using Microsoft.VisualBasic;
using System;
using System.Data.Common;
using System.Text;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Gui.Utils;
using UpgradeHelpers.Helpers;

namespace JETNET_Homebase
{
	internal partial class frm_VerifyStatusReport
		: System.Windows.Forms.Form
	{


		private bool gbAlreadyStarted = false; // To See If The Form Has Already Started Processing
		private bool gbClosing = false; // Set if the form is asked to close
		public frm_VerifyStatusReport()
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




		private void cmdClipboard_Click(Object eventSender, EventArgs eventArgs)
		{

			string strTemp = "";
			string strData = "";

			Clipboard.Clear();
			//UPGRADE_WARNING: (2081) Clipboard.SetText has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
			Clipboard.SetText($"Verify Status Report: [{modAdminCommon.GetDateTime()}]{Environment.NewLine}{Environment.NewLine}");

			// Loop Through The Entire Grid
			int tempForEndVar = msfgResults.RowsCount - 1;
			for (int iRow = 0; iRow <= tempForEndVar; iRow++)
			{

				msfgResults.CurrentColumnIndex = 0;
				msfgResults.CurrentRowIndex = iRow;
				strTemp = ($"{msfgResults[msfgResults.CurrentRowIndex, msfgResults.CurrentColumnIndex].FormattedValue.ToString()} ").Trim();

				// The Header is the Tricky Part
				if (iRow == 0)
				{
					strTemp = $"{strTemp}   ";
				}
				else
				{
					if (Strings.Len(strTemp) < 17)
					{
						strTemp = $"{strTemp}{new string(' ', 17 - (Strings.Len(strTemp)))}";
					}
				}

				// Now All The Data Rows/Cols
				int tempForEndVar2 = msfgResults.ColumnsCount - 1;
				for (int iCol = 1; iCol <= tempForEndVar2; iCol++)
				{
					msfgResults.CurrentColumnIndex = iCol;
					strData = ($"{msfgResults[msfgResults.CurrentRowIndex, msfgResults.CurrentColumnIndex].FormattedValue.ToString()} ").Trim();
					if ((iRow == 0) && (iCol == 2))
					{
						if (Strings.Len(strData) < 7)
						{
							strTemp = $"{strTemp}{new string(' ', 9 - (Strings.Len(strData)))}";
						}
					}
					else
					{
						if (Strings.Len(strData) < 15)
						{
							strTemp = $"{strTemp}{new string(' ', 16 - (Strings.Len(strData)))}";
						}
					}
					strTemp = $"{strTemp}{strData}";
				}
				//UPGRADE_WARNING: (2081) Clipboard.SetText has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				Clipboard.SetText($"{Clipboard.GetText()}{strTemp}{Environment.NewLine}");

				if (iRow == 0)
				{ // Underline Headers
					//UPGRADE_WARNING: (2081) Clipboard.SetText has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
					Clipboard.SetText($"{Clipboard.GetText()}{new string('=', 225)}{Environment.NewLine}");
				}

			}

			MessageBox.Show("Copy To Clipboard Complete", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK);

		}


		private void cmdClose_Click(Object eventSender, EventArgs eventArgs) => this.Close();


		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
		private void Form_Load()
		{
			gbAlreadyStarted = false;
			gbClosing = false;
		}

		private void Form_FormClosing(Object eventSender, FormClosingEventArgs eventArgs)
		{
			int Cancel = (eventArgs.Cancel) ? 1 : 0;
			int UnloadMode = (int) eventArgs.CloseReason;
			try
			{

				if (cmdClose.Enabled)
				{
					Cancel = 0; // OK To Unload
				}
				else
				{

					//UPGRADE_WARNING: (2065) QueryUnloadConstants property QueryUnloadConstants.vbFormControlMenu has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
					if (UnloadMode == ((int) CloseReason.UserClosing))
					{
						Cancel = 1; // NOT OK To Unload
						MessageBox.Show("Still Processing Report. Can NOT Close", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					else
					{
						Cancel = 0; // OK To Unload
						gbClosing = true;
						//Repeat
						do 
						{
						}
						while(!cmdClose.Enabled);
					}

				} // If cmdClose.Enabled = True Then
			}
			finally
			{
				eventArgs.Cancel = Cancel != 0;
			}

		} // End Sub Form_QueryUnload

		private void Fill_Grid_Headers(int iNbrCells)
		{


			gbAlreadyStarted = true;
			cmdClose.Enabled = false;
			cmdClipboard.Enabled = false;

			msfgResults.FixedColumns = 0;
			msfgResults.FixedRows = 0;

			msfgResults.Clear();

			// The first two are labels and totals
			iNbrCells += 2;

			// Setup How Many Columns and Rows
			msfgResults.ColumnsCount = iNbrCells;
			msfgResults.RowsCount = 7;

			msfgResults.CurrentColumnIndex = 0;
			msfgResults.CurrentRowIndex = 0;

			// Set Colum Widths
			msfgResults.SetColumnWidth(0, 100); // Class A,B,C
			int tempForEndVar = iNbrCells;
			for (int iCnt1 = 1; iCnt1 <= tempForEndVar; iCnt1++)
			{
				msfgResults.SetColumnWidth(iCnt1, 90); // Totals
			}

			// Set Colum Headers
			msfgResults.CurrentColumnIndex = 0;
			msfgResults.CurrentRowIndex = 0;
			msfgResults.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			msfgResults[msfgResults.CurrentRowIndex, msfgResults.CurrentColumnIndex].Value = "Aircraft Class";

			msfgResults.CurrentColumnIndex = 1;
			msfgResults.CurrentRowIndex = 0;
			msfgResults.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			msfgResults[msfgResults.CurrentRowIndex, msfgResults.CurrentColumnIndex].Value = "Total A/C";

			int tempForEndVar2 = iNbrCells - 1;
			for (int iCnt1 = 2; iCnt1 <= tempForEndVar2; iCnt1++)
			{
				msfgResults.CurrentColumnIndex = iCnt1;
				msfgResults.CurrentRowIndex = 0;
				msfgResults.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
				msfgResults[msfgResults.CurrentRowIndex, msfgResults.CurrentColumnIndex].Value = $"#{(iCnt1 - 1).ToString()}";
			}

			msfgResults.FixedColumns = 0;
			msfgResults.FixedRows = 0;

			msfgResults.CurrentColumnIndex = 0;
			msfgResults.CurrentRowIndex = 0;

			msfgResults.CurrentColumnIndex = 0; // Class A
			msfgResults.CurrentRowIndex = 1;
			msfgResults.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			msfgResults[msfgResults.CurrentRowIndex, msfgResults.CurrentColumnIndex].Value = "Class A (28 Days)";

			msfgResults.FixedRows = 1;

			msfgResults.CurrentColumnIndex = 0; // Class A
			msfgResults.CurrentRowIndex = 2;
			msfgResults.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			msfgResults[msfgResults.CurrentRowIndex, msfgResults.CurrentColumnIndex].Value = "Cumulative";

			msfgResults.CurrentColumnIndex = 0; // Class B
			msfgResults.CurrentRowIndex = 3;
			msfgResults.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			msfgResults[msfgResults.CurrentRowIndex, msfgResults.CurrentColumnIndex].Value = "Class B (35 Days)";

			msfgResults.CurrentColumnIndex = 0; // Class B
			msfgResults.CurrentRowIndex = 4;
			msfgResults.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			msfgResults[msfgResults.CurrentRowIndex, msfgResults.CurrentColumnIndex].Value = "Cumulative";

			msfgResults.CurrentColumnIndex = 0; // Class C
			msfgResults.CurrentRowIndex = 5;
			msfgResults.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			msfgResults[msfgResults.CurrentRowIndex, msfgResults.CurrentColumnIndex].Value = "Class C (56 Days)";

			msfgResults.CurrentColumnIndex = 0; // Class C
			msfgResults.CurrentRowIndex = 6;
			msfgResults.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			msfgResults[msfgResults.CurrentRowIndex, msfgResults.CurrentColumnIndex].Value = "Cumulative";

		} // End Sub Fill_Grid_Headers


		private void Form_Activated(Object eventSender, EventArgs eventArgs)
		{
			if (ActivateHelper.myActiveForm != eventSender)
			{
				ActivateHelper.myActiveForm = (Form) eventSender;

				try
				{

					ADORecordSetHelper rstRec1 = null;
					string strQuery = "";
					string strBaseQuery = "";
					string strVSQuery = "";
					string strClassQuery = "";
					string strDateQuery = "";
					int cntCount = 0;
					int iCnt1 = 0;
					string strDateFrom = "";
					string strDateTo = "";
					string strToday = "";
					int lTotalAC = 0;
					int lTotalCnt = 0;
					double dPercent = 0;
					StringBuilder strTemp = new StringBuilder();
					int lTimeOut = 0;
					int iNbrCells = 0;
					if (!gbAlreadyStarted)
					{


						rstRec1 = new ADORecordSetHelper();



						iNbrCells = 12;
						Fill_Grid_Headers(iNbrCells);

						lTimeOut = UpgradeHelpers.DB.DbConnectionHelper.GetCommandTimeOut(modAdminCommon.LOCAL_ADO_DB); // Hold The Current Value
						UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(modAdminCommon.LOCAL_ADO_DB, 300); // Five Minutes

						this.Cursor = Cursors.WaitCursor;
						Application.DoEvents();

						strBaseQuery = "SELECT DISTINCT ac_id FROM Aircraft_Model INNER JOIN Aircraft ON amod_id = ac_amod_id ";
						strBaseQuery = $"{strBaseQuery}INNER JOIN Journal ON ac_id = journ_ac_id  INNER JOIN Aircraft_Reference ON ac_id = cref_ac_id AND ac_journ_id = cref_journ_id ";
						strBaseQuery = $"{strBaseQuery}INNER JOIN Company ON cref_comp_id = comp_id AND cref_journ_id = comp_journ_id ";
						strBaseQuery = $"{strBaseQuery}WHERE (ac_journ_id = 0)  AND (ac_lifecycle_stage = 3) ";
						strBaseQuery = $"{strBaseQuery}AND (ac_ownership_type <> 'F') AND (cref_transmit_seq_no = 1)  AND (comp_agency_type <> 'G') ";

						strVSQuery = "AND (journ_subcategory_code = 'VS') ";

						strToday = modAdminCommon.GetDateTime();
						strDateTo = modAdminCommon.GetDateTime();


						strClassQuery = "AND (amod_class_code = 'A') ";

						strQuery = $"{strBaseQuery}{strClassQuery}";
						rstRec1.Open(strQuery, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

						lTotalAC = 0;
						if ((!rstRec1.BOF) && (!rstRec1.EOF))
						{

							rstRec1.MoveLast();
							lTotalAC = rstRec1.RecordCount;
							strTemp = new StringBuilder($"{StringsHelper.Format(lTotalAC, "#,###")}  ");

							msfgResults.CurrentColumnIndex = 1; // Total A/C
							msfgResults.CurrentRowIndex = 1;
							msfgResults[msfgResults.CurrentRowIndex, msfgResults.CurrentColumnIndex].Value = $"{strTemp.ToString()}  ";

							msfgResults.CurrentColumnIndex = 1; // Cumulative
							msfgResults.CurrentRowIndex = 2;
							msfgResults[msfgResults.CurrentRowIndex, msfgResults.CurrentColumnIndex].Value = "  ";

						} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

						rstRec1.Close();

						Application.DoEvents();

						// Check To See If The Process Should Continue
						if (!gbClosing)
						{


							iCnt1 = 0;
							do 
							{ // Loop Until iCnt1 = iNbrCells

								iCnt1++;

								msfgResults.CurrentColumnIndex = iCnt1 + 1;
								msfgResults.CurrentRowIndex = 1;

								Application.DoEvents();

								strDateFrom = DateTimeHelper.ToString(DateTime.Parse(strDateTo).AddDays(-28)); // Each Interation Subtract 28 days

								strDateQuery = $"AND (journ_entry_date BETWEEN '{strDateFrom}' AND '{strDateTo}') ";
								strQuery = $"{strBaseQuery}{strVSQuery}{strClassQuery}{strDateQuery}";

								rstRec1.Open(strQuery, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
								if ((!rstRec1.BOF) && (!rstRec1.EOF))
								{

									rstRec1.MoveLast();
									lTotalCnt = rstRec1.RecordCount;
									strTemp = new StringBuilder(StringsHelper.Format(lTotalCnt, "#,###"));

									if ((lTotalCnt > 0) && (lTotalAC > 0))
									{
										dPercent = lTotalCnt / ((double) lTotalAC) * 100;
										strTemp.Append($" ({StringsHelper.Format(dPercent, "###.00")}%)");
									} // If (lTotalCnt > 0) And (lTotalAC > 0) Then

									msfgResults.CurrentRowIndex = 1;
									msfgResults[msfgResults.CurrentRowIndex, msfgResults.CurrentColumnIndex].Value = $"{strTemp.ToString()}  ";

								} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

								rstRec1.Close();

								Application.DoEvents();

								strDateQuery = $"AND (journ_entry_date BETWEEN '{strDateFrom}' AND '{strToday}') ";
								strQuery = $"{strBaseQuery}{strVSQuery}{strClassQuery}{strDateQuery}";

								rstRec1.Open(strQuery, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
								if ((!rstRec1.BOF) && (!rstRec1.EOF))
								{

									rstRec1.MoveLast();
									lTotalCnt = rstRec1.RecordCount;
									strTemp = new StringBuilder(StringsHelper.Format(lTotalCnt, "#,###"));

									if ((lTotalCnt > 0) && (lTotalAC > 0))
									{
										dPercent = lTotalCnt / ((double) lTotalAC) * 100;
										strTemp.Append($" ({StringsHelper.Format(dPercent, "###.00")}%)");
									} // If (lTotalCnt > 0) And (lTotalAC > 0) Then

									msfgResults.CurrentRowIndex = 2;
									msfgResults[msfgResults.CurrentRowIndex, msfgResults.CurrentColumnIndex].Value = $"{strTemp.ToString()}  ";

								} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

								rstRec1.Close();

								strDateTo = DateTimeHelper.ToString(DateTime.Parse(strDateFrom).AddDays(-1)); // Always Reset

								Application.DoEvents();

							}
							while(!((iCnt1 == iNbrCells) || (gbClosing)));

							// Check To See If The Process Should Continue
							if (!gbClosing)
							{

								strDateTo = modAdminCommon.GetDateTime();
								strToday = modAdminCommon.GetDateTime();


								strClassQuery = "AND (amod_class_code = 'B') ";

								strQuery = $"{strBaseQuery}{strClassQuery}";
								rstRec1.Open(strQuery, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

								lTotalAC = 0;
								if ((!rstRec1.BOF) && (!rstRec1.EOF))
								{

									rstRec1.MoveLast();
									lTotalAC = rstRec1.RecordCount;
									strTemp = new StringBuilder($"{StringsHelper.Format(lTotalAC, "#,###")}  ");

									msfgResults.CurrentColumnIndex = 1; // Total A/C
									msfgResults.CurrentRowIndex = 3;
									msfgResults[msfgResults.CurrentRowIndex, msfgResults.CurrentColumnIndex].Value = $"{strTemp.ToString()}  ";

									msfgResults.CurrentColumnIndex = 1; // Cumulative
									msfgResults.CurrentRowIndex = 4;
									msfgResults[msfgResults.CurrentRowIndex, msfgResults.CurrentColumnIndex].Value = "  ";

								} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

								rstRec1.Close();

								Application.DoEvents();

								// Check To See If The Process Should Continue
								if (!gbClosing)
								{


									iCnt1 = 0;
									do 
									{ // Loop Until iCnt1 = iNbrCells

										iCnt1++;

										msfgResults.CurrentColumnIndex = iCnt1 + 1;
										msfgResults.CurrentRowIndex = 3;

										Application.DoEvents();

										strDateFrom = DateTimeHelper.ToString(DateTime.Parse(strDateTo).AddDays(-35)); // Each Interation Subtract 35 days

										strDateQuery = $"AND (journ_entry_date BETWEEN '{strDateFrom}' AND '{strDateTo}') ";
										strQuery = $"{strBaseQuery}{strVSQuery}{strClassQuery}{strDateQuery}";

										rstRec1.Open(strQuery, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
										if ((!rstRec1.BOF) && (!rstRec1.EOF))
										{

											rstRec1.MoveLast();
											lTotalCnt = rstRec1.RecordCount;
											strTemp = new StringBuilder(StringsHelper.Format(lTotalCnt, "#,###"));

											if ((lTotalCnt > 0) && (lTotalAC > 0))
											{
												dPercent = lTotalCnt / ((double) lTotalAC) * 100;
												strTemp.Append($" ({StringsHelper.Format(dPercent, "###.00")}%)");
											} // If (lTotalCnt > 0) And (lTotalAC > 0) Then

											msfgResults.CurrentRowIndex = 3;
											msfgResults[msfgResults.CurrentRowIndex, msfgResults.CurrentColumnIndex].Value = $"{strTemp.ToString()}  ";

										} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

										rstRec1.Close();

										Application.DoEvents();


										strDateQuery = $"AND (journ_entry_date BETWEEN '{strDateFrom}' AND '{strToday}') ";
										strQuery = $"{strBaseQuery}{strVSQuery}{strClassQuery}{strDateQuery}";

										rstRec1.Open(strQuery, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
										if ((!rstRec1.BOF) && (!rstRec1.EOF))
										{

											rstRec1.MoveLast();
											lTotalCnt = rstRec1.RecordCount;
											strTemp = new StringBuilder(StringsHelper.Format(lTotalCnt, "#,###"));

											if ((lTotalCnt > 0) && (lTotalAC > 0))
											{
												dPercent = lTotalCnt / ((double) lTotalAC) * 100;
												strTemp.Append($" ({StringsHelper.Format(dPercent, "###.00")}%)");
											} // If (lTotalCnt > 0) And (lTotalAC > 0) Then

											msfgResults.CurrentRowIndex = 4;
											msfgResults[msfgResults.CurrentRowIndex, msfgResults.CurrentColumnIndex].Value = $"{strTemp.ToString()}  ";

										} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

										rstRec1.Close();

										strDateTo = DateTimeHelper.ToString(DateTime.Parse(strDateFrom).AddDays(-1)); // Always Reset

										Application.DoEvents();

									}
									while(!((iCnt1 == iNbrCells) || (gbClosing)));

									// Check To See If The Process Should Continue
									if (!gbClosing)
									{

										strDateTo = modAdminCommon.GetDateTime();
										strToday = modAdminCommon.GetDateTime();


										strClassQuery = "AND (amod_class_code = 'C') ";

										strQuery = $"{strBaseQuery}{strClassQuery}";

										rstRec1.Open(strQuery, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

										lTotalAC = 0;
										if ((!rstRec1.BOF) && (!rstRec1.EOF))
										{

											rstRec1.MoveLast();
											lTotalAC = rstRec1.RecordCount;
											strTemp = new StringBuilder($"{StringsHelper.Format(lTotalAC, "#,###")}  ");

											msfgResults.CurrentColumnIndex = 1; // Total A/C
											msfgResults.CurrentRowIndex = 5;
											msfgResults[msfgResults.CurrentRowIndex, msfgResults.CurrentColumnIndex].Value = $"{strTemp.ToString()}  ";

											msfgResults.CurrentColumnIndex = 1; // Cumulative
											msfgResults.CurrentRowIndex = 6;
											msfgResults[msfgResults.CurrentRowIndex, msfgResults.CurrentColumnIndex].Value = "  ";

										} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

										rstRec1.Close();

										Application.DoEvents();

										// Check To See If The Process Should Continue
										if (!gbClosing)
										{

											iCnt1 = 0;
											do 
											{ // Loop Until iCnt1 = iNbrCells

												iCnt1++;

												msfgResults.CurrentColumnIndex = iCnt1 + 1;
												msfgResults.CurrentRowIndex = 5;

												Application.DoEvents();

												strDateFrom = DateTimeHelper.ToString(DateTime.Parse(strDateTo).AddDays(-56)); // Each Interation Subtract 56 days

												strDateQuery = $"AND (journ_entry_date BETWEEN '{strDateFrom}' AND '{strDateTo}') ";
												strQuery = $"{strBaseQuery}{strVSQuery}{strClassQuery}{strDateQuery}";

												rstRec1.Open(strQuery, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
												if ((!rstRec1.BOF) && (!rstRec1.EOF))
												{

													rstRec1.MoveLast();
													lTotalCnt = rstRec1.RecordCount;
													strTemp = new StringBuilder(StringsHelper.Format(lTotalCnt, "#,###"));

													if ((lTotalCnt > 0) && (lTotalAC > 0))
													{
														dPercent = lTotalCnt / ((double) lTotalAC) * 100;
														strTemp.Append($" ({StringsHelper.Format(dPercent, "###.00")}%)");
													} // If (lTotalCnt > 0) And (lTotalAC > 0) Then

													msfgResults.CurrentRowIndex = 5;
													msfgResults[msfgResults.CurrentRowIndex, msfgResults.CurrentColumnIndex].Value = $"{strTemp.ToString()}  ";

												} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

												rstRec1.Close();

												Application.DoEvents();
												strDateQuery = $"AND (journ_entry_date BETWEEN '{strDateFrom}' AND '{strToday}') ";
												strQuery = $"{strBaseQuery}{strVSQuery}{strClassQuery}{strDateQuery}";

												rstRec1.Open(strQuery, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
												if ((!rstRec1.BOF) && (!rstRec1.EOF))
												{

													rstRec1.MoveLast();
													lTotalCnt = rstRec1.RecordCount;
													strTemp = new StringBuilder(StringsHelper.Format(lTotalCnt, "#,###"));

													if ((lTotalCnt > 0) && (lTotalAC > 0))
													{
														dPercent = lTotalCnt / ((double) lTotalAC) * 100;
														strTemp.Append($" ({StringsHelper.Format(dPercent, "###.00")}%)");
													} // If (lTotalCnt > 0) And (lTotalAC > 0) Then

													msfgResults.CurrentRowIndex = 6;
													msfgResults[msfgResults.CurrentRowIndex, msfgResults.CurrentColumnIndex].Value = $"{strTemp.ToString()}  ";

												} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

												rstRec1.Close();

												strDateTo = DateTimeHelper.ToString(DateTime.Parse(strDateFrom).AddDays(-1)); // Always Reset

												Application.DoEvents();

											}
											while(!((iCnt1 == iNbrCells) || (gbClosing)));

										} // If gbClosing = False Then

									} // If gbClosing = False Then

								} // If gbClosing = False Then

							} // If gbClosing = False Then

						} // If gbClosing = False Then

						//================================================================================

						rstRec1 = null;

						cmdClose.Enabled = true;
						cmdClipboard.Enabled = true;

						cmdClose.Focus();
						this.Cursor = CursorHelper.CursorDefault;

						UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(modAdminCommon.LOCAL_ADO_DB, lTimeOut); // Return To Saved Setting

					} // If bAlreadyStated = False Then

					return;
				}
				catch (System.Exception excep)
				{

					modAdminCommon.Report_Error($"Form_Activate_Error: {excep.Message}");
					this.Cursor = CursorHelper.CursorDefault;
				}
			}
		} // End Sub Form_Activate
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}