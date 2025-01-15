using Microsoft.VisualBasic;
using System;
using System.Runtime.InteropServices;

namespace JETNET_Homebase
{
	internal static class modRegistry
	{


		public const int REG_NONE = 0; // No value type
		public const int REG_SZ = 1; // Unicode nul terminated string
		public const int REG_EXPAND_SZ = 2; // Unicode nul terminated string
		public const int REG_BINARY = 3; // Free form binary
		public const int REG_DWORD = 4; // 32-bit number
		public const int REG_DWORD_LITTLE_ENDIAN = 4; // 32-bit number (same as REG_DWORD)
		public const int REG_DWORD_BIG_ENDIAN = 5; // 32-bit number
		public const int REG_LINK = 6; // Symbolic Link (unicode)
		public const int REG_MULTI_SZ = 7; // Multiple Unicode strings
		public const int REG_RESOURCE_LIST = 8; // Resource list in the resource map
		public const int REG_FULL_RESOURCE_DESCRIPTOR = 9; // Resource list in the hardware description

		public const int HKEY_CLASSES_ROOT = unchecked((int) 0x80000000);
		public const int HKEY_CURRENT_USER = unchecked((int) 0x80000001);
		public const int HKEY_LOCAL_MACHINE = unchecked((int) 0x80000002);
		public const int HKEY_USERS = unchecked((int) 0x80000003);

		public const int ERROR_NONE = 0;
		public const int ERROR_BADDB = 1;
		public const int ERROR_BADKEY = 2;
		public const int ERROR_CANTOPEN = 3;
		public const int ERROR_CANTREAD = 4;
		public const int ERROR_CANTWRITE = 5;
		public const int ERROR_OUTOFMEMORY = 6;
		public const int ERROR_INVALID_PARAMETER = 7;
		public const int ERROR_ACCESS_DENIED = 8;
		public const int ERROR_INVALID_PARAMETERS = 87;
		public const int ERROR_NO_MORE_ITEMS = 259;

		public const int KEY_ALL_ACCESS = 0x3F;

		public const int SYNCHRONIZE = 0x100000;
		public const int STANDARD_RIGHTS_ALL = 0x1F0000;

		// Reg Key Security Options
		public const int KEY_QUERY_VALUE = 0x1;
		public const int KEY_SET_VALUE = 0x2;
		public const int KEY_CREATE_SUB_KEY = 0x4;
		public const int KEY_ENUMERATE_SUB_KEYS = 0x8;
		public const int KEY_NOTIFY = 0x10;
		public const int KEY_CREATE_LINK = 0x20;

		//Global Const KEY_ALL_ACCESS = ((STANDARD_RIGHTS_ALL Or KEY_QUERY_VALUE Or KEY_SET_VALUE Or KEY_CREATE_SUB_KEY Or KEY_ENUMERATE_SUB_KEYS Or KEY_NOTIFY Or KEY_CREATE_LINK) And (Not SYNCHRONIZE))
		public const int REG_OPTION_NON_VOLATILE = 0;

		private static int glHKEY_Hive = 0;

		//UPGRADE_NOTE: (2041) The following line was commented. More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-2041
		//[DllImport("advapi32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		//extern public static int RegCloseKey(int hKey);
		//UPGRADE_NOTE: (2041) The following line was commented. More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-2041
		//[DllImport("advapi32.dll", EntryPoint = "RegCreateKeyExA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		//extern public static int RegCreateKeyEx(int hKey, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpSubKey, int Reserved, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpClass, int dwOptions, int samDesired, int lpSecurityAttributes, ref int phkResult, ref int lpdwDisposition);
		//UPGRADE_NOTE: (2041) The following line was commented. More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-2041
		//[DllImport("advapi32.dll", EntryPoint = "RegEnumValueA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		//extern public static int RegEnumValue(int hKey, int dwIndex, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpValueName, ref int lpcbValueName, int lpReserved, ref int lpType, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpData, ref int lpcbData);
		//UPGRADE_NOTE: (2041) The following line was commented. More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-2041
		//[DllImport("advapi32.dll", EntryPoint = "RegOpenKeyExA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		//extern public static int RegOpenKeyEx(int hKey, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpSubKey, int ulOptions, int samDesired, ref int phkResult);

		//UPGRADE_NOTE: (2041) The following line was commented. More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-2041
		//[DllImport("advapi32.dll", EntryPoint = "RegQueryValueExA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		//extern public static int RegQueryValueExString(int hKey, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpValueName, int lpReserved, ref int lpType, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpData, ref int lpcbData);
		//UPGRADE_NOTE: (2041) The following line was commented. More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-2041
		//[DllImport("advapi32.dll", EntryPoint = "RegQueryValueExA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		//extern public static int RegQueryValueExLong(int hKey, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpValueName, int lpReserved, ref int lpType, ref int lpData, ref int lpcbData);
		//UPGRADE_NOTE: (2041) The following line was commented. More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-2041
		//[DllImport("advapi32.dll", EntryPoint = "RegQueryValueExA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		//extern public static int RegQueryValueExNULL(int hKey, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpValueName, int lpReserved, ref int lpType, int lpData, ref int lpcbData);
		//UPGRADE_NOTE: (2041) The following line was commented. More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-2041
		//[DllImport("advapi32.dll", EntryPoint = "RegSetValueExA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		//extern public static int RegSetValueExString(int hKey, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpValueName, int Reserved, int dwType, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpValue, int cbData);
		//UPGRADE_NOTE: (2041) The following line was commented. More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-2041
		//[DllImport("advapi32.dll", EntryPoint = "RegSetValueExA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		//extern public static int RegSetValueExLong(int hKey, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpValueName, int Reserved, int dwType, ref int lpValue, int cbData);

		internal static void SetHive(int lHKEY_Hive)
		{

			// Must be one of these 4 Hives
			if ((lHKEY_Hive == HKEY_CLASSES_ROOT) || (lHKEY_Hive == HKEY_CURRENT_USER) || (lHKEY_Hive == HKEY_LOCAL_MACHINE) || (lHKEY_Hive == HKEY_USERS))
			{
				glHKEY_Hive = lHKEY_Hive;
			}
			else
			{
				glHKEY_Hive = HKEY_LOCAL_MACHINE; // Default
			}

		} // SetHive


		private static int GetHive()
		{

			if (glHKEY_Hive == 0)
			{
				glHKEY_Hive = HKEY_LOCAL_MACHINE; // Default
			}

			return glHKEY_Hive;

		} // GetHive


		internal static string ReadRegistryKeyString(string strRegKey, string strRegKeyField)
		{

			int Zero = 0;
			int hKey = 0;
			string OrigKeyNam = "";
			object vRegKeyValue = null;

			string strResults = new string(Strings.Chr(0), 255);

			int IRetVal = JetNetSupport.PInvoke.SafeNative.advapi32.RegOpenKeyEx(GetHive(), ref strRegKey, Zero, KEY_ALL_ACCESS, ref hKey);
			int tempRefParam = REG_SZ;
			int tempRefParam2 = 255;
			IRetVal = JetNetSupport.PInvoke.SafeNative.advapi32.RegQueryValueExString(hKey, ref strRegKeyField, 0, ref tempRefParam, ref strResults, ref tempRefParam2);
			JetNetSupport.PInvoke.SafeNative.advapi32.RegCloseKey(hKey);

			strResults = strResults;
			int iPos1 = (strResults.IndexOf(Strings.Chr(0).ToString()) + 1);
			strResults = strResults.Substring(0, Math.Min(iPos1 - 1, strResults.Length));

			return strResults;

		} // ReadRegistryKeyString


		internal static void WriteRegistryKeyString(string strRegKey, string strRegKeyField, string strRegKeyValue)
		{

			int Zero = 0;
			int hKey = 0;
			string OrigKeyNam = "";

			strRegKeyValue = $"{strRegKeyValue}{Strings.Chr(0).ToString()}";

			int IRetVal = JetNetSupport.PInvoke.SafeNative.advapi32.RegOpenKeyEx(GetHive(), ref strRegKey, Zero, KEY_ALL_ACCESS, ref hKey);
			IRetVal = JetNetSupport.PInvoke.SafeNative.advapi32.RegSetValueExString(hKey, ref strRegKeyField, 0, REG_SZ, ref strRegKeyValue, Strings.Len(strRegKeyValue));
			JetNetSupport.PInvoke.SafeNative.advapi32.RegCloseKey(hKey);

		} // WriteRegistryKeyString


		internal static int ReadRegistryKeyDWORD(string strRegKey, string strRegKeyField)
		{

			int lResults = 0;
			int Zero = 0;
			int hKey = 0;
			string OrigKeyNam = "";
			object vRegKeyValue = null;

			int IRetVal = JetNetSupport.PInvoke.SafeNative.advapi32.RegOpenKeyEx(GetHive(), ref strRegKey, Zero, KEY_ALL_ACCESS, ref hKey);
			int tempRefParam = REG_DWORD;
			int tempRefParam2 = 4;
			IRetVal = JetNetSupport.PInvoke.SafeNative.advapi32.RegQueryValueExLong(hKey, ref strRegKeyField, 0, ref tempRefParam, ref lResults, ref tempRefParam2);
			JetNetSupport.PInvoke.SafeNative.advapi32.RegCloseKey(hKey);

			return lResults;

		} // ReadRegistryKeyDWORD


		internal static void WriteRegistryKeyDWORD(string strRegKey, string strRegKeyField, int lRegKeyValue)
		{

			int Zero = 0;
			int hKey = 0;
			string OrigKeyNam = "";

			//open the specified key
			int IRetVal = JetNetSupport.PInvoke.SafeNative.advapi32.RegOpenKeyEx(GetHive(), ref strRegKey, Zero, KEY_ALL_ACCESS, ref hKey);
			IRetVal = JetNetSupport.PInvoke.SafeNative.advapi32.RegSetValueExLong(hKey, ref strRegKeyField, 0, REG_DWORD, ref lRegKeyValue, 4);
			JetNetSupport.PInvoke.SafeNative.advapi32.RegCloseKey(hKey);

		} // WriteRegistryKeyDWORD

		internal static void CreateNewRegistryKey(string strRegKey)
		{

			int hKey = 0;
			int lRetDisp = 0;

			string tempRefParam = null;
			int lRetVal = JetNetSupport.PInvoke.SafeNative.advapi32.RegCreateKeyEx(GetHive(), ref strRegKey, 0, ref tempRefParam, REG_OPTION_NON_VOLATILE, KEY_ALL_ACCESS, 0, ref hKey, ref lRetDisp);
			JetNetSupport.PInvoke.SafeNative.advapi32.RegCloseKey(hKey);

		} // CreateNewRegistryKey


		internal static int ReadSingleRegistryDWORDKey(string strRegKeyField)
		{


			string strRegKey = "SOFTWARE\\JETNET LLC\\Homebase";
			int lResults = ReadRegistryKeyDWORD(strRegKey, strRegKeyField);

			return lResults;

		} // ReadSingleRegistryDWORDKey


		internal static void ReadYachtTransRegistryStatusKey(ref string strStatus, ref int lStatus, ref string strState)
		{


			string strRegKey = "SOFTWARE\\JETNET LLC\\Homebase";
			CreateNewRegistryKey(strRegKey);

			string strRegKeyField = "YachtTransStatus";
			strStatus = ReadRegistryKeyString(strRegKey, strRegKeyField);

			strRegKeyField = "YachtTransStatusValue";
			lStatus = ReadRegistryKeyDWORD(strRegKey, strRegKeyField);

			strRegKeyField = "YachtTransState";
			strState = ReadRegistryKeyString(strRegKey, strRegKeyField);

		} // ReadYachtTransRegistryStatusKey
	}
}