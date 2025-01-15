using Microsoft.VisualBasic;
using System;
using System.Data.Common;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Gui.Controls;
using UpgradeHelpers.Helpers;

namespace JETNET_Homebase
{
	internal partial class frm_Missing_Solds
		: System.Windows.Forms.Form
	{

		public frm_Missing_Solds()
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


		private void frm_Missing_Solds_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		public string sold_model_ids = "";
		public string sold_model_ids_original = "";
		public string direction_of = "";
		public int Main_Comp_ID = 0;


		private void cmd_export_list_Click(Object eventSender, EventArgs eventArgs)
		{

			cmd_export_list.Enabled = false;
			modExcel.ExportMSHFlexGrid(grd_sale_prices);
			cmd_export_list.Enabled = true;

		}

		private void cmd_Refresh_Click(Object eventSender, EventArgs eventArgs)
		{

			if (cbo_amod_make_name.Text.Trim() != "")
			{
				sold_model_ids = cbo_amod_make_name.GetItemData(cbo_amod_make_name.SelectedIndex).ToString();
			}
			else if (sold_model_ids_original.Trim() != "")
			{ 
				sold_model_ids = sold_model_ids_original;
			}
			else
			{
				sold_model_ids = "";
			}

			create_missing_sales();

		}

		public void Fill_Aircraft_Make_List(string AirframeType = "")
		{
			ADORecordSetHelper snpAircraftMakeList = new ADORecordSetHelper(); //aey 6/10/04

			string strQuery = "SELECT * FROM Aircraft_Model WITH(NOLOCK)";

			if (AirframeType.Trim() != "")
			{ //aey 7/26/05
				strQuery = $"{strQuery} WHERE amod_airframe_type_code = '{AirframeType.Trim()}'";
			}

			strQuery = $"{strQuery} ORDER BY amod_make_name, amod_model_name";

			snpAircraftMakeList.Open(strQuery, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

			if (!(snpAircraftMakeList.BOF && snpAircraftMakeList.EOF))
			{
				cbo_amod_make_name.Items.Clear();
				cbo_amod_make_name.AddItem(("").Trim());
				cbo_amod_make_name.SetItemData(cbo_amod_make_name.Items.Count - 1, 0);


				while(!snpAircraftMakeList.EOF)
				{
					cbo_amod_make_name.AddItem(($"{Convert.ToString(snpAircraftMakeList["amod_make_name"]).Trim()} / {Convert.ToString(snpAircraftMakeList["amod_model_name"]).Trim()}").Trim());
					cbo_amod_make_name.SetItemData(cbo_amod_make_name.Items.Count - 1, Convert.ToInt32(snpAircraftMakeList["amod_id"]));
					snpAircraftMakeList.MoveNext();
				};

			}

			snpAircraftMakeList.Close();

		}

		private void create_missing_sales()
		{
			System.Windows.Forms.Button cmd_select_company = frm_enter_sale_price_company.DefInstance.cmd_select_company;


			string Query = modGlobalVars.cEmptyString;
			ADORecordSetHelper ado_company = new ADORecordSetHelper();
			string cellcolor = modGlobalVars.cEmptyString;
			string HiddenColor = "";
			string current_color = "";
			int lRow = 0;
			string strAddress = "";
			string strAddressSearch = "";
			string strPhoneNbr = "";
			string strPhoneSearch = "";
			string strLastContact = "";
			string strCONTACTNAME = "";
			string strPhoneContactName = "";

			try
			{


				current_color = ColorTranslator.ToOle(Color.White).ToString();
				HiddenColor = (0xE0E0E0).ToString();

				//extract fields from yacht table
				grd_sale_prices.Visible = false;
				grd_sale_prices.Enabled = false;

				//Clear the grid.
				grd_sale_prices.Clear();

				//Set the number of columns and rows in the grid.

				grd_sale_prices.ColumnsCount = 10;
				grd_sale_prices.RowsCount = 2;

				//point to the first column and first row.
				grd_sale_prices.CurrentRowIndex = 0;

				grd_sale_prices.CurrentColumnIndex = 0;
				grd_sale_prices.SetColumnWidth(grd_sale_prices.CurrentColumnIndex, 153);
				grd_sale_prices.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = "Make/Model";

				grd_sale_prices.CurrentColumnIndex = 1;
				grd_sale_prices.SetColumnWidth(grd_sale_prices.CurrentColumnIndex, 77);
				grd_sale_prices.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = "Ser No";


				grd_sale_prices.CurrentColumnIndex = 2;
				grd_sale_prices.SetColumnWidth(grd_sale_prices.CurrentColumnIndex, 57);
				grd_sale_prices.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = "Reg No";


				grd_sale_prices.CurrentColumnIndex = 3;
				grd_sale_prices.SetColumnWidth(grd_sale_prices.CurrentColumnIndex, 70);
				grd_sale_prices.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = "Journ Date";

				grd_sale_prices.CurrentColumnIndex = 4;
				grd_sale_prices.SetColumnWidth(grd_sale_prices.CurrentColumnIndex, 333);
				grd_sale_prices.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = "Journ Subject";

				grd_sale_prices.CurrentColumnIndex = 5;
				grd_sale_prices.SetColumnWidth(grd_sale_prices.CurrentColumnIndex, 60);
				grd_sale_prices.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = "Journ ID";

				grd_sale_prices.CurrentColumnIndex = 6;
				grd_sale_prices.SetColumnWidth(grd_sale_prices.CurrentColumnIndex, 0);
				grd_sale_prices.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = "ACID";


				grd_sale_prices.CurrentColumnIndex = 7;
				grd_sale_prices.SetColumnWidth(grd_sale_prices.CurrentColumnIndex, 73);
				grd_sale_prices.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = "Asking Price";


				grd_sale_prices.CurrentColumnIndex = 8;
				grd_sale_prices.SetColumnWidth(grd_sale_prices.CurrentColumnIndex, 67);
				grd_sale_prices.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = "Sale Price";

				grd_sale_prices.CurrentColumnIndex = 9;
				if (chk_sold_prices.CheckState == CheckState.Checked)
				{
					grd_sale_prices.SetColumnWidth(grd_sale_prices.CurrentColumnIndex, 33);
				}
				else
				{
					grd_sale_prices.SetColumnWidth(grd_sale_prices.CurrentColumnIndex, 0);
				}
				grd_sale_prices.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = "Disp?";




				Query = " select distinct journ_date, ac_id, amod_id, amod_make_name, amod_model_name, ac_journ_id, ac_ser_no_full, ac_reg_no,";
				Query = $"{Query} ac_asking, ac_asking_price, ac_sale_price,  ac_sale_price_display_flag,";
				Query = $"{Query} journ_subject , journ_description, journ_id ";

				Query = $"{Query} from  Aircraft with (NOLOCK)  inner join Aircraft_Model with (NOLOCK) on ac_amod_id = amod_id";
				Query = $"{Query} inner join Journal with (NOLOCK) on ac_journ_id = journ_id";


				Query = $"{Query} where journ_subcat_code_part1='WS' and journ_internal_trans_flag='N'  and journ_subcategory_code not like '%CORR'  ";


				if (cbo_year.Text.Trim() != "")
				{
					if ((sold_model_ids.IndexOf(',') + 1) == 0 && sold_model_ids.Trim() != "")
					{
						frame_Missing_Solds.Text = "Retail Transactions with Missing Sold Prices - Last 3 Years";
						Query = $"{Query} and journ_date >= '1/1/{cbo_year.Text.Trim()}' and journ_date <= '12/31/{cbo_year.Text.Trim()}' ";
						Query = $"{Query} and amod_id in ({sold_model_ids})";
					}
					else
					{
						frame_Missing_Solds.Text = "Retail Transactions with Missing Sold Prices - Last 90 Days";
						Query = $"{Query} and journ_date >= '1/1/{cbo_year.Text.Trim()}' and journ_date <= '12/31/{cbo_year.Text.Trim()}' ";
						if (sold_model_ids.Trim() != "")
						{
							Query = $"{Query} and amod_id in ({sold_model_ids})";
						}
					}
				}
				else
				{
					if ((sold_model_ids.IndexOf(',') + 1) == 0 && sold_model_ids.Trim() != "")
					{
						frame_Missing_Solds.Text = "Retail Transactions with Missing Sold Prices - Last 3 Years";
						Query = $"{Query} and journ_date >= GETDATE() -1095";
						Query = $"{Query} and amod_id in ({sold_model_ids})";
					}
					else
					{
						frame_Missing_Solds.Text = "Retail Transactions with Missing Sold Prices - Last 90 Days";
						Query = $"{Query} and journ_date >= GETDATE() -90";
						if (sold_model_ids.Trim() != "")
						{
							Query = $"{Query} and amod_id in ({sold_model_ids})";
						}
					}
				}


				if (chk_sold_prices.CheckState == CheckState.Checked)
				{
					Query = $"{Query} and (ac_sale_price <> 0) ";
					cmd_export_list.Visible = false;
				}
				else
				{
					Query = $"{Query} and ((ac_sale_price = 0 or ac_sale_price is null) or (ac_sale_price_display_flag = 'N' and ac_sale_price > 0))";
					cmd_export_list.Visible = true;
				}


				Query = $"{Query} and journ_subcat_code_part3 NOT IN ('DB','DS','FI','FY','IT','MF','RE','CC','LS', 'RM')";



				switch(grd_sale_prices.MouseRow)
				{
					case 0 : 
						 
						switch(grd_sale_prices.MouseCol)
						{
							case 0 : 
								Query = $"{Query} order by amod_make_name {direction_of}, amod_model_name, journ_date desc "; 
								break;
							case 1 : 
								Query = $"{Query} order by ac_ser_no_full {direction_of}, amod_make_name, amod_model_name, journ_date desc "; 
								break;
							case 2 : 
								Query = $"{Query} order by ac_reg_no {direction_of}, amod_make_name, amod_model_name, journ_date desc "; 
								break;
							case 3 : 
								Query = $"{Query} order by journ_date {direction_of}, amod_make_name, amod_model_name desc "; 
								break;
							case 4 : 
								Query = $"{Query} order by journ_subject {direction_of}, amod_make_name, amod_model_name, journ_date desc "; 
								break;
							case 5 : 
								Query = $"{Query} order by journ_id {direction_of}, amod_make_name, amod_model_name, journ_date desc "; 
								break;
							case 6 : 
								Query = $"{Query} order by ac_id {direction_of}, amod_make_name, amod_model_name, journ_date desc "; 
								break;
							case 7 : 
								Query = $"{Query} order by ac_asking_price {direction_of}, amod_make_name, amod_model_name, journ_date desc "; 
								break;
							case 8 : 
								Query = $"{Query} order by ac_sale_price {direction_of}, amod_make_name, amod_model_name, journ_date desc "; 
								break;
							case 9 : 
								Query = $"{Query} order by ac_sale_price_display_flag {direction_of}, amod_make_name, amod_model_name, journ_date desc "; 
								break;
							default:
								Query = $"{Query} order by amod_make_name {direction_of}, amod_model_name, journ_date desc "; 
								 
								break;
						} 
						break;
					default:
						Query = $"{Query} order by amod_make_name, amod_model_name, journ_date desc "; 
						break;
				}





				ado_company.CursorLocation = CursorLocationEnum.adUseClient;
				ado_company.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);


				if (!ado_company.BOF && !ado_company.EOF)
				{

					if (ado_company.RecordCount <= 15000)
					{

						lbl_class[2].Text = $"{ado_company.RecordCount.ToString()}";
						lRow = 0;
						//frame_search.Caption = "Search - Found " & Format(ado_Company.RecordCount, "#,##0") & " Record(s)"
						Application.DoEvents();
						strLastContact = "";

						do 
						{ // Loop Until ado_Company.EOF = True

							Application.DoEvents();

							if (chk_sold_prices.CheckState == CheckState.Checked)
							{
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(ado_company["ac_sale_price_display_flag"]))
								{
									if (Convert.ToString(ado_company["ac_sale_price_display_flag"]).Trim() == "Y")
									{
										current_color = ColorTranslator.ToOle(Color.White).ToString();
									}
									else
									{
										current_color = (0xE0E0E0).ToString();
									}
								}
								else
								{
									current_color = ColorTranslator.ToOle(Color.White).ToString();
								}
							}
							else
							{
								current_color = ColorTranslator.ToOle(Color.White).ToString();
							}


							grd_sale_prices.CurrentRowIndex++;
							grd_sale_prices.CurrentColumnIndex = 0;
							grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
							grd_sale_prices.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(current_color)));
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(ado_company["amod_make_name"]))
							{
								grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = $"{Convert.ToString(ado_company["amod_make_name"]).Trim()} {Convert.ToString(ado_company["amod_model_name"]).Trim()}";
							}

							grd_sale_prices.CurrentColumnIndex = 1;
							grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
							grd_sale_prices.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(current_color)));
							grd_sale_prices.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(ado_company["ac_ser_no_full"]))
							{
								grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = Convert.ToString(ado_company["ac_ser_no_full"]).Trim();
							}


							grd_sale_prices.CurrentColumnIndex = 2;
							grd_sale_prices.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(current_color)));
							grd_sale_prices.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(ado_company["ac_reg_no"]))
							{
								grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = Convert.ToString(ado_company["ac_reg_no"]).Trim();
							}

							grd_sale_prices.CurrentColumnIndex = 3;
							grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
							grd_sale_prices.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(current_color)));
							grd_sale_prices.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(ado_company["journ_date"]))
							{
								grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = Convert.ToString(ado_company["journ_date"]).Trim();
							}

							grd_sale_prices.CurrentColumnIndex = 4;
							grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
							grd_sale_prices.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(current_color)));
							grd_sale_prices.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(ado_company["journ_subject"]))
							{
								grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = Convert.ToString(ado_company["journ_subject"]).Trim();
							}

							grd_sale_prices.CurrentColumnIndex = 5;
							grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
							grd_sale_prices.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(current_color)));
							grd_sale_prices.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(ado_company["journ_id"]))
							{
								grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = Convert.ToString(ado_company["journ_id"]).Trim();
							}


							grd_sale_prices.CurrentColumnIndex = 6;
							grd_sale_prices.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(current_color)));
							grd_sale_prices.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
							grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = ($"{Convert.ToString(ado_company["AC_ID"])} ").Trim();



							grd_sale_prices.CurrentColumnIndex = 7;
							grd_sale_prices.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(current_color)));
							grd_sale_prices.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(ado_company["ac_asking_price"]))
							{
								grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = Double.Parse(Convert.ToString(ado_company["ac_asking_price"]), NumberStyles.Any).ToString("N0").Trim();
							}

							if (chk_sold_prices.CheckState == CheckState.Checked)
							{
								grd_sale_prices.CurrentColumnIndex = 8;
								grd_sale_prices.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(current_color)));
								grd_sale_prices.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(ado_company["ac_sale_price"]))
								{
									grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = Double.Parse(Convert.ToString(ado_company["ac_sale_price"]), NumberStyles.Any).ToString("N0").Trim();
								}

								grd_sale_prices.CurrentColumnIndex = 9;
								grd_sale_prices.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(current_color)));
								grd_sale_prices.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(ado_company["ac_sale_price_display_flag"]))
								{
									grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = Convert.ToString(ado_company["ac_sale_price_display_flag"]).Trim();
								}
							}
							else
							{
								grd_sale_prices.CurrentColumnIndex = 8;
								grd_sale_prices.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(current_color)));
								grd_sale_prices.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

								grd_sale_prices.CurrentColumnIndex = 9;
								grd_sale_prices.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(current_color)));
								grd_sale_prices.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
							}


							grd_sale_prices.set_RowData(grd_sale_prices.CurrentRowIndex, Convert.ToInt32(ado_company["journ_id"].ToString().Trim()));
							grd_sale_prices.RowsCount++;

							Application.DoEvents();

							ado_company.MoveNext();
							Application.DoEvents();

						}
						while(!ado_company.EOF);

						grd_sale_prices.RowsCount--;


					}
					else
					{
						MessageBox.Show("Search Results Exceed 5,000 Records. Too Large", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						grd_sale_prices.CurrentColumnIndex = 0;
						grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
						grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = "Search Results Too Large";
						grd_sale_prices.Visible = true;
						grd_sale_prices.Enabled = true;
						//UPGRADE_TODO: (1067) Member Visible is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						cmd_select_company.Visible = false;
					} // If ado_Company.RecordCount <= 1000 Then
				}

				Application.DoEvents();

				grd_sale_prices.FixedRows = 1;
				grd_sale_prices.FixedColumns = 0;
				grd_sale_prices.Visible = true;
				grd_sale_prices.Enabled = true;

				Application.DoEvents();
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("create_missing_sales_Error", excep.Message);
			}

		} // cmd_find_now_Click
		private void create_submitted_sales()
		{


			string Query = modGlobalVars.cEmptyString;
			ADORecordSetHelper ado_company = new ADORecordSetHelper();
			string cellcolor = modGlobalVars.cEmptyString;
			string HiddenColor = "";
			string current_color = "";
			int lRow = 0;
			string strAddress = "";
			string strAddressSearch = "";
			string strPhoneNbr = "";
			string strPhoneSearch = "";
			string strLastContact = "";
			string strCONTACTNAME = "";
			string strPhoneContactName = "";
			string temp_field = "";
			int tcol = 0;

			try
			{


				current_color = ColorTranslator.ToOle(Color.White).ToString();
				HiddenColor = (0xE0E0E0).ToString();

				//extract fields from yacht table
				grd_prices_sum.Visible = false;
				grd_prices_sum.Enabled = false;

				//Clear the grid.
				grd_prices_sum.Clear();

				//Set the number of columns and rows in the grid.

				grd_prices_sum.ColumnsCount = 6;
				grd_prices_sum.RowsCount = 2;

				//point to the first column and first row.
				grd_prices_sum.CurrentRowIndex = 0;

				tcol = 0;
				grd_prices_sum.CurrentColumnIndex = 0;
				grd_prices_sum.SetColumnWidth(grd_prices_sum.CurrentColumnIndex, 133);
				grd_prices_sum.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_prices_sum[grd_prices_sum.CurrentRowIndex, grd_prices_sum.CurrentColumnIndex].Value = "Company Name";

				tcol++;
				grd_prices_sum.CurrentColumnIndex = tcol;
				grd_prices_sum.SetColumnWidth(grd_prices_sum.CurrentColumnIndex, 45);
				grd_prices_sum.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_prices_sum[grd_prices_sum.CurrentRowIndex, grd_prices_sum.CurrentColumnIndex].Value = "YEAR";


				tcol++;
				grd_prices_sum.CurrentColumnIndex = tcol;


				grd_prices_sum.SetColumnWidth(grd_prices_sum.CurrentColumnIndex, 45);

				grd_prices_sum.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_prices_sum[grd_prices_sum.CurrentRowIndex, grd_prices_sum.CurrentColumnIndex].Value = "MONTH";


				tcol++;
				grd_prices_sum.CurrentColumnIndex = tcol;
				grd_prices_sum.SetColumnWidth(grd_prices_sum.CurrentColumnIndex, 45);
				grd_prices_sum.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_prices_sum[grd_prices_sum.CurrentRowIndex, grd_prices_sum.CurrentColumnIndex].Value = "PRICES";

				tcol++;
				grd_prices_sum.CurrentColumnIndex = tcol;
				grd_prices_sum.SetColumnWidth(grd_prices_sum.CurrentColumnIndex, 40);
				grd_prices_sum.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_prices_sum[grd_prices_sum.CurrentRowIndex, grd_prices_sum.CurrentColumnIndex].Value = "ESTIM";

				tcol++;
				grd_prices_sum.CurrentColumnIndex = tcol;
				grd_prices_sum.SetColumnWidth(grd_prices_sum.CurrentColumnIndex, 40);
				grd_prices_sum.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_prices_sum[grd_prices_sum.CurrentRowIndex, grd_prices_sum.CurrentColumnIndex].Value = "NDisp";


				if (frm_company_summary.Text == "Submitted Sale Price Summary By Trans Date")
				{
					temp_field = "journ_date";
				}
				else
				{
					temp_field = "acval_entry_date";
				}




				Query = "";

				if (frm_company_summary.Text == "Submitted Sale Price Summary By Trans Date")
				{
					Query = $"{Query} select DISTINCT comp_name AS COMPNAME, comp_id as COMPID, year(acval_date) as CALYEAR , month(acval_date) as CALMONTH, ";
					Query = $"{Query} (select COUNT(distinct a2.acval_journ_id) ";
					Query = $"{Query} from Aircraft_Value a2 with (NOLOCK) where Year(a2.acval_date) = Year(av1.acval_date) And Month(a2.acval_date) = Month(av1.acval_date) ";
					Query = $"{Query} and a2.acval_type='SOLD' and a2.acval_comp_id = comp_id) as PRICES,";
					Query = $"{Query}  (select COUNT(distinct a2.acval_ac_id) ";
					Query = $"{Query} from Aircraft_Value a2 with (NOLOCK) where Year(a2.acval_date) = Year(av1.acval_date) And Month(a2.acval_date) = Month(av1.acval_date) ";
					Query = $"{Query} and a2.acval_type='ESTIMATED PRICE' and a2.acval_comp_id = comp_id) as ESTIMATES,";
					Query = $"{Query} (select COUNT(distinct journ_ac_id) ";
					Query = $"{Query} from Journal with (NOLOCK) where Year(journ_date) = Year(av1.acval_date) And Month(journ_date) = Month(av1.acval_date) ";
					Query = $"{Query} and journ_comp_id = comp_id  and (journ_subject like 'Sale Price Entered for%' or journ_subject like 'Sale Price Changed for%')) as NDPRICES";
				}
				else
				{
					Query = $"{Query} select DISTINCT comp_name AS COMPNAME, comp_id as COMPID, year(acval_entry_date) as CALYEAR , month(acval_entry_date) as CALMONTH, ";
					Query = $"{Query} (select COUNT(distinct a2.acval_journ_id) ";
					Query = $"{Query} from Aircraft_Value a2 with (NOLOCK) where Year(a2.acval_entry_date) = Year(av1.acval_entry_date) And Month(a2.acval_entry_date) = Month(av1.acval_entry_date) ";
					Query = $"{Query} and a2.acval_type='SOLD' and a2.acval_comp_id = comp_id) as PRICES,";
					Query = $"{Query}  (select COUNT(distinct a2.acval_ac_id) ";
					Query = $"{Query} from Aircraft_Value a2 with (NOLOCK) where Year(a2.acval_entry_date) = Year(av1.acval_entry_date) And Month(a2.acval_entry_date) = Month(av1.acval_entry_date) ";
					Query = $"{Query} and a2.acval_type='ESTIMATED PRICE' and a2.acval_comp_id = comp_id) as ESTIMATES,";
					Query = $"{Query} (select COUNT(distinct journ_ac_id) ";
					Query = $"{Query} from Journal with (NOLOCK) where Year(journ_date) = Year(av1.acval_entry_date) And Month(journ_date) = Month(av1.acval_entry_date) ";
					Query = $"{Query} and journ_comp_id = comp_id  and (journ_subject like 'Sale Price Entered for%' or journ_subject like 'Sale Price Changed for%')) as NDPRICES";
				}


				Query = $"{Query} from Aircraft_Value av1 with (NOLOCK)  inner join Company with (NOLOCK) on acval_comp_id = comp_id and comp_journ_id = 0";
				Query = $"{Query} inner join Journal with (NOLOCK) on journ_id = acval_journ_id and journ_ac_id = acval_ac_id";
				Query = $"{Query} inner join Aircraft  with (NOLOCK) on acval_journ_id = ac_journ_id and ac_id = acval_ac_id";
				Query = $"{Query} inner join Aircraft_Model with (NOLOCK) on amod_id = ac_amod_id";

				Query = $"{Query} where acval_type in ('SOLD','ESTIMATED PRICE')  and comp_id in ({Main_Comp_ID.ToString()}) ";

				if (frm_company_summary.Text == "Submitted Sale Price Summary By Trans Date")
				{
					Query = $"{Query}  group by  comp_name, comp_id, year(acval_date), month(acval_date)  ";
					Query = $"{Query}  order by year(acval_date) desc, month(acval_date) desc";
				}
				else
				{
					Query = $"{Query}  group by  comp_name, comp_id, year(acval_entry_date), month(acval_entry_date)  ";
					Query = $"{Query}   order by year(acval_entry_date) desc, month(acval_entry_date) desc";
				}



				ado_company.CursorLocation = CursorLocationEnum.adUseClient;
				ado_company.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);

				lbl_class[2].Text = "0";

				if (!ado_company.BOF && !ado_company.EOF)
				{


					lbl_class[2].Text = $"{ado_company.RecordCount.ToString()}";
					lRow = 0;
					//frame_search.Caption = "Search - Found " & Format(ado_Company.RecordCount, "#,##0") & " Record(s)"
					Application.DoEvents();
					strLastContact = "";

					do 
					{ // Loop Until ado_Company.EOF = True

						Application.DoEvents();

						if (chk_sold_prices.CheckState == CheckState.Checked)
						{
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(ado_company["ac_sale_price_display_flag"]))
							{
								if (Convert.ToString(ado_company["ac_sale_price_display_flag"]).Trim() == "Y")
								{
									current_color = ColorTranslator.ToOle(Color.White).ToString();
								}
								else
								{
									current_color = (0xE0E0E0).ToString();
								}
							}
							else
							{
								current_color = ColorTranslator.ToOle(Color.White).ToString();
							}
						}

						tcol = 0;
						grd_prices_sum.CurrentRowIndex++;
						grd_prices_sum.CurrentColumnIndex = 0;
						grd_prices_sum[grd_prices_sum.CurrentRowIndex, grd_prices_sum.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
						grd_prices_sum.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(current_color)));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_company["COMPNAME"]))
						{
							grd_prices_sum[grd_prices_sum.CurrentRowIndex, grd_prices_sum.CurrentColumnIndex].Value = Convert.ToString(ado_company["COMPNAME"]).Trim();
						}

						tcol++;
						grd_prices_sum.CurrentColumnIndex = 1;
						grd_prices_sum[grd_prices_sum.CurrentRowIndex, grd_prices_sum.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
						grd_prices_sum.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(current_color)));
						grd_prices_sum.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_company["CALYEAR"]))
						{
							grd_prices_sum[grd_prices_sum.CurrentRowIndex, grd_prices_sum.CurrentColumnIndex].Value = Convert.ToString(ado_company["CALYEAR"]).Trim();
						}

						tcol++;
						grd_prices_sum.CurrentColumnIndex = tcol;
						grd_prices_sum.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(current_color)));
						grd_prices_sum.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_company["CALMONTH"]))
						{
							grd_prices_sum[grd_prices_sum.CurrentRowIndex, grd_prices_sum.CurrentColumnIndex].Value = Convert.ToString(ado_company["CALMONTH"]).Trim();
						}



						tcol++;
						grd_prices_sum.CurrentColumnIndex = tcol;
						grd_prices_sum.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(current_color)));
						grd_prices_sum.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_company["PRICES"]))
						{
							grd_prices_sum[grd_prices_sum.CurrentRowIndex, grd_prices_sum.CurrentColumnIndex].Value = Convert.ToString(ado_company["PRICES"]).Trim();
						}

						tcol++;
						grd_prices_sum.CurrentColumnIndex = tcol;
						grd_prices_sum.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(current_color)));
						grd_prices_sum.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_company["ESTIMATES"]))
						{
							grd_prices_sum[grd_prices_sum.CurrentRowIndex, grd_prices_sum.CurrentColumnIndex].Value = Convert.ToString(ado_company["ESTIMATES"]).Trim();
						}


						tcol++;
						grd_prices_sum.CurrentColumnIndex = tcol;
						grd_prices_sum.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(current_color)));
						grd_prices_sum.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_company["NDPRICES"]))
						{
							grd_prices_sum[grd_prices_sum.CurrentRowIndex, grd_prices_sum.CurrentColumnIndex].Value = Convert.ToString(ado_company["NDPRICES"]).Trim();
						}

						// grd_prices_sum.RowData(grd_prices_sum.Row) = Trim(ado_company!journ_id & " ")
						grd_prices_sum.RowsCount++;

						Application.DoEvents();

						ado_company.MoveNext();
						Application.DoEvents();

					}
					while(!ado_company.EOF);

					grd_prices_sum.RowsCount--;


				}

				Application.DoEvents();

				ado_company.Close();
				if (lbl_class[2].Text == "0")
				{
					cmd_switch.Visible = false;
					frm_company_summary.Text = "Submitted Sale Price Summary By Date Submitted - Non Displayable Prices";
				}


				Query = "";
				Query = $"{Query} select Year(journ_date) as tyear, Month(journ_date) as tmonth, COUNT(distinct journ_ac_id) as tcount ";
				Query = $"{Query} from Journal with (NOLOCK) where ";
				//Year(journ_date) = Year(av1.acval_date) And Month(journ_date) = Month(av1.acval_date) and "
				Query = $"{Query} journ_comp_id = {Main_Comp_ID.ToString()}  and (journ_subject like 'Sale Price Entered for%' or journ_subject like 'Sale Price Changed for%')";
				Query = $"{Query} group by Year(journ_date), Month(journ_date)";

				ado_company.CursorLocation = CursorLocationEnum.adUseClient;
				ado_company.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);


				if (!ado_company.BOF && !ado_company.EOF)
				{
					grd_prices_sum.RowsCount++;
					do 
					{ // Loop Until ado_Company.EOF = True

						grd_prices_sum.CurrentRowIndex++;
						grd_prices_sum.CurrentColumnIndex = 0;
						grd_prices_sum[grd_prices_sum.CurrentRowIndex, grd_prices_sum.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
						grd_prices_sum.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(current_color)));
						grd_prices_sum[grd_prices_sum.CurrentRowIndex, grd_prices_sum.CurrentColumnIndex].Value = "Other NDisp Values";

						grd_prices_sum.CurrentColumnIndex = 1;
						grd_prices_sum[grd_prices_sum.CurrentRowIndex, grd_prices_sum.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
						grd_prices_sum.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(current_color)));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_company["tyear"]))
						{
							grd_prices_sum[grd_prices_sum.CurrentRowIndex, grd_prices_sum.CurrentColumnIndex].Value = Convert.ToString(ado_company["tyear"]).Trim();
						}

						grd_prices_sum.CurrentColumnIndex = 2;
						grd_prices_sum[grd_prices_sum.CurrentRowIndex, grd_prices_sum.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
						grd_prices_sum.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(current_color)));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_company["tmonth"]))
						{
							grd_prices_sum[grd_prices_sum.CurrentRowIndex, grd_prices_sum.CurrentColumnIndex].Value = Convert.ToString(ado_company["tmonth"]).Trim();
						}


						for (int i = 3; i <= 4; i++)
						{
							grd_prices_sum.CurrentColumnIndex = i;
							grd_prices_sum[grd_prices_sum.CurrentRowIndex, grd_prices_sum.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
							grd_prices_sum.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(current_color)));
						}

						grd_prices_sum.CurrentColumnIndex = 5;
						grd_prices_sum[grd_prices_sum.CurrentRowIndex, grd_prices_sum.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
						grd_prices_sum.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(current_color)));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_company["tcount"]))
						{
							grd_prices_sum[grd_prices_sum.CurrentRowIndex, grd_prices_sum.CurrentColumnIndex].Value = Convert.ToString(ado_company["tcount"]).Trim();
						}

						grd_prices_sum.RowsCount++;

						ado_company.MoveNext();
						Application.DoEvents();

					}
					while(!ado_company.EOF);

					grd_prices_sum.RowsCount--;

				}




				grd_prices_sum.FixedRows = 1;
				grd_prices_sum.FixedColumns = 0;
				grd_prices_sum.Visible = true;
				grd_prices_sum.Enabled = true;

				Application.DoEvents();
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("create_submitted_sales_Error", excep.Message);
			}

		} // cmd_find_now_Click


		//UPGRADE_NOTE: (7001) The following declaration (Command1_Click) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void Command1_Click()
		//{
			//
		//}

		private void cmd_switch_Click(Object eventSender, EventArgs eventArgs)
		{


			if (frm_company_summary.Text == "Submitted Sale Price Summary By Trans Date")
			{
				frm_company_summary.Text = "Submitted Sale Price Summary By Date Submitted";
				cmd_switch.Text = "Switch To View By Trans Date";
			}
			else
			{
				frm_company_summary.Text = "Submitted Sale Price Summary By Trans Date";
				cmd_switch.Text = "Switch To View By Date Submitted";
			}


			create_submitted_sales();


		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
		private void Form_Load()
		{

			if (Main_Comp_ID > 0)
			{
				create_submitted_sales();
			}

			sold_model_ids_original = sold_model_ids;
			create_missing_sales();
			Fill_Aircraft_Make_List();

			cbo_year.AddItem("");
			cbo_year.AddItem(DateTime.Today.Year.ToString());
			cbo_year.AddItem((DateTime.Today.Year - 1).ToString());
			cbo_year.AddItem((DateTime.Today.Year - 2).ToString());
			cbo_year.AddItem((DateTime.Today.Year - 3).ToString());
			cbo_year.AddItem((DateTime.Today.Year - 4).ToString());
			cbo_year.AddItem((DateTime.Today.Year - 5).ToString());


		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs) => sold_model_ids = "";



		private void grd_sale_prices_Click(Object eventSender, EventArgs eventArgs)
		{

			if (direction_of.Trim() == "" || direction_of.Trim() == "desc")
			{
				direction_of = " asc ";
			}
			else
			{
				direction_of = " desc ";
			}


			switch(grd_sale_prices.MouseRow)
			{
				case 0 : 
					create_missing_sales(); 
					break;
			}


		}

		private void grd_sale_prices_DoubleClick(Object eventSender, EventArgs eventArgs)
		{


			grd_sale_prices.CurrentColumnIndex = 7;
			if (grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].FormattedValue.ToString().Trim() == "")
			{
				frm_enter_sale_price_company.DefInstance.txt_asking_price.Text = "0";
			}
			else
			{
				frm_enter_sale_price_company.DefInstance.txt_asking_price.Text = grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].FormattedValue.ToString();
			}

			grd_sale_prices.CurrentColumnIndex = 8;
			if (grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].FormattedValue.ToString().Trim() == "")
			{
				frm_enter_sale_price_company.DefInstance.txt_sale_price.Text = "0";
			}
			else
			{
				frm_enter_sale_price_company.DefInstance.txt_sale_price.Text = grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].FormattedValue.ToString();
			}

			grd_sale_prices.CurrentColumnIndex = 6;
			frm_enter_sale_price_company.DefInstance.AC_ID = Convert.ToInt32(Double.Parse(grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].FormattedValue.ToString()));

			grd_sale_prices.CurrentColumnIndex = 5;
			frm_enter_sale_price_company.DefInstance.journ_id = Convert.ToInt32(Double.Parse(grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].FormattedValue.ToString()));

			frm_enter_sale_price_company.DefInstance.amod_ID = 272;


			grd_sale_prices.CurrentColumnIndex = 2;
			frm_enter_sale_price_company.DefInstance.trans_date = grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].FormattedValue.ToString();

			frm_enter_sale_price_company.DefInstance.ShowDialog();


		}
	}
}