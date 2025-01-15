using System;

namespace JETNET_Homebase
{
	internal static class modCallOne
	{


		// ====================================================================================
		// Written By : David D. Cruger
		// Created    : 12/09/2020
		// Modified   : 12/09/2020
		// Function   : CallOne_Dialer
		// Parameters : ByRef strPhoneNbr As String
		//
		// Returns    : Boolean
		//
		// Notes      : Using the WScript.Shell command and if a phone number has been
		// past issues the Run command for the "callto" protocol.  This should be setup
		// for CallOne UC for Auto Dialing.  Note USA requires no prefix while international
		// requires the country codes.  That formatting is done in another procedure.
		// This is just the auto dial routine.
		//
		// ====================================================================================

		internal static bool CallOne_Dialer(string strPhoneNbr)
		{

			// Artical On WScript.Shell
			// https://www.informit.com/articles/article.aspx?p=1187429&seqNum=5

			IWshRuntimeLibrary.WshShell oCallOne = null;

			bool bResults = false;

			if (strPhoneNbr != "")
			{

				oCallOne = new IWshRuntimeLibrary.WshShell();

				if (oCallOne != null)
				{

					object tempRefParam = 1;
					object tempRefParam2 = false;
					oCallOne.Run($"callto:{strPhoneNbr}", ref tempRefParam, ref tempRefParam2);

					bResults = true;

				}

				oCallOne = null;

			} // If strPhoneNbr <> "" Then

			return bResults;

		} // CallOne_Dialer
	}
}