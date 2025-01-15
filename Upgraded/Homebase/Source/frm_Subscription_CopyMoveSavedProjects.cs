using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Gui.Controls;
using UpgradeHelpers.Gui.Utils;
using UpgradeHelpers.Helpers;

namespace JETNET_Homebase
{
	internal partial class frm_Subscription_CopyMoveSavedProjects
		: System.Windows.Forms.Form
	{


		public frm_Subscription_CopyMoveSavedProjects()
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


		// Last Updated 12/20/2011 - By David D. Cruger

		private void AddItemToListBox(string strText)
		{

			lstbCopyMove.AddItem(strText);
			if (lstbCopyMove.Items.Count > 1)
			{
				ListBoxHelper.SetSelectedIndex(lstbCopyMove, lstbCopyMove.Items.Count - 1);
				ListBoxHelper.SetSelected(lstbCopyMove, lstbCopyMove.Items.Count - 1, false);
			}

		} // End Sub AddItemToListBox

		public void SetCompId(string strCompId) => txtCompId.Text = strCompId;


		public void SetCompany(string strCompany) => lblCompany.Text = strCompany;


		public void SetSubId(string strSubId) => txtSubIdOld.Text = strSubId;


		public void SetLogin(string strLogin) => txtLoginOld.Text = strLogin;


		public void SetSeqNbr(string strSeqNbr) => txtSeqNbrOld.Text = strSeqNbr;


		private bool ValidateSubIdLoginSeqNbr(string strSISSCId, string strSubId, string strLogin, string strSeqNbr, ref string strStatus)
		{

			bool bResults = false;

			try
			{

				bResults = true;
				strStatus = "";

				if (strSISSCId != "0" && strSISSCId != "")
				{
					if (!Information.IsNumeric(strSISSCId))
					{
						bResults = false;
						strStatus = $"Failed SISSCId{Environment.NewLine}";
					}
					else
					{
						if (Convert.ToInt32(Double.Parse(strSISSCId)) < 0 || Convert.ToInt32(Double.Parse(strSISSCId)) > 99999)
						{
							bResults = false;
							strStatus = $"Failed SISSCId{Environment.NewLine}";
						}
					}
				}

				if (strSubId != "" && strSubId != "0" && Information.IsNumeric(strSubId))
				{
					if (Convert.ToInt32(Double.Parse(strSubId)) <= 0 || Convert.ToInt32(Double.Parse(strSubId)) > 99999)
					{
						bResults = false;
						strStatus = $"Failed SubId{Environment.NewLine}";
					}
				}
				else
				{
					bResults = false;
					strStatus = $"Failed SubId{Environment.NewLine}";
				}

				if (strLogin == "" || strLogin == "0")
				{
					bResults = false;
					strStatus = (strStatus == $"Failed Login{Environment.NewLine}").ToString();
				}

				if (strSeqNbr != "" && Information.IsNumeric(strSeqNbr))
				{
					if (Convert.ToInt32(Double.Parse(strSeqNbr)) < 0 || Convert.ToInt32(Double.Parse(strSeqNbr)) > 25)
					{
						bResults = false;
						strStatus = (strStatus == "Failed SeqNbr").ToString();
					}
				}
				else
				{
					bResults = false;
					strStatus = (strStatus == "Failed SeqNbr").ToString();
				}


				return bResults;
			}
			catch
			{

				modAdminCommon.Report_Error("ValidateSubIdLoginSeqNbr_Error: ");
			}
			return false;
		} // ValidateSubIdLoginSeqNbr

		private bool DoesSubIdLoginSeqNbrInstallExist(DbConnection cntConn, string strSubId, string strLogin, string strSeqNbr, ref string strContact)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			bool bResults = false;

			try
			{

				bResults = false;
				strContact = "";

				strQuery1 = "SELECT subins_sub_id, subins_login, subins_seq_no, subins_platform_name ";
				strQuery1 = $"{strQuery1}FROM Subscription_Install WITH (NOLOCK) WHERE (subins_sub_id = {strSubId}) ";
				strQuery1 = $"{strQuery1}AND (subins_login = '{strLogin}') AND (subins_seq_no = {strSeqNbr}) AND (subins_active_flag = 'Y') ";

				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{
					bResults = true;
					strContact = ($"{Convert.ToString(rstRec1["subins_platform_name"])} ").Trim();
				}

				rstRec1.Close();

				rstRec1 = null;


				return bResults;
			}
			catch
			{

				modAdminCommon.Report_Error("DoesSubIdLoginSeqNbrInstallExist_Error: ");
			}
			return false;
		} // DoesSubIdLoginSeqNbrInstallExist

		private bool DoesSubIdLoginSeqNbrHaveSavedProjectsClientFolders(DbConnection cntConn, string strSISSCId, string strCFId, string strSISEId, string strSubId, string strLogin, string strSeqNbr, ref int lNbrSavedProjects, ref int lNbrClientFolders, ref int lNbrSavedExports)
		{

			bool result = false;
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			bool bResults = false;

			try
			{

				bResults = false;
				lNbrSavedProjects = 0;
				lNbrClientFolders = 0;
				lNbrSavedExports = 0;

				if (optProjects.Checked)
				{

					strQuery1 = "SELECT COUNT(sissc_id) As lNbr FROM Subscription_Install_Saved_Search_Criteria WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1}WHERE (sissc_sub_id = {strSubId}) ";
					strQuery1 = $"{strQuery1}AND (sissc_login = '{strLogin}')  AND (sissc_seq_no = {strSeqNbr}) ";

					if (strSISSCId != "0" && strSISSCId != "")
					{
						strQuery1 = $"{strQuery1}AND (sissc_id = {strSISSCId}) ";
					}

				} // If optProjects.Value = True Then

				if (optFolders.Checked)
				{

					strQuery1 = "SELECT COUNT(cfolder_id) As lNbr  FROM Client_Folder WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1}WHERE (cfolder_sub_id = {strSubId})  AND (cfolder_login = '{strLogin}')  AND (cfolder_seq_no = {strSeqNbr}) ";

					if (strCFId != "0" && strCFId != "")
					{
						strQuery1 = $"{strQuery1}AND (cfolder_id = {strCFId}) ";
					}

				}

				if (optSavedExports.Checked)
				{

					strQuery1 = "SELECT COUNT(sise_id) As lNbr FROM Subscription_Install_Saved_Exports WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1}WHERE (sise_sub_id = {strSubId}) ";
					strQuery1 = $"{strQuery1}AND (sise_login = '{strLogin}') AND (sise_seq_no = {strSeqNbr}) ";

					if (strSISEId != "0" && strSISEId != "")
					{
						strQuery1 = $"{strQuery1}AND (sise_id = {strSISEId}) ";
					}

				} // If optSavedExports.Value = True Then

				rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{
					if (Convert.ToDouble(rstRec1["lNbr"]) > 0)
					{
						bResults = true;
					}
					if (optProjects.Checked)
					{
						lNbrSavedProjects = Convert.ToInt32(rstRec1["lNbr"]);
					}
					if (optFolders.Checked)
					{
						lNbrClientFolders = Convert.ToInt32(rstRec1["lNbr"]);
					}
					if (optSavedExports.Checked)
					{
						lNbrSavedExports = Convert.ToInt32(rstRec1["lNbr"]);
					}
				}

				rstRec1.Close();

				rstRec1 = null;


				return bResults;
			}
			catch
			{

				modAdminCommon.Report_Error("DoesSubIdLoginSeqNbrHaveSavedProjectsClientFolders_Error: ");

				result = false;
			}
			return result;
		} // DoesSubIdLoginSeqNbrHaveSavedProjects

		private bool MoveSavedProjectsToSubIdLoginSeqNbr(DbConnection cntConn, string strCompId, ref int lNbrSavedProjects, string strSISSCId, string strSubIdOld, string strLoginOld, string strSeqNbrOld, string strSubIdNew, string strLoginNew, string strSeqNbrNew, ref string strStatus)
		{
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			StringBuilder strUpdate1 = new StringBuilder();
			string strEventMsg = "";
			bool bResults = false;

			int lCnt1 = 0;

			try
			{

				lblStatus.Text = "Moving Saved Project(s)";
				AddItemToListBox(lblStatus.Text);

				bResults = false;
				strStatus = "";
				lNbrSavedProjects = 0;

				if ((strSubIdOld != strSubIdNew) || (strLoginOld != strLoginNew) || (strSeqNbrOld != strSeqNbrNew))
				{

					strQuery1 = "SELECT * FROM Subscription_Install_Saved_Search_Criteria WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1}WHERE (sissc_sub_id = {strSubIdOld}) ";
					strQuery1 = $"{strQuery1}AND (sissc_login = '{strLoginOld}') AND (sissc_seq_no  = {strSeqNbrOld}) ";

					if (strSISSCId != "0" && strSISSCId != "")
					{
						strQuery1 = $"{strQuery1}AND (sissc_id = {strSISSCId}) ";
					}

					rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
					rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if ((!rstRec1.BOF) && (!rstRec1.EOF))
					{

						rstRec1.ActiveConnection = null;
						lCnt1 = 0;

						do 
						{ // Loop Until rstRec1.EOF = True

							lCnt1++;
							lblStatus.Text = $"Moving Saved Project(s) #{lCnt1.ToString()}";
							Application.DoEvents();

							AddItemToListBox($"Moving - {Convert.ToString(rstRec1["sissc_id"])} - {Convert.ToString(rstRec1["sissc_subject"])}");

							strSISSCId = Convert.ToString(rstRec1["sissc_id"]);

							strUpdate1 = new StringBuilder($"UPDATE Subscription_Install_Saved_Search_Criteria  SET sissc_sub_id = {strSubIdNew}, ");
							strUpdate1.Append($"sissc_login = '{strLoginNew}', sissc_seq_no = {strSeqNbrNew} ");
							strUpdate1.Append($"WHERE (sissc_id = {strSISSCId}) ");

							UpgradeHelpers.DB.TransactionManager.Enlist(cntConn.BeginTransaction());

							DbCommand TempCommand = null;
							TempCommand = cntConn.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
							TempCommand.CommandText = strUpdate1.ToString();
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
							TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
							TempCommand.ExecuteNonQuery();

							UpgradeHelpers.DB.TransactionManager.Commit(cntConn);

							rstRec1.MoveNext();
							Application.DoEvents();

						}
						while(!rstRec1.EOF);

						lNbrSavedProjects = lCnt1;

						strEventMsg = $"{lNbrSavedProjects.ToString()} Saved Project(s) Moved From {strSubIdOld}-{strLoginOld}-{strSeqNbrOld} To {strSubIdNew}-{strLoginNew}-{strSeqNbrNew}";
						modAdminCommon.Record_Event("Subscription Saved Project(s) Moved", strEventMsg, 0, 0, Convert.ToInt32(Double.Parse(strCompId)));

					} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

					rstRec1.Close();

					modCommon.DelaySeconds(1);

				}
				else
				{
					MessageBox.Show($"SubId, Login, SeqNbr (Old/New){Environment.NewLine}Can NOT Be The Same", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If (strSubIdOld <> strSubIdNew) Or (strLoginOld <> strLoginNew) Or (strSeqNbrOld <> strSeqNbrNew) Then

				rstRec1 = null;

				bResults = true;


				return bResults;
			}
			catch (System.Exception excep)
			{

				strStatus = excep.Message;
				modAdminCommon.Report_Error("MoveSavedProjectsToSubIdLoginSeqNbr_Error: ");
			}
			return false;
		} // MoveSavedProjectsToSubIdLoginSeqNbr

		private bool MoveClientFoldersToSubIdLoginSeqNbr(DbConnection cntConn, string strCompId, ref int lNbrClientFolders, string strCFId, string strSubIdOld, string strLoginOld, string strSeqNbrOld, string strSubIdNew, string strLoginNew, string strSeqNbrNew, ref string strStatus)
		{
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			StringBuilder strUpdate1 = new StringBuilder();
			string strEventMsg = "";
			bool bResults = false;

			int lCnt1 = 0;

			try
			{

				lblStatus.Text = "Moving Client Folder(s)";
				AddItemToListBox(lblStatus.Text);

				bResults = false;
				strStatus = "";
				lNbrClientFolders = 0;

				if ((strSubIdOld != strSubIdNew) || (strLoginOld != strLoginNew) || (strSeqNbrOld != strSeqNbrNew))
				{

					strQuery1 = $"SELECT * FROM Client_Folder WITH (NOLOCK) WHERE (cfolder_sub_id = {strSubIdOld}) ";
					strQuery1 = $"{strQuery1}AND (cfolder_login = '{strLoginOld}') AND (cfolder_seq_no  = {strSeqNbrOld}) ";

					if (strCFId != "0" && strCFId != "")
					{
						strQuery1 = $"{strQuery1}AND (cfolder_id = {strCFId}) ";
					}

					rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
					rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if ((!rstRec1.BOF) && (!rstRec1.EOF))
					{

						rstRec1.ActiveConnection = null;
						lCnt1 = 0;

						do 
						{ // Loop Until rstRec1.EOF = True

							lCnt1++;
							lblStatus.Text = $"Moving Client Folder(s) #{lCnt1.ToString()}";
							Application.DoEvents();

							AddItemToListBox($"Moving - {Convert.ToString(rstRec1["cfolder_id"])} - {Convert.ToString(rstRec1["cfolder_name"])}");

							strCFId = Convert.ToString(rstRec1["cfolder_id"]);

							strUpdate1 = new StringBuilder($"UPDATE Client_Folder SET cfolder_sub_id = {strSubIdNew}, ");
							strUpdate1.Append($"cfolder_login = '{strLoginNew}', cfolder_seq_no = {strSeqNbrNew} ");
							strUpdate1.Append($"WHERE (cfolder_id = {strCFId}) ");

							UpgradeHelpers.DB.TransactionManager.Enlist(cntConn.BeginTransaction());

							DbCommand TempCommand = null;
							TempCommand = cntConn.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
							TempCommand.CommandText = strUpdate1.ToString();
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
							TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
							TempCommand.ExecuteNonQuery();

							UpgradeHelpers.DB.TransactionManager.Commit(cntConn);

							rstRec1.MoveNext();
							Application.DoEvents();

						}
						while(!rstRec1.EOF);

						lNbrClientFolders = lCnt1;

						strEventMsg = $"{lNbrClientFolders.ToString()} Client Folder(s) Moved From {strSubIdOld}-{strLoginOld}-{strSeqNbrOld} To {strSubIdNew}-{strLoginNew}-{strSeqNbrNew}";
						modAdminCommon.Record_Event("Subscription Client Folder(s) Moved", strEventMsg, 0, 0, Convert.ToInt32(Double.Parse(strCompId)));

					} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

					rstRec1.Close();

					modCommon.DelaySeconds(1);

				}
				else
				{
					MessageBox.Show($"SubId, Login, SeqNbr (Old/New){Environment.NewLine}Can NOT Be The Same", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If (strSubIdOld <> strSubIdNew) Or (strLoginOld <> strLoginNew) Or (strSeqNbrOld <> strSeqNbrNew) Then

				rstRec1 = null;

				bResults = true;


				return bResults;
			}
			catch (System.Exception excep)
			{

				strStatus = excep.Message;
				modAdminCommon.Report_Error("MoveClientFoldersToSubIdLoginSeqNbr_Error: ");
			}
			return false;
		} // MoveClientFoldersToSubIdLoginSeqNbr

		private bool MoveSavedExportsToSubIdLoginSeqNbr(DbConnection cntConn, string strCompId, ref int lNbrSavedExports, string strSISEId, string strSubIdOld, string strLoginOld, string strSeqNbrOld, string strSubIdNew, string strLoginNew, string strSeqNbrNew, ref string strStatus)
		{
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			StringBuilder strUpdate1 = new StringBuilder();

			string strEventMsg = "";
			bool bResults = false;

			int lCnt1 = 0;

			try
			{

				lblStatus.Text = "Moving Saved Export(s)";
				AddItemToListBox(lblStatus.Text);

				bResults = false;
				strStatus = "";
				lNbrSavedExports = 0;

				if ((strSubIdOld != strSubIdNew) || (strLoginOld != strLoginNew) || (strSeqNbrOld != strSeqNbrNew))
				{

					strQuery1 = $"SELECT * FROM Subscription_Install_Saved_Exports WITH (NOLOCK) WHERE (sise_sub_id = {strSubIdOld}) ";
					strQuery1 = $"{strQuery1}AND (sise_login = '{strLoginOld}')  AND (sise_seq_no  = {strSeqNbrOld}) ";

					if (strSISEId != "0" && strSISEId != "")
					{
						strQuery1 = $"{strQuery1}AND (sise_id = {strSISEId}) ";
					}

					rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
					rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if ((!rstRec1.BOF) && (!rstRec1.EOF))
					{

						rstRec1.ActiveConnection = null;
						lCnt1 = 0;

						UpgradeHelpers.DB.TransactionManager.Enlist(cntConn.BeginTransaction());

						do 
						{ // Loop Until rstRec1.EOF = True

							lCnt1++;
							lblStatus.Text = $"Moving Saved Export(s) #{lCnt1.ToString()}";
							Application.DoEvents();

							AddItemToListBox($"Moving - {Convert.ToString(rstRec1["sise_id"])} - {($"{Convert.ToString(rstRec1["sise_subject"])} ").Trim()}");

							strSISEId = Convert.ToString(rstRec1["sise_id"]);

							strUpdate1 = new StringBuilder($"UPDATE Subscription_Install_Saved_Exports  SET sise_sub_id = {strSubIdNew}, ");
							strUpdate1.Append($"sise_login = '{strLoginNew}', sise_seq_no = {strSeqNbrNew} ");
							strUpdate1.Append($"WHERE (sise_id = {strSISEId}) ");

							DbCommand TempCommand = null;
							TempCommand = cntConn.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
							TempCommand.CommandText = strUpdate1.ToString();
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
							TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
							TempCommand.ExecuteNonQuery();

							rstRec1.MoveNext();
							Application.DoEvents();

						}
						while(!rstRec1.EOF);

						UpgradeHelpers.DB.TransactionManager.Commit(cntConn);

						lNbrSavedExports = lCnt1;

						strEventMsg = $"{lNbrSavedExports.ToString()} Saved Export(s) Moved From {strSubIdOld}-{strLoginOld}-{strSeqNbrOld} To {strSubIdNew}-{strLoginNew}-{strSeqNbrNew}";
						modAdminCommon.Record_Event("Subscription Saved Export(s) Moved", strEventMsg, 0, 0, Convert.ToInt32(Double.Parse(strCompId)));

					} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

					rstRec1.Close();

					modCommon.DelaySeconds(1);

				}
				else
				{
					MessageBox.Show($"SubId, Login, SeqNbr (Old/New){Environment.NewLine}Can NOT Be The Same", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If (strSubIdOld <> strSubIdNew) Or (strLoginOld <> strLoginNew) Or (strSeqNbrOld <> strSeqNbrNew) Then

				rstRec1 = null;

				bResults = true;


				return bResults;
			}
			catch (System.Exception excep)
			{

				strStatus = excep.Message;
				modAdminCommon.Report_Error("MoveSavedExportsToSubIdLoginSeqNbr_Error: ");
			}
			return false;
		} // MoveSavedExportsToSubIdLoginSeqNbr

		private bool CopySavedProjectsToSubIdLoginSeqNbr(DbConnection cntConn, string strCompId, ref int lNbrSavedProjects, string strSISSCId, string strSubIdOld, string strLoginOld, string strSeqNbrOld, string strSubIdNew, string strLoginNew, string strSeqNbrNew, ref string strStatus)
		{

			ADORecordSetHelper rstAdd1 = new ADORecordSetHelper();
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();

			string strAdd1 = "";
			string strQuery1 = "";

			string strEventMsg = "";
			bool bResults = false;

			int lCnt1 = 0;

			try
			{

				bResults = false;
				strStatus = "";
				lNbrSavedProjects = 0;

				if ((strSubIdOld != strSubIdNew) || (strLoginOld != strLoginNew) || (strSeqNbrOld != strSeqNbrNew))
				{

					lblStatus.Text = "Coping Saved Project(s)";
					AddItemToListBox(lblStatus.Text);

					strAdd1 = "SELECT * FROM Subscription_Install_Saved_Search_Criteria WHERE (sissc_id = -1)";

					rstAdd1.CursorLocation = CursorLocationEnum.adUseClient;
					rstAdd1.Open(strAdd1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);

					strQuery1 = $"SELECT * FROM Subscription_Install_Saved_Search_Criteria WITH (NOLOCK) WHERE (sissc_sub_id = {strSubIdOld}) ";
					strQuery1 = $"{strQuery1}AND (sissc_login = '{strLoginOld}')  AND (sissc_seq_no  = {strSeqNbrOld}) ";

					if (strSISSCId != "0" && strSISSCId != "")
					{
						strQuery1 = $"{strQuery1}AND (sissc_id = {strSISSCId}) ";
					}

					rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
					rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if ((!rstRec1.BOF) && (!rstRec1.EOF))
					{

						//------------------------------------------------------
						rstRec1.ActiveConnection = null; // Disconnected

						lCnt1 = 0;

						do 
						{ // Loop Until rstRec1.EOF = True

							lCnt1++;
							lblStatus.Text = $"Coping Saved Project(s) #{lCnt1.ToString()}";
							Application.DoEvents();

							AddItemToListBox($"Copying - {Convert.ToString(rstRec1["sissc_id"])} - {Convert.ToString(rstRec1["sissc_subject"])}");

							UpgradeHelpers.DB.TransactionManager.Enlist(cntConn.BeginTransaction());
							rstAdd1.AddNew();

							int tempForEndVar = rstRec1.FieldsMetadata.Count - 1;
							for (int lCnt2 = 0; lCnt2 <= tempForEndVar; lCnt2++)
							{
								if (rstRec1.GetField(lCnt2).FieldMetadata.ColumnName != "sissc_id")
								{
									if (!Convert.IsDBNull(rstRec1[lCnt2]))
									{
										rstAdd1[lCnt2] = rstRec1[lCnt2];
									}
								}
							}

							rstAdd1["sissc_sub_id"] = Convert.ToInt32(Double.Parse(strSubIdNew));
							rstAdd1["sissc_login"] = strLoginNew;
							rstAdd1["sissc_seq_no"] = Convert.ToInt32(Double.Parse(strSeqNbrNew));
							rstAdd1["sissc_entry_date"] = DateTime.Now;

							rstAdd1.UpdateBatch();
							UpgradeHelpers.DB.TransactionManager.Commit(cntConn);

							rstRec1.MoveNext();
							Application.DoEvents();

						}
						while(!rstRec1.EOF);

						lNbrSavedProjects = lCnt1;

						strEventMsg = $"{lNbrSavedProjects.ToString()} Saved Project(s) Copied From {strSubIdOld}-{strLoginOld}-{strSeqNbrOld} To {strSubIdNew}-{strLoginNew}-{strSeqNbrNew}";
						modAdminCommon.Record_Event("Subscription Saved Project(s) Copied", strEventMsg, 0, 0, Convert.ToInt32(Double.Parse(strCompId)));

					} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

					rstRec1.Close();
					rstAdd1.Close();

					modCommon.DelaySeconds(1);

				}
				else
				{
					MessageBox.Show($"SubId, Login, SeqNbr (Old/New){Environment.NewLine}Can NOT Be The Same", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If (strSubIdOld <> strSubIdNew) Or (strLoginOld <> strLoginNew) Or (strSeqNbrOld <> strSeqNbrNew) Then

				rstRec1 = null;
				rstAdd1 = null;

				bResults = true;


				return bResults;
			}
			catch (System.Exception excep)
			{

				strStatus = excep.Message;
				modAdminCommon.Report_Error("CopySavedProjectsToSubIdLoginSeqNbr_Error: ");
			}
			return false;
		} // CopySavedProjectsToSubIdLoginSeqNbr

		private bool CopyClientFoldersToSubIdLoginSeqNbr(DbConnection cntConn, string strCompId, ref int lNbrClientFolders, string strCFId, string strSubIdOld, string strLoginOld, string strSeqNbrOld, string strSubIdNew, string strLoginNew, string strSeqNbrNew, ref string strStatus)
		{

			ADORecordSetHelper rstAdd1 = new ADORecordSetHelper();
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();

			string strAdd1 = "";
			string strQuery1 = "";

			string strEventMsg = "";
			bool bResults = false;

			int lCnt1 = 0;

			try
			{

				bResults = false;
				strStatus = "";
				lNbrClientFolders = 0;

				if ((strSubIdOld != strSubIdNew) || (strLoginOld != strLoginNew) || (strSeqNbrOld != strSeqNbrNew))
				{

					lblStatus.Text = "Coping Client Folder(s)";
					AddItemToListBox(lblStatus.Text);

					strAdd1 = "SELECT * FROM Client_Folder WHERE (cfolder_id = -1)";

					rstAdd1.CursorLocation = CursorLocationEnum.adUseClient;
					rstAdd1.Open(strAdd1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);

					strQuery1 = $"SELECT * FROM Client_Folder WITH (NOLOCK) WHERE (cfolder_sub_id = {strSubIdOld}) ";
					strQuery1 = $"{strQuery1}AND (cfolder_login = '{strLoginOld}') AND (cfolder_seq_no  = {strSeqNbrOld}) ";

					if (strCFId != "0" && strCFId != "")
					{
						strQuery1 = $"{strQuery1}AND (cfolder_id = {strCFId}) ";
					}

					rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
					rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if ((!rstRec1.BOF) && (!rstRec1.EOF))
					{

						//------------------------------------------------------
						rstRec1.ActiveConnection = null; // Disconnected

						lCnt1 = 0;

						do 
						{ // Loop Until rstRec1.EOF = True

							lCnt1++;
							lblStatus.Text = $"Coping Client Folder(s) #{lCnt1.ToString()}";
							Application.DoEvents();

							AddItemToListBox($"Copying - {Convert.ToString(rstRec1["cfolder_id"])} - {Convert.ToString(rstRec1["cfolder_name"])}");

							UpgradeHelpers.DB.TransactionManager.Enlist(cntConn.BeginTransaction());
							rstAdd1.AddNew();

							int tempForEndVar = rstRec1.FieldsMetadata.Count - 1;
							for (int lCnt2 = 0; lCnt2 <= tempForEndVar; lCnt2++)
							{
								if (rstRec1.GetField(lCnt2).FieldMetadata.ColumnName != "cfolder_id")
								{
									if (!Convert.IsDBNull(rstRec1[lCnt2]))
									{
										rstAdd1[lCnt2] = rstRec1[lCnt2];
									}
								}
							}

							rstAdd1["cfolder_sub_id"] = Convert.ToInt32(Double.Parse(strSubIdNew));
							rstAdd1["cfolder_login"] = strLoginNew;
							rstAdd1["cfolder_seq_no"] = Convert.ToInt32(Double.Parse(strSeqNbrNew));
							rstAdd1["cfolder_entry_date"] = DateTime.Now;

							rstAdd1.UpdateBatch();
							UpgradeHelpers.DB.TransactionManager.Commit(cntConn);

							rstRec1.MoveNext();
							Application.DoEvents();

						}
						while(!rstRec1.EOF);

						lNbrClientFolders = lCnt1;

						strEventMsg = $"{lNbrClientFolders.ToString()} Client Folder(s) Copied From {strSubIdOld}-{strLoginOld}-{strSeqNbrOld} To {strSubIdNew}-{strLoginNew}-{strSeqNbrNew}";
						modAdminCommon.Record_Event("Subscription Client Folder(s) Copied", strEventMsg, 0, 0, Convert.ToInt32(Double.Parse(strCompId)));

					} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

					rstRec1.Close();
					rstAdd1.Close();

					modCommon.DelaySeconds(1);

				}
				else
				{
					MessageBox.Show($"SubId, Login, SeqNbr (Old/New){Environment.NewLine}Can NOT Be The Same", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If (strSubIdOld <> strSubIdNew) Or (strLoginOld <> strLoginNew) Or (strSeqNbrOld <> strSeqNbrNew) Then

				rstRec1 = null;
				rstAdd1 = null;

				bResults = true;


				return bResults;
			}
			catch (System.Exception excep)
			{

				strStatus = excep.Message;
				modAdminCommon.Report_Error("CopyClientFoldersToSubIdLoginSeqNbr_Error: ");
			}
			return false;
		} // CopyClientFoldersToSubIdLoginSeqNbr

		private bool CopySavedExportsToSubIdLoginSeqNbr(DbConnection cntConn, string strCompId, ref int lNbrSavedExports, string strSISEId, string strSubIdOld, string strLoginOld, string strSeqNbrOld, string strSubIdNew, string strLoginNew, string strSeqNbrNew, ref string strStatus)
		{
			// Subscription_Install_Saved_Exports
			ADORecordSetHelper rstAdd1 = new ADORecordSetHelper();
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strAdd1 = "";
			string strQuery1 = "";

			// Subscription_Install_Saved_Export_Fields
			ADORecordSetHelper rstAdd2 = new ADORecordSetHelper();
			ADORecordSetHelper rstRec2 = new ADORecordSetHelper();
			string strAdd2 = "";
			string strQuery2 = "";

			string strEventMsg = "";
			bool bResults = false;

			int lOldSISEId = 0;
			int lNewSISEId = 0;
			int lCnt1 = 0;

			try
			{

				bResults = false;
				strStatus = "";
				lNbrSavedExports = 0;

				if ((strSubIdOld != strSubIdNew) || (strLoginOld != strLoginNew) || (strSeqNbrOld != strSeqNbrNew))
				{

					lblStatus.Text = "Coping Saved Export(s)";
					AddItemToListBox(lblStatus.Text);

					strAdd1 = "SELECT * FROM Subscription_Install_Saved_Exports WHERE (sise_id = -1)";
					rstAdd1.CursorLocation = CursorLocationEnum.adUseClient;
					rstAdd1.Open(strAdd1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);

					strAdd2 = "SELECT * FROM Subscription_Install_Saved_Export_Fields WHERE (sisef_sise_id = -1)";
					rstAdd2.CursorLocation = CursorLocationEnum.adUseClient;
					rstAdd2.Open(strAdd2, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);

					strQuery1 = $"SELECT * FROM Subscription_Install_Saved_Exports WITH (NOLOCK) WHERE (sise_sub_id = {strSubIdOld}) ";
					strQuery1 = $"{strQuery1}AND (sise_login = '{strLoginOld}') AND (sise_seq_no  = {strSeqNbrOld}) ";

					if (strSISEId != "0" && strSISEId != "")
					{
						strQuery1 = $"{strQuery1}AND (sise_id = {strSISEId}) ";
					}

					rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
					rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if ((!rstRec1.BOF) && (!rstRec1.EOF))
					{

						//------------------------------------------------------
						rstRec1.ActiveConnection = null; // Disconnected

						lCnt1 = 0;

						do 
						{ // Loop Until rstRec1.EOF = True

							lCnt1++;
							lblStatus.Text = $"Coping Saved Export(s) #{lCnt1.ToString()}";
							Application.DoEvents();

							lOldSISEId = Convert.ToInt32(rstRec1["sise_id"]);
							AddItemToListBox($"Copying - {Convert.ToString(rstRec1["sise_id"])} - {($"{Convert.ToString(rstRec1["sise_subject"])} ").Trim()}");

							UpgradeHelpers.DB.TransactionManager.Enlist(cntConn.BeginTransaction());
							rstAdd1.AddNew();

							int tempForEndVar = rstRec1.FieldsMetadata.Count - 1;
							for (int lCnt2 = 0; lCnt2 <= tempForEndVar; lCnt2++)
							{
								if (rstRec1.GetField(lCnt2).FieldMetadata.ColumnName != "sise_id")
								{
									if (!Convert.IsDBNull(rstRec1[lCnt2]))
									{
										rstAdd1[lCnt2] = rstRec1[lCnt2];
									}
								}
							}

							rstAdd1["sise_sub_id"] = Convert.ToInt32(Double.Parse(strSubIdNew));
							rstAdd1["sise_login"] = strLoginNew;
							rstAdd1["sise_seq_no"] = Convert.ToInt32(Double.Parse(strSeqNbrNew));
							rstAdd1["sise_entry_date"] = DateTime.Now;

							rstAdd1.UpdateBatch();
							UpgradeHelpers.DB.TransactionManager.Commit(cntConn);

							lNewSISEId = Convert.ToInt32(rstAdd1["sise_id"]);

							//-------------------------------------
							// Now Copy Saved Export Fields

							strQuery2 = $"SELECT * FROM Subscription_Install_Saved_Export_Fields WITH (NOLOCK) WHERE (sisef_sise_id = {lOldSISEId.ToString()})";
							rstRec2.CursorLocation = CursorLocationEnum.adUseClient;
							rstRec2.Open(strQuery2, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);

							if ((!rstRec2.BOF) && (!rstRec2.EOF))
							{

								UpgradeHelpers.DB.TransactionManager.Enlist(cntConn.BeginTransaction());

								do 
								{ // Loop Until rstRec2.EOF = True

									rstAdd2.AddNew();

									int tempForEndVar2 = rstRec2.FieldsMetadata.Count - 1;
									for (int lCnt2 = 0; lCnt2 <= tempForEndVar2; lCnt2++)
									{
										if (rstRec2.GetField(lCnt2).FieldMetadata.ColumnName != "sisef_sise_id")
										{
											rstAdd2[lCnt2] = rstRec2[lCnt2];
										}
										else
										{
											rstAdd2["sisef_sise_id"] = lNewSISEId;
										}
									}

									rstAdd2.UpdateBatch();

									rstRec2.MoveNext();

								}
								while(!rstRec2.EOF);

								UpgradeHelpers.DB.TransactionManager.Commit(cntConn);

							} // If (rstRec2.BOF = False) And (rstRec2.EOF = False) Then

							rstRec2.Close();

							rstRec1.MoveNext();
							Application.DoEvents();

						}
						while(!rstRec1.EOF);

						lNbrSavedExports = lCnt1;

						strEventMsg = $"{lNbrSavedExports.ToString()} Saved Export(s) Copied From {strSubIdOld}-{strLoginOld}-{strSeqNbrOld} To {strSubIdNew}-{strLoginNew}-{strSeqNbrNew}";
						modAdminCommon.Record_Event("Subscription Saved Export(s) Copied", strEventMsg, 0, 0, Convert.ToInt32(Double.Parse(strCompId)));

					} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

					rstAdd2.Close();
					rstRec1.Close();
					rstAdd1.Close();

					modCommon.DelaySeconds(1);

				}
				else
				{
					MessageBox.Show($"SubId, Login, SeqNbr (Old/New){Environment.NewLine}Can NOT Be The Same", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If (strSubIdOld <> strSubIdNew) Or (strLoginOld <> strLoginNew) Or (strSeqNbrOld <> strSeqNbrNew) Then

				rstRec2 = null;
				rstAdd2 = null;

				rstRec1 = null;
				rstAdd1 = null;

				bResults = true;


				return bResults;
			}
			catch (System.Exception excep)
			{

				strStatus = excep.Message;
				modAdminCommon.Report_Error("CopySavedExportsToSubIdLoginSeqNbr_Error: ");
			}
			return false;
		} // CopySavedExportsToSubIdLoginSeqNbr

		private void cmdClose_Click(Object eventSender, EventArgs eventArgs) => this.Hide();


		private void cmdCopyMove_Click(Object eventSender, EventArgs eventArgs)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strCompId = "";

			string strSISSCId = ""; // Saved Projects
			string strCFId = ""; // Client Folders
			string strSISEId = ""; // Saved Exports

			string strSubIdOld = "";
			string strSubIdNew = "";

			string strLoginOld = "";
			string strLoginNew = "";

			string strSeqNbrOld = "";
			string strSeqNbrNew = "";

			string strContact = "";
			int lNbrSavedProjects = 0;
			int lNbrClientFolders = 0;
			int lNbrSavedExports = 0;
			string strStatus = "";

			string strMsg = "";
			string strWhat = "";
			bool bCompleted = false;

			try
			{

				bCompleted = false;

				strCompId = txtCompId.Text;

				strSISSCId = txtSISSCId.Text;
				strCFId = txtCFId.Text;
				strSISEId = txtSISEId.Text;

				strSubIdOld = txtSubIdOld.Text;
				strSubIdNew = txtSubIdNew.Text;

				strLoginOld = txtLoginOld.Text;
				strLoginNew = txtLoginNew.Text;

				strSeqNbrOld = txtSeqNbrOld.Text;
				strSeqNbrNew = txtSeqNbrNew.Text;

				strStatus = "";
				strWhat = "";
				lNbrSavedProjects = 0;
				lNbrClientFolders = 0;
				lNbrSavedExports = 0;

				strMsg = "Are You Sure You Want To ";

				if (optCopy.Checked)
				{
					strMsg = $"{strMsg}Copy ";
				}

				if (optMove.Checked)
				{
					strMsg = $"{strMsg}Move ";
				}

				if (optProjects.Checked)
				{
					strWhat = "Saved Project(s)";
					strMsg = $"{strMsg}{strWhat}";
					if (strSISSCId != "" && strSISSCId != "0")
					{
						strMsg = $"{strMsg}{Environment.NewLine}{Environment.NewLine}SISSCId: {strSISSCId}";
					}
				}

				if (optFolders.Checked)
				{
					strWhat = "Client Folder(s)";
					strMsg = $"{strMsg}{strWhat}";
					if (strCFId != "" && strCFId != "0")
					{
						strMsg = $"{strMsg}{Environment.NewLine}{Environment.NewLine}CFId: {strCFId}";
					}
				}

				if (optSavedExports.Checked)
				{
					strWhat = "Saved Export(s)";
					strMsg = $"{strMsg}{strWhat}";
					if (strSISEId != "" && strSISEId != "0")
					{
						strMsg = $"{strMsg}{Environment.NewLine}{Environment.NewLine}SISEId: {strSISEId}";
					}
				}

				strMsg = $"{strMsg}{Environment.NewLine}{Environment.NewLine}To: {strSubIdNew}-{strLoginNew}-{strSeqNbrNew}";

				if (ValidateSubIdLoginSeqNbr(strSISSCId, strSubIdNew, strLoginNew, strSeqNbrNew, ref strStatus))
				{

					if ((strSubIdOld != strSubIdNew) || (strLoginOld != strLoginNew) || (strSeqNbrOld != strSeqNbrNew))
					{

						if (modSubscription.OpenRemoteDatabase())
						{

							if (DoesSubIdLoginSeqNbrHaveSavedProjectsClientFolders(frm_Subscription.DefInstance.REMOTE_ADO_DB, strSISSCId, strCFId, strSISEId, strSubIdOld, strLoginOld, strSeqNbrOld, ref lNbrSavedProjects, ref lNbrClientFolders, ref lNbrSavedExports))
							{

								if (DoesSubIdLoginSeqNbrInstallExist(frm_Subscription.DefInstance.REMOTE_ADO_DB, strSubIdNew, strLoginNew, strSeqNbrNew, ref strContact))
								{

									if (strContact != "")
									{
										strMsg = $"{strMsg}{Environment.NewLine}{Environment.NewLine}Install: {strContact}";
									}

									strMsg = $"{strMsg}{Environment.NewLine}{Environment.NewLine}User Has ";
									if (optProjects.Checked)
									{
										strMsg = $"{strMsg}{lNbrSavedProjects.ToString()} {strWhat}";
									}
									if (optFolders.Checked)
									{
										strMsg = $"{strMsg}{lNbrClientFolders.ToString()} {strWhat}";
									}
									if (optSavedExports.Checked)
									{
										strMsg = $"{strMsg}{lNbrSavedExports.ToString()} {strWhat}";
									}

									if (MessageBox.Show(strMsg, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
									{

										if (optCopy.Checked)
										{

											if (optProjects.Checked)
											{

												if (!CopySavedProjectsToSubIdLoginSeqNbr(frm_Subscription.DefInstance.REMOTE_ADO_DB, strCompId, ref lNbrSavedProjects, strSISSCId, strSubIdOld, strLoginOld, strSeqNbrOld, strSubIdNew, strLoginNew, strSeqNbrNew, ref strStatus))
												{
													MessageBox.Show($"Copy Failed!{Environment.NewLine}{strStatus}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
												}
												else
												{
													lblStatus.Text = $"Copy {strWhat} Completed";
													MessageBox.Show(lblStatus.Text, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
													bCompleted = true;
												}

											} // If optProjects.Value = True Then

											if (optFolders.Checked)
											{

												if (!CopyClientFoldersToSubIdLoginSeqNbr(frm_Subscription.DefInstance.REMOTE_ADO_DB, strCompId, ref lNbrClientFolders, strCFId, strSubIdOld, strLoginOld, strSeqNbrOld, strSubIdNew, strLoginNew, strSeqNbrNew, ref strStatus))
												{
													MessageBox.Show($"Copy Failed!{Environment.NewLine}{strStatus}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
												}
												else
												{
													lblStatus.Text = $"Copy {strWhat} Completed";
													MessageBox.Show(lblStatus.Text, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
													bCompleted = true;
												}
											} // If optFolders.Value = True Then

											if (optSavedExports.Checked)
											{

												if (!CopySavedExportsToSubIdLoginSeqNbr(frm_Subscription.DefInstance.REMOTE_ADO_DB, strCompId, ref lNbrSavedExports, strSISEId, strSubIdOld, strLoginOld, strSeqNbrOld, strSubIdNew, strLoginNew, strSeqNbrNew, ref strStatus))
												{
													MessageBox.Show($"Copy Failed!{Environment.NewLine}{strStatus}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
												}
												else
												{
													lblStatus.Text = $"Copy {strWhat} Completed";
													MessageBox.Show(lblStatus.Text, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
													bCompleted = true;
												}

											} // If optSavedExports.Value = True Then

										} // If optCopy.Value = True Then

										if (optMove.Checked)
										{

											if (optProjects.Checked)
											{

												if (!MoveSavedProjectsToSubIdLoginSeqNbr(frm_Subscription.DefInstance.REMOTE_ADO_DB, strCompId, ref lNbrSavedProjects, strSISSCId, strSubIdOld, strLoginOld, strSeqNbrOld, strSubIdNew, strLoginNew, strSeqNbrNew, ref strStatus))
												{
													MessageBox.Show($"Move Failed!{Environment.NewLine}{strStatus}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
												}
												else
												{
													lblStatus.Text = $"Moved {strWhat} Completed";
													MessageBox.Show(lblStatus.Text, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
													bCompleted = true;
												}

											} // If optProjects.Value = True Then

											if (optFolders.Checked)
											{

												if (!MoveClientFoldersToSubIdLoginSeqNbr(frm_Subscription.DefInstance.REMOTE_ADO_DB, strCompId, ref lNbrClientFolders, strCFId, strSubIdOld, strLoginOld, strSeqNbrOld, strSubIdNew, strLoginNew, strSeqNbrNew, ref strStatus))
												{
													MessageBox.Show($"Move Failed!{Environment.NewLine}{strStatus}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
												}
												else
												{
													lblStatus.Text = $"Moved {strWhat} Completed";
													MessageBox.Show(lblStatus.Text, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
													bCompleted = true;
												}

											} // If optFolders.Value = True Then

											if (optSavedExports.Checked)
											{

												if (!MoveSavedExportsToSubIdLoginSeqNbr(frm_Subscription.DefInstance.REMOTE_ADO_DB, strCompId, ref lNbrSavedExports, strSISEId, strSubIdOld, strLoginOld, strSeqNbrOld, strSubIdNew, strLoginNew, strSeqNbrNew, ref strStatus))
												{
													MessageBox.Show($"Move Failed!{Environment.NewLine}{strStatus}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
												}
												else
												{
													lblStatus.Text = $"Moved {strWhat} Completed";
													MessageBox.Show(lblStatus.Text, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
													bCompleted = true;
												}

											} // If optSavedExports.Value = True Then

										} // If optMove.Value = True Then

									} // If MsgBox(strMsg, vbYesNo + vbApplicationModal) = vbYes Then

								}
								else
								{
									MessageBox.Show("To SubId, Login, SeqNbr Does NOT Exists!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
								} // If DoesSubIdLoginSeqNbrInstallExist(REMOTE_ADO_DB, strSubIdNew, strLoginNew, strSeqNbrNew, strContact) = True Then

							}
							else
							{
								MessageBox.Show($"From SubId, Login, SeqNbr Does NOT Have Any {strWhat} Records", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							} // If DoesSubIdLoginSeqNbrHaveSavedProjectsClientFolders(frm_Subscription.REMOTE_ADO_DB, strSISSCId, strCFId, strSISEId, strSubIdOld, strLoginOld, strSeqNbrOld, lNbrSavedProjects, lNbrClientFolders, lNbrSavedExports) = True Then

						} // If OpenRemoteDatabase() = True Then

						modSubscription.CloseRemoteDatabase();

					}
					else
					{
						MessageBox.Show("From SubId, Login, SeqNbr Can NOT Be The Same As TO!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					}

				}
				else
				{
					MessageBox.Show($"Validation Failed!{Environment.NewLine}{strStatus}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If ValidateSubIdLoginSeqNbr(strSISSCId, strSubIdNew, strLoginNew, strSeqNbrNew) = True Then

				rstRec1 = null;
			}
			catch
			{

				modAdminCommon.Report_Error("cmdCopyMove_Click_Error: ");
			}

		} // cmdCopyMove_Click

		private void Form_Activated(Object eventSender, EventArgs eventArgs)
		{
			if (ActivateHelper.myActiveForm != eventSender)
			{
				ActivateHelper.myActiveForm = (Form) eventSender;
				this.Refresh();
				txtSubIdNew.Focus();
			}
		}

		private void Form_Initialize()
		{

			modCommon.CenterFormOnHomebaseMainForm(this);

			optCopy.Checked = true;
			optProjects.Checked = true;
			cmdCopyMove.Text = "&Copy";
			lstbCopyMove.Items.Clear();
			UpdateStatusWithOptions();

		} // Form_Initialize

		private void UpdateStatusWithOptions()
		{

			string strType = "";
			string strAction = "";
			string strID = "";
			string strToolTip = "";

			if (optCopy.Checked)
			{
				strAction = "Copy";
			}
			if (optMove.Checked)
			{
				strAction = "Move";
			}

			if (optProjects.Checked)
			{
				strType = "Saved Project(s)";
			}
			if (optFolders.Checked)
			{
				strType = "Client Folder(s)";
			}
			if (optSavedExports.Checked)
			{
				strType = "Saved Export(s)";
			}

			this.Text = $"Copy/Move {strType}";

			string strMsg = $"This Will {strAction} {strType}";

			lblStatus.Text = strMsg;

		} // UpdateStatusWithOptions

		private bool isInitializingComponent;
		private void optFolders_CheckedChanged(Object eventSender, EventArgs eventArgs)
		{
			if (((RadioButton) eventSender).Checked)
			{
				if (isInitializingComponent)
				{
					return;
				}

				UpdateStatusWithOptions();

			}
		} // optFolders_Click

		private void optProjects_CheckedChanged(Object eventSender, EventArgs eventArgs)
		{
			if (((RadioButton) eventSender).Checked)
			{
				if (isInitializingComponent)
				{
					return;
				}

				UpdateStatusWithOptions();

			}
		} // optProjects_Click

		private void optSavedExports_CheckedChanged(Object eventSender, EventArgs eventArgs)
		{
			if (((RadioButton) eventSender).Checked)
			{
				if (isInitializingComponent)
				{
					return;
				}

				UpdateStatusWithOptions();

			}
		} // optSavedExports_Click

		private void optCopy_CheckedChanged(Object eventSender, EventArgs eventArgs)
		{
			if (((RadioButton) eventSender).Checked)
			{
				if (isInitializingComponent)
				{
					return;
				}
				frmFrom.Text = "Copy From";
				cmdCopyMove.Text = "&Copy";
				UpdateStatusWithOptions();
			}
		}

		private void optMove_CheckedChanged(Object eventSender, EventArgs eventArgs)
		{
			if (((RadioButton) eventSender).Checked)
			{
				if (isInitializingComponent)
				{
					return;
				}
				frmFrom.Text = "Move From";
				cmdCopyMove.Text = "&Move";
				UpdateStatusWithOptions();
			}
		}
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}