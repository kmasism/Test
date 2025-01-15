using System.Runtime.InteropServices;
using System;
using System.Diagnostics;

namespace JetNetSupport.PInvoke.UnsafeNative
{
	[System.Security.SuppressUnmanagedCodeSecurity]
	public static class shell32
	{

		//UPGRADE_TODO: (1050) Structure BrowseInfo may require marshalling attributes to be passed as an argument in this Declare statement. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1050
		[DllImport("shell32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		extern public static int SHBrowseForFolder(ref JetNetSupport.PInvoke.UnsafeNative.Structures.BrowseInfo lpbi);
		[DllImport("shell32.dll", EntryPoint = "ShellAboutA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		extern public static int ShellAbout(int hWnd, [MarshalAs(UnmanagedType.VBByRefStr)] ref string szApp, [MarshalAs(UnmanagedType.VBByRefStr)] ref string szOtherStuff, int hIcon);
		[DllImport("shell32.dll", EntryPoint = "ShellExecuteA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		extern public static int ShellExecute(int hwnd, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpOperation, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpFile, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpParameters, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpDirectory, int nShowCmd);
		[DllImport("shell32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		extern public static int SHGetPathFromIDList(int pidList, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpBuffer);
		//UPGRADE_TODO: (1050) Structure ITEMIDLIST may require marshalling attributes to be passed as an argument in this Declare statement. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1050
		[DllImport("shell32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		extern public static int SHGetSpecialFolderLocation(int hwndOwner, int nFolder, ref JetNetSupport.PInvoke.UnsafeNative.Structures.ITEMIDLIST pidl);
	}
}