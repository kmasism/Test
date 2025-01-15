using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Gui.Controls;
using UpgradeHelpers.Helpers;

namespace JETNET_Homebase
{
	internal partial class frm_CompanyDocument
		: System.Windows.Forms.Form
	{

		public frm_CompanyDocument()
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
			ReLoadForm(false);
		}


		private void frm_CompanyDocument_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}

		private int glCompId = 0;
		private bool gAlreadyLoaded = false;
		private bool gAttachFAADoc = false;

		public void SetAttachFAADoc(bool bValue) => gAttachFAADoc = bValue;


		public void SetCompanyId(int lCompId) => glCompId = lCompId;


		public void Form_Load_Data()
		{

			gAttachFAADoc = false;
			Load_Document_Type_ComboBox();
			cmdCompDocumentNew_Click(cmdCompDocumentNew, new EventArgs());
			Load_Company_Documents_Grid();

		}

		public void SetDocumentFileName(string strDocFileName)
		{

			FileInfo fFile = null;
			string strFromFileName = "";
			string strToFileName = "";
			string strFileName = "";
			bool bContinue = false;
			string strToPath = "";

			strDocFileName = strDocFileName.Trim();

			if (strDocFileName != "")
			{

				strFromFileName = strDocFileName;

				if (File.Exists(strFromFileName))
				{

					if (strFromFileName.ToLower().Substring(Math.Max(strFromFileName.ToLower().Length - 4, 0)) == ".pdf")
					{
						fFile = new FileInfo(strFromFileName);
						strFileName = fFile.Name;
						txtCompDragDocument.Tag = strFromFileName;
						txtCompDragDocument.Text = $"Drag Document Here{Environment.NewLine}{strFileName}";
						txtCompDocumentDate.Text = DateTimeHelper.ToString(DateTime.Parse(fFile.LastWriteTime.ToString("MM/dd/yyyy")));
						calCompDocumentDate.SetDate(DateTime.Parse(txtCompDocumentDate.Text));
						wbCompBrowser1[0].Navigate(new Uri(Convert.ToString(txtCompDragDocument.Tag)));
					}
					else
					{
						MessageBox.Show($"Filename Does NOT have a .PDF extension.{Environment.NewLine}File MUST be a PDF!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					}

				}
				else
				{
					MessageBox.Show($"Unable To Find File{Environment.NewLine}{strFromFileName}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If gfso.FileExists(strFromFileName) = True Then

			} // If strDocFileName <> "" Then

		} // SetDocumentFileName

		private void cmbCompDocumentType_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs)
		{
			cmbCompDocumentType.Tag = cmbCompDocumentType.Text.Substring(0, Math.Min(3, cmbCompDocumentType.Text.Length));


			if (cmbCompDocumentType.Text.Trim() == "LLC - LLC Application")
			{ // added in MSW - 5/12/22
				if (Convert.ToString(lblCompLabel[39].Tag) == "1")
				{ // we clicked on one to edit

				}
				else if (Convert.ToString(lblCompLabel[39].Tag) == "0")
				{  // we clicked on one new
					if (Convert.ToString(lblCompLabel[38].Tag) == "1")
					{ // then we already have an LLC app
						MessageBox.Show("This Company Already Has an LLC Application. Please review to ensure this is not a duplicate", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK);
					}
				}
			}


		}

		private void Load_Document_Type_ComboBox()
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();

			// Load Document Type
			cmbCompDocumentType.Items.Clear();
			string strQuery1 = "SELECT doctype_code, doctype_description ";
			strQuery1 = $"{strQuery1}FROM Document_Type WITH (NOLOCK) ";
			strQuery1 = $"{strQuery1}WHERE (doctype_company_doc_view = 'Y') ";
			strQuery1 = $"{strQuery1}ORDER BY doctype_description ";

			rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

			if ((!rstRec1.BOF) && (!rstRec1.EOF))
			{

				do 
				{ // Loop Until rstRec1.EOF = True
					cmbCompDocumentType.AddItem($"{($"{Convert.ToString(rstRec1["doctype_code"])} ").Trim()} - {($"{Convert.ToString(rstRec1["doctype_description"])} ").Trim()}");
					rstRec1.MoveNext();
				}
				while(!rstRec1.EOF);

				cmbCompDocumentType.Text = cmbCompDocumentType.GetListItem(0);
				cmbCompDocumentType.Tag = cmbCompDocumentType.Text.Substring(0, Math.Min(3, cmbCompDocumentType.Text.Length));

			} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

			rstRec1.Close();

		} // Load_Document_Type_ComboBox

		private void Load_Company_Documents_Grid()
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strCompId = "";
			int lCol = 0;

			try
			{

				lblCompLabel[38].Tag = "0";
				strCompId = glCompId.ToString();

				if ((strCompId != "0") && (strCompId != ""))
				{

					grd_CompDocument.Clear();
					grd_CompDocument.RowsCount = 2;
					grd_CompDocument.FixedRows = 1;
					grd_CompDocument.FixedColumns = 0;

					grd_CompDocument.ColumnsCount = 7;
					grd_CompDocument.CurrentRowIndex = 0;

					lCol = 0;
					grd_CompDocument.CurrentColumnIndex = lCol;
					grd_CompDocument[grd_CompDocument.CurrentRowIndex, grd_CompDocument.CurrentColumnIndex].Value = "DocId";
					grd_CompDocument.SetColumnWidth(lCol, 67);
					grd_CompDocument.CellAlignment = DataGridViewContentAlignment.MiddleRight;
					grd_CompDocument.CellBackColor = grd_CompDocument.BackColorFixed;

					lCol++;
					grd_CompDocument.CurrentColumnIndex = lCol;
					grd_CompDocument[grd_CompDocument.CurrentRowIndex, grd_CompDocument.CurrentColumnIndex].Value = "Type"; // Evolution Contract
					grd_CompDocument.SetColumnWidth(lCol, 200);
					grd_CompDocument.CellBackColor = grd_CompDocument.BackColorFixed;

					lCol++;
					grd_CompDocument.CurrentColumnIndex = lCol;
					grd_CompDocument[grd_CompDocument.CurrentRowIndex, grd_CompDocument.CurrentColumnIndex].Value = "Doc Date";
					grd_CompDocument.SetColumnWidth(lCol, 67);
					grd_CompDocument.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
					grd_CompDocument.CellBackColor = grd_CompDocument.BackColorFixed;

					lCol++;
					grd_CompDocument.CurrentColumnIndex = lCol;
					grd_CompDocument[grd_CompDocument.CurrentRowIndex, grd_CompDocument.CurrentColumnIndex].Value = "Entry Date";
					grd_CompDocument.SetColumnWidth(lCol, 67);
					grd_CompDocument.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
					grd_CompDocument.CellBackColor = grd_CompDocument.BackColorFixed;

					lCol++;
					grd_CompDocument.CurrentColumnIndex = lCol;
					grd_CompDocument[grd_CompDocument.CurrentRowIndex, grd_CompDocument.CurrentColumnIndex].Value = "User Id";
					grd_CompDocument.SetColumnWidth(lCol, 47);
					grd_CompDocument.CellBackColor = grd_CompDocument.BackColorFixed;

					lCol++;
					grd_CompDocument.CurrentColumnIndex = lCol;
					grd_CompDocument[grd_CompDocument.CurrentRowIndex, grd_CompDocument.CurrentColumnIndex].Value = "Subject";
					grd_CompDocument.SetColumnWidth(lCol, 467);
					grd_CompDocument.CellBackColor = grd_CompDocument.BackColorFixed;

					lCol++;
					grd_CompDocument.CurrentColumnIndex = lCol;
					grd_CompDocument[grd_CompDocument.CurrentRowIndex, grd_CompDocument.CurrentColumnIndex].Value = "";
					grd_CompDocument.SetColumnWidth(lCol, 0);
					grd_CompDocument.CellBackColor = grd_CompDocument.BackColorFixed;

					grd_CompDocument.CurrentRowIndex = 1;

					strQuery1 = "SELECT * FROM Company_Documents WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1}INNER JOIN Document_Type on compdoc_doc_type_code = doctype_code ";
					strQuery1 = $"{strQuery1}WHERE (compdoc_comp_id = {strCompId}) ";
					strQuery1 = $"{strQuery1}AND (compdoc_journ_id = 0) ";
					strQuery1 = $"{strQuery1}AND (doctype_company_doc_view = 'Y') ";
					strQuery1 = $"{strQuery1}ORDER BY compdoc_id DESC ";

					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if ((!rstRec1.BOF) && (!rstRec1.EOF))
					{

						do 
						{ // Loop Until rstRec1.EOF = True

							lCol = 0;
							grd_CompDocument.CurrentColumnIndex = lCol;
							grd_CompDocument[grd_CompDocument.CurrentRowIndex, grd_CompDocument.CurrentColumnIndex].Value = Convert.ToString(rstRec1["compdoc_id"]);
							grd_CompDocument.CellAlignment = DataGridViewContentAlignment.MiddleRight;

							lCol++;
							grd_CompDocument.CurrentColumnIndex = lCol;
							grd_CompDocument[grd_CompDocument.CurrentRowIndex, grd_CompDocument.CurrentColumnIndex].Value = $"{($"{Convert.ToString(rstRec1["compdoc_doc_type_code"])} ").Trim()} - {($"{Convert.ToString(rstRec1["doctype_description"])} ").Trim()}";


							if (($"{Convert.ToString(rstRec1["compdoc_doc_type_code"])} ").Trim().IndexOf("LLC") >= 0)
							{
								lblCompLabel[38].Tag = "1";
							}


							lCol++;
							grd_CompDocument.CurrentColumnIndex = lCol;
							grd_CompDocument[grd_CompDocument.CurrentRowIndex, grd_CompDocument.CurrentColumnIndex].Value = "";
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(rstRec1["compdoc_doc_date"]))
							{
								if (Information.IsDate(rstRec1["compdoc_doc_date"]))
								{
									grd_CompDocument[grd_CompDocument.CurrentRowIndex, grd_CompDocument.CurrentColumnIndex].Value = Convert.ToDateTime(rstRec1["compdoc_doc_date"]).ToString("MM/dd/yyyy");
								}
							}
							grd_CompDocument.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

							lCol++;
							grd_CompDocument.CurrentColumnIndex = lCol;
							grd_CompDocument[grd_CompDocument.CurrentRowIndex, grd_CompDocument.CurrentColumnIndex].Value = "";
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(rstRec1["compdoc_entry_date"]))
							{
								if (Information.IsDate(rstRec1["compdoc_entry_date"]))
								{
									grd_CompDocument[grd_CompDocument.CurrentRowIndex, grd_CompDocument.CurrentColumnIndex].Value = Convert.ToDateTime(rstRec1["compdoc_entry_date"]).ToString("MM/dd/yyyy");
								}
							}
							grd_CompDocument.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

							lCol++;
							grd_CompDocument.CurrentColumnIndex = lCol;
							grd_CompDocument[grd_CompDocument.CurrentRowIndex, grd_CompDocument.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["compdoc_user_id"])} ").Trim();

							lCol++;
							grd_CompDocument.CurrentColumnIndex = lCol;
							grd_CompDocument[grd_CompDocument.CurrentRowIndex, grd_CompDocument.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["compdoc_subject"])} ").Trim();

							lCol++;
							grd_CompDocument.CurrentColumnIndex = lCol;
							grd_CompDocument[grd_CompDocument.CurrentRowIndex, grd_CompDocument.CurrentColumnIndex].Value = ""; // Blank

							rstRec1.MoveNext();

							if (!rstRec1.EOF)
							{
								grd_CompDocument.RowsCount++;
								grd_CompDocument.CurrentRowIndex++;
							}

						}
						while(!rstRec1.EOF);

						grd_CompDocument.CurrentRowIndex = 1; // Set to first Row

					}
					else
					{
						grd_CompDocument.FixedRows = 0;
						grd_CompDocument.RemoveItem(1);
						grd_CompDocument.RowsCount = 0;
					} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

					rstRec1.Close();

				}
				else
				{
					MessageBox.Show("Company Id Is Blank Or Zero!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If (strCompId <> "0") And (strCompId <> "") Then

				rstRec1 = null;
			}
			catch
			{

				modAdminCommon.Report_Error("Load_Company_Documents_Grid_Error: ");
			}

		} // Load_Company_Documents_Grid



		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
		private void Form_Load() => gAlreadyLoaded = false;


		private void grd_CompDocument_Click(Object eventSender, EventArgs eventArgs)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strDocId = "";
			string strDocDir = "";

			try
			{


				lblCompLabel[39].Tag = "1"; // we clicked on one to edit

				if (grd_CompDocument.Enabled)
				{

					grd_CompDocument.Enabled = false;

					cmdCompDocumentNew_Click(cmdCompDocumentNew, new EventArgs());

					grd_CompDocument.CurrentColumnIndex = 0;
					strDocId = grd_CompDocument[grd_CompDocument.CurrentRowIndex, grd_CompDocument.CurrentColumnIndex].FormattedValue.ToString();

					strQuery1 = "SELECT * ";
					strQuery1 = $"{strQuery1}FROM Company_Documents WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1}INNER JOIN Document_Type ON compdoc_doc_type_code = doctype_code ";
					strQuery1 = $"{strQuery1}WHERE (compdoc_id = {strDocId}) ";
					strQuery1 = $"{strQuery1}AND (doctype_company_doc_view = 'Y') ";

					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if ((!rstRec1.BOF) && (!rstRec1.EOF))
					{

						txtCompDocumentId.Text = strDocId;
						cmbCompDocumentType.Text = $"{($"{Convert.ToString(rstRec1["compdoc_doc_type_code"])} ").Trim()} - {($"{Convert.ToString(rstRec1["doctype_description"])} ").Trim()}";
						cmbCompDocumentType.Tag = ($"{Convert.ToString(rstRec1["compdoc_doc_type_code"])} ").Trim();
						txtCompDocumentSubject.Text = ($"{Convert.ToString(rstRec1["compdoc_subject"])} ").Trim();
						txtCompDocumentDescription.Text = ($"{Convert.ToString(rstRec1["compdoc_description"])} ").Trim();

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["compdoc_doc_date"]))
						{
							if (Information.IsDate(rstRec1["compdoc_doc_date"]))
							{
								calCompDocumentDate.SetDate(Convert.ToDateTime(rstRec1["compdoc_doc_date"]));
								txtCompDocumentDate.Text = Convert.ToDateTime(rstRec1["compdoc_doc_date"]).ToString("MM/dd/yyyy");
							}
						}

						txtCompDragDocument.Text = $"Drag Document Here{Environment.NewLine}{($"{Convert.ToString(rstRec1["compdoc_filename"])} ").Trim()}";
						strDocDir = modCommon.DLookUp("aconfig_company_document_dir", "Application_Configuration");
						txtCompDragDocument.Tag = $"{strDocDir}\\{($"{Convert.ToString(rstRec1["compdoc_filename"])} ").Trim()}"; // This Holds The Path To The File To Add Or On File

						wbCompBrowser1[0].Navigate(new Uri(Convert.ToString(txtCompDragDocument.Tag)));
						cmdCompDocumentView.Enabled = true;
						cmdCompDocumentNew.Enabled = true;
						cmdCompDocumentDelete.Enabled = true;
						cmdCompDocumentMove.Enabled = true;

						grd_CompDocument.CurrentColumnIndex = 6;
						grd_CompDocument.ColSel = 0;

					} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

					rstRec1.Close();

					grd_CompDocument.Enabled = true;

				} // If grd_CompDocument.Enabled = True Then

				rstRec1 = null;
			}
			catch
			{

				modAdminCommon.Report_Error("grd_CompDocument_Click_Error: ");
			}

		} // grd_CompDocument_Click

		private void txtCompDocumentDate_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{

				txtCompDocumentDate.Enabled = false;
				calCompDocumentDate.Enabled = false;

				modCommon.PlusMinusDateField(txtCompDocumentDate, ref KeyAscii);

				if (txtCompDocumentDate.Text == "")
				{
					calCompDocumentDate.SetDate(DateTime.Now);
				}
				else
				{
					calCompDocumentDate.SetDate(DateTime.Parse(txtCompDocumentDate.Text));
				}

				txtCompDocumentDate.Enabled = true;
				calCompDocumentDate.Enabled = true;
			}
			finally
			{
				if (KeyAscii == 0)
				{
					eventArgs.Handled = true;
				}
				eventArgs.KeyChar = Convert.ToChar(KeyAscii);
			}

		} // txtCompDocumentDate_KeyPress

		//UPGRADE_WARNING: (2050) MSComCtl2.MonthView Event calCompDocumentDate.DateClick was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2050
		private void calCompDocumentDate_DateClick(System.DateTime DateClicked) => txtCompDocumentDate.Text = calCompDocumentDate.SelectionRange.Start.ToString("MM/dd/yyyy");


		private void SetButtons(bool bValue) => frmCompDocumentControl.Enabled = bValue;


		private void txtCompDragDocument_DoubleClick(Object eventSender, EventArgs eventArgs)
		{

			FileInfo fFile = null;
			string strFromFileName = "";
			string strFileName = "";

			try
			{

				SetButtons(false);

				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.InitDir was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				mdi_ResearchAssistant.DefInstance.CommonDialog1Open.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.DialogTitle was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				mdi_ResearchAssistant.DefInstance.CommonDialog1Open.Title = "Company Documents";
				//UPGRADE_WARNING: (2074) MSComDlg.CommonDialog property mdi_ResearchAssistant.CommonDialog1.Flags was upgraded to mdi_ResearchAssistant.CommonDialog1Open.ShowReadOnly which has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2074
				//UPGRADE_WARNING: (2074) FileOpenConstants STRING RESOURCE ["IDS-CONSTANT"] NOT FOUND FileOpenConstants.cdlOFNHideReadOnly was upgraded to OpenFileDialog.ShowReadOnly which has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2074
				mdi_ResearchAssistant.DefInstance.CommonDialog1Open.ShowReadOnly = false;
				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.Filter was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (2081) Filter has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				mdi_ResearchAssistant.DefInstance.CommonDialog1Open.Filter = "PDF Files (*.pdf)|*.pdf";
				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.FileName was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				mdi_ResearchAssistant.DefInstance.CommonDialog1Open.FileName = "";
				mdi_ResearchAssistant.DefInstance.CommonDialog1Open.ShowDialog();

				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.FileName was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				if (mdi_ResearchAssistant.DefInstance.CommonDialog1Open.FileName != "")
				{

					//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.FileName was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					strFromFileName = mdi_ResearchAssistant.DefInstance.CommonDialog1Open.FileName;

					if (File.Exists(strFromFileName))
					{

						//----------------------------------------------------------
						// 02/07/2008 - By David D. Cruger; File MUST be a PDF
						//----------------------------------------------------------
						if (strFromFileName.ToLower().Substring(Math.Max(strFromFileName.ToLower().Length - 4, 0)) == ".pdf")
						{
							fFile = new FileInfo(strFromFileName);
							strFileName = fFile.Name;
							txtCompDragDocument.Tag = strFromFileName;
							txtCompDragDocument.Text = $"Drag Document Here{Environment.NewLine}{strFileName}";
							txtCompDocumentDate.Text = DateTimeHelper.ToString(DateTime.Parse(fFile.LastWriteTime.ToString("MM/dd/yyyy")));
							calCompDocumentDate.SetDate(DateTime.Parse(txtCompDocumentDate.Text));
							wbCompBrowser1[0].Navigate(new Uri(Convert.ToString(txtCompDragDocument.Tag)));
						}
						else
						{
							MessageBox.Show($"Filename Does NOT have a .PDF extension.{Environment.NewLine}File MUST be a PDF!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						}

					}
					else
					{
						MessageBox.Show($"Unable To Find File{Environment.NewLine}{strFromFileName}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					} // If gfso.FileExists(strFromFileName) = True Then

				} // If mdi_ResearchAssistant.CommonDialog1.FileName <> "" Then

				SetButtons(true);
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("txtCompDragDocument_DblClick_Error", excep.Message);

				SetButtons(true);
			}

		} // txtCompDragDocument_DblClick

		//UPGRADE_WARNING: (2050) TextBox Event txtCompDragDocument.OLEDragDrop was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2050
		private void txtCompDragDocument_OLEDragDrop(DataObject Data, int Effect, int Button, int Shift, float X, float Y)
		{

			FileInfo fFile = null;
			string strFromFileName = "";
			string strFileName = "";

			try
			{

				//UPGRADE_ISSUE: (2064) DataObjectFiles property Files.Item was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//strFromFileName = Data.Files.Item(1); gap-note this line must be checked during blazor stabilization

				if (File.Exists(strFromFileName))
				{

					SetButtons(false);

					//----------------------------------------------------------
					// 02/07/2008 - By David D. Cruger; File MUST be a PDF
					//----------------------------------------------------------
					if (strFromFileName.ToLower().Substring(Math.Max(strFromFileName.ToLower().Length - 4, 0)) == ".pdf")
					{

						fFile = new FileInfo(strFromFileName);
						strFileName = fFile.Name;
						txtCompDragDocument.Tag = strFromFileName;
						txtCompDragDocument.Text = $"Drag Document Here{Environment.NewLine}{strFileName}";
						txtCompDocumentDate.Text = DateTimeHelper.ToString(DateTime.Parse(fFile.LastWriteTime.ToString("MM/dd/yyyy")));
						calCompDocumentDate.SetDate(DateTime.Parse(txtCompDocumentDate.Text));
						wbCompBrowser1[0].Navigate(new Uri(Convert.ToString(txtCompDragDocument.Tag)));
					}
					else
					{
						MessageBox.Show($"Filename Does NOT have a .PDF extension.{Environment.NewLine}File MUST be a PDF!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					}

					SetButtons(true);

				}
				else
				{
					MessageBox.Show($"Unable To Find File{Environment.NewLine}{strFromFileName}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If fso.FileExists(strFromFileName) = True Then
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("txtCompDragDocument_OLEDragDrop_Error", excep.Message);
				SetButtons(true);
			}

		} // txtCompDragDocument_OLEDragDrop

		//UPGRADE_NOTE: (7001) The following declaration (cmdBrowse_Click) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void cmdBrowse_Click()
		//{
			//
			//
		//} // cmdBrowse_Click

		private void cmdCompDocumentDelete_Click(Object eventSender, EventArgs eventArgs)
		{

			Object fso = new Object();
			string strDelete1 = "";
			string strInsert1 = "";
			string strDocumentId = "";
			string strCompId = "";
			int lCompId = 0;

			string strDocFullFileName = "";
			string strDocFileName = "";

			try
			{

				if (cmdCompDocumentDelete.Enabled)
				{

					// Disable Delete Button
					cmdCompDocumentDelete.Enabled = false;

					// Get Document Id and CompId
					strDocumentId = ($"{txtCompDocumentId.Text} ").Trim();
					strCompId = glCompId.ToString();
					lCompId = Convert.ToInt32(Double.Parse(strCompId));

					if (Convert.ToString(txtCompDragDocument.Tag) != "")
					{

						// Clear The WebBrowser
						wbCompBrowser1[0].Navigate(new Uri("about:blank")); // Make Sure It's Not Open
						modCommon.DelaySeconds(1);

						strDocFullFileName = ($"{Convert.ToString(txtCompDragDocument.Tag)} ").Trim();
						strDocFileName = modCommon.DLookUp("compdoc_filename", "Company_Documents", $"(compdoc_id = {strDocumentId})");

						//------------------------------
						// If File Exists Delete It
						//------------------------------
						if (File.Exists(strDocFullFileName))
						{
							//UPGRADE_WARNING: (2081) DeleteFile has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
							File.Delete(strDocFullFileName);
						} // If fso.FileExists(strDocFileName) = True Then

						//--------------------------------------------
						// Create Delete Log Entry
						//--------------------------------------------
						strInsert1 = "INSERT INTO Delete_Log ";
						strInsert1 = $"{strInsert1}(dlog_type, dlog_comp_id, dlog_action_date, dlog_entry_user, dlog_compdoc_id, dlog_note) ";
						strInsert1 = $"{strInsert1}VALUES (";
						strInsert1 = $"{strInsert1}'COMPDOC', ";
						strInsert1 = $"{strInsert1}{strCompId}, ";
						strInsert1 = $"{strInsert1}'1/1/1900', ";
						strInsert1 = $"{strInsert1}'{modAdminCommon.gbl_User_ID}', ";
						strInsert1 = $"{strInsert1}{txtCompDocumentId.Text}, ";
						strInsert1 = $"{strInsert1}'{strDocFileName}'";
						strInsert1 = $"{strInsert1})";
						DbCommand TempCommand = null;
						TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
						TempCommand.CommandText = strInsert1;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
						TempCommand.ExecuteNonQuery();

						//--------------------------------------------
						// Now Delete The Company Document Record
						//--------------------------------------------
						strDelete1 = $"DELETE Company_Documents WHERE (compdoc_id = {strDocumentId}) ";
						DbCommand TempCommand_2 = null;
						TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
						TempCommand_2.CommandText = strDelete1;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand_2.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
						TempCommand_2.ExecuteNonQuery();

						modAdminCommon.Record_Event("User Action", $"Delete Company Document: {strDocFileName} - Subject: {txtCompDocumentSubject.Text}", 0, 0, lCompId);

					} // If txtCompDragDocument.Tag <> "" Then

					Load_Company_Documents_Grid();

					cmdCompDocumentNew_Click(cmdCompDocumentNew, new EventArgs());

				} // If cmdCompDocumentDelete.Enabled = True Then

				fso = null;
			}
			catch
			{
			}


		} // cmdSubDocumentDelete

		private void cmdCompDocumentMove_Click(Object eventSender, EventArgs eventArgs)
		{

			Object fso = new Object();

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			ADORecordSetHelper rstRec2 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strQuery2 = "";

			string strUpdate1 = "";
			string strDocumentId = "";
			string strCompId = "";
			int lCompId = 0;

			string strNewCompId = "";
			int lNewCompId = 0;

			string strDocDir = "";

			string strDocFileName = "";
			string strFileName = "";

			string strNewDocFileName = "";
			string strNewFileName = "";

			string strCompany = "";
			string strCity = "";

			try
			{

				if (cmdCompDocumentMove.Enabled)
				{

					// Disable Move Button
					cmdCompDocumentMove.Enabled = false;

					// Get Document Id and CompId
					strDocumentId = ($"{txtCompDocumentId.Text} ").Trim();
					strCompId = glCompId.ToString();
					lCompId = Convert.ToInt32(Double.Parse(strCompId));

					if (Convert.ToString(txtCompDragDocument.Tag) != "")
					{

						strNewCompId = InputBoxHelper.InputBox("Enter New Company Id", "Move Document");

						if (strNewCompId != "")
						{

							lNewCompId = 0;
							if (Information.IsNumeric(strNewCompId))
							{
								lNewCompId = Convert.ToInt32(Double.Parse(strNewCompId));
							}

							if (lNewCompId > 0)
							{

								if (strCompId != strNewCompId)
								{

									strQuery1 = "SELECT comp_id, comp_name, comp_city ";
									strQuery1 = $"{strQuery1}FROM Company WITH (NOLOCK) ";
									strQuery1 = $"{strQuery1}WHERE (comp_id = {lNewCompId.ToString()}) ";
									strQuery1 = $"{strQuery1}AND (comp_journ_id = 0) ";

									rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

									if ((!rstRec1.BOF) && (!rstRec1.EOF))
									{

										strCompany = ($"{Convert.ToString(rstRec1["comp_name"])} ").Trim();
										strCity = ($"{Convert.ToString(rstRec1["comp_city"])} ").Trim();

										if (MessageBox.Show($"Move To Company: [{strNewCompId}]{Environment.NewLine}{strCompany}, {strCity}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
										{

											//--------------------------------------
											// Clear The WebBrowser
											wbCompBrowser1[0].Navigate(new Uri("about:blank")); // Make Sure It's Not Open
											modCommon.DelaySeconds(1);

											//--------------------------------------
											// Get Document Record

											strQuery2 = $"SELECT * FROM Company_Documents WHERE (compdoc_id = {strDocumentId}) ";

											rstRec2.Open(strQuery2, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

											if ((!rstRec2.BOF) && (!rstRec2.EOF))
											{

												strDocDir = modCommon.DLookUp("aconfig_company_document_dir", "Application_Configuration");

												strFileName = ($"{Convert.ToString(rstRec2["compdoc_filename"])} ").Trim();
												strDocFileName = $"{strDocDir}\\{strFileName}";

												strNewFileName = StringsHelper.Replace(strFileName, $"{strCompId}-", $"{strNewCompId}-", 1, -1, CompareMethod.Binary);
												strNewDocFileName = $"{strDocDir}\\{strNewFileName}";

												//--------------------------------------------------------
												// Check To See If New Document Name Already Exists

												if (!File.Exists(strNewDocFileName))
												{

													//------------------------------
													// Old File Must Exists

													if (File.Exists(strDocFileName))
													{

														File.Move(strDocFileName, strNewDocFileName);

														strUpdate1 = "UPDATE Company_Documents ";
														strUpdate1 = $"{strUpdate1}SET compdoc_comp_id = {strNewCompId}, ";
														strUpdate1 = $"{strUpdate1}compdoc_filename = '{strNewFileName}', ";
														strUpdate1 = $"{strUpdate1}compdoc_backup_date = NULL ";
														strUpdate1 = $"{strUpdate1}WHERE (compdoc_id = {strDocumentId}) ";

														DbCommand TempCommand = null;
														TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
														UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
														TempCommand.CommandText = strUpdate1;
														//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
														//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
														TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
														UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
														TempCommand.ExecuteNonQuery();

														modAdminCommon.Record_Event("User Action", $"Moved Company Document: {strFileName} To {strNewFileName}", 0, 0, lCompId);

													}
													else
													{
														MessageBox.Show($"ERROR: Old Document File Does NOT Exist [{strFileName}]", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
													} // If fso.FileExists(strDocFileName) = True Then

												}
												else
												{
													MessageBox.Show($"ERROR: New Document File Already Exists [{strNewFileName}]", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
												} // If fso.FileExists(strNewDocFileName) = False Then

											}
											else
											{
												MessageBox.Show($"ERROR: Could NOT Find Document Record [{strDocumentId}]", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
											} // If (rstRec2.BOF = False) And (rstRec2.EOF = False) Then

											rstRec2.Close();

										} // If MsgBox("Move To Company" & vbCrLf & strCompany & ", " & strCity, vbYesNo) = vbYes Then

									}
									else
									{
										MessageBox.Show($"New CompId Is Not On File [{strNewCompId}]", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
									} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

									rstRec1.Close();

								}
								else
								{
									MessageBox.Show($"New CompId Equals Old CompId [{strCompId}]=[{strNewCompId}]", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
								} // If strCompId <> strNewCompId Then

							}
							else
							{
								MessageBox.Show($"New CompId Is Invalid [{strNewCompId}]", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							} // If lNewCompId > 0 Then

						} // If strNewCompId <> "" Then

					} // If txtCompDragDocument.Tag <> "" Then

					Load_Company_Documents_Grid();

					cmdCompDocumentNew_Click(cmdCompDocumentNew, new EventArgs());

				} // If cmdCompDocumentDelete.Enabled = True Then

				fso = null;
				rstRec2 = null;
				rstRec1 = null;
			}
			catch
			{
			}


		} // cmdSubDocumentMove

		private void cmdCompDocumentNew_Click(Object eventSender, EventArgs eventArgs)
		{

			txtCompDocumentId.Text = "0";
			cmbCompDocumentType.Text = "";
			cmbCompDocumentType.Tag = "";
			txtCompDocumentSubject.Text = "";
			txtCompDocumentDescription.Text = "";
			txtCompDocumentId.Text = "0";
			calCompDocumentDate.SetDate(DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")));
			txtCompDocumentDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
			txtCompDragDocument.Text = "Drag Document Here";
			txtCompDragDocument.Tag = ""; // This Holds The Path To The File To Add Or On File
			wbCompBrowser1[0].Navigate(new Uri("about:blank"));
			cmdCompDocumentNew.Enabled = false;
			cmdCompDocumentView.Enabled = false;
			cmdCompDocumentDelete.Enabled = false;
			cmdCompDocumentMove.Enabled = false;
			lblCompLabel[39].Tag = "0"; // we clicked on one to new


		} // cmdCompDocumentNew_Click

		private void cmdCompDocumentSave_Click(Object eventSender, EventArgs eventArgs)
		{

			Object fso = new Object();
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strUpdate1 = "";

			string strDocumentId = "";
			string strCompId = "";

			string strDocumentTypeName = "";
			string strDocumentTypeCode = "";
			string strSubject = "";
			string strDescription = "";
			string strExt = "";
			string strFileName = "";
			string strLocalFileName = "";
			string strToFileName = "";
			string strDocDate = "";
			string strDocDir = "";
			int iPos1 = 0;
			bool bContinue = false;
			string strUserId = "";
			string strSendToEvo = "";
			bool bDocSaved = false;

			try
			{

				bDocSaved = false;
				strSendToEvo = "N";
				strDocumentId = ($"{txtCompDocumentId.Text} ").Trim();
				strCompId = glCompId.ToString();
				strSubject = ($"{txtCompDocumentSubject.Text} ").Trim();
				strDescription = ($"{txtCompDocumentDescription.Text} ").Trim();
				strDocumentTypeName = ($"{cmbCompDocumentType.Text} ").Trim();
				strDocDate = ($"{txtCompDocumentDate.Text} ").Trim();
				strUserId = modAdminCommon.gbl_User_ID;

				if (!Information.IsDate(strDocDate))
				{
					strDocDate = "";
					txtCompDocumentDate.Text = "";
				}
				else
				{
					System.DateTime TempDate2 = DateTime.FromOADate(0);
					strDocDate = (DateTime.TryParse(strDocDate, out TempDate2)) ? TempDate2.ToString("MM/dd/yyyy") : strDocDate;
				}

				if (cmdCompDocumentSave.Enabled)
				{

					cmdCompDocumentSave.Enabled = false;
					frmCompDocumentControl.Enabled = false;

					// Validate Fields
					if (strDocumentTypeName != "")
					{

						strDocumentTypeCode = Convert.ToString(cmbCompDocumentType.Tag);

						if (strSubject != "")
						{

							if (strDocumentTypeCode != "")
							{

								if (Convert.ToString(txtCompDragDocument.Tag) != "")
								{

									strSendToEvo = modCommon.DLookUp("doctype_send_to_evol", "Document_Type", $"(doctype_code = '{strDocumentTypeCode}')");

									strLocalFileName = ($"{Convert.ToString(txtCompDragDocument.Tag)} ").Trim();

									if (File.Exists(strLocalFileName))
									{

										// Now Find Document On File Or If Document Id = 0 Then Add New One
										strQuery1 = $"SELECT * FROM Company_Documents WHERE (compdoc_id = {strDocumentId}) ";
										rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
										rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);

										bContinue = false;

										if (strDocumentId == "0")
										{
											rstRec1.AddNew();
											bContinue = true;
										}
										else
										{

											if ((!rstRec1.BOF) && (!rstRec1.EOF))
											{
												bContinue = true;
												wbCompBrowser1[0].Navigate(new Uri("about:blank")); // Make Sure It's Not Open
												modCommon.DelaySeconds(1);
											}
											else
											{
												MessageBox.Show("Unable To Find Existing Record To Save Update!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
											} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

										} // If strDocumentId = "0" Then

										if (bContinue)
										{ // Ok To Update/Add

											rstRec1["compdoc_comp_id"] = Convert.ToInt32(Double.Parse(strCompId));
											rstRec1["compdoc_journ_id"] = 0;
											rstRec1["compdoc_doc_type_code"] = strDocumentTypeCode;
											rstRec1["compdoc_subject"] = strSubject;
											rstRec1["compdoc_description"] = strDescription;
											rstRec1["compdoc_user_id"] = strUserId;

											if (Information.IsDate(strDocDate))
											{
												System.DateTime TempDate3 = DateTime.FromOADate(0);
												rstRec1["compdoc_doc_date"] = DateTime.Parse((DateTime.TryParse(strDocDate, out TempDate3)) ? TempDate3.ToString("MM/dd/yyyy") : strDocDate);
											}

											rstRec1["compdoc_backup_date"] = DateTime.Parse("1/1/1900");
											if (strSendToEvo == "Y")
											{
												rstRec1["compdoc_action_date"] = DateTime.Parse("1/1/1900");
											}

											rstRec1.UpdateBatch();

											if ((strDocumentId == "0") || (strLocalFileName != ""))
											{

												strDocumentId = Convert.ToString(rstRec1["compdoc_id"]);
												txtCompDocumentId.Text = strDocumentId;

												//UPGRADE_WARNING: (2099) Return value for Dir has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2099
												strFileName = FileSystem.Dir(strLocalFileName);
												iPos1 = (strFileName.IndexOf('.') + 1);
												strExt = strFileName.Substring(Math.Min(iPos1 - 1, strFileName.Length));

												strDocDir = modCommon.DLookUp("aconfig_company_document_dir", "Application_Configuration");
												strToFileName = $"{strDocDir}\\{strCompId}-{strDocumentId}{strExt}";

												if (strLocalFileName != strToFileName)
												{

													File.Copy(strLocalFileName, strToFileName, true);
													txtCompDragDocument.Text = $"Drag Document Here{Environment.NewLine}{strFileName}";

													// Now Add In The File Name Once We Know The Document Id
													//UPGRADE_WARNING: (2099) Return value for Dir has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2099
													strFileName = FileSystem.Dir(strToFileName);
													strUpdate1 = $"UPDATE Company_Documents Set compdoc_filename = '{strFileName}' ";
													strUpdate1 = $"{strUpdate1}WHERE (compdoc_id = {strDocumentId}) ";

													DbCommand TempCommand = null;
													TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
													UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
													TempCommand.CommandText = strUpdate1;
													//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
													//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
													TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
													UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
													TempCommand.ExecuteNonQuery();

												} // If strLocalFileName <> strToFileName Then

												modAdminCommon.Record_Event("User Action", $"Added Company Document: {strFileName} DocId: {strDocumentId}", 0, 0, glCompId);
												bDocSaved = true;

											} // If strDocumentId = "0" Then

											Load_Company_Documents_Grid();
											cmdCompDocumentNew_Click(cmdCompDocumentNew, new EventArgs());

										} // If bContinue = True Then ' Ok To Update

										rstRec1.Close();

									}
									else
									{
										MessageBox.Show($"Unable To Find Local Document File!{Environment.NewLine}{strLocalFileName}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
									} // If fso.FileExists(strLocalFileName) = True Then

								}
								else
								{
									MessageBox.Show("Document Has Not Been Added.  Please Drag a Document To The Document Area!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
								} // If txtCompDragDocument.Tag <> "" Then

							}
							else
							{
								MessageBox.Show("Document Type Is Blank!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							} // If strDocumentTypeCode <> "" Then

						}
						else
						{
							MessageBox.Show("Document Subject Is Blank!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						} // If strSubject <> "" Then

					}
					else
					{
						MessageBox.Show("Document Type Has Not Been Selected!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					} // If strDocumentTypeName <> "" Then

					frmCompDocumentControl.Enabled = true;
					cmdCompDocumentSave.Enabled = true;

				} // If cmdCompDocumentSave.Enabled = True Then

				rstRec1 = null;
				fso = null;

				if (bDocSaved)
				{
					if (gAttachFAADoc)
					{
						this.Close();
					}
				}
			}
			catch (System.Exception excep)
			{

				MessageBox.Show($"Save Document Error!{Environment.NewLine}{excep.Message}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		} // cmdCompDocumentSave_Click_Error

		private void cmdCompDocumentView_Click(Object eventSender, EventArgs eventArgs)
		{

			Object fso = new Object();
			string strURL = "";


			if (cmdCompDocumentView.Enabled)
			{
				try
				{

					cmdCompDocumentView.Enabled = false;
				}
				catch
				{
				}
				if (ErrorHandlingHelper.ResumeNextExpr<bool>(() => (Convert.ToString(txtCompDragDocument.Tag) != "")))
				{

					if (ErrorHandlingHelper.ResumeNextExpr<bool>(() => File.Exists(Convert.ToString(txtCompDragDocument.Tag))))
					{
						ErrorHandlingHelper.ResumeNext(

							() => {strURL = $"http:{StringsHelper.Replace(Convert.ToString(txtCompDragDocument.Tag), "\\", "/", 1, -1, CompareMethod.Binary)}";}, 

							() => {modCommon.ShellOpenURLInBrowser(modAdminCommon.gbl_User_Browser, strURL);});

					}
					else
					{
						ErrorHandlingHelper.ResumeNext(
							() => {wbCompBrowser1[0].Navigate(new Uri("about:blank"));}, 
							() => {MessageBox.Show($"Can Not Find Attached File{Environment.NewLine}{Convert.ToString(txtCompDragDocument.Tag)}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);});
					} // If fso.FileExists(txtCompDragDocument.Tag) = True Then

				}
				else
				{
					ErrorHandlingHelper.ResumeNext(
						() => {wbCompBrowser1[0].Navigate(new Uri("about:blank"));}, 
						() => {MessageBox.Show("No Document On File", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);});
				}
				try
				{

					cmdCompDocumentView.Enabled = true;
				}
				catch
				{
				}

			} // If cmdCompDocumentView.Enabled = True Then

			fso = null;

		} // cmdCompDocumentView_Click
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}