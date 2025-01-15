using Microsoft.VisualBasic;
using System;
using System.Drawing;
using System.Windows.Forms;
using UpgradeHelpers.Helpers;

namespace JETNET_Homebase
{
	internal static class modStatusBar
	{




		private static int intNum_Status_Bars = 0;
		private static Control[] ctlStatus_Bar = null;

		internal static void Clear_Status_Bar(int SB_ID)
		{
			try
			{

				if (SB_ID <= 0)
				{
					MessageBox.Show($"Clear_Status_Bar_Error: You must first assign a Status Bar ID using the 'Identify_Status_Bar' function.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}
				else if ((SB_ID > intNum_Status_Bars))
				{ 
					MessageBox.Show($"Clear_Status_Bar_Error: The Status Bar ID is not legal.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}
				else
				{
					ctlStatus_Bar[SB_ID].ForeColor = Color.Blue;
					ctlStatus_Bar[SB_ID].Text = "";
				}

				ctlStatus_Bar[SB_ID].Refresh();
			}
			catch
			{

				modAdminCommon.Report_Error("Clear_Status_Bar_Error");
			}

		}


		internal static int Identify_Status_Bar(Panel SBPanel)
		{
			int result = 0;
			try
			{

				intNum_Status_Bars++;
				ctlStatus_Bar = ArraysHelper.RedimPreserve(ctlStatus_Bar, new int[]{intNum_Status_Bars + 1});

				ctlStatus_Bar[intNum_Status_Bars] = SBPanel;

				return intNum_Status_Bars;
			}
			catch
			{

				modAdminCommon.Report_Error("Identify_Status_Bar_Error");
				intNum_Status_Bars--;
				result = -1;
			}
			return result;
		}


		internal static void Update_Status_Bar(int SB_ID, string Msg, Color color)
		{
			try
			{

				if (SB_ID <= 0)
				{
					MessageBox.Show($"Update_Status_Bar_Error: You must first assign a Status Bar ID using the 'Identify_Status_Bar' function.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}
				else if ((SB_ID > intNum_Status_Bars))
				{ 
					MessageBox.Show($"Update_Status_Bar_Error: The Status Bar ID is not legal.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}
				else
				{
					ctlStatus_Bar[SB_ID].ForeColor = color;
					ctlStatus_Bar[SB_ID].Text = Msg;
				}

				ctlStatus_Bar[SB_ID].Refresh();
				Application.DoEvents();
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Update_Status_Bar_Error ", excep.Message);
				modAdminCommon.Display_Error("Update_Status_Bar_Error ");
			}

		}

		internal static string Return_Status_Bar_Caption(int SB_ID)
		{


			string strResults = "";

			if (SB_ID >= 0)
			{
				strResults = ctlStatus_Bar[SB_ID].Text;
			}

			return strResults;

		} // Return_Status_Bar_Caption
	}
}