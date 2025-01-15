using System.Runtime.InteropServices;
using System;
using System.Diagnostics;

namespace JetNetSupport.PInvoke.UnsafeNative
{
	[System.Security.SuppressUnmanagedCodeSecurity]
	public static class advapi32
	{

		[DllImport("advapi32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		extern public static int RegCloseKey(int hKey);
		[DllImport("advapi32.dll", EntryPoint = "RegCreateKeyExA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		extern public static int RegCreateKeyEx(int hKey, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpSubKey, int Reserved, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpClass, int dwOptions, int samDesired, int lpSecurityAttributes, ref int phkResult, ref int lpdwDisposition);
		[DllImport("advapi32.dll", EntryPoint = "RegEnumValueA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		extern public static int RegEnumValue(int hKey, int dwIndex, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpValueName, ref int lpcbValueName, int lpReserved, ref int lpType, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpData, ref int lpcbData);
		[DllImport("advapi32.dll", EntryPoint = "RegOpenKeyExA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		extern public static int RegOpenKeyEx(int hKey, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpSubKey, int ulOptions, int samDesired, ref int phkResult);
		[DllImport("advapi32.dll", EntryPoint = "RegQueryValueExA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		extern public static int RegQueryValueExLong(int hKey, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpValueName, int lpReserved, ref int lpType, ref int lpData, ref int lpcbData);
		[DllImport("advapi32.dll", EntryPoint = "RegQueryValueExA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		extern public static int RegQueryValueExNULL(int hKey, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpValueName, int lpReserved, ref int lpType, int lpData, ref int lpcbData);
		[DllImport("advapi32.dll", EntryPoint = "RegQueryValueExA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		extern public static int RegQueryValueExString(int hKey, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpValueName, int lpReserved, ref int lpType, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpData, ref int lpcbData);
		[DllImport("advapi32.dll", EntryPoint = "RegSetValueExA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		extern public static int RegSetValueExLong(int hKey, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpValueName, int Reserved, int dwType, ref int lpValue, int cbData);
		[DllImport("advapi32.dll", EntryPoint = "RegSetValueExA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		extern public static int RegSetValueExString(int hKey, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpValueName, int Reserved, int dwType, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpValue, int cbData);
	}
}