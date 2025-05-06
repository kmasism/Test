using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Text;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Gui.Controls;
using UpgradeHelpers.Helpers;
using JetNetSupport.Excel;

namespace JETNET_Homebase
{
	internal partial class frm_JETNETiQLoadSurveyResults
		: System.Windows.Forms.Form
	{

		public frm_JETNETiQLoadSurveyResults()
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


		private void frm_JETNETiQLoadSurveyResults_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}

		string gExcelFileName = "";

		private void AddItemToListBox(string strText)
		{

			lstbJETNETiQSurvey.AddItem(strText);
			if (lstbJETNETiQSurvey.Items.Count > 1)
			{
				ListBoxHelper.SetSelectedIndex(lstbJETNETiQSurvey, lstbJETNETiQSurvey.Items.Count - 1);
				ListBoxHelper.SetSelected(lstbJETNETiQSurvey, lstbJETNETiQSurvey.Items.Count - 1, false);
			}
			Application.DoEvents();

		} // AddItemToListBox

		private bool Validate_Excel_Header_Row(dynamic xlExcelWS) //gap-note Excel library must be reviewed during the stabilization
		{


			bool bResults = false;

			int lRow = 1;

			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			string strCompId = ($"{Convert.ToString(xlExcelWS.Cells(lRow, 1).Value)} ").Trim();
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			string strStatus = ($"{Convert.ToString(xlExcelWS.Cells(lRow, 3).Value)} ").Trim();
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			string strContact = ($"{Convert.ToString(xlExcelWS.Cells(lRow, 5).Value)} ").Trim();
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			string strCompany = ($"{Convert.ToString(xlExcelWS.Cells(lRow, 6).Value)} ").Trim();
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			string strEndDate = ($"{Convert.ToString(xlExcelWS.Cells(lRow, 11).Value)} ").Trim();

			if (strCompId == "COMPANY ID" && strStatus == "STATUS" && strContact == "NAME" && strCompany == "COMPANY" && strEndDate == "EndDate")
			{
				bResults = true;
			}

			return bResults;

		} // Validate_Excel_Header_Row

		private void cmdBrowse_Click(Object eventSender, EventArgs eventArgs)
		{

			string strFileName = "";

			try
			{

				cmdBrowse.Enabled = false;

				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.InitDir was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				mdi_ResearchAssistant.DefInstance.CommonDialog1Open.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.DialogTitle was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				mdi_ResearchAssistant.DefInstance.CommonDialog1Open.Title = "JETNETiQ Load Survey Results";
				//UPGRADE_WARNING: (2074) MSComDlg.CommonDialog property mdi_ResearchAssistant.CommonDialog1.Flags was upgraded to mdi_ResearchAssistant.CommonDialog1Open.ShowReadOnly which has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2074
				//UPGRADE_WARNING: (2074) FileOpenConstants STRING RESOURCE ["IDS-CONSTANT"] NOT FOUND FileOpenConstants.cdlOFNHideReadOnly was upgraded to OpenFileDialog.ShowReadOnly which has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2074
				mdi_ResearchAssistant.DefInstance.CommonDialog1Open.ShowReadOnly = false;
				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.Filter was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (2081) Filter has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				mdi_ResearchAssistant.DefInstance.CommonDialog1Open.Filter = "Excel Files (*.xls)|*.xlsx|All Files (*.*)|*.*";
				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.FileName was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				mdi_ResearchAssistant.DefInstance.CommonDialog1Open.FileName = "";
				mdi_ResearchAssistant.DefInstance.CommonDialog1Open.ShowDialog();

				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.FileName was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				if (mdi_ResearchAssistant.DefInstance.CommonDialog1Open.FileName != "")
				{

					//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.FileName was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					strFileName = mdi_ResearchAssistant.DefInstance.CommonDialog1Open.FileName;

					if (File.Exists(strFileName))
					{

						if (strFileName.IndexOf(".xls") >= 0 || strFileName.IndexOf(".xlsx") >= 0)
						{

							txtFileName.Text = strFileName;

							cmdImport.Enabled = true;

						}
						else
						{
							MessageBox.Show($"File Is NOT And Excel File{Environment.NewLine}{Environment.NewLine}{strFileName}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						} // If InStr(1, strFileName, ".xls") > 0 Or InStr(1, strFromFileName, ".xlsx") > 0 Then

					}
					else
					{
						MessageBox.Show($"Unable To Find File{Environment.NewLine}{strFileName}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					} // If gfso.FileExists(strFileName) = True Then

				} // If mdi_ResearchAssistant.CommonDialog1.FileName <> "" Then

				cmdBrowse.Enabled = true;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"cmdBrowse_Click_Error: {excep.Message}");
			}

		} // cmdBrowse_Click

		private void cmdImport_Click(Object eventSender, EventArgs eventArgs)
		{

			string strFileName = "";
			string strName = "";
			string strExt = "";
			string strCopyToDir = "";
			string strCopyToFileName = "";

			ExcelApplication xlExcel = null;//gap-note Excel library must be reviewed during the stabilization
            ExcelApplication xlExcelWB = null;//gap-note Excel library must be reviewed during the stabilization
            ExcelApplication xlExcelWS = null;//gap-note Excel library must be reviewed during the stabilization

			int lExcelRow = 0;
			int lExcelCol = 0;

			int lCompId = 0;
			string strCompId = "";
			string strStatus = "";
			string strCompany = "";
			string strContact = "";
			string strContactNameProper = "";
			string strEntryDate = "";
			System.DateTime dtEntryDate = DateTime.FromOADate(0);
			string strJournalDate = "";
			System.DateTime dtJournalDate = DateTime.FromOADate(0);
			string strJSubject = "";
			string strUserId = "";

			int lCnt1 = 0;
			int lAdd1 = 0;
			int lNotFound1 = 0;
			FileInfo fFile = null;

			StringBuilder strInsert1 = new StringBuilder();

			try
			{

				strFileName = txtFileName.Text;

				if (File.Exists(strFileName))
				{

					strUserId = Convert.ToString(modAdminCommon.snp_User["user_id"]).ToUpper(); // Current User

					fFile = new FileInfo(strFileName);

					strName = fFile.Name;

					modAdminCommon.Record_Event("User Action", $"Load JETNETiQ Survey Results: {strName}");

					lstbJETNETiQSurvey.Items.Clear();
					AddItemToListBox("Load JETNETiQ Survey Results");
					AddItemToListBox($"  !-FileName: {strFileName}");

					strCopyToDir = modCommon.DLookUp("aconfig_jetnetiq_survey_dir", "Application_Configuration");

					if (strCopyToDir != "")
					{

						strCopyToDir = $"{strCopyToDir}\\";
						if (Directory.Exists(strCopyToDir))
						{

							strExt = ".xls";
							if (strName.IndexOf(".xlsx") >= 0)
							{
								strExt = ".xlsx";
							}

							strCopyToFileName = txtJournalSubject.Text;
							strCopyToFileName = StringsHelper.Replace(strCopyToFileName, "{STATUS} ", "", 1, -1, CompareMethod.Binary);
							strCopyToFileName = StringsHelper.Replace(strCopyToFileName, " {CONTACTNAME}", "", 1, -1, CompareMethod.Binary);
							strCopyToFileName = StringsHelper.Replace(strCopyToFileName, "/", "", 1, -1, CompareMethod.Binary);
							strCopyToFileName = StringsHelper.Replace(strCopyToFileName, " Survey", "", 1, -1, CompareMethod.Binary);
							strCopyToFileName = $"JETNETiQ_{strCopyToFileName}_Survey_Results_{StringsHelper.Format(DateTime.Now, "yyyymmdd_hhMMss")}{strExt}";

							if (File.Exists($"{strCopyToDir}{strCopyToFileName}"))
							{
								//UPGRADE_WARNING: (2081) DeleteFile has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
								File.Delete($"{strCopyToDir}{strCopyToFileName}");
							}

							AddItemToListBox($" !-Copying To: {strCopyToDir}{strCopyToFileName}");
							File.Copy(strFileName, $"{strCopyToDir}{strCopyToFileName}", true);

							AddItemToListBox(" !-Opening Excel File");

							if (xlExcel == null)
							{
								xlExcel = new ExcelApplication();
							}

							//UPGRADE_TODO: (1067) Member Workbooks is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
							xlExcel.Workbooks.Open(strFileName);
							//UPGRADE_TODO: (1067) Member ActiveWorkbook is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
							xlExcelWB = (ExcelApplication)xlExcel.ActiveWorkbook;
							//UPGRADE_TODO: (1067) Member ActiveSheet is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
							xlExcelWS = (ExcelApplication)xlExcelWB.ActiveSheet;

							//UPGRADE_TODO: (1067) Member Visible is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
							xlExcel.Visible = true; // <-- *** Optional ***

							lExcelRow = 1; // First Row Contains Headers
							lExcelCol = 0;

							lCnt1 = 0;
							lAdd1 = 0;
							lNotFound1 = 0;

							if (Validate_Excel_Header_Row(xlExcelWS))
							{

								do 
								{ // Loop Until lExcelRow >= 1000 Or strCompId = "EOF" Or strCompId = "EOJ" Or (strCompId = "" And strStatus = "")

									lExcelRow++;
									lCompId = 0;

									strEntryDate = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
									dtEntryDate = DateTime.Parse(strEntryDate);

									strJournalDate = DateTime.Now.ToString("MM/dd/yyyy");
									dtJournalDate = DateTime.Parse(strJournalDate);

									// Cell A = CompId
									//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									strCompId = ($"{Convert.ToString(xlExcelWS.Cells(lExcelRow, 1).Value)} ").Trim();

									// Cell C = Status
									//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									strStatus = ($"{Convert.ToString(xlExcelWS.Cells(lExcelRow, 3).Value)}").Trim();

									// Cell E = Contact Name
									//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									strContact = ($"{Convert.ToString(xlExcelWS.Cells(lExcelRow, 5).Value)} ").Trim();
									if (strContact != "" && strContact != "0")
									{
										strContactNameProper = Strings.StrConv(strContact, VbStrConv.ProperCase, 0);
									}
									else
									{
										strContact = "";
										strContactNameProper = "";
									}

									// Cell F = Company Name
									//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									strCompany = ($"{Convert.ToString(xlExcelWS.Cells(lExcelRow, 6).Value)} ").Trim();

									// Cell K - EndDate
									// This is the Date the User Took the Survey
									//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									strJournalDate = ($"{Convert.ToString(xlExcelWS.Cells(lExcelRow, 11).Value)} ").Trim();
									if (!Information.IsDate(strJournalDate) || strJournalDate == "")
									{
										strJournalDate = DateTime.Now.ToString("MM/dd/yyyy");
									}
									dtJournalDate = DateTime.Parse(strJournalDate);

									strEntryDate = dtEntryDate.ToString("MM/dd/yyyy HH:mm:ss");
									strJournalDate = dtJournalDate.ToString("MM/dd/yyyy");

									strJSubject = txtJournalSubject.Text;
									strJSubject = StringsHelper.Replace(strJSubject, "{STATUS}", strStatus, 1, -1, CompareMethod.Binary);
									strJSubject = StringsHelper.Replace(strJSubject, "{CONTACTNAME}", strContactNameProper, 1, -1, CompareMethod.Binary);
									strJSubject = StringsHelper.Replace(strJSubject, "'", "''", 1, -1, CompareMethod.Binary);

									if (strCompId != "" && strCompId != "0")
									{

										//-------------------------------------
										// Check To See If Company Is Valid

										if (Information.IsNumeric(strCompId))
										{

											lCompId = Convert.ToInt32(Double.Parse(modCommon.DLookUp("comp_id", "Company", $"(comp_id = {strCompId}) AND (comp_journ_id = 0)")));

											if (lCompId > 0)
											{

												strInsert1 = new StringBuilder("INSERT INTO Journal (journ_date,journ_entry_date, ");
												strInsert1.Append("journ_subcategory_code, ");
												strInsert1.Append("journ_subject,journ_comp_id, ");
												strInsert1.Append("journ_user_id, journ_status, journ_action_date");
												strInsert1.Append(") VALUES (");

												strInsert1.Append($"'{strJournalDate}', "); // Journal Date
												strInsert1.Append($"'{strEntryDate}', "); // Entry Date


												strInsert1.Append("'IQ', ");
												strInsert1.Append($"'{StringsHelper.Replace(strJSubject, "'", "''", 1, -1, CompareMethod.Binary)}', ");
												strInsert1.Append($"{strCompId}, '{strUserId}', ");
												strInsert1.Append("'A', GetDate()");
												strInsert1.Append(")");

												DbCommand TempCommand = null;
												TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
												UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
												TempCommand.CommandText = strInsert1.ToString();
												//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
												//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
												TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
												UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
												TempCommand.ExecuteNonQuery();

												AddItemToListBox($" !-Added: {strJSubject}");
												lAdd1++;

											}
											else
											{
												lNotFound1++;
												AddItemToListBox($"Could NOT Find CompId: {strCompId}");
											} // If lCompId > 0 Then

										}
										else
										{
											lNotFound1++;
											AddItemToListBox($"Invalid CompId: {strCompId}");
										} // If IsNumeric(strCompId) = True Then

										lCnt1++;

										lblStatus.Text = $"Working [{StringsHelper.Format(lCnt1, "#,##0")}]  Added [{StringsHelper.Format(lAdd1, "#,##0")}]  Not Found [{StringsHelper.Format(lNotFound1, "#,##0")}]";
										Application.DoEvents();

									} // If strCompId <> "" And strCompId <> "0" Then

								}
								while(!(lExcelRow >= 1000 || strCompId == "EOF" || strCompId == "EOJ" || (strCompId == "" && strStatus == "")));

							}
							else
							{
								MessageBox.Show("Excel Header Row Is Invalid", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							} // If Validate_Excel_Header_Row(xlExcelWS) = True Then

							AddItemToListBox(" !-Closing Excel File");

							//UPGRADE_TODO: (1067) Member Close is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
							xlExcelWB.Close(true);
							//UPGRADE_TODO: (1067) Member Quit is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
							xlExcel.Quit();

							lblCopyListBoxToClipboard.Visible = true;

						}
						else
						{
							MessageBox.Show($"Application Configuration JETNETiQ Survey Directory Does NOT Exist{Environment.NewLine}{Environment.NewLine}{strCopyToDir}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						} // If gfso.FolderExists(strCopyToDir) = True Then

					}
					else
					{
						MessageBox.Show("Unable To Get Application Configuration JETNETiQ Survey Directory", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					} // If strCopyToDir <> "" Then

				}
				else
				{
					MessageBox.Show($"Unable To Find File{Environment.NewLine}{Environment.NewLine}{strFileName}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If gfso.FileExists(strFileName) = True Then

				xlExcel = null;
				xlExcelWB = null;
				xlExcelWS = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("cmdImport_Click_Error:", excep.Message);
			}

		} // cmdImport_Click

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
		private void Form_Load()
		{

			txtJournalSubject.Text = $"{{STATUS}} Q{StringsHelper.Format(DateTime.Now, "q")}/{DateTime.Now.ToString("yyyy")} Survey {{CONTACTNAME}}";
			cmdImport.Enabled = false;
			lblCopyListBoxToClipboard.Visible = false;

		} // Form_Load

		private void SetButtons(bool bValue)
		{

			frmLoadFile.Enabled = bValue;
			cmdBrowse.Enabled = bValue;

		} // SetButtons

		private void frmLoadFile_DoubleClick(Object eventSender, EventArgs eventArgs)
		{

			string strFileName = "";
			string strFromFileName = "";

			try
			{

				SetButtons(false);

				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.InitDir was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				mdi_ResearchAssistant.DefInstance.CommonDialog1Open.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.DialogTitle was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				mdi_ResearchAssistant.DefInstance.CommonDialog1Open.Title = "JETNETiQ Excel File";
				//UPGRADE_WARNING: (2074) MSComDlg.CommonDialog property mdi_ResearchAssistant.CommonDialog1.Flags was upgraded to mdi_ResearchAssistant.CommonDialog1Open.ShowReadOnly which has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2074
				//UPGRADE_WARNING: (2074) FileOpenConstants STRING RESOURCE ["IDS-CONSTANT"] NOT FOUND FileOpenConstants.cdlOFNHideReadOnly was upgraded to OpenFileDialog.ShowReadOnly which has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2074
				mdi_ResearchAssistant.DefInstance.CommonDialog1Open.ShowReadOnly = false;
				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.Filter was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (2081) Filter has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				mdi_ResearchAssistant.DefInstance.CommonDialog1Open.Filter = "Excel Files (*.xls)|*.xlsx|All Files (*.*)|*.*";
				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.FileName was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				mdi_ResearchAssistant.DefInstance.CommonDialog1Open.FileName = "";
				mdi_ResearchAssistant.DefInstance.CommonDialog1Open.ShowDialog();

				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.FileName was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				if (mdi_ResearchAssistant.DefInstance.CommonDialog1Open.FileName != "")
				{

					//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.FileName was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					strFromFileName = mdi_ResearchAssistant.DefInstance.CommonDialog1Open.FileName;
					strFileName = Path.GetFileName(strFromFileName);

					if (File.Exists(strFromFileName))
					{

						if (strFileName.IndexOf(".xls") >= 0 || strFileName.IndexOf(".xlsx") >= 0)
						{

							txtFileName.Text = strFromFileName;

							cmdImport.Enabled = true;

						}
						else
						{
							MessageBox.Show($"File Is NOT And Excel File{Environment.NewLine}{Environment.NewLine}{strFileName}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						} // If InStr(1, strFromFileName, ".xls") > 0 Or InStr(1, strFileName, ".xlsx") > 0 Then

					}
					else
					{
						MessageBox.Show($"Unable To Find File{Environment.NewLine}{strFileName}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					} // If gfso.FileExists(strFileName) = True Then

				} // If mdi_ResearchAssistant.CommonDialog1.FileName <> "" Then

				SetButtons(true);
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("frmLoadFile_DblClick_Error - JETNETiQ Excel File - ", excep.Message);
			}

		} // frmLoadFile_DblClick

		//UPGRADE_WARNING: (2050) Frame Event frmLoadFile.OLEDragDrop was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2050
		private void frmLoadFile_OLEDragDrop(DataObject Data, int Effect, int Button, int Shift, float X, float Y)
		{

			FileInfo fFile = null;
			string strName = "";

			SetButtons(false);

			//UPGRADE_ISSUE: (2064) DataObjectFiles property Files.Item was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			string strFileName = null;// string strFileName = Data.Files.Item(1); //gap-note This line must be checked during Blazor stabilization since looks like is using drag/drop mechanism. An equivalent must be defined.
			cmdImport.Enabled = false;
			lblCopyListBoxToClipboard.Visible = false;

			if (File.Exists(strFileName))
			{

				fFile = new FileInfo(strFileName);

				strName = fFile.Name;

				if (strName.IndexOf(".xls") >= 0 || strName.IndexOf(".xlsx") >= 0)
				{

					txtFileName.Text = strFileName;

					cmdImport.Enabled = true;

				}
				else
				{
					MessageBox.Show($"File Is NOT And Excel File{Environment.NewLine}{Environment.NewLine}{strName}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If InStr(1, strName, ".xls") > 0 Or InStr(1, strName, ".xlsx") > 0 Then

			}
			else
			{
				MessageBox.Show($"Unable To Find File{Environment.NewLine}{Environment.NewLine}{strFileName}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
			} // If gfso.FileExists(strFileName) = True Then

			SetButtons(true);

		} // frmLoadFile_OLEDragDrop

		private void lblCopyListBoxToClipboard_Click(Object eventSender, EventArgs eventArgs)
		{


			lblCopyListBoxToClipboard.Enabled = false; // Temp Disable UnTil Process Is Completed

			string strTemp = "";
			int lCnt = lstbJETNETiQSurvey.Items.Count;
			if (lCnt > -1)
			{ // ListBox Contains Something

				Clipboard.Clear();

				int tempForEndVar = lstbJETNETiQSurvey.Items.Count - 1;
				for (lCnt = 0; lCnt <= tempForEndVar; lCnt++)
				{
					strTemp = $"{strTemp}{lstbJETNETiQSurvey.GetListItem(lCnt)}{Environment.NewLine}";
				}

				//UPGRADE_WARNING: (2081) Clipboard.SetText has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				Clipboard.SetText(strTemp);

			} // lCnt > -1

			MessageBox.Show("Copy Import Results To Clipboard Complete", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));

			lblCopyListBoxToClipboard.Enabled = true; // Is Completed

		} // lblCopyListBoxToClipboard_Click
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}