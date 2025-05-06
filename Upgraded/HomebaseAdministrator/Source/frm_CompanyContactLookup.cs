using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UpgradeHelpers;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Gui;
using UpgradeHelpers.Gui.Controls;
using UpgradeHelpers.Helpers;
using UpgradeStubs;

namespace HomebaseAdministrator
{
	internal partial class frm_CompanyContactLookup
		: System.Windows.Forms.Form
	{

		public frm_CompanyContactLookup()
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


		private void frm_CompanyContactLookup_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}



		private bool Is_Dirty = false;

		private string RecordStat = "";
		private bool Stopped = false;
		private string RegNoStat = "";
		private int RegNo_id = 0;
		public bool bolTAL = false;
		public bool bolTAL_SIC = false;
		public bool bolPanelJump = false;
		string[] busTypeArray = null;

		bool Fin_Initial_Load = false;

		private void LoadContactTitleGroupComboBox(ComboBox cboBox, string exclude_yachts = "N")
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			try
			{

				cboBox.Items.Clear();
				cboBox.AddItem("");

				strQuery1 = "SELECT * FROM Contact_Title_Group WITH (NOLOCK) ";

				if (exclude_yachts.Trim() == "Y")
				{
					strQuery1 = $"{strQuery1} where ctitleg_product_yacht_flag = 'N' ";
				}

				strQuery1 = $"{strQuery1} ORDER BY ctitleg_group_name ";

				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					do 
					{
						cboBox.AddItem(($"{Convert.ToString(rstRec1["ctitleg_group_name"])} ").Trim());
						rstRec1.MoveNext();
					}
					while(!rstRec1.EOF);

				} // If rstRec1.BOF = False And rstRec1.EOF = False Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("LoadContactTitleGroupComboBox_Error", excep.Message);
			}

		} // LoadContactTitleGroupComboBox

		private void FillTitleGroupLists(string inTitle)
		{

			try
			{

				string Query = "";
				string strUsedGroups = "";
				ADORecordSetHelper snpGroup = new ADORecordSetHelper();
				ADORecordSetHelper snpMaster = new ADORecordSetHelper();

				lstTitleGroup.Items.Clear();
				strUsedGroups = "";

				if (inTitle != "")
				{
					Query = "SELECT ctitlegref_group_name FROM Contact_Title_Group_Reference ";
					Query = $"{Query}WHERE ctitlegref_title_name = '{StringsHelper.Replace(inTitle, "'", "''", 1, -1, CompareMethod.Binary)}' ORDER BY ctitlegref_group_name";

					snpGroup.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

					if (!(snpGroup.BOF && snpGroup.EOF))
					{

						while(!snpGroup.EOF)
						{
							lstTitleGroup.AddItem(($"{Convert.ToString(snpGroup["ctitlegref_group_name"])}").Trim());
							strUsedGroups = $"{strUsedGroups}{($"{Convert.ToString(snpGroup["ctitlegref_group_name"])}").Trim()},";
							snpGroup.MoveNext();
						};

					}

					snpGroup.Close();
					snpGroup = null;
				}

				if (strUsedGroups != "")
				{
					strUsedGroups = strUsedGroups.Substring(0, Math.Min(Strings.Len(strUsedGroups) - 1, strUsedGroups.Length));
				}


				lstAllTitleGroups.Items.Clear();

				Query = "SELECT ctitleg_group_name FROM Contact_Title_Group ";
				if (strUsedGroups != "")
				{
					Query = $"{Query}WHERE ctitleg_group_name NOT IN ('{StringsHelper.Replace(strUsedGroups, ",", "','", 1, -1, CompareMethod.Binary)}') ";
				}
				Query = $"{Query}ORDER BY ctitleg_group_name";

				snpMaster.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpMaster.BOF && snpMaster.EOF))
				{

					while(!snpMaster.EOF)
					{
						lstAllTitleGroups.AddItem(($"{Convert.ToString(snpMaster["ctitleg_group_name"])}").Trim());
						snpMaster.MoveNext();
					};
				}

				snpMaster.Close();
				snpMaster = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"FillTitleGroupLists_error: {excep.Message}");
			}

		}

		private void FillBusinessGroupLists(string inCBG)
		{

			try
			{

				string Query = "";
				string strUsedGroups = "";
				ADORecordSetHelper snpGroup = null;
				ADORecordSetHelper snpMaster = null;
				int nLoop = 0;

				lstBusType.Items.Clear();
				strUsedGroups = "";

				if (inCBG != "")
				{
					Query = "SELECT cbtg_group_name FROM Company_Business_Type_Group";
					Query = $"{Query} INNER JOIN Company_Business_Type_Group_Reference ON (cbtgr_group_id = cbtg_id)";
					Query = $"{Query} WHERE cbtgr_business_type = '{StringsHelper.Replace(inCBG, "'", "''", 1, -1, CompareMethod.Binary)}' ORDER BY cbtg_id";

					//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseClient);
					snpGroup = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

					//UPGRADE_WARNING: (2080) IsEmpty was upgraded to a comparison and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
					if (!(snpGroup is null) && !(snpGroup.BOF && snpGroup.EOF))
					{

						snpGroup.MoveFirst();


						while(!snpGroup.EOF)
						{

							lstBusType.AddItem(($"{Convert.ToString(snpGroup["cbtg_group_name"])}").Trim());
							strUsedGroups = $"{strUsedGroups}{($"{Convert.ToString(snpGroup["cbtg_group_name"])}").Trim()},";
							snpGroup.MoveNext();

						};

						snpGroup.Close();

					}

					snpGroup = null;
				}

				if (strUsedGroups != "")
				{
					strUsedGroups = strUsedGroups.Substring(0, Math.Min(Strings.Len(strUsedGroups) - 1, strUsedGroups.Length));
				}


				lstAllBusType.Items.Clear();

				Query = "SELECT cbtg_id, cbtg_group_name FROM Company_Business_Type_Group";

				if (strUsedGroups != "")
				{
					Query = $"{Query} WHERE cbtg_group_name NOT IN ('{StringsHelper.Replace(strUsedGroups, ",", "','", 1, -1, CompareMethod.Binary)}') ";
				}

				Query = $"{Query} ORDER BY cbtg_id";

				snpMaster = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

				//UPGRADE_WARNING: (2080) IsEmpty was upgraded to a comparison and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
				if (!(snpMaster is null) && !(snpMaster.BOF && snpMaster.EOF))
				{

					snpMaster.MoveFirst();


					while(!snpMaster.EOF)
					{

						lstAllBusType.AddItem(($"{Convert.ToString(snpMaster["cbtg_group_name"])}").Trim());
						snpMaster.MoveNext();

					};

					snpMaster.Close();

				}

				if (!modAdminCommon.BusTypeArryFilled)
				{

					Query = "SELECT cbtg_id, cbtg_group_name FROM Company_Business_Type_Group ORDER BY cbtg_id";

					//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseClient);
					snpMaster = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

					//UPGRADE_WARNING: (2080) IsEmpty was upgraded to a comparison and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
					if (!(snpMaster is null) && !(snpMaster.BOF && snpMaster.EOF))
					{

						nLoop = 0;
						snpMaster.MoveFirst();

						modAdminCommon.BusTypeArry = ArraysHelper.InitializeArray<string[, ]>(new int[]{snpMaster.RecordCount, 2}, new int[]{0, 0});


						while(!snpMaster.EOF)
						{

							modAdminCommon.BusTypeArry[nLoop, 0] = Convert.ToString(snpMaster["cbtg_group_name"]);
							modAdminCommon.BusTypeArry[nLoop, 1] = Convert.ToString(snpMaster["cbtg_id"]);
							nLoop++;

							snpMaster.MoveNext();

						};

						snpMaster.Close();

					}

					if (modAdminCommon.BusTypeArry.GetUpperBound(0) > 0)
					{
						modAdminCommon.BusTypeArryFilled = true;
					}

				}

				snpMaster = null;

				//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseServer);
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"FillBusinessGroupLists_error: {excep.Message}");
			}

		}

		public bool pass_bad_check(string string_to_check)
		{
			bool result = false;
			string[] V = null;

			result = true;

			string_to_check = string_to_check.Trim();

			int CountChar = 0;
			int CountChar2 = 0;
			if (string_to_check.IndexOf('(') >= 0)
			{
				V = string_to_check.Split('(');
				CountChar = V.GetUpperBound(0);

				V = string_to_check.Split(')');
				CountChar2 = V.GetUpperBound(0);

				if (CountChar != CountChar2)
				{
					result = false;
					MessageBox.Show("Number of Open and Close Parenthesis Dont Match", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK);
				}
			}


			return result;
		}

		private void Update_Command_Buttons(string Action)
		{
			//enable/disable buttons

			switch(Action)
			{
				case "Enable" : 
					cmd_Add_CAT.Enabled = true; 
					cmd_Add_GAT.Enabled = true; 
					cmd_Add_CBT.Enabled = true; 
					cmd_Add_Country.Enabled = true; 
					 
					cmd_Cancel_CAT.Enabled = true; 
					cmd_Cancel_GAT.Enabled = true; 
					cmd_Cancel_CBT.Enabled = true; 
					cmd_Cancel_Country.Enabled = true; 
					 
					cmd_Delete_CAT.Enabled = true; 
					cmd_Delete_GAT.Enabled = true; 
					cmd_Delete_CBT.Enabled = true; 
					cmd_Delete_Country.Enabled = true; 
					 
					cmd_Save_CAT.Enabled = true; 
					cmd_Save_GAT.Enabled = true; 
					cmd_Save_Country.Enabled = true; 
					 
					break;
				case "Disable" : 
					cmd_Add_CAT.Enabled = false; 
					cmd_Add_GAT.Enabled = false; 
					cmd_Add_CBT.Enabled = false; 
					cmd_Add_Country.Enabled = false; 
					 
					cmd_Cancel_CAT.Enabled = false; 
					cmd_Cancel_GAT.Enabled = false; 
					cmd_Cancel_CBT.Enabled = false; 
					cmd_Cancel_Country.Enabled = false; 
					cmd_Delete_CAT.Enabled = false; 
					cmd_Delete_GAT.Enabled = false; 
					cmd_Delete_CBT.Enabled = false; 
					cmd_Delete_Country.Enabled = false; 
					cmd_Save_CAT.Enabled = false; 
					cmd_Save_GAT.Enabled = false; 
					cmd_Save_Country.Enabled = false; 
					 
					break;
			}

		}

		private void ToolbarButtonsSetup()
		{
			//turn buttons on/off


			ToolStrip tbr = tbr_ToolBar;

			tbr.Items[1].Visible = true;
			tbr.Items[3].Visible = false; //back
			tbr.Items[5].Visible = false;
			tbr.Items[7].Visible = true;

			tbr.Items[1].Enabled = true;
			tbr.Items[3].Enabled = false;
			tbr.Items[5].Enabled = true;
			tbr.Items[7].Enabled = true;

		}

		private void ToolbarSetup()
		{
			//set up button images, names


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

		private void btn_search_bus_type_flags_Click(Object eventSender, EventArgs eventArgs) => tab_Lookup_SelectedIndexChanged(tab_Lookup, new EventArgs());


		public void Fill_Contact_Title_List_From_Group()
		{

			int NewTab = 0; //Current tab

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = ""; //Current query sql

			string FLDS = ""; //work fields for query string
			string VALS = ""; //value work fields for query string
			string Comma = ""; //comma work field for query string
			int nRow = 0; //Current row counter
			int Ans = 0; //Answer to question
			Control Grd = null;
			Color lForeColor = System.Drawing.Color.Black;

			int lRow1 = 0;
			int lCol1 = 0;
			int lTot1 = 0;
			int temp_counter = 0;
			Color lBackColor = Color.White;
			frm_update_frame.Visible = false;
			string contact_id_string = "";


			pnl_CT_AddUpdate.Visible = false;
			pnl_ContactTitleGroup.Visible = false;
			grd_titles_in_group.Visible = true;
			lblTotTitles[1].Visible = true;
			Label1[54].Visible = true;


			grd_titles_in_group.Clear();
			grd_titles_in_group.RowsCount = 2;
			grd_titles_in_group.ColumnsCount = 2;

			grd_titles_in_group.CurrentRowIndex = 0;

			grd_titles_in_group.CurrentColumnIndex = 0;
			grd_titles_in_group[grd_titles_in_group.CurrentRowIndex, grd_titles_in_group.CurrentColumnIndex].Value = "Contact Title";
			grd_titles_in_group.SetColumnWidth(grd_titles_in_group.CurrentColumnIndex, 293);

			grd_titles_in_group.CurrentColumnIndex = 1;
			grd_titles_in_group[grd_titles_in_group.CurrentRowIndex, grd_titles_in_group.CurrentColumnIndex].Value = "#Contact";
			grd_titles_in_group.SetColumnWidth(grd_titles_in_group.CurrentColumnIndex, 53);

			grd_titles_in_group.CurrentRowIndex = 1;
			grd_titles_in_group.CurrentColumnIndex = 0;
			grd_titles_in_group.FixedRows = 1;
			grd_titles_in_group.FixedColumns = 0;
			 // FG_Contact_Title


			Label1[52].Tag = "";
			if (cbo_contact_title.Text.Trim() != "")
			{
				strQuery1 = "select distinct ctitleg_id  from Contact_Title_Group with (NOLOCK)";
				strQuery1 = $"{strQuery1} where ctitleg_group_name = '{cbo_contact_title.Text.Trim()}'";
				rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{
					do 
					{ // Loop Until rstRec1.EOF = True Or lblStopTitleLoad.Visible = False
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["ctitleg_id"]))
						{
							if (Convert.ToString(rstRec1["ctitleg_id"]).Trim() != "")
							{
								Label1[52].Tag = Convert.ToString(rstRec1["ctitleg_id"]).Trim();
							}
						}
						rstRec1.MoveNext();
						Application.DoEvents();

					}
					while(!rstRec1.EOF);
				}
				rstRec1.Close();

			}





			grd_titles_in_group.Enabled = false;


			strQuery1 = "select distinct contact_title, ctitleg_group_where_clause, ctitleg_group_name, ctitleg_id, count(distinct contact_id) as tcount ";

			strQuery1 = $"{strQuery1} from Contact_Title_Group with (NOLOCK)";
			strQuery1 = $"{strQuery1} left outer join Contact_Title_Group_Index  with (NOLOCK) on ctitleg_id = ctgind_ctitleg_id ";


			strQuery1 = $"{strQuery1} left outer join Contact with (NOLOCK) on contact_id = ctgind_contact_id and contact_journ_id = 0 and contact_active_flag='Y' and contact_hide_flag='N'";
			strQuery1 = $"{strQuery1} left outer join Company with (NOLOCK) on contact_comp_id=comp_id and comp_active_flag='Y' and comp_hide_flag='N' and comp_journ_id = 0 and (comp_product_business_flag='Y' or comp_product_helicopter_flag='Y' or comp_product_commercial_flag='Y') ";

			if (cbo_contact_title.Text.Trim() != "")
			{
				strQuery1 = $"{strQuery1} where ctitleg_group_name = '{cbo_contact_title.Text.Trim()}' ";
			}
			else
			{
				strQuery1 = $"{strQuery1} where ctitleg_group_name <> '' ";
			}

			strQuery1 = $"{strQuery1} and contact_title <> '' ";

			// in new not in the old
			if (opt_contact_title[2].Checked && Convert.ToString(Label1[52].Tag) != "")
			{
				strQuery1 = $"{strQuery1} and contact_id not in ( select distinct contact_id from Contact_Title_Group_Reference with (NOLOCK)";
				strQuery1 = $"{strQuery1} inner join Contact_Title_Group g2 with (NOLOCK) on ctitlegref_group_name = g2.ctitleg_group_name ";
				strQuery1 = $"{strQuery1} inner join Contact_Title wtih (NOLOCK) on ctitlegref_title_name = ctitle_name";
				strQuery1 = $"{strQuery1} inner join Contact with (NOLOCK) on ctitle_name = contact_title and contact_journ_id = 0 and contact_active_flag='Y' and contact_hide_flag='N'";
				strQuery1 = $"{strQuery1} inner join Company with (NOLOCK) on contact_comp_id=comp_id and comp_active_flag='Y' and comp_hide_flag='N' and comp_journ_id = 0";
				strQuery1 = $"{strQuery1} where g2.ctitleg_id = {Convert.ToString(Label1[52].Tag)})";
			}

			// in old, not in the new
			if (opt_contact_title[1].Checked && Convert.ToString(Label1[52].Tag) != "")
			{

				// THIS SWITCHER RTHE QUERY TO DO THIS ---
				strQuery1 = " select distinct contact_title, ctitleg_group_where_clause, ctitleg_group_name, ctitleg_id , count(distinct contact_id) as tcount from Contact_Title_Group_Reference with (NOLOCK)";
				strQuery1 = $"{strQuery1} inner join Contact_Title_Group with (NOLOCK) on ctitlegref_group_name = ctitleg_group_name";
				strQuery1 = $"{strQuery1} inner join Contact_Title wtih (NOLOCK) on ctitlegref_title_name = ctitle_name";
				strQuery1 = $"{strQuery1} inner join Contact with (NOLOCK) on ctitle_name = contact_title and contact_journ_id = 0 and contact_active_flag='Y' and contact_hide_flag='N'";
				strQuery1 = $"{strQuery1} inner join Company with (NOLOCK) on contact_comp_id=comp_id and comp_active_flag='Y' and comp_hide_flag='N' and comp_journ_id = 0";
				strQuery1 = $"{strQuery1} Where ctitleg_id = {Convert.ToString(Label1[52].Tag)}";
				strQuery1 = $"{strQuery1} and contact_id not in (select distinct ctgind_contact_id from Contact_Title_Group_Index with (NOLOCK)";
				strQuery1 = $"{strQuery1} inner join Contact with (NOLOCK) on contact_id = ctgind_contact_id and contact_journ_id = 0";
				strQuery1 = $"{strQuery1} where ctgind_ctitleg_id={Convert.ToString(Label1[52].Tag)})";
				strQuery1 = $"{strQuery1} and (comp_product_business_flag='Y' or comp_product_helicopter_flag='Y' or comp_product_commercial_flag='Y')";
				strQuery1 = $"{strQuery1}  and comp_active_flag='Y' and comp_hide_flag='N'";
			}


			strQuery1 = $"{strQuery1} group by contact_title, ctitleg_group_where_clause, ctitleg_group_name, ctitleg_id ";
			strQuery1 = $"{strQuery1} ORDER  by contact_title";


			this.Cursor = Cursors.WaitCursor;
			lblTotTitles[0].Text = "Searching Titles";

			rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
			rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

			if (!rstRec1.BOF && !rstRec1.EOF)
			{

				cmd_contact_button[8].Visible = true;
				lTot1 = rstRec1.RecordCount;
				lRow1 = 0;

				lblStopTitleLoad[0].Visible = true;
				grd_titles_in_group.Redraw = false;

				do 
				{ // Loop Until rstRec1.EOF = True Or lblStopTitleLoad.Visible = False

					lCol1 = 0;

					lRow1++;
					grd_titles_in_group.RowsCount = lRow1 + 1;
					grd_titles_in_group.CurrentRowIndex = lRow1;

					if (lRow1 == 1)
					{
						txt_contact_title_search[2].Text = "";
						txt_contact_title_search[3].Text = "";

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["ctitleg_group_name"]))
						{
							if (Convert.ToString(rstRec1["ctitleg_group_name"]).Trim() != "")
							{
								txt_contact_title_search[2].Text = Convert.ToString(rstRec1["ctitleg_group_name"]).Trim();
							}
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["ctitleg_group_where_clause"]))
						{
							if (Convert.ToString(rstRec1["ctitleg_group_where_clause"]).Trim() != "")
							{
								txt_contact_title_search[3].Text = Convert.ToString(rstRec1["ctitleg_group_where_clause"]).Trim();
							}
						}
					}



					lblTotTitles[1].Text = $"Unique Contact Titles: {StringsHelper.Format(lTot1, "#,##0")} Working: {StringsHelper.Format(lRow1, "#,##0")}";


					grd_titles_in_group.CurrentColumnIndex = 0;
					grd_titles_in_group.CellBackColor = lBackColor;
					grd_titles_in_group.CellForeColor = lForeColor;
					grd_titles_in_group[grd_titles_in_group.CurrentRowIndex, grd_titles_in_group.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["contact_title"])} ").Trim();

					grd_titles_in_group.CurrentColumnIndex = 1;
					grd_titles_in_group.CellBackColor = lBackColor;
					grd_titles_in_group.CellForeColor = lForeColor;
					grd_titles_in_group[grd_titles_in_group.CurrentRowIndex, grd_titles_in_group.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["tcount"])} ").Trim();

					temp_counter = Convert.ToInt32(temp_counter + Convert.ToDouble(rstRec1["tcount"]));


					if (lRow1 == 29)
					{
						grd_titles_in_group.Redraw = true;
						grd_titles_in_group.Refresh();
						Application.DoEvents();
						grd_titles_in_group.Redraw = false;
					}

					rstRec1.MoveNext();
					Application.DoEvents();

				}
				while(!(rstRec1.EOF || !lblStopTitleLoad[0].Visible));

				lblStopTitleLoad[0].Visible = false;
				grd_titles_in_group.Redraw = true;
				lblTotTitles[1].Text = $"Unique Contact Titles: {StringsHelper.Format(lRow1, "#,##0")}";

				grd_titles_in_group.Enabled = true;

			}
			else
			{
				grd_titles_in_group.CurrentRowIndex = 1;
				grd_titles_in_group.CurrentColumnIndex = 0;
				grd_titles_in_group[grd_titles_in_group.CurrentRowIndex, grd_titles_in_group.CurrentColumnIndex].Value = "No Records Found";
				lblTotTitles[0].Text = "No Records Found";
			} // If (rstRec1.BOF = False And rstRec1.EOF = False) Then

			rstRec1.Close();
			 // FG_Contact_Title

			this.Cursor = CursorHelper.CursorDefault;
			Label1[54].Text = $"Contact Counts: {StringsHelper.Format(temp_counter, "#,##0")}";




		} // Fill_Contact_Title_List


		private void cbo_contact_title_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs)
		{


			Fill_Contact_Title_List_From_Group();

			txt_contact_title_search[4].Visible = false;
			txt_contact_title_search[3].Enabled = true;
			cmd_contact_button[9].Text = "Expand Group";
			frm_update_group.Visible = false;
			cmd_contact_button[7].Visible = true;
			cmd_contact_button[8].Visible = true;
		}

		private void cboEFIG_SelectGroup_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.cboEFIG_SelectGroup, eventSender);
			try
			{
				string aSelection = "";
				int MoveCbo = 0;
				if (Index == 0)
				{
					// turn the panel off
					pnl_EFIG.Visible = false;
					aSelection = cboEFIG_SelectGroup[Index].GetItemData(cboEFIG_SelectGroup[Index].SelectedIndex).ToString();
					txtCIC[2].Text = "";
					// fill the datagrid
					Get_Financial_Group_Companies(Convert.ToInt32(Double.Parse(aSelection)));
					SSTabHelper.SetSelectedIndex(tab_Lists, 0);
					pnl_AddFinGroup.Visible = false;

					MoveCbo = 0;
					if (cboEFIG_SelectGroup[Index].Text != "All")
					{

						while(cboAdd_Comp_Ref.Text != cboEFIG_SelectGroup[Index].Text)
						{
							cboAdd_Comp_Ref.SelectedIndex = MoveCbo;
							MoveCbo++;
						};
					}
					//pnl_SplashScreen.Visible = False
					pnl_EFIG.Visible = true;
					//cboAdd_Comp_Ref.ListIndex = cboEFIG_SelectGroup.ItemData(cboEFIG_SelectGroup.ListIndex)
					//cboAdd_Comp_Ref.ItemData(cboAdd_Comp_Ref.Index) = cboEFIG_SelectGroup.ItemData(cboEFIG_SelectGroup.ListIndex)
				}
				else if (Index == 1)
				{ 
					txtCIC[2].Text = "";
					// clear the combos
					if (cboEFIG_SelectGroup[1].Text != "All")
					{
						//Dim MoveCbo As Integer
						MoveCbo = 0;

						while(cboEFIG_SelectGroup[2].Text != cboEFIG_SelectGroup[1].Text)
						{
							cboEFIG_SelectGroup[2].SelectedIndex = MoveCbo;
							MoveCbo++;
						};
						// cboEFIG_SelectGroup(2).Text = cboEFIG_SelectGroup(1).Text
						Load_Company_SIC_Codes("Combo", cboEFIG_SelectGroup[1].Text);
					}
					else
					{
						cboEFIG_SelectGroup[2].SelectedIndex = 0;
						Load_Company_SIC_Codes("Combo", "");
					}
				}
			}
			catch
			{
				modAdminCommon.Report_Error("Financial Groups: cboEFIG_SelectGroup_Click()");
				return;
			}
		}

		private void cboNIOL_Associate_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				// create an integer to hold if the user picks yes/no
				DialogResult UserPick = (DialogResult) 0;
				// create a string to hold the combobox selection
				string cboSelection = "";
				// create and integer to hold the ID for the Selection
				int cboSelectionID = 0;
				// set the string to the selection
				cboSelection = cboNIOL_Associate.Text;
				// set the integer to the selection for the ID
				cboSelectionID = cboNIOL_Associate.GetItemData(cboNIOL_Associate.SelectedIndex);
				// prompt the user letting them know what they selected, and if they want to associate it with the NIOL selection
				UserPick = MessageBox.Show($"You have chosen: {cboSelection}{Environment.NewLine}Would you like to use this for your association?", "Association", MessageBoxButtons.YesNo);
				// 6 is the user selected 'yes'
				int IDfipg = 0;
				string IDniol = "";
				StringBuilder IN_Clause = new StringBuilder();
				string Query = "";
				int aCounter = 0;
				ADORecordSetHelper RS_Table = null;
				if (UserPick == System.Windows.Forms.DialogResult.Yes)
				{

					// create an integer to hold the ID from the Financial_Institution_Primary_Group table
					// create an integer to hold the ID from the NIOL label
					// create a string to hold the in clasue inf
					// create a string for the query
					// create an integer to count with
					// create a ADOB recordset
					Query = "select fipg_main_comp_id, fipg_comp_id_in_clause from Financial_Institution_Primary_Group ";
					Query = $"{Query}where fipg_main_comp_id='{cboSelectionID.ToString()}'";
					RS_Table = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");
					// Eval RS for nothing
					// set the IDfipg ficr_main_comp_id in the Reference table
					IDfipg = Convert.ToInt32(RS_Table["fipg_main_comp_id"]);
					// set the IDniol ficr_sub_comp_id in the Reference table
					IDniol = lblNIOL_CompanyData[3].Text;
					// reset the IN_Clause for the update
					IN_Clause.Append($",{IDniol}");
					// set the query to associate the info giving it the ID of the selection and the NIOL ID
					Query = "Insert into Financial_Institution_Company_Reference (ficr_main_comp_id, ficr_sub_comp_id, ficr_active_flag) ";
					Query = $"{Query}Values({IDfipg.ToString()},{IDniol},'Y')";
					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = Query;
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();

					Query = "Select ficr_main_comp_id, ficr_sub_comp_id From Financial_Institution_Company_Reference ";
					Query = $"{Query}Where ficr_main_comp_id={IDfipg.ToString()}";
					// Execute the query
					RS_Table = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");
					if (!(RS_Table.EOF && RS_Table.BOF))
					{
						RS_Table.MoveFirst();

						while(!RS_Table.EOF)
						{
							if (aCounter == 0)
							{
								IN_Clause = new StringBuilder(Convert.ToString(RS_Table["ficr_sub_comp_id"]));
							}
							else
							{
								IN_Clause.Append($",{Convert.ToString(RS_Table["ficr_sub_comp_id"])}");
							}
							RS_Table.MoveNext();
							aCounter++;
						};
						RS_Table.Close();
					}
					else
					{
						// Error and exit
						MessageBox.Show("Unable to update info Error", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						// Delete the info you just added???
						return;
					} // If Not (RS_Table.EOF And RS_Table.BOF) Then
					// update the Financial_Institution_Primary_Group table specifically the fipg_comp_id_in_clause
					Query = $"Update Financial_Institution_Primary_Group Set fipg_comp_id_in_clause='{IN_Clause.ToString()}' ";
					Query = $"{Query}Where fipg_main_comp_id={IDfipg.ToString()}";

					DbCommand TempCommand_2 = null;
					TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
					TempCommand_2.CommandText = Query;
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
					TempCommand_2.ExecuteNonQuery();
					modAdminCommon.Table_Action_Log("Financial_Institution_Company_Reference");
					modAdminCommon.Table_Action_Log("Financial_Institution_Primary_Group");
					bolTAL = true;
					// reset the labels to empty strings
					cboNIOL_Associate.Items.Clear();
					if (txtViewOther[1].Text != "")
					{
						LoadNIOL(true, txtViewOther[1].Text);
					}
					else
					{
						LoadNIOL(true, "A");
					}
					if (lblNIOL_CompanyData[7].Text == "0")
					{
						lblNIOL_CompanyData[25].Text = "Please Enter A New Company To Search";
						cmd_Add_Parent_pnlEFIG_NIOL.Visible = false;
						txtViewOther[1].Focus();
						txtViewOther[1].Text = "";
						lblNIOL_CompanyData[0].Visible = false;
						lblNIOL_CompanyData[1].Visible = false;
						lblNIOL_CompanyData[2].Visible = false;
						lblNIOL_CompanyData[3].Visible = false;
						lblNIOL_CompanyData[4].Visible = false;
						lblNIOL_CompanyData[14].Visible = false;
						lblNIOL_CompanyData[15].Visible = false;
						lblNIOL_CompanyData[16].Visible = false;
						lblNIOL_CompanyData[17].Visible = false;
						lblNIOL_CompanyData[18].Visible = false;
						cboNIOL_Associate.Visible = false;
					}
					else
					{
						FG_EFIG_NIOL.CurrentColumnIndex = 0;
						lblNIOL_CompanyData[0].Text = FG_EFIG_NIOL[FG_EFIG_NIOL.CurrentRowIndex, FG_EFIG_NIOL.CurrentColumnIndex].FormattedValue.ToString();
						FG_EFIG_NIOL.CurrentColumnIndex = 1;
						lblNIOL_CompanyData[1].Text = FG_EFIG_NIOL[FG_EFIG_NIOL.CurrentRowIndex, FG_EFIG_NIOL.CurrentColumnIndex].FormattedValue.ToString();
						FG_EFIG_NIOL.CurrentColumnIndex = 2;
						lblNIOL_CompanyData[2].Text = FG_EFIG_NIOL[FG_EFIG_NIOL.CurrentRowIndex, FG_EFIG_NIOL.CurrentColumnIndex].FormattedValue.ToString();
						FG_EFIG_NIOL.CurrentColumnIndex = 3;
						lblNIOL_CompanyData[3].Text = FG_EFIG_NIOL[FG_EFIG_NIOL.CurrentRowIndex, FG_EFIG_NIOL.CurrentColumnIndex].FormattedValue.ToString();
						FG_EFIG_NIOL.CurrentColumnIndex = 4;
						lblNIOL_CompanyData[4].Text = FG_EFIG_NIOL[FG_EFIG_NIOL.CurrentRowIndex, FG_EFIG_NIOL.CurrentColumnIndex].FormattedValue.ToString();

						// populate the combobox for user selection
						Query = "select fipg_generic_name, fipg_main_comp_id  from Financial_Institution_Primary_Group ";
						Query = $"{Query}order by fipg_generic_name, fipg_main_comp_id";

						RS_Table = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

						//If Not IsNull(RS_Table) And (RS_Table.EOF And RS_Table.BOF) Then
						if (!(RS_Table.EOF && RS_Table.BOF))
						{
							RS_Table.MoveFirst();

							while(!RS_Table.EOF)
							{
								cboNIOL_Associate.AddItem(Convert.ToString(RS_Table["fipg_generic_name"]));
								cboNIOL_Associate.SetItemData(cboNIOL_Associate.GetNewIndex(), Convert.ToInt32(RS_Table["fipg_main_comp_id"]));
								RS_Table.MoveNext();
							};
							RS_Table.Close();
							cboNIOL_Associate.SelectedText = "";
						} // If Not (RS_Table.EOF And RS_Table.BOF) Then
					}
				} // for the user picking 6 on the message box
			}
			catch
			{
				modAdminCommon.Report_Error("Financial Groups: cboNIOL_Associate_Click()");
				return;
			}
		}

		private void chk_contact_title_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.chk_contact_title, eventSender);

			if (Index == 1 || Index == 2)
			{
				Fill_Contact_Title_List_From_Group();
			}

		}

		private void chkTitleNotInGroup_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{

			if (chkTitleNotInGroup.CheckState == CheckState.Checked)
			{
				cboTitleNotInGroup.Visible = true;
			}
			else
			{
				cboTitleNotInGroup.Visible = false;
				cboTitleNotInGroup.Text = "";
			}

		}

		private void cmd_Add_CAT_Click(Object eventSender, EventArgs eventArgs)
		{

			RecordStat = "Add";
			txt_cacctype_code.Text = "";
			txt_cacctype_Name.Text = "";
			pnl_CAT_AddUpdate.Visible = true;

		}

		private void cmd_Add_CBT_Click(Object eventSender, EventArgs eventArgs)
		{
			txt_cbus_type.Text = "";
			txt_cbus_Name.Text = "";
			txt_cbus_Desc.Text = "";
			txt_cbus_keywords.Text = "";


			lstBusType.Items.Clear();

			FillBusinessGroupLists("");
			RecordStat = "Add";
			txt_cbus_Name.Enabled = true;
			txt_cbus_Desc.Enabled = true;
			txt_cbus_keywords.Enabled = true;
			cmd_Save_CBT.Enabled = true;
			pnl_CBT_AddUpdate.Visible = true;
			pnl_BusGroup.Visible = true;

		}

		private void cmd_Add_Country_Click(Object eventSender, EventArgs eventArgs)
		{

			pnl_Country_AddUpdate.Visible = true;
			RecordStat = "Add";
			txt_country_code.Text = ""; //Country Phone prefix code
			txt_country_name.Text = "";
			txt_country_language.Text = "";
			txt_country_time_vs_eastern.Text = "";
			txt_country_currency.Text = "";
			txt_country_int_access_code.Text = "";
			txt_Abbrev.Text = "";
			txt_regnbr_prefix.Text = "";
			txt_Continent_Name.Text = "";
			txt_CityCode.Text = "";
			txt_county_grid_row.Text = "0";
			txt_country_name_old.Text = "";
			RegNoList.Items.Clear();

		}



		private void cmd_Add_CS_Click(Object eventSender, EventArgs eventArgs)
		{

			txt_csuffix_name.Text = "";
			pnl_CS_AddUpdate.Visible = true;
			RecordStat = "Add";

		}

		private void cmd_Add_CSN_Click(Object eventSender, EventArgs eventArgs)
		{
			//aey 4/9/04
			txt_csir_name.Text = "";
			pnl_CSN_AddUpdate.Visible = true;
			RecordStat = "Add";

		}

		//UPGRADE_NOTE: (7001) The following declaration (cmd_Add_CT_Click) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void cmd_Add_CT_Click()
		//{
			//
			//
		//}

		private void cmd_Add_Currency_Click(Object eventSender, EventArgs eventArgs)
		{
			//aey 4/19/04
			txt_currency_name[0].Text = "";
			txt_currency_name[1].Text = "";
			txt_currency_name[2].Text = DateTimeHelper.ToString(DateTime.Now);
			txt_currency_name[3].Text = "";
			txt_currency_name[4].Text = "";
			txt_currency_name[5].Text = "";
			RecordStat = "Add";
			pnl_Currency_Change.Visible = true;
		}

		private void cmd_add_fracPG_Click(Object eventSender, EventArgs eventArgs)
		{
			int Prog_id = 0;

			FG_FracPrograms.CurrentColumnIndex = 0;

			txt_FracPG_name.Text = "";
			txt_fracPG_desc.Text = "";
			txt_fracPG_code.Text = "";
			txtFracProg_id.Text = "";
			chk_active_fracpg.CheckState = CheckState.Checked;
			chk_major_fracPG.CheckState = CheckState.Unchecked;
			pnl_add_frac_Program.Visible = true;
			RecordStat = "Add";
		}

		private void cmd_Add_GAT_Click(Object eventSender, EventArgs eventArgs)
		{

			pnl_GAT_AddUpdate.Visible = true;
			txt_cagtype_code.Text = "";
			txt_cagtype_Name.Text = "";
			RecordStat = "Add";

		}

		private void cmd_Add_Language_Click(Object eventSender, EventArgs eventArgs)
		{

			pnl_Language_AddUpdate.Visible = true;
			RecordStat = "Add";
			txt_language_name.Enabled = true;
			cmd_Save_Language.Enabled = true;
			txt_language_name.Text = "";

		}

		private void cmd_Add_Parent_pnlEFIG_NIOL_Click(Object eventSender, EventArgs eventArgs)
		{
			// Turn the add panel on and hide the EFIG
			bolPanelJump = true;
			pnlEFIG_Add_Group.Visible = true;
			//pnlEFIG_NIOL.Visible = False
			txtFIG_Name.Text = lblNIOL_CompanyData[0].Text;
			txtFG_PID.Text = lblNIOL_CompanyData[3].Text;
		}

		private void cmd_Add_PT_Click(Object eventSender, EventArgs eventArgs)
		{
			FG_Phone_Type.CurrentColumnIndex = 0;
			txt_ptype_name.Text = "";
			txt_ptype_name.ReadOnly = false;
			FG_Phone_Type.CurrentColumnIndex = 1;
			txt_ptype_seq_no.Text = "";
			FG_Phone_Type.CurrentColumnIndex = 2;
			txt_ptype_abbrev.Text = "";
			RecordStat = "Add";
			pnl_PT_AddUpdate.Visible = true;

		}

		private void cmd_Add_State_Click(Object eventSender, EventArgs eventArgs)
		{

			txt_state_code.Text = "";
			txt_state_name.Text = "";
			txt_state_loc.Text = "";
			//txt_state_timezone = ""
			CMB_State_TimeZone.SelectedIndex = 0;
			cmb_state_country.SelectedIndex = 0;
			//UPGRADE_ISSUE: (2064) ComboBox property cmb_state_country.Locked was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			cmb_state_country.setLocked(false);
			RecordStat = "Add";

			pnl_State_AddUpdate.Visible = true;
			txt_state_code.Focus();
		}

		private void cmd_Add_TZ_Click(Object eventSender, EventArgs eventArgs)
		{

			RecordStat = "Add";
			txt_tzone_name.Text = "";
			txt_tzone_sort_num.Text = "";
			txt_tzone_time_vs_eastern.Text = "";
			txt_tzone_name.ReadOnly = false;
			pnl_TZ_AddUpdate.Visible = true;

		}


		private void cmd_ASP_dot_Net_Click(Object eventSender, EventArgs eventArgs)
		{
			string Quote = "\"";
			int Homebase_Info = FileSystem.FreeFile();
			//open the file for writing
			FileSystem.FileOpen(Homebase_Info, "C:\\Windows\\Temp\\Homebase_Info.xml", OpenMode.Output, OpenAccess.Default, OpenShare.Default, -1);
			//write to the file, this will overwrite and existing info
			// add the xml version
			FileSystem.PrintLine(Homebase_Info, $"<?xml version={Quote}1.0{Quote} ?>");
			// add any comments
			FileSystem.PrintLine(Homebase_Info, "<!--  Comments: Homebase Info for ASP.NET application -->");
			// create the Instruction info
			FileSystem.PrintLine(Homebase_Info, "<?Instruction Homebase User Selection Info?>");
			// create the ASPNET tag
			FileSystem.PrintLine(Homebase_Info, "<ASPNET>");
			// create the CompanyID tag - Company the user has selected
			FileSystem.PrintLine(Homebase_Info, "<CompanyID>30075</CompanyID>");
			// create the  AircraftID tag - Aircraft the user has selected
			FileSystem.PrintLine(Homebase_Info, "<AircraftID>32015</AircraftID>");
			// create the ContactID tag - Contact the user has selected
			FileSystem.PrintLine(Homebase_Info, "<ContactID>2233</ContactID>");
			// create the JournID tag - Journ the user has selected
			FileSystem.PrintLine(Homebase_Info, "<JournID>5892</JournID>");
			// create the RefID tag - Ref the user has selected
			FileSystem.PrintLine(Homebase_Info, "<RefID>90</RefID>");
			// create the Form tag - Form the user was on
			FileSystem.PrintLine(Homebase_Info, "<Form>frmCompany</Form>");
			// close the ASPNET tag
			FileSystem.PrintLine(Homebase_Info, "</ASPNET>");
			//close the file so we can open it
			FileSystem.FileClose(Homebase_Info);
			// launch the aspx page, which will read the xml file on load
			//UPGRADE_TODO: (7005) parameters (if any) must be set using the Arguments property of ProcessStartInfo More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-7005
			Process.Start($"C:\\Program Files (x86)\\Internet Explorer\\iexplore.exe http://localhost/VB6%20to%20.NET%20setup/default.asp?test={Quote}view2{Quote}");
		}

		private void cmd_Cancel_CAT_Click(Object eventSender, EventArgs eventArgs) => pnl_CAT_AddUpdate.Visible = false;


		private void cmd_Cancel_CBT_Click(Object eventSender, EventArgs eventArgs)
		{
			pnl_CBT_AddUpdate.Visible = false;
			pnl_BusGroup.Visible = false;
		}

		private void cmd_Cancel_Country_Click(Object eventSender, EventArgs eventArgs)
		{

			pnl_Country_AddUpdate.Visible = false;
			Label7[1].Visible = false;
			txt_regnbr_prefix.Visible = false;
			cmdRegNoUpdate.Visible = false; //aey 11/28/2005


		}



		private void cmd_Cancel_CS_Click(Object eventSender, EventArgs eventArgs) => pnl_CS_AddUpdate.Visible = false;


		private void cmd_Cancel_CSN_Click(Object eventSender, EventArgs eventArgs) => 
			//4/19/04 aey
			pnl_CSN_AddUpdate.Visible = false;



		private void cmd_Cancel_Currency_Click(Object eventSender, EventArgs eventArgs) => 
			//aey 4/19/04
			pnl_Currency_Change.Visible = false;


		private void cmd_cancel_FracPG_Click(Object eventSender, EventArgs eventArgs) => pnl_add_frac_Program.Visible = false;


		private void cmd_Cancel_GAT_Click(Object eventSender, EventArgs eventArgs) => FG_CompAgency.Visible = false;


		private void cmd_Cancel_Language_Click(Object eventSender, EventArgs eventArgs) => pnl_Language_AddUpdate.Visible = false;


		private void cmd_Cancel_PT_Click(Object eventSender, EventArgs eventArgs) => 
			//4/19/04
			pnl_PT_AddUpdate.Visible = false;


		private void cmd_Cancel_State_Click(Object eventSender, EventArgs eventArgs) => 
			//aey 4/19/2004
			pnl_State_AddUpdate.Visible = false;


		private void cmd_Cancel_TZ_Click(Object eventSender, EventArgs eventArgs) => 
			//aey 4/19/2004   Timezone ("Cancel")
			pnl_TZ_AddUpdate.Visible = false;


		private void cmd_CIC_Click(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.cmd_CIC, eventSender);
			string Query = "";
			string BuildQuery_Values = "";
			string BuildQuery_Insert = "";
			try
			{

				switch(Index)
				{
					case 0 :  // add 
						if (!cmd_CIC[1].Visible)
						{
							cmd_CIC[1].Visible = true;
							cmd_CIC[2].Visible = true;
						} 
						BuildQuery_Insert = ""; 
						BuildQuery_Values = ""; 
						if (txtCIC[0].Text.Trim() != "")
						{
							BuildQuery_Insert = $"{BuildQuery_Insert}csic_code";
							BuildQuery_Values = $"'{txtCIC[0].Text.Trim()}'";
						}
						else
						{
							MessageBox.Show($"The Code cannot be blank{Environment.NewLine}The Add cannot continue", "Blank Code Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							txtCIC[0].Focus();
							return;
						} 
						if (cboEFIG_SelectGroup[2].Text.Trim() != "")
						{
							BuildQuery_Insert = $"{BuildQuery_Insert}, csic_group";
							BuildQuery_Values = $"{BuildQuery_Values},'{cboEFIG_SelectGroup[2].Text.Trim()}'";
						}
						else
						{
							MessageBox.Show($"The Group cannot be blank{Environment.NewLine}The Add cannot continue", "Blank Group Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							cboEFIG_SelectGroup[2].Focus();
							return;
						} 
						if (txtCIC[1].Text != "")
						{
							BuildQuery_Insert = $"{BuildQuery_Insert},  csic_name";
							BuildQuery_Values = $"{BuildQuery_Values},'{txtCIC[1].Text.Trim()}'";
						} 
						if (txtCIC[2].Text != "")
						{
							BuildQuery_Insert = $"{BuildQuery_Insert},  csic_description";
							BuildQuery_Values = $"{BuildQuery_Values},'{StringsHelper.Replace(txtCIC[2].Text.Trim(), "'", "''", 1, -1, CompareMethod.Binary)}'";
						} 
						Query = $"Insert into  Company_SIC_Codes({BuildQuery_Insert}) "; 
						Query = $"{Query}Values({BuildQuery_Values})"; 
						// execute the query into the second table 
						DbCommand TempCommand = null; 
						TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand(); 
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand); 
						TempCommand.CommandText = Query; 
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand); 
						TempCommand.ExecuteNonQuery(); 
						bolTAL_SIC = true; 
						// clear the combos 
						cboEFIG_SelectGroup[1].Items.Clear(); 
						cboEFIG_SelectGroup[2].Items.Clear(); 
						Load_Company_SIC_Codes("Load", ""); 
						 
						break;
					case 1 :  // delete 
						if (MessageBox.Show($"Are You Sure You Want To Delete This Record?{Environment.NewLine}Group: {cboEFIG_SelectGroup[2].Text}{Environment.NewLine}Code: {txtCIC[0].Text}{Environment.NewLine}Name: {txtCIC[1].Text}{Environment.NewLine}Description: {txtCIC[2].Text}", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
						{
							if (txtCIC[0].Text.Trim() == "")
							{
								MessageBox.Show($"The Code cannot be blank{Environment.NewLine}The Add cannot continue", "Blank Code Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
								txtCIC[0].Focus();
								return;
							}
							Query = "Delete From Company_SIC_Codes ";
							Query = $"{Query}Where csic_code={Convert.ToInt32(Double.Parse(txtCIC[0].Text)).ToString()} ";
							DbCommand TempCommand_2 = null;
							TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
							TempCommand_2.CommandText = Query;
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
							TempCommand_2.ExecuteNonQuery();
							bolTAL_SIC = true;
							// clear the combos
							cboEFIG_SelectGroup[1].Items.Clear();
							cboEFIG_SelectGroup[2].Items.Clear();
							txtCIC[2].Text = "";
							// reload the data
							Load_Company_SIC_Codes("Load", "");
						} 
						break;
					case 2 :  // update 
						BuildQuery_Insert = ""; 
						BuildQuery_Values = ""; 
						if (txtCIC[0].Text.Trim() != "")
						{
							BuildQuery_Insert = $"{BuildQuery_Insert}csic_code";
							BuildQuery_Values = $"csic_code='{txtCIC[0].Text.Trim()}'";
						}
						else
						{
							MessageBox.Show($"The Code cannot be blank{Environment.NewLine}The Update cannot continue", "Blank Code Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							txtCIC[0].Focus();
							return;
						} 
						if (cboEFIG_SelectGroup[2].Text != "")
						{
							BuildQuery_Insert = $"{BuildQuery_Insert}, csic_group";
							BuildQuery_Values = $"{BuildQuery_Values}, csic_group='{cboEFIG_SelectGroup[2].Text.Trim()}'";
						}
						else
						{
							MessageBox.Show($"The Group cannot be blank{Environment.NewLine}The Update cannot continue", "Blank Group Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							cboEFIG_SelectGroup[2].Focus();
							return;
						} 
						 
						BuildQuery_Insert = $"{BuildQuery_Insert}, csic_name"; 
						BuildQuery_Values = $"{BuildQuery_Values}, csic_name='{txtCIC[1].Text.Trim()}'"; 
						 
						BuildQuery_Insert = $"{BuildQuery_Insert}, csic_description"; 
						 
						if (Strings.Len(txtCIC[2].Text.Trim()) < txtCIC[2].MaxLength)
						{
							BuildQuery_Values = $"{BuildQuery_Values}, csic_description='{StringsHelper.Replace(txtCIC[2].Text.Trim(), "'", "''", 1, -1, CompareMethod.Binary)}'";
						}
						else
						{
							MessageBox.Show("The description length is too long you may only enter 400 characters", "Description Length Too Long", MessageBoxButtons.OK, MessageBoxIcon.Error);
							txtCIC[2].Focus();
							return;
						} 
						Query = "UPDATE Company_SIC_Codes "; 
						Query = $"{Query}SET {BuildQuery_Values} "; 
						Query = $"{Query}WHERE csic_code={Convert.ToInt32(Double.Parse(txtCIC[0].Text)).ToString()} "; 
						DbCommand TempCommand_3 = null; 
						TempCommand_3 = modAdminCommon.LOCAL_ADO_DB.CreateCommand(); 
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_3); 
						TempCommand_3.CommandText = Query; 
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_3); 
						TempCommand_3.ExecuteNonQuery(); 
						bolTAL_SIC = true; 
						// clear the combos 
						cboEFIG_SelectGroup[1].Items.Clear(); 
						cboEFIG_SelectGroup[2].Items.Clear(); 
						// reload the data 
						Load_Company_SIC_Codes("Load", ""); 
						 
						break;
					case 3 :  // new 
						 
						txtCIC[0].Text = ""; 
						txtCIC[1].Text = ""; 
						txtCIC[2].Text = ""; 
						cmd_CIC[1].Visible = false; 
						cmd_CIC[2].Visible = false; 
						 
						break;
					case 4 :  // add 
						// reload the data 
						cboEFIG_SelectGroup[1].Text = ""; 
						cboEFIG_SelectGroup[2].Text = ""; 
						cboEFIG_SelectGroup[2].Items.Clear(); 
						cboEFIG_SelectGroup[1].Items.Clear(); 
						cmd_CIC[1].Visible = true; 
						cmd_CIC[2].Visible = true; 
						Load_Company_SIC_Codes("Load", ""); 
						break;
				}
			}
			catch (System.Exception excep)
			{
				modAdminCommon.Report_Error($"Load_Company_SIC_Codes(){excep.Message}");
				return;
			}

		}


		private void cmd_contact_button_Click(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.cmd_contact_button, eventSender);


			try
			{

				string update_string = "";


				cmd_contact_button[9].PerformClick();


				string temp_string = "";
				if (Index == 0)
				{
					Fill_Contact_Title_List_From_Contact();
				}
				else if (Index == 1)
				{ 

					if (MessageBox.Show($"This will update {Convert.ToString(cmd_contact_button[1].Tag)} Aircraft Records, Are you Sure? ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
					{

						update_string = $"Update Contact set contact_title = '{txt_contact_title_search[1].Text}', contact_action_date = NULL ";
						update_string = $"{update_string} where contact_title = '{Convert.ToString(txt_contact_title_search[1].Tag)}' ";
						update_string = $"{update_string} and contact_journ_id = 0 ";
						DbCommand TempCommand = null;
						TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
						TempCommand.CommandText = update_string;
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
						TempCommand.ExecuteNonQuery();
						Fill_Contact_Title_List_From_Contact();
					}
				}
				else if (Index == 2)
				{ 
					pnl_CT_AddUpdate.Visible = false;
					pnl_ContactTitleGroup.Visible = false;
				}
				else if (Index == 3)
				{ 

					int tempForEndVar = lstAllTitleGroups.Items.Count - 1;
					for (int I = 0; I <= tempForEndVar; I++)
					{
						if (ListBoxHelper.GetSelected(lstAllTitleGroups, I))
						{
							lstTitleGroup.AddItem(lstAllTitleGroups.GetListItem(I));
							lstAllTitleGroups.RemoveItem(I);
							I--;
						}

						if (I >= lstAllTitleGroups.Items.Count - 1)
						{
							break;
						}
					}

				}
				else if (Index == 4)
				{ 


					int tempForEndVar2 = lstTitleGroup.Items.Count - 1;
					for (int I = 0; I <= tempForEndVar2; I++)
					{
						if (ListBoxHelper.GetSelected(lstTitleGroup, I))
						{
							lstAllTitleGroups.AddItem(lstTitleGroup.GetListItem(I), I);
							lstTitleGroup.RemoveItem(I);
							I--;
						}

						if (I >= lstTitleGroup.Items.Count - 1)
						{
							break;
						}

					}
				}
				else if (Index == 5)
				{ 

					txt_ctitle_name.Text = "";
					chk_ctitle_active_flag.CheckState = CheckState.Checked;
					lstTitleGroup.Items.Clear();
					FillTitleGroupLists("");
					RecordStat = "Add";
					txt_ctitle_name.Enabled = true;
					cmd_Save_CT.Enabled = true;
					pnl_CT_AddUpdate.Visible = true;
					pnl_ContactTitleGroup.Visible = true;
				}
				else if (Index == 6)
				{ 
					//-- search button
					if ((txt_title_search.Text.Trim() != "") || (cboSearchTitleGroup.Text.Trim() != "") || (chkTitlesNotMapped.CheckState == CheckState.Checked) || (chkPilotsNotInPilotsGroup.CheckState == CheckState.Checked) || (chkChairmanCEONotInChairmanCEOGroup.CheckState == CheckState.Checked) || (chkCFONotInCFOGroup.CheckState == CheckState.Checked))
					{
						Fill_Contact_Title_List();
					}
				}
				else if (Index == 7)
				{ 

					if (pass_bad_check(txt_contact_title_search[3].Text))
					{
						if (Convert.ToString(Label1[52].Tag).Trim() != "" && Convert.ToString(Label1[52].Tag).Trim() != "0")
						{
							update_string = $"Update Contact_Title_Group set ctitleg_group_name = '{txt_contact_title_search[2].Text}', ctitleg_group_where_clause = '{StringsHelper.Replace(txt_contact_title_search[3].Text, "'", "''", 1, -1, CompareMethod.Binary)}' ";
							update_string = $"{update_string} where ctitleg_id = '{Convert.ToString(Label1[52].Tag).Trim()}' ";


							this.Cursor = Cursors.WaitCursor;
							// MsgBox (update_string)
							DbCommand TempCommand_2 = null;
							TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
							TempCommand_2.CommandText = update_string;
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
							TempCommand_2.ExecuteNonQuery();

							DbCommand TempCommand_3 = null;
							TempCommand_3 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_3);
							TempCommand_3.CommandText = $"exec sp_RefreshContactTitleGroupsforGroup {Convert.ToString(Label1[52].Tag).Trim()}";
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_3);
							TempCommand_3.ExecuteNonQuery();

							this.Cursor = CursorHelper.CursorDefault;
							MessageBox.Show("Contact Title Group Updated", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK);
							Fill_Contact_Title_List_From_Group();
							frm_update_group.Visible = false;
							cmd_contact_button[8].Visible = true;
							cmd_contact_button[9].PerformClick();

						}
					}

				}
				else if (Index == 8)
				{ 
					frm_update_group.Visible = true;
					cmd_contact_button[8].Visible = false;

				}
				else if (Index == 9)
				{ 

					if (txt_contact_title_search[4].Visible)
					{
						// set it to any changes that have been made
						txt_contact_title_search[3].Text = txt_contact_title_search[4].Text;
						txt_contact_title_search[4].Visible = false;
						txt_contact_title_search[3].Enabled = true;
						cmd_contact_button[7].Visible = true;
						grd_titles_in_group.Visible = true;
						cmd_contact_button[9].Text = "Expand Group";
					}
					else
					{
						// reset the box to be in the same spot
						txt_contact_title_search[3].Visible = true;
						txt_contact_title_search[3].Height = 73;
						txt_contact_title_search[3].Left = 8;
						txt_contact_title_search[3].Top = 48;
						txt_contact_title_search[3].Width = 553;


						txt_contact_title_search[4].Visible = true;
						temp_string = txt_contact_title_search[3].Text;
						temp_string = StringsHelper.Replace(temp_string, Environment.NewLine, "", 1, -1, CompareMethod.Binary);
						temp_string = StringsHelper.Replace(temp_string, "OR ", $"{Environment.NewLine}OR ", 1, -1, CompareMethod.Binary);
						temp_string = StringsHelper.Replace(temp_string, "AND ", $"{Environment.NewLine}AND ", 1, -1, CompareMethod.Binary);
						temp_string = StringsHelper.Replace(temp_string, "and ", $"{Environment.NewLine}AND ", 1, -1, CompareMethod.Binary);
						temp_string = StringsHelper.Replace(temp_string, ") )", $"){Environment.NewLine})", 1, -1, CompareMethod.Binary);
						temp_string = StringsHelper.Replace(temp_string, "( (", $"({Environment.NewLine}(", 1, -1, CompareMethod.Binary);
						temp_string = StringsHelper.Replace(temp_string, "))", $"){Environment.NewLine})", 1, -1, CompareMethod.Binary);
						temp_string = StringsHelper.Replace(temp_string, "((", $"({Environment.NewLine}(", 1, -1, CompareMethod.Binary);

						txt_contact_title_search[4].Text = temp_string;


						txt_contact_title_search[3].Enabled = false;
						cmd_contact_button[9].Text = "Shrink Group";
						cmd_contact_button[7].Visible = false;
						grd_titles_in_group.Visible = false;
					}



				}
			}
			catch
			{

				MessageBox.Show("Error, Action Not Completed", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK);
				this.Cursor = CursorHelper.CursorDefault;
				//Report_Error ("Country_Delete_Error: ")
				return;
			}

		}


		private void cmd_Delete_CAT_Click(Object eventSender, EventArgs eventArgs)
		{

			string Query = "";
			string Query2 = "";
			string M = "";
			DialogResult RESP = (DialogResult) 0;

			if (modAdminCommon.Exist($"SELECT * FROM Company WHERE comp_account_type = '{txt_cacctype_code.Text}'"))
			{
				M = $"Company Account Type   '{txt_cacctype_code.Text}',   currently used in the Company Table.";
				MessageBox.Show(M, "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else if (modAdminCommon.Exist($"SELECT * FROM Company_Account_Type WHERE cacctype_code = '{txt_cacctype_code.Text}'"))
			{ 
				Query = "DELETE FROM Company_Account_Type";
				Query = $"{Query} WHERE cacctype_code='{txt_cacctype_code.Text.Trim()}'";
				M = $"Company_Account_Type Delete For: {txt_cacctype_code.Text.Trim()}{"\r"}{"\r"}";
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

					Is_Dirty = true;
					FG_Cat_List.RemoveItem(FG_Cat_List.CurrentRowIndex);
					MessageBox.Show("Delete Successfully Completed", "DELETE COMPLETED", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					MessageBox.Show("Delete cancelled by user", "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			else
			{
				M = $"Company Account Type   '{txt_cacctype_code.Text}',   not currently in the Company_Account_Type Table.";
				MessageBox.Show(M, "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}

			FG_Cat_List.Refresh();
			pnl_CAT_AddUpdate.Visible = false;
			Application.DoEvents();


		}



		public void Fill_Contact_Title_List_From_Contact()
		{

			int NewTab = 0; //Current tab

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = ""; //Current query sql

			string FLDS = ""; //work fields for query string
			string VALS = ""; //value work fields for query string
			string Comma = ""; //comma work field for query string
			int nRow = 0; //Current row counter
			int Ans = 0; //Answer to question
			Control Grd = null;
			Color lForeColor = System.Drawing.Color.Black;

			int lRow1 = 0;
			int lCol1 = 0;
			int lTot1 = 0;
			int temp_counter = 0;
			Color lBackColor = Color.White;
			frm_update_frame.Visible = false;

			cmd_contact_button[0].Enabled = false;

			pnl_CT_AddUpdate.Visible = false;
			pnl_ContactTitleGroup.Visible = false;

			Fill_Contacdt_Title_List_Headers_For_Contact();


			FG_Contact_Title_New.Enabled = false;

			strQuery1 = " select distinct contact_title, count(distinct contact_id) as tcount from contact with (NOLOCK) ";
			strQuery1 = $"{strQuery1} inner join company with (NOLOCK) on comp_id = contact_comp_id and comp_journ_id = 0 and (comp_product_business_flag = 'Y' or comp_product_commercial_flag = 'Y' or comp_product_helicopter_flag = 'Y') and comp_active_flag = 'Y' and comp_hide_flag = 'N' ";


			strQuery1 = $"{strQuery1} where contact_journ_id = 0  and contact_title <> '' and contact_title is not null ";
			strQuery1 = $"{strQuery1} and contact_active_flag = 'Y' and contact_hide_flag = 'N' ";

			if (txt_contact_title_search[0].Text.Trim() != "")
			{
				strQuery1 = $"{strQuery1} and contact_title like '%{txt_contact_title_search[0].Text}%' ";
			}


			if (chk_contact_title[0].CheckState == CheckState.Checked)
			{
				strQuery1 = $"{strQuery1} and contact_id not in (select distinct ctgind_contact_id from Contact_Title_Group_Index with (NOLOCK)) ";
			}

			strQuery1 = $"{strQuery1} group by contact_title order by contact_title asc ";


			lblTotTitles[0].Text = "Searching Titles";

			rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
			rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

			if (!rstRec1.BOF && !rstRec1.EOF)
			{

				FG_Contact_Title_New.Visible = true;
				lblTotTitles[0].Visible = true;
				Label1[53].Visible = true;

				lTot1 = rstRec1.RecordCount;
				lRow1 = 0;

				lblStopTitleLoad[0].Visible = true;
				FG_Contact_Title_New.Redraw = false;

				do 
				{ // Loop Until rstRec1.EOF = True Or lblStopTitleLoad.Visible = False

					lCol1 = 0;

					lRow1++;
					FG_Contact_Title_New.RowsCount = lRow1 + 1;
					FG_Contact_Title_New.CurrentRowIndex = lRow1;

					lblTotTitles[0].Text = $"Unique Contact Titles: {StringsHelper.Format(lTot1, "#,##0")} Working: {StringsHelper.Format(lRow1, "#,##0")}";

					FG_Contact_Title_New.CurrentColumnIndex = 0;
					FG_Contact_Title_New.CellBackColor = lBackColor;
					FG_Contact_Title_New.CellForeColor = lForeColor;
					FG_Contact_Title_New[FG_Contact_Title_New.CurrentRowIndex, FG_Contact_Title_New.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["contact_title"])} ").Trim();

					FG_Contact_Title_New.CurrentColumnIndex = 1;
					FG_Contact_Title_New.CellBackColor = lBackColor;
					FG_Contact_Title_New.CellForeColor = lForeColor;
					FG_Contact_Title_New[FG_Contact_Title_New.CurrentRowIndex, FG_Contact_Title_New.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["tcount"])} ").Trim();

					temp_counter = Convert.ToInt32(temp_counter + Convert.ToDouble(rstRec1["tcount"]));


					if (lRow1 == 29)
					{
						FG_Contact_Title_New.Redraw = true;
						FG_Contact_Title_New.Refresh();
						Application.DoEvents();
						FG_Contact_Title_New.Redraw = false;
					}

					rstRec1.MoveNext();
					Application.DoEvents();

				}
				while(!(rstRec1.EOF || !lblStopTitleLoad[0].Visible));

				lblStopTitleLoad[0].Visible = false;
				FG_Contact_Title_New.Redraw = true;
				lblTotTitles[0].Text = $"Unique Contact Titles:: {StringsHelper.Format(lRow1, "#,##0")}";

				FG_Contact_Title_New.Enabled = true;

			}
			else
			{
				FG_Contact_Title_New.CurrentRowIndex = 1;
				FG_Contact_Title_New.CurrentColumnIndex = 0;
				FG_Contact_Title_New[FG_Contact_Title_New.CurrentRowIndex, FG_Contact_Title_New.CurrentColumnIndex].Value = "No Records Found";
				lblTotTitles[0].Text = "No Records Found";
			} // If (rstRec1.BOF = False And rstRec1.EOF = False) Then

			rstRec1.Close();
			 // FG_Contact_Title

			Label1[53].Text = $"Contact Counts: {StringsHelper.Format(temp_counter, "#,##0")}";

			cmd_contact_button[0].Enabled = true;


		} // Fill_Contact_Title_List

		public void Fill_Contacdt_Title_List_Headers_For_Contact()
		{


			FG_Contact_Title_New.Clear();
			FG_Contact_Title_New.RowsCount = 2;
			FG_Contact_Title_New.ColumnsCount = 2;

			FG_Contact_Title_New.CurrentRowIndex = 0;

			FG_Contact_Title_New.CurrentColumnIndex = 0;
			FG_Contact_Title_New[FG_Contact_Title_New.CurrentRowIndex, FG_Contact_Title_New.CurrentColumnIndex].Value = "Contact Title";
			FG_Contact_Title_New.SetColumnWidth(FG_Contact_Title_New.CurrentColumnIndex, 313);

			FG_Contact_Title_New.CurrentColumnIndex = 1;
			FG_Contact_Title_New[FG_Contact_Title_New.CurrentRowIndex, FG_Contact_Title_New.CurrentColumnIndex].Value = "#Contact";
			FG_Contact_Title_New.SetColumnWidth(FG_Contact_Title_New.CurrentColumnIndex, 80);

			FG_Contact_Title_New.CurrentRowIndex = 1;
			FG_Contact_Title_New.CurrentColumnIndex = 0;
			FG_Contact_Title_New.FixedRows = 1;
			FG_Contact_Title_New.FixedColumns = 0;
			 // FG_Contact_Title

		} // Fill_Contacdt_Title_List_Headers
		private void cmd_Delete_CBT_Click(Object eventSender, EventArgs eventArgs)
		{
			DialogResult RESP = (DialogResult) 0;

			ADORecordSetHelper RS_Table2 = new ADORecordSetHelper(); //Current recordset

			int test_count = 0;

			string Query = $"select count(*) as tcount From business_type_reference where bustypref_type= '{txt_cbus_type.Text}' ";

			RS_Table2.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);
			if (!(RS_Table2.BOF && RS_Table2.EOF))
			{
				RS_Table2.MoveFirst();

				while(!RS_Table2.EOF)
				{
					test_count = Convert.ToInt32(RS_Table2["tcount"]);
					RS_Table2.MoveNext();
				};
			}


			string M = "";
			if (test_count == 0)
			{


				if (modAdminCommon.Exist($"SELECT * FROM Company WHERE comp_business_type = '{txt_cbus_type.Text}'"))
				{
					M = $"Company Business Type   '{txt_cbus_type.Text}',   currently used in the Company Table.";
					MessageBox.Show(M, "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				else if (modAdminCommon.Exist($"SELECT * FROM Company_Business_Type WHERE cbus_type = '{txt_cbus_type.Text}'"))
				{ 
					Query = "DELETE FROM Company_Business_Type";
					Query = $"{Query} WHERE cbus_type='{txt_cbus_type.Text.Trim()}'";
					M = $"Company_Business_Type Delete For: {txt_cbus_type.Text.Trim()}{"\r"}{"\r"}";
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

						Query = $"DELETE FROM Company_Business_Type_Group_Reference WHERE cbtgr_business_type = '{txt_cbus_type.Text.Trim()}'";

						DbCommand TempCommand_2 = null;
						TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
						TempCommand_2.CommandText = Query;
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
						TempCommand_2.ExecuteNonQuery();

						Is_Dirty = true;
						FG_CBTList.RemoveItem(FG_CBTList.CurrentRowIndex);
						MessageBox.Show("Delete Successfully Completed", "DELETE COMPLETED", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else
					{
						MessageBox.Show("Delete Canceled by user", "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
				}
				else
				{
					M = $"Company Business Type   '{txt_cbus_type.Text}',   not currently in the Company_Business_Type Table.";
					MessageBox.Show(M, "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}

				pnl_CBT_AddUpdate.Visible = false;
				pnl_BusGroup.Visible = false;
				FG_CBTList.Refresh();
			}
			else
			{
				MessageBox.Show($"There is Currently {test_count.ToString()} Companies Attached to this Business Type- Unable To Delete", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}

		private void cmd_Delete_Country_Click(Object eventSender, EventArgs eventArgs)
		{
			//aey 4/19/2004 Country ("Delete")
			string Query = "";
			string Query2 = "";
			DialogResult RESP = (DialogResult) 0;
			string M = "";

			try
			{
				Label7[1].Visible = false;
				txt_regnbr_prefix.Visible = false;
				pnl_Country_AddUpdate.Visible = false;
				cmdRegNoUpdate.Visible = false; //aey 11/28/2005
				if (modAdminCommon.Exist($"SELECT * FROM Company WHERE comp_country = '{txt_country_name.Text}'"))
				{
					M = $"Country   '{txt_country_name.Text}',   currently used in the Company Table.";
					MessageBox.Show(M, "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				else if (modAdminCommon.Exist($"SELECT * FROM Country WHERE Country_name = '{txt_country_name.Text}'"))
				{ 
					Query = $"DELETE FROM Country WHERE Country_name = '{modAdminCommon.Fix_Quote(txt_country_name)}'";

					Query2 = $"Delete from Registration_Number_Prefix where regnbrpref_country_name ='{modAdminCommon.Fix_Quote(txt_country_name)}'";


					M = $"Country Delete For: {txt_country_name.Text.Trim()}{"\r"}{"\r"}";
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
						Is_Dirty = true;

						DbCommand TempCommand_2 = null;
						TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
						TempCommand_2.CommandText = Query2;
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
						TempCommand_2.ExecuteNonQuery();
						FG_Country.RemoveItem(FG_Country.CurrentRowIndex);
						FG_Country.Refresh();
						MessageBox.Show("Delete Successfully Completed.", "DELETE COMPLETED", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else
					{
						MessageBox.Show("Delete Canceled.", "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}
				else
				{
					M = $"Country   '{txt_country_name.Text}',   not currently in the Country Table.";
					MessageBox.Show(M, "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}

				this.Cursor = CursorHelper.CursorDefault;
			}
			catch
			{

				this.Cursor = CursorHelper.CursorDefault;
				modAdminCommon.Report_Error("Country_Delete_Error: ");
				return;
			}
		}



		private void cmd_Delete_CS_Click(Object eventSender, EventArgs eventArgs)
		{
			//4/19/04 aey
			string Query = "";
			string M = "";
			DialogResult RESP = (DialogResult) 0;

			if (modAdminCommon.Exist($"SELECT * FROM Contact_suffix WHERE csuffix_name = '{txt_csuffix_name.Text}'"))
			{
				Query = "DELETE FROM Contact_suffix";
				Query = $"{Query} WHERE csuffix_name='{txt_csuffix_name.Text.Trim()}'";
				M = $"Contact_suffix Delete For: {txt_csuffix_name.Text.Trim()}{"\r"}{"\r"}";
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
					Is_Dirty = true;
					MessageBox.Show("Delete Successfully Completed", "DELETE COMPLETED", MessageBoxButtons.OK, MessageBoxIcon.Information);
					FG_Contact_Suffix.RemoveItem(FG_Contact_Suffix.CurrentRowIndex);
					FG_Contact_Suffix.Refresh();
				}
				else
				{
					MessageBox.Show("Delete cancelled by user", "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			else
			{
				M = $"Contact_suffix   '{txt_csuffix_name.Text}',   not currently in the Contact_suffix Table.";
				MessageBox.Show(M, "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			pnl_CS_AddUpdate.Visible = false;

		}

		private void cmd_Delete_CSN_Click(Object eventSender, EventArgs eventArgs)
		{
			//4/19/04 aey
			string Query = "";
			string M = "";
			DialogResult RESP = (DialogResult) 0;

			if (modAdminCommon.Exist($"SELECT * FROM Contact_Sirname WHERE csir_name = '{txt_csir_name.Text}'"))
			{
				Query = "DELETE FROM Contact_Sirname";
				Query = $"{Query} WHERE csir_name='{txt_csir_name.Text.Trim()}'";
				M = $"Contact_Sirname Delete For: {txt_csir_name.Text.Trim()}{"\r"}{"\r"}";
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
					Is_Dirty = true;
					MessageBox.Show("Delete Successfully Completed", "DELETE COMPLETED", MessageBoxButtons.OK, MessageBoxIcon.Information);
					FG_Contact_SirName.RemoveItem(FG_Contact_SirName.CurrentRowIndex);
					FG_Contact_SirName.Refresh();
				}
				else
				{
					MessageBox.Show("Delete cancelled by user", "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			else
			{
				M = $"Contact_Sirname   '{txt_csir_name.Text}',   not currently in the Contact_Sirname Table.";
				MessageBox.Show(M, "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			pnl_CSN_AddUpdate.Visible = false;

		}

		private void cmd_Delete_CT_Click(Object eventSender, EventArgs eventArgs)
		{
			string Query = "";
			string M = "";
			DialogResult RESP = (DialogResult) 0;

			if (modAdminCommon.Exist($"SELECT * FROM Contact WHERE contact_title = '{txt_ctitle_name.Text}'"))
			{
				M = $"Contact_Title   '{txt_ctitle_name.Text}',   currently used in the Contact Table.";
				MessageBox.Show(M, "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else if (modAdminCommon.Exist($"SELECT * FROM Contact_Title WHERE ctitle_name = '{txt_ctitle_name.Text}'"))
			{ 
				M = $"Contact_Title Delete For: {txt_ctitle_name.Text.Trim()}{"\r"}{"\r"}";
				M = $"{M}Do you wish to perform the delete at this time?";
				RESP = MessageBox.Show(M, "Confirm Delete!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (RESP == System.Windows.Forms.DialogResult.Yes)
				{
					Query = "DELETE FROM Contact_Title";
					Query = $"{Query} WHERE ctitle_name='{txt_ctitle_name.Text.Trim()}'";
					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = Query;
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();
					Query = "DELETE FROM Contact_Title_Group_Reference ";
					Query = $"{Query}WHERE ctitlegref_title_name = '{txt_ctitle_name.Text.Trim()}'";
					//Call LOCAL_DB.Execute(QUERY, dbSQLPassThrough)
					DbCommand TempCommand_2 = null;
					TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
					TempCommand_2.CommandText = Query;
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
					TempCommand_2.ExecuteNonQuery();
					Is_Dirty = true;
					FG_Contact_Title.RemoveItem(FG_Contact_Title.CurrentRowIndex);
					FG_Contact_Title.Refresh();
					MessageBox.Show("Delete Successfully Completed", "DELETE COMPLETED", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					MessageBox.Show("Delete cancelled by user", "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			else
			{
				M = $"Contact_Title   '{txt_ctitle_name.Text}',   not currently in the Contact_Title Table.";
				MessageBox.Show(M, "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}

			pnl_CT_AddUpdate.Visible = false;
			pnl_ContactTitleGroup.Visible = false;

		}

		private void cmd_Delete_Currency_Click(Object eventSender, EventArgs eventArgs)
		{
			string Query = "";
			string M = "";
			DialogResult RESP = (DialogResult) 0;
			if (modAdminCommon.Exist($"SELECT * FROM currency WHERE currency_name = '{txt_currency_name[0].Text}'"))
			{
				Query = "DELETE FROM currency";
				Query = $"{Query} WHERE currency_name='{txt_currency_name[0].Text.Trim()}'";
				M = $"currency Delete For: {txt_currency_name[0].Text.Trim()}{"\r"}{"\r"}";
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
					Is_Dirty = true;
					MessageBox.Show("Delete Successfully Completed", "DELETE COMPLETED", MessageBoxButtons.OK, MessageBoxIcon.Information);
					FG_Currency.RemoveItem(FG_Currency.CurrentRowIndex);
					FG_Currency.Refresh();
				}
				else
				{
					MessageBox.Show("Delete cancelled by user", "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			else
			{
				M = $"currency   '{txt_currency_name[0].Text}',   not currently in the currency Table.";
				MessageBox.Show(M, "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}

			pnl_Currency_Change.Visible = false;

		}

		private void cmd_delete_fracPG_Click(Object eventSender, EventArgs eventArgs)
		{
			//4/19/04 aey
			string Query = "";
			string M = "";
			DialogResult RESP = (DialogResult) 0;

			if (Conversion.Val($"{txtFracProg_id.Text}") == 0)
			{
				return;
			}
			if (modAdminCommon.Exist($"SELECT * FROM aircraft_programs WHERE prog_id = {txtFracProg_id.Text} "))
			{
				Query = "DELETE FROM aircraft_programs ";
				Query = $"{Query} WHERE prog_id = {txtFracProg_id.Text} ";
				M = $"Fractional Program Delete For: {($"{txt_FracPG_name.Text}").Trim()}{"\r"}{"\r"}";
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
					Is_Dirty = true;
					MessageBox.Show("Delete Successfully Completed", "DELETE COMPLETED", MessageBoxButtons.OK, MessageBoxIcon.Information);
					modAdminCommon.Table_Action_Log("aircraft_programs");
					FG_FracPrograms.RemoveItem(FG_Contact_SirName.CurrentRowIndex);
					FG_FracPrograms.Refresh();
				}
				else
				{
					MessageBox.Show("Delete cancelled by user", "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			else
			{
				M = $"Fractional Program  '{FG_FracPrograms[FG_FracPrograms.CurrentRowIndex, FG_FracPrograms.CurrentColumnIndex].FormattedValue.ToString()}',   not currently in the Aircraft Programs Table.";
				MessageBox.Show(M, "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			pnl_add_frac_Program.Visible = false;

		}

		private void cmd_Delete_GAT_Click(Object eventSender, EventArgs eventArgs)
		{

			string Query = "";
			DialogResult RESP = (DialogResult) 0;
			string M = "";

			try
			{

				if (modAdminCommon.Exist($"SELECT * FROM Company WHERE comp_agency_type = '{txt_cagtype_code.Text}'"))
				{
					M = $"Company Agency Type   '{txt_cagtype_code.Text}',   currently used in the Company Table.";
					MessageBox.Show(M, "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				else if (modAdminCommon.Exist($"SELECT * FROM Company_Agency_Type WHERE cagtype_code = '{txt_cagtype_code.Text}'"))
				{ 
					Query = "DELETE FROM Company_Agency_Type";
					Query = $"{Query} WHERE cagtype_code='{txt_cagtype_code.Text.Trim()}'";
					M = $"Company_Agency_Type Delete For: {txt_cagtype_code.Text.Trim()}{"\r"}{"\r"}";
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
						Is_Dirty = true;
						FG_CompAgency.RemoveItem(FG_CompAgency.CurrentRowIndex);
						FG_CompAgency.Refresh();
						MessageBox.Show("Delete Successfully Completed", "DELETE COMPLETED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
					else
					{
						MessageBox.Show("Delete Cancelled by user", "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
				}
				else
				{
					M = $"Company Agency Type   '{txt_cagtype_code.Text}',   not currently in the Company_Agency_Type Table.";
					MessageBox.Show(M, "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			catch
			{

				this.Cursor = CursorHelper.CursorDefault;
				modAdminCommon.Report_Error("Company_Agency_Type_Error(d): ");
				return;
			}
		}

		private void cmd_Delete_Language_Click(Object eventSender, EventArgs eventArgs)
		{
			string Query = "";
			string M = "";
			DialogResult RESP = (DialogResult) 0;
			if (modAdminCommon.Exist($"SELECT * FROM company WHERE language_name = '{txt_language_name.Text}'"))
			{
				M = $"Language   '{txt_language_name.Text}',   currently used in the Company Table.";
				MessageBox.Show(M, "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else if (modAdminCommon.Exist($"SELECT * FROM Language WHERE language_name = '{txt_language_name.Text}'"))
			{ 
				Query = "DELETE FROM Language";
				Query = $"{Query} WHERE language_name='{txt_language_name.Text.Trim()}'";
				M = $"Language Delete For: {txt_language_name.Text.Trim()}{"\r"}{"\r"}";
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
					Is_Dirty = true;
					MessageBox.Show("Delete Successfully Completed", "DELETE COMPLETED", MessageBoxButtons.OK, MessageBoxIcon.Information);
					FG_Language.RemoveItem(FG_Language.CurrentRowIndex);
					FG_Language.Refresh();
				}
				else
				{
					MessageBox.Show("Delete cancelled by user", "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			else
			{
				M = $"Language   '{txt_language_name.Text}',   not currently in the Language Table.";
				MessageBox.Show(M, "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			pnl_Language_AddUpdate.Visible = false;

		}

		private void cmd_Delete_PT_Click(Object eventSender, EventArgs eventArgs)
		{
			string Query = "";
			string M = "";
			DialogResult RESP = (DialogResult) 0;

			if (modAdminCommon.Exist($"SELECT * FROM Phone_Numbers WHERE pnum_type = '{txt_ptype_name.Text}'"))
			{
				M = $"Phone_Type   '{txt_ptype_name.Text}',   currently used in the Phone_Numbers Table.";
				MessageBox.Show(M, "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else if (modAdminCommon.Exist($"SELECT * FROM Phone_Type WHERE ptype_name = '{txt_ptype_name.Text}'"))
			{ 
				Query = "DELETE FROM Phone_Type";
				Query = $"{Query} WHERE ptype_name='{txt_ptype_name.Text.Trim()}'";
				M = $"Phone_Type Delete For: {txt_ptype_name.Text.Trim()}{"\r"}{"\r"}";
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
					Is_Dirty = true;
					MessageBox.Show("Delete Successfully Completed", "DELETE COMPLETED", MessageBoxButtons.OK, MessageBoxIcon.Information);
					FG_Phone_Type.RemoveItem(FG_Phone_Type.CurrentRowIndex);
					FG_Phone_Type.Refresh();
				}
				else
				{
					MessageBox.Show("Delete cancelled by user", "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			else
			{
				M = $"Phone_Type   '{txt_ptype_name.Text}',   not currently in the Phone_Type Table.";
				MessageBox.Show(M, "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}

			pnl_PT_AddUpdate.Visible = false;

		}

		private void cmd_Delete_State_Click(Object eventSender, EventArgs eventArgs)
		{
			string Query = "";
			string M = "";
			DialogResult RESP = (DialogResult) 0;
			if (modAdminCommon.Exist($"SELECT * FROM Company WHERE comp_State = '{txt_state_code.Text}'"))
			{
				M = $"State '{txt_state_code.Text}',  currently used in the Company Table.";
				MessageBox.Show(M, "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else if (modAdminCommon.Exist($"SELECT * FROM State WHERE State_code = '{txt_state_code.Text}'"))
			{ 
				Query = "DELETE FROM State";
				Query = $"{Query} WHERE State_code = '{modAdminCommon.Fix_Quote(txt_state_code)}'";
				M = $"State Delete For: {txt_state_code.Text.Trim()}{"\r"}{"\r"}";
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
					FG_State.RemoveItem(FG_State.CurrentRowIndex);
					FG_State.Refresh();
					Is_Dirty = true;
					MessageBox.Show("Delete Successfully Completed.", "DELETE COMPLETED", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					MessageBox.Show("Delete Canceled.", "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			else
			{
				M = $"State   '{txt_state_code.Text}',   not currently in the State Table.";
				MessageBox.Show(M, "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}

			pnl_State_AddUpdate.Visible = false;

		}

		private void cmd_Delete_TZ_Click(Object eventSender, EventArgs eventArgs)
		{
			//aey 4/19/2004   Timezone ("Delete")
			string Query = "";
			string M = "";
			DialogResult RESP = (DialogResult) 0;

			//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			// Delete 'Timezone' Table row
			//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			if (modAdminCommon.Exist($"SELECT * FROM Company WHERE comp_timezone = '{txt_tzone_name.Text}'"))
			{
				M = $"Timezone '{txt_tzone_name.Text}',  currently used in the Company Table.";
				MessageBox.Show(M, "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else if (modAdminCommon.Exist($"SELECT * FROM Timezone WHERE tzone_name = '{txt_tzone_name.Text}'"))
			{ 
				Query = $"DELETE FROM Timezone WHERE tzone_name = '{modAdminCommon.Fix_Quote(txt_tzone_name)}'";
				M = $"Timezone Delete For: {txt_tzone_name.Text.Trim()}{"\r"}{"\r"}";
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
					Is_Dirty = true;
					FG_TimeZone.RemoveItem(FG_TimeZone.CurrentRowIndex);
					FG_TimeZone.Refresh();

					MessageBox.Show("Delete Successfully Completed.", "DELETE COMPLETED", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					MessageBox.Show("Delete Canceled.", "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			else
			{
				M = $"Timezone   '{txt_tzone_name.Text}',   not currently in the tzone Table.";
				MessageBox.Show(M, "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			pnl_TZ_AddUpdate.Visible = false;


		}

		private void cmd_FindProgram_Click(Object eventSender, EventArgs eventArgs)
		{
			//find the program for a given company

			ADORecordSetHelper ado_Search = new ADORecordSetHelper();

			int Prog_id = 0;
			string Query = $"SELECT  pgref_prog_id From Program_Reference Where (pgref_comp_id = {txt_find_Comp_id.Text}) ";

			ado_Search.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

			if (!(ado_Search.BOF && ado_Search.EOF))
			{
				ado_Search.MoveFirst();

				Prog_id = Convert.ToInt32(Conversion.Val($"{Convert.ToString(ado_Search["pgref_prog_id"])}"));
				ado_Search.Close();
			}

			ado_Search = null;

			if (Prog_id > 0)
			{
				int tempForEndVar = cmdFracProgram.Items.Count - 1;
				for (int K = 1; K <= tempForEndVar; K++)
				{
					if (cmdFracProgram.GetItemData(K) == Prog_id)
					{
						cmdFracProgram.SelectedIndex = K;
						break;
					}
				}
			}
			else
			{
				MessageBox.Show("This company is not part of any Fractional Program", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}

		private void cmd_Save_CAT_Click(Object eventSender, EventArgs eventArgs)
		{

			string Query = "";

			switch(RecordStat)
			{
				case "Add" : 
					Query = "INSERT INTO Company_Account_Type (cacctype_code, cacctype_name) VALUES ("; 
					Query = $"{Query}'{txt_cacctype_code.Text.Trim()}','{modAdminCommon.Fix_Quote(txt_cacctype_Name).Trim()}')"; 
					DbCommand TempCommand = null; 
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand(); 
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand); 
					TempCommand.CommandText = Query; 
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand); 
					TempCommand.ExecuteNonQuery(); 
					Is_Dirty = true; 
					FG_Cat_List.RowsCount++; 
					FG_Cat_List.CurrentRowIndex = FG_Cat_List.RowsCount - 1; 
					 
					FG_Cat_List.CurrentColumnIndex = 0; 
					FG_Cat_List[FG_Cat_List.CurrentRowIndex, FG_Cat_List.CurrentColumnIndex].Value = ($"{txt_cacctype_code.Text}").Trim(); 
					FG_Cat_List.CurrentColumnIndex = 1; 
					FG_Cat_List[FG_Cat_List.CurrentRowIndex, FG_Cat_List.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_cacctype_Name).Trim(); 

					 
					MessageBox.Show("Insert Successfully Completed", "INSERT COMPLETED", MessageBoxButtons.OK, MessageBoxIcon.Information); 
					 
					break;
				case "Update" : 
					Query = $"UPDATE Company_Account_Type SET cacctype_code='{modAdminCommon.Fix_Quote(txt_cacctype_code).Trim()}',"; 
					Query = $"{Query}cacctype_name='{modAdminCommon.Fix_Quote(txt_cacctype_Name).Trim()}'"; 
					Query = $"{Query} WHERE cacctype_code='{txt_cacctype_code.Text.Trim()}'"; 
					DbCommand TempCommand_2 = null; 
					TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand(); 
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2); 
					TempCommand_2.CommandText = Query; 
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2); 
					TempCommand_2.ExecuteNonQuery(); 
					Is_Dirty = true; 
					FG_Cat_List.CurrentColumnIndex = 0; 
					FG_Cat_List[FG_Cat_List.CurrentRowIndex, FG_Cat_List.CurrentColumnIndex].Value = ($"{txt_cacctype_code.Text}").Trim(); 
					FG_Cat_List.CurrentColumnIndex = 1; 
					FG_Cat_List[FG_Cat_List.CurrentRowIndex, FG_Cat_List.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_cacctype_Name).Trim(); 
					 
					MessageBox.Show("Update Successfully Completed", "UPDATE COMPLETED", MessageBoxButtons.OK, MessageBoxIcon.Information); 

					 
					break;
			}


			FG_Cat_List.Refresh();
			pnl_CAT_AddUpdate.Visible = false;
			Application.DoEvents();

		}

		private void cmd_Save_CBT_Click(Object eventSender, EventArgs eventArgs)
		{
			// insert or update table rows

			StringBuilder Query = new StringBuilder();
			string groupID = "";
			string lstItem = "";

			switch(RecordStat)
			{
				case "Add" : 
					Query = new StringBuilder("INSERT INTO Company_Business_Type (cbus_type, cbus_name, cbus_abi_flag, cbus_aircraft_flag, cbus_yacht_flag, cbus_description, cbus_keywords)"); 
					Query.Append($" VALUES ('{txt_cbus_type.Text.Trim()}','{modAdminCommon.Fix_Quote(txt_cbus_Name).Trim()}',"); 
					 
					Is_Dirty = true; 
					FG_CBTList.RowsCount++; 
					FG_CBTList.CurrentRowIndex = FG_CBTList.RowsCount - 1; 
					FG_CBTList.CurrentColumnIndex = 0; 
					FG_CBTList[FG_CBTList.CurrentRowIndex, FG_CBTList.CurrentColumnIndex].Value = txt_cbus_type.Text.Trim(); 
					FG_CBTList.CurrentColumnIndex = 1; 
					FG_CBTList[FG_CBTList.CurrentRowIndex, FG_CBTList.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_cbus_Name).Trim(); 
					FG_CBTList.CurrentColumnIndex = 2; 
					 
					if (chkBusIdxOnly.CheckState == CheckState.Checked)
					{
						Query.Append("'Y',");
						FG_CBTList[FG_CBTList.CurrentRowIndex, FG_CBTList.CurrentColumnIndex].Value = "Y";
					}
					else
					{
						Query.Append("'N',");
						FG_CBTList[FG_CBTList.CurrentRowIndex, FG_CBTList.CurrentColumnIndex].Value = "N";
					} 
					 
					FG_CBTList.CurrentColumnIndex = 3; 
					 
					if (chkACOnly.CheckState == CheckState.Checked)
					{
						Query.Append("'Y',");
						FG_CBTList[FG_CBTList.CurrentRowIndex, FG_CBTList.CurrentColumnIndex].Value = "Y";
					}
					else
					{
						Query.Append("'N',");
						FG_CBTList[FG_CBTList.CurrentRowIndex, FG_CBTList.CurrentColumnIndex].Value = "N";
					} 
					 
					FG_CBTList.CurrentColumnIndex = 4; 
					 
					if (chkYachtOnly.CheckState == CheckState.Checked)
					{
						Query.Append("'Y',");
						FG_CBTList[FG_CBTList.CurrentRowIndex, FG_CBTList.CurrentColumnIndex].Value = "Y";
					}
					else
					{
						Query.Append("'N',");
						FG_CBTList[FG_CBTList.CurrentRowIndex, FG_CBTList.CurrentColumnIndex].Value = "N";
					} 

					 
					FG_CBTList.CurrentColumnIndex = 5; 
					FG_CBTList[FG_CBTList.CurrentRowIndex, FG_CBTList.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_cbus_Desc).Trim(); 
					FG_CBTList.CurrentColumnIndex = 6; 
					FG_CBTList[FG_CBTList.CurrentRowIndex, FG_CBTList.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_cbus_keywords).Trim(); 

					 
					Query.Append($"'{modAdminCommon.Fix_Quote(txt_cbus_Desc).Trim()}','{modAdminCommon.Fix_Quote(txt_cbus_keywords).Trim()}')"); 
					 
					DbCommand TempCommand = null; 
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand(); 
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand); 
					TempCommand.CommandText = Query.ToString(); 
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand); 
					TempCommand.ExecuteNonQuery(); 
					 
					int tempForEndVar = lstBusType.Items.Count - 1; 
					for (int I = 0; I <= tempForEndVar; I++)
					{

						lstItem = lstBusType.GetListItem(I);

						// find the group_ID for this business_type
						int tempForEndVar2 = modAdminCommon.BusTypeArry.GetUpperBound(0);
						for (int M = 0; M <= tempForEndVar2; M++)
						{

							if (modAdminCommon.BusTypeArry[M, 0] == lstItem)
							{
								groupID = modAdminCommon.BusTypeArry[M, 1];
								break;
							}

						}

						Query = new StringBuilder("INSERT INTO Company_Business_Type_Group_Reference (cbtgr_group_id,cbtgr_business_type) VALUES (");
						Query.Append($"{groupID},'{StringsHelper.Replace(txt_cbus_type.Text, "'", "''", 1, -1, CompareMethod.Binary)}')");
						DbCommand TempCommand_2 = null;
						TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
						TempCommand_2.CommandText = Query.ToString();
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
						TempCommand_2.ExecuteNonQuery();
					} 
					 
					MessageBox.Show("Insert Successfully Completed", "INSERT COMPLETED", MessageBoxButtons.OK, MessageBoxIcon.Information); 
					 
					break;
				case "Update" : 
					Query = new StringBuilder($"UPDATE Company_Business_Type SET cbus_type = '{modAdminCommon.Fix_Quote(txt_cbus_type).Trim()}',"); 
					Query.Append($"cbus_name = '{modAdminCommon.Fix_Quote(txt_cbus_Name).Trim()}',"); 
					Query.Append($"cbus_description = '{modAdminCommon.Fix_Quote(txt_cbus_Desc).Trim()}',"); 
					Query.Append($"cbus_keywords = '{modAdminCommon.Fix_Quote(txt_cbus_keywords).Trim()}',"); 
					 
					Is_Dirty = true; 
					FG_CBTList.CurrentColumnIndex = 0; 
					FG_CBTList[FG_CBTList.CurrentRowIndex, FG_CBTList.CurrentColumnIndex].Value = txt_cbus_type.Text.Trim(); 
					FG_CBTList.CurrentColumnIndex = 1; 
					FG_CBTList[FG_CBTList.CurrentRowIndex, FG_CBTList.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_cbus_Name).Trim(); 
					FG_CBTList.CurrentColumnIndex = 2; 
					 
					if (chkBusIdxOnly.CheckState == CheckState.Checked)
					{
						Query.Append("cbus_abi_flag='Y'");
						FG_CBTList[FG_CBTList.CurrentRowIndex, FG_CBTList.CurrentColumnIndex].Value = "Y";
					}
					else
					{
						Query.Append("cbus_abi_flag='N'");
						FG_CBTList[FG_CBTList.CurrentRowIndex, FG_CBTList.CurrentColumnIndex].Value = "N";
					} 
					 
					FG_CBTList.CurrentColumnIndex = 3; 
					 
					if (chkACOnly.CheckState == CheckState.Checked)
					{
						Query.Append(", cbus_aircraft_flag='Y'");
						FG_CBTList[FG_CBTList.CurrentRowIndex, FG_CBTList.CurrentColumnIndex].Value = "Y";
					}
					else
					{
						Query.Append(", cbus_aircraft_flag='N'");
						FG_CBTList[FG_CBTList.CurrentRowIndex, FG_CBTList.CurrentColumnIndex].Value = "N";
					} 

					 
					FG_CBTList.CurrentColumnIndex = 4; 
					 
					if (chkYachtOnly.CheckState == CheckState.Checked)
					{
						Query.Append(", cbus_yacht_flag='Y'");
						FG_CBTList[FG_CBTList.CurrentRowIndex, FG_CBTList.CurrentColumnIndex].Value = "Y";
					}
					else
					{
						Query.Append(", cbus_yacht_flag='N'");
						FG_CBTList[FG_CBTList.CurrentRowIndex, FG_CBTList.CurrentColumnIndex].Value = "N";
					} 


					 
					FG_CBTList.CurrentColumnIndex = 5; 
					FG_CBTList[FG_CBTList.CurrentRowIndex, FG_CBTList.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_cbus_Desc).Trim(); 
					FG_CBTList.CurrentColumnIndex = 6; 
					FG_CBTList[FG_CBTList.CurrentRowIndex, FG_CBTList.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_cbus_keywords).Trim(); 
					 
					Query.Append($" WHERE cbus_type='{txt_cbus_type.Text.Trim()}'"); 
					 
					DbCommand TempCommand_3 = null; 
					TempCommand_3 = modAdminCommon.LOCAL_ADO_DB.CreateCommand(); 
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_3); 
					TempCommand_3.CommandText = Query.ToString(); 
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_3); 
					TempCommand_3.ExecuteNonQuery(); 
					 
					Query = new StringBuilder("DELETE FROM Company_Business_Type_Group_Reference "); 
					Query.Append($"WHERE cbtgr_business_type = '{txt_cbus_type.Text.Trim()}'"); 
					DbCommand TempCommand_4 = null; 
					TempCommand_4 = modAdminCommon.LOCAL_ADO_DB.CreateCommand(); 
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_4); 
					TempCommand_4.CommandText = Query.ToString(); 
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_4); 
					TempCommand_4.ExecuteNonQuery(); 
					 
					int tempForEndVar3 = lstBusType.Items.Count - 1; 
					for (int I = 0; I <= tempForEndVar3; I++)
					{

						lstItem = lstBusType.GetListItem(I);

						// find the group_ID for this business_type
						int tempForEndVar4 = modAdminCommon.BusTypeArry.GetUpperBound(0);
						for (int M = 0; M <= tempForEndVar4; M++)
						{

							if (modAdminCommon.BusTypeArry[M, 0] == lstItem)
							{
								groupID = modAdminCommon.BusTypeArry[M, 1];
								break;
							}

						}

						Query = new StringBuilder("INSERT INTO Company_Business_Type_Group_Reference (cbtgr_group_id,cbtgr_business_type");
						Query.Append($") VALUES ({groupID},'{StringsHelper.Replace(txt_cbus_type.Text, "'", "''", 1, -1, CompareMethod.Binary)}')");
						DbCommand TempCommand_5 = null;
						TempCommand_5 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_5);
						TempCommand_5.CommandText = Query.ToString();
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_5);
						TempCommand_5.ExecuteNonQuery();
					} 
					 
					MessageBox.Show("Update Successfully Completed", "UPDATE COMPLETED", MessageBoxButtons.OK, MessageBoxIcon.Information); 
					break;
			}

			pnl_CBT_AddUpdate.Visible = false;
			pnl_BusGroup.Visible = false;
			FG_CBTList.Refresh();

			return;

		}

		private void cmd_Save_Country_Click(Object eventSender, EventArgs eventArgs)
		{
			string Query = "";
			ADORecordSetHelper ado_Country = new ADORecordSetHelper();
			int GridRow = 0;
			string CName = "";

			try
			{

				this.Cursor = Cursors.WaitCursor;
				Label7[1].Visible = false;
				txt_regnbr_prefix.Visible = false;
				cmdRegNoUpdate.Visible = false; //aey 11/28/2005
				GridRow = Convert.ToInt32(Conversion.Val($"{txt_county_grid_row.Text}"));
				CName = txt_country_name_old.Text;

				Query = $"select * from country where country_name='{modAdminCommon.Fix_Quote(CName)}' ";
				ado_Country.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockPessimistic);

				if (Strings.Len(txt_country_name.Text.Trim()) == 0)
				{
					MessageBox.Show("Country Name must be supplied", "UPDATE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				switch(RecordStat)
				{
					case "Add" : 
						ado_Country.AddNew(); 
						FG_Country.RowsCount++; 
						FG_Country.CurrentRowIndex = FG_Country.RowsCount - 1; 
						GridRow = FG_Country.CurrentRowIndex; 
						txt_country_name_old.Text = txt_country_name.Text; 

						 
						Query = "insert into Registration_Number_Prefix (regnbrpref_country_name,regnbrpref_prefix) "; 
						Query = $"{Query} Values('{modAdminCommon.Fix_Quote(txt_country_name.Text)}','') "; 
						DbCommand TempCommand = null; 
						TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand(); 
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand); 
						TempCommand.CommandText = Query; 
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand); 
						TempCommand.ExecuteNonQuery(); 
						 
						break;
					case "Update" : 
						ado_Country.MoveFirst(); 
						 
						if (txt_country_name.Text.Trim() != txt_country_name_old.Text.Trim())
						{
							Query = $"update registration_Number_Prefix set regnbrpref_country_name ='{modAdminCommon.Fix_Quote(txt_country_name.Text)}' ";
							Query = $"{Query} where regnbrpref_country_name='{modAdminCommon.Fix_Quote(txt_country_name_old.Text)}' ";
							DbCommand TempCommand_2 = null;
							TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
							TempCommand_2.CommandText = Query;
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
							TempCommand_2.ExecuteNonQuery();


						} 
						 
						break;
				}

				FG_Country.CurrentColumnIndex = 0;
				FG_Country[FG_Country.CurrentRowIndex, FG_Country.CurrentColumnIndex].Value = txt_country_code.Text.Trim();

				FG_Country.CurrentColumnIndex = 1;
				FG_Country[FG_Country.CurrentRowIndex, FG_Country.CurrentColumnIndex].Value = txt_country_name.Text.Trim();
				FG_Country.CurrentColumnIndex = 2;
				FG_Country[FG_Country.CurrentRowIndex, FG_Country.CurrentColumnIndex].Value = txt_country_language.Text.Trim();
				FG_Country.CurrentColumnIndex = 3;
				FG_Country[FG_Country.CurrentRowIndex, FG_Country.CurrentColumnIndex].Value = txt_country_time_vs_eastern.Text.Trim();
				FG_Country.CurrentColumnIndex = 4;
				FG_Country[FG_Country.CurrentRowIndex, FG_Country.CurrentColumnIndex].Value = txt_country_currency.Text.Trim();
				FG_Country.CurrentColumnIndex = 5;
				FG_Country[FG_Country.CurrentRowIndex, FG_Country.CurrentColumnIndex].Value = txt_country_int_access_code.Text.Trim();
				FG_Country.CurrentColumnIndex = 6;
				FG_Country[FG_Country.CurrentRowIndex, FG_Country.CurrentColumnIndex].Value = ($"{txt_Abbrev.Text}").Trim();
				FG_Country.CurrentColumnIndex = 7;
				FG_Country[FG_Country.CurrentRowIndex, FG_Country.CurrentColumnIndex].Value = ($"{txt_Continent_Name.Text}").Trim();
				FG_Country.CurrentColumnIndex = 8;
				FG_Country[FG_Country.CurrentRowIndex, FG_Country.CurrentColumnIndex].Value = ($"{txt_CityCode.Text}").Trim();

				FG_Country.CurrentColumnIndex = 9;
				FG_Country[FG_Country.CurrentRowIndex, FG_Country.CurrentColumnIndex].Value = (Chk_Company_active.CheckState == CheckState.Checked) ? "Y" : "N";

				FG_Country.CurrentColumnIndex = 10;
				FG_Country[FG_Country.CurrentRowIndex, FG_Country.CurrentColumnIndex].Value = cmbDialLineAccessCode.GetItemData(cmbDialLineAccessCode.SelectedIndex).ToString();

				ado_Country["Country_code"] = ($"{txt_country_code.Text}").Trim();
				ado_Country["country_name"] = ($"{txt_country_name.Text}").Trim();
				ado_Country["Country_language"] = ($"{txt_country_language.Text}").Trim();
				ado_Country["Country_time_vs_eastern"] = Conversion.Val($"{txt_country_time_vs_eastern.Text}");
				ado_Country["Country_currency"] = ($"{txt_country_currency.Text}").Trim();
				ado_Country["Country_int_access_code"] = ($"{txt_country_int_access_code.Text}").Trim();
				ado_Country["country_abbrev"] = ($"{txt_Abbrev.Text}").Trim();
				ado_Country["country_continent_name"] = ($"{txt_Continent_Name.Text}").Trim();
				ado_Country["country_city_code"] = ($"{txt_CityCode.Text}").Trim();
				ado_Country["country_active_flag"] = (Chk_Company_active.CheckState == CheckState.Checked) ? "Y" : "N";
				ado_Country["country_line_access_code"] = Convert.ToString(FG_Country[GridRow, 10].Value);

				ado_Country.Update();
				ado_Country.Close();
				Is_Dirty = true;

				FG_Country.Refresh();
				this.Cursor = CursorHelper.CursorDefault;
				pnl_Country_AddUpdate.Visible = false;
			}
			catch
			{


				this.Cursor = CursorHelper.CursorDefault;
				modAdminCommon.Report_Error("Country_Update_Error: ");
				this.Cursor = CursorHelper.CursorDefault;
				pnl_Country_AddUpdate.Visible = false;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1065
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

		}



		private void cmd_Save_CS_Click(Object eventSender, EventArgs eventArgs)
		{
			//aey 4/19/04    Contact_Suffix ("Save")
			string Query = "";

			if (RecordStat == "Add")
			{
				Query = $"INSERT INTO Contact_Suffix (csuffix_name) VALUES ('{txt_csuffix_name.Text.Trim()}')";
				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = Query;
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();
				Is_Dirty = true;
				FG_Contact_Suffix.RowsCount++;
				FG_Contact_Suffix.CurrentRowIndex = FG_Contact_Suffix.RowsCount - 1;
				FG_Contact_Suffix.CurrentColumnIndex = 0;
				FG_Contact_Suffix[FG_Contact_Suffix.CurrentRowIndex, FG_Contact_Suffix.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_csuffix_name).Trim();
				MessageBox.Show("Insert Successfully Completed", "INSERT COMPLETED", MessageBoxButtons.OK, MessageBoxIcon.Information);

			}
			else if (RecordStat == "Update")
			{ 
				FG_Contact_Suffix.CurrentColumnIndex = 0;
				Query = $"UPDATE Contact_Suffix SET csuffix_name='{modAdminCommon.Fix_Quote($"{txt_csuffix_name.Text}").Trim()}'";
				Query = $"{Query} WHERE csuffix_name='{FG_Contact_Suffix[FG_Contact_Suffix.CurrentRowIndex, FG_Contact_Suffix.CurrentColumnIndex].FormattedValue.ToString().Trim()}'";
				DbCommand TempCommand_2 = null;
				TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
				TempCommand_2.CommandText = Query;
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
				TempCommand_2.ExecuteNonQuery();
				Is_Dirty = true;
				FG_Contact_Suffix.CurrentColumnIndex = 0;
				FG_Contact_Suffix[FG_Contact_Suffix.CurrentRowIndex, FG_Contact_Suffix.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_csuffix_name).Trim();
				MessageBox.Show("Update Successfully Completed", "UPDATE COMPLETED", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			FG_Contact_Suffix.Refresh();
			pnl_CS_AddUpdate.Visible = false;

		}

		private void cmd_Save_CSN_Click(Object eventSender, EventArgs eventArgs)
		{
			string Query = "";

			if (RecordStat == "Add")
			{
				Query = $"INSERT INTO Contact_Sirname (csir_name) VALUES ('{txt_csir_name.Text.Trim().Trim().Substring(0, Math.Min(10, txt_csir_name.Text.Trim().Trim().Length))}')";
				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = Query;
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();
				Is_Dirty = true;
				FG_Contact_SirName.RowsCount++;
				FG_Contact_SirName.CurrentRowIndex = FG_Contact_SirName.RowsCount - 1;
				FG_Contact_SirName.CurrentColumnIndex = 0;
				FG_Contact_SirName[FG_Contact_SirName.CurrentRowIndex, FG_Contact_SirName.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_csir_name).Trim();
				Is_Dirty = true;
				MessageBox.Show("Insert Successfully Completed", "INSERT COMPLETED", MessageBoxButtons.OK, MessageBoxIcon.Information);

			}
			else if (RecordStat == "Update")
			{ 
				FG_Contact_SirName.CurrentColumnIndex = 0;
				Query = "UPDATE Contact_Sirname SET ";
				Query = $"{Query}csir_name='{modAdminCommon.Fix_Quote($"{txt_csir_name.Text}").Trim()}'";
				Query = $"{Query} WHERE csir_name='{FG_Contact_SirName[FG_Contact_SirName.CurrentRowIndex, FG_Contact_SirName.CurrentColumnIndex].FormattedValue.ToString().Trim().Substring(0, Math.Min(10, FG_Contact_SirName[FG_Contact_SirName.CurrentRowIndex, FG_Contact_SirName.CurrentColumnIndex].FormattedValue.ToString().Trim().Length))}'";
				DbCommand TempCommand_2 = null;
				TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
				TempCommand_2.CommandText = Query;
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
				TempCommand_2.ExecuteNonQuery();
				Is_Dirty = true;
				FG_Contact_SirName.CurrentColumnIndex = 0;
				FG_Contact_SirName[FG_Contact_SirName.CurrentRowIndex, FG_Contact_SirName.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_csir_name).Trim();
				MessageBox.Show("Update Successfully Completed", "UPDATE COMPLETED", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			FG_Contact_SirName.Refresh();

			pnl_CSN_AddUpdate.Visible = false;


		}

		private void cmd_Save_CT_Click(Object eventSender, EventArgs eventArgs)
		{
			//aey 4/20/2004 Contact_Title ("Save")

			StringBuilder Query = new StringBuilder();

			string M = txt_ctitle_name.Text;
			if (M.IndexOf('\'') >= 0)
			{
				MessageBox.Show("Single Quote (') is not allowed in a contact title", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				return;
			}


			switch(RecordStat)
			{
				case "Add" : 
					if (Strings.Len(($"{txt_ctitle_name.Text}").Trim()) == 0)
					{
						M = "Contact Title Must Have A Name.";
						MessageBox.Show(M, "ADD CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
					else if (modAdminCommon.Exist($"SELECT * FROM Contact_Title WHERE ctitle_name = '{StringsHelper.Replace(txt_ctitle_name.Text, "'", "''", 1, -1, CompareMethod.Binary)}'"))
					{ 
						M = $"Contact Title   '{txt_ctitle_name.Text}',   currently used in the Contact_Title Table.";
						MessageBox.Show(M, "ADD CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
					else if (lstTitleGroup.Items.Count == 0)
					{ 
						M = "Contact Title Must Have A Title Group.";
						MessageBox.Show(M, "ADD CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
					else
					{
						FG_Contact_Title.RowsCount++;
						FG_Contact_Title.CurrentRowIndex = FG_Contact_Title.RowsCount - 1;
						FG_Contact_Title.CurrentColumnIndex = 0;
						FG_Contact_Title[FG_Contact_Title.CurrentRowIndex, FG_Contact_Title.CurrentColumnIndex].Value = txt_ctitle_name.Text.Trim();
						FG_Contact_Title.CurrentColumnIndex = 1;
						Query = new StringBuilder("INSERT INTO Contact_Title (ctitle_name, ctitle_active_flag) VALUES (");
						Query.Append($"'{StringsHelper.Replace(txt_ctitle_name.Text.Trim(), "'", "''", 1, -1, CompareMethod.Binary)}',");
						if (chk_ctitle_active_flag.CheckState == CheckState.Checked)
						{
							Query.Append("'Y')");
							FG_Contact_Title[FG_Contact_Title.CurrentRowIndex, FG_Contact_Title.CurrentColumnIndex].Value = "Y";
						}
						else
						{
							Query.Append("'N')");
							FG_Contact_Title[FG_Contact_Title.CurrentRowIndex, FG_Contact_Title.CurrentColumnIndex].Value = "N";
						}
						//Call LOCAL_DB.Execute(QUERY, dbSQLPassThrough)
						DbCommand TempCommand = null;
						TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
						TempCommand.CommandText = Query.ToString();
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
						TempCommand.ExecuteNonQuery();
						Is_Dirty = true;

						int tempForEndVar = lstTitleGroup.Items.Count - 1;
						for (int I = 0; I <= tempForEndVar; I++)
						{
							Query = new StringBuilder("INSERT INTO Contact_Title_Group_Reference (ctitlegref_title_name,");
							Query.Append("ctitlegref_group_name) VALUES (");
							Query.Append($"'{StringsHelper.Replace(txt_ctitle_name.Text.Trim(), "'", "''", 1, -1, CompareMethod.Binary)}',");
							Query.Append($"'{StringsHelper.Replace(lstTitleGroup.GetListItem(I), "'", "''", 1, -1, CompareMethod.Binary)}')");
							DbCommand TempCommand_2 = null;
							TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
							TempCommand_2.CommandText = Query.ToString();
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
							TempCommand_2.ExecuteNonQuery();
						}

						MessageBox.Show("Insert Successfully Completed", "INSERT COMPLETED", MessageBoxButtons.OK, MessageBoxIcon.Information);
					} 
					 
					break;
				case "Update" : 
					 
					if (Strings.Len(($"{txt_ctitle_name.Text}").Trim()) == 0)
					{
						M = "Contact Title Must Have A Name.";
						MessageBox.Show(M, "UPDATE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
					else if (lstTitleGroup.Items.Count == 0)
					{ 
						M = "Contact Title Must Have A Title Group.";
						MessageBox.Show(M, "UPDATE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
					else
					{
						FG_Contact_Title.CurrentColumnIndex = 0;
						M = FG_Contact_Title[FG_Contact_Title.CurrentRowIndex, FG_Contact_Title.CurrentColumnIndex].FormattedValue.ToString(); //save previous title for use in where
						FG_Contact_Title[FG_Contact_Title.CurrentRowIndex, FG_Contact_Title.CurrentColumnIndex].Value = txt_ctitle_name.Text.Trim();
						FG_Contact_Title.CurrentColumnIndex = 1;

						Query = new StringBuilder($"UPDATE Contact_Title SET ctitle_name='{modAdminCommon.Fix_Quote(txt_ctitle_name).Trim()}' ");
						if (chk_ctitle_active_flag.CheckState == CheckState.Checked)
						{
							Query.Append(",ctitle_active_flag = 'Y'");
							FG_Contact_Title[FG_Contact_Title.CurrentRowIndex, FG_Contact_Title.CurrentColumnIndex].Value = "Y";
						}
						else
						{
							Query.Append(",ctitle_active_flag = 'N'");
							FG_Contact_Title[FG_Contact_Title.CurrentRowIndex, FG_Contact_Title.CurrentColumnIndex].Value = "N";
						}

						Query.Append($" WHERE ctitle_name='{modAdminCommon.Fix_Quote(M).Trim()}'");

						DbCommand TempCommand_3 = null;
						TempCommand_3 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_3);
						TempCommand_3.CommandText = Query.ToString();
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_3);
						TempCommand_3.ExecuteNonQuery();

						Query = new StringBuilder("DELETE FROM Contact_Title_Group_Reference ");
						Query.Append($"WHERE ctitlegref_title_name = '{StringsHelper.Replace(txt_ctitle_name.Text.Trim(), "'", "''", 1, -1, CompareMethod.Binary)}'");
						DbCommand TempCommand_4 = null;
						TempCommand_4 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_4);
						TempCommand_4.CommandText = Query.ToString();
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_4);
						TempCommand_4.ExecuteNonQuery();
						Is_Dirty = true;

						int tempForEndVar2 = lstTitleGroup.Items.Count - 1;
						for (int I = 0; I <= tempForEndVar2; I++)
						{
							Query = new StringBuilder("INSERT INTO Contact_Title_Group_Reference (ctitlegref_title_name,");
							Query.Append("ctitlegref_group_name) VALUES (");
							Query.Append($"'{StringsHelper.Replace(txt_ctitle_name.Text.Trim(), "'", "''", 1, -1, CompareMethod.Binary)}',");
							Query.Append($"'{StringsHelper.Replace(lstTitleGroup.GetListItem(I), "'", "''", 1, -1, CompareMethod.Binary)}')");
							DbCommand TempCommand_5 = null;
							TempCommand_5 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_5);
							TempCommand_5.CommandText = Query.ToString();
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_5);
							TempCommand_5.ExecuteNonQuery();
						}

						MessageBox.Show("Update Successfully Completed", "UPDATE COMPLETED", MessageBoxButtons.OK, MessageBoxIcon.Information);
					} 
					 
					break;
			}

			pnl_CT_AddUpdate.Visible = false;
			pnl_ContactTitleGroup.Visible = false;

		}

		private void cmd_Save_Currency_Click(Object eventSender, EventArgs eventArgs)
		{
			string Query = "";

			if (RecordStat == "Add")
			{
				txt_currency_name[1].Text = StringsHelper.Replace(txt_currency_name[1].Text.Trim(), ",", "", 1, -1, CompareMethod.Binary);

				Query = "INSERT INTO currency (currency_name,currency_exchange_rate,currency_exchange_rate_date, currency_exchange_rate_source, currency_country, currency_iso) VALUES (";
				Query = $"{Query}'{txt_currency_name[0].Text.Trim()}',{StringsHelper.Replace(txt_currency_name[1].Text.Trim(), ",", "", 1, -1, CompareMethod.Binary)},'{txt_currency_name[2].Text.Trim()}','{txt_currency_name[3].Text.Trim()}','{txt_currency_name[4].Text.Trim()}','{txt_currency_name[5].Text.Trim()}')";
				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = Query;
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();
				Is_Dirty = true;
				FG_Currency.RowsCount++;
				FG_Currency.CurrentRowIndex = FG_Currency.RowsCount - 1;
				FG_Currency.CurrentColumnIndex = 0;
				FG_Currency[FG_Currency.CurrentRowIndex, FG_Currency.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_currency_name[0]).Trim();
				FG_Currency.CurrentColumnIndex = 1;
				FG_Currency[FG_Currency.CurrentRowIndex, FG_Currency.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_currency_name[1]).Trim();
				FG_Currency.CurrentColumnIndex = 2;
				FG_Currency[FG_Currency.CurrentRowIndex, FG_Currency.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_currency_name[2]).Trim();
				FG_Currency.CurrentColumnIndex = 3;
				FG_Currency[FG_Currency.CurrentRowIndex, FG_Currency.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_currency_name[3]).Trim();
				FG_Currency.CurrentColumnIndex = 4;
				FG_Currency[FG_Currency.CurrentRowIndex, FG_Currency.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_currency_name[4]).Trim();
				FG_Currency.CurrentColumnIndex = 5;
				FG_Currency[FG_Currency.CurrentRowIndex, FG_Currency.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_currency_name[5]).Trim();
				MessageBox.Show("Insert Successfully Completed", "INSERT COMPLETED", MessageBoxButtons.OK, MessageBoxIcon.Information);

			}
			else if (RecordStat == "Update")
			{ 
				FG_Currency.CurrentColumnIndex = 0;
				txt_currency_name[1].Text = StringsHelper.Replace(txt_currency_name[1].Text.Trim(), ",", "", 1, -1, CompareMethod.Binary);
				Query = $"UPDATE currency SET currency_name='{modAdminCommon.Fix_Quote($"{txt_currency_name[0].Text}").Trim()}',";
				Query = $"{Query}currency_exchange_rate={modAdminCommon.Fix_Quote($"{txt_currency_name[1].Text}").Trim()},";
				Query = $"{Query}currency_exchange_rate_date='{modAdminCommon.Fix_Quote($"{txt_currency_name[2].Text}").Trim()}',";
				Query = $"{Query}currency_exchange_rate_source='{modAdminCommon.Fix_Quote($"{txt_currency_name[3].Text}").Trim()}',";
				Query = $"{Query}currency_country='{modAdminCommon.Fix_Quote($"{txt_currency_name[4].Text}").Trim()}',";
				Query = $"{Query}currency_iso='{modAdminCommon.Fix_Quote($"{txt_currency_name[5].Text}").Trim()}'";

				Query = $"{Query} WHERE currency_name='{FG_Currency[FG_Currency.CurrentRowIndex, FG_Currency.CurrentColumnIndex].FormattedValue.ToString().Trim()}'";
				DbCommand TempCommand_2 = null;
				TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
				TempCommand_2.CommandText = Query;
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
				TempCommand_2.ExecuteNonQuery();
				Is_Dirty = true;
				FG_Currency[FG_Currency.CurrentRowIndex, FG_Currency.CurrentColumnIndex].Value = 0;
				FG_Currency.CurrentColumnIndex = 0;
				FG_Currency[FG_Currency.CurrentRowIndex, FG_Currency.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_currency_name[0]).Trim();
				FG_Currency.CurrentColumnIndex = 1;
				FG_Currency[FG_Currency.CurrentRowIndex, FG_Currency.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_currency_name[1]).Trim();
				FG_Currency.CurrentColumnIndex = 2;
				FG_Currency[FG_Currency.CurrentRowIndex, FG_Currency.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_currency_name[2]).Trim();
				FG_Currency.CurrentColumnIndex = 3;
				FG_Currency[FG_Currency.CurrentRowIndex, FG_Currency.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_currency_name[3]).Trim();
				FG_Currency.CurrentColumnIndex = 4;
				FG_Currency[FG_Currency.CurrentRowIndex, FG_Currency.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_currency_name[4]).Trim();
				FG_Currency.CurrentColumnIndex = 5;
				FG_Currency[FG_Currency.CurrentRowIndex, FG_Currency.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_currency_name[5]).Trim();
				MessageBox.Show("Update Successfully Completed", "UPDATE COMPLETED", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			pnl_Currency_Change.Visible = false;
			FG_Currency.Refresh();

		}

		private void cmd_save_frac_PG_Click(Object eventSender, EventArgs eventArgs)
		{
			string Query = "";

			if (RecordStat == "Add")
			{
				if (modAdminCommon.Exist($"SELECT * FROM aircraft_programs WHERE prog_name= '{modAdminCommon.Fix_Quote(txt_FracPG_name)}' "))
				{
					MessageBox.Show("A Fractional Program with this name already exists - insert cancelled", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					return;
				}

				Query = "INSERT INTO aircraft_programs(prog_name,prog_description,prog_code,prog_active_flag,prog_major_flag,prog_comp_id) VALUES (";
				Query = $"{Query}'{modAdminCommon.Fix_Quote(txt_FracPG_name)}','{modAdminCommon.Fix_Quote(txt_fracPG_desc)}',";
				Query = $"{Query}'{modAdminCommon.Fix_Quote(txt_fracPG_code).Substring(0, Math.Min(4, modAdminCommon.Fix_Quote(txt_fracPG_code).Length)).ToUpper()}',";
				Query = $"{Query}'{((chk_active_fracpg.CheckState == CheckState.Checked) ? "Y" : "N")}',";
				Query = $"{Query}'{((chk_major_fracPG.CheckState == CheckState.Checked) ? "Y" : "N")}', ";
				Query = $"{Query}{Conversion.Val($"{txt_FracCompID.Text}").ToString()}) ";

				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = Query;
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();
				Is_Dirty = true;
				FG_FracPrograms.RowsCount++;
				FG_FracPrograms.CurrentRowIndex = FG_FracPrograms.RowsCount - 1;
				FG_FracPrograms.CurrentColumnIndex = 1;
				FG_FracPrograms[FG_FracPrograms.CurrentRowIndex, FG_FracPrograms.CurrentColumnIndex].Value = txt_FracPG_name;
				FG_FracPrograms.CurrentColumnIndex = 2;
				FG_FracPrograms[FG_FracPrograms.CurrentRowIndex, FG_FracPrograms.CurrentColumnIndex].Value = $"{txt_fracPG_desc.Text}";
				FG_FracPrograms.CurrentColumnIndex = 3;
				FG_FracPrograms[FG_FracPrograms.CurrentRowIndex, FG_FracPrograms.CurrentColumnIndex].Value = ($"{txt_fracPG_code.Text}").Substring(0, Math.Min(4, ($"{txt_fracPG_code.Text}").Length)).ToUpper();
				FG_FracPrograms.CurrentColumnIndex = 4;
				FG_FracPrograms[FG_FracPrograms.CurrentRowIndex, FG_FracPrograms.CurrentColumnIndex].Value = (chk_active_fracpg.CheckState == CheckState.Checked) ? "Y" : "N";
				FG_FracPrograms.CurrentColumnIndex = 5;
				FG_FracPrograms[FG_FracPrograms.CurrentRowIndex, FG_FracPrograms.CurrentColumnIndex].Value = (chk_major_fracPG.CheckState == CheckState.Checked) ? "Y" : "N";
				FG_FracPrograms.CurrentColumnIndex = 6;
				FG_FracPrograms[FG_FracPrograms.CurrentRowIndex, FG_FracPrograms.CurrentColumnIndex].Value = txt_FracCompID;

				Is_Dirty = true;
				MessageBox.Show("Insert Successfully Completed", "INSERT COMPLETED", MessageBoxButtons.OK, MessageBoxIcon.Information);
				modAdminCommon.Table_Action_Log("aircraft_programs");
			}
			else if (RecordStat == "Update")
			{ 
				FG_FracPrograms.CurrentColumnIndex = 1;
				Query = $"UPDATE aircraft_programs SET prog_name = '{modAdminCommon.Fix_Quote(txt_FracPG_name)}',";
				Query = $"{Query}prog_description = '{modAdminCommon.Fix_Quote(txt_fracPG_desc)}',";
				Query = $"{Query}prog_code = '{modAdminCommon.Fix_Quote(txt_fracPG_code)}',";
				Query = $"{Query}prog_active_flag = '{((chk_active_fracpg.CheckState == CheckState.Checked) ? "Y" : "N")}',";
				Query = $"{Query}prog_major_flag = '{((chk_major_fracPG.CheckState == CheckState.Checked) ? "Y" : "N")}', ";
				Query = $"{Query}Prog_comp_id = {Conversion.Val($"{txt_FracCompID.Text}").ToString()}  WHERE prog_id = {txtFracProg_id.Text} ";
				DbCommand TempCommand_2 = null;
				TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
				TempCommand_2.CommandText = Query;
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
				TempCommand_2.ExecuteNonQuery();
				FG_FracPrograms.CurrentColumnIndex = 1;
				FG_FracPrograms[FG_FracPrograms.CurrentRowIndex, FG_FracPrograms.CurrentColumnIndex].Value = txt_FracPG_name;
				FG_FracPrograms.CurrentColumnIndex = 2;
				FG_FracPrograms[FG_FracPrograms.CurrentRowIndex, FG_FracPrograms.CurrentColumnIndex].Value = txt_fracPG_desc;
				FG_FracPrograms.CurrentColumnIndex = 3;
				FG_FracPrograms[FG_FracPrograms.CurrentRowIndex, FG_FracPrograms.CurrentColumnIndex].Value = txt_fracPG_code;
				FG_FracPrograms.CurrentColumnIndex = 4;
				FG_FracPrograms[FG_FracPrograms.CurrentRowIndex, FG_FracPrograms.CurrentColumnIndex].Value = (chk_active_fracpg.CheckState == CheckState.Checked) ? "Y" : "N";
				FG_FracPrograms.CurrentColumnIndex = 5;
				FG_FracPrograms[FG_FracPrograms.CurrentRowIndex, FG_FracPrograms.CurrentColumnIndex].Value = (chk_major_fracPG.CheckState == CheckState.Checked) ? "Y" : "N";
				FG_FracPrograms.CurrentColumnIndex = 6;
				FG_FracPrograms[FG_FracPrograms.CurrentRowIndex, FG_FracPrograms.CurrentColumnIndex].Value = txt_FracCompID;

				Is_Dirty = true;
				MessageBox.Show("Update Successfully Completed", "UPDATE COMPLETED", MessageBoxButtons.OK, MessageBoxIcon.Information);
				modAdminCommon.Table_Action_Log("aircraft_programs");
			}
			FG_FracPrograms.Refresh();

			pnl_add_frac_Program.Visible = false;


		}

		private void cmd_Save_GAT_Click(Object eventSender, EventArgs eventArgs)
		{

			string Query = "";

			try
			{

				switch(RecordStat)
				{
					case "Insert" : 
						Query = "INSERT INTO Company_Agency_Type (cagtype_code, cagtype_name) VALUES ("; 
						Query = $"{Query}'{txt_cagtype_code.Text.Trim()}','{modAdminCommon.Fix_Quote(txt_cagtype_Name).Trim()}')"; 
						DbCommand TempCommand = null; 
						TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand(); 
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand); 
						TempCommand.CommandText = Query; 
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand); 
						TempCommand.ExecuteNonQuery(); 
						Is_Dirty = true; 
						FG_CompAgency.RowsCount++; 
						FG_CompAgency.CurrentRowIndex = FG_CompAgency.RowsCount - 1; 
						FG_CompAgency.CurrentColumnIndex = 0; 
						txt_cagtype_code.Text = txt_cagtype_code.Text.Trim(); 
						FG_CompAgency.CurrentColumnIndex = 1; 
						txt_cagtype_Name.Text = modAdminCommon.Fix_Quote(txt_cagtype_Name).Trim(); 
						 
						MessageBox.Show("Insert Successfully Completed", "INSERT COMPLETED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
						 
						break;
					case "Update" : 
						Query = $"UPDATE Company_Agency_Type SET cagtype_code='{modAdminCommon.Fix_Quote(txt_cagtype_code).Trim()}',"; 
						Query = $"{Query}cagtype_name='{modAdminCommon.Fix_Quote(txt_cagtype_Name).Trim()}' WHERE cagtype_code='{txt_cagtype_code.Text.Trim()}'"; 
						DbCommand TempCommand_2 = null; 
						TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand(); 
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2); 
						TempCommand_2.CommandText = Query; 
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2); 
						TempCommand_2.ExecuteNonQuery(); 
						Is_Dirty = true; 
						FG_CompAgency.CurrentColumnIndex = 0; 
						FG_CompAgency[FG_CompAgency.CurrentRowIndex, FG_CompAgency.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_cagtype_code).Trim(); 
						FG_CompAgency.CurrentColumnIndex = 1; 
						FG_CompAgency[FG_CompAgency.CurrentRowIndex, FG_CompAgency.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_cagtype_Name).Trim(); 
						MessageBox.Show("Update Successfully Completed", "UPDATE COMLETED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
						break;
				}

				FG_CompAgency.Refresh();
			}
			catch
			{

				this.Cursor = CursorHelper.CursorDefault;
				modAdminCommon.Report_Error("Company_Agency_Type_Error(u): ");
				return;
			}
		}

		private void cmd_Save_Language_Click(Object eventSender, EventArgs eventArgs)
		{
			//aey 4/19/2004    Language ("Save")
			string Query = "";

			if (RecordStat == "Add")
			{
				//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				// Insert Language row
				// Inform the user
				//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				Query = $"INSERT INTO Language (language_name) VALUES ('{txt_language_name.Text.Trim()}')";
				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = Query;
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();
				Is_Dirty = true;
				FG_Language.RowsCount++;
				FG_Language.CurrentRowIndex = FG_Language.RowsCount - 1;
				FG_Language.CurrentColumnIndex = 0;
				FG_Language[FG_Language.CurrentRowIndex, FG_Language.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_language_name).Trim();
				MessageBox.Show("Insert Successfully Completed", "INSERT COMPLETED", MessageBoxButtons.OK, MessageBoxIcon.Information);

			}
			else if (RecordStat == "Update")
			{ 
				//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				// Update Language record  [NOTE: not used in single field table maintenance]
				//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				FG_Language.CurrentColumnIndex = 0;
				Query = $"UPDATE Language SET  Language_name='{modAdminCommon.Fix_Quote($"{txt_language_name.Text}").Trim()}'";
				Query = $"{Query} WHERE language_name='{FG_Language[FG_Language.CurrentRowIndex, FG_Language.CurrentColumnIndex].FormattedValue.ToString().Trim()}'";
				DbCommand TempCommand_2 = null;
				TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
				TempCommand_2.CommandText = Query;
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
				TempCommand_2.ExecuteNonQuery();
				Is_Dirty = true;
				FG_Language.CurrentColumnIndex = 0;
				FG_Language[FG_Language.CurrentRowIndex, FG_Language.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_language_name).Trim();
				MessageBox.Show("Update Successfully Completed", "UPDATE COMPLETED", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			pnl_Language_AddUpdate.Visible = false;
			FG_Language.Refresh();


		}

		private void cmd_Save_PT_Click(Object eventSender, EventArgs eventArgs)
		{

			string Query = "";
			int sort_num = 0;
			ADORecordSetHelper RS_Table = new ADORecordSetHelper();

			switch(RecordStat)
			{
				case "Add" : 
					Query = "SELECT MAX(ptype_seq_no) AS max_sort_num FROM Phone_type "; 
					RS_Table.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic); 
					if (!(RS_Table.BOF && RS_Table.EOF))
					{
						sort_num = Convert.ToInt32(Double.Parse(($"{Convert.ToString(RS_Table["max_sort_num"])}").Trim()) + 1);
					}
					else
					{
						sort_num = 1;
					} 
					 
					Query = "INSERT INTO Phone_Type (ptype_name,ptype_seq_no, ptype_abbrev) VALUES ("; 
					Query = $"{Query}'{txt_ptype_name.Text.Trim()}',{sort_num.ToString()} ,'{modAdminCommon.Fix_Quote(txt_ptype_abbrev).Trim()}')"; 
					DbCommand TempCommand = null; 
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand(); 
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand); 
					TempCommand.CommandText = Query; 
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand); 
					TempCommand.ExecuteNonQuery(); 
					Is_Dirty = true; 
					FG_Phone_Type.RowsCount++; 
					FG_Phone_Type.CurrentRowIndex = FG_Phone_Type.RowsCount - 1; 
					FG_Phone_Type.CurrentColumnIndex = 0; 
					FG_Phone_Type[FG_Phone_Type.CurrentRowIndex, FG_Phone_Type.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote($"{txt_ptype_name.Text}").Trim(); 
					FG_Phone_Type.CurrentColumnIndex = 1; 
					FG_Phone_Type[FG_Phone_Type.CurrentRowIndex, FG_Phone_Type.CurrentColumnIndex].Value = sort_num; 
					FG_Phone_Type.CurrentColumnIndex = 2; 
					FG_Phone_Type[FG_Phone_Type.CurrentRowIndex, FG_Phone_Type.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote($"{txt_ptype_abbrev.Text}").Trim(); 
					MessageBox.Show("Insert Successfully Completed", "INSERT COMPLETED", MessageBoxButtons.OK, MessageBoxIcon.Information); 
					Is_Dirty = true; 
					break;
				case "Update" : 
					if (Strings.Len(modAdminCommon.Fix_Quote(txt_ptype_name).Trim()) > 0)
					{
						Query = "UPDATE Phone_Type SET ";
						Query = $"{Query}ptype_name = '{modAdminCommon.Fix_Quote(txt_ptype_name).Trim()}' ";
						if (Strings.Len($"{txt_ptype_abbrev.Text}") > 0)
						{
							Query = $"{Query}, ptype_Abbrev = '{modAdminCommon.Fix_Quote(txt_ptype_abbrev).Trim()}' ";
						}
						else
						{
							Query = $"{Query}, ptype_Abbrev = NULL";
						}
						if (txt_ptype_seq_no.Text != "")
						{
							// check that txt_ptype_seq_no.text isNumeric
							if (Information.IsNumeric(txt_ptype_seq_no.Text))
							{
								Query = $"{Query}, ptype_seq_no = {txt_ptype_seq_no.Text}";
							}
							else
							{
								MessageBox.Show("The Seq # must be a number", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
								txt_ptype_seq_no.Focus();
								return;
							}
						}
						else
						{
							MessageBox.Show("The Seq # cannot be blank", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
							txt_ptype_seq_no.Focus();
							return;
						}
						Query = $"{Query} WHERE ptype_name='{modAdminCommon.Fix_Quote(txt_ptype_name).Trim()}'";
						DbCommand TempCommand_2 = null;
						TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
						TempCommand_2.CommandText = Query;
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
						TempCommand_2.ExecuteNonQuery();
						Is_Dirty = true;
						FG_Phone_Type.CurrentColumnIndex = 0;
						FG_Phone_Type[FG_Phone_Type.CurrentRowIndex, FG_Phone_Type.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote($"{txt_ptype_name.Text}").Trim();
						FG_Phone_Type.CurrentColumnIndex = 1;
						FG_Phone_Type[FG_Phone_Type.CurrentRowIndex, FG_Phone_Type.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote($"{txt_ptype_seq_no.Text}").Trim();
						FG_Phone_Type.CurrentColumnIndex = 2;
						FG_Phone_Type[FG_Phone_Type.CurrentRowIndex, FG_Phone_Type.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_ptype_abbrev).Trim();
						MessageBox.Show("Update Successfully Completed", "UPDATE COMPLETED", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else
					{
						MessageBox.Show("Phone Type is required", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					} 
					break;
			}


			pnl_PT_AddUpdate.Visible = false;

		}

		private void cmd_Save_State_Click(Object eventSender, EventArgs eventArgs)
		{

			string Query = "";
			string FLDS = "";
			string VALS = "";

			switch(RecordStat)
			{
				case "Add" : 
					if (Strings.Len(txt_state_code.Text.Trim()) > 0)
					{
						FG_State.RowsCount++;
						FG_State.CurrentRowIndex = FG_State.RowsCount - 1;

						FLDS = "INSERT INTO State (";
						VALS = ") VALUES (";
						FLDS = $"{FLDS}State_code";
						VALS = $"{VALS}'{modAdminCommon.Fix_Quote(txt_state_code.Text).Trim()}'";
						FG_State.CurrentColumnIndex = 0;
						FG_State[FG_State.CurrentRowIndex, FG_State.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_state_code).Trim();
						FG_State.CurrentColumnIndex = 1;
						if (Strings.Len(txt_state_name.Text.Trim()) > 0)
						{
							FLDS = $"{FLDS}, State_name";
							VALS = $"{VALS}, '{modAdminCommon.Fix_Quote(txt_state_name.Text).Trim()}'";
							FG_State[FG_State.CurrentRowIndex, FG_State.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_state_name).Trim();
						}
						FG_State.CurrentColumnIndex = 2;
						if (Strings.Len(txt_state_loc.Text.Trim()) > 0)
						{
							FLDS = $"{FLDS}, State_loc";
							VALS = $"{VALS}, '{modAdminCommon.Fix_Quote(txt_state_loc).Trim()}'";
							FG_State[FG_State.CurrentRowIndex, FG_State.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_state_loc).Trim();
						}
						FG_State.CurrentColumnIndex = 3;
						if (Strings.Len(CMB_State_TimeZone.GetListItem(CMB_State_TimeZone.SelectedIndex).Trim()) > 0)
						{
							FLDS = $"{FLDS}, State_timezone ";
							VALS = $"{VALS}, '{CMB_State_TimeZone.GetListItem(CMB_State_TimeZone.SelectedIndex).Trim()}'";
							FG_State[FG_State.CurrentRowIndex, FG_State.CurrentColumnIndex].Value = CMB_State_TimeZone.GetListItem(CMB_State_TimeZone.SelectedIndex).Trim();
						}
						FG_State.CurrentColumnIndex = 4;
						if (Strings.Len(cmb_state_country.GetListItem(cmb_state_country.SelectedIndex).Trim()) > 0)
						{
							FLDS = $"{FLDS}, state_country ";
							VALS = $"{VALS}, '{cmb_state_country.GetListItem(cmb_state_country.SelectedIndex).Trim()}'";
							FG_State[FG_State.CurrentRowIndex, FG_State.CurrentColumnIndex].Value = cmb_state_country.GetListItem(cmb_state_country.SelectedIndex).Trim();
						}
						FG_State.CurrentColumnIndex = 5; //6/28/04 aey
						FLDS = $"{FLDS}, state_active_flag ";
						VALS = $"{VALS}, '{((state_active_flag.CheckState == CheckState.Checked) ? "Y" : "N")}'";
						Query = $"{FLDS}{VALS})";
						FG_State[FG_State.CurrentRowIndex, FG_State.CurrentColumnIndex].Value = (state_active_flag.CheckState == CheckState.Checked) ? "Yes" : "No";

						DbCommand TempCommand = null;
						TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
						TempCommand.CommandText = Query;
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
						TempCommand.ExecuteNonQuery();
						Is_Dirty = true;
						MessageBox.Show("Insert Successfully Completed", "INSERT COMPLETE", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else
					{
						MessageBox.Show("State Name must be supplied", "INSERT CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Error);
					} 
					 
					break;
				case "Update" : 
					if (Strings.Len(txt_state_code.Text.Trim()) > 0)
					{
						Query = $"UPDATE State SET State_code = '{modAdminCommon.Fix_Quote(txt_state_code.Text).Trim()}'";
						FG_State.CurrentColumnIndex = 0;
						FG_State[FG_State.CurrentRowIndex, FG_State.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_state_code.Text).Trim();
						FG_State.CurrentColumnIndex = 1;
						FG_State[FG_State.CurrentRowIndex, FG_State.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_state_name).Trim();
						if (Strings.Len(txt_state_name.Text.Trim()) > 0)
						{
							Query = $"{Query}, State_name = '{modAdminCommon.Fix_Quote(txt_state_name.Text).Trim()}'";
						}
						else
						{
							Query = $"{Query}, State_name = NULL";
						}
						FG_State.CurrentColumnIndex = 2;
						FG_State[FG_State.CurrentRowIndex, FG_State.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_state_loc).Trim();
						if (Strings.Len(txt_state_loc.Text.Trim()) > 0)
						{
							Query = $"{Query}, State_loc = '{modAdminCommon.Fix_Quote(txt_state_loc).Trim()}'";
						}
						else
						{
							Query = $"{Query}, State_loc = NULL";
						}
						FG_State.CurrentColumnIndex = 3;
						FG_State[FG_State.CurrentRowIndex, FG_State.CurrentColumnIndex].Value = CMB_State_TimeZone.GetListItem(CMB_State_TimeZone.SelectedIndex).Trim();
						if (Strings.Len(CMB_State_TimeZone.GetListItem(CMB_State_TimeZone.SelectedIndex).Trim()) > 0)
						{
							Query = $"{Query}, State_timezone = '{CMB_State_TimeZone.GetListItem(CMB_State_TimeZone.SelectedIndex).Trim()}'";
						}
						else
						{
							Query = $"{Query}, State_timezone = NULL";
						}
						FG_State.CurrentColumnIndex = 4;
						FG_State[FG_State.CurrentRowIndex, FG_State.CurrentColumnIndex].Value = cmb_state_country.GetListItem(cmb_state_country.SelectedIndex).Trim();
						if (Strings.Len(cmb_state_country.GetListItem(cmb_state_country.SelectedIndex).Trim()) > 0)
						{
							Query = $"{Query}, state_country = '{cmb_state_country.GetListItem(cmb_state_country.SelectedIndex).Trim()}'";
						}
						else
						{
							Query = $"{Query}, state_country = NULL";
						}

						FG_State.CurrentColumnIndex = 5; //6/28/04 aey
						FG_State[FG_State.CurrentRowIndex, FG_State.CurrentColumnIndex].Value = (state_active_flag.CheckState == CheckState.Checked) ? "Yes" : "No";
						Query = $"{Query}, state_active_flag = '{((state_active_flag.CheckState == CheckState.Checked) ? "Y" : "N")}'";

						Query = $"{Query} WHERE State_code = '{txt_state_code.Text.Trim()}'";

						// added MSW - 4/19/23
						if (cmb_state_country.Text.Trim() != "")
						{
							Query = $"{Query} and State_country = '{cmb_state_country.Text.Trim()}'";
						}

						DbCommand TempCommand_2 = null;
						TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
						TempCommand_2.CommandText = Query;
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
						TempCommand_2.ExecuteNonQuery();
						Is_Dirty = true;
						MessageBox.Show("Update Successfully Completed.", "UPDATE COMPLETE", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else
					{
						MessageBox.Show("State Code must be supplied", "UPDATE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Error);
					} 
					break;
			}

			FG_State.Refresh();
			pnl_State_AddUpdate.Visible = false;

		}

		private void cmd_Save_TZ_Click(Object eventSender, EventArgs eventArgs)
		{
			ADORecordSetHelper RS_Table = new ADORecordSetHelper();
			string Query = "";
			int sort_num = 0;
			string FLDS = "";
			string VALS = "";

			switch(RecordStat)
			{
				case "Add" : 
					if (Strings.Len(txt_tzone_name.Text.Trim()) > 0)
					{

						Query = "SELECT MAX(tzone_sort_num) AS tzone_max_sort_num FROM Timezone ";
						RS_Table.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);
						if (!(RS_Table.BOF && RS_Table.EOF))
						{
							sort_num = Convert.ToInt32(Double.Parse(($"{Convert.ToString(RS_Table["tzone_max_sort_num"])}").Trim()) + 1);
						}
						else
						{
							sort_num = 1;
						}
						RS_Table.Close();
						txt_tzone_sort_num.Text = sort_num.ToString();
						FG_TimeZone.RowsCount++;
						FG_TimeZone.CurrentRowIndex = FG_TimeZone.RowsCount - 1;

						FLDS = "INSERT INTO Timezone (";
						VALS = ") VALUES (";
						FLDS = $"{FLDS}tzone_name";
						VALS = $"{VALS}'{modAdminCommon.Fix_Quote(txt_tzone_name).Trim()}'";
						FG_TimeZone.CurrentColumnIndex = 0;
						FG_TimeZone[FG_TimeZone.CurrentRowIndex, FG_TimeZone.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_tzone_name).Trim();
						FG_TimeZone.CurrentColumnIndex = 1;
						if (Strings.Len(txt_tzone_sort_num.Text.Trim()) > 0)
						{
							FLDS = $"{FLDS}, tzone_sort_num";
							VALS = $"{VALS}, {txt_tzone_sort_num.Text.Trim()}";
							FG_TimeZone[FG_TimeZone.CurrentRowIndex, FG_TimeZone.CurrentColumnIndex].Value = txt_tzone_sort_num.Text.Trim();
						}
						FG_TimeZone.CurrentColumnIndex = 2;
						if (Strings.Len(txt_tzone_time_vs_eastern.Text.Trim()) > 0)
						{
							FLDS = $"{FLDS}, tzone_time_vs_eastern";
							VALS = $"{VALS}, {txt_tzone_time_vs_eastern.Text.Trim()}";
							FG_TimeZone[FG_TimeZone.CurrentRowIndex, FG_TimeZone.CurrentColumnIndex].Value = txt_tzone_time_vs_eastern.Text.Trim();
						}
						Query = $"{FLDS}{VALS})";
						DbCommand TempCommand = null;
						TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
						TempCommand.CommandText = Query;
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
						TempCommand.ExecuteNonQuery();
						Is_Dirty = true;
						MessageBox.Show("Insert Successfully Completed", "INSERT COMPLETE", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else
					{
						MessageBox.Show("Timezone Name must be supplied", "INSERT CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Error);
					} 
					 
					break;
				case "Update" : 
					if (Strings.Len(txt_tzone_name.Text.Trim()) > 0)
					{
						Query = "UPDATE Timezone SET ";
						Query = $"{Query}tzone_name = '{modAdminCommon.Fix_Quote(txt_tzone_name).Trim()}'";
						if (Strings.Len(txt_tzone_sort_num.Text.Trim()) > 0)
						{
							Query = $"{Query}, tzone_sort_num = '{modAdminCommon.Fix_Quote(txt_tzone_sort_num).Trim()}'";
						}
						else
						{
							Query = $"{Query}, tzone_sort_num = NULL";
						}
						if (Strings.Len(txt_tzone_time_vs_eastern.Text.Trim()) > 0)
						{
							Query = $"{Query}, tzone_time_vs_eastern = '{modAdminCommon.Fix_Quote(txt_tzone_time_vs_eastern).Trim()}'";
						}
						else
						{
							Query = $"{Query}, tzone_time_vs_eastern = NULL";
						}
						Query = $"{Query} WHERE tzone_name = '{txt_tzone_name.Text.Trim()}'";
						DbCommand TempCommand_2 = null;
						TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
						TempCommand_2.CommandText = Query;
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
						TempCommand_2.ExecuteNonQuery();
						FG_TimeZone.CurrentColumnIndex = 0;
						FG_TimeZone[FG_TimeZone.CurrentRowIndex, FG_TimeZone.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_tzone_name).Trim();
						FG_TimeZone.CurrentColumnIndex = 1;
						FG_TimeZone[FG_TimeZone.CurrentRowIndex, FG_TimeZone.CurrentColumnIndex].Value = txt_tzone_sort_num.Text.Trim();
						FG_TimeZone.CurrentColumnIndex = 2;
						FG_TimeZone[FG_TimeZone.CurrentRowIndex, FG_TimeZone.CurrentColumnIndex].Value = txt_tzone_time_vs_eastern.Text.Trim();
						Is_Dirty = true;
						MessageBox.Show("Update Successfully Completed.", "UPDATE COMPLETE", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else
					{
						MessageBox.Show("Timezone Name must be supplied", "UPDATE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Error);
					} 
					break;
			}

			FG_TimeZone.Refresh();
			pnl_TZ_AddUpdate.Visible = false;

		}

		//UPGRADE_NOTE: (7001) The following declaration (cmd_Search_Titles_Click) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void cmd_Search_Titles_Click()
		//{
			//
			//
		//}

		private void cmdAdd_CompRef_Click(Object eventSender, EventArgs eventArgs)
		{
			DialogResult confirm = (DialogResult) 0;
			try
			{
				//cboAdd_Comp_Ref
				string aCompName = "";
				string aPrimaryID = "";
				string acboSelPrimaryID = "";
				string Query = "";
				ADORecordSetHelper RS_Table = null;
				StringBuilder IN_Clause = new StringBuilder();
				int aCounter = 0;
				string aSelection = "";
				if (txtViewOther[2].Text == "")
				{
					MessageBox.Show("Please enter a ID for the company reference you would like to add", "Empty ID Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					txtViewOther[2].Focus();
				}
				else if (!Information.IsNumeric(txtViewOther[2].Text))
				{ 
					// check for a number
					MessageBox.Show("Please enter a number for the company reference you would like to add", "Input Not Numeric", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					txtViewOther[2].Focus();
				}
				else if (cboAdd_Comp_Ref.Text == "")
				{ 
					MessageBox.Show("Please select a company name for the company reference you would like to add", "No Company Selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					cboAdd_Comp_Ref.Focus();
				}
				else
				{
					// check to see the ID is valid?
					// create a string to hold the name
					// create an string to hold the ID from the combobox selection
					// set the variables
					aCompName = cboAdd_Comp_Ref.Text;
					aPrimaryID = txtViewOther[2].Text.Trim();
					acboSelPrimaryID = cboAdd_Comp_Ref.GetItemData(cboAdd_Comp_Ref.SelectedIndex).ToString();
					Query = $"Select comp_id, comp_journ_id From company Where comp_id={aPrimaryID} and comp_journ_id=0";
					// set the record set to the query to execute
					RS_Table = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");
					// check to see if we got something if we didn't we exit the sub
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (RS_Table.EOF || RS_Table.BOF)
					{
						MessageBox.Show("The Primary ID that you entered is not a valid company ID", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						txtViewOther[2].Focus();
						txtViewOther[2].Text = "";
						return;
					}
					else if (Convert.IsDBNull(RS_Table.Fields))
					{ 
						MessageBox.Show("The Primary ID that you entered is not a valid company ID", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						txtViewOther[2].Focus();
						txtViewOther[2].Text = "";
						return;
					}
					else
					{
						Query = "SELECT ficr_main_comp_id From Financial_Institution_Company_Reference ";
						Query = $"{Query}where ficr_main_comp_id='{aPrimaryID}' ";
						if (modAdminCommon.Exist(Query))
						{
							MessageBox.Show($"The SecondaryID that you have entered {aPrimaryID} is also a Primary ID.{Environment.NewLine}{Environment.NewLine}This Add cannot complete.", "ID Conflict", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							txtViewOther[2].Text = "";
							return;
						}
						Query = "SELECT ficr_sub_comp_id From Financial_Institution_Company_Reference ";
						Query = $"{Query}where ficr_sub_comp_id='{aPrimaryID}' ";
						if (modAdminCommon.Exist(Query))
						{
							MessageBox.Show($"The SecondaryID that you have entered {aPrimaryID} is also a Primary ID.{Environment.NewLine}{Environment.NewLine}This Add cannot complete.", "ID Conflict", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							txtViewOther[2].Text = "";
							return;
						}
					}
					confirm = MessageBox.Show($"Are you sure you want add this information: {Environment.NewLine}Name - {aCompName}{Environment.NewLine}PrimaryID - {acboSelPrimaryID}" +
					          $"{Environment.NewLine}SecondaryID - {aPrimaryID}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					if (confirm == System.Windows.Forms.DialogResult.Yes)
					{
						Query = "Insert into Financial_Institution_Company_Reference(ficr_main_comp_id, ficr_sub_comp_id, ficr_active_flag) ";
						Query = $"{Query}Values({acboSelPrimaryID},{aPrimaryID},'Y')";
						// execute the query into the second table
						DbCommand TempCommand = null;
						TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
						TempCommand.CommandText = Query;
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
						TempCommand.ExecuteNonQuery();
						Query = "Select ficr_main_comp_id, ficr_sub_comp_id ";
						Query = $"{Query}From Financial_Institution_Company_Reference ";
						Query = $"{Query}Where ficr_main_comp_id={acboSelPrimaryID}";
						// Execute the query
						RS_Table = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");
						// check to see that we got something
						if (!(RS_Table.EOF && RS_Table.BOF))
						{
							aCounter = 0;
							RS_Table.MoveFirst();

							while(!RS_Table.EOF)
							{
								if (aCounter == 0)
								{
									IN_Clause = new StringBuilder(Convert.ToString(RS_Table["ficr_sub_comp_id"]));
								}
								else
								{
									IN_Clause.Append($",{Convert.ToString(RS_Table["ficr_sub_comp_id"])}");
								}
								RS_Table.MoveNext();
								aCounter++;
							};
							RS_Table.Close();
						}
						else
						{
							// Error and exit
							MessageBox.Show("Unable to update info Error", "Error While Updating", MessageBoxButtons.OK, MessageBoxIcon.Error);
							// Delete the info you just added???
							return;
						}
						// update the Financial_Institution_Primary_Group table specifically the fipg_comp_id_in_clause
						Query = $"Update Financial_Institution_Primary_Group Set fipg_comp_id_in_clause='{IN_Clause.ToString()}' ";
						Query = $"{Query}Where fipg_main_comp_id={acboSelPrimaryID}";
						//MsgBox ("Update Info:" & vbCrLf & Query)
						// execute the query for the update
						DbCommand TempCommand_2 = null;
						TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
						TempCommand_2.CommandText = Query;
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
						TempCommand_2.ExecuteNonQuery();
						modAdminCommon.Table_Action_Log("Financial_Institution_Company_Reference");
						modAdminCommon.Table_Action_Log("Financial_Institution_Primary_Group");
						bolTAL = true;
						aSelection = cboEFIG_SelectGroup[0].GetItemData(cboEFIG_SelectGroup[0].SelectedIndex).ToString();
						// refresh the datagrid
						Get_Financial_Group_Companies(Convert.ToInt32(Double.Parse(aSelection)));
						SSTabHelper.SetSelectedIndex(tab_Lists, 0);
						txtViewOther[2].Text = "";
					} // if confirm = 6
				} // for the whold thing checking for blanks, numeric, etc



				pnl_AddFinGroup.Visible = false;
			}
			catch
			{
				modAdminCommon.Report_Error("Financial Groups: cmdAdd_CompRef_Click()");
				return;
			}

		}

		private void cmdAdd_FG_Click(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				string aCompName = "";
				string aPrimaryID = "";
				string Query = "";
				ADORecordSetHelper RS_Table = null;
				int MoveCbo = 0;
				if (txtFIG_Name.Text == "")
				{
					MessageBox.Show("Please enter a Name to Add", "Empty Name Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					txtFIG_Name.Focus();
				}
				else if (txtFG_PID.Text == "")
				{ 
					MessageBox.Show("Please enter a Primary ID", "Empty ID Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					txtFG_PID.Focus();
				}
				else
				{
					// create a string to hold the name
					// create a string to hold the ID
					//   note the textbox as a IsNumeric check on it, we don't need to do that here
					// set the variables
					aCompName = txtFIG_Name.Text.Trim();
					aPrimaryID = txtFG_PID.Text.Trim();
					if (!bolPanelJump)
					{
						Query = "Select comp_id, comp_journ_id ";
						Query = $"{Query}From company ";
						Query = $"{Query}Where comp_id={aPrimaryID} and comp_journ_id=0";
						// set the record set to the query to execute
						RS_Table = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");
						// check to see if we got something if we didn't we exit the sub
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (RS_Table.EOF || RS_Table.BOF)
						{
							MessageBox.Show("The Primary ID that you entered is not a valid company ID", "Invalid Company ID", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							txtFG_PID.Focus();
							return;
						}
						else if (Convert.IsDBNull(RS_Table.Fields))
						{ 
							MessageBox.Show("The Primary ID that you entered is not a valid company ID", "Invalid Company ID", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							txtFG_PID.Focus();
							return;
						}
						// check to see if the name and number are already in the database
						Query = "Select fipg_generic_name, fipg_main_comp_id from Financial_Institution_Primary_Group ";
						Query = $"{Query}where fipg_main_comp_id={aPrimaryID}";
						// set the record set to the query to execute
						RS_Table = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");
						// check to see if we got something if we didn't we exit the sub
						if (!RS_Table.BOF || !RS_Table.EOF)
						{
							MessageBox.Show("The company name and ID you are trying to add is already in the database", "Existing ID", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							txtFG_PID.Focus();
							return;
						}
						// build the string
						Query = "Insert into Financial_Institution_Primary_Group(fipg_generic_name, fipg_main_comp_id, fipg_main_journ_id, fipg_comp_id_in_clause, fipg_active_flag) ";
						Query = $"{Query}Values('{aCompName}',{aPrimaryID},0,'{aPrimaryID}','Y')";
						// execute the query into the first table
						DbCommand TempCommand = null;
						TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
						TempCommand.CommandText = Query;
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
						TempCommand.ExecuteNonQuery();
						// rebuild the string to insert into the second table
						Query = "Insert into Financial_Institution_Company_Reference(ficr_main_comp_id, ficr_sub_comp_id, ficr_active_flag) ";
						Query = $"{Query}Values({aPrimaryID},{aPrimaryID},'Y')";
						// execute the query into the second table
						DbCommand TempCommand_2 = null;
						TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
						TempCommand_2.CommandText = Query;
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
						TempCommand_2.ExecuteNonQuery();
						MessageBox.Show("Add Successful", "Association Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
						bolTAL = true;
						cboEFIG_SelectGroup[0].Items.Clear();
						cboAdd_Comp_Ref.Items.Clear();
						// repopulate the combobox
						LoadcboEFIG();
						MoveCbo = 0;
						if (cboEFIG_SelectGroup[0].Text != "All")
						{

							while(cboAdd_Comp_Ref.Text != aCompName)
							{
								cboAdd_Comp_Ref.SelectedIndex = MoveCbo;
								cboEFIG_SelectGroup[0].SelectedIndex = MoveCbo;
								MoveCbo++;
							};
						}
						// refresh the datagrid based on what the user just added
						Fill_FG_EFIG_MC(false, aPrimaryID);
						pnlEFIG_Add_Group.Visible = false;
						pnl_EFIG.Visible = true;
						txtViewOther[0].Text = "";
					}
					else
					{
						Query = $"Select comp_id, comp_journ_id  From company Where comp_id={aPrimaryID} and comp_journ_id=0";
						// set the record set to the query to execute
						RS_Table = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");
						// check to see if we got something if we didn't we exit the sub
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (RS_Table.EOF || RS_Table.BOF)
						{
							MessageBox.Show("The Primary ID that you entered is not a valid company ID", "Invalid Company ID", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							txtFG_PID.Focus();
							return;
						}
						else if (Convert.IsDBNull(RS_Table.Fields))
						{ 
							MessageBox.Show("The Primary ID that you entered is not a valid company ID", "Invalid Company ID", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							txtFG_PID.Focus();
							return;
						}
						Query = "Select fipg_generic_name, fipg_main_comp_id from Financial_Institution_Primary_Group ";
						Query = $"{Query}where fipg_main_comp_id={aPrimaryID}";
						// set the record set to the query to execute
						RS_Table = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");
						if (!RS_Table.BOF || !RS_Table.EOF)
						{
							MessageBox.Show("The company name and ID you are trying to add is already in the database", "Existing ID", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							txtFG_PID.Focus();
							return;
						}
						// build the string
						Query = "Insert into Financial_Institution_Primary_Group(fipg_generic_name, fipg_main_comp_id, fipg_main_journ_id, fipg_comp_id_in_clause, fipg_active_flag) ";
						Query = $"{Query}Values('{aCompName}',{aPrimaryID},0,'{aPrimaryID}','Y')";
						// execute the query into the first table
						DbCommand TempCommand_3 = null;
						TempCommand_3 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_3);
						TempCommand_3.CommandText = Query;
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_3);
						TempCommand_3.ExecuteNonQuery();
						// rebuild the string to insert into the second table
						Query = "Insert into Financial_Institution_Company_Reference(ficr_main_comp_id, ficr_sub_comp_id, ficr_active_flag) ";
						Query = $"{Query}Values({aPrimaryID},{aPrimaryID},'Y')";
						// execute the query into the second table
						DbCommand TempCommand_4 = null;
						TempCommand_4 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_4);
						TempCommand_4.CommandText = Query;
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_4);
						TempCommand_4.ExecuteNonQuery();
						MessageBox.Show("Add Successful", "Association Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
						bolTAL = true;
						// call the LoadNIOL to populate the datagrid, pass it what the user typed in the textbox
						LoadNIOL(true, txtViewOther[1].Text);
						// repopulate the dataggrid
						cboNIOL_Associate.Items.Clear();
						cboEFIG_SelectGroup[0].Items.Clear();
						cboAdd_Comp_Ref.Items.Clear();
						// repopulate the combobox
						Query = "select fipg_generic_name, fipg_main_comp_id from Financial_Institution_Primary_Group ";
						Query = $"{Query}order by fipg_generic_name, fipg_main_comp_id";

						//Call RS_Table.Open(Query, LOCAL_ADO_DB, adOpenForwardOnly, adLockOptimistic, adCmdText)
						RS_Table = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

						//If Not IsNull(RS_Table) And (RS_Table.EOF And RS_Table.BOF) Then
						if (!(RS_Table.EOF && RS_Table.BOF))
						{
							RS_Table.MoveFirst();

							while(!RS_Table.EOF)
							{
								cboNIOL_Associate.AddItem(Convert.ToString(RS_Table["fipg_generic_name"]));
								cboNIOL_Associate.SetItemData(cboNIOL_Associate.GetNewIndex(), Convert.ToInt32(RS_Table["fipg_main_comp_id"]));
								RS_Table.MoveNext();
							};
							RS_Table.Close();
							// cboNIOL_Associate.ListIndex = 0
						} // If Not (RS_Table.EOF And RS_Table.BOF) Then
						pnlEFIG_Add_Group.Visible = false;
						pnlEFIG_NIOL.Visible = true;
						if (lblNIOL_CompanyData[7].Text == "0")
						{
							lblNIOL_CompanyData[25].Text = "Please Enter A New Company To Search";
							cmd_Add_Parent_pnlEFIG_NIOL.Visible = false;
							txtViewOther[1].Focus();
							txtViewOther[1].Text = "";
							lblNIOL_CompanyData[0].Visible = false;
							lblNIOL_CompanyData[1].Visible = false;
							lblNIOL_CompanyData[2].Visible = false;
							lblNIOL_CompanyData[3].Visible = false;
							lblNIOL_CompanyData[4].Visible = false;
							lblNIOL_CompanyData[14].Visible = false;
							lblNIOL_CompanyData[15].Visible = false;
							lblNIOL_CompanyData[16].Visible = false;
							lblNIOL_CompanyData[17].Visible = false;
							lblNIOL_CompanyData[18].Visible = false;
							cboNIOL_Associate.Visible = false;
						}
						else
						{
							FG_EFIG_NIOL.CurrentColumnIndex = 0;
							lblNIOL_CompanyData[0].Text = FG_EFIG_NIOL[FG_EFIG_NIOL.CurrentRowIndex, FG_EFIG_NIOL.CurrentColumnIndex].FormattedValue.ToString();
							FG_EFIG_NIOL.CurrentColumnIndex = 1;
							lblNIOL_CompanyData[1].Text = FG_EFIG_NIOL[FG_EFIG_NIOL.CurrentRowIndex, FG_EFIG_NIOL.CurrentColumnIndex].FormattedValue.ToString();
							FG_EFIG_NIOL.CurrentColumnIndex = 2;
							lblNIOL_CompanyData[2].Text = FG_EFIG_NIOL[FG_EFIG_NIOL.CurrentRowIndex, FG_EFIG_NIOL.CurrentColumnIndex].FormattedValue.ToString();
							FG_EFIG_NIOL.CurrentColumnIndex = 3;
							lblNIOL_CompanyData[3].Text = FG_EFIG_NIOL[FG_EFIG_NIOL.CurrentRowIndex, FG_EFIG_NIOL.CurrentColumnIndex].FormattedValue.ToString();
							FG_EFIG_NIOL.CurrentColumnIndex = 4;
							lblNIOL_CompanyData[4].Text = FG_EFIG_NIOL[FG_EFIG_NIOL.CurrentRowIndex, FG_EFIG_NIOL.CurrentColumnIndex].FormattedValue.ToString();

							Query = "select fipg_generic_name, fipg_main_comp_id ";
							Query = $"{Query}from Financial_Institution_Primary_Group ";
							Query = $"{Query}order by fipg_generic_name, fipg_main_comp_id";

							//Call RS_Table.Open(Query, LOCAL_ADO_DB, adOpenForwardOnly, adLockOptimistic, adCmdText)
							RS_Table = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

							//If Not IsNull(RS_Table) And (RS_Table.EOF And RS_Table.BOF) Then
							if (!(RS_Table.EOF && RS_Table.BOF))
							{
								RS_Table.MoveFirst();

								while(!RS_Table.EOF)
								{
									cboNIOL_Associate.AddItem(Convert.ToString(RS_Table["fipg_generic_name"]));
									cboNIOL_Associate.SetItemData(cboNIOL_Associate.GetNewIndex(), Convert.ToInt32(RS_Table["fipg_main_comp_id"]));
									RS_Table.MoveNext();
								};
								RS_Table.Close();
								cboNIOL_Associate.SelectedText = "";
							} // If Not (RS_Table.EOF And RS_Table.BOF) Then
						}


					}
				}
				modAdminCommon.Table_Action_Log("Financial_Institution_Company_Reference");
				modAdminCommon.Table_Action_Log("Financial_Institution_Primary_Group");
			}
			catch
			{
				modAdminCommon.Report_Error("Financial Groups: cmdAdd_FG_Click()");
				return;
			}
		}

		private void cmdAddEFIG_Click(Object eventSender, EventArgs eventArgs)
		{
			// Turn the add panel on and hide the EFIG
			bolPanelJump = false;
			pnlEFIG_Add_Group.Visible = true;
			//pnl_EFIG.Visible = False
			txtFIG_Name.Text = "";
			txtFG_PID.Text = "";
		}

		private void cmdAddFracMember_Click(Object eventSender, EventArgs eventArgs)
		{
			// txtmsearchname = ""

			pnl_new_FracMember.Visible = false;
			pnl_add_fracMember.Visible = false;

			int Prog_id = cmdFracProgram.GetItemData(cmdFracProgram.SelectedIndex);
			if (Prog_id == 44 || Prog_id == 0)
			{
				return;
			}

			pnl_new_FracMember.Visible = true;
			pnl_add_fracMember.Visible = false;
			txtfracMemberName.Text = "";
			txtfracMemberID.Text = "";
			string tmp = cmdFracProgram.Text;

			int J = (tmp.IndexOf(' ') + 1);
			if (J > 0)
			{
				tmp = tmp.Substring(Math.Min(J - 1, tmp.Length));
			}

			txtmsearchname.Text = tmp.Trim();
			RecordStat = "Add";

		}

		private void cmdAddRegno_Click(Object eventSender, EventArgs eventArgs)
		{
			//aey 11/28/2005
			Label7[1].Visible = true;
			txt_regnbr_prefix.Visible = true;
			cmdRegNoUpdate.Visible = true;
			RegNoStat = "Add";
			RegNo_id = 0;
			txt_regnbr_prefix.Text = "";


		}


		private void cmdAddBusGroup_Click(Object eventSender, EventArgs eventArgs)
		{


			int tempForEndVar = lstAllBusType.Items.Count - 1;
			for (int I = 0; I <= tempForEndVar; I++)
			{
				if (ListBoxHelper.GetSelected(lstAllBusType, I))
				{
					lstBusType.AddItem(lstAllBusType.GetListItem(I));
					lstAllBusType.RemoveItem(I);
					I--;
				}

				if (I >= lstAllBusType.Items.Count - 1)
				{
					break;
				}
			}

		}

		private void cmdCancelFracMem_Click(Object eventSender, EventArgs eventArgs) => pnl_add_fracMember.Visible = false;


		private void cmdCancelMerge_Click(Object eventSender, EventArgs eventArgs) => pnl_Merge_Frac_Programs.Visible = false;


		private void cmdDelete_EFIG_Click(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				DialogResult delConfirm = (DialogResult) 0;
				delConfirm = MessageBox.Show("Are You Sure", "Delete Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

				string Query = "";
				string aSelection = "";
				if (delConfirm == System.Windows.Forms.DialogResult.Yes)
				{
					Query = "Delete From Financial_Institution_Company_Reference ";
					Query = $"{Query}Where ficr_main_comp_id={lblCompanyData[1].Text} and ficr_sub_comp_id={lblCompanyData[5].Text}";
					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = Query;
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();
					modAdminCommon.Table_Action_Log("Financial_Institution_Company_Reference");
					modAdminCommon.Table_Action_Log("Financial_Institution_Primary_Group");
					// Prompt the User for now
					MessageBox.Show("Info has been deleted", "Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
					bolTAL = true;
					pnlEFIG_Delete.Visible = false;

					if (lblCompanyData[1].Text.Trim() != "")
					{
						aSelection = lblCompanyData[1].Text;
						txtCIC[2].Text = "";


						Fill_FG_EFIG_MC(false, aSelection);
					}
					pnl_EFIG.Visible = true;
					cboAdd_Comp_Ref.Text = "";
					txtViewOther[0].Text = "";
				}
			}
			catch
			{
				modAdminCommon.Report_Error("Financial Groups: cboEFIG_SelectGroup_Click()");
				return;
			}
		}

		private void cmdExit_AddFG_Click(Object eventSender, EventArgs eventArgs)
		{
			if (bolPanelJump)
			{
				bolPanelJump = false;
				pnlEFIG_Add_Group.Visible = false;
				pnlEFIG_NIOL.Visible = true;
			}
			else
			{
				pnlEFIG_Add_Group.Visible = false;
				pnl_EFIG.Visible = true;
			}
		}

		private void cmdExit_pnlEFIG_Delete_Click(Object eventSender, EventArgs eventArgs)
		{
			pnlEFIG_Delete.Visible = false;
			pnl_EFIG.Visible = true;
		}

		private void cmdFG_Home_Click(Object eventSender, EventArgs eventArgs)
		{
			bolPanelJump = false;
			this.Cursor = Cursors.WaitCursor;
			//    Call Get_Financial_Group_Companies(1)
			ADORecordSetHelper RS_Table = new ADORecordSetHelper();
			string Query = "select fipg_generic_name, fipg_main_comp_id from Financial_Institution_Primary_Group with (NOLOCK) ";
			Query = $"{Query}order by fipg_generic_name, fipg_main_comp_id";

			RS_Table = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

			if (!(RS_Table.EOF && RS_Table.BOF))
			{
				cboEFIG_SelectGroup[0].AddItem("All");
				cboEFIG_SelectGroup[0].SetItemData(cboEFIG_SelectGroup[0].GetNewIndex(), 0);
				RS_Table.MoveFirst();

				while(!RS_Table.EOF)
				{
					cboEFIG_SelectGroup[0].AddItem(Convert.ToString(RS_Table["fipg_generic_name"]));
					cboEFIG_SelectGroup[0].SetItemData(cboEFIG_SelectGroup[0].GetNewIndex(), Convert.ToInt32(RS_Table["fipg_main_comp_id"]));

					cboAdd_Comp_Ref.AddItem(Convert.ToString(RS_Table["fipg_generic_name"]));
					cboAdd_Comp_Ref.SetItemData(cboAdd_Comp_Ref.GetNewIndex(), Convert.ToInt32(RS_Table["fipg_main_comp_id"]));
					RS_Table.MoveNext();
				};
				RS_Table.Close();
				cboEFIG_SelectGroup[0].SelectedIndex = 1;
				Get_Financial_Group_Companies(cboAdd_Comp_Ref.GetNewIndex());
			}
			pnlEFIG_NIOL.Visible = false;
			pnlEFIG_Add_Group.Visible = false;
			pnlEFIG_Delete.Visible = false;
			//pnl_SplashScreen.Visible = False
			pnl_EFIG.Visible = true;
			txtViewOther[0].Text = "";
			this.Cursor = CursorHelper.CursorDefault;
		}

		private void cmdFracMemDelete_Click(Object eventSender, EventArgs eventArgs)
		{
			string M = "";
			DialogResult RESP = (DialogResult) 0;

			if (Conversion.Val($"{txtRefid.Text}") == 0)
			{
				MessageBox.Show("No Row Selected", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				return;
			}

			string Query = "select * from program_reference inner join company on comp_id=pgref_comp_id ";
			Query = $"{Query}inner join Business_Type_Reference on bustypref_comp_id=comp_id and bustypref_journ_id =comp_journ_id ";
			Query = $"{Query}where bustypref_type in ('PH','PM','PN') and comp_id={txtfracMemberID.Text} ";
			if (!modAdminCommon.Exist(Query))
			{
				if (modAdminCommon.Exist($"SELECT * FROM program_reference WHERE pgref_id = {txtRefid.Text} "))
				{
					Query = "DELETE FROM program_reference ";
					Query = $"{Query} WHERE pgref_id = {txtRefid.Text} ";
					M = $"Fractional Program Delete For: {($"{txtfracMemberName.Text}").Trim()}{"\r"}{"\r"}";
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
						Is_Dirty = true;
						MessageBox.Show("Delete Successfully Completed", "DELETE COMPLETED", MessageBoxButtons.OK, MessageBoxIcon.Information);
						modAdminCommon.Table_Action_Log("program_reference");
						FG_ProgCompany.RemoveItem(FG_Contact_SirName.CurrentRowIndex);
						FG_ProgCompany.Refresh();
					}
					else
					{
						MessageBox.Show("Delete cancelled by user", "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
				}
				else
				{
					M = $"Fractional Program  '{FG_FracPrograms[FG_FracPrograms.CurrentRowIndex, FG_FracPrograms.CurrentColumnIndex].FormattedValue.ToString()}',   not currently in the Aircraft Programs Table.";
					MessageBox.Show(M, "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}

				FG_ProgCompany.Refresh();

				pnl_add_fracMember.Visible = false;
				pnl_new_FracMember.Visible = false;
			}
			else
			{
				MessageBox.Show("This company has been a program manager and should not be removed", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}

		private void cmdFracMemSearchCancel_Click(Object eventSender, EventArgs eventArgs)
		{
			pnl_new_FracMember.Visible = false;
			pnl_add_fracMember.Visible = false;
		}

		private void cmdFracMerge_Click(Object eventSender, EventArgs eventArgs)
		{
			pnl_Merge_Frac_Programs.Visible = true;
			pnl_add_frac_Program.Visible = false;
		}

		private void cmdFracProgram_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{
			ADORecordSetHelper ado_Frac = new ADORecordSetHelper();
			int nRow = 0;
			int pgref_id = 0;

			grdMemSearch.Clear();

			FG_ProgCompany.Visible = false;
			int Prog_id = cmdFracProgram.GetItemData(cmdFracProgram.SelectedIndex);
			if (Prog_id == 44)
			{ //protect Other
				pnl_new_FracMember.Visible = false;
				pnl_add_fracMember.Visible = false;

				return;
			}

			if (Prog_id == 0)
			{
				cmdAddFracMember.Visible = false;
				return;
			}

			txtfracProgramID.Text = Prog_id.ToString();
			//Lbl_prog.Caption = Prog_id

			this.Cursor = Cursors.WaitCursor;

			pnl_new_FracMember.Visible = false;
			pnl_add_fracMember.Visible = false;

			cmdAddFracMember.Visible = cmdFracProgram.SelectedIndex != 0;

			FG_ProgCompany.Visible = true;
			FG_ProgCompany.Clear();
			FG_ProgCompany.RowsCount = 2;
			FG_ProgCompany.FixedRows = 1;
			FG_ProgCompany.CurrentRowIndex = 0;
			FG_ProgCompany.CurrentColumnIndex = 0;
			FG_ProgCompany[FG_ProgCompany.CurrentRowIndex, FG_ProgCompany.CurrentColumnIndex].Value = "Company Name";
			FG_ProgCompany.CurrentColumnIndex = 1;
			FG_ProgCompany[FG_ProgCompany.CurrentRowIndex, FG_ProgCompany.CurrentColumnIndex].Value = "Comp_id";
			FG_ProgCompany.CurrentColumnIndex = 2;
			FG_ProgCompany[FG_ProgCompany.CurrentRowIndex, FG_ProgCompany.CurrentColumnIndex].Value = "# Refs";

			FG_ProgCompany.SetColumnWidth(0, 200);
			FG_ProgCompany.SetColumnWidth(1, 67);
			FG_ProgCompany.SetColumnWidth(2, 67);
			FG_ProgCompany.SetColumnWidth(3, 0);
			Application.DoEvents();


			string Query = "Select distinct comp_id,comp_name,comp_city, comp_state, (select count(*) from aircraft_reference where cref_comp_id = comp_id ";
			Query = $"{Query}and cref_contact_type='17' and cref_journ_id = 0) as cac_total_referenced, pgref_id ";
			Query = $"{Query}from program_reference inner join company on comp_id = pgref_comp_id and comp_journ_id = 0 ";
			Query = $"{Query}where pgref_prog_id = {Prog_id.ToString()} ORDER BY comp_name";

			ado_Frac.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
			int old_pgref_id = 0;
			if (!(ado_Frac.BOF && ado_Frac.EOF))
			{
				ado_Frac.MoveFirst();
				nRow = 1;
				FG_ProgCompany.CurrentRowIndex = nRow;

				while(!ado_Frac.EOF)
				{
					pgref_id = Convert.ToInt32(Conversion.Val($"{Convert.ToString(ado_Frac["pgref_id"])}"));
					if (pgref_id != old_pgref_id)
					{
						FG_ProgCompany.CurrentColumnIndex = 0;
						FG_ProgCompany[FG_ProgCompany.CurrentRowIndex, FG_ProgCompany.CurrentColumnIndex].Value = ($"{Convert.ToString(ado_Frac["Comp_Name"])} ({Convert.ToString(ado_Frac["comp_city"])} {Convert.ToString(ado_Frac["comp_state"])})").Trim();
						FG_ProgCompany.CurrentColumnIndex = 1;
						FG_ProgCompany[FG_ProgCompany.CurrentRowIndex, FG_ProgCompany.CurrentColumnIndex].Value = ($"{Convert.ToString(ado_Frac["comp_id"])} ").Trim();
						FG_ProgCompany.CurrentColumnIndex = 2;
						FG_ProgCompany[FG_ProgCompany.CurrentRowIndex, FG_ProgCompany.CurrentColumnIndex].Value = ($"{Convert.ToString(ado_Frac["cac_total_referenced"])} ").Trim();
						FG_ProgCompany.CurrentColumnIndex = 3;
						FG_ProgCompany[FG_ProgCompany.CurrentRowIndex, FG_ProgCompany.CurrentColumnIndex].Value = ($"{Convert.ToString(ado_Frac["pgref_id"])} ").Trim();
						nRow++;
						FG_ProgCompany.RowsCount = nRow + 1;
						FG_ProgCompany.CurrentRowIndex = nRow;
					}
					old_pgref_id = pgref_id;
					ado_Frac.MoveNext();
					Application.DoEvents();
				};
			}

			ado_Frac.Close();
			FG_ProgCompany.RowsCount--;
			FG_ProgCompany.Refresh();

			this.Cursor = CursorHelper.CursorDefault;
			Application.DoEvents();

		}


		private void cmdFracRefresh_Click(Object eventSender, EventArgs eventArgs) => tab_Lookup_SelectedIndexChanged(tab_Lookup, new EventArgs());


		private void cmdMemSearch_Click(Object eventSender, EventArgs eventArgs)
		{
			ADORecordSetHelper ado_Search = new ADORecordSetHelper();

			if (Strings.Len(($"{txtmsearchname.Text}").Trim()) == 0 && Strings.Len(($"{txtmSearchNumber.Text}").Trim()) == 0)
			{
				return;
			}

			Stopped = false;
			grdMemSearch.Clear();
			grdMemSearch.RowsCount = 2;
			grdMemSearch.Visible = true;

			grdMemSearch.CurrentRowIndex = 0;
			grdMemSearch.CurrentColumnIndex = 0;
			grdMemSearch[grdMemSearch.CurrentRowIndex, grdMemSearch.CurrentColumnIndex].Value = "Comp_id";
			grdMemSearch.CurrentColumnIndex = 1;
			grdMemSearch[grdMemSearch.CurrentRowIndex, grdMemSearch.CurrentColumnIndex].Value = "Name";
			grdMemSearch.CurrentColumnIndex = 2;
			grdMemSearch[grdMemSearch.CurrentRowIndex, grdMemSearch.CurrentColumnIndex].Value = "City";
			grdMemSearch.CurrentColumnIndex = 3;
			grdMemSearch[grdMemSearch.CurrentRowIndex, grdMemSearch.CurrentColumnIndex].Value = "Country";
			grdMemSearch.CurrentColumnIndex = 4;
			grdMemSearch[grdMemSearch.CurrentRowIndex, grdMemSearch.CurrentColumnIndex].Value = "# AC Refs";

			grdMemSearch.SetColumnWidth(0, 67);
			grdMemSearch.SetColumnWidth(1, 133);
			grdMemSearch.SetColumnWidth(2, 133);
			grdMemSearch.SetColumnWidth(3, 67);
			grdMemSearch.SetColumnWidth(4, 67);

			int nRow = 1;
			grdMemSearch.CurrentRowIndex = nRow;

			this.Cursor = Cursors.WaitCursor;
			Application.DoEvents();

			string Query = "SELECT DISTINCT comp_id, comp_name,  comp_city, comp_country, cac_total_referenced ";
			Query = $"{Query}from company inner join Business_Type_Reference on bustypref_comp_id=comp_id and bustypref_journ_id =comp_journ_id ";
			Query = $"{Query}left outer join Company_Aircraft_Count on (comp_id = cac_comp_id and comp_journ_id = cac_journ_id) ";
			Query = $"{Query}where bustypref_type in ('PH','PM','PN') ";

			if (chk_FracHistory.CheckState == CheckState.Unchecked)
			{
				Query = $"{Query} and comp_journ_id=0 ";
			}
			else
			{
				Query = $"{Query} and comp_journ_id >= 0 ";
			}

			if (Strings.Len(($"{txtmsearchname.Text}").Trim()) > 0)
			{
				Query = $"{Query}and comp_name_search like '{RemoveAllMiscCharsAndUpShift(txtmsearchname.Text)}%' ";
			}

			if (Strings.Len(($"{txtmSearchNumber.Text}").Trim()) > 0)
			{
				Query = $"{Query}and  comp_id in ({txtmSearchNumber.Text}) ";
			}

			ado_Search.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

			if (!(ado_Search.BOF && ado_Search.EOF))
			{
				ado_Search.MoveFirst();
				grdMemSearch.Visible = true;

				while(!ado_Search.EOF)
				{
					grdMemSearch.CurrentColumnIndex = 0;
					grdMemSearch[grdMemSearch.CurrentRowIndex, grdMemSearch.CurrentColumnIndex].Value = $"{Convert.ToString(ado_Search["comp_id"])}";
					grdMemSearch.CurrentColumnIndex = 1;
					grdMemSearch[grdMemSearch.CurrentRowIndex, grdMemSearch.CurrentColumnIndex].Value = $"{Convert.ToString(ado_Search["Comp_Name"])}";
					grdMemSearch.CurrentColumnIndex = 2;
					grdMemSearch[grdMemSearch.CurrentRowIndex, grdMemSearch.CurrentColumnIndex].Value = $"{Convert.ToString(ado_Search["comp_city"])}";
					grdMemSearch.CurrentColumnIndex = 3;
					grdMemSearch[grdMemSearch.CurrentRowIndex, grdMemSearch.CurrentColumnIndex].Value = $"{Convert.ToString(ado_Search["comp_country"])}";
					grdMemSearch.CurrentColumnIndex = 4;
					grdMemSearch[grdMemSearch.CurrentRowIndex, grdMemSearch.CurrentColumnIndex].Value = $"{Convert.ToString(ado_Search["cac_total_referenced"])}";

					nRow++;
					grdMemSearch.RowsCount = nRow + 1;
					grdMemSearch.CurrentRowIndex = nRow;

					Application.DoEvents();
					if (Stopped)
					{
						break;
					}

					ado_Search.MoveNext();
				};
			}

			ado_Search.Close();

			if (grdMemSearch.Visible)
			{
				grdMemSearch.RowsCount--;
				grdMemSearch.Refresh();
			}

			this.Cursor = CursorHelper.CursorDefault;

		}

		public string RemoveAllMiscCharsAndUpShift(string strTemp)
		{
			string result = "";
			StringBuilder strResults = new StringBuilder();
			string strWork = strTemp;
			int iTest = 0;


			if (Strings.Len(strTemp) > 0)
			{
				strWork = strTemp.ToUpper();
				int tempForEndVar = Strings.Len(strTemp);
				for (int iZ1 = 1; iZ1 <= tempForEndVar; iZ1++)
				{
					iTest = Strings.Asc(strWork.Substring(Math.Min(iZ1 - 1, strWork.Length), Math.Min(1, Math.Max(0, strWork.Length - (iZ1 - 1))))[0]);
					if (((iTest >= 65) && (iTest <= 90)) || ((iTest >= 48) && (iTest <= 57)))
					{
						strResults.Append(strWork.Substring(Math.Min(iZ1 - 1, strWork.Length), Math.Min(1, Math.Max(0, strWork.Length - (iZ1 - 1)))));
					}
				}
			}
			else
			{
				strResults = new StringBuilder("AWAITINGDOCUMENTATION");
			} // Len(strTemp) > 0

			return strResults.ToString();

		}

		private void cmdMergeFractionals_Click(Object eventSender, EventArgs eventArgs)
		{

			int keep_program_id = cboFracToKeep.GetItemData(cboFracToKeep.SelectedIndex);
			int remove_program_id = cboFracToRemove.GetItemData(cboFracToRemove.SelectedIndex);

			if (keep_program_id <= 0 || keep_program_id == 44)
			{
				MessageBox.Show("Cannot process this program -K", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				return;
			}

			if (remove_program_id <= 0 || remove_program_id == 44)
			{
				MessageBox.Show("Cannot process this program -R", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				return;
			}

			if (remove_program_id == keep_program_id)
			{
				MessageBox.Show("Cannot merge a program onto itself", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				return;
			}

			this.Cursor = Cursors.WaitCursor;
			Application.DoEvents();

			//move charter companies
			string Query = $"update program_reference set pgref_prog_id = {keep_program_id.ToString()} ";
			Query = $"{Query}where pgref_prog_id = {remove_program_id.ToString()} ";
			DbCommand TempCommand = null;
			TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
			UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
			TempCommand.CommandText = Query;
			//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
			TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
			UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
			TempCommand.ExecuteNonQuery();

			//move shareholder companies
			Query = $"update program_shareholders set pshr_prog_id = {keep_program_id.ToString()} ";
			Query = $"{Query}where pshr_prog_id = {remove_program_id.ToString()} ";
			DbCommand TempCommand_2 = null;
			TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
			UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
			TempCommand_2.CommandText = Query;
			//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
			TempCommand_2.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
			UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
			TempCommand_2.ExecuteNonQuery();

			Query = $"delete Aircraft_Programs where prog_id = {remove_program_id.ToString()} ";
			DbCommand TempCommand_3 = null;
			TempCommand_3 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
			UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_3);
			TempCommand_3.CommandText = Query;
			//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
			TempCommand_3.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
			UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_3);
			TempCommand_3.ExecuteNonQuery();

			tab_Lookup_SelectedIndexChanged(tab_Lookup, new EventArgs());

			//look for duplicate charter companies
			Query = "Select pgref_comp_id, count(*) as freq from program_reference ";
			Query = $"{Query}Where pgref_prog_id = {keep_program_id.ToString()}  group by pgref_comp_id having count(*)>1 ";

			if (modAdminCommon.Exist(Query))
			{
				MessageBox.Show($"Merge complete{Environment.NewLine}There is a duplicate company in the program, please remove it", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
			else
			{
				MessageBox.Show("Merge complete", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

			this.Cursor = CursorHelper.CursorDefault;

		}

		private void cmdNewSearch_pnlEFIG_NIOL_Click(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				// check to see if the textbox is empty
				if (txtViewOther[1].Text == "")
				{
					// force the user to enter text, so we can reduce the 4000 records to about 20 or so
					MessageBox.Show("Please enter your search criteria in the textbox", "Empty Search Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					// set the focus on the text box to guide the user to where they need to enter info
					txtViewOther[1].Focus();
				}
				else
				{
					pnlEFIG_NIOL.Visible = false;
					lblNIOL_CompanyData[0].Visible = false;
					lblNIOL_CompanyData[1].Visible = false;
					lblNIOL_CompanyData[2].Visible = false;
					lblNIOL_CompanyData[3].Visible = false;
					lblNIOL_CompanyData[4].Visible = false;
					lblNIOL_CompanyData[14].Visible = false;
					lblNIOL_CompanyData[15].Visible = false;
					lblNIOL_CompanyData[16].Visible = false;
					lblNIOL_CompanyData[17].Visible = false;
					lblNIOL_CompanyData[18].Visible = false;
					lblNIOL_CompanyData[25].Visible = false;
					cmd_Add_Parent_pnlEFIG_NIOL.Visible = false;

					cboNIOL_Associate.Visible = false;
					if (txtViewOther[1].Text == "All")
					{
						LoadNIOL(false, "");
					}
					else
					{
						// call the LoadNIOL to populate the datagrid, pass it what the user typed in the textbox
						LoadNIOL(true, txtViewOther[1].Text);
					}
					// pnl_SplashScreen.Visible = False
					pnlEFIG_NIOL.Visible = true;
					FG_EFIG_NIOL.Visible = true;
				}
			}
			catch
			{
				modAdminCommon.Report_Error("Financial Groups: cmdNewSearch_pnlEFIG_NIOL_Click()");
				return;
			}
		}

		private void cmdRegNoChange_Click(Object eventSender, EventArgs eventArgs)
		{
			//aey 11/28/2005
			Label7[1].Visible = true;
			txt_regnbr_prefix.Visible = true;
			cmdRegNoUpdate.Visible = true;
			RegNoStat = "Change";

			txt_regnbr_prefix.Text = RegNoList.GetListItem(ListBoxHelper.GetSelectedIndex(RegNoList));
			RegNo_id = RegNoList.GetItemData(ListBoxHelper.GetSelectedIndex(RegNoList));


		}

		private void cmdRegNoDelete_Click(Object eventSender, EventArgs eventArgs)
		{
			//aey 11/28/2005
			RegNoStat = "Delete";
			txt_regnbr_prefix.Text = RegNoList.GetListItem(ListBoxHelper.GetSelectedIndex(RegNoList));
			RegNo_id = RegNoList.GetItemData(ListBoxHelper.GetSelectedIndex(RegNoList));

			string Query = $"delete from Registration_Number_Prefix where regnbrpref_id={RegNo_id.ToString()} ";
			DbCommand TempCommand = null;
			TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
			UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
			TempCommand.CommandText = Query;
			UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
			TempCommand.ExecuteNonQuery();

			RegNoList.RemoveItem(ListBoxHelper.GetSelectedIndex(RegNoList));

		}


		private void cmdRegNoUpdate_Click(Object eventSender, EventArgs eventArgs)
		{
			string Query = "";

			txt_regnbr_prefix.Visible = false;
			cmdRegNoUpdate.Visible = false;

			if (RegNoStat == "Add")
			{
				Query = "Insert into Registration_Number_Prefix(regnbrpref_prefix,regnbrpref_country_name) ";
				Query = $"{Query} values('{txt_regnbr_prefix.Text.Trim()}','{txt_country_name.Text.Trim()}') ";
				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = Query;
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();
				RegNoList.AddItem(txt_regnbr_prefix.Text.Trim());
			}
			else if (RegNoStat == "Change")
			{ 
				if (RegNo_id > 0)
				{
					Query = $"Update registration_Number_Prefix set regnbrpref_prefix='{txt_regnbr_prefix.Text.Trim()}' ";
					Query = $"{Query}Where regnbrpref_id = {RegNo_id.ToString()} ";
					DbCommand TempCommand_2 = null;
					TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
					TempCommand_2.CommandText = Query;
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
					TempCommand_2.ExecuteNonQuery();
					RegNoList.Text = txt_regnbr_prefix.Text.Trim();
				}
			}

		}

		private void cmdRemoveBusGroup_Click(Object eventSender, EventArgs eventArgs)
		{

			int tempForEndVar = lstBusType.Items.Count - 1;
			for (int I = 0; I <= tempForEndVar; I++)
			{
				if (ListBoxHelper.GetSelected(lstBusType, I))
				{
					lstAllBusType.AddItem(lstBusType.GetListItem(I), I);
					lstBusType.RemoveItem(I);
					I--;
				}

				if (I >= lstBusType.Items.Count - 1)
				{
					break;
				}

			}
		}

		private void cmdSaveFracMember_Click(Object eventSender, EventArgs eventArgs)
		{
			//4/19/04 aey   Contact_Sirname ("Save")
			string Query = "";

			if (Conversion.Val($"{txtfracMemberID.Text}") == 0)
			{
				MessageBox.Show("No Program Selected", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				return;
			}

			if (RecordStat == "Add")
			{
				Query = $"select * from program_reference where pgref_prog_id={txtfracProgramID.Text} and pgref_comp_id ={txtfracMemberID.Text} ";
				if (modAdminCommon.Exist(Query))
				{
					MessageBox.Show("An entry with this program/company already exists - insert cancelled", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					return;
				}

				Query = $"select * from program_reference where pgref_comp_id ={txtfracMemberID.Text} ";
				if (modAdminCommon.Exist(Query))
				{
					MessageBox.Show("A different program already uses this company - insert cancelled", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					return;
				}

				Query = $"INSERT INTO program_reference (pgref_prog_id,pgref_comp_id) VALUES ({Conversion.Val(txtfracProgramID.Text).ToString()} ,";
				Query = $"{Query} {Conversion.Val($"{txtfracMemberID.Text}").ToString()})";
				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = Query;
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();
				Is_Dirty = true;
				FG_ProgCompany.RowsCount++;
				FG_ProgCompany.CurrentRowIndex = FG_ProgCompany.RowsCount - 1;
				FG_ProgCompany.CurrentColumnIndex = 0;
				FG_ProgCompany[FG_ProgCompany.CurrentRowIndex, FG_ProgCompany.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txtfracMemberName).Trim();
				FG_ProgCompany.CurrentColumnIndex = 1;
				FG_ProgCompany[FG_ProgCompany.CurrentRowIndex, FG_ProgCompany.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txtfracMemberID).Trim();
				Is_Dirty = true;
				MessageBox.Show("Insert Successfully Completed", "INSERT COMPLETED", MessageBoxButtons.OK, MessageBoxIcon.Information);
				modAdminCommon.Table_Action_Log("program_reference");
			}
			else if (RecordStat == "Update")
			{ 
				if (Conversion.Val($"{txtRefid.Text}") == 0)
				{
					MessageBox.Show("No Row Selected", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					return;
				}

				FG_ProgCompany.CurrentColumnIndex = 0;
				Query = "UPDATE program_reference SET ";
				Query = $"{Query}pgref_comp_id = {txtfracMemberID.Text} ";
				Query = $"{Query} WHERE pgref_id = {txtRefid.Text} ";
				DbCommand TempCommand_2 = null;
				TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
				TempCommand_2.CommandText = Query;
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
				TempCommand_2.ExecuteNonQuery();
				Is_Dirty = true;
				FG_ProgCompany.CurrentColumnIndex = 1;
				FG_ProgCompany[FG_ProgCompany.CurrentRowIndex, FG_ProgCompany.CurrentColumnIndex].Value = txtfracMemberID;
				MessageBox.Show("Update Successfully Completed", "UPDATE COMPLETED", MessageBoxButtons.OK, MessageBoxIcon.Information);
				modAdminCommon.Table_Action_Log("program_reference");
			}
			FG_ProgCompany.Refresh();

			pnl_add_fracMember.Visible = false;
			pnl_new_FracMember.Visible = false;

		}

		private void Load_Region_Tab_Grid()
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strRegionName = "";
			string strRegionSourceURL = "";
			int lCol1 = 0;
			int lRow1 = 0;

			try
			{

				strQuery1 = "SELECT * FROM Region WITH (NOLOCK) ORDER BY region_name";
				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					FG_Region.Clear();
					FG_Region.ColumnsCount = 2;
					FG_Region.RowsCount = 2;
					FG_Region.FixedColumns = 0;
					FG_Region.FixedRows = 1;

					lRow1 = 0;
					lCol1 = -1;

					FG_Region.CurrentRowIndex = lRow1;

					lCol1++;
					FG_Region.CurrentColumnIndex = lCol1;
					FG_Region.SetColumnWidth(lCol1, 233);
					FG_Region[lRow1, lCol1].Value = "Region Name";

					lCol1++;
					FG_Region.CurrentColumnIndex = lCol1;
					FG_Region.SetColumnWidth(lCol1, 633);
					FG_Region[lRow1, lCol1].Value = "Source URL";

					do 
					{ // Loop Until rstRec1.EOF = True

						lRow1++;
						FG_Region.RowsCount = lRow1 + 1;
						FG_Region.CurrentRowIndex = lRow1;

						lblLoadingRegion.Text = $"Loading {StringsHelper.Format(lRow1, "#,##0")} of {StringsHelper.Format(rstRec1.RecordCount, "#,##0")} Records";

						FG_Region[lRow1, 0].Value = ($"{Convert.ToString(rstRec1["region_name"])} ").Trim();
						FG_Region[lRow1, 1].Value = ($"{Convert.ToString(rstRec1["region_source_definition"])} ").Trim();

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);
					 // FG_Region

				} // If rstRec1.BOF = False And rstRec1.EOF = False Then

				rstRec1.Close();
				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Homebase-Admin", $"Load_Region_Tab_Grid_Error: {excep.Message}");
			}

		} // Load_Region_Tab_Grid

		private void cmdSaveNew_Click(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.cmdSaveNew, eventSender);

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strRegionName = "";
			string strRegionSourceURL = "";

			try
			{

				switch(Index)
				{
					case 0 :  // Save 
						 
						strRegionName = txtRegionName.Text.Trim(); 
						strRegionSourceURL = txtRegionSourceURL.Text.Trim(); 
						 
						if (strRegionName != "")
						{

							strQuery1 = $"SELECT * FROM Region WHERE (region_name = '{StringsHelper.Replace(strRegionName, "'", "''", 1, -1, CompareMethod.Binary)}') ";
							rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);

							if (rstRec1.BOF && rstRec1.EOF)
							{
								rstRec1.AddNew();
							} // If rstRec1.BOF = True And rstRec1.EOF = True Then

							rstRec1["region_name"] = strRegionName;
							rstRec1["region_source_definition"] = strRegionSourceURL;
							rstRec1.UpdateBatch();

							rstRec1.Close();

							Load_Region_Tab_Grid();

							modAdminCommon.gIsRegionDirty = true;

						}  // If strRegionName <> "" Then 
						 
						break;
					case 1 :  // New 
						 
						txtRegionName.Text = ""; 
						txtRegionSourceURL.Text = ""; 
						 
						break;
				} // Case Index

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Homebase-Admin", $"cmdSaveNew_Click_Error: {Index.ToString()} {excep.Message}");
			}

		} // cmdSaveNew_Click

		private void cmdSearch_Compy_wDate_Click(Object eventSender, EventArgs eventArgs)
		{
			object date_today = null;
			try
			{
				if (Information.IsDate(txtDateRange_pnlEFIG[0].Text))
				{
					date_today = DateTime.Now.ToString("MM/dd/yyyy");
					//UPGRADE_WARNING: (1068) date_today of type Variant is being forced to DateTime. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
					if (DateTime.Parse(txtDateRange_pnlEFIG[0].Text) > Convert.ToDateTime(date_today))
					{
						//UPGRADE_WARNING: (1068) date_today of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						MessageBox.Show($"The text you have entered cannot be greater than: {Convert.ToString(date_today)}", "Invalid Input For Search", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
					else
					{
						Fill_FG_EFIG_MC(true, txtDateRange_pnlEFIG[0].Text);
					}
				}
				else
				{
					MessageBox.Show("The text you have entered must be a date", "Invalid Input For Search", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					txtDateRange_pnlEFIG[0].Focus();
				}
			}
			catch
			{

				modAdminCommon.Report_Error("Financial Groups: cmdSearch_Compy_wDate_Click()");
				return;
			}
		}

		private void cmdStopFrac_Click(Object eventSender, EventArgs eventArgs)
		{
			Stopped = true;
			Application.DoEvents();
		}

		//UPGRADE_NOTE: (7001) The following declaration (Command3_Click) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void Command3_Click()
		//{
			//
		//}

		private void cmdViewNIOL_Click(Object eventSender, EventArgs eventArgs)
		{
			try
			{

				lblNIOL_CompanyData[0].Visible = false;
				lblNIOL_CompanyData[1].Visible = false;
				lblNIOL_CompanyData[2].Visible = false;
				lblNIOL_CompanyData[3].Visible = false;
				lblNIOL_CompanyData[4].Visible = false;
				lblNIOL_CompanyData[14].Visible = false;
				lblNIOL_CompanyData[15].Visible = false;
				lblNIOL_CompanyData[16].Visible = false;
				lblNIOL_CompanyData[17].Visible = false;
				lblNIOL_CompanyData[18].Visible = false;
				lblNIOL_CompanyData[25].Visible = false;
				cmd_Add_Parent_pnlEFIG_NIOL.Visible = false;
				// Turn the combobox off, it will be visible when the user makes a selection from the datagrid
				cboNIOL_Associate.Visible = false;
				// call the LoadNIOL to populate the datagrid, pass it what the user typed in the textbox
				LoadNIOL(true, txtViewOther[0].Text);
				// pnl_SplashScreen.Visible = False
				// turn the panel on
				chk_SortTotal.Visible = true;
				pnlEFIG_NIOL.Visible = true;
				if (lblNIOL_CompanyData[7].Text != "0")
				{
					FG_EFIG_NIOL.Visible = true;
				}
				txtViewOther[1].Text = txtViewOther[0].Text;
				//  End If
			}
			catch
			{
				modAdminCommon.Report_Error("Financial Groups: cmdViewNIOL_Click_Click()");
				return;
			}
		}

		//UPGRADE_NOTE: (7001) The following declaration (Command1_Click) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void Command1_Click()
		//{
			//
		//}

		//UPGRADE_NOTE: (7001) The following declaration (Combo1_Change) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void Combo1_Change()
		//{
			//
		//}


		private void FG_Array_Click(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				FG_Array[0].CurrentColumnIndex = 0;
				txtCIC[0].Text = FG_Array[0][FG_Array[0].CurrentRowIndex, FG_Array[0].CurrentColumnIndex].FormattedValue.ToString();
				cboEFIG_SelectGroup[2].Text = "";
				// set the labels witht the values from the datagrid
				FG_Array[0].CurrentColumnIndex = 1;
				cboEFIG_SelectGroup[2].SelectedText = FG_Array[0][FG_Array[0].CurrentRowIndex, FG_Array[0].CurrentColumnIndex].FormattedValue.ToString();
				FG_Array[0].CurrentColumnIndex = 2;
				txtCIC[1].Text = FG_Array[0][FG_Array[0].CurrentRowIndex, FG_Array[0].CurrentColumnIndex].FormattedValue.ToString();
				FG_Array[0].CurrentColumnIndex = 3;
				txtCIC[2].Text = FG_Array[0][FG_Array[0].CurrentRowIndex, FG_Array[0].CurrentColumnIndex].FormattedValue.ToString();
			}
			catch
			{

				modAdminCommon.Report_Error("Company SIC Code: FG_Array_Click()");
				return;
			}
		}

		private void FG_Cat_List_Click(Object eventSender, EventArgs eventArgs)
		{

			RecordStat = "Update";
			pnl_CAT_AddUpdate.Visible = true;
			FG_Cat_List.CurrentColumnIndex = 0;
			txt_cacctype_code.Text = FG_Cat_List[FG_Cat_List.CurrentRowIndex, FG_Cat_List.CurrentColumnIndex].FormattedValue.ToString();
			FG_Cat_List.CurrentColumnIndex = 1;
			txt_cacctype_Name.Text = FG_Cat_List[FG_Cat_List.CurrentRowIndex, FG_Cat_List.CurrentColumnIndex].FormattedValue.ToString();

		}

		private void FG_CBTList_Click(Object eventSender, EventArgs eventArgs)
		{
			//Update existing row

			RecordStat = "Update";
            DataGridViewFlex Grd = FG_CBTList;
			//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			Grd.Col = 0;
			//UPGRADE_TODO: (1067) Member Text is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			txt_cbus_type.Text = Convert.ToString(Grd.Text);
			//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			Grd.Col = 1;
			//UPGRADE_TODO: (1067) Member Text is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			txt_cbus_Name.Text = Convert.ToString(Grd.Text);
			//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			Grd.Col = 2;
			//UPGRADE_TODO: (1067) Member Text is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			string txt_cbus_abi_type = Convert.ToString(Grd.Text);

			if (txt_cbus_abi_type == "Y")
			{
				chkBusIdxOnly.CheckState = CheckState.Checked;
			}
			else
			{
				chkBusIdxOnly.CheckState = CheckState.Unchecked;
			}

			//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			Grd.Col = 3;
			//UPGRADE_TODO: (1067) Member Text is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			string txt_cbus_ac_type = Convert.ToString(Grd.Text);

			if (txt_cbus_ac_type == "Y")
			{
				chkACOnly.CheckState = CheckState.Checked;
			}
			else
			{
				chkACOnly.CheckState = CheckState.Unchecked;
			}

			//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			Grd.Col = 4;
			//UPGRADE_TODO: (1067) Member Text is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			string txt_cbus_yacht_type = Convert.ToString(Grd.Text);
			if (txt_cbus_yacht_type == "Y")
			{
				chkYachtOnly.CheckState = CheckState.Checked;
			}
			else
			{
				chkYachtOnly.CheckState = CheckState.Unchecked;
			}



			//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			Grd.Col = 5;
			//UPGRADE_TODO: (1067) Member Text is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			txt_cbus_Desc.Text = Convert.ToString(Grd.Text);

			//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			Grd.Col = 6;
			//UPGRADE_TODO: (1067) Member Text is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			txt_cbus_keywords.Text = Convert.ToString(Grd.Text);


			FillBusinessGroupLists(($"{txt_cbus_type.Text}").Trim());
			pnl_CBT_AddUpdate.Visible = true;
			pnl_BusGroup.Visible = true;


		}

		private void FG_CompAgency_Click(Object eventSender, EventArgs eventArgs)
		{

			pnl_GAT_AddUpdate.Visible = true;
			RecordStat = "Update";

			//populate change panel from grid
			FG_CompAgency.CurrentColumnIndex = 0;
			txt_cagtype_code.Text = FG_CompAgency[FG_CompAgency.CurrentRowIndex, FG_CompAgency.CurrentColumnIndex].FormattedValue.ToString();
			FG_CompAgency.CurrentColumnIndex = 1;
			txt_cagtype_Name.Text = FG_CompAgency[FG_CompAgency.CurrentRowIndex, FG_CompAgency.CurrentColumnIndex].FormattedValue.ToString();

		}

		private void FG_Contact_SirName_Click(Object eventSender, EventArgs eventArgs)
		{
			//aey 4/9/04
			txt_csir_name.Text = FG_Contact_SirName[FG_Contact_SirName.CurrentRowIndex, FG_Contact_SirName.CurrentColumnIndex].FormattedValue.ToString();
			pnl_CSN_AddUpdate.Visible = true;
			RecordStat = "Update";
		}

		private void FG_Contact_Suffix_Click(Object eventSender, EventArgs eventArgs)
		{
			//aey 4/19/04
			txt_csuffix_name.Text = FG_Contact_Suffix[FG_Contact_Suffix.CurrentRowIndex, FG_Contact_Suffix.CurrentColumnIndex].FormattedValue.ToString();
			pnl_CS_AddUpdate.Visible = true;
			RecordStat = "Update";

		}

		private void FG_Contact_Title_Click(Object eventSender, EventArgs eventArgs)
		{
			//aey 4/20/04

			RecordStat = "Update";
			FG_Contact_Title.CurrentColumnIndex = 0;
			txt_ctitle_name.Text = FG_Contact_Title[FG_Contact_Title.CurrentRowIndex, FG_Contact_Title.CurrentColumnIndex].FormattedValue.ToString();
			FG_Contact_Title.CurrentColumnIndex = 3;
			if (FG_Contact_Title[FG_Contact_Title.CurrentRowIndex, FG_Contact_Title.CurrentColumnIndex].FormattedValue.ToString() == "Y")
			{
				chk_ctitle_active_flag.CheckState = CheckState.Checked;
			}
			else
			{
				chk_ctitle_active_flag.CheckState = CheckState.Unchecked;
			}

			FillTitleGroupLists(($"{txt_ctitle_name.Text}").Trim());

			pnl_CT_AddUpdate.Visible = true;
			pnl_ContactTitleGroup.Visible = true;

			modAdminCommon.Highlight_Grid_Row(FG_Contact_Title, 0);

		}

		private void FG_Contact_Title_New_Click(Object eventSender, EventArgs eventArgs)
		{


			FG_Contact_Title_New.CurrentColumnIndex = 0;
			txt_contact_title_search[1].Text = FG_Contact_Title_New[FG_Contact_Title_New.CurrentRowIndex, FG_Contact_Title_New.CurrentColumnIndex].FormattedValue.ToString();
			txt_contact_title_search[1].Tag = FG_Contact_Title_New[FG_Contact_Title_New.CurrentRowIndex, FG_Contact_Title_New.CurrentColumnIndex].FormattedValue.ToString();

			// set the button tag to be the count
			FG_Contact_Title_New.CurrentColumnIndex = 1;
			cmd_contact_button[1].Tag = FG_Contact_Title_New[FG_Contact_Title_New.CurrentRowIndex, FG_Contact_Title_New.CurrentColumnIndex].FormattedValue.ToString();

			FG_Contact_Title_New.CurrentColumnIndex = 1;
			frm_update_frame.Visible = true;


		}

		private void FG_Country_Click(Object eventSender, EventArgs eventArgs)
		{
			//modify current record

			ADORecordSetHelper ado_regno = new ADORecordSetHelper();
			string RegNo = "";
			int RegID = 0;

			int lRow1 = 0;
			int lCol1 = 0;

			pnl_Country_AddUpdate.Visible = true;

			RecordStat = "Update";
			Control Grd = FG_Country;


			lRow1 = FG_Country.CurrentRowIndex;
			txt_county_grid_row.Text = lRow1.ToString();

			lCol1 = -1;

			lCol1++;
			txt_country_code.Text = Convert.ToString(FG_Country[lRow1, lCol1].Value);

			lCol1++;
			txt_country_name.Text = Convert.ToString(FG_Country[lRow1, lCol1].Value);
			txt_country_name_old.Text = Convert.ToString(FG_Country[lRow1, lCol1].Value);

			lCol1++;
			txt_country_language.Text = Convert.ToString(FG_Country[lRow1, lCol1].Value);

			lCol1++;
			txt_country_time_vs_eastern.Text = Convert.ToString(FG_Country[lRow1, lCol1].Value);

			lCol1++;
			txt_country_currency.Text = Convert.ToString(FG_Country[lRow1, lCol1].Value);

			lCol1++;
			txt_country_int_access_code.Text = Convert.ToString(FG_Country[lRow1, lCol1].Value);

			lCol1++;
			txt_Abbrev.Text = Convert.ToString(FG_Country[lRow1, lCol1].Value);

			lCol1++;
			txt_Continent_Name.Text = Convert.ToString(FG_Country[lRow1, lCol1].Value);

			lCol1++;
			txt_CityCode.Text = Convert.ToString(FG_Country[lRow1, lCol1].Value);

			lCol1++;
			if (Convert.ToString(FG_Country[lRow1, lCol1].Value) == "Y")
			{
				Chk_Company_active.CheckState = CheckState.Checked;
			}
			else
			{
				Chk_Company_active.CheckState = CheckState.Unchecked;
			}

			lCol1++;
			modAdminCommon.SetComboBoxByItemData(cmbDialLineAccessCode, Convert.ToInt32(Double.Parse(Convert.ToString(FG_Country[lRow1, lCol1].Value))));
			 // With FG_Country

			//aey 11/28/2005
			RegNoList.Items.Clear();

			txt_regnbr_prefix.Visible = false;
			//pnl_Country_AddUpdate.Visible = False
			cmdRegNoUpdate.Visible = false;
			txt_regnbr_prefix.Text = "";
			Label7[1].Visible = false;

			string Query = "Select regnbrpref_id,regnbrpref_prefix from Registration_Number_Prefix ";
			Query = $"{Query}Where regnbrpref_country_name='{modAdminCommon.Fix_Quote(txt_country_name)}' order by regnbrpref_prefix ";

			ado_regno.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
			if (!(ado_regno.EOF && ado_regno.BOF))
			{
				ado_regno.MoveFirst();
				while (!ado_regno.EOF)
				{
					RegNo = ($"{Convert.ToString(ado_regno["regnbrpref_prefix"])}").Trim();
					RegID = Convert.ToInt32(Conversion.Val($"{Convert.ToString(ado_regno["regnbrpref_id"])}"));
					RegNoList.AddItem(RegNo);
					RegNoList.SetItemData(RegNoList.GetNewIndex(), RegID);

					ado_regno.MoveNext();
				}

				ado_regno.Close();
			}
			ado_regno = null;

		}

		private void FG_Currency_Click(Object eventSender, EventArgs eventArgs)
		{
			//aey 4/19/04
			FG_Currency.CurrentColumnIndex = 0;
			txt_currency_name[0].Text = FG_Currency[FG_Currency.CurrentRowIndex, FG_Currency.CurrentColumnIndex].FormattedValue.ToString();
			FG_Currency.CurrentColumnIndex = 1;
			txt_currency_name[1].Text = FG_Currency[FG_Currency.CurrentRowIndex, FG_Currency.CurrentColumnIndex].FormattedValue.ToString();
			FG_Currency.CurrentColumnIndex = 2;
			txt_currency_name[2].Text = FG_Currency[FG_Currency.CurrentRowIndex, FG_Currency.CurrentColumnIndex].FormattedValue.ToString();
			FG_Currency.CurrentColumnIndex = 3;
			txt_currency_name[3].Text = FG_Currency[FG_Currency.CurrentRowIndex, FG_Currency.CurrentColumnIndex].FormattedValue.ToString();
			FG_Currency.CurrentColumnIndex = 4;
			txt_currency_name[4].Text = FG_Currency[FG_Currency.CurrentRowIndex, FG_Currency.CurrentColumnIndex].FormattedValue.ToString();
			FG_Currency.CurrentColumnIndex = 5;
			txt_currency_name[5].Text = FG_Currency[FG_Currency.CurrentRowIndex, FG_Currency.CurrentColumnIndex].FormattedValue.ToString();
			pnl_Currency_Change.Visible = true;
			RecordStat = "Update";

		}

		private void FG_EFIG_MC_Click(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				FG_EFIG_MC.CurrentColumnIndex = 0;
				lblCompanyData[0].Text = FG_EFIG_MC[FG_EFIG_MC.CurrentRowIndex, FG_EFIG_MC.CurrentColumnIndex].FormattedValue.ToString();
				if (lblCompanyData[0].Text == "")
				{
					// Prompt the user that what they selected is empty
					MessageBox.Show("There is no data to select", "Empty Record Set", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					// turn the delete panel off and exit the sub, so they can pick another selection
					pnlEFIG_Delete.Visible = false;
					return;
				}
				else
				{
					pnlEFIG_Delete.Visible = true;
				}
				FG_EFIG_MC.CurrentColumnIndex = 1;
				lblCompanyData[1].Text = FG_EFIG_MC[FG_EFIG_MC.CurrentRowIndex, FG_EFIG_MC.CurrentColumnIndex].FormattedValue.ToString();
				// RELATED COMPANY
				FG_EFIG_MC.CurrentColumnIndex = 2;
				lblCompanyData[2].Text = FG_EFIG_MC[FG_EFIG_MC.CurrentRowIndex, FG_EFIG_MC.CurrentColumnIndex].FormattedValue.ToString();
				// RELATED COMPANY ID
				FG_EFIG_MC.CurrentColumnIndex = 3;
				lblCompanyData[5].Text = FG_EFIG_MC[FG_EFIG_MC.CurrentRowIndex, FG_EFIG_MC.CurrentColumnIndex].FormattedValue.ToString();
			}
			catch
			{
				modAdminCommon.Report_Error("Financial Groups: FG_EFIG_MC_Click()");
				return;
			}
		}

		private void FG_EFIG_NIOL_Click(Object eventSender, EventArgs eventArgs)
		{
			// set the 1st column and get the text from it that theuser clicked
			FG_EFIG_NIOL.CurrentColumnIndex = 0;
			lblNIOL_CompanyData[0].Text = FG_EFIG_NIOL[FG_EFIG_NIOL.CurrentRowIndex, FG_EFIG_NIOL.CurrentColumnIndex].FormattedValue.ToString();
			// evaluate if the text is blank if so prompt the user and ext the sub, if not set the rest of the labels
			string Query = "";
			ADORecordSetHelper RS_Table = null;
			if (lblNIOL_CompanyData[0].Text == "")
			{
				MessageBox.Show("There is no data to select", "Empty Record Set", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			else
			{
				// set the labels so they are visible and the combobox
				lblNIOL_CompanyData[0].Visible = true;
				lblNIOL_CompanyData[1].Visible = true;
				lblNIOL_CompanyData[2].Visible = true;
				lblNIOL_CompanyData[3].Visible = true;
				lblNIOL_CompanyData[4].Visible = true;
				lblNIOL_CompanyData[14].Visible = true;
				lblNIOL_CompanyData[15].Visible = true;
				lblNIOL_CompanyData[16].Visible = true;
				lblNIOL_CompanyData[17].Visible = true;
				lblNIOL_CompanyData[18].Visible = true;
				lblNIOL_CompanyData[25].Visible = true;
				cmd_Add_Parent_pnlEFIG_NIOL.Visible = true;
				cboNIOL_Associate.Visible = true;
				cboNIOL_Associate.Text = "";
				FG_EFIG_NIOL.CurrentColumnIndex = 1;
				lblNIOL_CompanyData[1].Text = FG_EFIG_NIOL[FG_EFIG_NIOL.CurrentRowIndex, FG_EFIG_NIOL.CurrentColumnIndex].FormattedValue.ToString();
				FG_EFIG_NIOL.CurrentColumnIndex = 2;
				lblNIOL_CompanyData[2].Text = FG_EFIG_NIOL[FG_EFIG_NIOL.CurrentRowIndex, FG_EFIG_NIOL.CurrentColumnIndex].FormattedValue.ToString();
				FG_EFIG_NIOL.CurrentColumnIndex = 3;
				lblNIOL_CompanyData[3].Text = FG_EFIG_NIOL[FG_EFIG_NIOL.CurrentRowIndex, FG_EFIG_NIOL.CurrentColumnIndex].FormattedValue.ToString();
				FG_EFIG_NIOL.CurrentColumnIndex = 4;
				lblNIOL_CompanyData[4].Text = FG_EFIG_NIOL[FG_EFIG_NIOL.CurrentRowIndex, FG_EFIG_NIOL.CurrentColumnIndex].FormattedValue.ToString();
				// populate the combobox for user selection
				Query = "select fipg_generic_name, fipg_main_comp_id ";
				Query = $"{Query}from Financial_Institution_Primary_Group ";
				Query = $"{Query}order by fipg_generic_name, fipg_main_comp_id";

				//Call RS_Table.Open(Query, LOCAL_ADO_DB, adOpenForwardOnly, adLockOptimistic, adCmdText)
				RS_Table = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

				//If Not IsNull(RS_Table) And (RS_Table.EOF And RS_Table.BOF) Then
				if (!(RS_Table.EOF && RS_Table.BOF))
				{
					RS_Table.MoveFirst();

					while(!RS_Table.EOF)
					{
						cboNIOL_Associate.AddItem(Convert.ToString(RS_Table["fipg_generic_name"]));
						cboNIOL_Associate.SetItemData(cboNIOL_Associate.GetNewIndex(), Convert.ToInt32(RS_Table["fipg_main_comp_id"]));
						RS_Table.MoveNext();
					};
					RS_Table.Close();
					// cboNIOL_Associate.ListIndex = 0
				} // If Not (RS_Table.EOF And RS_Table.BOF) Then
			} // If lblNIOL_CompanyData(0).Caption = "" Then
		}

		private void FG_FracPrograms_Click(Object eventSender, EventArgs eventArgs)
		{

			pnl_add_frac_Program.Visible = true;
			FG_FracPrograms.CurrentColumnIndex = 0;
			txtFracProg_id.Text = FG_FracPrograms[FG_FracPrograms.CurrentRowIndex, FG_FracPrograms.CurrentColumnIndex].FormattedValue.ToString();
			FG_FracPrograms.CurrentColumnIndex = 1;
			txt_FracPG_name.Text = FG_FracPrograms[FG_FracPrograms.CurrentRowIndex, FG_FracPrograms.CurrentColumnIndex].FormattedValue.ToString();
			FG_FracPrograms.CurrentColumnIndex = 2;
			txt_fracPG_desc.Text = FG_FracPrograms[FG_FracPrograms.CurrentRowIndex, FG_FracPrograms.CurrentColumnIndex].FormattedValue.ToString();
			FG_FracPrograms.CurrentColumnIndex = 3;
			txt_fracPG_code.Text = FG_FracPrograms[FG_FracPrograms.CurrentRowIndex, FG_FracPrograms.CurrentColumnIndex].FormattedValue.ToString();
			FG_FracPrograms.CurrentColumnIndex = 4;
			chk_active_fracpg.CheckState = (FG_FracPrograms[FG_FracPrograms.CurrentRowIndex, FG_FracPrograms.CurrentColumnIndex].FormattedValue.ToString() == "N") ? CheckState.Unchecked : CheckState.Checked;
			FG_FracPrograms.CurrentColumnIndex = 5;
			chk_major_fracPG.CheckState = (FG_FracPrograms[FG_FracPrograms.CurrentRowIndex, FG_FracPrograms.CurrentColumnIndex].FormattedValue.ToString() == "N") ? CheckState.Unchecked : CheckState.Checked;
			FG_FracPrograms.CurrentColumnIndex = 6;
			txt_FracCompID.Text = FG_FracPrograms[FG_FracPrograms.CurrentRowIndex, FG_FracPrograms.CurrentColumnIndex].FormattedValue.ToString();
			FG_FracPrograms.CurrentColumnIndex = 7;
			txt_FracProgramProvider.Text = FG_FracPrograms[FG_FracPrograms.CurrentRowIndex, FG_FracPrograms.CurrentColumnIndex].FormattedValue.ToString();
			RecordStat = "Update";

			if (StringsHelper.ToDoubleSafe(txtFracProg_id.Text) == 44)
			{ //protect Other
				pnl_add_frac_Program.Visible = false;
			}
		}

		private void FG_Language_Click(Object eventSender, EventArgs eventArgs)
		{
			//Modify or delete data row

			pnl_Language_AddUpdate.Visible = true;
			RecordStat = "Update";
			txt_language_name.Enabled = true;
			txt_language_name.Text = FG_Language[FG_Language.CurrentRowIndex, FG_Language.CurrentColumnIndex].FormattedValue.ToString();
			cmd_Save_Language.Enabled = true;
		}

		private void FG_Phone_Type_Click(Object eventSender, EventArgs eventArgs)
		{
			//aey 4/9/04
			FG_Phone_Type.CurrentColumnIndex = 0;
			txt_ptype_name.Text = ($"{FG_Phone_Type[FG_Phone_Type.CurrentRowIndex, FG_Phone_Type.CurrentColumnIndex].FormattedValue.ToString()}").Trim();
			txt_ptype_name.ReadOnly = true;
			FG_Phone_Type.CurrentColumnIndex = 1;
			txt_ptype_seq_no.Text = ($"{FG_Phone_Type[FG_Phone_Type.CurrentRowIndex, FG_Phone_Type.CurrentColumnIndex].FormattedValue.ToString()}").Trim();
			FG_Phone_Type.CurrentColumnIndex = 2;
			txt_ptype_abbrev.Text = ($"{FG_Phone_Type[FG_Phone_Type.CurrentRowIndex, FG_Phone_Type.CurrentColumnIndex].FormattedValue.ToString()}").Trim();
			RecordStat = "Update";
			pnl_PT_AddUpdate.Visible = true;

		}

		private void FG_ProgCompany_Click(Object eventSender, EventArgs eventArgs)
		{
			RecordStat = "Update";
			pnl_new_FracMember.Visible = false;
			pnl_add_fracMember.Visible = true;
			cmdFracMemDelete.Visible = true;

			FG_ProgCompany.CurrentColumnIndex = 0;
			txtfracMemberName.Text = $"{FG_ProgCompany[FG_ProgCompany.CurrentRowIndex, FG_ProgCompany.CurrentColumnIndex].FormattedValue.ToString()}";
			FG_ProgCompany.CurrentColumnIndex = 1;
			txtfracMemberID.Text = $"{FG_ProgCompany[FG_ProgCompany.CurrentRowIndex, FG_ProgCompany.CurrentColumnIndex].FormattedValue.ToString()}";
			FG_ProgCompany.CurrentColumnIndex = 3;
			txtRefid.Text = $"{FG_ProgCompany[FG_ProgCompany.CurrentRowIndex, FG_ProgCompany.CurrentColumnIndex].FormattedValue.ToString()}";


		}

		private void FG_Region_Click(Object eventSender, EventArgs eventArgs)
		{


			int lRow1 = FG_Region.MouseRow;

			if (lRow1 > 0)
			{

				modAdminCommon.Highlight_Grid_Row(FG_Region, 0);

				txtRegionName.Text = Convert.ToString(FG_Region[lRow1, 0].Value);
				txtRegionSourceURL.Text = Convert.ToString(FG_Region[lRow1, 1].Value);

			} // If lRow1 > 0 Then

		} // FG_Region_Click

		private void FG_State_Click(Object eventSender, EventArgs eventArgs)
		{
			//aey 4/19/2004

			FG_State.CurrentColumnIndex = 0;
			txt_state_code.Text = FG_State[FG_State.CurrentRowIndex, FG_State.CurrentColumnIndex].FormattedValue.ToString();
			FG_State.CurrentColumnIndex = 1;
			txt_state_name.Text = FG_State[FG_State.CurrentRowIndex, FG_State.CurrentColumnIndex].FormattedValue.ToString();
			FG_State.CurrentColumnIndex = 2;
			txt_state_loc.Text = FG_State[FG_State.CurrentRowIndex, FG_State.CurrentColumnIndex].FormattedValue.ToString();
			FG_State.CurrentColumnIndex = 3;
			//txt_state_timezone = FG_State.Text
			modAdminCommon.SetComboBox(CMB_State_TimeZone, FG_State[FG_State.CurrentRowIndex, FG_State.CurrentColumnIndex].FormattedValue.ToString());
			FG_State.CurrentColumnIndex = 4;
			modAdminCommon.SetComboBox(cmb_state_country, FG_State[FG_State.CurrentRowIndex, FG_State.CurrentColumnIndex].FormattedValue.ToString());
			//UPGRADE_ISSUE: (2064) ComboBox property cmb_state_country.Locked was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			cmb_state_country.setLocked(false);
			FG_State.CurrentColumnIndex = 5;
			state_active_flag.CheckState = CheckState.Checked;
			if (FG_State[FG_State.CurrentRowIndex, FG_State.CurrentColumnIndex].FormattedValue.ToString() == "No")
			{
				state_active_flag.CheckState = CheckState.Unchecked;
			}
			Application.DoEvents();
			RecordStat = "Update";
			pnl_State_AddUpdate.Visible = true;
			txt_state_code.Focus();
		}

		private void FG_TimeZone_Click(Object eventSender, EventArgs eventArgs)
		{

			RecordStat = "Update";
			FG_TimeZone.CurrentColumnIndex = 0;
			txt_tzone_name.Text = FG_TimeZone[FG_TimeZone.CurrentRowIndex, FG_TimeZone.CurrentColumnIndex].FormattedValue.ToString();
			FG_TimeZone.CurrentColumnIndex = 1;
			txt_tzone_sort_num.Text = FG_TimeZone[FG_TimeZone.CurrentRowIndex, FG_TimeZone.CurrentColumnIndex].FormattedValue.ToString();
			FG_TimeZone.CurrentColumnIndex = 2;
			txt_tzone_time_vs_eastern.Text = FG_TimeZone[FG_TimeZone.CurrentRowIndex, FG_TimeZone.CurrentColumnIndex].FormattedValue.ToString();
			txt_tzone_name.ReadOnly = true;
			pnl_TZ_AddUpdate.Visible = true;

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
		private void Form_Load()
		{

			modStatusBar.Clear_Status_Bar(modAdminCommon.SB);

			Is_Dirty = false;
			modAdminCommon.gIsRegionDirty = false;
			SSTabHelper.SetSelectedIndex(tab_Lookup, modAdminCommon.iTabCompanyAccountType);

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
				if (modAdminCommon.gIsRegionDirty)
				{
					modAdminCommon.Table_Action_Log("Region");
					modAdminCommon.gIsRegionDirty = false;
				}
			}
			finally
			{
				eventArgs.Cancel = Cancel != 0;
			}
		}

		private void frmRegion_Click(Object eventSender, EventArgs eventArgs)
		{


			string strCaption = lblLoadingRegion.Text;
			modExcel.ExportMSHFlexGrid(FG_Region, lblLoadingRegion);
			lblLoadingRegion.Text = strCaption;

		}

		private void grd_RelatedCompanies_Click(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				pnl_AddFinGroup.Visible = false;

				grd_RelatedCompanies.CurrentColumnIndex = 3;
				txtViewOther[2].Text = grd_RelatedCompanies[grd_RelatedCompanies.CurrentRowIndex, grd_RelatedCompanies.CurrentColumnIndex].FormattedValue.ToString();

				grd_RelatedCompanies.CurrentColumnIndex = 0;
				lblCompanyData[0].Text = grd_RelatedCompanies[grd_RelatedCompanies.CurrentRowIndex, grd_RelatedCompanies.CurrentColumnIndex].FormattedValue.ToString();
				if (lblCompanyData[0].Text == "")
				{
					// Prompt the user that what they selected is empty
					MessageBox.Show("There is no data to select", "Empty Record Set", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					// turn the delete panel off and exit the sub, so they can pick another selection
					pnlEFIG_Delete.Visible = false;
					return;
				}
				else
				{
					// turn the EFIG panel off and turn the Delte panel on
					//pnl_EFIG.Visible = False
					pnlEFIG_Delete.Visible = false;
				}


				grd_RelatedCompanies.CurrentColumnIndex = 1;
				lblCompanyData[1].Text = grd_RelatedCompanies[grd_RelatedCompanies.CurrentRowIndex, grd_RelatedCompanies.CurrentColumnIndex].FormattedValue.ToString();


				// added in MSW -
				int MoveCbo = 0;
				int I = 0;
				string FinComboSelect = "";
				MoveCbo = 0;
				I = 0;
				if (cboEFIG_SelectGroup[I].Text == "All")
				{
					int tempForEndVar = cboEFIG_SelectGroup[0].Items.Count - 1;
					for (I = 0; I <= tempForEndVar; I++)
					{
						FinComboSelect = cboEFIG_SelectGroup[0].GetItemData(I).ToString();
						// FinComboSelect = cboEFIG_SelectGroup(I).

						if (FinComboSelect.Trim() == grd_RelatedCompanies[grd_RelatedCompanies.CurrentRowIndex, grd_RelatedCompanies.CurrentColumnIndex].FormattedValue.ToString())
						{
							cboAdd_Comp_Ref.SelectedIndex = I - 1;
							I = cboEFIG_SelectGroup[0].Items.Count;
						}

						//  FinComboSelect = cboEFIG_SelectGroup.Item(I).Text
					}
				}



				// RELATED COMPANY
				grd_RelatedCompanies.CurrentColumnIndex = 2;
				lblCompanyData[2].Text = grd_RelatedCompanies[grd_RelatedCompanies.CurrentRowIndex, grd_RelatedCompanies.CurrentColumnIndex].FormattedValue.ToString();
				// RELATED COMPANY ID
				grd_RelatedCompanies.CurrentColumnIndex = 3;
				lblCompanyData[5].Text = grd_RelatedCompanies[grd_RelatedCompanies.CurrentRowIndex, grd_RelatedCompanies.CurrentColumnIndex].FormattedValue.ToString();
				pnl_AddFinGroup.Visible = true;
			}
			catch
			{
				modAdminCommon.Report_Error("Financial Groups: grd_RelatedCompanies_Click()");
				return;
			}

		}

		private void grd_titles_in_group_Click(Object eventSender, EventArgs eventArgs)
		{

			frm_update_group.Visible = false;
			cmd_contact_button[8].Visible = true;


			txt_contact_title_search[3].Visible = true;
			txt_contact_title_search[3].Height = 73;
			txt_contact_title_search[3].Left = 8;
			txt_contact_title_search[3].Top = 48;
			txt_contact_title_search[3].Width = 553;


		}

		private void grd_titles_in_group_DoubleClick(Object eventSender, EventArgs eventArgs)
		{

			grd_titles_in_group.CurrentColumnIndex = 0;
			txt_contact_title_search[0].Text = grd_titles_in_group[grd_titles_in_group.CurrentRowIndex, grd_titles_in_group.CurrentColumnIndex].FormattedValue.ToString();
			cmd_contact_button_Click(cmd_contact_button[0], new EventArgs()); // clicking search


		}


		private void grdMemSearch_Click(Object eventSender, EventArgs eventArgs)
		{
			pnl_add_fracMember.Visible = true;
			RecordStat = "Add";
			grdMemSearch.CurrentColumnIndex = 0;
			txtfracMemberID.Text = grdMemSearch[grdMemSearch.CurrentRowIndex, grdMemSearch.CurrentColumnIndex].FormattedValue.ToString();
			grdMemSearch.CurrentColumnIndex = 1;
			txtfracMemberName.Text = grdMemSearch[grdMemSearch.CurrentRowIndex, grdMemSearch.CurrentColumnIndex].FormattedValue.ToString();
			cmdFracMemDelete.Visible = false;


		}



		private void Label1_Click(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.Label1, eventSender);


			string strURL = "";


			if (Index == 26)
			{
				strURL = "http://www.nationsonline.org/oneworld/country_code_list.htm";
				modAdminCommon.OpenURLInBrowser(strURL);
			} // If Index = 26 Then

			if (Index == 49)
			{
				strURL = txtRegionSourceURL.Text.Trim();
				if (strURL != "")
				{
					modAdminCommon.OpenURLInBrowser(strURL);
				}
			}

		}


		private void lblStopTitleLoad_Click(Object eventSender, EventArgs eventArgs)
		{
			lblStopTitleLoad[0].Visible = false;
			lblStopTitleLoad[1].Visible = false;
		}


		private void lstAllBusType_SelectedIndexChanged(Object eventSender, EventArgs eventArgs) => cmdAddBusGroup_Click(cmdAddBusGroup, new EventArgs());





		private void lstBusType_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{

			cmdRemoveBusGroup_Click(cmdRemoveBusGroup, new EventArgs());
			Is_Dirty = true;

		}

		private void lstTitleGroup_DoubleClick(Object eventSender, EventArgs eventArgs)
		{

			cmd_contact_button_Click(cmd_contact_button[4], new EventArgs());
			Is_Dirty = true;

		}


		public void mnuFileClose_Click(Object eventSender, EventArgs eventArgs)
		{
			if (bolTAL)
			{
				modAdminCommon.Table_Action_Log("Financial_Institution_Company_Reference");
				modAdminCommon.Table_Action_Log("Financial_Institution_Primary_Group");
			}
			else if (bolTAL_SIC)
			{ 
				modAdminCommon.Table_Action_Log("Company_SIC_Codes");
			}
			//frm_Administration.Show
			this.Close();

		}

		public void mnuFileLogout_Click(Object eventSender, EventArgs eventArgs)
		{
			if (bolTAL)
			{
				modAdminCommon.Table_Action_Log("Financial_Institution_Company_Reference");
				modAdminCommon.Table_Action_Log("Financial_Institution_Primary_Group");
			}
			else if (bolTAL_SIC)
			{ 
				modAdminCommon.Table_Action_Log("Company_SIC_Codes");
			}
			Environment.Exit(0);

		}

		private bool isInitializingComponent;
		private void opt_contact_title_CheckedChanged(Object eventSender, EventArgs eventArgs)
		{
			if (((RadioButton) eventSender).Checked)
			{
				if (isInitializingComponent)
				{
					return;
				}

				Fill_Contact_Title_List_From_Group();

			}
		}

		private void state_active_flag_Validating(Object eventSender, CancelEventArgs eventArgs)
		{
			bool Cancel = eventArgs.Cancel;
			try
			{
				//6/28/04 aey
				string Query = "";

				if (state_active_flag.CheckState == CheckState.Unchecked)
				{
					Query = $"select comp_id from company where comp_state ='{($"{txt_state_code.Text}").Trim()}' ";
					Query = $"{Query}and comp_journ_id=0 and comp_active_flag='Y'";

					if (cmb_state_country.Text.Trim() != "")
					{
						Query = $"{Query}and comp_country = '{cmb_state_country.Text.Trim()}' ";
					}


					if (modAdminCommon.Exist(Query))
					{
						MessageBox.Show("This state code is being used by an active company, cannot make inactive.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						state_active_flag.CheckState = CheckState.Checked;
						Cancel = true;
						return;
					}

				}
			}
			finally
			{
				eventArgs.Cancel = Cancel;
			}


		}


		private void tab_Lists_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{


			int FinComboSelect = 0;
			// -----------------------------------------------------------
			// GET A LIST OF COMPANIES RELATED TO THE PRIMARY FINANCIAL GROUP
			// THAT ARE ADDITIONAL LOCATIONS OR SUBSIDARIES AND MAY HAVE DOCUMENTS.
			if (SSTabHelper.GetSelectedIndex(tab_Lists) == 1)
			{
				// aSelection = cboEFIG_SelectGroup(Index).ItemData(cboEFIG_SelectGroup(Index).ListIndex)
				FinComboSelect = 0;

				FinComboSelect = cboEFIG_SelectGroup[0].GetItemData(cboEFIG_SelectGroup[0].SelectedIndex);

				Get_Financial_Group_Unrelated_Companies(FinComboSelect);
			}

			tab_ListsPreviousTab = tab_Lists.SelectedIndex;
		}

		private void Load_Country_Grid_Headers()
		{

			int lRow1 = 0;
			int lCol1 = 0;


			FG_Country.Clear();

			FG_Country.RowsCount = 2;
			FG_Country.ColumnsCount = 11;
			FG_Country.FixedRows = 1;
			FG_Country.FixedColumns = 0;

			lRow1 = 1;
			FG_Country.CurrentRowIndex = lRow1;

			lCol1 = -1;

			lCol1++;
			FG_Country.CurrentColumnIndex = lCol1;
			FG_Country.SetColumnWidth(lCol1, 53);
			FG_Country[lRow1, lCol1].Value = "Code";

			lCol1++;
			FG_Country.CurrentColumnIndex = lCol1;
			FG_Country.SetColumnWidth(lCol1, 200);
			FG_Country[lRow1, lCol1].Value = "Name";

			lCol1++;
			FG_Country.CurrentColumnIndex = lCol1;
			FG_Country.SetColumnWidth(lCol1, 133);
			FG_Country[lRow1, lCol1].Value = "Language";

			lCol1++;
			FG_Country.CurrentColumnIndex = lCol1;
			FG_Country.SetColumnWidth(lCol1, 0);
			FG_Country[lRow1, lCol1].Value = "Time VS Eastern";

			lCol1++;
			FG_Country.CurrentColumnIndex = lCol1;
			FG_Country.SetColumnWidth(lCol1, 67);
			FG_Country[lRow1, lCol1].Value = "Currency";

			lCol1++;
			FG_Country.CurrentColumnIndex = lCol1;
			FG_Country.SetColumnWidth(lCol1, 0);
			FG_Country[lRow1, lCol1].Value = "intAccessCode";

			lCol1++;
			FG_Country.CurrentColumnIndex = lCol1;
			FG_Country.SetColumnWidth(lCol1, 0);
			FG_Country[lRow1, lCol1].Value = "abbrev";

			lCol1++;
			FG_Country.CurrentColumnIndex = lCol1;
			FG_Country.SetColumnWidth(lCol1, 0);
			FG_Country[lRow1, lCol1].Value = "regNBRPrefix";

			lCol1++;
			FG_Country.CurrentColumnIndex = lCol1;
			FG_Country.SetColumnWidth(lCol1, 0);
			FG_Country[lRow1, lCol1].Value = "ContinentName";

			lCol1++;
			FG_Country.CurrentColumnIndex = lCol1;
			FG_Country.SetColumnWidth(lCol1, 0);
			FG_Country[lRow1, lCol1].Value = "CityCode";

			lCol1++;
			FG_Country.CurrentColumnIndex = lCol1;
			FG_Country.SetColumnWidth(lCol1, 0);
			FG_Country[lRow1, lCol1].Value = "LineAccessCode";
			 // FG_Country

		} // Load_Country_Grid_Headers

		private void Load_Country_Grid()
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			int lRow1 = 0;
			int lCol1 = 0;

			FG_Country.Enabled = false;
			txt_country_name.ReadOnly = true;
			cmd_Delete_Country.Enabled = false;

			if (modAdminCommon.gbl_User_ID.ToLower() == "mvit" || modAdminCommon.gbl_User_ID.ToLower() == "dcr")
			{
				txt_country_name.ReadOnly = false;
				cmd_Delete_Country.Enabled = true;
			}

			pnl_Country_AddUpdate.Visible = false;

			Load_Country_Grid_Headers();

			string strQuery1 = "SELECT * from Country ORDER BY Country_name ";

			rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

			if (!rstRec1.BOF && !rstRec1.EOF)
			{

				lRow1 = 0;

				FG_Country.Redraw = false;

				do 
				{


					lRow1++;
					lCol1 = -1;

					FG_Country.RowsCount = lRow1 + 1;
					FG_Country.CurrentRowIndex = lRow1;

					lCol1++;
					FG_Country[lRow1, lCol1].Value = ($"{Convert.ToString(rstRec1["Country_code"])} ").Trim();

					lCol1++;
					FG_Country[lRow1, lCol1].Value = ($"{Convert.ToString(rstRec1["country_name"])} ").Trim();

					lCol1++;
					FG_Country[lRow1, lCol1].Value = ($"{Convert.ToString(rstRec1["Country_language"])} ").Trim();

					lCol1++;
					FG_Country[lRow1, lCol1].Value = ($"{Convert.ToString(rstRec1["Country_time_vs_eastern"])} ").Trim();

					lCol1++;
					FG_Country[lRow1, lCol1].Value = ($"{Convert.ToString(rstRec1["Country_currency"])} ").Trim();

					lCol1++;
					FG_Country[lRow1, lCol1].Value = ($"{Convert.ToString(rstRec1["Country_int_access_code"])} ").Trim();

					lCol1++;
					FG_Country[lRow1, lCol1].Value = ($"{Convert.ToString(rstRec1["country_abbrev"])}").Trim();

					lCol1++;
					FG_Country[lRow1, lCol1].Value = ($"{Convert.ToString(rstRec1["country_continent_name"])}").Trim();

					lCol1++;
					FG_Country[lRow1, lCol1].Value = ($"{Convert.ToString(rstRec1["country_city_code"])}").Trim();

					lCol1++;
					FG_Country[lRow1, lCol1].Value = ($"{Convert.ToString(rstRec1["country_active_flag"])}").Trim();

					lCol1++;
					FG_Country[lRow1, lCol1].Value = ($"{Convert.ToString(rstRec1["country_line_access_code"])}").Trim();

					if (lRow1 == 22)
					{
						FG_Country.Redraw = true;
						FG_Country.Refresh();
						Application.DoEvents();
						FG_Country.Redraw = false;
					}
					 // With FG_Country

					rstRec1.MoveNext();

				}
				while(!rstRec1.EOF);

				FG_Country.Redraw = true;
				FG_Country.Enabled = true;

			} // If rstRec1.BOF = False And rstRec1.EOF = False Then

			rstRec1.Close();
			rstRec1 = null;

			return;



			modAdminCommon.Record_Error("Load_Country_Grid_Error", Information.Err().Description);

		} // Load_Country_Grid

		private void tab_Lookup_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{
			//Common Processing for tabs  aey 4/2004

			int NewTab = 0; //Current tab
			string Query = ""; //Current query sql
			ADORecordSetHelper RS_Table = new ADORecordSetHelper(); //Current recordset
			string FLDS = ""; //work fields for query string
			string VALS = ""; //value work fields for query string
			string Comma = ""; //comma work field for query string
			int nRow = 0; //Current row counter
			int Ans = 0; //Answer to question
            DataGridViewFlex Grd = null;

			try
			{

				this.Cursor = Cursors.WaitCursor;


				Fin_Initial_Load = false;

				NewTab = SSTabHelper.GetSelectedIndex(tab_Lookup); //note tabs are zero (0) based
				 //mark tables to be copied to web server

				switch(tab_LookupPreviousTab)
				{
					case modAdminCommon.iTabCompanyAccountType :  // Company Account Type 
						break;
					case modAdminCommon.iTabCompanyAgencyType :  // Company Agency Type 
						modAdminCommon.Table_Action_Log("Company_Agency_Type"); 
						break;
					case modAdminCommon.iTabCompanyBusinessType :  // Company business type 
						modAdminCommon.Table_Action_Log("Company_Business_Type"); 
						modAdminCommon.Table_Action_Log("Company_Business_Type_Group_Reference"); 
						modAdminCommon.Table_Action_Log("Company_Business_Type_Group"); 
						break;
					case modAdminCommon.iTabCountry :  // Country 
						modAdminCommon.Table_Action_Log("Country"); 
						break;
					case modAdminCommon.iTabLanguage :  // Language 
						break;
					case modAdminCommon.iTabCurrency :  // Currency 
						modAdminCommon.Table_Action_Log("Currency"); 
						break;
					case modAdminCommon.iTabContactSirname :  // Contact Surname 
						break;
					case modAdminCommon.iTabContactSuffix :  // Contact Suffix 
						break;
					case modAdminCommon.iTabContactTitle :  // Contact Title 
						modAdminCommon.Table_Action_Log("Contact_Title"); 
						modAdminCommon.Table_Action_Log("Contact_Title_Group_Reference"); 
						break;
					case modAdminCommon.iTabPhoneType :  // Phone Type 
						modAdminCommon.Table_Action_Log("Phone_Type"); 
						break;
					case modAdminCommon.iTabState :  // State 
						modAdminCommon.Table_Action_Log("State"); 
						break;
					case modAdminCommon.iTabTimeZone :  // TimeZone 
						modAdminCommon.Table_Action_Log("Timezone"); 
						break;
					case modAdminCommon.iTabFractionalPrograms :  // Fractional Programs 
						break;
					case modAdminCommon.iTabFracProgramMembers :  // Fractional Program Members 
						break;
					case modAdminCommon.iTabFinancialGroups :  // Financial Groups 
						 
						break;
					case modAdminCommon.iTabCompanyIndustryCodes :  // Company Industry Codes 
						break;
					case modAdminCommon.iTabRegion :  // Region 
						modAdminCommon.Table_Action_Log("Region"); 
						break;
					default:
						 
						break;
				}

				Application.DoEvents();

				string search_string = "";
				switch(NewTab)
				{
					case modAdminCommon.iTabCompanyAccountType :  //Company Account Type 
						pnl_CAT_AddUpdate.Visible = false; 
						FG_Cat_List.Clear(); 
						Query = "SELECT * from Company_Account_Type "; 
						Query = $"{Query} ORDER BY cacctype_code "; 
						RS_Table.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic); 
						 
						if (!(RS_Table.BOF && RS_Table.EOF))
						{
							FG_Cat_List.CurrentColumnIndex = 0;
							FG_Cat_List.CurrentRowIndex = 0;
							FG_Cat_List[FG_Cat_List.CurrentRowIndex, FG_Cat_List.CurrentColumnIndex].Value = "Code";
							FG_Cat_List.CurrentColumnIndex = 1;
							FG_Cat_List[FG_Cat_List.CurrentRowIndex, FG_Cat_List.CurrentColumnIndex].Value = "Name";
							FG_Cat_List.SetColumnWidth(0, 67);
							FG_Cat_List.SetColumnWidth(1, 200);

							nRow = 1;
							FG_Cat_List.CurrentRowIndex = nRow;
							RS_Table.MoveFirst();

							while(!RS_Table.EOF)
							{
								FG_Cat_List.CurrentColumnIndex = 0;
								FG_Cat_List[FG_Cat_List.CurrentRowIndex, FG_Cat_List.CurrentColumnIndex].Value = ($"{Convert.ToString(RS_Table["cacctype_code"])} ").Trim();
								FG_Cat_List.CurrentColumnIndex = 1;
								FG_Cat_List[FG_Cat_List.CurrentRowIndex, FG_Cat_List.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote($"{Convert.ToString(RS_Table["cacctype_name"])} ").Trim();
								nRow++;
								FG_Cat_List.RowsCount = nRow + 1;
								FG_Cat_List.CurrentRowIndex = nRow;
								RS_Table.MoveNext();
							}; // Do While Not snp_Cat.EOF

						}  // If Not (snp_Cat.BOF And snp_Cat.EOF) Then 
						RS_Table.Close(); 
						FG_Cat_List.RowsCount--; 
						FG_Cat_List.Refresh(); 

						 
						break;
					case modAdminCommon.iTabCompanyAgencyType :  //Company Agency Type 
						FG_CompAgency.Clear(); 
						pnl_GAT_AddUpdate.Visible = false; 
						Query = "SELECT * from Company_Agency_Type ORDER BY cagtype_code "; 
						//Set snp_GAT = LOCAL_DB.OpenRecordset(QUERY, dbOpenSnapshot) 
						RS_Table.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic); 
						FG_CompAgency.CurrentColumnIndex = 0; 
						FG_CompAgency.CurrentRowIndex = 0; 
						FG_CompAgency[FG_CompAgency.CurrentRowIndex, FG_CompAgency.CurrentColumnIndex].Value = "Code"; 
						FG_CompAgency.CurrentColumnIndex = 1; 
						FG_CompAgency[FG_CompAgency.CurrentRowIndex, FG_CompAgency.CurrentColumnIndex].Value = "Name"; 
						FG_CompAgency.SetColumnWidth(0, 67); 
						FG_CompAgency.SetColumnWidth(1, 200); 
						 
						nRow = 1; 
						FG_CompAgency.CurrentRowIndex = nRow; 
						if (!(RS_Table.BOF && RS_Table.EOF))
						{
							RS_Table.MoveFirst();

							while(!RS_Table.EOF)
							{
								FG_CompAgency.CurrentColumnIndex = 0;
								FG_CompAgency[FG_CompAgency.CurrentRowIndex, FG_CompAgency.CurrentColumnIndex].Value = ($"{Convert.ToString(RS_Table["cagtype_code"])} ").Trim();
								FG_CompAgency.CurrentColumnIndex = 1;
								FG_CompAgency[FG_CompAgency.CurrentRowIndex, FG_CompAgency.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote($"{Convert.ToString(RS_Table["cagtype_name"])} ").Trim();
								nRow++;
								FG_CompAgency.RowsCount = nRow + 1;
								FG_CompAgency.CurrentRowIndex = nRow;
								RS_Table.MoveNext();
							};
						} 
						FG_CompAgency.RowsCount--; 
						FG_CompAgency.Refresh(); 
						RS_Table.Close(); 
						 
						break;
					case modAdminCommon.iTabCompanyBusinessType :  //Company Business Type 
						 
						search_string = ""; 
						 
						if (combo_bus_type_dropdown.Text == "All")
						{
							search_string = "";
						}
						else if (combo_bus_type_dropdown.Text == "ABI Only")
						{ 
							search_string = " where cbus_abi_flag ='Y'";
						}
						else if (combo_bus_type_dropdown.Text == "Aviation")
						{ 
							search_string = " where cbus_aircraft_flag ='Y'";
						}
						else if (combo_bus_type_dropdown.Text == "Yacht")
						{ 
							search_string = " where cbus_yacht_flag ='Y'";
						} 
						 
						if (search_string.Trim() == "")
						{
							// MSW 4/20/12 ADDED NEW DROP TO TO SEARCH -LIST INDEX TO 20
							combo_bus_type_dropdown.Items.Clear();
							combo_bus_type_dropdown.AddItem("All");
							combo_bus_type_dropdown.SetItemData(combo_bus_type_dropdown.GetNewIndex(), 0);
							combo_bus_type_dropdown.AddItem("ABI Only");
							combo_bus_type_dropdown.SetItemData(combo_bus_type_dropdown.GetNewIndex(), 1);
							combo_bus_type_dropdown.AddItem("Aviation");
							combo_bus_type_dropdown.SetItemData(combo_bus_type_dropdown.GetNewIndex(), 2);
							combo_bus_type_dropdown.AddItem("Yacht");
							combo_bus_type_dropdown.SetItemData(combo_bus_type_dropdown.GetNewIndex(), 3);
							combo_bus_type_dropdown.SelectedIndex = 0;
						} 

						 
						FG_CBTList.Clear(); 
						FG_CBTList.ColumnsCount = 7; 
						Grd = FG_CBTList; 
						pnl_CBT_AddUpdate.Visible = false; 
						pnl_BusGroup.Visible = false; 
						 
						Query = $"SELECT * from Company_Business_Type {search_string} ORDER BY cbus_type "; 
						 
						RS_Table.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic); 
						 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[0] = 500; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[1] = 2600; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[2] = 500; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[3] = 900; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[4] = 600; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[5] = 1100; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[6] = 1100; 

						 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 0; 
						//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Row = 0; 
						Grd.Text = "Code"; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 1; 
						Grd.Text = "Name"; 
						 
						// ADDED MSW 4/20/12 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 2; 
						Grd.Text = "ABI"; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 3; 
						Grd.Text = "AVIATION"; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 4; 
						Grd.Text = "YACHT"; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 5; 
						Grd.Text = "Desc"; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 6; 
						Grd.Text = "KeyWords"; 
						 
						nRow = 1; 
						//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Row = nRow; 
						 
						if (!(RS_Table.BOF && RS_Table.EOF))
						{
							RS_Table.MoveFirst();

							while(!RS_Table.EOF)
							{
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 0;
								Grd.Text = ($"{Convert.ToString(RS_Table["cbus_type"])} ").Trim();
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 1;
								Grd.Text = modAdminCommon.Fix_Quote($"{Convert.ToString(RS_Table["cbus_name"])} ").Trim();
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 2;
								Grd.Text = ($"{Convert.ToString(RS_Table["cbus_abi_flag"])} ").Trim();
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 3;
								Grd.Text = ($"{Convert.ToString(RS_Table["cbus_aircraft_flag"])} ").Trim();
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 4;
								Grd.Text = ($"{Convert.ToString(RS_Table["cbus_yacht_flag"])} ").Trim();
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 5;
								Grd.Text = ($"{modAdminCommon.Fix_Quote(RS_Table.GetField("cbus_description"))} ").Trim();
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 6;
								Grd.Text = ($"{modAdminCommon.Fix_Quote(RS_Table.GetField("cbus_keywords"))} ").Trim();
								nRow++;
								//UPGRADE_TODO: (1067) Member Rows is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.RowCount = nRow + 1;//gap-note Grd.Rows was changed to GrdRow.RowCount
								//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Row = nRow;
								RS_Table.MoveNext();
							};
						} 
						//UPGRADE_TODO: (1067) Member Rows is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.RowCount = nRow - 1;//gap-note Grd.Rows was changed to GrdRow.RowCount
						FG_CBTList.Refresh(); 
						RS_Table.Close(); 
						 
						break;
					case modAdminCommon.iTabCountry :  //Country 
						 
						Load_Country_Grid(); 
						 
						break;
					case modAdminCommon.iTabLanguage :  //Language 
						 
						FG_Language.Clear(); 
						pnl_Language_AddUpdate.Visible = false; 
						Grd = FG_Language; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 0; 
						//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Row = 0; 
						Grd.Text = "Language Name"; 
						nRow = 1; 
						//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Row = nRow; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[0] = 3000; 
						 
						Query = "SELECT * from Language ORDER BY language_name "; 
						RS_Table.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic); 
						 
						if (!(RS_Table.BOF && RS_Table.EOF))
						{
							RS_Table.MoveFirst();

							while(!RS_Table.EOF)
							{
								Grd.Text = ($"{Convert.ToString(RS_Table["language_name"])}").Trim();
								nRow++;
								//UPGRADE_TODO: (1067) Member Rows is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.RowCount = nRow + 1;//gap-note Grd.Rows was changed to GrdRow.RowCount
								//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Row = nRow;
								RS_Table.MoveNext();
							};
						} 
						//UPGRADE_TODO: (1067) Member Rows is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.RowCount = nRow - 1;//gap-note Grd.Rows was changed to GrdRow.RowCount
						RS_Table.Close(); 
						Grd.Refresh(); 
						 
						break;
					case modAdminCommon.iTabCurrency :  //Currency 
						 
						FG_Currency.Clear(); 
						pnl_Currency_Change.Visible = false; 
						Grd = FG_Currency; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 0; 
						//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Row = 0; 
						Grd.Text = "Currency Name"; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 1; 
						Grd.Text = "Currency Exchange Rate"; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 2; 
						Grd.Text = "Currency Exchange_Rate Date"; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 3; 
						Grd.Text = "Currency Exchange Rate Source"; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 4; 
						Grd.Text = "Currency Country"; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 5; 
						Grd.Text = "Currency ISO"; 
						nRow = 1; 
						//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Row = nRow; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[0] = 1500; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[1] = 1500; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[2] = 2500; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[3] = 1500; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[4] = 1500; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[5] = 1500; 

						 
						Query = "SELECT * from Currency ORDER BY currency_name "; 
						RS_Table.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic); 
						 
						if (!(RS_Table.BOF && RS_Table.EOF))
						{
							RS_Table.MoveFirst();

							while(!RS_Table.EOF)
							{
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 0;
								Grd.Text = ($"{Convert.ToString(RS_Table["currency_name"])}").Trim();
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 1;
								Grd.Text = ($"{Convert.ToString(RS_Table["currency_exchange_rate"])}").Trim();
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 2;
								Grd.Text = ($"{Convert.ToString(RS_Table["currency_exchange_rate_date"])}").Trim();
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 3;
								Grd.Text = ($"{Convert.ToString(RS_Table["currency_exchange_rate_source"])}").Trim();
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 4;
								Grd.Text = ($"{Convert.ToString(RS_Table["currency_country"])}").Trim();
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 5;
								Grd.Text = ($"{Convert.ToString(RS_Table["currency_iso"])}").Trim();
								nRow++;
								//UPGRADE_TODO: (1067) Member Rows is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.RowCount = nRow + 1;//gap-note Grd.Rows was changed to GrdRow.RowCount
								//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Row = nRow;
								RS_Table.MoveNext();
							};
						} 
						RS_Table.Close(); 
						//UPGRADE_TODO: (1067) Member Rows is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.RowCount = nRow - 1;//gap-note Grd.Rows was changed to GrdRow.RowCount
						Grd.Refresh(); 
						 
						Application.DoEvents(); 
						Application.DoEvents(); 
						 
						break;
					case modAdminCommon.iTabContactSirname :  //Contact Surname 
						 
						FG_Contact_SirName.Clear(); 
						pnl_CSN_AddUpdate.Visible = false; 
						Grd = FG_Contact_SirName; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 0; 
						//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Row = 0; 
						Grd.Text = "Contact Sirname"; 
						nRow = 1; 
						//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Row = nRow; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[0] = 3000; 
						 
						Query = "SELECT * from Contact_Sirname ORDER BY csir_name "; 
						RS_Table.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic); 
						 
						if (!(RS_Table.BOF && RS_Table.EOF))
						{
							RS_Table.MoveFirst();

							while(!RS_Table.EOF)
							{
								Grd.Text = ($"{Convert.ToString(RS_Table["csir_name"])}").Trim();
								nRow++;
								//UPGRADE_TODO: (1067) Member Rows is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.RowCount = nRow + 1;//gap-note Grd.Rows was changed to GrdRow.RowCount
								//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Row = nRow;
								RS_Table.MoveNext();
							};
						} 
						RS_Table.Close(); 
						//UPGRADE_TODO: (1067) Member Rows is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.RowCount = nRow - 1;//gap-note Grd.Rows was changed to GrdRow.RowCount
						Grd.Refresh(); 
						 
						break;
					case modAdminCommon.iTabContactSuffix :  //Contact Suffix 
						FG_Contact_Suffix.Clear(); 
						pnl_CS_AddUpdate.Visible = false; 
						Grd = FG_Contact_Suffix; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 0; 
						//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Row = 0; 
						Grd.Text = "Contact Suffix"; 
						nRow = 1; 
						//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Row = nRow; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[0] = 3000; 
						 
						Query = "SELECT * from Contact_Suffix ORDER BY csuffix_name "; 
						RS_Table.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic); 
						 
						if (!(RS_Table.BOF && RS_Table.EOF))
						{
							RS_Table.MoveFirst();

							while(!RS_Table.EOF)
							{
								Grd.Text = ($"{Convert.ToString(RS_Table["csuffix_name"])}").Trim();
								nRow++;
								//UPGRADE_TODO: (1067) Member Rows is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.RowCount = nRow + 1;//gap-note Grd.Rows was changed to GrdRow.RowCount
								//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Row = nRow;
								RS_Table.MoveNext();
							};
						} 
						RS_Table.Close(); 
						//UPGRADE_TODO: (1067) Member Rows is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.RowCount = nRow - 1;//gap-note Grd.Rows was changed to GrdRow.RowCount
						Grd.Refresh(); 
						 
						break;
					case modAdminCommon.iTabContactTitle :  //Contact Title 
						 
						LoadContactTitleGroupComboBox(cboSearchTitleGroup, "N"); 
						LoadContactTitleGroupComboBox(cboTitleNotInGroup, "N"); 
						LoadContactTitleGroupComboBox(cbo_contact_title, "Y"); 
						 
						break;
					case modAdminCommon.iTabPhoneType :  //Phone Type 
						pnl_PT_AddUpdate.Visible = false; 
						Grd = FG_Phone_Type; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 0; 
						//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Row = 0; 
						Grd.Text = "Phone Type"; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 1; 
						Grd.Text = "Seq_No"; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 2; 
						Grd.Text = "Abbrev"; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[0] = 2000; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[1] = 1000; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[2] = 1000; 
						 
						nRow = 1; 
						//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Row = nRow; 
						 
						Query = "SELECT * from Phone_Type ORDER BY ptype_name "; 
						RS_Table.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic); 
						 
						if (!(RS_Table.BOF && RS_Table.EOF))
						{
							RS_Table.MoveFirst();

							while(!RS_Table.EOF)
							{
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 0;
								Grd.Text = ($"{Convert.ToString(RS_Table["ptype_name"])} ").Trim();
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 1;
								Grd.Text = ($"{Convert.ToString(RS_Table["ptype_seq_no"])}").Trim();
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 2;
								Grd.Text = ($"{Convert.ToString(RS_Table["ptype_abbrev"])} ").Trim();
								nRow++;
								//UPGRADE_TODO: (1067) Member Rows is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.RowCount = nRow + 1;//gap-note Grd.Rows was changed to GrdRow.RowCount
								//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Row = nRow;
								RS_Table.MoveNext();
							};
						} 
						RS_Table.Close(); 
						//UPGRADE_TODO: (1067) Member Rows is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.RowCount = nRow - 1;//gap-note Grd.Rows was changed to GrdRow.RowCount
						Grd.Refresh(); 
						 
						break;
					case modAdminCommon.iTabState :  //State 
						 
						pnl_State_AddUpdate.Visible = false; 
						 
						cmb_state_country.Items.Clear(); 
						cmb_state_country.AddItem(""); 
						 
						Query = "SELECT DISTINCT state_country FROM [State] WITH (NOLOCK) WHERE (state_active_flag = 'Y') ORDER BY state_country "; 
						RS_Table.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic); 
						 

						while(!RS_Table.EOF)
						{
							cmb_state_country.AddItem($"{Convert.ToString(RS_Table["state_country"])}");
							RS_Table.MoveNext();
						}; 
						RS_Table.Close(); 

						 
						CMB_State_TimeZone.Items.Clear(); 
						CMB_State_TimeZone.AddItem(""); 
						 
						Query = "SELECT * from Timezone WITH (NOLOCK) ORDER BY tzone_name "; 
						RS_Table.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic); 
						 

						while(!RS_Table.EOF)
						{
							CMB_State_TimeZone.AddItem($"{Convert.ToString(RS_Table["tzone_name"])}");
							RS_Table.MoveNext();
						}; 
						RS_Table.Close(); 
						 
						//fill grid 
						FG_State.Clear(); 
						Grd = FG_State; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 0; 
						//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Row = 0; 
						Grd.Text = "Code"; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 1; 
						Grd.Text = "Name"; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 2; 
						Grd.Text = "Loc"; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 3; 
						Grd.Text = "Timezone"; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 4; 
						Grd.Text = "Country"; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 5; 
						Grd.Text = "Active"; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[0] = 1000; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[1] = 2000; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[2] = 1000; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[3] = 1000; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[4] = 1500; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[5] = 1000; 
						 
						nRow = 1; 
						//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Row = nRow; 
						Query = "SELECT * from State ORDER BY State_name "; 
						RS_Table.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic); 
						 
						if (!(RS_Table.BOF && RS_Table.EOF))
						{
							RS_Table.MoveFirst();

							while(!RS_Table.EOF)
							{
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 0;
								Grd.Text = $"{Convert.ToString(RS_Table["State_code"])}";
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 1;
								Grd.Text = $"{Convert.ToString(RS_Table["State_name"])}";
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 2;
								Grd.Text = $"{Convert.ToString(RS_Table["state_loc"])}";
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 3;
								Grd.Text = $"{Convert.ToString(RS_Table["state_timezone"])}";
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 4;
								Grd.Text = $"{Convert.ToString(RS_Table["state_country"])}";
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 5;
								Grd.Text = (Convert.ToString(RS_Table["state_active_flag"]) == "Y") ? "Yes" : "No";

								nRow++;
								//UPGRADE_TODO: (1067) Member Rows is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.RowCount = nRow + 1;//gap-note Grd.Rows was changed to GrdRow.RowCount
								//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Row = nRow;
								RS_Table.MoveNext();
							};
						} 
						RS_Table.Close(); 
						//UPGRADE_TODO: (1067) Member Rows is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.RowCount = nRow - 1;//gap-note Grd.Rows was changed to GrdRow.RowCount
						Grd.Refresh(); 
						 
						break;
					case modAdminCommon.iTabTimeZone :  //TimeZone 
						pnl_TZ_AddUpdate.Visible = false; 
						FG_TimeZone.Clear(); 
						Grd = FG_TimeZone; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 0; 
						//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Row = 0; 
						Grd.Text = "Zone Name"; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 1; 
						Grd.Text = "Sort Num"; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 2; 
						Grd.Text = "Time vs Eastern"; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[0] = 1000; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[1] = 1000; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[2] = 1500; 
						nRow = 1; 
						//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Row = nRow; 
						 
						Query = "SELECT * from Timezone ORDER BY tzone_name "; 
						RS_Table.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic); 
						 
						if (!(RS_Table.BOF && RS_Table.EOF))
						{
							RS_Table.MoveFirst();

							while(!RS_Table.EOF)
							{
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 0;
								Grd.Text = ($"{Convert.ToString(RS_Table["tzone_name"])} ").Trim();
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 1;
								Grd.Text = ($"{Convert.ToString(RS_Table["tzone_sort_num"])} ").Trim();
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 2;
								Grd.Text = ($"{Convert.ToString(RS_Table["tzone_time_vs_eastern"])} ").Trim();
								nRow++;
								//UPGRADE_TODO: (1067) Member Rows is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.RowCount = nRow + 1;//gap-note Grd.Rows was changed to GrdRow.RowCount
								//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Row = nRow;
								RS_Table.MoveNext();
							};
						} 
						 
						RS_Table.Close(); 
						//UPGRADE_TODO: (1067) Member Rows is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.RowCount = nRow - 1;//gap-note Grd.Rows was changed to GrdRow.RowCount
						Grd.Refresh(); 
						 
						break;
					case modAdminCommon.iTabFractionalPrograms :  //fractional programs 
						pnl_add_frac_Program.Visible = false; 
						FG_FracPrograms.Clear(); 
						FG_FracPrograms.RowsCount = 2; 
						FG_TimeZone.Clear(); 
						Grd = FG_FracPrograms; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 0; 
						//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Row = 0; 
						Grd.Text = "Prog Id"; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 1; 
						Grd.Text = "Fractional Program"; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 2; 
						Grd.Text = "Description"; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 3; 
						Grd.Text = "Code"; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 4; 
						Grd.Text = "Active"; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 5; 
						Grd.Text = "Major"; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 6; 
						Grd.Text = "CompID"; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 7; 
						Grd.Text = "Program Provider"; 

						 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[0] = 650; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[1] = 2000; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[2] = 2000; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[3] = 800; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[4] = 600; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[5] = 600; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[6] = 800; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[7] = 1300; 
						 
						nRow = 1; 
						//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Row = nRow; 
						Query = "SELECT prog_id, prog_name, prog_description, prog_code, prog_active_flag, prog_major_flag, prog_comp_id, comp_name "; 
						Query = $"{Query}from Aircraft_programs left outer join company on prog_comp_id = comp_id and comp_journ_id =0 "; 
						Query = $"{Query}ORDER BY prog_name "; 
						 
						RS_Table.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic); 
						 
						if (!(RS_Table.BOF && RS_Table.EOF))
						{
							RS_Table.MoveFirst();

							while(!RS_Table.EOF)
							{

								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 0;
								Grd.Text = ($"{Convert.ToString(RS_Table["Prog_id"])} ").Trim();
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 1;
								Grd.Text = ($"{Convert.ToString(RS_Table["prog_name"])} ").Trim();
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 2;
								Grd.Text = ($"{Convert.ToString(RS_Table["prog_description"])} ").Trim();
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 3;
								Grd.Text = ($"{Convert.ToString(RS_Table["prog_code"])} ").Trim();
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 4;
								Grd.Text = ($"{Convert.ToString(RS_Table["prog_active_flag"])} ").Trim();
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 5;
								Grd.Text = ($"{Convert.ToString(RS_Table["prog_major_flag"])} ").Trim();
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 6;
								Grd.Text = ($"{Convert.ToString(RS_Table["prog_comp_id"])} ").Trim();
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 7;
								Grd.Text = ($"{Convert.ToString(RS_Table["Comp_Name"])} ").Trim();
								nRow++;
								//UPGRADE_TODO: (1067) Member Rows is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.RowCount = nRow + 1;//gap-note Grd.Rows was changed to GrdRow.RowCount
								//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Row = nRow;
								RS_Table.MoveNext();
							};
						} 
						 
						RS_Table.Close(); 
						//UPGRADE_TODO: (1067) Member Rows is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.RowCount = nRow - 1;//gap-note Grd.Rows was changed to GrdRow.RowCount
						Grd.Refresh(); 
						 
						cboFracToRemove.Items.Clear(); 
						cboFracToKeep.Items.Clear(); 
						cboFracToRemove.AddItem("None Selected"); 
						cboFracToRemove.SetItemData(cboFracToRemove.GetNewIndex(), 0); 
						cboFracToKeep.AddItem("None Selected"); 
						cboFracToKeep.SetItemData(cboFracToKeep.GetNewIndex(), 0); 
						 
						Query = "SELECT prog_id, prog_name, prog_description, prog_code, prog_active_flag, prog_major_flag, prog_comp_id, comp_name "; 
						Query = $"{Query}from Aircraft_programs left outer join company on prog_comp_id = comp_id and comp_journ_id =0 "; 
						Query = $"{Query}ORDER BY prog_name "; 
						 
						RS_Table.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic); 
						 
						if (!(RS_Table.BOF && RS_Table.EOF))
						{
							RS_Table.MoveFirst();

							while(!RS_Table.EOF)
							{
								cboFracToRemove.AddItem($"{StringsHelper.Format(Conversion.Val($"{Convert.ToString(RS_Table["Prog_id"])}"), "000")} {Convert.ToString(RS_Table["prog_name"])}");
								cboFracToRemove.SetItemData(cboFracToRemove.GetNewIndex(), Convert.ToInt32(Conversion.Val($"{Convert.ToString(RS_Table["Prog_id"])}")));
								cboFracToKeep.AddItem($"{StringsHelper.Format(Conversion.Val($"{Convert.ToString(RS_Table["Prog_id"])}"), "000")} {Convert.ToString(RS_Table["prog_name"])}");
								cboFracToKeep.SetItemData(cboFracToKeep.GetNewIndex(), Convert.ToInt32(Conversion.Val($"{Convert.ToString(RS_Table["Prog_id"])}")));
								RS_Table.MoveNext();
							};
						} 
						cboFracToRemove.SelectedIndex = 0; 
						cboFracToKeep.SelectedIndex = 0; 
						RS_Table.Close(); 
						 
						pnl_Merge_Frac_Programs.Visible = false; 
						 
						break;
					case modAdminCommon.iTabFracProgramMembers :  // fractional program members 
						cmdFracProgram.Items.Clear(); 
						cmdFracProgram.AddItem("None Selected"); 
						cmdFracProgram.SetItemData(cmdFracProgram.GetNewIndex(), 0); 
						 
						txtmSearchNumber.Text = ""; 
						txtmsearchname.Text = ""; 
						Query = "SELECT * from Aircraft_programs  ORDER BY prog_name "; 
						RS_Table.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic); 
						 
						if (!(RS_Table.BOF && RS_Table.EOF))
						{
							RS_Table.MoveFirst();

							while(!RS_Table.EOF)
							{
								cmdFracProgram.AddItem($"{StringsHelper.Format(Conversion.Val($"{Convert.ToString(RS_Table["Prog_id"])}"), "000")} {Convert.ToString(RS_Table["prog_name"])}");
								cmdFracProgram.SetItemData(cmdFracProgram.GetNewIndex(), Convert.ToInt32(Conversion.Val($"{Convert.ToString(RS_Table["Prog_id"])}")));
								RS_Table.MoveNext();
							};
						} 
						cmdFracProgram.SelectedIndex = 0; 
						RS_Table.Close(); 
						 
						pnl_new_FracMember.Visible = false; 
						pnl_add_fracMember.Visible = false; 
						cmdAddFracMember.Visible = false; 
						FG_ProgCompany.Visible = false; 
						 
						// ************************************************************ 
						break;
					case modAdminCommon.iTabFinancialGroups :  // Existing Financial Intuition Groups 
						SSTabHelper.SetSelectedIndex(tab_Lists, 0); 
						if (modAdminCommon.gbl_User_ID != "mvit")
						{
							cmd_ASP_dot_Net.Visible = false;
						} 

						 
						Fin_Initial_Load = true; 
						Fill_Financial_Group_Drop_Down(); 
						 
						break;
					case modAdminCommon.iTabCompanyIndustryCodes : 
						Load_Company_SIC_Codes("Load", ""); 
						 
						break;
					case modAdminCommon.iTabRegion : 
						Load_Region_Tab_Grid(); 
						 
						break;
					default:
						 
						break;
				}

				Is_Dirty = false;
				this.Cursor = CursorHelper.CursorDefault;
				Application.DoEvents();
			}
			catch
			{
				this.Cursor = CursorHelper.CursorDefault;
				Is_Dirty = false;
				modAdminCommon.Report_Error($"CompanyContact Tab Error, Tab:{Conversion.Str(NewTab)}");
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

		private void txtFG_PID_TextChanged(Object eventSender, EventArgs eventArgs)
		{
			if (txtFG_PID.Text != "")
			{
				if (!Information.IsNumeric(txtFG_PID.Text))
				{
					MessageBox.Show("Please Enter A Number for the Primary ID", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}
			}
		}

		private void txt_csir_name_Leave(Object eventSender, EventArgs eventArgs)
		{
			if (Strings.Len(($"{txt_csir_name.Text}").Trim()) > 10)
			{
				MessageBox.Show("The entered Sir Name is more than 10 Characters", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}


		private void txt_FracPG_name_Leave(Object eventSender, EventArgs eventArgs)
		{
			//generate a default code, if none exists
			if (Strings.Len(($"{txt_fracPG_code.Text}").Trim()) == 0)
			{
				txt_fracPG_code.Text = ($"{txt_FracPG_name.Text}").Substring(0, Math.Min(4, ($"{txt_FracPG_name.Text}").Length)).ToUpper();
			}

		}

		private void txt_state_code_Leave(Object eventSender, EventArgs eventArgs) => txt_state_code.Text = ($"{txt_state_code.Text}").ToUpper();


		private void txtmsearchname_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				txtmSearchNumber.Text = "";
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}

		private void txtmSearchNumber_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{
				txtmsearchname.Text = "";
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

		private void Fill_FG_EFIG_MC(bool overload, string aSelection)
		{
			ADORecordSetHelper RS_Table = new ADORecordSetHelper();
			FG_EFIG_MC.Clear();
			FG_EFIG_MC.ColumnsCount = 7;
			FG_EFIG_MC.RowsCount = 2;
			FG_EFIG_MC.FixedRows = 1;
			FG_EFIG_MC.FixedColumns = 0;

			FG_EFIG_MC.CurrentRowIndex = 0;
			FG_EFIG_MC.CurrentColumnIndex = 0;
			FG_EFIG_MC[FG_EFIG_MC.CurrentRowIndex, FG_EFIG_MC.CurrentColumnIndex].Value = "fipg_generic_name";
			FG_EFIG_MC.SetColumnWidth(0, 200);

			FG_EFIG_MC.CurrentColumnIndex = 1;
			FG_EFIG_MC[FG_EFIG_MC.CurrentRowIndex, FG_EFIG_MC.CurrentColumnIndex].Value = "fipg_main_comp_id";

			FG_EFIG_MC.CurrentColumnIndex = 2;
			FG_EFIG_MC[FG_EFIG_MC.CurrentRowIndex, FG_EFIG_MC.CurrentColumnIndex].Value = "comp_name";
			FG_EFIG_MC.SetColumnWidth(2, 200);

			FG_EFIG_MC.CurrentColumnIndex = 3;
			FG_EFIG_MC[FG_EFIG_MC.CurrentRowIndex, FG_EFIG_MC.CurrentColumnIndex].Value = "comp_city";
			FG_EFIG_MC.SetColumnWidth(3, 80);

			FG_EFIG_MC.CurrentColumnIndex = 4;
			FG_EFIG_MC[FG_EFIG_MC.CurrentRowIndex, FG_EFIG_MC.CurrentColumnIndex].Value = "comp_state";

			FG_EFIG_MC.CurrentColumnIndex = 5;
			FG_EFIG_MC[FG_EFIG_MC.CurrentRowIndex, FG_EFIG_MC.CurrentColumnIndex].Value = "comp_id";

			FG_EFIG_MC.CurrentColumnIndex = 6;
			FG_EFIG_MC[FG_EFIG_MC.CurrentRowIndex, FG_EFIG_MC.CurrentColumnIndex].Value = "tcount";

			//  query updated to be used by rtw on 5/27/2021
			string Query = "select fipg_generic_name, fipg_main_comp_id, comp_name, comp_city, comp_state, comp_id, count(distinct journ_id + adoc_journ_seq_no) as tcount ";
			Query = $"{Query}from View_Financial_Documents ";
			if (!overload)
			{
				// check for the all variable
				if (aSelection != "0")
				{
					Query = $"{Query}where fipg_main_comp_id='{aSelection}' ";
				}

			}
			Query = $"{Query}group by fipg_generic_name, fipg_main_comp_id,comp_name, comp_city, comp_state, comp_id ";
			Query = $"{Query}order by fipg_generic_name, fipg_main_comp_id,comp_name, comp_city, comp_state, comp_id";

			RS_Table.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

			int aCounter = 0;
			int docCount = 0;
			if (!(RS_Table.EOF && RS_Table.BOF))
			{
				aCounter = 0;
				docCount = 0;
				//FG_EFIG_MC
				FG_EFIG_MC.CurrentRowIndex = 1;

				while(!RS_Table.EOF)
				{
					FG_EFIG_MC.CurrentColumnIndex = 0;
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(RS_Table["fipg_generic_name"]))
					{
						FG_EFIG_MC[FG_EFIG_MC.CurrentRowIndex, FG_EFIG_MC.CurrentColumnIndex].Value = $" {Convert.ToString(RS_Table["fipg_generic_name"])}";
					}

					FG_EFIG_MC.CurrentColumnIndex = 1;
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(RS_Table["fipg_main_comp_id"]))
					{
						FG_EFIG_MC[FG_EFIG_MC.CurrentRowIndex, FG_EFIG_MC.CurrentColumnIndex].Value = Convert.ToString(RS_Table["fipg_main_comp_id"]);
					}

					FG_EFIG_MC.CurrentColumnIndex = 2;
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(RS_Table["comp_name"]))
					{
						FG_EFIG_MC[FG_EFIG_MC.CurrentRowIndex, FG_EFIG_MC.CurrentColumnIndex].Value = $" {Convert.ToString(RS_Table["comp_name"])}";
					}

					FG_EFIG_MC.CurrentColumnIndex = 3;
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(RS_Table["comp_city"]))
					{
						FG_EFIG_MC[FG_EFIG_MC.CurrentRowIndex, FG_EFIG_MC.CurrentColumnIndex].Value = RS_Table["comp_city"];
					}

					FG_EFIG_MC.CurrentColumnIndex = 4;
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(RS_Table["comp_state"]))
					{
						FG_EFIG_MC[FG_EFIG_MC.CurrentRowIndex, FG_EFIG_MC.CurrentColumnIndex].Value = RS_Table["comp_state"];
					}

					FG_EFIG_MC.CurrentColumnIndex = 5;
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(RS_Table["comp_id"]))
					{
						FG_EFIG_MC[FG_EFIG_MC.CurrentRowIndex, FG_EFIG_MC.CurrentColumnIndex].Value = Convert.ToString(RS_Table["comp_id"]);
					}

					FG_EFIG_MC.CurrentColumnIndex = 6;
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(RS_Table["tcount"]))
					{
						FG_EFIG_MC[FG_EFIG_MC.CurrentRowIndex, FG_EFIG_MC.CurrentColumnIndex].Value = Convert.ToString(RS_Table["tcount"]);
						docCount = Convert.ToInt32(docCount + Convert.ToDouble(RS_Table["tcount"]));
					}

					FG_EFIG_MC.RowsCount++;
					FG_EFIG_MC.CurrentRowIndex++;

					RS_Table.MoveNext();
					aCounter++;
					lblNIOL_CompanyData[6].Text = $"Number of companies: {aCounter.ToString()}";
					lblNIOL_CompanyData[5].Text = $"Number of documents: {docCount.ToString()}";
				};
				FG_EFIG_MC.RowsCount--;
				FG_EFIG_MC.CurrentRowIndex = 1;
			}
			else
			{
				FG_EFIG_MC.CurrentRowIndex = 1;
				FG_EFIG_MC.CurrentColumnIndex = 0;
				FG_EFIG_MC[FG_EFIG_MC.CurrentRowIndex, FG_EFIG_MC.CurrentColumnIndex].Value = "";


				FG_EFIG_MC.CurrentColumnIndex = 1;
				FG_EFIG_MC[FG_EFIG_MC.CurrentRowIndex, FG_EFIG_MC.CurrentColumnIndex].Value = "";


				FG_EFIG_MC.CurrentColumnIndex = 2;
				FG_EFIG_MC[FG_EFIG_MC.CurrentRowIndex, FG_EFIG_MC.CurrentColumnIndex].Value = "";


				FG_EFIG_MC.CurrentColumnIndex = 3;
				FG_EFIG_MC[FG_EFIG_MC.CurrentRowIndex, FG_EFIG_MC.CurrentColumnIndex].Value = "";

				FG_EFIG_MC.CurrentColumnIndex = 4;
				FG_EFIG_MC[FG_EFIG_MC.CurrentRowIndex, FG_EFIG_MC.CurrentColumnIndex].Value = "";


				FG_EFIG_MC.CurrentColumnIndex = 5;
				FG_EFIG_MC[FG_EFIG_MC.CurrentRowIndex, FG_EFIG_MC.CurrentColumnIndex].Value = "";

				FG_EFIG_MC.CurrentColumnIndex = 6;
				FG_EFIG_MC[FG_EFIG_MC.CurrentRowIndex, FG_EFIG_MC.CurrentColumnIndex].Value = "";

				//FG_EFIG_MC.Rows = FG_EFIG_MC.Rows - 1
				FG_EFIG_MC.CurrentRowIndex = 0;
			}

			// ADDED RTW - 10/7/2019
			if (RS_Table != null)
			{
				if (RS_Table.State == ConnectionState.Open)
				{ // Already Open Close It
					RS_Table.Close();
				}
				RS_Table = null;
			}

			lblNIOL_CompanyData[6].Text = $"Number of companies: {aCounter.ToString()}";
			lblNIOL_CompanyData[5].Text = $"Number of documents: {docCount.ToString()}";
		}
		private void LoadcboEFIG()
		{
			string Query = "select fipg_generic_name, fipg_main_comp_id  from Financial_Institution_Primary_Group ";
			Query = $"{Query}order by fipg_generic_name, fipg_main_comp_id";

			ADORecordSetHelper RS_Table = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

			//If Not IsNull(RS_Table) And (RS_Table.EOF And RS_Table.BOF) Then
			if (!(RS_Table.EOF && RS_Table.BOF))
			{
				RS_Table.MoveFirst();

				while(!RS_Table.EOF)
				{
					cboEFIG_SelectGroup[0].AddItem(Convert.ToString(RS_Table["fipg_generic_name"]));
					cboEFIG_SelectGroup[0].SetItemData(cboEFIG_SelectGroup[0].GetNewIndex(), Convert.ToInt32(RS_Table["fipg_main_comp_id"]));

					cboAdd_Comp_Ref.AddItem(Convert.ToString(RS_Table["fipg_generic_name"]));
					cboAdd_Comp_Ref.SetItemData(cboAdd_Comp_Ref.GetNewIndex(), Convert.ToInt32(RS_Table["fipg_main_comp_id"]));

					RS_Table.MoveNext();
				};
				RS_Table.Close();
				cboEFIG_SelectGroup[0].SelectedIndex = 0;
			}
		}
		private void LoadNIOL(bool overload, string aSelection)
		{
			object date_today = null;
			try
			{
				// LoadNIOL populates cboEFIG_NIOL, and the datagrid FG_EFIG_NIOL on panel_EFIG_NIOL
				// Pulls info from Aircraft_Document and an inner join on company
				string Query = "";
				ADORecordSetHelper RS_Table = null;
				chk_SortTotal.Visible = true;

				this.Cursor = Cursors.WaitCursor;

				Query = "select distinct comp_name, comp_city, comp_state, comp_id, count(distinct journ_id + adoc_journ_seq_no) as tcount ";
				Query = $"{Query}from View_Financial_Documents with (NOLOCK) ";

				Query = $"{Query}where fipg_generic_name = 'Misc. Institutions' ";

				if (overload)
				{
					Query = $"{Query}and comp_name LIKE'{aSelection}%' ";
				}
				if (txtDateRange_pnlEFIG[0].Text != "")
				{
					if (Information.IsDate(txtDateRange_pnlEFIG[0].Text))
					{
						date_today = DateTime.Now.ToString("MM/dd/yyyy");
						//UPGRADE_WARNING: (1068) date_today of type Variant is being forced to DateTime. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						if (DateTime.Parse(txtDateRange_pnlEFIG[0].Text) > Convert.ToDateTime(date_today))
						{
							//UPGRADE_WARNING: (1068) date_today of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
							MessageBox.Show($"The text you have entered cannot be greater than: {Convert.ToString(date_today)}{Environment.NewLine}The search will continue", "Invalid Input For Search", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						}
						else
						{
							Query = $"{Query}AND adoc_entered_date <= '{txtDateRange_pnlEFIG[0].Text}' ";
						}
					}
					else
					{
						MessageBox.Show("The text you have entered must be a date, the search will continue for all documents", "Invalid Input For Search", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						txtDateRange_pnlEFIG[0].Text = "";
					}
				}
				Query = $"{Query}group by comp_name, comp_city, comp_state, comp_id ";
				if (chk_SortTotal.CheckState == CheckState.Unchecked)
				{
					Query = $"{Query}order by comp_name, comp_city, comp_state";
				}
				else
				{
					Query = $"{Query}order by count(distinct journ_id + adoc_journ_seq_no) desc";
				}

				FG_EFIG_NIOL.ColumnsCount = 5;
				FG_EFIG_NIOL.RowsCount = 2;
				FG_EFIG_NIOL.FixedRows = 1;
				FG_EFIG_NIOL.FixedColumns = 0;

				FG_EFIG_NIOL.CurrentRowIndex = 0;
				FG_EFIG_NIOL.CurrentColumnIndex = 0;
				FG_EFIG_NIOL[FG_EFIG_NIOL.CurrentRowIndex, FG_EFIG_NIOL.CurrentColumnIndex].Value = " COMPANY";
				FG_EFIG_NIOL.SetColumnWidth(0, 213);

				FG_EFIG_NIOL.CurrentColumnIndex = 1;
				FG_EFIG_NIOL[FG_EFIG_NIOL.CurrentRowIndex, FG_EFIG_NIOL.CurrentColumnIndex].Value = "CITY";
				FG_EFIG_NIOL.SetColumnWidth(1, 107);

				FG_EFIG_NIOL.CurrentColumnIndex = 2;
				FG_EFIG_NIOL[FG_EFIG_NIOL.CurrentRowIndex, FG_EFIG_NIOL.CurrentColumnIndex].Value = "STATE";
				FG_EFIG_NIOL.SetColumnWidth(2, 67);

				FG_EFIG_NIOL.CurrentColumnIndex = 3;
				FG_EFIG_NIOL[FG_EFIG_NIOL.CurrentRowIndex, FG_EFIG_NIOL.CurrentColumnIndex].Value = "ID";
				FG_EFIG_NIOL.SetColumnWidth(3, 67);

				FG_EFIG_NIOL.CurrentColumnIndex = 4;
				FG_EFIG_NIOL[FG_EFIG_NIOL.CurrentRowIndex, FG_EFIG_NIOL.CurrentColumnIndex].Value = "DOCS";

				RS_Table = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

				int aCounter = 0;
				int docCount = 0;
				if (!(RS_Table.EOF && RS_Table.BOF))
				{
					aCounter = 0;
					docCount = 0;

					//FG_EFIG_MC
					FG_EFIG_NIOL.CurrentRowIndex = 1;

					while(!RS_Table.EOF)
					{
						FG_EFIG_NIOL.CurrentColumnIndex = 0;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(RS_Table["comp_name"]))
						{
							FG_EFIG_NIOL[FG_EFIG_NIOL.CurrentRowIndex, FG_EFIG_NIOL.CurrentColumnIndex].Value = $" {Convert.ToString(RS_Table["comp_name"])}";
						}

						FG_EFIG_NIOL.CurrentColumnIndex = 1;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(RS_Table["comp_city"]))
						{
							FG_EFIG_NIOL[FG_EFIG_NIOL.CurrentRowIndex, FG_EFIG_NIOL.CurrentColumnIndex].Value = Convert.ToString(RS_Table["comp_city"]);
						}

						FG_EFIG_NIOL.CurrentColumnIndex = 2;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(RS_Table["comp_state"]))
						{
							FG_EFIG_NIOL[FG_EFIG_NIOL.CurrentRowIndex, FG_EFIG_NIOL.CurrentColumnIndex].Value = RS_Table["comp_state"];
						}

						FG_EFIG_NIOL.CurrentColumnIndex = 3;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(RS_Table["comp_id"]))
						{
							FG_EFIG_NIOL[FG_EFIG_NIOL.CurrentRowIndex, FG_EFIG_NIOL.CurrentColumnIndex].Value = Convert.ToString(RS_Table["comp_id"]);
						}

						FG_EFIG_NIOL.CurrentColumnIndex = 4;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(RS_Table["tcount"]))
						{
							FG_EFIG_NIOL[FG_EFIG_NIOL.CurrentRowIndex, FG_EFIG_NIOL.CurrentColumnIndex].Value = Convert.ToString(RS_Table["tcount"]);
							docCount = Convert.ToInt32(docCount + Convert.ToDouble(RS_Table["tcount"]));
						}

						FG_EFIG_NIOL.RowsCount++;
						FG_EFIG_NIOL.CurrentRowIndex++;

						RS_Table.MoveNext();
						aCounter++;
					};
					FG_EFIG_NIOL.RowsCount--;
					FG_EFIG_NIOL.CurrentRowIndex = 1;
					this.Cursor = CursorHelper.CursorDefault;
				}
				else
				{
					FG_EFIG_NIOL.Visible = false;
					lblNIOL_CompanyData[8].Text = "0";
					lblNIOL_CompanyData[7].Text = "0";
					this.Cursor = CursorHelper.CursorDefault;
					RS_Table.Close();
					return;
				}
				RS_Table.Close();
				lblNIOL_CompanyData[7].Text = $"Number of companies: {aCounter.ToString()}";
				lblNIOL_CompanyData[8].Text = $"Number of documents: {docCount.ToString()}";
				this.Cursor = CursorHelper.CursorDefault;
			}
			catch
			{
				modAdminCommon.Report_Error("Financial Groups: LoadNIOL()");
				return;
			}
		}
		private void Load_Company_SIC_Codes(string LoadType, string aComboSelection)
		{
			try
			{
				string Query = "";
				ADORecordSetHelper RS_Table = null;
				if (LoadType != "Combo")
				{
					Query = "SELECT DISTINCT csic_group FROM Company_SIC_Codes ORDER BY csic_group ASC";

					RS_Table = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

					//If Not IsNull(RS_Table) And (RS_Table.EOF And RS_Table.BOF) Then
					if (!(RS_Table.EOF && RS_Table.BOF))
					{
						cboEFIG_SelectGroup[1].AddItem("All");
						cboEFIG_SelectGroup[1].SetItemData(cboEFIG_SelectGroup[1].GetNewIndex(), 0);
						RS_Table.MoveFirst();

						while(!RS_Table.EOF)
						{
							cboEFIG_SelectGroup[1].AddItem(Convert.ToString(RS_Table["csic_group"]));
							cboEFIG_SelectGroup[2].AddItem(Convert.ToString(RS_Table["csic_group"]));
							RS_Table.MoveNext();
						};
						if (LoadType == "Combo")
						{
							cboEFIG_SelectGroup[1].SelectedText = aComboSelection;
							cboEFIG_SelectGroup[2].SelectedText = aComboSelection;
						}
						else
						{
							RS_Table.MoveFirst();
							cboEFIG_SelectGroup[2].SelectedText = Convert.ToString(RS_Table["csic_group"]);
							cboEFIG_SelectGroup[1].SelectedText = "All";
						}
						RS_Table.Close();
					}
				}

				FG_Array[0].ColumnsCount = 4;
				FG_Array[0].RowsCount = 2;
				FG_Array[0].FixedRows = 1;
				FG_EFIG_MC.FixedColumns = 0;

				FG_Array[0].CurrentRowIndex = 0;
				FG_Array[0].CurrentColumnIndex = 0;
				FG_Array[0][FG_Array[0].CurrentRowIndex, FG_Array[0].CurrentColumnIndex].Value = "csic_code";
				FG_Array[0].SetColumnWidth(0, 55);

				FG_Array[0].CurrentColumnIndex = 1;
				FG_Array[0][FG_Array[0].CurrentRowIndex, FG_Array[0].CurrentColumnIndex].Value = "csic_group";
				FG_Array[0].SetColumnWidth(1, 100);

				FG_Array[0].CurrentColumnIndex = 2;
				FG_Array[0][FG_Array[0].CurrentRowIndex, FG_Array[0].CurrentColumnIndex].Value = "csic_name";
				FG_Array[0].SetColumnWidth(2, 213);

				FG_Array[0].CurrentColumnIndex = 3;
				FG_Array[0][FG_Array[0].CurrentRowIndex, FG_Array[0].CurrentColumnIndex].Value = "csic_description";
				FG_Array[0].SetColumnWidth(3, 280);

				Query = "SELECT * FROM Company_SIC_Codes ";
				if (aComboSelection != "")
				{
					Query = $"{Query}Where csic_group = '{aComboSelection}' ";
				}
				Query = $"{Query}Order by csic_code";
				RS_Table = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");
				if (!(RS_Table.EOF && RS_Table.BOF))
				{
					//FG_EFIG_MC
					FG_Array[0].CurrentRowIndex = 1;

					while(!RS_Table.EOF)
					{
						FG_Array[0].CurrentColumnIndex = 0;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(RS_Table["csic_code"]))
						{
							FG_Array[0][FG_Array[0].CurrentRowIndex, FG_Array[0].CurrentColumnIndex].Value = RS_Table["csic_code"];
						}

						FG_Array[0].CurrentColumnIndex = 1;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(RS_Table["csic_group"]))
						{
							FG_Array[0][FG_Array[0].CurrentRowIndex, FG_Array[0].CurrentColumnIndex].Value = RS_Table["csic_group"];
						}

						FG_Array[0].CurrentColumnIndex = 2;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(RS_Table["csic_name"]))
						{
							FG_Array[0][FG_Array[0].CurrentRowIndex, FG_Array[0].CurrentColumnIndex].Value = RS_Table["csic_name"];
						}

						FG_Array[0].CurrentColumnIndex = 3;
						FG_Array[0][FG_Array[0].CurrentRowIndex, FG_Array[0].CurrentColumnIndex].Value = "";
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(RS_Table["csic_description"]))
						{
							FG_Array[0][FG_Array[0].CurrentRowIndex, FG_Array[0].CurrentColumnIndex].Value = RS_Table["csic_description"];
						}
						//FG_Array(0).RowData(FG_Array(0).Row) = CLng(RS_Table("csic_PK").Value)

						FG_Array[0].RowsCount++;
						FG_Array[0].CurrentRowIndex++;

						RS_Table.MoveNext();
					};
					FG_Array[0].RowsCount--;
					FG_Array[0].CurrentRowIndex = 1;
					// set the text fields
					FG_Array[0].CurrentColumnIndex = 0;
					txtCIC[0].Text = FG_Array[0][FG_Array[0].CurrentRowIndex, FG_Array[0].CurrentColumnIndex].FormattedValue.ToString().Trim();
					FG_Array[0].CurrentColumnIndex = 2;
					txtCIC[1].Text = FG_Array[0][FG_Array[0].CurrentRowIndex, FG_Array[0].CurrentColumnIndex].FormattedValue.ToString().Trim();
					FG_Array[0].CurrentColumnIndex = 3;
					txtCIC[2].Text = "";
					txtCIC[2].Text = FG_Array[0][FG_Array[0].CurrentRowIndex, FG_Array[0].CurrentColumnIndex].FormattedValue.ToString().Trim();
				}
				else
				{
					FG_Array[0].CurrentRowIndex = 1;
					FG_Array[0].CurrentColumnIndex = 0;
					FG_Array[0][FG_Array[0].CurrentRowIndex, FG_Array[0].CurrentColumnIndex].Value = "None";

					FG_Array[0].CurrentColumnIndex = 1;
					FG_Array[0][FG_Array[0].CurrentRowIndex, FG_Array[0].CurrentColumnIndex].Value = "None";

					FG_Array[0].CurrentColumnIndex = 2;
					FG_Array[0][FG_Array[0].CurrentRowIndex, FG_Array[0].CurrentColumnIndex].Value = "None";

					FG_Array[0].CurrentColumnIndex = 3;
					FG_Array[0][FG_Array[0].CurrentRowIndex, FG_Array[0].CurrentColumnIndex].Value = "None";
					FG_Array[0].set_RowData(FG_Array[0].CurrentRowIndex, 0);
					// set the text fields
					FG_Array[0].CurrentColumnIndex = 0;
					txtCIC[0].Text = "";
					FG_Array[0].CurrentColumnIndex = 2;
					txtCIC[1].Text = "";
					FG_Array[0].CurrentColumnIndex = 3;
					txtCIC[2].Text = "";
				}
				RS_Table.Close();
			}
			catch
			{
				modAdminCommon.Report_Error("Load_Company_SIC_Codes()");
				return;
			}
		}

		private void vbCheck_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{
			try
			{
                DataGridViewFlex Grd = null;
				int nRow = 0; //Current row counter
				string Query = ""; //Current query sql
				ADORecordSetHelper RS_Table = new ADORecordSetHelper(); //Current recordset
				Grd = FG_Phone_Type;
				//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				Grd.Col = 0;
				//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				Grd.Row = 0;
				Grd.Text = "Phone Type";
				//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				Grd.Col = 1;
				Grd.Text = "Seq_No";
				//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				Grd.Col = 2;
				Grd.Text = "Abbrev";
				//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				Grd.ColWidth[0] = 2000;
				//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				Grd.ColWidth[1] = 1000;
				//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				Grd.ColWidth[2] = 1000;

				nRow = 1;
				//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				Grd.Row = nRow;

				Query = "SELECT * from Phone_Type ";
				if (vbCheck[0].CheckState == CheckState.Checked)
				{
					Query = $"{Query} ORDER BY ptype_seq_no ";
				}
				else
				{
					Query = $"{Query} ORDER BY ptype_name ";
				}
				RS_Table.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

				if (!(RS_Table.BOF && RS_Table.EOF))
				{
					RS_Table.MoveFirst();

					while(!RS_Table.EOF)
					{
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						Grd.Col = 0;
						Grd.Text = ($"{Convert.ToString(RS_Table["ptype_name"])} ").Trim();
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						Grd.Col = 1;
						Grd.Text = ($"{Convert.ToString(RS_Table["ptype_seq_no"])}").Trim();
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						Grd.Col = 2;
						Grd.Text = ($"{Convert.ToString(RS_Table["ptype_abbrev"])} ").Trim();
						nRow++;
						//UPGRADE_TODO: (1067) Member Rows is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						Grd.RowCount = nRow + 1;//gap-note Grd.Rows was changed to GrdRow.RowCount
						//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						Grd.Row = nRow;
						RS_Table.MoveNext();
					};
				}
				RS_Table.Close();
                //UPGRADE_TODO: (1067) Member Rows is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
                Grd.RowCount = nRow - 1;//gap-note Grd.Rows was changed to GrdRow.RowCount
                Grd.Refresh();
			}
			catch
			{
				modAdminCommon.Report_Error("Error on Phone_Type, sorting the display");
				return;
			}

		}

		public void Fill_Contacdt_Title_List_Headers()
		{


			FG_Contact_Title.Clear();
			FG_Contact_Title.RowsCount = 2;
			FG_Contact_Title.ColumnsCount = 4;

			FG_Contact_Title.CurrentRowIndex = 0;

			FG_Contact_Title.CurrentColumnIndex = 0;
			FG_Contact_Title[FG_Contact_Title.CurrentRowIndex, FG_Contact_Title.CurrentColumnIndex].Value = "Title Name";
			FG_Contact_Title.SetColumnWidth(FG_Contact_Title.CurrentColumnIndex, 200);

			FG_Contact_Title.CurrentColumnIndex = 1;
			FG_Contact_Title[FG_Contact_Title.CurrentRowIndex, FG_Contact_Title.CurrentColumnIndex].Value = "Groups";
			FG_Contact_Title.SetColumnWidth(FG_Contact_Title.CurrentColumnIndex, 227);

			FG_Contact_Title.CurrentColumnIndex = 2;
			FG_Contact_Title[FG_Contact_Title.CurrentRowIndex, FG_Contact_Title.CurrentColumnIndex].Value = "Recs";
			FG_Contact_Title.SetColumnWidth(FG_Contact_Title.CurrentColumnIndex, 47);

			FG_Contact_Title.CurrentColumnIndex = 3;
			FG_Contact_Title[FG_Contact_Title.CurrentRowIndex, FG_Contact_Title.CurrentColumnIndex].Value = "Status";
			FG_Contact_Title.SetColumnWidth(FG_Contact_Title.CurrentColumnIndex, 47);

			FG_Contact_Title.CurrentRowIndex = 1;
			FG_Contact_Title.CurrentColumnIndex = 0;
			FG_Contact_Title.FixedRows = 1;
			FG_Contact_Title.FixedColumns = 0;
			 // FG_Contact_Title

		} // Fill_Contacdt_Title_List_Headers

		public void Fill_Contact_Title_List()
		{

			int NewTab = 0; //Current tab

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = ""; //Current query sql

			string FLDS = ""; //work fields for query string
			string VALS = ""; //value work fields for query string
			string Comma = ""; //comma work field for query string
			int nRow = 0; //Current row counter
			int Ans = 0; //Answer to question
			Control Grd = null;
			Color lForeColor = System.Drawing.Color.Black;

			int lRow1 = 0;
			int lCol1 = 0;
			int lTot1 = 0;

			int lBackColor = ColorTranslator.ToOle(Color.White);

			// cmd search title
			cmd_contact_button[6].Enabled = false;

			pnl_CT_AddUpdate.Visible = false;
			pnl_ContactTitleGroup.Visible = false;

			Fill_Contacdt_Title_List_Headers();


			FG_Contact_Title.Enabled = false;

			strQuery1 = "SELECT DISTINCT ctitle_name, ctitle_active_flag FROM Contact_Title with (NOLOCK) ";
			strQuery1 = $"{strQuery1}WHERE ctitle_name <> '' ";

			if (txt_title_search.Text.Trim() != "")
			{

				if (chkPilotsNotInPilotsGroup.CheckState == CheckState.Unchecked && chkChairmanCEONotInChairmanCEOGroup.CheckState == CheckState.Unchecked && chkCFONotInCFOGroup.CheckState == CheckState.Unchecked)
				{
					strQuery1 = $"{strQuery1}AND (ctitle_name LIKE '%{txt_title_search.Text.Trim()}%') ";

					if (chkTitleNotInGroup.CheckState == CheckState.Checked && cboTitleNotInGroup.Text != "")
					{
						strQuery1 = $"{strQuery1}AND (NOT EXISTS (SELECT NULL FROM Contact_Title_Group_Reference WITH (NOLOCK) ";
						strQuery1 = $"{strQuery1}                 WHERE (ctitlegref_title_name = ctitle_name) ";
						strQuery1 = $"{strQuery1}                 AND (ctitlegref_group_name = '{cboTitleNotInGroup.Text.Trim()}') ";
						strQuery1 = $"{strQuery1}                ) ";
						strQuery1 = $"{strQuery1}    ) ";
					} // If chkTitleNotInGroup.Value = vbChecked And cboTitleNotInGroup.Text <> "" Then

				} // If chkPilotsNotInPilotsGroup.Value = vbUnchecked And ...etc

			} // If Trim(txt_title_search.Text) <> "" Then

			if (chkTitlesNotMapped.CheckState == CheckState.Checked)
			{
				strQuery1 = $"{strQuery1}AND (NOT EXISTS (SELECT NULL FROM Contact_Title_Group_Reference WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}                 WHERE (ctitlegref_title_name = ctitle_name) ";
				strQuery1 = $"{strQuery1}                ) ";
				strQuery1 = $"{strQuery1}    ) ";
			}

			if (chkPilotsNotInPilotsGroup.CheckState == CheckState.Checked)
			{

				strQuery1 = $"{strQuery1}AND (ctitle_name LIKE '%Pilot%') ";
				strQuery1 = $"{strQuery1}AND (NOT EXISTS (SELECT NULL FROM Contact_Title_Group_Reference WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}                 WHERE (ctitlegref_title_name = ctitle_name) ";
				strQuery1 = $"{strQuery1}                 AND (ctitlegref_group_name = 'Pilots') ";
				strQuery1 = $"{strQuery1}                ) ";
				strQuery1 = $"{strQuery1}    ) ";

			} // If chkPilotsNotInPilotsGroup.Value = vbChecked Then

			if (chkChairmanCEONotInChairmanCEOGroup.CheckState == CheckState.Checked)
			{

				strQuery1 = $"{strQuery1}AND (ctitle_name LIKE '%Chairman%' OR ctitle_name LIKE '%CEO%') ";
				strQuery1 = $"{strQuery1}AND (NOT EXISTS (SELECT NULL FROM Contact_Title_Group_Reference WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}                 WHERE (ctitlegref_title_name = ctitle_name) ";
				strQuery1 = $"{strQuery1}                 AND (ctitlegref_group_name = 'Chairman/CEO') ";
				strQuery1 = $"{strQuery1}                ) ";
				strQuery1 = $"{strQuery1}    ) ";

			} // If chkChairmanCEONotInChairmanCEOGroup.Value = vbChecked Then

			if (chkCFONotInCFOGroup.CheckState == CheckState.Checked)
			{

				strQuery1 = $"{strQuery1}AND (ctitle_name LIKE '%CFO%') ";
				strQuery1 = $"{strQuery1}AND (";
				strQuery1 = $"{strQuery1}     (NOT EXISTS (SELECT NULL FROM Contact_Title_Group_Reference WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}                  WHERE (ctitlegref_title_name = ctitle_name) ";
				strQuery1 = $"{strQuery1}                  AND (ctitlegref_group_name = 'CFO') ";
				strQuery1 = $"{strQuery1}                 ) ";
				strQuery1 = $"{strQuery1}     ) ";
				strQuery1 = $"{strQuery1}OR ";
				strQuery1 = $"{strQuery1}    (NOT EXISTS (SELECT NULL FROM Contact_Title_Group_Reference WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}                 WHERE (ctitlegref_title_name = ctitle_name) ";
				strQuery1 = $"{strQuery1}                 AND (ctitlegref_group_name = 'Finance') ";
				strQuery1 = $"{strQuery1}                ) ";
				strQuery1 = $"{strQuery1}    ) ";
				strQuery1 = $"{strQuery1}   ) ";

			} // If chkCFONotInCFOGroup.Value = vbChecked Then

			if (cboSearchTitleGroup.Text.Trim() != "")
			{

				strQuery1 = $"{strQuery1}AND (EXISTS (SELECT NULL FROM Contact_Title_Group_Reference WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}             WHERE (ctitlegref_title_name = ctitle_name) ";
				strQuery1 = $"{strQuery1}             AND (ctitlegref_group_name = '{StringsHelper.Replace(cboSearchTitleGroup.Text.Trim(), "'", "''", 1, -1, CompareMethod.Binary)}') ";
				strQuery1 = $"{strQuery1}             ) ";
				strQuery1 = $"{strQuery1}    ) ";

			} // If Trim(cboSearchTitleGroup.Text) <> "" Then

			strQuery1 = $"{strQuery1}ORDER BY ctitle_name ";

			lblTotTitles[2].Text = "Searching Titles";

			rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
			rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

			if (!rstRec1.BOF && !rstRec1.EOF)
			{

				lTot1 = rstRec1.RecordCount;
				lRow1 = 0;

				lblStopTitleLoad[1].Visible = true;
				FG_Contact_Title.Redraw = false;

				do 
				{ // Loop Until rstRec1.EOF = True Or lblStopTitleLoad.Visible = False

					lCol1 = 0;

					lRow1++;
					FG_Contact_Title.RowsCount = lRow1 + 1;
					FG_Contact_Title.CurrentRowIndex = lRow1;

					lblTotTitles[2].Text = $"Total Records Found: {StringsHelper.Format(lTot1, "#,##0")} Working: {StringsHelper.Format(lRow1, "#,##0")}";

					if (($"{Convert.ToString(rstRec1["ctitle_active_flag"])}").Trim() == "Y")
					{
						lBackColor = ColorTranslator.ToOle(Color.White);
						lForeColor = Color.Black;
					}
					else
					{
						lBackColor = Convert.ToInt32(Double.Parse(modAdminCommon.InactiveColor));
						lForeColor = Color.Black;

					}

					FG_Contact_Title.CurrentColumnIndex = 0;
					FG_Contact_Title.CellBackColor = ColorTranslator.FromOle(lBackColor);
					FG_Contact_Title.CellForeColor = lForeColor;
					FG_Contact_Title[FG_Contact_Title.CurrentRowIndex, FG_Contact_Title.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["ctitle_name"])} ").Trim();

					FG_Contact_Title.CurrentColumnIndex = 1;
					FG_Contact_Title.CellBackColor = ColorTranslator.FromOle(lBackColor);
					FG_Contact_Title.CellForeColor = lForeColor;
					FG_Contact_Title[FG_Contact_Title.CurrentRowIndex, FG_Contact_Title.CurrentColumnIndex].Value = Get_Contact_Groups_For_Title(($"{Convert.ToString(rstRec1["ctitle_name"])} ").Trim());

					FG_Contact_Title.CurrentColumnIndex = 2;
					FG_Contact_Title.CellBackColor = ColorTranslator.FromOle(lBackColor);
					FG_Contact_Title.CellForeColor = lForeColor;
					FG_Contact_Title[FG_Contact_Title.CurrentRowIndex, FG_Contact_Title.CurrentColumnIndex].Value = Get_Contact_Title_Counts(($"{Convert.ToString(rstRec1["ctitle_name"])} ").Trim());

					FG_Contact_Title.CurrentColumnIndex = 3;
					FG_Contact_Title.CellBackColor = ColorTranslator.FromOle(lBackColor);
					FG_Contact_Title.CellForeColor = lForeColor;
					FG_Contact_Title[FG_Contact_Title.CurrentRowIndex, FG_Contact_Title.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["ctitle_active_flag"])}").Trim();

					if (lRow1 == 29)
					{
						FG_Contact_Title.Redraw = true;
						FG_Contact_Title.Refresh();
						Application.DoEvents();
						FG_Contact_Title.Redraw = false;
					}

					rstRec1.MoveNext();
					Application.DoEvents();

				}
				while(!(rstRec1.EOF || !lblStopTitleLoad[1].Visible));

				lblStopTitleLoad[1].Visible = false;
				FG_Contact_Title.Redraw = true;
				lblTotTitles[2].Text = $"Total Records Loaded: {StringsHelper.Format(lRow1, "#,##0")}";

				FG_Contact_Title.Enabled = true;

			}
			else
			{
				FG_Contact_Title.CurrentRowIndex = 1;
				FG_Contact_Title.CurrentColumnIndex = 0;
				FG_Contact_Title[FG_Contact_Title.CurrentRowIndex, FG_Contact_Title.CurrentColumnIndex].Value = "No Records Found";
				lblTotTitles[2].Text = "No Records Found";
			} // If (rstRec1.BOF = False And rstRec1.EOF = False) Then

			rstRec1.Close();
			 // FG_Contact_Title

			cmd_contact_button[6].Enabled = true;


		} // Fill_Contact_Title_List

		public string Get_Contact_Groups_For_Title(string inTitle)
		{

			string result = "";
			ADORecordSetHelper RS_Groups = new ADORecordSetHelper(); //Current recordset



			string Query = $"select ctitlegref_group_name from Contact_Title_Group_Reference with (NOLOCK) where ctitlegref_title_name='{inTitle}'"; //Current query sql

			RS_Groups.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

			if (!(RS_Groups.BOF && RS_Groups.EOF))
			{

				RS_Groups.MoveFirst();

				while(!RS_Groups.EOF)
				{
					if (Strings.Len(result.Trim()) > 0)
					{
						result = $"{result}; {Convert.ToString(RS_Groups["ctitlegref_group_name"])}";
					}
					else
					{
						result = Convert.ToString(RS_Groups["ctitlegref_group_name"]);
					}
					RS_Groups.MoveNext();
				};

			}
			RS_Groups.Close();

			return result;
		}

		public int Get_Contact_Title_Counts(string inTitle)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();

			int lResults = 0;

			string strQuery1 = "SELECT COUNT(*) As TotCnt FROM Contact WITH (NOLOCK) ";
			strQuery1 = $"{strQuery1}WHERE (contact_title ='{StringsHelper.Replace(inTitle, "'", "''", 1, -1, CompareMethod.Binary)}')";

			rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

			if (!rstRec1.BOF && !rstRec1.EOF)
			{
				lResults = Convert.ToInt32(rstRec1["TotCnt"]);
			}

			rstRec1.Close();


			return lResults;



			modAdminCommon.Record_Error("Get_Contact_Title_Counts_Error", Information.Err().Description);

			return 0;

		} // Get_Contact_Title_Counts

		public void Fill_Financial_Group_Drop_Down()
		{


			ADORecordSetHelper RS_GroupList = new ADORecordSetHelper();
			cboEFIG_SelectGroup[0].Items.Clear();

			//'''''''''''''''''''''''''''''''''
			// Populate the combobox
			//'''''''''''''''''''''''''''''''''
			string Query = "select fipg_generic_name, fipg_main_comp_id from Financial_Institution_Primary_Group ";
			Query = $"{Query}order by fipg_generic_name, fipg_main_comp_id";

			//Call RS_GroupList.Open(Query, LOCAL_ADO_DB, adOpenForwardOnly, adLockOptimistic, adCmdText)
			RS_GroupList = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

			//If Not IsNull(RS_GroupList) And (RS_GroupList.EOF And RS_GroupList.BOF) Then
			if (!(RS_GroupList.EOF && RS_GroupList.BOF))
			{
				cboEFIG_SelectGroup[0].AddItem("All");
				cboEFIG_SelectGroup[0].SetItemData(cboEFIG_SelectGroup[0].GetNewIndex(), 0);
				RS_GroupList.MoveFirst();

				while(!RS_GroupList.EOF)
				{
					cboEFIG_SelectGroup[0].AddItem(Convert.ToString(RS_GroupList["fipg_generic_name"]));
					cboEFIG_SelectGroup[0].SetItemData(cboEFIG_SelectGroup[0].GetNewIndex(), Convert.ToInt32(RS_GroupList["fipg_main_comp_id"]));

					cboAdd_Comp_Ref.AddItem(Convert.ToString(RS_GroupList["fipg_generic_name"]));
					cboAdd_Comp_Ref.SetItemData(cboAdd_Comp_Ref.GetNewIndex(), Convert.ToInt32(RS_GroupList["fipg_main_comp_id"]));
					RS_GroupList.MoveNext();
				};
				RS_GroupList.Close();
				//      cboEFIG_SelectGroup(0).ListIndex = 0
				if (!Fin_Initial_Load)
				{
					cboEFIG_SelectGroup[0].SelectedIndex = 0;
				}
				else
				{
					cboEFIG_SelectGroup[0].SelectedIndex = 1;
				}
			}
		}

		public void Get_Financial_Group_Companies(int inGroupID)
		{

			try
			{

				ADORecordSetHelper RS_FinCompList = null;
				string Query = "";

				this.Cursor = Cursors.WaitCursor;

				StringBuilder strCompInfo = new StringBuilder();
				pnl_EFIG.Visible = false;

				chk_SortTotal.Visible = false;
				pnlEFIG_Add_Group.Visible = false;
				pnlEFIG_Delete.Visible = false;
				pnlEFIG_NIOL.Visible = false;
				FG_EFIG_MC.Visible = false;
				bolPanelJump = false;

				FG_EFIG_MC.ColumnsCount = 5;
				FG_EFIG_MC.RowsCount = 2;
				FG_EFIG_MC.FixedRows = 1;
				FG_EFIG_MC.FixedColumns = 0;

				FG_EFIG_MC.CurrentRowIndex = 0;
				FG_EFIG_MC.CurrentColumnIndex = 0;
				FG_EFIG_MC[FG_EFIG_MC.CurrentRowIndex, FG_EFIG_MC.CurrentColumnIndex].Value = "Financial Group";
				FG_EFIG_MC.SetColumnWidth(0, 200);

				FG_EFIG_MC.CurrentColumnIndex = 1;
				FG_EFIG_MC[FG_EFIG_MC.CurrentRowIndex, FG_EFIG_MC.CurrentColumnIndex].Value = "Main ID";

				FG_EFIG_MC.CurrentColumnIndex = 2;
				FG_EFIG_MC[FG_EFIG_MC.CurrentRowIndex, FG_EFIG_MC.CurrentColumnIndex].Value = "Related Company";
				FG_EFIG_MC.SetColumnWidth(2, 280);


				FG_EFIG_MC.CurrentColumnIndex = 3;
				FG_EFIG_MC[FG_EFIG_MC.CurrentRowIndex, FG_EFIG_MC.CurrentColumnIndex].Value = "Comp ID";
				FG_EFIG_MC.SetColumnWidth(3, 53);

				FG_EFIG_MC.CurrentColumnIndex = 4;
				FG_EFIG_MC[FG_EFIG_MC.CurrentRowIndex, FG_EFIG_MC.CurrentColumnIndex].Value = "#Docs";
				FG_EFIG_MC.SetColumnWidth(4, 47);

				// sum the tcount field
				int docCount = 0;
				docCount = 0;

				// RTW - CHANGED ON 5/20/2021 TO DO LEFT OUTER JOIN AND ADDED DOCUMENT COUNT
				Query = "SELECT distinct fipg_generic_name, fipg_main_comp_id, comp_name, comp_city, comp_state, comp_id, count(distinct journ_id + adoc_journ_seq_no) as tcount ";
				//  Query = Query & "(select count(*) from aircraft_document with (NOLOCK) where adoc_infavor_comp_id=comp_id) as tcount "
				Query = $"{Query}From View_Financial_Documents with (NOLOCK) ";
				if (inGroupID != 0)
				{
					Query = $"{Query}where fipg_main_comp_id={inGroupID.ToString()} ";
				}
				Query = $"{Query}group by fipg_generic_name, fipg_main_comp_id, comp_name , comp_city, comp_state, comp_id ";
				Query = $"{Query}order by fipg_generic_name, fipg_main_comp_id, comp_name , comp_city, comp_state, comp_id";

				RS_FinCompList = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");
				int aCounter = 0;
				if (!(RS_FinCompList.EOF && RS_FinCompList.BOF))
				{
					//FG_EFIG_MC
					FG_EFIG_MC.CurrentRowIndex = 1;

					while(!RS_FinCompList.EOF)
					{

						FG_EFIG_MC.CurrentColumnIndex = 0;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(RS_FinCompList["fipg_generic_name"]))
						{
							FG_EFIG_MC[FG_EFIG_MC.CurrentRowIndex, FG_EFIG_MC.CurrentColumnIndex].Value = $" {Convert.ToString(RS_FinCompList["fipg_generic_name"])}";
						}

						FG_EFIG_MC.CurrentColumnIndex = 1;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(RS_FinCompList["fipg_main_comp_id"]))
						{
							FG_EFIG_MC[FG_EFIG_MC.CurrentRowIndex, FG_EFIG_MC.CurrentColumnIndex].Value = Convert.ToString(RS_FinCompList["fipg_main_comp_id"]);
						}

						strCompInfo = new StringBuilder("");
						FG_EFIG_MC.CurrentColumnIndex = 2;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(RS_FinCompList["comp_name"]))
						{
							strCompInfo = new StringBuilder(Convert.ToString(RS_FinCompList["comp_name"]));
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(RS_FinCompList["comp_city"]))
							{
								strCompInfo.Append($", {Convert.ToString(RS_FinCompList["comp_city"])}");
							}
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(RS_FinCompList["comp_state"]))
							{
								strCompInfo.Append($", {Convert.ToString(RS_FinCompList["comp_state"])}");
							}
							FG_EFIG_MC[FG_EFIG_MC.CurrentRowIndex, FG_EFIG_MC.CurrentColumnIndex].Value = $" {strCompInfo.ToString()}";
						}


						FG_EFIG_MC.CurrentColumnIndex = 3;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(RS_FinCompList["comp_id"]))
						{
							FG_EFIG_MC[FG_EFIG_MC.CurrentRowIndex, FG_EFIG_MC.CurrentColumnIndex].Value = Convert.ToString(RS_FinCompList["comp_id"]);
						}

						FG_EFIG_MC.CurrentColumnIndex = 4;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(RS_FinCompList["tcount"]))
						{
							FG_EFIG_MC[FG_EFIG_MC.CurrentRowIndex, FG_EFIG_MC.CurrentColumnIndex].Value = Convert.ToString(RS_FinCompList["tcount"]);
							docCount = Convert.ToInt32(docCount + Convert.ToDouble(RS_FinCompList["tcount"]));
						}

						FG_EFIG_MC.RowsCount++;
						FG_EFIG_MC.CurrentRowIndex++;


						modStatusBar.Update_Status_Bar(modAdminCommon.SB, $"Selecting Financial Groups {aCounter.ToString()} ...", Color.Blue);

						RS_FinCompList.MoveNext();
						aCounter++;
						lblNIOL_CompanyData[6].Text = $"Number of companies: {aCounter.ToString()}";

						lblNIOL_CompanyData[5].Text = $"Number of documents: {docCount.ToString()}";

					};
					FG_EFIG_MC.RowsCount--;
					FG_EFIG_MC.CurrentRowIndex = 1;
				}
				RS_FinCompList.Close();
				lblNIOL_CompanyData[6].Text = $"Number of companies: {aCounter.ToString()}";
				lblNIOL_CompanyData[5].Text = $"Number of documents: {docCount.ToString()}";


				cmdSearch_Compy_wDate[0].Visible = false;
				txtDateRange_pnlEFIG[0].Visible = false;


				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Financial Group Load Complete.", Color.Blue);

				FG_EFIG_MC.Visible = true;
				pnl_EFIG.Visible = true;
				this.Cursor = CursorHelper.CursorDefault;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"Get_Financial_Group_Companies_Error:{excep.Message}");
			}
		}

		public void Get_Financial_Group_Unrelated_Companies(int inGroupID)
		{

			StringBuilder strCompInfo = new StringBuilder();
			pnl_EFIG.Visible = false;
			pnlEFIG_Add_Group.Visible = false;
			pnlEFIG_Delete.Visible = false;
			pnlEFIG_NIOL.Visible = false;
			grd_RelatedCompanies.Visible = false;
			bolPanelJump = false;

			grd_RelatedCompanies.Clear();
			//'''''''''''''''''''''''''''''''''''
			// Build the header
			//'''''''''''''''''''''''''''''''''''
			grd_RelatedCompanies.ColumnsCount = 5;
			grd_RelatedCompanies.RowsCount = 2;
			grd_RelatedCompanies.FixedRows = 1;
			grd_RelatedCompanies.FixedColumns = 0;

			grd_RelatedCompanies.CurrentRowIndex = 0;
			grd_RelatedCompanies.CurrentColumnIndex = 0;
			grd_RelatedCompanies[grd_RelatedCompanies.CurrentRowIndex, grd_RelatedCompanies.CurrentColumnIndex].Value = "Financial Group";
			grd_RelatedCompanies.SetColumnWidth(0, 200);

			grd_RelatedCompanies.CurrentColumnIndex = 1;
			grd_RelatedCompanies[grd_RelatedCompanies.CurrentRowIndex, grd_RelatedCompanies.CurrentColumnIndex].Value = "Main ID";

			grd_RelatedCompanies.CurrentColumnIndex = 2;
			grd_RelatedCompanies[grd_RelatedCompanies.CurrentRowIndex, grd_RelatedCompanies.CurrentColumnIndex].Value = "Unrelated Related Company";
			grd_RelatedCompanies.SetColumnWidth(2, 280);

			grd_RelatedCompanies.CurrentColumnIndex = 3;
			grd_RelatedCompanies[grd_RelatedCompanies.CurrentRowIndex, grd_RelatedCompanies.CurrentColumnIndex].Value = "Comp ID";
			grd_RelatedCompanies.SetColumnWidth(3, 53);

			grd_RelatedCompanies.CurrentColumnIndex = 4;
			grd_RelatedCompanies[grd_RelatedCompanies.CurrentRowIndex, grd_RelatedCompanies.CurrentColumnIndex].Value = "#Docs";
			grd_RelatedCompanies.SetColumnWidth(4, 47);

			// sum the tcount field
			int docCount = 0;

			string Query = "select fipg_generic_name, fipg_main_comp_id, comp_name, comp_city, comp_state, comp_id, ";
			Query = $"{Query}(select count(*) from aircraft_document WITH (NOLOCK) where adoc_infavor_comp_id=comp_id) as tcount ";
			Query = $"{Query}From Company_Reference WITH (NOLOCK) ";
			Query = $"{Query}INNER JOIN Company WITH (NOLOCK) on compref_rel_comp_id = comp_id and compref_journ_id = comp_journ_id ";
			Query = $"{Query}inner join Financial_Institution_Primary_Group WITH (NOLOCK) on compref_comp_id = fipg_main_comp_id ";
			Query = $"{Query}Where compref_journ_id = 0 ";

			Query = $"{Query}and compref_contact_type in ('59','1T','83') ";
			if (inGroupID != 0)
			{
				Query = $"{Query}and fipg_main_comp_id={inGroupID.ToString()} ";
			}
			Query = $"{Query}and compref_rel_comp_id not in( ";
			Query = $"{Query}select distinct ficr_sub_comp_id from Financial_Institution_Company_Reference WITH (NOLOCK) ";
			Query = $"{Query}where ficr_active_flag='Y') order by fipg_generic_name ";


			ADORecordSetHelper RS_FinCompList = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");
			int aCounter = 0;
			if (!(RS_FinCompList.EOF && RS_FinCompList.BOF))
			{
				//grd_RelatedCompanies
				grd_RelatedCompanies.CurrentRowIndex = 1;

				while(!RS_FinCompList.EOF)
				{

					grd_RelatedCompanies.CurrentColumnIndex = 0;
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(RS_FinCompList["fipg_generic_name"]))
					{
						grd_RelatedCompanies[grd_RelatedCompanies.CurrentRowIndex, grd_RelatedCompanies.CurrentColumnIndex].Value = $" {Convert.ToString(RS_FinCompList["fipg_generic_name"])}";
					}

					grd_RelatedCompanies.CurrentColumnIndex = 1;
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(RS_FinCompList["fipg_main_comp_id"]))
					{
						grd_RelatedCompanies[grd_RelatedCompanies.CurrentRowIndex, grd_RelatedCompanies.CurrentColumnIndex].Value = Convert.ToString(RS_FinCompList["fipg_main_comp_id"]);
					}

					strCompInfo = new StringBuilder("");
					grd_RelatedCompanies.CurrentColumnIndex = 2;
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(RS_FinCompList["comp_name"]))
					{
						strCompInfo = new StringBuilder(Convert.ToString(RS_FinCompList["comp_name"]));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(RS_FinCompList["comp_city"]))
						{
							strCompInfo.Append($", {Convert.ToString(RS_FinCompList["comp_city"])}");
						}
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(RS_FinCompList["comp_state"]))
						{
							strCompInfo.Append($", {Convert.ToString(RS_FinCompList["comp_state"])}");
						}
						grd_RelatedCompanies[grd_RelatedCompanies.CurrentRowIndex, grd_RelatedCompanies.CurrentColumnIndex].Value = $" {strCompInfo.ToString()}";
					}


					grd_RelatedCompanies.CurrentColumnIndex = 3;
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(RS_FinCompList["comp_id"]))
					{
						grd_RelatedCompanies[grd_RelatedCompanies.CurrentRowIndex, grd_RelatedCompanies.CurrentColumnIndex].Value = Convert.ToString(RS_FinCompList["comp_id"]);
					}

					grd_RelatedCompanies.CurrentColumnIndex = 4;
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(RS_FinCompList["tcount"]))
					{
						grd_RelatedCompanies[grd_RelatedCompanies.CurrentRowIndex, grd_RelatedCompanies.CurrentColumnIndex].Value = Convert.ToString(RS_FinCompList["tcount"]);
						docCount = Convert.ToInt32(docCount + Convert.ToDouble(RS_FinCompList["tcount"]));
					}

					grd_RelatedCompanies.RowsCount++;
					grd_RelatedCompanies.CurrentRowIndex++;

					RS_FinCompList.MoveNext();
					aCounter++;
				};
				grd_RelatedCompanies.RowsCount--;
				grd_RelatedCompanies.CurrentRowIndex = 1;
			}
			RS_FinCompList.Close();
			lbl_UnRel_Comps.Text = $"Unrelated of companies: {aCounter.ToString()}";
			lbl_UnRel_Docs.Text = $"Unrelated of documents: {docCount.ToString()}";

			grd_RelatedCompanies.Visible = true;
			pnl_EFIG.Visible = true;

		}
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}