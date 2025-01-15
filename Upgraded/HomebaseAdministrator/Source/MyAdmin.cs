using Microsoft.VisualBasic;
using System;
using System.Data.Common;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Helpers;

namespace HomebaseAdministrator
{
	internal static class modMyAdmin
	{


		private static ADORecordSetHelper _MYSNP_USER = null;
		internal static ADORecordSetHelper MYSNP_USER
		{
			get
			{
				if (_MYSNP_USER is null)
				{
					_MYSNP_USER = new ADORecordSetHelper();
				}
				return _MYSNP_USER;
			}
			set => _MYSNP_USER = value;
		}


		//UPGRADE_NOTE: (2041) The following line was commented. More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-2041
		//[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		//extern public static void Sleep(int dwMilliseconds);

		internal static void Record_EventAdmin(string inType, string inText, int inAC_ID = 0, int inJourn_ID = 0, int inComp_ID = 0)
		{

			if (Strings.Len(inText) > 2000)
			{ //Too Big
				inText = $"{inText.Substring(0, Math.Min(1990, inText.Length))}**TO BIG**";
			}

			string Query = "INSERT into EventLog (evtl_date, evtl_user_id, evtl_type, evtl_message, evtl_ac_id, evtl_journ_id, evtl_comp_id) ";
			Query = $"{Query}VALUES ('{StringsHelper.Format(DateTime.Now, "General Date")}', ";
			// the MYSNP user id is getting lost sometimes, but we still have the global - 12/15/21
			if (modAdminCommon.gbl_User_ID.Trim() != "")
			{
				Query = $"{Query}'{modAdminCommon.gbl_User_ID.Trim()}', ";
			}
			else
			{
				Query = $"{Query}'{Convert.ToString(MYSNP_USER["user_id"])}', ";
			}


			Query = $"{Query}'{inType}', '{modAdminCommon.Fix_Quote(inText)}', {inAC_ID.ToString()},{inJourn_ID.ToString()},{inComp_ID.ToString()})";

			DbCommand TempCommand = null;
			TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
			UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
			TempCommand.CommandText = Query;
			UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
			TempCommand.ExecuteNonQuery();

			Application.DoEvents();
		}
		internal static void Delay(int Seconds) => JetNetSupport.PInvoke.SafeNative.kernel32.Sleep(Seconds * 1000);

	}
}