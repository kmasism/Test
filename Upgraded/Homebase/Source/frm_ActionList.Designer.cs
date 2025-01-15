
namespace JETNET_Homebase
{
	partial class frm_ActionList
	{

		#region "Upgrade Support "
		private static frm_ActionList m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_ActionList DefInstance
		{
			get
			{
				if (m_vb6FormDefInstance is null || m_vb6FormDefInstance.IsDisposed)
				{
					m_InitializingDefInstance = true;
					m_vb6FormDefInstance = CreateInstance();
					m_InitializingDefInstance = false;
				}
				return m_vb6FormDefInstance;
			}
			set
			{
				m_vb6FormDefInstance = value;
			}
		}

		#endregion
		#region "Windows Form Designer generated code "
		public static frm_ActionList CreateInstance()
		{
			frm_ActionList theInstance = new frm_ActionList();
			theInstance.Form_Load();
			//The MDI form in the VB6 project had its
			//AutoShowChildren property set to True
			//To simulate the VB6 behavior, we need to
			//automatically Show the form whenever it
			//is loaded.  If you do not want this behavior
			//then delete the following line of code
			//UPGRADE_TODO: (2018) Remove the next line of code to stop form from automatically showing. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-2018
			theInstance.Show();
			return theInstance;
		}
		private void Ctx_mnuEdit_Opening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			System.Collections.Generic.List<System.Windows.Forms.ToolStripItem> list = new System.Collections.Generic.List<System.Windows.Forms.ToolStripItem>();
			Ctx_mnuEdit.Items.Clear();
			//We are moving the submenus from original menu to the context menu before displaying it
			foreach (System.Windows.Forms.ToolStripItem item in ((System.Windows.Forms.ToolStripMenuItem) mnuEdit).DropDownItems)
			{
				list.Add(item);
			}
			foreach (System.Windows.Forms.ToolStripItem item in list)
			{
				Ctx_mnuEdit.Items.Add(item);
			}
			e.Cancel = false;
		}
		private void Ctx_mnuEdit_Closed(object sender, System.Windows.Forms.ToolStripDropDownClosedEventArgs e)
		{
			System.Collections.Generic.List<System.Windows.Forms.ToolStripItem> list = new System.Collections.Generic.List<System.Windows.Forms.ToolStripItem>();
			//We are moving the submenus the context menu back to the original menu after displaying
			foreach (System.Windows.Forms.ToolStripItem item in Ctx_mnuEdit.Items)
			{
				list.Add(item);
			}
			foreach (System.Windows.Forms.ToolStripItem item in list)
			{
				((System.Windows.Forms.ToolStripMenuItem) mnuEdit).DropDownItems.Add(item);
			}
		}
		private void Ctx_mnuRightClickCallback_Opening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			System.Collections.Generic.List<System.Windows.Forms.ToolStripItem> list = new System.Collections.Generic.List<System.Windows.Forms.ToolStripItem>();
			Ctx_mnuRightClickCallback.Items.Clear();
			//We are moving the submenus from original menu to the context menu before displaying it
			foreach (System.Windows.Forms.ToolStripItem item in ((System.Windows.Forms.ToolStripMenuItem) mnuRightClickCallback).DropDownItems)
			{
				list.Add(item);
			}
			foreach (System.Windows.Forms.ToolStripItem item in list)
			{
				Ctx_mnuRightClickCallback.Items.Add(item);
			}
			e.Cancel = false;
		}
		private void Ctx_mnuRightClickCallback_Closed(object sender, System.Windows.Forms.ToolStripDropDownClosedEventArgs e)
		{
			System.Collections.Generic.List<System.Windows.Forms.ToolStripItem> list = new System.Collections.Generic.List<System.Windows.Forms.ToolStripItem>();
			//We are moving the submenus the context menu back to the original menu after displaying
			foreach (System.Windows.Forms.ToolStripItem item in Ctx_mnuRightClickCallback.Items)
			{
				list.Add(item);
			}
			foreach (System.Windows.Forms.ToolStripItem item in list)
			{
				((System.Windows.Forms.ToolStripMenuItem) mnuRightClickCallback).DropDownItems.Add(item);
			}
		}
		private string[] visualControls = new string[]{"components", "ToolTipMain", "mnuFileClose", "mnuFileLogout", "mnuFile", "mnuNewPubsAvailable", "mnuCanRegistry", "mnuActionListShowUserHistory", "mnuTools", "mnuViewAcctRepMasterList", "mnuViewVerifyStatusReport", "mnuView", "mnuCopyFindDupsGrid", "mnuEditCompletedCustSubData", "mnuEdit", "mnuChangeDocType", "mnuRightClickCallback", "MainMenu1", "chk_alt_rep", "cmdNewCustSubData", "lbl_Message", "cbo_primary_country", "_chk_action_list_6", "_chk_action_list_5", "_chk_action_list_4", "_chk_action_list_3", "_chk_action_list_2", "_chk_action_list_1", "_chk_action_list_0", "_optSearchCust_2", "_optSearchCust_1", "_optSearchCust_0", "frmCustomers", "cmdRefresh", "Text4", "txt_TotalCallbacks", "txt_TotalAircraft", "cmdSelDClick", "grd_Callbacks", "_lbl_gen_40", "Label24", "_lbl_gen_8", "_lbl_gen_7", "pnl_Callbacks", "_tab_callback_TabPage0", "_chk_action_list_11", "opt_last30", "opt_AllReassigns", "grd_NewAssignments", "txt_total_reassigns", "cmd_Refresh_Reassignments", "lblReassignStopLoading", "_lbl_gen_9", "pnl_reassignemnt", "Label2", "lbl_Reassign_Message", "_tab_callback_TabPage1", "chkDoNotIncludeWrittenOffAC", "cmbColorConfirmType", "grd_CompConfirm", "cmd_Refresh_CompColorConfirm", "txt_Total_Confirm_Companies", "chkNotPrimary", "ChkRelatedtoAircraft", "lblColorConfirmType", "lbl_Comp_Confirm", "lbl_CompConfirm", "_lbl_gen_10", "_tab_callback_TabPage2", "_cmd_refresh_2", "txt_TotExclusive", "txt_expired", "txt_confirmed", "grd_Exclusives", "lst_primary", "lbl_actype", "pnl_primary", "_lbl_gen_11", "_lbl_gen_12", "pnl_Exclusives", "lbl_exclusivesdue", "_tab_callback_TabPage3", "lbl_Hot_Items", "_lbl_gen_37", "grd_Hot_Items", "pnl_Hot_Items", "chk_HotItemsAcctRep", "_opHBAircraftYacht_0", "_opHBAircraftYacht_1", "_cmd_refresh_1", "_chk_action_list_9", "_chk_action_list_10", "_cmd_export_docs_1", "_tab_callback_TabPage4", "_cmd_refresh_0", "txt_total_leased_aircraft", "chk_Unknown", "grd_expired_leases", "_lbl_gen_13", "lbl_expiredleases", "_tab_callback_TabPage5", "cmdRefreshFractOwners", "chk_Current_Acct_Rep", "chk_Date_Less_Than", "optFractionalOwners", "optBadFractions", "opt_OwnersPendingSale", "Opt_Reassigned", "cmd_ClearFractionalReassign", "Opt_FracWithPrimaryWhole", "txt_Total_Comp_Callbacks", "grdFractional", "Label15", "lbl_fract_col5", "Label9", "Label8", "Label1", "_lbl_gen_14", "lbl_fract_col6", "lbl_fract_col7", "lbl_fract_col8", "pnl_fractional_display", "txt_total_bad_fractional", "grdBadFractions", "lbl_6", "Label12", "Label13", "Label16", "Label19", "Label6", "pnlFractionalPercentagesBad", "pnl_Fractional", "lblFractionalMessage", "_tab_callback_TabPage6", "chk_Account_Rep_Wanted", "txt_Tot_CompanyWanted", "txt_Tot_Wanted", "cmd_Refresh_Wanted", "grd_WantedList", "_lbl_gen_16", "_lbl_gen_15", "_tab_callback_TabPage7", "cmdRefreshAvailAircraft", "grd_AvailableAircraft", "lblAvailACTotal", "pnl_AvailableAircraft", "_tab_callback_TabPage8", "_chk_action_list_13", "_cmd_export_docs_2", "_chk_action_list_12", "_cmd_export_docs_0", "chk_compact", "cmbDocType", "cmbDocInProcsClass", "chk_AllDocuments", "cmd_DocsInProcessRefresh", "chkAttachedDocs", "chkResponses", "grd_DocumentLog", "_lbl_gen_36", "lblClass", "lbl_Documents_In_Process", "_tab_callback_TabPage9", "chk_EventsToday", "lstEventCat", "cmdFillEvents", "txtEventDateTo", "txtEventDateFrom", "_lbl_gen_17", "_lbl_gen_18", "fraDateTimeRange", "grdPriorityEvents", "lblTotalPEventRecordsFound", "lblPEventStop", "_tab_callback_TabPage10", "Label26", "txt_total_abi_callbacks", "_tab_callback_TabPage11", "lbl_airbp_remarks", "pnl_bottom_totals", "pnl_bottom_totals2", "_tab_callback_TabPage12", "chkAllYachtCallbackRecords", "cmd_Refresh_Yacht_Callback_List", "cmbYachtCallbackType", "txt_TotalCallbacks_Yachts", "txt_TotalYachts", "grd_Yacht_Callbacks", "_lbl_gen_49", "_lbl_gen_47", "_lbl_gen_46", "_lbl_gen_45", "_lbl_gen_44", "_lbl_gen_43", "_lbl_gen_42", "_lbl_gen_41", "_lbl_gen_35", "lblYTCallbackStop", "_lbl_gen_33", "_lbl_gen_31", "frm_Yacht_Callback", "lbl_Yacht_Callback_Message", "_tab_callback_TabPage13", "lblOwrOprStop", "lblOwrOprRecords", "fgrdOwrOpr", "cmdOwrOprRefresh", "_tab_callback_TabPage14", "cmbFindDupReports", "cmdFindDupsRefresh", "fgrdFindDups", "_lbl_gen_32", "lblFindDupsStop", "lblFindDupsRecords", "_tab_callback_TabPage15", "lblFindACNoBaseStop", "lblFindACNoBaseRecords", "fgrdFindACNoBase", "cmdFindACNoBaseRefresh", "_chk_action_list_8", "_tab_callback_TabPage16", "_chk_action_list_7", "cmdFindACNoCHPRefresh", "fgrdFindACNoCHP", "lblFindACNoCHPRecords", "lblFindACNoCHPStop", "_tab_callback_TabPage17", "chk_new_submitted", "cmdCSDChangeAcctRep", "cmbCustSubAcctRep", "cmd_in_progress", "opSubmitBoth", "opSubmitCompany", "opSubmitAircraft", "cmdSubDataEMail", "chkCustSubDataIncludeCompleted", "cmdFindCustSubDataRefresh", "fgrdFindCustSubData", "_lbl_gen_39", "lblFindCustSubDataStop", "lblFindCustSubDataRecords", "_tab_callback_TabPage18", "chkSortDesc", "cmdResearchReportsExport", "cmbFindResearchReports", "cmdResearchReportsRefresh", "fgrdFindResearchReports", "lblFindResearchReports", "_lbl_gen_38", "lblFindResearchReportsStop", "_tab_callback_TabPage19", "_tab_callback_TabPage20", "_lbl_gen_52", "_lbl_gen_53", "grd_issues", "_cmd_refresh_4", "_cbo_multi_0", "_cbo_multi_1", "_tab_callback_TabPage21", "_cbo_multi_2", "_cmd_refresh_5", "grd_salesforce", "_lbl_gen_55", "_lbl_gen_54", "_tab_callback_TabPage22", "tab_callback", "txt_ListStartDate", "cbo_TimeScale", "cbo_Timezones", "cmbProductType", "cmd_Update_Callback_Dates", "cmd_New_Avail", "cmd_Fix_Fract_Owners", "txt_Callback_Date", "Adodc_CallBack", "cmdStop", "cmd_contacts_phone", "cmd_ClearReassign", "txt_next_confirm_date", "cmdFindLikeCompany", "cmdConfirmExclusive", "lstCompany", "_lbl_gen_5", "pnl_lstcompany", "cal_Callback", "cbo_account_id", "tbr_AL_ToolBar_Buttons_Button1", "tbr_AL_ToolBar_Buttons_Button2", "tbr_AL_ToolBar_Buttons_Button3", "tbr_AL_ToolBar_Buttons_Button4", "tbr_AL_ToolBar_Buttons_Button5", "tbr_AL_ToolBar_Buttons_Button6", "tbr_AL_ToolBar_Buttons_Button7", "tbr_AL_ToolBar_Buttons_Button8", "Label3", "tbr_AL_ToolBar", "Text6", "Text5", "Text3", "Text2", "Text1", "Label40", "_Label36_0", "_Label35_0", "_Label37_0", "Label39", "SSPanel1", "text_airbp_remarks", "lblTotRecordFound", "Label7", "pnl_Wait", "lbl_Test_omg", "_lbl_gen_57", "_lbl_gen_48", "_lbl_gen_4", "_lbl_gen_0", "_lbl_gen_3", "Label42", "Label47", "Label46", "_lbl_gen_6", "_lbl_gen_2", "_lbl_gen_1", "Label35", "Label36", "Label37", "cbo_multi", "chk_action_list", "cmd_export_docs", "cmd_refresh", "lbl_gen", "opHBAircraftYacht", "optSearchCust", "Ctx_mnuEdit", "Ctx_mnuRightClickCallback", "listBoxComboBoxHelper1", "listBoxHelper1", "optionButtonHelper1", "commandButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.ToolStripMenuItem mnuFileClose;
		public System.Windows.Forms.ToolStripMenuItem mnuFileLogout;
		public System.Windows.Forms.ToolStripMenuItem mnuFile;
		public System.Windows.Forms.ToolStripMenuItem mnuNewPubsAvailable;
		public System.Windows.Forms.ToolStripMenuItem mnuCanRegistry;
		public System.Windows.Forms.ToolStripMenuItem mnuActionListShowUserHistory;
		public System.Windows.Forms.ToolStripMenuItem mnuTools;
		public System.Windows.Forms.ToolStripMenuItem mnuViewAcctRepMasterList;
		public System.Windows.Forms.ToolStripMenuItem mnuViewVerifyStatusReport;
		public System.Windows.Forms.ToolStripMenuItem mnuView;
		public System.Windows.Forms.ToolStripMenuItem mnuCopyFindDupsGrid;
		public System.Windows.Forms.ToolStripMenuItem mnuEditCompletedCustSubData;
		public System.Windows.Forms.ToolStripMenuItem mnuEdit;
		public System.Windows.Forms.ToolStripMenuItem mnuChangeDocType;
		public System.Windows.Forms.ToolStripMenuItem mnuRightClickCallback;
		public System.Windows.Forms.MenuStrip MainMenu1;
		public System.Windows.Forms.CheckBox chk_alt_rep;
		public System.Windows.Forms.Button cmdNewCustSubData;
		public System.Windows.Forms.Label lbl_Message;
		public System.Windows.Forms.ComboBox cbo_primary_country;
		private System.Windows.Forms.CheckBox _chk_action_list_6;
		private System.Windows.Forms.CheckBox _chk_action_list_5;
		private System.Windows.Forms.CheckBox _chk_action_list_4;
		private System.Windows.Forms.CheckBox _chk_action_list_3;
		private System.Windows.Forms.CheckBox _chk_action_list_2;
		private System.Windows.Forms.CheckBox _chk_action_list_1;
		private System.Windows.Forms.CheckBox _chk_action_list_0;
		private System.Windows.Forms.RadioButton _optSearchCust_2;
		private System.Windows.Forms.RadioButton _optSearchCust_1;
		private System.Windows.Forms.RadioButton _optSearchCust_0;
		public System.Windows.Forms.GroupBox frmCustomers;
		public System.Windows.Forms.Button cmdRefresh;
		public System.Windows.Forms.TextBox Text4;
		public System.Windows.Forms.TextBox txt_TotalCallbacks;
		public System.Windows.Forms.TextBox txt_TotalAircraft;
		public System.Windows.Forms.Button cmdSelDClick;
		public UpgradeHelpers.DataGridViewFlex grd_Callbacks;
		private System.Windows.Forms.Label _lbl_gen_40;
		public System.Windows.Forms.Label Label24;
		private System.Windows.Forms.Label _lbl_gen_8;
		private System.Windows.Forms.Label _lbl_gen_7;
		public System.Windows.Forms.Panel pnl_Callbacks;
		private System.Windows.Forms.TabPage _tab_callback_TabPage0;
		private System.Windows.Forms.CheckBox _chk_action_list_11;
		public System.Windows.Forms.RadioButton opt_last30;
		public System.Windows.Forms.RadioButton opt_AllReassigns;
		public UpgradeHelpers.DataGridViewFlex grd_NewAssignments;
		public System.Windows.Forms.TextBox txt_total_reassigns;
		public System.Windows.Forms.Button cmd_Refresh_Reassignments;
		public System.Windows.Forms.Label lblReassignStopLoading;
		private System.Windows.Forms.Label _lbl_gen_9;
		public System.Windows.Forms.Panel pnl_reassignemnt;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label lbl_Reassign_Message;
		private System.Windows.Forms.TabPage _tab_callback_TabPage1;
		public System.Windows.Forms.CheckBox chkDoNotIncludeWrittenOffAC;
		public System.Windows.Forms.ComboBox cmbColorConfirmType;
		public UpgradeHelpers.DataGridViewFlex grd_CompConfirm;
		public System.Windows.Forms.Button cmd_Refresh_CompColorConfirm;
		public System.Windows.Forms.TextBox txt_Total_Confirm_Companies;
		public System.Windows.Forms.CheckBox chkNotPrimary;
		public System.Windows.Forms.CheckBox ChkRelatedtoAircraft;
		public System.Windows.Forms.Label lblColorConfirmType;
		public System.Windows.Forms.Label lbl_Comp_Confirm;
		public System.Windows.Forms.Label lbl_CompConfirm;
		private System.Windows.Forms.Label _lbl_gen_10;
		private System.Windows.Forms.TabPage _tab_callback_TabPage2;
		private System.Windows.Forms.Button _cmd_refresh_2;
		public System.Windows.Forms.TextBox txt_TotExclusive;
		public System.Windows.Forms.TextBox txt_expired;
		public System.Windows.Forms.TextBox txt_confirmed;
		public UpgradeHelpers.DataGridViewFlex grd_Exclusives;
		public System.Windows.Forms.ListBox lst_primary;
		public System.Windows.Forms.Label lbl_actype;
		public System.Windows.Forms.Panel pnl_primary;
		private System.Windows.Forms.Label _lbl_gen_11;
		private System.Windows.Forms.Label _lbl_gen_12;
		public System.Windows.Forms.Panel pnl_Exclusives;
		public System.Windows.Forms.Label lbl_exclusivesdue;
		private System.Windows.Forms.TabPage _tab_callback_TabPage3;
		public System.Windows.Forms.Label lbl_Hot_Items;
		private System.Windows.Forms.Label _lbl_gen_37;
		public UpgradeHelpers.DataGridViewFlex grd_Hot_Items;
		public System.Windows.Forms.Panel pnl_Hot_Items;
		public System.Windows.Forms.CheckBox chk_HotItemsAcctRep;
		private System.Windows.Forms.RadioButton _opHBAircraftYacht_0;
		private System.Windows.Forms.RadioButton _opHBAircraftYacht_1;
		private System.Windows.Forms.Button _cmd_refresh_1;
		private System.Windows.Forms.CheckBox _chk_action_list_9;
		private System.Windows.Forms.CheckBox _chk_action_list_10;
		private System.Windows.Forms.Button _cmd_export_docs_1;
		private System.Windows.Forms.TabPage _tab_callback_TabPage4;
		private System.Windows.Forms.Button _cmd_refresh_0;
		public System.Windows.Forms.TextBox txt_total_leased_aircraft;
		public System.Windows.Forms.CheckBox chk_Unknown;
		public UpgradeHelpers.DataGridViewFlex grd_expired_leases;
		private System.Windows.Forms.Label _lbl_gen_13;
		public System.Windows.Forms.Label lbl_expiredleases;
		private System.Windows.Forms.TabPage _tab_callback_TabPage5;
		public System.Windows.Forms.Button cmdRefreshFractOwners;
		public System.Windows.Forms.CheckBox chk_Current_Acct_Rep;
		public System.Windows.Forms.CheckBox chk_Date_Less_Than;
		public System.Windows.Forms.RadioButton optFractionalOwners;
		public System.Windows.Forms.RadioButton optBadFractions;
		public System.Windows.Forms.RadioButton opt_OwnersPendingSale;
		public System.Windows.Forms.RadioButton Opt_Reassigned;
		public System.Windows.Forms.Button cmd_ClearFractionalReassign;
		public System.Windows.Forms.RadioButton Opt_FracWithPrimaryWhole;
		public System.Windows.Forms.TextBox txt_Total_Comp_Callbacks;
		public UpgradeHelpers.DataGridViewFlex grdFractional;
		public System.Windows.Forms.Label Label15;
		public System.Windows.Forms.Label lbl_fract_col5;
		public System.Windows.Forms.Label Label9;
		public System.Windows.Forms.Label Label8;
		public System.Windows.Forms.Label Label1;
		private System.Windows.Forms.Label _lbl_gen_14;
		public System.Windows.Forms.Label lbl_fract_col6;
		public System.Windows.Forms.Label lbl_fract_col7;
		public System.Windows.Forms.Label lbl_fract_col8;
		public System.Windows.Forms.Panel pnl_fractional_display;
		public System.Windows.Forms.TextBox txt_total_bad_fractional;
		public UpgradeHelpers.DataGridViewFlex grdBadFractions;
		public System.Windows.Forms.Label lbl_6;
		public System.Windows.Forms.Label Label12;
		public System.Windows.Forms.Label Label13;
		public System.Windows.Forms.Label Label16;
		public System.Windows.Forms.Label Label19;
		public System.Windows.Forms.Label Label6;
		public System.Windows.Forms.Panel pnlFractionalPercentagesBad;
		public System.Windows.Forms.Panel pnl_Fractional;
		public System.Windows.Forms.Label lblFractionalMessage;
		private System.Windows.Forms.TabPage _tab_callback_TabPage6;
		public System.Windows.Forms.CheckBox chk_Account_Rep_Wanted;
		public System.Windows.Forms.TextBox txt_Tot_CompanyWanted;
		public System.Windows.Forms.TextBox txt_Tot_Wanted;
		public System.Windows.Forms.Button cmd_Refresh_Wanted;
		public UpgradeHelpers.DataGridViewFlex grd_WantedList;
		private System.Windows.Forms.Label _lbl_gen_16;
		private System.Windows.Forms.Label _lbl_gen_15;
		private System.Windows.Forms.TabPage _tab_callback_TabPage7;
		public System.Windows.Forms.Button cmdRefreshAvailAircraft;
		public UpgradeHelpers.DataGridViewFlex grd_AvailableAircraft;
		public System.Windows.Forms.Label lblAvailACTotal;
		public System.Windows.Forms.Panel pnl_AvailableAircraft;
		private System.Windows.Forms.TabPage _tab_callback_TabPage8;
		private System.Windows.Forms.CheckBox _chk_action_list_13;
		private System.Windows.Forms.Button _cmd_export_docs_2;
		private System.Windows.Forms.CheckBox _chk_action_list_12;
		private System.Windows.Forms.Button _cmd_export_docs_0;
		public System.Windows.Forms.CheckBox chk_compact;
		public System.Windows.Forms.ComboBox cmbDocType;
		public System.Windows.Forms.ComboBox cmbDocInProcsClass;
		public System.Windows.Forms.CheckBox chk_AllDocuments;
		public System.Windows.Forms.Button cmd_DocsInProcessRefresh;
		public System.Windows.Forms.CheckBox chkAttachedDocs;
		public System.Windows.Forms.CheckBox chkResponses;
		public UpgradeHelpers.DataGridViewFlex grd_DocumentLog;
		private System.Windows.Forms.Label _lbl_gen_36;
		public System.Windows.Forms.Label lblClass;
		public System.Windows.Forms.Label lbl_Documents_In_Process;
		private System.Windows.Forms.TabPage _tab_callback_TabPage9;
		public System.Windows.Forms.CheckBox chk_EventsToday;
		public System.Windows.Forms.ListBox lstEventCat;
		public System.Windows.Forms.Button cmdFillEvents;
		public System.Windows.Forms.TextBox txtEventDateTo;
		public System.Windows.Forms.TextBox txtEventDateFrom;
		private System.Windows.Forms.Label _lbl_gen_17;
		private System.Windows.Forms.Label _lbl_gen_18;
		public System.Windows.Forms.GroupBox fraDateTimeRange;
		public UpgradeHelpers.DataGridViewFlex grdPriorityEvents;
		public System.Windows.Forms.Label lblTotalPEventRecordsFound;
		public System.Windows.Forms.Label lblPEventStop;
		private System.Windows.Forms.TabPage _tab_callback_TabPage10;
		public System.Windows.Forms.Label Label26;
		public System.Windows.Forms.TextBox txt_total_abi_callbacks;
		private System.Windows.Forms.TabPage _tab_callback_TabPage11;
		public System.Windows.Forms.Label lbl_airbp_remarks;
		public System.Windows.Forms.Panel pnl_bottom_totals;
		public System.Windows.Forms.Panel pnl_bottom_totals2;
		private System.Windows.Forms.TabPage _tab_callback_TabPage12;
		public System.Windows.Forms.CheckBox chkAllYachtCallbackRecords;
		public System.Windows.Forms.Button cmd_Refresh_Yacht_Callback_List;
		public System.Windows.Forms.ComboBox cmbYachtCallbackType;
		public System.Windows.Forms.TextBox txt_TotalCallbacks_Yachts;
		public System.Windows.Forms.TextBox txt_TotalYachts;
		public UpgradeHelpers.DataGridViewFlex grd_Yacht_Callbacks;
		private System.Windows.Forms.Label _lbl_gen_49;
		private System.Windows.Forms.Label _lbl_gen_47;
		private System.Windows.Forms.Label _lbl_gen_46;
		private System.Windows.Forms.Label _lbl_gen_45;
		private System.Windows.Forms.Label _lbl_gen_44;
		private System.Windows.Forms.Label _lbl_gen_43;
		private System.Windows.Forms.Label _lbl_gen_42;
		private System.Windows.Forms.Label _lbl_gen_41;
		private System.Windows.Forms.Label _lbl_gen_35;
		public System.Windows.Forms.Label lblYTCallbackStop;
		private System.Windows.Forms.Label _lbl_gen_33;
		private System.Windows.Forms.Label _lbl_gen_31;
		public System.Windows.Forms.GroupBox frm_Yacht_Callback;
		public System.Windows.Forms.Label lbl_Yacht_Callback_Message;
		private System.Windows.Forms.TabPage _tab_callback_TabPage13;
		public System.Windows.Forms.Label lblOwrOprStop;
		public System.Windows.Forms.Label lblOwrOprRecords;
		public UpgradeHelpers.DataGridViewFlex fgrdOwrOpr;
		public System.Windows.Forms.Button cmdOwrOprRefresh;
		private System.Windows.Forms.TabPage _tab_callback_TabPage14;
		public System.Windows.Forms.ComboBox cmbFindDupReports;
		public System.Windows.Forms.Button cmdFindDupsRefresh;
		public UpgradeHelpers.DataGridViewFlex fgrdFindDups;
		private System.Windows.Forms.Label _lbl_gen_32;
		public System.Windows.Forms.Label lblFindDupsStop;
		public System.Windows.Forms.Label lblFindDupsRecords;
		private System.Windows.Forms.TabPage _tab_callback_TabPage15;
		public System.Windows.Forms.Label lblFindACNoBaseStop;
		public System.Windows.Forms.Label lblFindACNoBaseRecords;
		public UpgradeHelpers.DataGridViewFlex fgrdFindACNoBase;
		public System.Windows.Forms.Button cmdFindACNoBaseRefresh;
		private System.Windows.Forms.CheckBox _chk_action_list_8;
		private System.Windows.Forms.TabPage _tab_callback_TabPage16;
		private System.Windows.Forms.CheckBox _chk_action_list_7;
		public System.Windows.Forms.Button cmdFindACNoCHPRefresh;
		public UpgradeHelpers.DataGridViewFlex fgrdFindACNoCHP;
		public System.Windows.Forms.Label lblFindACNoCHPRecords;
		public System.Windows.Forms.Label lblFindACNoCHPStop;
		private System.Windows.Forms.TabPage _tab_callback_TabPage17;
		public System.Windows.Forms.CheckBox chk_new_submitted;
		public System.Windows.Forms.Button cmdCSDChangeAcctRep;
		public System.Windows.Forms.ComboBox cmbCustSubAcctRep;
		public System.Windows.Forms.Button cmd_in_progress;
		public System.Windows.Forms.RadioButton opSubmitBoth;
		public System.Windows.Forms.RadioButton opSubmitCompany;
		public System.Windows.Forms.RadioButton opSubmitAircraft;
		public System.Windows.Forms.Button cmdSubDataEMail;
		public System.Windows.Forms.CheckBox chkCustSubDataIncludeCompleted;
		public System.Windows.Forms.Button cmdFindCustSubDataRefresh;
		public UpgradeHelpers.DataGridViewFlex fgrdFindCustSubData;
		private System.Windows.Forms.Label _lbl_gen_39;
		public System.Windows.Forms.Label lblFindCustSubDataStop;
		public System.Windows.Forms.Label lblFindCustSubDataRecords;
		private System.Windows.Forms.TabPage _tab_callback_TabPage18;
		public System.Windows.Forms.CheckBox chkSortDesc;
		public System.Windows.Forms.Button cmdResearchReportsExport;
		public System.Windows.Forms.ComboBox cmbFindResearchReports;
		public System.Windows.Forms.Button cmdResearchReportsRefresh;
		public UpgradeHelpers.DataGridViewFlex fgrdFindResearchReports;
		public System.Windows.Forms.Label lblFindResearchReports;
		private System.Windows.Forms.Label _lbl_gen_38;
		public System.Windows.Forms.Label lblFindResearchReportsStop;
		private System.Windows.Forms.TabPage _tab_callback_TabPage19;
		private System.Windows.Forms.TabPage _tab_callback_TabPage20;
		private System.Windows.Forms.Label _lbl_gen_52;
		private System.Windows.Forms.Label _lbl_gen_53;
		public UpgradeHelpers.DataGridViewFlex grd_issues;
		private System.Windows.Forms.Button _cmd_refresh_4;
		private System.Windows.Forms.ComboBox _cbo_multi_0;
		private System.Windows.Forms.ComboBox _cbo_multi_1;
		private System.Windows.Forms.TabPage _tab_callback_TabPage21;
		private System.Windows.Forms.ComboBox _cbo_multi_2;
		private System.Windows.Forms.Button _cmd_refresh_5;
		public UpgradeHelpers.DataGridViewFlex grd_salesforce;
		private System.Windows.Forms.Label _lbl_gen_55;
		private System.Windows.Forms.Label _lbl_gen_54;
		private System.Windows.Forms.TabPage _tab_callback_TabPage22;
		public UpgradeHelpers.Gui.Controls.TabControlExtension tab_callback;
		public System.Windows.Forms.TextBox txt_ListStartDate;
		public System.Windows.Forms.ComboBox cbo_TimeScale;
		public System.Windows.Forms.ComboBox cbo_Timezones;
		public System.Windows.Forms.ComboBox cmbProductType;
		public System.Windows.Forms.Button cmd_Update_Callback_Dates;
		public System.Windows.Forms.Button cmd_New_Avail;
		public System.Windows.Forms.Button cmd_Fix_Fract_Owners;
		public System.Windows.Forms.TextBox txt_Callback_Date;
		public UpgradeHelpers.DB.ADO.ADODataControlHelper Adodc_CallBack;
		public System.Windows.Forms.Button cmdStop;
		public System.Windows.Forms.Button cmd_contacts_phone;
		public System.Windows.Forms.Button cmd_ClearReassign;
		public System.Windows.Forms.TextBox txt_next_confirm_date;
		public System.Windows.Forms.Button cmdFindLikeCompany;
		public System.Windows.Forms.Button cmdConfirmExclusive;
		public System.Windows.Forms.ListBox lstCompany;
		private System.Windows.Forms.Label _lbl_gen_5;
		public System.Windows.Forms.Panel pnl_lstcompany;
		public System.Windows.Forms.MonthCalendar cal_Callback;
		public System.Windows.Forms.ComboBox cbo_account_id;
		public System.Windows.Forms.ToolStripSeparator tbr_AL_ToolBar_Buttons_Button1;
		public System.Windows.Forms.ToolStripButton tbr_AL_ToolBar_Buttons_Button2;
		public System.Windows.Forms.ToolStripSeparator tbr_AL_ToolBar_Buttons_Button3;
		public System.Windows.Forms.ToolStripButton tbr_AL_ToolBar_Buttons_Button4;
		public System.Windows.Forms.ToolStripSeparator tbr_AL_ToolBar_Buttons_Button5;
		public System.Windows.Forms.ToolStripButton tbr_AL_ToolBar_Buttons_Button6;
		public System.Windows.Forms.ToolStripSeparator tbr_AL_ToolBar_Buttons_Button7;
		public System.Windows.Forms.ToolStripButton tbr_AL_ToolBar_Buttons_Button8;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.ToolStrip tbr_AL_ToolBar;
		public System.Windows.Forms.TextBox Text6;
		public System.Windows.Forms.TextBox Text5;
		public System.Windows.Forms.TextBox Text3;
		public System.Windows.Forms.TextBox Text2;
		public System.Windows.Forms.TextBox Text1;
		public System.Windows.Forms.Label Label40;
		private System.Windows.Forms.Label _Label36_0;
		private System.Windows.Forms.Label _Label35_0;
		private System.Windows.Forms.Label _Label37_0;
		public System.Windows.Forms.Label Label39;
		public System.Windows.Forms.Panel SSPanel1;
		public System.Windows.Forms.TextBox text_airbp_remarks;
		public System.Windows.Forms.Label lblTotRecordFound;
		public System.Windows.Forms.Label Label7;
		public System.Windows.Forms.Panel pnl_Wait;
		public System.Windows.Forms.Label lbl_Test_omg;
		private System.Windows.Forms.Label _lbl_gen_57;
		private System.Windows.Forms.Label _lbl_gen_48;
		private System.Windows.Forms.Label _lbl_gen_4;
		private System.Windows.Forms.Label _lbl_gen_0;
		private System.Windows.Forms.Label _lbl_gen_3;
		public System.Windows.Forms.Label Label42;
		public System.Windows.Forms.Label Label47;
		public System.Windows.Forms.Label Label46;
		private System.Windows.Forms.Label _lbl_gen_6;
		private System.Windows.Forms.Label _lbl_gen_2;
		private System.Windows.Forms.Label _lbl_gen_1;
		public System.Windows.Forms.Label[] Label35 = new System.Windows.Forms.Label[1];
		public System.Windows.Forms.Label[] Label36 = new System.Windows.Forms.Label[1];
		public System.Windows.Forms.Label[] Label37 = new System.Windows.Forms.Label[1];
		public System.Windows.Forms.ComboBox[] cbo_multi = new System.Windows.Forms.ComboBox[3];
		public System.Windows.Forms.CheckBox[] chk_action_list = new System.Windows.Forms.CheckBox[14];
		public System.Windows.Forms.Button[] cmd_export_docs = new System.Windows.Forms.Button[3];
		public System.Windows.Forms.Button[] cmd_refresh = new System.Windows.Forms.Button[6];
		public System.Windows.Forms.Label[] lbl_gen = new System.Windows.Forms.Label[58];
		public System.Windows.Forms.RadioButton[] opHBAircraftYacht = new System.Windows.Forms.RadioButton[2];
		public System.Windows.Forms.RadioButton[] optSearchCust = new System.Windows.Forms.RadioButton[3];
		public System.Windows.Forms.ContextMenuStrip Ctx_mnuEdit;
		public System.Windows.Forms.ContextMenuStrip Ctx_mnuRightClickCallback;
		public UpgradeHelpers.Gui.Controls.ListControlHelper listBoxComboBoxHelper1;
		public UpgradeHelpers.Gui.Controls.ListBoxHelper listBoxHelper1;
		public UpgradeHelpers.Gui.Controls.OptionButtonHelper optionButtonHelper1;
		public UpgradeHelpers.Gui.Controls.CommandButtonHelper commandButtonHelper1;
		private int tab_callbackPreviousTab;
		public System.ComponentModel.ComponentResourceManager resources;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ActionList));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			MainMenu1 = new System.Windows.Forms.MenuStrip();
			mnuFile = new System.Windows.Forms.ToolStripMenuItem();
			mnuFileClose = new System.Windows.Forms.ToolStripMenuItem();
			mnuFileLogout = new System.Windows.Forms.ToolStripMenuItem();
			mnuTools = new System.Windows.Forms.ToolStripMenuItem();
			mnuNewPubsAvailable = new System.Windows.Forms.ToolStripMenuItem();
			mnuCanRegistry = new System.Windows.Forms.ToolStripMenuItem();
			mnuActionListShowUserHistory = new System.Windows.Forms.ToolStripMenuItem();
			mnuView = new System.Windows.Forms.ToolStripMenuItem();
			mnuViewAcctRepMasterList = new System.Windows.Forms.ToolStripMenuItem();
			mnuViewVerifyStatusReport = new System.Windows.Forms.ToolStripMenuItem();
			mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
			mnuCopyFindDupsGrid = new System.Windows.Forms.ToolStripMenuItem();
			mnuEditCompletedCustSubData = new System.Windows.Forms.ToolStripMenuItem();
			mnuRightClickCallback = new System.Windows.Forms.ToolStripMenuItem();
			mnuChangeDocType = new System.Windows.Forms.ToolStripMenuItem();
			chk_alt_rep = new System.Windows.Forms.CheckBox();
			cmdNewCustSubData = new System.Windows.Forms.Button();
			tab_callback = new UpgradeHelpers.Gui.Controls.TabControlExtension();
			_tab_callback_TabPage0 = new System.Windows.Forms.TabPage();
			lbl_Message = new System.Windows.Forms.Label();
			pnl_Callbacks = new System.Windows.Forms.Panel();
			cbo_primary_country = new System.Windows.Forms.ComboBox();
			_chk_action_list_6 = new System.Windows.Forms.CheckBox();
			_chk_action_list_5 = new System.Windows.Forms.CheckBox();
			_chk_action_list_4 = new System.Windows.Forms.CheckBox();
			_chk_action_list_3 = new System.Windows.Forms.CheckBox();
			_chk_action_list_2 = new System.Windows.Forms.CheckBox();
			_chk_action_list_1 = new System.Windows.Forms.CheckBox();
			_chk_action_list_0 = new System.Windows.Forms.CheckBox();
			frmCustomers = new System.Windows.Forms.GroupBox();
			_optSearchCust_2 = new System.Windows.Forms.RadioButton();
			_optSearchCust_1 = new System.Windows.Forms.RadioButton();
			_optSearchCust_0 = new System.Windows.Forms.RadioButton();
			cmdRefresh = new System.Windows.Forms.Button();
			Text4 = new System.Windows.Forms.TextBox();
			txt_TotalCallbacks = new System.Windows.Forms.TextBox();
			txt_TotalAircraft = new System.Windows.Forms.TextBox();
			cmdSelDClick = new System.Windows.Forms.Button();
			grd_Callbacks = new UpgradeHelpers.DataGridViewFlex(components);
			_lbl_gen_40 = new System.Windows.Forms.Label();
			Label24 = new System.Windows.Forms.Label();
			_lbl_gen_8 = new System.Windows.Forms.Label();
			_lbl_gen_7 = new System.Windows.Forms.Label();
			_tab_callback_TabPage1 = new System.Windows.Forms.TabPage();
			_chk_action_list_11 = new System.Windows.Forms.CheckBox();
			opt_last30 = new System.Windows.Forms.RadioButton();
			opt_AllReassigns = new System.Windows.Forms.RadioButton();
			pnl_reassignemnt = new System.Windows.Forms.Panel();
			grd_NewAssignments = new UpgradeHelpers.DataGridViewFlex(components);
			txt_total_reassigns = new System.Windows.Forms.TextBox();
			cmd_Refresh_Reassignments = new System.Windows.Forms.Button();
			lblReassignStopLoading = new System.Windows.Forms.Label();
			_lbl_gen_9 = new System.Windows.Forms.Label();
			Label2 = new System.Windows.Forms.Label();
			lbl_Reassign_Message = new System.Windows.Forms.Label();
			_tab_callback_TabPage2 = new System.Windows.Forms.TabPage();
			chkDoNotIncludeWrittenOffAC = new System.Windows.Forms.CheckBox();
			cmbColorConfirmType = new System.Windows.Forms.ComboBox();
			grd_CompConfirm = new UpgradeHelpers.DataGridViewFlex(components);
			cmd_Refresh_CompColorConfirm = new System.Windows.Forms.Button();
			txt_Total_Confirm_Companies = new System.Windows.Forms.TextBox();
			chkNotPrimary = new System.Windows.Forms.CheckBox();
			ChkRelatedtoAircraft = new System.Windows.Forms.CheckBox();
			lblColorConfirmType = new System.Windows.Forms.Label();
			lbl_Comp_Confirm = new System.Windows.Forms.Label();
			lbl_CompConfirm = new System.Windows.Forms.Label();
			_lbl_gen_10 = new System.Windows.Forms.Label();
			_tab_callback_TabPage3 = new System.Windows.Forms.TabPage();
			pnl_Exclusives = new System.Windows.Forms.Panel();
			_cmd_refresh_2 = new System.Windows.Forms.Button();
			txt_TotExclusive = new System.Windows.Forms.TextBox();
			txt_expired = new System.Windows.Forms.TextBox();
			txt_confirmed = new System.Windows.Forms.TextBox();
			grd_Exclusives = new UpgradeHelpers.DataGridViewFlex(components);
			pnl_primary = new System.Windows.Forms.Panel();
			lst_primary = new System.Windows.Forms.ListBox();
			lbl_actype = new System.Windows.Forms.Label();
			_lbl_gen_11 = new System.Windows.Forms.Label();
			_lbl_gen_12 = new System.Windows.Forms.Label();
			lbl_exclusivesdue = new System.Windows.Forms.Label();
			_tab_callback_TabPage4 = new System.Windows.Forms.TabPage();
			lbl_Hot_Items = new System.Windows.Forms.Label();
			_lbl_gen_37 = new System.Windows.Forms.Label();
			pnl_Hot_Items = new System.Windows.Forms.Panel();
			grd_Hot_Items = new UpgradeHelpers.DataGridViewFlex(components);
			chk_HotItemsAcctRep = new System.Windows.Forms.CheckBox();
			_opHBAircraftYacht_0 = new System.Windows.Forms.RadioButton();
			_opHBAircraftYacht_1 = new System.Windows.Forms.RadioButton();
			_cmd_refresh_1 = new System.Windows.Forms.Button();
			_chk_action_list_9 = new System.Windows.Forms.CheckBox();
			_chk_action_list_10 = new System.Windows.Forms.CheckBox();
			_cmd_export_docs_1 = new System.Windows.Forms.Button();
			_tab_callback_TabPage5 = new System.Windows.Forms.TabPage();
			_cmd_refresh_0 = new System.Windows.Forms.Button();
			txt_total_leased_aircraft = new System.Windows.Forms.TextBox();
			chk_Unknown = new System.Windows.Forms.CheckBox();
			grd_expired_leases = new UpgradeHelpers.DataGridViewFlex(components);
			_lbl_gen_13 = new System.Windows.Forms.Label();
			lbl_expiredleases = new System.Windows.Forms.Label();
			_tab_callback_TabPage6 = new System.Windows.Forms.TabPage();
			pnl_Fractional = new System.Windows.Forms.Panel();
			cmdRefreshFractOwners = new System.Windows.Forms.Button();
			chk_Current_Acct_Rep = new System.Windows.Forms.CheckBox();
			chk_Date_Less_Than = new System.Windows.Forms.CheckBox();
			optFractionalOwners = new System.Windows.Forms.RadioButton();
			optBadFractions = new System.Windows.Forms.RadioButton();
			opt_OwnersPendingSale = new System.Windows.Forms.RadioButton();
			Opt_Reassigned = new System.Windows.Forms.RadioButton();
			cmd_ClearFractionalReassign = new System.Windows.Forms.Button();
			Opt_FracWithPrimaryWhole = new System.Windows.Forms.RadioButton();
			pnl_fractional_display = new System.Windows.Forms.Panel();
			txt_Total_Comp_Callbacks = new System.Windows.Forms.TextBox();
			grdFractional = new UpgradeHelpers.DataGridViewFlex(components);
			Label15 = new System.Windows.Forms.Label();
			lbl_fract_col5 = new System.Windows.Forms.Label();
			Label9 = new System.Windows.Forms.Label();
			Label8 = new System.Windows.Forms.Label();
			Label1 = new System.Windows.Forms.Label();
			_lbl_gen_14 = new System.Windows.Forms.Label();
			lbl_fract_col6 = new System.Windows.Forms.Label();
			lbl_fract_col7 = new System.Windows.Forms.Label();
			lbl_fract_col8 = new System.Windows.Forms.Label();
			pnlFractionalPercentagesBad = new System.Windows.Forms.Panel();
			txt_total_bad_fractional = new System.Windows.Forms.TextBox();
			grdBadFractions = new UpgradeHelpers.DataGridViewFlex(components);
			lbl_6 = new System.Windows.Forms.Label();
			Label12 = new System.Windows.Forms.Label();
			Label13 = new System.Windows.Forms.Label();
			Label16 = new System.Windows.Forms.Label();
			Label19 = new System.Windows.Forms.Label();
			Label6 = new System.Windows.Forms.Label();
			lblFractionalMessage = new System.Windows.Forms.Label();
			_tab_callback_TabPage7 = new System.Windows.Forms.TabPage();
			chk_Account_Rep_Wanted = new System.Windows.Forms.CheckBox();
			txt_Tot_CompanyWanted = new System.Windows.Forms.TextBox();
			txt_Tot_Wanted = new System.Windows.Forms.TextBox();
			cmd_Refresh_Wanted = new System.Windows.Forms.Button();
			grd_WantedList = new UpgradeHelpers.DataGridViewFlex(components);
			_lbl_gen_16 = new System.Windows.Forms.Label();
			_lbl_gen_15 = new System.Windows.Forms.Label();
			_tab_callback_TabPage8 = new System.Windows.Forms.TabPage();
			cmdRefreshAvailAircraft = new System.Windows.Forms.Button();
			pnl_AvailableAircraft = new System.Windows.Forms.Panel();
			grd_AvailableAircraft = new UpgradeHelpers.DataGridViewFlex(components);
			lblAvailACTotal = new System.Windows.Forms.Label();
			_tab_callback_TabPage9 = new System.Windows.Forms.TabPage();
			_chk_action_list_13 = new System.Windows.Forms.CheckBox();
			_cmd_export_docs_2 = new System.Windows.Forms.Button();
			_chk_action_list_12 = new System.Windows.Forms.CheckBox();
			_cmd_export_docs_0 = new System.Windows.Forms.Button();
			chk_compact = new System.Windows.Forms.CheckBox();
			cmbDocType = new System.Windows.Forms.ComboBox();
			cmbDocInProcsClass = new System.Windows.Forms.ComboBox();
			chk_AllDocuments = new System.Windows.Forms.CheckBox();
			cmd_DocsInProcessRefresh = new System.Windows.Forms.Button();
			chkAttachedDocs = new System.Windows.Forms.CheckBox();
			chkResponses = new System.Windows.Forms.CheckBox();
			grd_DocumentLog = new UpgradeHelpers.DataGridViewFlex(components);
			_lbl_gen_36 = new System.Windows.Forms.Label();
			lblClass = new System.Windows.Forms.Label();
			lbl_Documents_In_Process = new System.Windows.Forms.Label();
			_tab_callback_TabPage10 = new System.Windows.Forms.TabPage();
			chk_EventsToday = new System.Windows.Forms.CheckBox();
			lstEventCat = new System.Windows.Forms.ListBox();
			cmdFillEvents = new System.Windows.Forms.Button();
			fraDateTimeRange = new System.Windows.Forms.GroupBox();
			txtEventDateTo = new System.Windows.Forms.TextBox();
			txtEventDateFrom = new System.Windows.Forms.TextBox();
			_lbl_gen_17 = new System.Windows.Forms.Label();
			_lbl_gen_18 = new System.Windows.Forms.Label();
			grdPriorityEvents = new UpgradeHelpers.DataGridViewFlex(components);
			lblTotalPEventRecordsFound = new System.Windows.Forms.Label();
			lblPEventStop = new System.Windows.Forms.Label();
			_tab_callback_TabPage11 = new System.Windows.Forms.TabPage();
			Label26 = new System.Windows.Forms.Label();
			txt_total_abi_callbacks = new System.Windows.Forms.TextBox();
			_tab_callback_TabPage12 = new System.Windows.Forms.TabPage();
			lbl_airbp_remarks = new System.Windows.Forms.Label();
			pnl_bottom_totals = new System.Windows.Forms.Panel();
			pnl_bottom_totals2 = new System.Windows.Forms.Panel();
			_tab_callback_TabPage13 = new System.Windows.Forms.TabPage();
			chkAllYachtCallbackRecords = new System.Windows.Forms.CheckBox();
			cmd_Refresh_Yacht_Callback_List = new System.Windows.Forms.Button();
			frm_Yacht_Callback = new System.Windows.Forms.GroupBox();
			cmbYachtCallbackType = new System.Windows.Forms.ComboBox();
			txt_TotalCallbacks_Yachts = new System.Windows.Forms.TextBox();
			txt_TotalYachts = new System.Windows.Forms.TextBox();
			grd_Yacht_Callbacks = new UpgradeHelpers.DataGridViewFlex(components);
			_lbl_gen_49 = new System.Windows.Forms.Label();
			_lbl_gen_47 = new System.Windows.Forms.Label();
			_lbl_gen_46 = new System.Windows.Forms.Label();
			_lbl_gen_45 = new System.Windows.Forms.Label();
			_lbl_gen_44 = new System.Windows.Forms.Label();
			_lbl_gen_43 = new System.Windows.Forms.Label();
			_lbl_gen_42 = new System.Windows.Forms.Label();
			_lbl_gen_41 = new System.Windows.Forms.Label();
			_lbl_gen_35 = new System.Windows.Forms.Label();
			lblYTCallbackStop = new System.Windows.Forms.Label();
			_lbl_gen_33 = new System.Windows.Forms.Label();
			_lbl_gen_31 = new System.Windows.Forms.Label();
			lbl_Yacht_Callback_Message = new System.Windows.Forms.Label();
			_tab_callback_TabPage14 = new System.Windows.Forms.TabPage();
			lblOwrOprStop = new System.Windows.Forms.Label();
			lblOwrOprRecords = new System.Windows.Forms.Label();
			fgrdOwrOpr = new UpgradeHelpers.DataGridViewFlex(components);
			cmdOwrOprRefresh = new System.Windows.Forms.Button();
			_tab_callback_TabPage15 = new System.Windows.Forms.TabPage();
			cmbFindDupReports = new System.Windows.Forms.ComboBox();
			cmdFindDupsRefresh = new System.Windows.Forms.Button();
			fgrdFindDups = new UpgradeHelpers.DataGridViewFlex(components);
			_lbl_gen_32 = new System.Windows.Forms.Label();
			lblFindDupsStop = new System.Windows.Forms.Label();
			lblFindDupsRecords = new System.Windows.Forms.Label();
			_tab_callback_TabPage16 = new System.Windows.Forms.TabPage();
			lblFindACNoBaseStop = new System.Windows.Forms.Label();
			lblFindACNoBaseRecords = new System.Windows.Forms.Label();
			fgrdFindACNoBase = new UpgradeHelpers.DataGridViewFlex(components);
			cmdFindACNoBaseRefresh = new System.Windows.Forms.Button();
			_chk_action_list_8 = new System.Windows.Forms.CheckBox();
			_tab_callback_TabPage17 = new System.Windows.Forms.TabPage();
			_chk_action_list_7 = new System.Windows.Forms.CheckBox();
			cmdFindACNoCHPRefresh = new System.Windows.Forms.Button();
			fgrdFindACNoCHP = new UpgradeHelpers.DataGridViewFlex(components);
			lblFindACNoCHPRecords = new System.Windows.Forms.Label();
			lblFindACNoCHPStop = new System.Windows.Forms.Label();
			_tab_callback_TabPage18 = new System.Windows.Forms.TabPage();
			chk_new_submitted = new System.Windows.Forms.CheckBox();
			cmdCSDChangeAcctRep = new System.Windows.Forms.Button();
			cmbCustSubAcctRep = new System.Windows.Forms.ComboBox();
			cmd_in_progress = new System.Windows.Forms.Button();
			opSubmitBoth = new System.Windows.Forms.RadioButton();
			opSubmitCompany = new System.Windows.Forms.RadioButton();
			opSubmitAircraft = new System.Windows.Forms.RadioButton();
			cmdSubDataEMail = new System.Windows.Forms.Button();
			chkCustSubDataIncludeCompleted = new System.Windows.Forms.CheckBox();
			cmdFindCustSubDataRefresh = new System.Windows.Forms.Button();
			fgrdFindCustSubData = new UpgradeHelpers.DataGridViewFlex(components);
			_lbl_gen_39 = new System.Windows.Forms.Label();
			lblFindCustSubDataStop = new System.Windows.Forms.Label();
			lblFindCustSubDataRecords = new System.Windows.Forms.Label();
			_tab_callback_TabPage19 = new System.Windows.Forms.TabPage();
			chkSortDesc = new System.Windows.Forms.CheckBox();
			cmdResearchReportsExport = new System.Windows.Forms.Button();
			cmbFindResearchReports = new System.Windows.Forms.ComboBox();
			cmdResearchReportsRefresh = new System.Windows.Forms.Button();
			fgrdFindResearchReports = new UpgradeHelpers.DataGridViewFlex(components);
			lblFindResearchReports = new System.Windows.Forms.Label();
			_lbl_gen_38 = new System.Windows.Forms.Label();
			lblFindResearchReportsStop = new System.Windows.Forms.Label();
			_tab_callback_TabPage20 = new System.Windows.Forms.TabPage();
			_tab_callback_TabPage21 = new System.Windows.Forms.TabPage();
			_lbl_gen_52 = new System.Windows.Forms.Label();
			_lbl_gen_53 = new System.Windows.Forms.Label();
			grd_issues = new UpgradeHelpers.DataGridViewFlex(components);
			_cmd_refresh_4 = new System.Windows.Forms.Button();
			_cbo_multi_0 = new System.Windows.Forms.ComboBox();
			_cbo_multi_1 = new System.Windows.Forms.ComboBox();
			_tab_callback_TabPage22 = new System.Windows.Forms.TabPage();
			_cbo_multi_2 = new System.Windows.Forms.ComboBox();
			_cmd_refresh_5 = new System.Windows.Forms.Button();
			grd_salesforce = new UpgradeHelpers.DataGridViewFlex(components);
			_lbl_gen_55 = new System.Windows.Forms.Label();
			_lbl_gen_54 = new System.Windows.Forms.Label();
			txt_ListStartDate = new System.Windows.Forms.TextBox();
			cbo_TimeScale = new System.Windows.Forms.ComboBox();
			cbo_Timezones = new System.Windows.Forms.ComboBox();
			cmbProductType = new System.Windows.Forms.ComboBox();
			cmd_Update_Callback_Dates = new System.Windows.Forms.Button();
			cmd_New_Avail = new System.Windows.Forms.Button();
			cmd_Fix_Fract_Owners = new System.Windows.Forms.Button();
			txt_Callback_Date = new System.Windows.Forms.TextBox();
			Adodc_CallBack = new UpgradeHelpers.DB.ADO.ADODataControlHelper();
			cmdStop = new System.Windows.Forms.Button();
			pnl_lstcompany = new System.Windows.Forms.Panel();
			cmd_contacts_phone = new System.Windows.Forms.Button();
			cmd_ClearReassign = new System.Windows.Forms.Button();
			txt_next_confirm_date = new System.Windows.Forms.TextBox();
			cmdFindLikeCompany = new System.Windows.Forms.Button();
			cmdConfirmExclusive = new System.Windows.Forms.Button();
			lstCompany = new System.Windows.Forms.ListBox();
			_lbl_gen_5 = new System.Windows.Forms.Label();
			cal_Callback = new System.Windows.Forms.MonthCalendar();
			cbo_account_id = new System.Windows.Forms.ComboBox();
			tbr_AL_ToolBar = new System.Windows.Forms.ToolStrip();
			tbr_AL_ToolBar_Buttons_Button1 = new System.Windows.Forms.ToolStripSeparator();
			tbr_AL_ToolBar_Buttons_Button2 = new System.Windows.Forms.ToolStripButton();
			tbr_AL_ToolBar_Buttons_Button3 = new System.Windows.Forms.ToolStripSeparator();
			tbr_AL_ToolBar_Buttons_Button4 = new System.Windows.Forms.ToolStripButton();
			tbr_AL_ToolBar_Buttons_Button5 = new System.Windows.Forms.ToolStripSeparator();
			tbr_AL_ToolBar_Buttons_Button6 = new System.Windows.Forms.ToolStripButton();
			tbr_AL_ToolBar_Buttons_Button7 = new System.Windows.Forms.ToolStripSeparator();
			tbr_AL_ToolBar_Buttons_Button8 = new System.Windows.Forms.ToolStripButton();
			Label3 = new System.Windows.Forms.Label();
			SSPanel1 = new System.Windows.Forms.Panel();
			Text6 = new System.Windows.Forms.TextBox();
			Text5 = new System.Windows.Forms.TextBox();
			Text3 = new System.Windows.Forms.TextBox();
			Text2 = new System.Windows.Forms.TextBox();
			Text1 = new System.Windows.Forms.TextBox();
			Label40 = new System.Windows.Forms.Label();
			_Label36_0 = new System.Windows.Forms.Label();
			_Label35_0 = new System.Windows.Forms.Label();
			_Label37_0 = new System.Windows.Forms.Label();
			Label39 = new System.Windows.Forms.Label();
			text_airbp_remarks = new System.Windows.Forms.TextBox();
			pnl_Wait = new System.Windows.Forms.Panel();
			lblTotRecordFound = new System.Windows.Forms.Label();
			Label7 = new System.Windows.Forms.Label();
			lbl_Test_omg = new System.Windows.Forms.Label();
			_lbl_gen_57 = new System.Windows.Forms.Label();
			_lbl_gen_48 = new System.Windows.Forms.Label();
			_lbl_gen_4 = new System.Windows.Forms.Label();
			_lbl_gen_0 = new System.Windows.Forms.Label();
			_lbl_gen_3 = new System.Windows.Forms.Label();
			Label42 = new System.Windows.Forms.Label();
			Label47 = new System.Windows.Forms.Label();
			Label46 = new System.Windows.Forms.Label();
			_lbl_gen_6 = new System.Windows.Forms.Label();
			_lbl_gen_2 = new System.Windows.Forms.Label();
			_lbl_gen_1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize) Adodc_CallBack).BeginInit();
			tab_callback.SuspendLayout();
			_tab_callback_TabPage0.SuspendLayout();
			pnl_Callbacks.SuspendLayout();
			frmCustomers.SuspendLayout();
			_tab_callback_TabPage1.SuspendLayout();
			pnl_reassignemnt.SuspendLayout();
			_tab_callback_TabPage2.SuspendLayout();
			_tab_callback_TabPage3.SuspendLayout();
			pnl_Exclusives.SuspendLayout();
			pnl_primary.SuspendLayout();
			_tab_callback_TabPage4.SuspendLayout();
			pnl_Hot_Items.SuspendLayout();
			_tab_callback_TabPage5.SuspendLayout();
			_tab_callback_TabPage6.SuspendLayout();
			pnl_Fractional.SuspendLayout();
			pnl_fractional_display.SuspendLayout();
			pnlFractionalPercentagesBad.SuspendLayout();
			_tab_callback_TabPage7.SuspendLayout();
			_tab_callback_TabPage8.SuspendLayout();
			pnl_AvailableAircraft.SuspendLayout();
			_tab_callback_TabPage9.SuspendLayout();
			_tab_callback_TabPage10.SuspendLayout();
			fraDateTimeRange.SuspendLayout();
			_tab_callback_TabPage11.SuspendLayout();
			_tab_callback_TabPage12.SuspendLayout();
			_tab_callback_TabPage13.SuspendLayout();
			frm_Yacht_Callback.SuspendLayout();
			_tab_callback_TabPage14.SuspendLayout();
			_tab_callback_TabPage15.SuspendLayout();
			_tab_callback_TabPage16.SuspendLayout();
			_tab_callback_TabPage17.SuspendLayout();
			_tab_callback_TabPage18.SuspendLayout();
			_tab_callback_TabPage19.SuspendLayout();
			_tab_callback_TabPage21.SuspendLayout();
			_tab_callback_TabPage22.SuspendLayout();
			pnl_lstcompany.SuspendLayout();
			tbr_AL_ToolBar.SuspendLayout();
			SSPanel1.SuspendLayout();
			pnl_Wait.SuspendLayout();
			SuspendLayout();
			//Ctx_mnuEdit
			Ctx_mnuEdit = new System.Windows.Forms.ContextMenuStrip(components);
			Ctx_mnuEdit.Size = new System.Drawing.Size(153, 26);
			Ctx_mnuEdit.Opening += new System.ComponentModel.CancelEventHandler(Ctx_mnuEdit_Opening);
			Ctx_mnuEdit.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(Ctx_mnuEdit_Closed);
			//Ctx_mnuRightClickCallback
			Ctx_mnuRightClickCallback = new System.Windows.Forms.ContextMenuStrip(components);
			Ctx_mnuRightClickCallback.Size = new System.Drawing.Size(153, 26);
			Ctx_mnuRightClickCallback.Opening += new System.ComponentModel.CancelEventHandler(Ctx_mnuRightClickCallback_Opening);
			Ctx_mnuRightClickCallback.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(Ctx_mnuRightClickCallback_Closed);
			listBoxComboBoxHelper1 = new UpgradeHelpers.Gui.Controls.ListControlHelper(components);
			((System.ComponentModel.ISupportInitialize) listBoxComboBoxHelper1).BeginInit();
			listBoxHelper1 = new UpgradeHelpers.Gui.Controls.ListBoxHelper(components);
			optionButtonHelper1 = new UpgradeHelpers.Gui.Controls.OptionButtonHelper(components);
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
			((System.ComponentModel.ISupportInitialize) grd_Callbacks).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_NewAssignments).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_CompConfirm).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_Exclusives).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_Hot_Items).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_expired_leases).BeginInit();
			((System.ComponentModel.ISupportInitialize) grdFractional).BeginInit();
			((System.ComponentModel.ISupportInitialize) grdBadFractions).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_WantedList).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_AvailableAircraft).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_DocumentLog).BeginInit();
			((System.ComponentModel.ISupportInitialize) grdPriorityEvents).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_Yacht_Callbacks).BeginInit();
			((System.ComponentModel.ISupportInitialize) fgrdOwrOpr).BeginInit();
			((System.ComponentModel.ISupportInitialize) fgrdFindDups).BeginInit();
			((System.ComponentModel.ISupportInitialize) fgrdFindACNoBase).BeginInit();
			((System.ComponentModel.ISupportInitialize) fgrdFindACNoCHP).BeginInit();
			((System.ComponentModel.ISupportInitialize) fgrdFindCustSubData).BeginInit();
			((System.ComponentModel.ISupportInitialize) fgrdFindResearchReports).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_issues).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_salesforce).BeginInit();
			// 
			// MainMenu1
			// 
			MainMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[]{mnuFile, mnuTools, mnuView, mnuEdit, mnuRightClickCallback});
			// 
			// mnuFile
			// 
			mnuFile.Available = true;
			mnuFile.Checked = false;
			mnuFile.Enabled = true;
			mnuFile.Name = "mnuFile";
			mnuFile.Text = "&File";
			mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]{mnuFileClose, mnuFileLogout});
			// 
			// mnuFileClose
			// 
			mnuFileClose.Available = true;
			mnuFileClose.Checked = false;
			mnuFileClose.Enabled = true;
			mnuFileClose.Name = "mnuFileClose";
			mnuFileClose.Text = "Close";
			mnuFileClose.Click += new System.EventHandler(mnuFileClose_Click);
			// 
			// mnuFileLogout
			// 
			mnuFileLogout.Available = true;
			mnuFileLogout.Checked = false;
			mnuFileLogout.Enabled = true;
			mnuFileLogout.Name = "mnuFileLogout";
			mnuFileLogout.Text = "Logout";
			mnuFileLogout.Click += new System.EventHandler(mnuFileLogout_Click);
			// 
			// mnuTools
			// 
			mnuTools.Available = true;
			mnuTools.Checked = false;
			mnuTools.Enabled = true;
			mnuTools.Name = "mnuTools";
			mnuTools.Text = "&Tools";
			mnuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]{mnuNewPubsAvailable, mnuCanRegistry, mnuActionListShowUserHistory});
			// 
			// mnuNewPubsAvailable
			// 
			mnuNewPubsAvailable.Available = true;
			mnuNewPubsAvailable.Checked = false;
			mnuNewPubsAvailable.Enabled = true;
			mnuNewPubsAvailable.Name = "mnuNewPubsAvailable";
			mnuNewPubsAvailable.Text = "&New Tasks Available";
			mnuNewPubsAvailable.Click += new System.EventHandler(mnuNewPubsAvailable_Click);
			// 
			// mnuCanRegistry
			// 
			mnuCanRegistry.Available = true;
			mnuCanRegistry.Checked = false;
			mnuCanRegistry.Enabled = true;
			mnuCanRegistry.Name = "mnuCanRegistry";
			mnuCanRegistry.Text = "&Canadian Registry";
			mnuCanRegistry.Click += new System.EventHandler(mnuCanRegistry_Click);
			// 
			// mnuActionListShowUserHistory
			// 
			mnuActionListShowUserHistory.Available = true;
			mnuActionListShowUserHistory.Checked = false;
			mnuActionListShowUserHistory.Enabled = true;
			mnuActionListShowUserHistory.Name = "mnuActionListShowUserHistory";
			mnuActionListShowUserHistory.Text = "Show User History";
			mnuActionListShowUserHistory.Click += new System.EventHandler(mnuActionListShowUserHistory_Click);
			// 
			// mnuView
			// 
			mnuView.Available = true;
			mnuView.Checked = false;
			mnuView.Enabled = true;
			mnuView.Name = "mnuView";
			mnuView.Text = "&View";
			mnuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]{mnuViewAcctRepMasterList, mnuViewVerifyStatusReport});
			// 
			// mnuViewAcctRepMasterList
			// 
			mnuViewAcctRepMasterList.Available = true;
			mnuViewAcctRepMasterList.Checked = false;
			mnuViewAcctRepMasterList.Enabled = true;
			mnuViewAcctRepMasterList.Name = "mnuViewAcctRepMasterList";
			mnuViewAcctRepMasterList.Text = "&Account Rep Master List";
			mnuViewAcctRepMasterList.Click += new System.EventHandler(mnuViewAcctRepMasterList_Click);
			// 
			// mnuViewVerifyStatusReport
			// 
			mnuViewVerifyStatusReport.Available = true;
			mnuViewVerifyStatusReport.Checked = false;
			mnuViewVerifyStatusReport.Enabled = true;
			mnuViewVerifyStatusReport.Name = "mnuViewVerifyStatusReport";
			mnuViewVerifyStatusReport.Text = "&Verify Status Report";
			mnuViewVerifyStatusReport.Click += new System.EventHandler(mnuViewVerifyStatusReport_Click);
			// 
			// mnuEdit
			// 
			mnuEdit.Available = true;
			mnuEdit.Checked = false;
			mnuEdit.Enabled = true;
			mnuEdit.Name = "mnuEdit";
			mnuEdit.Text = "&Edit";
			mnuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]{mnuCopyFindDupsGrid, mnuEditCompletedCustSubData});
			// 
			// mnuCopyFindDupsGrid
			// 
			mnuCopyFindDupsGrid.Available = true;
			mnuCopyFindDupsGrid.Checked = false;
			mnuCopyFindDupsGrid.Enabled = true;
			mnuCopyFindDupsGrid.Name = "mnuCopyFindDupsGrid";
			mnuCopyFindDupsGrid.Text = "&Copy";
			mnuCopyFindDupsGrid.Click += new System.EventHandler(mnuCopyFindDupsGrid_Click);
			// 
			// mnuEditCompletedCustSubData
			// 
			mnuEditCompletedCustSubData.Available = true;
			mnuEditCompletedCustSubData.Checked = false;
			mnuEditCompletedCustSubData.Enabled = true;
			mnuEditCompletedCustSubData.Name = "mnuEditCompletedCustSubData";
			mnuEditCompletedCustSubData.Text = "Completed";
			mnuEditCompletedCustSubData.Click += new System.EventHandler(mnuEditCompletedCustSubData_Click);
			// 
			// mnuRightClickCallback
			// 
			mnuRightClickCallback.Available = false;
			mnuRightClickCallback.Checked = false;
			mnuRightClickCallback.Enabled = true;
			mnuRightClickCallback.Name = "mnuRightClickCallback";
			mnuRightClickCallback.Text = "Right Click Callback";
			mnuRightClickCallback.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]{mnuChangeDocType});
			// 
			// mnuChangeDocType
			// 
			mnuChangeDocType.Available = true;
			mnuChangeDocType.Checked = false;
			mnuChangeDocType.Enabled = true;
			mnuChangeDocType.Name = "mnuChangeDocType";
			mnuChangeDocType.Text = "Change Document Type";
			mnuChangeDocType.Click += new System.EventHandler(mnuChangeDocType_Click);
			// 
			// chk_alt_rep
			// 
			chk_alt_rep.AllowDrop = true;
			chk_alt_rep.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_alt_rep.BackColor = System.Drawing.SystemColors.Control;
			chk_alt_rep.CausesValidation = true;
			chk_alt_rep.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_alt_rep.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_alt_rep.Enabled = true;
			chk_alt_rep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_alt_rep.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_alt_rep.Location = new System.Drawing.Point(112, 184);
			chk_alt_rep.Name = "chk_alt_rep";
			chk_alt_rep.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_alt_rep.Size = new System.Drawing.Size(81, 17);
			chk_alt_rep.TabIndex = 266;
			chk_alt_rep.TabStop = true;
			chk_alt_rep.Text = "Use Alt Rep";
			chk_alt_rep.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_alt_rep.Visible = true;
			chk_alt_rep.CheckStateChanged += new System.EventHandler(chk_alt_rep_CheckStateChanged);
			// 
			// cmdNewCustSubData
			// 
			cmdNewCustSubData.AllowDrop = true;
			cmdNewCustSubData.BackColor = System.Drawing.SystemColors.Control;
			cmdNewCustSubData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdNewCustSubData.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdNewCustSubData.Location = new System.Drawing.Point(10, 106);
			cmdNewCustSubData.Name = "cmdNewCustSubData";
			cmdNewCustSubData.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdNewCustSubData.Size = new System.Drawing.Size(132, 22);
			cmdNewCustSubData.TabIndex = 200;
			cmdNewCustSubData.Tag = "No";
			cmdNewCustSubData.Text = "New Submitted Data";
			cmdNewCustSubData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdNewCustSubData.UseVisualStyleBackColor = false;
			cmdNewCustSubData.Visible = false;
			cmdNewCustSubData.Click += new System.EventHandler(cmdNewCustSubData_Click);
			// 
			// tab_callback
			// 
			tab_callback.Alignment = System.Windows.Forms.TabAlignment.Top;
			tab_callback.AllowDrop = true;
			tab_callback.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
			tab_callback.Controls.Add(_tab_callback_TabPage0);
			tab_callback.Controls.Add(_tab_callback_TabPage1);
			tab_callback.Controls.Add(_tab_callback_TabPage2);
			tab_callback.Controls.Add(_tab_callback_TabPage3);
			tab_callback.Controls.Add(_tab_callback_TabPage4);
			tab_callback.Controls.Add(_tab_callback_TabPage5);
			tab_callback.Controls.Add(_tab_callback_TabPage6);
			tab_callback.Controls.Add(_tab_callback_TabPage7);
			tab_callback.Controls.Add(_tab_callback_TabPage8);
			tab_callback.Controls.Add(_tab_callback_TabPage9);
			tab_callback.Controls.Add(_tab_callback_TabPage10);
			tab_callback.Controls.Add(_tab_callback_TabPage11);
			tab_callback.Controls.Add(_tab_callback_TabPage12);
			tab_callback.Controls.Add(_tab_callback_TabPage13);
			tab_callback.Controls.Add(_tab_callback_TabPage14);
			tab_callback.Controls.Add(_tab_callback_TabPage15);
			tab_callback.Controls.Add(_tab_callback_TabPage16);
			tab_callback.Controls.Add(_tab_callback_TabPage17);
			tab_callback.Controls.Add(_tab_callback_TabPage18);
			tab_callback.Controls.Add(_tab_callback_TabPage19);
			tab_callback.Controls.Add(_tab_callback_TabPage20);
			tab_callback.Controls.Add(_tab_callback_TabPage21);
			tab_callback.Controls.Add(_tab_callback_TabPage22);
			tab_callback.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			tab_callback.ItemSize = new System.Drawing.Size(82, 18);
			tab_callback.Location = new System.Drawing.Point(8, 208);
			tab_callback.Multiline = true;
			tab_callback.Name = "tab_callback";
			tab_callback.Size = new System.Drawing.Size(1001, 494);
			tab_callback.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			tab_callback.TabIndex = 16;
			tab_callback.SelectedIndexChanged += new System.EventHandler(tab_callback_SelectedIndexChanged);
			// 
			// _tab_callback_TabPage0
			// 
			_tab_callback_TabPage0.Controls.Add(lbl_Message);
			_tab_callback_TabPage0.Controls.Add(pnl_Callbacks);
			_tab_callback_TabPage0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_callback_TabPage0.Text = "Primary CB";
			// 
			// lbl_Message
			// 
			lbl_Message.AllowDrop = true;
			lbl_Message.BackColor = System.Drawing.Color.Transparent;
			lbl_Message.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_Message.Font = new System.Drawing.Font("Microsoft Sans Serif", 24f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_Message.ForeColor = System.Drawing.Color.Maroon;
			lbl_Message.Location = new System.Drawing.Point(41, 362);
			lbl_Message.MinimumSize = new System.Drawing.Size(617, 89);
			lbl_Message.Name = "lbl_Message";
			lbl_Message.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_Message.Size = new System.Drawing.Size(617, 89);
			lbl_Message.TabIndex = 133;
			lbl_Message.Text = "Message";
			lbl_Message.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// pnl_Callbacks
			// 
			pnl_Callbacks.AllowDrop = true;
			pnl_Callbacks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Callbacks.Controls.Add(cbo_primary_country);
			pnl_Callbacks.Controls.Add(_chk_action_list_6);
			pnl_Callbacks.Controls.Add(_chk_action_list_5);
			pnl_Callbacks.Controls.Add(_chk_action_list_4);
			pnl_Callbacks.Controls.Add(_chk_action_list_3);
			pnl_Callbacks.Controls.Add(_chk_action_list_2);
			pnl_Callbacks.Controls.Add(_chk_action_list_1);
			pnl_Callbacks.Controls.Add(_chk_action_list_0);
			pnl_Callbacks.Controls.Add(frmCustomers);
			pnl_Callbacks.Controls.Add(cmdRefresh);
			pnl_Callbacks.Controls.Add(Text4);
			pnl_Callbacks.Controls.Add(txt_TotalCallbacks);
			pnl_Callbacks.Controls.Add(txt_TotalAircraft);
			pnl_Callbacks.Controls.Add(cmdSelDClick);
			pnl_Callbacks.Controls.Add(grd_Callbacks);
			pnl_Callbacks.Controls.Add(_lbl_gen_40);
			pnl_Callbacks.Controls.Add(Label24);
			pnl_Callbacks.Controls.Add(_lbl_gen_8);
			pnl_Callbacks.Controls.Add(_lbl_gen_7);
			pnl_Callbacks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Callbacks.Location = new System.Drawing.Point(14, 8);
			pnl_Callbacks.Name = "pnl_Callbacks";
			pnl_Callbacks.Size = new System.Drawing.Size(967, 435);
			pnl_Callbacks.TabIndex = 20;
			pnl_Callbacks.MouseMove += new System.Windows.Forms.MouseEventHandler(pnl_Callbacks_MouseMove);
			// 
			// cbo_primary_country
			// 
			cbo_primary_country.AllowDrop = true;
			cbo_primary_country.BackColor = System.Drawing.SystemColors.Window;
			cbo_primary_country.CausesValidation = true;
			cbo_primary_country.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_primary_country.Enabled = true;
			cbo_primary_country.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_primary_country.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_primary_country.IntegralHeight = true;
			cbo_primary_country.Location = new System.Drawing.Point(856, 403);
			cbo_primary_country.Name = "cbo_primary_country";
			cbo_primary_country.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_primary_country.Size = new System.Drawing.Size(105, 21);
			cbo_primary_country.Sorted = false;
			cbo_primary_country.TabIndex = 240;
			cbo_primary_country.TabStop = true;
			cbo_primary_country.Text = "All";
			cbo_primary_country.Visible = true;
			// 
			// _chk_action_list_6
			// 
			_chk_action_list_6.AllowDrop = true;
			_chk_action_list_6.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_action_list_6.BackColor = System.Drawing.SystemColors.Control;
			_chk_action_list_6.CausesValidation = true;
			_chk_action_list_6.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_action_list_6.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_action_list_6.Enabled = true;
			_chk_action_list_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_action_list_6.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_action_list_6.Location = new System.Drawing.Point(750, 10);
			_chk_action_list_6.Name = "_chk_action_list_6";
			_chk_action_list_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_action_list_6.Size = new System.Drawing.Size(91, 13);
			_chk_action_list_6.TabIndex = 30;
			_chk_action_list_6.TabStop = true;
			_chk_action_list_6.Text = "All Companies";
			_chk_action_list_6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_action_list_6.Visible = true;
			_chk_action_list_6.CheckStateChanged += new System.EventHandler(chk_action_list_CheckStateChanged);
			// 
			// _chk_action_list_5
			// 
			_chk_action_list_5.AllowDrop = true;
			_chk_action_list_5.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_action_list_5.BackColor = System.Drawing.SystemColors.Control;
			_chk_action_list_5.CausesValidation = true;
			_chk_action_list_5.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_action_list_5.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_action_list_5.Enabled = true;
			_chk_action_list_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_action_list_5.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_action_list_5.Location = new System.Drawing.Point(432, 4);
			_chk_action_list_5.Name = "_chk_action_list_5";
			_chk_action_list_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_action_list_5.Size = new System.Drawing.Size(101, 13);
			_chk_action_list_5.TabIndex = 24;
			_chk_action_list_5.TabStop = true;
			_chk_action_list_5.Text = "Highlight Class A";
			_chk_action_list_5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_action_list_5.Visible = true;
			_chk_action_list_5.CheckStateChanged += new System.EventHandler(chk_action_list_CheckStateChanged);
			// 
			// _chk_action_list_4
			// 
			_chk_action_list_4.AllowDrop = true;
			_chk_action_list_4.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_action_list_4.BackColor = System.Drawing.SystemColors.Control;
			_chk_action_list_4.CausesValidation = true;
			_chk_action_list_4.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_action_list_4.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_action_list_4.Enabled = true;
			_chk_action_list_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_action_list_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_action_list_4.Location = new System.Drawing.Point(244, 4);
			_chk_action_list_4.Name = "_chk_action_list_4";
			_chk_action_list_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_action_list_4.Size = new System.Drawing.Size(185, 13);
			_chk_action_list_4.TabIndex = 23;
			_chk_action_list_4.TabStop = true;
			_chk_action_list_4.Text = "View Master List (Ignore Calendar)";
			_chk_action_list_4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_action_list_4.Visible = true;
			_chk_action_list_4.CheckStateChanged += new System.EventHandler(chk_action_list_CheckStateChanged);
			// 
			// _chk_action_list_3
			// 
			_chk_action_list_3.AllowDrop = true;
			_chk_action_list_3.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_action_list_3.BackColor = System.Drawing.SystemColors.Control;
			_chk_action_list_3.CausesValidation = true;
			_chk_action_list_3.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_action_list_3.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_action_list_3.Enabled = true;
			_chk_action_list_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_action_list_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_action_list_3.Location = new System.Drawing.Point(11, 4);
			_chk_action_list_3.Name = "_chk_action_list_3";
			_chk_action_list_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_action_list_3.Size = new System.Drawing.Size(219, 13);
			_chk_action_list_3.TabIndex = 22;
			_chk_action_list_3.TabStop = true;
			_chk_action_list_3.Text = "Only Show Callbacks for Available Aircraft";
			_chk_action_list_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_action_list_3.Visible = true;
			_chk_action_list_3.CheckStateChanged += new System.EventHandler(chk_action_list_CheckStateChanged);
			// 
			// _chk_action_list_2
			// 
			_chk_action_list_2.AllowDrop = true;
			_chk_action_list_2.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_action_list_2.BackColor = System.Drawing.SystemColors.Control;
			_chk_action_list_2.CausesValidation = true;
			_chk_action_list_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_action_list_2.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_action_list_2.Enabled = true;
			_chk_action_list_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_action_list_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_action_list_2.Location = new System.Drawing.Point(136, 24);
			_chk_action_list_2.Name = "_chk_action_list_2";
			_chk_action_list_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_action_list_2.Size = new System.Drawing.Size(105, 13);
			_chk_action_list_2.TabIndex = 25;
			_chk_action_list_2.TabStop = true;
			_chk_action_list_2.Text = "Hide IQ Declined";
			_chk_action_list_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_action_list_2.Visible = true;
			_chk_action_list_2.CheckStateChanged += new System.EventHandler(chk_action_list_CheckStateChanged);
			// 
			// _chk_action_list_1
			// 
			_chk_action_list_1.AllowDrop = true;
			_chk_action_list_1.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_action_list_1.BackColor = System.Drawing.SystemColors.Control;
			_chk_action_list_1.CausesValidation = true;
			_chk_action_list_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_action_list_1.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_action_list_1.Enabled = true;
			_chk_action_list_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_action_list_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_action_list_1.Location = new System.Drawing.Point(680, 408);
			_chk_action_list_1.Name = "_chk_action_list_1";
			_chk_action_list_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_action_list_1.Size = new System.Drawing.Size(121, 13);
			_chk_action_list_1.TabIndex = 235;
			_chk_action_list_1.TabStop = true;
			_chk_action_list_1.Text = "Exclude Reassigns";
			_chk_action_list_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_action_list_1.Visible = true;
			_chk_action_list_1.CheckStateChanged += new System.EventHandler(chk_action_list_CheckStateChanged);
			// 
			// _chk_action_list_0
			// 
			_chk_action_list_0.AllowDrop = true;
			_chk_action_list_0.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_action_list_0.BackColor = System.Drawing.SystemColors.Control;
			_chk_action_list_0.CausesValidation = true;
			_chk_action_list_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_action_list_0.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_action_list_0.Enabled = true;
			_chk_action_list_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_action_list_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_action_list_0.Location = new System.Drawing.Point(11, 24);
			_chk_action_list_0.Name = "_chk_action_list_0";
			_chk_action_list_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_action_list_0.Size = new System.Drawing.Size(121, 13);
			_chk_action_list_0.TabIndex = 26;
			_chk_action_list_0.TabStop = true;
			_chk_action_list_0.Text = "Show IQ Completed";
			_chk_action_list_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_action_list_0.Visible = true;
			_chk_action_list_0.CheckStateChanged += new System.EventHandler(chk_action_list_CheckStateChanged);
			// 
			// frmCustomers
			// 
			frmCustomers.AllowDrop = true;
			frmCustomers.BackColor = System.Drawing.SystemColors.Control;
			frmCustomers.Controls.Add(_optSearchCust_2);
			frmCustomers.Controls.Add(_optSearchCust_1);
			frmCustomers.Controls.Add(_optSearchCust_0);
			frmCustomers.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmCustomers.Enabled = true;
			frmCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmCustomers.ForeColor = System.Drawing.SystemColors.ControlText;
			frmCustomers.Location = new System.Drawing.Point(536, 0);
			frmCustomers.Name = "frmCustomers";
			frmCustomers.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmCustomers.Size = new System.Drawing.Size(173, 31);
			frmCustomers.TabIndex = 206;
			frmCustomers.Text = "Customers";
			frmCustomers.Visible = true;
			// 
			// _optSearchCust_2
			// 
			_optSearchCust_2.AllowDrop = true;
			_optSearchCust_2.BackColor = System.Drawing.SystemColors.Control;
			_optSearchCust_2.CausesValidation = true;
			_optSearchCust_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_optSearchCust_2.Checked = false;
			_optSearchCust_2.Enabled = true;
			_optSearchCust_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_optSearchCust_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_optSearchCust_2.Location = new System.Drawing.Point(122, 12);
			_optSearchCust_2.Name = "_optSearchCust_2";
			_optSearchCust_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_optSearchCust_2.Size = new System.Drawing.Size(45, 13);
			_optSearchCust_2.TabIndex = 29;
			_optSearchCust_2.TabStop = true;
			_optSearchCust_2.Text = "No";
			_optSearchCust_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_optSearchCust_2.Visible = true;
			// 
			// _optSearchCust_1
			// 
			_optSearchCust_1.AllowDrop = true;
			_optSearchCust_1.BackColor = System.Drawing.SystemColors.Control;
			_optSearchCust_1.CausesValidation = true;
			_optSearchCust_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_optSearchCust_1.Checked = false;
			_optSearchCust_1.Enabled = true;
			_optSearchCust_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_optSearchCust_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_optSearchCust_1.Location = new System.Drawing.Point(70, 12);
			_optSearchCust_1.Name = "_optSearchCust_1";
			_optSearchCust_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_optSearchCust_1.Size = new System.Drawing.Size(41, 13);
			_optSearchCust_1.TabIndex = 28;
			_optSearchCust_1.TabStop = true;
			_optSearchCust_1.Text = "Yes";
			_optSearchCust_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_optSearchCust_1.Visible = true;
			// 
			// _optSearchCust_0
			// 
			_optSearchCust_0.AllowDrop = true;
			_optSearchCust_0.BackColor = System.Drawing.SystemColors.Control;
			_optSearchCust_0.CausesValidation = true;
			_optSearchCust_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_optSearchCust_0.Checked = true;
			_optSearchCust_0.Enabled = true;
			_optSearchCust_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_optSearchCust_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_optSearchCust_0.Location = new System.Drawing.Point(20, 12);
			_optSearchCust_0.Name = "_optSearchCust_0";
			_optSearchCust_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_optSearchCust_0.Size = new System.Drawing.Size(41, 13);
			_optSearchCust_0.TabIndex = 27;
			_optSearchCust_0.TabStop = true;
			_optSearchCust_0.Text = "All";
			_optSearchCust_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_optSearchCust_0.Visible = true;
			// 
			// cmdRefresh
			// 
			cmdRefresh.AllowDrop = true;
			cmdRefresh.BackColor = System.Drawing.SystemColors.Control;
			cmdRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdRefresh.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdRefresh.Location = new System.Drawing.Point(408, 400);
			cmdRefresh.Name = "cmdRefresh";
			cmdRefresh.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdRefresh.Size = new System.Drawing.Size(59, 23);
			cmdRefresh.TabIndex = 153;
			cmdRefresh.Text = "&Refresh";
			cmdRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdRefresh.UseVisualStyleBackColor = false;
			cmdRefresh.Click += new System.EventHandler(cmdRefresh_Click);
			// 
			// Text4
			// 
			Text4.AcceptsReturn = true;
			Text4.AllowDrop = true;
			Text4.BackColor = System.Drawing.Color.FromArgb(192, 255, 255);
			Text4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			Text4.Cursor = System.Windows.Forms.Cursors.IBeam;
			Text4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Text4.ForeColor = System.Drawing.SystemColors.WindowText;
			Text4.Location = new System.Drawing.Point(876, 8);
			Text4.MaxLength = 0;
			Text4.Name = "Text4";
			Text4.ReadOnly = true;
			Text4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Text4.Size = new System.Drawing.Size(73, 19);
			Text4.TabIndex = 33;
			Text4.Text = "Blue = Class A";
			Text4.Visible = false;
			// 
			// txt_TotalCallbacks
			// 
			txt_TotalCallbacks.AcceptsReturn = true;
			txt_TotalCallbacks.AllowDrop = true;
			txt_TotalCallbacks.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_TotalCallbacks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_TotalCallbacks.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_TotalCallbacks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_TotalCallbacks.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_TotalCallbacks.Location = new System.Drawing.Point(154, 403);
			txt_TotalCallbacks.MaxLength = 0;
			txt_TotalCallbacks.Name = "txt_TotalCallbacks";
			txt_TotalCallbacks.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_TotalCallbacks.Size = new System.Drawing.Size(57, 19);
			txt_TotalCallbacks.TabIndex = 32;
			txt_TotalCallbacks.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_TotalAircraft
			// 
			txt_TotalAircraft.AcceptsReturn = true;
			txt_TotalAircraft.AllowDrop = true;
			txt_TotalAircraft.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_TotalAircraft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_TotalAircraft.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_TotalAircraft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_TotalAircraft.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_TotalAircraft.Location = new System.Drawing.Point(594, 403);
			txt_TotalAircraft.MaxLength = 0;
			txt_TotalAircraft.Name = "txt_TotalAircraft";
			txt_TotalAircraft.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_TotalAircraft.Size = new System.Drawing.Size(57, 19);
			txt_TotalAircraft.TabIndex = 31;
			txt_TotalAircraft.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// cmdSelDClick
			// 
			cmdSelDClick.AllowDrop = true;
			cmdSelDClick.BackColor = System.Drawing.SystemColors.Control;
			cmdSelDClick.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdSelDClick.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdSelDClick.Location = new System.Drawing.Point(344, 400);
			cmdSelDClick.Name = "cmdSelDClick";
			cmdSelDClick.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdSelDClick.Size = new System.Drawing.Size(45, 23);
			cmdSelDClick.TabIndex = 21;
			cmdSelDClick.Text = "Select";
			cmdSelDClick.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdSelDClick.UseVisualStyleBackColor = false;
			cmdSelDClick.Visible = false;
			cmdSelDClick.Click += new System.EventHandler(cmdSelDClick_Click);
			// 
			// grd_Callbacks
			// 
			grd_Callbacks.AllowDrop = true;
			grd_Callbacks.AllowUserToAddRows = false;
			grd_Callbacks.AllowUserToDeleteRows = false;
			grd_Callbacks.AllowUserToResizeColumns = false;
			grd_Callbacks.AllowUserToResizeRows = false;
			grd_Callbacks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grd_Callbacks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_Callbacks.ColumnsCount = 2;
			grd_Callbacks.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			grd_Callbacks.FixedColumns = 0;
			grd_Callbacks.FixedRows = 0;
			grd_Callbacks.Location = new System.Drawing.Point(16, 46);
			grd_Callbacks.Name = "grd_Callbacks";
			grd_Callbacks.ReadOnly = true;
			grd_Callbacks.RowsCount = 2;
			grd_Callbacks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grd_Callbacks.ShowCellToolTips = false;
			grd_Callbacks.Size = new System.Drawing.Size(943, 354);
			grd_Callbacks.StandardTab = true;
			grd_Callbacks.TabIndex = 34;
			grd_Callbacks.Click += new System.EventHandler(grd_Callbacks_Click);
			grd_Callbacks.DoubleClick += new System.EventHandler(grd_Callbacks_DoubleClick);
			grd_Callbacks.MouseMove += new System.Windows.Forms.MouseEventHandler(grd_Callbacks_MouseMove);
			// 
			// _lbl_gen_40
			// 
			_lbl_gen_40.AllowDrop = true;
			_lbl_gen_40.AutoSize = true;
			_lbl_gen_40.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_40.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_40.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_40.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_40.Location = new System.Drawing.Point(808, 408);
			_lbl_gen_40.MinimumSize = new System.Drawing.Size(41, 13);
			_lbl_gen_40.Name = "_lbl_gen_40";
			_lbl_gen_40.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_40.Size = new System.Drawing.Size(41, 13);
			_lbl_gen_40.TabIndex = 241;
			_lbl_gen_40.Text = "Country:";
			_lbl_gen_40.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_gen_40.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// Label24
			// 
			Label24.AllowDrop = true;
			Label24.AutoSize = true;
			Label24.BackColor = System.Drawing.Color.Transparent;
			Label24.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label24.ForeColor = System.Drawing.SystemColors.ControlText;
			Label24.Location = new System.Drawing.Point(848, 11);
			Label24.MinimumSize = new System.Drawing.Size(24, 13);
			Label24.Name = "Label24";
			Label24.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label24.Size = new System.Drawing.Size(24, 13);
			Label24.TabIndex = 37;
			Label24.Text = "KEY:";
			Label24.Visible = false;
			// 
			// _lbl_gen_8
			// 
			_lbl_gen_8.AllowDrop = true;
			_lbl_gen_8.AutoSize = true;
			_lbl_gen_8.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_8.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_8.Location = new System.Drawing.Point(476, 406);
			_lbl_gen_8.MinimumSize = new System.Drawing.Size(112, 13);
			_lbl_gen_8.Name = "_lbl_gen_8";
			_lbl_gen_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_8.Size = new System.Drawing.Size(112, 13);
			_lbl_gen_8.TabIndex = 36;
			_lbl_gen_8.Text = "Total Aircraft Callbacks:";
			_lbl_gen_8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_gen_8.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// _lbl_gen_7
			// 
			_lbl_gen_7.AllowDrop = true;
			_lbl_gen_7.AutoSize = true;
			_lbl_gen_7.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_7.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_7.Location = new System.Drawing.Point(13, 406);
			_lbl_gen_7.MinimumSize = new System.Drawing.Size(123, 13);
			_lbl_gen_7.Name = "_lbl_gen_7";
			_lbl_gen_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_7.Size = new System.Drawing.Size(123, 13);
			_lbl_gen_7.TabIndex = 35;
			_lbl_gen_7.Text = "Total Company Callbacks:";
			_lbl_gen_7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_gen_7.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// _tab_callback_TabPage1
			// 
			_tab_callback_TabPage1.Controls.Add(_chk_action_list_11);
			_tab_callback_TabPage1.Controls.Add(opt_last30);
			_tab_callback_TabPage1.Controls.Add(opt_AllReassigns);
			_tab_callback_TabPage1.Controls.Add(pnl_reassignemnt);
			_tab_callback_TabPage1.Controls.Add(Label2);
			_tab_callback_TabPage1.Controls.Add(lbl_Reassign_Message);
			_tab_callback_TabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_callback_TabPage1.Text = "Reassigns";
			// 
			// _chk_action_list_11
			// 
			_chk_action_list_11.AllowDrop = true;
			_chk_action_list_11.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_action_list_11.BackColor = System.Drawing.SystemColors.Control;
			_chk_action_list_11.CausesValidation = true;
			_chk_action_list_11.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_action_list_11.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_action_list_11.Enabled = true;
			_chk_action_list_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_action_list_11.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_action_list_11.Location = new System.Drawing.Point(752, 8);
			_chk_action_list_11.Name = "_chk_action_list_11";
			_chk_action_list_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_action_list_11.Size = new System.Drawing.Size(185, 13);
			_chk_action_list_11.TabIndex = 253;
			_chk_action_list_11.TabStop = true;
			_chk_action_list_11.Text = "Off Market/Off Exclusive";
			_chk_action_list_11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_action_list_11.Visible = true;
			_chk_action_list_11.CheckStateChanged += new System.EventHandler(chk_action_list_CheckStateChanged);
			// 
			// opt_last30
			// 
			opt_last30.AllowDrop = true;
			opt_last30.BackColor = System.Drawing.SystemColors.Control;
			opt_last30.CausesValidation = true;
			opt_last30.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opt_last30.Checked = false;
			opt_last30.Enabled = true;
			opt_last30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			opt_last30.ForeColor = System.Drawing.SystemColors.ControlText;
			opt_last30.Location = new System.Drawing.Point(24, 7);
			opt_last30.Name = "opt_last30";
			opt_last30.RightToLeft = System.Windows.Forms.RightToLeft.No;
			opt_last30.Size = new System.Drawing.Size(87, 17);
			opt_last30.TabIndex = 18;
			opt_last30.TabStop = true;
			opt_last30.Text = "Last 30 Days";
			opt_last30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opt_last30.Visible = true;
			// 
			// opt_AllReassigns
			// 
			opt_AllReassigns.AllowDrop = true;
			opt_AllReassigns.BackColor = System.Drawing.SystemColors.Control;
			opt_AllReassigns.CausesValidation = true;
			opt_AllReassigns.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opt_AllReassigns.Checked = false;
			opt_AllReassigns.Enabled = true;
			opt_AllReassigns.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			opt_AllReassigns.ForeColor = System.Drawing.SystemColors.ControlText;
			opt_AllReassigns.Location = new System.Drawing.Point(118, 9);
			opt_AllReassigns.Name = "opt_AllReassigns";
			opt_AllReassigns.RightToLeft = System.Windows.Forms.RightToLeft.No;
			opt_AllReassigns.Size = new System.Drawing.Size(97, 13);
			opt_AllReassigns.TabIndex = 17;
			opt_AllReassigns.TabStop = true;
			opt_AllReassigns.Text = "All Reassigns";
			opt_AllReassigns.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opt_AllReassigns.Visible = true;
			// 
			// pnl_reassignemnt
			// 
			pnl_reassignemnt.AllowDrop = true;
			pnl_reassignemnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_reassignemnt.Controls.Add(grd_NewAssignments);
			pnl_reassignemnt.Controls.Add(txt_total_reassigns);
			pnl_reassignemnt.Controls.Add(cmd_Refresh_Reassignments);
			pnl_reassignemnt.Controls.Add(lblReassignStopLoading);
			pnl_reassignemnt.Controls.Add(_lbl_gen_9);
			pnl_reassignemnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_reassignemnt.Location = new System.Drawing.Point(10, 22);
			pnl_reassignemnt.Name = "pnl_reassignemnt";
			pnl_reassignemnt.Size = new System.Drawing.Size(933, 401);
			pnl_reassignemnt.TabIndex = 115;
			pnl_reassignemnt.Visible = false;
			// 
			// grd_NewAssignments
			// 
			grd_NewAssignments.AllowDrop = true;
			grd_NewAssignments.AllowUserToAddRows = false;
			grd_NewAssignments.AllowUserToDeleteRows = false;
			grd_NewAssignments.AllowUserToResizeColumns = false;
			grd_NewAssignments.AllowUserToResizeColumns = grd_NewAssignments.ColumnHeadersVisible;
			grd_NewAssignments.AllowUserToResizeRows = false;
			grd_NewAssignments.AllowUserToResizeRows = false;
			grd_NewAssignments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grd_NewAssignments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_NewAssignments.ColumnsCount = 2;
			grd_NewAssignments.FixedColumns = 0;
			grd_NewAssignments.FixedRows = 0;
			grd_NewAssignments.Location = new System.Drawing.Point(7, 4);
			grd_NewAssignments.Name = "grd_NewAssignments";
			grd_NewAssignments.ReadOnly = true;
			grd_NewAssignments.RowsCount = 2;
			grd_NewAssignments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grd_NewAssignments.ShowCellToolTips = false;
			grd_NewAssignments.Size = new System.Drawing.Size(918, 362);
			grd_NewAssignments.StandardTab = true;
			grd_NewAssignments.TabIndex = 118;
			grd_NewAssignments.Click += new System.EventHandler(grd_NewAssignments_Click);
			grd_NewAssignments.DoubleClick += new System.EventHandler(grd_NewAssignments_DoubleClick);
			// 
			// txt_total_reassigns
			// 
			txt_total_reassigns.AcceptsReturn = true;
			txt_total_reassigns.AllowDrop = true;
			txt_total_reassigns.BackColor = System.Drawing.SystemColors.Window;
			txt_total_reassigns.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_total_reassigns.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_total_reassigns.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_total_reassigns.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_total_reassigns.Location = new System.Drawing.Point(110, 372);
			txt_total_reassigns.MaxLength = 0;
			txt_total_reassigns.Name = "txt_total_reassigns";
			txt_total_reassigns.ReadOnly = true;
			txt_total_reassigns.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_total_reassigns.Size = new System.Drawing.Size(59, 19);
			txt_total_reassigns.TabIndex = 117;
			txt_total_reassigns.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// cmd_Refresh_Reassignments
			// 
			cmd_Refresh_Reassignments.AllowDrop = true;
			cmd_Refresh_Reassignments.BackColor = System.Drawing.SystemColors.Control;
			cmd_Refresh_Reassignments.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Refresh_Reassignments.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Refresh_Reassignments.Location = new System.Drawing.Point(320, 370);
			cmd_Refresh_Reassignments.Name = "cmd_Refresh_Reassignments";
			cmd_Refresh_Reassignments.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Refresh_Reassignments.Size = new System.Drawing.Size(78, 24);
			cmd_Refresh_Reassignments.TabIndex = 116;
			cmd_Refresh_Reassignments.Text = "&Refresh";
			cmd_Refresh_Reassignments.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Refresh_Reassignments.UseVisualStyleBackColor = false;
			cmd_Refresh_Reassignments.Click += new System.EventHandler(cmd_Refresh_Reassignments_Click);
			// 
			// lblReassignStopLoading
			// 
			lblReassignStopLoading.AllowDrop = true;
			lblReassignStopLoading.BackColor = System.Drawing.SystemColors.Control;
			lblReassignStopLoading.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblReassignStopLoading.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblReassignStopLoading.ForeColor = System.Drawing.Color.Blue;
			lblReassignStopLoading.Location = new System.Drawing.Point(206, 374);
			lblReassignStopLoading.MinimumSize = new System.Drawing.Size(67, 15);
			lblReassignStopLoading.Name = "lblReassignStopLoading";
			lblReassignStopLoading.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblReassignStopLoading.Size = new System.Drawing.Size(67, 15);
			lblReassignStopLoading.TabIndex = 214;
			lblReassignStopLoading.Text = "Stop Loading";
			lblReassignStopLoading.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			lblReassignStopLoading.Visible = false;
			lblReassignStopLoading.Click += new System.EventHandler(lblReassignStopLoading_Click);
			// 
			// _lbl_gen_9
			// 
			_lbl_gen_9.AllowDrop = true;
			_lbl_gen_9.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_9.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_9.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_9.Location = new System.Drawing.Point(22, 374);
			_lbl_gen_9.MinimumSize = new System.Drawing.Size(79, 15);
			_lbl_gen_9.Name = "_lbl_gen_9";
			_lbl_gen_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_9.Size = new System.Drawing.Size(79, 15);
			_lbl_gen_9.TabIndex = 119;
			_lbl_gen_9.Text = "Total Reassigns:";
			_lbl_gen_9.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// Label2
			// 
			Label2.AllowDrop = true;
			Label2.BackColor = System.Drawing.SystemColors.Control;
			Label2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label2.Enabled = false;
			Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label2.ForeColor = System.Drawing.Color.Blue;
			Label2.Location = new System.Drawing.Point(230, 406);
			Label2.MinimumSize = new System.Drawing.Size(77, 15);
			Label2.Name = "Label2";
			Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label2.Size = new System.Drawing.Size(77, 15);
			Label2.TabIndex = 212;
			Label2.Text = "Stop Loading";
			Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			Label2.Visible = false;
			// 
			// lbl_Reassign_Message
			// 
			lbl_Reassign_Message.AllowDrop = true;
			lbl_Reassign_Message.BackColor = System.Drawing.SystemColors.Control;
			lbl_Reassign_Message.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_Reassign_Message.Font = new System.Drawing.Font("Microsoft Sans Serif", 24f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_Reassign_Message.ForeColor = System.Drawing.Color.FromArgb(128, 64, 64);
			lbl_Reassign_Message.Location = new System.Drawing.Point(189, 227);
			lbl_Reassign_Message.MinimumSize = new System.Drawing.Size(579, 98);
			lbl_Reassign_Message.Name = "lbl_Reassign_Message";
			lbl_Reassign_Message.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_Reassign_Message.Size = new System.Drawing.Size(579, 98);
			lbl_Reassign_Message.TabIndex = 131;
			lbl_Reassign_Message.Text = "Message";
			lbl_Reassign_Message.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// _tab_callback_TabPage2
			// 
			_tab_callback_TabPage2.Controls.Add(chkDoNotIncludeWrittenOffAC);
			_tab_callback_TabPage2.Controls.Add(cmbColorConfirmType);
			_tab_callback_TabPage2.Controls.Add(grd_CompConfirm);
			_tab_callback_TabPage2.Controls.Add(cmd_Refresh_CompColorConfirm);
			_tab_callback_TabPage2.Controls.Add(txt_Total_Confirm_Companies);
			_tab_callback_TabPage2.Controls.Add(chkNotPrimary);
			_tab_callback_TabPage2.Controls.Add(ChkRelatedtoAircraft);
			_tab_callback_TabPage2.Controls.Add(lblColorConfirmType);
			_tab_callback_TabPage2.Controls.Add(lbl_Comp_Confirm);
			_tab_callback_TabPage2.Controls.Add(lbl_CompConfirm);
			_tab_callback_TabPage2.Controls.Add(_lbl_gen_10);
			_tab_callback_TabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_callback_TabPage2.Text = "Color Confirm";
			// 
			// chkDoNotIncludeWrittenOffAC
			// 
			chkDoNotIncludeWrittenOffAC.AllowDrop = true;
			chkDoNotIncludeWrittenOffAC.Appearance = System.Windows.Forms.Appearance.Normal;
			chkDoNotIncludeWrittenOffAC.BackColor = System.Drawing.SystemColors.Control;
			chkDoNotIncludeWrittenOffAC.CausesValidation = true;
			chkDoNotIncludeWrittenOffAC.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkDoNotIncludeWrittenOffAC.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkDoNotIncludeWrittenOffAC.Enabled = true;
			chkDoNotIncludeWrittenOffAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkDoNotIncludeWrittenOffAC.ForeColor = System.Drawing.SystemColors.ControlText;
			chkDoNotIncludeWrittenOffAC.Location = new System.Drawing.Point(418, 12);
			chkDoNotIncludeWrittenOffAC.Name = "chkDoNotIncludeWrittenOffAC";
			chkDoNotIncludeWrittenOffAC.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkDoNotIncludeWrittenOffAC.Size = new System.Drawing.Size(291, 13);
			chkDoNotIncludeWrittenOffAC.TabIndex = 48;
			chkDoNotIncludeWrittenOffAC.TabStop = true;
			chkDoNotIncludeWrittenOffAC.Text = "Do NOT Include Companies with Only Written Off Aircraft";
			chkDoNotIncludeWrittenOffAC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkDoNotIncludeWrittenOffAC.Visible = true;
			chkDoNotIncludeWrittenOffAC.CheckStateChanged += new System.EventHandler(chkDoNotIncludeWrittenOffAC_CheckStateChanged);
			// 
			// cmbColorConfirmType
			// 
			cmbColorConfirmType.AllowDrop = true;
			cmbColorConfirmType.BackColor = System.Drawing.SystemColors.Window;
			cmbColorConfirmType.CausesValidation = true;
			cmbColorConfirmType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cmbColorConfirmType.Enabled = true;
			cmbColorConfirmType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmbColorConfirmType.ForeColor = System.Drawing.SystemColors.WindowText;
			cmbColorConfirmType.IntegralHeight = true;
			cmbColorConfirmType.Location = new System.Drawing.Point(816, 8);
			cmbColorConfirmType.Name = "cmbColorConfirmType";
			cmbColorConfirmType.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmbColorConfirmType.Size = new System.Drawing.Size(166, 21);
			cmbColorConfirmType.Sorted = false;
			cmbColorConfirmType.TabIndex = 49;
			cmbColorConfirmType.TabStop = true;
			cmbColorConfirmType.Visible = true;
			cmbColorConfirmType.SelectionChangeCommitted += new System.EventHandler(cmbColorConfirmType_SelectionChangeCommitted);
			// 
			// grd_CompConfirm
			// 
			grd_CompConfirm.AllowDrop = true;
			grd_CompConfirm.AllowUserToAddRows = false;
			grd_CompConfirm.AllowUserToDeleteRows = false;
			grd_CompConfirm.AllowUserToResizeColumns = false;
			grd_CompConfirm.AllowUserToResizeColumns = grd_CompConfirm.ColumnHeadersVisible;
			grd_CompConfirm.AllowUserToResizeRows = false;
			grd_CompConfirm.AllowUserToResizeRows = false;
			grd_CompConfirm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grd_CompConfirm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_CompConfirm.ColumnsCount = 2;
			grd_CompConfirm.FixedColumns = 0;
			grd_CompConfirm.FixedRows = 0;
			grd_CompConfirm.Location = new System.Drawing.Point(8, 36);
			grd_CompConfirm.Name = "grd_CompConfirm";
			grd_CompConfirm.ReadOnly = true;
			grd_CompConfirm.RowsCount = 2;
			grd_CompConfirm.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grd_CompConfirm.ShowCellToolTips = false;
			grd_CompConfirm.Size = new System.Drawing.Size(972, 368);
			grd_CompConfirm.StandardTab = true;
			grd_CompConfirm.TabIndex = 50;
			grd_CompConfirm.Visible = false;
			grd_CompConfirm.Click += new System.EventHandler(grd_CompConfirm_Click);
			grd_CompConfirm.DoubleClick += new System.EventHandler(grd_CompConfirm_DoubleClick);
			// 
			// cmd_Refresh_CompColorConfirm
			// 
			cmd_Refresh_CompColorConfirm.AllowDrop = true;
			cmd_Refresh_CompColorConfirm.BackColor = System.Drawing.SystemColors.Control;
			cmd_Refresh_CompColorConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Refresh_CompColorConfirm.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Refresh_CompColorConfirm.Location = new System.Drawing.Point(304, 408);
			cmd_Refresh_CompColorConfirm.Name = "cmd_Refresh_CompColorConfirm";
			cmd_Refresh_CompColorConfirm.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Refresh_CompColorConfirm.Size = new System.Drawing.Size(71, 21);
			cmd_Refresh_CompColorConfirm.TabIndex = 101;
			cmd_Refresh_CompColorConfirm.Text = "&Refresh";
			cmd_Refresh_CompColorConfirm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Refresh_CompColorConfirm.UseVisualStyleBackColor = false;
			cmd_Refresh_CompColorConfirm.Click += new System.EventHandler(cmd_Refresh_CompColorConfirm_Click);
			// 
			// txt_Total_Confirm_Companies
			// 
			txt_Total_Confirm_Companies.AcceptsReturn = true;
			txt_Total_Confirm_Companies.AllowDrop = true;
			txt_Total_Confirm_Companies.BackColor = System.Drawing.SystemColors.Window;
			txt_Total_Confirm_Companies.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_Total_Confirm_Companies.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_Total_Confirm_Companies.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_Total_Confirm_Companies.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_Total_Confirm_Companies.Location = new System.Drawing.Point(183, 410);
			txt_Total_Confirm_Companies.MaxLength = 0;
			txt_Total_Confirm_Companies.Name = "txt_Total_Confirm_Companies";
			txt_Total_Confirm_Companies.ReadOnly = true;
			txt_Total_Confirm_Companies.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_Total_Confirm_Companies.Size = new System.Drawing.Size(59, 19);
			txt_Total_Confirm_Companies.TabIndex = 100;
			txt_Total_Confirm_Companies.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// chkNotPrimary
			// 
			chkNotPrimary.AllowDrop = true;
			chkNotPrimary.Appearance = System.Windows.Forms.Appearance.Normal;
			chkNotPrimary.BackColor = System.Drawing.SystemColors.Control;
			chkNotPrimary.CausesValidation = true;
			chkNotPrimary.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkNotPrimary.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkNotPrimary.Enabled = true;
			chkNotPrimary.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkNotPrimary.ForeColor = System.Drawing.SystemColors.ControlText;
			chkNotPrimary.Location = new System.Drawing.Point(13, 12);
			chkNotPrimary.Name = "chkNotPrimary";
			chkNotPrimary.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkNotPrimary.Size = new System.Drawing.Size(264, 13);
			chkNotPrimary.TabIndex = 46;
			chkNotPrimary.TabStop = true;
			chkNotPrimary.Text = "Only Companies that are not primary on any aircraft";
			chkNotPrimary.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkNotPrimary.Visible = true;
			chkNotPrimary.CheckStateChanged += new System.EventHandler(chkNotPrimary_CheckStateChanged);
			// 
			// ChkRelatedtoAircraft
			// 
			ChkRelatedtoAircraft.AllowDrop = true;
			ChkRelatedtoAircraft.Appearance = System.Windows.Forms.Appearance.Normal;
			ChkRelatedtoAircraft.BackColor = System.Drawing.SystemColors.Control;
			ChkRelatedtoAircraft.CausesValidation = true;
			ChkRelatedtoAircraft.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			ChkRelatedtoAircraft.CheckState = System.Windows.Forms.CheckState.Checked;
			ChkRelatedtoAircraft.Enabled = true;
			ChkRelatedtoAircraft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ChkRelatedtoAircraft.ForeColor = System.Drawing.SystemColors.ControlText;
			ChkRelatedtoAircraft.Location = new System.Drawing.Point(292, 12);
			ChkRelatedtoAircraft.Name = "ChkRelatedtoAircraft";
			ChkRelatedtoAircraft.RightToLeft = System.Windows.Forms.RightToLeft.No;
			ChkRelatedtoAircraft.Size = new System.Drawing.Size(113, 13);
			ChkRelatedtoAircraft.TabIndex = 47;
			ChkRelatedtoAircraft.TabStop = true;
			ChkRelatedtoAircraft.Text = "Related to Aircraft?";
			ChkRelatedtoAircraft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			ChkRelatedtoAircraft.Visible = true;
			ChkRelatedtoAircraft.CheckStateChanged += new System.EventHandler(ChkRelatedtoAircraft_CheckStateChanged);
			// 
			// lblColorConfirmType
			// 
			lblColorConfirmType.AllowDrop = true;
			lblColorConfirmType.AutoSize = true;
			lblColorConfirmType.BackColor = System.Drawing.Color.Transparent;
			lblColorConfirmType.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblColorConfirmType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblColorConfirmType.ForeColor = System.Drawing.SystemColors.ControlText;
			lblColorConfirmType.Location = new System.Drawing.Point(719, 16);
			lblColorConfirmType.MinimumSize = new System.Drawing.Size(89, 13);
			lblColorConfirmType.Name = "lblColorConfirmType";
			lblColorConfirmType.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblColorConfirmType.Size = new System.Drawing.Size(89, 13);
			lblColorConfirmType.TabIndex = 177;
			lblColorConfirmType.Text = "Color Confirm Type";
			lblColorConfirmType.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lbl_Comp_Confirm
			// 
			lbl_Comp_Confirm.AllowDrop = true;
			lbl_Comp_Confirm.BackColor = System.Drawing.SystemColors.Control;
			lbl_Comp_Confirm.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_Comp_Confirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 24f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_Comp_Confirm.ForeColor = System.Drawing.Color.FromArgb(128, 64, 64);
			lbl_Comp_Confirm.Location = new System.Drawing.Point(107, 254);
			lbl_Comp_Confirm.MinimumSize = new System.Drawing.Size(632, 119);
			lbl_Comp_Confirm.Name = "lbl_Comp_Confirm";
			lbl_Comp_Confirm.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_Comp_Confirm.Size = new System.Drawing.Size(632, 119);
			lbl_Comp_Confirm.TabIndex = 130;
			lbl_Comp_Confirm.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lbl_CompConfirm
			// 
			lbl_CompConfirm.AllowDrop = true;
			lbl_CompConfirm.BackColor = System.Drawing.SystemColors.Control;
			lbl_CompConfirm.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_CompConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_CompConfirm.ForeColor = System.Drawing.Color.Maroon;
			lbl_CompConfirm.Location = new System.Drawing.Point(72, 140);
			lbl_CompConfirm.MinimumSize = new System.Drawing.Size(265, 41);
			lbl_CompConfirm.Name = "lbl_CompConfirm";
			lbl_CompConfirm.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_CompConfirm.Size = new System.Drawing.Size(265, 41);
			lbl_CompConfirm.TabIndex = 134;
			// 
			// _lbl_gen_10
			// 
			_lbl_gen_10.AllowDrop = true;
			_lbl_gen_10.AutoSize = true;
			_lbl_gen_10.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_10.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_10.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_10.Location = new System.Drawing.Point(42, 413);
			_lbl_gen_10.MinimumSize = new System.Drawing.Size(132, 11);
			_lbl_gen_10.Name = "_lbl_gen_10";
			_lbl_gen_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_10.Size = new System.Drawing.Size(132, 11);
			_lbl_gen_10.TabIndex = 126;
			_lbl_gen_10.Text = "Total Companies to Confirm:";
			_lbl_gen_10.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// _tab_callback_TabPage3
			// 
			_tab_callback_TabPage3.Controls.Add(pnl_Exclusives);
			_tab_callback_TabPage3.Controls.Add(lbl_exclusivesdue);
			_tab_callback_TabPage3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_callback_TabPage3.Text = "Reverify Exc Due ";
			// 
			// pnl_Exclusives
			// 
			pnl_Exclusives.AllowDrop = true;
			pnl_Exclusives.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Exclusives.Controls.Add(_cmd_refresh_2);
			pnl_Exclusives.Controls.Add(txt_TotExclusive);
			pnl_Exclusives.Controls.Add(txt_expired);
			pnl_Exclusives.Controls.Add(txt_confirmed);
			pnl_Exclusives.Controls.Add(grd_Exclusives);
			pnl_Exclusives.Controls.Add(pnl_primary);
			pnl_Exclusives.Controls.Add(_lbl_gen_11);
			pnl_Exclusives.Controls.Add(_lbl_gen_12);
			pnl_Exclusives.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Exclusives.Location = new System.Drawing.Point(0, 12);
			pnl_Exclusives.Name = "pnl_Exclusives";
			pnl_Exclusives.Size = new System.Drawing.Size(970, 415);
			pnl_Exclusives.TabIndex = 105;
			pnl_Exclusives.MouseMove += new System.Windows.Forms.MouseEventHandler(pnl_Exclusives_MouseMove);
			// 
			// _cmd_refresh_2
			// 
			_cmd_refresh_2.AllowDrop = true;
			_cmd_refresh_2.BackColor = System.Drawing.SystemColors.Control;
			_cmd_refresh_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_refresh_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_refresh_2.Location = new System.Drawing.Point(296, 352);
			_cmd_refresh_2.Name = "_cmd_refresh_2";
			_cmd_refresh_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_refresh_2.Size = new System.Drawing.Size(65, 27);
			_cmd_refresh_2.TabIndex = 222;
			_cmd_refresh_2.Text = "Refresh";
			_cmd_refresh_2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_refresh_2.UseVisualStyleBackColor = false;
			_cmd_refresh_2.Click += new System.EventHandler(cmd_refresh_Click);
			// 
			// txt_TotExclusive
			// 
			txt_TotExclusive.AcceptsReturn = true;
			txt_TotExclusive.AllowDrop = true;
			txt_TotExclusive.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_TotExclusive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_TotExclusive.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_TotExclusive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_TotExclusive.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_TotExclusive.Location = new System.Drawing.Point(149, 374);
			txt_TotExclusive.MaxLength = 0;
			txt_TotExclusive.Name = "txt_TotExclusive";
			txt_TotExclusive.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_TotExclusive.Size = new System.Drawing.Size(57, 19);
			txt_TotExclusive.TabIndex = 112;
			txt_TotExclusive.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_expired
			// 
			txt_expired.AcceptsReturn = true;
			txt_expired.AllowDrop = true;
			txt_expired.BackColor = System.Drawing.Color.Yellow;
			txt_expired.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_expired.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_expired.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_expired.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_expired.Location = new System.Drawing.Point(15, 319);
			txt_expired.MaxLength = 0;
			txt_expired.Name = "txt_expired";
			txt_expired.ReadOnly = true;
			txt_expired.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_expired.Size = new System.Drawing.Size(112, 19);
			txt_expired.TabIndex = 111;
			txt_expired.Text = "Expiration Date";
			txt_expired.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txt_confirmed
			// 
			txt_confirmed.AcceptsReturn = true;
			txt_confirmed.AllowDrop = true;
			txt_confirmed.BackColor = System.Drawing.Color.FromArgb(255, 192, 192);
			txt_confirmed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_confirmed.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_confirmed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_confirmed.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_confirmed.Location = new System.Drawing.Point(15, 345);
			txt_confirmed.MaxLength = 0;
			txt_confirmed.Name = "txt_confirmed";
			txt_confirmed.ReadOnly = true;
			txt_confirmed.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_confirmed.Size = new System.Drawing.Size(112, 19);
			txt_confirmed.TabIndex = 110;
			txt_confirmed.Text = " Due to be Confirmed";
			txt_confirmed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// grd_Exclusives
			// 
			grd_Exclusives.AllowDrop = true;
			grd_Exclusives.AllowUserToAddRows = false;
			grd_Exclusives.AllowUserToDeleteRows = false;
			grd_Exclusives.AllowUserToResizeColumns = false;
			grd_Exclusives.AllowUserToResizeColumns = grd_Exclusives.ColumnHeadersVisible;
			grd_Exclusives.AllowUserToResizeRows = false;
			grd_Exclusives.AllowUserToResizeRows = false;
			grd_Exclusives.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grd_Exclusives.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_Exclusives.ColumnsCount = 2;
			grd_Exclusives.FixedColumns = 0;
			grd_Exclusives.FixedRows = 0;
			grd_Exclusives.Location = new System.Drawing.Point(8, 12);
			grd_Exclusives.Name = "grd_Exclusives";
			grd_Exclusives.ReadOnly = true;
			grd_Exclusives.RowsCount = 2;
			grd_Exclusives.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grd_Exclusives.ShowCellToolTips = false;
			grd_Exclusives.Size = new System.Drawing.Size(955, 304);
			grd_Exclusives.StandardTab = true;
			grd_Exclusives.TabIndex = 106;
			grd_Exclusives.Click += new System.EventHandler(grd_Exclusives_Click);
			grd_Exclusives.DoubleClick += new System.EventHandler(grd_Exclusives_DoubleClick);
			grd_Exclusives.MouseMove += new System.Windows.Forms.MouseEventHandler(grd_Exclusives_MouseMove);
			// 
			// pnl_primary
			// 
			pnl_primary.AllowDrop = true;
			pnl_primary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_primary.Controls.Add(lst_primary);
			pnl_primary.Controls.Add(lbl_actype);
			pnl_primary.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_primary.Location = new System.Drawing.Point(457, 333);
			pnl_primary.Name = "pnl_primary";
			pnl_primary.Size = new System.Drawing.Size(386, 78);
			pnl_primary.TabIndex = 107;
			pnl_primary.Visible = false;
			// 
			// lst_primary
			// 
			lst_primary.AllowDrop = true;
			lst_primary.BackColor = System.Drawing.SystemColors.Window;
			lst_primary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lst_primary.CausesValidation = true;
			lst_primary.Enabled = true;
			lst_primary.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lst_primary.ForeColor = System.Drawing.SystemColors.WindowText;
			lst_primary.IntegralHeight = true;
			lst_primary.Location = new System.Drawing.Point(5, 5);
			lst_primary.MultiColumn = false;
			lst_primary.Name = "lst_primary";
			lst_primary.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lst_primary.Size = new System.Drawing.Size(372, 70);
			lst_primary.Sorted = false;
			lst_primary.TabIndex = 108;
			lst_primary.TabStop = true;
			lst_primary.Visible = true;
			lst_primary.DoubleClick += new System.EventHandler(lst_primary_DoubleClick);
			// 
			// lbl_actype
			// 
			lbl_actype.AllowDrop = true;
			lbl_actype.BackColor = System.Drawing.Color.Transparent;
			lbl_actype.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_actype.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_actype.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_actype.Location = new System.Drawing.Point(209, 22);
			lbl_actype.MinimumSize = new System.Drawing.Size(167, 17);
			lbl_actype.Name = "lbl_actype";
			lbl_actype.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_actype.Size = new System.Drawing.Size(167, 17);
			lbl_actype.TabIndex = 109;
			// 
			// _lbl_gen_11
			// 
			_lbl_gen_11.AllowDrop = true;
			_lbl_gen_11.AutoSize = true;
			_lbl_gen_11.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_11.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_11.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_11.Location = new System.Drawing.Point(13, 377);
			_lbl_gen_11.MinimumSize = new System.Drawing.Size(124, 13);
			_lbl_gen_11.Name = "_lbl_gen_11";
			_lbl_gen_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_11.Size = new System.Drawing.Size(124, 13);
			_lbl_gen_11.TabIndex = 114;
			_lbl_gen_11.Text = "Total Exclusive Callbacks:";
			_lbl_gen_11.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// _lbl_gen_12
			// 
			_lbl_gen_12.AllowDrop = true;
			_lbl_gen_12.AutoSize = true;
			_lbl_gen_12.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_12.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_12.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_12.Location = new System.Drawing.Point(457, 320);
			_lbl_gen_12.MinimumSize = new System.Drawing.Size(159, 13);
			_lbl_gen_12.Name = "_lbl_gen_12";
			_lbl_gen_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_12.Size = new System.Drawing.Size(159, 13);
			_lbl_gen_12.TabIndex = 113;
			_lbl_gen_12.Text = "Exclusive Broker/Representative:";
			_lbl_gen_12.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// lbl_exclusivesdue
			// 
			lbl_exclusivesdue.AllowDrop = true;
			lbl_exclusivesdue.BackColor = System.Drawing.Color.Silver;
			lbl_exclusivesdue.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_exclusivesdue.Font = new System.Drawing.Font("Microsoft Sans Serif", 24f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_exclusivesdue.ForeColor = System.Drawing.Color.Maroon;
			lbl_exclusivesdue.Location = new System.Drawing.Point(108, 200);
			lbl_exclusivesdue.MinimumSize = new System.Drawing.Size(866, 98);
			lbl_exclusivesdue.Name = "lbl_exclusivesdue";
			lbl_exclusivesdue.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_exclusivesdue.Size = new System.Drawing.Size(866, 98);
			lbl_exclusivesdue.TabIndex = 128;
			// 
			// _tab_callback_TabPage4
			// 
			_tab_callback_TabPage4.Controls.Add(lbl_Hot_Items);
			_tab_callback_TabPage4.Controls.Add(_lbl_gen_37);
			_tab_callback_TabPage4.Controls.Add(pnl_Hot_Items);
			_tab_callback_TabPage4.Controls.Add(chk_HotItemsAcctRep);
			_tab_callback_TabPage4.Controls.Add(_opHBAircraftYacht_0);
			_tab_callback_TabPage4.Controls.Add(_opHBAircraftYacht_1);
			_tab_callback_TabPage4.Controls.Add(_cmd_refresh_1);
			_tab_callback_TabPage4.Controls.Add(_chk_action_list_9);
			_tab_callback_TabPage4.Controls.Add(_chk_action_list_10);
			_tab_callback_TabPage4.Controls.Add(_cmd_export_docs_1);
			_tab_callback_TabPage4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_callback_TabPage4.Text = "Hot Box Items";
			// 
			// lbl_Hot_Items
			// 
			lbl_Hot_Items.AllowDrop = true;
			lbl_Hot_Items.BackColor = System.Drawing.SystemColors.Control;
			lbl_Hot_Items.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_Hot_Items.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_Hot_Items.ForeColor = System.Drawing.Color.FromArgb(128, 64, 64);
			lbl_Hot_Items.Location = new System.Drawing.Point(135, 203);
			lbl_Hot_Items.MinimumSize = new System.Drawing.Size(845, 181);
			lbl_Hot_Items.Name = "lbl_Hot_Items";
			lbl_Hot_Items.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_Hot_Items.Size = new System.Drawing.Size(845, 181);
			lbl_Hot_Items.TabIndex = 129;
			lbl_Hot_Items.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// _lbl_gen_37
			// 
			_lbl_gen_37.AllowDrop = true;
			_lbl_gen_37.AutoSize = true;
			_lbl_gen_37.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_37.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_37.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_37.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_37.Location = new System.Drawing.Point(362, 10);
			_lbl_gen_37.MinimumSize = new System.Drawing.Size(377, 17);
			_lbl_gen_37.Name = "_lbl_gen_37";
			_lbl_gen_37.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_37.Size = new System.Drawing.Size(377, 17);
			_lbl_gen_37.TabIndex = 219;
			_lbl_gen_37.Text = "No Hot Items Selected";
			_lbl_gen_37.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// pnl_Hot_Items
			// 
			pnl_Hot_Items.AllowDrop = true;
			pnl_Hot_Items.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Hot_Items.Controls.Add(grd_Hot_Items);
			pnl_Hot_Items.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Hot_Items.Location = new System.Drawing.Point(14, 29);
			pnl_Hot_Items.Name = "pnl_Hot_Items";
			pnl_Hot_Items.Size = new System.Drawing.Size(969, 365);
			pnl_Hot_Items.TabIndex = 102;
			// 
			// grd_Hot_Items
			// 
			grd_Hot_Items.AllowDrop = true;
			grd_Hot_Items.AllowUserToAddRows = false;
			grd_Hot_Items.AllowUserToDeleteRows = false;
			grd_Hot_Items.AllowUserToResizeColumns = false;
			grd_Hot_Items.AllowUserToResizeColumns = grd_Hot_Items.ColumnHeadersVisible;
			grd_Hot_Items.AllowUserToResizeRows = false;
			grd_Hot_Items.AllowUserToResizeRows = false;
			grd_Hot_Items.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grd_Hot_Items.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_Hot_Items.ColumnsCount = 2;
			grd_Hot_Items.FixedColumns = 1;
			grd_Hot_Items.FixedRows = 1;
			grd_Hot_Items.Location = new System.Drawing.Point(10, 2);
			grd_Hot_Items.Name = "grd_Hot_Items";
			grd_Hot_Items.ReadOnly = true;
			grd_Hot_Items.RowsCount = 2;
			grd_Hot_Items.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			grd_Hot_Items.ShowCellToolTips = false;
			grd_Hot_Items.Size = new System.Drawing.Size(943, 349);
			grd_Hot_Items.StandardTab = true;
			grd_Hot_Items.TabIndex = 103;
			grd_Hot_Items.Click += new System.EventHandler(grd_Hot_Items_Click);
			grd_Hot_Items.DoubleClick += new System.EventHandler(grd_Hot_Items_DoubleClick);
			// 
			// chk_HotItemsAcctRep
			// 
			chk_HotItemsAcctRep.AllowDrop = true;
			chk_HotItemsAcctRep.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_HotItemsAcctRep.BackColor = System.Drawing.SystemColors.Control;
			chk_HotItemsAcctRep.CausesValidation = true;
			chk_HotItemsAcctRep.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_HotItemsAcctRep.CheckState = System.Windows.Forms.CheckState.Checked;
			chk_HotItemsAcctRep.Enabled = true;
			chk_HotItemsAcctRep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_HotItemsAcctRep.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_HotItemsAcctRep.Location = new System.Drawing.Point(15, 10);
			chk_HotItemsAcctRep.Name = "chk_HotItemsAcctRep";
			chk_HotItemsAcctRep.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_HotItemsAcctRep.Size = new System.Drawing.Size(164, 14);
			chk_HotItemsAcctRep.TabIndex = 63;
			chk_HotItemsAcctRep.TabStop = true;
			chk_HotItemsAcctRep.Text = "Only for current Account Rep";
			chk_HotItemsAcctRep.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_HotItemsAcctRep.Visible = true;
			chk_HotItemsAcctRep.CheckStateChanged += new System.EventHandler(chk_HotItemsAcctRep_CheckStateChanged);
			// 
			// _opHBAircraftYacht_0
			// 
			_opHBAircraftYacht_0.AllowDrop = true;
			_opHBAircraftYacht_0.BackColor = System.Drawing.SystemColors.Control;
			_opHBAircraftYacht_0.CausesValidation = true;
			_opHBAircraftYacht_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opHBAircraftYacht_0.Checked = true;
			_opHBAircraftYacht_0.Enabled = true;
			_opHBAircraftYacht_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_opHBAircraftYacht_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_opHBAircraftYacht_0.Location = new System.Drawing.Point(204, 10);
			_opHBAircraftYacht_0.Name = "_opHBAircraftYacht_0";
			_opHBAircraftYacht_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_opHBAircraftYacht_0.Size = new System.Drawing.Size(69, 13);
			_opHBAircraftYacht_0.TabIndex = 215;
			_opHBAircraftYacht_0.TabStop = true;
			_opHBAircraftYacht_0.Text = "Aircraft";
			_opHBAircraftYacht_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opHBAircraftYacht_0.Visible = true;
			_opHBAircraftYacht_0.CheckedChanged += new System.EventHandler(opHBAircraftYacht_CheckedChanged);
			// 
			// _opHBAircraftYacht_1
			// 
			_opHBAircraftYacht_1.AllowDrop = true;
			_opHBAircraftYacht_1.BackColor = System.Drawing.SystemColors.Control;
			_opHBAircraftYacht_1.CausesValidation = true;
			_opHBAircraftYacht_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opHBAircraftYacht_1.Checked = false;
			_opHBAircraftYacht_1.Enabled = true;
			_opHBAircraftYacht_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_opHBAircraftYacht_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_opHBAircraftYacht_1.Location = new System.Drawing.Point(288, 8);
			_opHBAircraftYacht_1.Name = "_opHBAircraftYacht_1";
			_opHBAircraftYacht_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_opHBAircraftYacht_1.Size = new System.Drawing.Size(57, 13);
			_opHBAircraftYacht_1.TabIndex = 216;
			_opHBAircraftYacht_1.TabStop = true;
			_opHBAircraftYacht_1.Text = "Yacht";
			_opHBAircraftYacht_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opHBAircraftYacht_1.Visible = true;
			_opHBAircraftYacht_1.CheckedChanged += new System.EventHandler(opHBAircraftYacht_CheckedChanged);
			// 
			// _cmd_refresh_1
			// 
			_cmd_refresh_1.AllowDrop = true;
			_cmd_refresh_1.BackColor = System.Drawing.SystemColors.Control;
			_cmd_refresh_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_refresh_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_refresh_1.Location = new System.Drawing.Point(16, 400);
			_cmd_refresh_1.Name = "_cmd_refresh_1";
			_cmd_refresh_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_refresh_1.Size = new System.Drawing.Size(65, 27);
			_cmd_refresh_1.TabIndex = 221;
			_cmd_refresh_1.Text = "Refresh";
			_cmd_refresh_1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_refresh_1.UseVisualStyleBackColor = false;
			_cmd_refresh_1.Click += new System.EventHandler(cmd_refresh_Click);
			// 
			// _chk_action_list_9
			// 
			_chk_action_list_9.AllowDrop = true;
			_chk_action_list_9.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_action_list_9.BackColor = System.Drawing.SystemColors.Control;
			_chk_action_list_9.CausesValidation = true;
			_chk_action_list_9.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_action_list_9.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_action_list_9.Enabled = true;
			_chk_action_list_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_action_list_9.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_action_list_9.Location = new System.Drawing.Point(748, 10);
			_chk_action_list_9.Name = "_chk_action_list_9";
			_chk_action_list_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_action_list_9.Size = new System.Drawing.Size(91, 13);
			_chk_action_list_9.TabIndex = 217;
			_chk_action_list_9.TabStop = true;
			_chk_action_list_9.Text = "Docs Ordered";
			_chk_action_list_9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_action_list_9.Visible = true;
			_chk_action_list_9.CheckStateChanged += new System.EventHandler(chk_action_list_CheckStateChanged);
			// 
			// _chk_action_list_10
			// 
			_chk_action_list_10.AllowDrop = true;
			_chk_action_list_10.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_action_list_10.BackColor = System.Drawing.SystemColors.Control;
			_chk_action_list_10.CausesValidation = true;
			_chk_action_list_10.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_action_list_10.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_action_list_10.Enabled = true;
			_chk_action_list_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_action_list_10.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_action_list_10.Location = new System.Drawing.Point(870, 10);
			_chk_action_list_10.Name = "_chk_action_list_10";
			_chk_action_list_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_action_list_10.Size = new System.Drawing.Size(91, 13);
			_chk_action_list_10.TabIndex = 218;
			_chk_action_list_10.TabStop = true;
			_chk_action_list_10.Text = "Sending Docs";
			_chk_action_list_10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_action_list_10.Visible = true;
			_chk_action_list_10.CheckStateChanged += new System.EventHandler(chk_action_list_CheckStateChanged);
			// 
			// _cmd_export_docs_1
			// 
			_cmd_export_docs_1.AllowDrop = true;
			_cmd_export_docs_1.BackColor = System.Drawing.SystemColors.Control;
			_cmd_export_docs_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_export_docs_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_export_docs_1.Location = new System.Drawing.Point(216, 400);
			_cmd_export_docs_1.Name = "_cmd_export_docs_1";
			_cmd_export_docs_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_export_docs_1.Size = new System.Drawing.Size(78, 20);
			_cmd_export_docs_1.TabIndex = 252;
			_cmd_export_docs_1.Text = "Export";
			_cmd_export_docs_1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_export_docs_1.UseVisualStyleBackColor = false;
			_cmd_export_docs_1.Click += new System.EventHandler(cmd_export_docs_Click);
			// 
			// _tab_callback_TabPage5
			// 
			_tab_callback_TabPage5.Controls.Add(_cmd_refresh_0);
			_tab_callback_TabPage5.Controls.Add(txt_total_leased_aircraft);
			_tab_callback_TabPage5.Controls.Add(chk_Unknown);
			_tab_callback_TabPage5.Controls.Add(grd_expired_leases);
			_tab_callback_TabPage5.Controls.Add(_lbl_gen_13);
			_tab_callback_TabPage5.Controls.Add(lbl_expiredleases);
			_tab_callback_TabPage5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_callback_TabPage5.Text = "Expired Leases";
			// 
			// _cmd_refresh_0
			// 
			_cmd_refresh_0.AllowDrop = true;
			_cmd_refresh_0.BackColor = System.Drawing.SystemColors.Control;
			_cmd_refresh_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_refresh_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_refresh_0.Location = new System.Drawing.Point(304, 404);
			_cmd_refresh_0.Name = "_cmd_refresh_0";
			_cmd_refresh_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_refresh_0.Size = new System.Drawing.Size(65, 27);
			_cmd_refresh_0.TabIndex = 220;
			_cmd_refresh_0.Text = "Refresh";
			_cmd_refresh_0.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_refresh_0.UseVisualStyleBackColor = false;
			_cmd_refresh_0.Click += new System.EventHandler(cmd_refresh_Click);
			// 
			// txt_total_leased_aircraft
			// 
			txt_total_leased_aircraft.AcceptsReturn = true;
			txt_total_leased_aircraft.AllowDrop = true;
			txt_total_leased_aircraft.BackColor = System.Drawing.SystemColors.Window;
			txt_total_leased_aircraft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_total_leased_aircraft.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_total_leased_aircraft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_total_leased_aircraft.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_total_leased_aircraft.Location = new System.Drawing.Point(212, 405);
			txt_total_leased_aircraft.MaxLength = 0;
			txt_total_leased_aircraft.Name = "txt_total_leased_aircraft";
			txt_total_leased_aircraft.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_total_leased_aircraft.Size = new System.Drawing.Size(53, 22);
			txt_total_leased_aircraft.TabIndex = 104;
			// 
			// chk_Unknown
			// 
			chk_Unknown.AllowDrop = true;
			chk_Unknown.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_Unknown.BackColor = System.Drawing.SystemColors.Control;
			chk_Unknown.CausesValidation = true;
			chk_Unknown.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_Unknown.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_Unknown.Enabled = true;
			chk_Unknown.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_Unknown.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_Unknown.Location = new System.Drawing.Point(9, 8);
			chk_Unknown.Name = "chk_Unknown";
			chk_Unknown.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_Unknown.Size = new System.Drawing.Size(289, 17);
			chk_Unknown.TabIndex = 44;
			chk_Unknown.TabStop = true;
			chk_Unknown.Text = "Include Leases That have Unknown Expiration Date";
			chk_Unknown.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_Unknown.Visible = true;
			// 
			// grd_expired_leases
			// 
			grd_expired_leases.AllowDrop = true;
			grd_expired_leases.AllowUserToAddRows = false;
			grd_expired_leases.AllowUserToDeleteRows = false;
			grd_expired_leases.AllowUserToResizeColumns = false;
			grd_expired_leases.AllowUserToResizeColumns = grd_expired_leases.ColumnHeadersVisible;
			grd_expired_leases.AllowUserToResizeRows = false;
			grd_expired_leases.AllowUserToResizeRows = false;
			grd_expired_leases.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grd_expired_leases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_expired_leases.ColumnsCount = 2;
			grd_expired_leases.FixedColumns = 0;
			grd_expired_leases.FixedRows = 1;
			grd_expired_leases.Location = new System.Drawing.Point(6, 28);
			grd_expired_leases.Name = "grd_expired_leases";
			grd_expired_leases.ReadOnly = true;
			grd_expired_leases.RowsCount = 2;
			grd_expired_leases.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grd_expired_leases.ShowCellToolTips = false;
			grd_expired_leases.Size = new System.Drawing.Size(973, 371);
			grd_expired_leases.StandardTab = true;
			grd_expired_leases.TabIndex = 38;
			grd_expired_leases.Click += new System.EventHandler(grd_expired_leases_Click);
			grd_expired_leases.DoubleClick += new System.EventHandler(grd_expired_leases_DoubleClick);
			// 
			// _lbl_gen_13
			// 
			_lbl_gen_13.AllowDrop = true;
			_lbl_gen_13.AutoSize = true;
			_lbl_gen_13.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_13.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_13.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_13.Location = new System.Drawing.Point(89, 410);
			_lbl_gen_13.MinimumSize = new System.Drawing.Size(101, 13);
			_lbl_gen_13.Name = "_lbl_gen_13";
			_lbl_gen_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_13.Size = new System.Drawing.Size(101, 13);
			_lbl_gen_13.TabIndex = 132;
			_lbl_gen_13.Text = "Total Leased Aircraft:";
			_lbl_gen_13.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// lbl_expiredleases
			// 
			lbl_expiredleases.AllowDrop = true;
			lbl_expiredleases.BackColor = System.Drawing.SystemColors.Control;
			lbl_expiredleases.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_expiredleases.Font = new System.Drawing.Font("Microsoft Sans Serif", 24f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_expiredleases.ForeColor = System.Drawing.Color.Maroon;
			lbl_expiredleases.Location = new System.Drawing.Point(12, 203);
			lbl_expiredleases.MinimumSize = new System.Drawing.Size(960, 113);
			lbl_expiredleases.Name = "lbl_expiredleases";
			lbl_expiredleases.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_expiredleases.Size = new System.Drawing.Size(960, 113);
			lbl_expiredleases.TabIndex = 127;
			lbl_expiredleases.Text = "Label5";
			// 
			// _tab_callback_TabPage6
			// 
			_tab_callback_TabPage6.Controls.Add(pnl_Fractional);
			_tab_callback_TabPage6.Controls.Add(lblFractionalMessage);
			_tab_callback_TabPage6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_callback_TabPage6.Text = "Fractional Owners";
			// 
			// pnl_Fractional
			// 
			pnl_Fractional.AllowDrop = true;
			pnl_Fractional.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Fractional.Controls.Add(cmdRefreshFractOwners);
			pnl_Fractional.Controls.Add(chk_Current_Acct_Rep);
			pnl_Fractional.Controls.Add(chk_Date_Less_Than);
			pnl_Fractional.Controls.Add(optFractionalOwners);
			pnl_Fractional.Controls.Add(optBadFractions);
			pnl_Fractional.Controls.Add(opt_OwnersPendingSale);
			pnl_Fractional.Controls.Add(Opt_Reassigned);
			pnl_Fractional.Controls.Add(cmd_ClearFractionalReassign);
			pnl_Fractional.Controls.Add(Opt_FracWithPrimaryWhole);
			pnl_Fractional.Controls.Add(pnl_fractional_display);
			pnl_Fractional.Controls.Add(pnlFractionalPercentagesBad);
			pnl_Fractional.Font = new System.Drawing.Font("Microsoft Sans Serif", 24f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Fractional.ForeColor = System.Drawing.Color.FromArgb(128, 64, 0);
			pnl_Fractional.Location = new System.Drawing.Point(12, 14);
			pnl_Fractional.Name = "pnl_Fractional";
			pnl_Fractional.Size = new System.Drawing.Size(971, 406);
			pnl_Fractional.TabIndex = 69;
			// 
			// cmdRefreshFractOwners
			// 
			cmdRefreshFractOwners.AllowDrop = true;
			cmdRefreshFractOwners.BackColor = System.Drawing.SystemColors.Control;
			cmdRefreshFractOwners.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdRefreshFractOwners.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdRefreshFractOwners.Location = new System.Drawing.Point(310, 374);
			cmdRefreshFractOwners.Name = "cmdRefreshFractOwners";
			cmdRefreshFractOwners.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdRefreshFractOwners.Size = new System.Drawing.Size(78, 22);
			cmdRefreshFractOwners.TabIndex = 90;
			cmdRefreshFractOwners.Text = "&Refresh";
			cmdRefreshFractOwners.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdRefreshFractOwners.UseVisualStyleBackColor = false;
			cmdRefreshFractOwners.Click += new System.EventHandler(cmdRefreshFractOwners_Click);
			// 
			// chk_Current_Acct_Rep
			// 
			chk_Current_Acct_Rep.AllowDrop = true;
			chk_Current_Acct_Rep.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_Current_Acct_Rep.BackColor = System.Drawing.SystemColors.Control;
			chk_Current_Acct_Rep.CausesValidation = true;
			chk_Current_Acct_Rep.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_Current_Acct_Rep.CheckState = System.Windows.Forms.CheckState.Checked;
			chk_Current_Acct_Rep.Enabled = true;
			chk_Current_Acct_Rep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_Current_Acct_Rep.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_Current_Acct_Rep.Location = new System.Drawing.Point(819, 44);
			chk_Current_Acct_Rep.Name = "chk_Current_Acct_Rep";
			chk_Current_Acct_Rep.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_Current_Acct_Rep.Size = new System.Drawing.Size(148, 24);
			chk_Current_Acct_Rep.TabIndex = 89;
			chk_Current_Acct_Rep.TabStop = true;
			chk_Current_Acct_Rep.Text = "Current Account Rep Only";
			chk_Current_Acct_Rep.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_Current_Acct_Rep.Visible = true;
			// 
			// chk_Date_Less_Than
			// 
			chk_Date_Less_Than.AllowDrop = true;
			chk_Date_Less_Than.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_Date_Less_Than.BackColor = System.Drawing.SystemColors.Control;
			chk_Date_Less_Than.CausesValidation = true;
			chk_Date_Less_Than.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_Date_Less_Than.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_Date_Less_Than.Enabled = true;
			chk_Date_Less_Than.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_Date_Less_Than.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_Date_Less_Than.Location = new System.Drawing.Point(819, 83);
			chk_Date_Less_Than.Name = "chk_Date_Less_Than";
			chk_Date_Less_Than.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_Date_Less_Than.Size = new System.Drawing.Size(112, 44);
			chk_Date_Less_Than.TabIndex = 88;
			chk_Date_Less_Than.TabStop = true;
			chk_Date_Less_Than.Text = "Dates Less Than or Equal to Callback Date";
			chk_Date_Less_Than.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_Date_Less_Than.Visible = true;
			// 
			// optFractionalOwners
			// 
			optFractionalOwners.AllowDrop = true;
			optFractionalOwners.BackColor = System.Drawing.SystemColors.Control;
			optFractionalOwners.CausesValidation = true;
			optFractionalOwners.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			optFractionalOwners.Checked = true;
			optFractionalOwners.Enabled = true;
			optFractionalOwners.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			optFractionalOwners.ForeColor = System.Drawing.SystemColors.ControlText;
			optFractionalOwners.Location = new System.Drawing.Point(819, 142);
			optFractionalOwners.Name = "optFractionalOwners";
			optFractionalOwners.RightToLeft = System.Windows.Forms.RightToLeft.No;
			optFractionalOwners.Size = new System.Drawing.Size(136, 13);
			optFractionalOwners.TabIndex = 87;
			optFractionalOwners.TabStop = true;
			optFractionalOwners.Text = "View Fractional Owners";
			optFractionalOwners.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			optFractionalOwners.Visible = true;
			optFractionalOwners.CheckedChanged += new System.EventHandler(optFractionalOwners_CheckedChanged);
			// 
			// optBadFractions
			// 
			optBadFractions.AllowDrop = true;
			optBadFractions.BackColor = System.Drawing.SystemColors.Control;
			optBadFractions.CausesValidation = true;
			optBadFractions.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			optBadFractions.Checked = false;
			optBadFractions.Enabled = true;
			optBadFractions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			optBadFractions.ForeColor = System.Drawing.SystemColors.ControlText;
			optBadFractions.Location = new System.Drawing.Point(819, 170);
			optBadFractions.Name = "optBadFractions";
			optBadFractions.RightToLeft = System.Windows.Forms.RightToLeft.No;
			optBadFractions.Size = new System.Drawing.Size(136, 13);
			optBadFractions.TabIndex = 86;
			optBadFractions.TabStop = true;
			optBadFractions.Text = "View Problem Fractions";
			optBadFractions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			optBadFractions.Visible = true;
			optBadFractions.CheckedChanged += new System.EventHandler(optBadFractions_CheckedChanged);
			// 
			// opt_OwnersPendingSale
			// 
			opt_OwnersPendingSale.AllowDrop = true;
			opt_OwnersPendingSale.BackColor = System.Drawing.SystemColors.Control;
			opt_OwnersPendingSale.CausesValidation = true;
			opt_OwnersPendingSale.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opt_OwnersPendingSale.Checked = false;
			opt_OwnersPendingSale.Enabled = true;
			opt_OwnersPendingSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			opt_OwnersPendingSale.ForeColor = System.Drawing.SystemColors.ControlText;
			opt_OwnersPendingSale.Location = new System.Drawing.Point(819, 198);
			opt_OwnersPendingSale.Name = "opt_OwnersPendingSale";
			opt_OwnersPendingSale.RightToLeft = System.Windows.Forms.RightToLeft.No;
			opt_OwnersPendingSale.Size = new System.Drawing.Size(128, 29);
			opt_OwnersPendingSale.TabIndex = 85;
			opt_OwnersPendingSale.TabStop = true;
			opt_OwnersPendingSale.Text = "View Fractional Owners Pending Sale";
			opt_OwnersPendingSale.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opt_OwnersPendingSale.Visible = true;
			opt_OwnersPendingSale.CheckedChanged += new System.EventHandler(opt_OwnersPendingSale_CheckedChanged);
			// 
			// Opt_Reassigned
			// 
			Opt_Reassigned.AllowDrop = true;
			Opt_Reassigned.BackColor = System.Drawing.SystemColors.Control;
			Opt_Reassigned.CausesValidation = true;
			Opt_Reassigned.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			Opt_Reassigned.Checked = false;
			Opt_Reassigned.Enabled = true;
			Opt_Reassigned.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Opt_Reassigned.ForeColor = System.Drawing.SystemColors.ControlText;
			Opt_Reassigned.Location = new System.Drawing.Point(819, 242);
			Opt_Reassigned.Name = "Opt_Reassigned";
			Opt_Reassigned.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Opt_Reassigned.Size = new System.Drawing.Size(116, 21);
			Opt_Reassigned.TabIndex = 84;
			Opt_Reassigned.TabStop = true;
			Opt_Reassigned.Text = "View Re-assigned ";
			Opt_Reassigned.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			Opt_Reassigned.Visible = true;
			Opt_Reassigned.CheckedChanged += new System.EventHandler(Opt_Reassigned_CheckedChanged);
			// 
			// cmd_ClearFractionalReassign
			// 
			cmd_ClearFractionalReassign.AllowDrop = true;
			cmd_ClearFractionalReassign.BackColor = System.Drawing.SystemColors.Control;
			cmd_ClearFractionalReassign.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_ClearFractionalReassign.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_ClearFractionalReassign.Location = new System.Drawing.Point(833, 329);
			cmd_ClearFractionalReassign.Name = "cmd_ClearFractionalReassign";
			cmd_ClearFractionalReassign.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_ClearFractionalReassign.Size = new System.Drawing.Size(102, 33);
			cmd_ClearFractionalReassign.TabIndex = 83;
			cmd_ClearFractionalReassign.Text = "Clear Fractional Reassign";
			cmd_ClearFractionalReassign.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_ClearFractionalReassign.UseVisualStyleBackColor = false;
			cmd_ClearFractionalReassign.Visible = false;
			cmd_ClearFractionalReassign.Click += new System.EventHandler(cmd_ClearFractionalReassign_Click);
			// 
			// Opt_FracWithPrimaryWhole
			// 
			Opt_FracWithPrimaryWhole.AllowDrop = true;
			Opt_FracWithPrimaryWhole.BackColor = System.Drawing.SystemColors.Control;
			Opt_FracWithPrimaryWhole.CausesValidation = true;
			Opt_FracWithPrimaryWhole.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			Opt_FracWithPrimaryWhole.Checked = false;
			Opt_FracWithPrimaryWhole.Enabled = true;
			Opt_FracWithPrimaryWhole.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Opt_FracWithPrimaryWhole.ForeColor = System.Drawing.SystemColors.ControlText;
			Opt_FracWithPrimaryWhole.Location = new System.Drawing.Point(819, 277);
			Opt_FracWithPrimaryWhole.Name = "Opt_FracWithPrimaryWhole";
			Opt_FracWithPrimaryWhole.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Opt_FracWithPrimaryWhole.Size = new System.Drawing.Size(134, 37);
			Opt_FracWithPrimaryWhole.TabIndex = 82;
			Opt_FracWithPrimaryWhole.TabStop = true;
			Opt_FracWithPrimaryWhole.Text = "Fractional Company wtih Primary on whole/share not PH";
			Opt_FracWithPrimaryWhole.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			Opt_FracWithPrimaryWhole.Visible = true;
			Opt_FracWithPrimaryWhole.CheckedChanged += new System.EventHandler(Opt_FracWithPrimaryWhole_CheckedChanged);
			// 
			// pnl_fractional_display
			// 
			pnl_fractional_display.AllowDrop = true;
			pnl_fractional_display.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_fractional_display.Controls.Add(txt_Total_Comp_Callbacks);
			pnl_fractional_display.Controls.Add(grdFractional);
			pnl_fractional_display.Controls.Add(Label15);
			pnl_fractional_display.Controls.Add(lbl_fract_col5);
			pnl_fractional_display.Controls.Add(Label9);
			pnl_fractional_display.Controls.Add(Label8);
			pnl_fractional_display.Controls.Add(Label1);
			pnl_fractional_display.Controls.Add(_lbl_gen_14);
			pnl_fractional_display.Controls.Add(lbl_fract_col6);
			pnl_fractional_display.Controls.Add(lbl_fract_col7);
			pnl_fractional_display.Controls.Add(lbl_fract_col8);
			pnl_fractional_display.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_fractional_display.Location = new System.Drawing.Point(6, 9);
			pnl_fractional_display.Name = "pnl_fractional_display";
			pnl_fractional_display.Size = new System.Drawing.Size(809, 360);
			pnl_fractional_display.TabIndex = 70;
			// 
			// txt_Total_Comp_Callbacks
			// 
			txt_Total_Comp_Callbacks.AcceptsReturn = true;
			txt_Total_Comp_Callbacks.AllowDrop = true;
			txt_Total_Comp_Callbacks.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_Total_Comp_Callbacks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_Total_Comp_Callbacks.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_Total_Comp_Callbacks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_Total_Comp_Callbacks.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_Total_Comp_Callbacks.Location = new System.Drawing.Point(140, 331);
			txt_Total_Comp_Callbacks.MaxLength = 0;
			txt_Total_Comp_Callbacks.Name = "txt_Total_Comp_Callbacks";
			txt_Total_Comp_Callbacks.ReadOnly = true;
			txt_Total_Comp_Callbacks.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_Total_Comp_Callbacks.Size = new System.Drawing.Size(57, 19);
			txt_Total_Comp_Callbacks.TabIndex = 71;
			txt_Total_Comp_Callbacks.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// grdFractional
			// 
			grdFractional.AllowDrop = true;
			grdFractional.AllowUserToAddRows = false;
			grdFractional.AllowUserToDeleteRows = false;
			grdFractional.AllowUserToResizeColumns = false;
			grdFractional.AllowUserToResizeRows = false;
			grdFractional.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grdFractional.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grdFractional.ColumnsCount = 2;
			grdFractional.FixedColumns = 0;
			grdFractional.FixedRows = 0;
			grdFractional.Location = new System.Drawing.Point(4, 23);
			grdFractional.Name = "grdFractional";
			grdFractional.ReadOnly = true;
			grdFractional.RowsCount = 2;
			grdFractional.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grdFractional.ShowCellToolTips = false;
			grdFractional.Size = new System.Drawing.Size(800, 302);
			grdFractional.StandardTab = true;
			grdFractional.TabIndex = 72;
			grdFractional.Click += new System.EventHandler(grdFractional_Click);
			grdFractional.DoubleClick += new System.EventHandler(grdFractional_DoubleClick);
			// 
			// Label15
			// 
			Label15.AllowDrop = true;
			Label15.BackColor = System.Drawing.Color.Transparent;
			Label15.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label15.ForeColor = System.Drawing.SystemColors.ControlText;
			Label15.Location = new System.Drawing.Point(491, 8);
			Label15.MinimumSize = new System.Drawing.Size(41, 477);
			Label15.Name = "Label15";
			Label15.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label15.Size = new System.Drawing.Size(41, 477);
			Label15.TabIndex = 81;
			Label15.Text = "State";
			Label15.Click += new System.EventHandler(Label15_Click);
			// 
			// lbl_fract_col5
			// 
			lbl_fract_col5.AllowDrop = true;
			lbl_fract_col5.BackColor = System.Drawing.Color.Transparent;
			lbl_fract_col5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_fract_col5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_fract_col5.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_fract_col5.Location = new System.Drawing.Point(539, 8);
			lbl_fract_col5.MinimumSize = new System.Drawing.Size(73, 479);
			lbl_fract_col5.Name = "lbl_fract_col5";
			lbl_fract_col5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_fract_col5.Size = new System.Drawing.Size(73, 479);
			lbl_fract_col5.TabIndex = 80;
			lbl_fract_col5.Text = "Time Zone";
			lbl_fract_col5.Click += new System.EventHandler(lbl_fract_col5_Click);
			// 
			// Label9
			// 
			Label9.AllowDrop = true;
			Label9.BackColor = System.Drawing.Color.Transparent;
			Label9.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label9.ForeColor = System.Drawing.SystemColors.ControlText;
			Label9.Location = new System.Drawing.Point(5, 8);
			Label9.MinimumSize = new System.Drawing.Size(33, 477);
			Label9.Name = "Label9";
			Label9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label9.Size = new System.Drawing.Size(33, 477);
			Label9.TabIndex = 79;
			Label9.Text = "Date";
			Label9.Click += new System.EventHandler(Label9_Click);
			// 
			// Label8
			// 
			Label8.AllowDrop = true;
			Label8.BackColor = System.Drawing.Color.Transparent;
			Label8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label8.ForeColor = System.Drawing.SystemColors.ControlText;
			Label8.Location = new System.Drawing.Point(349, 8);
			Label8.MinimumSize = new System.Drawing.Size(113, 477);
			Label8.Name = "Label8";
			Label8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label8.Size = new System.Drawing.Size(113, 477);
			Label8.TabIndex = 78;
			Label8.Text = "Location";
			Label8.Click += new System.EventHandler(Label8_Click);
			// 
			// Label1
			// 
			Label1.AllowDrop = true;
			Label1.AutoSize = true;
			Label1.BackColor = System.Drawing.SystemColors.Control;
			Label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label1.ForeColor = System.Drawing.SystemColors.ControlText;
			Label1.Location = new System.Drawing.Point(63, 8);
			Label1.MinimumSize = new System.Drawing.Size(44, 13);
			Label1.Name = "Label1";
			Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label1.Size = new System.Drawing.Size(44, 13);
			Label1.TabIndex = 77;
			Label1.Text = "Company";
			Label1.Click += new System.EventHandler(Label1_Click);
			// 
			// _lbl_gen_14
			// 
			_lbl_gen_14.AllowDrop = true;
			_lbl_gen_14.AutoSize = true;
			_lbl_gen_14.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_14.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_14.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_14.Location = new System.Drawing.Point(8, 333);
			_lbl_gen_14.MinimumSize = new System.Drawing.Size(116, 13);
			_lbl_gen_14.Name = "_lbl_gen_14";
			_lbl_gen_14.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_14.Size = new System.Drawing.Size(116, 13);
			_lbl_gen_14.TabIndex = 76;
			_lbl_gen_14.Text = "Total Fractional Owners:";
			_lbl_gen_14.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// lbl_fract_col6
			// 
			lbl_fract_col6.AllowDrop = true;
			lbl_fract_col6.BackColor = System.Drawing.Color.Transparent;
			lbl_fract_col6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_fract_col6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_fract_col6.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_fract_col6.Location = new System.Drawing.Point(603, 8);
			lbl_fract_col6.MinimumSize = new System.Drawing.Size(113, 17);
			lbl_fract_col6.Name = "lbl_fract_col6";
			lbl_fract_col6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_fract_col6.Size = new System.Drawing.Size(113, 17);
			lbl_fract_col6.TabIndex = 75;
			lbl_fract_col6.Text = "# Aircraft";
			lbl_fract_col6.Click += new System.EventHandler(lbl_fract_col6_Click);
			// 
			// lbl_fract_col7
			// 
			lbl_fract_col7.AllowDrop = true;
			lbl_fract_col7.BackColor = System.Drawing.Color.Transparent;
			lbl_fract_col7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_fract_col7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_fract_col7.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_fract_col7.Location = new System.Drawing.Point(656, 8);
			lbl_fract_col7.MinimumSize = new System.Drawing.Size(57, 17);
			lbl_fract_col7.Name = "lbl_fract_col7";
			lbl_fract_col7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_fract_col7.Size = new System.Drawing.Size(57, 17);
			lbl_fract_col7.TabIndex = 74;
			lbl_fract_col7.Text = "Column7";
			// 
			// lbl_fract_col8
			// 
			lbl_fract_col8.AllowDrop = true;
			lbl_fract_col8.BackColor = System.Drawing.Color.Transparent;
			lbl_fract_col8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_fract_col8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_fract_col8.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_fract_col8.Location = new System.Drawing.Point(712, 8);
			lbl_fract_col8.MinimumSize = new System.Drawing.Size(57, 17);
			lbl_fract_col8.Name = "lbl_fract_col8";
			lbl_fract_col8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_fract_col8.Size = new System.Drawing.Size(57, 17);
			lbl_fract_col8.TabIndex = 73;
			lbl_fract_col8.Text = "Column8";
			// 
			// pnlFractionalPercentagesBad
			// 
			pnlFractionalPercentagesBad.AllowDrop = true;
			pnlFractionalPercentagesBad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnlFractionalPercentagesBad.Controls.Add(txt_total_bad_fractional);
			pnlFractionalPercentagesBad.Controls.Add(grdBadFractions);
			pnlFractionalPercentagesBad.Controls.Add(lbl_6);
			pnlFractionalPercentagesBad.Controls.Add(Label12);
			pnlFractionalPercentagesBad.Controls.Add(Label13);
			pnlFractionalPercentagesBad.Controls.Add(Label16);
			pnlFractionalPercentagesBad.Controls.Add(Label19);
			pnlFractionalPercentagesBad.Controls.Add(Label6);
			pnlFractionalPercentagesBad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnlFractionalPercentagesBad.Location = new System.Drawing.Point(6, 9);
			pnlFractionalPercentagesBad.Name = "pnlFractionalPercentagesBad";
			pnlFractionalPercentagesBad.Size = new System.Drawing.Size(761, 360);
			pnlFractionalPercentagesBad.TabIndex = 91;
			pnlFractionalPercentagesBad.Visible = false;
			// 
			// txt_total_bad_fractional
			// 
			txt_total_bad_fractional.AcceptsReturn = true;
			txt_total_bad_fractional.AllowDrop = true;
			txt_total_bad_fractional.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_total_bad_fractional.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_total_bad_fractional.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_total_bad_fractional.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_total_bad_fractional.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_total_bad_fractional.Location = new System.Drawing.Point(140, 344);
			txt_total_bad_fractional.MaxLength = 0;
			txt_total_bad_fractional.Name = "txt_total_bad_fractional";
			txt_total_bad_fractional.ReadOnly = true;
			txt_total_bad_fractional.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_total_bad_fractional.Size = new System.Drawing.Size(57, 19);
			txt_total_bad_fractional.TabIndex = 93;
			txt_total_bad_fractional.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// grdBadFractions
			// 
			grdBadFractions.AllowDrop = true;
			grdBadFractions.AllowUserToAddRows = false;
			grdBadFractions.AllowUserToDeleteRows = false;
			grdBadFractions.AllowUserToResizeColumns = false;
			grdBadFractions.AllowUserToResizeRows = false;
			grdBadFractions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grdBadFractions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grdBadFractions.ColumnsCount = 2;
			grdBadFractions.FixedColumns = 0;
			grdBadFractions.FixedRows = 0;
			grdBadFractions.Location = new System.Drawing.Point(8, 32);
			grdBadFractions.Name = "grdBadFractions";
			grdBadFractions.ReadOnly = true;
			grdBadFractions.RowsCount = 2;
			grdBadFractions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grdBadFractions.ShowCellToolTips = false;
			grdBadFractions.Size = new System.Drawing.Size(748, 303);
			grdBadFractions.StandardTab = true;
			grdBadFractions.TabIndex = 92;
			grdBadFractions.DoubleClick += new System.EventHandler(grdBadFractions_DoubleClick);
			// 
			// lbl_6
			// 
			lbl_6.AllowDrop = true;
			lbl_6.AutoSize = true;
			lbl_6.BackColor = System.Drawing.Color.Transparent;
			lbl_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_6.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_6.Location = new System.Drawing.Point(8, 349);
			lbl_6.MinimumSize = new System.Drawing.Size(104, 13);
			lbl_6.Name = "lbl_6";
			lbl_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_6.Size = new System.Drawing.Size(104, 13);
			lbl_6.TabIndex = 99;
			lbl_6.Text = "Total Bad Fractionals:";
			// 
			// Label12
			// 
			Label12.AllowDrop = true;
			Label12.AutoSize = true;
			Label12.BackColor = System.Drawing.SystemColors.Control;
			Label12.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label12.ForeColor = System.Drawing.SystemColors.ControlText;
			Label12.Location = new System.Drawing.Point(96, 10);
			Label12.MinimumSize = new System.Drawing.Size(29, 13);
			Label12.Name = "Label12";
			Label12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label12.Size = new System.Drawing.Size(29, 13);
			Label12.TabIndex = 98;
			Label12.Text = "Model";
			// 
			// Label13
			// 
			Label13.AllowDrop = true;
			Label13.AutoSize = true;
			Label13.BackColor = System.Drawing.Color.Transparent;
			Label13.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label13.ForeColor = System.Drawing.SystemColors.ControlText;
			Label13.Location = new System.Drawing.Point(151, 10);
			Label13.MinimumSize = new System.Drawing.Size(36, 13);
			Label13.Name = "Label13";
			Label13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label13.Size = new System.Drawing.Size(36, 13);
			Label13.TabIndex = 97;
			Label13.Text = "Serial #";
			// 
			// Label16
			// 
			Label16.AllowDrop = true;
			Label16.AutoSize = true;
			Label16.BackColor = System.Drawing.Color.Transparent;
			Label16.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label16.ForeColor = System.Drawing.SystemColors.ControlText;
			Label16.Location = new System.Drawing.Point(17, 10);
			Label16.MinimumSize = new System.Drawing.Size(27, 13);
			Label16.Name = "Label16";
			Label16.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label16.Size = new System.Drawing.Size(27, 13);
			Label16.TabIndex = 96;
			Label16.Text = "Make";
			// 
			// Label19
			// 
			Label19.AllowDrop = true;
			Label19.AutoSize = true;
			Label19.BackColor = System.Drawing.Color.Transparent;
			Label19.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label19.ForeColor = System.Drawing.SystemColors.ControlText;
			Label19.Location = new System.Drawing.Point(212, 10);
			Label19.MinimumSize = new System.Drawing.Size(30, 13);
			Label19.Name = "Label19";
			Label19.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label19.Size = new System.Drawing.Size(30, 13);
			Label19.TabIndex = 95;
			Label19.Text = "Reg #";
			// 
			// Label6
			// 
			Label6.AllowDrop = true;
			Label6.BackColor = System.Drawing.SystemColors.Control;
			Label6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label6.ForeColor = System.Drawing.SystemColors.ControlText;
			Label6.Location = new System.Drawing.Point(270, 14);
			Label6.MinimumSize = new System.Drawing.Size(25, 12);
			Label6.Name = "Label6";
			Label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label6.Size = new System.Drawing.Size(25, 12);
			Label6.TabIndex = 94;
			Label6.Text = "%";
			// 
			// lblFractionalMessage
			// 
			lblFractionalMessage.AllowDrop = true;
			lblFractionalMessage.BackColor = System.Drawing.SystemColors.Control;
			lblFractionalMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblFractionalMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 24f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblFractionalMessage.ForeColor = System.Drawing.Color.FromArgb(128, 64, 64);
			lblFractionalMessage.Location = new System.Drawing.Point(189, 222);
			lblFractionalMessage.MinimumSize = new System.Drawing.Size(579, 98);
			lblFractionalMessage.Name = "lblFractionalMessage";
			lblFractionalMessage.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblFractionalMessage.Size = new System.Drawing.Size(579, 98);
			lblFractionalMessage.TabIndex = 125;
			lblFractionalMessage.Text = "Getting Fractional Owners...";
			lblFractionalMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// _tab_callback_TabPage7
			// 
			_tab_callback_TabPage7.Controls.Add(chk_Account_Rep_Wanted);
			_tab_callback_TabPage7.Controls.Add(txt_Tot_CompanyWanted);
			_tab_callback_TabPage7.Controls.Add(txt_Tot_Wanted);
			_tab_callback_TabPage7.Controls.Add(cmd_Refresh_Wanted);
			_tab_callback_TabPage7.Controls.Add(grd_WantedList);
			_tab_callback_TabPage7.Controls.Add(_lbl_gen_16);
			_tab_callback_TabPage7.Controls.Add(_lbl_gen_15);
			_tab_callback_TabPage7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_callback_TabPage7.Text = "Wanteds";
			// 
			// chk_Account_Rep_Wanted
			// 
			chk_Account_Rep_Wanted.AllowDrop = true;
			chk_Account_Rep_Wanted.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_Account_Rep_Wanted.BackColor = System.Drawing.SystemColors.Control;
			chk_Account_Rep_Wanted.CausesValidation = true;
			chk_Account_Rep_Wanted.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_Account_Rep_Wanted.CheckState = System.Windows.Forms.CheckState.Checked;
			chk_Account_Rep_Wanted.Enabled = true;
			chk_Account_Rep_Wanted.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_Account_Rep_Wanted.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_Account_Rep_Wanted.Location = new System.Drawing.Point(13, 7);
			chk_Account_Rep_Wanted.Name = "chk_Account_Rep_Wanted";
			chk_Account_Rep_Wanted.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_Account_Rep_Wanted.Size = new System.Drawing.Size(145, 20);
			chk_Account_Rep_Wanted.TabIndex = 68;
			chk_Account_Rep_Wanted.TabStop = true;
			chk_Account_Rep_Wanted.Text = "Current Account Rep Only";
			chk_Account_Rep_Wanted.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_Account_Rep_Wanted.Visible = true;
			chk_Account_Rep_Wanted.CheckStateChanged += new System.EventHandler(chk_Account_Rep_Wanted_CheckStateChanged);
			// 
			// txt_Tot_CompanyWanted
			// 
			txt_Tot_CompanyWanted.AcceptsReturn = true;
			txt_Tot_CompanyWanted.AllowDrop = true;
			txt_Tot_CompanyWanted.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_Tot_CompanyWanted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_Tot_CompanyWanted.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_Tot_CompanyWanted.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_Tot_CompanyWanted.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_Tot_CompanyWanted.Location = new System.Drawing.Point(179, 403);
			txt_Tot_CompanyWanted.MaxLength = 0;
			txt_Tot_CompanyWanted.Name = "txt_Tot_CompanyWanted";
			txt_Tot_CompanyWanted.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_Tot_CompanyWanted.Size = new System.Drawing.Size(57, 19);
			txt_Tot_CompanyWanted.TabIndex = 41;
			txt_Tot_CompanyWanted.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_Tot_Wanted
			// 
			txt_Tot_Wanted.AcceptsReturn = true;
			txt_Tot_Wanted.AllowDrop = true;
			txt_Tot_Wanted.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_Tot_Wanted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_Tot_Wanted.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_Tot_Wanted.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_Tot_Wanted.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_Tot_Wanted.Location = new System.Drawing.Point(452, 403);
			txt_Tot_Wanted.MaxLength = 0;
			txt_Tot_Wanted.Name = "txt_Tot_Wanted";
			txt_Tot_Wanted.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_Tot_Wanted.Size = new System.Drawing.Size(57, 19);
			txt_Tot_Wanted.TabIndex = 40;
			txt_Tot_Wanted.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// cmd_Refresh_Wanted
			// 
			cmd_Refresh_Wanted.AllowDrop = true;
			cmd_Refresh_Wanted.BackColor = System.Drawing.SystemColors.Control;
			cmd_Refresh_Wanted.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Refresh_Wanted.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Refresh_Wanted.Location = new System.Drawing.Point(256, 398);
			cmd_Refresh_Wanted.Name = "cmd_Refresh_Wanted";
			cmd_Refresh_Wanted.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Refresh_Wanted.Size = new System.Drawing.Size(78, 28);
			cmd_Refresh_Wanted.TabIndex = 39;
			cmd_Refresh_Wanted.Text = "&Refresh";
			cmd_Refresh_Wanted.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Refresh_Wanted.UseVisualStyleBackColor = false;
			cmd_Refresh_Wanted.Click += new System.EventHandler(cmd_Refresh_Wanted_Click);
			// 
			// grd_WantedList
			// 
			grd_WantedList.AllowDrop = true;
			grd_WantedList.AllowUserToAddRows = false;
			grd_WantedList.AllowUserToDeleteRows = false;
			grd_WantedList.AllowUserToResizeColumns = false;
			grd_WantedList.AllowUserToResizeColumns = grd_WantedList.ColumnHeadersVisible;
			grd_WantedList.AllowUserToResizeRows = false;
			grd_WantedList.AllowUserToResizeRows = false;
			grd_WantedList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grd_WantedList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_WantedList.ColumnsCount = 2;
			grd_WantedList.FixedColumns = 1;
			grd_WantedList.FixedRows = 1;
			grd_WantedList.Location = new System.Drawing.Point(9, 30);
			grd_WantedList.Name = "grd_WantedList";
			grd_WantedList.ReadOnly = true;
			grd_WantedList.RowsCount = 2;
			grd_WantedList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grd_WantedList.ShowCellToolTips = false;
			grd_WantedList.Size = new System.Drawing.Size(971, 363);
			grd_WantedList.StandardTab = true;
			grd_WantedList.TabIndex = 120;
			grd_WantedList.Click += new System.EventHandler(grd_WantedList_Click);
			grd_WantedList.DoubleClick += new System.EventHandler(grd_WantedList_DoubleClick);
			// 
			// _lbl_gen_16
			// 
			_lbl_gen_16.AllowDrop = true;
			_lbl_gen_16.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_16.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_16.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_16.Location = new System.Drawing.Point(357, 404);
			_lbl_gen_16.MinimumSize = new System.Drawing.Size(85, 17);
			_lbl_gen_16.Name = "_lbl_gen_16";
			_lbl_gen_16.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_16.Size = new System.Drawing.Size(85, 17);
			_lbl_gen_16.TabIndex = 123;
			_lbl_gen_16.Text = "Total of Wanteds:";
			_lbl_gen_16.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// _lbl_gen_15
			// 
			_lbl_gen_15.AllowDrop = true;
			_lbl_gen_15.AutoSize = true;
			_lbl_gen_15.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_15.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_15.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_15.Location = new System.Drawing.Point(12, 406);
			_lbl_gen_15.MinimumSize = new System.Drawing.Size(162, 13);
			_lbl_gen_15.Name = "_lbl_gen_15";
			_lbl_gen_15.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_15.Size = new System.Drawing.Size(162, 13);
			_lbl_gen_15.TabIndex = 122;
			_lbl_gen_15.Text = "Total Companies Wanting Aircraft:";
			_lbl_gen_15.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// _tab_callback_TabPage8
			// 
			_tab_callback_TabPage8.Controls.Add(cmdRefreshAvailAircraft);
			_tab_callback_TabPage8.Controls.Add(pnl_AvailableAircraft);
			_tab_callback_TabPage8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_callback_TabPage8.Text = "Availables";
			// 
			// cmdRefreshAvailAircraft
			// 
			cmdRefreshAvailAircraft.AllowDrop = true;
			cmdRefreshAvailAircraft.BackColor = System.Drawing.SystemColors.Control;
			cmdRefreshAvailAircraft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdRefreshAvailAircraft.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdRefreshAvailAircraft.Location = new System.Drawing.Point(746, 416);
			cmdRefreshAvailAircraft.Name = "cmdRefreshAvailAircraft";
			cmdRefreshAvailAircraft.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdRefreshAvailAircraft.Size = new System.Drawing.Size(66, 22);
			cmdRefreshAvailAircraft.TabIndex = 64;
			cmdRefreshAvailAircraft.Text = "&Refresh";
			cmdRefreshAvailAircraft.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdRefreshAvailAircraft.UseVisualStyleBackColor = false;
			cmdRefreshAvailAircraft.Click += new System.EventHandler(cmdRefreshAvailAircraft_Click);
			// 
			// pnl_AvailableAircraft
			// 
			pnl_AvailableAircraft.AllowDrop = true;
			pnl_AvailableAircraft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_AvailableAircraft.Controls.Add(grd_AvailableAircraft);
			pnl_AvailableAircraft.Controls.Add(lblAvailACTotal);
			pnl_AvailableAircraft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_AvailableAircraft.Location = new System.Drawing.Point(11, 10);
			pnl_AvailableAircraft.Name = "pnl_AvailableAircraft";
			pnl_AvailableAircraft.Size = new System.Drawing.Size(885, 400);
			pnl_AvailableAircraft.TabIndex = 65;
			// 
			// grd_AvailableAircraft
			// 
			grd_AvailableAircraft.AllowDrop = true;
			grd_AvailableAircraft.AllowUserToAddRows = false;
			grd_AvailableAircraft.AllowUserToDeleteRows = false;
			grd_AvailableAircraft.AllowUserToResizeColumns = false;
			grd_AvailableAircraft.AllowUserToResizeColumns = grd_AvailableAircraft.ColumnHeadersVisible;
			grd_AvailableAircraft.AllowUserToResizeRows = false;
			grd_AvailableAircraft.AllowUserToResizeRows = false;
			grd_AvailableAircraft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grd_AvailableAircraft.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_AvailableAircraft.ColumnsCount = 2;
			grd_AvailableAircraft.FixedColumns = 0;
			grd_AvailableAircraft.FixedRows = 0;
			grd_AvailableAircraft.Location = new System.Drawing.Point(16, 21);
			grd_AvailableAircraft.Name = "grd_AvailableAircraft";
			grd_AvailableAircraft.ReadOnly = true;
			grd_AvailableAircraft.RowsCount = 2;
			grd_AvailableAircraft.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grd_AvailableAircraft.ShowCellToolTips = false;
			grd_AvailableAircraft.Size = new System.Drawing.Size(843, 355);
			grd_AvailableAircraft.StandardTab = true;
			grd_AvailableAircraft.TabIndex = 66;
			grd_AvailableAircraft.Click += new System.EventHandler(grd_AvailableAircraft_Click);
			grd_AvailableAircraft.DoubleClick += new System.EventHandler(grd_AvailableAircraft_DoubleClick);
			// 
			// lblAvailACTotal
			// 
			lblAvailACTotal.AllowDrop = true;
			lblAvailACTotal.AutoSize = true;
			lblAvailACTotal.BackColor = System.Drawing.SystemColors.Control;
			lblAvailACTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblAvailACTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblAvailACTotal.ForeColor = System.Drawing.SystemColors.ControlText;
			lblAvailACTotal.Location = new System.Drawing.Point(680, 380);
			lblAvailACTotal.MinimumSize = new System.Drawing.Size(30, 13);
			lblAvailACTotal.Name = "lblAvailACTotal";
			lblAvailACTotal.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblAvailACTotal.Size = new System.Drawing.Size(30, 13);
			lblAvailACTotal.TabIndex = 67;
			lblAvailACTotal.Text = "Total: ";
			// 
			// _tab_callback_TabPage9
			// 
			_tab_callback_TabPage9.Controls.Add(_chk_action_list_13);
			_tab_callback_TabPage9.Controls.Add(_cmd_export_docs_2);
			_tab_callback_TabPage9.Controls.Add(_chk_action_list_12);
			_tab_callback_TabPage9.Controls.Add(_cmd_export_docs_0);
			_tab_callback_TabPage9.Controls.Add(chk_compact);
			_tab_callback_TabPage9.Controls.Add(cmbDocType);
			_tab_callback_TabPage9.Controls.Add(cmbDocInProcsClass);
			_tab_callback_TabPage9.Controls.Add(chk_AllDocuments);
			_tab_callback_TabPage9.Controls.Add(cmd_DocsInProcessRefresh);
			_tab_callback_TabPage9.Controls.Add(chkAttachedDocs);
			_tab_callback_TabPage9.Controls.Add(chkResponses);
			_tab_callback_TabPage9.Controls.Add(grd_DocumentLog);
			_tab_callback_TabPage9.Controls.Add(_lbl_gen_36);
			_tab_callback_TabPage9.Controls.Add(lblClass);
			_tab_callback_TabPage9.Controls.Add(lbl_Documents_In_Process);
			_tab_callback_TabPage9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_callback_TabPage9.Text = "Documents in Process";
			// 
			// _chk_action_list_13
			// 
			_chk_action_list_13.AllowDrop = true;
			_chk_action_list_13.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_action_list_13.BackColor = System.Drawing.SystemColors.Control;
			_chk_action_list_13.CausesValidation = true;
			_chk_action_list_13.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_action_list_13.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_action_list_13.Enabled = true;
			_chk_action_list_13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_action_list_13.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_action_list_13.Location = new System.Drawing.Point(16, 431);
			_chk_action_list_13.Name = "_chk_action_list_13";
			_chk_action_list_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_action_list_13.Size = new System.Drawing.Size(145, 13);
			_chk_action_list_13.TabIndex = 272;
			_chk_action_list_13.TabStop = true;
			_chk_action_list_13.Text = "Show Class E Aircraft";
			_chk_action_list_13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_action_list_13.Visible = true;
			_chk_action_list_13.CheckStateChanged += new System.EventHandler(chk_action_list_CheckStateChanged);
			// 
			// _cmd_export_docs_2
			// 
			_cmd_export_docs_2.AllowDrop = true;
			_cmd_export_docs_2.BackColor = System.Drawing.SystemColors.Control;
			_cmd_export_docs_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_export_docs_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_export_docs_2.Location = new System.Drawing.Point(376, 406);
			_cmd_export_docs_2.Name = "_cmd_export_docs_2";
			_cmd_export_docs_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_export_docs_2.Size = new System.Drawing.Size(78, 20);
			_cmd_export_docs_2.TabIndex = 268;
			_cmd_export_docs_2.Text = "Export Dups";
			_cmd_export_docs_2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_export_docs_2.UseVisualStyleBackColor = false;
			_cmd_export_docs_2.Click += new System.EventHandler(cmd_export_docs_Click);
			// 
			// _chk_action_list_12
			// 
			_chk_action_list_12.AllowDrop = true;
			_chk_action_list_12.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_action_list_12.BackColor = System.Drawing.SystemColors.Control;
			_chk_action_list_12.CausesValidation = true;
			_chk_action_list_12.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_action_list_12.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_action_list_12.Enabled = true;
			_chk_action_list_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_action_list_12.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_action_list_12.Location = new System.Drawing.Point(528, 12);
			_chk_action_list_12.Name = "_chk_action_list_12";
			_chk_action_list_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_action_list_12.Size = new System.Drawing.Size(105, 13);
			_chk_action_list_12.TabIndex = 254;
			_chk_action_list_12.TabStop = true;
			_chk_action_list_12.Text = "Top 10 Models";
			_chk_action_list_12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_action_list_12.Visible = true;
			_chk_action_list_12.CheckStateChanged += new System.EventHandler(chk_action_list_CheckStateChanged);
			// 
			// _cmd_export_docs_0
			// 
			_cmd_export_docs_0.AllowDrop = true;
			_cmd_export_docs_0.BackColor = System.Drawing.SystemColors.Control;
			_cmd_export_docs_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_export_docs_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_export_docs_0.Location = new System.Drawing.Point(272, 406);
			_cmd_export_docs_0.Name = "_cmd_export_docs_0";
			_cmd_export_docs_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_export_docs_0.Size = new System.Drawing.Size(78, 20);
			_cmd_export_docs_0.TabIndex = 243;
			_cmd_export_docs_0.Text = "Export";
			_cmd_export_docs_0.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_export_docs_0.UseVisualStyleBackColor = false;
			_cmd_export_docs_0.Click += new System.EventHandler(cmd_export_docs_Click);
			// 
			// chk_compact
			// 
			chk_compact.AllowDrop = true;
			chk_compact.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_compact.BackColor = System.Drawing.SystemColors.Control;
			chk_compact.CausesValidation = true;
			chk_compact.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_compact.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_compact.Enabled = true;
			chk_compact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_compact.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_compact.Location = new System.Drawing.Point(16, 400);
			chk_compact.Name = "chk_compact";
			chk_compact.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_compact.Size = new System.Drawing.Size(89, 13);
			chk_compact.TabIndex = 242;
			chk_compact.TabStop = true;
			chk_compact.Text = "Compact View";
			chk_compact.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_compact.Visible = true;
			chk_compact.MouseDown += new System.Windows.Forms.MouseEventHandler(chk_compact_MouseDown);
			// 
			// cmbDocType
			// 
			cmbDocType.AllowDrop = true;
			cmbDocType.BackColor = System.Drawing.SystemColors.Window;
			cmbDocType.CausesValidation = true;
			cmbDocType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cmbDocType.Enabled = true;
			cmbDocType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmbDocType.ForeColor = System.Drawing.SystemColors.WindowText;
			cmbDocType.IntegralHeight = true;
			cmbDocType.Location = new System.Drawing.Point(576, 410);
			cmbDocType.Name = "cmbDocType";
			cmbDocType.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmbDocType.Size = new System.Drawing.Size(318, 21);
			cmbDocType.Sorted = false;
			cmbDocType.TabIndex = 210;
			cmbDocType.TabStop = true;
			cmbDocType.Visible = false;
			cmbDocType.SelectedIndexChanged += new System.EventHandler(cmbDocType_SelectedIndexChanged);
			// 
			// cmbDocInProcsClass
			// 
			cmbDocInProcsClass.AllowDrop = true;
			cmbDocInProcsClass.BackColor = System.Drawing.SystemColors.Window;
			cmbDocInProcsClass.CausesValidation = true;
			cmbDocInProcsClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cmbDocInProcsClass.Enabled = true;
			cmbDocInProcsClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmbDocInProcsClass.ForeColor = System.Drawing.SystemColors.WindowText;
			cmbDocInProcsClass.IntegralHeight = true;
			cmbDocInProcsClass.Location = new System.Drawing.Point(696, 8);
			cmbDocInProcsClass.Name = "cmbDocInProcsClass";
			cmbDocInProcsClass.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmbDocInProcsClass.Size = new System.Drawing.Size(71, 21);
			cmbDocInProcsClass.Sorted = false;
			cmbDocInProcsClass.TabIndex = 43;
			cmbDocInProcsClass.TabStop = true;
			cmbDocInProcsClass.Text = "All";
			cmbDocInProcsClass.Visible = true;
			// 
			// chk_AllDocuments
			// 
			chk_AllDocuments.AllowDrop = true;
			chk_AllDocuments.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_AllDocuments.BackColor = System.Drawing.SystemColors.Control;
			chk_AllDocuments.CausesValidation = true;
			chk_AllDocuments.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_AllDocuments.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_AllDocuments.Enabled = true;
			chk_AllDocuments.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_AllDocuments.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_AllDocuments.Location = new System.Drawing.Point(10, 9);
			chk_AllDocuments.Name = "chk_AllDocuments";
			chk_AllDocuments.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_AllDocuments.Size = new System.Drawing.Size(148, 18);
			chk_AllDocuments.TabIndex = 61;
			chk_AllDocuments.TabStop = true;
			chk_AllDocuments.Text = "All Docs (ignore Acct Rep)";
			chk_AllDocuments.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_AllDocuments.Visible = true;
			chk_AllDocuments.CheckStateChanged += new System.EventHandler(chk_AllDocuments_CheckStateChanged);
			// 
			// cmd_DocsInProcessRefresh
			// 
			cmd_DocsInProcessRefresh.AllowDrop = true;
			cmd_DocsInProcessRefresh.BackColor = System.Drawing.SystemColors.Control;
			cmd_DocsInProcessRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_DocsInProcessRefresh.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_DocsInProcessRefresh.Location = new System.Drawing.Point(120, 406);
			cmd_DocsInProcessRefresh.Name = "cmd_DocsInProcessRefresh";
			cmd_DocsInProcessRefresh.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_DocsInProcessRefresh.Size = new System.Drawing.Size(78, 20);
			cmd_DocsInProcessRefresh.TabIndex = 60;
			cmd_DocsInProcessRefresh.Text = "&Refresh";
			cmd_DocsInProcessRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_DocsInProcessRefresh.UseVisualStyleBackColor = false;
			cmd_DocsInProcessRefresh.Click += new System.EventHandler(cmd_DocsInProcessRefresh_Click);
			// 
			// chkAttachedDocs
			// 
			chkAttachedDocs.AllowDrop = true;
			chkAttachedDocs.Appearance = System.Windows.Forms.Appearance.Normal;
			chkAttachedDocs.BackColor = System.Drawing.SystemColors.Control;
			chkAttachedDocs.CausesValidation = true;
			chkAttachedDocs.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkAttachedDocs.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkAttachedDocs.Enabled = true;
			chkAttachedDocs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkAttachedDocs.ForeColor = System.Drawing.SystemColors.ControlText;
			chkAttachedDocs.Location = new System.Drawing.Point(160, 9);
			chkAttachedDocs.Name = "chkAttachedDocs";
			chkAttachedDocs.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkAttachedDocs.Size = new System.Drawing.Size(268, 18);
			chkAttachedDocs.TabIndex = 45;
			chkAttachedDocs.TabStop = true;
			chkAttachedDocs.Text = "Docs Already Attached (On or After Date Specified)";
			chkAttachedDocs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkAttachedDocs.Visible = true;
			chkAttachedDocs.CheckStateChanged += new System.EventHandler(chkAttachedDocs_CheckStateChanged);
			// 
			// chkResponses
			// 
			chkResponses.AllowDrop = true;
			chkResponses.Appearance = System.Windows.Forms.Appearance.Normal;
			chkResponses.BackColor = System.Drawing.SystemColors.Control;
			chkResponses.CausesValidation = true;
			chkResponses.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkResponses.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkResponses.Enabled = true;
			chkResponses.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkResponses.ForeColor = System.Drawing.SystemColors.ControlText;
			chkResponses.Location = new System.Drawing.Point(427, 9);
			chkResponses.Name = "chkResponses";
			chkResponses.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkResponses.Size = new System.Drawing.Size(99, 18);
			chkResponses.TabIndex = 42;
			chkResponses.TabStop = true;
			chkResponses.Text = "Doc Responses ";
			chkResponses.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkResponses.Visible = true;
			chkResponses.CheckStateChanged += new System.EventHandler(chkResponses_CheckStateChanged);
			// 
			// grd_DocumentLog
			// 
			grd_DocumentLog.AllowDrop = true;
			grd_DocumentLog.AllowUserToAddRows = false;
			grd_DocumentLog.AllowUserToDeleteRows = false;
			grd_DocumentLog.AllowUserToResizeColumns = false;
			grd_DocumentLog.AllowUserToResizeColumns = grd_DocumentLog.ColumnHeadersVisible;
			grd_DocumentLog.AllowUserToResizeRows = false;
			grd_DocumentLog.AllowUserToResizeRows = false;
			grd_DocumentLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grd_DocumentLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_DocumentLog.ColumnsCount = 2;
			grd_DocumentLog.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			grd_DocumentLog.FixedColumns = 0;
			grd_DocumentLog.FixedRows = 1;
			grd_DocumentLog.Location = new System.Drawing.Point(13, 32);
			grd_DocumentLog.Name = "grd_DocumentLog";
			grd_DocumentLog.ReadOnly = true;
			grd_DocumentLog.RowsCount = 2;
			grd_DocumentLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grd_DocumentLog.ShowCellToolTips = false;
			grd_DocumentLog.Size = new System.Drawing.Size(941, 363);
			grd_DocumentLog.StandardTab = true;
			grd_DocumentLog.TabIndex = 62;
			grd_DocumentLog.Click += new System.EventHandler(grd_DocumentLog_Click);
			grd_DocumentLog.DoubleClick += new System.EventHandler(grd_DocumentLog_DoubleClick);
			grd_DocumentLog.MouseDown += new System.Windows.Forms.MouseEventHandler(grd_DocumentLog_MouseDown);
			// 
			// _lbl_gen_36
			// 
			_lbl_gen_36.AllowDrop = true;
			_lbl_gen_36.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_36.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_36.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_36.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_36.Location = new System.Drawing.Point(478, 414);
			_lbl_gen_36.MinimumSize = new System.Drawing.Size(83, 20);
			_lbl_gen_36.Name = "_lbl_gen_36";
			_lbl_gen_36.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_36.Size = new System.Drawing.Size(83, 20);
			_lbl_gen_36.TabIndex = 211;
			_lbl_gen_36.Text = "Document Type";
			_lbl_gen_36.Visible = false;
			_lbl_gen_36.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// lblClass
			// 
			lblClass.AllowDrop = true;
			lblClass.BackColor = System.Drawing.SystemColors.Control;
			lblClass.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblClass.ForeColor = System.Drawing.SystemColors.ControlText;
			lblClass.Location = new System.Drawing.Point(641, 12);
			lblClass.MinimumSize = new System.Drawing.Size(49, 13);
			lblClass.Name = "lblClass";
			lblClass.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblClass.Size = new System.Drawing.Size(49, 13);
			lblClass.TabIndex = 194;
			lblClass.Text = "A/C Class";
			// 
			// lbl_Documents_In_Process
			// 
			lbl_Documents_In_Process.AllowDrop = true;
			lbl_Documents_In_Process.BackColor = System.Drawing.SystemColors.Control;
			lbl_Documents_In_Process.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_Documents_In_Process.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_Documents_In_Process.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
			lbl_Documents_In_Process.Location = new System.Drawing.Point(768, 8);
			lbl_Documents_In_Process.MinimumSize = new System.Drawing.Size(213, 23);
			lbl_Documents_In_Process.Name = "lbl_Documents_In_Process";
			lbl_Documents_In_Process.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_Documents_In_Process.Size = new System.Drawing.Size(213, 23);
			lbl_Documents_In_Process.TabIndex = 124;
			lbl_Documents_In_Process.Text = "No Documents in Process";
			// 
			// _tab_callback_TabPage10
			// 
			_tab_callback_TabPage10.Controls.Add(chk_EventsToday);
			_tab_callback_TabPage10.Controls.Add(lstEventCat);
			_tab_callback_TabPage10.Controls.Add(cmdFillEvents);
			_tab_callback_TabPage10.Controls.Add(fraDateTimeRange);
			_tab_callback_TabPage10.Controls.Add(grdPriorityEvents);
			_tab_callback_TabPage10.Controls.Add(lblTotalPEventRecordsFound);
			_tab_callback_TabPage10.Controls.Add(lblPEventStop);
			_tab_callback_TabPage10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_callback_TabPage10.Text = "Prority Events";
			// 
			// chk_EventsToday
			// 
			chk_EventsToday.AllowDrop = true;
			chk_EventsToday.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_EventsToday.BackColor = System.Drawing.SystemColors.Control;
			chk_EventsToday.CausesValidation = true;
			chk_EventsToday.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_EventsToday.CheckState = System.Windows.Forms.CheckState.Checked;
			chk_EventsToday.Enabled = true;
			chk_EventsToday.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_EventsToday.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_EventsToday.Location = new System.Drawing.Point(15, 45);
			chk_EventsToday.Name = "chk_EventsToday";
			chk_EventsToday.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_EventsToday.Size = new System.Drawing.Size(121, 13);
			chk_EventsToday.TabIndex = 58;
			chk_EventsToday.TabStop = true;
			chk_EventsToday.Text = "Todays Events Only";
			chk_EventsToday.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_EventsToday.Visible = true;
			chk_EventsToday.CheckStateChanged += new System.EventHandler(chk_EventsToday_CheckStateChanged);
			// 
			// lstEventCat
			// 
			lstEventCat.AllowDrop = true;
			lstEventCat.BackColor = System.Drawing.SystemColors.Window;
			lstEventCat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lstEventCat.CausesValidation = true;
			lstEventCat.Enabled = true;
			lstEventCat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lstEventCat.ForeColor = System.Drawing.SystemColors.WindowText;
			lstEventCat.IntegralHeight = true;
			lstEventCat.Location = new System.Drawing.Point(441, 12);
			lstEventCat.MultiColumn = false;
			lstEventCat.Name = "lstEventCat";
			lstEventCat.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lstEventCat.Size = new System.Drawing.Size(202, 96);
			lstEventCat.Sorted = false;
			lstEventCat.TabIndex = 57;
			lstEventCat.TabStop = true;
			lstEventCat.Visible = true;
			// 
			// cmdFillEvents
			// 
			cmdFillEvents.AllowDrop = true;
			cmdFillEvents.BackColor = System.Drawing.SystemColors.Control;
			cmdFillEvents.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdFillEvents.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdFillEvents.Location = new System.Drawing.Point(650, 86);
			cmdFillEvents.Name = "cmdFillEvents";
			cmdFillEvents.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdFillEvents.Size = new System.Drawing.Size(95, 19);
			cmdFillEvents.TabIndex = 56;
			cmdFillEvents.Text = "Refresh";
			cmdFillEvents.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdFillEvents.UseVisualStyleBackColor = false;
			cmdFillEvents.Click += new System.EventHandler(cmdFillEvents_Click);
			// 
			// fraDateTimeRange
			// 
			fraDateTimeRange.AllowDrop = true;
			fraDateTimeRange.BackColor = System.Drawing.SystemColors.Control;
			fraDateTimeRange.Controls.Add(txtEventDateTo);
			fraDateTimeRange.Controls.Add(txtEventDateFrom);
			fraDateTimeRange.Controls.Add(_lbl_gen_17);
			fraDateTimeRange.Controls.Add(_lbl_gen_18);
			fraDateTimeRange.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			fraDateTimeRange.Enabled = true;
			fraDateTimeRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			fraDateTimeRange.ForeColor = System.Drawing.SystemColors.ControlText;
			fraDateTimeRange.Location = new System.Drawing.Point(156, 8);
			fraDateTimeRange.Name = "fraDateTimeRange";
			fraDateTimeRange.RightToLeft = System.Windows.Forms.RightToLeft.No;
			fraDateTimeRange.Size = new System.Drawing.Size(276, 98);
			fraDateTimeRange.TabIndex = 51;
			fraDateTimeRange.Text = "Date/Time Range (mm/dd/ccyy hh:mm am/pm)";
			fraDateTimeRange.Visible = false;
			// 
			// txtEventDateTo
			// 
			txtEventDateTo.AcceptsReturn = true;
			txtEventDateTo.AllowDrop = true;
			txtEventDateTo.BackColor = System.Drawing.SystemColors.Window;
			txtEventDateTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtEventDateTo.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtEventDateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtEventDateTo.ForeColor = System.Drawing.SystemColors.WindowText;
			txtEventDateTo.Location = new System.Drawing.Point(77, 58);
			txtEventDateTo.MaxLength = 0;
			txtEventDateTo.Name = "txtEventDateTo";
			txtEventDateTo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtEventDateTo.Size = new System.Drawing.Size(150, 19);
			txtEventDateTo.TabIndex = 53;
			// 
			// txtEventDateFrom
			// 
			txtEventDateFrom.AcceptsReturn = true;
			txtEventDateFrom.AllowDrop = true;
			txtEventDateFrom.BackColor = System.Drawing.SystemColors.Window;
			txtEventDateFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtEventDateFrom.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtEventDateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtEventDateFrom.ForeColor = System.Drawing.SystemColors.WindowText;
			txtEventDateFrom.Location = new System.Drawing.Point(77, 35);
			txtEventDateFrom.MaxLength = 0;
			txtEventDateFrom.Name = "txtEventDateFrom";
			txtEventDateFrom.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtEventDateFrom.Size = new System.Drawing.Size(150, 19);
			txtEventDateFrom.TabIndex = 52;
			// 
			// _lbl_gen_17
			// 
			_lbl_gen_17.AllowDrop = true;
			_lbl_gen_17.AutoSize = true;
			_lbl_gen_17.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_17.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_17.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_17.Location = new System.Drawing.Point(46, 37);
			_lbl_gen_17.MinimumSize = new System.Drawing.Size(26, 13);
			_lbl_gen_17.Name = "_lbl_gen_17";
			_lbl_gen_17.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_17.Size = new System.Drawing.Size(26, 13);
			_lbl_gen_17.TabIndex = 55;
			_lbl_gen_17.Text = "From:";
			_lbl_gen_17.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// _lbl_gen_18
			// 
			_lbl_gen_18.AllowDrop = true;
			_lbl_gen_18.AutoSize = true;
			_lbl_gen_18.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_18.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_18.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_18.Location = new System.Drawing.Point(56, 60);
			_lbl_gen_18.MinimumSize = new System.Drawing.Size(16, 13);
			_lbl_gen_18.Name = "_lbl_gen_18";
			_lbl_gen_18.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_18.Size = new System.Drawing.Size(16, 13);
			_lbl_gen_18.TabIndex = 54;
			_lbl_gen_18.Text = "To:";
			_lbl_gen_18.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// grdPriorityEvents
			// 
			grdPriorityEvents.AllowDrop = true;
			grdPriorityEvents.AllowUserToAddRows = false;
			grdPriorityEvents.AllowUserToDeleteRows = false;
			grdPriorityEvents.AllowUserToResizeColumns = false;
			grdPriorityEvents.AllowUserToResizeColumns = grdPriorityEvents.ColumnHeadersVisible;
			grdPriorityEvents.AllowUserToResizeRows = false;
			grdPriorityEvents.AllowUserToResizeRows = false;
			grdPriorityEvents.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grdPriorityEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grdPriorityEvents.ColumnsCount = 2;
			grdPriorityEvents.FixedColumns = 1;
			grdPriorityEvents.FixedRows = 1;
			grdPriorityEvents.Location = new System.Drawing.Point(17, 110);
			grdPriorityEvents.Name = "grdPriorityEvents";
			grdPriorityEvents.ReadOnly = true;
			grdPriorityEvents.RowsCount = 2;
			grdPriorityEvents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grdPriorityEvents.ShowCellToolTips = false;
			grdPriorityEvents.Size = new System.Drawing.Size(957, 317);
			grdPriorityEvents.StandardTab = true;
			grdPriorityEvents.TabIndex = 59;
			grdPriorityEvents.DoubleClick += new System.EventHandler(grdPriorityEvents_DoubleClick);
			// 
			// lblTotalPEventRecordsFound
			// 
			lblTotalPEventRecordsFound.AllowDrop = true;
			lblTotalPEventRecordsFound.AutoSize = true;
			lblTotalPEventRecordsFound.BackColor = System.Drawing.Color.Transparent;
			lblTotalPEventRecordsFound.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblTotalPEventRecordsFound.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblTotalPEventRecordsFound.ForeColor = System.Drawing.SystemColors.ControlText;
			lblTotalPEventRecordsFound.Location = new System.Drawing.Point(652, 66);
			lblTotalPEventRecordsFound.MinimumSize = new System.Drawing.Size(325, 13);
			lblTotalPEventRecordsFound.Name = "lblTotalPEventRecordsFound";
			lblTotalPEventRecordsFound.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblTotalPEventRecordsFound.Size = new System.Drawing.Size(325, 13);
			lblTotalPEventRecordsFound.TabIndex = 193;
			lblTotalPEventRecordsFound.Text = "Total Records Found: 0";
			// 
			// lblPEventStop
			// 
			lblPEventStop.AllowDrop = true;
			lblPEventStop.BackColor = System.Drawing.SystemColors.Control;
			lblPEventStop.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblPEventStop.Enabled = false;
			lblPEventStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblPEventStop.ForeColor = System.Drawing.Color.Blue;
			lblPEventStop.Location = new System.Drawing.Point(890, 90);
			lblPEventStop.MinimumSize = new System.Drawing.Size(77, 15);
			lblPEventStop.Name = "lblPEventStop";
			lblPEventStop.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblPEventStop.Size = new System.Drawing.Size(77, 15);
			lblPEventStop.TabIndex = 192;
			lblPEventStop.Text = "Stop Loading";
			lblPEventStop.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			lblPEventStop.Visible = false;
			lblPEventStop.Click += new System.EventHandler(lblPEventStop_Click);
			// 
			// _tab_callback_TabPage11
			// 
			_tab_callback_TabPage11.Controls.Add(Label26);
			_tab_callback_TabPage11.Controls.Add(txt_total_abi_callbacks);
			_tab_callback_TabPage11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_callback_TabPage11.Text = "RPD";
			// 
			// Label26
			// 
			Label26.AllowDrop = true;
			Label26.AutoSize = true;
			Label26.BackColor = System.Drawing.Color.Transparent;
			Label26.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label26.ForeColor = System.Drawing.SystemColors.ControlText;
			Label26.Location = new System.Drawing.Point(5, 455);
			Label26.MinimumSize = new System.Drawing.Size(145, 13);
			Label26.Name = "Label26";
			Label26.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label26.Size = new System.Drawing.Size(145, 13);
			Label26.TabIndex = 121;
			Label26.Text = "Total ABI Company Callbacks:";
			Label26.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txt_total_abi_callbacks
			// 
			txt_total_abi_callbacks.AcceptsReturn = true;
			txt_total_abi_callbacks.AllowDrop = true;
			txt_total_abi_callbacks.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_total_abi_callbacks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_total_abi_callbacks.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_total_abi_callbacks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_total_abi_callbacks.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_total_abi_callbacks.Location = new System.Drawing.Point(176, 492);
			txt_total_abi_callbacks.MaxLength = 0;
			txt_total_abi_callbacks.Name = "txt_total_abi_callbacks";
			txt_total_abi_callbacks.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_total_abi_callbacks.Size = new System.Drawing.Size(57, 19);
			txt_total_abi_callbacks.TabIndex = 19;
			txt_total_abi_callbacks.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// _tab_callback_TabPage12
			// 
			_tab_callback_TabPage12.Controls.Add(lbl_airbp_remarks);
			_tab_callback_TabPage12.Controls.Add(pnl_bottom_totals);
			_tab_callback_TabPage12.Controls.Add(pnl_bottom_totals2);
			_tab_callback_TabPage12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_callback_TabPage12.Text = "AirBP";
			// 
			// lbl_airbp_remarks
			// 
			lbl_airbp_remarks.AllowDrop = true;
			lbl_airbp_remarks.BackColor = System.Drawing.SystemColors.Control;
			lbl_airbp_remarks.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_airbp_remarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_airbp_remarks.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_airbp_remarks.Location = new System.Drawing.Point(520, 348);
			lbl_airbp_remarks.MinimumSize = new System.Drawing.Size(129, 17);
			lbl_airbp_remarks.Name = "lbl_airbp_remarks";
			lbl_airbp_remarks.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_airbp_remarks.Size = new System.Drawing.Size(129, 17);
			lbl_airbp_remarks.TabIndex = 157;
			lbl_airbp_remarks.Visible = false;
			// 
			// pnl_bottom_totals
			// 
			pnl_bottom_totals.AllowDrop = true;
			pnl_bottom_totals.BackColor = System.Drawing.Color.FromArgb(236, 233, 216);
			pnl_bottom_totals.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_bottom_totals.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_bottom_totals.Location = new System.Drawing.Point(4, 404);
			pnl_bottom_totals.Name = "pnl_bottom_totals";
			pnl_bottom_totals.Size = new System.Drawing.Size(508, 55);
			pnl_bottom_totals.TabIndex = 140;
			// 
			// pnl_bottom_totals2
			// 
			pnl_bottom_totals2.AllowDrop = true;
			pnl_bottom_totals2.BackColor = System.Drawing.Color.FromArgb(236, 233, 216);
			pnl_bottom_totals2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_bottom_totals2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_bottom_totals2.Location = new System.Drawing.Point(510, 402);
			pnl_bottom_totals2.Name = "pnl_bottom_totals2";
			pnl_bottom_totals2.Size = new System.Drawing.Size(489, 55);
			pnl_bottom_totals2.TabIndex = 152;
			pnl_bottom_totals2.Visible = false;
			// 
			// _tab_callback_TabPage13
			// 
			_tab_callback_TabPage13.Controls.Add(chkAllYachtCallbackRecords);
			_tab_callback_TabPage13.Controls.Add(cmd_Refresh_Yacht_Callback_List);
			_tab_callback_TabPage13.Controls.Add(frm_Yacht_Callback);
			_tab_callback_TabPage13.Controls.Add(lbl_Yacht_Callback_Message);
			_tab_callback_TabPage13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_callback_TabPage13.Text = "Yacht Callback";
			// 
			// chkAllYachtCallbackRecords
			// 
			chkAllYachtCallbackRecords.AllowDrop = true;
			chkAllYachtCallbackRecords.Appearance = System.Windows.Forms.Appearance.Normal;
			chkAllYachtCallbackRecords.BackColor = System.Drawing.SystemColors.Control;
			chkAllYachtCallbackRecords.CausesValidation = true;
			chkAllYachtCallbackRecords.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkAllYachtCallbackRecords.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkAllYachtCallbackRecords.Enabled = true;
			chkAllYachtCallbackRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkAllYachtCallbackRecords.ForeColor = System.Drawing.SystemColors.ControlText;
			chkAllYachtCallbackRecords.Location = new System.Drawing.Point(190, 400);
			chkAllYachtCallbackRecords.Name = "chkAllYachtCallbackRecords";
			chkAllYachtCallbackRecords.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkAllYachtCallbackRecords.Size = new System.Drawing.Size(207, 17);
			chkAllYachtCallbackRecords.TabIndex = 171;
			chkAllYachtCallbackRecords.TabStop = true;
			chkAllYachtCallbackRecords.Text = "Display All Yacht Callback Records";
			chkAllYachtCallbackRecords.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkAllYachtCallbackRecords.Visible = true;
			// 
			// cmd_Refresh_Yacht_Callback_List
			// 
			cmd_Refresh_Yacht_Callback_List.AllowDrop = true;
			cmd_Refresh_Yacht_Callback_List.BackColor = System.Drawing.SystemColors.Control;
			cmd_Refresh_Yacht_Callback_List.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Refresh_Yacht_Callback_List.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Refresh_Yacht_Callback_List.Location = new System.Drawing.Point(8, 396);
			cmd_Refresh_Yacht_Callback_List.Name = "cmd_Refresh_Yacht_Callback_List";
			cmd_Refresh_Yacht_Callback_List.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Refresh_Yacht_Callback_List.Size = new System.Drawing.Size(163, 23);
			cmd_Refresh_Yacht_Callback_List.TabIndex = 170;
			cmd_Refresh_Yacht_Callback_List.Text = "Refresh Yacht Callback List";
			cmd_Refresh_Yacht_Callback_List.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Refresh_Yacht_Callback_List.UseVisualStyleBackColor = false;
			// 
			// frm_Yacht_Callback
			// 
			frm_Yacht_Callback.AllowDrop = true;
			frm_Yacht_Callback.BackColor = System.Drawing.SystemColors.Control;
			frm_Yacht_Callback.Controls.Add(cmbYachtCallbackType);
			frm_Yacht_Callback.Controls.Add(txt_TotalCallbacks_Yachts);
			frm_Yacht_Callback.Controls.Add(txt_TotalYachts);
			frm_Yacht_Callback.Controls.Add(grd_Yacht_Callbacks);
			frm_Yacht_Callback.Controls.Add(_lbl_gen_49);
			frm_Yacht_Callback.Controls.Add(_lbl_gen_47);
			frm_Yacht_Callback.Controls.Add(_lbl_gen_46);
			frm_Yacht_Callback.Controls.Add(_lbl_gen_45);
			frm_Yacht_Callback.Controls.Add(_lbl_gen_44);
			frm_Yacht_Callback.Controls.Add(_lbl_gen_43);
			frm_Yacht_Callback.Controls.Add(_lbl_gen_42);
			frm_Yacht_Callback.Controls.Add(_lbl_gen_41);
			frm_Yacht_Callback.Controls.Add(_lbl_gen_35);
			frm_Yacht_Callback.Controls.Add(lblYTCallbackStop);
			frm_Yacht_Callback.Controls.Add(_lbl_gen_33);
			frm_Yacht_Callback.Controls.Add(_lbl_gen_31);
			frm_Yacht_Callback.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frm_Yacht_Callback.Enabled = true;
			frm_Yacht_Callback.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frm_Yacht_Callback.ForeColor = System.Drawing.SystemColors.ControlText;
			frm_Yacht_Callback.Location = new System.Drawing.Point(8, 8);
			frm_Yacht_Callback.Name = "frm_Yacht_Callback";
			frm_Yacht_Callback.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frm_Yacht_Callback.Size = new System.Drawing.Size(953, 381);
			frm_Yacht_Callback.TabIndex = 165;
			frm_Yacht_Callback.Text = "Yacht Callbacks";
			frm_Yacht_Callback.Visible = true;
			// 
			// cmbYachtCallbackType
			// 
			cmbYachtCallbackType.AllowDrop = true;
			cmbYachtCallbackType.BackColor = System.Drawing.SystemColors.Window;
			cmbYachtCallbackType.CausesValidation = true;
			cmbYachtCallbackType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cmbYachtCallbackType.Enabled = true;
			cmbYachtCallbackType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmbYachtCallbackType.ForeColor = System.Drawing.SystemColors.WindowText;
			cmbYachtCallbackType.IntegralHeight = true;
			cmbYachtCallbackType.Location = new System.Drawing.Point(102, 20);
			cmbYachtCallbackType.Name = "cmbYachtCallbackType";
			cmbYachtCallbackType.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmbYachtCallbackType.Size = new System.Drawing.Size(174, 21);
			cmbYachtCallbackType.Sorted = false;
			cmbYachtCallbackType.TabIndex = 202;
			cmbYachtCallbackType.TabStop = true;
			cmbYachtCallbackType.Visible = true;
			cmbYachtCallbackType.Items.AddRange(new object[]{"", "Reassigns", "Available For Sale", "Available For Charter"});
			// 
			// txt_TotalCallbacks_Yachts
			// 
			txt_TotalCallbacks_Yachts.AcceptsReturn = true;
			txt_TotalCallbacks_Yachts.AllowDrop = true;
			txt_TotalCallbacks_Yachts.BackColor = System.Drawing.SystemColors.Window;
			txt_TotalCallbacks_Yachts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_TotalCallbacks_Yachts.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_TotalCallbacks_Yachts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_TotalCallbacks_Yachts.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_TotalCallbacks_Yachts.Location = new System.Drawing.Point(104, 352);
			txt_TotalCallbacks_Yachts.MaxLength = 0;
			txt_TotalCallbacks_Yachts.Name = "txt_TotalCallbacks_Yachts";
			txt_TotalCallbacks_Yachts.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_TotalCallbacks_Yachts.Size = new System.Drawing.Size(57, 19);
			txt_TotalCallbacks_Yachts.TabIndex = 168;
			txt_TotalCallbacks_Yachts.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_TotalYachts
			// 
			txt_TotalYachts.AcceptsReturn = true;
			txt_TotalYachts.AllowDrop = true;
			txt_TotalYachts.BackColor = System.Drawing.SystemColors.Window;
			txt_TotalYachts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_TotalYachts.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_TotalYachts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_TotalYachts.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_TotalYachts.Location = new System.Drawing.Point(680, 352);
			txt_TotalYachts.MaxLength = 0;
			txt_TotalYachts.Name = "txt_TotalYachts";
			txt_TotalYachts.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_TotalYachts.Size = new System.Drawing.Size(57, 19);
			txt_TotalYachts.TabIndex = 167;
			txt_TotalYachts.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// grd_Yacht_Callbacks
			// 
			grd_Yacht_Callbacks.AllowDrop = true;
			grd_Yacht_Callbacks.AllowUserToAddRows = false;
			grd_Yacht_Callbacks.AllowUserToDeleteRows = false;
			grd_Yacht_Callbacks.AllowUserToResizeColumns = false;
			grd_Yacht_Callbacks.AllowUserToResizeRows = false;
			grd_Yacht_Callbacks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grd_Yacht_Callbacks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_Yacht_Callbacks.ColumnsCount = 2;
			grd_Yacht_Callbacks.FixedColumns = 0;
			grd_Yacht_Callbacks.FixedRows = 0;
			grd_Yacht_Callbacks.Location = new System.Drawing.Point(8, 64);
			grd_Yacht_Callbacks.Name = "grd_Yacht_Callbacks";
			grd_Yacht_Callbacks.ReadOnly = true;
			grd_Yacht_Callbacks.RowsCount = 2;
			grd_Yacht_Callbacks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grd_Yacht_Callbacks.ShowCellToolTips = false;
			grd_Yacht_Callbacks.Size = new System.Drawing.Size(935, 278);
			grd_Yacht_Callbacks.StandardTab = true;
			grd_Yacht_Callbacks.TabIndex = 166;
			grd_Yacht_Callbacks.Click += new System.EventHandler(grd_Yacht_Callbacks_Click);
			// 
			// _lbl_gen_49
			// 
			_lbl_gen_49.AllowDrop = true;
			_lbl_gen_49.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_49.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_49.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_49.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_49.Location = new System.Drawing.Point(800, 44);
			_lbl_gen_49.MinimumSize = new System.Drawing.Size(69, 20);
			_lbl_gen_49.Name = "_lbl_gen_49";
			_lbl_gen_49.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_49.Size = new System.Drawing.Size(69, 20);
			_lbl_gen_49.TabIndex = 251;
			_lbl_gen_49.Text = "Account Rep";
			_lbl_gen_49.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// _lbl_gen_47
			// 
			_lbl_gen_47.AllowDrop = true;
			_lbl_gen_47.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_47.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_47.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_47.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_47.Location = new System.Drawing.Point(744, 36);
			_lbl_gen_47.MinimumSize = new System.Drawing.Size(45, 28);
			_lbl_gen_47.Name = "_lbl_gen_47";
			_lbl_gen_47.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_47.Size = new System.Drawing.Size(45, 28);
			_lbl_gen_47.TabIndex = 250;
			_lbl_gen_47.Text = "Last Attempt";
			_lbl_gen_47.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// _lbl_gen_46
			// 
			_lbl_gen_46.AllowDrop = true;
			_lbl_gen_46.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_46.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_46.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_46.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_46.Location = new System.Drawing.Point(696, 44);
			_lbl_gen_46.MinimumSize = new System.Drawing.Size(37, 20);
			_lbl_gen_46.Name = "_lbl_gen_46";
			_lbl_gen_46.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_46.Size = new System.Drawing.Size(37, 20);
			_lbl_gen_46.TabIndex = 249;
			_lbl_gen_46.Text = "Yachts";
			_lbl_gen_46.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// _lbl_gen_45
			// 
			_lbl_gen_45.AllowDrop = true;
			_lbl_gen_45.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_45.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_45.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_45.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_45.Location = new System.Drawing.Point(632, 44);
			_lbl_gen_45.MinimumSize = new System.Drawing.Size(53, 15);
			_lbl_gen_45.Name = "_lbl_gen_45";
			_lbl_gen_45.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_45.Size = new System.Drawing.Size(53, 15);
			_lbl_gen_45.TabIndex = 248;
			_lbl_gen_45.Text = "Time Zone";
			_lbl_gen_45.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// _lbl_gen_44
			// 
			_lbl_gen_44.AllowDrop = true;
			_lbl_gen_44.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_44.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_44.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_44.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_44.Location = new System.Drawing.Point(568, 44);
			_lbl_gen_44.MinimumSize = new System.Drawing.Size(45, 20);
			_lbl_gen_44.Name = "_lbl_gen_44";
			_lbl_gen_44.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_44.Size = new System.Drawing.Size(45, 20);
			_lbl_gen_44.TabIndex = 247;
			_lbl_gen_44.Text = "State";
			_lbl_gen_44.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// _lbl_gen_43
			// 
			_lbl_gen_43.AllowDrop = true;
			_lbl_gen_43.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_43.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_43.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_43.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_43.Location = new System.Drawing.Point(360, 44);
			_lbl_gen_43.MinimumSize = new System.Drawing.Size(45, 20);
			_lbl_gen_43.Name = "_lbl_gen_43";
			_lbl_gen_43.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_43.Size = new System.Drawing.Size(45, 20);
			_lbl_gen_43.TabIndex = 246;
			_lbl_gen_43.Text = "Location";
			_lbl_gen_43.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// _lbl_gen_42
			// 
			_lbl_gen_42.AllowDrop = true;
			_lbl_gen_42.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_42.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_42.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_42.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_42.Location = new System.Drawing.Point(72, 44);
			_lbl_gen_42.MinimumSize = new System.Drawing.Size(45, 20);
			_lbl_gen_42.Name = "_lbl_gen_42";
			_lbl_gen_42.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_42.Size = new System.Drawing.Size(45, 20);
			_lbl_gen_42.TabIndex = 245;
			_lbl_gen_42.Text = "Company";
			_lbl_gen_42.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// _lbl_gen_41
			// 
			_lbl_gen_41.AllowDrop = true;
			_lbl_gen_41.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_41.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_41.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_41.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_41.Location = new System.Drawing.Point(8, 44);
			_lbl_gen_41.MinimumSize = new System.Drawing.Size(53, 20);
			_lbl_gen_41.Name = "_lbl_gen_41";
			_lbl_gen_41.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_41.Size = new System.Drawing.Size(53, 20);
			_lbl_gen_41.TabIndex = 244;
			_lbl_gen_41.Text = "Date";
			_lbl_gen_41.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// _lbl_gen_35
			// 
			_lbl_gen_35.AllowDrop = true;
			_lbl_gen_35.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_35.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_35.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_35.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_35.Location = new System.Drawing.Point(610, 354);
			_lbl_gen_35.MinimumSize = new System.Drawing.Size(61, 20);
			_lbl_gen_35.Name = "_lbl_gen_35";
			_lbl_gen_35.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_35.Size = new System.Drawing.Size(61, 20);
			_lbl_gen_35.TabIndex = 205;
			_lbl_gen_35.Text = "Total Yachts";
			_lbl_gen_35.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// lblYTCallbackStop
			// 
			lblYTCallbackStop.AllowDrop = true;
			lblYTCallbackStop.BackColor = System.Drawing.SystemColors.Control;
			lblYTCallbackStop.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblYTCallbackStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblYTCallbackStop.ForeColor = System.Drawing.Color.Blue;
			lblYTCallbackStop.Location = new System.Drawing.Point(848, 354);
			lblYTCallbackStop.MinimumSize = new System.Drawing.Size(77, 15);
			lblYTCallbackStop.Name = "lblYTCallbackStop";
			lblYTCallbackStop.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblYTCallbackStop.Size = new System.Drawing.Size(77, 15);
			lblYTCallbackStop.TabIndex = 204;
			lblYTCallbackStop.Text = "Stop Loading";
			lblYTCallbackStop.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			lblYTCallbackStop.Click += new System.EventHandler(lblYTCallbackStop_Click);
			// 
			// _lbl_gen_33
			// 
			_lbl_gen_33.AllowDrop = true;
			_lbl_gen_33.AutoSize = true;
			_lbl_gen_33.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_33.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_33.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_33.Location = new System.Drawing.Point(6, 22);
			_lbl_gen_33.MinimumSize = new System.Drawing.Size(88, 13);
			_lbl_gen_33.Name = "_lbl_gen_33";
			_lbl_gen_33.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_33.Size = new System.Drawing.Size(88, 13);
			_lbl_gen_33.TabIndex = 203;
			_lbl_gen_33.Text = "Type of Research:";
			_lbl_gen_33.TextAlign = System.Drawing.ContentAlignment.TopRight;
			_lbl_gen_33.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// _lbl_gen_31
			// 
			_lbl_gen_31.AllowDrop = true;
			_lbl_gen_31.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_31.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_31.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_31.Location = new System.Drawing.Point(16, 354);
			_lbl_gen_31.MinimumSize = new System.Drawing.Size(77, 20);
			_lbl_gen_31.Name = "_lbl_gen_31";
			_lbl_gen_31.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_31.Size = new System.Drawing.Size(77, 20);
			_lbl_gen_31.TabIndex = 172;
			_lbl_gen_31.Text = "Total Callbacks";
			_lbl_gen_31.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// lbl_Yacht_Callback_Message
			// 
			lbl_Yacht_Callback_Message.AllowDrop = true;
			lbl_Yacht_Callback_Message.BackColor = System.Drawing.Color.Transparent;
			lbl_Yacht_Callback_Message.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_Yacht_Callback_Message.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_Yacht_Callback_Message.ForeColor = System.Drawing.Color.Maroon;
			lbl_Yacht_Callback_Message.Location = new System.Drawing.Point(16, 28);
			lbl_Yacht_Callback_Message.MinimumSize = new System.Drawing.Size(481, 41);
			lbl_Yacht_Callback_Message.Name = "lbl_Yacht_Callback_Message";
			lbl_Yacht_Callback_Message.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_Yacht_Callback_Message.Size = new System.Drawing.Size(481, 41);
			lbl_Yacht_Callback_Message.TabIndex = 169;
			// 
			// _tab_callback_TabPage14
			// 
			_tab_callback_TabPage14.Controls.Add(lblOwrOprStop);
			_tab_callback_TabPage14.Controls.Add(lblOwrOprRecords);
			_tab_callback_TabPage14.Controls.Add(fgrdOwrOpr);
			_tab_callback_TabPage14.Controls.Add(cmdOwrOprRefresh);
			_tab_callback_TabPage14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_callback_TabPage14.Text = "Owner=Operator";
			// 
			// lblOwrOprStop
			// 
			lblOwrOprStop.AllowDrop = true;
			lblOwrOprStop.BackColor = System.Drawing.SystemColors.Control;
			lblOwrOprStop.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblOwrOprStop.Enabled = false;
			lblOwrOprStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblOwrOprStop.ForeColor = System.Drawing.Color.Blue;
			lblOwrOprStop.Location = new System.Drawing.Point(904, 412);
			lblOwrOprStop.MinimumSize = new System.Drawing.Size(77, 15);
			lblOwrOprStop.Name = "lblOwrOprStop";
			lblOwrOprStop.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblOwrOprStop.Size = new System.Drawing.Size(77, 15);
			lblOwrOprStop.TabIndex = 174;
			lblOwrOprStop.Text = "Stop Loading";
			lblOwrOprStop.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			lblOwrOprStop.Visible = false;
			lblOwrOprStop.Click += new System.EventHandler(lblOwrOprStop_Click);
			// 
			// lblOwrOprRecords
			// 
			lblOwrOprRecords.AllowDrop = true;
			lblOwrOprRecords.AutoSize = true;
			lblOwrOprRecords.BackColor = System.Drawing.Color.Transparent;
			lblOwrOprRecords.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblOwrOprRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblOwrOprRecords.ForeColor = System.Drawing.SystemColors.ControlText;
			lblOwrOprRecords.Location = new System.Drawing.Point(19, 412);
			lblOwrOprRecords.MinimumSize = new System.Drawing.Size(389, 13);
			lblOwrOprRecords.Name = "lblOwrOprRecords";
			lblOwrOprRecords.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblOwrOprRecords.Size = new System.Drawing.Size(389, 13);
			lblOwrOprRecords.TabIndex = 176;
			lblOwrOprRecords.Text = "Total Records Found: 0";
			// 
			// fgrdOwrOpr
			// 
			fgrdOwrOpr.AllowDrop = true;
			fgrdOwrOpr.AllowUserToAddRows = false;
			fgrdOwrOpr.AllowUserToDeleteRows = false;
			fgrdOwrOpr.AllowUserToResizeColumns = false;
			fgrdOwrOpr.AllowUserToResizeColumns = fgrdOwrOpr.ColumnHeadersVisible;
			fgrdOwrOpr.AllowUserToResizeRows = false;
			fgrdOwrOpr.AllowUserToResizeRows = false;
			fgrdOwrOpr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			fgrdOwrOpr.ColumnsCount = 2;
			fgrdOwrOpr.FixedColumns = 1;
			fgrdOwrOpr.FixedRows = 1;
			fgrdOwrOpr.Location = new System.Drawing.Point(12, 12);
			fgrdOwrOpr.Name = "fgrdOwrOpr";
			fgrdOwrOpr.ReadOnly = true;
			fgrdOwrOpr.RowsCount = 2;
			fgrdOwrOpr.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			fgrdOwrOpr.ShowCellToolTips = false;
			fgrdOwrOpr.Size = new System.Drawing.Size(963, 391);
			fgrdOwrOpr.StandardTab = true;
			fgrdOwrOpr.TabIndex = 173;
			fgrdOwrOpr.Tag = "Make, Model, SerNbr";
			fgrdOwrOpr.Click += new System.EventHandler(fgrdOwrOpr_Click);
			fgrdOwrOpr.DoubleClick += new System.EventHandler(fgrdOwrOpr_DoubleClick);
			// 
			// cmdOwrOprRefresh
			// 
			cmdOwrOprRefresh.AllowDrop = true;
			cmdOwrOprRefresh.BackColor = System.Drawing.SystemColors.Control;
			cmdOwrOprRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdOwrOprRefresh.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdOwrOprRefresh.Location = new System.Drawing.Point(818, 410);
			cmdOwrOprRefresh.Name = "cmdOwrOprRefresh";
			cmdOwrOprRefresh.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdOwrOprRefresh.Size = new System.Drawing.Size(73, 21);
			cmdOwrOprRefresh.TabIndex = 175;
			cmdOwrOprRefresh.Text = "Refresh";
			cmdOwrOprRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdOwrOprRefresh.UseVisualStyleBackColor = false;
			cmdOwrOprRefresh.Click += new System.EventHandler(cmdOwrOprRefresh_Click);
			// 
			// _tab_callback_TabPage15
			// 
			_tab_callback_TabPage15.Controls.Add(cmbFindDupReports);
			_tab_callback_TabPage15.Controls.Add(cmdFindDupsRefresh);
			_tab_callback_TabPage15.Controls.Add(fgrdFindDups);
			_tab_callback_TabPage15.Controls.Add(_lbl_gen_32);
			_tab_callback_TabPage15.Controls.Add(lblFindDupsStop);
			_tab_callback_TabPage15.Controls.Add(lblFindDupsRecords);
			_tab_callback_TabPage15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_callback_TabPage15.Text = "Find Duplicate Companies";
			// 
			// cmbFindDupReports
			// 
			cmbFindDupReports.AllowDrop = true;
			cmbFindDupReports.BackColor = System.Drawing.SystemColors.Window;
			cmbFindDupReports.CausesValidation = true;
			cmbFindDupReports.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cmbFindDupReports.Enabled = true;
			cmbFindDupReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmbFindDupReports.ForeColor = System.Drawing.SystemColors.WindowText;
			cmbFindDupReports.IntegralHeight = true;
			cmbFindDupReports.Location = new System.Drawing.Point(130, 10);
			cmbFindDupReports.Name = "cmbFindDupReports";
			cmbFindDupReports.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmbFindDupReports.Size = new System.Drawing.Size(174, 21);
			cmbFindDupReports.Sorted = false;
			cmbFindDupReports.TabIndex = 182;
			cmbFindDupReports.TabStop = true;
			cmbFindDupReports.Visible = true;
			cmbFindDupReports.SelectionChangeCommitted += new System.EventHandler(cmbFindDupReports_SelectionChangeCommitted);
			// 
			// cmdFindDupsRefresh
			// 
			cmdFindDupsRefresh.AllowDrop = true;
			cmdFindDupsRefresh.BackColor = System.Drawing.SystemColors.Control;
			cmdFindDupsRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdFindDupsRefresh.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdFindDupsRefresh.Location = new System.Drawing.Point(818, 412);
			cmdFindDupsRefresh.Name = "cmdFindDupsRefresh";
			cmdFindDupsRefresh.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdFindDupsRefresh.Size = new System.Drawing.Size(73, 21);
			cmdFindDupsRefresh.TabIndex = 178;
			cmdFindDupsRefresh.Text = "Refresh";
			cmdFindDupsRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdFindDupsRefresh.UseVisualStyleBackColor = false;
			cmdFindDupsRefresh.Click += new System.EventHandler(cmdFindDupsRefresh_Click);
			// 
			// fgrdFindDups
			// 
			fgrdFindDups.AllowDrop = true;
			fgrdFindDups.AllowUserToAddRows = false;
			fgrdFindDups.AllowUserToDeleteRows = false;
			fgrdFindDups.AllowUserToResizeColumns = false;
			fgrdFindDups.AllowUserToResizeColumns = fgrdFindDups.ColumnHeadersVisible;
			fgrdFindDups.AllowUserToResizeRows = false;
			fgrdFindDups.AllowUserToResizeRows = false;
			fgrdFindDups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			fgrdFindDups.ColumnsCount = 2;
			fgrdFindDups.FixedColumns = 1;
			fgrdFindDups.FixedRows = 1;
			fgrdFindDups.Location = new System.Drawing.Point(14, 41);
			fgrdFindDups.Name = "fgrdFindDups";
			fgrdFindDups.ReadOnly = true;
			fgrdFindDups.RowsCount = 2;
			fgrdFindDups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			fgrdFindDups.ShowCellToolTips = false;
			fgrdFindDups.Size = new System.Drawing.Size(965, 366);
			fgrdFindDups.StandardTab = true;
			fgrdFindDups.TabIndex = 179;
			fgrdFindDups.Click += new System.EventHandler(fgrdFindDups_Click);
			fgrdFindDups.DoubleClick += new System.EventHandler(fgrdFindDups_DoubleClick);
			fgrdFindDups.MouseDown += new System.Windows.Forms.MouseEventHandler(fgrdFindDups_MouseDown);
			// 
			// _lbl_gen_32
			// 
			_lbl_gen_32.AllowDrop = true;
			_lbl_gen_32.AutoSize = true;
			_lbl_gen_32.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_32.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_32.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_32.Location = new System.Drawing.Point(11, 12);
			_lbl_gen_32.MinimumSize = new System.Drawing.Size(108, 13);
			_lbl_gen_32.Name = "_lbl_gen_32";
			_lbl_gen_32.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_32.Size = new System.Drawing.Size(108, 13);
			_lbl_gen_32.TabIndex = 183;
			_lbl_gen_32.Text = "Find Duplicate Reports";
			_lbl_gen_32.TextAlign = System.Drawing.ContentAlignment.TopRight;
			_lbl_gen_32.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// lblFindDupsStop
			// 
			lblFindDupsStop.AllowDrop = true;
			lblFindDupsStop.BackColor = System.Drawing.SystemColors.Control;
			lblFindDupsStop.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblFindDupsStop.Enabled = false;
			lblFindDupsStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblFindDupsStop.ForeColor = System.Drawing.Color.Blue;
			lblFindDupsStop.Location = new System.Drawing.Point(904, 414);
			lblFindDupsStop.MinimumSize = new System.Drawing.Size(77, 15);
			lblFindDupsStop.Name = "lblFindDupsStop";
			lblFindDupsStop.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblFindDupsStop.Size = new System.Drawing.Size(77, 15);
			lblFindDupsStop.TabIndex = 181;
			lblFindDupsStop.Text = "Stop Loading";
			lblFindDupsStop.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			lblFindDupsStop.Visible = false;
			lblFindDupsStop.Click += new System.EventHandler(lblFindDupsStop_Click);
			// 
			// lblFindDupsRecords
			// 
			lblFindDupsRecords.AllowDrop = true;
			lblFindDupsRecords.AutoSize = true;
			lblFindDupsRecords.BackColor = System.Drawing.Color.Transparent;
			lblFindDupsRecords.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblFindDupsRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblFindDupsRecords.ForeColor = System.Drawing.SystemColors.ControlText;
			lblFindDupsRecords.Location = new System.Drawing.Point(19, 414);
			lblFindDupsRecords.MinimumSize = new System.Drawing.Size(389, 13);
			lblFindDupsRecords.Name = "lblFindDupsRecords";
			lblFindDupsRecords.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblFindDupsRecords.Size = new System.Drawing.Size(389, 13);
			lblFindDupsRecords.TabIndex = 180;
			lblFindDupsRecords.Text = "Total Records Found: 0";
			// 
			// _tab_callback_TabPage16
			// 
			_tab_callback_TabPage16.Controls.Add(lblFindACNoBaseStop);
			_tab_callback_TabPage16.Controls.Add(lblFindACNoBaseRecords);
			_tab_callback_TabPage16.Controls.Add(fgrdFindACNoBase);
			_tab_callback_TabPage16.Controls.Add(cmdFindACNoBaseRefresh);
			_tab_callback_TabPage16.Controls.Add(_chk_action_list_8);
			_tab_callback_TabPage16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_callback_TabPage16.Text = "Aircraft No Base";
			// 
			// lblFindACNoBaseStop
			// 
			lblFindACNoBaseStop.AllowDrop = true;
			lblFindACNoBaseStop.BackColor = System.Drawing.SystemColors.Control;
			lblFindACNoBaseStop.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblFindACNoBaseStop.Enabled = false;
			lblFindACNoBaseStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblFindACNoBaseStop.ForeColor = System.Drawing.Color.Blue;
			lblFindACNoBaseStop.Location = new System.Drawing.Point(904, 412);
			lblFindACNoBaseStop.MinimumSize = new System.Drawing.Size(77, 15);
			lblFindACNoBaseStop.Name = "lblFindACNoBaseStop";
			lblFindACNoBaseStop.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblFindACNoBaseStop.Size = new System.Drawing.Size(77, 15);
			lblFindACNoBaseStop.TabIndex = 186;
			lblFindACNoBaseStop.Text = "Stop Loading";
			lblFindACNoBaseStop.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			lblFindACNoBaseStop.Visible = false;
			lblFindACNoBaseStop.Click += new System.EventHandler(lblFindACNoBaseStop_Click);
			// 
			// lblFindACNoBaseRecords
			// 
			lblFindACNoBaseRecords.AllowDrop = true;
			lblFindACNoBaseRecords.AutoSize = true;
			lblFindACNoBaseRecords.BackColor = System.Drawing.Color.Transparent;
			lblFindACNoBaseRecords.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblFindACNoBaseRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblFindACNoBaseRecords.ForeColor = System.Drawing.SystemColors.ControlText;
			lblFindACNoBaseRecords.Location = new System.Drawing.Point(19, 412);
			lblFindACNoBaseRecords.MinimumSize = new System.Drawing.Size(389, 13);
			lblFindACNoBaseRecords.Name = "lblFindACNoBaseRecords";
			lblFindACNoBaseRecords.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblFindACNoBaseRecords.Size = new System.Drawing.Size(389, 13);
			lblFindACNoBaseRecords.TabIndex = 187;
			lblFindACNoBaseRecords.Text = "Total Records Found: 0";
			// 
			// fgrdFindACNoBase
			// 
			fgrdFindACNoBase.AllowDrop = true;
			fgrdFindACNoBase.AllowUserToAddRows = false;
			fgrdFindACNoBase.AllowUserToDeleteRows = false;
			fgrdFindACNoBase.AllowUserToResizeColumns = false;
			fgrdFindACNoBase.AllowUserToResizeColumns = fgrdFindACNoBase.ColumnHeadersVisible;
			fgrdFindACNoBase.AllowUserToResizeRows = false;
			fgrdFindACNoBase.AllowUserToResizeRows = false;
			fgrdFindACNoBase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			fgrdFindACNoBase.ColumnsCount = 2;
			fgrdFindACNoBase.FixedColumns = 1;
			fgrdFindACNoBase.FixedRows = 1;
			fgrdFindACNoBase.Location = new System.Drawing.Point(12, 12);
			fgrdFindACNoBase.Name = "fgrdFindACNoBase";
			fgrdFindACNoBase.ReadOnly = true;
			fgrdFindACNoBase.RowsCount = 2;
			fgrdFindACNoBase.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			fgrdFindACNoBase.ShowCellToolTips = false;
			fgrdFindACNoBase.Size = new System.Drawing.Size(969, 391);
			fgrdFindACNoBase.StandardTab = true;
			fgrdFindACNoBase.TabIndex = 185;
			fgrdFindACNoBase.Click += new System.EventHandler(fgrdFindACNoBase_Click);
			fgrdFindACNoBase.DoubleClick += new System.EventHandler(fgrdFindACNoBase_DoubleClick);
			// 
			// cmdFindACNoBaseRefresh
			// 
			cmdFindACNoBaseRefresh.AllowDrop = true;
			cmdFindACNoBaseRefresh.BackColor = System.Drawing.SystemColors.Control;
			cmdFindACNoBaseRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdFindACNoBaseRefresh.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdFindACNoBaseRefresh.Location = new System.Drawing.Point(818, 410);
			cmdFindACNoBaseRefresh.Name = "cmdFindACNoBaseRefresh";
			cmdFindACNoBaseRefresh.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdFindACNoBaseRefresh.Size = new System.Drawing.Size(73, 21);
			cmdFindACNoBaseRefresh.TabIndex = 184;
			cmdFindACNoBaseRefresh.Text = "Refresh";
			cmdFindACNoBaseRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdFindACNoBaseRefresh.UseVisualStyleBackColor = false;
			cmdFindACNoBaseRefresh.Click += new System.EventHandler(cmdFindACNoBaseRefresh_Click);
			// 
			// _chk_action_list_8
			// 
			_chk_action_list_8.AllowDrop = true;
			_chk_action_list_8.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_action_list_8.BackColor = System.Drawing.SystemColors.Control;
			_chk_action_list_8.CausesValidation = true;
			_chk_action_list_8.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_action_list_8.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_action_list_8.Enabled = true;
			_chk_action_list_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_action_list_8.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_action_list_8.Location = new System.Drawing.Point(592, 416);
			_chk_action_list_8.Name = "_chk_action_list_8";
			_chk_action_list_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_action_list_8.Size = new System.Drawing.Size(217, 13);
			_chk_action_list_8.TabIndex = 239;
			_chk_action_list_8.TabStop = true;
			_chk_action_list_8.Text = "Exclude Reassigns";
			_chk_action_list_8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_action_list_8.Visible = true;
			_chk_action_list_8.CheckStateChanged += new System.EventHandler(chk_action_list_CheckStateChanged);
			// 
			// _tab_callback_TabPage17
			// 
			_tab_callback_TabPage17.Controls.Add(_chk_action_list_7);
			_tab_callback_TabPage17.Controls.Add(cmdFindACNoCHPRefresh);
			_tab_callback_TabPage17.Controls.Add(fgrdFindACNoCHP);
			_tab_callback_TabPage17.Controls.Add(lblFindACNoCHPRecords);
			_tab_callback_TabPage17.Controls.Add(lblFindACNoCHPStop);
			_tab_callback_TabPage17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_callback_TabPage17.Text = "Aircraft w/No Chief Pilots";
			// 
			// _chk_action_list_7
			// 
			_chk_action_list_7.AllowDrop = true;
			_chk_action_list_7.Appearance = System.Windows.Forms.Appearance.Normal;
			_chk_action_list_7.BackColor = System.Drawing.SystemColors.Control;
			_chk_action_list_7.CausesValidation = true;
			_chk_action_list_7.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_action_list_7.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chk_action_list_7.Enabled = true;
			_chk_action_list_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chk_action_list_7.ForeColor = System.Drawing.SystemColors.ControlText;
			_chk_action_list_7.Location = new System.Drawing.Point(584, 416);
			_chk_action_list_7.Name = "_chk_action_list_7";
			_chk_action_list_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chk_action_list_7.Size = new System.Drawing.Size(217, 13);
			_chk_action_list_7.TabIndex = 238;
			_chk_action_list_7.TabStop = true;
			_chk_action_list_7.Text = "Exclude Reassigns";
			_chk_action_list_7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chk_action_list_7.Visible = true;
			_chk_action_list_7.CheckStateChanged += new System.EventHandler(chk_action_list_CheckStateChanged);
			// 
			// cmdFindACNoCHPRefresh
			// 
			cmdFindACNoCHPRefresh.AllowDrop = true;
			cmdFindACNoCHPRefresh.BackColor = System.Drawing.SystemColors.Control;
			cmdFindACNoCHPRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdFindACNoCHPRefresh.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdFindACNoCHPRefresh.Location = new System.Drawing.Point(818, 408);
			cmdFindACNoCHPRefresh.Name = "cmdFindACNoCHPRefresh";
			cmdFindACNoCHPRefresh.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdFindACNoCHPRefresh.Size = new System.Drawing.Size(73, 21);
			cmdFindACNoCHPRefresh.TabIndex = 188;
			cmdFindACNoCHPRefresh.Text = "Refresh";
			cmdFindACNoCHPRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdFindACNoCHPRefresh.UseVisualStyleBackColor = false;
			cmdFindACNoCHPRefresh.Click += new System.EventHandler(cmdFindACNoCHPRefresh_Click);
			// 
			// fgrdFindACNoCHP
			// 
			fgrdFindACNoCHP.AllowDrop = true;
			fgrdFindACNoCHP.AllowUserToAddRows = false;
			fgrdFindACNoCHP.AllowUserToDeleteRows = false;
			fgrdFindACNoCHP.AllowUserToResizeColumns = false;
			fgrdFindACNoCHP.AllowUserToResizeColumns = fgrdFindACNoCHP.ColumnHeadersVisible;
			fgrdFindACNoCHP.AllowUserToResizeRows = false;
			fgrdFindACNoCHP.AllowUserToResizeRows = false;
			fgrdFindACNoCHP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			fgrdFindACNoCHP.ColumnsCount = 2;
			fgrdFindACNoCHP.FixedColumns = 1;
			fgrdFindACNoCHP.FixedRows = 1;
			fgrdFindACNoCHP.Location = new System.Drawing.Point(12, 12);
			fgrdFindACNoCHP.Name = "fgrdFindACNoCHP";
			fgrdFindACNoCHP.ReadOnly = true;
			fgrdFindACNoCHP.RowsCount = 2;
			fgrdFindACNoCHP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			fgrdFindACNoCHP.ShowCellToolTips = false;
			fgrdFindACNoCHP.Size = new System.Drawing.Size(961, 385);
			fgrdFindACNoCHP.StandardTab = true;
			fgrdFindACNoCHP.TabIndex = 189;
			fgrdFindACNoCHP.Click += new System.EventHandler(fgrdFindACNoCHP_Click);
			fgrdFindACNoCHP.DoubleClick += new System.EventHandler(fgrdFindACNoCHP_DoubleClick);
			// 
			// lblFindACNoCHPRecords
			// 
			lblFindACNoCHPRecords.AllowDrop = true;
			lblFindACNoCHPRecords.AutoSize = true;
			lblFindACNoCHPRecords.BackColor = System.Drawing.Color.Transparent;
			lblFindACNoCHPRecords.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblFindACNoCHPRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblFindACNoCHPRecords.ForeColor = System.Drawing.SystemColors.ControlText;
			lblFindACNoCHPRecords.Location = new System.Drawing.Point(19, 412);
			lblFindACNoCHPRecords.MinimumSize = new System.Drawing.Size(389, 13);
			lblFindACNoCHPRecords.Name = "lblFindACNoCHPRecords";
			lblFindACNoCHPRecords.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblFindACNoCHPRecords.Size = new System.Drawing.Size(389, 13);
			lblFindACNoCHPRecords.TabIndex = 191;
			lblFindACNoCHPRecords.Text = "Total Records Found: 0";
			// 
			// lblFindACNoCHPStop
			// 
			lblFindACNoCHPStop.AllowDrop = true;
			lblFindACNoCHPStop.BackColor = System.Drawing.SystemColors.Control;
			lblFindACNoCHPStop.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblFindACNoCHPStop.Enabled = false;
			lblFindACNoCHPStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblFindACNoCHPStop.ForeColor = System.Drawing.Color.Blue;
			lblFindACNoCHPStop.Location = new System.Drawing.Point(906, 412);
			lblFindACNoCHPStop.MinimumSize = new System.Drawing.Size(77, 15);
			lblFindACNoCHPStop.Name = "lblFindACNoCHPStop";
			lblFindACNoCHPStop.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblFindACNoCHPStop.Size = new System.Drawing.Size(77, 15);
			lblFindACNoCHPStop.TabIndex = 190;
			lblFindACNoCHPStop.Text = "Stop Loading";
			lblFindACNoCHPStop.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			lblFindACNoCHPStop.Visible = false;
			lblFindACNoCHPStop.Click += new System.EventHandler(lblFindACNoCHPStop_Click);
			// 
			// _tab_callback_TabPage18
			// 
			_tab_callback_TabPage18.Controls.Add(chk_new_submitted);
			_tab_callback_TabPage18.Controls.Add(cmdCSDChangeAcctRep);
			_tab_callback_TabPage18.Controls.Add(cmbCustSubAcctRep);
			_tab_callback_TabPage18.Controls.Add(cmd_in_progress);
			_tab_callback_TabPage18.Controls.Add(opSubmitBoth);
			_tab_callback_TabPage18.Controls.Add(opSubmitCompany);
			_tab_callback_TabPage18.Controls.Add(opSubmitAircraft);
			_tab_callback_TabPage18.Controls.Add(cmdSubDataEMail);
			_tab_callback_TabPage18.Controls.Add(chkCustSubDataIncludeCompleted);
			_tab_callback_TabPage18.Controls.Add(cmdFindCustSubDataRefresh);
			_tab_callback_TabPage18.Controls.Add(fgrdFindCustSubData);
			_tab_callback_TabPage18.Controls.Add(_lbl_gen_39);
			_tab_callback_TabPage18.Controls.Add(lblFindCustSubDataStop);
			_tab_callback_TabPage18.Controls.Add(lblFindCustSubDataRecords);
			_tab_callback_TabPage18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_callback_TabPage18.Text = "Customer Submitted Data";
			// 
			// chk_new_submitted
			// 
			chk_new_submitted.AllowDrop = true;
			chk_new_submitted.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_new_submitted.BackColor = System.Drawing.SystemColors.Control;
			chk_new_submitted.CausesValidation = true;
			chk_new_submitted.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_new_submitted.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_new_submitted.Enabled = true;
			chk_new_submitted.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_new_submitted.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_new_submitted.Location = new System.Drawing.Point(840, 368);
			chk_new_submitted.Name = "chk_new_submitted";
			chk_new_submitted.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_new_submitted.Size = new System.Drawing.Size(129, 13);
			chk_new_submitted.TabIndex = 269;
			chk_new_submitted.TabStop = true;
			chk_new_submitted.Text = "Show New Submitted";
			chk_new_submitted.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_new_submitted.Visible = true;
			// 
			// cmdCSDChangeAcctRep
			// 
			cmdCSDChangeAcctRep.AllowDrop = true;
			cmdCSDChangeAcctRep.BackColor = System.Drawing.SystemColors.Control;
			cmdCSDChangeAcctRep.Enabled = false;
			cmdCSDChangeAcctRep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdCSDChangeAcctRep.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdCSDChangeAcctRep.Location = new System.Drawing.Point(248, 370);
			cmdCSDChangeAcctRep.Name = "cmdCSDChangeAcctRep";
			cmdCSDChangeAcctRep.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdCSDChangeAcctRep.Size = new System.Drawing.Size(111, 27);
			cmdCSDChangeAcctRep.TabIndex = 234;
			cmdCSDChangeAcctRep.Text = "Change AcctRep";
			cmdCSDChangeAcctRep.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdCSDChangeAcctRep.Click += new System.EventHandler(cmdCSDChangeAcctRep_Click);
			// 
			// cmbCustSubAcctRep
			// 
			cmbCustSubAcctRep.AllowDrop = true;
			cmbCustSubAcctRep.BackColor = System.Drawing.SystemColors.Window;
			cmbCustSubAcctRep.CausesValidation = true;
			cmbCustSubAcctRep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cmbCustSubAcctRep.Enabled = true;
			cmbCustSubAcctRep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmbCustSubAcctRep.ForeColor = System.Drawing.SystemColors.WindowText;
			cmbCustSubAcctRep.IntegralHeight = true;
			cmbCustSubAcctRep.Location = new System.Drawing.Point(110, 376);
			cmbCustSubAcctRep.Name = "cmbCustSubAcctRep";
			cmbCustSubAcctRep.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmbCustSubAcctRep.Size = new System.Drawing.Size(115, 21);
			cmbCustSubAcctRep.Sorted = false;
			cmbCustSubAcctRep.TabIndex = 233;
			cmbCustSubAcctRep.TabStop = true;
			cmbCustSubAcctRep.Visible = true;
			// 
			// cmd_in_progress
			// 
			cmd_in_progress.AllowDrop = true;
			cmd_in_progress.BackColor = System.Drawing.SystemColors.Control;
			cmd_in_progress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_in_progress.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_in_progress.Location = new System.Drawing.Point(312, 408);
			cmd_in_progress.Name = "cmd_in_progress";
			cmd_in_progress.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_in_progress.Size = new System.Drawing.Size(187, 23);
			cmd_in_progress.TabIndex = 232;
			cmd_in_progress.Text = "Change To: In Progress";
			cmd_in_progress.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_in_progress.UseVisualStyleBackColor = false;
			cmd_in_progress.Click += new System.EventHandler(cmd_in_progress_Click);
			// 
			// opSubmitBoth
			// 
			opSubmitBoth.AllowDrop = true;
			opSubmitBoth.BackColor = System.Drawing.SystemColors.Control;
			opSubmitBoth.CausesValidation = true;
			opSubmitBoth.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opSubmitBoth.Checked = false;
			opSubmitBoth.Enabled = true;
			opSubmitBoth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			opSubmitBoth.ForeColor = System.Drawing.SystemColors.ControlText;
			opSubmitBoth.Location = new System.Drawing.Point(732, 430);
			opSubmitBoth.Name = "opSubmitBoth";
			opSubmitBoth.RightToLeft = System.Windows.Forms.RightToLeft.No;
			opSubmitBoth.Size = new System.Drawing.Size(69, 13);
			opSubmitBoth.TabIndex = 209;
			opSubmitBoth.TabStop = true;
			opSubmitBoth.Text = "Both";
			opSubmitBoth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opSubmitBoth.Visible = true;
			opSubmitBoth.CheckedChanged += new System.EventHandler(opSubmitBoth_CheckedChanged);
			// 
			// opSubmitCompany
			// 
			opSubmitCompany.AllowDrop = true;
			opSubmitCompany.BackColor = System.Drawing.SystemColors.Control;
			opSubmitCompany.CausesValidation = true;
			opSubmitCompany.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opSubmitCompany.Checked = false;
			opSubmitCompany.Enabled = true;
			opSubmitCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			opSubmitCompany.ForeColor = System.Drawing.SystemColors.ControlText;
			opSubmitCompany.Location = new System.Drawing.Point(640, 430);
			opSubmitCompany.Name = "opSubmitCompany";
			opSubmitCompany.RightToLeft = System.Windows.Forms.RightToLeft.No;
			opSubmitCompany.Size = new System.Drawing.Size(69, 13);
			opSubmitCompany.TabIndex = 208;
			opSubmitCompany.TabStop = true;
			opSubmitCompany.Text = "Company";
			opSubmitCompany.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opSubmitCompany.Visible = true;
			opSubmitCompany.CheckedChanged += new System.EventHandler(opSubmitCompany_CheckedChanged);
			// 
			// opSubmitAircraft
			// 
			opSubmitAircraft.AllowDrop = true;
			opSubmitAircraft.BackColor = System.Drawing.SystemColors.Control;
			opSubmitAircraft.CausesValidation = true;
			opSubmitAircraft.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opSubmitAircraft.Checked = false;
			opSubmitAircraft.Enabled = true;
			opSubmitAircraft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			opSubmitAircraft.ForeColor = System.Drawing.SystemColors.ControlText;
			opSubmitAircraft.Location = new System.Drawing.Point(552, 430);
			opSubmitAircraft.Name = "opSubmitAircraft";
			opSubmitAircraft.RightToLeft = System.Windows.Forms.RightToLeft.No;
			opSubmitAircraft.Size = new System.Drawing.Size(69, 13);
			opSubmitAircraft.TabIndex = 207;
			opSubmitAircraft.TabStop = true;
			opSubmitAircraft.Text = "Aircraft";
			opSubmitAircraft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opSubmitAircraft.Visible = true;
			opSubmitAircraft.CheckedChanged += new System.EventHandler(opSubmitAircraft_CheckedChanged);
			// 
			// cmdSubDataEMail
			// 
			cmdSubDataEMail.AllowDrop = true;
			cmdSubDataEMail.BackColor = System.Drawing.SystemColors.Control;
			cmdSubDataEMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdSubDataEMail.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdSubDataEMail.Location = new System.Drawing.Point(720, 404);
			cmdSubDataEMail.Name = "cmdSubDataEMail";
			cmdSubDataEMail.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdSubDataEMail.Size = new System.Drawing.Size(91, 21);
			cmdSubDataEMail.TabIndex = 201;
			cmdSubDataEMail.Text = "EMail Response";
			cmdSubDataEMail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdSubDataEMail.UseVisualStyleBackColor = false;
			cmdSubDataEMail.Click += new System.EventHandler(cmdSubDataEMail_Click);
			// 
			// chkCustSubDataIncludeCompleted
			// 
			chkCustSubDataIncludeCompleted.AllowDrop = true;
			chkCustSubDataIncludeCompleted.Appearance = System.Windows.Forms.Appearance.Normal;
			chkCustSubDataIncludeCompleted.BackColor = System.Drawing.SystemColors.Control;
			chkCustSubDataIncludeCompleted.CausesValidation = true;
			chkCustSubDataIncludeCompleted.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkCustSubDataIncludeCompleted.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkCustSubDataIncludeCompleted.Enabled = true;
			chkCustSubDataIncludeCompleted.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkCustSubDataIncludeCompleted.ForeColor = System.Drawing.SystemColors.ControlText;
			chkCustSubDataIncludeCompleted.Location = new System.Drawing.Point(554, 410);
			chkCustSubDataIncludeCompleted.Name = "chkCustSubDataIncludeCompleted";
			chkCustSubDataIncludeCompleted.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkCustSubDataIncludeCompleted.Size = new System.Drawing.Size(157, 13);
			chkCustSubDataIncludeCompleted.TabIndex = 199;
			chkCustSubDataIncludeCompleted.TabStop = true;
			chkCustSubDataIncludeCompleted.Text = "Include Completed Records";
			chkCustSubDataIncludeCompleted.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkCustSubDataIncludeCompleted.Visible = true;
			// 
			// cmdFindCustSubDataRefresh
			// 
			cmdFindCustSubDataRefresh.AllowDrop = true;
			cmdFindCustSubDataRefresh.BackColor = System.Drawing.SystemColors.Control;
			cmdFindCustSubDataRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdFindCustSubDataRefresh.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdFindCustSubDataRefresh.Location = new System.Drawing.Point(824, 404);
			cmdFindCustSubDataRefresh.Name = "cmdFindCustSubDataRefresh";
			cmdFindCustSubDataRefresh.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdFindCustSubDataRefresh.Size = new System.Drawing.Size(73, 21);
			cmdFindCustSubDataRefresh.TabIndex = 195;
			cmdFindCustSubDataRefresh.Text = "Refresh";
			cmdFindCustSubDataRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdFindCustSubDataRefresh.UseVisualStyleBackColor = false;
			cmdFindCustSubDataRefresh.Click += new System.EventHandler(cmdFindCustSubDataRefresh_Click);
			// 
			// fgrdFindCustSubData
			// 
			fgrdFindCustSubData.AllowDrop = true;
			fgrdFindCustSubData.AllowUserToAddRows = false;
			fgrdFindCustSubData.AllowUserToDeleteRows = false;
			fgrdFindCustSubData.AllowUserToResizeColumns = false;
			fgrdFindCustSubData.AllowUserToResizeColumns = fgrdFindCustSubData.ColumnHeadersVisible;
			fgrdFindCustSubData.AllowUserToResizeRows = false;
			fgrdFindCustSubData.AllowUserToResizeRows = false;
			fgrdFindCustSubData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			fgrdFindCustSubData.ColumnsCount = 2;
			fgrdFindCustSubData.FixedColumns = 1;
			fgrdFindCustSubData.FixedRows = 1;
			fgrdFindCustSubData.Location = new System.Drawing.Point(12, 12);
			fgrdFindCustSubData.Name = "fgrdFindCustSubData";
			fgrdFindCustSubData.ReadOnly = true;
			fgrdFindCustSubData.RowsCount = 2;
			fgrdFindCustSubData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			fgrdFindCustSubData.ShowCellToolTips = false;
			fgrdFindCustSubData.Size = new System.Drawing.Size(961, 351);
			fgrdFindCustSubData.StandardTab = true;
			fgrdFindCustSubData.TabIndex = 196;
			fgrdFindCustSubData.Click += new System.EventHandler(fgrdFindCustSubData_Click);
			fgrdFindCustSubData.DoubleClick += new System.EventHandler(fgrdFindCustSubData_DoubleClick);
			fgrdFindCustSubData.MouseDown += new System.Windows.Forms.MouseEventHandler(fgrdFindCustSubData_MouseDown);
			// 
			// _lbl_gen_39
			// 
			_lbl_gen_39.AllowDrop = true;
			_lbl_gen_39.AutoSize = true;
			_lbl_gen_39.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_39.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_39.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_39.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_39.Location = new System.Drawing.Point(4, 378);
			_lbl_gen_39.MinimumSize = new System.Drawing.Size(98, 13);
			_lbl_gen_39.Name = "_lbl_gen_39";
			_lbl_gen_39.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_39.Size = new System.Drawing.Size(98, 13);
			_lbl_gen_39.TabIndex = 236;
			_lbl_gen_39.Text = "Assigned AcctRep";
			_lbl_gen_39.TextAlign = System.Drawing.ContentAlignment.TopRight;
			_lbl_gen_39.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// lblFindCustSubDataStop
			// 
			lblFindCustSubDataStop.AllowDrop = true;
			lblFindCustSubDataStop.BackColor = System.Drawing.SystemColors.Control;
			lblFindCustSubDataStop.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblFindCustSubDataStop.Enabled = false;
			lblFindCustSubDataStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblFindCustSubDataStop.ForeColor = System.Drawing.Color.Blue;
			lblFindCustSubDataStop.Location = new System.Drawing.Point(906, 406);
			lblFindCustSubDataStop.MinimumSize = new System.Drawing.Size(67, 15);
			lblFindCustSubDataStop.Name = "lblFindCustSubDataStop";
			lblFindCustSubDataStop.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblFindCustSubDataStop.Size = new System.Drawing.Size(67, 15);
			lblFindCustSubDataStop.TabIndex = 198;
			lblFindCustSubDataStop.Text = "Stop Loading";
			lblFindCustSubDataStop.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			lblFindCustSubDataStop.Visible = false;
			lblFindCustSubDataStop.Click += new System.EventHandler(lblFindCustSubDataStop_Click);
			// 
			// lblFindCustSubDataRecords
			// 
			lblFindCustSubDataRecords.AllowDrop = true;
			lblFindCustSubDataRecords.AutoSize = true;
			lblFindCustSubDataRecords.BackColor = System.Drawing.Color.Transparent;
			lblFindCustSubDataRecords.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblFindCustSubDataRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblFindCustSubDataRecords.ForeColor = System.Drawing.SystemColors.ControlText;
			lblFindCustSubDataRecords.Location = new System.Drawing.Point(12, 416);
			lblFindCustSubDataRecords.MinimumSize = new System.Drawing.Size(389, 13);
			lblFindCustSubDataRecords.Name = "lblFindCustSubDataRecords";
			lblFindCustSubDataRecords.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblFindCustSubDataRecords.Size = new System.Drawing.Size(389, 13);
			lblFindCustSubDataRecords.TabIndex = 197;
			lblFindCustSubDataRecords.Text = "Total Records Found: 0";
			// 
			// _tab_callback_TabPage19
			// 
			_tab_callback_TabPage19.Controls.Add(chkSortDesc);
			_tab_callback_TabPage19.Controls.Add(cmdResearchReportsExport);
			_tab_callback_TabPage19.Controls.Add(cmbFindResearchReports);
			_tab_callback_TabPage19.Controls.Add(cmdResearchReportsRefresh);
			_tab_callback_TabPage19.Controls.Add(fgrdFindResearchReports);
			_tab_callback_TabPage19.Controls.Add(lblFindResearchReports);
			_tab_callback_TabPage19.Controls.Add(_lbl_gen_38);
			_tab_callback_TabPage19.Controls.Add(lblFindResearchReportsStop);
			_tab_callback_TabPage19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_callback_TabPage19.Text = "Research Reports";
			// 
			// chkSortDesc
			// 
			chkSortDesc.AllowDrop = true;
			chkSortDesc.Appearance = System.Windows.Forms.Appearance.Normal;
			chkSortDesc.BackColor = System.Drawing.SystemColors.Control;
			chkSortDesc.CausesValidation = true;
			chkSortDesc.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkSortDesc.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkSortDesc.Enabled = true;
			chkSortDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkSortDesc.ForeColor = System.Drawing.SystemColors.ControlText;
			chkSortDesc.Location = new System.Drawing.Point(650, 414);
			chkSortDesc.Name = "chkSortDesc";
			chkSortDesc.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkSortDesc.Size = new System.Drawing.Size(97, 13);
			chkSortDesc.TabIndex = 227;
			chkSortDesc.TabStop = true;
			chkSortDesc.Text = "Sort Decending";
			chkSortDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkSortDesc.Visible = false;
			// 
			// cmdResearchReportsExport
			// 
			cmdResearchReportsExport.AllowDrop = true;
			cmdResearchReportsExport.BackColor = System.Drawing.SystemColors.Control;
			cmdResearchReportsExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdResearchReportsExport.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdResearchReportsExport.Location = new System.Drawing.Point(838, 412);
			cmdResearchReportsExport.Name = "cmdResearchReportsExport";
			cmdResearchReportsExport.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdResearchReportsExport.Size = new System.Drawing.Size(57, 21);
			cmdResearchReportsExport.TabIndex = 231;
			cmdResearchReportsExport.Text = "Export";
			cmdResearchReportsExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdResearchReportsExport.UseVisualStyleBackColor = false;
			cmdResearchReportsExport.Click += new System.EventHandler(cmdResearchReportsExport_Click);
			// 
			// cmbFindResearchReports
			// 
			cmbFindResearchReports.AllowDrop = true;
			cmbFindResearchReports.BackColor = System.Drawing.SystemColors.Window;
			cmbFindResearchReports.CausesValidation = true;
			cmbFindResearchReports.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cmbFindResearchReports.Enabled = true;
			cmbFindResearchReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmbFindResearchReports.ForeColor = System.Drawing.SystemColors.WindowText;
			cmbFindResearchReports.IntegralHeight = true;
			cmbFindResearchReports.Location = new System.Drawing.Point(109, 414);
			cmbFindResearchReports.Name = "cmbFindResearchReports";
			cmbFindResearchReports.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmbFindResearchReports.Size = new System.Drawing.Size(310, 21);
			cmbFindResearchReports.Sorted = false;
			cmbFindResearchReports.TabIndex = 226;
			cmbFindResearchReports.TabStop = true;
			cmbFindResearchReports.Visible = true;
			cmbFindResearchReports.SelectionChangeCommitted += new System.EventHandler(cmbFindResearchReports_SelectionChangeCommitted);
			// 
			// cmdResearchReportsRefresh
			// 
			cmdResearchReportsRefresh.AllowDrop = true;
			cmdResearchReportsRefresh.BackColor = System.Drawing.SystemColors.Control;
			cmdResearchReportsRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdResearchReportsRefresh.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdResearchReportsRefresh.Location = new System.Drawing.Point(776, 412);
			cmdResearchReportsRefresh.Name = "cmdResearchReportsRefresh";
			cmdResearchReportsRefresh.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdResearchReportsRefresh.Size = new System.Drawing.Size(57, 21);
			cmdResearchReportsRefresh.TabIndex = 229;
			cmdResearchReportsRefresh.Text = "Refresh";
			cmdResearchReportsRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdResearchReportsRefresh.UseVisualStyleBackColor = false;
			cmdResearchReportsRefresh.Click += new System.EventHandler(cmdResearchReportsRefresh_Click);
			// 
			// fgrdFindResearchReports
			// 
			fgrdFindResearchReports.AllowDrop = true;
			fgrdFindResearchReports.AllowUserToAddRows = false;
			fgrdFindResearchReports.AllowUserToDeleteRows = false;
			fgrdFindResearchReports.AllowUserToResizeColumns = false;
			fgrdFindResearchReports.AllowUserToResizeColumns = fgrdFindResearchReports.ColumnHeadersVisible;
			fgrdFindResearchReports.AllowUserToResizeRows = false;
			fgrdFindResearchReports.AllowUserToResizeRows = false;
			fgrdFindResearchReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			fgrdFindResearchReports.ColumnsCount = 2;
			fgrdFindResearchReports.FixedColumns = 1;
			fgrdFindResearchReports.FixedRows = 1;
			fgrdFindResearchReports.Location = new System.Drawing.Point(8, 16);
			fgrdFindResearchReports.Name = "fgrdFindResearchReports";
			fgrdFindResearchReports.ReadOnly = true;
			fgrdFindResearchReports.RowsCount = 2;
			fgrdFindResearchReports.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			fgrdFindResearchReports.ShowCellToolTips = false;
			fgrdFindResearchReports.Size = new System.Drawing.Size(961, 383);
			fgrdFindResearchReports.StandardTab = true;
			fgrdFindResearchReports.TabIndex = 224;
			fgrdFindResearchReports.Click += new System.EventHandler(fgrdFindResearchReports_Click);
			fgrdFindResearchReports.DoubleClick += new System.EventHandler(fgrdFindResearchReports_DoubleClick);
			// 
			// lblFindResearchReports
			// 
			lblFindResearchReports.AllowDrop = true;
			lblFindResearchReports.AutoSize = true;
			lblFindResearchReports.BackColor = System.Drawing.Color.Transparent;
			lblFindResearchReports.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblFindResearchReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblFindResearchReports.ForeColor = System.Drawing.SystemColors.ControlText;
			lblFindResearchReports.Location = new System.Drawing.Point(424, 416);
			lblFindResearchReports.MinimumSize = new System.Drawing.Size(337, 13);
			lblFindResearchReports.Name = "lblFindResearchReports";
			lblFindResearchReports.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblFindResearchReports.Size = new System.Drawing.Size(337, 13);
			lblFindResearchReports.TabIndex = 230;
			lblFindResearchReports.Text = "Total Records Found: 0";
			// 
			// _lbl_gen_38
			// 
			_lbl_gen_38.AllowDrop = true;
			_lbl_gen_38.AutoSize = true;
			_lbl_gen_38.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_38.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_38.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_38.ForeColor = System.Drawing.Color.Blue;
			_lbl_gen_38.Location = new System.Drawing.Point(9, 416);
			_lbl_gen_38.MinimumSize = new System.Drawing.Size(89, 13);
			_lbl_gen_38.Name = "_lbl_gen_38";
			_lbl_gen_38.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_38.Size = new System.Drawing.Size(89, 13);
			_lbl_gen_38.TabIndex = 228;
			_lbl_gen_38.Text = "Research Reports ";
			_lbl_gen_38.TextAlign = System.Drawing.ContentAlignment.TopRight;
			_lbl_gen_38.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// lblFindResearchReportsStop
			// 
			lblFindResearchReportsStop.AllowDrop = true;
			lblFindResearchReportsStop.BackColor = System.Drawing.SystemColors.Control;
			lblFindResearchReportsStop.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblFindResearchReportsStop.Enabled = false;
			lblFindResearchReportsStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblFindResearchReportsStop.ForeColor = System.Drawing.Color.Blue;
			lblFindResearchReportsStop.Location = new System.Drawing.Point(904, 414);
			lblFindResearchReportsStop.MinimumSize = new System.Drawing.Size(67, 15);
			lblFindResearchReportsStop.Name = "lblFindResearchReportsStop";
			lblFindResearchReportsStop.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblFindResearchReportsStop.Size = new System.Drawing.Size(67, 15);
			lblFindResearchReportsStop.TabIndex = 225;
			lblFindResearchReportsStop.Text = "Stop Loading";
			lblFindResearchReportsStop.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			lblFindResearchReportsStop.Visible = false;
			lblFindResearchReportsStop.Click += new System.EventHandler(lblFindResearchReportsStop_Click);
			// 
			// _tab_callback_TabPage20
			// 
			_tab_callback_TabPage20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_callback_TabPage20.Text = "Unverified";
			// 
			// _tab_callback_TabPage21
			// 
			_tab_callback_TabPage21.Controls.Add(_lbl_gen_52);
			_tab_callback_TabPage21.Controls.Add(_lbl_gen_53);
			_tab_callback_TabPage21.Controls.Add(grd_issues);
			_tab_callback_TabPage21.Controls.Add(_cmd_refresh_4);
			_tab_callback_TabPage21.Controls.Add(_cbo_multi_0);
			_tab_callback_TabPage21.Controls.Add(_cbo_multi_1);
			_tab_callback_TabPage21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_callback_TabPage21.Text = "Issues";
			// 
			// _lbl_gen_52
			// 
			_lbl_gen_52.AllowDrop = true;
			_lbl_gen_52.AutoSize = true;
			_lbl_gen_52.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_52.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_52.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_52.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_52.Location = new System.Drawing.Point(820, 408);
			_lbl_gen_52.MinimumSize = new System.Drawing.Size(61, 13);
			_lbl_gen_52.Name = "_lbl_gen_52";
			_lbl_gen_52.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_52.Size = new System.Drawing.Size(61, 13);
			_lbl_gen_52.TabIndex = 259;
			_lbl_gen_52.Text = "Total Issues:";
			_lbl_gen_52.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_gen_52.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// _lbl_gen_53
			// 
			_lbl_gen_53.AllowDrop = true;
			_lbl_gen_53.AutoSize = true;
			_lbl_gen_53.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_53.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_53.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_53.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_53.Location = new System.Drawing.Point(927, 408);
			_lbl_gen_53.MinimumSize = new System.Drawing.Size(7, 13);
			_lbl_gen_53.Name = "_lbl_gen_53";
			_lbl_gen_53.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_53.Size = new System.Drawing.Size(7, 13);
			_lbl_gen_53.TabIndex = 260;
			_lbl_gen_53.Text = "0";
			_lbl_gen_53.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_gen_53.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// grd_issues
			// 
			grd_issues.AllowDrop = true;
			grd_issues.AllowUserToAddRows = false;
			grd_issues.AllowUserToDeleteRows = false;
			grd_issues.AllowUserToResizeColumns = false;
			grd_issues.AllowUserToResizeColumns = grd_issues.ColumnHeadersVisible;
			grd_issues.AllowUserToResizeRows = false;
			grd_issues.AllowUserToResizeRows = grd_issues.RowHeadersVisible;
			grd_issues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_issues.ColumnsCount = 2;
			grd_issues.FixedColumns = 0;
			grd_issues.FixedRows = 1;
			grd_issues.Location = new System.Drawing.Point(16, 40);
			grd_issues.Name = "grd_issues";
			grd_issues.ReadOnly = true;
			grd_issues.RowsCount = 2;
			grd_issues.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			grd_issues.ShowCellToolTips = false;
			grd_issues.Size = new System.Drawing.Size(961, 345);
			grd_issues.StandardTab = true;
			grd_issues.TabIndex = 255;
			grd_issues.DoubleClick += new System.EventHandler(grd_issues_DoubleClick);
			// 
			// _cmd_refresh_4
			// 
			_cmd_refresh_4.AllowDrop = true;
			_cmd_refresh_4.BackColor = System.Drawing.SystemColors.Control;
			_cmd_refresh_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_refresh_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_refresh_4.Location = new System.Drawing.Point(32, 400);
			_cmd_refresh_4.Name = "_cmd_refresh_4";
			_cmd_refresh_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_refresh_4.Size = new System.Drawing.Size(65, 27);
			_cmd_refresh_4.TabIndex = 257;
			_cmd_refresh_4.Text = "Refresh";
			_cmd_refresh_4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_refresh_4.UseVisualStyleBackColor = false;
			_cmd_refresh_4.Click += new System.EventHandler(cmd_refresh_Click);
			// 
			// _cbo_multi_0
			// 
			_cbo_multi_0.AllowDrop = true;
			_cbo_multi_0.BackColor = System.Drawing.SystemColors.Window;
			_cbo_multi_0.CausesValidation = true;
			_cbo_multi_0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			_cbo_multi_0.Enabled = true;
			_cbo_multi_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cbo_multi_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_cbo_multi_0.IntegralHeight = true;
			_cbo_multi_0.Location = new System.Drawing.Point(24, 8);
			_cbo_multi_0.Name = "_cbo_multi_0";
			_cbo_multi_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cbo_multi_0.Size = new System.Drawing.Size(137, 21);
			_cbo_multi_0.Sorted = false;
			_cbo_multi_0.TabIndex = 263;
			_cbo_multi_0.TabStop = true;
			_cbo_multi_0.Visible = true;
			_cbo_multi_0.SelectionChangeCommitted += new System.EventHandler(cbo_multi_SelectionChangeCommitted);
			// 
			// _cbo_multi_1
			// 
			_cbo_multi_1.AllowDrop = true;
			_cbo_multi_1.BackColor = System.Drawing.SystemColors.Window;
			_cbo_multi_1.CausesValidation = true;
			_cbo_multi_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			_cbo_multi_1.Enabled = true;
			_cbo_multi_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cbo_multi_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_cbo_multi_1.IntegralHeight = true;
			_cbo_multi_1.Location = new System.Drawing.Point(192, 8);
			_cbo_multi_1.Name = "_cbo_multi_1";
			_cbo_multi_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cbo_multi_1.Size = new System.Drawing.Size(129, 21);
			_cbo_multi_1.Sorted = false;
			_cbo_multi_1.TabIndex = 264;
			_cbo_multi_1.TabStop = true;
			_cbo_multi_1.Visible = true;
			_cbo_multi_1.SelectionChangeCommitted += new System.EventHandler(cbo_multi_SelectionChangeCommitted);
			// 
			// _tab_callback_TabPage22
			// 
			_tab_callback_TabPage22.Controls.Add(_cbo_multi_2);
			_tab_callback_TabPage22.Controls.Add(_cmd_refresh_5);
			_tab_callback_TabPage22.Controls.Add(grd_salesforce);
			_tab_callback_TabPage22.Controls.Add(_lbl_gen_55);
			_tab_callback_TabPage22.Controls.Add(_lbl_gen_54);
			_tab_callback_TabPage22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_callback_TabPage22.Text = "SalesForce";
			// 
			// _cbo_multi_2
			// 
			_cbo_multi_2.AllowDrop = true;
			_cbo_multi_2.BackColor = System.Drawing.SystemColors.Window;
			_cbo_multi_2.CausesValidation = true;
			_cbo_multi_2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			_cbo_multi_2.Enabled = true;
			_cbo_multi_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cbo_multi_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_cbo_multi_2.IntegralHeight = true;
			_cbo_multi_2.Location = new System.Drawing.Point(24, 8);
			_cbo_multi_2.Name = "_cbo_multi_2";
			_cbo_multi_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cbo_multi_2.Size = new System.Drawing.Size(225, 21);
			_cbo_multi_2.Sorted = false;
			_cbo_multi_2.TabIndex = 265;
			_cbo_multi_2.TabStop = true;
			_cbo_multi_2.Visible = true;
			_cbo_multi_2.SelectionChangeCommitted += new System.EventHandler(cbo_multi_SelectionChangeCommitted);
			// 
			// _cmd_refresh_5
			// 
			_cmd_refresh_5.AllowDrop = true;
			_cmd_refresh_5.BackColor = System.Drawing.SystemColors.Control;
			_cmd_refresh_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_refresh_5.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_refresh_5.Location = new System.Drawing.Point(32, 408);
			_cmd_refresh_5.Name = "_cmd_refresh_5";
			_cmd_refresh_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_refresh_5.Size = new System.Drawing.Size(65, 27);
			_cmd_refresh_5.TabIndex = 258;
			_cmd_refresh_5.Text = "Refresh";
			_cmd_refresh_5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_refresh_5.UseVisualStyleBackColor = false;
			_cmd_refresh_5.Click += new System.EventHandler(cmd_refresh_Click);
			// 
			// grd_salesforce
			// 
			grd_salesforce.AllowDrop = true;
			grd_salesforce.AllowUserToAddRows = false;
			grd_salesforce.AllowUserToDeleteRows = false;
			grd_salesforce.AllowUserToResizeColumns = false;
			grd_salesforce.AllowUserToResizeColumns = grd_salesforce.ColumnHeadersVisible;
			grd_salesforce.AllowUserToResizeRows = false;
			grd_salesforce.AllowUserToResizeRows = false;
			grd_salesforce.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grd_salesforce.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_salesforce.ColumnsCount = 2;
			grd_salesforce.FixedColumns = 0;
			grd_salesforce.FixedRows = 1;
			grd_salesforce.Location = new System.Drawing.Point(24, 32);
			grd_salesforce.Name = "grd_salesforce";
			grd_salesforce.ReadOnly = true;
			grd_salesforce.RowsCount = 2;
			grd_salesforce.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			grd_salesforce.ShowCellToolTips = false;
			grd_salesforce.Size = new System.Drawing.Size(929, 361);
			grd_salesforce.StandardTab = true;
			grd_salesforce.TabIndex = 256;
			grd_salesforce.DoubleClick += new System.EventHandler(grd_salesforce_DoubleClick);
			// 
			// _lbl_gen_55
			// 
			_lbl_gen_55.AllowDrop = true;
			_lbl_gen_55.AutoSize = true;
			_lbl_gen_55.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_55.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_55.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_55.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_55.Location = new System.Drawing.Point(935, 416);
			_lbl_gen_55.MinimumSize = new System.Drawing.Size(7, 13);
			_lbl_gen_55.Name = "_lbl_gen_55";
			_lbl_gen_55.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_55.Size = new System.Drawing.Size(7, 13);
			_lbl_gen_55.TabIndex = 262;
			_lbl_gen_55.Text = "0";
			_lbl_gen_55.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_gen_55.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// _lbl_gen_54
			// 
			_lbl_gen_54.AllowDrop = true;
			_lbl_gen_54.AutoSize = true;
			_lbl_gen_54.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_54.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_54.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_54.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_54.Location = new System.Drawing.Point(799, 416);
			_lbl_gen_54.MinimumSize = new System.Drawing.Size(119, 13);
			_lbl_gen_54.Name = "_lbl_gen_54";
			_lbl_gen_54.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_54.Size = new System.Drawing.Size(119, 13);
			_lbl_gen_54.TabIndex = 261;
			_lbl_gen_54.Text = "Total Salesforce Actions:";
			_lbl_gen_54.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_gen_54.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// txt_ListStartDate
			// 
			txt_ListStartDate.AcceptsReturn = true;
			txt_ListStartDate.AllowDrop = true;
			txt_ListStartDate.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_ListStartDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_ListStartDate.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ListStartDate.Enabled = false;
			txt_ListStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ListStartDate.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ListStartDate.Location = new System.Drawing.Point(284, 110);
			txt_ListStartDate.MaxLength = 0;
			txt_ListStartDate.Name = "txt_ListStartDate";
			txt_ListStartDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ListStartDate.Size = new System.Drawing.Size(76, 21);
			txt_ListStartDate.TabIndex = 163;
			// 
			// cbo_TimeScale
			// 
			cbo_TimeScale.AllowDrop = true;
			cbo_TimeScale.BackColor = System.Drawing.SystemColors.Window;
			cbo_TimeScale.CausesValidation = true;
			cbo_TimeScale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_TimeScale.Enabled = true;
			cbo_TimeScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_TimeScale.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_TimeScale.IntegralHeight = true;
			cbo_TimeScale.Location = new System.Drawing.Point(268, 56);
			cbo_TimeScale.Name = "cbo_TimeScale";
			cbo_TimeScale.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_TimeScale.Size = new System.Drawing.Size(94, 21);
			cbo_TimeScale.Sorted = false;
			cbo_TimeScale.TabIndex = 161;
			cbo_TimeScale.TabStop = true;
			cbo_TimeScale.Visible = true;
			cbo_TimeScale.SelectionChangeCommitted += new System.EventHandler(cbo_TimeScale_SelectionChangeCommitted);
			// 
			// cbo_Timezones
			// 
			cbo_Timezones.AllowDrop = true;
			cbo_Timezones.BackColor = System.Drawing.SystemColors.Window;
			cbo_Timezones.CausesValidation = true;
			cbo_Timezones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_Timezones.Enabled = true;
			cbo_Timezones.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_Timezones.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_Timezones.IntegralHeight = true;
			cbo_Timezones.Location = new System.Drawing.Point(249, 160);
			cbo_Timezones.Name = "cbo_Timezones";
			cbo_Timezones.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_Timezones.Size = new System.Drawing.Size(110, 21);
			cbo_Timezones.Sorted = false;
			cbo_Timezones.TabIndex = 158;
			cbo_Timezones.TabStop = true;
			cbo_Timezones.Visible = true;
			// 
			// cmbProductType
			// 
			cmbProductType.AllowDrop = true;
			cmbProductType.BackColor = System.Drawing.SystemColors.Window;
			cmbProductType.CausesValidation = true;
			cmbProductType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cmbProductType.Enabled = true;
			cmbProductType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmbProductType.ForeColor = System.Drawing.SystemColors.WindowText;
			cmbProductType.IntegralHeight = true;
			cmbProductType.Location = new System.Drawing.Point(184, 136);
			cmbProductType.Name = "cmbProductType";
			cmbProductType.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmbProductType.Size = new System.Drawing.Size(174, 21);
			cmbProductType.Sorted = false;
			cmbProductType.TabIndex = 13;
			cmbProductType.TabStop = true;
			cmbProductType.Visible = true;
			cmbProductType.SelectionChangeCommitted += new System.EventHandler(cmbProductType_SelectionChangeCommitted);
			// 
			// cmd_Update_Callback_Dates
			// 
			cmd_Update_Callback_Dates.AllowDrop = true;
			cmd_Update_Callback_Dates.BackColor = System.Drawing.SystemColors.Control;
			cmd_Update_Callback_Dates.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Update_Callback_Dates.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Update_Callback_Dates.Location = new System.Drawing.Point(11, 180);
			cmd_Update_Callback_Dates.Name = "cmd_Update_Callback_Dates";
			cmd_Update_Callback_Dates.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Update_Callback_Dates.Size = new System.Drawing.Size(92, 22);
			cmd_Update_Callback_Dates.TabIndex = 137;
			cmd_Update_Callback_Dates.Text = "Update Callbacks";
			cmd_Update_Callback_Dates.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Update_Callback_Dates.UseVisualStyleBackColor = false;
			cmd_Update_Callback_Dates.Visible = false;
			cmd_Update_Callback_Dates.Click += new System.EventHandler(cmd_Update_Callback_Dates_Click);
			// 
			// cmd_New_Avail
			// 
			cmd_New_Avail.AllowDrop = true;
			cmd_New_Avail.BackColor = System.Drawing.SystemColors.Control;
			cmd_New_Avail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_New_Avail.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_New_Avail.Location = new System.Drawing.Point(11, 81);
			cmd_New_Avail.Name = "cmd_New_Avail";
			cmd_New_Avail.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_New_Avail.Size = new System.Drawing.Size(132, 22);
			cmd_New_Avail.TabIndex = 136;
			cmd_New_Avail.Tag = "No";
			cmd_New_Avail.Text = "New Tasks Available";
			cmd_New_Avail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_New_Avail.UseVisualStyleBackColor = false;
			cmd_New_Avail.Click += new System.EventHandler(cmd_New_Avail_Click);
			// 
			// cmd_Fix_Fract_Owners
			// 
			cmd_Fix_Fract_Owners.AllowDrop = true;
			cmd_Fix_Fract_Owners.BackColor = System.Drawing.SystemColors.Control;
			cmd_Fix_Fract_Owners.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Fix_Fract_Owners.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Fix_Fract_Owners.Location = new System.Drawing.Point(11, 156);
			cmd_Fix_Fract_Owners.Name = "cmd_Fix_Fract_Owners";
			cmd_Fix_Fract_Owners.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Fix_Fract_Owners.Size = new System.Drawing.Size(91, 22);
			cmd_Fix_Fract_Owners.TabIndex = 135;
			cmd_Fix_Fract_Owners.Text = "Fix Fract Owners";
			cmd_Fix_Fract_Owners.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Fix_Fract_Owners.UseVisualStyleBackColor = false;
			cmd_Fix_Fract_Owners.Visible = false;
			cmd_Fix_Fract_Owners.Click += new System.EventHandler(cmd_Fix_Fract_Owners_Click);
			// 
			// txt_Callback_Date
			// 
			txt_Callback_Date.AcceptsReturn = true;
			txt_Callback_Date.AllowDrop = true;
			txt_Callback_Date.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_Callback_Date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_Callback_Date.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_Callback_Date.Enabled = false;
			txt_Callback_Date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_Callback_Date.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_Callback_Date.Location = new System.Drawing.Point(284, 88);
			txt_Callback_Date.MaxLength = 0;
			txt_Callback_Date.Name = "txt_Callback_Date";
			txt_Callback_Date.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_Callback_Date.Size = new System.Drawing.Size(76, 21);
			txt_Callback_Date.TabIndex = 14;
			// 
			// Adodc_CallBack
			// 
			Adodc_CallBack.AllowDrop = true;
			Adodc_CallBack.BackColor = System.Drawing.SystemColors.Window;
			Adodc_CallBack.BOFAction = UpgradeHelpers.DB.BOFActionEnum.MoveFirst;
			Adodc_CallBack.ConnectionString = "";
			Adodc_CallBack.CursorLocation = UpgradeHelpers.DB.ADO.CursorLocationEnum.adUseClient;
			Adodc_CallBack.Enabled = true;
			Adodc_CallBack.EOFAction = UpgradeHelpers.DB.EOFActionEnum.MoveLast;
			Adodc_CallBack.FactoryName = "Access";
			Adodc_CallBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Adodc_CallBack.ForeColor = System.Drawing.SystemColors.WindowText;
			Adodc_CallBack.Location = new System.Drawing.Point(13, 682);
			Adodc_CallBack.LockType = UpgradeHelpers.DB.LockTypeEnum.LockReadOnly;
			Adodc_CallBack.Name = "Adodc_CallBack";
			Adodc_CallBack.Password = "";
			Adodc_CallBack.QueryTimeout = 200;
			Adodc_CallBack.RecordSource = "";
			Adodc_CallBack.Text = "Adodc1";
			Adodc_CallBack.UserName = "";
			Adodc_CallBack.Visible = false;
			Adodc_CallBack.Width = 80;
			// 
			// cmdStop
			// 
			cmdStop.AllowDrop = true;
			cmdStop.BackColor = System.Drawing.SystemColors.Control;
			cmdStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdStop.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdStop.Location = new System.Drawing.Point(268, 184);
			cmdStop.Name = "cmdStop";
			cmdStop.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdStop.Size = new System.Drawing.Size(89, 20);
			cmdStop.TabIndex = 6;
			cmdStop.Text = "&Stop";
			cmdStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdStop.UseVisualStyleBackColor = false;
			cmdStop.Visible = false;
			cmdStop.Click += new System.EventHandler(cmdStop_Click);
			// 
			// pnl_lstcompany
			// 
			pnl_lstcompany.AllowDrop = true;
			pnl_lstcompany.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_lstcompany.Controls.Add(cmd_contacts_phone);
			pnl_lstcompany.Controls.Add(cmd_ClearReassign);
			pnl_lstcompany.Controls.Add(txt_next_confirm_date);
			pnl_lstcompany.Controls.Add(cmdFindLikeCompany);
			pnl_lstcompany.Controls.Add(cmdConfirmExclusive);
			pnl_lstcompany.Controls.Add(lstCompany);
			pnl_lstcompany.Controls.Add(_lbl_gen_5);
			pnl_lstcompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_lstcompany.Location = new System.Drawing.Point(568, 56);
			pnl_lstcompany.Name = "pnl_lstcompany";
			pnl_lstcompany.Size = new System.Drawing.Size(427, 150);
			pnl_lstcompany.TabIndex = 2;
			pnl_lstcompany.Visible = false;
			// 
			// cmd_contacts_phone
			// 
			cmd_contacts_phone.AllowDrop = true;
			cmd_contacts_phone.BackColor = System.Drawing.SystemColors.Control;
			cmd_contacts_phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_contacts_phone.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_contacts_phone.Location = new System.Drawing.Point(176, 128);
			cmd_contacts_phone.Name = "cmd_contacts_phone";
			cmd_contacts_phone.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_contacts_phone.Size = new System.Drawing.Size(81, 17);
			cmd_contacts_phone.TabIndex = 237;
			cmd_contacts_phone.Text = "Load Contacts";
			cmd_contacts_phone.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_contacts_phone.UseVisualStyleBackColor = false;
			cmd_contacts_phone.Click += new System.EventHandler(cmd_contacts_phone_Click);
			// 
			// cmd_ClearReassign
			// 
			cmd_ClearReassign.AllowDrop = true;
			cmd_ClearReassign.BackColor = System.Drawing.SystemColors.Control;
			cmd_ClearReassign.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_ClearReassign.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_ClearReassign.Location = new System.Drawing.Point(263, 56);
			cmd_ClearReassign.Name = "cmd_ClearReassign";
			cmd_ClearReassign.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_ClearReassign.Size = new System.Drawing.Size(156, 23);
			cmd_ClearReassign.TabIndex = 9;
			cmd_ClearReassign.Text = "Clear  Selected Reassign(s)";
			cmd_ClearReassign.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_ClearReassign.UseVisualStyleBackColor = false;
			cmd_ClearReassign.Visible = false;
			cmd_ClearReassign.Click += new System.EventHandler(cmd_ClearReassign_Click);
			// 
			// txt_next_confirm_date
			// 
			txt_next_confirm_date.AcceptsReturn = true;
			txt_next_confirm_date.AllowDrop = true;
			txt_next_confirm_date.BackColor = System.Drawing.SystemColors.Window;
			txt_next_confirm_date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_next_confirm_date.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_next_confirm_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_next_confirm_date.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_next_confirm_date.Location = new System.Drawing.Point(310, 30);
			txt_next_confirm_date.MaxLength = 0;
			txt_next_confirm_date.Name = "txt_next_confirm_date";
			txt_next_confirm_date.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_next_confirm_date.Size = new System.Drawing.Size(62, 20);
			txt_next_confirm_date.TabIndex = 7;
			txt_next_confirm_date.Visible = false;
			// 
			// cmdFindLikeCompany
			// 
			cmdFindLikeCompany.AllowDrop = true;
			cmdFindLikeCompany.BackColor = System.Drawing.SystemColors.Control;
			cmdFindLikeCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdFindLikeCompany.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdFindLikeCompany.Location = new System.Drawing.Point(263, 119);
			cmdFindLikeCompany.Name = "cmdFindLikeCompany";
			cmdFindLikeCompany.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdFindLikeCompany.Size = new System.Drawing.Size(156, 23);
			cmdFindLikeCompany.TabIndex = 5;
			cmdFindLikeCompany.Text = "&Find Like Companies";
			cmdFindLikeCompany.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdFindLikeCompany.UseVisualStyleBackColor = false;
			cmdFindLikeCompany.Click += new System.EventHandler(cmdFindLikeCompany_Click);
			// 
			// cmdConfirmExclusive
			// 
			cmdConfirmExclusive.AllowDrop = true;
			cmdConfirmExclusive.BackColor = System.Drawing.SystemColors.Control;
			cmdConfirmExclusive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdConfirmExclusive.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdConfirmExclusive.Location = new System.Drawing.Point(263, 88);
			cmdConfirmExclusive.Name = "cmdConfirmExclusive";
			cmdConfirmExclusive.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdConfirmExclusive.Size = new System.Drawing.Size(156, 23);
			cmdConfirmExclusive.TabIndex = 4;
			cmdConfirmExclusive.Text = "&Confirm Company";
			cmdConfirmExclusive.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdConfirmExclusive.UseVisualStyleBackColor = false;
			cmdConfirmExclusive.Click += new System.EventHandler(cmdConfirmExclusive_Click);
			// 
			// lstCompany
			// 
			lstCompany.AllowDrop = true;
			lstCompany.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			lstCompany.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lstCompany.CausesValidation = true;
			lstCompany.Enabled = true;
			lstCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lstCompany.ForeColor = System.Drawing.SystemColors.WindowText;
			lstCompany.IntegralHeight = true;
			lstCompany.Location = new System.Drawing.Point(8, 0);
			lstCompany.MultiColumn = false;
			lstCompany.Name = "lstCompany";
			lstCompany.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lstCompany.Size = new System.Drawing.Size(249, 148);
			lstCompany.Sorted = false;
			lstCompany.TabIndex = 3;
			lstCompany.TabStop = true;
			lstCompany.Visible = true;
			lstCompany.DoubleClick += new System.EventHandler(lstCompany_DoubleClick);
			// 
			// _lbl_gen_5
			// 
			_lbl_gen_5.AllowDrop = true;
			_lbl_gen_5.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_5.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_5.Location = new System.Drawing.Point(292, 13);
			_lbl_gen_5.MinimumSize = new System.Drawing.Size(98, 15);
			_lbl_gen_5.Name = "_lbl_gen_5";
			_lbl_gen_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_5.Size = new System.Drawing.Size(98, 15);
			_lbl_gen_5.TabIndex = 8;
			_lbl_gen_5.Text = "Next Confirm Date:";
			_lbl_gen_5.Visible = false;
			_lbl_gen_5.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// cal_Callback
			// 
			cal_Callback.AllowDrop = true;
			cal_Callback.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cal_Callback.ForeColor = System.Drawing.SystemColors.ControlText;
			cal_Callback.Location = new System.Drawing.Point(370, 51);
			cal_Callback.Name = "cal_Callback";
			cal_Callback.Size = new System.Drawing.Size(178, 154);
			cal_Callback.TabIndex = 1;
			cal_Callback.Tag = "No";
			cal_Callback.Enter += new System.EventHandler(cal_Callback_Enter);
			// 
			// cbo_account_id
			// 
			cbo_account_id.AllowDrop = true;
			cbo_account_id.BackColor = System.Drawing.SystemColors.Window;
			cbo_account_id.CausesValidation = true;
			cbo_account_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_account_id.Enabled = true;
			cbo_account_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_account_id.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_account_id.IntegralHeight = true;
			cbo_account_id.Location = new System.Drawing.Point(76, 56);
			cbo_account_id.Name = "cbo_account_id";
			cbo_account_id.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_account_id.Size = new System.Drawing.Size(114, 21);
			cbo_account_id.Sorted = false;
			cbo_account_id.TabIndex = 0;
			cbo_account_id.TabStop = true;
			cbo_account_id.Visible = true;
			cbo_account_id.SelectionChangeCommitted += new System.EventHandler(cbo_account_id_SelectionChangeCommitted);
			// 
			// tbr_AL_ToolBar
			// 
			tbr_AL_ToolBar.AllowDrop = true;
			tbr_AL_ToolBar.Dock = System.Windows.Forms.DockStyle.Top;
			tbr_AL_ToolBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			tbr_AL_ToolBar.Location = new System.Drawing.Point(0, 24);
			tbr_AL_ToolBar.Name = "tbr_AL_ToolBar";
			tbr_AL_ToolBar.ShowItemToolTips = true;
			tbr_AL_ToolBar.Size = new System.Drawing.Size(1029, 28);
			tbr_AL_ToolBar.TabIndex = 10;
			tbr_AL_ToolBar.Items.Add(tbr_AL_ToolBar_Buttons_Button1);
			tbr_AL_ToolBar.Items.Add(tbr_AL_ToolBar_Buttons_Button2);
			tbr_AL_ToolBar.Items.Add(tbr_AL_ToolBar_Buttons_Button3);
			tbr_AL_ToolBar.Items.Add(tbr_AL_ToolBar_Buttons_Button4);
			tbr_AL_ToolBar.Items.Add(tbr_AL_ToolBar_Buttons_Button5);
			tbr_AL_ToolBar.Items.Add(tbr_AL_ToolBar_Buttons_Button6);
			tbr_AL_ToolBar.Items.Add(tbr_AL_ToolBar_Buttons_Button7);
			tbr_AL_ToolBar.Items.Add(tbr_AL_ToolBar_Buttons_Button8);
			// 
			// tbr_AL_ToolBar_Buttons_Button1
			// 
			tbr_AL_ToolBar_Buttons_Button1.Size = new System.Drawing.Size(6, 22);
			tbr_AL_ToolBar_Buttons_Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			tbr_AL_ToolBar_Buttons_Button1.Click += new System.EventHandler(tbr_AL_ToolBar_ButtonClick);
			// 
			// tbr_AL_ToolBar_Buttons_Button2
			// 
			tbr_AL_ToolBar_Buttons_Button2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
			tbr_AL_ToolBar_Buttons_Button2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			tbr_AL_ToolBar_Buttons_Button2.Size = new System.Drawing.Size(24, 22);
			tbr_AL_ToolBar_Buttons_Button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			tbr_AL_ToolBar_Buttons_Button2.Click += new System.EventHandler(tbr_AL_ToolBar_ButtonClick);
			// 
			// tbr_AL_ToolBar_Buttons_Button3
			// 
			tbr_AL_ToolBar_Buttons_Button3.Size = new System.Drawing.Size(6, 22);
			tbr_AL_ToolBar_Buttons_Button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			tbr_AL_ToolBar_Buttons_Button3.Click += new System.EventHandler(tbr_AL_ToolBar_ButtonClick);
			// 
			// tbr_AL_ToolBar_Buttons_Button4
			// 
			tbr_AL_ToolBar_Buttons_Button4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
			tbr_AL_ToolBar_Buttons_Button4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			tbr_AL_ToolBar_Buttons_Button4.Size = new System.Drawing.Size(24, 22);
			tbr_AL_ToolBar_Buttons_Button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			tbr_AL_ToolBar_Buttons_Button4.Click += new System.EventHandler(tbr_AL_ToolBar_ButtonClick);
			// 
			// tbr_AL_ToolBar_Buttons_Button5
			// 
			tbr_AL_ToolBar_Buttons_Button5.Size = new System.Drawing.Size(6, 22);
			tbr_AL_ToolBar_Buttons_Button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			tbr_AL_ToolBar_Buttons_Button5.Click += new System.EventHandler(tbr_AL_ToolBar_ButtonClick);
			// 
			// tbr_AL_ToolBar_Buttons_Button6
			// 
			tbr_AL_ToolBar_Buttons_Button6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
			tbr_AL_ToolBar_Buttons_Button6.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			tbr_AL_ToolBar_Buttons_Button6.Size = new System.Drawing.Size(24, 22);
			tbr_AL_ToolBar_Buttons_Button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			tbr_AL_ToolBar_Buttons_Button6.Click += new System.EventHandler(tbr_AL_ToolBar_ButtonClick);
			// 
			// tbr_AL_ToolBar_Buttons_Button7
			// 
			tbr_AL_ToolBar_Buttons_Button7.Size = new System.Drawing.Size(6, 22);
			tbr_AL_ToolBar_Buttons_Button7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			tbr_AL_ToolBar_Buttons_Button7.Click += new System.EventHandler(tbr_AL_ToolBar_ButtonClick);
			// 
			// tbr_AL_ToolBar_Buttons_Button8
			// 
			tbr_AL_ToolBar_Buttons_Button8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
			tbr_AL_ToolBar_Buttons_Button8.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			tbr_AL_ToolBar_Buttons_Button8.Size = new System.Drawing.Size(24, 22);
			tbr_AL_ToolBar_Buttons_Button8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			tbr_AL_ToolBar_Buttons_Button8.Click += new System.EventHandler(tbr_AL_ToolBar_ButtonClick);
			// 
			// Label3
			// 
			Label3.AllowDrop = true;
			Label3.BackColor = System.Drawing.SystemColors.Control;
			Label3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label3.ForeColor = System.Drawing.SystemColors.ControlText;
			Label3.Location = new System.Drawing.Point(408, 0);
			Label3.MinimumSize = new System.Drawing.Size(113, 25);
			Label3.Name = "Label3";
			Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label3.Size = new System.Drawing.Size(113, 25);
			Label3.TabIndex = 270;
			Label3.Text = "Label3";
			// 
			// SSPanel1
			// 
			SSPanel1.AllowDrop = true;
			SSPanel1.BackColor = System.Drawing.Color.FromArgb(236, 233, 216);
			SSPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			SSPanel1.Controls.Add(Text6);
			SSPanel1.Controls.Add(Text5);
			SSPanel1.Controls.Add(Text3);
			SSPanel1.Controls.Add(Text2);
			SSPanel1.Controls.Add(Text1);
			SSPanel1.Controls.Add(Label40);
			SSPanel1.Controls.Add(_Label36_0);
			SSPanel1.Controls.Add(_Label35_0);
			SSPanel1.Controls.Add(_Label37_0);
			SSPanel1.Controls.Add(Label39);
			SSPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			SSPanel1.Location = new System.Drawing.Point(492, 611);
			SSPanel1.Name = "SSPanel1";
			SSPanel1.Size = new System.Drawing.Size(508, 55);
			SSPanel1.TabIndex = 141;
			// 
			// Text6
			// 
			Text6.AcceptsReturn = true;
			Text6.AllowDrop = true;
			Text6.BackColor = System.Drawing.SystemColors.Window;
			Text6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			Text6.Cursor = System.Windows.Forms.Cursors.IBeam;
			Text6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Text6.ForeColor = System.Drawing.SystemColors.WindowText;
			Text6.Location = new System.Drawing.Point(427, 0);
			Text6.MaxLength = 0;
			Text6.Name = "Text6";
			Text6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Text6.Size = new System.Drawing.Size(64, 22);
			Text6.TabIndex = 146;
			Text6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// Text5
			// 
			Text5.AcceptsReturn = true;
			Text5.AllowDrop = true;
			Text5.BackColor = System.Drawing.SystemColors.Window;
			Text5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			Text5.Cursor = System.Windows.Forms.Cursors.IBeam;
			Text5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Text5.ForeColor = System.Drawing.SystemColors.WindowText;
			Text5.Location = new System.Drawing.Point(360, 0);
			Text5.MaxLength = 0;
			Text5.Name = "Text5";
			Text5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Text5.Size = new System.Drawing.Size(64, 22);
			Text5.TabIndex = 145;
			Text5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// Text3
			// 
			Text3.AcceptsReturn = true;
			Text3.AllowDrop = true;
			Text3.BackColor = System.Drawing.SystemColors.Window;
			Text3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			Text3.Cursor = System.Windows.Forms.Cursors.IBeam;
			Text3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Text3.ForeColor = System.Drawing.SystemColors.WindowText;
			Text3.Location = new System.Drawing.Point(287, 0);
			Text3.MaxLength = 0;
			Text3.Name = "Text3";
			Text3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Text3.Size = new System.Drawing.Size(64, 22);
			Text3.TabIndex = 144;
			Text3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// Text2
			// 
			Text2.AcceptsReturn = true;
			Text2.AllowDrop = true;
			Text2.BackColor = System.Drawing.SystemColors.Window;
			Text2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			Text2.Cursor = System.Windows.Forms.Cursors.IBeam;
			Text2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Text2.ForeColor = System.Drawing.SystemColors.WindowText;
			Text2.Location = new System.Drawing.Point(1, 0);
			Text2.MaxLength = 0;
			Text2.Name = "Text2";
			Text2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Text2.Size = new System.Drawing.Size(107, 22);
			Text2.TabIndex = 143;
			Text2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// Text1
			// 
			Text1.AcceptsReturn = true;
			Text1.AllowDrop = true;
			Text1.BackColor = System.Drawing.SystemColors.Window;
			Text1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			Text1.Cursor = System.Windows.Forms.Cursors.IBeam;
			Text1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Text1.ForeColor = System.Drawing.SystemColors.WindowText;
			Text1.Location = new System.Drawing.Point(153, -1);
			Text1.MaxLength = 0;
			Text1.Name = "Text1";
			Text1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Text1.Size = new System.Drawing.Size(84, 22);
			Text1.TabIndex = 142;
			Text1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// Label40
			// 
			Label40.AllowDrop = true;
			Label40.BackColor = System.Drawing.SystemColors.Control;
			Label40.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label40.ForeColor = System.Drawing.SystemColors.ControlText;
			Label40.Location = new System.Drawing.Point(3, 22);
			Label40.MinimumSize = new System.Drawing.Size(108, 20);
			Label40.Name = "Label40";
			Label40.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label40.Size = new System.Drawing.Size(108, 20);
			Label40.TabIndex = 151;
			Label40.Text = "Total AirBP Companies ";
			// 
			// _Label36_0
			// 
			_Label36_0.AllowDrop = true;
			_Label36_0.BackColor = System.Drawing.SystemColors.Control;
			_Label36_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label36_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label36_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label36_0.Location = new System.Drawing.Point(352, 22);
			_Label36_0.MinimumSize = new System.Drawing.Size(80, 25);
			_Label36_0.Name = "_Label36_0";
			_Label36_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label36_0.Size = new System.Drawing.Size(80, 25);
			_Label36_0.TabIndex = 150;
			_Label36_0.Text = "Total In Service";
			// 
			// _Label35_0
			// 
			_Label35_0.AllowDrop = true;
			_Label35_0.BackColor = System.Drawing.SystemColors.Control;
			_Label35_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label35_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label35_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label35_0.Location = new System.Drawing.Point(280, 22);
			_Label35_0.MinimumSize = new System.Drawing.Size(72, 22);
			_Label35_0.Name = "_Label35_0";
			_Label35_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label35_0.Size = new System.Drawing.Size(72, 22);
			_Label35_0.TabIndex = 149;
			_Label35_0.Text = "Total On Order";
			// 
			// _Label37_0
			// 
			_Label37_0.AllowDrop = true;
			_Label37_0.BackColor = System.Drawing.SystemColors.Control;
			_Label37_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label37_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label37_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label37_0.Location = new System.Drawing.Point(427, 22);
			_Label37_0.MinimumSize = new System.Drawing.Size(74, 18);
			_Label37_0.Name = "_Label37_0";
			_Label37_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label37_0.Size = new System.Drawing.Size(74, 18);
			_Label37_0.TabIndex = 148;
			_Label37_0.Text = "Total Retired";
			// 
			// Label39
			// 
			Label39.AllowDrop = true;
			Label39.BackColor = System.Drawing.SystemColors.Control;
			Label39.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label39.ForeColor = System.Drawing.SystemColors.ControlText;
			Label39.Location = new System.Drawing.Point(167, 22);
			Label39.MinimumSize = new System.Drawing.Size(85, 22);
			Label39.Name = "Label39";
			Label39.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label39.Size = new System.Drawing.Size(85, 22);
			Label39.TabIndex = 147;
			Label39.Text = "Total Aircraft";
			// 
			// text_airbp_remarks
			// 
			text_airbp_remarks.AcceptsReturn = true;
			text_airbp_remarks.AllowDrop = true;
			text_airbp_remarks.BackColor = System.Drawing.SystemColors.Window;
			text_airbp_remarks.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			text_airbp_remarks.Cursor = System.Windows.Forms.Cursors.IBeam;
			text_airbp_remarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			text_airbp_remarks.ForeColor = System.Drawing.SystemColors.WindowText;
			text_airbp_remarks.Location = new System.Drawing.Point(512, 536);
			text_airbp_remarks.MaxLength = 0;
			text_airbp_remarks.Name = "text_airbp_remarks";
			text_airbp_remarks.RightToLeft = System.Windows.Forms.RightToLeft.No;
			text_airbp_remarks.Size = new System.Drawing.Size(489, 41);
			text_airbp_remarks.TabIndex = 156;
			text_airbp_remarks.Visible = false;
			// 
			// pnl_Wait
			// 
			pnl_Wait.AllowDrop = true;
			pnl_Wait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Wait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Wait.Controls.Add(lblTotRecordFound);
			pnl_Wait.Controls.Add(Label7);
			pnl_Wait.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Wait.Location = new System.Drawing.Point(251, 336);
			pnl_Wait.Name = "pnl_Wait";
			pnl_Wait.Size = new System.Drawing.Size(521, 129);
			pnl_Wait.TabIndex = 11;
			pnl_Wait.Visible = false;
			// 
			// lblTotRecordFound
			// 
			lblTotRecordFound.AllowDrop = true;
			lblTotRecordFound.BackColor = System.Drawing.Color.Transparent;
			lblTotRecordFound.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblTotRecordFound.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblTotRecordFound.ForeColor = System.Drawing.Color.Maroon;
			lblTotRecordFound.Location = new System.Drawing.Point(96, 90);
			lblTotRecordFound.MinimumSize = new System.Drawing.Size(333, 27);
			lblTotRecordFound.Name = "lblTotRecordFound";
			lblTotRecordFound.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblTotRecordFound.Size = new System.Drawing.Size(333, 27);
			lblTotRecordFound.TabIndex = 213;
			lblTotRecordFound.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// Label7
			// 
			Label7.AllowDrop = true;
			Label7.BackColor = System.Drawing.Color.Transparent;
			Label7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label7.ForeColor = System.Drawing.Color.Maroon;
			Label7.Location = new System.Drawing.Point(182, 64);
			Label7.MinimumSize = new System.Drawing.Size(153, 27);
			Label7.Name = "Label7";
			Label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label7.Size = new System.Drawing.Size(153, 27);
			Label7.TabIndex = 12;
			Label7.Text = "PLEASE WAIT!";
			Label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lbl_Test_omg
			// 
			lbl_Test_omg.AllowDrop = true;
			lbl_Test_omg.BackColor = System.Drawing.Color.Aqua;
			lbl_Test_omg.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_Test_omg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_Test_omg.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_Test_omg.Location = new System.Drawing.Point(112, 152);
			lbl_Test_omg.MinimumSize = new System.Drawing.Size(65, 25);
			lbl_Test_omg.Name = "lbl_Test_omg";
			lbl_Test_omg.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_Test_omg.Size = new System.Drawing.Size(65, 25);
			lbl_Test_omg.TabIndex = 271;
			lbl_Test_omg.Text = "--YOU ARE ON TEST--";
			lbl_Test_omg.Visible = false;
			// 
			// _lbl_gen_57
			// 
			_lbl_gen_57.AllowDrop = true;
			_lbl_gen_57.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_57.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_57.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_57.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_57.Location = new System.Drawing.Point(200, 184);
			_lbl_gen_57.MinimumSize = new System.Drawing.Size(57, 22);
			_lbl_gen_57.Name = "_lbl_gen_57";
			_lbl_gen_57.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_57.Size = new System.Drawing.Size(57, 22);
			_lbl_gen_57.TabIndex = 267;
			_lbl_gen_57.Text = ".....";
			_lbl_gen_57.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// _lbl_gen_48
			// 
			_lbl_gen_48.AllowDrop = true;
			_lbl_gen_48.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_48.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_48.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_48.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_48.Location = new System.Drawing.Point(0, 24);
			_lbl_gen_48.MinimumSize = new System.Drawing.Size(98, 15);
			_lbl_gen_48.Name = "_lbl_gen_48";
			_lbl_gen_48.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_48.Size = new System.Drawing.Size(98, 15);
			_lbl_gen_48.TabIndex = 223;
			_lbl_gen_48.Text = "Status:";
			_lbl_gen_48.Visible = false;
			_lbl_gen_48.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// _lbl_gen_4
			// 
			_lbl_gen_4.AllowDrop = true;
			_lbl_gen_4.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_4.Location = new System.Drawing.Point(228, 112);
			_lbl_gen_4.MinimumSize = new System.Drawing.Size(90, 28);
			_lbl_gen_4.Name = "_lbl_gen_4";
			_lbl_gen_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_4.Size = new System.Drawing.Size(90, 28);
			_lbl_gen_4.TabIndex = 164;
			_lbl_gen_4.Text = "Start Date:";
			_lbl_gen_4.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// _lbl_gen_0
			// 
			_lbl_gen_0.AllowDrop = true;
			_lbl_gen_0.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_0.Location = new System.Drawing.Point(200, 60);
			_lbl_gen_0.MinimumSize = new System.Drawing.Size(57, 14);
			_lbl_gen_0.Name = "_lbl_gen_0";
			_lbl_gen_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_0.Size = new System.Drawing.Size(57, 14);
			_lbl_gen_0.TabIndex = 162;
			_lbl_gen_0.Text = "Date Scale:";
			_lbl_gen_0.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// _lbl_gen_3
			// 
			_lbl_gen_3.AllowDrop = true;
			_lbl_gen_3.AutoSize = true;
			_lbl_gen_3.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_3.Location = new System.Drawing.Point(188, 160);
			_lbl_gen_3.MinimumSize = new System.Drawing.Size(51, 13);
			_lbl_gen_3.Name = "_lbl_gen_3";
			_lbl_gen_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_3.Size = new System.Drawing.Size(51, 13);
			_lbl_gen_3.TabIndex = 160;
			_lbl_gen_3.Text = "TimeZone:";
			_lbl_gen_3.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// Label42
			// 
			Label42.AllowDrop = true;
			Label42.AutoSize = true;
			Label42.BackColor = System.Drawing.Color.Transparent;
			Label42.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label42.ForeColor = System.Drawing.SystemColors.ControlText;
			Label42.Location = new System.Drawing.Point(0, 24);
			Label42.MinimumSize = new System.Drawing.Size(88, 13);
			Label42.Name = "Label42";
			Label42.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label42.Size = new System.Drawing.Size(88, 13);
			Label42.TabIndex = 159;
			Label42.Text = "Type of Research:";
			Label42.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// Label47
			// 
			Label47.AllowDrop = true;
			Label47.BackColor = System.Drawing.SystemColors.Control;
			Label47.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label47.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label47.ForeColor = System.Drawing.SystemColors.ControlText;
			Label47.Location = new System.Drawing.Point(8, 24);
			Label47.MinimumSize = new System.Drawing.Size(105, 20);
			Label47.Name = "Label47";
			Label47.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label47.Size = new System.Drawing.Size(105, 20);
			Label47.TabIndex = 155;
			Label47.Text = "On Order";
			// 
			// Label46
			// 
			Label46.AllowDrop = true;
			Label46.BackColor = System.Drawing.SystemColors.Control;
			Label46.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label46.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label46.ForeColor = System.Drawing.SystemColors.ControlText;
			Label46.Location = new System.Drawing.Point(0, 24);
			Label46.MinimumSize = new System.Drawing.Size(65, 20);
			Label46.Name = "Label46";
			Label46.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label46.Size = new System.Drawing.Size(65, 20);
			Label46.TabIndex = 154;
			Label46.Text = "On Order";
			// 
			// _lbl_gen_6
			// 
			_lbl_gen_6.AllowDrop = true;
			_lbl_gen_6.AutoSize = true;
			_lbl_gen_6.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_6.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_6.Location = new System.Drawing.Point(8, 60);
			_lbl_gen_6.MinimumSize = new System.Drawing.Size(66, 13);
			_lbl_gen_6.Name = "_lbl_gen_6";
			_lbl_gen_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_6.Size = new System.Drawing.Size(66, 13);
			_lbl_gen_6.TabIndex = 139;
			_lbl_gen_6.Text = "Account Rep:";
			_lbl_gen_6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			_lbl_gen_6.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// _lbl_gen_2
			// 
			_lbl_gen_2.AllowDrop = true;
			_lbl_gen_2.AutoSize = true;
			_lbl_gen_2.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_2.Location = new System.Drawing.Point(90, 138);
			_lbl_gen_2.MinimumSize = new System.Drawing.Size(88, 13);
			_lbl_gen_2.Name = "_lbl_gen_2";
			_lbl_gen_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_2.Size = new System.Drawing.Size(88, 13);
			_lbl_gen_2.TabIndex = 138;
			_lbl_gen_2.Text = "Type of Research:";
			_lbl_gen_2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			_lbl_gen_2.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// _lbl_gen_1
			// 
			_lbl_gen_1.AllowDrop = true;
			_lbl_gen_1.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_1.Location = new System.Drawing.Point(191, 80);
			_lbl_gen_1.MinimumSize = new System.Drawing.Size(90, 28);
			_lbl_gen_1.Name = "_lbl_gen_1";
			_lbl_gen_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_1.Size = new System.Drawing.Size(90, 28);
			_lbl_gen_1.TabIndex = 15;
			_lbl_gen_1.Text = "Dates Less Than or Equal to:";
			_lbl_gen_1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_gen_1.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// frm_ActionList
			// 
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			BackColor = System.Drawing.SystemColors.Control;
			ClientSize = new System.Drawing.Size(1029, 704);
			ControlBox = false;
			Controls.Add(chk_alt_rep);
			Controls.Add(cmdNewCustSubData);
			Controls.Add(tab_callback);
			Controls.Add(txt_ListStartDate);
			Controls.Add(cbo_TimeScale);
			Controls.Add(cbo_Timezones);
			Controls.Add(cmbProductType);
			Controls.Add(cmd_Update_Callback_Dates);
			Controls.Add(cmd_New_Avail);
			Controls.Add(cmd_Fix_Fract_Owners);
			Controls.Add(txt_Callback_Date);
			Controls.Add(Adodc_CallBack);
			Controls.Add(cmdStop);
			Controls.Add(pnl_lstcompany);
			Controls.Add(cal_Callback);
			Controls.Add(cbo_account_id);
			Controls.Add(tbr_AL_ToolBar);
			Controls.Add(SSPanel1);
			Controls.Add(text_airbp_remarks);
			Controls.Add(pnl_Wait);
			Controls.Add(lbl_Test_omg);
			Controls.Add(_lbl_gen_57);
			Controls.Add(_lbl_gen_48);
			Controls.Add(_lbl_gen_4);
			Controls.Add(_lbl_gen_0);
			Controls.Add(_lbl_gen_3);
			Controls.Add(Label42);
			Controls.Add(Label47);
			Controls.Add(Label46);
			Controls.Add(_lbl_gen_6);
			Controls.Add(_lbl_gen_2);
			Controls.Add(_lbl_gen_1);
			Controls.Add(Label3);
			Controls.Add(MainMenu1);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Location = new System.Drawing.Point(348, 221);
			MaximizeBox = true;
			MinimizeBox = true;
			Name = "frm_ActionList";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			Text = "Account Representative Action List";
			WindowState = System.Windows.Forms.FormWindowState.Maximized;
			commandButtonHelper1.SetStyle(cmdNewCustSubData, 0);
			commandButtonHelper1.SetStyle(cmdRefresh, 0);
			commandButtonHelper1.SetStyle(cmdSelDClick, 0);
			commandButtonHelper1.SetStyle(cmd_Refresh_Reassignments, 0);
			commandButtonHelper1.SetStyle(cmd_Refresh_CompColorConfirm, 0);
			commandButtonHelper1.SetStyle(_cmd_refresh_2, 0);
			commandButtonHelper1.SetStyle(_cmd_refresh_1, 0);
			commandButtonHelper1.SetStyle(_cmd_export_docs_1, 0);
			commandButtonHelper1.SetStyle(_cmd_refresh_0, 0);
			commandButtonHelper1.SetStyle(cmdRefreshFractOwners, 0);
			commandButtonHelper1.SetStyle(cmd_ClearFractionalReassign, 0);
			commandButtonHelper1.SetStyle(cmd_Refresh_Wanted, 0);
			commandButtonHelper1.SetStyle(cmdRefreshAvailAircraft, 0);
			commandButtonHelper1.SetStyle(_cmd_export_docs_2, 0);
			commandButtonHelper1.SetStyle(_cmd_export_docs_0, 0);
			commandButtonHelper1.SetStyle(cmd_DocsInProcessRefresh, 0);
			commandButtonHelper1.SetStyle(cmdFillEvents, 0);
			commandButtonHelper1.SetStyle(cmd_Refresh_Yacht_Callback_List, 0);
			commandButtonHelper1.SetStyle(cmdOwrOprRefresh, 0);
			commandButtonHelper1.SetStyle(cmdFindDupsRefresh, 0);
			commandButtonHelper1.SetStyle(cmdFindACNoBaseRefresh, 0);
			commandButtonHelper1.SetStyle(cmdFindACNoCHPRefresh, 0);
			commandButtonHelper1.SetStyle(cmdCSDChangeAcctRep, 0);
			commandButtonHelper1.SetStyle(cmd_in_progress, 0);
			commandButtonHelper1.SetStyle(cmdSubDataEMail, 0);
			commandButtonHelper1.SetStyle(cmdFindCustSubDataRefresh, 0);
			commandButtonHelper1.SetStyle(cmdResearchReportsExport, 0);
			commandButtonHelper1.SetStyle(cmdResearchReportsRefresh, 0);
			commandButtonHelper1.SetStyle(_cmd_refresh_4, 0);
			commandButtonHelper1.SetStyle(_cmd_refresh_5, 0);
			commandButtonHelper1.SetStyle(cmd_Update_Callback_Dates, 0);
			commandButtonHelper1.SetStyle(cmd_New_Avail, 0);
			commandButtonHelper1.SetStyle(cmd_Fix_Fract_Owners, 0);
			commandButtonHelper1.SetStyle(cmdStop, 0);
			commandButtonHelper1.SetStyle(cmd_contacts_phone, 0);
			commandButtonHelper1.SetStyle(cmd_ClearReassign, 0);
			commandButtonHelper1.SetStyle(cmdFindLikeCompany, 0);
			commandButtonHelper1.SetStyle(cmdConfirmExclusive, 0);
			listBoxComboBoxHelper1.SetItemData(cmbYachtCallbackType, new int[]{0, 0, 0, 0});
			listBoxHelper1.SetSelectionMode(lst_primary, System.Windows.Forms.SelectionMode.One);
			listBoxHelper1.SetSelectionMode(lstEventCat, System.Windows.Forms.SelectionMode.MultiExtended);
			listBoxHelper1.SetSelectionMode(lstCompany, System.Windows.Forms.SelectionMode.One);
			optionButtonHelper1.SetStyle(_optSearchCust_2, 0);
			optionButtonHelper1.SetStyle(_optSearchCust_1, 0);
			optionButtonHelper1.SetStyle(_optSearchCust_0, 0);
			optionButtonHelper1.SetStyle(opt_last30, 0);
			optionButtonHelper1.SetStyle(opt_AllReassigns, 0);
			optionButtonHelper1.SetStyle(_opHBAircraftYacht_0, 0);
			optionButtonHelper1.SetStyle(_opHBAircraftYacht_1, 0);
			optionButtonHelper1.SetStyle(optFractionalOwners, 0);
			optionButtonHelper1.SetStyle(optBadFractions, 0);
			optionButtonHelper1.SetStyle(opt_OwnersPendingSale, 0);
			optionButtonHelper1.SetStyle(Opt_Reassigned, 0);
			optionButtonHelper1.SetStyle(Opt_FracWithPrimaryWhole, 0);
			optionButtonHelper1.SetStyle(opSubmitBoth, 0);
			optionButtonHelper1.SetStyle(opSubmitCompany, 0);
			optionButtonHelper1.SetStyle(opSubmitAircraft, 0);
			ToolTipMain.SetToolTip(frmCustomers, "Search for Non-Customers");
			ToolTipMain.SetToolTip(_optSearchCust_2, "Search for Customers Only");
			ToolTipMain.SetToolTip(_optSearchCust_1, "Search for Customers Only");
			ToolTipMain.SetToolTip(_optSearchCust_0, "Search for Both Customers and Non-Customers");
			ToolTipMain.SetToolTip(lblReassignStopLoading, "Click To Stop Loading");
			ToolTipMain.SetToolTip(Label2, "Click To Stop Loading");
			ToolTipMain.SetToolTip(_chk_action_list_9, "Check to View Docs Ordered");
			ToolTipMain.SetToolTip(_chk_action_list_10, "Check to View Doc's Being Sent");
			ToolTipMain.SetToolTip(lblPEventStop, "Click To Stop Loading");
			ToolTipMain.SetToolTip(chkAllYachtCallbackRecords, "Check This To Display ALL Yacht Callback Records (Default=250)");
			ToolTipMain.SetToolTip(lblYTCallbackStop, "Click To Stop Loading");
			ToolTipMain.SetToolTip(lblOwrOprStop, "Click To Stop Loading");
			ToolTipMain.SetToolTip(cmdOwrOprRefresh, "Click To Search Owners=Owners ");
			ToolTipMain.SetToolTip(cmdFindDupsRefresh, "Click To Search Find Duplicates");
			ToolTipMain.SetToolTip(lblFindDupsStop, "Click To Stop Loading");
			ToolTipMain.SetToolTip(lblFindACNoBaseStop, "Click To Stop Loading");
			ToolTipMain.SetToolTip(cmdFindACNoBaseRefresh, "Click To Search Find Duplicates");
			ToolTipMain.SetToolTip(cmdFindACNoCHPRefresh, "Click To Search Find Duplicates");
			ToolTipMain.SetToolTip(lblFindACNoCHPStop, "Click To Stop Loading");
			ToolTipMain.SetToolTip(opSubmitBoth, "Click To See Submitted Data on Aircraft and Company");
			ToolTipMain.SetToolTip(opSubmitCompany, "Click To See Submitted Data on Company");
			ToolTipMain.SetToolTip(opSubmitAircraft, "Click To See Submitted Data on Aircraft");
			ToolTipMain.SetToolTip(cmdSubDataEMail, "Click To Send EMail To Customer");
			ToolTipMain.SetToolTip(chkCustSubDataIncludeCompleted, "Click To Include Completed Data");
			ToolTipMain.SetToolTip(cmdFindCustSubDataRefresh, "Click To Search Find Duplicates");
			ToolTipMain.SetToolTip(lblFindCustSubDataStop, "Click To Stop Loading");
			ToolTipMain.SetToolTip(chkSortDesc, "Temp Disable - DDC");
			ToolTipMain.SetToolTip(cmdResearchReportsExport, "Click To Export To Excel");
			ToolTipMain.SetToolTip(cmdResearchReportsRefresh, "Click To Refresh List");
			ToolTipMain.SetToolTip(_lbl_gen_38, "Click To View Description of Report");
			ToolTipMain.SetToolTip(lblFindResearchReportsStop, "Click To Stop Loading");
			Activated += new System.EventHandler(Form_Activated);
			Closed += new System.EventHandler(Form_Closed);
			MouseMove += new System.Windows.Forms.MouseEventHandler(Form_MouseMove);
			((System.ComponentModel.ISupportInitialize) grd_Callbacks).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_NewAssignments).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_CompConfirm).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_Exclusives).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_Hot_Items).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_expired_leases).EndInit();
			((System.ComponentModel.ISupportInitialize) grdFractional).EndInit();
			((System.ComponentModel.ISupportInitialize) grdBadFractions).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_WantedList).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_AvailableAircraft).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_DocumentLog).EndInit();
			((System.ComponentModel.ISupportInitialize) grdPriorityEvents).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_Yacht_Callbacks).EndInit();
			((System.ComponentModel.ISupportInitialize) fgrdOwrOpr).EndInit();
			((System.ComponentModel.ISupportInitialize) fgrdFindDups).EndInit();
			((System.ComponentModel.ISupportInitialize) fgrdFindACNoBase).EndInit();
			((System.ComponentModel.ISupportInitialize) fgrdFindACNoCHP).EndInit();
			((System.ComponentModel.ISupportInitialize) fgrdFindCustSubData).EndInit();
			((System.ComponentModel.ISupportInitialize) fgrdFindResearchReports).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_issues).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_salesforce).EndInit();
			((System.ComponentModel.ISupportInitialize) listBoxComboBoxHelper1).EndInit();
			((System.ComponentModel.ISupportInitialize) Adodc_CallBack).EndInit();
			tab_callback.ResumeLayout(false);
			tab_callback.PerformLayout();
			_tab_callback_TabPage0.ResumeLayout(false);
			_tab_callback_TabPage0.PerformLayout();
			pnl_Callbacks.ResumeLayout(false);
			pnl_Callbacks.PerformLayout();
			frmCustomers.ResumeLayout(false);
			frmCustomers.PerformLayout();
			_tab_callback_TabPage1.ResumeLayout(false);
			_tab_callback_TabPage1.PerformLayout();
			pnl_reassignemnt.ResumeLayout(false);
			pnl_reassignemnt.PerformLayout();
			_tab_callback_TabPage2.ResumeLayout(false);
			_tab_callback_TabPage2.PerformLayout();
			_tab_callback_TabPage3.ResumeLayout(false);
			_tab_callback_TabPage3.PerformLayout();
			pnl_Exclusives.ResumeLayout(false);
			pnl_Exclusives.PerformLayout();
			pnl_primary.ResumeLayout(false);
			pnl_primary.PerformLayout();
			_tab_callback_TabPage4.ResumeLayout(false);
			_tab_callback_TabPage4.PerformLayout();
			pnl_Hot_Items.ResumeLayout(false);
			pnl_Hot_Items.PerformLayout();
			_tab_callback_TabPage5.ResumeLayout(false);
			_tab_callback_TabPage5.PerformLayout();
			_tab_callback_TabPage6.ResumeLayout(false);
			_tab_callback_TabPage6.PerformLayout();
			pnl_Fractional.ResumeLayout(false);
			pnl_Fractional.PerformLayout();
			pnl_fractional_display.ResumeLayout(false);
			pnl_fractional_display.PerformLayout();
			pnlFractionalPercentagesBad.ResumeLayout(false);
			pnlFractionalPercentagesBad.PerformLayout();
			_tab_callback_TabPage7.ResumeLayout(false);
			_tab_callback_TabPage7.PerformLayout();
			_tab_callback_TabPage8.ResumeLayout(false);
			_tab_callback_TabPage8.PerformLayout();
			pnl_AvailableAircraft.ResumeLayout(false);
			pnl_AvailableAircraft.PerformLayout();
			_tab_callback_TabPage9.ResumeLayout(false);
			_tab_callback_TabPage9.PerformLayout();
			_tab_callback_TabPage10.ResumeLayout(false);
			_tab_callback_TabPage10.PerformLayout();
			fraDateTimeRange.ResumeLayout(false);
			fraDateTimeRange.PerformLayout();
			_tab_callback_TabPage11.ResumeLayout(false);
			_tab_callback_TabPage11.PerformLayout();
			_tab_callback_TabPage12.ResumeLayout(false);
			_tab_callback_TabPage12.PerformLayout();
			_tab_callback_TabPage13.ResumeLayout(false);
			_tab_callback_TabPage13.PerformLayout();
			frm_Yacht_Callback.ResumeLayout(false);
			frm_Yacht_Callback.PerformLayout();
			_tab_callback_TabPage14.ResumeLayout(false);
			_tab_callback_TabPage14.PerformLayout();
			_tab_callback_TabPage15.ResumeLayout(false);
			_tab_callback_TabPage15.PerformLayout();
			_tab_callback_TabPage16.ResumeLayout(false);
			_tab_callback_TabPage16.PerformLayout();
			_tab_callback_TabPage17.ResumeLayout(false);
			_tab_callback_TabPage17.PerformLayout();
			_tab_callback_TabPage18.ResumeLayout(false);
			_tab_callback_TabPage18.PerformLayout();
			_tab_callback_TabPage19.ResumeLayout(false);
			_tab_callback_TabPage19.PerformLayout();
			_tab_callback_TabPage21.ResumeLayout(false);
			_tab_callback_TabPage21.PerformLayout();
			_tab_callback_TabPage22.ResumeLayout(false);
			_tab_callback_TabPage22.PerformLayout();
			pnl_lstcompany.ResumeLayout(false);
			pnl_lstcompany.PerformLayout();
			tbr_AL_ToolBar.ResumeLayout(false);
			tbr_AL_ToolBar.PerformLayout();
			SSPanel1.ResumeLayout(false);
			SSPanel1.PerformLayout();
			pnl_Wait.ResumeLayout(false);
			pnl_Wait.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
		void ReLoadForm(bool addEvents)
		{
			InitializeoptSearchCust();
			InitializeopHBAircraftYacht();
			Initializelbl_gen();
			Initializecmd_refresh();
			Initializecmd_export_docs();
			Initializechk_action_list();
			Initializecbo_multi();
			InitializeLabel37();
			InitializeLabel36();
			InitializeLabel35();
			tab_callbackPreviousTab = tab_callback.SelectedIndex;
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			MdiParent = JETNET_Homebase.mdi_ResearchAssistant.DefInstance;
			JETNET_Homebase.mdi_ResearchAssistant.DefInstance.Show();
			Form_Initialize();
		}
		void InitializeoptSearchCust()
		{
			optSearchCust = new System.Windows.Forms.RadioButton[3];
			optSearchCust[2] = _optSearchCust_2;
			optSearchCust[1] = _optSearchCust_1;
			optSearchCust[0] = _optSearchCust_0;
		}
		void InitializeopHBAircraftYacht()
		{
			opHBAircraftYacht = new System.Windows.Forms.RadioButton[2];
			opHBAircraftYacht[1] = _opHBAircraftYacht_1;
			opHBAircraftYacht[0] = _opHBAircraftYacht_0;
		}
		void Initializelbl_gen()
		{
			lbl_gen = new System.Windows.Forms.Label[58];
			lbl_gen[49] = _lbl_gen_49;
			lbl_gen[47] = _lbl_gen_47;
			lbl_gen[46] = _lbl_gen_46;
			lbl_gen[45] = _lbl_gen_45;
			lbl_gen[44] = _lbl_gen_44;
			lbl_gen[43] = _lbl_gen_43;
			lbl_gen[42] = _lbl_gen_42;
			lbl_gen[41] = _lbl_gen_41;
			lbl_gen[35] = _lbl_gen_35;
			lbl_gen[33] = _lbl_gen_33;
			lbl_gen[31] = _lbl_gen_31;
			lbl_gen[17] = _lbl_gen_17;
			lbl_gen[18] = _lbl_gen_18;
			lbl_gen[40] = _lbl_gen_40;
			lbl_gen[8] = _lbl_gen_8;
			lbl_gen[7] = _lbl_gen_7;
			lbl_gen[14] = _lbl_gen_14;
			lbl_gen[11] = _lbl_gen_11;
			lbl_gen[12] = _lbl_gen_12;
			lbl_gen[9] = _lbl_gen_9;
			lbl_gen[55] = _lbl_gen_55;
			lbl_gen[54] = _lbl_gen_54;
			lbl_gen[53] = _lbl_gen_53;
			lbl_gen[52] = _lbl_gen_52;
			lbl_gen[39] = _lbl_gen_39;
			lbl_gen[38] = _lbl_gen_38;
			lbl_gen[37] = _lbl_gen_37;
			lbl_gen[36] = _lbl_gen_36;
			lbl_gen[32] = _lbl_gen_32;
			lbl_gen[13] = _lbl_gen_13;
			lbl_gen[10] = _lbl_gen_10;
			lbl_gen[16] = _lbl_gen_16;
			lbl_gen[15] = _lbl_gen_15;
			lbl_gen[5] = _lbl_gen_5;
			lbl_gen[57] = _lbl_gen_57;
			lbl_gen[48] = _lbl_gen_48;
			lbl_gen[4] = _lbl_gen_4;
			lbl_gen[0] = _lbl_gen_0;
			lbl_gen[3] = _lbl_gen_3;
			lbl_gen[6] = _lbl_gen_6;
			lbl_gen[2] = _lbl_gen_2;
			lbl_gen[1] = _lbl_gen_1;
		}
		void Initializecmd_refresh()
		{
			cmd_refresh = new System.Windows.Forms.Button[6];
			cmd_refresh[5] = _cmd_refresh_5;
			cmd_refresh[4] = _cmd_refresh_4;
			cmd_refresh[1] = _cmd_refresh_1;
			cmd_refresh[0] = _cmd_refresh_0;
			cmd_refresh[2] = _cmd_refresh_2;
		}
		void Initializecmd_export_docs()
		{
			cmd_export_docs = new System.Windows.Forms.Button[3];
			cmd_export_docs[2] = _cmd_export_docs_2;
			cmd_export_docs[1] = _cmd_export_docs_1;
			cmd_export_docs[0] = _cmd_export_docs_0;
		}
		void Initializechk_action_list()
		{
			chk_action_list = new System.Windows.Forms.CheckBox[14];
			chk_action_list[13] = _chk_action_list_13;
			chk_action_list[12] = _chk_action_list_12;
			chk_action_list[11] = _chk_action_list_11;
			chk_action_list[10] = _chk_action_list_10;
			chk_action_list[9] = _chk_action_list_9;
			chk_action_list[8] = _chk_action_list_8;
			chk_action_list[7] = _chk_action_list_7;
			chk_action_list[6] = _chk_action_list_6;
			chk_action_list[5] = _chk_action_list_5;
			chk_action_list[4] = _chk_action_list_4;
			chk_action_list[3] = _chk_action_list_3;
			chk_action_list[2] = _chk_action_list_2;
			chk_action_list[1] = _chk_action_list_1;
			chk_action_list[0] = _chk_action_list_0;
		}
		void Initializecbo_multi()
		{
			cbo_multi = new System.Windows.Forms.ComboBox[3];
			cbo_multi[2] = _cbo_multi_2;
			cbo_multi[1] = _cbo_multi_1;
			cbo_multi[0] = _cbo_multi_0;
		}
		void InitializeLabel37()
		{
			Label37 = new System.Windows.Forms.Label[1];
			Label37[0] = _Label37_0;
		}
		void InitializeLabel36()
		{
			Label36 = new System.Windows.Forms.Label[1];
			Label36[0] = _Label36_0;
		}
		void InitializeLabel35()
		{
			Label35 = new System.Windows.Forms.Label[1];
			Label35[0] = _Label35_0;
		}
		#endregion
	}
}