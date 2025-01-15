using System.Runtime.InteropServices;
using System;
using System.Diagnostics;

namespace JetNetSupport.PInvoke.UnsafeNative
{
	[System.Security.SuppressUnmanagedCodeSecurity]
	public static class ole32
	{

		//UPGRADE_TODO: (1050) Structure GUID may require marshalling attributes to be passed as an argument in this Declare statement. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1050
		[DllImport("OLE32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		extern public static int CoCreateGuid(ref JetNetSupport.PInvoke.UnsafeNative.Structures.GUID pGuid);
	}
}