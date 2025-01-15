using Microsoft.VisualBasic;
using System;
using System.Data.Common;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Gui.Controls;

namespace JETNET_Homebase
{
	internal static class modAircraftChange
	{


		internal static bool Buyer_Is_Broker(int inBuyer_ID)
		{

			//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			// Retrieve the 'Primary Point of Contact' from the 'Aircraft_Reference' table
			//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

			bool result = false;
			try
			{

				string Query = "";
				ADORecordSetHelper snp_POC = new ADORecordSetHelper(); // Snapshot aey 7/21/04 converted to ado

				result = false;

				Query = "SELECT cref_comp_id FROM Aircraft_Reference WITH(NOLOCK)";
				Query = $"{Query} WHERE cref_ac_id = {modAdminCommon.gbl_Aircraft_ID.ToString()}";
				Query = $"{Query} AND cref_journ_id = 0";
				Query = $"{Query} AND cref_contact_type in ('93','98','99')";
				Query = $"{Query} AND cref_comp_id = {inBuyer_ID.ToString()}";

				snp_POC.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_POC.BOF && snp_POC.EOF))
				{
					result = true;
				}

				snp_POC.Close();
				snp_POC = null;
				return result;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Buyer_Is_Broker: {Information.Err().Number.ToString()} {excep.Message}");
				return result;
			}
		}

		internal static void Display_Buyer_Info(ListBox lst_Buyer_to_fill, ComboBox cbo_Buyer_to_fill, int inCompany_ID, int inContact_ID, ref string Company_Business_Type, ref string COMPANY_NAME, bool isAwaitingDocs = false)
		{

			try
			{

				string Query = "";
				ADORecordSetHelper snpContact = new ADORecordSetHelper(); //8/11/05 aey
				ADORecordSetHelper snpCompany = new ADORecordSetHelper(); //Snapshot
				string M = "";

				lst_Buyer_to_fill.Items.Clear();

				if (inContact_ID > 0)
				{
					Query = $"SELECT * FROM Contact WITH(NOLOCK) WHERE contact_id = {inContact_ID.ToString()}";

					snpContact.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!(snpContact.BOF && snpContact.EOF))
					{

						M = ($"{Convert.ToString(snpContact["contact_last_name"])}").Trim();

						if (Strings.Len(($"{Convert.ToString(snpContact["contact_first_name"])}").Trim()) > 0)
						{
							M = $"{M}, {($"{Convert.ToString(snpContact["contact_first_name"])}").Trim()}";
						}

						if (Strings.Len(($"{Convert.ToString(snpContact["contact_middle_initial"])}").Trim()) > 0)
						{
							M = $"{M} {($"{Convert.ToString(snpContact["contact_middle_initial"])}").Trim()}.";
						}

						lst_Buyer_to_fill.AddItem(M);
					}

					snpContact.Close();

				}

				if (inCompany_ID > 0)
				{
					Query = "SELECT comp_id, comp_name, comp_city, comp_state, comp_country, comp_business_type, cbus_name";
					Query = $"{Query} FROM Company WITH(NOLOCK), Company_Business_Type WITH(NOLOCK)";
					Query = $"{Query} WHERE comp_id = {inCompany_ID.ToString()} AND comp_journ_id = 0";
					Query = $"{Query} AND cbus_type = comp_business_type";

					snpCompany.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!(snpCompany.BOF && snpCompany.EOF))
					{

						lst_Buyer_to_fill.AddItem(($"{Convert.ToString(snpCompany["Comp_Name"])}").Trim());
						M = ($"{Convert.ToString(snpCompany["comp_city"])}").Trim();

						if (Strings.Len(($"{Convert.ToString(snpCompany["comp_state"])}").Trim()) > 0)
						{
							M = $"{M}, {($"{Convert.ToString(snpCompany["comp_state"])}").Trim()}";
						}

						if (Strings.Len(($"{Convert.ToString(snpCompany["comp_country"])}").Trim()) > 0)
						{
							M = $"{M}, {($"{Convert.ToString(snpCompany["comp_country"])}").Trim()}";
						}

						lst_Buyer_to_fill.AddItem(M);
						lst_Buyer_to_fill.AddItem(($"{Convert.ToString(snpCompany["cbus_name"])}").Trim());

						Company_Business_Type = ($"{Convert.ToString(snpCompany["comp_business_type"])}").Trim();
						COMPANY_NAME = ($"{Convert.ToString(snpCompany["Comp_Name"])}").Trim();

					}
					else
					{

						Company_Business_Type = "";
						COMPANY_NAME = "";

					}

					snpCompany.Close();

					Fill_cbo_Trans_Buyer(cbo_Buyer_to_fill, inCompany_ID, Company_Business_Type, isAwaitingDocs);

				}

				lst_Buyer_to_fill.Refresh();

				snpContact = null;
				snpCompany = null;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Display_Buyer_Info_Error: {Information.Err().Number.ToString()} {excep.Message}");
			}

		}

		internal static void Fill_cbo_Trans_Buyer(ComboBox cbo_Buyer, int inCompanyID, string inComp_BusType, bool isAwaitingDocs = false)
		{
			try
			{

				string Query = "";
				ADORecordSetHelper snp_CBT = new ADORecordSetHelper(); //8/11/05 aey

				cbo_Buyer.Visible = false;
				cbo_Buyer.Items.Clear();

				if (inCompanyID > 0 || isAwaitingDocs)
				{

					if (isAwaitingDocs)
					{
						inCompanyID = 0;
					}
					// RTW - CHANGED TO BE AN INNER JOIN AND GET ONLY FIELDS NECESSARY
					// 1/27/2010
					Query = "SELECT cbus_type, cbus_name  FROM Company_Business_Type WITH(NOLOCK) ";
					Query = $"{Query}inner join Business_Type_Reference WITH(NOLOCK) on cbus_type = bustypref_type ";
					Query = $"{Query}WHERE bustypref_comp_id = {inCompanyID.ToString()} ";
					Query = $"{Query}AND cbus_abi_flag = 'N' AND bustypref_journ_id = 0  AND cbus_aircraft_flag = 'Y' ";

					Query = $"{Query}ORDER BY bustypref_seq_no";

					snp_CBT.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!(snp_CBT.BOF && snp_CBT.EOF))
					{

						while(!snp_CBT.EOF)
						{
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(snp_CBT["cbus_type"]))
							{
								cbo_Buyer.AddItem($"{Convert.ToString(snp_CBT["cbus_type"]).Trim()} - {Convert.ToString(snp_CBT["cbus_name"]).Trim()}");
							}
							snp_CBT.MoveNext();
						};
						cbo_Buyer.SelectedIndex = 0; // will fire on_click event
					}

					snp_CBT.Close();
					snp_CBT = null;

				}

				if (isAwaitingDocs)
				{
					int tempForEndVar = cbo_Buyer.Items.Count - 1;
					for (int I = 0; I <= tempForEndVar; I++)
					{
						if (cbo_Buyer.GetListItem(I).Trim() != "")
						{
							if (cbo_Buyer.GetListItem(I).Substring(0, Math.Min(2, cbo_Buyer.GetListItem(I).Length)).Trim().ToUpper() == "UI")
							{
								cbo_Buyer.SelectedIndex = I; // will fire on_click event
							}
						}
					}
				}
				else
				{
					// ok should default to the primary business type of the Buyer
					int tempForEndVar2 = cbo_Buyer.Items.Count - 1;
					for (int I = 0; I <= tempForEndVar2; I++)
					{
						if (cbo_Buyer.GetListItem(I).Trim() != "" && inComp_BusType.Trim() != "")
						{
							if (cbo_Buyer.GetListItem(I).Substring(0, Math.Min(2, cbo_Buyer.GetListItem(I).Length)).Trim().ToUpper() == inComp_BusType.ToUpper())
							{
								cbo_Buyer.SelectedIndex = I; // will fire on_click event
							}
						}
					}
				}

				if (cbo_Buyer.Items.Count == 0)
				{
					cbo_Buyer.SelectedIndex = -1; // should not fire on_click event
				}

				cbo_Buyer.Visible = true;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_cbo_Trans_Buyer_Error: {Information.Err().Number.ToString()} {excep.Message}");
				return;
			}

		}

		internal static void Fill_cbo_Trans_Seller(ComboBox cbo_Seller, int inCompanyID, string inAC_Business_Type)
		{


			try
			{

				string Query = "";
				ADORecordSetHelper snp_CBT = new ADORecordSetHelper();

				cbo_Seller.Visible = false;
				cbo_Seller.Items.Clear();
				// RTW - CHANGED TO BE AN INNER JOIN AND GET ONLY FIELDS NECESSARY
				// 1/27/2010
				Query = "SELECT cbus_type, cbus_name  FROM Company_Business_Type WITH(NOLOCK) ";
				Query = $"{Query}inner join Business_Type_Reference WITH(NOLOCK) on cbus_type = bustypref_type ";
				Query = $"{Query}WHERE bustypref_comp_id = {inCompanyID.ToString()} ";
				Query = $"{Query}AND cbus_abi_flag = 'N' AND bustypref_journ_id = 0 ";
				Query = $"{Query} and cbus_aircraft_flag = 'Y' ORDER BY bustypref_seq_no";

				snp_CBT.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_CBT.BOF && snp_CBT.EOF))
				{

					while(!snp_CBT.EOF)
					{

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snp_CBT["cbus_type"]))
						{
							cbo_Seller.AddItem($"{Convert.ToString(snp_CBT["cbus_type"]).Trim()} - {Convert.ToString(snp_CBT["cbus_name"]).Trim()}");
						}

						snp_CBT.MoveNext();
					};
					cbo_Seller.SelectedIndex = 0; // will fire on_click event
				}

				snp_CBT.Close();
				snp_CBT = null;

				int tempForEndVar = cbo_Seller.Items.Count - 1;
				for (int I = 0; I <= tempForEndVar; I++)
				{
					if (cbo_Seller.GetListItem(I).Trim() != "" && inAC_Business_Type.Trim() != "")
					{
						if (cbo_Seller.GetListItem(I).Substring(0, Math.Min(2, cbo_Seller.GetListItem(I).Length)).Trim().ToUpper() == inAC_Business_Type.ToUpper())
						{
							cbo_Seller.SelectedIndex = I; // will fire on_click event
						}
					}
				}

				if (cbo_Seller.Items.Count == 0)
				{
					cbo_Seller.SelectedIndex = -1; // should not fire on_click event
				}

				cbo_Seller.Visible = true;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_cbo_Trans_Seller_Error: {Information.Err().Number.ToString()} {excep.Message}");
				return;
			}

		}

		internal static void Display_Seller_Info(ListBox lst_Seller_to_fill, ComboBox cbo_Seller_to_fill, int COMPANY_ID, int CONTACT_ID, ref string Contact_Type, ref string Aircraft_Business_Type, ref string Company_Business_Type, ref string COMPANY_NAME)
		{
			//****************************************************************
			try
			{

				string Query = "";
				ADORecordSetHelper snpContact = new ADORecordSetHelper();
				ADORecordSetHelper snpReference = new ADORecordSetHelper();
				ADORecordSetHelper snpCompany = new ADORecordSetHelper();
				string M = "";

				lst_Seller_to_fill.Items.Clear();

				if (CONTACT_ID > 0)
				{
					Query = $"SELECT * FROM Contact WITH(NOLOCK) WHERE contact_id = {CONTACT_ID.ToString()}";

					snpContact.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!(snpContact.BOF && snpContact.EOF))
					{

						M = ($"{Convert.ToString(snpContact["contact_last_name"])}").Trim();

						if (Strings.Len(($"{Convert.ToString(snpContact["contact_first_name"])}").Trim()) > 0)
						{
							M = $"{M}, {($"{Convert.ToString(snpContact["contact_first_name"])}").Trim()}";
						}

						if (Strings.Len(($"{Convert.ToString(snpContact["contact_middle_initial"])}").Trim()) > 0)
						{
							M = $"{M} {($"{Convert.ToString(snpContact["contact_middle_initial"])}").Trim()}.";
						}

						lst_Seller_to_fill.AddItem(M);

					}

					snpContact.Close();

				}

				if (COMPANY_ID > 0)
				{
					//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
					// Retrieve seller company information from 'Company' table
					// Add to 'lst_Seller' list box
					//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
					Query = "SELECT comp_id, comp_name, comp_city, comp_state, comp_country, comp_business_type, cbus_name";
					Query = $"{Query} FROM Company WITH(NOLOCK), Company_Business_Type WITH(NOLOCK)";
					Query = $"{Query} WHERE comp_id = {COMPANY_ID.ToString()} AND comp_journ_id = 0";
					Query = $"{Query} AND cbus_type = comp_business_type";

					snpCompany.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!(snpCompany.BOF && snpCompany.EOF))
					{

						lst_Seller_to_fill.AddItem(($"{Convert.ToString(snpCompany["Comp_Name"])}").Trim());
						M = ($"{Convert.ToString(snpCompany["comp_city"])}").Trim();

						if (Strings.Len(($"{Convert.ToString(snpCompany["comp_state"])}").Trim()) > 0)
						{
							M = $"{M}, {($"{Convert.ToString(snpCompany["comp_state"])}").Trim()}";
						}

						if (Strings.Len(($"{Convert.ToString(snpCompany["comp_country"])}").Trim()) > 0)
						{
							M = $"{M}, {($"{Convert.ToString(snpCompany["comp_country"])}").Trim()}";
						}

						lst_Seller_to_fill.AddItem(M);
						lst_Seller_to_fill.AddItem(($"{Convert.ToString(snpCompany["cbus_name"])}").Trim());

						Company_Business_Type = ($"{Convert.ToString(snpCompany["comp_business_type"])}").Trim();
						COMPANY_NAME = ($"{Convert.ToString(snpCompany["Comp_Name"])}").Trim();

					}
					else
					{

						Company_Business_Type = "";
						COMPANY_NAME = "";

					}

					snpCompany.Close();

					if (COMPANY_ID > 0)
					{

						Query = $"SELECT cref_contact_type, cref_business_type FROM Aircraft_Reference WITH(NOLOCK) WHERE cref_ac_id = {modAdminCommon.gbl_Aircraft_ID.ToString()}";
						Query = $"{Query} AND cref_journ_id = 0 AND cref_comp_id = {COMPANY_ID.ToString()}";
						Query = $"{Query} AND cref_contact_id = {CONTACT_ID.ToString()}";

						snpReference.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

						if (!(snpReference.BOF && snpReference.EOF))
						{
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(snpReference["cref_contact_type"]))
							{
								Contact_Type = Convert.ToString(snpReference["cref_contact_type"]).Trim();
							}
							else
							{
								Contact_Type = "00";
							}

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(snpReference["cref_business_type"]))
							{
								Aircraft_Business_Type = Convert.ToString(snpReference["cref_business_type"]).Trim();
							}
							else
							{
								Aircraft_Business_Type = "";
							}

						}
						else
						{

							Contact_Type = "00";
							Aircraft_Business_Type = "";

						}

					}
					else
					{

						Contact_Type = "00";
						Aircraft_Business_Type = "";

					}

					snpReference.Close();

					modAircraftChange.Fill_cbo_Trans_Seller(cbo_Seller_to_fill, COMPANY_ID, Aircraft_Business_Type);

				}

				snpCompany = null;
				snpContact = null;
				snpReference = null;

				lst_Seller_to_fill.Refresh();
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Display_Seller_Info_Error: {Information.Err().Number.ToString()} {excep.Message}");

			}

		}

		internal static void Get_Seller(string inTrans_Type, int inMOD_Journal_ID, Panel pnl_to_show, ListBox lst_to_load, ComboBox cbo_to_fill, ref int COMPANY_ID, ref int CONTACT_ID, ref string Contact_Type, ref string Aircraft_Business_Type, ref string Company_Business_Type, ref string COMPANY_NAME)
		{


			try
			{

				string Query = "";
				ADORecordSetHelper snp_AR = new ADORecordSetHelper();
				COMPANY_ID = 0;
				CONTACT_ID = 0;

				Query = "SELECT cref_comp_id, cref_contact_id, cref_contact_type, cref_business_type FROM Aircraft_Reference WITH(NOLOCK), Company";
				Query = $"{Query} WHERE cref_ac_id = {modAdminCommon.gbl_Aircraft_ID.ToString()}";
				Query = $"{Query} AND cref_journ_id = {inMOD_Journal_ID.ToString()}";
				Query = $"{Query} AND comp_id = cref_comp_id";
				Query = $"{Query} AND comp_journ_id = {inMOD_Journal_ID.ToString()}";

				if (inTrans_Type == "DP")
				{
					Query = $"{Query} AND cref_contact_type IN ('42','36')";
				}
				else
				{
					Query = $"{Query} AND cref_contact_type IN ('00','08','17','50','55','56','62','97')";
				}

				Query = $"{Query} ORDER BY cref_contact_type";

				snp_AR.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_AR.BOF && snp_AR.EOF))
				{

					COMPANY_ID = Convert.ToInt32(snp_AR["cref_comp_id"]);

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snp_AR["cref_contact_id"]))
					{
						CONTACT_ID = Convert.ToInt32(snp_AR["cref_contact_id"]);
					}
					else
					{
						CONTACT_ID = 0;
					}

				}

				snp_AR.Close();
				snp_AR = null;

				if (COMPANY_ID == 0)
				{
					return;
				}

				pnl_to_show.Visible = true;

				modAircraftChange.Display_Seller_Info(lst_to_load, cbo_to_fill, COMPANY_ID, CONTACT_ID, ref Contact_Type, ref Aircraft_Business_Type, ref Company_Business_Type, ref COMPANY_NAME);

				pnl_to_show.Refresh();
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Get_Seller_Error: {Information.Err().Number.ToString()} {excep.Message}");
				return;
			}

		}

		internal static void Display_Registered_As_Info(ListBox lst_to_load, int COMPANY_ID, int CONTACT_ID)
		{
			try
			{

				string Query = "";
				ADORecordSetHelper snpContact = new ADORecordSetHelper(); //8/11/05 aey
				ADORecordSetHelper snpCompany = new ADORecordSetHelper(); //
				string M = "";
				lst_to_load.Items.Clear();

				if (CONTACT_ID > 0)
				{

					Query = $"SELECT * FROM Contact WITH(NOLOCK) WHERE contact_id = {CONTACT_ID.ToString()}";

					snpContact.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!(snpContact.BOF && snpContact.EOF))
					{

						M = ($"{Convert.ToString(snpContact["contact_last_name"])}").Trim();

						if (Strings.Len(($"{Convert.ToString(snpContact["contact_first_name"])}").Trim()) > 0)
						{
							M = $"{M}, {($"{Convert.ToString(snpContact["contact_first_name"])}").Trim()}";
						}

						if (Strings.Len(($"{Convert.ToString(snpContact["contact_middle_initial"])}").Trim()) > 0)
						{
							M = $"{M} {($"{Convert.ToString(snpContact["contact_middle_initial"])}").Trim()}.";
						}

						lst_to_load.AddItem(M);

					}

					snpContact.Close();
				}

				//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				// Retrieve seller company information from 'Company' table
				// Add to 'lst_Buyer' list box
				//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				if (COMPANY_ID > 0)
				{
					Query = "SELECT comp_name, comp_city, comp_state, comp_country, comp_business_type, cbus_name";
					Query = $"{Query} FROM Company WITH(NOLOCK), Company_Business_Type WITH(NOLOCK)";
					Query = $"{Query} WHERE comp_id = {COMPANY_ID.ToString()} AND comp_journ_id = 0";
					Query = $"{Query} AND cbus_type = comp_business_type";

					snpCompany.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!(snpCompany.BOF && snpCompany.EOF))
					{

						lst_to_load.AddItem(($"{Convert.ToString(snpCompany["Comp_Name"])}").Trim());
						M = ($"{Convert.ToString(snpCompany["comp_city"])}").Trim();

						if (Strings.Len(($"{Convert.ToString(snpCompany["comp_state"])}").Trim()) > 0)
						{
							M = $"{M}, {($"{Convert.ToString(snpCompany["comp_state"])}").Trim()}";
						}

						if (Strings.Len(($"{Convert.ToString(snpCompany["comp_country"])}").Trim()) > 0)
						{
							M = $"{M}, {($"{Convert.ToString(snpCompany["comp_country"])}").Trim()}";
						}

						lst_to_load.AddItem(M);
						lst_to_load.AddItem(($"{Convert.ToString(snpCompany["cbus_name"])}").Trim());

					}

					snpCompany.Close();

				}

				lst_to_load.Refresh();

				snpContact = null;
				snpCompany = null;
			}
			catch (System.Exception excep)
			{


				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Display_Registered_As_Info_Error: {Information.Err().Number.ToString()} {excep.Message}");

				return;
			}

		}
	}
}