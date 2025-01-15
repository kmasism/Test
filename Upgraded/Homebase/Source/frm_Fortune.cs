using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Gui;
using UpgradeHelpers.Gui.Controls;
using UpgradeHelpers.Gui.Utils;
using UpgradeHelpers.Helpers;
using UpgradeStubs;

namespace JETNET_Homebase
{
	internal partial class frm_Fortune
		: System.Windows.Forms.Form
	{


		public string inComp_name = "";
		public int inComp_ID = 0;
		public int Found_Company_Id = 0;
		public int Found_Journal_Id = 0;


		private bool Stopped = false;
		private string strOrderBy = "";

		private dynamic XL = null; //gap-note Excel library must be analyzed during stabilization.
		private dynamic xlWrkBook = null;//gap-note Excel library must be analyzed during stabilization.
		private dynamic xlSheet = null;//gap-note Excel library must be analyzed during stabilization.
		private dynamic xlRange = null;//gap-note Excel library must be analyzed during stabilization.
		private dynamic xlFont = null;//gap-note Excel library must be analyzed during stabilization.
		private int XLRow = 0;
		private int XLCol = 0;
		private string R1C1 = "";
		private int NSheet = 0;
		private int FirstYear = 0;
		private string Action = "";
		private string[] RememberWhatChanged = null;
		private int GridLastRow = 0;
		private int GridLastCol = 0;
		private int display_comp_id = 0;

		private modGlobalVars.e_find_form_action_types tCompFind_ActionTypes = (modGlobalVars.e_find_form_action_types) 0;
		private modGlobalVars.e_find_form_entry_points tCompFind_EntryPoints = (modGlobalVars.e_find_form_entry_points) 0;
		public frm_Fortune()
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




		private void HighlightRowColor(int sRow)
		{
			//Used to highlight empty cells with pink

			int sCol = 0;

			//non-edit cols=0,1,3,4,5,6,7, >15
			grdFortune.CurrentRowIndex = sRow;
			grdFortune.CurrentColumnIndex = 2; //rank
			string tmp = $"{grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].FormattedValue.ToString()}";

			if (Conversion.Val(tmp) == 0)
			{
				grdFortune.CellBackColor = Color.FromArgb(128, 128, 255); //blue &H8080FF  'PINK
			}

			for (int J = 9; J <= 9; J++)
			{ //nbaa & industry
				grdFortune.CurrentColumnIndex = J;
				tmp = ($"{grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].FormattedValue.ToString()}").Trim();

				if (Strings.Len(tmp) == 0)
				{
					grdFortune.CellBackColor = Color.FromArgb(128, 128, 255); //blue &H8080FF  'PINK
				}
			}

			for (int J = 10; J <= 14; J++)
			{ //numbers-- revenue, etc.
				grdFortune.CurrentColumnIndex = J;
				tmp = $"{grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].FormattedValue.ToString()}";

				if (Conversion.Val(tmp) == 0)
				{
					grdFortune.CellBackColor = Color.FromArgb(128, 128, 255); //blue &H8080FF  'PINK
				}
			}



		}


		public void TurnOffTabStop()
		{
			Control Control = null;
			//UPGRADE_WARNING: (2065) Form property frm_Fortune.Controls has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
			foreach (Control ControlIterator in ContainerHelper.Controls(this))
			{
				ErrorHandlingHelper.ResumeNext(
					() => {Control = ControlIterator;}, 
					() => {Control.TabStop = false;});
				Control = default(Control);
			}
		}

		public void TurnOnTabStop()
		{
			Control Control = null;
			//UPGRADE_WARNING: (2065) Form property frm_Fortune.Controls has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
			foreach (Control ControlIterator in ContainerHelper.Controls(this))
			{
				ErrorHandlingHelper.ResumeNext(
					() => {Control = ControlIterator;}, 
						//If Control.Name <> "txt_contact_id" Then
					() => {Control.TabStop = true;});
				//End If
				Control = default(Control);
			}
		}

		public void MoveInGrid(int Kcode)
		{
			//Tabbing through the grid.
			//If tab to the next cell, then perform a double click.
			//keyascii = 9 (tab)


			if (grdFortune.CurrentRowIndex > 0)
			{
				//if not at the last column, then move to the next column.
				if (Kcode == 9 && grdFortune.CurrentColumnIndex != grdFortune.ColumnsCount - 2)
				{

					if (grdFortune.CurrentColumnIndex == 2)
					{
						grdFortune.CurrentColumnIndex = 8;
					}
					else if (grdFortune.CurrentColumnIndex > 7 && grdFortune.CurrentColumnIndex < 14)
					{ 
						grdFortune.CurrentColumnIndex++;
					}
					// grdFortune_Click
					grdFortune_DoubleClick(grdFortune, new EventArgs());
					//tab at the last column then move to the next row, column 0.
				}
				else if (Kcode == 9 && grdFortune.CurrentRowIndex != grdFortune.RowsCount - 1)
				{ 
					grdFortune.CurrentRowIndex++;
					grdFortune.CurrentColumnIndex = 2;
					//grdFortune_Click
					grdFortune_DoubleClick(grdFortune, new EventArgs());
				}
				else if (Kcode == 9)
				{ 
					//if one of the hidden boxes is still visible then click the grid.
					//If UCase(chg_contact_phone_flag) = "Y" Then
					//    Call grd_Contact_Phone_Numbers_Click
					// End If
					TurnOnTabStop();
					//cmd_Delete_Contact_Phone.SetFocus
				}
				else
				{

				}
			}
			else
			{
				if (Kcode == 9)
				{

					grdFortune.CurrentRowIndex = 1;
					grdFortune.CurrentColumnIndex = 2;
					// grdFortune_Click
					grdFortune_DoubleClick(grdFortune, new EventArgs());
				}
			}

		}

		private void Fill_Fortune_Years()
		{
			//fill the list of available years

			ADORecordSetHelper ado_year = new ADORecordSetHelper();

			cmb_Start_year.Items.Clear();

			string Query = "select cfort_year from Company_Fortune_1000 ";
			Query = $"{Query}group by cfort_year  ";
			Query = $"{Query}order by cfort_year desc ";

			ado_year.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
			if (!(ado_year.BOF && ado_year.EOF))
			{
				ado_year.MoveFirst();
				while (!ado_year.EOF)
				{
					cmb_Start_year.AddItem(Convert.ToString(ado_year["cfort_year"]));
					FirstYear = Convert.ToInt32(Conversion.Val($"{Convert.ToString(ado_year["cfort_year"])}"));
					ado_year.MoveNext();
				}
				ado_year.Close();
			}
			cmb_Start_year.AddItem("Add New Year");
			cmb_Start_year.SelectedIndex = 0;


		}

		private void Fill_Fortune_Industries()
		{

			//
			//fill the list of available industry names

			ADORecordSetHelper ado_industry = new ADORecordSetHelper();

			cmb_Edit.Items.Clear();
			cmb_Edit.AddItem("");

			string Query = "select * from Fortune_1000_Industry_Names ";
			Query = $"{Query}group by f1000i_industry_name ";
			Query = $"{Query}order by f1000i_industry_name ";

			ado_industry.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
			if (!(ado_industry.BOF && ado_industry.EOF))
			{
				ado_industry.MoveFirst();
				while (!ado_industry.EOF)
				{
					cmb_Edit.AddItem(Convert.ToString(ado_industry["f1000i_industry_name"]));
					ado_industry.MoveNext();
				}
				ado_industry.Close();
			}

			cmb_Edit.SelectedIndex = 0;


		}




		private void chk_edit_Enter(Object eventSender, EventArgs eventArgs) => TurnOffTabStop();


		private void chk_edit_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{
				//If KeyAscii = 13 Or KeyAscii = 9 Then
				if (KeyAscii == 9)
				{
					if (chk_edit.CheckState == CheckState.Checked)
					{
						grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = "Y";
					}
					else
					{
						grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = "N";

					}

					if (KeyAscii == 9)
					{
						MoveInGrid(KeyAscii);
					}

					// chk_edit.Visible = False
					// grdFortune.Enabled = True
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
		}


		private void chk_edit_Leave(Object eventSender, EventArgs eventArgs)
		{
			// chk_edit.Visible = False
			Application.DoEvents();
			TurnOnTabStop();
		}

		private void ChkCompID_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{

			if (ChkCompID.CheckState == CheckState.Checked)
			{
				grdFortune.SetColumnWidth(0, 67);
			}
			else
			{
				grdFortune.SetColumnWidth(0, 0);
			}
			Application.DoEvents();
			grdFortune.Refresh();

		}

		private void chkEdit_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{

			txt_edit.Visible = false;
			//chk_edit.Visible = False

			if (chkEdit.CheckState == CheckState.Checked)
			{
				cmdAddCompany.Visible = true;

				ChkRollup.CheckState = CheckState.Unchecked;
				Label1.Text = "Year to Edit: ";
				Application.DoEvents();
				// cmdDisplay_Click
				lblEdit.Visible = true;
				Application.DoEvents();

			}
			else
			{
				cmdAddCompany.Visible = false;
				lblEdit.Visible = true;
				cmdSaveEdits.Visible = false;
				Label1.Text = "Year of Interest:";
			}

			Application.DoEvents();
		}

		private void cmb_Edit_Enter(Object eventSender, EventArgs eventArgs)
		{
			TurnOffTabStop();
			txt_edit.Visible = false;
			cmb_YN.Visible = false;
		}


		private void cmb_Edit_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{

				if (KeyAscii == 9)
				{
					grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = cmb_Edit.Text;
					MoveInGrid(KeyAscii);

				}
				else
				{
					grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = cmb_Edit.Text;

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

		}


		private void cmb_Edit_Leave(Object eventSender, EventArgs eventArgs)
		{
			TurnOnTabStop();
			//grdFortune.Text = cmb_Edit.Text
			cmb_Edit.SelectedIndex = 0;
			cmb_Edit.Visible = false;
		}

		private void cmb_Start_year_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs)
		{
			int NewYr = 0;

			if (cmb_Start_year.Text == "Add New Year")
			{
				NewYr = Convert.ToInt32(Conversion.Val($"{InputBoxHelper.InputBox("Enter a New Year", "New Year")}"));
				if (NewYr > 2004 && NewYr < 3000)
				{
					cmb_Start_year.AddItem(NewYr.ToString());
					cmb_Start_year.SelectedIndex = cmb_Start_year.Items.Count - 1;

				}
				else
				{
					MessageBox.Show($"Year:{NewYr.ToString()} is outside of valid range", "Add Year");
				}
			}

			txt_prior_year.Text = (Conversion.Val($"{cmb_Start_year.Text}") - 1).ToString();

		}


		private void cmb_YN_Enter(Object eventSender, EventArgs eventArgs)
		{
			TurnOffTabStop();
			txt_edit.Visible = false;
			cmb_Edit.Visible = false;
		}


		private void cmb_YN_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{
				if (KeyAscii == 9)
				{
					grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = cmb_YN.Text;
					MoveInGrid(KeyAscii);
				}
				else
				{
					grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = cmb_YN.Text;

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

		}


		private void cmb_YN_Leave(Object eventSender, EventArgs eventArgs)
		{
			TurnOnTabStop();
			cmb_YN.SelectedIndex = 0;
			cmb_YN.Visible = false;

		}

		private void cmdAddCompany_Click(Object eventSender, EventArgs eventArgs)
		{

			DialogResult Ans = (DialogResult) 0;

			if (RememberWhatChanged.GetUpperBound(0) > 0)
			{
				Ans = MessageBox.Show("Save Row Data Changes?", "Save Changes", MessageBoxButtons.YesNo);
				if (Ans == System.Windows.Forms.DialogResult.Yes)
				{
					cmdSaveEdits_Click(cmdSaveEdits, new EventArgs());
				}

			}

			Action = "Get Fortune1000";
			cmdGoToCompany.Visible = false;

			txt_edit.Visible = false;

			Found_Company_Id = -1; //-1 indicates no company identified

			tCompFind_ActionTypes = modGlobalVars.e_find_form_action_types.geIdCompany;

			if (modGlobalVars.bCallShowAndLoadOnlyOnce)
			{

				//UPGRADE_TODO: (1067) Member Clear_Search_Criteria is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_MISC].Clear_Search_Criteria(true, true, true);
				//UPGRADE_TODO: (1067) Member EntryPoint is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_MISC].EntryPoint = modGlobalVars.e_find_form_entry_points.geFortune1000;
				//UPGRADE_TODO: (1067) Member ActionTypes is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_MISC].ActionTypes = tCompFind_ActionTypes;
				//UPGRADE_TODO: (1067) Member Show is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_MISC].Show();
				//UPGRADE_TODO: (1067) Member ZOrder is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_MISC].ZOrder(0);

			}

		}

		private void cmdDisplay_Click(Object eventSender, EventArgs eventArgs)
		{
			//11/8/2005 aey
			string Query = "";
			ADORecordSetHelper ado_fortune = new ADORecordSetHelper();
			ADORecordSetHelper ado_aircraft = null;
			int NumRecs = 0;
			int CurRow = 0;
			int tmp_comp_id = 0;
			string Operated = "";
			int AC_ID = 0;
			int old_ac_id = 0;
			int pRank = 0;
			int CurrRank = 0;
			int PriorRank = 0;
			int[] comp_list = null;
			bool AddToGrid = false;


			DialogResult Ans = (DialogResult) 0;
			if (RememberWhatChanged.GetUpperBound(0) > 0)
			{
				Ans = MessageBox.Show("Save Row Data Changes?", "Save Changes", MessageBoxButtons.YesNo);
				if (Ans == System.Windows.Forms.DialogResult.Yes)
				{
					cmdSaveEdits_Click(cmdSaveEdits, new EventArgs());
				}
			}

			Stopped = false;
			cmdGoToCompany.Visible = false;

			this.Cursor = Cursors.WaitCursor;
			int top = Convert.ToInt32(Conversion.Val($"{txt_Number_to_Display.Text}"));
			string CName = ($"{txt_company_name.Text}").Trim();
			int StartYear = Convert.ToInt32(Conversion.Val($"{cmb_Start_year.Text}"));
			int CompareYear = Convert.ToInt32(Conversion.Val($"{txt_prior_year.Text}"));
			ChkCompID.Visible = false;
			cmdExcel.Visible = false;

			int EndRank = Convert.ToInt32(Conversion.Val($"{txt_EndRank.Text}"));
			int StartRank = Convert.ToInt32(Conversion.Val($"{txt_StartRank.Text}"));

			txt_edit.Visible = false;
			//chk_edit.Visible = False

			RememberWhatChanged = new string[]{""};
			comp_list = new int[1];

			int MaxComp_list = 0;

			if (StartYear == 0)
			{
				StartYear = DateTime.Now.Year;
			}

			if (CompareYear == 0)
			{
				CompareYear = StartYear - 1;
			}

			if (CompareYear < FirstYear)
			{
				MessageBox.Show($"No Data for {CompareYear.ToString()}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				return;
			}

			chkEdit.Visible = true;
			cmdStop.Visible = true;
			Application.DoEvents();
			Application.DoEvents();

			grdFortune.Clear();
			grdFortune.RowsCount = 2;
			grdFortune.FixedRows = 1;
			grdFortune.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
			grdFortune.SetRowHeight(0, 2 * grdFortune.Rows[1].Height);
			grdFortune.ColumnsCount = 27;
			grdFortune.CurrentRowIndex = 0;
			grdFortune.CurrentColumnIndex = 0;
			grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = "Comp_id";
			grdFortune.SetColumnWidth(0, 0);
			if (ChkCompID.CheckState == CheckState.Checked)
			{
				grdFortune.SetColumnWidth(0, 67);
			}
			grdFortune.CurrentColumnIndex = 1;
			grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = $"{CompareYear.ToString()} Rank";
			grdFortune.SetColumnWidth(1, 67);
			grdFortune.CurrentColumnIndex = 2;
			grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = $"{StartYear.ToString()} Rank";
			grdFortune.SetColumnWidth(2, 67);
			grdFortune.CurrentColumnIndex = 3;
			grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = "Company";
			grdFortune.SetColumnWidth(3, 120);
			grdFortune.CurrentColumnIndex = 4;
			grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = "Address";
			grdFortune.SetColumnWidth(4, 87);
			grdFortune.CurrentColumnIndex = 5;
			grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = "City";
			grdFortune.SetColumnWidth(5, 87);
			grdFortune.CurrentColumnIndex = 6;
			grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = "State";
			grdFortune.SetColumnWidth(6, 33);
			grdFortune.CurrentColumnIndex = 7;
			grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = "Zip";
			grdFortune.SetColumnWidth(7, 53);
			grdFortune.CurrentColumnIndex = 8;
			grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = "NBAA";
			grdFortune.SetColumnWidth(8, 40);
			grdFortune.CurrentColumnIndex = 9;
			grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = "Industry";
			grdFortune.SetColumnWidth(9, 100);
			grdFortune.CurrentColumnIndex = 10;
			grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = "Revenues $M";
			grdFortune.SetColumnWidth(10, 60);
			grdFortune.CurrentColumnIndex = 11;
			grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = "Profits $M";
			grdFortune.SetColumnWidth(11, 60);
			grdFortune.CurrentColumnIndex = 12;
			grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = "Assets $M";
			grdFortune.SetColumnWidth(12, 60);
			grdFortune.CurrentColumnIndex = 13;
			grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = "Stockholders Equity $M";
			grdFortune.SetColumnWidth(13, 60);
			grdFortune.CurrentColumnIndex = 14;
			grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = "Employees";
			grdFortune.SetColumnWidth(14, 53);
			if (chkEdit.CheckState == CheckState.Checked)
			{
				grdFortune.CurrentColumnIndex = 15;
				grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = "Year";
				grdFortune.SetColumnWidth(15, 47);
				grdFortune.SetColumnWidth(15, 0);

			}
			else
			{
				grdFortune.CurrentColumnIndex = 15;
				grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = "All AC-Tot#";
				grdFortune.SetColumnWidth(15, 67);
			}


			grdFortune.CurrentColumnIndex = 16;
			grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = "All AC- Whole Owned";
			grdFortune.SetColumnWidth(16, 67);
			grdFortune.CurrentColumnIndex = 17;
			grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = "All AC- Frac Owned";
			grdFortune.SetColumnWidth(17, 67);
			grdFortune.CurrentColumnIndex = 18;
			grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = "All AC- Operated";
			grdFortune.SetColumnWidth(18, 67);
			grdFortune.CurrentColumnIndex = 19;
			grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = "Fixed Wing Jet-Tot#";
			grdFortune.SetColumnWidth(19, 67);
			grdFortune.CurrentColumnIndex = 20;
			grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = "Fixed Wing Jet- Whole Owned";
			grdFortune.SetColumnWidth(20, 67);
			grdFortune.CurrentColumnIndex = 21;
			grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = "Fixed Wing Jet- Frac Owned";
			grdFortune.SetColumnWidth(21, 67);
			grdFortune.CurrentColumnIndex = 22;
			grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = "Fixed Wing Jet- Operated";
			grdFortune.SetColumnWidth(22, 67);
			grdFortune.CurrentColumnIndex = 23;
			grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = "Heli-Tot#";
			grdFortune.SetColumnWidth(23, 67);
			grdFortune.CurrentColumnIndex = 24;
			grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = "Heli- Whole Owned";
			grdFortune.SetColumnWidth(24, 67);
			grdFortune.CurrentColumnIndex = 25;
			grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = "Heli- Frac Owned";
			grdFortune.SetColumnWidth(25, 67);
			grdFortune.CurrentColumnIndex = 26;
			grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = "Heli- Operated";
			grdFortune.SetColumnWidth(26, 67);

			if (chkEdit.CheckState == CheckState.Checked)
			{
				ChkRollup.CheckState = CheckState.Unchecked; //limit colums in edit mode
				//non-edit cols=0,1,3,4,5,6,7, >15
				grdFortune.CurrentRowIndex = 0;
				grdFortune.CurrentColumnIndex = 2;
				grdFortune.CellBackColor = Color.Lime;
				for (int J = 8; J <= 14; J++)
				{
					grdFortune.CurrentColumnIndex = J;
					grdFortune.CellBackColor = Color.Lime;
				}
			}

			if (top == 0)
			{
				Query = "Select f1.*,company.comp_name,comp_address1,comp_city,comp_state,comp_zip_code from Company_Fortune_1000 as F1 WITH(NOLOCK) ";
			}
			else
			{
				Query = $"Select top {top.ToString()} f1.*,company.comp_name,comp_address1,comp_city,comp_state,comp_zip_code from Company_Fortune_1000 as F1 WITH(NOLOCK) ";
			}

			Query = $"{Query}inner join company WITH(NOLOCK) on comp_id=f1.cfort_comp_id and comp_journ_id=f1.cfort_journ_id ";
			//Query = Query & "inner join Company_Fortune_1000 as F2 WITH(NOLOCK) on comp_id=f2.cfort_comp_id and comp_journ_id=f2.cfort_journ_id "
			Query = $"{Query}where comp_journ_id=0 ";
			//and comp_active_flag='Y' "

			if (StartRank > 0)
			{
				Query = $"{Query} and f1.cfort_rank >= {StartRank.ToString()} ";
			}

			if (EndRank > 0)
			{
				Query = $"{Query} and f1.cfort_rank <= {EndRank.ToString()} ";
			}

			if (Strings.Len(CName) > 0)
			{
				Query = $"{Query}and comp_name like '{CName}%' ";
			}

			if (Conversion.Val($"{txt_Comp_id.Text}") > 0)
			{
				Query = $"{Query}and comp_id ={Conversion.Val(txt_Comp_id.Text).ToString()} ";
			}

			if (chkEdit.CheckState == CheckState.Checked)
			{
				Query = $"{Query} and f1.cfort_year in ('{StartYear.ToString()}','{CompareYear.ToString()}') ";
			}
			else
			{
				Query = $"{Query} and f1.cfort_year= '{StartYear.ToString()}' ";
			}

			if (chkEdit.CheckState == CheckState.Checked)
			{
				Query = $"{Query}Order by f1.cfort_year desc, cfort_rank ";
			}
			else
			{
				if (Strings.Len(strOrderBy) > 0)
				{
					Query = $"{Query}Order by {strOrderBy}";
				}
				else
				{
					if (opOrderBy[0].Checked)
					{
						Query = $"{Query}Order by comp_name ";
					}
					else
					{
						Query = $"{Query}Order by f1.cfort_rank ";
					}
				}
			}

			ado_fortune.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
			if (!(ado_fortune.BOF && ado_fortune.EOF))
			{
				ado_fortune.MoveFirst();
				NumRecs = 0;
				PriorRank = 0;


				while(!ado_fortune.EOF)
				{
					CurRow = grdFortune.RowsCount - 1;
					grdFortune.RowsCount++;
					grdFortune.CurrentRowIndex = CurRow;
					grdFortune.set_RowData(CurRow,Convert.ToInt32( ado_fortune.GetField("cfort_id")));
					grdFortune.CurrentColumnIndex = 0;
					grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = ado_fortune.GetField("cfort_comp_id");
					tmp_comp_id = Convert.ToInt32(Conversion.Val($"{Convert.ToString(ado_fortune["cfort_comp_id"])}"));
					grdFortune.CurrentColumnIndex = 1;

					if (Convert.ToDouble(ado_fortune["cfort_year"]) == StartYear)
					{
						AddToGrid = true;
						MaxComp_list = 1 + comp_list.GetUpperBound(0);
						comp_list = ArraysHelper.RedimPreserve(comp_list, new int[]{MaxComp_list + 1});
						comp_list[MaxComp_list] = tmp_comp_id;
						pRank = Convert.ToInt32(Conversion.Val($"{modCommon.DLookUp("cfort_rank", "company_fortune_1000", $"cfort_year={CompareYear.ToString()} and cfort_comp_id={tmp_comp_id.ToString()}")}"));
						if (pRank > 0)
						{
							grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = pRank;
						}
						else
						{
							grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = "N/A";
						}
						grdFortune.CellAlignment = DataGridViewContentAlignment.MiddleRight;
						grdFortune.CurrentColumnIndex = 2;
						grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = $"{Convert.ToString(ado_fortune["cfort_Rank"])}";
						CurrRank = Convert.ToInt32(Conversion.Val($"{Convert.ToString(ado_fortune["cfort_Rank"])}"));
						grdFortune.CellAlignment = DataGridViewContentAlignment.MiddleRight;
						if (Math.Abs(CurrRank - PriorRank) > 1)
						{
							grdFortune.CellBackColor = Color.FromArgb(192, 192, 255); //blue &H80FF80    'green
						}
						if (CurrRank == PriorRank)
						{
							grdFortune.CellBackColor = Color.Fuchsia; //Purple
						}

						PriorRank = CurrRank;
					}
					else
					{
						AddToGrid = true;
						MaxComp_list = comp_list.GetUpperBound(0);
						int tempForEndVar2 = MaxComp_list;
						for (int J = 1; J <= tempForEndVar2; J++)
						{
							if (comp_list[J] == tmp_comp_id)
							{
								AddToGrid = false;
							}
						}

						if (AddToGrid)
						{
							MaxComp_list = 1 + comp_list.GetUpperBound(0);
							comp_list = ArraysHelper.RedimPreserve(comp_list, new int[]{MaxComp_list + 1});
							comp_list[MaxComp_list] = tmp_comp_id;
						}
						else
						{
							grdFortune.RowsCount--;
							goto cmdDisplay_getNextRecord;
						}

						grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = $"{Convert.ToString(ado_fortune["cfort_Rank"])}";
						grdFortune.CurrentColumnIndex = 2;
						grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = "N/A";
						grdFortune.CellAlignment = DataGridViewContentAlignment.MiddleRight;
						grdFortune.CellForeColor = Color.FromArgb(255, 128, 128); //pink
					}


					grdFortune.CurrentColumnIndex = 3;
					grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = $"{Convert.ToString(ado_fortune["Comp_Name"])}";
					grdFortune.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

					if (Convert.ToDouble(ado_fortune["cfort_year"]) == StartYear)
					{
						grdFortune.CurrentColumnIndex = 4;
						grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = $"{Convert.ToString(ado_fortune["comp_address1"])}";
						grdFortune.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						grdFortune.CurrentColumnIndex = 5;
						grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = $"{Convert.ToString(ado_fortune["comp_city"])}";
						grdFortune.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						grdFortune.CurrentColumnIndex = 6;
						grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = $"{Convert.ToString(ado_fortune["comp_state"])}";
						grdFortune.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						grdFortune.CurrentColumnIndex = 7;
						grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = $"{Convert.ToString(ado_fortune["comp_zip_code"])}";
						grdFortune.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						grdFortune.CurrentColumnIndex = 8;
						if (chkEdit.CheckState == CheckState.Unchecked)
						{
							if (Convert.ToString(ado_fortune["cfort_nbaa_member_flag"]) == "Y")
							{
								grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = "NBAA";
							}
							else
							{
								grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = "";
							}
						}
						else
						{
							grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = $"{Convert.ToString(ado_fortune["cfort_nbaa_member_flag"])}";
						}
						grdFortune.CurrentColumnIndex = 9;
						grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = $"{Convert.ToString(ado_fortune["cfort_industry_name"])}";
						grdFortune.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						grdFortune.CurrentColumnIndex = 10;
						grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = StringsHelper.Format(Conversion.Val($"{Convert.ToString(ado_fortune["cfort_revenue"])}"), "###,##0.0");
						grdFortune.CellAlignment = DataGridViewContentAlignment.MiddleRight;

						grdFortune.CurrentColumnIndex = 11;
						grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = StringsHelper.Format(Conversion.Val($"{Convert.ToString(ado_fortune["cfort_profit"])}"), "###,##0.0");
						grdFortune.CellAlignment = DataGridViewContentAlignment.MiddleRight;
						grdFortune.CurrentColumnIndex = 12;
						grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = StringsHelper.Format(Conversion.Val($"{Convert.ToString(ado_fortune["cfort_assets"])}"), "###,##0.0");
						grdFortune.CellAlignment = DataGridViewContentAlignment.MiddleRight;
						grdFortune.CurrentColumnIndex = 13;
						grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = StringsHelper.Format(Conversion.Val($"{Convert.ToString(ado_fortune["cfort_stock_equity"])}"), "###,##0.0");
						grdFortune.CellAlignment = DataGridViewContentAlignment.MiddleRight;
						grdFortune.CurrentColumnIndex = 14;
						grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = StringsHelper.Format(Conversion.Val($"{Convert.ToString(ado_fortune["cfort_employees"])}"), "###,##0");
						grdFortune.CellAlignment = DataGridViewContentAlignment.MiddleRight;

						HighlightRowColor(grdFortune.CurrentRowIndex);

					}




					if (chkEdit.CheckState == CheckState.Checked)
					{
						grdFortune.CurrentColumnIndex = 15;
						grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = StringsHelper.Format(Conversion.Val($"{Convert.ToString(ado_fortune["cfort_year"])}"), "####0");
						grdFortune.CellAlignment = DataGridViewContentAlignment.MiddleRight;
					}
					else
					{

						for (int K = 15; K <= 26; K++)
						{
							grdFortune.CurrentColumnIndex = K;
							grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = 0;
						}
					}

					if (tmp_comp_id > 0 && ChkRollup.CheckState == CheckState.Checked)
					{
						ado_aircraft = new ADORecordSetHelper();
						//            Query = "select distinct amod_make_name,amod_model_name, ac_ser_no_full, ac_reg_no , ac_ownership_type,amod_type_code ,cref_operator_flag ,amod_airframe_type_code "
						//            Query = Query & "from aircraft_model WITH(NOLOCK) "
						//            Query = Query & "inner join aircraft WITH(NOLOCK) on amod_id = ac_amod_id "
						//            Query = Query & "inner join aircraft_reference WITH(NOLOCK) on cref_ac_id = ac_id and cref_journ_id = ac_journ_id and ac_journ_id = 0 "
						//            Query = Query & "Where cref_comp_id = " & tmp_comp_id & " "
						//            Query = Query & "or cref_comp_id in (select distinct compref_rel_comp_id From company_reference "
						//            Query = Query & "Where compref_comp_id = " & tmp_comp_id & " "
						//            Query = Query & "and compref_journ_id = 0 "
						//            Query = Query & "and compref_contact_type in ('79','59','84','77','77','1B','83','2A')) "

						Query = $"exec HomebaseGetRelatedAircraft {tmp_comp_id.ToString()} ";
						ado_aircraft.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
						if (!(ado_aircraft.BOF && ado_aircraft.EOF))
						{
							ado_aircraft.MoveFirst();
							old_ac_id = 0;

							while(!ado_aircraft.EOF)
							{
								AC_ID = Convert.ToInt32(ado_aircraft["AC_ID"]);
								if (AC_ID != old_ac_id)
								{

									grdFortune.CurrentColumnIndex = 15;
									grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = Conversion.Val($"{grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].FormattedValue.ToString()}") + 1;
									if (Convert.ToString(ado_aircraft["ac_ownership_type"]) == "W")
									{
										grdFortune.CurrentColumnIndex = 16;
										grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = Conversion.Val($"{grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].FormattedValue.ToString()}") + 1;
									}
									if (Convert.ToString(ado_aircraft["ac_ownership_type"]) != "W")
									{
										grdFortune.CurrentColumnIndex = 17;
										grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = Conversion.Val($"{grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].FormattedValue.ToString()}") + 1;
									}
									Query = $"select * from aircraft_reference where cref_comp_id={tmp_comp_id.ToString()} and cref_ac_id={AC_ID.ToString()} and cref_journ_id=0 and cref_operator_flag='Y' ";
									Operated = "N";
									if (modAdminCommon.Exist(Query))
									{
										Operated = "Y";
									}
									if (Operated == "Y")
									{
										grdFortune.CurrentColumnIndex = 18;
										grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = Conversion.Val($"{grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].FormattedValue.ToString()}") + 1;
									}

									if (Convert.ToString(ado_aircraft["amod_type_code"]) == "J" && Convert.ToString(ado_aircraft["amod_airframe_type_code"]) == "F")
									{
										grdFortune.CurrentColumnIndex = 19;
										grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = Conversion.Val($"{grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].FormattedValue.ToString()}") + 1;
										if (Convert.ToString(ado_aircraft["ac_ownership_type"]) == "W")
										{
											grdFortune.CurrentColumnIndex = 20;
											grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = Conversion.Val($"{grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].FormattedValue.ToString()}") + 1;
										}
										if (Convert.ToString(ado_aircraft["ac_ownership_type"]) != "W")
										{
											grdFortune.CurrentColumnIndex = 21;
											grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = Conversion.Val($"{grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].FormattedValue.ToString()}") + 1;
										}
										if (Operated == "Y")
										{
											grdFortune.CurrentColumnIndex = 22;
											grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = Conversion.Val($"{grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].FormattedValue.ToString()}") + 1;
										}
									}
									if (Convert.ToString(ado_aircraft["amod_airframe_type_code"]) == "R")
									{
										grdFortune.CurrentColumnIndex = 23;
										grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = Conversion.Val($"{grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].FormattedValue.ToString()}") + 1;
										if (Convert.ToString(ado_aircraft["ac_ownership_type"]) == "W")
										{
											grdFortune.CurrentColumnIndex = 24;
											grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = Conversion.Val($"{grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].FormattedValue.ToString()}") + 1;
										}
										if (Convert.ToString(ado_aircraft["ac_ownership_type"]) != "W")
										{
											grdFortune.CurrentColumnIndex = 25;
											grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = Conversion.Val($"{grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].FormattedValue.ToString()}") + 1;
										}
										if (Operated == "Y")
										{
											grdFortune.CurrentColumnIndex = 26;
											grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = Conversion.Val($"{grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].FormattedValue.ToString()}") + 1;
										}
									}
								}
								old_ac_id = AC_ID;
								ado_aircraft.MoveNext();
							};
							ado_aircraft.Close();
						}
					}

					cmdDisplay_getNextRecord:
					NumRecs++;
					lblMsg.Text = $"{NumRecs.ToString()} Records";
					Application.DoEvents();
					Application.DoEvents();
					Application.DoEvents();
					if (Stopped)
					{
						break;
					}
					ado_fortune.MoveNext();
				};
			}
			ado_fortune.Close();

			if (ChkRollup.CheckState == CheckState.Unchecked && chkEdit.CheckState == CheckState.Unchecked)
			{
				grdFortune.ColumnsCount = 15;
			}

			if (chkEdit.CheckState == CheckState.Checked)
			{
				grdFortune.ColumnsCount = 16;
			}

			lblMsg.Text = $"Done: {NumRecs.ToString()} Records";

			ado_fortune = null;
			ado_aircraft = null;

			if (grdFortune.RowsCount > 2)
			{
				grdFortune.RowsCount--;
			}

			cmdExcel.Visible = true;
			ChkCompID.Visible = true;

			this.Cursor = CursorHelper.CursorDefault;

		}

		private void cmdExcel_Click(Object eventSender, EventArgs eventArgs)
		{
			//11/8/2005 aey
			int Comp_id = 0;
			int AC_ID = 0;
			ADORecordSetHelper ado_company = null;
			ADORecordSetHelper ado_models = new ADORecordSetHelper();
			string Query = "";
			string CName = "";
			string Operated = "";
			int cRank = 0;
			int amod_id = 0;

			DialogResult Ans = (DialogResult) 0;

			cmdGoToCompany.Visible = false;

			if (RememberWhatChanged.GetUpperBound(0) > 0)
			{
				Ans = MessageBox.Show("Save Row Data Changes?", "Save Changes", MessageBoxButtons.YesNo);
				if (Ans == System.Windows.Forms.DialogResult.Yes)
				{
					cmdSaveEdits_Click(cmdSaveEdits, new EventArgs());
				}

			}


			this.Cursor = Cursors.WaitCursor;

			NSheet = 1;
			int NumRecs = 0;
			string inClause = "";

			txt_edit.Visible = false;
			// chk_edit.Visible = False

			XL = new Excel.Application();
			//UPGRADE_TODO: (1067) Member Workbooks is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlWrkBook = XL.Workbooks.Add();

			//UPGRADE_TODO: (1067) Member Author is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlWrkBook.Author = "JETNET, Inc";
			//UPGRADE_TODO: (1067) Member Title is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlWrkBook.Title = "Fortune 1000 Reports";
			//UPGRADE_TODO: (1067) Member Subject is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlWrkBook.Subject = $"Copyright(c) AvData Inc a JETNET Company {DateTime.Now.Year.ToString()}";

			//UPGRADE_TODO: (1067) Member ActiveWorkbook is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlSheet = XL.ActiveWorkbook.ActiveSheet;

			//UPGRADE_TODO: (1067) Member ActiveWorkbook is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlSheet = XL.ActiveWorkbook.ActiveSheet;
			//UPGRADE_TODO: (1067) Member Name is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlSheet.Name = "Table of Contents";
			//UPGRADE_TODO: (1067) Member PageSetup is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlSheet.PageSetup.LeftHeader = "Table of Contents";
			//UPGRADE_TODO: (1067) Member PageSetup is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlSheet.PageSetup.LeftFooter = $"Copyright(c) AvData Inc a JETNET Company {DateTime.Now.Year.ToString()}";
			//UPGRADE_TODO: (1067) Member PageSetup is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlSheet.PageSetup.CenterFooter = "Page &P of &N";
			//UPGRADE_TODO: (1067) Member PageSetup is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlSheet.PageSetup.Orientation = 2; //xlLandscape
			//UPGRADE_TODO: (1067) Member PageSetup is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlSheet.PageSetup.RightFooter = $"Data as of {DateTimeHelper.ToString(DateTime.Now)}";

			//UPGRADE_TODO: (1067) Member Visible is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Visible = true;

			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Cells.Select();
			//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Selection.Interior.ColorIndex = 19; //pale yellow
			//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Selection.Interior.Pattern = 1; //xlSolid
			//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Selection.Interior.PatternColorIndex = (-4105); //xlAutomatic

			XLRow = 1;
			XLCol = 1;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlSheet.Cells[XLRow, XLCol] = $"Fortune 1000 REPORTS as of {DateTime.Now.ToString("MM/dd/yyyy")}";
			XLRow++;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlSheet.Cells[XLRow, XLCol] = $"Copyright (c) {DateTime.Now.Year.ToString()} by AVDATA Inc a JETNET Company ";

			XLRow += 2;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlSheet.Cells[XLRow, XLCol] = "Table of Contents (click on title)";

			R1C1 = GetR1C1(1, 1, XLRow, 1);

			//UPGRADE_TODO: (1067) Member Range is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlFont = XL.Range(R1C1).Font;
			//UPGRADE_TODO: (1067) Member Bold is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlFont.Bold = true;
			//UPGRADE_TODO: (1067) Member Name is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlFont.Name = "Arial";
			//UPGRADE_TODO: (1067) Member Size is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlFont.Size = 10;

			R1C1 = GetR1C1(XLRow, 1, XLRow, 1);
			//UPGRADE_TODO: (1067) Member Range is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Range(R1C1).Select();
			//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Selection.Interior.ColorIndex = 40; // light orange
			//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Selection.Interior.Pattern = 1; // xlSolid
			//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Selection.Interior.PatternColorIndex = (-4105); // xlAutomatic

			//add a sheet for companies
			NSheet++;
			//UPGRADE_TODO: (1067) Member Worksheets is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Worksheets.Add(XL.Worksheets(XL.Worksheets.Count));
			//UPGRADE_TODO: (1067) Member Worksheets is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Worksheets(NSheet).Activate();
			//UPGRADE_TODO: (1067) Member ActiveWorkbook is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlSheet = XL.ActiveWorkbook.ActiveSheet;
			//UPGRADE_TODO: (1067) Member Name is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlSheet.Name = "Companies";

			//UPGRADE_TODO: (1067) Member PageSetup is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlSheet.PageSetup.LeftHeader = "Fortune 1000 Companies";
			//UPGRADE_TODO: (1067) Member PageSetup is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlSheet.PageSetup.LeftFooter = $"Copyright(c) AvData Inc a JETNET Company {DateTime.Now.Year.ToString()}";

			//UPGRADE_TODO: (1067) Member PageSetup is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlSheet.PageSetup.CenterFooter = "Page &P of &N";
			//UPGRADE_TODO: (1067) Member PageSetup is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlSheet.PageSetup.Orientation = 2; //xlLandscape
			//UPGRADE_TODO: (1067) Member PageSetup is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlSheet.PageSetup.RightFooter = $"Data as of {DateTimeHelper.ToString(DateTime.Now)}";

			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Cells.Select();
			//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Selection.Interior.ColorIndex = 19; //pale yellow
			//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Selection.Interior.Pattern = 1; // xlSolid
			//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Selection.Interior.PatternColorIndex = (-4105); // xlAutomatic

			XLRow = 1;
			R1C1 = GetR1C1(XLRow, 1, XLRow, 1);
			//UPGRADE_TODO: (1067) Member Range is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Range(R1C1).Select();
			//UPGRADE_WARNING: (7006) The Named argument TextToDisplay was not resolved and corresponds to the following expression Back to Table of Contents More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-7006
			//UPGRADE_WARNING: (7006) The Named argument SubAddress was not resolved and corresponds to the following expression 'Table of Contents'!A1 More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-7006
			//UPGRADE_WARNING: (7006) The Named argument Address was not resolved and corresponds to the following expression  More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-7006
			//UPGRADE_WARNING: (7006) The Named argument Anchor was not resolved and corresponds to the following expression XL.Selection More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-7006
			//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			//UPGRADE_TODO: (1067) Member ActiveSheet is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.ActiveSheet.Hyperlinks.Add(XL.Selection, "", "'Table of Contents'!A1", "Back to Table of Contents");

			// XL.Visible = True
			XLRow = 2;
			XLCol = 1;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlSheet.Cells[XLRow, XLCol] = $"Copyright (c) {DateTime.Now.Year.ToString()} by AVDATA Inc a JETNET Company ";
			XLRow++;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlSheet.Cells[XLRow, XLCol] = "Fortune 1000 Companies with Aircraft Counts";

			R1C1 = GetR1C1(1, 1, XLRow, 1);

			//UPGRADE_TODO: (1067) Member Range is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlFont = XL.Range(R1C1).Font;
			//UPGRADE_TODO: (1067) Member Bold is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlFont.Bold = true;
			//UPGRADE_TODO: (1067) Member Name is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlFont.Name = "Arial";
			//UPGRADE_TODO: (1067) Member Size is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlFont.Size = 10;

			XLRow = 5;
			int StartRow = XLRow + 1;

			int FirstCol = 1;
			int ColOffset = 0;
			if (ChkCompID.CheckState == CheckState.Checked)
			{
				FirstCol = 0;
				ColOffset = 1;
			}

			int tempForEndVar = grdFortune.RowsCount - 1;
			for (int jRow = 0; jRow <= tempForEndVar; jRow++)
			{
				grdFortune.CurrentRowIndex = jRow;
				grdFortune.CurrentColumnIndex = 3;
				if (grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].FormattedValue.ToString() != "")
				{ //skip over
					int tempForEndVar2 = grdFortune.ColumnsCount - 1;
					for (int kCol = FirstCol; kCol <= tempForEndVar2; kCol++)
					{
						grdFortune.CurrentColumnIndex = kCol;
						//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						xlSheet.Cells[XLRow, kCol + ColOffset] = grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].FormattedValue.ToString();
					}

					if (jRow == 0)
					{
						R1C1 = GetR1C1(XLRow, 1, XLRow, ColOffset + grdFortune.ColumnsCount - 1);
						//UPGRADE_TODO: (1067) Member Range is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						xlFont = XL.Range(R1C1).Font;
						//UPGRADE_TODO: (1067) Member Bold is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						xlFont.Bold = true;
						//UPGRADE_TODO: (1067) Member Name is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						xlFont.Name = "Arial";
						//UPGRADE_TODO: (1067) Member Size is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						xlFont.Size = 10;
						//UPGRADE_TODO: (1067) Member Range is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						XL.Range(R1C1).Select();
						//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						XL.Selection.Interior.ColorIndex = 40; // light orange
						//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						XL.Selection.Interior.Pattern = 1; // xlSolid
						//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						XL.Selection.Interior.PatternColorIndex = (-4105); // xlAutomatic
						//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						XL.Selection.WrapText = true;
						//        .Orientation = 70

					}

					NumRecs++;
					lblMsg.Text = $"{NumRecs.ToString()} Company Records";
					Application.DoEvents();
					if (Stopped)
					{
						break;
					}

					XLRow++;
				}
			}

			//XLRow = XLRow + 1
			int NumComp = NumRecs;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlSheet.Cells[XLRow, 1] = "' Total";

			FirstCol = 10;
			int LastCol = 26;
			if (ChkCompID.CheckState == CheckState.Checked)
			{
				FirstCol = 11;
				LastCol = 27;
			}

			int tempForEndVar3 = LastCol;
			for (int J = FirstCol; J <= tempForEndVar3; J++)
			{
				R1C1 = GetR1C1(StartRow, J, XLRow - 1, J);
				//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				xlSheet.Cells[XLRow, J] = $"=sum({R1C1})";
			}

			R1C1 = GetR1C1(StartRow, 1, XLRow, grdFortune.ColumnsCount - 1 + ColOffset);
			//    R1C1 = GetR1C1(XLRow, 1, XLRow, grdFortune.Cols - 1)
			//UPGRADE_TODO: (1067) Member Range is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlFont = XL.Range(R1C1).Font;
			//UPGRADE_TODO: (1067) Member Bold is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlFont.Bold = false;
			//UPGRADE_TODO: (1067) Member Name is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlFont.Name = "Arial";
			//UPGRADE_TODO: (1067) Member Size is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlFont.Size = 8;

			//UPGRADE_TODO: (1067) Member Range is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Range(R1C1).Select();
			//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Selection.Interior.ColorIndex = (-4142); //xlNone

			R1C1 = GetR1C1(StartRow - 1, 1, XLRow, grdFortune.ColumnsCount - 1 + ColOffset);
			DrawABox();

			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Cells.Select();
			//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Selection.Columns.AutoFit();
			//UPGRADE_TODO: (1067) Member Columns is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Columns("A:A").ColumnWidth = 10;
			//xlSheet.PageSetup.PrintArea = "$4:$" & XLRow + 2

			//>>>>>>>>>>> SHEET 2 - aircraft detail <<<<<<<<<<<<

			NumRecs = 0;
			NSheet++;
			//UPGRADE_TODO: (1067) Member Worksheets is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Worksheets.Add(XL.Worksheets(XL.Worksheets.Count));
			//UPGRADE_TODO: (1067) Member Worksheets is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Worksheets(NSheet).Activate();
			//UPGRADE_TODO: (1067) Member ActiveWorkbook is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlSheet = XL.ActiveWorkbook.ActiveSheet;

			//UPGRADE_TODO: (1067) Member Name is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlSheet.Name = "Aircraft";

			//UPGRADE_TODO: (1067) Member PageSetup is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlSheet.PageSetup.LeftHeader = "Aircraft Detail for Fortune 1000 Companies";
			//UPGRADE_TODO: (1067) Member PageSetup is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlSheet.PageSetup.LeftFooter = $"Copyright(c) AvData Inc a JETNET Company {DateTime.Now.Year.ToString()}";

			//UPGRADE_TODO: (1067) Member PageSetup is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlSheet.PageSetup.CenterFooter = "Page &P of &N";
			//UPGRADE_TODO: (1067) Member PageSetup is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlSheet.PageSetup.Orientation = 2; //xlLandscape
			//UPGRADE_TODO: (1067) Member PageSetup is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlSheet.PageSetup.RightFooter = $"Data as of {DateTimeHelper.ToString(DateTime.Now)}";

			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Cells.Select();
			//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Selection.Interior.ColorIndex = 19; //pale yellow
			//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Selection.Interior.Pattern = 1; // xlSolid
			//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Selection.Interior.PatternColorIndex = (-4105); // xlAutomatic

			XLRow = 1;
			R1C1 = GetR1C1(XLRow, 1, XLRow, 1);
			//UPGRADE_TODO: (1067) Member Range is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Range(R1C1).Select();
			//UPGRADE_WARNING: (7006) The Named argument TextToDisplay was not resolved and corresponds to the following expression Back to Table of Contents More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-7006
			//UPGRADE_WARNING: (7006) The Named argument SubAddress was not resolved and corresponds to the following expression 'Table of Contents'!A1 More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-7006
			//UPGRADE_WARNING: (7006) The Named argument Address was not resolved and corresponds to the following expression  More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-7006
			//UPGRADE_WARNING: (7006) The Named argument Anchor was not resolved and corresponds to the following expression XL.Selection More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-7006
			//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			//UPGRADE_TODO: (1067) Member ActiveSheet is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.ActiveSheet.Hyperlinks.Add(XL.Selection, "", "'Table of Contents'!A1", "Back to Table of Contents");

			XLRow = 2;
			XLCol = 1;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlSheet.Cells[XLRow, XLCol] = $"Copyright (c) {DateTime.Now.Year.ToString()} by AVDATA Inc a JETNET Company ";
			XLRow++;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlSheet.Cells[XLRow, XLCol] = "Aircraft Detail for Fortune 1000 Companies ";

			R1C1 = GetR1C1(1, 1, XLRow, 1);

			//UPGRADE_TODO: (1067) Member Range is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlFont = XL.Range(R1C1).Font;
			//UPGRADE_TODO: (1067) Member Bold is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlFont.Bold = true;
			//UPGRADE_TODO: (1067) Member Name is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlFont.Name = "Arial";
			//UPGRADE_TODO: (1067) Member Size is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlFont.Size = 10;

			//   R1C1 = GetR1C1(1, 1, XLRow, 1)
			//   XL.Range(R1C1).Select
			//   With XL.Selection.Interior
			//      .ColorIndex = 40   ' light orange
			//      .Pattern = 1   ' xlSolid
			//      .PatternColorIndex = -4105   ' xlAutomatic
			//   End With

			XLRow = 5;
			StartRow = XLRow + 1;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlSheet.Cells[XLRow, 1] = $"{cmb_Start_year.Text} Rank";
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlSheet.Cells[XLRow, 2] = "Company";
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlSheet.Cells[XLRow, 3] = "Make";
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlSheet.Cells[XLRow, 4] = "Model";
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlSheet.Cells[XLRow, 5] = "Year";
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlSheet.Cells[XLRow, 6] = "Serial";
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlSheet.Cells[XLRow, 7] = "Reg No";
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlSheet.Cells[XLRow, 8] = "How Owned";
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlSheet.Cells[XLRow, 9] = "Type";
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlSheet.Cells[XLRow, 10] = "Operated";
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlSheet.Cells[XLRow, 11] = "Airframe";

			R1C1 = GetR1C1(XLRow, 1, XLRow, 11);

			//UPGRADE_TODO: (1067) Member Range is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlFont = XL.Range(R1C1).Font;
			//UPGRADE_TODO: (1067) Member Bold is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlFont.Bold = true;
			//UPGRADE_TODO: (1067) Member Name is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlFont.Name = "Arial";
			//UPGRADE_TODO: (1067) Member Size is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlFont.Size = 10;
			//UPGRADE_TODO: (1067) Member Range is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Range(R1C1).Select();
			//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Selection.Interior.ColorIndex = 40; // light orange
			//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Selection.Interior.Pattern = 1; // xlSolid
			//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Selection.Interior.PatternColorIndex = (-4105); // xlAutomatic
			XLRow++;

			int tempForEndVar4 = grdFortune.RowsCount - 1;
			for (int jRow = 1; jRow <= tempForEndVar4; jRow++)
			{
				grdFortune.CurrentColumnIndex = 0;
				grdFortune.CurrentRowIndex = jRow;
				Comp_id = Convert.ToInt32(Conversion.Val($"{grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].FormattedValue.ToString()}"));
				grdFortune.CurrentColumnIndex = 2;
				cRank = Convert.ToInt32(Double.Parse($"{grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].FormattedValue.ToString()}"));
				grdFortune.CurrentColumnIndex = 3;
				CName = $"{grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].FormattedValue.ToString()}";

				if (Comp_id > 0)
				{
					ado_company = new ADORecordSetHelper();
					Query = $"exec HomebaseGetRelatedAircraft {Comp_id.ToString()} ";

					ado_company.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
					if (!(ado_company.BOF && ado_company.EOF))
					{
						ado_company.MoveFirst();

						while(!ado_company.EOF)
						{
							AC_ID = Convert.ToInt32(ado_company["AC_ID"]);
							inClause = $"{inClause}{AC_ID.ToString()}, ";
							//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
							xlSheet.Cells[XLRow, 1] = cRank;
							//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
							xlSheet.Cells[XLRow, 2] = $"{CName}";
							//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
							xlSheet.Cells[XLRow, 3] = $"'{Convert.ToString(ado_company["amod_make_name"])}";
							//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
							xlSheet.Cells[XLRow, 4] = $"'{Convert.ToString(ado_company["amod_model_name"])}";
							//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
							xlSheet.Cells[XLRow, 5] = $"{Convert.ToString(ado_company["ac_year"])}";
							//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
							xlSheet.Cells[XLRow, 6] = $"'{Convert.ToString(ado_company["ac_ser_no_full"])}";
							//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
							xlSheet.Cells[XLRow, 7] = $"'{Convert.ToString(ado_company["ac_reg_no"])}";
							//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
							xlSheet.Cells[XLRow, 8] = $"'{((Convert.ToString(ado_company["ac_ownership_type"]) == "W") ? "Whole Owned" : ((Convert.ToString(ado_company["ac_ownership_type"]) == "S") ? "Shares Owned" : "Frac Owned"))}";
							if (Convert.ToString(ado_company["amod_airframe_type_code"]) == "F")
							{
								//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								xlSheet.Cells[XLRow, 9] = $"'{((Convert.ToString(ado_company["amod_type_code"]) == "J") ? "Jet" : ((Convert.ToString(ado_company["amod_type_code"]) == "T") ? "TurboProp" : "Piston"))}";
							}
							else
							{
								//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								xlSheet.Cells[XLRow, 9] = $"'{((Convert.ToString(ado_company["amod_type_code"]) == "J") ? "Jet" : ((Convert.ToString(ado_company["amod_type_code"]) == "T") ? "Turbine" : "Piston"))}";
							}
							Operated = "N";
							Query = $"select * from aircraft_reference where cref_comp_id={Comp_id.ToString()} and cref_ac_id={AC_ID.ToString()} and cref_journ_id=0 and cref_operator_flag='Y' ";
							if (modAdminCommon.Exist(Query))
							{
								Operated = "Y";
							}

							//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
							xlSheet.Cells[XLRow, 10] = $"'{((Operated == "N") ? "No" : "Yes")}";
							//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
							xlSheet.Cells[XLRow, 11] = $"'{((Convert.ToString(ado_company["amod_airframe_type_code"]) == "F") ? "Fixed Wing" : "Rotary")}";

							ado_company.MoveNext();
							XLRow++;
							NumRecs++;
							lblMsg.Text = $"{NumRecs.ToString()} Aircraft Records";
							Application.DoEvents();
							if (Stopped)
							{
								break;
							}
						};
					}
					ado_company.Close();
				}

				Application.DoEvents();
				if (Stopped)
				{
					break;
				}
			}

			ado_company = null;

			R1C1 = GetR1C1(StartRow, 1, XLRow - 1, 11);
			//UPGRADE_TODO: (1067) Member Range is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlFont = XL.Range(R1C1).Font;
			//UPGRADE_TODO: (1067) Member Bold is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlFont.Bold = false;
			//UPGRADE_TODO: (1067) Member Name is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlFont.Name = "Arial";
			//UPGRADE_TODO: (1067) Member Size is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlFont.Size = 8;
			//UPGRADE_TODO: (1067) Member Range is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Range(R1C1).Select();
			//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Selection.Interior.ColorIndex = (-4142); //xlNone
			R1C1 = GetR1C1(StartRow - 1, 1, XLRow - 1, 11);
			DrawABox();

			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Cells.Select();
			//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Selection.Columns.AutoFit();
			//UPGRADE_TODO: (1067) Member Columns is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Columns("A:A").ColumnWidth = 10;

			//xlSheet.PageSetup.PrintArea = "$4:$" & XLRow + 2

			//add a sheet for models
			NSheet++;
			//UPGRADE_TODO: (1067) Member Worksheets is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Worksheets.Add(XL.Worksheets(XL.Worksheets.Count));
			//UPGRADE_TODO: (1067) Member Worksheets is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Worksheets(NSheet).Activate();
			//UPGRADE_TODO: (1067) Member ActiveWorkbook is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlSheet = XL.ActiveWorkbook.ActiveSheet;
			//UPGRADE_TODO: (1067) Member Name is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlSheet.Name = "Aircraft Models";

			//UPGRADE_TODO: (1067) Member PageSetup is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlSheet.PageSetup.LeftHeader = "Aircraft Models Used by the Fortune 1000 Companies";
			//UPGRADE_TODO: (1067) Member PageSetup is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlSheet.PageSetup.LeftFooter = $"Copyright(c) AvData Inc a JETNET Company {DateTime.Now.Year.ToString()}";

			//UPGRADE_TODO: (1067) Member PageSetup is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlSheet.PageSetup.CenterFooter = "Page &P of &N";
			//UPGRADE_TODO: (1067) Member PageSetup is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlSheet.PageSetup.Orientation = 2; //xlLandscape
			//UPGRADE_TODO: (1067) Member PageSetup is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlSheet.PageSetup.RightFooter = $"Data as of {DateTimeHelper.ToString(DateTime.Now)}";

			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Cells.Select();
			//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Selection.Interior.ColorIndex = 19; //pale yellow
			//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Selection.Interior.Pattern = 1; // xlSolid
			//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Selection.Interior.PatternColorIndex = (-4105); // xlAutomatic

			XLRow = 1;
			R1C1 = GetR1C1(XLRow, 1, XLRow, 1);
			//UPGRADE_TODO: (1067) Member Range is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Range(R1C1).Select();
			//UPGRADE_WARNING: (7006) The Named argument TextToDisplay was not resolved and corresponds to the following expression Back to Table of Contents More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-7006
			//UPGRADE_WARNING: (7006) The Named argument SubAddress was not resolved and corresponds to the following expression 'Table of Contents'!A1 More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-7006
			//UPGRADE_WARNING: (7006) The Named argument Address was not resolved and corresponds to the following expression  More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-7006
			//UPGRADE_WARNING: (7006) The Named argument Anchor was not resolved and corresponds to the following expression XL.Selection More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-7006
			//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			//UPGRADE_TODO: (1067) Member ActiveSheet is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.ActiveSheet.Hyperlinks.Add(XL.Selection, "", "'Table of Contents'!A1", "Back to Table of Contents");

			// XL.Visible = True
			XLRow = 2;
			XLCol = 1;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlSheet.Cells[XLRow, XLCol] = $"Copyright (c) {DateTime.Now.Year.ToString()} by AVDATA Inc a JETNET Company ";
			XLRow++;
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlSheet.Cells[XLRow, XLCol] = "Aircraft Models Used by the Fortune 1000 Companies ";

			R1C1 = GetR1C1(1, 1, XLRow, 1);

			//UPGRADE_TODO: (1067) Member Range is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlFont = XL.Range(R1C1).Font;
			//UPGRADE_TODO: (1067) Member Bold is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlFont.Bold = true;
			//UPGRADE_TODO: (1067) Member Name is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlFont.Name = "Arial";
			//UPGRADE_TODO: (1067) Member Size is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlFont.Size = 10;

			//drop the last comma
			inClause = inClause.Trim();
			inClause = StringsHelper.MidAssignment(inClause, Strings.Len(inClause), 1, " ");
			inClause = inClause.Trim();

			//model summary
			Query = "Select amod_make_name,amod_model_name,amod_id,amod_type_code,amod_airframe_type_code, count(ac_id) as freq  from aircraft ";
			Query = $"{Query}inner join aircraft_model on ac_amod_id=amod_id ";
			Query = $"{Query}where ac_journ_id=0 and amod_customer_flag='Y' ";
			Query = $"{Query}and ac_id in({inClause} ) ";
			Query = $"{Query}group by amod_make_name,amod_model_name,amod_id ,amod_type_code,amod_airframe_type_code ";
			Query = $"{Query}order by amod_make_name,amod_model_name ";

			XLRow = 5;

			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlSheet.Cells[XLRow, 1] = "'Make";
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlSheet.Cells[XLRow, 2] = "'Model";
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlSheet.Cells[XLRow, 3] = "'# Aircraft";
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlSheet.Cells[XLRow, 4] = "'Type";
			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlSheet.Cells[XLRow, 5] = "'Airframe";

			R1C1 = GetR1C1(XLRow, 1, XLRow, 5);

			//UPGRADE_TODO: (1067) Member Range is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlFont = XL.Range(R1C1).Font;
			//UPGRADE_TODO: (1067) Member Bold is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlFont.Bold = true;
			//UPGRADE_TODO: (1067) Member Name is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlFont.Name = "Arial";
			//UPGRADE_TODO: (1067) Member Size is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlFont.Size = 10;
			//UPGRADE_TODO: (1067) Member Range is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Range(R1C1).Select();
			//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Selection.Interior.ColorIndex = 40; // light orange
			//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Selection.Interior.Pattern = 1; // xlSolid
			//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Selection.Interior.PatternColorIndex = (-4105); // xlAutomatic

			XLRow++;
			StartRow = XLRow;

			ado_models.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
			if (!(ado_models.BOF && ado_models.EOF))
			{
				ado_models.MoveFirst();

				while(!ado_models.EOF)
				{
					//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					xlSheet.Cells[XLRow, 1] = $"'{Convert.ToString(ado_models["amod_make_name"])}";
					//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					xlSheet.Cells[XLRow, 2] = $"'{Convert.ToString(ado_models["amod_model_name"])}";
					//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					xlSheet.Cells[XLRow, 3] = Conversion.Val($"{Convert.ToString(ado_models["freq"])}");

					if (Convert.ToString(ado_models["amod_airframe_type_code"]) == "F")
					{
						//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						xlSheet.Cells[XLRow, 4] = $"'{((Convert.ToString(ado_models["amod_type_code"]) == "J") ? "Jet" : ((Convert.ToString(ado_models["amod_type_code"]) == "T") ? "TurboProp" : "Piston"))}";
					}
					else
					{
						//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						xlSheet.Cells[XLRow, 4] = $"'{((Convert.ToString(ado_models["amod_type_code"]) == "J") ? "Jet" : ((Convert.ToString(ado_models["amod_type_code"]) == "T") ? "Turbine" : "Piston"))}";
					}
					//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					xlSheet.Cells[XLRow, 5] = $"'{((Convert.ToString(ado_models["amod_airframe_type_code"]) == "F") ? "Fixed Wing" : "Rotary")}";
					XLRow++;
					ado_models.MoveNext();
				};
				ado_models.Close();
			}

			ado_models = null;

			R1C1 = GetR1C1(StartRow, 1, XLRow - 1, 5);
			//UPGRADE_TODO: (1067) Member Range is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlFont = XL.Range(R1C1).Font;
			//UPGRADE_TODO: (1067) Member Bold is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlFont.Bold = false;
			//UPGRADE_TODO: (1067) Member Name is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlFont.Name = "Arial";
			//UPGRADE_TODO: (1067) Member Size is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlFont.Size = 8;
			//UPGRADE_TODO: (1067) Member Range is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Range(R1C1).Select();
			//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Selection.Interior.ColorIndex = (-4142); //xlNone
			R1C1 = GetR1C1(StartRow - 1, 1, XLRow - 1, 5);
			DrawABox();

			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Cells.Select();
			//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Selection.Columns.AutoFit();
			//UPGRADE_TODO: (1067) Member Columns is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Columns("A:A").ColumnWidth = 18;

			//xlSheet.PageSetup.PrintArea = "$4:$" & XLRow + 2

			//Go back to first sheet, then add sheet names to first sheet
			//UPGRADE_TODO: (1067) Member Worksheets is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Worksheets(1).Activate();
			//UPGRADE_TODO: (1067) Member ActiveWorkbook is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			xlSheet = XL.ActiveWorkbook.ActiveSheet;
			XLRow = 5;
			XLCol = 1;
			int KK = 0;
			//UPGRADE_TODO: (1067) Member Worksheets is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			int K = Convert.ToInt32(XL.Worksheets.Count);
			int tempForEndVar5 = K;
			for (int J = 2; J <= tempForEndVar5; J++)
			{
				//UPGRADE_TODO: (1067) Member Worksheets is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				if (!Convert.ToString(XL.Worksheets(J).Name).StartsWith("Sheet", StringComparison.Ordinal))
				{
					KK++;
					//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					//UPGRADE_TODO: (1067) Member Worksheets is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					xlSheet.Cells[XLRow, XLCol] = XL.Worksheets(J).Name;
					R1C1 = GetR1C1(XLRow, 1, XLRow, 1);
					//UPGRADE_TODO: (1067) Member Range is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					XL.Range(R1C1).Select();
					//UPGRADE_WARNING: (7006) The Named argument TextToDisplay was not resolved and corresponds to the following expression    & Format() & .  & XL.Worksheets().Name More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-7006
					//UPGRADE_TODO: (1067) Member Worksheets is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					//UPGRADE_WARNING: (7006) The Named argument SubAddress was not resolved and corresponds to the following expression ' & XL.Worksheets().Name & '!A1 More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-7006
					//UPGRADE_WARNING: (7006) The Named argument Address was not resolved and corresponds to the following expression  More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-7006
					//UPGRADE_WARNING: (7006) The Named argument Anchor was not resolved and corresponds to the following expression XL.Selection More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-7006
					//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					//UPGRADE_TODO: (1067) Member ActiveSheet is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					XL.ActiveSheet.Hyperlinks.Add(XL.Selection, "", $"'{Convert.ToString(XL.Worksheets(J).Name)}'!A1", $"  {StringsHelper.Format(KK, "00")}. {Convert.ToString(XL.Worksheets(J).Name)}");
					//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					XL.Selection.Interior.ColorIndex = (-4142); // xlNone
					XLRow++;
				}
			}

			//remove unused sheets
			//UPGRADE_TODO: (1067) Member DisplayAlerts is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.DisplayAlerts = false; //turn off warning messages
			//UPGRADE_TODO: (1067) Member Workbooks is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			dynamic WS = XL.Workbooks; //gap-note Excel library must be analyzed during stabilization.
			KK = 0;
			//UPGRADE_TODO: (1067) Member Worksheets is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			foreach (object WSIterator in (System.Collections.IEnumerable) XL.Worksheets)
			{
				WS = WSIterator;
				//UPGRADE_TODO: (1067) Member Name is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				if (Convert.ToString(WS.Name).StartsWith("Sheet", StringComparison.Ordinal))
				{
					//remove unwanted sheet(s)
					//UPGRADE_TODO: (1067) Member Delete is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					WS.Delete();

				}
				WS = default(object);
			}
			//UPGRADE_TODO: (1067) Member DisplayAlerts is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.DisplayAlerts = true;

			//display term definitions
			//   XLRow = XLRow + 1
			//   StartRow = XLRow
			//   xlSheet.Cells(XLRow, XLCol) = "'Definitions:"
			//   R1C1 = GetR1C1(XLRow, 1, XLRow, 1)
			//   Set xlFont = XL.Range(R1C1).Font
			//   xlFont.Bold = True
			//
			//   XLRow = XLRow + 1
			//   xlSheet.Cells(XLRow, XLCol) = "'Aircraft Category Codes: A 4 position code describing the aircraft and it's ownership. Positions are numbered from the left."
			//   XLRow = XLRow + 1
			//   xlSheet.Cells(XLRow, XLCol) = "'  Position 1: Operator flag: Y or N"
			//   XLRow = XLRow + 1
			//   xlSheet.Cells(XLRow, XLCol) = "'  Position 2: Ownership type: W=Whole,S=Share,F=Fractional"
			//   XLRow = XLRow + 1
			//   xlSheet.Cells(XLRow, XLCol) = "'  Position 3: Airframe Type: F=Fixed Wing,R=Rotary"
			//   XLRow = XLRow + 1
			//   xlSheet.Cells(XLRow, XLCol) = "'  Position 4: Aircraft Type: J=Jet,T=Turboprop/Turbine,P=Piston"

			//UPGRADE_TODO: (1067) Member Cells is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Cells.Select();
			//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Selection.Columns.AutoFit();

			//xlSheet.PageSetup.PrintArea = "$4:$" & XLRow + 2

			lblMsg.Text = $"Done:{NumComp.ToString()} Company and {NumRecs.ToString()} Aircraft Records";

			//clean up
			XL = null;
			ado_company = null;
			this.Cursor = CursorHelper.CursorDefault;

		}

		public void DrawABox()
		{
			//draws a box around selected area

			//UPGRADE_TODO: (1067) Member Range is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Range(R1C1).Select();
			//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Selection.Borders(5).LineStyle = (-4142); // xlNone
			//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			XL.Selection.Borders(6).LineStyle = (-4142);
			dynamic withVar = null; //left edge//gap-note Excel library must be analyzed during stabilization.
			//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			withVar = XL.Selection.Borders(7);
			withVar.LineStyle = 1; // xlContinuous
			withVar.Weight = 2; // xlThin
			withVar.ColorIndex = (-4105); // xlAutomatic
			dynamic withVar_2 = null; //top edge //gap-note Excel library must be analyzed during stabilization.
									  //UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			withVar_2 = XL.Selection.Borders(8);
			withVar_2.LineStyle = 1; // xlContinuous
			withVar_2.Weight = 2; // xlThin
			withVar_2.ColorIndex = (-4105);
			dynamic withVar_3 = null; //xlEdgeBottom //gap-note Excel library must be analyzed during stabilization.
			//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			withVar_3 = XL.Selection.Borders(9);
			withVar_3.LineStyle = 1; // xlContinuous
			withVar_3.Weight = 2; //xlThin
			withVar_3.ColorIndex = (-4105);
			dynamic withVar_4 = null; //xlEdgeRight //gap-note Excel library must be analyzed during stabilization.
			//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			withVar_4 = XL.Selection.Borders(10);
			withVar_4.LineStyle = 1; //xlContinuous
			withVar_4.Weight = 2; // xlThin
			withVar_4.ColorIndex = (-4105);

			dynamic withVar_5 = null; //xlInsideVertical //gap-note Excel library must be analyzed during stabilization.
			//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			withVar_5 = XL.Selection.Borders(11);
			withVar_5.LineStyle = 1; // xlContinuous
			withVar_5.Weight = 2; // xlThin
			withVar_5.ColorIndex = (-4105);

			dynamic withVar_6 = null; //xlInsideHorizontal //gap-note Excel library must be analyzed during stabilization.
			//UPGRADE_TODO: (1067) Member Selection is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			withVar_6 = XL.Selection.Borders(12);
			withVar_6.LineStyle = 1; // xlContinuous
			withVar_6.Weight = 2; //xlThin
			withVar_6.ColorIndex = (-4105);
		}

		public string GetR1C1(int R1, int C1, int R2, int C2)
		{
			//aey 3/15/05
			//convert to r1c1 notation
			// mjm 4/19/05
			// fixed to go to 256 columns

			//A=65 ,Z=90

			string result = "";
			int K = 0;

			string RC1 = "";

			if (C1 > 255 && C2 > 255)
			{
				return "";
			}

			int M = C1 / 26; //rows /26
			int J = C1 % 26; //row remainder
			if (J == 0)
			{
				J = 26;
				M--;
			}

			if (M == 0)
			{
				RC1 = $"{RC1}{Strings.Chr(64 + J).ToString()}";
			}
			else
			{
				RC1 = $"{RC1}{Strings.Chr(64 + M).ToString()}";
				if (J > 0)
				{
					RC1 = $"{RC1}{Strings.Chr(64 + J).ToString()}";
				}
			}

			if (R1 > 0)
			{
				RC1 = $"{RC1}{Conversion.Str(R1).Trim()}";
				RC1 = RC1.Trim();
			}
			string RC2 = "";

			M = C2 / 26; //rows /26
			J = C2 % 26; //row remainder
			if (J == 0)
			{
				J = 26;
				M--;
			}

			if (M == 0)
			{
				RC2 = $"{RC2}{Strings.Chr(64 + J).ToString()}";
			}
			else
			{
				RC2 = $"{RC2}{Strings.Chr(64 + M).ToString()}";
				if (J > 0)
				{
					RC2 = $"{RC2}{Strings.Chr(64 + J).ToString()}";
				}
			}

			//RC2 = RC2 & Chr(64 + J)
			if (R2 > 0)
			{
				RC2 = $"{RC2}{Conversion.Str(R2).Trim()}";
				RC2 = RC2.Trim();
			}

			return $"{RC1}:{RC2}";

		}


		private void cmdGoToCompany_Click(Object eventSender, EventArgs eventArgs)
		{

			frm_Company o_Local_Show_Company = null;

			if (display_comp_id > 0)
			{

				modCommon.Unload_Form("frm_Company");
				o_Local_Show_Company = frm_Company.CreateInstance();
				//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//VB.Global.Load(o_Local_Show_Company);
				o_Local_Show_Company.Form_Initialize();
				o_Local_Show_Company.StartForm = modGlobalVars.tStart_Form;
				o_Local_Show_Company.Reference_CompanyID = display_comp_id;
				o_Local_Show_Company.Reference_CompanyJID = 0;
				o_Local_Show_Company.Show();
				//UPGRADE_WARNING: (2065) Form method o_Local_Show_Company.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
				o_Local_Show_Company.BringToFront();
				//UPGRADE_WARNING: (2065) Form event Form.Activated has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
				o_Local_Show_Company.Form_Activated(null, new EventArgs());

			}
			else
			{
				MessageBox.Show("Nothing Selected", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}

		private void cmdSaveEdits_Click(Object eventSender, EventArgs eventArgs)
		{

			int sRow = 0;
			int sCol = 0;
			StringBuilder Query = new StringBuilder();
			int cfort_id = 0;
			int NumRows = 0;
			string Rank = "";
			string NBAA = "";
			string Industry = "";
			string Revenue = "";
			string Assets = "";
			string Profit = "";
			string stock_equity = "";
			string Employees = "";
			string tmp = "";

			txt_edit.Visible = false;
			cmdGoToCompany.Visible = false;

			// chk_edit.Visible = False

			if (chkEdit.CheckState == CheckState.Checked)
			{
				NumRows = RememberWhatChanged.GetUpperBound(0);

				int tempForEndVar = NumRows;
				for (int J = 1; J <= tempForEndVar; J++)
				{
					tmp = RememberWhatChanged[J];
					sRow = Convert.ToInt32(Conversion.Val(tmp));

					if (sRow > 0)
					{
						grdFortune.CurrentRowIndex = sRow;
						grdFortune.CurrentColumnIndex = 2;
						Rank = Conversion.Val($"{grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].FormattedValue.ToString()}").ToString();
						grdFortune.CurrentColumnIndex = 8;

						if (grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].FormattedValue.ToString() == "NBAA" || grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].FormattedValue.ToString() == "Y")
						{
							NBAA = "Y";
						}
						else
						{
							NBAA = "N";
						}

						grdFortune.CurrentColumnIndex = 9;
						Industry = grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].FormattedValue.ToString();
						grdFortune.CurrentColumnIndex = 10;
						Revenue = Conversion.Val($"{StringsHelper.Replace(grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].FormattedValue.ToString(), ",", "", 1, -1, CompareMethod.Binary)}").ToString();
						grdFortune.CurrentColumnIndex = 11;
						Profit = Conversion.Val($"{StringsHelper.Replace(grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].FormattedValue.ToString(), ",", "", 1, -1, CompareMethod.Binary)}").ToString();
						grdFortune.CurrentColumnIndex = 12;
						Assets = Conversion.Val($"{StringsHelper.Replace(grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].FormattedValue.ToString(), ",", "", 1, -1, CompareMethod.Binary)}").ToString();
						grdFortune.CurrentColumnIndex = 13;
						stock_equity = Conversion.Val($"{StringsHelper.Replace(grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].FormattedValue.ToString(), ",", "", 1, -1, CompareMethod.Binary)}").ToString();
						grdFortune.CurrentColumnIndex = 14;
						Employees = Conversion.Val($"{StringsHelper.Replace(grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].FormattedValue.ToString(), ",", "", 1, -1, CompareMethod.Binary)}").ToString();
						cfort_id = grdFortune.get_RowData(sRow);

						// If cfort_id = 0 Then
						//cfort_id = 1 + Val(DMax("cfort_id", "company_fortune_1000") & "")

						//Query = "Insert into Company_fortune_1000 (cfort_comp_id,cfort_journ_id,cfort_year) "
						//Query = Query & " values(" & Found_Company_Id & "," & Found_Journal_Id & ",'" & cmb_Start_year.Text & "') "

						// Else

						Query = new StringBuilder($"update company_fortune_1000 set cfort_rank = {Rank}, ");
						Query.Append($"cfort_nbaa_member_flag = '{NBAA}', ");
						Query.Append($"cfort_industry_name = '{Industry}', ");
						Query.Append($"cfort_revenue = {Revenue}, ");
						Query.Append($"cfort_profit = {Profit}, ");
						Query.Append($"cfort_assets = {Assets}, ");
						Query.Append($"cfort_stock_equity = {stock_equity}, ");
						Query.Append($"cfort_employees = {Employees} ");
						Query.Append($" where cfort_id = {cfort_id.ToString()} ");
						// End If

						if (Conversion.Val($"{Rank}") > 0)
						{
							DbCommand TempCommand = null;
							TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
							TempCommand.CommandText = Query.ToString();
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
							TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
							TempCommand.ExecuteNonQuery();
							//MsgBox "Data Saved, Row:" & sRow
							lblMsg.Text = $"Data Saved, Row:{sRow.ToString()}";
						}
						else
						{

							Query = new StringBuilder("Delete company_fortune_1000 ");
							Query.Append($" where cfort_id = {cfort_id.ToString()} ");
							DbCommand TempCommand_2 = null;
							TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
							TempCommand_2.CommandText = Query.ToString();
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
							TempCommand_2.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
							TempCommand_2.ExecuteNonQuery();

							//MsgBox "Data Deleted, Row:" & sRow
							lblMsg.Text = $"Data Deleted, Row:{sRow.ToString()}";
							grdFortune.RemoveItem(sRow);
							grdFortune.Refresh();
						}


					} // srow>0

				}

				RememberWhatChanged = new string[]{""};
			} //chkedit

		}

		private void cmdStop_Click(Object eventSender, EventArgs eventArgs)
		{
			Stopped = true;
			Application.DoEvents();
			this.Cursor = CursorHelper.CursorDefault;
			cmdGoToCompany.Visible = false;

		}

		private void Form_Activated(Object eventSender, EventArgs eventArgs)
		{
			if (ActivateHelper.myActiveForm != eventSender)
			{
				ActivateHelper.myActiveForm = (Form) eventSender;
				string Query = "";
				try
				{
					txt_company_name.Text = ($"{inComp_name}").Trim();
					txt_Comp_id.Text = inComp_ID.ToString();
					Query = "";
					cmdGoToCompany.Visible = false;

					Found_Company_Id = 0;
					Found_Journal_Id = 0;

					//UPGRADE_TODO: (1067) Member EntryPoint is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					tCompFind_EntryPoints = (modGlobalVars.e_find_form_entry_points) Convert.ToInt32(modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_MISC].EntryPoint);

					if (modCommon.pubf_EncodeEntryPoints(tCompFind_EntryPoints) == modGlobalVars.gFIND_1000)
					{

						//UPGRADE_TODO: (1067) Member GetFormExitValues is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						Found_Company_Id = Convert.ToInt32(modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_MISC].GetFormExitValues(modGlobalVars.gcFOUNDCOMPANYID));
						//UPGRADE_TODO: (1067) Member GetFormExitValues is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						Found_Journal_Id = Convert.ToInt32(modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_MISC].GetFormExitValues(modGlobalVars.gcFOUNDCOMPANYJID));

					}

					if (Action == "Get Fortune1000")
					{

						if (modCommon.pubf_EncodeEntryPoints(tCompFind_EntryPoints) == modGlobalVars.gFIND_1000 && Found_Company_Id != 0)
						{

							Query = $"Select * from Company_fortune_1000 where cfort_journ_id = 0 and cfort_comp_id = {Found_Company_Id.ToString()}";

							if (!modAdminCommon.Exist(Query))
							{
								Query = "Insert into Company_fortune_1000 (cfort_comp_id,cfort_journ_id,cfort_year)";
								Query = $"{Query} values({Found_Company_Id.ToString()},{Found_Journal_Id.ToString()},'{cmb_Start_year.Text}') ";
								DbCommand TempCommand = null;
								TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
								UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
								TempCommand.CommandText = Query;
								//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
								//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
								TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
								UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
								TempCommand.ExecuteNonQuery();
							}

							cmdDisplay_Click(cmdDisplay, new EventArgs());

						}

					}

					return;
				}
				catch (System.Exception excep)
				{
					modAdminCommon.Report_Error($"Form_Activate_Error: {excep.Message} {Query}", "Fortune");
					this.Cursor = CursorHelper.CursorDefault;
					return;
					//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1065
					UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
				}
			}
		}

		public int CountWords(string S)
		{
			// Counts words in a string separated by specified delimeter
			//
			int result = 0;
			if (ErrorHandlingHelper.ResumeNextExpr<bool>(() => Information.VarType(S) != VariantType.String || Strings.Len(S) == 0))
			{
				result = 0;
				try
				{
					return result;
				}
				catch
				{
				}
			}
			int WC = 1;
			int Pos = (S.IndexOf(',') + 1);

			while(Pos > 0)
			{
				WC++;
				Pos = Strings.InStr(Pos + 1, S, ",", CompareMethod.Binary);
			};
			return WC;
		}

		public string GetWord(string S, int Indx)
		{

			// Returns the <Indx>th word from a comma-separated string.
			// For example, GetCSVWord("Nancy,Bob", 2) returns Bob.
			//
			string result = "";
			int WC = 0;
			int Spos = 1;
			int tempForEndVar = 0;
			int Epos = 0;
			try
			{
				WC = CountWords(S); //first get the count of delimited words
			}
			catch
			{
			}
			if (Indx < 1 || Indx > WC)
			{
				result = "";
				try
				{
					return result;
				}
				catch
				{
				}
			}
			try
			{

				tempForEndVar = Indx;
			}
			catch
			{
			}
			for (int Count = 1; Count <= tempForEndVar; Count++)
			{
				try
				{
					Spos = Strings.InStr(Spos, S, ",", CompareMethod.Binary) - 1;
				}
				catch
				{
				}
			}
			try
			{

				Epos = Strings.InStr(Spos, S, ",", CompareMethod.Binary) - 1;
			}
			catch
			{
			}
			if (Epos <= 0)
			{
				try
				{
					Epos = Strings.Len(S);
				}
				catch
				{
				}
			}
			try
			{
				result = S.Substring(Math.Min(Spos - 1, S.Length), Math.Min(Epos - Spos + 1, Math.Max(0, S.Length - (Spos - 1))));
			}
			catch
			{
			}
			return result;
		}
		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
		private void Form_Load()
		{

			//Call CenterForm32(Me)
			modCommon.CenterFormOnHomebaseMainForm(this);

			lblMsg.Text = "";
			strOrderBy = "";
			RememberWhatChanged = new string[]{""};
			GridLastRow = 0;
			GridLastCol = 0;
			display_comp_id = 0;

			Fill_Fortune_Years();
			Fill_Fortune_Industries();

			cmb_YN.Items.Clear();
			cmb_YN.AddItem("");
			cmb_YN.AddItem("Y");
			cmb_YN.AddItem("N");

		}

		private void grdFortune_Click(Object eventSender, EventArgs eventArgs)
		{

			grdFortune.CurrentColumnIndex = grdFortune.MouseCol;
			grdFortune.CurrentRowIndex = grdFortune.MouseRow;
			int sCol = grdFortune.CurrentColumnIndex;
			int sRow = grdFortune.CurrentRowIndex;
			cmdGoToCompany.Visible = false;
			display_comp_id = 0;

			if (sCol == 3)
			{
				cmdGoToCompany.Visible = true;
				cmdGoToCompany.Text = $"Go To: {StringsHelper.Replace(grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].FormattedValue.ToString().Substring(0, Math.Min(25, grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].FormattedValue.ToString().Length)), "&", "&&", 1, -1, CompareMethod.Binary)}";
				grdFortune.CurrentColumnIndex = 0;
				display_comp_id = Convert.ToInt32(Double.Parse(grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].FormattedValue.ToString()));
				grdFortune.CurrentColumnIndex = 3;
			}

			if (RememberWhatChanged.GetUpperBound(0) > 0)
			{

				if (sCol > 14)
				{
					sCol = 0;
				} //skip calculated columns

				if (sCol == 2 || sCol > 7)
				{

					if (sCol == 9)
					{
						modGridEditCommon.InPlace_Grid_Reset(grdFortune, cmb_Edit, GridLastRow, GridLastCol);
					}
					else if (sCol == 8)
					{ 
						modGridEditCommon.InPlace_Grid_Reset(grdFortune, cmb_YN, GridLastRow, GridLastCol);
					}
					else
					{
						modGridEditCommon.InPlace_Grid_Reset(grdFortune, txt_edit, GridLastRow, GridLastCol);
					}
				}

			}

		}

		private void grdFortune_DoubleClick(Object eventSender, EventArgs eventArgs)
		{
			int sCol = 0;
			int sRow = 0;
			int cfort_id = 0;
			string ColName = "";
			string ColType = "";
			string Query = "";
			int RCount = 0;
			int K = 0;
			bool FoundIt = false;
			int Ans = 0;
			int Comp_id = 0;
			string Comp_Name = "";
			int journ_id = 0;
			string Industry = "";

			try
			{
				this.Cursor = Cursors.WaitCursor;
				lblMsg.Text = "";

				if (grdFortune.CurrentRowIndex == 0)
				{
					sCol = grdFortune.CurrentColumnIndex;
					sRow = 0;
					switch(sCol)
					{
						case 1 : 
							strOrderBy = "PriorRank"; 
							//Case Else 
							//    strOrderBy = sCol 
							break;
					}

				}
				else
				{

					sCol = grdFortune.MouseCol;
					sRow = grdFortune.MouseRow;
					GridLastRow = sRow;
					GridLastCol = sCol;

					if (chkEdit.CheckState == CheckState.Checked)
					{
						grdFortune.CurrentColumnIndex = 14;
					}

					txt_edit.Visible = false;
					cmb_Edit.Visible = false;
					chk_edit.Visible = false;

					if (chkEdit.CheckState == CheckState.Checked && grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].FormattedValue.ToString() == cmb_Start_year.Text)
					{
						//non-edit cols=0,1,3,4,5,6,7, >15
						//sCol = grdFortune.MouseCol
						//   grdFortune.Col = sCol
						//sRow = grdFortune.MouseRow
						//grdFortune.Row = sRow

						// cfort_id = grdFortune.RowData(sRow)
						if (sCol > 14)
						{
							sCol = 0;
						} //skip calculated columns
						if (sCol == 2 || sCol > 7)
						{
							grdFortune.CurrentColumnIndex = sCol;

							if (sCol == 9)
							{
								//industry drop down
								modGridEditCommon.InPlace_Grid_Edit(grdFortune, cmb_Edit, false, true, null, grdFortune.Left * 15, grdFortune.Top * 15);

							}
							else if (sCol == 8)
							{ 
								//check box for nbaa
								modGridEditCommon.InPlace_Grid_Edit(grdFortune, cmb_YN, false, true, null, grdFortune.Left * 15, grdFortune.Top * 15);

							}
							else
							{
								modGridEditCommon.InPlace_Grid_Edit(grdFortune, txt_edit, false, true, null, grdFortune.Left * 15, grdFortune.Top * 15);

							}


						}

						RCount = RememberWhatChanged.GetUpperBound(0);
						if (RCount == 0)
						{
							RememberWhatChanged = ArraysHelper.RedimPreserve(RememberWhatChanged, new int[]{2});
							RememberWhatChanged[1] = sRow.ToString();
						}
						else
						{
							FoundIt = false;

							int tempForEndVar = RCount;
							for (int J = 1; J <= tempForEndVar; J++)
							{
								K = Convert.ToInt32(Double.Parse(RememberWhatChanged[J]));
								if (K == sRow)
								{
									FoundIt = true;
									break;
								}
							}

							if (!FoundIt)
							{
								RememberWhatChanged = ArraysHelper.RedimPreserve(RememberWhatChanged, new int[]{RCount + 2});
								RememberWhatChanged[RCount + 1] = sRow.ToString();
							}
						}

						cmdSaveEdits.Visible = true;
					}
					else if (chkEdit.CheckState == CheckState.Checked)
					{ 

						grdFortune.CurrentColumnIndex = 0;
						Comp_id = Convert.ToInt32(Conversion.Val($"{grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].FormattedValue.ToString()}"));
						cfort_id = grdFortune.get_RowData(sRow);
						journ_id = Convert.ToInt32(Conversion.Val($"{modCommon.DLookUp("cfort_journ_id", "company_fortune_1000", $"cfort_id={cfort_id.ToString()}")}"));
						grdFortune.CurrentColumnIndex = 15;
						grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = cmb_Start_year.Text;
						grdFortune.CurrentColumnIndex = 2;
						GridLastRow = sRow;
						GridLastCol = 2;

						if (Comp_id > 0)
						{
							Query = $"select * from Company_fortune_1000  where cfort_comp_id={Comp_id.ToString()} and cfort_year={cmb_Start_year.Text} ";
							if (!modAdminCommon.Exist(Query))
							{
								Comp_Name = modCommon.DLookUp("Comp_name", "Company", $"Comp_id={Comp_id.ToString()} and comp_journ_id={journ_id.ToString()}");

								//Ans = MsgBox("Add Company to Grid for " & cmb_Start_year.Text & "?", vbYesNo, Comp_Name)
								//If Ans = vbYes Then
								Query = "Insert into Company_fortune_1000 (cfort_comp_id,cfort_journ_id,cfort_year) ";
								Query = $"{Query} values({Comp_id.ToString()},{journ_id.ToString()},'{cmb_Start_year.Text}') ";
								DbCommand TempCommand = null;
								TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
								UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
								TempCommand.CommandText = Query;
								//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
								//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
								TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
								UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
								TempCommand.ExecuteNonQuery();
								lblMsg.Text = $"Company added for year: {cmb_Start_year.Text}";
								Application.DoEvents();
								cfort_id = Convert.ToInt32(Double.Parse(modCommon.DLookUp("cfort_id", "company_fortune_1000", $"cfort_comp_id={Comp_id.ToString()} and cfort_year={cmb_Start_year.Text} and cfort_rank=0")));
								grdFortune.set_RowData(sRow, cfort_id);
								grdFortune_DoubleClick(grdFortune, new EventArgs());
								HighlightRowColor(sRow);
								lblMsg.Text = $"{Comp_Name} added to grid for {cmb_Start_year.Text}";
								//End If
							}
						}


					} //If sCol = 2 Or sCol > 7 Then
					//End If    'chkedit
					grdFortune.CurrentColumnIndex = GridLastCol;
				} //row=


				this.Cursor = CursorHelper.CursorDefault;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"grdFortune_DblClick_Error: {excep.Message}", "Fortune");

				this.Cursor = CursorHelper.CursorDefault;
				return;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1065
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		private void grdFortune_GotFocus(Object eventSender, EventArgs eventArgs)
		{
			TurnOffTabStop();
			// chk_edit.Visible = False
			txt_edit.Visible = false;
			cmb_Edit.Visible = false;

		}

		private void grdFortune_LostFocus(Object eventSender, EventArgs eventArgs) => TurnOnTabStop();



		private void grdFortune_Scroll(Object eventSender, EventArgs eventArgs) => grdFortune_Click(grdFortune, new EventArgs());


		public void mnuClose_Click(Object eventSender, EventArgs eventArgs)
		{
			DialogResult Ans = (DialogResult) 0;
			if (RememberWhatChanged.GetUpperBound(0) > 0)
			{
				Ans = MessageBox.Show("Save Row Data Changes?", "Save Changes", MessageBoxButtons.YesNo);
				if (Ans == System.Windows.Forms.DialogResult.Yes)
				{
					cmdSaveEdits_Click(cmdSaveEdits, new EventArgs());
				}

			}

			this.Close();
		}


		private void txt_company_name_Leave(Object eventSender, EventArgs eventArgs)
		{
			//11/8/2005 aey
			ADORecordSetHelper ado_fortune = new ADORecordSetHelper();

			cmdStop.Visible = false;
			cmdExcel.Visible = false;
			ChkCompID.Visible = false;

			inComp_ID = 0;
			txt_Comp_id.Text = "0";
			grdFortune.Clear();
			grdFortune.RowsCount = 2;
			string CName = ($"{txt_company_name.Text}").Trim();

			Application.DoEvents();

			int NumRecs = 0;
			string Query = "Select * from Company_Fortune_1000 WITH(NOLOCK) ";
			Query = $"{Query}inner join company WITH(NOLOCK) on comp_id=cfort_comp_id and comp_journ_id=cfort_journ_id ";
			Query = $"{Query}where comp_name like '{CName}%' ";
			Query = $"{Query} and comp_journ_id=0 and comp_active_flag='Y' ";

			ado_fortune.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
			if (!(ado_fortune.BOF && ado_fortune.EOF))
			{
				ado_fortune.MoveLast();
				NumRecs = ado_fortune.RecordCount;
				ado_fortune.MoveFirst();

				//      If NumRecs = 1 Then
				//      ' txt_Comp_id = ado_fortune!comp_id
				//      End If
				//      grdFortune.Cols = 5

			}
			ado_fortune.Close();

			lblMsg.Text = $"{NumRecs.ToString()} Companies Found";

			ado_fortune = null;

		}


		//UPGRADE_NOTE: (7001) The following declaration (txt_First_year_LostFocus) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void txt_First_year_LostFocus()
		//{
			//cmdStop.Visible = false;
			//cmdExcel.Visible = false;
			//ChkCompID.Visible = false;
			//
			//Application.DoEvents();
		//}




		private void txt_edit_Enter(Object eventSender, EventArgs eventArgs)
		{
			TurnOffTabStop();
			//' Call chk_edit_KeyPress(9)
			// chk_edit.Visible = False
			cmb_Edit.Visible = false;
			cmb_YN.Visible = false;
		}

		private void txt_edit_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			// Call MoveInGrid(KeyCode)
			eventArgs.Handled = KeyCode == 0;
		}



		private void txt_edit_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{
				// If KeyAscii = 13 Or KeyAscii = 9 Then

				if (KeyAscii == 9)
				{
					//If grdFortune.Col = 8 Then
					//            If UCase(txt_edit.Text) = "NBAA" Then txt_edit.Text = "Y"
					//            txt_edit.Text = left(UCase(Trim(txt_edit.Text & "") & " "), 1)
					//            If txt_edit.Text <> "Y" Then
					//                txt_edit.Text = "N"
					//            End If
					//          grdFortune.Text = txt_edit.Text
					//        txt_edit.Text = ""

					grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = txt_edit.Text;
					MoveInGrid(KeyAscii);

				}
				else
				{
					if (grdFortune.CurrentColumnIndex == 2 || grdFortune.CurrentColumnIndex > 9)
					{
						//limit input to numbers only
						if (KeyAscii == 46)
						{ //. decimal

						}
						else
						{
							//UPGRADE_ISSUE: (1058) Assignment not supported: KeyAscii to a non-positive constant More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-1058
							KeyAscii = (KeyAscii != 8 && !(Conversion.Val(Strings.Chr(KeyAscii).ToString()) >= 0)) ? 0 : KeyAscii;
						}

						Application.DoEvents();
						grdFortune[grdFortune.CurrentRowIndex, grdFortune.CurrentColumnIndex].Value = $"{txt_edit.Text}{Strings.Chr(KeyAscii).ToString()}";

					}

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


		}


		private void txt_edit_Leave(Object eventSender, EventArgs eventArgs)
		{
			TurnOnTabStop();
			// grdFortune.Text = txt_edit.Text
			MoveInGrid(9);
			txt_edit.Visible = false;
			txt_edit.Text = "";
		}


		private void txt_EndRank_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{
				//limit input to numbers only
				//UPGRADE_ISSUE: (1058) Assignment not supported: KeyAscii to a non-positive constant More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-1058
				KeyAscii = (KeyAscii != 8 && !(Conversion.Val(Strings.Chr(KeyAscii).ToString()) >= 0)) ? 0 : KeyAscii;
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

		private void txt_Number_to_Display_Leave(Object eventSender, EventArgs eventArgs)
		{
			cmdStop.Visible = false;
			cmdExcel.Visible = false;
			ChkCompID.Visible = false;

			Application.DoEvents();
		}


		private void txt_prior_year_Leave(Object eventSender, EventArgs eventArgs)
		{
			cmdStop.Visible = false;
			cmdExcel.Visible = false;
			ChkCompID.Visible = false;

			Application.DoEvents();
		}



		private void txt_StartRank_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{
				//limit input to numbers only
				//UPGRADE_ISSUE: (1058) Assignment not supported: KeyAscii to a non-positive constant More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-1058
				KeyAscii = (KeyAscii != 8 && !(Conversion.Val(Strings.Chr(KeyAscii).ToString()) >= 0)) ? 0 : KeyAscii;
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