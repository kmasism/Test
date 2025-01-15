using Microsoft.VisualBasic;
using System;
using System.Data.Common;
using System.IO;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Helpers;
using UpgradeStubs;

namespace JETNET_Homebase
{
	internal partial class frm_NTSB_New
		: System.Windows.Forms.Form
	{

		public frm_NTSB_New()
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


		private void frm_NTSB_New_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}


		private Object _gfso = null;
		private Object gfso
		{
			get
			{
				if (_gfso is null)
				{
					_gfso = new Object();
				}
				return _gfso;
			}
			set => _gfso = value;
		}

		private string gstrNTSBPath = "";
		private string gstrNTSBMstrPath = "";
		private string gstrNTSBLibraryPath = "";
		private string gstrNTSBProcessingPath = "";
		private string gstrNTSBEMailPath = "";


		private void SetFormControlsEnable(bool bValue)
		{

			cmdDownloadNTSBReport.Enabled = bValue;
			cmdReloadNTSBReport.Enabled = bValue;
			cmdProcessNTSBReport.Enabled = bValue;

			fgridNTSB.Enabled = bValue;
			mvNTSBCal.Enabled = bValue;
			txtNTSBDate.Enabled = bValue;

		} // SetFormControlsEnable



		private void cmdClose_Click(Object eventSender, EventArgs eventArgs) => this.Close();




		private bool Check_Does_CSV_File_Exists()
		{


			bool bResults = false;

			//--------------------------------------------------
			// Check To See If NTSB CSV File Already Exists

			string strFileName = $"{DateTime.Parse(txtNTSBDate.Text).ToString("yyyyMMdd")}.csv";
			string strLocalFile = $"{gstrNTSBMstrPath}{strFileName}";

			if (File.Exists(strLocalFile))
			{
				cmdReloadNTSBReport.Visible = true;
				bResults = true;
			}
			else
			{
				cmdReloadNTSBReport.Visible = false;
				cmdProcessNTSBReport.Visible = false;
				bResults = false;
			} // If gfso.FileExists(strLocalFile) = True Then

			return bResults;

		} // Check_Does_CSV_File_Exists



		private void ClearNTSBGridAndSetHeaders()
		{


			fgridNTSB.Clear();

			fgridNTSB.RowsCount = 2;
			fgridNTSB.ColumnsCount = 13;
			fgridNTSB.CurrentRowIndex = 0;

			int iCol = -1;

			iCol++;
			fgridNTSB.CurrentColumnIndex = iCol;
			fgridNTSB.SetColumnWidth(iCol, 53);
			fgridNTSB.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			fgridNTSB[fgridNTSB.CurrentRowIndex, fgridNTSB.CurrentColumnIndex].Value = "FRAME #";

			iCol++;
			fgridNTSB.CurrentColumnIndex = iCol;
			fgridNTSB.SetColumnWidth(iCol, 73);
			fgridNTSB.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			fgridNTSB[fgridNTSB.CurrentRowIndex, fgridNTSB.CurrentColumnIndex].Value = "PROCESS";

			iCol++;
			fgridNTSB.CurrentColumnIndex = iCol;
			fgridNTSB.SetColumnWidth(iCol, 53);
			fgridNTSB.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			fgridNTSB[fgridNTSB.CurrentRowIndex, fgridNTSB.CurrentColumnIndex].Value = "ACID";

			iCol++;
			fgridNTSB.CurrentColumnIndex = iCol;
			fgridNTSB.SetColumnWidth(iCol, 133);
			fgridNTSB.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			fgridNTSB[fgridNTSB.CurrentRowIndex, fgridNTSB.CurrentColumnIndex].Value = "HB-MAKE";

			iCol++;
			fgridNTSB.CurrentColumnIndex = iCol;
			fgridNTSB.SetColumnWidth(iCol, 57);
			fgridNTSB.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			fgridNTSB[fgridNTSB.CurrentRowIndex, fgridNTSB.CurrentColumnIndex].Value = "REGNBR"; // REGIST_NBR

			iCol++;
			fgridNTSB.CurrentColumnIndex = iCol;
			fgridNTSB.SetColumnWidth(iCol, 100);
			fgridNTSB.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			fgridNTSB[fgridNTSB.CurrentRowIndex, fgridNTSB.CurrentColumnIndex].Value = "MAKE-MODEL"; // ACFT_MAKE_NAME & ACFT_MODEL_NAME

			iCol++;
			fgridNTSB.CurrentColumnIndex = iCol;
			fgridNTSB.SetColumnWidth(iCol, 93);
			fgridNTSB.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			fgridNTSB[fgridNTSB.CurrentRowIndex, fgridNTSB.CurrentColumnIndex].Value = "ACCIDENT TYPE"; // EVENT_TYPE_DESC

			iCol++;
			fgridNTSB.CurrentColumnIndex = iCol;
			fgridNTSB.SetColumnWidth(iCol, 117);
			fgridNTSB.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			fgridNTSB[fgridNTSB.CurrentRowIndex, fgridNTSB.CurrentColumnIndex].Value = "DAMAGE"; // ACFT_DMG_DESC & FLT_PHASE

			iCol++;
			fgridNTSB.CurrentColumnIndex = iCol;
			fgridNTSB.SetColumnWidth(iCol, 217);
			fgridNTSB.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			fgridNTSB[fgridNTSB.CurrentRowIndex, fgridNTSB.CurrentColumnIndex].Value = "DESCRIPTION"; // RMK_TEXT

			iCol++;
			fgridNTSB.CurrentColumnIndex = iCol;
			fgridNTSB.SetColumnWidth(iCol, 83);
			fgridNTSB.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			fgridNTSB[fgridNTSB.CurrentRowIndex, fgridNTSB.CurrentColumnIndex].Value = "TAPE DATE"; // ENTRY_DATE

			iCol++;
			fgridNTSB.CurrentColumnIndex = iCol;
			fgridNTSB.SetColumnWidth(iCol, 83);
			fgridNTSB.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			fgridNTSB[fgridNTSB.CurrentRowIndex, fgridNTSB.CurrentColumnIndex].Value = "DOC-DATE"; // EVENT_LCL_DATE

			iCol++;
			fgridNTSB.CurrentColumnIndex = iCol;
			fgridNTSB.SetColumnWidth(iCol, 70); // FAALOG_ID
			fgridNTSB.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			fgridNTSB[fgridNTSB.CurrentRowIndex, fgridNTSB.CurrentColumnIndex].Value = "FAALOG_ID";

			iCol++;
			fgridNTSB.CurrentColumnIndex = iCol;
			fgridNTSB.SetColumnWidth(iCol, 70); // ACCTREP
			fgridNTSB.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			fgridNTSB[fgridNTSB.CurrentRowIndex, fgridNTSB.CurrentColumnIndex].Value = "ACCTREP";

			fgridNTSB.FixedRows = 1;
			fgridNTSB.FixedColumns = 0;

			fgridNTSB.CurrentRowIndex = 1;

			cmdReloadNTSBReport.Visible = false;
			cmdProcessNTSBReport.Visible = false;

		} // ClearNTSBGridAndSetHeaders


		private bool LoadNTSBCSVFileInToGrid(string strPath, string strFileName)
		{

			bool result = false;
			DbConnection cntConn = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateConnection();
			string strConn = "";

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper(); // Reads CSV File
			ADORecordSetHelper rstRec2 = new ADORecordSetHelper(); // Reads Homebase
			ADORecordSetHelper rstRec3 = new ADORecordSetHelper(); // Checks FAA Document Log
			string strQuery1 = "";
			string strQuery2 = "";
			string strQuery3 = "";

			bool bResults = false;

			int iRow = 0;
			int iCol = 0;
			bool bFound = false;

			string strFrameNbr = "";
			string strProcess = "";
			int lACId = 0;
			string strACId = "";
			string strEntryDate = "";
			string strEventDate = "";
			string strSearchDate = "";
			string strRegNbr = "";
			string strHBMake = "";
			string strMake = "";
			string strModel = "";
			string strDistination = "";
			string strLocation = "";
			string strAccidentType = "";
			string strDamage = "";
			string strDescription = "";

			string strMsg = "";

			try
			{

				bResults = false;

				if (File.Exists($"{strPath}{strFileName}"))
				{

					strSearchDate = txtNTSBDate.Text;

					ClearNTSBGridAndSetHeaders();

					pbNTSB.Visible = true;
					pbNTSB.Maximum = 100;
					pbNTSB.Value = 1;

					bFound = false;

					//-----------------------------------
					// Open CSV File Connection

					strConn = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={gstrNTSBMstrPath};Extended Properties='text;FMT=Delimited'";
					//UPGRADE_ISSUE: (2064) ADODB.Connection property cntConn.ConnectionTimeout was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					cntConn.setConnectionTimeout(30);
					//UPGRADE_ISSUE: (2064) ADODB.Connection property cntConn.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					cntConn.setCursorLocation(CursorLocationEnum.adUseClient);
					//UPGRADE_TODO: (7010) The connection string must be verified to fullfill the .NET data provider connection string requirements. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-7010
					cntConn.ConnectionString = strConn;
					cntConn.Open();

					strQuery1 = $"SELECT * FROM {strFileName}";
					rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						pbNTSB.Maximum = rstRec1.RecordCount;
						pbNTSB.Value = 0;

						iRow = 0;

						do 
						{ // Loop Until rstRec1.EOF = True

							pbNTSB.Value = Convert.ToInt32(pbNTSB.Value + 1);

							lACId = 0;
							strACId = "";

							strEntryDate = "";
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(rstRec1["ENTRY_DATE"]))
							{
								if (Information.IsDate(rstRec1["ENTRY_DATE"]))
								{
									strEntryDate = Convert.ToDateTime(rstRec1["ENTRY_DATE"]).ToString("MM/dd/yyyy");
								}
							}

							strEventDate = "";
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(rstRec1["EVENT_LCL_DATE"]))
							{
								if (Information.IsDate(rstRec1["EVENT_LCL_DATE"]))
								{
									strEventDate = Convert.ToDateTime(rstRec1["EVENT_LCL_DATE"]).ToString("MM/dd/yyyy");
								}
							}

							strRegNbr = ($"{Convert.ToString(rstRec1["REGIST_NBR"])} ").Trim();
							strMake = ($"{Convert.ToString(rstRec1["ACFT_MAKE_NAME"])} ").Trim();
							strModel = ($"{Convert.ToString(rstRec1["ACFT_MODEL_NAME"])} ").Trim();
							strDistination = ($"{Convert.ToString(rstRec1["FSDO_DESC"])} ").Trim();
							strLocation = $"{($"{Convert.ToString(rstRec1["LOC_CITY_NAME"])} ").Trim()}, {($"{Convert.ToString(rstRec1["LOC_STATE_NAME"])} ").Trim()}, {($"{Convert.ToString(rstRec1["LOC_CNTRY_NAME"])} ").Trim()}";
							strAccidentType = ($"{Convert.ToString(rstRec1["EVENT_TYPE_DESC"])} ").Trim();
							strDamage = $"{($"{Convert.ToString(rstRec1["ACFT_DMG_DESC"])} ").Trim()} - {($"{Convert.ToString(rstRec1["FLT_PHASE"])} ").Trim()}";
							strDescription = ($"{Convert.ToString(rstRec1["RMK_TEXT"])} ").Trim();

							if (strSearchDate == strEntryDate)
							{

								bFound = true;

								iRow++;
								fgridNTSB.RowsCount = iRow + 1;
								fgridNTSB.CurrentRowIndex = iRow;

								strFrameNbr = iRow.ToString();
								strProcess = "";

								iCol = -1;

								iCol++;
								fgridNTSB.CurrentColumnIndex = iCol;
								fgridNTSB.CellAlignment = DataGridViewContentAlignment.MiddleRight;
								fgridNTSB[fgridNTSB.CurrentRowIndex, fgridNTSB.CurrentColumnIndex].Value = strFrameNbr;

								iCol++;
								fgridNTSB.CurrentColumnIndex = iCol;
								fgridNTSB.CellAlignment = DataGridViewContentAlignment.MiddleRight;
								fgridNTSB[fgridNTSB.CurrentRowIndex, fgridNTSB.CurrentColumnIndex].Value = strProcess;

								iCol++;
								fgridNTSB.CurrentColumnIndex = iCol;
								fgridNTSB.CellAlignment = DataGridViewContentAlignment.MiddleRight;
								fgridNTSB[fgridNTSB.CurrentRowIndex, fgridNTSB.CurrentColumnIndex].Value = strACId;

								iCol++;
								fgridNTSB.CurrentColumnIndex = iCol;
								fgridNTSB.CellAlignment = DataGridViewContentAlignment.MiddleRight;
								fgridNTSB[fgridNTSB.CurrentRowIndex, fgridNTSB.CurrentColumnIndex].Value = ""; // Homebase Make/Model

								iCol++;
								fgridNTSB.CurrentColumnIndex = iCol;
								fgridNTSB.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
								fgridNTSB[fgridNTSB.CurrentRowIndex, fgridNTSB.CurrentColumnIndex].Value = strRegNbr;

								iCol++;
								fgridNTSB.CurrentColumnIndex = iCol;
								fgridNTSB.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
								fgridNTSB[fgridNTSB.CurrentRowIndex, fgridNTSB.CurrentColumnIndex].Value = ($"{strMake} {strModel}").Trim();

								iCol++;
								fgridNTSB.CurrentColumnIndex = iCol;
								fgridNTSB.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
								fgridNTSB[fgridNTSB.CurrentRowIndex, fgridNTSB.CurrentColumnIndex].Value = strAccidentType;

								iCol++;
								fgridNTSB.CurrentColumnIndex = iCol;
								fgridNTSB.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
								fgridNTSB[fgridNTSB.CurrentRowIndex, fgridNTSB.CurrentColumnIndex].Value = strDamage;

								iCol++;
								fgridNTSB.CurrentColumnIndex = iCol;
								fgridNTSB.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
								fgridNTSB[fgridNTSB.CurrentRowIndex, fgridNTSB.CurrentColumnIndex].Value = strDescription;

								iCol++;
								fgridNTSB.CurrentColumnIndex = iCol;
								fgridNTSB.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
								fgridNTSB[fgridNTSB.CurrentRowIndex, fgridNTSB.CurrentColumnIndex].Value = strEntryDate; // TAPE DATE

								iCol++;
								fgridNTSB.CurrentColumnIndex = iCol;
								fgridNTSB.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
								fgridNTSB[fgridNTSB.CurrentRowIndex, fgridNTSB.CurrentColumnIndex].Value = strEventDate; // DOCUMENT DATE

								strQuery2 = "SELECT ac_id, amod_airframe_type_code, amod_type_code, amod_make_name, amod_model_name, ";
								strQuery2 = $"{strQuery2}ac_reg_no, ac_prev_reg_no, ac_ser_no_full FROM Aircraft_Model WITH (NOLOCK) ";
								strQuery2 = $"{strQuery2}INNER JOIN Aircraft WITH (NOLOCK) ON amod_id = ac_amod_id ";
								strQuery2 = $"{strQuery2}WHERE (ac_journ_id = 0) AND (ac_reg_no = '{strRegNbr}' OR ac_prev_reg_no = '{strRegNbr}') ";

								rstRec2.CursorLocation = CursorLocationEnum.adUseClient;
								rstRec2.Open(strQuery2, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

								if (!rstRec2.BOF && !rstRec2.EOF)
								{

									if (rstRec2.RecordCount == 1)
									{
										lACId = Convert.ToInt32(rstRec2["AC_ID"]);
										strACId = lACId.ToString();
										strHBMake = $"{($"{Convert.ToString(rstRec2["amod_make_name"])} ").Trim()} {($"{Convert.ToString(rstRec2["amod_model_name"])} ").Trim()}";
									}
									else
									{

										do 
										{ // Loop Until rstRec2.EOF = True Or lACId > 0

											strMsg = $"More Than One Aircraft Matched{Environment.NewLine}RegNbr: [{strRegNbr}]{Environment.NewLine}";
											strMsg = $"{strMsg}Make/Model: {strMake} {strModel}{Environment.NewLine}{Environment.NewLine}";
											strMsg = $"{strMsg}Use This One?{Environment.NewLine}{Environment.NewLine}ACId: {Convert.ToString(rstRec2["AC_ID"])}{Environment.NewLine}";
											strMsg = $"{strMsg}Airframe Type: {($"{Convert.ToString(rstRec2["amod_airframe_type_code"])} ").Trim()}{Environment.NewLine}";
											strMsg = $"{strMsg}Make Type: {($"{Convert.ToString(rstRec2["amod_type_code"])} ").Trim()}{Environment.NewLine}";
											strMsg = $"{strMsg}Make: {($"{Convert.ToString(rstRec2["amod_make_name"])} ").Trim()}{Environment.NewLine}";
											strMsg = $"{strMsg}Model: {($"{Convert.ToString(rstRec2["amod_model_name"])} ").Trim()}{Environment.NewLine}";
											strMsg = $"{strMsg}RegNbr: {($"{Convert.ToString(rstRec2["ac_reg_no"])} ").Trim()}{Environment.NewLine}";
											strMsg = $"{strMsg}PrevRegNbr: {($"{Convert.ToString(rstRec2["ac_prev_reg_no"])} ").Trim()}{Environment.NewLine}";
											strMsg = $"{strMsg}SerNbr: {($"{Convert.ToString(rstRec2["ac_ser_no_full"])} ").Trim()}{Environment.NewLine}";

											if (MessageBox.Show(strMsg, $"NTSB-[{strRegNbr}]", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
											{
												lACId = Convert.ToInt32(rstRec2["AC_ID"]);
												strACId = lACId.ToString();
												strHBMake = $"{($"{Convert.ToString(rstRec2["amod_make_name"])} ").Trim()} {($"{Convert.ToString(rstRec2["amod_model_name"])} ").Trim()}";
											}

											rstRec2.MoveNext();

										}
										while(!(rstRec2.EOF || lACId > 0));

									} // If rstRec2.RecordCount = 1 Then

									if (lACId > 0)
									{

										fgridNTSB.CurrentColumnIndex = 2;
										fgridNTSB.CellAlignment = DataGridViewContentAlignment.MiddleRight;
										fgridNTSB[fgridNTSB.CurrentRowIndex, fgridNTSB.CurrentColumnIndex].Value = strACId;

										fgridNTSB.CurrentColumnIndex = 3;
										fgridNTSB.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
										fgridNTSB[fgridNTSB.CurrentRowIndex, fgridNTSB.CurrentColumnIndex].Value = strHBMake;

										//---------------------------------------------------------------
										// Now Check To See If Record Is Already In FAA_Document_Log

										strQuery3 = $"SELECT faalog_id FROM FAA_Document_Log WITH (NOLOCK)  WHERE (faalog_ac_id = {strACId}) ";
										strQuery3 = $"{strQuery3}AND (faalog_tape_date = '{strEntryDate}')  AND (faalog_document_date = '{strEventDate}') ";
										strQuery3 = $"{strQuery3}AND (faalog_starting_frame_no = {strFrameNbr}) ";
										strQuery3 = $"{strQuery3}AND (faalog_ending_frame_no = {strFrameNbr}) AND (faalog_doc_type = 'NTS') ";

										rstRec3.Open(strQuery3, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

										if (!rstRec3.BOF && !rstRec3.EOF)
										{
											strProcess = "IN LOG";
											fgridNTSB[iRow, 1].Value = strProcess;
											fgridNTSB[iRow, 11].Value = Convert.ToString(rstRec3["faalog_id"]);
										} // If (rstRec3.BOF = False And rstRec3.EOF = False) Then

										rstRec3.Close();

									} // If lACId > 0 Then

								} // If (rstRec2.BOF = False And rstRec2.EOF = False) Then

								rstRec2.Close();

							} // If strSearchDate = strEntryDate Then

							rstRec1.MoveNext();
							Application.DoEvents();

						}
						while(!rstRec1.EOF);

					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();
					UpgradeHelpers.DB.TransactionManager.DeEnlist(cntConn);
					cntConn.Close();

					pbNTSB.Visible = false;

					if (bFound)
					{
						bResults = true;
						cmdReloadNTSBReport.Visible = true;
						cmdProcessNTSBReport.Visible = true;
					}
					else
					{
						MessageBox.Show("No Records Found Matching Search Date", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					}

				}
				else
				{
					MessageBox.Show($"Local CSV File Can NOT Be Found{Environment.NewLine}{strPath}{strFileName}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If gfso.FileExists(strPath & strFileName) = True Then

				rstRec3 = null;
				rstRec2 = null;
				rstRec1 = null;
				cntConn = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("LoadNTSBCSVFileInToGrid_Error: ", excep.Message);

				result = false;
			}
			return result;
		} // LoadNTSBCSVFileInToGrid

		private void cmdDownloadNTSBReport_Click(Object eventSender, EventArgs eventArgs)
		{
			StreamWriter tsFileWriter = null;

			FileStream tsFile = null;

			string strURL = "";
			string strURLParameters = "";
			string strLocalFile = "";
			string strFileName = "";
			System.DateTime dtDate = DateTime.FromOADate(0);
			bool bContinue = false;
			string strHTML = "";

			int lPos1 = 0;
			int lPos2 = 0;
			string strTemp = "";

			try
			{

				if (cmdDownloadNTSBReport.Enabled)
				{

					SetFormControlsEnable(false);

					if (((int) DateAndTime.DateDiff("d", DateTime.Parse(txtNTSBDate.Text), DateTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) <= 10)
					{

						modAdminCommon.Record_Event("NTSB Reports", $"Download NTSB Reports: {txtNTSBDate.Text}", 0, 0, 0);

						cmdReloadNTSBReport.Visible = false;
						cmdProcessNTSBReport.Visible = false;

						dtDate = mvNTSBCal.SelectionRange.Start;

						strURL = txtNTSBURL.Text;
						strURLParameters = txtNTSBURLParameters.Text;

						strFileName = $"{dtDate.ToString("yyyyMMdd")}.csv";
						strLocalFile = $"{gstrNTSBMstrPath}{strFileName}";
						bContinue = true;

						//---------------------------------------------------------------
						// Check To See If Master File Has Already Been Downloaded

						if (File.Exists(strLocalFile))
						{

							if (MessageBox.Show("Local NTSB Master File Already Exists, Re-Download", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
							{
								bContinue = false;
							}
							else
							{
								modAdminCommon.Record_Event("NTSB Reports", $"Download NTSB Reports - Overwrite Existing Report: {txtNTSBDate.Text}", 0, 0, 0);
								//UPGRADE_WARNING: (2081) DeleteFile has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
								File.Delete(strLocalFile); // Delete The Existing File
							}

						} // If gfso.FileExists(strLocalFile) = True Then

						if (bContinue)
						{

							//------------------------------------------------------------
							// Now Download Web Page
							// This WebPage Has The URL Parameters To Get The CSV File

							inNTSBInet.RequestTimeout = 48000;
							//inNTSBInet.AccessType = InetCtlsObjects.AccessConstants.icUseDefault; //gap-note check this line during blazor stabilization
							//inNTSBInet.Protocol = InetCtlsObjects.ProtocolConstants.icHTTP;//gap-note check this line during blazor stabilization

							//UPGRADE_WARNING: (1068) inNTSBInet.OpenURL() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
							strHTML = Convert.ToString(inNTSBInet.OpenURL($"{strURL}{strURLParameters}", Type.Missing));

							if (inNTSBInet.ResponseCode == 0)
							{

								//------------------------------------------------------
								// Need To Search For the faa_ai_prelim.csv file tab

								lPos1 = (strHTML.IndexOf(">csv format</A>") + 1);
								if (lPos1 > 0)
								{

									strTemp = strHTML.Substring(Math.Min(0, strHTML.Length), Math.Min(lPos1 - 2, Math.Max(0, strHTML.Length)));

									lPos1 = (strTemp.IndexOf("Preliminary Accident and Incident Notices are available in") + 1);
									if (lPos1 > 0)
									{

										strTemp = strTemp.Substring(Math.Min(lPos1 - 1, strTemp.Length));
										lPos1 = (strTemp.IndexOf("f?p=") + 1);
										strTemp = strTemp.Substring(Math.Min(lPos1 - 1, strTemp.Length));

										strURLParameters = strTemp;

										//UPGRADE_WARNING: (1068) inNTSBInet.OpenURL() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
										strHTML = Convert.ToString(inNTSBInet.OpenURL($"{strURL}{strURLParameters}", Type.Missing));

										if (inNTSBInet.ResponseCode == 0)
										{

											//---------------------------------------------
											// Save File To \NTSB\MASTER\ Directory

											tsFile = new FileStream(strLocalFile, FileMode.Create);
											tsFileWriter = new StreamWriter(tsFile);
											tsFileWriter.Write(strHTML.ToCharArray());
											tsFileWriter.Close();
											tsFile = null;

											cmdReloadNTSBReport.Visible = true;

											//---------------------------------------------
											// Now Open And Load Into Grid Based On Date

											if (LoadNTSBCSVFileInToGrid(gstrNTSBMstrPath, strFileName))
											{
												Application.DoEvents();
											} // If LoadNTSBCSVFileInToGrid(gstrNTSBMstrPath, strFileName) = True Then

										}
										else
										{
											MessageBox.Show($"NTSB - Error Downloading File: {inNTSBInet.ResponseCode.ToString()}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
										} // If inNTSBInet.ResponseCode = 0 Then

									}
									else
									{
										MessageBox.Show("NTSB - Could NOT Find CSV File (2)", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
									} // If lPos1 > 0 Then

								}
								else
								{
									MessageBox.Show("NTSB - Could NOT Find CSV File (1)", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
								} // If lPos1 > 0 Then

							}
							else
							{
								MessageBox.Show($"NTSB - Error Downloading File{Environment.NewLine}Error Code: {inNTSBInet.ResponseCode.ToString()}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							} // If inNTSBInet.ResponseCode = 0 Then

						} // If bContinue = True Then

					}
					else
					{
						MessageBox.Show($"Can NOT Download a File Dated Passed 10 Days [{txtNTSBDate.Text}]", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					} // If DateDiff("d", txtNTSBDate.Text, Now()) <= 10 Then

					SetFormControlsEnable(true);

				} // If cmdDownloadNTSBReport.Enabled = True Then
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("cmdDownloadNTSBReport_Click_Error: ", excep.Message);
			}

		} // cmdDownloadNTSBReport_Click


		private bool Add_NTSB_FAA_Document_Log(int iRow, ref int lFAALogId, ref string strACCTRep)
		{

			bool result = false;
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper(); // Get Account Rep
			ADORecordSetHelper rstRec2 = new ADORecordSetHelper(); // Make/Model
			ADORecordSetHelper rstAdd1 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strQuery2 = "";
			string strAdd1 = "";

			string strFrameNbr = "";
			string strEntryDate = "";
			string strEventDate = "";
			string strACId = "";
			string strFAALogId = "";

			int lCompId = 0;
			string strCompId = "";

			string strMake = "";
			string strModel = "";
			string strSerNbr = "";

			bool bResults = false;

			try
			{

				bResults = false;
				strACCTRep = "TN01";

				//-------------------------------
				// Can NOT Process Row Zero

				if (iRow > 0)
				{

					lCompId = 0;
					strCompId = "0";

					strMake = "";
					strModel = "";
					strSerNbr = "";
					strACId = Convert.ToString(fgridNTSB[iRow, 2].Value);

					strEntryDate = "";
					if (Information.IsDate(Convert.ToString(fgridNTSB[iRow, 9].Value)))
					{
						strEntryDate = Convert.ToString(fgridNTSB[iRow, 9].Value);
					}

					strEventDate = "";
					if (Information.IsDate(Convert.ToString(fgridNTSB[iRow, 10].Value)))
					{
						strEventDate = Convert.ToString(fgridNTSB[iRow, 10].Value);
					}

					//---------------------------------------------------------------------
					// Get Company Id and Account Rep From The Primary Point Of Contact

					strQuery1 = "SELECT DISTINCT comp_id, comp_account_id FROM Company WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1}INNER JOIN Aircraft_Reference WITH (NOLOCK) ON comp_id = cref_comp_id AND comp_journ_id = cref_journ_id ";
					strQuery1 = $"{strQuery1}WHERE (cref_ac_id = {strACId}) ";
					strQuery1 = $"{strQuery1}AND (cref_journ_id = 0)  AND (cref_primary_poc_flag = 'Y') ";

					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!rstRec1.BOF && !rstRec1.EOF)
					{
						lCompId = Convert.ToInt32(rstRec1["comp_id"]);
						strCompId = lCompId.ToString();
						strACCTRep = ($"{Convert.ToString(rstRec1["comp_account_id"])} ").Trim();
					}

					rstRec1.Close();

					//-------------------------------------
					// Set The Account Rep In The Grid

					fgridNTSB[iRow, 12].Value = strACCTRep;

					//----------------------------------
					// Get Make/Model For ACID

					strQuery2 = "SELECT amod_make_name, amod_model_name, ac_ser_no_full FROM Aircraft_Model WITH (NOLOCK) ";
					strQuery2 = $"{strQuery2}INNER JOIN Aircraft WITH (NOLOCK) ON amod_id = ac_amod_id ";
					strQuery2 = $"{strQuery2}WHERE (ac_id = {strACId})  AND (ac_journ_id = 0) ";

					rstRec2.Open(strQuery2, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!rstRec2.BOF && !rstRec2.EOF)
					{
						strMake = ($"{Convert.ToString(rstRec2["amod_make_name"])} ").Trim();
						strModel = ($"{Convert.ToString(rstRec2["amod_model_name"])} ").Trim();
						strSerNbr = ($"{Convert.ToString(rstRec2["ac_ser_no_full"])} ").Trim();
					}

					rstRec2.Close();

					//-------------------------------------------------
					// Now Add Record To FAA_Document_Log Table

					strAdd1 = "SELECT * FROM FAA_Document_Log  WHERE (faalog_id = -1) ";

					rstAdd1.CursorLocation = CursorLocationEnum.adUseClient;
					rstAdd1.Open(strAdd1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);

					rstAdd1.AddNew();
					rstAdd1["faalog_ac_id"] = Convert.ToInt32(Double.Parse(strACId));
					rstAdd1["faalog_journ_id"] = 0;
					rstAdd1["faalog_journ_seq_no"] = 0;
					rstAdd1["faalog_tape_of"] = 0;
					rstAdd1["faalog_tape_to"] = 0;
					rstAdd1["faalog_starting_frame_no"] = iRow;
					rstAdd1["faalog_ending_frame_no"] = iRow;

					if (strEntryDate != "")
					{
						rstAdd1["faalog_tape_date"] = DateTime.Parse(strEntryDate);
					}

					if (strEventDate != "")
					{
						rstAdd1["faalog_document_date"] = DateTime.Parse(strEventDate);
					}

					rstAdd1["faalog_general_note"] = "";
					rstAdd1["faalog_make_name"] = strMake;
					rstAdd1["faalog_ser_no_full"] = strSerNbr;
					rstAdd1["faalog_doc_type"] = "NTS";
					rstAdd1["faalog_user_id"] = strACCTRep;

					rstAdd1["faalog_rolled_by_user_id"] = modAdminCommon.gbl_User_ID.ToUpper();
					rstAdd1.UpdateBatch();

					//---------------------------
					// Get The New FAA Log Id

					lFAALogId = Convert.ToInt32(rstAdd1["faalog_id"]);
					strFAALogId = lFAALogId.ToString();

					rstAdd1.Close();

					fgridNTSB[iRow, 11].Value = strFAALogId;
					bResults = true;

				}
				else
				{
					MessageBox.Show("NTSB FAA Document Log - Can NOT Process Row Zero", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If iRow > 0 Then

				rstRec2 = null;
				rstRec1 = null;
				rstAdd1 = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Add_NTSB_FAA_Document_Log_Error: ", excep.Message);
				result = false;
			}
			return result;
		} // Add_NTSB_FAA_Document_Log

		private bool Add_NTSB_Journal_Record(int iRow, string strACCTRep, ref int lJournId)
		{

			bool result = false;
			ADORecordSetHelper rstAdd1 = new ADORecordSetHelper();
			string strAdd1 = "";

			string strACId = "";

			bool bResults = false;

			try
			{

				bResults = false;
				lJournId = 0;

				if (iRow > 0)
				{

					strACId = Convert.ToString(fgridNTSB[iRow, 2].Value);

					//-------------------------------------------------
					// Now Add Record To Journal Table

					strAdd1 = "SELECT * FROM Journal ";
					strAdd1 = $"{strAdd1}WHERE (journ_id = -1) ";

					rstAdd1.CursorLocation = CursorLocationEnum.adUseClient;
					rstAdd1.Open(strAdd1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);

					rstAdd1.AddNew();
					rstAdd1["journ_date"] = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy"));
					rstAdd1["journ_entry_date"] = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy"));
					rstAdd1["journ_entry_time"] = DateTime.Parse(DateTime.Now.ToString("HH:mm:ss"));
					rstAdd1["journ_subcategory_code"] = "RA";
					rstAdd1["journ_subject"] = "NTSB Report in Process";
					rstAdd1["journ_description"] = " ";
					rstAdd1["journ_ac_id"] = Convert.ToInt32(Double.Parse(strACId));
					rstAdd1["journ_comp_id"] = 0;
					rstAdd1["journ_contact_id"] = 0;
					rstAdd1["journ_account_id"] = strACCTRep;
					rstAdd1["journ_prior_account_id"] = " ";
					rstAdd1["journ_status"] = "P";
					rstAdd1["journ_user_id"] = modAdminCommon.gbl_User_ID.ToUpper();
					rstAdd1["journ_action_date"] = DateTime.Now;
					rstAdd1.UpdateBatch();

					//-------------------------
					// Now Get Journal Id

					lJournId = Convert.ToInt32(rstAdd1["journ_id"]);

					rstAdd1.Close();

					bResults = true;

				}
				else
				{
					MessageBox.Show("NTSB Journal - Can NOT Process Row Zero", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If iRow > 0 Then

				rstAdd1 = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Add_NTSB_Journal_Record_Error: ", excep.Message);
				result = false;
			}
			return result;
		} // Add_NTSB_Journal_Record

		// ====================================================================================
		// Written By : David D. Cruger
		// Created    : 04/15/2013
		// Modified   : 04/15/2013
		// Function   : Add_NTSB_Hot_Box_Record
		// Parameters : ByVal iRow As Integer
		//              ByVal strACCTRep As String
		//              ByVal lJournId As Long
		//
		// Returns    : Boolean
		//
		// Notes      : Removes all Hot Box Summary records for this ACID and re-adds them
		// back on. The returns true if successful.
		//
		// ====================================================================================

		private bool Add_NTSB_Hot_Box_Record(int iRow, string strACCTRep, int lJournId)
		{

			bool result = false;
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			ADORecordSetHelper rstAdd1 = new ADORecordSetHelper();
			string strAdd1 = "";

			string strACId = "";

			bool bResults = false;

			try
			{

				bResults = false;

				//-------------------------------
				// Can NOT Process Row Zero

				if (iRow > 0)
				{

					if (lJournId > 0)
					{

						strACId = Convert.ToString(fgridNTSB[iRow, 2].Value);

						//-------------------------------------------------
						// Get Hot Box Summary Information

						strQuery1 = "SELECT ";

						//----------------------------
						// Journal Information
						strQuery1 = $"{strQuery1}journ_entry_date, journ_entry_time, journ_ac_id,  journ_id, ";
						strQuery1 = $"{strQuery1}journ_user_id, journ_subject, journ_description, journ_status, ";

						//--------------------------------------
						// Make/Model-Aircraft Information
						strQuery1 = $"{strQuery1}amod_id,  amod_airframe_type_code, amod_type_code, ";
						strQuery1 = $"{strQuery1}amod_make_name, amod_model_name, ac_id, ";
						strQuery1 = $"{strQuery1}ac_ser_no_full, ac_reg_no, ";
						strQuery1 = $"{strQuery1}ac_product_business_flag, ac_product_helicopter_flag,  ac_product_commercial_flag, ";

						strQuery1 = $"{strQuery1}comp_id, comp_name, comp_account_id,  cref_contact_id ";
						strQuery1 = $"{strQuery1}FROM Journal WITH (NOLOCK) ";
						strQuery1 = $"{strQuery1}INNER JOIN Aircraft WITH (NOLOCK) ON journ_ac_id = ac_id AND ac_journ_id = 0 ";
						strQuery1 = $"{strQuery1}INNER JOIN Aircraft_Model WITH (NOLOCK) ON ac_amod_id = amod_id ";
						strQuery1 = $"{strQuery1}LEFT JOIN Aircraft_Reference WITH (NOLOCK) ON ac_id = cref_ac_id AND cref_journ_id = 0 ";
						strQuery1 = $"{strQuery1}LEFT JOIN Company WITH (NOLOCK) ON cref_comp_id = comp_id AND comp_journ_id = 0 ";
						strQuery1 = $"{strQuery1}WHERE (journ_id = {lJournId.ToString()})  AND (journ_ac_id = {strACId}) ";

						rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

						if (!rstRec1.BOF && !rstRec1.EOF)
						{

							//-------------------------------------------------
							// Now Add Record To Hot Box Summary Table

							strAdd1 = "SELECT * FROM Hot_Box_Summary WHERE (hbs_id = -1) ";

							rstAdd1.CursorLocation = CursorLocationEnum.adUseClient;
							rstAdd1.Open(strAdd1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);

							do 
							{ // Loop Until rstRec1.EOF = True

								rstAdd1.AddNew();

								//----------------------------
								// Journal Information
								//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
								rstAdd1["hbs_entry_date"] = Convert.ToDouble(rstRec1["journ_entry_date"]) + Convert.ToDouble(rstRec1["journ_entry_time"]);
								rstAdd1["hbs_ac_id"] = rstRec1["AC_ID"];
								rstAdd1["hbs_journ_id"] = rstRec1["journ_id"];
								rstAdd1["hbs_user_id"] = ($"{Convert.ToString(rstRec1["journ_user_id"])} ").Trim();
								rstAdd1["hbs_subject"] = ($"{Convert.ToString(rstRec1["journ_subject"])} ").Trim();
								rstAdd1["hbs_description"] = ($"{Convert.ToString(rstRec1["journ_description"])} ").Trim();
								rstAdd1["hbs_status"] = ($"{Convert.ToString(rstRec1["journ_status"])} ").Trim();

								//---------------------------------------
								// Make/Model-Aircraft Information
								rstAdd1["hbs_amod_id"] = rstRec1["amod_id"];
								rstAdd1["hbs_airframe_type_code"] = ($"{Convert.ToString(rstRec1["amod_airframe_type_code"])} ").Trim();
								rstAdd1["hbs_type_code"] = ($"{Convert.ToString(rstRec1["amod_type_code"])} ").Trim();
								rstAdd1["hbs_make_name"] = ($"{Convert.ToString(rstRec1["amod_make_name"])} ").Trim();
								rstAdd1["hbs_model_name"] = ($"{Convert.ToString(rstRec1["amod_model_name"])} ").Trim();
								rstAdd1["hbs_ser_no_full"] = ($"{Convert.ToString(rstRec1["ac_ser_no_full"])} ").Trim();
								rstAdd1["hbs_reg_no"] = ($"{Convert.ToString(rstRec1["ac_reg_no"])} ").Trim();
								rstAdd1["hbs_ac_product_business_flag"] = ($"{Convert.ToString(rstRec1["ac_product_business_flag"])} ").Trim();
								rstAdd1["hbs_ac_product_helicopter_flag"] = ($"{Convert.ToString(rstRec1["ac_product_helicopter_flag"])} ").Trim();
								rstAdd1["hbs_ac_product_commercial_flag"] = ($"{Convert.ToString(rstRec1["ac_product_commercial_flag"])} ").Trim();

								//-------------------------------
								// Company Information
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(rstRec1["comp_id"]))
								{
									rstAdd1["hbs_comp_id"] = rstRec1["comp_id"];
									rstAdd1["hbs_comp_name"] = ($"{Convert.ToString(rstRec1["comp_name"])} ").Trim();
									rstAdd1["hbs_comp_account_id"] = ($"{Convert.ToString(rstRec1["comp_account_id"])} ").Trim();
									rstAdd1["hbs_contact_id"] = rstRec1["cref_contact_id"];
								}

								rstAdd1.UpdateBatch();
								rstRec1.MoveNext();
								Application.DoEvents();

							}
							while(!rstRec1.EOF);

							rstAdd1.Close();

							bResults = true;

						}
						else
						{
							MessageBox.Show("NTSB Hot Box - Unable To Find Hot Box Information To ADD", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						} // If rstRec1.BOF = False And rstRec1.EOF = False Then

						rstRec1.Close();

					}
					else
					{
						MessageBox.Show("NTSB Hot Box - Can NOT Process JournId Zero", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					} // If lJournId > 0 Then

				}
				else
				{
					MessageBox.Show("NTSB Hot Box - Can NOT Process Row Zero", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If iRow > 0 Then

				rstRec1 = null;
				rstAdd1 = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Add_NTSB_Hot_Box_Record_Error: ", excep.Message);
				result = false;
			}
			return result;
		} // Add_NTSB_Hot_Box_Record


		private string ReturnInjuryHTML(string strTitle, string strNone, string strMinor, string strSerious, string strFatal, string strUnknown)
		{

			string strTemp = "";

			string strResults = $"{strTitle} ";
			int lTot1 = Convert.ToInt32(Double.Parse($"0{strNone}")) + Convert.ToInt32(Double.Parse($"0{strMinor}")) + Convert.ToInt32(Double.Parse($"0{strSerious}")) + Convert.ToInt32(Double.Parse($"0{strFatal}")) + Convert.ToInt32(Double.Parse($"0{strUnknown}"));
			strResults = $"{strResults}{StringsHelper.Format(lTot1, "0")} ";
			strResults = $"{strResults}Fat: {StringsHelper.Format($"0{strFatal}", "0")} ";
			strResults = $"{strResults}Ser: {StringsHelper.Format($"0{strSerious}", "0")} ";
			strResults = $"{strResults}Minor: {StringsHelper.Format($"0{strMinor}", "0")} ";
			strResults = $"{strResults}Unkn: {StringsHelper.Format($"0{strUnknown}", "0")} ";
			strResults = $"{strResults}None: {StringsHelper.Format($"0{strNone}", "0")} ";

			return strResults;

		} // ReturnInjuryHTML


		private bool Create_NTSB_HTML_Document(int iRow, int lFAALogId)
		{
			bool result = false;
			StreamWriter tsFileWriter = null;

			DbConnection cntConn = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateConnection();
			string strConn = "";

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			FileStream tsFile = null;

			string strHTMLFileName = "";
			string strHTMLLocalFile = "";

			string strCSVFileName = "";
			string strCSVLocalFile = "";

			string strACId = "";
			string strRegNbr = "";
			string strEntryDate = "";
			string strEventDate = "";

			string strHTML = "";
			string strHeader = "";
			string strIdentification = "";
			string strDate = "";
			string strEventType = "";
			string strDamage = "";
			string strOperator = "";
			string strLocation = "";
			string strDescription = "";
			string strInjuryData = "";
			string strOtherData = "";
			string strFooter = "";
			string strTemp = "";
			int lTot1 = 0;
			bool bFound = false;

			System.DateTime dtEntryDate1 = DateTime.FromOADate(0);
			System.DateTime dtEntryDate2 = DateTime.FromOADate(0);
			System.DateTime dtEventDate1 = DateTime.FromOADate(0);
			System.DateTime dtEventDate2 = DateTime.FromOADate(0);

			bool bResults = false;

			try
			{

				bResults = false;

				strHTMLFileName = $"{lFAALogId.ToString()}.html";
				strHTMLLocalFile = $"{gstrNTSBProcessingPath}{strHTMLFileName}";

				if (File.Exists(strHTMLLocalFile))
				{
					File.Delete(strHTMLLocalFile);
				}

				strCSVFileName = $"{DateTime.Parse(txtNTSBDate.Text).ToString("yyyyMMdd")}.csv";
				strCSVLocalFile = $"{gstrNTSBMstrPath}{strCSVFileName}";

				if (File.Exists(strCSVLocalFile))
				{

					strACId = Convert.ToString(fgridNTSB[iRow, 2].Value);
					strRegNbr = Convert.ToString(fgridNTSB[iRow, 4].Value);
					strEntryDate = Convert.ToString(fgridNTSB[iRow, 9].Value);
					strEventDate = Convert.ToString(fgridNTSB[iRow, 10].Value);

					dtEntryDate1 = DateTime.FromOADate(0);
					if (Information.IsDate(strEntryDate))
					{
						dtEntryDate1 = DateTime.Parse(strEntryDate);
					}

					dtEventDate1 = DateTime.FromOADate(0);
					if (Information.IsDate(strEventDate))
					{
						dtEventDate1 = DateTime.Parse(strEventDate);
					}

					//-----------------------------------
					// Open CSV File Connection

					strConn = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={gstrNTSBMstrPath};Extended Properties='text;FMT=Delimited'";
					//UPGRADE_ISSUE: (2064) ADODB.Connection property cntConn.ConnectionTimeout was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					cntConn.setConnectionTimeout(30);
					//UPGRADE_ISSUE: (2064) ADODB.Connection property cntConn.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					cntConn.setCursorLocation(CursorLocationEnum.adUseClient);
					//UPGRADE_TODO: (7010) The connection string must be verified to fullfill the .NET data provider connection string requirements. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-7010
					cntConn.ConnectionString = strConn;
					cntConn.Open();

					strQuery1 = $"SELECT * FROM {strCSVFileName}";

					rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						// Now Find RegNbr
						bFound = false;

						do 
						{

							if (strRegNbr == ($"{Convert.ToString(rstRec1["REGIST_NBR"])} ").Trim())
							{
								bFound = true;
							}
							else
							{
								rstRec1.MoveNext();
							}

						}
						while(!(rstRec1.EOF || bFound));

					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						//--------------------------------------------------
						// Check To Make Sure The Entry and Event Data
						// In the Recordset Match What Is In The Grid

						dtEntryDate2 = DateTime.FromOADate(0);
						if (Information.IsDate(rstRec1["ENTRY_DATE"]))
						{
							dtEntryDate2 = Convert.ToDateTime(rstRec1["ENTRY_DATE"]);
						}

						dtEventDate2 = DateTime.FromOADate(0);
						if (Information.IsDate(rstRec1["EVENT_LCL_DATE"]))
						{
							dtEventDate2 = Convert.ToDateTime(rstRec1["EVENT_LCL_DATE"]);
						}

						if ((dtEntryDate1 == dtEntryDate2) && (dtEventDate1 == dtEventDate2))
						{

							strHeader = $"**  Report created {DateTime.Now.ToString("MM/dd/yyyy")}  Record {iRow.ToString()}{new string(' ', 35)}**<br/>";
							strHeader = $"{strHeader}{new string('*', 80)}<br/><br/>";

							strIdentification = $"IDENTIFICATION<br/><b>Regis#:</b> {($"{Convert.ToString(rstRec1["REGIST_NBR"])} ").Trim()} ";
							strIdentification = $"{strIdentification}<b>Make:</b> {($"{Convert.ToString(rstRec1["ACFT_MAKE_NAME"])} ").Trim()} ";
							strIdentification = $"{strIdentification}<b>Model:</b> {($"{Convert.ToString(rstRec1["ACFT_MODEL_NAME"])} ").Trim()} ";
							strIdentification = $"{strIdentification}<b>FAR Part:</b> {($"{Convert.ToString(rstRec1["FAR_PART"])} ").Trim()}<br/>";

							strDate = "Entry Date: ";
							strTemp = ($"{Convert.ToString(rstRec1["ENTRY_DATE"])} ").Trim();
							if (strTemp != "")
							{
								if (Information.IsDate(strTemp))
								{
									System.DateTime TempDate2 = DateTime.FromOADate(0);
									strDate = $"{strDate}{((DateTime.TryParse(strTemp, out TempDate2)) ? TempDate2.ToString("MM/dd/yyyy") : strTemp)} ";
								}
							}
							strDate = $"{strDate}<br/>";

							strDate = $"{strDate}Event Date: ";
							strTemp = ($"{Convert.ToString(rstRec1["EVENT_LCL_DATE"])} ").Trim();
							if (strTemp != "")
							{
								if (Information.IsDate(strTemp))
								{
									System.DateTime TempDate3 = DateTime.FromOADate(0);
									strDate = $"{strDate}{((DateTime.TryParse(strTemp, out TempDate3)) ? TempDate3.ToString("MM/dd/yyyy") : strTemp)} ";
								}
							}

							strDate = $"{strDate}Time: ";
							strTemp = ($"{Convert.ToString(rstRec1["EVENT_LCL_TIME"])} ").Trim();
							if (strTemp != "")
							{
								strTemp = StringsHelper.Replace(strTemp, "Z", "", 1, -1, CompareMethod.Binary);
								if (Information.IsDate(strTemp))
								{
									System.DateTime TempDate4 = DateTime.FromOADate(0);
									strDate = $"{strDate}{((DateTime.TryParse(strTemp, out TempDate4)) ? TempDate4.ToString("HH:mm") : strTemp)} ";
								}
							}

							strDate = $"{strDate}<br/><br/>";

							strEventType = $"Event Type: {($"{Convert.ToString(rstRec1["EVENT_TYPE_DESC"])} ").Trim()} ";
							strEventType = $"{strEventType}Injury: Serious: {($"{Convert.ToString(rstRec1["MAX_INJ_LVL"])} ").Trim()} ";

							strEventType = $"{strEventType}Missing: {($"{Convert.ToString(rstRec1["ACFT_MISSING_FLAG"])} ").Trim()}<br/>";

							strDamage = $"Damage: {($"{Convert.ToString(rstRec1["ACFT_DMG_DESC"])} ").Trim()}<br/><br/>";

							strOperator = $"<b>OPERATOR</b> {($"{Convert.ToString(rstRec1["ACFT_OPRTR"])} ").Trim()}<br/><br/>";

							strLocation = "<b>LOCATION</b><br/>";
							strLocation = $"{strLocation}City: {($"{Convert.ToString(rstRec1["LOC_CITY_NAME"])} ").Trim()} ";
							strLocation = $"{strLocation}PAGE State: {($"{Convert.ToString(rstRec1["LOC_STATE_NAME"])} ").Trim()} ";
							strLocation = $"{strLocation}Country: {($"{Convert.ToString(rstRec1["LOC_CNTRY_NAME"])} ").Trim()}<br/><br/>";

							strDescription = "<b>DESCRIPTION</b><br/>";
							strDescription = $"{strDescription}{($"{Convert.ToString(rstRec1["RMK_TEXT"])} ").Trim()}<br/><br/>";

							strInjuryData = "<b>INJURY DATA</b> Total Fatal: ";
							lTot1 = 0;
							if (Convert.ToString(rstRec1["FATAL_FLAG"]).Trim().ToUpper() == "YES")
							{
								strTemp = ($"{Convert.ToString(rstRec1["FLT_CRW_INJ_FATAL"])} ").Trim();
								if (Information.IsNumeric(strTemp))
								{
									lTot1 += Convert.ToInt32(Double.Parse(strTemp));
								}
								strTemp = ($"{Convert.ToString(rstRec1["CBN_CRW_INJ_FATAL"])} ").Trim();
								if (Information.IsNumeric(strTemp))
								{
									lTot1 += Convert.ToInt32(Double.Parse(strTemp));
								}
								strTemp = ($"{Convert.ToString(rstRec1["PAX_INJ_FATAL"])} ").Trim();
								if (Information.IsNumeric(strTemp))
								{
									lTot1 += Convert.ToInt32(Double.Parse(strTemp));
								}
								strTemp = ($"{Convert.ToString(rstRec1["GRND_INJ_FATAL"])} ").Trim();
								if (Information.IsNumeric(strTemp))
								{
									lTot1 += Convert.ToInt32(Double.Parse(strTemp));
								}
							}
							strInjuryData = $"{strInjuryData}{StringsHelper.Format(lTot1, "0")}<br/>";

							strInjuryData = $"{strInjuryData}{ReturnInjuryHTML("# Flight-Crew:", ($"{Convert.ToString(rstRec1["FLT_CRW_INJ_NONE"])} ").Trim(), ($"{Convert.ToString(rstRec1["FLT_CRW_INJ_MINOR"])} ").Trim(), ($"{Convert.ToString(rstRec1["FLT_CRW_INJ_SERIOUS"])} ").Trim(), ($"{Convert.ToString(rstRec1["FLT_CRW_INJ_FATAL"])} ").Trim(), ($"{Convert.ToString(rstRec1["FLT_CRW_INJ_UNK"])} ").Trim())}<br/>";

							strInjuryData = $"{strInjuryData}{ReturnInjuryHTML("# Passenger:", ($"{Convert.ToString(rstRec1["PAX_INJ_NONE"])} ").Trim(), ($"{Convert.ToString(rstRec1["PAX_INJ_MINOR"])} ").Trim(), ($"{Convert.ToString(rstRec1["PAX_INJ_SERIOUS"])} ").Trim(), ($"{Convert.ToString(rstRec1["PAX_INJ_FATAL"])} ").Trim(), ($"{Convert.ToString(rstRec1["PAX_INJ_UNK"])} ").Trim())}<br/>";

							strInjuryData = $"{strInjuryData}{ReturnInjuryHTML("# Cabin-Crew:", ($"{Convert.ToString(rstRec1["CBN_CRW_INJ_NONE"])} ").Trim(), ($"{Convert.ToString(rstRec1["CBN_CRW_INJ_MINOR"])} ").Trim(), ($"{Convert.ToString(rstRec1["CBN_CRW_INJ_SERIOUS"])} ").Trim(), ($"{Convert.ToString(rstRec1["CBN_CRW_INJ_FATAL"])} ").Trim(), ($"{Convert.ToString(rstRec1["CBN_CRW_INJ_UNK"])} ").Trim())}<br/>";

							strInjuryData = $"{strInjuryData}{ReturnInjuryHTML("# Ground-Crew:", ($"{Convert.ToString(rstRec1["GRND_INJ_NONE"])} ").Trim(), ($"{Convert.ToString(rstRec1["GRND_INJ_MINOR"])} ").Trim(), ($"{Convert.ToString(rstRec1["GRND_INJ_SERIOUS"])} ").Trim(), ($"{Convert.ToString(rstRec1["GRND_INJ_FATAL"])} ").Trim(), ($"{Convert.ToString(rstRec1["GRND_INJ_UNK"])} ").Trim())}<br/><br/>";

							strOtherData = $"<b>OTHER DATA</b><br/>Activity: {($"{Convert.ToString(rstRec1["FLT_ACTIVITY"])} ").Trim()}<br/>";
							strOtherData = $"{strOtherData}Phase: {($"{Convert.ToString(rstRec1["FLT_PHASE"])} ").Trim()}<br/>";
							strOtherData = $"{strOtherData}Flight Nbr: {($"{Convert.ToString(rstRec1["FLT_NBR"])} ").Trim()}<br/>";
							strOtherData = $"{strOtherData}FAA FSDO: {($"{Convert.ToString(rstRec1["FSDO_DESC"])} ").Trim()}<br/><br/>";

							strFooter = $"{new string('*', 80)}<br/>";

							strHTML = "";

							strHTML = $"{strHTML}<STYLE>TABLE{{";
							strHTML = $"{strHTML}    FONT-SIZE: 8pt;";
							strHTML = $"{strHTML}    FONT-FAMILY: Arial;";
							strHTML = $"{strHTML}}}</STYLE><HTML>=<BODY><PRE>";
							strHTML = $"{strHTML}<FONT face='Arial' SIZE='2'>";

							strHTML = $"{strHTML}{strHeader}{strIdentification}{strDate}";
							strHTML = $"{strHTML}{strEventType}{strDamage}{strOperator}{strLocation}";
							strHTML = $"{strHTML}{strDescription}{strInjuryData}{strOtherData}{strFooter}";

							strHTML = $"{strHTML}</FONT></PRE></BODY></HTML>";


							tsFile = new FileStream(strHTMLLocalFile, FileMode.Create);
							tsFileWriter = new StreamWriter(tsFile);
							tsFileWriter.Write(strHTML.ToCharArray());
							tsFileWriter.Close();
							tsFile = null;

							bResults = true;

						}
						else
						{
							MessageBox.Show($"Unable To Create HTML Document Cound NOT Find Record In CSV File For ACID: {strACId}  RegNbr: {strRegNbr}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						} // If CDate(strEntryDate) = CDate(rstRec1!ENTRY_DATE) And CDate(strEventDate) = CDate(rstRec1!EVENT_LCL_DATE) Then

					}
					else
					{
						MessageBox.Show($"Unable To Create HTML Document CSV File Is Empty{strCSVLocalFile}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();
					UpgradeHelpers.DB.TransactionManager.DeEnlist(cntConn);
					cntConn.Close();

				}
				else
				{
					MessageBox.Show($"Unable To Create HTML Document CSV File Does NOT Exist{strCSVLocalFile}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If gfso.FileExists(strCSVLocalFile) = True Then

				rstRec1 = null;
				cntConn = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Create_NTSB_HTML_Document_Error:", excep.Message);
				result = false;
			}
			return result;
		} // Create_NTSB_HTML_Document


		private bool Create_And_Send_EMail_Notice()
		{
			StreamWriter tsFileWriter = null;

			bool bResults = false;

			FileStream tsFile = null;

			string strTo = "";
			string strCC = "";
			string strBCC = "";
			string strSubject = "";
			string strBody = "";
			string strFromName = "";
			string strFromEMail = "";
			string strAttachment = "";
			int iRow = 0;
			int iTot = 0;

			string strFAALogId = "";
			string strHRef = "";

			string strFileName = "";
			string strLocalFile = "";

			string strHTMLFileName = "";
			string strHTMLLocalFile = "";

			string strStatus = "";
			string strACId = "";
			string strRegNbr = "";
			string strHBMake = "";
			string strMake = "";
			string strACCTRep = "";
			string strDescription = "";

			try
			{

				bResults = false;

				if (fgridNTSB.RowsCount >= 1)
				{

					strFileName = $"NTSB_EMail_Notice_{StringsHelper.Format(DateTime.Now, "yyymmdd_hhMMss")}.html";
					strLocalFile = $"{gstrNTSBEMailPath}{strFileName}";

					if (File.Exists(strLocalFile))
					{
						//UPGRADE_WARNING: (2081) DeleteFile has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
						File.Delete(strLocalFile);
					}

					strTo = modCommon.DLookUp("aconfig_ntsb_email_address", "Application_Configuration");
					strCC = "";
					strBCC = "";
					strAttachment = "";

					strFromName = "Homebase NTSB";
					strFromEMail = "service@jetnet.com";

					strSubject = $"NTSB Report Processing Summary for {DateTime.Now.ToString("MM/dd/yyyy")}";

					strBody = $"<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>{Environment.NewLine}";
					strBody = $"{strBody}<HTML xmlns='http://www.w3.org/1999/xhtml' xml:lang='en' lang='en'>{Environment.NewLine}";
					strBody = $"{strBody}<HEAD>{Environment.NewLine}";
					strBody = $"{strBody}<META http-equiv='Content-Language' content='en-us'/>{Environment.NewLine}";
					strBody = $"{strBody}<META http-equiv='Content-Type' content='text/html; charset=windows-1252'/>{Environment.NewLine}";
					strBody = $"{strBody}</HEAD>{Environment.NewLine}{Environment.NewLine}";

					strBody = $"{strBody}<BODY>{Environment.NewLine}";

					strBody = $"{strBody}<TABLE border='1' cellspacing='1' cellpadding='1'>{Environment.NewLine}";
					strBody = $"{strBody}<TBODY STYLE='font-family: Courier New; font-size:8pt;'>{Environment.NewLine}{Environment.NewLine}";

					strBody = $"{strBody}<tr>{Environment.NewLine}";
					strBody = $"{strBody}<td colspan='8'>{Environment.NewLine}";
					strBody = $"{strBody}<PRE>{Environment.NewLine}";
					strBody = $"{strBody}Date/Time: {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}{Environment.NewLine}";
					strBody = $"{strBody}To       : {strTo}{Environment.NewLine}";
					strBody = $"{strBody}From     : {strFromName}{Environment.NewLine}";
					strBody = $"{strBody}Subject  : {strSubject}{Environment.NewLine}";
					strBody = $"{strBody}</PRE>{Environment.NewLine}</td>{Environment.NewLine}</tr>{Environment.NewLine}{Environment.NewLine}";

					strBody = $"{strBody}<tr><td colspan='8'>&nbsp;</td></tr>{Environment.NewLine}{Environment.NewLine}";

					strBody = $"{strBody}<tr>{Environment.NewLine}<th align='center'>STATUS</th>{Environment.NewLine}";
					strBody = $"{strBody}<th align='center'>ACID</th>{Environment.NewLine}";
					strBody = $"{strBody}<th align='center'>FAALOGID</th>{Environment.NewLine}";
					strBody = $"{strBody}<th align='center'>REGNBR</th>{Environment.NewLine}";
					strBody = $"{strBody}<th align='center'>HB-MAKE</th>{Environment.NewLine}";
					strBody = $"{strBody}<th align='center'>MAKE</th>{Environment.NewLine}";
					strBody = $"{strBody}<th align='center'>ACCTREP</th>{Environment.NewLine}";
					strBody = $"{strBody}<th align='center'>DESCRIPTION</th>{Environment.NewLine}</tr>{Environment.NewLine}{Environment.NewLine}";

					iRow = 0;
					iTot = 0;

					do 
					{ // Loop Until iRow >= fgridNTSB.Rows-1

						iRow++;

						strBody = $"{strBody}<tr>{Environment.NewLine}";

						strStatus = Convert.ToString(fgridNTSB[iRow, 1].Value);
						strACId = Convert.ToString(fgridNTSB[iRow, 2].Value);
						strFAALogId = Convert.ToString(fgridNTSB[iRow, 11].Value);
						strRegNbr = Convert.ToString(fgridNTSB[iRow, 4].Value);
						strHBMake = Convert.ToString(fgridNTSB[iRow, 3].Value);
						strMake = Convert.ToString(fgridNTSB[iRow, 5].Value);
						strACCTRep = Convert.ToString(fgridNTSB[iRow, 12].Value);
						strDescription = Convert.ToString(fgridNTSB[iRow, 8].Value);

						strBody = $"{strBody}<td align='center'>{strStatus}&nbsp;</td>{Environment.NewLine}"; // Status/Process
						strBody = $"{strBody}<td align='center'>{strACId}&nbsp;</td>{Environment.NewLine}"; // ACId

						if (Convert.ToString(fgridNTSB[iRow, 1].Value) == "LOADED")
						{
							iTot++;
							strHTMLFileName = $"{strFAALogId}.html";
							strHTMLLocalFile = $"{gstrNTSBProcessingPath}{strHTMLFileName}";
							strHRef = $"<a target='_blank' title='Click To View NTSB HTML Report' href='{strHTMLLocalFile}'>{strFAALogId}</a>";
							strBody = $"{strBody}<th align='center'>{strHRef}</th>{Environment.NewLine}";
						}
						else
						{
							strBody = $"{strBody}<td align='right'>{strFAALogId}&nbsp;</td>{Environment.NewLine}"; // FAALogId
						}

						strBody = $"{strBody}<td align='left' nowrap>{strRegNbr}&nbsp;</td>{Environment.NewLine}"; // RegNbr
						strBody = $"{strBody}<td align='left' nowrap>{strHBMake}&nbsp;</td>{Environment.NewLine}"; // HB-Make
						strBody = $"{strBody}<td align='left' nowrap>{strMake}&nbsp;</td>{Environment.NewLine}"; // Make/Model
						strBody = $"{strBody}<td align='center' nowrap>{strACCTRep}&nbsp;</td>{Environment.NewLine}"; // Account Rep
						strBody = $"{strBody}<td align='left'>{strDescription}&nbsp;</td>{Environment.NewLine}"; // Description

						strBody = $"{strBody}</tr>{Environment.NewLine}{Environment.NewLine}";

					}
					while(iRow < fgridNTSB.RowsCount - 1);

					strBody = $"{strBody}{Environment.NewLine}";
					strBody = $"{strBody}<tr>{Environment.NewLine}";
					strBody = $"{strBody}<td colspan='8' align='left'>{Environment.NewLine}";
					strBody = $"{strBody}Total of {iRow.ToString()} records processed.  Reports loaded {iTot.ToString()}{Environment.NewLine}";
					strBody = $"{strBody}</td>{Environment.NewLine}";
					strBody = $"{strBody}</tr>{Environment.NewLine}{Environment.NewLine}";

					strBody = $"{strBody}</TBODY'>{Environment.NewLine}</TABLE>{Environment.NewLine}{Environment.NewLine}</BODY>{Environment.NewLine}</HTML>{Environment.NewLine}";

					//---------------------------------------------
					// Save File To \NTSB\EMAIL\ Directory

					tsFile = new FileStream(strLocalFile, FileMode.Create);
					tsFileWriter = new StreamWriter(tsFile);
					tsFileWriter.Write(strBody.ToCharArray());
					tsFileWriter.Close();
					tsFile = null;

					bResults = modEmail.EMail_Message(strFromName, strFromEMail, strTo, strCC, strBCC, strSubject, strBody, strAttachment, true);

				} // If fgridNTSB.Rows >= 1 Then


				return bResults;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Create_And_Send_EMail_Notice_Error:", excep.Message);
			}
			return false;
		} // Create_And_Send_EMail_Notice


		private void cmdProcessNTSBReport_Click(Object eventSender, EventArgs eventArgs)
		{

			int iRow = 0;
			int iCol = 0;

			string strACId = "";
			string strProcess = "";
			int lFAALogId = 0;
			string strFAALogId = "";
			string strACCTRep = "";
			int lJournId = 0;

			bool bProcessed = false;
			bool bStop = false;

			if (cmdProcessNTSBReport.Enabled)
			{

				SetFormControlsEnable(false);

				modAdminCommon.Record_Event("NTSB Reports", $"Process NTSB Reports: {txtNTSBDate.Text}", 0, 0, 0);

				iRow = 0;
				bStop = false;
				bProcessed = false;

				do 
				{ // Loop Until iRow >= fgridNTSB.Rows -1

					iRow++;

					strACId = Convert.ToString(fgridNTSB[iRow, 2].Value);
					if (strACId != "" && strACId != "0")
					{

						strProcess = Convert.ToString(fgridNTSB[iRow, 1].Value);

						//---------------------------------
						// Process Cell Must Be Blank

						if (strProcess == "")
						{

							if (Add_NTSB_FAA_Document_Log(iRow, ref lFAALogId, ref strACCTRep))
							{

								strFAALogId = lFAALogId.ToString();

								if (Add_NTSB_Journal_Record(iRow, strACCTRep, ref lJournId))
								{

									if (Add_NTSB_Hot_Box_Record(iRow, strACCTRep, lJournId))
									{

										if (Create_NTSB_HTML_Document(iRow, lFAALogId))
										{

											fgridNTSB[iRow, 1].Value = "LOADED";
											bProcessed = true;

										}
										else
										{
											MessageBox.Show($"Unable To Create NTSB HTML Document For ACID: {strACId}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
											bStop = true;
										} // If Create_NTSB_HTML_Document(iRow) = True Then

									}
									else
									{
										MessageBox.Show($"Unable To Create NTSB HOT Box Record For ACID: {strACId}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
										bStop = true;
									} // If Add_NTSB_Hot_Box_Record(iRow, strAcctRep, lJournId) = True Then

								}
								else
								{
									MessageBox.Show($"Unable To Create NTSB Journal Record For ACID: {strACId}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
									bStop = true;
								} // If Add_NTSB_Journal_Record(iRow, strAcctRep, lJournId) = True Then

							}
							else
							{
								MessageBox.Show($"Unable To Add NTSB FAA_Document_Log Record For ACID: {strACId}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
								bStop = true;
							} // If Add_NTSB_FAA_Document_Log(iRow, lFAALogId, strAcctRep) = True Then

						} // If strProcess = "" Then

					} // If strACID <> "" And strACID <> "0" Then

				}
				while(!(iRow >= fgridNTSB.RowsCount - 1 || bStop));

				if (!bStop && bProcessed)
				{
					if (Create_And_Send_EMail_Notice())
					{
						modAdminCommon.Record_Event("NTSB Reports", $"Process NTSB Reports - Completed: {txtNTSBDate.Text}", 0, 0, 0);
						MessageBox.Show("Process Completed", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}
				else
				{
					if (!bProcessed)
					{
						MessageBox.Show("Nothing Has Been Found That Needs Processing", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}

				SetFormControlsEnable(true);

			} // If cmdProcessNTSBReport.Enabled = True Then

		} // cmdProcessNTSBReport_Click



		private void cmdReloadNTSBReport_Click(Object eventSender, EventArgs eventArgs)
		{

			string strLocalFile = "";
			string strFileName = "";

			if (cmdReloadNTSBReport.Enabled)
			{

				SetFormControlsEnable(false);
				cmdProcessNTSBReport.Visible = false;

				strFileName = $"{DateTime.Parse(txtNTSBDate.Text).ToString("yyyyMMdd")}.csv";
				strLocalFile = $"{gstrNTSBMstrPath}{strFileName}";

				//---------------------------------------------------------------
				// Check To See If Master File Has Already Been Downloaded

				if (File.Exists(strLocalFile))
				{

					//---------------------------------------------
					// Now Open And Load Into Grid Based On Date

					if (LoadNTSBCSVFileInToGrid(gstrNTSBMstrPath, strFileName))
					{
						Application.DoEvents();
					} // If LoadNTSBCSVFileInToGrid(gstrNTSBMstrPath, strFileName) = True Then

				}
				else
				{
					MessageBox.Show($"Master NTSB - CSV File For Date: [{txtNTSBDate.Text}] - Does NOT Exists", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If gfso.FileExists(strLocalFile) = True Then

				SetFormControlsEnable(true);

			} // If cmdReloadNTSBReport.Enabled = True Then

		} // cmdReloadNTSBReport_Click


		private void fgridNTSB_Click(Object eventSender, EventArgs eventArgs)
		{


			int lTop = 0;
			int lLeft = 0;
			int lWidth = 0;
			int lHeight = 0;
			string strACId = "";

			txtACID.Tag = "0";
			int iCol = fgridNTSB.MouseCol;
			int iRow = fgridNTSB.MouseRow;

			if (iCol == 2 && iRow > 0)
			{

				fgridNTSB.CurrentColumnIndex = 1; // Process
				if (fgridNTSB[fgridNTSB.CurrentRowIndex, fgridNTSB.CurrentColumnIndex].FormattedValue.ToString() == "")
				{ // OK Still Pending Process

					fgridNTSB.CurrentColumnIndex = iCol;
					strACId = fgridNTSB[fgridNTSB.CurrentRowIndex, fgridNTSB.CurrentColumnIndex].FormattedValue.ToString();

					lTop = fgridNTSB.Top * 15 + fgridNTSB.Rows[iRow].Height * 15 * (fgridNTSB.RowSel - fgridNTSB.FirstDisplayedScrollingRowIndex + 1);
					lLeft = fgridNTSB.Left * 15 + fgridNTSB.ColPos[iCol];
					lWidth = fgridNTSB.Columns[iCol].Width;
					lHeight = fgridNTSB.Rows[iRow].Height * 15;

					txtACID.Tag = iRow.ToString();
					txtACID.Top = lTop / 15;
					txtACID.Left = lLeft / 15;
					txtACID.Width = lWidth / 15;
					txtACID.Height = lHeight / 15;
					txtACID.Text = strACId;
					txtACID.Enabled = true;
					txtACID.Visible = true;
					txtACID.Focus();

				}
				else
				{
					MessageBox.Show($"Unable To Edit [{fgridNTSB[fgridNTSB.CurrentRowIndex, fgridNTSB.CurrentColumnIndex].FormattedValue.ToString()}] Records", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If fgridNTSB.Text = "" Then ' OK Still Pending Process
			} // If iCol = 2 And iRow > 0 Then

		} // fgridNTSB_Click



		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
		private void Form_Load()
		{

			string strURL = "";
			string strParameters = "";

			txtNTSBDate.Enabled = false;
			mvNTSBCal.Enabled = false;

			string strWebSite = modCommon.DLookUp("aconfig_ntsb_website_url", "Application_Configuration");
			int iPos1 = (strWebSite.IndexOf("f?p") + 1);
			if (iPos1 > 0)
			{
				txtNTSBURL.Text = strWebSite.Substring(0, Math.Min(iPos1 - 1, strWebSite.Length));
				txtNTSBURLParameters.Text = strWebSite.Substring(Math.Min(iPos1 - 1, strWebSite.Length));
			}

			txtNTSBDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
			mvNTSBCal.SetDate(DateTime.Parse(txtNTSBDate.Text));

			txtNTSBDate.Enabled = true;
			mvNTSBCal.Enabled = true;

			cmdReloadNTSBReport.Visible = false;
			txtACID.Text = "";
			txtACID.Visible = false;

			//----------------------------------------------
			// Get The NTSB Main and Master Directory
			// From the Application Configuration Table
			// Also Make Sure The Directories Exist

			gstrNTSBPath = modCommon.DLookUp("aconfig_ntsb_maindir", "Application_Configuration");
			if (gstrNTSBPath.Substring(Math.Max(gstrNTSBPath.Length - 1, 0)) != "\\")
			{
				gstrNTSBPath = $"{gstrNTSBPath}\\";
			}

			gstrNTSBMstrPath = $"{gstrNTSBPath}MASTERS\\";
			gstrNTSBLibraryPath = $"{gstrNTSBPath}LIBRARY\\";
			gstrNTSBProcessingPath = $"{gstrNTSBPath}PROCESSING\\";
			gstrNTSBEMailPath = $"{gstrNTSBPath}EMAIL\\";

			if (!Directory.Exists(gstrNTSBPath))
			{
				MessageBox.Show($"NTSB Main Directory Does Not Exist{Environment.NewLine}{gstrNTSBPath}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				this.Close();
			}

			if (!Directory.Exists(gstrNTSBMstrPath))
			{
				MessageBox.Show($"NTSB Master Directory Does Not Exist{Environment.NewLine}{gstrNTSBMstrPath}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				this.Close();
			}

			if (!Directory.Exists(gstrNTSBLibraryPath))
			{
				MessageBox.Show($"NTSB Library Directory Does Not Exist{Environment.NewLine}{gstrNTSBLibraryPath}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				this.Close();
			}

			if (!Directory.Exists(gstrNTSBProcessingPath))
			{
				MessageBox.Show($"NTSB Processing Directory Does Not Exist{Environment.NewLine}{gstrNTSBProcessingPath}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				this.Close();
			}

			if (!Directory.Exists(gstrNTSBEMailPath))
			{
				MessageBox.Show($"NTSB EMail Directory Does Not Exist{Environment.NewLine}{gstrNTSBEMailPath}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				this.Close();
			}

			ClearNTSBGridAndSetHeaders();

		} // Form_Load


		//UPGRADE_WARNING: (2050) MSComCtl2.MonthView Event mvNTSBCal.DateClick was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2050
		private void mvNTSBCal_DateClick(System.DateTime DateClicked)
		{

			mvNTSBCal.Enabled = false;
			txtNTSBDate.Enabled = false;

			if (DateClicked > DateTime.Now)
			{
				MessageBox.Show("Can NOT Select A Date In The Future", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtNTSBDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
				mvNTSBCal.SetDate(DateTime.Parse(txtNTSBDate.Text));
			}

			txtNTSBDate.Text = mvNTSBCal.SelectionRange.Start.ToString("MM/dd/yyyy");

			ClearNTSBGridAndSetHeaders();

			//--------------------------------------------------
			// Check To See If NTSB CSV File Already Exists

			if (!Check_Does_CSV_File_Exists())
			{
				Application.DoEvents();
			}

			mvNTSBCal.Enabled = true;
			txtNTSBDate.Enabled = true;
			txtNTSBDate.Focus();

		} // mvNTSBCal_DateClick


		private void txtACID_Leave(Object eventSender, EventArgs eventArgs)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper(); // Aircraft
			ADORecordSetHelper rstRec2 = new ADORecordSetHelper(); // FAA Document Log
			string strQuery1 = "";
			string strQuery2 = "";

			string strFrameNbr = "";
			string strProcess = "";
			string strEntryDate = "";
			string strEventDate = "";

			//-------------------------------------------------------------------
			// The Current Grid Row/Col Should Be Where The ACID Needs To Go

			int iRow = Convert.ToInt32(Double.Parse(Convert.ToString(txtACID.Tag)));
			int iCol = 2;

			string strACId = txtACID.Text;
			if (strACId != "")
			{
				if (!Information.IsNumeric(strACId))
				{
					MessageBox.Show("Failed - ACID Is NOT Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					strACId = Convert.ToString(fgridNTSB[iRow, 2].Value);
				}
			}

			//---------------------------------------------------------
			// If ACID Is Blank Clear Out Any Homebase Information

			if (strACId == "")
			{
				fgridNTSB[iRow, 1].Value = ""; // PROCESS
				fgridNTSB[iRow, 3].Value = ""; // HB-MAKE
				fgridNTSB[iRow, 11].Value = ""; // FAALOG_ID
			}
			else
			{

				//---------------------------------------------
				// If ACID Is NOT Blank Verify It Exists

				strQuery1 = "SELECT ac_id, amod_airframe_type_code, amod_type_code, amod_make_name, amod_model_name, ac_reg_no, ac_prev_reg_no, ac_ser_no_full ";
				strQuery1 = $"{strQuery1}FROM Aircraft_Model WITH (NOLOCK)  INNER JOIN Aircraft WITH (NOLOCK) ON amod_id = ac_amod_id ";
				strQuery1 = $"{strQuery1}WHERE (ac_id = {strACId})  AND (ac_journ_id = 0) ";

				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					fgridNTSB[iRow, 3].Value = $"{($"{Convert.ToString(rstRec1["amod_make_name"])} ").Trim()} {($"{Convert.ToString(rstRec1["amod_model_name"])} ").Trim()}"; // HB-MAKE

					strFrameNbr = Convert.ToString(fgridNTSB[iRow, 0].Value);
					strEntryDate = Convert.ToString(fgridNTSB[iRow, 9].Value);
					strEventDate = Convert.ToString(fgridNTSB[iRow, 10].Value);

					//-------------------------------------------------
					// Now Check If FAA Document Log Record Exists

					strQuery2 = $"SELECT faalog_id FROM FAA_Document_Log WITH (NOLOCK) WHERE (faalog_ac_id = {strACId}) ";
					strQuery2 = $"{strQuery2}AND (faalog_tape_date = '{strEntryDate}') AND (faalog_document_date = '{strEventDate}')";
					strQuery2 = $"{strQuery2}AND (faalog_starting_frame_no = {strFrameNbr}) ";
					strQuery2 = $"{strQuery2}AND (faalog_ending_frame_no = {strFrameNbr}) AND (faalog_doc_type = 'NTS') ";

					rstRec2.Open(strQuery2, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!rstRec2.BOF && !rstRec2.EOF)
					{
						strProcess = "IN LOG";
						fgridNTSB[iRow, 1].Value = strProcess;
						fgridNTSB[iRow, 11].Value = Convert.ToString(rstRec2["faalog_id"]);
					} // If (rstRec3.BOF = False And rstRec3.EOF = False) Then

					rstRec2.Close();

				}
				else
				{
					MessageBox.Show("Failed - ACID Is NOT In Database", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					strACId = Convert.ToString(fgridNTSB[iRow, 2].Value);
				} // If (rstRec1.BOF = False And rstRec1.EOF = False) Then

				rstRec1.Close();

			} // If strACID = "" Then

			txtACID.Tag = "0";
			fgridNTSB[iRow, 2].Value = strACId;
			txtACID.Visible = false;

			rstRec2 = null;
			rstRec1 = null;

			return;



			modAdminCommon.Record_Error("txtACID_LostFocus_Error: ", Information.Err().Description);

		} // txtACID_LostFocus

		private void txtNTSBDate_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{

				txtNTSBDate.Enabled = false;
				mvNTSBCal.Enabled = false;

				PlusMinusDateField(txtNTSBDate, ref KeyAscii);

				if (DateTime.Parse(txtNTSBDate.Text) > DateTime.Now)
				{
					txtNTSBDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
				}

				mvNTSBCal.SetDate(DateTime.Parse(txtNTSBDate.Text));

				txtNTSBDate.Enabled = true;
				mvNTSBCal.Enabled = true;

				ClearNTSBGridAndSetHeaders();

				//--------------------------------------------------
				// Check To See If NTSB CSV File Already Exists

				if (!Check_Does_CSV_File_Exists())
				{
					Application.DoEvents();
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

		} // txtNTSBDate_KeyPress

		private void PlusMinusDateField(TextBox txtText, ref int iKeyCode)
		{


			string strDate = txtText.Text.Trim();
			System.DateTime dtDate = DateTime.FromOADate(0);

			if (iKeyCode == Strings.Asc('+') || iKeyCode == Strings.Asc('=') || iKeyCode == 43 || iKeyCode == 61 || iKeyCode == 107 || iKeyCode == 187)
			{
				if (Information.IsDate(strDate))
				{
					dtDate = DateTime.Parse(strDate);
					dtDate = dtDate.AddDays(1);
					strDate = dtDate.ToString("MM/dd/yyyy");
					txtText.Text = strDate;
					iKeyCode = 0;
				}
			}
			else if (iKeyCode == Strings.Asc('-') || iKeyCode == 45 || iKeyCode == 95 || iKeyCode == 109 || iKeyCode == 189)
			{ 
				if (Information.IsDate(strDate))
				{
					dtDate = DateTime.Parse(strDate);
					dtDate = dtDate.AddDays(-1);
					strDate = dtDate.ToString("MM/dd/yyyy");
					txtText.Text = strDate;
					iKeyCode = 0;
				}
			}
			else if (iKeyCode == Strings.Asc(' '))
			{ 
				if (strDate == "")
				{
					strDate = DateTime.Now.ToString("MM/dd/yyyy");
				}
				else
				{
					strDate = "";
				}
				txtText.Text = strDate;
				iKeyCode = 0;
			} // Case iKeyCode

		} // txtServiceRecDataDate_KeyUp
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}