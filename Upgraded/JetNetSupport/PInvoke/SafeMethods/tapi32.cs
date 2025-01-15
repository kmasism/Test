using System.Runtime.InteropServices;
using System;
using System.Diagnostics;

namespace JetNetSupport.PInvoke.SafeNative
{
	public static class tapi32
	{

		public static int tapiRequestMakeCall(ref string DestAddress, ref string AppName, ref string CalledParty, ref string Comment) => JetNetSupport.PInvoke.UnsafeNative.tapi32.tapiRequestMakeCall(ref DestAddress, ref AppName, ref CalledParty, ref Comment);

	}
}