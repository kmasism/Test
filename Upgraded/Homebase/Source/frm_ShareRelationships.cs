using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
using System;
using System.Data.Common;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Gui.Controls;
using UpgradeHelpers.Gui.Utils;
using UpgradeHelpers.Helpers;
using UpgradeStubs;

namespace JETNET_Homebase
{
	internal partial class frm_ShareRelationships
		: System.Windows.Forms.Form
	{


		public int inACID = 0;
		public int incompid = 0;
		public int inContactId = 0;
		public int inJournID = 0;
		public int inCrefID = 0;
		public double inPercent = 0;
		public int FoundCompID = 0; // company id returned from company selection form
		public int FoundContactID = 0; // company id returned from company selection form
		public string FoundContactType = ""; // company id returned from company selection form
		public bool Activated_Renamed = false;

		private ADORecordSetHelper snpShareInfo = null;
		private modGlobalVars.e_find_form_action_types tCompFind_ActionTypes = (modGlobalVars.e_find_form_action_types) 0;
		private modGlobalVars.e_find_form_entry_points tCompFind_EntryPoints = (modGlobalVars.e_find_form_entry_points) 0;
		public frm_ShareRelationships()
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




		public modGlobalVars.e_find_form_entry_points EntryPoint
		{
			get => tCompFind_EntryPoints;
			set => tCompFind_EntryPoints = value;
		}



		public modGlobalVars.e_find_form_action_types ActionTypes
		{
			get => tCompFind_ActionTypes;
			set => tCompFind_ActionTypes = value;
		}


		private void FillRelationshipGrid()
		{


			grdRelationships.Clear();

			grdRelationships.ColumnsCount = 3;
			grdRelationships.RowsCount = 1;

			grdRelationships.CurrentRowIndex = 0;

			grdRelationships.CurrentColumnIndex = 0;
			grdRelationships[grdRelationships.CurrentRowIndex, grdRelationships.CurrentColumnIndex].Value = "Relationship";
			grdRelationships.CellBackColor = grdRelationships.BackColorFixed;
			grdRelationships.SetColumnWidth(0, 200);

			grdRelationships.CurrentColumnIndex = 1;
			grdRelationships[grdRelationships.CurrentRowIndex, grdRelationships.CurrentColumnIndex].Value = "Company";
			grdRelationships.CellBackColor = grdRelationships.BackColorFixed;
			grdRelationships.SetColumnWidth(1, 300);

			grdRelationships.CurrentColumnIndex = 2;
			grdRelationships[grdRelationships.CurrentRowIndex, grdRelationships.CurrentColumnIndex].Value = "Contact";
			grdRelationships.CellBackColor = grdRelationships.BackColorFixed;
			grdRelationships.SetColumnWidth(2, 300);

			cmdRemoveRelationship.Visible = false;
			string Query = $"SELECT * FROM Share_Reference WHERE sref_cref_id = {inCrefID.ToString()}";

			snpShareInfo = new ADORecordSetHelper();
			snpShareInfo.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

			grdRelationships.Visible = false;

			if (!(snpShareInfo.BOF && snpShareInfo.EOF))
			{


				while(!snpShareInfo.EOF)
				{
					grdRelationships.RowsCount++;
					grdRelationships.CurrentRowIndex = grdRelationships.RowsCount - 1;
					grdRelationships.SetRowHeight(grdRelationships.CurrentRowIndex, 67);
					grdRelationships.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

					grdRelationships.CurrentColumnIndex = 0;
					grdRelationships[grdRelationships.CurrentRowIndex, grdRelationships.CurrentColumnIndex].Value = GetTypeName(($"{Convert.ToString(snpShareInfo["sref_contact_type"])}").Trim());

					grdRelationships.CurrentColumnIndex = 1;
					grdRelationships[grdRelationships.CurrentRowIndex, grdRelationships.CurrentColumnIndex].Value = modCommon.GetCompanyInfo(Convert.ToInt32(Double.Parse(($"{Convert.ToString(snpShareInfo["sref_comp_id"])}").Trim())));

					grdRelationships.CurrentColumnIndex = 2;
					grdRelationships[grdRelationships.CurrentRowIndex, grdRelationships.CurrentColumnIndex].Value = GetContactInfo(Convert.ToInt32(Double.Parse(($"{Convert.ToString(snpShareInfo["sref_contact_id"])}").Trim())));

					snpShareInfo.MoveNext();

				};

				grdRelationships.FixedRows = 1;
				grdRelationships.FixedColumns = 0;

			}

			grdRelationships.Visible = true;
			grdRelationships.Redraw = true;

		}

		private string GetContactInfo(int inContactId)
		{

			string result = "";
			string Query = "";
			ADORecordSetHelper snpContactInfo = new ADORecordSetHelper();
			string M = "";

			if (inContactId > 0)
			{

				Query = "SELECT contact_first_name, contact_last_name, contact_title";
				Query = $"{Query} FROM Contact WHERE contact_id = {inContactId.ToString()} AND contact_journ_id = 0";

				snpContactInfo.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpContactInfo.BOF && snpContactInfo.EOF))
				{
					M = $"{($"{Convert.ToString(snpContactInfo["contact_first_name"])}").Trim()} ";
					M = $"{M}{($"{Convert.ToString(snpContactInfo["contact_last_name"])}").Trim()} [";
					M = $"{M}{($"{Convert.ToString(snpContactInfo["contact_title"])}").Trim()}]";

				}
				else
				{
					M = "";
				}

				result = M;

				snpContactInfo.Close();
				snpContactInfo = null;

			}
			else
			{
				result = "";
			}

			return result;
		}



		private string GetTypeName(string inContactType)
		{

			string result = "";
			ADORecordSetHelper snpType = new ADORecordSetHelper();

			string Query = $"SELECT actype_name FROM Aircraft_Contact_Type WHERE actype_code = '{inContactType}'";

			snpType.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

			if (!(snpType.BOF && snpType.EOF))
			{
				result = ($"{Convert.ToString(snpType["actype_name"])}").Trim();
			}
			else
			{
				result = "";
			}

			snpType.Close();

			return result;
		}

		private void InitializeForm()
		{

			string Query = "";
			ADORecordSetHelper snpAC = new ADORecordSetHelper(); //8/16/05 aey
			ADORecordSetHelper snpContactType = new ADORecordSetHelper();

			if (inCrefID > 0)
			{

				Query = "SELECT actype_name FROM Aircraft_Contact_Type, Aircraft_Reference";
				Query = $"{Query} WHERE cref_id = {inCrefID.ToString()} AND cref_contact_type = actype_code";

				snpContactType.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!snpContactType.BOF && !snpContactType.EOF)
				{
					lblTitle.Text = $"{($"{Convert.ToString(snpContactType["actype_name"])}").Trim()}{Environment.NewLine}Share - {inPercent.ToString()}%";
				}
				snpContactType.Close();
				snpContactType = null;

			} // If inCrefID > 0 Then

			if (inACID > 0)
			{

				Query = "SELECT ac_ser_no_full, ac_year, amod_id, amod_make_name, amod_model_name";
				Query = $"{Query} FROM Aircraft, Aircraft_Model WHERE ac_amod_id = amod_id";
				Query = $"{Query} AND ac_id = {inACID.ToString()} AND ac_journ_id = {inJournID.ToString()}";

				snpAC.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!snpAC.BOF && !snpAC.EOF)
				{
					lst_Aircraft.Items.Clear();
					lst_Aircraft.AddItem($"Make/Model: {($"{Convert.ToString(snpAC["amod_make_name"])}").Trim()}/{($"{Convert.ToString(snpAC["amod_model_name"])}").Trim()}");
					lst_Aircraft.AddItem($"Serial#: {($"{Convert.ToString(snpAC["ac_ser_no_full"])}").Trim()}");
					lst_Aircraft.AddItem($"Year: {($"{Convert.ToString(snpAC["ac_year"])}").Trim()}");
					lst_Aircraft.SetItemData(0, Convert.ToInt32(Double.Parse(($"{Convert.ToString(snpAC["amod_id"])}").Trim())));
				}
				snpAC.Close();
				snpAC = null;

			} // If inACID > 0 Then

			modCommon.Build_Company_NameAddress(lst_Company, incompid, inJournID);
			if (inContactId > 0)
			{
				modCommon.Build_Contact_Info(lst_Contact, inContactId, inJournID, false);
			}

			FillRelationshipGrid();

			//UPGRADE_WARNING: (2065) Form method frm_ShareRelationships.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
			this.BringToFront();

		}

		private void cmd_close_Click(Object eventSender, EventArgs eventArgs)
		{

			Form Frm = null;
			Form f = null;

			foreach (Form FrmIterator in Application.OpenForms)
			{
				Frm = FrmIterator;
				f = Frm;
				if (f.Name.Trim() == "frm_Aircraft")
				{
					//UPGRADE_TODO: (1067) Member Fill_Aircraft_Contact_Grid is not defined in type VB.Form. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					(f as frm_aircraft).Fill_Aircraft_Contact_Grid();//gap-note cast to frm_aircraft
					break;
				}
				Frm = default(Form);
			}

			this.Close();

		}

		private void cmdAddRelationship_Click(Object eventSender, EventArgs eventArgs)
		{

			tCompFind_ActionTypes = modGlobalVars.e_find_form_action_types.geIdCompany;

			if (modGlobalVars.bCallShowAndLoadOnlyOnce)
			{

				//UPGRADE_TODO: (1067) Member Clear_Search_Criteria is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_MISC].Clear_Search_Criteria(true, true, true);
				//UPGRADE_TODO: (1067) Member EntryPoint is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_MISC].EntryPoint = modGlobalVars.e_find_form_entry_points.geAddShareRelation;
				//UPGRADE_TODO: (1067) Member ActionTypes is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_MISC].ActionTypes = tCompFind_ActionTypes;
				//UPGRADE_TODO: (1067) Member Show is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_MISC].Show();
				//UPGRADE_TODO: (1067) Member ZOrder is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_MISC].ZOrder(0);

			}

		}

		private void cmdRemoveRelationship_Click(Object eventSender, EventArgs eventArgs) => Remove_Share_Relationship();


		public void Form_Activated(Object eventSender, EventArgs eventArgs)
		{
			if (ActivateHelper.myActiveForm != eventSender)
			{
				ActivateHelper.myActiveForm = (Form) eventSender;

				FoundCompID = 0;
				FoundContactID = 0;
				FoundContactType = "";

				if (modCommon.pubf_EncodeEntryPoints(tCompFind_EntryPoints) == modGlobalVars.gFIND_ASHR)
				{

					//UPGRADE_TODO: (1067) Member GetFormExitValues is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					FoundCompID = Convert.ToInt32(modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_MISC].GetFormExitValues(modGlobalVars.gcFOUNDCOMPANYID));
					//UPGRADE_TODO: (1067) Member GetFormExitValues is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					FoundContactID = Convert.ToInt32(modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_MISC].GetFormExitValues(modGlobalVars.gcFOUNDCONTACTID));
					//UPGRADE_TODO: (1067) Member GetFormExitValues is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					FoundContactType = Convert.ToString(modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_MISC].GetFormExitValues(modGlobalVars.gcFOUNDCONTACTTYPE));

				}

				if (modCommon.pubf_EncodeEntryPoints(tCompFind_EntryPoints) == modGlobalVars.gFIND_ASHR && FoundCompID != 0)
				{

					Insert_Share_Relationship();

					grdRelationships.Redraw = true;

					//UPGRADE_TODO: (1067) Member Clear_Search_Criteria is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_MISC].Clear_Search_Criteria(true, true, true);

				}

				//UPGRADE_WARNING: (2065) Form method frm_ShareRelationships.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
				Support.ZOrder(this, 0);

			}
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
		private void Form_Load()
		{

			modCommon.CenterFormOnHomebaseMainForm(this);
			InitializeForm();

		}

		public void Insert_Share_Relationship()
		{
			string Query = "";
			try
			{
				string[] arrTempArray = new string[]{"", ""};

				Query = "INSERT INTO Share_Reference (sref_cref_id, sref_comp_id, sref_contact_id, sref_contact_type) ";
				Query = $"{Query}VALUES ({inCrefID.ToString()},{FoundCompID.ToString()},{FoundContactID.ToString()},";
				Query = $"{Query}'{FoundContactType}')";

				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = Query;
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery(); //6/21/04 aey

				modCommon.ClearAircraftActionDate(inACID, inJournID);

				modAdminCommon.ADO_Transaction("BeginTrans");
				modAdminCommon.Record_Transmit(inACID.ToString(), 0, inJournID, lst_Aircraft.GetItemData(0), "Fractional Owner", "Change", ref arrTempArray, incompid);
				modAdminCommon.ADO_Transaction("CommitTrans");

				FillRelationshipGrid();
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"Error inserting share: {Query}: {excep.Message}");
			}

		}

		public void Remove_Share_Relationship()
		{
			string Query = "";
			try
			{
				DialogResult intPress = (DialogResult) 0;

				string[] arrTempArray = new string[]{"", ""};

				intPress = MessageBox.Show("Would you like to remove the highlighted relationship?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo);
				if (intPress == System.Windows.Forms.DialogResult.No)
				{
					MessageBox.Show("Relationhip Removal Cancelled.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					return;
				}
				Query = $"delete from Share_Reference where sref_id={Convert.ToString(snpShareInfo["sref_id"])}";

				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = Query;
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery(); //6/21/04 aey

				modCommon.ClearAircraftActionDate(inACID, inJournID);

				modAdminCommon.ADO_Transaction("BeginTrans");
				modAdminCommon.Record_Transmit(inACID.ToString(), 0, inJournID, lst_Aircraft.GetItemData(0), "Fractional Owner", "Change", ref arrTempArray, incompid);
				modAdminCommon.ADO_Transaction("CommitTrans");
				FillRelationshipGrid();
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"Error removing share: {Query}: {excep.Message}");
			}

		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{

			snpShareInfo.Close();
			snpShareInfo = null;

		}

		private void grdRelationships_Click(Object eventSender, EventArgs eventArgs)
		{

			if (grdRelationships.CurrentRowIndex > 0)
			{
				cmdRemoveRelationship.Visible = true;
				snpShareInfo.MoveFirst();
				int tempForEndVar = grdRelationships.CurrentRowIndex - 1;
				for (int i = 1; i <= tempForEndVar; i++)
				{
					snpShareInfo.MoveNext();
				}
			}
			else
			{
				cmdRemoveRelationship.Visible = false;
			}

		}
	}
}