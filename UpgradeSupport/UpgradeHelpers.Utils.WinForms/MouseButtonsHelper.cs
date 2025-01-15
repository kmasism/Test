using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpgradeHelpers.Utils.WinForms
{
	/// <summary>
	/// The MouseButtonsHelper class provides compatibility between VBRUN.MouseButtonConstants and System.Windows.Forms.MouseButtons enums. 
	/// </summary>
	public static class MouseButtonsHelper
	{
		/// <summary>
		/// Returns the VB6 short value corresponding to the .Net MouseButtons value. The VB6 enum had only 3 values, in any other case of the .Net enum it return -1. 
		/// </summary>
		/// <param name="value"></param>
		/// <returns>The short value VB6 used to have for the corresponding .Net MouseButtons value, -1 in any other case</returns>
		public static short GetVB6ShortValue(System.Windows.Forms.MouseButtons value)
		{
			switch (value)
			{
				case System.Windows.Forms.MouseButtons.Left:
					return 1;
				case System.Windows.Forms.MouseButtons.Right:
					return 2;
				case System.Windows.Forms.MouseButtons.Middle:
					return 4;
			}

			// any other MouseButtons value does has no correspondance in VBRUN.MouseButtonConstants enum
			return -1;
		}

		/// <summary>
		/// Returns the .NET MouseButton value corresponding to the VB6 short value. The MouseButton has 7 values, it return  default(System.Windows.Forms.MouseButtons) by default. 
		/// </summary>
		/// <param name="value"></param>
		/// <returns>The .Net MouseButtons value corresponding to VB6 short value, default(System.Windows.Forms.MouseButtons) in any other case</returns>
		public static System.Windows.Forms.MouseButtons GetVB6MouseButton(int value)
		{
			switch (value)
			{
				case 1:
					return System.Windows.Forms.MouseButtons.Left;
				case 2:
					return System.Windows.Forms.MouseButtons.Right;
				case 4:
					return System.Windows.Forms.MouseButtons.Middle;
			}

			// any other vb6 short value does has no correspondance in switch
			return default(System.Windows.Forms.MouseButtons);
		}
	}
}
