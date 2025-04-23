using Microsoft.VisualBasic;
using System;
using System.Data.Common;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Helpers;

namespace JETNET_Homebase
{
	internal partial class frm_UserHoursWorked
		: System.Windows.Forms.Form
	{

		public frm_UserHoursWorked()
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


		private void frm_UserHoursWorked_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}


		static readonly private Color iWhite = SystemColors.Window;
		static readonly private Color iBlack = SystemColors.WindowText;

		static readonly private Color iLtGrey = Color.Silver;
		static readonly private Color iDkGrey = Color.Gray;

		private const int iLtOrange = 0x80FF;
		private const int iDkOrange = 0x40C0;

		static readonly private Color iVLtGreen = Color.FromArgb(128, 255, 128);
		private const int iLtGreen = 0xC000;
		private const int iDkGreen = 0x8000;

		static readonly private Color iLtRed = Color.FromArgb(255, 192, 192);
		private const int iDkRed = 0xFF;

		static readonly private Color iYellow = Color.Yellow;
		static readonly private Color iRed = Color.FromArgb(192, 0, 0);

		private string strMsg = "";
		private System.DateTime dtStartDate = DateTime.FromOADate(0);
		private System.DateTime dtEndDate = DateTime.FromOADate(0);

		private void Calculate_Grid_Totals()
		{

			double dTotalHours = 0;
			double dTotalActivityHours = 0;

			double dColTotal = 0;

			grdUserHours.Redraw = false;

			//-- Get Rid of Any Blank Cells
			for (int lRow1 = 1; lRow1 <= 7; lRow1++)
			{
				for (int lCol1 = 1; lCol1 <= 16; lCol1++)
				{
					if (Convert.ToString(grdUserHours[lRow1, lCol1].Value) == "")
					{
						grdUserHours[lRow1, lCol1].Value = "0.00";
					}
					if (Convert.ToString(grdUserHours[lRow1, lCol1].Value) == ".")
					{
						grdUserHours[lRow1, lCol1].Value = "0.00";
					}
				}
			}


			for (int lRow1 = 1; lRow1 <= 7; lRow1++)
			{

				grdUserHours.CurrentRowIndex = lRow1;

				dTotalHours = 0;
				for (int lCol1 = 1; lCol1 <= 15; lCol1++)
				{
					dTotalHours += Double.Parse(Convert.ToString(grdUserHours[lRow1, lCol1].Value));
				}

				grdUserHours.CurrentColumnIndex = 16;
				grdUserHours.CellBackColor = iDkGrey;
				grdUserHours.CellForeColor = iWhite;
				grdUserHours.CellFontBold = true;
				grdUserHours.CellAlignment = DataGridViewContentAlignment.MiddleRight;
				grdUserHours[grdUserHours.CurrentRowIndex, grdUserHours.CurrentColumnIndex].Value = StringsHelper.Format(dTotalHours, "#0.00");

				for (int lCol1 = 1; lCol1 <= 16; lCol1++)
				{
					grdUserHours[lRow1, lCol1].Value = StringsHelper.Format(Convert.ToString(grdUserHours[lRow1, lCol1].Value), "#0.00");
				}

			} // lRow1

			for (int lCol1 = 1; lCol1 <= 16; lCol1++)
			{

				dColTotal = 0;

				for (int lRow1 = 1; lRow1 <= 7; lRow1++)
				{
					dColTotal += Double.Parse(Convert.ToString(grdUserHours[lRow1, lCol1].Value));
				} // Row1

				grdUserHours.CurrentRowIndex = 8;
				grdUserHours.CurrentColumnIndex = lCol1;
				grdUserHours.CellBackColor = iDkGrey;
				grdUserHours.CellForeColor = iWhite;
				grdUserHours.CellFontBold = true;
				grdUserHours.CellAlignment = DataGridViewContentAlignment.MiddleRight;
				grdUserHours[grdUserHours.CurrentRowIndex, grdUserHours.CurrentColumnIndex].Value = StringsHelper.Format(dColTotal, "#0.00");
				if (lCol1 == 16)
				{
					grdUserHours.CellBackColor = iVLtGreen;
					grdUserHours.CellForeColor = iBlack;
					grdUserHours.CellFontBold = true;
				}

			} // lCo1

			grdUserHours.Redraw = true;
			grdUserHours.Refresh();

		} // Calculate_Grid_Totals

		private void chkIncludeSatSun_CheckStateChanged(Object eventSender, EventArgs eventArgs) => Load_New_User();
		 // chkIncludeSatSun_Click

		private void cmbReport_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs)
		{

			cmdRunReport.Enabled = false;
			if (cmbReport.Text != "" && cmbTeamLeader.Text != "")
			{
				cmdRunReport.Enabled = true;
			}

		} // cmbReport_Click

		private void cmbTeamLeader_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs)
		{

			string iPos1 = "";

			cmdRunReport.Enabled = false;

			string strUserId = "";

			if (cmbTeamLeader.Text != "")
			{
				iPos1 = (cmbTeamLeader.Text.IndexOf(" -") + 1).ToString();
				if (StringsHelper.ToDoubleSafe(iPos1) > 0)
				{
					strUserId = cmbTeamLeader.Text.Substring(0, Math.Min(Convert.ToInt32(Double.Parse(iPos1) - 1), cmbTeamLeader.Text.Length));
				}
			}

			modUserHoursWorked.Load_Report_Combo_Box(cmbReport, strUserId);

			if (cmbReport.Text != "" && cmbTeamLeader.Text != "")
			{
				cmdRunReport.Enabled = true;
			}

		} // cmbTeamLeader_Click

		private void cmdOverallTimeTracker_Click(Object eventSender, EventArgs eventArgs)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			ADORecordSetHelper rstRec2 = new ADORecordSetHelper();

			string strQuery1 = "";
			string strQuery2 = "";

			ExcelApplication objExcel = null; //gap-note Review excel type during stabilization
            ExcelApplication objExcelWB = null; //gap-note Review excel type during stabilization
            ExcelApplication objExcelWS = null; //gap-note Review excel type during stabilization

			string strExcelDir = "";
			string strFileName = "";
			string strFullFileName = "";

			int lExcelRow = 0;
			int lExcelCol = 0;
			int lExcelMaxRow = 0;
			int lExcelMaxCol = 0;

			string strTeamLeaderUserId = "";
			string strTeamLeaderTeam = "";
			string strReportName = "";

			string strStart = "";
			string strEnd = "";
			string strMsg = "";

			string strUserName = "";
			string strFName = "";
			string strLName = "";

			bool bContinue = false;

			try
			{

				cmdOverallTimeTracker.Enabled = false;

				strStart = txtWeekOfStart.Text;
				strEnd = txtWeekOfEnd.Text;

				strMsg = $"Started Export Overall Time Tracker To Excel - Dates: {strStart} to {strEnd}";
				lblStatus.Text = strMsg;
				Application.DoEvents();

				modAdminCommon.Record_Event("User Hours", strMsg, 0, 0, 0, false, 0, 0);



				strExcelDir = $"{Path.GetDirectoryName(Application.ExecutablePath)}\\ExcelFiles";

				if (!Directory.Exists(strExcelDir))
				{
					Directory.CreateDirectory(strExcelDir);
				}

				strFileName = $"research_overall_time_tracker_{DateTime.Parse(txtWeekOfStart.Text).ToString("yyyyMMdd")}_{DateTime.Parse(txtWeekOfEnd.Text).ToString("yyyyMMdd")}.xls";
				strFullFileName = $"{strExcelDir}\\{strFileName}";

				if (File.Exists(strFullFileName))
				{

					if (MessageBox.Show($"Export File Already Exits.{Environment.NewLine}{Environment.NewLine}{strFileName}{Environment.NewLine}{Environment.NewLine}Overwrite?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
					{
						//UPGRADE_WARNING: (2081) DeleteFile has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
						File.Delete(strFullFileName);
					}

				} // If gfso.FileExists(strFullFileName) = True Then

				if (!File.Exists(strFullFileName))
				{

					if (modExcel.Create_Excel_File(ref objExcel, ref objExcelWB, ref objExcelWS, strFullFileName))
					{

						lExcelRow = 1;
						lExcelCol = 1;

						//UPGRADE_TODO: (1067) Member ScreenUpdating is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						objExcel.ScreenUpdating = false;
						Add_User_Overall_Time_Tracker_Headers(objExcel, objExcelWB, objExcelWS, ref lExcelRow, ref lExcelCol, strStart, strEnd);
						//UPGRADE_TODO: (1067) Member ScreenUpdating is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						objExcel.ScreenUpdating = true;

						lExcelMaxCol = lExcelCol;

						strQuery1 = "SELECT user_id, user_first_name, user_last_name, user_team_leader_team, user_default_account_id, ur_team_leader_team, ur_report_name ";
						strQuery1 = $"{strQuery1}FROM [User] WITH (NOLOCK) INNER JOIN User_Reports WITH (NOLOCK) ON ur_user_id = [user_id]";
						strQuery1 = $"{strQuery1}WHERE (user_team_leader_flag = 'Y') AND (user_password <> 'Inactive') ";
						strQuery1 = $"{strQuery1}AND (ur_active_flag = 'Y')  ORDER BY user_default_account_id, user_first_name ";

						rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
						rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

						if (!rstRec1.BOF && !rstRec1.EOF)
						{

							pBar.Maximum = rstRec1.RecordCount;
							pBar.Minimum = 0;
							pBar.Value = 0;
							pBar.Visible = true;

							do 
							{ // Loop Until rstRec1.EOF = True

								strTeamLeaderUserId = ($"{Convert.ToString(rstRec1["user_id"])} ").Trim();
								strTeamLeaderTeam = ($"{Convert.ToString(rstRec1["ur_team_leader_team"])} ").Trim();
								strReportName = ($"{Convert.ToString(rstRec1["ur_report_name"])} ").Trim();

								strFName = ($"{Convert.ToString(rstRec1["user_first_name"])} ").Trim();
								strLName = ($"{Convert.ToString(rstRec1["user_last_name"])} ").Trim();
								strUserName = $"{strFName} {strLName}";

								lblStatus.Text = $"{strMsg} - Team Leader: {strTeamLeaderUserId.ToUpper()} - {strUserName.ToUpper()}";
								Application.DoEvents();

								if (strTeamLeaderUserId != "")
								{
									//UPGRADE_TODO: (1067) Member ScreenUpdating is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcel.ScreenUpdating = false;
									Add_Team_Hours_To_Excel_File(objExcel, objExcelWB, objExcelWS, ref lExcelRow, ref lExcelCol, strTeamLeaderUserId, strTeamLeaderTeam, strReportName, strStart, strEnd);
									//UPGRADE_TODO: (1067) Member ScreenUpdating is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcel.ScreenUpdating = true;
								}

								pBar.Value = Convert.ToInt32(pBar.Value + 1);

								rstRec1.MoveNext();

							}
							while(!rstRec1.EOF);

							pBar.Value = Convert.ToInt32(pBar.Maximum);
							pBar.Visible = false;

						} // If rstRec1.BOF = False And rstRec1.EOF = False Then

						rstRec1.Close();

						//UPGRADE_TODO: (1067) Member ScreenUpdating is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						objExcel.ScreenUpdating = true;
						modExcel.Save_Excel_File(objExcel, objExcelWB, objExcelWS, strFullFileName);

					} // If Create_Excel_File(objExcel, objExcelWB, objExcelWS, strFullFileName) = True Then

				} // If gfso.FileExists(strFileName) = False Then

				strMsg = $"Finished Export Overall Time Tracker To Excel - Dates: {strStart} to {strEnd}";
				lblStatus.Text = strMsg;

				cmdOverallTimeTracker.Enabled = true;

				objExcelWS = null;
				objExcelWB = null;
				objExcel = null;
				rstRec1 = null;
				rstRec2 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("cmdOverallTimeTracker_Click_Error", excep.Message);
			}

		} // cmdOverallTimeTracker_Click

		private void cmdRunReport_Click(Object eventSender, EventArgs eventArgs)
		{

			DbConnection cntConn = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateConnection();

			string strTempTableName = "";
			string strTempTable = "";

			string strStartDate = "";
			string strEndDate = "";
			string strTimeRange = "";
			string strTeamLeaderUserId = "";
			string strTeamLeaderTeam = "";
			string strReportName = "";
			int iPos1 = 0;

			try
			{

				cmdRunReport.Enabled = false;

				if (modCommon.Open_Client_Side_Connection(ref cntConn))
				{

					strTempTableName = $"AcctRep_Report_Temp_Table_{modCommon.GetGUID()}";
					strTempTable = $"#{strTempTableName}";

					strStartDate = txtWeekOfStart.Text;
					strEndDate = txtWeekOfEnd.Text;

					strTeamLeaderUserId = cmbTeamLeader.Text;
					iPos1 = (strTeamLeaderUserId.IndexOf(" -") + 1);
					if (iPos1 > 0)
					{
						strTeamLeaderUserId = strTeamLeaderUserId.Substring(0, Math.Min(iPos1 - 1, strTeamLeaderUserId.Length));
					}
					else
					{
						strTeamLeaderUserId = "";
					}

					if (strTeamLeaderUserId != "")
					{

						strReportName = cmbReport.Text;

						if (strReportName != "")
						{

							modUserHoursWorked.Clear_UserHoursWorked_Private_Variables();

							strTeamLeaderTeam = modUserHoursWorked.Return_Team_Leaders_Team(strTeamLeaderUserId, strReportName);

							if (strTeamLeaderTeam != "")
							{

								strTimeRange = modCommon.Return_User_Report_Time_Range(strTeamLeaderUserId, strReportName);

								modUserHoursWorked.Set_UserHoursWorked_Private_Variables(strTempTable, strStartDate, strEndDate, strTimeRange, strTeamLeaderUserId, strTeamLeaderTeam, strReportName);

								modUserHoursWorked.Create_UserHoursWorked_General_User_Counts(cntConn, pBar, lblStatus);

								modUserHoursWorked.Create_UserHoursWorked_Report(cntConn, pBar, lblStatus);

								lblStatus.Text = $"Report - {strReportName} Has Been Completed";

							}
							else
							{
								lblStatus.Text = "Unable To Find Team Leaders - Team";
							} // If strTeamLeaderTeam <> "" Then

						}
						else
						{
							lblStatus.Text = "Unable To Find Report Name";
						} // If strReportName <> "" Then

					}
					else
					{
						lblStatus.Text = "Unable To Find Team Leader";
					} // If strTeamLeaderUserId <> "" Then

					modUserHoursWorked.Drop_Account_Rep_Activity_Report_Temp_Table(cntConn);

					modUserHoursWorked.Clear_UserHoursWorked_Private_Variables();

					UpgradeHelpers.DB.TransactionManager.DeEnlist(cntConn);
					cntConn.Close();

				}
				else
				{
					lblStatus.Text = "Unable To Open Client Side Connection";
				} // If Open_Client_Side_Connection(cntConn) = True Then

				cmdRunReport.Enabled = true;

				cntConn = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("cmdRunReport_Click_Error", excep.Message);
			}

		} // cmdRunReport_Click

		private void cmdSave_Click(Object eventSender, EventArgs eventArgs)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			int lRow1 = 0;
			int lCol1 = 0;
			bool bNoRecords = false;
			System.DateTime dtDate = DateTime.FromOADate(0);
			string strMsg = "";

			try
			{

				Calculate_Grid_Totals();

				dtDate = DateTime.Parse(txtWeekOfStart.Text);

				lRow1 = 0;

				do 
				{ // Loop Until dtDate > CDate(txtWeekOfEnd.Text)

					strQuery1 = $"SELECT * FROM User_Hours WHERE (uh_user_id = '{txtUserId.Text}') ";
					strQuery1 = $"{strQuery1}AND (uh_hours_date = '{dtDate.ToString("MM/dd/yyyy")}')  ORDER BY uh_hours_date";

					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);

					if (rstRec1.BOF && rstRec1.EOF)
					{
						rstRec1.AddNew();
						rstRec1["uh_user_id"] = txtUserId.Text;
						rstRec1["uh_hours_date"] = dtDate;
						rstRec1["uh_entry_user_id"] = modAdminCommon.gbl_User_ID;
					}

					rstRec1["uh_update_date"] = DateTime.Now;
					rstRec1["uh_update_user_id"] = modAdminCommon.gbl_User_ID;

					lRow1++;

					//-----------------------------------------------------

					rstRec1["uh_hours_research"] = Double.Parse(Convert.ToString(grdUserHours[lRow1, 1].Value));
					rstRec1["uh_hours_id"] = Double.Parse(Convert.ToString(grdUserHours[lRow1, 2].Value));
					rstRec1["uh_hours_pubs_pics"] = Double.Parse(Convert.ToString(grdUserHours[lRow1, 3].Value));
					rstRec1["uh_hours_projects"] = Double.Parse(Convert.ToString(grdUserHours[lRow1, 4].Value));
					rstRec1["uh_hours_trans"] = Double.Parse(Convert.ToString(grdUserHours[lRow1, 5].Value));
					rstRec1["uh_hours_specs"] = Double.Parse(Convert.ToString(grdUserHours[lRow1, 6].Value));
					rstRec1["uh_hours_frac"] = Double.Parse(Convert.ToString(grdUserHours[lRow1, 7].Value));
					rstRec1["uh_hours_yachts"] = Double.Parse(Convert.ToString(grdUserHours[lRow1, 8].Value));
					rstRec1["uh_hours_other_research"] = Double.Parse(Convert.ToString(grdUserHours[lRow1, 9].Value));

					//-----------------------------------------------------

					rstRec1["uh_hours_marketing"] = Double.Parse(Convert.ToString(grdUserHours[lRow1, 10].Value));
					rstRec1["uh_hours_train_meet"] = Double.Parse(Convert.ToString(grdUserHours[lRow1, 11].Value));
					rstRec1["uh_hours_scan_non_hb"] = Double.Parse(Convert.ToString(grdUserHours[lRow1, 12].Value));
					rstRec1["uh_hours_breaks"] = Double.Parse(Convert.ToString(grdUserHours[lRow1, 13].Value));
					rstRec1["uh_hours_tech"] = Double.Parse(Convert.ToString(grdUserHours[lRow1, 14].Value));
					rstRec1["uh_hours_paid_time_off"] = Double.Parse(Convert.ToString(grdUserHours[lRow1, 15].Value));

					//-----------------------------------------------------

					rstRec1["uh_hours_total_worked"] = Double.Parse(Convert.ToString(grdUserHours[lRow1, 16].Value));

					rstRec1.UpdateBatch();

					rstRec1.Close();

					dtDate = dtDate.AddDays(1);

				}
				while(dtDate <= DateTime.Parse(txtWeekOfEnd.Text));

				strMsg = $"Saved User Hours - UserId: [{txtUserId.Text}] Week Of: {txtWeekOfStart.Text} To {txtWeekOfEnd.Text}";
				lblStatus.Text = strMsg;

				modAdminCommon.Record_Event("User Hours", strMsg, 0, 0, 0, false, 0, 0);

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("cmdSave_Click_Error", excep.Message);
			}

		} // cmdSave_Click

		private void grdUserHours_Click(Object eventSender, EventArgs eventArgs)
		{


			int lRow1 = grdUserHours.MouseRow;
			int lCol1 = grdUserHours.MouseCol;

			Calculate_Grid_Totals();

			grdUserHours.CurrentRowIndex = lRow1;
			grdUserHours.CurrentColumnIndex = lCol1;

		} //grdUserHours_Click

		private void grdUserHours_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{


				int lRow1 = grdUserHours.MouseRow;
				int lCol1 = grdUserHours.MouseCol;

				//Debug.Print "KeyCode: " & CStr(KeyCode) & " Shift: " & CStr(Shift)

				if (lRow1 > 0)
				{

					if (lRow1 < 8)
					{

						if (lCol1 > 0)
						{

							if (lCol1 < 16)
							{


								// 46 = Delete Key

								if (KeyCode == 46)
								{

									if (grdUserHours[grdUserHours.CurrentRowIndex, grdUserHours.CurrentColumnIndex].FormattedValue.ToString() != "")
									{

										if (Strings.Len(grdUserHours[grdUserHours.CurrentRowIndex, grdUserHours.CurrentColumnIndex].FormattedValue.ToString()) >= 2)
										{
											grdUserHours[grdUserHours.CurrentRowIndex, grdUserHours.CurrentColumnIndex].Value = grdUserHours[grdUserHours.CurrentRowIndex, grdUserHours.CurrentColumnIndex].FormattedValue.ToString().Substring(Math.Min(1, grdUserHours[grdUserHours.CurrentRowIndex, grdUserHours.CurrentColumnIndex].FormattedValue.ToString().Length));
										}
										else
										{
											grdUserHours[grdUserHours.CurrentRowIndex, grdUserHours.CurrentColumnIndex].Value = "";
										}

									} // If .Text <> "" Then

								} // If KeyCode = 46 Then
								 // grdUserHours

							} // If lCol1 < 16 Then

						} // If lCol1 > 0 Then

					} // If lRow1 < 8 Then

				} // If lRow1 > 0 Then
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}

		} // grdUserHours_KeyDown

		private void grdUserHours_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{


				int lRow1 = grdUserHours.MouseRow;
				int lCol1 = grdUserHours.MouseCol;

				//Debug.Print "KeyAscii: " & CStr(KeyAscii)

				if (lRow1 > 0)
				{

					if (lRow1 < 8)
					{

						if (lCol1 > 0)
						{

							if (lCol1 < 16)
							{



								switch(KeyAscii)
								{
									case 8 :  //IF KEY IS BACKSPACE THEN 
										if (grdUserHours[grdUserHours.CurrentRowIndex, grdUserHours.CurrentColumnIndex].FormattedValue.ToString() != "")
										{
											grdUserHours[grdUserHours.CurrentRowIndex, grdUserHours.CurrentColumnIndex].Value = grdUserHours[grdUserHours.CurrentRowIndex, grdUserHours.CurrentColumnIndex].FormattedValue.ToString().Substring(0, Math.Min(Strings.Len(grdUserHours[grdUserHours.CurrentRowIndex, grdUserHours.CurrentColumnIndex].FormattedValue.ToString()) - 1, grdUserHours[grdUserHours.CurrentRowIndex, grdUserHours.CurrentColumnIndex].FormattedValue.ToString().Length));
										} 
										 
										break;
									case 13 : case 15 :  //IF KEY IS ENTER THEN 
										switch(grdUserHours.CurrentColumnIndex)
										{
											case 1 : case 2 : case 3 : case 4 : case 5 : case 6 : case 7 : case 8 : case 9 : case 10 : case 11 : case 12 : case 13 : case 14 : 
												grdUserHours.CurrentColumnIndex++; 
												break;
											case 15 :  // PTO - Paid Time Off 
												grdUserHours.CurrentColumnIndex = 1; 
												if (grdUserHours.CurrentRowIndex < 8)
												{
													grdUserHours.CurrentRowIndex++;
												} 
												break;
										} 
										 
										if (Information.IsNumeric(grdUserHours[grdUserHours.CurrentRowIndex, grdUserHours.CurrentColumnIndex].FormattedValue.ToString()))
										{
											grdUserHours[grdUserHours.CurrentRowIndex, grdUserHours.CurrentColumnIndex].Value = StringsHelper.Format(grdUserHours[grdUserHours.CurrentRowIndex, grdUserHours.CurrentColumnIndex].FormattedValue.ToString(), "#0.00");
										}
										else
										{
											MessageBox.Show("Text Entered Is NOT Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
											grdUserHours[grdUserHours.CurrentRowIndex, grdUserHours.CurrentColumnIndex].Value = "0.00";
										} 
										 
										Calculate_Grid_Totals(); 
										 
										break;
									case 32 :  // SPACE BLANK OUT FIELD 
										 
										grdUserHours[grdUserHours.CurrentRowIndex, grdUserHours.CurrentColumnIndex].Value = ""; 
										 
										break;
									default:
										//-------------------------- 
										// Must Be Numeric Only 
										if ((KeyAscii >= 48 && KeyAscii <= 57) || KeyAscii == 46)
										{
											if (KeyAscii == 46)
											{ // Period
												// Check To See If Already Exists
												if ((grdUserHours[grdUserHours.CurrentRowIndex, grdUserHours.CurrentColumnIndex].FormattedValue.ToString().IndexOf('.') + 1) == 0)
												{
													grdUserHours[grdUserHours.CurrentRowIndex, grdUserHours.CurrentColumnIndex].Value = $"{grdUserHours[grdUserHours.CurrentRowIndex, grdUserHours.CurrentColumnIndex].FormattedValue.ToString()}{Strings.Chr(KeyAscii).ToString()}";
												}
											}
											else
											{
												// Not A Period So Add It
												grdUserHours[grdUserHours.CurrentRowIndex, grdUserHours.CurrentColumnIndex].Value = $"{grdUserHours[grdUserHours.CurrentRowIndex, grdUserHours.CurrentColumnIndex].FormattedValue.ToString()}{Strings.Chr(KeyAscii).ToString()}";
											}
										}
										else
										{
											MessageBox.Show("Keypressed Is Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
										} 
										break;
								}

							} // If lCol1 < 16 Then

						} // If lCol1 > 0 Then

					} // If lRow1 < 8 Then

				} // If lRow1 > 0 Then
			}
			finally
			{
				if (KeyAscii == 0)
				{
					eventArgs.Handled = true;
				}
				eventArgs.KeyChar = Convert.ToChar(KeyAscii);
			}

		} // grdUserHours_KeyPress

		private void Fill_User_Hours_Grid_Data_Headers()
		{

			string strDayName = "";

			grdUserHours.Redraw = false;

			grdUserHours.RowsCount = 9;
			grdUserHours.ColumnsCount = 17;

			grdUserHours.FixedColumns = 0;
			grdUserHours.FixedRows = 0;

			System.DateTime dtStartDate = DateTime.Parse(txtWeekOfStart.Text);
			System.DateTime dtEndDate = DateTime.Parse(txtWeekOfEnd.Text);

			int lRow1 = 0;
			grdUserHours.CurrentRowIndex = lRow1;
			grdUserHours.SetRowHeight(lRow1, 43);

			//-----------------------------------------------------

			int lCol1 = 0;
			grdUserHours.CurrentColumnIndex = lCol1;
			grdUserHours.CellBackColor = iLtGrey;
			grdUserHours.CellForeColor = iBlack;
			grdUserHours.CellFontBold = true;
			grdUserHours.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grdUserHours.SetColumnWidth(lCol1, 80);
			grdUserHours[grdUserHours.CurrentRowIndex, grdUserHours.CurrentColumnIndex].Value = "Day";

			//-----------------------------------------------------

			lCol1++;
			grdUserHours.CurrentColumnIndex = lCol1;
			grdUserHours.CellBackColor = iVLtGreen;
			grdUserHours.CellForeColor = iBlack;
			grdUserHours.CellFontBold = true;
			grdUserHours.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grdUserHours.SetColumnWidth(lCol1, 57);
			grdUserHours[grdUserHours.CurrentRowIndex, grdUserHours.CurrentColumnIndex].Value = "RSCH";

			lCol1++;
			grdUserHours.CurrentColumnIndex = lCol1;
			grdUserHours.CellBackColor = iVLtGreen;
			grdUserHours.CellForeColor = iBlack;
			grdUserHours.CellFontBold = true;
			grdUserHours.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grdUserHours.SetColumnWidth(lCol1, 53);
			grdUserHours[grdUserHours.CurrentRowIndex, grdUserHours.CurrentColumnIndex].Value = "ID";

			lCol1++;
			grdUserHours.CurrentColumnIndex = lCol1;
			grdUserHours.CellBackColor = iVLtGreen;
			grdUserHours.CellForeColor = iBlack;
			grdUserHours.CellFontBold = true;
			grdUserHours.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grdUserHours.SetColumnWidth(lCol1, 70);
			grdUserHours[grdUserHours.CurrentRowIndex, grdUserHours.CurrentColumnIndex].Value = "Pubs/Pics";

			lCol1++;
			grdUserHours.CurrentColumnIndex = lCol1;
			grdUserHours.CellBackColor = iVLtGreen;
			grdUserHours.CellForeColor = iBlack;
			grdUserHours.CellFontBold = true;
			grdUserHours.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grdUserHours.SetColumnWidth(lCol1, 53);
			grdUserHours[grdUserHours.CurrentRowIndex, grdUserHours.CurrentColumnIndex].Value = "Projects";

			lCol1++;
			grdUserHours.CurrentColumnIndex = lCol1;
			grdUserHours.CellBackColor = iVLtGreen;
			grdUserHours.CellForeColor = iBlack;
			grdUserHours.CellFontBold = true;
			grdUserHours.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grdUserHours.SetColumnWidth(lCol1, 53);
			grdUserHours[grdUserHours.CurrentRowIndex, grdUserHours.CurrentColumnIndex].Value = "Trans";

			lCol1++;
			grdUserHours.CurrentColumnIndex = lCol1;
			grdUserHours.CellBackColor = iVLtGreen;
			grdUserHours.CellForeColor = iBlack;
			grdUserHours.CellFontBold = true;
			grdUserHours.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grdUserHours.SetColumnWidth(lCol1, 53);
			grdUserHours[grdUserHours.CurrentRowIndex, grdUserHours.CurrentColumnIndex].Value = "Specs";

			lCol1++;
			grdUserHours.CurrentColumnIndex = lCol1;
			grdUserHours.CellBackColor = iVLtGreen;
			grdUserHours.CellForeColor = iBlack;
			grdUserHours.CellFontBold = true;
			grdUserHours.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grdUserHours.SetColumnWidth(lCol1, 47);
			grdUserHours[grdUserHours.CurrentRowIndex, grdUserHours.CurrentColumnIndex].Value = "Frac";

			lCol1++;
			grdUserHours.CurrentColumnIndex = lCol1;
			grdUserHours.CellBackColor = iVLtGreen;
			grdUserHours.CellForeColor = iBlack;
			grdUserHours.CellFontBold = true;
			grdUserHours.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grdUserHours.SetColumnWidth(lCol1, 63);
			grdUserHours[grdUserHours.CurrentRowIndex, grdUserHours.CurrentColumnIndex].Value = "ADSB-X"; // changed from yachts- 10/19/23

			lCol1++;
			grdUserHours.CurrentColumnIndex = lCol1;
			grdUserHours.CellBackColor = iVLtGreen;
			grdUserHours.CellForeColor = iBlack;
			grdUserHours.CellFontBold = true;
			grdUserHours.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grdUserHours.SetColumnWidth(lCol1, 50);
			grdUserHours[grdUserHours.CurrentRowIndex, grdUserHours.CurrentColumnIndex].Value = "OT"; // changed from this "Other" & vbCrLf & "RSCH"

			//-----------------------------------------------------

			lCol1++;
			grdUserHours.CurrentColumnIndex = lCol1;
			grdUserHours.CellBackColor = iLtRed;
			grdUserHours.CellForeColor = iBlack;
			grdUserHours.CellFontBold = true;
			grdUserHours.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grdUserHours.SetColumnWidth(lCol1, 47);
			grdUserHours[grdUserHours.CurrentRowIndex, grdUserHours.CurrentColumnIndex].Value = "Mktg";

			lCol1++;
			grdUserHours.CurrentColumnIndex = lCol1;
			grdUserHours.CellBackColor = iLtRed;
			grdUserHours.CellForeColor = iBlack;
			grdUserHours.CellFontBold = true;
			grdUserHours.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grdUserHours.SetColumnWidth(lCol1, 60);
			grdUserHours[grdUserHours.CurrentRowIndex, grdUserHours.CurrentColumnIndex].Value = $"Train{Environment.NewLine}Meet";

			lCol1++;
			grdUserHours.CurrentColumnIndex = lCol1;
			grdUserHours.CellBackColor = iLtRed;
			grdUserHours.CellForeColor = iBlack;
			grdUserHours.CellFontBold = true;
			grdUserHours.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grdUserHours.SetColumnWidth(lCol1, 70);
			grdUserHours[grdUserHours.CurrentRowIndex, grdUserHours.CurrentColumnIndex].Value = $"Scan{Environment.NewLine}Non HB";

			lCol1++;
			grdUserHours.CurrentColumnIndex = lCol1;
			grdUserHours.CellBackColor = iLtRed;
			grdUserHours.CellForeColor = iBlack;
			grdUserHours.CellFontBold = true;
			grdUserHours.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grdUserHours.SetColumnWidth(lCol1, 47);
			grdUserHours[grdUserHours.CurrentRowIndex, grdUserHours.CurrentColumnIndex].Value = "Break";

			lCol1++;
			grdUserHours.CurrentColumnIndex = lCol1;
			grdUserHours.CellBackColor = iLtRed;
			grdUserHours.CellForeColor = iBlack;
			grdUserHours.CellFontBold = true;
			grdUserHours.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grdUserHours.SetColumnWidth(lCol1, 47);
			grdUserHours[grdUserHours.CurrentRowIndex, grdUserHours.CurrentColumnIndex].Value = "Tech";

			lCol1++;
			grdUserHours.CurrentColumnIndex = lCol1;
			grdUserHours.CellBackColor = iLtRed;
			grdUserHours.CellForeColor = iBlack;
			grdUserHours.CellFontBold = true;
			grdUserHours.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grdUserHours.SetColumnWidth(lCol1, 47);
			grdUserHours[grdUserHours.CurrentRowIndex, grdUserHours.CurrentColumnIndex].Value = "PTO";


			lCol1++;
			grdUserHours.CurrentColumnIndex = lCol1;
			grdUserHours.CellBackColor = iYellow;
			grdUserHours.CellForeColor = iBlack;
			grdUserHours.CellFontBold = true;
			grdUserHours.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grdUserHours.SetColumnWidth(lCol1, 60);
			grdUserHours[grdUserHours.CurrentRowIndex, grdUserHours.CurrentColumnIndex].Value = $"Total{Environment.NewLine}Paid{Environment.NewLine}Time";

			lCol1 = 0;
			grdUserHours.CurrentColumnIndex = lCol1;

			System.DateTime dtDate = dtStartDate;
			do 
			{

				strDayName = DateTimeFormatInfo.CurrentInfo.GetDayName((DayOfWeek) (DateAndTime.Weekday(dtDate) - 1));

				lRow1++;
				grdUserHours.CurrentRowIndex = lRow1;
				grdUserHours.CellBackColor = iLtGrey;
				grdUserHours.SetRowHeight(lRow1, 33);

				switch(strDayName)
				{
					case "Saturday" : case "Sunday" : 
						grdUserHours.CellForeColor = iRed; 
						if (chkIncludeSatSun.CheckState == CheckState.Unchecked)
						{
							grdUserHours.SetRowHeight(lRow1, 0);
						} 
						break;
					default:
						grdUserHours.CellForeColor = iBlack; 
						 
						break;
				} // Case strDayName

				grdUserHours.CellFontBold = true;
				grdUserHours.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
				grdUserHours[grdUserHours.CurrentRowIndex, grdUserHours.CurrentColumnIndex].Value = $"{strDayName}{Environment.NewLine}({dtDate.ToString("MM/dd")})";
				dtDate = dtDate.AddDays(1);

			}
			while(dtDate <= dtEndDate);

			lRow1++;
			grdUserHours.CurrentRowIndex = lRow1;
			grdUserHours.CellBackColor = iDkGrey;
			grdUserHours.CellForeColor = iBlack;
			grdUserHours.CellFontBold = true;
			grdUserHours.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			grdUserHours[grdUserHours.CurrentRowIndex, grdUserHours.CurrentColumnIndex].Value = "Total";

			for (lRow1 = 1; lRow1 <= 8; lRow1++)
			{
				for (lCol1 = 1; lCol1 <= 16; lCol1++)
				{
					grdUserHours.CurrentRowIndex = lRow1;
					grdUserHours.CurrentColumnIndex = lCol1;
					if (lRow1 != 8 && lCol1 != 16)
					{
						grdUserHours.CellBackColor = iWhite;
						grdUserHours.CellForeColor = iBlack;
					}
					grdUserHours.CellAlignment = DataGridViewContentAlignment.MiddleRight;
					grdUserHours[lRow1, lCol1].Value = "0.00";
				}
			}

			grdUserHours.CurrentRowIndex = 1;
			grdUserHours.CurrentColumnIndex = 1;

			grdUserHours.FixedColumns = 1;
			grdUserHours.FixedRows = 1;


		} // Fill_User_Hours_Grid_Data_Headers

		private void Fill_User_Hours_Grid_Data()
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			int lRow1 = 0;
			int lCol1 = 0;

			try
			{

				Fill_User_Hours_Grid_Data_Headers();

				strQuery1 = $"SELECT * FROM User_Hours WITH (NOLOCK) WHERE (uh_user_id = '{txtUserId.Text}') ";
				strQuery1 = $"{strQuery1}AND (uh_hours_date BETWEEN '{txtWeekOfStart.Text}' AND '{txtWeekOfEnd.Text}') ";
				strQuery1 = $"{strQuery1}ORDER BY uh_hours_date";

				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					grdUserHours.Redraw = false;

					lRow1 = 0;
					do 
					{ // Loop Until rstRec1.EOF = True

						lRow1++;

						// RSCH
						lCol1 = 1;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["uh_hours_research"]))
						{
							grdUserHours[lRow1, lCol1].Value = StringsHelper.Format(rstRec1["uh_hours_research"], "#0.00");
						}

						// ID
						lCol1++;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["uh_hours_id"]))
						{
							grdUserHours[lRow1, lCol1].Value = StringsHelper.Format(rstRec1["uh_hours_id"], "#0.00");
						}

						// Pubs/Pics
						lCol1++;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["uh_hours_pubs_pics"]))
						{
							grdUserHours[lRow1, lCol1].Value = StringsHelper.Format(rstRec1["uh_hours_pubs_pics"], "#0.00");
						}

						// Projects
						lCol1++;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["uh_hours_projects"]))
						{
							grdUserHours[lRow1, lCol1].Value = StringsHelper.Format(rstRec1["uh_hours_projects"], "#0.00");
						}

						// Transactions
						lCol1++;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["uh_hours_trans"]))
						{
							grdUserHours[lRow1, lCol1].Value = StringsHelper.Format(rstRec1["uh_hours_trans"], "#0.00");
						}

						// Specs
						lCol1++;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["uh_hours_specs"]))
						{
							grdUserHours[lRow1, lCol1].Value = StringsHelper.Format(rstRec1["uh_hours_specs"], "#0.00");
						}

						lCol1++;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["uh_hours_frac"]))
						{
							grdUserHours[lRow1, lCol1].Value = StringsHelper.Format(rstRec1["uh_hours_frac"], "#0.00");
						}

						lCol1++;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["uh_hours_yachts"]))
						{
							grdUserHours[lRow1, lCol1].Value = StringsHelper.Format(rstRec1["uh_hours_yachts"], "#0.00");
						}

						lCol1++;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["uh_hours_other_research"]))
						{
							grdUserHours[lRow1, lCol1].Value = StringsHelper.Format(rstRec1["uh_hours_other_research"], "#0.00");
						}

						lCol1++;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["uh_hours_marketing"]))
						{
							grdUserHours[lRow1, lCol1].Value = StringsHelper.Format(rstRec1["uh_hours_marketing"], "#0.00");
						}

						lCol1++;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["uh_hours_train_meet"]))
						{
							grdUserHours[lRow1, lCol1].Value = StringsHelper.Format(rstRec1["uh_hours_train_meet"], "#0.00");
						}

						lCol1++;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["uh_hours_scan_non_hb"]))
						{
							grdUserHours[lRow1, lCol1].Value = StringsHelper.Format(rstRec1["uh_hours_scan_non_hb"], "#0.00");
						}

						lCol1++;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["uh_hours_breaks"]))
						{
							grdUserHours[lRow1, lCol1].Value = StringsHelper.Format(rstRec1["uh_hours_breaks"], "#0.00");
						}

						lCol1++;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["uh_hours_tech"]))
						{
							grdUserHours[lRow1, lCol1].Value = StringsHelper.Format(rstRec1["uh_hours_tech"], "#0.00");
						}

						lCol1++;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["uh_hours_paid_time_off"]))
						{
							grdUserHours[lRow1, lCol1].Value = StringsHelper.Format(rstRec1["uh_hours_paid_time_off"], "#0.00");
						}

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);


				} // If rstRec1.BOF = False And rstRec1.EOF = False Then

				rstRec1.Close();

				Calculate_Grid_Totals();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Fill_User_Hours_Grid_Data_Error", excep.Message);
			}

		} // Fill_User_Hours_Grid_Data

		//UPGRADE_WARNING: (2050) MSComCtl2.MonthView Event calWeekOf.DateClick was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2050
		private void calWeekOf_DateClick(System.DateTime DateClicked)
		{

			System.DateTime dtMonday = DateTime.FromOADate(0);
			System.DateTime dtSunday = DateTime.FromOADate(0);
			System.DateTime dtSaturday = DateTime.FromOADate(0);

			System.DateTime dtDate = DateClicked;

			modCommon.ReturnSunSatDateRange(dtDate, ref dtSunday, ref dtSaturday, ref dtMonday);

			txtWeekOfStart.Text = dtMonday.ToString("MM/dd/yyyy");
			txtWeekOfEnd.Text = dtSunday.ToString("MM/dd/yyyy");

			modUserHoursWorked.Set_UserHoursWorked_Private_Start_End_Dates(txtWeekOfStart.Text, txtWeekOfEnd.Text);

			Fill_User_Hours_Grid_Data();

		} // calWeekOf_DateClick

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
		private void Form_Load()
		{

			System.DateTime dtSunday = DateTime.FromOADate(0);
			System.DateTime dtSaturday = DateTime.FromOADate(0);
			System.DateTime dtMonday = DateTime.FromOADate(0);

			modCommon.Start_Activity_Monitor_Message("Open User Hours", ref strMsg, ref dtStartDate, ref dtEndDate);

			frmReports.Visible = false;
			cmdRunReport.Enabled = false;
			txtUserId.Enabled = false;
			lblExportToExcel.Enabled = false;
			lblExportToExcel.Visible = false;


			switch(modAdminCommon.gbl_User_ID.ToUpper())
			{
				case "AJA" : case "DCR" : case "MVIT" : 
					lblExportToExcel.Enabled = true; 
					lblExportToExcel.Visible = true; 
					 
					break;
			} // Case

			txtUserId.Text = modAdminCommon.gbl_User_ID.ToUpper();
			txtUserName.Text = ($"{($"{Convert.ToString(modAdminCommon.snp_User["user_first_name"])} ").Trim()} {($"{Convert.ToString(modAdminCommon.snp_User["user_last_name"])} ").Trim()}").ToUpper();

			System.DateTime dtDate = DateTime.Now;
			calWeekOf.SetDate(dtDate);

			modCommon.ReturnSunSatDateRange(dtDate, ref dtSunday, ref dtSaturday, ref dtMonday);

			txtWeekOfStart.Text = dtMonday.ToString("MM/dd/yyyy");
			txtWeekOfEnd.Text = dtSunday.ToString("MM/dd/yyyy");

			modUserHoursWorked.Set_UserHoursWorked_Private_Start_End_Dates(txtWeekOfStart.Text, txtWeekOfEnd.Text);

			modUserHoursWorked.Load_Team_Leader_Combo_Box(cmbTeamLeader);

			modUserHoursWorked.Load_Report_Combo_Box(cmbReport);

			Load_New_User();

			if (Convert.ToString(modAdminCommon.snp_User["user_user_report_flag"]) == "Y")
			{
				txtUserId.Enabled = true;
				txtWeekOfStart.Enabled = true;
				txtWeekOfEnd.Enabled = true;
				frmReports.Visible = true;
			}

			modCommon.End_Activity_Monitor_Message("Open User Hours", ref strMsg, dtStartDate, ref dtEndDate, 0, 0, 0, 0, 0);

			modAdminCommon.Record_Event("User Hours", "Load User Hour Form, 0, 0, 0, False, 0, 0");

		} // Form_Load

		private void Add_User_Overall_Time_Tracker_Headers(ExcelApplication oExcel, ExcelApplication oExcelWB, ExcelApplication oExcelWS, ref int lExcelRow, ref int lExcelCol, string strStart, string strEnd)
		{


			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).Interior.ColorIndex = modExcel.xlGray15;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).VerticalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol)[lExcelRow, lExcelCol] = $"Date: {strStart} To {strEnd}";
			modExcel.Merge_Cells(oExcel, oExcelWB, oExcelWS, lExcelRow, lExcelCol, lExcelRow, lExcelCol + 2);

			lExcelRow++;
			//UPGRADE_TODO: (1067) Member Rows is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Rows(lExcelRow).RowHeight = 40;

			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).Interior.ColorIndex = modExcel.xlGray15;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).VerticalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Columns is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Columns(lExcelCol).ColumnWidth = 15;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol)[lExcelRow, lExcelCol] = "Last Name";

			lExcelCol++;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).Interior.ColorIndex = modExcel.xlGray15;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).VerticalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Columns is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Columns(lExcelCol).ColumnWidth = 15;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol)[lExcelRow, lExcelCol] = "First Name";

			lExcelCol++;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).Interior.ColorIndex = modExcel.xlGray15;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).VerticalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol)[lExcelRow, lExcelCol] = "Pos";


			lExcelCol++;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).Interior.ColorIndex = modExcel.xlBrightGreen;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).VerticalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol)[lExcelRow, lExcelCol] = "RSCH";

			lExcelCol++;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).Interior.ColorIndex = modExcel.xlBrightGreen;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).VerticalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol)[lExcelRow, lExcelCol] = "ID";

			lExcelCol++;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).Interior.ColorIndex = modExcel.xlBrightGreen;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).VerticalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Columns is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Columns(lExcelCol).ColumnWidth = 10;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol)[lExcelRow, lExcelCol] = "Pubs/Pics";

			lExcelCol++;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).Interior.ColorIndex = modExcel.xlBrightGreen;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).VerticalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol)[lExcelRow, lExcelCol] = "Projects";

			lExcelCol++;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).Interior.ColorIndex = modExcel.xlBrightGreen;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).VerticalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol)[lExcelRow, lExcelCol] = "Trans";

			lExcelCol++;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).Interior.ColorIndex = modExcel.xlBrightGreen;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).VerticalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol)[lExcelRow, lExcelCol] = "Specs";

			lExcelCol++;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).Interior.ColorIndex = modExcel.xlBrightGreen;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).VerticalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol)[lExcelRow, lExcelCol] = "Frac";

			lExcelCol++;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).Interior.ColorIndex = modExcel.xlBrightGreen;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).VerticalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Columns is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Columns(lExcelCol).ColumnWidth = 12;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol)[lExcelRow, lExcelCol] = "ADSB-X"; // changed from yachts - 10/20/23

			lExcelCol++;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).Interior.ColorIndex = modExcel.xlBrightGreen;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).VerticalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Columns is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Columns(lExcelCol).ColumnWidth = 12;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol)[lExcelRow, lExcelCol] = "OT"; //

			lExcelCol++;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).Interior.ColorIndex = modExcel.xlRose;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).VerticalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol)[lExcelRow, lExcelCol] = "Mktg";

			lExcelCol++;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).Interior.ColorIndex = modExcel.xlRose;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).VerticalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Columns is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Columns(lExcelCol).ColumnWidth = 11;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol)[lExcelRow, lExcelCol] = "Train/Meet";

			lExcelCol++;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).Interior.ColorIndex = modExcel.xlRose;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).VerticalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Columns is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Columns(lExcelCol).ColumnWidth = 12;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol)[lExcelRow, lExcelCol] = "Scan/Non HB";

			lExcelCol++;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).Interior.ColorIndex = modExcel.xlRose;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).VerticalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol)[lExcelRow, lExcelCol] = "Breaks";

			lExcelCol++;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).Interior.ColorIndex = modExcel.xlRose;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).VerticalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol)[lExcelRow, lExcelCol] = "Tech";

			lExcelCol++;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).Interior.ColorIndex = modExcel.xlRose;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).VerticalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol)[lExcelRow, lExcelCol] = "PTO";


			lExcelCol++;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).Interior.ColorIndex = modExcel.xlYellow27;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).VerticalAlignment = modExcel.xlCenter;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol)[lExcelRow, lExcelCol] = "Total";

			string strRange = modExcel.ConvertRowColumnToExcelRange(lExcelRow, 1, lExcelRow, lExcelCol);

			modExcel.DrawGrid(oExcel, strRange);

		} // Add_User_Overall_Time_Tracker_Headers

		private void Add_Individual_Hours_To_Excel(ExcelApplication oExcel, ExcelApplication oExcelWB, ExcelApplication oExcelWS, ref int lExcelRow, ref int lExcelCol, string strUserId, string strFName, string strLName, string strAcctRep, string strStart, string strEnd, int iColor)
		{
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			int iPos1 = 0;
			double dTotalWorked = 0;
			double dTotalActivity = 0;

			try
			{

				strUserId = strUserId.Trim();

				if (strUserId != "")
				{

					lExcelRow++;
					lExcelCol = 0;

					lExcelCol++;
					//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					oExcelWS.Cells(lExcelRow, lExcelCol).Interior.ColorIndex = iColor;
					//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					oExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlLeft;
					//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					oExcelWS.Cells(lExcelRow, lExcelCol).VerticalAlignment = modExcel.xlCenter;
					//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					oExcelWS.Cells(lExcelRow, lExcelCol)[lExcelRow, lExcelCol] = strLName.ToUpper();

					lExcelCol++;
					//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					oExcelWS.Cells(lExcelRow, lExcelCol).Interior.ColorIndex = iColor;
					//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					oExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlLeft;
					//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					oExcelWS.Cells(lExcelRow, lExcelCol).VerticalAlignment = modExcel.xlCenter;
					//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					oExcelWS.Cells(lExcelRow, lExcelCol)[lExcelRow, lExcelCol] = strFName.ToUpper();

					lExcelCol++;
					//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					oExcelWS.Cells(lExcelRow, lExcelCol).Interior.ColorIndex = modExcel.xlWhite;
					//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					oExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlCenter;
					//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					oExcelWS.Cells(lExcelRow, lExcelCol).VerticalAlignment = modExcel.xlCenter;
					//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					oExcelWS.Cells(lExcelRow, lExcelCol)[lExcelRow, lExcelCol] = strAcctRep.ToUpper();

					strQuery1 = "SELECT [user_id] As UserId,  user_first_name As FName, user_last_name As LName, user_default_account_id As AcctRep, ";

					strQuery1 = $"{strQuery1}SUM(uh_hours_research) As TotRSCH,  SUM(uh_hours_id) As TotID, ";
					strQuery1 = $"{strQuery1}SUM(uh_hours_pubs_pics) As TotPubsPics, SUM(uh_hours_projects) As TotProjects, ";
					strQuery1 = $"{strQuery1}SUM(uh_hours_trans) As TotTrans, SUM(uh_hours_specs) As TotSpecs, ";
					strQuery1 = $"{strQuery1}SUM(uh_hours_frac) As TotFrac, SUM(uh_hours_yachts) As TotYachts, SUM(uh_hours_other_research) As TotOtherRSCH, ";

					strQuery1 = $"{strQuery1}SUM(uh_hours_marketing) As TotMarketing, SUM(uh_hours_train_meet) As TotTrainMeet, ";
					strQuery1 = $"{strQuery1}SUM(uh_hours_scan_non_hb) As TotScanNonHB, SUM(uh_hours_breaks) As TotBreaks, ";
					strQuery1 = $"{strQuery1}SUM(uh_hours_tech) As TotTech, SUM(uh_hours_paid_time_off) As TotPTO, SUM(uh_hours_total_worked) As TotWorked ";

					strQuery1 = $"{strQuery1}FROM [User] WITH (NOLOCK) INNER JOIN User_Hours WITH (NOLOCK) ON uh_user_id = [user_id] ";

					strQuery1 = $"{strQuery1}WHERE (uh_user_id = '{strUserId}') AND (uh_hours_date BETWEEN '{strStart}' AND '{strEnd}') ";
					strQuery1 = $"{strQuery1}GROUP BY user_id, user_first_name, user_last_name, user_default_account_id ";

					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						//------------------------------------------------------------------

						modExcel.Add_Number_To_Excel(oExcelWS, lExcelRow, ref lExcelCol, Convert.ToDouble(rstRec1["TotRSCH"]), modExcel.xlWhite, "#0.00");
						modExcel.Add_Number_To_Excel(oExcelWS, lExcelRow, ref lExcelCol, Convert.ToDouble(rstRec1["TotID"]), modExcel.xlWhite, "#0.00");
						modExcel.Add_Number_To_Excel(oExcelWS, lExcelRow, ref lExcelCol, Convert.ToDouble(rstRec1["TotPubsPics"]), modExcel.xlWhite, "#0.00");
						modExcel.Add_Number_To_Excel(oExcelWS, lExcelRow, ref lExcelCol, Convert.ToDouble(rstRec1["TotProjects"]), modExcel.xlWhite, "#0.00");
						modExcel.Add_Number_To_Excel(oExcelWS, lExcelRow, ref lExcelCol, Convert.ToDouble(rstRec1["TotTrans"]), modExcel.xlWhite, "#0.00");
						modExcel.Add_Number_To_Excel(oExcelWS, lExcelRow, ref lExcelCol, Convert.ToDouble(rstRec1["TotSpecs"]), modExcel.xlWhite, "#0.00");
						modExcel.Add_Number_To_Excel(oExcelWS, lExcelRow, ref lExcelCol, Convert.ToDouble(rstRec1["TotFrac"]), modExcel.xlWhite, "#0.00");
						modExcel.Add_Number_To_Excel(oExcelWS, lExcelRow, ref lExcelCol, Convert.ToDouble(rstRec1["TotYachts"]), modExcel.xlWhite, "#0.00");
						modExcel.Add_Number_To_Excel(oExcelWS, lExcelRow, ref lExcelCol, Convert.ToDouble(rstRec1["TotOtherRSCH"]), modExcel.xlWhite, "#0.00");

						//------------------------------------------------------------------

						modExcel.Add_Number_To_Excel(oExcelWS, lExcelRow, ref lExcelCol, Convert.ToDouble(rstRec1["TotMarketing"]), modExcel.xlWhite, "#0.00");
						modExcel.Add_Number_To_Excel(oExcelWS, lExcelRow, ref lExcelCol, Convert.ToDouble(rstRec1["TotTrainMeet"]), modExcel.xlWhite, "#0.00");
						modExcel.Add_Number_To_Excel(oExcelWS, lExcelRow, ref lExcelCol, Convert.ToDouble(rstRec1["TotScanNonHB"]), modExcel.xlWhite, "#0.00");
						modExcel.Add_Number_To_Excel(oExcelWS, lExcelRow, ref lExcelCol, Convert.ToDouble(rstRec1["TotBreaks"]), modExcel.xlWhite, "#0.00");
						modExcel.Add_Number_To_Excel(oExcelWS, lExcelRow, ref lExcelCol, Convert.ToDouble(rstRec1["TotTech"]), modExcel.xlWhite, "#0.00");
						modExcel.Add_Number_To_Excel(oExcelWS, lExcelRow, ref lExcelCol, Convert.ToDouble(rstRec1["TotPTO"]), modExcel.xlWhite, "#0.00");

						//------------------------------------------------------------------

						//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
						//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
						//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
						//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
						//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
						//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
						//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
						//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
						//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
						//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
						//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
						//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
						//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
						//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
						dTotalWorked = Convert.ToDouble(Convert.ToDouble(Convert.ToDouble(Convert.ToDouble(Convert.ToDouble(Convert.ToDouble(Convert.ToDouble(Convert.ToDouble(Convert.ToDouble(Convert.ToDouble(Convert.ToDouble(Convert.ToDouble(Convert.ToDouble(Convert.ToDouble(Convert.ToDouble(rstRec1["TotRSCH"]) + Convert.ToDouble(rstRec1["TotID"])) + Convert.ToDouble(rstRec1["TotPubsPics"])) + Convert.ToDouble(rstRec1["TotProjects"])) + Convert.ToDouble(rstRec1["TotTrans"])) + Convert.ToDouble(rstRec1["TotSpecs"])) + Convert.ToDouble(rstRec1["TotFrac"])) + Convert.ToDouble(rstRec1["TotYachts"])) + Convert.ToDouble(rstRec1["TotOtherRSCH"])) + Convert.ToDouble(rstRec1["TotMarketing"])) + Convert.ToDouble(rstRec1["TotTrainMeet"])) + Convert.ToDouble(rstRec1["TotScanNonHB"])) + Convert.ToDouble(rstRec1["TotBreaks"])) + Convert.ToDouble(rstRec1["TotTech"])) + Convert.ToDouble(rstRec1["TotPTO"]));

						modExcel.Add_Number_To_Excel(oExcelWS, lExcelRow, ref lExcelCol, dTotalWorked, modExcel.xlBrightGreen, "#0.00");

					}
					else
					{

						for (int lCnt1 = 3; lCnt1 <= 17; lCnt1++)
						{
							modExcel.Add_Number_To_Excel(oExcelWS, lExcelRow, ref lExcelCol, 0, modExcel.xlWhite, "#0.00");
						}
						modExcel.Add_Number_To_Excel(oExcelWS, lExcelRow, ref lExcelCol, 0, modExcel.xlBrightGreen, "#0.00");

					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

				} // If strUserId <> "" Then

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Add_Individual_Hours_To_Excel_Error", excep.Message);
			}

		} // Add_Individual_Hours_To_Excel

		private void Add_Team_Hours_To_Excel_File(ExcelApplication oExcel, ExcelApplication oExcelWB, ExcelApplication oExcelWS, ref int lExcelRow, ref int lExcelCol, string strTeamLeaderUserId, string strTeamLeaderTeam, string strReportName, string strStart, string strEnd)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strInUserId = "";
			string strUserId = "";
			string strFName = "";
			string strLName = "";
			string strAcctRep = "";
			string strRange = "";

			int lStartRow = 0;
			int lMaxCol = 0;

			try
			{

				lStartRow = lExcelRow + 1;

				if (strTeamLeaderTeam != "")
				{
					strInUserId = $"{strTeamLeaderTeam},{strTeamLeaderUserId}";
				}
				else
				{
					strInUserId = strTeamLeaderUserId;
				}
				strInUserId = StringsHelper.Replace(strInUserId, " ", "", 1, -1, CompareMethod.Binary);
				strInUserId = $"'{StringsHelper.Replace(strInUserId, ",", "','", 1, -1, CompareMethod.Binary)}'";

				strQuery1 = "SELECT user_id, user_first_name, user_last_name, user_default_account_id ";
				strQuery1 = $"{strQuery1}FROM [User] WITH (NOLOCK) WHERE (user_id IN ({strInUserId})) ";
				strQuery1 = $"{strQuery1}AND (user_password <> 'Inactive') ORDER BY user_team_leader_flag, user_default_account_id, user_first_name ";

				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					do 
					{ // Loop Until rstRec1.EOF = True

						strUserId = ($"{Convert.ToString(rstRec1["user_id"])} ").Trim();
						strFName = ($"{Convert.ToString(rstRec1["user_first_name"])} ").Trim();
						strLName = ($"{Convert.ToString(rstRec1["user_last_name"])} ").Trim();
						strAcctRep = ($"{Convert.ToString(rstRec1["user_default_account_id"])} ").Trim();

						if (strUserId != strTeamLeaderUserId)
						{
							Add_Individual_Hours_To_Excel(oExcel, oExcelWB, oExcelWS, ref lExcelRow, ref lExcelCol, strUserId, strFName, strLName, strAcctRep, strStart, strEnd, modExcel.xlGold);
						}
						else
						{
							Add_Individual_Hours_To_Excel(oExcel, oExcelWB, oExcelWS, ref lExcelRow, ref lExcelCol, strUserId, strFName, strLName, strAcctRep, strStart, strEnd, modExcel.xlWhite);
						}

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

					lMaxCol = lExcelCol;

				} // If rstRec1.BOF = False And rstRec1.EOF = False Then

				rstRec1.Close();

				strRange = modExcel.ConvertRowColumnToExcelRange(lStartRow, 1, lExcelRow, lExcelCol);

				modExcel.DrawGrid(oExcel, strRange);

				//---------------------------------------------------
				// Now Add Report Name 1st two cells
				lExcelRow++;
				lExcelCol = 1;

				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol).Interior.ColorIndex = modExcel.xlYellow27;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = modExcel.xlLeft;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol).VerticalAlignment = modExcel.xlCenter;
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol)[lExcelRow, lExcelCol] = strReportName;

				modExcel.Merge_Cells(oExcel, oExcelWB, oExcelWS, lExcelRow, lExcelCol, lExcelRow, lExcelCol + 1);

				strRange = modExcel.ConvertRowColumnToExcelRange(lExcelRow, 1, lExcelRow, 2);

				modExcel.DrawGrid(oExcel, strRange);

				modExcel.Add_Seperator_Line_To_Excel(oExcel, oExcelWB, oExcelWS, ref lExcelRow, lMaxCol, modExcel.xlGray15);

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Add_Team_Hours_To_Excel_File_Error", excep.Message);
			}

		} // Add_Team_Hours_To_Excel_File

		private void lblExportToExcel_Click(Object eventSender, EventArgs eventArgs)
		{

			lblExportToExcel.Enabled = false;
			modExcel.ExportMSHFlexGrid(grdUserHours);
			lblExportToExcel.Enabled = true;

		} // lblExportToExcel_Click

		private void Load_New_User()
		{

			txtUserId.Text = txtUserId.Text.ToUpper();
			txtUserName.Text = modCommon.GetFullUserName(txtUserId.Text).ToUpper();

			if (txtUserName.Text != "")
			{
				cmdSave.Enabled = true;
				lblStatus.Text = $" Loaded Hours For {txtUserName.Text}";
				Application.DoEvents();
				Fill_User_Hours_Grid_Data();
			}
			else
			{
				cmdSave.Enabled = false;
				lblStatus.Text = $" Could NOT Find User Name For UserId [{txtUserId.Text}]";
				Fill_User_Hours_Grid_Data_Headers();
			}

		} // Load_New_User

		private void txtUserId_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{

				if (KeyAscii == Strings.Asc("\r"[0]))
				{
					Load_New_User();
				}
			}
			finally
			{
				if (KeyAscii == 0)
				{
					eventArgs.Handled = true;
				}
				eventArgs.KeyChar = Convert.ToChar(KeyAscii);
			}

		} // txtUserId_KeyPress

		private void txtUserId_Leave(Object eventSender, EventArgs eventArgs) => Load_New_User();
		 // txtUserId_LostFocus

		private void txtWeekOfStart_Leave(Object eventSender, EventArgs eventArgs)
		{


			string strStartDate = txtWeekOfStart.Text;
			string strEndDate = txtWeekOfEnd.Text;

			string gstrStartDate = modUserHoursWorked.Get_UserHoursWorked_Private_Start_Date();

			if (!Information.IsDate(strStartDate))
			{
				MessageBox.Show($"Invalid Start Date [{strStartDate}]{Environment.NewLine}{Environment.NewLine}Please Re-Enter", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtWeekOfStart.Text = gstrStartDate;
			}
			else
			{
				if (DateTime.Parse(strStartDate) > DateTime.Parse(strEndDate))
				{
					MessageBox.Show($"Start Date Can NOT Be After End Date{Environment.NewLine}{Environment.NewLine}Start Date: [{strStartDate}]  End Date: [{strEndDate}]", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					txtWeekOfStart.Text = gstrStartDate;
				}
			}

		} // txtWeekOfStart_LostFocus

		private void txtWeekOfEnd_Leave(Object eventSender, EventArgs eventArgs)
		{


			string strStartDate = txtWeekOfStart.Text;
			string strEndDate = txtWeekOfEnd.Text;

			string gstrEndDate = modUserHoursWorked.Get_UserHoursWorked_Private_End_Date();

			if (!Information.IsDate(strEndDate))
			{
				MessageBox.Show($"Invalid End Date [{strEndDate}]{Environment.NewLine}{Environment.NewLine}Please Re-Enter", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtWeekOfEnd.Text = gstrEndDate;
			}
			else
			{
				if (DateTime.Parse(strStartDate) > DateTime.Parse(strEndDate))
				{
					MessageBox.Show($"End Date Can NOT Be Before Start Date{Environment.NewLine}{Environment.NewLine}Start Date: [{strStartDate}]  End Date: [{strEndDate}]", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					txtWeekOfEnd.Text = gstrEndDate;
				}
			}

		} // txtWeekOfEnd_LostFocus
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}