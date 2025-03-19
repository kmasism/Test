using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
using System;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Gui;
using UpgradeHelpers.Gui.Controls;
using UpgradeHelpers.Gui.Utils;
using UpgradeHelpers.Helpers;
using UpgradeStubs;

namespace JETNET_Homebase
{
	public partial class frm_Find_Company //gap-note Manual change to fix Inconsistent accessibility error
		: System.Windows.Forms.Form
	{


		//private vars
		private bool gbCompTimer1DoubleClick = false;
		private bool gbCompTimer1SingleClick = false;

		private bool bACProsClicked = false;
		private bool bAwaitingDocsCompany = false;
		private bool bIsHistorical = false;
		private bool bIsStopped = false;

		private bool bIsFormLoad = false;
		private bool bIsFirstTime = false;
		private bool bIsSetDupeOptions = false;
		private bool bClickedAssociate = false;

		private modGlobalVars.e_find_form_entry_points tFormEntryPoint = (modGlobalVars.e_find_form_entry_points) 0;
		private modGlobalVars.e_find_form_action_types tFormActionTypes = (modGlobalVars.e_find_form_action_types) 0;
		private modGlobalVars.t_find_form_exit_record tFormExitValues = modGlobalVars.t_find_form_exit_record.CreateInstance();

		private string sReference_AccountRep = "";
		private string sReference_ContactType = "";
		private string sReference_HistContactName = "";
		private string sReference_HistContactType = "";
		private string sReference_CompanyName = "";

		private string sOrderBy = "";
		private string sContinentlist = "";
		private string sRegionlist = "";
		private string sCountrylist = "";
		private string sStatelist = "";

		private int iClickSpeed = 0;
		private int iRememberLastRow = 0;

		private int nReference_AircraftID = 0;
		private int nReference_JournalID = 0;
		private int nReference_CompanyID = 0;

		private int nReference_ContactID = 0;
		private int nReference_AwaitingDocsID = 0;

		private string sFormCollectionKey = "";

		private int nDuplicate_CompanyID = 0;
		private int nDuplicate_JournalID = 0;
		public bool from_company = false;

		public string fc_company_address1 = "";
		public string fc_company_address2 = "";
		public string fc_comp_zip = "";
		public string fc_comp_email = "";
		public string fc_comp_city = "";
		public string fc_comp_state = "";
		public string fc_comp_country = "";
		public string fc_comp_agency = "";
		public string fc_comp_business_type = "";
		public string fc_comp_language = "";
		public string fc_comp_account_rep = "";
		public string fc_comp_product = "";
		public string fc_comp_account_type = "";
		public frm_Find_Company()
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



		public void SetCompId(string strCompId) => txt_company_id[0].Text = strCompId.Trim();


		private void Refresh_Form_Pnl_Lbl_Txt()
		{
			Control Control_Obj = null;

			//UPGRADE_WARNING: (2065) Form property frm_Find_Company.Controls has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
			foreach (Control Control_ObjIterator in ContainerHelper.Controls(this))
			{
				Control_Obj = Control_ObjIterator;
				if ((Control_Obj is Panel) || (Control_Obj is Label) || (Control_Obj is TextBox))
				{
					Control_Obj.Refresh();
				}
				//Control_Obj
				Control_Obj = default(Control);
			}

		}

		private void cbo_contact_type_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{

			if (modCommon.pubf_EncodeEntryPoints(tFormEntryPoint) == modGlobalVars.gFIND_ACOR)
			{

				if (cbo_contact_type.Text.IndexOf('/') >= 0)
				{
					cbo_relationship.Items.Clear();
					cbo_relationship.AddItem(cbo_contact_type.Text.Substring(0, Math.Min(cbo_contact_type.Text.IndexOf('/'), cbo_contact_type.Text.Length)));
					cbo_relationship.SetItemData(cbo_relationship.Items.Count - 1, cbo_contact_type.GetItemData(cbo_contact_type.SelectedIndex));
					cbo_relationship.AddItem(cbo_contact_type.Text.Substring(Math.Max(cbo_contact_type.Text.Length - (Strings.Len(cbo_contact_type.Text) - (cbo_contact_type.Text.IndexOf('/') + 1)), 0)));
					cbo_relationship.SetItemData(cbo_relationship.Items.Count - 1, cbo_contact_type.GetItemData(cbo_contact_type.SelectedIndex));
					cbo_relationship.SelectedIndex = -1;
				}
				else
				{
					cbo_relationship.Items.Clear();
					cbo_relationship.AddItem(cbo_contact_type.Text);
					cbo_relationship.SetItemData(cbo_relationship.Items.Count - 1, cbo_contact_type.GetItemData(cbo_contact_type.SelectedIndex));
					cbo_relationship.SelectedIndex = -1;
				}

				pnl_company_info.Visible = false;
				pnl_contact_info.Visible = false;

				pnl_company_relationships.Visible = pnl_associate_aircraft.Visible && nReference_CompanyID > 0;

				lst_company1.Visible = false;

				if (nReference_CompanyID > 0)
				{
					modCommon.Build_Company_NameAddress(lst_company1, nReference_CompanyID, 0);
					lst_company1.Visible = true;
				}

				if (cbo_contact_type.Visible && nReference_CompanyID > 0)
				{
					cbo_relationship.Visible = true;
					lbl_Label1[27].Visible = true;
				}

				pnl_company_relationships.Refresh();

			}
			else
			{
				if (modCommon.pubf_EncodeEntryPoints(tFormEntryPoint) != modGlobalVars.gFIND_EXBK)
				{
					sReference_ContactType = modCompanyFind.Select_Contact_Type(cbo_contact_type, tFormEntryPoint);
				}
			}

		}

		private void cbo_Unknown_Country_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{

			if (!bIsFormLoad)
			{

				modFillCompConControls.Check_If_Country_HasState(cbo_unknown_state, cbo_unknown_country);

			}

		}

		private void cbo_Unknown_State_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{

			if (!bIsFormLoad)
			{
				modFillCompConControls.Select_Unknown_Country(cbo_unknown_state, cbo_unknown_country);
			}

		}

		private void chk_dup_include_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{

			for (int K = 3; K <= 5; K++)
			{

				opt_dup_sortby[K].Enabled = true;

			}

			for (int K = 0; K <= 2; K++)
			{

				if (chk_dup_include[K].CheckState == CheckState.Unchecked)
				{

					opt_dup_sortby[0].Checked = true;

					switch(K)
					{
						case 0 : 
							opt_dup_sortby[3].Enabled = false; 
							break;
						case 1 : 
							opt_dup_sortby[4].Enabled = false; 
							break;
						case 2 : 
							opt_dup_sortby[5].Enabled = false; 
							 
							break;
					}

				}

			}

		}

		private bool set_potential_dupe_options()
		{


			txt_dup_num_chars.Visible = true;
			lbl_Label1[29].Visible = true;

			for (int X = 0; X <= 6; X++)
			{

				if (X < 3)
				{
					chk_dup_include[X].Visible = true;
				}

				opt_dup_sortby[X].Visible = true;

				if (X == 2 || X == 6)
				{
					opt_dup_sortby[X].Visible = false;
				}

			}

			opt_dup_sortby[0].Checked = true;

			if (chk_dup_phone.CheckState == CheckState.Checked)
			{

				bIsSetDupeOptions = true;
				chk_dup_contacts.CheckState = CheckState.Unchecked;
				bIsSetDupeOptions = false;

				txt_dup_num_chars.Visible = false;
				lbl_Label1[29].Visible = false;

				for (int X = 0; X <= 6; X++)
				{

					opt_dup_sortby[0].Visible = false;

					if (X < 3)
					{
						chk_dup_include[X].CheckState = CheckState.Checked;
						chk_dup_include[X].Visible = false;
					}

					if (X == 6)
					{
						opt_dup_sortby[X].Visible = true;
						opt_dup_sortby[X].Checked = true;
					}

				}

			}
			else if (chk_dup_contacts.CheckState == CheckState.Checked)
			{ 

				bIsSetDupeOptions = true;
				chk_dup_phone.CheckState = CheckState.Unchecked;
				bIsSetDupeOptions = false;

				txt_dup_num_chars.Visible = false;
				lbl_Label1[29].Visible = false;

				for (int X = 0; X <= 6; X++)
				{

					opt_dup_sortby[X].Visible = false;

					if (X < 3)
					{
						chk_dup_include[X].CheckState = CheckState.Checked;
					}

					if (X == 2)
					{
						opt_dup_sortby[X].Visible = true;
						opt_dup_sortby[X].Checked = true;
					}

				}

			}

			return true;

		}

		private void chk_dup_contacts_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{

			if (!bIsSetDupeOptions)
			{
				set_potential_dupe_options();
			}

		}


		private void chk_dup_phone_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{

			if (!bIsSetDupeOptions)
			{
				set_potential_dupe_options();
			}

		}

		private void chk_hide_zero_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{

			chk_share_relationships.CheckState = CheckState.Unchecked;
			chk_share_relationships_withoutAC.CheckState = CheckState.Unchecked;
			chk_show_yacht_count.CheckState = CheckState.Unchecked;
			chk_history.CheckState = CheckState.Unchecked;

		}

		private void chk_inactives_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{



		}

		private void chk_prod_code_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.chk_prod_code, eventSender);

			Application.DoEvents();
			Application.DoEvents();
			Application.DoEvents();
			if (Index == 3)
			{
				if (chk_prod_code[3].CheckState == CheckState.Checked)
				{
					modFillCompConControls.fill_businesstype_FromArray(cbo_business_type);
				}
				else
				{
					modFillCommonArrays.Fill_BusinessType_Array(true); // run while ignoring yachts
					modFillCompConControls.fill_businesstype_FromArray(cbo_business_type);
					modFillCommonArrays.Fill_BusinessType_Array(false); // run to fix array, to not ignore yachts
				}
			}

		}

		private void chk_show_yacht_count_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{

			if (chk_show_yacht_count.CheckState == CheckState.Checked)
			{

				chk_share_relationships.CheckState = CheckState.Unchecked;
				chk_share_relationships_withoutAC.CheckState = CheckState.Unchecked;
				chk_aircraft_count.CheckState = CheckState.Unchecked;
				chk_hide_zero.CheckState = CheckState.Unchecked;
				chk_history.CheckState = CheckState.Unchecked;

			} // If chk_show_yacht_count.Value = vbChecked Then

		} // chk_show_yacht_count_Click

		private void cmd_Add_Company_Click(Object eventSender, EventArgs eventArgs)
		{

			Form Obj = null;

			bool bIsAllReadyOpen = false;

			foreach (Form ObjIterator in Application.OpenForms)
			{
				Obj = ObjIterator;
				if (String.Compare(Obj.Name, "frm_CompanyAdd", true) == 0)
				{
					bIsAllReadyOpen = true;
					break;
				}
				//Obj
				Obj = default(Form);
			}

			modGlobalVars.new_frm_CompanyAdd.ca_company_address1 = fc_company_address1;
			modGlobalVars.new_frm_CompanyAdd.ca_company_address2 = fc_company_address2;
			modGlobalVars.new_frm_CompanyAdd.ca_comp_email = fc_comp_email;
			modGlobalVars.new_frm_CompanyAdd.ca_comp_city = fc_comp_city;
			modGlobalVars.new_frm_CompanyAdd.ca_comp_agency = fc_comp_agency;
			modGlobalVars.new_frm_CompanyAdd.ca_comp_language = fc_comp_language;
			modGlobalVars.new_frm_CompanyAdd.ca_comp_account_rep = fc_comp_account_rep;
			modGlobalVars.new_frm_CompanyAdd.ca_comp_zip = fc_comp_zip;

			modGlobalVars.new_frm_CompanyAdd.ca_comp_state = fc_comp_state;
			modGlobalVars.new_frm_CompanyAdd.ca_comp_country = fc_comp_country;

			modGlobalVars.new_frm_CompanyAdd.ca_comp_product = fc_comp_product;
			modGlobalVars.new_frm_CompanyAdd.ca_comp_business_type = fc_comp_business_type;
			modGlobalVars.new_frm_CompanyAdd.ca_comp_account_type = fc_comp_account_type;


			modGlobalVars.new_frm_CompanyAdd.cmd_copy_company.Visible = true;


			if (!bIsAllReadyOpen)
			{
				modGlobalVars.new_frm_CompanyAdd.Show();
			}
			else
			{
				modGlobalVars.new_frm_CompanyAdd.BringToFront(); //gap-note Manual change to fix BringToFront rule failing sometimes
			}

		}

		private void cmd_Add_Contact_Click(Object eventSender, EventArgs eventArgs)
		{

			frm_CompanyContact new_frm_CompanyContact = frm_CompanyContact.CreateInstance();

			new_frm_CompanyContact.nCompanyID = grd_find_company.get_RowData(grd_find_company.CurrentRowIndex);

			if (chk_history.CheckState == CheckState.Checked)
			{
				grd_find_company.CurrentColumnIndex = 16;
				new_frm_CompanyContact.nJournID = Convert.ToInt32(Double.Parse(grd_find_company[grd_find_company.CurrentRowIndex, grd_find_company.CurrentColumnIndex].FormattedValue.ToString()));
			}
			else
			{
				new_frm_CompanyContact.nJournID = 0;
			}

			new_frm_CompanyContact.ServicesUsed = modCommon.GetCompanyServiceName(frm_CompanyContact.DefInstance.nCompanyID, frm_CompanyContact.DefInstance.nJournID, modGlobalVars.ServicesUsed_Array);
			new_frm_CompanyContact.CompanyName_Renamed = modCommon.GetCompanyName(frm_CompanyContact.DefInstance.nCompanyID, frm_CompanyContact.DefInstance.nJournID);
			new_frm_CompanyContact.nContactID = -1;

			new_frm_CompanyContact.ShowDialog();

			new_frm_CompanyContact = null;

			this.Show();
			this.Activate();

		}

		private void cmd_Add_contact_trial_Click(Object eventSender, EventArgs eventArgs)
		{


			int nCompanyID = 0;
			nCompanyID = Convert.ToInt32(Double.Parse(grd_find_company.get_RowData(grd_find_company.CurrentRowIndex).ToString().Trim()));

			frm_Subscription.DefInstance.cmd_find_contact[0].Tag = nCompanyID.ToString();
			frm_Subscription.DefInstance.Fill_CBO_Contact(nCompanyID, "", "", "", "");

			Hide_MySelf();
			this.Close();

			frm_Subscription.DefInstance.Show();
			//UPGRADE_WARNING: (2065) Form method frm_Subscription.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
			frm_Subscription.DefInstance.BringToFront();
			frm_Subscription.DefInstance.Activate();

			cmd_Add_contact_trial.Visible = false;


		}

		private void cmd_add_to_pub_Click(Object eventSender, EventArgs eventArgs)
		{

			int nCompanyID = 0;
			nCompanyID = Convert.ToInt32(Double.Parse(grd_find_company.get_RowData(grd_find_company.CurrentRowIndex).ToString().Trim()));

			frm_WebCrawl.DefInstance.txt_pub[6].Text = nCompanyID.ToString();
			frm_WebCrawl.DefInstance.account_rep = Convert.ToString(cmd_add_to_pub.Tag);
			frm_WebCrawl.DefInstance.assign_correct_account_rep();

			Hide_MySelf();
			this.Close();
			frm_WebCrawl.DefInstance.Activate();

		}

		private void cmd_Clear_Click(Object eventSender, EventArgs eventArgs) => Clear_Search_Criteria(true, true, true);


		private void cmd_close_duplicates_Click(Object eventSender, EventArgs eventArgs)
		{

			pnl_duplicates.Visible = false;
			pnl_contact_info.Visible = false;

		}

		private void cmd_dup_hide_grid_frame_Click(Object eventSender, EventArgs eventArgs)
		{

			frame_potential_dups_grid.Visible = false;
			mnuUnHideDupGrid.Available = true;

		}

		private void cmd_dup_paste_to_clipboard_Click(Object eventSender, EventArgs eventArgs)
		{
			string sTmp = "";

			Clipboard.Clear();

			int tempForEndVar = grd_potential_duplicates.RowsCount - 1;
			for (int R = 0; R <= tempForEndVar; R++)
			{
				int tempForEndVar2 = grd_potential_duplicates.ColumnsCount - 1;
				for (int C = 0; C <= tempForEndVar2; C++)
				{
					sTmp = $"{sTmp}{Convert.ToString(grd_potential_duplicates[R, C].Value)}{"\t"}";
				}
				sTmp = $"{sTmp}{Environment.NewLine}";
			}

			//UPGRADE_WARNING: (2081) Clipboard.SetText has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
			Clipboard.SetText(sTmp);

			sTmp = "";

		}

		private void cmd_dup_stop_grid_fill_Click(Object eventSender, EventArgs eventArgs) => bIsStopped = true;


		private void cmd_dup_stop_grid_fill_MouseMove(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;

			if (this.Cursor == Cursors.WaitCursor)
			{
				this.Cursor = CursorHelper.CursorDefault;
			}

		}

		public void cmd_find_Click(Object eventSender, EventArgs eventArgs)
		{

			cmdCompanyListExcelExport.Visible = false;
			bACProsClicked = false;
			pnl_duplicates.Visible = false;
			frame_potential_dups.Visible = false;
			frame_potential_dups_grid.Visible = false;

			sContinentlist = "";
			sRegionlist = "";
			sCountrylist = "";
			sStatelist = "";
			sOrderBy = "";

			Set_DemographicList(ref sContinentlist, ref sRegionlist, ref sCountrylist, ref sStatelist);
			Set_Sort_Order(ref sOrderBy, true);
			fill_find_company_Grd(ref sOrderBy);

		}

		private void cmd_AcPros_Click(Object eventSender, EventArgs eventArgs)
		{

			bACProsClicked = true;
			fill_find_company_Grd(ref sOrderBy);

		}

		private void cmd_find_duplicate_Click(Object eventSender, EventArgs eventArgs)
		{

			int nMatchCharacterCount = 0;

			int nCompanyID = Convert.ToInt32(Double.Parse(grd_find_company.get_RowData(grd_find_company.CurrentRowIndex).ToString().Trim()));
			//UPGRADE_ISSUE: (2064) MSHierarchicalFlexGridLib.MSHFlexGrid property grd_find_company.BandData was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			int nContactID = Convert.ToInt32(Double.Parse(grd_find_company.BandData(grd_find_company.CurrentRowIndex).ToString().Trim()));

			lst_duplicates.Items.Clear();

			if (modCommon.pubf_EncodeEntryPoints(tFormEntryPoint) == modGlobalVars.gFIND_FDMF)
			{

				bClickedAssociate = true;

				tFormExitValues.nFoundAircraftCompID = nCompanyID;

				if (opt_contacts.Checked)
				{
					tFormExitValues.nFoundContactID = nContactID;
				}
				else
				{
					tFormExitValues.nFoundContactID = 0;
				}

				Hide_MySelf();

			}
			else
			{

				if (Conversion.Val(txt_num_characters.Text) > 0 && txt_num_characters.Text != "")
				{
					nMatchCharacterCount = Convert.ToInt32(Conversion.Val(txt_num_characters.Text));
				}
				else
				{
					nMatchCharacterCount = 0;
				}

				modCompanyFind.Fill_Potential_Duplicate_List(nMatchCharacterCount, chk_match_city.CheckState, nCompanyID, lst_duplicates, pnl_duplicates, grd_find_company, opt_contacts.Checked);
				cmd_remove_duplicates.Visible = false;

			}

		}

		private void cmd_find_potential_dup_Click(Object eventSender, EventArgs eventArgs)
		{

			string Query = "";
			ADORecordSetHelper ado_Dups = new ADORecordSetHelper();
			int CurRow = 0;
			int MaxRow = 0;
			string sNumChars = "";
			bool IncludeAddress = false;
			bool IncludeState = false;
			bool IncludeCity = false;
			string SortOrder = "";
			string AcctRep = "";

			try
			{

				bIsStopped = false;
				mnuUnHideDupGrid.Available = true;

				pnl_search_results.Visible = false;

				grd_potential_duplicates.Clear();
				grd_potential_duplicates.RowsCount = 2;
				grd_potential_duplicates.ColumnsCount = 5;

				sNumChars = txt_dup_num_chars.Text;

				if (cbo_dup_account_rep.Text.Trim() != "")
				{
					AcctRep = cbo_dup_account_rep.Text.Trim();
				}

				IncludeAddress = chk_dup_include[0].CheckState != CheckState.Unchecked;
				IncludeState = chk_dup_include[1].CheckState != CheckState.Unchecked;
				IncludeCity = chk_dup_include[2].CheckState != CheckState.Unchecked;

				SortOrder = "";

				if (chk_dup_sort.CheckState == CheckState.Checked)
				{
					SortOrder = " DESC ";
				}

				Clear_Search_Criteria(true, false, true);

				if (chk_dup_phone.CheckState == CheckState.Checked)
				{
					opt_dup_sortby[6].Checked = true;
				}
				else if (chk_dup_contacts.CheckState == CheckState.Checked)
				{ 
					opt_dup_sortby[2].Checked = true;
				}
				else
				{
					opt_dup_sortby[6].Checked = false;
					opt_dup_sortby[2].Checked = false;
				}

				Wait_Pnl_On("Search for Potential Duplicates....");

				Query = "";

				lbl_Label1[33].Text = "";

				if (chk_dup_phone.CheckState == CheckState.Checked)
				{
					//alternate way of looking for dups: companies with the same phone number
					Query = "SELECT distinct comp_name_search as comp_search";
				}
				else if (chk_dup_contacts.CheckState == CheckState.Checked)
				{ 
					//alternate way of looking for dups: companies with the same phone number
					Query = "SELECT distinct comp_name_search as comp_search";
				}
				else
				{
					//duplicates with similiar company names
					Query = $"SELECT left(comp_name_search,{sNumChars}) AS comp_search";
				}

				if (IncludeAddress)
				{
					Query = $"{Query},comp_address1";
				}

				if (IncludeCity)
				{
					Query = $"{Query},comp_city";
				}

				if (IncludeState)
				{
					Query = $"{Query},comp_state";
				}

				if (chk_dup_phone.CheckState == CheckState.Checked)
				{

					Query = $"{Query},pnum_number_full_search as freq from company";
					Query = $"{Query} INNER JOIN Phone_Numbers WITH(NOLOCK) ON comp_id = pnum_comp_id";
					Query = $"{Query} WHERE pnum_number_full_search in(";
					Query = $"{Query} SELECT pnum_number_full_search from Phone_Numbers WITH(NOLOCK)";
					Query = $"{Query} WHERE pnum_journ_id = 0 group by pnum_number_full_search having count(*)>1 )";
					Query = $"{Query} AND comp_journ_id = 0 AND comp_acpros_flag='N'  ";

					if (chk_inactives.CheckState == CheckState.Checked)
					{
						Query = $"{Query} AND (comp_active_flag IN('N','Y')) ";
					}
					else
					{
						Query = $"{Query} AND (comp_active_flag = 'Y') ";
					}

					Query = $"{Query}AND (comp_awaitdoc_flag = 'N') ";
					Query = $"{Query}AND (comp_city IS NOT NULL) AND (comp_address1 IS NOT NULL) ";

					if (AcctRep != "All" && AcctRep != "")
					{
						Query = $"{Query}AND (comp_account_id='{AcctRep}') ";
					}

					if (chk_exclude_comp_to_comp.CheckState == CheckState.Checked)
					{
						Query = $"{Query} AND not exists ( SELECT compref_comp_id FROM Company_Reference WITH(NOLOCK)";
						Query = $"{Query} WHERE compref_journ_id = 0 AND (compref_comp_id = Comp_id Or compref_rel_comp_id = Comp_id))";
					}

				}
				else if (chk_dup_contacts.CheckState == CheckState.Checked)
				{ 

					Query = $"{Query},(contact_last_name + Contact_first_name) as freq";
					Query = $"{Query} FROM company WITH(NOLOCK) INNER JOIN contact WITH(NOLOCK) ON comp_id = contact_comp_id and comp_journ_id = contact_journ_id";
					Query = $"{Query} WHERE (contact_last_name + contact_first_name) IN( SELECT (contact_last_name + Contact_first_name)";
					Query = $"{Query} FROM contact WITH(NOLOCK) WHERE contact_journ_id = 0 AND contact_active_flag='Y' AND";
					Query = $"{Query} isnull(contact_last_name,'') <> '' AND isnull(contact_first_name,'') <> ''";
					Query = $"{Query} group by contact_last_name,Contact_first_name having count(*)>1 )";
					Query = $"{Query} AND comp_journ_id = 0 AND comp_acpros_flag='N' ";

					if (chk_inactives.CheckState == CheckState.Checked)
					{
						Query = $"{Query}AND (comp_active_flag IN ('N','Y')) ";
					}
					else
					{
						Query = $"{Query}AND (comp_active_flag = 'Y') ";
					}

					Query = $"{Query} AND comp_awaitdoc_flag = 'N' AND comp_city IS NOT NULL";
					Query = $"{Query} AND comp_address1 IS NOT NULL";

					if (AcctRep != "All" && AcctRep != "")
					{
						Query = $"{Query} AND comp_account_id='{AcctRep}'";
					}

					if (chk_exclude_comp_to_comp.CheckState == CheckState.Checked)
					{
						Query = $"{Query} AND not exists ( SELECT compref_comp_id FROM Company_Reference WITH(NOLOCK) ";
						Query = $"{Query} WHERE compref_journ_id = 0 AND (compref_comp_id = Comp_id Or compref_rel_comp_id = Comp_id)) ";
					}

					Query = $"{Query} Group By(contact_last_name + contact_first_name), comp_name_search, comp_address1, comp_city, comp_state ";

				}
				else
				{

					Query = $"{Query},COUNT(*) AS freq FROM Company WITH(NOLOCK) ";
					Query = $"{Query} WHERE comp_journ_id = 0 AND comp_acpros_flag='N'  ";

					if (chk_inactives.CheckState == CheckState.Checked)
					{
						Query = $"{Query}AND (comp_active_flag IN ('N','Y')) ";
					}
					else
					{
						Query = $"{Query}AND (comp_active_flag = 'Y') ";
					}

					Query = $"{Query} AND comp_awaitdoc_flag = 'N' AND comp_city IS NOT NULL";
					Query = $"{Query} AND comp_address1 IS NOT NULL";

					if (AcctRep != "All" && AcctRep != "")
					{
						Query = $"{Query} AND comp_account_id='{AcctRep}'";
					}

					if (chk_exclude_comp_to_comp.CheckState == CheckState.Checked)
					{
						Query = $"{Query} AND not exists ( SELECT compref_comp_id FROM Company_Reference WITH(NOLOCK)";
						Query = $"{Query} WHERE compref_journ_id = 0 AND (compref_comp_id = Comp_id Or compref_rel_comp_id = Comp_id))";
					}

					Query = $"{Query} GROUP BY left(comp_name_search,{sNumChars})";

					if (IncludeAddress)
					{
						Query = $"{Query},comp_address1";
					}

					if (IncludeCity)
					{
						Query = $"{Query},comp_city";
					}

					if (IncludeState)
					{
						Query = $"{Query},comp_state";
					}


					Query = $"{Query} Having (Count(Comp_id) > 1)";

				}

				if (opt_dup_sortby[0].Checked)
				{
					Query = $"{Query} ORDER BY COUNT(comp_id) {SortOrder} , left(comp_name_search,{sNumChars})";
				}
				else if (opt_dup_sortby[1].Checked)
				{ 
					Query = $"{Query} ORDER BY left(comp_name_search,{sNumChars}) {SortOrder}";
				}
				else if (opt_dup_sortby[2].Checked)
				{ 
					Query = $"{Query} ORDER BY (contact_last_name + contact_first_name), comp_name_search";
				}
				else if (opt_dup_sortby[3].Checked)
				{ 
					Query = $"{Query} ORDER BY comp_address1 {SortOrder}";
				}
				else if (opt_dup_sortby[4].Checked)
				{ 
					Query = $"{Query} ORDER BY comp_city {SortOrder}";
				}
				else if (opt_dup_sortby[5].Checked)
				{ 
					Query = $"{Query} ORDER BY comp_state {SortOrder}";
				}
				else if (opt_dup_sortby[6].Checked)
				{ 
					Query = $"{Query} ORDER BY pnum_number_full_search {SortOrder}";

					if (IncludeAddress)
					{
						Query = $"{Query},comp_address1";
					}

					if (IncludeCity)
					{
						Query = $"{Query},comp_city";
					}

					if (IncludeState)
					{
						Query = $"{Query},comp_state";
					}

				}

				cmd_dup_stop_grid_fill.Visible = true;
				cmd_dup_hide_grid_frame.Visible = false;

				frame_potential_dups_grid.Visible = true;

				grd_potential_duplicates.CurrentRowIndex = 0;
				grd_potential_duplicates.CurrentColumnIndex = 0;
				grd_potential_duplicates[grd_potential_duplicates.CurrentRowIndex, grd_potential_duplicates.CurrentColumnIndex].Value = "Search Name";
				grd_potential_duplicates.CurrentColumnIndex = 1;
				grd_potential_duplicates[grd_potential_duplicates.CurrentRowIndex, grd_potential_duplicates.CurrentColumnIndex].Value = "City";
				grd_potential_duplicates.CurrentColumnIndex = 2;
				grd_potential_duplicates[grd_potential_duplicates.CurrentRowIndex, grd_potential_duplicates.CurrentColumnIndex].Value = "State";
				grd_potential_duplicates.CurrentColumnIndex = 3;
				grd_potential_duplicates[grd_potential_duplicates.CurrentRowIndex, grd_potential_duplicates.CurrentColumnIndex].Value = "Address";
				grd_potential_duplicates.CurrentColumnIndex = 4;

				if (chk_dup_phone.CheckState == CheckState.Checked)
				{
					grd_potential_duplicates[grd_potential_duplicates.CurrentRowIndex, grd_potential_duplicates.CurrentColumnIndex].Value = "Phone#";
					grd_potential_duplicates.SetColumnWidth(4, 80);
				}
				else if (chk_dup_contacts.CheckState == CheckState.Checked)
				{ 
					grd_potential_duplicates[grd_potential_duplicates.CurrentRowIndex, grd_potential_duplicates.CurrentColumnIndex].Value = "Contact";
					grd_potential_duplicates.SetColumnWidth(4, 80);
				}
				else
				{
					grd_potential_duplicates[grd_potential_duplicates.CurrentRowIndex, grd_potential_duplicates.CurrentColumnIndex].Value = "Count";
					grd_potential_duplicates.SetColumnWidth(4, 40);
				}

				grd_potential_duplicates.SetColumnWidth(0, 167);

				if (IncludeCity)
				{
					grd_potential_duplicates.SetColumnWidth(1, 100);
				}
				else
				{
					grd_potential_duplicates.SetColumnWidth(1, 0);
				}

				if (IncludeState)
				{
					grd_potential_duplicates.SetColumnWidth(2, 40);
				}
				else
				{
					grd_potential_duplicates.SetColumnWidth(2, 0);
				}

				if (IncludeAddress)
				{
					grd_potential_duplicates.SetColumnWidth(3, 200);
				}
				else
				{
					grd_potential_duplicates.SetColumnWidth(3, 0);
				}

				//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseClient);
				ado_Dups.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(ado_Dups.BOF && ado_Dups.EOF))
				{

					MaxRow = ado_Dups.RecordCount;
					CurRow = 0;

					Wait_Pnl_On(" Loading Potential Duplicates....");


					while(!ado_Dups.EOF)
					{

						if (bIsStopped)
						{
							break;
						}

						grd_potential_duplicates.RowsCount++;
						CurRow++;

						grd_potential_duplicates.CurrentRowIndex = CurRow;
						grd_potential_duplicates.CurrentColumnIndex = 0;
						grd_potential_duplicates.ColAlignment[0] = DataGridViewContentAlignment.TopLeft;
						grd_potential_duplicates[grd_potential_duplicates.CurrentRowIndex, grd_potential_duplicates.CurrentColumnIndex].Value = $"{Convert.ToString(ado_Dups["comp_search"])}";

						if (IncludeCity)
						{
							grd_potential_duplicates.CurrentColumnIndex = 1;
							grd_potential_duplicates[grd_potential_duplicates.CurrentRowIndex, grd_potential_duplicates.CurrentColumnIndex].Value = $"{Convert.ToString(ado_Dups["Comp_city"])}";
						}

						if (IncludeState)
						{
							grd_potential_duplicates.CurrentColumnIndex = 2;
							grd_potential_duplicates[grd_potential_duplicates.CurrentRowIndex, grd_potential_duplicates.CurrentColumnIndex].Value = $"{Convert.ToString(ado_Dups["comp_state"])}";
						}

						if (IncludeAddress)
						{
							grd_potential_duplicates.CurrentColumnIndex = 3;
							grd_potential_duplicates.ColAlignment[3] = DataGridViewContentAlignment.TopLeft;
							grd_potential_duplicates[grd_potential_duplicates.CurrentRowIndex, grd_potential_duplicates.CurrentColumnIndex].Value = $"{Convert.ToString(ado_Dups["comp_address1"])}";
						}

						grd_potential_duplicates.CurrentColumnIndex = 4;
						grd_potential_duplicates[grd_potential_duplicates.CurrentRowIndex, grd_potential_duplicates.CurrentColumnIndex].Value = ado_Dups.GetField("freq");

						lbl_Label1[33].Text = $"{CurRow.ToString()} out of {MaxRow.ToString()}";
						lbl_Label1[33].Refresh();

						if (chk_dup_confirm_non_dups.CheckState == CheckState.Checked)
						{

							Query = "";
							Query = "SELECT comp_id FROM company WITH(NOLOCK) WHERE comp_journ_id = 0";
							Query = $"{Query} AND comp_description LIKE '%Not a Duplicate%'";
							Query = $"{Query} AND comp_name_search LIKE '{Convert.ToString(ado_Dups["comp_search"])}%'";

							if (modAdminCommon.Exist(Query))
							{
								grd_potential_duplicates.CurrentColumnIndex = 0;
								grd_potential_duplicates.CellBackColor = Color.FromArgb(0, 192, 0);
							}

						}

						ado_Dups.MoveNext();

					};

					grd_potential_duplicates.RowsCount--;

				}

				Wait_Pnl_Off();

				lbl_Label1[33].Text = $"{CurRow.ToString()} Potential Duplicates";

				cmd_dup_stop_grid_fill.Visible = false;
				cmd_dup_hide_grid_frame.Visible = true;

				ado_Dups.Close();
				ado_Dups = null;
				//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseServer);

				this.Cursor = CursorHelper.CursorDefault;
			}
			catch (System.Exception excep)
			{

				Wait_Pnl_Off();

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"cmd_find_potential_dup_Error: {excep.Message} {Information.Err().Number.ToString()}");
				ado_Dups = null;
				//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseServer);
				return;
			}

		}

		private void cmd_hide_potential_dup_frame_Click(Object eventSender, EventArgs eventArgs)
		{

			frame_potential_dups.Visible = false;
			frame_potential_dups_grid.Visible = false;

		}

		private void cmd_refresh_Click(Object eventSender, EventArgs eventArgs)
		{

			if (grd_find_company.CurrentRowIndex > 0 && iRememberLastRow > 0)
			{
				iRememberLastRow = grd_find_company.CurrentRowIndex;
			}

			fill_find_company_Grd(ref sOrderBy);

		}

		private void cmd_awaiting_docsOK_Click(Object eventSender, EventArgs eventArgs)
		{

			bAwaitingDocsCompany = true;

			if (modCommon.pubf_EncodeEntryPoints(tFormEntryPoint) == modGlobalVars.gFIND_ACCH || modCommon.pubf_EncodeEntryPoints(tFormEntryPoint) == modGlobalVars.gFIND_CHCT)
			{
				cbo_contact_type.Visible = false;
			}
			else if (modCommon.pubf_EncodeEntryPoints(tFormEntryPoint) == modGlobalVars.gFIND_ADOC)
			{ 
				cbo_contact_type.Visible = false;
			}
			else if (modCommon.pubf_EncodeEntryPoints(tFormEntryPoint) == modGlobalVars.gFIND_ACCA)
			{ 
				cbo_contact_type.Visible = true;
			}

			cmd_Associate_Click(cmd_Associate, new EventArgs());

		}

		private void cmd_remove_duplicates_Click(Object eventSender, EventArgs eventArgs)
		{


			int nCompanyID = Convert.ToInt32(Double.Parse(grd_find_company.get_RowData(grd_find_company.CurrentRowIndex).ToString().Trim()));

			Wait_Pnl_On("Submitting Duplicate for Removal.");

			modCompanyFind.Remove_Duplicate(nCompanyID, nDuplicate_CompanyID, nDuplicate_JournalID, pnl_duplicates, chk_history.CheckState);

			pnl_duplicates.Visible = false;

			Wait_Pnl_Off();

		}

		private void cmd_sale_source_Click(Object eventSender, EventArgs eventArgs)
		{

			int nCompanyID = 0;
			nCompanyID = Convert.ToInt32(Double.Parse(grd_find_company.get_RowData(grd_find_company.CurrentRowIndex).ToString().Trim()));
			Application.DoEvents();
			Application.DoEvents();
			Application.DoEvents();
			Application.DoEvents();
			frm_aircraft.DefInstance.txt_ac_sale_price.Tag = nCompanyID.ToString();
			Application.DoEvents();
			Application.DoEvents();
			Application.DoEvents();
			Application.DoEvents();
			Application.DoEvents();
			Application.DoEvents();
			Application.DoEvents();
			//  tFormExitValues.tEntryPoint = tFormEntryPoint
			Application.DoEvents();
			Application.DoEvents();
			Application.DoEvents();
			JetNetSupport.PInvoke.SafeNative.kernel32.Sleep(200);
			Application.DoEvents();
			Application.DoEvents();
			this.Close();
			JetNetSupport.PInvoke.SafeNative.kernel32.Sleep(200);
			Application.DoEvents();
			Application.DoEvents();
			Application.DoEvents();
			Application.DoEvents();
			Application.DoEvents();
			Application.DoEvents();
			Application.DoEvents();
			Application.DoEvents();
			Application.DoEvents();
			Application.DoEvents();
			Application.DoEvents();
			Application.DoEvents();
			Application.DoEvents();
			Application.DoEvents();
			Application.DoEvents();
			Application.DoEvents();
			Application.DoEvents();

		}

		private void cmdCompanyListExcelExport_Click(Object eventSender, EventArgs eventArgs)
		{

			cmdCompanyListExcelExport.Enabled = false;
			modExcel.ExportMSHFlexGrid(grd_find_company);
			cmdCompanyListExcelExport.Enabled = true;

		}

		//UPGRADE_NOTE: (7001) The following declaration (Set_Panels_Visible) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void Set_Panels_Visible(bool bVisible)
		//{
			//
			//pnl_aircraft_info.Visible = bVisible;
			//
			//pnl_company.Visible = bVisible;
			//pnl_company_demographics.Visible = bVisible;
			//
			//pnl_contact.Visible = bVisible;
			//
			//pnl_prod_code.Visible = bVisible;
			//
			//pnl_search.Visible = bVisible;
			//
			//cbo_MailList.Visible = bVisible;
			//lbl_List.Visible = bVisible;
			//
			//if (!bVisible)
			//{
				//pnl_associate_aircraft.Visible = bVisible;
				//pnl_company_relationships.Visible = bVisible;
				//pnl_contact_info.Visible = bVisible;
				//pnl_company_info.Visible = bVisible;
				//pnl_duplicates.Visible = bVisible;
				//pnl_search_results.Visible = bVisible;
				//pnl_wait_text.Visible = bVisible;
				//frame_awaiting_documentation.Visible = bVisible;
			//} // If bVisible = False Then
			//
		//} // Set_Panels_Visible

		private void Form_Activated(Object eventSender, EventArgs eventArgs)
		{
			if (ActivateHelper.myActiveForm != eventSender)
			{
				ActivateHelper.myActiveForm = (Form) eventSender;

				try
				{

					//Activate
					bAwaitingDocsCompany = false;

					tFormExitValues.tEntryPoint = tFormEntryPoint;
					tFormExitValues.sEntryPointText = modCommon.pubf_FindFormEntryPointsToString(tFormEntryPoint);

					bClickedAssociate = false;

					if (modAdminCommon.gbl_bHomeClicked)
					{

						this.Cursor = CursorHelper.CursorDefault;
						Hide_MySelf();

					}
					else
					{

						if (grd_find_company.RowsCount > 1)
						{
							pnl_search_results.Visible = Convert.ToString(grd_find_company[1, 0].Value) != "";
						}
						else
						{
							pnl_search_results.Visible = false;
						}

						pnl_company_info.Visible = false;
						pnl_contact_info.Visible = false;
						pnl_duplicates.Visible = false;

						frame_potential_dups.Visible = false;
						frame_potential_dups_grid.Visible = false;

						// TURN ON THE ADMINISTRATIVE FUNCTION FOR REMOVING DUPLICATE PHONE NUMBERS
						mnuEditRemoveDupPhones.Enabled = modAdminCommon.gbl_User_ID.ToUpper() == "MVIT" || modAdminCommon.gbl_User_ID.ToUpper() == "DCR";

						frame_potential_dups.Visible = false;
						frame_potential_dups_grid.Visible = false;

						modFillCompConControls.Fill_Contact_Type_ListFromArray(cbo_contact_type, lbl_Label1[27], tFormEntryPoint);

						// Temp Hold - 03/09/2017 - David D. Cruger
						//Call SetFormCaptionAndKey(tFormEntryPoint)

						if (modCommon.pubf_EncodeEntryPoints(tFormEntryPoint) != modGlobalVars.gFIND_NONE)
						{
							if (modCommon.pubf_EncodeEntryPoints(tFormEntryPoint) == modGlobalVars.gFIND_CHCT)
							{
								chk_history.Visible = true;
							}
							else
							{
								// chk_history.Value = vbUnchecked   ' commented out MSW - 1/19/22
								// chk_history.Visible = False
							}
						}
						else
						{
							chk_history.Visible = true;
						}

						if (modCommon.pubf_EncodeEntryPoints(tFormEntryPoint) == modGlobalVars.gFIND_ACCH || modCommon.pubf_EncodeEntryPoints(tFormEntryPoint) == modGlobalVars.gFIND_ACCA || modCommon.pubf_EncodeEntryPoints(tFormEntryPoint) == modGlobalVars.gFIND_EXBK || modCommon.pubf_EncodeEntryPoints(tFormEntryPoint) == modGlobalVars.gFIND_ADOC || modCommon.pubf_EncodeEntryPoints(tFormEntryPoint) == modGlobalVars.gFIND_CHCT)
						{

							if (!bIsFirstTime)
							{
								opt_contacts.Checked = true;
								opt_companies.Checked = false;
							}

							Display_Aircraft_Info();

							pnl_associate_aircraft.Visible = true;
							pnl_company_relationships.Visible = false;

							// find manufacturer
						}
						else if (modCommon.pubf_EncodeEntryPoints(tFormEntryPoint) == modGlobalVars.gFIND_FDMF)
						{ 

							if (!bIsFirstTime)
							{
								opt_contacts.Checked = true;
								opt_companies.Checked = false;
							}

							pnl_associate_aircraft.Visible = false;
							pnl_company_relationships.Visible = false;

							// company relationship
						}
						else if (modCommon.pubf_EncodeEntryPoints(tFormEntryPoint) == modGlobalVars.gFIND_ACOR)
						{ 

							if (!bIsFirstTime)
							{
								opt_contacts.Checked = true;
								opt_companies.Checked = false;
							}

							// share relationship
						}
						else if (modCommon.pubf_EncodeEntryPoints(tFormEntryPoint) == modGlobalVars.gFIND_ASHR)
						{ 

							if (!bIsFirstTime)
							{
								opt_contacts.Checked = true;
								opt_companies.Checked = false;
							}

							// forune 1000
						}
						else if (modCommon.pubf_EncodeEntryPoints(tFormEntryPoint) == modGlobalVars.gFIND_1000)
						{ 

							if (!bIsFirstTime)
							{
								opt_contacts.Checked = false;
								opt_companies.Checked = true;
							}

						}
						else
						{

							if (!bIsFirstTime)
							{
								opt_contacts.Checked = false;
								opt_companies.Checked = true;
							}

							pnl_associate_aircraft.Visible = false;
							pnl_company_relationships.Visible = false;

						}

						if (modCommon.pubf_EncodeEntryPoints(tFormEntryPoint) == modGlobalVars.gFIND_ACCH && bIsHistorical)
						{
							chk_history.Visible = true;
						}

						frame_awaiting_documentation.Visible = modCommon.pubf_EncodeEntryPoints(tFormEntryPoint) == modGlobalVars.gFIND_CHCT;

						//determine if special setup needs are required based on EntryPoint and EntryAction
						Set_Form_View();

						if (modCommon.pubf_EncodeEntryPoints(tFormEntryPoint) == modGlobalVars.gFIND_CBAK)
						{
							cbo_account_rep.Text = sReference_AccountRep.Trim();
							txt_comp_name.Text = sReference_CompanyName.Trim();

							if (bIsFirstTime)
							{
								cmd_find_Click(cmd_Find, new EventArgs());
							}

						}


						Refresh_Form_Pnl_Lbl_Txt();

						if (!bIsFirstTime)
						{
							bIsFirstTime = true;
						}

						if (txt_comp_name.Visible && txt_comp_name.Enabled)
						{
							txt_comp_name.Focus();
						}

						if (pnl_display_results.Visible && (txt_comp_name.Text != modGlobalVars.cEmptyString || txt_comp_address.Text != modGlobalVars.cEmptyString || txt_comp_email.Text != modGlobalVars.cEmptyString || txt_comp_web_address.Text != modGlobalVars.cEmptyString || txt_comp_zip_code.Text != modGlobalVars.cEmptyString || txt_comp_city.Text != modGlobalVars.cEmptyString || txt_comp_phone.Text != modGlobalVars.cEmptyString || cbo_agency_type.SelectedIndex > 0 || cbo_business_type.SelectedIndex > 0 || cbo_account_rep.SelectedIndex > 0 || cbo_MailList.SelectedIndex > 0 || chk_prod_code[3].CheckState == CheckState.Checked))
						{
							pnl_search_results.Visible = true;
						}

						ToolbarSetup();

						ToolbarButtonsSetup();

						modStatusBar.Clear_Status_Bar(modAdminCommon.SB);

						// Temp Hold. Needs More Work
						//Set_Panels_Visible True

						this.BringToFront(); //gap-note Manual change to fix BringToFront rule failing sometimes

					} // gbl_bHomeClicked Then

					return;
				}
				catch
				{
				}

			}
		} // Form_Activate

		private void Form_Initialize()
		{
			// init

			try
			{

				gbCompTimer1DoubleClick = false;
				gbCompTimer1SingleClick = false;

				bACProsClicked = false;
				bAwaitingDocsCompany = false;
				bIsHistorical = false;
				bIsFirstTime = false;
				bIsSetDupeOptions = false;
				bClickedAssociate = false;

				tFormEntryPoint = modGlobalVars.e_find_form_entry_points.geNoEntryPoint;
				tFormActionTypes = modGlobalVars.e_find_form_action_types.geNoAction;

				sReference_AccountRep = "";

				iClickSpeed = 0;
				iRememberLastRow = 0;

				nReference_AircraftID = 0;
				nReference_JournalID = 0;
				nReference_CompanyID = 0;

				nReference_ContactID = 0;
				nReference_AwaitingDocsID = 0;

				tFormExitValues.tEntryPoint = modGlobalVars.e_find_form_entry_points.geNoEntryPoint;
				tFormExitValues.sEntryPointText = "";

				Clear_Exit_Values();

				nDuplicate_CompanyID = 0;
				nDuplicate_JournalID = 0;
			}
			catch
			{
			}




		} // Form_Initialize

		private void Clear_Exit_Values()
		{

			tFormExitValues.nFoundAircraftCompID = 0;
			tFormExitValues.nFoundAircraftID = 0;
			tFormExitValues.nFoundAircraftJID = 0;
			tFormExitValues.nFoundCompanyID = 0;
			tFormExitValues.nFoundCompanyJID = 0;
			tFormExitValues.sFoundCompanyTYPE = "";
			tFormExitValues.nFoundContactID = 0;
			tFormExitValues.nFoundContactJID = 0;
			tFormExitValues.sFoundContactTYPE = "";
			tFormExitValues.nFoundAwaitingDocsID = 0;
			tFormExitValues.sFoundNewCompanyName = "";

		}

		private void Form_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{

				if ((KeyCode == ((int) Keys.Return)) || (KeyCode == ((int) Keys.F1)))
				{
					cmd_find_Click(cmd_Find, new EventArgs());
				}
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
		private void Form_Load()
		{
			// load
			try
			{

				iClickSpeed = modCommon.GetDoubleClickSpeed();

				compTimer1.Enabled = false;
				if (iClickSpeed == 0)
				{
					compTimer1.Enabled = false;
				}
				else
				{
					compTimer1.Interval = iClickSpeed;
					compTimer1.Enabled = true;
				}

				pnl_search_results.Visible = false;
				pnl_company_info.Visible = false;
				pnl_contact_info.Visible = false;
				pnl_duplicates.Visible = false;

				frame_potential_dups.Visible = false;
				frame_potential_dups_grid.Visible = false;



				if (mdi_ResearchAssistant.DefInstance.lbl_test_omg.Visible)
				{
					lbl_test_omg.Visible = true;
				}


				bIsFormLoad = true;

				modFillCompConControls.Fill_ProductList_FromArray(cbo_product[0], cbo_product[1]);

				Application.DoEvents();

				if (chk_prod_code[3].CheckState == CheckState.Checked)
				{
					cbo_business_type.Items.Clear();
					modFillCompConControls.fill_businesstype_FromArray(cbo_business_type);
				}
				else
				{
					modFillCommonArrays.Fill_BusinessType_Array(true); // ignore yacht true, get others
					cbo_business_type.Items.Clear();
					modFillCompConControls.fill_businesstype_FromArray(cbo_business_type);
					modFillCommonArrays.Fill_BusinessType_Array(false); // put it back
				}


				modFillCompConControls.Fill_TitleGroup_FromArray(lst_title_group);
				modFillCompConControls.Fill_Contact_Title(cbo_contact_title, lst_title_group);
				modFillCompConControls.Fill_AccountRep_FromArray(cbo_account_rep, false, false);
				modFillCompConControls.Fill_AccountRep_FromArray(cbo_dup_account_rep, false, false);
				modFillCompConControls.fill_agencytype_FromArray(cbo_agency_type);

				if (cbo_cert_drop.Items.Count == 0)
				{
					fill_cert_drop_down();
				}


				modFillCompConControls.Fill_Owner_Type(cbo_owner_type[0], cbo_compare[0], cbo_owner_type[1], cbo_compare[1], txt_ac_value[0], txt_ac_value[1]);

				modFillCompConControls.fill_country_FromArray(cbo_unknown_country);
				modFillCompConControls.fill_state_FromArray(cbo_unknown_state, false, true, false);
				// RTW - ADDED 4/26/2011
				modFillCompConControls.Fill_MailList_FromArray(cbo_MailList);

				opt_continent_region[0].Checked = true;

				txt_num_characters.Text = "0";
				txt_dup_num_chars.Text = "40";

				opt_dup_sortby[0].Checked = true;

				modFillCompConControls.Fill_Demographics(opt_continent_region, lst_area);

				//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				// Initialize the ToolBar
				//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				ToolbarSetup();
				ToolbarButtonsSetup();

				bIsFormLoad = false;
			}
			catch
			{
			}




		} // Form_Load
		public void fill_cert_drop_down()
		{
			ADORecordSetHelper ado_cert_name = new ADORecordSetHelper();
			int CurRow = 0;
			int counter1 = 0;
			int row_selected = 0;

			int counter_for_selected = 0;
			string Query = " Select distinct ccerttype_type from Company_Certification_type WITH (NOLOCK) order by ccerttype_type asc";

			ado_cert_name = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

			if (!(ado_cert_name.BOF && ado_cert_name.EOF))
			{

				cbo_cert_drop.Items.Clear();



				while(!ado_cert_name.EOF)
				{

					cbo_cert_drop.AddItem(Convert.ToString(ado_cert_name["ccerttype_type"]));
					counter1++;

					ado_cert_name.MoveNext();
				};



			}
			else
			{
			}

		}


		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			//Unload
			return;
		}


	public bool HistoricalSearch
		{
			get
			{
				bIsHistorical = false;
				return false;
			}
			set => bIsHistorical = value;
		}



		public string HistoricalContactName
		{
			get => sReference_HistContactName;
			set => sReference_HistContactName = value;
		}



		public string HistoricalContactType
		{
			get => sReference_HistContactType;
			set => sReference_HistContactType = value;
		}



		public string Form_CollectionKey
		{
			get => sFormCollectionKey;
			set => sFormCollectionKey = value;
		}



		public modGlobalVars.e_find_form_entry_points EntryPoint
		{
			get => tFormEntryPoint;
			set => tFormEntryPoint = value;
		}



		public modGlobalVars.e_find_form_action_types ActionTypes
		{
			get => tFormActionTypes;
			set => tFormActionTypes = value;
		}



		public int Reference_AircraftID
		{
			get => nReference_AircraftID;
			set => nReference_AircraftID = value;
		}



		public int Reference_JournalID
		{
			get => nReference_JournalID;
			set => nReference_JournalID = value;
		}



		public string Reference_CompanyName
		{
			get => sReference_CompanyName;
			set => sReference_CompanyName = value;
		}



		public int Reference_CompanyID
		{
			get => nReference_CompanyID;
			set => nReference_CompanyID = value;
		}



		public int Reference_ContactID
		{
			get => nReference_ContactID;
			set => nReference_ContactID = value;
		}



		public string Reference_AccountRep
		{
			get => sReference_AccountRep;
			set => sReference_AccountRep = value;
		}



		public string Reference_ContactType
		{
			get => sReference_ContactType;
			set => sReference_ContactType = value;
		}



		public int Reference_AwaitingDocsID
		{
			get => nReference_AwaitingDocsID;
			set => nReference_AwaitingDocsID = value;
		}


		public modGlobalVars.e_find_form_entry_points GetFormExitValues(int recIndex)
		{


			modGlobalVars.e_find_form_entry_points result = (modGlobalVars.e_find_form_entry_points) 0;
			switch(recIndex)
			{
				case 1000 : 
					result = tFormExitValues.tEntryPoint; 
					break;
				case 1001 : 
					//UPGRADE_WARNING: (6021) Casting 'string' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021 
					result = (modGlobalVars.e_find_form_entry_points) Convert.ToInt32(Double.Parse(tFormExitValues.sEntryPointText)); 
					break;
				case 1002 : 
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021 
					result = (modGlobalVars.e_find_form_entry_points) tFormExitValues.nFoundAircraftID; 
					break;
				case 1003 : 
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021 
					result = (modGlobalVars.e_find_form_entry_points) tFormExitValues.nFoundAircraftCompID; 
					break;
				case 1004 : 
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021 
					result = (modGlobalVars.e_find_form_entry_points) tFormExitValues.nFoundAircraftJID; 
					break;
				case 1005 : 
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021 
					result = (modGlobalVars.e_find_form_entry_points) tFormExitValues.nFoundCompanyID; 
					break;
				case 1006 : 
					//UPGRADE_WARNING: (6021) Casting 'string' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021 
					result = (modGlobalVars.e_find_form_entry_points) Convert.ToInt32(Double.Parse(tFormExitValues.sFoundCompanyTYPE)); 
					break;
				case 1007 : 
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021 
					result = (modGlobalVars.e_find_form_entry_points) tFormExitValues.nFoundCompanyJID; 
					break;
				case 1008 : 
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021 
					result = (modGlobalVars.e_find_form_entry_points) tFormExitValues.nFoundContactID; 
					break;
				case 1009 : 
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021 
					result = (modGlobalVars.e_find_form_entry_points) tFormExitValues.nFoundContactJID; 
					break;
				case 1010 : 
					//UPGRADE_WARNING: (6021) Casting 'string' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021 
					result = (modGlobalVars.e_find_form_entry_points) Convert.ToInt32(Double.Parse(tFormExitValues.sFoundContactTYPE)); 
					break;
				case 1011 : 
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021 
					result = (modGlobalVars.e_find_form_entry_points) tFormExitValues.nFoundAwaitingDocsID; 
					break;
				case 1012 : 
					//UPGRADE_WARNING: (6021) Casting 'string' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021 
					result = (modGlobalVars.e_find_form_entry_points) Convert.ToInt32(Double.Parse(tFormExitValues.sFoundNewCompanyName)); 
					break;
			}

			return result;
		}

		public string SetFormCaptionAndKey(modGlobalVars.e_find_form_entry_points in_Entry_Point)
		{

			if (modCommon.pubf_EncodeEntryPoints(in_Entry_Point) == modGlobalVars.gFIND_ACCH)
			{

				this.Text = $"Find Company - {modCommon.pubf_FindFormEntryPointsToString(in_Entry_Point)} ACID:{nReference_AircraftID.ToString()}";

			}
			else if (modCommon.pubf_EncodeEntryPoints(in_Entry_Point) == modGlobalVars.gFIND_NONE)
			{ 

				this.Text = "Find Company - New Search";

			}
			else
			{

				this.Text = $"Find Company - {modCommon.pubf_FindFormEntryPointsToString(in_Entry_Point)}";

			}


			switch((in_Entry_Point))
			{
				case modGlobalVars.e_find_form_entry_points.geChangeHistContact : 
					sFormCollectionKey = modGlobalVars.gFIND_CHCT.ToString(); 
					break;
				case modGlobalVars.e_find_form_entry_points.geAssociateToAircraft : 
					sFormCollectionKey = modGlobalVars.gFIND_ACCA.ToString(); 
					break;
				case modGlobalVars.e_find_form_entry_points.geFindManufacturer : 
					sFormCollectionKey = modGlobalVars.gFIND_FDMF.ToString(); 
					break;
				case modGlobalVars.e_find_form_entry_points.geAddCompanyRelation : 
					sFormCollectionKey = modGlobalVars.gFIND_ACOR.ToString(); 
					break;
				case modGlobalVars.e_find_form_entry_points.geAddShareRelation : 
					sFormCollectionKey = modGlobalVars.gFIND_ASHR.ToString(); 
					break;
				case modGlobalVars.e_find_form_entry_points.geFortune1000 : 
					sFormCollectionKey = modGlobalVars.gFIND_1000.ToString(); 
					break;
				case modGlobalVars.e_find_form_entry_points.geAircraftChange : 
					sFormCollectionKey = modGlobalVars.gFIND_ACCH.ToString(); 
					break;
				case modGlobalVars.e_find_form_entry_points.geAircraftDocument : 
					sFormCollectionKey = modGlobalVars.gFIND_ADOC.ToString(); 
					break;
				case modGlobalVars.e_find_form_entry_points.geAccountCallback : 
					sFormCollectionKey = modGlobalVars.gFIND_CBAK.ToString(); 
					break;
				case modGlobalVars.e_find_form_entry_points.geExclusiveBroker : 
					sFormCollectionKey = modGlobalVars.gFIND_EXBK.ToString(); 
					break;
				default:
					sFormCollectionKey = modGlobalVars.gFIND_NONE.ToString(); 
					 
					break;
			}

			sFormCollectionKey = $"{sFormCollectionKey}_frm_find_company";

			return "";

		} // SetFormCaptionAndKey

		private void cmd_Associate_Click(Object eventSender, EventArgs eventArgs)
		{

			string tmpCompName = "";
			string Query = "";
			int nCompanyID = 0;
			int nContactID = 0;
			ADORecordSetHelper snpCompID = null;
			string journal_text = "";
			string strDateTime = "";
			int compid2 = 0;
			string strInsert1 = "";
			string temp_phone_Type = "";
			string temp_phone = "";
			string Update_Query = "";
			int business_comp = 0;
			int add_comp = 0;
			int temp_contact_id = 0;

			string pnum_Country = "";
			string pnum_Area = "";
			string pnum_Prefix = "";
			string pnum_number = "";

			try
			{

				nCompanyID = Convert.ToInt32(Double.Parse(grd_find_company.get_RowData(grd_find_company.CurrentRowIndex).ToString().Trim()));
				//UPGRADE_ISSUE: (2064) MSHierarchicalFlexGridLib.MSHFlexGrid property grd_find_company.BandData was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				nContactID = Convert.ToInt32(Double.Parse(grd_find_company.BandData(grd_find_company.CurrentRowIndex).ToString().Trim()));

				// ******************************************************************************
				// RTW - 11/10/2011 - MODIFIED TO NOT ALLOW A BUYERS BROKER TO BE ADDED TO AN ACTIVE AIRCRAFT
				if (cbo_contact_type.Text.Trim() == "Buyers Broker" && nReference_JournalID == 0)
				{
					MessageBox.Show("Not allowed to attach a Buyers Broker to an active aircraft.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					return;
				}

				bClickedAssociate = true;

				if (nContactID > 0 && nCompanyID > 0)
				{

					Query = $"SELECT * FROM contact WITH(NOLOCK) WHERE contact_id = {nContactID.ToString()}";
					Query = $"{Query} AND contact_comp_id = {nCompanyID.ToString()} AND contact_active_flag = 'Y'";

					if (!modAdminCommon.Exist(Query))
					{
						MessageBox.Show($"Someone has changed the company contact!{Environment.NewLine}Action Cancelled", modCommon.pubf_FindFormEntryPointsToString(tFormEntryPoint), MessageBoxButtons.OK, MessageBoxIcon.Error);
						cmd_find_Click(cmd_Find, new EventArgs());
						return;
					}
				}

				// ADDED IN MSW - IF THE COMPANY IS EXCLUSIVE BROKER AND
				if (nCompanyID > 0)
				{
					if (sReference_ContactType.Trim() == "75")
					{

						if (Convert.ToString(cmd_Associate.Tag).Trim() == "Warned")
						{

						}
						else
						{
							Query = $"SELECT * FROM company WITH(NOLOCK) WHERE comp_id = {nCompanyID.ToString()}";
							Query = $"{Query} AND comp_hide_flag = 'Y' and comp_journ_id = 0 ";

							if (modAdminCommon.Exist(Query))
							{
								cmd_Associate.Tag = "Warned";
								MessageBox.Show($"You are about to add a Hidden Exclusive Broker!{Environment.NewLine}Please Make Sure This Is Correct.", modCommon.pubf_FindFormEntryPointsToString(tFormEntryPoint), MessageBoxButtons.OK, MessageBoxIcon.Error);
								return;
							}
						}
					}
				}

				// added this MSw - everywhere where contact it was, i replaced.. with temp_contact_id-  9/26/22
				if (!lst_contact_info.Visible)
				{
					temp_contact_id = 0;
				}
				else
				{
					temp_contact_id = lst_contact_info.GetItemData(0);
				}

				// added MSW - 7/7/22    82 is additional name
				if (sReference_ContactType.Trim() == "82")
				{ //  business name/additional location

					// this is to see which direction the reltionship is going and make sure it does the correct direction
					business_comp = 0;
					add_comp = 0;
					if (cbo_relationship.Text.Trim() == "Business Name")
					{
						business_comp = nReference_CompanyID;
						add_comp = nCompanyID;
					}
					else
					{
						business_comp = nCompanyID;
						add_comp = nReference_CompanyID;
					}


					// if the main phone number is here and the main company has one, then check to see if the one we are attaching does or not
					if (modAdminCommon.Exist($"select top 1 pnum_number_full from Phone_Numbers with (NOLOCK) where pnum_journ_id = 0 and pnum_contact_id = 0 and pnum_type in ('Office')  and pnum_comp_id ={business_comp.ToString()}"))
					{
						if (!modAdminCommon.Exist($"select top 1 pnum_number_full from Phone_Numbers with (NOLOCK) where pnum_journ_id = 0 and pnum_contact_id = 0 and pnum_type not in ('Office')  and pnum_comp_id ={add_comp.ToString()}"))
						{
							//if the main company has a phone number and the other additional location doesnt, then ask if we want to add it
							if (MessageBox.Show("Would You Like To Add The Company Phone Number to the Additional Related Company?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
							{

								Query = $"select top 1 pnum_number_full, pnum_type, pnum_cntry_code,pnum_prefix,pnum_area_code,pnum_number from Phone_Numbers with (NOLOCK) where pnum_type in ('Office') and pnum_journ_id = 0 and pnum_contact_id = 0 and pnum_comp_id ={business_comp.ToString()} order by pnum_type desc ";

								snpCompID = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(snpCompID.Fields) && !(snpCompID.BOF && snpCompID.EOF))
								{
									temp_phone = Convert.ToString(snpCompID["pnum_number_full"]);
									temp_phone_Type = Convert.ToString(snpCompID["pnum_type"]);

									//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
									if (!Convert.IsDBNull(snpCompID["pnum_cntry_code"]))
									{
										pnum_Country = Convert.ToString(snpCompID["pnum_cntry_code"]);
									}
									else
									{
										pnum_Country = "";
									}

									//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
									if (!Convert.IsDBNull(snpCompID["pnum_area_code"]))
									{
										pnum_Area = Convert.ToString(snpCompID["pnum_area_code"]);
									}
									else
									{
										pnum_Area = "";
									}

									//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
									if (!Convert.IsDBNull(snpCompID["pnum_prefix"]))
									{
										pnum_Prefix = Convert.ToString(snpCompID["pnum_prefix"]);
									}
									else
									{
										pnum_Prefix = "";
									}

									//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
									if (!Convert.IsDBNull(snpCompID["pnum_number"]))
									{
										pnum_number = Convert.ToString(snpCompID["pnum_number"]);
									}
									else
									{
										pnum_number = "";
									}


									snpCompID.Close();

									if (temp_phone.Trim() != "")
									{
										Update_Query = "INSERT INTO Phone_Numbers (";
										Update_Query = $"{Update_Query}pnum_comp_id, pnum_journ_id, pnum_contact_id, ";
										Update_Query = $"{Update_Query}pnum_type, pnum_cntry_code, pnum_area_code, pnum_prefix, ";
										Update_Query = $"{Update_Query}pnum_number, pnum_number_full, ";
										Update_Query = $"{Update_Query}pnum_confirm_date, pnum_hide_customer, pnum_number_full_search)";
										Update_Query = $"{Update_Query} VALUES ({add_comp.ToString()},"; // company ID
										Update_Query = $"{Update_Query}0,"; // journal ID
										Update_Query = $"{Update_Query}0,"; // contact ID
										Update_Query = $"{Update_Query}'{temp_phone_Type}',"; // Phone Type
										Update_Query = $"{Update_Query} '{pnum_Country}','{pnum_Area}','{pnum_Prefix}','{pnum_number}',"; // Phone (Country,Area,Prefix,Number)
										// fixed area and prefix .. they had been switched - MSW - 8/12/22
										Update_Query = $"{Update_Query}'{temp_phone}',"; // Phone Number Full (with Dashes)
										Update_Query = $"{Update_Query}'{DateTime.Parse(modAdminCommon.DateToday).ToString("d")}',"; // Phone Number Confirm Date
										Update_Query = $"{Update_Query}'N',"; // Phone Number hide flag
										Update_Query = $"{Update_Query}'{StringsHelper.Replace(StringsHelper.Replace(temp_phone, modGlobalVars.cHyphen, modGlobalVars.cEmptyString, 1, -1, CompareMethod.Binary), " ", modGlobalVars.cEmptyString, 1, -1, CompareMethod.Binary)}')"; // Phone Number Full Search (without Dashes or Spaces)

										DbCommand TempCommand = null;
										TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
										UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
										TempCommand.CommandText = Update_Query;
										UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
										TempCommand.ExecuteNonQuery();

									}
								}
							}
						}
					}
				}

				// all of the main location relationships - MSW -2/16/22
				if (sReference_ContactType.Trim() == "1B" || sReference_ContactType.Trim() == "47" || sReference_ContactType.Trim() == "59" || sReference_ContactType.Trim() == "77" || sReference_ContactType.Trim() == "83")
				{

					Query = ""; // MSw - 2/16/22
					if (cbo_relationship.Text != "Main Location")
					{ // then i am the main location, so check other company to see if they have one
						Query = $" select top 10 * from Company_Reference  with (NOLOCK)  where compref_journ_id = 0 and compref_contact_type in  ('1B','47','59','77','83') and compref_rel_comp_id = {nReference_CompanyID.ToString()}";
					}
					else
					{
						// else then i am NOT the main location. so make sure i dont alread have a main location
						Query = $" select top 10 * from Company_Reference  with (NOLOCK)  where compref_journ_id = 0 and compref_contact_type in  ('1B','47','59','77','83') and compref_rel_comp_id = {nCompanyID.ToString()}";
					}


					if (modAdminCommon.Exist(Query))
					{
						cmd_Associate.Tag = "Warned";
						MessageBox.Show($"You are about to add a Main Location to a Company That Already Has One!{Environment.NewLine}Please Adjust the Relationship.", modCommon.pubf_FindFormEntryPointsToString(tFormEntryPoint), MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
				}

				if (nCompanyID > 0)
				{
					tmpCompName = modCommon.GetCompanyName(nCompanyID, 0);
				}

				if (bAwaitingDocsCompany)
				{

					modAdminCommon.ADO_Transaction("BeginTrans");
					nReference_AwaitingDocsID = modCompanyFind.Create_Awaiting_Documentation_Company(0, nReference_JournalID, cbo_unknown_country.Text.Trim(), cbo_unknown_state.Text.Substring(0, Math.Min(2, cbo_unknown_state.Text.Length)).Trim());
					tFormExitValues.nFoundAwaitingDocsID = nReference_AwaitingDocsID;
					modAdminCommon.ADO_Transaction("CommitTrans");

				}
				else if (modCommon.pubf_EncodeEntryPoints(tFormEntryPoint) == modGlobalVars.gFIND_CHCT)
				{ 

					if (tmpCompName.ToUpper() == ("Awaiting Documentation").ToUpper())
					{
						MessageBox.Show($"You cannot choose an existing Awaiting Documentation company!{Environment.NewLine}Action Cancelled", modCommon.pubf_FindFormEntryPointsToString(tFormEntryPoint), MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

				}

				string temp_subject = "";
				string temp_desc = "";
				if (modCommon.pubf_EncodeEntryPoints(tFormEntryPoint) == modGlobalVars.gFIND_ACCH)
				{
					// choose buyer goes into here

					if (modCompanyFind.CheckForProgramManager(nCompanyID))
					{
						MessageBox.Show($"Buyer cannot be a 'Program Manager' or 'Program Name'{Environment.NewLine}Action Cancelled", modCommon.pubf_FindFormEntryPointsToString(tFormEntryPoint), MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

					if (opt_contacts.Checked && pnl_contact_info.Visible)
					{
						tFormExitValues.nFoundContactID = nContactID;
						tFormExitValues.nFoundCompanyID = nCompanyID;
					}
					else
					{
						tFormExitValues.nFoundContactID = 0;
						tFormExitValues.nFoundCompanyID = nCompanyID;
					}

					// IF THE THE PURPOSE OF ASSOCIATING THE COMPANY RESULTS IN SOMETHING THAT
					// WOULD REQUIRE THAT THE COMPANY IS ACTIVE - THEN MAKE SURE THAT IT IS
					modCommon.CompanyActivate(nCompanyID, 0);

					//*************** ADD DOCUMENT RELATIONSHIP ********************
				}
				else if (modCommon.pubf_EncodeEntryPoints(tFormEntryPoint) == modGlobalVars.gFIND_ADOC)
				{ 
					if (opt_contacts.Checked && pnl_contact_info.Visible)
					{
						tFormExitValues.nFoundContactID = nContactID;
					}
					else
					{
						tFormExitValues.nFoundContactID = 0;
					}

					tFormExitValues.nFoundCompanyID = nCompanyID;

					//*************** CHANGE HISTORICAL CONTACT TYPE ********************
				}
				else if (modCommon.pubf_EncodeEntryPoints(tFormEntryPoint) == modGlobalVars.gFIND_CHCT)
				{ 

					tFormExitValues.nFoundContactJID = nReference_JournalID;

					if (bAwaitingDocsCompany)
					{
						tFormExitValues.nFoundAircraftCompID = nReference_AwaitingDocsID;
					}
					else
					{
						tFormExitValues.nFoundAircraftCompID = nCompanyID;
					}

					if ((opt_contacts.Checked && pnl_contact_info.Visible) && !(bAwaitingDocsCompany))
					{
						tFormExitValues.nFoundContactID = nContactID;
					}
					else
					{
						tFormExitValues.nFoundContactID = 0;
					}

					tFormExitValues.sFoundContactTYPE = sReference_HistContactType;

					sReference_HistContactName = "";

					if (bAwaitingDocsCompany)
					{
						tFormExitValues.sFoundNewCompanyName = "Awaiting Documentation";
					}
					else
					{
						if (tmpCompName == "" && tFormExitValues.nFoundContactJID > 0)
						{

							Query = $"SELECT cref_comp_id FROM Aircraft_Reference WITH(NOLOCK) WHERE cref_journ_id = {tFormExitValues.nFoundContactJID.ToString()}";

							snpCompID = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(snpCompID.Fields) && !(snpCompID.BOF && snpCompID.EOF))
							{
								tFormExitValues.sFoundNewCompanyName = modCommon.GetCompanyName(Convert.ToInt32(snpCompID["cref_comp_id"]), tFormExitValues.nFoundContactJID);
								snpCompID.Close();
							}
							else
							{
								snpCompID = null;
							}
						}
						else
						{
							tFormExitValues.sFoundNewCompanyName = tmpCompName;
						}
					}

					//*************** ADD SHARE RELATIONSHIP ********************
				}
				else if (modCommon.pubf_EncodeEntryPoints(tFormEntryPoint) == modGlobalVars.gFIND_ASHR)
				{ 

					tFormExitValues.sFoundContactTYPE = modCompanyFind.Select_Contact_Type(cbo_contact_type, tFormEntryPoint);

					if (opt_contacts.Checked && pnl_contact_info.Visible)
					{
						tFormExitValues.nFoundContactID = nContactID;
					}
					else
					{
						tFormExitValues.nFoundContactID = 0;
					}

					tFormExitValues.nFoundCompanyID = nCompanyID;

					// IF THE THE PURPOSE OF ASSOCIATING THE COMPANY RESULTS IN SOMETHING THAT
					// WOULD REQUIRE THAT THE COMPANY IS ACTIVE - THEN MAKE SURE THAT IT IS
					modCommon.CompanyActivate(nCompanyID, 0);

					//*************** ADD COMPANY RELATIONSHIP ********************
				}
				else if (modCommon.pubf_EncodeEntryPoints(tFormEntryPoint) == modGlobalVars.gFIND_ACOR)
				{ 
					if (cbo_relationship.Text != "")
					{
						if (nCompanyID != nReference_CompanyID)
						{

							tFormExitValues.nFoundCompanyID = nCompanyID;
							tFormExitValues.nFoundContactID = nContactID;
							tFormExitValues.sFoundCompanyTYPE = modCompanyFind.Select_Contact_Type(cbo_relationship, tFormEntryPoint);

							// 03/19/2015 - By David D. Cruger
							// Added Hide Flag
							modCompanyFind.Assocate_Company_To_Company(nReference_CompanyID, nReference_JournalID, tFormExitValues, cbo_relationship, cbo_contact, cbo_contact2, opt_contacts.Checked, chkCompRelHide.CheckState);

							// ADDED MSW - 9/27/21 ----------------
							temp_subject = "Company Relationship Added";
							temp_desc = $"Added {cbo_relationship.Text} of {modCompany.Get_Company_Name(nReference_CompanyID, 0)}";


							modCommon.InsertPriorityEvent("CRA", 0, 0, temp_desc, nCompanyID, nContactID, "N");

							//' add it for the original company
							temp_subject = "Company Relationship Added";
							temp_desc = $"Added {lbl_Label1[27].Text}"; // this is the label that should be the opposite relationship to cbo_rel
							temp_desc = $"{temp_desc} of {modCompany.Get_Company_Name(nCompanyID, 0)}";
							modCommon.InsertPriorityEvent("CRA", 0, 0, temp_desc, nReference_CompanyID, 0, "N");

							//Company Relationship Added

						}
						else
						{
							MessageBox.Show($"You can't relate the company to itself!{Environment.NewLine}Action Cancelled", modCommon.pubf_FindFormEntryPointsToString(tFormEntryPoint), MessageBoxButtons.OK, MessageBoxIcon.Error);
							cbo_relationship.Focus();
							return;
						}

						// IF THE THE PURPOSE OF ASSOCIATING THE COMPANY RESULTS IN SOMETHING THAT
						// WOULD REQUIRE THAT THE COMPANY IS ACTIVE - THEN MAKE SURE THAT IT IS
						modCommon.CompanyActivate(nCompanyID, 0);

					}
					else
					{
						MessageBox.Show($"You must select a relationship!{Environment.NewLine}Action Cancelled", modCommon.pubf_FindFormEntryPointsToString(tFormEntryPoint), MessageBoxButtons.OK, MessageBoxIcon.Error);
						cbo_relationship.Focus();
						return;
					}

					//*************** ADD EXCLUSIVE BROKER ********************
				}
				else if (modCommon.pubf_EncodeEntryPoints(tFormEntryPoint) == modGlobalVars.gFIND_EXBK)
				{ 

					if (modCompanyFind.VerifyExclusiveBusinessType(nCompanyID, cbo_contact_type.Text.Trim()))
					{
						tFormExitValues.sFoundCompanyTYPE = modCompanyFind.Select_Contact_Type(cbo_contact_type, tFormEntryPoint);

						if (opt_contacts.Checked && pnl_contact_info.Visible)
						{
							tFormExitValues.nFoundContactID = nContactID;
						}
						else
						{
							tFormExitValues.nFoundContactID = 0;
						}

						tFormExitValues.nFoundAircraftCompID = nCompanyID;
						tFormExitValues.nFoundAircraftJID = nReference_JournalID;

						// IF THE THE PURPOSE OF ASSOCIATING THE COMPANY RESULTS IN SOMETHING THAT
						// WOULD REQUIRE THAT THE COMPANY IS ACTIVE - THEN MAKE SURE THAT IT IS
						modCommon.CompanyActivate(nCompanyID, 0);

						modCommon.Company_Stats_Update(nCompanyID);

					}
					else
					{

						if (cbo_contact_type.Text.Trim() == "Exclusive Broker")
						{
							MessageBox.Show($"Exclusive Brokers can ONLY be Dealer Broker Companies{Environment.NewLine}Action Cancelled", modCommon.pubf_FindFormEntryPointsToString(tFormEntryPoint), MessageBoxButtons.OK, MessageBoxIcon.Error);
							return;
						}
						else
						{
							MessageBox.Show($"Exclusive Representatives can NOT be Dealer Broker Companies{Environment.NewLine}Action Cancelled", modCommon.pubf_FindFormEntryPointsToString(tFormEntryPoint), MessageBoxButtons.OK, MessageBoxIcon.Error);
							return;
						}

					}

				}
				else
				{
					// associate a company to an ac goes into here

					sReference_ContactType = modCompanyFind.Select_Contact_Type(cbo_contact_type, tFormEntryPoint);
					tFormExitValues.sFoundContactTYPE = sReference_ContactType;
					tFormExitValues.nFoundAircraftID = nReference_AircraftID;
					tFormExitValues.nFoundAircraftJID = nReference_JournalID;

					// WOULD REQUIRE THAT THE COMPANY IS ACTIVE - THEN MAKE SURE THAT IT IS
					modCommon.CompanyActivate(nCompanyID, 0);
					modCompanyFind.Associate_Company(tFormExitValues, opt_contacts.Checked, bAwaitingDocsCompany);
					// INSERTED MSW - 4/6/2012 - THIS WILL TAKE THE JOURNALS AND DELETE AND RE-INSERT
					// THEM INTO HOT BOX
					if (modAdminCommon.gbl_Aircraft_ID > 0)
					{
						int tempRefParam = 0;
						modAircraft.delete_and_insert_hotbox(ref tempRefParam, ref modAdminCommon.gbl_Aircraft_ID);
					}


				}

				// ADDED MSW - so that on changes these dont change - getting messed up  - 12/30/19
				if (cbo_contact_type.Visible)
				{

					if (lst_company1.Visible && lst_company2.Visible)
					{
						compid2 = nCompanyID;
						ListBoxHelper.SetSelectedIndex(lst_company1, 0);
						ListBoxHelper.SetSelectedIndex(lst_company2, 0);
						journal_text = $"Added Relationship of {cbo_contact_type.Text} Between Companies: {lst_company1.Text}";
						journal_text = $"{journal_text} and {lst_company2.Text}";


						//-------------- INSERT INTO JOURNAL NOTES FOR DELETE---------------------------------------------------------------------------
						strDateTime = DateTimeHelper.ToString(DateTime.Now);
						strInsert1 = "INSERT INTO Journal (";
						strInsert1 = $"{strInsert1}journ_subcategory_code, journ_description, journ_subject, journ_contact_id, journ_comp_id, ";
						strInsert1 = $"{strInsert1}journ_user_id, journ_status, journ_entry_date, journ_entry_time, journ_action_date, journ_date ";
						strInsert1 = $"{strInsert1}) VALUES ('RN', '";

						strInsert1 = $"{strInsert1}{StringsHelper.Replace(journal_text, "'", "", 1, -1, CompareMethod.Binary)}', 'Added Company to Company Relationship'";
						strInsert1 = $"{strInsert1},0, {nReference_CompanyID.ToString()}, '{modAdminCommon.gbl_User_ID}', 'A', ";
						strInsert1 = $"{strInsert1}'{DateTime.Parse(strDateTime).ToString("d")}', ";
						strInsert1 = $"{strInsert1}'{Strings.FormatDateTime(DateTime.Parse(strDateTime), DateFormat.ShortTime)}', ";
						strInsert1 = $"{strInsert1}'{DateTime.Parse(strDateTime).ToString()}', '{DateTime.Parse(strDateTime).ToString("d")}'";
						strInsert1 = $"{strInsert1}) ";

						modAdminCommon.ADO_Transaction("BeginTrans");
						DbCommand TempCommand_2 = null;
						TempCommand_2 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
						TempCommand_2.CommandText = strInsert1;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand_2.CommandType = (CommandType) (((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()) + ((int) CommandType.Text));
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
						TempCommand_2.ExecuteNonQuery();
						modAdminCommon.ADO_Transaction("CommitTrans");


						strDateTime = DateTimeHelper.ToString(DateTime.Now);
						strInsert1 = "INSERT INTO Journal (journ_subcategory_code, journ_description,journ_subject, journ_contact_id, journ_comp_id, ";
						strInsert1 = $"{strInsert1}journ_user_id, journ_status, journ_entry_date, journ_entry_time, journ_action_date, journ_date ";
						strInsert1 = $"{strInsert1}) VALUES ('RN', '";

						strInsert1 = $"{strInsert1}{StringsHelper.Replace(journal_text, "'", "", 1, -1, CompareMethod.Binary)}', 'Added Company to Company Relationship'";
						strInsert1 = $"{strInsert1},0, {compid2.ToString()}, '{modAdminCommon.gbl_User_ID}', 'A', ";
						strInsert1 = $"{strInsert1}'{DateTime.Parse(strDateTime).ToString("d")}', ";
						strInsert1 = $"{strInsert1}'{Strings.FormatDateTime(DateTime.Parse(strDateTime), DateFormat.ShortTime)}', ";
						strInsert1 = $"{strInsert1}'{DateTime.Parse(strDateTime).ToString()}', '{DateTime.Parse(strDateTime).ToString("d")}'";
						strInsert1 = $"{strInsert1}) ";

						modAdminCommon.ADO_Transaction("BeginTrans");
						DbCommand TempCommand_3 = null;
						TempCommand_3 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_3);
						TempCommand_3.CommandText = strInsert1;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand_3.CommandType = (CommandType) (((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()) + ((int) CommandType.Text));
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_3);
						TempCommand_3.ExecuteNonQuery();
						modAdminCommon.ADO_Transaction("CommitTrans");
					}

					if (sReference_ContactType.Trim() == "38")
					{
						strDateTime = DateTimeHelper.ToString(DateTime.Now);
						strInsert1 = "INSERT INTO Journal (journ_subcategory_code, journ_description,journ_subject, journ_contact_id, journ_comp_id, ";
						strInsert1 = $"{strInsert1}journ_user_id, journ_status, journ_entry_date, journ_entry_time, journ_action_date, journ_date, journ_ac_id ";
						strInsert1 = $"{strInsert1}) VALUES ('RN', '";

						strInsert1 = $"{strInsert1}Added Sales Company/Contact - {StringsHelper.Replace(lst_company.GetListItem(0), "'", "''", 1, -1, CompareMethod.Binary)}', 'Added Sales Company/Contact - {StringsHelper.Replace(lst_company.GetListItem(0), "'", "''", 1, -1, CompareMethod.Binary)}'";

						strInsert1 = $"{strInsert1},{temp_contact_id.ToString()}, {nCompanyID.ToString()}, '{modAdminCommon.gbl_User_ID}', 'A', ";
						strInsert1 = $"{strInsert1}'{DateTime.Parse(strDateTime).ToString("d")}', ";
						strInsert1 = $"{strInsert1}'{Strings.FormatDateTime(DateTime.Parse(strDateTime), DateFormat.ShortTime)}', ";
						strInsert1 = $"{strInsert1}'{DateTime.Parse(strDateTime).ToString()}', '{DateTime.Parse(strDateTime).ToString("d")}'";
						strInsert1 = $"{strInsert1},{nReference_AircraftID.ToString()}";
						strInsert1 = $"{strInsert1}) ";

						modAdminCommon.ADO_Transaction("BeginTrans");
						DbCommand TempCommand_4 = null;
						TempCommand_4 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_4);
						TempCommand_4.CommandText = strInsert1;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand_4.CommandType = (CommandType) (((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()) + ((int) CommandType.Text));
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_4);
						TempCommand_4.ExecuteNonQuery();
						modAdminCommon.ADO_Transaction("CommitTrans");
					}


					// ADDED FOR CAMO - MSW - 4/19/19
					if (sReference_ContactType.Trim() == "2Y")
					{
						strDateTime = DateTimeHelper.ToString(DateTime.Now);
						strInsert1 = "INSERT INTO Journal (journ_subcategory_code, journ_description,journ_subject, journ_contact_id, journ_comp_id, ";
						strInsert1 = $"{strInsert1}journ_user_id, journ_status, journ_entry_date, journ_entry_time, journ_action_date, journ_date, journ_ac_id ";
						strInsert1 = $"{strInsert1}) VALUES ('RN', '";

						strInsert1 = $"{strInsert1}Added CAMO Company - {StringsHelper.Replace(lst_company.GetListItem(0), "'", "''", 1, -1, CompareMethod.Binary)}', 'Added CAMO Company - {StringsHelper.Replace(lst_company.GetListItem(0), "'", "''", 1, -1, CompareMethod.Binary)}'";

						strInsert1 = $"{strInsert1},{temp_contact_id.ToString()}, {nCompanyID.ToString()}, '{modAdminCommon.gbl_User_ID}', 'A', ";
						strInsert1 = $"{strInsert1}'{DateTime.Parse(strDateTime).ToString("d")}', ";
						strInsert1 = $"{strInsert1}'{Strings.FormatDateTime(DateTime.Parse(strDateTime), DateFormat.ShortTime)}', ";
						strInsert1 = $"{strInsert1}'{DateTime.Parse(strDateTime).ToString()}', '{DateTime.Parse(strDateTime).ToString("d")}'";
						strInsert1 = $"{strInsert1},{nReference_AircraftID.ToString()}";
						strInsert1 = $"{strInsert1}) ";

						modAdminCommon.ADO_Transaction("BeginTrans");
						DbCommand TempCommand_5 = null;
						TempCommand_5 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_5);
						TempCommand_5.CommandText = strInsert1;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand_5.CommandType = (CommandType) (((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()) + ((int) CommandType.Text));
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_5);
						TempCommand_5.ExecuteNonQuery();
						modAdminCommon.ADO_Transaction("CommitTrans");

						modCommon.InsertPriorityEvent("NCAMO", Convert.ToInt32(Double.Parse(nReference_AircraftID.ToString())), 0, $"Added New Camo Company: {StringsHelper.Replace(lst_company.GetListItem(0), "'", "''", 1, -1, CompareMethod.Binary)}", Convert.ToInt32(Double.Parse(nCompanyID.ToString())), Convert.ToInt32(Double.Parse(temp_contact_id.ToString())));

					}



					// ADDED FOR CERTIFICATE HOLDER - MSW - 3/20/20
					if (sReference_ContactType.Trim() == "1V")
					{
						strDateTime = DateTimeHelper.ToString(DateTime.Now);
						strInsert1 = "INSERT INTO Journal (journ_subcategory_code, journ_description,journ_subject, journ_contact_id, journ_comp_id, ";
						strInsert1 = $"{strInsert1}journ_user_id, journ_status, journ_entry_date, journ_entry_time, journ_action_date, journ_date, journ_ac_id ";
						strInsert1 = $"{strInsert1}) VALUES ('PROJ', '";

						strInsert1 = $"{strInsert1}Added Certificate Holder - {StringsHelper.Replace(lst_company.GetListItem(0), "'", "''", 1, -1, CompareMethod.Binary)}', 'Certificate Holder - {StringsHelper.Replace(lst_company.GetListItem(0), "'", "''", 1, -1, CompareMethod.Binary)}'";

						strInsert1 = $"{strInsert1},{temp_contact_id.ToString()}, {nCompanyID.ToString()}, '{modAdminCommon.gbl_User_ID}', 'A', ";
						strInsert1 = $"{strInsert1}'{DateTime.Parse(strDateTime).ToString("d")}', ";
						strInsert1 = $"{strInsert1}'{Strings.FormatDateTime(DateTime.Parse(strDateTime), DateFormat.ShortTime)}', ";
						strInsert1 = $"{strInsert1}'{DateTime.Parse(strDateTime).ToString()}', '{DateTime.Parse(strDateTime).ToString("d")}'";
						strInsert1 = $"{strInsert1},{nReference_AircraftID.ToString()}";
						strInsert1 = $"{strInsert1}) ";

						modAdminCommon.ADO_Transaction("BeginTrans");
						DbCommand TempCommand_6 = null;
						TempCommand_6 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_6);
						TempCommand_6.CommandText = strInsert1;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand_6.CommandType = (CommandType) (((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()) + ((int) CommandType.Text));
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_6);
						TempCommand_6.ExecuteNonQuery();
						modAdminCommon.ADO_Transaction("CommitTrans");

						modCommon.InsertPriorityEvent("NCERTH", Convert.ToInt32(Double.Parse(nReference_AircraftID.ToString())), 0, $"Added Certificate Holder: {StringsHelper.Replace(lst_company.GetListItem(0), "'", "''", 1, -1, CompareMethod.Binary)}", Convert.ToInt32(Double.Parse(nCompanyID.ToString())), Convert.ToInt32(Double.Parse(temp_contact_id.ToString())));

					}



					if (sReference_ContactType.Trim() == "71")
					{

						strDateTime = DateTimeHelper.ToString(DateTime.Now);
						strInsert1 = "INSERT INTO Journal (journ_subcategory_code, journ_description,journ_subject, journ_contact_id, journ_comp_id, ";
						strInsert1 = $"{strInsert1}journ_user_id, journ_status, journ_entry_date, journ_entry_time, journ_action_date, journ_date, journ_ac_id ";
						strInsert1 = $"{strInsert1}) VALUES ('RN', '";

						// removed this adding into the description field as well
						strInsert1 = $"{strInsert1}', 'Added Research Only Company - {StringsHelper.Replace(lst_company.GetListItem(0), "'", "''", 1, -1, CompareMethod.Binary)}'";

						if (lst_contact_info.Text.Trim() == "")
						{
							strInsert1 = $"{strInsert1},''";
						}
						else
						{
							strInsert1 = $"{strInsert1},{temp_contact_id.ToString()}";
						}

						strInsert1 = $"{strInsert1}, {nCompanyID.ToString()}, '{modAdminCommon.gbl_User_ID}', 'A', ";
						strInsert1 = $"{strInsert1}'{DateTime.Parse(strDateTime).ToString("d")}', ";
						strInsert1 = $"{strInsert1}'{Strings.FormatDateTime(DateTime.Parse(strDateTime), DateFormat.ShortTime)}', ";
						strInsert1 = $"{strInsert1}'{DateTime.Parse(strDateTime).ToString()}', '{DateTime.Parse(strDateTime).ToString("d")}'";
						strInsert1 = $"{strInsert1},{nReference_AircraftID.ToString()}";
						strInsert1 = $"{strInsert1}) ";

						modAdminCommon.ADO_Transaction("BeginTrans");
						DbCommand TempCommand_7 = null;
						TempCommand_7 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_7);
						TempCommand_7.CommandText = strInsert1;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand_7.CommandType = (CommandType) (((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()) + ((int) CommandType.Text));
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_7);
						TempCommand_7.ExecuteNonQuery();
						modAdminCommon.ADO_Transaction("CommitTrans");

					}

					if (sReference_ContactType.Trim() == "2X")
					{
						strDateTime = DateTimeHelper.ToString(DateTime.Now);
						strInsert1 = "INSERT INTO Journal (";
						strInsert1 = $"{strInsert1}journ_subcategory_code, journ_description,journ_subject, journ_contact_id, journ_comp_id, ";
						strInsert1 = $"{strInsert1}journ_user_id, journ_status, journ_entry_date, journ_entry_time, journ_action_date, journ_date, journ_ac_id ";
						strInsert1 = $"{strInsert1}) VALUES ('RN', '";

						strInsert1 = $"{strInsert1}Added Non-Exclusive Sales Contact - {StringsHelper.Replace(lst_company.GetListItem(0), "'", "''", 1, -1, CompareMethod.Binary)}', 'Added Non-Exclusive Sales Contact - {StringsHelper.Replace(lst_company.GetListItem(0), "'", "''", 1, -1, CompareMethod.Binary)}'";

						strInsert1 = $"{strInsert1},{temp_contact_id.ToString()}, {nCompanyID.ToString()}, '{modAdminCommon.gbl_User_ID}', 'A', ";
						strInsert1 = $"{strInsert1}'{DateTime.Parse(strDateTime).ToString("d")}', ";
						strInsert1 = $"{strInsert1}'{Strings.FormatDateTime(DateTime.Parse(strDateTime), DateFormat.ShortTime)}', ";
						strInsert1 = $"{strInsert1}'{DateTime.Parse(strDateTime).ToString()}', '{DateTime.Parse(strDateTime).ToString("d")}'";
						strInsert1 = $"{strInsert1},{nReference_AircraftID.ToString()}";
						strInsert1 = $"{strInsert1}) ";

						modAdminCommon.ADO_Transaction("BeginTrans");
						DbCommand TempCommand_8 = null;
						TempCommand_8 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_8);
						TempCommand_8.CommandText = strInsert1;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand_8.CommandType = (CommandType) (((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()) + ((int) CommandType.Text));
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_8);
						TempCommand_8.ExecuteNonQuery();
						modAdminCommon.ADO_Transaction("CommitTrans");
					}

					if (sReference_ContactType.Trim() == "36")
					{
						strDateTime = DateTimeHelper.ToString(DateTime.Now);
						strInsert1 = "INSERT INTO Journal (journ_subcategory_code, journ_description,journ_subject, journ_contact_id, journ_comp_id, ";
						strInsert1 = $"{strInsert1}journ_user_id, journ_status, journ_entry_date, journ_entry_time, journ_action_date, journ_date, journ_ac_id ";
						strInsert1 = $"{strInsert1}) VALUES ('RN', '";

						strInsert1 = $"{strInsert1}Added Operator - {StringsHelper.Replace(lst_company.GetListItem(0), "'", "''", 1, -1, CompareMethod.Binary)}', 'Added Operator - {StringsHelper.Replace(lst_company.GetListItem(0), "'", "''", 1, -1, CompareMethod.Binary)}'";

						strInsert1 = $"{strInsert1},0, {nCompanyID.ToString()}, '{modAdminCommon.gbl_User_ID}', 'A', ";
						strInsert1 = $"{strInsert1}'{DateTime.Parse(strDateTime).ToString("d")}', ";
						strInsert1 = $"{strInsert1}'{Strings.FormatDateTime(DateTime.Parse(strDateTime), DateFormat.ShortTime)}', ";
						strInsert1 = $"{strInsert1}'{DateTime.Parse(strDateTime).ToString()}', '{DateTime.Parse(strDateTime).ToString("d")}'";
						strInsert1 = $"{strInsert1},{nReference_AircraftID.ToString()}";
						strInsert1 = $"{strInsert1}) ";

						modAdminCommon.ADO_Transaction("BeginTrans");
						DbCommand TempCommand_9 = null;
						TempCommand_9 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_9);
						TempCommand_9.CommandText = strInsert1;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand_9.CommandType = (CommandType) (((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()) + ((int) CommandType.Text));
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_9);
						TempCommand_9.ExecuteNonQuery();
						modAdminCommon.ADO_Transaction("CommitTrans");
					}
					//-------------- INSERT INTO JOURNAL NOTES FOR DELETE---------------------------------------------------------------------------

				}

				bool add_last_journal = false;

				add_last_journal = false;
				if (cbo_contact_type.Visible)
				{
					add_last_journal = true;
				}

				Hide_MySelf();

				if (modCommon.pubf_EncodeEntryPoints(tFormEntryPoint) == modGlobalVars.gFIND_ASHR)
				{
					//UPGRADE_WARNING: (2065) Form event Form.Activated has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
					frm_ShareRelationships.DefInstance.Form_Activated(frm_ShareRelationships.DefInstance, new EventArgs());
				}


				// ADDED MSW - so that on changes these dont change - getting messed up - 12/30/19
				if (add_last_journal && modCommon.pubf_EncodeEntryPoints(tFormEntryPoint) != modGlobalVars.gFIND_EXBK)
				{
					frm_aircraft.DefInstance.added_research_only = false;
					frm_aircraft.DefInstance.Last_Journal_ID = "";
					if (sReference_ContactType.Trim() == "71")
					{
						frm_aircraft.DefInstance.added_research_only = true;
						frm_aircraft.DefInstance.Last_Journal_ID = Last_Journal_ID(Convert.ToInt32(Double.Parse(nReference_AircraftID.ToString())));
					}
				}
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"clear_company_research_action_Error ({Information.Err().Number.ToString()}) {excep.Message}", "Company (frm_Company)");
				modAdminCommon.ADO_Transaction("RollbackTrans");
			}


		}
		private string Last_Journal_ID(int inAC_ID)
		{

			string result = "";

			ADORecordSetHelper snp_Exist = new ADORecordSetHelper();

			string Query = "SELECT TOP 1 journ_id From Journal ";
			Query = $"{Query}WHERE journ_ac_id = {inAC_ID.ToString()}  AND (journ_subcategory_code='RN') ";
			Query = $"{Query}ORDER BY journ_id DESC";


			snp_Exist.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
			if (!(snp_Exist.BOF && snp_Exist.EOF))
			{
				result = Convert.ToString(snp_Exist["journ_id"]);
			}
			else
			{
			}
			snp_Exist.Close();
			return result;
		}
		private void grd_find_company_singleClickBodyCode()
		{

			int tmpJournID = 0;
			int nCompanyID = 0;
			int nContactID = 0;
			int lRow = 0;

			try
			{

				lRow = grd_find_company.MouseRow;

				pnl_contact_info.Visible = false;
				pnl_duplicates.Visible = false;

				this.Cursor = Cursors.WaitCursor; //aey 5/21/04

				if (lRow == 0 && chk_aircraft_count.CheckState != CheckState.Checked)
				{

					Set_Sort_Order(ref sOrderBy, false);
					fill_find_company_Grd(ref sOrderBy);

				}
				else if (lRow == 1 && chk_aircraft_count.CheckState == CheckState.Checked)
				{ 

					Set_Sort_Order(ref sOrderBy, false);
					fill_find_company_Grd(ref sOrderBy);

				}
				else
				{

					if ((grd_find_company.CurrentRowIndex > 0 && chk_aircraft_count.CheckState != CheckState.Checked) || (grd_find_company.CurrentRowIndex > 1 && chk_aircraft_count.CheckState == CheckState.Checked))
					{

						nCompanyID = Convert.ToInt32(Double.Parse(grd_find_company.get_RowData(grd_find_company.CurrentRowIndex).ToString().Trim()));
						//UPGRADE_ISSUE: (2064) MSHierarchicalFlexGridLib.MSHFlexGrid property grd_find_company.BandData was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						nContactID = Convert.ToInt32(Double.Parse(grd_find_company.BandData(grd_find_company.CurrentRowIndex).ToString().Trim()));

						if (modCommon.pubf_EncodeEntryPoints(tFormEntryPoint) == modGlobalVars.gFIND_ACOR)
						{

							lst_company2.Visible = false;

							if (nCompanyID > 0)
							{
								modCommon.Build_Company_NameAddress(lst_company2, nCompanyID, 0);
								lst_company2.Visible = true;
							}

							modCompanyFind.FillContactLists(nReference_CompanyID, nCompanyID, nContactID, cbo_contact, cbo_contact2, opt_contacts.Checked);

						}
						else
						{

							select_company_contact();

						}

						if (pnl_associate_aircraft.Visible)
						{

							cmd_Associate.Visible = true;

							if (modCommon.pubf_EncodeEntryPoints(tFormEntryPoint) == modGlobalVars.gFIND_ACCH || modCommon.pubf_EncodeEntryPoints(tFormEntryPoint) == modGlobalVars.gFIND_CHCT || modCommon.pubf_EncodeEntryPoints(tFormEntryPoint) == modGlobalVars.gFIND_1000 || modCommon.pubf_EncodeEntryPoints(tFormEntryPoint) == modGlobalVars.gFIND_ADOC)
							{
								cbo_contact_type.Visible = false;
							}
							else if (modCommon.pubf_EncodeEntryPoints(tFormEntryPoint) == modGlobalVars.gFIND_ACCA || modCommon.pubf_EncodeEntryPoints(tFormEntryPoint) == modGlobalVars.gFIND_ACOR || modCommon.pubf_EncodeEntryPoints(tFormEntryPoint) == modGlobalVars.gFIND_EXBK || modCommon.pubf_EncodeEntryPoints(tFormEntryPoint) == modGlobalVars.gFIND_ASHR)
							{ 
								cbo_contact_type.Visible = true;
							}

						}

						if (chk_history.CheckState == CheckState.Checked)
						{
							// grd_find_company.Col = grd_find_company.Cols - 1
							grd_find_company.CurrentColumnIndex = 16;
							tmpJournID = Convert.ToInt32(Conversion.Val(grd_find_company[grd_find_company.CurrentRowIndex, grd_find_company.CurrentColumnIndex].FormattedValue.ToString().Trim()));
						}
						else
						{
							tmpJournID = 0;
						}


						cmd_Add_Contact.Visible = true;

						if (modCommon.pubf_EncodeEntryPoints(tFormEntryPoint) == modGlobalVars.gFIND_FDMF)
						{
							cmd_find_duplicate.Text = modCommon.pubf_FindFormEntryActionsToString(tFormActionTypes);
							// Removed all references to confirm company mjm 6/16/08
							//        cmd_Confirm_Company.Visible = False
							chk_match_city.Visible = false;
							lbl_Label1[23].Visible = false;
							txt_num_characters.Visible = false;
							chk_include_history.Visible = false;
						}
						else
						{

							if (pnl_company_info.Visible && modCommon.pubf_EncodeEntryPoints(tFormEntryPoint) != modGlobalVars.gFIND_FDMF)
							{

								cmd_find_duplicate.Visible = true;
								lbl_Label1[23].Visible = true;
								txt_num_characters.Visible = true;
								chk_match_city.Visible = true;
								chk_include_history.Visible = true;

							}

						}

						if (modCommon.pubf_EncodeEntryPoints(tFormEntryPoint) == modGlobalVars.gFIND_ACOR)
						{
							cbo_contact_type_SelectedIndexChanged(cbo_contact_type, new EventArgs());
						}

						grd_find_company.CurrentColumnIndex = 0;
						grd_find_company.ColSel = grd_find_company.ColumnsCount - 1;

						if (cmd_find_duplicate.Text.ToUpper() == ("Find Potential Duplicates").ToUpper() && grd_find_company[grd_find_company.CurrentRowIndex, grd_find_company.CurrentColumnIndex].FormattedValue.ToString().Substring(0, Math.Min(22, grd_find_company[grd_find_company.CurrentRowIndex, grd_find_company.CurrentColumnIndex].FormattedValue.ToString().Length)).ToUpper() == ("Awaiting Documentation").ToUpper())
						{
							cmd_find_duplicate.Visible = false;
							lbl_Label1[23].Visible = false;
							txt_num_characters.Visible = false;
							chk_match_city.Visible = false;
							chk_include_history.Visible = false;
						}

						grd_find_company.RowSel = grd_find_company.CurrentRowIndex;

					} // If (grd_find_company.Row > 0 And chk_aircraft_count.Value <> vbChecked) Or (grd_find_company.Row > 1 And chk_aircraft_count.Value = vbChecked) Then

				} // If lRow = 0 And chk_aircraft_count.Value <> vbChecked Then

				this.Cursor = CursorHelper.CursorDefault;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"grd_find_company_click_Error ({Information.Err().Number.ToString()}) {excep.Message}", "frm_Find_Company");
				this.Cursor = CursorHelper.CursorDefault;
			}

		}

		private void grd_find_company_doubleClickBodyCode()
		{

			frm_Company o_Local_Show_Company = null;
			int lCol = 0;
			string strColName = "";

			string strCompId = "";
			int lCompId = 0;
			string strContactId = "";
			int lContactId = 0;
			string strJournId = "";
			int lJournId = 0;

			int iCnt1 = 0;

			int lRow = grd_find_company.MouseRow;

			try
			{

				if (((lRow > 0 && chk_aircraft_count.CheckState != CheckState.Checked) || (lRow > 1 && chk_aircraft_count.CheckState == CheckState.Checked)) && grd_find_company.CurrentRowIndex > 0)
				{

					if (modCommon.pubf_EncodeEntryPoints(tFormEntryPoint) != modGlobalVars.gFIND_NONE)
					{
						MessageBox.Show($"Please Single Click When {modCommon.pubf_FindFormEntryActionsToString(tFormActionTypes)}!", modCommon.pubf_FindFormEntryPointsToString(tFormEntryPoint), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}

					//-------------------------------------------
					// Find CompId, Contact Id and JournId

					strCompId = "0";
					lCompId = 0;
					strContactId = "0";
					lContactId = 0;
					strJournId = "0";
					lJournId = 0;

					if (lCompId == 0)
					{
						strCompId = Convert.ToString(grd_find_company[lRow, 14].Value);
						if (Information.IsNumeric(strCompId))
						{
							lCompId = Convert.ToInt32(Double.Parse(strCompId));
						}
						strContactId = Convert.ToString(grd_find_company[lRow, 15].Value);
						if (Information.IsNumeric(strContactId))
						{
							lContactId = Convert.ToInt32(Double.Parse(strContactId));
						}
						strJournId = Convert.ToString(grd_find_company[lRow, 16].Value);
						if (Information.IsNumeric(strJournId))
						{
							lJournId = Convert.ToInt32(Double.Parse(strJournId));
						}
					}

					this.Cursor = Cursors.WaitCursor;

					modCommon.Unload_Form("frm_Company");

					o_Local_Show_Company = frm_Company.CreateInstance();
					//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//VB.Global.Load(o_Local_Show_Company);
					o_Local_Show_Company.Form_Initialize();
					o_Local_Show_Company.StartForm = modGlobalVars.tStart_Form;
					o_Local_Show_Company.Reference_CompanyID = lCompId;
					o_Local_Show_Company.Reference_CompanyJID = lJournId;
					o_Local_Show_Company.CompanyEntryPoint = EntryPoint;
					o_Local_Show_Company.Show();
					//UPGRADE_WARNING: (2065) Form method o_Local_Show_Company.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
					o_Local_Show_Company.BringToFront();
					//UPGRADE_WARNING: (2065) Form event Form.Activated has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
					o_Local_Show_Company.Form_Activated(null, new EventArgs());

					this.Cursor = CursorHelper.CursorDefault;


				} // If ((lRow > 0 And chk_aircraft_count.Value <> vbChecked) Or (lRow > 1 And chk_aircraft_count.Value = vbChecked)) And grd_find_company.Row > 0 Then
			}
			catch (Exception e)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				if (Information.Err().Number == 364)
				{ // we doubble clicked on a company that was removed or had an error loading
					this.Cursor = CursorHelper.CursorDefault;
					return;
				}

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"grd_find_company_dblclick_Error ({Information.Err().Number.ToString()}) {e.Message}", "frm_Find_Company");
				this.Cursor = CursorHelper.CursorDefault;
			}

		}

		private void grd_find_company_Click(Object eventSender, EventArgs eventArgs) => compTimer1.Enabled = true; // Turn On Timer


		private void grd_find_company_DoubleClick(Object eventSender, EventArgs eventArgs)
		{

			compTimer1.Enabled = false; // Turn Off Timer So The Single Click Is Never Called

			gbCompTimer1DoubleClick = true;

			if (!gbCompTimer1SingleClick)
			{

				grd_find_company_doubleClickBodyCode();

			} // If gbCompTimer1SingleClick = False Then

			gbCompTimer1DoubleClick = false;

		}

		private void cmd_Stop_Click(Object eventSender, EventArgs eventArgs) => bIsStopped = true;


		private void cmd_Stop_MouseMove(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;

			if (this.Cursor == Cursors.WaitCursor)
			{
				this.Cursor = CursorHelper.CursorDefault;
			}

		}

		private void compTimer1_Tick(Object eventSender, EventArgs eventArgs)
		{

			compTimer1.Enabled = false; // Turn OFF The Timer

			if (!gbCompTimer1DoubleClick)
			{

				gbCompTimer1SingleClick = true;

				if (grd_find_company.CurrentRowIndex > 0)
				{

					grd_find_company_singleClickBodyCode();

				}

				gbCompTimer1SingleClick = false;

			} // If gbccTimer1DoubleClick = False Then

		}

		public void Set_Form_View()
		{
			//  '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			//   Initialize the 'Associate' fields if coming from 'Aircraft_Change' form
			//  '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			cmd_Associate.Visible = false;

			if (modCommon.pubf_FindFormEntryActionsToString(tFormActionTypes) != "")
			{
				cmd_Associate.Text = modCommon.pubf_FindFormEntryActionsToString(tFormActionTypes);
			}

			if (modCommon.pubf_EncodeEntryPoints(tFormEntryPoint) == modGlobalVars.gFIND_ACCH || modCommon.pubf_EncodeEntryPoints(tFormEntryPoint) == modGlobalVars.gFIND_CHCT)
			{
				pnl_associate_aircraft.Visible = true;
				lbl_Label1[22].Visible = false;
				cbo_contact_type.Visible = false;

				if (modCommon.pubf_EncodeEntryPoints(tFormEntryPoint) == modGlobalVars.gFIND_CHCT)
				{
					cmd_Associate.Text = sReference_HistContactName.Trim();
					cmd_awaiting_docsOK.Text = $"{sReference_HistContactName.Trim()} To Awaiting Documentation";
				}

			}
			else if (modCommon.pubf_EncodeEntryPoints(tFormEntryPoint) == modGlobalVars.gFIND_ADOC)
			{ 
				pnl_associate_aircraft.Visible = true;
				lbl_Label1[22].Visible = false;
				cbo_contact_type.Visible = false;

				if (modCommon.pubf_FindFormEntryActionsToString(tFormActionTypes) == "")
				{
					Hide_MySelf();
				}

			}
			else if (modCommon.pubf_EncodeEntryPoints(tFormEntryPoint) == modGlobalVars.gFIND_ACOR || modCommon.pubf_EncodeEntryPoints(tFormEntryPoint) == modGlobalVars.gFIND_EXBK || modCommon.pubf_EncodeEntryPoints(tFormEntryPoint) == modGlobalVars.gFIND_ASHR || modCommon.pubf_EncodeEntryPoints(tFormEntryPoint) == modGlobalVars.gFIND_1000)
			{ 

				pnl_associate_aircraft.Visible = true;
				lbl_Label1[22].Visible = false;
				cbo_contact_type.Visible = false;
				lst_aircraft_info.Visible = false;
				//UPGRADE_ISSUE: (2064) Threed.SSPanel property pnl_associate_aircraft.Caption was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				pnl_associate_aircraft.setCaption("");

				cbo_relationship.Visible = false;
				lbl_Label1[27].Visible = false;

				cbo_contact.Visible = false;
				cbo_contact2.Visible = false;
				lst_company2.Visible = false;

			}

		}

		public void Set_Sort_Order(ref string strOrderBy, bool bIgnoreGridClick)
		{
			//   aey 5/20/04 - Added column sorts for fields from Company_Aircraf_Counts

			string strColName = "";

			int lRow = grd_find_company.MouseRow;
			int lCol = grd_find_company.MouseCol;

			strOrderBy = "ORDER BY comp_name, comp_city, comp_state, comp_id, comp_journ_id ";

			if (lRow == 0 && !bIgnoreGridClick)
			{

				strColName = ($"{Convert.ToString(grd_find_company[lRow, lCol].Value)} ").Trim();

				switch(strColName)
				{
					case "Company" : 
						strOrderBy = "ORDER BY comp_name, comp_id, comp_journ_id"; 
						break;
					case "City" : 
						strOrderBy = "ORDER BY comp_city, comp_name, comp_id"; 
						break;
					case "State" : 
						strOrderBy = "ORDER BY comp_state, comp_name, comp_id"; 
						break;
					case "Country" : 
						strOrderBy = "ORDER BY comp_country, comp_state, comp_city, comp_name, comp_id"; 
						break;
					case "Contact" : 
						strOrderBy = "ORDER BY contact_last_name, contact_first_name, comp_name, comp_id"; 
						break;
					case "Name" : 
						strOrderBy = "ORDER BY contact_first_name, contact_last_name, comp_name, comp_id"; 
						break;
					case "Title" : 
						strOrderBy = "ORDER BY contact_title, comp_name, comp_id"; 
						break;
					case "Rep" : 
						strOrderBy = "ORDER BY comp_account_id, comp_name, comp_id, comp_journ_id"; 
						break;
					case "Comp ID" : 
						strOrderBy = "ORDER BY comp_id, comp_journ_id"; 
						break;
					case "Contact ID" : 
						strOrderBy = "ORDER BY contact_id, comp_id, comp_journ_id"; 
						break;
					case "Journal ID" : 
						strOrderBy = "ORDER BY comp_journ_id, comp_id"; 
						 
						break;
				} // Case strColName

			} // If lRow = 0 And Not bIgnoreGridClick Then

		} // Set_Sort_Order

		private bool SomeCriteria(string Continentlist, string Regionlist, string Countrylist, string Statelist)
		{

			bool result = false;
			Control Control = null;


			// this check added by rtw on 4/26/2011 to allow search if on a mail list selection
			if (Strings.Len(cbo_MailList.Text.Trim()) > 0)
			{
				return true;
			}

			if (Statelist != "" || Countrylist != "" || Continentlist != "" || Regionlist != "")
			{
				return true;
			}

			if (lst_title_group.SelectedItems.Count > 0 && !ListBoxHelper.GetSelected(lst_title_group, 0))
			{
				return true;
			}

			if (bACProsClicked)
			{
				return true;
			}

			// Loop Through CO
			//UPGRADE_WARNING: (2065) Form property frm_Find_Company.Controls has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
			foreach (Control ControlIterator in ContainerHelper.Controls(this))
			{
				Control = ControlIterator;


				// Only Test ComboBox and TextBox Controls
				if ((Control is ComboBox) || (Control is TextBox))
				{

					//UPGRADE_TODO: (1067) Member Text is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					if (ErrorHandlingHelper.ResumeNextExpr<bool>(() => Convert.ToString(Control.Text) != ""))
					{ // Has Something Been Selected

						if (Control.Name == "cbo_account_rep" || Control.Name == "cbo_dup_account_rep" || Control.Name == "cbo_business_type" || Control.Name == "txt_num_characters" || Control.Name == "txt_dup_num_chars" || Control.Name == "cbo_contact_type" || Control.Name == "cbo_owner_type" || Control.Name == "cbo_compare" || Control.Name == "cbo_product")
						{
							result = true;
							try
							{
								break;
							}
							catch
							{
							}
						}
					}
				}
				//Control
				Control = default(Control);
			}

			if (chk_share_relationships.CheckState == CheckState.Checked || chk_share_relationships_withoutAC.CheckState == CheckState.Checked)
			{
				result = true;
			}

			return result;
		}

		private string BuildCompanyWhere(string strOrderBy)
		{

			string Query = "";
			string strAddressSearch = "";

			string Separator = " where ";
			if (opt_contacts.Checked)
			{ // Select contact AND company information
				if (Strings.Len(txt_contact_last_name.Text.Trim()) > 0)
				{
					Query = $"{Query}{Separator}contact_last_name LIKE '{modAdminCommon.Fix_Quote(($"{txt_contact_last_name.Text} ").Trim())}%' ";
					Separator = " and ";
				}
				if (Strings.Len(txt_contact_first_name.Text.Trim()) > 0)
				{
					Query = $"{Query}{Separator}contact_first_name LIKE '{modAdminCommon.Fix_Quote(($"{txt_contact_first_name.Text} ").Trim())}' ";
					Separator = " and ";
				}
				if (Strings.Len(cbo_contact_title.Text.Trim()) > 0)
				{
					Query = $"{Query}{Separator}contact_title LIKE '{modAdminCommon.Fix_Quote(($"{cbo_contact_title.Text} ").Trim())}%' ";
					Separator = " and ";
				}
			}

			//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			// Complete the WHERE portions of the Query
			//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			if (chk_history.CheckState == CheckState.Unchecked)
			{
				Query = $"{Query}{Separator}comp_journ_id = 0 ";
				Separator = " and ";
				if (opt_contacts.Checked)
				{
					Query = $"{Query}{Separator}contact_journ_id = 0 ";
					Separator = " AND ";
				}
			}

			if (Strings.Len(txt_comp_name.Text.Trim()) > 0)
			{

				if (txt_comp_name.Text.StartsWith("%", StringComparison.Ordinal) || txt_comp_name.Text.StartsWith("*", StringComparison.Ordinal))
				{
					Query = $"{Query}{Separator}comp_name_search LIKE '%{modAdminCommon.Fix_Quote(modCommon.Get_Name_Search_String($"{txt_comp_name.Text} "))}%' ";
				}
				else
				{
					Query = $"{Query}{Separator}comp_name_search LIKE '{modAdminCommon.Fix_Quote(modCommon.Get_Name_Search_String($"{txt_comp_name.Text} "))}%' ";
				}

				Separator = " AND ";
			}

			if (Strings.Len(txt_comp_city.Text.Trim()) > 0)
			{
				Query = $"{Query}{Separator}comp_city LIKE '{modAdminCommon.Fix_Quote(($"{txt_comp_city.Text} ").Trim())}%' ";
				Separator = " AND ";
			}

			if (Strings.Len(txt_comp_address.Text.Trim()) > 0)
			{
				strAddressSearch = modCommon.LeaveOnlyAlphaAndNumeric(txt_comp_address.Text).ToUpper();
				if (txt_comp_address.Text.StartsWith("*", StringComparison.Ordinal))
				{
					strAddressSearch = $"%{strAddressSearch}";
				}
				Query = $"{Query}{Separator}(comp_address1_search LIKE '{strAddressSearch}%' ";
				Query = $"{Query}          OR comp_address2_search LIKE '{strAddressSearch}%') ";
				Separator = " AND ";
			}

			if (Strings.Len(txt_comp_zip_code.Text.Trim()) > 0)
			{
				Query = $"{Query}{Separator}comp_zip_code LIKE '{($"{txt_comp_zip_code.Text} ").Trim()}%' ";
				Separator = " AND ";
			}

			if (cbo_account_rep.Text.Trim() != "All" && cbo_account_rep.Text.Trim() != "")
			{
				Query = $"{Query}{Separator}comp_account_id = '{($"{cbo_account_rep.Text} ").Trim()}' ";
				Separator = " AND ";
			}
			//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			// Add the ORDER BY portion of the Query
			// [NOTE: BUILT in the 'From_Load' and 'grd_find_company_Click' routines]
			//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			Query = $"{Query} {strOrderBy}";

			return Query;

		}

		private string BuildCompanyQuery(ref string strOrderBy)
		{

			//   aey 5/20/04 - Added table join for Company_Aircraf_Counts
			// RTW - 9/21/2010 - MODIFIED SEARCH TO USE MORE EFFICIENT PHONE NUMBER SEARCH
			string result = "";
			string Query = "";
			string Separator = "";
			int i = 0;
			string Product = "";
			string cbo_MailList = "";
			string tmp_MailListCode = "";
			bool ProdFlag = false;
			string PQuery = "";
			string CQuery = "";
			StringBuilder HQuery = new StringBuilder();
			string strTemp = "";
			string strAddressSearch = "";

			try
			{

				Query = "";
				result = "";

				string tmpquery = "";

				if (bACProsClicked)
				{

					result = "SELECT DISTINCT comp_id, comp_name, comp_address1, comp_address2, comp_journ_id, comp_account_id, ";
					result = $"{result}comp_city, comp_state, comp_zip_code, comp_country, comp_email_address,cbus_name, comp_account_id, comp_marketing_rep, ";


					result = $"{result} replace(replace(replace(STUFF(( ";
					result = $"{result} select svud_desc + ', ' as svud_desc from Company_Services_Used with (NOLOCK) ";
					result = $"{result} inner join Services_Used with (NOLOCK) on svud_id = csu_svud_id ";
					result = $"{result} Where csu_comp_id = comp_id ";
					result = $"{result} FOR XML PATH('')),1,1,''), '<svud_desc>', ''), '</svud_desc>', ''), 'svud_desc>', '') As CompService ";



					result = $"{result}STUFF((SELECT DISTINCT ';'+sub_serv_code FROM Subscription WITH (NOLOCK) ";
					result = $"{result}WHERE (sub_comp_id = comp_id) ";
					result = $"{result}AND (sub_start_date <= GETDATE()) ";
					result = $"{result}AND (sub_end_date IS NULL OR sub_end_date > GETDATE()) ";
					result = $"{result}AND (sub_marketing_flag = 'N') ";
					result = $"{result}FOR XML PATH('')),1,1,'') As ActiveSubService ";

					result = $"{result}FROM Company WITH(NOLOCK), Company_Business_Type WITH(NOLOCK), Business_Type_Reference WITH(NOLOCK) ";
					result = $"{result} WHERE bustypref_type = cbus_type";
					result = $"{result} AND bustypref_comp_id = comp_id";
					result = $"{result} AND bustypref_journ_id = comp_journ_id";
					result = $"{result} AND (bustypref_type IN ('DB','DS','FI','MF','PH','PM','PN'))";
					result = $"{result} AND (comp_journ_id = 0)";

					if (chk_inactives.CheckState == CheckState.Checked)
					{

					}
					else
					{
						result = $"{result}{Separator} and  comp_active_flag = 'Y' ";
					}


					result = $"{result} AND (comp_account_type <> 'UI')";
					result = $"{result} AND (comp_account_type <> 'UN')";
					result = $"{result} AND (comp_name Not like 'Await%')";
					result = $"{result} AND (comp_city IS NOT NULL)  AND (comp_city <> '')";
					result = $"{result} AND (comp_business_type = cbus_type) ";

					// 07/25/2016 - By David D. Cruger; Added Search for Customers or Non-Customers
					if (optSearchCust[1].Checked)
					{ // Customers Only
						//   BuildCompanyQuery = BuildCompanyQuery & "AND (EXISTS (SELECT NULL FROM Services_Used WITH (NOLOCK) "
						//   BuildCompanyQuery = BuildCompanyQuery & "             WHERE (svud_code = comp_service) "
						//   BuildCompanyQuery = BuildCompanyQuery & "             AND (svud_desc LIKE '%JETNET%' OR svud_desc LIKE '%AVDATA%') "
						//  BuildCompanyQuery = BuildCompanyQuery & "            ) "
						//   BuildCompanyQuery = BuildCompanyQuery & "    ) "

						result = $"{result}AND (EXISTS ";
						result = $"{result} SELECT NULL FROM Company_Services_Used WITH (NOLOCK)";
						result = $"{result} WHERE csu_comp_id = comp_id  and csu_svud_id in (25)"; // 25 is jetnet
						result = $"{result}    ) ";




					}

					if (optSearchCust[2].Checked)
					{ // Non-Customers

						result = $"{result}AND NOT (EXISTS ";
						result = $"{result} SELECT NULL FROM Company_Services_Used WITH (NOLOCK)";
						result = $"{result} WHERE csu_comp_id = comp_id  and csu_svud_id in (25)"; // 25 is jetnet
						result = $"{result}    ) ";

					}




					return $"{result}{strOrderBy}";

				}
				else
				{
					//acpros not clicked
					if (opt_contacts.Checked)
					{
						Query = "SELECT DISTINCT comp_id,comp_account_id,comp_marketing_rep,comp_name,comp_city,comp_state,comp_country,comp_journ_id,comp_last_contact_date,contact_id,";
						Query = $"{Query}contact_first_name,contact_last_name,contact_middle_initial,contact_title,cbus_name,contact_email_address, contact_suffix, ";


						Query = $"{Query} replace(replace(replace(STUFF(( ";
						Query = $"{Query} select svud_desc + ', ' as svud_desc from Company_Services_Used with (NOLOCK) ";
						Query = $"{Query} inner join Services_Used with (NOLOCK) on svud_id = csu_svud_id ";
						Query = $"{Query} Where csu_comp_id = comp_id ";
						Query = $"{Query} FOR XML PATH('')),1,1,''), '<svud_desc>', ''), '</svud_desc>', ''), 'svud_desc>', '') As CompService, ";



						Query = $"{Query}STUFF((SELECT DISTINCT ';'+sub_serv_code FROM Subscription WITH (NOLOCK) ";
						Query = $"{Query}WHERE (sub_comp_id = comp_id) ";
						Query = $"{Query}AND (sub_start_date <= GETDATE()) ";
						Query = $"{Query}AND (sub_end_date IS NULL OR sub_end_date > GETDATE()) ";
						Query = $"{Query}AND (sub_marketing_flag = 'N') ";
						Query = $"{Query}FOR XML PATH('')),1,1,'') As ActiveSubService, ";
						Query = $"{Query}(SELECT TOP 1 DNSEMail_Id FROM Do_Not_Send_EMail WITH (NOLOCK) WHERE (DNSEMail_Address = contact_email_address)) As DNSEMail_Id ";
					}
					else
					{
						//opt_Contacts.Value = false
						if (chk_aircraft_count.CheckState == CheckState.Unchecked && cbo_product[0].SelectedIndex == 0 && cbo_owner_type[0].SelectedIndex == 0)
						{
							Query = "SELECT DISTINCT comp_id,comp_name,comp_city,comp_state,comp_country,comp_journ_id,comp_last_contact_date,comp_account_id,comp_marketing_rep,cbus_name, ";


							Query = $"{Query} replace(replace(replace(STUFF(( ";
							Query = $"{Query} select svud_desc + ', ' as svud_desc from Company_Services_Used with (NOLOCK) ";
							Query = $"{Query} inner join Services_Used with (NOLOCK) on svud_id = csu_svud_id ";
							Query = $"{Query} Where csu_comp_id = comp_id ";
							Query = $"{Query} FOR XML PATH('')),1,1,''), '<svud_desc>', ''), '</svud_desc>', ''), 'svud_desc>', '') As CompService, ";


							Query = $"{Query}STUFF((SELECT DISTINCT ';'+sub_serv_code FROM Subscription WITH (NOLOCK) ";
							Query = $"{Query}WHERE (sub_comp_id = comp_id) ";
							Query = $"{Query}AND (sub_start_date <= GETDATE()) ";
							Query = $"{Query}AND (sub_end_date IS NULL OR sub_end_date > GETDATE()) ";
							Query = $"{Query}AND (sub_marketing_flag = 'N') ";
							Query = $"{Query}FOR XML PATH('')),1,1,'') As ActiveSubService ";
						}
						else
						{
							//chk_AircraftCount.Value <> 0
							//aey 5/20/04
							Query = "SELECT DISTINCT comp_id,comp_name,comp_city,comp_state,comp_country,comp_journ_id,comp_last_contact_date,comp_account_id,comp_marketing_rep,cbus_name, ";
							//Query = Query & "(SELECT TOP 1 svud_Desc FROM Services_Used WITH (NOLOCK) WHERE (svud_code = comp_service)) As CompService, "


							Query = $"{Query} replace(replace(replace(STUFF(( ";
							Query = $"{Query} select svud_desc + ', ' as svud_desc from Company_Services_Used with (NOLOCK) ";
							Query = $"{Query} inner join Services_Used with (NOLOCK) on svud_id = csu_svud_id ";
							Query = $"{Query} Where csu_comp_id = comp_id ";
							Query = $"{Query} FOR XML PATH('')),1,1,''), '<svud_desc>', ''), '</svud_desc>', ''), 'svud_desc>', '') As CompService, ";


							Query = $"{Query}STUFF((SELECT DISTINCT ';'+sub_serv_code FROM Subscription WITH (NOLOCK) ";
							Query = $"{Query}WHERE (sub_comp_id = comp_id) ";
							Query = $"{Query}AND (sub_start_date <= GETDATE()) ";
							Query = $"{Query}AND (sub_end_date IS NULL OR sub_end_date > GETDATE()) ";
							Query = $"{Query}AND (sub_marketing_flag = 'N') ";
							Query = $"{Query}FOR XML PATH('')),1,1,'') As ActiveSubService ";
						}
					}

					if (chk_show_yacht_count.CheckState == CheckState.Checked)
					{
						Query = $"{Query}, (SELECT COUNT(DISTINCT yr_yt_id) FROM Yacht_Reference WITH (NOLOCK) WHERE yr_comp_id = comp_id) as ycount ";
					}

					//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
					// Build the FROM portion of the Query and
					// Start the WHERE portion of the Query
					//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
					if (opt_contacts.Checked)
					{ // Select contact AND company information
						Query = $"{Query} FROM Company WITH(NOLOCK)";

						Query = $"{Query} LEFT OUTER JOIN Company_Business_Type WITH(NOLOCK) ON (comp_business_type=cbus_type)";

						// JOIN THE BUSINESS TYPE REF TABLE ONLY IF WE HAVE TO
						if (cbo_business_type.Text.Trim() != "All" && cbo_business_type.Text.Trim() != "")
						{
							Query = $"{Query} INNER JOIN Business_Type_reference WITH(NOLOCK) ON (bustypref_comp_id = comp_id AND bustypref_journ_id = comp_journ_id)";
						}

						Query = $"{Query} LEFT OUTER JOIN Contact WITH(NOLOCK) ON (comp_id = contact_comp_id AND comp_journ_id = contact_journ_id) ";
						if (chk_history.CheckState == CheckState.Unchecked)
						{
							Query = $"{Query}{Separator} AND (contact_active_flag = 'Y') ";
							Separator = " AND ";
						}

						// *********************************************
						// RTW - ADDED MAIL LIST SELECTION ON 4/26/2011
						if (this.cbo_MailList.SelectedIndex > 0)
						{
							i = (this.cbo_MailList.Text.IndexOf('-') + 1);
							tmp_MailListCode = this.cbo_MailList.Text.Substring(0, Math.Min(i - 1, this.cbo_MailList.Text.Length));
							Query = $"{Query} INNER JOIN Mailing_List on comp_id=ml_comp_id and contact_id = ml_contact_id and ml_jcat_subcategory_code='{tmp_MailListCode}'";
						}

						Query = $"{Query} WHERE ";
						Separator = "";

						if (($"{txt_contact_last_name.Text} ").Trim() != "")
						{
							Query = $"{Query}{Separator}(replace(contact_last_name, ' ', '') LIKE '{StringsHelper.Replace(modAdminCommon.Fix_Quote(txt_contact_last_name.Text.Trim()), " ", "", 1, -1, CompareMethod.Binary)}%') ";
							Separator = " AND ";
						}

						if (($"{txt_contact_first_name.Text} ").Trim() != "")
						{
							Query = $"{Query}{Separator}(contact_first_name LIKE '{modAdminCommon.Fix_Quote(txt_contact_first_name.Text.Trim())}%') ";
							Separator = " AND ";
						}

						if (($"{cbo_contact_title.Text} ").Trim() != "")
						{
							Query = $"{Query}{Separator}(contact_title LIKE '{modAdminCommon.Fix_Quote(($"{cbo_contact_title.Text} ").Trim())}%') ";
							Separator = " AND ";
						}
						else if ((lst_title_group.SelectedItems.Count > 0) && (!ListBoxHelper.GetSelected(lst_title_group, 0)))
						{ 
							Query = $"{Query}{Separator}contact_title IN (SELECT ctitlegref_title_name FROM Contact_Title_Group_Reference WITH(NOLOCK) WHERE ctitlegref_group_name IN (";

							int tempForEndVar = lst_title_group.Items.Count - 1;
							for (i = 1; i <= tempForEndVar; i++)
							{
								if (ListBoxHelper.GetSelected(lst_title_group, i))
								{
									Query = $"{Query}'{lst_title_group.GetListItem(i)}',";
								}
							}

							Query = $"{Query.Substring(0, Math.Min(Strings.Len(Query) - 1, Query.Length))}))";

							Separator = " AND ";
						}

						// Search Contact Phone Number
						strTemp = txt_pnum_number_full.Text.Trim();
						strTemp = modCommon.LeaveOnlyNumeric(strTemp);

						if (strTemp != "")
						{

							Query = $"{Query}{Separator} (EXISTS (SELECT NULL FROM Phone_Numbers  WITH (NOLOCK) ";
							Query = $"{Query}                      WHERE (pnum_comp_id = comp_id) ";
							Query = $"{Query}                      AND (pnum_journ_id = comp_journ_id) ";
							Query = $"{Query}                      AND (pnum_contact_id = contact_id) ";
							Query = $"{Query}                      AND (pnum_number_full_search LIKE '{strTemp}%') ";
							Query = $"{Query}                     ) ";
							Query = $"{Query}              ) ";

							Separator = " AND ";

						} // If strTemp <> "" Then

						if (txt_contact_email_address.Text.Trim() != "")
						{
							Query = $"{Query}{Separator} (contact_email_address LIKE '{modAdminCommon.Fix_Quote(($"{txt_contact_email_address.Text} ").Trim())}%' or contact_research_email_address LIKE '{modAdminCommon.Fix_Quote(($"{txt_contact_email_address.Text} ").Trim())}%' )  ";
							Separator = " AND ";
						}

						// added the inactives  - MSW
						if (chk_history.CheckState == CheckState.Unchecked && chk_inactives.CheckState == CheckState.Unchecked)
						{
							Query = $"{Query}{Separator}  (comp_active_flag = 'Y')";
							Separator = " AND ";
						}


					}
					else
					{
						//opt_Contacts.Value = false
						// JUST COMPANIES BEING QUERIED
						if (txt_comp_phone.Text.Trim() != "")
						{
							Query = $"{Query} FROM Company WITH(NOLOCK)";
							Query = $"{Query} LEFT OUTER JOIN Company_Business_Type WITH(NOLOCK) ON (comp_business_type=cbus_type)";

							// JOIN THE BUSINESS TYPE REF TABLE ONLY IF WE HAVE TO
							if (cbo_business_type.Text.Trim() != "All" && cbo_business_type.Text.Trim() != "")
							{
								Query = $"{Query} INNER JOIN Business_Type_reference WITH(NOLOCK) ON (bustypref_comp_id = comp_id AND bustypref_journ_id = comp_journ_id)";
							}

							// *********************************************
							// RTW - ADDED MAIL LIST SELECTION ON 4/26/2011
							if (this.cbo_MailList.SelectedIndex > 0)
							{
								i = (this.cbo_MailList.Text.IndexOf('-') + 1);
								tmp_MailListCode = this.cbo_MailList.Text.Substring(0, Math.Min(i - 1, this.cbo_MailList.Text.Length));
								Query = $"{Query} INNER JOIN Mailing_List on comp_id=ml_comp_id and ml_contact_id=0 and ml_jcat_subcategory_code='{tmp_MailListCode}'";
							}


							Query = $"{Query} WHERE ";
							Separator = "";
						}
						else
						{
							// tmp_message = "Companies"
							if (chk_share_relationships.CheckState == CheckState.Unchecked)
							{
								Query = $"{Query} FROM Company WITH(NOLOCK)";
								Query = $"{Query} LEFT OUTER JOIN Company_Business_Type WITH(NOLOCK) ON (comp_business_type=cbus_type) ";

								// JOIN THE BUSINESS TYPE REF TABLE ONLY IF WE HAVE TO
								if (cbo_business_type.Text.Trim() != "All" && cbo_business_type.Text.Trim() != "")
								{
									Query = $"{Query} INNER JOIN Business_Type_reference WITH(NOLOCK) ON (bustypref_comp_id = comp_id AND bustypref_journ_id = comp_journ_id) ";
								}
								// *********************************************
								// RTW - ADDED MAIL LIST SELECTION ON 4/26/2011
								if (this.cbo_MailList.SelectedIndex > 0)
								{
									i = (this.cbo_MailList.Text.IndexOf('-') + 1);
									tmp_MailListCode = this.cbo_MailList.Text.Substring(0, Math.Min(i - 1, this.cbo_MailList.Text.Length));
									Query = $"{Query} INNER JOIN Mailing_List on comp_id=ml_comp_id  and ml_jcat_subcategory_code='{tmp_MailListCode}' "; // taken out msw - 4/2/21 and ml_contact_id=0
								}
								Query = $"{Query} WHERE comp_name IS NOT NULL";
							}
							else
							{
								Query = $"{Query} from Company WITH(NOLOCK)";
								Query = $"{Query} LEFT OUTER JOIN Company_Business_Type WITH(NOLOCK) ON (comp_business_type=cbus_type)";

								// JOIN THE BUSINESS TYPE REF TABLE ONLY IF WE HAVE TO
								if (cbo_business_type.Text.Trim() != "All" && cbo_business_type.Text.Trim() != "")
								{
									Query = $"{Query} INNER JOIN Business_Type_reference WITH(NOLOCK) ON (bustypref_comp_id = comp_id AND bustypref_journ_id = comp_journ_id) ";
								}
								// *********************************************
								// RTW - ADDED MAIL LIST SELECTION ON 4/26/2011
								if (this.cbo_MailList.SelectedIndex > 0)
								{
									i = (this.cbo_MailList.Text.IndexOf('-') + 1);
									tmp_MailListCode = this.cbo_MailList.Text.Substring(0, Math.Min(i - 1, this.cbo_MailList.Text.Length));
									Query = $"{Query} INNER JOIN Mailing_List on comp_id=ml_comp_id and ml_contact_id=0 and ml_jcat_subcategory_code='{tmp_MailListCode}' ";
								}
								Query = $"{Query} INNER JOIN aircraft_reference WITH(NOLOCK) ON comp_id = cref_comp_id and comp_journ_id = cref_journ_id ";
								Query = $"{Query} INNER JOIN share_reference WITH(NOLOCK) ON cref_id = sref_cref_id ";
								Query = $"{Query} WHERE comp_name IS NOT NULL ";

							}
							Separator = " AND ";

						}

						if (chk_history.CheckState == CheckState.Unchecked && chk_inactives.CheckState == CheckState.Unchecked)
						{
							Query = $"{Query}{Separator}comp_active_flag = 'Y' ";
							Separator = " AND ";
						}
					}

					//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
					// Complete the WHERE portions of the Query
					//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
					if (chk_share_relationships_withoutAC.CheckState == CheckState.Checked)
					{
						Query = $"{Query} and comp_id IN(SELECT sref_comp_id FROM share_reference) ";
					}


					if (chk_history.CheckState == CheckState.Unchecked)
					{
						Query = $"{Query}{Separator}(comp_journ_id = 0) ";
						Separator = " AND ";
					}

					if (txt_comp_name.Text.Trim() != "")
					{

						Query = $"{Query}{Separator}";

						if (dba_check.CheckState == CheckState.Checked)
						{
							Query = $"{Query} ( ";
						}

						if (txt_comp_name.Text.StartsWith("%", StringComparison.Ordinal) || txt_comp_name.Text.StartsWith("*", StringComparison.Ordinal))
						{
							Query = $"{Query}(comp_name_search LIKE '%{modAdminCommon.Fix_Quote(modCommon.Get_Name_Search_String($"{txt_comp_name.Text} "))}%') ";
						}
						else
						{
							Query = $"{Query}(comp_name_search LIKE '{modAdminCommon.Fix_Quote(modCommon.Get_Name_Search_String($"{txt_comp_name.Text} "))}%') ";
						}
						Separator = " AND ";

						// added in MSW 5/15/2013
						// ADDED DBA SEARCH OF ALT NAME FIELD
						if (dba_check.CheckState == CheckState.Checked)
						{
							if (txt_comp_name.Text.StartsWith("%", StringComparison.Ordinal) || txt_comp_name.Text.StartsWith("*", StringComparison.Ordinal))
							{
								Query = $"{Query} OR replace(comp_altname_search, ' ', '') LIKE '%{modAdminCommon.Fix_Quote(modCommon.Get_Name_Search_String($"{txt_comp_name.Text} "))}%') ";
							}
							else
							{
								Query = $"{Query} OR replace(comp_altname_search, ' ', '') LIKE '{modAdminCommon.Fix_Quote(modCommon.Get_Name_Search_String($"{txt_comp_name.Text} "))}%') ";
							}
						}

					}

					if (cbo_agency_type.Text.Trim().ToLower() != ("NOT Specified").ToLower() && cbo_agency_type.Text.Trim() != "")
					{
						Query = $"{Query}{Separator}(comp_agency_type = '{cbo_agency_type.Text.Substring(0, Math.Min(1, cbo_agency_type.Text.Length))}') ";
					}

					//8/7/2001 rje start change company search to call routine to strip out punctuation
					if (txt_comp_city.Text.Trim() != "")
					{
						Query = $"{Query}{Separator}(comp_city LIKE '{modAdminCommon.Fix_Quote(($"{txt_comp_city.Text} ").Trim())}%') ";
						Separator = " AND ";
					}

					if (txt_comp_address.Text.Trim() != "")
					{
						strAddressSearch = modCommon.LeaveOnlyAlphaAndNumeric(txt_comp_address.Text).ToUpper();

						Query = $"{Query}{Separator} ( ";
						Query = $"{Query}  (comp_address1_search LIKE '{strAddressSearch}%' or comp_address2_search LIKE '{strAddressSearch}%')   ";

						Query = $"{Query} or (comp_description LIKE '%{modAdminCommon.Fix_Quote(txt_comp_address.Text.Trim())}%' and comp_description LIKE '%phys%address%')  ";
						Query = $"{Query}) ";

						Separator = " AND ";

					}

					if (sStatelist.Trim() != "")
					{
						Query = $"{Query}{Separator}(comp_state IN ({sStatelist})) ";
						Separator = " AND ";

						if (sCountrylist.Trim() != "")
						{
							Query = $"{Query}{Separator}comp_country in ({sCountrylist}) ";
						}
					}
					else
					{
						if (sCountrylist.Trim() != "")
						{
							// *****************************************
							// SEARCH FOR COUNTRY BASED ON LIST SELECTED
							Query = $"{Query}{Separator}comp_country in ({sCountrylist}) ";
							Separator = " AND ";
						}
						else
						{
							// *****************************************
							// SEARCH FOR CONINENT BASED ON LIST SELECTED
							if (sContinentlist.Trim() != "" && opt_continent_region[0].Checked)
							{
								Query = $"{Query}{Separator}comp_country IN (SELECT distinct country_name FROM country WITH(NOLOCK) WHERE country_continent_name IN ({sContinentlist}))";
								Separator = " AND ";
							}
							// *****************************************
							// SEARCH FOR REGION BASED ON LIST SELECTED
							if (sRegionlist.Trim() != "" && opt_continent_region[1].Checked)
							{
								Query = $"{Query}{Separator}comp_country in (SELECT distinct geographic_country_name FROM geographic WITH(NOLOCK) WHERE geographic_region_name in ({sRegionlist}))";
								tmpquery = $"SELECT distinct geographic_state_code FROM geographic WITH(NOLOCK) WHERE geographic_region_name IN ({sRegionlist}) and (geographic_state_code is not null and geographic_state_code <>'')";
								if (modAdminCommon.Exist(tmpquery))
								{

									Query = $"{Query}{Separator}comp_state IN (SELECT distinct geographic_state_code FROM geographic WITH(NOLOCK) WHERE geographic_region_name in ({sRegionlist})) ";
									Separator = " AND ";
								}
							}
							// END IF ON CONTRY LIST
						}
						// END IF ON STATE LIST
					}

					if (txt_comp_zip_code.Text.Trim() != "")
					{
						Query = $"{Query}{Separator}(comp_zip_code LIKE '{txt_comp_zip_code.Text.Trim()}%') ";
						Separator = " AND ";
					}

					if (cbo_account_rep.Text.Trim() != "All" && cbo_account_rep.Text.Trim() != "")
					{
						Query = $"{Query}{Separator}(comp_account_id = '{cbo_account_rep.Text.Trim()}') ";
						Separator = " AND ";
					}

					strTemp = txt_comp_phone.Text.Trim();
					strTemp = modCommon.LeaveOnlyNumeric(strTemp);

					if (strTemp != "")
					{


						Query = $"{Query}{Separator} (EXISTS (SELECT NULL FROM Phone_Numbers  WITH (NOLOCK) ";
						Query = $"{Query}                      WHERE (pnum_comp_id = comp_id) ";
						Query = $"{Query}                      AND (pnum_journ_id = comp_journ_id) ";
						Query = $"{Query}                      AND (pnum_contact_id = 0) ";
						Query = $"{Query}                      AND (pnum_number_full_search LIKE '{strTemp}%') ";
						Query = $"{Query}                     ) ";
						Query = $"{Query}              ) ";

						Separator = " AND ";

					} // If strTemp <> "" Then



					if (txt_comp_email.Text.Trim() != "")
					{
						Query = $"{Query}{Separator}(comp_email_address LIKE '{modAdminCommon.Fix_Quote(txt_comp_email.Text.Trim())}%') ";
						Separator = " AND ";
					}

					if (txt_comp_web_address.Text.Trim() != "")
					{
						Query = $"{Query}{Separator}(comp_web_address LIKE '{modAdminCommon.Fix_Quote(txt_comp_web_address.Text.Trim())}%') ";
						Separator = " AND ";
					}

					if (cbo_business_type.Text.Trim() != "All" && cbo_business_type.Text.Trim() != "")
					{
						Query = $"{Query}{Separator}(bustypref_type = '{cbo_business_type.Text.Trim().Substring(0, Math.Min(2, cbo_business_type.Text.Trim().Length))}') ";
						Separator = " AND ";
					}

					HQuery = new StringBuilder("");

					if (chk_aircraft_count.CheckState == CheckState.Checked)
					{

						for (int K = 0; K <= 1; K++)
						{

							ProdFlag = false;
							CQuery = "";

							bool tempBool = false;
							string auxVar = (cbo_owner_type[K].SelectedIndex > 0).ToString().Trim();
							if ((Boolean.TryParse(auxVar, out tempBool)) ? tempBool : Convert.ToBoolean(Double.Parse(auxVar)))
							{ //aey 5/20/04
								switch(cbo_owner_type[K].GetListItem(cbo_owner_type[K].SelectedIndex))
								{
									case "Whole Owners" : 
										CQuery = $"cac_fullsale_owner {cbo_compare[K].GetListItem(cbo_compare[K].SelectedIndex)} {Conversion.Val($"{txt_ac_value[K].Text} ").ToString()}"; 
										break;
									case "Whole Operators" : 
										CQuery = $"cac_fullsale_operator {cbo_compare[K].GetListItem(cbo_compare[K].SelectedIndex)} {Conversion.Val($"{txt_ac_value[K].Text} ").ToString()}"; 
										break;
									case "Share Owners" : 
										CQuery = $"cac_sharesale_owner {cbo_compare[K].GetListItem(cbo_compare[K].SelectedIndex)} {Conversion.Val($"{txt_ac_value[K].Text} ").ToString()}"; 
										break;
									case "Fractional Owners" : 
										CQuery = $"cac_fractionsale_owner {cbo_compare[K].GetListItem(cbo_compare[K].SelectedIndex)} {Conversion.Val($"{txt_ac_value[K].Text} ").ToString()}"; 
										break;
								}
							}
							else
							{
								CQuery = "";
							}

							if (cbo_product[K].SelectedIndex > 0)
							{
								ProdFlag = true;

								switch((cbo_product[K].Text.Trim().Substring(0, Math.Min(1, cbo_product[K].Text.Trim().Length))))
								{
									case "H" : 
										if (K == 0)
										{
											HQuery = new StringBuilder(" AND ( comp_product_helicopter_flag = 'Y' ");
										}
										else if (K == 1)
										{ 
											if (chk_OR.CheckState == CheckState.Checked)
											{
												HQuery.Append(") OR ( comp_product_helicopter_flag = 'Y' ");
											}
											else
											{
												HQuery.Append(") AND ( comp_product_helicopter_flag = 'Y' ");
											}
										} 
										 
										break;
									case "B" : 
										if (K == 0)
										{
											HQuery = new StringBuilder(" AND ( comp_product_business_flag = 'Y' ");
										}
										else if (K == 1)
										{ 
											if (chk_OR.CheckState == CheckState.Checked)
											{
												HQuery.Append(") OR ( comp_product_business_flag = 'Y' ");
											}
											else
											{
												HQuery.Append(") AND ( comp_product_business_flag = 'Y' ");
											}
										} 
										break;
									case "C" : 
										if (K == 0)
										{
											HQuery = new StringBuilder(" AND ( comp_product_commercial_flag = 'Y' ");
										}
										else if (K == 1)
										{ 
											if (chk_OR.CheckState == CheckState.Checked)
											{
												HQuery.Append(") OR ( comp_product_commercial_flag = 'Y' ");
											}
											else
											{
												HQuery.Append(") AND ( comp_product_commercial_flag = 'Y' ");
											}
										} 
										break;
									case "R" : 
										//              If K = 0 Then 
										//                HQuery = " AND ( comp_product_regional_flag = 'Y' " 
										//              ElseIf K = 1 Then 
										//                If chk_OR.Value = vbChecked Then 
										//                  HQuery = HQuery & ") OR ( comp_product_regional_flag = 'Y' " 
										//                Else 
										//                  HQuery = HQuery & ") AND ( comp_product_regional_flag = 'Y' " 
										//                End If 
										//              End If 
										break;
									case "F" : 
										//              If K = 0 Then 
										//                HQuery = " AND ( comp_product_fortune_flag = 'Y' " 
										//              ElseIf K = 1 Then 
										//                If chk_OR.Value = vbChecked Then 
										//                  HQuery = HQuery & ") OR ( comp_product_fortune_flag = 'Y' " 
										//                Else 
										//                  HQuery = HQuery & ") AND ( comp_product_fortune_flag = 'Y' " 
										//                End If 
										//              End If 
										break;
									case "P" : 
										if (K == 0)
										{
											HQuery = new StringBuilder(" AND ( comp_product_airbp_flag = 'Y' ");
										}
										else if (K == 1)
										{ 
											if (chk_OR.CheckState == CheckState.Checked)
											{
												HQuery.Append(") OR ( comp_product_airbp_flag = 'Y' ");
											}
											else
											{
												HQuery.Append(") AND ( comp_product_airbp_flag = 'Y' ");
											}
										} 
										break;
									case "A" : 
										if (K == 0)
										{
											HQuery = new StringBuilder(" AND ( comp_product_abi_flag = 'Y' ");
										}
										else if (K == 1)
										{ 
											if (chk_OR.CheckState == CheckState.Checked)
											{
												HQuery.Append(") OR ( comp_product_abi_flag = 'Y' ");
											}
											else
											{
												HQuery.Append(") AND ( comp_product_abi_flag = 'Y' ");
											}
										} 
										break;
									case "Y" : 
										if (K == 0)
										{
											HQuery = new StringBuilder(" AND ( comp_product_yacht_flag = 'Y' ");
										}
										else if (K == 1)
										{ 
											if (chk_OR.CheckState == CheckState.Checked)
											{
												HQuery.Append(") OR ( comp_product_yacht_flag = 'Y' ");
											}
											else
											{
												HQuery.Append(") AND ( comp_product_yacht_flag = 'Y' ");
											}
										} 
										break;
								}

							}

							if (K == 0)
							{
								if (!ProdFlag)
								{
									if (CQuery.Trim() != "")
									{
										HQuery = new StringBuilder($" AND ((comp_id in(select cac_comp_id FROM Company_Aircraft_Count WITH(NOLOCK) WHERE {CQuery})");
									}
								}
								else if (ProdFlag)
								{ 
									if (CQuery.Trim() != "")
									{
										HQuery.Append($") AND (comp_id IN(select cac_comp_id FROM Company_Aircraft_Count WITH(NOLOCK) WHERE {CQuery})");
									}
								}
							}
							else if (K == 1)
							{ 
								if (!ProdFlag)
								{
									if (CQuery.Trim() != "")
									{
										if (chk_OR.CheckState == CheckState.Checked)
										{
											HQuery = new StringBuilder($" OR ((comp_id IN(select cac_comp_id FROM Company_Aircraft_Count WITH(NOLOCK) WHERE {CQuery})");
										}
										else
										{
											HQuery = new StringBuilder($" AND ((comp_id in(select cac_comp_id FROM Company_Aircraft_Count WITH(NOLOCK) WHERE {CQuery})");
										}
									}
								}
								else if (ProdFlag)
								{ 
									if (CQuery.Trim() != "")
									{
										if (chk_OR.CheckState == CheckState.Checked)
										{
											HQuery.Append($") OR (comp_id IN(select cac_comp_id FROM Company_Aircraft_Count WITH(NOLOCK) WHERE {CQuery})");
										}
										else
										{
											HQuery.Append($") AND (comp_id IN(select cac_comp_id FROM Company_Aircraft_Count WITH(NOLOCK) WHERE {CQuery})");
										}
									}
								}

							}

						}

					}
					else
					{
						//chk_AircraftCount = unchecked

						for (int K = 0; K <= 1; K++)
						{

							if (cbo_product[K].SelectedIndex > 0 && cbo_owner_type[K].SelectedIndex == 0)
							{


								switch((cbo_product[K].Text.Trim().Substring(0, Math.Min(1, cbo_product[K].Text.Trim().Length))))
								{
									case "H" : 
										if (K == 0)
										{
											HQuery = new StringBuilder(" AND (comp_product_helicopter_flag = 'Y'");
										}
										else if (K == 1)
										{ 
											if (chk_OR.CheckState == CheckState.Checked)
											{
												HQuery.Append(") OR (comp_product_helicopter_flag = 'Y'");
											}
											else
											{
												HQuery.Append(") AND (comp_product_helicopter_flag = 'Y'");
											}
										} 
										 
										break;
									case "B" : 
										if (K == 0)
										{
											HQuery = new StringBuilder(" AND (comp_product_business_flag = 'Y'");
										}
										else if (K == 1)
										{ 
											if (chk_OR.CheckState == CheckState.Checked)
											{
												HQuery.Append(") OR (comp_product_business_flag = 'Y'");
											}
											else
											{
												HQuery.Append(") AND (comp_product_business_flag = 'Y'");
											}
										} 
										break;
									case "C" : 
										if (K == 0)
										{
											HQuery = new StringBuilder(" AND (comp_product_commercial_flag = 'Y'");
										}
										else if (K == 1)
										{ 
											if (chk_OR.CheckState == CheckState.Checked)
											{
												HQuery.Append(") OR (comp_product_commercial_flag = 'Y'");
											}
											else
											{
												HQuery.Append(") AND (comp_product_commercial_flag = 'Y'");
											}
										} 
										break;
									case "R" : case "F" : 
										 
										break;
									case "P" : 
										if (K == 0)
										{
											HQuery = new StringBuilder(" AND (comp_product_airbp_flag = 'Y'");
										}
										else if (K == 1)
										{ 
											if (chk_OR.CheckState == CheckState.Checked)
											{
												HQuery.Append(") OR (comp_product_airbp_flag = 'Y'");
											}
											else
											{
												HQuery.Append(") AND (comp_product_airbp_flag = 'Y'");
											}
										} 
										break;
									case "A" : 
										if (K == 0)
										{
											HQuery = new StringBuilder(" AND (comp_product_abi_flag = 'Y'");
										}
										else if (K == 1)
										{ 
											if (chk_OR.CheckState == CheckState.Checked)
											{
												HQuery.Append(") OR (comp_product_abi_flag = 'Y'");
											}
											else
											{
												HQuery.Append(") AND (comp_product_abi_flag = 'Y'");
											}
										} 
										 
										break;
								}

							}
						}
					}

					if (cbo_cert_drop.Text.Trim() != "")
					{
						Query = $"{Query} and exists(select top 1 ccert_comp_id from Company_Certification with (NOLOCK)";
						Query = $"{Query} inner join Company_Certification_Type on  ccerttype_id = ccert_type_id";
						Query = $"{Query} where ccert_journ_id = 0 and ccert_comp_id = comp_id  and ccerttype_type = '{cbo_cert_drop.Text.Trim()}'";
						Query = $"{Query} ) ";
					}

					if (HQuery.ToString().Trim() != "")
					{
						Query = $"{Query}{($"{HQuery.ToString()})").Trim()}";
					}

					if (chk_aircraft_count.CheckState == CheckState.Checked && chk_hide_zero.CheckState == CheckState.Checked)
					{
						Query = $"{Query}AND comp_id IN(SELECT distinct cac_comp_id FROM Company_Aircraft_Count WITH(NOLOCK) where cac_total_referenced > 0 )";
					}


					if (chk_primary.CheckState == CheckState.Checked)
					{
						Query = $"{Query}{Separator} exists (select ac_id from aircraft with (NOLOCK) inner join aircraft_reference on cref_ac_id = ac_id where cref_comp_id = comp_id and ac_journ_id = 0  and cref_primary_poc_flag = 'Y') ";
						Separator = " AND ";
					}


					if (chk_ACPros.CheckState == CheckState.Checked)
					{
						Query = $"{Query}{Separator}(comp_acpros_flag = 'Y') ";
						Separator = " AND ";
					}


					// ADDED MSW - 6/22/2020
					if (txt_airport_id_name.Text.Trim() != "")
					{
						if (Information.IsNumeric(txt_airport_id_name.Text.Trim()))
						{
							// then search airport ID
							Query = $"{Query}{Separator}(comp_aport_id = {txt_airport_id_name.Text.Trim()}) ";
							Separator = " AND ";
						}
						else
						{
							// then search icao and iata
							Query = $"{Query}{Separator}  ";

							Query = $"{Query} ( exists (select aport_id from Airport with (NOLOCK) where aport_id = comp_aport_id and aport_icao_code = '{txt_airport_id_name.Text.Trim()}') ";
							Query = $"{Query} or  exists (select aport_id from Airport with (NOLOCK) where aport_id = comp_aport_id and aport_iata_code = '{txt_airport_id_name.Text.Trim()}')) ";

							Separator = " AND ";
						}


					}

					if (txt_company_id[0].Text.Trim() != "")
					{
						Query = $"{Query}{Separator}(comp_id = {txt_company_id[0].Text.Trim()}) ";
						Separator = " AND ";
					}

					// added 2/4/2013 MSW

					if (chk_prod_code[0].CheckState == CheckState.Checked || chk_prod_code[1].CheckState == CheckState.Checked || chk_prod_code[2].CheckState == CheckState.Checked || chk_prod_code[3].CheckState == CheckState.Checked)
					{
						Separator = "";
						Query = $"{Query} AND ( ";

						if (chk_prod_code[0].CheckState == CheckState.Checked)
						{
							Query = $"{Query} comp_product_business_flag = 'Y' ";
							Separator = " OR ";
						}

						if (chk_prod_code[1].CheckState == CheckState.Checked)
						{
							Query = $"{Query}{Separator} comp_product_helicopter_flag = 'Y' ";
							Separator = " OR ";
						}

						if (chk_prod_code[2].CheckState == CheckState.Checked)
						{
							Query = $"{Query}{Separator} comp_product_commercial_flag = 'Y' ";
							Separator = " OR ";
						}

						if (chk_prod_code[3].CheckState == CheckState.Checked)
						{
							Query = $"{Query}{Separator} comp_product_yacht_flag = 'Y' ";
						}
						Query = $"{Query} ) ";
						Separator = " AND ";
					}


					// 02/19/2016 - By David D. Cruger
					// Added Search To Find Companies With Contact Address Flag Set
					if (chkCompContactAddressFlag.CheckState == CheckState.Checked)
					{
						Query = $"{Query} AND (comp_contact_address_flag = 'Y') ";
					}

					// 3/14/2008 - By David D. Cruger
					// Added Search by SubId/TechId

					if (txt_company_id[1].Text.Trim() != "")
					{
						Query = $"{Query}{Separator}(EXISTS (SELECT NULL FROM Subscription WITH(NOLOCK) WHERE (sub_comp_id = comp_id) AND (sub_id = {txt_company_id[1].Text.Trim()}))) ";
					}

					// 07/25/2016 - By David D. Cruger; Added Search for Customers or Non-Customers
					if (optSearchCust[1].Checked)
					{ // Customers Only
						Query = $"{Query}AND (EXISTS (  ";



						Query = $"{Query} select top 1 svud_desc   from Company_Services_Used with (NOLOCK) ";
						Query = $"{Query} inner join Services_Used with (NOLOCK) on svud_id = csu_svud_id ";
						Query = $"{Query} Where csu_comp_id = comp_id ";
						Query = $"{Query} and csu_svud_id in (25) "; // added msw 4/2/20

						Query = $"{Query}            ) ";
						Query = $"{Query}    ) ";
					}

					// ADDED MSW - 3/31/20
					if (txt_cert_search.Text.Trim() != "")
					{
						Query = $"{Query} and comp_id in (select  distinct ccert_comp_id from company_certification with (NOLOCK) ";
						Query = $"{Query} where ccert_journ_id = 0 and ccert_number like '{StringsHelper.Replace(txt_cert_search.Text, "'", "", 1, -1, CompareMethod.Binary)}%') "; // changed to a like statement - MSW - 2/21/23
					}

					if (optSearchCust[2].Checked)
					{ // Non-Customers

						Query = $"{Query} AND NOT EXISTS ( ";
						Query = $"{Query} SELECT NULL FROM Company_Services_Used WITH (NOLOCK)";
						Query = $"{Query} WHERE csu_comp_id = comp_id  and csu_svud_id in (25)"; // 25 is jetnet
						Query = $"{Query}    ) ";


					}

					if (strOrderBy.Trim() == "")
					{
						strOrderBy = " ORDER BY comp_name, comp_id,comp_journ_id ";
					}

					Query = $"{Query} {strOrderBy}";

					return Query;
				}
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"BuildCompanyQuery_Error: {excep.Message} {result}");
			}
			return result;
		} // BuildCompanyQuery

		private void ToolbarButtonsSetup()
		{


			ToolStrip tbr = tbr_ToolBar; //gap-note ToolStrip instead of Control


			ControlHelper.SetVisible(tbr, true);
			ControlHelper.SetEnabled(tbr, true);

			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[2].Visible = true;
			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[4].Visible = true;
			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[6].Visible = false;
			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[8].Visible = true;

			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[2].Enabled = true;
			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[4].Enabled = true;
			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[6].Enabled = false;
			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[8].Enabled = true;

			tbr.BringToFront();
			 // tbr

		}

		private void ToolbarSetup()
		{


			ToolStrip tbr = tbr_ToolBar; //gap-note ToolStrip instead of Control


			ControlHelper.SetVisible(tbr, true);
			ControlHelper.SetEnabled(tbr, true);

			//UPGRADE_TODO: (1067) Member ImageList is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.ImageList = mdi_ResearchAssistant.DefInstance.imgNormal;

			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			(tbr.Items[2] as ToolStripButton).Image = (Image) resources.GetObject( "Home");
			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			(tbr.Items[4] as ToolStripButton).Image = (Image) resources.GetObject( "Back");
			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			(tbr.Items[6] as ToolStripButton).Image = (Image) resources.GetObject( "Save");
			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			(tbr.Items[8] as ToolStripButton).Image = (Image) resources.GetObject( "Help");

			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[2].Text = "Home";
			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[4].Text = "Back";
			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[6].Text = "Save";
			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[8].Text = "Help";

			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[2].ToolTipText = "Go to Main Menu";
			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[4].ToolTipText = "Go to Previous Screen";
			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[6].ToolTipText = "Save screen data";
			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[8].ToolTipText = "Online Help";
			 // tbr

		}

		private void grd_find_company_MouseDown(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;


			//comp_account_id
			grd_find_company.CurrentColumnIndex = 7;
			cmd_add_to_pub.Tag = grd_find_company[grd_find_company.CurrentRowIndex, grd_find_company.CurrentColumnIndex].FormattedValue.ToString();

			grd_find_company.CurrentColumnIndex = 0;

		}

		private void grd_potential_duplicates_Click(Object eventSender, EventArgs eventArgs)
		{

			string tmpName = "";
			string chr = "";

			int X = 0;
			if (grd_potential_duplicates.CurrentRowIndex > 0)
			{
				grd_potential_duplicates.CurrentColumnIndex = 0;

				frame_potential_dups.Visible = false;
				frame_potential_dups_grid.Visible = false;

				if (chk_dup_contacts.CheckState == CheckState.Unchecked)
				{
					opt_companies.Checked = true;
					Set_Company_Versus_Contact_Search();
					txt_comp_name.Text = grd_potential_duplicates[grd_potential_duplicates.CurrentRowIndex, grd_potential_duplicates.CurrentColumnIndex].FormattedValue.ToString();
				}
				else
				{
					opt_contacts.Checked = true;
					Set_Company_Versus_Contact_Search();
					grd_potential_duplicates.CurrentColumnIndex = 4;
					tmpName = grd_potential_duplicates[grd_potential_duplicates.CurrentRowIndex, grd_potential_duplicates.CurrentColumnIndex].FormattedValue.ToString().Trim();

					if (tmpName != "")
					{

						// NOTE this will have issues if contact has a middle initial
						X = Strings.Len(tmpName);

						int tempForEndVar = X;
						for (int K = 2; K <= tempForEndVar; K++)
						{
							chr = tmpName.Substring(Math.Min(K - 1, tmpName.Length), Math.Min(1, Math.Max(0, tmpName.Length - (K - 1))));
							if (Strings.Asc(chr[0]) < 97)
							{ //look for upper case
								txt_contact_last_name.Text = tmpName.Substring(Math.Min(0, tmpName.Length), Math.Min(K - 1, Math.Max(0, tmpName.Length))).Trim();
								txt_contact_first_name.Text = tmpName.Substring(Math.Min(K - 1, tmpName.Length)).Trim();
								break;
							}
						}

					}
				}

			}

		}

		private void lst_Area_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{
			sContinentlist = "";
			sRegionlist = "";
			sCountrylist = "";
			sStatelist = "";

			Set_DemographicList(ref sContinentlist, ref sRegionlist, ref sCountrylist, ref sStatelist);
			modFillCompConControls.Fill_Country_List(lst_country, lst_area, sContinentlist, sRegionlist);

		}

		private void lst_Country_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{
			sContinentlist = "";
			sRegionlist = "";
			sCountrylist = "";
			sStatelist = "";

			Set_DemographicList(ref sContinentlist, ref sRegionlist, ref sCountrylist, ref sStatelist);
			modFillCompConControls.Fill_State_List((RadioButton[]) opt_continent_region, lst_state, lst_country, lst_area, sContinentlist, sRegionlist, sCountrylist, sStatelist);

		}

		private void lst_Company_SelectedIndexChanged(Object eventSender, EventArgs eventArgs) => ToolTipMain.SetToolTip(lst_company, lst_company.Text);


		private void lst_duplicates_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{

			cmd_remove_duplicates.Visible = true;

			Select_Duplicate_Company(ref nDuplicate_CompanyID, ref nDuplicate_JournalID);

			ToolTipMain.SetToolTip(lst_duplicates, lst_duplicates.Text);

		}

		public void Set_Company_Versus_Contact_Search()
		{

			pnl_contact.Visible = false;
			pnl_aircraft_info.Visible = false;

			if (opt_contacts.Checked)
			{
				pnl_contact.Visible = true;
				pnl_contact.Refresh();
			}
			else if (opt_companies.Checked)
			{ 
				pnl_aircraft_info.Visible = true;
				pnl_aircraft_info.Refresh();
				chk_aircraft_count.Visible = true;
			}

		}

		public void mnuEditRemoveDupPhones_Click(Object eventSender, EventArgs eventArgs) => modCompanyFind.Run_Remove_Duplicate_Phone_Numbers();


		public void mnuFindCompanyShowUserHistory_Click(Object eventSender, EventArgs eventArgs)
		{

			if (frm_Main_Menu.DefInstance.mnuShowUserHistory.Text == "Show User History")
			{
				frm_UserHistory.DefInstance.Refresh_User_History_Grids("All");
				mnuFindCompanyShowUserHistory.Text = "Hide User History";
				frm_Main_Menu.DefInstance.mnuShowUserHistory.Text = "Hide User History";
				modCommon.CenterFormOnHomebaseMainForm(frm_UserHistory.DefInstance);
				frm_UserHistory.DefInstance.Show();
			}
			else
			{
				frm_UserHistory.DefInstance.TimerOff();
				mnuFindCompanyShowUserHistory.Text = "Show User History";
				frm_Main_Menu.DefInstance.mnuShowUserHistory.Text = "Show User History";
				frm_UserHistory.DefInstance.Hide();
			}

		}

		public void mnuUnHideDupGrid_Click(Object eventSender, EventArgs eventArgs)
		{
			frame_potential_dups_grid.Visible = true;

			if (pnl_display_results.Visible)
			{
				pnl_display_results.Visible = false;
			}

		}

		public void mnuViewDups20_Click(Object eventSender, EventArgs eventArgs)
		{

			frame_potential_dups.Visible = true;

			if (pnl_display_results.Visible)
			{
				pnl_display_results.Visible = false;
			}

		}

		private bool isInitializingComponent;
		private void opt_Companies_CheckedChanged(Object eventSender, EventArgs eventArgs)
		{
			if (((RadioButton) eventSender).Checked)
			{
				if (isInitializingComponent)
				{
					return;
				}


				Set_Company_Versus_Contact_Search();
				Set_Sort_Order(ref sOrderBy, true);

				// Clear Contact Fields
				txt_contact_last_name.Text = "";
				txt_contact_first_name.Text = "";

				int tempForEndVar = lst_title_group.Items.Count - 1;
				for (int lCnt1 = 0; lCnt1 <= tempForEndVar; lCnt1++)
				{
					ListBoxHelper.SetSelected(lst_title_group, lCnt1, false);
				}
				ListBoxHelper.SetSelected(lst_title_group, 0, true);

				cbo_contact_title.SelectedIndex = -1;
				cbo_contact_title.Text = "";

				txt_pnum_number_full.Text = "";
				txt_contact_email_address.Text = "";

			}
		}

		private void opt_contacts_CheckedChanged(Object eventSender, EventArgs eventArgs)
		{
			if (((RadioButton) eventSender).Checked)
			{
				if (isInitializingComponent)
				{
					return;
				}

				Set_Company_Versus_Contact_Search();
				Set_Sort_Order(ref sOrderBy, true);

				if (opt_contacts.Checked)
				{
					chk_aircraft_count.CheckState = CheckState.Unchecked;
					chk_hide_zero.CheckState = CheckState.Unchecked;
					chk_show_yacht_count.CheckState = CheckState.Unchecked;
					chk_share_relationships_withoutAC.CheckState = CheckState.Unchecked;
					chk_share_relationships.CheckState = CheckState.Unchecked;
				}

			}
		}

		private void lst_title_group_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{

			if (!bIsFormLoad)
			{
				modFillCompConControls.Fill_Contact_Title(cbo_contact_title, lst_title_group);
			}

		}

		public void mnuFileLogout_Click(Object eventSender, EventArgs eventArgs) => frm_Main_Menu.DefInstance.Close();


		private void opt_continent_region_CheckedChanged(Object eventSender, EventArgs eventArgs)
		{
			if (((RadioButton) eventSender).Checked)
			{
				if (isInitializingComponent)
				{
					return;
				}
				if (!bIsFormLoad)
				{
					modFillCompConControls.Fill_Demographics(opt_continent_region, lst_area);
				}
			}
		}

		private void txt_ac_value_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{

				//aey 5/26/04
				string char_Renamed = Strings.Chr(KeyAscii).ToString();

				if (char_Renamed.Trim() == "" || KeyAscii <= 13)
				{
					if (KeyAscii == 0)
					{
						eventArgs.Handled = true;
					}
					return;
				}

				if (char_Renamed == ".")
				{
					if (KeyAscii == 0)
					{
						eventArgs.Handled = true;
					}
					return;
				}

				if (String.CompareOrdinal(char_Renamed, "0") < 0 || String.CompareOrdinal(char_Renamed, "9") > 0)
				{
					KeyAscii = 0;
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

		public void mnureport_Click(Object eventSender, EventArgs eventArgs)
		{


			Set_Sort_Order(ref sOrderBy, true);
			string NewQuery = BuildCompanyWhere(sOrderBy);

			if ((NewQuery.IndexOf("ORDER BY") + 1) > 1)
			{
				NewQuery = StringsHelper.Replace(NewQuery, "  ", " ", 1, -1, CompareMethod.Binary);
				NewQuery = StringsHelper.Replace(NewQuery, "%", "*", 1, -1, CompareMethod.Binary);
				NewQuery = NewQuery.Substring(Math.Min(0, NewQuery.Length), Math.Min(NewQuery.IndexOf("ORDER BY"), Math.Max(0, NewQuery.Length)));

				//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//VB.Global.Load(frm_WebReport.DefInstance);
				frm_WebReport.DefInstance.WhichReport = "Company List";
				frm_WebReport.DefInstance.PassedWhereClause = NewQuery;
				frm_WebReport.DefInstance.Show();

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
						Hide_MySelf(); 
						 
						break;
					case "Back" : 
						 
						mnuFileClose_Click(mnuFileClose, new EventArgs()); 
						 
						break;
					case "Save" : 
						MessageBox.Show("There is nothing to Save", "Find Company", MessageBoxButtons.OK, MessageBoxIcon.Information); 
						 
						break;
					case "Help" : 
						MessageBox.Show("Help is forthcoming", "Find Company", MessageBoxButtons.OK, MessageBoxIcon.Information); 
						 
						break;
				}
			}
			catch
			{

				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
			}

		}

		private void Set_Find_Company_Grid_Headers()
		{

			int lCol1 = 0;

			//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			// Header Columns/Names
			// 0       1     2     3       4       5     6     7   8       9   10    11    12      13      14      15        16      17      18          19               20
			// Company City  State Country Contact Title Email Rep Product #AC #WOwn #WOp  *ShOwn  #FROwn  CompId  ContactId JournId #Yachts CompService ActiveSubService Marketing Rep

			grd_find_company.Clear();
			grd_find_company.Visible = true;
			pnl_search_results.Visible = true;

			grd_find_company.RowsCount = 2;
			grd_find_company.CurrentRowIndex = 0;
			int lRow1 = 0;
			grd_find_company.FixedRows = 0;

			if (chk_aircraft_count.CheckState == CheckState.Checked)
			{
				grd_find_company.RowsCount = 3;
				grd_find_company.CurrentRowIndex = 1;
				lRow1 = 1;
			}

			grd_find_company.ColumnsCount = 21;

			grd_find_company.CurrentColumnIndex = 0;
			grd_find_company.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_find_company.SetColumnWidth(0, 367);
			grd_find_company[lRow1, 0].Value = "Company";

			grd_find_company.CurrentColumnIndex = 1;
			grd_find_company.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_find_company.SetColumnWidth(1, 133);
			grd_find_company[lRow1, 1].Value = "City";

			grd_find_company.CurrentColumnIndex = 2;
			grd_find_company.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_find_company.SetColumnWidth(2, 47);
			grd_find_company[lRow1, 2].Value = "State";

			grd_find_company.CurrentColumnIndex = 3;
			grd_find_company.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_find_company.SetColumnWidth(3, 87);
			grd_find_company[lRow1, 3].Value = "Country";

			//--------------------------------------
			// Contact Information

			grd_find_company.CurrentColumnIndex = 4;
			grd_find_company.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_find_company.SetColumnWidth(4, 0);
			if (opt_contacts.Checked)
			{
				grd_find_company.SetColumnWidth(4, 133);
			}
			grd_find_company[lRow1, 4].Value = "Name";

			grd_find_company.CurrentColumnIndex = 5;
			grd_find_company.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_find_company.SetColumnWidth(5, 0);
			if (opt_contacts.Checked)
			{
				grd_find_company.SetColumnWidth(5, 133);
			}
			grd_find_company[lRow1, 5].Value = "Title";

			grd_find_company.CurrentColumnIndex = 6;
			grd_find_company.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_find_company.SetColumnWidth(6, 0);
			if (opt_contacts.Checked)
			{
				grd_find_company.SetColumnWidth(6, 133);
			}
			grd_find_company[lRow1, 6].Value = "EMail";

			//--------------------------------------
			// Company Account Rep

			grd_find_company.CurrentColumnIndex = 7;
			grd_find_company.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_find_company.SetColumnWidth(7, 40);
			grd_find_company[lRow1, 7].Value = "Rep";

			//--------------------------------------
			// Show Counts

			grd_find_company.CurrentColumnIndex = 8;
			grd_find_company.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_find_company.SetColumnWidth(8, 0);
			if (chk_aircraft_count.CheckState == CheckState.Checked)
			{
				grd_find_company.SetColumnWidth(8, 33);
			}
			grd_find_company[lRow1, 8].Value = "Product";

			grd_find_company.CurrentColumnIndex = 9;
			grd_find_company.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_find_company.SetColumnWidth(9, 0);
			if (chk_aircraft_count.CheckState == CheckState.Checked)
			{
				grd_find_company.SetColumnWidth(9, 50);
			}
			grd_find_company[lRow1, 9].Value = "#Aircraft";

			grd_find_company.CurrentColumnIndex = 10;
			grd_find_company.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_find_company.SetColumnWidth(10, 0);
			if (chk_aircraft_count.CheckState == CheckState.Checked)
			{
				grd_find_company.SetColumnWidth(10, 53);
			}
			grd_find_company[lRow1, 10].Value = "#Wh Own";

			grd_find_company.CurrentColumnIndex = 11;
			grd_find_company.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_find_company.SetColumnWidth(11, 0);
			if (chk_aircraft_count.CheckState == CheckState.Checked)
			{
				grd_find_company.SetColumnWidth(11, 53);
			}
			grd_find_company[lRow1, 11].Value = "#Wh Op";

			grd_find_company.CurrentColumnIndex = 12;
			grd_find_company.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_find_company.SetColumnWidth(12, 0);
			if (chk_aircraft_count.CheckState == CheckState.Checked)
			{
				grd_find_company.SetColumnWidth(12, 50);
			}
			grd_find_company[lRow1, 12].Value = "*Sh Own";

			grd_find_company.CurrentColumnIndex = 13;
			grd_find_company.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_find_company.SetColumnWidth(13, 0);
			if (chk_aircraft_count.CheckState == CheckState.Checked)
			{
				grd_find_company.SetColumnWidth(13, 50);
			}
			grd_find_company[lRow1, 13].Value = "*Fr Own";

			//--------------------------------------
			// CompId and Contact Id

			grd_find_company.CurrentColumnIndex = 14;
			grd_find_company.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_find_company.SetColumnWidth(14, 67);
			grd_find_company[lRow1, 14].Value = "Comp ID";

			grd_find_company.CurrentColumnIndex = 15;
			grd_find_company.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_find_company.SetColumnWidth(15, 0);
			if (opt_contacts.Checked)
			{
				grd_find_company.SetColumnWidth(15, 67);
			}
			grd_find_company[lRow1, 15].Value = "Contact ID";

			//--------------------------------------
			// History/Journal Id

			grd_find_company.CurrentColumnIndex = 16;
			grd_find_company.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_find_company.SetColumnWidth(16, 0);
			if (chk_history.CheckState == CheckState.Checked)
			{
				grd_find_company.SetColumnWidth(16, 67);
			}
			grd_find_company[lRow1, 16].Value = "Journal ID";

			//--------------------------------------
			// Yacht Count

			grd_find_company.CurrentColumnIndex = 17;
			grd_find_company.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_find_company.SetColumnWidth(17, 0);
			if (chk_show_yacht_count.CheckState == CheckState.Checked)
			{
				grd_find_company.SetColumnWidth(17, 50);
			}
			grd_find_company[lRow1, 17].Value = "#Yachts";

			//---------------------------------------
			// Service Fields

			grd_find_company.CurrentColumnIndex = 18;
			grd_find_company.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_find_company.SetColumnWidth(18, 0);
			if (cbo_MailList.Text.Trim() != "" || optSearchCust[1].Checked || optSearchCust[2].Checked || chkIncludeServices.CheckState == CheckState.Checked)
			{
				grd_find_company.SetColumnWidth(18, 113);
			}
			grd_find_company[lRow1, 18].Value = "Service";

			grd_find_company.CurrentColumnIndex = 19;
			grd_find_company.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_find_company.SetColumnWidth(19, 0);
			if (cbo_MailList.Text.Trim() != "" || optSearchCust[1].Checked || chkIncludeServices.CheckState == CheckState.Checked)
			{
				grd_find_company.SetColumnWidth(19, 80);
			}
			grd_find_company[lRow1, 19].Value = "Sub-Service";

			grd_find_company.CurrentColumnIndex = 20;
			grd_find_company.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
			grd_find_company[lRow1, 20].Value = "Mkt Rep";
			grd_find_company.SetColumnWidth(20, 0);

			if (chk_search.CheckState == CheckState.Checked)
			{
				grd_find_company.SetColumnWidth(20, 100);
			}

			grd_find_company.FixedRows = 1;
			if (chk_aircraft_count.CheckState == CheckState.Checked)
			{
				grd_find_company.FixedRows = 2;
			}

		} // Set_Find_Company_Grid_Headers

		private void fill_find_company_Grd(ref string strOrderBy)
		{

			string Query = "";
			string strStatus = "";
			try
			{


				string strMsg = "";
				System.DateTime dtStartDate = DateTime.FromOADate(0);
				System.DateTime dtEndDate = DateTime.FromOADate(0);

				string Query1 = "";
				string Query2 = "";
				string Tname = "";
				Tname = "";
				int TotInGrid = 0;
				TotInGrid = 0; // number of companies
				string tmp_message = "";
				string tmp_CompanyType = "";
				string tmp_CompanyRoll = "";
				string tmp_CompanyTypeRoll = "";
				string M = "";

				int TotWhOwners = 0;
				TotWhOwners = 0; //tot aircraft owners    'aey 5/21/04
				int TotWhOperators = 0;
				TotWhOperators = 0; //tot aircraft operators
				double TotSharesOwn = 0;
				TotSharesOwn = 0; //tot shares owned
				double TotFracOwn = 0;
				TotFracOwn = 0; //tot fractions owned
				int TotAC = 0;
				TotAC = 0; //total #AC
				int lCompId = 0;
				int lJournId = 0;
				int lContactId = 0;
				int lOldCompId = 0;
				lOldCompId = 0;
				ADORecordSetHelper ado_Counts = new ADORecordSetHelper();
				int TotRef = 0;
				TotRef = 0;
				int TotNoContact = 0;
				TotNoContact = 0;
				int YachtCnt = 0;
				ADORecordSetHelper snp_CompList = new ADORecordSetHelper();
				bool bHasContact = false;
				int lCol1 = 0;
				int lRow1 = 0;
				int lcol_orig = 0;

				int lTot1 = 0;
				int lCnt1 = 0;
				int lCnt2 = 0;
				string strMktRep = "";

				strMktRep = "";

				if (grd_find_company.Enabled)
				{

					grd_find_company.Enabled = false;

					mdi_ResearchAssistant.DefInstance.prg_Progress_Bar.Visible = false;

					if (SomeCriteria(sContinentlist, sRegionlist, sCountrylist, sStatelist))
					{

						modCommon.Start_Activity_Monitor_Message("Company Search", ref strMsg, ref dtStartDate, ref dtEndDate);

						bIsStopped = false;
						strStatus = "Status #1";

						chk_aircraft_count.Enabled = false;
						chk_hide_zero.Enabled = false;

						pnl_search.Enabled = false;
						pnl_contact.Enabled = false;
						pnl_company.Enabled = false;
						tbr_ToolBar.Enabled = false;

						if (pnl_search_results.Visible)
						{
							pnl_search_results.Visible = false;
						}

						if (pnl_company_info.Visible)
						{
							pnl_company_info.Visible = false;
						}

						if (pnl_contact_info.Visible)
						{
							pnl_contact_info.Visible = false;
						}

						if (pnl_duplicates.Visible)
						{
							pnl_duplicates.Visible = false;
						}

						if (modCommon.pubf_EncodeEntryPoints(tFormEntryPoint) != modGlobalVars.gFIND_ACOR && pnl_company_relationships.Visible)
						{
							pnl_company_relationships.Visible = false;
						}

						cbo_contact_type.Visible = false;

						cmd_Associate.Visible = false;
						cmd_Stop.Visible = false;
						cmd_Add_Company.Visible = false;
						cmd_Add_Contact.Visible = false;

						cmd_Find.Enabled = false;
						cmd_Refresh.Enabled = false;
						cmd_Clear.Enabled = false;

						pnl_display_results.Visible = true;

						Wait_Pnl_On("Search In Progress....");

						strStatus = "Status #2";

						//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
						// Header Columns/Names
						// 0       1     2     3       4       5     6     7   8       9   10    11    12      13      14      15        16      17      18          19               20
						// Company City  State Country Contact Title Email Rep Product #AC #WOwn #WOp  *ShOwn  #FROwn  CompId  ContactId JournId #Yachts CompService ActiveSubService Marketing Rep

						Set_Find_Company_Grid_Headers();

						strStatus = "Status #3";

						if (opt_contacts.Checked)
						{
							tmp_message = "Master List of Companies and Contacts";
						}
						else
						{
							tmp_message = "Master List of Companies";
						}

						lbl_total_found.Text = $"Searching for {tmp_message}";

						if (chk_history.CheckState == CheckState.Checked)
						{
							tmp_message = $"{tmp_message} including Archived Data";
						}

						lbl_Label1[24].Text = tmp_message;

						// Build the SELECT portion of the Query
						Query = BuildCompanyQuery(ref strOrderBy);
						Query = StringsHelper.Replace(Query, "*", "%", 1, -1, CompareMethod.Binary);

						strStatus = "Status #4";


						if (this.cbo_MailList.SelectedIndex > 0)
						{ // added MSW - 4/2/21
							//dont do the replace
							Query = StringsHelper.Replace(Query, "WHERE  ORDER BY", "WHERE (comp_journ_id = 0) and (contact_journ_id = 0)  ORDER BY", 1, -1, CompareMethod.Binary);

						}
						else if (Query.IndexOf("WHERE   (comp_active_flag = 'Y') AND (comp_journ_id = 0)  ORDER BY") >= 0)
						{ 
							Query = StringsHelper.Replace(Query, "SELECT DISTINCT comp_id", "SELECT DISTINCT top 1  comp_id", 1, -1, CompareMethod.Binary);
							// Query = "select top 1 * FROM Company WITH(NOLOCK) LEFT OUTER JOIN Company_Business_Type WITH(NOLOCK) ON (comp_business_type=cbus_type) WHERE comp_name IS NOT NULL AND comp_active_flag = 'Y'  AND (comp_journ_id = 0) "
						}
						else if (Query.IndexOf("WHERE comp_name IS NOT NULL AND comp_active_flag = 'Y'  AND (comp_journ_id = 0)  ORDER BY") >= 0)
						{ 
							Query = StringsHelper.Replace(Query, "SELECT DISTINCT comp_id", "SELECT DISTINCT top 1  comp_id", 1, -1, CompareMethod.Binary);
							//Query = "select top 1 * FROM Company WITH(NOLOCK) LEFT OUTER JOIN Company_Business_Type WITH(NOLOCK) ON (comp_business_type=cbus_type) WHERE comp_name IS NOT NULL AND comp_active_flag = 'Y'  AND (comp_journ_id = 0) "
						}
						else
						{

						}



						snp_CompList.CursorLocation = CursorLocationEnum.adUseClient;
						snp_CompList.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

						strStatus = "Status #5";

						if (!snp_CompList.BOF && !snp_CompList.EOF)
						{

							lTot1 = snp_CompList.RecordCount;

							mdi_ResearchAssistant.DefInstance.prg_Progress_Bar.Maximum = lTot1;
							mdi_ResearchAssistant.DefInstance.prg_Progress_Bar.Value = 0;
							mdi_ResearchAssistant.DefInstance.prg_Progress_Bar.Visible = true;

							if (lTot1 > 10000)
							{
								snp_CompList.Close();
								snp_CompList = null;
								TooManyResults(lTot1); //gap-note Manual change to support GOTO
							}

							cmd_Stop.Visible = true;
							pnl_search_results.Visible = true;

							Wait_Pnl_On("Counting / Loading Selected Companies....");
							Application.DoEvents();

							strStatus = "Status #6";

							lRow1 = 0;
							if (chk_aircraft_count.CheckState == CheckState.Checked)
							{
								lRow1 = 1;
							}
							lCnt1 = 0;

							grd_find_company.Redraw = false;

							do 
							{ // Loop Until snp_CompList.EOF = True Or bIsStopped = True

								lCompId = 0;
								lJournId = 0;

								strStatus = "Status #6a";

								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(snp_CompList["comp_id"]))
								{
									lCompId = Convert.ToInt32(snp_CompList["comp_id"]);
								}
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(snp_CompList["comp_journ_id"]))
								{
									lJournId = Convert.ToInt32(snp_CompList["comp_journ_id"]);
								}

								lContactId = 0;
								bHasContact = false;
								if (opt_contacts.Checked)
								{
									bHasContact = true;
									//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
									if (!Convert.IsDBNull(snp_CompList["contact_id"]))
									{
										lContactId = Convert.ToInt32(snp_CompList["contact_id"]);
									}
								}

								YachtCnt = 0;
								if (chk_show_yacht_count.CheckState == CheckState.Checked)
								{
									//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
									if (!Convert.IsDBNull(snp_CompList["ycount"]))
									{
										YachtCnt = Convert.ToInt32(snp_CompList["ycount"]);
									}
								}

								lCnt1++;
								lbl_total_found.Text = $"Loading Company {StringsHelper.Format(lCnt1, "##,##0")} of {StringsHelper.Format(lTot1, "##,##0")} Companies Found ";

								lRow1++;
								grd_find_company.RowsCount = lRow1 + 1;
								grd_find_company.CurrentRowIndex = lRow1;

								grd_find_company.set_RowData(grd_find_company.CurrentRowIndex, lCompId);
								//UPGRADE_ISSUE: (2064) MSHierarchicalFlexGridLib.MSHFlexGrid property grd_find_company.BandData was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
								grd_find_company.setBandData(lContactId, grd_find_company.CurrentRowIndex);



								lCol1 = -1;

								//-------------------------------
								// Company Name

								strStatus = "Status #6b";

								grd_find_company.CurrentColumnIndex = 0;
								grd_find_company.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

								tmp_CompanyType = ($"{Convert.ToString(snp_CompList["cbus_name"])} ").Trim();
								tmp_CompanyRoll = modCompanyFind.GetCompanyRoles(lCompId, lJournId);
								if (tmp_CompanyRoll != "")
								{
									tmp_CompanyTypeRoll = $"{tmp_CompanyType}/{tmp_CompanyRoll}";
								}
								else
								{
									tmp_CompanyTypeRoll = tmp_CompanyType;
								}
								grd_find_company[lRow1, 0].Value = $"{Convert.ToString(snp_CompList["comp_name"]).Trim()} [{tmp_CompanyTypeRoll}]"; // [" & CStr(Comp_id) & "]"

								if (lJournId > 0)
								{
									grd_find_company[lRow1, 0].Value = $"{($"{Convert.ToString(snp_CompList["comp_name"])} ").Trim()} - Historical as of {modCommon.Get_Journal_Date(lJournId)}";
									grd_find_company.CellBackColor = Color.FromArgb(224, 224, 224);
								}

								if (lCompId != lOldCompId)
								{

									strStatus = "Status #6c";

									grd_find_company.CurrentColumnIndex = 1;
									grd_find_company.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
									grd_find_company[lRow1, 1].Value = ($"{Convert.ToString(snp_CompList["Comp_city"])} ").Trim();

									grd_find_company.CurrentColumnIndex = 2;
									grd_find_company.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
									grd_find_company[lRow1, 2].Value = ($"{Convert.ToString(snp_CompList["comp_state"])} ").Trim();

									grd_find_company.CurrentColumnIndex = 3;
									grd_find_company.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
									grd_find_company[lRow1, 3].Value = ($"{Convert.ToString(snp_CompList["Comp_country"])} ").Trim();

								}
								else
								{
									lCol1 += 3;
								} // If lCompId <> lOldCompId Then

								//-----------------------------------------------
								// Add Contact If Checked

								if (opt_contacts.Checked)
								{

									if (lContactId > 0)
									{

										strStatus = "Status #6d";

										Tname = modCommon.ReturnContactName("", ($"{Convert.ToString(snp_CompList["contact_first_name"])} ").Trim(), ($"{Convert.ToString(snp_CompList["contact_middle_initial"])} ").Trim(), ($"{Convert.ToString(snp_CompList["contact_last_name"])} ").Trim(), ($"{Convert.ToString(snp_CompList["contact_suffix"])} ").Trim());

										grd_find_company.CurrentColumnIndex = 4;
										grd_find_company.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
										grd_find_company[lRow1, 4].Value = Tname;

										grd_find_company.CurrentColumnIndex = 5;
										grd_find_company.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
										grd_find_company[lRow1, 5].Value = ($"{Convert.ToString(snp_CompList["contact_title"])} ").Trim();

										grd_find_company.CurrentColumnIndex = 6;
										grd_find_company.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
										grd_find_company[lRow1, 6].Value = ($"{Convert.ToString(snp_CompList["contact_email_address"])} ").Trim();
										//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
										if (!Convert.IsDBNull(snp_CompList["DNSEMail_Id"]))
										{
											if (Convert.ToDouble(snp_CompList["DNSEMail_Id"]) > 0)
											{
												grd_find_company[lRow1, 6].Value = "Do Not Send List";
											}
										}

									}
									else
									{
										TotNoContact++;
									} // If lContactId > 0 Then

								} // If opt_contacts.Value = True Then

								//-----------------------------------------------
								// Company Account Rep

								strStatus = "Status #6e";

								grd_find_company.CurrentColumnIndex = 7;
								grd_find_company.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
								grd_find_company[lRow1, 7].Value = ($"{Convert.ToString(snp_CompList["comp_account_id"])} ").Trim();

								//-----------------------------------------------
								// Aircraft Counts

								if (chk_aircraft_count.CheckState == CheckState.Checked)
								{

									strStatus = "Status #7";

									Query1 = "SELECT * FROM company_aircraft_count WITH (NOLOCK) ";
									Query1 = $"{Query1}WHERE (cac_comp_id = {lCompId.ToString()}) ";
									Query1 = $"{Query1}ORDER BY cac_product_type ";

									ado_Counts.Open(Query1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

									if (!ado_Counts.BOF && !ado_Counts.EOF)
									{

										lCnt2 = 0;

										do 
										{ // Loop Until ado_Counts.EOF = True

											lCnt2++;

											TotRef = Convert.ToInt32(ado_Counts["cac_total_referenced"]);

											if (TotRef > 0 || chk_hide_zero.CheckState == CheckState.Unchecked)
											{

												strStatus = "Status #7a";

												grd_find_company.CurrentColumnIndex = 8;
												grd_find_company.CellAlignment = DataGridViewContentAlignment.TopCenter;

												switch(Convert.ToString(ado_Counts["cac_product_type"]).Trim().ToUpper())
												{
													case "H" : 
														grd_find_company.CellPicture = pic_redx[2].Image; 
														break;
													case "B" : 
														grd_find_company.CellPicture = pic_redx[1].Image; 
														break;
													case "C" : 
														grd_find_company.CellPicture = pic_redx[3].Image; 
														break;
												}

												strStatus = "Status #7b";

												grd_find_company.CurrentColumnIndex = 9;
												grd_find_company.CellAlignment = DataGridViewContentAlignment.MiddleRight;
												grd_find_company[lRow1, 9].Value = Convert.ToString(ado_Counts["cac_total_referenced"]);

												strStatus = "Status #7c";

												grd_find_company.CurrentColumnIndex = 10;
												grd_find_company.CellAlignment = DataGridViewContentAlignment.MiddleRight;
												grd_find_company[lRow1, 10].Value = Convert.ToString(ado_Counts["cac_fullsale_owner"]);

												strStatus = "Status #7d";

												grd_find_company.CurrentColumnIndex = 11;
												grd_find_company.CellAlignment = DataGridViewContentAlignment.MiddleRight;
												grd_find_company[lRow1, 11].Value = Convert.ToString(ado_Counts["cac_fullsale_operator"]);

												strStatus = "Status #7e";

												grd_find_company.CurrentColumnIndex = 12;
												grd_find_company.CellAlignment = DataGridViewContentAlignment.MiddleRight;
												grd_find_company[lRow1, 12].Value = Strings.FormatNumber(ado_Counts.GetField("cac_sharesale_owner"), 2, TriState.False, TriState.False, TriState.False);

												strStatus = "Status #7f";

												grd_find_company.CurrentColumnIndex = 13;
												grd_find_company.CellAlignment = DataGridViewContentAlignment.MiddleRight;
												grd_find_company[lRow1, 13].Value = Strings.FormatNumber(ado_Counts.GetField("cac_fractionsale_owner"), 2, TriState.False, TriState.False, TriState.False);

												//calculate totals for grid display
												strStatus = "Status #7g";

												TotAC = Convert.ToInt32(TotAC + Convert.ToDouble(ado_Counts["cac_total_referenced"]));
												TotWhOwners = Convert.ToInt32(TotWhOwners + Convert.ToDouble(ado_Counts["cac_fullsale_owner"])); //tot aircraft owners
												TotWhOperators = Convert.ToInt32(TotWhOperators + Convert.ToDouble(ado_Counts["cac_fullsale_operator"])); //tot aircraft operators
												TotSharesOwn += Convert.ToDouble(ado_Counts["cac_sharesale_owner"]); //tot shares owned
												TotFracOwn += Convert.ToDouble(ado_Counts["cac_fractionsale_owner"]); //tot fractions owned

											} // If TotRef > 0 Or chk_hide_zero.Value = vbUnchecked Then

											strStatus = "Status #7h";
											if (lCnt2 == 1)
											{
												grd_find_company.CurrentColumnIndex = 14;
												grd_find_company.CellAlignment = DataGridViewContentAlignment.MiddleRight;
												grd_find_company[lRow1, 14].Value = lCompId.ToString();
												grd_find_company.CurrentColumnIndex = 15;
												grd_find_company.CellAlignment = DataGridViewContentAlignment.MiddleRight;
												grd_find_company[lRow1, 15].Value = lContactId.ToString();
												grd_find_company.CurrentColumnIndex = 16;
												grd_find_company.CellAlignment = DataGridViewContentAlignment.MiddleRight;
												grd_find_company[lRow1, 16].Value = lJournId.ToString();
											}

											ado_Counts.MoveNext();

											if (!ado_Counts.EOF)
											{
												lRow1++;
												grd_find_company.RowsCount = lRow1 + 1;
												grd_find_company.CurrentRowIndex = lRow1;
											}

										}
										while(!ado_Counts.EOF);

										strStatus = "Status #7i";

									} // If (ado_Counts.BOF = False And ado_Counts.EOF = False) Then

									ado_Counts.Close();

								} // If chk_aircraft_count.Value = vbChecked Then

								//-----------------------------------------------
								// Company Id and Contact Id

								strStatus = "Status #6f";

								if (chk_aircraft_count.CheckState == CheckState.Unchecked)
								{

									grd_find_company.CurrentColumnIndex = 14;
									grd_find_company.CellAlignment = DataGridViewContentAlignment.MiddleRight;
									grd_find_company[lRow1, 14].Value = lCompId.ToString();

								} // If chk_aircraft_count.Value = vbChecked Then

								grd_find_company.CurrentColumnIndex = 15;
								grd_find_company.CellAlignment = DataGridViewContentAlignment.MiddleRight;
								grd_find_company[lRow1, 15].Value = lContactId.ToString();

								//-----------------------------------------------
								// Journal / History

								grd_find_company.CurrentColumnIndex = 16;
								grd_find_company.CellAlignment = DataGridViewContentAlignment.MiddleRight;
								grd_find_company[lRow1, 16].Value = lJournId.ToString();

								//-----------------------------------------------
								// Yacht Count

								grd_find_company.CurrentColumnIndex = 17;
								grd_find_company.CellAlignment = DataGridViewContentAlignment.MiddleRight;
								grd_find_company[lRow1, 17].Value = YachtCnt.ToString();

								//-----------------------------------------------
								// Mailing List - Services

								grd_find_company.CurrentColumnIndex = 18;
								grd_find_company.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
								grd_find_company[lRow1, 18].Value = ($"{Convert.ToString(snp_CompList["CompService"])} ").Trim();

								grd_find_company.CurrentColumnIndex = 19;
								grd_find_company.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
								grd_find_company[lRow1, 19].Value = ($"{Convert.ToString(snp_CompList["ActiveSubService"])} ").Trim();

								//-----------------------------------------------

								if (chk_search.CheckState == CheckState.Checked)
								{
									grd_find_company.CurrentColumnIndex = 20;
									grd_find_company.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
									strMktRep = modCommon.Return_Company_Marketing_Rep_Name(Convert.ToInt32(snp_CompList["comp_id"]), Convert.ToInt32(snp_CompList["comp_journ_id"]), ($"{Convert.ToString(snp_CompList["COMP_MARKETING_REP"])} ").Trim());
									grd_find_company[lRow1, 20].Value = ($"{strMktRep} ").Trim();
								}

								lOldCompId = lCompId;
								strStatus = "Status #6g";

								if (lCnt1 == 12)
								{
									grd_find_company.Redraw = true;
									grd_find_company.Refresh();
									grd_find_company.Redraw = false;
								}

								snp_CompList.MoveNext();
								Application.DoEvents();

								if (lCnt1 <= mdi_ResearchAssistant.DefInstance.prg_Progress_Bar.Maximum)
								{
									mdi_ResearchAssistant.DefInstance.prg_Progress_Bar.Value = lCnt1;
								}

								strStatus = "Status #6h";

							}
							while(!(snp_CompList.EOF || bIsStopped));

							grd_find_company.Redraw = true;
							grd_find_company.Refresh();

							strStatus = "Status #8";

							cmdCompanyListExcelExport.Visible = true;

						} // If (snp_CompList.BOF = False And snp_CompList.EOF = False) Then

						snp_CompList.Close();
						snp_CompList = null;

						strStatus = "Status #9";

						if (opt_contacts.Checked)
						{
							// IF CONTACTS ARE SELECTED THEN DISPLAY # CONTACTS FOUND
							lbl_total_found.Text = $"{Strings.FormatNumber(lCnt1, 0, TriState.False, TriState.False, TriState.True)} Companies with Contacts({TotNoContact.ToString()} have no contacts)";
						}
						else
						{
							// IF CONTACTS ARE not SELECTED THEN DISPLAY # COMPANIES FOUND
							lbl_total_found.Text = $"{Strings.FormatNumber(lCnt1, 0, TriState.False, TriState.False, TriState.True)} Companies Found";
						} // If opt_contacts.Value Then

						if (chk_aircraft_count.CheckState == CheckState.Checked)
						{

							grd_find_company.FixedRows = 0;

							strStatus = "Status #10";

							grd_find_company[0, 0].Value = $"Totals:       Companies Found = {Strings.FormatNumber(lTot1, 0, TriState.False, TriState.False, TriState.True)}";

							grd_find_company.CurrentColumnIndex = 9;
							grd_find_company.CellAlignment = DataGridViewContentAlignment.MiddleRight;
							grd_find_company[0, 9].Value = Strings.FormatNumber(TotAC, 0, TriState.False, TriState.False, TriState.True);

							grd_find_company.CurrentColumnIndex = 10;
							grd_find_company.CellAlignment = DataGridViewContentAlignment.MiddleRight;
							grd_find_company[0, 10].Value = Strings.FormatNumber(TotWhOwners, 0, TriState.False, TriState.False, TriState.True);

							grd_find_company.CurrentColumnIndex = 11;
							grd_find_company.CellAlignment = DataGridViewContentAlignment.MiddleRight;
							grd_find_company[0, 11].Value = Strings.FormatNumber(TotWhOperators, 0, TriState.False, TriState.False, TriState.True);

							grd_find_company.CurrentColumnIndex = 12;
							grd_find_company.CellAlignment = DataGridViewContentAlignment.MiddleRight;
							grd_find_company[0, 12].Value = Strings.FormatNumber(TotSharesOwn, 2, TriState.False, TriState.False, TriState.True);

							grd_find_company.CurrentColumnIndex = 13;
							grd_find_company.CellAlignment = DataGridViewContentAlignment.MiddleRight;
							grd_find_company[0, 13].Value = Strings.FormatNumber(TotFracOwn, 2, TriState.False, TriState.False, TriState.True);

							grd_find_company.FixedRows = 2;

						} // If chk_aircraft_count.Value = vbChecked Then

						modCommon.End_Activity_Monitor_Message("Company Search", ref strMsg, dtStartDate, ref dtEndDate, 0, 0, 0, 0, 0);

						frm_UserHistory.DefInstance.Refresh_User_History_Grids("Callback");

						strStatus = "Status #11";

						// IF NO RECORDS WERE FOUND DISPLAY APPROPRIATE MESSAGE
						if (lCnt1 == 0)
						{

							M = $"No Records Found with the Current Search Criteria.{"\r"}{"\r"}Please reduce the criteria AND try again.";
							MessageBox.Show(M, "SEARCH RESULTS EMPTY", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							pnl_display_results.Visible = false;
							pnl_search_results.Visible = false;

						} // If TotInGrid = 0 Then

						cmd_Find.Enabled = true;
						cmd_Clear.Enabled = true;
						cmd_Refresh.Enabled = true;

						Wait_Pnl_Off();

						strStatus = "Status #12";

					}
					else
					{
						TooManyResults(lTot1); //gap-note Manual change to call GOTO statements
					}

					cmd_Stop.Visible = false;



					if (modCommon.pubf_EncodeEntryPoints(tFormEntryPoint) != modGlobalVars.gFIND_CBAK)
					{

						cmd_Add_Company.Visible = true;

						if (chk_aircraft_count.CheckState == CheckState.Checked && grd_find_company.RowsCount > 2)
						{
							grd_find_company.FixedRows = 2;
						}
						else if (grd_find_company.RowsCount > 1)
						{ 
							grd_find_company.FixedRows = 1;
						}

					}
					else
					{

						if (grd_find_company.RowsCount > 1)
						{
							grd_find_company.FixedRows = 1;
						}

					} // If modCommon.pubf_EncodeEntryPoints(tFormEntryPoint) <> gFIND_CBAK Then

					grd_find_company.Enabled = true;
					grd_find_company.Visible = true;
					grd_find_company.Redraw = true;

					chk_aircraft_count.Enabled = true;
					chk_hide_zero.Enabled = true;

					pnl_search.Enabled = true;
					pnl_contact.Enabled = true;
					pnl_company.Enabled = true;
					tbr_ToolBar.Enabled = true;

					mdi_ResearchAssistant.DefInstance.prg_Progress_Bar.Visible = false;

					grd_find_company.Enabled = true;

				} // If grd_find_company.Enabled = True Then
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"fill_find_company_Grd_Error ({Information.Err().Number.ToString()}) {excep.Message}");
				modAdminCommon.Report_Error($"  !-Find Company Status/Query: {strStatus} - {Query}");

				pnl_display_results.Visible = false;
				pnl_search_results.Visible = false;

				pnl_contact.Enabled = true;
				pnl_company.Enabled = true;
				tbr_ToolBar.Enabled = true;

				Wait_Pnl_Off();

				//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseServer);
			}

		} // fill_find_company_Grd
		  //UPGRADE_NOTE: (7001) The following declaration (select_automated_account_rep) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		  //private void select_automated_account_rep(string comp_name, string db_rep, ref string sAssignRep)
		  //{
		  //// Function used to Select Automated Account Rep from Account_Rep_Assignment table
		  //
		  //string Query = "";
		  //int i = 0;
		  //ADORecordSetHelper ado_AccountRep = null;
		  //
		  //try
		  //{
		  //
		  //Query = "SELECT user_first_name, user_last_name  FROM Account_Rep_Assignment WITH(NOLOCK) ";
		  //Query = $"{Query} inner join  Account_Rep with (NOLOCK) on accrep_account_id = assign_db_account_id ";
		  //Query = $"{Query} inner join [User] with (NOLOCK) on user_id = accrep_user_id ";
		  //Query = $"{Query} WHERE assign_character = '{comp_name.Trim().Substring(0, Math.Min(1, comp_name.Trim().Length)).ToUpper()}'";
		  //
		  //ado_AccountRep = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");
		  ////UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
		  //if (!Convert.IsDBNull(ado_AccountRep.Fields) && !(ado_AccountRep.BOF && ado_AccountRep.EOF))
		  //{
		  //
		  ////UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
		  //if (!Convert.IsDBNull(ado_AccountRep["user_first_name"]))
		  //{
		  //if (Convert.ToString(ado_AccountRep["user_first_name"]).Trim() != modGlobalVars.cEmptyString)
		  //{
		  //sAssignRep = $"{Convert.ToString(ado_AccountRep["user_first_name"]).Trim()} ";
		  //}
		  //}
		  //
		  ////UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
		  //if (!Convert.IsDBNull(ado_AccountRep["user_last_name"]))
		  //{
		  //if (Convert.ToString(ado_AccountRep["user_last_name"]).Trim() != modGlobalVars.cEmptyString)
		  //{
		  //sAssignRep = $"{sAssignRep}{Convert.ToString(ado_AccountRep["user_last_name"]).Trim()}";
		  //}
		  //}
		  //
		  //
		  //}
		  //
		  //ado_AccountRep = null;
		  //}
		  //catch
		  //{
		  //
		  //modSubscription.search_off();
		  //}
		  //
		  //}

		private void TooManyResults(int lTot1) //gap-note Method added manually due to GOTO statement
		{
			if (lTot1 > 0)
			{
				MessageBox.Show($"This search would return {StringsHelper.Format(lTot1, "#,##0")} records.{Environment.NewLine}{Environment.NewLine}Please narrow your search with more criteria.", modCommon.pubf_FindFormEntryPointsToString(tFormEntryPoint), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else
			{
				MessageBox.Show($"This search would return too many results.{Environment.NewLine}{Environment.NewLine}Please narrow your search with more criteria.", modCommon.pubf_FindFormEntryPointsToString(tFormEntryPoint), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}

			pnl_display_results.Visible = false;
			pnl_search_results.Visible = false;

			cmd_Find.Enabled = true;
			cmd_Clear.Enabled = true;

			Wait_Pnl_Off();
		}
		public void Check_For_History_Selection()
		{
			if (chk_history.CheckState == CheckState.Checked)
			{
				cmd_find_duplicate.Visible = false;
				chk_match_city.Visible = false;
				txt_num_characters.Visible = false;
				lbl_Label1[23].Visible = false;
			}
			else
			{
				cmd_find_duplicate.Visible = true;
				chk_match_city.Visible = true;
				txt_num_characters.Visible = true;
				lbl_Label1[23].Visible = true;
			}
		}

		private void Set_DemographicList(ref string Continentlist, ref string Regionlist, ref string Countrylist, ref string Statelist)
		{

			string strState = "";

			string Seperator = "";
			if (opt_continent_region[0].Checked)
			{
				int tempForEndVar = lst_area.Items.Count - 1;
				for (int i = 1; i <= tempForEndVar; i++)
				{
					if (ListBoxHelper.GetSelected(lst_area, i))
					{
						Continentlist = $"{Continentlist}{Seperator}{lst_area.GetListItem(i)}";
						Seperator = ",";
					}
				}
			}
			Seperator = "";

			int tempForEndVar2 = lst_country.Items.Count - 1;
			for (int i = 1; i <= tempForEndVar2; i++)
			{
				if (ListBoxHelper.GetSelected(lst_country, i))
				{ //fix_quote added 9/29/04 aey
					Countrylist = $"{Countrylist}{Seperator}{modAdminCommon.Fix_Quote(lst_country.GetListItem(i))}";
					Seperator = ",";
				}
			}
			Seperator = "";
			int tempForEndVar3 = lst_state.Items.Count - 1;
			for (int i = 1; i <= tempForEndVar3; i++)
			{
				if (ListBoxHelper.GetSelected(lst_state, i))
				{
					strState = lst_state.GetListItem(i);
					strState = strState.Substring(0, Math.Min(strState.IndexOf(" - "), strState.Length));
					Statelist = $"{Statelist}{Seperator}{strState}";
					Seperator = ",";
				}
			}
			Seperator = "";
			if (opt_continent_region[1].Checked)
			{
				int tempForEndVar4 = lst_area.Items.Count - 1;
				for (int i = 1; i <= tempForEndVar4; i++)
				{
					if (ListBoxHelper.GetSelected(lst_area, i))
					{
						Regionlist = $"{Regionlist}{Seperator}{lst_area.GetListItem(i)}";
						Seperator = ",";
					}
				}
			}
			if (Countrylist != "")
			{
				Countrylist = $"'{StringsHelper.Replace(Countrylist, ",", "','", 1, -1, CompareMethod.Binary)}'";
			}
			if (Continentlist != "")
			{
				Continentlist = $"'{StringsHelper.Replace(Continentlist, ",", "','", 1, -1, CompareMethod.Binary)}'";
			}
			if (Statelist != "")
			{
				Statelist = $"'{StringsHelper.Replace(Statelist, ",", "','", 1, -1, CompareMethod.Binary)}'";
			}
			if (Regionlist != "")
			{
				Regionlist = $"'{StringsHelper.Replace(Regionlist, ",", "','", 1, -1, CompareMethod.Binary)}'";
			}

		}

		public void select_company_contact()
		{


			try
			{

				tFormExitValues.nFoundCompanyID = grd_find_company.get_RowData(grd_find_company.CurrentRowIndex);

				if (chk_history.CheckState == CheckState.Checked)
				{
					grd_find_company.CurrentColumnIndex = 16;
					tFormExitValues.nFoundCompanyJID = Convert.ToInt32(Double.Parse(grd_find_company[grd_find_company.CurrentRowIndex, grd_find_company.CurrentColumnIndex].FormattedValue.ToString()));
				}
				else
				{
					tFormExitValues.nFoundCompanyJID = 0;
				}

				if (opt_contacts.Checked)
				{
					//UPGRADE_ISSUE: (2064) MSHierarchicalFlexGridLib.MSHFlexGrid property grd_find_company.BandData was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					tFormExitValues.nFoundContactID = grd_find_company.BandData(grd_find_company.CurrentRowIndex);
				}
				else
				{
					tFormExitValues.nFoundContactID = 0;
				}

				Display_Company_Contact();
			}
			catch (System.Exception excep)
			{

				Wait_Pnl_Off();
				modAdminCommon.Report_Error($"Select_CompanyContact_Error: comp_id:{Conversion.Str(nReference_CompanyID)} {excep.Message} {excep.Source} ent:{modCommon.pubf_FindFormEntryPointsToString(tFormEntryPoint)}");
				return;
			}

		}

		private void Display_Aircraft_Info()
		{

			string Query = "";
			ADORecordSetHelper snp_AircraftInfo = new ADORecordSetHelper();

			try
			{

				lst_aircraft_info.Items.Clear();

				Query = "SELECT amod_make_name, amod_model_name, ac_ser_no_full, ac_year ";
				Query = $"{Query}FROM Aircraft WITH (NOLOCK) ";
				Query = $"{Query}INNER JOIN Aircraft_Model WITH (NOLOCK) ON amod_id = ac_amod_id ";
				Query = $"{Query}WHERE (ac_id = {nReference_AircraftID.ToString()}) AND (ac_journ_id = 0)";

				snp_AircraftInfo.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!snp_AircraftInfo.BOF && !snp_AircraftInfo.EOF)
				{
					lst_aircraft_info.AddItem($"MAKE/MODEL: {($"{Convert.ToString(snp_AircraftInfo["amod_make_name"])} ").Trim()}/{($"{Convert.ToString(snp_AircraftInfo["amod_model_name"])} ").Trim()}");
					lst_aircraft_info.AddItem($"SERIAL#: {($"{Convert.ToString(snp_AircraftInfo["ac_ser_no_full"])} ").Trim()}");
					lst_aircraft_info.AddItem($"YEAR: {($"{Convert.ToString(snp_AircraftInfo["ac_year"])} ").Trim()}");
				}

				snp_AircraftInfo.Close();
				snp_AircraftInfo = null;

				lst_aircraft_info.Refresh();
			}
			catch (System.Exception excep)
			{

				Wait_Pnl_Off();
				modAdminCommon.Report_Error($"Display_Aircraft_Info_Error: {excep.Message}");
				return;
			}

		}

		private void Display_Company_Contact()
		{

			int tmpJournID = 0;

			int nCompanyID = Convert.ToInt32(Double.Parse(grd_find_company.get_RowData(grd_find_company.CurrentRowIndex).ToString().Trim()));
			//UPGRADE_ISSUE: (2064) MSHierarchicalFlexGridLib.MSHFlexGrid property grd_find_company.BandData was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			int nContactID = Convert.ToInt32(Double.Parse(grd_find_company.BandData(grd_find_company.CurrentRowIndex).ToString().Trim()));

			pnl_company_info.Visible = true;

			if (chk_history.CheckState == CheckState.Checked)
			{
				// grd_find_company.Col = grd_find_company.Cols - 1 '
				grd_find_company.CurrentColumnIndex = 16;
				tmpJournID = Convert.ToInt32(Double.Parse(grd_find_company[grd_find_company.CurrentRowIndex, grd_find_company.CurrentColumnIndex].FormattedValue.ToString()));
			}
			else
			{
				tmpJournID = 0;
			}

			modCommon.Build_Company_NameAddress(lst_company, nCompanyID, tmpJournID);

			if (opt_contacts.Checked)
			{
				//**************************************
				// DISPLAY CONTACT INFORMATION
				if (nContactID > 0)
				{
					pnl_contact_info.Visible = true;
					modCommon.Build_Contact_Info(lst_contact_info, nContactID, tmpJournID);
					cmd_Confirm_Contact.Visible = true;
				}
				else
				{
					pnl_contact_info.Visible = false;
				}
			}

			string strLock = modCommon.CompanyLocked(grd_find_company.get_RowData(grd_find_company.CurrentRowIndex), tmpJournID);

		}

		private void Select_Duplicate_Company(ref int nCompanyID, ref int nJournalID)
		{

			string tstring = "";
			int tCompanyID = 0;
			int tCompanyJID = 0;
			int nPos = 0;
			int nPos1 = 0;

			try
			{

				if (ListBoxHelper.GetSelectedIndex(lst_duplicates) > 0)
				{

					tstring = lst_duplicates.Text;
					nPos = (tstring.IndexOf("id=(") + 1);

					if (nPos > 0)
					{
						nPos1 = Strings.InStr(nPos + 3, tstring, ") ", CompareMethod.Binary);

						tCompanyID = Convert.ToInt32(Double.Parse(tstring.Substring(Math.Min(nPos + 3, tstring.Length), Math.Min(nPos1 - (nPos + 4), Math.Max(0, tstring.Length - (nPos + 3))))));
						nPos = 0;
						nPos = Strings.InStr(nPos1 + 1, tstring, "jid=(", CompareMethod.Binary);

						if (nPos > 0)
						{
							nPos1 = Strings.InStr(nPos + 4, tstring, ")", CompareMethod.Binary);

							tCompanyJID = Convert.ToInt32(Double.Parse(tstring.Substring(Math.Min(nPos + 4, tstring.Length), Math.Min(nPos1 - (nPos + 5), Math.Max(0, tstring.Length - (nPos + 4))))));

						}

					}

					nCompanyID = tCompanyID;
					nJournalID = tCompanyJID;

				}
			}
			catch
			{

				Wait_Pnl_Off();
				modAdminCommon.Report_Error("Select_Duplicate_Company_Error: ");
			}

		}

		public void Clear_Search_Criteria(bool bClearSearchInput, bool bClearPanels, bool bClearExitValues)
		{


			if (bClearSearchInput)
			{
				// Company Information panel
				txt_comp_name.Text = "";
				txt_comp_address.Text = "";
				txt_comp_phone.Text = "";
				txt_comp_email.Text = "";
				txt_comp_web_address.Text = "";
				txt_comp_zip_code.Text = "";
				txt_comp_city.Text = "";
				txt_company_id[0].Text = ""; // CompId
				txt_company_id[1].Text = ""; // SubId
				cbo_account_rep.SelectedIndex = -1;
				cbo_account_rep.Text = "";
				cbo_business_type.SelectedIndex = -1;
				cbo_business_type.Text = "";
				cbo_agency_type.SelectedIndex = -1;
				cbo_agency_type.Text = "";
				txt_cert_search.Text = ""; // added MSW - 4/4/23

				// Contact Information panel
				txt_contact_last_name.Text = "";
				txt_contact_first_name.Text = "";
				txt_pnum_number_full.Text = "";
				txt_contact_email_address.Text = "";
				txt_num_characters.Text = "0";

				int tempForEndVar = lst_title_group.Items.Count - 1;
				for (int lCnt1 = 0; lCnt1 <= tempForEndVar; lCnt1++)
				{
					ListBoxHelper.SetSelected(lst_title_group, lCnt1, false);
				}
				ListBoxHelper.SetSelected(lst_title_group, 0, true);

				cbo_contact_title.SelectedIndex = -1;
				cbo_contact_title.Text = "";

				// Relationship to Aircraft panel
				cbo_product[0].SelectedIndex = 0;
				cbo_product[1].SelectedIndex = 0;
				cbo_owner_type[0].SelectedIndex = 0;
				cbo_owner_type[1].SelectedIndex = 0;
				cbo_compare[0].SelectedIndex = 0;
				cbo_compare[1].SelectedIndex = 0;

				// changed from all 0's on a clear MSW -4/14/22
				chk_prod_code[0].CheckState = CheckState.Checked;
				chk_prod_code[1].CheckState = CheckState.Checked;
				chk_prod_code[2].CheckState = CheckState.Checked;
				chk_prod_code[3].CheckState = CheckState.Unchecked;

				// Company Demographics pannel
				opt_continent_region[0].Checked = true;
				modFillCompConControls.Fill_Demographics(opt_continent_region, lst_area);
				lst_state.Items.Clear();
				chk_history.CheckState = CheckState.Unchecked;
				chk_ACPros.CheckState = CheckState.Unchecked;
				chkCompContactAddressFlag.CheckState = CheckState.Unchecked;

				//added MSW - 12/18/17
				chk_primary.CheckState = CheckState.Unchecked;
				chk_show_yacht_count.CheckState = CheckState.Unchecked;
				chk_hide_zero.CheckState = CheckState.Unchecked;
				chk_aircraft_count.CheckState = CheckState.Unchecked;
				chk_share_relationships_withoutAC.CheckState = CheckState.Unchecked;
				chk_share_relationships.CheckState = CheckState.Unchecked;
				chk_inactives.CheckState = CheckState.Unchecked;

				// added MSW - make sure its clearing the company search - 1/10/21
				optSearchCust[0].Checked = true;

				grd_find_company.Clear();
				pnl_search_results.Visible = false;

				if (cmd_Associate.Visible)
				{
					cmd_Associate.Visible = false;
				}

				if (cbo_contact_type.Visible)
				{
					cbo_contact_type.Visible = false;
				}

			}

			if (bClearPanels)
			{

				// Any extra panels
				pnl_search_results.Visible = false;
				pnl_company_info.Visible = false;
				pnl_contact_info.Visible = false;
				pnl_duplicates.Visible = false;
				pnl_company_relationships.Visible = false;

				frame_awaiting_documentation.Visible = false;
				frame_potential_dups.Visible = false;
				frame_potential_dups_grid.Visible = false;

			}

			if (bClearExitValues)
			{
				Clear_Exit_Values();
			}

		}

		private void Hide_MySelf()
		{

			try
			{

				if (!modAdminCommon.gbl_bHomeClicked)
				{

					if (!bClickedAssociate && tFormEntryPoint != modGlobalVars.e_find_form_entry_points.geNoEntryPoint)
					{

						Clear_Search_Criteria(true, false, true);

					}

					tFormExitValues.tEntryPoint = tFormEntryPoint;

				}

				this.Hide();
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"ErrorClose_Contact: {Information.Err().Number.ToString()} - {excep.Message} EP:{modCommon.pubf_FindFormEntryPointsToString(tFormExitValues.tEntryPoint)}");

				this.Hide();

				return;
			}

		}

		private void cbo_owner_type_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.cbo_owner_type, eventSender);
			// aey 5/20/04

			txt_ac_value[Index].Visible = false;
			cbo_compare[Index].Visible = false;

			if (chk_history.CheckState == CheckState.Checked)
			{
				cbo_owner_type[Index].SelectedIndex = 0;
				return;
			}

			if (Index == 0 && cbo_product[0].SelectedIndex > 0 && cbo_owner_type[0].SelectedIndex > 0)
			{
				cbo_product[1].Visible = true;
				chk_OR.Visible = true;
			}

			if (Index == 0 && cbo_product[0].SelectedIndex > 0 && cbo_owner_type[0].SelectedIndex == 0)
			{
				cbo_product[1].Visible = false;
				cbo_product[1].SelectedIndex = 0;
				chk_OR.Visible = false;
				cbo_owner_type[1].Visible = false;
				txt_ac_value[1].Visible = false;
				cbo_compare[1].Visible = false;
				cbo_owner_type[0].SelectedIndex = 0;
			}

			if (cbo_owner_type[Index].SelectedIndex > 0 && cbo_owner_type[Index].Visible)
			{
				chk_aircraft_count.CheckState = CheckState.Checked;
				txt_ac_value[Index].Visible = true;
				cbo_compare[Index].Visible = true;
			}
			else
			{
				if (Index == 0)
				{
					chk_aircraft_count.CheckState = CheckState.Unchecked;
				}
			}

			if (cbo_owner_type[0].SelectedIndex > 0 && cbo_owner_type[1].SelectedIndex == 0 && cbo_product[1].SelectedIndex > 0)
			{
				cbo_owner_type[1].SelectedIndex = cbo_owner_type[0].SelectedIndex;
				chk_aircraft_count.CheckState = CheckState.Checked;
				txt_ac_value[1].Visible = true;
				cbo_compare[1].Visible = true;
				cbo_owner_type[1].Visible = true;
			}

			if (cbo_product[Index].SelectedIndex == 0)
			{
				txt_ac_value[Index].Visible = false;
				cbo_compare[Index].Visible = false;
				cbo_owner_type[Index].Visible = false;
			}

		}

		private void cbo_Relationship_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{

			lbl_Label1[27].Text = "";

			if (cbo_relationship.Items.Count > 1)
			{
				if (cbo_relationship.SelectedIndex == 0)
				{
					lbl_Label1[27].Text = cbo_relationship.GetListItem(1);
				}
				else
				{
					lbl_Label1[27].Text = cbo_relationship.GetListItem(0);
				}
			}

			sReference_ContactType = modCompanyFind.Select_Contact_Type(cbo_relationship, tFormEntryPoint);

			lst_company1.Refresh();
			lst_company2.Refresh();

			pnl_company_relationships.Refresh();

		}

		private void chk_history_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{

			if (chk_history.CheckState == CheckState.Checked)
			{

				chk_aircraft_count.CheckState = CheckState.Unchecked;
				cbo_product[1].SelectedIndex = 0;
				cbo_product[0].SelectedIndex = 0;

				chk_share_relationships.CheckState = CheckState.Unchecked;
				chk_share_relationships_withoutAC.CheckState = CheckState.Unchecked;
				chk_aircraft_count.CheckState = CheckState.Unchecked;
				chk_hide_zero.CheckState = CheckState.Unchecked;
				chk_show_yacht_count.CheckState = CheckState.Unchecked;

			} // If chk_history.Value = vbChecked Then

		}

		private void chk_aircraft_count_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{
			// aey 5/20/04
			Set_Sort_Order(ref sOrderBy, true);

			if (chk_aircraft_count.CheckState == CheckState.Unchecked)
			{
				modFillCompConControls.Fill_Owner_Type(cbo_owner_type[0], cbo_compare[0], cbo_owner_type[1], cbo_compare[1], txt_ac_value[0], txt_ac_value[1]);
				chk_hide_zero.CheckState = CheckState.Unchecked;
				chk_hide_zero.Enabled = false;
			}

			if (chk_aircraft_count.CheckState == CheckState.Checked)
			{

				chk_share_relationships.CheckState = CheckState.Unchecked;
				chk_share_relationships_withoutAC.CheckState = CheckState.Unchecked;
				chk_hide_zero.Enabled = true;
				chk_history.CheckState = CheckState.Unchecked;
				chk_show_yacht_count.CheckState = CheckState.Unchecked;
				chk_history.CheckState = CheckState.Unchecked;

				if (cbo_product[0].SelectedIndex > 0)
				{
					cbo_owner_type_SelectionChangeCommitted(cbo_owner_type[0], new EventArgs());
				}

			}

		}

		private void chk_share_relationships_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{

			if (chk_share_relationships.CheckState == CheckState.Checked)
			{
				chk_aircraft_count.CheckState = CheckState.Unchecked;
				chk_share_relationships_withoutAC.CheckState = CheckState.Unchecked;
				chk_show_yacht_count.CheckState = CheckState.Unchecked;
				chk_history.CheckState = CheckState.Unchecked;
			}

		}

		private void chk_share_relationships_withoutAC_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{

			if (chk_share_relationships_withoutAC.CheckState == CheckState.Checked)
			{
				chk_share_relationships.CheckState = CheckState.Unchecked;
				chk_aircraft_count.CheckState = CheckState.Unchecked;
				chk_show_yacht_count.CheckState = CheckState.Unchecked;
				chk_history.CheckState = CheckState.Unchecked;
			}

		}

		private void cbo_product_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.cbo_product, eventSender);
			//product selection
			ToolTipMain.SetToolTip(cbo_product[Index], cbo_product[Index].Text);

			if (chk_history.CheckState == CheckState.Checked)
			{
				lbl_Label1[13].Visible = false;
				lbl_Label1[14].Visible = false;
				cbo_owner_type[0].SelectedIndex = 0;
				cbo_owner_type[0].Visible = false;
				txt_ac_value[0].Visible = false;
				cbo_compare[0].Visible = false;
				cbo_owner_type[1].SelectedIndex = 0;
				cbo_owner_type[1].Visible = false;
				txt_ac_value[1].Visible = false;
				cbo_compare[1].Visible = false;
				cbo_product[1].Visible = false;
				chk_OR.Visible = false;
				return;
			}

			if (cbo_product[Index].SelectedIndex > 0)
			{
				cbo_owner_type[Index].Visible = true;
				lbl_Label1[13].Visible = true;
				lbl_Label1[14].Visible = true;

				if (Index == 0)
				{
					cbo_product[1].Visible = false;
					chk_OR.Visible = false;
				}

				if (Index == 1)
				{
					cbo_owner_type[1].SelectedIndex = 1;
				}

			}
			else
			{
				cbo_owner_type[Index].Visible = false;
				txt_ac_value[Index].Visible = false;
				cbo_compare[Index].Visible = false;
				lbl_Label1[13].Visible = false;
				lbl_Label1[14].Visible = false;
				if (Index == 0)
				{ //And cbo_product(1).ListIndex = 0 Then
					cbo_product[1].Visible = false;
					lbl_Label1[13].Visible = false;
					lbl_Label1[14].Visible = false;
					cbo_owner_type[1].Visible = false;
					txt_ac_value[1].Visible = false;
					cbo_compare[1].Visible = false;
					chk_OR.Visible = false;
					chk_aircraft_count.CheckState = CheckState.Unchecked;
					chk_OR.CheckState = CheckState.Unchecked;
				}
			}

		}

		private void cmd_Confirm_Contact_Click(Object eventSender, EventArgs eventArgs)
		{
			//UPGRADE_ISSUE: (2064) MSHierarchicalFlexGridLib.MSHFlexGrid property grd_find_company.BandData was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			modCommon.Confirm_Contact(grd_find_company.BandData(grd_find_company.CurrentRowIndex));
			select_company_contact();
		}

		public void mnuFileClose_Click(Object eventSender, EventArgs eventArgs) => Hide_MySelf();




		private void Wait_Pnl_On(string inMessage)
		{

			try
			{

				this.Cursor = Cursors.WaitCursor;
				pnl_wait_text.Visible = true;
				//UPGRADE_ISSUE: (2064) Threed.SSPanel property pnl_wait_text.Caption was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				pnl_wait_text.setCaption(inMessage.Trim());
				pnl_wait_text.Refresh();
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, inMessage, Color.Blue);
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Record_Error("Company (frm_Find_Company)", $"Wait_Pnl_On: {Information.Err().Number.ToString()} - {excep.Message}");
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1065
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}

		}

		private void Wait_Pnl_Off()
		{

			this.Cursor = CursorHelper.CursorDefault;
			pnl_wait_text.Visible = false;
			//UPGRADE_ISSUE: (2064) Threed.SSPanel property pnl_wait_text.Caption was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			pnl_wait_text.setCaption(" ");
			pnl_wait_text.Refresh();
			modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
			Application.DoEvents();

		}


		private void txt_company_id_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{

				if (KeyAscii > 31)
				{
					if (KeyAscii < 48 || KeyAscii > 57)
					{
						KeyAscii = 0;
					}
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

		//UPGRADE_NOTE: (7001) The following declaration (Fill_Mail_List_Combo) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void Fill_Mail_List_Combo()
		//{
			//
			//string Query = "";
			//try
			//{
				//
				//ADORecordSetHelper snp_SelectMLList = null;
				//int i = 0;
				//
				//Query = "select jcat_subcategory_code,jcat_subcategory_name from journal_category ";
				//Query = $"{Query}where jcat_category_code='ML'  order by jcat_subcategory_name ";
				//cbo_MailList.Items.Clear();
				//snp_SelectMLList = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");
				////UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				//if (!Convert.IsDBNull(snp_SelectMLList.Fields) && !(snp_SelectMLList.BOF && snp_SelectMLList.EOF))
				//{
					//
					//while(!snp_SelectMLList.EOF)
					//{
						//cbo_MailList.AddItem($"{Convert.ToString(snp_SelectMLList["jcat_subcategory_code"])}-{Convert.ToString(snp_SelectMLList["jcat_subcategory_name"])}");
						//snp_SelectMLList.MoveNext();
					//};
					//snp_SelectMLList.Close();
				//}
				//
				//cbo_MailList.Enabled = true;
				//snp_SelectMLList = null;
			//}
			//catch
			//{
				//MessageBox.Show($"Fill_Mail_List_Combo Error: Error list of mail lists into combo box: {Query}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			//}
		//}

		private void txt_company_id_Leave(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.txt_company_id, eventSender);


			switch(Index)
			{
				case 0 :  // Company Id 
					 
					if (txt_company_id[0].Text.Trim() != "")
					{
						txt_company_id[0].Text = modCommon.LeaveOnlyNumeric(txt_company_id[0].Text);
					} 
					 
					break;
				case 1 :  // Sub Id 
					 
					if (txt_company_id[1].Text.Trim() != "")
					{
						txt_company_id[1].Text = modCommon.LeaveOnlyNumeric(txt_company_id[1].Text);
					} 
					 
					break;
			} // Case Index

		} // txt_company_id_LostFocus
	}
}