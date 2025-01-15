using System.Runtime.InteropServices;
using System;
using System.Diagnostics;

namespace JetNetSupport.PInvoke.SafeNative
{
	public static class kernel32
	{

		public static int CloseHandle(int hObject) => JetNetSupport.PInvoke.UnsafeNative.kernel32.CloseHandle(hObject);

		public static int GetComputerName(ref string lpBuffer, ref int nSize) => JetNetSupport.PInvoke.UnsafeNative.kernel32.GetComputerName(ref lpBuffer, ref nSize);

		public static int lstrcat(ref string lpString1, ref string lpString2) => JetNetSupport.PInvoke.UnsafeNative.kernel32.lstrcat(ref lpString1, ref lpString2);

		public static int OpenProcess(int dwDesiredAccess, int bInheritHandle, int dwProcessId) => JetNetSupport.PInvoke.UnsafeNative.kernel32.OpenProcess(dwDesiredAccess, bInheritHandle, dwProcessId);

		public static void Sleep(int dwMilliseconds) => JetNetSupport.PInvoke.UnsafeNative.kernel32.Sleep(dwMilliseconds);

	}
}