using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Helpers;
using UpgradeStubs;

namespace JETNET_Homebase
{
	internal partial class frm_EventsList
		: System.Windows.Forms.Form
	{

		public frm_EventsList()
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


		private void frm_EventsList_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}

		public int gblACID = 0; //If this is greater than zero, we list all events for this aircraft
		public int gblYacht_ID = 0;

		public int gblCOMPID = 0;

		private bool GridEditOutstanding = false;
		private int LastRow = 0;
		private int LastCol = 0;

		private string GridChanges = "";

		private void ClearEventsGrid()
		{

			try
			{


				grdEvents.Clear();

				//Set the total number of rows/cols and the number of fixed rows/cols
				grdEvents.RowsCount = 2;
				grdEvents.ColumnsCount = 7;
				grdEvents.FixedRows = 1;
				grdEvents.FixedColumns = 0;

				//Fill in the Headers and set their width's
				grdEvents.CurrentRowIndex = 0;

				grdEvents.CurrentColumnIndex = 0;
				grdEvents[grdEvents.CurrentRowIndex, grdEvents.CurrentColumnIndex].Value = "Entry Date/Time";
				grdEvents.SetColumnWidth(grdEvents.CurrentColumnIndex, 133);
				
				grdEvents.ColAlignment[0] = DataGridViewContentAlignment.TopLeft;

				if (gblYacht_ID > 0)
				{
					grdEvents.CurrentColumnIndex = 1;
					grdEvents[grdEvents.CurrentRowIndex, grdEvents.CurrentColumnIndex].Value = "Yacht";
					grdEvents.SetColumnWidth(grdEvents.CurrentColumnIndex, 167);
				}
				else
				{
					grdEvents.CurrentColumnIndex = 1;
					grdEvents[grdEvents.CurrentRowIndex, grdEvents.CurrentColumnIndex].Value = "Aircraft";
					grdEvents.SetColumnWidth(grdEvents.CurrentColumnIndex, 133);
				}

				grdEvents.CurrentColumnIndex = 2;
				grdEvents[grdEvents.CurrentRowIndex, grdEvents.CurrentColumnIndex].Value = "Company";
				grdEvents.SetColumnWidth(grdEvents.CurrentColumnIndex, 187);

				grdEvents.CurrentColumnIndex = 3;
				grdEvents[grdEvents.CurrentRowIndex, grdEvents.CurrentColumnIndex].Value = "Contact";
				grdEvents.SetColumnWidth(grdEvents.CurrentColumnIndex, 113);

				grdEvents.CurrentColumnIndex = 4;
				grdEvents[grdEvents.CurrentRowIndex, grdEvents.CurrentColumnIndex].Value = "Event Description";
				grdEvents.SetColumnWidth(grdEvents.CurrentColumnIndex, 267);

				grdEvents.CurrentColumnIndex = 5;
				grdEvents[grdEvents.CurrentRowIndex, grdEvents.CurrentColumnIndex].Value = "User";
				grdEvents.SetColumnWidth(grdEvents.CurrentColumnIndex, 43);

				grdEvents.CurrentColumnIndex = 6;
				grdEvents[grdEvents.CurrentRowIndex, grdEvents.CurrentColumnIndex].Value = "Hide";
				grdEvents.SetColumnWidth(grdEvents.CurrentColumnIndex, 33);
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"ClearEventsGrid_Error: {excep.Message}");
			}



		}

		private void FillEventsGrid()
		{


			try
			{

				string Query = "";
				ADORecordSetHelper snpEvents = new ADORecordSetHelper();

				ClearEventsGrid();

				if (gblACID > 0 || gblCOMPID > 0)
				{

					this.Cursor = Cursors.WaitCursor;

					Query = "SELECT priorev_id, priorev_subject, priorev_description, priorev_ac_id, priorev_journ_id, priorev_comp_id, priorev_contact_id, priorev_user_id, priorev_entry_date, priorev_hide_flag ";
					Query = $"{Query}FROM Priority_Events WITH(NOLOCK) ";


					if (gblCOMPID > 0 && gblACID == 0)
					{
						Query = $"{Query}WHERE priorev_comp_id = {gblCOMPID.ToString()}  "; //  priorev_ac_id = 0 and
					}
					else
					{
						Query = $"{Query}WHERE priorev_ac_id = {gblACID.ToString()} ";
					}

					Query = $"{Query}ORDER BY priorev_entry_date DESC ";

					snpEvents.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if ((!snpEvents.BOF) && (!snpEvents.EOF))
					{

						//Start at row 1
						grdEvents.CurrentRowIndex = 1;

						do 
						{ // Loop Until snpEvents.EOF = True


							grdEvents.CurrentColumnIndex = 0;
							grdEvents[grdEvents.CurrentRowIndex, grdEvents.CurrentColumnIndex].Value = DateTime.Parse(($"{Convert.ToString(snpEvents["priorev_entry_date"])}").Trim()).ToString();

							grdEvents.CurrentColumnIndex = 1;
							grdEvents[grdEvents.CurrentRowIndex, grdEvents.CurrentColumnIndex].Value = modCommon.GetAircraftName(Convert.ToInt32(snpEvents["priorev_ac_id"]), 0);

							grdEvents.CurrentColumnIndex = 2;
							grdEvents[grdEvents.CurrentRowIndex, grdEvents.CurrentColumnIndex].Value = modCommon.GetCompanyName(Convert.ToInt32(snpEvents["priorev_comp_id"]), 0);

							grdEvents.CurrentColumnIndex = 3;
							grdEvents[grdEvents.CurrentRowIndex, grdEvents.CurrentColumnIndex].Value = modCommon.GetContactName(Convert.ToInt32(snpEvents["priorev_contact_id"]), 0);

							grdEvents.CurrentColumnIndex = 4;
							grdEvents[grdEvents.CurrentRowIndex, grdEvents.CurrentColumnIndex].Value = $"{($"{Convert.ToString(snpEvents["priorev_subject"])}").Trim()} - {($"{Convert.ToString(snpEvents["priorev_description"])}").Trim()}";

							grdEvents.CurrentColumnIndex = 5;
							grdEvents[grdEvents.CurrentRowIndex, grdEvents.CurrentColumnIndex].Value = ($"{Convert.ToString(snpEvents["priorev_user_id"])}").Trim();

							grdEvents.CurrentColumnIndex = 6;
							grdEvents[grdEvents.CurrentRowIndex, grdEvents.CurrentColumnIndex].Value = (($"{Convert.ToString(snpEvents["priorev_hide_flag"])}").Trim() == "N") ? "No" : "Yes";

							grdEvents.set_RowData(grdEvents.CurrentRowIndex, Convert.ToInt32(snpEvents["priorev_id"].ToString().Trim()));

							snpEvents.MoveNext();

							//Add a row
							grdEvents.RowsCount++;
							grdEvents.CurrentRowIndex++;
							 // grdEvents

						}
						while(!snpEvents.EOF);

						//Remove the extra row at the bottom
						grdEvents.RowsCount--;

					}
					else
					{
						grdEvents.CurrentRowIndex = 1;
						grdEvents.CurrentColumnIndex = 0;

						grdEvents[grdEvents.CurrentRowIndex, grdEvents.CurrentColumnIndex].Value = "No Events Found";
					} // If (snpEvents.BOF = False) And (snpEvents.EOF = False) Then

					snpEvents.Close();
					snpEvents = null;

					GridChanges = "";

				}

				this.Cursor = CursorHelper.CursorDefault;
			}
			catch (System.Exception excep)
			{

				this.Cursor = CursorHelper.CursorDefault;
				modAdminCommon.Report_Error($"FillEventsGrid_Error: {excep.Message}");
			}

		}
		private void FillEventsGrid_Yacht()
		{



			try
			{

				string Query = "";
				ADORecordSetHelper snpEvents = new ADORecordSetHelper();

				//Initialize the grid before we start
				ClearEventsGrid();

				if (gblYacht_ID > 0)
				{


					this.Cursor = Cursors.WaitCursor;

					Query = "SELECT * FROM Yacht_Priority_Events WITH(NOLOCK) ";
					Query = $"{Query}WHERE ype_yt_id = {gblYacht_ID.ToString()} ORDER BY ype_entered_date DESC ";

					snpEvents.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if ((!snpEvents.BOF) && (!snpEvents.EOF))
					{

						//Start at row 1
						grdEvents.CurrentRowIndex = 1;

						do 
						{ // Loop Until snpEvents.EOF = True


							grdEvents.CurrentColumnIndex = 0;
							grdEvents[grdEvents.CurrentRowIndex, grdEvents.CurrentColumnIndex].Value = DateTime.Parse(($"{Convert.ToString(snpEvents["ype_entered_date"])}").Trim()).ToString();

							grdEvents.CurrentColumnIndex = 1;
							grdEvents[grdEvents.CurrentRowIndex, grdEvents.CurrentColumnIndex].Value = modCommon.GetYachtName(Convert.ToInt32(snpEvents["ype_yt_id"]), 0);

							grdEvents.CurrentColumnIndex = 2;
							grdEvents[grdEvents.CurrentRowIndex, grdEvents.CurrentColumnIndex].Value = modCommon.GetCompanyName(Convert.ToInt32(snpEvents["ype_comp_id"]), 0);

							grdEvents.CurrentColumnIndex = 3;
							grdEvents[grdEvents.CurrentRowIndex, grdEvents.CurrentColumnIndex].Value = modCommon.GetContactName(Convert.ToInt32(snpEvents["ype_contact_id"]), 0);

							grdEvents.CurrentColumnIndex = 4;
							grdEvents[grdEvents.CurrentRowIndex, grdEvents.CurrentColumnIndex].Value = $"{($"{Convert.ToString(snpEvents["ype_subject"])}").Trim()} - {($"{Convert.ToString(snpEvents["ype_description"])}").Trim()}";

							grdEvents.CurrentColumnIndex = 5;
							grdEvents[grdEvents.CurrentRowIndex, grdEvents.CurrentColumnIndex].Value = ($"{Convert.ToString(snpEvents["ype_user_id"])}").Trim();

							grdEvents.CurrentColumnIndex = 6;
							grdEvents[grdEvents.CurrentRowIndex, grdEvents.CurrentColumnIndex].Value = (($"{Convert.ToString(snpEvents["ype_hide_flag"])}").Trim() == "N") ? "No" : "Yes";

							grdEvents.set_RowData(grdEvents.CurrentRowIndex, Convert.ToInt32(snpEvents["ype_id"].ToString().Trim()));

							snpEvents.MoveNext();

							//Add a row
							grdEvents.RowsCount++;
							grdEvents.CurrentRowIndex++;
							 // grdEvents

						}
						while(!snpEvents.EOF);

						//Remove the extra row at the bottom
						grdEvents.RowsCount--;

					}
					else
					{
						grdEvents.CurrentRowIndex = 1;
						grdEvents.CurrentColumnIndex = 0;

						grdEvents[grdEvents.CurrentRowIndex, grdEvents.CurrentColumnIndex].Value = "No Events Found";
					} // If (snpEvents.BOF = False) And (snpEvents.EOF = False) Then

					snpEvents.Close();
					snpEvents = null;


					GridChanges = "";

				}

				this.Cursor = CursorHelper.CursorDefault;
			}
			catch (System.Exception excep)
			{

				this.Cursor = CursorHelper.CursorDefault;
				modAdminCommon.Report_Error($"FillEventsGrid_Yacht_Error: {excep.Message}");
			}

		}


		private void SaveEventsFromGrid()
		{

			string Query = "";
			string[] arrChanges = null;
			ADORecordSetHelper snpChanges = new ADORecordSetHelper();
			StringBuilder strInsert1 = new StringBuilder();
			string strJSubject = "";
			string strDesc = "";

			try
			{

				if (Strings.Len(GridChanges) > 0)
				{

					modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Updating Events...", Color.Blue);
					this.Cursor = Cursors.WaitCursor;

					GridChanges = GridChanges.Substring(0, Math.Min(Strings.Len(GridChanges) - 1, GridChanges.Length));

					arrChanges = GridChanges.Split(',');

					foreach (string arrChanges_item in arrChanges)
					{

						grdEvents.CurrentRowIndex = Convert.ToInt32(Double.Parse(arrChanges_item));
						grdEvents.CurrentColumnIndex = 6;

						Query = $"SELECT * FROM Priority_Events WHERE priorev_id = {grdEvents.get_RowData(Convert.ToInt32(Double.Parse(arrChanges_item))).ToString()}";

						snpChanges.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

						if (!(snpChanges.BOF && snpChanges.EOF))
						{
							snpChanges.MoveFirst();

							snpChanges["priorev_hide_flag"] = grdEvents[grdEvents.CurrentRowIndex, grdEvents.CurrentColumnIndex].FormattedValue.ToString().Substring(Math.Min(0, grdEvents[grdEvents.CurrentRowIndex, grdEvents.CurrentColumnIndex].FormattedValue.ToString().Length), Math.Min(1, Math.Max(0, grdEvents[grdEvents.CurrentRowIndex, grdEvents.CurrentColumnIndex].FormattedValue.ToString().Length))).ToUpper();
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							snpChanges["priorev_action_date"] = DBNull.Value;

							strJSubject = $"[{Convert.ToString(snpChanges["priorev_subject"])}] Priority Event Hidden";
							if (Convert.ToString(snpChanges["priorev_hide_flag"]).Trim() == "Y")
							{
								strDesc = $"Priority Event: {grdEvents.get_RowData(Convert.ToInt32(Double.Parse(arrChanges_item))).ToString()}, Hidden";
							}
							else if (Convert.ToString(snpChanges["priorev_hide_flag"]).Trim() == "N")
							{ 
								strDesc = $"Priority Event: {grdEvents.get_RowData(Convert.ToInt32(Double.Parse(arrChanges_item))).ToString()}, Un-Hidden";
							}

							strDesc = $"{strDesc} [{Convert.ToString(snpChanges["priorev_subject"])}], ";
							strDesc = $"{strDesc} [{Convert.ToString(snpChanges["priorev_description"])}] ";


							strInsert1 = new StringBuilder("INSERT INTO Journal (journ_date, ");
							strInsert1.Append("journ_entry_date,journ_subcategory_code, ");
							strInsert1.Append("journ_subject, journ_description, ");
							strInsert1.Append("journ_comp_id, journ_ac_id, ");
							strInsert1.Append("journ_user_id, journ_status, ");
							strInsert1.Append("journ_action_date )  VALUES (");

							strInsert1.Append($"'{DateTimeHelper.ToString(DateTime.Now)}', "); // Journal Date
							strInsert1.Append($"'{DateTimeHelper.ToString(DateTime.Now)}', "); // Entry Date
							strInsert1.Append("'HDPE', ");
							strInsert1.Append($"'{StringsHelper.Replace(strJSubject, "'", "''", 1, -1, CompareMethod.Binary)}', ");
							strInsert1.Append($"'{StringsHelper.Replace(strDesc, "'", "''", 1, -1, CompareMethod.Binary)}', ");
							strInsert1.Append($"{gblCOMPID.ToString()}, ");
							strInsert1.Append($"{gblACID.ToString()}, ");
							strInsert1.Append($"'{modAdminCommon.gbl_User_ID}', ");
							strInsert1.Append("'A', ");
							strInsert1.Append("NULL");
							strInsert1.Append(")");

							DbCommand TempCommand = null;
							TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
							TempCommand.CommandText = strInsert1.ToString();
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
							TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
							TempCommand.ExecuteNonQuery();

							snpChanges.Update();

						}
						snpChanges.Close();

					}

					modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
					this.Cursor = CursorHelper.CursorDefault;

				} // If Len(GridChanges) > 0 Then

				// Moved this outside of loop.  Only need to create and destory this variable once.
				snpChanges = null;
				GridChanges = "";
			}
			catch (System.Exception excep)
			{


				modAdminCommon.Report_Error($"SaveEventsFromGrid_Error: {excep.Message}");
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
				this.Cursor = CursorHelper.CursorDefault;
			}

		}

		private void SaveEventsFromGrid_Yacht()
		{

			string Query = "";
			string[] arrChanges = null;
			ADORecordSetHelper snpChanges = new ADORecordSetHelper();

			try
			{

				if (Strings.Len(GridChanges) > 0)
				{

					modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Updating Events...", Color.Blue);
					this.Cursor = Cursors.WaitCursor;

					GridChanges = GridChanges.Substring(0, Math.Min(Strings.Len(GridChanges) - 1, GridChanges.Length));

					arrChanges = GridChanges.Split(',');

					foreach (string arrChanges_item in arrChanges)
					{

						grdEvents.CurrentRowIndex = Convert.ToInt32(Double.Parse(arrChanges_item));
						grdEvents.CurrentColumnIndex = 6;

						Query = $"SELECT * FROM Yacht_Priority_Events WHERE ype_id = {grdEvents.get_RowData(Convert.ToInt32(Double.Parse(arrChanges_item))).ToString()}";

						snpChanges.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

						if (!(snpChanges.BOF && snpChanges.EOF))
						{
							snpChanges.MoveFirst();

							snpChanges["ype_hide_flag"] = grdEvents[grdEvents.CurrentRowIndex, grdEvents.CurrentColumnIndex].FormattedValue.ToString().Substring(Math.Min(0, grdEvents[grdEvents.CurrentRowIndex, grdEvents.CurrentColumnIndex].FormattedValue.ToString().Length), Math.Min(1, Math.Max(0, grdEvents[grdEvents.CurrentRowIndex, grdEvents.CurrentColumnIndex].FormattedValue.ToString().Length))).ToUpper();
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							snpChanges["ype_action_date"] = DBNull.Value;

							snpChanges.Update();

						}
						snpChanges.Close();

					}

					modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
					this.Cursor = CursorHelper.CursorDefault;

				} // If Len(GridChanges) > 0 Then

				snpChanges = null;
				GridChanges = "";
			}
			catch (System.Exception excep)
			{


				modAdminCommon.Report_Error($"SaveEventsFromGrid_Error: {excep.Message}");
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
				this.Cursor = CursorHelper.CursorDefault;
			}

		}


		private void cmdClose_Click(Object eventSender, EventArgs eventArgs) => mnuClose_Click(mnuClose, new EventArgs());


		private void cmdSave_Click(Object eventSender, EventArgs eventArgs)
		{

			if (GridEditOutstanding)
			{
				modGridEditCommon.InPlace_Grid_Reset(grdEvents, chkEdit, LastRow, LastCol);
			}

			if (gblYacht_ID > 0)
			{
				SaveEventsFromGrid_Yacht();
			}
			else
			{
				SaveEventsFromGrid();
			}



		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
		private void Form_Load()
		{

			//Call CenterForm32(Me)
			modCommon.CenterFormOnHomebaseMainForm(this);


			if (gblYacht_ID > 0)
			{
				FillEventsGrid_Yacht();
			}
			else
			{
				FillEventsGrid();
			}

			chkEdit.Enabled = Convert.ToString(modAdminCommon.snp_User["user_hide_events_flag"]) == "Y";

			//UPGRADE_WARNING: (2065) Form method frm_EventsList.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
			this.BringToFront();

		}

		private void grdEvents_Click(Object eventSender, EventArgs eventArgs)
		{

			if (GridEditOutstanding)
			{
				modGridEditCommon.InPlace_Grid_Reset(grdEvents, chkEdit, LastRow, LastCol);
				modCommon.Highlight_Grid_Row(grdEvents);
				GridEditOutstanding = false; // Added this in - 6/4/15
			}

		}

		private void grdEvents_DoubleClick(Object eventSender, EventArgs eventArgs)
		{


			int lRow = grdEvents.CurrentRowIndex;
			int lCol = grdEvents.MouseCol;

			if (lCol == 6 && lRow > 0)
			{

				grdEvents.CurrentColumnIndex = lCol;

				if (Convert.ToString(modAdminCommon.snp_User["user_hide_events_flag"]) == "Y")
				{

					LastRow = grdEvents.CurrentRowIndex;
					LastCol = grdEvents.CurrentColumnIndex;

					GridChanges = $"{GridChanges}{lRow.ToString()},";

					modGridEditCommon.InPlace_Grid_Edit(grdEvents, chkEdit, false, true, null, grdEvents.Left * 15, grdEvents.Top * 15, chkEdit.Width * 15);

					GridEditOutstanding = true;

				} // If snp_User!user_hide_events_flag = "Y" Then

			} // If lCol = 6 And lRow > 0 Then

		}

		public void mnuClose_Click(Object eventSender, EventArgs eventArgs)
		{

			if (Strings.Len(GridChanges) > 0)
			{
				if (MessageBox.Show("Do you want to save your changes", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
				{
					cmdSave_Click(cmdSave, new EventArgs());
				}
			}

			this.Close();

		}

		public void mnuLogout_Click(Object eventSender, EventArgs eventArgs)
		{

			this.Close();
			Environment.Exit(0);

		}
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}