using Microsoft.VisualBasic;
using System;
using System.Data.Common;
using System.Drawing;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Helpers;

namespace JETNET_Homebase
{
	internal partial class frm_FAAFlightData
		: System.Windows.Forms.Form
	{

		public frm_FAAFlightData()
			: base()
		{
			if (m_vb6FormDefInstance is null)
			{
				if (m_InitializingDefInstance)
				{
					m_vb6FormDefInstance = this;
				}
				else
				{
					try
					{
						//For the start-up form, the first instance created is the default instance.
						if (!(System.Reflection.Assembly.GetExecutingAssembly().EntryPoint is null) && System.Reflection.Assembly.GetExecutingAssembly().EntryPoint.DeclaringType == this.GetType())
						{
							m_vb6FormDefInstance = this;
						}
					}
					catch
					{
					}
				}
			}
			//This call is required by the Windows Form Designer.
			InitializeComponent();
		}


		private void frm_FAAFlightData_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}

		private int glACId = 0;
		private System.DateTime gdDatePurchased = DateTime.FromOADate(0);
		private bool gbFormLoaded = false;
		private int glRow = 0;
		private int glTopRow = 0;
		public int gAPortId = 0;

		public int GetAPortId() => gAPortId;


		public void SetACId(int lACId)
		{

			string DP = "";
			glACId = 0;
			gdDatePurchased = DateTime.FromOADate(0);
			if (lACId > 0)
			{
				glACId = lACId;
				DP = modCommon.DLookUp("ac_purchase_date", "Aircraft", $"(ac_id = {glACId.ToString()} AND ac_journ_id = 0)");
				if (Information.IsDate(DP))
				{
					gdDatePurchased = DateTime.Parse(DP);
				}
			}

		} // SetACId

		public void Refresh_FAA_Flight_Data_Grid()
		{

			if (glACId > 0)
			{
				Load_FAA_Flight_Data_Grid();
			}

		}

		public void SetGridType(int iType)
		{

			rbAllFlights.Enabled = false;
			rbOriginFlights.Enabled = false;
			rbDestFlights.Enabled = false;

			switch(iType)
			{
				case 1 :  // All Flights 
					rbAllFlights.Checked = true; 
					break;
				case 2 :  // Summary Origin Flights 
					rbOriginFlights.Checked = true; 
					break;
				case 3 :  // Summary Dest Flights 
					rbDestFlights.Checked = true; 
					break;
				default:
					rbAllFlights.Checked = true; 
					break;
			} // Case iType

			rbAllFlights.Enabled = true;
			rbOriginFlights.Enabled = true;
			rbDestFlights.Enabled = true;

		} // SetGridType

		private void cmdSave_Click(Object eventSender, EventArgs eventArgs)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strFlightId = "";
			bool bUpdated = false;

			try
			{

				cmdSave.Enabled = false;
				bUpdated = false;

				strFlightId = txtFAAFlightId.Text;

				if (strFlightId != "" && strFlightId != "0")
				{

					strQuery1 = "SELECT * FROM FAA_Flight_Data ";
					strQuery1 = $"{strQuery1}WHERE (ffd_unique_flight_id = {strFlightId}) ";

					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						if (txtFlightTime.Text != "")
						{
							rstRec1["ffd_flight_time"] = Convert.ToInt32(Double.Parse(txtFlightTime.Text));
						}
						else
						{
							rstRec1["ffd_flight_time"] = 0;
						}

						if (txtDistance.Text != "")
						{
							rstRec1["ffd_distance"] = Convert.ToInt32(Double.Parse(txtDistance.Text));
						}
						else
						{
							rstRec1["ffd_distance"] = 0;
						}

						if (txtOriginAPortId.Text != Convert.ToString(txtOriginAPortId.Tag))
						{
							if (txtOriginAPortId.Text == "")
							{
								rstRec1["ffd_origin_aport_id"] = 0;
								rstRec1["ffd_distance"] = 0;
							}
							else
							{
								rstRec1["ffd_origin_aport_id"] = Convert.ToInt32(Double.Parse(txtOriginAPortId.Text));
							}
						}

						if (txtDestAPortId.Text != Convert.ToString(txtDestAPortId.Tag))
						{
							if (txtDestAPortId.Text == "")
							{
								rstRec1["ffd_dest_aport_id"] = 0;
								rstRec1["ffd_distance"] = 0;
							}
							else
							{
								rstRec1["ffd_dest_aport_id"] = Convert.ToInt32(Double.Parse(txtDestAPortId.Text));
							}
						}

						if (txtACId.Text != Convert.ToString(txtACId.Tag))
						{
							glRow = 0;
							glTopRow = 0;
							if (txtACId.Text == "")
							{
								rstRec1["ffd_ac_id"] = 0;
							}
							else
							{
								rstRec1["ffd_ac_id"] = Convert.ToInt32(Double.Parse(txtACId.Text));
							}
						}

						if (chkHideFlag.CheckState == CheckState.Unchecked)
						{
							rstRec1["ffd_hide_flag"] = "N";
						}
						else
						{
							rstRec1["ffd_hide_flag"] = "Y";
						}

						rstRec1["ffd_action_date"] = DateTime.Parse("1/1/1900");

						rstRec1.UpdateBatch();
						bUpdated = true;

					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

					if (bUpdated)
					{
						Clear_FAA_Data_Record_Form();
						Load_FAA_Flight_Data_Grid();
						if (glRow > 0)
						{
							grdFAAFlightData.FirstDisplayedScrollingRowIndex = glTopRow;
							grdFAAFlightData.CurrentRowIndex = glRow;
							modCommon.Highlight_Grid_Row(grdFAAFlightData);
						}
					}

				} // If strFlightId <> "" And strFlightId <> "0" Then

				cmdSave.Enabled = true;

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"cmdSave_Click_Error: {excep.Message}");
			}

		} // cmdSave_Click

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
		private void Form_Load()
		{

			rbAllFlights.Checked = true;
			gbFormLoaded = false;
			glRow = 0;
			glTopRow = 0;
			gAPortId = 0;

			Clear_FAA_Data_Record_Form();

		} // Form_Load

		private void frmFAAFlightDataGrid_Click(Object eventSender, EventArgs eventArgs)
		{

			if (grdFAAFlightData.RowsCount > 1)
			{
				lblStopExporting.Enabled = true;
				lblStopExporting.Visible = true;
				frmFAAFlightDataGrid.Enabled = false;
				if (rbAllFlights.Checked)
				{
					if (Convert.ToString(grdFAAFlightData[1, 5].Value) != "No Records Found")
					{
						modExcel.ExportMSHFlexGrid(grdFAAFlightData);
					}
				}
				if (rbOriginFlights.Checked || rbDestFlights.Checked)
				{
					if (Convert.ToString(grdFAAFlightDataSummary[1, 4].Value) != "No Records Found")
					{
						modExcel.ExportMSHFlexGrid(grdFAAFlightDataSummary);
					}
				}
				frmFAAFlightDataGrid.Enabled = true;
				lblStopExporting.Visible = false;
				lblStopExporting.Enabled = false;
			}

		} // frmFAAFlightDataGrid_Click

		private void Load_FAA_Flight_Data_Grid_Headers()
		{


			frmFAAFlightDataGrid.Enabled = false;
			grdFAAFlightData.Enabled = false;

			grdFAAFlightData.Clear();
			grdFAAFlightData.RowsCount = 2;
			grdFAAFlightData.ColumnsCount = 16;

			grdFAAFlightData.FixedColumns = 0;
			grdFAAFlightData.FixedRows = 0;

			grdFAAFlightData.CurrentRowIndex = 0;

			int lCol1 = 0;
			grdFAAFlightData.CurrentColumnIndex = lCol1;
			grdFAAFlightData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			grdFAAFlightData.SetColumnWidth(lCol1, 67);
			grdFAAFlightData[grdFAAFlightData.CurrentRowIndex, grdFAAFlightData.CurrentColumnIndex].Value = "FlightId";

			lCol1++;
			grdFAAFlightData.CurrentColumnIndex = lCol1;
			grdFAAFlightData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			grdFAAFlightData.SetColumnWidth(lCol1, 67);
			grdFAAFlightData[grdFAAFlightData.CurrentRowIndex, grdFAAFlightData.CurrentColumnIndex].Value = "RegNbr";

			lCol1++;
			grdFAAFlightData.CurrentColumnIndex = lCol1;
			grdFAAFlightData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			grdFAAFlightData.SetColumnWidth(lCol1, 67);
			grdFAAFlightData[grdFAAFlightData.CurrentRowIndex, grdFAAFlightData.CurrentColumnIndex].Value = "Flight Date";

			lCol1++;
			grdFAAFlightData.CurrentColumnIndex = lCol1;
			grdFAAFlightData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			grdFAAFlightData.SetColumnWidth(lCol1, 67);
			grdFAAFlightData[grdFAAFlightData.CurrentRowIndex, grdFAAFlightData.CurrentColumnIndex].Value = "Origin Airport";

			lCol1++;
			grdFAAFlightData.CurrentColumnIndex = lCol1;
			grdFAAFlightData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			grdFAAFlightData.SetColumnWidth(lCol1, 80);
			grdFAAFlightData[grdFAAFlightData.CurrentRowIndex, grdFAAFlightData.CurrentColumnIndex].Value = "Origin APortId";

			lCol1++;
			grdFAAFlightData.CurrentColumnIndex = lCol1;
			grdFAAFlightData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			grdFAAFlightData.SetColumnWidth(lCol1, 133);
			grdFAAFlightData[grdFAAFlightData.CurrentRowIndex, grdFAAFlightData.CurrentColumnIndex].Value = "Origin Date";
			grdFAAFlightData[1, lCol1].Value = "No Records Found";

			lCol1++;
			grdFAAFlightData.CurrentColumnIndex = lCol1;
			grdFAAFlightData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			grdFAAFlightData.SetColumnWidth(lCol1, 67);
			grdFAAFlightData[grdFAAFlightData.CurrentRowIndex, grdFAAFlightData.CurrentColumnIndex].Value = "Dest Airport";

			lCol1++;
			grdFAAFlightData.CurrentColumnIndex = lCol1;
			grdFAAFlightData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			grdFAAFlightData.SetColumnWidth(lCol1, 67);
			grdFAAFlightData[grdFAAFlightData.CurrentRowIndex, grdFAAFlightData.CurrentColumnIndex].Value = "Dest APortId";

			lCol1++;
			grdFAAFlightData.CurrentColumnIndex = lCol1;
			grdFAAFlightData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			grdFAAFlightData.SetColumnWidth(lCol1, 133);
			grdFAAFlightData[grdFAAFlightData.CurrentRowIndex, grdFAAFlightData.CurrentColumnIndex].Value = "Dest Date";

			lCol1++;
			grdFAAFlightData.CurrentColumnIndex = lCol1;
			grdFAAFlightData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			grdFAAFlightData.SetColumnWidth(lCol1, 67);
			grdFAAFlightData[grdFAAFlightData.CurrentRowIndex, grdFAAFlightData.CurrentColumnIndex].Value = "Flight Time";

			lCol1++;
			grdFAAFlightData.CurrentColumnIndex = lCol1;
			grdFAAFlightData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			grdFAAFlightData.SetColumnWidth(lCol1, 60);
			grdFAAFlightData[grdFAAFlightData.CurrentRowIndex, grdFAAFlightData.CurrentColumnIndex].Value = "Distance";

			lCol1++;
			grdFAAFlightData.CurrentColumnIndex = lCol1;
			grdFAAFlightData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			grdFAAFlightData.SetColumnWidth(lCol1, 133);
			grdFAAFlightData[grdFAAFlightData.CurrentRowIndex, grdFAAFlightData.CurrentColumnIndex].Value = "Entry Date";

			lCol1++;
			grdFAAFlightData.CurrentColumnIndex = lCol1;
			grdFAAFlightData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			grdFAAFlightData.SetColumnWidth(lCol1, 67);
			grdFAAFlightData[grdFAAFlightData.CurrentRowIndex, grdFAAFlightData.CurrentColumnIndex].Value = "ACId";

			lCol1++;
			grdFAAFlightData.CurrentColumnIndex = lCol1;
			grdFAAFlightData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			grdFAAFlightData.SetColumnWidth(lCol1, 60);
			grdFAAFlightData[grdFAAFlightData.CurrentRowIndex, grdFAAFlightData.CurrentColumnIndex].Value = "Hide Flag";

			lCol1++;
			grdFAAFlightData.CurrentColumnIndex = lCol1;
			grdFAAFlightData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			grdFAAFlightData.SetColumnWidth(lCol1, 67);
			grdFAAFlightData[grdFAAFlightData.CurrentRowIndex, grdFAAFlightData.CurrentColumnIndex].Value = "Source";

			frmFAAFlightDataGrid.Enabled = true;
			grdFAAFlightData.Enabled = true;
			grdFAAFlightData.Visible = true;
			grdFAAFlightData.Redraw = false;

		} // Load_FAA_Flight_Data_Grid_Headers

		private void Load_FAA_Flight_Data_Summary_Grid_Headers()
		{


			frmFAAFlightDataGrid.Enabled = false;
			grdFAAFlightDataSummary.Enabled = false;

			grdFAAFlightDataSummary.Clear();
			grdFAAFlightDataSummary.RowsCount = 2;
			grdFAAFlightDataSummary.ColumnsCount = 9;

			grdFAAFlightDataSummary.FixedColumns = 0;
			grdFAAFlightDataSummary.FixedRows = 0;

			grdFAAFlightDataSummary.CurrentRowIndex = 0;

			int lCol1 = 0;
			grdFAAFlightDataSummary.CurrentColumnIndex = lCol1;
			grdFAAFlightDataSummary.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			grdFAAFlightDataSummary.SetColumnWidth(lCol1, 0);
			grdFAAFlightDataSummary[grdFAAFlightDataSummary.CurrentRowIndex, grdFAAFlightDataSummary.CurrentColumnIndex].Value = "APortId";

			lCol1++;
			grdFAAFlightDataSummary.CurrentColumnIndex = lCol1;
			grdFAAFlightDataSummary.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			grdFAAFlightDataSummary.SetColumnWidth(lCol1, 53);
			grdFAAFlightDataSummary[grdFAAFlightDataSummary.CurrentRowIndex, grdFAAFlightDataSummary.CurrentColumnIndex].Value = "IATA";

			lCol1++;
			grdFAAFlightDataSummary.CurrentColumnIndex = lCol1;
			grdFAAFlightDataSummary.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			grdFAAFlightDataSummary.SetColumnWidth(lCol1, 53);
			grdFAAFlightDataSummary[grdFAAFlightDataSummary.CurrentRowIndex, grdFAAFlightDataSummary.CurrentColumnIndex].Value = "ICAO";

			lCol1++;
			grdFAAFlightDataSummary.CurrentColumnIndex = lCol1;
			grdFAAFlightDataSummary.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			grdFAAFlightDataSummary.SetColumnWidth(lCol1, 53);
			grdFAAFlightDataSummary[grdFAAFlightDataSummary.CurrentRowIndex, grdFAAFlightDataSummary.CurrentColumnIndex].Value = "FAAID";

			lCol1++;
			grdFAAFlightDataSummary.CurrentColumnIndex = lCol1;
			grdFAAFlightDataSummary.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			grdFAAFlightDataSummary.SetColumnWidth(lCol1, 167);
			grdFAAFlightDataSummary[grdFAAFlightDataSummary.CurrentRowIndex, grdFAAFlightDataSummary.CurrentColumnIndex].Value = "Airport";
			grdFAAFlightDataSummary[1, lCol1].Value = "No Records Found";

			lCol1++;
			grdFAAFlightDataSummary.CurrentColumnIndex = lCol1;
			grdFAAFlightDataSummary.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			grdFAAFlightDataSummary.SetColumnWidth(lCol1, 167);
			grdFAAFlightDataSummary[grdFAAFlightDataSummary.CurrentRowIndex, grdFAAFlightDataSummary.CurrentColumnIndex].Value = "Country";

			lCol1++;
			grdFAAFlightDataSummary.CurrentColumnIndex = lCol1;
			grdFAAFlightDataSummary.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			grdFAAFlightDataSummary.SetColumnWidth(lCol1, 167);
			grdFAAFlightDataSummary[grdFAAFlightDataSummary.CurrentRowIndex, grdFAAFlightDataSummary.CurrentColumnIndex].Value = "City";

			lCol1++;
			grdFAAFlightDataSummary.CurrentColumnIndex = lCol1;
			grdFAAFlightDataSummary.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			grdFAAFlightDataSummary.SetColumnWidth(lCol1, 33);
			grdFAAFlightDataSummary[grdFAAFlightDataSummary.CurrentRowIndex, grdFAAFlightDataSummary.CurrentColumnIndex].Value = "State";

			lCol1++;
			grdFAAFlightDataSummary.CurrentColumnIndex = lCol1;
			grdFAAFlightDataSummary.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			grdFAAFlightDataSummary.SetColumnWidth(lCol1, 93);
			grdFAAFlightDataSummary[grdFAAFlightDataSummary.CurrentRowIndex, grdFAAFlightDataSummary.CurrentColumnIndex].Value = "Total Flights";

			frmFAAFlightDataGrid.Enabled = true;
			grdFAAFlightDataSummary.Enabled = true;
			grdFAAFlightDataSummary.Visible = true;
			grdFAAFlightDataSummary.Redraw = false;

		} // Load_FAA_Flight_Data_Summary_Grid_Headers

		public void Fill_FAA_Flight_Data_Grid_Record(ADORecordSetHelper rstRec1, int lTot1, ref int lCnt1, ref int lRow1, ref int lCol1, ref int lCellColor, ref bool bPassed)
		{

			if (!rstRec1.BOF && !rstRec1.EOF)
			{

				lCellColor = Convert.ToInt32(Double.Parse(modAdminCommon.NoColor));
				if (Convert.ToString(rstRec1["ffd_hide_flag"]).ToUpper() == "Y")
				{
					lCellColor = Convert.ToInt32(Double.Parse(modAdminCommon.InactiveColor));
				}

				if (!bPassed)
				{
					if (gdDatePurchased > DateTime.FromOADate(0))
					{
						if (Convert.ToDateTime(rstRec1["ffd_date"]) < gdDatePurchased)
						{
							lRow1++;
							grdFAAFlightData.RowsCount = lRow1;
							grdFAAFlightData.CurrentRowIndex = lRow1 - 1;
							grdFAAFlightData.CurrentColumnIndex = 5;
							grdFAAFlightData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.InactiveColor)));
							grdFAAFlightData.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
							grdFAAFlightData[grdFAAFlightData.CurrentRowIndex, grdFAAFlightData.CurrentColumnIndex].Value = "Flights Not Current Owner";
							bPassed = true;
						}
					} // If gdDatePurchased > 0 Then
				} // If bPassed = False Then

				lRow1++;
				grdFAAFlightData.RowsCount = lRow1;
				grdFAAFlightData.CurrentRowIndex = lRow1 - 1;

				lCol1 = 0;
				grdFAAFlightData.CurrentColumnIndex = lCol1;
				grdFAAFlightData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
				grdFAAFlightData.CellBackColor = ColorTranslator.FromOle(lCellColor);
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(rstRec1["ffd_unique_flight_id"]))
				{
					grdFAAFlightData[grdFAAFlightData.CurrentRowIndex, grdFAAFlightData.CurrentColumnIndex].Value = Convert.ToString(rstRec1["ffd_unique_flight_id"]);
				}

				lCol1++;
				grdFAAFlightData.CurrentColumnIndex = lCol1;
				grdFAAFlightData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
				grdFAAFlightData.CellBackColor = ColorTranslator.FromOle(lCellColor);
				grdFAAFlightData[grdFAAFlightData.CurrentRowIndex, grdFAAFlightData.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["ffd_reg_no"])} ").Trim();

				lCol1++;
				grdFAAFlightData.CurrentColumnIndex = lCol1;
				grdFAAFlightData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
				grdFAAFlightData.CellBackColor = ColorTranslator.FromOle(lCellColor);
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(rstRec1["ffd_date"]))
				{
					grdFAAFlightData[grdFAAFlightData.CurrentRowIndex, grdFAAFlightData.CurrentColumnIndex].Value = Convert.ToDateTime(rstRec1["ffd_date"]).ToString("MM/dd/yyyy");
				}

				lCol1++;
				grdFAAFlightData.CurrentColumnIndex = lCol1;
				grdFAAFlightData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
				grdFAAFlightData.CellBackColor = ColorTranslator.FromOle(lCellColor);
				grdFAAFlightData[grdFAAFlightData.CurrentRowIndex, grdFAAFlightData.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["ffd_origin_aport"])} ").Trim();

				lCol1++;
				grdFAAFlightData.CurrentColumnIndex = lCol1;
				grdFAAFlightData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
				grdFAAFlightData.CellBackColor = ColorTranslator.FromOle(lCellColor);
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(rstRec1["ffd_origin_aport_id"]))
				{
					grdFAAFlightData[grdFAAFlightData.CurrentRowIndex, grdFAAFlightData.CurrentColumnIndex].Value = Convert.ToString(rstRec1["ffd_origin_aport_id"]);
				}

				lCol1++;
				grdFAAFlightData.CurrentColumnIndex = lCol1;
				grdFAAFlightData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
				grdFAAFlightData.CellBackColor = ColorTranslator.FromOle(lCellColor);
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(rstRec1["ffd_origin_date"]))
				{
					grdFAAFlightData[grdFAAFlightData.CurrentRowIndex, grdFAAFlightData.CurrentColumnIndex].Value = StringsHelper.Format(rstRec1["ffd_origin_date"], "mm/dd/yyyy hh:MM:ss AMPM");
				}

				lCol1++;
				grdFAAFlightData.CurrentColumnIndex = lCol1;
				grdFAAFlightData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
				grdFAAFlightData.CellBackColor = ColorTranslator.FromOle(lCellColor);
				grdFAAFlightData[grdFAAFlightData.CurrentRowIndex, grdFAAFlightData.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["ffd_dest_aport"])} ").Trim();

				lCol1++;
				grdFAAFlightData.CurrentColumnIndex = lCol1;
				grdFAAFlightData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
				grdFAAFlightData.CellBackColor = ColorTranslator.FromOle(lCellColor);
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(rstRec1["ffd_dest_aport_id"]))
				{
					grdFAAFlightData[grdFAAFlightData.CurrentRowIndex, grdFAAFlightData.CurrentColumnIndex].Value = Convert.ToString(rstRec1["ffd_dest_aport_id"]);
				}

				lCol1++;
				grdFAAFlightData.CurrentColumnIndex = lCol1;
				grdFAAFlightData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
				grdFAAFlightData.CellBackColor = ColorTranslator.FromOle(lCellColor);
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(rstRec1["ffd_dest_date"]))
				{
					grdFAAFlightData[grdFAAFlightData.CurrentRowIndex, grdFAAFlightData.CurrentColumnIndex].Value = StringsHelper.Format(rstRec1["ffd_dest_date"], "mm/dd/yyyy hh:MM:ss AMPM");
				}

				lCol1++;
				grdFAAFlightData.CurrentColumnIndex = lCol1;
				grdFAAFlightData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
				grdFAAFlightData.CellBackColor = ColorTranslator.FromOle(lCellColor);
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(rstRec1["ffd_flight_time"]))
				{
					grdFAAFlightData[grdFAAFlightData.CurrentRowIndex, grdFAAFlightData.CurrentColumnIndex].Value = StringsHelper.Format(rstRec1["ffd_flight_time"], "#,##0");
				}

				lCol1++;
				grdFAAFlightData.CurrentColumnIndex = lCol1;
				grdFAAFlightData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
				grdFAAFlightData.CellBackColor = ColorTranslator.FromOle(lCellColor);
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(rstRec1["ffd_distance"]))
				{
					grdFAAFlightData[grdFAAFlightData.CurrentRowIndex, grdFAAFlightData.CurrentColumnIndex].Value = StringsHelper.Format(rstRec1["ffd_distance"], "#,##0");
				}

				lCol1++;
				grdFAAFlightData.CurrentColumnIndex = lCol1;
				grdFAAFlightData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
				grdFAAFlightData.CellBackColor = ColorTranslator.FromOle(lCellColor);
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(rstRec1["ffd_entry_date"]))
				{
					grdFAAFlightData[grdFAAFlightData.CurrentRowIndex, grdFAAFlightData.CurrentColumnIndex].Value = StringsHelper.Format(rstRec1["ffd_entry_date"], "mm/dd/yyyy hh:MM:ss AMPM");
				}

				lCol1++;
				grdFAAFlightData.CurrentColumnIndex = lCol1;
				grdFAAFlightData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
				grdFAAFlightData.CellBackColor = ColorTranslator.FromOle(lCellColor);
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(rstRec1["ffd_ac_id"]))
				{
					grdFAAFlightData[grdFAAFlightData.CurrentRowIndex, grdFAAFlightData.CurrentColumnIndex].Value = Convert.ToString(rstRec1["ffd_ac_id"]);
				}

				lCol1++;
				grdFAAFlightData.CurrentColumnIndex = lCol1;
				grdFAAFlightData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
				grdFAAFlightData.CellBackColor = ColorTranslator.FromOle(lCellColor);
				grdFAAFlightData[grdFAAFlightData.CurrentRowIndex, grdFAAFlightData.CurrentColumnIndex].Value = modCommon.ReturnYesNo(($"{Convert.ToString(rstRec1["ffd_hide_flag"])} ").Trim());

				lCol1++;
				grdFAAFlightData.CurrentColumnIndex = lCol1;
				grdFAAFlightData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
				grdFAAFlightData.CellBackColor = ColorTranslator.FromOle(lCellColor);
				grdFAAFlightData[grdFAAFlightData.CurrentRowIndex, grdFAAFlightData.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["ffd_data_source"])} ").Trim();

				lCnt1++;
				lblRecords.Text = $"Records Found: {StringsHelper.Format(lTot1, "#,##0")} Loading: {StringsHelper.Format(lCnt1, "#,##0")}";

				if (lCnt1 == 25)
				{
					grdFAAFlightData.Enabled = true;
					grdFAAFlightData.Redraw = true;
					Application.DoEvents();
					grdFAAFlightData.Enabled = false;
					grdFAAFlightData.Redraw = false;
				} // If lCnt1 = 30 Then

			} // If rstRec1.BOF = False And rstRec1.EOF = False Then

		} // Fill_FAA_Flight_Data_Grid_Record

		public void Fill_FAA_Flight_Data_Summary_Grid_Record(ADORecordSetHelper rstRec1, int lTot1, ref int lCnt1, ref int lRow1, ref int lCol1, ref int lCellColor, bool bPassed)
		{

			if (!rstRec1.BOF && !rstRec1.EOF)
			{

				lCellColor = Convert.ToInt32(Double.Parse(modAdminCommon.NoColor));

				lRow1++;
				grdFAAFlightDataSummary.RowsCount = lRow1;
				grdFAAFlightDataSummary.CurrentRowIndex = lRow1 - 1;

				lCol1 = 0;
				grdFAAFlightDataSummary.CurrentColumnIndex = lCol1;
				grdFAAFlightDataSummary.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
				grdFAAFlightDataSummary.CellBackColor = ColorTranslator.FromOle(lCellColor);
				grdFAAFlightDataSummary[grdFAAFlightDataSummary.CurrentRowIndex, grdFAAFlightDataSummary.CurrentColumnIndex].Value = Convert.ToString(rstRec1["APortId"]);

				lCol1++;
				grdFAAFlightDataSummary.CurrentColumnIndex = lCol1;
				grdFAAFlightDataSummary.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
				grdFAAFlightDataSummary.CellBackColor = ColorTranslator.FromOle(lCellColor);
				grdFAAFlightDataSummary[grdFAAFlightDataSummary.CurrentRowIndex, grdFAAFlightDataSummary.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["IATA"])} ").Trim();

				lCol1++;
				grdFAAFlightDataSummary.CurrentColumnIndex = lCol1;
				grdFAAFlightDataSummary.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
				grdFAAFlightDataSummary.CellBackColor = ColorTranslator.FromOle(lCellColor);
				grdFAAFlightDataSummary[grdFAAFlightDataSummary.CurrentRowIndex, grdFAAFlightDataSummary.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["ICAO"])} ").Trim();

				lCol1++;
				grdFAAFlightDataSummary.CurrentColumnIndex = lCol1;
				grdFAAFlightDataSummary.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
				grdFAAFlightDataSummary.CellBackColor = ColorTranslator.FromOle(lCellColor);
				grdFAAFlightDataSummary[grdFAAFlightDataSummary.CurrentRowIndex, grdFAAFlightDataSummary.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["FAAID"])} ").Trim();

				lCol1++;
				grdFAAFlightDataSummary.CurrentColumnIndex = lCol1;
				grdFAAFlightDataSummary.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
				grdFAAFlightDataSummary.CellBackColor = ColorTranslator.FromOle(lCellColor);
				grdFAAFlightDataSummary[grdFAAFlightDataSummary.CurrentRowIndex, grdFAAFlightDataSummary.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["Airport"])} ").Trim();

				lCol1++;
				grdFAAFlightDataSummary.CurrentColumnIndex = lCol1;
				grdFAAFlightDataSummary.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
				grdFAAFlightDataSummary.CellBackColor = ColorTranslator.FromOle(lCellColor);
				grdFAAFlightDataSummary[grdFAAFlightDataSummary.CurrentRowIndex, grdFAAFlightDataSummary.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["country"])} ").Trim();

				lCol1++;
				grdFAAFlightDataSummary.CurrentColumnIndex = lCol1;
				grdFAAFlightDataSummary.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
				grdFAAFlightDataSummary.CellBackColor = ColorTranslator.FromOle(lCellColor);
				grdFAAFlightDataSummary[grdFAAFlightDataSummary.CurrentRowIndex, grdFAAFlightDataSummary.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["city"])} ").Trim();


				lCol1++;
				grdFAAFlightDataSummary.CurrentColumnIndex = lCol1;
				grdFAAFlightDataSummary.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
				grdFAAFlightDataSummary.CellBackColor = ColorTranslator.FromOle(lCellColor);
				grdFAAFlightDataSummary[grdFAAFlightDataSummary.CurrentRowIndex, grdFAAFlightDataSummary.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["state"])} ").Trim();

				lCol1++;
				grdFAAFlightDataSummary.CurrentColumnIndex = lCol1;
				grdFAAFlightDataSummary.CellAlignment = DataGridViewContentAlignment.MiddleRight;
				grdFAAFlightDataSummary.CellBackColor = ColorTranslator.FromOle(lCellColor);
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(rstRec1["TotFlights"]))
				{
					grdFAAFlightDataSummary[grdFAAFlightDataSummary.CurrentRowIndex, grdFAAFlightDataSummary.CurrentColumnIndex].Value = StringsHelper.Format(rstRec1["TotFlights"], "#,##0");
				}

				lCnt1++;
				lblRecords.Text = $"Records Found: {StringsHelper.Format(lTot1, "#,##0")} Loading: {StringsHelper.Format(lCnt1, "#,##0")}";

				if (lCnt1 == 25)
				{
					grdFAAFlightDataSummary.Enabled = true;
					grdFAAFlightDataSummary.Redraw = true;
					Application.DoEvents();
					grdFAAFlightDataSummary.Enabled = false;
					grdFAAFlightDataSummary.Redraw = false;
				} // If lCnt1 = 30 Then

			} // If rstRec1.BOF = False And rstRec1.EOF = False Then

		} // Fill_FAA_Flight_Data_Summary_Grid_Record

		public void Load_FAA_Flight_Data_Grid()
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			int lTot1 = 0;
			int lCnt1 = 0;
			int lRow1 = 0;
			int lCol1 = 0;
			int lCellColor = 0;
			bool bPassed = false;

			try
			{

				if (grdFAAFlightData.Enabled || grdFAAFlightDataSummary.Enabled)
				{

					lblStopLoading.Visible = true;
					lblStopLoading.Enabled = true;

					grdFAAFlightData.Enabled = false;
					grdFAAFlightData.Visible = false;
					grdFAAFlightDataSummary.Enabled = false;
					grdFAAFlightDataSummary.Visible = false;

					lblRecords.Text = "Records Found: 0";

					if (glACId > 0)
					{

						if (rbAllFlights.Checked)
						{

							Load_FAA_Flight_Data_Grid_Headers();

							strQuery1 = "SELECT *  FROM FAA_Flight_Data WITH (NOLOCK) ";
							strQuery1 = $"{strQuery1}WHERE (ffd_ac_id = {glACId.ToString()}) ORDER BY ffd_date DESC ";

						} // If rbAllFlights.Value = True Then

						if (rbOriginFlights.Checked)
						{

							Load_FAA_Flight_Data_Summary_Grid_Headers();

							strQuery1 = "SELECT  aport_id As APortId, aport_iata_code As IATA, ";
							strQuery1 = $"{strQuery1}aport_icao_code As ICAO, ";
							strQuery1 = $"{strQuery1}aport_faaid_code As FAAID, ";
							strQuery1 = $"{strQuery1}aport_name As Airport,  aport_country As Country, ";
							strQuery1 = $"{strQuery1}aport_city AS City, aport_state AS State, ";
							strQuery1 = $"{strQuery1}COUNT(ffd_unique_flight_id) As TotFlights ";
							strQuery1 = $"{strQuery1}FROM Airport WITH (NOLOCK) ";
							strQuery1 = $"{strQuery1}INNER JOIN FAA_Flight_Data WITH (NOLOCK) ON ffd_origin_aport_id = aport_id ";
							strQuery1 = $"{strQuery1}INNER JOIN Aircraft WITH (NOLOCK) ON ac_id = ffd_ac_id AND ac_journ_id = ffd_journ_id ";
							strQuery1 = $"{strQuery1}WHERE (ffd_ac_id = {glACId.ToString()}) AND (ffd_journ_id = 0) ";
							strQuery1 = $"{strQuery1}AND ((ffd_date >= ac_purchase_date) or ac_purchase_date is null) ";
							strQuery1 = $"{strQuery1}GROUP BY aport_id, aport_iata_code, aport_icao_code, aport_faaid_code, aport_name, aport_country, aport_city, aport_state ";
							strQuery1 = $"{strQuery1}ORDER BY COUNT(ffd_unique_flight_id) DESC ";

						} // If rbOriginFlights.Value = True Then

						if (rbDestFlights.Checked)
						{

							Load_FAA_Flight_Data_Summary_Grid_Headers();

							strQuery1 = "SELECT aport_id As APortId, ";
							strQuery1 = $"{strQuery1}aport_iata_code As IATA,  aport_icao_code As ICAO, ";
							strQuery1 = $"{strQuery1}aport_faaid_code As FAAID, aport_name As Airport, ";
							strQuery1 = $"{strQuery1}aport_country As Country,  aport_city AS City, ";
							strQuery1 = $"{strQuery1}aport_state AS State, COUNT(ffd_unique_flight_id) As TotFlights ";
							strQuery1 = $"{strQuery1}FROM Airport WITH (NOLOCK) ";
							strQuery1 = $"{strQuery1}INNER JOIN FAA_Flight_Data WITH (NOLOCK) ON ffd_dest_aport_id = aport_id ";
							strQuery1 = $"{strQuery1}INNER JOIN Aircraft WITH (NOLOCK) ON ac_id = ffd_ac_id AND ac_journ_id = ffd_journ_id ";
							strQuery1 = $"{strQuery1}WHERE (ffd_ac_id = {glACId.ToString()}) ";
							strQuery1 = $"{strQuery1}AND (ffd_journ_id = 0) ";
							strQuery1 = $"{strQuery1}AND ((ffd_date >= ac_purchase_date) or ac_purchase_date is null) ";
							strQuery1 = $"{strQuery1}GROUP BY aport_id, aport_iata_code, aport_icao_code, aport_faaid_code, aport_name, aport_country, aport_city, aport_state ";
							strQuery1 = $"{strQuery1}ORDER BY COUNT(ffd_unique_flight_id) DESC ";

						} // If rbDestFlights.Value = True Then

						rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
						rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

						if (!rstRec1.BOF && !rstRec1.EOF)
						{

							rstRec1.ActiveConnection = null;
							lTot1 = rstRec1.RecordCount;

							lblRecords.Text = $"Records Found: {StringsHelper.Format(lTot1, "#,##0")} Loading: 0";

							lCnt1 = 0;
							lRow1 = 1;
							bPassed = false;

							do 
							{ // Loop Until rstRec1.EOF = True Or lblStopLoading.Enabled = False

								if (rbAllFlights.Checked)
								{
									Fill_FAA_Flight_Data_Grid_Record(rstRec1, lTot1, ref lCnt1, ref lRow1, ref lCol1, ref lCellColor, ref bPassed);
								}

								if (rbOriginFlights.Checked || rbDestFlights.Checked)
								{
									Fill_FAA_Flight_Data_Summary_Grid_Record(rstRec1, lTot1, ref lCnt1, ref lRow1, ref lCol1, ref lCellColor, bPassed);
								}

								rstRec1.MoveNext();
								Application.DoEvents();

							}
							while(!(rstRec1.EOF || !lblStopLoading.Enabled));

							lblRecords.Text = $"Records Found: {StringsHelper.Format(lTot1, "#,##0")}";

						} // If rstRec1.BOF = False And rstRec1.EOF = falase Then

						rstRec1.Close();

					} // If glACId > 0 Then

					lblStopLoading.Visible = false;
					lblStopLoading.Enabled = false;

					if (rbAllFlights.Checked)
					{
						grdFAAFlightData.Redraw = true;
						grdFAAFlightData.Enabled = Convert.ToString(grdFAAFlightData[1, 5].Value) != "No Records Found";
						grdFAAFlightData.FixedRows = 1;
					}

					if (rbOriginFlights.Checked || rbDestFlights.Checked)
					{
						grdFAAFlightDataSummary.Redraw = true;
						grdFAAFlightDataSummary.Enabled = Convert.ToString(grdFAAFlightDataSummary[1, 4].Value) != "No Records Found";
						grdFAAFlightDataSummary.FixedRows = 1;
					}

				} // If grdFAAFlightData.Enabled = True Or grdFAAFlightDataSummary.Enabled = True Then

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"Load_FAA_Flight_Data_Grid_Error: {excep.Message}");
			}

		} // Load_FAA_Flight_Data_Grid

		private void Clear_FAA_Data_Record_Form()
		{

			txtFAAFlightId.Text = "";
			txtRegNbr.Text = "";
			txtFlightDate.Text = "";

			txtFlightTime.Text = "";
			txtDistance.Text = "";

			txtOriginAPortId.Text = "";
			txtOriginAPortCode.Text = "";
			lblOriginAPortName.Text = "";
			ToolTipMain.SetToolTip(lblOriginAPortName, "");
			txtOriginDate.Text = "";

			txtDestAPortId.Text = "";
			txtDestAPortCode.Text = "";
			lblDestAPortName.Text = "";
			ToolTipMain.SetToolTip(lblDestAPortName, "");
			txtDestDate.Text = "";

			txtACId.Text = "";
			lblMakeModelSerNbr.Text = "";
			txtEnteredDate.Text = "";

			chkHideFlag.CheckState = CheckState.Unchecked;
			cmdSave.Enabled = false;

		} // Clear_FAA_Data_Record_Form

		private void Load_FAA_Flight_Data_Rercord(string strFlightId)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			ADORecordSetHelper rstRec2 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strQuery2 = "";

			int lACId = 0;
			int lOriginAPortId = 0;
			int lDestAPortId = 0;

			string strOriginAPortNameCityStateCountry = "";
			string strDestAPortNameCityStateCountry = "";
			string strMakeModelSerNbr = "";

			try
			{

				Clear_FAA_Data_Record_Form();

				if (strFlightId != "")
				{

					strQuery1 = "SELECT * FROM FAA_Flight_Data WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1}WHERE (ffd_unique_flight_id = {strFlightId}) ";

					rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						rstRec1.ActiveConnection = null;

						txtFAAFlightId.Text = Convert.ToString(rstRec1["ffd_unique_flight_id"]);
						txtRegNbr.Text = ($"{Convert.ToString(rstRec1["ffd_reg_no"])} ").Trim();

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["ffd_date"]))
						{
							txtFlightDate.Text = Convert.ToDateTime(rstRec1["ffd_date"]).ToString("MM/dd/yyyy");
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["ffd_flight_time"]))
						{
							txtFlightTime.Text = StringsHelper.Format(rstRec1["ffd_flight_time"], "#,##0");
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["ffd_origin_aport_id"]))
						{
							txtOriginAPortId.Text = Convert.ToString(rstRec1["ffd_origin_aport_id"]);
							txtOriginAPortId.Tag = Convert.ToString(rstRec1["ffd_origin_aport_id"]);
							if (Convert.ToDouble(rstRec1["ffd_origin_aport_id"]) > 0)
							{
								lblOriginAPortName.Text = modCommon.DLookUp("aport_name", "Airport", $"(aport_id = {Convert.ToString(rstRec1["ffd_origin_aport_id"])})");
								ToolTipMain.SetToolTip(lblOriginAPortName, modCommon.DLookUp("COALESCE(aport_city,'')+' '+COALESCE(aport_state,'')+' '+COALESCE(aport_country,'')", "Airport", $"(aport_id = {Convert.ToString(rstRec1["ffd_origin_aport_id"])})"));
							}
						}

						txtOriginAPortCode.Text = ($"{Convert.ToString(rstRec1["ffd_origin_aport"])} ").Trim();

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["ffd_origin_date"]))
						{
							txtOriginDate.Text = StringsHelper.Format(rstRec1["ffd_origin_date"], "mm/dd/yyyy hh:MM:ss AMPM");
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["ffd_dest_aport_id"]))
						{
							txtDestAPortId.Text = Convert.ToString(rstRec1["ffd_dest_aport_id"]);
							txtDestAPortId.Tag = Convert.ToString(rstRec1["ffd_dest_aport_id"]);
							if (Convert.ToDouble(rstRec1["ffd_dest_aport_id"]) > 0)
							{
								lblDestAPortName.Text = modCommon.DLookUp("aport_name", "Airport", $"(aport_id = {Convert.ToString(rstRec1["ffd_dest_aport_id"])})");
								ToolTipMain.SetToolTip(lblDestAPortName, modCommon.DLookUp("COALESCE(aport_city,'')+' '+COALESCE(aport_state,'')+' '+COALESCE(aport_country,'')", "Airport", $"(aport_id = {Convert.ToString(rstRec1["ffd_dest_aport_id"])})"));
							}
						}

						txtDestAPortCode.Text = ($"{Convert.ToString(rstRec1["ffd_dest_aport"])} ").Trim();

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["ffd_dest_date"]))
						{
							txtDestDate.Text = StringsHelper.Format(rstRec1["ffd_dest_date"], "mm/dd/yyyy hh:MM:ss AMPM");
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["ffd_ac_id"]))
						{
							txtACId.Text = Convert.ToString(rstRec1["ffd_ac_id"]);
							txtACId.Tag = Convert.ToString(rstRec1["ffd_ac_id"]);
							if (Convert.ToDouble(rstRec1["ffd_ac_id"]) > 0)
							{
								lblMakeModelSerNbr.Text = modCommon.DLookUp("amod_make_name+' '+amod_model_name+' '+ac_ser_no_full", "Aircraft WITH (NOLOCK) INNER JOIN Aircraft_Model WITH (NOLOCK) ON amod_id = ac_amod_id", $"(ac_id = {Convert.ToString(rstRec1["ffd_ac_id"])} AND ac_journ_id = 0)");
							}
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["ffd_distance"]))
						{
							txtDistance.Text = StringsHelper.Format(rstRec1["ffd_distance"], "#,##0");
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["ffd_entry_date"]))
						{
							txtEnteredDate.Text = StringsHelper.Format(rstRec1["ffd_entry_date"], "mm/dd/yyyy hh:MM:ss AMPM");
						}

						if (($"{Convert.ToString(rstRec1["ffd_hide_flag"])} ").Trim() == "Y")
						{
							chkHideFlag.CheckState = CheckState.Checked;
						}

						cmdSave.Enabled = true;

					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

				} // If strFlightId <> "" Then

				rstRec2 = null;
				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"Load_FAA_Flight_Data_Rercord_Error: {excep.Message}");
			}

		} // Load_FAA_Flight_Data_Rercord

		private void grdFAAFlightData_DoubleClick(Object eventSender, EventArgs eventArgs)
		{


			grdFAAFlightData.Enabled = false;
			glRow = grdFAAFlightData.CurrentRowIndex;
			glTopRow = grdFAAFlightData.FirstDisplayedScrollingRowIndex;

			string strFlightId = Convert.ToString(grdFAAFlightData[glRow, 0].Value);

			if (strFlightId != "")
			{
				Load_FAA_Flight_Data_Rercord(strFlightId);
			} // If strFlightId <> "" Then

			grdFAAFlightData.CurrentRowIndex = glRow;
			modCommon.Highlight_Grid_Row(grdFAAFlightData);

			grdFAAFlightData.Enabled = true;

		} // grdFAAFlightData_DblClick

		private void grdFAAFlightDataSummary_DoubleClick(Object eventSender, EventArgs eventArgs)
		{

			int lRow1 = 0;
			int lCol1 = 0;

			gAPortId = 0;
			if (MessageBox.Show("Set Selected Airport As Aircraft Base", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
			{

				lRow1 = grdFAAFlightDataSummary.CurrentRowIndex;
				lCol1 = grdFAAFlightDataSummary.CurrentColumnIndex;

				if (lRow1 > 0)
				{
					gAPortId = Convert.ToInt32(Double.Parse(Convert.ToString(grdFAAFlightDataSummary[lRow1, 0].Value)));
					this.Close();
				}

			} // If MsgBox("Set Selected Airport As Aircraft Base", vbYesNo) = vbYes Then

		} // grdFAAFlightDataSummary_DblClick

		private void lblStopExporting_Click(Object eventSender, EventArgs eventArgs) => modExcel.StopExcelExporting();


		private void lblStopLoading_Click(Object eventSender, EventArgs eventArgs) => lblStopLoading.Enabled = false;


		private bool isInitializingComponent;
		private void rbAllFlights_CheckedChanged(Object eventSender, EventArgs eventArgs)
		{
			if (((RadioButton) eventSender).Checked)
			{
				if (isInitializingComponent)
				{
					return;
				}

				if (rbAllFlights.Enabled)
				{

					grdFAAFlightDataSummary.Visible = false;
					grdFAAFlightDataSummary.Enabled = false;

					grdFAAFlightData.Visible = true;
					grdFAAFlightData.Enabled = true;

					Load_FAA_Flight_Data_Grid();

				} // If rbAllFlights.Enabled = True Then

			}
		} // rbAllFlights_Click

		private void rbOriginFlights_CheckedChanged(Object eventSender, EventArgs eventArgs)
		{
			if (((RadioButton) eventSender).Checked)
			{
				if (isInitializingComponent)
				{
					return;
				}

				if (rbOriginFlights.Enabled)
				{

					grdFAAFlightData.Visible = false;
					grdFAAFlightData.Enabled = false;

					grdFAAFlightDataSummary.Visible = true;
					grdFAAFlightDataSummary.Enabled = true;

					Load_FAA_Flight_Data_Grid();

				} // If rbOriginFlights.Enabled = True Then

			}
		} // rbOriginFlights_Click

		private void rbDestFlights_CheckedChanged(Object eventSender, EventArgs eventArgs)
		{
			if (((RadioButton) eventSender).Checked)
			{
				if (isInitializingComponent)
				{
					return;
				}

				if (rbDestFlights.Enabled)
				{

					grdFAAFlightData.Visible = false;
					grdFAAFlightData.Enabled = false;

					grdFAAFlightDataSummary.Visible = true;
					grdFAAFlightDataSummary.Enabled = true;

					Load_FAA_Flight_Data_Grid();

				} // If rbDestFlights.Enabled = True Then

			}
		} // rbDestFlights_Click

		private void txtOriginAPortId_Leave(Object eventSender, EventArgs eventArgs)
		{

			int lDistance = 0;

			if (txtOriginAPortId.Text != Convert.ToString(txtOriginAPortId.Tag))
			{

				if (txtOriginAPortId.Text != "" && txtOriginAPortId.Text != "0")
				{
					if (Information.IsNumeric(txtOriginAPortId.Text))
					{
						lblOriginAPortName.Text = modCommon.DLookUp("aport_name+', '+COALESCE(aport_city,'')+' '+COALESCE(aport_state,'')+' '+COALESCE(aport_country,'')", "Airport", $"(aport_id = {txtOriginAPortId.Text.Trim()})");
						lDistance = modAdminCommon.CalulateDistanceBetweenAirports(Convert.ToInt32(Double.Parse(txtOriginAPortId.Text)), Convert.ToInt32(Double.Parse(txtDestAPortId.Text)));
						txtDistance.Text = StringsHelper.Format(lDistance, "#,##0");
					}
					else
					{
						MessageBox.Show("Dest-Airport Id Is Non-Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				else
				{
					lblOriginAPortName.Text = "";
					txtDistance.Text = "0";
				}
			} // If txtOriginAPortId.Text <> txtOriginAPortId.Tag Then

		} // txtOriginAPortId

		private void txtDestAPortId_Leave(Object eventSender, EventArgs eventArgs)
		{

			int lDistance = 0;

			if (txtDestAPortId.Text != Convert.ToString(txtDestAPortId.Tag))
			{

				if (txtDestAPortId.Text != "" && txtDestAPortId.Text != "0")
				{
					if (Information.IsNumeric(txtDestAPortId.Text))
					{
						lblDestAPortName.Text = modCommon.DLookUp("aport_name+', '+COALESCE(aport_city,'')+' '+COALESCE(aport_state,'')+' '+COALESCE(aport_country,'')", "Airport", $"(aport_id = {txtDestAPortId.Text.Trim()})");
						lDistance = modAdminCommon.CalulateDistanceBetweenAirports(Convert.ToInt32(Double.Parse(txtOriginAPortId.Text)), Convert.ToInt32(Double.Parse(txtDestAPortId.Text)));
						txtDistance.Text = StringsHelper.Format(lDistance, "#,##0");
					}
					else
					{
						MessageBox.Show("Dest-Airport Id Is Non-Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				else
				{
					lblDestAPortName.Text = "";
					txtDistance.Text = "0";
				}
			} // If txtDestAPortId.Text <> txtDestAPortId.Tag Then

		} // txtDestAPortId

		private void txtACID_Leave(Object eventSender, EventArgs eventArgs)
		{

			if (txtACId.Text != Convert.ToString(txtACId.Tag))
			{

				if (txtACId.Text != "" && txtACId.Text != "0")
				{
					if (Information.IsNumeric(txtACId.Text))
					{
						lblMakeModelSerNbr.Text = modCommon.DLookUp("amod_make_name+' '+amod_model_name+' '+ac_ser_no_full", "Aircraft WITH (NOLOCK) INNER JOIN Aircraft_Model WITH (NOLOCK) ON amod_id = ac_amod_id", $"(ac_id = {txtACId.Text.Trim()} AND ac_journ_id = 0)");
					}
					else
					{
						MessageBox.Show("ACId Is Non-Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				else
				{
					lblMakeModelSerNbr.Text = "";
				}
			} // If txtACId.Text <> txtACId.Tag Then

		} // txtACId_LostFocus
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}