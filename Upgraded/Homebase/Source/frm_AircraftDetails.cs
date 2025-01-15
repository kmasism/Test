using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
using System;
using System.Data.Common;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Gui.Controls;
using UpgradeHelpers.Helpers;
using UpgradeStubs;

namespace JETNET_Homebase
{
	internal partial class frm_AircraftDetails
		: System.Windows.Forms.Form
	{

		public frm_AircraftDetails()
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


		private void frm_AircraftDetails_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		//******************************************************************************************
		//***** VB Compress Pro 6.11.32 generated this copy of frm_AircraftDetails.frm on Mon 6/17/0
		//***** Mode: AutoSelect Standard Mode (Internal References Only)***************************
		//******************************************************************************************

		public int DetailID = 0;
		public bool UpdateMode = false;
		public string DetailType = "";
		public int inACID = 0;
		public int inJournID = 0;

		private void DeleteDetail() => frm_aircraft.DefInstance.DetailName = "Delete";


		private void FillAircraftInfoList()
		{

			string Query = "";
			ADORecordSetHelper snp_AircraftInfo = new ADORecordSetHelper(); //8/1/05 aey converted to ado

			try
			{

				lst_aircraft_info.Items.Clear();

				Query = "Select amod_make_name,amod_model_name,ac_ser_no_full,ac_year ";
				Query = $"{Query}from Aircraft WITH(NOLOCK) ";
				Query = $"{Query}inner join Aircraft_Model WITH(NOLOCK) on amod_id=ac_amod_id ";
				Query = $"{Query}where ac_id={inACID.ToString()}";
				//Query = Query & " and amod_id=ac_amod_id"
				//Set snp_AircraftInfo = LOCAL_DB.OpenRecordset(Query, dbOpenSnapshot, dbSQLPassThrough)
				snp_AircraftInfo.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_AircraftInfo.BOF && snp_AircraftInfo.EOF))
				{
					snp_AircraftInfo.MoveLast();
					snp_AircraftInfo.MoveFirst();
					lst_aircraft_info.AddItem($"MAKE/MODEL: {($"{Convert.ToString(snp_AircraftInfo["amod_make_name"])} ").Trim()}/{($"{Convert.ToString(snp_AircraftInfo["amod_model_name"])} ").Trim()}");
					lst_aircraft_info.AddItem($"SERIAL#: {($"{Convert.ToString(snp_AircraftInfo["ac_ser_no_full"])} ").Trim()}");
					lst_aircraft_info.AddItem($"YEAR: {($"{Convert.ToString(snp_AircraftInfo["ac_year"])} ").Trim()}");
				}

				snp_AircraftInfo.Close();
				snp_AircraftInfo = null;
			}
			catch (System.Exception excep)
			{
				modAdminCommon.Report_Error($"FillAircraftInfoList_Error: {excep.Message}", "AircraftDetails");
				this.Cursor = CursorHelper.CursorDefault;
			}
		}

		private void FillDetailNames()
		{

			string Query = "";
			ADORecordSetHelper snpDetailNames = new ADORecordSetHelper(); //8/1/05 aey converted to ado

			try
			{

				cbo_adet_data_name.Items.Clear();

				Query = "SELECT adt_data_name, adt_data_length ";
				Query = $"{Query}FROM Aircraft_Data_Type WITH(NOLOCK) ";
				Query = $"{Query}WHERE adt_data_type = '{DetailType}' ";
				if (DetailType.Trim() == "Maintenance")
				{
					Query = $"{Query}ORDER BY  adt_seq_no asc, adt_data_name";
				}
				else
				{
					Query = $"{Query}ORDER BY adt_data_name";
				}

				//Set snpDetailNames = LOCAL_DB.OpenRecordset(Query, dbOpenSnapshot, dbSQLPassThrough)
				snpDetailNames.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpDetailNames.BOF && snpDetailNames.EOF))
				{
					snpDetailNames.MoveFirst();

					while(!snpDetailNames.EOF)
					{
						cbo_adet_data_name.AddItem(($"{Convert.ToString(snpDetailNames["adt_data_name"])}").Trim());
						cbo_adet_data_name.SetItemData(cbo_adet_data_name.Items.Count - 1, Convert.ToInt32(Conversion.Val(($"{Convert.ToString(snpDetailNames["adt_data_length"])}").Trim())));
						snpDetailNames.MoveNext();
					};
				}

				snpDetailNames.Close();

				snpDetailNames = null;
			}
			catch (System.Exception excep)
			{
				modAdminCommon.Report_Error($"FillDetailNames_Error: {excep.Message}", "User_Accounts");
				this.Cursor = CursorHelper.CursorDefault;

			}

		}

		private void GetAircraftDetails()
		{

			string Query = "";
			ADORecordSetHelper snpDetails = new ADORecordSetHelper(); //8/1/05 aey converted to ado

			try
			{

				Query = "SELECT * FROM Aircraft_Details WITH(NOLOCK) ";
				Query = $"{Query}WHERE adet_id = {DetailID.ToString()}";

				//Set snpDetails = LOCAL_DB.OpenRecordset(Query, dbOpenSnapshot, dbSQLPassThrough)
				snpDetails.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpDetails.BOF && snpDetails.EOF))
				{
					snpDetails.MoveFirst();
					int tempForEndVar = cbo_adet_data_name.Items.Count - 1;
					for (int i = 0; i <= tempForEndVar; i++)
					{
						if (($"{Convert.ToString(snpDetails["adet_data_name"])}").Trim() == cbo_adet_data_name.GetListItem(i).Trim())
						{
							cbo_adet_data_name.SelectedIndex = i;
							break;
						}
					}
					txt_adet_data_description.MaxLength = 0;
					txt_adet_data_description.Text = ($"{Convert.ToString(snpDetails["adet_data_description"])}").Trim();
					if (cbo_adet_data_name.SelectedIndex > -1)
					{
						if (Conversion.Val(cbo_adet_data_name.GetItemData(cbo_adet_data_name.SelectedIndex).ToString()) > 0)
						{
							txt_adet_data_description.MaxLength = Convert.ToInt32(Conversion.Val(cbo_adet_data_name.GetItemData(cbo_adet_data_name.SelectedIndex).ToString()));
						}
						else
						{
							txt_adet_data_description.MaxLength = 350;
						}
					}
					else
					{
						txt_adet_data_description.MaxLength = 350;
					}

					if (Strings.Len(txt_adet_data_description.Text) > txt_adet_data_description.MaxLength)
					{
						cmdSave.Enabled = false;
						lblMessage.Text = "Size Exceeded!  Please reduce the length of the description before saving!";
					}

				}

				snpDetails.Close();
				snpDetails = null;
			}
			catch (System.Exception excep)
			{
				modAdminCommon.Report_Error($"GetAircraftDetails_Error: {excep.Message}", "AircraftDetails");
				this.Cursor = CursorHelper.CursorDefault;

			}

		}

		private void InsertAircraftDetail()
		{


			frm_aircraft.DefInstance.DetailName = modCommon.RemoveAllInvisibleChars(modCommon.RemoveAllSpecificCharacters(cbo_adet_data_name.Text)).Trim();
			frm_aircraft.DefInstance.DetailDescription = modCommon.RemoveAllInvisibleChars(modCommon.RemoveAllSpecificCharacters(txt_adet_data_description.Text)).Trim();
			frm_aircraft.DefInstance.DetailType = modCommon.RemoveAllInvisibleChars(modCommon.RemoveAllSpecificCharacters(modAdminCommon.Fix_Quote(DetailType))).Trim();


		}

		private void UpdateAircraftDetail()
		{


			frm_aircraft.DefInstance.DetailDescription = modCommon.RemoveAllInvisibleChars(modCommon.RemoveAllSpecificCharacters(txt_adet_data_description.Text)).Trim();
			frm_aircraft.DefInstance.DetailType = modCommon.RemoveAllInvisibleChars(modCommon.RemoveAllSpecificCharacters(modAdminCommon.Fix_Quote(DetailType))).Trim();
			frm_aircraft.DefInstance.DetailName = modCommon.RemoveAllInvisibleChars(modCommon.RemoveAllSpecificCharacters(cbo_adet_data_name.Text)).Trim();


		}

		private void cbo_adet_data_name_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{

			txt_adet_data_description.MaxLength = Convert.ToInt32(Conversion.Val(cbo_adet_data_name.GetItemData(cbo_adet_data_name.SelectedIndex).ToString()));

			if (Strings.Len(txt_adet_data_description.Text) > txt_adet_data_description.MaxLength)
			{
				cmdSave.Enabled = false;
				lblMessage.Text = "Size Exceeded!  Please reduce the length of the description beofore saving!";
			}

		}

		private void cmd_Close_Click(Object eventSender, EventArgs eventArgs) => this.Close();


		private void cmdDelete_Click(Object eventSender, EventArgs eventArgs)
		{

			if (MessageBox.Show("Are you sure you want to delete this Aircraft Detail?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
			{
				DeleteDetail();
				//MsgBox "Delete Successful"
				this.Close();
			}

		}

		private void cmdSave_Click(Object eventSender, EventArgs eventArgs)
		{


			if (DetailID > 0)
			{
				UpdateAircraftDetail();
				this.Close();
			}
			else
			{
				InsertAircraftDetail();
				this.Close();
			}

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
		private void Form_Load()
		{
			modCommon.CenterFormOnHomebaseMainForm(this);

			FillDetailNames();

			Application.DoEvents();

			if (DetailID > 0)
			{
				cmdDelete.Enabled = true;
				//UPGRADE_ISSUE: (2064) ComboBox property cbo_adet_data_name.Locked was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				cbo_adet_data_name.setLocked(true);
				lblTitle.Text = DetailType;
				FillAircraftInfoList();
				GetAircraftDetails();
			}
			else
			{
				cmdDelete.Enabled = false;
				lblTitle.Text = DetailType;
				FillAircraftInfoList();
				if (!UpdateMode)
				{
					cbo_adet_data_name.SelectedIndex = 0;
				}
			}

			if (UpdateMode)
			{
				UpdateMode = false;
				cmdDelete.Enabled = true;
				//UPGRADE_ISSUE: (2064) ComboBox property cbo_adet_data_name.Locked was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				cbo_adet_data_name.setLocked(true);
			}

			this.Cursor = CursorHelper.CursorDefault;

		}

		private void txt_adet_data_description_KeyUp(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{

				if (Strings.Len(txt_adet_data_description.Text) <= txt_adet_data_description.MaxLength)
				{
					cmdSave.Enabled = true;
					lblMessage.Text = "";
				}
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}

		}
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}