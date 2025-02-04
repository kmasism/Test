using Microsoft.VisualBasic;
using System;
using System.Data.Common;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Gui.Controls;
using UpgradeHelpers.Helpers;
using UpgradeStubs;

namespace JETNET_Homebase
{
	internal static class modFillCompConControls
	{



		internal static void assign_account_rep(string s_InCompanyName, ComboBox cbo_InAccountType, ComboBox cbo_OutRepID)
		{

			try
			{

				ADORecordSetHelper snp_AssignRep = null;
				string Query = "";

				Query = $"SELECT assign_db_account_id, assign_eu_account_id FROM Account_Rep_Assignment WITH(NOLOCK) WHERE assign_character = '{s_InCompanyName.Trim().Substring(0, Math.Min(1, s_InCompanyName.Trim().Length))}'";

				snp_AssignRep = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(snp_AssignRep.Fields) && !(snp_AssignRep.BOF && snp_AssignRep.EOF))
				{

					cbo_OutRepID.SelectedIndex = -1;

					if (cbo_InAccountType.Text.Trim().ToLower() == ("Dealer Broker").ToLower())
					{

						int tempForEndVar = cbo_OutRepID.Items.Count - 1;
						for (int i = 0; i <= tempForEndVar; i++)
						{
							if (cbo_OutRepID.GetListItem(i) == Convert.ToString(snp_AssignRep["assign_db_account_id"]).Trim())
							{
								cbo_OutRepID.SelectedIndex = i;
								break;
							}
						}

					}
					else
					{

						int tempForEndVar2 = cbo_OutRepID.Items.Count - 1;
						for (int i = 0; i <= tempForEndVar2; i++)
						{
							if (cbo_OutRepID.GetListItem(i) == Convert.ToString(snp_AssignRep["assign_eu_account_id"]).Trim())
							{
								cbo_OutRepID.SelectedIndex = i;
								break;
							}
						}
					}

					snp_AssignRep.Close();

				}

				snp_AssignRep = null;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error("Common (modFillCompConControls)", $"assign_account_rep_Error ({Information.Err().Number.ToString()}) {excep.Message}");
				return;
			}
		}

		//
		internal static bool fill_state_FromArray_With_ID(ComboBox cbo_to_fill, bool isAircraftForm, bool isAircraftChangeOrFindCoForm, bool isCompanyAddForm, string country = "")
		{

			bool result = false;
			try
			{

				string[] t_Array = null;
				NotUpgradedHelper.NotifyNotUpgradedElement("The following assignment/return was commented because it has incompatible types");
				//t_Array = (string[]) ArraysHelper.DeepCopy(null);
				string selected_state = "";
				int state_filled_count = 0;
				state_filled_count = 0;
				int counter1 = 0;
				counter1 = 0;

				if (cbo_to_fill.Text.Trim() != "")
				{
					selected_state = cbo_to_fill.Text.Trim();
				}
				else
				{
					selected_state = "";
				}

				cbo_to_fill.Enabled = false;
				cbo_to_fill.Items.Clear();
				cbo_to_fill.AddItem("");

				foreach (string State_Array_item in modGlobalVars.State_Array)
				{

					t_Array = State_Array_item.Split(new string[]{", "}, StringSplitOptions.None);


					state_filled_count++;
					if (isAircraftForm)
					{
						cbo_to_fill.AddItem(t_Array[0].Trim()); // TEMP HOLD MSW
					}
					else if (isAircraftChangeOrFindCoForm)
					{ 
						cbo_to_fill.AddItem($"{t_Array[0].Trim()}, {t_Array[1].Trim()}");
					}
					else if (isCompanyAddForm)
					{ 
						cbo_to_fill.AddItem($"{t_Array[0].Trim()}, {t_Array[3].Trim()}, {t_Array[2].Trim()}");
					}
					else
					{
						cbo_to_fill.AddItem($"{t_Array[0].Trim()}, {t_Array[1].Trim()}, {t_Array[2].Trim()}");
					}


					cbo_to_fill.SetItemData(counter1, 22);

					counter1++;
				}


				if (country.Trim() != "" && selected_state.Trim() != "")
				{
					cbo_to_fill.Text = selected_state;
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


				cbo_to_fill.Enabled = true;

				return true;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error("Common (modFillCompConControls)", $"fill_state_FromArray_With_ID_Error ({Information.Err().Number.ToString()}) {excep.Message}");
				result = false;
			}
			return result;
		}

		//
		internal static bool fill_state_FromArray(ComboBox cbo_to_fill, bool isAircraftForm, bool isAircraftChangeOrFindCoForm, bool isCompanyAddForm, string country = "")
		{

			bool result = false;
			try
			{

				string[] t_Array = null;
				NotUpgradedHelper.NotifyNotUpgradedElement("The following assignment/return was commented because it has incompatible types");
				//t_Array = (string[]) ArraysHelper.DeepCopy(null);
				string selected_state = "";
				int state_filled_count = 0;
				bool bEnabled = false;

				bEnabled = cbo_to_fill.Enabled;

				state_filled_count = 0;


				if (cbo_to_fill.Text.Trim() != "")
				{
					selected_state = cbo_to_fill.Text.Trim();
				}
				else
				{
					selected_state = "";
				}

				cbo_to_fill.Enabled = false;
				cbo_to_fill.Items.Clear();
				cbo_to_fill.AddItem("");

				foreach (string State_Array_item in modGlobalVars.State_Array)
				{


					t_Array = State_Array_item.Split(new string[]{", "}, StringSplitOptions.None);


					// added msw 9/6/13 if you select a country, we will not reload the state box with only the states from there.
					if (country.Trim() != "")
					{

						// if the country is equal to the selected country , then add the state
						// count the states to loop back through them later
						if (t_Array[1].Trim().Trim() == country.Trim())
						{
							state_filled_count++;
							if (isAircraftForm)
							{
								cbo_to_fill.AddItem(t_Array[0].Trim()); // TEMP HOLD MSW
							}
							else if (isAircraftChangeOrFindCoForm)
							{ 
								cbo_to_fill.AddItem($"{t_Array[0].Trim()}, {t_Array[1].Trim()}");
							}
							else if (isCompanyAddForm)
							{ 
								cbo_to_fill.AddItem($"{t_Array[0].Trim()}, {t_Array[3].Trim()}, {t_Array[2].Trim()}");
							}
							else
							{
								cbo_to_fill.AddItem($"{t_Array[0].Trim()}, {t_Array[1].Trim()}, {t_Array[2].Trim()}");
							}
						}

					}
					else
					{

						if (isAircraftForm)
						{
							cbo_to_fill.AddItem(t_Array[0].Trim()); // TEMP HOLD MSW
						}
						else if (isAircraftChangeOrFindCoForm)
						{ 
							cbo_to_fill.AddItem($"{t_Array[0].Trim()}, {t_Array[1].Trim()}");
						}
						else if (isCompanyAddForm)
						{ 
							cbo_to_fill.AddItem($"{t_Array[0].Trim()}, {t_Array[3].Trim()}, {t_Array[2].Trim()}");
						}
						else
						{
							cbo_to_fill.AddItem($"{t_Array[0].Trim()}, {t_Array[1].Trim()}, {t_Array[2].Trim()}");
						}


					}

				}

				if (country.Trim() == "" || selected_state.Trim() == "")
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

				cbo_to_fill.Enabled = true;

				return true;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error("Common (modFillCompConControls)", $"fill_state_FromArray_Error ({Information.Err().Number.ToString()}) {excep.Message}");
				result = false;
			}
			return result;
		}

		internal static bool fill_wanted_model_list_FromArray(ComboBox cbo_to_fill)
		{

			bool result = false;
			try
			{


				cbo_to_fill.Enabled = false;
				cbo_to_fill.Items.Clear();

				int tempForEndVar = modGlobalVars.WantedModel_Array.GetUpperBound(0);
				for (int a_row = modGlobalVars.WantedModel_Array.GetLowerBound(0); a_row <= tempForEndVar; a_row++)
				{
					cbo_to_fill.AddItem($"{modGlobalVars.WantedModel_Array[a_row, modGlobalVars.WANTED_MAKE].Trim()}/{modGlobalVars.WantedModel_Array[a_row, modGlobalVars.WANTED_MODEL].Trim()}");
					cbo_to_fill.SetItemData(cbo_to_fill.GetNewIndex(), Convert.ToInt32(Double.Parse(modGlobalVars.WantedModel_Array[a_row, modGlobalVars.WANTED_ID])));
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

				return true;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error("Common (modFillCompConControls)", $"fill_wanted_model_list_FromArray ({Information.Err().Number.ToString()}) {excep.Message}");
				return result;
			}
		}

		internal static bool fill_phonetype_FromArray(ComboBox cbo_to_fill)
		{

			bool result = false;
			try
			{

				cbo_to_fill.Enabled = false;
				cbo_to_fill.Items.Clear();
				cbo_to_fill.AddItem("");

				foreach (string PhoneType_Array_item in modGlobalVars.PhoneType_Array)
				{
					cbo_to_fill.AddItem(PhoneType_Array_item);
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

				return true;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error("Common (modFillCompConControls)", $"fill_phonetype_FromArray_Error ({Information.Err().Number.ToString()}) {excep.Message}");
				return result;
			}
		}

		internal static bool fill_contactsirname_FromArray(ComboBox cbo_to_fill)
		{
			//*****************************************************************************************************
			// Function used to fill contact sirname combo
			//**************************************************************************************************
			bool result = false;
			try
			{


				cbo_to_fill.Enabled = false;
				cbo_to_fill.Items.Clear();
				cbo_to_fill.AddItem("");

				foreach (string ContactSirname_Array_item in modGlobalVars.ContactSirname_Array)
				{
					cbo_to_fill.AddItem(ContactSirname_Array_item);
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

				return true;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error("Common (modFillCompConControls)", $"fill_contactsirname_FromArray_Error ({Information.Err().Number.ToString()}) {excep.Message}");
				return result;
			}
		}

		internal static bool fill_contactsuffix_FromArray(ComboBox cbo_to_fill)
		{

			bool result = false;
			try
			{
				result = false;


				cbo_to_fill.Enabled = false;
				cbo_to_fill.Items.Clear();
				cbo_to_fill.AddItem("");

				foreach (string ContactSuffix_Array_item in modGlobalVars.ContactSuffix_Array)
				{
					if (ContactSuffix_Array_item != "")
					{
						cbo_to_fill.AddItem(ContactSuffix_Array_item);
					}
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


				return true;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error("Common (modFillCompConControls)", $"fill_contactsuffix_FromArray_Error ({Information.Err().Number.ToString()}) {excep.Message}");
				return result;
			}
		}

		internal static bool fill_timezone_FromArray(ComboBox cbo_to_fill)
		{

			bool result = false;
			try
			{
				result = false;

				cbo_to_fill.Enabled = false;
				cbo_to_fill.Items.Clear();
				cbo_to_fill.AddItem("");

				foreach (string TimeZone_Array_item in modGlobalVars.TimeZone_Array)
				{
					cbo_to_fill.AddItem(TimeZone_Array_item);
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

				return true;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error("Common (modFillCompConControls)", $"fill_timezone_FromArray_Error ({Information.Err().Number.ToString()}) {excep.Message}");
				return result;
			}
		}

		internal static bool fill_country_FromArray(ComboBox cbo_to_fill, bool add_unknown = false, bool add_in_blank = true)
		{

			bool result = false;
			try
			{
				result = false;


				cbo_to_fill.Enabled = false;
				cbo_to_fill.Items.Clear();
				if (add_in_blank)
				{
					cbo_to_fill.AddItem("");
				}
				if (add_unknown)
				{
					cbo_to_fill.AddItem("Unknown");
				}

				foreach (string Country_Array_item in modGlobalVars.Country_Array)
				{
					cbo_to_fill.AddItem(Country_Array_item);
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


				return true;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error("Common (modFillCompConControls)", $"fill_country_FromArray_Error ({Information.Err().Number.ToString()}) {excep.Message}");
				return result;
			}
		}

		internal static bool fill_accounttype_FromArray(ComboBox cbo_to_fill)
		{

			bool result = false;
			try
			{
				result = false;

				cbo_to_fill.Items.Clear();
				cbo_to_fill.Enabled = false;
				cbo_to_fill.AddItem("");

				int tempForEndVar = modGlobalVars.AccountType_Array.GetUpperBound(0);
				for (int a_row = modGlobalVars.AccountType_Array.GetLowerBound(0); a_row <= tempForEndVar; a_row++)
				{
					if (modGlobalVars.AccountType_Array[a_row, modGlobalVars.ACCTTYPE_CODE].Trim() == "FO")
					{
					}
					else
					{
						cbo_to_fill.AddItem(modGlobalVars.AccountType_Array[a_row, modGlobalVars.ACCTTYPE_NAME]);
					}


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


				return true;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error("Common (modFillCompConControls)", $"fill_accounttype_FromArray_Error ({Information.Err().Number.ToString()}) {excep.Message}");
				return result;
			}
		}

		internal static bool fill_agencytype_FromArray(ComboBox cbo_to_fill)
		{

			bool result = false;
			try
			{

				cbo_to_fill.Items.Clear();
				cbo_to_fill.Enabled = false;
				cbo_to_fill.AddItem("");

				foreach (string AgencyType_Array_item in modGlobalVars.AgencyType_Array)
				{
					cbo_to_fill.AddItem($"{AgencyType_Array_item.Substring(0, Math.Min(1, AgencyType_Array_item.Length))} - {AgencyType_Array_item}");
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

				return true;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error("Common (modFillCompConControls)", $"fill_agencytype_FromArray_Error ({Information.Err().Number.ToString()}) {excep.Message}");
				return result;
			}
		}
		internal static bool fill_businesstype_From_Select(ComboBox cbo_to_fill, int comp_id_temp, string inbus_type = "")
		{

			bool result = false;
			try
			{
				result = false;
				string Query = "";
				int nRecCount = 0, nCounter = 0;
				ADORecordSetHelper ado_BusinessType = new ADORecordSetHelper();
				int selected_index = 0;
				selected_index = 0;

				Query = "SELECT distinct cbus_type, cbus_name, bustypref_seq_no FROM Company_Business_Type WITH(NOLOCK)";
				Query = $"{Query} inner join business_type_reference on bustypref_type = cbus_type";
				Query = $"{Query} where bustypref_comp_id = {comp_id_temp.ToString()} and bustypref_journ_id = 0 ORDER BY bustypref_seq_no asc";
				//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseClient);

				ado_BusinessType.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(ado_BusinessType.BOF && ado_BusinessType.EOF))
				{
					cbo_to_fill.Items.Clear();
					nRecCount = ado_BusinessType.RecordCount;
					nCounter = 0;


					while(!ado_BusinessType.EOF)
					{

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_BusinessType["cbus_name"]))
						{

							if (inbus_type.ToUpper().Substring(0, Math.Min(2, inbus_type.ToUpper().Length)).Trim() == Convert.ToString(ado_BusinessType["cbus_type"]).Trim().ToUpper())
							{
								selected_index = nCounter;
							}

							cbo_to_fill.AddItem($"{Convert.ToString(ado_BusinessType["cbus_type"]).Trim()} - {Convert.ToString(ado_BusinessType["cbus_name"]).Trim()} ");

							nCounter++;

						}

						ado_BusinessType.MoveNext();

					};

				}

				cbo_to_fill.SelectedIndex = selected_index;
				//cbo_to_fill.Enabled = False

				//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseServer);

				ado_BusinessType.Close();
				ado_BusinessType = null;


				return true;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error("Common (modFillCompConControls)", $"fill_businesstype_From_Select ({Information.Err().Number.ToString()}) {excep.Message}");
				return result;
			}
		}
		internal static bool fill_businesstype_FromArray(ComboBox cbo_to_fill, ComboBox cbo_is_filled = null)
		{

			bool result = false;
			try
			{

				object i = null;
				int nCounter = 0;
				bool isABISelected = false;
				isABISelected = false;
				bool isYACHTSelected = false;
				isYACHTSelected = false;

				nCounter = 0;

				cbo_to_fill.Enabled = false;
				cbo_to_fill.Items.Clear();
				cbo_to_fill.AddItem("", nCounter);
				nCounter++;


				//UPGRADE_WARNING: (2080) IsEmpty was upgraded to a comparison and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
				//UPGRADE_WARNING: (2065) Boolean method Information.IsMissing has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
				if (!(cbo_is_filled is null) && !String.IsNullOrEmpty(cbo_is_filled.Text))
				{

					if (cbo_is_filled.Text.Substring(Math.Min(0, cbo_is_filled.Text.Length), Math.Min(1, Math.Max(0, cbo_is_filled.Text.Length))).ToUpper() == "A")
					{
						isABISelected = true;
					}

					if (cbo_is_filled.Text.Substring(Math.Min(0, cbo_is_filled.Text.Length), Math.Min(1, Math.Max(0, cbo_is_filled.Text.Length))).ToUpper() == "Y")
					{
						isYACHTSelected = true;
					}

					int tempForEndVar = modGlobalVars.BusinessType_Array.GetUpperBound(0);
					for (int a_row = modGlobalVars.BusinessType_Array.GetLowerBound(0); a_row <= tempForEndVar; a_row++)
					{

						if (cbo_is_filled.Items.Count == 1 && cbo_is_filled.Text.Substring(Math.Min(0, cbo_is_filled.Text.Length), Math.Min(1, Math.Max(0, cbo_is_filled.Text.Length))).ToUpper() != "A")
						{

							if (modGlobalVars.BusinessType_Array[a_row, modGlobalVars.CBUS_ABIFLAG].ToUpper() == "N")
							{
								cbo_to_fill.AddItem(modGlobalVars.BusinessType_Array[a_row, modGlobalVars.CBUS_TYPENAME], nCounter);
								nCounter++;
							}

						}
						else if (cbo_is_filled.Items.Count == 1 && cbo_is_filled.Text.Substring(Math.Min(0, cbo_is_filled.Text.Length), Math.Min(1, Math.Max(0, cbo_is_filled.Text.Length))).ToUpper() == "A")
						{ 

							if (modGlobalVars.BusinessType_Array[a_row, modGlobalVars.CBUS_ABIFLAG].ToUpper() == "Y")
							{
								cbo_to_fill.AddItem(modGlobalVars.BusinessType_Array[a_row, modGlobalVars.CBUS_TYPENAME], nCounter);
								nCounter++;
							}

						}
						else if (!isABISelected && !isYACHTSelected)
						{ 

							if (cbo_is_filled.Text.Substring(Math.Min(0, cbo_is_filled.Text.Length), Math.Min(1, Math.Max(0, cbo_is_filled.Text.Length))) != "")
							{
								if (modGlobalVars.BusinessType_Array[a_row, modGlobalVars.CBUS_ABIFLAG].ToUpper() == "N")
								{
									cbo_to_fill.AddItem(modGlobalVars.BusinessType_Array[a_row, modGlobalVars.CBUS_TYPENAME], nCounter);
									nCounter++;
								}
							}
							else
							{
								cbo_to_fill.AddItem(modGlobalVars.BusinessType_Array[a_row, modGlobalVars.CBUS_TYPENAME], nCounter);
								nCounter++;
							}
						}
						else if (isYACHTSelected)
						{ 

							if (modGlobalVars.BusinessType_Array[a_row, modGlobalVars.CBUS_YACHTFLAG].ToUpper() == "Y")
							{
								cbo_to_fill.AddItem(modGlobalVars.BusinessType_Array[a_row, modGlobalVars.CBUS_TYPENAME], nCounter);
								nCounter++;
							}

						}
						else
						{
							if (modGlobalVars.BusinessType_Array[a_row, modGlobalVars.CBUS_ABIFLAG].ToUpper() == "Y")
							{
								cbo_to_fill.AddItem(modGlobalVars.BusinessType_Array[a_row, modGlobalVars.CBUS_TYPENAME], nCounter);
								nCounter++;
							}
						}

					}



				}
				else
				{
					int tempForEndVar2 = modGlobalVars.BusinessType_Array.GetUpperBound(0);
					for (int a_row = modGlobalVars.BusinessType_Array.GetLowerBound(0); a_row <= tempForEndVar2; a_row++)
					{
						cbo_to_fill.AddItem(modGlobalVars.BusinessType_Array[a_row, modGlobalVars.CBUS_TYPENAME]);
					}

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


				return true;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error("Common (modFillCompConControls)", $"fill_businesstype_FromArray_Error ({Information.Err().Number.ToString()}) {excep.Message}");
				return result;
			}
		}

		internal static bool fill_product_Codes(ComboBox cbo_to_fill)
		{

			bool result = false;
			try
			{

				cbo_to_fill.Enabled = false;

				if (cbo_to_fill.Name == "cmb_product_code")
				{
					cbo_to_fill.Items.Clear();
					cbo_to_fill.AddItem("", 0);
					cbo_to_fill.AddItem("B - Business Aircraft", 1);
					cbo_to_fill.AddItem("H - Helicopters", 2);
					cbo_to_fill.AddItem("C - Commercial Aircraft", 3);
					cbo_to_fill.AddItem("A - Aviation Business Index", 4);
					if (cbo_to_fill.Items.Count > 0)
					{
						cbo_to_fill.SelectedIndex = 0;
					}
					else
					{
						cbo_to_fill.SelectedIndex = -1;
					}
				}
				else
				{
					cbo_to_fill.Items.Clear();
					cbo_to_fill.AddItem("", 0);
					cbo_to_fill.AddItem("B - Business Aircraft", 1);
					cbo_to_fill.AddItem("H - Helicopters", 2);
					cbo_to_fill.AddItem("C - Commercial Aircraft", 3);
					cbo_to_fill.AddItem("A - Aviation Business Index", 4);
					cbo_to_fill.AddItem("P - AirBP", 5);
					cbo_to_fill.AddItem("Y - Yacht", 6);

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

				return true;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error("Common (modFillCompConControls)", $"fill_product_Codes_Error ({Information.Err().Number.ToString()}) {excep.Message}");
				return result;
			}
		}

		internal static bool fill_company_Ctype(ComboBox cbo_to_fill)
		{

			bool result = false;
			try
			{

				cbo_to_fill.Enabled = false;
				cbo_to_fill.Items.Clear();

				cbo_to_fill.AddItem("All", 0);
				cbo_to_fill.AddItem("Primary Company", 1); // primary poc flag=Y
				cbo_to_fill.AddItem("Owner/Operator", 2); // 50
				cbo_to_fill.AddItem("Owner", 3); //00
				cbo_to_fill.AddItem("Operator", 4); // 36
				cbo_to_fill.AddItem("Exclusive Broker", 5); //99
				cbo_to_fill.AddItem("Fractional Owner", 6); //97

				if (cbo_to_fill.Items.Count > 0)
				{
					cbo_to_fill.SelectedIndex = 0;
				}
				else
				{
					cbo_to_fill.SelectedIndex = -1;
				}

				cbo_to_fill.Enabled = true;

				return true;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error("Common (modFillCompConControls)", $"fill_company_Ctype_Error ({Information.Err().Number.ToString()}) {excep.Message}");
				return result;
			}
		}

		internal static bool fill_journ_subject_List(ComboBox cbo_to_fill)
		{

			bool result = false;
			try
			{

				cbo_to_fill.Enabled = false;
				cbo_to_fill.Items.Clear();

				cbo_to_fill.AddItem("Still has Shares Per:", 0);
				cbo_to_fill.AddItem("Email Sent", 1);
				cbo_to_fill.AddItem("Left Message", 2);
				cbo_to_fill.AddItem("", 3); // Custom
				cbo_to_fill.AddItem("Confirmed info per:", 4);

				cbo_to_fill.Enabled = true;

				if (cbo_to_fill.Items.Count > 0)
				{
					cbo_to_fill.SelectedIndex = 0;
				}
				else
				{
					cbo_to_fill.SelectedIndex = -1;
				}

				return true;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error("Common (modFillCompConControls)", $"fill_journ_subject_list_Error ({Information.Err().Number.ToString()}) {excep.Message}");
				return result;
			}
		}

		internal static bool fill_journ_auto_subject_List(ComboBox cbo_to_fill, string strNoteType, string from_spot = "")
		{

			cbo_to_fill.Enabled = false;
			cbo_to_fill.Items.Clear();

			cbo_to_fill.AddItem("", 0);

			if (strNoteType.StartsWith("ID", StringComparison.Ordinal))
			{
				cbo_to_fill.AddItem("IDNOTE - Attempted to ID", 1);
				cbo_to_fill.AddItem("IDNOTE - IDd", 2);
				cbo_to_fill.AddItem("IDNOTE - ID Lead Sent", 3);

			}

			if (strNoteType.StartsWith("REGCHK", StringComparison.Ordinal))
			{
				cbo_to_fill.AddItem("REGCHK - Registry Checked, No Changes", 1);
				cbo_to_fill.AddItem("REGCHK - Registry Checked, Update", 2);
				cbo_to_fill.AddItem("REGCHK - Registry Checked, Old Info", 3);
			}

			if (strNoteType.ToUpper().StartsWith("CS", StringComparison.Ordinal))
			{
				cbo_to_fill.AddItem("CSAC - Accounting", 1);
				cbo_to_fill.AddItem("CSCO - Customer Outreach", 2);
				cbo_to_fill.AddItem("CSCS - Customer Support", 3);
			}

			if (strNoteType.ToUpper().StartsWith("MN", StringComparison.Ordinal))
			{
				cbo_to_fill.AddItem("MN - Marketing Note", 1);
				cbo_to_fill.AddItem("MND - Marketing Demo", 2);
				cbo_to_fill.AddItem("MNC - Marketing Contract", 3);
				cbo_to_fill.AddItem("MNQ - Marketing Quote", 4);
				cbo_to_fill.AddItem("MNL - Marketing Lead", 5);

				// ADDED MSW - 4/1/20
				cbo_to_fill.AddItem("MNCS - Marketing Contract Sent", 6);
				cbo_to_fill.AddItem("MO - Marketing Outreach", 7);
				cbo_to_fill.AddItem("MR - Marketing Retention", 8);
				cbo_to_fill.AddItem("MC - Marketing Cold Call", 9);
			}

			if (strNoteType.ToUpper().StartsWith("IQ", StringComparison.Ordinal))
			{


				// NEW VERSION, WITH DELETED ITEMS - MSW - 8/4/2020
				cbo_to_fill.AddItem("JNiQ - Declined Survey", 1);
				cbo_to_fill.AddItem("JNiQ - Follow up Email/Call", 2);
				cbo_to_fill.Text = modGlobalVars.cEmptyString;
				cbo_to_fill.AddItem("JNiQ - EMail Sent", 3);
				cbo_to_fill.Text = modGlobalVars.cEmptyString;

				if (from_spot.Trim() == "Journal")
				{
					cbo_to_fill.AddItem("JNiQ - Phone Call", 4);
					cbo_to_fill.Text = modGlobalVars.cEmptyString;
				}
				else
				{

				}



			} // If left(strNoteType, 2) = "IQ" Then

			if (strNoteType.StartsWith("PB", StringComparison.Ordinal))
			{
				cbo_to_fill.AddItem("PUB Note - Blind PUB Sent", 1);
				cbo_to_fill.AddItem("PUB Note - PUB Not sent", 2);
				cbo_to_fill.AddItem("PUB Note - Email PUB sent", 3);
				cbo_to_fill.AddItem("PUB Note - Blind PUB Not Sent", 4);
				cbo_to_fill.Text = "";
			} // If left(strNoteType, 2) = "PB" Then

			if (strNoteType.StartsWith("RAAT", StringComparison.Ordinal))
			{
				cbo_to_fill.AddItem("RAAT - Reassign Attempted", 1);
				cbo_to_fill.Text = "RAAT - Reassign Attempted";
			} // If left(strNoteType, 4) = "RAAT" Then

			// 09/27/2017 - By David D. Cruger; Added
			if (strNoteType.StartsWith("RADN", StringComparison.Ordinal))
			{
				cbo_to_fill.AddItem("RADN - Reassign Procedures Done", 1);
				cbo_to_fill.Text = "RADN - Reassign Procedures Done";
			} // If left(strNoteType, 4) = "RADN" Then

			if (strNoteType.StartsWith("DOCAT", StringComparison.Ordinal))
			{
				cbo_to_fill.AddItem("DOCAT - Doc Attempted", 1);
				cbo_to_fill.Text = "DOCAT - Doc Attempted";
			} // If left(strNoteType, 5) = "DOCAT" Then

			if (strNoteType.StartsWith("SPEC", StringComparison.Ordinal))
			{
				cbo_to_fill.AddItem("SPEC - Entered Spec", 1);
				cbo_to_fill.AddItem("SPEC - Entered Spec Updates", 2);
				cbo_to_fill.AddItem("SPEC - Entered Spec Pub Blurb", 3);
				cbo_to_fill.AddItem("SPEC - Entered Info Per Email", 4);
				cbo_to_fill.AddItem("SPEC - Project", 5);
				cbo_to_fill.AddItem("SPEC - QC Item Sent", 6);
				cbo_to_fill.AddItem("SPEC - Entered per DOC", 7);
			}


			if (strNoteType.StartsWith("MEMO", StringComparison.Ordinal))
			{
				cbo_to_fill.AddItem("MEMO - Memo Sent", 1);
				cbo_to_fill.AddItem("MEMO - Memo Attempted", 2);
				cbo_to_fill.AddItem("MEMO - Memo Done", 3);
			}



			// 09/27/2017 - By David D. Cruger; Added
			if (strNoteType.StartsWith("RVEAT", StringComparison.Ordinal))
			{
				cbo_to_fill.AddItem("RVEAT - Reverify Exclusive Attempted", 1);
				cbo_to_fill.Text = "RVEAT - Reverify Exclusive Attempted";
			}


			if (cbo_to_fill.Text.Trim() != "")
			{

			}
			else if (cbo_to_fill.Items.Count > 0)
			{ 
				cbo_to_fill.SelectedIndex = 0;
			}
			else
			{
				cbo_to_fill.SelectedIndex = -1;
			}

			cbo_to_fill.Enabled = true;

			return true;

		}

		internal static bool fill_questionlist_FromArray(ComboBox cbo_to_fill)
		{

			bool result = false;
			try
			{


				cbo_to_fill.Enabled = false;
				cbo_to_fill.Items.Clear();
				//cbo_to_fill.AddItem "" ' don't add empty item to this list

				int tempForEndVar = modGlobalVars.PurchaseQuestion_Array.GetUpperBound(0);
				for (int a_row = modGlobalVars.PurchaseQuestion_Array.GetLowerBound(0); a_row <= tempForEndVar; a_row++)
				{
					cbo_to_fill.AddItem(modGlobalVars.PurchaseQuestion_Array[a_row, modGlobalVars.PURQUEST_NAME].Trim());
					cbo_to_fill.SetItemData(a_row, Convert.ToInt32(Double.Parse(modGlobalVars.PurchaseQuestion_Array[a_row, modGlobalVars.PURQUEST_ID])));
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

				return true;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error("Common (modFillCompConControls)", $"fill_questionlist_FromArray_Error ({Information.Err().Number.ToString()}) {excep.Message}");
				return result;
			}
		}

		internal static bool Fill_Language_FromArray(ComboBox cbo_to_fill)
		{

			bool result = false;
			try
			{

				cbo_to_fill.Enabled = false;
				cbo_to_fill.Items.Clear();
				cbo_to_fill.AddItem("");

				foreach (string Language_Array_item in modGlobalVars.Language_Array)
				{
					cbo_to_fill.AddItem(Language_Array_item);
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

				return true;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error("Common (modFillCompConControls)", $"Fill_Language_FromArray_Error ({Information.Err().Number.ToString()}) {excep.Message}");
				return result;
			}
		}

		internal static bool Fill_AccountRep_FromArray(ComboBox cbo_to_fill, bool bAddNoRep, bool bAddAll)
		{

			bool result = false;
			try
			{

				cbo_to_fill.Enabled = false;
				cbo_to_fill.Items.Clear();

				if (bAddNoRep)
				{
					cbo_to_fill.AddItem("No Rep Selected");
				}
				else if (bAddAll)
				{ 
					cbo_to_fill.AddItem("All");
				}
				else
				{
					cbo_to_fill.AddItem("");
				}

				foreach (string AccountRep_Array_item in modGlobalVars.AccountRep_Array)
				{
					cbo_to_fill.AddItem(AccountRep_Array_item);
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

				return true;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error("Common (modFillCompConControls)", $"Fill_AccountRep_FromArray_Error ({Information.Err().Number.ToString()}) {excep.Message}");
				return result;
			}
		}

		internal static bool Fill_ProductList_FromArray(ComboBox cbo_to_fill, ComboBox cbo_to_fill2)
		{

			bool result = false;
			try
			{


				cbo_to_fill.Enabled = false;
				cbo_to_fill2.Enabled = false;

				cbo_to_fill.Items.Clear();
				cbo_to_fill2.Items.Clear();
				cbo_to_fill.AddItem("None Selected");
				cbo_to_fill2.AddItem("None Selected");

				foreach (string CompanyProduct_Array_item in modGlobalVars.CompanyProduct_Array)
				{
					cbo_to_fill.AddItem(CompanyProduct_Array_item);
					cbo_to_fill2.AddItem(CompanyProduct_Array_item);
				}

				cbo_to_fill.SelectedIndex = 0;
				cbo_to_fill2.SelectedIndex = 0;
				cbo_to_fill.Enabled = true;
				cbo_to_fill2.Enabled = true;

				return true;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error("Common (modFillCompConControls)", $"Fill_ProductList_FromArray_Error ({Information.Err().Number.ToString()}) {excep.Message}");
				return result;
			}
		}

		internal static bool Fill_TitleGroup_FromArray(ListBox lst_to_fill)
		{

			bool result = false;
			try
			{


				lst_to_fill.Enabled = false;
				lst_to_fill.Items.Clear();
				lst_to_fill.AddItem("All");

				foreach (string TitleGroup_Array_item in modGlobalVars.TitleGroup_Array)
				{
					lst_to_fill.AddItem(TitleGroup_Array_item);
				}

				ListBoxHelper.SetSelected(lst_to_fill, 0, true);
				lst_to_fill.Enabled = true;

				return true;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error("Common (modFillCompConControls)", $"Fill_TitleGroup_FromArray_Error ({Information.Err().Number.ToString()}) {excep.Message}");
				return result;
			}
		}

		internal static void Fill_baseAndRegCountryCbos(ComboBox cbo_to_fill_base, ComboBox cbo_to_fill_registration)
		{

			try
			{

				string Query = "";
				ADORecordSetHelper snpCountry = null; //aey 6/10/04

				modFillCompConControls.fill_country_FromArray(cbo_to_fill_base);

				cbo_to_fill_registration.Enabled = false;
				cbo_to_fill_registration.Items.Clear();
				cbo_to_fill_registration.AddItem("");

				Query = "SELECT DISTINCT regnbrpref_country_name FROM Registration_Number_Prefix WITH(NOLOCK)";
				Query = $"{Query} INNER JOIN Country WITH(NOLOCK) ON regnbrpref_country_name = country_name";
				Query = $"{Query} WHERE (country_active_flag = 'Y') AND (regnbrpref_prefix <> '') AND (regnbrpref_prefix IS NOT NULL) ORDER BY regnbrpref_country_name";

				snpCountry = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(snpCountry.Fields) && !(snpCountry.EOF && snpCountry.BOF))
				{


					while(!snpCountry.EOF)
					{

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snpCountry["regnbrpref_country_name"]))
						{
							if (Convert.ToString(snpCountry["regnbrpref_country_name"]).Trim() != "")
							{
								cbo_to_fill_registration.AddItem(Convert.ToString(snpCountry["regnbrpref_country_name"]).Trim());
							}
						}

						snpCountry.MoveNext();
					};

					snpCountry.Close();

				}

				if (cbo_to_fill_registration.Items.Count > 0)
				{
					cbo_to_fill_registration.SelectedIndex = 0;
				}
				else
				{
					cbo_to_fill_registration.SelectedIndex = -1;
				}

				cbo_to_fill_registration.Enabled = true;

				snpCountry = null;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error("Common (modFillCompConControls)", $"Fill_baseAndRegCountryCbos_Error ({Information.Err().Number.ToString()}) {excep.Message}");
				return;
			}

		}

		internal static bool Fill_Owner_Type(ComboBox cbo_to_fill1, ComboBox cbo_to_fill2, ComboBox cbo_to_fill3, ComboBox cbo_to_fill4, TextBox txt_to_fill1, TextBox txt_to_fill2)
		{

			bool result = false;
			try
			{

				cbo_to_fill1.Enabled = false;
				cbo_to_fill1.Items.Clear();
				cbo_to_fill1.AddItem("All");
				cbo_to_fill1.AddItem("Whole Owners");
				cbo_to_fill1.AddItem("Whole Operators");
				cbo_to_fill1.AddItem("Fractional Owners");
				cbo_to_fill1.AddItem("Share Owners");
				cbo_to_fill1.SelectedIndex = 0;

				cbo_to_fill2.Enabled = false;
				cbo_to_fill2.Items.Clear();
				cbo_to_fill2.AddItem(">");
				cbo_to_fill2.AddItem("<");
				cbo_to_fill2.AddItem("=");
				cbo_to_fill2.SelectedIndex = 0;

				txt_to_fill1.Text = ""; //txt_ac_value(0)

				cbo_to_fill3.Enabled = false;
				cbo_to_fill3.Items.Clear();
				cbo_to_fill3.AddItem("All");
				cbo_to_fill3.AddItem("Whole Owners");
				cbo_to_fill3.AddItem("Whole Operators");
				cbo_to_fill3.AddItem("Fractional Owners");
				cbo_to_fill3.AddItem("Share Owners");
				cbo_to_fill3.SelectedIndex = 0;

				cbo_to_fill4.Enabled = false;
				cbo_to_fill4.Items.Clear();
				cbo_to_fill4.AddItem(">");
				cbo_to_fill4.AddItem("<");
				cbo_to_fill4.AddItem("=");
				cbo_to_fill4.SelectedIndex = 0;

				txt_to_fill2.Text = ""; //txt_ac_value(1)

				cbo_to_fill1.Enabled = true;
				cbo_to_fill2.Enabled = true;
				cbo_to_fill3.Enabled = true;
				cbo_to_fill4.Enabled = true;


				return true;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error("Common (modFillCompConControls)", $"Fill_Owner_Type_Error ({Information.Err().Number.ToString()}) {excep.Message}");
				return result;
			}
		}

		internal static bool Fill_Contact_Title(ComboBox cbo_to_fill, ListBox lst_group_selected = null)
		{
			// MODIFIED ON 9/17/2010 TO HANDLE FILLING COMBO VIA ARRAY IF ALL IS PASSED TO FUNCTION
			// OTHERWISE FILL THE ARRAY BY THE USING THE TITLE GROUP SELECTION
			bool result = false;
			try
			{

				string Query = "";
				string inString = "";
				ADORecordSetHelper snpTitle = null;

				bool FillFromDatabase = false; // USED AS VARIABLE TO DETERMINE WHETHER TO FILL FROM DATABASE OR ARRAY

				inString = "";


				cbo_to_fill.Enabled = false;
				cbo_to_fill.Items.Clear();
				cbo_to_fill.AddItem("");
				FillFromDatabase = false;
				//UPGRADE_WARNING: (2080) IsEmpty was upgraded to a comparison and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
				//UPGRADE_WARNING: (2065) Boolean method Information.IsMissing has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
				if (!(lst_group_selected is null) && !String.IsNullOrEmpty(lst_group_selected.Text))
				{
					if (lst_group_selected.Text != "All")
					{
						FillFromDatabase = true;
					}
				}

				if (FillFromDatabase)
				{

					if (!ListBoxHelper.GetSelected(lst_group_selected, 0) && lst_group_selected.SelectedItems.Count > 0)
					{
						int tempForEndVar = lst_group_selected.Items.Count - 1;
						for (int i = 0; i <= tempForEndVar; i++)
						{

							if (ListBoxHelper.GetSelected(lst_group_selected, i))
							{
								if (lst_group_selected.GetListItem(i).ToLower() != "all")
								{
									inString = $"{inString}{lst_group_selected.GetListItem(i)},";
								}
							}

						}

						if (inString != "")
						{
							inString = inString.Substring(0, Math.Min(Strings.Len(inString) - 1, inString.Length));
						}

					}



					Query = "SELECT DISTINCT ctitle_name FROM Contact_Title WITH(NOLOCK)";

					//Call Record_Event("TABLE", "Loaded contact list", 0, 0, 0)
					if (inString != "")
					{
						Query = $"{Query} INNER JOIN Contact_Title_Group_Reference WITH(NOLOCK)  ON ctitle_name = ctitlegref_title_name";
						Query = $"{Query} WHERE ctitlegref_group_name IN ('{StringsHelper.Replace(inString, ",", "','", 1, -1, CompareMethod.Binary)}')";
					}

					Query = $"{Query} ORDER BY ctitle_name";

					snpTitle = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snpTitle.Fields) && !(snpTitle.BOF && snpTitle.EOF))
					{


						while(!snpTitle.EOF)
						{
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(snpTitle["ctitle_name"]))
							{
								if (Convert.ToString(snpTitle["ctitle_name"]).Trim() != modGlobalVars.cEmptyString)
								{
									cbo_to_fill.AddItem(Convert.ToString(snpTitle["ctitle_name"]).Trim());
								}
							}

							snpTitle.MoveNext();
						};
						snpTitle.Close();
					}

					snpTitle = null;

					if (cbo_to_fill.Items.Count > 0)
					{
						cbo_to_fill.SelectedIndex = 0;
					}
					else
					{
						cbo_to_fill.SelectedIndex = -1;
					}

					cbo_to_fill.Enabled = true;

					result = true;
					// ******************************************************************
				}
				else
				{
					// NO GROUP PASSED TO THE FUNCTION SO FILL FROM ARRAY

					cbo_to_fill.Enabled = false;
					cbo_to_fill.Items.Clear();
					cbo_to_fill.AddItem("");

					foreach (string ContactTitle_Array_item in modGlobalVars.ContactTitle_Array)
					{
						cbo_to_fill.AddItem(ContactTitle_Array_item);
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
					result = true;
				}

				cbo_to_fill.Tag = "";
				if (cbo_to_fill.Text.Trim() != "")
				{
					cbo_to_fill.Tag = cbo_to_fill.Text;
				}


				return result;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error("Common (modFillCompConControls)", $"Fill_Contact_Title_Error ({Information.Err().Number.ToString()}) {excep.Message}");
				return result;
			}
		}

		internal static bool Fill_Demographics(System.Windows.Forms.RadioButton[] opt_selected, ListBox lst_to_fill)
		{

			if (opt_selected[0].Checked)
			{
				Fill_Continent_List(lst_to_fill);
			}
			else if (opt_selected[1].Checked)
			{ 
				Fill_Region_List(lst_to_fill);
			}

			return false;
		}

		internal static bool Fill_Region_List(ListBox lst_to_fill)
		{
			bool result = false;
			try
			{

				string Query = "";
				ADORecordSetHelper snp_RegionList = null;

				lst_to_fill.Enabled = false;
				lst_to_fill.Items.Clear();
				lst_to_fill.AddItem("All");

				Query = "SELECT * FROM Region WITH(NOLOCK) ORDER BY region_name";

				snp_RegionList = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(snp_RegionList.Fields) && !(snp_RegionList.BOF && snp_RegionList.EOF))
				{

					while(!snp_RegionList.EOF)
					{
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snp_RegionList["region_name"]))
						{
							if (Convert.ToString(snp_RegionList["region_name"]).Trim() != modGlobalVars.cEmptyString)
							{
								lst_to_fill.AddItem(Convert.ToString(snp_RegionList["region_name"]).Trim());
							}
						}
						snp_RegionList.MoveNext();
					};
					snp_RegionList.Close();
				}

				snp_RegionList = null;

				ListBoxHelper.SetSelected(lst_to_fill, 0, true);
				lst_to_fill.Enabled = true;

				return true;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error("Common (modFillCompConControls)", $"Fill_Region_List_Error ({Information.Err().Number.ToString()}) {excep.Message}");
				return result;
			}
		}

		internal static bool Fill_Continent_List(ListBox lst_to_fill)
		{
			bool result = false;
			try
			{

				string Query = "";
				ADORecordSetHelper snp_ContinentList = null;

				lst_to_fill.Enabled = false;
				lst_to_fill.Items.Clear();
				lst_to_fill.AddItem("All");




				foreach (string Continent_Array_item in modGlobalVars.Continent_Array)
				{
					lst_to_fill.AddItem(Continent_Array_item);
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


				ListBoxHelper.SetSelected(lst_to_fill, 0, true);
				lst_to_fill.Enabled = true;
				return true;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error("Common (modFillCompConControls)", $"Fill_Continent_List_Error ({Information.Err().Number.ToString()}) {excep.Message}");
				return result;
			}
		}

		internal static bool Fill_State_List(System.Windows.Forms.RadioButton[] opt_selected, ListBox lst_to_fill, ListBox selected_country, ListBox selected_area, string Continentlist, string Regionlist, string Countrylist, string Statelist)
		{

			bool result = false;
			try
			{

				string Query = "";
				ADORecordSetHelper snp_StateList = null;

				lst_to_fill.Enabled = false;
				lst_to_fill.Items.Clear();
				lst_to_fill.AddItem("All");

				if (Countrylist != "" && !ListBoxHelper.GetSelected(selected_country, 0))
				{

					Query = "SELECT state_code, state_name FROM State WITH(NOLOCK)";

					if (Regionlist != "")
					{
						Query = $"{Query}, Geographic WITH(NOLOCK)";
					}

					Query = $"{Query} WHERE state_country in ({Countrylist})  AND state_active_flag ='Y'"; //aey 6/25/04

					if (Regionlist != "")
					{
						Query = $"{Query} AND state_code = geographic_state_code AND state_country = geographic_country_name AND geographic_region_name in ({Regionlist})";
					}

				}
				else
				{

					if (Regionlist != "" && opt_selected[1].Checked && !ListBoxHelper.GetSelected(selected_area, 0))
					{
						Query = "SELECT state_code, state_name FROM State WITH(NOLOCK), Geographic WITH(NOLOCK)";
						Query = $"{Query} WHERE state_code = geographic_state_code AND state_country = geographic_country_name AND geographic_region_name in ({Regionlist})";
						Query = $"{Query} and state_active_flag = 'Y'"; //aey 6/25/04
					}

					if (Continentlist != "" && opt_selected[0].Checked && !ListBoxHelper.GetSelected(selected_area, 0))
					{
						Query = "SELECT state_code, state_name FROM State WITH(NOLOCK), Country WITH(NOLOCK)";
						Query = $"{Query} WHERE state_country = country_name AND country_continent_name IN ({Continentlist})";
						Query = $"{Query} and state_active_flag ='Y'"; //aey 6/25/04
					}

				}

				if (Query == "")
				{
					Query = "SELECT state_code, state_name FROM State WITH(NOLOCK) WHERE state_active_flag = 'Y'";
				}

				Query = $"{Query} ORDER BY state_code";

				snp_StateList = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(snp_StateList.Fields) && !(snp_StateList.BOF && snp_StateList.EOF))
				{

					while(!snp_StateList.EOF)
					{
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snp_StateList["state_code"]) && !Convert.IsDBNull(snp_StateList["state_name"]))
						{
							if (Convert.ToString(snp_StateList["state_code"]).Trim() != modGlobalVars.cEmptyString && Convert.ToString(snp_StateList["state_name"]).Trim() != modGlobalVars.cEmptyString)
							{
								lst_to_fill.AddItem($"{Convert.ToString(snp_StateList["state_code"]).Trim()} - {Convert.ToString(snp_StateList["state_name"]).Trim()}");
							}
						}
						snp_StateList.MoveNext();
					};
					snp_StateList.Close();
				}

				snp_StateList = null;

				ListBoxHelper.SetSelected(lst_to_fill, 0, true);
				lst_to_fill.Enabled = true;
				return true;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error("Common (modFillCompConControls)", $"Fill_State_List_Error ({Information.Err().Number.ToString()}) {excep.Message}");
				return result;
			}
		}

		internal static bool Fill_Country_List(ListBox lst_to_fill, ListBox selected_area, string Continentlist, string Regionlist)
		{

			bool result = false;
			string Query = "";
			ADORecordSetHelper snp_CountryList = null;

			try
			{

				lst_to_fill.Enabled = false;
				lst_to_fill.Items.Clear();
				lst_to_fill.AddItem("All");


				if ((Continentlist != "" && !ListBoxHelper.GetSelected(selected_area, 0)) || Regionlist != "")
				{

					Query = "SELECT distinct country_name FROM Country WITH(NOLOCK), Geographic WITH(NOLOCK) WHERE country_name = geographic_country_name";
					//Call Record_Event("TABLE", "Fill Country_List", 0, 0, 0, False)
					if (Continentlist != "" && !ListBoxHelper.GetSelected(selected_area, 0))
					{
						Query = $"{Query} AND country_continent_name IN ({Continentlist})";
					}
					else
					{
						if (Regionlist != "")
						{
							Query = $"{Query} AND geographic_region_name IN ({Regionlist})";
						}
					}
					Query = $"{Query} ORDER BY country_name";

					snp_CountryList = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snp_CountryList.Fields) && !(snp_CountryList.BOF && snp_CountryList.EOF))
					{

						while(!snp_CountryList.EOF)
						{
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(snp_CountryList["country_name"]))
							{
								if (Convert.ToString(snp_CountryList["country_name"]).Trim() != modGlobalVars.cEmptyString)
								{
									lst_to_fill.AddItem(Convert.ToString(snp_CountryList["country_name"]).Trim());
								}
							}
							snp_CountryList.MoveNext();
						};
						snp_CountryList.Close();
					}

					snp_CountryList = null;

					ListBoxHelper.SetSelected(lst_to_fill, 0, true);
					lst_to_fill.Enabled = true;

					return true;
				}
				else
				{
					// JUST FILL ARRAY WITH ALL VALUES
					//
					foreach (string Country_Array_item in modGlobalVars.Country_Array)
					{
						lst_to_fill.AddItem(Country_Array_item);
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
					return true;
				}
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error("Common (modFillCompConControls)", $"Fill_Country_List_Error ({Information.Err().Number.ToString()}) {excep.Message}");
				return result;
			}
		}

		internal static void Select_Unknown_Country(ComboBox cbo_State, ComboBox cbo_country)
		{

			try
			{

				bool bFoundIt = false;
				bFoundIt = false;
				string sFoundCountry = "";
				sFoundCountry = "";
				string[] l_tmpArray = null;
				NotUpgradedHelper.NotifyNotUpgradedElement("The following assignment/return was commented because it has incompatible types");
				//l_tmpArray = (string[]) ArraysHelper.DeepCopy(null);
				string strState = "";

                // gap-note: jgamboa. Use SetToolTipText extension method to set the tooltip of the control in the ToolTipMain.
                cbo_State.SetToolTipText(cbo_State.Text);
                // gap-note: jgamboa. Use SetToolTipText extension method to set the tooltip of the control in the ToolTipMain.
                cbo_country.SetToolTipText(cbo_country.Text);

				strState = cbo_State.Text.Trim().ToUpper();
				if (strState != "")
				{
					if (strState.IndexOf(", ") >= 0)
					{
						strState = strState.Substring(0, Math.Min(strState.IndexOf(", "), strState.Length));
					}
				}

				int tempForEndVar = modGlobalVars.State_Array.GetUpperBound(0);
				for (int i = modGlobalVars.State_Array.GetLowerBound(0); i <= tempForEndVar; i++)
				{

					l_tmpArray = modGlobalVars.State_Array[i].Split(new string[]{", "}, StringSplitOptions.None);

					if (strState == l_tmpArray[0].Trim().ToUpper())
					{
						sFoundCountry = l_tmpArray[1].Trim();
						break;
					}

				}

				if (sFoundCountry != "")
				{

					int tempForEndVar2 = cbo_country.Items.Count - 1;
					for (int i = 0; i <= tempForEndVar2; i++)
					{

						if (sFoundCountry.ToLower().Trim() == cbo_country.GetListItem(i).Trim().ToLower())
						{

							cbo_country.SelectedIndex = i;

							bFoundIt = true;
							break;

						}

					}

				}

				if (strState != "")
				{

					if (!bFoundIt)
					{
						if (cbo_country.Items.Count > 0)
						{
							cbo_country.SelectedIndex = 0;
						}
						else
						{
							cbo_country.SelectedIndex = -1;
						}
					}

				}
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error("Common (modFillCompConControls)", $"Select_Unknown_Country_Error ({Information.Err().Number.ToString()}) {excep.Message}");
			}

		}

		internal static void Select_Unknown_Country_By_ID(ComboBox cbo_State, ComboBox cbo_country)
		{

			try
			{

				bool bFoundIt = false;
				bFoundIt = false;
				string sFoundCountry = "";
				sFoundCountry = "";
				string[] l_tmpArray = null;
				NotUpgradedHelper.NotifyNotUpgradedElement("The following assignment/return was commented because it has incompatible types");
				//l_tmpArray = (string[]) ArraysHelper.DeepCopy(null);
				int starting_state = 0;

				starting_state = (cbo_State.SelectedIndex - 1);

				// gap-note: jgamboa. Use SetToolTipText extension method to set the tooltip of the control in the ToolTipMain.
				cbo_State.SetToolTipText(cbo_State.Text);
                // gap-note: jgamboa. Use SetToolTipText extension method to set the tooltip of the control in the ToolTipMain.
                cbo_country.SetToolTipText(cbo_country.Text);

				int tempForEndVar = modGlobalVars.State_Array.GetUpperBound(0);
				for (int i = modGlobalVars.State_Array.GetLowerBound(0); i <= tempForEndVar; i++)
				{

					l_tmpArray = modGlobalVars.State_Array[i].Split(new string[]{", "}, StringSplitOptions.None);

					if (cbo_State.Text.Substring(0, Math.Min(cbo_State.Text.IndexOf(", "), cbo_State.Text.Length)).Trim().ToUpper() == l_tmpArray[0].Trim().ToUpper())
					{
						if (starting_state == i)
						{
							sFoundCountry = l_tmpArray[1].Trim();
							break;
						}
					}

				}

				if (sFoundCountry != "")
				{

					int tempForEndVar2 = cbo_country.Items.Count - 1;
					for (int i = 0; i <= tempForEndVar2; i++)
					{

						if (sFoundCountry.ToLower().Trim() == cbo_country.GetListItem(i).Trim().ToLower())
						{
							frm_CompanyAdd.DefInstance.state_clicked = true;
							cbo_country.SelectedIndex = i; // this will fire country click
							bFoundIt = true;
							frm_CompanyAdd.DefInstance.state_clicked = false;
							break;

						}

					}

				}

				if (cbo_State.Text != "")
				{

					if (!bFoundIt)
					{
						if (cbo_country.Items.Count > 0)
						{
							cbo_country.SelectedIndex = 0;
						}
						else
						{
							cbo_country.SelectedIndex = -1;
						}
					}

				}
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error("Common (modFillCompConControls)", $"Select_Unknown_Country_Error ({Information.Err().Number.ToString()}) {excep.Message}");
				return;
			}

		}


		internal static void Check_If_Country_HasState(ComboBox cbo_State, ComboBox cbo_country)
		{

			string strState = "";
			string strCOUNTRY = "";

			try
			{

				strState = cbo_State.Text.Trim().ToLower();
				strCOUNTRY = cbo_country.Text.Trim().ToLower();

                // gap-note: jgamboa. Use SetToolTipText extension method to set the tooltip of the control in the ToolTipMain.
                cbo_State.SetToolTipText(strState);
                // gap-note: jgamboa. Use SetToolTipText extension method to set the tooltip of the control in the ToolTipMain.
                cbo_country.SetToolTipText(strCOUNTRY);

				if (strCOUNTRY != "")
				{

					if ((strCOUNTRY != "united states") && (strCOUNTRY != "canada") && (strCOUNTRY != "brazil") && (strCOUNTRY != "australia"))
					{

						if ((cbo_State.Items.Count > 0) && (strState != ""))
						{
							cbo_State.SelectedIndex = 0;
						}

					}

				} // If strCountry <> "" Then
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error("Common (modFillCompConControls)", $"Check_If_Country_HasState_Error ({Information.Err().Number.ToString()}) {excep.Message}");
				return;
			}

		} // End Sub Check_If_Country_HasState

		internal static bool Fill_Contact_Type_ListFromArray(ComboBox cbo_to_fill, Label lbl_to_fill, modGlobalVars.e_find_form_entry_points tIn_entry_point)
		{

			bool result = false;
			try
			{
				string Query = "";
				ADORecordSetHelper snp_ContactType = new ADORecordSetHelper();
				object i = null;
				int nCounter = 0;
				string last_contact_type = "";

				last_contact_type = "";
				lbl_to_fill.Text = "";

				cbo_to_fill.Enabled = false;
				cbo_to_fill.Items.Clear();

				if (modCommon.pubf_EncodeEntryPoints(tIn_entry_point) == modGlobalVars.gFIND_ACCA || modCommon.pubf_EncodeEntryPoints(tIn_entry_point) == modGlobalVars.gFIND_ASHR || modCommon.pubf_EncodeEntryPoints(tIn_entry_point) == modGlobalVars.gFIND_EXBK || modCommon.pubf_EncodeEntryPoints(tIn_entry_point) == modGlobalVars.gFIND_ACOR)
				{


					if (modCommon.pubf_EncodeEntryPoints(tIn_entry_point) == modGlobalVars.gFIND_EXBK)
					{

						cbo_to_fill.AddItem("Exclusive Broker");
						cbo_to_fill.SetItemData(cbo_to_fill.GetNewIndex(), Convert.ToInt32(Double.Parse(modCompanyFind.Get_ItemFrom_Contact_Type_Array("99", tIn_entry_point, modGlobalVars.AIRCONT_INDEX))));
						cbo_to_fill.AddItem("Exclusive Representative");
						cbo_to_fill.SetItemData(cbo_to_fill.GetNewIndex(), Convert.ToInt32(Double.Parse(modCompanyFind.Get_ItemFrom_Contact_Type_Array("93", tIn_entry_point, modGlobalVars.AIRCONT_INDEX))));

						if (cbo_to_fill.Items.Count > 0)
						{
							cbo_to_fill.SelectedIndex = 0;
						}
						else
						{
							cbo_to_fill.SelectedIndex = -1;
						}

						cbo_to_fill.Enabled = true;


						return true;
					}

					int tempForEndVar = modGlobalVars.ContactType_Array.GetUpperBound(0);
					for (int a_row = modGlobalVars.ContactType_Array.GetLowerBound(0); a_row <= tempForEndVar; a_row++)
					{

						if (modCommon.pubf_EncodeEntryPoints(tIn_entry_point) == modGlobalVars.gFIND_ACCA)
						{
							if (modGlobalVars.ContactType_Array[a_row, modGlobalVars.AIRCONT_USE].ToLower() == ("R").ToLower())
							{

								if (last_contact_type.Trim() != modGlobalVars.ContactType_Array[a_row, modGlobalVars.AIRCONT_NAME].Trim())
								{
									last_contact_type = modGlobalVars.ContactType_Array[a_row, modGlobalVars.AIRCONT_NAME].Trim();
									cbo_to_fill.AddItem(modGlobalVars.ContactType_Array[a_row, modGlobalVars.AIRCONT_NAME].Trim());
									cbo_to_fill.SetItemData(cbo_to_fill.GetNewIndex(), Convert.ToInt32(Double.Parse(modGlobalVars.ContactType_Array[a_row, modGlobalVars.AIRCONT_INDEX])));
								}
							}
						}
						else if (modCommon.pubf_EncodeEntryPoints(tIn_entry_point) == modGlobalVars.gFIND_ACOR)
						{ 
							if (modGlobalVars.ContactType_Array[a_row, modGlobalVars.AIRCONT_COMP].ToLower() == ("Y").ToLower())
							{
								if (modGlobalVars.ContactType_Array[a_row, modGlobalVars.AIRCONT_NAME].ToLower() != modGlobalVars.ContactType_Array[a_row, modGlobalVars.AIRCONT_NAMEREF].ToLower())
								{
									if (modGlobalVars.ContactType_Array[a_row, modGlobalVars.AIRCONT_NAMEREF].Trim() != "")
									{
										cbo_to_fill.AddItem($"{modGlobalVars.ContactType_Array[a_row, modGlobalVars.AIRCONT_NAME].Trim()}/{modGlobalVars.ContactType_Array[a_row, modGlobalVars.AIRCONT_NAMEREF].Trim()}");
										cbo_to_fill.SetItemData(cbo_to_fill.GetNewIndex(), Convert.ToInt32(Double.Parse(modGlobalVars.ContactType_Array[a_row, modGlobalVars.AIRCONT_INDEX])));
									}
								}
								else
								{
									cbo_to_fill.AddItem(modGlobalVars.ContactType_Array[a_row, modGlobalVars.AIRCONT_NAME].Trim());
									cbo_to_fill.SetItemData(cbo_to_fill.GetNewIndex(), Convert.ToInt32(Double.Parse(modGlobalVars.ContactType_Array[a_row, modGlobalVars.AIRCONT_INDEX])));
								}
							}
						}
						else if (modCommon.pubf_EncodeEntryPoints(tIn_entry_point) == modGlobalVars.gFIND_ASHR)
						{ 
							if (modGlobalVars.ContactType_Array[a_row, modGlobalVars.AIRCONT_SHARE].ToLower() == ("Y").ToLower())
							{
								cbo_to_fill.AddItem(modGlobalVars.ContactType_Array[a_row, modGlobalVars.AIRCONT_NAME].Trim());
								cbo_to_fill.SetItemData(cbo_to_fill.GetNewIndex(), Convert.ToInt32(Double.Parse(modGlobalVars.ContactType_Array[a_row, modGlobalVars.AIRCONT_INDEX])));
							}
						}

					}

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


				return true;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error("Common (modFillCompConControls)", $"Fill_Contact_Type_ListFromArray_Error ({Information.Err().Number.ToString()}) {excep.Message}");
				return result;
			}
		}

		internal static bool Fill_Company_Business_Types(int n_inCompanyID, int n_inCompanyJID, ListBox lst_to_fill, ComboBox cbo_to_set, ref bool bBlockAirBp, bool isABISelected, bool isABISelectedOnly)
		{
			//
			// PURPOSE: FILL THE LIST OF COMPANY BUSINESS TYPES
			// FOR THE SELECTED COMPANY.

			bool result = false;
			try
			{

				string Query = "";
				ADORecordSetHelper snpBusTypes = null;
				int i = 0;
				string lstItem = "";

				// CLEAR THE LIST BOX AND THEN FILL IT WITH THE BUSINESS TYPES FOR THE COMPANY
				lst_to_fill.Enabled = false;
				lst_to_fill.Items.Clear();
				bBlockAirBp = false;
				if (n_inCompanyID > 0)
				{

					Query = "SELECT * FROM Business_Type_Reference WITH(NOLOCK), Company_Business_Type WITH(NOLOCK)";
					Query = $"{Query} WHERE cbus_type = bustypref_type  AND bustypref_comp_id = {n_inCompanyID.ToString()} AND bustypref_journ_id = {n_inCompanyJID.ToString()}";

					if (!isABISelected)
					{
						Query = $"{Query} AND cbus_abi_flag = 'N'";
					}
					else if (isABISelected && isABISelectedOnly)
					{ 
						Query = $"{Query} AND cbus_abi_flag = 'Y'";
					}

					Query = $"{Query} ORDER BY cbus_abi_flag, bustypref_seq_no";

					snpBusTypes = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snpBusTypes.Fields) && !(snpBusTypes.BOF && snpBusTypes.EOF))
					{

						while(!snpBusTypes.EOF)
						{

							if (Convert.ToString(snpBusTypes["cbus_type"]).Trim() == "MF" || Convert.ToString(snpBusTypes["cbus_type"]).Trim() == "LS")
							{
								bBlockAirBp = true;
							}

							if (Convert.ToString(snpBusTypes["cbus_abi_flag"]).ToUpper() == "Y")
							{
								lst_to_fill.AddItem(($"{Convert.ToString(snpBusTypes["cbus_type"])} - * {Convert.ToString(snpBusTypes["cbus_name"])}").Trim());
							}
							else
							{
								lst_to_fill.AddItem(($"{Convert.ToString(snpBusTypes["cbus_type"])} - {Convert.ToString(snpBusTypes["cbus_name"])}").Trim());
							}
							snpBusTypes.MoveNext();
						};
						snpBusTypes.Close();
					}

					if (lst_to_fill.Items.Count > 0)
					{
						cbo_to_set.SetListItem(0, lst_to_fill.GetListItem(0));
						cbo_to_set.Text = lst_to_fill.GetListItem(0);
					}

					snpBusTypes = null;

					lst_to_fill.Enabled = true;
					cbo_to_set.Enabled = false;

				}


				return true;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error("Common (modFillCompConControls)", $"Fill_Company_Business_Types_Error ({Information.Err().Number.ToString()}) {excep.Message}");
				return result;
			}
		}

		internal static bool Fill_Journal_Note_Type(ComboBox cbo_to_fill, bool bShowAircraftNotes, bool bShowAllNotes, bool bShowYachtNotes = false, bool show_all_new = true)
		{

			bool result = false;
			try
			{

				// CLEAR THE LIST BOX AND THEN FILL IT WITH THE BUSINESS TYPES FOR THE COMPANY
				cbo_to_fill.Enabled = false;
				cbo_to_fill.Items.Clear();


				if (show_all_new)
				{
					cbo_to_fill.AddItem("All - Display All Rep Notes");

					cbo_to_fill.AddItem("RS - Research");
				}

				cbo_to_fill.AddItem("RN - Account Representative Note");
				cbo_to_fill.AddItem("MN - Marketing Representative Note");
				cbo_to_fill.AddItem("TN - Technical Representative Note");
				cbo_to_fill.AddItem("ML - Mail List Note");

				//added MSW 1/20/2014
				cbo_to_fill.AddItem("CN - Commercial Representative Note");
				cbo_to_fill.AddItem("FN - Fractional Representative Note");

				cbo_to_fill.AddItem("iQ - Survey Notes");

				// 03/22/2013 - msw added for yacht notes category
				// cbo_to_fill.AddItem ("YN - Yacht Notes")

				if (bShowAircraftNotes)
				{
					cbo_to_fill.AddItem("AH - Aircraft History Notes");
				}

				if (bShowYachtNotes)
				{
					// 07/24/2014 - By David D. Cruger Include Yacht History Notes
					cbo_to_fill.AddItem("YH - Yacht History Notes");
				}

				cbo_to_fill.AddItem("AN - Aircraft Delivery Notes");

				cbo_to_fill.AddItem("IDNOTE - ID Note");

				cbo_to_fill.AddItem("PBNOTE - PUB Note");

				// 05/12/2017 - By David D. Cruger; Added
				cbo_to_fill.AddItem("RAAT - Reassign Attempted");

				// commented out per request - MSW - 3/1/23
				if (cbo_to_fill.Name == "cbo_journal_note_type")
				{
					cbo_to_fill.AddItem("DOCAT - Doc Attempted");
				}
				// 09/27/2017 - By David D. Cruger; Added
				cbo_to_fill.AddItem("RADN - Reassign Procedures Done");
				cbo_to_fill.AddItem("RVEAT - Reverify Exclusive Attempted");

				cbo_to_fill.AddItem("PROJ - Project Notes");

				// added MSW - 12/12/18
				cbo_to_fill.AddItem("SPEC - Spec Note");

				// added MSW - 3/18/19
				cbo_to_fill.AddItem("MEMO - Memo Note");


				// added MSW - 11/21/19
				cbo_to_fill.AddItem("CC - Company Formal Name Change");

				cbo_to_fill.AddItem("CS - Customer Support");

				cbo_to_fill.AddItem("REGCHK - Reg Check");

				cbo_to_fill.AddItem("SN - Subscription Notes");

				// changed to default to 0 msw - per request from patty = 9/27/22
				cbo_to_fill.SelectedIndex = 0;


				cbo_to_fill.Enabled = true;


				return true;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error("Common (modFillCompConControls)", $"Fill_Journal_Note_Type_Error ({Information.Err().Number.ToString()}) {excep.Message}");
			}
			return result;
		}

		internal static bool Fill_Wanted_Damage_List(ComboBox cbo_to_fill)
		{

			bool result = false;
			try
			{

				cbo_to_fill.Enabled = false;
				cbo_to_fill.Items.Clear();

				cbo_to_fill.AddItem("Y", 0);
				cbo_to_fill.AddItem("N", 1);
				cbo_to_fill.AddItem("U", 2);

				cbo_to_fill.Enabled = true;

				if (cbo_to_fill.Items.Count > 0)
				{
					cbo_to_fill.SelectedIndex = 0;
				}
				else
				{
					cbo_to_fill.SelectedIndex = -1;
				}


				return true;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error("Common (modFillCompConControls)", $"Fill_Wanted_Damage_List_Error ({Information.Err().Number.ToString()}) {excep.Message}");
				return result;
			}
		}

		internal static bool Fill_GovernmentSubCode_List(ComboBox cbo_to_fill)
		{


			bool result = false;
			string Query = "";
			ADORecordSetHelper snp_GovSubCodeList = null;

			try
			{

				cbo_to_fill.Items.Clear();
				cbo_to_fill.Enabled = false;
				cbo_to_fill.AddItem("");

				Query = "SELECT * FROM Government WITH(NOLOCK) ORDER BY gov_id";

				snp_GovSubCodeList = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(snp_GovSubCodeList.Fields) && !(snp_GovSubCodeList.BOF && snp_GovSubCodeList.EOF))
				{

					while(!snp_GovSubCodeList.EOF)
					{
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snp_GovSubCodeList["gov_id"]))
						{
							if (Convert.ToDouble(snp_GovSubCodeList["gov_id"]) > 0)
							{
								cbo_to_fill.AddItem(Convert.ToString(snp_GovSubCodeList["gov_type"]).Trim());
							}
						}
						snp_GovSubCodeList.MoveNext();
					};
					snp_GovSubCodeList.Close();
				}

				snp_GovSubCodeList = null;

				if (cbo_to_fill.Items.Count > 0)
				{
					int tempForEndVar = cbo_to_fill.Items.Count - 1;
					for (int i = 0; i <= tempForEndVar; i++)
					{
						if (cbo_to_fill.GetListItem(i).Trim().ToLower() == "other")
						{
							cbo_to_fill.SelectedIndex = i;
							break;
						}
					}

				}
				else
				{
					cbo_to_fill.SelectedIndex = -1;
				}

				cbo_to_fill.Enabled = true;


				return true;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error("Common (modFillCompConControls)", $"Fill_GovernmentSubCode_List_Error ({Information.Err().Number.ToString()}) {excep.Message}");
				return result;
			}
		}

		internal static bool Fill_Deliver_Position_List(ComboBox cbo_to_fill, bool inCommericalcomp, bool inOthercomp, int FixPosition = 0)
		{

			bool result = false;
			try
			{

				if (cbo_to_fill.Items.Count == 0)
				{

					cbo_to_fill.AddItem("View No D.P");
					cbo_to_fill.AddItem("View Only D.P");
					cbo_to_fill.AddItem("View All Aircraft");

					cbo_to_fill.AddItem("Available A/C");
					cbo_to_fill.AddItem("Available w/Excl");
					cbo_to_fill.AddItem("All Active A/C");
					cbo_to_fill.AddItem("Primary A/C");
					cbo_to_fill.AddItem("Leased A/C");
					cbo_to_fill.AddItem("Class A");
					cbo_to_fill.AddItem("Class E");
					cbo_to_fill.AddItem("Business A/C");
					cbo_to_fill.AddItem("Helicopters");
					cbo_to_fill.AddItem("Commercial A/C");
					cbo_to_fill.AddItem("Reassigns");
					cbo_to_fill.AddItem("Research Only");
					cbo_to_fill.Tag = "N"; // Do NOT Clear

				}

				// RTW - 9/2/2010 - MODIFIED TO USE A FIXED COMBO POSITION IF PASSED TO IT - OTHERWISE DEFAULT TO RULES
				if (FixPosition >= 0)
				{
					cbo_to_fill.SelectedIndex = FixPosition;
				}
				else
				{
					//compares the two booleans to see if dp's should be shown or not
					if (inCommericalcomp && !inOthercomp)
					{
						cbo_to_fill.SelectedIndex = 0;
					}
					else
					{
						cbo_to_fill.SelectedIndex = 2;
					}
				}


				return true;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error("Common (modFillCompConControls)", $"Fill_Deliver_Position_List_Error ({Information.Err().Number.ToString()}) {excep.Message}");
				return result;
			}
		} // Fill_Deliver_Position_List

		internal static bool Fill_MailList_FromArray(ComboBox cbo_to_fill)
		{

			bool result = false;
			try
			{
				result = false;


				cbo_to_fill.Enabled = false;
				cbo_to_fill.Items.Clear();
				cbo_to_fill.AddItem("");

				foreach (string MailList_Array_item in modGlobalVars.MailList_Array)
				{
					cbo_to_fill.AddItem(MailList_Array_item);
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


				return true;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error("Common (modFillCompConControls)", $"Fill_MailList_FromArray_Error ({Information.Err().Number.ToString()}) {excep.Message}");
				return result;
			}
		}

		internal static void Fill_EMail_Notice_List(ComboBox cmbBox, string strWhere, bool bIncludeJNiQ = true)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			try
			{

				cmbBox.Enabled = false;

				strQuery1 = "SELECT * FROM EMail_Notices WITH (NOLOCK) WHERE (em_active_flag = 'Y') ";

				switch(strWhere)
				{
					case "Company" : 
						strQuery1 = $"{strQuery1}AND (em_comp_flag = 'Y') "; 
						break;
					case "Contact" : 
						strQuery1 = $"{strQuery1}AND (em_contact_flag = 'Y') "; 
						break;
					case "Aircraft" : 
						strQuery1 = $"{strQuery1}AND (em_aircraft_flag = 'Y') "; 
						break;
					case "Yacht" : 
						strQuery1 = $"{strQuery1}AND (em_yacht_flag = 'Y') "; 
						break;
				} // Case strWhere

				// 01/06/2016 - By David D. Cruger
				if (!bIncludeJNiQ)
				{
					strQuery1 = $"{strQuery1}AND (em_name NOT LIKE '%JNiQ%') ";
				}

				strQuery1 = $"{strQuery1}AND (em_expires_date IS NULL OR em_expires_date > GETDATE()) ORDER BY em_seq_no ";

				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					cmbBox.Items.Clear();

					do 
					{ // Loop Until rstRec1.EOF = True

						cmbBox.AddItem(($"{Convert.ToString(rstRec1["em_name"])} ").Trim());
						cmbBox.SetItemData(cmbBox.GetNewIndex(), Convert.ToInt32(rstRec1["em_id"]));

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If rstRec1.BOF = False And rstRec1.EOF = False Then

				rstRec1.Close();

				cmbBox.Text = cmbBox.GetListItem(0);
				cmbBox.Enabled = true;

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Fill_EMail_Notice_List_Error", excep.Message);
			}

		} // Fill_EMail_Notice_List

		internal static void Fill_Company_Marketing_Rep_ComboBox(ComboBox cmbCombo, bool bActiveContatsOnly)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strMktRepName = "";

			try
			{

				cmbCombo.Enabled = false;

				strQuery1 = "SELECT user_first_name, user_last_name, user_password  FROM [User] WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (user_first_name IS NOT NULL) AND (user_first_name <> '') ";
				strQuery1 = $"{strQuery1}AND (user_last_name IS NOT NULL)  AND (user_last_name <> '') ";
				strQuery1 = $"{strQuery1}AND (user_last_name NOT IN ('Rep','Mass Add','Company Combine','Employees','Transaction')) ";
				strQuery1 = $"{strQuery1}AND (user_first_name NOT IN ('Unidentified','MVInTech','Commercial','Delivery Pos','Department','Aussie','Homebase')) ";

				if (bActiveContatsOnly)
				{
					strQuery1 = $"{strQuery1}AND (user_password <> 'inactive') ";
				}

				strQuery1 = $"{strQuery1}ORDER BY user_first_name,user_last_name ";

				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					cmbCombo.Items.Clear();
					cmbCombo.AddItem("");

					do 
					{ // Loop Until rstRec1.EOF = True

						strMktRepName = $"{($"{Convert.ToString(rstRec1["user_first_name"])} ").Trim()} {($"{Convert.ToString(rstRec1["user_last_name"])} ").Trim()}";
						if (($"{Convert.ToString(rstRec1["user_password"])} ").Trim() == "inactive")
						{
							strMktRepName = $"{strMktRepName} -NA";
						}

						cmbCombo.AddItem(strMktRepName);

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If rstRec1.BOF = False And rstRec1.EOF = False Then

				rstRec1.Close();

				cmbCombo.Enabled = true;

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Fill_Company_Marketing_Rep_ComboBox_Error", excep.Message);
			}

		} //

		internal static void Fill_Yacht_Reference_List_Box(ListBox lstBox)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			try
			{

				lstBox.Items.Clear();
				lstBox.AddItem("");

				strQuery1 = "SELECT yct_name FROM Yacht_Contact_Type WITH (NOLOCK) WHERE (yct_yacht_reference_flag = 'Y') ORDER BY yct_name ";

				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					do 
					{ // Loop Until rstRec1.EOF = True
						lstBox.AddItem(($"{Convert.ToString(rstRec1["yct_name"])} ").Trim());
						rstRec1.MoveNext();
					}
					while(!rstRec1.EOF);

				} // If rstRec1.BOF = False And rstRec1.EOF = False Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Fill_Yacht_Reference_List_Box_Error", excep.Message);
			}

		} // Fill_Yacht_Reference_List_Box

		internal static void Fill_Aircraft_Model_JETNET_iQ_Size_Category_Combo_Box(ComboBox cbBox)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			try
			{

				cbBox.Items.Clear();
				cbBox.AddItem("");

				strQuery1 = "SELECT amjiqs_cat_code, amjiqs_cat_desc FROM Aircraft_Model_JIQ_Size WITH (NOLOCK) ORDER BY amjiqs_cat_code ";

				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					do 
					{ // Loop Until rstRec1.EOF = True
						cbBox.AddItem($"{($"{Convert.ToString(rstRec1["amjiqs_cat_code"])} ").Trim()} - {($"{Convert.ToString(rstRec1["amjiqs_cat_desc"])} ").Trim()}");
						rstRec1.MoveNext();
					}
					while(!rstRec1.EOF);

				}

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Fill_Aircraft_Model_JETNET_iQ_Size_Category_Combo_Box_Error", excep.Message);
			}

		}
	}
}