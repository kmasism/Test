using System;
using System.Drawing;
using System.Windows.Forms;
using UpgradeHelpers.Gui.Controls;

namespace JETNET_Homebase
{
	internal static class modGridEditCommon
	{


		internal static void InPlace_Grid_Edit(UpgradeHelpers.DataGridViewFlex grdCurrent, Control ctlEdit, bool isPhoneGrid, bool bSetFocus = false, object nAcceptSize = null, int nXOffset = 0, int nYOffset = 0, int nControlWidth = 0)
		{

			float sglTop = 0;
			float sglLeft = 0;
			int stLoop = 0;
			int visible_row = 0;

			//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			// Move method of the text/combo box control to place the control on the grid at the
			// location of the cell.  Make the text/combo box visible and set its
			// ZOrder to 0 to put it on top of the grid.  Move the text from
			// the grid into the text/combo Box.
			//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

			if (((int) grdCurrent.CellBorderStyle) > 0)
			{
				sglLeft = grdCurrent.CellLeft + 15 + 2;
				sglTop = grdCurrent.CellTop + 15 + 2;
			}
			else
			{
				sglLeft = grdCurrent.CellLeft + 15;
				sglTop = grdCurrent.CellTop + 15;
			}


			//UPGRADE_WARNING: (2080) IsEmpty was upgraded to a comparison and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
			//UPGRADE_WARNING: (2065) Boolean method Information.IsMissing has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
			if (nXOffset != 0 && !nXOffset.Equals(0))
			{
				sglLeft += nXOffset;
			}

			//UPGRADE_WARNING: (2080) IsEmpty was upgraded to a comparison and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
			//UPGRADE_WARNING: (2065) Boolean method Information.IsMissing has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
			if (nYOffset != 0 && !nYOffset.Equals(0))
			{
				sglTop += nYOffset;
			}

			//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			// Move the Text/combo Box on top of the Grid.
			//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			ctlEdit.SetBounds(Convert.ToInt32(sglLeft) / 15, Convert.ToInt32(sglTop) / 15, 0, 0, BoundsSpecified.X | BoundsSpecified.Y); //left,top
			ControlHelper.SetVisible(ctlEdit, true);
			ctlEdit.BringToFront();
			ctlEdit.BackColor = Color.FromArgb(255, 255, 0);
			ctlEdit.ForeColor = Color.FromArgb(0, 0, 0);

			TextBox ctlEditTyped = null;
			ComboBox ctlEditTyped2 = null;
			CheckBox ctlEditTyped3 = null;
			if (ctlEdit is TextBox)
			{
				ctlEditTyped = (TextBox) ctlEdit;

				if (isPhoneGrid)
				{
					//set the maxlength depending on which row is selected.
					//country, area code, and prefix should be maxlength = 6
					//number should be maxlength = 10
					if (grdCurrent.CurrentColumnIndex == 1 || grdCurrent.CurrentColumnIndex == 2 || grdCurrent.CurrentColumnIndex == 3)
					{
						ctlEditTyped.MaxLength = 6;
					}
					else if (grdCurrent.CurrentColumnIndex == 4)
					{ 
						ctlEditTyped.MaxLength = 10;
					}

				}
				else
				{

					//UPGRADE_WARNING: (2080) IsEmpty was upgraded to a comparison and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
					//UPGRADE_WARNING: (2065) Boolean method Information.IsMissing has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
					if (nAcceptSize != null && !Object.Equals(nAcceptSize, null))
					{
						//UPGRADE_WARNING: (1068) nAcceptSize of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						ctlEditTyped.MaxLength = Convert.ToInt32(nAcceptSize);
					}
					else
					{
						ctlEditTyped.MaxLength = 20;
					}

				}

				ctlEditTyped.Height = grdCurrent.Rows[grdCurrent.CurrentRowIndex].Height;
				ctlEditTyped.Text = grdCurrent[grdCurrent.CurrentRowIndex, grdCurrent.CurrentColumnIndex].FormattedValue.ToString();

			}
			else if (ctlEdit is ComboBox)
			{ 
				ctlEditTyped2 = (ComboBox) ctlEdit;

				int tempForEndVar = ctlEditTyped2.Items.Count - 1;
				for (int iLoop = 0; iLoop <= tempForEndVar; iLoop++)
				{
					if (ctlEditTyped2.GetListItem(iLoop).ToLower() == grdCurrent[grdCurrent.CurrentRowIndex, grdCurrent.CurrentColumnIndex].FormattedValue.ToString().ToLower())
					{
						ctlEditTyped2.SelectedIndex = iLoop;
						break;
					}
				}

				// set the purchase question to default to unknown if the listindex is zero
				if (ctlEditTyped2.Name == "cbo_comp_purchase_question" || ctlEditTyped2.Name == "cbo_ac_purchase_question")
				{
					if (ctlEditTyped2.SelectedIndex == 0)
					{
						ctlEditTyped2.SelectedIndex = 10;
					}
				}

			}
			else if (ctlEdit is CheckBox)
			{ 
				ctlEditTyped3 = (CheckBox) ctlEdit;

				if (grdCurrent[grdCurrent.CurrentRowIndex, grdCurrent.CurrentColumnIndex].FormattedValue.ToString().ToUpper() == "N" || grdCurrent[grdCurrent.CurrentRowIndex, grdCurrent.CurrentColumnIndex].FormattedValue.ToString().ToUpper() == "NO")
				{
					ctlEditTyped3.CheckState = CheckState.Unchecked;
				}
				else
				{
					ctlEditTyped3.CheckState = CheckState.Checked;
				}

			}

			//UPGRADE_WARNING: (2080) IsEmpty was upgraded to a comparison and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
			//UPGRADE_WARNING: (2065) Boolean method Information.IsMissing has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
			if (nControlWidth != 0 && !nControlWidth.Equals(0))
			{
				ctlEdit.Width = nControlWidth / 15;
			}
			else
			{
				ctlEdit.Width = (grdCurrent.Columns[grdCurrent.CurrentColumnIndex].Width - 2) / 15;
			}

			//UPGRADE_WARNING: (2080) IsEmpty was upgraded to a comparison and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
			//UPGRADE_WARNING: (2065) Boolean method Information.IsMissing has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
			if (bSetFocus && !bSetFocus.Equals(false))
			{

				if (bSetFocus)
				{
					ctlEdit.Focus();
				}

			}

		}

		internal static void InPlace_Grid_Reset(UpgradeHelpers.DataGridViewFlex grdCurrent, Control ctlEdit, int intRow, int intCol)
		{


			//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			// After the user clicks on another cell after editing in the text/combo/check box,
			// the grid has already been updated to the new row and column.  Position
			// back to the last row and column where the user was editing, take the
			// contents of the text/combo/check box, and put that value into the grid's cell.
			// Make the text/combo/box box invisible, and move it to an area on the form
			// that is out of the way.
			//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			int intOldRow = grdCurrent.CurrentRowIndex;
			int intOldCol = grdCurrent.CurrentColumnIndex;

			grdCurrent.CurrentRowIndex = intRow;
			grdCurrent.CurrentColumnIndex = intCol;

			TextBox ctlEditTyped = null;
			ComboBox ctlEditTyped2 = null;
			CheckBox ctlEditTyped3 = null;
			if (ctlEdit is TextBox)
			{
				ctlEditTyped = (TextBox) ctlEdit;
				grdCurrent[grdCurrent.CurrentRowIndex, grdCurrent.CurrentColumnIndex].Value = ctlEditTyped.Text;
			}
			else if (ctlEdit is ComboBox)
			{ 
				ctlEditTyped2 = (ComboBox) ctlEdit;
				grdCurrent[grdCurrent.CurrentRowIndex, grdCurrent.CurrentColumnIndex].Value = ctlEditTyped2.Text;
			}
			else if (ctlEdit is CheckBox)
			{ 
				ctlEditTyped3 = (CheckBox) ctlEdit;
				if (ctlEditTyped3.CheckState == CheckState.Checked)
				{
					grdCurrent[grdCurrent.CurrentRowIndex, grdCurrent.CurrentColumnIndex].Value = "Yes";
				}
				else
				{
					grdCurrent[grdCurrent.CurrentRowIndex, grdCurrent.CurrentColumnIndex].Value = "No";
				}
			}

			ControlHelper.SetVisible(ctlEdit, false);
			ctlEdit.SetBounds(0, 0, 0, 0, BoundsSpecified.X | BoundsSpecified.Y);

			grdCurrent.CurrentRowIndex = intOldRow;
			grdCurrent.CurrentColumnIndex = intOldCol;

			intRow = 0;
			intCol = 0;

		}
	}
}