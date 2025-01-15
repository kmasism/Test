using Microsoft.VisualBasic;
using System;
using System.Data.Common;
using System.Drawing;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Gui.Controls;
using UpgradeHelpers.Helpers;

namespace JETNET_Homebase
{
	internal partial class frm_Fractional
		: System.Windows.Forms.Form
	{

		public frm_Fractional()
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


		private void frm_Fractional_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}

		int Prog_id = 0;
		int Comp_id = 0;
		int AC_ID = 0;
		int amod_id = 0;
		int journ_id = 0;
		int Select_ac_id = 0;
		int Select_comp_id = 0;
		int NumFleet = 0;
		int BaseFleet = 0;
		int HistFleet = 0;
		int NumWrittenOff = 0;

		bool RefreshAC = false;
		bool Stopped = false;
		int[] AC_List = null;
		int NumFleetError = 0;
		int NumRecs = 0;
		bool ProgramLoadInProgress = false;
		private string tmpStart = "";
		private int tmpHowLong = 0;


		private bool Analyze_AC(int an_ac_id, bool Historical)
		{
			bool result = false;
			int Buy = 0;
			int Sell = 0;
			int NumRecs = 0;
			ADORecordSetHelper ado_Test = new ADORecordSetHelper();
			 //good - default

			string Query = "Select ac_id,count(*) as ntrans, sum(case when cref_contact_type ='95' then 1 else 0 end) sell, sum(case when cref_contact_type ='96' then 1 else 0 end) buy ";
			Query = $"{Query}From aircraft WITH(NOLOCK) ";
			Query = $"{Query}inner join aircraft_reference WITH(NOLOCK) on ac_id=cref_ac_id and ac_journ_id=cref_journ_id ";
			Query = $"{Query}inner join journal WITH(NOLOCK) on cref_journ_id=journ_id ";
			Query = $"{Query}where ((journ_subcategory_code like 'WSPH%' and cref_contact_type ='95') or (journ_subcategory_code like 'SSPH%' and cref_contact_type ='95') or (journ_subcategory_code like 'WS%PH' and cref_contact_type='96' ) or (journ_subcategory_code like 'SS%PH' and cref_contact_type='96' ) or (journ_subcategory_code like 'WSPHIT' and cref_contact_type='96' ) or (journ_subcategory_code like 'WSITPH' and cref_contact_type='95' )) ";

			Query = $"{Query}and journ_id>0 ";
			Query = $"{Query}and ac_id = {AC_ID.ToString()} ";
			if (Chk_internal.CheckState == CheckState.Checked)
			{
				Query = $"{Query}and journ_internal_trans_flag='N' ";
			}

			Query = $"{Query}group by ac_id ";

			ado_Test.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
			if (!(ado_Test.BOF && ado_Test.EOF))
			{
				ado_Test.MoveLast();
				NumRecs = ado_Test.RecordCount;
				if (NumRecs == 0)
				{ //bad - eof/no records
					return true;
				}

				Buy = Convert.ToInt32(Conversion.Val($"{Convert.ToString(ado_Test["Buy"])}"));
				Sell = Convert.ToInt32(Conversion.Val($"{Convert.ToString(ado_Test["Sell"])}"));

				ado_Test.Close();

				ado_Test = null;

				NumRecs = Buy - Sell;

				if (Historical)
				{
					if ((NumRecs != 0) || (Buy == 0) || (Sell == 0))
					{ //bad - sells should equal buys, Should be at least 1 buy
						return true;
					}

				}
				else
				{
					//not history
					if ((NumRecs != 1) || (Buy == 0))
					{ //bad - should net to 1
						return true;
					}
				}
			}
			else
			{
				result = true; //bad - no records
			}


			return result;
		}

		//UPGRADE_NOTE: (7001) The following declaration (Check1_Click) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void Check1_Click()
		//{
			//
		//}

		private void chk_analyze_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{
			if (ProgramLoadInProgress)
			{
				return;
			}

			cmb_Models_SelectedIndexChanged(cmb_Models, new EventArgs());
		}

		private void chk_FindOtherWS_CheckStateChanged(Object eventSender, EventArgs eventArgs) => cmdRefresh_Click(cmdRefresh, new EventArgs());


		private void chk_history_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{
			if (ProgramLoadInProgress)
			{
				return;
			}

			cmdFracProgram_SelectedIndexChanged(cmdFracProgram, new EventArgs());
		}

		private void Chk_internal_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{
			if (ProgramLoadInProgress)
			{
				return;
			}

			cmdFracProgram_SelectedIndexChanged(cmdFracProgram, new EventArgs());
		}

		private void Chk_ShowTransactions_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{
			if (ProgramLoadInProgress)
			{
				return;
			}

			cmdRefresh_Click(cmdRefresh, new EventArgs());
		}

		private void chkDead_CheckStateChanged(Object eventSender, EventArgs eventArgs) => cmdFracProgram_SelectedIndexChanged(cmdFracProgram, new EventArgs());


		private void chkShowInactive_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{
			lblTrans.Text = "";

			if (chkShowInactive.CheckState == CheckState.Checked)
			{
				DetailTab.Visible = true;
				Application.DoEvents();
				Opt_notinTable[3].Checked = true;
				Application.DoEvents();
				SSTabHelper.SetSelectedIndex(DetailTab, 2);
				Application.DoEvents();
			}
		}

		private void cmb_Models_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{
			string Query = "";
			ADORecordSetHelper ado_Frac = new ADORecordSetHelper();
			int Other_Comp_id = 0;
			int CurRow = 0;
			string aMake = "";
			string aModel = "";
			string SerNo = "";
			string RegNO = "";
			bool IsHistoricalAC = false;

			if (ProgramLoadInProgress)
			{
				return;
			}

			FLeetAC.Text = " ";
			lblTrans.Text = "";
			NumFleetError = 0;
			Stopped = false;

			//FG_Transactions.Visible = False
			Select_ac_id = 0;
			NumFleet = 0;
			NumWrittenOff = 0;
			BaseFleet = 0;
			HistFleet = 0;
			SSTabHelper.SetSelectedIndex(DetailTab, 0);
			DetailTab.Visible = false;

			if ((Prog_id == 0) || (!RefreshAC))
			{
				return;
			}

			this.Cursor = Cursors.WaitCursor;
			NumFleet = 0;
			amod_id = cmb_Models.GetItemData(ListBoxHelper.GetSelectedIndex(cmb_Models));


			if (Prog_id == 44)
			{

				Query = "select distinct  amod_Make_name,amod_Model_name,ac_ser_no_full, ac_reg_no, ac_id ";
				Query = $"{Query}From aircraft_reference WITH(NOLOCK) ";
				Query = $"{Query}inner join aircraft WITH(NOLOCK) on cref_ac_id = ac_id and cref_journ_id=ac_journ_id ";
				Query = $"{Query}inner join aircraft_model WITH(NOLOCK) on ac_amod_id=amod_id ";
				Query = $"{Query}inner join journal WITH(NOLOCK) on cref_journ_id = journ_id ";
				Query = $"{Query}inner join company WITH(NOLOCK) on cref_comp_id = comp_id and cref_journ_id = comp_journ_id ";
				Query = $"{Query}left outer join company_aircraft_count WITH(NOLOCK) on cac_comp_id = comp_id ";
				Query = $"{Query}where ((journ_subcategory_code like 'WSPH%' and cref_contact_type ='95') or (journ_subcategory_code like 'SSPH%' and cref_contact_type ='95') or (journ_subcategory_code like 'WS%PH' and cref_contact_type='96' ) or (journ_subcategory_code like 'SS%PH' and cref_contact_type='96' ) or (journ_subcategory_code like 'WSPHIT' and cref_contact_type='96' ) or (journ_subcategory_code like 'WSITPH' and cref_contact_type='95' )) ";

				if (Chk_internal.CheckState == CheckState.Checked)
				{
					Query = $"{Query}and journ_internal_trans_flag = 'N' ";
				}

				if (Select_comp_id > 0)
				{
					Query = $"{Query}and cref_comp_id = {Select_comp_id.ToString()} ";
				}

				if (chk_history.CheckState == CheckState.Unchecked)
				{
					Query = $"{Query}and ac_journ_id=0 ";
				}

				if (amod_id > 0)
				{
					Query = $"{Query}and ac_amod_id = {amod_id.ToString()} ";
				}
				Query = $"{Query}and cref_comp_id not in (select distinct pgref_comp_id from program_reference) ";
				//order by amod_Make_name,amod_Model_name
				Query = $"{Query}order by amod_make_name, amod_model_name, ac_ser_no_full, ac_reg_no, ac_id ";


			}
			else
			{

				Query = "Select distinct amod_make_name, amod_model_name, ac_ser_no_full, ac_reg_no, ac_id ";

				Query = $"{Query}From aircraft WITH(NOLOCK) ";
				Query = $"{Query}inner join aircraft_reference WITH(NOLOCK) on ac_id=cref_ac_id and ac_journ_id=cref_journ_id ";
				Query = $"{Query}inner join program_reference WITH(NOLOCK) on pgref_comp_id=cref_comp_id ";
				Query = $"{Query}inner join aircraft_programs  WITH(NOLOCK) on pgref_prog_id=prog_id ";
				Query = $"{Query}inner join aircraft_model on ac_amod_id = amod_id ";

				Query = $"{Query}where prog_id = {Prog_id.ToString()} and cref_contact_type = '17' ";

				if (Select_comp_id > 0)
				{
					Query = $"{Query}and cref_comp_id = {Select_comp_id.ToString()} ";
				}

				if (chk_history.CheckState == CheckState.Unchecked)
				{
					Query = $"{Query}and ac_journ_id = 0 and ac_lifecycle_stage <> 4 ";
				}

				if (amod_id > 0)
				{
					Query = $"{Query}and ac_amod_id = {amod_id.ToString()} ";
				}

				Query = $"{Query}group by amod_make_name, amod_model_name, ac_ser_no_full, ac_reg_no, ac_id ";
				Query = $"{Query}order by amod_make_name, amod_model_name,ac_id, ac_ser_no_full, ac_reg_no ";
			}

			FG_ProgAircraft.Clear();
			FG_ProgAircraft.RowsCount = 2;
			FG_ProgAircraft.FixedRows = 1;
			FG_ProgAircraft.Visible = true;
			FG_ProgAircraft.CurrentRowIndex = 0;
			FG_ProgAircraft.CurrentColumnIndex = 0;
			FG_ProgAircraft[FG_ProgAircraft.CurrentRowIndex, FG_ProgAircraft.CurrentColumnIndex].Value = "Make";
			FG_ProgAircraft.CurrentColumnIndex = 1;
			FG_ProgAircraft[FG_ProgAircraft.CurrentRowIndex, FG_ProgAircraft.CurrentColumnIndex].Value = "Model";
			FG_ProgAircraft.CurrentColumnIndex = 2;
			FG_ProgAircraft[FG_ProgAircraft.CurrentRowIndex, FG_ProgAircraft.CurrentColumnIndex].Value = "Serial#";
			FG_ProgAircraft.CurrentColumnIndex = 3;
			FG_ProgAircraft[FG_ProgAircraft.CurrentRowIndex, FG_ProgAircraft.CurrentColumnIndex].Value = "Reg#";
			FG_ProgAircraft.CurrentColumnIndex = 4;
			FG_ProgAircraft[FG_ProgAircraft.CurrentRowIndex, FG_ProgAircraft.CurrentColumnIndex].Value = "AC_ID";
			FG_ProgAircraft.CurrentColumnIndex = 5;
			FG_ProgAircraft[FG_ProgAircraft.CurrentRowIndex, FG_ProgAircraft.CurrentColumnIndex].Value = "Hist";

			FG_ProgAircraft.SetColumnWidth(0, 100);
			FG_ProgAircraft.SetColumnWidth(1, 100);
			FG_ProgAircraft.SetColumnWidth(2, 67);
			FG_ProgAircraft.SetColumnWidth(3, 67);
			FG_ProgAircraft.SetColumnWidth(4, 67);
			FG_ProgAircraft.SetColumnWidth(5, 0);

			if (chk_history.CheckState == CheckState.Checked)
			{
				FG_ProgAircraft.SetColumnWidth(5, 33);
			}

			ado_Frac.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
			if (!(ado_Frac.BOF && ado_Frac.EOF))
			{
				ado_Frac.MoveLast();
				NumRecs = ado_Frac.RecordCount;
				ado_Frac.MoveFirst();

				CurRow = 0;

				while(!ado_Frac.EOF)
				{
					NumFleet++;
					AC_List = ArraysHelper.RedimPreserve(AC_List, new int[]{NumFleet + 1});
					AC_ID = Convert.ToInt32(Conversion.Val($"{Convert.ToString(ado_Frac["AC_ID"])}"));
					AC_List[NumFleet] = AC_ID;
					aMake = $"{Convert.ToString(ado_Frac["amod_make_name"])}";
					aModel = $"{Convert.ToString(ado_Frac["amod_model_name"])}";
					RegNO = $"{Convert.ToString(ado_Frac["ac_reg_no"])}";
					SerNo = $"{Convert.ToString(ado_Frac["ac_ser_no_full"])}";

					CurRow++;


					FG_ProgAircraft.RowsCount++;
					FG_ProgAircraft.CurrentRowIndex = CurRow;
					FG_ProgAircraft.CurrentColumnIndex = 0;
					FG_ProgAircraft[FG_ProgAircraft.CurrentRowIndex, FG_ProgAircraft.CurrentColumnIndex].Value = aMake;
					FG_ProgAircraft.CurrentColumnIndex = 1;
					FG_ProgAircraft[FG_ProgAircraft.CurrentRowIndex, FG_ProgAircraft.CurrentColumnIndex].Value = aModel;
					FG_ProgAircraft.CurrentColumnIndex = 2;
					FG_ProgAircraft[FG_ProgAircraft.CurrentRowIndex, FG_ProgAircraft.CurrentColumnIndex].Value = SerNo;
					FG_ProgAircraft.CurrentColumnIndex = 3;
					FG_ProgAircraft[FG_ProgAircraft.CurrentRowIndex, FG_ProgAircraft.CurrentColumnIndex].Value = RegNO;
					FG_ProgAircraft.CurrentColumnIndex = 4;
					FG_ProgAircraft[FG_ProgAircraft.CurrentRowIndex, FG_ProgAircraft.CurrentColumnIndex].Value = AC_ID;

					FG_ProgAircraft.CurrentColumnIndex = 5; //historical fractional ac? no or yes
					FG_ProgAircraft[FG_ProgAircraft.CurrentRowIndex, FG_ProgAircraft.CurrentColumnIndex].Value = "N";
					IsHistoricalAC = false;

					if (chk_history.CheckState == CheckState.Checked)
					{
						Query = $"select ac_journ_id from aircraft where ac_journ_id=0 and  ac_lifecycle_stage<>4 and ac_ownership_type='F' and ac_id={AC_ID.ToString()} ";
						if (!modAdminCommon.Exist(Query))
						{
							FG_ProgAircraft[FG_ProgAircraft.CurrentRowIndex, FG_ProgAircraft.CurrentColumnIndex].Value = "Y";
							HistFleet++;
							IsHistoricalAC = true;
						}

						Query = $"select ac_journ_id from aircraft where ac_journ_id=0 and  ac_lifecycle_stage =4 and ac_id={AC_ID.ToString()} ";
						if (modAdminCommon.Exist(Query))
						{
							NumWrittenOff++;
						}

					}


					FG_ProgAircraft.CellBackColor = SystemColors.Window;

					if (chk_analyze.CheckState == CheckState.Checked)
					{
						if (Analyze_AC(AC_ID, IsHistoricalAC))
						{
							FG_ProgAircraft.CurrentColumnIndex = 4;
							FG_ProgAircraft.CellBackColor = Color.Red;
							NumFleetError++;
							Application.DoEvents();
						}

					}

					lblStatus.Text = $"Aircraft - Record:{NumFleet.ToString()} of {NumRecs.ToString()}";

					Application.DoEvents();

					if (Stopped)
					{
						break;
					}


					ado_Frac.MoveNext();
				};
				ado_Frac.Close();
				BaseFleet = NumFleet;
				FLeetAC.Text = $" {NumFleet.ToString()} Aircraft in fleet ";
				FG_ProgAircraft.RowsCount--;

			}

			if (NumFleet == 0)
			{
				FLeetAC.Text = "No Aircraft currently in Fleet";
				FG_ProgAircraft.Visible = false;
			}
			else
			{
				FLeetAC.Text = $" {NumFleet.ToString()} Aircraft in fleet ";
				FG_ProgAircraft.Visible = true;
			}
			lblStatus.Text = "";

			FLeetAC.ForeColor = SystemColors.ControlText;
			if (NumFleetError > 0)
			{
				FLeetAC.ForeColor = Color.Red;
			}

			cmdRefresh_Click(cmdRefresh, new EventArgs());
			this.Cursor = CursorHelper.CursorDefault;

		}

		//UPGRADE_NOTE: (7001) The following declaration (cmb_Models2_Change) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void cmb_Models2_Change()
		//{
			//
		//}

		private void cmdAircraft_Click(Object eventSender, EventArgs eventArgs)
		{
			//load aircraft

			if (ProgramLoadInProgress)
			{
				return;
			}


			int HoldRow = FG_ProgAircraft.CurrentRowIndex;
			Stopped = false;
			if (FG_ProgAircraft.CurrentRowIndex > 0)
			{

				this.Cursor = Cursors.WaitCursor;
				FG_ProgAircraft.CurrentColumnIndex = 4;

				modAdminCommon.gbl_Aircraft_ID = Convert.ToInt32(Double.Parse(FG_ProgAircraft[FG_ProgAircraft.CurrentRowIndex, FG_ProgAircraft.CurrentColumnIndex].FormattedValue.ToString()));
				modAdminCommon.gbl_Aircraft_Journal_ID = 0;

				frm_aircraft.DefInstance.Form_Initialize();
				frm_aircraft.DefInstance.StartForm = modGlobalVars.tStart_Form;
				frm_aircraft.DefInstance.Reference_Aircraft_ID = modAdminCommon.gbl_Aircraft_ID;
				frm_aircraft.DefInstance.Reference_Journal_ID = modAdminCommon.gbl_Aircraft_Journal_ID;
				frm_aircraft.DefInstance.Reference_Company_ID = 0;
				frm_aircraft.DefInstance.Show();
				//UPGRADE_WARNING: (2065) Form method frm_aircraft.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
				frm_aircraft.DefInstance.BringToFront();
				//UPGRADE_WARNING: (2065) Form event Form.Activated has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
				frm_aircraft.DefInstance.Form_Activated(frm_aircraft.DefInstance, new EventArgs());

				FG_ProgAircraft.RowSel = HoldRow;
				FG_ProgAircraft.ColSel = 1;

			} // If FG_ProgAircraft.Row > 0 Then

			this.Cursor = CursorHelper.CursorDefault;

		}

		private void cmdFracProgram_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{
			string Query = "";
			ADORecordSetHelper ado_Frac = new ADORecordSetHelper();
			int nRow = 0;
			int pgref_id = 0;
			string aMake = "";
			string aModel = "";

			this.Cursor = Cursors.WaitCursor;
			ProgramLoadInProgress = true;
			Stopped = false;
			Select_ac_id = 0;
			Select_comp_id = 0;
			SSTabHelper.SetSelectedIndex(DetailTab, 0);
			NumRecs = 0;
			int NCount = 0;
			lblStatus.Text = "";
			lblModels.Text = "";
			lblTrans.Text = "";
			PMPHCompanies.Text = "";
			FLeetAC.Text = "";
			RefreshAC = false;
			AC_List = new int[1];
			Application.DoEvents();

			FG_ProgCompany.Visible = false;
			Prog_id = cmdFracProgram.GetItemData(ListBoxHelper.GetSelectedIndex(cmdFracProgram));
			//Lbl_prog.Caption = Prog_id
			LblOther.Visible = false;
			this.Cursor = Cursors.WaitCursor;
			Application.DoEvents();

			GrdSubscribers.Clear();
			GrdSubscribers.RowsCount = 2;

			FG_Transactions.Clear();
			FG_Transactions.RowsCount = 2;

			FG_ProgAircraft.Clear();
			FG_ProgAircraft.RowsCount = 2;

			FG_ProgCompany.Clear();
			FG_ProgCompany.RowsCount = 2;

			GrdSubscribers.Clear();
			GrdSubscribers.RowsCount = 2;

			Application.DoEvents();

			//>>>> build model list <<<<
			if (Prog_id == 44)
			{
				LblOther.Visible = true;
				Application.DoEvents();
				Query = "select distinct  amod_id,amod_Make_name,amod_Model_name From aircraft_reference WITH(NOLOCK)  ";
				Query = $"{Query}inner join aircraft as a WITH(NOLOCK) on cref_ac_id = a.ac_id and cref_journ_id=a.ac_journ_id ";
				Query = $"{Query}inner join aircraft as a2 WITH(NOLOCK) on cref_ac_id = a2.ac_id and a2.ac_journ_id=0 ";
				Query = $"{Query}inner join aircraft_model WITH(NOLOCK)  on a2.ac_amod_id=amod_id ";
				Query = $"{Query}inner join journal WITH(NOLOCK)  on cref_journ_id = journ_id ";
				Query = $"{Query}inner join company WITH(NOLOCK)  on cref_comp_id = comp_id and cref_journ_id = comp_journ_id ";
				Query = $"{Query}left outer join company_aircraft_count WITH(NOLOCK) on cac_comp_id = comp_id ";
				//Query = Query & "where ((journ_subcategory_code like 'WSPH%' and cref_contact_type ='95') or (journ_subcategory_code like 'WS%PH' and cref_contact_type='96' )) "
				Query = $"{Query}where ((journ_subcategory_code like 'WSPH%' and cref_contact_type ='95') or (journ_subcategory_code like 'SSPH%' and cref_contact_type ='95') or (journ_subcategory_code like 'WS%PH' and cref_contact_type='96' ) or (journ_subcategory_code like 'SS%PH' and cref_contact_type='96' ) or (journ_subcategory_code like 'WSPHIT' and cref_contact_type='96' ) or (journ_subcategory_code like 'WSITPH' and cref_contact_type='95' )) ";

				if (Chk_internal.CheckState == CheckState.Checked)
				{
					Query = $"{Query}and journ_internal_trans_flag='N' ";
				}

				Query = $"{Query}and cref_comp_id not in (select distinct pgref_comp_id from program_reference WITH(NOLOCK) ) ";
				Query = $"{Query}order by amod_Make_name,amod_Model_name ";
				chk_history.CheckState = CheckState.Unchecked;

			}
			else
			{

				Query = "Select distinct amod_id,amod_Make_name,amod_Model_name ";
				Query = $"{Query}From aircraft  WITH(NOLOCK) ";
				Query = $"{Query}inner join aircraft_model WITH(NOLOCK) on amod_id=ac_amod_id ";
				Query = $"{Query}inner join aircraft_reference WITH(NOLOCK) on ac_id=cref_ac_id and ac_journ_id=cref_journ_id ";
				Query = $"{Query}inner join program_reference WITH(NOLOCK) on pgref_comp_id=cref_comp_id ";
				Query = $"{Query}inner join journal WITH(NOLOCK)  on cref_journ_id = journ_id ";
				Query = $"{Query}inner join aircraft_programs  WITH(NOLOCK) on pgref_prog_id=prog_id ";
				Query = $"{Query}where prog_id= {Prog_id.ToString()} ";

				if (chkDead.CheckState == CheckState.Unchecked)
				{
					Query = $"{Query}and cref_contact_type in('17','97','69','70','18','96','95','00','08') ";
					Query = $"{Query} and amod_id in(Select distinct amod_id ";
					Query = $"{Query}From aircraft WITH(NOLOCK) ";
					Query = $"{Query}inner join aircraft_reference WITH(NOLOCK) on ac_id=cref_ac_id and ac_journ_id=cref_journ_id ";
					Query = $"{Query}inner join program_reference WITH(NOLOCK) on pgref_comp_id=cref_comp_id ";
					Query = $"{Query}inner join aircraft_programs  WITH(NOLOCK) on pgref_prog_id=prog_id ";
					Query = $"{Query}inner join aircraft_model on ac_amod_id = amod_id ";
					Query = $"{Query}where prog_id = {Prog_id.ToString()} and cref_contact_type = '17' )";

				}

				if (chk_history.CheckState == CheckState.Unchecked)
				{
					Query = $"{Query}and a.ac_journ_id=0 ";
				}

				Query = $"{Query}Order by amod_Make_name,amod_Model_name ";
			}

			this.Cursor = Cursors.WaitCursor;
			Application.DoEvents();

			int nModels = 0;
			cmb_Models.Items.Clear();
			cmb_Models.AddItem("None Selected");
			cmb_Models.SetItemData(cmb_Models.GetNewIndex(), 0);
			ado_Frac.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
			if (!(ado_Frac.BOF && ado_Frac.EOF))
			{
				ado_Frac.MoveLast();
				NumRecs = ado_Frac.RecordCount;
				ado_Frac.MoveFirst();

				while(!ado_Frac.EOF)
				{
					nModels++;
					amod_id = Convert.ToInt32(Conversion.Val($"{Convert.ToString(ado_Frac["amod_id"])}"));
					aMake = $"{Convert.ToString(ado_Frac["amod_make_name"])}";
					aModel = $"{Convert.ToString(ado_Frac["amod_model_name"])}";
					cmb_Models.AddItem($"{aMake} {aModel}");
					cmb_Models.SetItemData(cmb_Models.GetNewIndex(), amod_id);

					lblStatus.Text = $"Models - Record:{nModels.ToString()} of {NumRecs.ToString()}";
					Application.DoEvents();

					if (Stopped)
					{
						break;
					}
					ado_Frac.MoveNext();
				};

				ado_Frac.Close();
			}
			ListBoxHelper.SetSelectedIndex(cmb_Models, 0);
			lblStatus.Text = "";
			//cmb_Models.Refresh
			lblModels.Text = $" {nModels.ToString()} Models";
			this.Cursor = Cursors.WaitCursor;

			ado_Frac = null;
			Application.DoEvents();

			//>>>>> Build Company List <<<<<<<

			FG_ProgCompany.Visible = true;
			FG_ProgCompany.RowsCount = 2;
			FG_ProgCompany.FixedRows = 1;
			FG_ProgCompany.CurrentRowIndex = 0;
			FG_ProgCompany.CurrentColumnIndex = 0;
			FG_ProgCompany[FG_ProgCompany.CurrentRowIndex, FG_ProgCompany.CurrentColumnIndex].Value = "Company Name";
			FG_ProgCompany.CurrentColumnIndex = 1;
			FG_ProgCompany[FG_ProgCompany.CurrentRowIndex, FG_ProgCompany.CurrentColumnIndex].Value = "Comp_id";
			FG_ProgCompany.CurrentColumnIndex = 2;
			FG_ProgCompany[FG_ProgCompany.CurrentRowIndex, FG_ProgCompany.CurrentColumnIndex].Value = "# Refs";

			FG_ProgCompany.SetColumnWidth(0, 133);
			FG_ProgCompany.SetColumnWidth(1, 67);
			FG_ProgCompany.SetColumnWidth(2, 67);
			FG_ProgCompany.SetColumnWidth(3, 0);
			Application.DoEvents();

			if (Prog_id == 44)
			{

				Query = "select distinct  comp_id,comp_name, cac_total_referenced from aircraft_reference WITH(NOLOCK) ";
				Query = $"{Query}inner join journal WITH(NOLOCK) on cref_journ_id = journ_id ";
				Query = $"{Query}inner join company WITH(NOLOCK) on cref_comp_id = comp_id and cref_journ_id = comp_journ_id ";
				Query = $"{Query}left outer join company_aircraft_count WITH(NOLOCK) on cac_comp_id = comp_id ";
				// Query = Query & "where ((journ_subcategory_code like 'WSPH%' and cref_contact_type ='95') or (journ_subcategory_code like 'WS%PH' and cref_contact_type='96' )) "
				Query = $"{Query}where ((journ_subcategory_code like 'WSPH%' and cref_contact_type ='95') or (journ_subcategory_code like 'SSPH%' and cref_contact_type ='95') or (journ_subcategory_code like 'WS%PH' and cref_contact_type='96' ) or (journ_subcategory_code like 'SS%PH' and cref_contact_type='96' ) or (journ_subcategory_code like 'WSPHIT' and cref_contact_type='96' ) or (journ_subcategory_code like 'WSITPH' and cref_contact_type='95' )) ";

				if (Chk_internal.CheckState == CheckState.Checked)
				{
					Query = $"{Query}and journ_internal_trans_flag='N' ";
				}
				Query = $"{Query}and cref_comp_id not in (select distinct pgref_comp_id from program_reference) ";
				Query = $"{Query}order by comp_name,  comp_id ";

			}
			else
			{
				Query = "Select distinct comp_id,comp_name,cac_total_referenced,pgref_id from program_reference WITH(NOLOCK)  left outer join company WITH(NOLOCK)  on comp_id = pgref_comp_id ";
				Query = $"{Query}left outer join company_aircraft_count WITH(NOLOCK) on cac_comp_id = comp_id ";
				Query = $"{Query}where pgref_prog_id = {Prog_id.ToString()}  ORDER BY comp_name ";
			}

			int NCompanies = 0;
			int NRelatedAC = 0;
			int NumRefs = 0;
			int old_pgref_id = -1;
			this.Cursor = Cursors.WaitCursor;

			ado_Frac.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
			old_pgref_id = 0;
			if (!(ado_Frac.BOF && ado_Frac.EOF))
			{
				ado_Frac.MoveLast();
				NumRecs = ado_Frac.RecordCount;
				ado_Frac.MoveFirst();

				nRow = 1;
				FG_ProgCompany.CurrentRowIndex = nRow;

				while(!ado_Frac.EOF)
				{
					if (Prog_id == 44)
					{
						pgref_id = nRow + 1;
					}
					else
					{
						pgref_id = Convert.ToInt32(Conversion.Val($"{Convert.ToString(ado_Frac["pgref_id"])}"));
					}
					if (pgref_id != old_pgref_id)
					{
						NCompanies++;
						FG_ProgCompany.CurrentColumnIndex = 0;
						FG_ProgCompany[FG_ProgCompany.CurrentRowIndex, FG_ProgCompany.CurrentColumnIndex].Value = ($"{Convert.ToString(ado_Frac["comp_name"])} ").Trim();
						FG_ProgCompany.ColAlignment[0] = DataGridViewContentAlignment.TopLeft;
						FG_ProgCompany.CurrentColumnIndex = 1;
						FG_ProgCompany[FG_ProgCompany.CurrentRowIndex, FG_ProgCompany.CurrentColumnIndex].Value = ($"{Convert.ToString(ado_Frac["Comp_id"])} ").Trim();
						FG_ProgCompany.CurrentColumnIndex = 2;
						FG_ProgCompany[FG_ProgCompany.CurrentRowIndex, FG_ProgCompany.CurrentColumnIndex].Value = ($"{Convert.ToString(ado_Frac["cac_total_referenced"])} ").Trim();
						NumRefs = Convert.ToInt32(Conversion.Val($"{Convert.ToString(ado_Frac["cac_total_referenced"])} "));
						NRelatedAC += NumRefs;
						if (Prog_id == 44)
						{
						}
						else
						{
							FG_ProgCompany.CurrentColumnIndex = 3;
							FG_ProgCompany[FG_ProgCompany.CurrentRowIndex, FG_ProgCompany.CurrentColumnIndex].Value = ($"{Convert.ToString(ado_Frac["pgref_id"])} ").Trim();
						}
						nRow++;
						FG_ProgCompany.RowsCount = nRow + 1;
						FG_ProgCompany.CurrentRowIndex = nRow;
					}
					old_pgref_id = pgref_id;

					lblStatus.Text = $"Companies - Record:{NCompanies.ToString()} of {NumRecs.ToString()}";

					Application.DoEvents();
					if (Stopped)
					{
						break;
					}

					ado_Frac.MoveNext();

				};
			}
			lblStatus.Text = "";
			Application.DoEvents();

			ado_Frac.Close();
			FG_ProgCompany.RowsCount--;
			//FG_ProgCompany.Refresh

			this.Cursor = Cursors.WaitCursor;

			PMPHCompanies.Text = $" {NCompanies.ToString()} Companies with {NRelatedAC.ToString()} Related AC";
			Application.DoEvents();
			RefreshAC = true;
			Application.DoEvents();
			cmb_Models_SelectedIndexChanged(cmb_Models, new EventArgs());
			Application.DoEvents();

			ProgramLoadInProgress = false;
			this.Cursor = CursorHelper.CursorDefault;

		}


		//UPGRADE_NOTE: (7001) The following declaration (cmdFracProgram2_Change) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void cmdFracProgram2_Change()
		//{
			//
		//}

		private void cmdRefresh_Click(Object eventSender, EventArgs eventArgs)
		{
			string Query = "";
			ADORecordSetHelper ado_Frac = new ADORecordSetHelper();
			int CurRow = 0;
			int journ_id = 0;
			string jDate = "";
			string jSubject = "";
			string jCode = "";
			string BuySell = "";
			string ContactType = "";
			int NTrans = 0;
			int OtherComp_id = 0;
			string CName = "";
			string OtherContactType = "";
			double nBuy = 0;
			double nSell = 0;
			double NetAdds = 0;
			double OwnerPct = 0;
			bool FoundAC = false;
			int local_amod_id = 0;
			int[] gac_list = null;

			lblTrans.Text = "";
			Stopped = false;
			gac_list = new int[1];
			gac_list[0] = 0;
			double DiffFromFleet = 0;
			int old_ac_id = 0;
			int NetSales = 0;

			if (Chk_ShowTransactions.CheckState == CheckState.Unchecked)
			{
				return;
			}

			int ErrCount = 0;
			Application.DoEvents();
			if (Prog_id == 0)
			{
				return;
			}
			this.Cursor = Cursors.WaitCursor;
			DetailTab.Visible = true;

			FG_Transactions.Clear();
			FG_Transactions.RowsCount = 2;
			FG_Transactions.FixedRows = 1;
			FG_Transactions.Visible = true;
			FG_Transactions.CurrentColumnIndex = 0;
			FG_Transactions.CurrentRowIndex = 0;
			FG_Transactions[FG_Transactions.CurrentRowIndex, FG_Transactions.CurrentColumnIndex].Value = "Date";
			FG_Transactions.CurrentColumnIndex = 1;
			FG_Transactions[FG_Transactions.CurrentRowIndex, FG_Transactions.CurrentColumnIndex].Value = "Code";
			FG_Transactions.CurrentColumnIndex = 2;
			FG_Transactions[FG_Transactions.CurrentRowIndex, FG_Transactions.CurrentColumnIndex].Value = "Subject";
			FG_Transactions.CurrentColumnIndex = 3;
			FG_Transactions[FG_Transactions.CurrentRowIndex, FG_Transactions.CurrentColumnIndex].Value = "PH Buy/Sell";
			FG_Transactions.CurrentColumnIndex = 4;
			FG_Transactions[FG_Transactions.CurrentRowIndex, FG_Transactions.CurrentColumnIndex].Value = "AC_ID";
			FG_Transactions.CurrentColumnIndex = 5;
			FG_Transactions[FG_Transactions.CurrentRowIndex, FG_Transactions.CurrentColumnIndex].Value = "Journal_id";
			FG_Transactions.CurrentColumnIndex = 6;
			FG_Transactions[FG_Transactions.CurrentRowIndex, FG_Transactions.CurrentColumnIndex].Value = "Comp_id";

			FG_Transactions.SetColumnWidth(0, 73);
			FG_Transactions.SetColumnWidth(1, 67);
			FG_Transactions.SetColumnWidth(2, 333);
			FG_Transactions.SetColumnWidth(3, 73);
			FG_Transactions.SetColumnWidth(4, 67);
			FG_Transactions.SetColumnWidth(5, 67);
			FG_Transactions.SetColumnWidth(6, 67);

			if (TranPrefix[0].Checked)
			{ //ws
				if (Prog_id == 44)
				{

					if (Select_ac_id > 0)
					{
						Query = "select distinct journ_date,journ_subcategory_code, journ_subject,journ_id,ac_id, cref_contact_type,cref_comp_id,cref_owner_percent,amod_id ";
						Query = $"{Query}From aircraft_reference ";
						Query = $"{Query}inner join aircraft WITH(NOLOCK) on cref_ac_id = ac_id and cref_journ_id=ac_journ_id ";
						Query = $"{Query}inner join aircraft_model WITH(NOLOCK) on ac_amod_id=amod_id ";
						Query = $"{Query}inner join journal WITH(NOLOCK) on cref_journ_id = journ_id ";
						Query = $"{Query}inner join company WITH(NOLOCK) on cref_comp_id = comp_id and cref_journ_id = comp_journ_id ";
						Query = $"{Query}left outer join company_aircraft_count WITH(NOLOCK) on cac_comp_id = comp_id ";
						Query = $"{Query}where journ_id>0 ";

						if (Chk_IncludeSS.CheckState == CheckState.Checked)
						{
							//Query = Query & "and ((journ_subcategory_code like 'WSPH%' and cref_contact_type ='95') or (journ_subcategory_code like 'SSPH%' and cref_contact_type ='95') or (journ_subcategory_code like 'WS%PH' and cref_contact_type='96' ) or (journ_subcategory_code like 'SS%PH' and cref_contact_type='96' ) or (journ_subcategory_code like 'WSPHIT' and cref_contact_type='96' ) or (journ_subcategory_code like 'WSITPH' and cref_contact_type='95' )) "
							Query = $"{Query} and (journ_subcategory_code like 'WSPH%' or journ_subcategory_code like 'WS%PH' ";
							Query = $"{Query} or  journ_subcategory_code like 'SSPH%' or journ_subcategory_code like 'SS%PH'  ";
							Query = $"{Query} or (journ_subcategory_code like 'WO%' and cref_contact_type ='17') ";
							Query = $"{Query}and (cref_contact_type ='95' or cref_contact_type ='96') ";

						}
						else
						{
							Query = $"{Query}and ((journ_subcategory_code like 'WSPH%' and cref_contact_type ='95') or (journ_subcategory_code like 'WS%PH' and cref_contact_type='96' )  or (journ_subcategory_code like 'WSPHIT' and cref_contact_type='96' ) or (journ_subcategory_code like 'WSITPH' and cref_contact_type='95' )   ";
							Query = $"{Query} or (journ_subcategory_code like 'WO%' and cref_contact_type ='17')  ) ";
						}

						Query = $"{Query}and cref_comp_id not in (select distinct pgref_comp_id from program_reference) ";

						Query = $"{Query} and ac_id={Select_ac_id.ToString()} ";

					}
					else
					{
						Query = "select distinct journ_date,journ_subcategory_code, journ_subject,journ_id,ac_id, cref_contact_type,cref_comp_id ,cref_owner_percent, amod_id ";
						Query = $"{Query}From aircraft_reference ";
						Query = $"{Query}inner join aircraft WITH(NOLOCK) on cref_ac_id = ac_id and cref_journ_id=ac_journ_id ";
						Query = $"{Query}inner join aircraft_model WITH(NOLOCK) on ac_amod_id=amod_id ";
						Query = $"{Query}inner join journal WITH(NOLOCK) on cref_journ_id = journ_id ";
						Query = $"{Query}inner join company WITH(NOLOCK) on cref_comp_id = comp_id and cref_journ_id = comp_journ_id ";
						Query = $"{Query}left outer join company_aircraft_count WITH(NOLOCK) on cac_comp_id = comp_id ";
						Query = $"{Query}where ";
						//Query = Query & "and ((journ_subcategory_code like 'WSPH%' and cref_contact_type ='95') or (journ_subcategory_code like 'WS%PH' and cref_contact_type='96' )) "

						if (Chk_IncludeSS.CheckState == CheckState.Checked)
						{
							Query = $"{Query} ((journ_subcategory_code like 'WSPH%' and cref_contact_type ='95') or (journ_subcategory_code like 'WS%PH' and cref_contact_type='96' ) or (journ_subcategory_code like 'SSPH%' and cref_contact_type ='95') or (journ_subcategory_code like 'SS%PH' and cref_contact_type='96' ) or (journ_subcategory_code like 'WSPHIT' and cref_contact_type='96' ) or (journ_subcategory_code like 'WSITPH' and cref_contact_type='95' ) ";
							Query = $"{Query} or (journ_subcategory_code like 'WO%' and cref_contact_type ='17')  ) ";
						}
						else
						{
							Query = $"{Query}and ((journ_subcategory_code like 'WSPH%' and cref_contact_type ='95') or (journ_subcategory_code like 'WS%PH' and cref_contact_type='96' ) or (journ_subcategory_code like 'WSPHIT' and cref_contact_type='96' ) or (journ_subcategory_code like 'WSITPH' and cref_contact_type='95' ) ";
							Query = $"{Query} or (journ_subcategory_code like 'WO%' and cref_contact_type ='17')  ) ";

						}

						Query = $"{Query}and cref_comp_id not in (select distinct pgref_comp_id from program_reference) ";
						//order by amod_Make_name,amod_Model_name

						if (Select_comp_id > 0)
						{
							Query = $"{Query}and cref_comp_id = {Select_comp_id.ToString()} ";
						}

						if (amod_id > 0)
						{
							Query = $"{Query}and amod_id= {amod_id.ToString()}  ";
						}


					}
					//Query = Query & "order by journ_date,journ_subcategory_code,ac_id "
					Query = $"{Query}order by ac_id,journ_date,journ_subcategory_code ";

				}
				else
				{
					//not 44
					if (Select_ac_id > 0)
					{
						Query = "Select journ_date,journ_subcategory_code, journ_subject,journ_id,ac_id, cref_contact_type,cref_comp_id,cref_owner_percent,amod_id ";
						Query = $"{Query}from aircraft WITH(NOLOCK) ";
						Query = $"{Query}inner join aircraft_model WITH(NOLOCK) on ac_amod_id=amod_id ";
						Query = $"{Query}inner join aircraft_reference WITH(NOLOCK) on ac_id=cref_ac_id and ac_journ_id=cref_journ_id ";
						Query = $"{Query}inner join journal WITH(NOLOCK) on cref_journ_id=journ_id ";

						if (Chk_IncludeSS.CheckState == CheckState.Checked)
						{
							Query = $"{Query}where ((journ_subcategory_code like 'WSPH%' and cref_contact_type ='95') or (journ_subcategory_code like 'WS%PH' and cref_contact_type='96' ) or (journ_subcategory_code like 'WSPHIT' and cref_contact_type='96' ) or (journ_subcategory_code like 'WSITPH' and cref_contact_type='95' ) or (journ_subcategory_code like 'SSPH%' and cref_contact_type ='95') or (journ_subcategory_code like 'SS%PH' and cref_contact_type='96' ) ";
							Query = $"{Query} or (journ_subcategory_code like 'WO%' and cref_contact_type ='17')  ) ";

						}
						else
						{
							Query = $"{Query}where ((journ_subcategory_code like 'WSPH%' and cref_contact_type ='95') or (journ_subcategory_code like 'WS%PH' and cref_contact_type='96' ) or  (journ_subcategory_code like 'WSPHIT' and cref_contact_type='96' ) or (journ_subcategory_code like 'WSITPH' and cref_contact_type='95' ) ";
							Query = $"{Query} or (journ_subcategory_code like 'WO%' and cref_contact_type ='17')  ) ";

						}


						Query = $"{Query}and amod_customer_flag = 'Y'  ";


						if (Select_ac_id > 0)
						{
							Query = $"{Query}and ac_id={Select_ac_id.ToString()} ";
						}


					}
					else
					{
						if (chk_FindOtherWS.CheckState == CheckState.Checked)
						{
							Query = "Select journ_date,journ_subcategory_code, journ_subject,journ_id,ac_id, cref_contact_type,cref_comp_id,cref_owner_percent,amod_id  ";
							Query = $"{Query}from aircraft WITH(NOLOCK) ";
							Query = $"{Query}inner join aircraft_model WITH(NOLOCK) on ac_amod_id=amod_id ";
							Query = $"{Query}inner join aircraft_reference WITH(NOLOCK) on ac_id=cref_ac_id and ac_journ_id=cref_journ_id ";
							Query = $"{Query}inner join program_reference WITH(NOLOCK) on pgref_comp_id=cref_comp_id ";
							Query = $"{Query}inner join aircraft_programs  WITH(NOLOCK) on pgref_prog_id=prog_id ";
							Query = $"{Query}inner join journal WITH(NOLOCK) on cref_journ_id=journ_id ";
							//Query = Query & "where ((journ_subcategory_code like 'WSPH%' and cref_contact_type ='95') or (journ_subcategory_code like 'WS%PH' and cref_contact_type='96' )) "
							if (Chk_IncludeSS.CheckState == CheckState.Checked)
							{
								Query = $"{Query}where ((journ_subcategory_code like 'WSPH%' and cref_contact_type ='95') or (journ_subcategory_code like 'WS%PH' and cref_contact_type='96' ) or (journ_subcategory_code like 'WSPHIT' and cref_contact_type='96' ) or (journ_subcategory_code like 'WSITPH' and cref_contact_type='95' ) or (journ_subcategory_code like 'SSPH%' and cref_contact_type ='95') or (journ_subcategory_code like 'SS%PH' and cref_contact_type='96' ) ";
								Query = $"{Query} or (journ_subcategory_code like 'WO%' and cref_contact_type ='17')  ) ";
							}
							else
							{
								Query = $"{Query}where ((journ_subcategory_code like 'WSPH%' and cref_contact_type ='95') or (journ_subcategory_code like 'WS%PH' and cref_contact_type='96' ) or (journ_subcategory_code like 'WSPHIT' and cref_contact_type='96' ) or (journ_subcategory_code like 'WSITPH' and cref_contact_type='95' ) ";
								Query = $"{Query} or (journ_subcategory_code like 'WO%' and cref_contact_type ='17')  ) ";
							}

							Query = $"{Query}and amod_customer_flag = 'Y' ";

							if (Select_comp_id > 0)
							{
								Query = $"{Query}and cref_comp_id = {Select_comp_id.ToString()} ";
							}

							//Query = Query & "and journ_id > 0  "

							Query = $"{Query}and prog_id = {Prog_id.ToString()} ";

							if (amod_id > 0)
							{
								Query = $"{Query}and amod_id= {amod_id.ToString()}  ";
							}

						}
						else
						{
							Query = "Select journ_date,journ_subcategory_code, journ_subject , journ_id, ac_id, cref_contact_type, cref_comp_id,cref_owner_percent ,amod_id ";
							Query = $"{Query}From aircraft WITH(NOLOCK) ";
							Query = $"{Query}inner join aircraft_model WITH(NOLOCK) on ac_amod_id=amod_id ";
							Query = $"{Query}inner join aircraft_reference WITH(NOLOCK) on ac_id=cref_ac_id and ac_journ_id=cref_journ_id ";
							Query = $"{Query}inner join program_reference WITH(NOLOCK) on pgref_comp_id=cref_comp_id ";
							Query = $"{Query}inner join aircraft_programs  WITH(NOLOCK) on pgref_prog_id=prog_id ";
							Query = $"{Query}inner join journal WITH(NOLOCK) on cref_journ_id=journ_id ";
							Query = $"{Query}where  amod_customer_flag = 'Y' ";


							//Query = Query & "and ((journ_subcategory_code like 'WSPH%' and cref_contact_type ='95') or (journ_subcategory_code like 'WS%PH' and cref_contact_type='96' )) "
							if (Chk_IncludeSS.CheckState == CheckState.Checked)
							{
								Query = $"{Query}and ((journ_subcategory_code like 'WSPH%' and cref_contact_type ='95') or (journ_subcategory_code like 'WS%PH' and cref_contact_type='96' ) or (journ_subcategory_code like 'WSPHIT' and cref_contact_type='96' ) or (journ_subcategory_code like 'WSITPH' and cref_contact_type='95' ) or (journ_subcategory_code like 'SSPH%' and cref_contact_type ='95') or (journ_subcategory_code like 'SS%PH' and cref_contact_type='96' ) ";
								Query = $"{Query} or (journ_subcategory_code like 'WO%' and cref_contact_type ='17')  ) ";
							}
							else
							{
								Query = $"{Query}and ((journ_subcategory_code like 'WSPH%' and cref_contact_type ='95') or (journ_subcategory_code like 'WS%PH' and cref_contact_type='96' ) or (journ_subcategory_code like 'WSPHIT' and cref_contact_type='96' ) or (journ_subcategory_code like 'WSITPH' and cref_contact_type='95' ) ";
								Query = $"{Query} or (journ_subcategory_code like 'WO%' and cref_contact_type ='17')  ) ";
							}


							Query = $"{Query}and  prog_id = {Prog_id.ToString()} ";

							if (amod_id > 0)
							{
								Query = $"{Query}and amod_id= {amod_id.ToString()}  ";
							}

							if (Select_comp_id > 0)
							{
								Query = $"{Query}and cref_comp_id = {Select_comp_id.ToString()} ";
							}
							//Query = Query & ") "

						}
					}
					// Query = Query & "order by journ_date,journ_subcategory_code ,ac_id "
					Query = $"{Query}order by ac_id,journ_date,journ_subcategory_code ";

				}

			}
			else if (TranPrefix[1].Checked)
			{  //fs
				if (Prog_id == 44)
				{
					if (Select_ac_id > 0)
					{
						Query = "Select journ_date,journ_subcategory_code, journ_subject, journ_id,ac_id,cref_contact_type,cref_comp_id,amod_id,cref_owner_percent  ";
						Query = $"{Query}from aircraft_reference inner join journal on cref_journ_id = journ_id ";
						Query = $"{Query}inner join aircraft on ac_id=cref_ac_id and ac_journ_id=cref_journ_id ";
						Query = $"{Query}inner join aircraft_model on ac_amod_id=amod_id ";
						Query = $"{Query}inner join company on cref_comp_id = comp_id and cref_journ_id = comp_journ_id ";
						Query = $"{Query}where ((journ_subcategory_code like 'FSPH%' and cref_contact_type ='69') or (journ_subcategory_code like 'FS%PH'  and cref_contact_type ='70' ) ) ";

						Query = $"{Query}and cref_comp_id not in (select distinct pshr_comp_id from program_shareholders) ";
						Query = $"{Query}and journ_id>0  ";


						if (Select_ac_id > 0)
						{
							Query = $"{Query} and ac_id={Select_ac_id.ToString()} ";
						}

					}
					else
					{
						Query = "Select journ_date,journ_subcategory_code, journ_subject, journ_id,ac_id,cref_contact_type,cref_comp_id,amod_id ,cref_owner_percent ";
						Query = $"{Query}from aircraft_reference inner join journal on cref_journ_id = journ_id ";
						Query = $"{Query}inner join aircraft on ac_id=cref_ac_id and ac_journ_id=cref_journ_id ";
						Query = $"{Query}inner join aircraft_model on ac_amod_id=amod_id ";
						Query = $"{Query}inner join company on cref_comp_id = comp_id and cref_journ_id = comp_journ_id ";
						Query = $"{Query}where ((journ_subcategory_code like 'FSPH%' and cref_contact_type ='69') or (journ_subcategory_code like 'FS%PH'  and cref_contact_type ='70' ) ) ";
						//            If Chk_internal.Value = vbChecked Then
						//               Query = Query & "and journ_internal_trans_flag='N' "
						//            End If
						Query = $"{Query}and cref_comp_id not in (select distinct pshr_comp_id from program_shareholders) ";
						Query = $"{Query}and journ_id>0  ";
						//         If Select_ac_id > 0 Then
						//            Query = Query & " and ac_id=" & Select_ac_id & " "
						//         End If
						if (Select_comp_id > 0)
						{
							Query = $"{Query}and cref_comp_id = {Select_comp_id.ToString()} ";
						}

						if (amod_id > 0)
						{
							Query = $"{Query}and amod_id= {amod_id.ToString()}  ";
						}
					}
					//Query = Query & "order by journ_date,journ_subcategory_code,ac_id "
					Query = $"{Query}order by ac_id,journ_date,journ_subcategory_code ";

				}
				else
				{
					if (Select_ac_id > 0)
					{
						Query = "Select journ_date,journ_subcategory_code, journ_subject, journ_id,ac_id,cref_contact_type,cref_comp_id ,amod_id,cref_owner_percent ";
						Query = $"{Query}from aircraft WITH(NOLOCK) ";
						Query = $"{Query}inner join aircraft_model WITH(NOLOCK) on ac_amod_id=amod_id ";
						Query = $"{Query}inner join aircraft_reference WITH(NOLOCK) on ac_id=cref_ac_id and ac_journ_id=cref_journ_id ";
						Query = $"{Query}inner join journal WITH(NOLOCK) on cref_journ_id=journ_id ";
						Query = $"{Query}where ((journ_subcategory_code like 'FSPH%' and cref_contact_type ='69') or (journ_subcategory_code like 'FS%PH'  and cref_contact_type ='70' ) ) ";
						Query = $"{Query}and journ_id>0  ";

						if (Select_ac_id > 0)
						{
							Query = $"{Query} and ac_id={Select_ac_id.ToString()} ";
						}
						// Query = Query & "and prog_id= " & Prog_id & " "

					}
					else
					{
						Query = "Select journ_date,journ_subcategory_code, journ_subject, journ_id,ac_id,cref_contact_type,cref_comp_id , amod_id,cref_owner_percent ";
						Query = $"{Query}from aircraft WITH(NOLOCK) ";
						Query = $"{Query}inner join aircraft_model WITH(NOLOCK) on ac_amod_id=amod_id ";
						Query = $"{Query}inner join aircraft_reference WITH(NOLOCK) on ac_id=cref_ac_id and ac_journ_id=cref_journ_id ";
						Query = $"{Query}inner join program_reference WITH(NOLOCK) on pgref_comp_id=cref_comp_id ";
						Query = $"{Query}inner join aircraft_programs  WITH(NOLOCK) on pgref_prog_id=prog_id ";
						Query = $"{Query}inner join journal WITH(NOLOCK) on cref_journ_id=journ_id ";
						Query = $"{Query}where ((journ_subcategory_code like 'FSPH%' and cref_contact_type ='69') or (journ_subcategory_code like 'FS%PH'  and cref_contact_type ='70' ) ) ";
						if (Select_comp_id > 0)
						{
							Query = $"{Query}and cref_comp_id = {Select_comp_id.ToString()} ";
						}

						Query = $"{Query}and journ_id>0  ";
						Query = $"{Query}and prog_id= {Prog_id.ToString()} ";
						if (amod_id > 0)
						{
							Query = $"{Query}and amod_id= {amod_id.ToString()}  ";
						}
					}
					//Query = Query & "order by journ_date,journ_subcategory_code,ac_id "

					Query = $"{Query}order by ac_id,journ_date,journ_subcategory_code ";

				}

			}
			else if (TranPrefix[2].Checked)
			{  //eueu

				if (Prog_id == 44)
				{
					if (Select_ac_id > 0)
					{

						Query = "Select journ_date,journ_subcategory_code, journ_subject, journ_id,ac_id,cref_contact_type,cref_comp_id,amod_id ,cref_owner_percent ";
						Query = $"{Query}from aircraft_reference WITH(NOLOCK)  inner join journal WITH(NOLOCK) on cref_journ_id = journ_id ";
						Query = $"{Query}inner join aircraft WITH(NOLOCK)  on ac_id=cref_ac_id and ac_journ_id=cref_journ_id ";
						Query = $"{Query}inner join aircraft_model WITH(NOLOCK) on ac_amod_id=amod_id ";
						Query = $"{Query}inner join company WITH(NOLOCK) on cref_comp_id = comp_id and cref_journ_id = comp_journ_id ";
						Query = $"{Query}where journ_id>0 ";
						Query = $"{Query}and journ_subcategory_code not like 'FS%PH' and journ_subcategory_code not like 'FSPH%' ";
						Query = $"{Query}and journ_subcategory_code not like 'FS%PM' and journ_subcategory_code not like 'FSPM%' ";
						Query = $"{Query}and cref_owner_percent>0 and journ_subcategory_code like 'FS%' and amod_customer_flag = 'Y' ";
						Query = $"{Query}and journ_subcategory_code <>'FSPEND' and journ_subcategory_code <>'FSCORR' ";
						Query = $"{Query}and journ_subcategory_code not like 'FS%IT' ";
						Query = $"{Query}and  cref_contact_type='69' ";
						Query = $"{Query}and cref_comp_id not in (select distinct pshr_comp_id from program_shareholders) ";
						if (Select_ac_id > 0)
						{
							Query = $"{Query} and ac_id={Select_ac_id.ToString()} ";
						}
					}
					else
					{

						Query = "Select journ_date,journ_subcategory_code, journ_subject, journ_id,ac_id,cref_contact_type,cref_comp_id , amod_id,cref_owner_percent ";
						Query = $"{Query}from aircraft_reference WITH(NOLOCK)  inner join journal WITH(NOLOCK) on cref_journ_id = journ_id ";
						Query = $"{Query}inner join aircraft WITH(NOLOCK)  on ac_id=cref_ac_id and ac_journ_id=cref_journ_id ";
						Query = $"{Query}inner join aircraft_model WITH(NOLOCK) on ac_amod_id=amod_id ";
						Query = $"{Query}inner join company WITH(NOLOCK) on cref_comp_id = comp_id and cref_journ_id = comp_journ_id ";
						Query = $"{Query}where journ_id>0 ";

						Query = $"{Query}and journ_subcategory_code not like 'FS%PH' and journ_subcategory_code not like 'FSPH%' ";
						Query = $"{Query}and journ_subcategory_code not like 'FS%PM' and journ_subcategory_code not like 'FSPM%' ";
						Query = $"{Query}and cref_owner_percent>0 and journ_subcategory_code like 'FS%' and amod_customer_flag = 'Y' ";
						Query = $"{Query}and journ_subcategory_code <>'FSPEND' and journ_subcategory_code <>'FSCORR' ";
						Query = $"{Query}and journ_subcategory_code not like 'FS%IT' ";
						Query = $"{Query}and  cref_contact_type='69' ";
						Query = $"{Query}and cref_comp_id not in (select distinct pshr_comp_id from program_shareholders) ";


						Query = $"{Query}and prog_id= {Prog_id.ToString()} ";
						if (amod_id > 0)
						{
							Query = $"{Query}and amod_id= {amod_id.ToString()}  ";
						}
						if (Select_comp_id > 0)
						{
							Query = $"{Query}and cref_comp_id = {Select_comp_id.ToString()} ";
						}

					}
					//         Query = Query & "order by journ_date,journ_subcategory_code ,ac_id "
					Query = $"{Query}order by ac_id,journ_date,journ_subcategory_code ";

				}
				else
				{
					if (Select_ac_id > 0)
					{
						Query = "Select journ_date,journ_subcategory_code, journ_subject, journ_id,ac_id,cref_contact_type,cref_comp_id,amod_id,cref_owner_percent ";
						Query = $"{Query}from aircraft WITH(NOLOCK) ";
						Query = $"{Query}inner join aircraft_model WITH(NOLOCK) on ac_amod_id=amod_id ";
						Query = $"{Query}inner join aircraft_reference WITH(NOLOCK) on ac_id=cref_ac_id and ac_journ_id=cref_journ_id ";
						// Query = Query & "inner join program_reference WITH(NOLOCK) on pgref_comp_id=cref_comp_id "
						Query = $"{Query}inner join program_shareholders WITH(NOLOCK) on pshr_comp_id=cref_comp_id ";
						//Query = Query & "inner join aircraft_programs  WITH(NOLOCK) on pshr_prog_id=prog_id "
						Query = $"{Query}inner join journal WITH(NOLOCK) on cref_journ_id=journ_id ";
						Query = $"{Query}where journ_id > 0 ";
						Query = $"{Query}and journ_subcategory_code not like 'FS%PH' and journ_subcategory_code not like 'FSPH%' ";
						Query = $"{Query}and journ_subcategory_code not like 'FS%PM' and journ_subcategory_code not like 'FSPM%' ";
						Query = $"{Query}and cref_owner_percent>0 and journ_subcategory_code like 'FS%' and amod_customer_flag = 'Y' ";
						Query = $"{Query}and journ_subcategory_code <>'FSPEND' and journ_subcategory_code <>'FSCORR' ";
						Query = $"{Query}and journ_subcategory_code not like 'FS%IT' ";
						Query = $"{Query}and  cref_contact_type='69' ";
						if (Select_ac_id > 0)
						{
							Query = $"{Query} and ac_id={Select_ac_id.ToString()} ";
						}

					}
					else
					{
						Query = "Select journ_date,journ_subcategory_code, journ_subject, journ_id,ac_id,cref_contact_type,cref_comp_id,amod_id,cref_owner_percent ";
						Query = $"{Query}from aircraft WITH(NOLOCK) ";
						Query = $"{Query}inner join aircraft_model WITH(NOLOCK) on ac_amod_id=amod_id ";
						Query = $"{Query}inner join aircraft_reference WITH(NOLOCK) on ac_id=cref_ac_id and ac_journ_id=cref_journ_id ";
						// Query = Query & "inner join program_reference WITH(NOLOCK) on pgref_comp_id=cref_comp_id "
						Query = $"{Query}inner join program_shareholders WITH(NOLOCK) on pshr_comp_id=cref_comp_id ";
						Query = $"{Query}inner join aircraft_programs  WITH(NOLOCK) on pshr_prog_id=prog_id ";
						Query = $"{Query}inner join journal WITH(NOLOCK) on cref_journ_id=journ_id ";
						Query = $"{Query}where journ_id > 0 ";
						Query = $"{Query}and journ_subcategory_code not like 'FS%PH' and journ_subcategory_code not like 'FSPH%' ";
						Query = $"{Query}and journ_subcategory_code not like 'FS%PM' and journ_subcategory_code not like 'FSPM%' ";
						Query = $"{Query}and cref_owner_percent>0 and journ_subcategory_code like 'FS%' and amod_customer_flag = 'Y' ";
						Query = $"{Query}and journ_subcategory_code <>'FSPEND' and journ_subcategory_code <>'FSCORR' ";
						Query = $"{Query}and journ_subcategory_code not like 'FS%IT' ";
						Query = $"{Query}and  cref_contact_type='69' ";

						Query = $"{Query}and prog_id= {Prog_id.ToString()} ";
						if (Select_comp_id > 0)
						{
							Query = $"{Query}and cref_comp_id = {Select_comp_id.ToString()} ";
						}

						if (amod_id > 0)
						{
							Query = $"{Query}and amod_id= {amod_id.ToString()}  ";
						}
					}
					// Query = Query & "order by journ_date,journ_subcategory_code,ac_id "
					Query = $"{Query}order by ac_id,journ_date,journ_subcategory_code ";

				}
			}

			ado_Frac.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
			if (!(ado_Frac.BOF && ado_Frac.EOF))
			{
				ado_Frac.MoveLast();
				NumRecs = ado_Frac.RecordCount;
				ado_Frac.MoveFirst();

				NTrans = 0;
				nBuy = 0;
				nSell = 0;
				CurRow = 0;

				while(!ado_Frac.EOF)
				{
					NTrans++;
					CurRow++;
					journ_id = Convert.ToInt32(Conversion.Val($"{Convert.ToString(ado_Frac["journ_id"])}"));
					AC_ID = Convert.ToInt32(Conversion.Val($"{Convert.ToString(ado_Frac["AC_ID"])}"));
					local_amod_id = Convert.ToInt32(Conversion.Val($"{Convert.ToString(ado_Frac["amod_id"])}"));
					Comp_id = Convert.ToInt32(Conversion.Val($"{Convert.ToString(ado_Frac["cref_comp_id"])}"));
					jDate = $"{Convert.ToString(ado_Frac["journ_date"])}";
					jCode = $"{Convert.ToString(ado_Frac["journ_subcategory_code"])}";
					jSubject = $"{Convert.ToString(ado_Frac["journ_subject"])}";
					ContactType = $"{Convert.ToString(ado_Frac["cref_contact_type"])}";
					OwnerPct = Conversion.Val($"{Convert.ToString(ado_Frac["cref_owner_percent"])}");



					BuySell = "";

					if (jCode.Substring(Math.Min(0, jCode.Length), Math.Min(2, Math.Max(0, jCode.Length))) == "WO")
					{
						OwnerPct = 100;
						nSell++;
						BuySell = "WO Sell";
						OtherContactType = "96";
					}

					if (jCode.Substring(Math.Min(0, jCode.Length), Math.Min(2, Math.Max(0, jCode.Length))) == "WS")
					{
						OwnerPct = 100;
						if (ContactType == "96")
						{
							BuySell = "Buy";
							nBuy++;
						}
						else if (ContactType == "95")
						{ 
							nSell++;
							BuySell = "Sell";
						}
					}
					else if (jCode.Substring(Math.Min(0, jCode.Length), Math.Min(2, Math.Max(0, jCode.Length))) == "SS")
					{ 
						if (ContactType == "96")
						{
							BuySell = "Buy";
							nBuy += (OwnerPct / 100d);
						}
						else if (ContactType == "95")
						{ 
							nSell += (OwnerPct / 100d);
							BuySell = "Sell";
						}
					}

					if (BuySell == "Buy")
					{
						NetSales++;
					}
					else if (BuySell == "Sell")
					{ 
						NetSales--;
					}

					//         Else
					//            If Mid(jCode, 5, 2) = "PH" Then
					//               BuySell = "Buy"
					//               nBuy = nBuy + 1
					//            ElseIf Mid(jCode, 3, 2) = "PH" Then
					//               nSell = nSell + 1
					//               BuySell = "Sell"
					//            End If
					//         End If


					OtherContactType = "";
					if (ContactType == "96")
					{
						OtherContactType = "95";
					}
					else if (ContactType == "95")
					{ 
						OtherContactType = "96";
					}
					else if (ContactType == "70")
					{ 
						OtherContactType = "69";
					}
					else if (ContactType == "69")
					{ 
						OtherContactType = "70";
					}



					FG_Transactions.RowsCount++;
					FG_Transactions.CurrentRowIndex = CurRow;
					FG_Transactions.CurrentColumnIndex = 0;
					System.DateTime TempDate2 = DateTime.FromOADate(0);
					FG_Transactions[FG_Transactions.CurrentRowIndex, FG_Transactions.CurrentColumnIndex].Value = (DateTime.TryParse(jDate, out TempDate2)) ? TempDate2.ToString("MM/dd/yyyy") : jDate;
					FG_Transactions.CurrentColumnIndex = 1;
					FG_Transactions[FG_Transactions.CurrentRowIndex, FG_Transactions.CurrentColumnIndex].Value = jCode;
					if (jCode.Substring(Math.Min(0, jCode.Length), Math.Min(2, Math.Max(0, jCode.Length))) == "SS")
					{
						FG_Transactions.CellBackColor = SystemColors.Control;
					}
					FG_Transactions.CurrentColumnIndex = 2;
					FG_Transactions[FG_Transactions.CurrentRowIndex, FG_Transactions.CurrentColumnIndex].Value = jSubject;
					FG_Transactions.ColAlignment[2] = DataGridViewContentAlignment.TopLeft;
					FG_Transactions.CurrentColumnIndex = 3;
					FG_Transactions[FG_Transactions.CurrentRowIndex, FG_Transactions.CurrentColumnIndex].Value = $"{BuySell} {StringsHelper.Format(OwnerPct, "##")}%";
					FG_Transactions.CurrentColumnIndex = 4;
					FG_Transactions.CellBackColor = SystemColors.Window;
					FG_Transactions[FG_Transactions.CurrentRowIndex, FG_Transactions.CurrentColumnIndex].Value = AC_ID;
					FG_Transactions.CurrentColumnIndex = 5;
					FG_Transactions[FG_Transactions.CurrentRowIndex, FG_Transactions.CurrentColumnIndex].Value = journ_id;
					FG_Transactions.CurrentColumnIndex = 6;
					FG_Transactions[FG_Transactions.CurrentRowIndex, FG_Transactions.CurrentColumnIndex].Value = Comp_id;
					//         FG_Transactions.CellBackColor = &H80000005

					FoundAC = false;
					int tempForEndVar = NumFleet;
					for (int K = 1; K <= tempForEndVar; K++)
					{
						if (AC_ID == AC_List[K])
						{
							FoundAC = true;
							break;
						}

					}


					gac_list = ArraysHelper.RedimPreserve(gac_list, new int[]{CurRow + 1});
					gac_list[CurRow] = AC_ID; //build a list of every ac_id in grid

					if (!FoundAC && Select_ac_id == 0 && amod_id > 0 && SSTabHelper.GetSelectedIndex(DetailTab) < 2)
					{ //add to other grid
						NumFleet++;
						AC_List = ArraysHelper.RedimPreserve(AC_List, new int[]{NumFleet + 1});
						AC_List[NumFleet] = AC_ID;
						FG_Transactions.CurrentColumnIndex = 4;
						FG_Transactions.CellBackColor = SystemColors.Control;
						FG_ProgAircraft.RowsCount++;
						FG_ProgAircraft.CurrentRowIndex = FG_ProgAircraft.RowsCount - 1;
						FG_ProgAircraft.CurrentColumnIndex = 0; //make
						FG_ProgAircraft[FG_ProgAircraft.CurrentRowIndex, FG_ProgAircraft.CurrentColumnIndex].Value = $"{modCommon.DLookUp("amod_make_name", "Aircraft_Model", $"amod_id={local_amod_id.ToString()}")}";
						FG_ProgAircraft.CellBackColor = SystemColors.Control;
						FG_ProgAircraft.CurrentColumnIndex = 1; //model
						FG_ProgAircraft[FG_ProgAircraft.CurrentRowIndex, FG_ProgAircraft.CurrentColumnIndex].Value = $"{modCommon.DLookUp("amod_model_name", "Aircraft_Model", $"amod_id={local_amod_id.ToString()}")}";
						FG_ProgAircraft.CurrentColumnIndex = 2; //serial #
						FG_ProgAircraft[FG_ProgAircraft.CurrentRowIndex, FG_ProgAircraft.CurrentColumnIndex].Value = $"{modCommon.DLookUp("ac_ser_no_full", "Aircraft", $"ac_id={AC_ID.ToString()} and ac_journ_id={journ_id.ToString()}")}";
						FG_ProgAircraft.CurrentColumnIndex = 3; //reg #
						FG_ProgAircraft[FG_ProgAircraft.CurrentRowIndex, FG_ProgAircraft.CurrentColumnIndex].Value = $"{modCommon.DLookUp("ac_reg_no", "Aircraft", $"ac_id={AC_ID.ToString()} and ac_journ_id={journ_id.ToString()}")}";
						FG_ProgAircraft.CurrentColumnIndex = 4; //ac_id
						FG_ProgAircraft[FG_ProgAircraft.CurrentRowIndex, FG_ProgAircraft.CurrentColumnIndex].Value = AC_ID;
						FG_ProgAircraft.CurrentColumnIndex = 5; //hist y/n
						FG_ProgAircraft[FG_ProgAircraft.CurrentRowIndex, FG_ProgAircraft.CurrentColumnIndex].Value = "Y";

						if (chk_analyze.CheckState == CheckState.Checked)
						{
							if (Analyze_AC(AC_ID, true))
							{
								FG_ProgAircraft.CurrentColumnIndex = 4;
								FG_ProgAircraft.CellBackColor = Color.Red;
								NumFleetError++;
								Application.DoEvents();
							}
						}

						Application.DoEvents();
					}

					lblStatus.Text = $"Transactions - Record:{NTrans.ToString()} of {NumRecs.ToString()}";

					Application.DoEvents();
					if (Stopped)
					{
						break;
					}


					ado_Frac.MoveNext();
				};
				FG_Transactions.RowsCount--;
				ado_Frac.Close();
			}

			FG_Transactions.Visible = NTrans != 0;

			if (TranPrefix[0].Checked)
			{ //ws
				NetAdds = nBuy - nSell;
				DiffFromFleet = ((BaseFleet - NumWrittenOff) - HistFleet) - Math.Abs(NetAdds);

				if (Select_ac_id > 0)
				{
					DiffFromFleet = 1 - Math.Abs(NetAdds);
				}

				lblTrans.Text = $"{NTrans.ToString()} Transactions: {nBuy.ToString()} Buy, {nSell.ToString()} Sell, Net Adds: {NetAdds.ToString()}";
				lblTrans.ForeColor = SystemColors.ControlText;

				if (DiffFromFleet != 0)
				{
					lblTrans.Text = $"{NTrans.ToString()} Transactions: {nBuy.ToString()} Buy, {nSell.ToString()} Sell, Net Adds: {NetAdds.ToString()} ,Variance: {DiffFromFleet.ToString()}";
					lblTrans.ForeColor = Color.Red;

					//compare transaction grid to ac grid
					if (Select_ac_id == 0)
					{
						int tempForEndVar2 = FG_ProgAircraft.RowsCount - 1;
						for (int J = 1; J <= tempForEndVar2; J++)
						{
							FG_ProgAircraft.CurrentColumnIndex = 4;
							FG_ProgAircraft.CurrentRowIndex = J;
							AC_ID = Convert.ToInt32(Conversion.Val($"{FG_ProgAircraft[FG_ProgAircraft.CurrentRowIndex, FG_ProgAircraft.CurrentColumnIndex].FormattedValue.ToString()}"));
							if (AC_ID > 0)
							{
								FoundAC = false;
								int tempForEndVar3 = NTrans;
								for (int K = 1; K <= tempForEndVar3; K++)
								{
									if (AC_ID == gac_list[K])
									{
										FoundAC = true;
										break;
									}
								}

								if (!FoundAC)
								{
									FG_ProgAircraft.CurrentColumnIndex = 2;
									FG_ProgAircraft.CellBackColor = Color.FromArgb(255, 128, 255); //purple
								}
							}
						}
					}
				}

			}
			else if (TranPrefix[1].Checked)
			{  //fs
				lblTrans.Text = $"{NTrans.ToString()} Transactions: {nBuy.ToString()} Buy, {nSell.ToString()} Sell ";
				lblTrans.ForeColor = SystemColors.ControlText;
			}
			else
			{
				//eueu
				lblTrans.Text = $"{NTrans.ToString()} Transactions ";
				lblTrans.ForeColor = SystemColors.ControlText;

			}

			lblStatus.Text = "";
			FLeetAC.Text = $" {NumFleet.ToString()} Aircraft in Fleet , {((BaseFleet - HistFleet).ToString())} Current";
			FLeetAC.ForeColor = SystemColors.ControlText;
			if (NumFleetError > 0)
			{
				FLeetAC.ForeColor = Color.Red;
			}


			this.Cursor = CursorHelper.CursorDefault;

		}


		private void cmdStop_Click(Object eventSender, EventArgs eventArgs)
		{
			Stopped = true;
			Application.DoEvents();
			ProgramLoadInProgress = false;
			Application.DoEvents();
		}

		private void DetailTab_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{
			string Query = "";
			double Pct = 0;
			string CompName = "";
			string CompCity = "";
			string CompState = "";
			string aMake = "";
			string aModel = "";
			int CurRow = 0;
			ADORecordSetHelper ado_Subs = new ADORecordSetHelper();
			object sDate = null;
			object EDate = null;
			ADORecordSetHelper ado_Date = null;
			bool NeedsEDate = false;

			if (ProgramLoadInProgress)
			{
				return;
			}

			GrdSubscribers.Clear();
			GrdSubscribers.RowsCount = 2;
			Stopped = false;

			if (Prog_id == 44)
			{
				return;
			}

			lblTrans.Text = "";
			LBLNotCount.Text = "";
			this.Cursor = Cursors.WaitCursor;
			Application.DoEvents();

			if (SSTabHelper.GetSelectedIndex(DetailTab) == 1)
			{ //build subscriber grid

				GrdSubscribers.CurrentColumnIndex = 0;
				GrdSubscribers.CurrentRowIndex = 0;
				GrdSubscribers[GrdSubscribers.CurrentRowIndex, GrdSubscribers.CurrentColumnIndex].Value = "Company";
				GrdSubscribers.CurrentColumnIndex = 1;
				GrdSubscribers[GrdSubscribers.CurrentRowIndex, GrdSubscribers.CurrentColumnIndex].Value = "Comp_id";
				GrdSubscribers.CurrentColumnIndex = 2;
				GrdSubscribers[GrdSubscribers.CurrentRowIndex, GrdSubscribers.CurrentColumnIndex].Value = "Percent";
				GrdSubscribers.CurrentColumnIndex = 3;
				GrdSubscribers[GrdSubscribers.CurrentRowIndex, GrdSubscribers.CurrentColumnIndex].Value = "AC_id";
				GrdSubscribers.CurrentColumnIndex = 4;
				GrdSubscribers[GrdSubscribers.CurrentRowIndex, GrdSubscribers.CurrentColumnIndex].Value = "Make";
				GrdSubscribers.CurrentColumnIndex = 5;
				GrdSubscribers[GrdSubscribers.CurrentRowIndex, GrdSubscribers.CurrentColumnIndex].Value = "Model";
				GrdSubscribers.SetColumnWidth(0, 200);
				GrdSubscribers.SetColumnWidth(1, 67);
				GrdSubscribers.SetColumnWidth(2, 67);
				GrdSubscribers.SetColumnWidth(3, 67);
				GrdSubscribers.SetColumnWidth(4, 100);
				GrdSubscribers.SetColumnWidth(5, 100);

				Query = "Select distinct comp_name,amod_Make_name,amod_Model_name,cref_comp_id,cref_ac_id,cref_owner_percent ";
				Query = $"{Query}From aircraft_programs  WITH(NOLOCK) ";
				Query = $"{Query}inner join program_shareholders WITH(NOLOCK) on pshr_prog_id = prog_id ";
				Query = $"{Query}inner join aircraft_reference WITH(NOLOCK) on pshr_comp_id = cref_comp_id and cref_journ_id = 0 ";
				Query = $"{Query}inner join aircraft WITH(NOLOCK) on ac_id=cref_ac_id and ac_journ_id=cref_journ_id ";
				Query = $"{Query}inner join aircraft_model on ac_amod_id=amod_id ";
				Query = $"{Query}inner join company on cref_comp_id=comp_id and cref_journ_id=comp_journ_id ";
				Query = $"{Query}Where ac_journ_id = 0 ";
				//And Prog_id = 6 And ac_amod_id = 272
				Query = $"{Query}and prog_id= {Prog_id.ToString()} ";

				if (amod_id > 0)
				{
					Query = $"{Query}and amod_id= {amod_id.ToString()}  ";
				}

				if (Select_ac_id > 0)
				{
					Query = $"{Query} and ac_id={Select_ac_id.ToString()} ";
				}

				if (Select_comp_id > 0)
				{
					Query = $"{Query}and cref_comp_id = {Select_comp_id.ToString()} ";
				}



				Query = $"{Query} order by comp_name,amod_Make_name,amod_Model_name ";

				ado_Subs.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
				if (!(ado_Subs.BOF && ado_Subs.EOF))
				{
					ado_Subs.MoveLast();
					NumRecs = ado_Subs.RecordCount;
					ado_Subs.MoveFirst();
					CurRow = 0;

					while(!ado_Subs.EOF)
					{
						AC_ID = Convert.ToInt32(Conversion.Val($"{Convert.ToString(ado_Subs["cref_ac_id"])}"));
						Comp_id = Convert.ToInt32(Conversion.Val($"{Convert.ToString(ado_Subs["cref_comp_id"])}"));
						Pct = Conversion.Val($"{Convert.ToString(ado_Subs["cref_owner_percent"])}");
						CompName = $"{Convert.ToString(ado_Subs["comp_name"])}";
						aMake = $"{Convert.ToString(ado_Subs["amod_make_name"])}";
						aModel = $"{Convert.ToString(ado_Subs["amod_model_name"])}";

						CurRow++;
						GrdSubscribers.RowsCount++;
						GrdSubscribers.CurrentRowIndex = CurRow;
						GrdSubscribers.CurrentColumnIndex = 0;
						GrdSubscribers[GrdSubscribers.CurrentRowIndex, GrdSubscribers.CurrentColumnIndex].Value = CompName;
						GrdSubscribers.ColAlignment[0] = DataGridViewContentAlignment.TopLeft;
						GrdSubscribers.CurrentColumnIndex = 1;
						GrdSubscribers[GrdSubscribers.CurrentRowIndex, GrdSubscribers.CurrentColumnIndex].Value = Comp_id;
						GrdSubscribers.CurrentColumnIndex = 2;
						GrdSubscribers[GrdSubscribers.CurrentRowIndex, GrdSubscribers.CurrentColumnIndex].Value = StringsHelper.Format(Pct, "##0.00");
						GrdSubscribers.CurrentColumnIndex = 3;
						GrdSubscribers[GrdSubscribers.CurrentRowIndex, GrdSubscribers.CurrentColumnIndex].Value = AC_ID;
						GrdSubscribers.CurrentColumnIndex = 4;
						GrdSubscribers[GrdSubscribers.CurrentRowIndex, GrdSubscribers.CurrentColumnIndex].Value = aMake;
						GrdSubscribers.CurrentColumnIndex = 5;
						GrdSubscribers[GrdSubscribers.CurrentRowIndex, GrdSubscribers.CurrentColumnIndex].Value = aModel;

						lblStatus.Text = $"Transactions - Record:{CurRow.ToString()} of {NumRecs.ToString()}";

						Application.DoEvents();
						if (Stopped)
						{
							break;
						}


						ado_Subs.MoveNext();
					};
					ado_Subs.Close();
				}


				lblTrans.Text = $"{CurRow.ToString()} Subscribers";
			}
			else if (SSTabHelper.GetSelectedIndex(DetailTab) == 2)
			{  //missing Program holders or shareholders
				GrdNotInTable.Clear();
				GrdNotInTable.RowsCount = 2;
				GrdNotInTable.ColumnsCount = 4;

				GrdNotInTable.FixedRows = 1;
				GrdNotInTable.CurrentRowIndex = 0;
				GrdNotInTable.CurrentColumnIndex = 0;
				GrdNotInTable[GrdNotInTable.CurrentRowIndex, GrdNotInTable.CurrentColumnIndex].Value = "Company Name";
				GrdNotInTable.CurrentColumnIndex = 1;
				GrdNotInTable[GrdNotInTable.CurrentRowIndex, GrdNotInTable.CurrentColumnIndex].Value = "City";
				GrdNotInTable.CurrentColumnIndex = 2;
				GrdNotInTable[GrdNotInTable.CurrentRowIndex, GrdNotInTable.CurrentColumnIndex].Value = "State";
				GrdNotInTable.CurrentColumnIndex = 3;
				GrdNotInTable[GrdNotInTable.CurrentRowIndex, GrdNotInTable.CurrentColumnIndex].Value = "Comp_id";
				GrdNotInTable.SetColumnWidth(0, 133);
				GrdNotInTable.SetColumnWidth(1, 67);
				GrdNotInTable.SetColumnWidth(2, 67);
				GrdNotInTable.SetColumnWidth(3, 67);


				if (Opt_notinTable[0].Checked)
				{ //program holders
					Query = "select distinct comp_name, comp_city, comp_state, comp_id ";
					Query = $"{Query}from aircraft_reference ";
					Query = $"{Query}inner join journal on cref_journ_id = journ_id inner join company on cref_comp_id = comp_id and cref_journ_id = comp_journ_id ";
					//Query = Query & "where ((journ_subcategory_code like 'WSPH%' and cref_contact_type ='95') or (journ_subcategory_code like 'WS%PH' and cref_contact_type='96' )) "
					Query = $"{Query}Where ((journ_subcategory_code like 'WSPH%' and cref_contact_type ='95') or (journ_subcategory_code like 'SSPH%' and cref_contact_type ='95') or (journ_subcategory_code like 'WS%PH' and cref_contact_type='96' ) or (journ_subcategory_code like 'SS%PH' and cref_contact_type='96' ) or (journ_subcategory_code like 'WSPHIT' and cref_contact_type='96' ) or (journ_subcategory_code like 'WSITPH' and cref_contact_type='95' )) ";

					//Query = Query & "and journ_internal_trans_flag='N' "
					if (Chk_internal.CheckState == CheckState.Checked)
					{
						Query = $"{Query}and journ_internal_trans_flag='N' ";
					}

					if (Select_comp_id > 0)
					{
						Query = $"{Query}and cref_comp_id = {Select_comp_id.ToString()} ";
					}

					Query = $"{Query}and cref_comp_id not in (select distinct pgref_comp_id from program_reference) ";
					Query = $"{Query}order by comp_name, comp_city, comp_state, comp_id ";

				}
				else if (Opt_notinTable[1].Checked)
				{  //shareholders

					Query = "select distinct comp_name, comp_city, comp_state, comp_id ";
					//,cref_owner_percent,cref_contact_type "
					Query = $"{Query}from aircraft_reference inner join journal on cref_journ_id = journ_id ";
					Query = $"{Query}inner join company on cref_comp_id = comp_id and cref_journ_id = comp_journ_id ";
					Query = $"{Query}Where ((journ_subcategory_code like 'FSPH%' and cref_contact_type ='69') or (journ_subcategory_code like 'FS%PH'  and cref_contact_type ='70' ) ) ";
					//Query = Query & "and journ_internal_trans_flag='N' "
					if (Chk_internal.CheckState == CheckState.Checked)
					{
						Query = $"{Query}and journ_internal_trans_flag='N' ";
					}
					if (Select_comp_id > 0)
					{
						Query = $"{Query}and cref_comp_id = {Select_comp_id.ToString()} ";
					}

					Query = $"{Query}and cref_comp_id not in (select distinct pshr_comp_id from program_shareholders) ";
					Query = $"{Query}order by comp_name, comp_city, comp_state, comp_id ";
				}
				else if (Opt_notinTable[2].Checked)
				{  //frac shareholders missing sells or buys
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					sDate = DBNull.Value;
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					EDate = DBNull.Value;
					GrdNotInTable.Clear();
					GrdNotInTable.RowsCount = 2;
					GrdNotInTable.ColumnsCount = 2;
					GrdNotInTable.FixedRows = 1;
					GrdNotInTable.CurrentRowIndex = 0;
					GrdNotInTable.CurrentColumnIndex = 0;
					GrdNotInTable[GrdNotInTable.CurrentRowIndex, GrdNotInTable.CurrentColumnIndex].Value = "Comp_id";
					GrdNotInTable.CurrentColumnIndex = 1;
					GrdNotInTable[GrdNotInTable.CurrentRowIndex, GrdNotInTable.CurrentColumnIndex].Value = "Issue";
					GrdNotInTable.SetColumnWidth(0, 133);
					GrdNotInTable.SetColumnWidth(1, 200);

					Query = "select distinct cref_comp_id from aircraft_reference ";
					Query = $"{Query}inner join journal on cref_journ_id = journ_id ";
					Query = $"{Query}where journ_id in (  select distinct journ_id from journal ";
					Query = $"{Query}inner join aircraft_reference on cref_journ_id = journ_id ";
					Query = $"{Query}inner join program_reference on pgref_comp_id = cref_comp_id ";
					Query = $"{Query}where (journ_subcategory_code like 'FS%' or journ_subcategory_code like 'FT%' ) ";
					Query = $"{Query}and cref_contact_type not in ('17','78','86','89','18') ";
					Query = $"{Query}and pgref_prog_id ={Prog_id.ToString()} ) ";
					Query = $"{Query}and  ((journ_subcategory_code like 'FS%PH' and cref_contact_type='69')  or  (journ_subcategory_code like 'FSPH%' and cref_contact_type='70') ";
					Query = $"{Query} or  (journ_subcategory_code like 'FT%PH' and cref_contact_type='69') ";
					Query = $"{Query}or  (journ_subcategory_code like 'FTPH%' and cref_contact_type='70') ";
					Query = $"{Query}or  (journ_subcategory_code like 'FT%IT' and (cref_contact_type='70' ";
					Query = $"{Query}or cref_contact_type='69') )) order by cref_comp_id ";
					ado_Subs.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
					if (!(ado_Subs.BOF && ado_Subs.EOF))
					{
						ado_Subs.MoveLast();
						NumRecs = ado_Subs.RecordCount;
						ado_Subs.MoveFirst();
						CurRow = 0;

						while(!ado_Subs.EOF)
						{
							Comp_id = Convert.ToInt32(Conversion.Val($"{Convert.ToString(ado_Subs["cref_comp_id"])}"));

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							sDate = DBNull.Value;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							EDate = DBNull.Value;
							Query = "select min(journ_date) AS SDate ";
							Query = $"{Query}from aircraft_reference inner join journal on cref_journ_id = journ_id ";
							Query = $"{Query}where journ_id in (  ";
							Query = $"{Query}select distinct journ_id from journal ";
							Query = $"{Query}inner join aircraft_reference on cref_journ_id = journ_id ";
							Query = $"{Query}inner join program_reference on pgref_comp_id = cref_comp_id ";
							Query = $"{Query}where (journ_subcategory_code like 'FS%' or journ_subcategory_code like 'FT%') ";
							Query = $"{Query}and pgref_prog_id = {Prog_id.ToString()} ";
							Query = $"{Query}) and ";
							Query = $"{Query} ((journ_subcategory_code like 'FS%' and cref_contact_type='70') ";
							Query = $"{Query} or  (journ_subcategory_code like 'FT%' and cref_contact_type='70') ) ";
							Query = $"{Query}and cref_comp_id= {Comp_id.ToString()}  ";

							ado_Date = new ADORecordSetHelper();
							ado_Date.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
							if (!(ado_Date.EOF && ado_Date.BOF))
							{
								ado_Date.MoveFirst();
								sDate = ado_Date["sDate"];
								ado_Date.Close();
							}

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (Convert.IsDBNull(sDate))
							{
								CurRow++;
								GrdNotInTable.RowsCount++;
								GrdNotInTable.CurrentRowIndex = CurRow;

								GrdNotInTable.CurrentColumnIndex = 0;
								GrdNotInTable[GrdNotInTable.CurrentRowIndex, GrdNotInTable.CurrentColumnIndex].Value = Comp_id;
								GrdNotInTable.CurrentColumnIndex = 1;
								GrdNotInTable[GrdNotInTable.CurrentRowIndex, GrdNotInTable.CurrentColumnIndex].Value = "sell w/out Buy";
							}

							Query = "select max(journ_date) AS EDate ";
							Query = $"{Query}from aircraft_reference inner join journal on cref_journ_id = journ_id ";
							Query = $"{Query}where journ_id in (  ";
							Query = $"{Query}select distinct journ_id from journal ";
							Query = $"{Query}inner join aircraft_reference on cref_journ_id = journ_id ";
							Query = $"{Query}inner join program_reference on pgref_comp_id = cref_comp_id ";
							Query = $"{Query}where (journ_subcategory_code like 'FS%' or journ_subcategory_code like 'FT%') ";
							Query = $"{Query}and pgref_prog_id = {Prog_id.ToString()} ";
							Query = $"{Query}) and ";
							Query = $"{Query} ((journ_subcategory_code like 'FS%' and cref_contact_type='69') ";
							Query = $"{Query} or  (journ_subcategory_code like 'FT%' and cref_contact_type='69')) ";
							Query = $"{Query}and cref_comp_id= {Comp_id.ToString()}  ";

							ado_Date = new ADORecordSetHelper();
							ado_Date.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
							if (!(ado_Date.EOF && ado_Date.BOF))
							{
								ado_Date.MoveFirst();
								EDate = ado_Date["EDate"];
								ado_Date.Close();
							}

							//currently in a program?
							Query = "select cref_comp_id, cref_journ_id, cref_ac_id, cref_owner_percent, cref_contact_type ";
							Query = $"{Query}From aircraft_reference WITH(NOLOCK) ";
							Query = $"{Query}where cref_ac_id in ( ";
							Query = $"{Query}select distinct cref_ac_id from aircraft_reference WITH(NOLOCK) ";
							Query = $"{Query}inner join program_reference WITH(NOLOCK) on pgref_comp_id = cref_comp_id ";
							Query = $"{Query}where (cref_contact_type='17' ";
							Query = $"{Query}and pgref_prog_id = {Prog_id.ToString()} and cref_journ_id = 0) ";
							Query = $"{Query}) and ( cref_contact_type='97') and cref_journ_id = 0 ";
							Query = $"{Query}and cref_comp_id = {Comp_id.ToString()} ";

							NeedsEDate = false;
							if (modAdminCommon.Exist(Query))
							{
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								EDate = DBNull.Value;
							}
							else
							{
								NeedsEDate = true;
							}

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (NeedsEDate && Convert.IsDBNull(EDate))
							{
								CurRow++;
								GrdNotInTable.RowsCount++;
								GrdNotInTable.CurrentRowIndex = CurRow;
								GrdNotInTable.CurrentColumnIndex = 0;
								GrdNotInTable[GrdNotInTable.CurrentRowIndex, GrdNotInTable.CurrentColumnIndex].Value = Comp_id;
								GrdNotInTable.CurrentColumnIndex = 1;
								GrdNotInTable[GrdNotInTable.CurrentRowIndex, GrdNotInTable.CurrentColumnIndex].Value = "no current frac aircraft, missing sell date";
							}

							//lblStatus.Caption = "Transactions - Record:" & CurRow & " of " & NumRecs
							Application.DoEvents();
							if (Stopped)
							{
								break;
							}

							ado_Subs.MoveNext();
						};
						ado_Subs.Close();
						LBLNotCount.Text = $"{CurRow.ToString()} Rows";
					}
				}
				else if (Opt_notinTable[3].Checked)
				{ 
					//inactive shareholders without buys
					GrdNotInTable.Clear();
					GrdNotInTable.RowsCount = 2;
					GrdNotInTable.ColumnsCount = 2;
					GrdNotInTable.FixedRows = 1;
					GrdNotInTable.CurrentRowIndex = 0;
					GrdNotInTable.CurrentColumnIndex = 0;
					GrdNotInTable[GrdNotInTable.CurrentRowIndex, GrdNotInTable.CurrentColumnIndex].Value = "Comp_id";
					GrdNotInTable.CurrentColumnIndex = 1;
					GrdNotInTable[GrdNotInTable.CurrentRowIndex, GrdNotInTable.CurrentColumnIndex].Value = "Company Name";
					GrdNotInTable.SetColumnWidth(0, 133);
					GrdNotInTable.SetColumnWidth(1, 200);
					CurRow = 0;

					Query = "Select * from View_Fractional_Shareholders_Inactive_No_Buys ";
					ado_Date = new ADORecordSetHelper();
					ado_Date.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
					if (!(ado_Date.EOF && ado_Date.BOF))
					{
						ado_Date.MoveFirst();

						while(!ado_Date.EOF)
						{
							CurRow++;
							GrdNotInTable.RowsCount++;
							GrdNotInTable.CurrentRowIndex = CurRow;
							GrdNotInTable.CurrentColumnIndex = 0;
							GrdNotInTable[GrdNotInTable.CurrentRowIndex, GrdNotInTable.CurrentColumnIndex].Value = Conversion.Val($"{Convert.ToString(ado_Date["Comp_id"])}");
							GrdNotInTable.CurrentColumnIndex = 1;
							GrdNotInTable[GrdNotInTable.CurrentRowIndex, GrdNotInTable.CurrentColumnIndex].Value = $"{Convert.ToString(ado_Date["comp_name"])}";
							Application.DoEvents();
							if (Stopped)
							{
								break;
							}

							ado_Date.MoveNext();
						};
						ado_Date.Close();
						LBLNotCount.Text = $"{CurRow.ToString()} Rows";

					}
					ado_Date = null;
					Query = "";

				}
				else if (Opt_notinTable[4].Checked)
				{ 
					//inactive shareholders without sells
					GrdNotInTable.Clear();
					GrdNotInTable.RowsCount = 2;
					GrdNotInTable.ColumnsCount = 2;
					GrdNotInTable.FixedRows = 1;
					GrdNotInTable.CurrentRowIndex = 0;
					GrdNotInTable.CurrentColumnIndex = 0;
					GrdNotInTable[GrdNotInTable.CurrentRowIndex, GrdNotInTable.CurrentColumnIndex].Value = "Comp_id";
					GrdNotInTable.CurrentColumnIndex = 1;
					GrdNotInTable[GrdNotInTable.CurrentRowIndex, GrdNotInTable.CurrentColumnIndex].Value = "Company Name";
					GrdNotInTable.SetColumnWidth(0, 133);
					GrdNotInTable.SetColumnWidth(1, 200);

					Query = "Select * from View_Fractional_Shareholders_Inactive_No_Sells ";
					CurRow = 0;

					ado_Date = new ADORecordSetHelper();
					ado_Date.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
					if (!(ado_Date.EOF && ado_Date.BOF))
					{
						ado_Date.MoveFirst();

						while(!ado_Date.EOF)
						{
							CurRow++;
							GrdNotInTable.RowsCount++;
							GrdNotInTable.CurrentRowIndex = CurRow;
							GrdNotInTable.CurrentColumnIndex = 0;
							GrdNotInTable[GrdNotInTable.CurrentRowIndex, GrdNotInTable.CurrentColumnIndex].Value = Conversion.Val($"{Convert.ToString(ado_Date["Comp_id"])}");
							GrdNotInTable.CurrentColumnIndex = 1;
							GrdNotInTable[GrdNotInTable.CurrentRowIndex, GrdNotInTable.CurrentColumnIndex].Value = $"{Convert.ToString(ado_Date["comp_name"])}";
							Application.DoEvents();
							if (Stopped)
							{
								break;
							}

							ado_Date.MoveNext();
						};
						ado_Date.Close();
						LBLNotCount.Text = $"{CurRow.ToString()} Rows";

					}
					ado_Date = null;

					Query = "";
				}

				if (Strings.Len(Query.Trim()) > 0)
				{
					ado_Subs.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
					if (!(ado_Subs.BOF && ado_Subs.EOF))
					{
						ado_Subs.MoveLast();
						NumRecs = ado_Subs.RecordCount;
						ado_Subs.MoveFirst();
						CurRow = 0;

						while(!ado_Subs.EOF)
						{
							Comp_id = Convert.ToInt32(Conversion.Val($"{Convert.ToString(ado_Subs["Comp_id"])}"));
							CompName = $"{Convert.ToString(ado_Subs["comp_name"])}";
							CompCity = $"{Convert.ToString(ado_Subs["comp_city"])}";
							CompState = $"{Convert.ToString(ado_Subs["comp_state"])}";

							CurRow++;
							GrdNotInTable.RowsCount++;
							GrdNotInTable.CurrentRowIndex = CurRow;
							GrdNotInTable.CurrentColumnIndex = 0;
							GrdNotInTable[GrdNotInTable.CurrentRowIndex, GrdNotInTable.CurrentColumnIndex].Value = CompName;
							GrdNotInTable.ColAlignment[0] = DataGridViewContentAlignment.TopLeft;
							GrdNotInTable.CurrentColumnIndex = 1;
							GrdNotInTable[GrdNotInTable.CurrentRowIndex, GrdNotInTable.CurrentColumnIndex].Value = CompCity;
							GrdNotInTable.CurrentColumnIndex = 2;
							GrdNotInTable[GrdNotInTable.CurrentRowIndex, GrdNotInTable.CurrentColumnIndex].Value = CompState;
							GrdNotInTable.CurrentColumnIndex = 3;
							GrdNotInTable[GrdNotInTable.CurrentRowIndex, GrdNotInTable.CurrentColumnIndex].Value = Comp_id;

							lblStatus.Text = $"Transactions - Record:{CurRow.ToString()} of {NumRecs.ToString()}";
							Application.DoEvents();
							if (Stopped)
							{
								break;
							}

							ado_Subs.MoveNext();
						};
						ado_Subs.Close();
						LBLNotCount.Text = $"{CurRow.ToString()} Rows";
					}
				}

			}

			ado_Subs = null;
			this.Cursor = CursorHelper.CursorDefault;
			lblStatus.Text = "";

			if (SSTabHelper.GetSelectedIndex(DetailTab) == 0)
			{
				cmdRefresh_Click(cmdRefresh, new EventArgs());
			}

			DetailTabPreviousTab = DetailTab.SelectedIndex;
		}

		private void FG_ProgAircraft_Click(Object eventSender, EventArgs eventArgs)
		{

			if (ProgramLoadInProgress)
			{
				return;
			}


			SSTabHelper.SetSelectedIndex(DetailTab, 0);
			Stopped = false;
			int HoldRow = FG_ProgAircraft.CurrentRowIndex;
			if (HoldRow > 0)
			{
				lblTrans.Text = "";

				this.Cursor = Cursors.WaitCursor;
				FG_ProgAircraft.CurrentColumnIndex = 4;
				Select_ac_id = Convert.ToInt32(Conversion.Val($"{FG_ProgAircraft[FG_ProgAircraft.CurrentRowIndex, FG_ProgAircraft.CurrentColumnIndex].FormattedValue.ToString()}"));

				if (Select_ac_id > 0)
				{
					cmdRefresh_Click(cmdRefresh, new EventArgs());
					//Amod_id = 0

					FG_ProgAircraft.CurrentColumnIndex = 2;
					int tempForEndVar = FG_ProgAircraft.RowsCount - 1;
					for (int K = 1; K <= tempForEndVar; K++)
					{
						FG_ProgAircraft.CurrentRowIndex = K;
						FG_ProgAircraft.CellBackColor = SystemColors.Window; //white
					}

				}

				Application.DoEvents();
				FG_ProgAircraft.CurrentRowIndex = HoldRow;
				FG_ProgAircraft.RowSel = HoldRow;
				FG_ProgAircraft.ColSel = 1;

			}

			this.Cursor = CursorHelper.CursorDefault;

		}

		private void FG_ProgAircraft_DoubleClick(Object eventSender, EventArgs eventArgs)
		{
			//'load aircraft

		}


		private void FG_ProgCompany_Click(Object eventSender, EventArgs eventArgs)
		{
			// load company
			string Query = "";

			if (ProgramLoadInProgress)
			{
				return;
			}

			SSTabHelper.SetSelectedIndex(DetailTab, 0); //transaction tab
			journ_id = 0; //default=current company
			Stopped = false;
			Select_comp_id = 0;

			int HoldRow = FG_ProgCompany.CurrentRowIndex; //save for later
			if (HoldRow > 0)
			{
				this.Cursor = Cursors.WaitCursor;
				Application.DoEvents();

				Select_comp_id = Convert.ToInt32(Conversion.Val($"{FG_ProgCompany[FG_ProgCompany.CurrentRowIndex, FG_ProgCompany.CurrentColumnIndex].FormattedValue.ToString()}")); //get company id
				cmb_Models_SelectedIndexChanged(cmb_Models, new EventArgs());
				FG_ProgCompany.RowSel = HoldRow; //highlight row
				FG_ProgCompany.ColSel = 2;

			}
			this.Cursor = CursorHelper.CursorDefault;


		}

		private void FG_ProgCompany_DoubleClick(Object eventSender, EventArgs eventArgs)
		{
			// load company
			string Query = "";
			frm_Company o_Local_Show_Company = null;

			SSTabHelper.SetSelectedIndex(DetailTab, 0); //transaction tab
			journ_id = 0; //default=current company
			Stopped = false;

			int HoldRow = FG_ProgCompany.CurrentRowIndex; //save for later
			if (HoldRow > 0)
			{
				this.Cursor = Cursors.WaitCursor;

				FG_ProgCompany.CurrentColumnIndex = 1;
				Comp_id = Convert.ToInt32(Conversion.Val($"{FG_ProgCompany[FG_ProgCompany.CurrentRowIndex, FG_ProgCompany.CurrentColumnIndex].FormattedValue.ToString()}")); //get company id

				Query = $"Select * from company where comp_id = {Comp_id.ToString()} and comp_journ_id =0 ";
				if (!modAdminCommon.Exist(Query))
				{
					//if current company does not exist, get the latest non-current company
					journ_id = Convert.ToInt32(Conversion.Val($"{DMax("comp_journ_id", "Company", $"comp_id = {Comp_id.ToString()}")}"));
				}

				if (Comp_id > 0)
				{

					modCommon.Unload_Form("frm_Company");

					o_Local_Show_Company = frm_Company.CreateInstance();
					//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//VB.Global.Load(o_Local_Show_Company);
					o_Local_Show_Company.Form_Initialize();
					o_Local_Show_Company.StartForm = modGlobalVars.tStart_Form;
					o_Local_Show_Company.Reference_CompanyID = Comp_id;
					o_Local_Show_Company.Reference_CompanyJID = journ_id;
					o_Local_Show_Company.Show();
					//UPGRADE_WARNING: (2065) Form method o_Local_Show_Company.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
					o_Local_Show_Company.BringToFront();
					//UPGRADE_WARNING: (2065) Form event Form.Activated has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
					o_Local_Show_Company.Form_Activated(null, new EventArgs());

				}

				FG_ProgCompany.RowSel = HoldRow; //highlight row
				FG_ProgCompany.ColSel = 2;

			}
			this.Cursor = CursorHelper.CursorDefault;


		}

		public string DMax(string FldName, string RSName, string RSCriteria = "")
		{


			string result = "";
			ADORecordSetHelper adoData = new ADORecordSetHelper();

			string Query = $"Select Max({FldName}) from {RSName}";

			if (Strings.Len(($"{RSCriteria}").Trim()) > 0)
			{
				Query = $"{Query} where {RSCriteria}";
			}

			adoData.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

			if (adoData.EOF && adoData.BOF)
			{
				result = "";
				adoData.Close();
				adoData = null;
				return result;
			}

			adoData.MoveFirst();
			result = $"{Convert.ToString(adoData[0])}";

			adoData.Close();

			return result;
		}

		private void FG_Transactions_DoubleClick(Object eventSender, EventArgs eventArgs)
		{
			//load specific ac history

			if (ProgramLoadInProgress)
			{
				return;
			}

			int HoldRow = FG_Transactions.CurrentRowIndex;
			Stopped = false;

			if (HoldRow > 0)
			{

				this.Cursor = Cursors.WaitCursor;

				modAdminCommon.gbl_Aircraft_ID = Convert.ToInt32(Double.Parse(Convert.ToString(FG_Transactions[HoldRow, 4].Value)));
				modAdminCommon.gbl_Aircraft_Journal_ID = Convert.ToInt32(Double.Parse(Convert.ToString(FG_Transactions[HoldRow, 5].Value)));

				frm_aircraft.DefInstance.Form_Initialize();
				frm_aircraft.DefInstance.StartForm = modGlobalVars.tStart_Form;
				frm_aircraft.DefInstance.Reference_Aircraft_ID = modAdminCommon.gbl_Aircraft_ID;
				frm_aircraft.DefInstance.Reference_Journal_ID = modAdminCommon.gbl_Aircraft_Journal_ID;
				frm_aircraft.DefInstance.Reference_Company_ID = 0;
				frm_aircraft.DefInstance.Show();
				//UPGRADE_WARNING: (2065) Form method frm_aircraft.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
				frm_aircraft.DefInstance.BringToFront();
				//UPGRADE_WARNING: (2065) Form event Form.Activated has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
				frm_aircraft.DefInstance.Form_Activated(frm_aircraft.DefInstance, new EventArgs());

				FG_Transactions.RowSel = HoldRow;
				FG_Transactions.ColSel = 2;

			} // If HoldRow > 0 Then

			this.Cursor = CursorHelper.CursorDefault;

		} // FG_Transactions_DblClick


		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
		private void Form_Load()
		{
			//aey 5/17/05 display fractional detail

			ADORecordSetHelper RS_Table = new ADORecordSetHelper(); //Current recordset

			this.Cursor = Cursors.WaitCursor;


			Stopped = false;
			FG_ProgCompany.Visible = false;
			FG_ProgAircraft.Visible = false;
			FG_Transactions.Visible = false;
			SSTabHelper.SetSelectedIndex(DetailTab, 0);

			GrdSubscribers.Clear();

			cmdFracProgram.Items.Clear();
			cmdFracProgram.AddItem("None Selected");
			cmdFracProgram.SetItemData(cmdFracProgram.GetNewIndex(), 0);


			string Query = "SELECT * from Aircraft_programs ";
			Query = $"{Query} ORDER BY prog_name ";
			RS_Table.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

			if (!(RS_Table.BOF && RS_Table.EOF))
			{
				RS_Table.MoveFirst();

				while(!RS_Table.EOF)
				{
					cmdFracProgram.AddItem($"{StringsHelper.Format(Conversion.Val($"{Convert.ToString(RS_Table["Prog_id"])}"), "000")} - {Convert.ToString(RS_Table["prog_name"])}");
					cmdFracProgram.SetItemData(cmdFracProgram.GetNewIndex(), Convert.ToInt32(Conversion.Val($"{Convert.ToString(RS_Table["Prog_id"])}")));
					RS_Table.MoveNext();
				};
			}

			ListBoxHelper.SetSelectedIndex(cmdFracProgram, 0);
			RS_Table.Close();

			cmb_Models.Items.Clear();
			cmb_Models.AddItem("None Selected");
			cmb_Models.SetItemData(cmb_Models.GetNewIndex(), 0);

			Prog_id = 0;
			Comp_id = 0;
			AC_ID = 0;
			amod_id = 0;
			Select_ac_id = 0;

			ProgramLoadInProgress = false;

			this.Cursor = CursorHelper.CursorDefault;

		}


		private void GrdNotInTable_DoubleClick(Object eventSender, EventArgs eventArgs)
		{
			// load company
			string Query = "";
			frm_Company o_Local_Show_Company = null;

			journ_id = 0; //default=current company
			Stopped = false;

			if (ProgramLoadInProgress)
			{
				return;
			}

			int HoldRow = GrdNotInTable.CurrentRowIndex; //save for later
			if (HoldRow > 0)
			{
				this.Cursor = Cursors.WaitCursor;
				Application.DoEvents();

				if (Opt_notinTable[2].Checked)
				{
					GrdNotInTable.CurrentColumnIndex = 0;
				}
				else
				{
					GrdNotInTable.CurrentColumnIndex = 3;
				}

				Comp_id = Convert.ToInt32(Conversion.Val($"{GrdNotInTable[GrdNotInTable.CurrentRowIndex, GrdNotInTable.CurrentColumnIndex].FormattedValue.ToString()}")); //get company id

				Query = $"Select * from company WITH(NOLOCK) where comp_id = {Comp_id.ToString()} and comp_journ_id = 0";
				if (!modAdminCommon.Exist(Query))
				{
					//if current company does not exist, get the latest non-current company
					journ_id = Convert.ToInt32(Conversion.Val($"{DMax("comp_journ_id", "Company", $"comp_id = {Comp_id.ToString()}")}"));
				}

				if (Comp_id > 0)
				{

					modCommon.Unload_Form("frm_Company");
					o_Local_Show_Company = frm_Company.CreateInstance();
					//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//VB.Global.Load(o_Local_Show_Company);
					o_Local_Show_Company.Form_Initialize();
					o_Local_Show_Company.StartForm = modGlobalVars.tStart_Form;
					o_Local_Show_Company.Reference_CompanyID = Comp_id;
					o_Local_Show_Company.Reference_CompanyJID = journ_id;
					o_Local_Show_Company.Show();
					//UPGRADE_WARNING: (2065) Form method o_Local_Show_Company.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
					o_Local_Show_Company.BringToFront();
					//UPGRADE_WARNING: (2065) Form event Form.Activated has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
					o_Local_Show_Company.Form_Activated(null, new EventArgs());

				}
				GrdNotInTable.RowSel = HoldRow; //highlight row
				GrdNotInTable.ColSel = 3;

			}
			this.Cursor = CursorHelper.CursorDefault;

		}


		private void GrdSubscribers_DoubleClick(Object eventSender, EventArgs eventArgs)
		{
			//load aircraft
			Stopped = false;

			if (ProgramLoadInProgress)
			{
				return;
			}

			int HoldRow = GrdSubscribers.CurrentRowIndex;

			if (GrdSubscribers.CurrentRowIndex > 0)
			{

				this.Cursor = Cursors.WaitCursor;

				modAdminCommon.gbl_Aircraft_ID = Convert.ToInt32(Double.Parse(Convert.ToString(GrdSubscribers[HoldRow, 3].Value)));
				modAdminCommon.gbl_Aircraft_Journal_ID = 0;

				frm_aircraft.DefInstance.Form_Initialize();
				frm_aircraft.DefInstance.StartForm = modGlobalVars.tStart_Form;
				frm_aircraft.DefInstance.Reference_Aircraft_ID = modAdminCommon.gbl_Aircraft_ID;
				frm_aircraft.DefInstance.Reference_Journal_ID = modAdminCommon.gbl_Aircraft_Journal_ID;
				frm_aircraft.DefInstance.Reference_Company_ID = 0;
				frm_aircraft.DefInstance.Show();
				//UPGRADE_WARNING: (2065) Form method frm_aircraft.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
				frm_aircraft.DefInstance.BringToFront();
				//UPGRADE_WARNING: (2065) Form event Form.Activated has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
				frm_aircraft.DefInstance.Form_Activated(frm_aircraft.DefInstance, new EventArgs());

				GrdSubscribers.RowSel = HoldRow;
				GrdSubscribers.ColSel = 1;

			} // If GrdSubscribers.Row > 0 Then

			this.Cursor = CursorHelper.CursorDefault;

		} // GrdSubscribers_DblClick

		public void mnuClose_Click(Object eventSender, EventArgs eventArgs)
		{
			Stopped = true;
			Application.DoEvents();
			this.Close();
		}


		private bool isInitializingComponent;
		private void Opt_notinTable_CheckedChanged(Object eventSender, EventArgs eventArgs)
		{
			if (((RadioButton) eventSender).Checked)
			{
				if (isInitializingComponent)
				{
					return;
				}
				Application.DoEvents();
				lblTrans.Text = "";
				DetailTab_SelectedIndexChanged(DetailTab, new EventArgs());
			}
		}

		private void TranPrefix_CheckedChanged(Object eventSender, EventArgs eventArgs)
		{
			if (((RadioButton) eventSender).Checked)
			{
				if (isInitializingComponent)
				{
					return;
				}
				Application.DoEvents();
				lblTrans.Text = "";
				cmb_Models_SelectedIndexChanged(cmb_Models, new EventArgs());
			}
		}
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}