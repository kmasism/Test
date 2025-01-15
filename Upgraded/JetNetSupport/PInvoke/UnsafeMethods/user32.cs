using System.Runtime.InteropServices;
using System;
using System.Diagnostics;

namespace JetNetSupport.PInvoke.UnsafeNative
{
	[System.Security.SuppressUnmanagedCodeSecurity]
	public static class user32
	{

		//UPGRADE_TODO: (1050) Structure POINTAPI may require marshalling attributes to be passed as an argument in this Declare statement. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1050
		[DllImport("user32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		extern public static int GetCursorPos(ref JetNetSupport.PInvoke.UnsafeNative.Structures.POINTAPI lpPoint);
		[DllImport("user32.dll", EntryPoint = "SendMessageA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		extern public static int SendMessage(int hWnd, int wMsg, int wParam, System.IntPtr lparam);
		[DllImport("user32.dll", EntryPoint = "SystemParametersInfoA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		extern public static int SystemParametersInfo(int uAction, int uParam, System.IntPtr lpvParam, int fuWinIni);
	}
}