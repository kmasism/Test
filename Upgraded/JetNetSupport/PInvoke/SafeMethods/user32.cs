using System.Runtime.InteropServices;
using System;
using System.Diagnostics;

namespace JetNetSupport.PInvoke.SafeNative
{
	public static class user32
	{

		public static int GetCursorPos(ref JetNetSupport.PInvoke.UnsafeNative.Structures.POINTAPI lpPoint) => JetNetSupport.PInvoke.UnsafeNative.user32.GetCursorPos(ref lpPoint);

		public static int SendMessage(int hWnd, int wMsg, int wParam, int lparam)
		{
			int result = 0;
			GCHandle handle = GCHandle.Alloc(lparam, GCHandleType.Pinned);
			try
			{
				IntPtr tmpPtr = handle.AddrOfPinnedObject();
				result = JetNetSupport.PInvoke.UnsafeNative.user32.SendMessage(hWnd, wMsg, wParam, tmpPtr);
				lparam = Marshal.ReadInt16(tmpPtr);
			}
			finally
			{
				handle.Free();
			}
			return result;
		}
		public static int SystemParametersInfo<T>(int uAction, int uParam, ref T lpvParam, int fuWinIni) where T : struct
		{
			int result = 0;
			IntPtr tmpPtr = Marshal.AllocHGlobal(Marshal.SizeOf(lpvParam));
			Marshal.StructureToPtr(lpvParam, tmpPtr, true);
			result = JetNetSupport.PInvoke.UnsafeNative.user32.SystemParametersInfo(uAction, uParam, tmpPtr, fuWinIni);
			lpvParam = (T) Marshal.PtrToStructure(tmpPtr, lpvParam.GetType());
			return result;
		}
	}
}