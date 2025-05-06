using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
using System;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Gui.Controls;
using UpgradeHelpers.Helpers;
using UpgradeStubs;

namespace JETNET_Homebase
{
	internal static class modCommon
	{



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




		[Serializable]
		public class Monitor_Cursor_Movement //gap-note Struct changed to class. VBUC feature.
		{

			public string UserId;
			public int xPos;
			public int yPos;
			public int lElapsedTime; // Seconds
			public System.DateTime dtDateTime; // Date Last Checked
			public bool bCursorPaused;

			public static Monitor_Cursor_Movement CreateInstance()
			{
				Monitor_Cursor_Movement result = new Monitor_Cursor_Movement();
				result.UserId = String.Empty;
				return result;
			}
		}

		[Serializable]
		public class JETNET_API_Record //gap-note Struct changed to class. VBUC feature.
		{

			public int lContactId;
			public int lSubId;
			public string strLogin;
			public int lSeqNbr;
			public string strEMail;
			public string strPassword;
			public string strToken;
			public string strHeader;
			public bool bHasAPILogin;

			public static JETNET_API_Record CreateInstance()
			{
				JETNET_API_Record result = new JETNET_API_Record();
				result.strLogin = String.Empty;
				result.strEMail = String.Empty;
				result.strPassword = String.Empty;
				result.strToken = String.Empty;
				result.strHeader = String.Empty;
				return result;
			}
		}





		public const int MAX_PATH = 255;
		public const int MAX_VALUE = 255;

		// MATT TBD CRM
		public const string gstrCRMMktConn = "Driver={MySQL ODBC 3.51 Driver};Server=192.69.4.165;Port=3306;Database=crmmarketing_client_db;Uid=jetnetmark_user;Pwd=fubar#01;OPTION=3;";

		public const int BIF_RETURNONLYFSDIRS = 1;
		public const int BIF_DONTGOBELOWDOMAIN = 2;

		public const int REG_SZ = 1;
		public const int HKEY_CLASSES_ROOT = unchecked((int) 0x80000000);
		public const int HKEY_CURRENT_USER = unchecked((int) 0x80000001);
		public const int HKEY_LOCAL_MACHINE = unchecked((int) 0x80000002);
		public const int HKEY_USERS = unchecked((int) 0x80000003);
		public const int KEY_ALL_ACCESS = 0x3F;

		//UPGRADE_NOTE: (2041) The following line was commented. More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-2041
		//[DllImport("user32.dll", EntryPoint = "SendMessageA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		//extern public static int SendMessage(int hWnd, int wMsg, int wParam, System.IntPtr lparam);
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
		////UPGRADE_TODO: (1050) Structure OPENFILENAME may require marshalling attributes to be passed as an argument in this Declare statement. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1050
		//[DllImport("comdlg32.dll", EntryPoint = "GetOpenFileNameA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		//extern public static int GetOpenFileName(ref JetNetSupport.PInvoke.UnsafeNative.Structures.OPENFILENAME pOpenfilename);
		//UPGRADE_NOTE: (2041) The following line was commented. More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-2041
		////UPGRADE_TODO: (1050) Structure POINTAPI may require marshalling attributes to be passed as an argument in this Declare statement. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1050
		//[DllImport("user32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		//extern public static int GetCursorPos(ref JetNetSupport.PInvoke.UnsafeNative.Structures.POINTAPI lpPoint);

		public const int CSIDLDESKTOP = 0x0;
		public const int CSIDLPROGRAMS = 0x2;
		public const int CSIDLCONTROLS = 0x3;
		public const int CSIDLPRINTERS = 0x4;
		public const int CSIDLPERSONAL = 0x5;
		public const int CSIDLFAVORITES = 0x6;
		public const int CSIDLSTARTUP = 0x7;
		public const int CSIDLRECENT = 0x8;
		public const int CSIDLSENDTO = 0x9;
		public const int CSIDLBITBUCKET = 0xA;
		public const int CSIDLSTARTMENU = 0xB;
		public const int CSIDLDESKTOPDIRECTORY = 0x10;
		public const int CSIDLDRIVES = 0x11;
		public const int CSIDLNETWORK = 0x12;
		public const int CSIDLNETHOOD = 0x13;
		public const int CSIDLFONTS = 0x14;
		public const int CSIDLTEMPLATES = 0x15;
		public const int MAXPATH = 260;

		//UPGRADE_NOTE: (2041) The following line was commented. More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-2041
		//[DllImport("shell32.dll", EntryPoint = "ShellAboutA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		//extern public static int ShellAbout(int hWnd, [MarshalAs(UnmanagedType.VBByRefStr)] ref string szApp, [MarshalAs(UnmanagedType.VBByRefStr)] ref string szOtherStuff, int hIcon);
		//UPGRADE_NOTE: (2041) The following line was commented. More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-2041
		////UPGRADE_TODO: (1050) Structure ITEMIDLIST may require marshalling attributes to be passed as an argument in this Declare statement. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1050
		//[DllImport("shell32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		//extern public static int SHGetSpecialFolderLocation(int hwndOwner, int nFolder, ref JetNetSupport.PInvoke.UnsafeNative.Structures.ITEMIDLIST pidl);

		// Windows API for Browsing a Folder
		//UPGRADE_NOTE: (2041) The following line was commented. More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-2041
		////UPGRADE_TODO: (1050) Structure BrowseInfo may require marshalling attributes to be passed as an argument in this Declare statement. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1050
		//[DllImport("shell32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		//extern public static int SHBrowseForFolder(ref JetNetSupport.PInvoke.UnsafeNative.Structures.BrowseInfo lpbi);

		// Windows API for Getting the Path from a List
		//UPGRADE_NOTE: (2041) The following line was commented. More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-2041
		//[DllImport("shell32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		//extern public static int SHGetPathFromIDList(int pidList, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpBuffer);

		//UPGRADE_NOTE: (2041) The following line was commented. More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-2041
		//[DllImport("shell32.dll", EntryPoint = "ShellExecuteA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		//extern public static int ShellExecute(int hWnd, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpOperation, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpFile, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpParameters, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpDirectory, int nShowCmd);
		public const int SW_SHOWNORMAL = 1;

		//UPGRADE_NOTE: (2041) The following line was commented. More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-2041
		//[DllImport("Kernel32.dll", EntryPoint = "lstrcatA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		//extern public static int lstrcat([MarshalAs(UnmanagedType.VBByRefStr)] ref string lpString1, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpString2);

		//UPGRADE_NOTE: (2041) The following line was commented. More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-2041
		////UPGRADE_TODO: (1050) Structure GUID may require marshalling attributes to be passed as an argument in this Declare statement. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1050
		//[DllImport("OLE32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		//extern public static int CoCreateGuid(ref JetNetSupport.PInvoke.UnsafeNative.Structures.GUID pGuid);

		//UPGRADE_NOTE: (2041) The following line was commented. More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-2041
		//[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		//extern public static int OpenProcess(int dwDesiredAccess, int bInheritHandle, int dwProcessId);
		//UPGRADE_NOTE: (2041) The following line was commented. More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-2041
		//[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		//extern public static int CloseHandle(int hObject);

		//UPGRADE_NOTE: (2041) The following line was commented. More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-2041
		//[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		//extern public static void Sleep(int dwMilliseconds);
		public static Monitor_Cursor_Movement mcmUser = Monitor_Cursor_Movement.CreateInstance();
		public static JETNET_API_Record JAPI = JETNET_API_Record.CreateInstance();
		public static bool gbUseTLS = false;

		internal static void Clear_JETNET_API_Record()
		{


			JAPI.lContactId = 0;
			JAPI.lSubId = 0;
			JAPI.strLogin = "";
			JAPI.lSeqNbr = 0;
			JAPI.strEMail = "";
			JAPI.strPassword = "";
			JAPI.strToken = "";
			JAPI.strHeader = "";
			JAPI.bHasAPILogin = false;


		} // Clear_JETNET_API_Record

		internal static string Current_Current_Ac_Stage(int ac_id, int ac_journ_id)
		{

			string result = "";
			result = "3";


			string Query = $"select top 1 ac_lifecycle_stage from aircraft with (NOLOCK) where ac_id = {ac_id.ToString()}";
			Query = $"{Query} and ac_journ_id =  {ac_journ_id.ToString()}";


			ADORecordSetHelper ado_ResearchNotes = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

			if (!(ado_ResearchNotes.BOF && ado_ResearchNotes.EOF))
			{



				while(!ado_ResearchNotes.EOF)
				{

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(ado_ResearchNotes["ac_lifecycle_stage"]))
					{
						if (Convert.ToString(ado_ResearchNotes["ac_lifecycle_stage"]).Trim() != modGlobalVars.cEmptyString)
						{
							result = Convert.ToString(ado_ResearchNotes["ac_lifecycle_stage"]).Trim();
						}
					}

					ado_ResearchNotes.MoveNext();

				};

			}

			return result;
		}

		internal static string Current_Current_Ac_Status(int ac_id, int ac_journ_id)
		{

			string result = "";


			string Query = $"select top 1 ac_status from aircraft with (NOLOCK) where ac_id = {ac_id.ToString()}";
			Query = $"{Query} and ac_journ_id =  {ac_journ_id.ToString()}";


			ADORecordSetHelper ado_ResearchNotes = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

			if (!(ado_ResearchNotes.BOF && ado_ResearchNotes.EOF))
			{



				while(!ado_ResearchNotes.EOF)
				{

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(ado_ResearchNotes["ac_status"]))
					{
						if (Convert.ToString(ado_ResearchNotes["ac_status"]).Trim() != modGlobalVars.cEmptyString)
						{
							result = Convert.ToString(ado_ResearchNotes["ac_status"]).Trim();
						}
					}

					ado_ResearchNotes.MoveNext();

				};

			}

			return result;
		}

		internal static void Set_JETNET_API_Record()
		{

			bool bHASAPI = false;

			Clear_JETNET_API_Record();

			bHASAPI = modSubscription.Does_Current_User_Have_JETNETAPI_Login(ref JAPI.lContactId, ref JAPI.lSubId, ref JAPI.strLogin, ref JAPI.lSeqNbr, ref JAPI.strEMail, ref JAPI.strPassword);
			JAPI.bHasAPILogin = bHASAPI;

		} // Set_JETNET_API_Record

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

				modAdminCommon.Report_Error("Highlight_Grid_Row_Error", excep.Message);
			}

		} // Highlight_Grid_Row


		internal static bool IsProcessRunning(int lAppId)
		{

			bool result = false;
			const int cAccess = 0x100000;
			int lProcessId = 0;
			bool bResults = false;

			try
			{

				bResults = false;

				if (lAppId != 0)
				{

					lProcessId = JetNetSupport.PInvoke.SafeNative.kernel32.OpenProcess(cAccess, 0, lAppId);

					if (lProcessId != 0)
					{
						bResults = true;
						JetNetSupport.PInvoke.SafeNative.kernel32.CloseHandle(lProcessId);
					}

				} // If lAppId <> 0 Then


				return bResults;
			}
			catch (Exception e)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				if (Information.Err().Number == 5)
				{
					Application.DoEvents();
					result = false;
				}
				else
				{
					//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1065
					UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
				}
			}
			return result;
		} // End Function IsProcessRunning

		internal static string pubf_URLEncode(string StringToEncode, bool UsePlusRatherThanHexForSpace = false)
		{

			StringBuilder TempAns = new StringBuilder();

			int CurChr = 1;

			while(CurChr - 1 != Strings.Len(StringToEncode))
			{
				int switchVar = Strings.Asc(StringToEncode.Substring(Math.Min(CurChr - 1, StringToEncode.Length), Math.Min(1, Math.Max(0, StringToEncode.Length - (CurChr - 1))))[0]);
				if (switchVar >= 48 && switchVar <= 57 || switchVar >= 65 && switchVar <= 90 || switchVar >= 97 && switchVar <= 122)
				{
					TempAns.Append(StringToEncode.Substring(Math.Min(CurChr - 1, StringToEncode.Length), Math.Min(1, Math.Max(0, StringToEncode.Length - (CurChr - 1)))));
				}
				else if (switchVar == 32)
				{ 
					if (UsePlusRatherThanHexForSpace)
					{
						TempAns.Append("+");
					}
					else
					{
						TempAns.Append($"%{(32).ToString("X")}");
					}
				}
				else
				{
					TempAns.Append($"%" +
					               $"{StringsHelper.Format(Strings.Asc(StringToEncode.Substring(Math.Min(CurChr - 1, StringToEncode.Length), Math.Min(1, Math.Max(0, StringToEncode.Length - (CurChr - 1))))[0]).ToString("X"), "00")}");
				}

				CurChr++;
			};

			return TempAns.ToString();

		} // pubf_URLEncode

		internal static string GetGUID(bool bStandard = false)
		{
			//(c) 2000 Gus Molina

			JetNetSupport.PInvoke.UnsafeNative.Structures.GUID udtGUID = JetNetSupport.PInvoke.UnsafeNative.Structures.GUID.CreateInstance();

			string strGUID = "";

			if (JetNetSupport.PInvoke.SafeNative.ole32.CoCreateGuid(ref udtGUID) == 0)
			{

				if (!bStandard)
				{
					strGUID = $"{new string('0', 8 - Strings.Len(udtGUID.Data1.ToString("X")))}{udtGUID.Data1.ToString("X")}" +
					          $"{new string('0', 4 - Strings.Len(udtGUID.Data2.ToString("X")))}{udtGUID.Data2.ToString("X")}" +
					          $"{new string('0', 4 - Strings.Len(udtGUID.Data3.ToString("X")))}{udtGUID.Data3.ToString("X")}" +
					          $"{(((udtGUID.Data4[0] < 0x10)) ? "0" : "")}{udtGUID.Data4[0].ToString("X")}" +
					          $"{(((udtGUID.Data4[1] < 0x10)) ? "0" : "")}{udtGUID.Data4[1].ToString("X")}" +
					          $"{(((udtGUID.Data4[2] < 0x10)) ? "0" : "")}{udtGUID.Data4[2].ToString("X")}" +
					          $"{(((udtGUID.Data4[3] < 0x10)) ? "0" : "")}{udtGUID.Data4[3].ToString("X")}" +
					          $"{(((udtGUID.Data4[4] < 0x10)) ? "0" : "")}{udtGUID.Data4[4].ToString("X")}" +
					          $"{(((udtGUID.Data4[5] < 0x10)) ? "0" : "")}{udtGUID.Data4[5].ToString("X")}" +
					          $"{(((udtGUID.Data4[6] < 0x10)) ? "0" : "")}{udtGUID.Data4[6].ToString("X")}" +
					          $"{(((udtGUID.Data4[7] < 0x10)) ? "0" : "")}{udtGUID.Data4[7].ToString("X")}";
				}
				else
				{
					strGUID = $"{new string('0', 8 - Strings.Len(udtGUID.Data1.ToString("X")))}{udtGUID.Data1.ToString("X")}-" +
					          $"{new string('0', 4 - Strings.Len(udtGUID.Data2.ToString("X")))}{udtGUID.Data2.ToString("X")}-" +
					          $"{new string('0', 4 - Strings.Len(udtGUID.Data3.ToString("X")))}{udtGUID.Data3.ToString("X")}-" +
					          $"{(((udtGUID.Data4[0] < 0x10)) ? "0" : "")}{udtGUID.Data4[0].ToString("X")}" +
					          $"{(((udtGUID.Data4[1] < 0x10)) ? "0" : "")}{udtGUID.Data4[1].ToString("X")}-" +
					          $"{(((udtGUID.Data4[2] < 0x10)) ? "0" : "")}{udtGUID.Data4[2].ToString("X")}" +
					          $"{(((udtGUID.Data4[3] < 0x10)) ? "0" : "")}{udtGUID.Data4[3].ToString("X")}" +
					          $"{(((udtGUID.Data4[4] < 0x10)) ? "0" : "")}{udtGUID.Data4[4].ToString("X")}" +
					          $"{(((udtGUID.Data4[5] < 0x10)) ? "0" : "")}{udtGUID.Data4[5].ToString("X")}" +
					          $"{(((udtGUID.Data4[6] < 0x10)) ? "0" : "")}{udtGUID.Data4[6].ToString("X")}" +
					          $"{(((udtGUID.Data4[7] < 0x10)) ? "0" : "")}{udtGUID.Data4[7].ToString("X")}";
					strGUID = strGUID.ToLower();
				}

			}

			return strGUID;

		} // GetGUID

		internal static string pubf_URLDecode(string StringToDecode)
		{

			StringBuilder TempAns = new StringBuilder();

			int CurChr = 1;


			while(CurChr - 1 != Strings.Len(StringToDecode))
			{
				switch(StringToDecode.Substring(Math.Min(CurChr - 1, StringToDecode.Length), Math.Min(1, Math.Max(0, StringToDecode.Length - (CurChr - 1)))))
				{
					case "+" : 
						TempAns.Append(" "); 
						break;
					case "%" : 
						TempAns.Append(Strings.Chr(Convert.ToInt32(Conversion.Val($"&h" +
						               $"{StringToDecode.Substring(Math.Min(CurChr, StringToDecode.Length), Math.Min(2, Math.Max(0, StringToDecode.Length - CurChr)))}"))).ToString()); 
						CurChr += 2; 
						break;
					default:
						TempAns.Append(StringToDecode.Substring(Math.Min(CurChr - 1, StringToDecode.Length), Math.Min(1, Math.Max(0, StringToDecode.Length - (CurChr - 1))))); 
						break;
				}

				CurChr++;
			};

			return TempAns.ToString();

		} // pubf_URLDecode

		internal static double pubf_ReturnNumberFromDollarAmt(string inTxtDollarAmt) => Conversion.Val(StringsHelper.Replace(StringsHelper.Replace(inTxtDollarAmt.Trim(), ",", "", 1, -1, CompareMethod.Binary), "$", "", 1, -1, CompareMethod.Binary));


		internal static void pubf_ReturnToStartPage(modGlobalVars.e_first_start_form tStart)
		{

			Form Obj = null;
			Form Frm = null;

			bool bIsLoaded = false;

			foreach (Form ObjIterator in Application.OpenForms)
			{
				Obj = ObjIterator;
				if (String.Compare(Obj.Name, pubf_StartFormToString(tStart), true) == 0)
				{
					bIsLoaded = true;
					Frm = Obj;
					break;
				}
				//Obj
				Obj = default(Form);
			}

			if (pubf_EncodeStartForm(tStart) != modGlobalVars.gcCOMPANY)
			{

				if (bIsLoaded)
				{
					modAdminCommon.Record_Event("Monitor Activity", $"pubf_ReturnToStartPage 1 - {Frm.Name}", 0, 0, 0, false, 0, 0);
					Frm.Show();
					Frm.BringToFront(); //gap-note Manual change to fix BringToFront rule failing sometimes
				}
				else
				{

					// if we cant find a page to go back to then go to the main page
					foreach (Form ObjIterator2 in Application.OpenForms)
					{
						Obj = ObjIterator2;
						if (String.Compare(Obj.Name, modGlobalVars.gcMAINPAGE_STR, true) == 0)
						{
							Frm = Obj;
							break;
						}
						//Obj
						Obj = default(Form);
					}

					modAdminCommon.Record_Event("Monitor Activity", $"pubf_ReturnToStartPage 2 - {Frm.Name}", 0, 0, 0, false, 0, 0);
					Frm.Show();
					Frm.BringToFront(); //gap-note Manual change to fix BringToFront rule failing sometimes

				}

			}
			else
			{

				if (modGlobalVars.bCallShowAndLoadOnlyOnce)
				{

					//UPGRADE_TODO: (1067) Member Name is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					modAdminCommon.Record_Event("Monitor Activity", $"pubf_ReturnToStartPage 3 - {Convert.ToString(modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_NEW].Name)}", 0, 0, 0, false, 0, 0);
					//UPGRADE_TODO: (1067) Member Show is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_NEW].Show();

					modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_NEW].BringToFront(); //gap-note Manual change to fix BringToFront rule failing sometimes

				}

			} // If pubf_EncodeStartForm(tStart) <> gcCOMPANY Then

		} // pubf_ReturnToStartPage

		internal static modGlobalVars.e_first_start_form pubf_DecodeStartForm(int tStart)
		{


			switch((tStart))
			{
				case modGlobalVars.gcCALLBACKS : 
					return modGlobalVars.e_first_start_form.geCallbackForm;
				case modGlobalVars.gcAIRCRAFT : 
					return modGlobalVars.e_first_start_form.geAircraftForm;
				case modGlobalVars.gcMODEL : 
					return modGlobalVars.e_first_start_form.geModelForm;
				case modGlobalVars.gcCOMPANY : 
					return modGlobalVars.e_first_start_form.geCompanyForm;
				case modGlobalVars.gcACCOUNT : 
					return modGlobalVars.e_first_start_form.geAccountForm;
				case modGlobalVars.gcADMIN : 
					return modGlobalVars.e_first_start_form.geAdminForm;
				case modGlobalVars.gcPUBS : 
					return modGlobalVars.e_first_start_form.gePubsForm;
				case modGlobalVars.gcNTSB : 
					return modGlobalVars.e_first_start_form.geNTSBForm;
				case modGlobalVars.gcCANREG : 
					return modGlobalVars.e_first_start_form.geCanRegForm;
				case modGlobalVars.gcDOCLOG : 
					return modGlobalVars.e_first_start_form.geDocLogForm;
				case modGlobalVars.gcUSERHISTORY : 
					return modGlobalVars.e_first_start_form.geUserHistoryForm;
				case modGlobalVars.gcYACHT : 
					return modGlobalVars.e_first_start_form.geYachtForm;
				default:
					return modGlobalVars.e_first_start_form.geMainForm; 

			}

		}

		internal static int pubf_EncodeStartForm(modGlobalVars.e_first_start_form tStart)
		{


			switch((tStart))
			{
				case modGlobalVars.e_first_start_form.geCallbackForm : 
					return modGlobalVars.gcCALLBACKS;
				case modGlobalVars.e_first_start_form.geAircraftForm : 
					return modGlobalVars.gcAIRCRAFT;
				case modGlobalVars.e_first_start_form.geModelForm : 
					return modGlobalVars.gcMODEL;
				case modGlobalVars.e_first_start_form.geCompanyForm : 
					return modGlobalVars.gcCOMPANY;
				case modGlobalVars.e_first_start_form.geAccountForm : 
					return modGlobalVars.gcACCOUNT;
				case modGlobalVars.e_first_start_form.geAdminForm : 
					return modGlobalVars.gcADMIN;
				case modGlobalVars.e_first_start_form.gePubsForm : 
					return modGlobalVars.gcPUBS;
				case modGlobalVars.e_first_start_form.geNTSBForm : 
					return modGlobalVars.gcNTSB;
				case modGlobalVars.e_first_start_form.geCanRegForm : 
					return modGlobalVars.gcCANREG;
				case modGlobalVars.e_first_start_form.geDocLogForm : 
					return modGlobalVars.gcDOCLOG;
				case modGlobalVars.e_first_start_form.geUserHistoryForm : 
					return modGlobalVars.gcUSERHISTORY;
				case modGlobalVars.e_first_start_form.geYachtForm : 
					return modGlobalVars.gcYACHT;
				default:
					return modGlobalVars.gcMAINPAGE; 

			}

		}

		internal static string pubf_StartFormToString(modGlobalVars.e_first_start_form tStart)
		{


			switch((tStart))
			{
				case modGlobalVars.e_first_start_form.geCallbackForm : 
					return modGlobalVars.gcCALLBACKS_STR;
				case modGlobalVars.e_first_start_form.geAircraftForm : 
					return modGlobalVars.gcAIRCRAFT_STR;
				case modGlobalVars.e_first_start_form.geModelForm : 
					return modGlobalVars.gcMODEL_STR;
				case modGlobalVars.e_first_start_form.geCompanyForm : 
					return modGlobalVars.gcCOMPANY_STR;
				case modGlobalVars.e_first_start_form.geAccountForm : 
					return modGlobalVars.gcACCOUNT_STR;
				case modGlobalVars.e_first_start_form.geAdminForm : 
					return modGlobalVars.gcADMIN_STR;
				case modGlobalVars.e_first_start_form.gePubsForm : 
					return modGlobalVars.gcPUBS_STR;
				case modGlobalVars.e_first_start_form.geNTSBForm : 
					return modGlobalVars.gcNTSB_STR;
				case modGlobalVars.e_first_start_form.geCanRegForm : 
					return modGlobalVars.gcCANREG_STR;
				case modGlobalVars.e_first_start_form.geDocLogForm : 
					return modGlobalVars.gcDOCLOG_STR;
				case modGlobalVars.e_first_start_form.geUserHistoryForm : 
					return modGlobalVars.gcUSERHISTORY_STR;
				default:
					return modGlobalVars.gcMAINPAGE_STR; 

			}

		}

		internal static modGlobalVars.e_find_form_entry_points pubf_DecodeEntryPoints(int tEntry)
		{


			switch((tEntry))
			{
				case modGlobalVars.gFIND_CHCT : 
					return modGlobalVars.e_find_form_entry_points.geChangeHistContact;
				case modGlobalVars.gFIND_ACCA : 
					return modGlobalVars.e_find_form_entry_points.geAssociateToAircraft;
				case modGlobalVars.gFIND_FDMF : 
					return modGlobalVars.e_find_form_entry_points.geFindManufacturer;
				case modGlobalVars.gFIND_ACOR : 
					return modGlobalVars.e_find_form_entry_points.geAddCompanyRelation;
				case modGlobalVars.gFIND_ASHR : 
					return modGlobalVars.e_find_form_entry_points.geAddShareRelation;
				case modGlobalVars.gFIND_1000 : 
					return modGlobalVars.e_find_form_entry_points.geFortune1000;
				case modGlobalVars.gFIND_ACCH : 
					return modGlobalVars.e_find_form_entry_points.geAircraftChange;
				case modGlobalVars.gFIND_ADOC : 
					return modGlobalVars.e_find_form_entry_points.geAircraftDocument;
				case modGlobalVars.gFIND_CBAK : 
					return modGlobalVars.e_find_form_entry_points.geAccountCallback;
				case modGlobalVars.gFIND_EXBK : 
					return modGlobalVars.e_find_form_entry_points.geExclusiveBroker;
				case modGlobalVars.gFIND_UserHistory : 
					return modGlobalVars.e_find_form_entry_points.geUserHistory;
				case modGlobalVars.gFIND_Yacht : 
					return modGlobalVars.e_find_form_entry_points.geYacht;
				default:
					return modGlobalVars.e_find_form_entry_points.geNoEntryPoint; 

			}

		}

		internal static int pubf_EncodeEntryPoints(modGlobalVars.e_find_form_entry_points tEntry)
		{


			switch((tEntry))
			{
				case modGlobalVars.e_find_form_entry_points.geChangeHistContact : 
					return modGlobalVars.gFIND_CHCT;
				case modGlobalVars.e_find_form_entry_points.geAssociateToAircraft : 
					return modGlobalVars.gFIND_ACCA;
				case modGlobalVars.e_find_form_entry_points.geFindManufacturer : 
					return modGlobalVars.gFIND_FDMF;
				case modGlobalVars.e_find_form_entry_points.geAddCompanyRelation : 
					return modGlobalVars.gFIND_ACOR;
				case modGlobalVars.e_find_form_entry_points.geAddShareRelation : 
					return modGlobalVars.gFIND_ASHR;
				case modGlobalVars.e_find_form_entry_points.geFortune1000 : 
					return modGlobalVars.gFIND_1000;
				case modGlobalVars.e_find_form_entry_points.geAircraftChange : 
					return modGlobalVars.gFIND_ACCH;
				case modGlobalVars.e_find_form_entry_points.geAircraftDocument : 
					return modGlobalVars.gFIND_ADOC;
				case modGlobalVars.e_find_form_entry_points.geAccountCallback : 
					return modGlobalVars.gFIND_CBAK;
				case modGlobalVars.e_find_form_entry_points.geExclusiveBroker : 
					return modGlobalVars.gFIND_EXBK;
				case modGlobalVars.e_find_form_entry_points.geUserHistory : 
					return modGlobalVars.gFIND_UserHistory;
				case modGlobalVars.e_find_form_entry_points.geYacht : 
					return modGlobalVars.gFIND_Yacht;
				default:
					return modGlobalVars.gFIND_NONE; 

			}

		}

		internal static string pubf_FindFormEntryPointsToString(modGlobalVars.e_find_form_entry_points tEntry)
		{


			switch((tEntry))
			{
				case modGlobalVars.e_find_form_entry_points.geChangeHistContact : 
					return modGlobalVars.STR_FIND_CHCT;
				case modGlobalVars.e_find_form_entry_points.geAssociateToAircraft : 
					return modGlobalVars.STR_FIND_ACCA;
				case modGlobalVars.e_find_form_entry_points.geFindManufacturer : 
					return modGlobalVars.STR_FIND_FDMF;
				case modGlobalVars.e_find_form_entry_points.geAddCompanyRelation : 
					return modGlobalVars.STR_FIND_ACOR;
				case modGlobalVars.e_find_form_entry_points.geAddShareRelation : 
					return modGlobalVars.STR_FIND_ASHR;
				case modGlobalVars.e_find_form_entry_points.geFortune1000 : 
					return modGlobalVars.STR_FIND_1000;
				case modGlobalVars.e_find_form_entry_points.geAircraftChange : 
					return modGlobalVars.STR_FIND_ACCH;
				case modGlobalVars.e_find_form_entry_points.geAircraftDocument : 
					return modGlobalVars.STR_FIND_ADOC;
				case modGlobalVars.e_find_form_entry_points.geAccountCallback : 
					return modGlobalVars.STR_FIND_CBAK;
				case modGlobalVars.e_find_form_entry_points.geExclusiveBroker : 
					return modGlobalVars.STR_FIND_EXBK;
				case modGlobalVars.e_find_form_entry_points.geUserHistory : 
					return modGlobalVars.STR_FIND_USERHISTORY;
				default:
					return modGlobalVars.STR_FIND_NONE; 

			}

		}

		internal static modGlobalVars.e_find_form_action_types pubf_DecodeEntryActions(int tEntry)
		{


			switch((tEntry))
			{
				case modGlobalVars.gFIND_GETSELLER : 
					return modGlobalVars.e_find_form_action_types.geGetSeller;
				case modGlobalVars.gFIND_GETOWNER : 
					return modGlobalVars.e_find_form_action_types.geGetOwner;
				case modGlobalVars.gFIND_GETBUYER : 
					return modGlobalVars.e_find_form_action_types.geGetBuyer;
				case modGlobalVars.gFIND_GETSEIZED : 
					return modGlobalVars.e_find_form_action_types.geSeizedBy;
				case modGlobalVars.gFIND_GETREPOBY : 
					return modGlobalVars.e_find_form_action_types.geReposessedBy;
				case modGlobalVars.gFIND_GETLESSR : 
					return modGlobalVars.e_find_form_action_types.geLessor;
				case modGlobalVars.gFIND_GETLESSE : 
					return modGlobalVars.e_find_form_action_types.geLessee;
				case modGlobalVars.gFIND_GETREGAS : 
					return modGlobalVars.e_find_form_action_types.geRegisteredAs;
				case modGlobalVars.gFIND_GETFAVOR : 
					return modGlobalVars.e_find_form_action_types.geInFavorOf;
				case modGlobalVars.gFIND_GETBEHALF : 
					return modGlobalVars.e_find_form_action_types.geOnBehalfOf;
				case modGlobalVars.gFIND_GETRUSTE :
					return modGlobalVars.e_find_form_action_types.geTrustee;
				case modGlobalVars.gFIND_GETSUBLES :
					return modGlobalVars.e_find_form_action_types.geSubLeasedTo;
				case modGlobalVars.gFIND_ASSOCCOMP : 
					return modGlobalVars.e_find_form_action_types.geAssociateComp;
				case modGlobalVars.gFIND_GETMANFAC : 
					return modGlobalVars.e_find_form_action_types.geGetManufacturer;
				case modGlobalVars.gFIND_IDCONTACT : 
					return modGlobalVars.e_find_form_action_types.geIdContact;
				case modGlobalVars.gFIND_IDCOMPANY : 
					return modGlobalVars.e_find_form_action_types.geIdCompany;
				case modGlobalVars.gFIND_EXBROKER : 
					return modGlobalVars.e_find_form_action_types.geExBroker;
				//case modGlobalVars.gFIND_UserHistory: gap - note this case was moved above since there are 2 cases with same value
					//UPGRADE_WARNING: (6021) Casting 'modGlobalVars.e_find_form_entry_points' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021 
					//return (modGlobalVars.e_find_form_action_types)modGlobalVars.e_find_form_entry_points.geUserHistory;
				case modGlobalVars.gFIND_Yacht : 
					//UPGRADE_WARNING: (6021) Casting 'modGlobalVars.e_find_form_entry_points' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021 
					return (modGlobalVars.e_find_form_action_types) modGlobalVars.e_find_form_entry_points.geYacht;
				default:
					return modGlobalVars.e_find_form_action_types.geNoAction; 

			}

		}

		internal static int pubf_EncodeEntryActions(modGlobalVars.e_find_form_action_types tEntry)
		{

			//UPGRADE_WARNING: (6021) Casting 'modGlobalVars.e_find_form_action_types' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021

			switch(((modGlobalVars.e_find_form_entry_points) tEntry))
			{
				case (modGlobalVars.e_find_form_entry_points) modGlobalVars.e_find_form_action_types.geGetSeller : 
					return modGlobalVars.gFIND_GETSELLER;
				case (modGlobalVars.e_find_form_entry_points) modGlobalVars.e_find_form_action_types.geGetOwner : 
					return modGlobalVars.gFIND_GETOWNER;
				case (modGlobalVars.e_find_form_entry_points) modGlobalVars.e_find_form_action_types.geGetBuyer : 
					return modGlobalVars.gFIND_GETBUYER;
				case (modGlobalVars.e_find_form_entry_points) modGlobalVars.e_find_form_action_types.geSeizedBy : 
					return modGlobalVars.gFIND_GETSEIZED;
				case (modGlobalVars.e_find_form_entry_points) modGlobalVars.e_find_form_action_types.geReposessedBy : 
					return modGlobalVars.gFIND_GETREPOBY;
				case (modGlobalVars.e_find_form_entry_points) modGlobalVars.e_find_form_action_types.geLessor : 
					return modGlobalVars.gFIND_GETLESSR;
				case (modGlobalVars.e_find_form_entry_points) modGlobalVars.e_find_form_action_types.geLessee : 
					return modGlobalVars.gFIND_GETLESSE;
				case (modGlobalVars.e_find_form_entry_points) modGlobalVars.e_find_form_action_types.geRegisteredAs : 
					return modGlobalVars.gFIND_GETREGAS;
				case (modGlobalVars.e_find_form_entry_points) modGlobalVars.e_find_form_action_types.geInFavorOf : 
					return modGlobalVars.gFIND_GETFAVOR;
				case (modGlobalVars.e_find_form_entry_points) modGlobalVars.e_find_form_action_types.geOnBehalfOf : 
					return modGlobalVars.gFIND_GETBEHALF;
				case (modGlobalVars.e_find_form_entry_points) modGlobalVars.e_find_form_action_types.geTrustee : 
					return modGlobalVars.gFIND_GETRUSTE;
				case (modGlobalVars.e_find_form_entry_points) modGlobalVars.e_find_form_action_types.geSubLeasedTo : 
					return modGlobalVars.gFIND_GETSUBLES;
				case (modGlobalVars.e_find_form_entry_points) modGlobalVars.e_find_form_action_types.geAssociateComp : 
					return modGlobalVars.gFIND_ASSOCCOMP;
				case (modGlobalVars.e_find_form_entry_points) modGlobalVars.e_find_form_action_types.geGetManufacturer : 
					return modGlobalVars.gFIND_GETMANFAC;
				case (modGlobalVars.e_find_form_entry_points) modGlobalVars.e_find_form_action_types.geIdContact : 
					return modGlobalVars.gFIND_IDCONTACT;
				case (modGlobalVars.e_find_form_entry_points) modGlobalVars.e_find_form_action_types.geIdCompany : 
					return modGlobalVars.gFIND_IDCOMPANY;
				case (modGlobalVars.e_find_form_entry_points) modGlobalVars.e_find_form_action_types.geExBroker : 
					return modGlobalVars.gFIND_EXBROKER;
				//case modGlobalVars.e_find_form_entry_points.geUserHistory : //gap-note geUserHistory has the same value of geSubLeasedTo
				//	return modGlobalVars.gFIND_UserHistory;
				case modGlobalVars.e_find_form_entry_points.geYacht : 
					return modGlobalVars.gFIND_Yacht;
				default:
					return modGlobalVars.gFIND_NOACTION; 

			}

		}

		internal static string pubf_FindFormEntryActionsToString(modGlobalVars.e_find_form_action_types tEntry)
		{

			//UPGRADE_WARNING: (6021) Casting 'modGlobalVars.e_find_form_action_types' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021

			switch(((modGlobalVars.e_find_form_entry_points) tEntry))
			{
				case (modGlobalVars.e_find_form_entry_points) modGlobalVars.e_find_form_action_types.geGetSeller : 
					return modGlobalVars.STR_FIND_GETSELLER;
				case (modGlobalVars.e_find_form_entry_points) modGlobalVars.e_find_form_action_types.geGetOwner : 
					return modGlobalVars.STR_FIND_GETOWNER;
				case (modGlobalVars.e_find_form_entry_points) modGlobalVars.e_find_form_action_types.geGetBuyer : 
					return modGlobalVars.STR_FIND_GETBUYER;
				case (modGlobalVars.e_find_form_entry_points) modGlobalVars.e_find_form_action_types.geSeizedBy : 
					return modGlobalVars.STR_FIND_GETSEIZED;
				case (modGlobalVars.e_find_form_entry_points) modGlobalVars.e_find_form_action_types.geReposessedBy : 
					return modGlobalVars.STR_FIND_GETREPOBY;
				case (modGlobalVars.e_find_form_entry_points) modGlobalVars.e_find_form_action_types.geLessor : 
					return modGlobalVars.STR_FIND_GETLESSR;
				case (modGlobalVars.e_find_form_entry_points) modGlobalVars.e_find_form_action_types.geLessee : 
					return modGlobalVars.STR_FIND_GETLESSE;
				case (modGlobalVars.e_find_form_entry_points) modGlobalVars.e_find_form_action_types.geRegisteredAs : 
					return modGlobalVars.STR_FIND_GETREGAS;
				case (modGlobalVars.e_find_form_entry_points) modGlobalVars.e_find_form_action_types.geInFavorOf : 
					return modGlobalVars.STR_FIND_GETFAVOR;
				case (modGlobalVars.e_find_form_entry_points) modGlobalVars.e_find_form_action_types.geOnBehalfOf : 
					return modGlobalVars.STR_FIND_GETBEHALF;
				case (modGlobalVars.e_find_form_entry_points) modGlobalVars.e_find_form_action_types.geTrustee : 
					return modGlobalVars.STR_FIND_GETRUSTE;
				case (modGlobalVars.e_find_form_entry_points) modGlobalVars.e_find_form_action_types.geSubLeasedTo : 
					return modGlobalVars.STR_FIND_GETSUBLES;
				case (modGlobalVars.e_find_form_entry_points) modGlobalVars.e_find_form_action_types.geAssociateComp : 
					return modGlobalVars.STR_FIND_ASSOCCOMP;
				case (modGlobalVars.e_find_form_entry_points) modGlobalVars.e_find_form_action_types.geGetManufacturer : 
					return modGlobalVars.STR_FIND_GETMANFAC;
				case (modGlobalVars.e_find_form_entry_points) modGlobalVars.e_find_form_action_types.geIdContact : 
					return modGlobalVars.STR_FIND_IDCONTACT;
				case (modGlobalVars.e_find_form_entry_points) modGlobalVars.e_find_form_action_types.geIdCompany : 
					return modGlobalVars.STR_FIND_IDCOMPANY;
				case (modGlobalVars.e_find_form_entry_points) modGlobalVars.e_find_form_action_types.geExBroker : 
					return modGlobalVars.STR_FIND_EXBROKER;
				//case modGlobalVars.e_find_form_entry_points.geUserHistory :  //gap-note geUserHistory has the same value of geSubLeasedTo
				//	return modGlobalVars.STR_FIND_USERHISTORY;
				case modGlobalVars.e_find_form_entry_points.geYacht : 
					return modGlobalVars.STR_FIND_YACHT;
				default:
					return modGlobalVars.STR_FIND_NOACTION; 

			}

		}

		static int nTraceCallCount_GetNextTraceCallCount = 0;
		internal static int GetNextTraceCallCount()
		{
			//TraceCallCount ID generator
			nTraceCallCount_GetNextTraceCallCount++;
			return nTraceCallCount_GetNextTraceCallCount;
		}

		static string nRememberUserDB_GetLastUserDB = "";
		internal static string GetLastUserDB(string inDb)
		{
			//TraceCallCount ID generator
			if (inDb != "")
			{
				nRememberUserDB_GetLastUserDB = inDb;
			}
			return nRememberUserDB_GetLastUserDB;
		}

		internal static bool BuildJournalSubjectJournID(int inSellerJournID)
		{
			//aey 7/2/04

			bool result = false;
			string Prefix = "";
			string Separator = "";
			string SellerName = "";
			string BuyerName = "";
			string Query = "";
			ADORecordSetHelper snpJcat = new ADORecordSetHelper();
			ADORecordSetHelper snpACRef = new ADORecordSetHelper();
			ADORecordSetHelper snpJournal = new ADORecordSetHelper();
			int SeqNO = 0;
			string inSubCatCode = "";
			int inSellerCompID = 0;
			int inBuyerCompID = 0;
			string JournalSubject = "";
			string strError = "";


			try
			{

				if (inSellerJournID == 0)
				{
					return result;
				}

				result = true;

				strError = "open journal";
				//open the journal record
				Query = $"SELECT * FROM Journal WITH(NOLOCK) WHERE journ_id = {inSellerJournID.ToString()}";
				snpJournal.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (snpJournal.BOF && snpJournal.EOF)
				{
					strError = "no rec";
					snpJournal = null;
					throw new Exception();
					return result;
				}

				inSubCatCode = $"{Convert.ToString(snpJournal["journ_subcategory_code"])}";

				snpJournal.Close();
				snpJournal = null;

				strError = "open jcat";
				Query = "SELECT jcat_subcategory_subjectprefix, jcat_subcategory_subjectseparator";
				Query = $"{Query} FROM Journal_Category WITH(NOLOCK)";
				Query = $"{Query} WHERE jcat_subcategory_code = '{inSubCatCode}'";

				snpJcat.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpJcat.BOF && snpJcat.EOF))
				{
					Prefix = ($"{Convert.ToString(snpJcat["jcat_subcategory_subjectprefix"])}").Trim();
					Separator = ($"{Convert.ToString(snpJcat["jcat_subcategory_subjectseparator"])}").Trim();
				}
				else
				{
					Prefix = "";
					Separator = "";
				}
				snpJcat.Close();
				snpJcat = null;

				strError = "open cref";

				Query = "SELECT cref_transmit_seq_no,cref_comp_id FROM aircraft_reference WITH(NOLOCK)";
				Query = $"{Query} WHERE cref_journ_id = {inSellerJournID.ToString()}";
				Query = $"{Query} AND (cref_transmit_seq_no = 1 OR cref_transmit_seq_no = 10) ORDER BY cref_transmit_seq_no";
				snpACRef.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (snpACRef.BOF && snpACRef.EOF)
				{
					strError = "no cref";
					snpACRef = null;
					throw new Exception();
					return result;
				}

				inSellerCompID = 0;
				inBuyerCompID = 0;
				SellerName = "";
				BuyerName = "";

				strError = "get acref";

				while (!snpACRef.EOF)
				{
					SeqNO = Convert.ToInt32(snpACRef["cref_transmit_seq_no"]);
					if (SeqNO == 1)
					{
						inSellerCompID = Convert.ToInt32(snpACRef["cref_comp_id"]);
					}
					if (SeqNO == 10)
					{
						inBuyerCompID = Convert.ToInt32(snpACRef["cref_comp_id"]);
					}
					snpACRef.MoveNext();
				}

				strError = $" Buyer={inBuyerCompID.ToString()} Seller = {inSellerCompID.ToString()}";
				if (inSellerCompID == 0 || inBuyerCompID == 0)
				{
					strError = $"Buyer or Seller unknown. Buyer = {inBuyerCompID.ToString()} Seller = {inSellerCompID.ToString()}";
					result = false;
					throw new Exception();
				}

				snpACRef.Close();
				snpACRef = null;

				strError = "lookup";
				//lookup the  company names
				SellerName = GetCompanyName(inSellerCompID, inSellerJournID);
				BuyerName = GetCompanyName(inBuyerCompID, inSellerJournID);

				JournalSubject = ($"{Prefix}{modGlobalVars.cSingleSpace}{SellerName}{modGlobalVars.cSingleSpace}{Separator}{modGlobalVars.cSingleSpace}{BuyerName}").Trim();

				Query = $"UPDATE Journal SET journ_subject = '{JournalSubject.Substring(0, Math.Min(120, JournalSubject.Length))}' WHERE journ_id = {inSellerJournID.ToString()}";

				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = Query;
				TempCommand.CommandType = CommandType.Text;
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();

				return true;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"BuildJournalSubjectJournID_Error ({Information.Err().Number.ToString()}) {excep.Message} {strError}", "modCommon (Journal)");
			}
			return result;
		}

		internal static void Company_Stats_Update(int in_company_id)
		{

			string Query = "";
			int RememberTimeout = 0;

			try
			{

				if (in_company_id > 0)
				{
					Query = $"select cac_id from Company_Aircraft_Count where cac_comp_id={in_company_id.ToString()} and cac_journ_id=0";
					if (modAdminCommon.Exist(Query))
					{
						Query = $"update Company_Aircraft_Count set cac_update_date=NULL where cac_comp_id={in_company_id.ToString()} and cac_journ_id=0";
						DbCommand TempCommand = null;
						TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
						TempCommand.CommandText = Query;
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
						TempCommand.ExecuteNonQuery();
					}
					else
					{
						Query = $"insert into Company_Aircraft_Count (cac_comp_id,cac_journ_id, cac_product_type) values({in_company_id.ToString()},0,'B')";
						DbCommand TempCommand_2 = null;
						TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
						TempCommand_2.CommandText = Query;
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
						TempCommand_2.ExecuteNonQuery();
					}

				}
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Company_Stats_Update_Error ({Information.Err().Number.ToString()}) {excep.Message}", "modCommon (Company)");
				return;
			}
		}
		internal static void Create_Restricted_Record(int ac_id, string check_box_value, string reg_no, string ser_no, string type_of, string comp_name)
		{
			//

			string Query = "";
			int RememberTimeout = 0;
			string Query2 = "";

			try
			{

				if (ac_id > 0)
				{

					Query2 = $"select top 1 * from Aircraft_Restricted with (NOLOCK) where  acrestrict_ac_id = {ac_id.ToString()}";

					if (StringsHelper.ToDoubleSafe(check_box_value) == 1)
					{

						if (modAdminCommon.Exist(Query2))
						{
							Query = ""; // if it exists - dont need to update
						}
						else
						{
							Query = "insert into Aircraft_Restricted (acrestrict_ac_id, acrestrict_company, acrestrict_reg_no, acrestrict_ser_no, acrestrict_actype, acrestrict_entry_date, acrestrict_user_id ";
							Query = $"{Query} ) values(";
							Query = $"{Query}{ac_id.ToString()},'', '{reg_no}', '{ser_no}', '{type_of}', '{DateTimeHelper.ToString(DateTime.Today)}', '{modAdminCommon.gbl_User_ID}')";
							DbCommand TempCommand = null;
							TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
							TempCommand.CommandText = Query;
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
							TempCommand.ExecuteNonQuery();
						}

					}
					else
					{
						if (modAdminCommon.Exist(Query2))
						{
							//    then remove the record that was there
							Query = $"delete from Aircraft_Restricted where acrestrict_ac_id = {ac_id.ToString()}";
							DbCommand TempCommand_2 = null;
							TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
							TempCommand_2.CommandText = Query;
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
							TempCommand_2.ExecuteNonQuery();
						}
					}


				}
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Create_Restricted_Record ({Information.Err().Number.ToString()}) {excep.Message}", "modCommon (Company)");
				return;
			}
		}

		internal static string Format_Reg_No_Sort(string strRegNbr)
		{

			string strRegVal1 = "";
			string strRegVal2 = "";

			strRegNbr = ($"{strRegNbr} ").Trim();
			string strResults = strRegNbr;

			int iLen1 = Strings.Len(strRegNbr);

			if (iLen1 > 0)
			{

				// Remove All Non-Numeric Values
				strRegVal1 = "";
				strRegVal2 = "";
				int tempForEndVar = iLen1;
				for (int iCnt1 = 1; iCnt1 <= tempForEndVar; iCnt1++)
				{
					if ((String.CompareOrdinal(strRegNbr.Substring(Math.Min(iCnt1 - 1, strRegNbr.Length), Math.Min(1, Math.Max(0, strRegNbr.Length - (iCnt1 - 1)))), "0") >= 0) && (String.CompareOrdinal(strRegNbr.Substring(Math.Min(iCnt1 - 1, strRegNbr.Length), Math.Min(1, Math.Max(0, strRegNbr.Length - (iCnt1 - 1)))), "9") <= 0))
					{
						strRegVal1 = $"{strRegVal1}{strRegNbr.Substring(Math.Min(iCnt1 - 1, strRegNbr.Length), Math.Min(1, Math.Max(0, strRegNbr.Length - (iCnt1 - 1))))}";
					}
				}

				// Check To See If ANY Numeric Values Where Found
				if (strRegVal1 != "")
				{
					strRegVal2 = StringsHelper.Format(strRegVal1, "00000000");
					strResults = StringsHelper.Replace(strRegNbr, strRegVal1, strRegVal2, 1, -1, CompareMethod.Binary);
				}
				else
				{
					strResults = strRegNbr;
				}
			} // If iLen1 > 0 Then

			return strResults;

		} // End Function Format_Reg_No_Sort

		internal static void CompanyActivate(int inCompany_ID, int inJournal_ID = 0)
		{
			//activate company if inactive

			string Query = "";
			bool bStartTrans = false;

			try
			{

				Query = $"SELECT comp_id FROM company WITH(NOLOCK) WHERE comp_id = {inCompany_ID.ToString()}";
				Query = $"{Query} AND comp_journ_id = {inJournal_ID.ToString()}";
				Query = $"{Query} AND comp_active_flag = 'N'";

				if (modAdminCommon.Exist(Query))
				{

					// if we are not in a transaction and start one
					if (modAdminCommon.ADO_Transaction("CheckStatus") == 0)
					{
						modAdminCommon.ADO_Transaction("BeginTrans");
						bStartTrans = true;
					}

					Query = "UPDATE company SET comp_active_flag = 'Y'";
					Query = $"{Query} WHERE comp_id = {inCompany_ID.ToString()}";
					Query = $"{Query} AND comp_journ_id = {inJournal_ID.ToString()}";

					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();

				}

				// if we were in a transaction then commit it if we started it
				if (modAdminCommon.ADO_Transaction("CheckStatus") == 1 && bStartTrans)
				{
					modAdminCommon.ADO_Transaction("CommitTrans");
				}
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"CompanyActivate_Error ({Information.Err().Number.ToString()}) {excep.Message}", "modCommon (Transaction)");
				if (modAdminCommon.ADO_Transaction("CheckStatus") == 1 && bStartTrans)
				{
					modAdminCommon.ADO_Transaction("RollbackTrans");
				}
			}

		}

		internal static bool GetTransWeb(string PassedTransType)
		{

			bool result = false;
			string Query = "";
			string wFlag = "";
			ADORecordSetHelper adoWeb = new ADORecordSetHelper();

			try
			{

				result = false;

				Query = $"SELECT jcat_send_to_website from Journal_Category WITH(NOLOCK) WHERE jcat_subcategory_code = '{PassedTransType.Trim()}'";

				adoWeb.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(adoWeb.EOF && adoWeb.BOF))
				{

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(adoWeb["jcat_send_to_website"]))
					{

						wFlag = Convert.ToString(adoWeb["jcat_send_to_website"]);

						if (wFlag.ToUpper() == "Y")
						{
							result = true;
						}

					}

				}

				adoWeb.Close();
				adoWeb = null;

				return result;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"GetTransWeb_Error ({Information.Err().Number.ToString()}) {excep.Message}", "modCommon (Transaction)");
				return result;
			}
		}

		internal static bool AlreadyInArray(string[] inArray, string inText)
		{


			bool result = false;

			foreach (string inArray_item in inArray)
			{
				if (inText.Trim() == inArray_item.Trim())
				{
					return true;
				}
			}

			return result;
		}

		internal static bool HasPictures(int inAircraft_ID, int inJournal_ID, string strHideFlag = "")
		{

			bool result = false;
			try
			{

				string Query = "";
				ADORecordSetHelper snpPic = new ADORecordSetHelper();

				result = false;

				Query = "SELECT COUNT(*) AS PicCount FROM Aircraft_Pictures WITH (NOLOCK) ";
				Query = $"{Query}WHERE (acpic_ac_id = {inAircraft_ID.ToString()}) AND (acpic_journ_id = {inJournal_ID.ToString()}) ";


				if (strHideFlag != "")
				{
					Query = $"{Query}AND (acpic_hide_flag = '{strHideFlag}') ";
				}

				snpPic.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpPic.BOF && snpPic.EOF))
				{
					if (Convert.ToInt32(snpPic["PicCount"]) > 0)
					{
						result = true;
					}
				}
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"HasPictures_Error ({Information.Err().Number.ToString()}) {excep.Message}", "modCommon (Pictures)");
			}

			return result;
		}

		internal static int GetAwaitingDocsCompID(int inAircraft_ID, int inJournal_ID)
		{

			int result = 0;
			string Query = "";
			ADORecordSetHelper snpComp = new ADORecordSetHelper();

			try
			{

				result = 0;

				Query = "SELECT comp_id FROM Company WITH(NOLOCK)";
				Query = $"{Query} INNER JOIN Aircraft_Reference WITH(NOLOCK) ON cref_comp_id = comp_id AND cref_journ_id = comp_journ_id";
				Query = $"{Query} WHERE cref_ac_id = {inAircraft_ID.ToString()}";
				Query = $"{Query} AND cref_journ_id = {inJournal_ID.ToString()} AND comp_name = 'Awaiting Documentation'";

				snpComp.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpComp.BOF && snpComp.EOF))
				{
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snpComp["Comp_id"]))
					{
						result = Convert.ToInt32(snpComp["Comp_id"]);
					}
				}

				snpComp.Close();
				snpComp = null;

				return result;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"GetAwaitingDocsCompID_Error ({Information.Err().Number.ToString()}) {excep.Message}", "modCommon (Company)");
				return result;
			}
		}

		internal static bool CreateCurrentCompanyRecord(int incompid, int inJournID = 0)
		{

			bool result = false;
			string Query = "";
			ADORecordSetHelper snpNewComp = new ADORecordSetHelper();
			ADORecordSetHelper snpNewContact = new ADORecordSetHelper();
			ADORecordSetHelper snpNewPhone = new ADORecordSetHelper();
			ADORecordSetHelper snpNewBusType = new ADORecordSetHelper();

			try
			{

				result = false;

				if (!(modGlobalVars.snpCreateComp_Comp.BOF && modGlobalVars.snpCreateComp_Comp.EOF))
				{
					Query = "SELECT * FROM Company WHERE comp_id = -1";

					snpNewComp.Open(Query, modAdminCommon.ADODB_Trans_conn, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

					snpNewComp.AddNew();

					int tempForEndVar = snpNewComp.FieldsMetadata.Count - 1;
					for (int i = 0; i <= tempForEndVar; i++)
					{
						snpNewComp[i] = modGlobalVars.snpCreateComp_Comp[i];
					}

					if (($"{modGlobalVars.tmpCompAccountID}").Trim() != "")
					{
						snpNewComp["comp_account_id"] = modGlobalVars.tmpCompAccountID;
					}

					snpNewComp["comp_active_flag"] = "Y";
					snpNewComp["comp_journ_id"] = 0;

					snpNewComp.Update();

					if (inJournID > 0)
					{
						snpNewComp.AddNew();

						int tempForEndVar2 = snpNewComp.FieldsMetadata.Count - 1;
						for (int i = 0; i <= tempForEndVar2; i++)
						{
							snpNewComp[i] = modGlobalVars.snpCreateComp_Comp[i];
						}

						snpNewComp["comp_journ_id"] = inJournID;

						if (($"{modGlobalVars.tmpCompAccountID}").Trim() != "")
						{
							snpNewComp["comp_account_id"] = modGlobalVars.tmpCompAccountID;
						}

						snpNewComp.Update();
					}

				}

				snpNewComp.Close();
				snpNewComp = null;

				modGlobalVars.snpCreateComp_Comp.Close();
				modGlobalVars.snpCreateComp_Comp = null;

				if (!(modGlobalVars.snpCreateComp_Contact.BOF && modGlobalVars.snpCreateComp_Contact.EOF))
				{
					Query = "SELECT * FROM Contact WHERE contact_id = -1";

					snpNewContact.Open(Query, modAdminCommon.ADODB_Trans_conn, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);


					while(!modGlobalVars.snpCreateComp_Contact.EOF)
					{

						snpNewContact.AddNew();

						int tempForEndVar3 = modGlobalVars.snpCreateComp_Contact.FieldsMetadata.Count - 1;
						for (int i = 0; i <= tempForEndVar3; i++)
						{
							snpNewContact[i] = modGlobalVars.snpCreateComp_Contact[i];
						}
						snpNewContact["contact_journ_id"] = 0;
						snpNewContact.Update();

						modGlobalVars.snpCreateComp_Contact.MoveNext();
					};

					if (inJournID > 0)
					{
						modGlobalVars.snpCreateComp_Contact.MoveFirst();


						while(!modGlobalVars.snpCreateComp_Contact.EOF)
						{

							snpNewContact.AddNew();

							int tempForEndVar4 = modGlobalVars.snpCreateComp_Contact.FieldsMetadata.Count - 1;
							for (int i = 0; i <= tempForEndVar4; i++)
							{
								snpNewContact[i] = modGlobalVars.snpCreateComp_Contact[i];
							}
							snpNewContact["contact_journ_id"] = inJournID;
							snpNewContact.Update();

							modGlobalVars.snpCreateComp_Contact.MoveNext();

						};
					}

					snpNewContact.Close();
					snpNewContact = null;

				}

				modGlobalVars.snpCreateComp_Contact.Close();
				modGlobalVars.snpCreateComp_Contact = null;

				if (!(modGlobalVars.snpCreateComp_Phone.BOF && modGlobalVars.snpCreateComp_Phone.EOF))
				{
					Query = "SELECT * FROM Phone_Numbers WHERE pnum_comp_id = -1";

					snpNewPhone.Open(Query, modAdminCommon.ADODB_Trans_conn, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);


					while(!modGlobalVars.snpCreateComp_Phone.EOF)
					{

						snpNewPhone.AddNew();

						int tempForEndVar5 = modGlobalVars.snpCreateComp_Phone.FieldsMetadata.Count - 1;
						for (int i = 0; i <= tempForEndVar5; i++)
						{
							snpNewPhone[i] = modGlobalVars.snpCreateComp_Phone[i];
						}

						snpNewPhone["pnum_journ_id"] = 0;
						snpNewPhone.Update();

						modGlobalVars.snpCreateComp_Phone.MoveNext();
					};

					if (inJournID > 0)
					{
						modGlobalVars.snpCreateComp_Phone.MoveFirst();

						while(!modGlobalVars.snpCreateComp_Phone.EOF)
						{

							snpNewPhone.AddNew();

							int tempForEndVar6 = modGlobalVars.snpCreateComp_Phone.FieldsMetadata.Count - 1;
							for (int i = 0; i <= tempForEndVar6; i++)
							{
								snpNewPhone[i] = modGlobalVars.snpCreateComp_Phone[i];
							}

							snpNewPhone["pnum_journ_id"] = inJournID;
							snpNewPhone.Update();

							modGlobalVars.snpCreateComp_Phone.MoveNext();
						};
					}

					snpNewPhone.Close();
					snpNewPhone = null;
				}

				modGlobalVars.snpCreateComp_Phone.Close();
				modGlobalVars.snpCreateComp_Phone = null;

				if (!(modGlobalVars.snpCreateComp_BusType.BOF && modGlobalVars.snpCreateComp_BusType.EOF))
				{
					Query = "SELECT * FROM Business_Type_Reference WHERE bustypref_id = -1";

					snpNewBusType.Open(Query, modAdminCommon.ADODB_Trans_conn, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);


					while(!modGlobalVars.snpCreateComp_BusType.EOF)
					{

						snpNewBusType.AddNew();

						int tempForEndVar7 = modGlobalVars.snpCreateComp_BusType.FieldsMetadata.Count - 1;
						for (int i = 0; i <= tempForEndVar7; i++)
						{
							if (snpNewBusType.GetField(i).FieldMetadata.ColumnName != "bustypref_id")
							{
								snpNewBusType[i] = modGlobalVars.snpCreateComp_BusType[i];
							}
						}

						snpNewBusType["bustypref_journ_id"] = 0;
						snpNewBusType.Update();

						modGlobalVars.snpCreateComp_BusType.MoveNext();
					};

					if (inJournID > 0)
					{
						modGlobalVars.snpCreateComp_BusType.MoveFirst();


						while(!modGlobalVars.snpCreateComp_BusType.EOF)
						{

							snpNewBusType.AddNew();

							int tempForEndVar8 = modGlobalVars.snpCreateComp_BusType.FieldsMetadata.Count - 1;
							for (int i = 0; i <= tempForEndVar8; i++)
							{
								if (snpNewBusType.GetField(i).FieldMetadata.ColumnName != "bustypref_id")
								{
									snpNewBusType[i] = modGlobalVars.snpCreateComp_BusType[i];
								}
							}

							snpNewBusType["bustypref_journ_id"] = inJournID;
							snpNewBusType.Update();

							modGlobalVars.snpCreateComp_BusType.MoveNext();
						};
					}

					snpNewBusType.Close();
					snpNewBusType = null;
				}

				modGlobalVars.snpCreateComp_BusType.Close();
				modGlobalVars.snpCreateComp_BusType = null;


				return true;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"CreateCurrentCompanyRecord_Error ({Information.Err().Number.ToString()}) {excep.Message}", "modCommon (Company)");
			}
			return result;
		}

		internal static bool CreateCurrentCompanyRecordsets(int incompid, ref int outJournID)
		{

			bool result = false;
			string Query = "";
			ADORecordSetHelper snpTempJourn = new ADORecordSetHelper();

			try
			{

				result = false;

				Query = "SELECT MAX(comp_journ_id) AS MaxJourn FROM Company WITH(NOLOCK)";
				Query = $"{Query} WHERE comp_id = {incompid.ToString()}";

				snpTempJourn.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpTempJourn.BOF && snpTempJourn.EOF))
				{
					outJournID = Convert.ToInt32(snpTempJourn["MaxJourn"]);
				}
				else
				{
					//Historical Company Doesn't Exist - Exit With Value of False
					snpTempJourn.Close();
					return result;
				}

				snpTempJourn.Close();
				snpTempJourn = null;

				Query = $"SELECT * FROM Company WHERE comp_id = {incompid.ToString()}";
				Query = $"{Query} AND comp_journ_id = {outJournID.ToString()}";

				modGlobalVars.snpCreateComp_Comp = new ADORecordSetHelper();
				modGlobalVars.snpCreateComp_Comp.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

				modGlobalVars.tmpCompAccountID = "";
				if (!(modGlobalVars.snpCreateComp_Comp.BOF && modGlobalVars.snpCreateComp_Comp.EOF))
				{
					if (($"{Convert.ToString(modGlobalVars.snpCreateComp_Comp["comp_account_id"])}").Trim() == "")
					{
						if (($"{Convert.ToString(modGlobalVars.snpCreateComp_Comp["comp_assign_flag"])}").Trim() == "M")
						{
							modGlobalVars.tmpCompAccountID = "ID03"; //changed from ID01 to ID03  - MSW - 10/30/18
						}
						else
						{
							modGlobalVars.tmpCompAccountID = GetAutoAccountID(incompid, outJournID);
						}
					}
				}

				Query = $"SELECT * FROM Contact WHERE contact_comp_id = {incompid.ToString()}";
				Query = $"{Query} AND contact_journ_id = {outJournID.ToString()}";

				modGlobalVars.snpCreateComp_Contact = new ADORecordSetHelper();
				modGlobalVars.snpCreateComp_Contact.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

				Query = $"SELECT * FROM Phone_Numbers WHERE pnum_comp_id = {incompid.ToString()}";
				Query = $"{Query} AND pnum_journ_id = {outJournID.ToString()}";

				modGlobalVars.snpCreateComp_Phone = new ADORecordSetHelper();
				modGlobalVars.snpCreateComp_Phone.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);


				Query = $"SELECT * FROM Business_Type_Reference WHERE bustypref_comp_id = {incompid.ToString()}";
				Query = $"{Query} AND bustypref_journ_id = {outJournID.ToString()}";

				modGlobalVars.snpCreateComp_BusType = new ADORecordSetHelper();
				modGlobalVars.snpCreateComp_BusType.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

				return true;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"CreateCurrentCompanyRecordsets_Error ({Information.Err().Number.ToString()}) {excep.Message}", "modCommon (Company)");
			}
			return result;
		}

		internal static string GetAutoAccountID(object incompid, object inJournID)
		{

			string result = "";
			ADORecordSetHelper snpCompInfo = new ADORecordSetHelper();
			string tmpCompName = "";
			string tmpCompBusType = "";
			ADORecordSetHelper snp_AssignRep = new ADORecordSetHelper();
			string Query = "";
			int i = 0;

			try
			{

				result = "";

				Query = "SELECT comp_name, comp_business_type FROM Company WITH(NOLOCK)";
				//UPGRADE_WARNING: (1068) inJournID of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
				//UPGRADE_WARNING: (1068) incompid of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
				Query = $"{Query} WHERE comp_id = {Convert.ToString(incompid)} AND comp_journ_id = {Convert.ToString(inJournID)}";

				snpCompInfo.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpCompInfo.BOF && snpCompInfo.EOF))
				{
					tmpCompName = ($"{Convert.ToString(snpCompInfo["comp_name"])}").Trim();
					tmpCompBusType = ($"{Convert.ToString(snpCompInfo["comp_business_type"])}").Trim().ToUpper();
				}
				else
				{
					snpCompInfo.Close();
					snpCompInfo = null;
					return result;
				}

				snpCompInfo.Close();
				snpCompInfo = null;

				Query = "SELECT assign_db_account_id, assign_eu_account_id FROM Account_Rep_Assignment ";
				Query = $"{Query}WHERE assign_character = '{tmpCompName.Trim().Substring(0, Math.Min(1, tmpCompName.Trim().Length))}'";
				snp_AssignRep.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_AssignRep.BOF && snp_AssignRep.EOF))
				{
					if (tmpCompBusType.Trim() == "DB")
					{
						result = ($"{Convert.ToString(snp_AssignRep["assign_db_account_id"])}").Trim();
					}
					else
					{
						result = ($"{Convert.ToString(snp_AssignRep["assign_eu_account_id"])}").Trim();
					}
				}

				snp_AssignRep.Close();
				snp_AssignRep = null;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"GetAutoAccountID_Error ({Information.Err().Number.ToString()}) {excep.Message}", "modCommon");
			}

			return result;
		}

		internal static string BuildJournalSubject(string inSubCatCode, int inSellerCompID, int inSellerJournID, int inBuyerCompID, int inBuyerJournID, string inSellerName = "", string inBuyerName = "")
		{

			try
			{

				string Prefix = "";
				string Separator = "";
				string SellerName = "";
				string BuyerName = "";
				string Query = "";
				ADORecordSetHelper snpJcat = new ADORecordSetHelper();


				//===============================================
				// Get the Transaction Type, Prefix, Separator,
				// and ToFrom from the Journal_Category table
				//===============================================
				Query = "SELECT jcat_subcategory_subjectprefix, jcat_subcategory_subjectseparator ";
				Query = $"{Query}FROM Journal_Category WITH (NOLOCK) WHERE jcat_subcategory_code = '{inSubCatCode}' ";

				snpJcat.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpJcat.BOF && snpJcat.EOF))
				{
					Prefix = ($"{Convert.ToString(snpJcat["jcat_subcategory_subjectprefix"])}").Trim();
					Separator = ($"{Convert.ToString(snpJcat["jcat_subcategory_subjectseparator"])}").Trim();
				}
				else
				{
					Prefix = "";
					Separator = "";
				}

				snpJcat.Close();
				snpJcat = null;

				if (Prefix == "")
				{ // journal subcategory was not found

					Query = "SELECT jcat_subcategory_subjectprefix, jcat_subcategory_subjectseparator ";
					Query = $"{Query}FROM Journal_Category WITH (NOLOCK) WHERE jcat_subcategory_code = '{inSubCatCode.Substring(0, Math.Min(2, inSubCatCode.Length))}' ";

					snpJcat.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!(snpJcat.BOF && snpJcat.EOF))
					{
						Prefix = ($"{Convert.ToString(snpJcat["jcat_subcategory_subjectprefix"])}").Trim();
						Separator = ($"{Convert.ToString(snpJcat["jcat_subcategory_subjectseparator"])}").Trim();
					}
					else
					{
						Prefix = "";
						Separator = "";
					}

					snpJcat.Close();
					snpJcat = null;
				}

				//===================================
				// Get the Seller and Buyer Names
				//===================================
				if (($"{inSellerName}").Trim() != "")
				{
					SellerName = inSellerName;
				}
				else
				{
					SellerName = GetCompanyName(inSellerCompID, inSellerJournID);
				}

				if (($"{inBuyerName}").Trim() != "")
				{
					BuyerName = inBuyerName;
				}
				else
				{
					BuyerName = GetCompanyName(inBuyerCompID, inBuyerJournID);
				}

				//===================================
				// Put it all together to pass back
				//===================================

				return $"{Prefix} {SellerName} {Separator} {BuyerName}";
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"BuildJournalSubject_Error ({Information.Err().Number.ToString()}) {excep.Message}", "modCommon (Journal)");
			}
			return "";
		}

		internal static string GetAircraftName(int inACID, int inJournID)
		{

			string result = "";
			string Query = "";
			ADORecordSetHelper snpACName = new ADORecordSetHelper(); //8/11/05 aey

			try
			{

				result = "";

				Query = "SELECT amod_make_name, amod_model_name, ac_ser_no_full FROM Aircraft WITH(NOLOCK), Aircraft_Model WITH(NOLOCK)";
				Query = $"{Query} WHERE ac_amod_id = amod_id";
				Query = $"{Query} AND ac_id = {inACID.ToString()} AND ac_journ_id = {inJournID.ToString()}";

				snpACName.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpACName.BOF && snpACName.EOF))
				{
					result = $"{($"{Convert.ToString(snpACName["amod_make_name"])}").Trim()} {($"{Convert.ToString(snpACName["amod_model_name"])}").Trim()} {($"{Convert.ToString(snpACName["ac_ser_no_full"])}").Trim()}";
				}
				else
				{
					result = "";
				}

				snpACName.Close();
				snpACName = null;

				return result;
			}
			catch (System.Exception excep)
			{

				result = "";
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"GetAircraftName ({Information.Err().Number.ToString()}) {excep.Message} : ACID[{inACID.ToString()}] JID[{inJournID.ToString()}]", "modCommon (Aircraft)");
				return result;
			}
		}

		internal static string GetYachtName(int YachtID, int inJournID)
		{

			string result = "";
			string Query = "";
			ADORecordSetHelper snpACName = new ADORecordSetHelper(); //8/11/05 aey

			try
			{

				result = "";

				Query = "SELECT * FROM Yacht WITH(NOLOCK), Yacht_Model WITH(NOLOCK)  WHERE yt_model_id = ym_model_id";
				Query = $"{Query} AND yt_id = {YachtID.ToString()} AND yt_journ_id = {inJournID.ToString()}";

				snpACName.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpACName.BOF && snpACName.EOF))
				{
					result = $"{($"{Convert.ToString(snpACName["ym_brand_name"])}").Trim()} {($"{Convert.ToString(snpACName["ym_model_name"])}").Trim()} {($"{Convert.ToString(snpACName["yt_yacht_name"])}").Trim()}";
				}
				else
				{
					result = "";
				}

				snpACName.Close();
				snpACName = null;

				return result;
			}
			catch (System.Exception excep)
			{

				result = "";
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"GetYachtName ({Information.Err().Number.ToString()}) {excep.Message} : YACHT[{YachtID.ToString()}] JID[{inJournID.ToString()}]", "modCommon (Aircraft)");
				return result;
			}
		}

		internal static void ClearAircraftActionDate(int PassedACID, int PassedJournID)
		{

			string Query = "";
			bool bStartTrans = false;
			string strErrDesc = "";
			int lErrNbr = 0;

			try
			{

				// if we are not in a transaction then start one
				if (modAdminCommon.ADO_Transaction("CheckStatus") == 0)
				{
					modAdminCommon.ADO_Transaction("BeginTrans");
					bStartTrans = true;
				}

				Query = "UPDATE Aircraft SET ac_action_date = '1/1/1900' ";
				Query = $"{Query}WHERE (ac_id = {PassedACID.ToString()}) ";
				Query = $"{Query}AND (ac_journ_id = {PassedJournID.ToString()})";

				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();

				if (PassedJournID > 0)
				{ //9/13/05 aey -- resend journal also

					Query = "UPDATE journal SET journ_action_date = '1/1/1900'";
					Query = $"{Query} WHERE (journ_id = {PassedJournID.ToString()}) ";

					DbCommand TempCommand_2 = null;
					TempCommand_2 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
					TempCommand_2.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand_2.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
					TempCommand_2.ExecuteNonQuery();

				}

				// if we were in a transaction then commit it if we started it
				if (modAdminCommon.ADO_Transaction("CheckStatus") == 1 && bStartTrans)
				{
					modAdminCommon.ADO_Transaction("CommitTrans");
				}
			}
			catch (System.Exception excep)
			{

				strErrDesc = excep.Message;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr = Information.Err().Number;

				modAdminCommon.Report_Error($"ClearAircraftActionDate ({lErrNbr.ToString()}) {strErrDesc} : ACId[{PassedACID.ToString()}] JournId[{PassedJournID.ToString()}]", "modCommon (Transaction)");
				if (modAdminCommon.ADO_Transaction("CheckStatus") == 1 && bStartTrans)
				{
					modAdminCommon.ADO_Transaction("RollbackTrans");
				}
			}

		} // ClearAircraftActionDate

		internal static void ClearCompanyActionDate(int lCompId, int lJournId)
		{

			string strQuery1 = "";
			bool bStartTrans = false;

			string strErrDesc = "";
			int lErrNbr = 0;

			try
			{

				bStartTrans = false;
				// if we are not in a transaction then start one
				if (modAdminCommon.ADO_Transaction("CheckStatus") == 0)
				{
					modAdminCommon.ADO_Transaction("BeginTrans");
					bStartTrans = true;
				}

				strQuery1 = "UPDATE Company SET comp_action_date = '1/1/1900' ";
				strQuery1 = $"{strQuery1}WHERE (comp_id = {lCompId.ToString()}) ";
				strQuery1 = $"{strQuery1}AND (comp_journ_id = {lJournId.ToString()}) ";

				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = strQuery1;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();

				if (lJournId > 0)
				{

					strQuery1 = "UPDATE journal SET journ_action_date = '1/1/1900' ";
					strQuery1 = $"{strQuery1}WHERE (journ_id = {lJournId.ToString()})";

					DbCommand TempCommand_2 = null;
					TempCommand_2 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
					TempCommand_2.CommandText = strQuery1;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand_2.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
					TempCommand_2.ExecuteNonQuery();

				}

				// if we were in a transaction then commit it if we started it
				if (modAdminCommon.ADO_Transaction("CheckStatus") == 1 && bStartTrans)
				{
					modAdminCommon.ADO_Transaction("CommitTrans");
				}
			}
			catch (System.Exception excep)
			{

				strErrDesc = excep.Message;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr = Information.Err().Number;

				if (modAdminCommon.ADO_Transaction("CheckStatus") == 1 && bStartTrans)
				{
					modAdminCommon.ADO_Transaction("RollbackTrans");
				}

				modAdminCommon.Report_Error($"ClearCompanyActionDate ({lErrNbr.ToString()}) {strErrDesc} : CompId[{lCompId.ToString()}] JournId[{lJournId.ToString()}]", "modCommon (Transaction)");
			}

		} // ClearCompanyActionDate

		internal static void ClearContactActionDate(int lContactId, int lJournId)
		{

			string strUpdate1 = "";

			try
			{

				if (lContactId > 0)
				{

					strUpdate1 = "UPDATE Contact SET contact_action_date = '1/1/1900' ";
					strUpdate1 = $"{strUpdate1}WHERE(contact_id = {lContactId.ToString()}) ";
					strUpdate1 = $"{strUpdate1}AND (contact_journ_id = {lJournId.ToString()}) ";

					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = strUpdate1;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();

				} // If lContactId > 0 Then
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"ClearContactActionDate_Error: ({lContactId.ToString()}) - ({Information.Err().Number.ToString()}) {excep.Message}", "frm_ContactRelationships");
			}

		} // ClearContactActionDate

		internal static void CheckForAircraftTransmit(int inCrefID)
		{

			string Query = "";
			ADORecordSetHelper snpCref = null;
			bool bStartTrans = false;
			string[] tmpFields = new string[]{"", ""};
			tmpFields[0] = "";

			try
			{

				Query = "SELECT * FROM Aircraft WITH(NOLOCK), Aircraft_Reference WITH(NOLOCK)";
				Query = $"{Query} WHERE ac_id = cref_ac_id  AND ac_journ_id = cref_journ_id";
				Query = $"{Query} AND cref_id = {inCrefID.ToString()} AND cref_transmit_seq_no = 1";

				snpCref = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(snpCref.Fields) && !(snpCref.BOF && snpCref.EOF))
				{

					// if we are not in a transaction and start one
					if (modAdminCommon.ADO_Transaction("CheckStatus") == 0)
					{
						modAdminCommon.ADO_Transaction("BeginTrans");
						bStartTrans = true;
					}

					modAdminCommon.Record_Transmit(Convert.ToString(snpCref["ac_ser_no_full"]).Trim(), Convert.ToInt32(Double.Parse(Convert.ToString(snpCref["AC_ID"]).Trim())), Convert.ToInt32(Double.Parse(Convert.ToString(snpCref["AC_Journ_id"]).Trim())), Convert.ToInt32(Double.Parse(Convert.ToString(snpCref["ac_amod_id"]).Trim())), "Aircraft", "Change", ref tmpFields);

					if (Convert.ToString(snpCref["ac_forsale_flag"]).Trim().ToUpper() == "Y")
					{
						modAdminCommon.Record_Transmit(Convert.ToString(snpCref["ac_ser_no_full"]).Trim(), Convert.ToInt32(Double.Parse(Convert.ToString(snpCref["AC_ID"]).Trim())), Convert.ToInt32(Double.Parse(Convert.ToString(snpCref["AC_Journ_id"]).Trim())), Convert.ToInt32(Double.Parse(Convert.ToString(snpCref["ac_amod_id"]).Trim())), "Available", "Change", ref tmpFields);
					}

					// if we were in a transaction then commit it if we started it
					if (modAdminCommon.ADO_Transaction("CheckStatus") == 1 && bStartTrans)
					{
						modAdminCommon.ADO_Transaction("CommitTrans");
					}

					snpCref.Close();

				}

				snpCref = null;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"CheckForAircraftTransmit_Error ({Information.Err().Number.ToString()}) {excep.Message} : CRefId[{inCrefID.ToString()}]", "modCommon (Transaction)");
				if (modAdminCommon.ADO_Transaction("CheckStatus") == 1 && bStartTrans)
				{
					modAdminCommon.ADO_Transaction("RollbackTrans");
				}
				return;
			}

		}

		internal static string GetBusinessTypeToUse(int incompid, int inJournID, bool inShowList = false)
		{

			string result = "";
			string Query = "";
			ADORecordSetHelper snpBusType = new ADORecordSetHelper(); //8/11/05 aey

			try
			{

				result = "";

				Query = "SELECT * FROM Business_Type_Reference WITH(NOLOCK), Company_Business_Type WITH(NOLOCK)";
				Query = $"{Query} WHERE cbus_type = bustypref_type";
				Query = $"{Query} AND bustypref_comp_id = {incompid.ToString()}";
				Query = $"{Query} AND bustypref_journ_id = {inJournID.ToString()}";
				Query = $"{Query} AND cbus_abi_flag = 'N'";

				snpBusType.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpBusType.BOF && snpBusType.EOF))
				{

					if (snpBusType.RecordCount > 1 || inShowList)
					{
						frm_CompanyBusinessTypes.DefInstance.inCompID = incompid;
						frm_CompanyBusinessTypes.DefInstance.inJournID = inJournID;
						frm_CompanyBusinessTypes.DefInstance.inSelectionMode = "BusType";
						frm_CompanyBusinessTypes.DefInstance.SelectOnly = true;
						frm_CompanyBusinessTypes.DefInstance.ShowCancel = true;
						//.inMessage = "Please Select a Business Type to use"

						frm_CompanyBusinessTypes.DefInstance.ShowDialog();

						result = frm_CompanyBusinessTypes.DefInstance.WhichOne;
						frm_CompanyBusinessTypes.DefInstance.WhichOne = "";


					}
					else
					{
						result = $"{($"{Convert.ToString(snpBusType["cbus_type"])}").Trim()} - {($"{Convert.ToString(snpBusType["cbus_name"])}").Trim()}";
					}

				} // If Not (snpBusType.BOF And snpBusType.EOF) Then

				snpBusType.Close();
				snpBusType = null;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"GetBusinessTypeToUse_Error: CMPID[{incompid.ToString()}] JID[{inJournID.ToString()}] ({Information.Err().Number.ToString()}) {excep.Message}", "modCommon");
				result = "";
			}

			return result;
		}

		internal static string GetBusinessTypeName(string inType)
		{

			string result = "";
			string Query = "";
			ADORecordSetHelper snpBusType = new ADORecordSetHelper(); //8/11/05 aey

			try
			{

				result = "";
				if (inType != "")
				{

					Query = $"SELECT cbus_name FROM Company_Business_Type WITH(NOLOCK) WHERE cbus_type = '{inType.Trim()}'";

					snpBusType.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!(snpBusType.BOF && snpBusType.EOF))
					{
						result = ($"{Convert.ToString(snpBusType["cbus_name"])}").Trim();
					}

					snpBusType.Close();
					snpBusType = null;

				}
			}
			catch
			{

				modAdminCommon.Report_Error($"GetBusinessTypeName: Type[{inType}] ");
				result = "";
			}

			return result;
		}

		internal static int GetNextBusTypeSeqNo(int incompid, int inJournID)
		{

			int result = 0;
			string Query = "";
			ADORecordSetHelper snpSeqNo = new ADORecordSetHelper(); //8/11/05 aey dao.Recordset

			try
			{

				Query = "SELECT max(bustypref_seq_no) as maxSeqNo FROM Business_Type_Reference WITH(NOLOCK) ";
				Query = $"{Query}WHERE bustypref_comp_id = {incompid.ToString()}  AND bustypref_journ_id = {inJournID.ToString()}";

				snpSeqNo.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpSeqNo.BOF && snpSeqNo.EOF))
				{
					result = Convert.ToInt32(Conversion.Val(($"{Convert.ToString(snpSeqNo["maxSeqNo"])}").Trim()) + 1);
				}
				else
				{
					result = 1;
				}

				snpSeqNo.Close();
				snpSeqNo = null;

				return result;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"GetNextBusTypeSeqNo_Error ({Information.Err().Number.ToString()}) {excep.Message} : CMPID[{incompid.ToString()}] JID[{inJournID.ToString()}]", "modCommon (Company)");
				return 0;
			}
		}

		internal static string GetPrimaryBusinessType(int inCompanyId, int inJournalId)
		{

			string result = "";
			string Query = "";
			ADORecordSetHelper snpPrimary = new ADORecordSetHelper(); //8/11/05 aey

			try
			{

				result = "";

				Query = "SELECT cbus_name FROM Company_Business_Type WITH(NOLOCK), Business_Type_Reference WITH(NOLOCK)";
				Query = $"{Query} WHERE bustypref_type = cbus_type ";
				Query = $"{Query} AND bustypref_comp_id = {inCompanyId.ToString()}";
				Query = $"{Query} AND bustypref_journ_id = {inJournalId.ToString()}";
				Query = $"{Query} AND bustypref_seq_no = 1";

				snpPrimary.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpPrimary.BOF && snpPrimary.EOF))
				{
					result = Convert.ToString(snpPrimary["cbus_name"]);
				}

				snpPrimary.Close();
				snpPrimary = null;

				return result;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"GetPrimaryBusinessType_Error ({Information.Err().Number.ToString()}) {excep.Message} : CMPID[{inCompanyId.ToString()}] JID[{inJournalId.ToString()}]", "modCommon (Company)");
				return "";
			}
		}

		internal static bool GetImportantRelationships(int inCrefID)
		{

			bool result = false;
			string Query = "";
			ADORecordSetHelper snpRel = new ADORecordSetHelper(); //8/11/05 aey
			string tmpText = "";

			try
			{

				result = false;

				Query = "SELECT sref_contact_type FROM Share_Reference WITH(NOLOCK)";
				Query = $"{Query} WHERE sref_cref_id = {inCrefID.ToString()}";
				Query = $"{Query} AND sref_contact_type in (SELECT actype_code FROM Aircraft_Contact_Type WITH(NOLOCK) WHERE actype_shareref_flag = 'Y' AND actype_active_flag = 'Y')";

				snpRel.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpRel.BOF && snpRel.EOF))
				{
					result = true;
				}

				snpRel.Close();
				snpRel = null;

				return result;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"GetImportantRelationships_Error ({Information.Err().Number.ToString()}) {excep.Message} : CREFID[{inCrefID.ToString()}]", "modCommon (Company)");
				return result;
			}
		}

		internal static void CheckEmailAddress(TextBox inTextbox)
		{

			string Query = "";
			ADORecordSetHelper snpEmail = new ADORecordSetHelper(); //8/11/05 aey

			try
			{

				if (inTextbox.Text.Trim() != "")
				{

					Query = $"SELECT * FROM EMail_Scan WITH(NOLOCK) WHERE emailscan_email_address = '{inTextbox.Text}'";

					snpEmail.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!(snpEmail.BOF && snpEmail.EOF))
					{
						if (($"{Convert.ToString(snpEmail["emailscan_status"])}").Trim() == "Failed")
						{
							inTextbox.Font = inTextbox.Font.Change(bold:true);
                            // gap-note: jgamboa. Use SetToolTipText extension method to set the tooltip of the control in the ToolTipMain.
                            inTextbox.SetToolTipText(StringsHelper.Replace(($"{Convert.ToString(snpEmail["emailscan_message"])}").Trim(), Environment.NewLine, " ", 1, -1, CompareMethod.Binary));
						}
						else
						{
							inTextbox.Font = inTextbox.Font.Change(bold:false);
                            // gap-note: jgamboa. Use SetToolTipText extension method to set the tooltip of the control in the ToolTipMain.
                            inTextbox.SetToolTipText("");
						}
					}

					snpEmail.Close();
					snpEmail = null;
				}
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"CheckEmailAddress ({Information.Err().Number.ToString()}) {excep.Message} : INTXT[{inTextbox.Text.Trim()}]", "modCommon (Company)");
				return;
			}

		}

		private static string GetPriorityEventSubject(string inCatCode)
		{

			string result = "";
			string Query = "";
			ADORecordSetHelper snpSubject = new ADORecordSetHelper(); //8/11/05 aey

			try
			{

				Query = $"SELECT priorevcat_category_name FROM Priority_Events_Category WITH(NOLOCK) WHERE priorevcat_category_code = '{inCatCode}'";

				snpSubject.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpSubject.BOF && snpSubject.EOF))
				{
					result = ($"{Convert.ToString(snpSubject["priorevcat_category_name"])}").Trim();
				}
				else
				{
					result = "";
				}

				snpSubject.Close();
				snpSubject = null;
			}
			catch
			{

				modAdminCommon.Report_Error($"GetPriorityEventSubject: CatCode[{inCatCode}]  ");
			}

			return result;
		}

		internal static bool IsLoaded(string Frm)
		{
			//check to see if the form is loaded
			//aey 2/4/2005

			bool result = false;
			Form Fm = null;


			foreach (Form FmIterator in Application.OpenForms)
			{
				Fm = FmIterator;
				if (Fm.Name.ToUpper() == Frm.ToUpper())
				{
					result = true;
					break;
				}
				Fm = default(Form);
			}

			return result;
		}

		internal static bool QuickCheckEmailAddress(string inAddress)
		{

			bool result = false;

			if (inAddress.Trim() != "")
			{
				if (inAddress.Trim().IndexOf('@') >= 0)
				{
					if (inAddress.Trim().IndexOf('.') >= 0)
					{
						if (inAddress.Trim().Substring(0, Math.Min(5, inAddress.Trim().Length)).ToLower() != "http:")
						{
							result = true;
						}
					}
				}
			}
			else
			{
				result = true;
			}
			// 2nd check for @@ and " "
			if (inAddress.Trim().IndexOf("@@") >= 0)
			{
				result = false;
			}
			else if (inAddress.Trim().IndexOf(' ') >= 0)
			{ 
				result = false;
			}
			else if (Strings.InStr(Strings.Len(inAddress), inAddress.Trim(), ".", CompareMethod.Binary) > 0)
			{ 
				result = false;
			}

			if (!result)
			{
				MessageBox.Show($"Invalid Email Address{Environment.NewLine}Your Changes Have NOT Been Saved", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

			return result;
		}

		internal static string GetContactName(int PassedContactID, int PassedJournID)
		{
			//
			// THE PURPOSE OF THIS FUNCTION
			// 6/17/03 - RTW - CHANGED TO ADO RECORDSET - ALSO NOW HAVE THE FUNCTION RETURN 0 IF NO CONTACT
			// **************************************************************************
			string result = "";
			string Query = "";
			ADORecordSetHelper adoContactRs = null;
			string Tname = "";

			try
			{

				result = "0";

				if (PassedContactID == 0)
				{
					return result;
				}

				Query = "SELECT contact_id, contact_sirname, contact_first_name, contact_middle_initial, contact_last_name, contact_suffix, contact_title";
				Query = $"{Query} FROM Contact WITH(NOLOCK) WHERE contact_id = {PassedContactID.ToString()}";
				Query = $"{Query} AND contact_journ_id = {PassedJournID.ToString()}";

				adoContactRs = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(adoContactRs.Fields) && !(adoContactRs.BOF && adoContactRs.EOF))
				{
					Tname = modGlobalVars.cEmptyString;

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(adoContactRs["contact_sirname"]))
					{
						if (Convert.ToString(adoContactRs["contact_sirname"]).Trim() != modGlobalVars.cEmptyString)
						{
							Tname = $"{Convert.ToString(adoContactRs["contact_sirname"]).Trim()}{modGlobalVars.cSingleSpace}";
						}
					}

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(adoContactRs["contact_first_name"]))
					{
						if (Convert.ToString(adoContactRs["contact_first_name"]).Trim() != modGlobalVars.cEmptyString)
						{
							Tname = $"{Tname}{Convert.ToString(adoContactRs["contact_first_name"]).Trim()}{modGlobalVars.cSingleSpace}";
						}
					}

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(adoContactRs["contact_middle_initial"]))
					{
						if (Convert.ToString(adoContactRs["contact_middle_initial"]).Trim() != modGlobalVars.cEmptyString)
						{
							Tname = $"{Tname}{Convert.ToString(adoContactRs["contact_middle_initial"]).Trim()}.{modGlobalVars.cSingleSpace}";
						}
					}

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(adoContactRs["contact_last_name"]))
					{
						if (Convert.ToString(adoContactRs["contact_last_name"]).Trim() != modGlobalVars.cEmptyString)
						{
							Tname = $"{Tname}{Convert.ToString(adoContactRs["contact_last_name"]).Trim()}{modGlobalVars.cSingleSpace}";
						}
					}

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(adoContactRs["contact_suffix"]))
					{
						if (Convert.ToString(adoContactRs["contact_suffix"]).Trim() != modGlobalVars.cEmptyString)
						{
							Tname = $"{Tname}{Convert.ToString(adoContactRs["contact_suffix"]).Trim()}{modGlobalVars.cSingleSpace}";
						}
					}

					if (Tname.Trim() == "")
					{
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(adoContactRs["contact_title"]))
						{
							if (Convert.ToString(adoContactRs["contact_title"]).Trim() != modGlobalVars.cEmptyString)
							{
								Tname = $"{Tname}{Convert.ToString(adoContactRs["contact_title"]).Trim()}";
							}
						}
					}

					result = Tname.Trim();

				}

				adoContactRs.Close();
			}
			catch
			{

				modAdminCommon.Report_Error($"GetContactName: ContactId[{PassedContactID.ToString()}]  JournId[{PassedJournID.ToString()}] ");
			}

			return result;
		}

		internal static string GetContactShortName(int lContactId, int lJournId)
		{

			string result = "";
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strResults = "";

			try
			{

				strResults = "";

				if (lContactId > 0)
				{

					strQuery1 = $"SELECT * FROM Contact WITH (NOLOCK) WHERE (contact_id = {lContactId.ToString()}) ";
					strQuery1 = $"{strQuery1}AND (contact_journ_id = {lJournId.ToString()}) ";

					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!rstRec1.BOF && !rstRec1.EOF)
					{
						strResults = $"{($"{Convert.ToString(rstRec1["contact_first_name"])} ").Trim()} {($"{Convert.ToString(rstRec1["contact_last_name"])} ").Trim()}";
					}

					rstRec1.Close();

				} // If lContactId > 0 Then

				result = strResults;

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"GetContactShortName_Error: ContactId [{lContactId.ToString()}]  JournId [{lJournId.ToString()}] ", excep.Message);

				result = "";
			}

			return result;
		} // GetContactShortName

		internal static void HighlightIfTooLong(Control PassedObject, ref Color PassedColor) //gap-notes PassedObject was changed to Control
		{


			if (PassedColor == Color.FromArgb(255, 255, 185))
			{
				PassedColor = Color.White;
			}

			int tmpLength = 0;

			//UPGRADE_TODO: (1067) Member Name is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067


			switch(Convert.ToString(PassedObject.Name).ToLower())
			{
				case "txt_ac_confidential_notes" : 
					 
					tmpLength = 136; 
					 
					break;
				case "txt_ac_damage_history_notes" : 
					 
					tmpLength = 204; 
					 
					break;
				case "txt_ac_equip_add_description" : 
					 
					tmpLength = 306; 
					 
					break;
				case "txt_ac_inspection_notes" : 
					 
					tmpLength = 216; 
					 
					break;
				case "txt_ac_interior_description" : case "txt_ac_exterior_description" : 
					 
					tmpLength = 226; 
					 
					break;
				case "txt_addl_cockpit_equip_description" : 
					 
					tmpLength = 214; 
					 
					break;
				case "txt_ac_maint_eoh_by_name" : case "txt_ac_maint_hots_by_name" : case "txt_ac_maint_prog_name" : 
					 
					tmpLength = 16; 
					 
					break;
				case "txt_comp_name" : case "txt_comp_address1" : 
					 
					tmpLength = 36; 
					 
					break;
				case "txt_comp_address2" : case "txt_comp_name_alt" : case "cbo_comp_name_alt_type" : 
					 
					tmpLength = 0; 
					 
					break;
				case "cbo_comp_country" : case "txt_ac_lavatory" : case "txt_comp_city" : 
					 
					tmpLength = 20; 
					 
					break;
				case "cbo_contact_sirname" : 
					 
					tmpLength = 4; 
					 
					break;
				case "txt_contact_first_name" : 
					 
					tmpLength = 12; 
					 
					break;
				case "txt_contact_last_name" : 
					 
					tmpLength = 14; 
					 
					break;
				case "cbo_contact_title" : 
					 
					tmpLength = 24; 
					 
					break;
				case "txt_comp_email_address" : case "txt_comp_web_address" : 
					tmpLength = 60; 
					 
					break;
				case "txt_adoc_general_note" : 
					tmpLength = 462; 
					 
					break;
			}


		}

		internal static bool AttachFile(string PassedFile, string PassedType, int PassedModelID, int PassedJournID, int PassedJournSeqNo, int PassedACID, bool LeaveInProcessing = false)
		{

			bool result = false;
			string DestinationPath = "";
			string DestinationFileName = "";
			string FullDestinationPathAndFile = "";
			string errString = "";
			string Extension = ""; // STORES THE FILE EXTENSION

			try
			{
				result = false;

				errString = "Decide which path we want";


				switch(PassedType)
				{
					case "FAAPDF" : case "NTSB" : case "337" : 
						 
						Extension = PassedFile.Substring(Math.Max(PassedFile.Length - 4, 0)); 
						 
						if ((Extension.IndexOf('.') + 1) == 0)
						{
							Extension = $".{Extension}";
						} 
						 
						FullDestinationPathAndFile = Get_Document_File_Name(PassedACID, PassedJournID, PassedJournSeqNo, PassedType, Extension); 
						 
						break;
					case "Model" : 
						// ************************************************************* 
						// STORE THE DOCUMENT AS A MODEL PICTURE 
						DestinationFileName = PassedModelID.ToString(); 
						DestinationFileName = $"{DestinationFileName}{PassedFile.Substring(Math.Max(PassedFile.Length - 4, 0))}"; 
						 
						if ((DestinationFileName.IndexOf('.') + 1) == 0)
						{
							DestinationFileName = $"{DestinationFileName.Substring(0, Math.Min(Strings.Len(DestinationFileName) - 4, DestinationFileName.Length))}.{DestinationFileName.Substring(Math.Max(DestinationFileName.Length - 4, 0))}";
						} 
						 
						DestinationPath = modAdminCommon.gbl_ModelPictures; 
						FullDestinationPathAndFile = $"{DestinationPath}\\{DestinationFileName}"; 
						 
						break;
					case "AircraftPicture" : 
						// ************************************************************* 
						// STORE THE DOCUMENT AS A AIRCRAFT PICTURE 
						DestinationFileName = $"{PassedACID.ToString()}-{PassedJournID.ToString()}-{PassedJournSeqNo.ToString()}"; 
						DestinationFileName = $"{DestinationFileName}{PassedFile.Substring(Math.Max(PassedFile.Length - 4, 0))}"; 
						 
						if ((DestinationFileName.IndexOf('.') + 1) == 0)
						{
							DestinationFileName = $"{DestinationFileName.Substring(0, Math.Min(Strings.Len(DestinationFileName) - 4, DestinationFileName.Length))}.{DestinationFileName.Substring(Math.Max(DestinationFileName.Length - 4, 0))}";
						} 
						 
						DestinationPath = modAdminCommon.gbl_AircraftPictures; 
						FullDestinationPathAndFile = $"{DestinationPath}\\{DestinationFileName}"; 
						 
						break;
					default:
						MessageBox.Show("Invalid", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly())); 
						return result; 

				}

				// ***************************************
				// MAKE SURE THAT A FILE NAME HAS BEEN SPECIFIED
				// IF NOT THN IDENTIFY THE ERROR AND EXIT
				if (Strings.Len(FullDestinationPathAndFile) == 0)
				{
					errString = "No file name specified";
					throw new Exception();
				}

				// **********************************************
				// MAKE SURE THAT THE FILE SPECIFIED DOESN'T ALREADY EXIST
				errString = "Check if file exists";
				if (File.Exists(FullDestinationPathAndFile))
				{
					if (MessageBox.Show($"File Already Exists{Environment.NewLine}Do you want to overwrite?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
					{
						return result;
					}
					else
					{
						File.Delete(FullDestinationPathAndFile);
					}
				}

				// ********************************************
				// COPY THE FILE TO THE APPROPRIATE LIBRAY
				errString = $"Do The Copy {PassedFile} {FullDestinationPathAndFile}";
				File.Copy(PassedFile, FullDestinationPathAndFile);

				// ************************************************
				// DELETE THE ORIGINAL FILE
				errString = "If necessary, Delete File";
				if (!LeaveInProcessing)
				{
					File.Delete(PassedFile);
				}

				result = true;

				Application.DoEvents();
			}
			catch (System.Exception excep)
			{

				result = false;

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Record_Error("modCommon (Attach)", $"AttachFile_Error ({Information.Err().Number.ToString()}) {excep.Message} : {errString}");
			}

			return result;
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
				if (RSName.ToLower() == "application_configuration")
				{ // if its app config look up

					// check the flag to see what we are connecting to, if true then live, else, test (non live)
					// either way set the string_for_app_flag to add into the query

					if (modAdminCommon.gbl_Live_flag)
					{
						string_for_app_flag = "LIVE";
					}
					else if (modAdminCommon.gbl_Backup_flag)
					{ 
						string_for_app_flag = "BACKUP";
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

				adoData.Open(strQuery, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

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
		}


		internal static string DLookUp_Top(string FldName, string RSName, int top_count, string RSCriteria = "")
		{

			string result = "";
			string strQuery = "";
			ADORecordSetHelper adoData = new ADORecordSetHelper();
			string string_for_app_flag = "";

			try
			{

				result = "";

				strQuery = $"SELECT TOP {top_count.ToString()} {FldName} FROM {RSName}";

				if (Strings.Len(($"{RSCriteria}").Trim()) > 0)
				{
					strQuery = $"{strQuery} WHERE {RSCriteria}";
				}

				// ADDED 6/14/2011 MSW - make sure that if it is an app config lookup that it checks to see which one it looks up
				if (RSName.ToLower() == "application_configuration")
				{ // if its app config look up

					// check the flag to see what we are connecting to, if true then live, else, test (non live)
					// either way set the string_for_app_flag to add into the query

					if (modAdminCommon.gbl_Live_flag)
					{
						string_for_app_flag = "LIVE";
					}
					else if (modAdminCommon.gbl_Backup_flag)
					{ 
						string_for_app_flag = "BACKUP";
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

				adoData.Open(strQuery, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!adoData.BOF) && (!adoData.EOF))
				{



					while(!adoData.EOF)
					{
						if (result.Trim() != "")
						{
							result = $"{result},";
						}

						result = $"{result}{Convert.ToString(adoData[0])}";

						adoData.MoveNext();
					};


				}

				adoData.Close();
				adoData = null;
			}
			catch
			{

				result = "";
			}

			return result;
		}




		internal static string DLookUpCRM(DbConnection cntConn, string strFieldName, string strTableName, string strSearchCriteria = "")
		{

			string result = "";
			string strQuery1 = "";
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();

			try
			{

				result = "";

				strQuery1 = $"SELECT {strFieldName} FROM {strTableName}";

				if (Strings.Len(($"{strSearchCriteria}").Trim()) > 0)
				{
					strQuery1 = $"{strQuery1} WHERE {strSearchCriteria}";
				}

				if (cntConn != null)
				{

					if (cntConn.State == ConnectionState.Open)
					{

						rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

						if ((!rstRec1.BOF) && (!rstRec1.EOF))
						{
							result = Convert.ToString(rstRec1[0]);
						}

						rstRec1.Close();

					} // If cntConn.State = adStateOpen Then

				} // If (cntConn Is Nothing) = False Then

				rstRec1 = null;
			}
			catch
			{

				result = "";
			}

			return result;
		} // DLookUpCRM

		internal static void ReturnCRMMasterClientInfo(DbConnection cntConn, int lCRMRegId, ref int lCompId, ref string strClientName, ref string strSubscriptionCode, ref string strSecurityToken, ref string strWebHostName, ref string strDBHost, ref string strDatabase, ref string strUserId, ref string strPassword)
		{

			string strQuery1 = "";
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();

			try
			{

				lCompId = 0;
				strClientName = "";
				strSubscriptionCode = "";
				strSecurityToken = "";
				strWebHostName = "";
				strDBHost = "";
				strDatabase = "";
				strUserId = "";
				strPassword = "";

				if (lCRMRegId > 0)
				{

					strQuery1 = "SELECT client_regID, client_regJetnetCompanyID, client_regName, client_regSubscriptionCode, client_regSecurityToken, ";
					strQuery1 = $"{strQuery1}client_webHostName, client_dbHost, client_dbHost_External, client_dbDatabase, client_dbUID, client_dbPWD ";
					strQuery1 = $"{strQuery1}FROM client_register_master ";
					strQuery1 = $"{strQuery1}WHERE (client_regID = {lCRMRegId.ToString()}) ";

					if (cntConn != null)
					{

						if (cntConn.State == ConnectionState.Open)
						{

							rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

							if ((!rstRec1.BOF) && (!rstRec1.EOF))
							{

								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(rstRec1["client_regJetnetCompanyID"]))
								{
									if (Convert.ToDouble(rstRec1["client_regJetnetCompanyID"]) > 0)
									{
										lCompId = Convert.ToInt32(rstRec1["client_regJetnetCompanyID"]);
									}
								}
								//lCompId = 12727 ' Temp Hold
								strClientName = ($"{Convert.ToString(rstRec1["client_regName"])} ").Trim();
								strSubscriptionCode = ($"{Convert.ToString(rstRec1["client_regSubscriptionCode"])} ").Trim();
								strSecurityToken = ($"{Convert.ToString(rstRec1["client_regSecurityToken"])} ").Trim();

								strWebHostName = ($"{Convert.ToString(rstRec1["client_webHostName"])} ").Trim();
								strDBHost = ($"{Convert.ToString(rstRec1["client_dbHost_External"])} ").Trim();
								strDatabase = ($"{Convert.ToString(rstRec1["client_dbDatabase"])} ").Trim();
								strUserId = ($"{Convert.ToString(rstRec1["client_dbUID"])} ").Trim();
								strPassword = ($"{Convert.ToString(rstRec1["client_dbPWD"])} ").Trim();

							} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

							rstRec1.Close();

						} // If cntConn.State = adStateOpen Then

					} // If (cntConn Is Nothing) = False Then

				} // If lCRMRegId > 0 Then

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("ReturnCRMMasterClientInfo_Error", excep.Message);
			}

		} // ReturnCRMMasterClientInfo

		internal static string DMax(string FldName, string RSName, string RSCriteria = "")
		{
			//Generalized table/query lookup function
			//Usage: Dlookup('field','table',optional 'criteria',optional iscurrent)
			//related domain functions: dmax, dmin, davg,dmedian, dfirst, dlast, dstdev,.....

			string result = "";
			ADORecordSetHelper adoData = new ADORecordSetHelper();


			string strQuery = $"SELECT MAX({FldName}) FROM {RSName} WITH(NOLOCK)";

			if (Strings.Len(($"{RSCriteria}").Trim()) > 0)
			{
				strQuery = $"{strQuery} WHERE {RSCriteria}";
			}

			adoData.Open(strQuery, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

			if ((!adoData.BOF) && (!adoData.EOF))
			{
				result = $"{Convert.ToString(adoData[0])}";
			}

			adoData.Close();

			return result;
		}

		internal static int DCount(string FldName, string RSName, string RSCriteria = "")
		{
			//Generalized table/query lookup function
			//Usage: Dlookup('field','table',optional 'criteria',optional iscurrent)
			//related domain functions: dmax, dmin, davg,dmedian, dfirst, dlast, dstdev,dcount .....

			// 06/27/2007 - By David D. Cruger
			// Changed Return Value to Long
			// Also Removed the adForwardOnly cursor because
			// there was a MoveFirst command

			ADORecordSetHelper adoData = new ADORecordSetHelper();

			int lResults = 0;

			string strQuery = $"SELECT COUNT({FldName}) AS TotCnt FROM {RSName} WITH(NOLOCK)";

			if (Strings.Len(($"{RSCriteria}").Trim()) > 0)
			{
				strQuery = $"{strQuery} WHERE {RSCriteria}";
			}

			adoData.Open(strQuery, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

			if ((!adoData.BOF) && (!adoData.EOF))
			{
				lResults = Convert.ToInt32(adoData["TotCnt"]);
			}

			adoData.Close();
			adoData = null;

			return lResults;

		}

		internal static string GetCompanyServiceName(int PassedCompID, int PassedJournID, Array ServicesUsed_Array)
		{

			string result = "";
			string tmpCompanyService = "";
			string Query = "";
			ADORecordSetHelper snpCompService = new ADORecordSetHelper(); //8/11/05 aey

			try
			{

				result = "";

				Query = $"SELECT comp_service FROM Company WITH(NOLOCK) WHERE comp_id = {PassedCompID.ToString()} AND comp_journ_id = {PassedJournID.ToString()}";

				snpCompService.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpCompService.BOF && snpCompService.EOF))
				{
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snpCompService["Comp_service"]))
					{
						tmpCompanyService = Convert.ToString(snpCompService["Comp_service"]).Trim();
					}
					else
					{
						tmpCompanyService = "";
					}
				}
				else
				{
					tmpCompanyService = "";
				}

				int tempForEndVar = ServicesUsed_Array.GetUpperBound(0);
				for (int nLoop = 1; nLoop <= tempForEndVar; nLoop++)
				{
					if (tmpCompanyService == ((string) ServicesUsed_Array.GetValue(nLoop, modGlobalVars.SERVICE_CODE)))
					{
						result = (string) ServicesUsed_Array.GetValue(nLoop, modGlobalVars.SERVICE_DESCRIPTION);
						break;
					}
				}

				snpCompService.Close();
				snpCompService = null;
			}
			catch
			{

				modAdminCommon.Report_Error($"GetCompanyServiceName: CompId[{PassedCompID.ToString()}]  JournId[{PassedJournID.ToString()}] ");
				result = "";
			}

			return result;
		}

		internal static string GetCompanyName(int PassedCompID, int PassedJournID, int replace_ticks = 0)
		{

			string result = "";
			string Query = "";
			ADORecordSetHelper snpCompName = null; //8/11/05 aey

			try
			{

				result = "";

				if (PassedCompID == 0)
				{
					return result;
				}

				Query = $"SELECT comp_name FROM Company WITH(NOLOCK) WHERE comp_id = {PassedCompID.ToString()} AND comp_journ_id = {PassedJournID.ToString()}";

				snpCompName = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(snpCompName.Fields) && !(snpCompName.BOF && snpCompName.EOF))
				{
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snpCompName["Comp_Name"]))
					{
						result = Convert.ToString(snpCompName["Comp_Name"]).Trim();

						if (replace_ticks > 0)
						{
							result = StringsHelper.Replace(result, "'", "''", 1, -1, CompareMethod.Binary);
						}
					}
					snpCompName.Close();
				}

				snpCompName = null;

				return result;
			}
			catch (System.Exception excep)
			{

				result = "";
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"GetCompanyName_Error ({Information.Err().Number.ToString()}) {excep.Message}", "modCommon (Company)");
				return result;
			}
		}

		internal static string GetCompanyCity(int PassedCompID, int PassedJournID)
		{

			string result = "";
			string Query = "";
			ADORecordSetHelper snpCompCity = new ADORecordSetHelper(); //8/11/05 aey

			try
			{

				result = "";

				if (PassedCompID == 0)
				{
					return result;
				}

				Query = $"SELECT comp_city FROM Company WITH(NOLOCK) WHERE comp_id = {PassedCompID.ToString()} AND comp_journ_id = {PassedJournID.ToString()}";

				snpCompCity.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpCompCity.BOF && snpCompCity.EOF))
				{
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snpCompCity["comp_city"]))
					{
						result = Convert.ToString(snpCompCity["comp_city"]).Trim();
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

				snpCompCity.Close();
				snpCompCity = null;

				return result;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"GetCompanyCity_Error ({Information.Err().Number.ToString()}) {excep.Message}", "modCommon (Company)");
				return "";
			}
		}


		internal static string GetCompanyNameBySeqNo(int lJournId, int lSeqNo)
		{

			string result = "";
			string strQuery = "";
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();

			try
			{

				result = "";

				strQuery = "SELECT comp_name FROM Journal WITH(NOLOCK) INNER JOIN Aircraft_Reference WITH(NOLOCK) ON ";
				strQuery = $"{strQuery}journ_id = cref_journ_id AND journ_ac_id = cref_ac_id ";
				strQuery = $"{strQuery}INNER JOIN Company WITH(NOLOCK) ON ";
				strQuery = $"{strQuery}cref_journ_id = comp_journ_id AND cref_comp_id = comp_id ";
				strQuery = $"{strQuery}WHERE (journ_id = {lJournId.ToString()}) ";
				strQuery = $"{strQuery}AND (cref_transmit_seq_no = {lSeqNo.ToString()}) ";

				rstRec1.Open(strQuery, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(rstRec1.BOF && rstRec1.EOF))
				{
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(rstRec1["Comp_Name"]))
					{
						result = Convert.ToString(rstRec1["Comp_Name"]).Trim();
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

				rstRec1.Close();
				rstRec1 = null;
			}
			catch
			{

				modAdminCommon.Report_Error($"GetCompanyNameBySeqNo: JournId[{lJournId.ToString()}]  SeqNo[{lSeqNo.ToString()}] ");
				result = "";
			}

			return result;
		}

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

		internal static void InsertPriorityEvent(string inCatCode, int inACID, int inJournID, string inDescription = "", int incompid = 0, int inContactId = 0, string inWrap = "N", int inAMWantID = 0, bool is_co_exclusive = false)
		{
			//aey 9/9/04
			//
			//  added inWrap parameter to be used for transaction processing
			// aey 6/21/05 added inAMWantID for wanted ac
			//===================================================================

			string Query = "";
			string Subject = "";

			try
			{

				Query = "INSERT INTO Priority_Events ( priorev_category_code, priorev_subject,";
				Query = $"{Query}priorev_description, priorev_ac_id, priorev_journ_id,";
				Query = $"{Query}priorev_comp_id, priorev_contact_id, priorev_user_id,";
				Query = $"{Query}priorev_amwant_id)  VALUES (";

				if (inCatCode.Trim() == "EXOFF1")
				{
					Query = $"{Query}'EXOFF',";
				}
				else
				{
					Query = $"{Query}'{inCatCode}',";
				}

				if (is_co_exclusive && inCatCode.Trim() == "EXOFF1")
				{
					Subject = "Removed Exclusive Previously With ";
				}
				else if (is_co_exclusive)
				{ 
					Subject = "Removed Co-Exclusive Previously With ";
				}
				else
				{
					Subject = GetPriorityEventSubject(inCatCode.Trim());
				}

				Query = $"{Query}'{Subject.Trim()}',";
				if (inDescription.Trim() != "")
				{
					Query = $"{Query}'{modAdminCommon.Fix_Quote(inDescription.Trim())}',";
				}
				else
				{
					Query = $"{Query} '' ,";
				}
				Query = $"{Query}{inACID.ToString()},";
				Query = $"{Query}{inJournID.ToString()},";
				if (($"{incompid.ToString()}").Trim() != "")
				{
					Query = $"{Query}{incompid.ToString()},";
				}
				else
				{
					Query = $"{Query}0,";
				}
				if (($"{inContactId.ToString()}").Trim() != "")
				{
					Query = $"{Query}{inContactId.ToString()},";
				}
				else
				{
					Query = $"{Query}0,";
				}
				Query = $"{Query}'{modAdminCommon.gbl_User_ID}',";

				// Last Field Needs The Closing Brackets
				if (($"{inAMWantID.ToString()}").Trim() != "")
				{
					Query = $"{Query}{inAMWantID.ToString()})";
				}
				else
				{
					Query = $"{Query}0)";
				}

				if (inWrap == "N")
				{
					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();
				}
				else
				{
					DbCommand TempCommand_2 = null;
					TempCommand_2 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
					TempCommand_2.CommandText = Query;
					TempCommand_2.CommandType = CommandType.Text;
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
					TempCommand_2.ExecuteNonQuery(); //aey 9/9/04
				}
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"InsertPriorityEvent_Error ({Information.Err().Number.ToString()}) {excep.Message}", "modCommon (Event)");
				return;
			}

		}

		// 09/18/2013 - By David D. Cruger

		internal static void InsertPriorityEventChangeInAsking(string strCatCode, int lACId, int lJournId, string strDesc, string strAskingFrom, string strAskingTo, string strInTransaction)
		{

			string strInsert1 = "";
			string strSubject = "";

			int lAskingFrom = 0;
			int lAskingTo = 0;

			string strAsking = "";

			try
			{

				lAskingFrom = 0;
				lAskingTo = 0;

				strAskingFrom = StringsHelper.Replace(strAskingFrom, "$", "", 1, -1, CompareMethod.Binary);
				strAskingFrom = StringsHelper.Replace(strAskingFrom, ",", "", 1, -1, CompareMethod.Binary);
				strAskingFrom = StringsHelper.Replace(strAskingFrom, " ", "", 1, -1, CompareMethod.Binary);
				if (Information.IsNumeric(strAskingFrom))
				{
					if (Conversion.Val(strAskingFrom) < 850000000)
					{
						lAskingFrom = Convert.ToInt32(Double.Parse(strAskingFrom));
					}
				}

				strAskingTo = StringsHelper.Replace(strAskingTo, "$", "", 1, -1, CompareMethod.Binary);
				strAskingTo = StringsHelper.Replace(strAskingTo, ",", "", 1, -1, CompareMethod.Binary);
				strAskingTo = StringsHelper.Replace(strAskingTo, " ", "", 1, -1, CompareMethod.Binary);
				if (Information.IsNumeric(strAskingTo))
				{
					if (Conversion.Val(strAskingTo) < 850000000)
					{
						lAskingTo = Convert.ToInt32(Double.Parse(strAskingTo));
					}
				}

				strInsert1 = "INSERT INTO Priority_Events ( priorev_category_code,";
				strInsert1 = $"{strInsert1}priorev_subject, priorev_description,";
				strInsert1 = $"{strInsert1}priorev_ac_id, priorev_journ_id,";
				strInsert1 = $"{strInsert1}priorev_user_id, priorev_from_asking_price,";
				strInsert1 = $"{strInsert1}priorev_to_asking_price)   VALUES (";
				strInsert1 = $"{strInsert1}'{strCatCode}',";

				strSubject = GetPriorityEventSubject(strCatCode.Trim());

				strInsert1 = $"{strInsert1}'{strSubject.Trim()}',";

				if (($"{strDesc} ").Trim() != "")
				{
					strInsert1 = $"{strInsert1}'{modAdminCommon.Fix_Quote(strDesc.Trim())}',";
				}
				else
				{
					strInsert1 = $"{strInsert1}NULL,";
				}

				strInsert1 = $"{strInsert1}{lACId.ToString()},";
				strInsert1 = $"{strInsert1}{lJournId.ToString()},";
				strInsert1 = $"{strInsert1}'{modAdminCommon.gbl_User_ID}',";
				strInsert1 = $"{strInsert1}{lAskingFrom.ToString()},";
				strInsert1 = $"{strInsert1}{lAskingTo.ToString()})";

				if (strInTransaction == "N")
				{
					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = strInsert1;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();
				}
				else
				{
					DbCommand TempCommand_2 = null;
					TempCommand_2 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
					TempCommand_2.CommandText = strInsert1;
					TempCommand_2.CommandType = CommandType.Text;
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
					TempCommand_2.ExecuteNonQuery();
				}
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"InsertPriorityEventChangeInAsking_Error ({Information.Err().Number.ToString()}) {excep.Message}", "modCommon (Event)");
			}

		} // InsertPriorityEventChangeInAsking

		internal static bool Is_A_Real_Number(string NUM)
		{


			bool result = false;
			bool digit_found = false;
			bool punc_found = false;

			if (Strings.Len(NUM.Trim()) > 0)
			{
				result = true;
				int tempForEndVar = Strings.Len(NUM);
				for (int i = 1; i <= tempForEndVar; i++)
				{
					if ((String.CompareOrdinal(NUM.Substring(Math.Min(i - 1, NUM.Length), Math.Min(1, Math.Max(0, NUM.Length - (i - 1)))), "0") >= 0) && (String.CompareOrdinal(NUM.Substring(Math.Min(i - 1, NUM.Length), Math.Min(1, Math.Max(0, NUM.Length - (i - 1)))), "9") <= 0))
					{
						digit_found = true;
					}
					else if ((NUM.Substring(Math.Min(i - 1, NUM.Length), Math.Min(1, Math.Max(0, NUM.Length - (i - 1)))) == ".") || (NUM.Substring(Math.Min(i - 1, NUM.Length), Math.Min(1, Math.Max(0, NUM.Length - (i - 1)))) == ","))
					{ 
						punc_found = true;
					}
					else if ((NUM.Substring(Math.Min(i - 1, NUM.Length), Math.Min(1, Math.Max(0, NUM.Length - (i - 1)))) == "-"))
					{ 
						punc_found = true;
						if (i == 1)
						{ // compensate for negitive numbers or numbers with hyphens in them
							result = true;
						}
						else
						{
							result = false;
						}
					}
					else
					{
						result = false;
						break;
					}
				}
				if (!digit_found)
				{
					result = false;
				}
			}

			return result;
		}

		internal static bool IsNumber(string inString)
		{


			bool result = false;
			result = true;

			int tempForEndVar = Strings.Len(inString) - 1;
			for (int i = 0; i <= tempForEndVar; i++)
			{
				if (!Information.IsNumeric(inString.Substring(Math.Min(i, inString.Length), Math.Min(1, Math.Max(0, inString.Length - i)))))
				{
					return false;
				}
			}


			return result;
		}

		internal static string CompanyLocked(int inCompanyId, int inJournalId)
		{

			string result = "";
			string strQuery = "";
			ADORecordSetHelper snpExists = null;

			try
			{

				result = "False";

				strQuery = "SELECT complock_user_id FROM Company_Lock WITH(NOLOCK)";
				strQuery = $"{strQuery} WHERE complock_comp_id  = {inCompanyId.ToString()}";
				strQuery = $"{strQuery} AND complock_journ_id  = {inJournalId.ToString()}";

				snpExists = ADORecordSetHelper.Open(strQuery, modAdminCommon.LOCAL_ADO_DB, "");

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(snpExists.Fields) && !(snpExists.BOF && snpExists.EOF))
				{
					result = Convert.ToString(snpExists["complock_user_id"]).Trim();
					snpExists.Close();
				}

				snpExists = null;

				return result;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"CompanyLocked_Error ({Information.Err().Number.ToString()}) {excep.Message} : CMPID[{inCompanyId.ToString()}] JID[{inJournalId.ToString()}]", "modCommon(CMPLOCK)");
				return result;
			}
		}

		internal static string ContactLocked(int inContactId, int inJournalId)
		{

			string result = "";
			string strQuery = "";
			ADORecordSetHelper snpExists = null;

			try
			{

				result = "False";

				strQuery = "SELECT contlock_user_id FROM Contact_Lock WITH(NOLOCK)";
				strQuery = $"{strQuery} WHERE contlock_contact_id  = {inContactId.ToString()}";
				strQuery = $"{strQuery} AND contlock_journ_id  = {inJournalId.ToString()}";

				snpExists = ADORecordSetHelper.Open(strQuery, modAdminCommon.LOCAL_ADO_DB, "");

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(snpExists.Fields) && !(snpExists.BOF && snpExists.EOF))
				{
					result = Convert.ToString(snpExists["contlock_user_id"]).Trim();
					snpExists.Close();
				}

				snpExists = null;

				return result;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"ContactLocked_Error ({Information.Err().Number.ToString()}) {excep.Message} : CONID[{inContactId.ToString()}] JID[{inJournalId.ToString()}]", "modCommon(CONLOCK)");
				return result;
			}
		}

		internal static string AircraftLocked(int inAircraftId, int inJournalId)
		{

			string result = "";
			string strQuery = "";
			ADORecordSetHelper snpExists = null; //aey 6/14/04

			try
			{

				result = "False";

				strQuery = "SELECT alock_user_id FROM Aircraft_Lock WITH(NOLOCK)";
				strQuery = $"{strQuery} WHERE alock_ac_id  = {inAircraftId.ToString()}";
				strQuery = $"{strQuery} AND alock_journ_id  = {inJournalId.ToString()}";

				snpExists = ADORecordSetHelper.Open(strQuery, modAdminCommon.LOCAL_ADO_DB, "");

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(snpExists.Fields) && !(snpExists.BOF && snpExists.EOF))
				{
					result = Convert.ToString(snpExists["alock_user_id"]).Trim();
					snpExists.Close();
				}

				snpExists = null;

				return result;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"ContactLocked_Error ({Information.Err().Number.ToString()}) {excep.Message} : ACID[{inAircraftId.ToString()}] JID[{inJournalId.ToString()}]", "modCommon(ACLOCK)");
				return result;
			}
		}

		internal static object LockCompany(int inCompanyId, int inJournalId, string strUserId)
		{

			string strQuery = "";

			try
			{

				if (CompanyLocked(inCompanyId, inJournalId).ToUpper() == ("False").ToUpper())
				{
					strQuery = "INSERT INTO Company_Lock (complock_comp_id, complock_journ_id, complock_user_id)";
					strQuery = $"{strQuery} VALUES({inCompanyId.ToString()}, {inJournalId.ToString()}, '{strUserId.Trim().ToLower()}')";
					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = strQuery;
					TempCommand.CommandType = CommandType.Text;
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery(); //aey 6/14/04
				}
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"LockCompany_Error ({Information.Err().Number.ToString()}) {excep.Message} : CMPID[{inCompanyId.ToString()}] JID[{inJournalId.ToString()}] UID[{strUserId.Trim()}]", "modCommon(LOCKCOMP)");
				return null;
			}

			return null;
		}

		internal static object LockContact(int inContactId, int inJournalId, string strUserId)
		{

			string strQuery = "";

			try
			{

				if (ContactLocked(inContactId, inJournalId).ToUpper() == ("False").ToUpper())
				{
					strQuery = "INSERT INTO Contact_Lock (contlock_contact_id, contlock_journ_id, contlock_user_id)";
					strQuery = $"{strQuery} VALUES({inContactId.ToString()}, {inJournalId.ToString()}, '{strUserId}')";
					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = strQuery;
					TempCommand.CommandType = CommandType.Text;
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery(); //aey 6/14/04
				}
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"LockContact_Error ({Information.Err().Number.ToString()}) {excep.Message} : CONID[{inContactId.ToString()}] JID[{inJournalId.ToString()}] UID[{strUserId.Trim()}]", "modCommon(LOCKCON)");
				return null;
			}

			return null;
		}

		internal static object LockAircraft(int inAircraftId, int inJournalId, string strUserId)
		{

			string strQuery = "";

			try
			{

				if (AircraftLocked(inAircraftId, inJournalId).ToUpper() == ("False").ToUpper())
				{
					strQuery = "INSERT INTO Aircraft_Lock (alock_ac_id, alock_journ_id, alock_user_id)";
					strQuery = $"{strQuery} VALUES({inAircraftId.ToString()}, {inJournalId.ToString()}, '{strUserId}')";
					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = strQuery;
					TempCommand.CommandType = CommandType.Text;
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery(); //converted to ado 6/8/2004 aey
				}
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"LockAircraft_Error ({Information.Err().Number.ToString()}) {excep.Message} : ACID[{inAircraftId.ToString()}] JID[{inJournalId.ToString()}] UID[{strUserId.Trim()}]", "modCommon(ACLOCK)");
				return null;
			}

			return null;
		}

		internal static object UnLockCompany(int inCompanyId, int inJournalId, string strUserId)
		{

			string strQuery = "";

			try
			{

				modAdminCommon.Record_Event("Monitor Activity", "UnLockCompany", 0, inJournalId, inCompanyId, false, 0, 0);

				strQuery = $"DELETE FROM Company_Lock WHERE complock_comp_id = {inCompanyId.ToString()}" +
				           $" AND complock_journ_id = {inJournalId.ToString()} AND complock_user_id = '{strUserId.Trim().ToLower()}'";

				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = strQuery;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"UnLockCompany_Error ({Information.Err().Number.ToString()}) {excep.Message} : CMPID[{inCompanyId.ToString()}] JID[{inJournalId.ToString()}] UID[{strUserId.Trim()}]", "modCommon(COMPUNLOCK)");
				return null;
			}

			return null;
		} // UnLockCompany

		internal static object UnLockCompany_ALL(int inJournalId, string strUserId)
		{

			string strQuery = "";

			try
			{

				//if we are on a current company, unlock all of the others
				if (inJournalId == 0)
				{

					strQuery = $"DELETE FROM Company_Lock WHERE complock_user_id = '{strUserId.Trim().ToLower()}'";

					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = strQuery;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();

				}
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"UnLockCompany_Error ({Information.Err().Number.ToString()}) {excep.Message} : UID[{strUserId.Trim()}]", "modCommon(COMPUNLOCK)");
				return null;
			}

			return null;
		}

		internal static object UnLockAircraft(int inAircraftId, int inJournalId, string strUserId)
		{

			string strQuery = "";

			try
			{

				strQuery = $"DELETE FROM Aircraft_Lock WHERE alock_ac_id = {inAircraftId.ToString()}" +
				           $" AND alock_journ_id = {inJournalId.ToString()} AND alock_user_id = '{strUserId.Trim()}'";

				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = strQuery;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery(); //aey 6/14/04
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"UnLockAircraft_Error ({Information.Err().Number.ToString()}) {excep.Message} : ACID[{inAircraftId.ToString()}] JID[{inJournalId.ToString()}] UID[{strUserId.Trim()}]", "modCommon(ACUNLOCK)");
				return null;
			}

			return null;
		}

		internal static object UnLockAircraft_ALL(string strUserId)
		{

			string strQuery = "";

			try
			{

				strQuery = $"DELETE FROM Aircraft_Lock WHERE alock_journ_id = 0 AND alock_user_id = '{strUserId.Trim()}'";

				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = strQuery;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery(); //aey 6/14/04
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"UnLockAircraft_Error ({Information.Err().Number.ToString()}) {excep.Message}  UID[{strUserId.Trim()}]", "modCommon(ACUNLOCK)");
				return null;
			}

			return null;
		}
		internal static object UnLockAircraft_ALL_History(string strUserId)
		{

			string strQuery = "";

			try
			{

				strQuery = $"DELETE FROM Aircraft_Lock WHERE alock_journ_id > 0 AND alock_user_id = '{strUserId.Trim()}'";

				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = strQuery;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery(); //aey 6/14/04
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"UnLockAircraft_ALL_History_Error ({Information.Err().Number.ToString()}) {excep.Message}  UID[{strUserId.Trim()}]", "modCommon(ACUNLOCK)");
				return null;
			}

			return null;
		}

		internal static void SetComboText(ComboBox PassedCombo, string PassedText)
		{


			bool FoundIt = false;

			int tempForEndVar = PassedCombo.Items.Count - 1;
			for (int i = 0; i <= tempForEndVar; i++)
			{

				if (PassedCombo.GetListItem(i).StartsWith(PassedText, StringComparison.Ordinal))
				{
					PassedCombo.SelectedIndex = i;
					FoundIt = true;
					break;
				}
			}

			if (!FoundIt)
			{
				if (PassedText == "")
				{
					PassedCombo.SelectedIndex = -1;
				}
				else
				{
					PassedCombo.AddItem(PassedText);
					PassedCombo.SelectedIndex = PassedCombo.Items.Count - 1;
				}
			}

		}

		internal static bool IsComboTextInList(ComboBox cmbBox, string strText)
		{


			bool bResults = false;
			strText = strText.Trim();

			if (cmbBox.Items.Count > 0)
			{

				if (strText != "")
				{

					int tempForEndVar = cmbBox.Items.Count - 1;
					for (int lCnt1 = 0; lCnt1 <= tempForEndVar; lCnt1++)
					{
						if (cmbBox.GetListItem(lCnt1) == strText)
						{
							cmbBox.SelectedIndex = lCnt1;
							bResults = true;
							break;
						}
					}

				} // If strText <> "" Then

			} // If cmbBox.ListCount > 0 Then

			return bResults;

		} // IsComboTextInList


		internal static void Verify_Aircraft(int in_Aircraft_ID, int inComp_ID, int inContact_ID, int inJournal_ID)
		{

			try
			{

				string Query = "";

				Query = $"EXEC HomebaseVerifyAircraft {in_Aircraft_ID.ToString()},{inComp_ID.ToString()},{inContact_ID.ToString()},{inJournal_ID.ToString()},'{modAdminCommon.gbl_User_ID}',{modAdminCommon.gbl_Account_ID}, '' ";

				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = Query;
				TempCommand.CommandType = CommandType.Text;
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery(); //aey 6/14/04
			}
			catch (System.Exception excep)
			{

				// Add the Held Error Values to the Report_Error procedure
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Verify_Aircraft_Error ({Information.Err().Number.ToString()}) {excep.Message}", "modCommon (Aircraft)");
				return;
			}

		}

		internal static void Combine_Company(int Old_Company_ID, int New_Company_ID)
		{

			string strError = "";
			try
			{

				int lError = 0;

				string Query = "";
				ADORecordSetHelper snpUpdComp = new ADORecordSetHelper();
				DbCommand cmdUpdChange = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				DbParameterCollection cmdUpdParms = null;
				int HoldTimeOut = 0;

				string FOwner_Note = "";

				strError = "start";

				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Selecting Duplicate Company", Color.Blue);

				// MODIFIED BY RTW ON 3/17/2011 TO USE NEW STORED PROCEDURE - OLD ONE WAS HomebaseCombineCompany
				Query = "HomebaseRemoveCompanyDuplicate ";

				strError = "ado";
				//set cmdUpdChange.ActiveConnection = ADODB_Trans_conn
				cmdUpdChange.Connection = modAdminCommon.LOCAL_ADO_DB;
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(cmdUpdChange);
				HoldTimeOut = cmdUpdChange.CommandTimeout;
				cmdUpdChange.CommandTimeout = 300;
				cmdUpdChange.CommandText = Query;
				cmdUpdChange.CommandType = CommandType.StoredProcedure;

				cmdUpdParms = cmdUpdChange.Parameters;
				DbParameter TempParameter = null;
				TempParameter = cmdUpdChange.CreateParameter();
				TempParameter.ParameterName = "RETURN_VALUE";
				TempParameter.DbType = DbType.Int32;
				TempParameter.Direction = ParameterDirection.ReturnValue;
				TempParameter.Size = 0;
				cmdUpdParms.Add(TempParameter);
				DbParameter TempParameter_2 = null;
				TempParameter_2 = cmdUpdChange.CreateParameter();
				TempParameter_2.ParameterName = "@Old_Company_id";
				TempParameter_2.DbType = DbType.Int32;
				TempParameter_2.Direction = ParameterDirection.Input;
				TempParameter_2.Size = 0;
				cmdUpdParms.Add(TempParameter_2);
				DbParameter TempParameter_3 = null;
				TempParameter_3 = cmdUpdChange.CreateParameter();
				TempParameter_3.ParameterName = "@New_Company_id";
				TempParameter_3.DbType = DbType.Int32;
				TempParameter_3.Direction = ParameterDirection.Input;
				TempParameter_3.Size = 0;
				cmdUpdParms.Add(TempParameter_3);
				DbParameter TempParameter_4 = null;
				TempParameter_4 = cmdUpdChange.CreateParameter();
				TempParameter_4.ParameterName = "@User_id";
				TempParameter_4.DbType = DbType.String;
				TempParameter_4.Direction = ParameterDirection.Input;
				TempParameter_4.Size = 4;
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				TempParameter_4.Value = DBNull.Value;
				cmdUpdParms.Add(TempParameter_4);
				cmdUpdParms["@Old_Company_id"].Value = Old_Company_ID;
				cmdUpdParms["@New_Company_id"].Value = New_Company_ID;
				cmdUpdParms["@User_id"].Value = modAdminCommon.gbl_User_ID;

				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(cmdUpdChange);
				cmdUpdChange.ExecuteNonQuery();
				cmdUpdChange.CommandTimeout = HoldTimeOut;

				strError = $"return {Conversion.Val($"{Convert.ToString(cmdUpdParms["RETURN_VALUE"].Value)}").ToString()}";
				if (Conversion.Val($"{Convert.ToString(cmdUpdParms["RETURN_VALUE"].Value)}") == 0)
				{
					throw new Exception(); // it didn't finish the stored procedure
				}
				else
				{
					// 03/22/2011 - By David D. Cruger; Put some vbCrLf breaks in the message.
					MessageBox.Show($"COMPANY DUPLICATE REMOVAL{Environment.NewLine}Note that your company duplicate removal request has been submitted.{Environment.NewLine}Homebase will be working on completing the process in the background.{Environment.NewLine}Both of the companies will be locked until completion.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}

				cmdUpdChange = null;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				strError = $"{Information.Err().Number.ToString()} {excep.Message} {strError} Comp to Remove:{Old_Company_ID.ToString()}, Comp to Keep: {New_Company_ID.ToString()}";

				// 10/11/2002 - By David D. Cruger; Add these held error values to the Report_Error message
				modAdminCommon.Report_Error($"Combine_Company_Error: {strError} Cound not complete company update.  {Old_Company_ID.ToString()} {New_Company_ID.ToString()}");
			}

		}

		internal static bool Transaction_Save_Aircraft_Company_History(int in_journal_id, ADORecordSetHelper in_snp_Company, ADORecordSetHelper in_snp_Contact, ADORecordSetHelper in_snp_Company_Phones, ADORecordSetHelper in_snp_Company_Btypes, ADORecordSetHelper in_snp_Company_Certs, int inContact_ID = 0, bool in_SendToWeb = true)
		{

			bool result = false;
			try
			{

				string Query = "";
				int i = 0;
				// RTW - 2/24/2006 - ADDED TO ELIMINATE DOING A BUNCH OF SYSTEM DATE/TIME
				// FUNCTIONS FOR EACH TRANSACTIONS - DO IT ONCE AND STORE IT
				string CurrentDateTime = "";
				CurrentDateTime = modAdminCommon.GetDateTime();

				// **************************************************************
				// DEFINE ALL OF THE RECORDSETS TO BE USED FOR ADDING/UPDATING
				ADORecordSetHelper ado_new_company = new ADORecordSetHelper();
				ADORecordSetHelper ado_New_Contact = new ADORecordSetHelper();
				ADORecordSetHelper ado_new_phone = new ADORecordSetHelper();
				ADORecordSetHelper ado_new_BusType = new ADORecordSetHelper();
				ADORecordSetHelper ado_new_Certs = new ADORecordSetHelper();


				// **************************************************************
				// OPEN ALL OF THE ADO RECORDSETS TO BE USED FOR ADDING/UPDATING.
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Opening Companiess for Action ... ", Color.Blue);
				ado_new_company.Open("Select * from Company where comp_id = -1", modAdminCommon.ADODB_Trans_conn, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Opening Contacts for Action ... ", Color.Blue);
				ado_New_Contact.Open("Select * from Contact where contact_id = -1", modAdminCommon.ADODB_Trans_conn, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);


				// TEMP HOLD MSW - 1/30/12 -
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Opening Phone Numbers for Action ... ", Color.Blue);
				// ado_new_phone.Open "Phone_Numbers", ADODB_Trans_conn, adOpenStatic, adLockOptimistic, adCmdTable
				ado_new_phone.Open("Select * from Phone_Numbers where pnum_comp_id = -1", modAdminCommon.ADODB_Trans_conn, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);



				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Opening Company Business Types for Action ... ", Color.Blue);
				ado_new_BusType.Open("Select * from Business_Type_Reference where bustypref_id = -1", modAdminCommon.ADODB_Trans_conn, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Opening Company Certs for Action ... ", Color.Blue);
				ado_new_Certs.Open("Select * from Company_Certification where ccert_id = -1", modAdminCommon.ADODB_Trans_conn, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);


				result = false;
				Cursor.Current = Cursors.WaitCursor;

				// *******************************
				// STORE THE COMPANY INFORMATION
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Saving a Historical Company Records ... ", Color.Blue);
				//    Debug.Print "SAVING AIRCRAFT COMPANIES"
				if (!(in_snp_Company.BOF && in_snp_Company.EOF))
				{
					in_snp_Company.MoveFirst();

					while(!in_snp_Company.EOF)
					{
						//UPGRADE_ISSUE: (2064) ADODB.CursorOptionEnum property CursorOptionEnum.adAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_ISSUE: (2064) ADODB.Recordset method ado_new_company.Supports was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						if (ado_new_company.Supports(UpgradeStubs.ADODB_CursorOptionEnum.getadAddNew()))
						{
							ado_new_company.AddNew();
							i = 0;
							// Do While (I < in_snp_Company.Fields.Count)

							while((i < ado_new_company.FieldsMetadata.Count))
							{
								ado_new_company[i] = in_snp_Company[i];
								i++;
							};
							//                Debug.Print in_snp_Company!comp_id & "-" & in_Journal_ID
							ado_new_company["comp_journ_id"] = in_journal_id;
							ado_new_company["comp_active_flag"] = "N";

							//null checking added 9/29/04 aey
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (Convert.IsDBNull(ado_new_company["comp_fractowr_id"]))
							{
								ado_new_company["comp_fractowr_id"] = 0;
							}

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (Convert.IsDBNull(ado_new_company["comp_fractowr_contact_id"]))
							{
								ado_new_company["comp_fractowr_contact_id"] = 0;
							}

							if (in_SendToWeb)
							{ //aey 7/28/04
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								ado_new_company["comp_action_date"] = DBNull.Value;
							}
							else
							{
								ado_new_company["comp_action_date"] = CurrentDateTime;
							}
							ado_new_company.Update();
						}
						else
						{
							// If ado_new_company.Supports(adAddNew) Then
							return result;
						}
						in_snp_Company.MoveNext();
					};
				} // If Not (in_snp_Company.BOF And in_snp_Company.EOF) Then


				// ************************************
				// STORE THE CONTACT INFORMATION
				//    Debug.Print "Aircraft Contacts:"
				// RTW - 3/31/2004 - IF THE CONTACT ADO IS OPEN THEN USE IT
				if (in_snp_Contact.State == ConnectionState.Open)
				{
					modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Saving a Historical Contact Records ... ", Color.Blue);
					if (!(in_snp_Contact.BOF && in_snp_Contact.EOF))
					{
						in_snp_Contact.MoveFirst();

						while(!in_snp_Contact.EOF)
						{
							// JUST STORE THE SPECIFIC CONTACT IF PASSED IN
							// 6/12/03 - rtw - commented to allow storage of all contacts - refs were stored but not contacts
							//If in_snp_Contact!contact_id = inContact_ID Or Trim(inContact_ID) = "" Then
							//UPGRADE_ISSUE: (2064) ADODB.CursorOptionEnum property CursorOptionEnum.adAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_ISSUE: (2064) ADODB.Recordset method ado_New_Contact.Supports was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							if (ado_New_Contact.Supports(UpgradeStubs.ADODB_CursorOptionEnum.getadAddNew()))
							{
								ado_New_Contact.AddNew();
								i = 0;

								while((i < in_snp_Contact.FieldsMetadata.Count))
								{

									ado_New_Contact[i] = in_snp_Contact[i];
									i++;
								};
								ado_New_Contact["contact_journ_id"] = in_journal_id;
								//                Debug.Print in_snp_Contact!contact_comp_id & "-"; in_snp_Contact!contact_id & "-" & in_Journal_ID & ";"
								if (in_SendToWeb)
								{ //aey 7/28/04
									//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
									ado_New_Contact["contact_action_date"] = DBNull.Value;
								}
								else
								{
									ado_New_Contact["contact_action_date"] = CurrentDateTime;
								}

								ado_New_Contact.Update();

							}
							else
							{
								// If ado_new_contact.Supports(adAddNew) Then
								return result;
							}
							//End If
							in_snp_Contact.MoveNext();

						};
					} // If Not (in_snp_Contact.BOF And in_snp_Contact.EOF) Then
				}


				if (in_snp_Company_Phones.State == ConnectionState.Open)
				{
					modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Saving a Historical Company/Contact Phone Numbers ... ", Color.Blue);
					if (!(in_snp_Company_Phones.BOF && in_snp_Company_Phones.EOF))
					{
						in_snp_Company_Phones.MoveFirst();

						while(!in_snp_Company_Phones.EOF)
						{

							if (Convert.ToDouble(in_snp_Company_Phones["pnum_contact_id"]) == inContact_ID || inContact_ID == 0 || Convert.ToDouble(in_snp_Company_Phones["pnum_contact_id"]) == 0)
							{

								//UPGRADE_ISSUE: (2064) ADODB.CursorOptionEnum property CursorOptionEnum.adAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
								//UPGRADE_ISSUE: (2064) ADODB.Recordset method ado_new_phone.Supports was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
								if (ado_new_phone.Supports(UpgradeStubs.ADODB_CursorOptionEnum.getadAddNew()))
								{
									ado_new_phone.AddNew();
									i = 0;

									while((i < in_snp_Company_Phones.FieldsMetadata.Count))
									{
										if (ado_new_phone.GetField(i).FieldMetadata.ColumnName != "pnum_id")
										{ // added MSW - 11/3/21 - couldnt repeat - but assume here
											ado_new_phone[i] = in_snp_Company_Phones[i];
										}
										i++;
									};
									ado_new_phone["pnum_journ_id"] = in_journal_id;
									ado_new_phone.Update();
								}
								else
								{
									// If ado_new_phone.Supports(adAddNew) Then
									return result;
								}
							}
							in_snp_Company_Phones.MoveNext();
							// if not just saving stuff for a single contact
						}; // Do While Not in_snp_Company_Phones.EOF
					} // If Not (in_snp_Company_Phones.BOF And in_snp_Company_Phones.EOF) Then
				}

				// ****************************************
				// SAVING COMPANY BUSINESS TYPES
				if (in_snp_Company_Btypes.State == ConnectionState.Open)
				{
					modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Saving a Company Business Types  ... ", Color.Blue);
					//UPGRADE_ISSUE: (2064) ADODB.CursorOptionEnum property CursorOptionEnum.adAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_ISSUE: (2064) ADODB.Recordset method ado_new_BusType.Supports was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					if (ado_new_BusType.Supports(UpgradeStubs.ADODB_CursorOptionEnum.getadAddNew()))
					{

						while(!in_snp_Company_Btypes.EOF)
						{
							ado_new_BusType.AddNew();
							i = 0;

							while((i < in_snp_Company_Btypes.FieldsMetadata.Count))
							{
								if (ado_new_BusType.GetField(i).FieldMetadata.ColumnName != "bustypref_id")
								{
									ado_new_BusType[i] = in_snp_Company_Btypes[i];
								}
								i++;
							};
							ado_new_BusType["bustypref_journ_id"] = in_journal_id;
							ado_new_BusType.Update();
							in_snp_Company_Btypes.MoveNext();
						}; //  Do While Not snp_BusType.EOF
					}
					else
					{
						// If ado_new_BusType.Supports(adAddNew) Then
						return result;
					}
				}

				// ****************************************
				// SAVING COMPANY CERTS
				if (in_snp_Company_Certs.State == ConnectionState.Open)
				{
					modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Saving a Company Certs  ... ", Color.Blue);
					//UPGRADE_ISSUE: (2064) ADODB.CursorOptionEnum property CursorOptionEnum.adAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_ISSUE: (2064) ADODB.Recordset method ado_new_Certs.Supports was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					if (ado_new_Certs.Supports(UpgradeStubs.ADODB_CursorOptionEnum.getadAddNew()))
					{

						while(!in_snp_Company_Certs.EOF)
						{
							ado_new_Certs.AddNew();
							i = 0;

							while((i < in_snp_Company_Certs.FieldsMetadata.Count))
							{
								if (ado_new_Certs.GetField(i).FieldMetadata.ColumnName != "ccert_id" && ado_new_Certs.GetField(i).FieldMetadata.ColumnName != "ccert_dsg_code")
								{ // added MSW - 6/18/24 ccert_dsg_code
									ado_new_Certs[i] = in_snp_Company_Certs[i];
								}
								i++;
							};
							ado_new_Certs["ccert_journ_id"] = in_journal_id;
							ado_new_Certs.Update();
							in_snp_Company_Certs.MoveNext();
						}; //  Do While Not snp_BusType.EOF
					}
					else
					{
						// If ado_new_BusType.Supports(adAddNew) Then
						return result;
					}
				}


				// **************************************************************
				// Indicate that the Company History data was successfully saved.
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Company Saves Complete.", Color.Blue);
				result = true;


				// **********************************************************************
				// CLOSE AND CLEARE THE ADO RECORD SETS USED TO ADDING/UPDATING RECORDS
				ado_New_Contact.Close();
				ado_new_company.Close();
				ado_new_phone.Close();
				ado_new_BusType.Close();
				ado_new_Certs.Close();

				ado_new_company = null;
				ado_New_Contact = null;
				ado_new_phone = null;
				ado_new_Certs = null;

				return result;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Transaction_Save_Aircraft_Company_History_Error ({Information.Err().Number.ToString()}) {excep.Message}", "modCommon (Transaction)");
				return result;
			}
		}

		internal static void Confirm_Company(int vcomp_id)
		{

			string Query = "UPDATE Company SET";
			Query = $"{Query} comp_address_confirm_date='{DateTime.Parse(modAdminCommon.DateToday).ToString("d")}',";
			Query = $"{Query} comp_web_confirm_date='{DateTime.Parse(modAdminCommon.DateToday).ToString("d")}',";
			Query = $"{Query} comp_email_confirm_date='{DateTime.Parse(modAdminCommon.DateToday).ToString("d")}',";
			Query = $"{Query} comp_last_contact_date = '{DateTime.Parse(modAdminCommon.DateToday).ToString("d")}',";
			Query = $"{Query} comp_action_date = NULL";

			Query = $"{Query} WHERE comp_id={vcomp_id.ToString()} AND comp_journ_id = 0";

			DbCommand TempCommand = null;
			TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
			UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
			TempCommand.CommandText = Query;
			//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
			TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
			UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
			TempCommand.ExecuteNonQuery(); //8/16/04 aey

			Query = "UPDATE Phone_Numbers SET";
			Query = $"{Query} pnum_confirm_date ='{DateTime.Parse(modAdminCommon.DateToday).ToString("d")}'";
			Query = $"{Query} WHERE pnum_comp_id = {vcomp_id.ToString()} AND pnum_journ_id = 0 AND pnum_contact_id = 0";

			DbCommand TempCommand_2 = null;
			TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
			UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
			TempCommand_2.CommandText = Query;
			//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
			TempCommand_2.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
			UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
			TempCommand_2.ExecuteNonQuery(); //8/16/04 aey

		}

		internal static bool Contact_Needs_Confirmation(int lCompId, int lContactId)
		{
			//  This Boolean function returns a TRUE if the contact needs to have
			//  dates confirmed by checking all the applicable confirmation dates
			//  on the company record (name, title, email, and
			//  phone). It is passed a contact id to check on.

			bool result = false;
			string Query = "";
			try
			{

				ADORecordSetHelper snp_ContactConfirm = new ADORecordSetHelper();
				ADORecordSetHelper snp_Pnum = new ADORecordSetHelper();

				System.DateTime tempconfirmdate = DateTime.FromOADate(0);
				bool phoneneedsconfirm = false;
				phoneneedsconfirm = false;

				bool bResults = false;

				bResults = false;

				Query = "SELECT contact_name_confirm_date, contact_title_confirm_date, contact_email_confirm_date";
				Query = $"{Query} FROM Contact WITH(NOLOCK) ";
				Query = $"{Query}WHERE (contact_id = {lContactId.ToString()}) ";
				Query = $"{Query}AND (contact_comp_id = {lCompId.ToString()}) ";
				Query = $"{Query}AND (contact_journ_id = 0) ";

				snp_ContactConfirm.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_ContactConfirm.BOF && snp_ContactConfirm.EOF))
				{

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snp_ContactConfirm["contact_name_confirm_date"]))
					{
						if (Information.IsDate(snp_ContactConfirm["contact_name_confirm_date"]))
						{

							tempconfirmdate = DateTime.Parse(Convert.ToString(snp_ContactConfirm["contact_name_confirm_date"])).AddDays(modAdminCommon.gbl_ConfirmDays);

							if (DateTime.Parse(DateTimeHelper.ToString(tempconfirmdate)) <= DateTime.Parse(DateTimeHelper.ToString(DateTime.Now)))
							{
								bResults = true;
							}
						}
						else
						{
							bResults = true;
						}
					}
					else
					{
						bResults = true;
					}

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snp_ContactConfirm["contact_title_confirm_date"]))
					{
						if (Information.IsDate(snp_ContactConfirm["contact_title_confirm_date"]))
						{

							tempconfirmdate = DateTime.Parse(Convert.ToString(snp_ContactConfirm["contact_title_confirm_date"])).AddDays(modAdminCommon.gbl_ConfirmDays);

							if (DateTime.Parse(DateTimeHelper.ToString(tempconfirmdate)) <= DateTime.Parse(DateTimeHelper.ToString(DateTime.Now)))
							{
								bResults = true;
							}
						}
						else
						{
							bResults = true;
						}
					}
					else
					{
						bResults = true;
					}

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snp_ContactConfirm["contact_email_confirm_date"]))
					{
						if (Information.IsDate(snp_ContactConfirm["contact_email_confirm_date"]))
						{

							tempconfirmdate = DateTime.Parse(Convert.ToString(snp_ContactConfirm["contact_email_confirm_date"])).AddDays(modAdminCommon.gbl_ConfirmDays);

							if (DateTime.Parse(DateTimeHelper.ToString(tempconfirmdate)) <= DateTime.Parse(DateTimeHelper.ToString(DateTime.Now)))
							{
								bResults = true;
							}
						}
						else
						{
							bResults = true;
						}
					}
					else
					{
						bResults = true;
					}

					Query = "SELECT pnum_number_full, pnum_type, pnum_confirm_date ";
					// 07/18/2019 - By David D. Cruger; Removed INDEX HINT
					Query = $"{Query}FROM phone_numbers WITH (NOLOCK) ";
					Query = $"{Query}INNER JOIN phone_type WITH (NOLOCK) ON pnum_type = ptype_name ";
					Query = $"{Query}WHERE (pnum_contact_id = {lContactId.ToString()}) ";
					Query = $"{Query}AND (pnum_comp_id = {lCompId.ToString()}) ";
					Query = $"{Query}AND (pnum_journ_id = 0) ";
					Query = $"{Query}ORDER BY ptype_seq_no, pnum_number_full";

					// rtw - changed to ado on 10/21/2002
					snp_Pnum.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!(snp_Pnum.BOF && snp_Pnum.EOF))
					{


						while(!snp_Pnum.EOF)
						{

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(snp_Pnum["pnum_confirm_date"]))
							{

								if (Information.IsDate(snp_Pnum["pnum_confirm_date"]))
								{

									tempconfirmdate = DateTime.Parse(Convert.ToString(snp_Pnum["pnum_confirm_date"])).AddDays(modAdminCommon.gbl_ConfirmDays);

									if (DateTime.Parse(DateTimeHelper.ToString(tempconfirmdate)) <= DateTime.Parse(DateTimeHelper.ToString(DateTime.Now)))
									{
										bResults = true;
									}

								}
								else
								{
									bResults = true;
								}

							}
							else
							{
								bResults = true;
							} // If Not IsNull(snp_Pnum("pnum_confirm_date")) Then

							snp_Pnum.MoveNext();

						}; // Do While Not snp_Pnum.EOF

					} // If Not (snp_Pnum.BOF And snp_Pnum.EOF) Then

					snp_Pnum.Close();

				} // If Not (snp_ContactConfirm.BOF And snp_ContactConfirm.EOF) Then

				snp_ContactConfirm.Close();

				snp_Pnum = null;
				snp_ContactConfirm = null;


				return bResults;
			}
			catch
			{

				MessageBox.Show($"Error checking on the need for Contact confirmation: {Query}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));

				result = false;
			}
			return result;
		} // Contact_Needs_Confirmation

		internal static void Confirm_Contact(int vcontact_id, string email_Address = "")
		{


			string Query = "UPDATE Contact SET";
			Query = $"{Query} contact_name_confirm_date = '{DateTime.Parse(modAdminCommon.DateToday).ToString("d")}',";
			Query = $"{Query} contact_title_confirm_date = '{DateTime.Parse(modAdminCommon.DateToday).ToString("d")}',";
			//added in MSW - using this for contact email address
			if (email_Address.Trim() == "")
			{
			}
			else
			{
				Query = $"{Query} contact_email_confirm_date = '{DateTime.Parse(modAdminCommon.DateToday).ToString("d")}',";
			}
			Query = $"{Query} contact_phone_confirm_date = '{DateTime.Parse(modAdminCommon.DateToday).ToString("d")}'";
			Query = $"{Query} WHERE contact_id = {vcontact_id.ToString()} AND contact_journ_id = 0";

			DbCommand TempCommand = null;
			TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
			UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
			TempCommand.CommandText = Query;
			//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
			TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
			UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
			TempCommand.ExecuteNonQuery();

		}

		internal static bool Check_For_Account_Reassignment(int inOld_Comp_ID, int inNew_Comp_ID, int inAircraft_ID, string insert_aa_reassign = "Y")
		{


			bool result = false;
			string strMsg = "";
			int Retry_Count = 0;
			try
			{

				string Query = ""; // string used for queries
				int tmpResult = 0;
				int HoldTimeOut = 0;

				ADORecordSetHelper snpUpdComp = new ADORecordSetHelper();
				DbCommand cmdUpdChange = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateCommand();
				DbParameterCollection cmdUpdParms = null;

				Retry_Count = 0;

				if (inNew_Comp_ID == 0)
				{ //aey 6/1/04 cannot reassign if company does not exist.
					return result;
				}



				strMsg = $"retry:{Conversion.Str(Retry_Count)}";


				result = true;

				Query = "HomebaseCheckForAccountReassignment";
				strMsg = "set";
				cmdUpdChange.Connection = modAdminCommon.ADODB_Trans_conn;
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(cmdUpdChange);
				HoldTimeOut = cmdUpdChange.CommandTimeout;
				cmdUpdChange.CommandTimeout = 500;
				cmdUpdChange.CommandText = Query;
				cmdUpdChange.CommandType = CommandType.StoredProcedure;

				cmdUpdParms = cmdUpdChange.Parameters;
				DbParameter TempParameter = null;
				TempParameter = cmdUpdChange.CreateParameter();
				TempParameter.ParameterName = "RETURN_VALUE";
				TempParameter.DbType = DbType.Int32;
				TempParameter.Direction = ParameterDirection.ReturnValue;
				TempParameter.Size = 0;
				cmdUpdParms.Add(TempParameter);
				DbParameter TempParameter_2 = null;
				TempParameter_2 = cmdUpdChange.CreateParameter();
				TempParameter_2.ParameterName = "@Old_Company_id";
				TempParameter_2.DbType = DbType.Int32;
				TempParameter_2.Direction = ParameterDirection.Input;
				TempParameter_2.Size = 0;
				cmdUpdParms.Add(TempParameter_2);
				DbParameter TempParameter_3 = null;
				TempParameter_3 = cmdUpdChange.CreateParameter();
				TempParameter_3.ParameterName = "@New_Company_id";
				TempParameter_3.DbType = DbType.Int32;
				TempParameter_3.Direction = ParameterDirection.Input;
				TempParameter_3.Size = 0;
				cmdUpdParms.Add(TempParameter_3);
				DbParameter TempParameter_4 = null;
				TempParameter_4 = cmdUpdChange.CreateParameter();
				TempParameter_4.ParameterName = "@in_Ac_id";
				TempParameter_4.DbType = DbType.Int32;
				TempParameter_4.Direction = ParameterDirection.Input;
				TempParameter_4.Size = 0;
				cmdUpdParms.Add(TempParameter_4);
				DbParameter TempParameter_5 = null;
				TempParameter_5 = cmdUpdChange.CreateParameter();
				TempParameter_5.ParameterName = "@User_id";
				TempParameter_5.DbType = DbType.String;
				TempParameter_5.Direction = ParameterDirection.Input;
				TempParameter_5.Size = 4;
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				TempParameter_5.Value = DBNull.Value;
				cmdUpdParms.Add(TempParameter_5);
				DbParameter TempParameter_6 = null;
				TempParameter_6 = cmdUpdChange.CreateParameter();
				TempParameter_6.ParameterName = "@insert_AA_reassign";
				TempParameter_6.DbType = DbType.String;
				TempParameter_6.Direction = ParameterDirection.Input;
				TempParameter_6.Size = 1;
				TempParameter_6.Value = "Y";
				cmdUpdParms.Add(TempParameter_6);


				cmdUpdParms["@Old_Company_id"].Value = inOld_Comp_ID;
				cmdUpdParms["@New_Company_id"].Value = inNew_Comp_ID;
				cmdUpdParms["@in_Ac_id"].Value = inAircraft_ID;
				cmdUpdParms["@User_id"].Value = modAdminCommon.gbl_User_ID;
				cmdUpdParms["@insert_AA_reassign"].Value = insert_aa_reassign;


				strMsg = "exec";
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(cmdUpdChange);
				cmdUpdChange.ExecuteNonQuery();

				cmdUpdChange.CommandTimeout = HoldTimeOut; //restore to orignal value

				tmpResult = Convert.ToInt32(Conversion.Val($"{Convert.ToString(cmdUpdParms["RETURN_VALUE"].Value)}"));

				cmdUpdChange = null;
				strMsg = $"result:{Conversion.Str(tmpResult)}";

				if (tmpResult > 0)
				{

					//  REPORT ANY MISSING ACCOUNT REPS ON COMPANIES TO TECH
					if (tmpResult == 1 || tmpResult == 3)
					{
						strMsg = $"{strMsg}Original company ({inOld_Comp_ID.ToString()}) account id was blank or null. ";
					}

					if (tmpResult == 2 || tmpResult == 3)
					{
						strMsg = $"{strMsg}New company ({inOld_Comp_ID.ToString()}) account id was blank or null. ";
					}
					throw new Exception();

				}
			}
			catch (System.Exception excep)
			{

				result = false;
				int lErrNbr = 0;
				string strErrDesc = "";
				int K = 0;

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr = Information.Err().Number;
				strErrDesc = excep.Message;
				if (Retry_Count < 5)
				{ //aey 5/26/04 retry 5 times if deadlocked
					Retry_Count++;
					K = (strErrDesc.IndexOf("deadlocked") + 1);
					if (K > 0)
					{
						//UPGRADE_TODO: (1065) Error handling statement (Resume) could not be converted. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1065
						UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Statement");
					}
				}

				Information.Err().Number = lErrNbr;
				Information.Err().Description = strErrDesc;
				modAdminCommon.Report_Error($"Check_For_Account_Reassignment_Error: {lErrNbr.ToString()} Src:{excep.Source} Desc:{($"{strErrDesc}").Trim()}:{strMsg}");
			}

			return result;
		}

		internal static void Build_Company_NameAddress(ListBox FormBox, int PassedCompID, int PassedJournID, string company_string, bool get_contacts, ref bool has_phone)
		{

			string ErrorMsg = "";
			try
			{

				ADORecordSetHelper snp_AircraftcompanyArray = new ADORecordSetHelper();

				string Query = "";
				ADORecordSetHelper snp_Pnum = new ADORecordSetHelper();
				ADORecordSetHelper snpRelation = new ADORecordSetHelper();
				ADORecordSetHelper ado_ServicesUsed = new ADORecordSetHelper();
				string TempString = "";
				System.DateTime tempconfirmdate = DateTime.FromOADate(0);
				string Comma = "";
				string tmpCompService = "";
				bool phoneneedsconfirm = false;

				phoneneedsconfirm = false;

				Cursor.Current = Cursors.WaitCursor;

				FormBox.Items.Clear();

				Query = "SELECT comp_id, comp_name, comp_address1, comp_address2, comp_city, comp_state, comp_account_id,  comp_timezone, ";


				Query = $"{Query} replace(replace(replace(STUFF(( ";
				Query = $"{Query} select svud_desc + ', ' as svud_desc from Company_Services_Used with (NOLOCK) ";
				Query = $"{Query} inner join Services_Used with (NOLOCK) on svud_id = csu_svud_id ";
				Query = $"{Query} Where csu_comp_id = comp_id ";
				Query = $"{Query} FOR XML PATH('')),1,1,''), '<svud_desc>', ''), '</svud_desc>', ''), 'svud_desc>', '') As comp_service, ";




				Query = $"{Query}comp_zip_code, comp_country, comp_email_confirm_date, comp_web_confirm_date, comp_address_confirm_date, comp_name_alt, comp_name_alt_type";
				Query = $"{Query} FROM Company WITH(NOLOCK)  Where comp_id = {PassedCompID.ToString()}";
				Query = $"{Query} AND comp_journ_id = {PassedJournID.ToString()}";

				snp_AircraftcompanyArray.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_AircraftcompanyArray.BOF && snp_AircraftcompanyArray.EOF))
				{

					ErrorMsg = "Add Fields to ListBox";

					FormBox.AddItem($"{($"{Convert.ToString(snp_AircraftcompanyArray["comp_name"])}").Trim()} (ID={($"{Convert.ToString(snp_AircraftcompanyArray["comp_id"])}").Trim()})");
					FormBox.SetItemData(0, Convert.ToInt32(Double.Parse(($"{Convert.ToString(snp_AircraftcompanyArray["comp_id"])}").Trim())));

					FormBox.Tag = Convert.ToString(snp_AircraftcompanyArray["comp_name"]);

					// ADDED MSW - PER REQUEST - 9/11/18
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snp_AircraftcompanyArray["comp_name_alt_type"]))
					{
						// If Trim(snp_AircraftcompanyArray!comp_name_alt_type) = "DBA" Then
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snp_AircraftcompanyArray["comp_name_alt"]))
						{
							FormBox.AddItem(($"{Convert.ToString(snp_AircraftcompanyArray["comp_name_alt_type"])}: {Convert.ToString(snp_AircraftcompanyArray["comp_name_alt"])}").Trim());
						}
						// End If
					}


					if (Strings.Len(($"{Convert.ToString(snp_AircraftcompanyArray["comp_address1"])}").Trim()) > 0)
					{
						FormBox.AddItem(($"{Convert.ToString(snp_AircraftcompanyArray["comp_address1"])}").Trim());
					}

					if (Strings.Len(($"{Convert.ToString(snp_AircraftcompanyArray["Comp_address2"])}").Trim()) > 0)
					{
						FormBox.AddItem(($"{Convert.ToString(snp_AircraftcompanyArray["Comp_address2"])}").Trim());
					}
					TempString = "";
					Comma = "";
					if (Strings.Len(($"{Convert.ToString(snp_AircraftcompanyArray["Comp_city"])}").Trim()) > 0)
					{
						TempString = $"{TempString}{Comma}{($"{Convert.ToString(snp_AircraftcompanyArray["Comp_city"])}").Trim()}";
						Comma = ", ";
					}

					if (Strings.Len(($"{Convert.ToString(snp_AircraftcompanyArray["comp_state"])}").Trim()) > 0)
					{
						TempString = $"{TempString}{Comma}{($"{Convert.ToString(snp_AircraftcompanyArray["comp_state"])}").Trim()}";
						Comma = " ";
					}
					else
					{
						if (Strings.Len(($"{Convert.ToString(snp_AircraftcompanyArray["Comp_city"])}").Trim()) == 0)
						{
							Comma = "";
						}
						else
						{
							Comma = " ";
						}
					}

					if (Strings.Len(($"{Convert.ToString(snp_AircraftcompanyArray["Comp_zip_code"])}").Trim()) > 0)
					{
						TempString = $"{TempString}{Comma}{($"{Convert.ToString(snp_AircraftcompanyArray["Comp_zip_code"])}").Trim()}";
						Comma = " ";
					}
					if (Strings.Len(($"{Convert.ToString(snp_AircraftcompanyArray["Comp_country"])}").Trim()) > 0)
					{
						TempString = $"{TempString}{Comma}{($"{Convert.ToString(snp_AircraftcompanyArray["Comp_country"])}").Trim()}";
					}

					// added MSW - 4/20/20
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snp_AircraftcompanyArray["comp_timezone"]))
					{
						if (Strings.Len(($"{Convert.ToString(snp_AircraftcompanyArray["comp_timezone"])}").Trim()) > 0)
						{
							TempString = $"{TempString} ({($"{Convert.ToString(snp_AircraftcompanyArray["comp_timezone"])}").Trim()})";
						}
					}


					if (Strings.Len(TempString.Trim()) > 0)
					{
						FormBox.AddItem(TempString);
					}

					FormBox.AddItem(($"REP: {Convert.ToString(snp_AircraftcompanyArray["comp_account_id"])}").Trim());





					tmpCompService = "";
					TempString = "";



					FormBox.AddItem(($"Services Used: {Convert.ToString(snp_AircraftcompanyArray["comp_service"])}").Trim());


					Query = "SELECT pnum_number_full, pnum_type, pnum_confirm_date ";
					if (get_contacts)
					{
						Query = $"{Query}, contact_first_name, contact_last_name ";
					}
					Query = $"{Query} FROM phone_numbers WITH(NOLOCK), phone_type WITH(NOLOCK)";
					if (get_contacts)
					{
						Query = $"{Query} inner join Contact with (NOLOCK) on contact_comp_id = {PassedCompID.ToString()} and contact_journ_id = {PassedJournID.ToString()}";
					}

					Query = $"{Query} WHERE pnum_comp_id = {PassedCompID.ToString()} AND pnum_journ_id = {PassedJournID.ToString()}";

					if (get_contacts)
					{
						Query = $"{Query} AND pnum_contact_id > 0 ";
					}
					else
					{
						Query = $"{Query} AND pnum_contact_id = 0 ";
					}
					Query = $"{Query} AND pnum_type = ptype_name  ORDER BY ptype_seq_no, pnum_number_full";

					// rtw - changed to ado on 10/21/2002
					snp_Pnum.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
					if (!(snp_Pnum.BOF && snp_Pnum.EOF))
					{
						// 08/25/2006 - By David D. Cruger; Removed the MoveFirst statement

						while(!snp_Pnum.EOF)
						{

							has_phone = true;
							if (get_contacts)
							{
								FormBox.AddItem($"{($"{Convert.ToString(snp_Pnum["contact_first_name"])}").Trim()} {($"{Convert.ToString(snp_Pnum["contact_last_name"])}").Trim()}: {($"{Convert.ToString(snp_Pnum["pnum_type"])}").Trim()}: {($"{Convert.ToString(snp_Pnum["pnum_number_full"])}").Trim()}");
							}
							else
							{
								FormBox.AddItem($"{($"{Convert.ToString(snp_Pnum["pnum_type"])}").Trim()}: {($"{Convert.ToString(snp_Pnum["pnum_number_full"])}").Trim()}");
							}


							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(snp_Pnum["pnum_confirm_date"]))
							{
								if (Information.IsDate(snp_Pnum["pnum_confirm_date"]))
								{
									tempconfirmdate = Convert.ToDateTime(snp_Pnum["pnum_confirm_date"]).AddDays(modAdminCommon.gbl_ConfirmDays);

									if (tempconfirmdate <= DateTime.Parse(modAdminCommon.DateToday))
									{
										phoneneedsconfirm = true;
									}
								}
								else
								{
									phoneneedsconfirm = true;
								}
							}
							else
							{
								phoneneedsconfirm = true;
							}
							snp_Pnum.MoveNext();
						};
					}


					if (company_string.Trim() == "" && !get_contacts)
					{
						Query = "SELECT Company_Reference.*,actype_name,actype_compref_internal_flag,actype_compref_twoway_flag,actype_compref_name2";
						Query = $"{Query} FROM Company_Reference WITH(NOLOCK)";
						Query = $"{Query} INNER JOIN Aircraft_Contact_Type WITH(NOLOCK) ON compref_contact_type = actype_code";
						Query = $"{Query} WHERE (compref_journ_id = {PassedJournID.ToString()})";
						Query = $"{Query} AND (compref_comp_id = {PassedCompID.ToString()} OR compref_rel_comp_id = {PassedCompID.ToString()})";
						Query = $"{Query} ORDER BY actype_name";

						snpRelation.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

						if (!(snpRelation.BOF && snpRelation.EOF))
						{

							FormBox.AddItem("");
							FormBox.AddItem("** COMPANY RELATIONSHIPS **");

							while(!snpRelation.EOF)
							{
								TempString = "";

								if (Convert.ToInt32(Double.Parse(($"{Convert.ToString(snpRelation["compref_comp_id"])}").Trim())) == PassedCompID)
								{
									if (($"{Convert.ToString(snpRelation["actype_compref_twoway_flag"])}").Trim().ToUpper() == "Y")
									{
										TempString = ($"{Convert.ToString(snpRelation["actype_compref_name2"])}").Trim(); // " (" & Trim("" & snpRelation!compref_contact_type) & ")"
									}
									else
									{
										TempString = ($"{Convert.ToString(snpRelation["actype_name"])}").Trim(); // " (" & Trim("" & snpRelation!compref_contact_type) & ")"
									}
								}
								else
								{
									TempString = ($"{Convert.ToString(snpRelation["actype_name"])}").Trim(); // " (" & Trim("" & snpRelation!compref_contact_type) & ")"
								}

								if (Convert.ToInt32(Double.Parse(($"{Convert.ToString(snpRelation["compref_comp_id"])}").Trim())) == PassedCompID)
								{
									TempString = $"{TempString} {($"{GetCompanyName(Convert.ToInt32(snpRelation["compref_rel_comp_id"]), 0)}").Trim()}";
								}
								else
								{
									TempString = $"{TempString} {($"{GetCompanyName(Convert.ToInt32(snpRelation["compref_comp_id"]), 0)}").Trim()}";
								}

								FormBox.AddItem(TempString);

								snpRelation.MoveNext();
							};

						}
					}

					//check confirmation of company fields

					// set background to grey before checking color confirm
					FormBox.BackColor = Color.FromArgb(224, 224, 224);

					// DETERMINE IF THE PHONE NUMBERS NEEDED CONFIRMATION
					// IF THEY DID THEN TURN PINK AND EXIT

					if (phoneneedsconfirm)
					{
						FormBox.BackColor = Color.FromArgb(255, 192, 192);
						goto CloseMe;
					}

					if (PassedJournID == 0)
					{

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snp_AircraftcompanyArray["comp_email_confirm_date"]))
						{
							if (Information.IsDate(snp_AircraftcompanyArray["comp_email_confirm_date"]))
							{

								tempconfirmdate = Convert.ToDateTime(snp_AircraftcompanyArray["comp_email_confirm_date"]).AddDays(modAdminCommon.gbl_ConfirmDays);

								if (tempconfirmdate <= DateTime.Parse(modAdminCommon.DateToday))
								{
									FormBox.BackColor = Color.FromArgb(255, 192, 192);
									goto CloseMe;
								}
							}
							else
							{
								FormBox.BackColor = Color.FromArgb(255, 192, 192);
								goto CloseMe;
							}
						}
						else
						{
							FormBox.BackColor = Color.FromArgb(255, 192, 192);
							goto CloseMe;
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snp_AircraftcompanyArray["comp_web_confirm_date"]))
						{
							if (Information.IsDate(snp_AircraftcompanyArray["comp_web_confirm_date"]))
							{

								tempconfirmdate = Convert.ToDateTime(snp_AircraftcompanyArray["comp_web_confirm_date"]).AddDays(modAdminCommon.gbl_ConfirmDays);

								if (tempconfirmdate <= DateTime.Parse(modAdminCommon.DateToday))
								{
									FormBox.BackColor = Color.FromArgb(255, 192, 192);
									goto CloseMe;
								}
							}
							else
							{
								FormBox.BackColor = Color.FromArgb(255, 192, 192);
								goto CloseMe;
							}
						}
						else
						{
							FormBox.BackColor = Color.FromArgb(255, 192, 192);
							goto CloseMe;
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snp_AircraftcompanyArray["comp_address_confirm_date"]))
						{
							if (Information.IsDate(snp_AircraftcompanyArray["comp_address_confirm_date"]))
							{

								tempconfirmdate = Convert.ToDateTime(snp_AircraftcompanyArray["comp_address_confirm_date"]).AddDays(modAdminCommon.gbl_ConfirmDays);

								if (tempconfirmdate <= DateTime.Parse(modAdminCommon.DateToday))
								{
									FormBox.BackColor = Color.FromArgb(255, 192, 192);
									goto CloseMe;
								}
							}
							else
							{
								FormBox.BackColor = Color.FromArgb(255, 192, 192);
								goto CloseMe;
							}
						}
						else
						{
							FormBox.BackColor = Color.FromArgb(255, 192, 192);
							goto CloseMe;
						}
					}

				}
				else
				{
					FormBox.BackColor = Color.FromArgb(255, 192, 192);
					FormBox.AddItem($"ERROR: This Company ({PassedCompID.ToString()}) has been removed ");
					FormBox.AddItem("or replaced.  Please inform the TECH department ");
					FormBox.AddItem("of this error.");
				} // check for active company record

				CloseMe:


				if (snpRelation.State == ConnectionState.Open)
				{
					snpRelation.Close();
				}
				snpRelation = null;

				if (snp_Pnum.State == ConnectionState.Open)
				{
					snp_Pnum.Close();
				}
				snp_Pnum = null;

				if (snp_AircraftcompanyArray.State == ConnectionState.Open)
				{
					snp_AircraftcompanyArray.Close();
				}
				snp_AircraftcompanyArray = null;

				if (ado_ServicesUsed.State == ConnectionState.Open)
				{
					ado_ServicesUsed.Close();
				}
				ado_ServicesUsed = null;

				Cursor.Current = CursorHelper.CursorDefault;
				FormBox.Refresh();
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				ErrorMsg = $"{Information.Err().Number.ToString()} {excep.Message} {excep.Source} {ErrorMsg}";


				modAdminCommon.Report_Error($"Build_Aircraft_Company_NameAddress_Error: [{ErrorMsg}]");
			}
		}

		internal static void Build_Company_NameAddress(ListBox FormBox, int PassedCompID, int PassedJournID, string company_string, bool get_contacts)
		{
			bool tempRefParam = false;
			Build_Company_NameAddress(FormBox, PassedCompID, PassedJournID, company_string, get_contacts, ref tempRefParam);
		}

		internal static void Build_Company_NameAddress(ListBox FormBox, int PassedCompID, int PassedJournID, string company_string)
		{
			bool tempRefParam2 = false;
			Build_Company_NameAddress(FormBox, PassedCompID, PassedJournID, company_string, false, ref tempRefParam2);
		}

		internal static void Build_Company_NameAddress(ListBox FormBox, int PassedCompID, int PassedJournID)
		{
			bool tempRefParam3 = false;
			Build_Company_NameAddress(FormBox, PassedCompID, PassedJournID, "", false, ref tempRefParam3);
		}

		internal static void Build_Contact_Info(ListBox FormBox, object PassedContactID, object PassedJournID, bool Details = true, int comp_id_temp = 0, bool active_is_allowed = false)
		{

			string ErrorMsg = "";
			ADORecordSetHelper snp_Current_Contact = default(ADORecordSetHelper);
			ADORecordSetHelper snp_Current_ContactInfo = default(ADORecordSetHelper);
			try
			{

				// 09/25/2006 - mjm - fixed the closing of the recordsets to only close if they were opened

				string Query = "";
				snp_Current_Contact = new ADORecordSetHelper();
				snp_Current_ContactInfo = new ADORecordSetHelper();
				string TempPrimaryContact = "";
				string phoneline = "";
				string finalline = "";
				StringBuilder repline = new StringBuilder();
				int PreviousContactID = 0;
				int currentContactCompIdID = 0;
				string contact_email = "";
				string contact_email_address = "";

				contact_email = "";
				ErrorMsg = "clear";

				FormBox.Items.Clear();

				ErrorMsg = "passed";

				//UPGRADE_WARNING: (1068) PassedContactID of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
				PassedContactID = Conversion.Val($"{Convert.ToString(PassedContactID)}");
				//UPGRADE_WARNING: (1068) PassedJournID of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
				PassedJournID = Conversion.Val($"{Convert.ToString(PassedJournID)}");
				currentContactCompIdID = 0;

				ErrorMsg = "query";

				Query = "SELECT Contact.*, ptype_seq_no, pnum_number_full, pnum_type, pnum_ext ";
				Query = $"{Query}FROM Contact WITH(NOLOCK) LEFT OUTER JOIN ";
				Query = $"{Query}Phone_Numbers WITH(NOLOCK) ON Contact.contact_id = Phone_Numbers.pnum_contact_id ";
				Query = $"{Query}AND Contact.contact_journ_id = Phone_Numbers.pnum_journ_id ";
				Query = $"{Query}FULL OUTER JOIN Phone_Type WITH(NOLOCK) ON Phone_Numbers.pnum_type = Phone_Type.ptype_name ";
				//UPGRADE_WARNING: (1068) PassedJournID of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
				Query = $"{Query}WHERE (Contact.contact_journ_id = {Convert.ToString(PassedJournID)}) ";
				//UPGRADE_WARNING: (1068) PassedContactID of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
				Query = $"{Query}AND (Contact.contact_id = {Convert.ToString(PassedContactID)}) ";

				if (active_is_allowed)
				{
				}
				else
				{
					Query = $"{Query} and contact_active_flag = 'Y' "; //aey 7/30/04  contact_active_flag
				}

				Query = $"{Query}ORDER BY ptype_seq_no, pnum_number_full ";

				ErrorMsg = "Open Contact Recordset";

				// rtw - 10/21/2002 - changed to ado
				snp_Current_Contact.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_Current_Contact.BOF && snp_Current_Contact.EOF))
				{
					TempPrimaryContact = "";

					ErrorMsg = "Add Fields to ListBox";
					//aey 7/12/04 added middle name and suffix #289


					// asked to be added back in - 4/20/20
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snp_Current_Contact["contact_sirname"]))
					{
						if (Convert.ToString(snp_Current_Contact["contact_sirname"]).Trim() != modGlobalVars.cEmptyString)
						{
							TempPrimaryContact = $"{Convert.ToString(snp_Current_Contact["contact_sirname"]).Trim()}{modGlobalVars.cSingleSpace}";
						}
					}


					TempPrimaryContact = $"{TempPrimaryContact}{($"{($"{Convert.ToString(snp_Current_Contact["contact_first_name"])} ").Trim()} {((Strings.Len(($"{Convert.ToString(snp_Current_Contact["contact_middle_initial"])}").Trim()) == 0) ? "" : $"{Convert.ToString(snp_Current_Contact["contact_middle_initial"])}. ")}{($"{Convert.ToString(snp_Current_Contact["contact_last_name"])} ").Trim()}")}{((Strings.Len(($"{Convert.ToString(snp_Current_Contact["contact_suffix"])}").Trim()) == 0) ? "" : $" {Convert.ToString(snp_Current_Contact["contact_suffix"])}")}";
					if (Strings.Len(($"{Convert.ToString(snp_Current_Contact["contact_title"])}").Trim()) > 0)
					{
						TempPrimaryContact = $"{TempPrimaryContact},{Convert.ToString(snp_Current_Contact["contact_title"]).Trim()}";
					}
					TempPrimaryContact = $"{TempPrimaryContact} (ID={($"{Convert.ToString(snp_Current_Contact["contact_id"])}").Trim()})";

					currentContactCompIdID = Convert.ToInt32(snp_Current_Contact["contact_comp_id"]);

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!(Convert.IsDBNull(snp_Current_Contact["contact_email_address"])))
					{
						FormBox.Tag = Convert.ToString(snp_Current_Contact["contact_email_address"]);
					}
					else
					{
						FormBox.Tag = "";
					}

					FormBox.AddItem(TempPrimaryContact);
					FormBox.SetItemData(FormBox.Items.Count - 1, Convert.ToInt32(snp_Current_Contact["contact_id"]));


					while(!snp_Current_Contact.EOF)
					{

						ErrorMsg = "Add Phone Numbers to ListBox";

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!(Convert.IsDBNull(snp_Current_Contact["pnum_number_full"]) && Convert.IsDBNull(snp_Current_Contact["pnum_type"])))
						{
							phoneline = $"{($"{Convert.ToString(snp_Current_Contact["pnum_type"])} ").Trim()}: ";
							phoneline = $"{phoneline}{($"{Convert.ToString(snp_Current_Contact["pnum_number_full"])} ").Trim()} ";

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(snp_Current_Contact["pnum_ext"]))
							{
								phoneline = $"{phoneline}Ext:{Convert.ToString(snp_Current_Contact["pnum_ext"]).Trim()}";
							}

						}
						else
						{
							phoneline = "";
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snp_Current_Contact["contact_email_address"]))
						{
							contact_email = Convert.ToString(snp_Current_Contact["contact_email_address"]).Trim();
						}

						if (phoneline != "")
						{
							FormBox.AddItem(phoneline);
							FormBox.SetItemData(FormBox.Items.Count - 1, Convert.ToInt32(snp_Current_Contact["contact_id"]));
						}

						snp_Current_Contact.MoveNext();
					};

					snp_Current_Contact.Close();

				}
				else
				{

					if (snp_Current_Contact.State == ConnectionState.Open)
					{
						snp_Current_Contact.Close();
					}

					snp_Current_Contact = null;

					// if this is passed in, it means they checked the show all button, so we are going to show all
					if (comp_id_temp > 0)
					{
					}
					else
					{
						FormBox.AddItem("This Contact has been removed/replaced by another user.  Please exit and re-enter this form to see the new contact.");
						return;
					}

				}

				// moved up from below - to fix it being displayed below "all contacts is checked"
				if (contact_email.Trim() != "")
				{
					FormBox.AddItem($"Email: {contact_email}");
				}


				ErrorMsg = "other contact";

				if (Details)
				{
					// GET OTHER CONTACT INFORMATION

					Query = "SELECT Contact.*, ptype_seq_no, pnum_number_full, pnum_type ";
					Query = $"{Query}FROM Contact WITH(NOLOCK) LEFT OUTER JOIN ";
					Query = $"{Query}Phone_Numbers WITH(NOLOCK) ON Contact.contact_id = Phone_Numbers.pnum_contact_id ";
					Query = $"{Query}AND Contact.contact_journ_id = Phone_Numbers.pnum_journ_id ";
					Query = $"{Query}FULL OUTER JOIN Phone_Type WITH(NOLOCK) ON Phone_Numbers.pnum_type = Phone_Type.ptype_name ";

					if (comp_id_temp > 0)
					{
						Query = $"{Query}WHERE contact_comp_id = {($"{comp_id_temp.ToString()} ").Trim()} ";
					}
					else
					{
						Query = $"{Query}WHERE contact_comp_id = {($"{currentContactCompIdID.ToString()} ").Trim()} ";
					}

					//UPGRADE_WARNING: (1068) PassedContactID of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
					Query = $"{Query}and contact_id not in ({($"{Convert.ToString(PassedContactID)} ").Trim()},0) "; //added contact_id > 0 check
					//UPGRADE_WARNING: (1068) PassedJournID of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
					Query = $"{Query}and contact_journ_id = {Convert.ToString(PassedJournID)}  and contact_active_flag = 'Y' "; //aey 7/30/04 contact_active_flag
					Query = $"{Query}ORDER BY contact_last_name, contact_id";

					ErrorMsg = "Get Other Details";

					// rtw - changed to ado on 10/21/2002
					snp_Current_ContactInfo.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
					PreviousContactID = 0;

					if (!(snp_Current_ContactInfo.BOF && snp_Current_ContactInfo.EOF))
					{

						snp_Current_ContactInfo.MoveFirst();

						FormBox.AddItem(" ");
						FormBox.AddItem("***** OTHER CONTACT(S) *****");
						FormBox.AddItem("NAME, TITLE                    PHONE");

						while(!snp_Current_ContactInfo.EOF)
						{

							ErrorMsg = "Add Other Details to ListBox";

							if (PreviousContactID != StringsHelper.ToDoubleSafe(($"{Convert.ToString(snp_Current_ContactInfo["contact_id"])}").Trim()))
							{
								repline = new StringBuilder($"{($"{($"{Convert.ToString(snp_Current_ContactInfo["contact_first_name"])} ").Trim()} {($"{Convert.ToString(snp_Current_ContactInfo["contact_last_name"])} ").Trim()}")}{((Strings.Len(($"{Convert.ToString(snp_Current_ContactInfo["contact_suffix"])}").Trim()) == 0) ? "" : $" {Convert.ToString(snp_Current_ContactInfo["contact_suffix"])}")}");
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(snp_Current_ContactInfo["Contact_Title"]))
								{
									repline.Append($",{($"{Convert.ToString(snp_Current_ContactInfo["Contact_Title"])} ").Trim()}");
								}
								PreviousContactID = Convert.ToInt32(Conversion.Val(($"{Convert.ToString(snp_Current_ContactInfo["contact_id"])}").Trim()));
							}

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!(Convert.IsDBNull(snp_Current_ContactInfo["pnum_number_full"]) && Convert.IsDBNull(snp_Current_ContactInfo["pnum_type"])))
							{

								phoneline = $"{($"{Convert.ToString(snp_Current_ContactInfo["pnum_type"])} ").Trim()}: ";
								phoneline = $"{phoneline}{($"{Convert.ToString(snp_Current_ContactInfo["pnum_number_full"])} ").Trim()}  ";

							}
							else
							{

								phoneline = "";

							}

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(snp_Current_ContactInfo["contact_email_address"]))
							{
								contact_email_address = Convert.ToString(snp_Current_ContactInfo["contact_email_address"]);
							}
							else
							{
								contact_email_address = "";
							}



							finalline = $"{modAdminCommon.gbl_LeftAdjust(repline.ToString().Substring(0, Math.Min(30, repline.ToString().Length)), "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@")} {phoneline} {contact_email_address}";
							FormBox.AddItem(finalline);
							FormBox.SetItemData(FormBox.Items.Count - 1, Convert.ToInt32(snp_Current_ContactInfo["contact_id"]));
							finalline = "";
							snp_Current_ContactInfo.MoveNext();
							repline = new StringBuilder("  ");

						};

						snp_Current_ContactInfo.Close();

					}

					if (snp_Current_ContactInfo.State == ConnectionState.Open)
					{
						snp_Current_ContactInfo.Close();
					}

				}

				if (snp_Current_Contact.State == ConnectionState.Open)
				{
					snp_Current_Contact.Close();
				}

				snp_Current_Contact = null;

				if (snp_Current_ContactInfo.State == ConnectionState.Open)
				{
					snp_Current_ContactInfo.Close();
				}

				snp_Current_ContactInfo = null;


				ErrorMsg = "journ >0 ";
				//UPGRADE_WARNING: (1068) PassedJournID of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
				if (Convert.ToInt32(PassedJournID) == 0)
				{
					ErrorMsg = "Check Confirmation Dates";

					//UPGRADE_WARNING: (1068) PassedContactID of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
					if (Contact_Needs_Confirmation(currentContactCompIdID, Convert.ToInt32(PassedContactID)))
					{
						FormBox.BackColor = Color.FromArgb(255, 192, 192);
					}
					else
					{
						FormBox.BackColor = Color.FromArgb(224, 224, 224);
					}
				}
				else
				{
					FormBox.BackColor = Color.FromArgb(224, 224, 224);
				}

				FormBox.Refresh();
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				ErrorMsg = $"{excep.Message} - {ErrorMsg} {Information.Err().Number.ToString()}";

				if (snp_Current_Contact.State == ConnectionState.Open)
				{
					snp_Current_Contact.Close();
				}


				if (snp_Current_ContactInfo.State == ConnectionState.Open)
				{
					snp_Current_ContactInfo.Close();
				}


				modAdminCommon.Report_Error($"Build_Contact_Info_Error: [{ErrorMsg}]");
			}

		}

		internal static void Record_CompanyContact_Aircraft_Transmits(string Record_Type, string Record_Action, int inCompany_ID, int inContact_ID, int inJournal_ID, ref string[] arrTransmitFields, int inAC_ID = 0, string inContact_Type = "", string inFractOwner_Id = "")
		{

			string stringprefix = "";
			try
			{

				string Query = ""; // strings used to define queries to database
				string Query1 = "";
				ADORecordSetHelper adoCRef = new ADORecordSetHelper(); // Snapshot aey 6/14/04                                ' record set for selecting sequence numbers for each aircraft
				ADORecordSetHelper ado_ACList = new ADORecordSetHelper(); // record set for selecting aircraft associated with each company/contact
				string[] arrTempChangedFields = null;
				int total_changes = 0;
				bool bTransmit = false;

				Query = "SELECT DISTINCT cref_ac_id, ac_amod_id, ac_ser_no_full, ac_forsale_flag ";
				Query = $"{Query}FROM Aircraft_Reference WITH(NOLOCK) INNER JOIN Aircraft WITH(NOLOCK) ON cref_ac_id = ac_id AND cref_journ_id = ac_journ_id ";

				if (Record_Type == "Company")
				{
					Query = $"{Query}WHERE (cref_comp_id = {inCompany_ID.ToString()}) ";
				}
				else
				{
					Query = $"{Query}WHERE (cref_contact_id = {inContact_ID.ToString()}) ";
				}

				if (inAC_ID > 0)
				{
					Query = $"{Query}AND (cref_ac_id = {inAC_ID.ToString()}) ";
				}

				Query = $"{Query}AND (cref_journ_id = {inJournal_ID.ToString()}) ";
				Query = $"{Query}AND (cref_transmit_seq_no < 99) ";
				Query = $"{Query}ORDER BY cref_ac_id, ac_amod_id, ac_ser_no_full, ac_forsale_flag ";

				// 08/25/2006 - By David D. Cruger; Changed to adOpenForwardOnly and adLockReadyOnly
				ado_ACList.CursorLocation = CursorLocationEnum.adUseClient;
				ado_ACList.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(ado_ACList.BOF && ado_ACList.EOF))
				{
					stringprefix = "";


					while(!ado_ACList.EOF)
					{
						total_changes = 0;
						stringprefix = "";

						// get a list of transmit sequence numbers for the current aircraft
						// that apply to this company

						Query1 = "select cref_transmit_seq_no,cref_contact_id from Aircraft_Reference WITH(NOLOCK)";
						Query1 = $"{Query1}where cref_ac_id={Convert.ToString(ado_ACList["cref_ac_id"])} ";
						if (Record_Type == "Company")
						{
							Query1 = $"{Query1}and cref_comp_id={inCompany_ID.ToString()} ";
						}
						else
						{
							Query1 = $"{Query1}and cref_contact_id={inContact_ID.ToString()} ";
						}
						Query1 = $"{Query1}and cref_journ_id={inJournal_ID.ToString()} ";
						Query1 = $"{Query1}and cref_transmit_seq_no < 99";

						adoCRef.Open(Query1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

						if (!(adoCRef.BOF && adoCRef.EOF))
						{

							stringprefix = "";
							arrTempChangedFields = new string[]{""};


							while(!adoCRef.EOF)
							{

								switch(Convert.ToInt32(adoCRef["cref_transmit_seq_no"]))
								{
									case 1 : 
										stringprefix = "owner_"; 
										break;
									case 2 : 
										stringprefix = "operator_"; 
										break;
									case 3 : 
										stringprefix = "chp_"; 
										break;
									case 4 : 
										stringprefix = "excbrk1_"; 
										break;
									case 5 : 
										stringprefix = "excbrk2_"; 
										break;
									case 6 : 
										stringprefix = "alt1_"; 
										break;
									case 7 : 
										stringprefix = "alt2_"; 
										break;
									case 8 : 
										stringprefix = "alt3_"; 
										break;
									case 9 : 
										stringprefix = "owner_regas_"; 
										break;
									case 10 : 
										stringprefix = "purchaser_"; 
										break;
									case 11 : 
										stringprefix = "purchaser_regas_"; 
										break;
								}

								int tempForEndVar = arrTransmitFields.GetUpperBound(0) - 1;
								for (int n = 0; n <= tempForEndVar; n++)
								{ // used to be changecount then number of company changes in array
									if (arrTransmitFields.GetUpperBound(0) == 0)
									{
										break;
									}
									if (arrTransmitFields[n].IndexOf("contact_phone") >= 0 || arrTransmitFields[n].IndexOf("contact_email_address") >= 0)
									{
										if (Record_Type == "Company" && Conversion.Val(($"{Convert.ToString(adoCRef["cref_contact_id"])}").Trim()) == 0)
										{
											total_changes++;
											arrTempChangedFields = ArraysHelper.RedimPreserve(arrTempChangedFields, new int[]{arrTempChangedFields.GetUpperBound(0) + 2});
											arrTempChangedFields[arrTempChangedFields.GetUpperBound(0)] = $"{stringprefix}{arrTransmitFields[n]}";
										}
										else if (arrTransmitFields[n] != "")
										{ 
											total_changes++;
											arrTempChangedFields = ArraysHelper.RedimPreserve(arrTempChangedFields, new int[]{arrTempChangedFields.GetUpperBound(0) + 2});
											arrTempChangedFields[arrTempChangedFields.GetUpperBound(0)] = $"{stringprefix}{arrTransmitFields[n]}";
										}
									}
									else if (arrTransmitFields[n] != "")
									{ 
										total_changes++;
										arrTempChangedFields = ArraysHelper.RedimPreserve(arrTempChangedFields, new int[]{arrTempChangedFields.GetUpperBound(0) + 2});

										if (($"{stringprefix}{arrTransmitFields[n]}") != "excbrk1_comp_address")
										{
											arrTempChangedFields[arrTempChangedFields.GetUpperBound(0)] = $"{stringprefix}{arrTransmitFields[n]}";
										}

									}
								}
								adoCRef.MoveNext();
							}; // next aircraft transmit sequence number
							adoCRef.Close();
						} // end of sequence number list
						adoCRef = null;

						if (arrTempChangedFields.GetUpperBound(0) > 0)
						{ // We may throw away all the phone number changes if they are associated to a contact

							modAdminCommon.Record_Transmit(Convert.ToString(ado_ACList["ac_ser_no_full"]), Convert.ToInt32(ado_ACList["cref_ac_id"]), inJournal_ID, Convert.ToInt32(ado_ACList["ac_amod_id"]), "Aircraft", "Change", ref arrTempChangedFields);
							if (Convert.ToString(ado_ACList["ac_forsale_flag"]).Trim().ToUpper() == "Y")
							{
								modAdminCommon.Record_Transmit(Convert.ToString(ado_ACList["ac_ser_no_full"]), Convert.ToInt32(ado_ACList["cref_ac_id"]), inJournal_ID, Convert.ToInt32(ado_ACList["ac_amod_id"]), "Available", "Change", ref arrTempChangedFields);
							}

						}

						ado_ACList.MoveNext();
					}; // get next aircraft
					ado_ACList.Close();
				} // end of aircraft list
				ado_ACList = null;

				if (Conversion.Val(inFractOwner_Id.Trim()) > 0)
				{ // record fractional owner transmit if necessary
					modAdminCommon.Record_Transmit(" ", Convert.ToInt32(Conversion.Val($"{inFractOwner_Id}")), 0, 0, "Fractional Owner", "Change", ref arrTempChangedFields, inCompany_ID);
				}
			}
			catch (Exception e)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				if (Information.Err().Number == 9)
				{
					arrTransmitFields = new string[]{""};
					//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1065
					UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
				}

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Record_CompanyContact_Aircraft_Transmits_Error: {Information.Err().Number.ToString()} {e.Message} {stringprefix}");
				return;
			}

		}



		internal static bool Delete_Aircraft_History(int Passed_AC_ID, int Passed_Journ_ID)
		{
			bool result = false;
			string strError = "";
			try
			{

				string Query = "";
				int RememberTimeout = 0;
				// this must be wrapped with begin and commit transactions
				Cursor.Current = Cursors.WaitCursor;
				result = false;

				strError = "start";
				if (Passed_Journ_ID == 0)
				{
					Query = $"select * from Journal,Journal_Category where journ_ac_id={Passed_AC_ID.ToString()} and jcat_subcategory_code=journ_subcategory_code and jcat_category_code='AH' ";
					if (modAdminCommon.Exist(Query))
					{
						strError = "event";
						modAdminCommon.Record_Event("DeleteAircraftHist", "Tried to delete an aircraft with important journal entries.");
						MessageBox.Show("Tried to delete an aircraft with important journal entries.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						return false;
					} // IF INFORMATION ATTACHED
					// *****************************************************
					// DELETE EVERYTHING RELATED TO THIS AIRCRAFT
					strError = "on acid";
					Query = $"EXEC HomebaseDeleteAllRecordsBasedOnACId {Passed_AC_ID.ToString()}";
					RememberTimeout = UpgradeHelpers.DB.DbConnectionHelper.GetCommandTimeOut(modAdminCommon.ADODB_Trans_conn);
					UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(modAdminCommon.ADODB_Trans_conn, 50000);
					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'ADODB.ExecuteOptionEnum' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();
					UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(modAdminCommon.ADODB_Trans_conn, RememberTimeout);
				}
				else
				{
					// JOURN ID > 0
					strError = "on jid";
					// ******************************************
					// DELETE EVERYTHING RELATED TO THIS JOURNAL ENTRY
					Query = $"EXEC HomebaseDeleteAllRecordsBasedOnJournalId {Passed_Journ_ID.ToString()}";

					RememberTimeout = UpgradeHelpers.DB.DbConnectionHelper.GetCommandTimeOut(modAdminCommon.ADODB_Trans_conn);
					UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(modAdminCommon.ADODB_Trans_conn, 50000);
					DbCommand TempCommand_2 = null;
					TempCommand_2 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
					TempCommand_2.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'ADODB.ExecuteOptionEnum' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand_2.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
					TempCommand_2.ExecuteNonQuery();
					UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(modAdminCommon.ADODB_Trans_conn, RememberTimeout);

					if (!modAdminCommon.Record_Delete_Log_Entry("Transaction", Passed_AC_ID, Passed_Journ_ID))
					{
						result = false;
						modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
						Cursor.Current = CursorHelper.CursorDefault;
						return result;
					} // IF NOT DELETE LOG ENTRY
				} // IF CURRENT AIRCRAFT - JOURN ID = 0

				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);

				Cursor.Current = CursorHelper.CursorDefault;

				return true;
			}
			catch (System.Exception excep)
			{

				Cursor.Current = CursorHelper.CursorDefault;
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Delete_Aircraft_History_Error: {Passed_AC_ID.ToString()} {Passed_Journ_ID.ToString()} {Information.Err().Number.ToString()} {excep.Message} {strError} {excep.Source}");
				return false;
			}
		}

		internal static void Combine_Contact(int inComp_ID, int Old_Contact_ID, int New_Contact_ID)
		{
			//******************************************************************************************
			//* Note: VBC id'd the following unreferenced items and handled them as described:         *
			//*                                                                                        *
			//* Local Variables (Removed)                                                              *
			//*  snp_NewContact                snpOldPnum                                              *
			//******************************************************************************************

			try
			{

				string Query = "";
				int Counter = 0;
				ADORecordSetHelper snp_OldContact = new ADORecordSetHelper();


				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Combining Aircraft References...", Color.Blue);

				//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				// Move all Aircraft References - Including historical references
				Query = "UPDATE Aircraft_Reference ";
				Query = $"{Query}SET cref_contact_id = {New_Contact_ID.ToString()} ";
				Query = $"{Query}WHERE cref_contact_id={Old_Contact_ID.ToString()} ";
				//Query = Query & "  AND cref_journ_id = " & Trim("" & snp_OldContact!contact_journ_id) & " "
				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'ADODB.ExecuteOptionEnum' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();


				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Combining Company References...", Color.Blue);

				//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				// Move all Company References - Including historical references
				Query = "UPDATE Company_Reference ";
				Query = $"{Query}SET compref_contact_id = {New_Contact_ID.ToString()} ";
				Query = $"{Query}WHERE compref_contact_id={Old_Contact_ID.ToString()} ";
				//Query = Query & "  AND compref_journ_id = " & Trim("" & snp_OldContact!contact_journ_id) & " "
				DbCommand TempCommand_2 = null;
				TempCommand_2 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
				TempCommand_2.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'ADODB.ExecuteOptionEnum' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand_2.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
				TempCommand_2.ExecuteNonQuery();

				Query = "UPDATE Company_Reference ";
				Query = $"{Query}SET compref_rel_contact_id = {New_Contact_ID.ToString()} ";
				Query = $"{Query}WHERE compref_rel_contact_id={Old_Contact_ID.ToString()} ";
				//Query = Query & "  AND compref_journ_id = " & Trim("" & snp_OldContact!contact_journ_id) & " "
				DbCommand TempCommand_3 = null;
				TempCommand_3 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_3);
				TempCommand_3.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'ADODB.ExecuteOptionEnum' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand_3.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_3);
				TempCommand_3.ExecuteNonQuery();


				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Combining Share References...", Color.Blue);

				//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				// Move all Share References
				Query = "UPDATE Share_Reference ";
				Query = $"{Query}SET sref_contact_id = {New_Contact_ID.ToString()} ";
				Query = $"{Query}WHERE sref_contact_id={Old_Contact_ID.ToString()} ";
				DbCommand TempCommand_4 = null;
				TempCommand_4 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_4);
				TempCommand_4.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'ADODB.ExecuteOptionEnum' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand_4.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_4);
				TempCommand_4.ExecuteNonQuery();


				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Combining Wanteds...", Color.Blue);

				//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				// Move all wanted records
				Query = "UPDATE Aircraft_Model_Wanted ";
				Query = $"{Query}SET amwant_contact_id = {New_Contact_ID.ToString()}, ";
				Query = $"{Query}amwant_action_date = NULL ";
				Query = $"{Query}WHERE amwant_contact_id = {Old_Contact_ID.ToString()} ";
				//Query = Query & "  AND amwant_journ_id = " & Trim("" & snp_OldContact!contact_journ_id)
				DbCommand TempCommand_5 = null;
				TempCommand_5 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_5);
				TempCommand_5.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'ADODB.ExecuteOptionEnum' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand_5.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_5);
				TempCommand_5.ExecuteNonQuery();


				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Combining Subscriptions...", Color.Blue);

				//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				// Update the subscription table
				//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				Query = "UPDATE Subscription ";
				Query = $"{Query}SET sub_contact_id = {New_Contact_ID.ToString()}, ";
				Query = $"{Query}sub_action_date = NULL ";
				Query = $"{Query}WHERE sub_contact_id = {Old_Contact_ID.ToString()}";
				DbCommand TempCommand_6 = null;
				TempCommand_6 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_6);
				TempCommand_6.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'ADODB.ExecuteOptionEnum' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand_6.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_6);
				TempCommand_6.ExecuteNonQuery();

				//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				// Update the subscription_login table
				//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				Query = "UPDATE Subscription_Login ";
				Query = $"{Query}SET sublogin_contact_id = {New_Contact_ID.ToString()}, ";
				Query = $"{Query} sublogin_action_date = NULL "; // clear the action date - MSW - 11/3/24
				Query = $"{Query}WHERE sublogin_contact_id = {Old_Contact_ID.ToString()}";
				DbCommand TempCommand_7 = null;
				TempCommand_7 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_7);
				TempCommand_7.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'ADODB.ExecuteOptionEnum' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand_7.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_7);
				TempCommand_7.ExecuteNonQuery();


				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Combining Contact Phone Numbers...", Color.Blue);

				//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				// move contact phone numbers
				//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				Query = $"update Phone_Numbers set pnum_contact_id = {New_Contact_ID.ToString()}";
				Query = $"{Query}WHERE pnum_comp_id = {inComp_ID.ToString()}";
				Query = $"{Query} AND  pnum_contact_id = {Old_Contact_ID.ToString()}";
				//Query = Query & " AND pnum_journ_id = " & Trim("" & snp_OldContact!contact_journ_id)
				DbCommand TempCommand_8 = null;
				TempCommand_8 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_8);
				TempCommand_8.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'ADODB.ExecuteOptionEnum' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand_8.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_8);
				TempCommand_8.ExecuteNonQuery();


				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Getting Historical Contact References ...", Color.Blue);

				//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				// get all contact records for company to be removed (including historical).
				Query = "SELECT contact_id, contact_journ_id ";
				Query = $"{Query}FROM Contact ";
				Query = $"{Query}WHERE contact_id = {Old_Contact_ID.ToString()}";
				snp_OldContact.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);
				if (!(snp_OldContact.BOF && snp_OldContact.EOF))
				{
					snp_OldContact.MoveFirst();
					Counter = 1;

					while(!snp_OldContact.EOF)
					{
						modStatusBar.Update_Status_Bar(modAdminCommon.SB, $"Recording Delete Log Entry For Contact ID {Convert.ToString(snp_OldContact["contact_id"])} - JournID: {Convert.ToString(snp_OldContact["contact_journ_id"])} Counter: {Counter.ToString()}", Color.Blue);

						//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
						// ADD DELETE WEB RECORD
						modAdminCommon.Record_Delete_Log_Entry("Contact", Old_Contact_ID, Convert.ToInt32(snp_OldContact["contact_journ_id"]));
						snp_OldContact.MoveNext(); // get next historical company record
						Counter++;
					}; // historical company records

				}

				snp_OldContact.Close();
				snp_OldContact = null;

				//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				// remove the old company record
				Query = "DELETE FROM Contact ";
				Query = $"{Query}WHERE contact_comp_id = {inComp_ID.ToString()}";
				Query = $"{Query} AND contact_id = {Old_Contact_ID.ToString()}";
				// Query = Query & " AND contact_journ_id = " & Trim("" & snp_OldContact!contact_journ_id)
				DbCommand TempCommand_9 = null;
				TempCommand_9 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_9);
				TempCommand_9.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'ADODB.ExecuteOptionEnum' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand_9.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_9);
				TempCommand_9.ExecuteNonQuery();

				//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				// Move All Company Journal Entries
				Query = "UPDATE Journal ";
				Query = $"{Query}SET journ_contact_id={New_Contact_ID.ToString()}, ";
				Query = $"{Query}journ_action_date = '1/1/1900' "; //6/25/04 aey
				Query = $"{Query}WHERE journ_contact_id={Old_Contact_ID.ToString()}";
				DbCommand TempCommand_10 = null;
				TempCommand_10 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_10);
				TempCommand_10.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'ADODB.ExecuteOptionEnum' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand_10.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_10);
				TempCommand_10.ExecuteNonQuery();
			}
			catch
			{

				modAdminCommon.Report_Error("Combine_Company_Error: Cound not complete company update. ");
				modAdminCommon.ADO_Transaction("RollbackTrans");
				return;
			}
		}


		internal static int Fractional_Owner(int inComp_ID)
		{
			int result = 0;
			try
			{
				string Query = "";
				ADORecordSetHelper snp_Fown_ID = new ADORecordSetHelper(); //8/11/05 aey dao.Recordset

				result = 0;

				Query = $"SELECT comp_fractowr_id FROM Company WITH(NOLOCK) WHERE comp_id = {inComp_ID.ToString()} and comp_journ_id = 0";

				snp_Fown_ID = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(snp_Fown_ID.Fields) && !(snp_Fown_ID.BOF && snp_Fown_ID.EOF))
				{
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snp_Fown_ID.Fields))
					{
						if (Convert.ToInt32(snp_Fown_ID["comp_fractowr_id"]) > 0)
						{
							result = Convert.ToInt32(snp_Fown_ID["comp_fractowr_id"]);
							snp_Fown_ID.Close();
						}
					}
				}

				snp_Fown_ID = null;

				return result;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"fractional_owner_Error ({Information.Err().Number.ToString()}) {excep.Message}", "modCommon(FRACTOWN)");
				return result;
			}
		}

		internal static int Get_Next_Fractional_Owner_ID()
		{
			int result = 0;
			try
			{

				ADORecordSetHelper ado_nextid = new ADORecordSetHelper();
				string Query = "";

				result = 0;
				//Query = "EXEC HomebaseQueryGetLastFOwnerID"
				// CHANGED - RTW - 2/1/2012 - REMOVED USE OF STORED PROCEDURE AND REPLACED WITH REAL QUERY
				Query = "select max(comp_fractowr_id) as max_fractowr_id from company with (NOLOCK) where comp_journ_id=0";

				ado_nextid.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(ado_nextid.BOF && ado_nextid.EOF))
				{
					if (Convert.ToDouble(ado_nextid["max_fractowr_id"]) > 0)
					{
						result = Convert.ToInt32(Conversion.Val(Convert.ToString(ado_nextid["max_fractowr_id"])) + 1);
					}
					else
					{
						result = 1;
					}
				}

				ado_nextid.Close();
				ado_nextid = null;
				return result;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Get_Next_Fractional_Owner_ID_Error ({Information.Err().Number.ToString()}) {excep.Message}", "modCommon(FRACTOWN)");
				return 0;
			}
		}

		internal static string Company_Business_Type(int inComp_ID, int inJourn_ID)
		{

			string result = "";
			string Query = "";
			try
			{

				ADORecordSetHelper snp_Bus_Type = new ADORecordSetHelper(); //8/11/05 aey Snapshot

				Query = "select comp_business_type from Company WITH(NOLOCK) ";
				Query = $"{Query}where comp_id={inComp_ID.ToString()} ";
				Query = $"{Query}and comp_journ_id={inJourn_ID.ToString()}";

				snp_Bus_Type.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_Bus_Type.BOF && snp_Bus_Type.EOF))
				{
					result = Convert.ToString(snp_Bus_Type["comp_business_type"]);
				}
				else
				{
					result = "0";
				}
				snp_Bus_Type.Close();
				snp_Bus_Type = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"Company Business Type: {excep.Message}-{Query}");
			}
			return result;
		}

		internal static string Transaction_Code(string inPrefix, int inJourn_ID)
		{

			string result = "";
			string Query = "";
			ADORecordSetHelper snpTransType = new ADORecordSetHelper(); //8/11/05 aey
			int From_Comp_ID = 0; // company id of the from company, seller, lessor, etc
			int To_Comp_ID = 0; // company id of the to company, purchaser, lessee, etc.

			try
			{
				modAdminCommon.Transaction_Subject = ""; // clear the transaction subject
				switch(inPrefix)
				{
					case "WS" : case "SS" : 
						// return transaction type for seller and purchaser 
						From_Comp_ID = Reference_Company("95", inJourn_ID); 
						To_Comp_ID = Reference_Company("96", inJourn_ID); 
						result = $"{inPrefix}{Company_Business_Type(From_Comp_ID, inJourn_ID)}{Company_Business_Type(To_Comp_ID, inJourn_ID)}"; 
						break;
					case "FS" : 
						// return transaction type for fraction seller and fraction purchaser 
						From_Comp_ID = Reference_Company("69", inJourn_ID); 
						To_Comp_ID = Reference_Company("70", inJourn_ID); 
						result = $"{inPrefix}{Company_Business_Type(From_Comp_ID, inJourn_ID)}{Company_Business_Type(To_Comp_ID, inJourn_ID)}"; 
						break;
					case "FC" : 
						// return transaction type for previous owner and foreclosed by 
						From_Comp_ID = Reference_Company("56", inJourn_ID); 
						To_Comp_ID = Reference_Company("52", inJourn_ID); 
						result = $"{inPrefix}{Company_Business_Type(From_Comp_ID, inJourn_ID)}{Company_Business_Type(To_Comp_ID, inJourn_ID)}"; 
						break;
					case "SZ" : 
						// return transaction type for previous owner and seized by 
						From_Comp_ID = Reference_Company("56", inJourn_ID); 
						To_Comp_ID = Reference_Company("51", inJourn_ID); 
						result = $"{inPrefix}{Company_Business_Type(From_Comp_ID, inJourn_ID)}{Company_Business_Type(To_Comp_ID, inJourn_ID)}"; 
						break;
					default:
						result = "BAD"; 
						break;
				}

				Query = "SELECT jcat_subcategory_name  FROM Journal_Category WITH(NOLOCK) ";
				Query = $"{Query}WHERE jcat_subcategory_code = '{result}'";

				snpTransType.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpTransType.BOF && snpTransType.EOF))
				{
					result = $"{result}*{($"{Convert.ToString(snpTransType["jcat_subcategory_name"])}").Trim()} From {GetCompanyName(From_Comp_ID, inJourn_ID)} To {GetCompanyName(To_Comp_ID, inJourn_ID)}";
				}
				else
				{
					result = $"{result}*";
				}

				snpTransType.Close();
				snpTransType = null;

				return result;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Transaction_Code_Error ({Information.Err().Number.ToString()}) {excep.Message}", "modCommon (Transaction)");
				return result;
			}
		}

		internal static int Reference_Company(string in_Reference_Type, int inJourn_ID)
		{

			int result = 0;
			string Query = "";
			try
			{

				ADORecordSetHelper snp_Ref_ID = new ADORecordSetHelper(); //8/11/05 aey Snapshot

				Query = "select comp_id from Company WITH(NOLOCK), Aircraft_Reference WITH(NOLOCK) ";
				Query = $"{Query}where (comp_id=cref_comp_id and comp_journ_id=cref_journ_id) ";
				Query = $"{Query}and cref_contact_type='{in_Reference_Type}' ";
				Query = $"{Query}and comp_journ_id={inJourn_ID.ToString()}";
				snp_Ref_ID.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_Ref_ID.BOF && snp_Ref_ID.EOF))
				{
					result = Convert.ToInt32(snp_Ref_ID["comp_id"]);
				}
				else
				{
					result = 0;
				}
				snp_Ref_ID.Close();
				snp_Ref_ID = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"Function Reference Company: {excep.Message}-{Query}");
			}
			return result;
		}



		internal static int Get_Next_PC_Record_Key_Hold()
		{

			int result = 0;
			try
			{
				ADORecordSetHelper ado_NextJid = new ADORecordSetHelper();
				string Query = "";
				result = 0;
				// OLD QUERY
				//Query = "EXEC HomebaseQueryGetLastRecKey"
				// NEW QUERY
				Query = "EXEC HomebaseQueryGetNextPCRecKey";

				ado_NextJid.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);
				//ado_NextJid.NextRecordset
				if (!(ado_NextJid.BOF && ado_NextJid.EOF))
				{
					// ado_NextJid.MoveFirst
					if (Convert.ToDouble(ado_NextJid["next_pcreckey"]) > 0)
					{
						result = Convert.ToInt32(ado_NextJid["next_pcreckey"]);
					}
					else
					{
						result = 1;
					}
				}
				ado_NextJid.Close();
				ado_NextJid = null;
			}
			catch
			{
				result = 0;
			}
			return result;
		}

		internal static string build_common_sp_string(string string_field_name, string string_field_value)
		{

			string result = "";
			result = $"{string_field_name} = '{modAdminCommon.Fix_Quote(CleanSpecial(string_field_value)).Trim()}'";

			// leave source last
			if (string_field_name.Trim() != "@inSource")
			{
				result = $"{result},";
			}

			return result;
		}

		internal static int Get_Next_PC_Record_Key()
		{

			int result = 0;
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			System.DateTime dtNow = DateTime.FromOADate(0);
			int lResults = 0;

			try
			{

				lResults = 0;

				dtNow = DateTime.Parse(modAdminCommon.GetSystemDateTime());

				strQuery1 = "SELECT * FROM Journal_PCRecKey WHERE (jpck_pcreckey = -1)";

				rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockPessimistic);

				rstRec1.AddNew();
				rstRec1["jpck_entered_date"] = dtNow;
				rstRec1.Update();

				lResults = Convert.ToInt32(rstRec1["jpck_pcreckey"]);

				rstRec1.Close();
				rstRec1 = null;


				return lResults;
			}
			catch
			{

				result = 0;
			}
			return result;
		} // Get_Next_PC_Record_Key

		internal static int Get_Next_Fractional_Sold_ID(int in_Fractional_Owner_ID)
		{

			int result = 0;
			try
			{
				ADORecordSetHelper ado_nextid = new ADORecordSetHelper();
				string Query = "";
				result = 0;
				//Query = "EXEC HomebaseQueryGetLastFOwnerSoldID " & CStr(in_Fractional_Owner_ID)
				// RTW - CHANGED - 2/1/2012 - MODIFIED TO USE QUERY INSTEAD OF STORED PROCEDURE
				Query = $"select max(journ_fractsld_id) as max_sold_id from Journal with (NOLOCK) where journ_fractowr_id={in_Fractional_Owner_ID.ToString()}";
				ado_nextid.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(ado_nextid.BOF && ado_nextid.EOF))
				{
					if (Convert.ToDouble(ado_nextid["max_sold_id"]) > 0)
					{
						result = Convert.ToInt32(Conversion.Val(Convert.ToString(ado_nextid["max_sold_id"])) + 1);
					}
					else
					{
						result = 1;
					}
				}
				ado_nextid.Close();
				ado_nextid = null;
			}
			catch
			{
				result = 0;
			}
			return result;
		}

		internal static void ViewFile(string PassedFileName)
		{

			//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			//VB.Global.Load(frm_WebReport.DefInstance);
			frm_WebReport.DefInstance.PassedFileName = PassedFileName;
			frm_WebReport.DefInstance.WhichReport = "View Document";
			frm_WebReport.DefInstance.Show();

		}

		internal static void Remove_Duplicate_Phone_Numbers(int inComp_ID, int inContact_ID)
		{

			string strError = "";
			try
			{
				ADORecordSetHelper snpCList = new ADORecordSetHelper();

				string Query = "";

				strError = $"SELECT A LIST OF DUPLICATE COMPANY PHONE NUMBERS -SP:{inComp_ID.ToString()},{inContact_ID.ToString()}";
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, $"Removing Duplicate Phone Numbers, Contact ID: {inContact_ID.ToString()} Company ID: {inComp_ID.ToString()}", Color.Blue);

				Query = $"EXEC HomebaseRemoveDuplicatePhoneNumbersonCompanyContact {Conversion.Val($"{inComp_ID.ToString()}").ToString()},{Conversion.Val($"{inContact_ID.ToString()}").ToString()}";
				snpCList.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
				snpCList = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"Remove_Duplicate_Phone_Numbers_Error:{strError} {excep.Message}");
			}

		}

		internal static bool UnAttachFile(string inLog_File, int PassedModelID, int PassedJournID, int PassedJournSeqNo, int PassedACID)
		{

			bool result = false;
			Object fso = new Object();
			string strSourceFile = ""; // THE NAME OF THE FILE SERVER FILE
			string FileType = ""; // TYPE OF FILE BEING UNATTACHED FROM THE SERVER
			string Extension = ""; // EXTENSION OF THE FILE BEING UNATTACHED FROM THE SERVER
			bool bResults = false;

			try
			{

				bResults = false;

				// RTW - 3/25/2004 - MODIFIED TO USE NEW FILE SERVER LOCATION
				// IF THE PROCESSING DIRECTORY FILE NAME HAS AN HTML EXTENSION
				// THEN IT MUST BE AN NTSB REPORT
				if (inLog_File.Substring(Math.Max(inLog_File.Length - 4, 0)).ToLower() == "html")
				{
					FileType = "NTSB";
					Extension = ".html";
				}
				else
				{
					FileType = "FAAPDF";
					Extension = ".pdf";
				}

				// GET THE LOCATION OF THE FILE TO BE REMOVED
				strSourceFile = Get_Document_File_Name(PassedACID, PassedJournID, PassedJournSeqNo, FileType, Extension);

				if (File.Exists(strSourceFile))
				{

					if (File.Exists(inLog_File))
					{
						//UPGRADE_WARNING: (2081) DeleteFile has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
						File.Delete(inLog_File);
					}

					File.Copy(strSourceFile, inLog_File, true);
					//UPGRADE_WARNING: (2081) DeleteFile has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
					File.Delete(strSourceFile);
					bResults = true;

				}
				else
				{

					// If Source File Does NOT Exists But inLog_File Does Then Everything is OK
					if (File.Exists(inLog_File))
					{
						bResults = true;
					}
					else
					{
						modAdminCommon.Record_Error("UnAttacdDoc", $" Source file does not exist: {strSourceFile}");
					}

				} // If fso.FileExists(SourceFile) = True Then

				fso = null;

				result = bResults;
				Application.DoEvents();
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("UnAttachFile_Error", excep.Message);

				result = false;
			}

			return result;
		} // UnAttachFile


		internal static string Format_Ser_No_Sort_XXX(string inPrefix, string inSerNo, string inSuffix, string AirframeType = "")
		{

			string result = "";
			try
			{
				result = "";

				int tempForEndVar = 7 - Strings.Len(inPrefix.Trim());
				for (int i = 1; i <= tempForEndVar; i++)
				{
					result = $"{result}0";
				}
				result = $"{result}{inPrefix.Trim()}";

				int tempForEndVar2 = 8 - Strings.Len(inSerNo.Trim());
				for (int i = 1; i <= tempForEndVar2; i++)
				{
					result = $"{result}0";
				}

				result = $"{result}{inSerNo.Trim()}";

				int tempForEndVar3 = 7 - Strings.Len(inSuffix.Trim());
				for (int i = 1; i <= tempForEndVar3; i++)
				{
					result = $"{result}0";
				}

				return $"{result}{inSuffix.Trim()}";
			}
			catch (System.Exception excep)
			{

				Cursor.Current = CursorHelper.CursorDefault;
				modAdminCommon.Report_Error($"Format Serial Number Sort Error_XXX: {excep.Message}");
			}
			return result;
		}


		internal static string Format_Ser_No_Sort(string strPrefix, string strSerNo, string strSuffix, string AirframeType = "")
		{

			string strResults = "";

			try
			{

				strResults = "";

				strPrefix = StringsHelper.Replace(strPrefix, "-", "", 1, -1, CompareMethod.Binary);
				strSerNo = StringsHelper.Replace(strSerNo, "-", "", 1, -1, CompareMethod.Binary);
				strSuffix = StringsHelper.Replace(strSuffix, "-", "", 1, -1, CompareMethod.Binary);


				strPrefix = $"{new string('0', 7 - Strings.Len(strPrefix))}{strPrefix}";
				strSuffix = $"{new string('0', 7 - Strings.Len(strSuffix))}{strSuffix}";

				if (AirframeType == "F")
				{
					strSerNo = $"{new string('0', 8 - Strings.Len(strSerNo))}{strSerNo}";
				}
				else
				{
					strSerNo = $"{new string('0', 20 - Strings.Len(strSerNo))}{strSerNo}";
				}

				strResults = $"{strPrefix}{strSerNo}{strSuffix}";


				return strResults;
			}
			catch (System.Exception excep)
			{

				Cursor.Current = CursorHelper.CursorDefault;
				modAdminCommon.Report_Error($"Format Serial Number Sort Error: {excep.Message}");
			}
			return "";
		} // End Function Format_Ser_No_Sort

		internal static void temp_serno_fix()
		{

		}


		internal static bool Save_Company_Business_Types(object inJournal_ID)
		{
			// ====================================================================================
			// Written By : Rick Wanner ***** NOTE THAT THIS FUNCTION IS CURRENTLY NOT USED - 8/27/02
			//                                IT MAY BE A REQUIRED REPLACEMENT
			// Modified   : 8/27/2002
			// Function   : Save_Company_Business_Types
			// Parameters : ByVal inJournal ID - Journal ID of a transaction
			//
			// Returns    : True/False
			//
			// Notes      : This function saves a copy of all business types for all companies
			//              related to a historical transaction (as designated by the journal id)
			//
			// ====================================================================================
			bool result = false;
			string Query = "";
			ADORecordSetHelper snp_ACCompList = new ADORecordSetHelper();
			ADORecordSetHelper snp_BusType = new ADORecordSetHelper();

			ADORecordSetHelper ado_new_BusType = null;

			try
			{


				// ********* GET A LIST OF COMPANIES FROM THE HISTORICAL TRANSACTION
				//UPGRADE_WARNING: (1068) inJournal_ID of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
				Query = $"select distinct cref_comp_id from Aircraft_Reference where cref_journ_id={Convert.ToString(inJournal_ID)}";
				snp_ACCompList.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);
				string[] arr_Comp_Business_Types = null;
				if (!(snp_ACCompList.BOF && snp_ACCompList.EOF))
				{

					while(!snp_ACCompList.EOF)
					{


						// ********* SAVE COMPANY BUSINESS TYPE LIST INTO AN ARRAY
						Query = "SELECT * FROM Business_Type_Reference ";
						Query = $"{Query}WHERE bustypref_comp_id = {Convert.ToString(snp_ACCompList["cref_comp_id"])} ";
						Query = $"{Query}AND bustypref_journ_id = 0 ";
						Query = $"{Query}ORDER BY bustypref_seq_no ";

						snp_BusType.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);
						if (!(snp_BusType.BOF && snp_BusType.EOF))
						{
							arr_Comp_Business_Types = new string[]{""};

							while(!snp_BusType.EOF)
							{
								arr_Comp_Business_Types = ArraysHelper.RedimPreserve(arr_Comp_Business_Types, new int[]{arr_Comp_Business_Types.GetUpperBound(0) + 2});
								arr_Comp_Business_Types[arr_Comp_Business_Types.GetUpperBound(0)] = Convert.ToString(snp_BusType["bustypref_type"]);
								snp_BusType.MoveNext();
							}; //  Do While Not snp_BusType.EOF
						} // If Not (snp_BusType.BOF And snp_BusType.EOF) Then

						snp_BusType.Close();
						snp_BusType = null;



						//*********** LOOP THROUGH THE BUSINESS TYPES FOR EACH COMPANY STORED IN THE ARRAY
						//AND SAVE THEM TO HISTORICAL RECORD
						ado_new_BusType = new ADORecordSetHelper();
						ado_new_BusType.Open("Business_Type_Reference", modAdminCommon.ADODB_Trans_conn, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

						int tempForEndVar = arr_Comp_Business_Types.GetUpperBound(0);
						for (int J = 1; J <= tempForEndVar; J++)
						{
							//UPGRADE_ISSUE: (2064) ADODB.CursorOptionEnum property CursorOptionEnum.adAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_ISSUE: (2064) ADODB.Recordset method ado_new_BusType.Supports was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							if (ado_new_BusType.Supports(UpgradeStubs.ADODB_CursorOptionEnum.getadAddNew()))
							{
								ado_new_BusType.AddNew();
								ado_new_BusType["bustypref_comp_id"] = snp_ACCompList["cref_comp_id"];
								ado_new_BusType["bustypref_journ_id"] = inJournal_ID;
								ado_new_BusType["bustypref_type"] = arr_Comp_Business_Types[J];
								ado_new_BusType["bustypref_seq_no"] = J;
								ado_new_BusType.Update();
								//               Debug.Print "Processing Company Type -> " & arr_Comp_Business_Types(j)
							}
							else
							{
								// If ado_new_BusType.Supports(adAddNew) Then
								result = false;
							}

						} // end of loop through array of business types

						ado_new_BusType.Close();
						ado_new_BusType = null;

						snp_ACCompList.MoveNext(); // get the next company for the transaction
					}; //  Do While Not snp_ACCompList.EOF
				} // If Not (snp_ACCompList.BOF And snp_ACCompList.EOF) Then

				snp_ACCompList.Close();
				snp_ACCompList = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"Copy_Company_Business_Types_Error: {excep.Message}");
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
				Cursor.Current = CursorHelper.CursorDefault;
			}
			return result;
		}

		internal static bool Transaction_Save_Aircraft_History(int in_journal_id, string in_Trans_Type, ADORecordSetHelper snp_Aircraft, ADORecordSetHelper snp_Aircraft_Reference, ADORecordSetHelper snp_Aircraft_Features, ADORecordSetHelper snp_Aircraft_Avionics, ADORecordSetHelper snp_Aircraft_Certified, ADORecordSetHelper snp_Aircraft_Specification, ADORecordSetHelper snp_Aircraft_Details, ADORecordSetHelper snp_Aircraft_FAA_Document, bool inHist_Flag = false, string inRegNum = "", bool in_SendToWeb = true, string in_JournSubCatCode = "")
		{
			//******************************************************************************************
			//******************************************************************************************

			bool result = false;
			string errMsg = "";
			try
			{

				string Query = "";
				int i = 0;
				ADORecordSetHelper ado_new_aircraft = new ADORecordSetHelper();
				ADORecordSetHelper ado_new_reference = new ADORecordSetHelper();
				ADORecordSetHelper ado_new_share = new ADORecordSetHelper();
				ADORecordSetHelper ado_new_HistFeat = new ADORecordSetHelper();
				ADORecordSetHelper ado_new_Aircraft_Avionics = new ADORecordSetHelper();
				ADORecordSetHelper ado_new_Aircraft_Certified = new ADORecordSetHelper();
				ADORecordSetHelper ado_new_Aircraft_Specification = new ADORecordSetHelper();
				ADORecordSetHelper ado_new_Aircraft_Details = new ADORecordSetHelper();
				ADORecordSetHelper ado_new_Aircraft_FAA_Document = new ADORecordSetHelper();
				string CurrentDateTime = "";
				CurrentDateTime = modAdminCommon.GetDateTime();

				//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				// Create an Historical record of the current status of an Aircraft
				//    [NOTE: 'ADODB_Trans_conn' is PUBLIC and is initialized in the 'ADO_Transaction' routine]
				//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				Cursor.Current = Cursors.WaitCursor;
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Creating a Historical Aircraft Record", Color.Blue);

				result = false;
				errMsg = "AC Hist";

				// save the aircraft history record
				if ((!snp_Aircraft.BOF) && (!snp_Aircraft.EOF))
				{
					snp_Aircraft.MoveFirst();
					ado_new_aircraft.Open("Aircraft", modAdminCommon.ADODB_Trans_conn, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);
					//UPGRADE_ISSUE: (2064) ADODB.CursorOptionEnum property CursorOptionEnum.adAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_ISSUE: (2064) ADODB.Recordset method ado_new_aircraft.Supports was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					if (ado_new_aircraft.Supports(UpgradeStubs.ADODB_CursorOptionEnum.getadAddNew()))
					{
						ado_new_aircraft.AddNew();
						i = 0;

						while((i < snp_Aircraft.FieldsMetadata.Count))
						{
							ado_new_aircraft[i] = snp_Aircraft[i];
							i++;
						};
						// CLEAR APPROPRIATE VALUES FOR HISTORICAL AND CORRECTION TRANSACTIONS
						if (inHist_Flag)
						{ //Or right(in_Trans_Type, 4) = "CORR" Then
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_list_date"] = DBNull.Value;
							ado_new_aircraft["ac_forsale_flag"] = "N";
							if (($"{inRegNum}").Trim() != "")
							{
								ado_new_aircraft["ac_reg_no"] = inRegNum.ToUpper();
							}
							else
							{
								ado_new_aircraft["ac_reg_no"] = "";
							}
							ado_new_aircraft["ac_prev_reg_no"] = "";
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_purchase_date"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_exclusive_flag"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_exclusive_verify_date"] = DBNull.Value;
							ado_new_aircraft["ac_status"] = "Not For Sale";
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_delivery"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_delivery_date"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_asking"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_asking_price"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_foreign_currency_name"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_foreign_currency_price"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_times_as_of_date"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_airframe_tot_hrs"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_airframe_tot_landings"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_engine_maint_prog"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_engine_1_tot_hrs"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_engine_2_tot_hrs"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_engine_3_tot_hrs"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_engine_4_tot_hrs"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_engine_1_soh_hrs"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_engine_2_soh_hrs"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_engine_3_soh_hrs"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_engine_4_soh_hrs"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_engine_1_shi_hrs"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_engine_2_shi_hrs"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_engine_3_shi_hrs"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_engine_4_shi_hrs"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_engine_1_snew_cycles"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_engine_2_snew_cycles"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_engine_3_snew_cycles"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_engine_4_snew_cycles"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_engine_1_soh_cycles"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_engine_2_soh_cycles"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_engine_3_soh_cycles"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_engine_4_soh_cycles"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_engine_1_shs_cycles"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_engine_2_shs_cycles"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_engine_3_shs_cycles"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_engine_4_shs_cycles"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_prop_1_snew_hrs"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_prop_2_snew_hrs"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_prop_3_snew_hrs"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_prop_4_snew_hrs"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_prop_1_soh_hrs"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_prop_2_soh_hrs"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_prop_3_soh_hrs"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_prop_4_soh_hrs"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_prop_1_soh_moyear"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_prop_2_soh_moyear"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_prop_3_soh_moyear"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_prop_4_soh_moyear"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_apu_model_name"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_apu_ser_no"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_apu_tot_hrs"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_apu_soh_hrs"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_apu_shi_hrs"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_apu_maint_prog"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_maint_prog_name"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_maint_eoh_by_name"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_main_eoh_moyear"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_maint_hots_by_name"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_maint_hots_moyear"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_maint_tracking_name"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_maintained"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_damage_history_notes"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_interior_rating"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_interior_moyear"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_interior_doneby_name"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_exterior_rating"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_exterior_moyear"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_exterior_doneby_name"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_lease_flag"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_passenger_count"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_interior_config_name"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_lights"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_confidential_notes"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_last_verified_date"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_next_verified_date"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_common_notes"] = DBNull.Value;
							// assume aircraft was in operation and research will
							// change historical in odd cases
							ado_new_aircraft["ac_lifecycle_stage"] = 3;
							ado_new_aircraft["ac_ownership_type"] = "W";

							if (in_Trans_Type.StartsWith("FS", StringComparison.Ordinal) || in_Trans_Type == "F")
							{
								ado_new_aircraft["ac_ownership_type"] = "F";
							}
							if (in_Trans_Type.StartsWith("SS", StringComparison.Ordinal) || in_Trans_Type == "S")
							{
								ado_new_aircraft["ac_ownership_type"] = "S";
							}
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_reg_no_verify_date"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_airport_code_verify_date"] = DBNull.Value;
							//ado_new_aircraft!ac_certification = Null  'aey 6/3/04
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_exclusive_exp_confirm_date"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_exclusive_date"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_exclusive_expiration_flag"] = DBNull.Value;
							ado_new_aircraft["ac_aport_id"] = 0;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_aport_iata_code"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_aport_icao_code"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_aport_faaid_code"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_aport_name"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_aport_state"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_aport_country"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_aport_city"] = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_aport_private"] = DBNull.Value;

							ado_new_aircraft["ac_ent_user_id"] = modAdminCommon.gbl_User_ID.ToLower();
							ado_new_aircraft["ac_ent_date"] = CurrentDateTime;
							ado_new_aircraft["ac_upd_user_id"] = modAdminCommon.gbl_User_ID.ToLower();
							ado_new_aircraft["ac_upd_date"] = CurrentDateTime;
						}
						ado_new_aircraft["ac_journ_id"] = in_journal_id;
						if (in_SendToWeb)
						{
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							ado_new_aircraft["ac_action_date"] = DBNull.Value;
						}
						else
						{
							ado_new_aircraft["ac_action_date"] = CurrentDateTime;
						}
						ado_new_aircraft.Update();
					}
					else
					{
						result = false;
					}
					if (ado_new_aircraft.State == ConnectionState.Open)
					{
						ado_new_aircraft.Close();
					}
					ado_new_aircraft = null;
				}
				else
				{
					return result;
				} // AIRCRAFT

				errMsg = "AC Ref Hist";

				// save the aircraft reference history record
				// RTW - 3/31/2004 - MAKE SURE THAT THE SNAPSHOT IS OPEN BEFORE SAVING
				bool OK_To_Copy = false;
				if (snp_Aircraft_Reference.State == ConnectionState.Open)
				{
					if ((!snp_Aircraft_Reference.BOF) && (!snp_Aircraft_Reference.EOF))
					{
						snp_Aircraft_Reference.MoveFirst();
						ado_new_reference.Open("Aircraft_Reference", modAdminCommon.ADODB_Trans_conn, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

						while(!snp_Aircraft_Reference.EOF)
						{

							OK_To_Copy = true;

							switch(($"{Convert.ToString(snp_Aircraft_Reference["cref_contact_type"])}").Trim())
							{
								case "00" :  // CURRENT OWNER REFERENCE 
									//  DO NOT COPY THE CURRENT OWNER FOR WS, SZ, FC, AND SS TRANSACTIONS 
									// FS added 1/10/2006 aey 
									if (in_Trans_Type.StartsWith("WS", StringComparison.Ordinal) || in_Trans_Type.StartsWith("SZ", StringComparison.Ordinal) || in_Trans_Type.StartsWith("FC", StringComparison.Ordinal) || in_Trans_Type.StartsWith("FS", StringComparison.Ordinal) || in_Trans_Type.StartsWith("SS", StringComparison.Ordinal))
									{
										OK_To_Copy = false;
									} 
									 
									// DO NOT COPY THE CURRENT OWNER FOR LEASE TRANSACTIONS 
									if (in_Trans_Type.StartsWith("L", StringComparison.Ordinal))
									{
										OK_To_Copy = false;
									} 
									 
									break;
								case "17" : case "97" :  // PROGRAM HOLDER OR FRACTIONAL OWNER REFERENCE 
									// WITH A FRACTIONAL SALE (FS) 
									if (in_Trans_Type.StartsWith("FS", StringComparison.Ordinal))
									{
										OK_To_Copy = false;
									} 
									 
									break;
								case "08" :  // CO-OWNER REFERENCE WITH A SHARE SALE (SS) TRANSACTION 
									if (in_Trans_Type.StartsWith("SS", StringComparison.Ordinal))
									{
										OK_To_Copy = false;
									} 
									 
									break;
								case "12" : case "13" : case "39" : case "57" :  // LEASE REFERENCES 
									if (in_Trans_Type.StartsWith("L", StringComparison.Ordinal))
									{
										OK_To_Copy = false;
									} 
									 
									if (in_Trans_Type.StartsWith("FS", StringComparison.Ordinal))
									{
										OK_To_Copy = false; //1/10/2006 aey
									} 
									 
									break;
								default:
									if (inHist_Flag)
									{
										OK_To_Copy = false;
									} 
									 
									break;
							} // ON CONTACT TYPE


							if (OK_To_Copy)
							{ // OK TO COPY THIS REFERENCE
								//UPGRADE_ISSUE: (2064) ADODB.CursorOptionEnum property CursorOptionEnum.adAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
								//UPGRADE_ISSUE: (2064) ADODB.Recordset method ado_new_reference.Supports was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
								if (ado_new_reference.Supports(UpgradeStubs.ADODB_CursorOptionEnum.getadAddNew()))
								{
									ado_new_reference.AddNew();
									ado_new_reference["cref_ac_id"] = snp_Aircraft_Reference["cref_ac_id"];
									ado_new_reference["cref_comp_id"] = snp_Aircraft_Reference["cref_comp_id"];
									ado_new_reference["cref_contact_id"] = snp_Aircraft_Reference["cref_contact_id"];
									ado_new_reference["cref_journ_id"] = in_journal_id;
									ado_new_reference["cref_primary_poc_flag"] = "N";
									ado_new_reference["cref_owner_percent"] = snp_Aircraft_Reference["cref_owner_percent"];
									if (($"{Convert.ToString(snp_Aircraft_Reference["cref_contact_type"])} ").Trim() == "62" && in_JournSubCatCode == "")
									{ //aey 8/25/04
										ado_new_reference["cref_contact_type"] = "60";
									}
									else
									{
										ado_new_reference["cref_contact_type"] = snp_Aircraft_Reference["cref_contact_type"];
									}
									ado_new_reference["cref_transmit_seq_no"] = snp_Aircraft_Reference["cref_transmit_seq_no"];
									ado_new_reference["cref_business_type"] = snp_Aircraft_Reference["cref_business_type"];
									ado_new_reference.Update();
								}
							}
							snp_Aircraft_Reference.MoveNext();
						};
						if (ado_new_reference.State == ConnectionState.Open)
						{
							ado_new_reference.Close();
						}
						ado_new_reference = null;
					} // REFERENCES
				}


				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Saving Feature Codes  Copy", Color.Blue);
				//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				// SAVE HISTORICAL AIRCRAFT IMPORTANT FEATURE CODES
				//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Saving Key Features", Color.Blue);
				errMsg = "Key Feat";

				if (!(snp_Aircraft_Features.BOF && snp_Aircraft_Features.EOF))
				{
					snp_Aircraft_Features.MoveFirst();
					ado_new_HistFeat.Open("Aircraft_Key_Feature", modAdminCommon.ADODB_Trans_conn, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

					while(!snp_Aircraft_Features.EOF)
					{
						//UPGRADE_ISSUE: (2064) ADODB.CursorOptionEnum property CursorOptionEnum.adAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_ISSUE: (2064) ADODB.Recordset method ado_new_HistFeat.Supports was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						if (ado_new_HistFeat.Supports(UpgradeStubs.ADODB_CursorOptionEnum.getadAddNew()))
						{
							ado_new_HistFeat.AddNew();
							ado_new_HistFeat["afeat_ac_id"] = snp_Aircraft_Features["afeat_ac_id"];
							ado_new_HistFeat["afeat_journ_id"] = in_journal_id;
							ado_new_HistFeat["afeat_feature_code"] = snp_Aircraft_Features["afeat_feature_code"];
							// CLEAR THE FEATURE STATUS IF HISTORICAL
							if (inHist_Flag)
							{
								ado_new_HistFeat["afeat_status_flag"] = "U";
							}
							else
							{
								ado_new_HistFeat["afeat_status_flag"] = snp_Aircraft_Features["afeat_status_flag"];
							}
							ado_new_HistFeat["afeat_seq_no"] = snp_Aircraft_Features["afeat_seq_no"];

							if (in_SendToWeb)
							{ //7/30/04 aey
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								ado_new_HistFeat["afeat_action_date"] = DBNull.Value;
							}
							else
							{
								ado_new_HistFeat["afeat_action_date"] = CurrentDateTime;
							}


							ado_new_HistFeat.Update();
						}
						else
						{
							return result;
						}

						snp_Aircraft_Features.MoveNext();

					};
					if (ado_new_HistFeat.State == ConnectionState.Open)
					{
						ado_new_HistFeat.Close();
					}
					ado_new_HistFeat = null;
				} // AIRCRAFT FEATURES

				// *********************************************************
				// IF NOT A HISTORICAL TRANSACTION THEN SAVE THE AVIONICS, DETAILS, SPECS, AND
				// FAA DOCUMENTS RECORDS

				if (!inHist_Flag)
				{
					modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Saving Avionics", Color.Blue);
					//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
					// SAVE HISTORICAL 'Aircraft_Avionics' table row
					//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
					errMsg = "Avionics hist";

					if (!(snp_Aircraft_Avionics.BOF && snp_Aircraft_Avionics.EOF))
					{
						snp_Aircraft_Avionics.MoveFirst();
						ado_new_Aircraft_Avionics.Open("Aircraft_Avionics", modAdminCommon.ADODB_Trans_conn, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

						while(!snp_Aircraft_Avionics.EOF)
						{
							//UPGRADE_ISSUE: (2064) ADODB.CursorOptionEnum property CursorOptionEnum.adAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_ISSUE: (2064) ADODB.Recordset method ado_new_Aircraft_Avionics.Supports was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							if (ado_new_Aircraft_Avionics.Supports(UpgradeStubs.ADODB_CursorOptionEnum.getadAddNew()))
							{
								ado_new_Aircraft_Avionics.AddNew();
								i = 0;

								while((i < snp_Aircraft_Avionics.FieldsMetadata.Count))
								{
									ado_new_Aircraft_Avionics[i] = snp_Aircraft_Avionics[i];
									i++;
								};
								ado_new_Aircraft_Avionics["av_ac_journ_id"] = in_journal_id;
								ado_new_Aircraft_Avionics.Update();
							}
							else
							{
								return result;
							}

							snp_Aircraft_Avionics.MoveNext();
						};
						if (ado_new_Aircraft_Avionics.State == ConnectionState.Open)
						{
							ado_new_Aircraft_Avionics.Close();
						}
						ado_new_Aircraft_Avionics = null;
					} // AIRCRAFT AVIONICS


					modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Saving Aircraft Certified", Color.Blue);
					//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
					// SAVE HISTORICAL 'Aircraft_Certified' table row
					//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
					errMsg = "Cert Hist";

					if (!(snp_Aircraft_Certified.BOF && snp_Aircraft_Certified.EOF))
					{
						snp_Aircraft_Certified.MoveFirst();
						ado_new_Aircraft_Certified.Open("Aircraft_Certified", modAdminCommon.ADODB_Trans_conn, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

						while(!snp_Aircraft_Certified.EOF)
						{
							//UPGRADE_ISSUE: (2064) ADODB.CursorOptionEnum property CursorOptionEnum.adAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_ISSUE: (2064) ADODB.Recordset method ado_new_Aircraft_Certified.Supports was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							if (ado_new_Aircraft_Certified.Supports(UpgradeStubs.ADODB_CursorOptionEnum.getadAddNew()))
							{
								ado_new_Aircraft_Certified.AddNew();
								i = 0;

								while((i < snp_Aircraft_Certified.FieldsMetadata.Count))
								{
									ado_new_Aircraft_Certified[i] = snp_Aircraft_Certified[i];
									i++;
								};
								ado_new_Aircraft_Certified["accert_ac_journ_id"] = in_journal_id;
								ado_new_Aircraft_Certified.Update();
							}
							else
							{
								return result;
							}
							snp_Aircraft_Certified.MoveNext();
						};
						if (ado_new_Aircraft_Certified.State == ConnectionState.Open)
						{
							ado_new_Aircraft_Certified.Close();
						}
						ado_new_Aircraft_Certified = null;
					} // AIRCRAFT CERTIFIED


					//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
					// SAVE HISTORICAL 'AIRCRAFT_DETAILS' table row
					modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Saving Aircraft Details", Color.Blue);
					errMsg = "Detail Hist";

					if (!(snp_Aircraft_Details.BOF && snp_Aircraft_Details.EOF))
					{
						snp_Aircraft_Details.MoveFirst();
						ado_new_Aircraft_Details.Open("Aircraft_Details", modAdminCommon.ADODB_Trans_conn, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

						while(!snp_Aircraft_Details.EOF)
						{
							//UPGRADE_ISSUE: (2064) ADODB.CursorOptionEnum property CursorOptionEnum.adAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_ISSUE: (2064) ADODB.Recordset method ado_new_Aircraft_Details.Supports was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							if (ado_new_Aircraft_Details.Supports(UpgradeStubs.ADODB_CursorOptionEnum.getadAddNew()))
							{
								ado_new_Aircraft_Details.AddNew();
								i = 0;

								while((i < snp_Aircraft_Details.FieldsMetadata.Count))
								{
									if (snp_Aircraft_Details.GetField(i).FieldMetadata.ColumnName != "adet_id")
									{
										ado_new_Aircraft_Details[i] = snp_Aircraft_Details[i];
									}
									i++;
								};
								ado_new_Aircraft_Details["adet_journ_id"] = in_journal_id;

								if (in_SendToWeb)
								{ //7/30/04 aey
									//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
									ado_new_Aircraft_Details["adet_action_date"] = DBNull.Value;
								}
								else
								{
									ado_new_Aircraft_Details["adet_action_date"] = CurrentDateTime;
								}

								ado_new_Aircraft_Details.Update();
							}
							else
							{
								return result;
							}
							snp_Aircraft_Details.MoveNext();
						};
						if (ado_new_Aircraft_Details.State == ConnectionState.Open)
						{
							ado_new_Aircraft_Details.Close();
						}
						ado_new_Aircraft_Details = null;
					} // AIRCRAFT DETAILS



					//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
					// SAVE HISTORICAL 'Aircraft_Specification' table row
					//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
					modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Saving Aircraft Specifications", Color.Blue);
					errMsg = "Spec Hist";

					if (!(snp_Aircraft_Specification.BOF && snp_Aircraft_Specification.EOF))
					{
						snp_Aircraft_Specification.MoveFirst();
						ado_new_Aircraft_Specification.Open("Aircraft_Specification", modAdminCommon.ADODB_Trans_conn, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

						while(!snp_Aircraft_Specification.EOF)
						{
							//UPGRADE_ISSUE: (2064) ADODB.CursorOptionEnum property CursorOptionEnum.adAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_ISSUE: (2064) ADODB.Recordset method ado_new_Aircraft_Specification.Supports was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							if (ado_new_Aircraft_Specification.Supports(UpgradeStubs.ADODB_CursorOptionEnum.getadAddNew()))
							{
								ado_new_Aircraft_Specification.AddNew();
								i = 0;

								while((i < snp_Aircraft_Specification.FieldsMetadata.Count))
								{
									ado_new_Aircraft_Specification[i] = snp_Aircraft_Specification[i];
									i++;
								};
								ado_new_Aircraft_Specification["acspec_ac_journ_id"] = in_journal_id;
								ado_new_Aircraft_Specification.Update();
							}
							else
							{
								return result;
							}
							snp_Aircraft_Specification.MoveNext();
						};
						if (ado_new_Aircraft_Specification.State == ConnectionState.Open)
						{
							ado_new_Aircraft_Specification.Close();
						}
						ado_new_Aircraft_Specification = null;
					} // AIRCRAFT SPECIFICATION


					//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
					// SAVE HISTORICAL 'Aircraft_FAA_Document' table row
					//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
					modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Saving FAA Documents", Color.Blue);
					errMsg = "FAA Hist";

					if (!(snp_Aircraft_FAA_Document.BOF && snp_Aircraft_FAA_Document.EOF))
					{
						snp_Aircraft_FAA_Document.MoveFirst();
						ado_new_Aircraft_FAA_Document.Open("Aircraft_FAA_Document", modAdminCommon.ADODB_Trans_conn, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

						while(!snp_Aircraft_FAA_Document.EOF)
						{

							//UPGRADE_ISSUE: (2064) ADODB.CursorOptionEnum property CursorOptionEnum.adAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_ISSUE: (2064) ADODB.Recordset method ado_new_Aircraft_FAA_Document.Supports was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							if (ado_new_Aircraft_FAA_Document.Supports(UpgradeStubs.ADODB_CursorOptionEnum.getadAddNew()))
							{
								ado_new_Aircraft_FAA_Document.AddNew();
								i = 0;

								while((i < snp_Aircraft_FAA_Document.FieldsMetadata.Count))
								{
									ado_new_Aircraft_FAA_Document[i] = snp_Aircraft_FAA_Document[i];
									i++;
								};
								ado_new_Aircraft_FAA_Document["acfaa_journ_id"] = in_journal_id;
								ado_new_Aircraft_FAA_Document.Update();
							}
							else
							{
								return result;
							}
							snp_Aircraft_FAA_Document.MoveNext();
						};
						if (ado_new_Aircraft_FAA_Document.State == ConnectionState.Open)
						{
							ado_new_Aircraft_FAA_Document.Close();
						}
						ado_new_Aircraft_FAA_Document = null;
					} // AIRCRAFT FAA DOCUMENTS
				} // if not historical

				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
				Cursor.Current = CursorHelper.CursorDefault;
				return true;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Transaction_Save_Aircraft_History_Error ({Information.Err().Number.ToString()}) {excep.Message} : {errMsg}", "modCommon (Transaction)");
				return result;
			}
		}

		internal static string GetOwnershipType(int inACID, int inJournID)
		{

			string result = "";
			ADORecordSetHelper snpOwn = new ADORecordSetHelper(); //8/11/05 aey Recordset


			string Query = "SELECT ac_ownership_type ";
			Query = $"{Query}FROM Aircraft WITH(NOLOCK) ";
			Query = $"{Query}WHERE ac_id = {inACID.ToString()} ";
			Query = $"{Query}AND ac_journ_id = {inJournID.ToString()}";

			snpOwn.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

			if (!(snpOwn.BOF && snpOwn.EOF))
			{
				result = ($"{Convert.ToString(snpOwn["ac_ownership_type"])}").Trim();
			}

			snpOwn.Close();

			return result;
		}

		internal static bool Aircraft_History_Get_Recordsets(int in_Aircraft_ID, string in_Transaction_Type, string in_Company_List, object inSeller_Comp_ID = null, object inBuyer_Comp_ID = null)
		{

			bool result = false;
			string Query = "";
			string strStatus = "";
			try
			{

				string Query2 = "";
				StringBuilder CompanyCopyList = new StringBuilder();
				string Separator = "";
				string Separator2 = "";
				bool bSkipPhoneNbrs = false;
				string tmpquery = "";
				double temp_company_to_avoid_double = 0; // added msw 6/3/2011 to stop lessor number if seller from being re-entered

				//*******************************************************
				// CREATE NEW RECORDSETS FOR HOLDING HISTORY INFORMATION
				strStatus = "create";
				Aircraft_History_Create_Recordsets();


				Cursor.Current = Cursors.WaitCursor;
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Selecting a Snapshot of Aircraft Information", Color.Blue);

				result = false;

				strStatus = "Query 1";
				// **********************************************
				// GET A COPY OF THE CURRENT AIRCRAFT RECORD
				Query = $"SELECT DISTINCT * FROM Aircraft WITH(NOLOCK) WHERE ac_id = {in_Aircraft_ID.ToString()} AND ac_journ_id = 0";

				modGlobalVars.snp_TransAircraft.Open(Query, modAdminCommon.CLIENT_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(modGlobalVars.snp_TransAircraft.BOF && modGlobalVars.snp_TransAircraft.EOF))
				{
					modGlobalVars.snp_TransAircraft.MoveFirst();
				}
				else
				{
					return result;
				}

				modGlobalVars.snp_TransAircraft.ActiveConnection = null;


				strStatus = "Query 2";
				// ********************************************
				// GET ALL COMPANY RECORDS FOR THE AIRCRAFT
				// MAKE A LIST OF COMPANIES TO SAVE

				CompanyCopyList = new StringBuilder("");
				Separator = "";
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Selecting Aircraft Company Copies ...", Color.Blue);
				Query = "SELECT distinct Company.* FROM Company WITH(NOLOCK) ";
				Query = $"{Query}INNER JOIN Aircraft_Reference WITH(NOLOCK) ON comp_id=cref_comp_id and comp_journ_id = cref_journ_id";
				Query = $"{Query} WHERE cref_ac_id = {in_Aircraft_ID.ToString()}";
				Query = $"{Query} AND comp_journ_id = cref_journ_id"; //aey 9/10/04
				Query = $"{Query} AND comp_journ_id = 0";

				// ************************************************
				// CHECK TO SEE IF THE SELLER IS ALSO THE LESSOR
				// RTW - 11/3/2004 - TO SOLVE PROBLEM OF MISSING LESSOR

				temp_company_to_avoid_double = 0; // seller is not lessor MSW 6/3/2011

				// changed - 6/19/2011 MSW from a val statement to a len statement - to overall stop duplicates to not need the leesor/ owner check
				// IF THERE IS STILL A COMPANY LIST TO IGNORE THEN IGNORE THEM
				if (Strings.Len($"{in_Company_List}") > 0)
				{
					Query = $"{Query} AND cref_comp_id not in ({in_Company_List})";
				}

				Query2 = Query; //aey 9/10/04
				Query2 = StringsHelper.Replace(Query2, "distinct Company.*", "distinct Company.*,Aircraft_Reference.cref_business_type,Aircraft_Reference.cref_contact_type ", 1, -1, CompareMethod.Binary);

				//aey 7/29/04 combined all criteria into one if statement
				if (in_Transaction_Type.StartsWith("FS", StringComparison.Ordinal) || in_Transaction_Type.StartsWith("SS", StringComparison.Ordinal) || in_Transaction_Type.StartsWith("L", StringComparison.Ordinal) || in_Transaction_Type.StartsWith("WS", StringComparison.Ordinal) || in_Transaction_Type.StartsWith("FC", StringComparison.Ordinal) || in_Transaction_Type.StartsWith("SS", StringComparison.Ordinal) || in_Transaction_Type.StartsWith("SZ", StringComparison.Ordinal))
				{

					Query = $"{Query} AND cref_contact_type <> '97' AND cref_contact_type <> '08' AND cref_contact_type <> '17'";
					// RTW - COMMENTED OUT LEASE CONTACT TYPES TO ALLOW LESSEE ON TRANSACTIONS
					//Query = Query & " AND cref_contact_type NOT IN ('12','13','39','57') "
					//Query = Query & " AND cref_contact_type <> '00' "
				}

				bSkipPhoneNbrs = true;
				Separator2 = "";

				modGlobalVars.snp_TransAircraft_OtherCompanies = new ADORecordSetHelper();
				modGlobalVars.snp_TransAircraft_OtherCompanies.Open(Query2, modAdminCommon.CLIENT_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				modGlobalVars.snp_TransAircraft_Companies.Open(Query, modAdminCommon.CLIENT_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
				if (!(modGlobalVars.snp_TransAircraft_Companies.BOF && modGlobalVars.snp_TransAircraft_Companies.EOF))
				{
					modGlobalVars.snp_TransAircraft_Companies.MoveFirst();
					//  RTW - 3/30/2004 - MODIFIED TO GET EXACT COMPANY IDS ONE TIME

					while(!modGlobalVars.snp_TransAircraft_Companies.EOF)
					{
						CompanyCopyList.Append($"{Separator}{Convert.ToString(modGlobalVars.snp_TransAircraft_Companies["comp_id"])}");
						Separator = ",";
						modGlobalVars.snp_TransAircraft_Companies.MoveNext();
					};
					modGlobalVars.snp_TransAircraft_Companies.MoveFirst();
				}
				modGlobalVars.snp_TransAircraft_Companies.ActiveConnection = null;

				strStatus = "Query 3";
				// ***************************************************
				// IF THERE IS COMPANY INFORMATION TO COPY THEN GET IT
				if (Strings.Len(CompanyCopyList.ToString().Trim()) > 0)
				{

					//-------------------------------------------------------------------------------
					// Tasker Id #3067 If Off Market Do NOT Copy Phone Nbrs *ALL TRANSACTIONS*

					if (!bSkipPhoneNbrs)
					{

						// ********************************************
						// GET ALL COMPANY PHONE RECORDS FOR THE AIRCRAFT
						modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Selecting Aircraft Company Phone Number Copies ...", Color.Blue);
						Query = "SELECT DISTINCT Phone_Numbers.* FROM Phone_Numbers WITH(NOLOCK)";
						Query = $"{Query} WHERE pnum_journ_id = 0";
						// CHANGED ON 6/3/2011 BY MSW - TO COMPENSATE FOR GETTING TOO MANY COPIES/DUPLICATE PHONE NUMBERS
						Query = $"{Query} AND pnum_comp_id IN ({CompanyCopyList.ToString()})";
						// this was changed from the original CompanyCopyList to stop dup phone numbers

						// ***************************************************************
						// RTW - 6/7/2011
						// ONLY PHONES WITH CONTACT ID = 0 AS COMPANY PHONE NUMBERS OR CONTACTS ASSOCIATED WITH ORIGINAL AIRCRAFT - IN REF TABLE
						Query = $"{Query} AND (pnum_contact_id = 0 or ";
						Query = $"{Query}pnum_contact_id in (";
						Query = $"{Query} select distinct cref_contact_id from aircraft_reference where cref_journ_id = 0 and cref_ac_id={in_Aircraft_ID.ToString()} and cref_contact_id > 0))";
						// TEMP HOLD MATT

						modGlobalVars.snp_TransAircraft_Company_Phones.Open(Query, modAdminCommon.CLIENT_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
						if (!(modGlobalVars.snp_TransAircraft_Company_Phones.BOF && modGlobalVars.snp_TransAircraft_Company_Phones.EOF))
						{
							modGlobalVars.snp_TransAircraft_Company_Phones.MoveFirst();
						}
						modGlobalVars.snp_TransAircraft_Company_Phones.ActiveConnection = null;

					} // If bSkipPhoneNbrs = False Then

					strStatus = "Query 4";
					// ********************************************
					// GET ALL COMPANY BUSINESS TYPES
					modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Selecting Aircraft Company Business Type Copies ...", Color.Blue);
					Query = "SELECT DISTINCT Business_Type_Reference.* FROM Business_Type_Reference WITH(NOLOCK)";
					Query = $"{Query} where bustypref_journ_id = 0";
					Query = $"{Query} AND bustypref_comp_id in ({CompanyCopyList.ToString()})";

					modGlobalVars.snp_TransAircraft_Company_Btypes.Open(Query, modAdminCommon.CLIENT_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
					if (!(modGlobalVars.snp_TransAircraft_Company_Btypes.BOF && modGlobalVars.snp_TransAircraft_Company_Btypes.EOF))
					{
						modGlobalVars.snp_TransAircraft_Company_Btypes.MoveFirst();
					}
					modGlobalVars.snp_TransAircraft_Company_Btypes.ActiveConnection = null;


					strStatus = "Query 4.5 Certs";
					// ********************************************
					// GET ALL COMPANY CERTIFICATES
					modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Selecting Aircraft Company Certificates ...", Color.Blue);
					Query = "SELECT DISTINCT Company_Certification.* FROM Company_Certification WITH(NOLOCK)";
					Query = $"{Query} where ccert_journ_id = 0";
					Query = $"{Query} AND ccert_comp_id in ({CompanyCopyList.ToString()})";

					modGlobalVars.snp_TransAircraft_Company_Certs.Open(Query, modAdminCommon.CLIENT_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
					if (!(modGlobalVars.snp_TransAircraft_Company_Certs.BOF && modGlobalVars.snp_TransAircraft_Company_Certs.EOF))
					{
						modGlobalVars.snp_TransAircraft_Company_Certs.MoveFirst();
					}
					modGlobalVars.snp_TransAircraft_Company_Certs.ActiveConnection = null;


					strStatus = "Query 5";
					// *******************************************
					// GET ALL REFERENCE RECORDS FOR THE AIRCRAFT
					modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Selecting Aircraft References Copy ...", Color.Blue);
					Query = "SELECT DISTINCT Aircraft_Reference.* FROM Aircraft_Reference WITH(NOLOCK)";
					Query = $"{Query} WHERE cref_ac_id = {in_Aircraft_ID.ToString()}";
					Query = $"{Query} AND cref_journ_id = 0 ";
					Query = $"{Query} AND (cref_comp_id in ({CompanyCopyList.ToString()}) ";
					// RTW - ADDED TO ALLOW FOR COPYING OF REFERENCES RELATED TO SELLERS/BUYERS
					// 3/23/2006
					//ismissing added 3/24/06 aey
					//UPGRADE_WARNING: (2065) Boolean method Information.IsMissing has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
					if (!(inSeller_Comp_ID == null || inBuyer_Comp_ID == null))
					{
						// RTW/MSW - MODIFIED ON 12/1/2011 - ADDED LESSEE CONTACT TYPE TO ALLOW INCLUSION IN TRANSACTION
						//UPGRADE_WARNING: (1068) inBuyer_Comp_ID of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						//UPGRADE_WARNING: (1068) inSeller_Comp_ID of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						Query = $"{Query} OR (cref_comp_id in ({Convert.ToString(inSeller_Comp_ID)},{Convert.ToString(inBuyer_Comp_ID)}) AND cref_contact_type in ('36','44','12', '13')) ";
					}
					Query = $"{Query}) ";
					modGlobalVars.snp_TransAircraft_Reference.Open(Query, modAdminCommon.CLIENT_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
					if (!(modGlobalVars.snp_TransAircraft_Reference.BOF && modGlobalVars.snp_TransAircraft_Reference.EOF))
					{
						modGlobalVars.snp_TransAircraft_Reference.MoveFirst();
					}
					modGlobalVars.snp_TransAircraft_Reference.ActiveConnection = null;

					strStatus = "Query 6";
					// ********************************************
					// GET ALL CONTACT RECORDS FOR THE AIRCRAFT
					modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Selecting Aircraft Contacts Copies ...", Color.Blue);
					Query = "SELECT DISTINCT Contact.* FROM Contact WITH(NOLOCK)";
					Query = $"{Query} INNER JOIN Aircraft_Reference WITH(NOLOCK) on contact_id = cref_contact_id and contact_journ_id = cref_journ_id";
					Query = $"{Query} WHERE cref_ac_id = {in_Aircraft_ID.ToString()}";
					Query = $"{Query} AND cref_contact_id > 0  AND contact_journ_id = 0";
					Query = $"{Query} AND cref_comp_id in ({CompanyCopyList.ToString()})";

					modGlobalVars.snp_TransAircraft_Contacts.Open(Query, modAdminCommon.CLIENT_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
					if (!(modGlobalVars.snp_TransAircraft_Contacts.BOF && modGlobalVars.snp_TransAircraft_Contacts.EOF))
					{
						modGlobalVars.snp_TransAircraft_Contacts.MoveFirst();
					}
					modGlobalVars.snp_TransAircraft_Contacts.ActiveConnection = null;


				} // IF THERE IS COMPANY INFORMATION TO STORE

				strStatus = "Query 7";
				// *******************************************
				// GET ALL SHARE REFERENCE RECORDS FOR THE AIRCRAFT
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Selecting Aircraft References Copy ...", Color.Blue);
				Query = "SELECT DISTINCT Share_Reference.*, cref_ac_id, cref_journ_id, cref_comp_id, cref_contact_id, cref_contact_type";
				Query = $"{Query} FROM Share_Reference WITH(NOLOCK) ,Aircraft_Reference WITH(NOLOCK)";
				Query = $"{Query} WHERE cref_ac_id = {in_Aircraft_ID.ToString()}";
				Query = $"{Query} AND cref_journ_id = 0  AND cref_id = sref_cref_id";
				modGlobalVars.snp_TransShare_Reference.Open(Query, modAdminCommon.CLIENT_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
				if (!(modGlobalVars.snp_TransShare_Reference.BOF && modGlobalVars.snp_TransShare_Reference.EOF))
				{
					modGlobalVars.snp_TransShare_Reference.MoveFirst();
				}
				modGlobalVars.snp_TransShare_Reference.ActiveConnection = null;


				strStatus = "Query 8";
				// **************************************************
				// GET AIRCRAFT IMPORTANT FEATURE CODES
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Selecting Aircraft Key Features Copy ...", Color.Blue);
				Query = $"SELECT * FROM Aircraft_Key_Feature WITH(NOLOCK) WHERE afeat_ac_id = {in_Aircraft_ID.ToString()}";
				Query = $"{Query} AND afeat_journ_id = 0";
				modGlobalVars.snp_TransAircraft_Features.Open(Query, modAdminCommon.CLIENT_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
				if (!(modGlobalVars.snp_TransAircraft_Features.BOF && modGlobalVars.snp_TransAircraft_Features.EOF))
				{
					modGlobalVars.snp_TransAircraft_Features.MoveFirst();
				}
				modGlobalVars.snp_TransAircraft_Features.ActiveConnection = null;

				strStatus = "Query 9";
				// *********************************************************
				// Selecting 'Aircraft_Avionics'
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Selecting Aircraft Avionics Copy ...", Color.Blue);
				Query = $"SELECT * FROM Aircraft_Avionics WITH(NOLOCK) WHERE av_ac_id = {in_Aircraft_ID.ToString()}";
				Query = $"{Query} AND av_ac_journ_id = 0";
				modGlobalVars.snp_TransAircraft_Avionics.Open(Query, modAdminCommon.CLIENT_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
				if (!(modGlobalVars.snp_TransAircraft_Avionics.BOF && modGlobalVars.snp_TransAircraft_Avionics.EOF))
				{
					modGlobalVars.snp_TransAircraft_Avionics.MoveFirst();
				}
				modGlobalVars.snp_TransAircraft_Avionics.ActiveConnection = null;

				strStatus = "Query 10";

				// *************************************************
				// Selecting 'Aircraft_Certified' table row
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Select Aircraft Certified Copy ...", Color.Blue);
				Query = $"SELECT * FROM Aircraft_Certified WITH(NOLOCK) WHERE accert_ac_id = {in_Aircraft_ID.ToString()}";
				Query = $"{Query} AND accert_ac_journ_id = 0";
				modGlobalVars.snp_TransAircraft_Certified.Open(Query, modAdminCommon.CLIENT_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
				if (!(modGlobalVars.snp_TransAircraft_Certified.BOF && modGlobalVars.snp_TransAircraft_Certified.EOF))
				{
					modGlobalVars.snp_TransAircraft_Certified.MoveFirst();
				}
				modGlobalVars.snp_TransAircraft_Certified.ActiveConnection = null;


				strStatus = "Query 11";

				// ************************************************
				// Selecting 'AIRCRAFT_DETAILS' table row
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Selecting Aircraft Details Copy ... ", Color.Blue);
				Query = $"SELECT * FROM Aircraft_Details WITH(NOLOCK) WHERE adet_ac_id = {in_Aircraft_ID.ToString()}";
				Query = $"{Query} AND adet_journ_id = 0";
				modGlobalVars.snp_TransAircraft_Details.Open(Query, modAdminCommon.CLIENT_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
				if (!(modGlobalVars.snp_TransAircraft_Details.BOF && modGlobalVars.snp_TransAircraft_Details.EOF))
				{
					modGlobalVars.snp_TransAircraft_Details.MoveFirst();
				}
				modGlobalVars.snp_TransAircraft_Details.ActiveConnection = null;

				strStatus = "Query 12";

				// ***************************************************
				// Selecting 'Aircraft_Specification' data
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Selecting Aircraft Specifications Copy ...", Color.Blue);
				Query = $"SELECT * FROM Aircraft_Specification WITH(NOLOCK)  WHERE acspec_ac_id = {in_Aircraft_ID.ToString()}";
				Query = $"{Query} AND acspec_ac_journ_id = 0";
				modGlobalVars.snp_TransAircraft_Specification.Open(Query, modAdminCommon.CLIENT_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
				if (!(modGlobalVars.snp_TransAircraft_Specification.BOF && modGlobalVars.snp_TransAircraft_Specification.EOF))
				{
					modGlobalVars.snp_TransAircraft_Specification.MoveFirst();
				}
				modGlobalVars.snp_TransAircraft_Specification.ActiveConnection = null;

				strStatus = "Query 13";

				// ***********************************************
				// Selecting  'Aircraft_FAA_Document' table row
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Selecting Aircraft FAA Documents Copy ", Color.Blue);
				Query = $"SELECT * FROM Aircraft_FAA_Document WITH(NOLOCK) WHERE acfaa_ac_id = {in_Aircraft_ID.ToString()}";
				Query = $"{Query} AND acfaa_journ_id = 0";
				modGlobalVars.snp_TransAircraft_FAA_Document.Open(Query, modAdminCommon.CLIENT_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
				if (!(modGlobalVars.snp_TransAircraft_FAA_Document.BOF && modGlobalVars.snp_TransAircraft_FAA_Document.EOF))
				{
					modGlobalVars.snp_TransAircraft_FAA_Document.MoveFirst();
				}
				modGlobalVars.snp_TransAircraft_FAA_Document.ActiveConnection = null;

				strStatus = " end";

				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
				result = true;
				Cursor.Current = CursorHelper.CursorDefault;
			}
			catch (System.Exception excep)
			{

				strStatus = $"{excep.Message} {strStatus} AC={in_Aircraft_ID.ToString()}";

				modAdminCommon.Report_Error($"Aircraft_History_Get_Recordsets: {strStatus} Qry={Query}");

				Cursor.Current = CursorHelper.CursorDefault;
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);

				result = false;
			}

			return result;
		}

		internal static bool Aircraft_Buyer_Get_Recordset(int in_company_id, int in_Contact_ID)
		{

			bool result = false;
			string Query = "";
			string strStatus = "";
			int lError = 0; // Hold The Error Number Value
			string strError = ""; // Hold The Error Description Value

			try
			{

				modAdminCommon.Open_Client_Connection();

				// CREATE THE BUYER COMPANY RECORDSET
				strStatus = "snp_Buyer_Company";
				if (modGlobalVars.snp_Buyer_Company == null)
				{
					modGlobalVars.snp_Buyer_Company = new ADORecordSetHelper();
				}

				if (modGlobalVars.snp_Buyer_Company.State == ConnectionState.Open)
				{
					modGlobalVars.snp_Buyer_Company.Close();
				}

				// CREATE THE BUYER CONTACTS RECORDSET
				strStatus = "snp_Buyer_Contacts";
				if (modGlobalVars.snp_Buyer_Contacts == null)
				{
					modGlobalVars.snp_Buyer_Contacts = new ADORecordSetHelper();
				}

				if (modGlobalVars.snp_Buyer_Contacts.State == ConnectionState.Open)
				{
					modGlobalVars.snp_Buyer_Contacts.Close();
				}

				// CREATE THE BUYER COMPANY PHONES RECORDSET
				strStatus = "snp_Buyer_Company_Phones";
				if (modGlobalVars.snp_Buyer_Company_Phones == null)
				{
					modGlobalVars.snp_Buyer_Company_Phones = new ADORecordSetHelper();
				}

				if (modGlobalVars.snp_Buyer_Company_Phones.State == ConnectionState.Open)
				{
					modGlobalVars.snp_Buyer_Company_Phones.Close();
				}

				// CREATE THE BUYER COMPANY BUSINESS TYPES RECORDSET
				strStatus = "snp_Buyer_Company_Btypes";
				if (modGlobalVars.snp_Buyer_Company_Btypes == null)
				{
					modGlobalVars.snp_Buyer_Company_Btypes = new ADORecordSetHelper();
				}

				if (modGlobalVars.snp_Buyer_Company_Btypes.State == ConnectionState.Open)
				{
					modGlobalVars.snp_Buyer_Company_Btypes.Close();
				}

				// CREATE THE BUYER COMPANY CERTs RECORDSET
				strStatus = "snp_Buyer_Company_Certs";
				if (modGlobalVars.snp_Buyer_Company_Certs == null)
				{
					modGlobalVars.snp_Buyer_Company_Certs = new ADORecordSetHelper();
				}

				if (modGlobalVars.snp_Buyer_Company_Certs.State == ConnectionState.Open)
				{
					modGlobalVars.snp_Buyer_Company_Certs.Close();
				}

				Cursor.Current = Cursors.WaitCursor;
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Selecting a Snapshot of Buyer Information", Color.Blue);

				result = false;

				// ********************************************
				// GET BUYER COMPANY RECORD
				strStatus = "Select Company";
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Selecting Buyer Company Copy ...", Color.Blue);
				Query = "SELECT * FROM Company WITH(NOLOCK)";
				Query = $"{Query} where comp_id = {in_company_id.ToString()}";
				Query = $"{Query} AND comp_journ_id=0";
				modGlobalVars.snp_Buyer_Company.Open(Query, modAdminCommon.CLIENT_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
				if (!(modGlobalVars.snp_Buyer_Company.BOF && modGlobalVars.snp_Buyer_Company.EOF))
				{
					modGlobalVars.snp_Buyer_Company.MoveFirst();
				}
				else
				{
					return result;
				}
				modGlobalVars.snp_Buyer_Company.ActiveConnection = null;

				// ********************************************
				// GET ALL COMPANY PHONE RECORDS FOR THE BUYER
				strStatus = "Select Phone Numbers";
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Selecting Aircraft Company Phone Number Copies ...", Color.Blue);
				Query = "SELECT * FROM Phone_Numbers WITH(NOLOCK)";
				Query = $"{Query} where pnum_comp_id = {in_company_id.ToString()}";
				Query = $"{Query} AND pnum_journ_id = 0";
				// get phone numbers for just this company
				if (in_Contact_ID > 0)
				{
					Query = $"{Query} AND (pnum_contact_id = 0 or pnum_contact_id = {in_Contact_ID.ToString()}) ";
				}
				else
				{
					Query = $"{Query} AND (pnum_contact_id = 0) ";
				}
				//Query = Query & " AND pnum_contact_id = 0"
				// or contact id = contact id provided

				modGlobalVars.snp_Buyer_Company_Phones.Open(Query, modAdminCommon.CLIENT_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
				if (!(modGlobalVars.snp_Buyer_Company_Phones.BOF && modGlobalVars.snp_Buyer_Company_Phones.EOF))
				{
					modGlobalVars.snp_Buyer_Company_Phones.MoveFirst();
				}
				modGlobalVars.snp_Buyer_Company_Phones.ActiveConnection = null;

				// ********************************************
				// GET ALL CONTACT RECORDS FOR THE BUYER
				strStatus = "Select Aircraft Contacts";
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Selecting Aircraft Contacts Copies ...", Color.Blue);
				Query = "SELECT * FROM Contact WITH(NOLOCK)";
				Query = $"{Query} WHERE contact_comp_id = {in_company_id.ToString()}";
				Query = $"{Query} AND contact_journ_id = 0";
				Query = $"{Query} AND contact_id = {in_Contact_ID.ToString()}";
				modGlobalVars.snp_Buyer_Contacts.Open(Query, modAdminCommon.CLIENT_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(modGlobalVars.snp_Buyer_Contacts.BOF && modGlobalVars.snp_Buyer_Contacts.EOF))
				{
					modGlobalVars.snp_Buyer_Contacts.MoveFirst();
				}

				modGlobalVars.snp_Buyer_Contacts.ActiveConnection = null;

				// ********************************************
				// GET ALL BUSINESS TYPE RECORDS FOR THE BUYER
				strStatus = "Select Buyer Business Types";
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Selecting Buyer Business Types ...", Color.Blue);
				Query = "SELECT * FROM Business_Type_Reference WITH(NOLOCK)";
				Query = $"{Query} WHERE bustypref_comp_id ={in_company_id.ToString()}";
				Query = $"{Query} AND bustypref_journ_id=0";
				modGlobalVars.snp_Buyer_Company_Btypes.Open(Query, modAdminCommon.CLIENT_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
				if (!(modGlobalVars.snp_Buyer_Company_Btypes.BOF && modGlobalVars.snp_Buyer_Company_Btypes.EOF))
				{
					modGlobalVars.snp_Buyer_Company_Btypes.MoveFirst();
				}
				modGlobalVars.snp_Buyer_Company_Btypes.ActiveConnection = null;

				// ********************************************
				// GET ALL BUSINESS CERT RECORDS FOR THE BUYER
				strStatus = "Select Buyer Certifications";
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Selecting Buyer Certifications ...", Color.Blue);
				Query = $"SELECT * FROM Company_Certification WITH(NOLOCK)  WHERE ccert_comp_id ={in_company_id.ToString()}";
				Query = $"{Query} AND ccert_journ_id=0";
				modGlobalVars.snp_Buyer_Company_Certs.Open(Query, modAdminCommon.CLIENT_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
				if (!(modGlobalVars.snp_Buyer_Company_Certs.BOF && modGlobalVars.snp_Buyer_Company_Certs.EOF))
				{
					modGlobalVars.snp_Buyer_Company_Certs.MoveFirst();
				}
				modGlobalVars.snp_Buyer_Company_Certs.ActiveConnection = null;

				result = true;
				Cursor.Current = CursorHelper.CursorDefault;
			}
			catch (System.Exception excep)
			{

				// 10/11/2002 - By David D. Cruger; Hold These Error Values As the RollbackTrans will clear them
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lError = Information.Err().Number;
				strError = excep.Message;

				Cursor.Current = CursorHelper.CursorDefault;
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);

				// 10/11/2002 - By David D. Cruger; Add the Held Error Values to the Report_Error Procedure
				Information.Err().Number = lError;
				Information.Err().Description = strError;
				modAdminCommon.Report_Error($"Aircraft_Buyer_Get_Recordset: [{strStatus}]  Query={Query} AC={in_company_id.ToString()}");

				result = false;
			}

			return result;
		}

		internal static void Aircraft_History_Create_Recordsets()
		{

			string strStatus = "";

			try
			{

				modAdminCommon.Open_Client_Connection();

				// CREATE THE AIRCRAFT RECORDSET
				strStatus = "snp_TransAircraft";
				if (modGlobalVars.snp_TransAircraft == null)
				{
					modGlobalVars.snp_TransAircraft = new ADORecordSetHelper();
				}

				if (modGlobalVars.snp_TransAircraft.State == ConnectionState.Open)
				{
					modGlobalVars.snp_TransAircraft.Close();
				}

				// CREATE THE AIRCRAFT REFERENCE RECORDSET
				strStatus = "snp_TransAircraft_Reference";
				if (modGlobalVars.snp_TransAircraft_Reference == null)
				{
					modGlobalVars.snp_TransAircraft_Reference = new ADORecordSetHelper();
				}

				if (modGlobalVars.snp_TransAircraft_Reference.State == ConnectionState.Open)
				{
					modGlobalVars.snp_TransAircraft_Reference.Close();
				}

				// RTW - HOLD - put in copy of recordset for share relationships
				// CREATE THE SHARE REFERENCE RECORDSET
				strStatus = "snp_TransShare_Reference";
				if (modGlobalVars.snp_TransShare_Reference == null)
				{
					modGlobalVars.snp_TransShare_Reference = new ADORecordSetHelper();
				}

				if (modGlobalVars.snp_TransShare_Reference.State == ConnectionState.Open)
				{
					modGlobalVars.snp_TransShare_Reference.Close();
				}

				// CREATE THE AIRCRAFT FEATURES RECORDSET
				strStatus = "snp_TransAircraft_Features";
				if (modGlobalVars.snp_TransAircraft_Features == null)
				{
					modGlobalVars.snp_TransAircraft_Features = new ADORecordSetHelper();
				}

				if (modGlobalVars.snp_TransAircraft_Features.State == ConnectionState.Open)
				{
					modGlobalVars.snp_TransAircraft_Features.Close();
				}

				// CREATE THE AIRCRAFT AVIONICS RECORDSET
				strStatus = "snp_TransAircraft_Avionics";
				if (modGlobalVars.snp_TransAircraft_Avionics == null)
				{
					modGlobalVars.snp_TransAircraft_Avionics = new ADORecordSetHelper();
				}

				if (modGlobalVars.snp_TransAircraft_Avionics.State == ConnectionState.Open)
				{
					modGlobalVars.snp_TransAircraft_Avionics.Close();
				}

				// CREATE THE AIRCRAFT CERTIFIED RECORDSET
				strStatus = "snp_TransAircraft_Certified";
				if (modGlobalVars.snp_TransAircraft_Certified == null)
				{
					modGlobalVars.snp_TransAircraft_Certified = new ADORecordSetHelper();
				}

				if (modGlobalVars.snp_TransAircraft_Certified.State == ConnectionState.Open)
				{
					modGlobalVars.snp_TransAircraft_Certified.Close();
				}

				// CREATE THE AIRCRAFT SPECIFICATION RECORDSET
				strStatus = "snp_TransAircraft_Specification";
				if (modGlobalVars.snp_TransAircraft_Specification == null)
				{
					modGlobalVars.snp_TransAircraft_Specification = new ADORecordSetHelper();
				}

				if (modGlobalVars.snp_TransAircraft_Specification.State == ConnectionState.Open)
				{
					modGlobalVars.snp_TransAircraft_Specification.Close();
				}

				// CREATE THE AIRCRAFT DETAILS RECORDSET
				strStatus = "snp_TransAircraft_Details";
				if (modGlobalVars.snp_TransAircraft_Details == null)
				{
					modGlobalVars.snp_TransAircraft_Details = new ADORecordSetHelper();
				}

				if (modGlobalVars.snp_TransAircraft_Details.State == ConnectionState.Open)
				{
					modGlobalVars.snp_TransAircraft_Details.Close();
				}

				// CREATE THE AIRCRAFT FAA DOCUMENT RECORDSET
				strStatus = "snp_TransAircraft_FAA_Document";
				if (modGlobalVars.snp_TransAircraft_FAA_Document == null)
				{
					modGlobalVars.snp_TransAircraft_FAA_Document = new ADORecordSetHelper();
				}

				if (modGlobalVars.snp_TransAircraft_FAA_Document.State == ConnectionState.Open)
				{
					modGlobalVars.snp_TransAircraft_FAA_Document.Close();
				}

				//******************************************************
				// CREATE AIRCRAFT COMPANY RECORDSETS

				// CREATE THE AIRCRAFT COMPANY RECORDSET
				strStatus = "snp_TransAircraft_Companies";
				if (modGlobalVars.snp_TransAircraft_Companies == null)
				{
					modGlobalVars.snp_TransAircraft_Companies = new ADORecordSetHelper();
				}

				if (modGlobalVars.snp_TransAircraft_Companies.State == ConnectionState.Open)
				{
					modGlobalVars.snp_TransAircraft_Companies.Close();
				}

				// CREATE THE AIRCRAFT CONTACTS RECORDSET
				strStatus = "snp_TransAircraft_Contacts";
				if (modGlobalVars.snp_TransAircraft_Contacts == null)
				{
					modGlobalVars.snp_TransAircraft_Contacts = new ADORecordSetHelper();
				}

				if (modGlobalVars.snp_TransAircraft_Contacts.State == ConnectionState.Open)
				{
					modGlobalVars.snp_TransAircraft_Contacts.Close();
				}

				// CREATE THE AIRCRAFT COMPANY PHONES RECORDSET
				strStatus = "snp_TransAircraft_Company_Phones";
				if (modGlobalVars.snp_TransAircraft_Company_Phones == null)
				{
					modGlobalVars.snp_TransAircraft_Company_Phones = new ADORecordSetHelper();
				}

				if (modGlobalVars.snp_TransAircraft_Company_Phones.State == ConnectionState.Open)
				{
					modGlobalVars.snp_TransAircraft_Company_Phones.Close();
				}

				// CREATE THE AIRCRAFT COMPANY BUSINESS TYPES RECORDSET
				strStatus = "snp_TransAircraft_Company_Btypes";
				if (modGlobalVars.snp_TransAircraft_Company_Btypes == null)
				{
					modGlobalVars.snp_TransAircraft_Company_Btypes = new ADORecordSetHelper();
				}

				if (modGlobalVars.snp_TransAircraft_Company_Btypes.State == ConnectionState.Open)
				{
					modGlobalVars.snp_TransAircraft_Company_Btypes.Close();
				}


				// CREATE THE AIRCRAFT COMPANY CERTIFICATION TYPES RECORDSET
				strStatus = "snp_TransAircraft_Company_Certs";
				if (modGlobalVars.snp_TransAircraft_Company_Certs == null)
				{
					modGlobalVars.snp_TransAircraft_Company_Certs = new ADORecordSetHelper();
				}

				if (modGlobalVars.snp_TransAircraft_Company_Certs.State == ConnectionState.Open)
				{
					modGlobalVars.snp_TransAircraft_Company_Certs.Close();
				}
			}
			catch (System.Exception excep)
			{

				strStatus = $"{excep.Message} {strStatus}";
				modAdminCommon.Report_Error($"Aircraft_History_Create_Recordsets_Error: [{strStatus}]", "Aircraft History");
			}


		}


		internal static string CleanSpecial(string string_to_replace)
		{

			string result = "";
			result = string_to_replace;

			return StringsHelper.Replace(result, "\t", "", 1, -1, CompareMethod.Binary);
		}
		internal static void Aircraft_History_Close_Recordsets()
		{

			string strStatus = "";

			try
			{

				// CLOSE THE AIRCRAFT HISTORY RECORDSET
				strStatus = "snp_TransAircraft";
				if (modGlobalVars.snp_TransAircraft != null)
				{
					if (modGlobalVars.snp_TransAircraft.State == ConnectionState.Open)
					{
						modGlobalVars.snp_TransAircraft.Close();
					}
					modGlobalVars.snp_TransAircraft = null;
				}

				// CLOSE THE AIRCRAFT REFERENCE RECORDSET
				strStatus = "snp_TransAircraft_Reference";
				if (modGlobalVars.snp_TransAircraft_Reference != null)
				{
					if (modGlobalVars.snp_TransAircraft_Reference.State == ConnectionState.Open)
					{
						modGlobalVars.snp_TransAircraft_Reference.Close();
					}
					modGlobalVars.snp_TransAircraft_Reference = null;
				}

				// CLOSE THE AIRCRAFT REFERENCE RECORDSET
				strStatus = "snp_TransShare_Reference";
				if (modGlobalVars.snp_TransShare_Reference != null)
				{
					if (modGlobalVars.snp_TransShare_Reference.State == ConnectionState.Open)
					{
						modGlobalVars.snp_TransShare_Reference.Close();
					}
					modGlobalVars.snp_TransShare_Reference = null;
				}
				//
				// CLOSE THE AIRCRAFT FEATURES RECORDSET
				strStatus = "snp_TransAircraft_Features";
				if (modGlobalVars.snp_TransAircraft_Features != null)
				{
					if (modGlobalVars.snp_TransAircraft_Features.State == ConnectionState.Open)
					{
						modGlobalVars.snp_TransAircraft_Features.Close();
					}
					modGlobalVars.snp_TransAircraft_Features = null;
				}

				// CLOSE THE AIRCRAFT AVIONICS RECORDSET
				strStatus = "snp_TransAircraft_Avionics";
				if (modGlobalVars.snp_TransAircraft_Avionics != null)
				{
					if (modGlobalVars.snp_TransAircraft_Avionics.State == ConnectionState.Open)
					{
						modGlobalVars.snp_TransAircraft_Avionics.Close();
					}
					modGlobalVars.snp_TransAircraft_Avionics = null;
				}

				// CLOSE THE AIRCRAFT CERTIFIED RECORDSET
				strStatus = "snp_TransAircraft_Certified";
				if (modGlobalVars.snp_TransAircraft_Certified != null)
				{
					if (modGlobalVars.snp_TransAircraft_Certified.State == ConnectionState.Open)
					{
						modGlobalVars.snp_TransAircraft_Certified.Close();
					}
					modGlobalVars.snp_TransAircraft_Certified = null;
				}

				// CLOSE THE AIRCRAFT SPECIFICATION RECORDSET
				strStatus = "snp_TransAircraft_Specification";
				if (modGlobalVars.snp_TransAircraft_Specification != null)
				{
					if (modGlobalVars.snp_TransAircraft_Specification.State == ConnectionState.Open)
					{
						modGlobalVars.snp_TransAircraft_Specification.Close();
					}
					modGlobalVars.snp_TransAircraft_Specification = null;
				}

				// CLOSE THE AIRCRAFT DETAILS RECORDSET
				strStatus = "snp_TransAircraft_Details";
				if (modGlobalVars.snp_TransAircraft_Details != null)
				{
					if (modGlobalVars.snp_TransAircraft_Details.State == ConnectionState.Open)
					{
						modGlobalVars.snp_TransAircraft_Details.Close();
					}
					modGlobalVars.snp_TransAircraft_Details = null;
				}

				// CLOSE THE AIRCRAFT FAA DOCUMENT RECORDSET
				strStatus = "snp_TransAircraft_FAA_Document";
				if (modGlobalVars.snp_TransAircraft_FAA_Document != null)
				{
					if (modGlobalVars.snp_TransAircraft_FAA_Document.State == ConnectionState.Open)
					{
						modGlobalVars.snp_TransAircraft_FAA_Document.Close();
					}
					modGlobalVars.snp_TransAircraft_FAA_Document = null;
				}

				// CLOSE THE AIRCRAFT COMPANIES RECORDSET
				strStatus = "snp_TransAircraft_Companies";
				if (modGlobalVars.snp_TransAircraft_Companies != null)
				{
					if (modGlobalVars.snp_TransAircraft_Companies.State == ConnectionState.Open)
					{
						modGlobalVars.snp_TransAircraft_Companies.Close();
					}
					modGlobalVars.snp_TransAircraft_Companies = null;
				}

				strStatus = "snp_TransAircraft_otherCompanies";
				if (modGlobalVars.snp_TransAircraft_OtherCompanies != null)
				{
					if (modGlobalVars.snp_TransAircraft_OtherCompanies.State == ConnectionState.Open)
					{
						modGlobalVars.snp_TransAircraft_OtherCompanies.Close();
					}
					modGlobalVars.snp_TransAircraft_OtherCompanies = null;
				}

				// CLOSE THE AIRCRAFT CONTACTS RECORDSET
				strStatus = "snp_TransAircraft_Contacts";
				if (modGlobalVars.snp_TransAircraft_Contacts != null)
				{
					if (modGlobalVars.snp_TransAircraft_Contacts.State == ConnectionState.Open)
					{
						modGlobalVars.snp_TransAircraft_Contacts.Close();
					}
					modGlobalVars.snp_TransAircraft_Contacts = null;
				}

				// CLOSE THE AIRCRAFT COMPANY PHONES RECORDSET
				strStatus = "snp_TransAircraft_Company_Phones";
				if (modGlobalVars.snp_TransAircraft_Company_Phones != null)
				{
					if (modGlobalVars.snp_TransAircraft_Company_Phones.State == ConnectionState.Open)
					{
						modGlobalVars.snp_TransAircraft_Company_Phones.Close();
					}
					modGlobalVars.snp_TransAircraft_Company_Phones = null;
				}

				// CLOSE THE AIRCRAFT COMPANY BUSINESS TYPES RECORDSET
				strStatus = "snp_TransAircraft_Company_Btypes";
				if (modGlobalVars.snp_TransAircraft_Company_Btypes != null)
				{
					if (modGlobalVars.snp_TransAircraft_Company_Btypes.State == ConnectionState.Open)
					{
						modGlobalVars.snp_TransAircraft_Company_Btypes.Close();
					}
					modGlobalVars.snp_TransAircraft_Company_Btypes = null;
				}

				// CLOSE THE AIRCRAFT COMPANY BUSINESS Certs RECORDSET
				strStatus = "snp_TransAircraft_Company_Certs";
				if (modGlobalVars.snp_TransAircraft_Company_Certs != null)
				{
					if (modGlobalVars.snp_TransAircraft_Company_Certs.State == ConnectionState.Open)
					{
						modGlobalVars.snp_TransAircraft_Company_Certs.Close();
					}
					modGlobalVars.snp_TransAircraft_Company_Certs = null;
				}

				// **********************************************
				// CLOSE BUYER COMPANY RECORDSETS

				// CLOSE THE BUYER COMPANIES RECORDSET
				strStatus = "snp_Buyer_Company";
				if (modGlobalVars.snp_Buyer_Company != null)
				{
					if (modGlobalVars.snp_Buyer_Company.State == ConnectionState.Open)
					{
						modGlobalVars.snp_Buyer_Company.Close();
					}
					modGlobalVars.snp_Buyer_Company = null;
				}

				// CLOSE THE BUYER CONTACTS RECORDSET
				strStatus = "snp_Buyer_Contacts";
				if (modGlobalVars.snp_Buyer_Contacts != null)
				{
					if (modGlobalVars.snp_Buyer_Contacts.State == ConnectionState.Open)
					{
						modGlobalVars.snp_Buyer_Contacts.Close();
					}
					modGlobalVars.snp_Buyer_Contacts = null;
				}

				// CLOSE THE BUYER COMPANY PHONES RECORDSET
				strStatus = "snp_Buyer_Company_Phones";
				if (modGlobalVars.snp_Buyer_Company_Phones != null)
				{
					if (modGlobalVars.snp_Buyer_Company_Phones.State == ConnectionState.Open)
					{
						modGlobalVars.snp_Buyer_Company_Phones.Close();
					}
					modGlobalVars.snp_Buyer_Company_Phones = null;
				}

				// CLOSE THE BUYER COMPANY BUSINESS TYPES RECORDSET
				strStatus = "snp_Buyer_Company_Btypes";
				if (modGlobalVars.snp_Buyer_Company_Btypes != null)
				{
					if (modGlobalVars.snp_Buyer_Company_Btypes.State == ConnectionState.Open)
					{
						modGlobalVars.snp_Buyer_Company_Btypes.Close();
					}
					modGlobalVars.snp_Buyer_Company_Btypes = null;
				}

				// CLOSE THE BUYER COMPANY CERT RECORDSET
				strStatus = "snp_Buyer_Company_Certs";
				if (modGlobalVars.snp_Buyer_Company_Certs != null)
				{
					if (modGlobalVars.snp_Buyer_Company_Certs.State == ConnectionState.Open)
					{
						modGlobalVars.snp_Buyer_Company_Certs.Close();
					}
					modGlobalVars.snp_Buyer_Company_Certs = null;
				}
			}
			catch
			{

				modAdminCommon.Report_Error($"Aircraft_History_Close_Recordsets_Error: [{strStatus}]", "Aircraft History");
			}


		}

		internal static bool Validate_Trans_Type(string Trans_Type)
		{
			bool result = false;
			try
			{

				string Query = "";
				ADORecordSetHelper snp_SUB = new ADORecordSetHelper(); //8/11/05 aey dao.Recordset
				string FLDS = "";
				string VALS = "";
				string subcategory_name = "";
				string M = "";
				bool bStartTrans = false;
				bStartTrans = false;

				//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				// Validate a Transaction Type and force the user to enter a transaction description
				// if the Transaction Type is not in the 'Journal_Category' table.
				//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				result = true;

				// if we are not in a transaction and start one
				if (modAdminCommon.ADO_Transaction("CheckStatus") == 0)
				{
					modAdminCommon.ADO_Transaction("BeginTrans");
					bStartTrans = true;
				}

				Query = $"SELECT * FROM Journal_Category WITH(NOLOCK) WHERE jcat_category_code = 'AH' AND jcat_subcategory_code = '{Trans_Type}'";
				snp_SUB.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (snp_SUB.BOF && snp_SUB.EOF)
				{

					if ((frm_Main_Menu.DefInstance.lbl_DatabaseType.Text.Trim().ToLower().IndexOf(("LIVE").ToLower()) + 1) > 1)
					{
						modEmail.EMail_Message("Homebase", "jetnet@jetnet.com", "rick@jetnet.com", "mike@mvintech.com, andrew@jetnet.com", "", "Unknown Transaction Type", $"'{Trans_Type}' has been inserted into the Journal_Category table as an UNKNOWN TRANSACTION TYPE.{Environment.NewLine}{Environment.NewLine}This was inserted by {modCommon.GetUserName(modAdminCommon.gbl_User_ID)}", "", false);
					}
					else
					{
						modAdminCommon.Report_Error($"'{Trans_Type}' has been inserted into the Journal_Category table as an UNKNOWN TRANSACTION TYPE.{Environment.NewLine}{Environment.NewLine}This was inserted by {modCommon.GetUserName(modAdminCommon.gbl_User_ID)}");
					}

					subcategory_name = "UNKNOWN TRANSACTION TYPE";
					if (subcategory_name.Trim() != modGlobalVars.cEmptyString)
					{
						FLDS = "INSERT INTO Journal_Category (";
						VALS = ") VALUES (";
						FLDS = $"{FLDS}jcat_category_name ";
						VALS = $"{VALS}'Aircraft History' ";
						FLDS = $"{FLDS}, jcat_category_code ";
						VALS = $"{VALS}, 'AH' ";
						FLDS = $"{FLDS}, jcat_subcategory_name ";
						VALS = $"{VALS}, '{subcategory_name}' ";
						FLDS = $"{FLDS}, jcat_subcategory_code ";
						VALS = $"{VALS}, '{Trans_Type}' ";
						Query = $"{FLDS}{VALS})";
						DbCommand TempCommand = null;
						TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
						TempCommand.CommandText = Query;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
						TempCommand.ExecuteNonQuery();
					}
					else
					{

						MessageBox.Show("No Transaction Description supplied, Transaction aborted.", "Validate_Trans_Type : TRANSACTION ABORTED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						result = false;
					}
				}
				else
				{
					snp_SUB.Close();
				}

				// if we were in a transaction then commit it if we started it
				if (modAdminCommon.ADO_Transaction("CheckStatus") == 1 && bStartTrans)
				{
					modAdminCommon.ADO_Transaction("CommitTrans");
				}

				snp_SUB = null;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Validate_Trans_Type_Error: {Information.Err().Number.ToString()} {excep.Message}");
			}

			return result;
		}

		internal static string GetUserName(string inUserID)
		{

			string result = "";
			string Query = "";
			ADORecordSetHelper snpUserName = new ADORecordSetHelper(); //8/1/05 aey converted to ado

			try
			{

				Query = $"SELECT user_first_name FROM [User] WITH(NOLOCK) WHERE user_id = '{inUserID}'";

				snpUserName.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpUserName.BOF && snpUserName.EOF))
				{
					snpUserName.MoveFirst();
					result = ($"{Convert.ToString(snpUserName["user_first_name"])}").Trim();
				}
				else
				{
					result = "";
				}

				snpUserName.Close();
				snpUserName = null;
			}
			catch (System.Exception excep)
			{
				modAdminCommon.Report_Error($"GetUserName_Error: {excep.Message} {inUserID}", "User_Accounts");
			}
			return result;
		}

		// 03/04/2014 - By David D. Cruger; Added This Function
		internal static string GetFullUserName(string strUserId)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strResults = "";

			try
			{

				strResults = "";

				strQuery1 = "SELECT user_first_name, user_last_name ";
				strQuery1 = $"{strQuery1}FROM [User] WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (user_id = '{strUserId}') ";
				strQuery1 = $"{strQuery1}AND (user_password <> 'Inactive') ";

				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{
					strResults = $"{($"{Convert.ToString(rstRec1["user_first_name"])} ").Trim()} {($"{Convert.ToString(rstRec1["user_last_name"])} ").Trim()}";
				}

				rstRec1.Close();
				rstRec1 = null;


				return strResults;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"GetFullUserName_Error: {excep.Message} {strUserId}", "User_Accounts");
			}
			return "";
		} // GetFullUserName

		// 01/29/2016 - By David D. Cruger; Added This Function
		internal static string GetUserEMailAddress(string strUserId)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strResults = "";

			try
			{

				strResults = "";

				strQuery1 = "SELECT user_email_address  FROM [User] WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (user_id = '{strUserId}')";

				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{
					strResults = ($"{Convert.ToString(rstRec1["user_email_address"])} ").Trim();
				}

				rstRec1.Close();
				rstRec1 = null;


				return strResults;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"GetUserEMailAddress_Error: {excep.Message} {strUserId}", "User_Accounts");
			}
			return "";
		} // GetUserEMailAddress

		// 01/29/2016 - By David D. Cruger; Added This Procedure
		internal static void GetAircraftPrimaryContactNameEMailAddress(int lACId, ref int lCompId, ref int lContactId, ref string strToEMail, ref string strToName)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			try
			{

				lCompId = 0;
				lContactId = 0;
				strToName = "";
				strToEMail = "";

				strQuery1 = "SELECT TOP 1 cref_comp_id, cref_contact_id, contact_email_address, ";
				strQuery1 = $"{strQuery1}dbo.CreateContactFullNameTitle(contact_sirname, contact_first_name, contact_middle_initial, contact_last_name, contact_suffix, '') As Contact ";
				strQuery1 = $"{strQuery1}FROM Aircraft WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}INNER JOIN Aircraft_Reference WITH (NOLOCK) ON cref_ac_id = ac_id AND cref_journ_id = ac_journ_id ";
				strQuery1 = $"{strQuery1}INNER JOIN Contact WITH (NOLOCK) ON contact_comp_id = cref_comp_id AND contact_id = cref_contact_id AND contact_journ_id = cref_journ_id ";
				strQuery1 = $"{strQuery1}WHERE (ac_id = {lACId.ToString()}) ";
				strQuery1 = $"{strQuery1}AND (ac_journ_id = 0) AND (cref_primary_poc_flag = 'Y') ";
				strQuery1 = $"{strQuery1}AND (cref_contact_id > 0)  AND (contact_email_address IS NOT NULL) ";
				strQuery1 = $"{strQuery1}AND (contact_email_address <> '') ";

				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(rstRec1["cref_comp_id"]))
					{
						lCompId = Convert.ToInt32(rstRec1["cref_comp_id"]);
					}
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(rstRec1["cref_contact_id"]))
					{
						lContactId = Convert.ToInt32(rstRec1["cref_contact_id"]);
					}
					strToName = ($"{Convert.ToString(rstRec1["CONTACT"])} ").Trim();
					strToEMail = ($"{Convert.ToString(rstRec1["contact_email_address"])} ").Trim();
				}

				rstRec1.Close();
				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"GetAircraftPrimaryContactNameEMailAddress_Error: {excep.Message}");
			}

		} // GetAircraftPrimaryContactNameEMailAddress

		internal static bool Transaction_Seller_Buyer_Insert(int in_Aircraft_ID, int in_journal_id, int in_company_id, string in_Business_Type, int in_Contact_ID, string in_Contact_Type, string in_Owner_Percent, string in_POC, int in_Sequence_No = 0, string in_Expiration_Date = "")
		{
			//  PURPOSE: THIS FUNCTION INSERTS A AIRCRAFT BUYER, SELLER, OR OWNER AS PART OF COMPLETING
			//           AN AIRCRAFT TRANSACTION
			// ----------------------------------------------------------------------------------------
			bool result = false;
			string strEReport = "";
			try
			{

				string Query = "";

				ADORecordSetHelper ado_Add_Reference = new ADORecordSetHelper(); // STRING USED FOR REPORTING SPECIFIC SPOT OF ERROR

				Cursor.Current = Cursors.WaitCursor;

				if (($"{in_POC}").Trim() == "Y" || ($"{in_POC}").Trim() == "X")
				{
					strEReport = "Clearing Primary on Reference";
					Query = "update Aircraft_Reference set cref_primary_poc_flag='N' ";
					Query = $"{Query}where cref_ac_id={in_Aircraft_ID.ToString()} ";
					Query = $"{Query}and cref_journ_id={in_journal_id.ToString()} ";
					Query = $"{Query}and cref_primary_poc_flag= '{in_POC.Trim()}' ";
					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'ADODB.ExecuteOptionEnum' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();
				}

				// FILE THE LIST OF REFERENCES AIRCRAFT REFERENCES BASED ON SPECIFIC FRACTIONAL
				// COMPANIES
				strEReport = "Setting Up Reference Add";
				if (in_Contact_Type == "97" || in_Contact_Type == "17" || in_Contact_Type == "69" || in_Contact_Type == "70")
				{
					Query = $"cref_comp_id = {in_company_id.ToString()}";
					Query = $"{Query} and cref_contact_id = {in_Contact_ID.ToString()}";
					Query = $"{Query} and cref_contact_type = '97' ";
					modGlobalVars.snp_TransShare_Reference.Filter = Query;
					if (!(modGlobalVars.snp_TransShare_Reference.BOF && modGlobalVars.snp_TransShare_Reference.EOF))
					{

						ado_Add_Reference.Open("select * from Aircraft_Reference where cref_id = -1", modAdminCommon.ADODB_Trans_conn, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);
						//ado_Add_Reference.Open "Aircraft_Reference", ADODB_Trans_conn, adOpenKeyset, adLockOptimistic, adCmdTable
					}
					else
					{
						ado_Add_Reference.Open("select * from Aircraft_Reference where cref_id = -1", modAdminCommon.ADODB_Trans_conn, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);
					}
				}
				else
				{
					ado_Add_Reference.Open("select * from Aircraft_Reference where cref_id = -1", modAdminCommon.ADODB_Trans_conn, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);
				}

				// ADD A NEW AIRCRAFT REFERENCE
				strEReport = "Creating New Reference for Input";
				int tmp_cref_id = 0;
				//UPGRADE_ISSUE: (2064) ADODB.CursorOptionEnum property CursorOptionEnum.adAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method ado_Add_Reference.Supports was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				if (ado_Add_Reference.Supports(UpgradeStubs.ADODB_CursorOptionEnum.getadAddNew()))
				{
					ado_Add_Reference.AddNew();
					ado_Add_Reference["cref_ac_id"] = in_Aircraft_ID;
					ado_Add_Reference["cref_journ_id"] = in_journal_id;
					ado_Add_Reference["cref_comp_id"] = in_company_id;
					ado_Add_Reference["cref_contact_id"] = in_Contact_ID;
					switch(in_Contact_Type)
					{
						case "13" : case "57" :  // Lessor or Lessee-Sublessor 
							if (in_Sequence_No > 0)
							{
								ado_Add_Reference["cref_transmit_seq_no"] = in_Sequence_No;
							}
							else
							{
								ado_Add_Reference["cref_transmit_seq_no"] = 99;
							} 
							break;
						case "12" : case "39" :  // lessee or sublessee 
							if (in_Sequence_No > 0)
							{
								ado_Add_Reference["cref_transmit_seq_no"] = in_Sequence_No;
							}
							else
							{
								ado_Add_Reference["cref_transmit_seq_no"] = 99;
							} 
							break;
						case "08" :  // co-owner 
							if (in_Sequence_No > 0)
							{
								ado_Add_Reference["cref_transmit_seq_no"] = in_Sequence_No;
							}
							else
							{
								ado_Add_Reference["cref_transmit_seq_no"] = 99;
							} 
							break;
						case "95" : case "00" : case "17" : case "56" : case "69" : case "91" :  //Seller or Owner or Program Holder or Previous Owner or Fractional Seller or Fractional Owner Pending Sale 
							ado_Add_Reference["cref_transmit_seq_no"] = 1; 
							 
							break;
						case "60" : case "62" :  // Registered As Purchaser (put in the registered as owner/seller) 
							ado_Add_Reference["cref_transmit_seq_no"] = 9; 
							 
							break;
						case "96" : case "51" : case "52" : case "70" :  // Purchaser or lessee (put in send as purchaser block) 
							ado_Add_Reference["cref_transmit_seq_no"] = 10; 
							 
							break;
						case "61" :  // Registered As Purchaser 
							ado_Add_Reference["cref_transmit_seq_no"] = 11; 
							break;
						case "99" : 
							ado_Add_Reference["cref_transmit_seq_no"] = 4; 
							break;
						case "42" :  // Registered As Purchaser 
							ado_Add_Reference["cref_transmit_seq_no"] = 2; 
							in_Owner_Percent = ""; 
							break;
						default:
							ado_Add_Reference["cref_transmit_seq_no"] = 99; 
							break;
					}

					ado_Add_Reference["cref_contact_type"] = in_Contact_Type;

					ado_Add_Reference["cref_owner_percent"] = Math.Abs(Conversion.Val(($"0{in_Owner_Percent}").Trim()));

					if (Strings.Len(($"{in_POC}").Trim()) > 0)
					{
						ado_Add_Reference["cref_primary_poc_flag"] = in_POC;
					}

					if (Strings.Len(in_Business_Type.Trim()) == 0)
					{
						in_Business_Type = "UI";
					}

					ado_Add_Reference["cref_business_type"] = in_Business_Type;

					if (Strings.Len(($"{in_Expiration_Date}").Trim()) > 0 && ($"{in_Expiration_Date}").Trim() != "12:00:00 AM")
					{
						ado_Add_Reference["cref_fraction_expires_date"] = in_Expiration_Date;
					}
					else
					{
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						ado_Add_Reference["cref_fraction_expires_date"] = DBNull.Value;
					}

					strEReport = "Adding the Reference";
					ado_Add_Reference.Update();
					tmp_cref_id = Convert.ToInt32(ado_Add_Reference["cref_id"]);
					// DO NOT BOTHER WITH THIS UNLESS IT'S THE RIGHT CONTACT TYPE
					// - FRACTIONAL OWNERS
					// - PROGRAM HOLDER
					// - FRACTIONAL SELLER
					// - FRACTIONAL BUYER
					strEReport = "Modify Share Reference";
					if (in_Contact_Type == "97" || in_Contact_Type == "17" || in_Contact_Type == "69" || in_Contact_Type == "70")
					{
						if (!Modify_Share_Reference(in_Aircraft_ID, in_journal_id, in_company_id, in_Contact_ID, Convert.ToInt32(Double.Parse(in_Contact_Type)), tmp_cref_id))
						{
							throw new Exception();
						}
					}
				}
				if (ado_Add_Reference.State == ConnectionState.Open)
				{
					ado_Add_Reference.Close();
				}
				ado_Add_Reference = null;

				result = true;

				Cursor.Current = CursorHelper.CursorDefault;

				return result;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Transaction_Seller_Buyer_Insert_Error ({Information.Err().Number.ToString()}) {excep.Message} : {strEReport}", "modCommon (Transaction)");
				return result;
			}
		}



		internal static bool Transaction_Save_Buyer_History(ref int in_company_id, int in_journal_id, string in_Business_Type, ADORecordSetHelper in_snp_Company, ADORecordSetHelper in_snp_Contact, ADORecordSetHelper in_snp_Company_Phones, ADORecordSetHelper in_snp_Company_Btypes, ADORecordSetHelper in_snp_Company_Certs, int in_Fractional_Owner_ID = 0, bool in_SendToWeb = true)
		{


			bool result = false;
			string errMsg = "";
			try
			{

				string Query = "";
				int i = 0;
				string CurrentDateTime = "";

				errMsg = "Start";
				CurrentDateTime = modAdminCommon.GetDateTime();

				result = false;

				// ***************************************************
				// IF BUYER COMPANY ID = 0 THEN AWAITING DOCUMENTATION
				// CREATE THE AWAITING DOCUMENTATION COMPANY AND EXIT
				errMsg = "compid=0";
				if (in_company_id == 0)
				{

					if (frm_Aircraft_Change.DefInstance.cbo_Unknown_State.Text.Trim() != "")
					{
						in_company_id = Transaction_Create_Awaiting_Documentation_Company(in_company_id, in_journal_id, frm_Aircraft_Change.DefInstance.cbo_Unknown_Country.Text.Trim(), frm_Aircraft_Change.DefInstance.cbo_Unknown_State.Text.Substring(0, Math.Min(frm_Aircraft_Change.DefInstance.cbo_Unknown_State.Text.IndexOf(", "), frm_Aircraft_Change.DefInstance.cbo_Unknown_State.Text.Length)).Trim(), in_Business_Type, in_SendToWeb);
					}
					else
					{
						in_company_id = Transaction_Create_Awaiting_Documentation_Company(in_company_id, in_journal_id, frm_Aircraft_Change.DefInstance.cbo_Unknown_Country.Text.Trim(), "", in_Business_Type, in_SendToWeb);
					}

					if (in_company_id > 0)
					{
						return true;
					}
					else
					{
						// NOT SUCCESSFUL IN CREATING AWAITING DOCUMENTATION COMPANY
						return false;
					}
				}

				// **************************************************************
				// DEFINE ALL OF THE RECORDSETS TO BE USED FOR ADDING/UPDATING
				ADORecordSetHelper ado_new_company = new ADORecordSetHelper();
				ADORecordSetHelper ad_new_contacts = new ADORecordSetHelper();
				ADORecordSetHelper ado_new_phone = new ADORecordSetHelper();
				ADORecordSetHelper ado_new_BusType = new ADORecordSetHelper();
				ADORecordSetHelper ado_new_Certs = new ADORecordSetHelper();


				// **************************************************************
				// OPEN ALL OF THE ADO RECORDSETS TO BE USED FOR ADDING/UPDATING.
				errMsg = "open tables";
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Opening Companiess for Action ... ", Color.Blue);
				ado_new_company.Open("Select * from Company where comp_id = -1", modAdminCommon.ADODB_Trans_conn, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Opening Contacts for Action ... ", Color.Blue);
				ad_new_contacts.Open("Select * from Contact where contact_id = -1", modAdminCommon.ADODB_Trans_conn, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

				// TMEP HOLD MSW  -  1/30/12
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Opening Phone Numbers for Action ... ", Color.Blue);
				//ado_new_phone.Open "Phone_Numbers", ADODB_Trans_conn, adOpenStatic, adLockOptimistic, adCmdTable
				ado_new_phone.Open("Select * from Phone_Numbers where pnum_comp_id = -1", modAdminCommon.ADODB_Trans_conn, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);


				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Opening Company Business Types for Action ... ", Color.Blue);
				ado_new_BusType.Open("Select * from Business_Type_Reference where bustypref_id = -1", modAdminCommon.ADODB_Trans_conn, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Opening Company Certs for Action ... ", Color.Blue);
				ado_new_Certs.Open("Select * from Company_Certification where ccert_id = -1", modAdminCommon.ADODB_Trans_conn, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);


				// ***************************************************************
				// SET FUNCTION STATUS TO FALSE - FAILED
				// - THEREFORE IF THE FUNCTION FAILS IT WILL KEEP THE FALSE STATUS

				Cursor.Current = Cursors.WaitCursor;


				// *******************************
				// STORE THE COMPANY INFORMATION
				errMsg = "Save comp info";
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Saving a Historical Buyer Record ... ", Color.Blue);
				if (!(in_snp_Company.BOF && in_snp_Company.EOF))
				{
					in_snp_Company.MoveFirst();

					while(!in_snp_Company.EOF)
					{
						//UPGRADE_ISSUE: (2064) ADODB.CursorOptionEnum property CursorOptionEnum.adAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_ISSUE: (2064) ADODB.Recordset method ado_new_company.Supports was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						if (ado_new_company.Supports(UpgradeStubs.ADODB_CursorOptionEnum.getadAddNew()))
						{
							ado_new_company.AddNew();
							i = 0;

							while((i < in_snp_Company.FieldsMetadata.Count))
							{
								ado_new_company[i] = in_snp_Company[i];
								i++;
							};
							if (Conversion.Val($"{in_Fractional_Owner_ID.ToString()}") > 0)
							{
								ado_new_company["comp_fractowr_id"] = Conversion.Val($"{in_Fractional_Owner_ID.ToString()}");
							}

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (Convert.IsDBNull(ado_new_company["comp_fractowr_id"]))
							{ //9/29/04 aey
								ado_new_company["comp_fractowr_id"] = 0;
							}

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (Convert.IsDBNull(ado_new_company["comp_fractowr_contact_id"]))
							{ //9/29/04 aey
								ado_new_company["comp_fractowr_contact_id"] = 0;
							}

							ado_new_company["comp_journ_id"] = in_journal_id;
							ado_new_company["comp_active_flag"] = "N";

							if (in_SendToWeb)
							{ //aey 7/28/04
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								ado_new_company["comp_action_date"] = DBNull.Value;
							}
							else
							{
								ado_new_company["comp_action_date"] = CurrentDateTime;
							}


							// ***************************************************
							// PROTECT AGAINST ADDING A DUPLICATE COMPANY RECORDS
							try
							{
								ado_new_company.Update();
								//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
							}
							catch
							{
							}
							if (ErrorHandlingHelper.ResumeNextExpr<bool>(() => Information.Err().Number == -2147217873))
							{
								try
								{ // check for duplicate error code
									ado_new_company.CancelUpdate();
								}
								catch
								{
								}
							}
							else
							{
								Exception ex = null;
								ErrorHandlingHelper.ResumeNext(out ex);
								// if error is not a duplcate use normal error handling
								if (ex != null)
								{
									try
									{
										throw new Exception();
									}
									catch
									{
									}
								}
							}


						}
						else
						{
							// If ado_new_company.Supports(adAddNew) Then
							return result;
						}
						in_snp_Company.MoveNext();
					};
				} // If Not (in_snp_Company.BOF And in_snp_Company.EOF) Then


				// ************************************
				// STORE THE CONTACT INFORMATION
				//   Debug.Print "Buyer Contacts:"
				errMsg = "Save contact info";

				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Saving a Historical Buyer Contact Records ... ", Color.Blue);
				if (!(in_snp_Contact.BOF && in_snp_Contact.EOF))
				{
					in_snp_Contact.MoveFirst();

					while(!in_snp_Contact.EOF)
					{

						//UPGRADE_ISSUE: (2064) ADODB.CursorOptionEnum property CursorOptionEnum.adAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_ISSUE: (2064) ADODB.Recordset method ad_new_contacts.Supports was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						if (ad_new_contacts.Supports(UpgradeStubs.ADODB_CursorOptionEnum.getadAddNew()))
						{
							ad_new_contacts.AddNew();
							i = 0;

							while((i < in_snp_Contact.FieldsMetadata.Count))
							{
								ad_new_contacts[i] = in_snp_Contact[i];
								i++;
							};
							ad_new_contacts["contact_journ_id"] = in_journal_id;
							//            Debug.Print in_snp_Contact!contact_comp_id & "-" & in_snp_Contact!contact_id & "-" & in_Journal_ID & ";"
							if (in_SendToWeb)
							{ //aey 7/28/04
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								ad_new_contacts["contact_action_date"] = DBNull.Value;
							}
							else
							{
								ad_new_contacts["contact_action_date"] = CurrentDateTime;
							}


							// ***************************************************
							// PROTECT AGAINST ADDING A DUPLICATE CONTACTS
							try
							{
								ad_new_contacts.Update();
								//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
							}
							catch
							{
							}
							if (ErrorHandlingHelper.ResumeNextExpr<bool>(() => Information.Err().Number == -2147217873))
							{
								try
								{ // check for duplicate error code
									ad_new_contacts.CancelUpdate();
								}
								catch
								{
								}
							}
							else
							{
								Exception ex_2 = null;
								ErrorHandlingHelper.ResumeNext(out ex_2);
								// if error is not a duplcate use normal error handling
								if (ex_2 != null)
								{
									try
									{
										throw new Exception();
									}
									catch
									{
									}
								}
							}


						}
						else
						{
							// If ad_new_contacts.Supports(adAddNew) Then
							return result;
						}
						in_snp_Contact.MoveNext();
					};
				} // If Not (in_snp_Contact.BOF And in_snp_Contact.EOF) Then

				// **************************************************
				// STORE THE COMPANY PHONE NUMBER INFORMATION
				errMsg = "Save phone#s";

				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Saving a Historical Buyer Phone Numbers ... ", Color.Blue);
				if (!(in_snp_Company_Phones.BOF && in_snp_Company_Phones.EOF))
				{
					in_snp_Company_Phones.MoveFirst();

					while(!in_snp_Company_Phones.EOF)
					{
						//UPGRADE_ISSUE: (2064) ADODB.CursorOptionEnum property CursorOptionEnum.adAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_ISSUE: (2064) ADODB.Recordset method ado_new_phone.Supports was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						if (ado_new_phone.Supports(UpgradeStubs.ADODB_CursorOptionEnum.getadAddNew()))
						{
							ado_new_phone.AddNew();
							i = 0;

							while((i < in_snp_Company_Phones.FieldsMetadata.Count))
							{
								if (ado_new_phone.GetField(i).FieldMetadata.ColumnName != "pnum_id")
								{ // added MSW - 11/3/21
									ado_new_phone[i] = in_snp_Company_Phones[i];
								}
								i++;
							};

							//If ado_new_phone!pnum_journ_id = in_Journal_ID Then MsgBox "In JournID:" & CStr(in_Journal_ID), vbOKOnly, ""

							if (ErrorHandlingHelper.ResumeNextExpr<bool>(() => Convert.ToDouble(ado_new_phone["pnum_journ_id"]) == in_journal_id))
							{
								try
								{
									ado_new_phone.CancelUpdate();
								}
								catch
								{
								}
							}
							else
							{
								ErrorHandlingHelper.ResumeNext(
									() => {ado_new_phone["pnum_journ_id"] = in_journal_id;}, 
									() => {ado_new_phone.Update();});
							}


							//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
							if (Information.Err().Number == -2147217873)
							{ // check for duplicate error code
								ado_new_phone.CancelUpdate();
							}
							else
							{
								// if error is not a duplcate use normal error handling
								//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
								if (Information.Err().Number > 0)
								{
									throw new Exception();
								}
							}

						}
						else
						{
							// If ado_new_phone.Supports(adAddNew) Then
							return result;
						}
						in_snp_Company_Phones.MoveNext();
					}; // Do While Not in_snp_Company_Phones.EOF
				} // If Not (in_snp_Company_Phones.BOF And in_snp_Company_Phones.EOF) Then


				// ****************************************
				// SAVING COMPANY BUSINESS TYPES
				errMsg = "Save bus types";

				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Saving a Historical Buyer Business Types  ... ", Color.Blue);
				//UPGRADE_ISSUE: (2064) ADODB.CursorOptionEnum property CursorOptionEnum.adAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method ado_new_BusType.Supports was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				if (ado_new_BusType.Supports(UpgradeStubs.ADODB_CursorOptionEnum.getadAddNew()))
				{

					while(!in_snp_Company_Btypes.EOF)
					{
						ado_new_BusType.AddNew();
						i = 0;

						while((i < in_snp_Company_Btypes.FieldsMetadata.Count))
						{
							if (ado_new_BusType.GetField(i).FieldMetadata.ColumnName != "bustypref_id")
							{
								ado_new_BusType[i] = in_snp_Company_Btypes[i];
							}
							i++;
						};
						ado_new_BusType["bustypref_journ_id"] = in_journal_id;


						// ***************************************************
						// PROTECT AGAINST ADDING A DUPLICATE BUSINESS TYPE
						try
						{
							ado_new_BusType.Update();
							//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
						}
						catch
						{
						}
						if (ErrorHandlingHelper.ResumeNextExpr<bool>(() => Information.Err().Number == -2147217873))
						{
							try
							{ // check for duplicate error code
								ado_new_BusType.CancelUpdate();
							}
							catch
							{
							}
						}
						else
						{
							Exception ex_3 = null;
							ErrorHandlingHelper.ResumeNext(out ex_3);
							// if error is not a duplcate use normal error handling
							if (ex_3 != null)
							{
								try
								{
									throw new Exception();
								}
								catch
								{
								}
							}
						}
						try
						{
							in_snp_Company_Btypes.MoveNext();
						}
						catch
						{
						}
					}; //  Do While Not in_snp_Company_Btypes.EOF
				}
				else
				{
					// If in_snp_Company_Btypes.Supports(adAddNew) Then
					return result;
				}



				// ****************************************
				// SAVING COMPANY CERTs
				errMsg = "Save certs";

				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Saving a Historical Buyer Certs  ... ", Color.Blue);
				//UPGRADE_ISSUE: (2064) ADODB.CursorOptionEnum property CursorOptionEnum.adAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method ado_new_Certs.Supports was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				if (ado_new_Certs.Supports(UpgradeStubs.ADODB_CursorOptionEnum.getadAddNew()))
				{

					while(!in_snp_Company_Certs.EOF)
					{
						ado_new_Certs.AddNew();
						i = 0;

						while((i < in_snp_Company_Certs.FieldsMetadata.Count))
						{
							if (ado_new_Certs.GetField(i).FieldMetadata.ColumnName != "ccert_id" && ado_new_Certs.GetField(i).FieldMetadata.ColumnName != "ccert_dsg_code")
							{
								ado_new_Certs[i] = in_snp_Company_Certs[i];
							}
							i++;
						};
						ado_new_Certs["ccert_journ_id"] = in_journal_id;


						// ***************************************************
						// PROTECT AGAINST ADDING A DUPLICATE BUSINESS TYPE
						try
						{
							ado_new_Certs.Update();
							//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
						}
						catch
						{
						}
						if (ErrorHandlingHelper.ResumeNextExpr<bool>(() => Information.Err().Number == -2147217873))
						{
							try
							{ // check for duplicate error code
								ado_new_Certs.CancelUpdate();
							}
							catch
							{
							}
						}
						else
						{
							Exception ex_4 = null;
							ErrorHandlingHelper.ResumeNext(out ex_4);
							// if error is not a duplcate use normal error handling
							if (ex_4 != null)
							{
								try
								{
									throw new Exception();
								}
								catch
								{
								}
							}
						}


						in_snp_Company_Certs.MoveNext();
					}; //  Do While Not in_snp_Company_Certs.EOF
				}
				else
				{
					// If in_snp_Company_Certs.Supports(adAddNew) Then
					return result;
				}


				// **************************************************************
				// Indicate that the Company History data was successfully saved.
				errMsg = "close";

				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Buyer Company Saves Complete.", Color.Blue);
				result = true;


				// **********************************************************************
				// CLOSE AND CLEARE THE ADO RECORD SETS USED TO ADDING/UPDATING RECORDS
				ad_new_contacts.Close();
				ado_new_company.Close();
				ado_new_phone.Close();
				ado_new_BusType.Close();
				ado_new_Certs.Close();

				ado_new_company = null;
				ad_new_contacts = null;
				ado_new_phone = null;
				ado_new_Certs = null;

				return result;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Transaction_Save_Buyer_History_Error ({Information.Err().Number.ToString()}) {excep.Message} : {errMsg}", "modCommon (Transaction)");
				return result;
				//Resume Next
			}
		}

		internal static void fill_research_action_list(int nReference_CompanyID, int ac_id, ListBox lst_research_notes, UpgradeHelpers.DataGridViewFlex grd_Hot_Items, string account_rep, int Index, ref int tmpcount, bool chk_action_list_order = false, bool chk_action_list_send = false, string cbo_Timezones = "", int iHOTBoxSortCol = -1, TabControlExtension tab_ACMain = null)
		{

			// Function used to fill reserch note list

			try
			{
				string Query = "";
				ADORecordSetHelper ado_ResearchNotes = null;
				StringBuilder NoteLine = new StringBuilder();

				string cellcolor = "";
				cellcolor = modAdminCommon.NoColor;
				string make_name = "";
				make_name = "";
				string model_name = "";
				model_name = "";
				string ser_no = "";
				ser_no = "";
				string reg_no = "";
				reg_no = "";
				string temp_date = "";
				temp_date = "";
				string comp_name = "";
				comp_name = "";
				string Subject = "";
				Subject = "";
				string brandname = "";
				brandname = "";
				string modelname = "";
				modelname = "";
				string yacht_name = "";
				yacht_name = "";
				int journ_id = 0;
				journ_id = 0;
				int yacht_id = 0;
				yacht_id = 0;
				int comp_id_hot = 0;
				comp_id_hot = 0;
				int ac_id_hot = 0;
				ac_id_hot = 0;
				int lRow = 0;
				lRow = 0;
				string join_company = "";
				join_company = "";
				string timezone_string = "";
				timezone_string = "";

				// added MSW - 9/9/20
				if (cbo_Timezones != "All" && cbo_Timezones != "")
				{
					if (cbo_Timezones == "International")
					{
						join_company = " inner join company with (NOLOCK) on comp_journ_id = 0 and comp_id = ralert_comp_id ";
						timezone_string = $"{timezone_string} AND ((comp_timezone is NULL) or (comp_timezone='')) ";
					}
					else
					{
						join_company = " inner join company with (NOLOCK) on comp_journ_id = 0 and comp_id = ralert_comp_id ";
						timezone_string = $"{timezone_string} AND (comp_timezone='{cbo_Timezones}') ";
					}
				}


				if (lst_research_notes != null)
				{
					lst_research_notes.Enabled = false;
					lst_research_notes.Items.Clear();
				}


				string order_by_string = "";
				order_by_string = "";
				if (iHOTBoxSortCol > -1)
				{


					switch(iHOTBoxSortCol)
					{
						case 0 :  // Make/Model 
							order_by_string = "ORDER BY ralert_make_name, ralert_model_name, ralert_ser_no_full "; 
							break;
						case 1 :  // SerNbr 
							order_by_string = "ORDER BY ralert_ser_no_full, ralert_make_name, ralert_model_name "; 
							break;
						case 2 :  // RegNbr 
							order_by_string = "ORDER BY ralert_reg_no, ralert_make_name, ralert_model_name, ralert_ser_no_full "; 
							break;
						case 3 :  // Date 
							order_by_string = "ORDER BY ralert_entry_date, ralert_make_name, ralert_model_name, ralert_ser_no_full "; 
							break;
						case 4 :  // Company 
							order_by_string = "ORDER BY ralert_comp_name, ralert_make_name, ralert_model_name, ralert_ser_no_full "; 
							break;
						case 5 :  // Subject 
							order_by_string = "ORDER BY ralert_description, ralert_make_name, ralert_model_name, ralert_ser_no_full "; 
							break;
						default:
							 
							break;
					} // Case iHOTBoxSortCol

				}



				if (chk_action_list_order || chk_action_list_send)
				{

					Query = " select ralert_make_name, ralert_model_name, ralert_ser_no_full, ralert_ac_id, ralert_description, ralert_entry_date, ralert_source, ";
					Query = $"{Query} ralert_comp_name , ralert_comp_id, ralert_source_id, ralert_reg_no  ";
					Query = $"{Query} from View_Research_Alerts with (NOLOCK) {join_company}";

					if (account_rep.Trim() == "No Rep Selected")
					{
						Query = $"{Query} Where ralert_account_id <> '' ";
					}
					else
					{
						Query = $"{Query} Where ralert_account_id = '{account_rep}' ";
					}


					Query = $"{Query} and ralert_comp_id= 0 ";

					if (chk_action_list_order && chk_action_list_send)
					{
						Query = $"{Query} and (ralert_description like 'ordered%' or ralert_description like 'sending%') ";
					}
					else if (chk_action_list_order)
					{ 
						Query = $"{Query} and ralert_description like 'ordered%' ";
					}
					else if (chk_action_list_send)
					{ 
						Query = $"{Query} and ralert_description like 'sending%' ";
					}

					Query = $"{Query}{timezone_string}";

					Query = $"{Query}{order_by_string}";
				}
				else if (nReference_CompanyID > 0)
				{ 
					Query = " select top 500 ralert_make_name, ralert_model_name, ralert_ser_no_full, ralert_ac_id, ralert_description, ralert_entry_date, ralert_source, ";
					Query = $"{Query} ralert_comp_name , ralert_comp_id, ralert_source_id  ";
					Query = $"{Query} from View_Research_Alerts with (NOLOCK) {join_company}";
					Query = $"{Query} Where ralert_comp_id = {nReference_CompanyID.ToString()} ";


					Query = $"{Query}{order_by_string}";
				}
				else if (ac_id > 0)
				{ 
					Query = " select distinct top 500 ralert_description, ralert_entry_date, ralert_source_id  ";
					Query = $"{Query} from View_Research_Alerts with (NOLOCK) {join_company}";
					Query = $"{Query} Where ralert_ac_id = {ac_id.ToString()} ";

					Query = $"{Query}{timezone_string}";

					Query = $"{Query} order by ralert_entry_date desc ";
				}
				else if (account_rep.Trim() != "")
				{ 
					Query = " select ralert_make_name, ralert_model_name, ralert_ser_no_full, ralert_ac_id, ralert_description, ralert_entry_date, ralert_source, ";
					Query = $"{Query} ralert_comp_name , ralert_comp_id, ralert_source_id, ralert_reg_no  ";
					Query = $"{Query} from View_Research_Alerts with (NOLOCK) {join_company}";

					if (account_rep.Trim() == "No Rep Selected")
					{
						Query = $"{Query} Where ralert_account_id <> '' ";
					}
					else
					{
						Query = $"{Query} Where ralert_account_id = '{account_rep}' ";
					}



					Query = $"{Query} and ralert_comp_id > 0 {timezone_string}{order_by_string}";
				}

				ado_ResearchNotes = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

				if (!(ado_ResearchNotes.BOF && ado_ResearchNotes.EOF))
				{

					if (tab_ACMain != null)
					{
						if (ac_id > 0)
						{
							SSTabHelper.SetSelectedIndex(tab_ACMain, 3);
						}
						else if (nReference_CompanyID > 0)
						{ 
							SSTabHelper.SetSelectedIndex(tab_ACMain, 2);
						}

					}


					while(!ado_ResearchNotes.EOF)
					{

						NoteLine = new StringBuilder("");

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_ResearchNotes["ralert_entry_date"]))
						{
							if (Convert.ToString(ado_ResearchNotes["ralert_entry_date"]).Trim() != modGlobalVars.cEmptyString)
							{
								NoteLine.Append($"{Convert.ToDateTime(ado_ResearchNotes["ralert_entry_date"]).ToString("d")} - ");
								temp_date = Convert.ToDateTime(ado_ResearchNotes["ralert_entry_date"]).ToString("d");
							}
						}

						// ADDED MSW - TO REPLICATION HOT BOX
						if (account_rep.Trim() != "")
						{
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(ado_ResearchNotes["ralert_comp_name"]))
							{
								if (Convert.ToString(ado_ResearchNotes["ralert_comp_name"]).Trim() != modGlobalVars.cEmptyString)
								{
									comp_name = Convert.ToString(ado_ResearchNotes["ralert_comp_name"]);
								}
							}


							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(ado_ResearchNotes["ralert_comp_id"]))
							{
								if (Convert.ToString(ado_ResearchNotes["ralert_comp_id"]).Trim() != modGlobalVars.cEmptyString)
								{
									comp_id_hot = Convert.ToInt32(ado_ResearchNotes["ralert_comp_id"]);
								}
							}

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(ado_ResearchNotes["ralert_ac_id"]))
							{
								if (Convert.ToString(ado_ResearchNotes["ralert_ac_id"]).Trim() != modGlobalVars.cEmptyString)
								{
									ac_id_hot = Convert.ToInt32(ado_ResearchNotes["ralert_ac_id"]);
								}
							}

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(ado_ResearchNotes["ralert_reg_no"]))
							{
								if (Convert.ToString(ado_ResearchNotes["ralert_reg_no"]).Trim() != modGlobalVars.cEmptyString)
								{
									reg_no = Convert.ToString(ado_ResearchNotes["ralert_reg_no"]);
								}
							}

						}




						if (nReference_CompanyID > 0 || account_rep.Trim() != "")
						{


							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(ado_ResearchNotes["ralert_make_name"]))
							{
								if (Convert.ToString(ado_ResearchNotes["ralert_make_name"]).Trim() != modGlobalVars.cEmptyString)
								{
									NoteLine.Append(($"{Convert.ToString(ado_ResearchNotes["ralert_make_name"])}/").Trim());
									make_name = Convert.ToString(ado_ResearchNotes["ralert_make_name"]).Trim();
								}
							}

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(ado_ResearchNotes["ralert_model_name"]))
							{
								if (Convert.ToString(ado_ResearchNotes["ralert_model_name"]).Trim() != modGlobalVars.cEmptyString)
								{
									NoteLine.Append($"{Convert.ToString(ado_ResearchNotes["ralert_model_name"]).Trim()} ");
									model_name = Convert.ToString(ado_ResearchNotes["ralert_model_name"]).Trim();
								}
							}

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(ado_ResearchNotes["ralert_ser_no_full"]))
							{
								if (Convert.ToString(ado_ResearchNotes["ralert_ser_no_full"]).Trim() != modGlobalVars.cEmptyString)
								{
									NoteLine.Append(($"[{Convert.ToString(ado_ResearchNotes["ralert_ser_no_full"])}]").Trim());
									ser_no = Convert.ToString(ado_ResearchNotes["ralert_ser_no_full"]);
								}
							}


							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(ado_ResearchNotes["ralert_ac_id"]))
							{
								if (Convert.ToString(ado_ResearchNotes["ralert_ac_id"]).Trim() != modGlobalVars.cEmptyString)
								{
									if (Convert.ToString(ado_ResearchNotes["ralert_ac_id"]).Trim() != "0")
									{
										NoteLine.Append($"{($"[{Convert.ToString(ado_ResearchNotes["ralert_ac_id"])}]").Trim()} ");
										ac_id = Convert.ToInt32(ado_ResearchNotes["ralert_ac_id"]);
									}
								}
							}

						}
						else
						{

						}




						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_ResearchNotes["ralert_description"]))
						{
							if (Convert.ToString(ado_ResearchNotes["ralert_description"]).Trim() != modGlobalVars.cEmptyString)
							{
								NoteLine.Append(Convert.ToString(ado_ResearchNotes["ralert_description"]).Trim());
								Subject = Convert.ToString(ado_ResearchNotes["ralert_description"]).Trim();
							}
						}

						if (lst_research_notes != null)
						{
							lst_research_notes.AddItem(NoteLine.ToString().Trim());
							lst_research_notes.SetItemData(lst_research_notes.GetNewIndex(), Convert.ToInt32(Convert.ToDouble(ado_ResearchNotes["ralert_source_id"])));
						}

						if (grd_Hot_Items != null)
						{

							lRow++;
							grd_Hot_Items.RowsCount = lRow + 1;
							grd_Hot_Items.CurrentRowIndex = lRow;

							// fill grid
							tmpcount++;
							add_middle_hot_box(grd_Hot_Items, lRow, cellcolor, make_name, model_name, ser_no, reg_no, temp_date, comp_name, Subject, brandname, modelname, yacht_name, journ_id, ac_id_hot, yacht_id, comp_id_hot);

							if (tmpcount == 20)
							{
								grd_Hot_Items.Redraw = true;
								grd_Hot_Items.Refresh();
								Application.DoEvents();
								grd_Hot_Items.Redraw = false;
							}
						}


						ado_ResearchNotes.MoveNext();

					};

				}

				ado_ResearchNotes.Close();
				ado_ResearchNotes = null;


				if (lst_research_notes != null)
				{
					lst_research_notes.Enabled = true;
				}


				ado_ResearchNotes = null;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"fill_hotbox_list_Error ({Information.Err().Number.ToString()}) {excep.Message} CMPID:[{nReference_CompanyID.ToString()}] ", "Company (frm_Company)");
				modSubscription.search_off();
				return;
			}
		}
		internal static void add_middle_hot_box(UpgradeHelpers.DataGridViewFlex grd_Hot_Items, int lRow, string cellcolor, string make, string model, string serial, string RegNO, string date_entry, string comp_name, string Subject, string brandname, string modelname, string yacht_name, int journ_id, int ac_id, int yacht_id, int comp_id)
		{

			grd_Hot_Items.set_RowData(lRow, journ_id);

			grd_Hot_Items.CurrentColumnIndex = 0;
			grd_Hot_Items.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
			grd_Hot_Items[grd_Hot_Items.CurrentRowIndex, grd_Hot_Items.CurrentColumnIndex].Value = $"{($"{make}").Trim()}/{($"{model}").Trim()}";

			grd_Hot_Items.CurrentColumnIndex = 1;
			grd_Hot_Items.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
	
			grd_Hot_Items.ColAlignment[1] = DataGridViewContentAlignment.NotSet;
			grd_Hot_Items[grd_Hot_Items.CurrentRowIndex, grd_Hot_Items.CurrentColumnIndex].Value = ($"{serial}").Trim();

			grd_Hot_Items.CurrentColumnIndex = 2;
			grd_Hot_Items.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
			grd_Hot_Items[grd_Hot_Items.CurrentRowIndex, grd_Hot_Items.CurrentColumnIndex].Value = ($"{RegNO}").Trim();

			grd_Hot_Items.CurrentColumnIndex = 3;
			grd_Hot_Items.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
			grd_Hot_Items[grd_Hot_Items.CurrentRowIndex, grd_Hot_Items.CurrentColumnIndex].Value = DateTime.Parse(date_entry).ToString("d");

			grd_Hot_Items.CurrentColumnIndex = 4;
			grd_Hot_Items.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
			grd_Hot_Items[grd_Hot_Items.CurrentRowIndex, grd_Hot_Items.CurrentColumnIndex].Value = ($"{comp_name}").Trim();

			grd_Hot_Items.CurrentColumnIndex = 5;
			grd_Hot_Items.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
			grd_Hot_Items[grd_Hot_Items.CurrentRowIndex, grd_Hot_Items.CurrentColumnIndex].Value = ($"{Subject}").Trim();

			grd_Hot_Items.CurrentColumnIndex = 6;
			grd_Hot_Items.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
			grd_Hot_Items[grd_Hot_Items.CurrentRowIndex, grd_Hot_Items.CurrentColumnIndex].Value = $"{($"{brandname} ").Trim()} - {($"{modelname} ").Trim()}";

			grd_Hot_Items.CurrentColumnIndex = 7;
			grd_Hot_Items.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
			grd_Hot_Items[grd_Hot_Items.CurrentRowIndex, grd_Hot_Items.CurrentColumnIndex].Value = ($"{yacht_name}").Trim();

			grd_Hot_Items.CurrentColumnIndex = 8;
			grd_Hot_Items.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
			grd_Hot_Items[grd_Hot_Items.CurrentRowIndex, grd_Hot_Items.CurrentColumnIndex].Value = journ_id.ToString();

			grd_Hot_Items.CurrentColumnIndex = 9;
			grd_Hot_Items.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
			grd_Hot_Items[grd_Hot_Items.CurrentRowIndex, grd_Hot_Items.CurrentColumnIndex].Value = ac_id.ToString();

			grd_Hot_Items.CurrentColumnIndex = 10;
			grd_Hot_Items.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
			grd_Hot_Items[grd_Hot_Items.CurrentRowIndex, grd_Hot_Items.CurrentColumnIndex].Value = yacht_id.ToString();

			grd_Hot_Items.CurrentColumnIndex = 11;
			grd_Hot_Items.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
			grd_Hot_Items[grd_Hot_Items.CurrentRowIndex, grd_Hot_Items.CurrentColumnIndex].Value = comp_id.ToString();

		}


		internal static object find_research_action_item(int temp_id)
		{

			// Function used to fill reserch note list
			// RTW - MODIFIED ON 9/22/2010 - COMMENTED OUT THE EXISTS QUERY TO AVOID DOING 2 QUERIES

			object result = null;
			try
			{
				string Query = "";
				ADORecordSetHelper ado_ResearchNotes = null;
				string NoteLine = "";


				result = "";

				Query = " select top 500 ralert_type  ";
				Query = $"{Query} from View_Research_Alerts with (NOLOCK) ";

				Query = $"{Query} Where ralert_source_id = {temp_id.ToString()} ";


				ado_ResearchNotes = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

				if (!(ado_ResearchNotes.BOF && ado_ResearchNotes.EOF))
				{


					while(!ado_ResearchNotes.EOF)
					{

						NoteLine = "";

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_ResearchNotes["ralert_type"]))
						{
							if (Convert.ToString(ado_ResearchNotes["ralert_type"]).Trim() != modGlobalVars.cEmptyString)
							{
								result = ado_ResearchNotes["ralert_type"];
							}
						}

						ado_ResearchNotes.MoveNext();

					};



				}

				ado_ResearchNotes.Close();
				ado_ResearchNotes = null;

				// End If    'if exist
				ado_ResearchNotes = null;
				modSubscription.search_off();
				return result;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"fill_hotbox_list_Error ({Information.Err().Number.ToString()}) {excep.Message} ID:[{temp_id.ToString()}]", "Company (frm_Company)");
				modSubscription.search_off();
				return result;
			}
		}

		internal static int Transaction_Create_Awaiting_Documentation_Company(int inCompany_ID, int inJournal_ID, string inCountry, string inState, string inBusinessType, bool in_SendToWeb = false)
		{


			int result = 0;
			string Query = "";
			int New_Company_ID = 0;
			ADORecordSetHelper snpMaxComp = null;

			try
			{

				result = 0;

				// GET THE NEXT COMPANY ID
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Getting Next Company ID for Awaiting Documentation Company ...", Color.Blue);
				if (inCompany_ID == 0)
				{ // we must calculate the next company id
					New_Company_ID = 0;
					Query = "SELECT max(comp_id) as MaxCompID FROM Company WITH(NOLOCK)";
					snpMaxComp = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snpMaxComp["MaxCompID"]))
					{
						New_Company_ID = Convert.ToInt32(snpMaxComp["MaxCompID"]) + 1;
						snpMaxComp.Close();
					}
					snpMaxComp = null;
				}
				else
				{
					// USE THE COMPANY ID THAT WAS PASSED IN
					New_Company_ID = inCompany_ID;
				} // IF NO COMPANY ID

				if (New_Company_ID == 0)
				{
					return result;
				}

				if (inBusinessType.Trim() == "")
				{
					inBusinessType = "UI";
				}

				// CREATE NEW AWAITING DOCUMENTATION COMPANY RECORD
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Saving New Awaiting Documentation Company Record ...", Color.Blue);

				Query = "INSERT INTO Company (comp_id, comp_journ_id, comp_name, comp_name_search, comp_state, comp_country, comp_awaitdoc_flag, ";
				Query = $"{Query}comp_assign_flag, comp_account_id, comp_business_type, comp_account_type, comp_ent_user_id, ";
				Query = $"{Query}comp_ent_date, comp_active_flag, comp_action_date, comp_product_business_flag, comp_agency_type, comp_language) VALUES (";
				Query = $"{Query}{New_Company_ID.ToString()}";
				Query = $"{Query}, 0 , 'Awaiting Documentation' , 'AWAITINGDOCUMENTATION'";

				if (inState.Trim() != modGlobalVars.cEmptyString)
				{
					if (inState.Trim() != "")
					{
						if (inState.Trim().IndexOf(',') >= 0)
						{
							Query = $"{Query}, '{inState.Trim().Substring(0, Math.Min(inState.IndexOf(", "), inState.Trim().Length))}'";
						}
						else
						{
							Query = $"{Query}, '{inState.Trim()}'";
						}
					}
					else
					{
						Query = $"{Query},NULL";
					}
				}
				else
				{
					Query = $"{Query},NULL";
				}

				if (inCountry.Trim() != modGlobalVars.cEmptyString)
				{
					Query = $"{Query}, '{modAdminCommon.Fix_Quote(inCountry).Trim()}'";
				}
				else
				{
					Query = $"{Query},NULL";
				}
				Query = $"{Query},'Y','M','ID03','{inBusinessType}','UI','{modAdminCommon.gbl_User_ID}','{DateTime.Now.ToString()}','Y'";
				// IDBC to ID01 Account rep change mjm 8/9/06

				if (in_SendToWeb)
				{ //aey 7/28/04
					Query = $"{Query}, NULL";
				}
				else
				{
					Query = $"{Query},'{DateTime.Now.ToString()}'";
				}

				Query = $"{Query},'Y'"; // default to business 'comp_product_business_flag mjm 1/30/09

				Query = $"{Query},'C', 'English')";

				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery(); //aey 7/16/04 converted to ado

				// ***************************************
				// ADD HISTORICAL COMPANY RECORD AS WELL
				if (inJournal_ID > 0)
				{
					Query = "INSERT INTO Company (comp_id, comp_journ_id, comp_name, comp_name_search, comp_state, comp_country, comp_awaitdoc_flag, ";
					Query = $"{Query}comp_assign_flag, comp_account_id, comp_business_type, comp_account_type, comp_ent_user_id, ";
					Query = $"{Query}comp_ent_date, comp_active_flag, comp_action_date, comp_product_business_flag, comp_agency_type, comp_language) VALUES (";
					Query = $"{Query}{New_Company_ID.ToString()}";
					Query = $"{Query}, {inJournal_ID.ToString()}";
					Query = $"{Query}, 'Awaiting Documentation' , 'AWAITINGDOCUMENTATION'";

					if (inState.Trim() != modGlobalVars.cEmptyString)
					{
						if (inState.Trim() != "")
						{
							if (inState.Trim().IndexOf(',') >= 0)
							{
								Query = $"{Query}, '{inState.Trim().Substring(0, Math.Min(inState.IndexOf(", "), inState.Trim().Length))}'";
							}
							else
							{
								Query = $"{Query}, '{inState.Trim()}'";
							}
						}
						else
						{
							Query = $"{Query},NULL";
						}
					}
					else
					{
						Query = $"{Query},NULL";
					}

					if (inCountry.Trim() != modGlobalVars.cEmptyString)
					{
						Query = $"{Query}, '{modAdminCommon.Fix_Quote(inCountry).Trim()}'";
					}
					else
					{
						Query = $"{Query},NULL";
					}

					Query = $"{Query},'Y','M','ID03','{inBusinessType}','UI','{modAdminCommon.gbl_User_ID}','{DateTime.Now.ToString()}','N'";
					// IDBC to ID01 Account rep change mjm 8/9/06

					if (in_SendToWeb)
					{ //aey 7/28/04
						Query = $"{Query},NULL";
					}
					else
					{
						Query = $"{Query},'{DateTime.Now.ToString()}'";
					}

					Query = $"{Query},'Y'"; // default to business 'comp_product_business_flag mjm 1/30/09

					Query = $"{Query},'C', 'English')";

					DbCommand TempCommand_2 = null;
					TempCommand_2 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
					TempCommand_2.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand_2.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
					TempCommand_2.ExecuteNonQuery(); //aey 7/16/04 converted to ado

				}


				// INSERT A SINGLE BUSINESS TYPE REFERENCE RECORD FOR CURRENT COMPANY
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Saving Awaiting Documentation Business Type ...", Color.Blue);

				Query = "INSERT INTO Business_Type_Reference (bustypref_comp_id, bustypref_journ_id, bustypref_type, bustypref_seq_no)";
				Query = $"{Query} VALUES ({New_Company_ID.ToString()},0,'{inBusinessType}',1)";
				DbCommand TempCommand_3 = null;
				TempCommand_3 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_3);
				TempCommand_3.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand_3.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_3);
				TempCommand_3.ExecuteNonQuery();

				// INSERT HISTORICAL BUSINESS TYPE RECORD IF REQUIRED
				if (inJournal_ID > 0)
				{
					Query = "INSERT INTO Business_Type_Reference (bustypref_comp_id, bustypref_journ_id, bustypref_type, bustypref_seq_no)";
					Query = $"{Query} VALUES ({New_Company_ID.ToString()},{inJournal_ID.ToString()},'{inBusinessType}',1)";
					DbCommand TempCommand_4 = null;
					TempCommand_4 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_4);
					TempCommand_4.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand_4.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_4);
					TempCommand_4.ExecuteNonQuery();
				}

				Company_Stats_Update(New_Company_ID);


				return New_Company_ID;
			}
			catch (System.Exception excep)
			{

				result = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Transaction_Create_Awaiting_Documentation_Company_Error ({Information.Err().Number.ToString()}) {excep.Message} : CMPID[{New_Company_ID.ToString()}] JID[{inJournal_ID.ToString()}]", "modCommon (Transaction)");
				return result;
			}
		}

		internal static bool Transaction_Save_Company_History(int in_journal_id, ref ADORecordSetHelper in_snp_Company, ref ADORecordSetHelper in_snp_Contact, ref ADORecordSetHelper in_snp_Company_Phones, ref ADORecordSetHelper in_snp_Company_Btypes, ref ADORecordSetHelper in_snp_Company_Certs, int in_Fractional_Owner_ID = 0, bool in_SendToWeb = true)
		{
			//******************************************************************************************
			// MODIFIED: RTW - 6/29/2011 - TO HANDLE COMPANY CERTIFICATION RECORDS
			//******************************************************************************************

			bool result = false;
			string errString = "";
			try
			{

				string Query = "";
				int i = 0;
				string CurrentDateTime = "";
				CurrentDateTime = modAdminCommon.GetDateTime();


				// ***************************************************************
				// SET FUNCTION STATUS TO FALSE - FAILED
				// - THEREFORE IF THE FUNCTION FAILS IT WILL KEEP THE FALSE STATUS
				result = false;

				errString = "Setup Variables";
				// **************************************************************
				// DEFINE ALL OF THE RECORDSETS TO BE USED FOR ADDING/UPDATING
				ADORecordSetHelper ado_new_company = new ADORecordSetHelper();
				ADORecordSetHelper ad_new_contacts = new ADORecordSetHelper();
				ADORecordSetHelper ado_new_phone = new ADORecordSetHelper();
				ADORecordSetHelper ado_new_BusType = new ADORecordSetHelper();
				ADORecordSetHelper ado_new_Certs = new ADORecordSetHelper();

				string extra_query = "";
				bool skip_contact_insert = false;
				skip_contact_insert = false;



				StringBuilder temp_phone_list = new StringBuilder();
				string temp_phone_list_last = "";
				temp_phone_list = new StringBuilder("");
				temp_phone_list_last = "";

				// **************************************************************
				// OPEN ALL OF THE ADO RECORDSETS TO BE USED FOR ADDING/UPDATING.
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Opening Companiess for Action ... ", Color.Blue);
				ado_new_company.Open("Select * from Company where comp_id = -1", modAdminCommon.ADODB_Trans_conn, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Opening Contacts for Action ... ", Color.Blue);
				ad_new_contacts.Open("Select * from Contact where contact_id = -1", modAdminCommon.ADODB_Trans_conn, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

				// TEMP HOLD MSW - 1/30/12
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Opening Phone Numbers for Action ... ", Color.Blue);
				//ado_new_phone.Open "Phone_Numbers", ADODB_Trans_conn, adOpenDynamic, adLockOptimistic, adCmdTable
				ado_new_phone.Open("Select * from Phone_Numbers where pnum_comp_id = -1", modAdminCommon.ADODB_Trans_conn, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);


				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Opening Company Business Types for Action ... ", Color.Blue);
				ado_new_BusType.Open("Select * from Business_Type_Reference where bustypref_id = -1", modAdminCommon.ADODB_Trans_conn, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Opening Company Certs for Action ... ", Color.Blue);
				ado_new_Certs.Open("Select * from Company_Certification where ccert_id = -1", modAdminCommon.ADODB_Trans_conn, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

				Cursor.Current = Cursors.WaitCursor;

				errString = "Saving Company Data";

				// *******************************
				// STORE THE COMPANY INFORMATION
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Saving a Historical Company Record ... ", Color.Blue);
				if (!(in_snp_Company.BOF && in_snp_Company.EOF))
				{
					in_snp_Company.MoveFirst();

					while(!in_snp_Company.EOF)
					{
						//UPGRADE_ISSUE: (2064) ADODB.CursorOptionEnum property CursorOptionEnum.adAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_ISSUE: (2064) ADODB.Recordset method ado_new_company.Supports was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						if (ado_new_company.Supports(UpgradeStubs.ADODB_CursorOptionEnum.getadAddNew()))
						{
							ado_new_company.AddNew();
							i = 0;

							while((i < in_snp_Company.FieldsMetadata.Count))
							{
								ado_new_company[i] = in_snp_Company[i];
								i++;
							};

							if (Conversion.Val(in_Fractional_Owner_ID.ToString().Trim()) > 0)
							{
								ado_new_company["comp_fractowr_id"] = Conversion.Val(in_Fractional_Owner_ID.ToString().Trim());
							}

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (Convert.IsDBNull(ado_new_company["comp_fractowr_id"]))
							{ //aey 9/29/04
								ado_new_company["comp_fractowr_id"] = 0;
							}

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (Convert.IsDBNull(ado_new_company["comp_fractowr_contact_id"]))
							{ //aey 9/29/04
								ado_new_company["comp_fractowr_contact_id"] = 0;
							}

							ado_new_company["comp_journ_id"] = in_journal_id;
							ado_new_company["comp_active_flag"] = "N";

							if (in_SendToWeb)
							{ //aey 7/28/04
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								ado_new_company["comp_action_date"] = DBNull.Value;
							}
							else
							{
								ado_new_company["comp_action_date"] = CurrentDateTime;
							}

							// ***************************************************
							// PROTECT AGAINST ADDING A DUPLICATE COMPANY RECORDS
							try
							{
								ado_new_company.Update();
								//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
							}
							catch
							{
							}
							if (ErrorHandlingHelper.ResumeNextExpr<bool>(() => Information.Err().Number == -2147217873))
							{
								try
								{ // check for duplicate error code
									ado_new_company.CancelUpdate();
								}
								catch
								{
								}
							}
							else
							{
								Exception ex = null;
								ErrorHandlingHelper.ResumeNext(out ex);
								// if error is not a duplcate use normal error handling
								if (ex != null)
								{
									try
									{
										throw new Exception();
									}
									catch
									{
									}
								}
							}

						}
						in_snp_Company.MoveNext();
					};
				} // If Not (in_snp_Company.BOF And in_snp_Company.EOF) Then



				// ************************************
				// STORE THE CONTACT INFORMATION
				//If skip_contact_insert = False Then

				errString = "Saving Contact Data";
				// RTW - 3/31/2004 - ONLY WORK ON CONTACT SNAPSHOT IF OPEN
				if (in_snp_Contact.State == ConnectionState.Open)
				{
					modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Saving a Historical Company Contact Records ... ", Color.Blue);
					if (!(in_snp_Contact.BOF && in_snp_Contact.EOF))
					{
						in_snp_Contact.MoveFirst();

						while(!in_snp_Contact.EOF)
						{

							//UPGRADE_ISSUE: (2064) ADODB.CursorOptionEnum property CursorOptionEnum.adAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_ISSUE: (2064) ADODB.Recordset method ad_new_contacts.Supports was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							if (ad_new_contacts.Supports(UpgradeStubs.ADODB_CursorOptionEnum.getadAddNew()))
							{
								ad_new_contacts.AddNew();
								i = 0;

								while((i < in_snp_Contact.FieldsMetadata.Count))
								{
									ad_new_contacts[i] = in_snp_Contact[i];
									i++;
								};
								ad_new_contacts["contact_journ_id"] = in_journal_id;
								//            Debug.Print in_snp_Contact!contact_comp_id & "-" & in_snp_Contact!contact_id & "-" & in_Journal_ID & ";"
								if (in_SendToWeb)
								{ //aey 7/28/04
									//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
									ad_new_contacts["contact_action_date"] = DBNull.Value;
								}
								else
								{
									ad_new_contacts["contact_action_date"] = CurrentDateTime;
								}
								// ***************************************************
								// PROTECT AGAINST ADDING A DUPLICATE CONTACTS
								try
								{
									ad_new_contacts.Update();
									//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
								}
								catch
								{
								}
								if (ErrorHandlingHelper.ResumeNextExpr<bool>(() => Information.Err().Number == -2147217873))
								{
									try
									{ // check for duplicate error code
										ad_new_contacts.CancelUpdate();
									}
									catch
									{
									}
								}
								else
								{
									Exception ex_2 = null;
									ErrorHandlingHelper.ResumeNext(out ex_2);
									// if error is not a duplcate use normal error handling
									if (ex_2 != null)
									{
										try
										{
											throw new Exception();
										}
										catch
										{
										}
									}
								}

							}
							in_snp_Contact.MoveNext();
						};
					} // If Not (in_snp_Contact.BOF And in_snp_Contact.EOF) Then
				}
				// End If
				// **************************************************
				// STORE THE COMPANY PHONE NUMBER INFORMATION
				// RTW - 3/31/2004 - ONLY SAVE PHONE INFO IF SNAPSHOT IS OPEN
				errString = "Saving Phone Data";

				if (in_snp_Company_Phones.State == ConnectionState.Open)
				{
					modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Saving a Historical Company Phone Numbers ... ", Color.Blue);
					if (!(in_snp_Company_Phones.BOF && in_snp_Company_Phones.EOF))
					{
						in_snp_Company_Phones.MoveFirst();

						while(!in_snp_Company_Phones.EOF)
						{
							//UPGRADE_ISSUE: (2064) ADODB.CursorOptionEnum property CursorOptionEnum.adAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_ISSUE: (2064) ADODB.Recordset method ado_new_phone.Supports was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							if (ado_new_phone.Supports(UpgradeStubs.ADODB_CursorOptionEnum.getadAddNew()))
							{
								ado_new_phone.AddNew();
								i = 0;

								while((i < in_snp_Company_Phones.FieldsMetadata.Count))
								{
									if (ado_new_phone.GetField(i).FieldMetadata.ColumnName != "pnum_id")
									{ // added MSW - 11/3/21
										ado_new_phone[i] = in_snp_Company_Phones[i];
									}

									i++;
								};


								//If ado_new_phone!pnum_journ_id = in_Journal_ID Then MsgBox "In JournID:" & CStr(in_Journal_ID), vbOKOnly, ""

								if (ErrorHandlingHelper.ResumeNextExpr<bool>(() => Convert.ToDouble(ado_new_phone["pnum_journ_id"]) == in_journal_id))
								{
									try
									{
										ado_new_phone.CancelUpdate();
									}
									catch
									{
									}
								}
								else
								{
									ErrorHandlingHelper.ResumeNext(
										() => {ado_new_phone["pnum_journ_id"] = in_journal_id;}, 
										() => {ado_new_phone.Update();});
								}

								// MAKE UP TEMP VAR
								// STORE COMBINATION OF COMP, CONTACTACT



								temp_phone_list.Append($"{Convert.ToString(ado_new_phone["pnum_contact_id"])}-");
								temp_phone_list.Append($"{Convert.ToString(ado_new_phone["pnum_journ_id"])}-");
								temp_phone_list.Append($"{Convert.ToString(ado_new_phone["pnum_type"])}-");
								temp_phone_list.Append(Convert.ToString(ado_new_phone["pnum_number_full"]));

								temp_phone_list.Append(Environment.NewLine);


								//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
								if (Information.Err().Number == -2147217873)
								{ // check for duplicate error code
									ado_new_phone.CancelUpdate();
								}
								else
								{
									// if error is not a duplcate use normal error handling
									//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
									if (Information.Err().Number > 0)
									{
										throw new Exception();
									}
								}

							}
							in_snp_Company_Phones.MoveNext();
						}; // Do While Not in_snp_Company_Phones.EOF
					} // If Not (in_snp_Company_Phones.BOF And in_snp_Company_Phones.EOF) Then

				}

				// ****************************************
				// SAVING COMPANY BUSINESS TYPES
				errString = "Saving Business Type Data";
				// RTW - 3/31/2004 - ONLY SAVE Business Type INFO IF SNAPSHOT IS OPEN
				if (in_snp_Company_Btypes.State == ConnectionState.Open)
				{
					modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Saving a Historical Company Business Types  ... ", Color.Blue);
					if (!(in_snp_Company_Btypes.BOF && in_snp_Company_Btypes.EOF))
					{
						in_snp_Company_Btypes.MoveFirst();


						while(!in_snp_Company_Btypes.EOF)
						{
							//UPGRADE_ISSUE: (2064) ADODB.CursorOptionEnum property CursorOptionEnum.adAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_ISSUE: (2064) ADODB.Recordset method ado_new_BusType.Supports was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							if (ado_new_BusType.Supports(UpgradeStubs.ADODB_CursorOptionEnum.getadAddNew()))
							{
								ado_new_BusType.AddNew();
								i = 0;

								while((i < in_snp_Company_Btypes.FieldsMetadata.Count))
								{
									if (ado_new_BusType.GetField(i).FieldMetadata.ColumnName != "bustypref_id")
									{
										ado_new_BusType[i] = in_snp_Company_Btypes[i];
									}
									i++;
								};
								ado_new_BusType["bustypref_journ_id"] = in_journal_id;


								// ***************************************************
								// PROTECT AGAINST ADDING A DUPLICATE BUSINESS TYPE
								try
								{
									ado_new_BusType.Update();
									//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
								}
								catch
								{
								}
								if (ErrorHandlingHelper.ResumeNextExpr<bool>(() => Information.Err().Number == -2147217873))
								{
									try
									{ // check for duplicate error code
										ado_new_BusType.CancelUpdate();
									}
									catch
									{
									}
								}
								else
								{
									Exception ex_3 = null;
									ErrorHandlingHelper.ResumeNext(out ex_3);
									// if error is not a duplcate use normal error handling
									if (ex_3 != null)
									{
										try
										{
											throw new Exception();
										}
										catch
										{
										}
									}
								}

							} // add new

							in_snp_Company_Btypes.MoveNext();
						}; //  Do While Not snp_BusType.EOF

					} // if have business types to save
				}


				// ****************************************
				// SAVING COMPANY CERTS
				errString = "Saving Certs";
				if (in_snp_Company_Certs.State == ConnectionState.Open)
				{
					modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Saving a Historical Company Certs  ... ", Color.Blue);
					if (!(in_snp_Company_Certs.BOF && in_snp_Company_Certs.EOF))
					{
						in_snp_Company_Certs.MoveFirst();


						while(!in_snp_Company_Certs.EOF)
						{
							//UPGRADE_ISSUE: (2064) ADODB.CursorOptionEnum property CursorOptionEnum.adAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_ISSUE: (2064) ADODB.Recordset method ado_new_Certs.Supports was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							if (ado_new_Certs.Supports(UpgradeStubs.ADODB_CursorOptionEnum.getadAddNew()))
							{
								ado_new_Certs.AddNew();
								i = 0;

								while((i < in_snp_Company_Certs.FieldsMetadata.Count))
								{
									if (ado_new_Certs.GetField(i).FieldMetadata.ColumnName != "ccert_id" && ado_new_Certs.GetField(i).FieldMetadata.ColumnName != "ccert_dsg_code")
									{
										ado_new_Certs[i] = in_snp_Company_Certs[i];
									}
									i++;
								};
								ado_new_Certs["ccert_journ_id"] = in_journal_id;


								// ***************************************************
								// PROTECT AGAINST ADDING A DUPLICATE CERTS
								try
								{
									ado_new_Certs.Update();
									//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
								}
								catch
								{
								}
								if (ErrorHandlingHelper.ResumeNextExpr<bool>(() => Information.Err().Number == -2147217873))
								{
									try
									{ // check for duplicate error code
										ado_new_Certs.CancelUpdate();
									}
									catch
									{
									}
								}
								else
								{
									Exception ex_4 = null;
									ErrorHandlingHelper.ResumeNext(out ex_4);
									// if error is not a duplcate use normal error handling
									if (ex_4 != null)
									{
										try
										{
											throw new Exception();
										}
										catch
										{
										}
									}
								}

							} // add new

							in_snp_Company_Certs.MoveNext();
						}; //  Do While Not snp_BusType.EOF

					} // if have business types to save
				}

				// **************************************************************
				// Indicate that the Company History data was successfully saved.
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Historical Company Saves Complete.", Color.Blue);
				result = true;

				errString = "Closing Recordsets";
				// **********************************************************************
				// CLOSE AND CLEARE THE ADO RECORD SETS USED TO ADDING/UPDATING RECORDS

				ado_new_company.Close();
				ado_new_phone.Close();
				ado_new_BusType.Close();
				ado_new_Certs.Close();

				ado_new_company = null;
				ado_new_phone = null;
				ado_new_BusType = null;
				ado_new_Certs = null;

				if (ad_new_contacts != null)
				{ //aey 5/27/04
					if (ad_new_contacts.State == ConnectionState.Open)
					{
						ad_new_contacts.Close();
					}
				}
				ad_new_contacts = null;

				// CLOSE THE COMPANIES RECORDSET
				if (in_snp_Company != null)
				{
					if (in_snp_Company.State == ConnectionState.Open)
					{
						in_snp_Company.Close();
					}
					in_snp_Company = null;
				}

				// CLOSE THE CONTACTS RECORDSET
				if (in_snp_Contact != null)
				{
					if (in_snp_Contact.State == ConnectionState.Open)
					{
						in_snp_Contact.Close();
					}
					in_snp_Contact = null;
				}

				// CLOSE THE COMPANY PHONES RECORDSET
				if (in_snp_Company_Phones != null)
				{
					if (in_snp_Company_Phones.State == ConnectionState.Open)
					{
						in_snp_Company_Phones.Close();
					}
					in_snp_Company_Phones = null;
				}

				// CLOSE THE COMPANY BUSINESS TYPES RECORDSET
				if (in_snp_Company_Btypes != null)
				{
					if (in_snp_Company_Btypes.State == ConnectionState.Open)
					{
						in_snp_Company_Btypes.Close();
					}
					in_snp_Company_Btypes = null;
				}

				// CLOSE THE COMPANY CERTS RECORDSET
				if (in_snp_Company_Certs != null)
				{
					if (in_snp_Company_Certs.State == ConnectionState.Open)
					{
						in_snp_Company_Certs.Close();
					}
					in_snp_Company_Certs = null;
				}
				return result;
			}
			catch (System.Exception excep)
			{

				in_snp_Company = null;
				in_snp_Contact = null;
				in_snp_Company_Phones = null;
				in_snp_Company_Btypes = null;
				in_snp_Company_Certs = null;
				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Transaction_Save_Company_History_Error ({Information.Err().Number.ToString()}) {excep.Message} : {errString}", "modCommon (Transaction)");
				return result;
			}
		}

		internal static bool Transaction_Get_Company_History_Recordsets(string in_Company_List)
		{

			bool result = false;
			string errMsg = "";
			try
			{

				string Query = "";

				result = false;
				errMsg = "init";

				modAdminCommon.Open_Client_Connection();

				// CREATE THE  COMPANY RECORDSET
				if (modGlobalVars.snp_Company == null)
				{
					modGlobalVars.snp_Company = new ADORecordSetHelper();
				}

				if (modGlobalVars.snp_Company.State == ConnectionState.Open)
				{
					modGlobalVars.snp_Company.Close();
				}

				errMsg = "contacts";
				// CREATE THE  CONTACTS RECORDSET
				if (modGlobalVars.snp_Contacts == null)
				{
					modGlobalVars.snp_Contacts = new ADORecordSetHelper();
				}

				if (modGlobalVars.snp_Contacts.State == ConnectionState.Open)
				{
					modGlobalVars.snp_Contacts.Close();
				}

				errMsg = "Phones";
				// CREATE THE  COMPANY PHONES RECORDSET
				if (modGlobalVars.snp_Company_Phones == null)
				{
					modGlobalVars.snp_Company_Phones = new ADORecordSetHelper();
				}

				if (modGlobalVars.snp_Company_Phones.State == ConnectionState.Open)
				{
					modGlobalVars.snp_Company_Phones.Close();
				}

				errMsg = "Bus Types";
				// CREATE THE  COMPANY BUSINESS TYPES RECORDSET
				if (modGlobalVars.snp_Company_Btypes == null)
				{
					modGlobalVars.snp_Company_Btypes = new ADORecordSetHelper();
				}

				if (modGlobalVars.snp_Company_Btypes.State == ConnectionState.Open)
				{
					modGlobalVars.snp_Company_Btypes.Close();
				}


				errMsg = "Comp Certs";
				// CREATE THE  COMPANY CERTs RECORDSET
				if (modGlobalVars.snp_Company_Certs == null)
				{
					modGlobalVars.snp_Company_Certs = new ADORecordSetHelper();
				}

				if (modGlobalVars.snp_Company_Certs.State == ConnectionState.Open)
				{
					modGlobalVars.snp_Company_Certs.Close();
				}

				Cursor.Current = Cursors.WaitCursor;
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Selecting a Snapshot of Company Information", Color.Blue);


				result = false;
				errMsg = "Query 1";

				// ********************************************
				// GET ALL COMPANY RECORDS FOR THE AIRCRAFT
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Selecting Company Copy ...", Color.Blue);
				Query = "SELECT distinct Company.* FROM Company WITH(NOLOCK)";
				Query = $"{Query} where comp_id in ({in_Company_List})  AND comp_journ_id=0";
				modGlobalVars.snp_Company.Open(Query, modAdminCommon.CLIENT_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
				if (!(modGlobalVars.snp_Company.BOF && modGlobalVars.snp_Company.EOF))
				{
					modGlobalVars.snp_Company.MoveFirst();
				}
				modGlobalVars.snp_Company.ActiveConnection = null;

				//snp_TransAircraft_OtherCompanies

				errMsg = "Query 2";
				// ********************************************
				// GET ALL COMPANY PHONE RECORDS FOR THE AIRCRAFT
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Selecting Company Phone Number Copies ...", Color.Blue);
				Query = "SELECT distinct * FROM Phone_Numbers WITH(NOLOCK)";
				Query = $"{Query} where pnum_comp_id in ({in_Company_List})";
				Query = $"{Query} and pnum_journ_id = 0";
				modGlobalVars.snp_Company_Phones.Open(Query, modAdminCommon.CLIENT_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
				if (!(modGlobalVars.snp_Company_Phones.BOF && modGlobalVars.snp_Company_Phones.EOF))
				{
					modGlobalVars.snp_Company_Phones.MoveFirst();
				}
				modGlobalVars.snp_Company_Phones.ActiveConnection = null;

				errMsg = "Query 3a";

				// ********************************************
				// GET ALL COMPANY BUSINESS TYPES
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Selecting Company Business Type Copies ...", Color.Blue);
				Query = "SELECT distinct * FROM Business_Type_Reference WITH(NOLOCK)";
				Query = $"{Query} where bustypref_comp_id in ({in_Company_List})  and bustypref_journ_id = 0";
				modGlobalVars.snp_Company_Btypes.Open(Query, modAdminCommon.CLIENT_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
				if (!(modGlobalVars.snp_Company_Btypes.BOF && modGlobalVars.snp_Company_Btypes.EOF))
				{
					modGlobalVars.snp_Company_Btypes.MoveFirst();
				}
				modGlobalVars.snp_Company_Btypes.ActiveConnection = null;

				// ********************************************
				// GET ALL COMPANY CERTS
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Selecting Company Certificate Copies ...", Color.Blue);
				Query = "SELECT distinct * FROM Company_Certification WITH(NOLOCK)";
				Query = $"{Query} where ccert_comp_id in ({in_Company_List})";
				Query = $"{Query} and ccert_journ_id = 0";
				modGlobalVars.snp_Company_Certs.Open(Query, modAdminCommon.CLIENT_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
				if (!(modGlobalVars.snp_Company_Certs.BOF && modGlobalVars.snp_Company_Certs.EOF))
				{
					modGlobalVars.snp_Company_Certs.MoveFirst();
				}
				modGlobalVars.snp_Company_Certs.ActiveConnection = null;


				// ********************************************
				// GET ALL CONTACT RECORDS FOR THE AIRCRAFT
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Selecting Contacts Copies ...", Color.Blue);
				Query = "SELECT * FROM Contact WITH (NOLOCK)";
				Query = $"{Query} where contact_comp_id in ({in_Company_List})";
				Query = $"{Query} AND contact_journ_id=0";
				modGlobalVars.snp_Contacts.Open(Query, modAdminCommon.CLIENT_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
				if (!(modGlobalVars.snp_Contacts.BOF && modGlobalVars.snp_Contacts.EOF))
				{
					modGlobalVars.snp_Contacts.MoveFirst();
				}

				errMsg = "active disconn ";
				modGlobalVars.snp_Contacts.ActiveConnection = null;

				return true;
			}
			catch (System.Exception excep)
			{

				Cursor.Current = CursorHelper.CursorDefault;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				errMsg = $"{excep.Message} ({Information.Err().Number.ToString()}) {errMsg} cin:{in_Company_List}";

				modAdminCommon.Report_Error($"Transaction_Get_Company_History_Recordsets: {errMsg}", "modCommon (Transaction)");
				result = false;
			}
			return result;
		}

		internal static void Transaction_Insert_Priority_Event(string inCatCode, int inACID, int inJournID, string inDescription = "", int incompid = 0, int inContactId = 0, int inSeqNo = 0, bool Update = false, string inSubject = "")
		{

			string Query = "";
			string Subject = "";

			try
			{

				if (!Update)
				{

					Query = "INSERT INTO Priority_Events (";
					Query = $"{Query}priorev_category_code, priorev_subject,";
					Query = $"{Query}priorev_description, priorev_ac_id, priorev_journ_id,";
					Query = $"{Query}priorev_comp_id, priorev_contact_id, priorev_journ_seq_no,";
					Query = $"{Query}priorev_user_id)  VALUES ('{inCatCode.Trim()}',";

					if (inSubject.Trim() != "")
					{
						Query = $"{Query}'{inSubject.Trim()}',";
					}
					else
					{
						Query = $"{Query}'{GetPriorityEventSubject(inCatCode.Trim()).Trim()}',";
					}
					if (inDescription.Trim() != "")
					{
						Query = $"{Query}'{StringsHelper.Replace(inDescription.Trim(), "'", "''", 1, -1, CompareMethod.Binary)}',";
					}
					else
					{
						Query = $"{Query}'',";
					}

					Query = $"{Query}{inACID.ToString()},";
					Query = $"{Query}{inJournID.ToString()},";

					if (incompid > 0)
					{
						Query = $"{Query}{incompid.ToString()},";
					}
					else
					{
						Query = $"{Query}0,";
					}

					if (inContactId > 0)
					{
						Query = $"{Query}{inContactId.ToString()},";
					}
					else
					{
						Query = $"{Query}0,";
					}

					if (inSeqNo > 0)
					{
						Query = $"{Query}{inSeqNo.ToString()},";
					}
					else
					{
						Query = $"{Query}0,";
					}

					Query = $"{Query}'{modAdminCommon.gbl_User_ID}')";

				}
				else
				{

					Query = "UPDATE Priority_Events SET  priorev_action_date = NULL,";
					Query = $"{Query}priorev_category_code = '{inCatCode}',";

					Query = $"{Query}priorev_subject = '{GetPriorityEventSubject(inCatCode.Trim()).Trim()}',";

					if (inDescription.Trim() != "")
					{
						Query = $"{Query}priorev_description = '{StringsHelper.Replace(inDescription.Trim(), "'", "''", 1, -1, CompareMethod.Binary)}',";
					}
					else
					{
						Query = $"{Query}priorev_description = '',";
					}

					Query = $"{Query}priorev_user_id = '{modAdminCommon.gbl_User_ID}'";

					Query = $"{Query} WHERE priorev_ac_id = {inACID.ToString()}";

					if (incompid > 0)
					{
						Query = $"{Query} AND priorev_comp_id = {incompid.ToString()}";
					}
					else
					{
						Query = $"{Query} AND priorev_comp_id = 0";
					}

					if (inContactId > 0)
					{
						Query = $"{Query} AND priorev_contact_id = {inContactId.ToString()}";
					}
					else
					{
						Query = $"{Query} AND priorev_contact_id = 0";
					}

					if (inJournID > 0)
					{
						Query = $"{Query} AND priorev_journ_id = {inJournID.ToString()}";
					}
					else
					{
						Query = $"{Query} AND priorev_journ_id = 0";
					}

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
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Transaction_Insert_Priority_Event_Error ({Information.Err().Number.ToString()}) {excep.Message} ACId[{inACID.ToString()}]", "modCommon (Transaction)");
				return;
			}

		}

		internal static object GetSerNoValue(string inSerNo)
		{

			StringBuilder tmpSerNo = new StringBuilder();

			try
			{


				if (Information.IsNumeric(inSerNo))
				{
					return inSerNo;
				}
				else
				{
					tmpSerNo = new StringBuilder("");
					int tempForEndVar = Strings.Len(inSerNo);
					for (int i = 1; i <= tempForEndVar; i++)
					{
						if (Information.IsNumeric(inSerNo.Substring(Math.Min(i - 1, inSerNo.Length), Math.Min(1, Math.Max(0, inSerNo.Length - (i - 1))))))
						{
							tmpSerNo.Append(inSerNo.Substring(Math.Min(i - 1, inSerNo.Length), Math.Min(1, Math.Max(0, inSerNo.Length - (i - 1)))));
						}
					}
					return Convert.ToInt32(Double.Parse($"0{tmpSerNo.ToString()}"));
				}
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"GetSerNoValue_Error: {excep.Message}", "modCommon (Transaction)");
			}
			return null;
		}

		internal static bool Aircraft_RegisteredAs_Get_Recordset(int in_company_id, int in_Contact_ID)
		{


			bool result = false;
			string Query = "";
			string strStatus = "";
			int lError = 0; // Hold The Error Number Value
			string strError = ""; // Hold The Error Description Value

			try
			{

				//******************************************************
				// CREATE REGISTEREDAS COMPANY RECORDSETS

				// CREATE THE REGISTEREDAS COMPANY RECORDSET
				strStatus = "snp_RegisteredAs_Company";
				if (modGlobalVars.snp_RegisteredAs_Company == null)
				{
					modGlobalVars.snp_RegisteredAs_Company = new ADORecordSetHelper();
				}

				if (modGlobalVars.snp_RegisteredAs_Company.State == ConnectionState.Open)
				{
					modGlobalVars.snp_RegisteredAs_Company.Close();
				}

				// CREATE THE REGISTEREDAS CONTACTS RECORDSET
				strStatus = "snp_RegisteredAs_Contacts";
				if (modGlobalVars.snp_RegisteredAs_Contacts == null)
				{
					modGlobalVars.snp_RegisteredAs_Contacts = new ADORecordSetHelper();
				}

				if (modGlobalVars.snp_RegisteredAs_Contacts.State == ConnectionState.Open)
				{
					modGlobalVars.snp_RegisteredAs_Contacts.Close();
				}

				// CREATE THE REGISTEREDAS COMPANY PHONES RECORDSET
				strStatus = "snp_RegisteredAs_Company_Phones";
				if (modGlobalVars.snp_RegisteredAs_Company_Phones == null)
				{
					modGlobalVars.snp_RegisteredAs_Company_Phones = new ADORecordSetHelper();
				}

				if (modGlobalVars.snp_RegisteredAs_Company_Phones.State == ConnectionState.Open)
				{
					modGlobalVars.snp_RegisteredAs_Company_Phones.Close();
				}

				// CREATE THE REGISTEREDAS COMPANY BUSINESS TYPES RECORDSET
				strStatus = "snp_RegisteredAs_Company_Btypes";
				if (modGlobalVars.snp_RegisteredAs_Company_Btypes == null)
				{
					modGlobalVars.snp_RegisteredAs_Company_Btypes = new ADORecordSetHelper();
				}

				if (modGlobalVars.snp_RegisteredAs_Company_Btypes.State == ConnectionState.Open)
				{
					modGlobalVars.snp_RegisteredAs_Company_Btypes.Close();
				}

				// CREATE THE REGISTEREDAS COMPANY CERT RECORDSET
				strStatus = "snp_RegisteredAs_Company_Certs";
				if (modGlobalVars.snp_RegisteredAs_Company_Certs == null)
				{
					modGlobalVars.snp_RegisteredAs_Company_Certs = new ADORecordSetHelper();
				}

				if (modGlobalVars.snp_RegisteredAs_Company_Certs.State == ConnectionState.Open)
				{
					modGlobalVars.snp_RegisteredAs_Company_Certs.Close();
				}

				Cursor.Current = Cursors.WaitCursor;
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Selecting a Snapshot of REGISTERED AS Information", Color.Blue);

				result = false;

				// ********************************************
				// GET REGISTEREDAS COMPANY RECORD
				strStatus = "Select Company";
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Selecting REGISTERED AS Company Copy ...", Color.Blue);
				Query = $"SELECT * FROM Company WITH(NOLOCK)  where comp_id = {in_company_id.ToString()}";
				Query = $"{Query} AND comp_journ_id=0";
				modGlobalVars.snp_RegisteredAs_Company.Open(Query, modAdminCommon.CLIENT_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
				if (!(modGlobalVars.snp_RegisteredAs_Company.BOF && modGlobalVars.snp_RegisteredAs_Company.EOF))
				{
					modGlobalVars.snp_RegisteredAs_Company.MoveFirst();
				}
				else
				{
					return result;
				}
				modGlobalVars.snp_RegisteredAs_Company.ActiveConnection = null;

				// ********************************************
				// GET ALL COMPANY PHONE RECORDS FOR THE REGISTEREDAS
				strStatus = "Select Phone Numbers";
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Selecting Aircraft Company Phone Number Copies ...", Color.Blue);
				Query = $"SELECT * FROM Phone_Numbers WITH(NOLOCK)  where pnum_comp_id = {in_company_id.ToString()}";
				Query = $"{Query} AND pnum_journ_id = 0";
				modGlobalVars.snp_RegisteredAs_Company_Phones.Open(Query, modAdminCommon.CLIENT_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
				if (!(modGlobalVars.snp_RegisteredAs_Company_Phones.BOF && modGlobalVars.snp_RegisteredAs_Company_Phones.EOF))
				{
					modGlobalVars.snp_RegisteredAs_Company_Phones.MoveFirst();
				}
				modGlobalVars.snp_RegisteredAs_Company_Phones.ActiveConnection = null;

				// ********************************************
				// GET ALL CONTACT RECORDS FOR THE REGISTEREDAS
				strStatus = "Select Aircraft Contacts";
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Selecting Aircraft Contacts Copies ...", Color.Blue);
				Query = "SELECT distinct contact.* FROM Contact WITH(NOLOCK)";
				Query = $"{Query} WHERE contact_comp_id ={in_company_id.ToString()} AND contact_journ_id=0";
				Query = $"{Query} AND contact_id={in_Contact_ID.ToString()}";
				modGlobalVars.snp_RegisteredAs_Contacts.Open(Query, modAdminCommon.CLIENT_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
				if (!(modGlobalVars.snp_RegisteredAs_Contacts.BOF && modGlobalVars.snp_RegisteredAs_Contacts.EOF))
				{
					modGlobalVars.snp_RegisteredAs_Contacts.MoveFirst();
				}
				modGlobalVars.snp_RegisteredAs_Contacts.ActiveConnection = null;

				// ********************************************
				// GET ALL BUSINESS TYPE RECORDS FOR THE REGISTEREDAS
				strStatus = "Select REGISTEREDAS Business Types";
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Selecting REGISTEREDAS Business Types ...", Color.Blue);
				Query = "SELECT * FROM Business_Type_Reference WITH(NOLOCK)";
				Query = $"{Query} WHERE bustypref_comp_id ={in_company_id.ToString()}";
				Query = $"{Query} AND bustypref_journ_id=0";
				modGlobalVars.snp_RegisteredAs_Company_Btypes.Open(Query, modAdminCommon.CLIENT_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
				if (!(modGlobalVars.snp_RegisteredAs_Company_Btypes.BOF && modGlobalVars.snp_RegisteredAs_Company_Btypes.EOF))
				{
					modGlobalVars.snp_RegisteredAs_Company_Btypes.MoveFirst();
				}
				modGlobalVars.snp_RegisteredAs_Company_Btypes.ActiveConnection = null;

				// ********************************************
				// GET ALL CERT RECORDS FOR THE REGISTEREDAS
				strStatus = "Select REGISTEREDAS Certificate Recs";
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Selecting REGISTEREDAS Certificate ...", Color.Blue);
				Query = "SELECT * FROM Company_Certification WITH(NOLOCK)";
				Query = $"{Query} WHERE ccert_comp_id ={in_company_id.ToString()}";
				Query = $"{Query} AND ccert_journ_id=0";
				modGlobalVars.snp_RegisteredAs_Company_Certs.Open(Query, modAdminCommon.CLIENT_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
				if (!(modGlobalVars.snp_RegisteredAs_Company_Certs.BOF && modGlobalVars.snp_RegisteredAs_Company_Certs.EOF))
				{
					modGlobalVars.snp_RegisteredAs_Company_Certs.MoveFirst();
				}
				modGlobalVars.snp_RegisteredAs_Company_Certs.ActiveConnection = null;

				result = true;
				Cursor.Current = CursorHelper.CursorDefault;
			}
			catch (System.Exception excep)
			{

				// 10/11/2002 - By David D. Cruger; Hold These Error Values As the RollbackTrans will clear them
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lError = Information.Err().Number;
				strError = excep.Message;

				Cursor.Current = CursorHelper.CursorDefault;
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);

				// 10/11/2002 - By David D. Cruger; Add the Held Error Values to the Report_Error Procedure
				Information.Err().Number = lError;
				Information.Err().Description = strError;
				modAdminCommon.Report_Error($"Aircraft_REGISTEREDAS_Get_Recordset: [{strStatus}]  Query={Query} AC={in_company_id.ToString()}", "modCommon");

				result = false;
			}

			return result;
		}

		internal static bool Transaction_Save_RegisteredAs_History(ref int in_company_id, int in_journal_id, string in_Business_Type, ADORecordSetHelper in_snp_Company, ADORecordSetHelper in_snp_Contact, ADORecordSetHelper in_snp_Company_Phones, ADORecordSetHelper in_snp_Company_Btypes, ADORecordSetHelper in_snp_Company_Certs, int in_Fractional_Owner_ID = 0, bool in_SendToWeb = true)
		{


			bool result = false;
			try
			{

				string Query = "";
				int i = 0;
				string CurrentDateTime = "";
				CurrentDateTime = modAdminCommon.GetDateTime();
				result = false;

				if (in_company_id == 0)
				{
					in_company_id = Transaction_Create_Awaiting_Documentation_Company(in_company_id, in_journal_id, frm_Aircraft_Change.DefInstance.cbo_Unknown_Country.Text, frm_Aircraft_Change.DefInstance.cbo_Unknown_State.Text.Substring(0, Math.Min(frm_Aircraft_Change.DefInstance.cbo_Unknown_State.Text.IndexOf(", "), frm_Aircraft_Change.DefInstance.cbo_Unknown_State.Text.Length)), in_Business_Type, in_SendToWeb);
					if (in_company_id > 0)
					{
						return true;
					}
					else
					{
						// NOT SUCCESSFUL IN CREATING AWAITING DOCUMENTATION COMPANY
						return false;
					}
				}

				// **************************************************************
				// DEFINE ALL OF THE RECORDSETS TO BE USED FOR ADDING/UPDATING
				ADORecordSetHelper ado_new_company = new ADORecordSetHelper();
				ADORecordSetHelper ad_new_contacts = new ADORecordSetHelper();
				ADORecordSetHelper ado_new_phone = new ADORecordSetHelper();
				ADORecordSetHelper ado_new_BusType = new ADORecordSetHelper();
				ADORecordSetHelper ado_new_Certs = new ADORecordSetHelper();


				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Opening Companiess for Action ... ", Color.Blue);
				ado_new_company.Open("Select * from Company where comp_id=-1", modAdminCommon.ADODB_Trans_conn, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Opening Contacts for Action ... ", Color.Blue);
				ad_new_contacts.Open("Select * from Contact where contact_id=-1", modAdminCommon.ADODB_Trans_conn, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);
				//TEMP HOLD  - MSW 1/30/12
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Opening Phone Numbers for Action ... ", Color.Blue);
				//ado_new_phone.Open "Phone_Numbers", ADODB_Trans_conn, adOpenStatic, adLockOptimistic, adCmdTable
				ado_new_phone.Open("Select * from Phone_Numbers where pnum_comp_id = -1", modAdminCommon.ADODB_Trans_conn, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);


				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Opening Company Business Types for Action ... ", Color.Blue);
				ado_new_BusType.Open("Select * from Business_Type_Reference where bustypref_id=-1", modAdminCommon.ADODB_Trans_conn, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Opening Company Certs for Action ... ", Color.Blue);
				ado_new_Certs.Open("Select * from Company_Certification where ccert_id=-1", modAdminCommon.ADODB_Trans_conn, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);


				Cursor.Current = Cursors.WaitCursor;

				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Saving a Historical REGISTEREDAS Record ... ", Color.Blue);
				if (!(in_snp_Company.BOF && in_snp_Company.EOF))
				{
					in_snp_Company.MoveFirst();

					while(!in_snp_Company.EOF)
					{
						//UPGRADE_ISSUE: (2064) ADODB.CursorOptionEnum property CursorOptionEnum.adAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_ISSUE: (2064) ADODB.Recordset method ado_new_company.Supports was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						if (ado_new_company.Supports(UpgradeStubs.ADODB_CursorOptionEnum.getadAddNew()))
						{
							ado_new_company.AddNew();
							i = 0;

							while((i < in_snp_Company.FieldsMetadata.Count))
							{
								ado_new_company[i] = in_snp_Company[i];
								i++;
							};
							if (in_Fractional_Owner_ID > 0)
							{
								ado_new_company["comp_fractowr_id"] = Conversion.Val($"{in_Fractional_Owner_ID.ToString()}");
							}
							ado_new_company["comp_journ_id"] = in_journal_id;
							ado_new_company["comp_active_flag"] = "N";

							if (in_SendToWeb)
							{ //aey 7/28/04
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								ado_new_company["comp_action_date"] = DBNull.Value;
							}
							else
							{
								ado_new_company["comp_action_date"] = CurrentDateTime;
							}


							// ***************************************************
							// PROTECT AGAINST ADDING A DUPLICATE COMPANY RECORDS
							try
							{
								ado_new_company.Update();
								//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
							}
							catch
							{
							}
							if (ErrorHandlingHelper.ResumeNextExpr<bool>(() => Information.Err().Number == -2147217873))
							{
								try
								{ // check for duplicate error code
									ado_new_company.CancelUpdate();
								}
								catch
								{
								}
							}
							else
							{
								Exception ex = null;
								ErrorHandlingHelper.ResumeNext(out ex);
								// if error is not a duplcate use normal error handling
								if (ex != null)
								{
									try
									{
										throw new Exception();
									}
									catch
									{
									}
								}
							}


						}
						else
						{
							// If ado_new_company.Supports(adAddNew) Then
							return result;
						}
						in_snp_Company.MoveNext();
					};
				} // If Not (in_snp_Company.BOF And in_snp_Company.EOF) Then


				// ************************************
				// STORE THE CONTACT INFORMATION
				//   Debug.Print "REGISTEREDAS Contacts:"
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Saving a Historical REGISTEREDAS Contact Records ... ", Color.Blue);
				if (!(in_snp_Contact.BOF && in_snp_Contact.EOF))
				{
					in_snp_Contact.MoveFirst();

					while(!in_snp_Contact.EOF)
					{

						//UPGRADE_ISSUE: (2064) ADODB.CursorOptionEnum property CursorOptionEnum.adAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_ISSUE: (2064) ADODB.Recordset method ad_new_contacts.Supports was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						if (ad_new_contacts.Supports(UpgradeStubs.ADODB_CursorOptionEnum.getadAddNew()))
						{
							ad_new_contacts.AddNew();
							i = 0;

							while((i < in_snp_Contact.FieldsMetadata.Count))
							{
								ad_new_contacts[i] = in_snp_Contact[i];
								i++;
							};
							ad_new_contacts["contact_journ_id"] = in_journal_id;
							//            Debug.Print in_snp_Contact!contact_comp_id & "-" & in_snp_Contact!contact_id & "-" & in_Journal_ID & ";"
							if (in_SendToWeb)
							{ //aey 7/28/04
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								ad_new_contacts["contact_action_date"] = DBNull.Value;
							}
							else
							{
								ad_new_contacts["contact_action_date"] = CurrentDateTime;
							}


							// ***************************************************
							// PROTECT AGAINST ADDING A DUPLICATE CONTACTS
							try
							{
								ad_new_contacts.Update();
								//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
							}
							catch
							{
							}
							if (ErrorHandlingHelper.ResumeNextExpr<bool>(() => Information.Err().Number == -2147217873))
							{
								try
								{ // check for duplicate error code
									ad_new_contacts.CancelUpdate();
								}
								catch
								{
								}
							}
							else
							{
								Exception ex_2 = null;
								ErrorHandlingHelper.ResumeNext(out ex_2);
								// if error is not a duplcate use normal error handling
								if (ex_2 != null)
								{
									try
									{
										throw new Exception();
									}
									catch
									{
									}
								}
							}


						}
						else
						{
							// If ad_new_contacts.Supports(adAddNew) Then
							return result;
						}
						in_snp_Contact.MoveNext();
					};
				} // If Not (in_snp_Contact.BOF And in_snp_Contact.EOF) Then

				// **************************************************
				// STORE THE COMPANY PHONE NUMBER INFORMATION
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Saving a Historical REGISTEREDAS Phone Numbers ... ", Color.Blue);
				if (!(in_snp_Company_Phones.BOF && in_snp_Company_Phones.EOF))
				{
					in_snp_Company_Phones.MoveFirst();

					while(!in_snp_Company_Phones.EOF)
					{
						//UPGRADE_ISSUE: (2064) ADODB.CursorOptionEnum property CursorOptionEnum.adAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_ISSUE: (2064) ADODB.Recordset method ado_new_phone.Supports was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						if (ado_new_phone.Supports(UpgradeStubs.ADODB_CursorOptionEnum.getadAddNew()))
						{
							ado_new_phone.AddNew();

							i = ado_new_phone.FieldsMetadata.Count;
							i = 0;

							while((i < in_snp_Company_Phones.FieldsMetadata.Count))
							{

								if (ado_new_phone.GetField(i).FieldMetadata.ColumnName != "pnum_id")
								{ // added MSW - 11/3/21
									ado_new_phone[i] = in_snp_Company_Phones[i];
								}

								i++;
							};

							if (ErrorHandlingHelper.ResumeNextExpr<bool>(() => Convert.ToDouble(ado_new_phone["pnum_journ_id"]) == in_journal_id))
							{
								try
								{
									ado_new_phone.CancelUpdate();
								}
								catch
								{
								}
							}
							else
							{
								ErrorHandlingHelper.ResumeNext(
									() => {ado_new_phone["pnum_journ_id"] = in_journal_id;}, 
									() => {ado_new_phone.Update();});
							}

							// PROTECT AGAINST ADDING A DUPLICATE PHONE NUMBERS
							// this would work if the table had unique keys

							//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
							if (Information.Err().Number == -2147217873)
							{ // check for duplicate error code
								ado_new_phone.CancelUpdate();
							}
							else
							{
								// if error is not a duplcate use normal error handling
								//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
								if (Information.Err().Number > 0)
								{
									throw new Exception();
								}
							}

						}
						else
						{
							// If ado_new_phone.Supports(adAddNew) Then
							return result;
						}
						in_snp_Company_Phones.MoveNext();
					}; // Do While Not in_snp_Company_Phones.EOF
				} // If Not (in_snp_Company_Phones.BOF And in_snp_Company_Phones.EOF) Then


				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Saving a Historical REGISTEREDAS Business Types  ... ", Color.Blue);
				//UPGRADE_ISSUE: (2064) ADODB.CursorOptionEnum property CursorOptionEnum.adAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method ado_new_BusType.Supports was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				if (ado_new_BusType.Supports(UpgradeStubs.ADODB_CursorOptionEnum.getadAddNew()))
				{

					while(!in_snp_Company_Btypes.EOF)
					{
						ado_new_BusType.AddNew();
						i = 0;

						while((i < in_snp_Company_Btypes.FieldsMetadata.Count))
						{
							if (ado_new_BusType.GetField(i).FieldMetadata.ColumnName != "bustypref_id")
							{
								ado_new_BusType[i] = in_snp_Company_Btypes[i];
							}
							i++;
						};
						ado_new_BusType["bustypref_journ_id"] = in_journal_id;


						// ***************************************************
						// PROTECT AGAINST ADDING A DUPLICATE BUSINESS TYPE
						try
						{
							ado_new_BusType.Update();
							//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
						}
						catch
						{
						}
						if (ErrorHandlingHelper.ResumeNextExpr<bool>(() => Information.Err().Number == -2147217873))
						{
							try
							{ // check for duplicate error code
								ado_new_BusType.CancelUpdate();
							}
							catch
							{
							}
						}
						else
						{
							Exception ex_3 = null;
							ErrorHandlingHelper.ResumeNext(out ex_3);
							// if error is not a duplcate use normal error handling
							if (ex_3 != null)
							{
								try
								{
									throw new Exception();
								}
								catch
								{
								}
							}
						}


						in_snp_Company_Btypes.MoveNext();
					}; //  Do While Not snp_BusType.EOF
				}
				else
				{
					// If ado_new_BusType.Supports(adAddNew) Then
					return result;
				}


				// ****************************************
				// SAVING COMPANY CERTS
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Saving a Historical REGISTEREDAS Certs  ... ", Color.Blue);
				//UPGRADE_ISSUE: (2064) ADODB.CursorOptionEnum property CursorOptionEnum.adAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method ado_new_Certs.Supports was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				if (ado_new_Certs.Supports(UpgradeStubs.ADODB_CursorOptionEnum.getadAddNew()))
				{

					while(!in_snp_Company_Certs.EOF)
					{
						ado_new_Certs.AddNew();
						i = 0;

						while((i < in_snp_Company_Certs.FieldsMetadata.Count))
						{
							if (ado_new_Certs.GetField(i).FieldMetadata.ColumnName != "ccert_id" && ado_new_Certs.GetField(i).FieldMetadata.ColumnName != "ccert_dsg_code")
							{
								ado_new_Certs[i] = in_snp_Company_Certs[i];
							}
							i++;
						};
						ado_new_Certs["ccert_journ_id"] = in_journal_id;


						try
						{
							ado_new_Certs.Update();
							//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
						}
						catch
						{
						}
						if (ErrorHandlingHelper.ResumeNextExpr<bool>(() => Information.Err().Number == -2147217873))
						{
							try
							{ // check for duplicate error code
								ado_new_Certs.CancelUpdate();
							}
							catch
							{
							}
						}
						else
						{
							Exception ex_4 = null;
							ErrorHandlingHelper.ResumeNext(out ex_4);
							// if error is not a duplcate use normal error handling
							if (ex_4 != null)
							{
								try
								{
									throw new Exception();
								}
								catch
								{
								}
							}
						}


						in_snp_Company_Certs.MoveNext();
					}; //  Do While Not snp_Certs.EOF
				}
				else
				{
					// If ado_new_Certs.Supports(adAddNew) Then
					return result;
				}


				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "REGISTEREDAS Company Saves Complete.", Color.Blue);
				result = true;


				ad_new_contacts.Close();
				ado_new_company.Close();
				ado_new_phone.Close();
				ado_new_BusType.Close();
				ado_new_Certs.Close();

				ado_new_company = null;
				ad_new_contacts = null;
				ado_new_phone = null;
				ado_new_BusType = null;
				ado_new_Certs = null;

				return result;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Transaction_Save_RegisteredAs_History_Error ({Information.Err().Number.ToString()}) {excep.Message}", "modCommon (Transaction)");
				return result;
			}
		}

		internal static bool Fractional_Pending_Get_Recordsets(int in_Aircraft_ID)
		{


			bool result = false;
			try
			{

				string Query = "";

				if (modGlobalVars.snp_Fractions_Pending == null)
				{
					modGlobalVars.snp_Fractions_Pending = new ADORecordSetHelper();
				}

				if (modGlobalVars.snp_Fractions_Pending.State == ConnectionState.Open)
				{
					modGlobalVars.snp_Fractions_Pending.Close();
				}


				Cursor.Current = Cursors.WaitCursor;
				result = false;
				// ***********************************************
				// Selecting Pending Fractional Sales - only get used if whole sale for fractional aircraft
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Selecting Pending Fractional Sales Records ... ", Color.Blue);

				Query = $"SELECT * FROM Aircraft_Reference WHERE cref_ac_id = {in_Aircraft_ID.ToString()} ";
				Query = $"{Query}  AND cref_journ_id = 0  AND cref_contact_type in ('97','17') ";
				modGlobalVars.snp_Fractions_Pending.Open(Query, modAdminCommon.CLIENT_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
				if (!(modGlobalVars.snp_Fractions_Pending.BOF && modGlobalVars.snp_Fractions_Pending.EOF))
				{
					modGlobalVars.snp_Fractions_Pending.MoveFirst();
				}
				modGlobalVars.snp_Fractions_Pending.ActiveConnection = null;

				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
				result = true;
				Cursor.Current = CursorHelper.CursorDefault;
			}
			catch (System.Exception excep)
			{

				Cursor.Current = CursorHelper.CursorDefault;
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fractional_Pending_Get_Recordsets_Error ({Information.Err().Number.ToString()}) {excep.Message}", "modCommon");
				result = false;
			}

			return result;
		}

		internal static bool Modify_Share_Reference(int inAircraft, int inJournal, int inCompany, int inContact, int inType, int inKey)
		{

			bool result = false;
			try
			{
				result = true;
				StringBuilder Query = new StringBuilder();

				Query = new StringBuilder($"cref_comp_id = {inCompany.ToString()}");
				Query.Append($" and cref_contact_id = {inContact.ToString()}");
				Query.Append(" and cref_contact_type = '97' ");
				modGlobalVars.snp_TransShare_Reference.Filter = Query.ToString();
				if (!(modGlobalVars.snp_TransShare_Reference.BOF && modGlobalVars.snp_TransShare_Reference.EOF))
				{
					modGlobalVars.snp_TransShare_Reference.MoveFirst();
					// RTW - 3/7/07 - ADDED PROTECTION SO IT CAN'T ADD TOO MANY REFERENCES
					if (modGlobalVars.snp_TransShare_Reference.RecordCount <= 10)
					{


						while(!modGlobalVars.snp_TransShare_Reference.EOF)
						{
							Query = new StringBuilder("insert into Share_Reference (sref_cref_id, sref_comp_id,sref_contact_id,sref_contact_type) ");
							Query.Append($"values ({inKey.ToString()},{Convert.ToString(modGlobalVars.snp_TransShare_Reference["sref_comp_id"])},{Convert.ToString(modGlobalVars.snp_TransShare_Reference["sref_contact_id"])},'{Convert.ToString(modGlobalVars.snp_TransShare_Reference["sref_contact_type"])}')");
							DbCommand TempCommand = null;
							TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
							TempCommand.CommandText = Query.ToString();
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'ADODB.ExecuteOptionEnum' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
							TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
							TempCommand.ExecuteNonQuery();
							modGlobalVars.snp_TransShare_Reference.MoveNext();
						};
					}
					else
					{
						modAdminCommon.Record_Error("Transaction", $"Modify_Share_Reference_Error: TOO MANY RECORDS - {modGlobalVars.snp_TransShare_Reference.RecordCount.ToString()}");
					} // IF MORE THAN 10 SHARE OWNERS

				} // IF SHARE OWNERS TO COPY
			}
			catch (System.Exception excep)
			{

				result = false;
				modAdminCommon.Record_Error("Transaction", $"Modify_Share_Reference_Error:{excep.Message}");
			}
			return result;
		}


		internal static bool Delete_Transaction(int inAC_ID, int inJourn_ID)
		{

			try
			{
				int RememberTimeout = 0;
				string Query = "";

				Cursor.Current = Cursors.WaitCursor;
				// BEGIN THE TRANSACTION
				modAdminCommon.ADO_Transaction("BeginTrans");

				//  DELETE THE JOURNAL ENTRY AND ANYTHING ASSOCIATED
				Query = $"EXEC HomebaseDeleteAllRecordsBasedOnJournalId {inJourn_ID.ToString()}";

				RememberTimeout = UpgradeHelpers.DB.DbConnectionHelper.GetCommandTimeOut(modAdminCommon.ADODB_Trans_conn);
				UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(modAdminCommon.ADODB_Trans_conn, 50000);
				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'ADODB.ExecuteOptionEnum' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();
				UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(modAdminCommon.ADODB_Trans_conn, RememberTimeout);

				// PLACE AN ENTRY INTO THE DELETE LOG
				modAdminCommon.Record_Delete_Log_Entry("Transaction", inAC_ID, inJourn_ID);

				modAdminCommon.ADO_Transaction("CommitTrans");

				modAdminCommon.Record_Event("Journal", "Delete Transaction/Journal Record", inAC_ID, inJourn_ID, 0);
				Cursor.Current = CursorHelper.CursorDefault;
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Delete_Transaction_Error ({Information.Err().Number.ToString()}) {excep.Message}", "modCommon (Transaction)");
			}

			return false;
		}
		internal static bool Delete_Yacht_Transaction(int YT_ID, int inJourn_ID)
		{

			try
			{
				int RememberTimeout = 0;
				string Query = "";

				Cursor.Current = Cursors.WaitCursor;
				// BEGIN THE TRANSACTION
				modAdminCommon.ADO_Transaction("BeginTrans");

				//  DELETE THE JOURNAL ENTRY AND ANYTHING ASSOCIATED
				Query = $"EXEC HomebaseDeleteAllRecordsBasedOnYachtIdJournId {YT_ID.ToString()}, {inJourn_ID.ToString()}";

				RememberTimeout = UpgradeHelpers.DB.DbConnectionHelper.GetCommandTimeOut(modAdminCommon.ADODB_Trans_conn);
				UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(modAdminCommon.ADODB_Trans_conn, 50000);
				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'ADODB.ExecuteOptionEnum' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();
				UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(modAdminCommon.ADODB_Trans_conn, RememberTimeout);

				// PLACE AN ENTRY INTO THE DELETE LOG
				modAdminCommon.Record_Delete_Log_Entry("Transaction", YT_ID, inJourn_ID);

				// END THE TRANSACTION
				modAdminCommon.ADO_Transaction("CommitTrans");

				// RECORD AN EVENT TO DOCUMENT THE JOURNAL RECORD REMOVAL
				modAdminCommon.Record_Event("Journal", "Delete Transaction/Journal Record", YT_ID, inJourn_ID, 0);
				Cursor.Current = CursorHelper.CursorDefault;
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Delete_Yacht_Transaction ({Information.Err().Number.ToString()}) {excep.Message}", "modCommon (Transaction)");
			}

			return false;
		}

		internal static string Assign_Document_Directory(string inACID) => "";


		internal static string Get_Document_File_Name(int PassedACID, int PassedJournID, int PassedJournSeqNo, string PassedType, string PassedExtension)
		{

			try
			{

				// ************************************************************
				// IDENTIFY THE SUBDIRECTORY WHERE THE DOCUMENT IS BASE ON THE ACID
				StringBuilder DirName = new StringBuilder();

				switch(Strings.Len(PassedACID.ToString().Trim()))
				{
					case 1 : case 2 : case 3 :  // THE AIRCRAFT ID MUST BE LESS THAN 1000 SO JUST SET THE DIRECTORY 
						DirName = new StringBuilder("0-999"); 
						break;
					case 4 :  // AIRCRAFT ID MUST BE IN THE THOUSANDS 
						DirName = new StringBuilder(PassedACID.ToString().Trim().Substring(0, Math.Min(1, PassedACID.ToString().Trim().Length))); 
						int tempForEndVar = Strings.Len(PassedACID.ToString().Trim()) - 1; 
						for (int i = 1; i <= tempForEndVar; i++)
						{
							DirName.Append("0");
						} 
						DirName.Append($"-{PassedACID.ToString().Substring(0, Math.Min(1, PassedACID.ToString().Length))}999"); 
						break;
					case 5 :  // AIRCRAFT ID MUST BE IN THE TENS OF THOUSANDS 
						DirName = new StringBuilder(PassedACID.ToString().Trim().Substring(0, Math.Min(2, PassedACID.ToString().Trim().Length))); 
						int tempForEndVar2 = Strings.Len(PassedACID.ToString().Trim()) - 2; 
						for (int i = 1; i <= tempForEndVar2; i++)
						{
							DirName.Append("0");
						} 
						DirName.Append($"-{PassedACID.ToString().Trim().Substring(0, Math.Min(2, PassedACID.ToString().Trim().Length))}999"); 
						break;
					case 6 : 
						DirName = new StringBuilder(PassedACID.ToString().Trim().Substring(0, Math.Min(3, PassedACID.ToString().Trim().Length))); 
						int tempForEndVar3 = Strings.Len(PassedACID.ToString().Trim()) - 3; 
						for (int i = 1; i <= tempForEndVar3; i++)
						{
							DirName.Append("0");
						} 
						DirName.Append($"-{PassedACID.ToString().Trim().Substring(0, Math.Min(3, PassedACID.ToString().Trim().Length))}999"); 
						break;
					default: // RETURN A DIRECTORY NAME OF "0" IF THE NUMBER IS BIGGER THAN 5 
						DirName = new StringBuilder("0"); 
						break;
				}

				// *********************************************************
				// IDENTIFY THE LIBRARY MAIN DIRECTORY WHERE THE DOCUMENT IS
				// BASE ON THE TYPE OF FILE

				string DestinationPath = "";
				string DestinationFileName = "";
				string FullDestinationPathAndFile = "";



				switch(PassedType)
				{
					case "FAAPDF" : case "NTSB" : case "337" : 
						 
						// ASSIGN THE INITIAL FILE NAME BASED ON AC ID AND JOURN ID 
						DestinationFileName = $"{PassedACID.ToString()}-{PassedJournID.ToString()}"; 
						 
						// IF A SEQUENCE NUMBER IS PASSED THEN ADD THIS TO THE FILE NAME 
						// AS WELL 
						if (PassedJournSeqNo > 0)
						{
							DestinationFileName = $"{DestinationFileName}-{PassedJournSeqNo.ToString()}";
						} 
						 
						// ADD THE TYPE OF FILE AFTER THE NEW FILE NAME 
						DestinationFileName = $"{DestinationFileName}{PassedExtension}"; 

						 
						DestinationPath = $"{modAdminCommon.gbl_Documents}\\LIBRARY\\{DirName.ToString()}"; 
						//DestinationPath = "\\jetnet4\LIBRARY" & "\" & PassedType & "\" & DirName 
						 
						// CREATE THE FULL FILE NAME 
						return $"{DestinationPath}\\{DestinationFileName}"; 

					default:
						return "";
				}
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Record_Error($"Get_Document_File_Name_Error ({Information.Err().Number.ToString()}) {excep.Message}", "modCommon (Document)");
				return "";
			}
		}

		internal static int GetDoubleClickSpeed()
		{


			int iResults = 0;
			dynamic objShell = null;//Shell32.Shell objShell = new Shell32.Shell(); gap-note check during blazor stabilization
			//UPGRADE_WARNING: (1068) objShell.GetSystemInformation() of type Variant is being forced to Scalar. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
			object vReturn = objShell.GetSystemInformation("DoubleClickTime");
			//UPGRADE_WARNING: (1068) vReturn of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
			iResults = Convert.ToInt32(vReturn);
			objShell = null;

			return iResults;

		} // End Function GetDoubleClickSpeed


		internal static string Get_Journal_Date(int PassedJournID)
		{

			string result = "";
			try
			{
				string Query = "";
				ADORecordSetHelper snp_journ = null;
				result = "";

				Query = $"SELECT journ_date FROM Journal WITH(NOLOCK) WHERE journ_id = {PassedJournID.ToString()}";

				snp_journ = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(snp_journ.Fields) && !(snp_journ.BOF && snp_journ.EOF))
				{
					result = DateTime.Parse(Convert.ToString(snp_journ["journ_date"]).Trim()).ToString("d");
				}

				snp_journ.Close();
				snp_journ = null;

				return result;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Get_Journal_Date_Error ({Information.Err().Number.ToString()}) {excep.Message}", "modCommon (Journal)");

				return "";
			}
		}

		internal static string pf_PadString(int in_len, ref string in_data)
		{
			const string s_pad = " ";

			bool b_pad = false;
			string s_pad_str = ""; // build a string as wide as the in_len
			int n_data_len = 0;
			int n_pad_to = 0;

			// strip off all whitespace
			in_data = in_data.Trim();
			n_data_len = Strings.Len(in_data);

			if (in_data.Trim() == "")
			{
				return new string(s_pad[0], in_len);
			}

			// is data len = s_raw len - then no pad
			b_pad = n_data_len != in_len;

			if (b_pad)
			{ // find out how much we need to pad
				n_pad_to = in_len - n_data_len;
				if ((n_pad_to) < 0)
				{
					//truncate input data to size
					return in_data.Substring(Math.Min(0, in_data.Length), Math.Min(in_len, Math.Max(0, in_data.Length)));
				}
			}
			else
			{
				// no padding return the data
				return in_data;
			}

			s_pad_str = new string(s_pad[0], n_pad_to);

			return $"{in_data}{s_pad_str}";

		}


		internal static int DelaySeconds(int iDelaySec)
		{

			System.DateTime dtStartTime = DateTime.FromOADate(0);
			int iElapsedTime = 0;

			if (iDelaySec > 0 && iDelaySec < 3600)
			{ // Max 60 minutes

				dtStartTime = DateTime.Now;
				iElapsedTime = 0;

				do 
				{
					iElapsedTime = (int) DateAndTime.DateDiff("s", dtStartTime, DateTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
					Application.DoEvents();
					Application.DoEvents();
				}
				while(iElapsedTime < iDelaySec);

			} // If iDelaySec > 0 And iDelaySec < 3600 Then ' Max 60 minutes

			return iElapsedTime;

		} // End Function DelaySeconds

		internal static bool pf_ValidateDate(string strDate, bool bIgnoreToday)
		{

			bool result = false;
			bool bResults = false;
			System.DateTime dtInDate = DateTime.FromOADate(0);
			System.DateTime dtToDay = DateTime.FromOADate(0);

			try
			{

				bResults = false;

				// Input Parameter Can NOT be Blank
				if (strDate != "")
				{

					if (Information.IsDate(strDate))
					{

						System.DateTime TempDate2 = DateTime.FromOADate(0);
						dtInDate = DateTime.Parse((DateTime.TryParse(strDate, out TempDate2)) ? TempDate2.ToString("MM/dd/yyyy") : strDate);

						if (dtInDate.Year > 1960 && dtInDate.Year < 2100)
						{

							bResults = true;

							//-----------------------------------------------------
							// If Ignore=False strDate Cannot Be Less Than Today
							//----------------------------------------------------
							if (!bIgnoreToday)
							{
								dtToDay = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy"));
								if (dtInDate < dtToDay)
								{
									bResults = false;
								}
							} // If bIgnoreToday = True Then

						} // If Year(dtInDate) > 1980 And Year(dtInDate) < 2100 Then

					} // If IsDate(strDate) Then

				} // If strDate <> "" Then


				return bResults;
			}
			catch
			{

				result = false;
			}
			return result;
		} // pf_ValidateDate

		internal static bool pf_ValidateDate_Old(string in_str_date, bool bIgnoreToday)
		{


			bool result = false;
			string[] tmpDateArray = null;

			try
			{

				result = false;


				if (in_str_date != "")
				{ // no empty strings
					if (Information.IsDate(in_str_date))
					{ // vbDate check ( fails 5% of the time )

						tmpDateArray = Strings.Split(in_str_date, "/", -1, CompareMethod.Text);

						if (tmpDateArray.GetUpperBound(0) == 2)
						{ // should have three elememts (0) month (1) day (2) year
							if (Strings.Len(tmpDateArray[0]) > 0 && (Conversion.Val(tmpDateArray[0]) >= 1 && Conversion.Val(tmpDateArray[0]) <= 12))
							{ // month valid (between 1 and 12) check for day
								if (Strings.Len(tmpDateArray[1]) > 0 && (Conversion.Val(tmpDateArray[1]) >= 1 && Conversion.Val(tmpDateArray[1]) <= 31))
								{ // day valid (between 1 and 31) check for year
									if (Strings.Len(tmpDateArray[2]) > 0 && Strings.Len(tmpDateArray[2]) == 4 && (Conversion.Val(tmpDateArray[2]) > 1980 && Conversion.Val(tmpDateArray[2]) < 2100))
									{ // year valid valid date
										if (!bIgnoreToday)
										{
											if (DateTime.Parse(in_str_date) >= DateTime.Parse(DateTimeHelper.ToString(DateTime.Now)))
											{ // date cannot be earlier than right now
												return true;
											}
											else
											{
												return result;
											}
										}
										else
										{
											return true;
										}
									}
									else if (Strings.Len(tmpDateArray[2]) > 0 && Strings.Len(tmpDateArray[2]) == 2 && (DateTime.Parse($"01/01/{tmpDateArray[2]}").Year > 1980 && DateTime.Parse($"01/01/{tmpDateArray[2]}").Year < 2100))
									{  // 2 digit year between 1980 and 2050
										if (!bIgnoreToday)
										{
											if (DateTime.Parse(in_str_date) >= DateTime.Parse(DateTimeHelper.ToString(DateTime.Now)))
											{ // date cannot be earlier than right now
												return true;
											}
											else
											{
												return result;
											}
										}
										else
										{
											return true;
										}
									}
									else
									{
										return result;
									}

								}
								else
								{
									return result;
								}

							}
							else
							{
								return result;
							}

						}
						else
						{
							return result;
						}

					}
					else
					{
						return result;
					}

				}
				else
				{
					return result;
				}
			}
			catch
			{

				return result;
			}
		}

		internal static string pf_Proper_Case(string inText)
		{

			string result = "";

			string del = "";
			int tmp_length = 0;

			string[] my_array = inText.Split(' ');

			foreach (string my_array_item in my_array)
			{

				tmp_length = Strings.Len(my_array_item);

				result = $"{result}{del}{my_array_item.Substring(0, Math.Min(1, my_array_item.Length)).ToUpper()}{my_array_item.Substring(Math.Max(my_array_item.Length - (tmp_length - 1), 0)).ToLower()}";

				del = " ";

			}

			return result.Trim();

		}

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
			         $"({modAdminCommon.gbl_User_ID})-({modAdminCommon.gbl_Account_ID}) " +
			         $"{strMsg}";

			if (($"{Convert.ToString(modAdminCommon.snp_User["user_monitor_activity_flag"])} ").Trim() == "Y")
			{
				// HOLD RTW - CHANGES TO USER ACTION FROM MONITOR ACTIVITY ON 3/23/2021
				// NOTE THAT THE FOLLOWING TYPES ARE USED BY RESEARCH METRICS SO THEY ARE BEING KEPT IN ANOTHER CATEGORY CALLED USER ACTIONS

				if (strType == "Open Company" || strType == "Open Aircraft" || strType == "View Contact" || strType == "Open Contact" || strType == "Company Search" || strType == "Aircraft Search" || strType == "Save Aircraft")
				{ // added save aircraft
					modAdminCommon.Record_Event("Monitor Activity", strMsg, lACId, lJournId, lCompId, false, lYachtId, lContactId);
				}
				else
				{
					modAdminCommon.Record_Event("User Action", strMsg, lACId, lJournId, lCompId, false, lYachtId, lContactId);
				}
			}

		} // End_Activity_Monitor_Message

		internal static string LeaveOnlyNumeric(string strKey)
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
					if (Information.IsNumeric(strChar))
					{
						strTemp.Append(strChar);
					}
				}
				while(iPos1 < iLen1);

				strResults = strTemp.ToString();

			} // Len(strKey) > 0

			return strResults;

		} // LeaveOnlyNumeric

		internal static string LeaveOnlyAlpha(string strKey)
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
					if ((String.CompareOrdinal(strChar, "a") >= 0 && String.CompareOrdinal(strChar, "z") <= 0) || (String.CompareOrdinal(strChar, "A") >= 0 && String.CompareOrdinal(strChar, "Z") <= 0))
					{
						strTemp.Append(strChar);
					}
				}
				while(iPos1 < iLen1);

				strResults = strTemp.ToString();

			} // Len(strKey) > 0

			return strResults;

		} // LeaveOnlyAlpha

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

		internal static bool MakeSureDirectoryExists(string strDir)
		{

			Object fso = new Object();
			string[] aDir = null;
			string strDirTemp = "";

			strDir = ($"{strDir} ").Trim();
			bool bResults = false;

			if (strDir != "")
			{

				if (!Directory.Exists(strDir))
				{

					strDir = StringsHelper.Replace(strDir, "/", "\\", 1, -1, CompareMethod.Binary);
					aDir = strDir.Split('\\');
					strDirTemp = "";

					foreach (string aDir_item in aDir)
					{
						strDirTemp = $"{strDirTemp}{aDir_item}\\";
						if (strDirTemp != "\\" && strDirTemp != "\\\\")
						{
							if (!Directory.Exists(strDirTemp))
							{
								try
								{
									Directory.CreateDirectory(strDirTemp);
								}
								catch
								{
								}
							} // If fso.FolderExists(strDirTemp) = False Then
						}
					}

				} // If fso.FolderExists(strDir) = False Then

				if (Directory.Exists(strDir))
				{
					bResults = true;
				}

			}
			else
			{
				bResults = true;
			} // If strDir <> "" Then

			return bResults;

		} // MakeSureDirectoryExists

		internal static bool OpenCustomerSQLDatabase(ref DbConnection cntConn)
		{

			bool result = false;
			string strConn = "";
			bool bResults = false;

			string strServer = "";
			string strDatabase = "";
			string strUserName = "";
			string strPassword = "";

			try
			{

				strServer = DLookUp("aconfig_customer_program_server", "Application_Configuration");

				bResults = false;

				strDatabase = "customer";
				if (!modAdminCommon.gbl_Live_flag)
				{
					strDatabase = "customer_test";
				}
				strUserName = "sa";
				strPassword = "moejive";

				strConn = $"Provider=SQLNCLI10;Data Source={strServer};Initial Catalog={strDatabase};User Id={strUserName};Password={strPassword};";

				if (cntConn == null)
				{
					cntConn = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateConnection();
				}

				cntConn.ConnectionString = strConn;
				UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(cntConn, 180);
				//UPGRADE_ISSUE: (2064) ADODB.Connection property cntConn.ConnectionTimeout was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				cntConn.setConnectionTimeout(60);
				//UPGRADE_ISSUE: (2064) ADODB.Connection property cntConn.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				cntConn.setCursorLocation(CursorLocationEnum.adUseServer);
				//UPGRADE_TODO: (7010) The connection string must be verified to fullfill the .NET data provider connection string requirements. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-7010
				cntConn.Open();

				bResults = true;


				return bResults;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"OpenCustomerSQLDatabase_Error: {excep.Message}");

				result = false;
			}
			return result;
		} // OpenCustomerSQLDatabase


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

		} // ReadRegistryKeyString


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

				AddItemToLogFile($"Browser: {strBrowser}");
				AddItemToLogFile($"  !-[{strURL}]");

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
								// 12/10/2019 - By David D. Cruger; Commented out; This will open Chrome is full browser with url/address menus
								//strBrowserCmd = Replace(strBrowserCmd, " -- ", " --new-window --app=")
								strBrowserCmd = StringsHelper.Replace(strBrowserCmd, $"{"\""}%1{"\""}", strURL, 1, -1, CompareMethod.Binary);
							} 
							 
							break;
					} // Case strBrowser

					if (strBrowserCmd != "")
					{

						AddItemToLogFile($"strBrowserCmd: [{strBrowserCmd}]");


						//UPGRADE_TODO: (7005) parameters (if any) must be set using the Arguments property of ProcessStartInfo More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-7005
						ProcessStartInfo startInfo = new ProcessStartInfo(strBrowserCmd);
						startInfo.WindowStyle = ProcessWindowStyle.Normal;
						Process.Start(startInfo);

					}
					else
					{

						//--------------------------------------------
						// If Registry Entry Can NOT Be Found
						// Create IE Object

						AddItemToLogFile("Use Default Browser");
						AddItemToLogFile($"  !-[{strURL}]");

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

				AddItemToLogFile($"ShellOpenURLInBrowser_Error: {strErrDesc}");
				modAdminCommon.Report_Error($"ShellOpenURLInBrowser_Error: {strErrDesc}");
			}

		} // ShellOpenURLInBrowser

		internal static void CenterFormOnHomebaseMainForm(Form frmForm)
		{

			frmForm.Top = Convert.ToInt32(mdi_ResearchAssistant.DefInstance.Top + ((mdi_ResearchAssistant.DefInstance.Height - frmForm.Height) / 2d));
			frmForm.Left = Convert.ToInt32(mdi_ResearchAssistant.DefInstance.Left + ((mdi_ResearchAssistant.DefInstance.Width - frmForm.Width) / 2d));

		}


		internal static bool IsContactRelatedToAnotherContact(int lCompId, int lContactId)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			bool bResults = false;

			try
			{

				bResults = false;

				if (lCompId > 0 && lContactId > 0)
				{

					strQuery1 = "SELECT TOP 1 cr_id FROM Contact_Reference WITH (NOLOCK) WHERE (cr_journ_id = 0) ";
					strQuery1 = $"{strQuery1}AND ( ";
					strQuery1 = $"{strQuery1}      (cr_comp_id = {lCompId.ToString()} AND cr_contact_id = {lContactId.ToString()}) ";
					strQuery1 = $"{strQuery1}   OR (cr_comp_rel_id = {lCompId.ToString()} AND cr_contact_rel_id = {lContactId.ToString()}) ";
					strQuery1 = $"{strQuery1}    ) ";

					rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!rstRec1.BOF && !rstRec1.EOF)
					{
						bResults = true;
					}

					rstRec1.Close();

				} // If lCompId > 0 And lContactId > 0 Then

				rstRec1 = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"IsContactRelatedToAnotherContact_Error: {excep.Message}");
			}
			return false;
		} // IsContactRelatedToAnotherContact


		internal static bool DoesSameAddressRelatedCompanyExist(int lCompId, ref string comp_id_related)
		{

			bool result = false;
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			bool bResults = false;

			try
			{

				result = false;


				strQuery1 = "SELECT compref_comp_id, compref_rel_comp_id FROM Company_Reference WITH (NOLOCK)";
				strQuery1 = $"{strQuery1}WHERE (compref_journ_id = 0) and  compref_contact_type in ('81','82') ";
				strQuery1 = $"{strQuery1}AND (      (compref_comp_id = {lCompId.ToString()} ) ";
				strQuery1 = $"{strQuery1}   OR (compref_rel_comp_id = {lCompId.ToString()} ) ";
				strQuery1 = $"{strQuery1}    ) ";

				rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(rstRec1.BOF && rstRec1.EOF))
				{


					while(!rstRec1.EOF)
					{

						if (comp_id_related.Trim() != "")
						{
							comp_id_related = $"{comp_id_related}, ";
						}

						if (Convert.ToString(rstRec1["compref_comp_id"]).Trim() != lCompId.ToString().Trim())
						{
							comp_id_related = $"{comp_id_related}{Convert.ToString(rstRec1["compref_comp_id"])}";
						}
						else
						{
							comp_id_related = $"{comp_id_related}{Convert.ToString(rstRec1["compref_rel_comp_id"])}";
						}

						result = true;

						rstRec1.MoveNext();
					};
				}

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"DoesSameAddressRelatedCompanyExist_Error: {excep.Message}");
			}


			return result;
		} // IsContactRelatedToAnotherContact

		internal static string Return_String_Using_AlphaNumeric_DB_Function(string temp_string)
		{

			string result = "";
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			bool bResults = false;

			try
			{

				result = temp_string;

				strQuery1 = $" select dbo.LeaveAlphaAndNumeric('{temp_string}') as tfield ";

				rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(rstRec1.BOF && rstRec1.EOF))
				{


					while(!rstRec1.EOF)
					{

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["tfield"]))
						{
							result = Convert.ToString(rstRec1["tfield"]);
						}

						rstRec1.MoveNext();
					};
				}

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"Return_String_Using_AlphaNumeric_DB_Function_Error: {excep.Message}");
			}


			return result;
		} // IsContactRelatedToAnotherContact



		internal static bool DoesSameAddressExist(int lCompId, ref string comp_id_related, ref int count_of_same, ref string related_company_string)
		{

			bool result = false;
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			bool bResults = false;

			try
			{

				result = false;

				// NEED TO FIX --- TESTING WHAT WILL HAPPEN
				strQuery1 = " select distinct c1.comp_id, c1.comp_name from company c1 with (NOLOCK)";
				strQuery1 = $"{strQuery1} inner join company c2 with (NOLOCK) on c2.comp_id = {lCompId.ToString()} and c2.comp_journ_id = c1.comp_journ_id  ";
				strQuery1 = $"{strQuery1} and c1.comp_address1 = c2.comp_address1 ";
				// strQuery1 = strQuery1 & " and c1.comp_address2 = c2.comp_address2 and c1.comp_city = c2.comp_city"
				strQuery1 = $"{strQuery1} where c1.comp_journ_id = 0 and c1.comp_id <> c2.comp_id ";

				rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(rstRec1.BOF && rstRec1.EOF))
				{


					while(!rstRec1.EOF)
					{

						if (comp_id_related.Trim() != "")
						{
							comp_id_related = $"{comp_id_related}, ";
							related_company_string = $"{related_company_string}{Environment.NewLine}";
						}

						comp_id_related = $"{comp_id_related}{Convert.ToString(rstRec1["comp_id"])}";
						count_of_same++;

						related_company_string = $"{related_company_string}{Convert.ToString(rstRec1["comp_name"])}";


						result = true;

						rstRec1.MoveNext();
					};
				}

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"DoesSameAddressExist_Error: {excep.Message}");
			}


			return result;
		} // IsContactRelatedToAnotherContact
		internal static string Find_Historical_Company_AC_Records(int lCompId, int journ_id, string where_current_clause, ref int journ_count)
		{

			string result = "";
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			bool bResults = false;

			try
			{


				strQuery1 = "SELECT comp_journ_id from company with (NOLOCK) ";
				strQuery1 = $"{strQuery1} where comp_id = {lCompId.ToString()}   and  comp_journ_id > {journ_id.ToString()}";
				strQuery1 = $"{strQuery1}{where_current_clause}";

				rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(rstRec1.BOF && rstRec1.EOF))
				{


					while(!rstRec1.EOF)
					{

						result = $"{result},{Convert.ToString(rstRec1["comp_journ_id"])}";
						journ_count++;

						rstRec1.MoveNext();
					};
				}

				rstRec1.Close();

				strQuery1 = $"SELECT  top 1 * from company with (NOLOCK)  where comp_id = {lCompId.ToString()}  ";
				strQuery1 = $"{strQuery1} and comp_journ_id = 0 {where_current_clause}"; // make sure that field is blank

				rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(rstRec1.BOF && rstRec1.EOF))
				{


					while(!rstRec1.EOF)
					{

						result = $"0{result}";
						journ_count++;

						rstRec1.MoveNext();
					};
				}
				else
				{
					// then the current one isnt blank so we cant update it

					result = "Your Current Company Record Has Fields Filled In. Please Clear in Order to Push the Data.";
					journ_count++; // this means the current one is bad, but should still count
				}

				rstRec1.Close();


				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"DoesSameAddressRelatedCompanyExist_Error: {excep.Message}");
			}


			return result;
		} // IsContactRelatedToAnotherContact



		internal static void AddItemToLogFile(string strText)
		{
			StreamWriter tsFileWriter = null;



			//--------------------------------------------
			// Add Date/Time Stamp and Listener Name

			string strDT = $"{DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")} - {modAdminCommon.gbl_User_ID.ToUpper()} - Homebase - "; // Date/Time

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


		internal static bool OpenCRMDatabase(ref DbConnection cntConn)
		{

			bool result = false;
			int lErrNbr = 0;
			string strErrDesc = "";
			string strConn = "";
			string[] astrConn = null;
			int lTot1 = 0;
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

				cntConn = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateConnection();

				strConn = DLookUp("aconfig_crm_server", "Application_Configuration");

				if (strConn.Trim().IndexOf("ODBC 5.1") >= 0)
				{
					strConn = StringsHelper.Replace(strConn.Trim(), "ODBC 5.1", "ODBC 3.51", 1, -1, CompareMethod.Binary);
				}

				astrConn = strConn.Split(';');
				lTot1 = astrConn.GetUpperBound(0) - 1;
				int tempForEndVar = lTot1;
				for (int lCnt1 = 0; lCnt1 <= tempForEndVar; lCnt1++)
				{
					Debug.WriteLine(astrConn[lCnt1]);
				}

				//-----------------------------------------
				// Open Connection To MySQL-CRM Database

				if (strConn != "")
				{
					cntConn.ConnectionString = strConn;
					//UPGRADE_ISSUE: (2064) ADODB.Connection property cntConn.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					cntConn.setCursorLocation(CursorLocationEnum.adUseServer);
					UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(cntConn, 120);
					//UPGRADE_TODO: (7010) The connection string must be verified to fullfill the .NET data provider connection string requirements. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-7010
					cntConn.Open();
					bResults = true;
				}


				return bResults;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr = Information.Err().Number;
				strErrDesc = excep.Message;

				modAdminCommon.Report_Error($"OpenCRMDatabase_Error: {strErrDesc}");

				MessageBox.Show($"{Environment.NewLine}{strErrDesc}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);

				result = false;
			}
			return result;
		} // OpenCRMDatabase

		internal static void CloseCRMDatabase(ref DbConnection cntConn)
		{


			if (cntConn != null)
			{
				if (cntConn.State == ConnectionState.Open)
				{
					DbConnection cntConnTmp = cntConn;
					ErrorHandlingHelper.ResumeNext(
						() => {UpgradeHelpers.DB.TransactionManager.DeEnlist(cntConnTmp);}, 
						() => {cntConnTmp.Close();});
					cntConn = cntConnTmp;
				}
			}

			cntConn = null;

		} // CloseCRMDatabase

		internal static bool Open_Cloud_Notes_Database_Connection(ref DbConnection cntConn, ref string strErrMsg)
		{

			bool result = false;
			bool bResults = false;
			string strCNSQLServer = "";
			string strCNSQLUser = "";
			string strCNSQLPassword = "";
			string strConn = "";

			try
			{

				bResults = false;
				strErrMsg = "";

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

				strCNSQLServer = DLookUp("aconfig_cloud_notes_sql_server", "Application_Configuration");
				strCNSQLUser = DLookUp("aconfig_cloud_notes_sql_user", "Application_Configuration");
				strCNSQLPassword = DLookUp("aconfig_cloud_notes_sql_password", "Application_Configuration");

				strConn = $"Provider=SQLOLEDB;Data Source={strCNSQLServer};Initial Catalog=jetnet_ra_cloud_notes;UID={strCNSQLUser};PWD={strCNSQLPassword};";
				cntConn.ConnectionString = strConn;
				//UPGRADE_ISSUE: (2064) ADODB.Connection property cntConn.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				cntConn.setCursorLocation(CursorLocationEnum.adUseServer);
				UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(cntConn, 120);
				//UPGRADE_ISSUE: (2064) ADODB.Connection property cntConn.ConnectionTimeout was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				cntConn.setConnectionTimeout(60);

				//UPGRADE_TODO: (7010) The connection string must be verified to fullfill the .NET data provider connection string requirements. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-7010
				cntConn.Open();
				bResults = true;


				return bResults;
			}
			catch (System.Exception excep)
			{

				strErrMsg = excep.Message;
				result = false;
			}
			return result;
		} // Open_Cloud_Notes_Database_Connection


		internal static bool Open_CRM_Server_Side_Notes_Database_Connection(ref DbConnection cntConn, int lCRegId, ref string strErrMsg)
		{

			bool result = false;
			DbConnection cntCRMCentral = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateConnection();
			string strConn = "";

			int lCompId = 0;
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
			bool bResults = false;

			try
			{

				bResults = false;
				strErrMsg = "";

				if (lCRegId > 0)
				{

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

					if (OpenCRMDatabase(ref cntCRMCentral))
					{

						ReturnCRMMasterClientInfo(cntCRMCentral, lCRegId, ref lCompId, ref strClientName, ref strSubscriptionCode, ref strSecurityToken, ref strWebHostName, ref strDBHost, ref strDatabase, ref strUserId, ref strPassword);

						if (lCRegId > 0 && lCompId > 0)
						{

							if (strDBHost != "")
							{

								if (strDatabase != "")
								{

									if (strUserId != "")
									{

										if (strPassword != "")
										{

											if (strDBHost == "localhost")
											{
												strDBHost = "jetnetcrm2.jetnet.com";
											}

											strConn = "Driver={MySQL ODBC 3.51 Driver};";
											// strConn = "Driver={MySQL ODBC 5.1 Driver};"

											if (strDBHost.IndexOf("156") >= 0)
											{
												strConn = $"{strConn}Server=172.30.5.35;"; // hard coded MSW - 6/1/22
											}
											else
											{
												strConn = $"{strConn}Server={strDBHost};";
											}



											strConn = $"{strConn}Port=3306;Database={strDatabase};";
											strConn = $"{strConn}Uid={strUserId};Pwd={strPassword};OPTION=3;";

											cntConn.ConnectionString = strConn;
											//UPGRADE_ISSUE: (2064) ADODB.Connection property cntConn.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
											cntConn.setCursorLocation(CursorLocationEnum.adUseClient);
											UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(cntConn, 120);
											//UPGRADE_ISSUE: (2064) ADODB.Connection property cntConn.ConnectionTimeout was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
											cntConn.setConnectionTimeout(60);

											//UPGRADE_TODO: (7010) The connection string must be verified to fullfill the .NET data provider connection string requirements. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-7010
											cntConn.Open();

											bResults = true;

										}
										else
										{
											strErrMsg = "CRM Master Client - client_dbPWD Is Blank";
										} // If strPASSWORD <> "" Then

									}
									else
									{
										strErrMsg = "CRM Master Client - client_dbUID Is Blank";
									} // If strUserId <> "" Then

								}
								else
								{
									strErrMsg = "CRM Master Client - client_dbDatabase Is Blank";
								} // If strDatabase <> "" Then

							}
							else
							{
								strErrMsg = "CRM Master Client - client_dbHost_External Is Blank";
							} // If strDBHost <> "" Then

						}
						else
						{
							strErrMsg = $"Unable To Find Registered Master Record For CRegId {lCRegId.ToString()}";
						} // If (lCRegId > 0 And lCompId > 0) Then

						CloseCRMDatabase(ref cntCRMCentral);

					} // If OpenCRMDatabase(cntCRMCentral) = True Then

				}
				else
				{
					strErrMsg = "CRegId Is Invalid";
				} // If lCRegID > 0 Then

				cntCRMCentral = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				strErrMsg = excep.Message;
				result = false;
			}
			return result;
		} // Open_CRM_Server_Side_Notes_Database_Connection

		internal static void CloseCRMServerSideNotesDatabase(ref DbConnection cntConn)
		{


			if (cntConn != null)
			{
				if (cntConn.State == ConnectionState.Open)
				{
					DbConnection cntConnTmp = cntConn;
					ErrorHandlingHelper.ResumeNext(
						() => {UpgradeHelpers.DB.TransactionManager.DeEnlist(cntConnTmp);}, 
						() => {cntConnTmp.Close();});
					cntConn = cntConnTmp;
				}
			}

			cntConn = null;

		} // CloseCRMServerSideNotesDatabase


		internal static void Close_Cloud_Notes_Database_Connection(DbConnection cntConn, ref string strErrMsg)
		{

			string strCNSQLServer = "";
			string strCNSQLUser = "";
			string strCNSQLPassword = "";

			try
			{

				strErrMsg = "";

				if (cntConn != null)
				{
					if (cntConn.State == ConnectionState.Open)
					{
						UpgradeHelpers.DB.TransactionManager.DeEnlist(cntConn);
						cntConn.Close();
					}
				}
			}
			catch (System.Exception excep)
			{

				strErrMsg = excep.Message;
			}

		} // Close_Cloud_Notes_Database_Connection


		internal static bool Does_Company_Cloud_Notes_Table_Exist(DbConnection cntConn, int lCompId, ref string strErrMsg)
		{

			bool result = false;
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strTable = "";
			bool bResults = false;

			try
			{

				bResults = false;
				strErrMsg = "";

				strTable = $"cloud_notes_{lCompId.ToString()}";

				strQuery1 = "SELECT TABLE_NAME  FROM INFORMATION_SCHEMA.TABLES ";
				strQuery1 = $"{strQuery1}WHERE (TABLE_TYPE = 'BASE TABLE')  ORDER BY TABLE_NAME ";

				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					do 
					{

						if (strTable == ($"{Convert.ToString(rstRec1["TABLE_NAME"])} ").Trim().ToLower())
						{
							bResults = true;
						}

						rstRec1.MoveNext();

					}
					while(!(rstRec1.EOF || bResults));

				} // If (rstRec1.BOF = False And rstRec1.EOF = False) Then

				rstRec1.Close();
				rstRec1 = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				strErrMsg = excep.Message;
				result = false;
			}
			return result;
		} // Does_Company_Cloud_Notes_Table_Exist

		internal static int Return_Aircraft_Model_id(int lACId, int lJournId)
		{

			int result = 0;
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			int lResults = 0;

			try
			{

				lResults = 0;

				strQuery1 = "SELECT TOP 1 ac_amod_id FROM Aircraft WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (ac_id = {lACId.ToString()}) ";
				strQuery1 = $"{strQuery1}AND (ac_journ_id = {lJournId.ToString()} OR ac_journ_id = 0) ";
				strQuery1 = $"{strQuery1}ORDER BY ac_journ_id DESC ";

				if (lACId > 0)
				{

					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!rstRec1.BOF && !rstRec1.EOF)
					{
						lResults = Convert.ToInt32(rstRec1["ac_amod_id"]);
					}

					rstRec1.Close();

				} // If lACId > 0 Then

				rstRec1 = null;


				return lResults;
			}
			catch
			{

				result = 0;
			}
			return result;
		} // Return_Aircraft_Model_id(ByVal lACId) As Long

		internal static string Browse_Folders(string strTitle)
		{

			string sBuffer = "";
			JetNetSupport.PInvoke.UnsafeNative.Structures.BrowseInfo tBrowseInfo = new JetNetSupport.PInvoke.UnsafeNative.Structures.BrowseInfo();

			string strResults = "";
			string szTitle = strTitle;

			tBrowseInfo.hwndOwner = frm_Main_Menu.DefInstance.Handle.ToInt32();
			string tempRefParam = "";
			tBrowseInfo.lpszTitle = JetNetSupport.PInvoke.SafeNative.kernel32.lstrcat(ref szTitle, ref tempRefParam);
			tBrowseInfo.ulFlags = BIF_RETURNONLYFSDIRS + BIF_DONTGOBELOWDOMAIN;

			int lpIDList = JetNetSupport.PInvoke.SafeNative.shell32.SHBrowseForFolder(ref tBrowseInfo);

			if (lpIDList != 0)
			{
				sBuffer = new String(' ', MAX_PATH);
				JetNetSupport.PInvoke.SafeNative.shell32.SHGetPathFromIDList(lpIDList, ref sBuffer);
				sBuffer = sBuffer.Substring(0, Math.Min(sBuffer.IndexOf("\0"), sBuffer.Length));
				strResults = sBuffer;
			}

			return strResults;

		}

		internal static string ReturnContactName(string strSal, string strFName, string strMName, string strLName, string strSuffix)
		{


			string strResults = "";

			strSal = strSal.Trim();
			strFName = strFName.Trim();
			strMName = strMName.Trim();
			strLName = strLName.Trim();
			strSuffix = strSuffix.Trim();

			if (strSal != "")
			{
				strResults = $"{strResults}{strSal} ";
			}
			if (strFName != "")
			{
				strResults = $"{strResults}{strFName} ";
			}
			if (strMName != "")
			{
				strResults = $"{strResults}{strMName}. ";
			}
			if (strLName != "")
			{
				strResults = $"{strResults}{strLName}";
			}
			if (strSuffix != "")
			{
				strResults = $"{strResults}, {strSuffix}";
			}

			return strResults;

		} // ReturnContactName

		internal static void PlusMinusDateField(TextBox txtText, ref int iKeyCode)
		{


			string strDate = txtText.Text.Trim();
			System.DateTime dtDate = DateTime.FromOADate(0);

			if (iKeyCode == Strings.Asc('+') || iKeyCode == Strings.Asc('=') || iKeyCode == 43 || iKeyCode == 61 || iKeyCode == 107 || iKeyCode == 187)
			{
				if (Information.IsDate(strDate))
				{
					dtDate = DateTime.Parse(strDate);
					dtDate = dtDate.AddDays(1);
					strDate = dtDate.ToString("MM/dd/yyyy");
					txtText.Text = strDate;
					iKeyCode = 0;
				}
			}
			else if (iKeyCode == Strings.Asc('-') || iKeyCode == 45 || iKeyCode == 95 || iKeyCode == 109 || iKeyCode == 189)
			{ 
				if (Information.IsDate(strDate))
				{
					dtDate = DateTime.Parse(strDate);
					dtDate = dtDate.AddDays(-1);
					strDate = dtDate.ToString("MM/dd/yyyy");
					txtText.Text = strDate;
					iKeyCode = 0;
				}
			}
			else if (iKeyCode == Strings.Asc(' ') || iKeyCode == 32)
			{ 
				if (strDate == "")
				{
					strDate = DateTime.Now.ToString("MM/dd/yyyy");
				}
				else
				{
					strDate = "";
				}
				txtText.Text = strDate;
				iKeyCode = 0;
			} // Case iKeyCode

		} // PlusMinusDateField

		// ====================================================================
		// Written By : David D. Cruger
		// Created    : 03/16/2012
		// Modified   : 05/07/2014
		// Notes      : Uses the TechId as the Random number generator seed.
		// Then loops through and creates an 8 char password.  1st char is
		// always alpha.  No 'o','l' as they look to much like '1' and '0'.
		// 05/07/2014 - By David D. Cruger; Changed the Randomized statement
		// the old one was repeating passwords.
		// 05/15/2014 - By David D. Cruger; Again changed the Randomize to use
		// part of a QUID.  Use numeric only then if 1st char is even grab the
		// starting 8 numebers, if the 1st char is odd grab the last 8 numbers
		// ====================================================================

		internal static string GeneratePassword(int lTechId)
		{

			int lTmp1 = 0; // Temp Long
			string strTmp1 = ""; // Temp String


			string strResults = ""; // The Result Password // Clear The Password

			string strGUID = GetGUID();
			strGUID = LeaveOnlyNumeric(strGUID);
			string str1st = strGUID.Substring(0, Math.Min(1, strGUID.Length));

			if (Convert.ToInt32(Double.Parse(str1st)) / 2d == Convert.ToInt32(Double.Parse(str1st)) / 2)
			{
				strGUID = strGUID.Substring(0, Math.Min(8, strGUID.Length));
			}
			else
			{
				strGUID = strGUID.Substring(Math.Max(strGUID.Length - 8, 0));
			}

			VBMath.Randomize(Convert.ToInt32(Double.Parse(strGUID)));

			int iCnt1 = 0; // Loop Counter; Only try 5 times

			do 
			{ // Loop Until (iCnt1 >= 5)

				iCnt1++; // Increament Counter

				strTmp1 = "?"; // Set To Unknown
				do 
				{ // Loop Until strTmp1 <> "?"

					lTmp1 = Convert.ToInt32((25 * VBMath.Rnd()) + 97); // Should Generate (0--25)+97=(97--122) or a--z
					if ((String.CompareOrdinal(Strings.Chr(lTmp1).ToString(), "a") >= 0) && (String.CompareOrdinal(Strings.Chr(lTmp1).ToString(), "z") <= 0))
					{ // Make Sure It's between a and z lower case

						// Do NOT Use o or l they look to much like 0 and 1
						if ((Strings.Chr(lTmp1).ToString() != "o") && (Strings.Chr(lTmp1).ToString() != "l"))
						{
							strTmp1 = Strings.Chr(lTmp1).ToString(); // Found A Value Char
						} // No o or l

					} // If (Asc(lTmp1) >= "a") And (Asc(lTmp1) <= "z") Then

				}
				while(strTmp1 == "?");

				strResults = strTmp1; // First Char of the Password must be Alpha

				do 
				{ // Loop Until Len(strResults) >= 8

					strTmp1 = "?"; // Set to Unknown
					lTmp1 = (Convert.ToInt32(1 * VBMath.Rnd())); // 0=Alpha, 1=Numeric

					if ((lTmp1 != 0) && (lTmp1 != 1))
					{
						lTmp1 = 1;
					} // Default Numeric

					switch(lTmp1)
					{
						case 0 :  // Alpha 
							 
							lTmp1 = Convert.ToInt32((25 * VBMath.Rnd()) + 97);  // Should Generate (0--25)+97=(97--122) or a--z 
							if ((String.CompareOrdinal(Strings.Chr(lTmp1).ToString(), "a") >= 0) && (String.CompareOrdinal(Strings.Chr(lTmp1).ToString(), "z") <= 0))
							{ // Make Sure It's between a and z lower case

								// Do NOT Use o or l they look to much like 0 and 1
								if ((Strings.Chr(lTmp1).ToString() != "o") && (Strings.Chr(lTmp1).ToString() != "l"))
								{
									strTmp1 = Strings.Chr(lTmp1).ToString();
								} // No o or l

							}  // If (Chr(lTmp1) >= "a") And (Chr(lTmp1) <= "z") Then 
							 
							break;
						case 1 :  // Numeric 
							 
							lTmp1 = Convert.ToInt32((9 * VBMath.Rnd()) + 48);  // Should Generate (0--9)+48=(48--57) or 0--9 
							if ((String.CompareOrdinal(Strings.Chr(lTmp1).ToString(), "0") >= 0) && (String.CompareOrdinal(Strings.Chr(lTmp1).ToString(), "9") <= 0))
							{ // Make Sure It's between 0 and 9

								// Do NOT Use 0 or 1 they look to much like o and l
								if ((Strings.Chr(lTmp1).ToString() != "0") && (Strings.Chr(lTmp1).ToString() != "1"))
								{
									strTmp1 = Strings.Chr(lTmp1).ToString();
								} // No 0 or 1

							}  // If (Chr(lTmp1) >= "0") And (Chr(lTmp1) <= "9") Then 
							 
							break;
					} // Select Case lTmp1

					if (strTmp1 != "?")
					{
						strResults = $"{strResults}{strTmp1}"; // Build PassWord
					}

				}
				while(Strings.Len(strResults) < 8);

			}
			while(!(iCnt1 >= 5));

			return strResults;

		} // GeneratePassword


		internal static string GenerateNewPassword(int lTechId)
		{

			const string strSpecial = "!#$()[]/\\|{}";

			int lTmp1 = 0; // Temp Long
			string strTmp1 = ""; // Temp String
			bool bFirstChar = false;
			bool bSpecialChar = false;


			string strResults = ""; // The Result Password // Clear The Password
			int lLen = Strings.Len(strSpecial) - 1;

			string strGUID = GetGUID();
			strGUID = LeaveOnlyNumeric(strGUID);
			string str1st = strGUID.Substring(0, Math.Min(1, strGUID.Length));

			if (Convert.ToInt32(Double.Parse(str1st)) / 2d == Convert.ToInt32(Double.Parse(str1st)) / 2)
			{
				strGUID = strGUID.Substring(0, Math.Min(8, strGUID.Length));
			}
			else
			{
				strGUID = strGUID.Substring(Math.Max(strGUID.Length - 8, 0));
			}

			VBMath.Randomize(Convert.ToInt32(Double.Parse(strGUID)));

			int iCnt1 = 0; // Loop Counter; Only try 5 times

			do 
			{ // Loop Until (iCnt1 >= 5)

				iCnt1++; // Increament Counter

				strTmp1 = "?"; // Set To Unknown
				do 
				{ // Loop Until strTmp1 <> "?"

					lTmp1 = Convert.ToInt32((25 * VBMath.Rnd()) + 97); // Should Generate (0--25)+97=(97--122) or a--z
					if ((String.CompareOrdinal(Strings.Chr(lTmp1).ToString(), "a") >= 0) && (String.CompareOrdinal(Strings.Chr(lTmp1).ToString(), "z") <= 0))
					{ // Make Sure It's between a and z lower case

						// Do NOT Use o or l they look to much like 0 and 1
						if ((Strings.Chr(lTmp1).ToString() != "o") && (Strings.Chr(lTmp1).ToString() != "l"))
						{
							strTmp1 = Strings.Chr(lTmp1).ToString(); // Found A Value Char
						} // No o or l

					} // If (Asc(lTmp1) >= "a") And (Asc(lTmp1) <= "z") Then

				}
				while(strTmp1 == "?");

				strResults = strTmp1; // First Char of the Password must be Alpha

				bFirstChar = true;
				bSpecialChar = false; // Has Special Char Been Set Yet

				do 
				{ // Loop Until Len(strResults) >= 8

					strTmp1 = "?"; // Set to Unknown
					if (bSpecialChar)
					{
						lTmp1 = (Convert.ToInt32(1 * VBMath.Rnd())); // 0=Alpha, 1=Numeric
					}
					else
					{
						lTmp1 = (Convert.ToInt32(2 * VBMath.Rnd())); // 0=Alpha, 1=Numeric, 2=Special Char
					}

					if ((lTmp1 < 0) || (lTmp1 > 2))
					{
						lTmp1 = 1;
					} // Default Numeric


					switch(lTmp1)
					{
						case 0 :  // Alpha 
							 
							lTmp1 = Convert.ToInt32((25 * VBMath.Rnd()) + 97);  // Should Generate (0--25)+97=(97--122) or a--z 
							if ((String.CompareOrdinal(Strings.Chr(lTmp1).ToString(), "a") >= 0) && (String.CompareOrdinal(Strings.Chr(lTmp1).ToString(), "z") <= 0))
							{ // Make Sure It's between a and z lower case

								// Do NOT Use o or l they look to much like 0 and 1
								if ((Strings.Chr(lTmp1).ToString() != "o") && (Strings.Chr(lTmp1).ToString() != "l"))
								{
									strTmp1 = Strings.Chr(lTmp1).ToString();

									// If This Is The Next First Char (After the leading one) Then Make It UpCase
									if (bFirstChar)
									{
										strTmp1 = strTmp1.ToUpper();
										bFirstChar = false;
									}

								} // No o or l

							}  // If (Chr(lTmp1) >= "a") And (Chr(lTmp1) <= "z") Then 
							 
							break;
						case 1 :  // Numeric 
							 
							lTmp1 = Convert.ToInt32((9 * VBMath.Rnd()) + 48);  // Should Generate (0--9)+48=(48--57) or 0--9 
							if ((String.CompareOrdinal(Strings.Chr(lTmp1).ToString(), "0") >= 0) && (String.CompareOrdinal(Strings.Chr(lTmp1).ToString(), "9") <= 0))
							{ // Make Sure It's between 0 and 9

								// Do NOT Use 0 or 1 they look to much like o and l
								if ((Strings.Chr(lTmp1).ToString() != "0") && (Strings.Chr(lTmp1).ToString() != "1"))
								{
									strTmp1 = Strings.Chr(lTmp1).ToString();
								} // No 0 or 1

							}  // If (Chr(lTmp1) >= "0") And (Chr(lTmp1) <= "9") Then 
							 
							break;
						case 2 :  // Special Char 
							 
							lTmp1 = Convert.ToInt32((lLen * VBMath.Rnd()) + 1); 
							strTmp1 = strSpecial.Substring(Math.Min(lTmp1 - 1, strSpecial.Length), Math.Min(1, Math.Max(0, strSpecial.Length - (lTmp1 - 1)))); 
							bSpecialChar = true; 
							 
							break;
					} // Select Case lTmp1

					if (strTmp1 != "?")
					{
						strResults = $"{strResults}{strTmp1}"; // Build PassWord
					}

				}
				while(Strings.Len(strResults) < 8);

				if (!bSpecialChar)
				{
					lTmp1 = Convert.ToInt32((lLen * VBMath.Rnd()) + 1);
					strTmp1 = strSpecial.Substring(Math.Min(lTmp1 - 1, strSpecial.Length), Math.Min(1, Math.Max(0, strSpecial.Length - (lTmp1 - 1))));
					strResults = $"{strResults.Substring(0, Math.Min(7, strResults.Length))}{strTmp1}";
				}

			}
			while(!(iCnt1 >= 5));

			return strResults;

		} // GenerateNewPassword


		internal static string ReturnUsersHTMLSignature()
		{

			string result = "";
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			int lContactId = 0;
			string strContact = "";
			string strTitle = "";
			string strEMail = "";

			string strOfficeNbr = "";
			string strOfficeExt = "";
			string str800Nbr = "";
			string strFaxNbr = "";

			string strContactOfficeNbr = "";
			string strContactFaxNbr = "";
			string strContactCellNbr = "";

			string strBody = "";
			string strLinks = "";
			string strAddress = "";
			string strResults = "";

			try
			{

				strResults = "";
				strBody = "";

				lContactId = 0;
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(modAdminCommon.snp_User["user_contact_id"]))
				{
					lContactId = Convert.ToInt32(modAdminCommon.snp_User["user_contact_id"]);
				}

				//-----------------------------------------
				// Use Generic [User] Table Contact Name

				strContact = $"{($"{Convert.ToString(modAdminCommon.snp_User["user_first_name"])} ").Trim()} {($"{Convert.ToString(modAdminCommon.snp_User["user_last_name"])} ").Trim()}";
				strTitle = "";
				strEMail = ($"{Convert.ToString(modAdminCommon.snp_User["user_email_address"])} ").Trim();
				strOfficeExt = ($"{Convert.ToString(modAdminCommon.snp_User["user_phone_no_ext"])} ").Trim();
				if (strOfficeExt != "")
				{
					strOfficeExt = $"X{strOfficeExt}";
				}

				strOfficeNbr = DLookUp("pnum_number_full", "Phone_Numbers", "(pnum_contact_id = 0 AND pnum_comp_id = 135887 AND pnum_type = 'Office')");
				str800Nbr = DLookUp("pnum_number_full", "Phone_Numbers", "(pnum_contact_id = 0 AND pnum_comp_id = 135887 AND pnum_type = 'Toll Free')");
				strFaxNbr = DLookUp("pnum_number_full", "Phone_Numbers", "(pnum_contact_id = 0 AND pnum_comp_id = 135887 AND pnum_type = 'Fax')");

				strOfficeNbr = StringsHelper.Replace(strOfficeNbr, "-", ".", 1, -1, CompareMethod.Binary);
				str800Nbr = StringsHelper.Replace(str800Nbr, "-", ".", 1, -1, CompareMethod.Binary);
				strFaxNbr = StringsHelper.Replace(strFaxNbr, "-", ".", 1, -1, CompareMethod.Binary);

				strContactOfficeNbr = "";
				strContactFaxNbr = "";
				strContactCellNbr = "";

				if (lContactId > 0)
				{

					strQuery1 = "SELECT contact_id, contact_comp_id, contact_active_flag, ";
					strQuery1 = $"{strQuery1}dbo.CreateContactFullNameTitle('', contact_first_name, contact_middle_initial, contact_last_name, contact_suffix, '') As Contact,";
					strQuery1 = $"{strQuery1}contact_sirname, contact_first_name, contact_middle_initial, contact_last_name, contact_suffix, contact_title, ";
					strQuery1 = $"{strQuery1}contact_email_address ";
					strQuery1 = $"{strQuery1}FROM Contact WITH (NOLOCK) WHERE (contact_id = {lContactId.ToString()}) ";
					strQuery1 = $"{strQuery1}AND (contact_comp_id = 135887)  AND (contact_journ_id = 0) ";

					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						strContact = ($"{Convert.ToString(rstRec1["CONTACT"])} ").Trim();
						strTitle = ($"{Convert.ToString(rstRec1["contact_title"])} ").Trim();
						strEMail = ($"{Convert.ToString(rstRec1["contact_email_address"])} ").Trim();

						strContactOfficeNbr = DLookUp("pnum_number_full", "Phone_Numbers", $"(pnum_contact_id = {lContactId.ToString()} AND pnum_comp_id = 135887 AND pnum_type = 'Office')");
						strContactFaxNbr = DLookUp("pnum_number_full", "Phone_Numbers", $"(pnum_contact_id = {lContactId.ToString()} AND pnum_comp_id = 135887 AND pnum_type = 'Fax')");
						strContactCellNbr = DLookUp("pnum_number_full", "Phone_Numbers", $"(pnum_contact_id = {lContactId.ToString()} AND pnum_comp_id = 135887 AND pnum_type = 'Mobile')");

						strContactOfficeNbr = StringsHelper.Replace(strContactOfficeNbr, "-", ".", 1, -1, CompareMethod.Binary);
						strContactFaxNbr = StringsHelper.Replace(strContactFaxNbr, "-", ".", 1, -1, CompareMethod.Binary);
						strContactCellNbr = StringsHelper.Replace(strContactCellNbr, "-", ".", 1, -1, CompareMethod.Binary);

					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

				} // If lContactId > 0 Then

				strBody = $"<p>{Environment.NewLine}";
				strBody = $"{strBody}<b>{Environment.NewLine}";
				strBody = $"{strBody}<span style='font-family:Arial;color:#616E7D;font-size:12.0pt'>{Environment.NewLine}";
				strBody = $"{strBody}{strContact}{Environment.NewLine}";
				strBody = $"{strBody}</span>{Environment.NewLine}";
				strBody = $"{strBody}</b>{Environment.NewLine}";

				strBody = $"{strBody}<span style='font-family:Arial;color:#616E7D;font-size:10.0pt'>{Environment.NewLine}";
				strBody = $"{strBody}&nbsp;>>{strTitle}{Environment.NewLine}";
				strBody = $"{strBody}<br/><br/>{Environment.NewLine}</span>{Environment.NewLine}";

				strBody = $"{strBody}<b>{Environment.NewLine}";
				strBody = $"{strBody}<span style='font-family:Arial;color:#616E7D;font-size:12.0pt'>{Environment.NewLine}";
				strBody = $"{strBody}<a href='http://www.jetnet.com'>jetnet.com</a>{Environment.NewLine}";
				strBody = $"{strBody}<br/>{Environment.NewLine}";
				strBody = $"{strBody}</span>{Environment.NewLine}</b>{Environment.NewLine}";

				strBody = $"{strBody}<span style='font-family:Arial;color:black;font-size:10.0pt'>{Environment.NewLine}";

				if (($"{Convert.ToString(modAdminCommon.snp_User["user_first_name"])} ").Trim() == "Karim")
				{
					strBody = $"{strBody}{strContactOfficeNbr} Zurich<br/>{Environment.NewLine}";
					strBody = $"{strBody}{strOfficeNbr} x845 New York<br/>{Environment.NewLine}";
				}
				else
				{
					strBody = $"{strBody}{str800Nbr}<br/>{Environment.NewLine}";
					strBody = $"{strBody}{strOfficeNbr}<br/>{Environment.NewLine}";
				}

				strBody = $"{strBody}</span>{Environment.NewLine}";

				strBody = $"{strBody}<span style='font-family:Arial;color:#8D9AB1;font-size:10.0pt'>{Environment.NewLine}";
				strBody = $"{strBody}Worldwide leader in aviation market intelligence.{Environment.NewLine}";
				strBody = $"{strBody}</span>{Environment.NewLine}</p>{Environment.NewLine}";

				strResults = strBody;

				rstRec1 = null;


				return strResults;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("ReturnUsersHTMLSignature_Error: ", excep.Message);

				result = "";
			}
			return result;
		} // ReturnUsersHTMLSignature



		internal static string ReturnUsersTextSignature()
		{

			string result = "";
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			int lContactId = 0;
			string strContact = "";
			string strTitle = "";
			string strEMail = "";

			string strOfficeNbr = "";
			string strOfficeExt = "";
			string str800Nbr = "";
			string strFaxNbr = "";

			string strContactOfficeNbr = "";
			string strContactFaxNbr = "";
			string strContactCellNbr = "";

			string strBody = "";
			string strLinks = "";
			string strAddress = "";
			string strResults = "";

			try
			{

				strResults = "";
				strBody = "";

				lContactId = 0;
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(modAdminCommon.snp_User["user_contact_id"]))
				{
					lContactId = Convert.ToInt32(modAdminCommon.snp_User["user_contact_id"]);
				}

				//-----------------------------------------
				// Use Generic [User] Table Contact Name

				strContact = $"{($"{Convert.ToString(modAdminCommon.snp_User["user_first_name"])} ").Trim()} {($"{Convert.ToString(modAdminCommon.snp_User["user_last_name"])} ").Trim()}";
				strTitle = "";
				strEMail = ($"{Convert.ToString(modAdminCommon.snp_User["user_email_address"])} ").Trim();
				strOfficeExt = ($"{Convert.ToString(modAdminCommon.snp_User["user_phone_no_ext"])} ").Trim();
				if (strOfficeExt != "")
				{
					strOfficeExt = $"X{strOfficeExt}";
				}

				strOfficeNbr = DLookUp("pnum_number_full", "Phone_Numbers", "(pnum_contact_id = 0 AND pnum_comp_id = 135887 AND pnum_type = 'Office')");
				str800Nbr = DLookUp("pnum_number_full", "Phone_Numbers", "(pnum_contact_id = 0 AND pnum_comp_id = 135887 AND pnum_type = 'Toll Free')");
				strFaxNbr = DLookUp("pnum_number_full", "Phone_Numbers", "(pnum_contact_id = 0 AND pnum_comp_id = 135887 AND pnum_type = 'Fax')");

				strOfficeNbr = StringsHelper.Replace(strOfficeNbr, "-", ".", 1, -1, CompareMethod.Binary);
				str800Nbr = StringsHelper.Replace(str800Nbr, "-", ".", 1, -1, CompareMethod.Binary);
				strFaxNbr = StringsHelper.Replace(strFaxNbr, "-", ".", 1, -1, CompareMethod.Binary);

				strContactOfficeNbr = "";
				strContactFaxNbr = "";
				strContactCellNbr = "";

				if (lContactId > 0)
				{

					strQuery1 = "SELECT contact_id, contact_comp_id, contact_active_flag, ";
					strQuery1 = $"{strQuery1}dbo.CreateContactFullNameTitle('', contact_first_name, contact_middle_initial, contact_last_name, contact_suffix, '') As Contact,";
					strQuery1 = $"{strQuery1}contact_sirname, contact_first_name, contact_middle_initial, contact_last_name, contact_suffix, contact_title, ";
					strQuery1 = $"{strQuery1}contact_email_address ";
					strQuery1 = $"{strQuery1}FROM Contact WITH (NOLOCK) WHERE (contact_id = {lContactId.ToString()}) ";
					strQuery1 = $"{strQuery1}AND (contact_comp_id = 135887) AND (contact_journ_id = 0) ";

					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						strContact = ($"{Convert.ToString(rstRec1["CONTACT"])} ").Trim();
						strTitle = ($"{Convert.ToString(rstRec1["contact_title"])} ").Trim();
						strEMail = ($"{Convert.ToString(rstRec1["contact_email_address"])} ").Trim();

						strContactOfficeNbr = DLookUp("pnum_number_full", "Phone_Numbers", $"(pnum_contact_id = {lContactId.ToString()} AND pnum_comp_id = 135887 AND pnum_type = 'Office')");
						strContactFaxNbr = DLookUp("pnum_number_full", "Phone_Numbers", $"(pnum_contact_id = {lContactId.ToString()} AND pnum_comp_id = 135887 AND pnum_type = 'Fax')");
						strContactCellNbr = DLookUp("pnum_number_full", "Phone_Numbers", $"(pnum_contact_id = {lContactId.ToString()} AND pnum_comp_id = 135887 AND pnum_type = 'Mobile')");

						strContactOfficeNbr = StringsHelper.Replace(strContactOfficeNbr, "-", ".", 1, -1, CompareMethod.Binary);
						strContactFaxNbr = StringsHelper.Replace(strContactFaxNbr, "-", ".", 1, -1, CompareMethod.Binary);
						strContactCellNbr = StringsHelper.Replace(strContactCellNbr, "-", ".", 1, -1, CompareMethod.Binary);

					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

				} // If lContactId > 0 Then

				strBody = "";
				strBody = $"{strBody}{strContact} >> {strTitle}{Environment.NewLine}{Environment.NewLine}";
				strBody = $"{strBody}jetnet.com{Environment.NewLine}";

				if (($"{Convert.ToString(modAdminCommon.snp_User["user_first_name"])} ").Trim() == "Karim")
				{
					strBody = $"{strBody}{strContactOfficeNbr}{Environment.NewLine}";
				}
				else
				{
					strBody = $"{strBody}{str800Nbr}{Environment.NewLine}";
				}
				strBody = $"{strBody}{strOfficeNbr}{Environment.NewLine}";

				strBody = $"{strBody}Worldwide leader in aviation market intelligence.{Environment.NewLine}";

				strResults = strBody;

				rstRec1 = null;


				return strResults;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("ReturnUsersTextSignature_Error: ", excep.Message);

				result = "";
			}
			return result;
		} // ReturnUsersTextSignature

		internal static void GetMousePosXY(ref int xPos, ref int yPos)
		{

			JetNetSupport.PInvoke.UnsafeNative.Structures.POINTAPI pAPI = new JetNetSupport.PInvoke.UnsafeNative.Structures.POINTAPI();

			int lReturn = JetNetSupport.PInvoke.SafeNative.user32.GetCursorPos(ref pAPI);
			xPos = pAPI.xPos;
			yPos = pAPI.yPos;

		} // GetMousePosXY

		internal static void Clear_Monitor_Cursor_Movement()
		{

			mcmUser.UserId = modAdminCommon.gbl_User_ID;
			GetMousePosXY(ref mcmUser.xPos, ref mcmUser.yPos);
			mcmUser.lElapsedTime = 0;
			mcmUser.dtDateTime = DateTime.Now;
			mcmUser.bCursorPaused = false; // mcmUser

		} // Clear_Monitor_Cursor_Movement

		internal static void Monitor_Users_Cursor_Movement()
		{

			int xPos = 0;
			int yPos = 0;
			int lETime = 0;

			GetMousePosXY(ref xPos, ref yPos);


			if (xPos == mcmUser.xPos && yPos == mcmUser.yPos)
			{
				// No Mouse Movement
				mcmUser.bCursorPaused = true;
			}
			else
			{

				// Mouse Had Been Paused
				if (mcmUser.bCursorPaused)
				{
					mcmUser.lElapsedTime = (int) DateAndTime.DateDiff("s", mcmUser.dtDateTime, DateTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
					Log_Monitor_Users_Cursor_Movement();
				}

				// Now Reset
				mcmUser.xPos = xPos;
				mcmUser.yPos = yPos;
				mcmUser.bCursorPaused = false;
				mcmUser.dtDateTime = DateTime.Now;

			} // If xPos = .xPos And yPos = .yPos Then
			 // mcmUser

		} // Monitor_Users_Cursor_Movement

		internal static void Log_Monitor_Users_Cursor_Movement()
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strTotalCount = "";
			string strTotalElapsedTime = "";
			double dAvgElapsedTime = 0;
			string strAvgElapsedTime = "";


			if (mdi_ResearchAssistant.DefInstance.MouseTimer.Enabled)
			{

				mdi_ResearchAssistant.DefInstance.MouseTimer.Enabled = false;

				strQuery1 = "SELECT * FROM Monitor_User_Cursor_Movement WHERE (mucm_id = -1) ";

				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);
				rstRec1.AddNew();

				rstRec1["mucm_user_id"] = mcmUser.UserId;
				rstRec1["mucm_elapsedtime"] = mcmUser.lElapsedTime;

				rstRec1.UpdateBatch();
				rstRec1.Close();

				mdi_ResearchAssistant.DefInstance.MouseTimer.Enabled = true;

			} // If mdi_ResearchAssistant.MouseTimer.Enabled = True Then
			 // mcmUser


		} // Log_Monitor_Users_Cursor_Movement


		internal static string CleanUpCellNumber(string strCellNbr)
		{


			string strResults = "";

			if (strCellNbr != "")
			{

				strCellNbr = StringsHelper.Replace(strCellNbr, "+1", "", 1, -1, CompareMethod.Binary);
				strCellNbr = StringsHelper.Replace(strCellNbr, "+", "", 1, -1, CompareMethod.Binary);
				strCellNbr = StringsHelper.Replace(strCellNbr, ",", "", 1, -1, CompareMethod.Binary);
				strCellNbr = StringsHelper.Replace(strCellNbr, ".", "", 1, -1, CompareMethod.Binary);
				strCellNbr = StringsHelper.Replace(strCellNbr, "-", "", 1, -1, CompareMethod.Binary);
				strCellNbr = StringsHelper.Replace(strCellNbr, "(", "", 1, -1, CompareMethod.Binary);
				strCellNbr = StringsHelper.Replace(strCellNbr, ")", "", 1, -1, CompareMethod.Binary);
				strCellNbr = StringsHelper.Replace(strCellNbr, " ", "", 1, -1, CompareMethod.Binary);
				if (strCellNbr.StartsWith("1", StringComparison.Ordinal))
				{
					strCellNbr = strCellNbr.Substring(Math.Min(1, strCellNbr.Length));
				} // Remove 1

				strResults = strCellNbr;

			} // If strCellNbr <> "" Then

			return strResults;

		} // CleanUpCellNumber



		internal static bool Does_Contact_Have_An_Active_Subscription(int lContactId, ref int lSubId, ref int lParentId, bool frontegg, ref string login_name)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			bool bResults = false;

			if (lContactId > 0)
			{

				strQuery1 = "SELECT TOP 1 sub_id, subins_contact_id, sub_parent_sub_id, sublogin_login ";
				strQuery1 = $"{strQuery1}FROM Subscription WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}INNER JOIN Subscription_Login WITH (NOLOCK) ON sublogin_sub_id = sub_id ";
				strQuery1 = $"{strQuery1}INNER JOIN Subscription_Install WITH (NOLOCK) ON subins_sub_id = sublogin_sub_id AND subins_login = sublogin_login ";
				strQuery1 = $"{strQuery1}WHERE (sub_start_date <= GETDATE())  AND (sub_end_date > GETDATE() OR sub_end_date IS NULL) ";
				strQuery1 = $"{strQuery1}AND (sublogin_active_flag = 'Y') AND (subins_active_flag = 'Y') ";
				strQuery1 = $"{strQuery1}AND (subins_contact_id  = {lContactId.ToString()}) ";

				if (lSubId > 0)
				{
					strQuery1 = $"{strQuery1} and sub_id = {lSubId.ToString()} ";
				}

				if (frontegg)
				{
					strQuery1 = $"{strQuery1} and sub_frontegg_flag = '1' ";
				}

				strQuery1 = $"{strQuery1}ORDER BY sub_id ";

				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(rstRec1["sub_id"]))
					{
						lSubId = Convert.ToInt32(rstRec1["sub_id"]);
					}
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(rstRec1["sub_parent_sub_id"]))
					{
						lParentId = Convert.ToInt32(rstRec1["sub_parent_sub_id"]);
					}
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(rstRec1["sublogin_login"]))
					{
						login_name = Convert.ToString(rstRec1["sublogin_login"]);
					}
					bResults = true;
				}

				rstRec1.Close();

			} // If lContactId > 0 Then

			rstRec1 = null;

			return bResults;

		}

		internal static bool Does_Contact_Have_An_Active_Subscription(int lContactId, ref int lSubId, ref int lParentId, bool frontegg)
		{
			string tempRefParam4 = "";
			return Does_Contact_Have_An_Active_Subscription(lContactId, ref lSubId, ref lParentId, frontegg, ref tempRefParam4);
		}

		internal static bool Does_Contact_Have_An_Active_Subscription(int lContactId, ref int lSubId, ref int lParentId)
		{
			string tempRefParam5 = "";
			return Does_Contact_Have_An_Active_Subscription(lContactId, ref lSubId, ref lParentId, false, ref tempRefParam5);
		} // Does_Contact_Have_An_Active_Subscription

        internal static void UpdateLogin_Fields(int temp_contact_id, int temp_sub_id, string login_name, bool is_frontegg)
        {

            StringBuilder Query = new StringBuilder();
            string temp_title = "";
            string sQuery = "";
            int nRecCount = 0;
            int nCounter = 0;
            ADORecordSetHelper ado_ContactType = new ADORecordSetHelper();
            bool is_frontegg_blank = false;

            if (temp_contact_id > 0 && temp_sub_id > 0 && login_name.Trim() != "")
            {

                Query = new StringBuilder("UPDATE Subscription_Login  SET  ");
                Query.Append(" sublogin_action_date = NULL,  "); // clear the action date - MSW - 11/3/24

                sQuery = "SELECT * ";
                sQuery = $"{sQuery}, (SELECT TOP 1 CASE WHEN M.PNUM_NUMBER_FULL IS NOT NULL THEN CASE WHEN M.PNUM_EXT IS NULL THEN M.PNUM_NUMBER_FULL ELSE M.PNUM_NUMBER_FULL+' EXT:'+M.PNUM_EXT END ELSE CASE WHEN O.PNUM_NUMBER_FULL IS NOT NULL THEN CASE WHEN O.PNUM_EXT IS NULL THEN O.PNUM_NUMBER_FULL ELSE O.PNUM_NUMBER_FULL+' EXT:'+O.PNUM_EXT END ELSE CASE WHEN C.PNUM_NUMBER_FULL IS NOT NULL THEN CASE WHEN C.PNUM_EXT IS NULL THEN C.PNUM_NUMBER_FULL ELSE C.PNUM_NUMBER_FULL+' EXT:'+C.PNUM_EXT END ELSE''END END END FROM CONTACT A WITH (NOLOCK) LEFT OUTER JOIN PHONE_NUMBERS M ON M.PNUM_TYPE='MOBILE'AND A.CONTACT_ID=M.PNUM_CONTACT_ID AND M.PNUM_JOURN_ID=0 LEFT OUTER JOIN PHONE_NUMBERS O ON O.PNUM_TYPE='OFFICE'AND A.CONTACT_ID=O.PNUM_CONTACT_ID AND O.PNUM_JOURN_ID=0 LEFT OUTER JOIN PHONE_NUMBERS C ON C.PNUM_TYPE='OFFICE' AND A.CONTACT_COMP_ID=C.PNUM_COMP_ID AND C.PNUM_JOURN_ID=0 WHERE A.CONTACT_ID=CONTACT.CONTACT_ID AND A.CONTACT_JOURN_ID=0) AS 'CONTACTBESTPHONE' ";
                sQuery = $"{sQuery} FROM Contact WITH(NOLOCK) ";
                sQuery = $"{sQuery} inner join company with (NOLOCK) on comp_id = contact_comp_id and comp_journ_id = contact_journ_id ";
                sQuery = $"{sQuery} where contact_id = {temp_contact_id.ToString()} and contact_journ_id = 0 ";


                //UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
                modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseClient);

                ado_ContactType.Open(sQuery, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

                if (!(ado_ContactType.BOF && ado_ContactType.EOF))
                {



                    while(!ado_ContactType.EOF)
                    {

                        //UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
                        if (!Convert.IsDBNull(ado_ContactType["contact_title"]))
                        {
                            Query.Append($"  sublogin_title = '{StringsHelper.Replace(Convert.ToString(ado_ContactType["contact_title"]), "'", "''", 1, -1, CompareMethod.Binary)}', ");
                        }

                        //UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
                        if (!Convert.IsDBNull(ado_ContactType["contact_first_name"]))
                        {
                            Query.Append($"  sublogin_first_name = '{StringsHelper.Replace(Convert.ToString(ado_ContactType["contact_first_name"]), "'", "''", 1, -1, CompareMethod.Binary)}', ");
                        }

                        //UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
                        if (!Convert.IsDBNull(ado_ContactType["contact_last_name"]))
                        {
                            Query.Append($"  sublogin_last_name = '{StringsHelper.Replace(Convert.ToString(ado_ContactType["contact_last_name"]), "'", "''", 1, -1, CompareMethod.Binary)}', ");
                        }

                        //UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
                        if (!Convert.IsDBNull(ado_ContactType["comp_address1"]))
                        {
                            Query.Append($"  sublogin_address = '{StringsHelper.Replace(Convert.ToString(ado_ContactType["comp_address1"]), "'", "''", 1, -1, CompareMethod.Binary)}', ");
                        }

                        //UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
                        if (!Convert.IsDBNull(ado_ContactType["comp_city"]))
                        {
                            Query.Append($"  sublogin_city = '{StringsHelper.Replace(Convert.ToString(ado_ContactType["comp_city"]), "'", "''", 1, -1, CompareMethod.Binary)}', ");
                        }

                        //UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
                        if (!Convert.IsDBNull(ado_ContactType["comp_state"]))
                        {
                            Query.Append($"  sublogin_state = '{StringsHelper.Replace(Convert.ToString(ado_ContactType["comp_state"]), "'", "''", 1, -1, CompareMethod.Binary)}', ");
                        }

                        //UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
                        if (!Convert.IsDBNull(ado_ContactType["comp_zip_code"]))
                        {
                            Query.Append($"  sublogin_postal_code = '{StringsHelper.Replace(Convert.ToString(ado_ContactType["comp_zip_code"]), "'", "''", 1, -1, CompareMethod.Binary)}', ");
                        }

                        //UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
                        if (!Convert.IsDBNull(ado_ContactType["comp_country"]))
                        {
                            Query.Append($"  sublogin_country = '{StringsHelper.Replace(Convert.ToString(ado_ContactType["comp_country"]), "'", "''", 1, -1, CompareMethod.Binary)}', ");
                        }
                        //
                        //UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
                        if (!Convert.IsDBNull(ado_ContactType["CONTACTBESTPHONE"]))
                        {
                            Query.Append($"  sublogin_phone = '{StringsHelper.Replace(Convert.ToString(ado_ContactType["CONTACTBESTPHONE"]), "'", "''", 1, -1, CompareMethod.Binary)}', ");
                        }


                        //
                        //              If Not IsNull(ado_ContactType("contact_title")) Then
                        //                Query = Query & "  sublogin_phone_additional = '" & ado_ContactType("contact_title") & "', "
                        //              End If

                        //UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
                        if (!Convert.IsDBNull(ado_ContactType["contact_email_address"]))
                        {
                            Query.Append($"  sublogin_email = '{StringsHelper.Replace(Convert.ToString(ado_ContactType["contact_email_address"]), "'", "''", 1, -1, CompareMethod.Binary)}' ");
                        }

                        ado_ContactType.MoveNext();

                    };

                }

                //UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
                modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseServer);

                ado_ContactType.Close();

                // if it is frontegg, make sure its an add and those fields r blank

                is_frontegg_blank = true;

                if (is_frontegg)
                {
                    sQuery = "SELECT *  FROM Subscription_Login WITH(NOLOCK) ";
                    sQuery = $"{sQuery} WHERE (sublogin_sub_id = {temp_sub_id.ToString()})";
                    sQuery = $"{sQuery} AND sublogin_login = '{login_name}'";

                    //UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
                    modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseClient);

                    ado_ContactType.Open(sQuery, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

                    if (!(ado_ContactType.BOF && ado_ContactType.EOF))
                    {

                        while(!ado_ContactType.EOF)
                        {

                            //UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
                            if (!Convert.IsDBNull(ado_ContactType["sublogin_first_name"]))
                            {
                                is_frontegg_blank = false;
                            }

                            //UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
                            if (!Convert.IsDBNull(ado_ContactType["sublogin_email"]))
                            {
                                is_frontegg_blank = false;
                            }

                            ado_ContactType.MoveNext();
                        };

                    }
                    ado_ContactType.Close();

                }

                ado_ContactType = null;


                if (is_frontegg_blank)
                {

                    Query.Append($" WHERE (sublogin_sub_id = {temp_sub_id.ToString()})");
                    Query.Append($" AND sublogin_login = '{login_name}'");

                    DbCommand TempCommand = null;
                    TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
                    UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
                    TempCommand.CommandText = Query.ToString();
                    //UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
                    TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
                    UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
                    TempCommand.ExecuteNonQuery(); //aey 6/21/04

                    Query = new StringBuilder($"UPDATE Subscription  SET sub_action_date = NULL WHERE (sub_id = {temp_sub_id.ToString()})");
                    DbCommand TempCommand_2 = null;
                    TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
                    UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
                    TempCommand_2.CommandText = Query.ToString();
                    //UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
                    //UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
                    TempCommand_2.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
                    UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
                    TempCommand_2.ExecuteNonQuery(); //aey 6/21/04
                }

            }

        }
        internal static bool Does_Company_Have_An_Active_Subscription(int lCompId, ref int lSubId, ref int lParentId)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			bool bResults = false;
			lSubId = 0;
			lParentId = 0;

			if (lCompId > 0)
			{

				strQuery1 = "SELECT TOP 1 sub_id, sub_comp_id, sub_parent_sub_id FROM Subscription WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}INNER JOIN Subscription_Login WITH (NOLOCK) ON sublogin_sub_id = sub_id ";
				strQuery1 = $"{strQuery1}INNER JOIN Subscription_Install WITH (NOLOCK) ON subins_sub_id = sublogin_sub_id AND subins_login = sublogin_login ";
				strQuery1 = $"{strQuery1}WHERE (sub_start_date <= GETDATE())  AND (sub_end_date > GETDATE() OR sub_end_date IS NULL) ";
				strQuery1 = $"{strQuery1}AND (sub_comp_id = {lCompId.ToString()}) ";
				strQuery1 = $"{strQuery1}AND (sublogin_active_flag = 'Y') ";
				strQuery1 = $"{strQuery1}AND (subins_active_flag = 'Y')  ORDER BY sub_id ";

				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(rstRec1["sub_id"]))
					{
						lSubId = Convert.ToInt32(rstRec1["sub_id"]);
					}
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(rstRec1["sub_parent_sub_id"]))
					{
						lParentId = Convert.ToInt32(rstRec1["sub_parent_sub_id"]);
					}
					bResults = true;
				}

				rstRec1.Close();

			} // If lCompId > 0 Then

			rstRec1 = null;

			return bResults;

		} // Does_Company_Have_An_Active_Subscription

		internal static string ReturnYesNo(string strChar)
		{


			string strResults = "";
			strChar = strChar.Trim();

			if (strChar != "")
			{

				strChar = strChar.Substring(0, Math.Min(1, strChar.Length)).ToUpper();

				switch(strChar)
				{
					case "N" : 
						strResults = "No"; 
						break;
					case "Y" : 
						strResults = "Yes"; 
						break;
					case "U" : 
						strResults = "Ukn"; 
						break;
				} // Case strChar

			}

			return strResults;

		} // ReturnYesNo

		internal static string ReturnCheckBoxYesNo(CheckBox chkBox)
		{


			string strResults = "";
			if (chkBox.CheckState == CheckState.Unchecked)
			{
				strResults = "No";
			}
			if (chkBox.CheckState == CheckState.Checked)
			{
				strResults = "Yes";
			}

			return strResults;

		} // ReturnCheckBoxYesNo

		internal static string ReturnCheckBoxValueYesNo(CheckState iValue)
		{


			string strResults = "";
			if (iValue == CheckState.Unchecked)
			{
				strResults = "No";
			}
			if (iValue == CheckState.Checked)
			{
				strResults = "Yes";
			}

			return strResults;

		} // ReturnCheckBoxValueYesNo

		internal static bool Hide_UnHide_Company_Relationship(int lCompRefKey, ref string strHideFlag)
		{

			bool result = false;
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strUpdate1 = "";

			int lComp1 = 0;
			int lComp2 = 0;
			int lChg1 = 0;

			bool bResults = false;
			bool bTrans = false;
			string strErrDesc = "";

			try
			{

				bResults = false;
				strHideFlag = "";

				if (lCompRefKey > 0)
				{

					bTrans = false;
					lComp1 = 0;
					lComp2 = 0;

					strQuery1 = "SELECT * FROM Company_Reference WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1}WHERE (compref_key = {lCompRefKey.ToString()}) ";

					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						bTrans = true;
						modAdminCommon.ADO_Transaction("BeginTrans");

						strHideFlag = ($"{Convert.ToString(rstRec1["compref_hide_flag"])} ").Trim();
						lComp1 = Convert.ToInt32(rstRec1["compref_comp_id"]);
						lComp2 = Convert.ToInt32(rstRec1["compref_rel_comp_id"]);

						if (strHideFlag == "Y")
						{
							strHideFlag = "N";
						}
						else
						{
							strHideFlag = "Y";
						}

						// Update Hide Flag
						strUpdate1 = $"UPDATE Company_Reference SET compref_hide_flag = '{strHideFlag}' ";
						strUpdate1 = $"{strUpdate1}WHERE (compref_key = {lCompRefKey.ToString()}) ";
						DbCommand TempCommand = null;
						TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
						TempCommand.CommandText = strUpdate1;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
						lChg1 = TempCommand.ExecuteNonQuery();

						// Clear Company Action Dates
						strUpdate1 = "UPDATE Company SET comp_action_date = '1/1/1900' ";
						strUpdate1 = $"{strUpdate1}WHERE (comp_id = {lComp1.ToString()} OR comp_id = {lComp2.ToString()}) ";
						strUpdate1 = $"{strUpdate1}AND (comp_journ_id = 0) ";

						DbCommand TempCommand_2 = null;
						TempCommand_2 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
						TempCommand_2.CommandText = strUpdate1;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand_2.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
						lChg1 = TempCommand_2.ExecuteNonQuery();

						modAdminCommon.ADO_Transaction("CommitTrans");
						bTrans = false;

						bResults = true;

					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

				} // If lCompRefKey > 0 Then

				rstRec1 = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				strErrDesc = excep.Message;
				if (bTrans)
				{
					modAdminCommon.ADO_Transaction("RollbackTrans");
				}

				modAdminCommon.Record_Error("Hide_UnHide_Company_Relationship_Error: ", strErrDesc);

				result = false;
			}
			return result;
		} // Hide_UnHide_Company_Relationship

		internal static string Return_JNiQ_Eligible_Query(string strAcctRep, string start_Query = "")
		{



			string strQuery1 = "AND (C1.comp_product_business_flag = 'Y') ";

			// Must Have A Jet, TurboProp, ExcAir
			strQuery1 = $"{strQuery1}AND (EXISTS (SELECT NULL FROM Aircraft_Reference AS AR2 WITH (NOLOCK) ";
			strQuery1 = $"{strQuery1}             INNER JOIN Aircraft AS A2 WITH (NOLOCK) ON A2.ac_id = AR2.cref_ac_id AND A2.ac_journ_id = AR2.cref_journ_id ";
			strQuery1 = $"{strQuery1}             INNER JOIN Aircraft_Model AS AM2 WITH (NOLOCK) ON AM2.amod_id = A2.ac_amod_id ";
			strQuery1 = $"{strQuery1}             WHERE (AR2.cref_comp_id = C1.comp_id) ";
			strQuery1 = $"{strQuery1}             AND (AR2.cref_journ_id = C1.comp_journ_id) ";
			strQuery1 = $"{strQuery1}             AND (AR2.cref_primary_poc_flag IN ('X','Y')) ";
			strQuery1 = $"{strQuery1}             AND (AM2.amod_airframe_type_code = 'F') ";
			strQuery1 = $"{strQuery1}             AND (AM2.amod_customer_flag = 'Y') ";
			strQuery1 = $"{strQuery1}             AND (AM2.amod_type_code IN ('J','T','E')) ";
			strQuery1 = $"{strQuery1}             AND (AM2.amod_product_business_flag = 'Y') ";
			strQuery1 = $"{strQuery1}             AND (A2.ac_product_business_flag = 'Y') ";

			if (strAcctRep == "DB" || strAcctRep == "ACAX" || strAcctRep == "DEX1" || strAcctRep == "DEX2" || strAcctRep == "DEX3")
			{
				strQuery1 = $"{strQuery1}   AND (AM2.amod_airframe_type_code = 'F') ";
			}

			strQuery1 = $"{strQuery1}             ) ";
			strQuery1 = $"{strQuery1}    ) ";

			if (strAcctRep == "DB" || strAcctRep == "ACAX" || strAcctRep == "DEX1" || strAcctRep == "DEX2")
			{

			}
			else
			{
				// if the query comes in and doesnt have am1. then it shouldnt be included
				if (start_Query.Trim() != "")
				{
					if (start_Query.IndexOf("AM1.") >= 0)
					{
						strQuery1 = $"{strQuery1}   AND (AM1.amod_airframe_type_code = 'F') ";
					}
				}
				else
				{
					strQuery1 = $"{strQuery1}   AND (AM1.amod_airframe_type_code = 'F') ";
				}
			}



			// 03/11/2015 - By David D. Cruger
			// Added Per Jackie


			if (strAcctRep.StartsWith("DB", StringComparison.Ordinal))
			{
				strQuery1 = $"{strQuery1}AND (EXISTS (SELECT NULL FROM Business_Type_Reference AS BTR2 WITH (NOLOCK)";
				strQuery1 = $"{strQuery1}             WHERE (BTR2.bustypref_comp_id = C1.comp_id) ";
				strQuery1 = $"{strQuery1}             AND (BTR2.bustypref_journ_id = C1.comp_journ_id) ";
				strQuery1 = $"{strQuery1}             AND (BTR2.bustypref_type IN ('CH','MC')) ";
				strQuery1 = $"{strQuery1}            ) ";
				strQuery1 = $"{strQuery1}    ) ";
			} // If Left(strAcctRep,2) = "DB" Then

			return strQuery1;

		} // Return_JNiQ_Eligible_Query

		internal static string Return_Non_JNiQ_Eligible_Query()
		{



			string strQuery1 = "AND (EXISTS (SELECT NULL FROM Aircraft_Reference AS AR2 WITH (NOLOCK) ";
			strQuery1 = $"{strQuery1}             INNER JOIN Aircraft AS A2 WITH (NOLOCK) ON A2.ac_id = AR2.cref_ac_id AND A2.ac_journ_id = AR2.cref_journ_id ";
			strQuery1 = $"{strQuery1}             INNER JOIN Aircraft_Model AS AM2 WITH (NOLOCK) ON AM2.amod_id = A2.ac_amod_id ";
			strQuery1 = $"{strQuery1}             WHERE (AR2.cref_comp_id = C1.comp_id) ";
			strQuery1 = $"{strQuery1}             AND (AR2.cref_journ_id = C1.comp_journ_id) ";
			strQuery1 = $"{strQuery1}             AND (AR2.cref_primary_poc_flag IN ('X','Y')) ";
			strQuery1 = $"{strQuery1}             AND (";
			strQuery1 = $"{strQuery1}                      (AM2.amod_airframe_type_code = 'F' AND AM2.amod_type_code = 'P' AND A2.ac_product_business_flag = 'Y') ";
			strQuery1 = $"{strQuery1}                   OR (AM2.amod_airframe_type_code = 'F' AND A2.ac_product_commercial_flag = 'Y') ";
			strQuery1 = $"{strQuery1}                   OR (AM2.amod_airframe_type_code = 'R' AND A2.ac_product_helicopter_flag = 'Y') ";
			strQuery1 = $"{strQuery1}                   OR (AM2.amod_airframe_type_code = 'F' ";
			strQuery1 = $"{strQuery1}                       AND AM2.amod_type_code IN ('J','T','E')";
			strQuery1 = $"{strQuery1}                       AND AM2.amod_product_business_flag = 'Y'";
			strQuery1 = $"{strQuery1}                       AND (NOT EXISTS (SELECT NULL FROM Business_Type_Reference AS BTR2 WITH (NOLOCK) ";
			strQuery1 = $"{strQuery1}                                        WHERE (BTR2.bustypref_comp_id = C1.comp_id) ";
			strQuery1 = $"{strQuery1}                                        AND (BTR2.bustypref_journ_id = C1.comp_journ_id) ";
			strQuery1 = $"{strQuery1}                                        AND (BTR2.bustypref_type IN ('CH','MC')) ";
			strQuery1 = $"{strQuery1}                                        ) ";
			strQuery1 = $"{strQuery1}                            ) "; //--NOT EXISTS
			strQuery1 = $"{strQuery1}                      ) "; //-- AND AM2.
			strQuery1 = $"{strQuery1}                 ) "; //-- AND (
			strQuery1 = $"{strQuery1}  ) "; //-- SELECT NULL
			strQuery1 = $"{strQuery1}) "; //-- AND (EXISTS

			// Can NOT Have A Jet, TurboProp, ExcAir
			strQuery1 = $"{strQuery1}AND (NOT EXISTS (SELECT NULL FROM Aircraft_Reference AS AR2 WITH (NOLOCK) ";
			strQuery1 = $"{strQuery1}                 INNER JOIN Aircraft AS A2 WITH (NOLOCK) ON A2.ac_id = AR2.cref_ac_id AND A2.ac_journ_id = AR2.cref_journ_id ";
			strQuery1 = $"{strQuery1}                 INNER JOIN Aircraft_Model AS AM2 WITH (NOLOCK) ON AM2.amod_id = A2.ac_amod_id ";
			strQuery1 = $"{strQuery1}                 WHERE (AR2.cref_comp_id = C1.comp_id) ";
			strQuery1 = $"{strQuery1}                 AND (AR2.cref_journ_id = C1.comp_journ_id) ";
			strQuery1 = $"{strQuery1}                 AND (AR2.cref_primary_poc_flag IN ('X','Y')) ";
			strQuery1 = $"{strQuery1}                 AND (AM2.amod_airframe_type_code = 'F') ";
			strQuery1 = $"{strQuery1}                 AND (AM2.amod_type_code IN ('J','T','E')) ";
			strQuery1 = $"{strQuery1}                 AND (A2.ac_product_business_flag = 'Y') ";
			strQuery1 = $"{strQuery1}             ) ";
			strQuery1 = $"{strQuery1}    ) ";

			return strQuery1;

		} // Return_Non_JNiQ_Eligible_Query

		internal static bool OpenMarketingCRMDatabase(ref DbConnection cntCRMMktConn)
		{

			bool result = false;
			bool bResults = false;

			try
			{

				bResults = false;

				if (cntCRMMktConn != null)
				{
					if (cntCRMMktConn.State == ConnectionState.Open)
					{
						UpgradeHelpers.DB.TransactionManager.DeEnlist(cntCRMMktConn);
						cntCRMMktConn.Close();
					}
					cntCRMMktConn = null;
				}

				cntCRMMktConn = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateConnection();
				cntCRMMktConn.ConnectionString = gstrCRMMktConn;
				//UPGRADE_TODO: (7010) The connection string must be verified to fullfill the .NET data provider connection string requirements. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-7010
				cntCRMMktConn.Open();

				bResults = true;


				return bResults;
			}
			catch
			{

				MessageBox.Show($"Error Opening Marketing CRM Database{Environment.NewLine}{Environment.NewLine}Make Sure the {{MySQL ODBC 5.1 Driver}} is Loaded", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);

				result = false;
			}
			return result;
		} // OpenMarketingCRMDatabase

		internal static void Set_Company_Marketing_Rep_Combo_Box(ComboBox cmbCombo, string strMktRep)
		{

			string strMktRepName = "";

			cmbCombo.SelectedIndex = -1;

			if (strMktRep != "")
			{
				strMktRepName = DLookUp("user_first_name + ' ' + user_last_name", "[User]", $"([user_id]='{strMktRep}')");
				if (strMktRepName != "")
				{
					int tempForEndVar = cmbCombo.Items.Count - 1;
					for (int lCnt1 = 0; lCnt1 <= tempForEndVar; lCnt1++)
					{
						if (strMktRepName == cmbCombo.GetListItem(lCnt1).Substring(0, Math.Min(Strings.Len(strMktRepName), cmbCombo.GetListItem(lCnt1).Length)))
						{
							cmbCombo.SelectedIndex = lCnt1;
						}
					}
				}

			}

		} // Set_Company_Marketing_Rep_Combo_Box

		internal static bool DoesCompanyHaveDocumentsInProcess(int lCompId)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			bool bResults = false;

			try
			{

				bResults = false;

				if (lCompId > 0)
				{

					strQuery1 = "SELECT TOP 1 faalog_id FROM FAA_Document_Log WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1}INNER JOIN Aircraft_Reference WITH (NOLOCK) ON cref_ac_id = faalog_ac_id AND cref_journ_id = faalog_journ_id ";
					strQuery1 = $"{strQuery1}WHERE (cref_comp_id = {lCompId.ToString()}) ";
					strQuery1 = $"{strQuery1}AND (faalog_journ_id = 0) ";
					// 12/07/2015 - By David D. Cruger
					// Per Jackie; Remove Primary Criteria
					//strQuery1 = strQuery1 & "AND (cref_primary_poc_flag IN ('X','Y')) "

					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!rstRec1.BOF && !rstRec1.EOF)
					{
						bResults = true;
					}

					rstRec1.Close();

				} // If lCompId > 0 Then

				rstRec1 = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DoesCompanyHaveDocumentsInProcess_Error", excep.Message);
			}
			return false;
		} // DoesCompanyHaveDocumentsInProcess

		internal static void Close_All_Midi_Open_Forms()
		{

			Form fForm = null;

			foreach (Form fFormIterator in Application.OpenForms)
			{
				fForm = fFormIterator;

				if (fForm.Name == "frm_OpenDocument")
				{
					fForm.Close();
				}
				if (fForm.Name == "frm_Info")
				{
					fForm.Close();
				}
				if (fForm.Name == "frm_Tips")
				{
					fForm.Close();
				}
				if (fForm.Name == "frm_PopUp")
				{
					fForm.Close();
				}
				if (fForm.Name == "frm_UserHistory")
				{
					fForm.Close();
				}

				//fForm
				fForm = default(Form);
			}

		} // Close_All_Midi_Open_Forms

		internal static bool IsContactOnDoNotSendJNiQSurveyList(int lCompId, int lContactId)
		{

			bool result = false;
			bool bResults = false;
			string strEvtId = "";
			int lEvtId = 0;

			try
			{

				bResults = false;

				if (lCompId > 0 && lContactId > 0)
				{

					lEvtId = 0;
					strEvtId = DLookUp("evtl_id", "EventLog", $"(evtl_comp_id = {lCompId.ToString()}) AND (evtl_contact_id = {lContactId.ToString()}) AND (evtl_type = 'Do Not Send JNiQ Survey')");
					if (strEvtId != "")
					{
						if (Information.IsNumeric(strEvtId))
						{
							lEvtId = Convert.ToInt32(Double.Parse(strEvtId));
						}
					}

					if (lEvtId > 0)
					{
						bResults = true;
					}

				} // If lCompId > 0 And lContactId > 0 Then


				return bResults;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("IsContactOnDoNotSendJNiQSurveyList_Error", excep.Message);

				result = false;
			}
			return result;
		} // IsContactOnDoNotSendJNiQSurveyList

		internal static void FillComboAircraftClass(ComboBox cmbBox)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			try
			{

				cmbBox.Items.Clear();
				strQuery1 = "SELECT * FROM Aircraft_Class WITH( NOLOCK) ORDER BY aclass_code ";

				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					cmbBox.AddItem("All");

					do 
					{

						cmbBox.AddItem($"Class {($"{Convert.ToString(rstRec1["aclass_code"])} ").Trim()}");
						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

					cmbBox.SelectedIndex = 0;

				} // If (rstRec1.BOF = False And rstRec1.EOF = False) Then

				rstRec1.Close();
				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"FillComboAircraftClass_Error: {Information.Err().Number.ToString()} {excep.Message}");
			}

		} // FillComboAircraftClass

		internal static void EMail_RegNbr_Request_To_FAA(int lACId, string strRegNbr, bool bEnterJournal = false)
		{

			string strTo = "";
			string strSubject = "";
			string strBody = "";

			try
			{

				if (lACId > 0)
				{

					if (strRegNbr != "")
					{

						strTo = DLookUp("aconfig_ac_regnbr_request_email", "Application_Configuration");

						if (strTo != "")
						{

							strSubject = $"Request FAA Registration Number - {strRegNbr}";
							strBody = $"Please process and send FAA Registration Number Information for RegNbr - {strRegNbr}";

							modAdminCommon.Record_Event("Aircraft RegNbr Request", strSubject, lACId, 0, 0, false, 0, 0);

							//UPGRADE_WARNING: (2081) ShellExecuteA has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
							ProcessStartInfo startInfo = new ProcessStartInfo();
							startInfo.UseShellExecute = true;
							startInfo.CreateNoWindow = false;
							startInfo.Verb = "open";
							startInfo.FileName = $"mailto:{strTo}?subject={strSubject}&body={strBody}";
							startInfo.Arguments = "";
							startInfo.WorkingDirectory = "";
							startInfo.WindowStyle = ProcessWindowStyle.Hidden;
							Process shellExecuteProcess = Process.Start(startInfo);
							int tempAuxVar = shellExecuteProcess.ExitCode;

							if (bEnterJournal)
							{
							}

						}
						else
						{
							MessageBox.Show("EMail RegNbr Request Failed.  EMail TO Field Is Blank", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						} // If strTo <> "" Then

					}
					else
					{
						MessageBox.Show("EMail RegNbr Request Failed.  RegNbr Is Blank", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					} // If strRegNbr <> "" Then

				}
				else
				{
					MessageBox.Show("EMail RegNbr Request Failed.  ACId Is Blank Or Zero", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If lACId > 0 Then
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"EMail_RegNbr_Request_To_FAA_Error: {Information.Err().Number.ToString()} {excep.Message}");
			}

		} // EMail_RegNbr_Request_To_FAA


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
				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

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
				modAdminCommon.Report_Error($"CreateNewAVDataId_Error: {Information.Err().Number.ToString()} {excep.Message}");

				result = "";
			}
			return result;
		} // CreateNewAVDataId

		internal static bool RegNoDuplicate(string strRegNbr, string strACId)
		{

			string strQuery1 = "";

			bool bResults = false;

			if (strACId != "" && strACId != "0")
			{
				// MSW - updated to use new view - 2/6/25
				strQuery1 = $"select * from Research_Integrity_Aircraft_Registration_Number_Duplicates_View where ac_reg_no = '{strRegNbr}' ";
				if (modAdminCommon.Exist(strQuery1))
				{
					bResults = true;
				}
			}
			else
			{
				strQuery1 = $"SELECT ac_id FROM Aircraft WHERE (ac_reg_no = '{strRegNbr}') AND (ac_journ_id = 0)";
				if (modAdminCommon.Exist(strQuery1))
				{
					bResults = true;
				}
			}

			return bResults;

		} // RegNoDuplicate

		internal static string Return_Yacht_Reference_ListBox_Types(ListBox lstBox)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			bool bFound = false;
			string strResults = "";

			try
			{

				strResults = "";

				if (lstBox.SelectedItems.Count > 0)
				{

					strQuery1 = "SELECT yct_code, yct_name  FROM Yacht_Contact_Type WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1}WHERE (yct_yacht_reference_flag = 'Y')  ORDER BY yct_name ";

					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						int tempForEndVar = lstBox.Items.Count - 1;
						for (int lCnt1 = 1; lCnt1 <= tempForEndVar; lCnt1++)
						{

							if (ListBoxHelper.GetSelected(lstBox, lCnt1))
							{

								rstRec1.MoveFirst();
								bFound = false;
								do 
								{ // Loop Until rstRec1.EOF = True Or bFound = True

									if (lstBox.GetListItem(lCnt1) == ($"{Convert.ToString(rstRec1["yct_name"])} ").Trim())
									{
										strResults = $"{strResults}{($"{Convert.ToString(rstRec1["yct_code"])} ").Trim()},";
										bFound = true;
									}

									rstRec1.MoveNext();

								}
								while(!(rstRec1.EOF || bFound));

							} // If lstBox.Selected(lCnt1) = True Then

						}

						strResults = strResults.Substring(0, Math.Min(Strings.Len(strResults) - 1, strResults.Length)); // Remove Last Comma
						strResults = $"'{StringsHelper.Replace(strResults, ",", "','", 1, -1, CompareMethod.Binary)}'";

					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

				} // If lstBox.SelCount > 0 Then

				rstRec1 = null;


				return strResults;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Return_Yacht_Reference_ListBox_Types_Error", excep.Message);
			}
			return "";
		} // Return_Yacht_Reference_ListBox_Types

		internal static string FilterNoteInformation(string strNote)
		{

			string strChar = "";
			int lChar = 0;

			StringBuilder strResults = new StringBuilder();
			strNote = strNote.Trim();

			if (strNote != "")
			{

				int tempForEndVar = Strings.Len(strNote);
				for (int lCnt1 = 1; lCnt1 <= tempForEndVar; lCnt1++)
				{
					strChar = strNote.Substring(Math.Min(lCnt1 - 1, strNote.Length), Math.Min(1, Math.Max(0, strNote.Length - (lCnt1 - 1))));
					lChar = Strings.Asc(strChar[0]);
					if (lChar == Strings.Asc("\r"[0]) || lChar == Strings.Asc(Constants.vbLf[0]) || (lChar >= 32 && lChar <= 125))
					{
						if (lChar != 63)
						{
							strResults.Append(strChar);
						}
					}
				}

			} // If strNote <> "" Then

			return strResults.ToString();

		} // FilterNoteInformation

		internal static void Unload_Form(string strForm)
		{

			Form Frm = null;
			Form f = null;

			try
			{

				foreach (Form FrmIterator in Application.OpenForms)
				{
					Frm = FrmIterator;
					f = Frm;
					if (Frm.Name.Trim() == strForm)
					{
						f.Close();
					}
					Frm = default(Form);
				}
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Common - Unload_Form", excep.Message);
			}

		} // Unload_Form

		internal static void Hide_Form(string strForm)
		{

			Form Frm = null;

			try
			{

				foreach (Form FrmIterator in Application.OpenForms)
				{
					Frm = FrmIterator;
					if (Frm.Name.Trim() == strForm)
					{
						Frm.Hide();
					}
					Frm = default(Form);
				}
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Common - Unload_Form", excep.Message);
			}

		} // Hide Form

		internal static void Show_Form(string strForm)
		{

			Form Frm = null;

			try
			{

				foreach (Form FrmIterator in Application.OpenForms)
				{
					Frm = FrmIterator;
					//Debug.Print Frm.Name & " - " & Frm.Caption
					if (Frm.Name.Trim() == strForm)
					{
						//UPGRADE_WARNING: (2065) Form method Frm.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
						Frm.BringToFront();
					}
					Frm = default(Form);
				}
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Common - Show_Form", excep.Message);
			}

		} // Show_Form

		internal static bool Is_Form_Already_Loaded(string strForm)
		{

			Form Frm = null;

			bool bResults = false;

			foreach (Form FrmIterator in Application.OpenForms)
			{
				Frm = FrmIterator;
				if (Frm.Name.Trim() == strForm)
				{
					bResults = true;
				}
				Frm = default(Form);
			}

			return bResults;

		} // Is_Form_Already_Loaded

		internal static void Unload_All_Forms_Except(string strForm)
		{

			if (strForm != "Aircraft")
			{
				Unload_Form("frm_Aircraft");
			}
			if (strForm != "Aircraft Find")
			{
				Unload_Form("frm_AircraftList");
			}
			if (strForm != "Company")
			{
				Unload_Form("frm_Company");
			}
			if (strForm != "Company Find")
			{
				Unload_Form("frm_Find_Company");
			}
			if (strForm != "Contact")
			{
				Unload_Form("frm_CompanyContact");
			}
			if (strForm != "User Accounts")
			{
				Unload_Form("frm_UserAccounts");
			}

		} // Hide_All_Forms_Except

		internal static void Hide_All_Forms_Except(string strForm)
		{

			if (strForm != "Aircraft")
			{
				Hide_Form("frm_Aircraft");
			}
			if (strForm != "Aircraft Find")
			{
				Hide_Form("frm_AircraftList");
			}
			if (strForm != "Company")
			{
				Hide_Form("frm_Company");
			}
			if (strForm != "Company Find")
			{
				Hide_Form("frm_Find_Company");
			}
			if (strForm != "Contact")
			{
				Hide_Form("frm_CompanyContact");
			}
			if (strForm != "Callback")
			{
				Hide_Form("frm_ActionList");
			}

		} // Hide_All_Forms_Except

		internal static object ShowAndLoadCompanyFindFormat(int iForm)
		{

			if (modGlobalVars.bCallShowAndLoadOnlyOnce)
			{

				if (iForm == 0)
				{
					iForm++;
				}
				//UPGRADE_TODO: (1067) Member Show is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[iForm - 1].Show();
				modGlobalVars.find_frm_collection[iForm - 1].BringToFront(); //gap-note Manual change to fix BringToFront rule failing sometimes
				//UPGRADE_TODO: (1067) Member SetFocus is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[iForm - 1].Focus();

			}

			return null;
		}

		internal static object Unload_All_Forms_In_Collection()
		{

			Form Frm = null;

			if (modGlobalVars.find_frm_collection.Count > 0)
			{
				for (int X = modGlobalVars.find_frm_collection.Count; X >= 1; X--)
				{
					Frm = (Form) modGlobalVars.find_frm_collection[X - 1];
					modGlobalVars.find_frm_collection.RemoveAt(X - 1);
					Frm.Close();
					//UPGRADE_NOTE: (1029) Object Frm may not be destroyed until it is garbage collected. More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-1029
					Frm = null;
				}
			}

			return null;
		} // Unload_All_Forms_In_Collection

		internal static object Unload_All_Open_Forms()
		{

			Form Frm = null;

			foreach (Form FrmIterator in Application.OpenForms)
			{
				Frm = FrmIterator;

				if (Frm.Name != "frm_Main_Menu" && Frm.Name != "mdi_ResearchAssistant")
				{
					Frm.Close();
				}
				//Frm
				Frm = default(Form);
			}

			return null;
		} // Unload_All_Open_Forms

		internal static string Get_FAA_Document_In_Process_File_Name(int lFAADocId, int lACId)
		{

			string result = "";
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strResults = "";

			try
			{

				strResults = "";

				if (lFAADocId > 0)
				{

					if (lACId > 0)
					{

						strQuery1 = "SELECT * FROM FAA_Document_Log WITH (NOLOCK) ";
						strQuery1 = $"{strQuery1}WHERE (faalog_id = {lFAADocId.ToString()}) ";

						rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

						if (!rstRec1.BOF && !rstRec1.EOF)
						{


							switch(($"{Convert.ToString(rstRec1["faalog_doc_type"])} ").Trim().ToLower())
							{
								case "nts" : 
									strResults = $"{Convert.ToString(rstRec1["faalog_id"])}.html"; 
									 
									break;
								default:
									strResults = StringsHelper.Format(($"{Convert.ToString(rstRec1["faalog_tape_no"])} ").Trim(), "00000"); 
									strResults = $"{strResults}-{StringsHelper.Format(($"{Convert.ToString(rstRec1["faalog_tape_of"])} ").Trim(), "0")}"; 
									strResults = $"{strResults}of{StringsHelper.Format(($"{Convert.ToString(rstRec1["faalog_tape_to"])} ").Trim(), "0")}"; 
									strResults = $"{strResults}-{StringsHelper.Format(($"{Convert.ToString(rstRec1["faalog_starting_frame_no"])} ").Trim(), "00000")}"; 
									strResults = $"{strResults}-{StringsHelper.Format(($"{Convert.ToString(rstRec1["faalog_ending_frame_no"])} ").Trim(), "00000")}"; 
									strResults = $"{strResults}-{($"{Convert.ToString(rstRec1["faalog_doc_type"])} ").Trim().ToLower()}"; 
									// Use The Parameter lACId Instead Of The Recordset 
									strResults = $"{strResults}-{StringsHelper.Format(lACId, "000000")}"; 
									strResults = $"{strResults}.pdf"; 
									break;
							} // Case  LCase(Trim(rstRec1!faalog_doc_type & " "))

						} // If rstRec1.BOF = False And rstRec1.EOF = False Then

						rstRec1.Close();

					} // If lACId > 0 Then

				} // If lFAADocId > 0 Then

				rstRec1 = null;


				return strResults;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Get_FAA_Document_In_Process_File_Name_Error", excep.Message);

				result = "";
			}
			return result;
		} // Get_FAA_Document_In_Process_File_Name

		internal static string Return_FAA_Document_Root_Directory(string strType)
		{

			string strResults = "";

			strType = strType.Trim().ToLower();

			if (strType != "")
			{

				switch(strType)
				{
					case "nts" : 
						strResults = DLookUp("aconfig_ntsb_maindir", "application_configuration"); 
						 
						break;
					default: // PDF 
						strResults = DLookUp("aconfig_faapdf_maindir", "application_configuration"); 
						break;
				} // Case strType

				if (strResults.Substring(Math.Max(strResults.Length - 1, 0)) != "\\")
				{
					strResults = $"{strResults}\\";
				}
				strResults = $"{strResults}PROCESSING\\";

			} // If strType <> "" Then

			return strResults;

		} // Return_FAA_Document_Root_Directory

		internal static string Format_Phone_Number_To_Dial(string strLineAccess, string strCOUNTRY, string strCountryCode, string strAreaCode, string strPrefix, string strPhoneNbr)
		{

			string strResults = "";
			string strTemp = "";

			strLineAccess = strLineAccess.Substring(0, Math.Min(1, strLineAccess.Length)).Trim();

			if (strLineAccess == "")
			{
				strLineAccess = "7";
				if (strCOUNTRY != "")
				{
					strTemp = DLookUp("country_line_access_code", "Country", $"(country_name = '{StringsHelper.Replace(strCOUNTRY, "'", "''", 1, -1, CompareMethod.Binary)}')");
					if (strTemp.Trim() != "")
					{
						strLineAccess = strTemp;
					}
				}
			} // strLineAccess = "7"

			// WE ARE CLEARING THE LINE ACCESS - PATTY REQUEST - MSW - 2/9/21
			strLineAccess = "";

			strCountryCode = strCountryCode.Trim();
			strAreaCode = strAreaCode.Trim();
			strPrefix = strPrefix.Trim();
			strPhoneNbr = strPhoneNbr.Trim();

			if (strCountryCode != "")
			{
				strResults = $"{strResults}{strCountryCode}-";
			}
			if (strAreaCode != "")
			{
				strResults = $"{strResults}{strAreaCode}-";
			}
			if (strPrefix != "")
			{
				strResults = $"{strResults}{strPrefix}-";
			}
			if (strPhoneNbr != "")
			{
				strResults = $"{strResults}{strPhoneNbr}";
			}

			if (strResults.Substring(Math.Max(strResults.Length - 1, 0)) == "-")
			{
				strResults = strResults.Substring(0, Math.Min(Strings.Len(strResults) - 1, strResults.Length));
			}

			if (strAreaCode == "315")
			{
				strResults = $" 1 {strResults}"; // Local Call  ' removed the 4 MSW - 2/9/21
				//strResults = "4 " & strResults                           ' Local Call
			}
			else
			{
				if (strCountryCode == "")
				{
					strResults = $"{strLineAccess} 1 {strResults}"; // Long Distance
				}
				else
				{
					strResults = $"{strLineAccess} 011 {strResults}"; // International
				}
			}

			return strResults;

		} // Format_Phone_Number_To_Dial

		internal static void Fill_Country_Combo_Box(ComboBox cboBox, string strCOUNTRY = "")
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();

			cboBox.Items.Clear();
			cboBox.AddItem("");
			strCOUNTRY = strCOUNTRY.Trim();

			string strQuery1 = "SELECT country_name FROM Country WITH (NOLOCK) WHERE (country_active_flag = 'Y') ";
			strQuery1 = $"{strQuery1}ORDER BY country_name ";

			rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

			if (!rstRec1.BOF && !rstRec1.EOF)
			{

				do 
				{ // Loop Until rstRec1.EOF = True

					cboBox.AddItem(($"{Convert.ToString(rstRec1["country_name"])} ").Trim());
					if (strCOUNTRY == ($"{Convert.ToString(rstRec1["country_name"])} ").Trim())
					{
						cboBox.SelectedIndex = cboBox.GetNewIndex();
					}

					rstRec1.MoveNext();

				}
				while(!rstRec1.EOF);

			} // If rstRec1.BOF = False And rstRec1.EOF = False Then

			rstRec1.Close();

		} // Fill_Country_Combo_Box

		internal static void Fill_State_Combo_Box(ComboBox cboBox, string strCOUNTRY = "", string strState = "")
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();

			cboBox.Items.Clear();
			cboBox.AddItem("");
			strCOUNTRY = strCOUNTRY.Trim();
			strState = strState.Trim();

			string strQuery1 = "SELECT state_name FROM [State] WITH (NOLOCK) ";
			strQuery1 = $"{strQuery1}WHERE (state_active_flag = 'Y') ";

			if (strCOUNTRY != "")
			{
				strQuery1 = $"{strQuery1}AND (state_country = '{StringsHelper.Replace(strCOUNTRY, "'", "''", 1, -1, CompareMethod.Binary)}') ";
			}

			strQuery1 = $"{strQuery1}ORDER BY state_name ";

			rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

			if (!rstRec1.BOF && !rstRec1.EOF)
			{

				do 
				{ // Loop Until rstRec1.EOF = True

					cboBox.AddItem(($"{Convert.ToString(rstRec1["State_name"])} ").Trim());
					if (strState == ($"{Convert.ToString(rstRec1["State_name"])} ").Trim())
					{
						cboBox.SelectedIndex = cboBox.GetNewIndex();
					}

					rstRec1.MoveNext();

				}
				while(!rstRec1.EOF);

			} // If rstRec1.BOF = False And rstRec1.EOF = False Then

			rstRec1.Close();

		} // Fill_State_Combo_Box

		internal static string Return_State_Abbrev_From_State_Name(string strState, string strCOUNTRY = "")
		{


			string strResults = "";

			strState = strState.Trim();
			strCOUNTRY = strCOUNTRY.Trim();

			if (strState != "")
			{

				if (strCOUNTRY == "")
				{
					strResults = DLookUp("state_code", "[State]", $"(state_name = '{StringsHelper.Replace(strState, "'", "''", 1, -1, CompareMethod.Binary)}') AND (state_active_flag = 'Y')");
				}
				else
				{
					strResults = DLookUp("state_code", "[State]", $"(state_name = '{StringsHelper.Replace(strState, "'", "''", 1, -1, CompareMethod.Binary)}') AND (state_active_flag = 'Y') AND (state_country = '{StringsHelper.Replace(strCOUNTRY, "'", "''", 1, -1, CompareMethod.Binary)}')");
				}

			} // If strState <> "" Then

			return strResults;

		} // Return_State_Abbrev_From_State_Name

		internal static bool Is_State_Name_In_Country(string strCOUNTRY, string strStateName)
		{

			string strSearchCountry = "";

			bool bResults = false;

			strCOUNTRY = strCOUNTRY.Trim();
			strStateName = strStateName.Trim();

			if (strCOUNTRY != "")
			{

				if (strStateName != "")
				{

					strSearchCountry = DLookUp("state_country", "[State]", $"(state_name = '{StringsHelper.Replace(strStateName, "'", "''", 1, -1, CompareMethod.Binary)}')");
					if (strSearchCountry.ToUpper() == strCOUNTRY.ToUpper())
					{
						bResults = true;
					}

				} // If strStateName <> "" Then

			} // If strCountry <> "" Then

			return bResults;

		} // Is_State_Name_In_Country

		internal static bool Is_State_Abbrev_In_Country(string strCOUNTRY, string strStateAbbrev)
		{

			string strSearchCountry = "";

			bool bResults = false;

			strCOUNTRY = strCOUNTRY.Trim();
			strStateAbbrev = strStateAbbrev.Trim();

			if (strCOUNTRY != "")
			{

				if (strStateAbbrev != "")
				{

					strSearchCountry = DLookUp("state_country", "[State]", $"(state_code = '{strStateAbbrev}')");
					if (strSearchCountry.ToUpper() == strCOUNTRY.ToUpper())
					{
						bResults = true;
					}

				} // If strStateAbbrev <> "" Then

			} // If strCountry <> "" Then

			return bResults;

		} // Is_State_Abbrev_In_Country

		internal static void SetComboBoxValue(ComboBox cmbBox, string strValue)
		{


			if (strValue != "")
			{
				cmbBox.SelectedIndex = 0;
				int tempForEndVar = cmbBox.Items.Count - 1;
				for (int iCnt1 = 0; iCnt1 <= tempForEndVar; iCnt1++)
				{
					if (strValue == cmbBox.GetListItem(iCnt1).Substring(0, Math.Min(Strings.Len(strValue), cmbBox.GetListItem(iCnt1).Length)))
					{
						cmbBox.SelectedIndex = iCnt1;
					}
				}
			} // If strValue <> "" Then

		} // SetComboBoxValue

		internal static bool IsDocumentAPossibleDuplicate(int lACId, string strDocType, System.DateTime dtDocDate)
		{

			bool result = false;
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			bool bResults = false;

			try
			{

				bResults = false;

				strDocType = strDocType.Trim();

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (lACId > 0 && strDocType != "" && !Convert.IsDBNull(dtDocDate))
				{

					strQuery1 = "SELECT COUNT(*) As TotDocs  FROM Aircraft_Document WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1}INNER JOIN Document_Type WITH (NOLOCK) ON doctype_description = adoc_doc_type ";
					strQuery1 = $"{strQuery1}WHERE (adoc_ac_id = {lACId.ToString()}) AND (adoc_journ_id > 0) ";
					strQuery1 = $"{strQuery1}AND (doctype_code = '{strDocType}') ";
					strQuery1 = $"{strQuery1}AND (CAST(adoc_doc_date AS DATE) = '{dtDocDate.ToString("MM/dd/yyyy")}') ";
					strQuery1 = $"{strQuery1}AND (doctype_company_doc_view = 'N') ";

					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!rstRec1.BOF && !rstRec1.EOF)
					{
						if (Convert.ToDouble(rstRec1["TotDocs"]) > 0)
						{
							bResults = true;
						}
					}

					rstRec1.Close();

				} // If lACId > 0 And strDocType <> "" And IsNull(dtDocDate) = False Then

				rstRec1 = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("IsDocumentAPossibleDuplicate_Error", excep.Message);
				result = false;
			}
			return result;
		} // IsDocumentAPossibleDuplicate

		internal static string GetCompanyInfo(int incompid)
		{

			string result = "";
			ADORecordSetHelper snpCompInfo = new ADORecordSetHelper();


			string Query = "SELECT comp_name, comp_address1, comp_address2, comp_city,";
			Query = $"{Query}comp_state, comp_zip_code, comp_country";
			Query = $"{Query} FROM Company WHERE comp_id = {incompid.ToString()} AND comp_journ_id = 0";

			snpCompInfo.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

			string strResults = "";

			if (!(snpCompInfo.BOF && snpCompInfo.EOF))
			{
				strResults = $"{($"{Convert.ToString(snpCompInfo["comp_name"])}").Trim()}{Environment.NewLine}";
				strResults = $"{strResults}{($"{Convert.ToString(snpCompInfo["comp_address1"])}").Trim()}{Environment.NewLine}";
				strResults = $"{strResults}{($"{Convert.ToString(snpCompInfo["Comp_address2"])}").Trim()}{Environment.NewLine}";
				strResults = $"{strResults}{($"{Convert.ToString(snpCompInfo["Comp_city"])}").Trim()}, ";
				strResults = $"{strResults}{($"{Convert.ToString(snpCompInfo["comp_state"])}").Trim()} ";
				strResults = $"{strResults}{($"{Convert.ToString(snpCompInfo["Comp_zip_code"])}").Trim()}{Environment.NewLine}";
				strResults = $"{strResults}{($"{Convert.ToString(snpCompInfo["Comp_country"])}").Trim()}";

			}

			result = strResults;

			snpCompInfo.Close();

			return result;
		} // GetCompanyInfo


		internal static int CountDocumentNameByType(string strDocType)
		{

			string strDocName = "";
			string strResults = "";

			int iResults = 0;

			strDocType = strDocType.Trim().ToUpper();
			if (strDocType != "")
			{

				strDocName = DLookUp("doctype_description", "Document_Type", $"(doctype_code = '{strDocType}')");

				if (strDocName != "")
				{

					strResults = DLookUp("COUNT(doctype_code) As TotCnt", "Document_Type", $"(doctype_description = '{strDocName}')");
					if (Information.IsNumeric(strResults))
					{
						iResults = Convert.ToInt32(Double.Parse(strResults));
					}

				} // If strDocName <> "" Then

			} // If strDocType <> "" Then

			return iResults;

		} // CountDocumentNameByType

		internal static int Return_Aircraft_Estimated_Airframe_Total_Time(int lACId, System.DateTime dtTimesCurrent, System.DateTime dtDatePurchased)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strTimesCurrent = "";
			string strDatePurchased = "";

			int lResults = 0;

			try
			{

				lResults = 0;
				strTimesCurrent = dtTimesCurrent.ToString("MM/dd/yyyy");
				strDatePurchased = dtDatePurchased.ToString("MM/dd/yyyy");

				if (lACId > 0)
				{

					if (strTimesCurrent != "")
					{

						if (Information.IsDate(strTimesCurrent))
						{

							if (strDatePurchased != "")
							{

								if (Information.IsDate(strDatePurchased))
								{

									dtTimesCurrent = DateTime.Parse(strTimesCurrent);
									dtDatePurchased = DateTime.Parse(strDatePurchased);

									if (dtTimesCurrent > DateTime.Parse("1/1/2000"))
									{

										strQuery1 = "SELECT ac_airframe_tot_hrs As AFTT, SUM(ffd_flight_time) As TotFlightTime, COUNT(*) As TotCnt ";
										strQuery1 = $"{strQuery1}FROM FAA_Flight_Data WITH (NOLOCK)";
										strQuery1 = $"{strQuery1}INNER JOIN Aircraft WITH (NOLOCK) ON ac_id = ffd_ac_id AND ac_journ_id = 0 ";
										strQuery1 = $"{strQuery1}Where (ffd_ac_id = {lACId.ToString()}) ";
										strQuery1 = $"{strQuery1}AND (ffd_hide_flag = 'N') ";
										strQuery1 = $"{strQuery1}AND (ffd_date > ac_times_as_of_date) AND (ffd_date >= ac_purchase_date) ";
										strQuery1 = $"{strQuery1}AND (ac_times_as_of_date > = '1/1/2000') ";
										strQuery1 = $"{strQuery1}AND (ac_airframe_tot_hrs > 0) AND (ac_airframe_tot_hrs IS NOT NULL) ";
										strQuery1 = $"{strQuery1}GROUP BY ac_airframe_tot_hrs ";

										rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

										if (!rstRec1.BOF && !rstRec1.EOF)
										{

											if (Convert.ToDouble(rstRec1["TotCnt"]) > 0 && Convert.ToDouble(rstRec1["TotFlightTime"]) > 0)
											{
												// Add 12 Mins Per Flight
												lResults = Convert.ToInt32(Convert.ToDouble(rstRec1["aftt"]) + Math.Round((double) (Convert.ToDouble(rstRec1["TotFlightTime"]) / 60d), 0) + Math.Round((double) ((Convert.ToDouble(rstRec1["TotCnt"]) * 12) / 60d), 0));
											}

										} // If rstRec1.BOF = False And rstRec1.EOF = False Then

										rstRec1.Close();

									} // If dtTimesCurrent > CDate("1/1/2000") Then

								} // If IsDate(strDatePurchased) = True Then

							} // If strDatePurchased <> "" Then

						} // If IsDate(strTimesCurrent) = True Then

					} // If strTimesCurrent <> "" Then

				} // If lACId > 0 Then

				rstRec1 = null;


				return lResults;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Return_Aircraft_Estimated_Airframe_Total_Time_Error", excep.Message);
			}
			return 0;
		} // Return_Aircraft_Estimated_Airframe_Total_Time

		internal static void convert_metric_to_us1(ref double feet, ref double inches, double metric)
		{


			double english = (metric * 3.28084d);
			feet = Math.Floor(english);
			inches = (english - feet) * 12;
			inches = Double.Parse(Double.Parse(inches.ToString(), NumberStyles.Any).ToString("N0"));

			if (inches == 12)
			{
				feet++;
				inches = 0;
			}

		} // convert_metric_to_us1

		internal static string GetSpecialfolder(int lCSIDL)
		{

			string strPath = "";
			JetNetSupport.PInvoke.UnsafeNative.Structures.ITEMIDLIST IDL = JetNetSupport.PInvoke.UnsafeNative.Structures.ITEMIDLIST.CreateInstance();

			//Get the special folder
			string strResults = "";
			int lResults = JetNetSupport.PInvoke.SafeNative.shell32.SHGetSpecialFolderLocation(100, lCSIDL, ref IDL);

			if (lResults == 0)
			{

				//Create a buffer
				strPath = new String(' ', 512);

				//Get the path from the IDList
				lResults = JetNetSupport.PInvoke.SafeNative.shell32.SHGetPathFromIDList(IDL.mkid.cb, ref strPath);

				//Remove the unnecessary chr$(0)'s
				strResults = strPath.Substring(0, Math.Min(strPath.IndexOf(Strings.Chr(0).ToString()), strPath.Length));

			} // If lResults = NOERROR Then

			return strResults;

		} // GetSpecialfolder

		internal static void Enter_Customer_Program_Message_Note(string strTo, string strEMailTo, string strMessage, int lSubId, int lParentId, int lCompId, int lContactId)
		{

			DbConnection cntConn = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateConnection();

			ADORecordSetHelper rstAdd1 = new ADORecordSetHelper();
			string strQuery1 = "";

			try
			{

				strTo = strTo.Trim();
				strEMailTo = strEMailTo.Trim();
				strMessage = strMessage.Trim();

				if (strMessage != "")
				{

					if (strTo == "" && strEMailTo != "")
					{
						strTo = Return_User_Id_By_EMail(strEMailTo);
					}

					if (OpenCustomerSQLDatabase(ref cntConn))
					{

						strQuery1 = "SELECT * FROM Customer_Messages WHERE (cm_id = -1) ";
						rstAdd1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);

						rstAdd1.AddNew();

						rstAdd1["cm_techid_value"] = lSubId;
						rstAdd1["cm_sub_id"] = lSubId;
						rstAdd1["cm_parent_id"] = lParentId;
						rstAdd1["cm_comp_id"] = lCompId;
						rstAdd1["cm_contact_id"] = lContactId;
						rstAdd1["cm_entered_user_id"] = modAdminCommon.gbl_User_ID;
						rstAdd1["cm_message"] = strMessage.Substring(0, Math.Min(2000, strMessage.Length)).Trim();
						rstAdd1["cm_to_user_id"] = strTo.Substring(0, Math.Min(100, strTo.Length)).Trim();
						rstAdd1.UpdateBatch();

						rstAdd1.Close();
						UpgradeHelpers.DB.TransactionManager.DeEnlist(cntConn);
						cntConn.Close();

					} // If OpenCustomerSQLDatabase(cntConn) = True Then

				} // If strMessage <> "" Then

				rstAdd1 = null;
				cntConn = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Enter_Customer_Program_Message_Note_Error", excep.Message);
			}

		} // Enter_Customer_Program_Message_Note

		internal static string Return_User_Id_By_EMail(string strEMailTo)
		{

			string[] aEMail = null;
			int iPos1 = 0;
			string strEMail = "";
			string strTemp = "";

			string strResults = "";
			string strUserId = "";

			strEMailTo = StringsHelper.Replace(strEMailTo, " ", "", 1, -1, CompareMethod.Binary);
			strEMailTo = StringsHelper.Replace(strEMailTo, ";", ",", 1, -1, CompareMethod.Binary);
			strEMailTo = StringsHelper.Replace(strEMailTo, ":", ",", 1, -1, CompareMethod.Binary);
			strEMailTo = StringsHelper.Replace(strEMailTo, "|", ",", 1, -1, CompareMethod.Binary);
			strEMailTo = StringsHelper.Replace(strEMailTo, "\t", ",", 1, -1, CompareMethod.Binary);

			if (strEMailTo != "")
			{

				iPos1 = (strEMailTo.IndexOf(',') + 1);

				if (iPos1 > 0)
				{

					aEMail = strEMailTo.Split(',');
					int tempForEndVar = aEMail.GetUpperBound(0);
					for (int iCnt1 = 0; iCnt1 <= tempForEndVar; iCnt1++)
					{

						strTemp = aEMail[iCnt1];

						if (strTemp.IndexOf("jetnet.com") >= 0)
						{
							strTemp = DLookUp("user_id", "[User]", $"(user_password <> 'inactive') AND (user_email_address = '{strTemp}')");
							if (strTemp != "")
							{
								strUserId = $"{strUserId}{strTemp},";
							}
						}

					}

					strUserId = strUserId.Substring(0, Math.Min(Strings.Len(strUserId) - 1, strUserId.Length)); // Remove Last Comma

				}
				else
				{
					if (strEMailTo.IndexOf("jetnet.com") >= 0)
					{
						strUserId = DLookUp("user_id", "[User]", $"(user_password <> 'inactive') AND (user_email_address = '{strEMailTo}')");
					}
				} // If iPos1 > 0 Then

			} // If strEMailTo <> "" Then

			strResults = strUserId;

			return strResults;

		} // Return_User_Id_By_EMail

		internal static void SetCheckBoxYesNo(CheckBox chkBox, string strValue, CheckState iDefault)
		{

			chkBox.CheckState = iDefault;
			strValue = strValue.Trim();
			if (strValue != "")
			{
				strValue = strValue.ToUpper();
				switch(strValue.Substring(0, Math.Min(1, strValue.Length)))
				{
					case "Y" : 
						chkBox.CheckState = CheckState.Checked; 
						break;
					case "N" : 
						chkBox.CheckState = CheckState.Unchecked; 
						break;
				} // Case Left(strValue,1)

			} // If strValue <> "" Then

		}

		internal static void SetCheckBoxYesNo(CheckBox chkBox, string strValue) => SetCheckBoxYesNo(chkBox, strValue, CheckState.Unchecked);
		 // SetCheckBoxYesNo

		internal static string BuildEngineModelName(string strPrefix, string strCore, string strSuffix1, string strSuffix2) => $"{strPrefix.Trim()}{strCore.Trim()}{strSuffix1.Trim()}{strSuffix2.Trim()}";
		 // BuildEngineModelName

		internal static int ReturnNbrChars(string strData, string strChar)
		{

			string strTemp = "";

			int iResults = 0;

			strData = strData.Trim();
			strChar = strChar.Trim();

			if (strData != "" && strChar != "")
			{

				strChar = strChar.Substring(0, Math.Min(1, strChar.Length));
				strData = strData.ToUpper();
				strChar = strChar.ToUpper();
				strTemp = StringsHelper.Replace(strData, strChar, "", 1, -1, CompareMethod.Binary);
				iResults = Strings.Len(strData) - Strings.Len(strTemp);

			} // If strData <> "" And strChar <> "" Then

			return iResults;

		} // ReturnNbrChars

		internal static int ReturnContactIdByFirstLastName(string strContactFirstLastName, int lCompId, int lJournId)
		{

			int result = 0;
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			int lContactId = 0;
			int lResults = 0;

			try
			{

				lResults = 0;
				lContactId = 0;

				strContactFirstLastName = strContactFirstLastName.Trim();

				if (strContactFirstLastName != "")
				{

					if (lCompId > 0)
					{

						strQuery1 = "SELECT * FROM Contact WITH (NOLOCK) ";
						strQuery1 = $"{strQuery1}WHERE (contact_comp_id = {lCompId.ToString()}) ";
						strQuery1 = $"{strQuery1}AND (contact_journ_id = {lJournId.ToString()}) ";

						rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

						if (!rstRec1.BOF && !rstRec1.EOF)
						{

							do 
							{ // Loop Until rstRec1.EOF = True Or lContactId > 0

								if ($"{($"{Convert.ToString(rstRec1["contact_first_name"])} ").Trim()} {($"{Convert.ToString(rstRec1["contact_last_name"])} ").Trim()}" == strContactFirstLastName)
								{
									lContactId = Convert.ToInt32(rstRec1["contact_id"]);
								}

								rstRec1.MoveNext();

							}
							while(!(rstRec1.EOF || lContactId > 0));

						} // If rstRec1.BOF = False And rstRec1.EOF = False Then

						rstRec1.Close();

						lResults = lContactId;

					} // If lCompId > 0 Then

				} // If strContactFirstLastName <> "" Then

				rstRec1 = null;


				return lResults;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("ReturnContactIdByFirstLastName_Error", excep.Message);

				result = 0;
			}
			return result;
		} // ReturnContactIdByFirstLastName

		internal static void Find_And_Format_Phone_Number_For_TAPI_Dialer(int lCompId, int lContactId, ref string strPhoneNbr)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strCOUNTRY = "";
			string strLineAccess = "";

			try
			{

				if (lCompId > 0)
				{

					strCOUNTRY = DLookUp("comp_country", "Company", $"(comp_id = {lCompId.ToString()}) AND (comp_journ_id = 0) ");

					strQuery1 = "SELECT TOP 1 PN1.*, C1.comp_line_access_code ";
					strQuery1 = $"{strQuery1}FROM Phone_Numbers AS PN1 WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1}INNER JOIN Company AS C1 WITH (NOLOCK) ON comp_id = pnum_comp_id AND comp_journ_id = pnum_journ_id ";
					strQuery1 = $"{strQuery1}WHERE (pnum_comp_id = {lCompId.ToString()}) ";
					strQuery1 = $"{strQuery1}AND (pnum_journ_id = 0) ";
					strQuery1 = $"{strQuery1}AND (pnum_contact_id = {lContactId.ToString()}) ";
					strQuery1 = $"{strQuery1}AND (pnum_number_full = '{strPhoneNbr}') ";

					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						strLineAccess = ($"{Convert.ToString(rstRec1["comp_line_access_code"])} ").Trim();
						strPhoneNbr = Format_Phone_Number_To_Dial(strLineAccess, strCOUNTRY, ($"{Convert.ToString(rstRec1["pnum_cntry_code"])} ").Trim(), ($"{Convert.ToString(rstRec1["pnum_area_code"])} ").Trim(), ($"{Convert.ToString(rstRec1["pnum_Prefix"])} ").Trim(), ($"{Convert.ToString(rstRec1["pnum_number"])} ").Trim());

					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

				} // If lCompId > 0 Then

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Find_And_Format_Phone_Number_For_TAPI_Dialer_Error", excep.Message);

				strPhoneNbr = "";
			}

		} // Find_And_Format_Phone_Number_For_TAPI_Dialer

		internal static void Find_And_Format_Phone_Number_For_NUMVerify(int lCompId, int lContactId, ref string strPhoneNbr)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strCOUNTRY = "";

			try
			{

				if (lCompId > 0)
				{

					strQuery1 = "SELECT TOP 1 * FROM Phone_Numbers WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1}WHERE (pnum_comp_id = {lCompId.ToString()}) ";
					strQuery1 = $"{strQuery1}AND (pnum_journ_id = 0) AND (pnum_contact_id = {lContactId.ToString()}) ";
					strQuery1 = $"{strQuery1}AND (pnum_number_full = '{strPhoneNbr}') ";

					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						if (($"{Convert.ToString(rstRec1["pnum_cntry_code"])} ").Trim() == "")
						{
							strPhoneNbr = $"+1{strPhoneNbr}";
						}
						else
						{
							strPhoneNbr = $"+{strPhoneNbr}";
						}

						strPhoneNbr = StringsHelper.Replace(strPhoneNbr, "-", "", 1, -1, CompareMethod.Binary);

					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

				} // If lCompId > 0 Then

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Find_And_Format_Phone_Number_For_NUMVerify_Error", excep.Message);

				strPhoneNbr = "";
			}

		} // Find_And_Format_Phone_Number_For_NUMVerify

		internal static void EnterStandardJournalNotes(string strSubject, string strDesc, int lACId, int lCompId, int lContactId, int lYachtId)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			System.DateTime dtDate = DateTime.FromOADate(0);

			try
			{

				strQuery1 = "SELECT * FROM Journal WHERE (journ_id = -1)";

				rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);

				dtDate = DateTime.Parse(modAdminCommon.GetSystemDateTime());

				rstRec1.AddNew();

				rstRec1["journ_date"] = DateTime.Parse(dtDate.ToString("MM/dd/yyyy"));
				rstRec1["journ_subcategory_code"] = "RN";
				rstRec1["journ_entry_date"] = DateTime.Parse(dtDate.ToString("MM/dd/yyyy"));
				rstRec1["journ_entry_time"] = DateTime.Parse(dtDate.ToString("HH:mm:ss"));
				rstRec1["journ_subject"] = strSubject;
				rstRec1["journ_description"] = strDesc;
				rstRec1["journ_ac_id"] = lACId;
				rstRec1["journ_contact_id"] = lContactId;
				rstRec1["journ_comp_id"] = lCompId;
				rstRec1["journ_user_id"] = modAdminCommon.gbl_User_ID;
				rstRec1["journ_account_id"] = modAdminCommon.gbl_Account_ID;
				rstRec1["journ_status"] = "A";
				rstRec1["journ_yacht_id"] = lYachtId;

				rstRec1.UpdateBatch();

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("EnterStandardJournalNotes_Error", excep.Message);
			}

		} // EnterStandardJournalNotes

		internal static void ReturnSunSatDateRange(System.DateTime dtDate, ref System.DateTime dtSunday, ref System.DateTime dtSaturday, ref System.DateTime dtMonday)
		{

			// Monday - Sunday


			switch(dtDate.ToString("ddd"))
			{
				case "Sun" : 
					 
					dtMonday = dtDate.AddDays(-6); 
					dtSaturday = dtDate.AddDays(-5); 
					dtSunday = dtDate; 
					 
					break;
				case "Mon" : 
					 
					dtMonday = dtDate; 
					dtSaturday = dtDate.AddDays(5); 
					dtSunday = dtDate.AddDays(6); 
					 
					break;
				case "Tue" : 
					 
					dtMonday = dtDate.AddDays(-1); 
					dtSaturday = dtDate.AddDays(4); 
					dtSunday = dtDate.AddDays(5); 
					 
					break;
				case "Wed" : 
					 
					dtMonday = dtDate.AddDays(-2); 
					dtSaturday = dtDate.AddDays(3); 
					dtSunday = dtDate.AddDays(4); 
					 
					break;
				case "Thu" : 
					 
					dtMonday = dtDate.AddDays(-3); 
					dtSaturday = dtDate.AddDays(2); 
					dtSunday = dtDate.AddDays(3); 
					 
					break;
				case "Fri" : 
					 
					dtMonday = dtDate.AddDays(-4); 
					dtSaturday = dtDate.AddDays(1); 
					dtSunday = dtDate.AddDays(2); 
					 
					break;
				case "Sat" : 
					 
					dtMonday = dtDate.AddDays(-5); 
					dtSaturday = dtDate; 
					dtSunday = dtDate.AddDays(1); 
					 
					break;
			} // Case

		} // ReturnSunSatDateRange

		internal static bool Open_Client_Side_Connection(ref DbConnection cntConn)
		{

			bool result = false;
			string strConn = "";
			int lCommandTimeOut = 0;

			try
			{


				strConn = $"Provider=SQLNCLI10;" +
				          $"Data Source={frm_Main_Menu.DefInstance.txt_ip_address.Text};" +
				          $"Initial Catalog={frm_Main_Menu.DefInstance.txt_database_name.Text};" +
				          $"User Id={frm_Main_Menu.DefInstance.txt_db_login.Text};" +
				          $"Password={frm_Main_Menu.DefInstance.txt_db_password.Text};";

				if (cntConn == null)
				{
					cntConn = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateConnection();
				}
				else
				{
					if (cntConn.State == ConnectionState.Open)
					{
						UpgradeHelpers.DB.TransactionManager.DeEnlist(cntConn);
						cntConn.Close();
					}
				}

				lCommandTimeOut = UpgradeHelpers.DB.DbConnectionHelper.GetCommandTimeOut(modAdminCommon.LOCAL_ADO_DB);
				UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(cntConn, lCommandTimeOut * 4);
				cntConn.ConnectionString = strConn;
				//UPGRADE_ISSUE: (2064) ADODB.Connection property cntConn.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				cntConn.setCursorLocation(CursorLocationEnum.adUseClient);
				//UPGRADE_TODO: (7010) The connection string must be verified to fullfill the .NET data provider connection string requirements. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-7010
				cntConn.Open();


				return true;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Open_Client_Side_Connection_Error", $"{excep.Message} CString: {strConn}");

				result = false;
			}
			return result;
		}

		internal static void SetProgressBar(ProgressBar pBar, int lMax, int lMin, int lValue)
		{

			if (lMax < 1)
			{
				lMax = 1;
			}

			pBar.Maximum = lMax;

			if (lMin > lMax)
			{
				lMin = lMax;
			}
			if (lMin > 0)
			{
				lMin = 0;
			}
			pBar.Minimum = lMin;

			if (lValue > lMax)
			{
				lValue = lMax;
			}
			if (lValue < lMin)
			{
				lValue = lMin;
			}

			pBar.Value = lValue;

			pBar.Visible = true;

			Application.DoEvents();

		} // SetProgressBar

		internal static void IncProgressBar(ProgressBar pBar, int lInc = 1)
		{

			if (pBar.Value + lInc < pBar.Maximum)
			{
				pBar.Value = Convert.ToInt32(pBar.Value + lInc);
			}
			else
			{
				pBar.Value = Convert.ToInt32(pBar.Maximum);
			}

			Application.DoEvents();

		} // SetProgressBar

		internal static void SetProgressBarMax(ProgressBar pBar)
		{

			pBar.Value = Convert.ToInt32(pBar.Maximum);

			Application.DoEvents();

		} // SetProgressBar

		internal static string ConvertByteArrayToString(byte[] bArray)
		{


			StringBuilder strResults = new StringBuilder();

			if (bArray.GetUpperBound(0) > 0)
			{
				foreach (byte bArray_item in bArray)
				{
					strResults.Append(Strings.Chr(bArray_item).ToString());
				}
			}

			return strResults.ToString();

		} // ConvertByteArrayToString

		internal static string Return_NumVerify_PhoneNbr(int lCompId, int lContactId, string strPhoneNbr, ref bool bResults)
		{

			string result = "";
			string strHTML1 = "";
			string strURLTemplate = "";
			string strURL1 = "";
			byte[] baBuffer = null;
			byte iCnt1 = 0;

			string strResults = "";

			try
			{

				strResults = "";
				bResults = false;

				strPhoneNbr = strPhoneNbr.Trim();

				if (strPhoneNbr != "")
				{

					if (lCompId > 0)
					{

						strURLTemplate = DLookUp("aconfig_numverify_url", "Application_Configuration");

						Find_And_Format_Phone_Number_For_NUMVerify(lCompId, lContactId, ref strPhoneNbr);

						if (strPhoneNbr != "")
						{

							strURL1 = StringsHelper.Replace(strURLTemplate, "{PHONENBR}", strPhoneNbr, 1, -1, CompareMethod.Binary);

							//UPGRADE_WARNING: (1068) mdi_ResearchAssistant.Inet1.OpenURL() of type Variant is being forced to Array(byte). More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
							//baBuffer = (byte[]) mdi_ResearchAssistant.DefInstance.Inet1.OpenURL(strURL1, (int) InetCtlsObjects.DataTypeConstants.icByteArray); //gap-note this line must be reviewed during blazor stabilization
							strHTML1 = ConvertByteArrayToString(baBuffer);

							bResults = false;
							if (StringsHelper.Replace(strHTML1, "\"", "", 1, -1, CompareMethod.Binary).IndexOf("valid:true,") >= 0)
							{
								bResults = true;
							}

							strResults = strHTML1;

						} // If strPhoneNbr <> "" Then

					} // If lCompId > 0 Then

				} // If strPhoneNbr <> "" Then


				return strResults;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Return_NumVerify_PhoneNbr_Error", excep.Message);

				result = "";
			}
			return result;
		} // Return_NumVerify_PhoneNbr

		internal static void Return_Contact_Name_And_Id_From_ListBox(ListBox lstBox, ref string strCONTACTNAME, ref int lContactId)
		{

			int iPos1 = 0;
			int iPos2 = 0;

			strCONTACTNAME = "";
			lContactId = 0;

			string strData = "";
			string strName = "";
			string strID = "0";

			if (ListBoxHelper.GetSelectedIndex(lstBox) > -1)
			{

				strData = lstBox.GetListItem(0); // First Line Should Be Name

				iPos1 = (strData.IndexOf("(ID=") + 1);
				if (iPos1 > 0)
				{
					strID = strData.Substring(Math.Min(iPos1 - 1, strData.Length));
					strID = StringsHelper.Replace(strID, "(ID=", "", 1, -1, CompareMethod.Binary);
					strID = StringsHelper.Replace(strID, ")", "", 1, -1, CompareMethod.Binary);
					if (Information.IsNumeric(strID))
					{
						lContactId = Convert.ToInt32(Double.Parse(strID));
					}
					strData = strData.Substring(0, Math.Min(iPos1 - 1, strData.Length)).Trim();
				} // If iPos1 > 0 Then

				iPos1 = (strData.IndexOf(',') + 1);
				if (iPos1 > 0)
				{
					strName = strData.Substring(0, Math.Min(iPos1 - 1, strData.Length)).Trim();
				}
				else
				{
					strName = strData.Trim();
				}

				strCONTACTNAME = strName;

			} // If lstBox.ListIndex > -1 Then

		} // Return_Contact_Name_And_Id_From_ListBox

		internal static string Return_Company_Marketing_Rep_Name(int lCompId, int lJournId, string strMktRep)
		{

			string result = "";
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strResults = "";

			try
			{

				strResults = "";

				if (lCompId > 0)
				{

					if (strMktRep == "")
					{
						strQuery1 = "SELECT user_first_name, user_last_name ";
						strQuery1 = $"{strQuery1}FROM [User] WITH (NOLOCK) ";
						strQuery1 = $"{strQuery1}INNER JOIN Company WITH (NOLOCK) ON comp_marketing_rep = [user_id] ";
						strQuery1 = $"{strQuery1}WHERE (comp_id = {lCompId.ToString()}) ";
						strQuery1 = $"{strQuery1}AND (comp_journ_id = {lJournId.ToString()}) ";
					}
					else
					{
						strQuery1 = "SELECT user_first_name, user_last_name ";
						strQuery1 = $"{strQuery1}FROM [User] WITH (NOLOCK) ";
						strQuery1 = $"{strQuery1}WHERE ([user_id] = '{strMktRep}') ";
					}

					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!rstRec1.BOF && !rstRec1.EOF)
					{
						strResults = $"{($"{Convert.ToString(rstRec1["user_first_name"])} ").Trim()} {($"{Convert.ToString(rstRec1["user_last_name"])} ").Trim()}";
					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

				} // If lCompId > 0 Then

				rstRec1 = null;


				return strResults;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Return_Company_Marketing_Rep_Name_Error", excep.Message);

				result = "";
			}
			return result;
		} // Return_Company_Marketing_Rep_Name

		internal static string INet_HTTPGetBody(string strURL)
		{

			string result = "";
			string strResults = "";
			int iCnt1 = 0;
			int iPos1 = 0;
			byte[] baBuffer = null;

			try
			{

				strResults = "";

				mdi_ResearchAssistant.DefInstance.Inet1.RequestTimeout = 30000;
				//UPGRADE_WARNING: (1068) mdi_ResearchAssistant.Inet1.OpenURL() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
				//strResults = Convert.ToString(mdi_ResearchAssistant.DefInstance.Inet1.OpenURL(strURL, (int) InetCtlsObjects.DataTypeConstants.icString)); // icString // mdi_ResearchAssistant // gap-note this line must be reviewed during blazor stabilization


				return strResults;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("INet_HTTPGetBody_Error", excep.Message);

				result = "";
			}
			return result;
		} // INet_HTTPGetBody

		internal static void JETNETAPI_GetSecurityToken(string strEMail, string strPassword, ref string strToken, ref string strHeader)
		{

			// Tab #14

			string strSubId = "";

			string strURL = "";
			string strParam = "";
			int lCnt1 = 0;

			try
			{

				strToken = "";
				strHeader = "";
				lCnt1 = 0;

				if (strEMail != "" && strPassword != "")
				{

					strURL = "https://www.jetnetconnect.com/JetnetDataService.svc/getSecurityToken";
					strParam = $"?username={strEMail}&password={strPassword}";

					//- https://www.jetnetconnect.com/JetnetDataService.svc/getSecurityToken?username={email}&password={password}

					strToken = INet_HTTPGetBody($"{strURL}{strParam}");
					if (strToken == "")
					{
						// Try One More Time
						strToken = INet_HTTPGetBody($"{strURL}{strParam}");
					}

					strHeader = $"{{'securityToken': {strToken}}}";
					strToken = StringsHelper.Replace(strToken, "\"", "", 1, -1, CompareMethod.Binary);
					strHeader = StringsHelper.Replace(strHeader, "'", "\"", 1, -1, CompareMethod.Binary);

					if (strToken == "INVALID ACCOUNT")
					{
						strToken = "";
						strHeader = "";
					}

				} // If strEMail <> "" And strPassword <> "" Then
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("JETNETAPI_GetSecurityToken_Error", excep.Message);
			}

		} // cmdGetJETNETAPISecurityToken_Click
		internal static string RemoveAllMiscChars(string strTemp)
		{
			string result = "";
			StringBuilder strResults = new StringBuilder();
			string strWork = strTemp;
			int iTest = 0;


			if (Strings.Len(strTemp) > 0)
			{
				strWork = strTemp;
				int tempForEndVar = Strings.Len(strTemp);
				for (int iZ1 = 1; iZ1 <= tempForEndVar; iZ1++)
				{

					iTest = Strings.Asc(strWork.Substring(Math.Min(iZ1 - 1, strWork.Length), Math.Min(1, Math.Max(0, strWork.Length - (iZ1 - 1))))[0]);

					if ((iTest >= 32) && (iTest <= 126))
					{
						strResults.Append(strWork.Substring(Math.Min(iZ1 - 1, strWork.Length), Math.Min(1, Math.Max(0, strWork.Length - (iZ1 - 1)))));
					}

					//   End If

				}
			}
			else
			{
				strResults = new StringBuilder("");
			} // Len(strTemp) > 0

			return strResults.ToString();

		}

		internal static string RemoveAllInvisibleChars(string strTemp)
		{
			string result = "";
			StringBuilder strResults = new StringBuilder();
			string strWork = strTemp;
			int iTest = 0;


			// special case to replace carriage return/line feed - 6/20/23
			strTemp = StringsHelper.Replace(strTemp, $"{"\r"}{"\n"}", ", ", 1, -1, CompareMethod.Binary);


			if (Strings.Len(strTemp) > 0)
			{
				strWork = strTemp;
				int tempForEndVar = Strings.Len(strTemp);
				for (int iZ1 = 1; iZ1 <= tempForEndVar; iZ1++)
				{

					iTest = Strings.Asc(strWork.Substring(Math.Min(iZ1 - 1, strWork.Length), Math.Min(1, Math.Max(0, strWork.Length - (iZ1 - 1))))[0]);

					// 31 is the last invisible character
					if (iTest > 31)
					{
						strResults.Append(strWork.Substring(Math.Min(iZ1 - 1, strWork.Length), Math.Min(1, Math.Max(0, strWork.Length - (iZ1 - 1)))));
					}
					else if ((iTest == 9) || (iTest == 10) || (iTest == 13))
					{  // added these characters replaced with spaces - MSW - 6/9/23
						strResults.Append(" ");
					}

				}
			}
			else
			{
				strResults = new StringBuilder("");
			} // Len(strTemp) > 0

			return strResults.ToString();

		}

		internal static string RemoveAllSpecificCharacters(string strTemp)
		{
			string result = "";
			StringBuilder strResults = new StringBuilder();
			string strWork = strTemp;
			int iTest = 0;


			if (Strings.Len(strTemp) > 0)
			{
				strWork = strTemp;
				int tempForEndVar = Strings.Len(strTemp);
				for (int iZ1 = 1; iZ1 <= tempForEndVar; iZ1++)
				{

					iTest = Strings.Asc(strWork.Substring(Math.Min(iZ1 - 1, strWork.Length), Math.Min(1, Math.Max(0, strWork.Length - (iZ1 - 1))))[0]);

					// 31 is the last invisible character
					if (iTest == 149)
					{
						strResults.Append("");
					}
					else
					{
						strResults.Append(strWork.Substring(Math.Min(iZ1 - 1, strWork.Length), Math.Min(1, Math.Max(0, strWork.Length - (iZ1 - 1)))));
					}

				}

			}
			else
			{
				strResults = new StringBuilder("");
			} // Len(strTemp) > 0

			return strResults.ToString();

		}

		internal static string RemoveNonNumbers(string strTemp)
		{
			string result = "";
			StringBuilder strResults = new StringBuilder();
			string strWork = strTemp;
			int iTest = 0;


			if (Strings.Len(strTemp) > 0)
			{
				strWork = strTemp;
				int tempForEndVar = Strings.Len(strTemp);
				for (int iZ1 = 1; iZ1 <= tempForEndVar; iZ1++)
				{

					iTest = Strings.Asc(strWork.Substring(Math.Min(iZ1 - 1, strWork.Length), Math.Min(1, Math.Max(0, strWork.Length - (iZ1 - 1))))[0]);

					if ((iTest >= 48) && (iTest <= 57))
					{
						strResults.Append(strWork.Substring(Math.Min(iZ1 - 1, strWork.Length), Math.Min(1, Math.Max(0, strWork.Length - (iZ1 - 1)))));
					}

					//   End If

				}
			}
			else
			{
				strResults = new StringBuilder("");
			} // Len(strTemp) > 0

			return strResults.ToString();

		}

		internal static bool Is_Phone_Number_Field_Visible_Non_Numeric(string strTemp)
		{
			bool result = false;
			string strResults = "";
			string strWork = strTemp;
			int iTest = 0;


			if (Strings.Len(strTemp) > 0)
			{
				strWork = strTemp;
				int tempForEndVar = Strings.Len(strTemp);
				for (int iZ1 = 1; iZ1 <= tempForEndVar; iZ1++)
				{

					iTest = Strings.Asc(strWork.Substring(Math.Min(iZ1 - 1, strWork.Length), Math.Min(1, Math.Max(0, strWork.Length - (iZ1 - 1))))[0]);

					if (iTest <= 32)
					{
						// everything , invisible - is ok
					}
					else if ((iTest >= 33) && (iTest <= 47))
					{ 
						// visible, non numeric, not ok
						result = true;
					}
					else if ((iTest >= 48) && (iTest <= 57))
					{ 
						// is numeric, is ok
					}
					else if ((iTest >= 58))
					{ 
						// then visible and non numeric- not ok
						result = true;
					}

				}
			}
			else
			{
				strResults = "";
			}


			return result;
		}



		internal static string Return_User_Report_Time_Range(string strUserId, string strReportName)
		{


			string strResults = "";

			if (strUserId != "" && strReportName != "")
			{

				strResults = DLookUp("ur_time_range", "User_Reports", $"ur_user_id = ('{strUserId}') AND (ur_report_name = '{strReportName}')");

			} // If strUserId <> "" And strReportName <> "" Then

			return strResults;

		} // Return_User_Report_Time_Range
	}
}