using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using UpgradeHelpers.Helpers;
using JetNetSupport.Excel;

namespace HomebaseAdministrator
{
	internal static class modExcel
	{


		public const int gridCellActiveColor = unchecked((int) 0x80000005); // White = -2147483643
		static readonly public Color gridCellInActiveColor = Color.FromArgb(224, 224, 224); // Grey  =  14737632

		public const int gridCellDefaultForeColor = unchecked((int) 0x80000008); // Black
		public const int gridCellDefaultBackColor = unchecked((int) 0x80000005); // White

		// Excel Cell Alignment
		public const int xlCenter = -4108;
		public const int xlLeft = -4131;
		public const int xlRight = -4152;
		public const int xlNormal = -4143;

		public const int xlInsideVertical = 11;
		public const int xlInsideHorizontal = 12;
		public const int xlSolid = 1;

		public const int xlAutomatic = -4105;
		public const int xlNone = -4142;

		public const int xlContinuous = 1;
		public const int xlThin = 2;

		public const int xlDiagonalDown = 5;
		public const int xlDiagonalUp = 6;
		public const int xlEdgeLeft = 7;
		public const int xlEdgeTop = 8;
		public const int xlEdgeBottom = 9;
		public const int xlEdgeRight = 10;


		public const int xlBlack = 1;
		public const int xlWhite = 2;
		public const int xlRed = 3;
		public const int xlBrightGreen = 4;
		public const int xlBlue = 5;
		public const int xlYellow = 6;
		public const int xlPink = 7;
		public const int xlTurquoise = 8;
		public const int xlDkRed = 9;

		public const int xlGreen = 10;
		public const int xlDkBlue = 11;
		public const int xlDkYellow = 12;
		public const int xlViolet = 13;
		public const int xlTeal = 14;
		public const int xlGray15 = 15;
		public const int xlGray16 = 16;
		public const int xlDkGray = 16;
		public const int xlPowderBlue = 17;
		public const int xlPlum = 18;
		public const int xlCream = 19;

		public const int xlLtTurquoise = 20;
		public const int xlDkPurple = 21;
		public const int xlSalmon = 22;
		public const int xlNavyBlue = 23;
		public const int xlLightLavender = 24;
		public const int xlLtGray = 24;

		public const int xlNavyBlue25 = 25;
		public const int xlMegenta26 = 26;
		public const int xlYellow27 = 27;
		public const int xlCyan = 28;
		public const int xlPurple = 29;
		public const int xlDkBrown = 30;
		public const int xlDkSeaGreen = 31;
		public const int xlDkBlue32 = 32;
		public const int xlSkyBlue = 33;
		public const int xlLtGreen = 35;
		public const int xlLtYellow = 36;
		public const int xlPaleBlue = 37;
		public const int xlRose = 38;
		public const int xlLavender = 39;

		public const int xlTan = 40;
		public const int xlLtBlue = 41;
		public const int xlAqua = 42;
		public const int xlLime = 43;
		public const int xlGold = 44;
		public const int xlLtOrange = 45;
		public const int xlOrange = 46;
		public const int xlBlueGray = 47;
		public const int xlGray48 = 48;
		public const int xlDkTeal = 49;

		public const int xlSeaGreen = 50;
		public const int xlDkGreen = 51;
		public const int xlOliveGreen = 52;
		public const int xlBrown = 53;
		public const int xlIndigo = 55;
		public const int xlGray80 = 56;

		private static bool bStopExport = false;

		//==================================================================================

		internal static void StopExcelExporting() => bStopExport = true;



		internal static bool Create_Excel_File(ref ExcelApplication objExcel, ref ExcelApplication objExcelWB, ref ExcelApplication objExcelWS, string strFileName)
		{

			bool result = false;
			bool bResults = false;

			try
			{

				bResults = false;

				objExcel = new ExcelApplication();

				//UPGRADE_TODO: (1067) Member Workbooks is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				objExcelWB = (ExcelApplication)objExcel.Workbooks.Add(new Microsoft.Office.Interop.Excel.Workbook());
                //UPGRADE_TODO: (1067) Member Worksheets is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
                objExcelWS = objExcelWB.Worksheets("Sheet1");

				//UPGRADE_WARNING: (7006) The Named argument FileFormat was not resolved and corresponds to the following expression xlNormal More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-7006
				//UPGRADE_WARNING: (7006) The Named argument FileName was not resolved and corresponds to the following expression strFileName More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-7006
				//UPGRADE_TODO: (1067) Member ActiveWorkbook is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				objExcel.ActiveWorkbook.SaveAs(strFileName, xlNormal);

				//UPGRADE_TODO: (1067) Member Visible is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				objExcel.Visible = true; // <-- *** Optional ***

				bResults = true;


				return bResults;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Create_Excel_File_Error", excep.Message);

				result = false;
			}
			return result;
		} // Create_Excel_File

		//==================================================================================

		internal static void OpenExcel(ref ExcelApplication objExcel, ref ExcelApplication objExcelWB, ref ExcelApplication objExcelWS, bool bQuite)
		{

			if (objExcel == null)
			{
				objExcel = new ExcelApplication();
			}

			//UPGRADE_TODO: (1067) Member Workbooks is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			objExcelWB = (ExcelApplication)objExcel.Workbooks.Add(new Microsoft.Office.Interop.Excel.Workbook());
			//UPGRADE_TODO: (1067) Member Worksheets is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			objExcelWB.Worksheets("Sheet1").Activate();
			//UPGRADE_TODO: (1067) Member Worksheets is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			objExcelWS = objExcelWB.Worksheets("Sheet1");

			//UPGRADE_TODO: (1067) Member Visible is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			objExcel.Visible = !bQuite;

		} // OpenExcel


		internal static void DisposeExcel(ref ExcelApplication objExcel, ref ExcelApplication objExcelWB, ref ExcelApplication objExcelWS)
		{

			objExcelWS = null;
			objExcelWB = null;
			objExcel = null;

		} // DisposeExcel


		internal static void OpenExcelFile(ref ExcelApplication objExcel, ref ExcelApplication objExcelWB, ref ExcelApplication objExcelWS, string strFileName, bool bQuite)
		{

			Object fso = new Object();

			if (objExcel == null)
			{
				objExcel = new ExcelApplication();
			}

			if (File.Exists(strFileName))
			{

				//UPGRADE_WARNING: (7006) The Named argument FileName was not resolved and corresponds to the following expression strFileName More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-7006
				//UPGRADE_TODO: (1067) Member Workbooks is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				objExcel.Workbooks.Open(strFileName);
				//UPGRADE_TODO: (1067) Member ActiveWorkbook is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				objExcelWB = (ExcelApplication)objExcel.ActiveWorkbook;
				//UPGRADE_TODO: (1067) Member ActiveSheet is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				objExcelWS = (ExcelApplication)objExcelWB.ActiveSheet;
				//UPGRADE_TODO: (1067) Member Visible is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				objExcel.Visible = true;

			} // If fso.FileExists(strFileName) = True Then


		} // OpenExcelFile


		internal static void ExportMSHFlexGrid(UpgradeHelpers.DataGridViewFlex fGrid, Label lLabel)
		{

			ExcelApplication objExcel = null;//gap-note type must be defined during Blazor stabilization
			ExcelApplication objExcelWB = null;//gap-note type must be defined during Blazor stabilization
			ExcelApplication objExcelWS = null;//gap-note type must be defined during Blazor stabilization

			int lExcelRow = 0;
			int lExcelCol = 0;
			int lExcelMaxCol = 0;

			int lGridRow = 0;
			int lGridCol = 0;

			int lRow = 0;
			int lTotal = 0;
			string strMsg = "";

			string strColName = "";

			int lFirstRow = 0;
			int lLastRow = 0;

			try
			{

				bStopExport = false;

				if (fGrid.RowsCount >= 2)
				{

					lFirstRow = fGrid.CurrentRowIndex;
					lLastRow = fGrid.RowSel;
					lTotal = fGrid.RowsCount - 1;

					lRow = 0;

					OpenExcel(ref objExcel, ref objExcelWB, ref objExcelWS, false);

					//UPGRADE_TODO: (1067) Member ScreenUpdating is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					objExcel.ScreenUpdating = true;
					lExcelRow = 0;

					//--------------------------------------
					// Headers

					lExcelRow++;
					lExcelCol = 0;
					lExcelMaxCol = 0;

					lGridRow = lExcelRow;
					lGridCol = -1;

					fGrid.CurrentRowIndex = lExcelRow - 1;

					if (fGrid.Rows[fGrid.CurrentRowIndex].Height * 15 != 0)
					{

						do 
						{ // Loop Until fGrid.Cols - 1 <= lGridCol

							lGridCol++;

							if (fGrid.Columns[lGridCol].Width != 0)
							{

								lExcelCol++;

								//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								objExcelWS.Cells(lExcelRow, lExcelCol).NumberFormat = "@";
								//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								objExcelWS.Cells(lExcelRow, lExcelCol).Interior.ColorIndex = xlGray16;
								//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								objExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = xlCenter;

								fGrid.CurrentColumnIndex = lGridCol;
								//UPGRADE_TODO: (1067) Member Columns is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								objExcelWS.Columns(lExcelCol).ColumnWidth = ((fGrid.Columns[lGridCol].Width / 100) + 4);
								strColName = fGrid[fGrid.CurrentRowIndex, fGrid.CurrentColumnIndex].FormattedValue.ToString();
								strColName = StringsHelper.Replace(strColName, "> ", "", 1, -1, CompareMethod.Binary);
								strColName = StringsHelper.Replace(strColName, "< ", "", 1, -1, CompareMethod.Binary);

								//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								objExcelWS.Cells(lExcelRow, lExcelCol).Value = strColName;

								//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
								DataGridViewContentAlignment switchVar = (DataGridViewContentAlignment) fGrid.CellAlignment;
								if (switchVar == DataGridViewContentAlignment.MiddleRight)
								{
									//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = xlRight;
								}
								else if (switchVar == DataGridViewContentAlignment.MiddleCenter)
								{ 
									//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = xlCenter;
								}
								else if (switchVar == DataGridViewContentAlignment.MiddleLeft)
								{ 
									//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = xlLeft;
								}
								else
								{
									//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = xlLeft;
								}

								Application.DoEvents();

							} // If fGrid.ColWidth(lGridCol) <> 0 Then

						}
						while(fGrid.ColumnsCount - 1 > lGridCol);

					} // If fGrid.RowHeight(fGrid.Row) <> 0 Then

					// Turning this off is faster but then some sort of status needs to be display
					//UPGRADE_TODO: (1067) Member ScreenUpdating is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					objExcel.ScreenUpdating = false;

					lExcelMaxCol = lExcelCol;

					do 
					{ // Loop Until lRow = lTotal Or bStopExport = True

						lExcelRow++;
						lExcelCol = 0;

						lGridRow = lExcelRow;
						lGridCol = -1;

						lRow++;
						fGrid.CurrentRowIndex = lRow;

						lLabel.Text = $"Exporting {StringsHelper.Format(lRow, "#,##0")} of {StringsHelper.Format(lTotal, "#,##0")}";

						if (fGrid.Rows[lRow].Height * 15 != 0)
						{

							do 
							{ // Loop Until fGrid.Cols - 1 <= lGridCol

								lGridCol++;

								if (fGrid.Columns[lGridCol].Width != 0)
								{

									lExcelCol++;

									//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWS.Cells(lExcelRow, lExcelCol).NumberFormat = "@";
									//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = xlCenter;

									fGrid.CurrentColumnIndex = lGridCol;
									//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWS.Cells(lExcelRow, lExcelCol).Value = fGrid[fGrid.CurrentRowIndex, fGrid.CurrentColumnIndex].FormattedValue.ToString();


									//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWS.Cells(lExcelRow, lExcelCol).Interior.ColorIndex = xlWhite;
									//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									objExcelWS.Cells(lExcelRow, lExcelCol).Font.ColorIndex = xlBlack;

									if (fGrid.CellBackColor == gridCellInActiveColor)
									{
										//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
										objExcelWS.Cells(lExcelRow, lExcelCol).Interior.ColorIndex = xlGray15;
									}

									if (fGrid.CellBackColor == Color.Red)
									{
										//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
										objExcelWS.Cells(lExcelRow, lExcelCol).Interior.ColorIndex = xlRed;
										//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
										objExcelWS.Cells(lExcelRow, lExcelCol).Font.ColorIndex = xlWhite;
									}

									//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
									DataGridViewContentAlignment switchVar_2 = (DataGridViewContentAlignment) fGrid.CellAlignment;
									if (switchVar_2 == DataGridViewContentAlignment.MiddleRight)
									{
										//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
										objExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = xlRight;
									}
									else if (switchVar_2 == DataGridViewContentAlignment.MiddleCenter)
									{ 
										//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
										objExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = xlCenter;
									}
									else if (switchVar_2 == DataGridViewContentAlignment.MiddleLeft)
									{ 
										//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
										objExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = xlLeft;
									}
									else
									{
										//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
										objExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = xlLeft;
									}

									Application.DoEvents();

								} // If fGrid.ColWidth(lGridCol) <> 0 Then

							}
							while(fGrid.ColumnsCount - 1 > lGridCol);

						} // If fGrid.RowHeight(lRow) <> 0 Then

						fGrid.CurrentColumnIndex = 0;

					}
					while(!(lRow == lTotal || bStopExport));

					//UPGRADE_TODO: (1067) Member ScreenUpdating is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					objExcel.ScreenUpdating = true;

					DisposeExcel(ref objExcel, ref objExcelWB, ref objExcelWS);

					lLabel.Text = "Export Completed";

				}
				else
				{
					MessageBox.Show("Unable To Export Grid.  No Rows Available", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If fGrid.Rows >= 2 Then
			}
			catch (Exception e)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				if (Information.Err().Number == 424)
				{ // Object Required
					MessageBox.Show($"The Excel Object Has Been Closed Or Lost Prior To Completion Of The Export{Environment.NewLine}{Environment.NewLine}Aborting Export", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}

		} // ExportMSHFlexGrid

		internal static double ReturnPercentageGrowth(double dValue1, double dValue2)
		{


			double dResults = 0d;
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(dValue1) && !Convert.IsDBNull(dValue2))
			{
				if (dValue2 > 0d)
				{
					dResults = ((dValue1 - dValue2) / dValue2);
				}
			}

			return dResults;

		} // ReturnPercentageGrowth

		internal static string ConvertRowColumnToExcelRange(int Row1, int Col1, int Row2, int Col2)
		{

			string RowCol2 = "";
			int K = 0;
			int J = 0;
			int M = 0;


			string strResults = "";

			string RowCol1 = "";

			if (Col1 < 255 && Col2 < 255)
			{

				M = Col1 / 26; //rows /26
				J = Col1 % 26; //row remainder
				if (J == 0)
				{
					J = 26;
					M--;
				}

				if (M == 0)
				{
					RowCol1 = $"{RowCol1}{Strings.Chr(64 + J).ToString()}";
				}
				else
				{
					RowCol1 = $"{RowCol1}{Strings.Chr(64 + M).ToString()}";
					if (J > 0)
					{
						RowCol1 = $"{RowCol1}{Strings.Chr(64 + J).ToString()}";
					}
				}

				if (Row1 > 0)
				{
					RowCol1 = $"{RowCol1}{Conversion.Str(Row1).Trim()}";
					RowCol1 = RowCol1.Trim();
				}
				RowCol2 = "";

				M = Col2 / 26; //rows /26
				J = Col2 % 26; //row remainder
				if (J == 0)
				{
					J = 26;
					M--;
				}

				if (M == 0)
				{
					RowCol2 = $"{RowCol2}{Strings.Chr(64 + J).ToString()}";
				}
				else
				{
					RowCol2 = $"{RowCol2}{Strings.Chr(64 + M).ToString()}";
					if (J > 0)
					{
						RowCol2 = $"{RowCol2}{Strings.Chr(64 + J).ToString()}";
					}
				}

				if (Row2 > 0)
				{
					RowCol2 = $"{RowCol2}{Conversion.Str(Row2).Trim()}";
					RowCol2 = RowCol2.Trim();
				}

				strResults = $"{RowCol1}:{RowCol2}";

			} // If Col1 < 255 And Col2 < 255 Then

			return strResults;

		} // ConvertRowColumnToExcelRange

		internal static void DrawGrid(ExcelApplication oExcel, string strRange)
		{

			try
			{

				//UPGRADE_TODO: (1067) Member Range is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcel.Range(strRange).Select();
				//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcel.selection.Interior.Pattern = xlSolid;

				//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcel.selection.Borders(xlDiagonalDown).LineStyle = xlNone;
				//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcel.selection.Borders(xlDiagonalUp).LineStyle = xlNone;

				//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcel.selection.Borders(xlEdgeTop).LineStyle = xlContinuous;
				//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcel.selection.Borders(xlEdgeTop).Weight = xlThin;

				//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcel.selection.Borders(xlEdgeBottom).LineStyle = xlContinuous;
				//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcel.selection.Borders(xlEdgeBottom).Weight = xlThin;

				//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcel.selection.Borders(xlEdgeLeft).LineStyle = xlContinuous;
				//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcel.selection.Borders(xlEdgeLeft).Weight = xlThin;

				//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcel.selection.Borders(xlEdgeRight).LineStyle = xlContinuous;
				//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcel.selection.Borders(xlEdgeRight).Weight = xlThin;

				//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcel.selection.Borders(xlInsideVertical).LineStyle = xlContinuous;
				//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcel.selection.Borders(xlInsideVertical).Weight = xlThin;

				//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcel.selection.Borders(xlInsideHorizontal).LineStyle = xlContinuous;
				//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcel.selection.Borders(xlInsideHorizontal).Weight = xlThin;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("DrawGrid_Error", excep.Message);
			}


		} // DrawGrid

		internal static void AddHyperLink(ExcelApplication oExcel, ExcelApplication oExcelWB, ExcelApplication oExcelWS, string strWorksheetName, string strText, int lExcelRow, int lExcelCol)
		{

			string strHRef = "";
			string strRange = "";

			try
			{

				strHRef = $"'{strWorksheetName}'!A1";
				strRange = $"{Strings.Chr(64 + lExcelCol).ToString()}{lExcelRow.ToString()}:{Strings.Chr(64 + lExcelCol).ToString()}{lExcelRow.ToString()}";
				//UPGRADE_TODO: (1067) Member Range is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcel.Range(strRange).Select();
				//UPGRADE_WARNING: (7006) The Named argument TextToDisplay was not resolved and corresponds to the following expression strText More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-7006
				//UPGRADE_WARNING: (7006) The Named argument SubAddress was not resolved and corresponds to the following expression strHRef More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-7006
				//UPGRADE_WARNING: (7006) The Named argument Address was not resolved and corresponds to the following expression  More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-7006
				//UPGRADE_WARNING: (7006) The Named argument Anchor was not resolved and corresponds to the following expression oExcel.Selection More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-7006
				//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				//UPGRADE_TODO: (1067) Member Hyperlinks is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Hyperlinks.Add(oExcel.selection, "", strHRef, strText);
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("AddHyperLink_Error", excep.Message);
			}

		} // AddHyperLink

		internal static void Merge_Cells(ExcelApplication oExcel, ExcelApplication oExcelWB, ExcelApplication oExcelWS, int lRow1, int lCol1, int lRow2, int lCol2)
		{


			string strRange = ConvertRowColumnToExcelRange(lRow1, lCol1, lRow2, lCol2);
			//UPGRADE_TODO: (1067) Member Range is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Range(strRange).Merge();
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lRow1, lCol1).HorizontalAlignment = xlCenter;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lRow1, lCol1).VerticalAlignment = xlCenter;

		} // Merge_Cells

		internal static void Save_Excel_File(ExcelApplication oExcel, ExcelApplication oExcelWB, ExcelApplication oExcelWS, string strFullFileName)
		{

			try
			{

				if (oExcel != null)
				{

					if (File.Exists(strFullFileName))
					{
						//UPGRADE_TODO: (1067) Member ActiveWorkbook is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						oExcel.ActiveWorkbook.Save();
					}
					else
					{
						//UPGRADE_WARNING: (7006) The Named argument FileName was not resolved and corresponds to the following expression strFullFileName More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-7006
						//UPGRADE_TODO: (1067) Member ActiveWorkbook is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						oExcel.ActiveWorkbook.SaveAs(strFullFileName);
					}

				} // If (oExcel Is Nothing) = False Then
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Save_Excel_File_Error", excep.Message);
			}

		} // Savei_Excel_File

		internal static void Add_Seperator_Line_To_Excel(ExcelApplication oExcel, ExcelApplication oExcelWB, ExcelApplication oExcelWS, ref int lExcelRow, int lExcelCol, int iColor)
		{

			int lCnt1 = 0;

			lExcelRow++;

			string strRange = ConvertRowColumnToExcelRange(lExcelRow, 1, lExcelRow, lExcelCol);
			DrawGrid(oExcel, strRange);

			Merge_Cells(oExcel, oExcelWB, oExcelWS, lExcelRow, 1, lExcelRow, lExcelCol);

			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, 1).Interior.ColorIndex = iColor;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, 1)[lExcelRow, 1] = " ";

		} // Add_Seperator_Line_To_Excel

		internal static void Add_Number_To_Excel(ExcelApplication oExcelWS, int lExcelRow, ref int lExcelCol, double dValue, int iColor, string strFormat)
		{

			lExcelCol++;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).Interior.ColorIndex = iColor;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).HorizontalAlignment = xlRight;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).VerticalAlignment = xlCenter;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			oExcelWS.Cells(lExcelRow, lExcelCol).NumberFormat = strFormat;

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(dValue))
			{
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol)[lExcelRow, lExcelCol] = dValue.ToString();
			}
			else
			{
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				oExcelWS.Cells(lExcelRow, lExcelCol)[lExcelRow, lExcelCol] = "0";
			}

		} // Add_Number_To_Excel
	}
}