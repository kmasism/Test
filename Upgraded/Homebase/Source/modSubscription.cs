using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Text;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Gui.Controls;
using UpgradeHelpers.Helpers;
using UpgradeStubs;

namespace JETNET_Homebase
{
	internal static class modSubscription
	{


		public const string MBABase64Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";

		public const int ProductBusinessAC = 0;
		public const int ProductHelicopters = 1;
		public const int ProductABIListing = 3;
		public const int ProductCommercial = 4;
		public const int ProductAerodex = 5;
		public const int ProductStarReports = 6;
		public const int ProductSPI = 7;
		public const int ProductMarketing = 8;
		public const int ShareByCompId = 9;
		public const int ShareByParentId = 10;
		public const int ProductHistory = 11;
		public const int ProductMPM = 12;

		static readonly public CheckState iCHKLOGINACTIVE = CheckState.Unchecked;
		static readonly public CheckState iCHKLOGINDEMO = CheckState.Checked;
		static readonly public CheckState iCHKLOGINEXPORT = CheckState.Indeterminate;
		//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
		public const CheckState iCHKLOGINLOCALNOTES = (CheckState) 3;
		//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
		public const CheckState iCHKLOGINPROJECTS = (CheckState) 4;
		//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
		public const CheckState iCHKLOGINEMAILREQUEST = (CheckState) 5;
		//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
		public const CheckState iCHKLOGINEVENTREQUEST = (CheckState) 6;
		//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
		public const CheckState iCHKLOGINTEXTMSG = (CheckState) 7;
		//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
		public const CheckState iCHKLOGINBYPASSACTIVEX = (CheckState) 8;
		//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
		public const CheckState iCHKLOGINVALUES = (CheckState) 9;
		//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
		public const CheckState iCHKLOGINMPM = (CheckState) 10;

		[Serializable]
		public struct TextMsg_Customer_Record //gap-note Struct changed to class. VBUC feature.
        {

			public int lCompId;
			public int lContactId;
			public int lSubId;
			public string strLogin;
			public int lSeqNbr;
			public string strSearchModelId;
			public System.DateTime dtLastProcessDate;
			public bool bDomestic;
			public string strCellNumber;
			public string strCellCarrierCountry;
			public string strCellCarrierService;
			public string strTextMessage;

			public static TextMsg_Customer_Record CreateInstance()
			{
				TextMsg_Customer_Record result = new TextMsg_Customer_Record();
				result.strLogin = String.Empty;
				result.strSearchModelId = String.Empty;
				result.strCellNumber = String.Empty;
				result.strCellCarrierCountry = String.Empty;
				result.strCellCarrierService = String.Empty;
				result.strTextMessage = String.Empty;
				return result;
			}
		} // TextMsg_Customer_Record

		public static int Entered_Subscription_ID = 0;
		public static int Entered_Contact_ID = 0;
		public static int Entered_Company_ID = 0;
		public static int gbl_SubID = 0;
		// 09/10/2004 - By David D. Cruger; Added this global variable to track Subscription service Changes
		public static string gstrService = "";

		internal static void search_off()
		{

			frm_Subscription.DefInstance.pnl_Please_Wait.Visible = false;
			Cursor.Current = CursorHelper.CursorDefault;
		}

		internal static void search_on(string strMsg, string strStatus = "")
		{

			Cursor.Current = Cursors.WaitCursor;
			//UPGRADE_ISSUE: (2064) Threed.SSPanel property pnl_Please_Wait.Caption was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			frm_Subscription.DefInstance.pnl_Please_Wait.setCaption(strMsg);
			frm_Subscription.DefInstance.lblPleaseWaitStatus[0].Text = strStatus;
			frm_Subscription.DefInstance.pnl_Please_Wait.Visible = true;
			frm_Subscription.DefInstance.pnl_Please_Wait.BringToFront();

		}

		internal static void CloseRemoteDatabase()
		{



			if (frm_Subscription.DefInstance.REMOTE_ADO_DB != null)
			{
				if (frm_Subscription.DefInstance.REMOTE_ADO_DB.State == ConnectionState.Open)
				{
					ErrorHandlingHelper.ResumeNext(
						() => {UpgradeHelpers.DB.TransactionManager.DeEnlist(frm_Subscription.DefInstance.REMOTE_ADO_DB);}, 
						() => {frm_Subscription.DefInstance.REMOTE_ADO_DB.Close();});
				}
			}
			frm_Subscription.DefInstance.REMOTE_ADO_DB = null;

			frm_Subscription.DefInstance.AlreadyOpen = false;
			 // frm_Subscription

		}

		internal static bool OpenRemoteDatabase()
		{

			bool result = false;
			try
			{

				bool bResults = false;
				string IP_Address = "";
				string DB_Name = "";
				string DB_User_ID = "";
				string DB_Password = "";
				string strConnect = "";
				int iErrCnt = 0; // Try 3 Times Before Stopping

				bResults = false;


				if (!frm_Subscription.DefInstance.AlreadyOpen)
				{

					if (modAdminCommon.gbl_Live_flag)
					{
						DB_Name = "jetnet_ra";
					}
					else
					{
						DB_Name = "jetnet_ra_test";
					}

					// 04/23/2008 - By David D. Cruger;
					// These are now all Application Configuration Items
					IP_Address = modCommon.DLookUp("aconfig_evo_sql_server", "Application_Configuration");
					DB_User_ID = modCommon.DLookUp("aconfig_evo_sql_user", "Application_Configuration");
					DB_Password = modCommon.DLookUp("aconfig_evo_sql_password", "Application_Configuration");

					strConnect = $"Provider=SQLNCLI10;" +
					             $"Data Source={IP_Address};" +
					             $"Initial Catalog={DB_Name};" +
					             $"User Id={DB_User_ID};" +
					             $"Password={DB_Password};";

					frm_Subscription.DefInstance.REMOTE_ADO_DB = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateConnection();

					//UPGRADE_ISSUE: (2070) Constant adModeShareDenyNone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2070
					//UPGRADE_ISSUE: (2064) ADODB.Connection property REMOTE_ADO_DB.Mode was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					frm_Subscription.DefInstance.REMOTE_ADO_DB.setMode(UpgradeStubs.System_Data_CommandType.getadModeShareDenyNone());
					//UPGRADE_ISSUE: (2064) ADODB.Connection property REMOTE_ADO_DB.ConnectionTimeout was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					frm_Subscription.DefInstance.REMOTE_ADO_DB.setConnectionTimeout(30); // Seconds

					iErrCnt = 0;
					bResults = false;

					Exception ex = null;
					//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
					do 
					{
						ErrorHandlingHelper.ResumeNext(out ex, 
							() => {iErrCnt++;}, 
								//UPGRADE_TODO: (7010) The connection string must be verified to fullfill the .NET data provider connection string requirements. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-7010
							() => {frm_Subscription.DefInstance.REMOTE_ADO_DB.ConnectionString = strConnect;}, 
							() => {frm_Subscription.DefInstance.REMOTE_ADO_DB.Open();});
					}
					while(!ErrorHandlingHelper.ResumeNextExpr<bool>(() => Information.Err().Number == 0 || iErrCnt >= 3));
					ErrorHandlingHelper.ResumeNext(out ex);

					if (ex == null)
					{
						try
						{
							UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(frm_Subscription.DefInstance.REMOTE_ADO_DB, 120);
						}
						catch
						{
						}
						bResults = true;
						frm_Subscription.DefInstance.AlreadyOpen = true;
					}
					else
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
				else
				{
					bResults = true;
				} // If .AlreadyOpen = False Then
				 // frm_Subscription


				return bResults;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"OpenRemoteDatabase_Error: {excep.Message}");

				result = false;
			}
			return result;
		} // OpenRemoteDatabase

		internal static string FormatContactName(string strSirName, string strFName, string strMInit, string strLName, string strSuffix)
		{


			string strResults = "";

			if (strSirName != "")
			{
				strResults = $"{strResults}{strSirName} ";
			}

			if (strFName != "")
			{
				strResults = $"{strResults}{strFName} ";
			}

			if (strMInit != "")
			{
				strResults = $"{strResults}{strMInit}. ";
			}

			if (strLName != "")
			{
				strResults = $"{strResults}{strLName} ";
			}

			if (strSuffix != "")
			{
				strResults = $"{strResults.Trim()}, {strSuffix}";
			}

			return strResults;

		} // FormatContactName

		internal static string URLEncoding(string strText)
		{

			string strChar1 = "";
			string strChar2 = "";

			StringBuilder strResults = new StringBuilder();
			int iLen1 = Strings.Len(strText);
			if (iLen1 > 0)
			{

				int tempForEndVar = iLen1;
				for (int iCnt1 = 1; iCnt1 <= tempForEndVar; iCnt1++)
				{

					strChar1 = strText.Substring(Math.Min(iCnt1 - 1, strText.Length), Math.Min(1, Math.Max(0, strText.Length - (iCnt1 - 1)))); //  Single Char
					strChar2 = strChar1; //  Equals Char1

					//If strChar1 = Chr(32) Then strChar2 = "%20"   '    - Space
					if (strChar1 == "\"")
					{
						strChar2 = "%22";
					} //  " - Double Quote
					if (strChar1 == Strings.Chr(35).ToString())
					{
						strChar2 = "%23";
					} //  # - Pound Sign
					if (strChar1 == Strings.Chr(36).ToString())
					{
						strChar2 = "%24";
					} //  $ - Dollar Sign
					if (strChar1 == Strings.Chr(37).ToString())
					{
						strChar2 = "%25";
					} //  % - Percentage
					if (strChar1 == Strings.Chr(38).ToString())
					{
						strChar2 = "%26";
					} //  & - Ampersand
					if (strChar1 == Strings.Chr(43).ToString())
					{
						strChar2 = "%2B";
					} //  + - Plus Sign
					if (strChar1 == Strings.Chr(44).ToString())
					{
						strChar2 = "%2C";
					} //  , - Comma
					if (strChar1 == Strings.Chr(47).ToString())
					{
						strChar2 = "%2F";
					} //  / - Forward Slash

					if (strChar1 == Strings.Chr(58).ToString())
					{
						strChar2 = "%3A";
					} //  : - Colon
					if (strChar1 == Strings.Chr(59).ToString())
					{
						strChar2 = "%3B";
					} //  ; - Semi-Colon
					if (strChar1 == Strings.Chr(60).ToString())
					{
						strChar2 = "%3C";
					} //  < - Less Than Sign
					if (strChar1 == Strings.Chr(61).ToString())
					{
						strChar2 = "%3D";
					} //  = - Equal Sign
					if (strChar1 == Strings.Chr(62).ToString())
					{
						strChar2 = "%3E";
					} //  > - Greater Than Sign
					if (strChar1 == Strings.Chr(63).ToString())
					{
						strChar2 = "%3F";
					} //  ? - Question Mark
					if (strChar1 == Strings.Chr(64).ToString())
					{
						strChar2 = "%40";
					} //  @ - AT Sign

					if (strChar1 == Strings.Chr(91).ToString())
					{
						strChar2 = "%5B";
					} //  [ - Left Bracket
					if (strChar1 == Strings.Chr(92).ToString())
					{
						strChar2 = "%5C";
					} //  \ - Back Slash
					if (strChar1 == Strings.Chr(93).ToString())
					{
						strChar2 = "%5D";
					} //  ] - Right Bracket
					if (strChar1 == Strings.Chr(94).ToString())
					{
						strChar2 = "%5E";
					} //  ^ - Accent Sign
					if (strChar1 == Strings.Chr(96).ToString())
					{
						strChar2 = "%60";
					} //  ' - Single Quote

					if (strChar1 == Strings.Chr(123).ToString())
					{
						strChar2 = "%7B";
					} //  { - Left Curly Brace
					if (strChar1 == Strings.Chr(124).ToString())
					{
						strChar2 = "%7C";
					} //  | - Pipe Char
					if (strChar1 == Strings.Chr(125).ToString())
					{
						strChar2 = "%7D";
					} //  } - Right Curly Brace

					strResults.Append(strChar2);

				}

			} // If iLen1 > 0 Then

			return strResults.ToString();

		} // URLEncoding

		internal static string Base64_Encode(string strIn)
		{

			int C1 = 0;
			int C2 = 0;
			int c3 = 0;
			int w1 = 0;
			int w2 = 0;
			int w3 = 0;
			int w4 = 0;

			StringBuilder strOut = new StringBuilder();

			int tempForEndVar = Strings.Len(strIn);
			for (int n = 1; n <= tempForEndVar; n += 3)
			{

				C1 = Strings.Asc(strIn.Substring(Math.Min(n - 1, strIn.Length), Math.Min(1, Math.Max(0, strIn.Length - (n - 1))))[0]);
				C2 = Strings.Asc($"{strIn.Substring(Math.Min(n, strIn.Length), Math.Min(1, Math.Max(0, strIn.Length - n)))}{Strings.Chr(0).ToString()}"[0]);
				c3 = Strings.Asc($"{strIn.Substring(Math.Min(n + 1, strIn.Length), Math.Min(1, Math.Max(0, strIn.Length - (n + 1))))}{Strings.Chr(0).ToString()}"[0]);

				w1 = Convert.ToInt32(Math.Floor(C1 / 4d));
				w2 = Convert.ToInt32((C1 & 3) * 16 + Math.Floor(C2 / 16d));

				if (Strings.Len(strIn) >= n + 1)
				{
					w3 = Convert.ToInt32((C2 & 15) * 4 + Math.Floor(c3 / 64d));
				}
				else
				{
					w3 = -1;
				}

				if (Strings.Len(strIn) >= n + 2)
				{
					w4 = c3 & 63;
				}
				else
				{
					w4 = -1;
				}

				strOut.Append($"{MimeEncode(w1)}{MimeEncode(w2)}{MimeEncode(w3)}{MimeEncode(w4)}");

			} // n

			return strOut.ToString();

		} // Base64_Encode

		// ===================================================================

		internal static string MimeEncode(int intIn)
		{

			if (intIn >= 0)
			{
				return MBABase64Chars.Substring(Math.Min(intIn, MBABase64Chars.Length), Math.Min(1, Math.Max(0, MBABase64Chars.Length - intIn)));
			}
			else
			{
				return "";
			}

		} // MimeEncode

		internal static string Base64_Decode(string strIn)
		{

			int w1 = 0;
			int w2 = 0;
			int w3 = 0;
			int w4 = 0;

			StringBuilder strOut = new StringBuilder();

			int tempForEndVar = Strings.Len(strIn);
			for (int n = 1; n <= tempForEndVar; n += 4)
			{

				w1 = MimeDecode(strIn.Substring(Math.Min(n - 1, strIn.Length), Math.Min(1, Math.Max(0, strIn.Length - (n - 1)))));
				w2 = MimeDecode(strIn.Substring(Math.Min(n, strIn.Length), Math.Min(1, Math.Max(0, strIn.Length - n))));
				w3 = MimeDecode(strIn.Substring(Math.Min(n + 1, strIn.Length), Math.Min(1, Math.Max(0, strIn.Length - (n + 1)))));
				w4 = MimeDecode(strIn.Substring(Math.Min(n + 2, strIn.Length), Math.Min(1, Math.Max(0, strIn.Length - (n + 2)))));

				if (w2 >= 0)
				{
					strOut.Append(Strings.Chr((Convert.ToInt32(w1 * 4 + Math.Floor(w2 / 16d))) & 255).ToString());
				}

				if (w3 >= 0)
				{
					strOut.Append(Strings.Chr((Convert.ToInt32(w2 * 16 + Math.Floor(w3 / 4d))) & 255).ToString());
				}

				if (w4 >= 0)
				{
					strOut.Append(Strings.Chr((w3 * 64 + w4) & 255).ToString());
				}

			} // n

			return strOut.ToString();

		} // Base64_Decode

		// ===================================================================

		internal static int MimeDecode(string strIn)
		{

			if (Strings.Len(strIn) == 0)
			{
				return -1;
			}
			else
			{
				return MBABase64Chars.IndexOf(strIn);
			}

		} // MimeDecode

		internal static string SQL_Base64_Encode(string strText)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strResults = strText;
			if (strText.Trim() != "")
			{

				strQuery1 = $"SELECT dbo.ENCODE_BASE64('{strText}') As Base64Token ";

				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{
					strResults = ($"{Convert.ToString(rstRec1["Base64Token"])} ").Trim();
				} // If rstRec1.BOF = False And rstRec1.EOF = False Then

				rstRec1.Close();

			} // If Trim(strText) <> "" Then

			rstRec1 = null;

			return strResults;

		} // SQL_Base64_Encode

		internal static string SQL_Base64_Decode(string strToken)
		{

			string result = "";
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strResults = result;
			if (result.Trim() != "")
			{

				strQuery1 = $"SELECT dbo.DECODE_BASE64('{result}') As Base64Text ";

				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{
					strResults = ($"{Convert.ToString(rstRec1["Base64Text"])} ").Trim();
				} // If rstRec1.BOF = False And rstRec1.EOF = False Then

				rstRec1.Close();

			} // If Trim(SQL_Base64_Decode) <> "" Then

			rstRec1 = null;

			return strResults;

		} // SQL_Base64_Decode


		internal static string Return_Last_SMS_Text_Message_Sent(DbConnection cntConn, int lCompId, int lSubId, string strLogin, int lSeqNbr, string strCellNbr, int lTop)
		{

			string result = "";
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			StringBuilder strResults = new StringBuilder();

			try
			{

				if (lTop <= 0)
				{
					lTop = 5;
				}

				strResults = new StringBuilder($"<table border='1' cellpadding='0' cellspacing='0' width='700'>{Environment.NewLine}");
				strResults.Append($"<tr>{Environment.NewLine}");
				strResults.Append($"<th colspan='4'>{Environment.NewLine}");
				strResults.Append($"LAST {lTop.ToString()} SMS TEXT MESSAGE(S) SENT TO: {strCellNbr}");
				strResults.Append($"</th>{Environment.NewLine}");
				strResults.Append($"</tr>{Environment.NewLine}");

				if (lCompId > 0 && lSubId > 0 && strLogin != "" && lSeqNbr >= 0 && strCellNbr != "")
				{

					strQuery1 = $"SELECT TOP {lTop.ToString()} * FROM SMS_Text_Message_Queue WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1}WHERE (smst_cell_number = '{strCellNbr}') ORDER BY smst_id DESC ";

					rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						strResults.Append($"<tr>{Environment.NewLine}");
						strResults.Append($"<th>SMSId</th>{Environment.NewLine}");
						strResults.Append($"<th>Entry Date</th>{Environment.NewLine}");
						strResults.Append($"<th>Status</th>{Environment.NewLine}");
						strResults.Append($"<th>Message</th>{Environment.NewLine}");
						strResults.Append($"<tr>{Environment.NewLine}{Environment.NewLine}");

						do 
						{
							strResults.Append($"<tr>{Environment.NewLine}");
							strResults.Append($"<td>{Convert.ToString(rstRec1["smst_id"])}</td>{Environment.NewLine}");
							strResults.Append($"<td nowrap>{StringsHelper.Format(rstRec1["smst_entry_date"], "mm/dd/yyyy hh:mm:ss AM/PM")}</td>{Environment.NewLine}");
							strResults.Append($"<td>{($"{Convert.ToString(rstRec1["smst_status"])} ").Trim()}&nbsp;</td>{Environment.NewLine}");
							strResults.Append($"<td>{($"{Convert.ToString(rstRec1["smst_message"])} ").Trim()}&nbsp;</td>{Environment.NewLine}");
							strResults.Append($"<tr>{Environment.NewLine}{Environment.NewLine}");
							rstRec1.MoveNext();
						}
						while(!rstRec1.EOF);

					}
					else
					{
						strResults.Append($"<tr><td align='left' colspan='4'>Could Not Find Any Text Messages Sent</td></tr>{Environment.NewLine}{Environment.NewLine}");
					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

				}
				else
				{
					strResults.Append($"<tr><td colspan='4'><H1>Report Parameters Invalid</H1></td></tr>{Environment.NewLine}");
				} // If lCompId > 0 And lSubId > 0 And strLogin <> "" And lSeqNbr >= 0 And strCellNBr <> "" Then

				strResults.Append($"</table>{Environment.NewLine}");

				//--------------------------------------------------------------------------

				rstRec1 = null;


				return strResults.ToString();
			}
			catch (System.Exception excep)
			{

				MessageBox.Show($"Return_Last_SMS_Text_Message_Sent_Error: {excep.Message}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				result = "";
			}
			return result;
		} // Return_Last_SMS_Text_Message_Sent


		internal static string Return_Last_SMS_Text_Message_Received(DbConnection cntConn, int lCompId, int lSubId, string strLogin, int lSeqNbr, string strCellNbr, int lTop)
		{

			string result = "";
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			StringBuilder strResults = new StringBuilder();

			try
			{

				if (lTop <= 0)
				{
					lTop = 5;
				}

				strResults = new StringBuilder($"<table border='1' cellpadding='0' cellspacing='0' width='700'>{Environment.NewLine}");
				strResults.Append($"<tr>{Environment.NewLine}");
				strResults.Append($"<th colspan='4'>{Environment.NewLine}");
				strResults.Append($"LAST {lTop.ToString()} SMS TEXT MESSAGE(S) RECEIVED FROM: {strCellNbr}");
				strResults.Append($"</th>{Environment.NewLine}");
				strResults.Append($"</tr>{Environment.NewLine}");

				if (lCompId > 0 && lSubId > 0 && strLogin != "" && lSeqNbr >= 0 && strCellNbr != "")
				{

					strQuery1 = $"SELECT TOP {lTop.ToString()} * FROM SMS_Text_Message_Received WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1}WHERE (smsrecv_cell_number = '{strCellNbr}') ";
					strQuery1 = $"{strQuery1}ORDER BY smsrecv_id DESC ";

					rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						strResults.Append($"<tr>{Environment.NewLine}");
						strResults.Append($"<th>SMSId</th>{Environment.NewLine}");
						strResults.Append($"<th>Entry Date</th>{Environment.NewLine}");
						strResults.Append($"<th>Status</th>{Environment.NewLine}");
						strResults.Append($"<th>Message</th>{Environment.NewLine}");
						strResults.Append($"<tr>{Environment.NewLine}{Environment.NewLine}");

						do 
						{
							strResults.Append($"<tr>{Environment.NewLine}");
							strResults.Append($"<td>{Convert.ToString(rstRec1["smsrecv_id"])}</td>{Environment.NewLine}");
							strResults.Append($"<td nowrap>{StringsHelper.Format(rstRec1["smsrecv_entry_date"], "mm/dd/yyyy hh:mm:ss AM/PM")}</td>{Environment.NewLine}");
							strResults.Append($"<td>{($"{Convert.ToString(rstRec1["smsrecv_status"])} ").Trim()}&nbsp;</td>{Environment.NewLine}");
							strResults.Append($"<td>{($"{Convert.ToString(rstRec1["smsrecv_message"])} ").Trim()}&nbsp;</td>{Environment.NewLine}");
							strResults.Append($"<tr>{Environment.NewLine}{Environment.NewLine}");
							rstRec1.MoveNext();
						}
						while(!rstRec1.EOF);

					}
					else
					{
						strResults.Append($"<tr><td align='left' colspan='4'>Could Not Find Any Text Messages Recieved</td></tr>{Environment.NewLine}{Environment.NewLine}");
					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

				}
				else
				{
					strResults.Append($"<tr><td colspan='4'><H1>Report Parameters Invalid</H1></td></tr>{Environment.NewLine}");
				} // If lCompId > 0 And lSubId > 0 And strLogin <> "" And lSeqNbr >= 0 And strCellNBr <> "" Then

				strResults.Append($"</table>{Environment.NewLine}");

				//--------------------------------------------------------------------------

				rstRec1 = null;


				return strResults.ToString();
			}
			catch (System.Exception excep)
			{

				MessageBox.Show($"Return_Last_SMS_Text_Message_Received_Error: {excep.Message}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				result = "";
			}
			return result;
		} // Return_Last_SMS_Text_Message_Received

		internal static string Return_SMS_Text_Message_Link(string strCellNbr, string strMobileActiveDate)
		{


			string result = "";
			string strResults = "";

			string strLink1 = "";
			string strHRef1 = "";
			string strLink2 = "";
			string strHRef2 = "";

			try
			{

				strResults = $"<table border='1' cellpadding='0' cellspacing='0' width='750'>{Environment.NewLine}";
				strResults = $"{strResults}<tr>{Environment.NewLine}";
				strResults = $"{strResults}<th colspan='1'>{Environment.NewLine}";
				strResults = $"{strResults}EVOLUTION MOBILE SMS TEXT MESSAGE LINK FOR: {strCellNbr}";
				strResults = $"{strResults}</th>{Environment.NewLine}";
				strResults = $"{strResults}</tr>{Environment.NewLine}";

				if (strCellNbr != "")
				{

					if (strMobileActiveDate != "")
					{

						strLink1 = $"http://www.jetnetevomobile.com/login.asp?ENbr={Base64_Encode($"{strCellNbr}|{strMobileActiveDate}")}";
						strHRef1 = $"<a title='Click To Follow Link' target='_blank' href='{strLink1}'>{strLink1}</a>";

						strLink2 = "http://www.jetnetevomobile.com/index.asp";
						strHRef2 = $"<a title='Click To Follow Link' target='_blank' href='{strLink2}'>{strLink2}</a>";

						strResults = $"{strResults}<tr>{Environment.NewLine}{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='center'>{Environment.NewLine}";
						strResults = $"{strResults}&nbsp;&nbsp;{strHRef1}&nbsp;&nbsp;<BR/>{Environment.NewLine}";
						strResults = $"{strResults}&nbsp;&nbsp;OR&nbsp;&nbsp;<BR/>{Environment.NewLine}";
						strResults = $"{strResults}&nbsp;&nbsp;{strHRef2}&nbsp;&nbsp;{Environment.NewLine}";
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

					}
					else
					{
						strResults = $"{strResults}<tr><td colspan='1'><H1>No Mobile Active Date</H1></td></tr>{Environment.NewLine}";
					} // If strMobileActiveDate <> "" Then

				}
				else
				{
					strResults = $"{strResults}<tr><td colspan='1'><H1>No Cell Phone Number</H1></td></tr>{Environment.NewLine}";
				} // If strCellNBr <> "" Then

				strResults = $"{strResults}</table>{Environment.NewLine}";

				//--------------------------------------------------------------------------


				return strResults;
			}
			catch (System.Exception excep)
			{

				MessageBox.Show($"Return_SMS_Text_Message_Link_Error: {excep.Message}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				result = "";
			}
			return result;
		} // Return_SMS_Text_Message_Link


		internal static bool Add_Text_Message_To_Queue(ref TextMsg_Customer_Record txtmsgRecord)
		{

			bool result = false;
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strInsert1 = "";
			bool bResults = false;
			string strTextMsg = "";

			try
			{

				bResults = false;

				strTextMsg = txtmsgRecord.strTextMessage;
				if (strTextMsg != "")
				{

					//-----------------------------------------------
					// Get SMS Configuration Information
					strQuery1 = "SELECT TOP 1 * FROM SMS_Text_Message_Configuration WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1}WHERE (smscfg_active_flag = 'Y') ";

					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if ((!rstRec1.BOF) && (!rstRec1.EOF))
					{

						// URLEncode For Spaces, & Sign and / Backslash..etc
						strTextMsg = URLEncoding(strTextMsg);

						//-----------------------------------------
						// Remove All Non-Required Characters
						//-----------------------------------------
						txtmsgRecord.strCellNumber = modCommon.CleanUpCellNumber(txtmsgRecord.strCellNumber);

						strInsert1 = "INSERT INTO SMS_Text_Message_Queue (";

						strInsert1 = $"{strInsert1}smst_account_id, smst_password, smst_short_code, ";
						strInsert1 = $"{strInsert1}smst_gateway, smst_domestic_flag,  smst_comp_id, ";
						strInsert1 = $"{strInsert1}smst_sub_id, smst_login, smst_seq_no, ";
						strInsert1 = $"{strInsert1}smst_cell_number,  smst_cell_service, smst_message, ";
						strInsert1 = $"{strInsert1}smst_status,  smst_onhold_flag ) VALUES (";

						if (txtmsgRecord.bDomestic)
						{
							strInsert1 = $"{strInsert1}'{($"{Convert.ToString(rstRec1["smscfg_domestic_account_id"])} ").Trim()}', ";
							strInsert1 = $"{strInsert1}'{($"{Convert.ToString(rstRec1["smscfg_domestic_password"])} ").Trim()}', ";
							strInsert1 = $"{strInsert1}'{($"{Convert.ToString(rstRec1["smscfg_domestic_short_code"])} ").Trim()}', ";
							strInsert1 = $"{strInsert1}'{($"{Convert.ToString(rstRec1["smscfg_domestic_sms_gateway"])} ").Trim()}', ";
							strInsert1 = $"{strInsert1}'Y', ";
						}
						else
						{
							strInsert1 = $"{strInsert1}'{($"{Convert.ToString(rstRec1["smscfg_intl_account_id"])} ").Trim()}', ";
							strInsert1 = $"{strInsert1}'{($"{Convert.ToString(rstRec1["smscfg_intl_password"])} ").Trim()}', ";
							strInsert1 = $"{strInsert1}'{($"{Convert.ToString(rstRec1["smscfg_intl_short_code"])} ").Trim()}', ";
							strInsert1 = $"{strInsert1}'{($"{Convert.ToString(rstRec1["smscfg_intl_sms_gateway"])} ").Trim()}', ";
							strInsert1 = $"{strInsert1}'N', ";
						} // If txtmsgRecord.bDomestic = True Then

						strInsert1 = $"{strInsert1}{txtmsgRecord.lCompId.ToString()}, ";
						strInsert1 = $"{strInsert1}{txtmsgRecord.lSubId.ToString()}, ";
						strInsert1 = $"{strInsert1}'{txtmsgRecord.strLogin}', ";
						strInsert1 = $"{strInsert1}{txtmsgRecord.lSeqNbr.ToString()}, ";
						strInsert1 = $"{strInsert1}'{txtmsgRecord.strCellNumber}', ";
						strInsert1 = $"{strInsert1}'{txtmsgRecord.strCellCarrierService}', ";
						strInsert1 = $"{strInsert1}'{StringsHelper.Replace(strTextMsg, "'", "''", 1, -1, CompareMethod.Binary)}', ";
						strInsert1 = $"{strInsert1}'Open', 'N' ) ";


						if (txtmsgRecord.strCellNumber != "1234567890")
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

						bResults = true;

					} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

					rstRec1.Close();

				} // If strTextMsg <> "" Then

				rstRec1 = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				MessageBox.Show($"Add_Text_Message_To_Queue_Error: {excep.Message}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				result = false;
			}
			return result;
		} // Add_Text_Message_To_Queue

		internal static void FillBasicTextMessageRecord(ref TextMsg_Customer_Record tmRec, string strMsg)
		{

			string[] aCarrier = null;
			int lCarrierId = 0;
			string strCarrier = "";
			string strCOUNTRY = "";
			bool bDomestic = false;

			try
			{


				//-----------------------------
				// Load Text Message Record
				//-----------------------------

				tmRec.lCompId = Entered_Company_ID;
				tmRec.lSubId = gbl_SubID;
				tmRec.strLogin = frm_Subscription.DefInstance.txtLoginName.Text;

				frm_Subscription.DefInstance.grd_Installations.CurrentColumnIndex = 0;
				tmRec.lSeqNbr = Convert.ToInt32(Double.Parse(frm_Subscription.DefInstance.grd_Installations[frm_Subscription.DefInstance.grd_Installations.CurrentRowIndex, frm_Subscription.DefInstance.grd_Installations.CurrentColumnIndex].FormattedValue.ToString()));

				tmRec.strCellNumber = frm_Subscription.DefInstance.txtCellNumber.Text;

				aCarrier = frm_Subscription.DefInstance.cboCellCarrier.Text.Split(new string[]{" - "}, StringSplitOptions.None);

				strCOUNTRY = ($"{aCarrier[0]} ").Trim();
				strCarrier = ($"{aCarrier[1]} ").Trim();

				tmRec.strCellCarrierCountry = strCOUNTRY;
				tmRec.strCellCarrierService = strCarrier;

				tmRec.strTextMessage = strMsg;

				bDomestic = true;
				if (strCOUNTRY != "United States")
				{
					bDomestic = false;
				}

				tmRec.bDomestic = bDomestic;
				 // frm_Subscription
			}
			catch (System.Exception excep)
			{

				MessageBox.Show($"FillBasicTextMessageRecord_Error: {excep.Message}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		} // FillBasicTextMessageRecord

		// ====================================================================================
		// Written By : David D. Cruger
		// Created    : 11/21/2011
		// Modified   : 03/30/2017
		// Function   : IsPasswordAndEMailUsedMoreThanOnce
		//
		// Parameters : ByVal strPassword As String
		//              ByVal strService As String
		//              ByRef strStatus As String
		//
		// Returns    : Boolean
		//
		// Notes      : Checks To See If Password/EMail Is Used More Than Once
		//
		// ====================================================================================

		internal static bool IsPasswordAndEMailUsedMoreThanOnce(string strPassword, string strService, ref string strStatus)
		{

			bool result = false;
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			bool bResults = false;
			int lCnt1 = 0;

			try
			{

				bResults = false;
				strStatus = "";

				strPassword = strPassword.ToLower();

				if (strPassword != "")
				{

					strQuery1 = "SELECT DISTINCT sub_id As SubId, sublogin_login As Login, sublogin_password As PassWord, ";
					strQuery1 = $"{strQuery1}subins_seq_no As SeqNbr, contact_email_address As EMailAddress ";
					strQuery1 = $"{strQuery1}FROM Subscription WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1}INNER JOIN Subscription_Login WITH (NOLOCK) ON sub_id = sublogin_sub_id ";
					strQuery1 = $"{strQuery1}INNER JOIN Subscription_Install WITH (NOLOCK) ON sublogin_sub_id = subins_sub_id AND sublogin_login = subins_login ";
					strQuery1 = $"{strQuery1}INNER JOIN Contact WITH (NOLOCK) ON subins_contact_id = contact_id AND contact_journ_id = 0 ";
					strQuery1 = $"{strQuery1}WHERE (sub_start_date IS NOT NULL) AND (sub_start_date <= GetDate()) ";
					strQuery1 = $"{strQuery1}AND (sub_end_date IS NULL OR sub_end_date > GetDate())";
					strQuery1 = $"{strQuery1}AND (sublogin_active_flag = 'Y') ";
					strQuery1 = $"{strQuery1}AND (subins_active_flag = 'Y')  AND (sublogin_password = '{strPassword}') ";
					strQuery1 = $"{strQuery1}AND (contact_email_address IS NOT NULL) AND (contact_email_address <> '') ";

					// 03/30/2017 - By David D. Cruger
					// Only Check CRM/MPM if that is the service passed
					// Else do NOT check CRM/MPM
					if (strService == "CRM" || strService == "MPM")
					{
						strQuery1 = $"{strQuery1}AND (sub_serv_code IN ('CRM','MPM')) ";
					}
					else
					{
						strQuery1 = $"{strQuery1}AND (sub_serv_code NOT IN ('CRM','MPM')) ";
					}

					strQuery1 = $"{strQuery1}ORDER BY sub_id, sublogin_login, subins_seq_no ";

					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if ((!rstRec1.BOF) && (!rstRec1.EOF))
					{

						lCnt1 = 0;
						do 
						{ // Loop Until rstRec1.EOF = True

							lCnt1++;

							strStatus = $"{strStatus}{Convert.ToString(rstRec1["SubId"])}-{($"{Convert.ToString(rstRec1["login"])} ").Trim()}-{Convert.ToString(rstRec1["SeqNbr"])}-{($"{Convert.ToString(rstRec1["emailAddress"])} ").Trim()}{Environment.NewLine}";

							rstRec1.MoveNext();

						}
						while(!(rstRec1.EOF || lCnt1 >= 10));

						if (lCnt1 > 1)
						{
							bResults = true;
						}

					} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

					rstRec1.Close();

				}
				else
				{
					strStatus = "Password is Blank";
				} // If strPassword <> "" Then

				rstRec1 = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				MessageBox.Show($"IsPasswordAndEMailUsedMoreThanOnce_Error: {excep.Message}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				result = false;
			}
			return result;
		} // IsPasswordAndEMailUsedMoreThanOnce


		internal static string ReturnAircraftMakeModelNames(string strAModId)
		{

			string result = "";
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strResults = "";

			try
			{


				strResults = "";

				strAModId = StringsHelper.Replace(strAModId, " ", "", 1, -1, CompareMethod.Binary);
				strAModId = StringsHelper.Replace(strAModId, ";", ",", 1, -1, CompareMethod.Binary);
				strAModId = StringsHelper.Replace(strAModId, "|", ",", 1, -1, CompareMethod.Binary);

				if (strAModId != "")
				{

					strQuery1 = "SELECT amod_make_name As Make, amod_model_name As Model FROM Aircraft_Model WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1}WHERE (amod_id IN ({strAModId})) ";
					strQuery1 = $"{strQuery1}AND (amod_customer_flag = 'Y') ORDER BY amod_make_name, amod_model_name ";

					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						do 
						{
							strResults = $"{strResults}{($"{Convert.ToString(rstRec1["make"])} ").Trim()} {($"{Convert.ToString(rstRec1["model"])} ").Trim()}, ";
							rstRec1.MoveNext();
						}
						while(!rstRec1.EOF);

						strResults = strResults.Substring(0, Math.Min(Strings.Len(strResults) - 2, strResults.Length)); // Remove ,space

					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

				} // If strAModId <> "" Then
				 // frm_Subscription

				rstRec1 = null;


				return strResults;
			}
			catch
			{

				result = "";
			}
			return result;
		} // ReturnAircraftMakeModelNames

		internal static string ReturnAirportCodesNames(string strAirportId)
		{

			string result = "";
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strResults = "";

			try
			{


				strResults = "";

				strAirportId = StringsHelper.Replace(strAirportId, " ", "", 1, -1, CompareMethod.Binary);
				strAirportId = StringsHelper.Replace(strAirportId, ";", ",", 1, -1, CompareMethod.Binary);
				strAirportId = StringsHelper.Replace(strAirportId, "|", ",", 1, -1, CompareMethod.Binary);

				if (strAirportId != "")
				{

					strQuery1 = "SELECT aport_id As APortId,  aport_iata_code As IATA, aport_icao_code AS ICAO, ";
					strQuery1 = $"{strQuery1}aport_faaid_code AS FAAID, aport_name AS APortName ";
					strQuery1 = $"{strQuery1}FROM Airport WITH (NOLOCK) WHERE (aport_id IN ({strAirportId})) ";
					strQuery1 = $"{strQuery1}AND (aport_active_flag = 'Y') ORDER BY APortName ";

					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						do 
						{
							strResults = $"{strResults}[{($"{Convert.ToString(rstRec1["IATA"])} ").Trim()}-{($"{Convert.ToString(rstRec1["ICAO"])} ").Trim()}-{($"{Convert.ToString(rstRec1["FAAID"])} ").Trim()}]-{($"{Convert.ToString(rstRec1["APortName"])} ").Trim()}, ";
							rstRec1.MoveNext();
						}
						while(!rstRec1.EOF);

						strResults = strResults.Substring(0, Math.Min(Strings.Len(strResults) - 2, strResults.Length)); // Remove ,space

					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

				} // If strAirportId <> "" Then
				 // frm_Subscription

				rstRec1 = null;


				return strResults;
			}
			catch
			{

				result = "";
			}
			return result;
		} // ReturnAirportCodesNames

		internal static string Return_SMS_Text_Message_Validation_Report(DbConnection cntConn, int lCompId, int lSubId, string strLogin, int lSeqNbr, string strDatabase, ref bool bPassed)
		{

			string result = "";
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper(); // Company
			ADORecordSetHelper rstRec2 = new ADORecordSetHelper(); // Subscription
			ADORecordSetHelper rstRec3 = new ADORecordSetHelper(); // Login
			ADORecordSetHelper rstRec4 = new ADORecordSetHelper(); // Install
			ADORecordSetHelper rstRec5 = new ADORecordSetHelper(); // Contact

			string strQuery1 = "";
			string strQuery2 = "";
			string strQuery3 = "";
			string strQuery4 = "";
			string strQuery5 = "";

			bool bEvoMobilePassed = false;
			bool bSMSTextMsgPassed = false;

			//--------------------------
			// From Company Record

			string strCompany = "";
			string strCompCity = "";
			string strCompCountry = "";
			string strCompActiveFlag = "";

			//----------------------------
			// From Contact Record

			string strContact = "";
			string strContactEMail = "";
			int lContactId = 0;

			//----------------------------
			// From Subscription Record

			string strBusinessFlag = "";
			string strHelicopterFlag = "";
			string strCommercialFlag = "";
			string strYachtFlag = "";

			string strShareByCompId = "";
			string strShareByParentId = "";

			string strFrequency = "";
			System.DateTime dtStartDate = DateTime.FromOADate(0);
			System.DateTime dtEndDate = DateTime.FromOADate(0);
			string strMaxAllowedCustomExport = "";

			//----------------------
			// From Login Record

			string strLoginActiveFlag = "";
			string strLoginDemoFlag = "";
			string strLoginAllowTextMsgFlag = "";

			//--------------------------
			// From Install Record

			string strInstallPlatformOS = "";
			string strInstallActiveFlag = "";
			string strInstallPlatform = "";
			string strInstallCellNbr = "";
			string strInstallCellCarrierName = "";
			int lInstallCellCarrierId = 0;
			string strInstallTextMsgModels = "";
			System.DateTime dtInstallDate = DateTime.FromOADate(0);
			System.DateTime dtLastAccessDate = DateTime.FromOADate(0);
			System.DateTime dtMobileActiveDate = DateTime.FromOADate(0);
			System.DateTime dt7Days = DateTime.FromOADate(0);
			string strEvoMobileFlag = "";
			string strInstallSMSTextActiveFlag = "";
			string strSMSEvents = "";

			// 09/13/2011 - By David D. Cruger
			System.DateTime dtLastLoginDate = DateTime.FromOADate(0);
			System.DateTime dtLastLogoutDate = DateTime.FromOADate(0);
			System.DateTime dtLastSessionDate = DateTime.FromOADate(0);

			// 08/22/2014 - By David D. Cruger
			string strAdminFlag = "";
			string strChatFlag = "";

			string strHeader = "";
			string strResults = "";
			string strFooter = "";

			try
			{


				strResults = "";
				bPassed = true;
				bEvoMobilePassed = true;
				bSMSTextMsgPassed = true;

				if (lCompId > 0 && lSubId > 0 && strLogin != "" && lSeqNbr >= 0)
				{

					//-----------------------
					// Company Record

					strCompany = "";
					strCompCity = "";
					strCompCountry = "";

					strQuery1 = $"SELECT * FROM Company WITH (NOLOCK) WHERE (comp_id = {lCompId.ToString()}) AND (comp_journ_id = 0) ";

					rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!rstRec1.BOF && !rstRec1.EOF)
					{
						strCompany = ($"{Convert.ToString(rstRec1["comp_name"])} ").Trim();
						strCompCity = ($"{Convert.ToString(rstRec1["comp_city"])} ").Trim();
						strCompCountry = ($"{Convert.ToString(rstRec1["comp_country"])} ").Trim();
						strCompActiveFlag = ($"{Convert.ToString(rstRec1["comp_active_flag"])} ").Trim();
						if (strCompActiveFlag == "Y")
						{
							strCompActiveFlag = "Yes";
						}
						else
						{
							strCompActiveFlag = "No";
						}
					}
					else
					{
						strResults = $"{strResults}<tr><td align='left' colspan='3'>Could Not Find Company Record - CompId: [{lCompId.ToString()}]</td></tr>{Environment.NewLine}{Environment.NewLine}";
						bPassed = false;
						bEvoMobilePassed = false;
						bSMSTextMsgPassed = false;
					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

					//----------------------------
					// Subscription Record

					strBusinessFlag = "N";
					strHelicopterFlag = "N";
					strCommercialFlag = "N";
					strYachtFlag = "N";

					strShareByCompId = "N";
					strShareByParentId = "N";

					strFrequency = "";
					dtStartDate = DateTime.FromOADate(0);
					dtEndDate = DateTime.FromOADate(0);
					strMaxAllowedCustomExport = "";

					strQuery2 = $"SELECT * FROM Subscription WITH (NOLOCK) WHERE (sub_id = {lSubId.ToString()}) ";

					rstRec2.Open(strQuery2, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!rstRec2.BOF && !rstRec2.EOF)
					{

						strBusinessFlag = modCommon.ReturnYesNo(($"{Convert.ToString(rstRec2["sub_business_aircraft_flag"])} ").Trim());
						strHelicopterFlag = modCommon.ReturnYesNo(($"{Convert.ToString(rstRec2["sub_helicopters_flag"])} ").Trim());
						strCommercialFlag = modCommon.ReturnYesNo(($"{Convert.ToString(rstRec2["sub_commerical_flag"])} ").Trim());
						strYachtFlag = modCommon.ReturnYesNo(($"{Convert.ToString(rstRec2["sub_yacht_flag"])} ").Trim());

						strShareByCompId = modCommon.ReturnYesNo(($"{Convert.ToString(rstRec2["sub_share_by_comp_id_flag"])} ").Trim());
						strShareByParentId = modCommon.ReturnYesNo(($"{Convert.ToString(rstRec2["sub_share_by_parent_sub_id_flag"])} ").Trim());

						strFrequency = ($"{Convert.ToString(rstRec2["sub_frequency"])} ").Trim().ToUpper();

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec2["sub_start_date"]))
						{
							dtStartDate = Convert.ToDateTime(rstRec2["sub_start_date"]);
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec2["sub_end_date"]))
						{
							dtEndDate = Convert.ToDateTime(rstRec2["sub_end_date"]);
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec2["sub_max_allowed_custom_export"]))
						{
							strMaxAllowedCustomExport = Convert.ToString(rstRec2["sub_max_allowed_custom_export"]);
						}

					}
					else
					{
						strResults = $"{strResults}<tr><td align='left' colspan='3'>Could Not Find Company Subscription Record - SubId: [{lSubId.ToString()}]</td></tr>{Environment.NewLine}{Environment.NewLine}";
						bPassed = false;
						bEvoMobilePassed = false;
						bSMSTextMsgPassed = false;
					} // If rstRec2.BOF = False And rstRec2.EOF = False Then

					rstRec2.Close();

					//----------------------------
					// Subscription Login Record

					strLoginActiveFlag = "N";
					strLoginDemoFlag = "N";
					strLoginAllowTextMsgFlag = "N";

					strQuery3 = "SELECT * FROM Subscription_Login WITH (NOLOCK) ";
					strQuery3 = $"{strQuery3}WHERE (sublogin_sub_id = {lSubId.ToString()}) AND (sublogin_login = '{strLogin}') ";

					rstRec3.Open(strQuery3, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!rstRec3.BOF && !rstRec3.EOF)
					{

						strLoginActiveFlag = modCommon.ReturnYesNo(($"{Convert.ToString(rstRec3["sublogin_active_flag"])} ").Trim());
						strLoginDemoFlag = modCommon.ReturnYesNo(($"{Convert.ToString(rstRec3["sublogin_demo_flag"])} ").Trim());
						strLoginAllowTextMsgFlag = modCommon.ReturnYesNo(($"{Convert.ToString(rstRec3["sublogin_allow_text_message_flag"])} ").Trim());

					}
					else
					{
						strResults = $"{strResults}<tr><td align='left' colspan='3'>Could Not Find Company Subscription-Login Record - SubId/Login [{lSubId.ToString()}-{strLogin}]</td></tr>{Environment.NewLine}{Environment.NewLine}";
						bPassed = false;
						bEvoMobilePassed = false;
						bSMSTextMsgPassed = false;
					} // If rstRec3.BOF = False And rstRec3.EOF = False Then

					rstRec3.Close();

					//------------------------------
					// Subscription Install Record

					strInstallPlatformOS = "";
					strInstallActiveFlag = "N";
					strInstallPlatform = "";
					strInstallCellNbr = "";
					strInstallCellCarrierName = "";
					lInstallCellCarrierId = 0;
					strInstallTextMsgModels = "";
					dtInstallDate = DateTime.FromOADate(0);
					dtLastAccessDate = DateTime.FromOADate(0);
					dtMobileActiveDate = DateTime.FromOADate(0);
					dt7Days = DateTime.FromOADate(0);
					strEvoMobileFlag = "N";
					strInstallSMSTextActiveFlag = "N";
					strSMSEvents = "MA";
					dtLastLoginDate = DateTime.FromOADate(0);
					dtLastLogoutDate = DateTime.FromOADate(0);
					dtLastSessionDate = DateTime.FromOADate(0);
					lContactId = 0;
					strAdminFlag = "N";
					strChatFlag = "N";

					strQuery4 = $"SELECT * FROM Subscription_Install WITH (NOLOCK) WHERE (subins_sub_id = {lSubId.ToString()})";
					strQuery4 = $"{strQuery4}AND (subins_login = '{strLogin}') AND (subins_seq_no = {lSeqNbr.ToString()}) ";

					rstRec4.Open(strQuery4, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!rstRec4.BOF && !rstRec4.EOF)
					{

						strInstallPlatformOS = ($"{Convert.ToString(rstRec4["subins_platform_os"])} ").Trim();

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec4["subins_contact_id"]))
						{
							lContactId = Convert.ToInt32(rstRec4["subins_contact_id"]);
						}

						strInstallActiveFlag = modCommon.ReturnYesNo(($"{Convert.ToString(rstRec4["subins_active_flag"])} ").Trim());

						strInstallPlatform = ($"{Convert.ToString(rstRec4["subins_platform_name"])} ").Trim();
						strInstallCellNbr = ($"{Convert.ToString(rstRec4["subins_cell_number"])} ").Trim();
						strInstallCellCarrierName = ($"{Convert.ToString(rstRec4["subins_cell_service"])} ").Trim();
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec4["subins_cell_carrier_id"]))
						{
							lInstallCellCarrierId = Convert.ToInt32(rstRec4["subins_cell_carrier_id"]);
						}
						strInstallTextMsgModels = ($"{Convert.ToString(rstRec4["subins_smstxt_models"])} ").Trim();
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec4["subins_install_date"]))
						{
							dtInstallDate = Convert.ToDateTime(rstRec4["subins_install_date"]);
						}
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec4["subins_access_date"]))
						{
							dtLastAccessDate = Convert.ToDateTime(rstRec4["subins_access_date"]);
						}
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec4["subins_mobile_active_date"]))
						{
							dtMobileActiveDate = Convert.ToDateTime(rstRec4["subins_mobile_active_date"]);
							dt7Days = dtMobileActiveDate.AddDays(7);
						}

						strEvoMobileFlag = modCommon.ReturnYesNo(($"{Convert.ToString(rstRec4["subins_evo_mobile_flag"])} ").Trim());

						strInstallSMSTextActiveFlag = ($"{Convert.ToString(rstRec4["subins_smstxt_active_flag"])} ").Trim();
						switch(strInstallSMSTextActiveFlag)
						{
							case "Y" : 
								strInstallSMSTextActiveFlag = "Yes"; 
								break;
							case "N" : 
								strInstallSMSTextActiveFlag = "No"; 
								break;
							case "W" : 
								strInstallSMSTextActiveFlag = "Waiting"; 
								break;
							case "A" : 
								strInstallSMSTextActiveFlag = "Activate"; 
								break;
						}

						// 03/08/2011 - By David D. Cruger; Added
						strSMSEvents = ($"{Convert.ToString(rstRec4["subins_sms_events"])} ").Trim();

						// 09/13/2011 - By David D. Cruger; Added
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec4["subins_last_login_date"]))
						{
							dtLastLoginDate = Convert.ToDateTime(rstRec4["subins_last_login_date"]);
						}
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec4["subins_last_login_date"]))
						{
							dtLastLogoutDate = Convert.ToDateTime(rstRec4["subins_last_login_date"]);
						}
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec4["subins_last_login_date"]))
						{
							dtLastSessionDate = Convert.ToDateTime(rstRec4["subins_last_login_date"]);
						}

						// 08/22/2014 - By David D. Cruger
						strAdminFlag = modCommon.ReturnYesNo(($"{Convert.ToString(rstRec4["subins_admin_flag"])} ").Trim());
						strChatFlag = modCommon.ReturnYesNo(($"{Convert.ToString(rstRec4["subins_chat_flag"])} ").Trim());

					}
					else
					{
						strResults = $"{strResults}<tr><td align='left' colspan='3'>Could Not Find Company Subscription-Install Record - SubId/Login/SeqNbr = [{lSubId.ToString()}-{strLogin}-{lSeqNbr.ToString()}]</td></tr>{Environment.NewLine}{Environment.NewLine}";
						bPassed = false;
						bEvoMobilePassed = false;
						bSMSTextMsgPassed = false;
					} // If rstRec4.BOF = False And rstRec4.EOF = False Then

					rstRec4.Close();

					//----------------------------
					// Contact

					strContact = "";
					strContactEMail = "";
					if (lContactId > 0)
					{

						strQuery5 = $"SELECT * FROM Contact WITH (NOLOCK) WHERE (contact_id = {lContactId.ToString()}) AND (contact_journ_id = 0) ";

						rstRec5.Open(strQuery5, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

						if (!rstRec5.BOF && !rstRec5.EOF)
						{

							if (($"{Convert.ToString(rstRec5["contact_sirname"])} ").Trim() != "")
							{
								strContact = $"{($"{Convert.ToString(rstRec5["contact_sirname"])} ").Trim()} ";
							}
							if (($"{Convert.ToString(rstRec5["contact_first_name"])} ").Trim() != "")
							{
								strContact = $"{strContact}{($"{Convert.ToString(rstRec5["contact_first_name"])} ").Trim()} ";
							}
							if (($"{Convert.ToString(rstRec5["contact_middle_initial"])} ").Trim() != "")
							{
								strContact = $"{strContact}{($"{Convert.ToString(rstRec5["contact_middle_initial"])} ").Trim()}. ";
							}
							if (($"{Convert.ToString(rstRec5["contact_last_name"])} ").Trim() != "")
							{
								strContact = $"{strContact}{($"{Convert.ToString(rstRec5["contact_last_name"])} ").Trim()} ";
							}
							if (($"{Convert.ToString(rstRec5["contact_suffix"])} ").Trim() != "")
							{
								strContact = $"{strContact}, {($"{Convert.ToString(rstRec5["contact_suffix"])} ").Trim()}";
							}

							if (($"{Convert.ToString(rstRec5["contact_email_address"])} ").Trim() != "")
							{
								strContactEMail = ($"{Convert.ToString(rstRec5["contact_email_address"])} ").Trim();
							}

						} // If rstRec5.BOF = False And rstRec5.EOF = False Then

						rstRec5.Close();

					} // If lContactId > 0 Then

					//-----------------------------------------------
					// If True Then All Data Records Were Found

					if (bPassed)
					{

						//----------------------------------------------
						// Now Check Data And Create Report

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left'>Comp ID</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>{lCompId.ToString()}</tb>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left'>Sub ID</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>{lSubId.ToString()}</tb>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left'>Login Name</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						if (strAdminFlag == "Yes")
						{
							strResults = $"{strResults}<font color='red'><b>{strLogin}</b></font>&nbsp;(Administrator)";
						}
						else
						{
							strResults = $"{strResults}{strLogin}";
						}
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left'>Contact Name</td>{Environment.NewLine}";

						strResults = $"{strResults}<td align='left' colspan='2'>";
						if (strContact != "")
						{
							strResults = $"{strResults}{strContact}";
						}
						else
						{
							strResults = $"{strResults}<font color='red'><b>** NO CONTACT **</b></font>{Environment.NewLine}";
						}
						strResults = $"{strResults}</td>{Environment.NewLine}";

						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left'>EMail</td>{Environment.NewLine}";

						strResults = $"{strResults}<td align='left' colspan='2'>";
						if (strContactEMail != "")
						{
							strResults = $"{strResults}{strContactEMail}";
						}
						else
						{
							strResults = $"{strResults}<font color='red'><b>** NO CONTACT EMAIL ADDRESS **</b></font>{Environment.NewLine}";
						}
						strResults = $"{strResults}</td>{Environment.NewLine}";

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left'>Platform OS</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>{strInstallPlatformOS}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='3'>&nbsp;</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left'>Company</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'><b>{strCompany}</b></td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left'>City </td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>{strCompCity}&nbsp;</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left'>Country </td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left'>{strCompCountry}&nbsp;</td>{Environment.NewLine}";

						if (strCompCountry != "")
						{
							strResults = $"{strResults}<td align='left'>OK</td>{Environment.NewLine}";
						}
						else
						{
							strResults = $"{strResults}<td align='center'><font color='red'><b>** INVALID **<BR/>COUNTRY BLANK</b></font></td>{Environment.NewLine}";
							bPassed = false;
							bEvoMobilePassed = false;
							bSMSTextMsgPassed = false;
						}
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='3'>&nbsp;</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left'>Active Flag</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left'>{strCompActiveFlag}</td>{Environment.NewLine}";

						if (strCompActiveFlag == "Yes")
						{
							strResults = $"{strResults}<td align='left'>OK</td>{Environment.NewLine}";
						}
						else
						{
							strResults = $"{strResults}<td align='center'><font color='red'><b>** NOT ACTIVE **</b></font></td>{Environment.NewLine}";
							bPassed = false;
							bEvoMobilePassed = false;
							bSMSTextMsgPassed = false;
						}
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left'>Products</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left'>";
						if (strBusinessFlag == "Yes")
						{
							strResults = $"{strResults}Business ";
						}
						if (strHelicopterFlag == "Yes")
						{
							strResults = $"{strResults}Helicopters ";
						}
						if (strCommercialFlag == "Yes")
						{
							strResults = $"{strResults}Commercial ";
						}
						if (strYachtFlag == "Yes")
						{
							strResults = $"{strResults}Yachts ";
						}
						strResults = $"{strResults}</td>{Environment.NewLine}";

						if (strBusinessFlag == "Yes" || strHelicopterFlag == "Yes" || strCommercialFlag == "Yes" || strYachtFlag == "Yes")
						{
							strResults = $"{strResults}<td align='left'>OK</td>{Environment.NewLine}";
						}
						else
						{
							strResults = $"{strResults}<td align='center'><font color='red'><b>** INVALID **<BR/>NO PRODUCT SELECTED (BUSINESS, HELICOPTER, COMMERCIAL, YACHT)</b></font></td>{Environment.NewLine}";
							bPassed = false;
							bEvoMobilePassed = false;
							bSMSTextMsgPassed = false;
						}
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left'>Share By CompId</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>{strShareByCompId}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left'>Share By ParnetId</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>{strShareByParentId}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left'>Frequency</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left'>{strFrequency}</td>{Environment.NewLine}";

						if (strFrequency.ToUpper() == "LIVE")
						{
							strResults = $"{strResults}<td align='left'>OK</td>{Environment.NewLine}";
						}
						else
						{
							strResults = $"{strResults}<td align='center'><font color='red'><b>** INVALID **<BR/>MUST BE LIVE</b></font></td>{Environment.NewLine}";
							bPassed = false;
							bEvoMobilePassed = false;
							bSMSTextMsgPassed = false;
						}
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left'>Start Date</td>{Environment.NewLine}";

						if (dtStartDate > DateTime.FromOADate(0))
						{
							strResults = $"{strResults}<td align='left'>{dtStartDate.ToString("MM/dd/yyyy")}</td>{Environment.NewLine}";
							if (dtStartDate <= DateTime.Now)
							{
								strResults = $"{strResults}<td align='left'>OK</td>{Environment.NewLine}";
							}
							else
							{
								strResults = $"{strResults}<td align='center'><font color='red'><b>** INVALID **<BR/>AFTER TODAY</b></font></td>{Environment.NewLine}";
								bPassed = false;
								bEvoMobilePassed = false;
								bSMSTextMsgPassed = false;
							}
						}
						else
						{
							strResults = $"{strResults}<td>&nbsp;</td>{Environment.NewLine}";
							strResults = $"{strResults}<th align='center'><font color='red'>** INVALID **<BR/>BLANK</font></th>{Environment.NewLine}";
							bPassed = false;
							bEvoMobilePassed = false;
							bSMSTextMsgPassed = false;
						} // If dtStartDate > 0 Then
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left'>End Date</td>{Environment.NewLine}";
						if (dtEndDate == DateTime.FromOADate(0))
						{
							strResults = $"{strResults}<td>&nbsp;</td>{Environment.NewLine}";
							strResults = $"{strResults}<td align='left'>OK</td>{Environment.NewLine}";
						}
						else
						{
							strResults = $"{strResults}<td align='left'>{dtStartDate.ToString("MM/dd/yyyy")}</td>{Environment.NewLine}";
							if (dtEndDate > DateTime.Now)
							{
								strResults = $"{strResults}<td align='left'>AFTER TODAY-OK</td>{Environment.NewLine}";
							}
							else
							{
								strResults = $"{strResults}<td align='center'><font color='red'><b>** INVALID **<BR/>EXPIRED</b></font></td>{Environment.NewLine}";
								bPassed = false;
								bEvoMobilePassed = false;
								bSMSTextMsgPassed = false;
							}
						}
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left'>Max Allowed Custom Export</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left'>{strMaxAllowedCustomExport}</td>{Environment.NewLine}";

						if (strMaxAllowedCustomExport == "" || strMaxAllowedCustomExport == "0")
						{
							strResults = $"{strResults}<td align='center'><font color='red'><b>** BLANK **</b></font></td>{Environment.NewLine}";
						}
						else
						{

							if (Convert.ToInt32(Double.Parse(strMaxAllowedCustomExport)) == 5000)
							{
								strResults = $"{strResults}<td align='center'>OK</td>{Environment.NewLine}";
							}

							if (Convert.ToInt32(Double.Parse(strMaxAllowedCustomExport)) < 5000)
							{
								strResults = $"{strResults}<td align='center'><font color='blue'><b>** LOWER THAN NORMAL **</b></font></td>{Environment.NewLine}";
							}

							if (Convert.ToInt32(Double.Parse(strMaxAllowedCustomExport)) > 5000)
							{
								strResults = $"{strResults}<td align='center'><font color='red'><b>** HIGHER THAN NORMAL **</b></font></td>{Environment.NewLine}";
							}

						} // If strMaxAllowedCustomExport = "" Or strMaxAllowedCustomExport = "0" Then

						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left'>Active Flag</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left'>{strLoginActiveFlag}</td>{Environment.NewLine}";

						if (strLoginActiveFlag == "Yes")
						{
							strResults = $"{strResults}<td align='left'>OK</td>{Environment.NewLine}";
						}
						else
						{
							strResults = $"{strResults}<td align='center'><font color='red'><b>** NOT ACTIVE **</b></font></td>{Environment.NewLine}";
							bPassed = false;
							bEvoMobilePassed = false;
							bSMSTextMsgPassed = false;
						}
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left'>Demo Flag</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left'>{strLoginDemoFlag}</td>{Environment.NewLine}";

						if (strLoginDemoFlag == "No")
						{
							strResults = $"{strResults}<td align='left'>OK</td>{Environment.NewLine}";
						}
						else
						{
							strResults = $"{strResults}<td align='center'><font color='red'><b>** INVALID **<BR/>DEMO ACCOUNT</b></font></td>{Environment.NewLine}";
							bPassed = false;
							bEvoMobilePassed = false;
							bSMSTextMsgPassed = false;
						}
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left'>Allow Text Messages Flag</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left'>{strLoginAllowTextMsgFlag}</td>{Environment.NewLine}";

						if (strLoginAllowTextMsgFlag == "Yes")
						{
							strResults = $"{strResults}<td align='left'>OK</td>{Environment.NewLine}";
						}
						else
						{
							strResults = $"{strResults}<td align='center'><font color='red'><b>** INVALID **<BR/>FLAG NO</b></font></td>{Environment.NewLine}";
							bPassed = false;
							bEvoMobilePassed = false;
							bSMSTextMsgPassed = false;
						}
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left'>Install SeqNbr</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>{lSeqNbr.ToString()}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left'>Platform</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>{strInstallPlatform}&nbsp;</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left'>Cell Number</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left'>{strInstallCellNbr}&nbsp;</td>{Environment.NewLine}";

						if (strInstallCellNbr != "")
						{
							strResults = $"{strResults}<td align='left'>OK</td>{Environment.NewLine}";
						}
						else
						{
							strResults = $"{strResults}<td align='center'><font color='red'><b>** INVALID **<BR/>BLANK</b></font></td>{Environment.NewLine}";
							bPassed = false;
							bEvoMobilePassed = false;
							bSMSTextMsgPassed = false;
						}
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left'>Cell Carrier</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left'>{strInstallCellCarrierName}&nbsp;</td>{Environment.NewLine}";

						if (strInstallCellCarrierName != "")
						{
							strResults = $"{strResults}<td align='left'>OK</td>{Environment.NewLine}";
						}
						else
						{
							strResults = $"{strResults}<td align='center'><font color='red'><b>** INVALID **<BR/>BLANK</b></font></td>{Environment.NewLine}";
							bPassed = false;
							bEvoMobilePassed = false;
							bSMSTextMsgPassed = false;
						}
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left'>Evo-Mobile Flag</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left'>{strEvoMobileFlag}</td>{Environment.NewLine}";

						if (strEvoMobileFlag == "Yes")
						{
							strResults = $"{strResults}<td align='left'>OK</td>{Environment.NewLine}";
						}
						else
						{
							strResults = $"{strResults}<td align='center'><font color='red'><b>** NOT ACTIVE **</b></font></td>{Environment.NewLine}";
							bPassed = false;
							bEvoMobilePassed = false;
							bSMSTextMsgPassed = false;
						}
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left'>SMS Text Message Active Flag</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left'>{strInstallSMSTextActiveFlag}</td>{Environment.NewLine}";

						if (strInstallSMSTextActiveFlag == "Yes")
						{
							strResults = $"{strResults}<td align='left'>OK</td>{Environment.NewLine}";
						}
						else if (strInstallSMSTextActiveFlag == "No")
						{ 
							strResults = $"{strResults}<td align='center'><font color='red'><b>** NOT ACTIVE **</b></font></td>{Environment.NewLine}";
							bPassed = false;
							bEvoMobilePassed = false;
							bSMSTextMsgPassed = false;
						}
						else if (strInstallSMSTextActiveFlag == "Waiting")
						{ 
							strResults = $"{strResults}<td align='center'><font color='blue'><b>User Must Send<BR/>OK Text Message</b></font></td>{Environment.NewLine}";
						}
						else if (strInstallSMSTextActiveFlag == "Activate")
						{ 
							strResults = $"{strResults}<td align='center'><font color='blue'><b>Activate Message<BR/>Needs To Be Sent</b></font></td>{Environment.NewLine}";
						}
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left'>Text Msg Models</td>{Environment.NewLine}";

						if (strInstallTextMsgModels != "" && strInstallTextMsgModels != "0" && strInstallTextMsgModels != "9999")
						{
							strResults = $"{strResults}<td align='left'>{strInstallTextMsgModels}</td>{Environment.NewLine}";
							strResults = $"{strResults}<td align='left'>OK</td>{Environment.NewLine}";
						}
						else
						{
							strResults = $"{strResults}<td align='center' colspan='2'>{Environment.NewLine}";
							strResults = $"{strResults}<b><font color='red'>** BLANK **<BR/>NOT INVALID FOR TEXT MSG ALERTS</font><BR/>OK For Evo-Mobile</b>{Environment.NewLine}";
							strResults = $"{strResults}</td>{Environment.NewLine}";
							bSMSTextMsgPassed = false;
						}
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						// 03/08/2011 - By David D. Cruger; Added
						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left'>Events To Monitor</td>{Environment.NewLine}";

						if (strSMSEvents != "")
						{
							strResults = $"{strResults}<td align='left'>{strSMSEvents}</td>{Environment.NewLine}";
							strResults = $"{strResults}<td align='left'>OK</td>{Environment.NewLine}";
						}
						else
						{
							strResults = $"{strResults}<td align='center' colspan='2'>{Environment.NewLine}";
							strResults = $"{strResults}<b><font color='red'>** BLANK **<BR/>NOT INVALID FOR TEXT MSG ALERTS</font><BR/>OK For Evo-Mobile</b>{Environment.NewLine}";
							strResults = $"{strResults}</td>{Environment.NewLine}";
							bSMSTextMsgPassed = false;
						}
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						// 08/22/2014 - By David D. Cruger; Added
						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left'>Chat Flag</td>{Environment.NewLine}";

						if (strChatFlag == "Yes")
						{
							strResults = $"{strResults}<td align='left' colspan='2'>Yes - Chat Is Active</td>{Environment.NewLine}";
						}
						else
						{
							strResults = $"{strResults}<td align='left' colspan='2'>No - Chat Is NOT Active</td>{Environment.NewLine}";
						}
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left'>Install Date</td>{Environment.NewLine}";

						if (dtInstallDate > DateTime.FromOADate(0))
						{
							strResults = $"{strResults}<td align='left'>{StringsHelper.Format(dtInstallDate, "MM/DD/YYYY HH:MM:SS AM/PM")}</td>{Environment.NewLine}";
							strResults = $"{strResults}<td align='left'>OK</td>{Environment.NewLine}";
						}
						else
						{
							strResults = $"{strResults}<td align='left'>&nbsp;</td>{Environment.NewLine}";
							strResults = $"{strResults}<th align='center'><font color='red'>** INVALID **<BR/>BLANK</font></th>{Environment.NewLine}";
							bPassed = false;
							bEvoMobilePassed = false;
							bSMSTextMsgPassed = false;
						}
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left'>Last Access Date</td>{Environment.NewLine}";

						if (dtLastAccessDate > DateTime.FromOADate(0))
						{
							strResults = $"{strResults}<td align='left'>{StringsHelper.Format(dtLastAccessDate, "MM/DD/YYYY HH:MM:SS AM/PM")}</td>{Environment.NewLine}";
							strResults = $"{strResults}<td align='left'>OK</td>{Environment.NewLine}";
						}
						else
						{
							strResults = $"{strResults}<td align='left'>&nbsp;</td>{Environment.NewLine}";
							strResults = $"{strResults}<th align='center'><font color='red'>** INVALID **<BR/>BLANK</font></th>{Environment.NewLine}";
							bPassed = false;
							bEvoMobilePassed = false;
							bSMSTextMsgPassed = false;
						}
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						// 09/13/2011 - By David D. Cruger; Added;
						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left'>Last Login Date</td>{Environment.NewLine}";

						if (dtLastLoginDate > DateTime.FromOADate(0))
						{
							strResults = $"{strResults}<td align='left'>{StringsHelper.Format(dtLastLoginDate, "MM/DD/YYYY HH:MM:SS AM/PM")}</td>{Environment.NewLine}";
							strResults = $"{strResults}<td align='left'>OK</td>{Environment.NewLine}";
						}
						else
						{
							strResults = $"{strResults}<td align='left'>&nbsp;</td>{Environment.NewLine}";
							strResults = $"{strResults}<td align='left'>&nbsp;</td>{Environment.NewLine}";
						}
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						// 09/13/2011 - By David D. Cruger; Added;
						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left'>Last Logout Date</td>{Environment.NewLine}";

						if (dtLastLoginDate > DateTime.FromOADate(0))
						{
							strResults = $"{strResults}<td align='left'>{StringsHelper.Format(dtLastLogoutDate, "MM/DD/YYYY HH:MM:SS AM/PM")}</td>{Environment.NewLine}";
							strResults = $"{strResults}<td align='left'>OK</td>{Environment.NewLine}";
						}
						else
						{
							strResults = $"{strResults}<td align='left'>&nbsp;</td>{Environment.NewLine}";
							strResults = $"{strResults}<td align='left'>&nbsp;</td>{Environment.NewLine}";
						}
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						// 09/13/2011 - By David D. Cruger; Added;
						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left'>Last Session Date</td>{Environment.NewLine}";

						if (dtLastLoginDate > DateTime.FromOADate(0))
						{
							strResults = $"{strResults}<td align='left'>{StringsHelper.Format(dtLastSessionDate, "MM/DD/YYYY HH:MM:SS AM/PM")}</td>{Environment.NewLine}";
							strResults = $"{strResults}<td align='left'>OK</td>{Environment.NewLine}";
						}
						else
						{
							strResults = $"{strResults}<td align='left'>&nbsp;</td>{Environment.NewLine}";
							strResults = $"{strResults}<td align='left'>&nbsp;</td>{Environment.NewLine}";
						}
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

					} // If bPassed = True Then

				}
				else
				{
					strResults = $"<tr><td colspan='3'><H1>Report Parameters Invalid</H1></td></tr>{Environment.NewLine}";
					bPassed = false;
					bEvoMobilePassed = false;
					bSMSTextMsgPassed = false;
				} // If lCompId > 0 And lSubId > 0 And strLogin <> "" And lSeqNbr >= 0 Then

				//--------------------------------------------------------------------------

				strHeader = $"<table border='1' cellpadding='0' cellspacing='0' width='600'>{Environment.NewLine}";

				strHeader = $"{strHeader}<tr>{Environment.NewLine}";
				strHeader = $"{strHeader}<th colspan='3' align='center'>{Environment.NewLine}";
				strHeader = $"{strHeader}{strDatabase} SMS TEXT MESSAGE VALIDATION<BR/>";
				if (bEvoMobilePassed)
				{
					strHeader = $"{strHeader}<font color='blue'><b>EVOLUTION MOBILE PASSED</b></font><BR/>";
				}
				else
				{
					strHeader = $"{strHeader}<font color='red'><b>EVOLUTION MOBILE FAILED</b></font><BR/>";
				}
				if (bSMSTextMsgPassed)
				{
					strHeader = $"{strHeader}<font color='blue'><b>SMS TEXT MSG PASSED</b></font><BR/>";
				}
				else
				{
					strHeader = $"{strHeader}<font color='red'><b>SMS TEXT MSG FAILED</b></font><BR/>";
				}
				strHeader = $"{strHeader}</th>{Environment.NewLine}";
				strHeader = $"{strHeader}</tr>{Environment.NewLine}";

				strFooter = $"</table>{Environment.NewLine}{Environment.NewLine}";

				strResults = $"{strHeader}{strResults}{strFooter}";
				 // frm_Subscription

				rstRec5 = null;
				rstRec4 = null;
				rstRec3 = null;
				rstRec2 = null;
				rstRec1 = null;


				return strResults;
			}
			catch (System.Exception excep)
			{

				bPassed = false;
				MessageBox.Show($"Return_SMS_Text_Message_Validation_Report_Error: {excep.Message}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				result = "";
			}
			return result;
		} // Return_SMS_Text_Message_Validation_Report



		internal static string Return_Subscription_Install_Validation_Report(DbConnection cntConn, int lCompId, int lContactId, int lSubId, string strLogin, int lSeqNbr, string strDatabase, ref bool bPassed)
		{

			string result = "";
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper(); // Company
			ADORecordSetHelper rstRec2 = new ADORecordSetHelper(); // Contact
			ADORecordSetHelper rstRec3 = new ADORecordSetHelper(); // Subscription
			ADORecordSetHelper rstRec4 = new ADORecordSetHelper(); // Login
			ADORecordSetHelper rstRec5 = new ADORecordSetHelper(); // Install

			string strQuery1 = "";
			string strQuery2 = "";
			string strQuery3 = "";
			string strQuery4 = "";
			string strQuery5 = "";

			//------------------------------
			// Company Record

			string strCompany = "";
			string strCompCity = "";
			string strCompState = "";
			string strCompCountry = "";
			string strCompActiveFlag = "";
			System.DateTime dtCompActionDate = DateTime.FromOADate(0);

			//------------------------------
			// Contact Record

			string strContact = "";
			string strContactEMail = "";
			string strContactActiveFlag = "";
			System.DateTime dtContactActionDate = DateTime.FromOADate(0);

			//------------------------------
			// Subscription Record

			string strSubService = "";
			System.DateTime dtSubStartDate = DateTime.FromOADate(0);
			System.DateTime dtSubEndDate = DateTime.FromOADate(0);
			System.DateTime dtSubActionDate = DateTime.FromOADate(0);
			string strNbrInstalls = "";
			string strNbrSPIInstalls = "";
			string strSubMktFlag = "";
			string strSubBFlag = "";
			string strSubCFlag = "";
			string strSubHFlag = "";
			string strSubAFlag = "";
			string strSubYFlag = "";
			string strSubSPIFlag = "";
			string strSubSPINbrInstalls = "";
			string strSubMPMFlag = "";
			string strSubMPMNbrInstalls = "";
			string strSubFrequency = "";
			string strSubServerSideNoteFlag = "";
			string strSubServerSideNotedBaseName = "";
			string strMaxAllowedCustomExport = "";
			string strHistoryFlag = "";

			//------------------------------
			// Subscription Login Record

			string strSubLogLogin = "";
			string strSubLogPassword = "";
			string strSubLogActiveFlag = "";
			string strSubLogDemoFlag = "";
			string strSubLogAllowExportFlag = "";
			string strSubLogAllowLocalNotesFlag = "";
			string strSubLogAllowProjectsFlag = "";
			string strSubLogAllowEMailRequestsFlag = "";
			string strSubLogAllowEventRequestsFlag = "";
			string strSubLogAllowTextMsgFlag = "";
			string strSubLogAllowValuesFlag = "";
			string strSubLogAllowMPMFlag = "";

			//------------------------------
			// Subscription Install Record

			string strSubInsPlatformName = "";
			string strSubInsOSName = "";
			System.DateTime dtSubInsInstallDate = DateTime.FromOADate(0);
			System.DateTime dtSubInsAccessDate = DateTime.FromOADate(0);
			string strSubInsActiveFlag = "";
			string strSubInsLocalNotesFlag = "";
			string strSubInsLocalNotesPath = "";
			string strSubInsActiveXFlag = "";
			string strSubInsAutoCheckTServiceFlag = "";
			string strSubInsTerminalServiceFlag = "";
			string strSubInsEMailReplyName = "";
			string strSubInsEMailReplyAddress = "";
			string strSubInsDisplayNotesFlag = "";
			int lSubInsEvoViewId = 0;
			string strSubInsEvoViewName = "";
			string strSubInsCellNbr = "";
			string strSubInsSMSModels = "";
			string strSubInsSMSActiveFlag = "";
			string strSubInsSMSCellService = "";
			string strSubInsMobileFlag = "";
			string strSubInsSMSEvents = "";
			System.DateTime dtSubInsLastLoginDate = DateTime.FromOADate(0);
			System.DateTime dtSubInsLastLogoutDate = DateTime.FromOADate(0);
			System.DateTime dtSubInsLastSessionDate = DateTime.FromOADate(0);
			int lSubInsNbrRecPerPage = 0;
			string strSubInsDefaultModelId = "";
			string strSubInsDefaultModels = "";
			string strSubInsAdmindFlag = "";
			string strSubInsChatFlag = "";

			string strDefaultAirports = "";
			string strDefaultAirportNames = "";
			string strBusinessType = "";

			string strHeader = "";
			string strResults = "";
			string strFooter = "";

			string strBGStyle = "";

			try
			{


				strResults = "";
				bPassed = true;

				if (lCompId > 0 && lContactId > 0 && lSubId > 0 && strLogin != "" && lSeqNbr >= 0)
				{

					strBGStyle = "style='background-color: beige'";

					//-----------------------
					// Company Record

					strCompany = "";
					strCompCity = "";
					strCompState = "";
					strCompCountry = "";
					strCompActiveFlag = "No";
					dtCompActionDate = DateTime.FromOADate(0);

					strQuery1 = $"SELECT * FROM Company WITH (NOLOCK) WHERE (comp_id = {lCompId.ToString()}) AND (comp_journ_id = 0) ";

					rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						strCompany = ($"{Convert.ToString(rstRec1["comp_name"])} ").Trim();
						strCompCity = ($"{Convert.ToString(rstRec1["comp_city"])} ").Trim();
						strCompState = ($"{Convert.ToString(rstRec1["comp_state"])} ").Trim();
						strCompCountry = ($"{Convert.ToString(rstRec1["comp_country"])} ").Trim();
						strCompActiveFlag = ($"{Convert.ToString(rstRec1["comp_active_flag"])} ").Trim();
						if (strCompActiveFlag == "Y")
						{
							strCompActiveFlag = "Yes";
						}
						else
						{
							strCompActiveFlag = "No";
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["comp_action_date"]))
						{
							dtCompActionDate = Convert.ToDateTime(rstRec1["comp_action_date"]);
							if (dtCompActionDate == DateTime.Parse("1/1/1900"))
							{
								dtCompActionDate = DateTime.FromOADate(0);
							}
						}

					}
					else
					{
						strResults = $"{strResults}<tr><td align='left' colspan='3'>Could Not Find Company Record - CompId: [{lCompId.ToString()}]</td></tr>{Environment.NewLine}{Environment.NewLine}";
						bPassed = false;
					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

					//----------------------------
					// Contact

					strContact = "";
					strContactEMail = "";
					strContactActiveFlag = "No";
					dtContactActionDate = DateTime.FromOADate(0);

					strQuery2 = $"SELECT * FROM Contact WITH (NOLOCK) WHERE (contact_id = {lContactId.ToString()}) AND (contact_journ_id = 0) ";

					rstRec2.Open(strQuery2, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!rstRec2.BOF && !rstRec2.EOF)
					{

						if (($"{Convert.ToString(rstRec2["contact_sirname"])} ").Trim() != "")
						{
							strContact = $"{($"{Convert.ToString(rstRec2["contact_sirname"])} ").Trim()} ";
						}
						if (($"{Convert.ToString(rstRec2["contact_first_name"])} ").Trim() != "")
						{
							strContact = $"{strContact}{($"{Convert.ToString(rstRec2["contact_first_name"])} ").Trim()} ";
						}
						if (($"{Convert.ToString(rstRec2["contact_middle_initial"])} ").Trim() != "")
						{
							strContact = $"{strContact}{($"{Convert.ToString(rstRec2["contact_middle_initial"])} ").Trim()}. ";
						}
						if (($"{Convert.ToString(rstRec2["contact_last_name"])} ").Trim() != "")
						{
							strContact = $"{strContact}{($"{Convert.ToString(rstRec2["contact_last_name"])} ").Trim()} ";
						}
						if (($"{Convert.ToString(rstRec2["contact_suffix"])} ").Trim() != "")
						{
							strContact = $"{strContact}, {($"{Convert.ToString(rstRec2["contact_suffix"])} ").Trim()}";
						}

						strContactEMail = ($"{Convert.ToString(rstRec2["contact_email_address"])} ").Trim();

						strContactActiveFlag = ($"{Convert.ToString(rstRec2["contact_active_flag"])} ").Trim();
						if (strContactActiveFlag == "Y")
						{
							strContactActiveFlag = "Yes";
						}
						else
						{
							strContactActiveFlag = "No";
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec2["contact_action_date"]))
						{
							dtContactActionDate = Convert.ToDateTime(rstRec2["contact_action_date"]);
							if (dtContactActionDate == DateTime.Parse("1/1/1900"))
							{
								dtContactActionDate = DateTime.FromOADate(0);
							}
						}

					}
					else
					{
						strResults = $"{strResults}<tr><td align='left' colspan='3'>Could Not Find Contact Record - ContactId: [{lContactId.ToString()}]</td></tr>{Environment.NewLine}{Environment.NewLine}";
						bPassed = false;
					} // If rstRec2.BOF = False And rstRec2.EOF = False Then

					rstRec2.Close();

					//----------------------------
					// Subscription Record

					strSubService = "";
					dtSubStartDate = DateTime.FromOADate(0);
					dtSubEndDate = DateTime.FromOADate(0);
					dtSubActionDate = DateTime.FromOADate(0);
					strNbrInstalls = "0";
					strNbrSPIInstalls = "0";
					strSubMktFlag = "No";
					strSubBFlag = "No";
					strSubCFlag = "No";
					strSubHFlag = "No";
					strSubAFlag = "No";
					strSubYFlag = "No";
					strSubSPIFlag = "No";
					strSubSPINbrInstalls = "0";
					strSubMPMFlag = "No";
					strSubMPMNbrInstalls = "0";

					strSubFrequency = "";
					strSubServerSideNoteFlag = "No";
					strSubServerSideNotedBaseName = "";
					strMaxAllowedCustomExport = "";
					strHistoryFlag = "No";

					strQuery3 = "SELECT * FROM Subscription WITH (NOLOCK) ";
					strQuery3 = $"{strQuery3}LEFT OUTER JOIN Service WITH (NOLOCK) ON sub_serv_code = serv_code ";
					strQuery3 = $"{strQuery3}WHERE (sub_id = {lSubId.ToString()}) ";

					rstRec3.Open(strQuery3, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!rstRec3.BOF && !rstRec3.EOF)
					{

						if (($"{Convert.ToString(rstRec3["sub_serv_code"])} ").Trim() != "")
						{
							strSubService = $"{($"{Convert.ToString(rstRec3["sub_serv_code"])} ").Trim()}-{($"{Convert.ToString(rstRec3["serv_name"])} ").Trim()}";
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec3["sub_start_date"]))
						{
							dtSubStartDate = Convert.ToDateTime(rstRec3["sub_start_date"]);
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec3["sub_end_date"]))
						{
							dtSubEndDate = Convert.ToDateTime(rstRec3["sub_end_date"]);
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec3["sub_action_date"]))
						{
							dtSubActionDate = Convert.ToDateTime(rstRec3["sub_action_date"]);
							if (dtSubActionDate == DateTime.Parse("1/1/1900"))
							{
								dtSubActionDate = DateTime.FromOADate(0);
							}
						}

						// 10/28/2016 - By David D. Cruger; Added
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec3["sub_nbr_of_installs"]))
						{
							if (Information.IsNumeric(rstRec3["sub_nbr_of_installs"]))
							{
								strNbrInstalls = Convert.ToString(rstRec3["sub_nbr_of_installs"]);
							}
						}

						// 10/28/2016 - By David D. Cruger; Added
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec3["sub_nbr_of_spi_installs"]))
						{
							if (Information.IsNumeric(rstRec3["sub_nbr_of_spi_installs"]))
							{
								strNbrSPIInstalls = Convert.ToString(rstRec3["sub_nbr_of_spi_installs"]);
							}
						}

						// 09/20/2019 - By David D. Cruger; Added
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec3["sub_mpm_nbr_installs"]))
						{
							if (Information.IsNumeric(rstRec3["sub_mpm_nbr_installs"]))
							{
								strSubMPMNbrInstalls = Convert.ToString(rstRec3["sub_mpm_nbr_installs"]);
							}
						}

						strSubMktFlag = ($"{Convert.ToString(rstRec3["sub_marketing_flag"])} ").Trim();
						if (strSubMktFlag == "Y")
						{
							strSubMktFlag = "Yes";
						}
						else
						{
							strSubMktFlag = "No";
						}

						strSubBFlag = ($"{Convert.ToString(rstRec3["sub_business_aircraft_flag"])} ").Trim();
						if (strSubBFlag == "Y")
						{
							strSubBFlag = "Yes";
						}
						else
						{
							strSubBFlag = "No";
						}

						strSubCFlag = ($"{Convert.ToString(rstRec3["sub_commerical_flag"])} ").Trim();
						if (strSubCFlag == "Y")
						{
							strSubCFlag = "Yes";
						}
						else
						{
							strSubCFlag = "No";
						}

						strSubHFlag = ($"{Convert.ToString(rstRec3["sub_helicopters_flag"])} ").Trim();
						if (strSubHFlag == "Y")
						{
							strSubHFlag = "Yes";
						}
						else
						{
							strSubHFlag = "No";
						}

						strSubAFlag = ($"{Convert.ToString(rstRec3["sub_aerodex_flag"])} ").Trim();
						if (strSubAFlag == "Y")
						{
							strSubAFlag = "Yes";
						}
						else
						{
							strSubAFlag = "No";
						}

						strSubYFlag = ($"{Convert.ToString(rstRec3["sub_yacht_flag"])} ").Trim();
						if (strSubYFlag == "Y")
						{
							strSubYFlag = "Yes";
						}
						else
						{
							strSubYFlag = "No";
						}

						strSubSPIFlag = ($"{Convert.ToString(rstRec3["sub_sale_price_flag"])} ").Trim();
						if (strSubSPIFlag == "Y")
						{
							strSubSPIFlag = "Yes";
						}
						else
						{
							strSubSPIFlag = "No";
						}

						strSubMPMFlag = ($"{Convert.ToString(rstRec3["sub_mpm_flag"])} ").Trim();
						if (strSubMPMFlag == "Y")
						{
							strSubMPMFlag = "Yes";
						}
						else
						{
							strSubMPMFlag = "No";
						}

						strHistoryFlag = ($"{Convert.ToString(rstRec3["sub_history_flag"])} ").Trim();
						if (strHistoryFlag == "Y")
						{
							strHistoryFlag = "Yes";
						}
						else
						{
							strHistoryFlag = "No";
						}

						strSubFrequency = ($"{Convert.ToString(rstRec3["sub_frequency"])} ").Trim().ToUpper();

						strSubServerSideNoteFlag = ($"{Convert.ToString(rstRec3["sub_server_side_notes_flag"])} ").Trim();
						if (strSubServerSideNoteFlag == "Y")
						{
							strSubServerSideNoteFlag = "Yes";
						}
						else
						{
							strSubServerSideNoteFlag = "No";
						}

						strSubServerSideNotedBaseName = ($"{Convert.ToString(rstRec3["sub_server_side_dbase_name"])} ").Trim();
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec3["sub_server_side_crm_regid"]))
						{
							strSubServerSideNotedBaseName = $"{Convert.ToString(rstRec3["sub_server_side_crm_regid"])}-{strSubServerSideNotedBaseName}";
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec3["sub_max_allowed_custom_export"]))
						{
							strMaxAllowedCustomExport = Convert.ToString(rstRec3["sub_max_allowed_custom_export"]);
						}

					}
					else
					{
						strResults = $"{strResults}<tr><td align='left' colspan='3'>Could Not Find Subscription Record - SubId: [{lSubId.ToString()}]</td></tr>{Environment.NewLine}{Environment.NewLine}";
						bPassed = false;
					} // If rstRec3.BOF = False And rstRec3.EOF = False Then

					rstRec3.Close();

					//----------------------------
					// Subscription Login Record

					strSubLogLogin = "";
					strSubLogPassword = "";
					strSubLogActiveFlag = "No";
					strSubLogDemoFlag = "No";
					strSubLogAllowExportFlag = "No";
					strSubLogAllowLocalNotesFlag = "No";
					strSubLogAllowProjectsFlag = "No";
					strSubLogAllowEMailRequestsFlag = "No";
					strSubLogAllowEventRequestsFlag = "No";
					strSubLogAllowTextMsgFlag = "No";
					strSubLogAllowValuesFlag = "No";
					strSubLogAllowMPMFlag = "No";

					strQuery4 = "SELECT * FROM Subscription_Login WITH (NOLOCK) ";
					strQuery4 = $"{strQuery4}WHERE (sublogin_sub_id = {lSubId.ToString()}) AND (sublogin_login = '{strLogin}') ";

					rstRec4.Open(strQuery4, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!rstRec4.BOF && !rstRec4.EOF)
					{

						strSubLogLogin = ($"{Convert.ToString(rstRec4["sublogin_login"])} ").Trim();
						strSubLogPassword = ($"{Convert.ToString(rstRec4["sublogin_password"])} ").Trim();

						strSubLogActiveFlag = ($"{Convert.ToString(rstRec4["sublogin_active_flag"])} ").Trim();
						if (strSubLogActiveFlag == "Y")
						{
							strSubLogActiveFlag = "Yes";
						}
						else
						{
							strSubLogActiveFlag = "No";
						}

						strSubLogDemoFlag = ($"{Convert.ToString(rstRec4["sublogin_demo_flag"])} ").Trim();
						if (strSubLogDemoFlag == "Y")
						{
							strSubLogDemoFlag = "Yes";
						}
						else
						{
							strSubLogDemoFlag = "No";
						}

						strSubLogAllowExportFlag = ($"{Convert.ToString(rstRec4["sublogin_allow_export_flag"])} ").Trim();
						if (strSubLogAllowExportFlag == "Y")
						{
							strSubLogAllowExportFlag = "Yes";
						}
						else
						{
							strSubLogAllowExportFlag = "No";
						}

						strSubLogAllowLocalNotesFlag = ($"{Convert.ToString(rstRec4["sublogin_allow_local_notes_flag"])} ").Trim();
						if (strSubLogAllowLocalNotesFlag == "Y")
						{
							strSubLogAllowLocalNotesFlag = "Yes";
						}
						else
						{
							strSubLogAllowLocalNotesFlag = "No";
						}

						strSubLogAllowProjectsFlag = ($"{Convert.ToString(rstRec4["sublogin_allow_projects_flag"])} ").Trim();
						if (strSubLogAllowProjectsFlag == "Y")
						{
							strSubLogAllowProjectsFlag = "Yes";
						}
						else
						{
							strSubLogAllowProjectsFlag = "No";
						}

						strSubLogAllowEMailRequestsFlag = ($"{Convert.ToString(rstRec4["sublogin_allow_email_request_flag"])} ").Trim();
						if (strSubLogAllowEMailRequestsFlag == "Y")
						{
							strSubLogAllowEMailRequestsFlag = "Yes";
						}
						else
						{
							strSubLogAllowEMailRequestsFlag = "No";
						}

						strSubLogAllowEventRequestsFlag = ($"{Convert.ToString(rstRec4["sublogin_allow_event_request_flag"])} ").Trim();
						if (strSubLogAllowEventRequestsFlag == "Y")
						{
							strSubLogAllowEventRequestsFlag = "Yes";
						}
						else
						{
							strSubLogAllowEventRequestsFlag = "No";
						}

						strSubLogAllowTextMsgFlag = ($"{Convert.ToString(rstRec4["sublogin_allow_text_message_flag"])} ").Trim();
						if (strSubLogAllowTextMsgFlag == "Y")
						{
							strSubLogAllowTextMsgFlag = "Yes";
						}
						else
						{
							strSubLogAllowTextMsgFlag = "No";
						}

						strSubLogAllowValuesFlag = ($"{Convert.ToString(rstRec4["sublogin_values_flag"])} ").Trim();
						if (strSubLogAllowValuesFlag == "Y")
						{
							strSubLogAllowValuesFlag = "Yes";
						}
						else
						{
							strSubLogAllowValuesFlag = "No";
						}

						strSubLogAllowMPMFlag = ($"{Convert.ToString(rstRec4["sublogin_mpm_flag"])} ").Trim();
						if (strSubLogAllowMPMFlag == "Y")
						{
							strSubLogAllowMPMFlag = "Yes";
						}
						else
						{
							strSubLogAllowMPMFlag = "No";
						}

					}
					else
					{
						strResults = $"{strResults}<tr><td align='left' colspan='3'>Could Not Find Subscription-Login Record - SubId/Login [{lSubId.ToString()}-{strLogin}]</td></tr>{Environment.NewLine}{Environment.NewLine}";
						bPassed = false;
					} // If rstRec4.BOF = False And rstRec4.EOF = False Then

					rstRec4.Close();

					//------------------------------
					// Subscription Install Record

					strSubInsPlatformName = "";
					strSubInsOSName = "";
					dtSubInsInstallDate = DateTime.FromOADate(0);
					dtSubInsAccessDate = DateTime.FromOADate(0);
					strSubInsActiveFlag = "No";
					strSubInsLocalNotesFlag = "No";
					strSubInsLocalNotesPath = "";
					strSubInsActiveXFlag = "No";
					strSubInsAutoCheckTServiceFlag = "No";
					strSubInsTerminalServiceFlag = "No";
					strSubInsEMailReplyName = "";
					strSubInsEMailReplyAddress = "";
					strSubInsDisplayNotesFlag = "No";
					lSubInsEvoViewId = 0;
					strSubInsEvoViewName = "";
					strSubInsCellNbr = "";
					strSubInsSMSModels = "";
					strSubInsSMSActiveFlag = "No";
					strSubInsSMSCellService = "Unknown";
					strSubInsMobileFlag = "No";
					strSubInsSMSEvents = "";
					dtSubInsLastLoginDate = DateTime.FromOADate(0);
					dtSubInsLastLogoutDate = DateTime.FromOADate(0);
					dtSubInsLastSessionDate = DateTime.FromOADate(0);
					lSubInsNbrRecPerPage = 0;
					strSubInsDefaultModelId = "";
					strSubInsDefaultModels = "";
					strSubInsAdmindFlag = "No";
					strSubInsChatFlag = "No";
					strDefaultAirports = "";
					strDefaultAirportNames = "";
					strBusinessType = "DB";

					strQuery5 = "SELECT * FROM Subscription_Install WITH (NOLOCK) ";
					strQuery5 = $"{strQuery5}LEFT OUTER JOIN Evolution_Views WITH (NOLOCK) ON subins_evoview_id = evoview_id ";
					strQuery5 = $"{strQuery5}WHERE (subins_sub_id = {lSubId.ToString()})";
					strQuery5 = $"{strQuery5}AND (subins_login = '{strLogin}')  AND (subins_seq_no = {lSeqNbr.ToString()})  AND (subins_contact_id = {lContactId.ToString()}) ";

					rstRec5.Open(strQuery5, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!rstRec5.BOF && !rstRec5.EOF)
					{

						strSubInsPlatformName = ($"{Convert.ToString(rstRec5["subins_platform_name"])} ").Trim();
						strSubInsOSName = ($"{Convert.ToString(rstRec5["subins_platform_os"])} ").Trim();

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec5["subins_install_date"]))
						{
							dtSubInsInstallDate = Convert.ToDateTime(rstRec5["subins_install_date"]);
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec5["subins_access_date"]))
						{
							dtSubInsAccessDate = Convert.ToDateTime(rstRec5["subins_access_date"]);
						}

						strSubInsActiveFlag = ($"{Convert.ToString(rstRec5["subins_active_flag"])} ").Trim();
						if (strSubInsActiveFlag == "Y")
						{
							strSubInsActiveFlag = "Yes";
						}
						else
						{
							strSubInsActiveFlag = "No";
						}

						strSubInsLocalNotesFlag = ($"{Convert.ToString(rstRec5["subins_local_db_flag"])} ").Trim();
						if (strSubInsLocalNotesFlag == "Y")
						{
							strSubInsLocalNotesFlag = "Yes";
						}
						else
						{
							strSubInsLocalNotesFlag = "No";
						}

						strSubInsLocalNotesPath = ($"{Convert.ToString(rstRec5["subins_local_db_file"])} ").Trim();

						strSubInsActiveXFlag = ($"{Convert.ToString(rstRec5["subins_activex_flag"])} ").Trim();
						if (strSubInsActiveXFlag == "Y")
						{
							strSubInsActiveXFlag = "Yes";
						}
						else
						{
							strSubInsActiveXFlag = "No";
						}

						strSubInsAutoCheckTServiceFlag = ($"{Convert.ToString(rstRec5["subins_autocheck_tservice"])} ").Trim();
						if (strSubInsAutoCheckTServiceFlag == "Y")
						{
							strSubInsAutoCheckTServiceFlag = "Yes";
						}
						else
						{
							strSubInsAutoCheckTServiceFlag = "No";
						}

						strSubInsTerminalServiceFlag = ($"{Convert.ToString(rstRec5["subins_terminal_service"])} ").Trim();
						if (strSubInsTerminalServiceFlag == "Y")
						{
							strSubInsTerminalServiceFlag = "Yes";
						}
						else
						{
							strSubInsTerminalServiceFlag = "No";
						}

						strSubInsEMailReplyName = ($"{Convert.ToString(rstRec5["subins_email_replyname"])} ").Trim();
						strSubInsEMailReplyAddress = ($"{Convert.ToString(rstRec5["subins_email_replyaddress"])} ").Trim();

						strSubInsDisplayNotesFlag = ($"{Convert.ToString(rstRec5["subins_display_note_tag_on_aclist_flag"])} ").Trim();
						if (strSubInsDisplayNotesFlag == "Y")
						{
							strSubInsDisplayNotesFlag = "Yes";
						}
						else
						{
							strSubInsDisplayNotesFlag = "No";
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec5["subins_evoview_id"]))
						{
							lSubInsEvoViewId = Convert.ToInt32(rstRec5["subins_evoview_id"]);
						}

						strSubInsEvoViewName = ($"{Convert.ToString(rstRec5["evoview_title"])} ").Trim();

						strSubInsCellNbr = ($"{Convert.ToString(rstRec5["subins_cell_number"])} ").Trim();
						strSubInsSMSModels = ($"{Convert.ToString(rstRec5["subins_smstxt_models"])} ").Trim();

						strSubInsSMSActiveFlag = ($"{Convert.ToString(rstRec5["subins_smstxt_active_flag"])} ").Trim();
						switch(strSubInsSMSActiveFlag)
						{
							case "Y" : 
								strSubInsSMSActiveFlag = "Yes"; 
								break;
							case "N" : 
								strSubInsSMSActiveFlag = "No"; 
								break;
							case "W" : 
								strSubInsSMSActiveFlag = "Waiting"; 
								break;
							case "A" : 
								strSubInsSMSActiveFlag = "Activate"; 
								break;
						}

						strSubInsSMSCellService = ($"{Convert.ToString(rstRec5["subins_cell_service"])} ").Trim();
						if (strSubInsSMSCellService == "")
						{
							strSubInsSMSCellService = "Unknown";
						}

						strSubInsMobileFlag = ($"{Convert.ToString(rstRec5["subins_evo_mobile_flag"])} ").Trim();
						if (strSubInsMobileFlag == "Y")
						{
							strSubInsMobileFlag = "Yes";
						}
						else
						{
							strSubInsMobileFlag = "No";
						}

						strSubInsSMSEvents = ($"{Convert.ToString(rstRec5["subins_sms_events"])} ").Trim();

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec5["subins_last_login_date"]))
						{
							dtSubInsLastLoginDate = Convert.ToDateTime(rstRec5["subins_last_login_date"]);
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec5["subins_last_login_date"]))
						{
							dtSubInsLastLogoutDate = Convert.ToDateTime(rstRec5["subins_last_login_date"]);
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec5["subins_last_login_date"]))
						{
							dtSubInsLastSessionDate = Convert.ToDateTime(rstRec5["subins_last_login_date"]);
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec5["subins_nbr_rec_per_page"]))
						{
							lSubInsNbrRecPerPage = Convert.ToInt32(rstRec5["subins_nbr_rec_per_page"]);
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec5["subins_default_amod_id"]))
						{
							if (Convert.ToDouble(rstRec5["subins_default_amod_id"]) > 0)
							{
								strSubInsDefaultModelId = Convert.ToString(rstRec5["subins_default_amod_id"]);
							}
						}

						strSubInsDefaultModels = ($"{Convert.ToString(rstRec5["subins_default_models"])} ").Trim();

						strSubInsAdmindFlag = ($"{Convert.ToString(rstRec5["subins_admin_flag"])} ").Trim();
						if (strSubInsAdmindFlag == "Y")
						{
							strSubInsAdmindFlag = "Yes";
						}
						else
						{
							strSubInsAdmindFlag = "No";
						}

						strSubInsChatFlag = ($"{Convert.ToString(rstRec5["subins_chat_flag"])} ").Trim();
						if (strSubInsChatFlag == "Y")
						{
							strSubInsChatFlag = "Yes";
						}
						else
						{
							strSubInsChatFlag = "No";
						}

						// 09/22/2015 - By David D. Cruger; Added

						strDefaultAirports = ($"{Convert.ToString(rstRec5["subins_default_airports"])} ").Trim();
						strBusinessType = ($"{Convert.ToString(rstRec5["subins_business_type_code"])} ").Trim();
						if (strBusinessType != "")
						{
							strBusinessType = $"{strBusinessType}-{modCommon.DLookUpCRM(cntConn, "cbus_name", "Company_Business_Type", $"(cbus_type='{strBusinessType}')")}";
						}

					}
					else
					{
						strResults = $"{strResults}<tr><td align='left' colspan='3'>Could Not Find Subscription-Install Record - SubId/Login/SeqNbr/ContactId = [{lSubId.ToString()}-{strLogin}-{lSeqNbr.ToString()}-{lContactId.ToString()}]</td></tr>{Environment.NewLine}{Environment.NewLine}";
						bPassed = false;
					} // If rstRec5.BOF = False And rstRec5.EOF = False Then

					rstRec5.Close();

					//-----------------------------------------------
					// If True Then All Data Records Were Found

					if (bPassed)
					{

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<th align='center' colspan='3'{strBGStyle}>Company Information</th>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>Company Id<br/>Company Name<br/>City, State, Country</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						strResults = $"{strResults}{lCompId.ToString()}<br/>";
						strResults = $"{strResults}{strCompany}<br/>";
						strResults = $"{strResults}{strCompCity}, {strCompState} {strCompCountry}";
						strResults = $"{strResults}</tb>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>Sub ID</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>{lSubId.ToString()}</tb>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>Active Flag</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						strResults = $"{strResults}{strCompActiveFlag}";
						if (strCompActiveFlag == "No")
						{
							strResults = $"{strResults}&nbsp;<font color='red'><b>** COMPANY IS NOT ACTIVE **</b></font>{Environment.NewLine}";
							bPassed = false;
						}
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>Action Date</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						if (dtCompActionDate == DateTime.FromOADate(0))
						{
							strResults = $"{strResults}&nbsp;<font color='red'><b>** NO ACTION DATE - PENDING TRANSMIT **</b></font>{Environment.NewLine}";
							bPassed = false;
						}
						else
						{
							strResults = $"{strResults}{StringsHelper.Format(dtCompActionDate, "mm/dd/yyyy hh:mm:ss AM/PM")}";
						}
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------
						//----------------------------------
						// Contact
						//----------------------------------
						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<th align='center' colspan='3'{strBGStyle}>Contact Information</th>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>Contact Name</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						if (strSubInsAdmindFlag == "Yes")
						{
							strResults = $"{strResults}<font color='red'><b>{strContact}</b></font> (Administrator)";
						}
						else
						{
							strResults = $"{strResults}{strContact}";
						}
						if (strContact == "")
						{
							strResults = $"{strResults}<font color='red'><b>** NO CONTACT **</b></font>{Environment.NewLine}";
							bPassed = false;
						}
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>EMail Address</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						strResults = $"{strResults}{strContactEMail}";
						if (strContactEMail == "")
						{
							strResults = $"{strResults}<font color='red'><b>** NO CONTACT EMAIL ADDRESS **</b></font>{Environment.NewLine}";
							bPassed = false;
						}
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>Active Flag</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						strResults = $"{strResults}{strContactActiveFlag}";
						if (strContactActiveFlag == "No")
						{
							strResults = $"{strResults}&nbsp;<font color='red'><b>** CONTACT IS NOT ACTIVE **</b></font>{Environment.NewLine}";
							bPassed = false;
						}
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>Action Date</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						if (dtContactActionDate == DateTime.FromOADate(0))
						{
							strResults = $"{strResults}&nbsp;<font color='red'><b>** NO ACTION DATE - PENDING TRANSMIT **</b></font>{Environment.NewLine}";
							bPassed = false;
						}
						else
						{
							strResults = $"{strResults}{StringsHelper.Format(dtContactActionDate, "mm/dd/yyyy hh:mm:ss AM/PM")}";
						}
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";



						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<th align='center' colspan='3'{strBGStyle}>Subscription Information</th>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>Service</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						strResults = $"{strResults}{strSubService}";
						if (strSubService == "")
						{
							strResults = $"{strResults}&nbsp;<font color='red'><b>** NO SERVICE ENTERED **</b></font>{Environment.NewLine}";
							bPassed = false;
						}
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>Start Date</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						if (dtSubStartDate > DateTime.FromOADate(0))
						{
							strResults = $"{strResults}{dtSubStartDate.ToString("MM/dd/yyyy")}";
						}
						else
						{
							strResults = $"{strResults}&nbsp;<font color='red'><b>** NO START DATE **</b></font>{Environment.NewLine}";
							bPassed = false;
						}
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>End Date</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						if (dtSubEndDate == DateTime.FromOADate(0))
						{
							strResults = $"{strResults}&nbsp;{Environment.NewLine}";
						}
						else
						{
							strResults = $"{strResults}{dtSubEndDate.ToString("MM/dd/yyyy")}";
							if (dtSubEndDate <= DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")))
							{
								strResults = $"{strResults}&nbsp;<font color='red'><b>** END DATE HAS EXPIRED **</b></font>{Environment.NewLine}";
								bPassed = false;
							}
						}
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>Action Date</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						if (dtSubActionDate == DateTime.FromOADate(0))
						{
							strResults = $"{strResults}&nbsp;<font color='red'><b>** NO ACTION DATE - PENDING TRANSMIT **</b></font>{Environment.NewLine}";
							bPassed = false;
						}
						else
						{
							strResults = $"{strResults}{StringsHelper.Format(dtSubActionDate, "mm/dd/yyyy hh:mm:ss AM/PM")}";
						}
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//---------------------------------------------
						// 10/28/2016 - By David D. Cruger; Added

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>Number of Installs</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						if (strNbrInstalls == "0")
						{
							strResults = $"{strResults}&nbsp;<font color='red'><b>** NO NUMBER OF INSTALLS **</b></font>{Environment.NewLine}";
							bPassed = false;
						}
						else
						{
							strResults = $"{strResults}{strNbrInstalls}";
						}
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//--------------------------------------------
						// 10/28/2016 - By David D. Cruger; Added

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>Number of Values Installs</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						if (strNbrSPIInstalls == "0")
						{
							strResults = $"{strResults}&nbsp;<font color='red'><b>** NO NUMBER OF VALUES INSTALLS **</b></font>{Environment.NewLine}";
							bPassed = false;
						}
						else
						{
							strResults = $"{strResults}{strNbrSPIInstalls}";
						}
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//--------------------------------------------
						// 09/20/2019 - By David D. Cruger; Added

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>Number of MPM Installs</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						if (strSubMPMNbrInstalls == "0")
						{
							strResults = $"{strResults}&nbsp;<font color='red'><b>** NO NUMBER OF MPM INSTALLS **</b></font>{Environment.NewLine}";
							bPassed = false;
						}
						else
						{
							strResults = $"{strResults}{strSubMPMNbrInstalls}";
						}
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>Marketing Flag</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						strResults = $"{strResults}{strSubMktFlag}";
						if (strSubMktFlag == "Yes")
						{
							strResults = $"{strResults}&nbsp;<font color='red'><b>** MARKETING ACCOUNT **</b></font>{Environment.NewLine}";
							bPassed = false;
						}
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>Business Flag</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						strResults = $"{strResults}{strSubBFlag}";
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>Commercial Flag</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						strResults = $"{strResults}{strSubCFlag}";
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>Helicopter Flag</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						strResults = $"{strResults}{strSubHFlag}";
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>Aerodex Flag</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						strResults = $"{strResults}{strSubAFlag}";
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>Yacht Flag</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						strResults = $"{strResults}{strSubYFlag}";
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>SPI Flag</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						strResults = $"{strResults}{strSubSPIFlag}";
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------
						// 07/31/2019 - By David D. Cruger; Added

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>History Flag</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						strResults = $"{strResults}{strHistoryFlag}";
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------
						// 09/20/2019 - By David D. Cruger; Added

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>MPM Flag</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						strResults = $"{strResults}{strSubMPMFlag}";
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>Frequency</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						strResults = $"{strResults}{strSubFrequency}";
						if (strSubFrequency == "")
						{
							strResults = $"{strResults}&nbsp;<font color='red'><b>** NO FREQUENCY ENTERED **</b></font>{Environment.NewLine}";
							bPassed = false;
						}
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>Server Side Notes</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						strResults = $"{strResults}{strSubServerSideNoteFlag}&nbsp;";
						if (strSubServerSideNoteFlag == "Yes" && strSubServerSideNotedBaseName == "")
						{
							strResults = $"{strResults}&nbsp;<font color='red'><b>** NO DATABASE ATTACHED **</b></font>{Environment.NewLine}";
							bPassed = false;
						}
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>SSN-dBase Name</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						strResults = $"{strResults}{strSubServerSideNotedBaseName}&nbsp;";
						if (strSubServerSideNoteFlag == "No" && strSubServerSideNotedBaseName != "0-")
						{
							strResults = $"{strResults}<BR/><font color='blue'><b>** DATABASE NAME SET BUT NOT ENABLED **</b></font>{Environment.NewLine}";
						}
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						if (strSubMktFlag == "No" && strSubBFlag == "No" && strSubCFlag == "No" && strSubHFlag == "No" && strSubAFlag == "No" && strSubYFlag == "No" && strSubSPIFlag == "No" && strSubServerSideNoteFlag == "No")
						{
							strResults = $"{strResults}<tr>{Environment.NewLine}";
							strResults = $"{strResults}<th align='center' colspan='3'><font color='red'><b>NO SUBSCRIPTION FLAGS HAVE BEEN SET</b></font></th>{Environment.NewLine}";
							strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";
						}

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>Max Allowed Custom Export</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left'>{strMaxAllowedCustomExport}</td>{Environment.NewLine}";

						if (strMaxAllowedCustomExport == "" || strMaxAllowedCustomExport == "0")
						{
							strResults = $"{strResults}<td align='center'><font color='red'><b>** BLANK **</b></font></td>{Environment.NewLine}";
						}
						else
						{

							if (Convert.ToInt32(Double.Parse(strMaxAllowedCustomExport)) == 5000)
							{
								strResults = $"{strResults}<td align='center'>OK</td>{Environment.NewLine}";
							}

							if (Convert.ToInt32(Double.Parse(strMaxAllowedCustomExport)) < 5000)
							{
								strResults = $"{strResults}<td align='center'><font color='blue'><b>** LOWER THAN NORMAL **</b></font></td>{Environment.NewLine}";
							}

							if (Convert.ToInt32(Double.Parse(strMaxAllowedCustomExport)) > 5000)
							{
								strResults = $"{strResults}<td align='center'><font color='red'><b>** HIGHER THAN NORMAL **</b></font></td>{Environment.NewLine}";
							}

						} // If strMaxAllowedCustomExport = "" Or strMaxAllowedCustomExport = "0" Then

						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------
						//----------------------------------
						// Subscription Logins
						//----------------------------------
						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<th align='center' colspan='3'{strBGStyle}>Subscription Login Information</th>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>Login Name</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						strResults = $"{strResults}{strSubLogLogin}";
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>Password</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						strResults = $"{strResults}{strSubLogPassword}";
						if (strSubLogPassword == "")
						{
							strResults = $"{strResults}<font color='red'><b>** PASSWORD IS BLANK **</b></font>{Environment.NewLine}";
							bPassed = false;
						}
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>Active Flag</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						strResults = $"{strResults}{strSubLogActiveFlag}";
						if (strSubLogActiveFlag == "No")
						{
							strResults = $"{strResults}&nbsp;<font color='red'><b>** LOGIN IS NOT ACTIVE **</b></font>{Environment.NewLine}";
							bPassed = false;
						}
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>Demo Flag</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						strResults = $"{strResults}{strSubLogDemoFlag}";
						if (strSubLogDemoFlag == "Yes")
						{
							strResults = $"{strResults}&nbsp;<font color='red'><b>** LOGIN IS A DEMO ACCOUNT **</b></font>{Environment.NewLine}";
							bPassed = false;
						}
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>Allow Export Flag</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						strResults = $"{strResults}{strSubLogAllowExportFlag}";
						if (strSubLogAllowExportFlag == "No")
						{
							strResults = $"{strResults}&nbsp;<font color='red'><b>** DOES NOT ALLOW EXPORT **</b></font>{Environment.NewLine}";
							bPassed = false;
						}
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>Allow Local Notes Flag</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						strResults = $"{strResults}{strSubLogAllowLocalNotesFlag}";
						if (strSubLogAllowLocalNotesFlag == "No")
						{
							strResults = $"{strResults}&nbsp;<font color='red'><b>** DOES NOT ALLOW LOCAL NOTES **</b></font>{Environment.NewLine}";
							bPassed = false;
						}
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>Allow Projects Flag</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						strResults = $"{strResults}{strSubLogAllowProjectsFlag}";
						if (strSubLogAllowProjectsFlag == "No")
						{
							strResults = $"{strResults}&nbsp;<font color='red'><b>** DOES NOT ALLOW PROJECTS **</b></font>{Environment.NewLine}";
							bPassed = false;
						}
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>Allow EMail Request Flag</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						strResults = $"{strResults}{strSubLogAllowEMailRequestsFlag}";
						if (strSubLogAllowEMailRequestsFlag == "No")
						{
							strResults = $"{strResults}&nbsp;<font color='red'><b>** DOES NOT ALLOW EMAIL REQUEST **</b></font>{Environment.NewLine}";
							bPassed = false;
						}
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>Allow Event Request Flag</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						strResults = $"{strResults}{strSubLogAllowEventRequestsFlag}";
						if (strSubLogAllowEventRequestsFlag == "No")
						{
							strResults = $"{strResults}&nbsp;<font color='red'><b>** DOES NOT ALLOW EVENT REQUEST **</b></font>{Environment.NewLine}";
							bPassed = false;
						}
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>Allow SMS Text Msg Flag</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						strResults = $"{strResults}{strSubLogAllowTextMsgFlag}";
						if (strSubLogAllowTextMsgFlag == "No")
						{
							strResults = $"{strResults}&nbsp;<font color='red'><b>** DOES NOT ALLOW SMS TEXT MESSAGES **</b></font>{Environment.NewLine}";
							bPassed = false;
							if (strSubInsSMSActiveFlag == "Yes")
							{
								strResults = $"{strResults}<br/><font color='red'><b>** DOES ALLOW SMS TEXT MESSAGES **</b></font>{Environment.NewLine}";
								bPassed = false;
							}
						}
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>Allow Values Flag</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						strResults = $"{strResults}{strSubLogAllowValuesFlag}";
						if (strSubLogAllowValuesFlag == "No")
						{
							strResults = $"{strResults}&nbsp;<font color='red'><b>** DOES NOT ALLOW VALUES **</b></font>{Environment.NewLine}";
							bPassed = false;
							if (strSubLogAllowValuesFlag == "Yes")
							{
								strResults = $"{strResults}<br/><font color='red'><b>** DOES ALLOW VALUES **</b></font>{Environment.NewLine}";
								bPassed = false;
							}
						}
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>Allow MPM Flag</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						strResults = $"{strResults}{strSubLogAllowMPMFlag}";
						if (strSubLogAllowMPMFlag == "No")
						{
							strResults = $"{strResults}&nbsp;<font color='red'><b>** DOES NOT ALLOW MPM **</b></font>{Environment.NewLine}";
							bPassed = false;
							if (strSubLogAllowMPMFlag == "Yes")
							{
								strResults = $"{strResults}<br/><font color='red'><b>** DOES ALLOW MPM **</b></font>{Environment.NewLine}";
								bPassed = false;
							}
						}
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<th align='center' colspan='3'{strBGStyle}>Subscription Install Information</th>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>SeqNbr</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>{lSeqNbr.ToString()}&nbsp;</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>Install Name</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						strResults = $"{strResults}{strSubInsPlatformName}";
						if (strSubInsPlatformName == "")
						{
							strResults = $"{strResults}&nbsp;<font color='blue'><b>** INSTALL NAME IS BLANK **</b></font>{Environment.NewLine}";
						}
						strResults = $"{strResults}&nbsp;</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>Administrator Flag</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						strResults = $"{strResults}{strSubInsAdmindFlag}";
						if (strSubInsAdmindFlag == "Yes")
						{
							strResults = $"{strResults}&nbsp;<font color='blue'><b>** SubId Administrator - OK**</b></font>{Environment.NewLine}";
						}
						strResults = $"{strResults}&nbsp;</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>Chat Flag</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						strResults = $"{strResults}{strSubInsChatFlag}&nbsp;";
						if (strSubInsChatFlag == "Yes")
						{
							strResults = $"{strResults}- Chat Is Active{Environment.NewLine}";
						}
						else
						{
							strResults = $"{strResults}- Chat Is NOT Active{Environment.NewLine}";
						}
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>Browser Name</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						strResults = $"{strResults}{strSubInsOSName}";
						if (strSubInsOSName == "")
						{
							strResults = $"{strResults}&nbsp;<font color='blue'><b>** BROWSER NAME IS BLANK **</b></font>{Environment.NewLine}";
						}
						strResults = $"{strResults}&nbsp;</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>Install Date</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						if (dtSubInsInstallDate > DateTime.FromOADate(0))
						{
							strResults = $"{strResults}{StringsHelper.Format(dtSubInsInstallDate, "mm/dd/yyyy hh:mm:ss AM/PM")}";
						}
						else
						{
							strResults = $"{strResults}&nbsp;<font color='red'><b>** NO INSTALL DATE **</b></font>{Environment.NewLine}";
							bPassed = false;
						}
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>Access Date</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						if (dtSubInsAccessDate > DateTime.FromOADate(0))
						{
							strResults = $"{strResults}{StringsHelper.Format(dtSubInsAccessDate, "mm/dd/yyyy hh:mm:ss AM/PM")}";
						}
						else
						{
							strResults = $"{strResults}&nbsp;<font color='red'><b>** NO LAST ACCESS DATE **</b></font>{Environment.NewLine}";
							bPassed = false;
						}
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>Active Flag</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						strResults = $"{strResults}{strSubInsActiveFlag}";
						if (strSubInsActiveFlag == "No")
						{
							strResults = $"{strResults}&nbsp;<font color='red'><b>** INSTALL IS NOT ACTIVE **</b></font>{Environment.NewLine}";
							bPassed = false;
						}
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>Local Notes Flag</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						strResults = $"{strResults}{strSubInsLocalNotesFlag}";
						if (strSubInsLocalNotesFlag == "Yes")
						{
							if (strSubInsLocalNotesPath == "")
							{
								strResults = $"{strResults}&nbsp;<font color='red'><b>** NOTES ENABLED BUT NO PATH **</b></font>{Environment.NewLine}";
								bPassed = false;
							}
						}
						else
						{
							// If No
							if (strSubInsLocalNotesPath != "")
							{
								strResults = $"{strResults}&nbsp;<font color='red'><b>** NOTES NOT ENABLED BUT THERE IS A PATH **</b></font>{Environment.NewLine}";
								bPassed = false;
							}
						}
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>Active X Flag</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						strResults = $"{strResults}{strSubInsActiveXFlag}";
						if (strSubInsActiveXFlag == "No")
						{
							if (strSubInsLocalNotesFlag == "Yes" && strSubInsLocalNotesPath != "")
							{
								strResults = $"{strResults}&nbsp;<font color='red'><b>** LOCAL NOTES ENABLED - ACTIVE X TURNED OFF **</b></font>{Environment.NewLine}";
								bPassed = false;
							}
						}
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>Display Local Notes Flag</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						strResults = $"{strResults}{strSubInsDisplayNotesFlag}";
						if (strSubInsDisplayNotesFlag == "No")
						{
							if (strSubInsLocalNotesFlag == "Yes" && strSubInsLocalNotesPath != "")
							{
								strResults = $"{strResults}&nbsp;<font color='blue'><b>** LOCAL NOTES ENABLED - NOT DISPLAYED ON LISTING **</b></font>{Environment.NewLine}";
							}
						}
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>Auto Check Terminal Service Flag</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						strResults = $"{strResults}{strSubInsAutoCheckTServiceFlag}&nbsp;";
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>Terminal Service Flag</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						strResults = $"{strResults}{strSubInsTerminalServiceFlag}&nbsp;";
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>EMail Reply Name</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						strResults = $"{strResults}{strSubInsEMailReplyName}&nbsp;";
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>EMail Reply Address</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						strResults = $"{strResults}{strSubInsEMailReplyAddress}&nbsp;";
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>View Id</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						strResults = $"{strResults}{lSubInsEvoViewId.ToString()}";
						if (lSubInsEvoViewId > 0)
						{
							strResults = $"{strResults} - {strSubInsEvoViewName}";
							strResults = $"{strResults}<br/><font color='blue'><b>** LOGIN MAYBE SLOW BECAUSE OF VIEW **</b></font>{Environment.NewLine}";
						}
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>SMS Text Msg Flag</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						strResults = $"{strResults}{strSubInsSMSActiveFlag}";
						if (strSubInsSMSActiveFlag != "No")
						{
							if (strSubInsCellNbr == "")
							{
								strResults = $"{strResults}&nbsp;<font color='red'><b>** SMS TEXT MSG ENABLED - NO CELL NBR ENTERED **</b></font>{Environment.NewLine}";
								bPassed = false;
							}
						}
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>SMS Text Cell Nbr</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						strResults = $"{strResults}{strSubInsCellNbr}&nbsp;";
						if (strSubInsCellNbr != "")
						{
							if (strSubInsSMSActiveFlag != "Yes")
							{
								strResults = $"{strResults}&nbsp;<font color='red'><b>** SMS TEXT MSG CELL NBR ENTERED - BUT DISABLED **</b></font>{Environment.NewLine}";
								bPassed = false;
							}
						}
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";


						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>SMS Text Cell Service</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						strResults = $"{strResults}{strSubInsSMSCellService}";
						if (strSubInsSMSCellService == "Unknown")
						{
							strResults = $"{strResults}&nbsp;<font color='red'><b>** CELL SERVICE IS INVALID **</b></font>{Environment.NewLine}";
							bPassed = false;
						}
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>SMS Text Models</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2' title='{ReturnAircraftMakeModelNames(strSubInsSMSModels)}'>";
						strResults = $"{strResults}{strSubInsSMSModels}&nbsp;";
						if (strSubInsSMSActiveFlag == "Yes")
						{
							if (strSubInsSMSModels == "" || strSubInsSMSModels == "0")
							{
								strResults = $"{strResults}&nbsp;<font color='red'><b>** SMS TEXT MSG ENABLED - NO MODELS SELECTED **</b></font>{Environment.NewLine}";
								bPassed = false;
							}
						}
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>SMS Text Events</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						strResults = $"{strResults}{strSubInsSMSEvents}&nbsp;";
						if (strSubInsSMSEvents == "")
						{
							strResults = $"{strResults}&nbsp;<font color='red'><b>** SMS TEXT MSG ENABLED - NO EVENTS SELECTED **</b></font>{Environment.NewLine}";
							bPassed = false;
						}
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>Evo Mobile Flag</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						strResults = $"{strResults}{strSubInsMobileFlag}";
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>Last Login Date</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						if (dtSubInsLastLoginDate > DateTime.FromOADate(0))
						{
							strResults = $"{strResults}{StringsHelper.Format(dtSubInsLastLoginDate, "mm/dd/yyyy hh:mm:ss AM/PM")}";
						}
						else
						{
							strResults = $"{strResults}&nbsp;<font color='red'><b>** NO LAST LOGIN DATE **</b></font>{Environment.NewLine}";
							bPassed = false;
						}
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>Last Logout Date</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						if (dtSubInsLastLogoutDate > DateTime.FromOADate(0))
						{
							strResults = $"{strResults}{StringsHelper.Format(dtSubInsLastLogoutDate, "mm/dd/yyyy hh:mm:ss AM/PM")}";
						}
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>Last Session Date</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						if (dtSubInsLastSessionDate > DateTime.FromOADate(0))
						{
							strResults = $"{strResults}{StringsHelper.Format(dtSubInsLastSessionDate, "mm/dd/yyyy hh:mm:ss AM/PM")}";
						}
						else
						{
							strResults = $"{strResults}&nbsp;<font color='red'><b>** NO LAST SESSION DATE **</b></font>{Environment.NewLine}";
							bPassed = false;
						}
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>Nbr Records Per Page</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						if (lSubInsNbrRecPerPage > 0)
						{
							strResults = $"{strResults}{lSubInsNbrRecPerPage.ToString()}";
							if (lSubInsNbrRecPerPage >= 50)
							{
								strResults = $"{strResults}&nbsp;<font color='blue'><b>** AIRCRAFT LISTINGS MAYBE SLOW **</b></font>{Environment.NewLine}";
							}
						}
						else
						{
							strResults = $"{strResults}&nbsp;<font color='red'><b>** NBR RECORD PER PAGE IS ZERO **</b></font>{Environment.NewLine}";
							bPassed = false;
						}
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>Default Model Id</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2' title='{ReturnAircraftMakeModelNames(strSubInsDefaultModelId)}'>";
						strResults = $"{strResults}{strSubInsDefaultModelId}&nbsp;";
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>Default Models</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2' title='{ReturnAircraftMakeModelNames(strSubInsDefaultModels)}'>";
						strResults = $"{strResults}{strSubInsDefaultModels}&nbsp;";
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>Default Airports</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2' title='{ReturnAirportCodesNames(strDefaultAirports)}'>";
						strResults = $"{strResults}{strDefaultAirports}&nbsp;";
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

						strResults = $"{strResults}<tr>{Environment.NewLine}";
						strResults = $"{strResults}<td nowrap align='left'>Business Type</td>{Environment.NewLine}";
						strResults = $"{strResults}<td align='left' colspan='2'>";
						strResults = $"{strResults}{strBusinessType}&nbsp;";
						if (strBusinessType == "")
						{
							strResults = $"{strResults}&nbsp;<font color='red'><b>** BUSINESS TYPE BLANK **</b></font>{Environment.NewLine}";
							bPassed = false;
						}
						strResults = $"{strResults}</td>{Environment.NewLine}";
						strResults = $"{strResults}</tr>{Environment.NewLine}{Environment.NewLine}";

						//----------------------------------

					} // If bPassed = True Then

				}
				else
				{
					strResults = $"<tr><td colspan='3'><H1>Report Parameters Invalid</H1></td></tr>{Environment.NewLine}";
					bPassed = false;
				} // If lCompId > 0 And lContactId > 0 And lSubId > 0 And strLogin <> "" And lSeqNbr >= 0 Then

				//--------------------------------------------------------------------------

				strHeader = $"<table border='1' cellpadding='0' cellspacing='0' width='750'>{Environment.NewLine}";

				strHeader = $"{strHeader}<tr>{Environment.NewLine}";
				strHeader = $"{strHeader}<th colspan='3' align='center'>{Environment.NewLine}";
				strHeader = $"{strHeader}{strDatabase} VALIDATION<BR/>";
				if (bPassed)
				{
					strHeader = $"{strHeader}<font color='blue'><b>PASSED</b></font><BR/>";
				}
				else
				{
					strHeader = $"{strHeader}<font color='red'><b>FAILED</b></font><BR/>";
				}
				strHeader = $"{strHeader}</th>{Environment.NewLine}";
				strHeader = $"{strHeader}</tr>{Environment.NewLine}";

				strFooter = $"</table>{Environment.NewLine}{Environment.NewLine}";

				strResults = $"{strHeader}{strResults}{strFooter}";
				 // frm_Subscription

				rstRec5 = null;
				rstRec4 = null;
				rstRec3 = null;
				rstRec2 = null;
				rstRec1 = null;


				return strResults;
			}
			catch (System.Exception excep)
			{

				bPassed = false;
				MessageBox.Show($"Return_Subscription_Install_Validation_Report_Error: {excep.Message}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				result = "";
			}
			return result;
		} // Return_Subscription_Install_Validation_Report

		internal static void Update_Subscription_Parent_Sub_Id()
		{

			DbConnection cntConn = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateConnection();

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			ADORecordSetHelper rstRec2 = new ADORecordSetHelper();

			string strQuery1 = "";
			string strQuery2 = "";
			string strUpdate1 = "";

			string strSubId = "";
			string strTCode = "";

			int lSubId = 0;
			int lParentSubId = 0;
			int lTCodeValue = 0;
			bool bUpdate = false;

			try
			{


				bUpdate = false;
				lParentSubId = 0;
				lTCodeValue = 0;

				strSubId = ($"{frm_Subscription.DefInstance.txt_sub_id.Text} ").Trim();

				if (strSubId != "" && strSubId != "0")
				{

					if (Information.IsNumeric(strSubId))
					{

						lSubId = Convert.ToInt32(Double.Parse(strSubId));
						strQuery1 = "SELECT sub_id, sub_parent_sub_id FROM Subscription WITH (NOLOCK) ";
						strQuery1 = $"{strQuery1}WHERE (sub_id = {strSubId}) ";

						rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

						if (!rstRec1.BOF && !rstRec1.EOF)
						{

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(rstRec1["sub_parent_sub_id"]))
							{
								lParentSubId = Convert.ToInt32(rstRec1["sub_parent_sub_id"]);
							}

							if (modCommon.OpenCustomerSQLDatabase(ref cntConn))
							{

								strQuery2 = "SELECT cstmain_id, cstmain_comp_id, cstmain_tcode, cstmain_techid, cstmain_techid_value ";
								strQuery2 = $"{strQuery2}FROM Customer_Main WITH (NOLOCK) WHERE (cstmain_techid_value = {strSubId}) ";

								rstRec2.Open(strQuery2, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

								if (!rstRec2.BOF && !rstRec2.EOF)
								{

									strTCode = "000000";
									//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
									if (!Convert.IsDBNull(rstRec2["cstmain_tcode"]))
									{
										strTCode = ($"{Convert.ToString(rstRec2["cstmain_tcode"])} ").Trim();
										strTCode = strTCode.Substring(Math.Min(1, strTCode.Length));
									}

									if (Information.IsNumeric(strTCode))
									{

										lTCodeValue = Convert.ToInt32(Double.Parse(strTCode));

										if (lParentSubId != lTCodeValue)
										{
											bUpdate = true;
										}

									} // If IsNumeric(strTCode) = True Then

								}
								else
								{
									if (lParentSubId != lSubId)
									{
										lParentSubId = lSubId;
										bUpdate = true;
									}
								} // If rstRec2.BOF = False And rstRec2.EOF = False Then

								rstRec2.Close();

								UpgradeHelpers.DB.TransactionManager.DeEnlist(cntConn);
								cntConn.Close();

							} // If OpenCustomerSQLDatabase(cntConn) = True Then

						} // If rstRec1.BOF = False And rstRec1.EOF = False Then

						rstRec1.Close();

						//------------------------
						// If Update Is Needed
						if (bUpdate)
						{

							strUpdate1 = $"UPDATE Subscription SET sub_parent_sub_id = {lTCodeValue.ToString()}, ";
							strUpdate1 = $"{strUpdate1}sub_action_date = NULL  WHERE (sub_id = {strSubId}) ";

							DbCommand TempCommand = null;
							TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
							TempCommand.CommandText = strUpdate1;
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
							TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
							TempCommand.ExecuteNonQuery(); //aey 6/21/04

						} // If bUpdate = True Then

					} // If IsNumeric(strSubId) = True Then

				} // If strSubId <> "" And strSubId <> "0" Then
				 // frm_Subscription

				rstRec2 = null;
				rstRec1 = null;
				cntConn = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"Update_Subscription_Parent_Sub_Id_Error: {excep.Message}");
			}

		} // Update_Subscription_Parent_Sub_Id_Error


		internal static bool Does_User_Install_Have_Any_Saved_Projects(int lSubId, string strLogin, int lSeqNo, ref int lTotRec)
		{

			bool result = false;
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			ADORecordSetHelper rstRec2 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strQuery2 = "";
			bool bResults = false;

			int lCnt1 = 0;
			int lCnt2 = 0;

			try
			{


				bResults = false;
				lTotRec = 0;
				lCnt1 = 0;
				lCnt2 = 0;

				search_on("Checking WebSite For Saved Projects ...");

				if (OpenRemoteDatabase())
				{

					strLogin = ($"{strLogin} ").Trim();

					//---------------------------------
					// Checking For Saved Projects

					strQuery1 = "SELECT COUNT(sissc_id) As lTotRec FROM Subscription_Install_Saved_Search_Criteria WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1}WHERE (sissc_sub_id = {lSubId.ToString()}) AND (sissc_login = '{($"{strLogin} ").Trim()}') ";

					if (lSeqNo >= 0)
					{
						strQuery1 = $"{strQuery1}AND (sissc_seq_no = {lSeqNo.ToString()}) ";
					}

					rstRec1.Open(strQuery1, frm_Subscription.DefInstance.REMOTE_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if ((!rstRec1.BOF) && (!rstRec1.EOF))
					{

						lCnt1 = Convert.ToInt32(rstRec1["lTotRec"]);
						if (lCnt1 > 0)
						{
							bResults = true;
						}

					} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

					rstRec1.Close();

					//---------------------------------
					// Checking For Folders

					strQuery1 = "SELECT COUNT(cfolder_id) As lTotRec FROM Client_Folder WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1}WHERE (cfolder_sub_id = {lSubId.ToString()}) ";
					strQuery1 = $"{strQuery1}AND (cfolder_login = '{($"{strLogin} ").Trim()}') ";

					if (lSeqNo >= 0)
					{
						strQuery1 = $"{strQuery1}AND (cfolder_seq_no = {lSeqNo.ToString()}) ";
					}

					rstRec1.Open(strQuery1, frm_Subscription.DefInstance.REMOTE_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if ((!rstRec1.BOF) && (!rstRec1.EOF))
					{

						lCnt2 = Convert.ToInt32(rstRec1["lTotRec"]);
						if (lCnt2 > 0)
						{
							bResults = true;
						}

					} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

					rstRec1.Close();

					lTotRec = lCnt1 + lCnt2;

					CloseRemoteDatabase();

				} // If OpenRemoteDatabase() = True Then

				search_off();
				 // frm_Subscription

				rstRec1 = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"Does_User_Install_Have_Any_Saved_Projects_Error: {excep.Message}");

				result = true;
			}
			return result;
		} // Does_User_Install_Have_Any_Saved_Projects

		// ===================================================================

		internal static void AddCustomerActivityRecord(int lSubId, string strNote)
		{

			DbConnection cntConn = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateConnection();
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			ADORecordSetHelper rstAdd1 = new ADORecordSetHelper();

			int lErrNbr = 0;
			string strErrDesc = "";

			string strQuery1 = "";
			string strAdd1 = "";

			int lMainId = 0;
			string strTechId = "";
			string strUserId = "";

			try
			{


				strNote = strNote.Trim();
				if (strNote != "")
				{

					if (modCommon.OpenCustomerSQLDatabase(ref cntConn))
					{

						strUserId = Convert.ToString(modAdminCommon.snp_User["user_id"]).ToUpper(); // Current User

						strQuery1 = "SELECT cstmain_id, cstmain_techid  FROM Customer_Main WITH (NOLOCK) ";
						strQuery1 = $"{strQuery1}WHERE (cstmain_techid_value = {lSubId.ToString()}) ";

						rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

						if (!rstRec1.BOF && !rstRec1.EOF)
						{

							lMainId = Convert.ToInt32(rstRec1["cstmain_id"]);
							strTechId = Convert.ToString(rstRec1["cstmain_techid"]);

							strAdd1 = "SELECT * FROM Customer_Activity WHERE (cstact_id = -1) ";
							rstAdd1.Open(strAdd1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);

							rstAdd1.AddNew();
							rstAdd1["cstact_cstmain_id"] = lMainId;
							rstAdd1["cstact_techid"] = strTechId;
							rstAdd1["cstact_techid_value"] = lSubId;
							rstAdd1["cstact_init"] = strUserId.Substring(0, Math.Min(3, strUserId.Length));
							rstAdd1["cstact_added_date"] = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy"));
							rstAdd1["cstact_added_time"] = DateTime.Parse(StringsHelper.Format(DateTime.Now, "hh:mm:ss AM/PM"));
							rstAdd1["cstact_updated_datetime"] = DateTime.Now;
							rstAdd1["cstact_note"] = strNote;

							rstAdd1.UpdateBatch();

							rstAdd1.Close();

						} // If (rstRec1.BOF = False And rstRec1.EOF = False) Then

						rstRec1.Close();

						UpgradeHelpers.DB.TransactionManager.DeEnlist(cntConn);
						cntConn.Close();

					} // If OpenCustomerSQLDatabase(cntConn) = True Then

				} // If strNote <> "" Then
				 // frm_Subscription

				rstAdd1 = null;
				rstRec1 = null;
				cntConn = null;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr = Information.Err().Number;
				strErrDesc = excep.Message;

				modAdminCommon.Report_Error($"AddCustomerActivityRecord: {strErrDesc}");
			}

		} // AddCustomerActivityRecord

		internal static void AddSubscriptionNote(int lCompId, int lSubId, string strSubject, string strNote)
		{

			string strInsert1 = "";

			int lErrNbr = 0;
			string strErrDesc = "";

			string strDateTime = "";
			string strSubId = "";
			string strDescription = "";
			string strJournId = "";
			string strCompId = "";
			string strContactId = "";
			string strUserId = "";

			try
			{


				strDateTime = modAdminCommon.GetSystemDateTime();

				strCompId = lCompId.ToString();
				strSubId = lSubId.ToString();
				strSubject = ($"{strSubject} ").Trim();
				strNote = ($"{strNote} ").Trim();

				strJournId = "0";
				strContactId = "0";

				strUserId = ($"{Convert.ToString(modAdminCommon.snp_User["user_id"])} ").Trim().ToUpper();

				if (strSubId != "0" && strSubId != "")
				{

					if (strCompId != "0" && strCompId != "")
					{

						if (strSubject != "")
						{

							// Add or Save
							if ((strJournId == "0") || (strJournId == ""))
							{

								strSubject = StringsHelper.Replace(strSubject, "'", "''", 1, -1, CompareMethod.Binary);
								strNote = StringsHelper.Replace(strNote, "'", "''", 1, -1, CompareMethod.Binary);

								strInsert1 = "INSERT INTO Journal (journ_subcategory_code, journ_subject, journ_description, ";
								strInsert1 = $"{strInsert1}journ_comp_id, journ_user_id, journ_entry_date, ";
								strInsert1 = $"{strInsert1}journ_entry_time, journ_action_date ";
								strInsert1 = $"{strInsert1}) VALUES ('SN',";
								strInsert1 = $"{strInsert1}'{strSubject}',";
								strInsert1 = $"{strInsert1}'{strNote}',";
								strInsert1 = $"{strInsert1}{strCompId},";
								strInsert1 = $"{strInsert1}'{strUserId}',";
								System.DateTime TempDate2 = DateTime.FromOADate(0);
								strInsert1 = $"{strInsert1}'{((DateTime.TryParse(strDateTime, out TempDate2)) ? TempDate2.ToString("MM/dd/yyyy") : strDateTime)}',";
								strInsert1 = $"{strInsert1}'{StringsHelper.Format(strDateTime, "hh:mm:ss AM/PM")}',";
								strInsert1 = $"{strInsert1}GetDate()";
								strInsert1 = $"{strInsert1})";

								DbCommand TempCommand = null;
								TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
								UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
								TempCommand.CommandText = strInsert1;
								//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
								//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
								TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
								UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
								TempCommand.ExecuteNonQuery();

							} // If (strJournId = "0") Or (strJournId = "") Then

						} // strSubject <> "" Then

					} // If strCompId <> "0" And strCompId <> "" Then

				} // If strSubId <> "0" And strSubId <> "" Then
				 // frm_Subscription
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr = Information.Err().Number;
				strErrDesc = excep.Message;

				modAdminCommon.Report_Error($"AddSubscriptionNote_Error: {strErrDesc}");
			}

		} // AddSubscriptionNote

		internal static bool Update_Customer_Main_And_Contact_Record(DbConnection cntConn, int lCompIdCurr, int lCompIdNew, int lSubId, string strContactId, ref string strErrMsg)
		{

			bool result = false;
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string[] aContactId1 = null; // ContactIdCurr|ContactIdNew|Login|ContactName
			string[] aContactId2 = null;

			int lTot1 = 0;
			int lTot2 = 0;
			int lCnt1 = 0;
			int lCnt2 = 0;

			int lErrNbr = 0;
			string strErrDesc = "";

			bool bResults = false;

			int lChg = 0;

			int lContactIdCurr = 0;
			int lContactIdNew = 0;

			string strLogin = "";
			string strCONTACTNAME = "";

			try
			{


				bResults = false;

				strContactId = strContactId.Trim();

				if (strContactId != "")
				{

					search_on($"Moving Customer Main Record: {lSubId.ToString()}", "");

					strQuery1 = $"SELECT * FROM Customer_Main WHERE (cstmain_techid_value = {lSubId.ToString()}) ";

					rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
					rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						rstRec1["cstmain_comp_id"] = lCompIdNew;
						rstRec1["cstmain_datechg"] = DateTime.Now;
						rstRec1.UpdateBatch();

					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

					//--------------------------------------------------------
					// Now Contacts

					aContactId1 = strContactId.Split(Environment.NewLine[0]);

					lTot1 = aContactId1.GetUpperBound(0);

					if (lTot1 > 0)
					{

						lCnt1 = -1;

						do 
						{ // Loop Until lCnt1 >= lTot1 - 1

							lCnt1++;

							aContactId2 = aContactId1[lCnt1].Split('|');

							if (Information.IsNumeric(aContactId2[0]) && Information.IsNumeric(aContactId2[1]))
							{

								lContactIdCurr = Convert.ToInt32(Double.Parse(aContactId2[0]));
								lContactIdNew = Convert.ToInt32(Double.Parse(aContactId2[1]));
								strLogin = aContactId2[2];
								strCONTACTNAME = aContactId2[3];

								strQuery1 = "SELECT * FROM Customer_Contact ";
								strQuery1 = $"{strQuery1}WHERE (cstcontact_techid_value = {lSubId.ToString()}) ";
								rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
								rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);

								if (!rstRec1.BOF && !rstRec1.EOF)
								{

									lTot2 = rstRec1.RecordCount;

									lCnt2 = 0;
									do 
									{ // Loop Until rstRec1.EOF = True

										lCnt2++;

										rstRec1["cstcontact_hbcontact_id"] = lContactIdNew;
										rstRec1["cstcontact_date_updated"] = DateTime.Now;
										rstRec1.UpdateBatch();

										rstRec1.MoveNext();
										Application.DoEvents();

									}
									while(!rstRec1.EOF);

								} // If rstRec1.BOF = False And rstRec1.EOF = False Then

								rstRec1.Close();

							} // If IsNumeric(aContactId2(0)) = True And IsNumeric(aContactId2(1)) = True Then

						}
						while(lCnt1 < lTot1 - 1);

						bResults = true;

					}
					else
					{
						strErrMsg = "Customer Main/Contact - Contact Id Unable To Split.  Can NOT Move";
					} // If lTot1> 0 Then

					search_off();

				}
				else
				{
					strErrMsg = "Customer Main/Contact - Contact Id Is Blank.  Nothing To Move";
				} // If strContactId <> "" Then
				 // frm_Subscription

				rstRec1 = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr = Information.Err().Number;
				strErrDesc = excep.Message;

				modAdminCommon.Report_Error($"Update_Customer_Main_And_Contact_Record_Error: {strErrDesc}");

				result = false;
			}
			return result;
		} // Update_Customer_Main_And_Contact_Record

		internal static bool Move_All_Subscription_Record(string strWhere, int lCompIdCurr, int lCompIdNew, int lSubId, ref int lNbrChg, ref string strErrMsg)
		{

			bool result = false;
			int lErrNbr = 0;
			string strErrDesc = "";

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			bool bResults = false;

			int lCnt1 = 0;
			int lTot1 = 0;

			try
			{


				bResults = false;

				search_on($"Moving Subscription Record In {strWhere}", $"SubId: {lSubId.ToString()}");

				strQuery1 = $"SELECT * FROM Subscription WHERE (sub_id = {lSubId.ToString()}) ";

				rstRec1.CursorLocation = CursorLocationEnum.adUseClient;

				switch(strWhere)
				{
					case "Homebase" : 
						rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
						break;
					case "Evolution" : 
						rstRec1.Open(strQuery1, frm_Subscription.DefInstance.REMOTE_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
						break;
				}

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					lTot1 = rstRec1.RecordCount;

					lCnt1 = 0;
					do 
					{ // Loop Until rstRec1.EOF = True

						lNbrChg++;
						lCnt1++;

						rstRec1["sub_comp_id"] = lCompIdNew;
						rstRec1["sub_upd_date"] = DateTime.Now;
						rstRec1["sub_upd_user_id"] = modAdminCommon.snp_User["user_id"];
						rstRec1.UpdateBatch();

						rstRec1.MoveNext();
						Application.DoEvents();

					}
					while(!rstRec1.EOF);

				} // If rstRec1.BOF = False And rstRec1.EOF = False Then

				bResults = true;

				rstRec1.Close();

				search_off();
				 // frm_Subscription

				rstRec1 = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr = Information.Err().Number;
				strErrMsg = excep.Message;

				modAdminCommon.Report_Error($"Move_All_Subscription_Record_Error: {strErrMsg}");

				result = false;
			}
			return result;
		} // Move_All_Subscription_Record

		internal static bool Move_All_Subscription_Install_With_New_Contact_Id(string strWhere, int lCompIdCurr, int lCompIdNew, int lSubId, string strContactId, ref int lNbrChg, ref string strErrMsg)
		{

			bool result = false;
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string[] aContactId1 = null; // ContactIdCurr|ContactIdNew|Login|ContactName
			string[] aContactId2 = null;

			int lTot1 = 0;
			int lTot2 = 0;
			int lCnt1 = 0;
			int lCnt2 = 0;

			int lErrNbr = 0;
			string strErrDesc = "";

			bool bResults = false;

			string strReplace1 = "";
			string strReplace2 = "";
			int lChg = 0;

			int lContactIdCurr = 0;
			int lContactIdNew = 0;

			string strLogin = "";
			string strCONTACTNAME = "";

			try
			{


				bResults = false;

				strContactId = strContactId.Trim();

				if (strContactId != "")
				{

					search_on($"Moving Subscription Install With New Contact Id In {strWhere}", "");

					aContactId1 = strContactId.Split(Environment.NewLine[0]);

					lTot1 = aContactId1.GetUpperBound(0);

					if (lTot1 > 0)
					{

						lCnt1 = -1;

						do 
						{ // Loop Until lCnt1 >= lTot1 - 1

							lCnt1++;

							aContactId2 = aContactId1[lCnt1].Split('|');

							if (Information.IsNumeric(aContactId2[0]) && Information.IsNumeric(aContactId2[1]))
							{

								lContactIdCurr = Convert.ToInt32(Double.Parse(aContactId2[0]));
								lContactIdNew = Convert.ToInt32(Double.Parse(aContactId2[1]));
								strLogin = aContactId2[2];
								strCONTACTNAME = aContactId2[3];

								strQuery1 = "SELECT * FROM Subscription_Install ";
								strQuery1 = $"{strQuery1}WHERE (subins_sub_id = {lSubId.ToString()}) ";
								strQuery1 = $"{strQuery1}AND (subins_login = '{strLogin}') ";
								strQuery1 = $"{strQuery1}AND (subins_contact_id = {lContactIdCurr.ToString()} OR subins_contact_id = 0) ";

								rstRec1.CursorLocation = CursorLocationEnum.adUseClient;

								switch(strWhere)
								{
									case "Homebase" : 
										rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
										break;
									case "Evolution" : 
										rstRec1.Open(strQuery1, frm_Subscription.DefInstance.REMOTE_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
										break;
								}

								if (!rstRec1.BOF && !rstRec1.EOF)
								{

									lTot2 = rstRec1.RecordCount;

									lCnt2 = 0;
									do 
									{ // Loop Until rstRec1.EOF = True

										lCnt2++;
										lNbrChg++;

										search_on($"Moving Subscription Install With New Contact Id In {strWhere}", $"Install: ({strLogin}) - {strCONTACTNAME} - {StringsHelper.Format(lCnt2, "#,###")} of {StringsHelper.Format(lTot2, "#,###")}");

										rstRec1["subins_contact_id"] = lContactIdNew;
										rstRec1.UpdateBatch();

										rstRec1.MoveNext();
										Application.DoEvents();

									}
									while(!rstRec1.EOF);

								} // If rstRec1.BOF = False And rstRec1.EOF = False Then

								rstRec1.Close();

							} // If IsNumeric(aContactId2(0)) = True And IsNumeric(aContactId2(1)) = True Then

						}
						while(lCnt1 < lTot1 - 1);

						bResults = true;

					}
					else
					{
						strErrMsg = "Subscription Install New Contact Id Unable To Split.  Can NOT Move";
					} // If lTot1> 0 Then

					search_off();

				}
				else
				{
					strErrMsg = "Subscription Install New Contact Id Is Blank.  Nothing To Move";
				} // If strContactId <> "" Then
				 // frm_Subscription

				rstRec1 = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr = Information.Err().Number;
				strErrMsg = excep.Message;

				modAdminCommon.Report_Error($"Move_All_Subscription_Install_With_New_Contact_Id_Error: {strErrMsg}");

				result = false;
			}
			return result;
		} // Move_All_Subscription_Install_With_New_Contact_Id

		internal static bool Move_All_Login_Subscription_Installs(string strWhere, int lCompId, string strLogin, int lContactId, int lCurrSubId, int lNewSubId, ref int lNbrChg, ref string strErrMsg)
		{

			bool result = false;
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			int lErrNbr = 0;
			string strErrDesc = "";

			bool bResults = false;

			int lTot2 = 0;
			int lCnt2 = 0;
			int lChg = 0;

			try
			{

				bResults = false;


				if (strWhere != "" && lCompId > 0 && strLogin != "" && lContactId > 0 && lCurrSubId > 0 && lNewSubId > 0)
				{

					strQuery1 = $"SELECT * FROM Subscription_Install WHERE (subins_sub_id = {lCurrSubId.ToString()}) ";
					strQuery1 = $"{strQuery1}AND (subins_login = '{strLogin}')  AND (subins_contact_id = {lContactId.ToString()} OR subins_contact_id = 0) ";

					rstRec1.CursorLocation = CursorLocationEnum.adUseClient;

					switch(strWhere)
					{
						case "Homebase" : 
							rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
							break;
						case "Evolution" : 
							rstRec1.Open(strQuery1, frm_Subscription.DefInstance.REMOTE_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
							break;
					}

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						lTot2 = rstRec1.RecordCount;

						lCnt2 = 0;
						do 
						{ // Loop Until rstRec1.EOF = True

							lCnt2++;
							lNbrChg++;

							rstRec1["subins_sub_id"] = lNewSubId;
							rstRec1.UpdateBatch();

							rstRec1.MoveNext();
							Application.DoEvents();

						}
						while(!rstRec1.EOF);

					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

				} // If strWhere <> "" And lCompId > 0 And strLogin <> "" And lContactId > 0 And lCurrSubId > 0 And lNewSubId > 0 Then
				 // frm_Subscription

				bResults = true;

				rstRec1 = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr = Information.Err().Number;
				strErrMsg = excep.Message;

				modAdminCommon.Report_Error($"Move_All_Login_Subscription_Installs_Error: {strErrMsg}");

				result = false;
			}
			return result;
		} // Move_All_Login_Subscription_Installs

		internal static bool Move_All_Login_Subscription_Login(string strWhere, int lCompId, string strLogin, int lCurrSubId, int lNewSubId, ref int lNbrChg, ref string strErrMsg)
		{

			bool result = false;
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			int lErrNbr = 0;
			string strErrDesc = "";

			bool bResults = false;

			int lTot2 = 0;
			int lCnt2 = 0;
			int lChg = 0;

			try
			{

				bResults = false;


				if (strWhere != "" && lCompId > 0 && strLogin != "" && lCurrSubId > 0 && lNewSubId > 0)
				{

					strQuery1 = $"SELECT * FROM Subscription_Login WHERE (sublogin_sub_id = {lCurrSubId.ToString()}) ";
					strQuery1 = $"{strQuery1}AND (sublogin_login = '{strLogin}') ";

					rstRec1.CursorLocation = CursorLocationEnum.adUseClient;

					switch(strWhere)
					{
						case "Homebase" : 
							rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
							break;
						case "Evolution" : 
							rstRec1.Open(strQuery1, frm_Subscription.DefInstance.REMOTE_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
							break;
					}

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						lTot2 = rstRec1.RecordCount;

						lCnt2 = 0;
						do 
						{ // Loop Until rstRec1.EOF = True

							lCnt2++;
							lNbrChg++;

							rstRec1["sublogin_sub_id"] = lNewSubId;
							rstRec1.UpdateBatch();

							rstRec1.MoveNext();
							Application.DoEvents();

						}
						while(!rstRec1.EOF);

					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

				} // If strWhere <> "" And lCompId > 0 And strLogin <> "" And lContactId > 0 And lCurrSubId > 0 And lNewSubId > 0 Then
				 // frm_Subscription

				bResults = true;

				rstRec1 = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr = Information.Err().Number;
				strErrMsg = excep.Message;

				modAdminCommon.Report_Error($"Move_All_Login_Subscription_Login_Error: {strErrMsg}");

				result = false;
			}
			return result;
		} // Move_All_Login_Subscription_Login

		internal static bool Move_All_Login_Subscription_Saved_Projects(string strWhere, int lCompId, string strLogin, int lContactId, int lCurrSubId, int lNewSubId, ref int lNbrChg, ref string strErrMsg)
		{

			bool result = false;
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			int lErrNbr = 0;
			string strErrDesc = "";

			bool bResults = false;

			int lTot2 = 0;
			int lCnt2 = 0;
			int lChg = 0;

			try
			{

				bResults = false;


				if (strWhere != "" && lCompId > 0 && strLogin != "" && lContactId > 0 && lCurrSubId > 0 && lNewSubId > 0)
				{

					strQuery1 = "SELECT * FROM Subscription_Install_Saved_Search_Criteria ";
					strQuery1 = $"{strQuery1}WHERE (sissc_sub_id = {lCurrSubId.ToString()}) AND (sissc_login = '{strLogin}') ";

					rstRec1.CursorLocation = CursorLocationEnum.adUseClient;

					switch(strWhere)
					{
						case "Homebase" : 
							rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
							break;
						case "Evolution" : 
							rstRec1.Open(strQuery1, frm_Subscription.DefInstance.REMOTE_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
							break;
					}

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						lTot2 = rstRec1.RecordCount;

						lCnt2 = 0;
						do 
						{ // Loop Until rstRec1.EOF = True

							lCnt2++;
							lNbrChg++;

							rstRec1["sissc_sub_id"] = lNewSubId;
							rstRec1.UpdateBatch();

							rstRec1.MoveNext();
							Application.DoEvents();

						}
						while(!rstRec1.EOF);

					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

				} // If strWhere <> "" And lCompId > 0 And strLogin <> "" And lCurrSubId > 0 And lNewSubId > 0 Then
				 // frm_Subscription

				bResults = true;

				rstRec1 = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr = Information.Err().Number;
				strErrMsg = excep.Message;

				modAdminCommon.Report_Error($"Move_All_Login_Subscription_Saved_Projects_Error: {strErrMsg}");

				result = false;
			}
			return result;
		} // Move_All_Login_Subscription_Saved_Projects

		internal static bool Move_All_Login_Subscription_Saved_Folders(string strWhere, int lCompId, string strLogin, int lContactId, int lCurrSubId, int lNewSubId, ref int lNbrChg, ref string strErrMsg)
		{

			bool result = false;
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			int lErrNbr = 0;
			string strErrDesc = "";

			bool bResults = false;

			int lTot2 = 0;
			int lCnt2 = 0;
			int lChg = 0;

			try
			{

				bResults = false;


				if (strWhere != "" && lCompId > 0 && strLogin != "" && lContactId > 0 && lCurrSubId > 0 && lNewSubId > 0)
				{

					strQuery1 = $"SELECT * FROM Client_Folder WHERE (cfolder_sub_id = {lCurrSubId.ToString()}) ";
					strQuery1 = $"{strQuery1}AND (cfolder_login = '{strLogin}') ";

					rstRec1.CursorLocation = CursorLocationEnum.adUseClient;

					switch(strWhere)
					{
						case "Homebase" : 
							rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
							break;
						case "Evolution" : 
							rstRec1.Open(strQuery1, frm_Subscription.DefInstance.REMOTE_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
							break;
					}

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						lTot2 = rstRec1.RecordCount;

						lCnt2 = 0;
						do 
						{ // Loop Until rstRec1.EOF = True

							lCnt2++;
							lNbrChg++;

							rstRec1["cfolder_sub_id"] = lNewSubId;
							rstRec1.UpdateBatch();

							rstRec1.MoveNext();
							Application.DoEvents();

						}
						while(!rstRec1.EOF);

					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

				} // If strWhere <> "" And lCompId > 0 And strLogin <> "" And lCurrSubId > 0 And lNewSubId > 0 Then
				 // frm_Subscription

				bResults = true;

				rstRec1 = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr = Information.Err().Number;
				strErrMsg = excep.Message;

				modAdminCommon.Report_Error($"Move_All_Login_Subscription_Saved_Folders_Error: {strErrMsg}");

				result = false;
			}
			return result;
		} // Move_All_Login_Subscription_Saved_Folders

		internal static bool Move_All_Login_Subscription_Saved_Custom_Export(string strWhere, int lCompId, string strLogin, int lContactId, int lCurrSubId, int lNewSubId, ref int lNbrChg, ref string strErrMsg)
		{

			bool result = false;
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			int lErrNbr = 0;
			string strErrDesc = "";

			bool bResults = false;

			int lTot2 = 0;
			int lCnt2 = 0;
			int lChg = 0;

			try
			{

				bResults = false;


				if (strWhere != "" && lCompId > 0 && strLogin != "" && lContactId > 0 && lCurrSubId > 0 && lNewSubId > 0)
				{

					strQuery1 = "SELECT * FROM Subscription_Install_Saved_Exports ";
					strQuery1 = $"{strQuery1}WHERE (sise_sub_id = {lCurrSubId.ToString()}) AND (sise_login = '{strLogin}') ";

					rstRec1.CursorLocation = CursorLocationEnum.adUseClient;

					switch(strWhere)
					{
						case "Homebase" : 
							rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
							break;
						case "Evolution" : 
							rstRec1.Open(strQuery1, frm_Subscription.DefInstance.REMOTE_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
							break;
					}

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						lTot2 = rstRec1.RecordCount;

						lCnt2 = 0;
						do 
						{ // Loop Until rstRec1.EOF = True

							lCnt2++;
							lNbrChg++;

							rstRec1["sise_sub_id"] = lNewSubId;
							rstRec1.UpdateBatch();

							rstRec1.MoveNext();
							Application.DoEvents();

						}
						while(!rstRec1.EOF);

					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

				} // If strWhere <> "" And lCompId > 0 And strLogin <> "" And lCurrSubId > 0 And lNewSubId > 0 Then
				 // frm_Subscription

				bResults = true;

				rstRec1 = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr = Information.Err().Number;
				strErrMsg = excep.Message;

				modAdminCommon.Report_Error($"Move_All_Login_Subscription_Saved_Custom_Export_Error: {strErrMsg}");

				result = false;
			}
			return result;
		} // Move_All_Login_Subscription_Saved_Custom_Export

		internal static bool Move_All_Login_Subscription_User_Agent_String(string strWhere, int lCompId, string strLogin, int lCurrSubId, int lNewSubId, ref int lNbrChg, ref string strErrMsg)
		{

			bool result = false;
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			int lErrNbr = 0;
			string strErrDesc = "";

			bool bResults = false;

			int lTot2 = 0;
			int lCnt2 = 0;
			int lChg = 0;

			try
			{

				bResults = false;


				if (strWhere != "" && lCompId > 0 && strLogin != "" && lCurrSubId > 0 && lNewSubId > 0)
				{

					strQuery1 = $"SELECT * FROM Subscription_User_Agent_String WHERE (suas_sub_id = {lCurrSubId.ToString()}) ";
					strQuery1 = $"{strQuery1}AND (suas_login = '{strLogin}') ";

					rstRec1.CursorLocation = CursorLocationEnum.adUseClient;

					switch(strWhere)
					{
						case "Homebase" : 
							rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
							break;
						case "Evolution" : 
							rstRec1.Open(strQuery1, frm_Subscription.DefInstance.REMOTE_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
							break;
					}

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						lTot2 = rstRec1.RecordCount;

						lCnt2 = 0;
						do 
						{ // Loop Until rstRec1.EOF = True

							lCnt2++;
							lNbrChg++;

							rstRec1["suas_sub_id"] = lNewSubId;
							rstRec1.UpdateBatch();

							rstRec1.MoveNext();
							Application.DoEvents();

						}
						while(!rstRec1.EOF);

					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

				} // If strWhere <> "" And lCompId > 0 And strLogin <> "" And lCurrSubId > 0 And lNewSubId > 0 Then
				 // frm_Subscription

				bResults = true;

				rstRec1 = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr = Information.Err().Number;
				strErrMsg = excep.Message;

				modAdminCommon.Report_Error($"Move_All_Login_Subscription_User_Agent_String_Error: {strErrMsg}");

				result = false;
			}
			return result;
		} // Move_All_Login_Subscription_User_Agent_String

		internal static bool Move_All_Login_Subscription_Notifications(string strWhere, int lCompId, string strLogin, int lCurrSubId, int lNewSubId, ref int lNbrChg, ref string strErrMsg)
		{

			bool result = false;
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			int lErrNbr = 0;
			string strErrDesc = "";

			bool bResults = false;

			int lTot2 = 0;
			int lCnt2 = 0;
			int lChg = 0;

			try
			{

				bResults = false;


				if (strWhere != "" && lCompId > 0 && strLogin != "" && lCurrSubId > 0 && lNewSubId > 0)
				{

					strQuery1 = $"SELECT * FROM Subscription_Notifications WHERE (subnot_sub_id = {lCurrSubId.ToString()}) ";
					strQuery1 = $"{strQuery1}AND (subnot_login = '{strLogin}') ";

					rstRec1.CursorLocation = CursorLocationEnum.adUseClient;

					switch(strWhere)
					{
						case "Homebase" : 
							rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
							break;
						case "Evolution" : 
							rstRec1.Open(strQuery1, frm_Subscription.DefInstance.REMOTE_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
							break;
					}

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						lTot2 = rstRec1.RecordCount;

						lCnt2 = 0;
						do 
						{ // Loop Until rstRec1.EOF = True

							lCnt2++;
							lNbrChg++;

							rstRec1["subnot_sub_id"] = lNewSubId;
							rstRec1.UpdateBatch();

							rstRec1.MoveNext();
							Application.DoEvents();

						}
						while(!rstRec1.EOF);

					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

				} // If strWhere <> "" And lCompId > 0 And strLogin <> "" And lCurrSubId > 0 And lNewSubId > 0 Then
				 // frm_Subscription

				bResults = true;

				rstRec1 = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr = Information.Err().Number;
				strErrMsg = excep.Message;

				modAdminCommon.Report_Error($"Move_All_Login_Subscription_Notifications_Error: {strErrMsg}");

				result = false;
			}
			return result;
		} // Move_All_Login_Subscription_Notifications

		internal static bool Move_All_Login_Subscription_Install_Models(string strWhere, int lCompId, string strLogin, int lCurrSubId, int lNewSubId, ref int lNbrChg, ref string strErrMsg)
		{

			bool result = false;
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			int lErrNbr = 0;
			string strErrDesc = "";

			bool bResults = false;

			int lTot2 = 0;
			int lCnt2 = 0;
			int lChg = 0;

			try
			{

				bResults = false;


				if (strWhere != "" && lCompId > 0 && strLogin != "" && lCurrSubId > 0 && lNewSubId > 0)
				{

					strQuery1 = $"SELECT * FROM Subscription_Install_Models WHERE (sim_sub_id = {lCurrSubId.ToString()}) ";
					strQuery1 = $"{strQuery1}AND (sim_login = '{strLogin}') ";

					rstRec1.CursorLocation = CursorLocationEnum.adUseClient;

					switch(strWhere)
					{
						case "Homebase" : 
							rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
							break;
						case "Evolution" : 
							rstRec1.Open(strQuery1, frm_Subscription.DefInstance.REMOTE_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
							break;
					}

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						lTot2 = rstRec1.RecordCount;

						lCnt2 = 0;
						do 
						{ // Loop Until rstRec1.EOF = True

							lCnt2++;
							lNbrChg++;

							rstRec1["sim_sub_id"] = lNewSubId;
							rstRec1.UpdateBatch();

							rstRec1.MoveNext();
							Application.DoEvents();

						}
						while(!rstRec1.EOF);

					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

				} // If strWhere <> "" And lCompId > 0 And strLogin <> "" And lCurrSubId > 0 And lNewSubId > 0 Then
				 // frm_Subscription

				bResults = true;

				rstRec1 = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr = Information.Err().Number;
				strErrMsg = excep.Message;

				modAdminCommon.Report_Error($"Move_All_Login_Subscription_Install_Models_Error: {strErrMsg}");

				result = false;
			}
			return result;
		} // Move_All_Login_Subscription_Install_Models

		internal static bool Move_All_Login_Subscription_EULA_Log(string strWhere, int lCompId, string strLogin, int lContactId, int lCurrSubId, int lNewSubId, ref int lNbrChg, ref string strErrMsg)
		{

			bool result = false;
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			int lErrNbr = 0;
			string strErrDesc = "";

			bool bResults = false;

			int lTot2 = 0;
			int lCnt2 = 0;
			int lChg = 0;

			try
			{

				bResults = false;


				if (strWhere != "" && lCompId > 0 && strLogin != "" && lContactId > 0 && lCurrSubId > 0 && lNewSubId > 0)
				{

					strQuery1 = $"SELECT * FROM Subscription_EULA_Log WHERE (seulal_sub_id = {lCurrSubId.ToString()}) ";
					strQuery1 = $"{strQuery1}AND (seulal_contact_id = {lContactId.ToString()}) AND (seulal_login = '{strLogin}') ";

					rstRec1.CursorLocation = CursorLocationEnum.adUseClient;

					switch(strWhere)
					{
						case "Homebase" : 
							rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
							break;
						case "Evolution" : 
							rstRec1.Open(strQuery1, frm_Subscription.DefInstance.REMOTE_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
							break;
					}

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						lTot2 = rstRec1.RecordCount;

						lCnt2 = 0;
						do 
						{ // Loop Until rstRec1.EOF = True

							lCnt2++;
							lNbrChg++;

							rstRec1["seulal_sub_id"] = lNewSubId;
							rstRec1.UpdateBatch();

							rstRec1.MoveNext();
							Application.DoEvents();

						}
						while(!rstRec1.EOF);

					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

				} // If strWhere <> "" And lCompId > 0 And strLogin <> "" And lContactId > 0 And lCurrSubId > 0 And lNewSubId > 0 Then
				 // frm_Subscription

				bResults = true;

				rstRec1 = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr = Information.Err().Number;
				strErrMsg = excep.Message;

				modAdminCommon.Report_Error($"Move_All_Login_Subscription_EULA_Log_Error: {strErrMsg}");

				result = false;
			}
			return result;
		} // Move_All_Login_Subscription_EULA_Log

		internal static bool Move_All_Login_Subscription_SQL_Report(string strWhere, int lCompId, string strLogin, int lContactId, int lCurrSubId, int lNewSubId, ref int lNbrChg, ref string strErrMsg)
		{

			bool result = false;
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			int lErrNbr = 0;
			string strErrDesc = "";

			bool bResults = false;

			int lTot2 = 0;
			int lCnt2 = 0;
			int lChg = 0;

			try
			{

				bResults = false;


				if (strWhere != "" && lCompId > 0 && strLogin != "" && lContactId > 0 && lCurrSubId > 0 && lNewSubId > 0)
				{

					strQuery1 = $"SELECT * FROM SQL_Report WHERE (sqlrep_sub_id = {lCurrSubId.ToString()}) ";
					strQuery1 = $"{strQuery1}AND (sqlrep_contact_id = {lContactId.ToString()}) ";

					rstRec1.CursorLocation = CursorLocationEnum.adUseClient;

					switch(strWhere)
					{
						case "Homebase" : 
							rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
							break;
						case "Evolution" : 
							rstRec1.Open(strQuery1, frm_Subscription.DefInstance.REMOTE_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
							break;
					}

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						lTot2 = rstRec1.RecordCount;

						lCnt2 = 0;
						do 
						{ // Loop Until rstRec1.EOF = True

							lCnt2++;
							lNbrChg++;

							rstRec1["sqlrep_sub_id"] = lNewSubId;
							rstRec1.UpdateBatch();

							rstRec1.MoveNext();
							Application.DoEvents();

						}
						while(!rstRec1.EOF);

					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

				} // If strWhere <> "" And lCompId > 0 And strLogin <> "" And lContactId > 0 And lCurrSubId > 0 And lNewSubId > 0 Then
				 // frm_Subscription

				bResults = true;

				rstRec1 = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr = Information.Err().Number;
				strErrMsg = excep.Message;

				modAdminCommon.Report_Error($"Move_All_Login_Subscription_SQL_Report_Error: {strErrMsg}");

				result = false;
			}
			return result;
		} // Move_All_Login_Subscription_SQL_Report

		internal static bool Move_All_Login_Subscription_Evolution_SessionVars(string strWhere, int lCompId, string strLogin, int lContactId, int lCurrSubId, int lNewSubId, ref int lNbrChg, ref string strErrMsg)
		{

			bool result = false;
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			int lErrNbr = 0;
			string strErrDesc = "";

			bool bResults = false;

			int lTot2 = 0;
			int lCnt2 = 0;
			int lChg = 0;

			try
			{

				bResults = false;


				if (strWhere != "" && lCompId > 0 && strLogin != "" && lCurrSubId > 0 && lNewSubId > 0)
				{

					strQuery1 = $"SELECT * FROM Evolution_SessionVars WHERE (session_vars_sub_id = {lCurrSubId.ToString()}) ";
					strQuery1 = $"{strQuery1}AND (session_vars_login = '{strLogin}') ";

					rstRec1.CursorLocation = CursorLocationEnum.adUseClient;

					switch(strWhere)
					{
						case "Homebase" : 
							rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
							break;
						case "Evolution" : 
							rstRec1.Open(strQuery1, frm_Subscription.DefInstance.REMOTE_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
							break;
					}

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						lTot2 = rstRec1.RecordCount;

						lCnt2 = 0;
						do 
						{ // Loop Until rstRec1.EOF = True

							lCnt2++;
							lNbrChg++;

							rstRec1["session_vars_sub_id"] = lNewSubId;
							rstRec1.UpdateBatch();

							rstRec1.MoveNext();
							Application.DoEvents();

						}
						while(!rstRec1.EOF);

					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

				} // If strWhere <> "" And lCompId > 0 And strLogin <> "" And lCurrSubId > 0 And lNewSubId > 0 Then
				 // frm_Subscription

				bResults = true;

				rstRec1 = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr = Information.Err().Number;
				strErrMsg = excep.Message;

				modAdminCommon.Report_Error($"Move_All_Login_Subscription_Evolution_SessionVars_Error: {strErrMsg}");

				result = false;
			}
			return result;
		} // Move_All_Login_Subscription_Evolution_SessionVars

		internal static bool Move_All_Login_Subscription_Evolution_Content_Stats(string strWhere, int lCompId, string strLogin, int lContactId, int lCurrSubId, int lNewSubId, ref int lNbrChg, ref string strErrMsg)
		{

			bool result = false;
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			int lErrNbr = 0;
			string strErrDesc = "";

			bool bResults = false;

			int lTot2 = 0;
			int lCnt2 = 0;
			int lChg = 0;

			try
			{

				bResults = false;


				if (strWhere != "" && lCompId > 0 && strLogin != "" && lCurrSubId > 0 && lNewSubId > 0)
				{

					strQuery1 = $"SELECT * FROM Evolution_Content_Stats WHERE (ecs_sub_id = {lCurrSubId.ToString()}) ";
					strQuery1 = $"{strQuery1}AND (ecs_login = '{strLogin}') ";

					rstRec1.CursorLocation = CursorLocationEnum.adUseClient;

					switch(strWhere)
					{
						case "Homebase" : 
							rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
							break;
						case "Evolution" : 
							rstRec1.Open(strQuery1, frm_Subscription.DefInstance.REMOTE_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
							break;
					}

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						lTot2 = rstRec1.RecordCount;

						lCnt2 = 0;
						do 
						{ // Loop Until rstRec1.EOF = True

							lCnt2++;
							lNbrChg++;

							rstRec1["ecs_sub_id"] = lNewSubId;
							rstRec1.UpdateBatch();

							rstRec1.MoveNext();

						}
						while(!rstRec1.EOF);

					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

				} // If strWhere <> "" And lCompId > 0 And strLogin <> "" And lCurrSubId > 0 And lNewSubId > 0 Then
				 // frm_Subscription

				bResults = true;

				rstRec1 = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr = Information.Err().Number;
				strErrMsg = excep.Message;

				modAdminCommon.Report_Error($"Move_All_Login_Subscription_Evolution_Content_Stats_Error: {strErrMsg}");

				result = false;
			}
			return result;
		} // Move_All_Login_Subscription_Evolution_Content_Stats

		internal static bool Move_All_Login_Subscription_Chat_Message(string strWhere, int lCompId, string strLogin, int lContactId, int lCurrSubId, int lNewSubId, ref int lNbrChg, ref string strErrMsg)
		{

			bool result = false;
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			int lErrNbr = 0;
			string strErrDesc = "";

			bool bResults = false;

			int lTot2 = 0;
			int lCnt2 = 0;
			int lChg = 0;

			try
			{

				bResults = false;


				if (strWhere != "" && lCompId > 0 && strLogin != "" && lContactId > 0 && lCurrSubId > 0 && lNewSubId > 0)
				{

					strQuery1 = "SELECT * FROM Chat_Message ";
					strQuery1 = $"{strQuery1}WHERE (";
					strQuery1 = $"{strQuery1}            chatmsg_from_comp_id = {lCompId.ToString()} ";
					strQuery1 = $"{strQuery1}        AND chatmsg_from_contact_id = {lContactId.ToString()} ";
					strQuery1 = $"{strQuery1}        AND chatmsg_from_sub_id = {lCurrSubId.ToString()} ";
					strQuery1 = $"{strQuery1}        AND chatmsg_from_login = '{strLogin}' ";
					strQuery1 = $"{strQuery1}       ) ";
					strQuery1 = $"{strQuery1} OR   (";
					strQuery1 = $"{strQuery1}            chatmsg_to_comp_id = {lCompId.ToString()} ";
					strQuery1 = $"{strQuery1}        AND chatmsg_to_contact_id = {lContactId.ToString()} ";
					strQuery1 = $"{strQuery1}        AND chatmsg_to_sub_id = {lCurrSubId.ToString()} ";
					strQuery1 = $"{strQuery1}        AND chatmsg_to_login = '{strLogin}' ";
					strQuery1 = $"{strQuery1}      )";

					rstRec1.CursorLocation = CursorLocationEnum.adUseClient;

					switch(strWhere)
					{
						case "Homebase" : 
							rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
							break;
						case "Evolution" : 
							rstRec1.Open(strQuery1, frm_Subscription.DefInstance.REMOTE_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
							break;
					}

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						lTot2 = rstRec1.RecordCount;

						lCnt2 = 0;
						do 
						{ // Loop Until rstRec1.EOF = True

							lCnt2++;
							lNbrChg++;

							if (Convert.ToDouble(rstRec1["chatmsg_from_sub_id"]) == lCurrSubId)
							{
								rstRec1["chatmsg_from_sub_id"] = lNewSubId;
							}
							if (Convert.ToDouble(rstRec1["chatmsg_to_sub_id"]) == lCurrSubId)
							{
								rstRec1["chatmsg_to_sub_id"] = lNewSubId;
							}

							rstRec1.UpdateBatch();

							rstRec1.MoveNext();

						}
						while(!rstRec1.EOF);

					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

				} // If strWhere <> "" And lCompId > 0 And strLogin <> "" And lContactId > 0 And lCurrSubId > 0 And lNewSubId > 0 Then
				 // frm_Subscription

				bResults = true;

				rstRec1 = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr = Information.Err().Number;
				strErrMsg = excep.Message;

				modAdminCommon.Report_Error($"Move_All_Login_Subscription_Chat_Message_Error: {strErrMsg}");

				result = false;
			}
			return result;
		} // Move_All_Login_Subscription_Chat_Message

		internal static bool Move_All_Login_Subscription_Chat_Log(string strWhere, int lCompId, string strLogin, int lContactId, int lCurrSubId, int lNewSubId, ref int lNbrChg, ref string strErrMsg)
		{

			bool result = false;
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			int lErrNbr = 0;
			string strErrDesc = "";

			bool bResults = false;

			int lTot2 = 0;
			int lCnt2 = 0;
			int lChg = 0;

			try
			{

				bResults = false;


				if (strWhere != "" && lCompId > 0 && strLogin != "" && lContactId > 0 && lCurrSubId > 0 && lNewSubId > 0)
				{

					strQuery1 = "SELECT * FROM Chat_Log  ";
					strQuery1 = $"{strQuery1}WHERE (";
					strQuery1 = $"{strQuery1}            chatlog_from_comp_id = {lCompId.ToString()} ";
					strQuery1 = $"{strQuery1}        AND chatlog_from_contact_id = {lContactId.ToString()} ";
					strQuery1 = $"{strQuery1}        AND chatlog_from_sub_id = {lCurrSubId.ToString()} ";
					strQuery1 = $"{strQuery1}        AND chatlog_from_login = '{strLogin}' ";
					strQuery1 = $"{strQuery1}       ) ";
					strQuery1 = $"{strQuery1} OR   (";
					strQuery1 = $"{strQuery1}            chatlog_to_comp_id = {lCompId.ToString()} ";
					strQuery1 = $"{strQuery1}        AND chatlog_to_contact_id = {lContactId.ToString()} ";
					strQuery1 = $"{strQuery1}        AND chatlog_to_sub_id = {lCurrSubId.ToString()} ";
					strQuery1 = $"{strQuery1}        AND chatlog_to_login = '{strLogin}' ";
					strQuery1 = $"{strQuery1}      )";

					rstRec1.CursorLocation = CursorLocationEnum.adUseClient;

					switch(strWhere)
					{
						case "Homebase" : 
							rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
							break;
						case "Evolution" : 
							rstRec1.Open(strQuery1, frm_Subscription.DefInstance.REMOTE_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
							break;
					}

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						lTot2 = rstRec1.RecordCount;

						lCnt2 = 0;
						do 
						{ // Loop Until rstRec1.EOF = True

							lCnt2++;
							lNbrChg++;

							if (Convert.ToDouble(rstRec1["chatlog_from_sub_id"]) == lCurrSubId)
							{
								rstRec1["chatlog_from_sub_id"] = lNewSubId;
							}
							if (Convert.ToDouble(rstRec1["chatlog_to_sub_id"]) == lCurrSubId)
							{
								rstRec1["chatlog_to_sub_id"] = lNewSubId;
							}

							rstRec1.UpdateBatch();

							rstRec1.MoveNext();

						}
						while(!rstRec1.EOF);

					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

				} // If strWhere <> "" And lCompId > 0 And strLogin <> "" And lContactId > 0 And lCurrSubId > 0 And lNewSubId > 0 Then
				 // frm_Subscription

				bResults = true;

				rstRec1 = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr = Information.Err().Number;
				strErrMsg = excep.Message;

				modAdminCommon.Report_Error($"Move_All_Login_Subscription_Chat_Log_Error: {strErrMsg}");

				result = false;
			}
			return result;
		} // Move_All_Login_Subscription_Chat_Log

		internal static bool Move_All_Login_Subscription_Aircraft_Value(string strWhere, int lCompId, string strLogin, int lContactId, int lCurrSubId, int lNewSubId, ref int lNbrChg, ref string strErrMsg)
		{

			bool result = false;
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			int lErrNbr = 0;
			string strErrDesc = "";

			bool bResults = false;

			int lTot2 = 0;
			int lCnt2 = 0;
			int lChg = 0;

			try
			{

				bResults = false;


				if (strWhere != "" && lCompId > 0 && strLogin != "" && lCurrSubId > 0 && lNewSubId > 0)
				{

					strQuery1 = $"SELECT * FROM Aircraft_Value WHERE (acval_comp_id = {lCompId.ToString()}) ";
					strQuery1 = $"{strQuery1}AND (acval_sub_id = {lCurrSubId.ToString()}) AND (acval_login = '{strLogin}') ";

					rstRec1.CursorLocation = CursorLocationEnum.adUseClient;

					switch(strWhere)
					{
						case "Homebase" : 
							rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
							break;
						case "Evolution" : 
							rstRec1.Open(strQuery1, frm_Subscription.DefInstance.REMOTE_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
							break;
					}

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						lTot2 = rstRec1.RecordCount;

						lCnt2 = 0;
						do 
						{ // Loop Until rstRec1.EOF = True

							lCnt2++;
							lNbrChg++;

							rstRec1["acval_comp_id"] = lNewSubId;
							rstRec1.UpdateBatch();

							rstRec1.MoveNext();

						}
						while(!rstRec1.EOF);

					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

				} // If strWhere <> "" And lCompId > 0 And strLogin <> "" And lCurrSubId > 0 And lNewSubId > 0 Then
				 // frm_Subscription

				bResults = true;

				rstRec1 = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr = Information.Err().Number;
				strErrMsg = excep.Message;

				modAdminCommon.Report_Error($"Move_All_Login_Subscription_Aircraft_Value_Error: {strErrMsg}");

				result = false;
			}
			return result;
		} // Move_All_Login_Subscription_Aircraft_Value

		internal static bool Move_All_EMail_Request_Records(string strWhere, int lCompIdCurr, int lCompIdNew, int lSubId, ref int lNbrChg, ref string strErrMsg)
		{

			bool result = false;
			int lErrNbr = 0;
			string strErrDesc = "";

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			bool bResults = false;

			int lCnt1 = 0;
			int lTot1 = 0;

			try
			{


				bResults = false;

				search_on($"Moving EMail Request Records In {strWhere}", "");

				strQuery1 = $"SELECT * FROM EMail_Request WHERE (emrq_sub_id = {lSubId.ToString()}) ";

				rstRec1.CursorLocation = CursorLocationEnum.adUseClient;

				switch(strWhere)
				{
					case "Homebase" : 
						rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
						break;
					case "Evolution" : 
						rstRec1.Open(strQuery1, frm_Subscription.DefInstance.REMOTE_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
						break;
				}

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					lTot1 = rstRec1.RecordCount;

					lCnt1 = 0;
					do 
					{ // Loop Until rstRec1.EOF = True

						lNbrChg++;
						lCnt1++;

						search_on($"Moving EMail Request Records In {strWhere}", $"Moving EMail Request: {StringsHelper.Format(lCnt1, "#,###")} of {StringsHelper.Format(lTot1, "#,###")}");

						rstRec1["emrq_comp_id"] = lCompIdNew;
						rstRec1.UpdateBatch();

						rstRec1.MoveNext();
						Application.DoEvents();

					}
					while(!rstRec1.EOF);

				} // If rstRec1.BOF = False And rstRec1.EOF = False Then

				bResults = true;

				rstRec1.Close();

				search_off();
				 // frm_Subscription

				rstRec1 = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr = Information.Err().Number;
				strErrMsg = excep.Message;

				modAdminCommon.Report_Error($"Move_All_EMail_Request_Records_Error: {strErrMsg}");

				result = false;
			}
			return result;
		} // Move_All_EMail_Request_Records

		internal static bool Move_All_Login_EMail_Request_Records(string strWhere, int lCompId, string strLogin, int lContactId, string strContactEMail, int lCurrSubId, int lNewSubId, ref int lNbrChg, ref string strErrMsg)
		{

			bool result = false;
			int lErrNbr = 0;
			string strErrDesc = "";

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			bool bResults = false;

			int lCnt1 = 0;
			int lTot1 = 0;

			try
			{

				bResults = false;


				if (strWhere != "" && lCompId > 0 && lContactId > 0 && strContactEMail != "" && strLogin != "" && lCurrSubId > 0 && lNewSubId > 0)
				{

					strQuery1 = $"SELECT * FROM EMail_Request WHERE (emrq_sub_id = {lCurrSubId.ToString()}) ";
					strQuery1 = $"{strQuery1}AND (emrq_comp_id = {lCompId.ToString()}) ";
					strQuery1 = $"{strQuery1}AND (emrq_email_replyaddress = '{strContactEMail}') ";

					rstRec1.CursorLocation = CursorLocationEnum.adUseClient;

					switch(strWhere)
					{
						case "Homebase" : 
							rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
							break;
						case "Evolution" : 
							rstRec1.Open(strQuery1, frm_Subscription.DefInstance.REMOTE_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
							break;
					}

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						lTot1 = rstRec1.RecordCount;

						lCnt1 = 0;
						do 
						{ // Loop Until rstRec1.EOF = True

							lNbrChg++;
							lCnt1++;

							rstRec1["emrq_sub_id"] = lNewSubId;
							rstRec1.UpdateBatch();

							rstRec1.MoveNext();
							Application.DoEvents();

						}
						while(!rstRec1.EOF);

					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

				} // If strWhere <> "" And lCompId > 0 And lContactId > 0 And strContactEMail <> "" And strLogin <> "" And lCurrSubId > 0 And lNewSubId > 0 Then
				 // frm_Subscription

				bResults = true;
				rstRec1 = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr = Information.Err().Number;
				strErrMsg = excep.Message;

				modAdminCommon.Report_Error($"Move_All_Login_EMail_Request_Records_Error: {strErrMsg}");

				result = false;
			}
			return result;
		} // Move_All_Login_EMail_Request_Records

		internal static bool Move_All_EMail_Queue_Records(string strWhere, int lCompIdCurr, int lCompIdNew, int lSubId, ref int lNbrChg, ref string strErrMsg)
		{

			bool result = false;
			int lErrNbr = 0;
			string strErrDesc = "";

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			bool bResults = false;

			int lCnt1 = 0;
			int lTot1 = 0;

			try
			{


				bResults = false;

				search_on($"Moving EMail Queue Records In {strWhere}", "");

				strQuery1 = $"SELECT * FROM EMail_Queue WHERE (emailq_sub_id = {lSubId.ToString()}) ";

				rstRec1.CursorLocation = CursorLocationEnum.adUseClient;

				switch(strWhere)
				{
					case "Homebase" : 
						rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
						break;
					case "Evolution" : 
						rstRec1.Open(strQuery1, frm_Subscription.DefInstance.REMOTE_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
						break;
				}

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					lTot1 = rstRec1.RecordCount;

					lCnt1 = 0;
					do 
					{ // Loop Until rstRec1.EOF = True

						lNbrChg++;
						lCnt1++;

						search_on($"Moving EMail Queue Records In {strWhere}", $"Moving EMail Queue: {StringsHelper.Format(lCnt1, "#,###")} of {StringsHelper.Format(lTot1, "#,###")}");

						rstRec1["emailq_comp_id"] = lCompIdNew;
						rstRec1.UpdateBatch();

						rstRec1.MoveNext();
						Application.DoEvents();

					}
					while(!rstRec1.EOF);

				} // If rstRec1.BOF = False And rstRec1.EOF = False Then

				bResults = true;

				rstRec1.Close();

				search_off();
				 // frm_Subscription

				rstRec1 = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr = Information.Err().Number;
				strErrMsg = excep.Message;

				modAdminCommon.Report_Error($"Move_All_EMail_Queue_Records_Error: {strErrMsg}");

				result = false;
			}
			return result;
		} // Move_All_EMail_Queue_Records

		internal static bool Move_All_Login_EMail_Queue_Records(string strWhere, int lCompId, string strLogin, int lContactId, string strContactEMail, int lCurrSubId, int lNewSubId, ref int lNbrChg, ref string strErrMsg)
		{

			bool result = false;
			int lErrNbr = 0;
			string strErrDesc = "";

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			bool bResults = false;

			int lCnt1 = 0;
			int lTot1 = 0;

			try
			{

				bResults = false;


				if (strWhere != "" && lCompId > 0 && strLogin != "" && lContactId > 0 && strContactEMail != "" && lCurrSubId > 0 && lNewSubId > 0)
				{

					strQuery1 = $"SELECT * FROM EMail_Queue WHERE (emailq_sub_id = {lCurrSubId.ToString()}) ";
					strQuery1 = $"{strQuery1}AND (emailq_comp_id = {lCompId.ToString()}) ";
					strQuery1 = $"{strQuery1}AND (emailq_contact_id = {lContactId.ToString()}) ";
					strQuery1 = $"{strQuery1}AND (emailq_to = '{strContactEMail}') ";

					rstRec1.CursorLocation = CursorLocationEnum.adUseClient;

					switch(strWhere)
					{
						case "Homebase" : 
							rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
							break;
						case "Evolution" : 
							rstRec1.Open(strQuery1, frm_Subscription.DefInstance.REMOTE_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
							break;
					}

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						lTot1 = rstRec1.RecordCount;

						lCnt1 = 0;
						do 
						{ // Loop Until rstRec1.EOF = True

							lNbrChg++;
							lCnt1++;

							rstRec1["emailq_sub_id"] = lNewSubId;
							rstRec1.UpdateBatch();

							rstRec1.MoveNext();
							Application.DoEvents();

						}
						while(!rstRec1.EOF);

					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

				} // If strWhere <> "" And lCompId > 0 And strLogin <> "" And lContactId > 0 And strContactEMail <> "" And lCurrSubId > 0 And lNewSubId > 0 Then
				 // frm_Subscription

				bResults = true;

				rstRec1 = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr = Information.Err().Number;
				strErrMsg = excep.Message;

				modAdminCommon.Report_Error($"Move_All_Login_EMail_Queue_Records_Error: {strErrMsg}");

				result = false;
			}
			return result;
		} // Move_All_Login_EMail_Queue_Records

		internal static bool Move_All_SMS_Text_Message_Received_Records(string strWhere, int lCompIdCurr, int lCompIdNew, int lSubId, ref int lNbrChg, ref string strErrMsg)
		{

			bool result = false;
			int lErrNbr = 0;
			string strErrDesc = "";

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			bool bResults = false;

			int lCnt1 = 0;
			int lTot1 = 0;

			try
			{


				bResults = false;

				search_on($"Moving SMS Text Message Received In {strWhere}", "");

				strQuery1 = $"SELECT * FROM SMS_Text_Message_Received WHERE (smsrecv_sub_id = {lSubId.ToString()}) ";

				rstRec1.CursorLocation = CursorLocationEnum.adUseClient;

				switch(strWhere)
				{
					case "Homebase" : 
						rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
						break;
					case "Evolution" : 
						rstRec1.Open(strQuery1, frm_Subscription.DefInstance.REMOTE_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
						break;
				}

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					lTot1 = rstRec1.RecordCount;

					lCnt1 = 0;
					do 
					{ // Loop Until rstRec1.EOF = True

						lNbrChg++;
						lCnt1++;

						search_on($"Moving SMS Text Message Received In {strWhere}", $"Moving SMS Text Msg: {StringsHelper.Format(lCnt1, "#,###")} of {StringsHelper.Format(lTot1, "#,###")}");

						rstRec1["smsrecv_comp_id"] = lCompIdNew;
						rstRec1.UpdateBatch();

						rstRec1.MoveNext();
						Application.DoEvents();

					}
					while(!rstRec1.EOF);

				} // If rstRec1.BOF = False And rstRec1.EOF = False Then

				bResults = true;

				rstRec1.Close();

				search_off();
				 // frm_Subscription

				rstRec1 = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr = Information.Err().Number;
				strErrMsg = excep.Message;

				modAdminCommon.Report_Error($"Move_All_SMS_Text_Message_Records_Received_Error: {strErrMsg}");

				result = false;
			}
			return result;
		} // Move_All_SMS_Text_Message_Received_Records

		internal static bool Move_All_Login_SMS_Text_Message_Received_Records(string strWhere, int lCompId, string strLogin, int lCurrSubId, int lNewSubId, ref int lNbrChg, ref string strErrMsg)
		{

			bool result = false;
			int lErrNbr = 0;
			string strErrDesc = "";

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			bool bResults = false;

			int lCnt1 = 0;
			int lTot1 = 0;

			try
			{

				bResults = false;


				if (strWhere != "" && lCompId > 0 && strLogin != "" && lCurrSubId > 0 && lNewSubId > 0)
				{

					strQuery1 = "SELECT * FROM SMS_Text_Message_Received ";
					strQuery1 = $"{strQuery1}WHERE (smsrecv_sub_id = {lCurrSubId.ToString()}) AND (smsrecv_login = '{strLogin}') ";

					rstRec1.CursorLocation = CursorLocationEnum.adUseClient;

					switch(strWhere)
					{
						case "Homebase" : 
							rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
							break;
						case "Evolution" : 
							rstRec1.Open(strQuery1, frm_Subscription.DefInstance.REMOTE_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
							break;
					}

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						lTot1 = rstRec1.RecordCount;

						lCnt1 = 0;
						do 
						{ // Loop Until rstRec1.EOF = True

							lNbrChg++;
							lCnt1++;

							rstRec1["smsrecv_sub_id"] = lNewSubId;
							rstRec1.UpdateBatch();

							rstRec1.MoveNext();
							Application.DoEvents();

						}
						while(!rstRec1.EOF);

					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

				} // If strWhere <> "" And lCompId > 0 And strLogin <> "" And lCurrSubId > 0 And lNewSubId > 0 Then
				 // frm_Subscription

				bResults = true;

				rstRec1 = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr = Information.Err().Number;
				strErrMsg = excep.Message;

				modAdminCommon.Report_Error($"Move_All_Login_SMS_Text_Message_Received_Records_Error: {strErrMsg}");

				result = false;
			}
			return result;
		} // Move_All_Login_SMS_Text_Message_Received_Records

		internal static bool Move_All_SMS_Text_Message_Queue_Records(string strWhere, int lCompIdCurr, int lCompIdNew, int lSubId, ref int lNbrChg, ref string strErrMsg)
		{

			bool result = false;
			int lErrNbr = 0;
			string strErrDesc = "";

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			bool bResults = false;

			int lCnt1 = 0;
			int lTot1 = 0;

			try
			{


				bResults = false;

				search_on($"Moving SMS Text Message Queue In {strWhere}", "");

				strQuery1 = $"SELECT * FROM SMS_Text_Message_Queue WHERE (smst_sub_id = {lSubId.ToString()}) ";

				rstRec1.CursorLocation = CursorLocationEnum.adUseClient;

				switch(strWhere)
				{
					case "Homebase" : 
						rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
						break;
					case "Evolution" : 
						rstRec1.Open(strQuery1, frm_Subscription.DefInstance.REMOTE_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
						break;
				}

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					lTot1 = rstRec1.RecordCount;

					lCnt1 = 0;
					do 
					{ // Loop Until rstRec1.EOF = True

						lNbrChg++;
						lCnt1++;

						search_on($"Moving SMS Text Message Queue In {strWhere}", $"Moving SMS Text Msg: {StringsHelper.Format(lCnt1, "#,###")} of {StringsHelper.Format(lTot1, "#,###")}");

						rstRec1["smst_comp_id"] = lCompIdNew;
						rstRec1.UpdateBatch();

						rstRec1.MoveNext();
						Application.DoEvents();

					}
					while(!rstRec1.EOF);

				} // If rstRec1.BOF = False And rstRec1.EOF = False Then

				bResults = true;

				rstRec1.Close();

				search_off();
				 // frm_Subscription

				rstRec1 = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr = Information.Err().Number;
				strErrMsg = excep.Message;

				modAdminCommon.Report_Error($"Move_All_SMS_Text_Message_Queue_Records_Error: {strErrMsg}");

				result = false;
			}
			return result;
		} // Move_All_SMS_Text_Message_Queue_Records

		internal static bool Move_All_Login_SMS_Text_Message_Queue_Records(string strWhere, int lCompId, string strLogin, int lCurrSubId, int lNewSubId, ref int lNbrChg, ref string strErrMsg)
		{

			bool result = false;
			int lErrNbr = 0;
			string strErrDesc = "";

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			bool bResults = false;

			int lCnt1 = 0;
			int lTot1 = 0;

			try
			{

				bResults = false;


				if (strWhere != "" && lCompId > 0 && strLogin != "" && lCurrSubId > 0 && lNewSubId > 0)
				{

					strQuery1 = $"SELECT * FROM SMS_Text_Message_Queue  WHERE (smst_sub_id = {lCurrSubId.ToString()}) ";
					strQuery1 = $"{strQuery1}AND (smst_login = '{strLogin}') ";

					rstRec1.CursorLocation = CursorLocationEnum.adUseClient;

					switch(strWhere)
					{
						case "Homebase" : 
							rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
							break;
						case "Evolution" : 
							rstRec1.Open(strQuery1, frm_Subscription.DefInstance.REMOTE_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
							break;
					}

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						lTot1 = rstRec1.RecordCount;

						lCnt1 = 0;
						do 
						{ // Loop Until rstRec1.EOF = True

							lNbrChg++;
							lCnt1++;

							rstRec1["smst_sub_id"] = lNewSubId;
							rstRec1.UpdateBatch();

							rstRec1.MoveNext();
							Application.DoEvents();

						}
						while(!rstRec1.EOF);

					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

				} // If strWhere <> "" And lCompId > 0 And strLogin <> "" And lCurrSubId > 0 And lNewSubId > 0 Then

				bResults = true;
				 // frm_Subscription

				rstRec1 = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr = Information.Err().Number;
				strErrMsg = excep.Message;

				modAdminCommon.Report_Error($"Move_All_Login_SMS_Text_Message_Queue_Records_Error: {strErrMsg}");

				result = false;
			}
			return result;
		} // Move_All_Login_SMS_Text_Message_Queue_Records

		internal static bool Move_All_Service_Interruption_Record(string strWhere, int lCompIdCurr, int lCompIdNew, int lSubId, ref int lNbrChg, ref string strErrMsg)
		{

			bool result = false;
			int lErrNbr = 0;
			string strErrDesc = "";

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			bool bResults = false;

			int lCnt1 = 0;
			int lTot1 = 0;

			try
			{


				bResults = false;

				search_on($"Moving Service Interruption Records In {strWhere}", "");

				strQuery1 = $"SELECT * FROM Service_Interruption WHERE (serint_sub_id = {lSubId.ToString()}) ";
				strQuery1 = $"{strQuery1}OR (serint_tech_id_value = {lSubId.ToString()}) ";

				rstRec1.CursorLocation = CursorLocationEnum.adUseClient;

				switch(strWhere)
				{
					case "Homebase" : 
						rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
						break;
					case "Evolution" : 
						rstRec1.Open(strQuery1, frm_Subscription.DefInstance.REMOTE_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
						break;
				}

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					lTot1 = rstRec1.RecordCount;

					lCnt1 = 0;
					do 
					{ // Loop Until rstRec1.EOF = True

						lNbrChg++;
						lCnt1++;

						rstRec1["serint_comp_id"] = lCompIdNew;
						rstRec1.UpdateBatch();

						rstRec1.MoveNext();
						Application.DoEvents();

					}
					while(!rstRec1.EOF);

				} // If rstRec1.BOF = False And rstRec1.EOF = False Then

				bResults = true;

				rstRec1.Close();

				search_off();

				rstRec1 = null;
				 // frm_Subscription


				return bResults;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr = Information.Err().Number;
				strErrMsg = excep.Message;

				modAdminCommon.Report_Error($"Move_All_Service_Interruption_Record_Error: {strErrMsg}");

				result = false;
			}
			return result;
		} // Move_All_Service_Interruption_Record

		internal static bool Move_All_Subscription_Request_Report_DotNet(string strWhere, int lCompIdCurr, int lCompIdNew, int lSubId, string strContactId, ref int lNbrChg, ref string strErrMsg)
		{

			bool result = false;
			int lErrNbr = 0;
			string strErrDesc = "";

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string[] aContactId1 = null; // ContactIdCurr|ContactIdNew|Login|ContactName
			string[] aContactId2 = null;

			int lTot1 = 0;
			int lTot2 = 0;
			int lCnt1 = 0;
			int lCnt2 = 0;

			bool bResults = false;

			string strReplace1 = "";
			string strReplace2 = "";
			int lChg = 0;

			int lContactIdCurr = 0;
			int lContactIdNew = 0;

			string strLogin = "";
			string strCONTACTNAME = "";

			try
			{


				bResults = false;

				strContactId = strContactId.Trim();

				if (strContactId != "")
				{

					search_on($"Moving Subscription Request Report DotNet Logs In {strWhere}", "");

					aContactId1 = strContactId.Split(Environment.NewLine[0]);

					lTot1 = aContactId1.GetUpperBound(0);

					if (lTot1 > 0)
					{

						lCnt1 = -1;

						do 
						{ // Loop Until lCnt1 >= lTot1 - 1

							lCnt1++;

							aContactId2 = aContactId1[lCnt1].Split('|');

							if (Information.IsNumeric(aContactId2[0]) && Information.IsNumeric(aContactId2[1]))
							{

								lContactIdCurr = Convert.ToInt32(Double.Parse(aContactId2[0]));
								lContactIdNew = Convert.ToInt32(Double.Parse(aContactId2[1]));
								strLogin = aContactId2[2];
								strCONTACTNAME = aContactId2[3];

								strQuery1 = $"SELECT * FROM Report_Request_DotNet  WHERE (rrdn_sub_comp_id = {lCompIdCurr.ToString()}) ";
								strQuery1 = $"{strQuery1}AND (rrdn_sub_contact_id = {lContactIdCurr.ToString()}) ";

								rstRec1.CursorLocation = CursorLocationEnum.adUseClient;

								switch(strWhere)
								{
									case "Homebase" : 
										rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
										break;
									case "Evolution" : 
										rstRec1.Open(strQuery1, frm_Subscription.DefInstance.REMOTE_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
										break;
								}

								if (!rstRec1.BOF && !rstRec1.EOF)
								{

									lTot2 = rstRec1.RecordCount;

									lCnt2 = 0;
									do 
									{ // Loop Until rstRec1.EOF = True

										lCnt2++;
										lNbrChg++;

										search_on($"Moving Subscription Request Report DotNet Logs In {strWhere}", $"Moving DotNet Log: {StringsHelper.Format(lCnt2, "#,###")} of {StringsHelper.Format(lTot2, "#,###")}");

										rstRec1["rrdn_sub_comp_id"] = lCompIdNew;
										rstRec1["rrdn_sub_contact_id"] = lContactIdNew;
										rstRec1.UpdateBatch();

										rstRec1.MoveNext();
										Application.DoEvents();

									}
									while(!rstRec1.EOF);

								} // If rstRec1.BOF = False And rstRec1.EOF = False Then

								rstRec1.Close();

							} // If IsNumeric(aContactId2(0)) = True And IsNumeric(aContactId2(1)) = True Then

						}
						while(lCnt1 < lTot1 - 1);

						bResults = true;

					}
					else
					{
						strErrMsg = "Report Request DotNet Contact Id Unable To Split.  Can NOT Move";
					} // If lTot1> 0 Then

					search_off();

				}
				else
				{
					strErrMsg = "Report Request DotNet Contact Id Is Blank.  Nothing To Move";
				} // If strContactId <> "" Then

				rstRec1 = null;
				 // frm_Subscription


				return bResults;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr = Information.Err().Number;
				strErrMsg = excep.Message;

				modAdminCommon.Report_Error($"Move_All_Subscription_Request_Report_DotNet_Error: {strErrMsg}");

				result = false;
			}
			return result;
		} // Move_All_Subscription_Request_Report_DotNet

		internal static bool Move_All_Subscription_Login_Request_Report_DotNet(string strWhere, int lCompId, string strLogin, int lCurrSubId, int lNewSubId, ref int lNbrChg, ref string strErrMsg)
		{

			bool result = false;
			int lErrNbr = 0;
			string strErrDesc = "";

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			int lTot1 = 0;
			int lTot2 = 0;
			int lCnt1 = 0;
			int lCnt2 = 0;

			bool bResults = false;

			int lChg = 0;

			try
			{


				bResults = false;

				if (strWhere != "" && lCompId > 0 && strLogin != "" && lCurrSubId > 0 && lNewSubId > 0)
				{

					strQuery1 = "SELECT * FROM Report_Request_DotNet ";
					strQuery1 = $"{strQuery1}WHERE (rrdn_sub_id = {lCurrSubId.ToString()}) ";
					strQuery1 = $"{strQuery1}AND (rrdn_login = '{strLogin}') ";

					rstRec1.CursorLocation = CursorLocationEnum.adUseClient;

					switch(strWhere)
					{
						case "Homebase" : 
							rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
							break;
						case "Evolution" : 
							rstRec1.Open(strQuery1, frm_Subscription.DefInstance.REMOTE_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
							break;
					}

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						lTot2 = rstRec1.RecordCount;

						lCnt2 = 0;
						do 
						{ // Loop Until rstRec1.EOF = True

							lCnt2++;
							lNbrChg++;

							rstRec1["rrdn_sub_id"] = lNewSubId;
							rstRec1.UpdateBatch();

							rstRec1.MoveNext();
							Application.DoEvents();

						}
						while(!rstRec1.EOF);

					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

				} // If strWhere <> "" And lCompId > 0 And strLogin <> "" And lCurrSubId > 0 And lNewSubId > 0 Then

				bResults = true;
				rstRec1 = null;
				 // frm_Subscription


				return bResults;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr = Information.Err().Number;
				strErrMsg = excep.Message;

				modAdminCommon.Report_Error($"Move_All_Subscription_Login_Request_Report_DotNet_Error: {strErrMsg}");

				result = false;
			}
			return result;
		} // Move_All_Subscription_Login_Request_Report_DotNet

		internal static bool Move_All_Subscription_Login_Request_Report(string strWhere, int lCompId, string strLogin, int lCurrSubId, int lNewSubId, ref int lNbrChg, ref string strErrMsg)
		{

			bool result = false;
			int lErrNbr = 0;
			string strErrDesc = "";

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			int lTot1 = 0;
			int lTot2 = 0;
			int lCnt1 = 0;
			int lCnt2 = 0;

			bool bResults = false;

			int lChg = 0;

			try
			{


				bResults = false;

				if (strWhere != "" && lCompId > 0 && strLogin != "" && lCurrSubId > 0 && lNewSubId > 0)
				{

					strQuery1 = $"SELECT * FROM Report_Request WHERE (rprq_sub_id = {lCurrSubId.ToString()}) ";
					strQuery1 = $"{strQuery1}AND (rprq_login = '{strLogin}') ";

					rstRec1.CursorLocation = CursorLocationEnum.adUseClient;

					switch(strWhere)
					{
						case "Homebase" : 
							rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
							break;
						case "Evolution" : 
							rstRec1.Open(strQuery1, frm_Subscription.DefInstance.REMOTE_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
							break;
					}

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						lTot2 = rstRec1.RecordCount;

						lCnt2 = 0;
						do 
						{ // Loop Until rstRec1.EOF = True

							lCnt2++;
							lNbrChg++;

							rstRec1["rprq_sub_id"] = lNewSubId;
							// rstRec1!rprq_id = rstRec1!rprq_id
							rstRec1.UpdateBatch();
							//rstRec1.Update

							rstRec1.MoveNext();
							Application.DoEvents();

						}
						while(!rstRec1.EOF);

					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

				} // If strWhere <> "" And lCompId > 0 And strLogin <> "" And lCurrSubId > 0 And lNewSubId > 0 Then

				bResults = true;
				rstRec1 = null;
				 // frm_Subscription


				return bResults;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr = Information.Err().Number;
				strErrMsg = excep.Message;

				modAdminCommon.Report_Error($"Move_All_Subscription_Login_Request_Report_Error: {strErrMsg}");

				result = false;
			}
			return result;
		} // Move_All_Subscription_Login_Request_Report

		internal static bool Move_All_Subscription_Install_Logs(string strWhere, int lCompIdCurr, int lCompIdNew, int lSubId, string strContactId, ref int lNbrChg, ref string strErrMsg)
		{

			bool result = false;
			int lErrNbr = 0;
			string strErrDesc = "";

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string[] aContactId1 = null; // ContactIdCurr|ContactIdNew|Login|ContactName
			string[] aContactId2 = null;

			int lTot1 = 0;
			int lCnt1 = 0;

			bool bResults = false;

			string strReplace1 = "";
			string strReplace2 = "";
			int lChg = 0;

			int lContactIdCurr = 0;
			int lContactIdNew = 0;

			string strLogin = "";
			string strCONTACTNAME = "";

			try
			{

				bResults = false;


				strContactId = strContactId.Trim();

				if (strContactId != "")
				{

					aContactId1 = strContactId.Split(Environment.NewLine[0]);

					lTot1 = aContactId1.GetUpperBound(0);

					if (lTot1 > 0)
					{

						lCnt1 = -1;

						do 
						{ // Loop Until lCnt1 >= lTot1 - 1

							lCnt1++;

							aContactId2 = aContactId1[lCnt1].Split('|');

							if (Information.IsNumeric(aContactId2[0]) && Information.IsNumeric(aContactId2[1]))
							{

								lContactIdCurr = Convert.ToInt32(Double.Parse(aContactId2[0]));
								lContactIdNew = Convert.ToInt32(Double.Parse(aContactId2[1]));
								strLogin = aContactId2[2];
								strCONTACTNAME = aContactId2[3];

								strQuery1 = "SELECT * FROM Subscription_Install_Log ";
								strQuery1 = $"{strQuery1}WHERE (subislog_subid = {lSubId.ToString()}) ";
								strQuery1 = $"{strQuery1}AND (";
								strQuery1 = $"{strQuery1}        (subislog_subins_contact_id = 0 AND subislog_login = '{strLogin}') ";
								strQuery1 = $"{strQuery1}     OR (subislog_subins_contact_id = {lContactIdCurr.ToString()}) ";
								strQuery1 = $"{strQuery1})";

								rstRec1.CursorLocation = CursorLocationEnum.adUseClient;

								switch(strWhere)
								{
									case "Homebase" : 
										rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
										break;
									case "Evolution" : 
										rstRec1.Open(strQuery1, frm_Subscription.DefInstance.REMOTE_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
										break;
								}

								if (!rstRec1.BOF && !rstRec1.EOF)
								{

									lTot1 = rstRec1.RecordCount;

									lCnt1 = 0;
									do 
									{ // Loop Until rstRec1.EOF = True

										lCnt1++;
										lNbrChg++;

										rstRec1["subislog_subins_contact_id"] = lContactIdNew;
										rstRec1.UpdateBatch();

										rstRec1.MoveNext();
										Application.DoEvents();

									}
									while(!rstRec1.EOF);

								} // If rstRec1.BOF = False And rstRec1.EOF = False Then

								rstRec1.Close();

							} // If IsNumeric(aContactId2(0)) = True And IsNumeric(aContactId2(1)) = True Then

						}
						while(lCnt1 < lTot1 - 1);

						bResults = true;

					}
					else
					{
						strErrMsg = "Subscription Install Logs  Contact Id Unable To Split.  Can NOT Move";
					} // If lTot1> 0 Then

				}
				else
				{
					strErrMsg = "Subscription Install Logs Contact Id Is Blank.  Nothing To Move";
				} // If strContactId <> "" Then

				rstRec1 = null;
				 // frm_Subscription


				return bResults;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr = Information.Err().Number;
				strErrMsg = excep.Message;

				modAdminCommon.Report_Error($"Move_All_Subscription_Install_Logs_Error: {strErrMsg}");

				result = false;
			}
			return result;
		} // Move_All_Subscription_Install_Logs

		internal static bool Move_All_Aircraft_Value_Records(string strWhere, int lCompIdCurr, int lCompIdNew, int lSubId, string strContactId, ref int lNbrChg, ref string strErrMsg)
		{

			bool result = false;
			int lErrNbr = 0;
			string strErrDesc = "";

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string[] aContactId1 = null; // ContactIdCurr|ContactIdNew|Login|ContactName
			string[] aContactId2 = null;

			int lTot1 = 0;
			int lCnt1 = 0;

			bool bResults = false;

			string strReplace1 = "";
			string strReplace2 = "";
			int lChg = 0;

			int lContactIdCurr = 0;
			int lContactIdNew = 0;

			string strLogin = "";
			string strCONTACTNAME = "";

			try
			{

				bResults = false;


				strQuery1 = $"SELECT * FROM Aircraft_Value WHERE (acval_comp_id = {lCompIdCurr.ToString()}) ";
				strQuery1 = $"{strQuery1}AND (acval_sub_id = {lSubId.ToString()}) ";

				rstRec1.CursorLocation = CursorLocationEnum.adUseClient;

				switch(strWhere)
				{
					case "Homebase" : 
						rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
						break;
					case "Evolution" : 
						rstRec1.Open(strQuery1, frm_Subscription.DefInstance.REMOTE_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
						break;
				}

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					lTot1 = rstRec1.RecordCount;

					lCnt1 = 0;
					do 
					{ // Loop Until rstRec1.EOF = True

						lCnt1++;
						lNbrChg++;

						rstRec1["acval_comp_id"] = lCompIdNew;
						rstRec1.UpdateBatch();

						rstRec1.MoveNext();
						Application.DoEvents();

					}
					while(!rstRec1.EOF);

				} // If rstRec1.BOF = False And rstRec1.EOF = False Then

				rstRec1.Close();

				bResults = true;

				rstRec1 = null;
				 // frm_Subscription


				return bResults;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr = Information.Err().Number;
				strErrMsg = excep.Message;

				modAdminCommon.Report_Error($"Move_All_Aircraft_Value_Records_Error: {strErrMsg}");

				result = false;
			}
			return result;
		} // Move_All_Aircraft_Value_Records

		internal static bool Move_All_Subscription_Login_Install_Logs(string strWhere, int lCompId, string strLogin, int lCurrSubId, int lNewSubId, ref int lNbrChg, ref string strErrMsg)
		{

			bool result = false;
			int lErrNbr = 0;
			string strErrDesc = "";

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			int lTot1 = 0;
			int lCnt1 = 0;

			bool bResults = false;

			string strReplace1 = "";
			string strReplace2 = "";
			int lChg = 0;
			StringBuilder update_string = new StringBuilder();

			try
			{

				bResults = false;


				if (strWhere != "" && lCompId > 0 && strLogin != "" && lCurrSubId > 0 && lNewSubId > 0)
				{

					search_on($"Moving Subscription Install Logs In {strWhere}", "Moving Install Log");

					strQuery1 = "SELECT * FROM Subscription_Install_Log ";
					strQuery1 = $"{strQuery1}WHERE (subislog_subid = {lCurrSubId.ToString()}) ";
					strQuery1 = $"{strQuery1}AND (subislog_login = '{strLogin}') ";

					rstRec1.CursorLocation = CursorLocationEnum.adUseClient;

					switch(strWhere)
					{
						case "Homebase" : 
							rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
							break;
						case "Evolution" : 
							rstRec1.Open(strQuery1, frm_Subscription.DefInstance.REMOTE_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
							break;
					}

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						lTot1 = rstRec1.RecordCount;

						lCnt1 = 0;
						do 
						{ // Loop Until rstRec1.EOF = True

							lCnt1++;
							lNbrChg++;

							if (lCnt1 == 1)
							{
								// changed from an update batch to an update statement - 6/1/22 - MSW
								update_string = new StringBuilder($" update Subscription_Install_Log set subislog_subid = {lNewSubId.ToString()}");
								update_string.Append($" WHERE (subislog_subid = {lCurrSubId.ToString()}) ");
								update_string.Append($" AND (subislog_login = '{strLogin}') ");

								switch(strWhere)
								{
									case "Homebase" : 
										MessageBox.Show("THIS SHOULDNT HAPPEN, CONTACT MATT", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK); 
										// Call LOCAL_ADO_DB.Execute(update_string, , adExecuteNoRecords + adCmdText) 
										break;
									case "Evolution" : 
										DbCommand TempCommand = null; 
										TempCommand = frm_Subscription.DefInstance.REMOTE_ADO_DB.CreateCommand(); 
										UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand); 
										TempCommand.CommandText = update_string.ToString(); 
										//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064 
										//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021 
										TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
										UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand); 
										TempCommand.ExecuteNonQuery(); 
										// rstRec1.Execute update_string, .REMOTE_ADO_DB, adOpenDynamic, adLockBatchOptimistic, adCmdText 
										break;
								}

							}

							// rstRec1!subislog_subid = lNewSubId
							//  rstRec1.UpdateBatch

							rstRec1.MoveNext();
							Application.DoEvents();

						}
						while(!rstRec1.EOF);

					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

				} // If strWhere <> "" And lCompId > 0 And strLogin <> "" And lCurrSubId > 0 And lNewSubId > 0 Then

				bResults = true;

				rstRec1 = null;
				 // frm_Subscription


				return bResults;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr = Information.Err().Number;
				strErrMsg = excep.Message;

				modAdminCommon.Report_Error($"Move_All_Subscription_Login_Install_Logs_Error: {strErrMsg}");

				result = false;
			}
			return result;
		} // Move_All_Subscription_Login_Install_Logs

		internal static bool Move_All_Subscription_Event_Logs(string strWhere, int lCompIdCurr, int lCompIdNew, int lSubId, ref int lNbrChg, ref string strErrMsg)
		{

			bool result = false;
			int lErrNbr = 0;
			string strErrDesc = "";

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			bool bResults = false;

			int lCnt1 = 0;
			int lTot1 = 0;

			string strReplace1 = "";
			string strReplace2 = "";

			try
			{

				bResults = false;


				search_on($"Moving Subscription Event Logs In {strWhere}", "Moving Event Logs");

				strQuery1 = "SELECT * FROM EventLog ";
				strQuery1 = $"{strQuery1}WHERE (evtl_comp_id = {lCompIdCurr.ToString()}) ";
				strQuery1 = $"{strQuery1}AND ( evtl_type IN ('Generated Password','Cloud Notes','Moved Contract','Auto Update Nbr Of Installs') ";
				strQuery1 = $"{strQuery1}   OR (evtl_type = 'Company' AND evtl_message LIKE '%Delete Contract Document%') ";
				strQuery1 = $"{strQuery1}   OR (evtl_type = 'Company' AND evtl_message LIKE '%Moved Contract Document%') ";
				strQuery1 = $"{strQuery1}   OR (evtl_type LIKE 'Subscription%') ";
				strQuery1 = $"{strQuery1}   OR (evtl_type = 'Clear Install Date') ";
				strQuery1 = $"{strQuery1}   OR (evtl_message LIKE '%subID:{lSubId.ToString()} %')";
				strQuery1 = $"{strQuery1}    ) ";

				rstRec1.CursorLocation = CursorLocationEnum.adUseClient;

				switch(strWhere)
				{
					case "Homebase" : 
						rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
						break;
					case "Evolution" : 
						rstRec1.Open(strQuery1, frm_Subscription.DefInstance.REMOTE_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
						break;
				}

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					lTot1 = rstRec1.RecordCount;

					strReplace1 = $"CompId:=[{lCompIdCurr.ToString()}]";
					strReplace2 = $"CompId:=[{lCompIdNew.ToString()}]";

					lCnt1 = 0;
					do 
					{ // Loop Until rstRec1.EOF = True

						lNbrChg++;
						lCnt1++;

						search_on($"Moving Subscription Event Logs In {strWhere}", $"Moving Event Logs: {StringsHelper.Format(lCnt1, "#,###")} of {StringsHelper.Format(lTot1, "#,###")}");

						rstRec1["evtl_comp_id"] = lCompIdNew;
						rstRec1["evtl_message"] = StringsHelper.Replace(Convert.ToString(rstRec1["evtl_message"]), strReplace1, strReplace2, 1, -1, CompareMethod.Binary);
						rstRec1.UpdateBatch();

						rstRec1.MoveNext();
						Application.DoEvents();

					}
					while(!rstRec1.EOF);

				} // If rstRec1.BOF = False And rstRec1.EOF = False Then

				bResults = true;

				rstRec1.Close();

				search_off();
				 // frm_Subscription

				rstRec1 = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr = Information.Err().Number;
				strErrMsg = excep.Message;

				modAdminCommon.Report_Error($"Move_All_Subscription_Event_Logs_Error: {strErrMsg}");

				result = false;
			}
			return result;
		} // Move_All_Subscription_Event_Logs

		internal static bool Move_All_Subscription_Login_Event_Logs(string strWhere, int lCompId, int lContactId, string strLogin, int lCurrSubId, int lNewSubId, ref int lNbrChg, ref string strErrMsg)
		{

			bool result = false;
			int lErrNbr = 0;
			string strErrDesc = "";

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			bool bResults = false;

			int lCnt1 = 0;
			int lTot1 = 0;

			string strMsg = "";

			try
			{

				bResults = false;


				if (lCompId > 0 && lContactId > 0 && strLogin != "" && lCurrSubId > 0 && lNewSubId > 0)
				{

					strQuery1 = $"SELECT * FROM EventLog WHERE (evtl_comp_id = {lCompId.ToString()}) ";
					strQuery1 = $"{strQuery1}AND (evtl_message LIKE '%{strLogin}%') ";
					strQuery1 = $"{strQuery1}AND (evtl_message LIKE '%{lCurrSubId.ToString()}%')";

					strQuery1 = $"{strQuery1}AND ( evtl_type IN ('Generated Password','Cloud Notes','Moved Contract','Auto Update Nbr Of Installs') ";
					strQuery1 = $"{strQuery1}   OR (evtl_type = 'Company' AND evtl_message LIKE '%Delete Contract Document%') ";
					strQuery1 = $"{strQuery1}   OR (evtl_type = 'Company' AND evtl_message LIKE '%Moved Contract Document%') ";
					strQuery1 = $"{strQuery1}   OR (evtl_type LIKE 'Subscription%') ";
					strQuery1 = $"{strQuery1}   OR (evtl_type = 'Clear Install Date') ";
					strQuery1 = $"{strQuery1}   OR (evtl_message LIKE '%subID:{lCurrSubId.ToString()} %')";
					strQuery1 = $"{strQuery1}    ) ";

					rstRec1.CursorLocation = CursorLocationEnum.adUseClient;

					switch(strWhere)
					{
						case "Homebase" : 
							rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
							break;
						case "Evolution" : 
							rstRec1.Open(strQuery1, frm_Subscription.DefInstance.REMOTE_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic); 
							break;
					}

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						lTot1 = rstRec1.RecordCount;

						lCnt1 = 0;
						do 
						{ // Loop Until rstRec1.EOF = True

							lCnt1++;

							strMsg = ($"{Convert.ToString(rstRec1["evtl_message"])} ").Trim();
							strMsg = StringsHelper.Replace(strMsg, $"SubId: {lCurrSubId.ToString()} ", $"SubId: {lNewSubId.ToString()} ", 1, -1, CompareMethod.Binary);
							strMsg = StringsHelper.Replace(strMsg, $"SubId:={lCurrSubId.ToString()} ", $"SubId:={lNewSubId.ToString()} ", 1, -1, CompareMethod.Binary);
							strMsg = StringsHelper.Replace(strMsg, $"SubId:=[{lCurrSubId.ToString()}]", $"SubId:=[{lNewSubId.ToString()}]", 1, -1, CompareMethod.Binary);

							if (strMsg != ($"{Convert.ToString(rstRec1["evtl_type"])} ").Trim())
							{
								rstRec1["evtl_message"] = strMsg;
								rstRec1.UpdateBatch();
								lNbrChg++;
							}

							rstRec1.MoveNext();
							Application.DoEvents();

						}
						while(!rstRec1.EOF);

					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

				} // If lCompId > 0 And lContactId > 0 And strLogin <> "" And lCurrSubId > 0 And lNewSubId > 0 Then

				bResults = true;
				 // frm_Subscription

				rstRec1 = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr = Information.Err().Number;
				strErrMsg = excep.Message;

				modAdminCommon.Report_Error($"Move_All_Subscription_Login_Event_Logs_Error: {strErrMsg}");

				result = false;
			}
			return result;
		} // Move_All_Subscription_Login_Event_Logs

		internal static bool Create_New_Subscription_Contact_Record(int lCompIdCurr, int lCompIdNew, int lContactIdCurr, ref int lContactIdNew, string strCONTACTNAME)
		{

			bool result = false;
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			ADORecordSetHelper rstAdd1 = new ADORecordSetHelper();
			string strAdd1 = "";

			int lTot1 = 0;

			int lErrNbr = 0;
			string strErrDesc = "";

			bool bHidden = false;
			bool bResults = false;

			try
			{

				bResults = false;
				lContactIdNew = 0;

				//-----------------------------------------------------
				// Copy Contact Record

				bHidden = true;
				if (MessageBox.Show($"Creating New Subscription Contact Record{Environment.NewLine}{Environment.NewLine}" +
				                    $"For {strCONTACTNAME}{Environment.NewLine}{Environment.NewLine}" +
				                    $"Should Contact Be Hidden?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
				{
					bHidden = false;
				}

				//----------------------------------------------------
				// Create New Contact Id

				strQuery1 = "SELECT (MAX(contact_id)+1) As NewContactId FROM Contact WITH (NOLOCK)";
				rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
				if (!rstRec1.BOF && !rstRec1.EOF)
				{
					lContactIdNew = Convert.ToInt32(rstRec1["NewContactId"]);
				}
				rstRec1.Close();

				//----------------------------------------------------
				// Open Contact Record

				strQuery1 = $"SELECT * FROM Contact WITH (NOLOCK) WHERE (contact_id = {lContactIdCurr.ToString()}) ";
				strQuery1 = $"{strQuery1}AND (contact_comp_id = {lCompIdCurr.ToString()}) AND (contact_journ_id = 0) ";

				rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					strAdd1 = "SELECT * FROM Contact WHERE (contact_id = -1 ) ";

					rstAdd1.CursorLocation = CursorLocationEnum.adUseClient;
					rstAdd1.Open(strAdd1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);

					rstAdd1.AddNew();
					int tempForEndVar = rstRec1.FieldsMetadata.Count - 1;
					for (int lCnt1 = 1; lCnt1 <= tempForEndVar; lCnt1++)
					{
						if (rstRec1.GetField(lCnt1).FieldMetadata.ColumnName != "contact_id")
						{
							int tempForEndVar2 = rstAdd1.FieldsMetadata.Count - 1;
							for (int lCnt2 = 1; lCnt2 <= tempForEndVar2; lCnt2++)
							{
								if (rstRec1.GetField(lCnt1).FieldMetadata.ColumnName == rstAdd1.GetField(lCnt2).FieldMetadata.ColumnName)
								{
									rstAdd1[lCnt2] = rstRec1[lCnt1];
								}
							}
						}
					}

					rstAdd1["contact_comp_id"] = lCompIdNew;
					rstAdd1["contact_id"] = lContactIdNew;
					rstAdd1["contact_action_date"] = DateTime.Parse("1/1/1900");

					rstAdd1["Contact_hide_flag"] = "Y";
					if (!bHidden)
					{
						rstAdd1["Contact_hide_flag"] = "N";
					}

					rstAdd1.UpdateBatch();

					rstAdd1.Close();

				} // If rstRec1.BOF = False And rstRec1.EOF = False Then

				rstRec1.Close();

				//-----------------------------------------------------
				// Copy Contact Phone Records

				strQuery1 = $"SELECT * FROM Phone_Numbers WITH (NOLOCK)  WHERE (pnum_contact_id = {lContactIdCurr.ToString()}) ";
				strQuery1 = $"{strQuery1}AND (pnum_comp_id = {lCompIdCurr.ToString()})  AND (pnum_journ_id = 0) ";

				rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					strAdd1 = "SELECT * FROM Phone_Numbers WHERE (pnum_comp_id = -1 ) ";

					rstAdd1.CursorLocation = CursorLocationEnum.adUseClient;
					rstAdd1.Open(strAdd1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);

					do 
					{

						rstAdd1.AddNew();
						int tempForEndVar3 = rstRec1.FieldsMetadata.Count - 1;
						for (int lCnt1 = 1; lCnt1 <= tempForEndVar3; lCnt1++)
						{
							int tempForEndVar4 = rstAdd1.FieldsMetadata.Count - 1;
							for (int lCnt2 = 1; lCnt2 <= tempForEndVar4; lCnt2++)
							{
								if (rstRec1.GetField(lCnt1).FieldMetadata.ColumnName == rstAdd1.GetField(lCnt2).FieldMetadata.ColumnName)
								{
									rstAdd1[lCnt2] = rstRec1[lCnt1];
								}
							}
						}

						rstAdd1["pnum_comp_id"] = lCompIdNew;
						rstAdd1["pnum_contact_id"] = lContactIdNew;
						rstAdd1.UpdateBatch();

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

					rstAdd1.Close();

				} // If rstRec1.BOF = False And rstRec1.EOF = False Then

				rstRec1.Close();

				bResults = true;

				rstAdd1 = null;
				rstRec1 = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr = Information.Err().Number;
				strErrDesc = excep.Message;

				modAdminCommon.Report_Error($"Create_New_Subscription_Contact_Record_Error: {strErrDesc}");

				MessageBox.Show($"Create_New_Subscription_Contact_Record_Error{Environment.NewLine}{strErrDesc}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);

				result = false;
			}
			return result;
		} // Create_New_Subscription_Contact_Record

		internal static bool Do_All_Subscription_Contacts_Exist_In_New_Company_Record(int lCompIdCurr, int lCompIdNew, int lSubId, ref string strMatchingContacts, ref string strMissingContacts)
		{

			bool result = false;
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			ADORecordSetHelper rstRec2 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strQuery2 = "";

			int lErrNbr = 0;
			string strErrDesc = "";

			bool bFound = false;

			int lContactIdCurr = 0;
			int lContactIdNew = 0;
			string strContactName1 = "";
			string strContactName2 = "";
			string strLogin = "";

			bool bResults = false;

			try
			{

				bResults = false;
				strMatchingContacts = "";
				strMissingContacts = "";


				search_on("Checking - Do All Contacts Exists In New Company Record", "");

				strQuery1 = "SELECT contact_id, contact_sirname, contact_first_name, contact_middle_initial, contact_last_name, contact_suffix, ";
				strQuery1 = $"{strQuery1}contact_title, contact_email_address, subins_login ";
				strQuery1 = $"{strQuery1}FROM Contact WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}INNER JOIN Subscription_Install WITH (NOLOCK) ON subins_contact_id = contact_id ";
				strQuery1 = $"{strQuery1}INNER JOIN Subscription WITH (NOLOCK) ON sub_id = subins_sub_id ";
				strQuery1 = $"{strQuery1}WHERE (sub_id = {lSubId.ToString()}) ";
				strQuery1 = $"{strQuery1}AND (sub_comp_id = {lCompIdCurr.ToString()}) ";
				strQuery1 = $"{strQuery1}AND (subins_contact_id > 0) ";
				strQuery1 = $"{strQuery1}AND (contact_journ_id = 0) ";
				strQuery1 = $"{strQuery1}ORDER BY contact_first_name, contact_last_name ";

				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					strQuery2 = "SELECT contact_id, contact_sirname, contact_first_name, contact_middle_initial, contact_last_name, contact_suffix, ";
					strQuery2 = $"{strQuery2}contact_title, contact_email_address ";
					strQuery2 = $"{strQuery2}FROM Contact WITH (NOLOCK) ";
					strQuery2 = $"{strQuery2}WHERE (contact_comp_id = {lCompIdNew.ToString()}) ";
					strQuery2 = $"{strQuery2}AND (contact_journ_id = 0) ";
					strQuery2 = $"{strQuery2}AND (contact_first_name IS NOT NULL AND contact_first_name <> '') ";
					strQuery2 = $"{strQuery2}AND (contact_last_name IS NOT NULL AND contact_last_name <> '') ";
					strQuery2 = $"{strQuery2}ORDER BY contact_first_name, contact_last_name ";

					rstRec2.Open(strQuery2, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!rstRec2.BOF && !rstRec2.EOF)
					{

						do 
						{ // Loop Until rstRec1.EOF = true

							lContactIdCurr = Convert.ToInt32(rstRec1["contact_id"]);
							strContactName1 = modCommon.ReturnContactName(($"{Convert.ToString(rstRec1["contact_sirname"])} ").Trim(), ($"{Convert.ToString(rstRec1["contact_first_name"])} ").Trim(), ($"{Convert.ToString(rstRec1["contact_middle_initial"])} ").Trim(), ($"{Convert.ToString(rstRec1["contact_last_name"])} ").Trim(), ($"{Convert.ToString(rstRec1["contact_suffix"])} ").Trim());

							strLogin = ($"{Convert.ToString(rstRec1["subins_login"])} ").Trim();

							search_on("Checking - Do All Contacts Exists In New Company Record", $"Checking: {strContactName1}");

							rstRec2.MoveFirst();

							bFound = false;

							do 
							{ // Loop Until rstRec2.EOF = True Or bFound = True

								lContactIdNew = Convert.ToInt32(rstRec2["contact_id"]);
								strContactName2 = modCommon.ReturnContactName(($"{Convert.ToString(rstRec2["contact_sirname"])} ").Trim(), ($"{Convert.ToString(rstRec2["contact_first_name"])} ").Trim(), ($"{Convert.ToString(rstRec2["contact_middle_initial"])} ").Trim(), ($"{Convert.ToString(rstRec2["contact_last_name"])} ").Trim(), ($"{Convert.ToString(rstRec2["contact_suffix"])} ").Trim());

								if (strContactName1 == strContactName2)
								{
									if (($"{Convert.ToString(rstRec1["contact_email_address"])} ").Trim() == ($"{Convert.ToString(rstRec2["contact_email_address"])} ").Trim())
									{
										bFound = true;
									}
								}

								rstRec2.MoveNext();

							}
							while(!(rstRec2.EOF || bFound));

							if (bFound)
							{
								strMatchingContacts = $"{lContactIdCurr.ToString()}|{lContactIdNew.ToString()}|{strLogin}|{strContactName1}|{Environment.NewLine}";
							}
							else
							{

								if (MessageBox.Show($"Contact {strContactName1} Does NOT Exist In New Company Record{Environment.NewLine}Create A New Contact Record?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
								{

									lContactIdNew = 0;
									if (Create_New_Subscription_Contact_Record(lCompIdCurr, lCompIdNew, lContactIdCurr, ref lContactIdNew, strContactName1))
									{

										if (lContactIdNew != 0)
										{
											strMatchingContacts = $"{lContactIdCurr.ToString()}|{lContactIdNew.ToString()}|{strLogin}|{strContactName1}|{Environment.NewLine}";
											bFound = true;
										}
										else
										{
											strMissingContacts = $"{strContactName1}{Environment.NewLine}";
										}

									}
									else
									{
										strMissingContacts = $"{strContactName1}{Environment.NewLine}";
									} // If Create_New_Subscription_Contact_Record

								}
								else
								{
									strMissingContacts = $"{strContactName1}{Environment.NewLine}";
								} // If MsgBox

							} // If bFound = True Then

							rstRec1.MoveNext();

						}
						while(!rstRec1.EOF);

						if (strMissingContacts == "")
						{
							bResults = true;
						}

					}
					else
					{
						strMissingContacts = "There Are No Contacts In The New Company Record";
					} // If rstRec2.BOF = False And rstRec2.EOF = False Then

					rstRec2.Close();

				}
				else
				{
					//strMissingContacts = "This Subscription Has NO Contacts Related To Installs"
					bResults = true;
				} // If rstRec1.BOF = False And rstRec1.EOF = False Then

				rstRec1.Close();

				search_off();
				 // frm_Subscription

				rstRec2 = null;
				rstRec1 = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr = Information.Err().Number;
				strErrDesc = excep.Message;

				modAdminCommon.Report_Error($"Do_All_Subscription_Contacts_Exist_In_New_Company_Record: {strErrDesc}");

				MessageBox.Show($"Do_All_Subscription_Contacts_Exist_In_New_Company_Record_Error{Environment.NewLine}{strErrDesc}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);

				result = false;
			}
			return result;
		} // Do_All_Subscription_Contacts_Exist_In_New_Company_Record

		internal static bool Are_Any_Subscription_Contacts_Currently_Logged_Into_Evolution(int lCompIdCurr, int lSubId, ref string strContactsLoggedIn, string strLogin = "")
		{

			bool result = false;
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			int lErrNbr = 0;
			string strErrDesc = "";

			bool bResults = false;

			string strContactName1 = "";
			string strContactName2 = "";

			try
			{


				search_on("Checking - Any Subscription Contacts Currently Logged Into Evolution", "Any Currently Logged In");

				bResults = true;
				strContactsLoggedIn = "";

				strQuery1 = "SELECT contact_id, contact_sirname, contact_first_name, contact_middle_initial, contact_last_name, contact_suffix, ";
				strQuery1 = $"{strQuery1}contact_title, contact_email_address, ";
				strQuery1 = $"{strQuery1}subins_access_date, subins_last_login_date, subins_last_logout_date, subins_last_session_date ";
				strQuery1 = $"{strQuery1}FROM Contact WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}INNER JOIN Subscription_Install WITH (NOLOCK) ON subins_contact_id = contact_id ";
				strQuery1 = $"{strQuery1}INNER JOIN Subscription WITH (NOLOCK) ON sub_id = subins_sub_id ";
				strQuery1 = $"{strQuery1}WHERE (sub_id = {lSubId.ToString()}) ";
				strQuery1 = $"{strQuery1}AND (sub_comp_id = {lCompIdCurr.ToString()}) ";
				strQuery1 = $"{strQuery1}AND (subins_contact_id > 0) ";
				strQuery1 = $"{strQuery1}AND (contact_journ_id = 0) ";

				if (strLogin != "")
				{
					strQuery1 = $"{strQuery1}AND (subins_login = '{strLogin}') ";
				}
				strQuery1 = $"{strQuery1}ORDER BY contact_first_name, contact_last_name ";

				rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
				rstRec1.Open(strQuery1, frm_Subscription.DefInstance.REMOTE_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					bResults = false;
					do 
					{ // Loop Until rstRec1.EOF = True

						strContactName1 = modCommon.ReturnContactName(($"{Convert.ToString(rstRec1["contact_sirname"])} ").Trim(), ($"{Convert.ToString(rstRec1["contact_first_name"])} ").Trim(), ($"{Convert.ToString(rstRec1["contact_middle_initial"])} ").Trim(), ($"{Convert.ToString(rstRec1["contact_last_name"])} ").Trim(), ($"{Convert.ToString(rstRec1["contact_suffix"])} ").Trim());

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["subins_last_login_date"]))
						{
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (Convert.IsDBNull(rstRec1["subins_last_logout_date"]))
							{
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(rstRec1["subins_last_session_date"]))
								{
									if (ReflectionHelper.IsLessThanOrEqual(rstRec1["subins_last_login_date"], rstRec1["subins_last_session_date"]))
									{
										if (((int) DateAndTime.DateDiff("n", Convert.ToDateTime(rstRec1["subins_last_session_date"]), DateTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) < 120)
										{
											bResults = true;
											strContactsLoggedIn = $"{strContactsLoggedIn}{strContactName1}{Environment.NewLine}";
										}
									}
								}
							}
						}

						rstRec1.MoveNext();
						Application.DoEvents();

					}
					while(!rstRec1.EOF);

				}
				else
				{
					bResults = false; // Ok With No Installs
				} // If rstRec1.BOF = False And rstRec1.EOF = False Then

				rstRec1.Close();

				search_off();

				rstRec1 = null;
				 // frm_Subscription


				return bResults;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr = Information.Err().Number;
				strErrDesc = excep.Message;

				modAdminCommon.Report_Error($"Are_Any_Subscription_Contacts_Currently_Logged_Into_Evolution_Error: {strErrDesc}");

				MessageBox.Show($"Are_Any_Subscription_Contacts_Currently_Logged_Into_Evolution_Error{Environment.NewLine}{strErrDesc}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);

				result = true;
			}
			return result;
		} // Are_Any_Subscription_Contacts_Currently_Logged_Into_Evoltuion

		//-----------------------------------------------
		// Created: 01/23/2014 - By David D. Cruger

		internal static bool Does_Subscription_Have_CRM_Or_Cloud_Notes(int lCompId, int lSubId)
		{


			bool bResults = false;


			if (frm_Subscription.DefInstance.chkServerSideNotes.CheckState == CheckState.Checked || frm_Subscription.DefInstance.chkCloudNotesFlag.CheckState == CheckState.Checked)
			{
				bResults = true;
			}
			 // frm_Subscription

			return bResults;

		} // Does_Subscription_Have_CRM_Or_Cloud_Notes


		internal static bool Validate_Subscription_Can_Be_Moved(int lCompId, int lSubId)
		{

			string strContactsLoggedIn = "";

			bool bResults = false;

			if (lCompId > 0)
			{

				if (lSubId > 0)
				{

					if (lCompId != 135887)
					{

						if (!Does_Subscription_Have_CRM_Or_Cloud_Notes(lCompId, lSubId))
						{

							if (!Are_Any_Subscription_Contacts_Currently_Logged_Into_Evolution(lCompId, lSubId, ref strContactsLoggedIn, ""))
							{

								bResults = true; // Ok To Move

							}
							else
							{
								MessageBox.Show($"Some Subscription Contacts Are Currently Logged Into Evolution{Environment.NewLine}Can NOT Move{Environment.NewLine}{Environment.NewLine}{strContactsLoggedIn}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							} // If Are_Any_Subscription_Contacts_Currently_Logged_Into_Evolution(lCompIdCurr, lCompIdNew, lSubId, strContactsLoggedIn, "") = False Then

						}
						else
						{
							MessageBox.Show($"Subscription Has CRM or Cloud Notes Attached{Environment.NewLine}Can NOT Move", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						} // If Does_Subscription_Have_CRM_Or_Cloud_Notes(lCompId, lSubId) = False Then

					}
					else
					{
						MessageBox.Show("Can NOT Move A JETNET Subscription", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					} // If lCompId <> 135887 Then

				}
				else
				{
					MessageBox.Show("Invalid SubId {Blank}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If lSubId > 0 Then

			}
			else
			{
				MessageBox.Show("Invalid CompId {Blank}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
			} // If lCompId > 0 Then

			return bResults;

		} // Validate_Subscription_Can_Be_Moved

		internal static bool Validate_Subscription_Login_Can_Be_Moved(int lCompId, int lSubId, string strLogin)
		{

			string strContactsLoggedIn = "";

			bool bResults = false;

			if (lCompId > 0)
			{

				if (lSubId > 0)
				{

					if (strLogin != "")
					{

						if (lCompId != 135887)
						{

							if (!Are_Any_Subscription_Contacts_Currently_Logged_Into_Evolution(lCompId, lSubId, ref strContactsLoggedIn, strLogin))
							{

								bResults = true; // Ok To Move

							}
							else
							{
								MessageBox.Show($"This Subscription Login Is Currently Logged Into Evolution{Environment.NewLine}Can NOT Move{Environment.NewLine}{Environment.NewLine}{strContactsLoggedIn}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							} // If Are_Any_Subscription_Contacts_Currently_Logged_Into_Evolution(lCompIdCurr, lCompIdNew, lSubId, strContactsLoggedIn, strLogin) = False Then

						}
						else
						{
							MessageBox.Show("Can NOT Move A JETNET Subscription", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						} // If lCompId <> 135887 Then

					}
					else
					{
						MessageBox.Show("Invalid Login {Blank}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					} // If strLogin <> "" Then

				}
				else
				{
					MessageBox.Show("Invalid SubId {Blank}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If lSubId > 0 Then

			}
			else
			{
				MessageBox.Show("Invalid CompId {Blank}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
			} // If lCompId > 0 Then

			return bResults;

		} // Validate_Subscription_Login_Can_Be_Moved

		internal static int Get_Current_User_ContactId()
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";


			int lResults = 0;

			if (($"{Convert.ToString(modAdminCommon.snp_User["user_last_name"])} ").Trim() != "" && ($"{Convert.ToString(modAdminCommon.snp_User["user_email_address"])} ").Trim() != "")
			{

				strQuery1 = "SELECT contact_id  FROM Contact WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (contact_comp_id = 135887)  AND (contact_journ_id = 0) ";
				strQuery1 = $"{strQuery1}AND (contact_last_name = '{Convert.ToString(modAdminCommon.snp_User["user_last_name"])}') ";
				strQuery1 = $"{strQuery1}AND (contact_email_address = '{Convert.ToString(modAdminCommon.snp_User["user_email_address"])}') ";

				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{
					lResults = Convert.ToInt32(rstRec1["contact_id"]);
				}

				rstRec1.Close();

			} // If Trim(snp_User!user_last_name & " ") <> "" And Trim(snp_User!user_email_address & " ") <> "" Then

			rstRec1 = null;


			return lResults;



			modAdminCommon.Record_Error("Get_Current_User_ContactId_Error", Information.Err().Description);

			return 0;

		} // Get_Current_User_ContactId

		internal static bool Does_Current_User_Have_JETNETAPI_Login(ref int lContactId, ref int lSubId, ref string strLogin, ref int lSeqNbr, ref string strEMail, ref string strPassword)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";


			bool bResults = false;

			lSubId = 0;
			strLogin = "";
			lSeqNbr = 0;
			strEMail = "";
			strPassword = "";

			lContactId = Get_Current_User_ContactId();

			if (lContactId > 0)
			{

				strQuery1 = "SELECT sub_id, sublogin_login, subins_seq_no, contact_email_address, sublogin_password, subins_session_guid ";
				strQuery1 = $"{strQuery1}FROM Subscription WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}INNER JOIN Subscription_Login WITH (NOLOCK) ON sub_id = sublogin_sub_id ";
				strQuery1 = $"{strQuery1}INNER JOIN Subscription_Install WITH (NOLOCK) ON sublogin_sub_id = subins_sub_id AND sublogin_login = subins_login ";
				strQuery1 = $"{strQuery1}INNER JOIN Contact WITH (NOLOCK) ON subins_contact_id = contact_id AND contact_journ_id = 0 ";
				strQuery1 = $"{strQuery1}WHERE (sub_start_date IS NOT NULL) ";
				strQuery1 = $"{strQuery1}AND (sub_start_date <= GetDate()) ";
				strQuery1 = $"{strQuery1}AND (sub_end_date IS NULL OR sub_end_date > GetDate())";
				strQuery1 = $"{strQuery1}AND (sub_serv_code = 'OAPI') ";
				strQuery1 = $"{strQuery1}AND (sub_comp_id = 135887) AND (sub_aerodex_flag = 'N') ";
				strQuery1 = $"{strQuery1}AND (sublogin_active_flag = 'Y')  AND (subins_active_flag = 'Y') ";
				strQuery1 = $"{strQuery1}AND (subins_contact_id = {lContactId.ToString()}) ";

				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					lSubId = Convert.ToInt32(rstRec1["sub_id"]);
					strLogin = ($"{Convert.ToString(rstRec1["sublogin_login"])} ").Trim();
					lSeqNbr = Convert.ToInt32(rstRec1["subins_seq_no"]);
					strEMail = ($"{Convert.ToString(rstRec1["contact_email_address"])} ").Trim();
					strPassword = ($"{Convert.ToString(rstRec1["sublogin_password"])} ").Trim();

					bResults = true;

				} // If rstRec1.BOF = False And rstRec1.EOF = False Then

				rstRec1.Close();

			} // If lContactId > 0 Then

			rstRec1 = null;


			return bResults;



			modAdminCommon.Record_Error("Does_Current_User_Have_JETNETAPI_Login_Error", Information.Err().Description);

			return false;

		} // Does_Current_User_Have_JETNETAPI_Login

		internal static bool IsSubscriptionServiceCodeForSalesForce(string strSerCode)
		{

			bool result = false;
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			bool bResults = false;

			try
			{

				bResults = false;

				strSerCode = ($"{strSerCode} ").Trim().ToUpper();

				if (strSerCode != "")
				{

					strQuery1 = "SELECT serv_code FROM [Service] WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1}WHERE (serv_active_flag = 'Y') ";
					strQuery1 = $"{strQuery1}AND (serv_name LIKE '%Salesforce%') ";
					strQuery1 = $"{strQuery1}AND (serv_code = '{strSerCode}') ";

					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!rstRec1.BOF && !rstRec1.EOF)
					{
						bResults = true;
					}

					rstRec1.Close();

				} // If strSerCode <> "" Then

				rstRec1 = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("IsSubscriptionServiceCodeForSalesForce_Error", excep.Message);

				result = false;
			}
			return result;
		} // IsSubscriptionServiceCodeForSalesForce

		// 11/20/2019 - By David D. Cruger
		// This ONLY Gets Call If On A JETNET for Salesforce Or Aerodex for Salesforce Subscription

		internal static void Copy_Logins_From_Another_SubId(int lCompId, int lSubId)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper(); // Login
			ADORecordSetHelper rstRec2 = new ADORecordSetHelper(); // Install

			ADORecordSetHelper rstAdd1 = new ADORecordSetHelper(); // Login
			ADORecordSetHelper rstAdd2 = new ADORecordSetHelper(); // Install

			string strQuery1 = "";
			string strQuery2 = "";
			string strAdd1 = "";
			string strAdd2 = "";

			int lFromSubId = 0;
			string strFromSubId = "";
			int lFromCompId = 0;

			string strLogin = "";
			string strPassword = "";
			string strNewPassword = "";
			string strTestLogin = "";
			string strInsert1 = "";
			string strDelete1 = "";
			string strTemp1 = "";

			string strErrMsg = "";

			try
			{

				if (lCompId > 0)
				{

					if (lSubId > 0)
					{

						strFromSubId = "0";
						strFromSubId = InputBoxHelper.InputBox("Enter From SubId", "Copy Logins");

						if (strFromSubId != "")
						{

							if (Information.IsNumeric(strFromSubId))
							{

								lFromSubId = Convert.ToInt32(Double.Parse(strFromSubId));
								if (lFromSubId > 0)
								{

									strFromSubId = lFromSubId.ToString();

									// Is From SubId From The Same Company Record
									strTemp1 = modCommon.DLookUp("sub_comp_id", "Subscription", $"(sub_id = {strFromSubId})");

									if (strTemp1 != "")
									{

										lFromCompId = Convert.ToInt32(Double.Parse(strTemp1));
										if (lCompId == lFromCompId)
										{

											modAdminCommon.Record_Event("Subscription", $"Copy All Logins From CompId: [{lCompId.ToString()} SubId: [{lFromSubId.ToString()}] To SubId: [{lSubId.ToString()}]", 0, 0, lCompId, false, 0, 0);

											search_on("Copy All Logins...", "");

											// Get ALL Active Logins From SubId
											strQuery1 = "SELECT * FROM Subscription_Login WITH (NOLOCK) ";
											strQuery1 = $"{strQuery1}WHERE (sublogin_sub_id = {lFromSubId.ToString()}) ";
											strQuery1 = $"{strQuery1}AND (sublogin_active_flag = 'Y') ORDER BY sublogin_login ";

											rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

											if (!rstRec1.BOF && !rstRec1.EOF)
											{

												// Loop Through Logins And Add Login/Install

												do 
												{ // Loop Until rstRec1.EOF = True

													strLogin = ($"{Convert.ToString(rstRec1["sublogin_login"])} ").Trim();
													strPassword = ($"{Convert.ToString(rstRec1["sublogin_password"])} ").Trim();

													search_on("Copy All Logins...", $"Copying Login Name: {strLogin}");

													// Need To Check To See If Login Exists
													strAdd1 = $"SELECT * FROM Subscription_Login WHERE (sublogin_sub_id = {lSubId.ToString()}) AND (sublogin_login = '{strLogin}') ";
													rstAdd1.Open(strAdd1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);

													if (rstAdd1.BOF && rstAdd1.EOF)
													{

														// New Password Can NOT Exist
														strNewPassword = "";
														do 
														{
															strNewPassword = modCommon.GeneratePassword(lSubId);
															strTestLogin = modCommon.DLookUp("sublogin_login", "Subscription_Login", $"(sublogin_password = '{strNewPassword}')");
															if (strTestLogin != "")
															{
																strNewPassword = "";
															}
														}
														while(strNewPassword == "");

														// Add New Login
														rstAdd1.AddNew();

														rstAdd1["sublogin_sub_id"] = lSubId;
														rstAdd1["sublogin_login"] = strLogin;
														rstAdd1["sublogin_password"] = strNewPassword;
														rstAdd1["sublogin_active_flag"] = "Y";
														rstAdd1["sublogin_demo_flag"] = "N";
														rstAdd1["sublogin_nbr_of_installs"] = 1;
														rstAdd1["sublogin_contract_amount"] = 0;
														rstAdd1["sublogin_allow_export_flag"] = "Y";
														rstAdd1["sublogin_allow_local_notes_flag"] = "N";
														rstAdd1["sublogin_allow_projects_flag"] = "N";
														rstAdd1["sublogin_allow_email_request_flag"] = "N";
														rstAdd1["sublogin_bypass_active_x_registry_flag"] = "N";
														rstAdd1["sublogin_allow_text_message_flag"] = "N";
														rstAdd1["sublogin_mpm_flag"] = "N";
														rstAdd1["sublogin_values_flag"] = "N";

														rstAdd1.UpdateBatch();

														strTemp1 = $"CompId:=[{lCompId.ToString()}] ";
														strTemp1 = $"{strTemp1}SubId:=[{lSubId.ToString()}]  ";
														strTemp1 = $"{strTemp1}Login:=[{strLogin}]  ";

														modAdminCommon.Record_Event("Subscription Login Added", strTemp1, 0, 0, lCompId);

														//---------------------------------------
														// Find All Active Installs

														// Get ALL Active Installs From SubId/Login
														strQuery2 = "SELECT * FROM Subscription_Install WITH (NOLOCK) ";
														strQuery2 = $"{strQuery2}WHERE (subins_sub_id = {lFromSubId.ToString()}) ";
														strQuery2 = $"{strQuery2}AND (subins_login = '{strLogin}') ";
														strQuery2 = $"{strQuery2}AND (subins_active_flag = 'Y') ORDER BY subins_seq_no ";

														rstRec2.Open(strQuery2, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

														if (!rstRec2.BOF && !rstRec2.EOF)
														{

															// Delete Any Installs Tied To This New Login - There Shouldn't be any
															strDelete1 = $"DELETE FROM Subscription_Install WHERE (subins_sub_id = {lSubId.ToString()}) AND (subins_login = '{strLogin}') ";
															DbCommand TempCommand = null;
															TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
															UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
															TempCommand.CommandText = strDelete1;
															//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
															//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
															TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
															UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
															TempCommand.ExecuteNonQuery();

															// Create Add Install RecordSet
															strAdd2 = $"SELECT * FROM Subscription_Install WHERE (subins_sub_id = {lSubId.ToString()}) AND (subins_login = '{strLogin}') ";
															rstAdd2.Open(strAdd2, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);

															// Now Add All Active Installs

															do 
															{ // Loop Until rstRec2.EOF = False

																rstAdd2.AddNew();

																rstAdd2["subins_sub_id"] = lSubId; // Current SubId
																rstAdd2["subins_login"] = rstRec2["subins_login"];
																rstAdd2["subins_seq_no"] = rstRec2["subins_seq_no"];
																rstAdd2["subins_platform_name"] = rstRec2["subins_platform_name"];
																rstAdd2["subins_platform_os"] = rstRec2["subins_platform_os"];
																rstAdd2["subins_active_flag"] = rstRec2["subins_active_flag"];
																rstAdd2["subins_contact_id"] = rstRec2["subins_contact_id"];
																rstAdd2["subins_admin_flag"] = rstRec2["subins_admin_flag"];

																rstAdd2.UpdateBatch();

																rstRec2.MoveNext();

															}
															while(!rstRec2.EOF);

															rstAdd2.Close();

														} // If rstRec2.BOF = False And rstRec2.EOF = False Then

														rstRec2.Close();

													} // If rstAdd1.BOF = True And rstAdd1.EOF = True Then

													rstAdd1.Close();

													rstRec1.MoveNext();
													Application.DoEvents();

												}
												while(!rstRec1.EOF);

												search_on("Copy All Logins...", "Process Complete");
												modCommon.DelaySeconds(2);

											}
											else
											{
												MessageBox.Show($"No Logins To Copy From SubId: [{lFromSubId.ToString()}]", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
											} // If rstRec1.BOF = False And rstRec1.EOF = False Then

											rstRec1.Close();

										}
										else
										{
											MessageBox.Show($"From SubId - CompId Is NOT The Same As Current CompId{Environment.NewLine}{Environment.NewLine}Current CompId: [{lCompId.ToString()}  From CompId: [{lFromCompId.ToString()}]", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
										} // If lCompId = lFromCompId Then

									}
									else
									{
										MessageBox.Show($"From SubId - NOT Found [{strFromSubId}]", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
									} // If strTemp1 <> "" Then

								}
								else
								{
									MessageBox.Show("SubId Entered Is Less Than 1", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
								} // If lFromSubId > 0 Then

							}
							else
							{
								MessageBox.Show("SubId Entered Is NOT Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							} // If IsNumeric(strFromSubId) = True Then

						} // If strFromSubId <> "" Then

					}
					else
					{
						MessageBox.Show("Current SubId Is Blank/Zero", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					} // If lSubId > 0 Then

				}
				else
				{
					MessageBox.Show("Current CompId Is Blank/Zero", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If lCompId > 0 Then

				search_off();
				Application.DoEvents();

				rstAdd2 = null;
				rstAdd1 = null;
				rstRec2 = null;
				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				strErrMsg = excep.Message;
				modAdminCommon.Record_Error("Copy_Logins_From_Another_SubId_Error", strErrMsg);

				MessageBox.Show($"Copy_Logins_From_Another_SubId_Error{Environment.NewLine}{Environment.NewLine}{strErrMsg}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		} // Copy_Logins_From_Another_SubId

		internal static bool DoesForgotPasswordTokenExistsOnHomebaseAndEvolution(int lSubId, string strLogin, ref string strReason)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			int lTot1 = 0;

			string strEvoToken = "";
			System.DateTime dtEvoTokenDate = DateTime.FromOADate(0);

			string strHBToken = "";
			System.DateTime dtHBTokenDate = DateTime.FromOADate(0);


			bool bResults = false;
			strReason = "";

			if (lSubId > 0 && strLogin != "")
			{

				strQuery1 = "SELECT ";
				strQuery1 = $"{strQuery1}'Evo-Live' As SubLoginSource, ";
				strQuery1 = $"{strQuery1}sublogin_sub_id, ";
				strQuery1 = $"{strQuery1}sublogin_login, ";
				strQuery1 = $"{strQuery1}sublogin_forgot_password_token, ";
				strQuery1 = $"{strQuery1}sublogin_forgot_password_token_date, ";
				strQuery1 = $"{strQuery1}sublogin_web_action_date ";
				strQuery1 = $"{strQuery1}FROM [EVO_Live].jetnet_ra.dbo.Subscription_Login WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (sublogin_sub_id = {lSubId.ToString()}) ";
				strQuery1 = $"{strQuery1}AND (sublogin_login = '{strLogin}') ";
				strQuery1 = $"{strQuery1}UNION ALL ";
				strQuery1 = $"{strQuery1}SELECT ";
				strQuery1 = $"{strQuery1}'HB-Live' As SubLoginSource, ";
				strQuery1 = $"{strQuery1}sublogin_sub_id, ";
				strQuery1 = $"{strQuery1}sublogin_login, ";
				strQuery1 = $"{strQuery1}sublogin_forgot_password_token, ";
				strQuery1 = $"{strQuery1}sublogin_forgot_password_token_date, ";
				strQuery1 = $"{strQuery1}sublogin_web_action_date ";
				strQuery1 = $"{strQuery1}FROM [Homebase].jetnet_ra.dbo.Subscription_Login WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (sublogin_sub_id = {lSubId.ToString()}) ";
				strQuery1 = $"{strQuery1}AND (sublogin_login = '{strLogin}') ";
				strQuery1 = $"{strQuery1}ORDER BY SubLoginSource ";

				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					lTot1 = rstRec1.RecordCount;

					// Must be Two Exactly
					if (lTot1 == 2)
					{

						strEvoToken = "";
						dtEvoTokenDate = DateTime.FromOADate(0);

						strHBToken = "";
						dtHBTokenDate = DateTime.FromOADate(0);

						strEvoToken = ($"{Convert.ToString(rstRec1["sublogin_forgot_password_token"])} ").Trim();
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["sublogin_forgot_password_token_date"]))
						{
							dtEvoTokenDate = Convert.ToDateTime(rstRec1["sublogin_forgot_password_token_date"]);
						}

						rstRec1.MoveNext();

						strHBToken = ($"{Convert.ToString(rstRec1["sublogin_forgot_password_token"])} ").Trim();

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["sublogin_forgot_password_token_date"]))
						{
							dtHBTokenDate = Convert.ToDateTime(rstRec1["sublogin_forgot_password_token_date"]);
						}

						if (strEvoToken != "" && strHBToken != "")
						{

							if (dtEvoTokenDate > DateTime.Parse("1/1/1988") && dtHBTokenDate > DateTime.Parse("1/1/1988"))
							{

								if (strEvoToken == strHBToken)
								{

									if (dtEvoTokenDate == dtHBTokenDate)
									{
										bResults = true;
										strReason = "Tokens and Expire Date - MATCH";
									}
									else
									{
										strReason = "Evolution and Homebase Token Expires Dates Do NOT Match";
									} // If dtEvoTokenDate = dtHBTokenDate Then

								}
								else
								{
									strReason = "Evolution and Homebase Tokens Do NOT Match";
								} // If strEvoToken = strHBToken Then

							}
							else
							{
								strReason = "Either Evo or HB Token Date Is Blank";
							} // If dtEvoTokenDate > CDate("1/1/1988") And dtHBTokenDate > CDate("1/1/1988") Then

						}
						else
						{
							strReason = "Either Evo or HB Token Is Blank";
						} // If strEvoToken <> "" And strHBToken <> "" Then

					}
					else
					{
						strReason = "Invalid Number Of Records Returned = Nbr Records Must = 2";
					} // If lTot1 = 2 Then

				}
				else
				{
					strReason = "Could NOT Find Any Subscription/Login Records";
				} // If rstRec1.BOF = False And rstRec1.EOF = False Then

				rstRec1.Close();

			}
			else
			{
				strReason = "SubId Or Login Is Blank";
			} //   If lSubId > 0 And strLogin <> "" Then

			rstRec1 = null;


			return bResults;



			string strErrMsg = Information.Err().Description;
			modAdminCommon.Record_Error("DoesForgotPasswordTokenExistsOnHomebaseAndEvolution_Error", strErrMsg);

			MessageBox.Show($"DoesForgotPasswordTokenExistsOnHomebaseAndEvolution_Error{Environment.NewLine}{Environment.NewLine}{strErrMsg}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);

			return false;
		} // DoesForgotPasswordTokenExistsOnHomebaseAndEvolution
	}
}