using Microsoft.VisualBasic;
using System;
using System.Data.Common;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Gui.Controls;
using UpgradeStubs;

namespace JETNET_Homebase
{
	internal static class modFillAircraftControls
	{


		internal static bool Fill_Aircraft_Owner_Type_CBO(ComboBox cbo_to_fill)
		{
			string strQuery = "";
			ADORecordSetHelper snpAircraftOwnerType = new ADORecordSetHelper(); //aey 6/10/04

			try
			{

				cbo_to_fill.Enabled = false;
				cbo_to_fill.Items.Clear();
				cbo_to_fill.AddItem("");

				strQuery = "SELECT acot_code,acot_name FROM Aircraft_Owner_Type WITH(NOLOCK)";

				snpAircraftOwnerType.Open(strQuery, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpAircraftOwnerType.BOF && snpAircraftOwnerType.EOF))
				{

					while(!snpAircraftOwnerType.EOF)
					{
						cbo_to_fill.AddItem($"{($"{Convert.ToString(snpAircraftOwnerType["acot_code"])} ").Trim()} - {($"{Convert.ToString(snpAircraftOwnerType["acot_name"])} ").Trim()}");
						snpAircraftOwnerType.MoveNext();
					};
				}

				if (cbo_to_fill.Items.Count > 0)
				{
					cbo_to_fill.SelectedIndex = 0;
				}
				else
				{
					cbo_to_fill.SelectedIndex = -1;
				}

				cbo_to_fill.Enabled = true;

				snpAircraftOwnerType.Close();
				snpAircraftOwnerType = null;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_Aircraft_Owner_Type_CBO_Error: {Information.Err().Number.ToString()} {excep.Message}");
			}

			return false;
		}

		internal static bool Fill_Aircraft_Stage_CBO(ComboBox cbo_to_fill)
		{

			string strQuery = "";
			ADORecordSetHelper snpAircraftStage = new ADORecordSetHelper(); //aey 6/10/04

			try
			{

				cbo_to_fill.Enabled = false;
				cbo_to_fill.Items.Clear();
				cbo_to_fill.AddItem("");

				strQuery = "SELECT * FROM Aircraft_Stage WITH(NOLOCK) ORDER BY acs_code";

				snpAircraftStage.Open(strQuery, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpAircraftStage.BOF && snpAircraftStage.EOF))
				{

					while(!snpAircraftStage.EOF)
					{
						cbo_to_fill.AddItem($"{($"{Convert.ToString(snpAircraftStage["acs_code"])} ").Trim()} - {($"{Convert.ToString(snpAircraftStage["acs_name"])} ").Trim()}");
						snpAircraftStage.MoveNext();
					};
				}

				if (cbo_to_fill.Items.Count > 0)
				{
					cbo_to_fill.SelectedIndex = 0;
				}
				else
				{
					cbo_to_fill.SelectedIndex = -1;
				}

				cbo_to_fill.Enabled = true;

				snpAircraftStage.Close();
				snpAircraftStage = null;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_Aircraft_Stage_CBO_Error: {Information.Err().Number.ToString()} {excep.Message}");
			}

			return false;
		}
		internal static bool Fill_Engine_Management_CBO_From_Array(ComboBox cbo_to_fill)
		{

			if (modGlobalVars.bEngine1_IsLoaded)
			{
				cbo_to_fill.Enabled = false;
				cbo_to_fill.Items.Clear();
				cbo_to_fill.AddItem("");

				int tempForEndVar = modGlobalVars.Engine_Array1.GetUpperBound(0);
				for (int a_row = modGlobalVars.Engine_Array1.GetLowerBound(0); a_row <= tempForEndVar; a_row++)
				{
					cbo_to_fill.AddItem(modGlobalVars.Engine_Array1[a_row]);
					cbo_to_fill.SetItemData(cbo_to_fill.Items.Count - 1, Convert.ToInt32(Double.Parse($"0{modGlobalVars.Engine_ArrayData[a_row]}")));
				}

				if (cbo_to_fill.Items.Count > 0)
				{
					cbo_to_fill.SelectedIndex = 0;
				}
				else
				{
					cbo_to_fill.SelectedIndex = -1;
				}

			}
			cbo_to_fill.Enabled = true;

			return false;
		}
		internal static bool Fill_Engine_Management_CBO(ComboBox cbo_to_fill)
		{

			string Query = "";
			ADORecordSetHelper snpEng = new ADORecordSetHelper(); //aey 6/10/04

			try
			{

				cbo_to_fill.Enabled = false;
				cbo_to_fill.Items.Clear();
				cbo_to_fill.AddItem("");

				Query = "SELECT * FROM Engine_Management_Program WITH(NOLOCK) ORDER BY emgp_provider_name, emgp_program_name";

				snpEng.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

				if (!(snpEng.BOF && snpEng.EOF))
				{

					while(!snpEng.EOF)
					{

						cbo_to_fill.AddItem($"{($"{Convert.ToString(snpEng["emgp_provider_name"])}").Trim()} - {($"{Convert.ToString(snpEng["emgp_program_name"])}").Trim()}");
						cbo_to_fill.SetItemData(cbo_to_fill.Items.Count - 1, Convert.ToInt32(Double.Parse($"0{($"{Convert.ToString(snpEng["emgp_id"])}").Trim()}")));

						snpEng.MoveNext();
					};
				}

				snpEng.Close();
				snpEng = null;

				if (cbo_to_fill.Items.Count > 0)
				{
					cbo_to_fill.SelectedIndex = 0;
				}
				else
				{
					cbo_to_fill.SelectedIndex = -1;
				}

				cbo_to_fill.Enabled = true;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_Engine_Management_CBO_Error: {Information.Err().Number.ToString()} {excep.Message}");
			}

			return false;
		}

		internal static bool Fill_Airframe_Maintenance_Program_CBO(ComboBox cbo_to_fill)
		{

			string Query = "";
			ADORecordSetHelper snpMaintProg = new ADORecordSetHelper(); //aey 6/10/04

			try
			{

				cbo_to_fill.Enabled = false;
				cbo_to_fill.Items.Clear();
				cbo_to_fill.AddItem("");

				Query = "SELECT * FROM Airframe_Maintenance_Program WITH(NOLOCK) ORDER BY amp_provider_name, amp_program_name";

				snpMaintProg.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpMaintProg.BOF && snpMaintProg.EOF))
				{


					while(!snpMaintProg.EOF)
					{

						cbo_to_fill.AddItem($"{($"{Convert.ToString(snpMaintProg["amp_provider_name"])}").Trim()} - {($"{Convert.ToString(snpMaintProg["amp_program_name"])}").Trim()}");
						cbo_to_fill.SetItemData(cbo_to_fill.Items.Count - 1, Convert.ToInt32(Double.Parse($"0{($"{Convert.ToString(snpMaintProg["amp_id"])}").Trim()}")));

						snpMaintProg.MoveNext();
					};
				}

				snpMaintProg.Close();
				snpMaintProg = null;

				if (cbo_to_fill.Items.Count > 0)
				{
					cbo_to_fill.SelectedIndex = 0;
				}
				else
				{
					cbo_to_fill.SelectedIndex = -1;
				}

				cbo_to_fill.Enabled = true;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_Airframe_Maintenance_Program_CBO_Error: {Information.Err().Number.ToString()} {excep.Message}");
			}

			return false;
		}

		internal static bool Fill_Airframe_Tracking_CBO(ComboBox cbo_to_fill)
		{

			string Query = "";
			ADORecordSetHelper snpTracking = new ADORecordSetHelper(); //aey 6/10/04

			try
			{

				cbo_to_fill.Enabled = false;
				cbo_to_fill.Items.Clear();
				cbo_to_fill.AddItem("");

				Query = "SELECT * FROM Airframe_Maintenance_Tracking_Program WITH(NOLOCK) ORDER BY amtp_provider_name, amtp_program_name";

				snpTracking.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpTracking.BOF && snpTracking.EOF))
				{


					while(!snpTracking.EOF)
					{

						cbo_to_fill.AddItem($"{($"{Convert.ToString(snpTracking["amtp_provider_name"])}").Trim()} - {($"{Convert.ToString(snpTracking["amtp_program_name"])}").Trim()}");
						cbo_to_fill.SetItemData(cbo_to_fill.Items.Count - 1, Convert.ToInt32(Double.Parse($"0{($"{Convert.ToString(snpTracking["amtp_id"])}").Trim()}")));

						snpTracking.MoveNext();
					};
				}

				snpTracking.Close();
				snpTracking = null;

				if (cbo_to_fill.Items.Count > 0)
				{
					cbo_to_fill.SelectedIndex = 0;
				}
				else
				{
					cbo_to_fill.SelectedIndex = -1;
				}

				cbo_to_fill.Enabled = true;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_Airframe_Tracking_CBO_Error: {Information.Err().Number.ToString()} {excep.Message}");
			}

			return false;
		}

		internal static bool Fill_Airframe_Maintenance_Program_CBO_From_Array(ComboBox cbo_to_fill)
		{


			if (modGlobalVars.bAirframeMaintProg_IsLoaded)
			{
				cbo_to_fill.Enabled = false;
				cbo_to_fill.Items.Clear();
				cbo_to_fill.AddItem("");

				int tempForEndVar = modGlobalVars.Airframe_Maint_Prog.GetUpperBound(0);
				for (int a_row = modGlobalVars.Airframe_Maint_Prog.GetLowerBound(0); a_row <= tempForEndVar; a_row++)
				{
					cbo_to_fill.AddItem(modGlobalVars.Airframe_Maint_Prog[a_row]);
					cbo_to_fill.SetItemData(cbo_to_fill.Items.Count - 1, Convert.ToInt32(Double.Parse($"0{modGlobalVars.Airframe_Maint_Prog_Data[a_row]}")));
				}

				if (cbo_to_fill.Items.Count > 0)
				{
					cbo_to_fill.SelectedIndex = 0;
				}
				else
				{
					cbo_to_fill.SelectedIndex = -1;
				}

			}
			cbo_to_fill.Enabled = true;


			return false;
		}

		internal static bool Fill_Airframe_Maintenance_Program_CBO_From_Array_History(ComboBox cbo_to_fill)
		{



			if (modGlobalVars.bAirframeMaintProg_IsLoaded)
			{
				cbo_to_fill.Enabled = false;
				cbo_to_fill.Items.Clear();
				cbo_to_fill.AddItem("");

				int tempForEndVar = modGlobalVars.Airframe_Maint_Prog_History.GetUpperBound(0);
				for (int a_row = modGlobalVars.Airframe_Maint_Prog_History.GetLowerBound(0); a_row <= tempForEndVar; a_row++)
				{
					cbo_to_fill.AddItem(modGlobalVars.Airframe_Maint_Prog_History[a_row]);
					cbo_to_fill.SetItemData(cbo_to_fill.Items.Count - 1, Convert.ToInt32(Double.Parse($"0{modGlobalVars.Airframe_Maint_Prog_Data_History[a_row]}")));
				}

				if (cbo_to_fill.Items.Count > 0)
				{
					cbo_to_fill.SelectedIndex = 0;
				}
				else
				{
					cbo_to_fill.SelectedIndex = -1;
				}

			}
			cbo_to_fill.Enabled = true;

			return false;
		} // Fill_Airframe_Maintenance_Program_CBO_From_Array_History

		internal static bool Fill_Airframe_Tracking_CBO_From_Array(ComboBox cbo_to_fill)
		{

			if (modGlobalVars.bAirframeMaintTrackProg_IsLoaded)
			{
				cbo_to_fill.Enabled = false;
				cbo_to_fill.Items.Clear();
				cbo_to_fill.AddItem("");

				int tempForEndVar = modGlobalVars.Airframe_Maint_Track_Prog.GetUpperBound(0);
				for (int a_row = modGlobalVars.Airframe_Maint_Track_Prog.GetLowerBound(0); a_row <= tempForEndVar; a_row++)
				{
					cbo_to_fill.AddItem(modGlobalVars.Airframe_Maint_Track_Prog[a_row]);
					cbo_to_fill.SetItemData(cbo_to_fill.Items.Count - 1, Convert.ToInt32(Double.Parse($"0{modGlobalVars.Airframe_Maint_Track_Prog_Data[a_row]}")));
				}

				if (cbo_to_fill.Items.Count > 0)
				{
					cbo_to_fill.SelectedIndex = 0;
				}
				else
				{
					cbo_to_fill.SelectedIndex = -1;
				}

			}
			cbo_to_fill.Enabled = true;

			return false;
		}

		// TEMP HOLD THIS CAN BE REMOVED
		internal static bool Fill_Currency_Type(ComboBox cbo_to_fill)
		{

			string Query = "";
			ADORecordSetHelper snpCurrency = new ADORecordSetHelper(); //aey 6/10/04

			try
			{

				cbo_to_fill.Enabled = false;
				cbo_to_fill.Items.Clear();
				cbo_to_fill.AddItem("");

				Query = "SELECT currency_name FROM Currency WITH(NOLOCK) ORDER BY currency_name";

				snpCurrency.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpCurrency.BOF && snpCurrency.EOF))
				{


					while(!snpCurrency.EOF)
					{
						cbo_to_fill.AddItem(($"{Convert.ToString(snpCurrency["currency_name"])}").Trim());
						snpCurrency.MoveNext();
					};

				}

				snpCurrency.Close();
				snpCurrency = null;

				if (cbo_to_fill.Items.Count > 0)
				{
					cbo_to_fill.SelectedIndex = 0;
				}
				else
				{
					cbo_to_fill.SelectedIndex = -1;
				}

				cbo_to_fill.Enabled = true;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_Currency_Type_Error: {Information.Err().Number.ToString()} {excep.Message}");
			}

			return false;
		}
		internal static object Fill_Currency_Type_From_Array(ComboBox cbo_to_fill)
		{

			if (modGlobalVars.bCurrency_IsLoaded)
			{
				cbo_to_fill.Enabled = false;
				cbo_to_fill.Items.Clear();
				cbo_to_fill.AddItem("");

				foreach (string Currency_Array_item in modGlobalVars.Currency_Array)
				{
					cbo_to_fill.AddItem(Currency_Array_item);
				}

				if (cbo_to_fill.Items.Count > 0)
				{
					cbo_to_fill.SelectedIndex = 0;
				}
				else
				{
					cbo_to_fill.SelectedIndex = -1;
				}

				cbo_to_fill.Enabled = true;
			}

			return null;




			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
			modAdminCommon.Report_Error($"Fill_Currency_Type_From_Array_Error: {Information.Err().Number.ToString()} {Information.Err().Description}");

			return null;
		}

		internal static bool Fill_Helicopter_Categories(ComboBox cbo_to_fill)
		{
			//fill helicopter category combo list aey 8/10/05

			ADORecordSetHelper helicat = new ADORecordSetHelper();
			string Query = "";

			try
			{

				cbo_to_fill.Enabled = false;
				cbo_to_fill.Items.Clear();
				cbo_to_fill.AddItem("");

				Query = "Select distinct heldtcat_category_type from Helicopter_Detail_Times_Category_Type WITH(NOLOCK) Order by heldtcat_category_type ";

				helicat.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(helicat.BOF && helicat.EOF))
				{

					while(!helicat.EOF)
					{
						cbo_to_fill.AddItem($"{Convert.ToString(helicat["heldtcat_category_type"])}");
						helicat.MoveNext();
					};
				}

				helicat.Close();
				helicat = null;

				cbo_to_fill.SelectedIndex = 0;
				cbo_to_fill.Enabled = true;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_Helicopter_Categories_Error: {Information.Err().Number.ToString()} {excep.Message}");
			}

			return false;
		}

		internal static bool Fill_Helicopter_SubCategories(ComboBox cbo_to_fill, string inCategory)
		{
			//fill helicopter sub category combo list aey 8/10/05

			ADORecordSetHelper helicat = new ADORecordSetHelper();
			string Query = "";

			try
			{

				cbo_to_fill.Enabled = false;
				cbo_to_fill.Items.Clear();
				cbo_to_fill.AddItem("");

				Query = "Select distinct heldtcat_subcat_type from Helicopter_Detail_Times_Category_Type WITH(NOLOCK)";
				if (Strings.Len(($"{inCategory}").Trim()) > 0)
				{
					Query = $"{Query} Where heldtcat_category_type ='{inCategory}'";
				}
				Query = $"{Query} Order by heldtcat_subcat_type";

				helicat.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(helicat.BOF && helicat.EOF))
				{

					while(!helicat.EOF)
					{
						cbo_to_fill.AddItem($"{Convert.ToString(helicat["heldtcat_subcat_type"])}");
						helicat.MoveNext();
					};
				}

				helicat.Close();
				helicat = null;

				cbo_to_fill.SelectedIndex = 0;
				cbo_to_fill.Enabled = true;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_Helicopter_SubCategories_Error: {Information.Err().Number.ToString()} {excep.Message}");
			}

			return false;
		}

		internal static bool Fill_Aircraft_Usage_List(ComboBox cbo_to_fill)
		{
			string Query = "";
			ADORecordSetHelper ado_Usage = new ADORecordSetHelper();

			try
			{
				cbo_to_fill.Enabled = false;
				cbo_to_fill.Items.Clear();
				cbo_to_fill.AddItem("");

				Query = "SELECT * FROM aircraft_useage WITH(NOLOCK) ORDER BY acuse_code";

				ado_Usage.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(ado_Usage.BOF && ado_Usage.EOF))
				{

					while(!ado_Usage.EOF)
					{
						cbo_to_fill.AddItem(($"{Convert.ToString(ado_Usage["acuse_code"])} - {Convert.ToString(ado_Usage["acuse_name"])}").Trim());
						ado_Usage.MoveNext();
					};
				}

				if (cbo_to_fill.Items.Count == 0)
				{
					cbo_to_fill.AddItem("B - Business");
				}

				cbo_to_fill.SelectedIndex = 0;

                // gap-note: jgamboa. Use SetToolTipText extension method to set the tooltip of the control in the ToolTipMain.
                cbo_to_fill.SetToolTipText("");
				cbo_to_fill.Enabled = true;

				ado_Usage.Close();
				ado_Usage = null;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_Aircraft_Usage_List_Error: {Information.Err().Number.ToString()} {excep.Message}");
			}

			return false;
		}

		internal static bool Fill_Journal_Cat_List(ComboBox cbo_to_fill)
		{
			try
			{
				string Query = "";
				ADORecordSetHelper snp_Journal_Category = new ADORecordSetHelper(); // Snapshot aey 6/10/04

				cbo_to_fill.Enabled = false;
				cbo_to_fill.Items.Clear();
				cbo_to_fill.AddItem("All");

				Query = "SELECT distinct jcat_category_name FROM Journal_Category WITH(NOLOCK) ORDER BY jcat_category_name";

				snp_Journal_Category.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_Journal_Category.BOF && snp_Journal_Category.EOF))
				{

					while(!snp_Journal_Category.EOF)
					{
						cbo_to_fill.AddItem(($"{Convert.ToString(snp_Journal_Category["jcat_category_name"])} ").Trim());
						snp_Journal_Category.MoveNext();
					};
					cbo_to_fill.SelectedIndex = 0;
				}

				cbo_to_fill.Enabled = true;

				snp_Journal_Category.Close();
				snp_Journal_Category = null;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_Journal_Cat_List_Error: {Information.Err().Number.ToString()} {excep.Message}");
			}

			return false;
		}

		internal static bool Fill_Journal_SubCat_List(ComboBox cbo_to_fill)
		{
			try
			{
				string Query = "";
				ADORecordSetHelper snp_Journal_SubCategory = new ADORecordSetHelper(); // Snapshot aey 6/10/04

				cbo_to_fill.Enabled = false;
				cbo_to_fill.Items.Clear();
				cbo_to_fill.AddItem("All");

				Query = "SELECT * FROM Journal_Category WITH(NOLOCK) ORDER BY jcat_subcategory_name";

				snp_Journal_SubCategory.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_Journal_SubCategory.BOF && snp_Journal_SubCategory.EOF))
				{

					while(!snp_Journal_SubCategory.EOF)
					{
						cbo_to_fill.AddItem(($"{Convert.ToString(snp_Journal_SubCategory["jcat_subcategory_name"])} ").Trim());
						snp_Journal_SubCategory.MoveNext();
					};
					cbo_to_fill.SelectedIndex = 0;
				}

				cbo_to_fill.Enabled = true;

				snp_Journal_SubCategory.Close();
				snp_Journal_SubCategory = null;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_Journal_SubCat_List_Error: {Information.Err().Number.ToString()} {excep.Message}");
				return false;
			}

			return false;
		}

		internal static bool Fill_Aircraft_Asking_List(ComboBox cbo_to_fill)
		{
			try
			{
				string M = "";
				string Query = "";
				ADORecordSetHelper snp_acasking = new ADORecordSetHelper(); // Snapshot aey 6/10/04

				cbo_to_fill.Enabled = false;
				cbo_to_fill.Items.Clear();
				cbo_to_fill.AddItem("");

				Query = "SELECT * FROM Aircraft_Asking WITH(NOLOCK) ORDER BY aask_name";

				snp_acasking.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_acasking.BOF && snp_acasking.EOF))
				{

					cbo_to_fill.AddItem("Make Offer");


					while(!snp_acasking.EOF)
					{
						M = (($"{Convert.ToString(snp_acasking["aask_name"])} ").Trim());
						if (M == "" || M == "Make Offer")
						{
						}
						else
						{
							cbo_to_fill.AddItem(M);
						}
						snp_acasking.MoveNext();
					};

					cbo_to_fill.SelectedIndex = 0;

				}

				cbo_to_fill.Enabled = true;

				snp_acasking.Close();
				snp_acasking = null;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_Aircraft_Asking_List_Error: {Information.Err().Number.ToString()} {excep.Message}");
			}

			return false;
		}

		internal static bool Fill_Aircraft_Asking_List_Select(ComboBox cbo_to_fill, string selected_status)
		{
			try
			{
				string M = "";
				string Query = "";
				ADORecordSetHelper snp_acasking = new ADORecordSetHelper(); // Snapshot aey 6/10/04

				cbo_to_fill.Enabled = false;
				cbo_to_fill.Items.Clear();
				cbo_to_fill.AddItem("");

				Query = "SELECT * FROM Aircraft_Asking WITH(NOLOCK) where aask_name <> '' ";


				if (selected_status.Trim() == "Auction")
				{
					Query = $"{Query} and aask_name in ('Bid', 'Sealed Bid', 'Price', 'No Engines') ";
				}
				else if (selected_status.Trim() == "For Sale")
				{ 
					Query = $"{Query} and aask_name in ('Make Offer', 'Inquire', 'Price', 'No Engines') ";
				}
				else if (selected_status.Trim() == "For Sale/Lease")
				{ 
					Query = $"{Query} and aask_name in ('Make Offer', 'Inquire', 'Price') ";
				}
				else if (selected_status.Trim() == "For Sale/Trade/Lease")
				{ 
					Query = $"{Query} and aask_name in ('Price', 'Make Offer', 'Inquire') ";
				}
				else if (selected_status.Trim() == "For Sale/Share")
				{ 
					Query = $"{Query} and aask_name in ('Price', 'Make Offer', 'Inquire','Share') ";
				}
				else if (selected_status.Trim() == "For Sale/Trade")
				{ 
					Query = $"{Query} and aask_name in ('Price', 'Make Offer', 'Inquire') ";
				}
				else if (selected_status.Trim() == "Lease" || selected_status.Trim() == "Lease Pending")
				{ 
					Query = $"{Query} and aask_name in ('Inquire', 'Lease Only') ";
				}


				Query = $"{Query} ORDER BY aask_name";

				snp_acasking.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_acasking.BOF && snp_acasking.EOF))
				{



					while(!snp_acasking.EOF)
					{

						M = (($"{Convert.ToString(snp_acasking["aask_name"])} ").Trim());
						if (M == "")
						{ // Or M = "Make Offer"
						}
						else
						{
							cbo_to_fill.AddItem(M);
						}

						snp_acasking.MoveNext();
					};

					cbo_to_fill.SelectedIndex = 0;

				}

				cbo_to_fill.Enabled = true;

				snp_acasking.Close();
				snp_acasking = null;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_Aircraft_Asking_List_Select_Error: {Information.Err().Number.ToString()} {excep.Message}");
			}

			return false;
		}

		internal static bool Fill_Aircraft_Status_List(ComboBox cbo_to_fill, int chkIsForsale)
		{
			try
			{
				string Query = "";
				Query = "";
				ADORecordSetHelper RS_Table = new ADORecordSetHelper();
				cbo_to_fill.Enabled = false;
				cbo_to_fill.Items.Clear();
				cbo_to_fill.AddItem("");

				if (chkIsForsale == 11)
				{

					// ADD ALL OF THE STATUSES IN
					Query = "SELECT * FROM  Aircraft_Status ";
					RS_Table.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);
					if (!(RS_Table.BOF && RS_Table.EOF))
					{

						while(!RS_Table.EOF)
						{
							cbo_to_fill.AddItem(($"{Convert.ToString(RS_Table["astat_name"])}").Trim());
							RS_Table.MoveNext();
						};
					}
					RS_Table.Close();
					cbo_to_fill.AddItem("Historical");

					cbo_to_fill.SelectedIndex = 0;

				}
				else if (chkIsForsale == ((int) CheckState.Checked))
				{ 

					Query = "SELECT * FROM  Aircraft_Status WHERE (astat_forsale = 'Y')";
					RS_Table.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);
					if (!(RS_Table.BOF && RS_Table.EOF))
					{

						while(!RS_Table.EOF)
						{
							cbo_to_fill.AddItem(($"{Convert.ToString(RS_Table["astat_name"])}").Trim());
							RS_Table.MoveNext();
						};
					}
					RS_Table.Close();
					cbo_to_fill.AddItem("Historical");


					cbo_to_fill.SelectedIndex = 0;


				}
				else
				{
					Query = "SELECT * FROM  Aircraft_Status WHERE (astat_forsale <> 'Y')";
					RS_Table.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);
					if (!(RS_Table.BOF && RS_Table.EOF))
					{

						while(!RS_Table.EOF)
						{
							cbo_to_fill.AddItem(($"{Convert.ToString(RS_Table["astat_name"])}").Trim());
							RS_Table.MoveNext();
						};
					}
					RS_Table.Close();
					cbo_to_fill.AddItem("Historical");

					cbo_to_fill.SelectedIndex = 0;
				}


				cbo_to_fill.Enabled = true;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_aircraft_status_List_Error: {Information.Err().Number.ToString()} {excep.Message}");
			}
			return false;
		}

		internal static bool Fill_Operating_Certification_CBO(ComboBox cbo_to_fill, int lJournId = 0)
		{
			// aey 5/30/04
			string Query = "";
			ADORecordSetHelper snpOpCert = new ADORecordSetHelper(); //aey 6/10/04

			try
			{

				cbo_to_fill.Enabled = false;
				cbo_to_fill.Items.Clear();
				cbo_to_fill.Tag = "";
				cbo_to_fill.AddItem("");

				Query = "SELECT * FROM Certification WITH(NOLOCK) ";

				if (lJournId == 0)
				{
					Query = $"{Query}WHERE (certification_active_flag = 'Y') ";
				}
				Query = $"{Query}ORDER BY certification_name";

				snpOpCert.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpOpCert.BOF && snpOpCert.EOF))
				{


					while(!snpOpCert.EOF)
					{
						cbo_to_fill.AddItem(($"{Convert.ToString(snpOpCert["certification_name"])}").Trim());
						snpOpCert.MoveNext();
					};
				}

				cbo_to_fill.Enabled = true;

				snpOpCert.Close();
				snpOpCert = null;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_Operating_Certification_CBO: {Information.Err().Number.ToString()} {excep.Message}");
			}

			return false;
		}

		internal static bool Fill_Certifications_CBO(ComboBox cbo_to_fill)
		{

			string Query = "";
			ADORecordSetHelper snp_Certs = new ADORecordSetHelper(); //Snapshot aey 6/10/04
			int qlength = 0;

			try
			{

				Query = "SELECT cert_name FROM Certified WITH(NOLOCK)";

				snp_Certs.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_Certs.BOF && snp_Certs.EOF))
				{

					cbo_to_fill.Enabled = false;
					cbo_to_fill.Items.Clear();
					cbo_to_fill.AddItem("");


					while(!snp_Certs.EOF)
					{

						cbo_to_fill.AddItem(Convert.ToString(snp_Certs["cert_name"]).Trim());
						snp_Certs.MoveNext();

					};

				}

				cbo_to_fill.Enabled = true;
				cbo_to_fill.SelectedIndex = -1;

				snp_Certs.Close();
				snp_Certs = null;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_Certifications_CBO_Error: {Information.Err().Number.ToString()} {excep.Message}");
			}

			return false;
		}

		internal static bool Fill_Aircraft_Config_Name(ComboBox cbo_to_fill)
		{
			string Query = "";
			ADORecordSetHelper snp_ConfigName = new ADORecordSetHelper();

			try
			{

				cbo_to_fill.Enabled = false;
				cbo_to_fill.Items.Clear();
				cbo_to_fill.AddItem("");

				Query = "SELECT intconfig_name FROM Interior_Configuration WITH(NOLOCK)";

				snp_ConfigName.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

				if (!(snp_ConfigName.BOF && snp_ConfigName.EOF))
				{

					while(!snp_ConfigName.EOF)
					{
						cbo_to_fill.AddItem(Convert.ToString(snp_ConfigName["intconfig_name"]).Trim());
						snp_ConfigName.MoveNext();
					};
				}

				if (cbo_to_fill.Items.Count > 0)
				{
					cbo_to_fill.SelectedIndex = 0;
				}
				else
				{
					cbo_to_fill.SelectedIndex = -1;
				}

				cbo_to_fill.Enabled = true;

				snp_ConfigName.Close();

				snp_ConfigName = null;
			}
			catch
			{


				modAdminCommon.Report_Error("Fill_Aircraft_Config_Name_Error: ");
				return false;
			}
			return false;
		}

		internal static bool Display_Aircraft_Model_Engine_APU_List(ComboBox cbo_to_fill)
		{

			try
			{

				string Query = "";
				ADORecordSetHelper snp_Aircraft_Model_Engine_APU = new ADORecordSetHelper(); // Snapshot aey 6/18/04

				cbo_to_fill.Enabled = false;
				cbo_to_fill.Items.Clear();
				cbo_to_fill.AddItem("");

				Query = "SELECT * FROM Auxilliary_Power_Unit WITH(NOLOCK)";

				snp_Aircraft_Model_Engine_APU.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_Aircraft_Model_Engine_APU.BOF && snp_Aircraft_Model_Engine_APU.EOF))
				{

					while(!snp_Aircraft_Model_Engine_APU.EOF)
					{
						cbo_to_fill.AddItem($"{($"{Convert.ToString(snp_Aircraft_Model_Engine_APU["apu_make_name"])}").Trim()} {($"{Convert.ToString(snp_Aircraft_Model_Engine_APU["apu_model_name"])} ").Trim()}");
						snp_Aircraft_Model_Engine_APU.MoveNext();
					};
				}

				if (cbo_to_fill.Items.Count > 0)
				{
					cbo_to_fill.SelectedIndex = 0;
				}
				else
				{
					cbo_to_fill.SelectedIndex = -1;
				}

				cbo_to_fill.Enabled = true;

				snp_Aircraft_Model_Engine_APU.Close();
				snp_Aircraft_Model_Engine_APU = null;
			}
			catch
			{

				modAdminCommon.Report_Error("Display_Aircraft_Model_Engine_APU_List_Error");
				return false;
			}

			return false;
		}

		internal static bool Display_Aircraft_Model_Engine_EMP_List(ComboBox cbo_to_fill)
		{

			try
			{

				string Query = "";
				string Temp = "";
				ADORecordSetHelper snp_Aircraft_Model_Engine_EMP = new ADORecordSetHelper(); //aey 6/18/04

				cbo_to_fill.Enabled = false;
				cbo_to_fill.Items.Clear();
				cbo_to_fill.AddItem("");

				Query = "SELECT emp_id, emp_code, emp_provider_name, emp_program_name FROM Engine_Maintenance_Program WITH(NOLOCK)";
				Query = $"{Query} ORDER BY emp_code, emp_provider_name, emp_program_name";

				snp_Aircraft_Model_Engine_EMP.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

				if (!(snp_Aircraft_Model_Engine_EMP.BOF && snp_Aircraft_Model_Engine_EMP.EOF))
				{

					while(!snp_Aircraft_Model_Engine_EMP.EOF)
					{

						Temp = ($"{Convert.ToString(snp_Aircraft_Model_Engine_EMP["emp_code"])}").Trim();

						Temp = $"{Temp} - {($"{Convert.ToString(snp_Aircraft_Model_Engine_EMP["emp_provider_name"])}").Trim()}";
						Temp = $"{Temp} - {($"{Convert.ToString(snp_Aircraft_Model_Engine_EMP["emp_program_name"])}").Trim()}";

						cbo_to_fill.AddItem(Temp);
						cbo_to_fill.SetItemData(cbo_to_fill.Items.Count - 1, Convert.ToInt32(Double.Parse(($"{Convert.ToString(snp_Aircraft_Model_Engine_EMP["emp_id"])}").Trim())));

						snp_Aircraft_Model_Engine_EMP.MoveNext();
					};
				}

				if (cbo_to_fill.Items.Count > 0)
				{
					cbo_to_fill.SelectedIndex = 0;
				}
				else
				{
					cbo_to_fill.SelectedIndex = -1;
				}

				cbo_to_fill.Enabled = true;

				snp_Aircraft_Model_Engine_EMP.Close();
				snp_Aircraft_Model_Engine_EMP = null;
			}
			catch
			{

				modAdminCommon.Report_Error("Display_Aircraft_Model_Engine_EMP_List_Error: ");
				return false;
			}

			return false;
		}

		internal static bool Fill_Avionics_Master_List(ListBox lst_to_fill)
		{

			try
			{
				string Query = "";
				ADORecordSetHelper snp_AvionicsList = new ADORecordSetHelper(); //aey 6/10/04

				lst_to_fill.Enabled = false;
				lst_to_fill.Items.Clear();

				Query = "SELECT avion_name FROM Avionics WITH(NOLOCK) ORDER BY avion_name";

				snp_AvionicsList.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_AvionicsList.BOF && snp_AvionicsList.EOF))
				{

					while(!snp_AvionicsList.EOF)
					{

						if (Convert.ToString(snp_AvionicsList["avion_name"]).Trim() != "")
						{
							lst_to_fill.AddItem(Convert.ToString(snp_AvionicsList["avion_name"]).Trim());
						}

						snp_AvionicsList.MoveNext();
					};
				}

				if (lst_to_fill.Items.Count > 0)
				{
					ListBoxHelper.SetSelectedIndex(lst_to_fill, 0);
				}
				else
				{
					ListBoxHelper.SetSelectedIndex(lst_to_fill, -1);
				}

				lst_to_fill.Enabled = true;

				snp_AvionicsList.Close();
				snp_AvionicsList = null;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_Avionics_Master_List_Error: {Information.Err().Number.ToString()} {excep.Message}");
				return false;
			}

			return false;
		}

		internal static bool Fill_Avionics_Lookup(ComboBox cbo_to_fill, string in_avion_name, string in_avion_description, int amod_ID, bool Lock_Avionics = false)
		{

			string Query = "";
			ADORecordSetHelper snp_FieldValues = new ADORecordSetHelper(); // Snapshot aey 6/10/04

			try
			{

				cbo_to_fill.Enabled = false;
				cbo_to_fill.Items.Clear();

				if (Lock_Avionics)
				{
					// then dont add the blank, cause we need to pick an item that is there
				}
				else
				{
					cbo_to_fill.AddItem("");
				}

				Query = " select distinct av_description   from Aircraft_Avionics with (NOLOCK) inner join Aircraft with (NOLOCK) on ac_id = av_ac_id and ac_journ_id = av_ac_journ_id";
				Query = $"{Query} Where ac_journ_id = 0 and ac_amod_id = {amod_ID.ToString()}  and av_name = '{in_avion_name}'";

				snp_FieldValues.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_FieldValues.BOF && snp_FieldValues.EOF))
				{


					while(!snp_FieldValues.EOF)
					{
						cbo_to_fill.AddItem(Convert.ToString(snp_FieldValues["av_description"]).Trim());
						snp_FieldValues.MoveNext();
					};
				}

				if (cbo_to_fill.Items.Count > 0 && in_avion_description != "")
				{
					cbo_to_fill.SelectedIndex = 0; //'moved here msw - 6/24/20
					int tempForEndVar = cbo_to_fill.Items.Count - 1;
					for (int i = 0; i <= tempForEndVar; i++)
					{
						if (cbo_to_fill.GetListItem(i).Trim().ToLower() == in_avion_description.Trim().ToLower())
						{
							cbo_to_fill.SelectedIndex = i;
							break;
						}
					}
				}
				else
				{

					if (cbo_to_fill.Items.Count > 0)
					{
						cbo_to_fill.SelectedIndex = 0;
					}
					else
					{
						cbo_to_fill.SelectedIndex = -1;
					}

				}

				if (cbo_to_fill.Text == "" && in_avion_description != "")
				{
					if (in_avion_description != "")
					{
						cbo_to_fill.Text = in_avion_description;
					}
					else
					{
						cbo_to_fill.Text = "";
					}
				}

				cbo_to_fill.Enabled = true;

				snp_FieldValues.Close();
				snp_FieldValues = null;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_Avionics_Lookup_Error: {Information.Err().Number.ToString()} {excep.Message}");
				return false;
			}

			return false;
		}

		internal static bool Fill_TimeZoneList_FromArray(ListBox lst_to_fill)
		{

			bool result = false;
			try
			{
				result = false;

				lst_to_fill.Items.Clear();
				lst_to_fill.AddItem("All");

				if (modFillCommonArrays.Fill_TimeZone_Array())
				{

					foreach (string TimeZone_Array_item in modGlobalVars.TimeZone_Array)
					{
						lst_to_fill.AddItem(TimeZone_Array_item);
					}

					result = true;

				}
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_TimeZoneList_FromArray_Error {Information.Err().Number.ToString()} {excep.Message}");
			}

			return result;
		}
	}
}