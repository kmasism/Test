using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Gui.Controls;
using UpgradeHelpers.Helpers;
using UpgradeStubs;

namespace JETNET_Homebase
{
	internal partial class frm_AircraftPictures
		: System.Windows.Forms.Form
	{

		public frm_AircraftPictures()
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
			isInitializingComponent = true;
			InitializeComponent();
			isInitializingComponent = false;
			ReLoadForm(false);
		}


		private void frm_AircraftPictures_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}

		public int inACID = 0;
		public int inJournID = 0;

		private int RememberListIndex = 0;
		private bool ChangesWereMade = false;
		private bool SeqChangesWereMade = false;

		private bool ClickStop = false;

		private int[] PicSeqNo = null;

		//UPGRADE_NOTE: (7001) The following declaration (InsertJournalNote) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void InsertJournalNote(string strSubject)
		//{
			//
			//string strInsert1 = "";
			//System.DateTime dtSystemDateTime = DateTime.FromOADate(0);
			//
			//try
			//{
				//
				//if (strSubject != "")
				//{
					//
					//dtSystemDateTime = DateTime.Parse(modAdminCommon.GetSystemDateTime());
					//
					//strInsert1 = "INSERT INTO Journal (journ_date, journ_subcategory_code, journ_subject, journ_description, ";
					//strInsert1 = $"{strInsert1}journ_ac_id,journ_comp_id, journ_contact_id, journ_user_id, journ_entry_date, journ_entry_time, ";
					//strInsert1 = $"{strInsert1}journ_account_id, journ_prior_account_id,journ_status, ";
					//strInsert1 = $"{strInsert1}journ_customer_note, journ_action_date ";
					//
					//strInsert1 = $"{strInsert1}) VALUES (";
					//strInsert1 = $"{strInsert1}'{DateTime.Now.ToString("MM/dd/yyyy")}', ";
					//strInsert1 = $"{strInsert1}'RN', ";
					//strInsert1 = $"{strInsert1}'{($"{strSubject} ").Trim()}', ";
					//strInsert1 = $"{strInsert1}'', ";
					//strInsert1 = $"{strInsert1}{inACID.ToString()}, ";
					//strInsert1 = $"{strInsert1}0, ";
					//strInsert1 = $"{strInsert1}0, ";
					//strInsert1 = $"{strInsert1}'{modAdminCommon.gbl_User_ID}', ";
					//strInsert1 = $"{strInsert1}'{dtSystemDateTime.ToString("MM/dd/yyyy")}', ";
					//strInsert1 = $"{strInsert1}'{dtSystemDateTime.ToString("HH:mm:ss")}', ";
					//strInsert1 = $"{strInsert1}'{modAdminCommon.gbl_Account_ID}', ";
					//strInsert1 = $"{strInsert1}'', ";
					//strInsert1 = $"{strInsert1}'A', ";
					//strInsert1 = $"{strInsert1}'', ";
					//strInsert1 = $"{strInsert1}'{DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}'";
					//strInsert1 = $"{strInsert1})";
					//
					//DbCommand TempCommand = null;
					//TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					//UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					//TempCommand.CommandText = strInsert1;
					////UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					////UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					//TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					//UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					//TempCommand.ExecuteNonQuery();
					//
				//} // If strSubject <> "" Then
			//}
			//catch (System.Exception excep)
			//{
				//
				//modAdminCommon.Record_Error("InsertJournalNote_Error: ", excep.Message);
			//}
			//
		//} // InsertJournalNote

		private void FillPicturesList()
		{

			ADORecordSetHelper snpPictures = new ADORecordSetHelper(); //6/14/04
			string strFileName = "";
			string strListItem = "";
			int NumPics = 0;

			lstACPics.Items.Clear();
			PicSeqNo = new int[1];
			txtDate.Text = "";
			txtUserId.Text = "";
			txtSubject.Text = "";
			//   movACMovie.Visible = False
			ClickStop = true;
			chkHide.CheckState = CheckState.Unchecked;
			ClickStop = false;
			imgACPicture.Visible = false;

			string Query = "SELECT * FROM Aircraft_Pictures ";
			Query = $"{Query}WHERE acpic_ac_id = {inACID.ToString()} ";
			Query = $"{Query}AND acpic_journ_id = {inJournID.ToString()} ";
			if (Chk_ShowAll.CheckState == CheckState.Unchecked)
			{
				Query = $"{Query} and acpic_hide_flag = 'N' ";
			}
			Query = $"{Query}ORDER BY acpic_seq_no";

			snpPictures.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

			if (!(snpPictures.BOF && snpPictures.EOF))
			{
				snpPictures.MoveFirst();

				while(!snpPictures.EOF)
				{
					strFileName = $"{inACID.ToString()}-{inJournID.ToString()}-{Convert.ToString(snpPictures["acpic_id"])}.{Convert.ToString(snpPictures["acpic_image_type"])}";
					strListItem = ($"{Convert.ToString(snpPictures["acpic_subject"])}").Trim();
					if (Strings.Len(strListItem) < 45)
					{
						strListItem = $"{strListItem}{new String(' ', 45 - Strings.Len(strListItem))}{Convert.ToString(snpPictures["acpic_hide_flag"])} {strFileName}";
					}
					else
					{
						// strListItem = strListItem & strFileName
						strListItem = $"{strListItem}{Convert.ToString(snpPictures["acpic_hide_flag"])} {strFileName}";
					}
					lstACPics.AddItem(strListItem);
					lstACPics.SetItemData(lstACPics.Items.Count - 1, Convert.ToInt32(Double.Parse(($"{Convert.ToString(snpPictures["acpic_id"])}").Trim())));

					NumPics = 1 + PicSeqNo.GetUpperBound(0);
					PicSeqNo = ArraysHelper.RedimPreserve(PicSeqNo, new int[]{NumPics + 1});
					PicSeqNo[NumPics] = Convert.ToInt32(snpPictures["acpic_seq_no"]);
					snpPictures.MoveNext();
				};
			}

			snpPictures.Close();
			snpPictures = null;

			SeqChangesWereMade = false;
			ChangesWereMade = false;

			if (RememberListIndex > -1 && RememberListIndex < lstACPics.Items.Count)
			{
				ListBoxHelper.SetSelectedIndex(lstACPics, RememberListIndex);
			}

		}

		private int GetNextSeqNo()
		{

			int result = 0;
			ADORecordSetHelper snpSeqNo = new ADORecordSetHelper(); //aey 6/14/04

			string Query = "SELECT MAX(acpic_seq_no) AS MaxSeqNo ";
			Query = $"{Query}FROM Aircraft_Pictures ";
			Query = $"{Query}WHERE acpic_ac_id = {inACID.ToString()} ";
			Query = $"{Query}AND acpic_journ_id = {inJournID.ToString()}";

			snpSeqNo.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

			if (!(snpSeqNo.BOF && snpSeqNo.EOF))
			{
				snpSeqNo.MoveFirst();
				result = Convert.ToInt32(Conversion.Val(($"{Convert.ToString(snpSeqNo["maxSeqNo"])}").Trim()) + 1);
			}
			else
			{
				result = 1;
			}

			snpSeqNo.Close();

			return result;
		}

		private int GetPicID(int inSeqNo)
		{

			int result = 0;
			ADORecordSetHelper snpSeqNo = new ADORecordSetHelper(); //aey 6/14/04

			string Query = "SELECT acpic_id ";
			Query = $"{Query}FROM Aircraft_Pictures ";
			Query = $"{Query}WHERE acpic_ac_id = {inACID.ToString()} ";
			Query = $"{Query}AND acpic_journ_id = {inJournID.ToString()} ";
			Query = $"{Query}AND acpic_seq_no = {inSeqNo.ToString()}";

			snpSeqNo.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

			if (!(snpSeqNo.BOF && snpSeqNo.EOF))
			{
				snpSeqNo.MoveFirst();
				result = Convert.ToInt32(Double.Parse(($"{Convert.ToString(snpSeqNo["acpic_id"])}").Trim()));
			}
			else
			{
				result = 0;
			}

			snpSeqNo.Close();

			return result;
		}

		private void SavePictures()
		{

			StringBuilder Query = new StringBuilder();
			int lPicId = 0;

			if (ListBoxHelper.GetSelectedIndex(lstACPics) >= 0)
			{

				lPicId = lstACPics.GetItemData(ListBoxHelper.GetSelectedIndex(lstACPics));

				Query = new StringBuilder("UPDATE Aircraft_Pictures SET ");

				if (txtSubject.Text.Trim() != "")
				{
					Query.Append($"acpic_subject = '{StringsHelper.Replace(txtSubject.Text, "'", "''", 1, -1, CompareMethod.Binary)}', ");
				}
				else
				{
					MessageBox.Show("You Must Have A Subject", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					txtSubject.Focus();
					return;
				}

				if (txtDate.Text.Trim() != "")
				{

					if (Information.IsDate(txtDate.Text.Trim()))
					{
						Query.Append($"acpic_date = '{DateTime.Parse(txtDate.Text).ToString("MM/dd/yyyy")}', ");
					}
					else
					{
						MessageBox.Show("Invalid Date", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						txtDate.Focus();
						return;
					}

				}
				else
				{
					Query.Append("acpic_date = NULL, ");
				} // If Trim(txtDate.Text) <> "" Then

				if (chkHide.CheckState == CheckState.Checked)
				{
					Query.Append("acpic_hide_flag = 'Y', ");
				}
				else
				{
					Query.Append("acpic_hide_flag = 'N', ");
				}

				Query.Append("acpic_action_date = NULL ");

				Query.Append($"WHERE (acpic_id = {lPicId.ToString()}) ");

				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = Query.ToString();
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();

				if (SeqChangesWereMade)
				{

					int tempForEndVar = lstACPics.Items.Count - 1;
					for (int i = 0; i <= tempForEndVar; i++)
					{
						Query = new StringBuilder("UPDATE Aircraft_Pictures ");
						Query.Append($"SET acpic_seq_no = {(i + 1).ToString()}, ");
						Query.Append("acpic_action_date = NULL ");
						Query.Append($"WHERE acpic_id = {lstACPics.GetItemData(i).ToString()}");

						DbCommand TempCommand_2 = null;
						TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
						TempCommand_2.CommandText = Query.ToString();
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand_2.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
						TempCommand_2.ExecuteNonQuery();

						if (Convert.ToDouble(inACID) > 0)
						{
							Query = new StringBuilder($"UPDATE Aircraft SET ac_action_date = NULL WHERE ac_id = {inACID.ToString()} AND ac_journ_id = {inJournID.ToString()}");
							DbCommand TempCommand_3 = null;
							TempCommand_3 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_3);
							TempCommand_3.CommandText = Query.ToString();
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'ADODB.ExecuteOptionEnum' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
							TempCommand_3.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_3);
							TempCommand_3.ExecuteNonQuery();
						}

					}

				} // If SeqChangesWereMade Then


				modAdminCommon.Record_Event("Aircraft Pictures", $"Saved Aircraft Picture: {lPicId.ToString()}", inACID, inJournID, 0);

				FillPicturesList();

			} // If lstACPics.ListIndex >= 0 Then

		} // SavePictures

		public void Setup_attach_picture_subject(string strFileName)
		{

			lbl_pic[0].Visible = true;
			lbl_pic[1].Visible = true;
			cbo_subject_add.Visible = true;
			cmd_add_subject.Visible = true;
			cbo_subject_add.Tag = strFileName;

		}

		//UPGRADE_WARNING: (2074) ComboBox event cbo_subject_drop.Change was upgraded to cbo_subject_drop.TextChanged which has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2074
		private bool isInitializingComponent;
		private void cbo_subject_drop_TextChanged(Object eventSender, EventArgs eventArgs)
		{
			if (isInitializingComponent)
			{
				return;
			}

			txtSubject.Text = cbo_subject_drop.Text;

		}

		private void cbo_subject_drop_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs) => txtSubject.Text = cbo_subject_drop.Text;


		private void Chk_ShowAll_CheckStateChanged(Object eventSender, EventArgs eventArgs) => FillPicturesList();


		private void chkHide_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{

			if (!ClickStop)
			{
				ChangesWereMade = true;
			}

			ClickStop = false;

		}

		private void Attach_Picture(string strFileName)
		{

			Object fso = new Object();
			FileInfo fFile = null;

			string strInsert1 = "";
			int lSeqNo = 0;
			string strSubject = "";
			string strFileType = "";
			string strExt = "";
			int iPos1 = 0;
			string strToFileName = "";
			int lPicId = 0;
			string strType = "";
			bool bResize = false;
			string strMsg = "";

			try
			{

				strFileName = ($"{strFileName} ").Trim();

				if (strFileName != "")
				{

					if (File.Exists(strFileName))
					{

						fFile = new FileInfo(strFileName);

						strType = "";

                        // gap-note: jgamboa. Use FileInfo.Extension instead of File.Type. This
                        // extracts the extension from the file name and avoids regionalization
                        // issues, requiring some code adjustments due to value differences.
                        switch (fFile.Extension.ToLower())
                        {
                            case ".jpeg" : case ".jpg" :
                                strType = "JPG";
                                break;
                            case ".bmp":
                                strType = "BMP";
                                break;
                        }

                        if (strType != "")
						{

							// Default Values
							txtDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
							txtUserId.Text = modAdminCommon.gbl_User_ID;
							txtSubject.Text = "";
							chkHide.CheckState = CheckState.Unchecked;
							imgACPicture.Visible = false;

							iPos1 = (fFile.Name.IndexOf('.') + 1);
							strExt = fFile.Name.Substring(Math.Min(iPos1, fFile.Name.Length)).ToLower(); // Do NOT Save the Period In The Ext
							if (strExt == "jpeg" || strExt == "jpe")
							{
								strExt = "jpg";
							}

							lSeqNo = GetNextSeqNo();

							strSubject = cbo_subject_add.Text;

							if (strSubject != "")
							{

								strSubject = StringsHelper.Replace(strSubject, "'", "''", 1, -1, CompareMethod.Binary);
								strSubject = ($"{strSubject} ").Trim();
								strSubject = strSubject.Substring(0, Math.Min(120, strSubject.Length));
								txtSubject.Text = strSubject;

								cbo_subject_drop.Text = txtSubject.Text;

								strInsert1 = "INSERT INTO Aircraft_Pictures (";
								strInsert1 = $"{strInsert1}acpic_ac_id, ";
								strInsert1 = $"{strInsert1}acpic_journ_id, ";
								strInsert1 = $"{strInsert1}acpic_seq_no, ";
								if (($"{txtDate.Text} ").Trim() != "")
								{
									if (Information.IsDate(txtDate.Text))
									{
										strInsert1 = $"{strInsert1}acpic_date, ";
									}
								}
								strInsert1 = $"{strInsert1}acpic_subject, ";
								strInsert1 = $"{strInsert1}acpic_image_type, ";
								strInsert1 = $"{strInsert1}acpic_user_id";
								strInsert1 = $"{strInsert1}) VALUES ({inACID.ToString()}, {inJournID.ToString()}, {lSeqNo.ToString()}, ";
								if (($"{txtDate.Text} ").Trim() != "")
								{
									if (Information.IsDate(txtDate.Text))
									{
										strInsert1 = $"{strInsert1}'{DateTime.Parse(txtDate.Text).ToString("MM/dd/yyyy")}', ";
									}
								}
								strInsert1 = $"{strInsert1}'{strSubject}', ";
								strInsert1 = $"{strInsert1}'{strExt}', ";
								strInsert1 = $"{strInsert1}'{modAdminCommon.gbl_User_ID}')";

								DbCommand TempCommand = null;
								TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
								UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
								TempCommand.CommandText = strInsert1;
								//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
								//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
								TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
								UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
								TempCommand.ExecuteNonQuery();

								lPicId = GetPicID(lSeqNo);
								strToFileName = $"{modAdminCommon.gbl_AircraftPictures}\\{inACID.ToString()}-{inJournID.ToString()}-{lPicId.ToString()}.jpg";

								// 05/30/2008 - By David D. Cruger
								// Added ReSize and Copy
								bResize = true;
								if (chkAutoResize.CheckState == CheckState.Unchecked)
								{
									bResize = false;
								}

								// 04/04/2017 - By David D. Cruger
								// Changed ReSize Max from 640 to 2048
								if (modImage.CopyImageFromToAndReSize(strFileName, strToFileName, strType, 2048, bResize, true))
								{

									RememberListIndex = lstACPics.Items.Count;

									modAdminCommon.Record_Event("Aircraft Pictures", $"Added Aircraft Picture: {lPicId.ToString()} - {strSubject}", inACID, inJournID, 0);

									FillPicturesList();

								}
								else
								{
									strMsg = $"Error Copy ReSize Image: FileName[{strFileName}] ";
									modAdminCommon.Report_Error(strMsg);
									MessageBox.Show(strMsg, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
								} // If CopyImageFromToAndReSize(strFileName, strToFileName, 640, bResize, True) = True Then

							} // If strSubject <> "" Then

						}
						else
						{
                            // gap-note: jgamboa. Use FileInfo.Extension instead of File.Type.
                            MessageBox.Show($"File Type Must Be JPG or BMP Type!{Environment.NewLine}Type: [{fFile.Extension.ToLower()}]", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        } // If strType <> "" Then

					}
					else
					{
						MessageBox.Show("File Does Not Exists!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					} // If fso.FileExists(strFileName) = True Then

				}
				else
				{
					MessageBox.Show("File Name Is Blank!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If strFileName <> "" Then

				fFile = null;
				fso = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Attach_Picture_Error: ", excep.Message);
			}

		} // Attach_Picture

		private void cmd_add_subject_Click(Object eventSender, EventArgs eventArgs) => Attach_Picture(Convert.ToString(cbo_subject_add.Tag));


		private void cmd_refresh_Click(Object eventSender, EventArgs eventArgs) => FillPicturesList();


		private void cmd_upload_multiple_Click(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			//VB.Global.Load(frm_WebReport.DefInstance);
			frm_WebReport.DefInstance.ac_id = inACID;

			if (modAdminCommon.LOCAL_ADO_DB.ConnectionString.IndexOf("jetnet_ra_test") >= 0)
			{
				frm_WebReport.DefInstance.WhichReport = "Image Uploader Test";
			}
			else
			{
				frm_WebReport.DefInstance.WhichReport = "Image Uploader Live";
			}

			frm_WebReport.DefInstance.ShowDialog();
		}

		private void cmdAdd_Click(Object eventSender, EventArgs eventArgs)
		{


			//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.FileName was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			mdi_ResearchAssistant.DefInstance.CommonDialog1Open.FileName = "";
			//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.DialogTitle was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			mdi_ResearchAssistant.DefInstance.CommonDialog1Open.Title = "Attach Aircraft Picture";
			//UPGRADE_WARNING: (2074) MSComDlg.CommonDialog property mdi_ResearchAssistant.CommonDialog1.Flags was upgraded to mdi_ResearchAssistant.CommonDialog1Open.ShowReadOnly which has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2074
			//UPGRADE_WARNING: (2074) FileOpenConstants STRING RESOURCE ["IDS-CONSTANT"] NOT FOUND FileOpenConstants.cdlOFNHideReadOnly was upgraded to OpenFileDialog.ShowReadOnly which has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2074
			mdi_ResearchAssistant.DefInstance.CommonDialog1Open.ShowReadOnly = false;
			//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.Filter was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			//UPGRADE_WARNING: (2081) Filter has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
			mdi_ResearchAssistant.DefInstance.CommonDialog1Open.Filter = "Image Files (*.jpg)|*.jpg|Movie Files (*.mpg;*.mpeg)|*.mpg;*.mpeg|All Files (*.*)|*.*";
			mdi_ResearchAssistant.DefInstance.CommonDialog1Open.ShowDialog();

			//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.FileName was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			string strFileName = ($"{mdi_ResearchAssistant.DefInstance.CommonDialog1Open.FileName} ").Trim();
			if (strFileName != "")
			{

				Setup_attach_picture_subject(strFileName);

			} // If strFileName <> "" Then

		} // cmdAdd_Click

		private void cmdClose_Click(Object eventSender, EventArgs eventArgs)
		{

			DialogResult Response = (DialogResult) 0;

			if (ChangesWereMade || SeqChangesWereMade)
			{
				Response = MessageBox.Show("Do you want to save your changes?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNoCancel);
				if (Response == System.Windows.Forms.DialogResult.Yes)
				{
					cmdSave_Click(cmdSave, new EventArgs());
				}
				else if (Response == System.Windows.Forms.DialogResult.Cancel)
				{ 
					return;
				}
			}

			this.Close();

		}

		private void cmdDown_Click(Object eventSender, EventArgs eventArgs)
		{

			int RememberIndex = 0;
			string RememberText = "";
			int RememberItemData = 0;
			string Query = "";

			if ((ListBoxHelper.GetSelectedIndex(lstACPics) < lstACPics.Items.Count - 1) && (ListBoxHelper.GetSelectedIndex(lstACPics) >= 0))
			{

				if (ChangesWereMade)
				{
					if (MessageBox.Show("Do you want to save your changes?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
					{
						cmdSave_Click(cmdSave, new EventArgs());
						ChangesWereMade = false;
						return;
					}
				}

				RememberIndex = ListBoxHelper.GetSelectedIndex(lstACPics);
				RememberText = lstACPics.Text;
				RememberItemData = lstACPics.GetItemData(ListBoxHelper.GetSelectedIndex(lstACPics));

				lstACPics.RemoveItem(ListBoxHelper.GetSelectedIndex(lstACPics));
				lstACPics.AddItem(RememberText, RememberIndex + 1);
				lstACPics.SetItemData(RememberIndex + 1, RememberItemData);

				ListBoxHelper.SetSelectedIndex(lstACPics, RememberIndex + 1);
				SeqChangesWereMade = true;

				if (Convert.ToDouble(inACID) > 0)
				{
					Query = $"UPDATE Aircraft SET ac_action_date = NULL WHERE ac_id = {inACID.ToString()} AND ac_journ_id = {inJournID.ToString()}";
					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'ADODB.ExecuteOptionEnum' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();
				}

			}

		} // cmdDown_Click

		private void cmdRemove_Click(Object eventSender, EventArgs eventArgs)
		{

			string strDelete1 = "";
			string FileToDelete = "";
			int SeqNO = 0;
			int lPicId = 0;

			try
			{

				SeqNO = ListBoxHelper.GetSelectedIndex(lstACPics);
				if (PicSeqNo.GetUpperBound(0) <= SeqNO)
				{
					SeqNO = PicSeqNo[ListBoxHelper.GetSelectedIndex(lstACPics)];
				}

				if (ListBoxHelper.GetSelectedIndex(lstACPics) >= 0)
				{

					lPicId = lstACPics.GetItemData(ListBoxHelper.GetSelectedIndex(lstACPics));

					if (MessageBox.Show("Are you sure you want to delete this picture?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
					{

						FileToDelete = $"{modAdminCommon.gbl_AircraftPictures}\\{inACID.ToString()}-{inJournID.ToString()}-{lPicId.ToString()}.*";

						modAdminCommon.ADO_Transaction("BeginTrans");
						if (modAdminCommon.Record_Delete_Log_Entry("AircraftPicture", inACID, inJournID, SeqNO, 0, "", lPicId))
						{
							modAdminCommon.ADO_Transaction("CommitTrans");

							strDelete1 = "DELETE FROM Aircraft_Pictures ";
							strDelete1 = $"{strDelete1}WHERE (acpic_id = {lPicId.ToString()}) ";

							DbCommand TempCommand = null;
							TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
							TempCommand.CommandText = strDelete1;
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
							TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
							TempCommand.ExecuteNonQuery();

							if (ErrorHandlingHelper.ResumeNextExpr<bool>(() => File.Exists(FileToDelete)))
							{
								try
								{
									File.Delete(FileToDelete);
								}
								catch
								{
								}
							}

							modAdminCommon.Record_Event("Aircraft Pictures", $"Deleted Aircraft Picture: {lPicId.ToString()}", inACID, 0, 0);

							RememberListIndex = 0;

							FillPicturesList();

						}
						else
						{
							modAdminCommon.ADO_Transaction("RollbackTrans");
							MessageBox.Show("Delete Failed", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						} // If Record_Delete_Log_Entry("AircraftPicture", inACID, inJournID, SeqNO, , , lPicId) Then

					} // If MsgBox("Are you sure you want to delete this picture?", vbYesNo) = vbYes Then

				} // If lstACPics.ListIndex >= 0 Then
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("cmdRemove_Click_Error: ", excep.Message);
			}

		} // cmdRemove_Click

		private void cmdSave_Click(Object eventSender, EventArgs eventArgs) => SavePictures();


		private void cmdUp_Click(Object eventSender, EventArgs eventArgs)
		{

			int RememberIndex = 0;
			string RememberText = "";
			int RememberItemData = 0;
			string Query = "";

			if (ListBoxHelper.GetSelectedIndex(lstACPics) > 0)
			{

				if (ChangesWereMade)
				{
					if (MessageBox.Show("Do you want to save your changes?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
					{
						cmdSave_Click(cmdSave, new EventArgs());
						ChangesWereMade = false;
						return;
					}
				}

				RememberIndex = ListBoxHelper.GetSelectedIndex(lstACPics);
				RememberText = lstACPics.Text;
				RememberItemData = lstACPics.GetItemData(ListBoxHelper.GetSelectedIndex(lstACPics));

				lstACPics.RemoveItem(ListBoxHelper.GetSelectedIndex(lstACPics));

				lstACPics.AddItem(RememberText, RememberIndex - 1);
				lstACPics.SetItemData(RememberIndex - 1, RememberItemData);

				ListBoxHelper.SetSelectedIndex(lstACPics, RememberIndex - 1);
				SeqChangesWereMade = true;

				if (inACID > 0)
				{
					Query = "UPDATE Aircraft SET ac_action_date = NULL ";
					Query = $"{Query}WHERE (ac_id = {inACID.ToString()}) ";
					Query = $"{Query}AND (ac_journ_id = {inJournID.ToString()}) ";
					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'ADODB.ExecuteOptionEnum' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();
				}

			} // If lstACPics.ListIndex > 0 Then

		} // cmdUp_Click

		//UPGRADE_NOTE: (7001) The following declaration (Combo1_Change) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void Combo1_Change()
		//{
			//
			//
		//}

		//UPGRADE_NOTE: (7001) The following declaration (Command1_Click) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void Command1_Click()
		//{
			//
		//}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
		private void Form_Load()
		{

			Fill_Picture_Subjects();

			ChangesWereMade = false;
			SeqChangesWereMade = false;
			Chk_ShowAll.CheckState = CheckState.Unchecked;

			CreateOriginalImageDirectory();

			FillPicturesList();

			lbl_pic[0].Visible = false;
			lbl_pic[1].Visible = false;
			cbo_subject_add.Visible = false;
			cmd_add_subject.Visible = false;



			if (modAdminCommon.gbl_User_ID.Trim() == "mvit" || modAdminCommon.gbl_User_ID.Trim() == "pls" || modAdminCommon.gbl_User_ID.Trim() == "jas" || modAdminCommon.gbl_User_ID.Trim() == "kkf")
			{
			}
			else
			{
				cmd_upload_multiple.Visible = false;
			}



		}

		public void Fill_Picture_Subjects()
		{

			try
			{

				string Query = "";
				ADORecordSetHelper snp_Aircraft_Pic = new ADORecordSetHelper(); //aey 6/10/04

				cbo_subject_drop.Items.Clear();
				cbo_subject_drop.AddItem(modGlobalVars.cEmptyString);

				cbo_subject_add.Items.Clear();
				cbo_subject_add.AddItem(modGlobalVars.cEmptyString);


				Query = "SELECT distinct acpicnm_subject FROM Aircraft_Picture_Names with (NOLOCK) order by acpicnm_subject asc  ";
				snp_Aircraft_Pic.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_Aircraft_Pic.BOF && snp_Aircraft_Pic.EOF))
				{

					while(!snp_Aircraft_Pic.EOF)
					{
						cbo_subject_drop.AddItem(($"{Convert.ToString(snp_Aircraft_Pic["acpicnm_subject"])} ").Trim());
						cbo_subject_add.AddItem(($"{Convert.ToString(snp_Aircraft_Pic["acpicnm_subject"])} ").Trim());
						snp_Aircraft_Pic.MoveNext();
					};
					cbo_subject_drop.SelectedIndex = 0;
					cbo_subject_add.SelectedIndex = 0;
				}

				snp_Aircraft_Pic.Close();
				snp_Aircraft_Pic = null;
			}
			catch
			{

				this.Cursor = CursorHelper.CursorDefault;
			}

		}


		private void SetButtons(bool bValue) => frmAction.Enabled = bValue;
		 // SetButtons

		private void frmAddPicture_DoubleClick(Object eventSender, EventArgs eventArgs)
		{

			string strFileName = "";
			string strFromFileName = "";

			try
			{

				SetButtons(false);

				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.InitDir was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				mdi_ResearchAssistant.DefInstance.CommonDialog1Open.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.DialogTitle was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				mdi_ResearchAssistant.DefInstance.CommonDialog1Open.Title = "Aircraft Pictures";
				//UPGRADE_WARNING: (2074) MSComDlg.CommonDialog property mdi_ResearchAssistant.CommonDialog1.Flags was upgraded to mdi_ResearchAssistant.CommonDialog1Open.ShowReadOnly which has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2074
				//UPGRADE_WARNING: (2074) FileOpenConstants STRING RESOURCE ["IDS-CONSTANT"] NOT FOUND FileOpenConstants.cdlOFNHideReadOnly was upgraded to OpenFileDialog.ShowReadOnly which has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2074
				mdi_ResearchAssistant.DefInstance.CommonDialog1Open.ShowReadOnly = false;
				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.Filter was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (2081) Filter has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				mdi_ResearchAssistant.DefInstance.CommonDialog1Open.Filter = "All Files|*.*";
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

						// changed MSW - 11/9/22
						Setup_attach_picture_subject(strFromFileName);
						//Attach_Picture strFromFileName

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

				modAdminCommon.Record_Error("frmAddPicture_DblClick_Error", excep.Message);

				SetButtons(true);
			}

		} // frmAddPicture_DblClick

		//-----------------------------------------------------
		// 05/21/2008 - By David D. Cruger
		// Added Drag Drop Picture To Frame For Adding
		//-----------------------------------------------------

		//UPGRADE_WARNING: (2050) Frame Event frmAddPicture.OLEDragDrop was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2050
		private void frmAddPicture_OLEDragDrop(DataObject Data, int Effect, int Button, int Shift, float X, float Y)
		{


			SetButtons(false);

			//UPGRADE_ISSUE: (2064) DataObjectFiles property Files.Item was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			string strFileName = null;// string strFileName = Data.Files.Item(1); //gap-note This line must be checked during Blazor stabilization since looks like is using drag/drop mechanism. An equivalent must be defined .This method does not have references.

			// changed from Attach_Picture
			Setup_attach_picture_subject(strFileName);

			SetButtons(true);

		} // frmAddPicture_OLEDragDrop

		// 05/30/2008 - By David D. Cruger
		// Make Sure Original Picture Image Directory
		// Is Available
		private void CreateOriginalImageDirectory()
		{

			Object fso = new Object();

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strMainDir = "";
			string strFolderName = "";
			string strMake = "";
			string strModel = "";
			string strSerNbr = "";

			try
			{

				//-------------------------------------
				// 08/19/2008 - By David D. Cruger
				// Made this a configuration option
				//-------------------------------------
				strMainDir = modCommon.DLookUp("aconfig_aircraft_pictures_original", "Application_Configuration", "aconfig_aircraft_pictures_original IS NOT NULL");

				if (Directory.Exists(strMainDir))
				{

					strQuery1 = "SELECT amod_airframe_type_code, amod_type_code, amod_make_name, amod_model_name, ac_ser_no_full ";
					strQuery1 = $"{strQuery1}FROM Aircraft ";
					strQuery1 = $"{strQuery1}INNER JOIN Aircraft_Model ON ac_amod_id = amod_id ";
					strQuery1 = $"{strQuery1}WHERE (ac_id = {inACID.ToString()}) ";
					strQuery1 = $"{strQuery1}AND (ac_journ_id = {inJournID.ToString()}) ";

					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if ((!rstRec1.BOF) && (!rstRec1.EOF))
					{


						switch(Convert.ToString(rstRec1["amod_type_code"]))
						{
							case "J" : 
								strFolderName = $"{strMainDir}Jets\\"; 
								 
								break;
							case "T" : 
								 
								switch(Convert.ToString(rstRec1["amod_airframe_type_code"]))
								{
									case "F" : 
										strFolderName = $"{strMainDir}Turbos\\"; 
										break;
									case "R" : 
										strFolderName = $"{strMainDir}Turbines\\"; 
										break;
								} 
								 
								break;
							case "E" : 
								strFolderName = $"{strMainDir}Executive\\"; 
								 
								break;
							case "P" : 
								strFolderName = $"{strMainDir}Pistons\\"; 
								 
								break;
						} // Select Case rstRec1!amod_type_code

						if (Directory.Exists(strFolderName))
						{

							strMake = ($"{Convert.ToString(rstRec1["amod_make_name"])} ").Trim();
							strMake = StringsHelper.Replace(strMake, "/", "-", 1, -1, CompareMethod.Binary); // AGUSTA/WESTLAND = AGUSTA-WESTLAND

							strModel = ($"{Convert.ToString(rstRec1["amod_model_name"])} ").Trim().ToUpper();
							strModel = StringsHelper.Replace(strModel, "/", "-", 1, -1, CompareMethod.Binary); // OH-13/M74 = 0H-13-M74

							strSerNbr = ($"{Convert.ToString(rstRec1["ac_ser_no_full"])} ").Trim().ToUpper();
							strSerNbr = StringsHelper.Replace(strSerNbr, "/", "-", 1, -1, CompareMethod.Binary); // 2385/40 = 2385-40

							// Does Make Folder Exist
							strFolderName = $"{strFolderName}{strMake}\\";
							if (!Directory.Exists(strFolderName))
							{
								Directory.CreateDirectory(strFolderName);
							}

							strFolderName = $"{strFolderName}{strModel}\\";
							if (!Directory.Exists(strFolderName))
							{
								Directory.CreateDirectory(strFolderName);
							}

							strFolderName = $"{strFolderName}{strSerNbr}\\";
							if (!Directory.Exists(strFolderName))
							{
								Directory.CreateDirectory(strFolderName);
							}

							if (Directory.Exists(strFolderName))
							{
								lblOpenOriginalImageDirectory.Enabled = true;
								lblOpenOriginalImageDirectory.Visible = true;
								lblOpenOriginalImageDirectory.Tag = strFolderName;
							}
							else
							{
								lblOpenOriginalImageDirectory.Enabled = false;
								lblOpenOriginalImageDirectory.Visible = false;
								MessageBox.Show($"Unable To Find and/or Create Original Picture Folder{Environment.NewLine}{strFolderName}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							} // If fso.FolderExists(strFolderName) = True Then

						}
						else
						{
							MessageBox.Show($"Unable To Find Original Picture Folder{Environment.NewLine}{strFolderName}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						} // If fso.FolderExists(strFolderName) = True Then

					}
					else
					{
						MessageBox.Show("Unable To Find Aircraft Information", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

					rstRec1.Close();

				}
				else
				{
					MessageBox.Show($"Unable To Find Main Original Picture Folder{Environment.NewLine}{strMainDir}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If fso.FolderExists(strMainDir) = True Then

				rstRec1 = null;
				fso = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("CreateOriginalImageDirectory_Error: ", excep.Message);
			}

		} // CreateOriginalImageDirectory

		private void hide_all_button_Click(Object eventSender, EventArgs eventArgs)
		{


			string strUpdate1 = "";
			if (inACID > 0)
			{

				if (MessageBox.Show("Are You Sure You Want to Hide All Images?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
				{
					strUpdate1 = "UPDATE Aircraft_Pictures SET ";
					strUpdate1 = $"{strUpdate1}acpic_hide_flag = 'Y', ";
					strUpdate1 = $"{strUpdate1}acpic_action_date = NULL ";
					strUpdate1 = $"{strUpdate1}WHERE (acpic_ac_id = {inACID.ToString()}) ";

					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = strUpdate1;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();

					RememberListIndex = 0;

					FillPicturesList();

					modAdminCommon.Record_Event("Aircraft Pictures", $"Hide All Aircraft Pictures: {inACID.ToString()}", 0, inJournID, 0, false, inACID);
				}
				else
				{

				}

			}

		}

		private void lblOpenOriginalImageDirectory_Click(Object eventSender, EventArgs eventArgs)
		{

			Object fso = new Object();

			string strFolderName = "";

			try
			{

				strFolderName = Convert.ToString(lblOpenOriginalImageDirectory.Tag);

				if (Directory.Exists(strFolderName))
				{


					modCommon.ShellOpenURLInBrowser("I", strFolderName);

				}
				else
				{
					MessageBox.Show($"Unable To Find Original Picture Folder{Environment.NewLine}{strFolderName}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If fso.FolderExists(strMainDir) = True Then

				fso = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("lblOpenOriginalImageDirectory_Click_Error: ", excep.Message);
			}

		} // lblOpenOriginalImageDirectory_Click

		private void lblViewAllActivePictures_Click(Object eventSender, EventArgs eventArgs)
		{

			string strWebPage = "";

			try
			{

				strWebPage = $"{modAdminCommon.gbl_WebSite}/help/Find_Aircraft_Pictures_By_ACID.asp?ACId={inACID.ToString()}";

				modCommon.ShellOpenURLInBrowser(modAdminCommon.gbl_User_Browser, strWebPage);
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("lblViewAllActivePictures_Click_Error: ", excep.Message);
			}

		} // lblViewAllActivePictures_Click

		private void lstACPics_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{

			string Query = "";
			ADORecordSetHelper snpPics = new ADORecordSetHelper(); //8/1/05 aey converted to ado
			string FileType = "";
			int iPos1 = 0;
			string strFileName = "";

			try
			{

				if (!ClickStop)
				{

					if (ChangesWereMade)
					{
						if (MessageBox.Show("Do you want to save your changes?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
						{
							ClickStop = true;
							ListBoxHelper.SetSelectedIndex(lstACPics, RememberListIndex);
							cmdSave_Click(cmdSave, new EventArgs());
							return;
						}
					}

					txtDate.Text = "";
					txtUserId.Text = "";
					txtSubject.Text = "";

					ClickStop = true;
					chkHide.CheckState = CheckState.Unchecked;
					ClickStop = false;

					if (Strings.Len(modAdminCommon.gbl_AircraftPictures.Trim()) > 0)
					{

						iPos1 = lstACPics.Text.LastIndexOf(".") + 1;
						FileType = lstACPics.Text.Substring(Math.Min(iPos1, lstACPics.Text.Length)).ToLower();
						if (FileType == "jpeg" || FileType == "jpe")
						{
							FileType = "jpg";
						}

						strFileName = $"{modAdminCommon.gbl_AircraftPictures}\\{inACID.ToString()}-{inJournID.ToString()}-{lstACPics.GetItemData(ListBoxHelper.GetSelectedIndex(lstACPics)).ToString()}.{FileType}";
						if (File.Exists(strFileName))
						{

							if (FileType == "jpg")
							{
								imgACPicture.Image = Image.FromFile(strFileName);
								imgACPicture.Width = 700;
								imgACPicture.Height = 433;
								Application.DoEvents();
								imgACPicture.Visible = true;
							}

							if ((FileType == "mpg") || (FileType == "mpeg"))
							{
								imgACPicture.Visible = false;
							}

						}
						else
						{
							imgACPicture.Visible = false;
						} // If gfso.FileExists(strFileName) = True Then


					}

					Query = "SELECT * FROM Aircraft_Pictures ";
					Query = $"{Query}WHERE acpic_id = {lstACPics.GetItemData(ListBoxHelper.GetSelectedIndex(lstACPics)).ToString()}";

					snpPics.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!(snpPics.BOF && snpPics.EOF))
					{
						snpPics.MoveFirst();

						// 05/30/2008 - By David D. Cruger
						// Use acpic_date if exists else use entry date
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snpPics["acpic_date"]))
						{
							txtDate.Text = Convert.ToDateTime(snpPics["acpic_date"]).ToString("MM/dd/yyyy");
						}
						else
						{
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(snpPics["acpic_entry_date"]))
							{
								txtDate.Text = Convert.ToDateTime(snpPics["acpic_entry_date"]).ToString("MM/dd/yyyy");
							}
						}

						// 05/30/2008 - By David D. Cruger
						// Display User Who Added Image
						txtUserId.Text = ($"{Convert.ToString(snpPics["acpic_user_id"])}").Trim();
						txtSubject.Text = ($"{Convert.ToString(snpPics["acpic_subject"])}").Trim();
						cbo_subject_drop.Text = txtSubject.Text;

						if (($"{Convert.ToString(snpPics["acpic_hide_flag"])}").Trim().ToUpper() == "Y")
						{
							ClickStop = true;
							chkHide.CheckState = CheckState.Checked;
							ClickStop = false;
						}
						else
						{
							ClickStop = true;
							chkHide.CheckState = CheckState.Unchecked;
							ClickStop = false;
						}
					}

					snpPics.Close();
					snpPics = null;

					RememberListIndex = ListBoxHelper.GetSelectedIndex(lstACPics);
				}

				lbl_pic[0].Visible = false;
				lbl_pic[1].Visible = false;
				cbo_subject_add.Visible = false;
				cmd_add_subject.Visible = false;



				ClickStop = false;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"lstACPics_Error: {excep.Message}", "AircraftPictures");
				this.Cursor = CursorHelper.CursorDefault;
				snpPics = null;
			}
		}

		private void txtDate_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{
				ChangesWereMade = true;
			}
			finally
			{
				if (KeyAscii == 0)
				{
					eventArgs.Handled = true;
				}
				eventArgs.KeyChar = Convert.ToChar(KeyAscii);
			}
		}

		private void txtSubject_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{
				ChangesWereMade = true;
			}
			finally
			{
				if (KeyAscii == 0)
				{
					eventArgs.Handled = true;
				}
				eventArgs.KeyChar = Convert.ToChar(KeyAscii);
			}
		}
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}