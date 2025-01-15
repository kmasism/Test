using Microsoft.VisualBasic;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using UpgradeHelpers.Helpers;

namespace JETNET_Homebase
{
	internal static class modTAPI
	{


		//UPGRADE_NOTE: (2041) The following line was commented. More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-2041
		//[DllImport("TAPI32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		//extern public static int tapiRequestMakeCall([MarshalAs(UnmanagedType.VBByRefStr)] ref string DestAddress, [MarshalAs(UnmanagedType.VBByRefStr)] ref string AppName, [MarshalAs(UnmanagedType.VBByRefStr)] ref string CalledParty, [MarshalAs(UnmanagedType.VBByRefStr)] ref string Comment);
		private const int TAPIERR_NOREQUESTRECIPIENT = -2;
		private const int TAPIERR_REQUESTQUEUEFULL = -3;
		private const int TAPIERR_INVALDESTADDRESS = -4;

		// Something Else To Review Is
		// [ ] TAPI3 Terminal Manager 1.0 Type Library

		internal static void TAPIDialer(string strPhoneNumber)
		{

			string strMsg = "";

			string tempRefParam = "";
			string tempRefParam2 = "";
			int lResult = JetNetSupport.PInvoke.SafeNative.tapi32.tapiRequestMakeCall(ref strPhoneNumber, ref tempRefParam, ref strPhoneNumber, ref tempRefParam2);

			if (lResult != 0)
			{

				strMsg = "Error dialing number : ";

				switch(lResult)
				{
					case TAPIERR_NOREQUESTRECIPIENT : 
						strMsg = $"{strMsg}No Windows Telephony dialing application is running and none could be started."; 
						break;
					case TAPIERR_REQUESTQUEUEFULL : 
						strMsg = $"{strMsg}The queue of pending Windows Telephony dialing requests is full."; 
						break;
					case TAPIERR_INVALDESTADDRESS : 
						strMsg = $"{strMsg}The phone number is not valid."; 
						break;
					default:
						strMsg = $"{strMsg}Unknown error."; 
						break;
				}

				MessageBox.Show(strMsg, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);

			} // If lResult <> 0 Then

		} // TAPIDialer
	}
}