using System;
using System.Data.Common;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;

namespace JETNET_Homebase
{
	internal partial class frm_AircraftSettings
		: System.Windows.Forms.Form
	{

		public frm_AircraftSettings()
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


		private void frm_AircraftSettings_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		//******************************************************************************************


		public string inTrans_Type = "";
		public string inJournal_Code = ""; // RTW - 3/31/2004 - IDENTIES THE CODE TO BE USED ON THE TRANSACTION
		public bool inCorrection_Flag = false;
		public bool inInternal_Flag = false;
		public bool inHistorical_Flag = false;
		public bool inAvailable_flag = false;
		public bool inNewUsed = false; //  RTW - 3/30/2004 - ADDED TO SUPPORT NEW VS USED FEATURES

		private void cmd_cancel_Click(Object eventSender, EventArgs eventArgs)
		{
			frm_Aircraft_Change.DefInstance.Aircraft_Settings = false;
			this.Close();
		}

		private void cmd_OK_Click(Object eventSender, EventArgs eventArgs)
		{
			frm_Aircraft_Change.DefInstance.Clear_Availability = opt_avail_clear.Checked;

			frm_Aircraft_Change.DefInstance.Clear_Contacts = opt_contact_clear.Checked;

			frm_Aircraft_Change.DefInstance.Clear_Base = opt_base_clear.Checked;

			frm_Aircraft_Change.DefInstance.Clear_Specifications = opt_spec_clear.Checked;
			frm_Aircraft_Change.DefInstance.Aircraft_Settings = true;

			frm_Aircraft_Change.DefInstance.AircraftUsed = opt_Used.Checked;
			this.Close();
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
		private void Form_Load()
		{

			opt_avail_leave.Checked = true;
			opt_contact_leave.Checked = true;
			opt_base_leave.Checked = true;
			opt_spec_leave.Checked = true;
			// IF THE TRANSACTION IS A WHOLE SALE AND NOT AN INTERNAL
			// OR A CORRECTION THEN PROCEED WITH NEW VS USED ACTION ITEMS
			if ((inJournal_Code.StartsWith("WS", StringComparison.Ordinal) || inJournal_Code.StartsWith("L", StringComparison.Ordinal)) && inJournal_Code.Substring(Math.Max(inJournal_Code.Length - 2, 0)) != "IT" && inJournal_Code.Substring(Math.Max(inJournal_Code.Length - 4, 0)) != "CORR" && frm_Aircraft_Change.DefInstance.chk_NewAircraft.CheckState == CheckState.Unchecked)
			{
				if (Aircraft_New(modAdminCommon.gbl_Aircraft_ID))
				{
					pnl_newused.Visible = true;
					// RTW - 3/30/2004 - ADDED TO SUPPORT
					if (Last_Transaction_New_To_Market(modAdminCommon.gbl_Aircraft_ID))
					{
						opt_Used.Checked = true;
					}
					else
					{
						opt_New.Checked = true;
					}
				}
				else
				{
					// DO NOT SHOW THAT NEW VS USED PANEL
					pnl_newused.Visible = false;
				}
			}
			else
			{
				// DO NOT SHOW THAT NEW VS USED PANEL
				pnl_newused.Visible = false;
			}

			if (inTrans_Type == "WS" && !inInternal_Flag && !inCorrection_Flag)
			{
				opt_avail_clear.Checked = true;
				opt_contact_clear.Checked = true;
				opt_base_clear.Checked = true;
				opt_spec_leave.Checked = true;
			}
			if (inTrans_Type == "LO")
			{ // for lease off markets
				opt_avail_clear.Checked = true;
				opt_avail_clear.Enabled = false;
				opt_avail_leave.Enabled = false;
			}
			// IF AIRCRAFT IS NOT AVAILABLE DISABLE THE CLEAR AVAILABILITY AREA
			if (!inAvailable_flag)
			{
				opt_avail_clear.Checked = true;
				opt_avail_clear.Enabled = false;
				opt_avail_leave.Enabled = false;
			}

			if ((inTrans_Type == "FC" || inTrans_Type == "SZ") && !inInternal_Flag && !inCorrection_Flag)
			{
				opt_contact_clear.Checked = true;
				opt_base_clear.Checked = true;
			}
		}

		private bool Last_Transaction_New_To_Market(int inAC_ID)
		{

			bool result = false;
			try
			{
				ADORecordSetHelper snp_Exist = new ADORecordSetHelper();
				string Query = "";

				Query = "SELECT TOP 1 * From Journal ";
				Query = $"{Query}WHERE journ_ac_id = {inAC_ID.ToString()} ";
				// RTW - 3/31/2004 - CHANGED PER DISCUSSION WITH LU TO
				// FIND ANY NEW TO MARKET TRANSACTION
				Query = $"{Query}AND (journ_subcategory_code LIKE 'WS%' or journ_subcategory_code LIKE 'L%') ";
				Query = $"{Query}AND (journ_subcategory_code not like '%CORR') ";
				Query = $"{Query}AND (journ_subcategory_code not like '%IT') ";
				Query = $"{Query}AND (journ_newac_flag='Y') ";
				Query = $"{Query}ORDER BY journ_date desc,journ_id DESC";

				result = false;

				snp_Exist.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
				result = !(snp_Exist.BOF && snp_Exist.EOF);
				snp_Exist.Close();
				snp_Exist = null;
			}
			catch
			{
				result = false;
			}

			return result;
		}

		private bool Aircraft_New(int inAC_ID)
		{

			bool result = false;
			try
			{
				ADORecordSetHelper snp_Exist = new ADORecordSetHelper();
				string Query = "";

				Query = "SELECT ac_previously_owned_flag From Aircraft ";
				Query = $"{Query}WHERE ac_id = {inAC_ID.ToString()} ";
				Query = $"{Query}AND (ac_journ_id = 0) ";

				result = false;

				snp_Exist.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
				if (!(snp_Exist.BOF && snp_Exist.EOF))
				{
					if (Convert.ToString(snp_Exist["ac_previously_owned_flag"]) == "N")
					{
						result = true;
					}
				}
				else
				{
					result = false;
				}
				snp_Exist.Close();
				snp_Exist = null;
			}
			catch
			{
				result = false;
			}

			return result;
		}
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}