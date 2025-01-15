using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Gui.Controls;
using UpgradeHelpers.Gui.Utils;
using UpgradeHelpers.Helpers;
using UpgradeStubs;

namespace JETNET_Homebase
{
	internal partial class frm_enter_sale_price_company
		: System.Windows.Forms.Form
	{

		public string From_Form = "";
		private bool bFormActivate = false;
		private bool bFormLoad = false;
		private int lFormWidth = 0;
		private int lFormHeight = 0;
		private bool gbReSizing = false;
		public int AC_ID = 0;
		public int journ_id = 0;
		public string trans_date = "";
		public int amod_ID = 0;
		public DbConnection REMOTE_ADO_DB = null;
		public frm_enter_sale_price_company()
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





		public void find_comp_now()
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

			try
			{

				cmd_find_now.Enabled = false;
				frame_search.Text = "Search";

				current_color = ColorTranslator.ToOle(Color.White).ToString();
				HiddenColor = (0xE0E0E0).ToString();

				//extract fields from yacht table
				grd_company_list.Visible = false;
				grd_company_list.Enabled = false;

				//Clear the grid.
				grd_company_list.Clear();

				//Set the number of columns and rows in the grid.
				grd_company_list.ColumnsCount = 8;
				grd_company_list.RowsCount = 2;

				//point to the first column and first row.
				grd_company_list.CurrentRowIndex = 0;

				grd_company_list.CurrentColumnIndex = 0;
				grd_company_list.SetColumnWidth(grd_company_list.CurrentColumnIndex, 53);
				grd_company_list.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_company_list[grd_company_list.CurrentRowIndex, grd_company_list.CurrentColumnIndex].Value = "CompId";

				grd_company_list.CurrentColumnIndex = 1;
				grd_company_list.SetColumnWidth(grd_company_list.CurrentColumnIndex, 167);
				grd_company_list.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_company_list[grd_company_list.CurrentRowIndex, grd_company_list.CurrentColumnIndex].Value = "Company Name";

				grd_company_list.CurrentColumnIndex = 2;
				grd_company_list.SetColumnWidth(grd_company_list.CurrentColumnIndex, 120);
				grd_company_list.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_company_list[grd_company_list.CurrentRowIndex, grd_company_list.CurrentColumnIndex].Value = "City";

				grd_company_list.CurrentColumnIndex = 3;
				grd_company_list.SetColumnWidth(grd_company_list.CurrentColumnIndex, 33);
				grd_company_list.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_company_list[grd_company_list.CurrentRowIndex, grd_company_list.CurrentColumnIndex].Value = "State";

				grd_company_list.CurrentColumnIndex = 4;
				grd_company_list.SetColumnWidth(grd_company_list.CurrentColumnIndex, 120);
				grd_company_list.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_company_list[grd_company_list.CurrentRowIndex, grd_company_list.CurrentColumnIndex].Value = "Coutry";

				grd_company_list.CurrentColumnIndex = 5;
				grd_company_list.SetColumnWidth(grd_company_list.CurrentColumnIndex, 167);
				grd_company_list.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_company_list[grd_company_list.CurrentRowIndex, grd_company_list.CurrentColumnIndex].Value = "Contact Name";


				grd_company_list.CurrentColumnIndex = 6;
				grd_company_list.SetColumnWidth(grd_company_list.CurrentColumnIndex, 100);
				grd_company_list.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_company_list[grd_company_list.CurrentRowIndex, grd_company_list.CurrentColumnIndex].Value = "ID";

				grd_company_list.CurrentColumnIndex = 7;
				grd_company_list.SetColumnWidth(grd_company_list.CurrentColumnIndex, 167);
				grd_company_list.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_company_list[grd_company_list.CurrentRowIndex, grd_company_list.CurrentColumnIndex].Value = "Address";

				strAddress = ($"{txtAddress.Text} ").Trim();

				strPhoneNbr = ($"{txtPhoneNbr.Text} ").Trim();
				strPhoneSearch = modCommon.LeaveOnlyNumeric(strPhoneNbr);

				Query = "SELECT DISTINCT comp_id, comp_name, comp_city, comp_state, comp_country, comp_address1, comp_address2, comp_active_flag ";


				Query = $"{Query}, dbo.CreateContactFullNameTitle('', CT1.contact_first_name, '', CT1.contact_last_name,  CT1.contact_suffix, '') As ContactName, contact_id ";

				if (strPhoneSearch != "")
				{
					Query = $"{Query}, (SELECT TOP 1 dbo.CreateContactFullNameTitle('', CT2.contact_first_name, '', CT2.contact_last_name, CT2.contact_suffix, '') ";
					Query = $"{Query}   FROM Contact AS CT2 WITH (NOLOCK) ";
					Query = $"{Query}   INNER JOIN Phone_Numbers AS PN2 WITH (NOLOCK) ON PN2.pnum_comp_id = CT2.contact_comp_id AND PN2.pnum_contact_id = CT2.contact_id AND PN2.pnum_journ_id = CT2.contact_journ_id ";
					Query = $"{Query}   WHERE (CT2.contact_comp_id = C1.comp_id) ";
					Query = $"{Query}   AND (CT2.contact_journ_id = C1.comp_journ_id) ";
					Query = $"{Query}   AND (PN2.pnum_contact_id > 0) ";
					Query = $"{Query}   AND (PN2.pnum_number_full_search LIKE '{strPhoneSearch}%') ";
					Query = $"{Query}   ORDER BY CT2.contact_acpros_seq_no ";
					Query = $"{Query}  ) As PhoneContact ";
				}
				else
				{
					Query = $"{Query}, '' As PhoneContact ";
				} //

				Query = $"{Query} FROM Company AS C1 WITH (NOLOCK) ";
				Query = $"{Query} LEFT OUTER JOIN Contact AS CT1 WITH (NOLOCK) ON CT1.contact_comp_id = comp_id AND CT1.contact_journ_id = comp_journ_id and contact_active_flag = 'Y'  ";

				Query = $"{Query}WHERE (comp_journ_id = 0) ";

				if (chk_inactive.CheckState != CheckState.Checked)
				{
					Query = $"{Query}AND (comp_active_flag = 'Y') ";
				}

				if (text_company_id.Text != "")
				{
					if (Information.IsNumeric(text_company_id.Text))
					{
						Query = $"{Query}AND (comp_id = {text_company_id.Text}) ";
					}
				}

				if (text_company_name.Text != "")
				{
					Query = $"{Query}AND (comp_name_search LIKE '{modCommon.Get_Name_Search_String(text_company_name.Text)}%') ";
				}

				if (text_city.Text != "")
				{
					Query = $"{Query}AND (comp_city LIKE '{StringsHelper.Replace(text_city.Text, "'", "''", 1, -1, CompareMethod.Binary)}%') ";
				}

				if (text_state.Text != "")
				{
					Query = $"{Query}AND (comp_state LIKE '{text_state.Text}%') ";
				}

				if (cbo_country.Text != "")
				{
					Query = $"{Query}AND (comp_country = '{StringsHelper.Replace(cbo_country.Text, "'", "''", 1, -1, CompareMethod.Binary)}') ";
				}

				if (txt_contact_first.Text != "")
				{
					Query = $"{Query}AND (CT1.contact_first_name LIKE '{StringsHelper.Replace(txt_contact_first.Text, "'", "''", 1, -1, CompareMethod.Binary)}%') ";
				}

				if (txt_contact_last.Text != "")
				{
					Query = $"{Query}AND (CT1.contact_last_name LIKE '{StringsHelper.Replace(txt_contact_last.Text, "'", "''", 1, -1, CompareMethod.Binary)}%') ";
				}

				if (strPhoneSearch != "")
				{

					if (strPhoneSearch != "")
					{
						Query = $"{Query}AND (EXISTS (SELECT NULL FROM Phone_Numbers WITH (NOLOCK) ";
						Query = $"{Query}             WHERE (pnum_comp_id = comp_id) ";
						Query = $"{Query}             AND (pnum_journ_id = comp_journ_id) ";
						Query = $"{Query}             AND (pnum_number_full_search LIKE '{strPhoneSearch}%') ";
						Query = $"{Query}            ) ";
						Query = $"{Query}    ) ";
					} // If strPhoneSearch <> "" Then

				} // If strPhoneSearch <> "" Then

				if (strAddress != "")
				{
					strAddressSearch = modCommon.LeaveOnlyAlphaAndNumeric(strAddress).ToUpper();
					if (strAddress.StartsWith("*", StringComparison.Ordinal))
					{
						strAddressSearch = $"%{strAddressSearch}";
					}
					Query = $"{Query}AND (";
					Query = $"{Query}       comp_address1_search LIKE '{strAddressSearch}%' ";
					Query = $"{Query}    OR comp_address2_search LIKE '{strAddressSearch}%' ";
					Query = $"{Query}    ) ";
				} // If strAddress <> "" Then

				Query = $"{Query}ORDER BY comp_name, comp_city, comp_state, comp_country ";
				if (txt_contact_first.Text != "" || txt_contact_last.Text != "")
				{
					Query = $"{Query}, ContactName ";
				}

				ado_company.CursorLocation = CursorLocationEnum.adUseClient;
				ado_company.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);

				if (!ado_company.BOF && !ado_company.EOF)
				{

					if (ado_company.RecordCount <= 1000)
					{

						lRow = 0;
						frame_search.Text = $"Search - Found {StringsHelper.Format(ado_company.RecordCount, "#,##0")} Record(s)";
						Application.DoEvents();
						strLastContact = "";

						do 
						{ // Loop Until ado_Company.EOF = True

							strCONTACTNAME = ($"{Convert.ToString(ado_company["ContactName"])} ").Trim();
							strPhoneContactName = ($"{Convert.ToString(ado_company["PhoneContact"])} ").Trim();

							if ((strPhoneContactName == "") || (strPhoneContactName != strLastContact))
							{

								lRow++;
								grd_company_list.RowsCount = lRow + 1;
								grd_company_list.CurrentRowIndex = lRow;

								grd_company_list.set_RowData(grd_company_list.CurrentRowIndex,Convert.ToInt32( ado_company.GetField("comp_id")));

								current_color = ColorTranslator.ToOle(Color.White).ToString();
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(ado_company["comp_active_flag"]))
								{
									if (Convert.ToString(ado_company["comp_active_flag"]).Trim() == "N")
									{
										current_color = (0xE0E0E0).ToString();
									}
								}

								grd_company_list.CurrentColumnIndex = 0;
								grd_company_list[grd_company_list.CurrentRowIndex, grd_company_list.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
								grd_company_list.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(current_color)));
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(ado_company["comp_id"]))
								{
									grd_company_list[grd_company_list.CurrentRowIndex, grd_company_list.CurrentColumnIndex].Value = Convert.ToString(ado_company["comp_id"]).Trim();
								}

								grd_company_list.CurrentColumnIndex = 1;
								grd_company_list[grd_company_list.CurrentRowIndex, grd_company_list.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
								grd_company_list.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(current_color)));
								grd_company_list.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(ado_company["comp_name"]))
								{
									grd_company_list[grd_company_list.CurrentRowIndex, grd_company_list.CurrentColumnIndex].Value = Convert.ToString(ado_company["comp_name"]).Trim();
								}

								grd_company_list.CurrentColumnIndex = 2;
								grd_company_list[grd_company_list.CurrentRowIndex, grd_company_list.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
								grd_company_list.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(current_color)));
								grd_company_list.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(ado_company["comp_city"]))
								{
									grd_company_list[grd_company_list.CurrentRowIndex, grd_company_list.CurrentColumnIndex].Value = Convert.ToString(ado_company["comp_city"]).Trim();
								}

								grd_company_list.CurrentColumnIndex = 3;
								grd_company_list[grd_company_list.CurrentRowIndex, grd_company_list.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
								grd_company_list.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(current_color)));
								grd_company_list.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(ado_company["comp_state"]))
								{
									grd_company_list[grd_company_list.CurrentRowIndex, grd_company_list.CurrentColumnIndex].Value = Convert.ToString(ado_company["comp_state"]).Trim();
								}

								grd_company_list.CurrentColumnIndex = 4;
								grd_company_list[grd_company_list.CurrentRowIndex, grd_company_list.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
								grd_company_list.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(current_color)));
								grd_company_list.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(ado_company["comp_country"]))
								{
									grd_company_list[grd_company_list.CurrentRowIndex, grd_company_list.CurrentColumnIndex].Value = Convert.ToString(ado_company["comp_country"]).Trim();
								}

								grd_company_list.CurrentColumnIndex = 5;
								grd_company_list[grd_company_list.CurrentRowIndex, grd_company_list.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
								grd_company_list.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(current_color)));
								grd_company_list.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

								grd_company_list[grd_company_list.CurrentRowIndex, grd_company_list.CurrentColumnIndex].Value = ($"{Convert.ToString(ado_company["ContactName"])} ").Trim();

								if (($"{Convert.ToString(ado_company["PhoneContact"])} ").Trim() != "")
								{
									grd_company_list[grd_company_list.CurrentRowIndex, grd_company_list.CurrentColumnIndex].Value = ($"{Convert.ToString(ado_company["PhoneContact"])} ").Trim();
								}

								strLastContact = grd_company_list[grd_company_list.CurrentRowIndex, grd_company_list.CurrentColumnIndex].FormattedValue.ToString();

								grd_company_list.CurrentColumnIndex = 6;
								grd_company_list.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(current_color)));
								grd_company_list.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
								grd_company_list[grd_company_list.CurrentRowIndex, grd_company_list.CurrentColumnIndex].Value = ($"{Convert.ToString(ado_company["contact_id"])} ").Trim();


								grd_company_list.CurrentColumnIndex = 7;
								grd_company_list.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(current_color)));
								grd_company_list.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
								grd_company_list[grd_company_list.CurrentRowIndex, grd_company_list.CurrentColumnIndex].Value = $"{($"{Convert.ToString(ado_company["comp_address1"])} ").Trim()} {($"{Convert.ToString(ado_company["Comp_address2"])} ").Trim()}";

							} // If (strPhoneContactName = "") Or (strPhoneContactName <> strLastContact) Then

							ado_company.MoveNext();
							Application.DoEvents();

						}
						while(!ado_company.EOF);

						grd_company_list.Visible = true;
						grd_company_list.Enabled = true;
						cmd_select_company.Visible = false;

					}
					else
					{
						MessageBox.Show("Search Results Exceed 1,000 Records. Too Large", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						grd_company_list.CurrentColumnIndex = 0;
						grd_company_list[grd_company_list.CurrentRowIndex, grd_company_list.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
						grd_company_list[grd_company_list.CurrentRowIndex, grd_company_list.CurrentColumnIndex].Value = "Search Results Too Large";
						grd_company_list.Visible = true;
						grd_company_list.Enabled = true;
						cmd_select_company.Visible = false;
					} // If ado_Company.RecordCount <= 1000 Then

				}
				else
				{
					grd_company_list.CurrentColumnIndex = 0;
					grd_company_list[grd_company_list.CurrentRowIndex, grd_company_list.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
					grd_company_list[grd_company_list.CurrentRowIndex, grd_company_list.CurrentColumnIndex].Value = "No Company Exists";
					grd_company_list.Visible = true;
					grd_company_list.Enabled = true;
					cmd_select_company.Visible = false;
				} // If ado_Company.BOF = False And ado_Company.EOF = False Then

				grd_company_list.FixedRows = 1;
				grd_company_list.FixedColumns = 0;

				frame_comp_details.Visible = false;

				ado_company.Close();
				ado_company = null;

				cmd_find_now.Enabled = true;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("cmd_find_now_Click_Error", excep.Message);
			}

		}

		public string Replace_bad(string temp_string)
		{

			temp_string = StringsHelper.Replace(temp_string, "'", "", 1, -1, CompareMethod.Binary);
			temp_string = StringsHelper.Replace(temp_string, ".", "", 1, -1, CompareMethod.Binary);
			temp_string = StringsHelper.Replace(temp_string, ",", "", 1, -1, CompareMethod.Binary);
			temp_string = StringsHelper.Replace(temp_string, " ", "", 1, -1, CompareMethod.Binary);
			temp_string = StringsHelper.Replace(temp_string, "&", "", 1, -1, CompareMethod.Binary);
			temp_string = StringsHelper.Replace(temp_string, ";", "", 1, -1, CompareMethod.Binary);

			return temp_string.ToLower();

		}

		private void cbo_country_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{
				if (KeyAscii == 13)
				{
					cmd_find_now_Click(cmd_find_now, new EventArgs());
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

		private void cmd_Clear_Click(Object eventSender, EventArgs eventArgs)
		{

			text_company_id.Text = "";
			text_company_name.Text = "";
			txtAddress.Text = "";
			text_city.Text = "";
			text_state.Text = "";
			cbo_country.Text = "";
			txt_contact_first.Text = "";
			txt_contact_last.Text = "";
			txtPhoneNbr.Text = "";
			cmd_select_company.Visible = false;

		}

		private void cmd_find_company_id_Click(Object eventSender, EventArgs eventArgs)
		{
			frm_company_search.Visible = true;
			frame_comp_details.Visible = false;

			if (txt_comp_id.Text.Trim() != "")
			{
				text_company_id.Text = txt_comp_id.Text.Trim();
				find_comp_now();
			}
		}

		private void cmd_find_now_Click(Object eventSender, EventArgs eventArgs) => find_comp_now();
		 // cmd_find_now_Click

		//UPGRADE_NOTE: (7001) The following declaration (Command1_Click) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void Command1_Click()
		//{
			//
		//}

		private void cmd_select_company_Click(Object eventSender, EventArgs eventArgs)
		{

			int contact_id = 0;

			frm_enter_sale_price_company.DefInstance.txt_comp_id.Text = grd_company_list.get_RowData(grd_company_list.RowSel).ToString();

			grd_company_list.CurrentColumnIndex = 5;
			frm_enter_sale_price_company.DefInstance.txt_contact_name.Text = grd_company_list[grd_company_list.CurrentRowIndex, grd_company_list.CurrentColumnIndex].FormattedValue.ToString();

			grd_company_list.CurrentColumnIndex = 6;
			contact_id = Convert.ToInt32(Double.Parse(grd_company_list[grd_company_list.CurrentRowIndex, grd_company_list.CurrentColumnIndex].FormattedValue.ToString()));

			lbl_sub_id.Text = find_company_contact_sub_id(Convert.ToInt32(Double.Parse(frm_enter_sale_price_company.DefInstance.txt_comp_id.Text)), contact_id);


			frm_company_search.Visible = false;

		}

		public string find_company_contact_sub_id(int COMPANY_ID, int contact_id)
		{

			ADORecordSetHelper snp_sub_lookup = new ADORecordSetHelper();
			string SQL = "";
			int sub_id = 0;

			try
			{

				//------------------- FiLL THE MOTOR TYPE DROP DOWN----------
				SQL = "select top 1 sub_id from Subscription with (NOLOCK) inner join Subscription_Install with (NOLOCK) on subins_sub_id = sub_id ";
				SQL = $"{SQL} Where sub_comp_id = {COMPANY_ID.ToString()} And subins_contact_id = {contact_id.ToString()} ";
				SQL = $"{SQL} order by subins_active_flag desc ";

				snp_sub_lookup.Open(SQL, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);

				if (!snp_sub_lookup.BOF && !snp_sub_lookup.EOF)
				{
					do 
					{

						sub_id = Convert.ToInt32(snp_sub_lookup["sub_id"]);

						snp_sub_lookup.MoveNext();

					}
					while(!snp_sub_lookup.EOF);

				} //

				snp_sub_lookup.Close();
				snp_sub_lookup = null;



				return sub_id.ToString();
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Yacht find_company_contact_sub_id_Error", excep.Message);
			}
			return "";
		} // fill_hull_material_drop_down


		private void cmd_select_company_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{

				if (KeyAscii == 13)
				{
					cmd_find_now_Click(cmd_find_now, new EventArgs());
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

		private void cmd_submit_record_Click(Object eventSender, EventArgs eventArgs)
		{

			try
			{

				if (txt_comp_id.Text != "")
				{
					if (txt_contact_name.Text != "")
					{

						if (modAdminCommon.LOCAL_ADO_DB.ConnectionString.IndexOf("jetnet_ra_test") >= 0)
						{
							MessageBox.Show("You are logged into Test, Sale Price Not Entered", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));

						}
						else
						{

							if (OpenRemoteDatabase())
							{
								insert_into_aircraft_value();
							}

							CloseRemoteDatabase();

						}

						InsertJournalNote_AC($"Displayable Sale Price Entered for {trans_date} Transaction", $"Price Entered: ${Double.Parse(StringsHelper.Replace(StringsHelper.Replace(txt_sale_price.Text, ",", "", 1, -1, CompareMethod.Binary), "$", "", 1, -1, CompareMethod.Binary), NumberStyles.Any).ToString("N0")}");


						frm_enter_sale_price_company.DefInstance.Hide();

					}
					else
					{
						MessageBox.Show("You need to Enter a Contact Name", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					}
				}
				else
				{
					MessageBox.Show("You need to Enter a Company ID", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"cmd_submit_record_Click_Error: {excep.Message}");
			}





		}

		private void InsertJournalNote_AC(string strSubject, string desc_text)
		{

			string strInsert1 = "";
			System.DateTime dtSystemDateTime = DateTime.FromOADate(0);

			try
			{

				if (strSubject != "")
				{

					dtSystemDateTime = DateTime.Parse(modAdminCommon.GetSystemDateTime());

					strInsert1 = "INSERT INTO Journal (";
					strInsert1 = $"{strInsert1}journ_date, journ_subcategory_code, ";
					strInsert1 = $"{strInsert1}journ_subject, journ_description, ";
					strInsert1 = $"{strInsert1}journ_ac_id,  journ_comp_id, ";
					strInsert1 = $"{strInsert1}journ_contact_id, journ_user_id, ";
					strInsert1 = $"{strInsert1}journ_entry_date, journ_entry_time, ";
					strInsert1 = $"{strInsert1}journ_account_id, journ_prior_account_id, ";
					strInsert1 = $"{strInsert1}journ_status,  journ_customer_note,  journ_action_date ";

					strInsert1 = $"{strInsert1}) VALUES ('{DateTime.Now.ToString("MM/dd/yyyy")}', ";
					strInsert1 = $"{strInsert1}'RN', ";
					strInsert1 = $"{strInsert1}'{($"{strSubject} ").Trim()}', ";
					strInsert1 = $"{strInsert1}'{desc_text.Trim()}', ";
					strInsert1 = $"{strInsert1}{AC_ID.ToString()}, ";
					strInsert1 = $"{strInsert1}0,0, ";
					strInsert1 = $"{strInsert1}'{modAdminCommon.gbl_User_ID}', ";
					strInsert1 = $"{strInsert1}'{dtSystemDateTime.ToString("MM/dd/yyyy")}', ";
					strInsert1 = $"{strInsert1}'{dtSystemDateTime.ToString("HH:mm:ss")}', ";
					strInsert1 = $"{strInsert1}'{modAdminCommon.gbl_Account_ID}', ";
					strInsert1 = $"{strInsert1}'', ";
					strInsert1 = $"{strInsert1}'A', ";
					strInsert1 = $"{strInsert1}'', ";
					strInsert1 = $"{strInsert1}'{DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}'";
					strInsert1 = $"{strInsert1})";

					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = strInsert1;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();

				} // If strSubject <> "" Then
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("InsertJournalNote_AC_Error: ", excep.Message);
			}

		} // InsertJournalNote


		public void CloseRemoteDatabase()
		{



			if (frm_Subscription.DefInstance.REMOTE_ADO_DB != null)
			{
				if (frm_Subscription.DefInstance.REMOTE_ADO_DB.State == ConnectionState.Open)
				{
					ErrorHandlingHelper.ResumeNext(
						() => {UpgradeHelpers.DB.TransactionManager.DeEnlist(frm_Subscription.DefInstance.REMOTE_ADO_DB);}, 
						() => {frm_Subscription.DefInstance.REMOTE_ADO_DB.Close();});
				}
			}
			frm_Subscription.DefInstance.REMOTE_ADO_DB = null;

			frm_Subscription.DefInstance.AlreadyOpen = false;
			 // frm_Subscription

		}


		public void insert_into_aircraft_value()
		{

			try
			{


				string SQL = "";
				SQL = "";
				SQL = $"{SQL} INSERT INTO Aircraft_Value (";
				SQL = $"{SQL} acval_type ,acval_entry_date ,acval_date ,acval_sub_id ,acval_login";
				SQL = $"{SQL},acval_seq_no ,acval_comp_id ,acval_contact_name";
				SQL = $"{SQL},acval_amod_id ,acval_ac_id ,acval_journ_id";
				SQL = $"{SQL},acval_airframe_tot_hrs ,acval_airframe_tot_landings";
				SQL = $"{SQL},acval_asking_price ,acval_take_price";
				SQL = $"{SQL},acval_est_price,acval_sale_price";
				SQL = $"{SQL},acval_webaction_date ,acval_notes ,acval_display_flag";
				SQL = $"{SQL} )  VALUES (";
				SQL = $"{SQL} 'SOLD'"; // acval_type  ' " & & "

				SQL = $"{SQL}, Getdate() ";

				SQL = $"{SQL},'{trans_date}'";

				// SQL = SQL & ",'" & lbl_sub_id.Caption & "' "   ' acval_sub_id
				// sub id
				SQL = $"{SQL},0";
				SQL = $"{SQL},'' "; // acval_login     ' CStr(Trim(HttpContext.Current.Session.Item("localUser").crmUserLogin))
				SQL = $"{SQL},'0' "; //acval_seq_no "      ' Trim(HttpContext.Current.Session.Item("localUser").crmSubSeqNo)

				SQL = $"{SQL},'{txt_comp_id.Text.Trim()}' ";
				SQL = $"{SQL},'{StringsHelper.Replace(txt_contact_name.Text.Trim(), "'", "", 1, -1, CompareMethod.Binary)}' "; // acval_contact_name "   '

				SQL = $"{SQL},{amod_ID.ToString()}"; // acval_amod_id "   ?  ?
				SQL = $"{SQL},{AC_ID.ToString()}";
				SQL = $"{SQL},{journ_id.ToString()}"; //acval_journ_id "   'aclsClient_Transactions.clitrans_jetnet_trans_id   ' aclsClient_Transactions.clitrans_id

				if (Information.IsNumeric(txt_aftt.Text))
				{
					SQL = $"{SQL}, {StringsHelper.Replace(txt_aftt.Text, ",", "", 1, -1, CompareMethod.Binary)} "; // aclsClient_Transactions.clitrans_airframe_total_hours
				}
				else
				{
					SQL = $"{SQL},0";
				}

				if (Information.IsNumeric(txt_total_landings.Text))
				{
					SQL = $"{SQL}, {StringsHelper.Replace(txt_total_landings.Text, ",", "", 1, -1, CompareMethod.Binary)} "; // aclsClient_Transactions.clitrans_airframe_total_landings
				}
				else
				{
					SQL = $"{SQL},0";
				}

				if (txt_asking_price.Text.Trim() == "")
				{
					SQL = $"{SQL},0 ";
				}
				else
				{
					SQL = $"{SQL},{StringsHelper.Replace(StringsHelper.Replace(txt_asking_price.Text, ",", "", 1, -1, CompareMethod.Binary), "$", "", 1, -1, CompareMethod.Binary)} ";
				}


				SQL = $"{SQL},0"; //acval_take_price
				SQL = $"{SQL},0"; // acval_est_price

				if (txt_sale_price.Text.Trim() == "")
				{
					SQL = $"{SQL},0 ";
				}
				else
				{
					SQL = $"{SQL},{StringsHelper.Replace(StringsHelper.Replace(txt_sale_price.Text, ",", "", 1, -1, CompareMethod.Binary), "$", "", 1, -1, CompareMethod.Binary)}"; // acval_sale_price
				}


				SQL = $"{SQL},'1/1/1900' ";
				SQL = $"{SQL},'{StringsHelper.Replace(txt_notes.Text, "'", "", 1, -1, CompareMethod.Binary)} (Entered By: {modAdminCommon.gbl_User_ID})' "; //description
				SQL = $"{SQL},'Y' ";
				SQL = $"{SQL})  ";

				DbCommand TempCommand = null;
				TempCommand = REMOTE_ADO_DB.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = SQL;
				TempCommand.CommandType = CommandType.Text;
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();

				MessageBox.Show("Your Value Record Has Been Inserted", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK);
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"insert_into_aircraft_value_Error: {excep.Message}");
			}
		}
		public bool OpenRemoteDatabase()
		{

			bool result = false;
			try
			{

				bool bResults = false;
				string IP_Address = "";
				string DB_Name = "";
				string DB_User_ID = "";
				string DB_Password = "";
				string strConnect = "";
				int iErrCnt = 0; // Try 3 Times Before Stopping

				bResults = false;


				if (!frm_Subscription.DefInstance.AlreadyOpen)
				{

					DB_Name = "jetnet_ra";

					// 04/23/2008 - By David D. Cruger;
					// These are now all Application Configuration Items
					IP_Address = modCommon.DLookUp("aconfig_evo_sql_server", "Application_Configuration");
					DB_User_ID = modCommon.DLookUp("aconfig_evo_sql_user", "Application_Configuration");
					DB_Password = modCommon.DLookUp("aconfig_evo_sql_password", "Application_Configuration");

					strConnect = $"Provider=SQLNCLI10;" +
					             $"Data Source={IP_Address};" +
					             $"Initial Catalog={DB_Name};" +
					             $"User Id={DB_User_ID};" +
					             $"Password={DB_Password};";

					REMOTE_ADO_DB = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateConnection();

					//UPGRADE_ISSUE: (2070) Constant adModeShareDenyNone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2070
					//UPGRADE_ISSUE: (2064) ADODB.Connection property REMOTE_ADO_DB.Mode was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					REMOTE_ADO_DB.setMode(UpgradeStubs.System_Data_CommandType.getadModeShareDenyNone());
					//UPGRADE_ISSUE: (2064) ADODB.Connection property REMOTE_ADO_DB.ConnectionTimeout was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					REMOTE_ADO_DB.setConnectionTimeout(30); // Seconds

					iErrCnt = 0;
					bResults = false;

					Exception ex = null;
					//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
					do 
					{
						ErrorHandlingHelper.ResumeNext(out ex, 
							() => {iErrCnt++;}, 
								//UPGRADE_TODO: (7010) The connection string must be verified to fullfill the .NET data provider connection string requirements. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-7010
							() => {REMOTE_ADO_DB.ConnectionString = strConnect;}, 
							() => {REMOTE_ADO_DB.Open();});
					}
					while(!ErrorHandlingHelper.ResumeNextExpr<bool>(() => Information.Err().Number == 0 || iErrCnt >= 3));
					ErrorHandlingHelper.ResumeNext(out ex);

					if (ex == null)
					{
						try
						{
							UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(REMOTE_ADO_DB, 120);
						}
						catch
						{
						}
						bResults = true;
						frm_Subscription.DefInstance.AlreadyOpen = true;
					}
					else
					{
						try
						{
							throw new Exception();
						}
						catch
						{
						}
					}

				}
				else
				{
					bResults = true;
				} // If .AlreadyOpen = False Then
				 // frm_Subscription


				return bResults;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"OpenRemoteDatabase_Error: {excep.Message}");

				result = false;
			}
			return result;
		} // OpenRemoteDatabase


		private void Form_Activated(Object eventSender, EventArgs eventArgs)
		{
			if (ActivateHelper.myActiveForm != eventSender)
			{
				ActivateHelper.myActiveForm = (Form) eventSender;

				bFormActivate = true;
				lbl_sub_id.Text = "";
				this.WindowState = FormWindowState.Normal;
				frame_comp_details.Visible = false;
				//UPGRADE_WARNING: (2065) Form method frm_enter_sale_price_company.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
				this.BringToFront();

			}
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
		private void Form_Load()
		{

			bFormActivate = false;
			bFormLoad = false;
			gbReSizing = false;

			lFormWidth = this.Width * 15;
			lFormHeight = this.Height * 15;

			modCommon.CenterFormOnHomebaseMainForm(this);

			modFillCompConControls.fill_country_FromArray(cbo_country);

			bFormLoad = true;

		} // Form_Load


		private void Display_Aircraft_Info()
		{

			ADORecordSetHelper snp_AircraftInfo = new ADORecordSetHelper(); //aey 7/1/04 convert to ado
			string temp_subject = "";

			lst_aircraft_info.Items.Clear();


			string Query = "Select amod_make_name,amod_model_name,ac_ser_no_full,ac_year,amod_id, journ_subject ";
			Query = $"{Query} from Aircraft WITH(NOLOCK) ";
			Query = $"{Query} inner join Aircraft_Model WITH(NOLOCK) on amod_id = ac_amod_id ";
			Query = $"{Query} inner join journal WITH(NOLOCK) on journ_id = ac_journ_id ";
			Query = $"{Query} where ac_id = {AC_ID.ToString()}";
			Query = $"{Query} and ac_journ_id = {journ_id.ToString()}";


			snp_AircraftInfo.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

			if (!(snp_AircraftInfo.BOF && snp_AircraftInfo.EOF))
			{
				lst_aircraft_info.AddItem($"MAKE/MODEL: {($"{Convert.ToString(snp_AircraftInfo["amod_make_name"])} ").Trim()}/{($"{Convert.ToString(snp_AircraftInfo["amod_model_name"])} ").Trim()}");
				lst_aircraft_info.AddItem($"SERIAL#: {($"{Convert.ToString(snp_AircraftInfo["ac_ser_no_full"])} ").Trim()}");
				lst_aircraft_info.AddItem($"YEAR: {($"{Convert.ToString(snp_AircraftInfo["ac_year"])} ").Trim()}");

				lst_aircraft_info.AddItem($"DATE: {trans_date.Trim()} ");

				temp_subject = ($"{Convert.ToString(snp_AircraftInfo["journ_subject"])} ").Trim();

				if (temp_subject.Trim() != "")
				{
					lst_aircraft_info.AddItem($"SUBJECT: {temp_subject.Substring(0, Math.Min(33, temp_subject.Length))}");
					if (Strings.Len(temp_subject.Trim()) > 33)
					{
						lst_aircraft_info.AddItem(temp_subject.Substring(Math.Max(temp_subject.Length - (Strings.Len(temp_subject.Trim()) - 33), 0)));
					}
				}

			}

			snp_AircraftInfo.Close();


		} // Display_Aircraft_Info


		private void Add_Company_Business_Types(int lCompId, int lJournId, ListBox lstBox)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			try
			{

				if (lCompId > 0)
				{

					strQuery1 = "SELECT bustypref_type, cbus_name ";
					strQuery1 = $"{strQuery1}FROM Business_Type_Reference WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1}INNER JOIN Company_Business_Type WITH (NOLOCK) ON cbus_type = bustypref_type ";
					strQuery1 = $"{strQuery1}WHERE (bustypref_comp_id = {lCompId.ToString()}) ";
					strQuery1 = $"{strQuery1}AND (bustypref_journ_id = {lJournId.ToString()}) ";
					strQuery1 = $"{strQuery1}ORDER BY bustypref_seq_no ";

					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					lstBox.AddItem("");
					lstBox.AddItem("Business Type(s)");

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						do 
						{ // Loop Until rstRec1.EOF = True

							lstBox.AddItem($"{($"{Convert.ToString(rstRec1["bustypref_type"])} ").Trim()} - {($"{Convert.ToString(rstRec1["cbus_name"])} ").Trim()}");
							rstRec1.MoveNext();

						}
						while(!rstRec1.EOF);

					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

				} // If lCompId > 0 Then

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Add_Company_Business_Types_Error", excep.Message);
			}

		} // Add_Company_Business_Types

		private bool isInitializingComponent;
		private void Form_Resize(Object eventSender, EventArgs eventArgs)
		{
			if (isInitializingComponent)
			{
				return;
			}


			if (((int) this.WindowState) != ((int) FormWindowState.Minimized) && ((int) this.WindowState) != ((int) FormWindowState.Maximized) && ((int) this.WindowState) != ((int) ProcessWindowStyle.Minimized))
			{

				if (!gbReSizing)
				{

					gbReSizing = true;

					if (this.Width * 15 < lFormWidth)
					{
						this.Width = lFormWidth / 15; // Can NOT Be Smaller Than This
					}
					grd_company_list.Width = this.Width - 21;

					this.Height = lFormHeight / 15; // This Value Can Not Change

					gbReSizing = false;

				} // If gbReSizing = False Then

			} // If .WindowState <> vbNormalFocus And .WindowState <> vbMinimizedFocus And .WindowState <> vbMinimizedNoFocus Then
			 // Me

			Display_Aircraft_Info();

		}

		//UPGRADE_NOTE: (7001) The following declaration (Frame1_DragDrop) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void Frame1_DragDrop(Control Source, float X, float Y)
		//{
			//
		//}

		private void grd_company_list_Click(Object eventSender, EventArgs eventArgs)
		{


			int lRow = grd_company_list.CurrentRowIndex;

			int lCompId = grd_company_list.get_RowData(grd_company_list.RowSel);
			int lJournId = 0;

			modCommon.Build_Company_NameAddress(company_details_list, lCompId, lJournId);

			// 03/17/2015 - By David D. Cruger
			// Added Business Types Per Tasker
			Add_Company_Business_Types(lCompId, lJournId, company_details_list);

			modCommon.Highlight_Grid_Row(grd_company_list);

			grd_company_list.CurrentColumnIndex = 5;
			txt_contact_name.Text = grd_company_list[grd_company_list.CurrentRowIndex, grd_company_list.CurrentColumnIndex].FormattedValue.ToString();

			txt_comp_id.Text = lCompId.ToString();
			cmd_select_company.Visible = true;
			frame_comp_details.Visible = true;
			cmd_submit_record.Visible = true;

		} // grd_company_list_Click

		//UPGRADE_NOTE: (7001) The following declaration (SSPanel1_Click) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void SSPanel1_Click()
		//{
			//
		//}

		private void text_city_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{
				if (KeyAscii == 13)
				{
					cmd_find_now_Click(cmd_find_now, new EventArgs());
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

		private void text_company_id_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{
				if (KeyAscii == 13)
				{
					cmd_find_now_Click(cmd_find_now, new EventArgs());
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

		private void text_company_name_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{
				if (KeyAscii == 13)
				{
					cmd_find_now_Click(cmd_find_now, new EventArgs());
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

		private void text_state_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{
				if (KeyAscii == 13)
				{
					cmd_find_now_Click(cmd_find_now, new EventArgs());
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

		private void txt_comp_id_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{

				if (KeyAscii == 13)
				{
					cmd_find_company_id_Click(cmd_find_company_id, new EventArgs());
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

		private void txt_contact_first_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{
				if (KeyAscii == 13)
				{
					cmd_find_now_Click(cmd_find_now, new EventArgs());
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

		private void txt_contact_last_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{
				if (KeyAscii == 13)
				{
					cmd_find_now_Click(cmd_find_now, new EventArgs());
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

		private void Form_KeyUp(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{

				System.DateTime dtStart = DateTime.FromOADate(0);
				int lElapsed = 0;

				if (KeyCode == ((int) Keys.Return))
				{

					dtStart = DateTime.Now;
					do 
					{
						lElapsed = (int) DateAndTime.DateDiff("s", dtStart, DateTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
					}
					while(!((bFormLoad && bFormActivate) || lElapsed >= 10));
					cmd_find_now_Click(cmd_find_now, new EventArgs());

				} // If (KeyCode = vbKeyReturn) Then
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}

		} // Form_KeyUp

		private void txtAddress_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{
				if (KeyAscii == 13)
				{
					cmd_find_now_Click(cmd_find_now, new EventArgs());
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


		private void txtPhoneNbr_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{
				if (KeyAscii == 13)
				{
					cmd_find_now_Click(cmd_find_now, new EventArgs());
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
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}