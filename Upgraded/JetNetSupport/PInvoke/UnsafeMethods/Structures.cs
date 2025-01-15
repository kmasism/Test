using System.Runtime.InteropServices;
using System;
using System.Diagnostics;

namespace JetNetSupport.PInvoke.UnsafeNative
{
	[System.Security.SuppressUnmanagedCodeSecurity]
	public static class Structures
	{

		[Serializable][StructLayout(LayoutKind.Sequential)]
		public struct POINTAPI
		{
			public int xPos;
			public int yPos;
		}
		[Serializable][StructLayout(LayoutKind.Sequential)]
		public struct SHITEMID
		{
			public int cb;
			public byte abID;
		}
		[Serializable][StructLayout(LayoutKind.Sequential)]
		public struct OPENFILENAME
		{
			public int lStructSize;
			public int hwndOwner;
			public int hInstance;
			public string lpstrFilter;
			public string lpstrCustomFilter;
			public int nMaxCustFilter;
			public int nFilterIndex;
			public string lpstrFile;
			public int nMaxFile;
			public string lpstrFileTitle;
			public int nMaxFileTitle;
			public string lpstrInitialDir;
			public string lpstrTitle;
			public int flags;
			public short nFileOffset;
			public short nFileExtension;
			public string lpstrDefExt;
			public int lCustData;
			public int lpfnHook;
			public string lpTemplateName;
			private static void InitStruct(ref OPENFILENAME result, bool init)
			{
				if (init)
				{
					result.lpstrFilter = String.Empty;
					result.lpstrCustomFilter = String.Empty;
					result.lpstrFile = String.Empty;
					result.lpstrFileTitle = String.Empty;
					result.lpstrInitialDir = String.Empty;
					result.lpstrTitle = String.Empty;
					result.lpstrDefExt = String.Empty;
					result.lpTemplateName = String.Empty;
				}
			}
			public static OPENFILENAME CreateInstance()
			{
				OPENFILENAME result = new OPENFILENAME();
				InitStruct(ref result, true);
				return result;
			}
			public OPENFILENAME Clone()
			{
				OPENFILENAME result = this;
				InitStruct(ref result, false);
				return result;
			}
		}
		[Serializable][StructLayout(LayoutKind.Sequential)]
		public struct BrowseInfo
		{
			public int hwndOwner;
			public int pIDLRoot;
			public int pszDisplayName;
			public int lpszTitle;
			public int ulFlags;
			public int lpfnCallback;
			public int lparam;
			public int iImage;
		}
		[Serializable][StructLayout(LayoutKind.Sequential)]
		public struct GUID
		{
			public int Data1;
			public short Data2;
			public short Data3;
			[System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst=7)]
			public byte[] Data4;
			private static void InitStruct(ref GUID result, bool init) => result.Data4 = new byte[8];

			public static GUID CreateInstance()
			{
				GUID result = new GUID();
				InitStruct(ref result, true);
				return result;
			}
			public GUID Clone()
			{
				GUID result = this;
				InitStruct(ref result, false);
				Array.Copy(this.Data4, result.Data4, 8);
				return result;
			}
		}
		[Serializable][StructLayout(LayoutKind.Sequential)]
		public struct ITEMIDLIST
		{
			public JetNetSupport.PInvoke.UnsafeNative.Structures.SHITEMID mkid;
			private static void InitStruct(ref ITEMIDLIST result, bool init)
			{
			}
			public static ITEMIDLIST CreateInstance()
			{
				ITEMIDLIST result = new ITEMIDLIST();
				InitStruct(ref result, true);
				return result;
			}
			public ITEMIDLIST Clone()
			{
				ITEMIDLIST result = this;
				InitStruct(ref result, false);
				return result;
			}
		}
	}
}