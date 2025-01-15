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
using UpgradeStubs;

namespace JETNET_Homebase
{
	internal partial class frm_Sale_Prices
		: System.Windows.Forms.Form
	{

		public frm_Sale_Prices()
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


		private void frm_Sale_Prices_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		public DbConnection REMOTE_ADO_DB = null;
		public bool AlreadyOpen = false;
		public int is_remove = 0;
		public int journ_remove = 0;

		public string create_insert_string()
		{
			string result = "";
			int temp_id = 0;
			StringBuilder iistring = new StringBuilder();
			string Query = "";
			ADORecordSetHelper ado_company = new ADORecordSetHelper();


			if (OpenRemoteDatabase())
			{

				temp_id = grd_ac_sale.get_RowData(grd_ac_sale.CurrentRowIndex);

				Query = " select * from Aircraft_Value with (NOLOCK)  ";

				if (temp_id > 0)
				{
					Query = $"{Query} Where acval_id = {temp_id.ToString()} ";
					Query = $"{Query} And acval_ac_id = {lbl_ac_id.Text} And acval_journ_id = {lbl_journ_id.Text}";
				}
				else
				{
					Query = $"{Query} Where acval_ac_id = {lbl_ac_id.Text} And acval_journ_id = {lbl_journ_id.Text}";
				}


				ado_company.CursorLocation = CursorLocationEnum.adUseClient;
				ado_company.Open(Query, REMOTE_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);

				if (!ado_company.BOF && !ado_company.EOF)
				{


					do 
					{

						iistring = new StringBuilder("");
						iistring.Append(" INSERT INTO  Aircraft_Value  (acval_type ,acval_entry_date");
						iistring.Append(" ,acval_date  ,acval_sub_id  ,acval_login ,acval_seq_no");
						iistring.Append(" ,acval_contact_name ,acval_amod_id  ,acval_ac_id  ,acval_journ_id");
						iistring.Append(" ,acval_airframe_tot_hrs ,acval_airframe_tot_landings ,acval_asking_price");
						iistring.Append(" ,acval_take_price  ,acval_est_price ,acval_sale_price");
						iistring.Append(" ,acval_webaction_date ,acval_notes,acval_display_flag");
						iistring.Append(" ,acval_process_status,acval_comp_id,acval_primary_price_flag");
						iistring.Append(" ,acval_primary_price_notes) Values ('XXXXX'");
						iistring.Append($" , Getdate() ,'{Convert.ToString(ado_company["acval_date"])}' ");
						iistring.Append($"  ,'{Convert.ToString(ado_company["acval_sub_id"])}' ,'{Convert.ToString(ado_company["acval_login"])}' ");
						iistring.Append($" ,'{Convert.ToString(ado_company["acval_seq_no"])}' ");
						iistring.Append($" ,'{Convert.ToString(ado_company["acval_contact_name"])}' ");
						iistring.Append($" ,'{Convert.ToString(ado_company["acval_amod_id"])}'  ,'{Convert.ToString(ado_company["acval_ac_id"])}' ");
						iistring.Append($" ,'{Convert.ToString(ado_company["acval_journ_id"])}'  ,'{Convert.ToString(ado_company["acval_airframe_tot_hrs"])}' ");
						iistring.Append($"  ,'{Convert.ToString(ado_company["acval_airframe_tot_landings"])}' ");
						iistring.Append($" ,'{Convert.ToString(ado_company["acval_asking_price"])}' ,'{Convert.ToString(ado_company["acval_take_price"])}' ");
						iistring.Append($" ,'{Convert.ToString(ado_company["acval_est_price"])}' ,'{Convert.ToString(ado_company["acval_sale_price"])}' ");
						iistring.Append($" ,'1/1/1900' ,'{Convert.ToString(ado_company["acval_notes"])}' ");
						iistring.Append($" ,'{Convert.ToString(ado_company["acval_display_flag"])}' ,'{Convert.ToString(ado_company["acval_process_status"])}' ");
						iistring.Append($"  ,'{Convert.ToString(ado_company["acval_comp_id"])}'  ,'{Convert.ToString(ado_company["acval_primary_price_flag"])}' ");
						iistring.Append($" ,'{StringsHelper.Replace(txt_update_note.Text, "'", "", 1, -1, CompareMethod.Binary)}' )");


						ado_company.MoveNext();
						Application.DoEvents();

					}
					while(!ado_company.EOF);

				}
			}


			if (iistring.ToString().Trim() != "")
			{
				result = iistring.ToString();
			}


			CloseRemoteDatabase();


			return result;
		}

		public void make_selections(ref string Query, string order_by)
		{

			Query = "";

			if (StringsHelper.ToDoubleSafe(cbo_search_type.SelectedIndex.ToString().Trim()) == -1 || StringsHelper.ToDoubleSafe(cbo_search_type.SelectedIndex.ToString().Trim()) == 1)
			{

				Query = $"{Query} select distinct amod_make_name, amod_model_name, ac_ser_no_full, ac_id, journ_date, journ_subject, journ_id,";
				Query = $"{Query} ac_sale_price as SALEPRICECURRENT,";
				Query = $"{Query} (select top 1 v1.acval_sale_price from Aircraft_Value v1 with (NOLOCK)";
				Query = $"{Query} where ((v1.acval_sale_price > (a.ac_sale_price * 1.05)) Or (v1.acval_sale_price < (a.ac_sale_price * 0.95)))";
				Query = $"{Query} and v1.acval_sale_price > 0 and v1.acval_ac_id = journal.journ_ac_id and v1.acval_journ_id = Journal.journ_id and v1.acval_comp_id <> v.acval_comp_id";
				Query = $"{Query} ) as SALEPRICE2  from Aircraft  a with (NOLOCK)";
				Query = $"{Query} inner join Aircraft_Model with (NOLOCK) on amod_id = ac_amod_id";
				Query = $"{Query} inner join journal with (NOLOCK) on journ_id = ac_journ_id and journ_ac_id = ac_id";
				Query = $"{Query} inner join Aircraft_Value v with (NOLOCK) on acval_id = ac_sale_price_acval_id and acval_primary_price_flag='N'";
				Query = $"{Query} where ac_sale_price > 0 and ac_sale_price_display_flag='Y'";
				Query = $"{Query} and v.acval_journ_id in ( select distinct acval_journ_id from Aircraft_Value with (NOLOCK)";
				Query = $"{Query} Where ((acval_sale_price > (a.ac_sale_price * 1.05)) Or (acval_sale_price < (a.ac_sale_price * 0.95)))";
				Query = $"{Query}  and acval_sale_price > 0 and acval_ac_id = journal.journ_ac_id and acval_journ_id = Journal.journ_id and acval_comp_id <> v.acval_comp_id";
				Query = $"{Query} )  and acval_type <> 'CLEAR' ";

				if (order_by.Trim() != "")
				{
					Query = $"{Query} order by {order_by.Trim()}";
				}
				else
				{
					Query = $"{Query} order by amod_make_name, amod_model_name, ac_ser_no_full ";
				}

			}
			else if (StringsHelper.ToDoubleSafe(cbo_search_type.SelectedIndex.ToString().Trim()) == 2)
			{ 

				Query = $"{Query} select distinct amod_make_name, amod_model_name, ac_ser_no_full, ac_id, journ_date, journ_subject, journ_id,acval_type,";
				Query = $"{Query} count(distinct comp_id) as SOURCES,";
				Query = $"{Query} STUFF( (select ';' + cast(cast((acval_sale_price/1000) as int) as varchar(20)) + 'k' from Aircraft_Value where acval_journ_id = journ_id for XML path ('')),1,1,'') as SALEPRICECURRENT";
				Query = $"{Query} from Aircraft_Value with (NOLOCK)";
				Query = $"{Query} inner join Aircraft  with (NOLOCK) on acval_journ_id = ac_journ_id and ac_id = acval_ac_id";
				Query = $"{Query} inner join Aircraft_Model with (NOLOCK) on amod_id = ac_amod_id";
				Query = $"{Query} inner join journal with (NOLOCK) on journ_id = acval_journ_id and journ_ac_id = acval_ac_id";
				Query = $"{Query} left outer join Subscription with (NOLOCK) on acval_sub_id = sub_id";
				Query = $"{Query} inner join Company with (NOLOCK) on acval_comp_id = comp_id and comp_journ_id = 0";
				Query = $"{Query} Where acval_sale_price > 0 and not exists(select distinct av2.acval_ac_id from aircraft_value av2 with (NOLOCK) where av2.acval_ac_id = aircraft_value.acval_ac_id and av2.acval_journ_id  = aircraft_value.acval_journ_id and av2.acval_primary_price_flag = 'Y') ";
				Query = $"{Query} group by amod_make_name, amod_model_name, ac_ser_no_full, ac_id, journ_date, journ_subject, journ_id, acval_type";
				Query = $"{Query} having count(distinct comp_id) > 1 and acval_type <> 'CLEAR' ";
				Query = $"{Query} and journ_date >= getdate()-(365*4) "; // added MSW - 10/13/2020 - only deal with last 4 years

				if (order_by.Trim() != "")
				{
					Query = $"{Query} order by {order_by.Trim()}";
				}
				else
				{
					Query = $"{Query} order by SOURCES desc";
				}


			}
			else if (StringsHelper.ToDoubleSafe(cbo_search_type.SelectedIndex.ToString().Trim()) == 3)
			{ 

				Query = $"{Query} select distinct (comp_name + ' - ' + acval_contact_name) as SUBMITTEDBY,";
				Query = $"{Query} amod_make_name, amod_model_name, ac_ser_no_full, ac_id, journ_date, journ_subject,";
				Query = $"{Query} acval_sale_price as CUSTSOLD, amod_start_price, amod_end_price,acval_asking_price as CUSTASKING,";
				Query = $"{Query} acval_entry_date as SUBMITTEDON, journ_id, acval_process_status as PSTATUS, acval_id as ACVALID, sub_id as SUBID, journ_subcategory_code as TRANSTYPE,";
				Query = $"{Query} journ_ac_id as ACID, journ_id as JOURNID, journ_newac_flag, comp_id as COMPID,";
				Query = $"{Query}  acval_webaction_date , acval_notes, ac_sale_price";
				Query = $"{Query}   , (select COUNT(*) from Aircraft_Value av2 with (NOLOCK) where acval_type = 'CLEAR' and av2.acval_ac_id = Aircraft_Value.acval_ac_id and av2.acval_journ_id = Aircraft_Value.acval_journ_id) as count_cleared ";
				Query = $"{Query}  , (select COUNT(*) from Aircraft_Value av3 with (NOLOCK) where acval_type <> 'CLEAR' and av3.acval_ac_id = Aircraft_Value.acval_ac_id and av3.acval_journ_id <> Aircraft_Value.acval_journ_id and av3.acval_id > Aircraft_Value.acval_id) as count_after ";

				Query = $"{Query} from Aircraft_Value with (NOLOCK) inner join Aircraft  with (NOLOCK) on acval_journ_id = ac_journ_id and ac_id = acval_ac_id";
				Query = $"{Query} inner join Aircraft_Model with (NOLOCK) on amod_id = ac_amod_id";
				Query = $"{Query} inner join journal with (NOLOCK) on journ_id = acval_journ_id and journ_ac_id = acval_ac_id";
				Query = $"{Query} left outer join Subscription with (NOLOCK) on acval_sub_id = sub_id";
				Query = $"{Query} inner join Company with (NOLOCK) on acval_comp_id = comp_id and comp_journ_id = 0";
				Query = $"{Query} Where acval_sale_price > 0 and  ac_sale_price_display_flag = 'N'";
				Query = $"{Query} and acval_type <> 'CLEAR' ";

				// and doesnt have a cleared record for that price/date/journal
				Query = $"{Query}  and not exists( select a2.acval_ac_id";
				Query = $"{Query} from Aircraft_Value a2";
				Query = $"{Query} Where a2.acval_ac_id = Aircraft_Value.acval_ac_id";
				Query = $"{Query} and a2.acval_date = Aircraft_Value.acval_date";
				Query = $"{Query} and a2.acval_journ_id = Aircraft_Value.acval_journ_id";
				Query = $"{Query}  and a2.acval_sale_price = Aircraft_Value.acval_sale_price";
				Query = $"{Query} and acval_type = 'CLEAR'     )";


				if (order_by.Trim() != "")
				{
					Query = $"{Query} order by {order_by.Trim()}";
				}
				else
				{
					Query = $"{Query} order by amod_make_name, amod_model_name";
				}

			}
			else if (StringsHelper.ToDoubleSafe(cbo_search_type.SelectedIndex.ToString().Trim()) == 4)
			{  // internal

				Query = $"{Query} select distinct (comp_name + ' - ' + acval_contact_name) as SUBMITTEDBY,";
				Query = $"{Query} amod_make_name, amod_model_name, ac_ser_no_full, ac_id, journ_date, journ_subject,";
				Query = $"{Query} acval_sale_price as CUSTSOLD, amod_start_price, amod_end_price,acval_asking_price as CUSTASKING,";
				Query = $"{Query} acval_entry_date as SUBMITTEDON, journ_id, acval_process_status as PSTATUS, acval_id as ACVALID, sub_id as SUBID, journ_subcategory_code as TRANSTYPE,";
				Query = $"{Query} journ_ac_id as ACID, journ_id as JOURNID, journ_newac_flag, comp_id as COMPID,";
				Query = $"{Query}  acval_webaction_date , acval_notes";
				Query = $"{Query} from Aircraft_Value with (NOLOCK)  inner join Aircraft  with (NOLOCK) on acval_journ_id = ac_journ_id and ac_id = acval_ac_id";
				Query = $"{Query} inner join Aircraft_Model with (NOLOCK) on amod_id = ac_amod_id";
				Query = $"{Query} inner join journal with (NOLOCK) on journ_id = acval_journ_id and journ_ac_id = acval_ac_id";
				Query = $"{Query} left outer join Subscription with (NOLOCK) on acval_sub_id = sub_id";
				Query = $"{Query} inner join Company with (NOLOCK) on acval_comp_id = comp_id and comp_journ_id = 0";
				Query = $"{Query} Where acval_sale_price > 0 and (journ_internal_trans_flag = 'Y') ";
				Query = $"{Query} and acval_type <> 'CLEAR' ";

				if (order_by.Trim() != "")
				{
					Query = $"{Query} order by {order_by.Trim()}";
				}
				else
				{
					Query = $"{Query} order by amod_make_name, amod_model_name";
				}

			}
			else if (StringsHelper.ToDoubleSafe(cbo_search_type.SelectedIndex.ToString().Trim()) == 5)
			{  // non-retail sales

				Query = $"{Query} select distinct (comp_name + ' - ' + acval_contact_name) as SUBMITTEDBY,";
				Query = $"{Query} amod_make_name, amod_model_name, ac_ser_no_full, ac_id, journ_date, journ_subject,";
				Query = $"{Query} acval_sale_price as CUSTSOLD, amod_start_price, amod_end_price,acval_asking_price as CUSTASKING,";
				Query = $"{Query} acval_entry_date as SUBMITTEDON, journ_id, acval_process_status as PSTATUS, acval_id as ACVALID, sub_id as SUBID, journ_subcategory_code as TRANSTYPE,";
				Query = $"{Query} journ_ac_id as ACID, journ_id as JOURNID, journ_newac_flag, comp_id as COMPID,";
				Query = $"{Query}  acval_webaction_date , acval_notes , (select count(*) from Aircraft a2 with (NOLOCK)";
				Query = $"{Query} inner join Journal j2 with (NOLOCK) on j2.journ_ac_id = a2.ac_id and j2.journ_id = a2.ac_journ_id";
				Query = $"{Query} Where j2.journ_date = Journal.journ_date";
				Query = $"{Query} and a2.ac_id = aircraft.ac_id and (a2.ac_sale_price = 0 or a2.ac_sale_price is null)";
				Query = $"{Query} and j2.journ_subcat_code_part3 not IN ('DB','DS','FI','FY','IT','MF','RE','CC','LS', 'RM') and j2.journ_subcat_code_part1='WS'";
				Query = $"{Query} AND j2.journ_internal_trans_flag='N') as scount ";

				Query = $"{Query} from Aircraft_Value with (NOLOCK) inner join Aircraft  with (NOLOCK) on acval_journ_id = ac_journ_id and ac_id = acval_ac_id";
				Query = $"{Query} inner join Aircraft_Model with (NOLOCK) on amod_id = ac_amod_id";
				Query = $"{Query} inner join journal with (NOLOCK) on journ_id = acval_journ_id and journ_ac_id = acval_ac_id";
				Query = $"{Query} left outer join Subscription with (NOLOCK) on acval_sub_id = sub_id";
				Query = $"{Query} inner join Company with (NOLOCK) on acval_comp_id = comp_id and comp_journ_id = 0";
				Query = $"{Query} Where acval_sale_price > 0 and (journ_subcat_code_part3 IN ('DB','DS','FI','FY','IT','MF','RE','CC','LS', 'RM')) ";
				Query = $"{Query} and acval_type <> 'CLEAR' ";

				if (order_by.Trim() != "")
				{
					Query = $"{Query} order by {order_by.Trim()}";
				}
				else
				{
					Query = $"{Query} order by amod_make_name, amod_model_name";
				}

			}


		}

		private void button_hide_Click(Object eventSender, EventArgs eventArgs)
		{

			ADORecordSetHelper ado_company = new ADORecordSetHelper();

			string temp_insert = create_insert_string();
			temp_insert = StringsHelper.Replace(temp_insert, "XXXXX", "HIDE", 1, -1, CompareMethod.Binary);

			if (OpenRemoteDatabase())
			{

				ado_company.CursorLocation = CursorLocationEnum.adUseClient;
				ado_company.Open(temp_insert, REMOTE_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);


			}

			CloseRemoteDatabase();

			lbl_update.Visible = true;

		}

		private void cbo_search_type_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs)
		{

			find_sale_prices_out_of_range("");

			frm_update_click.Visible = false;

		}

		private void clear_button_Click(Object eventSender, EventArgs eventArgs)
		{

			ADORecordSetHelper ado_company = new ADORecordSetHelper();


			string temp_insert = create_insert_string();
			temp_insert = StringsHelper.Replace(temp_insert, "XXXXX", "CLEAR", 1, -1, CompareMethod.Binary);


			if (OpenRemoteDatabase())
			{

				ado_company.CursorLocation = CursorLocationEnum.adUseClient;
				ado_company.Open(temp_insert, REMOTE_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);


			}

			CloseRemoteDatabase();

			lbl_update.Visible = true;

		}
		private void cmd_Refresh_Click(Object eventSender, EventArgs eventArgs) => find_sale_prices_out_of_range("");


		private void find_sale_prices_out_of_range(string order_by)
		{
			object cmd_select_company = null; //gap-note cmd_select_company belongs to frmYacht and this form seems to be obsolete.


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
			bool pass_test = false;

			try
			{


				current_color = ColorTranslator.ToOle(Color.White).ToString();
				HiddenColor = (0xE0E0E0).ToString();

				grd_sale_prices.Visible = false;
				grd_sale_prices.Enabled = false;
				pass_test = false;

				grd_sale_prices.Clear();


				grd_sale_prices.ColumnsCount = 10;
				grd_sale_prices.RowsCount = 2;

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
				grd_sale_prices.SetColumnWidth(grd_sale_prices.CurrentColumnIndex, 70);
				grd_sale_prices.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = "Journ Date";

				grd_sale_prices.CurrentColumnIndex = 3;

				if (StringsHelper.ToDoubleSafe(cbo_search_type.SelectedIndex.ToString().Trim()) == 4 || StringsHelper.ToDoubleSafe(cbo_search_type.SelectedIndex.ToString().Trim()) == 5)
				{
					grd_sale_prices.SetColumnWidth(grd_sale_prices.CurrentColumnIndex, 307);
				}
				else
				{
					grd_sale_prices.SetColumnWidth(grd_sale_prices.CurrentColumnIndex, 333);
				}


				grd_sale_prices.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = "Journ Subject";

				grd_sale_prices.CurrentColumnIndex = 4;
				grd_sale_prices.SetColumnWidth(grd_sale_prices.CurrentColumnIndex, 60);
				grd_sale_prices.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = "Journ ID";


				grd_sale_prices.CurrentColumnIndex = 5;
				grd_sale_prices.SetColumnWidth(grd_sale_prices.CurrentColumnIndex, 0);
				grd_sale_prices.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = "ACID";


				if (StringsHelper.ToDoubleSafe(cbo_search_type.SelectedIndex.ToString().Trim()) == -1 || StringsHelper.ToDoubleSafe(cbo_search_type.SelectedIndex.ToString().Trim()) == 1)
				{


					grd_sale_prices.CurrentColumnIndex = 6;
					grd_sale_prices.SetColumnWidth(grd_sale_prices.CurrentColumnIndex, 97);
					grd_sale_prices.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
					grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = "Sales Price Current";

					grd_sale_prices.CurrentColumnIndex = 7;
					grd_sale_prices.SetColumnWidth(grd_sale_prices.CurrentColumnIndex, 73);
					grd_sale_prices.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
					grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = "Sales Price 2";

					cmd_update_selected.Text = "Set as Primary Sale Price";

				}
				else if (StringsHelper.ToDoubleSafe(cbo_search_type.SelectedIndex.ToString().Trim()) == 2)
				{ 

					grd_sale_prices.CurrentColumnIndex = 6;
					grd_sale_prices.SetColumnWidth(grd_sale_prices.CurrentColumnIndex, 47);
					grd_sale_prices.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
					grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = "Sources";

					grd_sale_prices.CurrentColumnIndex = 7;
					grd_sale_prices.SetColumnWidth(grd_sale_prices.CurrentColumnIndex, 120);
					grd_sale_prices.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
					grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = "Sales Prices";

					cmd_update_selected.Text = "Set as Primary Sale Price";


				}
				else if (StringsHelper.ToDoubleSafe(cbo_search_type.SelectedIndex.ToString().Trim()) == 3)
				{ 


					grd_sale_prices.CurrentColumnIndex = 6;
					grd_sale_prices.SetColumnWidth(grd_sale_prices.CurrentColumnIndex, 163);
					grd_sale_prices.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
					grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = "Submitted On/By";

					grd_sale_prices.CurrentColumnIndex = 7;
					grd_sale_prices.SetColumnWidth(grd_sale_prices.CurrentColumnIndex, 50);
					grd_sale_prices.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
					grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = "Asking";

					grd_sale_prices.CurrentColumnIndex = 8;
					grd_sale_prices.SetColumnWidth(grd_sale_prices.CurrentColumnIndex, 67);
					grd_sale_prices.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
					grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = "TransType";

					grd_sale_prices.CurrentColumnIndex = 9;
					grd_sale_prices.SetColumnWidth(grd_sale_prices.CurrentColumnIndex, 667);
					grd_sale_prices.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
					grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = "STATUS";
					// ,SUBID, , journ_newac_flag, acval_webaction_date , acval_notes

					cmd_update_selected.Text = "Allow Out of Range Price";

				}
				else if (StringsHelper.ToDoubleSafe(cbo_search_type.SelectedIndex.ToString().Trim()) == 4)
				{ 

					grd_sale_prices.CurrentColumnIndex = 6;
					grd_sale_prices.SetColumnWidth(grd_sale_prices.CurrentColumnIndex, 150);
					grd_sale_prices.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
					grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = "Submitted On/By";

					grd_sale_prices.CurrentColumnIndex = 7;
					grd_sale_prices.SetColumnWidth(grd_sale_prices.CurrentColumnIndex, 47);
					grd_sale_prices.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
					grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = "Asking";

					grd_sale_prices.CurrentColumnIndex = 8;
					grd_sale_prices.SetColumnWidth(grd_sale_prices.CurrentColumnIndex, 47);
					grd_sale_prices.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
					grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = "Sold";

				}
				else if (StringsHelper.ToDoubleSafe(cbo_search_type.SelectedIndex.ToString().Trim()) == 5)
				{ 

					grd_sale_prices.CurrentColumnIndex = 6;
					grd_sale_prices.SetColumnWidth(grd_sale_prices.CurrentColumnIndex, 150);
					grd_sale_prices.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
					grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = "Submitted On/By";

					grd_sale_prices.CurrentColumnIndex = 7;
					grd_sale_prices.SetColumnWidth(grd_sale_prices.CurrentColumnIndex, 47);
					grd_sale_prices.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
					grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = "Asking";

					grd_sale_prices.CurrentColumnIndex = 8;
					grd_sale_prices.SetColumnWidth(grd_sale_prices.CurrentColumnIndex, 47);
					grd_sale_prices.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
					grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = "Sold";

				}


				if (StringsHelper.ToDoubleSafe(cbo_search_type.SelectedIndex.ToString().Trim()) < 3)
				{
					grd_sale_prices.CurrentColumnIndex = 8;
					grd_sale_prices.SetColumnWidth(grd_sale_prices.CurrentColumnIndex, 0);
					grd_sale_prices.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
					grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = "";

					grd_sale_prices.CurrentColumnIndex = 9;
					grd_sale_prices.SetColumnWidth(grd_sale_prices.CurrentColumnIndex, 0);
					grd_sale_prices.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
					grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = "";
				}



				Query = "";

				make_selections(ref Query, order_by);

				if (OpenRemoteDatabase())
				{
					ado_company.CursorLocation = CursorLocationEnum.adUseClient;
					ado_company.Open(Query, REMOTE_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);

					if (!ado_company.BOF && !ado_company.EOF)
					{

						if (ado_company.RecordCount <= 1500)
						{


							lRow = 0;
							//frame_search.Caption = "Search - Found " & Format(ado_Company.RecordCount, "#,##0") & " Record(s)"
							Application.DoEvents();
							strLastContact = "";

							do 
							{ // Loop Until ado_Company.EOF = True
								current_color = ColorTranslator.ToOle(Color.White).ToString();
								if (StringsHelper.ToDoubleSafe(cbo_search_type.SelectedIndex.ToString().Trim()) == 5)
								{
									if (Convert.ToInt32(ado_company["scount"]) > 0)
									{
										current_color = ColorTranslator.ToOle(Color.Red).ToString(); // current_color = &HC0FFC0
									}
								}

								//added MSW - if there is no sale price on the current record, and there is a cleared record in there, then it shouldnt show up on the grid
								pass_test = true;
								if (StringsHelper.ToDoubleSafe(cbo_search_type.SelectedIndex.ToString().Trim()) == 3)
								{
									//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
									if (!Convert.IsDBNull(ado_company["ac_sale_price"]))
									{
										if (Convert.ToDouble(ado_company["ac_sale_price"]) == 0 && Convert.ToDouble(ado_company["count_cleared"]) > 0)
										{
											pass_test = false;
										}
									}
									else if (Convert.ToDouble(ado_company["count_cleared"]) > 0)
									{  // if the sale price is null, and it was cleared
										pass_test = false;
									}
								}

								if (pass_test)
								{

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
									grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
									grd_sale_prices.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(current_color)));
									grd_sale_prices.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
									//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
									if (!Convert.IsDBNull(ado_company["journ_date"]))
									{
										grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = Convert.ToString(ado_company["journ_date"]).Trim();
									}

									grd_sale_prices.CurrentColumnIndex = 3;
									grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
									grd_sale_prices.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(current_color)));
									grd_sale_prices.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
									//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
									if (!Convert.IsDBNull(ado_company["journ_subject"]))
									{
										grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = Convert.ToString(ado_company["journ_subject"]).Trim();
									}

									grd_sale_prices.CurrentColumnIndex = 4;
									grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
									grd_sale_prices.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(current_color)));
									grd_sale_prices.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
									//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
									if (!Convert.IsDBNull(ado_company["journ_id"]))
									{
										grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = Convert.ToString(ado_company["journ_id"]).Trim();
									}


									grd_sale_prices.CurrentColumnIndex = 5;
									grd_sale_prices.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(current_color)));
									grd_sale_prices.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
									grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = ($"{Convert.ToString(ado_company["ac_id"])} ").Trim();



									if (StringsHelper.ToDoubleSafe(cbo_search_type.SelectedIndex.ToString().Trim()) == -1 || StringsHelper.ToDoubleSafe(cbo_search_type.SelectedIndex.ToString().Trim()) == 1)
									{


										grd_sale_prices.CurrentColumnIndex = 6;
										grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
										grd_sale_prices.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(current_color)));
										grd_sale_prices.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
										//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
										if (!Convert.IsDBNull(ado_company["SALEPRICECURRENT"]))
										{
											grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = $"{Double.Parse((Double.Parse(Convert.ToString(ado_company["SALEPRICECURRENT"]).Trim()) / 1000d).ToString(), NumberStyles.Any).ToString("N0")}k";
										}

										grd_sale_prices.CurrentColumnIndex = 7;
										grd_sale_prices.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(current_color)));
										grd_sale_prices.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
										grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = $"{Double.Parse((Double.Parse(Convert.ToString(ado_company["SALEPRICE2"]).Trim()) / 1000d).ToString(), NumberStyles.Any).ToString("N0")}k";

									}
									else if (StringsHelper.ToDoubleSafe(cbo_search_type.SelectedIndex.ToString().Trim()) == 2)
									{ 


										grd_sale_prices.CurrentColumnIndex = 6;
										grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
										grd_sale_prices.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(current_color)));
										grd_sale_prices.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
										//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
										if (!Convert.IsDBNull(ado_company["SOURCES"]))
										{
											grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = Convert.ToString(ado_company["SOURCES"]).Trim();
										}


										grd_sale_prices.CurrentColumnIndex = 7;
										grd_sale_prices.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(current_color)));
										grd_sale_prices.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
										grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = ($"{Convert.ToString(ado_company["SALEPRICECURRENT"])} ").Trim();

									}
									else if (StringsHelper.ToDoubleSafe(cbo_search_type.SelectedIndex.ToString().Trim()) == 3)
									{ 


										grd_sale_prices.CurrentColumnIndex = 6;
										grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
										grd_sale_prices.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(current_color)));
										grd_sale_prices.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
										//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
										if (!Convert.IsDBNull(ado_company["SUBMITTEDON"]))
										{
											grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = DateTime.Parse(Convert.ToString(ado_company["SUBMITTEDON"]).Trim()).ToString("d");
										}

										//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
										if (!Convert.IsDBNull(ado_company["SUBMITTEDBY"]))
										{
											grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = $"{grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].FormattedValue.ToString()} - {Convert.ToString(ado_company["SUBMITTEDBY"]).Trim()}";
										}

										grd_sale_prices.CurrentColumnIndex = 7;
										grd_sale_prices.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(current_color)));
										grd_sale_prices.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
										if (Convert.ToDouble(ado_company["CUSTASKING"]) > 0)
										{
											grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = $"{Double.Parse((Double.Parse(Convert.ToString(ado_company["CUSTASKING"]).Trim()) / 1000d).ToString(), NumberStyles.Any).ToString("N0")}k";
										}
										else
										{
											grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = "";
										}

										grd_sale_prices.CurrentColumnIndex = 8;
										grd_sale_prices.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(current_color)));
										grd_sale_prices.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
										grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = ($"{Convert.ToString(ado_company["TransType"])} ").Trim();

										grd_sale_prices.CurrentColumnIndex = 9;
										grd_sale_prices.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(current_color)));
										grd_sale_prices.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
										grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = StringsHelper.Replace(($"{Convert.ToString(ado_company["PSTATUS"])} ").Trim(), "Completed - Sale Price Is ", "", 1, -1, CompareMethod.Binary);

									}
									else if (StringsHelper.ToDoubleSafe(cbo_search_type.SelectedIndex.ToString().Trim()) == 4 || StringsHelper.ToDoubleSafe(cbo_search_type.SelectedIndex.ToString().Trim()) == 5)
									{ 


										grd_sale_prices.CurrentColumnIndex = 6;
										grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
										grd_sale_prices.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(current_color)));
										grd_sale_prices.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
										//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
										if (!Convert.IsDBNull(ado_company["SUBMITTEDON"]))
										{
											grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = DateTime.Parse(Convert.ToString(ado_company["SUBMITTEDON"]).Trim()).ToString("d");
										}

										//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
										if (!Convert.IsDBNull(ado_company["SUBMITTEDBY"]))
										{
											grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = $"{grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].FormattedValue.ToString()} - {Convert.ToString(ado_company["SUBMITTEDBY"]).Trim()}";
										}

										grd_sale_prices.CurrentColumnIndex = 7;
										grd_sale_prices.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(current_color)));
										grd_sale_prices.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
										if (Convert.ToDouble(ado_company["CUSTASKING"]) > 0)
										{
											grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = $"{Double.Parse((Double.Parse(Convert.ToString(ado_company["CUSTASKING"]).Trim()) / 1000d).ToString(), NumberStyles.Any).ToString("N0")}k";
										}
										else
										{
											grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = "";
										}

										grd_sale_prices.CurrentColumnIndex = 8;
										grd_sale_prices.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(current_color)));
										grd_sale_prices.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
										if (Convert.ToDouble(ado_company["CUSTSOLD"]) > 0)
										{
											grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = $"{Double.Parse((Double.Parse(Convert.ToString(ado_company["CUSTSOLD"]).Trim()) / 1000d).ToString(), NumberStyles.Any).ToString("N0")}k";
										}
										else
										{
											grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = "";
										}

									}


									grd_sale_prices.set_RowData(grd_sale_prices.CurrentRowIndex, Convert.ToInt32(ado_company["journ_id"].ToString().Trim()));
									grd_sale_prices.RowsCount++;


								}

								ado_company.MoveNext();
								Application.DoEvents();

								lbl_class2[2].Text = $"{((grd_sale_prices.RowsCount - 2).ToString())} Records Found";

							}
							while(!ado_company.EOF);

							grd_sale_prices.RowsCount--;


						}
						else
						{
							MessageBox.Show("Search Results Exceed 1,500 Records. Too Large", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							grd_sale_prices.CurrentColumnIndex = 0;
							grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
							grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = "Search Results Too Large";
							grd_sale_prices.Visible = true;
							grd_sale_prices.Enabled = true;
							//UPGRADE_TODO: (1067) Member Visible is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
							// cmd_select_company.Visible = false; //gap-note cmd_select_company belongs to frmYacht and this form seems to be obsolete.
						} // If ado_Company.RecordCount <= 1000 Then

					}
					else
					{
						grd_sale_prices.CurrentColumnIndex = 0;
						grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
						grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].Value = "No Company Exists";
						grd_sale_prices.Visible = true;
						grd_sale_prices.Enabled = true;
						//UPGRADE_TODO: (1067) Member Visible is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						// cmd_select_company.Visible = false; //gap-note cmd_select_company belongs to frmYacht and this form seems to be obsolete.
					} // If ado_Company.BOF = False And ado_Company.EOF = False Then


				}

				CloseRemoteDatabase();


				grd_sale_prices.FixedRows = 1;
				grd_sale_prices.FixedColumns = 0;

				grd_sale_prices.Visible = true;
				grd_sale_prices.Enabled = true;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("find_sale_prices_out_of_range_Click_Error", excep.Message);
			}



		} // cmd_find_now_Click
		public void CloseRemoteDatabase()
		{



			if (REMOTE_ADO_DB != null)
			{
				if (REMOTE_ADO_DB.State == ConnectionState.Open)
				{
					ErrorHandlingHelper.ResumeNext(
						() => {UpgradeHelpers.DB.TransactionManager.DeEnlist(REMOTE_ADO_DB);}, 
						() => {REMOTE_ADO_DB.Close();});
				}
			}
			REMOTE_ADO_DB = null;

			AlreadyOpen = false;
			 // frm_Subscription

		}




		private void find_sale_prices_for_Ac(int journ_id)
		{
			//object cmd_select_company = null;


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
				grd_ac_sale.Visible = false;
				grd_ac_sale.Enabled = false;

				grd_ac_sale.Clear();

				grd_ac_sale.ColumnsCount = 7;
				grd_ac_sale.RowsCount = 2;

				//point to the first column and first row.
				grd_ac_sale.CurrentRowIndex = 0;

				grd_ac_sale.CurrentColumnIndex = 0;
				grd_ac_sale.SetColumnWidth(grd_ac_sale.CurrentColumnIndex, 133);
				grd_ac_sale.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_ac_sale[grd_ac_sale.CurrentRowIndex, grd_ac_sale.CurrentColumnIndex].Value = "Submitted On";

				grd_ac_sale.CurrentColumnIndex = 1;
				grd_ac_sale.SetColumnWidth(grd_ac_sale.CurrentColumnIndex, 253);
				grd_ac_sale.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_ac_sale[grd_ac_sale.CurrentRowIndex, grd_ac_sale.CurrentColumnIndex].Value = "Submitted By";

				grd_ac_sale.CurrentColumnIndex = 2;
				grd_ac_sale.SetColumnWidth(grd_ac_sale.CurrentColumnIndex, 93);
				grd_ac_sale.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_ac_sale[grd_ac_sale.CurrentRowIndex, grd_ac_sale.CurrentColumnIndex].Value = "RECSTAT";

				grd_ac_sale.CurrentColumnIndex = 3;
				grd_ac_sale.SetColumnWidth(grd_ac_sale.CurrentColumnIndex, 80);
				grd_ac_sale.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_ac_sale[grd_ac_sale.CurrentRowIndex, grd_ac_sale.CurrentColumnIndex].Value = "ASKING";

				grd_ac_sale.CurrentColumnIndex = 4;
				grd_ac_sale.SetColumnWidth(grd_ac_sale.CurrentColumnIndex, 60);
				grd_ac_sale.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_ac_sale[grd_ac_sale.CurrentRowIndex, grd_ac_sale.CurrentColumnIndex].Value = "SOLD";

				grd_ac_sale.CurrentColumnIndex = 5;
				grd_ac_sale.SetColumnWidth(grd_ac_sale.CurrentColumnIndex, 50);
				grd_ac_sale.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_ac_sale[grd_ac_sale.CurrentRowIndex, grd_ac_sale.CurrentColumnIndex].Value = "COMP ID";

				grd_ac_sale.CurrentColumnIndex = 6;
				grd_ac_sale.SetColumnWidth(grd_ac_sale.CurrentColumnIndex, 50);
				grd_ac_sale.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_ac_sale[grd_ac_sale.CurrentRowIndex, grd_ac_sale.CurrentColumnIndex].Value = "ACVALID";


				Query = "select acval_entry_date as SUBMITTEDON, (comp_name + ' - ' + acval_contact_name) as SUBMITTEDBY,";
				Query = $"{Query} case when ac_sale_price_acval_id = acval_id then 'CURRENTPRICE' ELSE 'EXTRAPRICE' END as RECSTAT,";
				Query = $"{Query} ac_asking_price as JETNETASKING, ac_sale_price JETNETSOLD,";
				Query = $"{Query} acval_asking_price as SUBMITASKING,acval_sale_price as SUBMITSOLD,";
				Query = $"{Query} journ_id as JORUNID, acval_id as ACVALID,  journ_ac_id as ACID, journ_id as JOURNID,";
				Query = $"{Query} acval_comp_id As CompID  from Aircraft_Value with (NOLOCK)";
				Query = $"{Query} inner join Aircraft  with (NOLOCK) on acval_journ_id = ac_journ_id and ac_id = acval_ac_id";
				Query = $"{Query} inner join Aircraft_Model with (NOLOCK) on amod_id = ac_amod_id";
				Query = $"{Query} inner join journal with (NOLOCK) on journ_id = acval_journ_id and journ_ac_id = acval_ac_id";
				Query = $"{Query} inner join Company with (NOLOCK) on acval_comp_id = comp_id and comp_journ_id = 0";
				Query = $"{Query} Where acval_sale_price > 0 and journ_id = {journ_id.ToString()}";
				Query = $"{Query} and acval_type <> 'CLEAR' order by acval_entry_date asc";

				if (OpenRemoteDatabase())
				{

					ado_company.CursorLocation = CursorLocationEnum.adUseClient;
					ado_company.Open(Query, REMOTE_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);

					if (!ado_company.BOF && !ado_company.EOF)
					{

						if (ado_company.RecordCount <= 1000)
						{

							lRow = 0;
							//frame_search.Caption = "Search - Found " & Format(ado_Company.RecordCount, "#,##0") & " Record(s)"
							Application.DoEvents();
							strLastContact = "";

							do 
							{ // Loop Until ado_Company.EOF = True

								current_color = ColorTranslator.ToOle(Color.White).ToString();
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(ado_company["RECSTAT"]))
								{
									if (Convert.ToString(ado_company["RECSTAT"]).Trim() == "CURRENTPRICE")
									{
										current_color = (0xC0FFC0).ToString();
									}
								}


								grd_ac_sale.CurrentRowIndex++;
								grd_ac_sale.CurrentColumnIndex = 0;
								grd_ac_sale[grd_ac_sale.CurrentRowIndex, grd_ac_sale.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
								grd_ac_sale.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(current_color)));
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(ado_company["SUBMITTEDON"]))
								{
									grd_ac_sale[grd_ac_sale.CurrentRowIndex, grd_ac_sale.CurrentColumnIndex].Value = Convert.ToString(ado_company["SUBMITTEDON"]).Trim();
								}

								grd_ac_sale.CurrentColumnIndex = 1;
								grd_ac_sale[grd_ac_sale.CurrentRowIndex, grd_ac_sale.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
								grd_ac_sale.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(current_color)));
								grd_ac_sale.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(ado_company["SUBMITTEDBY"]))
								{
									grd_ac_sale[grd_ac_sale.CurrentRowIndex, grd_ac_sale.CurrentColumnIndex].Value = Convert.ToString(ado_company["SUBMITTEDBY"]).Trim();
								}

								grd_ac_sale.CurrentColumnIndex = 2;
								grd_ac_sale[grd_ac_sale.CurrentRowIndex, grd_ac_sale.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
								grd_ac_sale.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(current_color)));
								grd_ac_sale.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(ado_company["RECSTAT"]))
								{
									grd_ac_sale[grd_ac_sale.CurrentRowIndex, grd_ac_sale.CurrentColumnIndex].Value = Convert.ToString(ado_company["RECSTAT"]).Trim();
								}

								grd_ac_sale.CurrentColumnIndex = 3;
								grd_ac_sale[grd_ac_sale.CurrentRowIndex, grd_ac_sale.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
								grd_ac_sale.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(current_color)));
								grd_ac_sale.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(ado_company["SUBMITASKING"]))
								{
									if (Convert.ToDouble(ado_company["SUBMITASKING"]) > 0)
									{
										grd_ac_sale[grd_ac_sale.CurrentRowIndex, grd_ac_sale.CurrentColumnIndex].Value = $"{Double.Parse((Double.Parse(Convert.ToString(ado_company["SUBMITASKING"]).Trim()) / 1000d).ToString(), NumberStyles.Any).ToString("N0")}k";
									}
									else
									{
										grd_ac_sale[grd_ac_sale.CurrentRowIndex, grd_ac_sale.CurrentColumnIndex].Value = "";
									}
								}

								grd_ac_sale.CurrentColumnIndex = 4;
								grd_ac_sale[grd_ac_sale.CurrentRowIndex, grd_ac_sale.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
								grd_ac_sale.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(current_color)));
								grd_ac_sale.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(ado_company["SUBMITSOLD"]))
								{
									grd_ac_sale[grd_ac_sale.CurrentRowIndex, grd_ac_sale.CurrentColumnIndex].Value = $"{Double.Parse((Double.Parse(Convert.ToString(ado_company["SUBMITSOLD"]).Trim()) / 1000d).ToString(), NumberStyles.Any).ToString("N0")}k";
								}


								grd_ac_sale.CurrentColumnIndex = 5;
								grd_ac_sale.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(current_color)));
								grd_ac_sale.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(ado_company["CompID"]))
								{
									grd_ac_sale[grd_ac_sale.CurrentRowIndex, grd_ac_sale.CurrentColumnIndex].Value = Convert.ToString(ado_company["CompID"]).Trim();
								}

								grd_ac_sale.CurrentColumnIndex = 6;
								grd_ac_sale.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(current_color)));
								grd_ac_sale.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(ado_company["ACVALID"]))
								{
									grd_ac_sale[grd_ac_sale.CurrentRowIndex, grd_ac_sale.CurrentColumnIndex].Value = Convert.ToString(ado_company["ACVALID"]).Trim();
								}

								lbl_ac_id.Text = Convert.ToString(ado_company["ACID"]);

								grd_ac_sale.set_RowData(grd_ac_sale.CurrentRowIndex, Convert.ToInt32(ado_company["ACVALID"].ToString().Trim()));
								grd_ac_sale.RowsCount++;

								ado_company.MoveNext();
								Application.DoEvents();

							}
							while(!ado_company.EOF);

							grd_ac_sale.RowsCount--;


						}
						else
						{
							MessageBox.Show("Search Results Exceed 1,000 Records. Too Large", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							grd_ac_sale.CurrentColumnIndex = 0;
							grd_ac_sale[grd_ac_sale.CurrentRowIndex, grd_ac_sale.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
							grd_ac_sale[grd_ac_sale.CurrentRowIndex, grd_ac_sale.CurrentColumnIndex].Value = "Search Results Too Large";
							grd_ac_sale.Visible = true;
							grd_ac_sale.Enabled = true;
							//UPGRADE_TODO: (1067) Member Visible is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
							// cmd_select_company.Visible = false;//gap-note cmd_select_company belongs to frmYacht and this form seems to be obsolete.
						} // If ado_Company.RecordCount <= 1000 Then

					}
					else
					{
						grd_ac_sale.CurrentColumnIndex = 0;
						grd_ac_sale[grd_ac_sale.CurrentRowIndex, grd_ac_sale.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
						grd_ac_sale[grd_ac_sale.CurrentRowIndex, grd_ac_sale.CurrentColumnIndex].Value = "No Company Exists";
						grd_ac_sale.Visible = true;
						grd_ac_sale.Enabled = true;
						//UPGRADE_TODO: (1067) Member Visible is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						//cmd_select_company.Visible = false; //gap-note cmd_select_company belongs to frmYacht and this form seems to be obsolete.
					} // If ado_Company.BOF = False And ado_Company.EOF = False Then


				}

				CloseRemoteDatabase();

				grd_ac_sale.FixedRows = 1;
				grd_ac_sale.FixedColumns = 0;

				grd_ac_sale.Visible = true;
				grd_ac_sale.Enabled = true;

				// was erroring, if closed and trying to close again
				if (ado_company.State != ConnectionState.Closed)
				{
					ado_company.Close();
				}


				ado_company = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("find_sale_prices_out_of_range_Click_Error", excep.Message);
			}


		} // cmd_find_now_Click



		private void cmd_update_selected_Click(Object eventSender, EventArgs eventArgs)
		{
			string Query = "";

			int temp_id = grd_ac_sale.get_RowData(grd_ac_sale.CurrentRowIndex);

			if (OpenRemoteDatabase())
			{
				if (MessageBox.Show("Are You Sure You Want to Set This as Primary?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
				{

					Query = $"UPDATE Aircraft_Value SET acval_primary_price_flag = 'N' , acval_webaction_date = '1900-01-01' , acval_primary_price_notes = ''  WHERE acval_journ_id = {lbl_journ_id.Text} and acval_primary_price_flag = 'Y' and acval_ac_id = {lbl_ac_id.Text}";

					DbCommand TempCommand = null;
					TempCommand = REMOTE_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = Query;
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();

					Query = $"UPDATE Aircraft_Value SET acval_primary_price_flag = 'Y' , acval_webaction_date = '1900-01-01' , acval_primary_price_notes = '{StringsHelper.Replace(txt_update_note.Text, "'", "''", 1, -1, CompareMethod.Binary)}' WHERE acval_id = {temp_id.ToString()} and acval_ac_id = {lbl_ac_id.Text} and acval_journ_id = {lbl_journ_id.Text}";

					DbCommand TempCommand_2 = null;
					TempCommand_2 = REMOTE_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
					TempCommand_2.CommandText = Query;
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
					TempCommand_2.ExecuteNonQuery();


					find_sale_prices_out_of_range("");

				}

			}

			CloseRemoteDatabase();

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
		private void Form_Load()
		{



			if (is_remove > 0)
			{
				frm_list.Visible = false;
			}
			else
			{

				cbo_search_type.AddItem("");
				cbo_search_type.AddItem("Sale Prices from Multiple Sources (Out of Range)");
				cbo_search_type.AddItem("Sale Prices from Multiple Sources");
				cbo_search_type.AddItem("Sale Prices Not Processed (Outside of Model Ranges)");
				cbo_search_type.AddItem("Sale Prices for Internal Solds");
				cbo_search_type.AddItem("Sale Prices Not Processed for Non Retail Solds");
				cbo_search_type.SelectedIndex = 1;

				find_sale_prices_out_of_range("");

				frm_list.Visible = true;
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


				if (!AlreadyOpen)
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
						AlreadyOpen = true;
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



		private void grd_ac_sale_Click(Object eventSender, EventArgs eventArgs)
		{

			frm_update_click.Visible = true;
			lbl_update.Visible = false;

		}

		public void grd_sale_prices_Click(Object eventSender, EventArgs eventArgs)
		{

			string order_by = "";


			if (grd_sale_prices.MouseRow == 0 && grd_sale_prices.Visible)
			{

				if (cbo_search_type.SelectedIndex == 1)
				{
					if (grd_sale_prices.MouseCol == 0)
					{
						order_by = " amod_make_name asc, amod_model_name asc ";
					}
					else if (grd_sale_prices.MouseCol == 1)
					{ 
						order_by = " ac_ser_no_full asc, amod_make_name asc, amod_model_name asc ";
					}
					else if (grd_sale_prices.MouseCol == 2)
					{ 
						order_by = " journ_date asc, amod_make_name asc, amod_model_name asc ";
					}
					else if (grd_sale_prices.MouseCol == 3)
					{ 
						order_by = " journ_subject asc, amod_make_name asc, amod_model_name asc ";
					}
					else if (grd_sale_prices.MouseCol == 4)
					{ 
						order_by = " journ_id asc, amod_make_name asc, amod_model_name asc ";
					}
					else if (grd_sale_prices.MouseCol == 6)
					{ 
						order_by = " ac_sale_price asc, amod_make_name asc, amod_model_name asc ";
					}
				}
				else if (cbo_search_type.SelectedIndex == 2)
				{ 
					if (grd_sale_prices.MouseCol == 0)
					{
						order_by = " amod_make_name asc, amod_model_name asc ";
					}
					else if (grd_sale_prices.MouseCol == 1)
					{ 
						order_by = " ac_ser_no_full asc, amod_make_name asc, amod_model_name asc ";
					}
					else if (grd_sale_prices.MouseCol == 2)
					{ 
						order_by = " journ_date asc, amod_make_name asc, amod_model_name asc ";
					}
					else if (grd_sale_prices.MouseCol == 3)
					{ 
						order_by = " journ_subject asc, amod_make_name asc, amod_model_name asc ";
					}
					else if (grd_sale_prices.MouseCol == 4)
					{ 
						order_by = " journ_id asc, amod_make_name asc, amod_model_name asc ";
					}
					else if (grd_sale_prices.MouseCol == 6)
					{ 
						order_by = " SOURCES asc, amod_make_name asc, amod_model_name asc ";
					}
				}
				else if (cbo_search_type.SelectedIndex == 3)
				{ 
					if (grd_sale_prices.MouseCol == 0)
					{
						order_by = " amod_make_name asc, amod_model_name asc ";
					}
					else if (grd_sale_prices.MouseCol == 1)
					{ 
						order_by = " ac_ser_no_full asc, amod_make_name asc, amod_model_name asc ";
					}
					else if (grd_sale_prices.MouseCol == 2)
					{ 
						order_by = " journ_date asc, amod_make_name asc, amod_model_name asc ";
					}
					else if (grd_sale_prices.MouseCol == 3)
					{ 
						order_by = " journ_subject asc, amod_make_name asc, amod_model_name asc ";
					}
					else if (grd_sale_prices.MouseCol == 4)
					{ 
						order_by = " journ_id asc, amod_make_name asc, amod_model_name asc ";
					}
					else if (grd_sale_prices.MouseCol == 6)
					{ 
						order_by = " acval_entry_date asc, amod_make_name asc, amod_model_name asc ";
					}
				}
				else if (cbo_search_type.SelectedIndex == 4)
				{ 
					if (grd_sale_prices.MouseCol == 0)
					{
						order_by = " amod_make_name asc, amod_model_name asc ";
					}
					else if (grd_sale_prices.MouseCol == 1)
					{ 
						order_by = " ac_ser_no_full asc, amod_make_name asc, amod_model_name asc ";
					}
					else if (grd_sale_prices.MouseCol == 2)
					{ 
						order_by = " journ_date asc, amod_make_name asc, amod_model_name asc ";
					}
					else if (grd_sale_prices.MouseCol == 3)
					{ 
						order_by = " journ_subject asc, amod_make_name asc, amod_model_name asc ";
					}
					else if (grd_sale_prices.MouseCol == 4)
					{ 
						order_by = " journ_id asc, amod_make_name asc, amod_model_name asc ";
					}
					else if (grd_sale_prices.MouseCol == 6)
					{ 
						order_by = " acval_entry_date asc, amod_make_name asc, amod_model_name asc ";
					}
				}
				else if (cbo_search_type.SelectedIndex == 5)
				{ 
					if (grd_sale_prices.MouseCol == 0)
					{
						order_by = " amod_make_name asc, amod_model_name asc ";
					}
					else if (grd_sale_prices.MouseCol == 1)
					{ 
						order_by = " ac_ser_no_full asc, amod_make_name asc, amod_model_name asc ";
					}
					else if (grd_sale_prices.MouseCol == 2)
					{ 
						order_by = " journ_date asc, amod_make_name asc, amod_model_name asc ";
					}
					else if (grd_sale_prices.MouseCol == 3)
					{ 
						order_by = " journ_subject asc, amod_make_name asc, amod_model_name asc ";
					}
					else if (grd_sale_prices.MouseCol == 4)
					{ 
						order_by = " journ_id asc, amod_make_name asc, amod_model_name asc ";
					}
					else if (grd_sale_prices.MouseCol == 6)
					{ 
						order_by = " acval_entry_date asc, amod_make_name asc, amod_model_name asc ";
					}

				}





				find_sale_prices_out_of_range(order_by);

			}
			else if (is_remove > 0 && journ_remove > 0 && lbl_journ_id.Text != "" && lbl_ac_id.Text != "")
			{ 

				find_sale_prices_for_Ac(Convert.ToInt32(Double.Parse(lbl_journ_id.Text)));
				grd_ac_sale.Visible = true;
				frm_update_click.Visible = false;

			}
			else
			{
				lbl_journ_id.Text = grd_sale_prices.get_RowData(grd_sale_prices.CurrentRowIndex).ToString();

				find_sale_prices_for_Ac(Convert.ToInt32(Double.Parse(lbl_journ_id.Text)));

				grd_ac_sale.Visible = true;

				frm_update_click.Visible = false;
			}

		}

		private void grd_sale_prices_DoubleClick(Object eventSender, EventArgs eventArgs)
		{
			int nReference_CompanyID = 0;

			int trow = 0;
			int tcol = 0;
			int journ_id = 0;



			if (grd_sale_prices.MouseCol == 4)
			{

				trow = grd_sale_prices.MouseRow;
				tcol = grd_sale_prices.MouseCol;

				grd_sale_prices.CurrentColumnIndex = tcol;
				grd_sale_prices.CurrentRowIndex = trow;
				journ_id = Convert.ToInt32(Double.Parse(grd_sale_prices[grd_sale_prices.CurrentRowIndex, grd_sale_prices.CurrentColumnIndex].FormattedValue.ToString()));

				lbl_journ_id.Text = journ_id.ToString();

				find_sale_prices_for_Ac(Convert.ToInt32(Double.Parse(lbl_journ_id.Text)));

				grd_ac_sale.Visible = true;

				modAdminCommon.gbl_Aircraft_ID = Convert.ToInt32(Double.Parse(lbl_ac_id.Text));
				modAdminCommon.gbl_Aircraft_Journal_ID = Convert.ToInt32(Double.Parse(lbl_journ_id.Text));

				frm_aircraft.DefInstance.Form_Initialize();
				frm_aircraft.DefInstance.Reference_Aircraft_ID = modAdminCommon.gbl_Aircraft_ID;
				frm_aircraft.DefInstance.Reference_Journal_ID = modAdminCommon.gbl_Aircraft_Journal_ID;
				frm_aircraft.DefInstance.Reference_Company_ID = nReference_CompanyID;
				frm_aircraft.DefInstance.Show();
				//UPGRADE_WARNING: (2065) Form method frm_aircraft.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
				frm_aircraft.DefInstance.BringToFront();
				//UPGRADE_WARNING: (2065) Form event Form.Activated has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
				frm_aircraft.DefInstance.Form_Activated(frm_aircraft.DefInstance, new EventArgs());



			}



		}
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}