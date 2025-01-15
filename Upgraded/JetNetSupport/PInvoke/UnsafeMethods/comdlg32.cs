using System.Runtime.InteropServices;
using System;
using System.Diagnostics;

namespace JetNetSupport.PInvoke.UnsafeNative
{
	[System.Security.SuppressUnmanagedCodeSecurity]
	public static class comdlg32
	{

		//UPGRADE_TODO: (1050) Structure OPENFILENAME may require marshalling attributes to be passed as an argument in this Declare statement. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1050
		[DllImport("comdlg32.dll", EntryPoint = "GetOpenFileNameA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		extern public static int GetOpenFileName(ref JetNetSupport.PInvoke.UnsafeNative.Structures.OPENFILENAME pOpenfilename);
	}
}