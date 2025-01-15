using System.Runtime.InteropServices;
using System;
using System.Diagnostics;

namespace JetNetSupport.PInvoke.SafeNative
{
	public static class advapi32
	{

		public static int RegCloseKey(int hKey) => JetNetSupport.PInvoke.UnsafeNative.advapi32.RegCloseKey(hKey);

		public static int RegCreateKeyEx(int hKey, ref string lpSubKey, int Reserved, ref string lpClass, int dwOptions, int samDesired, int lpSecurityAttributes, ref int phkResult, ref int lpdwDisposition) => JetNetSupport.PInvoke.UnsafeNative.advapi32.RegCreateKeyEx(hKey, ref lpSubKey, Reserved, ref lpClass, dwOptions, samDesired, lpSecurityAttributes, ref phkResult, ref lpdwDisposition);

		public static int RegOpenKeyEx(int hKey, ref string lpSubKey, int ulOptions, int samDesired, ref int phkResult) => JetNetSupport.PInvoke.UnsafeNative.advapi32.RegOpenKeyEx(hKey, ref lpSubKey, ulOptions, samDesired, ref phkResult);

		public static int RegQueryValueExLong(int hKey, ref string lpValueName, int lpReserved, ref int lpType, ref int lpData, ref int lpcbData) => JetNetSupport.PInvoke.UnsafeNative.advapi32.RegQueryValueExLong(hKey, ref lpValueName, lpReserved, ref lpType, ref lpData, ref lpcbData);

		public static int RegQueryValueExString(int hKey, ref string lpValueName, int lpReserved, ref int lpType, ref string lpData, ref int lpcbData) => JetNetSupport.PInvoke.UnsafeNative.advapi32.RegQueryValueExString(hKey, ref lpValueName, lpReserved, ref lpType, ref lpData, ref lpcbData);

		public static int RegSetValueExLong(int hKey, ref string lpValueName, int Reserved, int dwType, ref int lpValue, int cbData) => JetNetSupport.PInvoke.UnsafeNative.advapi32.RegSetValueExLong(hKey, ref lpValueName, Reserved, dwType, ref lpValue, cbData);

		public static int RegSetValueExString(int hKey, ref string lpValueName, int Reserved, int dwType, ref string lpValue, int cbData) => JetNetSupport.PInvoke.UnsafeNative.advapi32.RegSetValueExString(hKey, ref lpValueName, Reserved, dwType, ref lpValue, cbData);

	}
}