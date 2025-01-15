using System.Runtime.InteropServices;
using System;
using System.Diagnostics;

namespace JetNetSupport.PInvoke.SafeNative
{
	public static class comdlg32
	{

		public static int GetOpenFileName(ref JetNetSupport.PInvoke.UnsafeNative.Structures.OPENFILENAME pOpenfilename) => JetNetSupport.PInvoke.UnsafeNative.comdlg32.GetOpenFileName(ref pOpenfilename);

	}
}