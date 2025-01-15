using System.Runtime.InteropServices;
using System;
using System.Diagnostics;

namespace JetNetSupport.PInvoke.SafeNative
{
	public static class ole32
	{

		public static int CoCreateGuid(ref JetNetSupport.PInvoke.UnsafeNative.Structures.GUID pGuid) => JetNetSupport.PInvoke.UnsafeNative.ole32.CoCreateGuid(ref pGuid);

	}
}