using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Gui.Controls;
using UpgradeHelpers.Helpers;

namespace HomebaseAdministrator
{
	internal partial class frm_CommonLookup
		: System.Windows.Forms.Form
	{

		public frm_CommonLookup()
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


		private void frm_CommonLookup_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}



		private bool Is_Dirty = false;

		private string RecordStat = "";
		public int action_id = 0;

		public object create_class_page()
		{




			ADORecordSetHelper ado_FieldList = new ADORecordSetHelper();
			string temp_model_string = "";
			string temp_name = "";
			string temp_ac_string = "";
			string days = "";
			string days_fs = "";
			int I = 0;
			int record_count = 0;
			int temp_length = 0;

			if (cbo_days[0].Items.Count == 0)
			{
				for (I = 0; I <= 365; I++)
				{
					cbo_days[0].AddItem(I.ToString());
					cbo_days[1].AddItem(I.ToString());
				}
			}
			I = 0;



			string SQL = " select aclass_code, aclass_name , aclass_common_verify_days, aclass_sale_verify_days, ";
			SQL = $"{SQL} (select count(*) from Aircraft_Model with (NOLOCK) where amod_class_code = aclass_code) as Model_Count,";
			SQL = $"{SQL} (select count(distinct ac_id) from Aircraft with (NOLOCK) inner join aircraft_model with (NOLOCK) on amod_id = ac_amod_id and  amod_class_code = aclass_code where ac_journ_id = 0 ) as AC_Count ";
			SQL = $"{SQL} from Aircraft_Class ";


			ado_FieldList.Open(SQL, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

			lst_class.Items.Clear();
			while (!ado_FieldList.EOF)
			{

				temp_model_string = Double.Parse(Convert.ToString(ado_FieldList["Model_Count"]), NumberStyles.Any).ToString("N0");
				temp_length = Strings.Len(temp_model_string.Trim());
				temp_length = (11 - temp_length);
				int tempForEndVar2 = temp_length;
				for (I = 0; I <= tempForEndVar2; I++)
				{
					temp_model_string = $"{Strings.Chr(160).ToString()}{temp_model_string.Trim()}";
				}

				temp_ac_string = Double.Parse(Convert.ToString(ado_FieldList["ac_count"]), NumberStyles.Any).ToString("N0");
				temp_length = Strings.Len(temp_ac_string.Trim());
				temp_length = (11 - temp_length);
				int tempForEndVar3 = temp_length;
				for (I = 0; I <= tempForEndVar3; I++)
				{
					temp_ac_string = $"{Strings.Chr(160).ToString()}{temp_ac_string.Trim()}";
				}

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(ado_FieldList["aclass_name"]))
				{
					temp_name = Convert.ToString(ado_FieldList["aclass_name"]);
				}
				else
				{
					temp_name = "";
				}
				temp_length = Strings.Len(temp_name.Trim());
				temp_length = (16 - temp_length);
				int tempForEndVar4 = temp_length;
				for (I = 0; I <= tempForEndVar4; I++)
				{
					temp_name = $"{Strings.Chr(160).ToString()}{temp_name.Trim()}";
				}

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(ado_FieldList["aclass_common_verify_days"]))
				{
					days = Convert.ToString(ado_FieldList["aclass_common_verify_days"]);
				}
				else
				{
					days = "";
				}
				temp_length = Strings.Len(days.Trim());
				temp_length = (10 - temp_length);
				int tempForEndVar5 = temp_length;
				for (I = 0; I <= tempForEndVar5; I++)
				{
					days = $"{Strings.Chr(160).ToString()}{days.Trim()}";
				}

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(ado_FieldList["aclass_sale_verify_days"]))
				{
					days_fs = Convert.ToString(ado_FieldList["aclass_sale_verify_days"]);
				}
				else
				{
					days_fs = "";
				}
				temp_length = Strings.Len(days_fs.Trim());
				temp_length = (15 - temp_length);
				int tempForEndVar6 = temp_length;
				for (I = 0; I <= tempForEndVar6; I++)
				{
					days_fs = $"{Strings.Chr(160).ToString()}{days_fs.Trim()}";
				}




				lst_class.AddItem($"{($"{Convert.ToString(ado_FieldList["aclass_code"])}").Trim()}{Strings.Chr(160).ToString()}{Strings.Chr(160).ToString()} {temp_name.Trim()} {days.Trim()} {days_fs.Trim()} {temp_model_string.Trim()} {temp_ac_string.Trim()} ");
				lst_class.SetItemData(lst_class.Items.Count - 1, 0);
				record_count++;


				ado_FieldList.MoveNext();
			}

			lbl_apu[2].Text = $"Total Class Records: {record_count.ToString()}";




			return null;
		}

		public void Fill_grd_Subscriptions(string serv_code)
		{

			ADORecordSetHelper snp_SUB = new ADORecordSetHelper();
			ADORecordSetHelper snp_C = new ADORecordSetHelper();
			StringBuilder M = new StringBuilder();

			string Query = $"SELECT * FROM Subscription WHERE sub_serv_code = '{serv_code}'  ORDER BY sub_id ";

			snp_SUB.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

			if (!(snp_SUB.BOF && snp_SUB.EOF))
			{
				grd_Subscriptions.Visible = true;
				lbl_Subscriptions.Visible = true;
				grd_Subscriptions.RowsCount = 1;
				grd_Subscriptions.ColumnsCount = 5;
				grd_Subscriptions.CurrentRowIndex = 0;
				grd_Subscriptions.CurrentColumnIndex = 0;
				grd_Subscriptions.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_Subscriptions.SetColumnWidth(0, 40);
				grd_Subscriptions[grd_Subscriptions.CurrentRowIndex, grd_Subscriptions.CurrentColumnIndex].Value = "Sub ID";
				grd_Subscriptions.CurrentColumnIndex = 1;
				grd_Subscriptions.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_Subscriptions.SetColumnWidth(1, 60);
				grd_Subscriptions[grd_Subscriptions.CurrentRowIndex, grd_Subscriptions.CurrentColumnIndex].Value = "Contact ID";
				grd_Subscriptions.CurrentColumnIndex = 2;
				grd_Subscriptions.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_Subscriptions.SetColumnWidth(2, 220);
				grd_Subscriptions[grd_Subscriptions.CurrentRowIndex, grd_Subscriptions.CurrentColumnIndex].Value = "Contact";
				grd_Subscriptions.CurrentColumnIndex = 3;
				grd_Subscriptions.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_Subscriptions.SetColumnWidth(3, 67);
				grd_Subscriptions[grd_Subscriptions.CurrentRowIndex, grd_Subscriptions.CurrentColumnIndex].Value = "Start Date";
				grd_Subscriptions.CurrentColumnIndex = 4;
				grd_Subscriptions.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_Subscriptions.SetColumnWidth(4, 67);
				grd_Subscriptions[grd_Subscriptions.CurrentRowIndex, grd_Subscriptions.CurrentColumnIndex].Value = "End Date";

				while(!snp_SUB.EOF)
				{
					grd_Subscriptions.RowsCount++;
					grd_Subscriptions.CurrentRowIndex++;
					grd_Subscriptions.CurrentColumnIndex = 0;
					grd_Subscriptions[grd_Subscriptions.CurrentRowIndex, grd_Subscriptions.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_SUB["sub_id"])}").Trim();
					grd_Subscriptions.CurrentColumnIndex = 1;
					grd_Subscriptions[grd_Subscriptions.CurrentRowIndex, grd_Subscriptions.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_SUB["sub_contact_id"])}").Trim();
					grd_Subscriptions.CurrentColumnIndex = 2;

					if (Strings.Len(($"{Convert.ToString(snp_SUB["sub_contact_id"])} ").Trim()) > 0)
					{

						Query = $"SELECT *  FROM Contact WHERE contact_id = {($"{Convert.ToString(snp_SUB["sub_contact_id"])}").Trim()} ";

						snp_C.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

						if (!(snp_C.BOF && snp_C.EOF))
						{
							M = new StringBuilder($"{($"{Convert.ToString(snp_C["contact_last_name"])}").Trim()}, ");
							M.Append(($"{Convert.ToString(snp_C["contact_first_name"])}").Trim());
							grd_Subscriptions[grd_Subscriptions.CurrentRowIndex, grd_Subscriptions.CurrentColumnIndex].Value = M.ToString();
						}
						else
						{
							grd_Subscriptions[grd_Subscriptions.CurrentRowIndex, grd_Subscriptions.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_SUB["sub_contact_id"])}").Trim();
						}
						snp_C.Close();
					}

					grd_Subscriptions.CurrentColumnIndex = 3;
					grd_Subscriptions[grd_Subscriptions.CurrentRowIndex, grd_Subscriptions.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_SUB["sub_start_date"])}").Trim();
					grd_Subscriptions.CurrentColumnIndex = 4;
					grd_Subscriptions[grd_Subscriptions.CurrentRowIndex, grd_Subscriptions.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_SUB["sub_end_date"])}").Trim();
					snp_SUB.MoveNext();
				};
				grd_Subscriptions.FixedRows = 1;
				grd_Subscriptions.FixedColumns = 0;
			}
			else
			{
				grd_Subscriptions.Visible = false;
				lbl_Subscriptions.Visible = false;
			}

		}

		public object move_sort(string direction)
		{
			string SQL = "";
			int temp_id = 0;
			int sort_num1 = 0;
			int temp_id2 = 0;
			int sort_num2 = 0;
			int temper = 0;
			string first_main = "";
			string first_sub = "";
			ADORecordSetHelper ado_FieldList = new ADORecordSetHelper(); //Current recordset

			action_id = 0;


			string temp_display = Convert.ToDouble(list_CustomFields.GetItemData(ListBoxHelper.GetSelectedIndex(list_CustomFields))).ToString();

			if (temp_display.Trim() != "")
			{
				temp_id = Convert.ToInt32(Double.Parse(temp_display));
			}
			else
			{
				temp_id = 0;
			}

			if (Convert.ToDouble(temp_id) > 0)
			{

				SQL = "SELECT cef_sort, cefstab_main_name, cefstab_sub_name ";
				SQL = $"{SQL}from Custom_Export_Fields left outer join Custom_Export_Tab on cef_export_tab_id = cefstab_id ";
				SQL = $"{SQL}left outer join Custom_Export_Block on cef_export_block_id = cefsblk_id ";
				SQL = $"{SQL}where cef_evo_flag='Y' and cef_id= {temp_id.ToString()} ";

				ado_FieldList.Open(SQL, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

				while (!ado_FieldList.EOF)
				{

					sort_num1 = Convert.ToInt32(ado_FieldList["cef_sort"]);
					first_main = Convert.ToString(ado_FieldList["cefstab_main_name"]);
					first_sub = Convert.ToString(ado_FieldList["cefstab_sub_name"]);

					ado_FieldList.MoveNext();
				}


				ado_FieldList.Close();
				ado_FieldList = null;


				if (direction == "lower")
				{
					temper = sort_num1 - 1;
				}
				else
				{
					temper = sort_num1 + 1;
				}


				SQL = "SELECT top 1 cef_id, cef_sort  from Custom_Export_Fields left outer join Custom_Export_Tab on cef_export_tab_id = cefstab_id ";
				SQL = $"{SQL}left outer join Custom_Export_Block on cef_export_block_id = cefsblk_id ";
				SQL = $"{SQL}where cef_evo_flag='Y' and cef_sort = {temper.ToString()} ";
				SQL = $"{SQL} and cefstab_main_name = '{first_main}' and cefstab_sub_name = '{first_sub}' ";

				ado_FieldList.Open(SQL, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

				while (!ado_FieldList.EOF)
				{

					temp_id2 = Convert.ToInt32(ado_FieldList["cef_id"]);
					sort_num2 = Convert.ToInt32(ado_FieldList["cef_sort"]);


					ado_FieldList.MoveNext();
				}


				ado_FieldList.Close();
				ado_FieldList = null;


				if (temp_id > 0 && temp_id2 > 0)
				{

					SQL = $"Update Custom_Export_Fields set  cef_sort = {temper.ToString()} where cef_id = {temp_id.ToString()} ";

					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = SQL;
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();


					SQL = $"Update Custom_Export_Fields set cef_sort = {sort_num1.ToString()} where cef_id = {temp_id2.ToString()} ";

					DbCommand TempCommand_2 = null;
					TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
					TempCommand_2.CommandText = SQL;
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
					TempCommand_2.ExecuteNonQuery();

					action_id = temp_id;

					FillCustomFieldList();

				}


			}
			return null;
		}

		public object Save_Custom_Export_Field()
		{

			// THIS FUNCTION SAVES A CUSTOM EXPORT FIELD RECORD
			string SQL = "";
			string group = "";
			string sub_group = "";
			string header_text = "";
			string display_text = "";
			string evo_field = "";
			string field_type = "";
			string field_length = "";
			string helptopic = "";
			string chk_b = "";
			string chk_h = "";
			string chk_c = "";
			string chk_y = "";
			string chk_a = "";
			string chk_summary = "";
			int temp_id = 0;
			string tab_group = "";
			string client_field_name = "";
			int temp_cef_id = 0;
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";


			string temp_main = "";
			string temp_sub = "";


			try
			{


				action_id = 0;
				//GET THE HELP TOPIC OUT OF THE CBO BOX
				helptopic = cbo_Help_Topic.Text.Substring(0, Math.Min(cbo_Help_Topic.Text.IndexOf('-'), cbo_Help_Topic.Text.Length));

				if (cbo_selected_group.Text == "New")
				{
					group = txt_new_group.Text;
				}
				else
				{
					group = cbo_selected_group.Text;
				}

				if (cbo_selected_sub_group.Text == "New")
				{
					sub_group = txt_sub_group.Text;
				}
				else
				{
					sub_group = cbo_selected_sub_group.Text;
				}

				tab_group = cbo_tab.Text;

				header_text = txt_header_name.Text;

				display_text = txt_display_name.Text;

				evo_field = txt_field_name.Text;

				field_type = cbo_field_type.Text;

				field_length = txt_length.Text;


				evo_field = StringsHelper.Replace(evo_field, "'", "''", 1, -1, CompareMethod.Binary);


				if (((int) chk_business.CheckState).ToString() == "1")
				{
					chk_b = "Y";
				}
				else
				{
					chk_b = "N";
				}

				if (((int) chk_helicopter.CheckState).ToString() == "1")
				{
					chk_h = "Y";
				}
				else
				{
					chk_h = "N";
				}

				if (((int) chk_comm.CheckState).ToString() == "1")
				{
					chk_c = "Y";
				}
				else
				{
					chk_c = "N";
				}

				if (((int) chk_yacht.CheckState).ToString() == "1")
				{
					chk_y = "Y";
				}
				else
				{
					chk_y = "N";
				}

				if (((int) chk_aero.CheckState).ToString() == "1")
				{
					chk_a = "Y";
				}
				else
				{
					chk_a = "N";
				}


				if (((int) chk_summary_level.CheckState).ToString() == "1")
				{
					chk_summary = "Y";
				}
				else
				{
					chk_summary = "N";
				}

				if (lbl_cef_id.Text.Trim() != "")
				{
					temp_id = Convert.ToInt32(Double.Parse(lbl_cef_id.Text));
				}
				else
				{
					temp_id = 0;
				}


				if (temp_id == 0)
				{

					strQuery1 = " select top 1 cef_id from Custom_Export_Fields order by cef_id desc";

					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);

					if ((rstRec1.BOF) && (rstRec1.EOF))
					{
					}
					else
					{
						temp_cef_id = Convert.ToInt32(rstRec1["cef_id"]);
					}
					temp_cef_id++;
					rstRec1.Close();
				}


				// ADDED MSW - 6/4/15 --------------------------
				if (temp_cef_id > 0 && evo_field.ToLower().Trim().IndexOf("(select") >= 0 && lbl_client_field.Text.Trim() == "")
				{
					client_field_name = $"rename_{temp_cef_id.ToString()}_{header_text}";
				}
				else if (evo_field.ToLower().Trim().IndexOf("(select") >= 0 && lbl_client_field.Text.Trim() == "")
				{ 
					client_field_name = $"rename_{temp_id.ToString()}_{header_text}";
				}
				else
				{
					client_field_name = lbl_client_field.Text.Trim();
				}
				//----------------------------------------------


				if (temp_id == 0)
				{


					SQL = " Insert into Custom_Export_Fields(cef_display, cef_header_field_name, cef_evo_field_name, cef_definition, ";
					SQL = $"{SQL}cef_values, cef_list_select_query, cef_advanced_search_flag, ";
					SQL = $"{SQL}cef_field_type, cef_field_length, ";
					SQL = $"{SQL}cef_product_business_flag, cef_product_helicopter_flag, cef_product_commercial_flag,";
					SQL = $"{SQL}cef_product_yacht_flag, cef_product_aerodex_flag, cef_sub_total_flag,";
					SQL = $"{SQL}cef_export_tab_id,  cef_export_block_id,cef_sort, cef_help_topic_id, ";
					SQL = $"{SQL} cef_evo_flag, cef_client_field_name,  cef_main_group, cef_sub_group ";

					SQL = $"{SQL} ) VALUES(";
					SQL = $"{SQL} '{display_text}', '{txt_header_name.Text}', '{evo_field}',";
					SQL = $"{SQL}'{txt_cef_definition.Text}',";

					SQL = $"{SQL}'{txt_cef_values.Text}',";
					SQL = $"{SQL}'{StringsHelper.Replace(txt_cef_list_select_query.Text, "'", ":", 1, -1, CompareMethod.Binary)}',";
					if (chk_cef_advanced_search_flag.CheckState == CheckState.Checked)
					{
						SQL = $"{SQL}'Y',";
					}
					else
					{
						SQL = $"{SQL}'N',";
					}
					SQL = $"{SQL}'{cbo_field_type.Text}', '{txt_length.Text}',";
					SQL = $"{SQL} '{chk_b}', '{chk_h}', '{chk_c}',";
					SQL = $"{SQL} '{chk_y}', '{chk_a}', '{chk_summary}', ";
					// EXPORT TAB
					//UPGRADE_WARNING: (1068) Get_PrimaryTab_ID() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
					SQL = $"{SQL}'{Convert.ToString(Get_PrimaryTab_ID(tab_group, cbo_selected_group.Text))}', ";
					// TAB BLOCK
					//UPGRADE_WARNING: (1068) Get_Block_ID() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
					SQL = $"{SQL}'{Convert.ToString(Get_Block_ID(cbo_selected_sub_group.Text))}',";

					// FIELD SORT
					if (Strings.Len(cbo_sort.Text.Trim()) > 0)
					{
						SQL = $"{SQL}{cbo_sort.Text.Trim()}, ";
					}
					else
					{
						SQL = $"{SQL}0, ";
					}

					SQL = $"{SQL}'{helptopic}',  'Y', ";



					if (client_field_name.Trim() != "")
					{
						SQL = $"{SQL}'{client_field_name}', ";
					}
					else
					{
						SQL = $"{SQL}NULL, ";
					}


					//UPGRADE_WARNING: (1068) Get_PrimaryTab_ID() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
					SQL = $"{SQL}(Select top 1 cefstab_main_name from Custom_Export_Tab with (NOLOCK) where cefstab_id = {Convert.ToString(Get_PrimaryTab_ID(tab_group, cbo_selected_group.Text))}),";
					//UPGRADE_WARNING: (1068) Get_PrimaryTab_ID() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
					SQL = $"{SQL}(Select top 1 cefstab_sub_name from Custom_Export_Tab with (NOLOCK) where cefstab_id = {Convert.ToString(Get_PrimaryTab_ID(tab_group, cbo_selected_group.Text))})";

					//SQL = SQL & "'" & temp_main & "',"
					// SQL = SQL & "'" & temp_sub & "'"


					SQL = $"{SQL} )";
				}
				else
				{

					SQL = $"Update Custom_Export_Fields  set cef_display = '{display_text}', ";
					SQL = $"{SQL} cef_header_field_name = '{txt_header_name.Text}', ";
					SQL = $"{SQL} cef_evo_field_name = '{evo_field}', ";
					SQL = $"{SQL} cef_definition = '{txt_cef_definition.Text}', ";
					SQL = $"{SQL} cef_values = '{txt_cef_values.Text}', ";
					SQL = $"{SQL} cef_list_select_query = '{StringsHelper.Replace(txt_cef_list_select_query.Text, "'", ":", 1, -1, CompareMethod.Binary)}', ";
					if (chk_cef_advanced_search_flag.CheckState == CheckState.Checked)
					{
						SQL = $"{SQL} cef_advanced_search_flag = 'Y', ";
					}
					else
					{
						SQL = $"{SQL} cef_advanced_search_flag = 'N', ";
					}

					// MUST BE CONVERTED TO  VALUE - cef_export_tab_id
					//UPGRADE_WARNING: (1068) Get_PrimaryTab_ID() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
					SQL = $"{SQL} cef_export_tab_id = '{Convert.ToString(Get_PrimaryTab_ID(tab_group, cbo_selected_group.Text))}', ";

					//UPGRADE_WARNING: (1068) Get_Block_ID() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
					SQL = $"{SQL} cef_export_block_id = '{Convert.ToString(Get_Block_ID(cbo_selected_sub_group.Text))}', ";

					if (Strings.Len(cbo_sort.Text.Trim()) > 0)
					{
						SQL = $"{SQL} cef_sort = {cbo_sort.Text}, ";
					}
					SQL = $"{SQL} cef_field_type = '{cbo_field_type.Text}',   cef_field_length = '{txt_length.Text}', ";
					SQL = $"{SQL} cef_product_business_flag = '{chk_b}',   cef_product_helicopter_flag = '{chk_h}', ";
					SQL = $"{SQL} cef_product_commercial_flag = '{chk_c}',  cef_product_yacht_flag = '{chk_y}', ";
					SQL = $"{SQL} cef_product_aerodex_flag = '{chk_a}',   cef_sub_total_flag = '{chk_summary}', ";
					SQL = $"{SQL} cef_help_topic_id = '{helptopic}', cef_sub_group_sort = '{cbo_sub_number.Text}', ";

					if (client_field_name.Trim() != "")
					{
						SQL = $"{SQL}cef_client_field_name = '{client_field_name}', ";
					}
					else
					{
						SQL = $"{SQL}cef_client_field_name = NULL, ";
					}


					//UPGRADE_WARNING: (1068) Get_PrimaryTab_ID() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
					SQL = $"{SQL} cef_main_group = (Select top 1 cefstab_main_name from Custom_Export_Tab with (NOLOCK) where cefstab_id = {Convert.ToString(Get_PrimaryTab_ID(tab_group, cbo_selected_group.Text))}),";
					//UPGRADE_WARNING: (1068) Get_PrimaryTab_ID() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
					SQL = $"{SQL} cef_sub_group = (Select top 1 cefstab_sub_name from Custom_Export_Tab with (NOLOCK) where cefstab_id = {Convert.ToString(Get_PrimaryTab_ID(tab_group, cbo_selected_group.Text))})";


					SQL = $"{SQL} where cef_id = {temp_id.ToString()} ";

					action_id = temp_id;


				}


				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = SQL;
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();

				FillCustomFieldList();
			}
			catch
			{
				MessageBox.Show($"Save_Custom_Export_Field_Error: {SQL}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

			return null;
		}

		public object Test_Connection_Query(string type_of)
		{


			string SQL = ""; //Current query sql
			ADORecordSetHelper ado_FieldList = new ADORecordSetHelper(); //Current recordset
			string sort_num = "";
			int nRow = 0;


			string temp_evo_field = txt_field_name.Text;
			temp_evo_field = temp_evo_field.ToLower().Trim();
			if (temp_evo_field.IndexOf(" as ") >= 0)
			{
				temp_evo_field = temp_evo_field.Substring(0, Math.Min(temp_evo_field.IndexOf(" as ") + 1, temp_evo_field.Length));
			}

			grid_details.Clear();
			//
			// FOR SUMMARY LEVEL QUERIES
			if (type_of == "Summary")
			{
				SQL = $"SELECT {temp_evo_field} as TestField, Count(*) as Tcount ";


				if (cbo_tab.Text.Trim() == "Company")
				{
					SQL = $"{SQL} FROM company WITH (NOLOCK)  left outer join contact on comp_id = contact_comp_id and comp_journ_id = contact_journ_id";
					SQL = $"{SQL} Where comp_journ_id = 0 and comp_state='NY'and comp_zip_code like '13%' ";
				}
				else
				{
					SQL = $"{SQL} FROM View_Aircraft_Flat WITH (NOLOCK) ";
					SQL = $"{SQL} WHERE ac_journ_id = 0 and amod_id in ('272') and ac_forsale_flag = 'Y' ";
				}

				SQL = $"{SQL} Group By {temp_evo_field} Order By {temp_evo_field} asc ";

				ado_FieldList.Open(SQL, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);
				grid_details.ColumnsCount = 2;

				grid_details.CurrentRowIndex = 0;
				grid_details.CurrentColumnIndex = 0;
				grid_details[grid_details.CurrentRowIndex, grid_details.CurrentColumnIndex].Value = txt_header_name.Text;
				grid_details.SetColumnWidth(0, 267);

				grid_details.CurrentColumnIndex = 1;
				grid_details[grid_details.CurrentRowIndex, grid_details.CurrentColumnIndex].Value = "Count";
				grid_details.SetColumnWidth(1, 47);


				nRow = 1;
				grid_details.CurrentRowIndex = nRow;
				while (!ado_FieldList.EOF)
				{



					grid_details.CurrentColumnIndex = 0;
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!(Convert.IsDBNull(ado_FieldList["TestField"])))
					{
						grid_details[grid_details.CurrentRowIndex, grid_details.CurrentColumnIndex].Value = ado_FieldList.GetField("TestField");
					}
					else
					{
						grid_details[grid_details.CurrentRowIndex, grid_details.CurrentColumnIndex].Value = "";
					}

					grid_details.CurrentColumnIndex = 1;
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!(Convert.IsDBNull(ado_FieldList["tcount"])))
					{
						grid_details[grid_details.CurrentRowIndex, grid_details.CurrentColumnIndex].Value = $"{Convert.ToString(ado_FieldList["tcount"])}   ";
					}




					nRow++;
					grid_details.RowsCount = nRow + 1;
					grid_details.CurrentRowIndex = nRow;

					ado_FieldList.MoveNext();
				}
				// **********************************************************
				// FOR DETAILED LEVEL QUERIES
			}
			else
			{



				if (cbo_tab.Text.Trim() == "Company")
				{
					SQL = $"SELECT DISTINCT {temp_evo_field} as TestField ";
					SQL = $"{SQL} FROM company WITH (NOLOCK)";
					SQL = $"{SQL} left outer join contact on comp_id = contact_comp_id and comp_journ_id = contact_journ_id";
					SQL = $"{SQL} Where comp_journ_id = 0 and comp_state='NY' and comp_zip_code like '13%' ";
				}
				else
				{
					SQL = "SELECT DISTINCT AMOD_MAKE_NAME AS 'MAKE',AMOD_MODEL_NAME AS 'MODEL',AC_REG_NO AS 'REGNO',AC_SER_NO_FULL AS 'SERNO', ";
					SQL = $"{SQL}{temp_evo_field} as  TestField ";
					SQL = $"{SQL} FROM View_Aircraft_Flat WITH (NOLOCK) ";

					SQL = $"{SQL} WHERE ac_journ_id = 0 and amod_id in ('272') and ac_forsale_flag = 'Y' ";
				}


				ado_FieldList.Open(SQL, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

				if (cbo_tab.Text.Trim() == "Company")
				{

					grid_details.ColumnsCount = 1;
					grid_details.CurrentRowIndex = 0;
					grid_details.CurrentColumnIndex = 0;
					grid_details[grid_details.CurrentRowIndex, grid_details.CurrentColumnIndex].Value = txt_header_name.Text;
					grid_details.SetColumnWidth(0, 300);


				}
				else
				{

					grid_details.ColumnsCount = 3;

					grid_details.CurrentRowIndex = 0;
					grid_details.CurrentColumnIndex = 0;
					grid_details[grid_details.CurrentRowIndex, grid_details.CurrentColumnIndex].Value = "MAKE/MODEL";
					grid_details.SetColumnWidth(0, 117);

					grid_details.CurrentColumnIndex = 1;
					grid_details[grid_details.CurrentRowIndex, grid_details.CurrentColumnIndex].Value = "SERNO";
					grid_details.SetColumnWidth(1, 43);


					grid_details.CurrentColumnIndex = 2;
					grid_details[grid_details.CurrentRowIndex, grid_details.CurrentColumnIndex].Value = txt_header_name.Text;
					grid_details.SetColumnWidth(2, 187);
				}




				nRow = 1;
				grid_details.CurrentRowIndex = nRow;
				while (!ado_FieldList.EOF)
				{

					if (cbo_tab.Text.Trim() == "Company")
					{

						grid_details.CurrentColumnIndex = 0;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!(Convert.IsDBNull(ado_FieldList["TestField"])))
						{
							grid_details[grid_details.CurrentRowIndex, grid_details.CurrentColumnIndex].Value = ado_FieldList.GetField("TestField");
						}
						else
						{
							grid_details[grid_details.CurrentRowIndex, grid_details.CurrentColumnIndex].Value = "";
						}

					}
					else
					{
						grid_details.CurrentColumnIndex = 0;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!(Convert.IsDBNull(ado_FieldList["MAKE"]) || Convert.IsDBNull(ado_FieldList["MODEL"])))
						{
							grid_details[grid_details.CurrentRowIndex, grid_details.CurrentColumnIndex].Value = $"{Convert.ToString(ado_FieldList["MAKE"])} {Convert.ToString(ado_FieldList["MODEL"])}";
						}

						grid_details.CurrentColumnIndex = 1;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!(Convert.IsDBNull(ado_FieldList["SERNO"])))
						{
							grid_details[grid_details.CurrentRowIndex, grid_details.CurrentColumnIndex].Value = $" {Convert.ToString(ado_FieldList["SERNO"])}";
						}

						grid_details.CurrentColumnIndex = 2;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!(Convert.IsDBNull(ado_FieldList["TestField"])))
						{
							grid_details[grid_details.CurrentRowIndex, grid_details.CurrentColumnIndex].Value = ado_FieldList.GetField("TestField");
						}
						else
						{
							grid_details[grid_details.CurrentRowIndex, grid_details.CurrentColumnIndex].Value = "";
						}

					}

					nRow++;
					grid_details.RowsCount = nRow + 1;
					grid_details.CurrentRowIndex = nRow;

					ado_FieldList.MoveNext();
				}
			}

			ado_FieldList.Close();
			return null;
		}

		private void Update_Command_Buttons(string Action)
		{
			//Enable/Disable Buttons

			switch(Action)
			{
				case "Enable" : 
					cmd_Add_JC.Enabled = true; 
					cmd_Add_User.Enabled = true; 
					 
					cmd_Cancel_JC.Enabled = true; 
					cmd_Cancel_User.Enabled = true; 
					 
					cmd_Delete_JC.Enabled = true; 
					cmd_Delete_User.Enabled = true; 
					 
					cmd_Save_JC.Enabled = true; 
					cmd_Save_User.Enabled = true; 
					//cmd_Save_Website.Enabled = True 
					 
					break;
				case "Disable" : 
					cmd_Add_JC.Enabled = false; 
					cmd_Add_User.Enabled = false; 
					 
					cmd_Cancel_JC.Enabled = false; 
					cmd_Cancel_User.Enabled = false; 
					 
					cmd_Delete_JC.Enabled = false; 
					cmd_Delete_User.Enabled = false; 
					 
					cmd_Save_JC.Enabled = false; 
					cmd_Save_User.Enabled = false; 
					// cmd_Save_Website.Enabled = False 
					 
					break;
			}

		}

		private void ToolbarButtonsSetup()
		{
			//turn toolbar buttons on, off


			ToolStrip tbr = tbr_ToolBar;

			tbr.Items[1].Visible = true;
			tbr.Items[3].Visible = false;
			tbr.Items[5].Visible = false;
			tbr.Items[7].Visible = true;

			tbr.Items[1].Enabled = true;
			tbr.Items[3].Enabled = false;
			tbr.Items[5].Enabled = true;
			tbr.Items[7].Enabled = true;

		}



		private void ToolbarSetup()
		{
			//set up names & images for toolar


			ToolStrip tbr = tbr_ToolBar;

			tbr.ImageList = mdi_AdminAssistant.DefInstance.imgNormal;

			tbr.Items[1].ImageKey = "Home";
			tbr.Items[3].ImageKey = "Back";
			tbr.Items[5].ImageKey = "Save";
			tbr.Items[7].ImageKey = "Help";

			tbr.Items[1].Name = "Home";
			tbr.Items[3].Name = "Back";
			tbr.Items[5].Name = "Save";
			tbr.Items[7].Name = "Help";

			tbr.Items[1].ToolTipText = "Go to Main Menu";
			tbr.Items[3].ToolTipText = "Go to Previous Screen";
			tbr.Items[5].ToolTipText = "Save screen data";
			tbr.Items[7].ToolTipText = "Online Help";

		}

		private void btn_new_Click(Object eventSender, EventArgs eventArgs)
		{
			action_id = 0;
			Fill_Selected_Group_Drop_Down("");
			Fill_Selected_Sub_Group_Drop_Down("");
			Fill_Selected_Field_Type_Drop_Down("");

			Fill_Help_Topic_List(0);

			txt_header_name.Text = "";
			txt_display_name.Text = "";
			txt_field_name.Text = "";
			txt_length.Text = "";
			txt_cef_definition.Text = "";
			txt_cef_values.Text = "";
			chk_cef_advanced_search_flag.CheckState = CheckState.Unchecked;


			chk_business.CheckState = CheckState.Unchecked;
			chk_helicopter.CheckState = CheckState.Unchecked;
			chk_comm.CheckState = CheckState.Unchecked;
			chk_yacht.CheckState = CheckState.Unchecked;
			chk_aero.CheckState = CheckState.Unchecked;

			lbl_cef_id.Text = "";


			lbl_updated.Visible = false;
			txt_new_group.Visible = false;
			txt_sub_group.Visible = false;
			SSTabHelper.SetSelectedIndex(tabstrip_data, 0);
			lbl_client_field.Text = "";

		}

		private void btn_save_Click(Object eventSender, EventArgs eventArgs)
		{

			Save_Custom_Export_Field();


			lbl_updated.Visible = true;

		}


		private void btn_send_Click(Object eventSender, EventArgs eventArgs)
		{
			modAdminCommon.Table_Action_Log("Custom_Export_Fields");
			MessageBox.Show("Custom Export Fields Table Submitted to Listener for Update.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
		}

		private void btn_test_query_Click(Object eventSender, EventArgs eventArgs)
		{

			Test_Connection_Query("Test");

			SSTabHelper.SetSelectedIndex(tabstrip_data, 1);

		}


		private void btn_update_sub_group_Click(Object eventSender, EventArgs eventArgs)
		{
			// update all records only on sub group where sub group = that



			string SQL = $"Update Custom_Export_Tab  set cefstab_order = '{cbo_sub_number.Text}' ";
			SQL = $"{SQL} where cefstab_sub_name = '{cbo_selected_sub_group.Text}' ";
			SQL = $"{SQL} and cefstab_main_name = '{cbo_selected_group.Text}'";


			DbCommand TempCommand = null;
			TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
			UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
			TempCommand.CommandText = SQL;
			UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
			TempCommand.ExecuteNonQuery();

			MessageBox.Show($"Your '{cbo_selected_sub_group.Text}' Sub Tab Sorting has Been Updated", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));

		}

		private void cbo_area_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs) => Fill_FieldGroups();


		private void cbo_avionics_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.cbo_avionics, eventSender);

			if (Index == 0)
			{
				Fill_Models();
			}
			else if (Index == 1)
			{ 
				Fill_Avionics();
			}
			else if (Index == 2)
			{ 
				if (cbo_avionics[2].Text.Trim().Trim() != "")
				{
					Fill_Avionics_Found("N");
				}
			}



		}

		private void cbo_FieldGroups_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs)
		{
			action_id = 0;

			FillCustomFieldList();
		}

		private void cbo_selected_group_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs) => txt_new_group.Visible = cbo_selected_group.Text == "New";


		private void cbo_selected_sub_group_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs) => txt_sub_group.Visible = cbo_selected_sub_group.Text == "New";


		private void cbo_tab_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs) => Fill_Selected_Group_Drop_Down(cbo_tab.Text);


		private void chk_service_MouseDown(Object eventSender, MouseEventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.chk_service, eventSender);
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float x = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;

			Application.DoEvents();
			Application.DoEvents();

			if (chk_service[Index].CheckState == CheckState.Checked)
			{ // if its 1, then its being shut off

			}
			else
			{
				// then its being turned on - so shut the others off
				if (Index != 0)
				{
					chk_service[0].CheckState = CheckState.Unchecked;
				}

				if (Index != 1)
				{
					chk_service[1].CheckState = CheckState.Unchecked;
				}

				if (Index != 2)
				{
					chk_service[2].CheckState = CheckState.Unchecked;
				}

				if (Index != 3)
				{
					chk_service[3].CheckState = CheckState.Unchecked;
				}

				if (Index != 4)
				{
					chk_service[4].CheckState = CheckState.Unchecked;
				}

				if (Index != 5)
				{
					chk_service[5].CheckState = CheckState.Unchecked;
				}
			}

		}


		private void chk_user_team_leader_flag_CheckStateChanged(Object eventSender, EventArgs eventArgs) => frmTeamLeader.Visible = chk_user_team_leader_flag.CheckState == CheckState.Checked;
		 // chk_user_team_leader_flag_Click

		private void chkIncludeInactive_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{

			chkIncludeInactive.Enabled = false;
			Load_User_Name_Grid();
			chkIncludeInactive.Enabled = true;

		}

		private void cmbTeamReports_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs)
		{

			string strTeam = "";
			bool bActive = false;

			string strUserId = txt_user_id.Text;
			string strReport = cmbTeamReports.Text;
			txtUserTeamLeaderTeam.Text = "";
			ToolTipMain.SetToolTip(lblUserTeamLeaderTeam, "");
			chkTeamLeaderReportActive.CheckState = CheckState.Unchecked;

			if (strUserId != "" && strReport != "")
			{
				strTeam = modAdminCommon.ReturnTeamUserIdsByTeamLeaderAndReportName(strUserId, strReport, ref bActive);
				txtUserTeamLeaderTeam.Text = strTeam;
				ToolTipMain.SetToolTip(lblUserTeamLeaderTeam, modAdminCommon.Return_User_Names_By_User_Id_List(txtUserTeamLeaderTeam.Text));
				if (bActive)
				{
					chkTeamLeaderReportActive.CheckState = CheckState.Checked;
				}
			} // If strUserId <> "" And strReport <> "" Then

		} // cmbTeamReports_Click

		private void cmd_Add_JC_Click(Object eventSender, EventArgs eventArgs)
		{
			//Display panel for adding new Journal Category records aey 4/8/04

			pnl_JC_Update_Change.Visible = true;
			// Journal_Category ("Clear")
			RecordStat = "Add";
			txt_jcat_category_name.Enabled = true;
			fG_JournalCat.CurrentColumnIndex = 0;
			txt_jcat_category_name.Text = "";
			fG_JournalCat.CurrentColumnIndex = 1;
			txt_jcat_category_code.Text = "";
			fG_JournalCat.CurrentColumnIndex = 2;
			txt_jcat_subcategory_name.Text = "";
			fG_JournalCat.CurrentColumnIndex = 3;
			txt_jcat_subcategory_code.Text = "";

		}

		private void cmd_Add_Service_Click(Object eventSender, EventArgs eventArgs)
		{

			pnl_Service_Update_Change.Visible = true;
			grd_Subscriptions.Visible = false;
			lbl_Subscriptions.Visible = false;
			//Service ("Clear")

			txt_serv_code.Text = "";
			txt_serv_name.Text = "";
			txt_serv_description.Text = "";
			lbl_serv_entry_date.Text = "";
			lbl_serv_entry_user_id.Text = "";
			lbl_serv_upd_date.Text = "";
			lbl_serv_upd_user_id.Text = "";

			RecordStat = "Add";
			txt_serv_code.Enabled = true;
			lbl_serv_entry_date.Text = DateTime.Today.ToString("MM-dd-yyyy");
			lbl_serv_entry_user_id.Text = modAdminCommon.gbl_User_ID;

		}

		private void cmd_Add_User_Click(Object eventSender, EventArgs eventArgs)
		{

			pnl_User_Update_Change.Visible = true;
			RecordStat = "Add";

			txt_user_id.Text = "";
			txt_user_first_name.Text = "";
			txt_user_middle_initial.Text = "";
			txt_user_last_name.Text = "";
			txt_user_password.Text = "";
			txt_user_email_address.Text = "";
			txt_user_phone_no.Text = "";
			txtUserCellNbr.Text = ""; // 04/19/2018 - By David D. Cruger; Added
			txt_user_phone_no_ext.Text = "";
			txt_user_default_account_id.Text = "";
			txt_user_comp_id.Text = "0";
			txt_user_contact_id.Text = "0";
			txt_user_description.Text = "";

			cbo_user_type.SelectedIndex = 0;
			cbo_user_type.Text = "";

			cmbDefaultAirframe.SelectedIndex = 0;
			cmbDefaultAirframe.Text = "";

			lbl_user_entry_date.Text = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
			lbl_user_entered_by.Text = modAdminCommon.gbl_User_ID;

			chkAutoCallback.CheckState = CheckState.Unchecked;
			chk_user_logged_in.CheckState = CheckState.Unchecked;
			chk_run_account_management_reports_flag.CheckState = CheckState.Unchecked;
			chk_remove_journal_subject_flag.CheckState = CheckState.Unchecked;
			chk_user_process_pubs_flag.CheckState = CheckState.Unchecked;
			chk_user_process_canadian_reg_flag.CheckState = CheckState.Unchecked;
			chk_user_process_ntsb_reports_flag.CheckState = CheckState.Unchecked;
			chk_user_edit_subscriptions.CheckState = CheckState.Unchecked;
			chk_user_open_multiple_homebase.CheckState = CheckState.Unchecked;
			chk_user_subscription_contract_amount.CheckState = CheckState.Unchecked;
			chk_user_manage_accounts_flags.CheckState = CheckState.Unchecked;
			chk_user_delete_attached_ac_specs_flag.CheckState = CheckState.Unchecked; // 06/18/2008 - By David D. Cruger; Added
			chk_user_hide_events_flag.CheckState = CheckState.Unchecked; // 06/24/2008 - By David D. Cruger; Added Per LF;
			chk_user_team_leader_flag.CheckState = CheckState.Unchecked; // 10/10/2017 - By David D. Cruger; Added
			chk_user_report_flag.CheckState = CheckState.Unchecked; // 11/03/2017 - By David D. Cruger; Added

			txt_user_marketing_subids_allowed.Text = "";

		} // cmd_Add_User_Click

		private void cmd_Analyze_Emails_Click(Object eventSender, EventArgs eventArgs) => Analyze_Emails();


		public void Analyze_Emails()
		{

			ADORecordSetHelper snp_email = new ADORecordSetHelper();
			int total_companies = 0;
			double tmp_percentage = 0;

			this.Cursor = Cursors.WaitCursor;

			grd_email.Visible = true;
			grd_email.Clear();
			grd_email.ColumnsCount = 3;
			grd_email.RowsCount = 1;
			grd_email.CurrentRowIndex = 0;
			grd_email.CurrentColumnIndex = 0;
			grd_email.SetColumnWidth(0, 200);
			grd_email[grd_email.CurrentRowIndex, grd_email.CurrentColumnIndex].Value = "Category";
			grd_email.CurrentColumnIndex = 1;
			grd_email.SetColumnWidth(1, 67);
			grd_email[grd_email.CurrentRowIndex, grd_email.CurrentColumnIndex].Value = "Total";
			grd_email.CurrentColumnIndex = 2;
			grd_email.SetColumnWidth(2, 67);
			grd_email[grd_email.CurrentRowIndex, grd_email.CurrentColumnIndex].Value = "Percent";


			grd_email.RowsCount++;
			grd_email.CurrentRowIndex = grd_email.RowsCount - 1;
			grd_email.CurrentColumnIndex = 0;
			grd_email[grd_email.CurrentRowIndex, grd_email.CurrentColumnIndex].Value = "Counting Companies ..";
			Application.DoEvents();

			string Query = "SELECT COUNT(*) AS tcount FROM Company WITH (NOLOCK) ";
			Query = $"{Query}WHERE (comp_journ_id = 0)  AND (comp_active_flag = 'Y')";

			snp_email.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

			if (!(snp_email.BOF && snp_email.EOF))
			{
				grd_email[grd_email.CurrentRowIndex, grd_email.CurrentColumnIndex].Value = "Total Companies";
				grd_email.CurrentColumnIndex = 1;
				grd_email.CellAlignment = DataGridViewContentAlignment.MiddleRight;
				grd_email[grd_email.CurrentRowIndex, grd_email.CurrentColumnIndex].Value = StringsHelper.Format(snp_email["tcount"], "###,##0");
				total_companies = Convert.ToInt32(snp_email["tcount"]);
			}
			snp_email.Close();


			grd_email.RowsCount++;
			grd_email.CurrentRowIndex = grd_email.RowsCount - 1;
			grd_email.CurrentColumnIndex = 0;
			grd_email[grd_email.CurrentRowIndex, grd_email.CurrentColumnIndex].Value = "Counting Email Addresses ..";
			Application.DoEvents();

			Query = "SELECT COUNT(*) as tcount FROM Company WITH (NOLOCK) WHERE (comp_email_address IS NOT NULL) ";
			Query = $"{Query}AND (comp_email_address <> '') AND (comp_journ_id = 0) AND (comp_active_flag = 'Y')";

			snp_email.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

			if (!(snp_email.BOF && snp_email.EOF))
			{
				grd_email[grd_email.CurrentRowIndex, grd_email.CurrentColumnIndex].Value = "Total Companies w/Email Addresses";
				grd_email.CurrentColumnIndex = 1;
				grd_email.CellAlignment = DataGridViewContentAlignment.MiddleRight;
				grd_email[grd_email.CurrentRowIndex, grd_email.CurrentColumnIndex].Value = StringsHelper.Format(snp_email["tcount"], "###,##0");
				grd_email.CurrentColumnIndex = 2;
				grd_email.CellAlignment = DataGridViewContentAlignment.MiddleRight;
				tmp_percentage = (Convert.ToDouble(snp_email["tcount"]) / ((double) total_companies)) * 100;
				grd_email[grd_email.CurrentRowIndex, grd_email.CurrentColumnIndex].Value = $"{StringsHelper.Format(tmp_percentage, "##0.00")}%";
			}
			snp_email.Close();

			//-----------------------------------------------
			// GET THE TOTAL NUMBER OF EMAILS WITH AOL
			grd_email.RowsCount++;
			grd_email.CurrentRowIndex = grd_email.RowsCount - 1;
			grd_email.CurrentColumnIndex = 0;
			grd_email[grd_email.CurrentRowIndex, grd_email.CurrentColumnIndex].Value = "Counting AOL Addresses ..";
			Application.DoEvents();

			Query = "SELECT COUNT(*) as tcount FROM Company WITH (NOLOCK) ";
			Query = $"{Query}WHERE (comp_email_address IS NOT NULL) AND (comp_email_address <> '') ";
			Query = $"{Query}AND (comp_journ_id = 0) AND (comp_active_flag = 'Y') AND (comp_email_address LIKE '%aol.com%') ";

			snp_email.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

			if (!(snp_email.BOF && snp_email.EOF))
			{
				grd_email[grd_email.CurrentRowIndex, grd_email.CurrentColumnIndex].Value = "AOL Addresses";
				grd_email.CurrentColumnIndex = 1;
				grd_email.CellAlignment = DataGridViewContentAlignment.MiddleRight;
				grd_email[grd_email.CurrentRowIndex, grd_email.CurrentColumnIndex].Value = StringsHelper.Format(snp_email["tcount"], "###,##0");
				grd_email.CurrentColumnIndex = 2;
				grd_email.CellAlignment = DataGridViewContentAlignment.MiddleRight;
				tmp_percentage = (Convert.ToDouble(snp_email["tcount"]) / ((double) total_companies)) * 100;
				grd_email[grd_email.CurrentRowIndex, grd_email.CurrentColumnIndex].Value = $"{StringsHelper.Format(tmp_percentage, "##0.00")}%";
			}
			snp_email.Close();

			//-----------------------------------------------
			// GET THE TOTAL NUMBER OF EMAILS WITH HOTMAIL

			grd_email.RowsCount++;
			grd_email.CurrentRowIndex = grd_email.RowsCount - 1;
			grd_email.CurrentColumnIndex = 0;
			grd_email[grd_email.CurrentRowIndex, grd_email.CurrentColumnIndex].Value = "Counting HOTMAIL Addresses ..";
			Application.DoEvents();

			Query = "SELECT COUNT(*) as tcount FROM Company WITH (NOLOCK) ";
			Query = $"{Query}WHERE (comp_email_address IS NOT NULL) AND (comp_email_address <> '') ";
			Query = $"{Query}AND (comp_journ_id = 0) AND (comp_active_flag = 'Y') AND (comp_email_address LIKE '%hotmail.com%') ";

			snp_email.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

			if (!(snp_email.BOF && snp_email.EOF))
			{
				grd_email[grd_email.CurrentRowIndex, grd_email.CurrentColumnIndex].Value = "HOTMAIL Addresses";
				grd_email.CurrentColumnIndex = 1;
				grd_email.CellAlignment = DataGridViewContentAlignment.MiddleRight;
				grd_email[grd_email.CurrentRowIndex, grd_email.CurrentColumnIndex].Value = StringsHelper.Format(snp_email["tcount"], "###,##0");
				grd_email.CurrentColumnIndex = 2;
				grd_email.CellAlignment = DataGridViewContentAlignment.MiddleRight;
				tmp_percentage = (Convert.ToDouble(snp_email["tcount"]) / ((double) total_companies)) * 100;
				grd_email[grd_email.CurrentRowIndex, grd_email.CurrentColumnIndex].Value = $"{StringsHelper.Format(tmp_percentage, "##0.00")}%";
			}
			snp_email.Close();

			//-----------------------------------------------
			// GET THE TOTAL NUMBER OF EMAILS WITH GMAIL

			grd_email.RowsCount++;
			grd_email.CurrentRowIndex = grd_email.RowsCount - 1;
			grd_email.CurrentColumnIndex = 0;
			grd_email[grd_email.CurrentRowIndex, grd_email.CurrentColumnIndex].Value = "Counting GMAIL Addresses ..";
			Application.DoEvents();

			Query = "SELECT COUNT(*) as tcount FROM Company WITH (NOLOCK) ";
			Query = $"{Query}WHERE (comp_email_address IS NOT NULL)  AND (comp_email_address <> '') ";
			Query = $"{Query}AND (comp_journ_id = 0) AND (comp_active_flag = 'Y') AND (comp_email_address LIKE '%gmail.com%') ";

			snp_email.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

			if (!(snp_email.BOF && snp_email.EOF))
			{
				grd_email[grd_email.CurrentRowIndex, grd_email.CurrentColumnIndex].Value = "GMAIL Addresses";
				grd_email.CurrentColumnIndex = 1;
				grd_email.CellAlignment = DataGridViewContentAlignment.MiddleRight;
				grd_email[grd_email.CurrentRowIndex, grd_email.CurrentColumnIndex].Value = StringsHelper.Format(snp_email["tcount"], "###,##0");
				grd_email.CurrentColumnIndex = 2;
				grd_email.CellAlignment = DataGridViewContentAlignment.MiddleRight;
				tmp_percentage = (Convert.ToDouble(snp_email["tcount"]) / ((double) total_companies)) * 100;
				grd_email[grd_email.CurrentRowIndex, grd_email.CurrentColumnIndex].Value = $"{StringsHelper.Format(tmp_percentage, "##0.00")}%";
			}
			snp_email.Close();

			//-----------------------------------------------
			// GET THE TOTAL NUMBER OF EMAILS WITH YACHOO

			grd_email.RowsCount++;
			grd_email.CurrentRowIndex = grd_email.RowsCount - 1;
			grd_email.CurrentColumnIndex = 0;
			grd_email[grd_email.CurrentRowIndex, grd_email.CurrentColumnIndex].Value = "Counting YAHOO Addresses ..";
			Application.DoEvents();

			Query = "SELECT COUNT(*) as tcount FROM Company WITH (NOLOCK) WHERE (comp_email_address IS NOT NULL) ";
			Query = $"{Query}AND (comp_email_address <> '') AND (comp_journ_id = 0) AND (comp_active_flag = 'Y')";
			Query = $"{Query}AND (comp_email_address LIKE '%yahoo.com%') ";

			snp_email.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

			if (!(snp_email.BOF && snp_email.EOF))
			{
				grd_email[grd_email.CurrentRowIndex, grd_email.CurrentColumnIndex].Value = "YAHOO Addresses";
				grd_email.CurrentColumnIndex = 1;
				grd_email.CellAlignment = DataGridViewContentAlignment.MiddleRight;
				grd_email[grd_email.CurrentRowIndex, grd_email.CurrentColumnIndex].Value = StringsHelper.Format(snp_email["tcount"], "###,##0");
				grd_email.CurrentColumnIndex = 2;
				grd_email.CellAlignment = DataGridViewContentAlignment.MiddleRight;
				tmp_percentage = (Convert.ToDouble(snp_email["tcount"]) / ((double) total_companies)) * 100;
				grd_email[grd_email.CurrentRowIndex, grd_email.CurrentColumnIndex].Value = $"{StringsHelper.Format(tmp_percentage, "##0.00")}%";
			}
			snp_email.Close();

			//-------------------------------------------------------
			// GET THE TOTAL NUMBER OF EMAILS Structured Bad

			grd_email.RowsCount++;
			grd_email.CurrentRowIndex = grd_email.RowsCount - 1;
			grd_email.CurrentColumnIndex = 0;
			grd_email[grd_email.CurrentRowIndex, grd_email.CurrentColumnIndex].Value = "Counting Addresses with Bad Structure ..";
			Application.DoEvents();

			Query = "SELECT COUNT(*) as tcount FROM Company WITH (NOLOCK) WHERE (comp_email_address IS NOT NULL) ";
			Query = $"{Query}AND (comp_email_address <> '')  AND (comp_journ_id = 0) AND (comp_active_flag = 'Y')";
			Query = $"{Query}AND (comp_email_address not like '%@%.%') ";

			snp_email.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

			if (!(snp_email.BOF && snp_email.EOF))
			{
				grd_email[grd_email.CurrentRowIndex, grd_email.CurrentColumnIndex].Value = "Address with Bad Structure (@ & .)";
				grd_email.CurrentColumnIndex = 1;
				grd_email.CellAlignment = DataGridViewContentAlignment.MiddleRight;
				grd_email[grd_email.CurrentRowIndex, grd_email.CurrentColumnIndex].Value = StringsHelper.Format(snp_email["tcount"], "###,##0");
				grd_email.CurrentColumnIndex = 2;
				grd_email.CellAlignment = DataGridViewContentAlignment.MiddleRight;
				tmp_percentage = (Convert.ToDouble(snp_email["tcount"]) / ((double) total_companies)) * 100;
				grd_email[grd_email.CurrentRowIndex, grd_email.CurrentColumnIndex].Value = $"{StringsHelper.Format(tmp_percentage, "##0.00")}%";
			}
			snp_email.Close();

			grd_email.FixedRows = 1;
			grd_email.FixedColumns = 0;

			snp_email = null;
			this.Cursor = CursorHelper.CursorDefault;

		} // Analyze_Emails

		private void cmd_AppConfig_save_Click(Object eventSender, EventArgs eventArgs)
		{

			string SQL = ""; //Current query sql
			string FLDS = ""; //work fields for query string
			string VALS = ""; //value work fields for query string
			string Comma = ""; //comma work field for query string

			try
			{

				SQL = "DELETE FROM Application_Configuration ";
				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = SQL;
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();
				Comma = "";
				FLDS = "INSERT INTO Application_Configuration (";
				VALS = ") VALUES (";
				if (Strings.Len(txt_aconfig_website.Text.Trim()) > 0)
				{
					FLDS = $"{FLDS}aconfig_website";
					VALS = $"{VALS}'{modAdminCommon.Fix_Quote(txt_aconfig_website).Trim()}'";
					Comma = ",";
				}
				if (Strings.Len(txt_aconfig_fileserver.Text.Trim()) > 0)
				{
					FLDS = $"{FLDS}{Comma} aconfig_fileserver";
					VALS = $"{VALS}{Comma} '{modAdminCommon.Fix_Quote(txt_aconfig_fileserver).Trim()}'";
					Comma = ",";
				}
				if (Strings.Len(txtColorConfirmDays.Text.Trim()) > 0)
				{
					FLDS = $"{FLDS}{Comma} aconfig_color_confirm_days";
					VALS = $"{VALS}{Comma} {Conversion.Val(modAdminCommon.Fix_Quote(txtColorConfirmDays).Trim()).ToString()}";
					Comma = ",";
				}
				if (Strings.Len(txt_aconfig_model.Text.Trim()) > 0)
				{
					FLDS = $"{FLDS}{Comma} aconfig_model";
					VALS = $"{VALS}{Comma} '{modAdminCommon.Fix_Quote(txt_aconfig_model).Trim()}'";
					Comma = ",";
				}
				if (Strings.Len(txt_aconfig_documents.Text.Trim()) > 0)
				{
					FLDS = $"{FLDS}{Comma} aconfig_documents";
					VALS = $"{VALS}{Comma} '{modAdminCommon.Fix_Quote(txt_aconfig_documents).Trim()}'";
					Comma = ",";
				}
				if (Strings.Len(txt_aconfig_processing.Text.Trim()) > 0)
				{
					FLDS = $"{FLDS}{Comma} aconfig_processing";
					VALS = $"{VALS}{Comma} '{modAdminCommon.Fix_Quote(txt_aconfig_processing).Trim()}'";
					Comma = ",";
				}
				SQL = $"{FLDS}{VALS})";
				DbCommand TempCommand_2 = null;
				TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
				TempCommand_2.CommandText = SQL;
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
				TempCommand_2.ExecuteNonQuery();

				Is_Dirty = false;
			}
			catch
			{
				Is_Dirty = false;
				this.Cursor = CursorHelper.CursorDefault;
				modAdminCommon.Report_Error("CommonLookup AppConfig Save Error: ");
				return;
			}

		}


		private void cmd_apu_Click(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.cmd_apu, eventSender);


			string SQL = "";
			string SQL2 = "";
			StringBuilder ac_id_list = new StringBuilder();
			ADORecordSetHelper ado_FieldList = new ADORecordSetHelper();
			int ac_count = 0;
			int record_count = 0;
			string SQL_Delete = "";

			lbl_apu[0].Visible = false;
			cmd_apu[2].Visible = false;
			cmd_apu[3].Visible = false;


			if (Index == 0)
			{
				// search

				SQL = " select distinct ac_apu_model_name, count(*) as tcount from aircraft with (NOLOCK)";
				SQL = $"{SQL} Where ac_journ_id = 0 And ac_apu_model_name Is Not Null";

				if (txt_search_apu[0].Text.Trim() != "")
				{
					SQL = $"{SQL} and ac_apu_model_name like '%{txt_search_apu[0].Text}%' ";
				}

				SQL = $"{SQL} group by ac_apu_model_name order by ac_apu_model_name asc";


				ado_FieldList.Open(SQL, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

				lst_apu[0].Items.Clear();
				while (!ado_FieldList.EOF)
				{


					lst_apu[0].AddItem($"{($"{Convert.ToString(ado_FieldList["ac_apu_model_name"])}").Trim()}  |({Convert.ToString(ado_FieldList["tcount"])})");
					record_count++;
					ac_count = Convert.ToInt32(ac_count + (Convert.ToDouble(ado_FieldList["tcount"])));


					ado_FieldList.MoveNext();
				}

				lbl_apu[2].Text = $"Total Unique APU Records: {record_count.ToString()}, Total Count: {ac_count.ToString()}";


			}
			else if (Index == 1)
			{ 


				SQL = $"{SQL}  select distinct ac_id  from aircraft with (NOLOCK)";
				SQL = $"{SQL} Where ac_journ_id = 0 And ac_apu_model_name Is Not Null ";
				SQL = $"{SQL} and ac_apu_model_name = '{Convert.ToString(txt_search_apu[1].Tag)}' "; // tag so it updates what it was


				ado_FieldList.Open(SQL, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);


				while (!ado_FieldList.EOF)
				{

					if (ac_id_list.ToString().Trim() != "")
					{
						ac_id_list.Append(",");
					}

					ac_id_list.Append($"'{Convert.ToString(ado_FieldList["ac_id"]).Trim()}'");
					record_count++;

					ado_FieldList.MoveNext();
				}


				lbl_apu[0].Text = $"This will update {record_count.ToString()} Record(s), Are You Sure You Want to Run This Update?";
				lbl_apu[0].Tag = ac_id_list.ToString();

				lbl_apu[0].Visible = true;
				cmd_apu[2].Visible = true;
				cmd_apu[3].Visible = true;

			}
			else if (Index == 2)
			{ 

				ac_id_list = new StringBuilder(Convert.ToString(lbl_apu[0].Tag));

				SQL2 = $"Update Aircraft set ac_apu_model_name = '{txt_search_apu[1].Text.Trim()}', ac_action_date  = NULL where ac_id in ({ac_id_list.ToString()}) and ac_journ_id = 0  ";


				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = SQL2;
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();
				MessageBox.Show("Record(s) Updated", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				cmd_apu_Click(cmd_apu[0], new EventArgs());
			}
			else if (Index == 3)
			{ 

				lbl_apu[0].Visible = false;
				cmd_apu[2].Visible = false;
				cmd_apu[3].Visible = false;
			}
		}


		private void cmd_av_button_Click(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.cmd_av_button, eventSender);
			string temp_string = "";

			string SQL = "";
			string SQL2 = "";
			StringBuilder ac_id_list = new StringBuilder();
			ADORecordSetHelper ado_FieldList = new ADORecordSetHelper();
			int record_count = 0;
			string SQL_Delete = "";

			string Query2 = "";
			if (Index == 0)
			{
				pnl_yes_no.Visible = true;

				cmd_av_button[4].Visible = false;
				cmd_av_button[5].Visible = false;
				txt_avionics[2].Visible = false;

				ac_id_list = new StringBuilder("");
				SQL = "";
				SQL2 = "";
				record_count = 0;

				SQL = " select distinct ac_id from Aircraft_Avionics with (NOLOCK)";
				SQL = $"{SQL} inner join Aircraft with (NOLOCK) on ac_id = av_ac_id and ac_journ_id = av_ac_journ_id";
				SQL = $"{SQL} inner join Aircraft_Model with (NOLOCK) on ac_amod_id = amod_id";
				SQL = $"{SQL} Where ac_journ_id = 0 ";

				if (cbo_avionics[0].Text.Trim() != "")
				{
					SQL = $"{SQL} and amod_make_name = '{cbo_avionics[0].Text}' ";
				}

				if (cbo_avionics[1].Text.Trim() != "")
				{
					SQL = $"{SQL} and amod_model_name = '{cbo_avionics[1].Text}' ";
				}

				if (cbo_avionics[2].Text.Trim() != "")
				{
					SQL = $"{SQL} and av_name = '{cbo_avionics[2].Text.Trim()}' ";
				}


				if (lbl_avionics[3].Text.Trim() != "")
				{
					SQL = $"{SQL} and av_description = '{lbl_avionics[3].Text.Trim()}' ";
				}

				if (txt_avionics[1].Text.Trim() != "")
				{
					SQL = $"{SQL} and av_description like '%{txt_avionics[1].Text.Trim()}%' ";
				}


				ado_FieldList.Open(SQL, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);


				while (!ado_FieldList.EOF)
				{

					record_count++;

					ado_FieldList.MoveNext();
				}

				lbl_avionics[5].Text = $"This will update {record_count.ToString()} Record(s), Are You Sure You Want to Run This Update?";


			}
			else if (Index == 1)
			{ 
				pnl_yes_no.Visible = false;
				//yes click


				try
				{


					cmd_av_button[4].Visible = false;
					cmd_av_button[5].Visible = false;
					txt_avionics[2].Visible = false;

					ac_id_list = new StringBuilder("");
					SQL = "";
					SQL2 = "";


					if (!cmd_av_button[0].Visible && !txt_avionics[0].Visible)
					{

						SQL = " select distinct ac_id from Aircraft_Avionics with (NOLOCK)";
						SQL = $"{SQL} inner join Aircraft with (NOLOCK) on ac_id = av_ac_id and ac_journ_id = av_ac_journ_id";
						SQL = $"{SQL} inner join Aircraft_Model with (NOLOCK) on ac_amod_id = amod_id";
						SQL = $"{SQL} Where ac_journ_id = 0 and av_description like '%{txt_avionics[1].Text.Trim()}%' ";

						ado_FieldList.Open(SQL, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);
						while (!ado_FieldList.EOF)
						{

							if (ac_id_list.ToString().Trim() != "")
							{
								ac_id_list.Append(",");
							}

							ac_id_list.Append($"'{Convert.ToString(ado_FieldList["ac_id"]).Trim()}'");

							ado_FieldList.MoveNext();
						}

						SQL = "";
						SQL = $"{SQL} Update Aircraft_Avionics set av_description = replace(av_description, '{txt_avionics[1].Text}', '{txt_avionics[2].Text}')  where av_ac_id in ({ac_id_list.ToString()}) and av_ac_journ_id = 0  ";
						SQL = $"{SQL} and av_description like '%{txt_avionics[1].Text.Trim()}%' ";
						SQL = SQL;
						DbCommand TempCommand = null;
						TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
						TempCommand.CommandText = SQL;
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
						TempCommand.ExecuteNonQuery();

						if (lbl_avionics[8].Visible && Strings.Len(lbl_avionics[8].Text.Trim()) > 5)
						{
							// Call InsertJournalNote_AC("Avionics Mass Update", Replace(lbl_avionics(8).Caption & " " & lbl_avionics(5).Caption, "'", "''"))

							Query2 = "INSERT INTO Eventlog   ( ";
							Query2 = $"{Query2}evtl_date, evtl_user_id, evtl_type, evtl_message, evtl_ac_id, evtl_journ_id";
							Query2 = $"{Query2} ) VALUES ('{DateTimeHelper.ToString(DateTime.Today)} {DateTimeHelper.ToString(DateTimeHelper.Time)}',"; // date
							Query2 = $"{Query2}'{modAdminCommon.gbl_User_ID}',"; // user id
							Query2 = $"{Query2}'Avionics Mass Update',"; // type
							Query2 = $"{Query2}'{StringsHelper.Replace($"{lbl_avionics[8].Text} {lbl_avionics[5].Text}", "'", "''", 1, -1, CompareMethod.Binary)}',";
							Query2 = $"{Query2}0,0) ";

							DbCommand TempCommand_2 = null;
							TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
							TempCommand_2.CommandText = Query2;
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
							TempCommand_2.ExecuteNonQuery();
						}

					}
					else
					{



						SQL = " select distinct ac_id from Aircraft_Avionics with (NOLOCK)";
						SQL = $"{SQL} inner join Aircraft with (NOLOCK) on ac_id = av_ac_id and ac_journ_id = av_ac_journ_id";
						SQL = $"{SQL} inner join Aircraft_Model with (NOLOCK) on ac_amod_id = amod_id";
						SQL = $"{SQL} Where ac_journ_id = 0 ";

						if (cbo_avionics[0].Text.Trim() != "")
						{
							SQL = $"{SQL} and amod_make_name = '{cbo_avionics[0].Text}' ";
						}

						if (cbo_avionics[1].Text.Trim() != "")
						{
							SQL = $"{SQL} and amod_model_name = '{cbo_avionics[1].Text}' ";
						}

						if (cbo_avionics[2].Text.Trim() != "")
						{
							SQL = $"{SQL} and av_name = '{cbo_avionics[2].Text.Trim()}' ";
						}


						if (lbl_avionics[3].Text.Trim() != "")
						{
							SQL = $"{SQL} and av_description = '{lbl_avionics[3].Text.Trim()}' ";
						}

						if (txt_avionics[1].Text.Trim() != "")
						{
							SQL = $"{SQL} and av_description like '%{txt_avionics[1].Text.Trim()}%' ";
						}


						ado_FieldList.Open(SQL, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);


						while (!ado_FieldList.EOF)
						{

							if (ac_id_list.ToString().Trim() != "")
							{
								ac_id_list.Append(",");
							}

							ac_id_list.Append($"'{Convert.ToString(ado_FieldList["ac_id"]).Trim()}'");

							ado_FieldList.MoveNext();
						}



						// SET IT EQUAL TO CAPTION 4 - second one where it is 3, the first one
						SQL = $" Update Aircraft_Avionics set av_description = '{txt_avionics[0].Text}' where av_ac_id in ({ac_id_list.ToString()}) and av_ac_journ_id = 0  ";


						if (cbo_avionics[2].Text.Trim() != "")
						{
							SQL = $"{SQL} and av_name = '{cbo_avionics[2].Text.Trim()}' ";
						}


						if (lbl_avionics[3].Text.Trim() != "")
						{
							SQL = $"{SQL} and av_description = '{lbl_avionics[3].Text.Trim()}' ";
						}

						if (txt_avionics[1].Text.Trim() != "")
						{
							SQL = $"{SQL} and av_description like '%{txt_avionics[1].Text.Trim()}%' ";
						}

						DbCommand TempCommand_3 = null;
						TempCommand_3 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_3);
						TempCommand_3.CommandText = SQL;
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_3);
						TempCommand_3.ExecuteNonQuery();

					}

					SQL2 = $" Update Aircraft set ac_action_date  = NULL where ac_id in ({ac_id_list.ToString()}) and ac_journ_id = 0  ";


					DbCommand TempCommand_4 = null;
					TempCommand_4 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_4);
					TempCommand_4.CommandText = SQL2;
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_4);
					TempCommand_4.ExecuteNonQuery();
					cmd_av_button_Click(cmd_av_button[3], new EventArgs());

					return;
				}
				catch
				{

					MessageBox.Show("Error Updating, Please Check the AC List For Possible Issues with ****.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));

					temp_string = txt_avionics[0].Text;
					lst_av_names_SelectedIndexChanged(lst_av_names[0], new EventArgs()); // run it like you clicked on the left again
					lbl_avionics[7].Text = temp_string; // set the temp_string as if you clicked on the one in the box wethaer u did or not
					Fill_Avionics_Found("Y"); //' run it liked you clicked on right again
					txt_avionics[0].Text = temp_string;

					return;
				}
			}
			else if (Index == 2)
			{ 
				pnl_yes_no.Visible = false;
				// no click
			}
			else if (Index == 3)
			{ 
				Fill_Avionics_Found("N");
			}
			else if (Index == 4)
			{ 
				txt_avionics[2].Text = "";
				txt_avionics[2].Visible = true;
				cmd_av_button[0].Visible = false;
				txt_avionics[0].Visible = false;
				cmd_av_button[4].Visible = false;
				cmd_av_button[5].Visible = true;


			}
			else if (Index == 5)
			{ 
				if (txt_avionics[2].Text.Trim() != "")
				{
					if (Strings.Len(txt_avionics[2].Text.Trim()) > 3)
					{
						pnl_yes_no.Visible = true;

						ac_id_list = new StringBuilder("");
						SQL = "";
						SQL2 = "";
						record_count = 0;

						SQL = " select distinct ac_id from Aircraft_Avionics with (NOLOCK)";
						SQL = $"{SQL} inner join Aircraft with (NOLOCK) on ac_id = av_ac_id and ac_journ_id = av_ac_journ_id";
						SQL = $"{SQL} inner join Aircraft_Model with (NOLOCK) on ac_amod_id = amod_id";
						SQL = $"{SQL} Where ac_journ_id = 0 ";
						SQL = $"{SQL} and av_description like '%{txt_avionics[1].Text.Trim()}%' ";

						ado_FieldList.Open(SQL, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

						while (!ado_FieldList.EOF)
						{

							record_count++;

							ado_FieldList.MoveNext();
						}


						lbl_avionics[8].Text = $"You have Requested to Change '{txt_avionics[1].Text}' to '{txt_avionics[2].Text}'.";
						lbl_avionics[8].Visible = true;

						cmd_av_button[0].Visible = false;
						txt_avionics[0].Visible = false;

						lbl_avionics[5].Text = $"This will update {record_count.ToString()} Record(s), Are You Sure You Want to Run This Update?";
					}
					else
					{
						MessageBox.Show("Please Enter More Than 3 Characters to Update", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK);
					}
				}
				else
				{
					MessageBox.Show("Please Enter More Than 3 Characters to Update", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK);
				}
			}



		}

		private void cmd_Cancel_JC_Click(Object eventSender, EventArgs eventArgs) => pnl_JC_Update_Change.Visible = false;



		private void cmd_Cancel_Service_Click(Object eventSender, EventArgs eventArgs)
		{
			pnl_Service_Update_Change.Visible = false;
			lbl_Subscriptions.Visible = false;
			grd_Subscriptions.Visible = false;
		}

		private void cmd_Cancel_User_Click(Object eventSender, EventArgs eventArgs) => pnl_User_Update_Change.Visible = false;


		private void cmd_class_Click(Object eventSender, EventArgs eventArgs)
		{



			string SQL2 = "";

			string Query2 = "INSERT INTO Eventlog  ( ";
			Query2 = $"{Query2}evtl_date, evtl_user_id, evtl_type, evtl_message, evtl_ac_id, evtl_journ_id";
			Query2 = $"{Query2} ) VALUES (";
			Query2 = $"{Query2}'{DateTimeHelper.ToString(DateTime.Today)} {DateTimeHelper.ToString(DateTimeHelper.Time)}',"; // date
			Query2 = $"{Query2}'{modAdminCommon.gbl_User_ID}',"; // user id


			// if we have an ID then update
			if (Convert.ToString(lst_class.Tag) != "" && Convert.ToString(lst_class.Tag) != "0")
			{

				SQL2 = $" Update Aircraft_Class set aclass_name = '{txt_class[1].Text.Trim().Substring(0, Math.Min(50, txt_class[1].Text.Trim().Length))}'  ";

				SQL2 = $"{SQL2}, aclass_common_verify_days = '{cbo_days[0].Text.Trim()}'  ";
				SQL2 = $"{SQL2}, aclass_sale_verify_days = '{cbo_days[1].Text.Trim()}'  ";

				SQL2 = $"{SQL2} where aclass_code = '{txt_class[0].Text.Trim()}'  ";


				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = SQL2;
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();



				SQL2 = $"Update Aircraft_Model set amod_common_verify_days = '{cbo_days[0].Text.Trim()}',  ";
				SQL2 = $"{SQL2}  amod_sale_verify_days = '{cbo_days[1].Text.Trim()}'  ";
				SQL2 = $"{SQL2} where amod_class_code = '{txt_class[0].Text.Trim()}'  ";

				//Call MsgBox(SQL2)
				DbCommand TempCommand_2 = null;
				TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
				TempCommand_2.CommandText = SQL2;
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
				TempCommand_2.ExecuteNonQuery();

				Query2 = $"{Query2}'Class Update',";

			}
			else
			{
				SQL2 = " Insert Into Aircraft_Class (aclass_code, aclass_code";
				SQL2 = $"{SQL2}, aclass_common_verify_days, aclass_sale_verify_days";
				SQL2 = $"{SQL2}) VALUES ('{txt_class[0].Text.Trim()}' "; // code
				SQL2 = $"{SQL2},'{txt_class[1].Text.Trim().Substring(0, Math.Min(50, txt_class[1].Text.Trim().Length))}' "; // name
				SQL2 = $"{SQL2},'{cbo_days[0].Text.Trim()}' ";
				SQL2 = $"{SQL2},'{cbo_days[1].Text.Trim()}') ";
				MessageBox.Show(SQL2, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));

				Query2 = $"{Query2}'Class Insert',";

			}





			Query2 = $"{Query2}'{txt_class[0].Text.Trim()}, {txt_class[1].Text.Trim()},{cbo_days[0].Text.Trim()},{cbo_days[1].Text.Trim()}',";
			Query2 = $"{Query2}0,0 ) ";

			DbCommand TempCommand_3 = null;
			TempCommand_3 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
			UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_3);
			TempCommand_3.CommandText = Query2;
			UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_3);
			TempCommand_3.ExecuteNonQuery();


			frm_edit_class.Visible = false;
			create_class_page();




		}

		private void cmd_Clear_Company_Record_Locks_Click(Object eventSender, EventArgs eventArgs)
		{

			string Query = "delete from Company_Lock ";
			DbCommand TempCommand = null;
			TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
			UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
			TempCommand.CommandText = Query;
			UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
			TempCommand.ExecuteNonQuery();
			Count_Company_Locked_Records();

		}

		private void cmd_Clear_Contact_Record_locks_Click(Object eventSender, EventArgs eventArgs)
		{

			string Query = "delete from Contact_Lock ";
			DbCommand TempCommand = null;
			TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
			UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
			TempCommand.CommandText = Query;
			UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
			TempCommand.ExecuteNonQuery();
			Count_Contact_Locked_Records();
		}

		private void cmd_Clear_Aircraft_Record_Locks_Click(Object eventSender, EventArgs eventArgs)
		{

			string Query = "delete from Aircraft_Lock";
			DbCommand TempCommand = null;
			TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
			UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
			TempCommand.CommandText = Query;
			UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
			TempCommand.ExecuteNonQuery();
			Count_Aircraft_Locked_Records();

		}

		private void cmd_delete_Click(Object eventSender, EventArgs eventArgs)
		{
			string SQL = "";
			int temp_id = 0;

			DialogResult temp_response = MessageBox.Show("Are You Sure You Want To Delete This Record?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo);


			if (temp_response == System.Windows.Forms.DialogResult.Yes)
			{
				if (lbl_cef_id.Text.Trim() != "")
				{
					temp_id = Convert.ToInt32(Double.Parse(lbl_cef_id.Text));
				}
				else
				{
					temp_id = 0;
				}

				if (temp_id > 0)
				{
					SQL = $"Delete from Custom_Export_Fields where cef_id = {temp_id.ToString()} ";

					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = SQL;
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();
				}

				FillCustomFieldList();

			}
			else
			{
			}


		}

		private void cmd_Delete_JC_Click(Object eventSender, EventArgs eventArgs)
		{

			try
			{

				string SQL = "";

				SQL = $"DELETE FROM Journal WHERE journ_subcategory_code = '{txt_jcat_category_name.Text}'";
				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = SQL;
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();
				fG_JournalCat.RemoveItem(fG_JournalCat.CurrentRowIndex);
				fG_JournalCat.Refresh();
				MessageBox.Show("Delete Sucessfully Completed", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				pnl_JC_Update_Change.Visible = false;
			}
			catch
			{

				this.Cursor = CursorHelper.CursorDefault;
				modAdminCommon.Report_Error("CommonLookup JC Delete Error: ");
				return;
			}
		}

		private void cmd_Delete_Service_Click(Object eventSender, EventArgs eventArgs)
		{

			string Query = "";
			DialogResult RESP = (DialogResult) 0;
			string M = "";

			try
			{
				grd_Subscriptions.Visible = false;
				lbl_Subscriptions.Visible = false;

				Query = $"DELETE FROM Service WHERE serv_code = '{txt_serv_code.Text.Trim()}'";
				M = $"Service Delete For: {txt_serv_code.Text.Trim()}{"\r"}{"\r"}";
				M = $"{M}Do you wish to perform the delete at this time?";
				RESP = MessageBox.Show(M, "CONFIRM DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (RESP == System.Windows.Forms.DialogResult.Yes)
				{
					//Call LOCAL_DB.Execute(Query, dbSQLPassThrough)
					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = Query;
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();
					FG_Service.RemoveItem(FG_Service.CurrentRowIndex);
					FG_Service.Refresh();
					//Service ("Fill List")
					M = "Delete Successfully Completed";
					MessageBox.Show(M, "DELETE COMPLETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				}
				else
				{
					M = "Delete Cancelled";
					MessageBox.Show(M, "DELETE ABORTED", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				}
				pnl_JC_Update_Change.Visible = false;
			}
			catch
			{
				this.Cursor = CursorHelper.CursorDefault;
				modAdminCommon.Report_Error("CommonLookup Service Delete Error: ");
				pnl_JC_Update_Change.Visible = false;
				return;
			}

		}

		private void cmd_Delete_User_Click(Object eventSender, EventArgs eventArgs)
		{

			string Query = ""; // temp variable for query sql
			string M = ""; // temp variable for string
			DialogResult RESP = (DialogResult) 0; // answer to yes/no question

			try
			{

				Query = $"DELETE FROM [User] WHERE user_id = '{txt_user_id.Text.Trim()}'";
				M = $"User Delete For: {txt_user_id.Text.Trim()}{"\r"}{"\r"}";
				M = $"{M}Do you wish to perform the delete at this time?";
				RESP = MessageBox.Show(M, "Confirm Delete!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (RESP == System.Windows.Forms.DialogResult.Yes)
				{
					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = Query;
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();
					MessageBox.Show("Delete Successfully Completed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					FG_Users.RemoveItem(FG_Users.CurrentRowIndex);
					FG_Users.Refresh();
					Application.DoEvents();
				}
				else
				{
					MessageBox.Show("Delete Cancelled!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}
			}
			catch
			{
				this.Cursor = CursorHelper.CursorDefault;
				modAdminCommon.Report_Error("CommonLookup User Delete Error: ");
				return;
			}

		}

		private void cmd_refresh_Click(Object eventSender, EventArgs eventArgs)
		{
			Fill_FieldGroups();
			Fill_Field_Details();
		}

		private void cmd_run_summary_query_Click(Object eventSender, EventArgs eventArgs)
		{
			Test_Connection_Query("Summary");

			SSTabHelper.SetSelectedIndex(tabstrip_data, 1);
		}

		private void cmd_Save_JC_Click(Object eventSender, EventArgs eventArgs)
		{
			//add or delete Journnal Category Records -- aey 4/8/04

			string Query = "";
			string FLDS = "";
			string VALS = "";
			int nRows = 0;

			try
			{

				if (RecordStat == "Add")
				{

					if ((Strings.Len(txt_jcat_category_name.Text.Trim()) > 0) && (Strings.Len(txt_jcat_category_code.Text.Trim()) > 0) && (Strings.Len(txt_jcat_subcategory_name.Text.Trim()) > 0) && (Strings.Len(txt_jcat_subcategory_code.Text.Trim()) > 0))
					{
						FLDS = "INSERT INTO Journal_Category (";
						VALS = ") VALUES (";
						FLDS = $"{FLDS}jcat_category_name";
						VALS = $"{VALS}'{modAdminCommon.Fix_Quote(txt_jcat_category_name).Trim()}'";
						FLDS = $"{FLDS}, jcat_category_code";
						VALS = $"{VALS}, '{modAdminCommon.Fix_Quote(txt_jcat_category_code).Trim()}'";
						FLDS = $"{FLDS}, jcat_subcategory_name";
						VALS = $"{VALS}, '{modAdminCommon.Fix_Quote(txt_jcat_subcategory_name).Trim()}'";
						FLDS = $"{FLDS}, jcat_subcategory_code";
						VALS = $"{VALS}, '{modAdminCommon.Fix_Quote(txt_jcat_subcategory_code).Trim()}'";


						FLDS = $"{FLDS}, jcat_send_to_website";
						if (send_check.CheckState == CheckState.Checked)
						{
							VALS = $"{VALS}, 'Y'";
						}
						else
						{
							VALS = $"{VALS}, 'N'";
						}

						FLDS = $"{FLDS}, jcat_used_retail_sales_flag";
						if (retail_check.CheckState == CheckState.Checked)
						{
							VALS = $"{VALS}, 'Y'";
						}
						else
						{
							VALS = $"{VALS}, 'N'";
						}




						Query = $"{FLDS}{VALS})";
						DbCommand TempCommand = null;
						TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
						TempCommand.CommandText = Query;
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
						TempCommand.ExecuteNonQuery();
						nRows = fG_JournalCat.RowsCount;
						fG_JournalCat.RowsCount = nRows + 1;
						fG_JournalCat.CurrentRowIndex = fG_JournalCat.RowsCount - 1;

						fG_JournalCat.CurrentColumnIndex = 0;
						fG_JournalCat[fG_JournalCat.CurrentRowIndex, fG_JournalCat.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote($"{txt_jcat_category_name.Text}").Trim();
						fG_JournalCat.CurrentColumnIndex = 1;
						fG_JournalCat[fG_JournalCat.CurrentRowIndex, fG_JournalCat.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote($"{txt_jcat_category_code.Text}").Trim();
						fG_JournalCat.CurrentColumnIndex = 2;
						fG_JournalCat[fG_JournalCat.CurrentRowIndex, fG_JournalCat.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote($"{txt_jcat_subcategory_name.Text}").Trim();
						fG_JournalCat.CurrentColumnIndex = 3;
						fG_JournalCat[fG_JournalCat.CurrentRowIndex, fG_JournalCat.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote($"{txt_jcat_subcategory_code.Text}").Trim();
						fG_JournalCat.Refresh();

						MessageBox.Show("Insert Successfully Completed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					}
				}
				else
				{
					if ((Strings.Len(txt_jcat_category_name.Text.Trim()) > 0) && (Strings.Len(txt_jcat_category_code.Text.Trim()) > 0) && (Strings.Len(txt_jcat_subcategory_name.Text.Trim()) > 0) && (Strings.Len(txt_jcat_subcategory_code.Text.Trim()) > 0))
					{
						Query = $"UPDATE Journal_Category SET jcat_category_name='{modAdminCommon.Fix_Quote(txt_jcat_category_name).Trim()}'";
						Query = $"{Query}, jcat_category_code='{modAdminCommon.Fix_Quote(txt_jcat_category_code).Trim()}'";
						Query = $"{Query}, jcat_subcategory_name='{modAdminCommon.Fix_Quote(txt_jcat_subcategory_name).Trim()}'";
						Query = $"{Query}, jcat_subcategory_code='{modAdminCommon.Fix_Quote(txt_jcat_subcategory_code).Trim()}'";




						Query = $"{Query}, jcat_send_to_website";
						if (send_check.CheckState == CheckState.Checked)
						{
							Query = $"{Query} = 'Y'";
						}
						else
						{
							Query = $"{Query} = 'N'";
						}


						Query = $"{Query}, jcat_used_retail_sales_flag";
						if (retail_check.CheckState == CheckState.Checked)
						{
							Query = $"{Query} = 'Y'";
						}
						else
						{
							Query = $"{Query} = 'N'";
						}


						Query = $"{Query} WHERE jcat_category_code='{modAdminCommon.Fix_Quote(txt_jcat_category_code).Trim()}'";
						Query = $"{Query}  AND jcat_subcategory_code='{modAdminCommon.Fix_Quote(txt_jcat_subcategory_code).Trim()}'";
						fG_JournalCat.CurrentColumnIndex = 0;
						fG_JournalCat[fG_JournalCat.CurrentRowIndex, fG_JournalCat.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote($"{txt_jcat_category_code.Text}").Trim();
						fG_JournalCat.CurrentColumnIndex = 1;
						fG_JournalCat[fG_JournalCat.CurrentRowIndex, fG_JournalCat.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote($"{txt_jcat_category_code.Text}").Trim();
						fG_JournalCat.CurrentColumnIndex = 2;
						fG_JournalCat[fG_JournalCat.CurrentRowIndex, fG_JournalCat.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote($"{txt_jcat_subcategory_name.Text}").Trim();
						fG_JournalCat.CurrentColumnIndex = 3; // SEND TO EVO
						if (send_check.CheckState == CheckState.Checked)
						{
							fG_JournalCat[fG_JournalCat.CurrentRowIndex, fG_JournalCat.CurrentColumnIndex].Value = "Y";
						}
						else
						{
							fG_JournalCat[fG_JournalCat.CurrentRowIndex, fG_JournalCat.CurrentColumnIndex].Value = "N";
						}
						fG_JournalCat.CurrentColumnIndex = 4; // retail sales
						if (retail_check.CheckState == CheckState.Checked)
						{
							fG_JournalCat[fG_JournalCat.CurrentRowIndex, fG_JournalCat.CurrentColumnIndex].Value = "Y";
						}
						else
						{
							fG_JournalCat[fG_JournalCat.CurrentRowIndex, fG_JournalCat.CurrentColumnIndex].Value = "N";
						}

						MessageBox.Show("Update Successfully Completed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						//Call Update_Click
					}

				}

				fG_JournalCat.Refresh();
				Application.DoEvents();
				pnl_JC_Update_Change.Visible = false;
			}
			catch
			{
				this.Cursor = CursorHelper.CursorDefault;
				pnl_JC_Update_Change.Visible = false;
				modAdminCommon.Report_Error("CommonLookup JC Save Error: ");
				return;
			}

		}

		//UPGRADE_NOTE: (7001) The following declaration (InsertJournalNote_AC) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void InsertJournalNote_AC(string strSubject, string desc_text)
		//{
			//
			//string strInsert1 = "";
			//System.DateTime dtSystemDateTime = DateTime.FromOADate(0);
			//
			//try
			//{
				//
				//if (strSubject != "")
				//{
					//
					//dtSystemDateTime = DateTime.Parse(modAdminCommon.GetSystemDateTime());
					//
					//strInsert1 = "INSERT INTO Journal ( journ_date,  journ_subcategory_code, journ_subject, ";
					//strInsert1 = $"{strInsert1}journ_description, journ_ac_id,  journ_comp_id, journ_contact_id, ";
					//strInsert1 = $"{strInsert1}journ_user_id, journ_entry_date, journ_entry_time, journ_account_id, ";
					//strInsert1 = $"{strInsert1}journ_prior_account_id, journ_status, journ_customer_note, journ_action_date ";
					//
					//strInsert1 = $"{strInsert1}) VALUES ('{DateTime.Now.ToString("MM/dd/yyyy")}', ";
					//strInsert1 = $"{strInsert1}'RN', '{($"{strSubject} ").Trim()}', ";
					//strInsert1 = $"{strInsert1}'{desc_text.Trim()}', ";
					//strInsert1 = $"{strInsert1}0,  0, 0, ";
					//strInsert1 = $"{strInsert1}'{modAdminCommon.gbl_User_ID}', ";
					//strInsert1 = $"{strInsert1}'{dtSystemDateTime.ToString("MM/dd/yyyy")}', ";
					//strInsert1 = $"{strInsert1}'{dtSystemDateTime.ToString("HH:mm:ss")}', ";
					//strInsert1 = $"{strInsert1}'{modAdminCommon.gbl_Account_ID}', ";
					//strInsert1 = $"{strInsert1}'',  'A', '', ";
					//strInsert1 = $"{strInsert1}'{DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}')";
					//
					//DbCommand TempCommand = null;
					//TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					//UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					//TempCommand.CommandText = strInsert1;
					////UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					////UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					//TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
					//UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					//TempCommand.ExecuteNonQuery();
					//
				//} // If strSubject <> "" Then
			//}
			//catch (System.Exception excep)
			//{
				//
				//modAdminCommon.Record_Error("InsertJournalNote_AC_Error: ", excep.Message);
			//}
			//
		//} // InsertJournalNote



		private void cmd_Save_Service_Click(Object eventSender, EventArgs eventArgs)
		{
			//Add or Update service records

			string Query = "";
			int RESP = 0;
			string M = "";
			string FLDS = "";
			string VALS = "";

			switch(RecordStat)
			{
				case "Add" : 
					Query = $"SELECT * FROM Service WHERE serv_code = '{txt_serv_code.Text}'"; 
					if (modAdminCommon.Exist(Query))
					{
						M = $"Service '{txt_serv_code.Text}'";
						M = $"{M}', currently used in the Service Table - ADD CANCELLED.";
						MessageBox.Show(M, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					}
					else
					{

						if ((Strings.Len(txt_serv_code.Text.Trim()) > 0) && (Strings.Len(txt_serv_name.Text.Trim()) > 0))
						{
							FG_Service.RowsCount++;
							FG_Service.CurrentRowIndex = FG_Service.RowsCount - 1;

							FLDS = "INSERT INTO Service (";
							VALS = ") VALUES (";
							FLDS = $"{FLDS}serv_code";
							VALS = $"{VALS}'{txt_serv_code.Text.Trim()}'";
							FLDS = $"{FLDS}, serv_name";
							VALS = $"{VALS}, '{modAdminCommon.Fix_Quote(txt_serv_name).Trim()}'";

							FLDS = $"{FLDS}, serv_evolution_flag";
							if (chk_service[0].CheckState == CheckState.Checked)
							{
								VALS = $"{VALS}, 'Y'";
							}
							else
							{
								VALS = $"{VALS}, 'N'";
							}

							FLDS = $"{FLDS}, serv_api_flag";
							if (chk_service[1].CheckState == CheckState.Checked)
							{
								VALS = $"{VALS}, 'Y'";
							}
							else
							{
								VALS = $"{VALS}, 'N'";
							}

							FLDS = $"{FLDS}, serv_bi_flag";
							if (chk_service[2].CheckState == CheckState.Checked)
							{
								VALS = $"{VALS}, 'Y'";
							}
							else
							{
								VALS = $"{VALS}, 'N'";
							}

							FLDS = $"{FLDS}, serv_salesforce_flag";
							if (chk_service[3].CheckState == CheckState.Checked)
							{
								VALS = $"{VALS}, 'Y'";
							}
							else
							{
								VALS = $"{VALS}, 'N'";
							}

							FLDS = $"{FLDS}, serv_jetnetiq_flag";
							if (chk_service[4].CheckState == CheckState.Checked)
							{
								VALS = $"{VALS}, 'Y'";
							}
							else
							{
								VALS = $"{VALS}, 'N'";
							}

							FLDS = $"{FLDS}, serv_customrep_flag";
							if (chk_service[5].CheckState == CheckState.Checked)
							{
								VALS = $"{VALS}, 'Y'";
							}
							else
							{
								VALS = $"{VALS}, 'N'";
							}



							FG_Service.CurrentColumnIndex = 0;
							FG_Service[FG_Service.CurrentRowIndex, FG_Service.CurrentColumnIndex].Value = txt_serv_code;
							FG_Service.CurrentColumnIndex = 1;
							FG_Service[FG_Service.CurrentRowIndex, FG_Service.CurrentColumnIndex].Value = txt_serv_name;

							if (Strings.Len(txt_serv_description.Text.Trim()) > 0)
							{
								FLDS = $"{FLDS}, serv_description";
								VALS = $"{VALS}, '{modAdminCommon.Fix_Quote(txt_serv_description).Trim()}'";
								FG_Service.CurrentColumnIndex = 2;
								FG_Service[FG_Service.CurrentRowIndex, FG_Service.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote($"{txt_serv_description.Text}").Trim();
							}
							if (Strings.Len(lbl_serv_entry_date.Text.Trim()) > 0)
							{
								FLDS = $"{FLDS}, serv_entry_date";
								VALS = $"{VALS}, '{lbl_serv_entry_date.Text.Trim()}'";
								FG_Service.CurrentColumnIndex = 3;
								FG_Service[FG_Service.CurrentRowIndex, FG_Service.CurrentColumnIndex].Value = ($"{lbl_serv_entry_date.Text}").Trim();
							}
							if (Strings.Len(lbl_serv_entry_user_id.Text.Trim()) > 0)
							{
								FLDS = $"{FLDS}, serv_entry_user_id";
								VALS = $"{VALS}, '{lbl_serv_entry_user_id.Text.Trim()}'";
								FG_Service.CurrentColumnIndex = 4;
								FG_Service[FG_Service.CurrentRowIndex, FG_Service.CurrentColumnIndex].Value = ($"{lbl_serv_entry_user_id.Text}").Trim();
							}
							Query = $"{FLDS}{VALS})";

							DbCommand TempCommand = null;
							TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
							TempCommand.CommandText = Query;
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
							TempCommand.ExecuteNonQuery();
							MessageBox.Show("Insert Successfully Completed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
							//Service ("Fill List")
						}
						else
						{
							MessageBox.Show("Code and Name fields must be supplied.", "ADD ABORTED", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					} 
					 
					break;
				case "Update" : 
					if ((Strings.Len(txt_serv_code.Text.Trim()) > 0) && (Strings.Len(txt_serv_name.Text.Trim()) > 0))
					{
						Query = $"UPDATE Service SET serv_code = '{modAdminCommon.Fix_Quote(txt_serv_code).Trim()}'";
						Query = $"{Query}, serv_name = '{modAdminCommon.Fix_Quote(txt_serv_name).Trim()}'";
						FG_Service.CurrentColumnIndex = 0;
						FG_Service[FG_Service.CurrentRowIndex, FG_Service.CurrentColumnIndex].Value = txt_serv_code;
						FG_Service.CurrentColumnIndex = 1;
						FG_Service[FG_Service.CurrentRowIndex, FG_Service.CurrentColumnIndex].Value = txt_serv_name;
						FG_Service.CurrentColumnIndex = 2;
						FG_Service[FG_Service.CurrentRowIndex, FG_Service.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote($"{txt_serv_description.Text}").Trim();
						FG_Service.CurrentColumnIndex = 3;
						FG_Service[FG_Service.CurrentRowIndex, FG_Service.CurrentColumnIndex].Value = ($"{lbl_serv_entry_date.Text}").Trim();
						FG_Service.CurrentColumnIndex = 4;
						FG_Service[FG_Service.CurrentRowIndex, FG_Service.CurrentColumnIndex].Value = ($"{lbl_serv_entry_user_id.Text}").Trim();

						if (Strings.Len(txt_serv_description.Text.Trim()) > 0)
						{
							Query = $"{Query}, serv_description = '{modAdminCommon.Fix_Quote(txt_serv_description).Trim()}'";
						}
						else
						{
							Query = $"{Query}, serv_description = NULL";
						}
						lbl_serv_upd_date.Text = DateTime.Today.ToString("MM-dd-yyyy");
						lbl_serv_upd_user_id.Text = modAdminCommon.gbl_User_ID;
						FG_Service.CurrentColumnIndex = 5;
						FG_Service[FG_Service.CurrentRowIndex, FG_Service.CurrentColumnIndex].Value = DateTime.Today.ToString("MM-dd-yyyy");
						FG_Service.CurrentColumnIndex = 6;
						FG_Service[FG_Service.CurrentRowIndex, FG_Service.CurrentColumnIndex].Value = modAdminCommon.gbl_User_ID;

						Query = $"{Query}, serv_upd_date = '{DateTime.Today.ToString("MM-dd-yyyy")}' , serv_upd_user_id = '{modAdminCommon.gbl_User_ID}'";


						// added in MSW - 7/18/22
						if (chk_service[0].CheckState == CheckState.Checked)
						{
							Query = $"{Query}, serv_evolution_flag = 'Y' ";
						}
						else
						{
							Query = $"{Query}, serv_evolution_flag = 'N' ";
						}

						if (chk_service[1].CheckState == CheckState.Checked)
						{
							Query = $"{Query}, serv_api_flag = 'Y' ";
						}
						else
						{
							Query = $"{Query}, serv_api_flag = 'N' ";
						}

						if (chk_service[2].CheckState == CheckState.Checked)
						{
							Query = $"{Query}, serv_bi_flag = 'Y' ";
						}
						else
						{
							Query = $"{Query}, serv_bi_flag = 'N' ";
						}

						if (chk_service[3].CheckState == CheckState.Checked)
						{
							Query = $"{Query}, serv_salesforce_flag = 'Y' ";
						}
						else
						{
							Query = $"{Query}, serv_salesforce_flag = 'N' ";
						}

						if (chk_service[4].CheckState == CheckState.Checked)
						{
							Query = $"{Query}, serv_jetnetiq_flag = 'Y' ";
						}
						else
						{
							Query = $"{Query}, serv_jetnetiq_flag = 'N' ";
						}

						if (chk_service[5].CheckState == CheckState.Checked)
						{
							Query = $"{Query}, serv_customrep_flag = 'Y' ";
						}
						else
						{
							Query = $"{Query}, serv_customrep_flag = 'N' ";
						}


						Query = $"{Query} WHERE serv_code = '{txt_serv_code.Text.Trim()}'";

						//Call LOCAL_DB.Execute(Query, dbSQLPassThrough)
						DbCommand TempCommand_2 = null;
						TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
						TempCommand_2.CommandText = Query;
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
						TempCommand_2.ExecuteNonQuery();
						M = "Update Successfully Completed.";
						MessageBox.Show(M, "UPDATE COMPLETE", MessageBoxButtons.OK, MessageBoxIcon.Information);
						//Service ("Fill List")
					}
					else
					{
						M = "Codeand Name fields must be entered.";
						MessageBox.Show(M, "UPDATE ABORTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
					} 
					break;
			}

			pnl_JC_Update_Change.Visible = false;
			FG_Service.Refresh();
			Application.DoEvents();


		}

		private void cmd_Save_User_Click(Object eventSender, EventArgs eventArgs)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strDelete1 = "";
			string strQuery1 = "";

			string strUserId = "";
			bool bContinue = false;
			string strFlagChged = "";

			try
			{

				if ((($"{txt_user_id.Text} ").Trim() != "") && (($"{txt_user_first_name.Text} ").Trim() != "") && (($"{txt_user_last_name.Text} ").Trim() != ""))
				{

					strUserId = ($"{txt_user_id.Text} ").Trim();

					strQuery1 = $"SELECT * FROM [User] WHERE (user_id = '{strUserId}') ";

					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);

					bContinue = false;
					strFlagChged = "";

					if (RecordStat == "Add")
					{
						if ((rstRec1.BOF) && (rstRec1.EOF))
						{
							rstRec1.AddNew();
							bContinue = true;
						}
						else
						{
							MessageBox.Show("User Already Exists", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					}

					if (RecordStat == "Update")
					{
						if ((!rstRec1.BOF) && (!rstRec1.EOF))
						{
							bContinue = true;
						}
						else
						{
							MessageBox.Show("User Does NOT Exists", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					}

					if (bContinue)
					{

						rstRec1["user_id"] = strUserId.ToLower();
						rstRec1["user_password"] = ($"{txt_user_password.Text} ").Trim();
						rstRec1["user_last_name"] = modAdminCommon.Fix_Quote(($"{txt_user_last_name.Text} ").Trim());
						rstRec1["user_first_name"] = modAdminCommon.Fix_Quote(($"{txt_user_first_name.Text} ").Trim());
						rstRec1["user_middle_initial"] = ($"{txt_user_middle_initial.Text} ").Trim();
						rstRec1["user_phone_no"] = ($"{txt_user_phone_no.Text} ").Trim();
						rstRec1["user_phone_no_ext"] = ($"{txt_user_phone_no_ext.Text} ").Trim();

						// 04/19/2018 - By David D. Cruger; Added
						rstRec1["user_cell_no"] = ($"{txtUserCellNbr.Text} ").Trim();

						rstRec1["user_type"] = ($"{cbo_user_type.Text} ").Trim();
						rstRec1["user_entered_by"] = modAdminCommon.gbl_User_ID;
						rstRec1["user_entry_date"] = DateTime.Now;
						rstRec1["user_default_account_id"] = ($"{txt_user_default_account_id.Text} ").Trim();
						rstRec1["user_browser_type"] = default_browser.Text.Substring(0, Math.Min(1, default_browser.Text.Length));
						rstRec1["user_description"] = ($"{txt_user_description.Text} ").Trim();

						if (($"{txt_user_comp_id.Text} ").Trim() != "")
						{
							if (Information.IsNumeric(txt_user_comp_id.Text))
							{
								rstRec1["user_comp_id"] = Convert.ToInt32(Double.Parse(txt_user_comp_id.Text));
							}
						}

						if (($"{txt_user_contact_id.Text} ").Trim() != "")
						{
							if (Information.IsNumeric(txt_user_contact_id.Text))
							{
								rstRec1["user_contact_id"] = Convert.ToInt32(Double.Parse(txt_user_contact_id.Text));
							}
						}

						if (chkAutoCallback.CheckState == CheckState.Checked)
						{
							rstRec1["user_auto_callback"] = "Y";
						}
						else
						{
							rstRec1["user_auto_callback"] = "N";
						}

						if (($"{txt_user_marketing_subids_allowed.Text} ").Trim() == "")
						{
							rstRec1["user_marketing_subids_allowed"] = "NONE";
						}
						else
						{
							rstRec1["user_marketing_subids_allowed"] = ($"{txt_user_marketing_subids_allowed.Text} ").Trim();
						}

						if (cmbDefaultAirframe.Text.StartsWith("N", StringComparison.Ordinal))
						{
							rstRec1["user_default_airframe"] = "A";
						}
						else
						{
							rstRec1["user_default_airframe"] = cmbDefaultAirframe.Text.Substring(0, Math.Min(1, cmbDefaultAirframe.Text.Length));
						}

						if (chk_run_account_management_reports_flag.CheckState == CheckState.Checked)
						{
							if (Convert.ToString(rstRec1["user_run_account_management_reports_flag"]) == "N")
							{
								strFlagChged = $"{strFlagChged}Acct Mgt Reports Chged From No to Yes, ";
							}
							rstRec1["user_run_account_management_reports_flag"] = "Y";
						}
						else
						{
							if (Convert.ToString(rstRec1["user_run_account_management_reports_flag"]) == "Y")
							{
								strFlagChged = $"{strFlagChged}Acct Mgt Reports Chged From Yes to No, ";
							}
							rstRec1["user_run_account_management_reports_flag"] = "N";
						}

						if (chk_remove_journal_subject_flag.CheckState == CheckState.Checked)
						{
							if (Convert.ToString(rstRec1["user_remove_journal_subject_flag"]) == "N")
							{
								strFlagChged = $"{strFlagChged}Remove Journal Subject Chged From No to Yes, ";
							}
							rstRec1["user_remove_journal_subject_flag"] = "Y";
						}
						else
						{
							if (Convert.ToString(rstRec1["user_remove_journal_subject_flag"]) == "Y")
							{
								strFlagChged = $"{strFlagChged}Remove Journal Subject Chged From Yes to No, ";
							}
							rstRec1["user_remove_journal_subject_flag"] = "N";
						}

						if (chk_user_process_pubs_flag.CheckState == CheckState.Checked)
						{
							rstRec1["user_process_pubs_flag"] = "Y";
						}
						else
						{
							rstRec1["user_process_pubs_flag"] = "N";
						}

						if (chk_user_process_canadian_reg_flag.CheckState == CheckState.Checked)
						{
							rstRec1["user_process_canadian_reg_flag"] = "Y";
						}
						else
						{
							rstRec1["user_process_canadian_reg_flag"] = "N";
						}

						if (chk_user_logged_in.CheckState == CheckState.Checked)
						{
							rstRec1["user_logged_in"] = "Y";
						}
						else
						{
							rstRec1["user_logged_in"] = "N";
						}

						if (chkUserMonitorActivityFlag.CheckState == CheckState.Checked)
						{
							if (Convert.ToString(rstRec1["user_monitor_activity_flag"]) == "N")
							{
								strFlagChged = $"{strFlagChged}Monitor Activity Chged From No to Yes, ";
							}
							rstRec1["user_monitor_activity_flag"] = "Y";
						}
						else
						{
							if (Convert.ToString(rstRec1["user_monitor_activity_flag"]) == "Y")
							{
								strFlagChged = $"{strFlagChged}Monitor Activity Chged From Yes to No, ";
							}
							rstRec1["user_monitor_activity_flag"] = "N";
						}

						if (chk_user_process_ntsb_reports_flag.CheckState == CheckState.Checked)
						{
							rstRec1["user_process_ntsb_reports_flag"] = "Y";
						}
						else
						{
							rstRec1["user_process_ntsb_reports_flag"] = "N";
						}

						rstRec1["user_email_address"] = ($"{txt_user_email_address.Text} ").Trim();

						if (chk_user_edit_subscriptions.CheckState == CheckState.Checked)
						{
							if (Convert.ToString(rstRec1["user_edit_subscriptions"]) == "N")
							{
								strFlagChged = $"{strFlagChged}Edit Subscriptions Chged From No to Yes, ";
							}
							rstRec1["user_edit_subscriptions"] = "Y";
						}
						else
						{
							if (Convert.ToString(rstRec1["user_edit_subscriptions"]) == "Y")
							{
								strFlagChged = $"{strFlagChged}Edit Subscriptions Chged From Yes to No, ";
							}
							rstRec1["user_edit_subscriptions"] = "N";
						}

						if (chk_user_open_multiple_homebase.CheckState == CheckState.Checked)
						{
							rstRec1["user_open_multiple_homebase"] = "Y";
						}
						else
						{
							rstRec1["user_open_multiple_homebase"] = "N";
						}

						if (chk_user_subscription_contract_amount.CheckState == CheckState.Checked)
						{
							if (Convert.ToString(rstRec1["user_subscription_contract_amount"]) == "N")
							{
								strFlagChged = $"{strFlagChged}View Contract Amts Chged From No to Yes, ";
							}
							rstRec1["user_subscription_contract_amount"] = "Y";
						}
						else
						{
							if (Convert.ToString(rstRec1["user_subscription_contract_amount"]) == "Y")
							{
								strFlagChged = $"{strFlagChged}View Contract Amts Chged From Yes to No, ";
							}
							rstRec1["user_subscription_contract_amount"] = "N";
						}

						if (chk_user_manage_accounts_flags.CheckState == CheckState.Checked)
						{
							if (Convert.ToString(rstRec1["user_manage_accounts_flag"]) == "N")
							{
								strFlagChged = $"{strFlagChged}Mgt Accts Chged From No to Yes, ";
							}
							rstRec1["user_manage_accounts_flag"] = "Y";
						}
						else
						{
							if (Convert.ToString(rstRec1["user_manage_accounts_flag"]) == "Y")
							{
								strFlagChged = $"{strFlagChged}Mgt Accts Chged From Yes to No, ";
							}
							rstRec1["user_manage_accounts_flag"] = "N";
						}

						// 06/18/2008 - By David D. Cruger; Added
						if (chk_user_delete_attached_ac_specs_flag.CheckState == CheckState.Checked)
						{
							if (Convert.ToString(rstRec1["user_delete_attached_ac_specs_flag"]) == "N")
							{
								strFlagChged = $"{strFlagChged}Del Attached A/C Spec Chged From No to Yes, ";
							}
							rstRec1["user_delete_attached_ac_specs_flag"] = "Y";
						}
						else
						{
							if (Convert.ToString(rstRec1["user_delete_attached_ac_specs_flag"]) == "Y")
							{
								strFlagChged = $"{strFlagChged}Del Attached A/C Spec Chged From Yes to No, ";
							}
							rstRec1["user_delete_attached_ac_specs_flag"] = "N";
						}

						// 06/24/2008 - By David D. Cruger; Added - Per LF
						if (chk_user_hide_events_flag.CheckState == CheckState.Checked)
						{
							if (Convert.ToString(rstRec1["user_hide_events_flag"]) == "N")
							{
								strFlagChged = $"{strFlagChged}Hide Event Chged From No to Yes, ";
							}
							rstRec1["user_hide_events_flag"] = "Y";
						}
						else
						{
							if (Convert.ToString(rstRec1["user_hide_events_flag"]) == "Y")
							{
								strFlagChged = $"{strFlagChged}Hide Event Chged From Yes to No, ";
							}
							rstRec1["user_hide_events_flag"] = "N";
						}

						// 10/10/2017 - By David D. Cruger; Added
						if (chk_user_team_leader_flag.CheckState == CheckState.Checked)
						{
							if (Convert.ToString(rstRec1["user_team_leader_flag"]) == "N")
							{
								strFlagChged = $"{strFlagChged}Team Leader Chged From No to Yes, ";
							}
							rstRec1["user_team_leader_flag"] = "Y";
						}
						else
						{
							if (Convert.ToString(rstRec1["user_team_leader_flag"]) == "Y")
							{
								strFlagChged = $"{strFlagChged}Team Leader Chged From Yes to No, ";
							}
							rstRec1["user_team_leader_flag"] = "N";
						}

						// 11/03/2017 - By David D. Cruger; Added
						if (chk_user_report_flag.CheckState == CheckState.Checked)
						{
							if (Convert.ToString(rstRec1["user_user_report_flag"]) == "N")
							{
								strFlagChged = $"{strFlagChged}User Report Chged From No to Yes, ";
							}
							rstRec1["user_user_report_flag"] = "Y";
						}
						else
						{
							if (Convert.ToString(rstRec1["user_user_report_flag"]) == "Y")
							{
								strFlagChged = $"{strFlagChged}User Report Chged From Yes to No, ";
							}
							rstRec1["user_user_report_flag"] = "N";
						}

						rstRec1.UpdateBatch();

					} // If (bContinue = True) Then

					rstRec1.Close();


					if (strFlagChged != "")
					{
						strFlagChged = strFlagChged.Substring(0, Math.Min(Strings.Len(strFlagChged) - 2, strFlagChged.Length)); // Remove Last ,Space
						modAdminCommon.Record_Event("User Table", strFlagChged, 0, 0, 0, false, 0, 0);
					}

					modAdminCommon.Table_Action_Log("[User]");

					Load_User_Name_Grid();

				} // If (Trim(txt_user_id.Text & " ") <> "") And (Trim(txt_user_first_name.Text & " ") <> "") And (Trim(txt_user_last_name.Text & " ") <>"" Then

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				MessageBox.Show($"cmd_Save_User_Click_Error: {excep.Message}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		} // cmd_Save_User_Click

		private void cmd_sort_down_Click(Object eventSender, EventArgs eventArgs) => move_sort("higher");


		private void cmd_sort_up_Click(Object eventSender, EventArgs eventArgs) => move_sort("lower");

		private void cmdAccountRepCancel_Click(Object eventSender, EventArgs eventArgs) => pnlAcctRepUpdateChange.Visible = false;


		private void cmdAccountRepDelete_Click(Object eventSender, EventArgs eventArgs)
		{


			string Query = $"DELETE FROM Account_Rep WHERE accrep_account_id='{txt_accrep_account_id.Text.Trim()}'";
			string M = $"Account Rep Delete For: {txt_accrep_account_id.Text.Trim()}{"\r"}{"\r"}";
			M = $"{M}Do you wish to perform the delete at this time?";
			DialogResult RESP = MessageBox.Show(M, "Confirm Delete!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (RESP == System.Windows.Forms.DialogResult.Yes)
			{
				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = Query;
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();
				FG_AccountRep.RemoveItem(FG_AccountRep.CurrentRowIndex);
				FG_AccountRep.Refresh();

				MessageBox.Show("Delete Successfully Completed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
			else
			{
				MessageBox.Show("Delete Cancelled!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}

		private void cmdAcctRepSave_Click(Object eventSender, EventArgs eventArgs)
		{

			string Query = "";
			string FLDS = "";
			string VALS = "";
			string M = "";

			switch(RecordStat)
			{
				case "Add" : 
					Query = $"SELECT *  FROM Account_Rep WHERE accrep_account_id = '{txt_accrep_account_id.Text}'"; 
					if (modAdminCommon.Exist(Query))
					{
						M = $"Account Rep '{txt_accrep_account_id.Text}'";
						M = $"{M}', currently used in the Account_Rep Table - ADD CANCELLED.";
						MessageBox.Show(M, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					}
					else
					{

						FG_AccountRep.RowsCount++;
						FG_AccountRep.CurrentRowIndex = FG_AccountRep.RowsCount - 1;

						if (Strings.Len(txt_accrep_account_id.Text.Trim()) > 0)
						{
							FLDS = "INSERT INTO Account_Rep (";
							VALS = ") VALUES (";
							FLDS = $"{FLDS}accrep_account_id";
							VALS = $"{VALS}'{modAdminCommon.Fix_Quote(txt_accrep_account_id).Trim()}'";
							FLDS = $"{FLDS}, accrep_account_type";
							VALS = $"{VALS}, '{modAdminCommon.Fix_Quote(txt_accrep_account_type).Trim()}'";
							FLDS = $"{FLDS}, accrep_description";
							VALS = $"{VALS}, '{modAdminCommon.Fix_Quote(txt_accrep_description).Trim()}'";
							FLDS = $"{FLDS}, accrep_user_id";
							VALS = $"{VALS}, '{modAdminCommon.Fix_Quote(txt_accrep_user_id).Trim()}'";
							Query = $"{FLDS}{VALS})";
							//Call LOCAL_DB.Execute(Query, dbSQLPassThrough)
							DbCommand TempCommand = null;
							TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
							TempCommand.CommandText = Query;
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
							TempCommand.ExecuteNonQuery();
							MessageBox.Show("Insert Successfully Completed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
							//Account_Rep ("Fill List")
						}
					} 
					break;
				case "Update" : 
					if (Strings.Len(txt_accrep_account_id.Text.Trim()) > 0)
					{
						Query = "UPDATE Account_Rep SET ";
						Query = $"{Query}accrep_account_type='{modAdminCommon.Fix_Quote(txt_accrep_account_type).Trim()}'";
						Query = $"{Query}, accrep_description='{modAdminCommon.Fix_Quote(txt_accrep_description).Trim()}'";
						Query = $"{Query}, accrep_user_id='{modAdminCommon.Fix_Quote(txt_accrep_user_id).Trim()}'";
						Query = $"{Query} WHERE accrep_account_id='{modAdminCommon.Fix_Quote(txt_accrep_account_id).Trim()}'";
						//Call LOCAL_DB.Execute(Query, dbSQLPassThrough)
						DbCommand TempCommand_2 = null;
						TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
						TempCommand_2.CommandText = Query;
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
						TempCommand_2.ExecuteNonQuery();
						MessageBox.Show("Update Successfully Completed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					} 
					break;
			}

			modAdminCommon.Table_Action_Log("Account_Rep");

			FG_AccountRep.Refresh();

		}

		private void cmdAddAccountRep_Click(Object eventSender, EventArgs eventArgs)
		{
			pnlAcctRepUpdateChange.Visible = true;
			RecordStat = "Add";
			txt_accrep_account_id.Enabled = true;
			txt_accrep_account_id.Text = "";
			txt_accrep_account_type.Text = "";
			txt_accrep_description.Text = "";
			txt_accrep_user_id.Text = "";
			cmdAcctRepSave.Focus();

		}

		//UPGRADE_NOTE: (7001) The following declaration (Combo1_Change) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void Combo1_Change()
		//{
			//
			//
			//
		//}

		//UPGRADE_NOTE: (7001) The following declaration (Combo3_Change) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void Combo3_Change()
		//{
			//
		//}

		//UPGRADE_NOTE: (7001) The following declaration (Combo2_Change) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void Combo2_Change()
		//{
			//
		//}

		private void cmdCheckCompOrphanPhoneNbrs_Click(Object eventSender, EventArgs eventArgs)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();

			cmdCheckCompOrphanPhoneNbrs.Enabled = false;
			cmdRemoveCompOrphanPhoneNbrs.Visible = false;
			lblTotalCompOrphanPhoneNbrs.Visible = true;
			lblTotalCompOrphanPhoneNbrs.Text = "Working";
			Application.DoEvents();

			string strQuery1 = "SELECT COUNT(*) AS TotCnt FROM Phone_Numbers WITH (NOLOCK) ";
			strQuery1 = $"{strQuery1}LEFT OUTER JOIN Company WITH (NOLOCK) ON comp_id = pnum_comp_id AND comp_journ_id = pnum_journ_id ";
			strQuery1 = $"{strQuery1}WHERE (comp_id IS Null) AND (pnum_contact_id = 0) ";

			rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

			if (!rstRec1.BOF && !rstRec1.EOF)
			{
				lblTotalCompOrphanPhoneNbrs.Text = $"Total Records: {StringsHelper.Format(rstRec1["TotCnt"], "#,##0")}";
				if (Convert.ToDouble(rstRec1["TotCnt"]) > 0)
				{
					cmdRemoveCompOrphanPhoneNbrs.Visible = true;
				}
			}
			else
			{
				lblTotalCompOrphanPhoneNbrs.Text = "Nothing Returned";
			}

			rstRec1.Close();

			cmdCheckCompOrphanPhoneNbrs.Enabled = true;

			rstRec1 = null;

		} // cmdCheckCompOrphanPhoneNbrs_Click

		private void cmdCheckContactOrphanPhoneNbrs_Click(Object eventSender, EventArgs eventArgs)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();

			cmdCheckContactOrphanPhoneNbrs.Enabled = false;
			cmdRemoveContactOrphanPhoneNbrs.Visible = false;
			lblTotalContactOrphanPhoneNbrs.Visible = true;
			lblTotalContactOrphanPhoneNbrs.Text = "Working";
			Application.DoEvents();

			string strQuery1 = "SELECT COUNT(*) AS TotCnt FROM Phone_Numbers WITH (NOLOCK) ";
			strQuery1 = $"{strQuery1}LEFT OUTER JOIN Contact WITH (NOLOCK) ON contact_id = pnum_contact_id AND contact_comp_id = pnum_comp_id AND contact_journ_id = pnum_journ_id ";
			strQuery1 = $"{strQuery1}WHERE (contact_id IS Null) AND (pnum_contact_id > 0) ";

			rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

			if (!rstRec1.BOF && !rstRec1.EOF)
			{
				lblTotalContactOrphanPhoneNbrs.Text = $"Total Records: {StringsHelper.Format(rstRec1["TotCnt"], "#,##0")}";
				if (Convert.ToDouble(rstRec1["TotCnt"]) > 0)
				{
					cmdRemoveContactOrphanPhoneNbrs.Visible = true;
				}
			}
			else
			{
				lblTotalContactOrphanPhoneNbrs.Text = "Nothing Returned";
			}

			rstRec1.Close();

			cmdCheckContactOrphanPhoneNbrs.Enabled = true;

			rstRec1 = null;

		} // cmdCheckContactOrphanPhoneNbrs_Click

		private void cmdRemoveCompOrphanPhoneNbrs_Click(Object eventSender, EventArgs eventArgs)
		{

			int lCnt1 = 0;

			cmdRemoveCompOrphanPhoneNbrs.Enabled = false;
			lblTotalCompOrphanPhoneNbrs.Text = "Working";
			Application.DoEvents();

			string strDelete1 = "DELETE FROM Phone_Numbers WHERE (pnum_contact_id = 0) ";
			strDelete1 = $"{strDelete1}AND (NOT EXISTS (SELECT NULL FROM Company WITH (NOLOCK) ";
			strDelete1 = $"{strDelete1}                 WHERE (comp_id = pnum_comp_id) ";
			strDelete1 = $"{strDelete1}                 AND (comp_journ_id = pnum_journ_id) ";
			strDelete1 = $"{strDelete1}                 )     ) ";

			DbCommand TempCommand = null;
			TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
			UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
			TempCommand.CommandText = strDelete1;
			//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
			TempCommand.CommandType = (CommandType) (((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()) + ((int) CommandType.Text));
			UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
			lCnt1 = TempCommand.ExecuteNonQuery();

			lblTotalCompOrphanPhoneNbrs.Text = $"Total Company Orphan Phone Nbrs Removed: {StringsHelper.Format(lCnt1, "#,##0")}";

			cmdRemoveCompOrphanPhoneNbrs.Enabled = true;
			cmdRemoveCompOrphanPhoneNbrs.Visible = false;

		} // cmdRemoveCompOrphanPhoneNbrs_Click

		private void cmdRemoveContactOrphanPhoneNbrs_Click(Object eventSender, EventArgs eventArgs)
		{

			int lCnt1 = 0;

			cmdRemoveContactOrphanPhoneNbrs.Enabled = false;
			lblTotalContactOrphanPhoneNbrs.Text = "Working";
			Application.DoEvents();

			string strDelete1 = "DELETE FROM Phone_Numbers WHERE (pnum_contact_id > 0) ";
			strDelete1 = $"{strDelete1}AND (NOT EXISTS (SELECT NULL FROM Contact WITH (NOLOCK) ";
			strDelete1 = $"{strDelete1}                 WHERE (contact_id = pnum_contact_id) ";
			strDelete1 = $"{strDelete1}                 AND (contact_comp_id = pnum_comp_id) ";
			strDelete1 = $"{strDelete1}                 AND (contact_journ_id = pnum_journ_id) ";
			strDelete1 = $"{strDelete1}                 )    ) ";

			DbCommand TempCommand = null;
			TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
			UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
			TempCommand.CommandText = strDelete1;
			//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
			TempCommand.CommandType = (CommandType) (((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()) + ((int) CommandType.Text));
			UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
			lCnt1 = TempCommand.ExecuteNonQuery();

			lblTotalContactOrphanPhoneNbrs.Text = $"Total Contact Orphan Phone Nbrs Removed: {StringsHelper.Format(lCnt1, "#,##0")}";

			cmdRemoveContactOrphanPhoneNbrs.Enabled = true;
			cmdRemoveContactOrphanPhoneNbrs.Visible = false;

		} // cmdRemoveContactOrphanPhoneNbrs_Click

		private void cmdSaveTeam_Click(Object eventSender, EventArgs eventArgs)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strUserId = "";
			string strReport = "";
			string strTeam = "";
			string strMsg = "";

			try
			{

				cmdSaveTeam.Enabled = false;

				strUserId = txt_user_id.Text;
				strReport = cmbTeamReports.Text;
				strTeam = txtUserTeamLeaderTeam.Text;

				if (strUserId != "" && strReport != "")
				{

					strQuery1 = $"SELECT * FROM User_Reports WHERE (ur_user_id = '{strUserId}') ";
					strQuery1 = $"{strQuery1}AND (ur_report_name = '{strReport}') ";

					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);

					if (rstRec1.BOF && rstRec1.EOF)
					{
						rstRec1.AddNew();
					}

					rstRec1["ur_report_name"] = strReport;
					rstRec1["ur_user_id"] = strUserId;
					rstRec1["ur_team_leader_team"] = strTeam;
					if (chkTeamLeaderReportActive.CheckState == CheckState.Checked)
					{
						rstRec1["ur_active_flag"] = "Y";
					}
					else
					{
						rstRec1["ur_active_flag"] = "N";
					}
					rstRec1.UpdateBatch();

					strMsg = $"Updated Team Leaders Team For: UserId [{strUserId}]  Report [{strReport}] - Team [{strTeam}]";
					modAdminCommon.Record_Event("User", strMsg, 0, 0, 0, false, 0, 0);

					strMsg = StringsHelper.Replace(strMsg, ": ", $"{Environment.NewLine}{Environment.NewLine}", 1, -1, CompareMethod.Binary);
					strMsg = StringsHelper.Replace(strMsg, " - ", $"{Environment.NewLine}{Environment.NewLine}", 1, -1, CompareMethod.Binary);
					MessageBox.Show(strMsg, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);

				} // If strUserId <> "" And strReport <> "" Then

				cmdSaveTeam.Enabled = true;

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("cmdSaveTeam_Click_Error", excep.Message);
			}

		} // cmdSaveTeam_Click

		private void FG_AccountRep_Click(Object eventSender, EventArgs eventArgs)
		{
			//display row information in panel

			pnlAcctRepUpdateChange.Visible = true;
			RecordStat = "Update";
			txt_accrep_account_id.Enabled = true;
			FG_AccountRep.CurrentColumnIndex = 0;
			txt_accrep_account_id.Text = FG_AccountRep[FG_AccountRep.CurrentRowIndex, FG_AccountRep.CurrentColumnIndex].FormattedValue.ToString();
			FG_AccountRep.CurrentColumnIndex = 1;
			txt_accrep_account_type.Text = FG_AccountRep[FG_AccountRep.CurrentRowIndex, FG_AccountRep.CurrentColumnIndex].FormattedValue.ToString();
			FG_AccountRep.CurrentColumnIndex = 2;
			txt_accrep_description.Text = FG_AccountRep[FG_AccountRep.CurrentRowIndex, FG_AccountRep.CurrentColumnIndex].FormattedValue.ToString();
			FG_AccountRep.CurrentColumnIndex = 3;
			txt_accrep_user_id.Text = FG_AccountRep[FG_AccountRep.CurrentRowIndex, FG_AccountRep.CurrentColumnIndex].FormattedValue.ToString();
			cmdAcctRepSave.Focus();

		}

		private void fG_JournalCat_Click(Object eventSender, EventArgs eventArgs)
		{

			fG_JournalCat.RowSel = fG_JournalCat.CurrentRowIndex;
			fG_JournalCat.HighLight = UpgradeHelpers.HighLightSettings.HighlightNever;

			fG_JournalCat.SelectionMode = DataGridViewSelectionMode.CellSelect;
			fG_JournalCat.Focus();

			fG_JournalCat.CurrentColumnIndex = 0;

			txt_jcat_category_code.Text = fG_JournalCat[fG_JournalCat.CurrentRowIndex, fG_JournalCat.CurrentColumnIndex].FormattedValue.ToString();
			fG_JournalCat.CurrentColumnIndex = 1;
			txt_jcat_subcategory_code.Text = fG_JournalCat[fG_JournalCat.CurrentRowIndex, fG_JournalCat.CurrentColumnIndex].FormattedValue.ToString();
			fG_JournalCat.CurrentColumnIndex = 2;
			txt_jcat_subcategory_name.Text = fG_JournalCat[fG_JournalCat.CurrentRowIndex, fG_JournalCat.CurrentColumnIndex].FormattedValue.ToString();
			fG_JournalCat.CurrentColumnIndex = 3;
			txt_jcat_send_to_website.Text = fG_JournalCat[fG_JournalCat.CurrentRowIndex, fG_JournalCat.CurrentColumnIndex].FormattedValue.ToString();
			fG_JournalCat.CurrentColumnIndex = 4;
			txt_jcat_used_retail_sales_flag.Text = fG_JournalCat[fG_JournalCat.CurrentRowIndex, fG_JournalCat.CurrentColumnIndex].FormattedValue.ToString();
			fG_JournalCat.CurrentColumnIndex = 5;
			txt_jcat_category_name.Text = fG_JournalCat[fG_JournalCat.CurrentRowIndex, fG_JournalCat.CurrentColumnIndex].FormattedValue.ToString();

			if (txt_jcat_send_to_website.Text == "Y")
			{
				send_check.CheckState = CheckState.Checked;
			}
			else
			{
				send_check.CheckState = CheckState.Unchecked;
			}

			if (txt_jcat_used_retail_sales_flag.Text == "Y")
			{
				retail_check.CheckState = CheckState.Checked;
			}
			else
			{
				retail_check.CheckState = CheckState.Unchecked;
			}

			fG_JournalCat.RowSel = fG_JournalCat.CurrentRowIndex;
			fG_JournalCat.HighLight = UpgradeHelpers.HighLightSettings.HighlightNever;

			fG_JournalCat.SelectionMode = DataGridViewSelectionMode.CellSelect;

			pnl_JC_Update_Change.Visible = true;

		}

		private void FG_Service_Click(Object eventSender, EventArgs eventArgs)
		{
			pnl_Service_Update_Change.Visible = true;
			grd_Subscriptions.Visible = false;
			lbl_Subscriptions.Visible = false;
			RecordStat = "Update";
			txt_serv_code.Enabled = false;

			FG_Service.CurrentColumnIndex = 0;
			txt_serv_code.Text = FG_Service[FG_Service.CurrentRowIndex, FG_Service.CurrentColumnIndex].FormattedValue.ToString();
			FG_Service.CurrentColumnIndex = 1;
			txt_serv_name.Text = FG_Service[FG_Service.CurrentRowIndex, FG_Service.CurrentColumnIndex].FormattedValue.ToString();
			FG_Service.CurrentColumnIndex = 2;
			txt_serv_description.Text = FG_Service[FG_Service.CurrentRowIndex, FG_Service.CurrentColumnIndex].FormattedValue.ToString();
			FG_Service.CurrentColumnIndex = 3;
			lbl_serv_entry_date.Text = FG_Service[FG_Service.CurrentRowIndex, FG_Service.CurrentColumnIndex].FormattedValue.ToString();
			FG_Service.CurrentColumnIndex = 4;
			lbl_serv_entry_user_id.Text = FG_Service[FG_Service.CurrentRowIndex, FG_Service.CurrentColumnIndex].FormattedValue.ToString();
			FG_Service.CurrentColumnIndex = 5;
			lbl_serv_upd_date.Text = FG_Service[FG_Service.CurrentRowIndex, FG_Service.CurrentColumnIndex].FormattedValue.ToString();
			FG_Service.CurrentColumnIndex = 6;
			lbl_serv_upd_user_id.Text = FG_Service[FG_Service.CurrentRowIndex, FG_Service.CurrentColumnIndex].FormattedValue.ToString();
			FG_Service.CurrentColumnIndex = 7; //database name

			Fill_grd_Subscriptions(txt_serv_code.Text);



			// added in MSW - 7/18/22
			FG_Service.CurrentColumnIndex = 8;
			if (FG_Service[FG_Service.CurrentRowIndex, FG_Service.CurrentColumnIndex].FormattedValue.ToString() == "Y")
			{
				chk_service[0].CheckState = CheckState.Checked;
			}
			else
			{
				chk_service[0].CheckState = CheckState.Unchecked;
			}

			FG_Service.CurrentColumnIndex = 9;
			if (FG_Service[FG_Service.CurrentRowIndex, FG_Service.CurrentColumnIndex].FormattedValue.ToString() == "Y")
			{
				chk_service[1].CheckState = CheckState.Checked;
			}
			else
			{
				chk_service[1].CheckState = CheckState.Unchecked;
			}

			FG_Service.CurrentColumnIndex = 10;
			if (FG_Service[FG_Service.CurrentRowIndex, FG_Service.CurrentColumnIndex].FormattedValue.ToString() == "Y")
			{
				chk_service[2].CheckState = CheckState.Checked;
			}
			else
			{
				chk_service[2].CheckState = CheckState.Unchecked;
			}

			FG_Service.CurrentColumnIndex = 11;
			if (FG_Service[FG_Service.CurrentRowIndex, FG_Service.CurrentColumnIndex].FormattedValue.ToString() == "Y")
			{
				chk_service[3].CheckState = CheckState.Checked;
			}
			else
			{
				chk_service[3].CheckState = CheckState.Unchecked;
			}

			FG_Service.CurrentColumnIndex = 12;
			if (FG_Service[FG_Service.CurrentRowIndex, FG_Service.CurrentColumnIndex].FormattedValue.ToString() == "Y")
			{
				chk_service[4].CheckState = CheckState.Checked;
			}
			else
			{
				chk_service[4].CheckState = CheckState.Unchecked;
			}

			FG_Service.CurrentColumnIndex = 13;
			if (FG_Service[FG_Service.CurrentRowIndex, FG_Service.CurrentColumnIndex].FormattedValue.ToString() == "Y")
			{
				chk_service[5].CheckState = CheckState.Checked;
			}
			else
			{
				chk_service[5].CheckState = CheckState.Unchecked;
			}


		}

		private void FG_Users_Click(Object eventSender, EventArgs eventArgs)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strUserId = "";

			int lRow1 = 0;
			int lCol1 = 0;

			try
			{

				lRow1 = FG_Users.MouseRow;
				lCol1 = FG_Users.MouseCol;

				if (lRow1 > 0)
				{

					pnl_User_Update_Change.Visible = true;
					RecordStat = "Update";

					FG_Users.CurrentColumnIndex = 0;
					strUserId = FG_Users[FG_Users.CurrentRowIndex, FG_Users.CurrentColumnIndex].FormattedValue.ToString();

					strQuery1 = $"SELECT * FROM [User] WHERE (user_id = '{strUserId}') ";

					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if ((!rstRec1.BOF) && (!rstRec1.EOF))
					{

						txt_user_id.Text = ($"{Convert.ToString(rstRec1["user_id"])} ").Trim();

						chkAutoCallback.CheckState = CheckState.Unchecked;
						if (($"{Convert.ToString(rstRec1["user_auto_callback"])} ").Trim() == "Y")
						{
							chkAutoCallback.CheckState = CheckState.Checked;
						}

						chk_user_logged_in.CheckState = CheckState.Unchecked;
						if (($"{Convert.ToString(rstRec1["user_logged_in"])} ").Trim() == "Y")
						{
							chk_user_logged_in.CheckState = CheckState.Checked;
						}

						chkUserMonitorActivityFlag.CheckState = CheckState.Unchecked;
						if (($"{Convert.ToString(rstRec1["user_monitor_activity_flag"])} ").Trim() == "Y")
						{
							chkUserMonitorActivityFlag.CheckState = CheckState.Checked;
						}

						txt_user_first_name.Text = ($"{Convert.ToString(rstRec1["user_first_name"])} ").Trim();
						txt_user_middle_initial.Text = ($"{Convert.ToString(rstRec1["user_middle_initial"])} ").Trim();
						txt_user_last_name.Text = ($"{Convert.ToString(rstRec1["user_last_name"])} ").Trim();
						txt_user_password.Text = ($"{Convert.ToString(rstRec1["user_password"])} ").Trim();
						cbo_user_type.Text = ($"{Convert.ToString(rstRec1["user_type"])} ").Trim();
						txt_user_email_address.Text = ($"{Convert.ToString(rstRec1["user_email_address"])} ").Trim();
						txt_user_phone_no.Text = ($"{Convert.ToString(rstRec1["user_phone_no"])} ").Trim();
						txt_user_phone_no_ext.Text = ($"{Convert.ToString(rstRec1["user_phone_no_ext"])} ").Trim();

						// 04/19/2018 - By David D. Cruger; Added
						txtUserCellNbr.Text = ($"{Convert.ToString(rstRec1["user_cell_no"])} ").Trim();

						txt_user_default_account_id.Text = ($"{Convert.ToString(rstRec1["user_default_account_id"])} ").Trim();
						txt_user_description.Text = ($"{Convert.ToString(rstRec1["user_description"])} ").Trim();

						int tempForEndVar = default_browser.Items.Count - 1;
						for (int iCnt1 = 0; iCnt1 <= tempForEndVar; iCnt1++)
						{
							if (($"{Convert.ToString(rstRec1["user_browser_type"])} ").Trim() == default_browser.GetListItem(iCnt1).Substring(0, Math.Min(1, default_browser.GetListItem(iCnt1).Length)))
							{
								//default_browser.Text = default_browser.ItemData(iCnt1)
								default_browser.Text = default_browser.GetListItem(iCnt1).Substring(0, Math.Min(1, default_browser.GetListItem(iCnt1).Length));
								default_browser.SelectedIndex = iCnt1;
								break;
							}
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["user_comp_id"]))
						{
							txt_user_comp_id.Text = Convert.ToString(rstRec1["user_comp_id"]);
						}
						else
						{
							txt_user_comp_id.Text = "0";
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["user_contact_id"]))
						{
							txt_user_contact_id.Text = Convert.ToString(rstRec1["user_contact_id"]);
						}
						else
						{
							txt_user_contact_id.Text = "0";
						}

						cmbDefaultAirframe.Text = "N - None Selected";
						int tempForEndVar2 = cmbDefaultAirframe.Items.Count - 1;
						for (int iCnt1 = 0; iCnt1 <= tempForEndVar2; iCnt1++)
						{
							if (($"{Convert.ToString(rstRec1["user_default_airframe"])} ").Trim() == cmbDefaultAirframe.GetListItem(iCnt1).Substring(0, Math.Min(1, cmbDefaultAirframe.GetListItem(iCnt1).Length)))
							{
								cmbDefaultAirframe.Text = cmbDefaultAirframe.GetItemData(iCnt1).ToString();
								cmbDefaultAirframe.SelectedIndex = iCnt1;
							}
						}

						lbl_user_entry_date.Text = "";
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["user_entry_date"]))
						{
							lbl_user_entry_date.Text = Convert.ToDateTime(rstRec1["user_entry_date"]).ToString("MM/dd/yyyy HH:mm:ss");
						}

						lbl_user_entered_by.Text = ($"{Convert.ToString(rstRec1["user_entered_by"])} ").Trim();

						chk_run_account_management_reports_flag.CheckState = CheckState.Unchecked;
						if (($"{Convert.ToString(rstRec1["user_run_account_management_reports_flag"])} ").Trim() == "Y")
						{
							chk_run_account_management_reports_flag.CheckState = CheckState.Checked;
						}

						chk_remove_journal_subject_flag.CheckState = CheckState.Unchecked;
						if (($"{Convert.ToString(rstRec1["user_remove_journal_subject_flag"])} ").Trim() == "Y")
						{
							chk_remove_journal_subject_flag.CheckState = CheckState.Checked;
						}

						chk_user_process_pubs_flag.CheckState = CheckState.Unchecked;
						if (($"{Convert.ToString(rstRec1["user_process_pubs_flag"])} ").Trim() == "Y")
						{
							chk_user_process_pubs_flag.CheckState = CheckState.Checked;
						}

						chk_user_process_canadian_reg_flag.CheckState = CheckState.Unchecked;
						if (($"{Convert.ToString(rstRec1["user_process_canadian_reg_flag"])} ").Trim() == "Y")
						{
							chk_user_process_canadian_reg_flag.CheckState = CheckState.Checked;
						}

						chk_user_process_ntsb_reports_flag.CheckState = CheckState.Unchecked;
						if (($"{Convert.ToString(rstRec1["user_process_ntsb_reports_flag"])} ").Trim() == "Y")
						{
							chk_user_process_ntsb_reports_flag.CheckState = CheckState.Checked;
						}

						chk_user_edit_subscriptions.CheckState = CheckState.Unchecked;
						if (($"{Convert.ToString(rstRec1["user_edit_subscriptions"])} ").Trim() == "Y")
						{
							chk_user_edit_subscriptions.CheckState = CheckState.Checked;
						}

						chk_user_open_multiple_homebase.CheckState = CheckState.Unchecked;
						if (($"{Convert.ToString(rstRec1["user_open_multiple_homebase"])} ").Trim() == "Y")
						{
							chk_user_open_multiple_homebase.CheckState = CheckState.Checked;
						}

						chk_user_subscription_contract_amount.CheckState = CheckState.Unchecked;
						if (($"{Convert.ToString(rstRec1["user_subscription_contract_amount"])} ").Trim() == "Y")
						{
							chk_user_subscription_contract_amount.CheckState = CheckState.Checked;
						}

						chk_user_manage_accounts_flags.CheckState = CheckState.Unchecked;
						if (($"{Convert.ToString(rstRec1["user_manage_accounts_flag"])} ").Trim() == "Y")
						{
							chk_user_manage_accounts_flags.CheckState = CheckState.Checked;
						}

						// 06/18/2008 - By David D. Cruger; Added
						chk_user_delete_attached_ac_specs_flag.CheckState = CheckState.Unchecked;
						if (($"{Convert.ToString(rstRec1["user_delete_attached_ac_specs_flag"])} ").Trim() == "Y")
						{
							chk_user_delete_attached_ac_specs_flag.CheckState = CheckState.Checked;
						}

						// 06/24/2008 - By David D. Cruger; Added - Per Lf
						chk_user_hide_events_flag.CheckState = CheckState.Unchecked;
						if (($"{Convert.ToString(rstRec1["user_hide_events_flag"])} ").Trim() == "Y")
						{
							chk_user_hide_events_flag.CheckState = CheckState.Checked;
						}

						// 10/10/2017 - By David D. Cruger; Added
						chk_user_team_leader_flag.CheckState = CheckState.Unchecked;
						frmTeamLeader.Visible = false;
						txtUserTeamLeaderTeam.Text = "";
						ToolTipMain.SetToolTip(lblUserTeamLeaderTeam, "");
						cmbTeamReports.SelectedIndex = 0;

						if (($"{Convert.ToString(rstRec1["user_team_leader_flag"])} ").Trim() == "Y")
						{
							chk_user_team_leader_flag.CheckState = CheckState.Checked;
							frmTeamLeader.Visible = true;
						}

						// 11/03/2017 - By David D. Cruger; Added
						chk_user_report_flag.CheckState = CheckState.Unchecked;
						if (($"{Convert.ToString(rstRec1["user_user_report_flag"])} ").Trim() == "Y")
						{
							chk_user_report_flag.CheckState = CheckState.Checked;
						}

						txt_user_marketing_subids_allowed.Text = ($"{Convert.ToString(rstRec1["user_marketing_subids_allowed"])} ").Trim();
						if (txt_user_marketing_subids_allowed.Text == "")
						{
							txt_user_marketing_subids_allowed.Text = "NONE";
						}

					} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

					rstRec1.Close();

					modAdminCommon.Highlight_Grid_Row(FG_Users);

				}
				else
				{

					FG_Users.CurrentColumnIndex = lCol1;
					FG_Users.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortStringAscending));

				} // If lRow1 > 0 Then

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				MessageBox.Show($"FG_Users_Click_Error: {excep.Message}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		} // FG_Users_Click

		private void Load_User_Name_Grid()
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			int lCellBackColor = 0;
			Color lCellForeColor = System.Drawing.Color.Black;
			int lCnt1 = 0;

			try
			{

				strQuery1 = "SELECT * FROM [User] ";
				if (chkIncludeInactive.CheckState == CheckState.Unchecked)
				{
					strQuery1 = $"{strQuery1}WHERE (user_password <> 'inactive') ";
				}
				strQuery1 = $"{strQuery1}ORDER BY user_last_name, user_first_name, user_password ";
				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					FG_Users.FixedColumns = 0;
					FG_Users.FixedRows = 0;

					FG_Users.Clear();

					FG_Users.ColumnsCount = 4;
					FG_Users.RowsCount = 1;

					FG_Users.CurrentRowIndex = 0;
					FG_Users.CurrentColumnIndex = 0;

					FG_Users.SetColumnWidth(0, 40);
					FG_Users.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
					FG_Users[FG_Users.CurrentRowIndex, FG_Users.CurrentColumnIndex].Value = "UserId";

					FG_Users.CurrentColumnIndex = 1;
					FG_Users.SetColumnWidth(1, 97);
					FG_Users[FG_Users.CurrentRowIndex, FG_Users.CurrentColumnIndex].Value = "Last Name";

					FG_Users.CurrentColumnIndex = 2;
					FG_Users.SetColumnWidth(2, 97);
					FG_Users[FG_Users.CurrentRowIndex, FG_Users.CurrentColumnIndex].Value = "First Name";

					FG_Users.CurrentColumnIndex = 3;
					FG_Users.SetColumnWidth(3, 50);
					FG_Users[FG_Users.CurrentRowIndex, FG_Users.CurrentColumnIndex].Value = "AcctRep";

					FG_Users.Redraw = false;
					lCnt1 = 0;

					do 
					{ // Loop Until rstRec1.EOF = True

						FG_Users.RowsCount++;
						FG_Users.CurrentRowIndex++;

						lCellBackColor = Convert.ToInt32(Double.Parse(modAdminCommon.NoColor));
						lCellForeColor = Color.Black;
						if (($"{Convert.ToString(rstRec1["user_team_leader_flag"])} ").Trim() == "Y")
						{
							lCellForeColor = Color.Red;
						}
						if (($"{Convert.ToString(rstRec1["user_password"])} ").Trim().ToUpper() == "INACTIVE")
						{
							lCellBackColor = Convert.ToInt32(Double.Parse(modAdminCommon.InactiveColor));
						}

						FG_Users.CurrentColumnIndex = 0;
						FG_Users.CellBackColor = ColorTranslator.FromOle(lCellBackColor);
						FG_Users.CellForeColor = lCellForeColor;
						FG_Users.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
						FG_Users[FG_Users.CurrentRowIndex, FG_Users.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["user_id"])} ").Trim();

						FG_Users.CurrentColumnIndex = 1;
						FG_Users.CellBackColor = ColorTranslator.FromOle(lCellBackColor);
						FG_Users.CellForeColor = lCellForeColor;
						FG_Users.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						FG_Users[FG_Users.CurrentRowIndex, FG_Users.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["user_last_name"])} ").Trim();

						FG_Users.CurrentColumnIndex = 2;
						FG_Users.CellBackColor = ColorTranslator.FromOle(lCellBackColor);
						FG_Users.CellForeColor = lCellForeColor;
						FG_Users.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						FG_Users[FG_Users.CurrentRowIndex, FG_Users.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["user_first_name"])} ").Trim();

						FG_Users.CurrentColumnIndex = 3;
						FG_Users.CellBackColor = ColorTranslator.FromOle(lCellBackColor);
						FG_Users.CellForeColor = lCellForeColor;
						FG_Users.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						FG_Users[FG_Users.CurrentRowIndex, FG_Users.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["user_default_account_id"])} ").Trim();

						if (FG_Users.CurrentRowIndex == 1)
						{
							FG_Users.FixedRows = 1;
						}

						lCnt1++;
						if (lCnt1 == 31)
						{
							FG_Users.Redraw = true;
							FG_Users.Refresh();
							Application.DoEvents();
							FG_Users.Redraw = false;
						}

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

					FG_Users.Redraw = true;

				} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

				rstRec1.Close();

				FG_Users.CurrentRowIndex = 1;
				FG_Users.CurrentColumnIndex = 0;
				FG_Users.FirstDisplayedScrollingRowIndex = 1;

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				MessageBox.Show($"Load_User_Name_Grid_Error: {excep.Message}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		} // Load_User_Name_Grid

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
		private void Form_Load()
		{

			modStatusBar.Clear_Status_Bar(modAdminCommon.SB);


			SSTabHelper.SetSelectedIndex(tab_Lookup, 4);

			tab_Lookup_SelectedIndexChanged(tab_Lookup, new EventArgs());
			lbl_client_field.Text = "";
			Is_Dirty = false;

			ToolbarSetup();
			ToolbarButtonsSetup();

			if ((($"{Convert.ToString(modMyAdmin.MYSNP_USER["user_type"])} ").Trim() == "Research Manager") || (($"{Convert.ToString(modMyAdmin.MYSNP_USER["user_type"])} ").Trim() == "Administrator"))
			{
				Update_Command_Buttons("Enable");
			}
			else
			{
				Update_Command_Buttons("Disable");
			}

		}

		private void Form_FormClosing(Object eventSender, FormClosingEventArgs eventArgs)
		{
			int Cancel = (eventArgs.Cancel) ? 1 : 0;
			int UnloadMode = (int) eventArgs.CloseReason;
			try
			{
				if (Is_Dirty)
				{
					tab_Lookup_SelectedIndexChanged(tab_Lookup, new EventArgs());
				}
			}
			finally
			{
				eventArgs.Cancel = Cancel != 0;
			}

		}

		//UPGRADE_NOTE: (7001) The following declaration (lbl_summary_Click) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void lbl_summary_Click()
		//{
			//
		//}

		private void list_CustomFields_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{

			Fill_Field_Details();
			lbl_updated.Visible = false;
			txt_new_group.Visible = false;
			txt_sub_group.Visible = false;
		}



		private void lst_apu_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.lst_apu, eventSender);

			if (Index == 0)
			{
				txt_search_apu[1].Tag = lst_apu[0].Text.Substring(0, Math.Min(lst_apu[0].Text.IndexOf('|'), lst_apu[0].Text.Length));
				txt_search_apu[1].Text = Convert.ToString(txt_search_apu[1].Tag);
				cmd_apu[1].Visible = true;

				lbl_apu[0].Visible = false;
				cmd_apu[2].Visible = false;
				cmd_apu[3].Visible = false;
			}

		}

		private void lst_av_names_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.lst_av_names, eventSender);

			if (Index == 0)
			{

				lbl_avionics[7].Text = "";
				lbl_avionics[3].Text = lst_av_names[0].Text.Substring(0, Math.Min(lst_av_names[0].Text.IndexOf('|'), lst_av_names[0].Text.Length));
				txt_avionics[0].Text = lbl_avionics[3].Text;
				Fill_Avionics_Found("Y");



			}
			else if (Index == 1)
			{ 

				if (txt_avionics[0].Text.Trim() != "")
				{
					txt_avionics[0].Text = lbl_avionics[3].Text;
					lbl_avionics[7].Text = lst_av_names[1].Text.Substring(0, Math.Min(lst_av_names[1].Text.IndexOf('|'), lst_av_names[1].Text.Length));
					Fill_Avionics_Found("Y");
					txt_avionics[0].Text = lst_av_names[1].Text.Substring(0, Math.Min(lst_av_names[1].Text.IndexOf('|'), lst_av_names[1].Text.Length));
				}

			}
			else if (Index == 2)
			{ 

			}

			pnl_yes_no.Visible = false;


		}


		private void lst_class_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{



			lst_class.Tag = lst_class.Text.Substring(0, Math.Min(lst_class.Text.IndexOf(Strings.Chr(160).ToString()), lst_class.Text.Length));
			frm_edit_class.Visible = true;


			ADORecordSetHelper ado_FieldList = new ADORecordSetHelper(); //Current recordset
			string SQL = "";

			if (Convert.ToString(lst_class.Tag).Trim() != "" && Convert.ToString(lst_class.Tag).Trim() != "0")
			{
				SQL = $"SELECT *  from  Aircraft_Class where aclass_code = '{Convert.ToString(lst_class.Tag)}' ";

				ado_FieldList.Open(SQL, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

				while (!ado_FieldList.EOF)
				{

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(ado_FieldList["aclass_code"]))
					{
						txt_class[0].Text = Convert.ToString(ado_FieldList["aclass_code"]).Trim();
					}
					else
					{
						txt_class[0].Text = "";
					}
					txt_class[0].Enabled = false;


					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(ado_FieldList["aclass_name"]))
					{
						txt_class[1].Text = Convert.ToString(ado_FieldList["aclass_name"]).Trim();
					}
					else
					{
						txt_class[1].Text = "";
					}

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(ado_FieldList["aclass_common_verify_days"]))
					{
						cbo_days[0].Text = Convert.ToString(ado_FieldList["aclass_common_verify_days"]).Trim();
					}
					else
					{
						cbo_days[0].Text = "";
					}

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(ado_FieldList["aclass_sale_verify_days"]))
					{
						cbo_days[1].Text = Convert.ToString(ado_FieldList["aclass_sale_verify_days"]).Trim();
					}
					else
					{
						cbo_days[1].Text = "";
					}

					ado_FieldList.MoveNext();
				}

				ado_FieldList.Close();
				ado_FieldList = null;

			}

		}

		public void mnuFileClose_Click(Object eventSender, EventArgs eventArgs) => this.Close();


		public void mnuFileLogout_Click(Object eventSender, EventArgs eventArgs) => Environment.Exit(0);



		private void tab_Lookup_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{

			int NewTab = 0; //Current tab
			string SQL = ""; //Current query sql
			ADORecordSetHelper RS_Table = new ADORecordSetHelper(); //Current recordset
			int nRow = 0; //Current row counter
			int nCol = 0;


			try
			{

				NewTab = SSTabHelper.GetSelectedIndex(tab_Lookup); //note tabs are zero (0) based


				Application.DoEvents();

				switch(NewTab)
				{
					case 0 :  //Application configuration 
						SQL = "Select * from Application_Configuration ORDER BY aconfig_website "; 
						RS_Table.Open(SQL, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic); 
						 
						if (!(RS_Table.BOF && RS_Table.EOF))
						{
							txt_aconfig_website.Text = ($"{Convert.ToString(RS_Table["aconfig_website"])} ").Trim();
							txt_aconfig_fileserver.Text = ($"{Convert.ToString(RS_Table["aconfig_fileserver"])} ").Trim();
							txt_aconfig_model.Text = ($"{Convert.ToString(RS_Table["aconfig_model"])}").Trim();
							txt_aconfig_documents.Text = ($"{Convert.ToString(RS_Table["aconfig_documents"])}").Trim();
							txt_aconfig_processing.Text = ($"{Convert.ToString(RS_Table["aconfig_processing"])}").Trim();
							txtColorConfirmDays.Text = ($"{Convert.ToString(RS_Table["aconfig_color_confirm_days"])}").Trim();
						} 
						RS_Table.Close(); 
						 
						break;
					case 1 :  //display journal category records 

						 
						fG_JournalCat.Visible = false; 
						tot_number.Visible = false; 
						total_cat.Visible = false; 
						 
						drop_evo.Items.Clear(); 
						drop_evo.AddItem("All"); 
						drop_evo.AddItem("Yes"); 
						drop_evo.AddItem("No"); 
						drop_evo.SelectedIndex = 0; 
						drop_evo.Refresh(); 
						 
						drop_sales.Items.Clear(); 
						drop_sales.AddItem("All"); 
						drop_sales.AddItem("Yes"); 
						drop_sales.AddItem("No"); 
						drop_sales.SelectedIndex = 0; 
						drop_sales.Refresh(); 

						 
						SQL = "SELECT distinct jcat_category_name, jcat_category_code from Journal_Category "; 
						SQL = $"{SQL}ORDER BY jcat_category_name "; 
						 
						fill_cat_dropdown(SQL); 
						 
						break;
					case 2 :  //users 
						pnl_User_Update_Change.Visible = false; 
						cbo_user_type.Items.Clear(); 
						cbo_user_type.AddItem("Accounting"); 
						cbo_user_type.AddItem("Administrator"); 
						cbo_user_type.AddItem("Research Manager"); 
						cbo_user_type.AddItem("Marketing"); 
						cbo_user_type.AddItem("Researcher"); 
						cbo_user_type.AddItem("Technical"); 
						cbo_user_type.SelectedIndex = 0; 
						 
						default_browser.Items.Clear(); 
						default_browser.AddItem("I - Internet Explorer"); 
						default_browser.AddItem("M - Mozilla Firefox"); 
						default_browser.AddItem("C - Google Chrome"); 
						default_browser.AddItem("D - Default Browser"); 
						default_browser.SelectedIndex = 0; 
						default_browser.Refresh(); 
						 
						SQL = "select * from Airframe_type order by aftype_name "; 
						RS_Table.Open(SQL, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly); 
						 
						cmbDefaultAirframe.Items.Clear(); 
						cmbDefaultAirframe.AddItem("N - None Selected"); 
						 
						do 
						{ // Loop Until RS_Table.EOF = True
							cmbDefaultAirframe.AddItem($"{Convert.ToString(RS_Table["aftype_code"])} - {Convert.ToString(RS_Table["aftype_name"])}");
							RS_Table.MoveNext();
						}
						while(!RS_Table.EOF); 
						 
						RS_Table.Close(); 
						cmbDefaultAirframe.SelectedIndex = 1; 
						 
						modAdminCommon.Load_Team_Leaders_Report_Combo(cmbTeamReports); 
						 
						Load_User_Name_Grid(); 
						 
						break;
					case 3 :  //service  --8 cols 
						 
						grd_Subscriptions.Visible = false; 
						lbl_Subscriptions.Visible = false; 
						FG_Service.Clear(); 
						FG_Service.ColumnsCount = 14; 
						SQL = "SELECT * from Service  ORDER BY serv_code"; 
						RS_Table.Open(SQL, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic); 
						 
						RS_Table.MoveFirst(); 
						FG_Service.CurrentRowIndex = 0; 
						FG_Service.CurrentColumnIndex = 0; 
						FG_Service[FG_Service.CurrentRowIndex, FG_Service.CurrentColumnIndex].Value = "Serv_Code"; 
						FG_Service.CurrentColumnIndex = 1; 
						FG_Service[FG_Service.CurrentRowIndex, FG_Service.CurrentColumnIndex].Value = "Serv_Name"; 
						FG_Service.CurrentColumnIndex = 2; 
						FG_Service[FG_Service.CurrentRowIndex, FG_Service.CurrentColumnIndex].Value = "Serv_Descr"; 
						FG_Service.CurrentColumnIndex = 3; 
						FG_Service[FG_Service.CurrentRowIndex, FG_Service.CurrentColumnIndex].Value = "Serv_entry_date"; 
						FG_Service.CurrentColumnIndex = 4; 
						FG_Service[FG_Service.CurrentRowIndex, FG_Service.CurrentColumnIndex].Value = "Serv_entry_user_id"; 
						FG_Service.CurrentColumnIndex = 5; 
						FG_Service[FG_Service.CurrentRowIndex, FG_Service.CurrentColumnIndex].Value = "Serv_upd_date"; 
						FG_Service.CurrentColumnIndex = 6; 
						FG_Service[FG_Service.CurrentRowIndex, FG_Service.CurrentColumnIndex].Value = "Serv_upd_user_id"; 
						FG_Service.CurrentColumnIndex = 7; 
						FG_Service[FG_Service.CurrentRowIndex, FG_Service.CurrentColumnIndex].Value = "Serv_database_name"; 
						FG_Service.CurrentColumnIndex = 8; 
						FG_Service[FG_Service.CurrentRowIndex, FG_Service.CurrentColumnIndex].Value = "serv_evolution_flag"; 
						FG_Service.CurrentColumnIndex = 9; 
						FG_Service[FG_Service.CurrentRowIndex, FG_Service.CurrentColumnIndex].Value = "serv_api_flag"; 
						FG_Service.CurrentColumnIndex = 10; 
						FG_Service[FG_Service.CurrentRowIndex, FG_Service.CurrentColumnIndex].Value = "serv_bi_flag"; 
						FG_Service.CurrentColumnIndex = 11; 
						FG_Service[FG_Service.CurrentRowIndex, FG_Service.CurrentColumnIndex].Value = "serv_salesforce_flag"; 
						FG_Service.CurrentColumnIndex = 12; 
						FG_Service[FG_Service.CurrentRowIndex, FG_Service.CurrentColumnIndex].Value = "serv_jetnetiq_flag"; 
						FG_Service.CurrentColumnIndex = 13; 
						FG_Service[FG_Service.CurrentRowIndex, FG_Service.CurrentColumnIndex].Value = "serv_customrep_flag"; 
						 
						FG_Service.SetColumnWidth(0, 67); 
						FG_Service.SetColumnWidth(1, 200); 
						FG_Service.SetColumnWidth(2, 0); 
						FG_Service.SetColumnWidth(3, 0); 
						FG_Service.SetColumnWidth(4, 0); 
						FG_Service.SetColumnWidth(5, 0); 
						FG_Service.SetColumnWidth(6, 0); 
						FG_Service.SetColumnWidth(7, 0); 
						FG_Service.SetColumnWidth(8, 0); 
						FG_Service.SetColumnWidth(9, 0); 
						FG_Service.SetColumnWidth(10, 0); 
						FG_Service.SetColumnWidth(11, 0); 
						FG_Service.SetColumnWidth(12, 0); 
						FG_Service.SetColumnWidth(13, 0); 
						nRow = 1; 
						FG_Service.CurrentRowIndex = nRow; 
						while (!RS_Table.EOF)
						{

							FG_Service.CurrentColumnIndex = 0;
							FG_Service[FG_Service.CurrentRowIndex, FG_Service.CurrentColumnIndex].Value = ($"{Convert.ToString(RS_Table["serv_code"])}").Trim();
							FG_Service.CurrentColumnIndex = 1;
							FG_Service[FG_Service.CurrentRowIndex, FG_Service.CurrentColumnIndex].Value = ($"{Convert.ToString(RS_Table["Serv_Name"])}").Trim();
							FG_Service.CurrentColumnIndex = 2;
							FG_Service[FG_Service.CurrentRowIndex, FG_Service.CurrentColumnIndex].Value = ($"{Convert.ToString(RS_Table["Serv_Description"])}").Trim();
							FG_Service.CurrentColumnIndex = 3;
							FG_Service[FG_Service.CurrentRowIndex, FG_Service.CurrentColumnIndex].Value = ($"{Convert.ToString(RS_Table["Serv_entry_date"])}").Trim();
							FG_Service.CurrentColumnIndex = 4;
							FG_Service[FG_Service.CurrentRowIndex, FG_Service.CurrentColumnIndex].Value = ($"{Convert.ToString(RS_Table["Serv_entry_user_id"])}").Trim();
							FG_Service.CurrentColumnIndex = 5;
							FG_Service[FG_Service.CurrentRowIndex, FG_Service.CurrentColumnIndex].Value = ($"{Convert.ToString(RS_Table["Serv_upd_date"])}").Trim();
							FG_Service.CurrentColumnIndex = 6;
							FG_Service[FG_Service.CurrentRowIndex, FG_Service.CurrentColumnIndex].Value = ($"{Convert.ToString(RS_Table["Serv_upd_user_id"])}").Trim();
							FG_Service.CurrentColumnIndex = 7;
							FG_Service[FG_Service.CurrentRowIndex, FG_Service.CurrentColumnIndex].Value = ($"{Convert.ToString(RS_Table["Serv_database_name"])}").Trim();
							FG_Service.CurrentColumnIndex = 8;
							FG_Service[FG_Service.CurrentRowIndex, FG_Service.CurrentColumnIndex].Value = ($"{Convert.ToString(RS_Table["serv_evolution_flag"])}").Trim();
							FG_Service.CurrentColumnIndex = 9;
							FG_Service[FG_Service.CurrentRowIndex, FG_Service.CurrentColumnIndex].Value = ($"{Convert.ToString(RS_Table["serv_api_flag"])}").Trim();
							FG_Service.CurrentColumnIndex = 10;
							FG_Service[FG_Service.CurrentRowIndex, FG_Service.CurrentColumnIndex].Value = ($"{Convert.ToString(RS_Table["serv_bi_flag"])}").Trim();
							FG_Service.CurrentColumnIndex = 11;
							FG_Service[FG_Service.CurrentRowIndex, FG_Service.CurrentColumnIndex].Value = ($"{Convert.ToString(RS_Table["serv_salesforce_flag"])}").Trim();
							FG_Service.CurrentColumnIndex = 12;
							FG_Service[FG_Service.CurrentRowIndex, FG_Service.CurrentColumnIndex].Value = ($"{Convert.ToString(RS_Table["serv_jetnetiq_flag"])}").Trim();
							FG_Service.CurrentColumnIndex = 13;
							FG_Service[FG_Service.CurrentRowIndex, FG_Service.CurrentColumnIndex].Value = ($"{Convert.ToString(RS_Table["serv_customrep_flag"])}").Trim();

							nRow++;
							FG_Service.RowsCount = nRow + 1;
							FG_Service.CurrentRowIndex = nRow;
							RS_Table.MoveNext();
						} 
						RS_Table.Close(); 
						 
						pnl_Service_Update_Change.Visible = false; 
						FG_Service.Visible = true; 
						FG_Service.RowsCount--; 
						FG_Service.Refresh(); 

						 
						break;
					case 4 :  //Account rep 
						 
						pnlAcctRepUpdateChange.Visible = false; 
						FG_AccountRep.Clear(); 
						SQL = "SELECT * from Account_rep Order By accrep_account_id "; 
						RS_Table.Open(SQL, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic); 
						 
						RS_Table.MoveFirst(); 
						FG_AccountRep.CurrentRowIndex = 0; 
						FG_AccountRep.CurrentColumnIndex = 0; 
						FG_AccountRep[FG_AccountRep.CurrentRowIndex, FG_AccountRep.CurrentColumnIndex].Value = "Account ID"; 
						FG_AccountRep.SetColumnWidth(0, 67); 
						FG_AccountRep.CurrentColumnIndex = 1; 
						FG_AccountRep[FG_AccountRep.CurrentRowIndex, FG_AccountRep.CurrentColumnIndex].Value = "Account Type"; 
						FG_AccountRep.SetColumnWidth(1, 67); 
						FG_AccountRep.CurrentColumnIndex = 2; 
						FG_AccountRep[FG_AccountRep.CurrentRowIndex, FG_AccountRep.CurrentColumnIndex].Value = "Account Description"; 
						FG_AccountRep.SetColumnWidth(2, 200); 
						FG_AccountRep.CurrentColumnIndex = 3; 
						FG_AccountRep[FG_AccountRep.CurrentRowIndex, FG_AccountRep.CurrentColumnIndex].Value = "User ID"; 
						FG_AccountRep.SetColumnWidth(3, 67); 
						 
						nRow = 1; 
						FG_AccountRep.CurrentRowIndex = nRow; 
						while (!RS_Table.EOF)
						{

							FG_AccountRep.CurrentColumnIndex = 0;
							FG_AccountRep[FG_AccountRep.CurrentRowIndex, FG_AccountRep.CurrentColumnIndex].Value = ($"{Convert.ToString(RS_Table["accrep_account_id"])}").Trim();
							FG_AccountRep.CurrentColumnIndex = 1;
							FG_AccountRep[FG_AccountRep.CurrentRowIndex, FG_AccountRep.CurrentColumnIndex].Value = ($"{Convert.ToString(RS_Table["accrep_account_type"])}").Trim();
							FG_AccountRep.CurrentColumnIndex = 2;
							FG_AccountRep[FG_AccountRep.CurrentRowIndex, FG_AccountRep.CurrentColumnIndex].Value = ($"{Convert.ToString(RS_Table["accrep_description"])}").Trim();
							FG_AccountRep.CurrentColumnIndex = 3;
							FG_AccountRep[FG_AccountRep.CurrentRowIndex, FG_AccountRep.CurrentColumnIndex].Value = ($"{Convert.ToString(RS_Table["accrep_user_id"])}").Trim();
							nRow++;
							FG_AccountRep.RowsCount = nRow + 1;
							FG_AccountRep.CurrentRowIndex = nRow;

							RS_Table.MoveNext();
						} 
						RS_Table.Close(); 
						FG_AccountRep.RowsCount--; 
						FG_AccountRep.Visible = true; 
						FG_AccountRep.Enabled = true; 
						//FG_AccountRep.SetFocus 
						 
						break;
					case 5 :  //table locking 
						Count_Company_Locked_Records(); 
						Count_Contact_Locked_Records(); 
						Count_Aircraft_Locked_Records(); 
						break;
					case 6 :  //Error correction 
						 
						cmdCheckCompOrphanPhoneNbrs.Visible = true; 
						lblTotalCompOrphanPhoneNbrs.Visible = false; 
						lblTotalCompOrphanPhoneNbrs.Text = "Total Record: 0"; 
						cmdRemoveCompOrphanPhoneNbrs.Visible = false; 
						 
						cmdCheckContactOrphanPhoneNbrs.Visible = true; 
						lblTotalContactOrphanPhoneNbrs.Visible = false; 
						lblTotalContactOrphanPhoneNbrs.Text = "Total Record: 0"; 
						cmdRemoveContactOrphanPhoneNbrs.Visible = false; 
						 
						break;
					case 7 :  //eMail Addresses 
						break;
					case 8 : 
						Fill_Evo_Areas(); 
						 
						break;
					case 9 : 
						Fill_Makes(); 
						 
						break;
					case 10 : 
						cmd_apu_Click(cmd_apu[0], new EventArgs()); 
						 
						break;
					case 11 : 
						create_class_page(); 
						 
						break;
				}

				Application.DoEvents();
				Is_Dirty = false;
			}
			catch
			{

				Is_Dirty = false;
				this.Cursor = CursorHelper.CursorDefault;
				modAdminCommon.Report_Error("CommonLookup Tab Error: ");
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1065
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");

				tab_LookupPreviousTab = tab_Lookup.SelectedIndex;
			}



		}


		private void tbr_ToolBar_ButtonClick(Object eventSender, EventArgs eventArgs)
		{
			ToolStripItem Button = (ToolStripItem) eventSender;

			try
			{


				switch(Button.Name)
				{
					case "Home" : 
						modAdminCommon.gbl_bHomeClicked = true; 
						frm_Admin_Menu.DefInstance.Show(); 
						this.Close(); 
						 
						break;
					case "Back" : 
						mnuFileClose_Click(mnuFileClose, new EventArgs()); 
						 
						break;
					case "Save" : 
						MessageBox.Show("This is nothing to Save", "Aircraft Lookup", MessageBoxButtons.OK, MessageBoxIcon.Information); 
						 
						break;
					case "Help" : 
						MessageBox.Show("Help is forthcoming", "Aircraft Lookup", MessageBoxButtons.OK, MessageBoxIcon.Information); 
						 
						break;
				}
			}
			catch
			{

				modAdminCommon.Report_Error("tbr_ToolBar_Error: ");
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
				return;
			}

		}

		private void txt_accrep_account_id_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{

				//UPGRADE_ISSUE: (1058) Assignment not supported: KeyAscii to a non-positive constant More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-1058
				KeyAscii = Strings.AscW(Strings.ChrW(KeyAscii).ToString().ToUpper());
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

		private void txt_accrep_account_type_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{

				//UPGRADE_ISSUE: (1058) Assignment not supported: KeyAscii to a non-positive constant More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-1058
				KeyAscii = Strings.AscW(Strings.ChrW(KeyAscii).ToString().ToUpper());
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

		public void Count_Company_Locked_Records()
		{

			ADORecordSetHelper snp_CompanyLocked = new ADORecordSetHelper();

			string Query = "select count(*) as Tot_Company_Locked from Company_Lock";
			snp_CompanyLocked.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);


			if (!(snp_CompanyLocked.BOF && snp_CompanyLocked.EOF))
			{
				snp_CompanyLocked.MoveFirst();
				if ((Convert.ToDouble(snp_CompanyLocked["Tot_Company_Locked"])) > 0)
				{
					txt_Total_Company_Locked.Text = (Convert.ToString(snp_CompanyLocked["Tot_Company_Locked"]));
				}
				else
				{
					txt_Total_Company_Locked.Text = "0";
				}
			}

		}

		public void Count_Contact_Locked_Records()
		{

			ADORecordSetHelper snp_ContactLocked = new ADORecordSetHelper();

			string Query = "select count(*) as Tot_Contact_Locked from Contact_Lock";
			snp_ContactLocked.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);


			if (!(snp_ContactLocked.BOF && snp_ContactLocked.EOF))
			{
				snp_ContactLocked.MoveFirst();
				if ((Convert.ToDouble(snp_ContactLocked["Tot_Contact_Locked"])) > 0)
				{
					txt_Total_Contact_Locked.Text = (Convert.ToString(snp_ContactLocked["Tot_Contact_Locked"]));
				}
				else
				{
					txt_Total_Contact_Locked.Text = "0";
				}
			}

		}

		public void Count_Aircraft_Locked_Records()
		{

			ADORecordSetHelper snp_AircraftLocked = new ADORecordSetHelper();

			string Query = "select count(*) as Tot_Aircraft_Locked from Aircraft_Lock";
			//Set snp_AircraftLocked = LOCAL_DB.OpenRecordset(Query, dbOpenSnapshot)
			snp_AircraftLocked.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);


			if (!(snp_AircraftLocked.BOF && snp_AircraftLocked.EOF))
			{
				snp_AircraftLocked.MoveFirst();
				if ((Convert.ToDouble(snp_AircraftLocked["Tot_Aircraft_Locked"])) > 0)
				{
					txt_Total_Aircraft_Locked.Text = (Convert.ToString(snp_AircraftLocked["Tot_Aircraft_Locked"]));
				}
				else
				{
					txt_Total_Aircraft_Locked.Text = "0";
				}
			}


		}

		private void txt_aconfig_ac_pictures_TextChanged(Object eventSender, EventArgs eventArgs) => Is_Dirty = true;


		private void txt_aconfig_documents_TextChanged(Object eventSender, EventArgs eventArgs) => Is_Dirty = true;



		private void txt_aconfig_fileserver_TextChanged(Object eventSender, EventArgs eventArgs) => Is_Dirty = true;


		private void txt_aconfig_model_TextChanged(Object eventSender, EventArgs eventArgs) => Is_Dirty = true;



		private void txt_aconfig_processing_TextChanged(Object eventSender, EventArgs eventArgs) => Is_Dirty = true;


		private void txt_aconfig_website_TextChanged(Object eventSender, EventArgs eventArgs) => Is_Dirty = true;



		private void txt_avionics_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{

				if (KeyCode == ((int) Keys.Return))
				{
					Fill_Avionics_Found("N");
				}
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}

		}


		private void txt_serv_code_Leave(Object eventSender, EventArgs eventArgs) => txt_serv_code.Text = ($"{txt_serv_code.Text}").ToUpper();



		private void txt_user_first_name_Leave(Object eventSender, EventArgs eventArgs) => txt_user_first_name.Text = Strings.StrConv($"{txt_user_first_name.Text}", VbStrConv.ProperCase, 0);



		private void txt_user_last_name_Leave(Object eventSender, EventArgs eventArgs)
		{


			//if the first letter is capitalized, then leave, otherwise, put in proper case
			if (txt_user_last_name.Text.Trim().StartsWith(txt_user_last_name.Text.Trim().Substring(0, Math.Min(1, txt_user_last_name.Text.Trim().Length)).ToUpper(), StringComparison.Ordinal))
			{
				txt_user_last_name.Text = txt_user_last_name.Text;
			}
			else
			{
				txt_user_last_name.Text = Strings.StrConv($"{txt_user_last_name.Text}", VbStrConv.ProperCase, 0);
			}

		}


		private void txt_user_middle_initial_Leave(Object eventSender, EventArgs eventArgs) => txt_user_middle_initial.Text = ($"{txt_user_middle_initial.Text}").ToUpper();



		private void txtColorConfirmDays_TextChanged(Object eventSender, EventArgs eventArgs) => Is_Dirty = true;




		public void fill_journal_cat()
		{
			pnl_JC_Update_Change.Visible = false;

			fG_JournalCat.Clear();
			ADORecordSetHelper RS_Table = new ADORecordSetHelper(); //Current recordset
			int nCol = 0;
			int first_time = 1;
			int total_counter = 0;

			//tot_number.Visible = False
			string[] temp_code = drop_cat.GetListItem(drop_cat.SelectedIndex).Split('-');
			string temp_evo = drop_evo.GetListItem(drop_evo.SelectedIndex);
			string temp_sales = drop_sales.GetListItem(drop_sales.SelectedIndex);


			string SQL = $"SELECT * from Journal_Category Where jcat_category_code = '{temp_code[0]}'"; //Current query sql


			if (temp_evo == "Yes")
			{
				SQL = $"{SQL} and Jcat_send_to_website = 'Y' ";
			}
			else if ((temp_evo == "No"))
			{ 
				SQL = $"{SQL} and Jcat_send_to_website = 'N' ";
			}

			if (temp_sales == "Yes")
			{
				SQL = $"{SQL} and Jcat_used_retail_sales_flag  = 'Y' ";
			}
			else if ((temp_sales == "No"))
			{ 
				SQL = $"{SQL} and Jcat_used_retail_sales_flag  = 'N' ";
			}


			SQL = $"{SQL} ORDER BY jcat_category_name, jcat_subcategory_name ";


			RS_Table.Open(SQL, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);


			fG_JournalCat.SetColumnWidth(0, 80);
			fG_JournalCat.SetColumnWidth(1, 100);
			fG_JournalCat.SetColumnWidth(2, 160);
			fG_JournalCat.SetColumnWidth(3, 67);
			fG_JournalCat.SetColumnWidth(4, 67);
			fG_JournalCat.SetColumnWidth(5, 0);



			fG_JournalCat.CurrentRowIndex = 0;
			fG_JournalCat.CurrentColumnIndex = 0;
			fG_JournalCat[fG_JournalCat.CurrentRowIndex, fG_JournalCat.CurrentColumnIndex].Value = "Category Code";
			fG_JournalCat.CurrentColumnIndex = 1;
			fG_JournalCat[fG_JournalCat.CurrentRowIndex, fG_JournalCat.CurrentColumnIndex].Value = "SubCategory Code";
			fG_JournalCat.CurrentColumnIndex = 2;
			fG_JournalCat[fG_JournalCat.CurrentRowIndex, fG_JournalCat.CurrentColumnIndex].Value = "SubCategory Name";
			fG_JournalCat.CurrentColumnIndex = 3;
			fG_JournalCat[fG_JournalCat.CurrentRowIndex, fG_JournalCat.CurrentColumnIndex].Value = "Send to Evo";
			fG_JournalCat.CurrentColumnIndex = 4;
			fG_JournalCat[fG_JournalCat.CurrentRowIndex, fG_JournalCat.CurrentColumnIndex].Value = "Retail Sales";
			fG_JournalCat.CurrentColumnIndex = 5;
			fG_JournalCat[fG_JournalCat.CurrentRowIndex, fG_JournalCat.CurrentColumnIndex].Value = "Category Name";






			int nRow = 1; //Current row counter
			fG_JournalCat.CurrentRowIndex = nRow;

			while (!RS_Table.EOF)
			{

				if (first_time == 1)
				{
					first_time = 2;
					RS_Table.MoveFirst();
				}


				fG_JournalCat.CurrentColumnIndex = 0;
				fG_JournalCat[fG_JournalCat.CurrentRowIndex, fG_JournalCat.CurrentColumnIndex].Value = ($"{Convert.ToString(RS_Table["jcat_category_code"])}").Trim();
				fG_JournalCat.CurrentColumnIndex = 1;
				fG_JournalCat[fG_JournalCat.CurrentRowIndex, fG_JournalCat.CurrentColumnIndex].Value = ($"{Convert.ToString(RS_Table["jcat_subcategory_code"])}").Trim();
				fG_JournalCat.CurrentColumnIndex = 2;
				fG_JournalCat[fG_JournalCat.CurrentRowIndex, fG_JournalCat.CurrentColumnIndex].Value = ($"{Convert.ToString(RS_Table["jcat_subcategory_name"])}").Trim();
				fG_JournalCat.CurrentColumnIndex = 3;
				fG_JournalCat[fG_JournalCat.CurrentRowIndex, fG_JournalCat.CurrentColumnIndex].Value = ($"{Convert.ToString(RS_Table["Jcat_send_to_website"])}").Trim();
				fG_JournalCat.CurrentColumnIndex = 4;
				fG_JournalCat[fG_JournalCat.CurrentRowIndex, fG_JournalCat.CurrentColumnIndex].Value = ($"{Convert.ToString(RS_Table["Jcat_used_retail_sales_flag"])}").Trim();
				fG_JournalCat.CurrentColumnIndex = 5;
				fG_JournalCat[fG_JournalCat.CurrentRowIndex, fG_JournalCat.CurrentColumnIndex].Value = ($"{Convert.ToString(RS_Table["jcat_category_name"])}").Trim();

				total_counter++;
				tot_number.Text = total_counter.ToString();
				tot_number.Refresh();
				nRow++;
				fG_JournalCat.RowsCount = nRow + 1;
				fG_JournalCat.CurrentRowIndex = nRow;
				RS_Table.MoveNext();
			}



			tot_number.Visible = true;
			total_cat.Visible = true;
			fG_JournalCat.Visible = true;
			RS_Table.Close();
			fG_JournalCat.RowsCount--;
			fG_JournalCat.Refresh();
		}

		public void fill_cat_dropdown(string inquery)
		{

			ADORecordSetHelper cat_drop = new ADORecordSetHelper(); //Current recordset

			drop_cat.Items.Clear();

			string SQL = inquery; //Current query sql
			cat_drop.Open(SQL, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

			while (!cat_drop.EOF)
			{

				drop_cat.AddItem($"{($"{Convert.ToString(cat_drop["jcat_category_code"])}").Trim()}-{($"{Convert.ToString(cat_drop["jcat_category_name"])}").Trim()}");


				cat_drop.MoveNext();
			}

			drop_cat.SelectedIndex = 0;
			cat_drop.Close();

			drop_cat.Refresh();
		}

		private void Update_Click(Object eventSender, EventArgs eventArgs) => fill_journal_cat();


		public void Fill_FieldGroups()
		{
			ADORecordSetHelper ado_FieldGroup = new ADORecordSetHelper(); //Current recordset

			cbo_FieldGroups.Items.Clear();
			cbo_FieldGroups.AddItem("All");


			string SQL = "SELECT * from Custom_Export_Tab "; //Current query sql
			if (cbo_area.Text != "All")
			{
				SQL = $"{SQL}where cefstab_main_name='{cbo_area.Text}' ";
			}
			SQL = $"{SQL} order by cefstab_main_name, cefstab_order";
			ado_FieldGroup.Open(SQL, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

			while (!ado_FieldGroup.EOF)
			{

				cbo_FieldGroups.AddItem($"{($"{Convert.ToString(ado_FieldGroup["cefstab_main_name"])}").Trim()} - {($"{Convert.ToString(ado_FieldGroup["cefstab_sub_name"])}").Trim()}");

				ado_FieldGroup.MoveNext();
			}

			cbo_FieldGroups.SelectedIndex = 0;
			ado_FieldGroup.Close();


		}

		public void FillCustomFieldList()
		{

			// GET A LIST OF ALL FIELDS TO ALLOW USER SELECTION BASED ON THE TAB AND SUB TAB SELETED.
			string SQL = ""; //Current query sql
			ADORecordSetHelper ado_FieldList = new ADORecordSetHelper(); //Current recordset
			string Query = "";
			string[] query_array = ArraysHelper.InitializeArray<string>(251);

			int list_index_temp = 0;
			int Counter = 1;
			int query_counter = 0;

			string split_group = cbo_FieldGroups.Text.Substring(0, Math.Min(cbo_FieldGroups.Text.IndexOf(" - ") + 1, cbo_FieldGroups.Text.Length));
			string main_group = split_group;
			split_group = cbo_FieldGroups.Text.Substring(Math.Max(cbo_FieldGroups.Text.Length - (Strings.Len(cbo_FieldGroups.Text) - (cbo_FieldGroups.Text.IndexOf(" - ") + 1) - 2), 0));
			string sub_group = split_group;


			list_CustomFields.Items.Clear();


			if (cbo_FieldGroups.Text != "All")
			{
				SQL = "SELECT * from Custom_Export_Fields left outer join Custom_Export_Tab on cef_export_tab_id = cefstab_id ";
				SQL = $"{SQL}left outer join Custom_Export_Block on cef_export_block_id = cefsblk_id ";
				SQL = $"{SQL}where cef_evo_flag='Y' ";
				if (cbo_area.Text != "All")
				{
					SQL = $"{SQL}and cefstab_main_name = '{cbo_area.Text}' ";
				}
				SQL = $"{SQL}and cefstab_main_name = '{main_group}' and cefstab_sub_name  = '{sub_group}' ";
				SQL = $"{SQL}order by cefstab_main_name, cefstab_order, cef_sort, cef_display asc";
				cmd_sort_up.Visible = true;
				cmd_sort_down.Visible = true;
			}
			else
			{
				SQL = "SELECT * from Custom_Export_Fields left outer join Custom_Export_Tab on cef_export_tab_id = cefstab_id ";
				SQL = $"{SQL}left outer join Custom_Export_Block on cef_export_block_id = cefsblk_id ";
				SQL = $"{SQL}where cef_evo_flag='Y' ";
				if (cbo_area.Text != "All")
				{
					SQL = $"{SQL}and cefstab_main_name = '{cbo_area.Text}' ";
				}
				SQL = $"{SQL}order by cefstab_main_name, cefstab_order, cef_sort, cef_display asc";
				cmd_sort_up.Visible = false;
				cmd_sort_down.Visible = false;
			}


			ado_FieldList.Open(SQL, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

			while (!(ado_FieldList.EOF || ado_FieldList.BOF))
			{

				if (cbo_FieldGroups.Text != "All")
				{
					list_CustomFields.AddItem(($"{Convert.ToString(ado_FieldList["cef_display"])}").Trim());
				}
				else
				{
					list_CustomFields.AddItem($"{Convert.ToString(ado_FieldList["cefstab_sub_name"])}-{($"{Convert.ToString(ado_FieldList["cef_display"])}").Trim()}");
				}

				list_CustomFields.SetItemData(list_CustomFields.Items.Count - 1, Convert.ToInt32(ado_FieldList["cef_id"]));

				if (action_id == Convert.ToDouble(ado_FieldList["cef_id"]))
				{
					list_index_temp = Convert.ToInt32(Convert.ToDouble(list_CustomFields.Items.Count));
				}

				if (cbo_FieldGroups.Text != "All")
				{
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(ado_FieldList["cef_sort"]))
					{
						if (Convert.ToDouble(ado_FieldList["cef_sort"]) != Counter)
						{
							query_array[query_counter] = $" Update custom_export_fields set cef_sort = {Counter.ToString()} where cef_id = {Convert.ToString(ado_FieldList["cef_id"])}";
							query_counter++;
						}
					}
					else
					{
						query_array[query_counter] = $" Update custom_export_fields set cef_sort = {Counter.ToString()} where cef_id = {Convert.ToString(ado_FieldList["cef_id"])}";
						query_counter++;
					}
				}
				Counter++;

				ado_FieldList.MoveNext();
			}

			if (cbo_FieldGroups.Text != "All")
			{
				if (query_counter > 0)
				{
					int tempForEndVar = query_counter - 1;
					for (int I = 0; I <= tempForEndVar; I++)
					{
						DbCommand TempCommand = null;
						TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
						TempCommand.CommandText = query_array[I];
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
						TempCommand.ExecuteNonQuery();
					}
				}
			}

			if (Counter > 1)
			{
				frame_CustomField.Visible = true;
				if (list_index_temp == 0)
				{
					ListBoxHelper.SetSelectedIndex(list_CustomFields, 0);
				}
				else
				{
					ListBoxHelper.SetSelectedIndex(list_CustomFields, list_index_temp - 1);
				}
			}
			else
			{
				frame_CustomField.Visible = false;
			}

			ado_FieldList.Close();

		}

		public void Fill_Selected_Group_Drop_Down(string selected_group_text)
		{

			ADORecordSetHelper ado_FieldList = new ADORecordSetHelper(); //Current recordset

			cbo_selected_group.Items.Clear();

			string SQL = "SELECT distinct cefstab_sub_name,cefstab_order from Custom_Export_Tab "; //Current query sql
			if (cbo_tab.Text.Trim() != "")
			{
				SQL = $"{SQL}where cefstab_main_name='{cbo_tab.Text.Trim()}' ";
			}
			SQL = $"{SQL}group by cefstab_sub_name,cefstab_order order by cefstab_order asc";

			ado_FieldList.Open(SQL, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

			//cbo_selected_group.AddItem ("New")

			while (!ado_FieldList.EOF)
			{


				cbo_selected_group.AddItem(($"{Convert.ToString(ado_FieldList["cefstab_sub_name"])}").Trim());

				if (Convert.ToString(ado_FieldList["cefstab_sub_name"]).Trim() == selected_group_text)
				{
					cbo_selected_group.Text = selected_group_text;
				}


				ado_FieldList.MoveNext();
			}


			ado_FieldList.Close();


		}
		public void Fill_Selected_Field_Type_Drop_Down(string selected_field_type)
		{

			ADORecordSetHelper ado_FieldList = new ADORecordSetHelper(); //Current recordset

			cbo_field_type.Items.Clear();
			string SQL = "SELECT distinct cef_field_type from Custom_Export_Fields where cef_evo_flag='Y' "; //Current query sql
			SQL = $"{SQL} and cef_field_type <> '' order by cef_field_type asc";

			ado_FieldList.Open(SQL, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

			cbo_field_type.AddItem("New");

			while (!ado_FieldList.EOF)
			{


				cbo_field_type.AddItem(($"{Convert.ToString(ado_FieldList["cef_field_type"])}").Trim());

				if (Convert.ToString(ado_FieldList["cef_field_type"]).Trim() == selected_field_type)
				{
					cbo_field_type.Text = selected_field_type;
				}


				ado_FieldList.MoveNext();
			}


			ado_FieldList.Close();

		}

		public void Fill_Selected_Sub_Group_Drop_Down(string selected_sub_group_tex)
		{

			ADORecordSetHelper ado_FieldList = new ADORecordSetHelper(); //Current recordset

			cbo_selected_sub_group.Items.Clear();

			string SQL = "SELECT * from Custom_Export_Block order by cefsblk_name asc"; //Current query sql

			ado_FieldList.Open(SQL, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

			cbo_selected_sub_group.AddItem("New");

			while (!ado_FieldList.EOF)
			{


				cbo_selected_sub_group.AddItem(($"{Convert.ToString(ado_FieldList["cefsblk_name"])}").Trim());

				if (Convert.ToString(ado_FieldList["cefsblk_name"]).Trim() == selected_sub_group_tex)
				{
					cbo_selected_sub_group.Text = selected_sub_group_tex;
				}


				ado_FieldList.MoveNext();
			}


			ado_FieldList.Close();

		}
		public void Fill_Selected_Tab_Drop_Down(string selected_tab_text)
		{

			ADORecordSetHelper ado_FieldList = new ADORecordSetHelper(); //Current recordset

			cbo_tab.Items.Clear();


			string SQL = "SELECT distinct cefstab_main_name from Custom_Export_Tab order by cefstab_main_name"; //Current query sql

			ado_FieldList.Open(SQL, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);



			while (!ado_FieldList.EOF)
			{

				cbo_tab.AddItem(($"{Convert.ToString(ado_FieldList["cefstab_main_name"])}").Trim());

				if (Convert.ToString(ado_FieldList["cefstab_main_name"]).Trim() == selected_tab_text)
				{
					cbo_tab.Text = selected_tab_text;
				}


				ado_FieldList.MoveNext();
			}


			ado_FieldList.Close();


		}




		public object Fill_Field_Details(object selected_id = null)
		{

			string SQL = ""; //Current query sql
			ADORecordSetHelper ado_FieldList = new ADORecordSetHelper(); //Current recordset
			string sort_num = "";
			string temp_display = Convert.ToDouble(list_CustomFields.GetItemData(ListBoxHelper.GetSelectedIndex(list_CustomFields))).ToString();


			if (action_id > 0 && temp_display.Trim() == "")
			{
				temp_display = action_id.ToString();
			}
			if (temp_display.Trim() != "")
			{
				SQL = "SELECT *  from Custom_Export_Fields left outer join Custom_Export_Tab on cef_export_tab_id = cefstab_id ";
				SQL = $"{SQL}left outer join Custom_Export_Block on cef_export_block_id = cefsblk_id ";
				SQL = $"{SQL}where cef_evo_flag='Y' and cef_id= {temp_display} ";

				ado_FieldList.Open(SQL, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

				while (!ado_FieldList.EOF)
				{

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(ado_FieldList["cef_display"]))
					{
						txt_display_name.Text = Convert.ToString(ado_FieldList["cef_display"]).Trim();
					}
					else
					{
						txt_display_name.Text = "";
					}

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(ado_FieldList["cef_header_field_name"]))
					{
						txt_header_name.Text = Convert.ToString(ado_FieldList["cef_header_field_name"]).Trim();
					}
					else
					{
						txt_header_name.Text = "";
					}

					// FIELD DEFINITION
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(ado_FieldList["cef_definition"]))
					{
						txt_cef_definition.Text = Convert.ToString(ado_FieldList["cef_definition"]).Trim();
					}
					else
					{
						txt_cef_definition.Text = "";
					}

					// SELECT STATEMENT LIST FIELD
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(ado_FieldList["cef_list_select_query"]))
					{
						txt_cef_list_select_query.Text = StringsHelper.Replace(Convert.ToString(ado_FieldList["cef_list_select_query"]).Trim(), ":", "'", 1, -1, CompareMethod.Binary);
					}
					else
					{
						txt_cef_list_select_query.Text = "";
					}

					// VALUES/SELECT LIST FIELD
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(ado_FieldList["cef_values"]))
					{
						txt_cef_values.Text = Convert.ToString(ado_FieldList["cef_values"]).Trim();
					}
					else
					{
						txt_cef_values.Text = "";
					}

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(ado_FieldList["cef_sort"]))
					{
						sort_num = Convert.ToString(ado_FieldList["cef_sort"]).Trim();
					}
					else
					{
						sort_num = "1";
					}

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(ado_FieldList["cef_client_field_name"]))
					{
						lbl_client_field.Text = Convert.ToString(ado_FieldList["cef_client_field_name"]).Trim();
					}
					else
					{
						lbl_client_field.Text = "";
					}



					txt_field_name.Text = Convert.ToString(ado_FieldList["cef_evo_field_name"]).Trim();



					chk_summary_level.Enabled = !(((txt_field_name.Text.IndexOf("select") + 1) & ((Strings.Len(txt_field_name.Text) > 0) ? -1 : 0)) != 0);


					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(ado_FieldList["cef_field_length"]))
					{
						txt_length.Text = Convert.ToString(ado_FieldList["cef_field_length"]).Trim();
					}

					// THIS IS THE MAIN TAB DROP DOWN
					Fill_Selected_Tab_Drop_Down(Convert.ToString(ado_FieldList["cefstab_main_name"]).Trim());

					// THIS IS THE SUB TAB DROP DOWN
					Fill_Selected_Group_Drop_Down(Convert.ToString(ado_FieldList["cefstab_sub_name"]).Trim());

					// THIS IS THE SUB TAB DROP DOWN
					Fill_Selected_Sub_Group_Drop_Down(Convert.ToString(ado_FieldList["cefsblk_name"]).Trim());

					Fill_Selected_Field_Type_Drop_Down(Convert.ToString(ado_FieldList["cef_field_type"]).Trim());

					Fill_Help_Topic_List(Convert.ToInt32(ado_FieldList["cef_help_topic_id"]));

					cbo_sort.Items.Clear();
					for (int I = 1; I <= 100; I++)
					{

						cbo_sort.AddItem(I.ToString());

						if (Double.Parse(sort_num) == I)
						{
							cbo_sort.Text = sort_num;
						}
					}


					sort_num = Convert.ToString(ado_FieldList["cef_sub_group_sort"]);

					cbo_sub_number.Items.Clear();
					for (int I = 1; I <= 100; I++)
					{

						cbo_sub_number.AddItem(I.ToString());

						if (Double.Parse(sort_num) == I)
						{
							cbo_sub_number.Text = sort_num;
						}
					}


					if (txt_header_name.Text.Trim() != "" && txt_field_name.Text.Trim() != "")
					{
						btn_test_query.Visible = true;
						if (Convert.ToString(ado_FieldList["cef_sub_total_flag"]) == "Y")
						{
							cmd_run_summary_query.Visible = true;
						}
					}
					else
					{
						btn_test_query.Visible = false;
						cmd_run_summary_query.Visible = false;
					}

					if (Convert.ToString(ado_FieldList["cef_sub_total_flag"]) == "Y")
					{
						chk_summary_level.CheckState = CheckState.Checked;
					}
					else
					{
						chk_summary_level.CheckState = CheckState.Unchecked;
						cmd_run_summary_query.Visible = false;
					}

					if (Convert.ToString(ado_FieldList["cef_advanced_search_flag"]) == "Y")
					{
						chk_cef_advanced_search_flag.CheckState = CheckState.Checked;
					}
					else
					{
						chk_cef_advanced_search_flag.CheckState = CheckState.Unchecked;
					}



					if (Convert.ToString(ado_FieldList["cef_product_business_flag"]) == "Y")
					{
						chk_business.CheckState = CheckState.Checked;
					}
					else
					{
						chk_business.CheckState = CheckState.Unchecked;
					}

					if (Convert.ToString(ado_FieldList["cef_product_helicopter_flag"]) == "Y")
					{
						chk_helicopter.CheckState = CheckState.Checked;
					}
					else
					{
						chk_helicopter.CheckState = CheckState.Unchecked;
					}

					if (Convert.ToString(ado_FieldList["cef_product_commercial_flag"]) == "Y")
					{
						chk_comm.CheckState = CheckState.Checked;
					}
					else
					{
						chk_comm.CheckState = CheckState.Unchecked;
					}


					if (Convert.ToString(ado_FieldList["cef_product_yacht_flag"]) == "Y")
					{
						chk_yacht.CheckState = CheckState.Checked;
					}
					else
					{
						chk_yacht.CheckState = CheckState.Unchecked;
					}

					if (Convert.ToString(ado_FieldList["cef_product_aerodex_flag"]) == "Y")
					{
						chk_aero.CheckState = CheckState.Checked;
					}
					else
					{
						chk_aero.CheckState = CheckState.Unchecked;
					}




					lbl_cef_id.Text = Convert.ToString(ado_FieldList["cef_id"]);

					ado_FieldList.MoveNext();
				}


				ado_FieldList.Close();
				ado_FieldList = null;

			}

			return null;
		}


		public void Fill_Evo_Areas()
		{


			ADORecordSetHelper ado_FieldList = new ADORecordSetHelper(); //Current recordset



			cbo_area.Items.Clear();
			cbo_area.AddItem("All");

			string SQL = "SELECT distinct cefstab_main_name from Custom_Export_Tab "; //Current query sql
			SQL = $"{SQL}group by cefstab_main_name order by cefstab_main_name asc";

			ado_FieldList.Open(SQL, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);


			while (!ado_FieldList.EOF)
			{

				cbo_area.AddItem(($"{Convert.ToString(ado_FieldList["cefstab_main_name"])}").Trim());

				ado_FieldList.MoveNext();
			}


			ado_FieldList.Close();
			ado_FieldList = null;

			cbo_area.SelectedIndex = 0;
		}


		public void Fill_Makes()
		{

			ADORecordSetHelper ado_FieldList = new ADORecordSetHelper(); //Current recordset


			cbo_avionics[0].Items.Clear();
			cbo_avionics[0].AddItem("");

			string SQL = "SELECT distinct amod_make_name from Aircraft_Model  order by amod_make_name asc"; //Current query sql

			ado_FieldList.Open(SQL, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

			while (!ado_FieldList.EOF)
			{

				cbo_avionics[0].AddItem(($"{Convert.ToString(ado_FieldList["amod_make_name"])}").Trim());

				ado_FieldList.MoveNext();
			}


			ado_FieldList.Close();
			ado_FieldList = null;

			cbo_avionics[0].SelectedIndex = 0;
		}


		public void Fill_Models()
		{

			ADORecordSetHelper ado_FieldList = new ADORecordSetHelper(); //Current recordset


			cbo_avionics[1].Items.Clear();
			cbo_avionics[1].AddItem("");

			string SQL = $"SELECT distinct amod_model_name from Aircraft_Model where amod_make_name = '{cbo_avionics[0].Text}' "; //Current query sql

			SQL = $"{SQL}order by amod_model_name asc";


			ado_FieldList.Open(SQL, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);


			while (!ado_FieldList.EOF)
			{

				cbo_avionics[1].AddItem(($"{Convert.ToString(ado_FieldList["amod_model_name"])}").Trim());

				ado_FieldList.MoveNext();
			}


			ado_FieldList.Close();
			ado_FieldList = null;

			cbo_avionics[1].SelectedIndex = 0;
		}


		public void Fill_Avionics()
		{

			ADORecordSetHelper ado_FieldList = new ADORecordSetHelper(); //Current recordset


			cbo_avionics[2].Items.Clear();
			cbo_avionics[2].AddItem("");

			string SQL = " select distinct av_name, COUNT(distinct ac_id) as tcount from Aircraft_Avionics with (NOLOCK)"; //Current query sql
			SQL = $"{SQL} inner join Aircraft with (NOLOCK) on ac_id = av_ac_id and ac_journ_id = av_ac_journ_id";
			SQL = $"{SQL} inner join Aircraft_Model with (NOLOCK) on ac_amod_id = amod_id";
			SQL = $"{SQL} Where ac_journ_id = 0";

			if (cbo_avionics[0].Text.Trim() != "")
			{
				SQL = $"{SQL} and amod_make_name = '{cbo_avionics[0].Text}' ";
			}

			if (cbo_avionics[1].Text.Trim() != "")
			{
				SQL = $"{SQL} and amod_model_name = '{cbo_avionics[1].Text}' ";
			}

			SQL = $"{SQL} group by av_name  order by av_name ";
			ado_FieldList.Open(SQL, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);


			while (!ado_FieldList.EOF)
			{

				cbo_avionics[2].AddItem(($"{Convert.ToString(ado_FieldList["av_name"])}").Trim());

				ado_FieldList.MoveNext();
			}


			ado_FieldList.Close();
			ado_FieldList = null;

			cbo_avionics[2].SelectedIndex = 0;
		}


		public void Fill_Avionics_Found(string get_ac_side)
		{

			string SQL = ""; //Current query sql
			ADORecordSetHelper ado_FieldList = new ADORecordSetHelper(); //Current recordset
			int ac_count = 0;

			int record_count = 0;


			if (get_ac_side.Trim() == "Y")
			{
				SQL = " select distinct amod_make_name, amod_model_name, ac_ser_no_full, ac_id, ";

				if (txt_avionics[0].Text.Trim() != "" && lst_av_names[0].Text.Substring(0, Math.Min(lst_av_names[0].Text.Trim().IndexOf('|'), lst_av_names[0].Text.Length)).Trim() != txt_avionics[0].Text.Trim())
				{
					SQL = $"{SQL} (select COUNT(*) from Aircraft_Avionics av2 with (NOLOCK) where av2.av_ac_id = ac_id and  av2.av_ac_journ_id = ac_journ_id and av_description = '{txt_avionics[0].Text.Trim()}') as dcount";
				}
				else if (lbl_avionics[7].Text.Trim() != "")
				{  // then we clicked on 2nd column last
					SQL = $"{SQL} (select COUNT(*) from Aircraft_Avionics av2 with (NOLOCK) where av2.av_ac_id = ac_id and  av2.av_ac_journ_id = ac_journ_id and av_description = '{lbl_avionics[7].Text.Trim()}') as dcount";
				}
				else
				{
					SQL = $"{SQL}  0 as dcount";
				}

				lst_av_names[2].Items.Clear();
			}
			else
			{
				SQL = " select distinct av_description, COUNT(distinct ac_id) as tcount ";
				lst_av_names[0].Items.Clear();
				lst_av_names[1].Items.Clear();
			}


			SQL = $"{SQL} from Aircraft_Avionics with (NOLOCK) inner join Aircraft with (NOLOCK) on ac_id = av_ac_id and ac_journ_id = av_ac_journ_id";
			SQL = $"{SQL} inner join Aircraft_Model with (NOLOCK) on ac_amod_id = amod_id";
			SQL = $"{SQL} Where ac_journ_id = 0";

			if (cbo_avionics[0].Text.Trim() != "")
			{
				SQL = $"{SQL} and amod_make_name = '{cbo_avionics[0].Text}' ";
			}

			if (cbo_avionics[1].Text.Trim() != "")
			{
				SQL = $"{SQL} and amod_model_name = '{cbo_avionics[1].Text}' ";
			}

			if (cbo_avionics[2].Text.Trim() != "")
			{
				SQL = $"{SQL} and av_name = '{cbo_avionics[2].Text.Trim()}' ";
			}

			if (txt_avionics[1].Text.Trim() != "")
			{
				SQL = $"{SQL} and av_description like '%{txt_avionics[1].Text.Trim()}%' ";
			}

			if (get_ac_side.Trim() == "Y")
			{
				SQL = $"{SQL} and av_description = '{txt_avionics[0].Text.Trim()}' ";
			}
			else
			{
				SQL = $"{SQL} group by av_description  order by av_description asc ";
			}


			ado_FieldList.Open(SQL, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);


			while (!ado_FieldList.EOF)
			{


				if (get_ac_side.Trim() == "Y")
				{
					if (Convert.ToString(ado_FieldList["dcount"]).Trim() != "0")
					{
						lst_av_names[2].AddItem($"{($"{Convert.ToString(ado_FieldList["amod_make_name"])} ").Trim()} {($"{Convert.ToString(ado_FieldList["amod_model_name"])} ").Trim()}{($"{Convert.ToString(ado_FieldList["ac_ser_no_full"])} ").Trim()}  |({Convert.ToString(ado_FieldList["ac_id"])}) ****");
					}
					else
					{
						lst_av_names[2].AddItem($"{($"{Convert.ToString(ado_FieldList["amod_make_name"])} ").Trim()} {($"{Convert.ToString(ado_FieldList["amod_model_name"])} ").Trim()}{($"{Convert.ToString(ado_FieldList["ac_ser_no_full"])} ").Trim()}  |({Convert.ToString(ado_FieldList["ac_id"])})");
					}
				}
				else
				{
					lst_av_names[0].AddItem($"{($"{Convert.ToString(ado_FieldList["av_description"])}").Trim()}  |({Convert.ToString(ado_FieldList["tcount"])})");
					lst_av_names[1].AddItem($"{($"{Convert.ToString(ado_FieldList["av_description"])}").Trim()}  |({Convert.ToString(ado_FieldList["tcount"])})");
					record_count++;
					ac_count = Convert.ToInt32(ac_count + (Convert.ToDouble(ado_FieldList["tcount"])));
				}

				ado_FieldList.MoveNext();
			}



			if (ac_count > 0)
			{
				cmd_av_button[0].Visible = true;
				txt_avionics[0].Visible = true;
				cmd_av_button[4].Visible = true;
				cmd_av_button[5].Visible = false;
				txt_avionics[2].Visible = false;
			}
			else
			{
				cmd_av_button[4].Visible = false;
				cmd_av_button[5].Visible = false;
				txt_avionics[2].Visible = false;
			}

			if (get_ac_side.Trim() == "Y")
			{
			}
			else
			{
				lbl_avionics[6].Text = $"{record_count.ToString()} Records Found, {ac_count.ToString()} Aircraft ";
			}
			ado_FieldList.Close();

		}


		public object Get_PrimaryTab_ID(string inMainTab, string inSubTab)
		{

			object result = null;
			string SQL = "";
			try
			{
				 //Current query sql
				ADORecordSetHelper ado_Gat_Tab_ID = new ADORecordSetHelper(); //Current recordset



				SQL = "SELECT cefstab_id  from Custom_Export_Tab ";
				SQL = $"{SQL}where cefstab_main_name = '{inMainTab}' and cefstab_sub_name = '{inSubTab}' ";


				ado_Gat_Tab_ID.Open(SQL, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

				if (!(ado_Gat_Tab_ID.EOF || ado_Gat_Tab_ID.BOF))
				{
					result = ado_Gat_Tab_ID["cefstab_id"];
				}
				else
				{
					result = 0;
				}


				ado_Gat_Tab_ID.Close();
				ado_Gat_Tab_ID = null;
			}
			catch
			{
				MessageBox.Show($"Get_PrimaryTab_ID_Error: Error in getting tab id.. {SQL}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
			return result;
		}

		public object Get_Block_ID(string inBlock)
		{
			object result = null;
			string SQL = "";
			try
			{
				 //Current query sql
				ADORecordSetHelper ado_Get_Block_ID = new ADORecordSetHelper(); //Current recordset


				SQL = $"SELECT cefsblk_id from Custom_Export_Block  where cefsblk_name= '{inBlock}' ";

				ado_Get_Block_ID.Open(SQL, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

				if (!(ado_Get_Block_ID.EOF || ado_Get_Block_ID.BOF))
				{
					result = ado_Get_Block_ID["cefsblk_id"];
				}
				else
				{
					result = 0;
				}


				ado_Get_Block_ID.Close();
				ado_Get_Block_ID = null;
			}
			catch
			{
				MessageBox.Show($"Get_Block_ID_Error: Error in getting block id.. {SQL}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
			return result;
		}

		public void Fill_Help_Topic_List(int inTopicID)
		{

			ADORecordSetHelper ado_HelpList = new ADORecordSetHelper(); //Current recordset
			int topiclength = Strings.Len(inTopicID.ToString());
			int topicindex = 0;
			int helpcounter = 0;

			if (inTopicID == 0)
			{
				topicindex = 0;
			}

			cbo_Help_Topic.Items.Clear();
			cbo_Help_Topic.AddItem("0-No Help Topic Assigned");

			string SQL = "SELECT evonot_id, evonot_title from Evolution_Notifications where evonot_active_flag='Y' "; //Current query sql
			SQL = $"{SQL}and evonot_release_type='H' order by evonot_title";

			ado_HelpList.Open(SQL, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);



			while (!ado_HelpList.EOF)
			{


				cbo_Help_Topic.AddItem($"{Convert.ToString(ado_HelpList["evonot_id"])}-{($"{Convert.ToString(ado_HelpList["evonot_title"])}").Trim()}");
				helpcounter++;
				if (($"{Convert.ToString(ado_HelpList["evonot_id"])}-{($"{Convert.ToString(ado_HelpList["evonot_title"])}").Trim()}").StartsWith($"{inTopicID.ToString()}-", StringComparison.Ordinal))
				{
					topicindex = helpcounter;
				}

				ado_HelpList.MoveNext();
			}


			ado_HelpList.Close();
			ado_HelpList = null;

			cbo_Help_Topic.SelectedIndex = topicindex;
		}
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}