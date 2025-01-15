
namespace JETNET_Homebase
{
	partial class frm_Subscription
	{

		#region "Upgrade Support "
		private static frm_Subscription m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_Subscription DefInstance
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
		public static frm_Subscription CreateInstance()
		{
			frm_Subscription theInstance = new frm_Subscription();
			theInstance.Form_Load();
			return theInstance;
		}
		private void Ctx_mnuRightClick_Opening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			System.Collections.Generic.List<System.Windows.Forms.ToolStripItem> list = new System.Collections.Generic.List<System.Windows.Forms.ToolStripItem>();
			Ctx_mnuRightClick.Items.Clear();
			//We are moving the submenus from original menu to the context menu before displaying it
			foreach (System.Windows.Forms.ToolStripItem item in ((System.Windows.Forms.ToolStripMenuItem) mnuRightClick).DropDownItems)
			{
				list.Add(item);
			}
			foreach (System.Windows.Forms.ToolStripItem item in list)
			{
				Ctx_mnuRightClick.Items.Add(item);
			}
			e.Cancel = false;
		}
		private void Ctx_mnuRightClick_Closed(object sender, System.Windows.Forms.ToolStripDropDownClosedEventArgs e)
		{
			System.Collections.Generic.List<System.Windows.Forms.ToolStripItem> list = new System.Collections.Generic.List<System.Windows.Forms.ToolStripItem>();
			//We are moving the submenus the context menu back to the original menu after displaying
			foreach (System.Windows.Forms.ToolStripItem item in Ctx_mnuRightClick.Items)
			{
				list.Add(item);
			}
			foreach (System.Windows.Forms.ToolStripItem item in list)
			{
				((System.Windows.Forms.ToolStripMenuItem) mnuRightClick).DropDownItems.Add(item);
			}
		}
		private string[] visualControls = new string[]{"components", "ToolTipMain", "mnuMPMManagement", "mnuRightClick", "MainMenu1", "_cmdSubscription_4", "_cmdSubscription_3", "_cmdSubscription_2", "_cmdSubscription_1", "_cmdSubscription_0", "_lblSubLabel_27", "frmSubscriptionAction", "chkIncludeInactive", "grd_Subscriptions", "_wbSubBrowser1_4", "_lblSubLabel_5", "frm_Sub_Id", "_chkProductType_13", "cbo_Service", "cmbTierLevel_comm", "chk_sub_api_flag", "txt_sub_billed_amount", "_txt_SubNbrOfInstalls_2", "_chkProductType_12", "_chkProductType_11", "_txt_SubNbrOfInstalls_1", "_chkProductType_10", "_chkProductType_9", "_chkProductType_8", "_chkProductType_7", "_chkProductType_6", "_chkProductType_5", "_chkProductType_4", "_chkProductType_3", "_chkProductType_1", "txt_sub_start_date", "txt_sub_end_date", "txt_SubContractAmount", "_txt_SubNbrOfInstalls_0", "cmbTierLevel", "_chkProductType_0", "txt_sub_id", "cmbFrequency", "txtNbrDaysExpire", "txtSubMaxExport", "lbl_Service", "_lblSubLabel_15", "_lblSubLabel_56", "_lblSubLabel_54", "_lblSubLabel_51", "lblSubUpdateNbrInstalls", "_lblSubLabel_3", "lblCalendars", "lbl_SubNbrOfInstalls", "_lblSubLabel_4", "_lblSubLabel_0", "_lblSubLabel_29", "lblNbrDaysExpire", "_lblSubLabel_2", "frmSubOptions", "txtCallbackComments", "cboCallBackStatus", "txtCallBackDate", "calCallBackDate", "_lblSubLabel_70", "lblServerSideNotes", "_lblSubLabel_7", "_lblSubLabel_6", "frmCallbackStatus", "cal_sub_start_date", "cal_sub_end_date", "lblEndDate", "lblStartDate", "frmStartEndDate", "frm_Sub_Service", "frm_Subscription_Top", "cmdUpload", "cmdUpdateCRMSite", "cmdNewLogin", "cmd_New_Installation", "cmd_Close", "frm_Sub_Command", "chkInstallAdministrator", "txtCellNumber", "cboCellCarrier", "txtTextMsgModels", "txtMobileActiveDate", "txtSMSTextActiveFlag", "txtSMSEvents", "chkInstallEvoMobile", "cmdInstallValidateSMSTxtMsg", "lblSendTxtMsg", "_lblSubLabel_16", "_lblSubLabel_17", "_lblSubLabel_18", "_lblSubLabel_19", "_lblSubLabel_20", "_lblSubLabel_21", "lblSendTextMsgEvoMobileLink", "lblSendTextMsgOK", "frmSMSTextMsg", "grd_Installations", "cmdSubInsValidate", "cmbSubInsContact", "txtSubDefaultAModId", "cmdDeleteInstallation", "cmdUpdateInstallation", "cmd_InstallCancel", "txt_SubInsContractAmount", "cmdClearInstallDate", "txt_Platform_OS", "txtReplyName", "txtReplyEMail", "txtSubInsNbrRecPerPage", "txtSubInsDefaultAnalysisMths", "cmbSubInsBGImageId", "chkDefaultHTMLEMail", "chkInstallationDisplayNoteTag", "_lblSubLabel_69", "_lblSubLabel_66", "lblSubDefaultAModId", "_lblSubLabel_10", "_lblSubLabel_12", "_lblSubLabel_13", "_lblSubLabel_1", "_lblSubLabel_55", "_lblSubLabel_22", "frmInstallFlags", "lblSubInsViewEvoMobileLogs", "lblSubInsViewSMSTextMsgsReceived", "lblSubInsViewSMSTextMsgsSent", "lblSubInsViewWebReport", "frmInstallASPLogs", "_lblSubLabel_8", "_lblSubLabel_31", "_InstallLinkLabel_2", "_InstallLinkLabel_1", "_InstallLinkLabel_0", "_lblSubLabel_14", "fra_Add_Installation", "grd_Logins", "cbo_build", "txt_auth_phone", "txt_auth_last_action", "_cmd_auth_btn_1", "_cmd_auth_btn_0", "cbo_auth_type", "cbo_auth_cycle", "chk_auth_status", "_lblSubLabel_9", "_lblSubLabel_68", "_lblSubLabel_67", "_lblSubLabel_65", "_lblSubLabel_64", "_lblSubLabel_63", "_lblSubLabel_62", "_lblSubLabel_61", "_lblSubLabel_60", "_lblSubLabel_58", "frm_authentication", "_chkLoginFlag_2", "_chkLoginFlag_5", "_chkLoginFlag_7", "_chkLoginFlag_10", "_chkLoginFlag_9", "_chkLoginFlag_6", "_chkLoginFlag_1", "_chkLoginFlag_0", "lblLoginFlagsHide", "frmLoginFlags", "txt_sublogin_billed_amount", "cmdMoveLoginFrame", "cmd_SaveUser", "cmdCancelLoginFrame", "txt_sub_password", "txt_SubLoginContractAmount", "txt_SubLoginNbrOfInstalls", "cmd_DeleteLogin", "cmdEMailSubNotice", "cmdResetDemoLogin", "cmdGeneratePassword", "txtLoginName", "_lblSubLabel_73", "_lblSubLabel_57", "Label1", "lblSubAddInstall", "lblLoginShowFlags", "lbl_Password", "lbl_SubLoginContractAmount", "lbl_SubLoginNbrOfInstalls", "lblSubInsContact", "fraLogin", "_chkLoginFlag_3", "chkInstallationChatFlag", "chkInstallationUseLocalNotes", "_chkLoginFlag_8", "_chkLoginFlag_4", "txtInstallationPathToLocalDB", "chkInstallationActive", "chkActiveXFlag", "chkAutoCheckTS", "chkTerminalService", "cboSubBType", "txtWebPageTimeOut", "txt_Platform_Name", "_lblSubLabel_11", "_lblSubLabel_47", "frm_old_Invisible", "fra_Bottom", "_SSTab_Subscription_TabPage0", "txt_SubJournalDescription", "txt_SubJournalSubject", "cmdSubNoteNew", "cmdSubNoteSave", "frmSubscriptionNotesControl", "txt_SubJournalId", "grd_SubJournalNotes", "_lblSubLabel_53", "_lblSubLabel_52", "_lblSubLabel_37", "_lblSubLabel_36", "_lblSubLabel_35", "frmSubscriptionNotes", "_SSTab_Subscription_TabPage1", "txtSubExpirationDate", "txtSubDragDocument", "txtSubDocumentDate", "cmbSubDocumentType", "txtSubDocumentId", "cmdSubDocumentMove", "cmdSubDocumentDelete", "cmdSubDocumentView", "cmdSubDocumentSave", "cmdSubDocumentNew", "frmSubDocumentControl", "txtSubDocumentSubject", "txtSubDocumentDescription", "grd_SubDocument", "calSubDocumentDate", "_wbSubBrowser1_0", "calSubExpirationDate", "_lblSubLabel_49", "_lblSubLabel_48", "_lblSubLabel_41", "_lblSubLabel_40", "_lblSubLabel_39", "_lblSubLabel_38", "lblSubDocumentId", "frmSubscriptionContracts", "_SSTab_Subscription_TabPage2", "lstb_SubExecutionFormsDisplay", "_wbSubBrowser1_3", "frm_SubExecutionFormsDisplay", "grd_SubExecutionForms", "frm_SubExecutionFormsGrid", "_txtSubExc_Type_1", "_txtSubExc_MonthlyAmt_2", "_txtSubExc_MonthlyAmt_1", "txtSubExc_Notes", "txtSubExc_Status", "_txtSubExc_MonthlyAmt_0", "_txtSubExc_Type_0", "txtSubExc_Service", "txtSubExc_ContractNbr", "txtSubExc_ADisableDate", "txtSubExc_SrvChgDate", "txtSubExc_CLetterDate", "txtSubExc_ContractDate", "txtSubExc_ExcDate", "txtSubExc_SubId", "_lblSubExc_Type_2", "_lblSubExc_MonthlyAmt_6", "_lblSubExc_MonthlyAmt_5", "_lblSubExc_MonthlyAmt_4", "_lblSubExc_MonthlyAmt_3", "_lblSubExc_Type_1", "_lblSubExc_MonthlyAmt_2", "_lblSubExc_MonthlyAmt_1", "_lblSubLabel_43", "_lblSubLabel_42", "_lblSubExc_MonthlyAmt_0", "_lblSubExc_Type_0", "lblSubExc_Service", "lblSubExc_ContractNbr", "frm_SubExecutionFormsData", "_SSTab_Subscription_TabPage3", "txtSubSISubId", "txtSubSIApprovedBy", "chkSubSIChangeAutoDisable", "chkSubSIAccoutingIssues", "chkSubSICancellation", "chkSubSIStopUpdates", "chkSubSIStopEvolution", "frmSubSIDocCheckBoxes", "txtSubSIAutoDisableDate", "txtSubSIDocInterruptDate", "txtSubSIDocRequestedDate", "lblSubSIAutoDisableDate", "lblSubSIDocInterruptDate", "lblSubSIDocRequestedDate", "frmSubSIDocDates", "cmdSubSIDocView", "frmSubSIDocView", "txtSubSIDocId", "grd_SubSIDocument", "_wbSubBrowser1_1", "lblSubSIViewOnly", "lblSubSISubId", "lblSubSIApprovedBy", "lblSubSIDocId", "frmSubSIDocControl", "_SSTab_Subscription_TabPage4", "cboWebReports", "_wbSubBrowser1_2", "lblWebReportsURL", "lblWebReportProcessing", "_SSTab_Subscription_TabPage5", "txtTotalRecordsInCloudNotes", "txtImportCloudNotesFromDate", "pbImportCNotesToCRMNotes", "_cmdSubNotesButton_10", "txtTotalImportedFromCloudNotesToSSNotes", "_cmdSubNotesButton_7", "_lblSubLabel_46", "_lblSubLabel_45", "_lblSubLabel_44", "frmImportCloudNotesToCRMSSN", "_cmdSubNotesButton_6", "txtTotalRecordsInSSNotes", "txtTotalImportedFromSSNToCloudNotes", "_cmdSubNotesButton_9", "rbCopySSNToCNOverwriteCloudNotes", "rbCopySSNToCNAppendCloudNotes", "pbImportSSNotes", "_lblSubLabel_30", "_lblSubLabel_28", "frmImportCRMSSNToCloudNotes", "txtPathToEvoLocalNotes", "_cmdSubNotesButton_5", "_cmdSubNotesButton_8", "rbEvoLocalNotesOverrideCloudNotes", "rbEvoLocalNotesAppendCloudNotes", "txtTotalImportedFromLocalNotesToEvoCloudNotes", "txtTotalRecordsInEvoLocalNotes", "_cmdSubNotesButton_4", "rbEvoLocalNotesPurgeImportCloudNotes", "pbImportEvoLocalNotes", "_lblSubLabel_24", "_lblSubLabel_23", "_lblSubLabel_26", "frmImportEvoLocalNotesToCloudNotes", "_cmdSubNotesButton_3", "_cmdSubNotesButton_2", "cmbCloudNotesDatabaseName", "chkCloudNotesFlag", "Label3", "_lblSubLabel_25", "frmCloudNotes", "_cmdSubNotesButton_1", "_cmdSubNotesButton_0", "chkServerSideNotes", "cmbCRMDatabaseName", "txtCRMRegId", "lblCRMDatabaseName", "lblCRMRegId", "lblCRMMessage", "frmServerSideNotes", "_SSTab_Subscription_TabPage6", "SSTab_Subscription", "cmdIdentifyContact", "cmdClearContact", "_txt_find_sub_2", "_txt_find_sub_0", "_txt_find_sub_1", "_cmd_find_contact_1", "_cmd_find_contact_0", "cboChooseContact", "cmdChooseContactSave", "cmdChooseContactCancel", "_lblSubLabel_71", "_lblSubLabel_59", "_lblSubLabel_32", "fra_ChooseContact", "lst_Company", "lst_Contact", "_lblSubLabel_34", "_lblSubLabel_33", "fra_Contact_Info", "_lblPleaseWaitStatus_0", "_lblPleaseWait_85", "pnl_Please_Wait", "InstallLinkLabel", "chkLoginFlag", "chkProductType", "cmdSubNotesButton", "cmdSubscription", "cmd_auth_btn", "cmd_find_contact", "lblPleaseWait", "lblPleaseWaitStatus", "lblSubExc_MonthlyAmt", "lblSubExc_Type", "lblSubLabel", "txtSubExc_MonthlyAmt", "txtSubExc_Type", "txt_SubNbrOfInstalls", "txt_find_sub", "wbSubBrowser1", "Ctx_mnuRightClick", "optionButtonHelper1", "listBoxHelper1", "commandButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.ToolStripMenuItem mnuMPMManagement;
		public System.Windows.Forms.ToolStripMenuItem mnuRightClick;
		public System.Windows.Forms.MenuStrip MainMenu1;
		private System.Windows.Forms.Button _cmdSubscription_4;
		private System.Windows.Forms.Button _cmdSubscription_3;
		private System.Windows.Forms.Button _cmdSubscription_2;
		private System.Windows.Forms.Button _cmdSubscription_1;
		private System.Windows.Forms.Button _cmdSubscription_0;
		private System.Windows.Forms.Label _lblSubLabel_27;
		public System.Windows.Forms.GroupBox frmSubscriptionAction;
		public System.Windows.Forms.CheckBox chkIncludeInactive;
		public UpgradeHelpers.DataGridViewFlex grd_Subscriptions;
		private System.Windows.Forms.WebBrowser _wbSubBrowser1_4;
		private System.Windows.Forms.Label _lblSubLabel_5;
		public System.Windows.Forms.GroupBox frm_Sub_Id;
		private System.Windows.Forms.CheckBox _chkProductType_13;
		public System.Windows.Forms.ComboBox cbo_Service;
		public System.Windows.Forms.ComboBox cmbTierLevel_comm;
		public System.Windows.Forms.CheckBox chk_sub_api_flag;
		public System.Windows.Forms.TextBox txt_sub_billed_amount;
		private System.Windows.Forms.TextBox _txt_SubNbrOfInstalls_2;
		private System.Windows.Forms.CheckBox _chkProductType_12;
		private System.Windows.Forms.CheckBox _chkProductType_11;
		private System.Windows.Forms.TextBox _txt_SubNbrOfInstalls_1;
		private System.Windows.Forms.CheckBox _chkProductType_10;
		private System.Windows.Forms.CheckBox _chkProductType_9;
		private System.Windows.Forms.CheckBox _chkProductType_8;
		private System.Windows.Forms.CheckBox _chkProductType_7;
		private System.Windows.Forms.CheckBox _chkProductType_6;
		private System.Windows.Forms.CheckBox _chkProductType_5;
		private System.Windows.Forms.CheckBox _chkProductType_4;
		private System.Windows.Forms.CheckBox _chkProductType_3;
		private System.Windows.Forms.CheckBox _chkProductType_1;
		public System.Windows.Forms.TextBox txt_sub_start_date;
		public System.Windows.Forms.TextBox txt_sub_end_date;
		public System.Windows.Forms.TextBox txt_SubContractAmount;
		private System.Windows.Forms.TextBox _txt_SubNbrOfInstalls_0;
		public System.Windows.Forms.ComboBox cmbTierLevel;
		private System.Windows.Forms.CheckBox _chkProductType_0;
		public System.Windows.Forms.TextBox txt_sub_id;
		public System.Windows.Forms.ComboBox cmbFrequency;
		public System.Windows.Forms.TextBox txtNbrDaysExpire;
		public System.Windows.Forms.TextBox txtSubMaxExport;
		public System.Windows.Forms.Label lbl_Service;
		private System.Windows.Forms.Label _lblSubLabel_15;
		private System.Windows.Forms.Label _lblSubLabel_56;
		private System.Windows.Forms.Label _lblSubLabel_54;
		private System.Windows.Forms.Label _lblSubLabel_51;
		public System.Windows.Forms.Label lblSubUpdateNbrInstalls;
		private System.Windows.Forms.Label _lblSubLabel_3;
		public System.Windows.Forms.Label lblCalendars;
		public System.Windows.Forms.Label lbl_SubNbrOfInstalls;
		private System.Windows.Forms.Label _lblSubLabel_4;
		private System.Windows.Forms.Label _lblSubLabel_0;
		private System.Windows.Forms.Label _lblSubLabel_29;
		public System.Windows.Forms.Label lblNbrDaysExpire;
		private System.Windows.Forms.Label _lblSubLabel_2;
		public System.Windows.Forms.GroupBox frmSubOptions;
		public System.Windows.Forms.TextBox txtCallbackComments;
		public System.Windows.Forms.ComboBox cboCallBackStatus;
		public System.Windows.Forms.TextBox txtCallBackDate;
		public System.Windows.Forms.MonthCalendar calCallBackDate;
		private System.Windows.Forms.Label _lblSubLabel_70;
		public System.Windows.Forms.Label lblServerSideNotes;
		private System.Windows.Forms.Label _lblSubLabel_7;
		private System.Windows.Forms.Label _lblSubLabel_6;
		public System.Windows.Forms.GroupBox frmCallbackStatus;
		public System.Windows.Forms.MonthCalendar cal_sub_start_date;
		public System.Windows.Forms.MonthCalendar cal_sub_end_date;
		public System.Windows.Forms.Label lblEndDate;
		public System.Windows.Forms.Label lblStartDate;
		public System.Windows.Forms.GroupBox frmStartEndDate;
		public System.Windows.Forms.GroupBox frm_Sub_Service;
		public System.Windows.Forms.GroupBox frm_Subscription_Top;
		public System.Windows.Forms.Button cmdUpload;
		public System.Windows.Forms.Button cmdUpdateCRMSite;
		public System.Windows.Forms.Button cmdNewLogin;
		public System.Windows.Forms.Button cmd_New_Installation;
		public System.Windows.Forms.Button cmd_Close;
		public System.Windows.Forms.GroupBox frm_Sub_Command;
		public System.Windows.Forms.CheckBox chkInstallAdministrator;
		public System.Windows.Forms.TextBox txtCellNumber;
		public System.Windows.Forms.ComboBox cboCellCarrier;
		public System.Windows.Forms.TextBox txtTextMsgModels;
		public System.Windows.Forms.TextBox txtMobileActiveDate;
		public System.Windows.Forms.TextBox txtSMSTextActiveFlag;
		public System.Windows.Forms.TextBox txtSMSEvents;
		public System.Windows.Forms.CheckBox chkInstallEvoMobile;
		public System.Windows.Forms.Button cmdInstallValidateSMSTxtMsg;
		public System.Windows.Forms.Label lblSendTxtMsg;
		private System.Windows.Forms.Label _lblSubLabel_16;
		private System.Windows.Forms.Label _lblSubLabel_17;
		private System.Windows.Forms.Label _lblSubLabel_18;
		private System.Windows.Forms.Label _lblSubLabel_19;
		private System.Windows.Forms.Label _lblSubLabel_20;
		private System.Windows.Forms.Label _lblSubLabel_21;
		public System.Windows.Forms.Label lblSendTextMsgEvoMobileLink;
		public System.Windows.Forms.Label lblSendTextMsgOK;
		public System.Windows.Forms.GroupBox frmSMSTextMsg;
		public UpgradeHelpers.DataGridViewFlex grd_Installations;
		public System.Windows.Forms.Button cmdSubInsValidate;
		public System.Windows.Forms.ComboBox cmbSubInsContact;
		public System.Windows.Forms.TextBox txtSubDefaultAModId;
		public System.Windows.Forms.Button cmdDeleteInstallation;
		public System.Windows.Forms.Button cmdUpdateInstallation;
		public System.Windows.Forms.Button cmd_InstallCancel;
		public System.Windows.Forms.TextBox txt_SubInsContractAmount;
		public System.Windows.Forms.Button cmdClearInstallDate;
		public System.Windows.Forms.TextBox txt_Platform_OS;
		public System.Windows.Forms.TextBox txtReplyName;
		public System.Windows.Forms.TextBox txtReplyEMail;
		public System.Windows.Forms.TextBox txtSubInsNbrRecPerPage;
		public System.Windows.Forms.TextBox txtSubInsDefaultAnalysisMths;
		public System.Windows.Forms.ComboBox cmbSubInsBGImageId;
		public System.Windows.Forms.CheckBox chkDefaultHTMLEMail;
		public System.Windows.Forms.CheckBox chkInstallationDisplayNoteTag;
		private System.Windows.Forms.Label _lblSubLabel_69;
		private System.Windows.Forms.Label _lblSubLabel_66;
		public System.Windows.Forms.Label lblSubDefaultAModId;
		private System.Windows.Forms.Label _lblSubLabel_10;
		private System.Windows.Forms.Label _lblSubLabel_12;
		private System.Windows.Forms.Label _lblSubLabel_13;
		private System.Windows.Forms.Label _lblSubLabel_1;
		private System.Windows.Forms.Label _lblSubLabel_55;
		private System.Windows.Forms.Label _lblSubLabel_22;
		public System.Windows.Forms.GroupBox frmInstallFlags;
		public System.Windows.Forms.Label lblSubInsViewEvoMobileLogs;
		public System.Windows.Forms.Label lblSubInsViewSMSTextMsgsReceived;
		public System.Windows.Forms.Label lblSubInsViewSMSTextMsgsSent;
		public System.Windows.Forms.Label lblSubInsViewWebReport;
		public System.Windows.Forms.GroupBox frmInstallASPLogs;
		private System.Windows.Forms.Label _lblSubLabel_8;
		private System.Windows.Forms.Label _lblSubLabel_31;
		private System.Windows.Forms.Label _InstallLinkLabel_2;
		private System.Windows.Forms.Label _InstallLinkLabel_1;
		private System.Windows.Forms.Label _InstallLinkLabel_0;
		private System.Windows.Forms.Label _lblSubLabel_14;
		public System.Windows.Forms.GroupBox fra_Add_Installation;
		public UpgradeHelpers.DataGridViewFlex grd_Logins;
		public System.Windows.Forms.ComboBox cbo_build;
		public System.Windows.Forms.TextBox txt_auth_phone;
		public System.Windows.Forms.TextBox txt_auth_last_action;
		private System.Windows.Forms.Button _cmd_auth_btn_1;
		private System.Windows.Forms.Button _cmd_auth_btn_0;
		public System.Windows.Forms.ComboBox cbo_auth_type;
		public System.Windows.Forms.ComboBox cbo_auth_cycle;
		public System.Windows.Forms.CheckBox chk_auth_status;
		private System.Windows.Forms.Label _lblSubLabel_9;
		private System.Windows.Forms.Label _lblSubLabel_68;
		private System.Windows.Forms.Label _lblSubLabel_67;
		private System.Windows.Forms.Label _lblSubLabel_65;
		private System.Windows.Forms.Label _lblSubLabel_64;
		private System.Windows.Forms.Label _lblSubLabel_63;
		private System.Windows.Forms.Label _lblSubLabel_62;
		private System.Windows.Forms.Label _lblSubLabel_61;
		private System.Windows.Forms.Label _lblSubLabel_60;
		private System.Windows.Forms.Label _lblSubLabel_58;
		public System.Windows.Forms.GroupBox frm_authentication;
		private System.Windows.Forms.CheckBox _chkLoginFlag_2;
		private System.Windows.Forms.CheckBox _chkLoginFlag_5;
		private System.Windows.Forms.CheckBox _chkLoginFlag_7;
		private System.Windows.Forms.CheckBox _chkLoginFlag_10;
		private System.Windows.Forms.CheckBox _chkLoginFlag_9;
		private System.Windows.Forms.CheckBox _chkLoginFlag_6;
		private System.Windows.Forms.CheckBox _chkLoginFlag_1;
		private System.Windows.Forms.CheckBox _chkLoginFlag_0;
		public System.Windows.Forms.Label lblLoginFlagsHide;
		public System.Windows.Forms.GroupBox frmLoginFlags;
		public System.Windows.Forms.TextBox txt_sublogin_billed_amount;
		public System.Windows.Forms.Button cmdMoveLoginFrame;
		public System.Windows.Forms.Button cmd_SaveUser;
		public System.Windows.Forms.Button cmdCancelLoginFrame;
		public System.Windows.Forms.TextBox txt_sub_password;
		public System.Windows.Forms.TextBox txt_SubLoginContractAmount;
		public System.Windows.Forms.TextBox txt_SubLoginNbrOfInstalls;
		public System.Windows.Forms.Button cmd_DeleteLogin;
		public System.Windows.Forms.Button cmdEMailSubNotice;
		public System.Windows.Forms.Button cmdResetDemoLogin;
		public System.Windows.Forms.Button cmdGeneratePassword;
		public System.Windows.Forms.TextBox txtLoginName;
		private System.Windows.Forms.Label _lblSubLabel_73;
		private System.Windows.Forms.Label _lblSubLabel_57;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label lblSubAddInstall;
		public System.Windows.Forms.Label lblLoginShowFlags;
		public System.Windows.Forms.Label lbl_Password;
		public System.Windows.Forms.Label lbl_SubLoginContractAmount;
		public System.Windows.Forms.Label lbl_SubLoginNbrOfInstalls;
		public System.Windows.Forms.Label lblSubInsContact;
		public System.Windows.Forms.GroupBox fraLogin;
		private System.Windows.Forms.CheckBox _chkLoginFlag_3;
		public System.Windows.Forms.CheckBox chkInstallationChatFlag;
		public System.Windows.Forms.CheckBox chkInstallationUseLocalNotes;
		private System.Windows.Forms.CheckBox _chkLoginFlag_8;
		private System.Windows.Forms.CheckBox _chkLoginFlag_4;
		public System.Windows.Forms.TextBox txtInstallationPathToLocalDB;
		public System.Windows.Forms.CheckBox chkInstallationActive;
		public System.Windows.Forms.CheckBox chkActiveXFlag;
		public System.Windows.Forms.CheckBox chkAutoCheckTS;
		public System.Windows.Forms.CheckBox chkTerminalService;
		public System.Windows.Forms.ComboBox cboSubBType;
		public System.Windows.Forms.TextBox txtWebPageTimeOut;
		public System.Windows.Forms.TextBox txt_Platform_Name;
		private System.Windows.Forms.Label _lblSubLabel_11;
		private System.Windows.Forms.Label _lblSubLabel_47;
		public System.Windows.Forms.GroupBox frm_old_Invisible;
		public System.Windows.Forms.GroupBox fra_Bottom;
		private System.Windows.Forms.TabPage _SSTab_Subscription_TabPage0;
		public System.Windows.Forms.TextBox txt_SubJournalDescription;
		public System.Windows.Forms.TextBox txt_SubJournalSubject;
		public System.Windows.Forms.Button cmdSubNoteNew;
		public System.Windows.Forms.Button cmdSubNoteSave;
		public System.Windows.Forms.GroupBox frmSubscriptionNotesControl;
		public System.Windows.Forms.TextBox txt_SubJournalId;
		public UpgradeHelpers.DataGridViewFlex grd_SubJournalNotes;
		private System.Windows.Forms.Label _lblSubLabel_53;
		private System.Windows.Forms.Label _lblSubLabel_52;
		private System.Windows.Forms.Label _lblSubLabel_37;
		private System.Windows.Forms.Label _lblSubLabel_36;
		private System.Windows.Forms.Label _lblSubLabel_35;
		public System.Windows.Forms.GroupBox frmSubscriptionNotes;
		private System.Windows.Forms.TabPage _SSTab_Subscription_TabPage1;
		public System.Windows.Forms.TextBox txtSubExpirationDate;
		public System.Windows.Forms.TextBox txtSubDragDocument;
		public System.Windows.Forms.TextBox txtSubDocumentDate;
		public System.Windows.Forms.ComboBox cmbSubDocumentType;
		public System.Windows.Forms.TextBox txtSubDocumentId;
		public System.Windows.Forms.Button cmdSubDocumentMove;
		public System.Windows.Forms.Button cmdSubDocumentDelete;
		public System.Windows.Forms.Button cmdSubDocumentView;
		public System.Windows.Forms.Button cmdSubDocumentSave;
		public System.Windows.Forms.Button cmdSubDocumentNew;
		public System.Windows.Forms.GroupBox frmSubDocumentControl;
		public System.Windows.Forms.TextBox txtSubDocumentSubject;
		public System.Windows.Forms.TextBox txtSubDocumentDescription;
		public UpgradeHelpers.DataGridViewFlex grd_SubDocument;
		public System.Windows.Forms.MonthCalendar calSubDocumentDate;
		private System.Windows.Forms.WebBrowser _wbSubBrowser1_0;
		public System.Windows.Forms.MonthCalendar calSubExpirationDate;
		private System.Windows.Forms.Label _lblSubLabel_49;
		private System.Windows.Forms.Label _lblSubLabel_48;
		private System.Windows.Forms.Label _lblSubLabel_41;
		private System.Windows.Forms.Label _lblSubLabel_40;
		private System.Windows.Forms.Label _lblSubLabel_39;
		private System.Windows.Forms.Label _lblSubLabel_38;
		public System.Windows.Forms.Label lblSubDocumentId;
		public System.Windows.Forms.GroupBox frmSubscriptionContracts;
		private System.Windows.Forms.TabPage _SSTab_Subscription_TabPage2;
		public System.Windows.Forms.ListBox lstb_SubExecutionFormsDisplay;
		private System.Windows.Forms.WebBrowser _wbSubBrowser1_3;
		public System.Windows.Forms.GroupBox frm_SubExecutionFormsDisplay;
		public UpgradeHelpers.DataGridViewFlex grd_SubExecutionForms;
		public System.Windows.Forms.GroupBox frm_SubExecutionFormsGrid;
		private System.Windows.Forms.TextBox _txtSubExc_Type_1;
		private System.Windows.Forms.TextBox _txtSubExc_MonthlyAmt_2;
		private System.Windows.Forms.TextBox _txtSubExc_MonthlyAmt_1;
		public System.Windows.Forms.TextBox txtSubExc_Notes;
		public System.Windows.Forms.TextBox txtSubExc_Status;
		private System.Windows.Forms.TextBox _txtSubExc_MonthlyAmt_0;
		private System.Windows.Forms.TextBox _txtSubExc_Type_0;
		public System.Windows.Forms.TextBox txtSubExc_Service;
		public System.Windows.Forms.TextBox txtSubExc_ContractNbr;
		public System.Windows.Forms.TextBox txtSubExc_ADisableDate;
		public System.Windows.Forms.TextBox txtSubExc_SrvChgDate;
		public System.Windows.Forms.TextBox txtSubExc_CLetterDate;
		public System.Windows.Forms.TextBox txtSubExc_ContractDate;
		public System.Windows.Forms.TextBox txtSubExc_ExcDate;
		public System.Windows.Forms.TextBox txtSubExc_SubId;
		private System.Windows.Forms.Label _lblSubExc_Type_2;
		private System.Windows.Forms.Label _lblSubExc_MonthlyAmt_6;
		private System.Windows.Forms.Label _lblSubExc_MonthlyAmt_5;
		private System.Windows.Forms.Label _lblSubExc_MonthlyAmt_4;
		private System.Windows.Forms.Label _lblSubExc_MonthlyAmt_3;
		private System.Windows.Forms.Label _lblSubExc_Type_1;
		private System.Windows.Forms.Label _lblSubExc_MonthlyAmt_2;
		private System.Windows.Forms.Label _lblSubExc_MonthlyAmt_1;
		private System.Windows.Forms.Label _lblSubLabel_43;
		private System.Windows.Forms.Label _lblSubLabel_42;
		private System.Windows.Forms.Label _lblSubExc_MonthlyAmt_0;
		private System.Windows.Forms.Label _lblSubExc_Type_0;
		public System.Windows.Forms.Label lblSubExc_Service;
		public System.Windows.Forms.Label lblSubExc_ContractNbr;
		public System.Windows.Forms.GroupBox frm_SubExecutionFormsData;
		private System.Windows.Forms.TabPage _SSTab_Subscription_TabPage3;
		public System.Windows.Forms.TextBox txtSubSISubId;
		public System.Windows.Forms.TextBox txtSubSIApprovedBy;
		public System.Windows.Forms.CheckBox chkSubSIChangeAutoDisable;
		public System.Windows.Forms.CheckBox chkSubSIAccoutingIssues;
		public System.Windows.Forms.CheckBox chkSubSICancellation;
		public System.Windows.Forms.CheckBox chkSubSIStopUpdates;
		public System.Windows.Forms.CheckBox chkSubSIStopEvolution;
		public System.Windows.Forms.GroupBox frmSubSIDocCheckBoxes;
		public System.Windows.Forms.TextBox txtSubSIAutoDisableDate;
		public System.Windows.Forms.TextBox txtSubSIDocInterruptDate;
		public System.Windows.Forms.TextBox txtSubSIDocRequestedDate;
		public System.Windows.Forms.Label lblSubSIAutoDisableDate;
		public System.Windows.Forms.Label lblSubSIDocInterruptDate;
		public System.Windows.Forms.Label lblSubSIDocRequestedDate;
		public System.Windows.Forms.GroupBox frmSubSIDocDates;
		public System.Windows.Forms.Button cmdSubSIDocView;
		public System.Windows.Forms.GroupBox frmSubSIDocView;
		public System.Windows.Forms.TextBox txtSubSIDocId;
		public UpgradeHelpers.DataGridViewFlex grd_SubSIDocument;
		private System.Windows.Forms.WebBrowser _wbSubBrowser1_1;
		public System.Windows.Forms.Label lblSubSIViewOnly;
		public System.Windows.Forms.Label lblSubSISubId;
		public System.Windows.Forms.Label lblSubSIApprovedBy;
		public System.Windows.Forms.Label lblSubSIDocId;
		public System.Windows.Forms.GroupBox frmSubSIDocControl;
		private System.Windows.Forms.TabPage _SSTab_Subscription_TabPage4;
		public System.Windows.Forms.ComboBox cboWebReports;
		private System.Windows.Forms.WebBrowser _wbSubBrowser1_2;
		public System.Windows.Forms.Label lblWebReportsURL;
		public System.Windows.Forms.Label lblWebReportProcessing;
		private System.Windows.Forms.TabPage _SSTab_Subscription_TabPage5;
		public System.Windows.Forms.TextBox txtTotalRecordsInCloudNotes;
		public System.Windows.Forms.TextBox txtImportCloudNotesFromDate;
		public System.Windows.Forms.ProgressBar pbImportCNotesToCRMNotes;
		private System.Windows.Forms.Button _cmdSubNotesButton_10;
		public System.Windows.Forms.TextBox txtTotalImportedFromCloudNotesToSSNotes;
		private System.Windows.Forms.Button _cmdSubNotesButton_7;
		private System.Windows.Forms.Label _lblSubLabel_46;
		private System.Windows.Forms.Label _lblSubLabel_45;
		private System.Windows.Forms.Label _lblSubLabel_44;
		public System.Windows.Forms.GroupBox frmImportCloudNotesToCRMSSN;
		private System.Windows.Forms.Button _cmdSubNotesButton_6;
		public System.Windows.Forms.TextBox txtTotalRecordsInSSNotes;
		public System.Windows.Forms.TextBox txtTotalImportedFromSSNToCloudNotes;
		private System.Windows.Forms.Button _cmdSubNotesButton_9;
		public System.Windows.Forms.RadioButton rbCopySSNToCNOverwriteCloudNotes;
		public System.Windows.Forms.RadioButton rbCopySSNToCNAppendCloudNotes;
		public System.Windows.Forms.ProgressBar pbImportSSNotes;
		private System.Windows.Forms.Label _lblSubLabel_30;
		private System.Windows.Forms.Label _lblSubLabel_28;
		public System.Windows.Forms.GroupBox frmImportCRMSSNToCloudNotes;
		public System.Windows.Forms.TextBox txtPathToEvoLocalNotes;
		private System.Windows.Forms.Button _cmdSubNotesButton_5;
		private System.Windows.Forms.Button _cmdSubNotesButton_8;
		public System.Windows.Forms.RadioButton rbEvoLocalNotesOverrideCloudNotes;
		public System.Windows.Forms.RadioButton rbEvoLocalNotesAppendCloudNotes;
		public System.Windows.Forms.TextBox txtTotalImportedFromLocalNotesToEvoCloudNotes;
		public System.Windows.Forms.TextBox txtTotalRecordsInEvoLocalNotes;
		private System.Windows.Forms.Button _cmdSubNotesButton_4;
		public System.Windows.Forms.RadioButton rbEvoLocalNotesPurgeImportCloudNotes;
		public System.Windows.Forms.ProgressBar pbImportEvoLocalNotes;
		private System.Windows.Forms.Label _lblSubLabel_24;
		private System.Windows.Forms.Label _lblSubLabel_23;
		private System.Windows.Forms.Label _lblSubLabel_26;
		public System.Windows.Forms.GroupBox frmImportEvoLocalNotesToCloudNotes;
		private System.Windows.Forms.Button _cmdSubNotesButton_3;
		private System.Windows.Forms.Button _cmdSubNotesButton_2;
		public System.Windows.Forms.ComboBox cmbCloudNotesDatabaseName;
		public System.Windows.Forms.CheckBox chkCloudNotesFlag;
		public System.Windows.Forms.Label Label3;
		private System.Windows.Forms.Label _lblSubLabel_25;
		public System.Windows.Forms.GroupBox frmCloudNotes;
		private System.Windows.Forms.Button _cmdSubNotesButton_1;
		private System.Windows.Forms.Button _cmdSubNotesButton_0;
		public System.Windows.Forms.CheckBox chkServerSideNotes;
		public System.Windows.Forms.ComboBox cmbCRMDatabaseName;
		public System.Windows.Forms.TextBox txtCRMRegId;
		public System.Windows.Forms.Label lblCRMDatabaseName;
		public System.Windows.Forms.Label lblCRMRegId;
		public System.Windows.Forms.Label lblCRMMessage;
		public System.Windows.Forms.GroupBox frmServerSideNotes;
		private System.Windows.Forms.TabPage _SSTab_Subscription_TabPage6;
		public UpgradeHelpers.Gui.Controls.TabControlExtension SSTab_Subscription;
		public System.Windows.Forms.Button cmdIdentifyContact;
		public System.Windows.Forms.Button cmdClearContact;
		private System.Windows.Forms.TextBox _txt_find_sub_2;
		private System.Windows.Forms.TextBox _txt_find_sub_0;
		private System.Windows.Forms.TextBox _txt_find_sub_1;
		private System.Windows.Forms.Button _cmd_find_contact_1;
		private System.Windows.Forms.Button _cmd_find_contact_0;
		public System.Windows.Forms.ComboBox cboChooseContact;
		public System.Windows.Forms.Button cmdChooseContactSave;
		public System.Windows.Forms.Button cmdChooseContactCancel;
		private System.Windows.Forms.Label _lblSubLabel_71;
		private System.Windows.Forms.Label _lblSubLabel_59;
		private System.Windows.Forms.Label _lblSubLabel_32;
		public System.Windows.Forms.GroupBox fra_ChooseContact;
		public System.Windows.Forms.ListBox lst_Company;
		public System.Windows.Forms.ListBox lst_Contact;
		private System.Windows.Forms.Label _lblSubLabel_34;
		private System.Windows.Forms.Label _lblSubLabel_33;
		public System.Windows.Forms.GroupBox fra_Contact_Info;
		private System.Windows.Forms.Label _lblPleaseWaitStatus_0;
		private System.Windows.Forms.Label _lblPleaseWait_85;
		public System.Windows.Forms.Panel pnl_Please_Wait;
		public System.Windows.Forms.Label[] InstallLinkLabel = new System.Windows.Forms.Label[3];
		public System.Windows.Forms.CheckBox[] chkLoginFlag = new System.Windows.Forms.CheckBox[11];
		public System.Windows.Forms.CheckBox[] chkProductType = new System.Windows.Forms.CheckBox[14];
		public System.Windows.Forms.Button[] cmdSubNotesButton = new System.Windows.Forms.Button[11];
		public System.Windows.Forms.Button[] cmdSubscription = new System.Windows.Forms.Button[5];
		public System.Windows.Forms.Button[] cmd_auth_btn = new System.Windows.Forms.Button[2];
		public System.Windows.Forms.Button[] cmd_find_contact = new System.Windows.Forms.Button[2];
		public System.Windows.Forms.Label[] lblPleaseWait = new System.Windows.Forms.Label[86];
		public System.Windows.Forms.Label[] lblPleaseWaitStatus = new System.Windows.Forms.Label[1];
		public System.Windows.Forms.Label[] lblSubExc_MonthlyAmt = new System.Windows.Forms.Label[7];
		public System.Windows.Forms.Label[] lblSubExc_Type = new System.Windows.Forms.Label[3];
		public System.Windows.Forms.Label[] lblSubLabel = new System.Windows.Forms.Label[74];
		public System.Windows.Forms.TextBox[] txtSubExc_MonthlyAmt = new System.Windows.Forms.TextBox[3];
		public System.Windows.Forms.TextBox[] txtSubExc_Type = new System.Windows.Forms.TextBox[2];
		public System.Windows.Forms.TextBox[] txt_SubNbrOfInstalls = new System.Windows.Forms.TextBox[3];
		public System.Windows.Forms.TextBox[] txt_find_sub = new System.Windows.Forms.TextBox[3];
		public System.Windows.Forms.WebBrowser[] wbSubBrowser1 = new System.Windows.Forms.WebBrowser[5];
		public System.Windows.Forms.ContextMenuStrip Ctx_mnuRightClick;
		public UpgradeHelpers.Gui.Controls.OptionButtonHelper optionButtonHelper1;
		public UpgradeHelpers.Gui.Controls.ListBoxHelper listBoxHelper1;
		public UpgradeHelpers.Gui.Controls.CommandButtonHelper commandButtonHelper1;
		private int SSTab_SubscriptionPreviousTab;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Subscription));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			MainMenu1 = new System.Windows.Forms.MenuStrip();
			mnuRightClick = new System.Windows.Forms.ToolStripMenuItem();
			mnuMPMManagement = new System.Windows.Forms.ToolStripMenuItem();
			SSTab_Subscription = new UpgradeHelpers.Gui.Controls.TabControlExtension();
			_SSTab_Subscription_TabPage0 = new System.Windows.Forms.TabPage();
			frm_Subscription_Top = new System.Windows.Forms.GroupBox();
			frmSubscriptionAction = new System.Windows.Forms.GroupBox();
			_cmdSubscription_4 = new System.Windows.Forms.Button();
			_cmdSubscription_3 = new System.Windows.Forms.Button();
			_cmdSubscription_2 = new System.Windows.Forms.Button();
			_cmdSubscription_1 = new System.Windows.Forms.Button();
			_cmdSubscription_0 = new System.Windows.Forms.Button();
			_lblSubLabel_27 = new System.Windows.Forms.Label();
			frm_Sub_Id = new System.Windows.Forms.GroupBox();
			chkIncludeInactive = new System.Windows.Forms.CheckBox();
			grd_Subscriptions = new UpgradeHelpers.DataGridViewFlex(components);
			_wbSubBrowser1_4 = new System.Windows.Forms.WebBrowser();
			_lblSubLabel_5 = new System.Windows.Forms.Label();
			frm_Sub_Service = new System.Windows.Forms.GroupBox();
			frmSubOptions = new System.Windows.Forms.GroupBox();
			_chkProductType_13 = new System.Windows.Forms.CheckBox();
			cbo_Service = new System.Windows.Forms.ComboBox();
			cmbTierLevel_comm = new System.Windows.Forms.ComboBox();
			chk_sub_api_flag = new System.Windows.Forms.CheckBox();
			txt_sub_billed_amount = new System.Windows.Forms.TextBox();
			_txt_SubNbrOfInstalls_2 = new System.Windows.Forms.TextBox();
			_chkProductType_12 = new System.Windows.Forms.CheckBox();
			_chkProductType_11 = new System.Windows.Forms.CheckBox();
			_txt_SubNbrOfInstalls_1 = new System.Windows.Forms.TextBox();
			_chkProductType_10 = new System.Windows.Forms.CheckBox();
			_chkProductType_9 = new System.Windows.Forms.CheckBox();
			_chkProductType_8 = new System.Windows.Forms.CheckBox();
			_chkProductType_7 = new System.Windows.Forms.CheckBox();
			_chkProductType_6 = new System.Windows.Forms.CheckBox();
			_chkProductType_5 = new System.Windows.Forms.CheckBox();
			_chkProductType_4 = new System.Windows.Forms.CheckBox();
			_chkProductType_3 = new System.Windows.Forms.CheckBox();
			_chkProductType_1 = new System.Windows.Forms.CheckBox();
			txt_sub_start_date = new System.Windows.Forms.TextBox();
			txt_sub_end_date = new System.Windows.Forms.TextBox();
			txt_SubContractAmount = new System.Windows.Forms.TextBox();
			_txt_SubNbrOfInstalls_0 = new System.Windows.Forms.TextBox();
			cmbTierLevel = new System.Windows.Forms.ComboBox();
			_chkProductType_0 = new System.Windows.Forms.CheckBox();
			txt_sub_id = new System.Windows.Forms.TextBox();
			cmbFrequency = new System.Windows.Forms.ComboBox();
			txtNbrDaysExpire = new System.Windows.Forms.TextBox();
			txtSubMaxExport = new System.Windows.Forms.TextBox();
			lbl_Service = new System.Windows.Forms.Label();
			_lblSubLabel_15 = new System.Windows.Forms.Label();
			_lblSubLabel_56 = new System.Windows.Forms.Label();
			_lblSubLabel_54 = new System.Windows.Forms.Label();
			_lblSubLabel_51 = new System.Windows.Forms.Label();
			lblSubUpdateNbrInstalls = new System.Windows.Forms.Label();
			_lblSubLabel_3 = new System.Windows.Forms.Label();
			lblCalendars = new System.Windows.Forms.Label();
			lbl_SubNbrOfInstalls = new System.Windows.Forms.Label();
			_lblSubLabel_4 = new System.Windows.Forms.Label();
			_lblSubLabel_0 = new System.Windows.Forms.Label();
			_lblSubLabel_29 = new System.Windows.Forms.Label();
			lblNbrDaysExpire = new System.Windows.Forms.Label();
			_lblSubLabel_2 = new System.Windows.Forms.Label();
			frmCallbackStatus = new System.Windows.Forms.GroupBox();
			txtCallbackComments = new System.Windows.Forms.TextBox();
			cboCallBackStatus = new System.Windows.Forms.ComboBox();
			txtCallBackDate = new System.Windows.Forms.TextBox();
			calCallBackDate = new System.Windows.Forms.MonthCalendar();
			_lblSubLabel_70 = new System.Windows.Forms.Label();
			lblServerSideNotes = new System.Windows.Forms.Label();
			_lblSubLabel_7 = new System.Windows.Forms.Label();
			_lblSubLabel_6 = new System.Windows.Forms.Label();
			frmStartEndDate = new System.Windows.Forms.GroupBox();
			cal_sub_start_date = new System.Windows.Forms.MonthCalendar();
			cal_sub_end_date = new System.Windows.Forms.MonthCalendar();
			lblEndDate = new System.Windows.Forms.Label();
			lblStartDate = new System.Windows.Forms.Label();
			fra_Bottom = new System.Windows.Forms.GroupBox();
			frm_Sub_Command = new System.Windows.Forms.GroupBox();
			cmdUpload = new System.Windows.Forms.Button();
			cmdUpdateCRMSite = new System.Windows.Forms.Button();
			cmdNewLogin = new System.Windows.Forms.Button();
			cmd_New_Installation = new System.Windows.Forms.Button();
			cmd_Close = new System.Windows.Forms.Button();
			fra_Add_Installation = new System.Windows.Forms.GroupBox();
			chkInstallAdministrator = new System.Windows.Forms.CheckBox();
			frmSMSTextMsg = new System.Windows.Forms.GroupBox();
			txtCellNumber = new System.Windows.Forms.TextBox();
			cboCellCarrier = new System.Windows.Forms.ComboBox();
			txtTextMsgModels = new System.Windows.Forms.TextBox();
			txtMobileActiveDate = new System.Windows.Forms.TextBox();
			txtSMSTextActiveFlag = new System.Windows.Forms.TextBox();
			txtSMSEvents = new System.Windows.Forms.TextBox();
			chkInstallEvoMobile = new System.Windows.Forms.CheckBox();
			cmdInstallValidateSMSTxtMsg = new System.Windows.Forms.Button();
			lblSendTxtMsg = new System.Windows.Forms.Label();
			_lblSubLabel_16 = new System.Windows.Forms.Label();
			_lblSubLabel_17 = new System.Windows.Forms.Label();
			_lblSubLabel_18 = new System.Windows.Forms.Label();
			_lblSubLabel_19 = new System.Windows.Forms.Label();
			_lblSubLabel_20 = new System.Windows.Forms.Label();
			_lblSubLabel_21 = new System.Windows.Forms.Label();
			lblSendTextMsgEvoMobileLink = new System.Windows.Forms.Label();
			lblSendTextMsgOK = new System.Windows.Forms.Label();
			grd_Installations = new UpgradeHelpers.DataGridViewFlex(components);
			cmdSubInsValidate = new System.Windows.Forms.Button();
			cmbSubInsContact = new System.Windows.Forms.ComboBox();
			txtSubDefaultAModId = new System.Windows.Forms.TextBox();
			cmdDeleteInstallation = new System.Windows.Forms.Button();
			cmdUpdateInstallation = new System.Windows.Forms.Button();
			cmd_InstallCancel = new System.Windows.Forms.Button();
			txt_SubInsContractAmount = new System.Windows.Forms.TextBox();
			cmdClearInstallDate = new System.Windows.Forms.Button();
			frmInstallFlags = new System.Windows.Forms.GroupBox();
			txt_Platform_OS = new System.Windows.Forms.TextBox();
			txtReplyName = new System.Windows.Forms.TextBox();
			txtReplyEMail = new System.Windows.Forms.TextBox();
			txtSubInsNbrRecPerPage = new System.Windows.Forms.TextBox();
			txtSubInsDefaultAnalysisMths = new System.Windows.Forms.TextBox();
			cmbSubInsBGImageId = new System.Windows.Forms.ComboBox();
			chkDefaultHTMLEMail = new System.Windows.Forms.CheckBox();
			chkInstallationDisplayNoteTag = new System.Windows.Forms.CheckBox();
			_lblSubLabel_69 = new System.Windows.Forms.Label();
			_lblSubLabel_66 = new System.Windows.Forms.Label();
			lblSubDefaultAModId = new System.Windows.Forms.Label();
			_lblSubLabel_10 = new System.Windows.Forms.Label();
			_lblSubLabel_12 = new System.Windows.Forms.Label();
			_lblSubLabel_13 = new System.Windows.Forms.Label();
			_lblSubLabel_1 = new System.Windows.Forms.Label();
			_lblSubLabel_55 = new System.Windows.Forms.Label();
			_lblSubLabel_22 = new System.Windows.Forms.Label();
			frmInstallASPLogs = new System.Windows.Forms.GroupBox();
			lblSubInsViewEvoMobileLogs = new System.Windows.Forms.Label();
			lblSubInsViewSMSTextMsgsReceived = new System.Windows.Forms.Label();
			lblSubInsViewSMSTextMsgsSent = new System.Windows.Forms.Label();
			lblSubInsViewWebReport = new System.Windows.Forms.Label();
			_lblSubLabel_8 = new System.Windows.Forms.Label();
			_lblSubLabel_31 = new System.Windows.Forms.Label();
			_InstallLinkLabel_2 = new System.Windows.Forms.Label();
			_InstallLinkLabel_1 = new System.Windows.Forms.Label();
			_InstallLinkLabel_0 = new System.Windows.Forms.Label();
			_lblSubLabel_14 = new System.Windows.Forms.Label();
			grd_Logins = new UpgradeHelpers.DataGridViewFlex(components);
			fraLogin = new System.Windows.Forms.GroupBox();
			cbo_build = new System.Windows.Forms.ComboBox();
			frm_authentication = new System.Windows.Forms.GroupBox();
			txt_auth_phone = new System.Windows.Forms.TextBox();
			txt_auth_last_action = new System.Windows.Forms.TextBox();
			_cmd_auth_btn_1 = new System.Windows.Forms.Button();
			_cmd_auth_btn_0 = new System.Windows.Forms.Button();
			cbo_auth_type = new System.Windows.Forms.ComboBox();
			cbo_auth_cycle = new System.Windows.Forms.ComboBox();
			chk_auth_status = new System.Windows.Forms.CheckBox();
			_lblSubLabel_9 = new System.Windows.Forms.Label();
			_lblSubLabel_68 = new System.Windows.Forms.Label();
			_lblSubLabel_67 = new System.Windows.Forms.Label();
			_lblSubLabel_65 = new System.Windows.Forms.Label();
			_lblSubLabel_64 = new System.Windows.Forms.Label();
			_lblSubLabel_63 = new System.Windows.Forms.Label();
			_lblSubLabel_62 = new System.Windows.Forms.Label();
			_lblSubLabel_61 = new System.Windows.Forms.Label();
			_lblSubLabel_60 = new System.Windows.Forms.Label();
			_lblSubLabel_58 = new System.Windows.Forms.Label();
			frmLoginFlags = new System.Windows.Forms.GroupBox();
			_chkLoginFlag_2 = new System.Windows.Forms.CheckBox();
			_chkLoginFlag_5 = new System.Windows.Forms.CheckBox();
			_chkLoginFlag_7 = new System.Windows.Forms.CheckBox();
			_chkLoginFlag_10 = new System.Windows.Forms.CheckBox();
			_chkLoginFlag_9 = new System.Windows.Forms.CheckBox();
			_chkLoginFlag_6 = new System.Windows.Forms.CheckBox();
			_chkLoginFlag_1 = new System.Windows.Forms.CheckBox();
			_chkLoginFlag_0 = new System.Windows.Forms.CheckBox();
			lblLoginFlagsHide = new System.Windows.Forms.Label();
			txt_sublogin_billed_amount = new System.Windows.Forms.TextBox();
			cmdMoveLoginFrame = new System.Windows.Forms.Button();
			cmd_SaveUser = new System.Windows.Forms.Button();
			cmdCancelLoginFrame = new System.Windows.Forms.Button();
			txt_sub_password = new System.Windows.Forms.TextBox();
			txt_SubLoginContractAmount = new System.Windows.Forms.TextBox();
			txt_SubLoginNbrOfInstalls = new System.Windows.Forms.TextBox();
			cmd_DeleteLogin = new System.Windows.Forms.Button();
			cmdEMailSubNotice = new System.Windows.Forms.Button();
			cmdResetDemoLogin = new System.Windows.Forms.Button();
			cmdGeneratePassword = new System.Windows.Forms.Button();
			txtLoginName = new System.Windows.Forms.TextBox();
			_lblSubLabel_73 = new System.Windows.Forms.Label();
			_lblSubLabel_57 = new System.Windows.Forms.Label();
			Label1 = new System.Windows.Forms.Label();
			lblSubAddInstall = new System.Windows.Forms.Label();
			lblLoginShowFlags = new System.Windows.Forms.Label();
			lbl_Password = new System.Windows.Forms.Label();
			lbl_SubLoginContractAmount = new System.Windows.Forms.Label();
			lbl_SubLoginNbrOfInstalls = new System.Windows.Forms.Label();
			lblSubInsContact = new System.Windows.Forms.Label();
			frm_old_Invisible = new System.Windows.Forms.GroupBox();
			_chkLoginFlag_3 = new System.Windows.Forms.CheckBox();
			chkInstallationChatFlag = new System.Windows.Forms.CheckBox();
			chkInstallationUseLocalNotes = new System.Windows.Forms.CheckBox();
			_chkLoginFlag_8 = new System.Windows.Forms.CheckBox();
			_chkLoginFlag_4 = new System.Windows.Forms.CheckBox();
			txtInstallationPathToLocalDB = new System.Windows.Forms.TextBox();
			chkInstallationActive = new System.Windows.Forms.CheckBox();
			chkActiveXFlag = new System.Windows.Forms.CheckBox();
			chkAutoCheckTS = new System.Windows.Forms.CheckBox();
			chkTerminalService = new System.Windows.Forms.CheckBox();
			cboSubBType = new System.Windows.Forms.ComboBox();
			txtWebPageTimeOut = new System.Windows.Forms.TextBox();
			txt_Platform_Name = new System.Windows.Forms.TextBox();
			_lblSubLabel_11 = new System.Windows.Forms.Label();
			_lblSubLabel_47 = new System.Windows.Forms.Label();
			_SSTab_Subscription_TabPage1 = new System.Windows.Forms.TabPage();
			frmSubscriptionNotes = new System.Windows.Forms.GroupBox();
			txt_SubJournalDescription = new System.Windows.Forms.TextBox();
			txt_SubJournalSubject = new System.Windows.Forms.TextBox();
			frmSubscriptionNotesControl = new System.Windows.Forms.GroupBox();
			cmdSubNoteNew = new System.Windows.Forms.Button();
			cmdSubNoteSave = new System.Windows.Forms.Button();
			txt_SubJournalId = new System.Windows.Forms.TextBox();
			grd_SubJournalNotes = new UpgradeHelpers.DataGridViewFlex(components);
			_lblSubLabel_53 = new System.Windows.Forms.Label();
			_lblSubLabel_52 = new System.Windows.Forms.Label();
			_lblSubLabel_37 = new System.Windows.Forms.Label();
			_lblSubLabel_36 = new System.Windows.Forms.Label();
			_lblSubLabel_35 = new System.Windows.Forms.Label();
			_SSTab_Subscription_TabPage2 = new System.Windows.Forms.TabPage();
			frmSubscriptionContracts = new System.Windows.Forms.GroupBox();
			txtSubExpirationDate = new System.Windows.Forms.TextBox();
			txtSubDragDocument = new System.Windows.Forms.TextBox();
			txtSubDocumentDate = new System.Windows.Forms.TextBox();
			cmbSubDocumentType = new System.Windows.Forms.ComboBox();
			txtSubDocumentId = new System.Windows.Forms.TextBox();
			frmSubDocumentControl = new System.Windows.Forms.GroupBox();
			cmdSubDocumentMove = new System.Windows.Forms.Button();
			cmdSubDocumentDelete = new System.Windows.Forms.Button();
			cmdSubDocumentView = new System.Windows.Forms.Button();
			cmdSubDocumentSave = new System.Windows.Forms.Button();
			cmdSubDocumentNew = new System.Windows.Forms.Button();
			txtSubDocumentSubject = new System.Windows.Forms.TextBox();
			txtSubDocumentDescription = new System.Windows.Forms.TextBox();
			grd_SubDocument = new UpgradeHelpers.DataGridViewFlex(components);
			calSubDocumentDate = new System.Windows.Forms.MonthCalendar();
			_wbSubBrowser1_0 = new System.Windows.Forms.WebBrowser();
			calSubExpirationDate = new System.Windows.Forms.MonthCalendar();
			_lblSubLabel_49 = new System.Windows.Forms.Label();
			_lblSubLabel_48 = new System.Windows.Forms.Label();
			_lblSubLabel_41 = new System.Windows.Forms.Label();
			_lblSubLabel_40 = new System.Windows.Forms.Label();
			_lblSubLabel_39 = new System.Windows.Forms.Label();
			_lblSubLabel_38 = new System.Windows.Forms.Label();
			lblSubDocumentId = new System.Windows.Forms.Label();
			_SSTab_Subscription_TabPage3 = new System.Windows.Forms.TabPage();
			frm_SubExecutionFormsDisplay = new System.Windows.Forms.GroupBox();
			lstb_SubExecutionFormsDisplay = new System.Windows.Forms.ListBox();
			_wbSubBrowser1_3 = new System.Windows.Forms.WebBrowser();
			frm_SubExecutionFormsGrid = new System.Windows.Forms.GroupBox();
			grd_SubExecutionForms = new UpgradeHelpers.DataGridViewFlex(components);
			frm_SubExecutionFormsData = new System.Windows.Forms.GroupBox();
			_txtSubExc_Type_1 = new System.Windows.Forms.TextBox();
			_txtSubExc_MonthlyAmt_2 = new System.Windows.Forms.TextBox();
			_txtSubExc_MonthlyAmt_1 = new System.Windows.Forms.TextBox();
			txtSubExc_Notes = new System.Windows.Forms.TextBox();
			txtSubExc_Status = new System.Windows.Forms.TextBox();
			_txtSubExc_MonthlyAmt_0 = new System.Windows.Forms.TextBox();
			_txtSubExc_Type_0 = new System.Windows.Forms.TextBox();
			txtSubExc_Service = new System.Windows.Forms.TextBox();
			txtSubExc_ContractNbr = new System.Windows.Forms.TextBox();
			txtSubExc_ADisableDate = new System.Windows.Forms.TextBox();
			txtSubExc_SrvChgDate = new System.Windows.Forms.TextBox();
			txtSubExc_CLetterDate = new System.Windows.Forms.TextBox();
			txtSubExc_ContractDate = new System.Windows.Forms.TextBox();
			txtSubExc_ExcDate = new System.Windows.Forms.TextBox();
			txtSubExc_SubId = new System.Windows.Forms.TextBox();
			_lblSubExc_Type_2 = new System.Windows.Forms.Label();
			_lblSubExc_MonthlyAmt_6 = new System.Windows.Forms.Label();
			_lblSubExc_MonthlyAmt_5 = new System.Windows.Forms.Label();
			_lblSubExc_MonthlyAmt_4 = new System.Windows.Forms.Label();
			_lblSubExc_MonthlyAmt_3 = new System.Windows.Forms.Label();
			_lblSubExc_Type_1 = new System.Windows.Forms.Label();
			_lblSubExc_MonthlyAmt_2 = new System.Windows.Forms.Label();
			_lblSubExc_MonthlyAmt_1 = new System.Windows.Forms.Label();
			_lblSubLabel_43 = new System.Windows.Forms.Label();
			_lblSubLabel_42 = new System.Windows.Forms.Label();
			_lblSubExc_MonthlyAmt_0 = new System.Windows.Forms.Label();
			_lblSubExc_Type_0 = new System.Windows.Forms.Label();
			lblSubExc_Service = new System.Windows.Forms.Label();
			lblSubExc_ContractNbr = new System.Windows.Forms.Label();
			_SSTab_Subscription_TabPage4 = new System.Windows.Forms.TabPage();
			frmSubSIDocControl = new System.Windows.Forms.GroupBox();
			txtSubSISubId = new System.Windows.Forms.TextBox();
			txtSubSIApprovedBy = new System.Windows.Forms.TextBox();
			frmSubSIDocCheckBoxes = new System.Windows.Forms.GroupBox();
			chkSubSIChangeAutoDisable = new System.Windows.Forms.CheckBox();
			chkSubSIAccoutingIssues = new System.Windows.Forms.CheckBox();
			chkSubSICancellation = new System.Windows.Forms.CheckBox();
			chkSubSIStopUpdates = new System.Windows.Forms.CheckBox();
			chkSubSIStopEvolution = new System.Windows.Forms.CheckBox();
			frmSubSIDocDates = new System.Windows.Forms.GroupBox();
			txtSubSIAutoDisableDate = new System.Windows.Forms.TextBox();
			txtSubSIDocInterruptDate = new System.Windows.Forms.TextBox();
			txtSubSIDocRequestedDate = new System.Windows.Forms.TextBox();
			lblSubSIAutoDisableDate = new System.Windows.Forms.Label();
			lblSubSIDocInterruptDate = new System.Windows.Forms.Label();
			lblSubSIDocRequestedDate = new System.Windows.Forms.Label();
			frmSubSIDocView = new System.Windows.Forms.GroupBox();
			cmdSubSIDocView = new System.Windows.Forms.Button();
			txtSubSIDocId = new System.Windows.Forms.TextBox();
			grd_SubSIDocument = new UpgradeHelpers.DataGridViewFlex(components);
			_wbSubBrowser1_1 = new System.Windows.Forms.WebBrowser();
			lblSubSIViewOnly = new System.Windows.Forms.Label();
			lblSubSISubId = new System.Windows.Forms.Label();
			lblSubSIApprovedBy = new System.Windows.Forms.Label();
			lblSubSIDocId = new System.Windows.Forms.Label();
			_SSTab_Subscription_TabPage5 = new System.Windows.Forms.TabPage();
			cboWebReports = new System.Windows.Forms.ComboBox();
			_wbSubBrowser1_2 = new System.Windows.Forms.WebBrowser();
			lblWebReportsURL = new System.Windows.Forms.Label();
			lblWebReportProcessing = new System.Windows.Forms.Label();
			_SSTab_Subscription_TabPage6 = new System.Windows.Forms.TabPage();
			frmImportCloudNotesToCRMSSN = new System.Windows.Forms.GroupBox();
			txtTotalRecordsInCloudNotes = new System.Windows.Forms.TextBox();
			txtImportCloudNotesFromDate = new System.Windows.Forms.TextBox();
			pbImportCNotesToCRMNotes = new System.Windows.Forms.ProgressBar();
			_cmdSubNotesButton_10 = new System.Windows.Forms.Button();
			txtTotalImportedFromCloudNotesToSSNotes = new System.Windows.Forms.TextBox();
			_cmdSubNotesButton_7 = new System.Windows.Forms.Button();
			_lblSubLabel_46 = new System.Windows.Forms.Label();
			_lblSubLabel_45 = new System.Windows.Forms.Label();
			_lblSubLabel_44 = new System.Windows.Forms.Label();
			frmImportCRMSSNToCloudNotes = new System.Windows.Forms.GroupBox();
			_cmdSubNotesButton_6 = new System.Windows.Forms.Button();
			txtTotalRecordsInSSNotes = new System.Windows.Forms.TextBox();
			txtTotalImportedFromSSNToCloudNotes = new System.Windows.Forms.TextBox();
			_cmdSubNotesButton_9 = new System.Windows.Forms.Button();
			rbCopySSNToCNOverwriteCloudNotes = new System.Windows.Forms.RadioButton();
			rbCopySSNToCNAppendCloudNotes = new System.Windows.Forms.RadioButton();
			pbImportSSNotes = new System.Windows.Forms.ProgressBar();
			_lblSubLabel_30 = new System.Windows.Forms.Label();
			_lblSubLabel_28 = new System.Windows.Forms.Label();
			frmImportEvoLocalNotesToCloudNotes = new System.Windows.Forms.GroupBox();
			txtPathToEvoLocalNotes = new System.Windows.Forms.TextBox();
			_cmdSubNotesButton_5 = new System.Windows.Forms.Button();
			_cmdSubNotesButton_8 = new System.Windows.Forms.Button();
			rbEvoLocalNotesOverrideCloudNotes = new System.Windows.Forms.RadioButton();
			rbEvoLocalNotesAppendCloudNotes = new System.Windows.Forms.RadioButton();
			txtTotalImportedFromLocalNotesToEvoCloudNotes = new System.Windows.Forms.TextBox();
			txtTotalRecordsInEvoLocalNotes = new System.Windows.Forms.TextBox();
			_cmdSubNotesButton_4 = new System.Windows.Forms.Button();
			rbEvoLocalNotesPurgeImportCloudNotes = new System.Windows.Forms.RadioButton();
			pbImportEvoLocalNotes = new System.Windows.Forms.ProgressBar();
			_lblSubLabel_24 = new System.Windows.Forms.Label();
			_lblSubLabel_23 = new System.Windows.Forms.Label();
			_lblSubLabel_26 = new System.Windows.Forms.Label();
			frmCloudNotes = new System.Windows.Forms.GroupBox();
			_cmdSubNotesButton_3 = new System.Windows.Forms.Button();
			_cmdSubNotesButton_2 = new System.Windows.Forms.Button();
			cmbCloudNotesDatabaseName = new System.Windows.Forms.ComboBox();
			chkCloudNotesFlag = new System.Windows.Forms.CheckBox();
			Label3 = new System.Windows.Forms.Label();
			_lblSubLabel_25 = new System.Windows.Forms.Label();
			frmServerSideNotes = new System.Windows.Forms.GroupBox();
			_cmdSubNotesButton_1 = new System.Windows.Forms.Button();
			_cmdSubNotesButton_0 = new System.Windows.Forms.Button();
			chkServerSideNotes = new System.Windows.Forms.CheckBox();
			cmbCRMDatabaseName = new System.Windows.Forms.ComboBox();
			txtCRMRegId = new System.Windows.Forms.TextBox();
			lblCRMDatabaseName = new System.Windows.Forms.Label();
			lblCRMRegId = new System.Windows.Forms.Label();
			lblCRMMessage = new System.Windows.Forms.Label();
			fra_Contact_Info = new System.Windows.Forms.GroupBox();
			cmdIdentifyContact = new System.Windows.Forms.Button();
			cmdClearContact = new System.Windows.Forms.Button();
			fra_ChooseContact = new System.Windows.Forms.GroupBox();
			_txt_find_sub_2 = new System.Windows.Forms.TextBox();
			_txt_find_sub_0 = new System.Windows.Forms.TextBox();
			_txt_find_sub_1 = new System.Windows.Forms.TextBox();
			_cmd_find_contact_1 = new System.Windows.Forms.Button();
			_cmd_find_contact_0 = new System.Windows.Forms.Button();
			cboChooseContact = new System.Windows.Forms.ComboBox();
			cmdChooseContactSave = new System.Windows.Forms.Button();
			cmdChooseContactCancel = new System.Windows.Forms.Button();
			_lblSubLabel_71 = new System.Windows.Forms.Label();
			_lblSubLabel_59 = new System.Windows.Forms.Label();
			_lblSubLabel_32 = new System.Windows.Forms.Label();
			lst_Company = new System.Windows.Forms.ListBox();
			lst_Contact = new System.Windows.Forms.ListBox();
			_lblSubLabel_34 = new System.Windows.Forms.Label();
			_lblSubLabel_33 = new System.Windows.Forms.Label();
			pnl_Please_Wait = new System.Windows.Forms.Panel();
			_lblPleaseWaitStatus_0 = new System.Windows.Forms.Label();
			_lblPleaseWait_85 = new System.Windows.Forms.Label();
			SSTab_Subscription.SuspendLayout();
			_SSTab_Subscription_TabPage0.SuspendLayout();
			frm_Subscription_Top.SuspendLayout();
			frmSubscriptionAction.SuspendLayout();
			frm_Sub_Id.SuspendLayout();
			frm_Sub_Service.SuspendLayout();
			frmSubOptions.SuspendLayout();
			frmCallbackStatus.SuspendLayout();
			frmStartEndDate.SuspendLayout();
			fra_Bottom.SuspendLayout();
			frm_Sub_Command.SuspendLayout();
			fra_Add_Installation.SuspendLayout();
			frmSMSTextMsg.SuspendLayout();
			frmInstallFlags.SuspendLayout();
			frmInstallASPLogs.SuspendLayout();
			fraLogin.SuspendLayout();
			frm_authentication.SuspendLayout();
			frmLoginFlags.SuspendLayout();
			frm_old_Invisible.SuspendLayout();
			_SSTab_Subscription_TabPage1.SuspendLayout();
			frmSubscriptionNotes.SuspendLayout();
			frmSubscriptionNotesControl.SuspendLayout();
			_SSTab_Subscription_TabPage2.SuspendLayout();
			frmSubscriptionContracts.SuspendLayout();
			frmSubDocumentControl.SuspendLayout();
			_SSTab_Subscription_TabPage3.SuspendLayout();
			frm_SubExecutionFormsDisplay.SuspendLayout();
			frm_SubExecutionFormsGrid.SuspendLayout();
			frm_SubExecutionFormsData.SuspendLayout();
			_SSTab_Subscription_TabPage4.SuspendLayout();
			frmSubSIDocControl.SuspendLayout();
			frmSubSIDocCheckBoxes.SuspendLayout();
			frmSubSIDocDates.SuspendLayout();
			frmSubSIDocView.SuspendLayout();
			_SSTab_Subscription_TabPage5.SuspendLayout();
			_SSTab_Subscription_TabPage6.SuspendLayout();
			frmImportCloudNotesToCRMSSN.SuspendLayout();
			frmImportCRMSSNToCloudNotes.SuspendLayout();
			frmImportEvoLocalNotesToCloudNotes.SuspendLayout();
			frmCloudNotes.SuspendLayout();
			frmServerSideNotes.SuspendLayout();
			fra_Contact_Info.SuspendLayout();
			fra_ChooseContact.SuspendLayout();
			pnl_Please_Wait.SuspendLayout();
			SuspendLayout();
			//Ctx_mnuRightClick
			Ctx_mnuRightClick = new System.Windows.Forms.ContextMenuStrip(components);
			Ctx_mnuRightClick.Size = new System.Drawing.Size(153, 26);
			Ctx_mnuRightClick.Opening += new System.ComponentModel.CancelEventHandler(Ctx_mnuRightClick_Opening);
			Ctx_mnuRightClick.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(Ctx_mnuRightClick_Closed);
			optionButtonHelper1 = new UpgradeHelpers.Gui.Controls.OptionButtonHelper(components);
			listBoxHelper1 = new UpgradeHelpers.Gui.Controls.ListBoxHelper(components);
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
			((System.ComponentModel.ISupportInitialize) grd_Subscriptions).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_Installations).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_Logins).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_SubJournalNotes).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_SubDocument).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_SubExecutionForms).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_SubSIDocument).BeginInit();
			// 
			// MainMenu1
			// 
			MainMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[]{mnuRightClick});
			// 
			// mnuRightClick
			// 
			mnuRightClick.Available = false;
			mnuRightClick.Checked = false;
			mnuRightClick.Enabled = true;
			mnuRightClick.Name = "mnuRightClick";
			mnuRightClick.Text = "Right Click";
			mnuRightClick.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]{mnuMPMManagement});
			// 
			// mnuMPMManagement
			// 
			mnuMPMManagement.Available = true;
			mnuMPMManagement.Checked = false;
			mnuMPMManagement.Enabled = true;
			mnuMPMManagement.Name = "mnuMPMManagement";
			mnuMPMManagement.Text = "MPM Management";
			mnuMPMManagement.Click += new System.EventHandler(mnuMPMManagement_Click);
			// 
			// SSTab_Subscription
			// 
			SSTab_Subscription.Alignment = System.Windows.Forms.TabAlignment.Top;
			SSTab_Subscription.AllowDrop = true;
			SSTab_Subscription.BackColor = System.Drawing.Color.Red;
			SSTab_Subscription.Controls.Add(_SSTab_Subscription_TabPage0);
			SSTab_Subscription.Controls.Add(_SSTab_Subscription_TabPage1);
			SSTab_Subscription.Controls.Add(_SSTab_Subscription_TabPage2);
			SSTab_Subscription.Controls.Add(_SSTab_Subscription_TabPage3);
			SSTab_Subscription.Controls.Add(_SSTab_Subscription_TabPage4);
			SSTab_Subscription.Controls.Add(_SSTab_Subscription_TabPage5);
			SSTab_Subscription.Controls.Add(_SSTab_Subscription_TabPage6);
			SSTab_Subscription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			SSTab_Subscription.ItemSize = new System.Drawing.Size(133, 18);
			SSTab_Subscription.Location = new System.Drawing.Point(10, 144);
			SSTab_Subscription.Multiline = true;
			SSTab_Subscription.Name = "SSTab_Subscription";
			SSTab_Subscription.Size = new System.Drawing.Size(944, 661);
			SSTab_Subscription.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			SSTab_Subscription.TabIndex = 49;
			SSTab_Subscription.SelectedIndexChanged += new System.EventHandler(SSTab_Subscription_SelectedIndexChanged);
			// 
			// _SSTab_Subscription_TabPage0
			// 
			_SSTab_Subscription_TabPage0.Controls.Add(frm_Subscription_Top);
			_SSTab_Subscription_TabPage0.Controls.Add(fra_Bottom);
			_SSTab_Subscription_TabPage0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_SSTab_Subscription_TabPage0.Text = "Subscriptions";
			// 
			// frm_Subscription_Top
			// 
			frm_Subscription_Top.AllowDrop = true;
			frm_Subscription_Top.BackColor = System.Drawing.SystemColors.Control;
			frm_Subscription_Top.Controls.Add(frmSubscriptionAction);
			frm_Subscription_Top.Controls.Add(frm_Sub_Id);
			frm_Subscription_Top.Controls.Add(frm_Sub_Service);
			frm_Subscription_Top.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frm_Subscription_Top.Enabled = true;
			frm_Subscription_Top.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frm_Subscription_Top.ForeColor = System.Drawing.SystemColors.ControlText;
			frm_Subscription_Top.Location = new System.Drawing.Point(6, 4);
			frm_Subscription_Top.Name = "frm_Subscription_Top";
			frm_Subscription_Top.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frm_Subscription_Top.Size = new System.Drawing.Size(925, 337);
			frm_Subscription_Top.TabIndex = 60;
			frm_Subscription_Top.Visible = true;
			// 
			// frmSubscriptionAction
			// 
			frmSubscriptionAction.AllowDrop = true;
			frmSubscriptionAction.BackColor = System.Drawing.SystemColors.Control;
			frmSubscriptionAction.Controls.Add(_cmdSubscription_4);
			frmSubscriptionAction.Controls.Add(_cmdSubscription_3);
			frmSubscriptionAction.Controls.Add(_cmdSubscription_2);
			frmSubscriptionAction.Controls.Add(_cmdSubscription_1);
			frmSubscriptionAction.Controls.Add(_cmdSubscription_0);
			frmSubscriptionAction.Controls.Add(_lblSubLabel_27);
			frmSubscriptionAction.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmSubscriptionAction.Enabled = true;
			frmSubscriptionAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmSubscriptionAction.ForeColor = System.Drawing.SystemColors.ControlText;
			frmSubscriptionAction.Location = new System.Drawing.Point(6, 286);
			frmSubscriptionAction.Name = "frmSubscriptionAction";
			frmSubscriptionAction.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmSubscriptionAction.Size = new System.Drawing.Size(427, 45);
			frmSubscriptionAction.TabIndex = 270;
			frmSubscriptionAction.Text = "Action";
			frmSubscriptionAction.Visible = true;
			// 
			// _cmdSubscription_4
			// 
			_cmdSubscription_4.AllowDrop = true;
			_cmdSubscription_4.BackColor = System.Drawing.SystemColors.Control;
			_cmdSubscription_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmdSubscription_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmdSubscription_4.Location = new System.Drawing.Point(368, 16);
			_cmdSubscription_4.Name = "_cmdSubscription_4";
			_cmdSubscription_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmdSubscription_4.Size = new System.Drawing.Size(52, 21);
			_cmdSubscription_4.TabIndex = 370;
			_cmdSubscription_4.Text = "BI";
			_cmdSubscription_4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmdSubscription_4.UseVisualStyleBackColor = false;
			_cmdSubscription_4.Click += new System.EventHandler(cmdSubscription_Click);
			// 
			// _cmdSubscription_3
			// 
			_cmdSubscription_3.AllowDrop = true;
			_cmdSubscription_3.BackColor = System.Drawing.SystemColors.Control;
			_cmdSubscription_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmdSubscription_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmdSubscription_3.Location = new System.Drawing.Point(299, 16);
			_cmdSubscription_3.Name = "_cmdSubscription_3";
			_cmdSubscription_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmdSubscription_3.Size = new System.Drawing.Size(52, 21);
			_cmdSubscription_3.TabIndex = 274;
			_cmdSubscription_3.Text = "&Move";
			_cmdSubscription_3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmdSubscription_3.UseVisualStyleBackColor = false;
			_cmdSubscription_3.Click += new System.EventHandler(cmdSubscription_Click);
			// 
			// _cmdSubscription_2
			// 
			_cmdSubscription_2.AllowDrop = true;
			_cmdSubscription_2.BackColor = System.Drawing.SystemColors.Control;
			_cmdSubscription_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmdSubscription_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmdSubscription_2.Location = new System.Drawing.Point(229, 16);
			_cmdSubscription_2.Name = "_cmdSubscription_2";
			_cmdSubscription_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmdSubscription_2.Size = new System.Drawing.Size(52, 21);
			_cmdSubscription_2.TabIndex = 273;
			_cmdSubscription_2.Text = "&New";
			_cmdSubscription_2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmdSubscription_2.UseVisualStyleBackColor = false;
			_cmdSubscription_2.Click += new System.EventHandler(cmdSubscription_Click);
			// 
			// _cmdSubscription_1
			// 
			_cmdSubscription_1.AllowDrop = true;
			_cmdSubscription_1.BackColor = System.Drawing.SystemColors.Control;
			_cmdSubscription_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmdSubscription_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmdSubscription_1.Location = new System.Drawing.Point(150, 16);
			_cmdSubscription_1.Name = "_cmdSubscription_1";
			_cmdSubscription_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmdSubscription_1.Size = new System.Drawing.Size(62, 21);
			_cmdSubscription_1.TabIndex = 272;
			_cmdSubscription_1.Text = "Remove";
			_cmdSubscription_1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmdSubscription_1.UseVisualStyleBackColor = false;
			_cmdSubscription_1.Click += new System.EventHandler(cmdSubscription_Click);
			// 
			// _cmdSubscription_0
			// 
			_cmdSubscription_0.AllowDrop = true;
			_cmdSubscription_0.BackColor = System.Drawing.SystemColors.Control;
			_cmdSubscription_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmdSubscription_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmdSubscription_0.Location = new System.Drawing.Point(80, 16);
			_cmdSubscription_0.Name = "_cmdSubscription_0";
			_cmdSubscription_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmdSubscription_0.Size = new System.Drawing.Size(52, 21);
			_cmdSubscription_0.TabIndex = 271;
			_cmdSubscription_0.Text = "&Save";
			_cmdSubscription_0.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmdSubscription_0.UseVisualStyleBackColor = false;
			_cmdSubscription_0.Click += new System.EventHandler(cmdSubscription_Click);
			// 
			// _lblSubLabel_27
			// 
			_lblSubLabel_27.AllowDrop = true;
			_lblSubLabel_27.AutoSize = true;
			_lblSubLabel_27.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_27.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_27.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_27.Location = new System.Drawing.Point(8, 22);
			_lblSubLabel_27.MinimumSize = new System.Drawing.Size(58, 13);
			_lblSubLabel_27.Name = "_lblSubLabel_27";
			_lblSubLabel_27.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_27.Size = new System.Drawing.Size(58, 13);
			_lblSubLabel_27.TabIndex = 275;
			_lblSubLabel_27.Text = "Subscription";
			_lblSubLabel_27.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_27.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// frm_Sub_Id
			// 
			frm_Sub_Id.AllowDrop = true;
			frm_Sub_Id.BackColor = System.Drawing.SystemColors.Control;
			frm_Sub_Id.Controls.Add(chkIncludeInactive);
			frm_Sub_Id.Controls.Add(grd_Subscriptions);
			frm_Sub_Id.Controls.Add(_wbSubBrowser1_4);
			frm_Sub_Id.Controls.Add(_lblSubLabel_5);
			frm_Sub_Id.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frm_Sub_Id.Enabled = true;
			frm_Sub_Id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frm_Sub_Id.ForeColor = System.Drawing.SystemColors.ControlText;
			frm_Sub_Id.Location = new System.Drawing.Point(6, 8);
			frm_Sub_Id.Name = "frm_Sub_Id";
			frm_Sub_Id.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frm_Sub_Id.Size = new System.Drawing.Size(427, 277);
			frm_Sub_Id.TabIndex = 61;
			frm_Sub_Id.Text = "Subscriptions for this Company";
			frm_Sub_Id.Visible = true;
			frm_Sub_Id.Click += new System.EventHandler(frm_Sub_Id_Click);
			// 
			// chkIncludeInactive
			// 
			chkIncludeInactive.AllowDrop = true;
			chkIncludeInactive.Appearance = System.Windows.Forms.Appearance.Normal;
			chkIncludeInactive.BackColor = System.Drawing.SystemColors.Control;
			chkIncludeInactive.CausesValidation = true;
			chkIncludeInactive.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkIncludeInactive.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkIncludeInactive.Enabled = true;
			chkIncludeInactive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkIncludeInactive.ForeColor = System.Drawing.SystemColors.ControlText;
			chkIncludeInactive.Location = new System.Drawing.Point(12, 16);
			chkIncludeInactive.Name = "chkIncludeInactive";
			chkIncludeInactive.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkIncludeInactive.Size = new System.Drawing.Size(267, 13);
			chkIncludeInactive.TabIndex = 1;
			chkIncludeInactive.TabStop = true;
			chkIncludeInactive.Text = "Include Inactive";
			chkIncludeInactive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkIncludeInactive.Visible = true;
			chkIncludeInactive.CheckStateChanged += new System.EventHandler(chkIncludeInactive_CheckStateChanged);
			// 
			// grd_Subscriptions
			// 
			grd_Subscriptions.AllowDrop = true;
			grd_Subscriptions.AllowUserToAddRows = false;
			grd_Subscriptions.AllowUserToDeleteRows = false;
			grd_Subscriptions.AllowUserToResizeColumns = false;
			grd_Subscriptions.AllowUserToResizeColumns = grd_Subscriptions.ColumnHeadersVisible;
			grd_Subscriptions.AllowUserToResizeRows = false;
			grd_Subscriptions.AllowUserToResizeRows = grd_Subscriptions.RowHeadersVisible;
			grd_Subscriptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grd_Subscriptions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_Subscriptions.ColumnsCount = 2;
			grd_Subscriptions.FixedColumns = 1;
			grd_Subscriptions.FixedRows = 1;
			grd_Subscriptions.FocusRect = UpgradeHelpers.FocusRectSettings.FocusNone;
			grd_Subscriptions.Location = new System.Drawing.Point(8, 32);
			grd_Subscriptions.Name = "grd_Subscriptions";
			grd_Subscriptions.ReadOnly = true;
			grd_Subscriptions.RowsCount = 2;
			grd_Subscriptions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grd_Subscriptions.ShowCellToolTips = false;
			grd_Subscriptions.Size = new System.Drawing.Size(410, 119);
			grd_Subscriptions.StandardTab = true;
			grd_Subscriptions.TabIndex = 2;
			grd_Subscriptions.Click += new System.EventHandler(grd_Subscriptions_Click);
			grd_Subscriptions.MouseDown += new System.Windows.Forms.MouseEventHandler(grd_Subscriptions_MouseDown);
			// 
			// _wbSubBrowser1_4
			// 
			_wbSubBrowser1_4.AllowWebBrowserDrop = true;
			_wbSubBrowser1_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_wbSubBrowser1_4.Location = new System.Drawing.Point(8, 152);
			_wbSubBrowser1_4.Name = "_wbSubBrowser1_4";
			_wbSubBrowser1_4.Size = new System.Drawing.Size(413, 121);
			_wbSubBrowser1_4.TabIndex = 3;
			// 
			// _lblSubLabel_5
			// 
			_lblSubLabel_5.AllowDrop = true;
			_lblSubLabel_5.AutoSize = true;
			_lblSubLabel_5.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_5.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_5.Location = new System.Drawing.Point(280, 16);
			_lblSubLabel_5.MinimumSize = new System.Drawing.Size(80, 13);
			_lblSubLabel_5.Name = "_lblSubLabel_5";
			_lblSubLabel_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_5.Size = new System.Drawing.Size(80, 13);
			_lblSubLabel_5.TabIndex = 377;
			_lblSubLabel_5.Text = "Customer Since: ";
			_lblSubLabel_5.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_5.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// frm_Sub_Service
			// 
			frm_Sub_Service.AllowDrop = true;
			frm_Sub_Service.BackColor = System.Drawing.SystemColors.Control;
			frm_Sub_Service.Controls.Add(frmSubOptions);
			frm_Sub_Service.Controls.Add(frmCallbackStatus);
			frm_Sub_Service.Controls.Add(frmStartEndDate);
			frm_Sub_Service.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frm_Sub_Service.Enabled = true;
			frm_Sub_Service.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frm_Sub_Service.ForeColor = System.Drawing.SystemColors.ControlText;
			frm_Sub_Service.Location = new System.Drawing.Point(438, 9);
			frm_Sub_Service.Name = "frm_Sub_Service";
			frm_Sub_Service.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frm_Sub_Service.Size = new System.Drawing.Size(478, 321);
			frm_Sub_Service.TabIndex = 62;
			frm_Sub_Service.Text = "Service";
			frm_Sub_Service.Visible = true;
			// 
			// frmSubOptions
			// 
			frmSubOptions.AllowDrop = true;
			frmSubOptions.BackColor = System.Drawing.SystemColors.Control;
			frmSubOptions.Controls.Add(_chkProductType_13);
			frmSubOptions.Controls.Add(cbo_Service);
			frmSubOptions.Controls.Add(cmbTierLevel_comm);
			frmSubOptions.Controls.Add(chk_sub_api_flag);
			frmSubOptions.Controls.Add(txt_sub_billed_amount);
			frmSubOptions.Controls.Add(_txt_SubNbrOfInstalls_2);
			frmSubOptions.Controls.Add(_chkProductType_12);
			frmSubOptions.Controls.Add(_chkProductType_11);
			frmSubOptions.Controls.Add(_txt_SubNbrOfInstalls_1);
			frmSubOptions.Controls.Add(_chkProductType_10);
			frmSubOptions.Controls.Add(_chkProductType_9);
			frmSubOptions.Controls.Add(_chkProductType_8);
			frmSubOptions.Controls.Add(_chkProductType_7);
			frmSubOptions.Controls.Add(_chkProductType_6);
			frmSubOptions.Controls.Add(_chkProductType_5);
			frmSubOptions.Controls.Add(_chkProductType_4);
			frmSubOptions.Controls.Add(_chkProductType_3);
			frmSubOptions.Controls.Add(_chkProductType_1);
			frmSubOptions.Controls.Add(txt_sub_start_date);
			frmSubOptions.Controls.Add(txt_sub_end_date);
			frmSubOptions.Controls.Add(txt_SubContractAmount);
			frmSubOptions.Controls.Add(_txt_SubNbrOfInstalls_0);
			frmSubOptions.Controls.Add(cmbTierLevel);
			frmSubOptions.Controls.Add(_chkProductType_0);
			frmSubOptions.Controls.Add(txt_sub_id);
			frmSubOptions.Controls.Add(cmbFrequency);
			frmSubOptions.Controls.Add(txtNbrDaysExpire);
			frmSubOptions.Controls.Add(txtSubMaxExport);
			frmSubOptions.Controls.Add(lbl_Service);
			frmSubOptions.Controls.Add(_lblSubLabel_15);
			frmSubOptions.Controls.Add(_lblSubLabel_56);
			frmSubOptions.Controls.Add(_lblSubLabel_54);
			frmSubOptions.Controls.Add(_lblSubLabel_51);
			frmSubOptions.Controls.Add(lblSubUpdateNbrInstalls);
			frmSubOptions.Controls.Add(_lblSubLabel_3);
			frmSubOptions.Controls.Add(lblCalendars);
			frmSubOptions.Controls.Add(lbl_SubNbrOfInstalls);
			frmSubOptions.Controls.Add(_lblSubLabel_4);
			frmSubOptions.Controls.Add(_lblSubLabel_0);
			frmSubOptions.Controls.Add(_lblSubLabel_29);
			frmSubOptions.Controls.Add(lblNbrDaysExpire);
			frmSubOptions.Controls.Add(_lblSubLabel_2);
			frmSubOptions.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmSubOptions.Enabled = true;
			frmSubOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmSubOptions.ForeColor = System.Drawing.SystemColors.ControlText;
			frmSubOptions.Location = new System.Drawing.Point(8, 8);
			frmSubOptions.Name = "frmSubOptions";
			frmSubOptions.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmSubOptions.Size = new System.Drawing.Size(466, 152);
			frmSubOptions.TabIndex = 233;
			frmSubOptions.Visible = true;
			// 
			// _chkProductType_13
			// 
			_chkProductType_13.AllowDrop = true;
			_chkProductType_13.Appearance = System.Windows.Forms.Appearance.Normal;
			_chkProductType_13.BackColor = System.Drawing.SystemColors.Control;
			_chkProductType_13.CausesValidation = true;
			_chkProductType_13.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkProductType_13.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chkProductType_13.Enabled = true;
			_chkProductType_13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chkProductType_13.ForeColor = System.Drawing.SystemColors.ControlText;
			_chkProductType_13.Location = new System.Drawing.Point(120, 32);
			_chkProductType_13.Name = "_chkProductType_13";
			_chkProductType_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chkProductType_13.Size = new System.Drawing.Size(76, 13);
			_chkProductType_13.TabIndex = 378;
			_chkProductType_13.TabStop = true;
			_chkProductType_13.Text = "SSO";
			_chkProductType_13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkProductType_13.Visible = true;
			_chkProductType_13.CheckStateChanged += new System.EventHandler(chkProductType_CheckStateChanged);
			_chkProductType_13.MouseDown += new System.Windows.Forms.MouseEventHandler(chkProductType_MouseDown);
			// 
			// cbo_Service
			// 
			cbo_Service.AllowDrop = true;
			cbo_Service.BackColor = System.Drawing.SystemColors.Window;
			cbo_Service.CausesValidation = true;
			cbo_Service.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_Service.Enabled = true;
			cbo_Service.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_Service.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_Service.IntegralHeight = true;
			cbo_Service.Location = new System.Drawing.Point(77, 8);
			cbo_Service.Name = "cbo_Service";
			cbo_Service.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_Service.Size = new System.Drawing.Size(299, 21);
			cbo_Service.Sorted = false;
			cbo_Service.TabIndex = 375;
			cbo_Service.TabStop = true;
			cbo_Service.Visible = true;
			cbo_Service.SelectionChangeCommitted += new System.EventHandler(cbo_Service_SelectionChangeCommitted);
			cbo_Service.TextChanged += new System.EventHandler(cbo_Service_TextChanged);
			// 
			// cmbTierLevel_comm
			// 
			cmbTierLevel_comm.AllowDrop = true;
			cmbTierLevel_comm.BackColor = System.Drawing.SystemColors.Window;
			cmbTierLevel_comm.CausesValidation = true;
			cmbTierLevel_comm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cmbTierLevel_comm.Enabled = true;
			cmbTierLevel_comm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmbTierLevel_comm.ForeColor = System.Drawing.SystemColors.WindowText;
			cmbTierLevel_comm.IntegralHeight = true;
			cmbTierLevel_comm.Location = new System.Drawing.Point(269, 72);
			cmbTierLevel_comm.Name = "cmbTierLevel_comm";
			cmbTierLevel_comm.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmbTierLevel_comm.Size = new System.Drawing.Size(107, 21);
			cmbTierLevel_comm.Sorted = false;
			cmbTierLevel_comm.TabIndex = 372;
			cmbTierLevel_comm.TabStop = true;
			cmbTierLevel_comm.Visible = false;
			// 
			// chk_sub_api_flag
			// 
			chk_sub_api_flag.AllowDrop = true;
			chk_sub_api_flag.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_sub_api_flag.BackColor = System.Drawing.SystemColors.Control;
			chk_sub_api_flag.CausesValidation = true;
			chk_sub_api_flag.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_sub_api_flag.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_sub_api_flag.Enabled = true;
			chk_sub_api_flag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_sub_api_flag.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_sub_api_flag.Location = new System.Drawing.Point(384, 64);
			chk_sub_api_flag.Name = "chk_sub_api_flag";
			chk_sub_api_flag.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_sub_api_flag.Size = new System.Drawing.Size(73, 13);
			chk_sub_api_flag.TabIndex = 371;
			chk_sub_api_flag.TabStop = true;
			chk_sub_api_flag.Text = "API Flights";
			chk_sub_api_flag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_sub_api_flag.Visible = true;
			// 
			// txt_sub_billed_amount
			// 
			txt_sub_billed_amount.AcceptsReturn = true;
			txt_sub_billed_amount.AllowDrop = true;
			txt_sub_billed_amount.BackColor = System.Drawing.SystemColors.Window;
			txt_sub_billed_amount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_sub_billed_amount.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_sub_billed_amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_sub_billed_amount.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_sub_billed_amount.Location = new System.Drawing.Point(240, 8);
			txt_sub_billed_amount.MaxLength = 0;
			txt_sub_billed_amount.Name = "txt_sub_billed_amount";
			txt_sub_billed_amount.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_sub_billed_amount.Size = new System.Drawing.Size(48, 19);
			txt_sub_billed_amount.TabIndex = 300;
			txt_sub_billed_amount.Text = "0.0";
			txt_sub_billed_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txt_sub_billed_amount.Visible = false;
			// 
			// _txt_SubNbrOfInstalls_2
			// 
			_txt_SubNbrOfInstalls_2.AcceptsReturn = true;
			_txt_SubNbrOfInstalls_2.AllowDrop = true;
			_txt_SubNbrOfInstalls_2.BackColor = System.Drawing.Color.White;
			_txt_SubNbrOfInstalls_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_SubNbrOfInstalls_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_SubNbrOfInstalls_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_SubNbrOfInstalls_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_SubNbrOfInstalls_2.Location = new System.Drawing.Point(432, 48);
			_txt_SubNbrOfInstalls_2.MaxLength = 4;
			_txt_SubNbrOfInstalls_2.Name = "_txt_SubNbrOfInstalls_2";
			_txt_SubNbrOfInstalls_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_SubNbrOfInstalls_2.Size = new System.Drawing.Size(27, 19);
			_txt_SubNbrOfInstalls_2.TabIndex = 255;
			_txt_SubNbrOfInstalls_2.Text = "0";
			_txt_SubNbrOfInstalls_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// _chkProductType_12
			// 
			_chkProductType_12.AllowDrop = true;
			_chkProductType_12.Appearance = System.Windows.Forms.Appearance.Normal;
			_chkProductType_12.BackColor = System.Drawing.SystemColors.Control;
			_chkProductType_12.CausesValidation = true;
			_chkProductType_12.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkProductType_12.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chkProductType_12.Enabled = false;
			_chkProductType_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chkProductType_12.ForeColor = System.Drawing.SystemColors.ControlText;
			_chkProductType_12.Location = new System.Drawing.Point(384, 50);
			_chkProductType_12.Name = "_chkProductType_12";
			_chkProductType_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chkProductType_12.Size = new System.Drawing.Size(50, 13);
			_chkProductType_12.TabIndex = 254;
			_chkProductType_12.TabStop = true;
			_chkProductType_12.Text = "MPM";
			_chkProductType_12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkProductType_12.Visible = true;
			_chkProductType_12.CheckStateChanged += new System.EventHandler(chkProductType_CheckStateChanged);
			_chkProductType_12.MouseDown += new System.Windows.Forms.MouseEventHandler(chkProductType_MouseDown);
			// 
			// _chkProductType_11
			// 
			_chkProductType_11.AllowDrop = true;
			_chkProductType_11.Appearance = System.Windows.Forms.Appearance.Normal;
			_chkProductType_11.BackColor = System.Drawing.SystemColors.Control;
			_chkProductType_11.CausesValidation = true;
			_chkProductType_11.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkProductType_11.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chkProductType_11.Enabled = true;
			_chkProductType_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chkProductType_11.ForeColor = System.Drawing.SystemColors.ControlText;
			_chkProductType_11.Location = new System.Drawing.Point(384, 78);
			_chkProductType_11.Name = "_chkProductType_11";
			_chkProductType_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chkProductType_11.Size = new System.Drawing.Size(75, 13);
			_chkProductType_11.TabIndex = 249;
			_chkProductType_11.TabStop = true;
			_chkProductType_11.Text = "API History";
			_chkProductType_11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkProductType_11.Visible = true;
			_chkProductType_11.CheckStateChanged += new System.EventHandler(chkProductType_CheckStateChanged);
			_chkProductType_11.MouseDown += new System.Windows.Forms.MouseEventHandler(chkProductType_MouseDown);
			// 
			// _txt_SubNbrOfInstalls_1
			// 
			_txt_SubNbrOfInstalls_1.AcceptsReturn = true;
			_txt_SubNbrOfInstalls_1.AllowDrop = true;
			_txt_SubNbrOfInstalls_1.BackColor = System.Drawing.Color.White;
			_txt_SubNbrOfInstalls_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_SubNbrOfInstalls_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_SubNbrOfInstalls_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_SubNbrOfInstalls_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_SubNbrOfInstalls_1.Location = new System.Drawing.Point(432, 28);
			_txt_SubNbrOfInstalls_1.MaxLength = 4;
			_txt_SubNbrOfInstalls_1.Name = "_txt_SubNbrOfInstalls_1";
			_txt_SubNbrOfInstalls_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_SubNbrOfInstalls_1.Size = new System.Drawing.Size(27, 19);
			_txt_SubNbrOfInstalls_1.TabIndex = 253;
			_txt_SubNbrOfInstalls_1.Text = "0";
			_txt_SubNbrOfInstalls_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// _chkProductType_10
			// 
			_chkProductType_10.AllowDrop = true;
			_chkProductType_10.Appearance = System.Windows.Forms.Appearance.Normal;
			_chkProductType_10.BackColor = System.Drawing.SystemColors.Control;
			_chkProductType_10.CausesValidation = true;
			_chkProductType_10.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			_chkProductType_10.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chkProductType_10.Enabled = true;
			_chkProductType_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chkProductType_10.ForeColor = System.Drawing.SystemColors.ControlText;
			_chkProductType_10.Location = new System.Drawing.Point(150, 110);
			_chkProductType_10.Name = "_chkProductType_10";
			_chkProductType_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chkProductType_10.Size = new System.Drawing.Size(110, 13);
			_chkProductType_10.TabIndex = 242;
			_chkProductType_10.TabStop = true;
			_chkProductType_10.Text = "Share by Parent Id";
			_chkProductType_10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkProductType_10.Visible = true;
			_chkProductType_10.CheckStateChanged += new System.EventHandler(chkProductType_CheckStateChanged);
			_chkProductType_10.MouseDown += new System.Windows.Forms.MouseEventHandler(chkProductType_MouseDown);
			// 
			// _chkProductType_9
			// 
			_chkProductType_9.AllowDrop = true;
			_chkProductType_9.Appearance = System.Windows.Forms.Appearance.Normal;
			_chkProductType_9.BackColor = System.Drawing.SystemColors.Control;
			_chkProductType_9.CausesValidation = true;
			_chkProductType_9.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			_chkProductType_9.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chkProductType_9.Enabled = true;
			_chkProductType_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chkProductType_9.ForeColor = System.Drawing.SystemColors.ControlText;
			_chkProductType_9.Location = new System.Drawing.Point(4, 110);
			_chkProductType_9.Name = "_chkProductType_9";
			_chkProductType_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chkProductType_9.Size = new System.Drawing.Size(106, 13);
			_chkProductType_9.TabIndex = 238;
			_chkProductType_9.TabStop = true;
			_chkProductType_9.Text = "Share by CompId";
			_chkProductType_9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkProductType_9.Visible = true;
			_chkProductType_9.CheckStateChanged += new System.EventHandler(chkProductType_CheckStateChanged);
			_chkProductType_9.MouseDown += new System.Windows.Forms.MouseEventHandler(chkProductType_MouseDown);
			// 
			// _chkProductType_8
			// 
			_chkProductType_8.AllowDrop = true;
			_chkProductType_8.Appearance = System.Windows.Forms.Appearance.Normal;
			_chkProductType_8.BackColor = System.Drawing.SystemColors.Control;
			_chkProductType_8.CausesValidation = true;
			_chkProductType_8.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			_chkProductType_8.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chkProductType_8.Enabled = true;
			_chkProductType_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chkProductType_8.ForeColor = System.Drawing.SystemColors.ControlText;
			_chkProductType_8.Location = new System.Drawing.Point(8, 56);
			_chkProductType_8.Name = "_chkProductType_8";
			_chkProductType_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chkProductType_8.Size = new System.Drawing.Size(94, 13);
			_chkProductType_8.TabIndex = 235;
			_chkProductType_8.TabStop = true;
			_chkProductType_8.Text = "Marketing Acct";
			_chkProductType_8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkProductType_8.Visible = true;
			_chkProductType_8.CheckStateChanged += new System.EventHandler(chkProductType_CheckStateChanged);
			_chkProductType_8.MouseDown += new System.Windows.Forms.MouseEventHandler(chkProductType_MouseDown);
			// 
			// _chkProductType_7
			// 
			_chkProductType_7.AllowDrop = true;
			_chkProductType_7.Appearance = System.Windows.Forms.Appearance.Normal;
			_chkProductType_7.BackColor = System.Drawing.SystemColors.Control;
			_chkProductType_7.CausesValidation = true;
			_chkProductType_7.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkProductType_7.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chkProductType_7.Enabled = true;
			_chkProductType_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chkProductType_7.ForeColor = System.Drawing.SystemColors.ControlText;
			_chkProductType_7.Location = new System.Drawing.Point(384, 30);
			_chkProductType_7.Name = "_chkProductType_7";
			_chkProductType_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chkProductType_7.Size = new System.Drawing.Size(52, 13);
			_chkProductType_7.TabIndex = 252;
			_chkProductType_7.TabStop = true;
			_chkProductType_7.Text = "Values";
			_chkProductType_7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkProductType_7.Visible = true;
			_chkProductType_7.CheckStateChanged += new System.EventHandler(chkProductType_CheckStateChanged);
			_chkProductType_7.MouseDown += new System.Windows.Forms.MouseEventHandler(chkProductType_MouseDown);
			// 
			// _chkProductType_6
			// 
			_chkProductType_6.AllowDrop = true;
			_chkProductType_6.Appearance = System.Windows.Forms.Appearance.Normal;
			_chkProductType_6.BackColor = System.Drawing.SystemColors.Control;
			_chkProductType_6.CausesValidation = true;
			_chkProductType_6.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkProductType_6.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chkProductType_6.Enabled = true;
			_chkProductType_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chkProductType_6.ForeColor = System.Drawing.SystemColors.ControlText;
			_chkProductType_6.Location = new System.Drawing.Point(280, 96);
			_chkProductType_6.Name = "_chkProductType_6";
			_chkProductType_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chkProductType_6.Size = new System.Drawing.Size(80, 13);
			_chkProductType_6.TabIndex = 251;
			_chkProductType_6.TabStop = true;
			_chkProductType_6.Text = "Star Reports";
			_chkProductType_6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkProductType_6.Visible = false;
			_chkProductType_6.CheckStateChanged += new System.EventHandler(chkProductType_CheckStateChanged);
			_chkProductType_6.MouseDown += new System.Windows.Forms.MouseEventHandler(chkProductType_MouseDown);
			// 
			// _chkProductType_5
			// 
			_chkProductType_5.AllowDrop = true;
			_chkProductType_5.Appearance = System.Windows.Forms.Appearance.Normal;
			_chkProductType_5.BackColor = System.Drawing.SystemColors.Control;
			_chkProductType_5.CausesValidation = true;
			_chkProductType_5.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkProductType_5.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chkProductType_5.Enabled = true;
			_chkProductType_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chkProductType_5.ForeColor = System.Drawing.SystemColors.ControlText;
			_chkProductType_5.Location = new System.Drawing.Point(384, 12);
			_chkProductType_5.Name = "_chkProductType_5";
			_chkProductType_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chkProductType_5.Size = new System.Drawing.Size(72, 13);
			_chkProductType_5.TabIndex = 250;
			_chkProductType_5.TabStop = true;
			_chkProductType_5.Text = "Aerodex";
			_chkProductType_5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkProductType_5.Visible = true;
			_chkProductType_5.CheckStateChanged += new System.EventHandler(chkProductType_CheckStateChanged);
			_chkProductType_5.MouseDown += new System.Windows.Forms.MouseEventHandler(chkProductType_MouseDown);
			// 
			// _chkProductType_4
			// 
			_chkProductType_4.AllowDrop = true;
			_chkProductType_4.Appearance = System.Windows.Forms.Appearance.Normal;
			_chkProductType_4.BackColor = System.Drawing.SystemColors.Control;
			_chkProductType_4.CausesValidation = true;
			_chkProductType_4.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkProductType_4.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chkProductType_4.Enabled = true;
			_chkProductType_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chkProductType_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_chkProductType_4.Location = new System.Drawing.Point(184, 72);
			_chkProductType_4.Name = "_chkProductType_4";
			_chkProductType_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chkProductType_4.Size = new System.Drawing.Size(84, 13);
			_chkProductType_4.TabIndex = 248;
			_chkProductType_4.TabStop = true;
			_chkProductType_4.Text = "Commercial";
			_chkProductType_4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkProductType_4.Visible = true;
			_chkProductType_4.CheckStateChanged += new System.EventHandler(chkProductType_CheckStateChanged);
			_chkProductType_4.MouseDown += new System.Windows.Forms.MouseEventHandler(chkProductType_MouseDown);
			// 
			// _chkProductType_3
			// 
			_chkProductType_3.AllowDrop = true;
			_chkProductType_3.Appearance = System.Windows.Forms.Appearance.Normal;
			_chkProductType_3.BackColor = System.Drawing.SystemColors.Control;
			_chkProductType_3.CausesValidation = true;
			_chkProductType_3.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkProductType_3.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chkProductType_3.Enabled = true;
			_chkProductType_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chkProductType_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_chkProductType_3.Location = new System.Drawing.Point(288, 96);
			_chkProductType_3.Name = "_chkProductType_3";
			_chkProductType_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chkProductType_3.Size = new System.Drawing.Size(72, 13);
			_chkProductType_3.TabIndex = 247;
			_chkProductType_3.TabStop = true;
			_chkProductType_3.Text = "JN Global";
			_chkProductType_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkProductType_3.Visible = false;
			_chkProductType_3.CheckStateChanged += new System.EventHandler(chkProductType_CheckStateChanged);
			_chkProductType_3.MouseDown += new System.Windows.Forms.MouseEventHandler(chkProductType_MouseDown);
			// 
			// _chkProductType_1
			// 
			_chkProductType_1.AllowDrop = true;
			_chkProductType_1.Appearance = System.Windows.Forms.Appearance.Normal;
			_chkProductType_1.BackColor = System.Drawing.SystemColors.Control;
			_chkProductType_1.CausesValidation = true;
			_chkProductType_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkProductType_1.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chkProductType_1.Enabled = true;
			_chkProductType_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chkProductType_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_chkProductType_1.Location = new System.Drawing.Point(184, 88);
			_chkProductType_1.Name = "_chkProductType_1";
			_chkProductType_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chkProductType_1.Size = new System.Drawing.Size(98, 13);
			_chkProductType_1.TabIndex = 246;
			_chkProductType_1.TabStop = true;
			_chkProductType_1.Text = "Helicopters";
			_chkProductType_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkProductType_1.Visible = true;
			_chkProductType_1.CheckStateChanged += new System.EventHandler(chkProductType_CheckStateChanged);
			_chkProductType_1.MouseDown += new System.Windows.Forms.MouseEventHandler(chkProductType_MouseDown);
			// 
			// txt_sub_start_date
			// 
			txt_sub_start_date.AcceptsReturn = true;
			txt_sub_start_date.AllowDrop = true;
			txt_sub_start_date.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_sub_start_date.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_sub_start_date.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_sub_start_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_sub_start_date.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_sub_start_date.Location = new System.Drawing.Point(62, 126);
			txt_sub_start_date.MaxLength = 0;
			txt_sub_start_date.Name = "txt_sub_start_date";
			txt_sub_start_date.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_sub_start_date.Size = new System.Drawing.Size(82, 19);
			txt_sub_start_date.TabIndex = 243;
			txt_sub_start_date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txt_sub_end_date
			// 
			txt_sub_end_date.AcceptsReturn = true;
			txt_sub_end_date.AllowDrop = true;
			txt_sub_end_date.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_sub_end_date.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_sub_end_date.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_sub_end_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_sub_end_date.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_sub_end_date.Location = new System.Drawing.Point(305, 126);
			txt_sub_end_date.MaxLength = 0;
			txt_sub_end_date.Name = "txt_sub_end_date";
			txt_sub_end_date.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_sub_end_date.Size = new System.Drawing.Size(82, 19);
			txt_sub_end_date.TabIndex = 244;
			txt_sub_end_date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txt_SubContractAmount
			// 
			txt_SubContractAmount.AcceptsReturn = true;
			txt_SubContractAmount.AllowDrop = true;
			txt_SubContractAmount.BackColor = System.Drawing.Color.White;
			txt_SubContractAmount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_SubContractAmount.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_SubContractAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_SubContractAmount.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_SubContractAmount.Location = new System.Drawing.Point(224, 8);
			txt_SubContractAmount.MaxLength = 10;
			txt_SubContractAmount.Name = "txt_SubContractAmount";
			txt_SubContractAmount.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_SubContractAmount.Size = new System.Drawing.Size(48, 19);
			txt_SubContractAmount.TabIndex = 237;
			txt_SubContractAmount.Text = "0.00";
			txt_SubContractAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txt_SubContractAmount.Visible = false;
			txt_SubContractAmount.Leave += new System.EventHandler(txt_SubContractAmount_Leave);
			// 
			// _txt_SubNbrOfInstalls_0
			// 
			_txt_SubNbrOfInstalls_0.AcceptsReturn = true;
			_txt_SubNbrOfInstalls_0.AllowDrop = true;
			_txt_SubNbrOfInstalls_0.BackColor = System.Drawing.Color.White;
			_txt_SubNbrOfInstalls_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_SubNbrOfInstalls_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_SubNbrOfInstalls_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_SubNbrOfInstalls_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_SubNbrOfInstalls_0.Location = new System.Drawing.Point(424, 92);
			_txt_SubNbrOfInstalls_0.MaxLength = 4;
			_txt_SubNbrOfInstalls_0.Name = "_txt_SubNbrOfInstalls_0";
			_txt_SubNbrOfInstalls_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_SubNbrOfInstalls_0.Size = new System.Drawing.Size(35, 19);
			_txt_SubNbrOfInstalls_0.TabIndex = 241;
			_txt_SubNbrOfInstalls_0.Text = "0";
			_txt_SubNbrOfInstalls_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// cmbTierLevel
			// 
			cmbTierLevel.AllowDrop = true;
			cmbTierLevel.BackColor = System.Drawing.SystemColors.Window;
			cmbTierLevel.CausesValidation = true;
			cmbTierLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cmbTierLevel.Enabled = true;
			cmbTierLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmbTierLevel.ForeColor = System.Drawing.SystemColors.WindowText;
			cmbTierLevel.IntegralHeight = true;
			cmbTierLevel.Location = new System.Drawing.Point(269, 48);
			cmbTierLevel.Name = "cmbTierLevel";
			cmbTierLevel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmbTierLevel.Size = new System.Drawing.Size(107, 21);
			cmbTierLevel.Sorted = false;
			cmbTierLevel.TabIndex = 240;
			cmbTierLevel.TabStop = true;
			cmbTierLevel.Visible = true;
			// 
			// _chkProductType_0
			// 
			_chkProductType_0.AllowDrop = true;
			_chkProductType_0.Appearance = System.Windows.Forms.Appearance.Normal;
			_chkProductType_0.BackColor = System.Drawing.SystemColors.Control;
			_chkProductType_0.CausesValidation = true;
			_chkProductType_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkProductType_0.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_chkProductType_0.Enabled = true;
			_chkProductType_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chkProductType_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_chkProductType_0.Location = new System.Drawing.Point(184, 55);
			_chkProductType_0.Name = "_chkProductType_0";
			_chkProductType_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chkProductType_0.Size = new System.Drawing.Size(89, 13);
			_chkProductType_0.TabIndex = 245;
			_chkProductType_0.TabStop = true;
			_chkProductType_0.Text = "Business";
			_chkProductType_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkProductType_0.Visible = true;
			_chkProductType_0.CheckStateChanged += new System.EventHandler(chkProductType_CheckStateChanged);
			_chkProductType_0.MouseDown += new System.Windows.Forms.MouseEventHandler(chkProductType_MouseDown);
			// 
			// txt_sub_id
			// 
			txt_sub_id.AcceptsReturn = true;
			txt_sub_id.AllowDrop = true;
			txt_sub_id.BackColor = System.Drawing.Color.White;
			txt_sub_id.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_sub_id.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_sub_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_sub_id.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_sub_id.Location = new System.Drawing.Point(37, 32);
			txt_sub_id.MaxLength = 0;
			txt_sub_id.Name = "txt_sub_id";
			txt_sub_id.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_sub_id.Size = new System.Drawing.Size(57, 20);
			txt_sub_id.TabIndex = 234;
			txt_sub_id.Text = "0";
			// 
			// cmbFrequency
			// 
			cmbFrequency.AllowDrop = true;
			cmbFrequency.BackColor = System.Drawing.SystemColors.Window;
			cmbFrequency.CausesValidation = true;
			cmbFrequency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cmbFrequency.Enabled = true;
			cmbFrequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmbFrequency.ForeColor = System.Drawing.SystemColors.WindowText;
			cmbFrequency.IntegralHeight = true;
			cmbFrequency.Location = new System.Drawing.Point(293, 28);
			cmbFrequency.Name = "cmbFrequency";
			cmbFrequency.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmbFrequency.Size = new System.Drawing.Size(83, 21);
			cmbFrequency.Sorted = false;
			cmbFrequency.TabIndex = 239;
			cmbFrequency.TabStop = true;
			cmbFrequency.Visible = true;
			// 
			// txtNbrDaysExpire
			// 
			txtNbrDaysExpire.AcceptsReturn = true;
			txtNbrDaysExpire.AllowDrop = true;
			txtNbrDaysExpire.BackColor = System.Drawing.SystemColors.Window;
			txtNbrDaysExpire.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtNbrDaysExpire.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtNbrDaysExpire.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtNbrDaysExpire.ForeColor = System.Drawing.SystemColors.WindowText;
			txtNbrDaysExpire.Location = new System.Drawing.Point(88, 70);
			txtNbrDaysExpire.MaxLength = 0;
			txtNbrDaysExpire.Name = "txtNbrDaysExpire";
			txtNbrDaysExpire.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtNbrDaysExpire.Size = new System.Drawing.Size(29, 19);
			txtNbrDaysExpire.TabIndex = 236;
			txtNbrDaysExpire.Text = "0";
			txtNbrDaysExpire.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txtNbrDaysExpire.TextChanged += new System.EventHandler(txtNbrDaysExpire_TextChanged);
			// 
			// txtSubMaxExport
			// 
			txtSubMaxExport.AcceptsReturn = true;
			txtSubMaxExport.AllowDrop = true;
			txtSubMaxExport.BackColor = System.Drawing.SystemColors.Window;
			txtSubMaxExport.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtSubMaxExport.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtSubMaxExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtSubMaxExport.ForeColor = System.Drawing.SystemColors.WindowText;
			txtSubMaxExport.Location = new System.Drawing.Point(70, 92);
			txtSubMaxExport.MaxLength = 6;
			txtSubMaxExport.Name = "txtSubMaxExport";
			txtSubMaxExport.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtSubMaxExport.Size = new System.Drawing.Size(37, 19);
			txtSubMaxExport.TabIndex = 256;
			txtSubMaxExport.Text = "2000";
			txtSubMaxExport.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lbl_Service
			// 
			lbl_Service.AllowDrop = true;
			lbl_Service.AutoSize = true;
			lbl_Service.BackColor = System.Drawing.Color.Transparent;
			lbl_Service.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_Service.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_Service.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_Service.Location = new System.Drawing.Point(4, 12);
			lbl_Service.MinimumSize = new System.Drawing.Size(66, 13);
			lbl_Service.Name = "lbl_Service";
			lbl_Service.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_Service.Size = new System.Drawing.Size(66, 13);
			lbl_Service.TabIndex = 376;
			lbl_Service.Text = "Base Service:";
			lbl_Service.Click += new System.EventHandler(lbl_Service_Click);
			// 
			// _lblSubLabel_15
			// 
			_lblSubLabel_15.AllowDrop = true;
			_lblSubLabel_15.AutoSize = true;
			_lblSubLabel_15.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_15.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_15.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_15.Location = new System.Drawing.Point(5, 94);
			_lblSubLabel_15.MinimumSize = new System.Drawing.Size(53, 13);
			_lblSubLabel_15.Name = "_lblSubLabel_15";
			_lblSubLabel_15.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_15.Size = new System.Drawing.Size(53, 13);
			_lblSubLabel_15.TabIndex = 263;
			_lblSubLabel_15.Text = "Max Export";
			_lblSubLabel_15.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_15.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// _lblSubLabel_56
			// 
			_lblSubLabel_56.AllowDrop = true;
			_lblSubLabel_56.AutoSize = true;
			_lblSubLabel_56.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_56.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_56.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_56.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_56.Location = new System.Drawing.Point(264, 8);
			_lblSubLabel_56.MinimumSize = new System.Drawing.Size(11, 13);
			_lblSubLabel_56.Name = "_lblSubLabel_56";
			_lblSubLabel_56.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_56.Size = new System.Drawing.Size(11, 13);
			_lblSubLabel_56.TabIndex = 301;
			_lblSubLabel_56.Text = " / ";
			_lblSubLabel_56.Visible = false;
			_lblSubLabel_56.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_56.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// _lblSubLabel_54
			// 
			_lblSubLabel_54.AllowDrop = true;
			_lblSubLabel_54.AutoSize = true;
			_lblSubLabel_54.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_54.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_54.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_54.ForeColor = System.Drawing.Color.Blue;
			_lblSubLabel_54.Location = new System.Drawing.Point(394, 130);
			_lblSubLabel_54.MinimumSize = new System.Drawing.Size(64, 13);
			_lblSubLabel_54.Name = "_lblSubLabel_54";
			_lblSubLabel_54.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_54.Size = new System.Drawing.Size(64, 13);
			_lblSubLabel_54.TabIndex = 299;
			_lblSubLabel_54.Text = "Copy Logins";
			_lblSubLabel_54.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lblSubLabel_54.Visible = false;
			_lblSubLabel_54.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_54.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// _lblSubLabel_51
			// 
			_lblSubLabel_51.AllowDrop = true;
			_lblSubLabel_51.AutoSize = true;
			_lblSubLabel_51.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_51.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_51.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_51.ForeColor = System.Drawing.Color.Blue;
			_lblSubLabel_51.Location = new System.Drawing.Point(268, 110);
			_lblSubLabel_51.MinimumSize = new System.Drawing.Size(81, 13);
			_lblSubLabel_51.Name = "_lblSubLabel_51";
			_lblSubLabel_51.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_51.Size = new System.Drawing.Size(81, 13);
			_lblSubLabel_51.TabIndex = 290;
			_lblSubLabel_51.Text = "View MPM Users";
			_lblSubLabel_51.Visible = false;
			_lblSubLabel_51.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_51.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// lblSubUpdateNbrInstalls
			// 
			lblSubUpdateNbrInstalls.AllowDrop = true;
			lblSubUpdateNbrInstalls.BackColor = System.Drawing.SystemColors.Control;
			lblSubUpdateNbrInstalls.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblSubUpdateNbrInstalls.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblSubUpdateNbrInstalls.ForeColor = System.Drawing.Color.Blue;
			lblSubUpdateNbrInstalls.Location = new System.Drawing.Point(356, 110);
			lblSubUpdateNbrInstalls.MinimumSize = new System.Drawing.Size(105, 16);
			lblSubUpdateNbrInstalls.Name = "lblSubUpdateNbrInstalls";
			lblSubUpdateNbrInstalls.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblSubUpdateNbrInstalls.Size = new System.Drawing.Size(105, 16);
			lblSubUpdateNbrInstalls.TabIndex = 276;
			lblSubUpdateNbrInstalls.Text = "Update Nbr Of Installs";
			lblSubUpdateNbrInstalls.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			lblSubUpdateNbrInstalls.Click += new System.EventHandler(lblSubUpdateNbrInstalls_Click);
			// 
			// _lblSubLabel_3
			// 
			_lblSubLabel_3.AllowDrop = true;
			_lblSubLabel_3.AutoSize = true;
			_lblSubLabel_3.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_3.Location = new System.Drawing.Point(5, 132);
			_lblSubLabel_3.MinimumSize = new System.Drawing.Size(48, 13);
			_lblSubLabel_3.Name = "_lblSubLabel_3";
			_lblSubLabel_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_3.Size = new System.Drawing.Size(48, 13);
			_lblSubLabel_3.TabIndex = 269;
			_lblSubLabel_3.Text = "Start Date";
			_lblSubLabel_3.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_3.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// lblCalendars
			// 
			lblCalendars.AllowDrop = true;
			lblCalendars.BackColor = System.Drawing.SystemColors.Control;
			lblCalendars.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblCalendars.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblCalendars.ForeColor = System.Drawing.Color.Blue;
			lblCalendars.Location = new System.Drawing.Point(144, 132);
			lblCalendars.MinimumSize = new System.Drawing.Size(105, 13);
			lblCalendars.Name = "lblCalendars";
			lblCalendars.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblCalendars.Size = new System.Drawing.Size(105, 13);
			lblCalendars.TabIndex = 268;
			lblCalendars.Text = "<< View Calendars >>";
			lblCalendars.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			lblCalendars.Click += new System.EventHandler(lblCalendars_Click);
			// 
			// lbl_SubNbrOfInstalls
			// 
			lbl_SubNbrOfInstalls.AllowDrop = true;
			lbl_SubNbrOfInstalls.AutoSize = true;
			lbl_SubNbrOfInstalls.BackColor = System.Drawing.Color.Transparent;
			lbl_SubNbrOfInstalls.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_SubNbrOfInstalls.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_SubNbrOfInstalls.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_SubNbrOfInstalls.Location = new System.Drawing.Point(384, 96);
			lbl_SubNbrOfInstalls.MinimumSize = new System.Drawing.Size(37, 13);
			lbl_SubNbrOfInstalls.Name = "lbl_SubNbrOfInstalls";
			lbl_SubNbrOfInstalls.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_SubNbrOfInstalls.Size = new System.Drawing.Size(37, 13);
			lbl_SubNbrOfInstalls.TabIndex = 267;
			lbl_SubNbrOfInstalls.Text = "# Install";
			lbl_SubNbrOfInstalls.Click += new System.EventHandler(lbl_SubNbrOfInstalls_Click);
			// 
			// _lblSubLabel_4
			// 
			_lblSubLabel_4.AllowDrop = true;
			_lblSubLabel_4.AutoSize = true;
			_lblSubLabel_4.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_4.Location = new System.Drawing.Point(248, 32);
			_lblSubLabel_4.MinimumSize = new System.Drawing.Size(43, 13);
			_lblSubLabel_4.Name = "_lblSubLabel_4";
			_lblSubLabel_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_4.Size = new System.Drawing.Size(43, 13);
			_lblSubLabel_4.TabIndex = 265;
			_lblSubLabel_4.Text = "Updates:";
			_lblSubLabel_4.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_4.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// _lblSubLabel_0
			// 
			_lblSubLabel_0.AllowDrop = true;
			_lblSubLabel_0.AutoSize = true;
			_lblSubLabel_0.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_0.Location = new System.Drawing.Point(4, 35);
			_lblSubLabel_0.MinimumSize = new System.Drawing.Size(30, 13);
			_lblSubLabel_0.Name = "_lblSubLabel_0";
			_lblSubLabel_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_0.Size = new System.Drawing.Size(30, 13);
			_lblSubLabel_0.TabIndex = 261;
			_lblSubLabel_0.Text = "SubID";
			_lblSubLabel_0.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_0.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// _lblSubLabel_29
			// 
			_lblSubLabel_29.AllowDrop = true;
			_lblSubLabel_29.AutoSize = true;
			_lblSubLabel_29.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_29.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_29.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_29.Location = new System.Drawing.Point(252, 132);
			_lblSubLabel_29.MinimumSize = new System.Drawing.Size(45, 13);
			_lblSubLabel_29.Name = "_lblSubLabel_29";
			_lblSubLabel_29.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_29.Size = new System.Drawing.Size(45, 13);
			_lblSubLabel_29.TabIndex = 259;
			_lblSubLabel_29.Text = "End Date";
			_lblSubLabel_29.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_29.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// lblNbrDaysExpire
			// 
			lblNbrDaysExpire.AllowDrop = true;
			lblNbrDaysExpire.BackColor = System.Drawing.SystemColors.Control;
			lblNbrDaysExpire.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblNbrDaysExpire.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblNbrDaysExpire.ForeColor = System.Drawing.SystemColors.ControlText;
			lblNbrDaysExpire.Location = new System.Drawing.Point(5, 74);
			lblNbrDaysExpire.MinimumSize = new System.Drawing.Size(71, 17);
			lblNbrDaysExpire.Name = "lblNbrDaysExpire";
			lblNbrDaysExpire.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblNbrDaysExpire.Size = new System.Drawing.Size(71, 17);
			lblNbrDaysExpire.TabIndex = 257;
			lblNbrDaysExpire.Text = "Days to Expire";
			// 
			// _lblSubLabel_2
			// 
			_lblSubLabel_2.AllowDrop = true;
			_lblSubLabel_2.AutoSize = true;
			_lblSubLabel_2.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_2.Location = new System.Drawing.Point(208, 16);
			_lblSubLabel_2.MinimumSize = new System.Drawing.Size(79, 13);
			_lblSubLabel_2.Name = "_lblSubLabel_2";
			_lblSubLabel_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_2.Size = new System.Drawing.Size(79, 13);
			_lblSubLabel_2.TabIndex = 266;
			_lblSubLabel_2.Text = "List/Billed Amt $:";
			_lblSubLabel_2.Visible = false;
			_lblSubLabel_2.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_2.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// frmCallbackStatus
			// 
			frmCallbackStatus.AllowDrop = true;
			frmCallbackStatus.BackColor = System.Drawing.SystemColors.Control;
			frmCallbackStatus.Controls.Add(txtCallbackComments);
			frmCallbackStatus.Controls.Add(cboCallBackStatus);
			frmCallbackStatus.Controls.Add(txtCallBackDate);
			frmCallbackStatus.Controls.Add(calCallBackDate);
			frmCallbackStatus.Controls.Add(_lblSubLabel_70);
			frmCallbackStatus.Controls.Add(lblServerSideNotes);
			frmCallbackStatus.Controls.Add(_lblSubLabel_7);
			frmCallbackStatus.Controls.Add(_lblSubLabel_6);
			frmCallbackStatus.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmCallbackStatus.Enabled = true;
			frmCallbackStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmCallbackStatus.ForeColor = System.Drawing.SystemColors.ControlText;
			frmCallbackStatus.Location = new System.Drawing.Point(8, 152);
			frmCallbackStatus.Name = "frmCallbackStatus";
			frmCallbackStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmCallbackStatus.Size = new System.Drawing.Size(465, 161);
			frmCallbackStatus.TabIndex = 129;
			frmCallbackStatus.Visible = true;
			// 
			// txtCallbackComments
			// 
			txtCallbackComments.AcceptsReturn = true;
			txtCallbackComments.AllowDrop = true;
			txtCallbackComments.BackColor = System.Drawing.Color.White;
			txtCallbackComments.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtCallbackComments.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtCallbackComments.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtCallbackComments.ForeColor = System.Drawing.SystemColors.WindowText;
			txtCallbackComments.Location = new System.Drawing.Point(8, 80);
			txtCallbackComments.MaxLength = 250;
			txtCallbackComments.Multiline = true;
			txtCallbackComments.Name = "txtCallbackComments";
			txtCallbackComments.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtCallbackComments.Size = new System.Drawing.Size(254, 75);
			txtCallbackComments.TabIndex = 262;
			// 
			// cboCallBackStatus
			// 
			cboCallBackStatus.AllowDrop = true;
			cboCallBackStatus.BackColor = System.Drawing.SystemColors.Window;
			cboCallBackStatus.CausesValidation = true;
			cboCallBackStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboCallBackStatus.Enabled = true;
			cboCallBackStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cboCallBackStatus.ForeColor = System.Drawing.SystemColors.WindowText;
			cboCallBackStatus.IntegralHeight = true;
			cboCallBackStatus.Location = new System.Drawing.Point(85, 40);
			cboCallBackStatus.Name = "cboCallBackStatus";
			cboCallBackStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cboCallBackStatus.Size = new System.Drawing.Size(169, 21);
			cboCallBackStatus.Sorted = false;
			cboCallBackStatus.TabIndex = 260;
			cboCallBackStatus.TabStop = true;
			cboCallBackStatus.Visible = true;
			// 
			// txtCallBackDate
			// 
			txtCallBackDate.AcceptsReturn = true;
			txtCallBackDate.AllowDrop = true;
			txtCallBackDate.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txtCallBackDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtCallBackDate.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtCallBackDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtCallBackDate.ForeColor = System.Drawing.SystemColors.WindowText;
			txtCallBackDate.Location = new System.Drawing.Point(87, 16);
			txtCallBackDate.MaxLength = 0;
			txtCallBackDate.Name = "txtCallBackDate";
			txtCallBackDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtCallBackDate.Size = new System.Drawing.Size(82, 19);
			txtCallBackDate.TabIndex = 258;
			txtCallBackDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// calCallBackDate
			// 
			calCallBackDate.AllowDrop = true;
			calCallBackDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			calCallBackDate.ForeColor = System.Drawing.SystemColors.ControlText;
			calCallBackDate.Location = new System.Drawing.Point(280, 10);
			calCallBackDate.Name = "calCallBackDate";
			calCallBackDate.Size = new System.Drawing.Size(178, 154);
			calCallBackDate.TabIndex = 264;
			calCallBackDate.TabStop = false;
			calCallBackDate.Enter += new System.EventHandler(calCallBackDate_Enter);
			// 
			// _lblSubLabel_70
			// 
			_lblSubLabel_70.AllowDrop = true;
			_lblSubLabel_70.AutoSize = true;
			_lblSubLabel_70.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_70.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_70.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_70.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_70.Location = new System.Drawing.Point(8, 64);
			_lblSubLabel_70.MinimumSize = new System.Drawing.Size(49, 13);
			_lblSubLabel_70.Name = "_lblSubLabel_70";
			_lblSubLabel_70.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_70.Size = new System.Drawing.Size(49, 13);
			_lblSubLabel_70.TabIndex = 361;
			_lblSubLabel_70.Text = "Comments";
			_lblSubLabel_70.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_70.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// lblServerSideNotes
			// 
			lblServerSideNotes.AllowDrop = true;
			lblServerSideNotes.AutoSize = true;
			lblServerSideNotes.BackColor = System.Drawing.Color.Transparent;
			lblServerSideNotes.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblServerSideNotes.Enabled = false;
			lblServerSideNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblServerSideNotes.ForeColor = System.Drawing.Color.Blue;
			lblServerSideNotes.Location = new System.Drawing.Point(180, 18);
			lblServerSideNotes.MinimumSize = new System.Drawing.Size(88, 13);
			lblServerSideNotes.Name = "lblServerSideNotes";
			lblServerSideNotes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblServerSideNotes.Size = new System.Drawing.Size(88, 13);
			lblServerSideNotes.TabIndex = 141;
			lblServerSideNotes.Text = "View Server Notes";
			lblServerSideNotes.Visible = false;
			// 
			// _lblSubLabel_7
			// 
			_lblSubLabel_7.AllowDrop = true;
			_lblSubLabel_7.AutoSize = true;
			_lblSubLabel_7.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_7.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_7.Location = new System.Drawing.Point(8, 45);
			_lblSubLabel_7.MinimumSize = new System.Drawing.Size(74, 13);
			_lblSubLabel_7.Name = "_lblSubLabel_7";
			_lblSubLabel_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_7.Size = new System.Drawing.Size(74, 13);
			_lblSubLabel_7.TabIndex = 131;
			_lblSubLabel_7.Text = "Callback Status";
			_lblSubLabel_7.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_7.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// _lblSubLabel_6
			// 
			_lblSubLabel_6.AllowDrop = true;
			_lblSubLabel_6.AutoSize = true;
			_lblSubLabel_6.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_6.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_6.Location = new System.Drawing.Point(8, 19);
			_lblSubLabel_6.MinimumSize = new System.Drawing.Size(67, 13);
			_lblSubLabel_6.Name = "_lblSubLabel_6";
			_lblSubLabel_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_6.Size = new System.Drawing.Size(67, 13);
			_lblSubLabel_6.TabIndex = 130;
			_lblSubLabel_6.Text = "Callback Date";
			_lblSubLabel_6.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_6.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// frmStartEndDate
			// 
			frmStartEndDate.AllowDrop = true;
			frmStartEndDate.BackColor = System.Drawing.SystemColors.Control;
			frmStartEndDate.Controls.Add(cal_sub_start_date);
			frmStartEndDate.Controls.Add(cal_sub_end_date);
			frmStartEndDate.Controls.Add(lblEndDate);
			frmStartEndDate.Controls.Add(lblStartDate);
			frmStartEndDate.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmStartEndDate.Enabled = true;
			frmStartEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmStartEndDate.ForeColor = System.Drawing.SystemColors.ControlText;
			frmStartEndDate.Location = new System.Drawing.Point(6, 155);
			frmStartEndDate.Name = "frmStartEndDate";
			frmStartEndDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmStartEndDate.Size = new System.Drawing.Size(465, 153);
			frmStartEndDate.TabIndex = 126;
			frmStartEndDate.Visible = false;
			// 
			// cal_sub_start_date
			// 
			cal_sub_start_date.AllowDrop = true;
			cal_sub_start_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cal_sub_start_date.ForeColor = System.Drawing.SystemColors.ControlText;
			cal_sub_start_date.Location = new System.Drawing.Point(16, 8);
			cal_sub_start_date.Name = "cal_sub_start_date";
			cal_sub_start_date.Size = new System.Drawing.Size(178, 154);
			cal_sub_start_date.TabIndex = 127;
			cal_sub_start_date.TabStop = false;
			cal_sub_start_date.Enter += new System.EventHandler(cal_sub_start_date_Enter);
			// 
			// cal_sub_end_date
			// 
			cal_sub_end_date.AllowDrop = true;
			cal_sub_end_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cal_sub_end_date.ForeColor = System.Drawing.SystemColors.ControlText;
			cal_sub_end_date.Location = new System.Drawing.Point(288, 8);
			cal_sub_end_date.Name = "cal_sub_end_date";
			cal_sub_end_date.Size = new System.Drawing.Size(178, 154);
			cal_sub_end_date.TabIndex = 128;
			cal_sub_end_date.TabStop = false;
			cal_sub_end_date.Enter += new System.EventHandler(cal_sub_end_date_Enter);
			// 
			// lblEndDate
			// 
			lblEndDate.AllowDrop = true;
			lblEndDate.AutoSize = true;
			lblEndDate.BackColor = System.Drawing.Color.Transparent;
			lblEndDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblEndDate.ForeColor = System.Drawing.SystemColors.ControlText;
			lblEndDate.Location = new System.Drawing.Point(210, 132);
			lblEndDate.MinimumSize = new System.Drawing.Size(60, 13);
			lblEndDate.Name = "lblEndDate";
			lblEndDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblEndDate.Size = new System.Drawing.Size(60, 13);
			lblEndDate.TabIndex = 133;
			lblEndDate.Text = "End Date >>";
			// 
			// lblStartDate
			// 
			lblStartDate.AllowDrop = true;
			lblStartDate.AutoSize = true;
			lblStartDate.BackColor = System.Drawing.Color.Transparent;
			lblStartDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblStartDate.ForeColor = System.Drawing.SystemColors.ControlText;
			lblStartDate.Location = new System.Drawing.Point(196, 42);
			lblStartDate.MinimumSize = new System.Drawing.Size(63, 13);
			lblStartDate.Name = "lblStartDate";
			lblStartDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblStartDate.Size = new System.Drawing.Size(63, 13);
			lblStartDate.TabIndex = 132;
			lblStartDate.Text = "<< Start Date";
			// 
			// fra_Bottom
			// 
			fra_Bottom.AllowDrop = true;
			fra_Bottom.BackColor = System.Drawing.SystemColors.Control;
			fra_Bottom.Controls.Add(frm_Sub_Command);
			fra_Bottom.Controls.Add(fra_Add_Installation);
			fra_Bottom.Controls.Add(grd_Logins);
			fra_Bottom.Controls.Add(fraLogin);
			fra_Bottom.Controls.Add(frm_old_Invisible);
			fra_Bottom.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			fra_Bottom.Enabled = true;
			fra_Bottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			fra_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
			fra_Bottom.Location = new System.Drawing.Point(0, 348);
			fra_Bottom.Name = "fra_Bottom";
			fra_Bottom.RightToLeft = System.Windows.Forms.RightToLeft.No;
			fra_Bottom.Size = new System.Drawing.Size(945, 278);
			fra_Bottom.TabIndex = 52;
			fra_Bottom.Visible = true;
			// 
			// frm_Sub_Command
			// 
			frm_Sub_Command.AllowDrop = true;
			frm_Sub_Command.BackColor = System.Drawing.SystemColors.Control;
			frm_Sub_Command.Controls.Add(cmdUpload);
			frm_Sub_Command.Controls.Add(cmdUpdateCRMSite);
			frm_Sub_Command.Controls.Add(cmdNewLogin);
			frm_Sub_Command.Controls.Add(cmd_New_Installation);
			frm_Sub_Command.Controls.Add(cmd_Close);
			frm_Sub_Command.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frm_Sub_Command.Enabled = true;
			frm_Sub_Command.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frm_Sub_Command.ForeColor = System.Drawing.SystemColors.ControlText;
			frm_Sub_Command.Location = new System.Drawing.Point(0, 248);
			frm_Sub_Command.Name = "frm_Sub_Command";
			frm_Sub_Command.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frm_Sub_Command.Size = new System.Drawing.Size(916, 37);
			frm_Sub_Command.TabIndex = 63;
			frm_Sub_Command.Visible = true;
			// 
			// cmdUpload
			// 
			cmdUpload.AllowDrop = true;
			cmdUpload.BackColor = System.Drawing.SystemColors.Control;
			cmdUpload.Enabled = false;
			cmdUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdUpload.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdUpload.Location = new System.Drawing.Point(208, 10);
			cmdUpload.Name = "cmdUpload";
			cmdUpload.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdUpload.Size = new System.Drawing.Size(140, 27);
			cmdUpload.TabIndex = 137;
			cmdUpload.Text = "&Update Web Site";
			cmdUpload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdUpload.Visible = false;
			cmdUpload.Click += new System.EventHandler(cmdUpload_Click);
			cmdUpload.MouseUp += new System.Windows.Forms.MouseEventHandler(cmdUpload_MouseUp);
			// 
			// cmdUpdateCRMSite
			// 
			cmdUpdateCRMSite.AllowDrop = true;
			cmdUpdateCRMSite.BackColor = System.Drawing.SystemColors.Control;
			cmdUpdateCRMSite.Enabled = false;
			cmdUpdateCRMSite.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdUpdateCRMSite.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdUpdateCRMSite.Location = new System.Drawing.Point(390, 10);
			cmdUpdateCRMSite.Name = "cmdUpdateCRMSite";
			cmdUpdateCRMSite.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdUpdateCRMSite.Size = new System.Drawing.Size(140, 27);
			cmdUpdateCRMSite.TabIndex = 138;
			cmdUpdateCRMSite.Text = "Update C&RM Site";
			cmdUpdateCRMSite.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdUpdateCRMSite.Visible = false;
			cmdUpdateCRMSite.Click += new System.EventHandler(cmdUpdateCRMSite_Click);
			// 
			// cmdNewLogin
			// 
			cmdNewLogin.AllowDrop = true;
			cmdNewLogin.BackColor = System.Drawing.SystemColors.Control;
			cmdNewLogin.Enabled = false;
			cmdNewLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdNewLogin.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdNewLogin.Location = new System.Drawing.Point(36, 10);
			cmdNewLogin.Name = "cmdNewLogin";
			cmdNewLogin.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdNewLogin.Size = new System.Drawing.Size(140, 27);
			cmdNewLogin.TabIndex = 136;
			cmdNewLogin.Text = "New &Login";
			cmdNewLogin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdNewLogin.Click += new System.EventHandler(cmdNewLogin_Click);
			cmdNewLogin.MouseUp += new System.Windows.Forms.MouseEventHandler(cmdNewLogin_MouseUp);
			// 
			// cmd_New_Installation
			// 
			cmd_New_Installation.AllowDrop = true;
			cmd_New_Installation.BackColor = System.Drawing.SystemColors.Control;
			cmd_New_Installation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_New_Installation.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_New_Installation.Location = new System.Drawing.Point(562, 10);
			cmd_New_Installation.Name = "cmd_New_Installation";
			cmd_New_Installation.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_New_Installation.Size = new System.Drawing.Size(140, 27);
			cmd_New_Installation.TabIndex = 139;
			cmd_New_Installation.Text = "New &Installation";
			cmd_New_Installation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_New_Installation.UseVisualStyleBackColor = false;
			cmd_New_Installation.Click += new System.EventHandler(cmd_New_Installation_Click);
			cmd_New_Installation.MouseUp += new System.Windows.Forms.MouseEventHandler(cmd_New_Installation_MouseUp);
			// 
			// cmd_Close
			// 
			cmd_Close.AllowDrop = true;
			cmd_Close.BackColor = System.Drawing.SystemColors.Control;
			cmd_Close.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Close.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Close.Location = new System.Drawing.Point(738, 10);
			cmd_Close.Name = "cmd_Close";
			cmd_Close.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Close.Size = new System.Drawing.Size(140, 27);
			cmd_Close.TabIndex = 140;
			cmd_Close.Text = "&Close";
			cmd_Close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Close.UseVisualStyleBackColor = false;
			cmd_Close.Click += new System.EventHandler(cmd_Close_Click);
			cmd_Close.MouseUp += new System.Windows.Forms.MouseEventHandler(cmd_Close_MouseUp);
			// 
			// fra_Add_Installation
			// 
			fra_Add_Installation.AllowDrop = true;
			fra_Add_Installation.BackColor = System.Drawing.SystemColors.Control;
			fra_Add_Installation.Controls.Add(chkInstallAdministrator);
			fra_Add_Installation.Controls.Add(frmSMSTextMsg);
			fra_Add_Installation.Controls.Add(grd_Installations);
			fra_Add_Installation.Controls.Add(cmdSubInsValidate);
			fra_Add_Installation.Controls.Add(cmbSubInsContact);
			fra_Add_Installation.Controls.Add(txtSubDefaultAModId);
			fra_Add_Installation.Controls.Add(cmdDeleteInstallation);
			fra_Add_Installation.Controls.Add(cmdUpdateInstallation);
			fra_Add_Installation.Controls.Add(cmd_InstallCancel);
			fra_Add_Installation.Controls.Add(txt_SubInsContractAmount);
			fra_Add_Installation.Controls.Add(cmdClearInstallDate);
			fra_Add_Installation.Controls.Add(frmInstallFlags);
			fra_Add_Installation.Controls.Add(frmInstallASPLogs);
			fra_Add_Installation.Controls.Add(_lblSubLabel_8);
			fra_Add_Installation.Controls.Add(_lblSubLabel_31);
			fra_Add_Installation.Controls.Add(_InstallLinkLabel_2);
			fra_Add_Installation.Controls.Add(_InstallLinkLabel_1);
			fra_Add_Installation.Controls.Add(_InstallLinkLabel_0);
			fra_Add_Installation.Controls.Add(_lblSubLabel_14);
			fra_Add_Installation.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			fra_Add_Installation.Enabled = true;
			fra_Add_Installation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			fra_Add_Installation.ForeColor = System.Drawing.SystemColors.ControlText;
			fra_Add_Installation.Location = new System.Drawing.Point(464, 0);
			fra_Add_Installation.Name = "fra_Add_Installation";
			fra_Add_Installation.RightToLeft = System.Windows.Forms.RightToLeft.No;
			fra_Add_Installation.Size = new System.Drawing.Size(459, 235);
			fra_Add_Installation.TabIndex = 58;
			fra_Add_Installation.Text = "Installation";
			fra_Add_Installation.Visible = true;
			// 
			// chkInstallAdministrator
			// 
			chkInstallAdministrator.AllowDrop = true;
			chkInstallAdministrator.Appearance = System.Windows.Forms.Appearance.Normal;
			chkInstallAdministrator.BackColor = System.Drawing.SystemColors.Control;
			chkInstallAdministrator.CausesValidation = true;
			chkInstallAdministrator.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkInstallAdministrator.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkInstallAdministrator.Enabled = true;
			chkInstallAdministrator.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkInstallAdministrator.ForeColor = System.Drawing.Color.Red;
			chkInstallAdministrator.Location = new System.Drawing.Point(8, 40);
			chkInstallAdministrator.Name = "chkInstallAdministrator";
			chkInstallAdministrator.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkInstallAdministrator.Size = new System.Drawing.Size(80, 13);
			chkInstallAdministrator.TabIndex = 331;
			chkInstallAdministrator.TabStop = true;
			chkInstallAdministrator.Text = "Administrator";
			chkInstallAdministrator.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkInstallAdministrator.Visible = true;
			chkInstallAdministrator.CheckStateChanged += new System.EventHandler(chkInstallAdministrator_CheckStateChanged);
			// 
			// frmSMSTextMsg
			// 
			frmSMSTextMsg.AllowDrop = true;
			frmSMSTextMsg.BackColor = System.Drawing.SystemColors.Control;
			frmSMSTextMsg.Controls.Add(txtCellNumber);
			frmSMSTextMsg.Controls.Add(cboCellCarrier);
			frmSMSTextMsg.Controls.Add(txtTextMsgModels);
			frmSMSTextMsg.Controls.Add(txtMobileActiveDate);
			frmSMSTextMsg.Controls.Add(txtSMSTextActiveFlag);
			frmSMSTextMsg.Controls.Add(txtSMSEvents);
			frmSMSTextMsg.Controls.Add(chkInstallEvoMobile);
			frmSMSTextMsg.Controls.Add(cmdInstallValidateSMSTxtMsg);
			frmSMSTextMsg.Controls.Add(lblSendTxtMsg);
			frmSMSTextMsg.Controls.Add(_lblSubLabel_16);
			frmSMSTextMsg.Controls.Add(_lblSubLabel_17);
			frmSMSTextMsg.Controls.Add(_lblSubLabel_18);
			frmSMSTextMsg.Controls.Add(_lblSubLabel_19);
			frmSMSTextMsg.Controls.Add(_lblSubLabel_20);
			frmSMSTextMsg.Controls.Add(_lblSubLabel_21);
			frmSMSTextMsg.Controls.Add(lblSendTextMsgEvoMobileLink);
			frmSMSTextMsg.Controls.Add(lblSendTextMsgOK);
			frmSMSTextMsg.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmSMSTextMsg.Enabled = true;
			frmSMSTextMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmSMSTextMsg.ForeColor = System.Drawing.SystemColors.ControlText;
			frmSMSTextMsg.Location = new System.Drawing.Point(208, 32);
			frmSMSTextMsg.Name = "frmSMSTextMsg";
			frmSMSTextMsg.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmSMSTextMsg.Size = new System.Drawing.Size(242, 161);
			frmSMSTextMsg.TabIndex = 144;
			frmSMSTextMsg.Text = "SMS Text Messaging";
			frmSMSTextMsg.Visible = false;
			// 
			// txtCellNumber
			// 
			txtCellNumber.AcceptsReturn = true;
			txtCellNumber.AllowDrop = true;
			txtCellNumber.BackColor = System.Drawing.Color.White;
			txtCellNumber.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtCellNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtCellNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtCellNumber.ForeColor = System.Drawing.SystemColors.WindowText;
			txtCellNumber.Location = new System.Drawing.Point(72, 8);
			txtCellNumber.MaxLength = 500;
			txtCellNumber.Name = "txtCellNumber";
			txtCellNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtCellNumber.Size = new System.Drawing.Size(109, 19);
			txtCellNumber.TabIndex = 152;
			// 
			// cboCellCarrier
			// 
			cboCellCarrier.AllowDrop = true;
			cboCellCarrier.BackColor = System.Drawing.SystemColors.Window;
			cboCellCarrier.CausesValidation = true;
			cboCellCarrier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboCellCarrier.Enabled = true;
			cboCellCarrier.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cboCellCarrier.ForeColor = System.Drawing.SystemColors.WindowText;
			cboCellCarrier.IntegralHeight = true;
			cboCellCarrier.Location = new System.Drawing.Point(71, 32);
			cboCellCarrier.Name = "cboCellCarrier";
			cboCellCarrier.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cboCellCarrier.Size = new System.Drawing.Size(144, 21);
			cboCellCarrier.Sorted = false;
			cboCellCarrier.TabIndex = 151;
			cboCellCarrier.TabStop = true;
			cboCellCarrier.Visible = true;
			// 
			// txtTextMsgModels
			// 
			txtTextMsgModels.AcceptsReturn = true;
			txtTextMsgModels.AllowDrop = true;
			txtTextMsgModels.BackColor = System.Drawing.Color.White;
			txtTextMsgModels.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtTextMsgModels.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtTextMsgModels.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtTextMsgModels.ForeColor = System.Drawing.SystemColors.WindowText;
			txtTextMsgModels.Location = new System.Drawing.Point(72, 56);
			txtTextMsgModels.MaxLength = 500;
			txtTextMsgModels.Name = "txtTextMsgModels";
			txtTextMsgModels.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtTextMsgModels.Size = new System.Drawing.Size(141, 19);
			txtTextMsgModels.TabIndex = 150;
			// 
			// txtMobileActiveDate
			// 
			txtMobileActiveDate.AcceptsReturn = true;
			txtMobileActiveDate.AllowDrop = true;
			txtMobileActiveDate.BackColor = System.Drawing.Color.White;
			txtMobileActiveDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtMobileActiveDate.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtMobileActiveDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtMobileActiveDate.ForeColor = System.Drawing.SystemColors.WindowText;
			txtMobileActiveDate.Location = new System.Drawing.Point(71, 77);
			txtMobileActiveDate.MaxLength = 500;
			txtMobileActiveDate.Name = "txtMobileActiveDate";
			txtMobileActiveDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtMobileActiveDate.Size = new System.Drawing.Size(123, 19);
			txtMobileActiveDate.TabIndex = 149;
			// 
			// txtSMSTextActiveFlag
			// 
			txtSMSTextActiveFlag.AcceptsReturn = true;
			txtSMSTextActiveFlag.AllowDrop = true;
			txtSMSTextActiveFlag.BackColor = System.Drawing.Color.White;
			txtSMSTextActiveFlag.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtSMSTextActiveFlag.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtSMSTextActiveFlag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtSMSTextActiveFlag.ForeColor = System.Drawing.SystemColors.WindowText;
			txtSMSTextActiveFlag.Location = new System.Drawing.Point(72, 98);
			txtSMSTextActiveFlag.MaxLength = 10;
			txtSMSTextActiveFlag.Name = "txtSMSTextActiveFlag";
			txtSMSTextActiveFlag.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtSMSTextActiveFlag.Size = new System.Drawing.Size(42, 19);
			txtSMSTextActiveFlag.TabIndex = 148;
			txtSMSTextActiveFlag.Text = "No";
			// 
			// txtSMSEvents
			// 
			txtSMSEvents.AcceptsReturn = true;
			txtSMSEvents.AllowDrop = true;
			txtSMSEvents.BackColor = System.Drawing.Color.White;
			txtSMSEvents.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtSMSEvents.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtSMSEvents.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtSMSEvents.ForeColor = System.Drawing.SystemColors.WindowText;
			txtSMSEvents.Location = new System.Drawing.Point(71, 120);
			txtSMSEvents.MaxLength = 500;
			txtSMSEvents.Name = "txtSMSEvents";
			txtSMSEvents.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtSMSEvents.Size = new System.Drawing.Size(86, 19);
			txtSMSEvents.TabIndex = 147;
			txtSMSEvents.Text = "MA";
			// 
			// chkInstallEvoMobile
			// 
			chkInstallEvoMobile.AllowDrop = true;
			chkInstallEvoMobile.Appearance = System.Windows.Forms.Appearance.Normal;
			chkInstallEvoMobile.BackColor = System.Drawing.SystemColors.Control;
			chkInstallEvoMobile.CausesValidation = true;
			chkInstallEvoMobile.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkInstallEvoMobile.CheckState = System.Windows.Forms.CheckState.Checked;
			chkInstallEvoMobile.Enabled = true;
			chkInstallEvoMobile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkInstallEvoMobile.ForeColor = System.Drawing.SystemColors.ControlText;
			chkInstallEvoMobile.Location = new System.Drawing.Point(160, 120);
			chkInstallEvoMobile.Name = "chkInstallEvoMobile";
			chkInstallEvoMobile.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkInstallEvoMobile.Size = new System.Drawing.Size(78, 13);
			chkInstallEvoMobile.TabIndex = 146;
			chkInstallEvoMobile.TabStop = true;
			chkInstallEvoMobile.Text = "Evo-Mobile";
			chkInstallEvoMobile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkInstallEvoMobile.Visible = true;
			// 
			// cmdInstallValidateSMSTxtMsg
			// 
			cmdInstallValidateSMSTxtMsg.AllowDrop = true;
			cmdInstallValidateSMSTxtMsg.BackColor = System.Drawing.SystemColors.Control;
			cmdInstallValidateSMSTxtMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdInstallValidateSMSTxtMsg.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdInstallValidateSMSTxtMsg.Location = new System.Drawing.Point(120, 98);
			cmdInstallValidateSMSTxtMsg.Name = "cmdInstallValidateSMSTxtMsg";
			cmdInstallValidateSMSTxtMsg.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdInstallValidateSMSTxtMsg.Size = new System.Drawing.Size(96, 19);
			cmdInstallValidateSMSTxtMsg.TabIndex = 145;
			cmdInstallValidateSMSTxtMsg.Text = "Validate SMS Text";
			cmdInstallValidateSMSTxtMsg.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdInstallValidateSMSTxtMsg.UseVisualStyleBackColor = false;
			cmdInstallValidateSMSTxtMsg.Click += new System.EventHandler(cmdInstallValidateSMSTxtMsg_Click);
			// 
			// lblSendTxtMsg
			// 
			lblSendTxtMsg.AllowDrop = true;
			lblSendTxtMsg.AutoSize = true;
			lblSendTxtMsg.BackColor = System.Drawing.Color.Transparent;
			lblSendTxtMsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblSendTxtMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblSendTxtMsg.ForeColor = System.Drawing.SystemColors.ControlText;
			lblSendTxtMsg.Location = new System.Drawing.Point(8, 144);
			lblSendTxtMsg.MinimumSize = new System.Drawing.Size(75, 13);
			lblSendTxtMsg.Name = "lblSendTxtMsg";
			lblSendTxtMsg.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblSendTxtMsg.Size = new System.Drawing.Size(75, 13);
			lblSendTxtMsg.TabIndex = 220;
			lblSendTxtMsg.Text = "Send Text Msg:";
			// 
			// _lblSubLabel_16
			// 
			_lblSubLabel_16.AllowDrop = true;
			_lblSubLabel_16.AutoSize = true;
			_lblSubLabel_16.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_16.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_16.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_16.Location = new System.Drawing.Point(8, 16);
			_lblSubLabel_16.MinimumSize = new System.Drawing.Size(57, 13);
			_lblSubLabel_16.Name = "_lblSubLabel_16";
			_lblSubLabel_16.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_16.Size = new System.Drawing.Size(57, 13);
			_lblSubLabel_16.TabIndex = 160;
			_lblSubLabel_16.Text = "Cell Number";
			_lblSubLabel_16.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_16.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// _lblSubLabel_17
			// 
			_lblSubLabel_17.AllowDrop = true;
			_lblSubLabel_17.AutoSize = true;
			_lblSubLabel_17.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_17.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_17.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_17.Location = new System.Drawing.Point(6, 36);
			_lblSubLabel_17.MinimumSize = new System.Drawing.Size(30, 13);
			_lblSubLabel_17.Name = "_lblSubLabel_17";
			_lblSubLabel_17.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_17.Size = new System.Drawing.Size(30, 13);
			_lblSubLabel_17.TabIndex = 159;
			_lblSubLabel_17.Text = "Carrier";
			_lblSubLabel_17.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_17.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// _lblSubLabel_18
			// 
			_lblSubLabel_18.AllowDrop = true;
			_lblSubLabel_18.AutoSize = true;
			_lblSubLabel_18.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_18.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_18.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_18.Location = new System.Drawing.Point(6, 59);
			_lblSubLabel_18.MinimumSize = new System.Drawing.Size(34, 13);
			_lblSubLabel_18.Name = "_lblSubLabel_18";
			_lblSubLabel_18.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_18.Size = new System.Drawing.Size(34, 13);
			_lblSubLabel_18.TabIndex = 158;
			_lblSubLabel_18.Text = "Models";
			_lblSubLabel_18.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_18.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// _lblSubLabel_19
			// 
			_lblSubLabel_19.AllowDrop = true;
			_lblSubLabel_19.AutoSize = true;
			_lblSubLabel_19.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_19.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_19.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_19.Location = new System.Drawing.Point(6, 80);
			_lblSubLabel_19.MinimumSize = new System.Drawing.Size(56, 13);
			_lblSubLabel_19.Name = "_lblSubLabel_19";
			_lblSubLabel_19.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_19.Size = new System.Drawing.Size(56, 13);
			_lblSubLabel_19.TabIndex = 157;
			_lblSubLabel_19.Text = "Active Date";
			_lblSubLabel_19.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_19.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// _lblSubLabel_20
			// 
			_lblSubLabel_20.AllowDrop = true;
			_lblSubLabel_20.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_20.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_20.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_20.Location = new System.Drawing.Point(6, 104);
			_lblSubLabel_20.MinimumSize = new System.Drawing.Size(60, 16);
			_lblSubLabel_20.Name = "_lblSubLabel_20";
			_lblSubLabel_20.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_20.Size = new System.Drawing.Size(60, 16);
			_lblSubLabel_20.TabIndex = 156;
			_lblSubLabel_20.Text = "Active";
			_lblSubLabel_20.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_20.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// _lblSubLabel_21
			// 
			_lblSubLabel_21.AllowDrop = true;
			_lblSubLabel_21.AutoSize = true;
			_lblSubLabel_21.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_21.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_21.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_21.Location = new System.Drawing.Point(6, 125);
			_lblSubLabel_21.MinimumSize = new System.Drawing.Size(33, 13);
			_lblSubLabel_21.Name = "_lblSubLabel_21";
			_lblSubLabel_21.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_21.Size = new System.Drawing.Size(33, 13);
			_lblSubLabel_21.TabIndex = 155;
			_lblSubLabel_21.Text = "Events";
			_lblSubLabel_21.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_21.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// lblSendTextMsgEvoMobileLink
			// 
			lblSendTextMsgEvoMobileLink.AllowDrop = true;
			lblSendTextMsgEvoMobileLink.AutoSize = true;
			lblSendTextMsgEvoMobileLink.BackColor = System.Drawing.Color.Transparent;
			lblSendTextMsgEvoMobileLink.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblSendTextMsgEvoMobileLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblSendTextMsgEvoMobileLink.ForeColor = System.Drawing.Color.Blue;
			lblSendTextMsgEvoMobileLink.Location = new System.Drawing.Point(160, 144);
			lblSendTextMsgEvoMobileLink.MinimumSize = new System.Drawing.Size(76, 13);
			lblSendTextMsgEvoMobileLink.Name = "lblSendTextMsgEvoMobileLink";
			lblSendTextMsgEvoMobileLink.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblSendTextMsgEvoMobileLink.Size = new System.Drawing.Size(76, 13);
			lblSendTextMsgEvoMobileLink.TabIndex = 154;
			lblSendTextMsgEvoMobileLink.Text = "Evo Mobile Link";
			lblSendTextMsgEvoMobileLink.Click += new System.EventHandler(lblSendTextMsgEvoMobileLink_Click);
			// 
			// lblSendTextMsgOK
			// 
			lblSendTextMsgOK.AllowDrop = true;
			lblSendTextMsgOK.AutoSize = true;
			lblSendTextMsgOK.BackColor = System.Drawing.Color.Transparent;
			lblSendTextMsgOK.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblSendTextMsgOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblSendTextMsgOK.ForeColor = System.Drawing.Color.Blue;
			lblSendTextMsgOK.Location = new System.Drawing.Point(88, 144);
			lblSendTextMsgOK.MinimumSize = new System.Drawing.Size(68, 13);
			lblSendTextMsgOK.Name = "lblSendTextMsgOK";
			lblSendTextMsgOK.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblSendTextMsgOK.Size = new System.Drawing.Size(68, 13);
			lblSendTextMsgOK.TabIndex = 153;
			lblSendTextMsgOK.Text = "User Send OK";
			lblSendTextMsgOK.Click += new System.EventHandler(lblSendTextMsgOK_Click);
			// 
			// grd_Installations
			// 
			grd_Installations.AllowDrop = true;
			grd_Installations.AllowUserToAddRows = false;
			grd_Installations.AllowUserToDeleteRows = false;
			grd_Installations.AllowUserToResizeColumns = false;
			grd_Installations.AllowUserToResizeColumns = grd_Installations.ColumnHeadersVisible;
			grd_Installations.AllowUserToResizeRows = false;
			grd_Installations.AllowUserToResizeRows = grd_Installations.RowHeadersVisible;
			grd_Installations.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grd_Installations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_Installations.ColumnsCount = 2;
			grd_Installations.FixedColumns = 1;
			grd_Installations.FixedRows = 1;
			grd_Installations.FocusRect = UpgradeHelpers.FocusRectSettings.FocusNone;
			grd_Installations.Location = new System.Drawing.Point(216, 8);
			grd_Installations.Name = "grd_Installations";
			grd_Installations.ReadOnly = true;
			grd_Installations.RowsCount = 2;
			grd_Installations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grd_Installations.ShowCellToolTips = false;
			grd_Installations.Size = new System.Drawing.Size(242, 50);
			grd_Installations.StandardTab = true;
			grd_Installations.TabIndex = 309;
			grd_Installations.DoubleClick += new System.EventHandler(grd_Installations_DoubleClick);
			// 
			// cmdSubInsValidate
			// 
			cmdSubInsValidate.AllowDrop = true;
			cmdSubInsValidate.BackColor = System.Drawing.SystemColors.Control;
			cmdSubInsValidate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdSubInsValidate.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdSubInsValidate.Location = new System.Drawing.Point(256, 56);
			cmdSubInsValidate.Name = "cmdSubInsValidate";
			cmdSubInsValidate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdSubInsValidate.Size = new System.Drawing.Size(76, 21);
			cmdSubInsValidate.TabIndex = 16;
			cmdSubInsValidate.Text = "Validate Install";
			cmdSubInsValidate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdSubInsValidate.UseVisualStyleBackColor = false;
			cmdSubInsValidate.Visible = false;
			cmdSubInsValidate.Click += new System.EventHandler(cmdSubInsValidate_Click);
			// 
			// cmbSubInsContact
			// 
			cmbSubInsContact.AllowDrop = true;
			cmbSubInsContact.BackColor = System.Drawing.SystemColors.Window;
			cmbSubInsContact.CausesValidation = true;
			cmbSubInsContact.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cmbSubInsContact.Enabled = true;
			cmbSubInsContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmbSubInsContact.ForeColor = System.Drawing.SystemColors.WindowText;
			cmbSubInsContact.IntegralHeight = true;
			cmbSubInsContact.Location = new System.Drawing.Point(56, 16);
			cmbSubInsContact.Name = "cmbSubInsContact";
			cmbSubInsContact.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmbSubInsContact.Size = new System.Drawing.Size(161, 21);
			cmbSubInsContact.Sorted = false;
			cmbSubInsContact.TabIndex = 15;
			cmbSubInsContact.TabStop = true;
			cmbSubInsContact.Visible = true;
			// 
			// txtSubDefaultAModId
			// 
			txtSubDefaultAModId.AcceptsReturn = true;
			txtSubDefaultAModId.AllowDrop = true;
			txtSubDefaultAModId.BackColor = System.Drawing.Color.White;
			txtSubDefaultAModId.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtSubDefaultAModId.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtSubDefaultAModId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtSubDefaultAModId.ForeColor = System.Drawing.SystemColors.WindowText;
			txtSubDefaultAModId.Location = new System.Drawing.Point(595, 18);
			txtSubDefaultAModId.MaxLength = 4;
			txtSubDefaultAModId.Name = "txtSubDefaultAModId";
			txtSubDefaultAModId.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtSubDefaultAModId.Size = new System.Drawing.Size(33, 19);
			txtSubDefaultAModId.TabIndex = 17;
			txtSubDefaultAModId.Text = "30";
			// 
			// cmdDeleteInstallation
			// 
			cmdDeleteInstallation.AllowDrop = true;
			cmdDeleteInstallation.BackColor = System.Drawing.SystemColors.Control;
			cmdDeleteInstallation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdDeleteInstallation.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdDeleteInstallation.Location = new System.Drawing.Point(120, 210);
			cmdDeleteInstallation.Name = "cmdDeleteInstallation";
			cmdDeleteInstallation.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdDeleteInstallation.Size = new System.Drawing.Size(91, 21);
			cmdDeleteInstallation.TabIndex = 23;
			cmdDeleteInstallation.Text = "Delete";
			cmdDeleteInstallation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdDeleteInstallation.UseVisualStyleBackColor = false;
			cmdDeleteInstallation.Click += new System.EventHandler(cmdDeleteInstallation_Click);
			cmdDeleteInstallation.MouseUp += new System.Windows.Forms.MouseEventHandler(cmdDeleteInstallation_MouseUp);
			// 
			// cmdUpdateInstallation
			// 
			cmdUpdateInstallation.AllowDrop = true;
			cmdUpdateInstallation.BackColor = System.Drawing.SystemColors.Control;
			cmdUpdateInstallation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdUpdateInstallation.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdUpdateInstallation.Location = new System.Drawing.Point(16, 210);
			cmdUpdateInstallation.Name = "cmdUpdateInstallation";
			cmdUpdateInstallation.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdUpdateInstallation.Size = new System.Drawing.Size(91, 21);
			cmdUpdateInstallation.TabIndex = 22;
			cmdUpdateInstallation.Text = "&Save";
			cmdUpdateInstallation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdUpdateInstallation.UseVisualStyleBackColor = false;
			cmdUpdateInstallation.Click += new System.EventHandler(cmdUpdateInstallation_Click);
			cmdUpdateInstallation.MouseUp += new System.Windows.Forms.MouseEventHandler(cmdUpdateInstallation_MouseUp);
			// 
			// cmd_InstallCancel
			// 
			cmd_InstallCancel.AllowDrop = true;
			cmd_InstallCancel.BackColor = System.Drawing.SystemColors.Control;
			cmd_InstallCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_InstallCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_InstallCancel.Location = new System.Drawing.Point(219, 210);
			cmd_InstallCancel.Name = "cmd_InstallCancel";
			cmd_InstallCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_InstallCancel.Size = new System.Drawing.Size(91, 21);
			cmd_InstallCancel.TabIndex = 24;
			cmd_InstallCancel.Text = "Cancel";
			cmd_InstallCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_InstallCancel.UseVisualStyleBackColor = false;
			cmd_InstallCancel.Click += new System.EventHandler(cmd_InstallCancel_Click);
			// 
			// txt_SubInsContractAmount
			// 
			txt_SubInsContractAmount.AcceptsReturn = true;
			txt_SubInsContractAmount.AllowDrop = true;
			txt_SubInsContractAmount.BackColor = System.Drawing.Color.White;
			txt_SubInsContractAmount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_SubInsContractAmount.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_SubInsContractAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_SubInsContractAmount.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_SubInsContractAmount.Location = new System.Drawing.Point(120, 56);
			txt_SubInsContractAmount.MaxLength = 10;
			txt_SubInsContractAmount.Name = "txt_SubInsContractAmount";
			txt_SubInsContractAmount.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_SubInsContractAmount.Size = new System.Drawing.Size(54, 19);
			txt_SubInsContractAmount.TabIndex = 14;
			txt_SubInsContractAmount.Text = "0.00";
			txt_SubInsContractAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txt_SubInsContractAmount.Visible = false;
			// 
			// cmdClearInstallDate
			// 
			cmdClearInstallDate.AllowDrop = true;
			cmdClearInstallDate.BackColor = System.Drawing.SystemColors.Control;
			cmdClearInstallDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdClearInstallDate.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdClearInstallDate.Location = new System.Drawing.Point(320, 210);
			cmdClearInstallDate.Name = "cmdClearInstallDate";
			cmdClearInstallDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdClearInstallDate.Size = new System.Drawing.Size(133, 21);
			cmdClearInstallDate.TabIndex = 25;
			cmdClearInstallDate.Text = "&Clear Install Date";
			cmdClearInstallDate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdClearInstallDate.UseVisualStyleBackColor = false;
			cmdClearInstallDate.Click += new System.EventHandler(cmdClearInstallDate_Click);
			cmdClearInstallDate.MouseUp += new System.Windows.Forms.MouseEventHandler(cmdClearInstallDate_MouseUp);
			// 
			// frmInstallFlags
			// 
			frmInstallFlags.AllowDrop = true;
			frmInstallFlags.BackColor = System.Drawing.SystemColors.Control;
			frmInstallFlags.Controls.Add(txt_Platform_OS);
			frmInstallFlags.Controls.Add(txtReplyName);
			frmInstallFlags.Controls.Add(txtReplyEMail);
			frmInstallFlags.Controls.Add(txtSubInsNbrRecPerPage);
			frmInstallFlags.Controls.Add(txtSubInsDefaultAnalysisMths);
			frmInstallFlags.Controls.Add(cmbSubInsBGImageId);
			frmInstallFlags.Controls.Add(chkDefaultHTMLEMail);
			frmInstallFlags.Controls.Add(chkInstallationDisplayNoteTag);
			frmInstallFlags.Controls.Add(_lblSubLabel_69);
			frmInstallFlags.Controls.Add(_lblSubLabel_66);
			frmInstallFlags.Controls.Add(lblSubDefaultAModId);
			frmInstallFlags.Controls.Add(_lblSubLabel_10);
			frmInstallFlags.Controls.Add(_lblSubLabel_12);
			frmInstallFlags.Controls.Add(_lblSubLabel_13);
			frmInstallFlags.Controls.Add(_lblSubLabel_1);
			frmInstallFlags.Controls.Add(_lblSubLabel_55);
			frmInstallFlags.Controls.Add(_lblSubLabel_22);
			frmInstallFlags.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmInstallFlags.Enabled = true;
			frmInstallFlags.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmInstallFlags.ForeColor = System.Drawing.SystemColors.ControlText;
			frmInstallFlags.Location = new System.Drawing.Point(8, 72);
			frmInstallFlags.Name = "frmInstallFlags";
			frmInstallFlags.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmInstallFlags.Size = new System.Drawing.Size(437, 108);
			frmInstallFlags.TabIndex = 21;
			frmInstallFlags.Text = "User Settings";
			frmInstallFlags.Visible = true;
			// 
			// txt_Platform_OS
			// 
			txt_Platform_OS.AcceptsReturn = true;
			txt_Platform_OS.AllowDrop = true;
			txt_Platform_OS.BackColor = System.Drawing.Color.White;
			txt_Platform_OS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_Platform_OS.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_Platform_OS.Enabled = false;
			txt_Platform_OS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_Platform_OS.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_Platform_OS.Location = new System.Drawing.Point(80, 32);
			txt_Platform_OS.MaxLength = 50;
			txt_Platform_OS.Name = "txt_Platform_OS";
			txt_Platform_OS.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_Platform_OS.Size = new System.Drawing.Size(141, 19);
			txt_Platform_OS.TabIndex = 344;
			// 
			// txtReplyName
			// 
			txtReplyName.AcceptsReturn = true;
			txtReplyName.AllowDrop = true;
			txtReplyName.BackColor = System.Drawing.Color.White;
			txtReplyName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtReplyName.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtReplyName.Enabled = false;
			txtReplyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtReplyName.ForeColor = System.Drawing.SystemColors.WindowText;
			txtReplyName.Location = new System.Drawing.Point(80, 80);
			txtReplyName.MaxLength = 100;
			txtReplyName.Name = "txtReplyName";
			txtReplyName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtReplyName.Size = new System.Drawing.Size(129, 19);
			txtReplyName.TabIndex = 337;
			// 
			// txtReplyEMail
			// 
			txtReplyEMail.AcceptsReturn = true;
			txtReplyEMail.AllowDrop = true;
			txtReplyEMail.BackColor = System.Drawing.Color.White;
			txtReplyEMail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtReplyEMail.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtReplyEMail.Enabled = false;
			txtReplyEMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtReplyEMail.ForeColor = System.Drawing.SystemColors.WindowText;
			txtReplyEMail.Location = new System.Drawing.Point(266, 80);
			txtReplyEMail.MaxLength = 500;
			txtReplyEMail.Name = "txtReplyEMail";
			txtReplyEMail.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtReplyEMail.Size = new System.Drawing.Size(155, 19);
			txtReplyEMail.TabIndex = 336;
			// 
			// txtSubInsNbrRecPerPage
			// 
			txtSubInsNbrRecPerPage.AcceptsReturn = true;
			txtSubInsNbrRecPerPage.AllowDrop = true;
			txtSubInsNbrRecPerPage.BackColor = System.Drawing.Color.White;
			txtSubInsNbrRecPerPage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtSubInsNbrRecPerPage.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtSubInsNbrRecPerPage.Enabled = false;
			txtSubInsNbrRecPerPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtSubInsNbrRecPerPage.ForeColor = System.Drawing.SystemColors.WindowText;
			txtSubInsNbrRecPerPage.Location = new System.Drawing.Point(288, 32);
			txtSubInsNbrRecPerPage.MaxLength = 10;
			txtSubInsNbrRecPerPage.Name = "txtSubInsNbrRecPerPage";
			txtSubInsNbrRecPerPage.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtSubInsNbrRecPerPage.Size = new System.Drawing.Size(30, 19);
			txtSubInsNbrRecPerPage.TabIndex = 333;
			txtSubInsNbrRecPerPage.Text = "10";
			txtSubInsNbrRecPerPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtSubInsDefaultAnalysisMths
			// 
			txtSubInsDefaultAnalysisMths.AcceptsReturn = true;
			txtSubInsDefaultAnalysisMths.AllowDrop = true;
			txtSubInsDefaultAnalysisMths.BackColor = System.Drawing.Color.White;
			txtSubInsDefaultAnalysisMths.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtSubInsDefaultAnalysisMths.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtSubInsDefaultAnalysisMths.Enabled = false;
			txtSubInsDefaultAnalysisMths.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtSubInsDefaultAnalysisMths.ForeColor = System.Drawing.SystemColors.WindowText;
			txtSubInsDefaultAnalysisMths.Location = new System.Drawing.Point(399, 32);
			txtSubInsDefaultAnalysisMths.MaxLength = 3;
			txtSubInsDefaultAnalysisMths.Name = "txtSubInsDefaultAnalysisMths";
			txtSubInsDefaultAnalysisMths.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtSubInsDefaultAnalysisMths.Size = new System.Drawing.Size(30, 19);
			txtSubInsDefaultAnalysisMths.TabIndex = 332;
			txtSubInsDefaultAnalysisMths.Text = "6";
			txtSubInsDefaultAnalysisMths.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// cmbSubInsBGImageId
			// 
			cmbSubInsBGImageId.AllowDrop = true;
			cmbSubInsBGImageId.BackColor = System.Drawing.SystemColors.Window;
			cmbSubInsBGImageId.CausesValidation = true;
			cmbSubInsBGImageId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cmbSubInsBGImageId.Enabled = false;
			cmbSubInsBGImageId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmbSubInsBGImageId.ForeColor = System.Drawing.SystemColors.WindowText;
			cmbSubInsBGImageId.IntegralHeight = true;
			cmbSubInsBGImageId.Location = new System.Drawing.Point(80, 56);
			cmbSubInsBGImageId.Name = "cmbSubInsBGImageId";
			cmbSubInsBGImageId.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmbSubInsBGImageId.Size = new System.Drawing.Size(110, 21);
			cmbSubInsBGImageId.Sorted = false;
			cmbSubInsBGImageId.TabIndex = 20;
			cmbSubInsBGImageId.TabStop = true;
			cmbSubInsBGImageId.Visible = true;
			// 
			// chkDefaultHTMLEMail
			// 
			chkDefaultHTMLEMail.AllowDrop = true;
			chkDefaultHTMLEMail.Appearance = System.Windows.Forms.Appearance.Normal;
			chkDefaultHTMLEMail.BackColor = System.Drawing.SystemColors.Control;
			chkDefaultHTMLEMail.CausesValidation = true;
			chkDefaultHTMLEMail.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkDefaultHTMLEMail.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkDefaultHTMLEMail.Enabled = false;
			chkDefaultHTMLEMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkDefaultHTMLEMail.ForeColor = System.Drawing.SystemColors.ControlText;
			chkDefaultHTMLEMail.Location = new System.Drawing.Point(112, 15);
			chkDefaultHTMLEMail.Name = "chkDefaultHTMLEMail";
			chkDefaultHTMLEMail.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkDefaultHTMLEMail.Size = new System.Drawing.Size(109, 13);
			chkDefaultHTMLEMail.TabIndex = 18;
			chkDefaultHTMLEMail.TabStop = true;
			chkDefaultHTMLEMail.Text = "Def. HTML EMail";
			chkDefaultHTMLEMail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkDefaultHTMLEMail.Visible = true;
			// 
			// chkInstallationDisplayNoteTag
			// 
			chkInstallationDisplayNoteTag.AllowDrop = true;
			chkInstallationDisplayNoteTag.Appearance = System.Windows.Forms.Appearance.Normal;
			chkInstallationDisplayNoteTag.BackColor = System.Drawing.SystemColors.Control;
			chkInstallationDisplayNoteTag.CausesValidation = true;
			chkInstallationDisplayNoteTag.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkInstallationDisplayNoteTag.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkInstallationDisplayNoteTag.Enabled = false;
			chkInstallationDisplayNoteTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkInstallationDisplayNoteTag.ForeColor = System.Drawing.SystemColors.ControlText;
			chkInstallationDisplayNoteTag.Location = new System.Drawing.Point(14, 15);
			chkInstallationDisplayNoteTag.Name = "chkInstallationDisplayNoteTag";
			chkInstallationDisplayNoteTag.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkInstallationDisplayNoteTag.Size = new System.Drawing.Size(77, 13);
			chkInstallationDisplayNoteTag.TabIndex = 19;
			chkInstallationDisplayNoteTag.TabStop = true;
			chkInstallationDisplayNoteTag.Text = "Display Tag";
			chkInstallationDisplayNoteTag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkInstallationDisplayNoteTag.Visible = true;
			// 
			// _lblSubLabel_69
			// 
			_lblSubLabel_69.AllowDrop = true;
			_lblSubLabel_69.AutoSize = true;
			_lblSubLabel_69.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_69.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_69.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_69.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_69.Location = new System.Drawing.Point(304, 56);
			_lblSubLabel_69.MinimumSize = new System.Drawing.Size(77, 13);
			_lblSubLabel_69.Name = "_lblSubLabel_69";
			_lblSubLabel_69.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_69.Size = new System.Drawing.Size(77, 13);
			_lblSubLabel_69.TabIndex = 359;
			_lblSubLabel_69.Text = "last access date";
			_lblSubLabel_69.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_69.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// _lblSubLabel_66
			// 
			_lblSubLabel_66.AllowDrop = true;
			_lblSubLabel_66.AutoSize = true;
			_lblSubLabel_66.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_66.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_66.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_66.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_66.Location = new System.Drawing.Point(232, 56);
			_lblSubLabel_66.MinimumSize = new System.Drawing.Size(61, 13);
			_lblSubLabel_66.Name = "_lblSubLabel_66";
			_lblSubLabel_66.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_66.Size = new System.Drawing.Size(61, 13);
			_lblSubLabel_66.TabIndex = 358;
			_lblSubLabel_66.Text = "Last Access:";
			_lblSubLabel_66.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_66.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// lblSubDefaultAModId
			// 
			lblSubDefaultAModId.AllowDrop = true;
			lblSubDefaultAModId.BackColor = System.Drawing.Color.Transparent;
			lblSubDefaultAModId.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblSubDefaultAModId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblSubDefaultAModId.ForeColor = System.Drawing.SystemColors.ControlText;
			lblSubDefaultAModId.Location = new System.Drawing.Point(232, 16);
			lblSubDefaultAModId.MinimumSize = new System.Drawing.Size(161, 19);
			lblSubDefaultAModId.Name = "lblSubDefaultAModId";
			lblSubDefaultAModId.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblSubDefaultAModId.Size = new System.Drawing.Size(161, 19);
			lblSubDefaultAModId.TabIndex = 348;
			lblSubDefaultAModId.Text = "Model: None";
			// 
			// _lblSubLabel_10
			// 
			_lblSubLabel_10.AllowDrop = true;
			_lblSubLabel_10.AutoSize = true;
			_lblSubLabel_10.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_10.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_10.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_10.Location = new System.Drawing.Point(14, 35);
			_lblSubLabel_10.MinimumSize = new System.Drawing.Size(38, 13);
			_lblSubLabel_10.Name = "_lblSubLabel_10";
			_lblSubLabel_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_10.Size = new System.Drawing.Size(38, 13);
			_lblSubLabel_10.TabIndex = 345;
			_lblSubLabel_10.Text = "Browser";
			_lblSubLabel_10.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_10.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// _lblSubLabel_12
			// 
			_lblSubLabel_12.AllowDrop = true;
			_lblSubLabel_12.AutoSize = true;
			_lblSubLabel_12.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_12.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_12.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_12.Location = new System.Drawing.Point(14, 85);
			_lblSubLabel_12.MinimumSize = new System.Drawing.Size(58, 13);
			_lblSubLabel_12.Name = "_lblSubLabel_12";
			_lblSubLabel_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_12.Size = new System.Drawing.Size(58, 13);
			_lblSubLabel_12.TabIndex = 339;
			_lblSubLabel_12.Text = "Reply Name";
			_lblSubLabel_12.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_12.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// _lblSubLabel_13
			// 
			_lblSubLabel_13.AllowDrop = true;
			_lblSubLabel_13.AutoSize = true;
			_lblSubLabel_13.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_13.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_13.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_13.Location = new System.Drawing.Point(232, 80);
			_lblSubLabel_13.MinimumSize = new System.Drawing.Size(26, 13);
			_lblSubLabel_13.Name = "_lblSubLabel_13";
			_lblSubLabel_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_13.Size = new System.Drawing.Size(26, 13);
			_lblSubLabel_13.TabIndex = 338;
			_lblSubLabel_13.Text = "EMail";
			_lblSubLabel_13.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_13.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// _lblSubLabel_1
			// 
			_lblSubLabel_1.AllowDrop = true;
			_lblSubLabel_1.AutoSize = true;
			_lblSubLabel_1.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_1.Location = new System.Drawing.Point(232, 35);
			_lblSubLabel_1.MinimumSize = new System.Drawing.Size(37, 13);
			_lblSubLabel_1.Name = "_lblSubLabel_1";
			_lblSubLabel_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_1.Size = new System.Drawing.Size(37, 13);
			_lblSubLabel_1.TabIndex = 335;
			_lblSubLabel_1.Text = "#/Page";
			_lblSubLabel_1.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_1.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// _lblSubLabel_55
			// 
			_lblSubLabel_55.AllowDrop = true;
			_lblSubLabel_55.AutoSize = true;
			_lblSubLabel_55.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_55.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_55.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_55.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_55.Location = new System.Drawing.Point(330, 35);
			_lblSubLabel_55.MinimumSize = new System.Drawing.Size(64, 13);
			_lblSubLabel_55.Name = "_lblSubLabel_55";
			_lblSubLabel_55.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_55.Size = new System.Drawing.Size(64, 13);
			_lblSubLabel_55.TabIndex = 334;
			_lblSubLabel_55.Text = "Analysis Mths";
			_lblSubLabel_55.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_55.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// _lblSubLabel_22
			// 
			_lblSubLabel_22.AllowDrop = true;
			_lblSubLabel_22.BackColor = System.Drawing.SystemColors.Control;
			_lblSubLabel_22.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_22.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_22.Location = new System.Drawing.Point(14, 58);
			_lblSubLabel_22.MinimumSize = new System.Drawing.Size(65, 17);
			_lblSubLabel_22.Name = "_lblSubLabel_22";
			_lblSubLabel_22.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_22.Size = new System.Drawing.Size(65, 17);
			_lblSubLabel_22.TabIndex = 174;
			_lblSubLabel_22.Text = "BG Image";
			_lblSubLabel_22.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_22.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// frmInstallASPLogs
			// 
			frmInstallASPLogs.AllowDrop = true;
			frmInstallASPLogs.BackColor = System.Drawing.SystemColors.Control;
			frmInstallASPLogs.Controls.Add(lblSubInsViewEvoMobileLogs);
			frmInstallASPLogs.Controls.Add(lblSubInsViewSMSTextMsgsReceived);
			frmInstallASPLogs.Controls.Add(lblSubInsViewSMSTextMsgsSent);
			frmInstallASPLogs.Controls.Add(lblSubInsViewWebReport);
			frmInstallASPLogs.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmInstallASPLogs.Enabled = true;
			frmInstallASPLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmInstallASPLogs.ForeColor = System.Drawing.SystemColors.ControlText;
			frmInstallASPLogs.Location = new System.Drawing.Point(258, -16);
			frmInstallASPLogs.Name = "frmInstallASPLogs";
			frmInstallASPLogs.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmInstallASPLogs.Size = new System.Drawing.Size(205, 151);
			frmInstallASPLogs.TabIndex = 161;
			frmInstallASPLogs.Visible = false;
			// 
			// lblSubInsViewEvoMobileLogs
			// 
			lblSubInsViewEvoMobileLogs.AllowDrop = true;
			lblSubInsViewEvoMobileLogs.BackColor = System.Drawing.SystemColors.Control;
			lblSubInsViewEvoMobileLogs.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblSubInsViewEvoMobileLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblSubInsViewEvoMobileLogs.ForeColor = System.Drawing.Color.Blue;
			lblSubInsViewEvoMobileLogs.Location = new System.Drawing.Point(32, 90);
			lblSubInsViewEvoMobileLogs.MinimumSize = new System.Drawing.Size(172, 16);
			lblSubInsViewEvoMobileLogs.Name = "lblSubInsViewEvoMobileLogs";
			lblSubInsViewEvoMobileLogs.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblSubInsViewEvoMobileLogs.Size = new System.Drawing.Size(172, 16);
			lblSubInsViewEvoMobileLogs.TabIndex = 165;
			lblSubInsViewEvoMobileLogs.Text = "Evo Mobile Logs";
			lblSubInsViewEvoMobileLogs.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			lblSubInsViewEvoMobileLogs.Click += new System.EventHandler(lblSubInsViewEvoMobileLogs_Click);
			// 
			// lblSubInsViewSMSTextMsgsReceived
			// 
			lblSubInsViewSMSTextMsgsReceived.AllowDrop = true;
			lblSubInsViewSMSTextMsgsReceived.BackColor = System.Drawing.SystemColors.Control;
			lblSubInsViewSMSTextMsgsReceived.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblSubInsViewSMSTextMsgsReceived.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblSubInsViewSMSTextMsgsReceived.ForeColor = System.Drawing.Color.Blue;
			lblSubInsViewSMSTextMsgsReceived.Location = new System.Drawing.Point(15, 69);
			lblSubInsViewSMSTextMsgsReceived.MinimumSize = new System.Drawing.Size(172, 16);
			lblSubInsViewSMSTextMsgsReceived.Name = "lblSubInsViewSMSTextMsgsReceived";
			lblSubInsViewSMSTextMsgsReceived.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblSubInsViewSMSTextMsgsReceived.Size = new System.Drawing.Size(172, 16);
			lblSubInsViewSMSTextMsgsReceived.TabIndex = 164;
			lblSubInsViewSMSTextMsgsReceived.Text = "SMS Text Msgs Received";
			lblSubInsViewSMSTextMsgsReceived.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			lblSubInsViewSMSTextMsgsReceived.Click += new System.EventHandler(lblSubInsViewSMSTextMsgsReceived_Click);
			// 
			// lblSubInsViewSMSTextMsgsSent
			// 
			lblSubInsViewSMSTextMsgsSent.AllowDrop = true;
			lblSubInsViewSMSTextMsgsSent.BackColor = System.Drawing.SystemColors.Control;
			lblSubInsViewSMSTextMsgsSent.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblSubInsViewSMSTextMsgsSent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblSubInsViewSMSTextMsgsSent.ForeColor = System.Drawing.Color.Blue;
			lblSubInsViewSMSTextMsgsSent.Location = new System.Drawing.Point(16, 48);
			lblSubInsViewSMSTextMsgsSent.MinimumSize = new System.Drawing.Size(172, 16);
			lblSubInsViewSMSTextMsgsSent.Name = "lblSubInsViewSMSTextMsgsSent";
			lblSubInsViewSMSTextMsgsSent.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblSubInsViewSMSTextMsgsSent.Size = new System.Drawing.Size(172, 16);
			lblSubInsViewSMSTextMsgsSent.TabIndex = 163;
			lblSubInsViewSMSTextMsgsSent.Text = "SMS Text Msgs Sent";
			lblSubInsViewSMSTextMsgsSent.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			lblSubInsViewSMSTextMsgsSent.Click += new System.EventHandler(lblSubInsViewSMSTextMsgsSent_Click);
			// 
			// lblSubInsViewWebReport
			// 
			lblSubInsViewWebReport.AllowDrop = true;
			lblSubInsViewWebReport.BackColor = System.Drawing.SystemColors.Control;
			lblSubInsViewWebReport.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblSubInsViewWebReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblSubInsViewWebReport.ForeColor = System.Drawing.Color.Blue;
			lblSubInsViewWebReport.Location = new System.Drawing.Point(36, 27);
			lblSubInsViewWebReport.MinimumSize = new System.Drawing.Size(121, 16);
			lblSubInsViewWebReport.Name = "lblSubInsViewWebReport";
			lblSubInsViewWebReport.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblSubInsViewWebReport.Size = new System.Drawing.Size(121, 16);
			lblSubInsViewWebReport.TabIndex = 162;
			lblSubInsViewWebReport.Text = "Saved Projects/Folders";
			lblSubInsViewWebReport.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			lblSubInsViewWebReport.Click += new System.EventHandler(lblSubInsViewWebReport_Click);
			// 
			// _lblSubLabel_8
			// 
			_lblSubLabel_8.AllowDrop = true;
			_lblSubLabel_8.AutoSize = true;
			_lblSubLabel_8.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_8.ForeColor = System.Drawing.Color.Blue;
			_lblSubLabel_8.Location = new System.Drawing.Point(360, 183);
			_lblSubLabel_8.MinimumSize = new System.Drawing.Size(42, 13);
			_lblSubLabel_8.Name = "_lblSubLabel_8";
			_lblSubLabel_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_8.Size = new System.Drawing.Size(42, 13);
			_lblSubLabel_8.TabIndex = 222;
			_lblSubLabel_8.Text = "Last App";
			_lblSubLabel_8.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_8.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// _lblSubLabel_31
			// 
			_lblSubLabel_31.AllowDrop = true;
			_lblSubLabel_31.AutoSize = true;
			_lblSubLabel_31.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_31.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_31.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_31.Location = new System.Drawing.Point(8, 16);
			_lblSubLabel_31.MinimumSize = new System.Drawing.Size(37, 13);
			_lblSubLabel_31.Name = "_lblSubLabel_31";
			_lblSubLabel_31.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_31.Size = new System.Drawing.Size(37, 13);
			_lblSubLabel_31.TabIndex = 201;
			_lblSubLabel_31.Text = "Contact";
			_lblSubLabel_31.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_31.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// _InstallLinkLabel_2
			// 
			_InstallLinkLabel_2.AllowDrop = true;
			_InstallLinkLabel_2.AutoSize = true;
			_InstallLinkLabel_2.BackColor = System.Drawing.Color.Transparent;
			_InstallLinkLabel_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_InstallLinkLabel_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_InstallLinkLabel_2.ForeColor = System.Drawing.Color.Blue;
			_InstallLinkLabel_2.Location = new System.Drawing.Point(200, 184);
			_InstallLinkLabel_2.MinimumSize = new System.Drawing.Size(141, 13);
			_InstallLinkLabel_2.Name = "_InstallLinkLabel_2";
			_InstallLinkLabel_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_InstallLinkLabel_2.Size = new System.Drawing.Size(141, 13);
			_InstallLinkLabel_2.TabIndex = 173;
			_InstallLinkLabel_2.Text = "Copy/Move (Proj/Fldrs/Expts)";
			_InstallLinkLabel_2.Click += new System.EventHandler(InstallLinkLabel_Click);
			// 
			// _InstallLinkLabel_1
			// 
			_InstallLinkLabel_1.AllowDrop = true;
			_InstallLinkLabel_1.AutoSize = true;
			_InstallLinkLabel_1.BackColor = System.Drawing.Color.Transparent;
			_InstallLinkLabel_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_InstallLinkLabel_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_InstallLinkLabel_1.ForeColor = System.Drawing.Color.Blue;
			_InstallLinkLabel_1.Location = new System.Drawing.Point(96, 184);
			_InstallLinkLabel_1.MinimumSize = new System.Drawing.Size(90, 13);
			_InstallLinkLabel_1.Name = "_InstallLinkLabel_1";
			_InstallLinkLabel_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_InstallLinkLabel_1.Size = new System.Drawing.Size(90, 13);
			_InstallLinkLabel_1.TabIndex = 172;
			_InstallLinkLabel_1.Text = "View SMS Txt Msg";
			_InstallLinkLabel_1.Click += new System.EventHandler(InstallLinkLabel_Click);
			// 
			// _InstallLinkLabel_0
			// 
			_InstallLinkLabel_0.AllowDrop = true;
			_InstallLinkLabel_0.AutoSize = true;
			_InstallLinkLabel_0.BackColor = System.Drawing.Color.Transparent;
			_InstallLinkLabel_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_InstallLinkLabel_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_InstallLinkLabel_0.ForeColor = System.Drawing.Color.Blue;
			_InstallLinkLabel_0.Location = new System.Drawing.Point(16, 184);
			_InstallLinkLabel_0.MinimumSize = new System.Drawing.Size(73, 13);
			_InstallLinkLabel_0.Name = "_InstallLinkLabel_0";
			_InstallLinkLabel_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_InstallLinkLabel_0.Size = new System.Drawing.Size(73, 13);
			_InstallLinkLabel_0.TabIndex = 135;
			_InstallLinkLabel_0.Text = "View ASP Logs";
			_InstallLinkLabel_0.Click += new System.EventHandler(InstallLinkLabel_Click);
			// 
			// _lblSubLabel_14
			// 
			_lblSubLabel_14.AllowDrop = true;
			_lblSubLabel_14.AutoSize = true;
			_lblSubLabel_14.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_14.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_14.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_14.Location = new System.Drawing.Point(16, 58);
			_lblSubLabel_14.MinimumSize = new System.Drawing.Size(91, 21);
			_lblSubLabel_14.Name = "_lblSubLabel_14";
			_lblSubLabel_14.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_14.Size = new System.Drawing.Size(91, 21);
			_lblSubLabel_14.TabIndex = 59;
			_lblSubLabel_14.Text = "Contract Amount: $";
			_lblSubLabel_14.Visible = false;
			_lblSubLabel_14.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_14.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// grd_Logins
			// 
			grd_Logins.AllowDrop = true;
			grd_Logins.AllowUserToAddRows = false;
			grd_Logins.AllowUserToDeleteRows = false;
			grd_Logins.AllowUserToResizeColumns = false;
			grd_Logins.AllowUserToResizeColumns = grd_Logins.ColumnHeadersVisible;
			grd_Logins.AllowUserToResizeRows = false;
			grd_Logins.AllowUserToResizeRows = grd_Logins.RowHeadersVisible;
			grd_Logins.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grd_Logins.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_Logins.ColumnsCount = 2;
			grd_Logins.FixedColumns = 1;
			grd_Logins.FixedRows = 1;
			grd_Logins.FocusRect = UpgradeHelpers.FocusRectSettings.FocusNone;
			grd_Logins.Location = new System.Drawing.Point(8, 8);
			grd_Logins.Name = "grd_Logins";
			grd_Logins.ReadOnly = true;
			grd_Logins.RowsCount = 2;
			grd_Logins.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grd_Logins.ShowCellToolTips = false;
			grd_Logins.Size = new System.Drawing.Size(277, 217);
			grd_Logins.StandardTab = true;
			grd_Logins.TabIndex = 57;
			grd_Logins.Visible = false;
			grd_Logins.Click += new System.EventHandler(grd_Logins_Click);
			grd_Logins.DoubleClick += new System.EventHandler(grd_Logins_DoubleClick);
			// 
			// fraLogin
			// 
			fraLogin.AllowDrop = true;
			fraLogin.BackColor = System.Drawing.SystemColors.Control;
			fraLogin.Controls.Add(cbo_build);
			fraLogin.Controls.Add(frm_authentication);
			fraLogin.Controls.Add(frmLoginFlags);
			fraLogin.Controls.Add(txt_sublogin_billed_amount);
			fraLogin.Controls.Add(cmdMoveLoginFrame);
			fraLogin.Controls.Add(cmd_SaveUser);
			fraLogin.Controls.Add(cmdCancelLoginFrame);
			fraLogin.Controls.Add(txt_sub_password);
			fraLogin.Controls.Add(txt_SubLoginContractAmount);
			fraLogin.Controls.Add(txt_SubLoginNbrOfInstalls);
			fraLogin.Controls.Add(cmd_DeleteLogin);
			fraLogin.Controls.Add(cmdEMailSubNotice);
			fraLogin.Controls.Add(cmdResetDemoLogin);
			fraLogin.Controls.Add(cmdGeneratePassword);
			fraLogin.Controls.Add(txtLoginName);
			fraLogin.Controls.Add(_lblSubLabel_73);
			fraLogin.Controls.Add(_lblSubLabel_57);
			fraLogin.Controls.Add(Label1);
			fraLogin.Controls.Add(lblSubAddInstall);
			fraLogin.Controls.Add(lblLoginShowFlags);
			fraLogin.Controls.Add(lbl_Password);
			fraLogin.Controls.Add(lbl_SubLoginContractAmount);
			fraLogin.Controls.Add(lbl_SubLoginNbrOfInstalls);
			fraLogin.Controls.Add(lblSubInsContact);
			fraLogin.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			fraLogin.Enabled = true;
			fraLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			fraLogin.ForeColor = System.Drawing.SystemColors.ControlText;
			fraLogin.Location = new System.Drawing.Point(16, 0);
			fraLogin.Name = "fraLogin";
			fraLogin.RightToLeft = System.Windows.Forms.RightToLeft.No;
			fraLogin.Size = new System.Drawing.Size(455, 235);
			fraLogin.TabIndex = 53;
			fraLogin.Text = "Login";
			fraLogin.Visible = true;
			// 
			// cbo_build
			// 
			cbo_build.AllowDrop = true;
			cbo_build.BackColor = System.Drawing.SystemColors.Window;
			cbo_build.CausesValidation = true;
			cbo_build.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_build.Enabled = true;
			cbo_build.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_build.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_build.IntegralHeight = true;
			cbo_build.Location = new System.Drawing.Point(211, 48);
			cbo_build.Name = "cbo_build";
			cbo_build.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_build.Size = new System.Drawing.Size(57, 21);
			cbo_build.Sorted = false;
			cbo_build.TabIndex = 373;
			cbo_build.TabStop = true;
			cbo_build.Visible = true;
			// 
			// frm_authentication
			// 
			frm_authentication.AllowDrop = true;
			frm_authentication.BackColor = System.Drawing.SystemColors.Control;
			frm_authentication.Controls.Add(txt_auth_phone);
			frm_authentication.Controls.Add(txt_auth_last_action);
			frm_authentication.Controls.Add(_cmd_auth_btn_1);
			frm_authentication.Controls.Add(_cmd_auth_btn_0);
			frm_authentication.Controls.Add(cbo_auth_type);
			frm_authentication.Controls.Add(cbo_auth_cycle);
			frm_authentication.Controls.Add(chk_auth_status);
			frm_authentication.Controls.Add(_lblSubLabel_9);
			frm_authentication.Controls.Add(_lblSubLabel_68);
			frm_authentication.Controls.Add(_lblSubLabel_67);
			frm_authentication.Controls.Add(_lblSubLabel_65);
			frm_authentication.Controls.Add(_lblSubLabel_64);
			frm_authentication.Controls.Add(_lblSubLabel_63);
			frm_authentication.Controls.Add(_lblSubLabel_62);
			frm_authentication.Controls.Add(_lblSubLabel_61);
			frm_authentication.Controls.Add(_lblSubLabel_60);
			frm_authentication.Controls.Add(_lblSubLabel_58);
			frm_authentication.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frm_authentication.Enabled = true;
			frm_authentication.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frm_authentication.ForeColor = System.Drawing.SystemColors.ControlText;
			frm_authentication.Location = new System.Drawing.Point(272, 0);
			frm_authentication.Name = "frm_authentication";
			frm_authentication.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frm_authentication.Size = new System.Drawing.Size(177, 225);
			frm_authentication.TabIndex = 310;
			frm_authentication.Text = "Authentication";
			frm_authentication.Visible = true;
			// 
			// txt_auth_phone
			// 
			txt_auth_phone.AcceptsReturn = true;
			txt_auth_phone.AllowDrop = true;
			txt_auth_phone.BackColor = System.Drawing.SystemColors.Window;
			txt_auth_phone.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_auth_phone.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_auth_phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_auth_phone.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_auth_phone.Location = new System.Drawing.Point(56, 155);
			txt_auth_phone.MaxLength = 0;
			txt_auth_phone.Name = "txt_auth_phone";
			txt_auth_phone.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_auth_phone.Size = new System.Drawing.Size(113, 19);
			txt_auth_phone.TabIndex = 360;
			// 
			// txt_auth_last_action
			// 
			txt_auth_last_action.AcceptsReturn = true;
			txt_auth_last_action.AllowDrop = true;
			txt_auth_last_action.BackColor = System.Drawing.SystemColors.Window;
			txt_auth_last_action.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_auth_last_action.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_auth_last_action.Enabled = false;
			txt_auth_last_action.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_auth_last_action.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_auth_last_action.Location = new System.Drawing.Point(8, 88);
			txt_auth_last_action.MaxLength = 0;
			txt_auth_last_action.Multiline = true;
			txt_auth_last_action.Name = "txt_auth_last_action";
			txt_auth_last_action.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_auth_last_action.Size = new System.Drawing.Size(161, 67);
			txt_auth_last_action.TabIndex = 325;
			// 
			// _cmd_auth_btn_1
			// 
			_cmd_auth_btn_1.AllowDrop = true;
			_cmd_auth_btn_1.BackColor = System.Drawing.SystemColors.Control;
			_cmd_auth_btn_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_auth_btn_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_auth_btn_1.Location = new System.Drawing.Point(88, 189);
			_cmd_auth_btn_1.Name = "_cmd_auth_btn_1";
			_cmd_auth_btn_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_auth_btn_1.Size = new System.Drawing.Size(73, 18);
			_cmd_auth_btn_1.TabIndex = 324;
			_cmd_auth_btn_1.Text = "Clear";
			_cmd_auth_btn_1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_auth_btn_1.UseVisualStyleBackColor = false;
			_cmd_auth_btn_1.Click += new System.EventHandler(cmd_auth_btn_Click);
			// 
			// _cmd_auth_btn_0
			// 
			_cmd_auth_btn_0.AllowDrop = true;
			_cmd_auth_btn_0.BackColor = System.Drawing.SystemColors.Control;
			_cmd_auth_btn_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_auth_btn_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_auth_btn_0.Location = new System.Drawing.Point(8, 189);
			_cmd_auth_btn_0.Name = "_cmd_auth_btn_0";
			_cmd_auth_btn_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_auth_btn_0.Size = new System.Drawing.Size(73, 18);
			_cmd_auth_btn_0.TabIndex = 323;
			_cmd_auth_btn_0.Text = "Save";
			_cmd_auth_btn_0.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_auth_btn_0.UseVisualStyleBackColor = false;
			_cmd_auth_btn_0.Click += new System.EventHandler(cmd_auth_btn_Click);
			// 
			// cbo_auth_type
			// 
			cbo_auth_type.AllowDrop = true;
			cbo_auth_type.BackColor = System.Drawing.SystemColors.Window;
			cbo_auth_type.CausesValidation = true;
			cbo_auth_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_auth_type.Enabled = true;
			cbo_auth_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_auth_type.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_auth_type.IntegralHeight = true;
			cbo_auth_type.Location = new System.Drawing.Point(112, 40);
			cbo_auth_type.Name = "cbo_auth_type";
			cbo_auth_type.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_auth_type.Size = new System.Drawing.Size(57, 21);
			cbo_auth_type.Sorted = false;
			cbo_auth_type.TabIndex = 315;
			cbo_auth_type.TabStop = true;
			cbo_auth_type.Text = "Combo1";
			cbo_auth_type.Visible = true;
			// 
			// cbo_auth_cycle
			// 
			cbo_auth_cycle.AllowDrop = true;
			cbo_auth_cycle.BackColor = System.Drawing.SystemColors.Window;
			cbo_auth_cycle.CausesValidation = true;
			cbo_auth_cycle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_auth_cycle.Enabled = true;
			cbo_auth_cycle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_auth_cycle.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_auth_cycle.IntegralHeight = true;
			cbo_auth_cycle.Location = new System.Drawing.Point(112, 16);
			cbo_auth_cycle.Name = "cbo_auth_cycle";
			cbo_auth_cycle.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_auth_cycle.Size = new System.Drawing.Size(57, 21);
			cbo_auth_cycle.Sorted = false;
			cbo_auth_cycle.TabIndex = 312;
			cbo_auth_cycle.TabStop = true;
			cbo_auth_cycle.Text = "14";
			cbo_auth_cycle.Visible = true;
			// 
			// chk_auth_status
			// 
			chk_auth_status.AllowDrop = true;
			chk_auth_status.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_auth_status.BackColor = System.Drawing.SystemColors.Control;
			chk_auth_status.CausesValidation = true;
			chk_auth_status.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_auth_status.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_auth_status.Enabled = true;
			chk_auth_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_auth_status.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_auth_status.Location = new System.Drawing.Point(16, 16);
			chk_auth_status.Name = "chk_auth_status";
			chk_auth_status.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_auth_status.Size = new System.Drawing.Size(57, 13);
			chk_auth_status.TabIndex = 311;
			chk_auth_status.TabStop = true;
			chk_auth_status.Text = "Status";
			chk_auth_status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_auth_status.Visible = true;
			// 
			// _lblSubLabel_9
			// 
			_lblSubLabel_9.AllowDrop = true;
			_lblSubLabel_9.AutoSize = true;
			_lblSubLabel_9.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_9.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_9.ForeColor = System.Drawing.Color.Red;
			_lblSubLabel_9.Location = new System.Drawing.Point(8, 206);
			_lblSubLabel_9.MinimumSize = new System.Drawing.Size(18, 13);
			_lblSubLabel_9.Name = "_lblSubLabel_9";
			_lblSubLabel_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_9.Size = new System.Drawing.Size(18, 13);
			_lblSubLabel_9.TabIndex = 357;
			_lblSubLabel_9.Text = "......";
			_lblSubLabel_9.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_9.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// _lblSubLabel_68
			// 
			_lblSubLabel_68.AllowDrop = true;
			_lblSubLabel_68.AutoSize = true;
			_lblSubLabel_68.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_68.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_68.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_68.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_68.Location = new System.Drawing.Point(48, 173);
			_lblSubLabel_68.MinimumSize = new System.Drawing.Size(116, 13);
			_lblSubLabel_68.Name = "_lblSubLabel_68";
			_lblSubLabel_68.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_68.Size = new System.Drawing.Size(116, 13);
			_lblSubLabel_68.TabIndex = 322;
			_lblSubLabel_68.Text = "xxxx";
			_lblSubLabel_68.TextAlign = System.Drawing.ContentAlignment.TopRight;
			_lblSubLabel_68.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_68.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// _lblSubLabel_67
			// 
			_lblSubLabel_67.AllowDrop = true;
			_lblSubLabel_67.AutoSize = true;
			_lblSubLabel_67.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_67.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_67.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_67.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_67.Location = new System.Drawing.Point(56, 159);
			_lblSubLabel_67.MinimumSize = new System.Drawing.Size(108, 13);
			_lblSubLabel_67.Name = "_lblSubLabel_67";
			_lblSubLabel_67.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_67.Size = new System.Drawing.Size(108, 13);
			_lblSubLabel_67.TabIndex = 321;
			_lblSubLabel_67.Text = "xxxx";
			_lblSubLabel_67.TextAlign = System.Drawing.ContentAlignment.TopRight;
			_lblSubLabel_67.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_67.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// _lblSubLabel_65
			// 
			_lblSubLabel_65.AllowDrop = true;
			_lblSubLabel_65.AutoSize = true;
			_lblSubLabel_65.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_65.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_65.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_65.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_65.Location = new System.Drawing.Point(81, 60);
			_lblSubLabel_65.MinimumSize = new System.Drawing.Size(92, 13);
			_lblSubLabel_65.Name = "_lblSubLabel_65";
			_lblSubLabel_65.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_65.Size = new System.Drawing.Size(92, 13);
			_lblSubLabel_65.TabIndex = 320;
			_lblSubLabel_65.Text = "xxxx";
			_lblSubLabel_65.TextAlign = System.Drawing.ContentAlignment.TopRight;
			_lblSubLabel_65.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_65.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// _lblSubLabel_64
			// 
			_lblSubLabel_64.AllowDrop = true;
			_lblSubLabel_64.AutoSize = true;
			_lblSubLabel_64.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_64.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_64.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_64.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_64.Location = new System.Drawing.Point(8, 173);
			_lblSubLabel_64.MinimumSize = new System.Drawing.Size(28, 13);
			_lblSubLabel_64.Name = "_lblSubLabel_64";
			_lblSubLabel_64.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_64.Size = new System.Drawing.Size(28, 13);
			_lblSubLabel_64.TabIndex = 319;
			_lblSubLabel_64.Text = "Email:";
			_lblSubLabel_64.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_64.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// _lblSubLabel_63
			// 
			_lblSubLabel_63.AllowDrop = true;
			_lblSubLabel_63.AutoSize = true;
			_lblSubLabel_63.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_63.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_63.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_63.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_63.Location = new System.Drawing.Point(8, 155);
			_lblSubLabel_63.MinimumSize = new System.Drawing.Size(34, 13);
			_lblSubLabel_63.Name = "_lblSubLabel_63";
			_lblSubLabel_63.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_63.Size = new System.Drawing.Size(34, 13);
			_lblSubLabel_63.TabIndex = 318;
			_lblSubLabel_63.Text = "Phone:";
			_lblSubLabel_63.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_63.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// _lblSubLabel_62
			// 
			_lblSubLabel_62.AllowDrop = true;
			_lblSubLabel_62.AutoSize = true;
			_lblSubLabel_62.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_62.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_62.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_62.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_62.Location = new System.Drawing.Point(8, 74);
			_lblSubLabel_62.MinimumSize = new System.Drawing.Size(56, 13);
			_lblSubLabel_62.Name = "_lblSubLabel_62";
			_lblSubLabel_62.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_62.Size = new System.Drawing.Size(56, 13);
			_lblSubLabel_62.TabIndex = 317;
			_lblSubLabel_62.Text = "Last Status:";
			_lblSubLabel_62.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_62.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// _lblSubLabel_61
			// 
			_lblSubLabel_61.AllowDrop = true;
			_lblSubLabel_61.AutoSize = true;
			_lblSubLabel_61.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_61.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_61.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_61.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_61.Location = new System.Drawing.Point(8, 60);
			_lblSubLabel_61.MinimumSize = new System.Drawing.Size(62, 13);
			_lblSubLabel_61.Name = "_lblSubLabel_61";
			_lblSubLabel_61.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_61.Size = new System.Drawing.Size(62, 13);
			_lblSubLabel_61.TabIndex = 316;
			_lblSubLabel_61.Text = "Last Attempt:";
			_lblSubLabel_61.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_61.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// _lblSubLabel_60
			// 
			_lblSubLabel_60.AllowDrop = true;
			_lblSubLabel_60.AutoSize = true;
			_lblSubLabel_60.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_60.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_60.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_60.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_60.Location = new System.Drawing.Point(80, 40);
			_lblSubLabel_60.MinimumSize = new System.Drawing.Size(27, 13);
			_lblSubLabel_60.Name = "_lblSubLabel_60";
			_lblSubLabel_60.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_60.Size = new System.Drawing.Size(27, 13);
			_lblSubLabel_60.TabIndex = 314;
			_lblSubLabel_60.Text = "Type:";
			_lblSubLabel_60.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_60.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// _lblSubLabel_58
			// 
			_lblSubLabel_58.AllowDrop = true;
			_lblSubLabel_58.AutoSize = true;
			_lblSubLabel_58.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_58.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_58.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_58.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_58.Location = new System.Drawing.Point(80, 16);
			_lblSubLabel_58.MinimumSize = new System.Drawing.Size(37, 13);
			_lblSubLabel_58.Name = "_lblSubLabel_58";
			_lblSubLabel_58.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_58.Size = new System.Drawing.Size(37, 13);
			_lblSubLabel_58.TabIndex = 313;
			_lblSubLabel_58.Text = "Cycle:";
			_lblSubLabel_58.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_58.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// frmLoginFlags
			// 
			frmLoginFlags.AllowDrop = true;
			frmLoginFlags.BackColor = System.Drawing.SystemColors.Control;
			frmLoginFlags.Controls.Add(_chkLoginFlag_2);
			frmLoginFlags.Controls.Add(_chkLoginFlag_5);
			frmLoginFlags.Controls.Add(_chkLoginFlag_7);
			frmLoginFlags.Controls.Add(_chkLoginFlag_10);
			frmLoginFlags.Controls.Add(_chkLoginFlag_9);
			frmLoginFlags.Controls.Add(_chkLoginFlag_6);
			frmLoginFlags.Controls.Add(_chkLoginFlag_1);
			frmLoginFlags.Controls.Add(_chkLoginFlag_0);
			frmLoginFlags.Controls.Add(lblLoginFlagsHide);
			frmLoginFlags.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmLoginFlags.Enabled = true;
			frmLoginFlags.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmLoginFlags.ForeColor = System.Drawing.SystemColors.ControlText;
			frmLoginFlags.Location = new System.Drawing.Point(8, 144);
			frmLoginFlags.Name = "frmLoginFlags";
			frmLoginFlags.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmLoginFlags.Size = new System.Drawing.Size(268, 83);
			frmLoginFlags.TabIndex = 93;
			frmLoginFlags.Text = "Login Flags";
			frmLoginFlags.Visible = false;
			// 
			// _chkLoginFlag_2
			// 
			_chkLoginFlag_2.AllowDrop = true;
			_chkLoginFlag_2.Appearance = System.Windows.Forms.Appearance.Normal;
			_chkLoginFlag_2.BackColor = System.Drawing.SystemColors.Control;
			_chkLoginFlag_2.CausesValidation = true;
			_chkLoginFlag_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkLoginFlag_2.CheckState = System.Windows.Forms.CheckState.Checked;
			_chkLoginFlag_2.Enabled = true;
			_chkLoginFlag_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chkLoginFlag_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_chkLoginFlag_2.Location = new System.Drawing.Point(137, 32);
			_chkLoginFlag_2.Name = "_chkLoginFlag_2";
			_chkLoginFlag_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chkLoginFlag_2.Size = new System.Drawing.Size(83, 13);
			_chkLoginFlag_2.TabIndex = 356;
			_chkLoginFlag_2.TabStop = true;
			_chkLoginFlag_2.Text = "Allow Export";
			_chkLoginFlag_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkLoginFlag_2.Visible = false;
			_chkLoginFlag_2.CheckStateChanged += new System.EventHandler(chkLoginFlag_CheckStateChanged);
			_chkLoginFlag_2.MouseDown += new System.Windows.Forms.MouseEventHandler(chkLoginFlag_MouseDown);
			// 
			// _chkLoginFlag_5
			// 
			_chkLoginFlag_5.AllowDrop = true;
			_chkLoginFlag_5.Appearance = System.Windows.Forms.Appearance.Normal;
			_chkLoginFlag_5.BackColor = System.Drawing.SystemColors.Control;
			_chkLoginFlag_5.CausesValidation = true;
			_chkLoginFlag_5.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkLoginFlag_5.CheckState = System.Windows.Forms.CheckState.Checked;
			_chkLoginFlag_5.Enabled = true;
			_chkLoginFlag_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chkLoginFlag_5.ForeColor = System.Drawing.SystemColors.ControlText;
			_chkLoginFlag_5.Location = new System.Drawing.Point(137, 16);
			_chkLoginFlag_5.Name = "_chkLoginFlag_5";
			_chkLoginFlag_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chkLoginFlag_5.Size = new System.Drawing.Size(124, 13);
			_chkLoginFlag_5.TabIndex = 355;
			_chkLoginFlag_5.TabStop = true;
			_chkLoginFlag_5.Text = "Allow EMail Requests";
			_chkLoginFlag_5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkLoginFlag_5.Visible = false;
			_chkLoginFlag_5.CheckStateChanged += new System.EventHandler(chkLoginFlag_CheckStateChanged);
			_chkLoginFlag_5.MouseDown += new System.Windows.Forms.MouseEventHandler(chkLoginFlag_MouseDown);
			// 
			// _chkLoginFlag_7
			// 
			_chkLoginFlag_7.AllowDrop = true;
			_chkLoginFlag_7.Appearance = System.Windows.Forms.Appearance.Normal;
			_chkLoginFlag_7.BackColor = System.Drawing.SystemColors.Control;
			_chkLoginFlag_7.CausesValidation = true;
			_chkLoginFlag_7.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkLoginFlag_7.CheckState = System.Windows.Forms.CheckState.Checked;
			_chkLoginFlag_7.Enabled = true;
			_chkLoginFlag_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chkLoginFlag_7.ForeColor = System.Drawing.SystemColors.ControlText;
			_chkLoginFlag_7.Location = new System.Drawing.Point(137, 49);
			_chkLoginFlag_7.Name = "_chkLoginFlag_7";
			_chkLoginFlag_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chkLoginFlag_7.Size = new System.Drawing.Size(124, 13);
			_chkLoginFlag_7.TabIndex = 354;
			_chkLoginFlag_7.TabStop = true;
			_chkLoginFlag_7.Text = "Allow Text Messages";
			_chkLoginFlag_7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkLoginFlag_7.Visible = false;
			_chkLoginFlag_7.CheckStateChanged += new System.EventHandler(chkLoginFlag_CheckStateChanged);
			_chkLoginFlag_7.MouseDown += new System.Windows.Forms.MouseEventHandler(chkLoginFlag_MouseDown);
			// 
			// _chkLoginFlag_10
			// 
			_chkLoginFlag_10.AllowDrop = true;
			_chkLoginFlag_10.Appearance = System.Windows.Forms.Appearance.Normal;
			_chkLoginFlag_10.BackColor = System.Drawing.SystemColors.Control;
			_chkLoginFlag_10.CausesValidation = true;
			_chkLoginFlag_10.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkLoginFlag_10.CheckState = System.Windows.Forms.CheckState.Checked;
			_chkLoginFlag_10.Enabled = false;
			_chkLoginFlag_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chkLoginFlag_10.ForeColor = System.Drawing.SystemColors.ControlText;
			_chkLoginFlag_10.Location = new System.Drawing.Point(8, 48);
			_chkLoginFlag_10.Name = "_chkLoginFlag_10";
			_chkLoginFlag_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chkLoginFlag_10.Size = new System.Drawing.Size(124, 13);
			_chkLoginFlag_10.TabIndex = 98;
			_chkLoginFlag_10.TabStop = true;
			_chkLoginFlag_10.Text = "Allow MPM";
			_chkLoginFlag_10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkLoginFlag_10.Visible = true;
			_chkLoginFlag_10.CheckStateChanged += new System.EventHandler(chkLoginFlag_CheckStateChanged);
			_chkLoginFlag_10.MouseDown += new System.Windows.Forms.MouseEventHandler(chkLoginFlag_MouseDown);
			// 
			// _chkLoginFlag_9
			// 
			_chkLoginFlag_9.AllowDrop = true;
			_chkLoginFlag_9.Appearance = System.Windows.Forms.Appearance.Normal;
			_chkLoginFlag_9.BackColor = System.Drawing.SystemColors.Control;
			_chkLoginFlag_9.CausesValidation = true;
			_chkLoginFlag_9.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkLoginFlag_9.CheckState = System.Windows.Forms.CheckState.Checked;
			_chkLoginFlag_9.Enabled = true;
			_chkLoginFlag_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chkLoginFlag_9.ForeColor = System.Drawing.SystemColors.ControlText;
			_chkLoginFlag_9.Location = new System.Drawing.Point(8, 64);
			_chkLoginFlag_9.Name = "_chkLoginFlag_9";
			_chkLoginFlag_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chkLoginFlag_9.Size = new System.Drawing.Size(124, 13);
			_chkLoginFlag_9.TabIndex = 97;
			_chkLoginFlag_9.TabStop = true;
			_chkLoginFlag_9.Text = "Allow Values";
			_chkLoginFlag_9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkLoginFlag_9.Visible = true;
			_chkLoginFlag_9.CheckStateChanged += new System.EventHandler(chkLoginFlag_CheckStateChanged);
			_chkLoginFlag_9.MouseDown += new System.Windows.Forms.MouseEventHandler(chkLoginFlag_MouseDown);
			// 
			// _chkLoginFlag_6
			// 
			_chkLoginFlag_6.AllowDrop = true;
			_chkLoginFlag_6.Appearance = System.Windows.Forms.Appearance.Normal;
			_chkLoginFlag_6.BackColor = System.Drawing.SystemColors.Control;
			_chkLoginFlag_6.CausesValidation = true;
			_chkLoginFlag_6.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkLoginFlag_6.CheckState = System.Windows.Forms.CheckState.Checked;
			_chkLoginFlag_6.Enabled = true;
			_chkLoginFlag_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chkLoginFlag_6.ForeColor = System.Drawing.SystemColors.ControlText;
			_chkLoginFlag_6.Location = new System.Drawing.Point(8, 33);
			_chkLoginFlag_6.Name = "_chkLoginFlag_6";
			_chkLoginFlag_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chkLoginFlag_6.Size = new System.Drawing.Size(124, 13);
			_chkLoginFlag_6.TabIndex = 96;
			_chkLoginFlag_6.TabStop = true;
			_chkLoginFlag_6.Text = "Allow Event Requests";
			_chkLoginFlag_6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkLoginFlag_6.Visible = true;
			_chkLoginFlag_6.CheckStateChanged += new System.EventHandler(chkLoginFlag_CheckStateChanged);
			_chkLoginFlag_6.MouseDown += new System.Windows.Forms.MouseEventHandler(chkLoginFlag_MouseDown);
			// 
			// _chkLoginFlag_1
			// 
			_chkLoginFlag_1.AllowDrop = true;
			_chkLoginFlag_1.Appearance = System.Windows.Forms.Appearance.Normal;
			_chkLoginFlag_1.BackColor = System.Drawing.SystemColors.Control;
			_chkLoginFlag_1.CausesValidation = true;
			_chkLoginFlag_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkLoginFlag_1.CheckState = System.Windows.Forms.CheckState.Checked;
			_chkLoginFlag_1.Enabled = true;
			_chkLoginFlag_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chkLoginFlag_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_chkLoginFlag_1.Location = new System.Drawing.Point(136, 64);
			_chkLoginFlag_1.Name = "_chkLoginFlag_1";
			_chkLoginFlag_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chkLoginFlag_1.Size = new System.Drawing.Size(56, 13);
			_chkLoginFlag_1.TabIndex = 95;
			_chkLoginFlag_1.TabStop = true;
			_chkLoginFlag_1.Text = "Demo";
			_chkLoginFlag_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkLoginFlag_1.Visible = false;
			_chkLoginFlag_1.CheckStateChanged += new System.EventHandler(chkLoginFlag_CheckStateChanged);
			_chkLoginFlag_1.MouseDown += new System.Windows.Forms.MouseEventHandler(chkLoginFlag_MouseDown);
			// 
			// _chkLoginFlag_0
			// 
			_chkLoginFlag_0.AllowDrop = true;
			_chkLoginFlag_0.Appearance = System.Windows.Forms.Appearance.Normal;
			_chkLoginFlag_0.BackColor = System.Drawing.SystemColors.Control;
			_chkLoginFlag_0.CausesValidation = true;
			_chkLoginFlag_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkLoginFlag_0.CheckState = System.Windows.Forms.CheckState.Checked;
			_chkLoginFlag_0.Enabled = true;
			_chkLoginFlag_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chkLoginFlag_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_chkLoginFlag_0.Location = new System.Drawing.Point(8, 18);
			_chkLoginFlag_0.Name = "_chkLoginFlag_0";
			_chkLoginFlag_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chkLoginFlag_0.Size = new System.Drawing.Size(56, 13);
			_chkLoginFlag_0.TabIndex = 94;
			_chkLoginFlag_0.TabStop = true;
			_chkLoginFlag_0.Text = "Active";
			_chkLoginFlag_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkLoginFlag_0.Visible = true;
			_chkLoginFlag_0.CheckStateChanged += new System.EventHandler(chkLoginFlag_CheckStateChanged);
			_chkLoginFlag_0.MouseDown += new System.Windows.Forms.MouseEventHandler(chkLoginFlag_MouseDown);
			// 
			// lblLoginFlagsHide
			// 
			lblLoginFlagsHide.AllowDrop = true;
			lblLoginFlagsHide.BackColor = System.Drawing.SystemColors.Control;
			lblLoginFlagsHide.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblLoginFlagsHide.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblLoginFlagsHide.ForeColor = System.Drawing.Color.Blue;
			lblLoginFlagsHide.Location = new System.Drawing.Point(56, 64);
			lblLoginFlagsHide.MinimumSize = new System.Drawing.Size(64, 16);
			lblLoginFlagsHide.Name = "lblLoginFlagsHide";
			lblLoginFlagsHide.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblLoginFlagsHide.Size = new System.Drawing.Size(64, 16);
			lblLoginFlagsHide.TabIndex = 99;
			lblLoginFlagsHide.Text = "Hide Flags";
			lblLoginFlagsHide.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			lblLoginFlagsHide.Visible = false;
			lblLoginFlagsHide.Click += new System.EventHandler(lblLoginFlagsHide_Click);
			// 
			// txt_sublogin_billed_amount
			// 
			txt_sublogin_billed_amount.AcceptsReturn = true;
			txt_sublogin_billed_amount.AllowDrop = true;
			txt_sublogin_billed_amount.BackColor = System.Drawing.SystemColors.Window;
			txt_sublogin_billed_amount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_sublogin_billed_amount.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_sublogin_billed_amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_sublogin_billed_amount.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_sublogin_billed_amount.Location = new System.Drawing.Point(176, 72);
			txt_sublogin_billed_amount.MaxLength = 0;
			txt_sublogin_billed_amount.Name = "txt_sublogin_billed_amount";
			txt_sublogin_billed_amount.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_sublogin_billed_amount.Size = new System.Drawing.Size(54, 19);
			txt_sublogin_billed_amount.TabIndex = 302;
			txt_sublogin_billed_amount.Text = "0.00";
			txt_sublogin_billed_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// cmdMoveLoginFrame
			// 
			cmdMoveLoginFrame.AllowDrop = true;
			cmdMoveLoginFrame.BackColor = System.Drawing.SystemColors.Control;
			cmdMoveLoginFrame.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdMoveLoginFrame.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdMoveLoginFrame.Location = new System.Drawing.Point(200, 120);
			cmdMoveLoginFrame.Name = "cmdMoveLoginFrame";
			cmdMoveLoginFrame.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdMoveLoginFrame.Size = new System.Drawing.Size(51, 21);
			cmdMoveLoginFrame.TabIndex = 13;
			cmdMoveLoginFrame.Text = "Move";
			cmdMoveLoginFrame.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdMoveLoginFrame.UseVisualStyleBackColor = false;
			cmdMoveLoginFrame.Click += new System.EventHandler(cmdMoveLoginFrame_Click);
			// 
			// cmd_SaveUser
			// 
			cmd_SaveUser.AllowDrop = true;
			cmd_SaveUser.BackColor = System.Drawing.SystemColors.Control;
			cmd_SaveUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_SaveUser.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_SaveUser.Location = new System.Drawing.Point(8, 120);
			cmd_SaveUser.Name = "cmd_SaveUser";
			cmd_SaveUser.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_SaveUser.Size = new System.Drawing.Size(51, 21);
			cmd_SaveUser.TabIndex = 10;
			cmd_SaveUser.Text = "&Save";
			cmd_SaveUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_SaveUser.UseVisualStyleBackColor = false;
			cmd_SaveUser.Click += new System.EventHandler(cmd_SaveUser_Click);
			cmd_SaveUser.MouseUp += new System.Windows.Forms.MouseEventHandler(cmd_SaveUser_MouseUp);
			// 
			// cmdCancelLoginFrame
			// 
			cmdCancelLoginFrame.AllowDrop = true;
			cmdCancelLoginFrame.BackColor = System.Drawing.SystemColors.Control;
			cmdCancelLoginFrame.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdCancelLoginFrame.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdCancelLoginFrame.Location = new System.Drawing.Point(136, 120);
			cmdCancelLoginFrame.Name = "cmdCancelLoginFrame";
			cmdCancelLoginFrame.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdCancelLoginFrame.Size = new System.Drawing.Size(51, 21);
			cmdCancelLoginFrame.TabIndex = 12;
			cmdCancelLoginFrame.Text = "Cancel";
			cmdCancelLoginFrame.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdCancelLoginFrame.UseVisualStyleBackColor = false;
			cmdCancelLoginFrame.Click += new System.EventHandler(cmdCancelLoginFrame_Click);
			cmdCancelLoginFrame.MouseUp += new System.Windows.Forms.MouseEventHandler(cmdCancelLoginFrame_MouseUp);
			// 
			// txt_sub_password
			// 
			txt_sub_password.AcceptsReturn = true;
			txt_sub_password.AllowDrop = true;
			txt_sub_password.BackColor = System.Drawing.Color.White;
			txt_sub_password.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_sub_password.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_sub_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_sub_password.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_sub_password.Location = new System.Drawing.Point(64, 37);
			txt_sub_password.MaxLength = 25;
			txt_sub_password.Name = "txt_sub_password";
			txt_sub_password.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_sub_password.Size = new System.Drawing.Size(94, 19);
			txt_sub_password.TabIndex = 5;
			txt_sub_password.Leave += new System.EventHandler(txt_sub_password_Leave);
			// 
			// txt_SubLoginContractAmount
			// 
			txt_SubLoginContractAmount.AcceptsReturn = true;
			txt_SubLoginContractAmount.AllowDrop = true;
			txt_SubLoginContractAmount.BackColor = System.Drawing.Color.White;
			txt_SubLoginContractAmount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_SubLoginContractAmount.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_SubLoginContractAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_SubLoginContractAmount.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_SubLoginContractAmount.Location = new System.Drawing.Point(112, 72);
			txt_SubLoginContractAmount.MaxLength = 10;
			txt_SubLoginContractAmount.Name = "txt_SubLoginContractAmount";
			txt_SubLoginContractAmount.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_SubLoginContractAmount.Size = new System.Drawing.Size(54, 19);
			txt_SubLoginContractAmount.TabIndex = 7;
			txt_SubLoginContractAmount.Text = "0.00";
			txt_SubLoginContractAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_SubLoginNbrOfInstalls
			// 
			txt_SubLoginNbrOfInstalls.AcceptsReturn = true;
			txt_SubLoginNbrOfInstalls.AllowDrop = true;
			txt_SubLoginNbrOfInstalls.BackColor = System.Drawing.Color.White;
			txt_SubLoginNbrOfInstalls.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_SubLoginNbrOfInstalls.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_SubLoginNbrOfInstalls.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_SubLoginNbrOfInstalls.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_SubLoginNbrOfInstalls.Location = new System.Drawing.Point(8, 96);
			txt_SubLoginNbrOfInstalls.MaxLength = 4;
			txt_SubLoginNbrOfInstalls.Name = "txt_SubLoginNbrOfInstalls";
			txt_SubLoginNbrOfInstalls.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_SubLoginNbrOfInstalls.Size = new System.Drawing.Size(54, 19);
			txt_SubLoginNbrOfInstalls.TabIndex = 6;
			txt_SubLoginNbrOfInstalls.Text = "0";
			txt_SubLoginNbrOfInstalls.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txt_SubLoginNbrOfInstalls.Visible = false;
			// 
			// cmd_DeleteLogin
			// 
			cmd_DeleteLogin.AllowDrop = true;
			cmd_DeleteLogin.BackColor = System.Drawing.SystemColors.Control;
			cmd_DeleteLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_DeleteLogin.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_DeleteLogin.Location = new System.Drawing.Point(72, 120);
			cmd_DeleteLogin.Name = "cmd_DeleteLogin";
			cmd_DeleteLogin.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_DeleteLogin.Size = new System.Drawing.Size(51, 21);
			cmd_DeleteLogin.TabIndex = 11;
			cmd_DeleteLogin.Text = "Delete";
			cmd_DeleteLogin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_DeleteLogin.UseVisualStyleBackColor = false;
			cmd_DeleteLogin.Click += new System.EventHandler(cmd_DeleteLogin_Click);
			cmd_DeleteLogin.MouseUp += new System.Windows.Forms.MouseEventHandler(cmd_DeleteLogin_MouseUp);
			// 
			// cmdEMailSubNotice
			// 
			cmdEMailSubNotice.AllowDrop = true;
			cmdEMailSubNotice.BackColor = System.Drawing.SystemColors.Control;
			cmdEMailSubNotice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdEMailSubNotice.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdEMailSubNotice.Location = new System.Drawing.Point(152, 88);
			cmdEMailSubNotice.Name = "cmdEMailSubNotice";
			cmdEMailSubNotice.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdEMailSubNotice.Size = new System.Drawing.Size(117, 25);
			cmdEMailSubNotice.TabIndex = 9;
			cmdEMailSubNotice.Text = "&EMail Sub Notice";
			cmdEMailSubNotice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdEMailSubNotice.UseVisualStyleBackColor = false;
			cmdEMailSubNotice.Click += new System.EventHandler(cmdEMailSubNotice_Click);
			cmdEMailSubNotice.MouseUp += new System.Windows.Forms.MouseEventHandler(cmdEMailSubNotice_MouseUp);
			// 
			// cmdResetDemoLogin
			// 
			cmdResetDemoLogin.AllowDrop = true;
			cmdResetDemoLogin.BackColor = System.Drawing.SystemColors.Control;
			cmdResetDemoLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdResetDemoLogin.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdResetDemoLogin.Location = new System.Drawing.Point(224, 88);
			cmdResetDemoLogin.Name = "cmdResetDemoLogin";
			cmdResetDemoLogin.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdResetDemoLogin.Size = new System.Drawing.Size(51, 33);
			cmdResetDemoLogin.TabIndex = 221;
			cmdResetDemoLogin.Text = "&Reset";
			cmdResetDemoLogin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdResetDemoLogin.UseVisualStyleBackColor = false;
			cmdResetDemoLogin.Visible = false;
			cmdResetDemoLogin.Click += new System.EventHandler(cmdResetDemoLogin_Click);
			// 
			// cmdGeneratePassword
			// 
			cmdGeneratePassword.AllowDrop = true;
			cmdGeneratePassword.BackColor = System.Drawing.SystemColors.Control;
			cmdGeneratePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdGeneratePassword.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdGeneratePassword.Location = new System.Drawing.Point(0, 88);
			cmdGeneratePassword.Name = "cmdGeneratePassword";
			cmdGeneratePassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdGeneratePassword.Size = new System.Drawing.Size(143, 25);
			cmdGeneratePassword.TabIndex = 8;
			cmdGeneratePassword.Text = "&Generate Password";
			cmdGeneratePassword.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdGeneratePassword.UseVisualStyleBackColor = false;
			cmdGeneratePassword.Click += new System.EventHandler(cmdGeneratePassword_Click);
			cmdGeneratePassword.MouseUp += new System.Windows.Forms.MouseEventHandler(cmdGeneratePassword_MouseUp);
			// 
			// txtLoginName
			// 
			txtLoginName.AcceptsReturn = true;
			txtLoginName.AllowDrop = true;
			txtLoginName.BackColor = System.Drawing.Color.White;
			txtLoginName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtLoginName.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtLoginName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtLoginName.ForeColor = System.Drawing.SystemColors.WindowText;
			txtLoginName.Location = new System.Drawing.Point(64, 16);
			txtLoginName.MaxLength = 15;
			txtLoginName.Name = "txtLoginName";
			txtLoginName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtLoginName.Size = new System.Drawing.Size(94, 19);
			txtLoginName.TabIndex = 4;
			txtLoginName.Leave += new System.EventHandler(txtLoginName_Leave);
			// 
			// _lblSubLabel_73
			// 
			_lblSubLabel_73.AllowDrop = true;
			_lblSubLabel_73.AutoSize = true;
			_lblSubLabel_73.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_73.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_73.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_73.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_73.Location = new System.Drawing.Point(176, 48);
			_lblSubLabel_73.MinimumSize = new System.Drawing.Size(26, 13);
			_lblSubLabel_73.Name = "_lblSubLabel_73";
			_lblSubLabel_73.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_73.Size = new System.Drawing.Size(26, 13);
			_lblSubLabel_73.TabIndex = 374;
			_lblSubLabel_73.Text = "Build:";
			_lblSubLabel_73.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_73.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// _lblSubLabel_57
			// 
			_lblSubLabel_57.AllowDrop = true;
			_lblSubLabel_57.AutoSize = true;
			_lblSubLabel_57.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_57.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_57.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_57.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_57.Location = new System.Drawing.Point(160, 93);
			_lblSubLabel_57.MinimumSize = new System.Drawing.Size(11, 13);
			_lblSubLabel_57.Name = "_lblSubLabel_57";
			_lblSubLabel_57.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_57.Size = new System.Drawing.Size(11, 13);
			_lblSubLabel_57.TabIndex = 304;
			_lblSubLabel_57.Text = " / ";
			_lblSubLabel_57.TextAlign = System.Drawing.ContentAlignment.TopRight;
			_lblSubLabel_57.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_57.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// Label1
			// 
			Label1.AllowDrop = true;
			Label1.AutoSize = true;
			Label1.BackColor = System.Drawing.Color.Transparent;
			Label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label1.ForeColor = System.Drawing.SystemColors.ControlText;
			Label1.Location = new System.Drawing.Point(0, 0);
			Label1.MinimumSize = new System.Drawing.Size(3, 13);
			Label1.Name = "Label1";
			Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label1.Size = new System.Drawing.Size(3, 13);
			Label1.TabIndex = 303;
			// 
			// lblSubAddInstall
			// 
			lblSubAddInstall.AllowDrop = true;
			lblSubAddInstall.BackColor = System.Drawing.SystemColors.Control;
			lblSubAddInstall.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblSubAddInstall.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblSubAddInstall.ForeColor = System.Drawing.Color.Blue;
			lblSubAddInstall.Location = new System.Drawing.Point(208, 29);
			lblSubAddInstall.MinimumSize = new System.Drawing.Size(69, 12);
			lblSubAddInstall.Name = "lblSubAddInstall";
			lblSubAddInstall.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblSubAddInstall.Size = new System.Drawing.Size(69, 12);
			lblSubAddInstall.TabIndex = 125;
			lblSubAddInstall.Text = "Add Installs";
			lblSubAddInstall.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			lblSubAddInstall.Visible = false;
			lblSubAddInstall.Click += new System.EventHandler(lblSubAddInstall_Click);
			// 
			// lblLoginShowFlags
			// 
			lblLoginShowFlags.AllowDrop = true;
			lblLoginShowFlags.BackColor = System.Drawing.SystemColors.Control;
			lblLoginShowFlags.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblLoginShowFlags.Enabled = false;
			lblLoginShowFlags.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblLoginShowFlags.ForeColor = System.Drawing.Color.Blue;
			lblLoginShowFlags.Location = new System.Drawing.Point(208, 8);
			lblLoginShowFlags.MinimumSize = new System.Drawing.Size(68, 12);
			lblLoginShowFlags.Name = "lblLoginShowFlags";
			lblLoginShowFlags.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblLoginShowFlags.Size = new System.Drawing.Size(68, 12);
			lblLoginShowFlags.TabIndex = 100;
			lblLoginShowFlags.Text = "Show Flags";
			lblLoginShowFlags.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			lblLoginShowFlags.Click += new System.EventHandler(lblLoginShowFlags_Click);
			// 
			// lbl_Password
			// 
			lbl_Password.AllowDrop = true;
			lbl_Password.AutoSize = true;
			lbl_Password.BackColor = System.Drawing.Color.Transparent;
			lbl_Password.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_Password.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_Password.Location = new System.Drawing.Point(8, 37);
			lbl_Password.MinimumSize = new System.Drawing.Size(49, 17);
			lbl_Password.Name = "lbl_Password";
			lbl_Password.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_Password.Size = new System.Drawing.Size(49, 17);
			lbl_Password.TabIndex = 56;
			lbl_Password.Text = "Password:";
			// 
			// lbl_SubLoginContractAmount
			// 
			lbl_SubLoginContractAmount.AllowDrop = true;
			lbl_SubLoginContractAmount.AutoSize = true;
			lbl_SubLoginContractAmount.BackColor = System.Drawing.Color.Transparent;
			lbl_SubLoginContractAmount.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_SubLoginContractAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_SubLoginContractAmount.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_SubLoginContractAmount.Location = new System.Drawing.Point(8, 72);
			lbl_SubLoginContractAmount.MinimumSize = new System.Drawing.Size(97, 13);
			lbl_SubLoginContractAmount.Name = "lbl_SubLoginContractAmount";
			lbl_SubLoginContractAmount.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_SubLoginContractAmount.Size = new System.Drawing.Size(97, 13);
			lbl_SubLoginContractAmount.TabIndex = 55;
			lbl_SubLoginContractAmount.Text = "List/Billed Amount: $";
			lbl_SubLoginContractAmount.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lbl_SubLoginNbrOfInstalls
			// 
			lbl_SubLoginNbrOfInstalls.AllowDrop = true;
			lbl_SubLoginNbrOfInstalls.AutoSize = true;
			lbl_SubLoginNbrOfInstalls.BackColor = System.Drawing.Color.Transparent;
			lbl_SubLoginNbrOfInstalls.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_SubLoginNbrOfInstalls.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_SubLoginNbrOfInstalls.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_SubLoginNbrOfInstalls.Location = new System.Drawing.Point(0, 104);
			lbl_SubLoginNbrOfInstalls.MinimumSize = new System.Drawing.Size(69, 13);
			lbl_SubLoginNbrOfInstalls.Name = "lbl_SubLoginNbrOfInstalls";
			lbl_SubLoginNbrOfInstalls.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_SubLoginNbrOfInstalls.Size = new System.Drawing.Size(69, 13);
			lbl_SubLoginNbrOfInstalls.TabIndex = 54;
			lbl_SubLoginNbrOfInstalls.Text = "Nbr Of Installs:";
			lbl_SubLoginNbrOfInstalls.Visible = false;
			// 
			// lblSubInsContact
			// 
			lblSubInsContact.AllowDrop = true;
			lblSubInsContact.BackColor = System.Drawing.SystemColors.Control;
			lblSubInsContact.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblSubInsContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblSubInsContact.ForeColor = System.Drawing.SystemColors.ControlText;
			lblSubInsContact.Location = new System.Drawing.Point(8, 14);
			lblSubInsContact.MinimumSize = new System.Drawing.Size(57, 17);
			lblSubInsContact.Name = "lblSubInsContact";
			lblSubInsContact.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblSubInsContact.Size = new System.Drawing.Size(57, 17);
			lblSubInsContact.TabIndex = 219;
			lblSubInsContact.Text = "Login";
			lblSubInsContact.Click += new System.EventHandler(lblSubInsContact_Click);
			// 
			// frm_old_Invisible
			// 
			frm_old_Invisible.AllowDrop = true;
			frm_old_Invisible.BackColor = System.Drawing.SystemColors.Control;
			frm_old_Invisible.Controls.Add(_chkLoginFlag_3);
			frm_old_Invisible.Controls.Add(chkInstallationChatFlag);
			frm_old_Invisible.Controls.Add(chkInstallationUseLocalNotes);
			frm_old_Invisible.Controls.Add(_chkLoginFlag_8);
			frm_old_Invisible.Controls.Add(_chkLoginFlag_4);
			frm_old_Invisible.Controls.Add(txtInstallationPathToLocalDB);
			frm_old_Invisible.Controls.Add(chkInstallationActive);
			frm_old_Invisible.Controls.Add(chkActiveXFlag);
			frm_old_Invisible.Controls.Add(chkAutoCheckTS);
			frm_old_Invisible.Controls.Add(chkTerminalService);
			frm_old_Invisible.Controls.Add(cboSubBType);
			frm_old_Invisible.Controls.Add(txtWebPageTimeOut);
			frm_old_Invisible.Controls.Add(txt_Platform_Name);
			frm_old_Invisible.Controls.Add(_lblSubLabel_11);
			frm_old_Invisible.Controls.Add(_lblSubLabel_47);
			frm_old_Invisible.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frm_old_Invisible.Enabled = true;
			frm_old_Invisible.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frm_old_Invisible.ForeColor = System.Drawing.SystemColors.ControlText;
			frm_old_Invisible.Location = new System.Drawing.Point(712, 8);
			frm_old_Invisible.Name = "frm_old_Invisible";
			frm_old_Invisible.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frm_old_Invisible.Size = new System.Drawing.Size(209, 177);
			frm_old_Invisible.TabIndex = 326;
			frm_old_Invisible.Visible = false;
			// 
			// _chkLoginFlag_3
			// 
			_chkLoginFlag_3.AllowDrop = true;
			_chkLoginFlag_3.Appearance = System.Windows.Forms.Appearance.Normal;
			_chkLoginFlag_3.BackColor = System.Drawing.SystemColors.Control;
			_chkLoginFlag_3.CausesValidation = true;
			_chkLoginFlag_3.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkLoginFlag_3.CheckState = System.Windows.Forms.CheckState.Checked;
			_chkLoginFlag_3.Enabled = true;
			_chkLoginFlag_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chkLoginFlag_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_chkLoginFlag_3.Location = new System.Drawing.Point(8, 160);
			_chkLoginFlag_3.Name = "_chkLoginFlag_3";
			_chkLoginFlag_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chkLoginFlag_3.Size = new System.Drawing.Size(113, 13);
			_chkLoginFlag_3.TabIndex = 349;
			_chkLoginFlag_3.TabStop = true;
			_chkLoginFlag_3.Text = "Allow Local Notes";
			_chkLoginFlag_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkLoginFlag_3.Visible = false;
			_chkLoginFlag_3.CheckStateChanged += new System.EventHandler(chkLoginFlag_CheckStateChanged);
			_chkLoginFlag_3.MouseDown += new System.Windows.Forms.MouseEventHandler(chkLoginFlag_MouseDown);
			// 
			// chkInstallationChatFlag
			// 
			chkInstallationChatFlag.AllowDrop = true;
			chkInstallationChatFlag.Appearance = System.Windows.Forms.Appearance.Normal;
			chkInstallationChatFlag.BackColor = System.Drawing.SystemColors.Control;
			chkInstallationChatFlag.CausesValidation = true;
			chkInstallationChatFlag.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkInstallationChatFlag.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkInstallationChatFlag.Enabled = false;
			chkInstallationChatFlag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkInstallationChatFlag.ForeColor = System.Drawing.SystemColors.ControlText;
			chkInstallationChatFlag.Location = new System.Drawing.Point(128, 64);
			chkInstallationChatFlag.Name = "chkInstallationChatFlag";
			chkInstallationChatFlag.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkInstallationChatFlag.Size = new System.Drawing.Size(78, 13);
			chkInstallationChatFlag.TabIndex = 353;
			chkInstallationChatFlag.TabStop = true;
			chkInstallationChatFlag.Text = "Chat Flag";
			chkInstallationChatFlag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkInstallationChatFlag.Visible = false;
			// 
			// chkInstallationUseLocalNotes
			// 
			chkInstallationUseLocalNotes.AllowDrop = true;
			chkInstallationUseLocalNotes.Appearance = System.Windows.Forms.Appearance.Normal;
			chkInstallationUseLocalNotes.BackColor = System.Drawing.SystemColors.Control;
			chkInstallationUseLocalNotes.CausesValidation = true;
			chkInstallationUseLocalNotes.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkInstallationUseLocalNotes.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkInstallationUseLocalNotes.Enabled = false;
			chkInstallationUseLocalNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkInstallationUseLocalNotes.ForeColor = System.Drawing.SystemColors.ControlText;
			chkInstallationUseLocalNotes.Location = new System.Drawing.Point(16, 64);
			chkInstallationUseLocalNotes.Name = "chkInstallationUseLocalNotes";
			chkInstallationUseLocalNotes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkInstallationUseLocalNotes.Size = new System.Drawing.Size(103, 13);
			chkInstallationUseLocalNotes.TabIndex = 352;
			chkInstallationUseLocalNotes.TabStop = true;
			chkInstallationUseLocalNotes.Text = "Has Notes  ==>>";
			chkInstallationUseLocalNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkInstallationUseLocalNotes.Visible = true;
			chkInstallationUseLocalNotes.CheckStateChanged += new System.EventHandler(chkInstallationUseLocalNotes_CheckStateChanged);
			// 
			// _chkLoginFlag_8
			// 
			_chkLoginFlag_8.AllowDrop = true;
			_chkLoginFlag_8.Appearance = System.Windows.Forms.Appearance.Normal;
			_chkLoginFlag_8.BackColor = System.Drawing.SystemColors.Control;
			_chkLoginFlag_8.CausesValidation = true;
			_chkLoginFlag_8.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkLoginFlag_8.CheckState = System.Windows.Forms.CheckState.Checked;
			_chkLoginFlag_8.Enabled = true;
			_chkLoginFlag_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chkLoginFlag_8.ForeColor = System.Drawing.SystemColors.ControlText;
			_chkLoginFlag_8.Location = new System.Drawing.Point(144, 112);
			_chkLoginFlag_8.Name = "_chkLoginFlag_8";
			_chkLoginFlag_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chkLoginFlag_8.Size = new System.Drawing.Size(36, 13);
			_chkLoginFlag_8.TabIndex = 351;
			_chkLoginFlag_8.TabStop = true;
			_chkLoginFlag_8.Text = "bypass active x ";
			_chkLoginFlag_8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkLoginFlag_8.Visible = true;
			_chkLoginFlag_8.CheckStateChanged += new System.EventHandler(chkLoginFlag_CheckStateChanged);
			_chkLoginFlag_8.MouseDown += new System.Windows.Forms.MouseEventHandler(chkLoginFlag_MouseDown);
			// 
			// _chkLoginFlag_4
			// 
			_chkLoginFlag_4.AllowDrop = true;
			_chkLoginFlag_4.Appearance = System.Windows.Forms.Appearance.Normal;
			_chkLoginFlag_4.BackColor = System.Drawing.SystemColors.Control;
			_chkLoginFlag_4.CausesValidation = true;
			_chkLoginFlag_4.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkLoginFlag_4.CheckState = System.Windows.Forms.CheckState.Checked;
			_chkLoginFlag_4.Enabled = true;
			_chkLoginFlag_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_chkLoginFlag_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_chkLoginFlag_4.Location = new System.Drawing.Point(96, 152);
			_chkLoginFlag_4.Name = "_chkLoginFlag_4";
			_chkLoginFlag_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chkLoginFlag_4.Size = new System.Drawing.Size(87, 13);
			_chkLoginFlag_4.TabIndex = 350;
			_chkLoginFlag_4.TabStop = true;
			_chkLoginFlag_4.Text = "Allow Projects";
			_chkLoginFlag_4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_chkLoginFlag_4.Visible = false;
			_chkLoginFlag_4.CheckStateChanged += new System.EventHandler(chkLoginFlag_CheckStateChanged);
			_chkLoginFlag_4.MouseDown += new System.Windows.Forms.MouseEventHandler(chkLoginFlag_MouseDown);
			// 
			// txtInstallationPathToLocalDB
			// 
			txtInstallationPathToLocalDB.AcceptsReturn = true;
			txtInstallationPathToLocalDB.AllowDrop = true;
			txtInstallationPathToLocalDB.BackColor = System.Drawing.Color.White;
			txtInstallationPathToLocalDB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtInstallationPathToLocalDB.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtInstallationPathToLocalDB.Enabled = false;
			txtInstallationPathToLocalDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtInstallationPathToLocalDB.ForeColor = System.Drawing.SystemColors.WindowText;
			txtInstallationPathToLocalDB.Location = new System.Drawing.Point(80, 136);
			txtInstallationPathToLocalDB.MaxLength = 250;
			txtInstallationPathToLocalDB.Name = "txtInstallationPathToLocalDB";
			txtInstallationPathToLocalDB.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtInstallationPathToLocalDB.Size = new System.Drawing.Size(105, 19);
			txtInstallationPathToLocalDB.TabIndex = 346;
			txtInstallationPathToLocalDB.Visible = false;
			// 
			// chkInstallationActive
			// 
			chkInstallationActive.AllowDrop = true;
			chkInstallationActive.Appearance = System.Windows.Forms.Appearance.Normal;
			chkInstallationActive.BackColor = System.Drawing.SystemColors.Control;
			chkInstallationActive.CausesValidation = true;
			chkInstallationActive.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkInstallationActive.CheckState = System.Windows.Forms.CheckState.Checked;
			chkInstallationActive.Enabled = true;
			chkInstallationActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkInstallationActive.ForeColor = System.Drawing.SystemColors.ControlText;
			chkInstallationActive.Location = new System.Drawing.Point(24, 120);
			chkInstallationActive.Name = "chkInstallationActive";
			chkInstallationActive.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkInstallationActive.Size = new System.Drawing.Size(88, 13);
			chkInstallationActive.TabIndex = 343;
			chkInstallationActive.TabStop = true;
			chkInstallationActive.Text = "Install Active";
			chkInstallationActive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkInstallationActive.Visible = false;
			// 
			// chkActiveXFlag
			// 
			chkActiveXFlag.AllowDrop = true;
			chkActiveXFlag.Appearance = System.Windows.Forms.Appearance.Normal;
			chkActiveXFlag.BackColor = System.Drawing.SystemColors.Control;
			chkActiveXFlag.CausesValidation = true;
			chkActiveXFlag.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkActiveXFlag.CheckState = System.Windows.Forms.CheckState.Checked;
			chkActiveXFlag.Enabled = true;
			chkActiveXFlag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkActiveXFlag.ForeColor = System.Drawing.SystemColors.ControlText;
			chkActiveXFlag.Location = new System.Drawing.Point(16, 104);
			chkActiveXFlag.Name = "chkActiveXFlag";
			chkActiveXFlag.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkActiveXFlag.Size = new System.Drawing.Size(95, 13);
			chkActiveXFlag.TabIndex = 342;
			chkActiveXFlag.TabStop = true;
			chkActiveXFlag.Text = "Allow Active X";
			chkActiveXFlag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkActiveXFlag.Visible = false;
			// 
			// chkAutoCheckTS
			// 
			chkAutoCheckTS.AllowDrop = true;
			chkAutoCheckTS.Appearance = System.Windows.Forms.Appearance.Normal;
			chkAutoCheckTS.BackColor = System.Drawing.SystemColors.Control;
			chkAutoCheckTS.CausesValidation = true;
			chkAutoCheckTS.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkAutoCheckTS.CheckState = System.Windows.Forms.CheckState.Checked;
			chkAutoCheckTS.Enabled = true;
			chkAutoCheckTS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkAutoCheckTS.ForeColor = System.Drawing.SystemColors.ControlText;
			chkAutoCheckTS.Location = new System.Drawing.Point(24, 88);
			chkAutoCheckTS.Name = "chkAutoCheckTS";
			chkAutoCheckTS.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkAutoCheckTS.Size = new System.Drawing.Size(161, 13);
			chkAutoCheckTS.TabIndex = 341;
			chkAutoCheckTS.TabStop = true;
			chkAutoCheckTS.Text = "Auto Check Terminal Service";
			chkAutoCheckTS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkAutoCheckTS.Visible = false;
			chkAutoCheckTS.CheckStateChanged += new System.EventHandler(chkAutoCheckTS_CheckStateChanged);
			// 
			// chkTerminalService
			// 
			chkTerminalService.AllowDrop = true;
			chkTerminalService.Appearance = System.Windows.Forms.Appearance.Normal;
			chkTerminalService.BackColor = System.Drawing.SystemColors.Control;
			chkTerminalService.CausesValidation = true;
			chkTerminalService.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkTerminalService.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkTerminalService.Enabled = false;
			chkTerminalService.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkTerminalService.ForeColor = System.Drawing.SystemColors.ControlText;
			chkTerminalService.Location = new System.Drawing.Point(24, 72);
			chkTerminalService.Name = "chkTerminalService";
			chkTerminalService.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkTerminalService.Size = new System.Drawing.Size(133, 13);
			chkTerminalService.TabIndex = 340;
			chkTerminalService.TabStop = true;
			chkTerminalService.Text = "Using Terminal Service";
			chkTerminalService.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkTerminalService.Visible = false;
			// 
			// cboSubBType
			// 
			cboSubBType.AllowDrop = true;
			cboSubBType.BackColor = System.Drawing.SystemColors.Window;
			cboSubBType.CausesValidation = true;
			cboSubBType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboSubBType.Enabled = true;
			cboSubBType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cboSubBType.ForeColor = System.Drawing.SystemColors.WindowText;
			cboSubBType.IntegralHeight = true;
			cboSubBType.Location = new System.Drawing.Point(56, 40);
			cboSubBType.Name = "cboSubBType";
			cboSubBType.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cboSubBType.Size = new System.Drawing.Size(148, 21);
			cboSubBType.Sorted = false;
			cboSubBType.TabIndex = 329;
			cboSubBType.TabStop = true;
			cboSubBType.Visible = true;
			// 
			// txtWebPageTimeOut
			// 
			txtWebPageTimeOut.AcceptsReturn = true;
			txtWebPageTimeOut.AllowDrop = true;
			txtWebPageTimeOut.BackColor = System.Drawing.Color.White;
			txtWebPageTimeOut.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtWebPageTimeOut.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtWebPageTimeOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtWebPageTimeOut.ForeColor = System.Drawing.SystemColors.WindowText;
			txtWebPageTimeOut.Location = new System.Drawing.Point(24, 16);
			txtWebPageTimeOut.MaxLength = 2;
			txtWebPageTimeOut.Name = "txtWebPageTimeOut";
			txtWebPageTimeOut.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtWebPageTimeOut.Size = new System.Drawing.Size(27, 19);
			txtWebPageTimeOut.TabIndex = 328;
			txtWebPageTimeOut.Text = "30";
			// 
			// txt_Platform_Name
			// 
			txt_Platform_Name.AcceptsReturn = true;
			txt_Platform_Name.AllowDrop = true;
			txt_Platform_Name.BackColor = System.Drawing.Color.White;
			txt_Platform_Name.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_Platform_Name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_Platform_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_Platform_Name.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_Platform_Name.Location = new System.Drawing.Point(56, 16);
			txt_Platform_Name.MaxLength = 50;
			txt_Platform_Name.Name = "txt_Platform_Name";
			txt_Platform_Name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_Platform_Name.Size = new System.Drawing.Size(145, 19);
			txt_Platform_Name.TabIndex = 327;
			txt_Platform_Name.Visible = false;
			// 
			// _lblSubLabel_11
			// 
			_lblSubLabel_11.AllowDrop = true;
			_lblSubLabel_11.AutoSize = true;
			_lblSubLabel_11.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_11.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_11.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_11.Location = new System.Drawing.Point(8, 136);
			_lblSubLabel_11.MinimumSize = new System.Drawing.Size(69, 13);
			_lblSubLabel_11.Name = "_lblSubLabel_11";
			_lblSubLabel_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_11.Size = new System.Drawing.Size(69, 13);
			_lblSubLabel_11.TabIndex = 347;
			_lblSubLabel_11.Text = "Path To Notes";
			_lblSubLabel_11.Visible = false;
			_lblSubLabel_11.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_11.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// _lblSubLabel_47
			// 
			_lblSubLabel_47.AllowDrop = true;
			_lblSubLabel_47.AutoSize = true;
			_lblSubLabel_47.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_47.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_47.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_47.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_47.Location = new System.Drawing.Point(16, 48);
			_lblSubLabel_47.MinimumSize = new System.Drawing.Size(31, 13);
			_lblSubLabel_47.Name = "_lblSubLabel_47";
			_lblSubLabel_47.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_47.Size = new System.Drawing.Size(31, 13);
			_lblSubLabel_47.TabIndex = 330;
			_lblSubLabel_47.Text = "BType";
			_lblSubLabel_47.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_47.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// _SSTab_Subscription_TabPage1
			// 
			_SSTab_Subscription_TabPage1.Controls.Add(frmSubscriptionNotes);
			_SSTab_Subscription_TabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_SSTab_Subscription_TabPage1.Text = "Subscription Notes";
			// 
			// frmSubscriptionNotes
			// 
			frmSubscriptionNotes.AllowDrop = true;
			frmSubscriptionNotes.BackColor = System.Drawing.SystemColors.Control;
			frmSubscriptionNotes.Controls.Add(txt_SubJournalDescription);
			frmSubscriptionNotes.Controls.Add(txt_SubJournalSubject);
			frmSubscriptionNotes.Controls.Add(frmSubscriptionNotesControl);
			frmSubscriptionNotes.Controls.Add(txt_SubJournalId);
			frmSubscriptionNotes.Controls.Add(grd_SubJournalNotes);
			frmSubscriptionNotes.Controls.Add(_lblSubLabel_53);
			frmSubscriptionNotes.Controls.Add(_lblSubLabel_52);
			frmSubscriptionNotes.Controls.Add(_lblSubLabel_37);
			frmSubscriptionNotes.Controls.Add(_lblSubLabel_36);
			frmSubscriptionNotes.Controls.Add(_lblSubLabel_35);
			frmSubscriptionNotes.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmSubscriptionNotes.Enabled = true;
			frmSubscriptionNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmSubscriptionNotes.ForeColor = System.Drawing.SystemColors.ControlText;
			frmSubscriptionNotes.Location = new System.Drawing.Point(6, 6);
			frmSubscriptionNotes.Name = "frmSubscriptionNotes";
			frmSubscriptionNotes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmSubscriptionNotes.Size = new System.Drawing.Size(928, 590);
			frmSubscriptionNotes.TabIndex = 50;
			frmSubscriptionNotes.Text = "Subscription Notes";
			frmSubscriptionNotes.Visible = true;
			// 
			// txt_SubJournalDescription
			// 
			txt_SubJournalDescription.AcceptsReturn = true;
			txt_SubJournalDescription.AllowDrop = true;
			txt_SubJournalDescription.BackColor = System.Drawing.SystemColors.Window;
			txt_SubJournalDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_SubJournalDescription.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_SubJournalDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_SubJournalDescription.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_SubJournalDescription.Location = new System.Drawing.Point(9, 72);
			txt_SubJournalDescription.MaxLength = 2000;
			txt_SubJournalDescription.Multiline = true;
			txt_SubJournalDescription.Name = "txt_SubJournalDescription";
			txt_SubJournalDescription.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_SubJournalDescription.Size = new System.Drawing.Size(905, 75);
			txt_SubJournalDescription.TabIndex = 28;
			// 
			// txt_SubJournalSubject
			// 
			txt_SubJournalSubject.AcceptsReturn = true;
			txt_SubJournalSubject.AllowDrop = true;
			txt_SubJournalSubject.BackColor = System.Drawing.SystemColors.Window;
			txt_SubJournalSubject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_SubJournalSubject.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_SubJournalSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_SubJournalSubject.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_SubJournalSubject.Location = new System.Drawing.Point(66, 27);
			txt_SubJournalSubject.MaxLength = 120;
			txt_SubJournalSubject.Name = "txt_SubJournalSubject";
			txt_SubJournalSubject.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_SubJournalSubject.Size = new System.Drawing.Size(527, 21);
			txt_SubJournalSubject.TabIndex = 27;
			// 
			// frmSubscriptionNotesControl
			// 
			frmSubscriptionNotesControl.AllowDrop = true;
			frmSubscriptionNotesControl.BackColor = System.Drawing.SystemColors.Control;
			frmSubscriptionNotesControl.Controls.Add(cmdSubNoteNew);
			frmSubscriptionNotesControl.Controls.Add(cmdSubNoteSave);
			frmSubscriptionNotesControl.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmSubscriptionNotesControl.Enabled = true;
			frmSubscriptionNotesControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmSubscriptionNotesControl.ForeColor = System.Drawing.SystemColors.ControlText;
			frmSubscriptionNotesControl.Location = new System.Drawing.Point(603, 15);
			frmSubscriptionNotesControl.Name = "frmSubscriptionNotesControl";
			frmSubscriptionNotesControl.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmSubscriptionNotesControl.Size = new System.Drawing.Size(175, 49);
			frmSubscriptionNotesControl.TabIndex = 51;
			frmSubscriptionNotesControl.Visible = true;
			// 
			// cmdSubNoteNew
			// 
			cmdSubNoteNew.AllowDrop = true;
			cmdSubNoteNew.BackColor = System.Drawing.SystemColors.Control;
			cmdSubNoteNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdSubNoteNew.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdSubNoteNew.Location = new System.Drawing.Point(18, 15);
			cmdSubNoteNew.Name = "cmdSubNoteNew";
			cmdSubNoteNew.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdSubNoteNew.Size = new System.Drawing.Size(55, 25);
			cmdSubNoteNew.TabIndex = 30;
			cmdSubNoteNew.Text = "&New";
			cmdSubNoteNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdSubNoteNew.UseVisualStyleBackColor = false;
			cmdSubNoteNew.Click += new System.EventHandler(cmdSubNoteNew_Click);
			// 
			// cmdSubNoteSave
			// 
			cmdSubNoteSave.AllowDrop = true;
			cmdSubNoteSave.BackColor = System.Drawing.SystemColors.Control;
			cmdSubNoteSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdSubNoteSave.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdSubNoteSave.Location = new System.Drawing.Point(90, 15);
			cmdSubNoteSave.Name = "cmdSubNoteSave";
			cmdSubNoteSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdSubNoteSave.Size = new System.Drawing.Size(55, 25);
			cmdSubNoteSave.TabIndex = 31;
			cmdSubNoteSave.Text = "&Save";
			cmdSubNoteSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdSubNoteSave.UseVisualStyleBackColor = false;
			cmdSubNoteSave.Click += new System.EventHandler(cmdSubNoteSave_Click);
			// 
			// txt_SubJournalId
			// 
			txt_SubJournalId.AcceptsReturn = true;
			txt_SubJournalId.AllowDrop = true;
			txt_SubJournalId.BackColor = System.Drawing.SystemColors.Window;
			txt_SubJournalId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_SubJournalId.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_SubJournalId.Enabled = false;
			txt_SubJournalId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_SubJournalId.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_SubJournalId.Location = new System.Drawing.Point(822, 39);
			txt_SubJournalId.MaxLength = 120;
			txt_SubJournalId.Name = "txt_SubJournalId";
			txt_SubJournalId.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_SubJournalId.Size = new System.Drawing.Size(68, 21);
			txt_SubJournalId.TabIndex = 33;
			txt_SubJournalId.Text = "0";
			txt_SubJournalId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// grd_SubJournalNotes
			// 
			grd_SubJournalNotes.AllowDrop = true;
			grd_SubJournalNotes.AllowUserToAddRows = false;
			grd_SubJournalNotes.AllowUserToDeleteRows = false;
			grd_SubJournalNotes.AllowUserToResizeColumns = false;
			grd_SubJournalNotes.AllowUserToResizeRows = false;
			grd_SubJournalNotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_SubJournalNotes.ColumnsCount = 2;
			grd_SubJournalNotes.FixedColumns = 1;
			grd_SubJournalNotes.FixedRows = 1;
			grd_SubJournalNotes.Location = new System.Drawing.Point(6, 153);
			grd_SubJournalNotes.Name = "grd_SubJournalNotes";
			grd_SubJournalNotes.ReadOnly = true;
			grd_SubJournalNotes.RowsCount = 2;
			grd_SubJournalNotes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			grd_SubJournalNotes.ShowCellToolTips = false;
			grd_SubJournalNotes.Size = new System.Drawing.Size(919, 408);
			grd_SubJournalNotes.StandardTab = true;
			grd_SubJournalNotes.TabIndex = 29;
			grd_SubJournalNotes.Click += new System.EventHandler(grd_SubJournalNotes_Click);
			// 
			// _lblSubLabel_53
			// 
			_lblSubLabel_53.AllowDrop = true;
			_lblSubLabel_53.AutoSize = true;
			_lblSubLabel_53.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_53.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_53.Enabled = false;
			_lblSubLabel_53.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_53.ForeColor = System.Drawing.Color.Blue;
			_lblSubLabel_53.Location = new System.Drawing.Point(842, 568);
			_lblSubLabel_53.MinimumSize = new System.Drawing.Size(65, 13);
			_lblSubLabel_53.Name = "_lblSubLabel_53";
			_lblSubLabel_53.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_53.Size = new System.Drawing.Size(65, 13);
			_lblSubLabel_53.TabIndex = 292;
			_lblSubLabel_53.Text = "Stop Loading";
			_lblSubLabel_53.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lblSubLabel_53.Visible = false;
			_lblSubLabel_53.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_53.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// _lblSubLabel_52
			// 
			_lblSubLabel_52.AllowDrop = true;
			_lblSubLabel_52.AutoSize = true;
			_lblSubLabel_52.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_52.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_52.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_52.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_52.Location = new System.Drawing.Point(6, 568);
			_lblSubLabel_52.MinimumSize = new System.Drawing.Size(317, 13);
			_lblSubLabel_52.Name = "_lblSubLabel_52";
			_lblSubLabel_52.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_52.Size = new System.Drawing.Size(317, 13);
			_lblSubLabel_52.TabIndex = 291;
			_lblSubLabel_52.Text = "Loading Subscription Notes -  #,### of #,### Total Records";
			_lblSubLabel_52.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_52.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// _lblSubLabel_37
			// 
			_lblSubLabel_37.AllowDrop = true;
			_lblSubLabel_37.AutoSize = true;
			_lblSubLabel_37.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_37.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_37.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_37.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_37.Location = new System.Drawing.Point(830, 20);
			_lblSubLabel_37.MinimumSize = new System.Drawing.Size(46, 13);
			_lblSubLabel_37.Name = "_lblSubLabel_37";
			_lblSubLabel_37.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_37.Size = new System.Drawing.Size(46, 13);
			_lblSubLabel_37.TabIndex = 207;
			_lblSubLabel_37.Text = "Journal Id";
			_lblSubLabel_37.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_37.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// _lblSubLabel_36
			// 
			_lblSubLabel_36.AllowDrop = true;
			_lblSubLabel_36.AutoSize = true;
			_lblSubLabel_36.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_36.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_36.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_36.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_36.Location = new System.Drawing.Point(8, 52);
			_lblSubLabel_36.MinimumSize = new System.Drawing.Size(53, 13);
			_lblSubLabel_36.Name = "_lblSubLabel_36";
			_lblSubLabel_36.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_36.Size = new System.Drawing.Size(53, 13);
			_lblSubLabel_36.TabIndex = 206;
			_lblSubLabel_36.Text = "Description";
			_lblSubLabel_36.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_36.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// _lblSubLabel_35
			// 
			_lblSubLabel_35.AllowDrop = true;
			_lblSubLabel_35.AutoSize = true;
			_lblSubLabel_35.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_35.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_35.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_35.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_35.Location = new System.Drawing.Point(14, 30);
			_lblSubLabel_35.MinimumSize = new System.Drawing.Size(36, 13);
			_lblSubLabel_35.Name = "_lblSubLabel_35";
			_lblSubLabel_35.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_35.Size = new System.Drawing.Size(36, 13);
			_lblSubLabel_35.TabIndex = 205;
			_lblSubLabel_35.Text = "Subject";
			_lblSubLabel_35.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_35.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// _SSTab_Subscription_TabPage2
			// 
			_SSTab_Subscription_TabPage2.Controls.Add(frmSubscriptionContracts);
			_SSTab_Subscription_TabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_SSTab_Subscription_TabPage2.Text = "Contracts/Documents";
			// 
			// frmSubscriptionContracts
			// 
			frmSubscriptionContracts.AllowDrop = true;
			frmSubscriptionContracts.BackColor = System.Drawing.SystemColors.Control;
			frmSubscriptionContracts.Controls.Add(txtSubExpirationDate);
			frmSubscriptionContracts.Controls.Add(txtSubDragDocument);
			frmSubscriptionContracts.Controls.Add(txtSubDocumentDate);
			frmSubscriptionContracts.Controls.Add(cmbSubDocumentType);
			frmSubscriptionContracts.Controls.Add(txtSubDocumentId);
			frmSubscriptionContracts.Controls.Add(frmSubDocumentControl);
			frmSubscriptionContracts.Controls.Add(txtSubDocumentSubject);
			frmSubscriptionContracts.Controls.Add(txtSubDocumentDescription);
			frmSubscriptionContracts.Controls.Add(grd_SubDocument);
			frmSubscriptionContracts.Controls.Add(calSubDocumentDate);
			frmSubscriptionContracts.Controls.Add(_wbSubBrowser1_0);
			frmSubscriptionContracts.Controls.Add(calSubExpirationDate);
			frmSubscriptionContracts.Controls.Add(_lblSubLabel_49);
			frmSubscriptionContracts.Controls.Add(_lblSubLabel_48);
			frmSubscriptionContracts.Controls.Add(_lblSubLabel_41);
			frmSubscriptionContracts.Controls.Add(_lblSubLabel_40);
			frmSubscriptionContracts.Controls.Add(_lblSubLabel_39);
			frmSubscriptionContracts.Controls.Add(_lblSubLabel_38);
			frmSubscriptionContracts.Controls.Add(lblSubDocumentId);
			frmSubscriptionContracts.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmSubscriptionContracts.Enabled = true;
			frmSubscriptionContracts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmSubscriptionContracts.ForeColor = System.Drawing.SystemColors.ControlText;
			frmSubscriptionContracts.Location = new System.Drawing.Point(6, 6);
			frmSubscriptionContracts.Name = "frmSubscriptionContracts";
			frmSubscriptionContracts.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmSubscriptionContracts.Size = new System.Drawing.Size(925, 586);
			frmSubscriptionContracts.TabIndex = 64;
			frmSubscriptionContracts.Text = "Contracts/Documents";
			frmSubscriptionContracts.Visible = true;
			// 
			// txtSubExpirationDate
			// 
			txtSubExpirationDate.AcceptsReturn = true;
			txtSubExpirationDate.AllowDrop = true;
			txtSubExpirationDate.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txtSubExpirationDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtSubExpirationDate.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtSubExpirationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtSubExpirationDate.ForeColor = System.Drawing.SystemColors.WindowText;
			txtSubExpirationDate.Location = new System.Drawing.Point(640, 70);
			txtSubExpirationDate.MaxLength = 0;
			txtSubExpirationDate.Name = "txtSubExpirationDate";
			txtSubExpirationDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtSubExpirationDate.Size = new System.Drawing.Size(82, 19);
			txtSubExpirationDate.TabIndex = 38;
			txtSubExpirationDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			txtSubExpirationDate.Enter += new System.EventHandler(txtSubExpirationDate_Enter);
			txtSubExpirationDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtSubExpirationDate_KeyPress);
			txtSubExpirationDate.Leave += new System.EventHandler(txtSubExpirationDate_Leave);
			// 
			// txtSubDragDocument
			// 
			txtSubDragDocument.AcceptsReturn = true;
			txtSubDragDocument.AllowDrop = true;
			txtSubDragDocument.BackColor = System.Drawing.SystemColors.Menu;
			txtSubDragDocument.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtSubDragDocument.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtSubDragDocument.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtSubDragDocument.ForeColor = System.Drawing.SystemColors.WindowText;
			txtSubDragDocument.Location = new System.Drawing.Point(548, 108);
			txtSubDragDocument.MaxLength = 2000;
			txtSubDragDocument.Multiline = true;
			txtSubDragDocument.Name = "txtSubDragDocument";
			txtSubDragDocument.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtSubDragDocument.Size = new System.Drawing.Size(179, 75);
			txtSubDragDocument.TabIndex = 71;
			txtSubDragDocument.TabStop = false;
			txtSubDragDocument.Text = "Drag Document Here\r\n";
			txtSubDragDocument.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			txtSubDragDocument.DoubleClick += new System.EventHandler(txtSubDragDocument_DoubleClick);
			// 
			// txtSubDocumentDate
			// 
			txtSubDocumentDate.AcceptsReturn = true;
			txtSubDocumentDate.AllowDrop = true;
			txtSubDocumentDate.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txtSubDocumentDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtSubDocumentDate.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtSubDocumentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtSubDocumentDate.ForeColor = System.Drawing.SystemColors.WindowText;
			txtSubDocumentDate.Location = new System.Drawing.Point(642, 30);
			txtSubDocumentDate.MaxLength = 0;
			txtSubDocumentDate.Name = "txtSubDocumentDate";
			txtSubDocumentDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtSubDocumentDate.Size = new System.Drawing.Size(82, 19);
			txtSubDocumentDate.TabIndex = 37;
			txtSubDocumentDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			txtSubDocumentDate.Enter += new System.EventHandler(txtSubDocumentDate_Enter);
			txtSubDocumentDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtSubDocumentDate_KeyPress);
			// 
			// cmbSubDocumentType
			// 
			cmbSubDocumentType.AllowDrop = true;
			cmbSubDocumentType.BackColor = System.Drawing.SystemColors.Window;
			cmbSubDocumentType.CausesValidation = true;
			cmbSubDocumentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cmbSubDocumentType.Enabled = true;
			cmbSubDocumentType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmbSubDocumentType.ForeColor = System.Drawing.SystemColors.WindowText;
			cmbSubDocumentType.IntegralHeight = true;
			cmbSubDocumentType.Location = new System.Drawing.Point(95, 42);
			cmbSubDocumentType.Name = "cmbSubDocumentType";
			cmbSubDocumentType.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmbSubDocumentType.Size = new System.Drawing.Size(212, 21);
			cmbSubDocumentType.Sorted = false;
			cmbSubDocumentType.TabIndex = 34;
			cmbSubDocumentType.TabStop = true;
			cmbSubDocumentType.Visible = true;
			cmbSubDocumentType.SelectionChangeCommitted += new System.EventHandler(cmbSubDocumentType_SelectionChangeCommitted);
			// 
			// txtSubDocumentId
			// 
			txtSubDocumentId.AcceptsReturn = true;
			txtSubDocumentId.AllowDrop = true;
			txtSubDocumentId.BackColor = System.Drawing.SystemColors.Window;
			txtSubDocumentId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtSubDocumentId.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtSubDocumentId.Enabled = false;
			txtSubDocumentId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtSubDocumentId.ForeColor = System.Drawing.SystemColors.WindowText;
			txtSubDocumentId.Location = new System.Drawing.Point(96, 16);
			txtSubDocumentId.MaxLength = 120;
			txtSubDocumentId.Name = "txtSubDocumentId";
			txtSubDocumentId.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtSubDocumentId.Size = new System.Drawing.Size(68, 21);
			txtSubDocumentId.TabIndex = 32;
			txtSubDocumentId.Text = "0";
			txtSubDocumentId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// frmSubDocumentControl
			// 
			frmSubDocumentControl.AllowDrop = true;
			frmSubDocumentControl.BackColor = System.Drawing.SystemColors.Control;
			frmSubDocumentControl.Controls.Add(cmdSubDocumentMove);
			frmSubDocumentControl.Controls.Add(cmdSubDocumentDelete);
			frmSubDocumentControl.Controls.Add(cmdSubDocumentView);
			frmSubDocumentControl.Controls.Add(cmdSubDocumentSave);
			frmSubDocumentControl.Controls.Add(cmdSubDocumentNew);
			frmSubDocumentControl.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmSubDocumentControl.Enabled = true;
			frmSubDocumentControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmSubDocumentControl.ForeColor = System.Drawing.SystemColors.ControlText;
			frmSubDocumentControl.Location = new System.Drawing.Point(314, 8);
			frmSubDocumentControl.Name = "frmSubDocumentControl";
			frmSubDocumentControl.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmSubDocumentControl.Size = new System.Drawing.Size(313, 49);
			frmSubDocumentControl.TabIndex = 65;
			frmSubDocumentControl.Visible = true;
			// 
			// cmdSubDocumentMove
			// 
			cmdSubDocumentMove.AllowDrop = true;
			cmdSubDocumentMove.BackColor = System.Drawing.SystemColors.Control;
			cmdSubDocumentMove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdSubDocumentMove.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdSubDocumentMove.Location = new System.Drawing.Point(249, 15);
			cmdSubDocumentMove.Name = "cmdSubDocumentMove";
			cmdSubDocumentMove.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdSubDocumentMove.Size = new System.Drawing.Size(55, 25);
			cmdSubDocumentMove.TabIndex = 170;
			cmdSubDocumentMove.Text = "&Move";
			cmdSubDocumentMove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdSubDocumentMove.UseVisualStyleBackColor = false;
			cmdSubDocumentMove.Click += new System.EventHandler(cmdSubDocumentMove_Click);
			// 
			// cmdSubDocumentDelete
			// 
			cmdSubDocumentDelete.AllowDrop = true;
			cmdSubDocumentDelete.BackColor = System.Drawing.SystemColors.Control;
			cmdSubDocumentDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdSubDocumentDelete.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdSubDocumentDelete.Location = new System.Drawing.Point(189, 15);
			cmdSubDocumentDelete.Name = "cmdSubDocumentDelete";
			cmdSubDocumentDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdSubDocumentDelete.Size = new System.Drawing.Size(55, 25);
			cmdSubDocumentDelete.TabIndex = 70;
			cmdSubDocumentDelete.Text = "&Delete";
			cmdSubDocumentDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdSubDocumentDelete.UseVisualStyleBackColor = false;
			cmdSubDocumentDelete.Click += new System.EventHandler(cmdSubDocumentDelete_Click);
			// 
			// cmdSubDocumentView
			// 
			cmdSubDocumentView.AllowDrop = true;
			cmdSubDocumentView.BackColor = System.Drawing.SystemColors.Control;
			cmdSubDocumentView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdSubDocumentView.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdSubDocumentView.Location = new System.Drawing.Point(129, 15);
			cmdSubDocumentView.Name = "cmdSubDocumentView";
			cmdSubDocumentView.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdSubDocumentView.Size = new System.Drawing.Size(55, 25);
			cmdSubDocumentView.TabIndex = 69;
			cmdSubDocumentView.Text = "&View";
			cmdSubDocumentView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdSubDocumentView.UseVisualStyleBackColor = false;
			cmdSubDocumentView.Click += new System.EventHandler(cmdSubDocumentView_Click);
			// 
			// cmdSubDocumentSave
			// 
			cmdSubDocumentSave.AllowDrop = true;
			cmdSubDocumentSave.BackColor = System.Drawing.SystemColors.Control;
			cmdSubDocumentSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdSubDocumentSave.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdSubDocumentSave.Location = new System.Drawing.Point(67, 15);
			cmdSubDocumentSave.Name = "cmdSubDocumentSave";
			cmdSubDocumentSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdSubDocumentSave.Size = new System.Drawing.Size(55, 25);
			cmdSubDocumentSave.TabIndex = 68;
			cmdSubDocumentSave.Text = "&Save";
			cmdSubDocumentSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdSubDocumentSave.UseVisualStyleBackColor = false;
			cmdSubDocumentSave.Click += new System.EventHandler(cmdSubDocumentSave_Click);
			// 
			// cmdSubDocumentNew
			// 
			cmdSubDocumentNew.AllowDrop = true;
			cmdSubDocumentNew.BackColor = System.Drawing.SystemColors.Control;
			cmdSubDocumentNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdSubDocumentNew.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdSubDocumentNew.Location = new System.Drawing.Point(6, 15);
			cmdSubDocumentNew.Name = "cmdSubDocumentNew";
			cmdSubDocumentNew.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdSubDocumentNew.Size = new System.Drawing.Size(55, 25);
			cmdSubDocumentNew.TabIndex = 67;
			cmdSubDocumentNew.Text = "&New";
			cmdSubDocumentNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdSubDocumentNew.UseVisualStyleBackColor = false;
			cmdSubDocumentNew.Click += new System.EventHandler(cmdSubDocumentNew_Click);
			// 
			// txtSubDocumentSubject
			// 
			txtSubDocumentSubject.AcceptsReturn = true;
			txtSubDocumentSubject.AllowDrop = true;
			txtSubDocumentSubject.BackColor = System.Drawing.SystemColors.Window;
			txtSubDocumentSubject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtSubDocumentSubject.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtSubDocumentSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtSubDocumentSubject.ForeColor = System.Drawing.SystemColors.WindowText;
			txtSubDocumentSubject.Location = new System.Drawing.Point(95, 67);
			txtSubDocumentSubject.MaxLength = 120;
			txtSubDocumentSubject.Name = "txtSubDocumentSubject";
			txtSubDocumentSubject.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtSubDocumentSubject.Size = new System.Drawing.Size(531, 21);
			txtSubDocumentSubject.TabIndex = 35;
			// 
			// txtSubDocumentDescription
			// 
			txtSubDocumentDescription.AcceptsReturn = true;
			txtSubDocumentDescription.AllowDrop = true;
			txtSubDocumentDescription.BackColor = System.Drawing.SystemColors.Window;
			txtSubDocumentDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtSubDocumentDescription.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtSubDocumentDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtSubDocumentDescription.ForeColor = System.Drawing.SystemColors.WindowText;
			txtSubDocumentDescription.Location = new System.Drawing.Point(9, 108);
			txtSubDocumentDescription.MaxLength = 2000;
			txtSubDocumentDescription.Multiline = true;
			txtSubDocumentDescription.Name = "txtSubDocumentDescription";
			txtSubDocumentDescription.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtSubDocumentDescription.Size = new System.Drawing.Size(533, 75);
			txtSubDocumentDescription.TabIndex = 36;
			// 
			// grd_SubDocument
			// 
			grd_SubDocument.AllowDrop = true;
			grd_SubDocument.AllowUserToAddRows = false;
			grd_SubDocument.AllowUserToDeleteRows = false;
			grd_SubDocument.AllowUserToResizeColumns = false;
			grd_SubDocument.AllowUserToResizeRows = false;
			grd_SubDocument.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_SubDocument.ColumnsCount = 2;
			grd_SubDocument.FixedColumns = 1;
			grd_SubDocument.FixedRows = 1;
			grd_SubDocument.Location = new System.Drawing.Point(9, 189);
			grd_SubDocument.Name = "grd_SubDocument";
			grd_SubDocument.ReadOnly = true;
			grd_SubDocument.RowsCount = 2;
			grd_SubDocument.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			grd_SubDocument.ShowCellToolTips = false;
			grd_SubDocument.Size = new System.Drawing.Size(901, 85);
			grd_SubDocument.StandardTab = true;
			grd_SubDocument.TabIndex = 40;
			grd_SubDocument.Click += new System.EventHandler(grd_SubDocument_Click);
			// 
			// calSubDocumentDate
			// 
			calSubDocumentDate.AllowDrop = true;
			calSubDocumentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			calSubDocumentDate.ForeColor = System.Drawing.SystemColors.ControlText;
			calSubDocumentDate.Location = new System.Drawing.Point(734, 28);
			calSubDocumentDate.Name = "calSubDocumentDate";
			calSubDocumentDate.Size = new System.Drawing.Size(178, 154);
			calSubDocumentDate.TabIndex = 39;
			calSubDocumentDate.TabStop = false;
			// 
			// _wbSubBrowser1_0
			// 
			_wbSubBrowser1_0.AllowWebBrowserDrop = true;
			_wbSubBrowser1_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_wbSubBrowser1_0.Location = new System.Drawing.Point(10, 279);
			_wbSubBrowser1_0.Name = "_wbSubBrowser1_0";
			_wbSubBrowser1_0.Size = new System.Drawing.Size(907, 295);
			_wbSubBrowser1_0.TabIndex = 41;
			// 
			// calSubExpirationDate
			// 
			calSubExpirationDate.AllowDrop = true;
			calSubExpirationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			calSubExpirationDate.ForeColor = System.Drawing.SystemColors.ControlText;
			calSubExpirationDate.Location = new System.Drawing.Point(734, 28);
			calSubExpirationDate.Name = "calSubExpirationDate";
			calSubExpirationDate.Size = new System.Drawing.Size(178, 154);
			calSubExpirationDate.TabIndex = 288;
			calSubExpirationDate.TabStop = false;
			// 
			// _lblSubLabel_49
			// 
			_lblSubLabel_49.AllowDrop = true;
			_lblSubLabel_49.AutoSize = true;
			_lblSubLabel_49.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_49.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_49.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_49.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_49.Location = new System.Drawing.Point(743, 12);
			_lblSubLabel_49.MinimumSize = new System.Drawing.Size(146, 13);
			_lblSubLabel_49.Name = "_lblSubLabel_49";
			_lblSubLabel_49.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_49.Size = new System.Drawing.Size(146, 13);
			_lblSubLabel_49.TabIndex = 289;
			_lblSubLabel_49.Text = "Calendar - Document Date";
			_lblSubLabel_49.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lblSubLabel_49.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_49.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// _lblSubLabel_48
			// 
			_lblSubLabel_48.AllowDrop = true;
			_lblSubLabel_48.AutoSize = true;
			_lblSubLabel_48.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_48.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_48.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_48.ForeColor = System.Drawing.Color.Black;
			_lblSubLabel_48.Location = new System.Drawing.Point(642, 54);
			_lblSubLabel_48.MinimumSize = new System.Drawing.Size(72, 13);
			_lblSubLabel_48.Name = "_lblSubLabel_48";
			_lblSubLabel_48.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_48.Size = new System.Drawing.Size(72, 13);
			_lblSubLabel_48.TabIndex = 287;
			_lblSubLabel_48.Text = "Expiration Date";
			_lblSubLabel_48.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lblSubLabel_48.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_48.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// _lblSubLabel_41
			// 
			_lblSubLabel_41.AllowDrop = true;
			_lblSubLabel_41.AutoSize = true;
			_lblSubLabel_41.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_41.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_41.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_41.ForeColor = System.Drawing.Color.Black;
			_lblSubLabel_41.Location = new System.Drawing.Point(641, 14);
			_lblSubLabel_41.MinimumSize = new System.Drawing.Size(77, 13);
			_lblSubLabel_41.Name = "_lblSubLabel_41";
			_lblSubLabel_41.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_41.Size = new System.Drawing.Size(77, 13);
			_lblSubLabel_41.TabIndex = 211;
			_lblSubLabel_41.Text = "Document Date";
			_lblSubLabel_41.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lblSubLabel_41.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_41.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// _lblSubLabel_40
			// 
			_lblSubLabel_40.AllowDrop = true;
			_lblSubLabel_40.AutoSize = true;
			_lblSubLabel_40.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_40.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_40.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_40.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_40.Location = new System.Drawing.Point(10, 90);
			_lblSubLabel_40.MinimumSize = new System.Drawing.Size(53, 13);
			_lblSubLabel_40.Name = "_lblSubLabel_40";
			_lblSubLabel_40.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_40.Size = new System.Drawing.Size(53, 13);
			_lblSubLabel_40.TabIndex = 210;
			_lblSubLabel_40.Text = "Description";
			_lblSubLabel_40.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_40.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// _lblSubLabel_39
			// 
			_lblSubLabel_39.AllowDrop = true;
			_lblSubLabel_39.AutoSize = true;
			_lblSubLabel_39.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_39.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_39.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_39.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_39.Location = new System.Drawing.Point(10, 68);
			_lblSubLabel_39.MinimumSize = new System.Drawing.Size(36, 13);
			_lblSubLabel_39.Name = "_lblSubLabel_39";
			_lblSubLabel_39.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_39.Size = new System.Drawing.Size(36, 13);
			_lblSubLabel_39.TabIndex = 209;
			_lblSubLabel_39.Text = "Subject";
			_lblSubLabel_39.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_39.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// _lblSubLabel_38
			// 
			_lblSubLabel_38.AllowDrop = true;
			_lblSubLabel_38.AutoSize = true;
			_lblSubLabel_38.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_38.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_38.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_38.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_38.Location = new System.Drawing.Point(10, 44);
			_lblSubLabel_38.MinimumSize = new System.Drawing.Size(76, 13);
			_lblSubLabel_38.Name = "_lblSubLabel_38";
			_lblSubLabel_38.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_38.Size = new System.Drawing.Size(76, 13);
			_lblSubLabel_38.TabIndex = 208;
			_lblSubLabel_38.Text = "Document Type";
			_lblSubLabel_38.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_38.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// lblSubDocumentId
			// 
			lblSubDocumentId.AllowDrop = true;
			lblSubDocumentId.BackColor = System.Drawing.SystemColors.Control;
			lblSubDocumentId.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblSubDocumentId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblSubDocumentId.ForeColor = System.Drawing.SystemColors.ControlText;
			lblSubDocumentId.Location = new System.Drawing.Point(10, 18);
			lblSubDocumentId.MinimumSize = new System.Drawing.Size(70, 16);
			lblSubDocumentId.Name = "lblSubDocumentId";
			lblSubDocumentId.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblSubDocumentId.Size = new System.Drawing.Size(70, 16);
			lblSubDocumentId.TabIndex = 66;
			lblSubDocumentId.Text = "Document Id";
			lblSubDocumentId.Click += new System.EventHandler(lblSubDocumentId_Click);
			// 
			// _SSTab_Subscription_TabPage3
			// 
			_SSTab_Subscription_TabPage3.Controls.Add(frm_SubExecutionFormsDisplay);
			_SSTab_Subscription_TabPage3.Controls.Add(frm_SubExecutionFormsGrid);
			_SSTab_Subscription_TabPage3.Controls.Add(frm_SubExecutionFormsData);
			_SSTab_Subscription_TabPage3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_SSTab_Subscription_TabPage3.Text = "Execution Forms";
			// 
			// frm_SubExecutionFormsDisplay
			// 
			frm_SubExecutionFormsDisplay.AllowDrop = true;
			frm_SubExecutionFormsDisplay.BackColor = System.Drawing.SystemColors.Control;
			frm_SubExecutionFormsDisplay.Controls.Add(lstb_SubExecutionFormsDisplay);
			frm_SubExecutionFormsDisplay.Controls.Add(_wbSubBrowser1_3);
			frm_SubExecutionFormsDisplay.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frm_SubExecutionFormsDisplay.Enabled = true;
			frm_SubExecutionFormsDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frm_SubExecutionFormsDisplay.ForeColor = System.Drawing.SystemColors.ControlText;
			frm_SubExecutionFormsDisplay.Location = new System.Drawing.Point(12, 256);
			frm_SubExecutionFormsDisplay.Name = "frm_SubExecutionFormsDisplay";
			frm_SubExecutionFormsDisplay.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frm_SubExecutionFormsDisplay.Size = new System.Drawing.Size(913, 343);
			frm_SubExecutionFormsDisplay.TabIndex = 92;
			frm_SubExecutionFormsDisplay.Visible = true;
			// 
			// lstb_SubExecutionFormsDisplay
			// 
			lstb_SubExecutionFormsDisplay.AllowDrop = true;
			lstb_SubExecutionFormsDisplay.BackColor = System.Drawing.SystemColors.Window;
			lstb_SubExecutionFormsDisplay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			lstb_SubExecutionFormsDisplay.CausesValidation = true;
			lstb_SubExecutionFormsDisplay.Enabled = true;
			lstb_SubExecutionFormsDisplay.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 255);
			lstb_SubExecutionFormsDisplay.ForeColor = System.Drawing.SystemColors.WindowText;
			lstb_SubExecutionFormsDisplay.IntegralHeight = true;
			lstb_SubExecutionFormsDisplay.Location = new System.Drawing.Point(6, 14);
			lstb_SubExecutionFormsDisplay.MultiColumn = false;
			lstb_SubExecutionFormsDisplay.Name = "lstb_SubExecutionFormsDisplay";
			lstb_SubExecutionFormsDisplay.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lstb_SubExecutionFormsDisplay.Size = new System.Drawing.Size(901, 319);
			lstb_SubExecutionFormsDisplay.Sorted = false;
			lstb_SubExecutionFormsDisplay.TabIndex = 87;
			lstb_SubExecutionFormsDisplay.TabStop = true;
			lstb_SubExecutionFormsDisplay.Visible = true;
			// 
			// _wbSubBrowser1_3
			// 
			_wbSubBrowser1_3.AllowWebBrowserDrop = true;
			_wbSubBrowser1_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_wbSubBrowser1_3.Location = new System.Drawing.Point(6, 14);
			_wbSubBrowser1_3.Name = "_wbSubBrowser1_3";
			_wbSubBrowser1_3.Size = new System.Drawing.Size(901, 321);
			_wbSubBrowser1_3.TabIndex = 175;
			// 
			// frm_SubExecutionFormsGrid
			// 
			frm_SubExecutionFormsGrid.AllowDrop = true;
			frm_SubExecutionFormsGrid.BackColor = System.Drawing.SystemColors.Control;
			frm_SubExecutionFormsGrid.Controls.Add(grd_SubExecutionForms);
			frm_SubExecutionFormsGrid.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frm_SubExecutionFormsGrid.Enabled = true;
			frm_SubExecutionFormsGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frm_SubExecutionFormsGrid.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
			frm_SubExecutionFormsGrid.Location = new System.Drawing.Point(12, 124);
			frm_SubExecutionFormsGrid.Name = "frm_SubExecutionFormsGrid";
			frm_SubExecutionFormsGrid.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frm_SubExecutionFormsGrid.Size = new System.Drawing.Size(913, 133);
			frm_SubExecutionFormsGrid.TabIndex = 73;
			frm_SubExecutionFormsGrid.Text = "Execution Forms";
			frm_SubExecutionFormsGrid.Visible = true;
			frm_SubExecutionFormsGrid.Click += new System.EventHandler(frm_SubExecutionFormsGrid_Click);
			// 
			// grd_SubExecutionForms
			// 
			grd_SubExecutionForms.AllowDrop = true;
			grd_SubExecutionForms.AllowUserToAddRows = false;
			grd_SubExecutionForms.AllowUserToDeleteRows = false;
			grd_SubExecutionForms.AllowUserToResizeColumns = false;
			grd_SubExecutionForms.AllowUserToResizeRows = false;
			grd_SubExecutionForms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_SubExecutionForms.ColumnsCount = 2;
			grd_SubExecutionForms.FixedColumns = 1;
			grd_SubExecutionForms.FixedRows = 1;
			grd_SubExecutionForms.Location = new System.Drawing.Point(9, 14);
			grd_SubExecutionForms.Name = "grd_SubExecutionForms";
			grd_SubExecutionForms.ReadOnly = true;
			grd_SubExecutionForms.RowsCount = 2;
			grd_SubExecutionForms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			grd_SubExecutionForms.ShowCellToolTips = false;
			grd_SubExecutionForms.Size = new System.Drawing.Size(895, 112);
			grd_SubExecutionForms.StandardTab = true;
			grd_SubExecutionForms.TabIndex = 86;
			grd_SubExecutionForms.Click += new System.EventHandler(grd_SubExecutionForms_Click);
			// 
			// frm_SubExecutionFormsData
			// 
			frm_SubExecutionFormsData.AllowDrop = true;
			frm_SubExecutionFormsData.BackColor = System.Drawing.SystemColors.Control;
			frm_SubExecutionFormsData.Controls.Add(_txtSubExc_Type_1);
			frm_SubExecutionFormsData.Controls.Add(_txtSubExc_MonthlyAmt_2);
			frm_SubExecutionFormsData.Controls.Add(_txtSubExc_MonthlyAmt_1);
			frm_SubExecutionFormsData.Controls.Add(txtSubExc_Notes);
			frm_SubExecutionFormsData.Controls.Add(txtSubExc_Status);
			frm_SubExecutionFormsData.Controls.Add(_txtSubExc_MonthlyAmt_0);
			frm_SubExecutionFormsData.Controls.Add(_txtSubExc_Type_0);
			frm_SubExecutionFormsData.Controls.Add(txtSubExc_Service);
			frm_SubExecutionFormsData.Controls.Add(txtSubExc_ContractNbr);
			frm_SubExecutionFormsData.Controls.Add(txtSubExc_ADisableDate);
			frm_SubExecutionFormsData.Controls.Add(txtSubExc_SrvChgDate);
			frm_SubExecutionFormsData.Controls.Add(txtSubExc_CLetterDate);
			frm_SubExecutionFormsData.Controls.Add(txtSubExc_ContractDate);
			frm_SubExecutionFormsData.Controls.Add(txtSubExc_ExcDate);
			frm_SubExecutionFormsData.Controls.Add(txtSubExc_SubId);
			frm_SubExecutionFormsData.Controls.Add(_lblSubExc_Type_2);
			frm_SubExecutionFormsData.Controls.Add(_lblSubExc_MonthlyAmt_6);
			frm_SubExecutionFormsData.Controls.Add(_lblSubExc_MonthlyAmt_5);
			frm_SubExecutionFormsData.Controls.Add(_lblSubExc_MonthlyAmt_4);
			frm_SubExecutionFormsData.Controls.Add(_lblSubExc_MonthlyAmt_3);
			frm_SubExecutionFormsData.Controls.Add(_lblSubExc_Type_1);
			frm_SubExecutionFormsData.Controls.Add(_lblSubExc_MonthlyAmt_2);
			frm_SubExecutionFormsData.Controls.Add(_lblSubExc_MonthlyAmt_1);
			frm_SubExecutionFormsData.Controls.Add(_lblSubLabel_43);
			frm_SubExecutionFormsData.Controls.Add(_lblSubLabel_42);
			frm_SubExecutionFormsData.Controls.Add(_lblSubExc_MonthlyAmt_0);
			frm_SubExecutionFormsData.Controls.Add(_lblSubExc_Type_0);
			frm_SubExecutionFormsData.Controls.Add(lblSubExc_Service);
			frm_SubExecutionFormsData.Controls.Add(lblSubExc_ContractNbr);
			frm_SubExecutionFormsData.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frm_SubExecutionFormsData.Enabled = true;
			frm_SubExecutionFormsData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frm_SubExecutionFormsData.ForeColor = System.Drawing.SystemColors.ControlText;
			frm_SubExecutionFormsData.Location = new System.Drawing.Point(12, 4);
			frm_SubExecutionFormsData.Name = "frm_SubExecutionFormsData";
			frm_SubExecutionFormsData.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frm_SubExecutionFormsData.Size = new System.Drawing.Size(913, 120);
			frm_SubExecutionFormsData.TabIndex = 72;
			frm_SubExecutionFormsData.Visible = true;
			// 
			// _txtSubExc_Type_1
			// 
			_txtSubExc_Type_1.AcceptsReturn = true;
			_txtSubExc_Type_1.AllowDrop = true;
			_txtSubExc_Type_1.BackColor = System.Drawing.Color.White;
			_txtSubExc_Type_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txtSubExc_Type_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtSubExc_Type_1.Enabled = false;
			_txtSubExc_Type_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtSubExc_Type_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtSubExc_Type_1.Location = new System.Drawing.Point(356, 52);
			_txtSubExc_Type_1.MaxLength = 0;
			_txtSubExc_Type_1.Name = "_txtSubExc_Type_1";
			_txtSubExc_Type_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtSubExc_Type_1.Size = new System.Drawing.Size(200, 19);
			_txtSubExc_Type_1.TabIndex = 298;
			// 
			// _txtSubExc_MonthlyAmt_2
			// 
			_txtSubExc_MonthlyAmt_2.AcceptsReturn = true;
			_txtSubExc_MonthlyAmt_2.AllowDrop = true;
			_txtSubExc_MonthlyAmt_2.BackColor = System.Drawing.Color.White;
			_txtSubExc_MonthlyAmt_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txtSubExc_MonthlyAmt_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtSubExc_MonthlyAmt_2.Enabled = false;
			_txtSubExc_MonthlyAmt_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtSubExc_MonthlyAmt_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtSubExc_MonthlyAmt_2.Location = new System.Drawing.Point(657, 31);
			_txtSubExc_MonthlyAmt_2.MaxLength = 0;
			_txtSubExc_MonthlyAmt_2.Name = "_txtSubExc_MonthlyAmt_2";
			_txtSubExc_MonthlyAmt_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtSubExc_MonthlyAmt_2.Size = new System.Drawing.Size(61, 19);
			_txtSubExc_MonthlyAmt_2.TabIndex = 294;
			_txtSubExc_MonthlyAmt_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// _txtSubExc_MonthlyAmt_1
			// 
			_txtSubExc_MonthlyAmt_1.AcceptsReturn = true;
			_txtSubExc_MonthlyAmt_1.AllowDrop = true;
			_txtSubExc_MonthlyAmt_1.BackColor = System.Drawing.Color.White;
			_txtSubExc_MonthlyAmt_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txtSubExc_MonthlyAmt_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtSubExc_MonthlyAmt_1.Enabled = false;
			_txtSubExc_MonthlyAmt_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtSubExc_MonthlyAmt_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtSubExc_MonthlyAmt_1.Location = new System.Drawing.Point(344, 31);
			_txtSubExc_MonthlyAmt_1.MaxLength = 0;
			_txtSubExc_MonthlyAmt_1.Name = "_txtSubExc_MonthlyAmt_1";
			_txtSubExc_MonthlyAmt_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtSubExc_MonthlyAmt_1.Size = new System.Drawing.Size(61, 19);
			_txtSubExc_MonthlyAmt_1.TabIndex = 293;
			_txtSubExc_MonthlyAmt_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtSubExc_Notes
			// 
			txtSubExc_Notes.AcceptsReturn = true;
			txtSubExc_Notes.AllowDrop = true;
			txtSubExc_Notes.BackColor = System.Drawing.Color.White;
			txtSubExc_Notes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtSubExc_Notes.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtSubExc_Notes.Enabled = false;
			txtSubExc_Notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtSubExc_Notes.ForeColor = System.Drawing.SystemColors.WindowText;
			txtSubExc_Notes.Location = new System.Drawing.Point(35, 75);
			txtSubExc_Notes.MaxLength = 0;
			txtSubExc_Notes.Multiline = true;
			txtSubExc_Notes.Name = "txtSubExc_Notes";
			txtSubExc_Notes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtSubExc_Notes.Size = new System.Drawing.Size(869, 40);
			txtSubExc_Notes.TabIndex = 85;
			// 
			// txtSubExc_Status
			// 
			txtSubExc_Status.AcceptsReturn = true;
			txtSubExc_Status.AllowDrop = true;
			txtSubExc_Status.BackColor = System.Drawing.Color.White;
			txtSubExc_Status.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtSubExc_Status.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtSubExc_Status.Enabled = false;
			txtSubExc_Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtSubExc_Status.ForeColor = System.Drawing.SystemColors.WindowText;
			txtSubExc_Status.Location = new System.Drawing.Point(828, 32);
			txtSubExc_Status.MaxLength = 0;
			txtSubExc_Status.Name = "txtSubExc_Status";
			txtSubExc_Status.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtSubExc_Status.Size = new System.Drawing.Size(46, 19);
			txtSubExc_Status.TabIndex = 84;
			txtSubExc_Status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// _txtSubExc_MonthlyAmt_0
			// 
			_txtSubExc_MonthlyAmt_0.AcceptsReturn = true;
			_txtSubExc_MonthlyAmt_0.AllowDrop = true;
			_txtSubExc_MonthlyAmt_0.BackColor = System.Drawing.Color.White;
			_txtSubExc_MonthlyAmt_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txtSubExc_MonthlyAmt_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtSubExc_MonthlyAmt_0.Enabled = false;
			_txtSubExc_MonthlyAmt_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtSubExc_MonthlyAmt_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtSubExc_MonthlyAmt_0.Location = new System.Drawing.Point(496, 31);
			_txtSubExc_MonthlyAmt_0.MaxLength = 0;
			_txtSubExc_MonthlyAmt_0.Name = "_txtSubExc_MonthlyAmt_0";
			_txtSubExc_MonthlyAmt_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtSubExc_MonthlyAmt_0.Size = new System.Drawing.Size(61, 19);
			_txtSubExc_MonthlyAmt_0.TabIndex = 78;
			_txtSubExc_MonthlyAmt_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// _txtSubExc_Type_0
			// 
			_txtSubExc_Type_0.AcceptsReturn = true;
			_txtSubExc_Type_0.AllowDrop = true;
			_txtSubExc_Type_0.BackColor = System.Drawing.Color.White;
			_txtSubExc_Type_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txtSubExc_Type_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtSubExc_Type_0.Enabled = false;
			_txtSubExc_Type_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtSubExc_Type_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtSubExc_Type_0.Location = new System.Drawing.Point(84, 53);
			_txtSubExc_Type_0.MaxLength = 0;
			_txtSubExc_Type_0.Name = "_txtSubExc_Type_0";
			_txtSubExc_Type_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtSubExc_Type_0.Size = new System.Drawing.Size(178, 19);
			_txtSubExc_Type_0.TabIndex = 77;
			// 
			// txtSubExc_Service
			// 
			txtSubExc_Service.AcceptsReturn = true;
			txtSubExc_Service.AllowDrop = true;
			txtSubExc_Service.BackColor = System.Drawing.Color.White;
			txtSubExc_Service.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtSubExc_Service.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtSubExc_Service.Enabled = false;
			txtSubExc_Service.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtSubExc_Service.ForeColor = System.Drawing.SystemColors.WindowText;
			txtSubExc_Service.Location = new System.Drawing.Point(206, 33);
			txtSubExc_Service.MaxLength = 0;
			txtSubExc_Service.Name = "txtSubExc_Service";
			txtSubExc_Service.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtSubExc_Service.Size = new System.Drawing.Size(52, 19);
			txtSubExc_Service.TabIndex = 76;
			txtSubExc_Service.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtSubExc_ContractNbr
			// 
			txtSubExc_ContractNbr.AcceptsReturn = true;
			txtSubExc_ContractNbr.AllowDrop = true;
			txtSubExc_ContractNbr.BackColor = System.Drawing.Color.White;
			txtSubExc_ContractNbr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtSubExc_ContractNbr.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtSubExc_ContractNbr.Enabled = false;
			txtSubExc_ContractNbr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtSubExc_ContractNbr.ForeColor = System.Drawing.SystemColors.WindowText;
			txtSubExc_ContractNbr.Location = new System.Drawing.Point(243, 11);
			txtSubExc_ContractNbr.MaxLength = 0;
			txtSubExc_ContractNbr.Name = "txtSubExc_ContractNbr";
			txtSubExc_ContractNbr.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtSubExc_ContractNbr.Size = new System.Drawing.Size(73, 19);
			txtSubExc_ContractNbr.TabIndex = 75;
			txtSubExc_ContractNbr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtSubExc_ADisableDate
			// 
			txtSubExc_ADisableDate.AcceptsReturn = true;
			txtSubExc_ADisableDate.AllowDrop = true;
			txtSubExc_ADisableDate.BackColor = System.Drawing.Color.White;
			txtSubExc_ADisableDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtSubExc_ADisableDate.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtSubExc_ADisableDate.Enabled = false;
			txtSubExc_ADisableDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtSubExc_ADisableDate.ForeColor = System.Drawing.SystemColors.WindowText;
			txtSubExc_ADisableDate.Location = new System.Drawing.Point(828, 11);
			txtSubExc_ADisableDate.MaxLength = 0;
			txtSubExc_ADisableDate.Name = "txtSubExc_ADisableDate";
			txtSubExc_ADisableDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtSubExc_ADisableDate.Size = new System.Drawing.Size(76, 19);
			txtSubExc_ADisableDate.TabIndex = 83;
			txtSubExc_ADisableDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtSubExc_SrvChgDate
			// 
			txtSubExc_SrvChgDate.AcceptsReturn = true;
			txtSubExc_SrvChgDate.AllowDrop = true;
			txtSubExc_SrvChgDate.BackColor = System.Drawing.Color.White;
			txtSubExc_SrvChgDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtSubExc_SrvChgDate.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtSubExc_SrvChgDate.Enabled = false;
			txtSubExc_SrvChgDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtSubExc_SrvChgDate.ForeColor = System.Drawing.SystemColors.WindowText;
			txtSubExc_SrvChgDate.Location = new System.Drawing.Point(657, 11);
			txtSubExc_SrvChgDate.MaxLength = 0;
			txtSubExc_SrvChgDate.Name = "txtSubExc_SrvChgDate";
			txtSubExc_SrvChgDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtSubExc_SrvChgDate.Size = new System.Drawing.Size(76, 19);
			txtSubExc_SrvChgDate.TabIndex = 82;
			txtSubExc_SrvChgDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtSubExc_CLetterDate
			// 
			txtSubExc_CLetterDate.AcceptsReturn = true;
			txtSubExc_CLetterDate.AllowDrop = true;
			txtSubExc_CLetterDate.BackColor = System.Drawing.Color.White;
			txtSubExc_CLetterDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtSubExc_CLetterDate.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtSubExc_CLetterDate.Enabled = false;
			txtSubExc_CLetterDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtSubExc_CLetterDate.ForeColor = System.Drawing.SystemColors.WindowText;
			txtSubExc_CLetterDate.Location = new System.Drawing.Point(482, 11);
			txtSubExc_CLetterDate.MaxLength = 0;
			txtSubExc_CLetterDate.Name = "txtSubExc_CLetterDate";
			txtSubExc_CLetterDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtSubExc_CLetterDate.Size = new System.Drawing.Size(76, 19);
			txtSubExc_CLetterDate.TabIndex = 81;
			txtSubExc_CLetterDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtSubExc_ContractDate
			// 
			txtSubExc_ContractDate.AcceptsReturn = true;
			txtSubExc_ContractDate.AllowDrop = true;
			txtSubExc_ContractDate.BackColor = System.Drawing.Color.White;
			txtSubExc_ContractDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtSubExc_ContractDate.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtSubExc_ContractDate.Enabled = false;
			txtSubExc_ContractDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtSubExc_ContractDate.ForeColor = System.Drawing.SystemColors.WindowText;
			txtSubExc_ContractDate.Location = new System.Drawing.Point(330, 11);
			txtSubExc_ContractDate.MaxLength = 0;
			txtSubExc_ContractDate.Name = "txtSubExc_ContractDate";
			txtSubExc_ContractDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtSubExc_ContractDate.Size = new System.Drawing.Size(76, 19);
			txtSubExc_ContractDate.TabIndex = 80;
			txtSubExc_ContractDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtSubExc_ExcDate
			// 
			txtSubExc_ExcDate.AcceptsReturn = true;
			txtSubExc_ExcDate.AllowDrop = true;
			txtSubExc_ExcDate.BackColor = System.Drawing.Color.White;
			txtSubExc_ExcDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtSubExc_ExcDate.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtSubExc_ExcDate.Enabled = false;
			txtSubExc_ExcDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtSubExc_ExcDate.ForeColor = System.Drawing.SystemColors.WindowText;
			txtSubExc_ExcDate.Location = new System.Drawing.Point(84, 32);
			txtSubExc_ExcDate.MaxLength = 0;
			txtSubExc_ExcDate.Name = "txtSubExc_ExcDate";
			txtSubExc_ExcDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtSubExc_ExcDate.Size = new System.Drawing.Size(76, 19);
			txtSubExc_ExcDate.TabIndex = 79;
			txtSubExc_ExcDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtSubExc_SubId
			// 
			txtSubExc_SubId.AcceptsReturn = true;
			txtSubExc_SubId.AllowDrop = true;
			txtSubExc_SubId.BackColor = System.Drawing.Color.White;
			txtSubExc_SubId.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtSubExc_SubId.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtSubExc_SubId.Enabled = false;
			txtSubExc_SubId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtSubExc_SubId.ForeColor = System.Drawing.SystemColors.WindowText;
			txtSubExc_SubId.Location = new System.Drawing.Point(84, 11);
			txtSubExc_SubId.MaxLength = 0;
			txtSubExc_SubId.Name = "txtSubExc_SubId";
			txtSubExc_SubId.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtSubExc_SubId.Size = new System.Drawing.Size(49, 19);
			txtSubExc_SubId.TabIndex = 74;
			txtSubExc_SubId.Text = "0";
			txtSubExc_SubId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// _lblSubExc_Type_2
			// 
			_lblSubExc_Type_2.AllowDrop = true;
			_lblSubExc_Type_2.BackColor = System.Drawing.SystemColors.Control;
			_lblSubExc_Type_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubExc_Type_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubExc_Type_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubExc_Type_2.Location = new System.Drawing.Point(0, 80);
			_lblSubExc_Type_2.MinimumSize = new System.Drawing.Size(49, 16);
			_lblSubExc_Type_2.Name = "_lblSubExc_Type_2";
			_lblSubExc_Type_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubExc_Type_2.Size = new System.Drawing.Size(49, 16);
			_lblSubExc_Type_2.TabIndex = 367;
			_lblSubExc_Type_2.Text = "Notes";
			// 
			// _lblSubExc_MonthlyAmt_6
			// 
			_lblSubExc_MonthlyAmt_6.AllowDrop = true;
			_lblSubExc_MonthlyAmt_6.AutoSize = true;
			_lblSubExc_MonthlyAmt_6.BackColor = System.Drawing.Color.Transparent;
			_lblSubExc_MonthlyAmt_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubExc_MonthlyAmt_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubExc_MonthlyAmt_6.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubExc_MonthlyAmt_6.Location = new System.Drawing.Point(416, 16);
			_lblSubExc_MonthlyAmt_6.MinimumSize = new System.Drawing.Size(60, 13);
			_lblSubExc_MonthlyAmt_6.Name = "_lblSubExc_MonthlyAmt_6";
			_lblSubExc_MonthlyAmt_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubExc_MonthlyAmt_6.Size = new System.Drawing.Size(60, 13);
			_lblSubExc_MonthlyAmt_6.TabIndex = 366;
			_lblSubExc_MonthlyAmt_6.Text = "CLetter Date";
			// 
			// _lblSubExc_MonthlyAmt_5
			// 
			_lblSubExc_MonthlyAmt_5.AllowDrop = true;
			_lblSubExc_MonthlyAmt_5.AutoSize = true;
			_lblSubExc_MonthlyAmt_5.BackColor = System.Drawing.Color.Transparent;
			_lblSubExc_MonthlyAmt_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubExc_MonthlyAmt_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubExc_MonthlyAmt_5.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubExc_MonthlyAmt_5.Location = new System.Drawing.Point(736, 16);
			_lblSubExc_MonthlyAmt_5.MinimumSize = new System.Drawing.Size(86, 13);
			_lblSubExc_MonthlyAmt_5.Name = "_lblSubExc_MonthlyAmt_5";
			_lblSubExc_MonthlyAmt_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubExc_MonthlyAmt_5.Size = new System.Drawing.Size(86, 13);
			_lblSubExc_MonthlyAmt_5.TabIndex = 365;
			_lblSubExc_MonthlyAmt_5.Text = "Auto Disable Date";
			// 
			// _lblSubExc_MonthlyAmt_4
			// 
			_lblSubExc_MonthlyAmt_4.AllowDrop = true;
			_lblSubExc_MonthlyAmt_4.AutoSize = true;
			_lblSubExc_MonthlyAmt_4.BackColor = System.Drawing.Color.Transparent;
			_lblSubExc_MonthlyAmt_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubExc_MonthlyAmt_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubExc_MonthlyAmt_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubExc_MonthlyAmt_4.Location = new System.Drawing.Point(784, 32);
			_lblSubExc_MonthlyAmt_4.MinimumSize = new System.Drawing.Size(30, 13);
			_lblSubExc_MonthlyAmt_4.Name = "_lblSubExc_MonthlyAmt_4";
			_lblSubExc_MonthlyAmt_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubExc_MonthlyAmt_4.Size = new System.Drawing.Size(30, 13);
			_lblSubExc_MonthlyAmt_4.TabIndex = 364;
			_lblSubExc_MonthlyAmt_4.Text = "Status";
			// 
			// _lblSubExc_MonthlyAmt_3
			// 
			_lblSubExc_MonthlyAmt_3.AllowDrop = true;
			_lblSubExc_MonthlyAmt_3.AutoSize = true;
			_lblSubExc_MonthlyAmt_3.BackColor = System.Drawing.Color.Transparent;
			_lblSubExc_MonthlyAmt_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubExc_MonthlyAmt_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubExc_MonthlyAmt_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubExc_MonthlyAmt_3.Location = new System.Drawing.Point(560, 16);
			_lblSubExc_MonthlyAmt_3.MinimumSize = new System.Drawing.Size(84, 13);
			_lblSubExc_MonthlyAmt_3.Name = "_lblSubExc_MonthlyAmt_3";
			_lblSubExc_MonthlyAmt_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubExc_MonthlyAmt_3.Size = new System.Drawing.Size(84, 13);
			_lblSubExc_MonthlyAmt_3.TabIndex = 363;
			_lblSubExc_MonthlyAmt_3.Text = "Service Chg Date";
			// 
			// _lblSubExc_Type_1
			// 
			_lblSubExc_Type_1.AllowDrop = true;
			_lblSubExc_Type_1.BackColor = System.Drawing.SystemColors.Control;
			_lblSubExc_Type_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubExc_Type_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubExc_Type_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubExc_Type_1.Location = new System.Drawing.Point(286, 56);
			_lblSubExc_Type_1.MinimumSize = new System.Drawing.Size(71, 16);
			_lblSubExc_Type_1.Name = "_lblSubExc_Type_1";
			_lblSubExc_Type_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubExc_Type_1.Size = new System.Drawing.Size(71, 16);
			_lblSubExc_Type_1.TabIndex = 297;
			_lblSubExc_Type_1.Text = "Action Name";
			// 
			// _lblSubExc_MonthlyAmt_2
			// 
			_lblSubExc_MonthlyAmt_2.AllowDrop = true;
			_lblSubExc_MonthlyAmt_2.AutoSize = true;
			_lblSubExc_MonthlyAmt_2.BackColor = System.Drawing.Color.Transparent;
			_lblSubExc_MonthlyAmt_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubExc_MonthlyAmt_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubExc_MonthlyAmt_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubExc_MonthlyAmt_2.Location = new System.Drawing.Point(562, 35);
			_lblSubExc_MonthlyAmt_2.MinimumSize = new System.Drawing.Size(88, 13);
			_lblSubExc_MonthlyAmt_2.Name = "_lblSubExc_MonthlyAmt_2";
			_lblSubExc_MonthlyAmt_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubExc_MonthlyAmt_2.Size = new System.Drawing.Size(88, 13);
			_lblSubExc_MonthlyAmt_2.TabIndex = 296;
			_lblSubExc_MonthlyAmt_2.Text = "Mthly Net Chg Fee";
			// 
			// _lblSubExc_MonthlyAmt_1
			// 
			_lblSubExc_MonthlyAmt_1.AllowDrop = true;
			_lblSubExc_MonthlyAmt_1.AutoSize = true;
			_lblSubExc_MonthlyAmt_1.BackColor = System.Drawing.Color.Transparent;
			_lblSubExc_MonthlyAmt_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubExc_MonthlyAmt_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubExc_MonthlyAmt_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubExc_MonthlyAmt_1.Location = new System.Drawing.Point(270, 35);
			_lblSubExc_MonthlyAmt_1.MinimumSize = new System.Drawing.Size(65, 13);
			_lblSubExc_MonthlyAmt_1.Name = "_lblSubExc_MonthlyAmt_1";
			_lblSubExc_MonthlyAmt_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubExc_MonthlyAmt_1.Size = new System.Drawing.Size(65, 13);
			_lblSubExc_MonthlyAmt_1.TabIndex = 295;
			_lblSubExc_MonthlyAmt_1.Text = "Mthly List Fee";
			// 
			// _lblSubLabel_43
			// 
			_lblSubLabel_43.AllowDrop = true;
			_lblSubLabel_43.AutoSize = true;
			_lblSubLabel_43.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_43.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_43.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_43.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_43.Location = new System.Drawing.Point(4, 34);
			_lblSubLabel_43.MinimumSize = new System.Drawing.Size(73, 13);
			_lblSubLabel_43.Name = "_lblSubLabel_43";
			_lblSubLabel_43.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_43.Size = new System.Drawing.Size(73, 13);
			_lblSubLabel_43.TabIndex = 213;
			_lblSubLabel_43.Text = "Execution Date";
			_lblSubLabel_43.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_43.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// _lblSubLabel_42
			// 
			_lblSubLabel_42.AllowDrop = true;
			_lblSubLabel_42.AutoSize = true;
			_lblSubLabel_42.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_42.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_42.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_42.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_42.Location = new System.Drawing.Point(4, 14);
			_lblSubLabel_42.MinimumSize = new System.Drawing.Size(72, 13);
			_lblSubLabel_42.Name = "_lblSubLabel_42";
			_lblSubLabel_42.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_42.Size = new System.Drawing.Size(72, 13);
			_lblSubLabel_42.TabIndex = 212;
			_lblSubLabel_42.Text = "Subscription ID";
			_lblSubLabel_42.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_42.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// _lblSubExc_MonthlyAmt_0
			// 
			_lblSubExc_MonthlyAmt_0.AllowDrop = true;
			_lblSubExc_MonthlyAmt_0.AutoSize = true;
			_lblSubExc_MonthlyAmt_0.BackColor = System.Drawing.Color.Transparent;
			_lblSubExc_MonthlyAmt_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubExc_MonthlyAmt_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubExc_MonthlyAmt_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubExc_MonthlyAmt_0.Location = new System.Drawing.Point(414, 37);
			_lblSubExc_MonthlyAmt_0.MinimumSize = new System.Drawing.Size(74, 13);
			_lblSubExc_MonthlyAmt_0.Name = "_lblSubExc_MonthlyAmt_0";
			_lblSubExc_MonthlyAmt_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubExc_MonthlyAmt_0.Size = new System.Drawing.Size(74, 13);
			_lblSubExc_MonthlyAmt_0.TabIndex = 91;
			_lblSubExc_MonthlyAmt_0.Text = "Mthly Billed Fee";
			// 
			// _lblSubExc_Type_0
			// 
			_lblSubExc_Type_0.AllowDrop = true;
			_lblSubExc_Type_0.BackColor = System.Drawing.SystemColors.Control;
			_lblSubExc_Type_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubExc_Type_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubExc_Type_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubExc_Type_0.Location = new System.Drawing.Point(4, 56);
			_lblSubExc_Type_0.MinimumSize = new System.Drawing.Size(49, 16);
			_lblSubExc_Type_0.Name = "_lblSubExc_Type_0";
			_lblSubExc_Type_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubExc_Type_0.Size = new System.Drawing.Size(49, 16);
			_lblSubExc_Type_0.TabIndex = 90;
			_lblSubExc_Type_0.Text = "Exc Type";
			// 
			// lblSubExc_Service
			// 
			lblSubExc_Service.AllowDrop = true;
			lblSubExc_Service.AutoSize = true;
			lblSubExc_Service.BackColor = System.Drawing.Color.Transparent;
			lblSubExc_Service.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblSubExc_Service.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblSubExc_Service.ForeColor = System.Drawing.SystemColors.ControlText;
			lblSubExc_Service.Location = new System.Drawing.Point(159, 37);
			lblSubExc_Service.MinimumSize = new System.Drawing.Size(36, 13);
			lblSubExc_Service.Name = "lblSubExc_Service";
			lblSubExc_Service.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblSubExc_Service.Size = new System.Drawing.Size(36, 13);
			lblSubExc_Service.TabIndex = 89;
			lblSubExc_Service.Text = "Service";
			// 
			// lblSubExc_ContractNbr
			// 
			lblSubExc_ContractNbr.AllowDrop = true;
			lblSubExc_ContractNbr.AutoSize = true;
			lblSubExc_ContractNbr.BackColor = System.Drawing.Color.Transparent;
			lblSubExc_ContractNbr.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblSubExc_ContractNbr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblSubExc_ContractNbr.ForeColor = System.Drawing.SystemColors.ControlText;
			lblSubExc_ContractNbr.Location = new System.Drawing.Point(141, 14);
			lblSubExc_ContractNbr.MinimumSize = new System.Drawing.Size(94, 13);
			lblSubExc_ContractNbr.Name = "lblSubExc_ContractNbr";
			lblSubExc_ContractNbr.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblSubExc_ContractNbr.Size = new System.Drawing.Size(94, 13);
			lblSubExc_ContractNbr.TabIndex = 88;
			lblSubExc_ContractNbr.Text = "Contract Nbr / Date";
			// 
			// _SSTab_Subscription_TabPage4
			// 
			_SSTab_Subscription_TabPage4.Controls.Add(frmSubSIDocControl);
			_SSTab_Subscription_TabPage4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_SSTab_Subscription_TabPage4.Text = "Service Interruption";
			// 
			// frmSubSIDocControl
			// 
			frmSubSIDocControl.AllowDrop = true;
			frmSubSIDocControl.BackColor = System.Drawing.SystemColors.Control;
			frmSubSIDocControl.Controls.Add(txtSubSISubId);
			frmSubSIDocControl.Controls.Add(txtSubSIApprovedBy);
			frmSubSIDocControl.Controls.Add(frmSubSIDocCheckBoxes);
			frmSubSIDocControl.Controls.Add(frmSubSIDocDates);
			frmSubSIDocControl.Controls.Add(frmSubSIDocView);
			frmSubSIDocControl.Controls.Add(txtSubSIDocId);
			frmSubSIDocControl.Controls.Add(grd_SubSIDocument);
			frmSubSIDocControl.Controls.Add(_wbSubBrowser1_1);
			frmSubSIDocControl.Controls.Add(lblSubSIViewOnly);
			frmSubSIDocControl.Controls.Add(lblSubSISubId);
			frmSubSIDocControl.Controls.Add(lblSubSIApprovedBy);
			frmSubSIDocControl.Controls.Add(lblSubSIDocId);
			frmSubSIDocControl.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmSubSIDocControl.Enabled = true;
			frmSubSIDocControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmSubSIDocControl.ForeColor = System.Drawing.SystemColors.ControlText;
			frmSubSIDocControl.Location = new System.Drawing.Point(6, 7);
			frmSubSIDocControl.Name = "frmSubSIDocControl";
			frmSubSIDocControl.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmSubSIDocControl.Size = new System.Drawing.Size(925, 586);
			frmSubSIDocControl.TabIndex = 101;
			frmSubSIDocControl.Text = "Service Interruption";
			frmSubSIDocControl.Visible = true;
			// 
			// txtSubSISubId
			// 
			txtSubSISubId.AcceptsReturn = true;
			txtSubSISubId.AllowDrop = true;
			txtSubSISubId.BackColor = System.Drawing.SystemColors.Window;
			txtSubSISubId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtSubSISubId.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtSubSISubId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtSubSISubId.ForeColor = System.Drawing.SystemColors.WindowText;
			txtSubSISubId.Location = new System.Drawing.Point(90, 54);
			txtSubSISubId.MaxLength = 120;
			txtSubSISubId.Name = "txtSubSISubId";
			txtSubSISubId.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtSubSISubId.Size = new System.Drawing.Size(68, 21);
			txtSubSISubId.TabIndex = 103;
			txtSubSISubId.Text = "0";
			txtSubSISubId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtSubSIApprovedBy
			// 
			txtSubSIApprovedBy.AcceptsReturn = true;
			txtSubSIApprovedBy.AllowDrop = true;
			txtSubSIApprovedBy.BackColor = System.Drawing.SystemColors.Window;
			txtSubSIApprovedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtSubSIApprovedBy.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtSubSIApprovedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtSubSIApprovedBy.ForeColor = System.Drawing.SystemColors.WindowText;
			txtSubSIApprovedBy.Location = new System.Drawing.Point(90, 78);
			txtSubSIApprovedBy.MaxLength = 120;
			txtSubSIApprovedBy.Name = "txtSubSIApprovedBy";
			txtSubSIApprovedBy.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtSubSIApprovedBy.Size = new System.Drawing.Size(191, 21);
			txtSubSIApprovedBy.TabIndex = 104;
			// 
			// frmSubSIDocCheckBoxes
			// 
			frmSubSIDocCheckBoxes.AllowDrop = true;
			frmSubSIDocCheckBoxes.BackColor = System.Drawing.SystemColors.Control;
			frmSubSIDocCheckBoxes.Controls.Add(chkSubSIChangeAutoDisable);
			frmSubSIDocCheckBoxes.Controls.Add(chkSubSIAccoutingIssues);
			frmSubSIDocCheckBoxes.Controls.Add(chkSubSICancellation);
			frmSubSIDocCheckBoxes.Controls.Add(chkSubSIStopUpdates);
			frmSubSIDocCheckBoxes.Controls.Add(chkSubSIStopEvolution);
			frmSubSIDocCheckBoxes.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmSubSIDocCheckBoxes.Enabled = true;
			frmSubSIDocCheckBoxes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmSubSIDocCheckBoxes.ForeColor = System.Drawing.SystemColors.ControlText;
			frmSubSIDocCheckBoxes.Location = new System.Drawing.Point(537, 24);
			frmSubSIDocCheckBoxes.Name = "frmSubSIDocCheckBoxes";
			frmSubSIDocCheckBoxes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmSubSIDocCheckBoxes.Size = new System.Drawing.Size(256, 85);
			frmSubSIDocCheckBoxes.TabIndex = 121;
			frmSubSIDocCheckBoxes.Visible = true;
			// 
			// chkSubSIChangeAutoDisable
			// 
			chkSubSIChangeAutoDisable.AllowDrop = true;
			chkSubSIChangeAutoDisable.Appearance = System.Windows.Forms.Appearance.Normal;
			chkSubSIChangeAutoDisable.BackColor = System.Drawing.SystemColors.Control;
			chkSubSIChangeAutoDisable.CausesValidation = true;
			chkSubSIChangeAutoDisable.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkSubSIChangeAutoDisable.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkSubSIChangeAutoDisable.Enabled = true;
			chkSubSIChangeAutoDisable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkSubSIChangeAutoDisable.ForeColor = System.Drawing.SystemColors.ControlText;
			chkSubSIChangeAutoDisable.Location = new System.Drawing.Point(123, 36);
			chkSubSIChangeAutoDisable.Name = "chkSubSIChangeAutoDisable";
			chkSubSIChangeAutoDisable.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkSubSIChangeAutoDisable.Size = new System.Drawing.Size(122, 13);
			chkSubSIChangeAutoDisable.TabIndex = 112;
			chkSubSIChangeAutoDisable.TabStop = true;
			chkSubSIChangeAutoDisable.Text = "Change Auto Disable";
			chkSubSIChangeAutoDisable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkSubSIChangeAutoDisable.Visible = true;
			// 
			// chkSubSIAccoutingIssues
			// 
			chkSubSIAccoutingIssues.AllowDrop = true;
			chkSubSIAccoutingIssues.Appearance = System.Windows.Forms.Appearance.Normal;
			chkSubSIAccoutingIssues.BackColor = System.Drawing.SystemColors.Control;
			chkSubSIAccoutingIssues.CausesValidation = true;
			chkSubSIAccoutingIssues.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkSubSIAccoutingIssues.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkSubSIAccoutingIssues.Enabled = true;
			chkSubSIAccoutingIssues.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkSubSIAccoutingIssues.ForeColor = System.Drawing.SystemColors.ControlText;
			chkSubSIAccoutingIssues.Location = new System.Drawing.Point(123, 15);
			chkSubSIAccoutingIssues.Name = "chkSubSIAccoutingIssues";
			chkSubSIAccoutingIssues.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkSubSIAccoutingIssues.Size = new System.Drawing.Size(119, 13);
			chkSubSIAccoutingIssues.TabIndex = 111;
			chkSubSIAccoutingIssues.TabStop = true;
			chkSubSIAccoutingIssues.Text = "Accounting Issues";
			chkSubSIAccoutingIssues.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkSubSIAccoutingIssues.Visible = true;
			// 
			// chkSubSICancellation
			// 
			chkSubSICancellation.AllowDrop = true;
			chkSubSICancellation.Appearance = System.Windows.Forms.Appearance.Normal;
			chkSubSICancellation.BackColor = System.Drawing.SystemColors.Control;
			chkSubSICancellation.CausesValidation = true;
			chkSubSICancellation.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkSubSICancellation.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkSubSICancellation.Enabled = true;
			chkSubSICancellation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkSubSICancellation.ForeColor = System.Drawing.SystemColors.ControlText;
			chkSubSICancellation.Location = new System.Drawing.Point(9, 57);
			chkSubSICancellation.Name = "chkSubSICancellation";
			chkSubSICancellation.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkSubSICancellation.Size = new System.Drawing.Size(95, 13);
			chkSubSICancellation.TabIndex = 110;
			chkSubSICancellation.TabStop = true;
			chkSubSICancellation.Text = "Cancellation";
			chkSubSICancellation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkSubSICancellation.Visible = true;
			// 
			// chkSubSIStopUpdates
			// 
			chkSubSIStopUpdates.AllowDrop = true;
			chkSubSIStopUpdates.Appearance = System.Windows.Forms.Appearance.Normal;
			chkSubSIStopUpdates.BackColor = System.Drawing.SystemColors.Control;
			chkSubSIStopUpdates.CausesValidation = true;
			chkSubSIStopUpdates.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkSubSIStopUpdates.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkSubSIStopUpdates.Enabled = true;
			chkSubSIStopUpdates.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkSubSIStopUpdates.ForeColor = System.Drawing.SystemColors.ControlText;
			chkSubSIStopUpdates.Location = new System.Drawing.Point(9, 36);
			chkSubSIStopUpdates.Name = "chkSubSIStopUpdates";
			chkSubSIStopUpdates.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkSubSIStopUpdates.Size = new System.Drawing.Size(95, 13);
			chkSubSIStopUpdates.TabIndex = 109;
			chkSubSIStopUpdates.TabStop = true;
			chkSubSIStopUpdates.Text = "Stop Updates";
			chkSubSIStopUpdates.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkSubSIStopUpdates.Visible = true;
			// 
			// chkSubSIStopEvolution
			// 
			chkSubSIStopEvolution.AllowDrop = true;
			chkSubSIStopEvolution.Appearance = System.Windows.Forms.Appearance.Normal;
			chkSubSIStopEvolution.BackColor = System.Drawing.SystemColors.Control;
			chkSubSIStopEvolution.CausesValidation = true;
			chkSubSIStopEvolution.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkSubSIStopEvolution.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkSubSIStopEvolution.Enabled = true;
			chkSubSIStopEvolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkSubSIStopEvolution.ForeColor = System.Drawing.SystemColors.ControlText;
			chkSubSIStopEvolution.Location = new System.Drawing.Point(9, 15);
			chkSubSIStopEvolution.Name = "chkSubSIStopEvolution";
			chkSubSIStopEvolution.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkSubSIStopEvolution.Size = new System.Drawing.Size(95, 13);
			chkSubSIStopEvolution.TabIndex = 108;
			chkSubSIStopEvolution.TabStop = true;
			chkSubSIStopEvolution.Text = "Stop Evolution";
			chkSubSIStopEvolution.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkSubSIStopEvolution.Visible = true;
			// 
			// frmSubSIDocDates
			// 
			frmSubSIDocDates.AllowDrop = true;
			frmSubSIDocDates.BackColor = System.Drawing.SystemColors.Control;
			frmSubSIDocDates.Controls.Add(txtSubSIAutoDisableDate);
			frmSubSIDocDates.Controls.Add(txtSubSIDocInterruptDate);
			frmSubSIDocDates.Controls.Add(txtSubSIDocRequestedDate);
			frmSubSIDocDates.Controls.Add(lblSubSIAutoDisableDate);
			frmSubSIDocDates.Controls.Add(lblSubSIDocInterruptDate);
			frmSubSIDocDates.Controls.Add(lblSubSIDocRequestedDate);
			frmSubSIDocDates.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmSubSIDocDates.Enabled = true;
			frmSubSIDocDates.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmSubSIDocDates.ForeColor = System.Drawing.SystemColors.ControlText;
			frmSubSIDocDates.Location = new System.Drawing.Point(291, 24);
			frmSubSIDocDates.Name = "frmSubSIDocDates";
			frmSubSIDocDates.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmSubSIDocDates.Size = new System.Drawing.Size(241, 85);
			frmSubSIDocDates.TabIndex = 117;
			frmSubSIDocDates.Visible = true;
			// 
			// txtSubSIAutoDisableDate
			// 
			txtSubSIAutoDisableDate.AcceptsReturn = true;
			txtSubSIAutoDisableDate.AllowDrop = true;
			txtSubSIAutoDisableDate.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txtSubSIAutoDisableDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtSubSIAutoDisableDate.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtSubSIAutoDisableDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtSubSIAutoDisableDate.ForeColor = System.Drawing.SystemColors.WindowText;
			txtSubSIAutoDisableDate.Location = new System.Drawing.Point(120, 57);
			txtSubSIAutoDisableDate.MaxLength = 0;
			txtSubSIAutoDisableDate.Name = "txtSubSIAutoDisableDate";
			txtSubSIAutoDisableDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtSubSIAutoDisableDate.Size = new System.Drawing.Size(82, 19);
			txtSubSIAutoDisableDate.TabIndex = 107;
			txtSubSIAutoDisableDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtSubSIDocInterruptDate
			// 
			txtSubSIDocInterruptDate.AcceptsReturn = true;
			txtSubSIDocInterruptDate.AllowDrop = true;
			txtSubSIDocInterruptDate.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txtSubSIDocInterruptDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtSubSIDocInterruptDate.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtSubSIDocInterruptDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtSubSIDocInterruptDate.ForeColor = System.Drawing.SystemColors.WindowText;
			txtSubSIDocInterruptDate.Location = new System.Drawing.Point(120, 36);
			txtSubSIDocInterruptDate.MaxLength = 0;
			txtSubSIDocInterruptDate.Name = "txtSubSIDocInterruptDate";
			txtSubSIDocInterruptDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtSubSIDocInterruptDate.Size = new System.Drawing.Size(82, 19);
			txtSubSIDocInterruptDate.TabIndex = 106;
			txtSubSIDocInterruptDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtSubSIDocRequestedDate
			// 
			txtSubSIDocRequestedDate.AcceptsReturn = true;
			txtSubSIDocRequestedDate.AllowDrop = true;
			txtSubSIDocRequestedDate.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txtSubSIDocRequestedDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtSubSIDocRequestedDate.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtSubSIDocRequestedDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtSubSIDocRequestedDate.ForeColor = System.Drawing.SystemColors.WindowText;
			txtSubSIDocRequestedDate.Location = new System.Drawing.Point(96, 15);
			txtSubSIDocRequestedDate.MaxLength = 0;
			txtSubSIDocRequestedDate.Name = "txtSubSIDocRequestedDate";
			txtSubSIDocRequestedDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtSubSIDocRequestedDate.Size = new System.Drawing.Size(136, 19);
			txtSubSIDocRequestedDate.TabIndex = 105;
			txtSubSIDocRequestedDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// lblSubSIAutoDisableDate
			// 
			lblSubSIAutoDisableDate.AllowDrop = true;
			lblSubSIAutoDisableDate.BackColor = System.Drawing.SystemColors.Control;
			lblSubSIAutoDisableDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblSubSIAutoDisableDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblSubSIAutoDisableDate.ForeColor = System.Drawing.SystemColors.ControlText;
			lblSubSIAutoDisableDate.Location = new System.Drawing.Point(9, 60);
			lblSubSIAutoDisableDate.MinimumSize = new System.Drawing.Size(103, 16);
			lblSubSIAutoDisableDate.Name = "lblSubSIAutoDisableDate";
			lblSubSIAutoDisableDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblSubSIAutoDisableDate.Size = new System.Drawing.Size(103, 16);
			lblSubSIAutoDisableDate.TabIndex = 120;
			lblSubSIAutoDisableDate.Text = "Auto Disable Date";
			// 
			// lblSubSIDocInterruptDate
			// 
			lblSubSIDocInterruptDate.AllowDrop = true;
			lblSubSIDocInterruptDate.BackColor = System.Drawing.SystemColors.Control;
			lblSubSIDocInterruptDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblSubSIDocInterruptDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblSubSIDocInterruptDate.ForeColor = System.Drawing.SystemColors.ControlText;
			lblSubSIDocInterruptDate.Location = new System.Drawing.Point(9, 39);
			lblSubSIDocInterruptDate.MinimumSize = new System.Drawing.Size(85, 16);
			lblSubSIDocInterruptDate.Name = "lblSubSIDocInterruptDate";
			lblSubSIDocInterruptDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblSubSIDocInterruptDate.Size = new System.Drawing.Size(85, 16);
			lblSubSIDocInterruptDate.TabIndex = 119;
			lblSubSIDocInterruptDate.Text = "Interrupt Date";
			// 
			// lblSubSIDocRequestedDate
			// 
			lblSubSIDocRequestedDate.AllowDrop = true;
			lblSubSIDocRequestedDate.BackColor = System.Drawing.SystemColors.Control;
			lblSubSIDocRequestedDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblSubSIDocRequestedDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblSubSIDocRequestedDate.ForeColor = System.Drawing.SystemColors.ControlText;
			lblSubSIDocRequestedDate.Location = new System.Drawing.Point(9, 18);
			lblSubSIDocRequestedDate.MinimumSize = new System.Drawing.Size(82, 16);
			lblSubSIDocRequestedDate.Name = "lblSubSIDocRequestedDate";
			lblSubSIDocRequestedDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblSubSIDocRequestedDate.Size = new System.Drawing.Size(82, 16);
			lblSubSIDocRequestedDate.TabIndex = 118;
			lblSubSIDocRequestedDate.Text = "Requested Date";
			// 
			// frmSubSIDocView
			// 
			frmSubSIDocView.AllowDrop = true;
			frmSubSIDocView.BackColor = System.Drawing.SystemColors.Control;
			frmSubSIDocView.Controls.Add(cmdSubSIDocView);
			frmSubSIDocView.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmSubSIDocView.Enabled = true;
			frmSubSIDocView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmSubSIDocView.ForeColor = System.Drawing.SystemColors.ControlText;
			frmSubSIDocView.Location = new System.Drawing.Point(816, 39);
			frmSubSIDocView.Name = "frmSubSIDocView";
			frmSubSIDocView.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmSubSIDocView.Size = new System.Drawing.Size(73, 49);
			frmSubSIDocView.TabIndex = 115;
			frmSubSIDocView.Visible = true;
			// 
			// cmdSubSIDocView
			// 
			cmdSubSIDocView.AllowDrop = true;
			cmdSubSIDocView.BackColor = System.Drawing.SystemColors.Control;
			cmdSubSIDocView.Enabled = false;
			cmdSubSIDocView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdSubSIDocView.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdSubSIDocView.Location = new System.Drawing.Point(9, 15);
			cmdSubSIDocView.Name = "cmdSubSIDocView";
			cmdSubSIDocView.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdSubSIDocView.Size = new System.Drawing.Size(55, 25);
			cmdSubSIDocView.TabIndex = 113;
			cmdSubSIDocView.Text = "&View";
			cmdSubSIDocView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdSubSIDocView.Click += new System.EventHandler(cmdSubSIDocView_Click);
			// 
			// txtSubSIDocId
			// 
			txtSubSIDocId.AcceptsReturn = true;
			txtSubSIDocId.AllowDrop = true;
			txtSubSIDocId.BackColor = System.Drawing.SystemColors.Window;
			txtSubSIDocId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtSubSIDocId.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtSubSIDocId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtSubSIDocId.ForeColor = System.Drawing.SystemColors.WindowText;
			txtSubSIDocId.Location = new System.Drawing.Point(90, 30);
			txtSubSIDocId.MaxLength = 120;
			txtSubSIDocId.Name = "txtSubSIDocId";
			txtSubSIDocId.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtSubSIDocId.Size = new System.Drawing.Size(68, 21);
			txtSubSIDocId.TabIndex = 102;
			txtSubSIDocId.Text = "0";
			txtSubSIDocId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// grd_SubSIDocument
			// 
			grd_SubSIDocument.AllowDrop = true;
			grd_SubSIDocument.AllowUserToAddRows = false;
			grd_SubSIDocument.AllowUserToDeleteRows = false;
			grd_SubSIDocument.AllowUserToResizeColumns = false;
			grd_SubSIDocument.AllowUserToResizeRows = false;
			grd_SubSIDocument.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_SubSIDocument.ColumnsCount = 2;
			grd_SubSIDocument.FixedColumns = 1;
			grd_SubSIDocument.FixedRows = 1;
			grd_SubSIDocument.Location = new System.Drawing.Point(12, 120);
			grd_SubSIDocument.Name = "grd_SubSIDocument";
			grd_SubSIDocument.ReadOnly = true;
			grd_SubSIDocument.RowsCount = 2;
			grd_SubSIDocument.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			grd_SubSIDocument.ShowCellToolTips = false;
			grd_SubSIDocument.Size = new System.Drawing.Size(901, 67);
			grd_SubSIDocument.StandardTab = true;
			grd_SubSIDocument.TabIndex = 114;
			grd_SubSIDocument.Click += new System.EventHandler(grd_SubSIDocument_Click);
			// 
			// _wbSubBrowser1_1
			// 
			_wbSubBrowser1_1.AllowWebBrowserDrop = true;
			_wbSubBrowser1_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_wbSubBrowser1_1.Location = new System.Drawing.Point(9, 198);
			_wbSubBrowser1_1.Name = "_wbSubBrowser1_1";
			_wbSubBrowser1_1.Size = new System.Drawing.Size(907, 373);
			_wbSubBrowser1_1.TabIndex = 166;
			// 
			// lblSubSIViewOnly
			// 
			lblSubSIViewOnly.AllowDrop = true;
			lblSubSIViewOnly.BackColor = System.Drawing.SystemColors.Control;
			lblSubSIViewOnly.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblSubSIViewOnly.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblSubSIViewOnly.ForeColor = System.Drawing.Color.Blue;
			lblSubSIViewOnly.Location = new System.Drawing.Point(177, 36);
			lblSubSIViewOnly.MinimumSize = new System.Drawing.Size(97, 28);
			lblSubSIViewOnly.Name = "lblSubSIViewOnly";
			lblSubSIViewOnly.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblSubSIViewOnly.Size = new System.Drawing.Size(97, 28);
			lblSubSIViewOnly.TabIndex = 124;
			lblSubSIViewOnly.Text = "View Only";
			lblSubSIViewOnly.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			lblSubSIViewOnly.Visible = false;
			// 
			// lblSubSISubId
			// 
			lblSubSISubId.AllowDrop = true;
			lblSubSISubId.BackColor = System.Drawing.SystemColors.Control;
			lblSubSISubId.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblSubSISubId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblSubSISubId.ForeColor = System.Drawing.SystemColors.ControlText;
			lblSubSISubId.Location = new System.Drawing.Point(12, 57);
			lblSubSISubId.MinimumSize = new System.Drawing.Size(70, 16);
			lblSubSISubId.Name = "lblSubSISubId";
			lblSubSISubId.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblSubSISubId.Size = new System.Drawing.Size(70, 16);
			lblSubSISubId.TabIndex = 123;
			lblSubSISubId.Text = "Sub Id";
			// 
			// lblSubSIApprovedBy
			// 
			lblSubSIApprovedBy.AllowDrop = true;
			lblSubSIApprovedBy.BackColor = System.Drawing.SystemColors.Control;
			lblSubSIApprovedBy.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblSubSIApprovedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblSubSIApprovedBy.ForeColor = System.Drawing.SystemColors.ControlText;
			lblSubSIApprovedBy.Location = new System.Drawing.Point(12, 81);
			lblSubSIApprovedBy.MinimumSize = new System.Drawing.Size(73, 16);
			lblSubSIApprovedBy.Name = "lblSubSIApprovedBy";
			lblSubSIApprovedBy.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblSubSIApprovedBy.Size = new System.Drawing.Size(73, 16);
			lblSubSIApprovedBy.TabIndex = 122;
			lblSubSIApprovedBy.Text = "Approved By";
			// 
			// lblSubSIDocId
			// 
			lblSubSIDocId.AllowDrop = true;
			lblSubSIDocId.BackColor = System.Drawing.SystemColors.Control;
			lblSubSIDocId.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblSubSIDocId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblSubSIDocId.ForeColor = System.Drawing.SystemColors.ControlText;
			lblSubSIDocId.Location = new System.Drawing.Point(12, 33);
			lblSubSIDocId.MinimumSize = new System.Drawing.Size(70, 16);
			lblSubSIDocId.Name = "lblSubSIDocId";
			lblSubSIDocId.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblSubSIDocId.Size = new System.Drawing.Size(70, 16);
			lblSubSIDocId.TabIndex = 116;
			lblSubSIDocId.Text = "Document Id";
			// 
			// _SSTab_Subscription_TabPage5
			// 
			_SSTab_Subscription_TabPage5.Controls.Add(cboWebReports);
			_SSTab_Subscription_TabPage5.Controls.Add(_wbSubBrowser1_2);
			_SSTab_Subscription_TabPage5.Controls.Add(lblWebReportsURL);
			_SSTab_Subscription_TabPage5.Controls.Add(lblWebReportProcessing);
			_SSTab_Subscription_TabPage5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_SSTab_Subscription_TabPage5.Text = "Web Reports";
			// 
			// cboWebReports
			// 
			cboWebReports.AllowDrop = true;
			cboWebReports.BackColor = System.Drawing.SystemColors.Window;
			cboWebReports.CausesValidation = true;
			cboWebReports.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboWebReports.Enabled = true;
			cboWebReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cboWebReports.ForeColor = System.Drawing.SystemColors.WindowText;
			cboWebReports.IntegralHeight = true;
			cboWebReports.Location = new System.Drawing.Point(12, 19);
			cboWebReports.Name = "cboWebReports";
			cboWebReports.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cboWebReports.Size = new System.Drawing.Size(305, 21);
			cboWebReports.Sorted = false;
			cboWebReports.TabIndex = 169;
			cboWebReports.TabStop = true;
			cboWebReports.Visible = true;
			cboWebReports.SelectedIndexChanged += new System.EventHandler(cboWebReports_SelectedIndexChanged);
			// 
			// _wbSubBrowser1_2
			// 
			_wbSubBrowser1_2.AllowWebBrowserDrop = true;
			_wbSubBrowser1_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_wbSubBrowser1_2.Location = new System.Drawing.Point(12, 67);
			_wbSubBrowser1_2.Name = "_wbSubBrowser1_2";
			_wbSubBrowser1_2.Size = new System.Drawing.Size(907, 523);
			_wbSubBrowser1_2.TabIndex = 167;
			// 
			// lblWebReportsURL
			// 
			lblWebReportsURL.AllowDrop = true;
			lblWebReportsURL.BackColor = System.Drawing.SystemColors.Control;
			lblWebReportsURL.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblWebReportsURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblWebReportsURL.ForeColor = System.Drawing.Color.Blue;
			lblWebReportsURL.Location = new System.Drawing.Point(11, 46);
			lblWebReportsURL.MinimumSize = new System.Drawing.Size(137, 19);
			lblWebReportsURL.Name = "lblWebReportsURL";
			lblWebReportsURL.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblWebReportsURL.Size = new System.Drawing.Size(137, 19);
			lblWebReportsURL.TabIndex = 171;
			lblWebReportsURL.Text = "Click To Open In Browser";
			lblWebReportsURL.Click += new System.EventHandler(lblWebReportsURL_Click);
			// 
			// lblWebReportProcessing
			// 
			lblWebReportProcessing.AllowDrop = true;
			lblWebReportProcessing.BackColor = System.Drawing.SystemColors.Control;
			lblWebReportProcessing.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblWebReportProcessing.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblWebReportProcessing.ForeColor = System.Drawing.Color.Red;
			lblWebReportProcessing.Location = new System.Drawing.Point(714, 19);
			lblWebReportProcessing.MinimumSize = new System.Drawing.Size(202, 25);
			lblWebReportProcessing.Name = "lblWebReportProcessing";
			lblWebReportProcessing.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblWebReportProcessing.Size = new System.Drawing.Size(202, 25);
			lblWebReportProcessing.TabIndex = 168;
			lblWebReportProcessing.Text = "Processing Web Report";
			lblWebReportProcessing.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// _SSTab_Subscription_TabPage6
			// 
			_SSTab_Subscription_TabPage6.Controls.Add(frmImportCloudNotesToCRMSSN);
			_SSTab_Subscription_TabPage6.Controls.Add(frmImportCRMSSNToCloudNotes);
			_SSTab_Subscription_TabPage6.Controls.Add(frmImportEvoLocalNotesToCloudNotes);
			_SSTab_Subscription_TabPage6.Controls.Add(frmCloudNotes);
			_SSTab_Subscription_TabPage6.Controls.Add(frmServerSideNotes);
			_SSTab_Subscription_TabPage6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_SSTab_Subscription_TabPage6.Text = "SSCN / Cloud Notes";
			// 
			// frmImportCloudNotesToCRMSSN
			// 
			frmImportCloudNotesToCRMSSN.AllowDrop = true;
			frmImportCloudNotesToCRMSSN.BackColor = System.Drawing.SystemColors.Control;
			frmImportCloudNotesToCRMSSN.Controls.Add(txtTotalRecordsInCloudNotes);
			frmImportCloudNotesToCRMSSN.Controls.Add(txtImportCloudNotesFromDate);
			frmImportCloudNotesToCRMSSN.Controls.Add(pbImportCNotesToCRMNotes);
			frmImportCloudNotesToCRMSSN.Controls.Add(_cmdSubNotesButton_10);
			frmImportCloudNotesToCRMSSN.Controls.Add(txtTotalImportedFromCloudNotesToSSNotes);
			frmImportCloudNotesToCRMSSN.Controls.Add(_cmdSubNotesButton_7);
			frmImportCloudNotesToCRMSSN.Controls.Add(_lblSubLabel_46);
			frmImportCloudNotesToCRMSSN.Controls.Add(_lblSubLabel_45);
			frmImportCloudNotesToCRMSSN.Controls.Add(_lblSubLabel_44);
			frmImportCloudNotesToCRMSSN.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmImportCloudNotesToCRMSSN.Enabled = true;
			frmImportCloudNotesToCRMSSN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmImportCloudNotesToCRMSSN.ForeColor = System.Drawing.SystemColors.ControlText;
			frmImportCloudNotesToCRMSSN.Location = new System.Drawing.Point(8, 482);
			frmImportCloudNotesToCRMSSN.Name = "frmImportCloudNotesToCRMSSN";
			frmImportCloudNotesToCRMSSN.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmImportCloudNotesToCRMSSN.Size = new System.Drawing.Size(533, 115);
			frmImportCloudNotesToCRMSSN.TabIndex = 277;
			frmImportCloudNotesToCRMSSN.Text = "Import Cloud Notes To CRM Server Side Notes";
			frmImportCloudNotesToCRMSSN.Visible = true;
			// 
			// txtTotalRecordsInCloudNotes
			// 
			txtTotalRecordsInCloudNotes.AcceptsReturn = true;
			txtTotalRecordsInCloudNotes.AllowDrop = true;
			txtTotalRecordsInCloudNotes.BackColor = System.Drawing.Color.White;
			txtTotalRecordsInCloudNotes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtTotalRecordsInCloudNotes.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtTotalRecordsInCloudNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtTotalRecordsInCloudNotes.ForeColor = System.Drawing.SystemColors.WindowText;
			txtTotalRecordsInCloudNotes.Location = new System.Drawing.Point(322, 52);
			txtTotalRecordsInCloudNotes.MaxLength = 0;
			txtTotalRecordsInCloudNotes.Name = "txtTotalRecordsInCloudNotes";
			txtTotalRecordsInCloudNotes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtTotalRecordsInCloudNotes.Size = new System.Drawing.Size(61, 19);
			txtTotalRecordsInCloudNotes.TabIndex = 286;
			txtTotalRecordsInCloudNotes.Text = "0";
			txtTotalRecordsInCloudNotes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtImportCloudNotesFromDate
			// 
			txtImportCloudNotesFromDate.AcceptsReturn = true;
			txtImportCloudNotesFromDate.AllowDrop = true;
			txtImportCloudNotesFromDate.BackColor = System.Drawing.Color.White;
			txtImportCloudNotesFromDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtImportCloudNotesFromDate.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtImportCloudNotesFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtImportCloudNotesFromDate.ForeColor = System.Drawing.SystemColors.WindowText;
			txtImportCloudNotesFromDate.Location = new System.Drawing.Point(166, 26);
			txtImportCloudNotesFromDate.MaxLength = 0;
			txtImportCloudNotesFromDate.Name = "txtImportCloudNotesFromDate";
			txtImportCloudNotesFromDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtImportCloudNotesFromDate.Size = new System.Drawing.Size(77, 19);
			txtImportCloudNotesFromDate.TabIndex = 283;
			txtImportCloudNotesFromDate.Text = "mm/dd/ccyy";
			txtImportCloudNotesFromDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// pbImportCNotesToCRMNotes
			// 
			pbImportCNotesToCRMNotes.AllowDrop = true;
			pbImportCNotesToCRMNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pbImportCNotesToCRMNotes.Location = new System.Drawing.Point(6, 86);
			pbImportCNotesToCRMNotes.Name = "pbImportCNotesToCRMNotes";
			pbImportCNotesToCRMNotes.Size = new System.Drawing.Size(513, 13);
			pbImportCNotesToCRMNotes.TabIndex = 281;
			pbImportCNotesToCRMNotes.Visible = false;
			// 
			// _cmdSubNotesButton_10
			// 
			_cmdSubNotesButton_10.AllowDrop = true;
			_cmdSubNotesButton_10.BackColor = System.Drawing.SystemColors.Control;
			_cmdSubNotesButton_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmdSubNotesButton_10.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmdSubNotesButton_10.Location = new System.Drawing.Point(8, 24);
			_cmdSubNotesButton_10.Name = "_cmdSubNotesButton_10";
			_cmdSubNotesButton_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmdSubNotesButton_10.Size = new System.Drawing.Size(55, 21);
			_cmdSubNotesButton_10.TabIndex = 280;
			_cmdSubNotesButton_10.Text = "&Import";
			_cmdSubNotesButton_10.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmdSubNotesButton_10.UseVisualStyleBackColor = false;
			_cmdSubNotesButton_10.Click += new System.EventHandler(cmdSubNotesButton_Click);
			// 
			// txtTotalImportedFromCloudNotesToSSNotes
			// 
			txtTotalImportedFromCloudNotesToSSNotes.AcceptsReturn = true;
			txtTotalImportedFromCloudNotesToSSNotes.AllowDrop = true;
			txtTotalImportedFromCloudNotesToSSNotes.BackColor = System.Drawing.Color.White;
			txtTotalImportedFromCloudNotesToSSNotes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtTotalImportedFromCloudNotesToSSNotes.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtTotalImportedFromCloudNotesToSSNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtTotalImportedFromCloudNotesToSSNotes.ForeColor = System.Drawing.SystemColors.WindowText;
			txtTotalImportedFromCloudNotesToSSNotes.Location = new System.Drawing.Point(98, 54);
			txtTotalImportedFromCloudNotesToSSNotes.MaxLength = 0;
			txtTotalImportedFromCloudNotesToSSNotes.Name = "txtTotalImportedFromCloudNotesToSSNotes";
			txtTotalImportedFromCloudNotesToSSNotes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtTotalImportedFromCloudNotesToSSNotes.Size = new System.Drawing.Size(61, 19);
			txtTotalImportedFromCloudNotesToSSNotes.TabIndex = 279;
			txtTotalImportedFromCloudNotesToSSNotes.Text = "0";
			txtTotalImportedFromCloudNotesToSSNotes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// _cmdSubNotesButton_7
			// 
			_cmdSubNotesButton_7.AllowDrop = true;
			_cmdSubNotesButton_7.BackColor = System.Drawing.SystemColors.Control;
			_cmdSubNotesButton_7.Enabled = false;
			_cmdSubNotesButton_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmdSubNotesButton_7.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmdSubNotesButton_7.Location = new System.Drawing.Point(464, 24);
			_cmdSubNotesButton_7.Name = "_cmdSubNotesButton_7";
			_cmdSubNotesButton_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmdSubNotesButton_7.Size = new System.Drawing.Size(57, 21);
			_cmdSubNotesButton_7.TabIndex = 278;
			_cmdSubNotesButton_7.Text = "Stop";
			_cmdSubNotesButton_7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmdSubNotesButton_7.Click += new System.EventHandler(cmdSubNotesButton_Click);
			// 
			// _lblSubLabel_46
			// 
			_lblSubLabel_46.AllowDrop = true;
			_lblSubLabel_46.AutoSize = true;
			_lblSubLabel_46.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_46.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_46.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_46.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_46.Location = new System.Drawing.Point(188, 56);
			_lblSubLabel_46.MinimumSize = new System.Drawing.Size(114, 13);
			_lblSubLabel_46.Name = "_lblSubLabel_46";
			_lblSubLabel_46.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_46.Size = new System.Drawing.Size(114, 13);
			_lblSubLabel_46.TabIndex = 285;
			_lblSubLabel_46.Text = "In Cloud Notes Table";
			_lblSubLabel_46.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_46.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// _lblSubLabel_45
			// 
			_lblSubLabel_45.AllowDrop = true;
			_lblSubLabel_45.AutoSize = true;
			_lblSubLabel_45.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_45.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_45.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_45.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_45.Location = new System.Drawing.Point(104, 28);
			_lblSubLabel_45.MinimumSize = new System.Drawing.Size(49, 13);
			_lblSubLabel_45.Name = "_lblSubLabel_45";
			_lblSubLabel_45.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_45.Size = new System.Drawing.Size(49, 13);
			_lblSubLabel_45.TabIndex = 284;
			_lblSubLabel_45.Text = "From Date";
			_lblSubLabel_45.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_45.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// _lblSubLabel_44
			// 
			_lblSubLabel_44.AllowDrop = true;
			_lblSubLabel_44.AutoSize = true;
			_lblSubLabel_44.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_44.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_44.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_44.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_44.Location = new System.Drawing.Point(8, 56);
			_lblSubLabel_44.MinimumSize = new System.Drawing.Size(84, 13);
			_lblSubLabel_44.Name = "_lblSubLabel_44";
			_lblSubLabel_44.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_44.Size = new System.Drawing.Size(84, 13);
			_lblSubLabel_44.TabIndex = 282;
			_lblSubLabel_44.Text = "Records Imported";
			_lblSubLabel_44.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_44.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// frmImportCRMSSNToCloudNotes
			// 
			frmImportCRMSSNToCloudNotes.AllowDrop = true;
			frmImportCRMSSNToCloudNotes.BackColor = System.Drawing.SystemColors.Control;
			frmImportCRMSSNToCloudNotes.Controls.Add(_cmdSubNotesButton_6);
			frmImportCRMSSNToCloudNotes.Controls.Add(txtTotalRecordsInSSNotes);
			frmImportCRMSSNToCloudNotes.Controls.Add(txtTotalImportedFromSSNToCloudNotes);
			frmImportCRMSSNToCloudNotes.Controls.Add(_cmdSubNotesButton_9);
			frmImportCRMSSNToCloudNotes.Controls.Add(rbCopySSNToCNOverwriteCloudNotes);
			frmImportCRMSSNToCloudNotes.Controls.Add(rbCopySSNToCNAppendCloudNotes);
			frmImportCRMSSNToCloudNotes.Controls.Add(pbImportSSNotes);
			frmImportCRMSSNToCloudNotes.Controls.Add(_lblSubLabel_30);
			frmImportCRMSSNToCloudNotes.Controls.Add(_lblSubLabel_28);
			frmImportCRMSSNToCloudNotes.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmImportCRMSSNToCloudNotes.Enabled = true;
			frmImportCRMSSNToCloudNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmImportCRMSSNToCloudNotes.ForeColor = System.Drawing.SystemColors.ControlText;
			frmImportCRMSSNToCloudNotes.Location = new System.Drawing.Point(8, 360);
			frmImportCRMSSNToCloudNotes.Name = "frmImportCRMSSNToCloudNotes";
			frmImportCRMSSNToCloudNotes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmImportCRMSSNToCloudNotes.Size = new System.Drawing.Size(533, 113);
			frmImportCRMSSNToCloudNotes.TabIndex = 223;
			frmImportCRMSSNToCloudNotes.Text = "Import  CRM Server Side Notes To Cloud Notes";
			frmImportCRMSSNToCloudNotes.Visible = true;
			// 
			// _cmdSubNotesButton_6
			// 
			_cmdSubNotesButton_6.AllowDrop = true;
			_cmdSubNotesButton_6.BackColor = System.Drawing.SystemColors.Control;
			_cmdSubNotesButton_6.Enabled = false;
			_cmdSubNotesButton_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmdSubNotesButton_6.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmdSubNotesButton_6.Location = new System.Drawing.Point(464, 24);
			_cmdSubNotesButton_6.Name = "_cmdSubNotesButton_6";
			_cmdSubNotesButton_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmdSubNotesButton_6.Size = new System.Drawing.Size(57, 21);
			_cmdSubNotesButton_6.TabIndex = 232;
			_cmdSubNotesButton_6.Text = "Stop";
			_cmdSubNotesButton_6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmdSubNotesButton_6.Click += new System.EventHandler(cmdSubNotesButton_Click);
			// 
			// txtTotalRecordsInSSNotes
			// 
			txtTotalRecordsInSSNotes.AcceptsReturn = true;
			txtTotalRecordsInSSNotes.AllowDrop = true;
			txtTotalRecordsInSSNotes.BackColor = System.Drawing.Color.White;
			txtTotalRecordsInSSNotes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtTotalRecordsInSSNotes.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtTotalRecordsInSSNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtTotalRecordsInSSNotes.ForeColor = System.Drawing.SystemColors.WindowText;
			txtTotalRecordsInSSNotes.Location = new System.Drawing.Point(322, 54);
			txtTotalRecordsInSSNotes.MaxLength = 0;
			txtTotalRecordsInSSNotes.Name = "txtTotalRecordsInSSNotes";
			txtTotalRecordsInSSNotes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtTotalRecordsInSSNotes.Size = new System.Drawing.Size(61, 19);
			txtTotalRecordsInSSNotes.TabIndex = 228;
			txtTotalRecordsInSSNotes.Text = "0";
			txtTotalRecordsInSSNotes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtTotalImportedFromSSNToCloudNotes
			// 
			txtTotalImportedFromSSNToCloudNotes.AcceptsReturn = true;
			txtTotalImportedFromSSNToCloudNotes.AllowDrop = true;
			txtTotalImportedFromSSNToCloudNotes.BackColor = System.Drawing.Color.White;
			txtTotalImportedFromSSNToCloudNotes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtTotalImportedFromSSNToCloudNotes.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtTotalImportedFromSSNToCloudNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtTotalImportedFromSSNToCloudNotes.ForeColor = System.Drawing.SystemColors.WindowText;
			txtTotalImportedFromSSNToCloudNotes.Location = new System.Drawing.Point(96, 54);
			txtTotalImportedFromSSNToCloudNotes.MaxLength = 0;
			txtTotalImportedFromSSNToCloudNotes.Name = "txtTotalImportedFromSSNToCloudNotes";
			txtTotalImportedFromSSNToCloudNotes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtTotalImportedFromSSNToCloudNotes.Size = new System.Drawing.Size(61, 19);
			txtTotalImportedFromSSNToCloudNotes.TabIndex = 227;
			txtTotalImportedFromSSNToCloudNotes.Text = "0";
			txtTotalImportedFromSSNToCloudNotes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// _cmdSubNotesButton_9
			// 
			_cmdSubNotesButton_9.AllowDrop = true;
			_cmdSubNotesButton_9.BackColor = System.Drawing.SystemColors.Control;
			_cmdSubNotesButton_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmdSubNotesButton_9.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmdSubNotesButton_9.Location = new System.Drawing.Point(10, 24);
			_cmdSubNotesButton_9.Name = "_cmdSubNotesButton_9";
			_cmdSubNotesButton_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmdSubNotesButton_9.Size = new System.Drawing.Size(55, 21);
			_cmdSubNotesButton_9.TabIndex = 226;
			_cmdSubNotesButton_9.Text = "&Import";
			_cmdSubNotesButton_9.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmdSubNotesButton_9.UseVisualStyleBackColor = false;
			_cmdSubNotesButton_9.Click += new System.EventHandler(cmdSubNotesButton_Click);
			// 
			// rbCopySSNToCNOverwriteCloudNotes
			// 
			rbCopySSNToCNOverwriteCloudNotes.AllowDrop = true;
			rbCopySSNToCNOverwriteCloudNotes.BackColor = System.Drawing.SystemColors.Control;
			rbCopySSNToCNOverwriteCloudNotes.CausesValidation = true;
			rbCopySSNToCNOverwriteCloudNotes.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			rbCopySSNToCNOverwriteCloudNotes.Checked = true;
			rbCopySSNToCNOverwriteCloudNotes.Enabled = true;
			rbCopySSNToCNOverwriteCloudNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			rbCopySSNToCNOverwriteCloudNotes.ForeColor = System.Drawing.SystemColors.ControlText;
			rbCopySSNToCNOverwriteCloudNotes.Location = new System.Drawing.Point(96, 28);
			rbCopySSNToCNOverwriteCloudNotes.Name = "rbCopySSNToCNOverwriteCloudNotes";
			rbCopySSNToCNOverwriteCloudNotes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			rbCopySSNToCNOverwriteCloudNotes.Size = new System.Drawing.Size(147, 15);
			rbCopySSNToCNOverwriteCloudNotes.TabIndex = 225;
			rbCopySSNToCNOverwriteCloudNotes.TabStop = true;
			rbCopySSNToCNOverwriteCloudNotes.Text = "Overwrite All Cloud Notes";
			rbCopySSNToCNOverwriteCloudNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			rbCopySSNToCNOverwriteCloudNotes.Visible = true;
			// 
			// rbCopySSNToCNAppendCloudNotes
			// 
			rbCopySSNToCNAppendCloudNotes.AllowDrop = true;
			rbCopySSNToCNAppendCloudNotes.BackColor = System.Drawing.SystemColors.Control;
			rbCopySSNToCNAppendCloudNotes.CausesValidation = true;
			rbCopySSNToCNAppendCloudNotes.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			rbCopySSNToCNAppendCloudNotes.Checked = false;
			rbCopySSNToCNAppendCloudNotes.Enabled = true;
			rbCopySSNToCNAppendCloudNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			rbCopySSNToCNAppendCloudNotes.ForeColor = System.Drawing.SystemColors.ControlText;
			rbCopySSNToCNAppendCloudNotes.Location = new System.Drawing.Point(252, 28);
			rbCopySSNToCNAppendCloudNotes.Name = "rbCopySSNToCNAppendCloudNotes";
			rbCopySSNToCNAppendCloudNotes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			rbCopySSNToCNAppendCloudNotes.Size = new System.Drawing.Size(125, 15);
			rbCopySSNToCNAppendCloudNotes.TabIndex = 224;
			rbCopySSNToCNAppendCloudNotes.TabStop = true;
			rbCopySSNToCNAppendCloudNotes.Text = "Append Cloud Notes";
			rbCopySSNToCNAppendCloudNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			rbCopySSNToCNAppendCloudNotes.Visible = true;
			// 
			// pbImportSSNotes
			// 
			pbImportSSNotes.AllowDrop = true;
			pbImportSSNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pbImportSSNotes.Location = new System.Drawing.Point(6, 84);
			pbImportSSNotes.Name = "pbImportSSNotes";
			pbImportSSNotes.Size = new System.Drawing.Size(513, 13);
			pbImportSSNotes.TabIndex = 229;
			pbImportSSNotes.Visible = false;
			// 
			// _lblSubLabel_30
			// 
			_lblSubLabel_30.AllowDrop = true;
			_lblSubLabel_30.AutoSize = true;
			_lblSubLabel_30.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_30.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_30.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_30.Location = new System.Drawing.Point(188, 58);
			_lblSubLabel_30.MinimumSize = new System.Drawing.Size(120, 13);
			_lblSubLabel_30.Name = "_lblSubLabel_30";
			_lblSubLabel_30.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_30.Size = new System.Drawing.Size(120, 13);
			_lblSubLabel_30.TabIndex = 231;
			_lblSubLabel_30.Text = "In CRM SS Notes Table  ";
			_lblSubLabel_30.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_30.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// _lblSubLabel_28
			// 
			_lblSubLabel_28.AllowDrop = true;
			_lblSubLabel_28.AutoSize = true;
			_lblSubLabel_28.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_28.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_28.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_28.Location = new System.Drawing.Point(6, 58);
			_lblSubLabel_28.MinimumSize = new System.Drawing.Size(84, 13);
			_lblSubLabel_28.Name = "_lblSubLabel_28";
			_lblSubLabel_28.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_28.Size = new System.Drawing.Size(84, 13);
			_lblSubLabel_28.TabIndex = 230;
			_lblSubLabel_28.Text = "Records Imported";
			_lblSubLabel_28.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_28.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// frmImportEvoLocalNotesToCloudNotes
			// 
			frmImportEvoLocalNotesToCloudNotes.AllowDrop = true;
			frmImportEvoLocalNotesToCloudNotes.BackColor = System.Drawing.SystemColors.Control;
			frmImportEvoLocalNotesToCloudNotes.Controls.Add(txtPathToEvoLocalNotes);
			frmImportEvoLocalNotesToCloudNotes.Controls.Add(_cmdSubNotesButton_5);
			frmImportEvoLocalNotesToCloudNotes.Controls.Add(_cmdSubNotesButton_8);
			frmImportEvoLocalNotesToCloudNotes.Controls.Add(rbEvoLocalNotesOverrideCloudNotes);
			frmImportEvoLocalNotesToCloudNotes.Controls.Add(rbEvoLocalNotesAppendCloudNotes);
			frmImportEvoLocalNotesToCloudNotes.Controls.Add(txtTotalImportedFromLocalNotesToEvoCloudNotes);
			frmImportEvoLocalNotesToCloudNotes.Controls.Add(txtTotalRecordsInEvoLocalNotes);
			frmImportEvoLocalNotesToCloudNotes.Controls.Add(_cmdSubNotesButton_4);
			frmImportEvoLocalNotesToCloudNotes.Controls.Add(rbEvoLocalNotesPurgeImportCloudNotes);
			frmImportEvoLocalNotesToCloudNotes.Controls.Add(pbImportEvoLocalNotes);
			frmImportEvoLocalNotesToCloudNotes.Controls.Add(_lblSubLabel_24);
			frmImportEvoLocalNotesToCloudNotes.Controls.Add(_lblSubLabel_23);
			frmImportEvoLocalNotesToCloudNotes.Controls.Add(_lblSubLabel_26);
			frmImportEvoLocalNotesToCloudNotes.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmImportEvoLocalNotesToCloudNotes.Enabled = true;
			frmImportEvoLocalNotesToCloudNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmImportEvoLocalNotesToCloudNotes.ForeColor = System.Drawing.SystemColors.ControlText;
			frmImportEvoLocalNotesToCloudNotes.Location = new System.Drawing.Point(8, 208);
			frmImportEvoLocalNotesToCloudNotes.Name = "frmImportEvoLocalNotesToCloudNotes";
			frmImportEvoLocalNotesToCloudNotes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmImportEvoLocalNotesToCloudNotes.Size = new System.Drawing.Size(533, 143);
			frmImportEvoLocalNotesToCloudNotes.TabIndex = 214;
			frmImportEvoLocalNotesToCloudNotes.Text = "Import Evolution Local Notes To Cloud Notes";
			frmImportEvoLocalNotesToCloudNotes.Visible = true;
			// 
			// txtPathToEvoLocalNotes
			// 
			txtPathToEvoLocalNotes.AcceptsReturn = true;
			txtPathToEvoLocalNotes.AllowDrop = true;
			txtPathToEvoLocalNotes.BackColor = System.Drawing.SystemColors.Window;
			txtPathToEvoLocalNotes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtPathToEvoLocalNotes.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtPathToEvoLocalNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtPathToEvoLocalNotes.ForeColor = System.Drawing.SystemColors.WindowText;
			txtPathToEvoLocalNotes.Location = new System.Drawing.Point(10, 38);
			txtPathToEvoLocalNotes.MaxLength = 0;
			txtPathToEvoLocalNotes.Name = "txtPathToEvoLocalNotes";
			txtPathToEvoLocalNotes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtPathToEvoLocalNotes.Size = new System.Drawing.Size(441, 21);
			txtPathToEvoLocalNotes.TabIndex = 186;
			txtPathToEvoLocalNotes.Text = "C:\\TEMP\\";
			txtPathToEvoLocalNotes.Leave += new System.EventHandler(txtPathToEvoLocalNotes_Leave);
			// 
			// _cmdSubNotesButton_5
			// 
			_cmdSubNotesButton_5.AllowDrop = true;
			_cmdSubNotesButton_5.BackColor = System.Drawing.SystemColors.Control;
			_cmdSubNotesButton_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmdSubNotesButton_5.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmdSubNotesButton_5.Location = new System.Drawing.Point(464, 38);
			_cmdSubNotesButton_5.Name = "_cmdSubNotesButton_5";
			_cmdSubNotesButton_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmdSubNotesButton_5.Size = new System.Drawing.Size(57, 21);
			_cmdSubNotesButton_5.TabIndex = 187;
			_cmdSubNotesButton_5.Text = "Browse";
			_cmdSubNotesButton_5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmdSubNotesButton_5.UseVisualStyleBackColor = false;
			_cmdSubNotesButton_5.Click += new System.EventHandler(cmdSubNotesButton_Click);
			// 
			// _cmdSubNotesButton_8
			// 
			_cmdSubNotesButton_8.AllowDrop = true;
			_cmdSubNotesButton_8.BackColor = System.Drawing.SystemColors.Control;
			_cmdSubNotesButton_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmdSubNotesButton_8.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmdSubNotesButton_8.Location = new System.Drawing.Point(8, 74);
			_cmdSubNotesButton_8.Name = "_cmdSubNotesButton_8";
			_cmdSubNotesButton_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmdSubNotesButton_8.Size = new System.Drawing.Size(55, 21);
			_cmdSubNotesButton_8.TabIndex = 188;
			_cmdSubNotesButton_8.Text = "Import";
			_cmdSubNotesButton_8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmdSubNotesButton_8.UseVisualStyleBackColor = false;
			_cmdSubNotesButton_8.Click += new System.EventHandler(cmdSubNotesButton_Click);
			// 
			// rbEvoLocalNotesOverrideCloudNotes
			// 
			rbEvoLocalNotesOverrideCloudNotes.AllowDrop = true;
			rbEvoLocalNotesOverrideCloudNotes.BackColor = System.Drawing.SystemColors.Control;
			rbEvoLocalNotesOverrideCloudNotes.CausesValidation = true;
			rbEvoLocalNotesOverrideCloudNotes.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			rbEvoLocalNotesOverrideCloudNotes.Checked = true;
			rbEvoLocalNotesOverrideCloudNotes.Enabled = true;
			rbEvoLocalNotesOverrideCloudNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			rbEvoLocalNotesOverrideCloudNotes.ForeColor = System.Drawing.SystemColors.ControlText;
			rbEvoLocalNotesOverrideCloudNotes.Location = new System.Drawing.Point(72, 76);
			rbEvoLocalNotesOverrideCloudNotes.Name = "rbEvoLocalNotesOverrideCloudNotes";
			rbEvoLocalNotesOverrideCloudNotes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			rbEvoLocalNotesOverrideCloudNotes.Size = new System.Drawing.Size(147, 15);
			rbEvoLocalNotesOverrideCloudNotes.TabIndex = 189;
			rbEvoLocalNotesOverrideCloudNotes.TabStop = true;
			rbEvoLocalNotesOverrideCloudNotes.Text = "Overwrite All Cloud Notes";
			rbEvoLocalNotesOverrideCloudNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			rbEvoLocalNotesOverrideCloudNotes.Visible = true;
			// 
			// rbEvoLocalNotesAppendCloudNotes
			// 
			rbEvoLocalNotesAppendCloudNotes.AllowDrop = true;
			rbEvoLocalNotesAppendCloudNotes.BackColor = System.Drawing.SystemColors.Control;
			rbEvoLocalNotesAppendCloudNotes.CausesValidation = true;
			rbEvoLocalNotesAppendCloudNotes.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			rbEvoLocalNotesAppendCloudNotes.Checked = false;
			rbEvoLocalNotesAppendCloudNotes.Enabled = true;
			rbEvoLocalNotesAppendCloudNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			rbEvoLocalNotesAppendCloudNotes.ForeColor = System.Drawing.SystemColors.ControlText;
			rbEvoLocalNotesAppendCloudNotes.Location = new System.Drawing.Point(228, 76);
			rbEvoLocalNotesAppendCloudNotes.Name = "rbEvoLocalNotesAppendCloudNotes";
			rbEvoLocalNotesAppendCloudNotes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			rbEvoLocalNotesAppendCloudNotes.Size = new System.Drawing.Size(125, 15);
			rbEvoLocalNotesAppendCloudNotes.TabIndex = 190;
			rbEvoLocalNotesAppendCloudNotes.TabStop = true;
			rbEvoLocalNotesAppendCloudNotes.Text = "Append Cloud Notes";
			rbEvoLocalNotesAppendCloudNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			rbEvoLocalNotesAppendCloudNotes.Visible = true;
			// 
			// txtTotalImportedFromLocalNotesToEvoCloudNotes
			// 
			txtTotalImportedFromLocalNotesToEvoCloudNotes.AcceptsReturn = true;
			txtTotalImportedFromLocalNotesToEvoCloudNotes.AllowDrop = true;
			txtTotalImportedFromLocalNotesToEvoCloudNotes.BackColor = System.Drawing.Color.White;
			txtTotalImportedFromLocalNotesToEvoCloudNotes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtTotalImportedFromLocalNotesToEvoCloudNotes.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtTotalImportedFromLocalNotesToEvoCloudNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtTotalImportedFromLocalNotesToEvoCloudNotes.ForeColor = System.Drawing.SystemColors.WindowText;
			txtTotalImportedFromLocalNotesToEvoCloudNotes.Location = new System.Drawing.Point(100, 96);
			txtTotalImportedFromLocalNotesToEvoCloudNotes.MaxLength = 0;
			txtTotalImportedFromLocalNotesToEvoCloudNotes.Name = "txtTotalImportedFromLocalNotesToEvoCloudNotes";
			txtTotalImportedFromLocalNotesToEvoCloudNotes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtTotalImportedFromLocalNotesToEvoCloudNotes.Size = new System.Drawing.Size(61, 19);
			txtTotalImportedFromLocalNotesToEvoCloudNotes.TabIndex = 192;
			txtTotalImportedFromLocalNotesToEvoCloudNotes.Text = "0";
			txtTotalImportedFromLocalNotesToEvoCloudNotes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtTotalRecordsInEvoLocalNotes
			// 
			txtTotalRecordsInEvoLocalNotes.AcceptsReturn = true;
			txtTotalRecordsInEvoLocalNotes.AllowDrop = true;
			txtTotalRecordsInEvoLocalNotes.BackColor = System.Drawing.Color.White;
			txtTotalRecordsInEvoLocalNotes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtTotalRecordsInEvoLocalNotes.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtTotalRecordsInEvoLocalNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtTotalRecordsInEvoLocalNotes.ForeColor = System.Drawing.SystemColors.WindowText;
			txtTotalRecordsInEvoLocalNotes.Location = new System.Drawing.Point(322, 96);
			txtTotalRecordsInEvoLocalNotes.MaxLength = 0;
			txtTotalRecordsInEvoLocalNotes.Name = "txtTotalRecordsInEvoLocalNotes";
			txtTotalRecordsInEvoLocalNotes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtTotalRecordsInEvoLocalNotes.Size = new System.Drawing.Size(61, 19);
			txtTotalRecordsInEvoLocalNotes.TabIndex = 193;
			txtTotalRecordsInEvoLocalNotes.Text = "0";
			txtTotalRecordsInEvoLocalNotes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// _cmdSubNotesButton_4
			// 
			_cmdSubNotesButton_4.AllowDrop = true;
			_cmdSubNotesButton_4.BackColor = System.Drawing.SystemColors.Control;
			_cmdSubNotesButton_4.Enabled = false;
			_cmdSubNotesButton_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmdSubNotesButton_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmdSubNotesButton_4.Location = new System.Drawing.Point(464, 14);
			_cmdSubNotesButton_4.Name = "_cmdSubNotesButton_4";
			_cmdSubNotesButton_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmdSubNotesButton_4.Size = new System.Drawing.Size(57, 21);
			_cmdSubNotesButton_4.TabIndex = 194;
			_cmdSubNotesButton_4.Text = "Stop";
			_cmdSubNotesButton_4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmdSubNotesButton_4.Click += new System.EventHandler(cmdSubNotesButton_Click);
			// 
			// rbEvoLocalNotesPurgeImportCloudNotes
			// 
			rbEvoLocalNotesPurgeImportCloudNotes.AllowDrop = true;
			rbEvoLocalNotesPurgeImportCloudNotes.BackColor = System.Drawing.SystemColors.Control;
			rbEvoLocalNotesPurgeImportCloudNotes.CausesValidation = true;
			rbEvoLocalNotesPurgeImportCloudNotes.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			rbEvoLocalNotesPurgeImportCloudNotes.Checked = false;
			rbEvoLocalNotesPurgeImportCloudNotes.Enabled = true;
			rbEvoLocalNotesPurgeImportCloudNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			rbEvoLocalNotesPurgeImportCloudNotes.ForeColor = System.Drawing.SystemColors.ControlText;
			rbEvoLocalNotesPurgeImportCloudNotes.Location = new System.Drawing.Point(360, 76);
			rbEvoLocalNotesPurgeImportCloudNotes.Name = "rbEvoLocalNotesPurgeImportCloudNotes";
			rbEvoLocalNotesPurgeImportCloudNotes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			rbEvoLocalNotesPurgeImportCloudNotes.Size = new System.Drawing.Size(99, 15);
			rbEvoLocalNotesPurgeImportCloudNotes.TabIndex = 191;
			rbEvoLocalNotesPurgeImportCloudNotes.TabStop = true;
			rbEvoLocalNotesPurgeImportCloudNotes.Text = "Purge Imported";
			rbEvoLocalNotesPurgeImportCloudNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			rbEvoLocalNotesPurgeImportCloudNotes.Visible = true;
			// 
			// pbImportEvoLocalNotes
			// 
			pbImportEvoLocalNotes.AllowDrop = true;
			pbImportEvoLocalNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pbImportEvoLocalNotes.Location = new System.Drawing.Point(6, 122);
			pbImportEvoLocalNotes.Name = "pbImportEvoLocalNotes";
			pbImportEvoLocalNotes.Size = new System.Drawing.Size(513, 13);
			pbImportEvoLocalNotes.TabIndex = 215;
			pbImportEvoLocalNotes.Visible = false;
			// 
			// _lblSubLabel_24
			// 
			_lblSubLabel_24.AllowDrop = true;
			_lblSubLabel_24.AutoSize = true;
			_lblSubLabel_24.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_24.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_24.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_24.Location = new System.Drawing.Point(10, 22);
			_lblSubLabel_24.MinimumSize = new System.Drawing.Size(167, 13);
			_lblSubLabel_24.Name = "_lblSubLabel_24";
			_lblSubLabel_24.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_24.Size = new System.Drawing.Size(167, 13);
			_lblSubLabel_24.TabIndex = 218;
			_lblSubLabel_24.Text = "Path To Evo Local Notes MDB";
			_lblSubLabel_24.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_24.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// _lblSubLabel_23
			// 
			_lblSubLabel_23.AllowDrop = true;
			_lblSubLabel_23.AutoSize = true;
			_lblSubLabel_23.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_23.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_23.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_23.Location = new System.Drawing.Point(6, 100);
			_lblSubLabel_23.MinimumSize = new System.Drawing.Size(84, 13);
			_lblSubLabel_23.Name = "_lblSubLabel_23";
			_lblSubLabel_23.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_23.Size = new System.Drawing.Size(84, 13);
			_lblSubLabel_23.TabIndex = 217;
			_lblSubLabel_23.Text = "Records Imported";
			_lblSubLabel_23.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_23.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// _lblSubLabel_26
			// 
			_lblSubLabel_26.AllowDrop = true;
			_lblSubLabel_26.AutoSize = true;
			_lblSubLabel_26.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_26.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_26.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_26.Location = new System.Drawing.Point(188, 100);
			_lblSubLabel_26.MinimumSize = new System.Drawing.Size(126, 13);
			_lblSubLabel_26.Name = "_lblSubLabel_26";
			_lblSubLabel_26.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_26.Size = new System.Drawing.Size(126, 13);
			_lblSubLabel_26.TabIndex = 216;
			_lblSubLabel_26.Text = "In Evo Local Notes MDB";
			_lblSubLabel_26.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_26.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// frmCloudNotes
			// 
			frmCloudNotes.AllowDrop = true;
			frmCloudNotes.BackColor = System.Drawing.SystemColors.Control;
			frmCloudNotes.Controls.Add(_cmdSubNotesButton_3);
			frmCloudNotes.Controls.Add(_cmdSubNotesButton_2);
			frmCloudNotes.Controls.Add(cmbCloudNotesDatabaseName);
			frmCloudNotes.Controls.Add(chkCloudNotesFlag);
			frmCloudNotes.Controls.Add(Label3);
			frmCloudNotes.Controls.Add(_lblSubLabel_25);
			frmCloudNotes.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmCloudNotes.Enabled = true;
			frmCloudNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmCloudNotes.ForeColor = System.Drawing.Color.Black;
			frmCloudNotes.Location = new System.Drawing.Point(8, 114);
			frmCloudNotes.Name = "frmCloudNotes";
			frmCloudNotes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmCloudNotes.Size = new System.Drawing.Size(532, 90);
			frmCloudNotes.TabIndex = 198;
			frmCloudNotes.Text = "Evolution Cloud Notes";
			frmCloudNotes.Visible = true;
			// 
			// _cmdSubNotesButton_3
			// 
			_cmdSubNotesButton_3.AllowDrop = true;
			_cmdSubNotesButton_3.BackColor = System.Drawing.SystemColors.Control;
			_cmdSubNotesButton_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmdSubNotesButton_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmdSubNotesButton_3.Location = new System.Drawing.Point(466, 64);
			_cmdSubNotesButton_3.Name = "_cmdSubNotesButton_3";
			_cmdSubNotesButton_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmdSubNotesButton_3.Size = new System.Drawing.Size(52, 21);
			_cmdSubNotesButton_3.TabIndex = 185;
			_cmdSubNotesButton_3.Text = "Export";
			_cmdSubNotesButton_3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmdSubNotesButton_3.UseVisualStyleBackColor = false;
			_cmdSubNotesButton_3.Click += new System.EventHandler(cmdSubNotesButton_Click);
			// 
			// _cmdSubNotesButton_2
			// 
			_cmdSubNotesButton_2.AllowDrop = true;
			_cmdSubNotesButton_2.BackColor = System.Drawing.SystemColors.Control;
			_cmdSubNotesButton_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmdSubNotesButton_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmdSubNotesButton_2.Location = new System.Drawing.Point(466, 14);
			_cmdSubNotesButton_2.Name = "_cmdSubNotesButton_2";
			_cmdSubNotesButton_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmdSubNotesButton_2.Size = new System.Drawing.Size(52, 21);
			_cmdSubNotesButton_2.TabIndex = 184;
			_cmdSubNotesButton_2.Text = "&Save";
			_cmdSubNotesButton_2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmdSubNotesButton_2.UseVisualStyleBackColor = false;
			_cmdSubNotesButton_2.Click += new System.EventHandler(cmdSubNotesButton_Click);
			// 
			// cmbCloudNotesDatabaseName
			// 
			cmbCloudNotesDatabaseName.AllowDrop = true;
			cmbCloudNotesDatabaseName.BackColor = System.Drawing.SystemColors.Window;
			cmbCloudNotesDatabaseName.CausesValidation = true;
			cmbCloudNotesDatabaseName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cmbCloudNotesDatabaseName.Enabled = true;
			cmbCloudNotesDatabaseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmbCloudNotesDatabaseName.ForeColor = System.Drawing.SystemColors.WindowText;
			cmbCloudNotesDatabaseName.IntegralHeight = true;
			cmbCloudNotesDatabaseName.Location = new System.Drawing.Point(159, 40);
			cmbCloudNotesDatabaseName.Name = "cmbCloudNotesDatabaseName";
			cmbCloudNotesDatabaseName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmbCloudNotesDatabaseName.Size = new System.Drawing.Size(361, 21);
			cmbCloudNotesDatabaseName.Sorted = false;
			cmbCloudNotesDatabaseName.TabIndex = 183;
			cmbCloudNotesDatabaseName.TabStop = true;
			cmbCloudNotesDatabaseName.Visible = true;
			cmbCloudNotesDatabaseName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(cmbCloudNotesDatabaseName_KeyPress);
			cmbCloudNotesDatabaseName.KeyUp += new System.Windows.Forms.KeyEventHandler(cmbCloudNotesDatabaseName_KeyUp);
			// 
			// chkCloudNotesFlag
			// 
			chkCloudNotesFlag.AllowDrop = true;
			chkCloudNotesFlag.Appearance = System.Windows.Forms.Appearance.Normal;
			chkCloudNotesFlag.BackColor = System.Drawing.SystemColors.Control;
			chkCloudNotesFlag.CausesValidation = true;
			chkCloudNotesFlag.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkCloudNotesFlag.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkCloudNotesFlag.Enabled = true;
			chkCloudNotesFlag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkCloudNotesFlag.ForeColor = System.Drawing.SystemColors.ControlText;
			chkCloudNotesFlag.Location = new System.Drawing.Point(12, 22);
			chkCloudNotesFlag.Name = "chkCloudNotesFlag";
			chkCloudNotesFlag.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkCloudNotesFlag.Size = new System.Drawing.Size(128, 13);
			chkCloudNotesFlag.TabIndex = 182;
			chkCloudNotesFlag.TabStop = true;
			chkCloudNotesFlag.Text = "Turn On Cloud Notes";
			chkCloudNotesFlag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkCloudNotesFlag.Visible = true;
			chkCloudNotesFlag.CheckStateChanged += new System.EventHandler(chkCloudNotesFlag_CheckStateChanged);
			// 
			// Label3
			// 
			Label3.AllowDrop = true;
			Label3.AutoSize = true;
			Label3.BackColor = System.Drawing.Color.Transparent;
			Label3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label3.ForeColor = System.Drawing.Color.Blue;
			Label3.Location = new System.Drawing.Point(174, 15);
			Label3.MinimumSize = new System.Drawing.Size(275, 16);
			Label3.Name = "Label3";
			Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label3.Size = new System.Drawing.Size(275, 16);
			Label3.TabIndex = 200;
			// 
			// _lblSubLabel_25
			// 
			_lblSubLabel_25.AllowDrop = true;
			_lblSubLabel_25.AutoSize = true;
			_lblSubLabel_25.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_25.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_25.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_25.Location = new System.Drawing.Point(12, 43);
			_lblSubLabel_25.MinimumSize = new System.Drawing.Size(138, 13);
			_lblSubLabel_25.Name = "_lblSubLabel_25";
			_lblSubLabel_25.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_25.Size = new System.Drawing.Size(138, 13);
			_lblSubLabel_25.TabIndex = 199;
			_lblSubLabel_25.Text = "Cloud Notes Database Name";
			_lblSubLabel_25.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_25.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// frmServerSideNotes
			// 
			frmServerSideNotes.AllowDrop = true;
			frmServerSideNotes.BackColor = System.Drawing.SystemColors.Control;
			frmServerSideNotes.Controls.Add(_cmdSubNotesButton_1);
			frmServerSideNotes.Controls.Add(_cmdSubNotesButton_0);
			frmServerSideNotes.Controls.Add(chkServerSideNotes);
			frmServerSideNotes.Controls.Add(cmbCRMDatabaseName);
			frmServerSideNotes.Controls.Add(txtCRMRegId);
			frmServerSideNotes.Controls.Add(lblCRMDatabaseName);
			frmServerSideNotes.Controls.Add(lblCRMRegId);
			frmServerSideNotes.Controls.Add(lblCRMMessage);
			frmServerSideNotes.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmServerSideNotes.Enabled = true;
			frmServerSideNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmServerSideNotes.ForeColor = System.Drawing.Color.Black;
			frmServerSideNotes.Location = new System.Drawing.Point(8, 14);
			frmServerSideNotes.Name = "frmServerSideNotes";
			frmServerSideNotes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmServerSideNotes.Size = new System.Drawing.Size(532, 98);
			frmServerSideNotes.TabIndex = 176;
			frmServerSideNotes.Text = "Cloud Notes Plus";
			frmServerSideNotes.Visible = true;
			// 
			// _cmdSubNotesButton_1
			// 
			_cmdSubNotesButton_1.AllowDrop = true;
			_cmdSubNotesButton_1.BackColor = System.Drawing.SystemColors.Control;
			_cmdSubNotesButton_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmdSubNotesButton_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmdSubNotesButton_1.Location = new System.Drawing.Point(464, 66);
			_cmdSubNotesButton_1.Name = "_cmdSubNotesButton_1";
			_cmdSubNotesButton_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmdSubNotesButton_1.Size = new System.Drawing.Size(52, 21);
			_cmdSubNotesButton_1.TabIndex = 181;
			_cmdSubNotesButton_1.Text = "Export";
			_cmdSubNotesButton_1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmdSubNotesButton_1.UseVisualStyleBackColor = false;
			_cmdSubNotesButton_1.Click += new System.EventHandler(cmdSubNotesButton_Click);
			// 
			// _cmdSubNotesButton_0
			// 
			_cmdSubNotesButton_0.AllowDrop = true;
			_cmdSubNotesButton_0.BackColor = System.Drawing.SystemColors.Control;
			_cmdSubNotesButton_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmdSubNotesButton_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmdSubNotesButton_0.Location = new System.Drawing.Point(466, 14);
			_cmdSubNotesButton_0.Name = "_cmdSubNotesButton_0";
			_cmdSubNotesButton_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmdSubNotesButton_0.Size = new System.Drawing.Size(52, 21);
			_cmdSubNotesButton_0.TabIndex = 180;
			_cmdSubNotesButton_0.Text = "&Save";
			_cmdSubNotesButton_0.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmdSubNotesButton_0.UseVisualStyleBackColor = false;
			_cmdSubNotesButton_0.Click += new System.EventHandler(cmdSubNotesButton_Click);
			// 
			// chkServerSideNotes
			// 
			chkServerSideNotes.AllowDrop = true;
			chkServerSideNotes.Appearance = System.Windows.Forms.Appearance.Normal;
			chkServerSideNotes.BackColor = System.Drawing.SystemColors.Control;
			chkServerSideNotes.CausesValidation = true;
			chkServerSideNotes.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkServerSideNotes.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkServerSideNotes.Enabled = true;
			chkServerSideNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkServerSideNotes.ForeColor = System.Drawing.SystemColors.ControlText;
			chkServerSideNotes.Location = new System.Drawing.Point(12, 22);
			chkServerSideNotes.Name = "chkServerSideNotes";
			chkServerSideNotes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkServerSideNotes.Size = new System.Drawing.Size(156, 13);
			chkServerSideNotes.TabIndex = 177;
			chkServerSideNotes.TabStop = true;
			chkServerSideNotes.Text = "Turn on Cloud Notes Plus";
			chkServerSideNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkServerSideNotes.Visible = true;
			chkServerSideNotes.CheckStateChanged += new System.EventHandler(chkServerSideNotes_CheckStateChanged);
			// 
			// cmbCRMDatabaseName
			// 
			cmbCRMDatabaseName.AllowDrop = true;
			cmbCRMDatabaseName.BackColor = System.Drawing.SystemColors.Window;
			cmbCRMDatabaseName.CausesValidation = true;
			cmbCRMDatabaseName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cmbCRMDatabaseName.Enabled = true;
			cmbCRMDatabaseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmbCRMDatabaseName.ForeColor = System.Drawing.SystemColors.WindowText;
			cmbCRMDatabaseName.IntegralHeight = true;
			cmbCRMDatabaseName.Location = new System.Drawing.Point(130, 40);
			cmbCRMDatabaseName.Name = "cmbCRMDatabaseName";
			cmbCRMDatabaseName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmbCRMDatabaseName.Size = new System.Drawing.Size(391, 21);
			cmbCRMDatabaseName.Sorted = false;
			cmbCRMDatabaseName.TabIndex = 178;
			cmbCRMDatabaseName.TabStop = true;
			cmbCRMDatabaseName.Visible = true;
			cmbCRMDatabaseName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(cmbCRMDatabaseName_KeyPress);
			cmbCRMDatabaseName.KeyUp += new System.Windows.Forms.KeyEventHandler(cmbCRMDatabaseName_KeyUp);
			cmbCRMDatabaseName.SelectionChangeCommitted += new System.EventHandler(cmbCRMDatabaseName_SelectionChangeCommitted);
			// 
			// txtCRMRegId
			// 
			txtCRMRegId.AcceptsReturn = true;
			txtCRMRegId.AllowDrop = true;
			txtCRMRegId.BackColor = System.Drawing.Color.White;
			txtCRMRegId.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtCRMRegId.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtCRMRegId.Enabled = false;
			txtCRMRegId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtCRMRegId.ForeColor = System.Drawing.SystemColors.WindowText;
			txtCRMRegId.Location = new System.Drawing.Point(130, 64);
			txtCRMRegId.MaxLength = 0;
			txtCRMRegId.Name = "txtCRMRegId";
			txtCRMRegId.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtCRMRegId.Size = new System.Drawing.Size(53, 19);
			txtCRMRegId.TabIndex = 179;
			txtCRMRegId.Text = "0";
			txtCRMRegId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lblCRMDatabaseName
			// 
			lblCRMDatabaseName.AllowDrop = true;
			lblCRMDatabaseName.AutoSize = true;
			lblCRMDatabaseName.BackColor = System.Drawing.Color.Transparent;
			lblCRMDatabaseName.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblCRMDatabaseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblCRMDatabaseName.ForeColor = System.Drawing.SystemColors.ControlText;
			lblCRMDatabaseName.Location = new System.Drawing.Point(12, 43);
			lblCRMDatabaseName.MinimumSize = new System.Drawing.Size(105, 13);
			lblCRMDatabaseName.Name = "lblCRMDatabaseName";
			lblCRMDatabaseName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblCRMDatabaseName.Size = new System.Drawing.Size(105, 13);
			lblCRMDatabaseName.TabIndex = 197;
			lblCRMDatabaseName.Text = "MPM Database Name";
			// 
			// lblCRMRegId
			// 
			lblCRMRegId.AllowDrop = true;
			lblCRMRegId.AutoSize = true;
			lblCRMRegId.BackColor = System.Drawing.Color.Transparent;
			lblCRMRegId.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblCRMRegId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblCRMRegId.ForeColor = System.Drawing.SystemColors.ControlText;
			lblCRMRegId.Location = new System.Drawing.Point(12, 66);
			lblCRMRegId.MinimumSize = new System.Drawing.Size(98, 13);
			lblCRMRegId.Name = "lblCRMRegId";
			lblCRMRegId.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblCRMRegId.Size = new System.Drawing.Size(98, 13);
			lblCRMRegId.TabIndex = 196;
			lblCRMRegId.Text = "MPM Registration ID";
			// 
			// lblCRMMessage
			// 
			lblCRMMessage.AllowDrop = true;
			lblCRMMessage.AutoSize = true;
			lblCRMMessage.BackColor = System.Drawing.Color.Transparent;
			lblCRMMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblCRMMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblCRMMessage.ForeColor = System.Drawing.Color.Blue;
			lblCRMMessage.Location = new System.Drawing.Point(174, 15);
			lblCRMMessage.MinimumSize = new System.Drawing.Size(275, 16);
			lblCRMMessage.Name = "lblCRMMessage";
			lblCRMMessage.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblCRMMessage.Size = new System.Drawing.Size(275, 16);
			lblCRMMessage.TabIndex = 195;
			// 
			// fra_Contact_Info
			// 
			fra_Contact_Info.AllowDrop = true;
			fra_Contact_Info.BackColor = System.Drawing.SystemColors.Control;
			fra_Contact_Info.Controls.Add(cmdIdentifyContact);
			fra_Contact_Info.Controls.Add(cmdClearContact);
			fra_Contact_Info.Controls.Add(fra_ChooseContact);
			fra_Contact_Info.Controls.Add(lst_Company);
			fra_Contact_Info.Controls.Add(lst_Contact);
			fra_Contact_Info.Controls.Add(_lblSubLabel_34);
			fra_Contact_Info.Controls.Add(_lblSubLabel_33);
			fra_Contact_Info.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			fra_Contact_Info.Enabled = true;
			fra_Contact_Info.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			fra_Contact_Info.ForeColor = System.Drawing.SystemColors.ControlText;
			fra_Contact_Info.Location = new System.Drawing.Point(8, 24);
			fra_Contact_Info.Name = "fra_Contact_Info";
			fra_Contact_Info.RightToLeft = System.Windows.Forms.RightToLeft.No;
			fra_Contact_Info.Size = new System.Drawing.Size(954, 746);
			fra_Contact_Info.TabIndex = 0;
			fra_Contact_Info.Visible = true;
			// 
			// cmdIdentifyContact
			// 
			cmdIdentifyContact.AllowDrop = true;
			cmdIdentifyContact.BackColor = System.Drawing.SystemColors.Control;
			cmdIdentifyContact.Enabled = false;
			cmdIdentifyContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdIdentifyContact.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdIdentifyContact.Location = new System.Drawing.Point(375, 51);
			cmdIdentifyContact.Name = "cmdIdentifyContact";
			cmdIdentifyContact.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdIdentifyContact.Size = new System.Drawing.Size(105, 21);
			cmdIdentifyContact.TabIndex = 143;
			cmdIdentifyContact.Text = "Identify Contact";
			cmdIdentifyContact.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdIdentifyContact.Click += new System.EventHandler(cmdIdentifyContact_Click);
			cmdIdentifyContact.MouseUp += new System.Windows.Forms.MouseEventHandler(cmdIdentifyContact_MouseUp);
			// 
			// cmdClearContact
			// 
			cmdClearContact.AllowDrop = true;
			cmdClearContact.BackColor = System.Drawing.SystemColors.Control;
			cmdClearContact.Enabled = false;
			cmdClearContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdClearContact.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdClearContact.Location = new System.Drawing.Point(375, 27);
			cmdClearContact.Name = "cmdClearContact";
			cmdClearContact.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdClearContact.Size = new System.Drawing.Size(105, 21);
			cmdClearContact.TabIndex = 142;
			cmdClearContact.Text = "Clear Contact";
			cmdClearContact.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdClearContact.Click += new System.EventHandler(cmdClearContact_Click);
			cmdClearContact.MouseUp += new System.Windows.Forms.MouseEventHandler(cmdClearContact_MouseUp);
			// 
			// fra_ChooseContact
			// 
			fra_ChooseContact.AllowDrop = true;
			fra_ChooseContact.BackColor = System.Drawing.SystemColors.Control;
			fra_ChooseContact.Controls.Add(_txt_find_sub_2);
			fra_ChooseContact.Controls.Add(_txt_find_sub_0);
			fra_ChooseContact.Controls.Add(_txt_find_sub_1);
			fra_ChooseContact.Controls.Add(_cmd_find_contact_1);
			fra_ChooseContact.Controls.Add(_cmd_find_contact_0);
			fra_ChooseContact.Controls.Add(cboChooseContact);
			fra_ChooseContact.Controls.Add(cmdChooseContactSave);
			fra_ChooseContact.Controls.Add(cmdChooseContactCancel);
			fra_ChooseContact.Controls.Add(_lblSubLabel_71);
			fra_ChooseContact.Controls.Add(_lblSubLabel_59);
			fra_ChooseContact.Controls.Add(_lblSubLabel_32);
			fra_ChooseContact.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			fra_ChooseContact.Enabled = true;
			fra_ChooseContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			fra_ChooseContact.ForeColor = System.Drawing.SystemColors.ControlText;
			fra_ChooseContact.Location = new System.Drawing.Point(568, 32);
			fra_ChooseContact.Name = "fra_ChooseContact";
			fra_ChooseContact.RightToLeft = System.Windows.Forms.RightToLeft.No;
			fra_ChooseContact.Size = new System.Drawing.Size(374, 85);
			fra_ChooseContact.TabIndex = 48;
			fra_ChooseContact.Text = "Choose Contact";
			fra_ChooseContact.Visible = false;
			// 
			// _txt_find_sub_2
			// 
			_txt_find_sub_2.AcceptsReturn = true;
			_txt_find_sub_2.AllowDrop = true;
			_txt_find_sub_2.BackColor = System.Drawing.SystemColors.Window;
			_txt_find_sub_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_find_sub_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_find_sub_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_find_sub_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_find_sub_2.Location = new System.Drawing.Point(248, 52);
			_txt_find_sub_2.MaxLength = 0;
			_txt_find_sub_2.Name = "_txt_find_sub_2";
			_txt_find_sub_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_find_sub_2.Size = new System.Drawing.Size(81, 19);
			_txt_find_sub_2.TabIndex = 369;
			// 
			// _txt_find_sub_0
			// 
			_txt_find_sub_0.AcceptsReturn = true;
			_txt_find_sub_0.AllowDrop = true;
			_txt_find_sub_0.BackColor = System.Drawing.SystemColors.Window;
			_txt_find_sub_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_find_sub_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_find_sub_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_find_sub_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_find_sub_0.Location = new System.Drawing.Point(176, 52);
			_txt_find_sub_0.MaxLength = 0;
			_txt_find_sub_0.Name = "_txt_find_sub_0";
			_txt_find_sub_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_find_sub_0.Size = new System.Drawing.Size(65, 19);
			_txt_find_sub_0.TabIndex = 368;
			// 
			// _txt_find_sub_1
			// 
			_txt_find_sub_1.AcceptsReturn = true;
			_txt_find_sub_1.AllowDrop = true;
			_txt_find_sub_1.BackColor = System.Drawing.SystemColors.Window;
			_txt_find_sub_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_txt_find_sub_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_find_sub_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_find_sub_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_find_sub_1.Location = new System.Drawing.Point(176, 20);
			_txt_find_sub_1.MaxLength = 0;
			_txt_find_sub_1.Name = "_txt_find_sub_1";
			_txt_find_sub_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_find_sub_1.Size = new System.Drawing.Size(193, 21);
			_txt_find_sub_1.TabIndex = 307;
			// 
			// _cmd_find_contact_1
			// 
			_cmd_find_contact_1.AllowDrop = true;
			_cmd_find_contact_1.BackColor = System.Drawing.SystemColors.Control;
			_cmd_find_contact_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_find_contact_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_find_contact_1.Location = new System.Drawing.Point(336, 64);
			_cmd_find_contact_1.Name = "_cmd_find_contact_1";
			_cmd_find_contact_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_find_contact_1.Size = new System.Drawing.Size(32, 18);
			_cmd_find_contact_1.TabIndex = 306;
			_cmd_find_contact_1.Text = "Find";
			_cmd_find_contact_1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_find_contact_1.UseVisualStyleBackColor = false;
			_cmd_find_contact_1.Click += new System.EventHandler(cmd_find_contact_Click);
			// 
			// _cmd_find_contact_0
			// 
			_cmd_find_contact_0.AllowDrop = true;
			_cmd_find_contact_0.BackColor = System.Drawing.SystemColors.Control;
			_cmd_find_contact_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_find_contact_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_find_contact_0.Location = new System.Drawing.Point(112, 64);
			_cmd_find_contact_0.Name = "_cmd_find_contact_0";
			_cmd_find_contact_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_find_contact_0.Size = new System.Drawing.Size(45, 18);
			_cmd_find_contact_0.TabIndex = 305;
			_cmd_find_contact_0.Text = "Search";
			_cmd_find_contact_0.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_find_contact_0.UseVisualStyleBackColor = false;
			_cmd_find_contact_0.Visible = false;
			_cmd_find_contact_0.Click += new System.EventHandler(cmd_find_contact_Click);
			// 
			// cboChooseContact
			// 
			cboChooseContact.AllowDrop = true;
			cboChooseContact.BackColor = System.Drawing.SystemColors.Window;
			cboChooseContact.CausesValidation = true;
			cboChooseContact.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboChooseContact.Enabled = true;
			cboChooseContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cboChooseContact.ForeColor = System.Drawing.SystemColors.WindowText;
			cboChooseContact.IntegralHeight = true;
			cboChooseContact.Location = new System.Drawing.Point(6, 20);
			cboChooseContact.Name = "cboChooseContact";
			cboChooseContact.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cboChooseContact.Size = new System.Drawing.Size(161, 21);
			cboChooseContact.Sorted = false;
			cboChooseContact.TabIndex = 26;
			cboChooseContact.TabStop = true;
			cboChooseContact.Visible = true;
			// 
			// cmdChooseContactSave
			// 
			cmdChooseContactSave.AllowDrop = true;
			cmdChooseContactSave.BackColor = System.Drawing.SystemColors.Control;
			cmdChooseContactSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdChooseContactSave.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdChooseContactSave.Location = new System.Drawing.Point(8, 64);
			cmdChooseContactSave.Name = "cmdChooseContactSave";
			cmdChooseContactSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdChooseContactSave.Size = new System.Drawing.Size(39, 18);
			cmdChooseContactSave.TabIndex = 42;
			cmdChooseContactSave.Text = "Save";
			cmdChooseContactSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdChooseContactSave.UseVisualStyleBackColor = false;
			cmdChooseContactSave.Click += new System.EventHandler(cmdChooseContactSave_Click);
			cmdChooseContactSave.MouseUp += new System.Windows.Forms.MouseEventHandler(cmdChooseContactSave_MouseUp);
			// 
			// cmdChooseContactCancel
			// 
			cmdChooseContactCancel.AllowDrop = true;
			cmdChooseContactCancel.BackColor = System.Drawing.SystemColors.Control;
			cmdChooseContactCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdChooseContactCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdChooseContactCancel.Location = new System.Drawing.Point(56, 64);
			cmdChooseContactCancel.Name = "cmdChooseContactCancel";
			cmdChooseContactCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdChooseContactCancel.Size = new System.Drawing.Size(48, 18);
			cmdChooseContactCancel.TabIndex = 43;
			cmdChooseContactCancel.Text = "Cancel";
			cmdChooseContactCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdChooseContactCancel.UseVisualStyleBackColor = false;
			cmdChooseContactCancel.Click += new System.EventHandler(cmdChooseContactCancel_Click);
			cmdChooseContactCancel.MouseUp += new System.Windows.Forms.MouseEventHandler(cmdChooseContactCancel_MouseUp);
			// 
			// _lblSubLabel_71
			// 
			_lblSubLabel_71.AllowDrop = true;
			_lblSubLabel_71.AutoSize = true;
			_lblSubLabel_71.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_71.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_71.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_71.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_71.Location = new System.Drawing.Point(176, 70);
			_lblSubLabel_71.MinimumSize = new System.Drawing.Size(119, 13);
			_lblSubLabel_71.Name = "_lblSubLabel_71";
			_lblSubLabel_71.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_71.Size = new System.Drawing.Size(119, 13);
			_lblSubLabel_71.TabIndex = 362;
			_lblSubLabel_71.Text = "First Name      Last Name";
			_lblSubLabel_71.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_71.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// _lblSubLabel_59
			// 
			_lblSubLabel_59.AllowDrop = true;
			_lblSubLabel_59.AutoSize = true;
			_lblSubLabel_59.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_59.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_59.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_59.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_59.Location = new System.Drawing.Point(176, 40);
			_lblSubLabel_59.MinimumSize = new System.Drawing.Size(130, 13);
			_lblSubLabel_59.Name = "_lblSubLabel_59";
			_lblSubLabel_59.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_59.Size = new System.Drawing.Size(130, 13);
			_lblSubLabel_59.TabIndex = 308;
			_lblSubLabel_59.Text = "Company/ID/Contact Email";
			_lblSubLabel_59.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_59.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// _lblSubLabel_32
			// 
			_lblSubLabel_32.AllowDrop = true;
			_lblSubLabel_32.AutoSize = true;
			_lblSubLabel_32.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_32.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_32.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_32.Location = new System.Drawing.Point(6, 40);
			_lblSubLabel_32.MinimumSize = new System.Drawing.Size(37, 13);
			_lblSubLabel_32.Name = "_lblSubLabel_32";
			_lblSubLabel_32.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_32.Size = new System.Drawing.Size(37, 13);
			_lblSubLabel_32.TabIndex = 202;
			_lblSubLabel_32.Text = "Contact";
			_lblSubLabel_32.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_32.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// lst_Company
			// 
			lst_Company.AllowDrop = true;
			lst_Company.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			lst_Company.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lst_Company.CausesValidation = true;
			lst_Company.Enabled = true;
			lst_Company.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lst_Company.ForeColor = System.Drawing.SystemColors.WindowText;
			lst_Company.IntegralHeight = true;
			lst_Company.Location = new System.Drawing.Point(0, 32);
			lst_Company.MultiColumn = false;
			lst_Company.Name = "lst_Company";
			lst_Company.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lst_Company.Size = new System.Drawing.Size(362, 83);
			lst_Company.Sorted = false;
			lst_Company.TabIndex = 45;
			lst_Company.TabStop = true;
			lst_Company.Visible = true;
			// 
			// lst_Contact
			// 
			lst_Contact.AllowDrop = true;
			lst_Contact.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			lst_Contact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lst_Contact.CausesValidation = true;
			lst_Contact.Enabled = true;
			lst_Contact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lst_Contact.ForeColor = System.Drawing.SystemColors.WindowText;
			lst_Contact.IntegralHeight = true;
			lst_Contact.Location = new System.Drawing.Point(486, 24);
			lst_Contact.MultiColumn = false;
			lst_Contact.Name = "lst_Contact";
			lst_Contact.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lst_Contact.Size = new System.Drawing.Size(449, 83);
			lst_Contact.Sorted = false;
			lst_Contact.TabIndex = 44;
			lst_Contact.TabStop = true;
			lst_Contact.Visible = true;
			// 
			// _lblSubLabel_34
			// 
			_lblSubLabel_34.AllowDrop = true;
			_lblSubLabel_34.AutoSize = true;
			_lblSubLabel_34.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_34.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_34.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_34.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_34.Location = new System.Drawing.Point(6, 8);
			_lblSubLabel_34.MinimumSize = new System.Drawing.Size(99, 13);
			_lblSubLabel_34.Name = "_lblSubLabel_34";
			_lblSubLabel_34.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_34.Size = new System.Drawing.Size(99, 13);
			_lblSubLabel_34.TabIndex = 204;
			_lblSubLabel_34.Text = "Company Information";
			_lblSubLabel_34.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_34.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// _lblSubLabel_33
			// 
			_lblSubLabel_33.AllowDrop = true;
			_lblSubLabel_33.AutoSize = true;
			_lblSubLabel_33.BackColor = System.Drawing.Color.Transparent;
			_lblSubLabel_33.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblSubLabel_33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblSubLabel_33.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblSubLabel_33.Location = new System.Drawing.Point(486, 8);
			_lblSubLabel_33.MinimumSize = new System.Drawing.Size(96, 13);
			_lblSubLabel_33.Name = "_lblSubLabel_33";
			_lblSubLabel_33.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblSubLabel_33.Size = new System.Drawing.Size(96, 13);
			_lblSubLabel_33.TabIndex = 203;
			_lblSubLabel_33.Text = "Contact Information";
			_lblSubLabel_33.Click += new System.EventHandler(lblSubLabel_Click);
			_lblSubLabel_33.DoubleClick += new System.EventHandler(lblSubLabel_DoubleClick);
			// 
			// pnl_Please_Wait
			// 
			pnl_Please_Wait.AllowDrop = true;
			pnl_Please_Wait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Please_Wait.Controls.Add(_lblPleaseWaitStatus_0);
			pnl_Please_Wait.Controls.Add(_lblPleaseWait_85);
			pnl_Please_Wait.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Please_Wait.Location = new System.Drawing.Point(165, 279);
			pnl_Please_Wait.Name = "pnl_Please_Wait";
			pnl_Please_Wait.Size = new System.Drawing.Size(683, 163);
			pnl_Please_Wait.TabIndex = 46;
			pnl_Please_Wait.Visible = false;
			// 
			// _lblPleaseWaitStatus_0
			// 
			_lblPleaseWaitStatus_0.AllowDrop = true;
			_lblPleaseWaitStatus_0.BackColor = System.Drawing.Color.Transparent;
			_lblPleaseWaitStatus_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblPleaseWaitStatus_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblPleaseWaitStatus_0.ForeColor = System.Drawing.Color.Maroon;
			_lblPleaseWaitStatus_0.Location = new System.Drawing.Point(18, 108);
			_lblPleaseWaitStatus_0.MinimumSize = new System.Drawing.Size(648, 27);
			_lblPleaseWaitStatus_0.Name = "_lblPleaseWaitStatus_0";
			_lblPleaseWaitStatus_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblPleaseWaitStatus_0.Size = new System.Drawing.Size(648, 27);
			_lblPleaseWaitStatus_0.TabIndex = 134;
			_lblPleaseWaitStatus_0.Text = "Status";
			_lblPleaseWaitStatus_0.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// _lblPleaseWait_85
			// 
			_lblPleaseWait_85.AllowDrop = true;
			_lblPleaseWait_85.BackColor = System.Drawing.Color.Transparent;
			_lblPleaseWait_85.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblPleaseWait_85.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblPleaseWait_85.ForeColor = System.Drawing.Color.Maroon;
			_lblPleaseWait_85.Location = new System.Drawing.Point(271, 68);
			_lblPleaseWait_85.MinimumSize = new System.Drawing.Size(153, 27);
			_lblPleaseWait_85.Name = "_lblPleaseWait_85";
			_lblPleaseWait_85.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblPleaseWait_85.Size = new System.Drawing.Size(153, 27);
			_lblPleaseWait_85.TabIndex = 47;
			_lblPleaseWait_85.Text = "PLEASE WAIT!";
			_lblPleaseWait_85.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// frm_Subscription
			// 
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			ClientSize = new System.Drawing.Size(963, 811);
			Controls.Add(SSTab_Subscription);
			Controls.Add(fra_Contact_Info);
			Controls.Add(pnl_Please_Wait);
			Controls.Add(MainMenu1);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Location = new System.Drawing.Point(383, 132);
			MaximizeBox = true;
			MinimizeBox = true;
			Name = "frm_Subscription";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			Text = "Subscription";
			commandButtonHelper1.SetStyle(_cmdSubscription_4, 0);
			commandButtonHelper1.SetStyle(_cmdSubscription_3, 0);
			commandButtonHelper1.SetStyle(_cmdSubscription_2, 0);
			commandButtonHelper1.SetStyle(_cmdSubscription_1, 0);
			commandButtonHelper1.SetStyle(_cmdSubscription_0, 0);
			commandButtonHelper1.SetStyle(cmdUpload, 0);
			commandButtonHelper1.SetStyle(cmdUpdateCRMSite, 0);
			commandButtonHelper1.SetStyle(cmdNewLogin, 0);
			commandButtonHelper1.SetStyle(cmd_New_Installation, 0);
			commandButtonHelper1.SetStyle(cmd_Close, 0);
			commandButtonHelper1.SetStyle(cmdInstallValidateSMSTxtMsg, 0);
			commandButtonHelper1.SetStyle(cmdSubInsValidate, 0);
			commandButtonHelper1.SetStyle(cmdDeleteInstallation, 0);
			commandButtonHelper1.SetStyle(cmdUpdateInstallation, 0);
			commandButtonHelper1.SetStyle(cmd_InstallCancel, 0);
			commandButtonHelper1.SetStyle(cmdClearInstallDate, 0);
			commandButtonHelper1.SetStyle(_cmd_auth_btn_1, 0);
			commandButtonHelper1.SetStyle(_cmd_auth_btn_0, 0);
			commandButtonHelper1.SetStyle(cmdMoveLoginFrame, 0);
			commandButtonHelper1.SetStyle(cmd_SaveUser, 0);
			commandButtonHelper1.SetStyle(cmdCancelLoginFrame, 0);
			commandButtonHelper1.SetStyle(cmd_DeleteLogin, 0);
			commandButtonHelper1.SetStyle(cmdEMailSubNotice, 0);
			commandButtonHelper1.SetStyle(cmdResetDemoLogin, 0);
			commandButtonHelper1.SetStyle(cmdGeneratePassword, 0);
			commandButtonHelper1.SetStyle(cmdSubNoteNew, 0);
			commandButtonHelper1.SetStyle(cmdSubNoteSave, 0);
			commandButtonHelper1.SetStyle(cmdSubDocumentMove, 0);
			commandButtonHelper1.SetStyle(cmdSubDocumentDelete, 0);
			commandButtonHelper1.SetStyle(cmdSubDocumentView, 0);
			commandButtonHelper1.SetStyle(cmdSubDocumentSave, 0);
			commandButtonHelper1.SetStyle(cmdSubDocumentNew, 0);
			commandButtonHelper1.SetStyle(cmdSubSIDocView, 0);
			commandButtonHelper1.SetStyle(_cmdSubNotesButton_10, 0);
			commandButtonHelper1.SetStyle(_cmdSubNotesButton_7, 0);
			commandButtonHelper1.SetStyle(_cmdSubNotesButton_6, 0);
			commandButtonHelper1.SetStyle(_cmdSubNotesButton_9, 0);
			commandButtonHelper1.SetStyle(_cmdSubNotesButton_5, 0);
			commandButtonHelper1.SetStyle(_cmdSubNotesButton_8, 0);
			commandButtonHelper1.SetStyle(_cmdSubNotesButton_4, 0);
			commandButtonHelper1.SetStyle(_cmdSubNotesButton_3, 0);
			commandButtonHelper1.SetStyle(_cmdSubNotesButton_2, 0);
			commandButtonHelper1.SetStyle(_cmdSubNotesButton_1, 0);
			commandButtonHelper1.SetStyle(_cmdSubNotesButton_0, 0);
			commandButtonHelper1.SetStyle(cmdIdentifyContact, 0);
			commandButtonHelper1.SetStyle(cmdClearContact, 0);
			commandButtonHelper1.SetStyle(_cmd_find_contact_1, 0);
			commandButtonHelper1.SetStyle(_cmd_find_contact_0, 0);
			commandButtonHelper1.SetStyle(cmdChooseContactSave, 0);
			commandButtonHelper1.SetStyle(cmdChooseContactCancel, 0);
			listBoxHelper1.SetSelectionMode(lstb_SubExecutionFormsDisplay, System.Windows.Forms.SelectionMode.One);
			listBoxHelper1.SetSelectionMode(lst_Company, System.Windows.Forms.SelectionMode.One);
			listBoxHelper1.SetSelectionMode(lst_Contact, System.Windows.Forms.SelectionMode.One);
			optionButtonHelper1.SetStyle(rbCopySSNToCNOverwriteCloudNotes, 0);
			optionButtonHelper1.SetStyle(rbCopySSNToCNAppendCloudNotes, 0);
			optionButtonHelper1.SetStyle(rbEvoLocalNotesOverrideCloudNotes, 0);
			optionButtonHelper1.SetStyle(rbEvoLocalNotesAppendCloudNotes, 0);
			optionButtonHelper1.SetStyle(rbEvoLocalNotesPurgeImportCloudNotes, 0);
			ToolTipMain.SetToolTip(_cmdSubscription_4, "Click To Move Subscription To Another Company Record");
			ToolTipMain.SetToolTip(_cmdSubscription_3, "Click To Move Subscription To Another Company Record");
			ToolTipMain.SetToolTip(_cmdSubscription_2, "Click To Enter A New Subscription");
			ToolTipMain.SetToolTip(_cmdSubscription_1, "Click To Remove Subscription and ALL Related Records");
			ToolTipMain.SetToolTip(_cmdSubscription_0, "Click To Save Subscription Information");
			ToolTipMain.SetToolTip(frm_Sub_Id, "Click To Change Parent Id");
			ToolTipMain.SetToolTip(chkIncludeInactive, "Click To Include Inactive Subscription");
			ToolTipMain.SetToolTip(_chkProductType_13, "Check To Turn On Values");
			ToolTipMain.SetToolTip(_txt_SubNbrOfInstalls_2, "Enter the Number of MPM Installs");
			ToolTipMain.SetToolTip(_chkProductType_12, "Check To Turn On MPM");
			ToolTipMain.SetToolTip(_chkProductType_11, "Check To Turn On History (API)");
			ToolTipMain.SetToolTip(_txt_SubNbrOfInstalls_1, "Enter the Number of Values Installs");
			ToolTipMain.SetToolTip(_chkProductType_10, "Check This To Share Folders, Templates and Notes By Parent Id");
			ToolTipMain.SetToolTip(_chkProductType_9, "Check This To Share Folders, Templates and Notes By Comp Id");
			ToolTipMain.SetToolTip(_chkProductType_7, "Check To Turn On Values");
			ToolTipMain.SetToolTip(_chkProductType_6, "Check To Turn On Star Reports");
			ToolTipMain.SetToolTip(_chkProductType_5, "Check To Turn On Aerodex");
			ToolTipMain.SetToolTip(_chkProductType_4, "Check To Turn On Commercial");
			ToolTipMain.SetToolTip(_chkProductType_3, "Only Active if Company is a Dealer Broker");
			ToolTipMain.SetToolTip(_chkProductType_1, "Check To Turn On Helicopters");
			ToolTipMain.SetToolTip(_txt_SubNbrOfInstalls_0, "Enter the Number of Total Installs");
			ToolTipMain.SetToolTip(_chkProductType_0, "Check To Turn On Business Aircraft");
			ToolTipMain.SetToolTip(txtNbrDaysExpire, "If a Marketing Account, Nbr of Days after install to Expire");
			ToolTipMain.SetToolTip(txtSubMaxExport, "Enter the Max Allowed For Custom Export");
			ToolTipMain.SetToolTip(_lblSubLabel_54, "Double Click To Copy ALL Logins From Another Subid Within This Company (For Salesfoce Serivces ONLY)");
			ToolTipMain.SetToolTip(lblSubUpdateNbrInstalls, "Click To Update The SubId/Login Nbr Of Installs.  Will Count Only Active Installs.");
			ToolTipMain.SetToolTip(lblServerSideNotes, "Click To Set/Clear Access To Server Side Notes");
			ToolTipMain.SetToolTip(chkInstallAdministrator, "Is This Install an Administrator for this SubId");
			ToolTipMain.SetToolTip(txtTextMsgModels, "Model Id's for the Text Message Alert System To Monitor");
			ToolTipMain.SetToolTip(txtSMSTextActiveFlag, "Is The SMS Text Message Service Active (Y/N/A/W)");
			ToolTipMain.SetToolTip(chkInstallEvoMobile, "If Checked User Has Evolution Mobile Turned On");
			ToolTipMain.SetToolTip(cmdInstallValidateSMSTxtMsg, "Click To Validate SMS Text Message Setup");
			ToolTipMain.SetToolTip(_lblSubLabel_20, "Is The SMS Text Message Service Active (Y/N/A/W)");
			ToolTipMain.SetToolTip(lblSendTextMsgEvoMobileLink, "Click To Send Text Message With Evo-Mobile Link");
			ToolTipMain.SetToolTip(lblSendTextMsgOK, "Click To Send Text Message User Must Send OK");
			ToolTipMain.SetToolTip(cmdSubInsValidate, "Click To Validate Install");
			ToolTipMain.SetToolTip(txtSubDefaultAModId, "Enter Default Aircraft Model Id (Zero=No Default Model)");
			ToolTipMain.SetToolTip(txtSubInsNbrRecPerPage, "Enter The Number of Records Per Page To Display");
			ToolTipMain.SetToolTip(txtSubInsDefaultAnalysisMths, "Enter The Number of Months for Default Analysis");
			ToolTipMain.SetToolTip(cmbSubInsBGImageId, "Background Image Id");
			ToolTipMain.SetToolTip(chkInstallationDisplayNoteTag, "Display Note Tag on Aircraft Listing");
			ToolTipMain.SetToolTip(lblSubInsViewEvoMobileLogs, "Click To View Saved Projects For This Install WebPage Report");
			ToolTipMain.SetToolTip(lblSubInsViewSMSTextMsgsReceived, "Click To View Saved Projects For This Install WebPage Report");
			ToolTipMain.SetToolTip(lblSubInsViewSMSTextMsgsSent, "Click To View Saved Projects For This Install WebPage Report");
			ToolTipMain.SetToolTip(lblSubInsViewWebReport, "Click To View Saved Projects and Client Folders For This Install WebPage Report");
			ToolTipMain.SetToolTip(_InstallLinkLabel_2, "Click To Copy/Move Saved Project(s), Client Folder(s) or Saved Export(s)");
			ToolTipMain.SetToolTip(_InstallLinkLabel_1, "Click To ViewSMS Text Message WebPage Link");
			ToolTipMain.SetToolTip(_InstallLinkLabel_0, "Click To View/Hide ASP Logs");
			ToolTipMain.SetToolTip(_chkLoginFlag_2, "Check To Allow Evolution To Export");
			ToolTipMain.SetToolTip(_chkLoginFlag_5, "Check To Allow Evolution EMail Requests");
			ToolTipMain.SetToolTip(_chkLoginFlag_7, "Check To Allow Evolution Text Message Alearts");
			ToolTipMain.SetToolTip(_chkLoginFlag_10, "Check To Allow MPM");
			ToolTipMain.SetToolTip(_chkLoginFlag_9, "Check To Allow Values");
			ToolTipMain.SetToolTip(_chkLoginFlag_6, "Check To Allow Evolution Event Requests");
			ToolTipMain.SetToolTip(_chkLoginFlag_1, "Check If Login Is A Demo Account");
			ToolTipMain.SetToolTip(_chkLoginFlag_0, "Check If Account Is Active");
			ToolTipMain.SetToolTip(lblLoginFlagsHide, "Click To Hide Login Flags");
			ToolTipMain.SetToolTip(cmdMoveLoginFrame, "Click To Move LOGIN To Another SubId Within This Company Record");
			ToolTipMain.SetToolTip(cmdEMailSubNotice, "This will email a subscription notice");
			ToolTipMain.SetToolTip(cmdResetDemoLogin, "This Will Reset This Demo Login, Change Password, Clear Install and Delete Any Saved Projects/Folders");
			ToolTipMain.SetToolTip(lblSubAddInstall, "Click To View Saved Projects For This Install WebPage Report");
			ToolTipMain.SetToolTip(lblLoginShowFlags, "Click To Show Login Flags");
			ToolTipMain.SetToolTip(_chkLoginFlag_3, "Check To Allow Evolution Local Notes");
			ToolTipMain.SetToolTip(chkInstallationChatFlag, "Check To Turn On The Chat System");
			ToolTipMain.SetToolTip(chkInstallationUseLocalNotes, "Does User Have Local Notes");
			ToolTipMain.SetToolTip(_chkLoginFlag_8, "Check To Allow Evolution Event Requests");
			ToolTipMain.SetToolTip(_chkLoginFlag_4, "Check To Allow Evolution Projects");
			ToolTipMain.SetToolTip(chkInstallationActive, "Is This An Active Install");
			ToolTipMain.SetToolTip(chkActiveXFlag, "Allow Use Of Active X Control Report Or ASP");
			ToolTipMain.SetToolTip(chkAutoCheckTS, "Auto Check For Terminal Services");
			ToolTipMain.SetToolTip(chkTerminalService, "Use Terminal Services");
			ToolTipMain.SetToolTip(txtWebPageTimeOut, "In Minutes the Amount of time the webpage will TimeOut at. Min=15 Max=60");
			ToolTipMain.SetToolTip(cmdSubNoteNew, "Click To Clear Form And Enter New Subscription Note");
			ToolTipMain.SetToolTip(cmdSubNoteSave, "Click To Save New or Edited Subscription Note");
			ToolTipMain.SetToolTip(txtSubDragDocument, "Drag Document Here To Add or Double Click To Open Browse Window");
			ToolTipMain.SetToolTip(cmdSubDocumentMove, "Click To Move Selected Document To Another Company");
			ToolTipMain.SetToolTip(cmdSubDocumentDelete, "Click To Delete Selected Document");
			ToolTipMain.SetToolTip(cmdSubDocumentView, "Click To View Document In Seperate Window");
			ToolTipMain.SetToolTip(cmdSubDocumentSave, "Click To Save New or EditedDocument");
			ToolTipMain.SetToolTip(cmdSubDocumentNew, "Click To Clear Form And Enter New Document");
			ToolTipMain.SetToolTip(txtSubDocumentSubject, "Enter Subject of Document");
			ToolTipMain.SetToolTip(_lblSubLabel_48, "Click To Set Calendar To Expiration Date");
			ToolTipMain.SetToolTip(_lblSubLabel_41, "Click To Set Calendar To Document Date");
			ToolTipMain.SetToolTip(frm_SubExecutionFormsGrid, "Click To Export Grid to Excel");
			ToolTipMain.SetToolTip(_txtSubExc_MonthlyAmt_2, "Enter Monthly Net Amount");
			ToolTipMain.SetToolTip(_txtSubExc_MonthlyAmt_1, "Enter Monthly List Amount");
			ToolTipMain.SetToolTip(_txtSubExc_MonthlyAmt_0, "Enter Monthly Billed Amount");
			ToolTipMain.SetToolTip(chkSubSIChangeAutoDisable, "Check If Account Is Active");
			ToolTipMain.SetToolTip(chkSubSIAccoutingIssues, "Check If Account Is Active");
			ToolTipMain.SetToolTip(chkSubSICancellation, "Check If Account Is Active");
			ToolTipMain.SetToolTip(chkSubSIStopUpdates, "Check If Account Is Active");
			ToolTipMain.SetToolTip(chkSubSIStopEvolution, "Check If Account Is Active");
			ToolTipMain.SetToolTip(cmdSubSIDocView, "Click To View Document In Seperate Window");
			ToolTipMain.SetToolTip(txtImportCloudNotesFromDate, "Import Notes From A Specific Date");
			ToolTipMain.SetToolTip(_cmdSubNotesButton_10, "Import Cloud Notes to Server Side Notes");
			ToolTipMain.SetToolTip(_cmdSubNotesButton_7, "Click To Stop Import Of Cloud Notes To CRM SS Notes");
			ToolTipMain.SetToolTip(_cmdSubNotesButton_6, "Click To Stop Import Of CRM SS Notes To Cloud Notes");
			ToolTipMain.SetToolTip(_cmdSubNotesButton_9, "Import Server Side Notes to Cloud Notes");
			ToolTipMain.SetToolTip(rbCopySSNToCNOverwriteCloudNotes, "Click To Delete ALL Notes And Start Over");
			ToolTipMain.SetToolTip(rbCopySSNToCNAppendCloudNotes, "Click If You Want To APPEND ALL Notes");
			ToolTipMain.SetToolTip(_cmdSubNotesButton_5, "Click To Browse For Dir Evo Local Notes MDB");
			ToolTipMain.SetToolTip(_cmdSubNotesButton_8, "Click To Start Import of Evo Local Notes To Cloud Notes");
			ToolTipMain.SetToolTip(rbEvoLocalNotesOverrideCloudNotes, "Click To Delete ALL Notes And Start Over");
			ToolTipMain.SetToolTip(rbEvoLocalNotesAppendCloudNotes, "Click If You Want To APPEND ALL Notes");
			ToolTipMain.SetToolTip(_cmdSubNotesButton_4, "Click To Stop Import Of Evo Local Notes To Clound Notes");
			ToolTipMain.SetToolTip(rbEvoLocalNotesPurgeImportCloudNotes, "Click If To Purge Only IMPORTED Notes");
			ToolTipMain.SetToolTip(_cmdSubNotesButton_3, "Click To Export Cloud Notes To Excel (Aircraft)");
			ToolTipMain.SetToolTip(_cmdSubNotesButton_2, "Click To Save Evolution Cloud Notes Subscription Information");
			ToolTipMain.SetToolTip(chkCloudNotesFlag, "Check If Subscription Has Server Side Notes.  *Local MSAccess Notes Will Override this Setting");
			ToolTipMain.SetToolTip(_cmdSubNotesButton_1, "Click To Export Server Side Notes (Aircraft & Company)");
			ToolTipMain.SetToolTip(_cmdSubNotesButton_0, "Click To Save Server Side Client Notes Subscription Information");
			ToolTipMain.SetToolTip(chkServerSideNotes, "Check If Subscription Has Server Side Notes.  *Local MSAccess Notes Will Override this Setting");
			ToolTipMain.SetToolTip(cmdIdentifyContact, "Identify Login");
			ToolTipMain.SetToolTip(cmdClearContact, "Clear Contact From Login");
			Activated += new System.EventHandler(Form_Activated);
			Closed += new System.EventHandler(Form_Closed);
			FormClosing += new System.Windows.Forms.FormClosingEventHandler(Form_FormClosing);
			((System.ComponentModel.ISupportInitialize) grd_Subscriptions).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_Installations).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_Logins).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_SubJournalNotes).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_SubDocument).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_SubExecutionForms).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_SubSIDocument).EndInit();
			SSTab_Subscription.ResumeLayout(false);
			SSTab_Subscription.PerformLayout();
			_SSTab_Subscription_TabPage0.ResumeLayout(false);
			_SSTab_Subscription_TabPage0.PerformLayout();
			frm_Subscription_Top.ResumeLayout(false);
			frm_Subscription_Top.PerformLayout();
			frmSubscriptionAction.ResumeLayout(false);
			frmSubscriptionAction.PerformLayout();
			frm_Sub_Id.ResumeLayout(false);
			frm_Sub_Id.PerformLayout();
			frm_Sub_Service.ResumeLayout(false);
			frm_Sub_Service.PerformLayout();
			frmSubOptions.ResumeLayout(false);
			frmSubOptions.PerformLayout();
			frmCallbackStatus.ResumeLayout(false);
			frmCallbackStatus.PerformLayout();
			frmStartEndDate.ResumeLayout(false);
			frmStartEndDate.PerformLayout();
			fra_Bottom.ResumeLayout(false);
			fra_Bottom.PerformLayout();
			frm_Sub_Command.ResumeLayout(false);
			frm_Sub_Command.PerformLayout();
			fra_Add_Installation.ResumeLayout(false);
			fra_Add_Installation.PerformLayout();
			frmSMSTextMsg.ResumeLayout(false);
			frmSMSTextMsg.PerformLayout();
			frmInstallFlags.ResumeLayout(false);
			frmInstallFlags.PerformLayout();
			frmInstallASPLogs.ResumeLayout(false);
			frmInstallASPLogs.PerformLayout();
			fraLogin.ResumeLayout(false);
			fraLogin.PerformLayout();
			frm_authentication.ResumeLayout(false);
			frm_authentication.PerformLayout();
			frmLoginFlags.ResumeLayout(false);
			frmLoginFlags.PerformLayout();
			frm_old_Invisible.ResumeLayout(false);
			frm_old_Invisible.PerformLayout();
			_SSTab_Subscription_TabPage1.ResumeLayout(false);
			_SSTab_Subscription_TabPage1.PerformLayout();
			frmSubscriptionNotes.ResumeLayout(false);
			frmSubscriptionNotes.PerformLayout();
			frmSubscriptionNotesControl.ResumeLayout(false);
			frmSubscriptionNotesControl.PerformLayout();
			_SSTab_Subscription_TabPage2.ResumeLayout(false);
			_SSTab_Subscription_TabPage2.PerformLayout();
			frmSubscriptionContracts.ResumeLayout(false);
			frmSubscriptionContracts.PerformLayout();
			frmSubDocumentControl.ResumeLayout(false);
			frmSubDocumentControl.PerformLayout();
			_SSTab_Subscription_TabPage3.ResumeLayout(false);
			_SSTab_Subscription_TabPage3.PerformLayout();
			frm_SubExecutionFormsDisplay.ResumeLayout(false);
			frm_SubExecutionFormsDisplay.PerformLayout();
			frm_SubExecutionFormsGrid.ResumeLayout(false);
			frm_SubExecutionFormsGrid.PerformLayout();
			frm_SubExecutionFormsData.ResumeLayout(false);
			frm_SubExecutionFormsData.PerformLayout();
			_SSTab_Subscription_TabPage4.ResumeLayout(false);
			_SSTab_Subscription_TabPage4.PerformLayout();
			frmSubSIDocControl.ResumeLayout(false);
			frmSubSIDocControl.PerformLayout();
			frmSubSIDocCheckBoxes.ResumeLayout(false);
			frmSubSIDocCheckBoxes.PerformLayout();
			frmSubSIDocDates.ResumeLayout(false);
			frmSubSIDocDates.PerformLayout();
			frmSubSIDocView.ResumeLayout(false);
			frmSubSIDocView.PerformLayout();
			_SSTab_Subscription_TabPage5.ResumeLayout(false);
			_SSTab_Subscription_TabPage5.PerformLayout();
			_SSTab_Subscription_TabPage6.ResumeLayout(false);
			_SSTab_Subscription_TabPage6.PerformLayout();
			frmImportCloudNotesToCRMSSN.ResumeLayout(false);
			frmImportCloudNotesToCRMSSN.PerformLayout();
			frmImportCRMSSNToCloudNotes.ResumeLayout(false);
			frmImportCRMSSNToCloudNotes.PerformLayout();
			frmImportEvoLocalNotesToCloudNotes.ResumeLayout(false);
			frmImportEvoLocalNotesToCloudNotes.PerformLayout();
			frmCloudNotes.ResumeLayout(false);
			frmCloudNotes.PerformLayout();
			frmServerSideNotes.ResumeLayout(false);
			frmServerSideNotes.PerformLayout();
			fra_Contact_Info.ResumeLayout(false);
			fra_Contact_Info.PerformLayout();
			fra_ChooseContact.ResumeLayout(false);
			fra_ChooseContact.PerformLayout();
			pnl_Please_Wait.ResumeLayout(false);
			pnl_Please_Wait.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
		void ReLoadForm(bool addEvents)
		{
			InitializewbSubBrowser1();
			Initializetxt_find_sub();
			Initializetxt_SubNbrOfInstalls();
			InitializetxtSubExc_Type();
			InitializetxtSubExc_MonthlyAmt();
			InitializelblSubLabel();
			InitializelblSubExc_Type();
			InitializelblSubExc_MonthlyAmt();
			InitializelblPleaseWaitStatus();
			InitializelblPleaseWait();
			Initializecmd_find_contact();
			Initializecmd_auth_btn();
			InitializecmdSubscription();
			InitializecmdSubNotesButton();
			InitializechkProductType();
			InitializechkLoginFlag();
			InitializeInstallLinkLabel();
			SSTab_SubscriptionPreviousTab = SSTab_Subscription.SelectedIndex;
		}
		void InitializewbSubBrowser1()
		{
			wbSubBrowser1 = new System.Windows.Forms.WebBrowser[5];
			wbSubBrowser1[1] = _wbSubBrowser1_1;
			wbSubBrowser1[3] = _wbSubBrowser1_3;
			wbSubBrowser1[0] = _wbSubBrowser1_0;
			wbSubBrowser1[4] = _wbSubBrowser1_4;
			wbSubBrowser1[2] = _wbSubBrowser1_2;
		}
		void Initializetxt_find_sub()
		{
			txt_find_sub = new System.Windows.Forms.TextBox[3];
			txt_find_sub[2] = _txt_find_sub_2;
			txt_find_sub[0] = _txt_find_sub_0;
			txt_find_sub[1] = _txt_find_sub_1;
		}
		void Initializetxt_SubNbrOfInstalls()
		{
			txt_SubNbrOfInstalls = new System.Windows.Forms.TextBox[3];
			txt_SubNbrOfInstalls[2] = _txt_SubNbrOfInstalls_2;
			txt_SubNbrOfInstalls[1] = _txt_SubNbrOfInstalls_1;
			txt_SubNbrOfInstalls[0] = _txt_SubNbrOfInstalls_0;
		}
		void InitializetxtSubExc_Type()
		{
			txtSubExc_Type = new System.Windows.Forms.TextBox[2];
			txtSubExc_Type[1] = _txtSubExc_Type_1;
			txtSubExc_Type[0] = _txtSubExc_Type_0;
		}
		void InitializetxtSubExc_MonthlyAmt()
		{
			txtSubExc_MonthlyAmt = new System.Windows.Forms.TextBox[3];
			txtSubExc_MonthlyAmt[2] = _txtSubExc_MonthlyAmt_2;
			txtSubExc_MonthlyAmt[1] = _txtSubExc_MonthlyAmt_1;
			txtSubExc_MonthlyAmt[0] = _txtSubExc_MonthlyAmt_0;
		}
		void InitializelblSubLabel()
		{
			lblSubLabel = new System.Windows.Forms.Label[74];
			lblSubLabel[16] = _lblSubLabel_16;
			lblSubLabel[17] = _lblSubLabel_17;
			lblSubLabel[18] = _lblSubLabel_18;
			lblSubLabel[19] = _lblSubLabel_19;
			lblSubLabel[20] = _lblSubLabel_20;
			lblSubLabel[21] = _lblSubLabel_21;
			lblSubLabel[69] = _lblSubLabel_69;
			lblSubLabel[66] = _lblSubLabel_66;
			lblSubLabel[10] = _lblSubLabel_10;
			lblSubLabel[12] = _lblSubLabel_12;
			lblSubLabel[13] = _lblSubLabel_13;
			lblSubLabel[1] = _lblSubLabel_1;
			lblSubLabel[55] = _lblSubLabel_55;
			lblSubLabel[22] = _lblSubLabel_22;
			lblSubLabel[8] = _lblSubLabel_8;
			lblSubLabel[31] = _lblSubLabel_31;
			lblSubLabel[14] = _lblSubLabel_14;
			lblSubLabel[9] = _lblSubLabel_9;
			lblSubLabel[68] = _lblSubLabel_68;
			lblSubLabel[67] = _lblSubLabel_67;
			lblSubLabel[65] = _lblSubLabel_65;
			lblSubLabel[64] = _lblSubLabel_64;
			lblSubLabel[63] = _lblSubLabel_63;
			lblSubLabel[62] = _lblSubLabel_62;
			lblSubLabel[61] = _lblSubLabel_61;
			lblSubLabel[60] = _lblSubLabel_60;
			lblSubLabel[58] = _lblSubLabel_58;
			lblSubLabel[73] = _lblSubLabel_73;
			lblSubLabel[57] = _lblSubLabel_57;
			lblSubLabel[11] = _lblSubLabel_11;
			lblSubLabel[47] = _lblSubLabel_47;
			lblSubLabel[46] = _lblSubLabel_46;
			lblSubLabel[45] = _lblSubLabel_45;
			lblSubLabel[44] = _lblSubLabel_44;
			lblSubLabel[30] = _lblSubLabel_30;
			lblSubLabel[28] = _lblSubLabel_28;
			lblSubLabel[24] = _lblSubLabel_24;
			lblSubLabel[23] = _lblSubLabel_23;
			lblSubLabel[26] = _lblSubLabel_26;
			lblSubLabel[25] = _lblSubLabel_25;
			lblSubLabel[43] = _lblSubLabel_43;
			lblSubLabel[42] = _lblSubLabel_42;
			lblSubLabel[49] = _lblSubLabel_49;
			lblSubLabel[48] = _lblSubLabel_48;
			lblSubLabel[41] = _lblSubLabel_41;
			lblSubLabel[40] = _lblSubLabel_40;
			lblSubLabel[39] = _lblSubLabel_39;
			lblSubLabel[38] = _lblSubLabel_38;
			lblSubLabel[27] = _lblSubLabel_27;
			lblSubLabel[5] = _lblSubLabel_5;
			lblSubLabel[15] = _lblSubLabel_15;
			lblSubLabel[56] = _lblSubLabel_56;
			lblSubLabel[54] = _lblSubLabel_54;
			lblSubLabel[51] = _lblSubLabel_51;
			lblSubLabel[3] = _lblSubLabel_3;
			lblSubLabel[4] = _lblSubLabel_4;
			lblSubLabel[0] = _lblSubLabel_0;
			lblSubLabel[29] = _lblSubLabel_29;
			lblSubLabel[2] = _lblSubLabel_2;
			lblSubLabel[70] = _lblSubLabel_70;
			lblSubLabel[7] = _lblSubLabel_7;
			lblSubLabel[6] = _lblSubLabel_6;
			lblSubLabel[53] = _lblSubLabel_53;
			lblSubLabel[52] = _lblSubLabel_52;
			lblSubLabel[37] = _lblSubLabel_37;
			lblSubLabel[36] = _lblSubLabel_36;
			lblSubLabel[35] = _lblSubLabel_35;
			lblSubLabel[71] = _lblSubLabel_71;
			lblSubLabel[59] = _lblSubLabel_59;
			lblSubLabel[32] = _lblSubLabel_32;
			lblSubLabel[34] = _lblSubLabel_34;
			lblSubLabel[33] = _lblSubLabel_33;
		}
		void InitializelblSubExc_Type()
		{
			lblSubExc_Type = new System.Windows.Forms.Label[3];
			lblSubExc_Type[2] = _lblSubExc_Type_2;
			lblSubExc_Type[1] = _lblSubExc_Type_1;
			lblSubExc_Type[0] = _lblSubExc_Type_0;
		}
		void InitializelblSubExc_MonthlyAmt()
		{
			lblSubExc_MonthlyAmt = new System.Windows.Forms.Label[7];
			lblSubExc_MonthlyAmt[6] = _lblSubExc_MonthlyAmt_6;
			lblSubExc_MonthlyAmt[5] = _lblSubExc_MonthlyAmt_5;
			lblSubExc_MonthlyAmt[4] = _lblSubExc_MonthlyAmt_4;
			lblSubExc_MonthlyAmt[3] = _lblSubExc_MonthlyAmt_3;
			lblSubExc_MonthlyAmt[2] = _lblSubExc_MonthlyAmt_2;
			lblSubExc_MonthlyAmt[1] = _lblSubExc_MonthlyAmt_1;
			lblSubExc_MonthlyAmt[0] = _lblSubExc_MonthlyAmt_0;
		}
		void InitializelblPleaseWaitStatus()
		{
			lblPleaseWaitStatus = new System.Windows.Forms.Label[1];
			lblPleaseWaitStatus[0] = _lblPleaseWaitStatus_0;
		}
		void InitializelblPleaseWait()
		{
			lblPleaseWait = new System.Windows.Forms.Label[86];
			lblPleaseWait[85] = _lblPleaseWait_85;
		}
		void Initializecmd_find_contact()
		{
			cmd_find_contact = new System.Windows.Forms.Button[2];
			cmd_find_contact[1] = _cmd_find_contact_1;
			cmd_find_contact[0] = _cmd_find_contact_0;
		}
		void Initializecmd_auth_btn()
		{
			cmd_auth_btn = new System.Windows.Forms.Button[2];
			cmd_auth_btn[1] = _cmd_auth_btn_1;
			cmd_auth_btn[0] = _cmd_auth_btn_0;
		}
		void InitializecmdSubscription()
		{
			cmdSubscription = new System.Windows.Forms.Button[5];
			cmdSubscription[4] = _cmdSubscription_4;
			cmdSubscription[3] = _cmdSubscription_3;
			cmdSubscription[2] = _cmdSubscription_2;
			cmdSubscription[1] = _cmdSubscription_1;
			cmdSubscription[0] = _cmdSubscription_0;
		}
		void InitializecmdSubNotesButton()
		{
			cmdSubNotesButton = new System.Windows.Forms.Button[11];
			cmdSubNotesButton[10] = _cmdSubNotesButton_10;
			cmdSubNotesButton[7] = _cmdSubNotesButton_7;
			cmdSubNotesButton[6] = _cmdSubNotesButton_6;
			cmdSubNotesButton[9] = _cmdSubNotesButton_9;
			cmdSubNotesButton[5] = _cmdSubNotesButton_5;
			cmdSubNotesButton[8] = _cmdSubNotesButton_8;
			cmdSubNotesButton[4] = _cmdSubNotesButton_4;
			cmdSubNotesButton[3] = _cmdSubNotesButton_3;
			cmdSubNotesButton[2] = _cmdSubNotesButton_2;
			cmdSubNotesButton[1] = _cmdSubNotesButton_1;
			cmdSubNotesButton[0] = _cmdSubNotesButton_0;
		}
		void InitializechkProductType()
		{
			chkProductType = new System.Windows.Forms.CheckBox[14];
			chkProductType[13] = _chkProductType_13;
			chkProductType[12] = _chkProductType_12;
			chkProductType[11] = _chkProductType_11;
			chkProductType[10] = _chkProductType_10;
			chkProductType[9] = _chkProductType_9;
			chkProductType[8] = _chkProductType_8;
			chkProductType[7] = _chkProductType_7;
			chkProductType[6] = _chkProductType_6;
			chkProductType[5] = _chkProductType_5;
			chkProductType[4] = _chkProductType_4;
			chkProductType[3] = _chkProductType_3;
			chkProductType[1] = _chkProductType_1;
			chkProductType[0] = _chkProductType_0;
		}
		void InitializechkLoginFlag()
		{
			chkLoginFlag = new System.Windows.Forms.CheckBox[11];
			chkLoginFlag[2] = _chkLoginFlag_2;
			chkLoginFlag[5] = _chkLoginFlag_5;
			chkLoginFlag[7] = _chkLoginFlag_7;
			chkLoginFlag[10] = _chkLoginFlag_10;
			chkLoginFlag[9] = _chkLoginFlag_9;
			chkLoginFlag[6] = _chkLoginFlag_6;
			chkLoginFlag[1] = _chkLoginFlag_1;
			chkLoginFlag[0] = _chkLoginFlag_0;
			chkLoginFlag[3] = _chkLoginFlag_3;
			chkLoginFlag[8] = _chkLoginFlag_8;
			chkLoginFlag[4] = _chkLoginFlag_4;
		}
		void InitializeInstallLinkLabel()
		{
			InstallLinkLabel = new System.Windows.Forms.Label[3];
			InstallLinkLabel[2] = _InstallLinkLabel_2;
			InstallLinkLabel[1] = _InstallLinkLabel_1;
			InstallLinkLabel[0] = _InstallLinkLabel_0;
		}
		#endregion
	}
}