using System.Runtime.InteropServices;
using System;
using System.Diagnostics;

namespace JetNetSupport.PInvoke.SafeNative
{
	public static class shell32
	{

		public static int SHBrowseForFolder(ref JetNetSupport.PInvoke.UnsafeNative.Structures.BrowseInfo lpbi) => JetNetSupport.PInvoke.UnsafeNative.shell32.SHBrowseForFolder(ref lpbi);

		public static int ShellExecute(int hwnd, string lpOperation, string lpFile, string lpParameters, string lpDirectory, int nShowCmd)
		{
			//UPGRADE_WARNING: (2081) ShellExecuteA has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
			ProcessStartInfo startInfo = new ProcessStartInfo();
			startInfo.UseShellExecute = true;
			startInfo.CreateNoWindow = false;
			startInfo.Verb = lpOperation;
			startInfo.FileName = lpFile;
			startInfo.Arguments = lpParameters;
			startInfo.WorkingDirectory = lpDirectory;
			startInfo.WindowStyle = ProcessWindowStyle.Normal;
			Process shellExecuteProcess = Process.Start(startInfo);
			return shellExecuteProcess.ExitCode;
		}
		public static int SHGetPathFromIDList(int pidList, ref string lpBuffer) => JetNetSupport.PInvoke.UnsafeNative.shell32.SHGetPathFromIDList(pidList, ref lpBuffer);

		public static int SHGetSpecialFolderLocation(int hwndOwner, int nFolder, ref JetNetSupport.PInvoke.UnsafeNative.Structures.ITEMIDLIST pidl) => JetNetSupport.PInvoke.UnsafeNative.shell32.SHGetSpecialFolderLocation(hwndOwner, nFolder, ref pidl);

	}
}