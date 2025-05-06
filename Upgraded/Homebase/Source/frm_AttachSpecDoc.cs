using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Gui.Utils;
using UpgradeHelpers.Helpers;

namespace JETNET_Homebase
{
	internal partial class frm_AttachSpecDoc
		: System.Windows.Forms.Form
	{


		public frm_AttachSpecDoc()
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


		//UPGRADE_WARNING: (2050) MSComCtl2.MonthView Event calSpecDocumentDate.DateClick was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2050
		private void calSpecDocumentDate_DateClick(System.DateTime DateClicked) => txtSpecDocumentDate.Text = calSpecDocumentDate.SelectionRange.Start.ToString("MM/dd/yyyy");


		//---------------------------------------------
		// 06/18/2008 - By David D. Cruger
		// Added Option To Delete Attached Specs
		//---------------------------------------------

		private void cmdSpecDocumentDelete_Click(Object eventSender, EventArgs eventArgs)
		{

			Object fso = new Object();
			string strDocDir = "";
			string strFileName = "";
			string strDocumentId = "";
			string strACId = "";
			string strSubject = "";
			string strDelete1 = "";
			string strMsg = "";

			try
			{

				if (cmdSpecDocumentDelete.Enabled)
				{

					cmdSpecDocumentDelete.Enabled = false;
					if (Convert.ToString(txtSpecDragDocument.Tag) != "")
					{

						strFileName = Convert.ToString(txtSpecDragDocument.Tag);
						if (strFileName.IndexOf('*') >= 0)
						{
							// CANNOT USE A WILD CARD
							strFileName = "";
						}

						strDocumentId = ($"{txtSpecDocumentId.Text} ").Trim();
						strACId = ($"{txtSpecACId.Text} ").Trim();
						strSubject = ($"{txtSpecDocumentSubject.Text} ").Trim();

						if ((strACId != "") && (strACId != "0") && (strDocumentId != "") && (strDocumentId != "0"))
						{

							strDocDir = modCommon.DLookUp("aconfig_spec_doc_dir", "Application_Configuration");

							wbSpecBrowser1.Navigate(new Uri("about:blank"));
							modCommon.DelaySeconds(1);

							strDelete1 = "DELETE FROM Aircraft_Specification_Documents ";
							strDelete1 = $"{strDelete1}WHERE (asdoc_id = {strDocumentId}) ";

							DbCommand TempCommand = null;
							TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
							TempCommand.CommandText = strDelete1;
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
							TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
							TempCommand.ExecuteNonQuery();

							if (File.Exists(strFileName) && strFileName != "")
							{
								//UPGRADE_WARNING: (2081) DeleteFile has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
								File.Delete(strFileName);
							}
							else
							{
								//--------------------------
								// Manually Build Name
								strFileName = $"{strDocDir}\\{ReturnSubDirectoryForFile(strACId)}\\{strACId}-{strDocumentId}.pdf";
								if (File.Exists(strFileName))
								{
									//UPGRADE_WARNING: (2081) DeleteFile has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
									File.Delete(strFileName);
								}
								else
								{
									//-----------------------------
									// Get Name From Data Record
									strFileName = modCommon.DLookUp("asdoc_filename", "Aircraft_Specification_Documents", $"(asdoc_id = {strDocumentId})");
									if (($"{strFileName} ").Trim() != "")
									{
										strFileName = $"{strDocDir}\\{ReturnSubDirectoryForFile(strACId)}\\{strFileName}";
										if (File.Exists(strFileName))
										{
											//UPGRADE_WARNING: (2081) DeleteFile has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
											File.Delete(strFileName);
										}
									} // If strFileName <> "" Then
								} // If fso.FileExists(strFileName) = True Then
							} // If fso.FileExists(strFileName) = True Then

							Load_Specification_Documents_Grid();

							cmdSpecDocumentNew_Click(cmdSpecDocumentNew, new EventArgs());

							modAdminCommon.Record_Event("Aircraft Spec", $"Deleted Aircraft Spec: DocId:=({strDocumentId}) FileName:=({strFileName}) {strSubject}", Convert.ToInt32(Double.Parse(strACId)), 0, 0);

						}
						else
						{
							wbSpecBrowser1.Navigate(new Uri("about:blank"));
							MessageBox.Show($"Aircraft Id or Document Id Is Blank{Environment.NewLine}{Convert.ToString(txtSpecDragDocument.Tag)}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						} // If (strACId <> "") And (strACId <> "0") And (strDocumentId <> "") And (strDocumentId <> "0") Then

					}
					else
					{
						wbSpecBrowser1.Navigate(new Uri("about:blank"));
						MessageBox.Show("No Document On File", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					} // If (txtSpecDragDocument.Tag <> "") Then

				} // If cmdSpecDocumentDelete.Enabled = True Then
			}
			catch (System.Exception excep)
			{

				strMsg = excep.Message;
				modAdminCommon.Record_Error("cmdSpecDocumentDelete_Click_Error", strMsg);
				MessageBox.Show($"cmdSpecDocumentDelete_Click_Error{Environment.NewLine}{strMsg}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		} // cmdSpecDocumentDelete_Click

		private void cmdSpecDocumentNew_Click(Object eventSender, EventArgs eventArgs)
		{

			txtSpecDocumentId.Text = "0";
			txtSpecDocumentDescription.Text = "";
			txtSpecDocumentId.Text = "0";
			calSpecDocumentDate.SetDate(DateTime.Now);
			txtSpecDocumentDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
			txtSpecDragDocument.Text = "Drag Document Here";
			txtSpecDragDocument.Tag = ""; // This Holds The Path To The File To Add Or On File
			wbSpecBrowser1.Navigate(new Uri("about:blank"));
			cmdSpecDocumentNew.Enabled = false;
			cmdSpecDocumentView.Enabled = false;
			grd_SpecDocument.ColSel = 0;
			cmdSpecDocumentDelete.Enabled = false;

		} // cmdSpecDocumentNew_Click

		private string ReturnSubDirectoryForFile(string strACId)
		{

			int lACId = 0;
			int lBottom = 0;
			int lTop = 0;

			string strResults = "";

			if ((strACId != "0") && (strACId != ""))
			{

				lACId = Convert.ToInt32(Conversion.Val(strACId));
				lBottom = 0;
				lTop = 999;

				do 
				{ // Loop Until lBottom < lACID And lTop > lACID
					if (lTop < lACId)
					{
						lBottom += 1000;
						lTop += 1000;
					}
				}
				while(!(lBottom <= lACId && lTop >= lACId));

				strResults = $"{lBottom.ToString()}-{lTop.ToString()}";

			} // If (strACId <> "0") And (strACId <> "") Then

			return strResults;

		} // ReturnSubDirectoryForFile

		private void cmdSpecDocumentSave_Click(Object eventSender, EventArgs eventArgs)
		{

			Object fso = new Object();
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strUpdate1 = "";

			string strDocumentId = "";
			string strACId = "";

			string strSubject = "";
			string strDescription = "";
			string strExt = "";
			string strFileName = "";
			string strLocalFileName = "";
			string strToFileName = "";
			string strDocDate = "";
			string strDocDir = "";
			string strUserId = "";
			int iPos1 = 0;
			bool bContinue = false;

			try
			{

				strDocumentId = ($"{txtSpecDocumentId.Text} ").Trim();
				strACId = ($"{txtSpecACId.Text} ").Trim();
				strSubject = ($"{txtSpecDocumentSubject.Text} ").Trim();
				strDescription = ($"{txtSpecDocumentDescription.Text} ").Trim();
				strDocDate = ($"{txtSpecDocumentDate.Text} ").Trim();
				strUserId = ($"{Convert.ToString(modAdminCommon.snp_User["user_id"])} ").Trim().ToUpper();

				if (!Information.IsDate(strDocDate))
				{
					strDocDate = "";
					txtSpecDocumentDate.Text = "";
				}
				else
				{
					System.DateTime TempDate2 = DateTime.FromOADate(0);
					strDocDate = (DateTime.TryParse(strDocDate, out TempDate2)) ? TempDate2.ToString("MM/dd/yyyy") : strDocDate;
				}

				if (cmdSpecDocumentSave.Enabled)
				{

					cmdSpecDocumentSave.Enabled = false;
					frmSpecDocumentControl.Enabled = false;

					// Validate Fields
					if ((strACId != "0") && (strACId != ""))
					{

						if (strSubject != "")
						{

							if (Convert.ToString(txtSpecDragDocument.Tag) != "")
							{

								strLocalFileName = ($"{Convert.ToString(txtSpecDragDocument.Tag)} ").Trim();

								if (File.Exists(strLocalFileName))
								{

									// Now Find Document On File Or If Document Id = 0 Then Add New One
									strQuery1 = "SELECT * FROM Aircraft_Specification_Documents ";
									strQuery1 = $"{strQuery1}WHERE (asdoc_id = {strDocumentId}) ";

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
											wbSpecBrowser1.Navigate(new Uri("about:blank")); // Make Sure It's Not Open
											modCommon.DelaySeconds(1);
										}
										else
										{
											MessageBox.Show("Unable To Find Existing Record To Save Update!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
										} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

									} // If strDocumentId = "0" Then

									if (bContinue)
									{ // Ok To Update/Add

										rstRec1["asdoc_ac_id"] = Convert.ToInt32(Double.Parse(strACId));
										rstRec1["asdoc_journ_id"] = 0;
										rstRec1["asdoc_user_id"] = strUserId;
										rstRec1["asdoc_Subject"] = strSubject;
										rstRec1["asdoc_description"] = strDescription;

										if (Information.IsDate(strDocDate))
										{
											System.DateTime TempDate3 = DateTime.FromOADate(0);
											rstRec1["asdoc_doc_date"] = DateTime.Parse((DateTime.TryParse(strDocDate, out TempDate3)) ? TempDate3.ToString("MM/dd/yyyy") : strDocDate);
										}

										rstRec1["asdoc_update_date"] = DateTime.Now;
										rstRec1["asdoc_backup_date"] = DateTime.Parse("1/1/1900");

										rstRec1.UpdateBatch();

										if ((strDocumentId == "0") || (strLocalFileName != ""))
										{

											strDocumentId = Convert.ToString(rstRec1["asdoc_id"]);
											txtSpecDocumentId.Text = strDocumentId;

											//UPGRADE_WARNING: (2099) Return value for Dir has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2099
											strFileName = FileSystem.Dir(strLocalFileName);

											iPos1 = (strFileName.IndexOf('.') + 1);
											strExt = strFileName.Substring(Math.Min(iPos1 - 1, strFileName.Length));

											strDocDir = modCommon.DLookUp("aconfig_spec_doc_dir", "Application_Configuration");
											strToFileName = $"{strDocDir}\\{ReturnSubDirectoryForFile(strACId)}\\{strACId}-{strDocumentId}{strExt}";

											if (strLocalFileName != strToFileName)
											{

												File.Copy(strLocalFileName, strToFileName, true);
												txtSpecDragDocument.Text = $"Drag Document Here{Environment.NewLine}{strFileName}";

												// Now Add In The File Name Once We Know The Document Id
												strFileName = (new FileInfo(strToFileName)).Name;

												rstRec1["asdoc_filename"] = strFileName;
												rstRec1.UpdateBatch();

												modAdminCommon.Record_Event("Aircraft Spec", $"Added Aircraft Spec: FileName:=[{strFileName}] ", Convert.ToInt32(Double.Parse(strACId)), 0, 0);

											} // If strLocalFileName <> strToFileName Then

										} // If strDocumentId = "0" Then

									} // If bContinue = True Then ' Ok To Update

									rstRec1.Close();

									if (bContinue)
									{

										Load_Specification_Documents_Grid();

										cmdSpecDocumentNew_Click(cmdSpecDocumentNew, new EventArgs());

									}

								}
								else
								{
									MessageBox.Show($"Unable To Find Local Document File!{Environment.NewLine}{strLocalFileName}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
								} // If fso.FileExists(strLocalFileName) = True Then

							}
							else
							{
								MessageBox.Show("Document Has Not Been Added.  Please Drag a Document To The Document Area!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							} // If txtSpecDragDocument.Tag <> "" Then

						}
						else
						{
							MessageBox.Show("Document Subject Is Blank!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						} // If strSubject <> "" Then

					}
					else
					{
						MessageBox.Show("Document - ACID Is Blank!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					} // If (strACId <> "0") And (strACId <> "") Then

					frmSpecDocumentControl.Enabled = true;
					cmdSpecDocumentSave.Enabled = true;

				} // If cmdSpecDocumentSave.Enabled = True Then

				rstRec1 = null;
				fso = null;
			}
			catch (System.Exception excep)
			{

				MessageBox.Show($"Save Document Error!{Environment.NewLine}{excep.Message}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		} // cmdSpecDocumentSave_Click

		private void cmdSpecDocumentView_Click(Object eventSender, EventArgs eventArgs)
		{

			Object fso = new Object();
			object objIE = null;


			if (cmdSpecDocumentView.Enabled)
			{
				try
				{

					cmdSpecDocumentView.Enabled = false;
				}
				catch
				{
				}
				if (ErrorHandlingHelper.ResumeNextExpr<bool>(() => (Convert.ToString(txtSpecDragDocument.Tag) != "")))
				{

					if (ErrorHandlingHelper.ResumeNextExpr<bool>(() => File.Exists(Convert.ToString(txtSpecDragDocument.Tag))))
					{
						try
						{

							// 11/05/2013 - By David D. Cruger
							// The Procedure Will Select Which Browser To Use

							modCommon.ShellOpenURLInBrowser(modAdminCommon.gbl_User_Browser, Convert.ToString(txtSpecDragDocument.Tag));
						}
						catch
						{
						}

					}
					else
					{
						ErrorHandlingHelper.ResumeNext(
							() => {wbSpecBrowser1.Navigate(new Uri("about:blank"));}, 
							() => {MessageBox.Show($"Can Not File Attached File{Environment.NewLine}{Convert.ToString(txtSpecDragDocument.Tag)}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);});
					} // If fso.FileExists(txtSpecDragDocument.Tag) = True Then

				}
				else
				{
					ErrorHandlingHelper.ResumeNext(
						() => {wbSpecBrowser1.Navigate(new Uri("about:blank"));}, 
						() => {MessageBox.Show("No Document On File", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);});
				}
				try
				{ // If (txtSpecDragDocument.Tag <> "") Then

					cmdSpecDocumentView.Enabled = true;
				}
				catch
				{
				}

			} // If cmdSubDocumentView.Enabled = True Then

			fso = null;

		} // cmdSpecDocumentView_Click

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{

			this.Hide();
			this.Close();
			//  frm_AttachSpecDoc.Enabled = False


		}

		private void grd_SpecDocument_Click(Object eventSender, EventArgs eventArgs)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strDocId = "";
			string strDocDir = "";
			string strACId = "";

			try
			{

				if (grd_SpecDocument.Enabled)
				{

					grd_SpecDocument.Enabled = false;

					cmdSpecDocumentNew_Click(cmdSpecDocumentNew, new EventArgs());

					strACId = ($"{txtSpecACId.Text} ").Trim();

					grd_SpecDocument.CurrentColumnIndex = 0;
					grd_SpecDocument.ColSel = 5;

					strDocId = grd_SpecDocument[grd_SpecDocument.CurrentRowIndex, grd_SpecDocument.CurrentColumnIndex].FormattedValue.ToString();

					strQuery1 = "SELECT * ";
					strQuery1 = $"{strQuery1}FROM Aircraft_Specification_Documents ";
					strQuery1 = $"{strQuery1}WHERE (asdoc_id = {strDocId})";

					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if ((!rstRec1.BOF) && (!rstRec1.EOF))
					{

						txtSpecDocumentId.Text = strDocId;
						txtSpecDocumentSubject.Text = ($"{Convert.ToString(rstRec1["asdoc_Subject"])} ").Trim();
						txtSpecDocumentDescription.Text = ($"{Convert.ToString(rstRec1["asdoc_description"])} ").Trim();

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["asdoc_doc_date"]))
						{
							if (Information.IsDate(rstRec1["asdoc_doc_date"]))
							{
								calSpecDocumentDate.SetDate(Convert.ToDateTime(rstRec1["asdoc_doc_date"]));
								txtSpecDocumentDate.Text = Convert.ToDateTime(rstRec1["asdoc_doc_date"]).ToString("MM/dd/yyyy");
							}
						}

						txtSpecDragDocument.Text = $"Drag Document Here{Environment.NewLine}{($"{Convert.ToString(rstRec1["asdoc_filename"])} ").Trim()}";
						strDocDir = modCommon.DLookUp("aconfig_spec_doc_dir", "Application_Configuration");
						txtSpecDragDocument.Tag = $"{strDocDir}\\{ReturnSubDirectoryForFile(strACId)}\\{($"{Convert.ToString(rstRec1["asdoc_filename"])} ").Trim()}"; // This Holds The Path To The File To Add Or On File

						wbSpecBrowser1.Navigate(new Uri(Convert.ToString(txtSpecDragDocument.Tag)));
						cmdSpecDocumentView.Enabled = true;
						cmdSpecDocumentNew.Enabled = true;
						cmdSpecDocumentDelete.Enabled = true;

						if (wbSpecBrowser1.ReadyState == WebBrowserReadyState.Complete)
						{
							Application.DoEvents();
							Application.DoEvents();
							Application.DoEvents();
							Application.DoEvents();
						}

						Application.DoEvents();
						Application.DoEvents();
						Application.DoEvents();
						// wbSpecBrowser1.Busy = False
						// wbSpecBrowser1.Quit
						wbSpecBrowser1.Stop();

					} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

					rstRec1.Close();

					grd_SpecDocument.Enabled = true;

				} // If grd_SpecDocument.Enabled = True Then

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("grd_SpecDocument_Click_Error: ", excep.Message);
			}

		} // grd_SpecDocument_Click

		private void txtSpecDocumentDate_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{

				if (KeyAscii == 32)
				{ // Space Bar

					calSpecDocumentDate.SetDate(DateTime.Now);

					if (txtSpecDocumentDate.Text == "")
					{
						txtSpecDocumentDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
					}
					else
					{
						txtSpecDocumentDate.Text = "";
					}

					KeyAscii = 0;

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

		} // txtSpecDocumentDate_KeyPress

		private void txtSpecDragDocument_DoubleClick(Object eventSender, EventArgs eventArgs)
		{

			string strFromFileName = "";
			string strFileName = "";

			try
			{

				SetButtons(false);

				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.InitDir was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				mdi_ResearchAssistant.DefInstance.CommonDialog1Open.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.DialogTitle was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				mdi_ResearchAssistant.DefInstance.CommonDialog1Open.Title = "Aircraft Spec Docs (PDF)";
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

						strFileName = Path.GetFileName(strFromFileName);

						if (strFileName.Substring(Math.Max(strFileName.Length - 4, 0)).ToLower() == ".pdf")
						{
							txtSpecDragDocument.Tag = strFromFileName;
							txtSpecDragDocument.Text = $"Drag Document Here{Environment.NewLine}{strFileName}";
						}
						else
						{
							MessageBox.Show("Document Extenstion MUST be PDF!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
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

				modAdminCommon.Record_Error("txtSpecDragDocument_DblClick_Error: ", excep.Message);

				SetButtons(true);
			}

		} // txtSpecDragDocument_DblClick

		//UPGRADE_WARNING: (2050) TextBox Event txtSpecDragDocument.OLEDragDrop was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2050
		private void txtSpecDragDocument_OLEDragDrop(DataObject Data, int Effect, int Button, int Shift, float X, float Y)
		{

			string strFromFileName = "";
			string strFileName = "";

			try
			{

				//UPGRADE_ISSUE: (2064) DataObjectFiles property Files.Item was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				strFromFileName = null;// string strFileName Data.Files.Item(1); //gap-note This line must be checked during Blazor stabilization since looks like is using drag/drop mechanism. An equivalent must be defined.

				if (File.Exists(strFromFileName))
				{

					//UPGRADE_WARNING: (2099) Return value for Dir has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2099
					strFileName = FileSystem.Dir(strFromFileName);

					if (strFileName.Substring(Math.Max(strFileName.Length - 4, 0)).ToLower() == ".pdf")
					{
						txtSpecDragDocument.Tag = strFromFileName;
						txtSpecDragDocument.Text = $"Drag Document Here{Environment.NewLine}{strFileName}";
					}
					else
					{
						MessageBox.Show("Document Extenstion MUST be PDF!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					}

				}
				else
				{
					MessageBox.Show($"Unable To Find File{Environment.NewLine}{strFromFileName}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If fso.FileExists(strFromFileName) = True Then
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("txtSpecDragDocument_OLEDragDrop_Error: ", excep.Message);
			}

		} // txtSpecDragDocument_OLEDragDrop

		private void SetButtons(bool bValue) => frmSpecDocumentControl.Enabled = bValue;
		 // SetButtons

		private void Load_Specification_Documents_Grid()
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strACId = "";

			try
			{

				strACId = txtSpecACId.Text;

				if ((strACId != "0") && (strACId != ""))
				{

					grd_SpecDocument.Enabled = false;

					grd_SpecDocument.Clear();
					grd_SpecDocument.RowsCount = 2;
					grd_SpecDocument.FixedRows = 1;
					grd_SpecDocument.FixedColumns = 0;

					grd_SpecDocument.ColumnsCount = 6;
					grd_SpecDocument.CurrentRowIndex = 0;

					grd_SpecDocument.CurrentColumnIndex = 0;
					grd_SpecDocument[grd_SpecDocument.CurrentRowIndex, grd_SpecDocument.CurrentColumnIndex].Value = "DocId";
					grd_SpecDocument.SetColumnWidth(0, 0);
					grd_SpecDocument.CellAlignment = DataGridViewContentAlignment.MiddleRight;
					grd_SpecDocument.CellBackColor = grd_SpecDocument.BackColorFixed;

					grd_SpecDocument.CurrentColumnIndex = 1;
					grd_SpecDocument[grd_SpecDocument.CurrentRowIndex, grd_SpecDocument.CurrentColumnIndex].Value = "Doc Date";
					grd_SpecDocument.SetColumnWidth(1, 67);
					grd_SpecDocument.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
					grd_SpecDocument.CellBackColor = grd_SpecDocument.BackColorFixed;

					grd_SpecDocument.CurrentColumnIndex = 2;
					grd_SpecDocument[grd_SpecDocument.CurrentRowIndex, grd_SpecDocument.CurrentColumnIndex].Value = "Entry Date";
					grd_SpecDocument.SetColumnWidth(2, 133);
					grd_SpecDocument.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
					grd_SpecDocument.CellBackColor = grd_SpecDocument.BackColorFixed;

					grd_SpecDocument.CurrentColumnIndex = 3;
					grd_SpecDocument[grd_SpecDocument.CurrentRowIndex, grd_SpecDocument.CurrentColumnIndex].Value = "Update Date";
					grd_SpecDocument.SetColumnWidth(3, 133);
					grd_SpecDocument.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
					grd_SpecDocument.CellBackColor = grd_SpecDocument.BackColorFixed;

					grd_SpecDocument.CurrentColumnIndex = 4;
					grd_SpecDocument[grd_SpecDocument.CurrentRowIndex, grd_SpecDocument.CurrentColumnIndex].Value = "User Id";
					grd_SpecDocument.SetColumnWidth(4, 50);
					grd_SpecDocument.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
					grd_SpecDocument.CellBackColor = grd_SpecDocument.BackColorFixed;

					grd_SpecDocument.CurrentColumnIndex = 5;
					grd_SpecDocument[grd_SpecDocument.CurrentRowIndex, grd_SpecDocument.CurrentColumnIndex].Value = "Subject";
					grd_SpecDocument.SetColumnWidth(5, 500);
					grd_SpecDocument.CellBackColor = grd_SpecDocument.BackColorFixed;

					grd_SpecDocument.CurrentRowIndex = 1;

					strQuery1 = "SELECT * FROM Aircraft_Specification_Documents ";
					strQuery1 = $"{strQuery1}WHERE (asdoc_ac_id = {strACId}) ";
					strQuery1 = $"{strQuery1}ORDER BY asdoc_id DESC ";

					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if ((!rstRec1.BOF) && (!rstRec1.EOF))
					{

						grd_SpecDocument.Enabled = true;

						do 
						{ // Loop Until rstRec1.EOF = True

							grd_SpecDocument.CurrentColumnIndex = 0;
							grd_SpecDocument[grd_SpecDocument.CurrentRowIndex, grd_SpecDocument.CurrentColumnIndex].Value = Convert.ToString(rstRec1["asdoc_id"]);
							grd_SpecDocument.CellAlignment = DataGridViewContentAlignment.MiddleRight;

							grd_SpecDocument.CurrentColumnIndex = 1;
							grd_SpecDocument[grd_SpecDocument.CurrentRowIndex, grd_SpecDocument.CurrentColumnIndex].Value = "";
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(rstRec1["asdoc_doc_date"]))
							{
								if (Information.IsDate(rstRec1["asdoc_doc_date"]))
								{
									grd_SpecDocument[grd_SpecDocument.CurrentRowIndex, grd_SpecDocument.CurrentColumnIndex].Value = Convert.ToDateTime(rstRec1["asdoc_doc_date"]).ToString("MM/dd/yyyy");
								}
							}
							grd_SpecDocument.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

							grd_SpecDocument.CurrentColumnIndex = 2;
							grd_SpecDocument[grd_SpecDocument.CurrentRowIndex, grd_SpecDocument.CurrentColumnIndex].Value = "";
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(rstRec1["asdoc_entry_date"]))
							{
								if (Information.IsDate(rstRec1["asdoc_entry_date"]))
								{
									grd_SpecDocument[grd_SpecDocument.CurrentRowIndex, grd_SpecDocument.CurrentColumnIndex].Value = Convert.ToDateTime(rstRec1["asdoc_entry_date"]).ToString();
								}
							}
							grd_SpecDocument.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

							grd_SpecDocument.CurrentColumnIndex = 3;
							grd_SpecDocument[grd_SpecDocument.CurrentRowIndex, grd_SpecDocument.CurrentColumnIndex].Value = "";
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(rstRec1["asdoc_update_date"]))
							{
								if (Information.IsDate(rstRec1["asdoc_update_date"]))
								{
									grd_SpecDocument[grd_SpecDocument.CurrentRowIndex, grd_SpecDocument.CurrentColumnIndex].Value = Convert.ToDateTime(rstRec1["asdoc_update_date"]).ToString();
								}
							}
							grd_SpecDocument.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

							grd_SpecDocument.CurrentColumnIndex = 4;
							grd_SpecDocument[grd_SpecDocument.CurrentRowIndex, grd_SpecDocument.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["asdoc_user_id"])} ").Trim();
							grd_SpecDocument.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

							grd_SpecDocument.CurrentColumnIndex = 5;
							grd_SpecDocument[grd_SpecDocument.CurrentRowIndex, grd_SpecDocument.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["asdoc_Subject"])} ").Trim();

							rstRec1.MoveNext();

							if (!rstRec1.EOF)
							{
								grd_SpecDocument.RowsCount++;
								grd_SpecDocument.CurrentRowIndex++;
							}

						}
						while(!rstRec1.EOF);

						grd_SpecDocument.CurrentRowIndex = 1; // Set to first Row

					}
					else
					{
						grd_SpecDocument.FixedRows = 0;
						grd_SpecDocument.RemoveItem(1);
						grd_SpecDocument.RowsCount = 0;
					} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

					rstRec1.Close();

				}
				else
				{
					MessageBox.Show("Aircraft Id Is Blank Or Zero!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If (strACId <> "0") And (strACId <> "") Then

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Load_Specification_Documents_Grid_Error: ", excep.Message);
			}

		} // Load_Specification_Documents_Grid

		private void Form_Activated(Object eventSender, EventArgs eventArgs)
		{
			if (ActivateHelper.myActiveForm != eventSender)
			{
				ActivateHelper.myActiveForm = (Form) eventSender;

				Load_Specification_Documents_Grid();

			}
		} // Form_Activate

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
		private void Form_Load()
		{

			//------------------------------------------------
			// 06/18/2008 - By David D. Cruger
			// Added Option To Delete Attached Specs
			//------------------------------------------------
			if (Convert.ToString(modAdminCommon.snp_User["user_delete_attached_ac_specs_flag"]) == "Y")
			{
				frmSpecDocumentControl.Width = 261;
				frmSpecDocumentControl.Left = 361;
				cmdSpecDocumentDelete.Visible = true;
				cmdSpecDocumentDelete.Enabled = false;
				cmdSpecDocumentDelete.Left = cmdSpecDocumentView.Left + 55 + 7;
			}
			else
			{
				cmdSpecDocumentDelete.Visible = false;
				cmdSpecDocumentDelete.Enabled = false;
				frmSpecDocumentControl.Width = 199;
				frmSpecDocumentControl.Left = 423;
			}

			modCommon.CenterFormOnHomebaseMainForm(this);

			cmdSpecDocumentNew_Click(cmdSpecDocumentNew, new EventArgs());


		} // Form_Load
	}
}