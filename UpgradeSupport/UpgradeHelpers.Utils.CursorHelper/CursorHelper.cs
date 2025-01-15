using System;

namespace UpgradeHelpers.Helpers
{
    public static class CursorHelper
    {
		public static readonly System.Windows.Forms.Cursor CursorDefault = new System.Windows.Forms.Cursor(System.Windows.Forms.Cursors.Default.CopyHandle());
		public static readonly System.Windows.Forms.Cursor CursorIconPointer = new System.Windows.Forms.Cursor(System.Windows.Forms.Cursors.Arrow.CopyHandle());
		public static readonly System.Windows.Forms.Cursor CursorSizePointer = new System.Windows.Forms.Cursor(System.Windows.Forms.Cursors.SizeAll.CopyHandle());

		/// <summary>
		/// Converts the 'cursorIntValue' to System.Windows.Forms.Cursor
		/// </summary>
		/// <param name="cursorIntValue">The value to be converted.</param>
		/// <returns>A value converted to System.Windows.Forms.Cursor.</returns>
		public static System.Windows.Forms.Cursor GetValueForcedToCursor(int cursorIntValue)
		{
			switch (cursorIntValue)
			{
				case 0: return CursorDefault;
				case 1: return System.Windows.Forms.Cursors.Arrow;
				case 2: return System.Windows.Forms.Cursors.Cross;
				case 3: return System.Windows.Forms.Cursors.IBeam;
				case 4: return CursorIconPointer;
				case 5: return CursorSizePointer;
				case 6: return System.Windows.Forms.Cursors.SizeNESW;
				case 7: return System.Windows.Forms.Cursors.SizeNS;
				case 8: return System.Windows.Forms.Cursors.SizeNWSE;
				case 9: return System.Windows.Forms.Cursors.SizeWE;
				case 10: return System.Windows.Forms.Cursors.UpArrow;
				case 11: return System.Windows.Forms.Cursors.WaitCursor;
				case 12: return System.Windows.Forms.Cursors.No;
				case 13: return System.Windows.Forms.Cursors.AppStarting;
				case 14: return System.Windows.Forms.Cursors.Help;
				case 15: return System.Windows.Forms.Cursors.SizeAll;
				default: throw new ArgumentException("Value can not be converted to a Cursor");
			}
		}

		/// <summary>
		/// Gets the vb6 integer value for the given cursor
		/// </summary>
		/// <param name="cursor">The cursor</param>
		/// <returns>The vb6 integer value for the given cursor</returns>
		public static int GetCursorValueForcedToInteger(System.Windows.Forms.Cursor cursor)
		{
			if (cursor == CursorDefault)
				return 0;
			if (cursor == System.Windows.Forms.Cursors.Arrow)
				return 1;
			if (cursor == System.Windows.Forms.Cursors.Cross)
				return 2;
			if (cursor == System.Windows.Forms.Cursors.IBeam)
				return 3;
			if (cursor == CursorIconPointer)
				return 4;
			if (cursor == CursorSizePointer)
				return 5;
			if (cursor == System.Windows.Forms.Cursors.SizeNESW)
				return 6;
			if (cursor == System.Windows.Forms.Cursors.SizeNS)
				return 7;
			if (cursor == System.Windows.Forms.Cursors.SizeNWSE)
				return 8;
			if (cursor == System.Windows.Forms.Cursors.SizeWE)
				return 9;
			if (cursor == System.Windows.Forms.Cursors.UpArrow)
				return 10;
			if (cursor == System.Windows.Forms.Cursors.WaitCursor)
				return 11;
			if (cursor == System.Windows.Forms.Cursors.No)
				return 12;
			if (cursor == System.Windows.Forms.Cursors.AppStarting)
				return 13;
			if (cursor == System.Windows.Forms.Cursors.Help)
				return 14;
			if (cursor == System.Windows.Forms.Cursors.SizeAll)
				return 15;

			return 99;
		}
	}
}
