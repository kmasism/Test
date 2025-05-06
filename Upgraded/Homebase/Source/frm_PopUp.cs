using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Gui.Controls;
using UpgradeHelpers.Helpers;
using UpgradeStubs;

namespace JETNET_Homebase
{
	internal partial class frm_PopUp
		: System.Windows.Forms.Form
	{

		public frm_PopUp()
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


		private void frm_PopUp_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}


		public int PassedACID = 0;
		public int PassedJournID = 0;
		public int PassedCompID = 0;
		public int PassedContID = 0;
		public string PassedContType = "";
		public bool EndUser = false;
		public string PassedCountry = "";
		public string PassedState = "";

		private string dtFractionalExpireDate = "";
		private string dtCallbackDate = "";
		private string strComingFrom = "";

		bool Stopped = false;


		public string CallbackDate
		{
			get => dtCallbackDate;
			set => dtCallbackDate = value;
		}



		public string ComingFrom
		{
			get => strComingFrom;
			set => strComingFrom = value;
		}



		public string FractionalExpireDate
		{
			get => dtFractionalExpireDate;
			set => dtFractionalExpireDate = value;
		}


		private void CenterLabel()
		{


			int iTop = (frm_PopUp.DefInstance.Height * 15 - lblExclusiveBroker.Height * 15) / 2;
			int iLeft = (frm_PopUp.DefInstance.Width * 15 - lblExclusiveBroker.Width * 15) / 2;

			lblExclusiveBroker.SetBounds(iLeft / 15, iTop / 15, 0, 0, BoundsSpecified.X | BoundsSpecified.Y);

		}

		private void cmdAwaitingDocsCancel_Click(Object eventSender, EventArgs eventArgs) => this.Close();


		private void cmdAwaitingDocsSave_Click(Object eventSender, EventArgs eventArgs)
		{


			this.Cursor = Cursors.WaitCursor;

			string Query = $"UPDATE Company SET comp_country = '{cboCountry.Text.Trim()}',";
			Query = $"{Query} comp_state = '{cboState.Text.Substring(Math.Min(0, cboState.Text.Length), Math.Min(cboState.Text.IndexOf(", "), Math.Max(0, cboState.Text.Length)))}',";
			Query = $"{Query} comp_action_date = NULL";
			Query = $"{Query} WHERE comp_id = {PassedCompID.ToString()} AND comp_journ_id = {PassedJournID.ToString()}";

			DbCommand TempCommand = null;
			TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
			UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
			TempCommand.CommandText = Query;
			//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
			TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
			UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
			TempCommand.ExecuteNonQuery();

			this.Cursor = CursorHelper.CursorDefault;

			this.Close();

		}

		private void cmdCancel_Click(Object eventSender, EventArgs eventArgs)
		{

			dtCallbackDate = "CANCEL";

			this.Close();

		}

		private void cmdClose_Click(Object eventSender, EventArgs eventArgs) => this.Close();


		private void cmdExclusiveBrokerNo_Click(Object eventSender, EventArgs eventArgs)
		{

			dtCallbackDate = "";
			this.Close();

		}

		private void cmdExclusiveBrokerYes_Click(Object eventSender, EventArgs eventArgs)
		{

			if (strComingFrom == "Fractional Expire Date")
			{

				if (txtExclusiveCallbackDate.Text.Trim() == "")
				{
					dtFractionalExpireDate = "Null";

				}
				else
				{

					if (!modCommon.pf_ValidateDate(txtExclusiveCallbackDate.Text, false))
					{
						MessageBox.Show("Fractional Expiration Date must be a Date", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						txtExclusiveCallbackDate.Focus();
						return;
					}

					dtFractionalExpireDate = DateTime.Parse(txtExclusiveCallbackDate.Text).ToString("d");

				}

			}
			else if (strComingFrom == "Company Name Change")
			{ 

				if (txtExclusiveCallbackDate.Text == "")
				{
					MessageBox.Show("Date As Of Cannot be blank.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					txtExclusiveCallbackDate.Focus();
					return;
				}

				if (!modCommon.pf_ValidateDate(txtExclusiveCallbackDate.Text, true))
				{
					MessageBox.Show("Date As Of Must be a Date", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					txtExclusiveCallbackDate.Focus();
					return;
				}

				dtCallbackDate = DateTime.Parse(txtExclusiveCallbackDate.Text).ToString("d");

			}
			else if (strComingFrom == "99" || strComingFrom == "93")
			{ 

				if (txtExclusiveCallbackDate.Text == "")
				{
					MessageBox.Show("Exclusive Callback Date Cannot be blank.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					txtExclusiveCallbackDate.Focus();
					return;
				}


				if (!modCommon.pf_ValidateDate(txtExclusiveCallbackDate.Text, false))
				{
					MessageBox.Show("Exclusive Callback Date Must be a Date", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					txtExclusiveCallbackDate.Focus();
					return;
				}

				dtCallbackDate = DateTime.Parse(txtExclusiveCallbackDate.Text).ToString("d");

			}

			this.Close();

		}

		private void cmdFind_Click(Object eventSender, EventArgs eventArgs)
		{

			string Query = "";
			bool SomethingSelected = false;
			ADORecordSetHelper snp_Search = new ADORecordSetHelper();
			int RecCount = 0;
			int CurRow = 0;
			string errMsg = "";

			try
			{

				errMsg = "init";
				SomethingSelected = false;
				RecCount = 0;
				this.Cursor = Cursors.WaitCursor;
				grdSearch.Visible = false;
				Lbl_notfound.Visible = false;
				lbl_count.Text = "";
				lbl_count.Visible = false;

				Query = "Select top 100 ac_id,amod_make_name,amod_model_name, ac_ser_no_full,ac_reg_no   FROM Aircraft WITH(NOLOCK), Aircraft_Model ";
				Query = $"{Query} WHERE amod_id = ac_amod_id AND ac_journ_id = 0 ";

				if (txt_make.Text.Trim() != "")
				{
					Query = $"{Query} and (amod_make_name like '{StringsHelper.Replace(txt_make.Text.Trim(), "*", "%", 1, -1, CompareMethod.Binary)}%' or amod_make_abbrev like '{StringsHelper.Replace(($"{txt_make.Text}").Trim(), "*", "%", 1, -1, CompareMethod.Binary)}%' ) ";
					SomethingSelected = true;
				}

				if (txt_SerialNo.Text.Trim() != "")
				{
					Query = $"{Query} and (( ac_ser_no_full like '{StringsHelper.Replace(txt_SerialNo.Text.Trim(), "*", "%", 1, -1, CompareMethod.Binary)}%' or ac_alt_ser_no_full like '{StringsHelper.Replace(txt_SerialNo.Text.Trim(), "*", "%", 1, -1, CompareMethod.Binary)}%' ) ";
					Query = $"{Query} or ( ac_ser_no_full like '%{StringsHelper.Replace(txt_SerialNo.Text.Trim(), "*", "%", 1, -1, CompareMethod.Binary)}' or ac_alt_ser_no_full like '%{StringsHelper.Replace(txt_SerialNo.Text.Trim(), "*", "%", 1, -1, CompareMethod.Binary)}' )) ";
					SomethingSelected = true;
				}

				if (txt_RegNo.Text.Trim() != "")
				{
					Query = $"{Query} and ((ac_reg_no LIKE '{StringsHelper.Replace(txt_RegNo.Text.Trim(), "*", "%", 1, -1, CompareMethod.Binary)}%' OR ac_prev_reg_no LIKE '{StringsHelper.Replace(txt_RegNo.Text.Trim(), "*", "%", 1, -1, CompareMethod.Binary)}%') ";
					Query = $"{Query} or (ac_reg_no LIKE '%{StringsHelper.Replace(txt_RegNo.Text.Trim(), "*", "%", 1, -1, CompareMethod.Binary)}' OR ac_prev_reg_no LIKE '%{StringsHelper.Replace(txt_RegNo.Text.Trim(), "*", "%", 1, -1, CompareMethod.Binary)}')) ";
					SomethingSelected = true;
				}

				if (txt_id_box.Text.Trim() != "")
				{
					Query = $"{Query} and ac_id = {txt_id_box.Text.Trim()}";
					SomethingSelected = true;
				}

				Query = $"{Query} Order by amod_make_name,amod_model_name, ac_ser_no_full, ac_reg_no  ";

				if (SomethingSelected)
				{



					snp_Search.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					// Set snp_Search = Adodc1.Recordset.Clone
					if (!(snp_Search.EOF && snp_Search.BOF))
					{

						grdSearch.Visible = true;
						grdSearch.Clear();
						grdSearch.ColumnsCount = 5;

						grdSearch.CurrentRowIndex = 0;
						grdSearch.CurrentColumnIndex = 1;
						grdSearch[grdSearch.CurrentRowIndex, grdSearch.CurrentColumnIndex].Value = "Make";
						grdSearch.CurrentColumnIndex = 2;
						grdSearch[grdSearch.CurrentRowIndex, grdSearch.CurrentColumnIndex].Value = "Model";
						grdSearch.CurrentColumnIndex = 3;
						grdSearch[grdSearch.CurrentRowIndex, grdSearch.CurrentColumnIndex].Value = "Serial";
						grdSearch.CurrentColumnIndex = 4;
						grdSearch[grdSearch.CurrentRowIndex, grdSearch.CurrentColumnIndex].Value = "Reg No";
						grdSearch.SetColumnWidth(0, 0);
						grdSearch.SetColumnWidth(1, 80);
						grdSearch.SetColumnWidth(2, 80);
						grdSearch.SetColumnWidth(3, 80);
						grdSearch.SetColumnWidth(4, 80);

						snp_Search.MoveFirst();
						grdSearch.RowsCount = snp_Search.RecordCount + 1;
						grdSearch.CurrentRowIndex = 0;

						do 
						{ // Loop Until snp_Search.EOF = True

							grdSearch.CurrentRowIndex++;

							grdSearch.CurrentColumnIndex = 0;
							
							grdSearch.ColAlignment[0] = DataGridViewContentAlignment.TopLeft;
							grdSearch[grdSearch.CurrentRowIndex, grdSearch.CurrentColumnIndex].Value = Convert.ToString(snp_Search["AC_ID"]);

							grdSearch.CurrentColumnIndex = 1;
							
							grdSearch.ColAlignment[1] = DataGridViewContentAlignment.TopLeft;
							grdSearch[grdSearch.CurrentRowIndex, grdSearch.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_Search["amod_make_name"])} ").Trim();

							grdSearch.CurrentColumnIndex = 2;
							
							grdSearch.ColAlignment[2] = DataGridViewContentAlignment.TopLeft;
							grdSearch[grdSearch.CurrentRowIndex, grdSearch.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_Search["amod_model_name"])} ").Trim();

							grdSearch.CurrentColumnIndex = 3;
							
							grdSearch.ColAlignment[3] = DataGridViewContentAlignment.TopLeft;
							grdSearch[grdSearch.CurrentRowIndex, grdSearch.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_Search["ac_ser_no_full"])} ").Trim();

							grdSearch.CurrentColumnIndex = 4;
							
							grdSearch.ColAlignment[4] = DataGridViewContentAlignment.TopLeft;
							grdSearch[grdSearch.CurrentRowIndex, grdSearch.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_Search["ac_reg_no"])} ").Trim();

							snp_Search.MoveNext();

						}
						while(!snp_Search.EOF);

						RecCount = snp_Search.RecordCount;
						if (RecCount == 1)
						{
							grdSearch.CurrentRowIndex = 1;
							errMsg = "grid";
							Application.DoEvents();
							Application.DoEvents();
							Application.DoEvents();
							grdSearch_DoubleClick(grdSearch, new EventArgs());
							Application.DoEvents();
							Application.DoEvents();
							Application.DoEvents();
						}
						lbl_count.Text = $"{RecCount.ToString()} Records";
						lbl_count.Visible = true;

					}
					else
					{
						//no recs
						Lbl_notfound.Visible = true;
					} // If Not (snp_Search.EOF And snp_Search.BOF) Then

					snp_Search.Close();

				}
				else
				{
					Lbl_notfound.Visible = true;
				} //something selected

				snp_Search = null;
				this.Cursor = CursorHelper.CursorDefault;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"QuickACSearch_Error: {excep.Message} {errMsg}");
				this.Cursor = CursorHelper.CursorDefault;
				snp_Search = null;
			}

		}

		private void CmdSelect_Click(Object eventSender, EventArgs eventArgs) => grdSearch_DoubleClick(grdSearch, new EventArgs());


		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
		private void Form_Load()
		{

			string tmpCaption = "";

			modCommon.CenterFormOnHomebaseMainForm(this);

			Stopped = false;
			pnlAircraftSearch.Visible = false;
			pnlAircraftSearch.Enabled = false;


			switch(strComingFrom)
			{
				case "Awaiting Docs" : 
					 
					this.Text = "Awaiting Documention Info"; 
					 
					pnlAddExclusiveBroker.Visible = false; 
					pnlAwaitingDocs.Visible = true; 
					 
					modFillCompConControls.fill_country_FromArray(cboCountry); 
					modFillCompConControls.fill_state_FromArray(cboState, false, false, false); 
					 
					if (PassedCountry.Trim() != "")
					{
						cboCountry.Text = PassedCountry.Trim();
					} 
					 
					if (PassedState.Trim() != "")
					{
						int tempForEndVar = cboState.Items.Count - 1;
						for (int i = 0; i <= tempForEndVar; i++)
						{
							if (cboState.GetListItem(i).Trim().Substring(0, Math.Min(cboState.GetListItem(i).IndexOf(", "), cboState.GetListItem(i).Trim().Length)).ToUpper() == PassedState.Trim().Substring(0, Math.Min(PassedState.IndexOf(", "), PassedState.Trim().Length)).ToUpper())
							{
								cboState.SelectedIndex = i;
								break;
							}
						}
						if (cboState.SelectedIndex == 0)
						{
							cboState.Text = PassedState.Trim();
						}
					} 
					 
					break;
				case "99" : case "93" : 
					 
					this.Text = $"Assign {((strComingFrom == "99") ? "Exclusive Broker" : "Exclusive Representative")}"; 
					 
					pnlAwaitingDocs.Visible = false; 
					pnlAddExclusiveBroker.Visible = true; 
					lblExclusiveCallbackDate.Text = "Exclusive Callback Date"; 
					 
					if (strComingFrom == "99")
					{ // Exclusive Broker
						txtExclusiveCallbackDate.Text = DateTimeHelper.ToString(DateTime.Parse(modAdminCommon.GetDateTime()).AddDays(Convert.ToDouble(modAdminCommon.gbl_ColorConfirmDays)));
					}
					else
					{
						// Exclusive Representative
						txtExclusiveCallbackDate.Text = DateTime.Parse(modAdminCommon.DateToday).ToString("d");
					} 
					 
					dtCallbackDate = DateTime.Parse(txtExclusiveCallbackDate.Text).ToString("d"); 
					 
					tmpCaption = $"You are about to associate an {"\""}{((strComingFrom == "99") ? "Exclusive Broker" : "Exclusive Representative")}{"\""}{Environment.NewLine}Company to this aircraft.{Environment.NewLine}{Environment.NewLine}"; 
					tmpCaption = $"{tmpCaption}This process will put the aircraft {"\""}on exclusive{"\""} and make the {Environment.NewLine}{"\""}{((strComingFrom == "99") ? "Exclusive Broker" : "Exclusive Representative")}{"\""}"; 
					tmpCaption = $"{tmpCaption} Company the primary company for status.{Environment.NewLine}It will also make the Owner the contact for verifying the exclusive.{Environment.NewLine}"; 
					tmpCaption = $"{tmpCaption}All of these changes will happen immediately.{Environment.NewLine}{Environment.NewLine}"; 
					tmpCaption = $"{tmpCaption}Are you sure you want to associate this {"\""}{((strComingFrom == "99") ? "Exclusive Broker" : "Exclusive Representative")}{"\""}{Environment.NewLine}Company to this aircraft?"; 
					 
					lblExclusiveBroker.Text = tmpCaption; 
					 
					this.Cursor = CursorHelper.CursorDefault; 
					 
					break;
				case "Fractional Expire Date" : 
					 
					this.Text = "Assign/Change Fractional Expire Date"; 
					 
					pnlAwaitingDocs.Visible = false; 
					pnlAddExclusiveBroker.Visible = true; 
					lblExclusiveCallbackDate.Text = "Fractional Expiration Date"; 
					 
					if (dtFractionalExpireDate.Trim() == "")
					{
						txtExclusiveCallbackDate.Text = DateTime.Parse(modAdminCommon.DateToday).ToString("d");
					}
					else if (Information.IsDate(dtFractionalExpireDate))
					{ 
						txtExclusiveCallbackDate.Text = DateTime.Parse(dtFractionalExpireDate).ToString("d");
					}
					else
					{
						txtExclusiveCallbackDate.Text = DateTime.Parse(modAdminCommon.DateToday).ToString("d");
					} 
					 
					dtFractionalExpireDate = DateTime.Parse(txtExclusiveCallbackDate.Text).ToString("d"); 
					 
					tmpCaption = "This will change the fractional expiration date for this owner."; 
					tmpCaption = $"{tmpCaption}{Environment.NewLine}{Environment.NewLine}This change will happen IMMEDIATELY."; 
					tmpCaption = $"{tmpCaption}{Environment.NewLine}{Environment.NewLine}Are you sure you want to modify this date?"; 
					 
					lblExclusiveBroker.Text = tmpCaption; 
					 
					this.Cursor = CursorHelper.CursorDefault; 
					 
					break;
				case "Company Name Change" : 
					 
					cmdCancel.Visible = true; 
					 
					lblExclusiveCallbackDate.Text = "Name Changed As Of"; 
					 
					txtExclusiveCallbackDate.Text = DateTime.Parse(modAdminCommon.GetDateTime()).ToString("d"); 
					dtCallbackDate = DateTime.Parse(txtExclusiveCallbackDate.Text).ToString("d"); 
					lblExclusiveBroker.Text = "Is this a Formal Name Change?"; 
					 
					CenterLabel(); 
					 
					break;
				case "Aircraft Search" : case "AC Pub" : 
					 
					pnlAircraftSearch.Visible = true; 
					pnlAircraftSearch.Enabled = true; 
					 
					pnlAddExclusiveBroker.Visible = false; 
					pnlAwaitingDocs.Visible = false; 
					pnlAddExclusiveBroker.Enabled = false; 
					pnlAwaitingDocs.Enabled = true; 
					 
					this.Text = "Aircraft Search (Top 100 Only)"; 
					txt_make.Text = ""; 
					 
					break;
			}

			this.Cursor = CursorHelper.CursorDefault;


		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{



		}

		private void grdSearch_Click(Object eventSender, EventArgs eventArgs) => cmdSelect.Visible = true;


		private void grdSearch_DoubleClick(Object eventSender, EventArgs eventArgs)
		{


			int AC_ID = 0;

			if (grdSearch.CurrentRowIndex > 0)
			{
				grdSearch.CurrentColumnIndex = 0;
				AC_ID = Convert.ToInt32(Conversion.Val(grdSearch[grdSearch.CurrentRowIndex, grdSearch.CurrentColumnIndex].FormattedValue.ToString()));

				if (ComingFrom.Trim() == "AC Pub")
				{
					if (AC_ID > 0)
					{
						frm_WebCrawl.DefInstance.txt_pub[1].Text = AC_ID.ToString();
					}
				}
				else
				{
					if (AC_ID > 0)
					{
						modAdminCommon.gbl_Aircraft_ID = AC_ID;
						modAdminCommon.gbl_Aircraft_Journal_ID = 0;
					}
				}

				this.Close();

			}

		}

		private void txt_id_box_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{

				// added MSw - 9/28/23
				if (KeyCode == ((int) Keys.Return))
				{
					cmdFind_Click(cmdFind, new EventArgs());
				}
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}


		}


		private void txt_Make_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{

				if (KeyCode == ((int) Keys.Return))
				{
					cmdFind_Click(cmdFind, new EventArgs());
				}
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}

		}

		private void txt_RegNo_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				if (KeyCode == ((int) Keys.Return))
				{
					cmdFind_Click(cmdFind, new EventArgs());
				}
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}

		private void txt_SerialNo_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{

				if (KeyCode == ((int) Keys.Return))
				{
					cmdFind_Click(cmdFind, new EventArgs());
				}
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}
	}
}