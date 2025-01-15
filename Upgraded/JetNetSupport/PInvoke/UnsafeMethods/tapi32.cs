using System.Runtime.InteropServices;
using System;
using System.Diagnostics;

namespace JetNetSupport.PInvoke.UnsafeNative
{
	[System.Security.SuppressUnmanagedCodeSecurity]
	public static class tapi32
	{

		[DllImport("TAPI32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		extern public static int tapiRequestMakeCall([MarshalAs(UnmanagedType.VBByRefStr)] ref string DestAddress, [MarshalAs(UnmanagedType.VBByRefStr)] ref string AppName, [MarshalAs(UnmanagedType.VBByRefStr)] ref string CalledParty, [MarshalAs(UnmanagedType.VBByRefStr)] ref string Comment);
	}
}