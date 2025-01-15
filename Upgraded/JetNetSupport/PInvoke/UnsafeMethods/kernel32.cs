using System.Runtime.InteropServices;
using System;
using System.Diagnostics;

namespace JetNetSupport.PInvoke.UnsafeNative
{
	[System.Security.SuppressUnmanagedCodeSecurity]
	public static class kernel32
	{

		[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		extern public static int CloseHandle(int hObject);
		[DllImport("Kernel32.dll", EntryPoint = "GetComputerNameA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		extern public static int GetComputerName([MarshalAs(UnmanagedType.VBByRefStr)] ref string lpBuffer, ref int nSize);
		[DllImport("Kernel32.dll", EntryPoint = "lstrcatA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		extern public static int lstrcat([MarshalAs(UnmanagedType.VBByRefStr)] ref string lpString1, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpString2);
		[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		extern public static int OpenProcess(int dwDesiredAccess, int bInheritHandle, int dwProcessId);
		[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		extern public static void Sleep(int dwMilliseconds);
	}
}