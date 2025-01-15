
namespace JETNET_Homebase
{
	partial class frm_Transaction_Documents
	{

		#region "Upgrade Support "
		private static frm_Transaction_Documents m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_Transaction_Documents DefInstance
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
		public static frm_Transaction_Documents CreateInstance()
		{
			frm_Transaction_Documents theInstance = new frm_Transaction_Documents();
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
		private string[] visualControls = new string[]{"components", "ToolTipMain", "mnuFileClose", "mnuFile", "mnuEditNewDocument", "mnuAttachDocument", "mnuEditDocDelete", "mnuEditDelAttachment", "mnuEdit", "MainMenu1", "lst_FinancialDoc", "lbl_FinancialDoc_Records", "pnl_FinancialDocList", "chk_adoc_hide_flag", "cmd_OK", "cmd_Cancel", "lst_Aircraft_Info", "txt_adoc_general_note", "txt_adoc_doc_date", "cbo_doc_type", "Label2", "img_Document_Picture", "lblGeneralNotes", "lbl_Document_Date", "lbl_Document_Type", "pnl_Doc_Info", "tbr_ToolBar_Buttons_Button1", "tbr_ToolBar_Buttons_Button2", "tbr_ToolBar_Buttons_Button3", "tbr_ToolBar_Buttons_Button4", "tbr_ToolBar_Buttons_Button5", "tbr_ToolBar_Buttons_Button6", "tbr_ToolBar_Buttons_Button7", "tbr_ToolBar_Buttons_Button8", "tbr_ToolBar", "lst_SubLeased_to", "txt_adoc_sublease_note", "lbl_SubLeased_to_hdr", "lbl_SubLeased_to_Trustee_Financial_Notes", "pnl_SubLeased_to", "lst_On_Behalf_of", "cmd_Identify_On_Behalf_of", "txt_On_Behalf_of_Notes", "cmd_Clear_On_Behalf_of", "lbl_On_Behalf_of_hdr", "lbl_On_Behalf_of_Notes", "Label6", "pnl_On_Behalf_of", "cmd_Identify_Filed_By", "lst_In_Favor_of", "txt_In_Favor_of_Notes", "cmd_Clear_Filed_By", "lbl_In_Favor_of_hdr", "lbl_In_Favor_of_Notes", "pnl_In_Favor_of", "txt_adoc_doc_amount", "txt_adoc_interest_points", "txt_adoc_number_payments", "txt_adoc_payment_amount", "txt_adoc_last_payment_amount", "txt_adoc_last_payment_date", "lbl_Amount", "lbl_At", "lbl_Percent_Interest_with", "lbl_payments_of", "lbl_each", "lbl_due_on", "lbl_Last_payment_of", "pnl_Values", "cmd_Trustee", "lst_Trustee", "txt_adoc_trustee_note", "cmd_Clear_Trustee", "lbl_Trustee_hdr", "lbl_Trustee_Financial_Notes", "pnl_Trustee", "_tab_Document_TabPage0", "WebBrowser1", "txt_faalog_tape_no", "txt_faalog_starting_frame_no", "txt_faalog_tape_date", "txt_faalog_tape_of", "txt_faalog_tape_to", "txt_faalog_ending_frame_no", "Label3", "Label4", "Label5", "Label7", "Label8", "Label9", "Label10", "pnl_faa_log", "cmdTransOpenDocument", "_tab_Document_TabPage1", "tab_Document", "chkLeaveInProcessing", "cmd_Attach", "cmd_Close_Document_Log", "grd_DocumentLog", "lbl_Status", "Label11", "pnl_Document_Log", "lbl_Aircraft_Documents_hdr", "commandButtonHelper1", "listBoxHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.ToolStripMenuItem mnuFileClose;
		public System.Windows.Forms.ToolStripMenuItem mnuFile;
		public System.Windows.Forms.ToolStripMenuItem mnuEditNewDocument;
		public System.Windows.Forms.ToolStripMenuItem mnuAttachDocument;
		public System.Windows.Forms.ToolStripMenuItem mnuEditDocDelete;
		public System.Windows.Forms.ToolStripMenuItem mnuEditDelAttachment;
		public System.Windows.Forms.ToolStripMenuItem mnuEdit;
		public System.Windows.Forms.MenuStrip MainMenu1;
		public System.Windows.Forms.ListBox lst_FinancialDoc;
		public System.Windows.Forms.Label lbl_FinancialDoc_Records;
		public System.Windows.Forms.Panel pnl_FinancialDocList;
		public System.Windows.Forms.CheckBox chk_adoc_hide_flag;
		public System.Windows.Forms.Button cmd_OK;
		public System.Windows.Forms.Button cmd_Cancel;
		public System.Windows.Forms.ListBox lst_Aircraft_Info;
		public System.Windows.Forms.TextBox txt_adoc_general_note;
		public System.Windows.Forms.TextBox txt_adoc_doc_date;
		public System.Windows.Forms.ComboBox cbo_doc_type;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.PictureBox img_Document_Picture;
		public System.Windows.Forms.Label lblGeneralNotes;
		public System.Windows.Forms.Label lbl_Document_Date;
		public System.Windows.Forms.Label lbl_Document_Type;
		public System.Windows.Forms.Panel pnl_Doc_Info;
		public System.Windows.Forms.ToolStripSeparator tbr_ToolBar_Buttons_Button1;
		public System.Windows.Forms.ToolStripButton tbr_ToolBar_Buttons_Button2;
		public System.Windows.Forms.ToolStripSeparator tbr_ToolBar_Buttons_Button3;
		public System.Windows.Forms.ToolStripButton tbr_ToolBar_Buttons_Button4;
		public System.Windows.Forms.ToolStripSeparator tbr_ToolBar_Buttons_Button5;
		public System.Windows.Forms.ToolStripButton tbr_ToolBar_Buttons_Button6;
		public System.Windows.Forms.ToolStripSeparator tbr_ToolBar_Buttons_Button7;
		public System.Windows.Forms.ToolStripButton tbr_ToolBar_Buttons_Button8;
		public System.Windows.Forms.ToolStrip tbr_ToolBar;
		public System.Windows.Forms.ListBox lst_SubLeased_to;
		public System.Windows.Forms.TextBox txt_adoc_sublease_note;
		public System.Windows.Forms.Label lbl_SubLeased_to_hdr;
		public System.Windows.Forms.Label lbl_SubLeased_to_Trustee_Financial_Notes;
		public System.Windows.Forms.Panel pnl_SubLeased_to;
		public System.Windows.Forms.ListBox lst_On_Behalf_of;
		public System.Windows.Forms.Button cmd_Identify_On_Behalf_of;
		public System.Windows.Forms.TextBox txt_On_Behalf_of_Notes;
		public System.Windows.Forms.Button cmd_Clear_On_Behalf_of;
		public System.Windows.Forms.Label lbl_On_Behalf_of_hdr;
		public System.Windows.Forms.Label lbl_On_Behalf_of_Notes;
		public System.Windows.Forms.Label Label6;
		public System.Windows.Forms.Panel pnl_On_Behalf_of;
		public System.Windows.Forms.Button cmd_Identify_Filed_By;
		public System.Windows.Forms.ListBox lst_In_Favor_of;
		public System.Windows.Forms.TextBox txt_In_Favor_of_Notes;
		public System.Windows.Forms.Button cmd_Clear_Filed_By;
		public System.Windows.Forms.Label lbl_In_Favor_of_hdr;
		public System.Windows.Forms.Label lbl_In_Favor_of_Notes;
		public System.Windows.Forms.Panel pnl_In_Favor_of;
		public System.Windows.Forms.TextBox txt_adoc_doc_amount;
		public System.Windows.Forms.TextBox txt_adoc_interest_points;
		public System.Windows.Forms.TextBox txt_adoc_number_payments;
		public System.Windows.Forms.TextBox txt_adoc_payment_amount;
		public System.Windows.Forms.TextBox txt_adoc_last_payment_amount;
		public System.Windows.Forms.TextBox txt_adoc_last_payment_date;
		public System.Windows.Forms.Label lbl_Amount;
		public System.Windows.Forms.Label lbl_At;
		public System.Windows.Forms.Label lbl_Percent_Interest_with;
		public System.Windows.Forms.Label lbl_payments_of;
		public System.Windows.Forms.Label lbl_each;
		public System.Windows.Forms.Label lbl_due_on;
		public System.Windows.Forms.Label lbl_Last_payment_of;
		public System.Windows.Forms.Panel pnl_Values;
		public System.Windows.Forms.Button cmd_Trustee;
		public System.Windows.Forms.ListBox lst_Trustee;
		public System.Windows.Forms.TextBox txt_adoc_trustee_note;
		public System.Windows.Forms.Button cmd_Clear_Trustee;
		public System.Windows.Forms.Label lbl_Trustee_hdr;
		public System.Windows.Forms.Label lbl_Trustee_Financial_Notes;
		public System.Windows.Forms.Panel pnl_Trustee;
		private System.Windows.Forms.TabPage _tab_Document_TabPage0;
		public System.Windows.Forms.WebBrowser WebBrowser1;
		public System.Windows.Forms.TextBox txt_faalog_tape_no;
		public System.Windows.Forms.TextBox txt_faalog_starting_frame_no;
		public System.Windows.Forms.TextBox txt_faalog_tape_date;
		public System.Windows.Forms.TextBox txt_faalog_tape_of;
		public System.Windows.Forms.TextBox txt_faalog_tape_to;
		public System.Windows.Forms.TextBox txt_faalog_ending_frame_no;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.Label Label4;
		public System.Windows.Forms.Label Label5;
		public System.Windows.Forms.Label Label7;
		public System.Windows.Forms.Label Label8;
		public System.Windows.Forms.Label Label9;
		public System.Windows.Forms.Label Label10;
		public System.Windows.Forms.Panel pnl_faa_log;
		public System.Windows.Forms.Button cmdTransOpenDocument;
		private System.Windows.Forms.TabPage _tab_Document_TabPage1;
		public UpgradeHelpers.Gui.Controls.TabControlExtension tab_Document;
		public System.Windows.Forms.CheckBox chkLeaveInProcessing;
		public System.Windows.Forms.Button cmd_Attach;
		public System.Windows.Forms.Button cmd_Close_Document_Log;
		public UpgradeHelpers.DataGridViewFlex grd_DocumentLog;
		public System.Windows.Forms.Label lbl_Status;
		public System.Windows.Forms.Label Label11;
		public System.Windows.Forms.Panel pnl_Document_Log;
		public System.Windows.Forms.Label lbl_Aircraft_Documents_hdr;
		public UpgradeHelpers.Gui.Controls.CommandButtonHelper commandButtonHelper1;
		public UpgradeHelpers.Gui.Controls.ListBoxHelper listBoxHelper1;
		private int tab_DocumentPreviousTab;
		public System.ComponentModel.ComponentResourceManager resources;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Transaction_Documents));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			MainMenu1 = new System.Windows.Forms.MenuStrip();
			mnuFile = new System.Windows.Forms.ToolStripMenuItem();
			mnuFileClose = new System.Windows.Forms.ToolStripMenuItem();
			mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
			mnuEditNewDocument = new System.Windows.Forms.ToolStripMenuItem();
			mnuAttachDocument = new System.Windows.Forms.ToolStripMenuItem();
			mnuEditDocDelete = new System.Windows.Forms.ToolStripMenuItem();
			mnuEditDelAttachment = new System.Windows.Forms.ToolStripMenuItem();
			pnl_FinancialDocList = new System.Windows.Forms.Panel();
			lst_FinancialDoc = new System.Windows.Forms.ListBox();
			lbl_FinancialDoc_Records = new System.Windows.Forms.Label();
			pnl_Doc_Info = new System.Windows.Forms.Panel();
			chk_adoc_hide_flag = new System.Windows.Forms.CheckBox();
			cmd_OK = new System.Windows.Forms.Button();
			cmd_Cancel = new System.Windows.Forms.Button();
			lst_Aircraft_Info = new System.Windows.Forms.ListBox();
			txt_adoc_general_note = new System.Windows.Forms.TextBox();
			txt_adoc_doc_date = new System.Windows.Forms.TextBox();
			cbo_doc_type = new System.Windows.Forms.ComboBox();
			Label2 = new System.Windows.Forms.Label();
			img_Document_Picture = new System.Windows.Forms.PictureBox();
			lblGeneralNotes = new System.Windows.Forms.Label();
			lbl_Document_Date = new System.Windows.Forms.Label();
			lbl_Document_Type = new System.Windows.Forms.Label();
			tbr_ToolBar = new System.Windows.Forms.ToolStrip();
			tbr_ToolBar_Buttons_Button1 = new System.Windows.Forms.ToolStripSeparator();
			tbr_ToolBar_Buttons_Button2 = new System.Windows.Forms.ToolStripButton();
			tbr_ToolBar_Buttons_Button3 = new System.Windows.Forms.ToolStripSeparator();
			tbr_ToolBar_Buttons_Button4 = new System.Windows.Forms.ToolStripButton();
			tbr_ToolBar_Buttons_Button5 = new System.Windows.Forms.ToolStripSeparator();
			tbr_ToolBar_Buttons_Button6 = new System.Windows.Forms.ToolStripButton();
			tbr_ToolBar_Buttons_Button7 = new System.Windows.Forms.ToolStripSeparator();
			tbr_ToolBar_Buttons_Button8 = new System.Windows.Forms.ToolStripButton();
			tab_Document = new UpgradeHelpers.Gui.Controls.TabControlExtension();
			_tab_Document_TabPage0 = new System.Windows.Forms.TabPage();
			pnl_SubLeased_to = new System.Windows.Forms.Panel();
			lst_SubLeased_to = new System.Windows.Forms.ListBox();
			txt_adoc_sublease_note = new System.Windows.Forms.TextBox();
			lbl_SubLeased_to_hdr = new System.Windows.Forms.Label();
			lbl_SubLeased_to_Trustee_Financial_Notes = new System.Windows.Forms.Label();
			pnl_On_Behalf_of = new System.Windows.Forms.Panel();
			lst_On_Behalf_of = new System.Windows.Forms.ListBox();
			cmd_Identify_On_Behalf_of = new System.Windows.Forms.Button();
			txt_On_Behalf_of_Notes = new System.Windows.Forms.TextBox();
			cmd_Clear_On_Behalf_of = new System.Windows.Forms.Button();
			lbl_On_Behalf_of_hdr = new System.Windows.Forms.Label();
			lbl_On_Behalf_of_Notes = new System.Windows.Forms.Label();
			Label6 = new System.Windows.Forms.Label();
			pnl_In_Favor_of = new System.Windows.Forms.Panel();
			cmd_Identify_Filed_By = new System.Windows.Forms.Button();
			lst_In_Favor_of = new System.Windows.Forms.ListBox();
			txt_In_Favor_of_Notes = new System.Windows.Forms.TextBox();
			cmd_Clear_Filed_By = new System.Windows.Forms.Button();
			lbl_In_Favor_of_hdr = new System.Windows.Forms.Label();
			lbl_In_Favor_of_Notes = new System.Windows.Forms.Label();
			pnl_Values = new System.Windows.Forms.Panel();
			txt_adoc_doc_amount = new System.Windows.Forms.TextBox();
			txt_adoc_interest_points = new System.Windows.Forms.TextBox();
			txt_adoc_number_payments = new System.Windows.Forms.TextBox();
			txt_adoc_payment_amount = new System.Windows.Forms.TextBox();
			txt_adoc_last_payment_amount = new System.Windows.Forms.TextBox();
			txt_adoc_last_payment_date = new System.Windows.Forms.TextBox();
			lbl_Amount = new System.Windows.Forms.Label();
			lbl_At = new System.Windows.Forms.Label();
			lbl_Percent_Interest_with = new System.Windows.Forms.Label();
			lbl_payments_of = new System.Windows.Forms.Label();
			lbl_each = new System.Windows.Forms.Label();
			lbl_due_on = new System.Windows.Forms.Label();
			lbl_Last_payment_of = new System.Windows.Forms.Label();
			pnl_Trustee = new System.Windows.Forms.Panel();
			cmd_Trustee = new System.Windows.Forms.Button();
			lst_Trustee = new System.Windows.Forms.ListBox();
			txt_adoc_trustee_note = new System.Windows.Forms.TextBox();
			cmd_Clear_Trustee = new System.Windows.Forms.Button();
			lbl_Trustee_hdr = new System.Windows.Forms.Label();
			lbl_Trustee_Financial_Notes = new System.Windows.Forms.Label();
			_tab_Document_TabPage1 = new System.Windows.Forms.TabPage();
			WebBrowser1 = new System.Windows.Forms.WebBrowser();
			pnl_faa_log = new System.Windows.Forms.Panel();
			txt_faalog_tape_no = new System.Windows.Forms.TextBox();
			txt_faalog_starting_frame_no = new System.Windows.Forms.TextBox();
			txt_faalog_tape_date = new System.Windows.Forms.TextBox();
			txt_faalog_tape_of = new System.Windows.Forms.TextBox();
			txt_faalog_tape_to = new System.Windows.Forms.TextBox();
			txt_faalog_ending_frame_no = new System.Windows.Forms.TextBox();
			Label3 = new System.Windows.Forms.Label();
			Label4 = new System.Windows.Forms.Label();
			Label5 = new System.Windows.Forms.Label();
			Label7 = new System.Windows.Forms.Label();
			Label8 = new System.Windows.Forms.Label();
			Label9 = new System.Windows.Forms.Label();
			Label10 = new System.Windows.Forms.Label();
			cmdTransOpenDocument = new System.Windows.Forms.Button();
			pnl_Document_Log = new System.Windows.Forms.Panel();
			chkLeaveInProcessing = new System.Windows.Forms.CheckBox();
			cmd_Attach = new System.Windows.Forms.Button();
			cmd_Close_Document_Log = new System.Windows.Forms.Button();
			grd_DocumentLog = new UpgradeHelpers.DataGridViewFlex(components);
			lbl_Status = new System.Windows.Forms.Label();
			Label11 = new System.Windows.Forms.Label();
			lbl_Aircraft_Documents_hdr = new System.Windows.Forms.Label();
			pnl_FinancialDocList.SuspendLayout();
			pnl_Doc_Info.SuspendLayout();
			tbr_ToolBar.SuspendLayout();
			tab_Document.SuspendLayout();
			_tab_Document_TabPage0.SuspendLayout();
			pnl_SubLeased_to.SuspendLayout();
			pnl_On_Behalf_of.SuspendLayout();
			pnl_In_Favor_of.SuspendLayout();
			pnl_Values.SuspendLayout();
			pnl_Trustee.SuspendLayout();
			_tab_Document_TabPage1.SuspendLayout();
			pnl_faa_log.SuspendLayout();
			pnl_Document_Log.SuspendLayout();
			SuspendLayout();
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
			listBoxHelper1 = new UpgradeHelpers.Gui.Controls.ListBoxHelper(components);
			((System.ComponentModel.ISupportInitialize) grd_DocumentLog).BeginInit();
			// 
			// MainMenu1
			// 
			MainMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[]{mnuFile, mnuEdit});
			// 
			// mnuFile
			// 
			mnuFile.Available = true;
			mnuFile.Checked = false;
			mnuFile.Enabled = true;
			mnuFile.Name = "mnuFile";
			mnuFile.Text = "&File";
			mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]{mnuFileClose});
			// 
			// mnuFileClose
			// 
			mnuFileClose.Available = true;
			mnuFileClose.Checked = false;
			mnuFileClose.Enabled = true;
			mnuFileClose.Name = "mnuFileClose";
			mnuFileClose.Text = "&Close";
			mnuFileClose.Click += new System.EventHandler(mnuFileClose_Click);
			// 
			// mnuEdit
			// 
			mnuEdit.Available = true;
			mnuEdit.Checked = false;
			mnuEdit.Enabled = true;
			mnuEdit.Name = "mnuEdit";
			mnuEdit.Text = "Edit";
			mnuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]{mnuEditNewDocument, mnuAttachDocument, mnuEditDocDelete, mnuEditDelAttachment});
			// 
			// mnuEditNewDocument
			// 
			mnuEditNewDocument.Available = true;
			mnuEditNewDocument.Checked = false;
			mnuEditNewDocument.Enabled = true;
			mnuEditNewDocument.Name = "mnuEditNewDocument";
			mnuEditNewDocument.Text = "New Document";
			mnuEditNewDocument.Click += new System.EventHandler(mnuEditNewDocument_Click);
			// 
			// mnuAttachDocument
			// 
			mnuAttachDocument.Available = false;
			mnuAttachDocument.Checked = false;
			mnuAttachDocument.Enabled = true;
			mnuAttachDocument.Name = "mnuAttachDocument";
			mnuAttachDocument.Text = "Attach Document";
			mnuAttachDocument.Click += new System.EventHandler(mnuAttachDocument_Click);
			// 
			// mnuEditDocDelete
			// 
			mnuEditDocDelete.Available = true;
			mnuEditDocDelete.Checked = false;
			mnuEditDocDelete.Enabled = true;
			mnuEditDocDelete.Name = "mnuEditDocDelete";
			mnuEditDocDelete.Text = "Delete Document";
			mnuEditDocDelete.Click += new System.EventHandler(mnuEditDocDelete_Click);
			// 
			// mnuEditDelAttachment
			// 
			mnuEditDelAttachment.Available = true;
			mnuEditDelAttachment.Checked = false;
			mnuEditDelAttachment.Enabled = true;
			mnuEditDelAttachment.Name = "mnuEditDelAttachment";
			mnuEditDelAttachment.Text = "Remove Attached Document";
			mnuEditDelAttachment.Click += new System.EventHandler(mnuEditDelAttachment_Click);
			// 
			// pnl_FinancialDocList
			// 
			pnl_FinancialDocList.AllowDrop = true;
			pnl_FinancialDocList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_FinancialDocList.Controls.Add(lst_FinancialDoc);
			pnl_FinancialDocList.Controls.Add(lbl_FinancialDoc_Records);
			pnl_FinancialDocList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_FinancialDocList.Location = new System.Drawing.Point(3, 70);
			pnl_FinancialDocList.Name = "pnl_FinancialDocList";
			pnl_FinancialDocList.Size = new System.Drawing.Size(204, 120);
			pnl_FinancialDocList.TabIndex = 6;
			// 
			// lst_FinancialDoc
			// 
			lst_FinancialDoc.AllowDrop = true;
			lst_FinancialDoc.BackColor = System.Drawing.SystemColors.Window;
			lst_FinancialDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lst_FinancialDoc.CausesValidation = true;
			lst_FinancialDoc.Enabled = true;
			lst_FinancialDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lst_FinancialDoc.ForeColor = System.Drawing.SystemColors.WindowText;
			lst_FinancialDoc.IntegralHeight = true;
			lst_FinancialDoc.Location = new System.Drawing.Point(6, 20);
			lst_FinancialDoc.MultiColumn = false;
			lst_FinancialDoc.Name = "lst_FinancialDoc";
			lst_FinancialDoc.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lst_FinancialDoc.Size = new System.Drawing.Size(191, 96);
			lst_FinancialDoc.Sorted = false;
			lst_FinancialDoc.TabIndex = 7;
			lst_FinancialDoc.TabStop = true;
			lst_FinancialDoc.Visible = true;
			lst_FinancialDoc.SelectedIndexChanged += new System.EventHandler(lst_FinancialDoc_SelectedIndexChanged);
			// 
			// lbl_FinancialDoc_Records
			// 
			lbl_FinancialDoc_Records.AllowDrop = true;
			lbl_FinancialDoc_Records.BackColor = System.Drawing.Color.Transparent;
			lbl_FinancialDoc_Records.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_FinancialDoc_Records.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_FinancialDoc_Records.ForeColor = System.Drawing.Color.Maroon;
			lbl_FinancialDoc_Records.Location = new System.Drawing.Point(3, 3);
			lbl_FinancialDoc_Records.MinimumSize = new System.Drawing.Size(214, 19);
			lbl_FinancialDoc_Records.Name = "lbl_FinancialDoc_Records";
			lbl_FinancialDoc_Records.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_FinancialDoc_Records.Size = new System.Drawing.Size(214, 19);
			lbl_FinancialDoc_Records.TabIndex = 8;
			lbl_FinancialDoc_Records.Text = "Totals";
			// 
			// pnl_Doc_Info
			// 
			pnl_Doc_Info.AllowDrop = true;
			pnl_Doc_Info.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Doc_Info.Controls.Add(chk_adoc_hide_flag);
			pnl_Doc_Info.Controls.Add(cmd_OK);
			pnl_Doc_Info.Controls.Add(cmd_Cancel);
			pnl_Doc_Info.Controls.Add(lst_Aircraft_Info);
			pnl_Doc_Info.Controls.Add(txt_adoc_general_note);
			pnl_Doc_Info.Controls.Add(txt_adoc_doc_date);
			pnl_Doc_Info.Controls.Add(cbo_doc_type);
			pnl_Doc_Info.Controls.Add(Label2);
			pnl_Doc_Info.Controls.Add(img_Document_Picture);
			pnl_Doc_Info.Controls.Add(lblGeneralNotes);
			pnl_Doc_Info.Controls.Add(lbl_Document_Date);
			pnl_Doc_Info.Controls.Add(lbl_Document_Type);
			pnl_Doc_Info.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Doc_Info.Location = new System.Drawing.Point(207, 70);
			pnl_Doc_Info.Name = "pnl_Doc_Info";
			pnl_Doc_Info.Size = new System.Drawing.Size(767, 120);
			pnl_Doc_Info.TabIndex = 1;
			// 
			// chk_adoc_hide_flag
			// 
			chk_adoc_hide_flag.AllowDrop = true;
			chk_adoc_hide_flag.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_adoc_hide_flag.BackColor = System.Drawing.SystemColors.Control;
			chk_adoc_hide_flag.CausesValidation = true;
			chk_adoc_hide_flag.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_adoc_hide_flag.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_adoc_hide_flag.Enabled = true;
			chk_adoc_hide_flag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_adoc_hide_flag.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_adoc_hide_flag.Location = new System.Drawing.Point(662, 10);
			chk_adoc_hide_flag.Name = "chk_adoc_hide_flag";
			chk_adoc_hide_flag.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_adoc_hide_flag.Size = new System.Drawing.Size(99, 16);
			chk_adoc_hide_flag.TabIndex = 79;
			chk_adoc_hide_flag.TabStop = true;
			chk_adoc_hide_flag.Text = "Hide Document";
			chk_adoc_hide_flag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_adoc_hide_flag.Visible = true;
			// 
			// cmd_OK
			// 
			cmd_OK.AllowDrop = true;
			cmd_OK.BackColor = System.Drawing.SystemColors.Control;
			cmd_OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_OK.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_OK.Location = new System.Drawing.Point(680, 43);
			cmd_OK.Name = "cmd_OK";
			cmd_OK.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_OK.Size = new System.Drawing.Size(62, 27);
			cmd_OK.TabIndex = 14;
			cmd_OK.Text = "Save";
			cmd_OK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_OK.UseVisualStyleBackColor = false;
			cmd_OK.Click += new System.EventHandler(cmd_OK_Click);
			// 
			// cmd_Cancel
			// 
			cmd_Cancel.AllowDrop = true;
			cmd_Cancel.BackColor = System.Drawing.SystemColors.Control;
			cmd_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Cancel.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Cancel.Location = new System.Drawing.Point(681, 75);
			cmd_Cancel.Name = "cmd_Cancel";
			cmd_Cancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Cancel.Size = new System.Drawing.Size(61, 27);
			cmd_Cancel.TabIndex = 13;
			cmd_Cancel.Text = "Close";
			cmd_Cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Cancel.UseVisualStyleBackColor = false;
			cmd_Cancel.Click += new System.EventHandler(cmd_cancel_Click);
			// 
			// lst_Aircraft_Info
			// 
			lst_Aircraft_Info.AllowDrop = true;
			lst_Aircraft_Info.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			lst_Aircraft_Info.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lst_Aircraft_Info.CausesValidation = true;
			lst_Aircraft_Info.Enabled = false;
			lst_Aircraft_Info.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lst_Aircraft_Info.ForeColor = System.Drawing.SystemColors.WindowText;
			lst_Aircraft_Info.IntegralHeight = true;
			lst_Aircraft_Info.Location = new System.Drawing.Point(433, 32);
			lst_Aircraft_Info.MultiColumn = false;
			lst_Aircraft_Info.Name = "lst_Aircraft_Info";
			lst_Aircraft_Info.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lst_Aircraft_Info.Size = new System.Drawing.Size(223, 83);
			lst_Aircraft_Info.Sorted = false;
			lst_Aircraft_Info.TabIndex = 11;
			lst_Aircraft_Info.TabStop = true;
			lst_Aircraft_Info.Visible = true;
			// 
			// txt_adoc_general_note
			// 
			txt_adoc_general_note.AcceptsReturn = true;
			txt_adoc_general_note.AllowDrop = true;
			txt_adoc_general_note.BackColor = System.Drawing.SystemColors.Window;
			txt_adoc_general_note.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_adoc_general_note.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_adoc_general_note.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_adoc_general_note.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_adoc_general_note.Location = new System.Drawing.Point(10, 54);
			txt_adoc_general_note.MaxLength = 500;
			txt_adoc_general_note.Multiline = true;
			txt_adoc_general_note.Name = "txt_adoc_general_note";
			txt_adoc_general_note.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_adoc_general_note.Size = new System.Drawing.Size(419, 58);
			txt_adoc_general_note.TabIndex = 9;
			// 
			// txt_adoc_doc_date
			// 
			txt_adoc_doc_date.AcceptsReturn = true;
			txt_adoc_doc_date.AllowDrop = true;
			txt_adoc_doc_date.BackColor = System.Drawing.SystemColors.Window;
			txt_adoc_doc_date.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_adoc_doc_date.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_adoc_doc_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_adoc_doc_date.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_adoc_doc_date.Location = new System.Drawing.Point(40, 32);
			txt_adoc_doc_date.MaxLength = 0;
			txt_adoc_doc_date.Name = "txt_adoc_doc_date";
			txt_adoc_doc_date.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_adoc_doc_date.Size = new System.Drawing.Size(66, 19);
			txt_adoc_doc_date.TabIndex = 3;
			txt_adoc_doc_date.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// cbo_doc_type
			// 
			cbo_doc_type.AllowDrop = true;
			cbo_doc_type.BackColor = System.Drawing.SystemColors.Window;
			cbo_doc_type.CausesValidation = true;
			cbo_doc_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_doc_type.Enabled = true;
			cbo_doc_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_doc_type.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_doc_type.IntegralHeight = true;
			cbo_doc_type.Location = new System.Drawing.Point(41, 7);
			cbo_doc_type.Name = "cbo_doc_type";
			cbo_doc_type.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_doc_type.Size = new System.Drawing.Size(230, 21);
			cbo_doc_type.Sorted = false;
			cbo_doc_type.TabIndex = 2;
			cbo_doc_type.TabStop = true;
			cbo_doc_type.Visible = true;
			cbo_doc_type.SelectedIndexChanged += new System.EventHandler(cbo_doc_type_SelectedIndexChanged);
			// 
			// Label2
			// 
			Label2.AllowDrop = true;
			Label2.AutoSize = true;
			Label2.BackColor = System.Drawing.Color.Transparent;
			Label2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label2.ForeColor = System.Drawing.SystemColors.ControlText;
			Label2.Location = new System.Drawing.Point(433, 12);
			Label2.MinimumSize = new System.Drawing.Size(37, 13);
			Label2.Name = "Label2";
			Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label2.Size = new System.Drawing.Size(37, 13);
			Label2.TabIndex = 12;
			Label2.Text = "Aircraft:";
			Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// img_Document_Picture
			// 
			img_Document_Picture.AllowDrop = true;
			img_Document_Picture.BorderStyle = System.Windows.Forms.BorderStyle.None;
			img_Document_Picture.Enabled = true;
			img_Document_Picture.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			img_Document_Picture.Image = (System.Drawing.Image) resources.GetObject("img_Document_Picture.Image");
			img_Document_Picture.Location = new System.Drawing.Point(328, 5);
			img_Document_Picture.Name = "img_Document_Picture";
			img_Document_Picture.Size = new System.Drawing.Size(53, 46);
			img_Document_Picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			img_Document_Picture.Visible = true;
			// 
			// lblGeneralNotes
			// 
			lblGeneralNotes.AllowDrop = true;
			lblGeneralNotes.AutoSize = true;
			lblGeneralNotes.BackColor = System.Drawing.Color.Transparent;
			lblGeneralNotes.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblGeneralNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblGeneralNotes.ForeColor = System.Drawing.SystemColors.ControlText;
			lblGeneralNotes.Location = new System.Drawing.Point(162, 36);
			lblGeneralNotes.MinimumSize = new System.Drawing.Size(80, 13);
			lblGeneralNotes.Name = "lblGeneralNotes";
			lblGeneralNotes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblGeneralNotes.Size = new System.Drawing.Size(80, 13);
			lblGeneralNotes.TabIndex = 10;
			lblGeneralNotes.Text = "General Notes:";
			lblGeneralNotes.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lbl_Document_Date
			// 
			lbl_Document_Date.AllowDrop = true;
			lbl_Document_Date.AutoSize = true;
			lbl_Document_Date.BackColor = System.Drawing.Color.Transparent;
			lbl_Document_Date.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_Document_Date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_Document_Date.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_Document_Date.Location = new System.Drawing.Point(12, 35);
			lbl_Document_Date.MinimumSize = new System.Drawing.Size(26, 13);
			lbl_Document_Date.Name = "lbl_Document_Date";
			lbl_Document_Date.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_Document_Date.Size = new System.Drawing.Size(26, 13);
			lbl_Document_Date.TabIndex = 5;
			lbl_Document_Date.Text = "Date:";
			lbl_Document_Date.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lbl_Document_Type
			// 
			lbl_Document_Type.AllowDrop = true;
			lbl_Document_Type.AutoSize = true;
			lbl_Document_Type.BackColor = System.Drawing.Color.Transparent;
			lbl_Document_Type.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_Document_Type.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_Document_Type.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_Document_Type.Location = new System.Drawing.Point(11, 8);
			lbl_Document_Type.MinimumSize = new System.Drawing.Size(27, 13);
			lbl_Document_Type.Name = "lbl_Document_Type";
			lbl_Document_Type.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_Document_Type.Size = new System.Drawing.Size(27, 13);
			lbl_Document_Type.TabIndex = 4;
			lbl_Document_Type.Text = "Type:";
			lbl_Document_Type.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// tbr_ToolBar
			// 
			tbr_ToolBar.AllowDrop = true;
			tbr_ToolBar.Dock = System.Windows.Forms.DockStyle.Top;
			tbr_ToolBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			tbr_ToolBar.Location = new System.Drawing.Point(0, 24);
			tbr_ToolBar.Name = "tbr_ToolBar";
			tbr_ToolBar.ShowItemToolTips = true;
			tbr_ToolBar.Size = new System.Drawing.Size(979, 28);
			tbr_ToolBar.TabIndex = 0;
			tbr_ToolBar.Items.Add(tbr_ToolBar_Buttons_Button1);
			tbr_ToolBar.Items.Add(tbr_ToolBar_Buttons_Button2);
			tbr_ToolBar.Items.Add(tbr_ToolBar_Buttons_Button3);
			tbr_ToolBar.Items.Add(tbr_ToolBar_Buttons_Button4);
			tbr_ToolBar.Items.Add(tbr_ToolBar_Buttons_Button5);
			tbr_ToolBar.Items.Add(tbr_ToolBar_Buttons_Button6);
			tbr_ToolBar.Items.Add(tbr_ToolBar_Buttons_Button7);
			tbr_ToolBar.Items.Add(tbr_ToolBar_Buttons_Button8);
			// 
			// tbr_ToolBar_Buttons_Button1
			// 
			tbr_ToolBar_Buttons_Button1.Size = new System.Drawing.Size(6, 22);
			tbr_ToolBar_Buttons_Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			tbr_ToolBar_Buttons_Button1.Click += new System.EventHandler(tbr_ToolBar_ButtonClick);
			// 
			// tbr_ToolBar_Buttons_Button2
			// 
			tbr_ToolBar_Buttons_Button2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
			tbr_ToolBar_Buttons_Button2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			tbr_ToolBar_Buttons_Button2.Size = new System.Drawing.Size(24, 22);
			tbr_ToolBar_Buttons_Button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			tbr_ToolBar_Buttons_Button2.Click += new System.EventHandler(tbr_ToolBar_ButtonClick);
			// 
			// tbr_ToolBar_Buttons_Button3
			// 
			tbr_ToolBar_Buttons_Button3.Size = new System.Drawing.Size(6, 22);
			tbr_ToolBar_Buttons_Button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			tbr_ToolBar_Buttons_Button3.Click += new System.EventHandler(tbr_ToolBar_ButtonClick);
			// 
			// tbr_ToolBar_Buttons_Button4
			// 
			tbr_ToolBar_Buttons_Button4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
			tbr_ToolBar_Buttons_Button4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			tbr_ToolBar_Buttons_Button4.Size = new System.Drawing.Size(24, 22);
			tbr_ToolBar_Buttons_Button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			tbr_ToolBar_Buttons_Button4.Click += new System.EventHandler(tbr_ToolBar_ButtonClick);
			// 
			// tbr_ToolBar_Buttons_Button5
			// 
			tbr_ToolBar_Buttons_Button5.Size = new System.Drawing.Size(6, 22);
			tbr_ToolBar_Buttons_Button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			tbr_ToolBar_Buttons_Button5.Click += new System.EventHandler(tbr_ToolBar_ButtonClick);
			// 
			// tbr_ToolBar_Buttons_Button6
			// 
			tbr_ToolBar_Buttons_Button6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
			tbr_ToolBar_Buttons_Button6.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			tbr_ToolBar_Buttons_Button6.Size = new System.Drawing.Size(24, 22);
			tbr_ToolBar_Buttons_Button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			tbr_ToolBar_Buttons_Button6.Click += new System.EventHandler(tbr_ToolBar_ButtonClick);
			// 
			// tbr_ToolBar_Buttons_Button7
			// 
			tbr_ToolBar_Buttons_Button7.Size = new System.Drawing.Size(6, 22);
			tbr_ToolBar_Buttons_Button7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			tbr_ToolBar_Buttons_Button7.Click += new System.EventHandler(tbr_ToolBar_ButtonClick);
			// 
			// tbr_ToolBar_Buttons_Button8
			// 
			tbr_ToolBar_Buttons_Button8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
			tbr_ToolBar_Buttons_Button8.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			tbr_ToolBar_Buttons_Button8.Size = new System.Drawing.Size(24, 22);
			tbr_ToolBar_Buttons_Button8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			tbr_ToolBar_Buttons_Button8.Click += new System.EventHandler(tbr_ToolBar_ButtonClick);
			// 
			// tab_Document
			// 
			tab_Document.Alignment = System.Windows.Forms.TabAlignment.Top;
			tab_Document.AllowDrop = true;
			tab_Document.Controls.Add(_tab_Document_TabPage0);
			tab_Document.Controls.Add(_tab_Document_TabPage1);
			tab_Document.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			tab_Document.ItemSize = new System.Drawing.Size(484, 14);
			tab_Document.Location = new System.Drawing.Point(3, 192);
			tab_Document.Multiline = true;
			tab_Document.Name = "tab_Document";
			tab_Document.Size = new System.Drawing.Size(975, 493);
			tab_Document.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			tab_Document.TabIndex = 20;
			tab_Document.SelectedIndexChanged += new System.EventHandler(tab_Document_SelectedIndexChanged);
			// 
			// _tab_Document_TabPage0
			// 
			_tab_Document_TabPage0.Controls.Add(pnl_SubLeased_to);
			_tab_Document_TabPage0.Controls.Add(pnl_On_Behalf_of);
			_tab_Document_TabPage0.Controls.Add(pnl_In_Favor_of);
			_tab_Document_TabPage0.Controls.Add(pnl_Values);
			_tab_Document_TabPage0.Controls.Add(pnl_Trustee);
			_tab_Document_TabPage0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Document_TabPage0.Text = "Document Information";
			// 
			// pnl_SubLeased_to
			// 
			pnl_SubLeased_to.AllowDrop = true;
			pnl_SubLeased_to.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_SubLeased_to.Controls.Add(lst_SubLeased_to);
			pnl_SubLeased_to.Controls.Add(txt_adoc_sublease_note);
			pnl_SubLeased_to.Controls.Add(lbl_SubLeased_to_hdr);
			pnl_SubLeased_to.Controls.Add(lbl_SubLeased_to_Trustee_Financial_Notes);
			pnl_SubLeased_to.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_SubLeased_to.Location = new System.Drawing.Point(722, 31);
			pnl_SubLeased_to.Name = "pnl_SubLeased_to";
			pnl_SubLeased_to.Size = new System.Drawing.Size(236, 329);
			pnl_SubLeased_to.TabIndex = 71;
			// 
			// lst_SubLeased_to
			// 
			lst_SubLeased_to.AllowDrop = true;
			lst_SubLeased_to.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			lst_SubLeased_to.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lst_SubLeased_to.CausesValidation = true;
			lst_SubLeased_to.Enabled = false;
			lst_SubLeased_to.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lst_SubLeased_to.ForeColor = System.Drawing.SystemColors.WindowText;
			lst_SubLeased_to.IntegralHeight = true;
			lst_SubLeased_to.Location = new System.Drawing.Point(13, 18);
			lst_SubLeased_to.MultiColumn = false;
			lst_SubLeased_to.Name = "lst_SubLeased_to";
			lst_SubLeased_to.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lst_SubLeased_to.Size = new System.Drawing.Size(216, 57);
			lst_SubLeased_to.Sorted = false;
			lst_SubLeased_to.TabIndex = 73;
			lst_SubLeased_to.TabStop = true;
			lst_SubLeased_to.Visible = true;
			// 
			// txt_adoc_sublease_note
			// 
			txt_adoc_sublease_note.AcceptsReturn = true;
			txt_adoc_sublease_note.AllowDrop = true;
			txt_adoc_sublease_note.BackColor = System.Drawing.SystemColors.Window;
			txt_adoc_sublease_note.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_adoc_sublease_note.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_adoc_sublease_note.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_adoc_sublease_note.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_adoc_sublease_note.Location = new System.Drawing.Point(13, 96);
			txt_adoc_sublease_note.MaxLength = 0;
			txt_adoc_sublease_note.Multiline = true;
			txt_adoc_sublease_note.Name = "txt_adoc_sublease_note";
			txt_adoc_sublease_note.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_adoc_sublease_note.Size = new System.Drawing.Size(216, 229);
			txt_adoc_sublease_note.TabIndex = 72;
			// 
			// lbl_SubLeased_to_hdr
			// 
			lbl_SubLeased_to_hdr.AllowDrop = true;
			lbl_SubLeased_to_hdr.BackColor = System.Drawing.Color.Transparent;
			lbl_SubLeased_to_hdr.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_SubLeased_to_hdr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_SubLeased_to_hdr.ForeColor = System.Drawing.Color.Maroon;
			lbl_SubLeased_to_hdr.Location = new System.Drawing.Point(3, 2);
			lbl_SubLeased_to_hdr.MinimumSize = new System.Drawing.Size(124, 20);
			lbl_SubLeased_to_hdr.Name = "lbl_SubLeased_to_hdr";
			lbl_SubLeased_to_hdr.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_SubLeased_to_hdr.Size = new System.Drawing.Size(124, 20);
			lbl_SubLeased_to_hdr.TabIndex = 75;
			lbl_SubLeased_to_hdr.Text = "Sub-Leased To:";
			// 
			// lbl_SubLeased_to_Trustee_Financial_Notes
			// 
			lbl_SubLeased_to_Trustee_Financial_Notes.AllowDrop = true;
			lbl_SubLeased_to_Trustee_Financial_Notes.BackColor = System.Drawing.Color.Transparent;
			lbl_SubLeased_to_Trustee_Financial_Notes.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_SubLeased_to_Trustee_Financial_Notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_SubLeased_to_Trustee_Financial_Notes.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_SubLeased_to_Trustee_Financial_Notes.Location = new System.Drawing.Point(10, 79);
			lbl_SubLeased_to_Trustee_Financial_Notes.MinimumSize = new System.Drawing.Size(81, 17);
			lbl_SubLeased_to_Trustee_Financial_Notes.Name = "lbl_SubLeased_to_Trustee_Financial_Notes";
			lbl_SubLeased_to_Trustee_Financial_Notes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_SubLeased_to_Trustee_Financial_Notes.Size = new System.Drawing.Size(81, 17);
			lbl_SubLeased_to_Trustee_Financial_Notes.TabIndex = 74;
			lbl_SubLeased_to_Trustee_Financial_Notes.Text = "Sublease Notes:";
			// 
			// pnl_On_Behalf_of
			// 
			pnl_On_Behalf_of.AllowDrop = true;
			pnl_On_Behalf_of.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_On_Behalf_of.Controls.Add(lst_On_Behalf_of);
			pnl_On_Behalf_of.Controls.Add(cmd_Identify_On_Behalf_of);
			pnl_On_Behalf_of.Controls.Add(txt_On_Behalf_of_Notes);
			pnl_On_Behalf_of.Controls.Add(cmd_Clear_On_Behalf_of);
			pnl_On_Behalf_of.Controls.Add(lbl_On_Behalf_of_hdr);
			pnl_On_Behalf_of.Controls.Add(lbl_On_Behalf_of_Notes);
			pnl_On_Behalf_of.Controls.Add(Label6);
			pnl_On_Behalf_of.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_On_Behalf_of.Location = new System.Drawing.Point(21, 117);
			pnl_On_Behalf_of.Name = "pnl_On_Behalf_of";
			pnl_On_Behalf_of.Size = new System.Drawing.Size(699, 86);
			pnl_On_Behalf_of.TabIndex = 63;
			// 
			// lst_On_Behalf_of
			// 
			lst_On_Behalf_of.AllowDrop = true;
			lst_On_Behalf_of.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			lst_On_Behalf_of.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lst_On_Behalf_of.CausesValidation = true;
			lst_On_Behalf_of.Enabled = false;
			lst_On_Behalf_of.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lst_On_Behalf_of.ForeColor = System.Drawing.SystemColors.WindowText;
			lst_On_Behalf_of.IntegralHeight = true;
			lst_On_Behalf_of.Location = new System.Drawing.Point(12, 21);
			lst_On_Behalf_of.MultiColumn = false;
			lst_On_Behalf_of.Name = "lst_On_Behalf_of";
			lst_On_Behalf_of.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lst_On_Behalf_of.Size = new System.Drawing.Size(241, 57);
			lst_On_Behalf_of.Sorted = false;
			lst_On_Behalf_of.TabIndex = 67;
			lst_On_Behalf_of.TabStop = true;
			lst_On_Behalf_of.Visible = true;
			// 
			// cmd_Identify_On_Behalf_of
			// 
			cmd_Identify_On_Behalf_of.AllowDrop = true;
			cmd_Identify_On_Behalf_of.BackColor = System.Drawing.SystemColors.Control;
			cmd_Identify_On_Behalf_of.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Identify_On_Behalf_of.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Identify_On_Behalf_of.Location = new System.Drawing.Point(265, 20);
			cmd_Identify_On_Behalf_of.Name = "cmd_Identify_On_Behalf_of";
			cmd_Identify_On_Behalf_of.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Identify_On_Behalf_of.Size = new System.Drawing.Size(65, 27);
			cmd_Identify_On_Behalf_of.TabIndex = 66;
			cmd_Identify_On_Behalf_of.Text = "Identify";
			cmd_Identify_On_Behalf_of.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Identify_On_Behalf_of.UseVisualStyleBackColor = false;
			cmd_Identify_On_Behalf_of.Click += new System.EventHandler(cmd_Identify_On_Behalf_of_Click);
			// 
			// txt_On_Behalf_of_Notes
			// 
			txt_On_Behalf_of_Notes.AcceptsReturn = true;
			txt_On_Behalf_of_Notes.AllowDrop = true;
			txt_On_Behalf_of_Notes.BackColor = System.Drawing.SystemColors.Window;
			txt_On_Behalf_of_Notes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_On_Behalf_of_Notes.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_On_Behalf_of_Notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_On_Behalf_of_Notes.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_On_Behalf_of_Notes.Location = new System.Drawing.Point(342, 21);
			txt_On_Behalf_of_Notes.MaxLength = 0;
			txt_On_Behalf_of_Notes.Multiline = true;
			txt_On_Behalf_of_Notes.Name = "txt_On_Behalf_of_Notes";
			txt_On_Behalf_of_Notes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_On_Behalf_of_Notes.Size = new System.Drawing.Size(346, 54);
			txt_On_Behalf_of_Notes.TabIndex = 65;
			// 
			// cmd_Clear_On_Behalf_of
			// 
			cmd_Clear_On_Behalf_of.AllowDrop = true;
			cmd_Clear_On_Behalf_of.BackColor = System.Drawing.SystemColors.Control;
			cmd_Clear_On_Behalf_of.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Clear_On_Behalf_of.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Clear_On_Behalf_of.Location = new System.Drawing.Point(265, 50);
			cmd_Clear_On_Behalf_of.Name = "cmd_Clear_On_Behalf_of";
			cmd_Clear_On_Behalf_of.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Clear_On_Behalf_of.Size = new System.Drawing.Size(65, 27);
			cmd_Clear_On_Behalf_of.TabIndex = 64;
			cmd_Clear_On_Behalf_of.Text = "Clear";
			cmd_Clear_On_Behalf_of.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Clear_On_Behalf_of.UseVisualStyleBackColor = false;
			cmd_Clear_On_Behalf_of.Click += new System.EventHandler(cmd_Clear_On_Behalf_of_Click);
			// 
			// lbl_On_Behalf_of_hdr
			// 
			lbl_On_Behalf_of_hdr.AllowDrop = true;
			lbl_On_Behalf_of_hdr.AutoSize = true;
			lbl_On_Behalf_of_hdr.BackColor = System.Drawing.Color.Transparent;
			lbl_On_Behalf_of_hdr.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_On_Behalf_of_hdr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_On_Behalf_of_hdr.ForeColor = System.Drawing.Color.Maroon;
			lbl_On_Behalf_of_hdr.Location = new System.Drawing.Point(3, 2);
			lbl_On_Behalf_of_hdr.MinimumSize = new System.Drawing.Size(67, 16);
			lbl_On_Behalf_of_hdr.Name = "lbl_On_Behalf_of_hdr";
			lbl_On_Behalf_of_hdr.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_On_Behalf_of_hdr.Size = new System.Drawing.Size(67, 16);
			lbl_On_Behalf_of_hdr.TabIndex = 70;
			lbl_On_Behalf_of_hdr.Text = "Borrower:";
			// 
			// lbl_On_Behalf_of_Notes
			// 
			lbl_On_Behalf_of_Notes.AllowDrop = true;
			lbl_On_Behalf_of_Notes.AutoSize = true;
			lbl_On_Behalf_of_Notes.BackColor = System.Drawing.SystemColors.Control;
			lbl_On_Behalf_of_Notes.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_On_Behalf_of_Notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_On_Behalf_of_Notes.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_On_Behalf_of_Notes.Location = new System.Drawing.Point(300, -256);
			lbl_On_Behalf_of_Notes.MinimumSize = new System.Drawing.Size(93, 13);
			lbl_On_Behalf_of_Notes.Name = "lbl_On_Behalf_of_Notes";
			lbl_On_Behalf_of_Notes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_On_Behalf_of_Notes.Size = new System.Drawing.Size(93, 13);
			lbl_On_Behalf_of_Notes.TabIndex = 69;
			lbl_On_Behalf_of_Notes.Text = "On Behalf of Notes:";
			// 
			// Label6
			// 
			Label6.AllowDrop = true;
			Label6.AutoSize = true;
			Label6.BackColor = System.Drawing.SystemColors.Control;
			Label6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label6.ForeColor = System.Drawing.SystemColors.ControlText;
			Label6.Location = new System.Drawing.Point(339, 4);
			Label6.MinimumSize = new System.Drawing.Size(76, 13);
			Label6.Name = "Label6";
			Label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label6.Size = new System.Drawing.Size(76, 13);
			Label6.TabIndex = 68;
			Label6.Text = "Borrower Notes:";
			// 
			// pnl_In_Favor_of
			// 
			pnl_In_Favor_of.AllowDrop = true;
			pnl_In_Favor_of.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_In_Favor_of.Controls.Add(cmd_Identify_Filed_By);
			pnl_In_Favor_of.Controls.Add(lst_In_Favor_of);
			pnl_In_Favor_of.Controls.Add(txt_In_Favor_of_Notes);
			pnl_In_Favor_of.Controls.Add(cmd_Clear_Filed_By);
			pnl_In_Favor_of.Controls.Add(lbl_In_Favor_of_hdr);
			pnl_In_Favor_of.Controls.Add(lbl_In_Favor_of_Notes);
			pnl_In_Favor_of.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.21f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_In_Favor_of.Location = new System.Drawing.Point(21, 31);
			pnl_In_Favor_of.Name = "pnl_In_Favor_of";
			pnl_In_Favor_of.Size = new System.Drawing.Size(699, 86);
			pnl_In_Favor_of.TabIndex = 56;
			// 
			// cmd_Identify_Filed_By
			// 
			cmd_Identify_Filed_By.AllowDrop = true;
			cmd_Identify_Filed_By.BackColor = System.Drawing.SystemColors.Control;
			cmd_Identify_Filed_By.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Identify_Filed_By.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Identify_Filed_By.Location = new System.Drawing.Point(266, 20);
			cmd_Identify_Filed_By.Name = "cmd_Identify_Filed_By";
			cmd_Identify_Filed_By.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Identify_Filed_By.Size = new System.Drawing.Size(65, 27);
			cmd_Identify_Filed_By.TabIndex = 60;
			cmd_Identify_Filed_By.Text = "Identify";
			cmd_Identify_Filed_By.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Identify_Filed_By.UseVisualStyleBackColor = false;
			cmd_Identify_Filed_By.Click += new System.EventHandler(cmd_Identify_Filed_By_Click);
			// 
			// lst_In_Favor_of
			// 
			lst_In_Favor_of.AllowDrop = true;
			lst_In_Favor_of.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			lst_In_Favor_of.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lst_In_Favor_of.CausesValidation = true;
			lst_In_Favor_of.Enabled = false;
			lst_In_Favor_of.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lst_In_Favor_of.ForeColor = System.Drawing.SystemColors.WindowText;
			lst_In_Favor_of.IntegralHeight = true;
			lst_In_Favor_of.Location = new System.Drawing.Point(13, 22);
			lst_In_Favor_of.MultiColumn = false;
			lst_In_Favor_of.Name = "lst_In_Favor_of";
			lst_In_Favor_of.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lst_In_Favor_of.Size = new System.Drawing.Size(241, 57);
			lst_In_Favor_of.Sorted = false;
			lst_In_Favor_of.TabIndex = 59;
			lst_In_Favor_of.TabStop = true;
			lst_In_Favor_of.Visible = true;
			// 
			// txt_In_Favor_of_Notes
			// 
			txt_In_Favor_of_Notes.AcceptsReturn = true;
			txt_In_Favor_of_Notes.AllowDrop = true;
			txt_In_Favor_of_Notes.BackColor = System.Drawing.SystemColors.Window;
			txt_In_Favor_of_Notes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_In_Favor_of_Notes.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_In_Favor_of_Notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_In_Favor_of_Notes.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_In_Favor_of_Notes.Location = new System.Drawing.Point(342, 22);
			txt_In_Favor_of_Notes.MaxLength = 0;
			txt_In_Favor_of_Notes.Multiline = true;
			txt_In_Favor_of_Notes.Name = "txt_In_Favor_of_Notes";
			txt_In_Favor_of_Notes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_In_Favor_of_Notes.Size = new System.Drawing.Size(346, 54);
			txt_In_Favor_of_Notes.TabIndex = 58;
			// 
			// cmd_Clear_Filed_By
			// 
			cmd_Clear_Filed_By.AllowDrop = true;
			cmd_Clear_Filed_By.BackColor = System.Drawing.SystemColors.Control;
			cmd_Clear_Filed_By.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Clear_Filed_By.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Clear_Filed_By.Location = new System.Drawing.Point(265, 50);
			cmd_Clear_Filed_By.Name = "cmd_Clear_Filed_By";
			cmd_Clear_Filed_By.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Clear_Filed_By.Size = new System.Drawing.Size(65, 27);
			cmd_Clear_Filed_By.TabIndex = 57;
			cmd_Clear_Filed_By.Text = "Clear";
			cmd_Clear_Filed_By.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Clear_Filed_By.UseVisualStyleBackColor = false;
			cmd_Clear_Filed_By.Click += new System.EventHandler(cmd_Clear_Filed_By_Click);
			// 
			// lbl_In_Favor_of_hdr
			// 
			lbl_In_Favor_of_hdr.AllowDrop = true;
			lbl_In_Favor_of_hdr.AutoSize = true;
			lbl_In_Favor_of_hdr.BackColor = System.Drawing.Color.Transparent;
			lbl_In_Favor_of_hdr.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_In_Favor_of_hdr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_In_Favor_of_hdr.ForeColor = System.Drawing.Color.Maroon;
			lbl_In_Favor_of_hdr.Location = new System.Drawing.Point(2, 3);
			lbl_In_Favor_of_hdr.MinimumSize = new System.Drawing.Size(53, 16);
			lbl_In_Favor_of_hdr.Name = "lbl_In_Favor_of_hdr";
			lbl_In_Favor_of_hdr.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_In_Favor_of_hdr.Size = new System.Drawing.Size(53, 16);
			lbl_In_Favor_of_hdr.TabIndex = 62;
			lbl_In_Favor_of_hdr.Text = "Lender:";
			// 
			// lbl_In_Favor_of_Notes
			// 
			lbl_In_Favor_of_Notes.AllowDrop = true;
			lbl_In_Favor_of_Notes.AutoSize = true;
			lbl_In_Favor_of_Notes.BackColor = System.Drawing.SystemColors.Control;
			lbl_In_Favor_of_Notes.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_In_Favor_of_Notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_In_Favor_of_Notes.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_In_Favor_of_Notes.Location = new System.Drawing.Point(339, 6);
			lbl_In_Favor_of_Notes.MinimumSize = new System.Drawing.Size(67, 13);
			lbl_In_Favor_of_Notes.Name = "lbl_In_Favor_of_Notes";
			lbl_In_Favor_of_Notes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_In_Favor_of_Notes.Size = new System.Drawing.Size(67, 13);
			lbl_In_Favor_of_Notes.TabIndex = 61;
			lbl_In_Favor_of_Notes.Text = "Lender Notes:";
			// 
			// pnl_Values
			// 
			pnl_Values.AllowDrop = true;
			pnl_Values.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Values.Controls.Add(txt_adoc_doc_amount);
			pnl_Values.Controls.Add(txt_adoc_interest_points);
			pnl_Values.Controls.Add(txt_adoc_number_payments);
			pnl_Values.Controls.Add(txt_adoc_payment_amount);
			pnl_Values.Controls.Add(txt_adoc_last_payment_amount);
			pnl_Values.Controls.Add(txt_adoc_last_payment_date);
			pnl_Values.Controls.Add(lbl_Amount);
			pnl_Values.Controls.Add(lbl_At);
			pnl_Values.Controls.Add(lbl_Percent_Interest_with);
			pnl_Values.Controls.Add(lbl_payments_of);
			pnl_Values.Controls.Add(lbl_each);
			pnl_Values.Controls.Add(lbl_due_on);
			pnl_Values.Controls.Add(lbl_Last_payment_of);
			pnl_Values.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Values.Location = new System.Drawing.Point(21, 291);
			pnl_Values.Name = "pnl_Values";
			pnl_Values.Size = new System.Drawing.Size(699, 70);
			pnl_Values.TabIndex = 42;
			// 
			// txt_adoc_doc_amount
			// 
			txt_adoc_doc_amount.AcceptsReturn = true;
			txt_adoc_doc_amount.AllowDrop = true;
			txt_adoc_doc_amount.BackColor = System.Drawing.SystemColors.Window;
			txt_adoc_doc_amount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_adoc_doc_amount.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_adoc_doc_amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_adoc_doc_amount.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_adoc_doc_amount.Location = new System.Drawing.Point(84, 9);
			txt_adoc_doc_amount.MaxLength = 0;
			txt_adoc_doc_amount.Name = "txt_adoc_doc_amount";
			txt_adoc_doc_amount.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_adoc_doc_amount.Size = new System.Drawing.Size(65, 19);
			txt_adoc_doc_amount.TabIndex = 48;
			txt_adoc_doc_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_adoc_interest_points
			// 
			txt_adoc_interest_points.AcceptsReturn = true;
			txt_adoc_interest_points.AllowDrop = true;
			txt_adoc_interest_points.BackColor = System.Drawing.SystemColors.Window;
			txt_adoc_interest_points.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_adoc_interest_points.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_adoc_interest_points.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_adoc_interest_points.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_adoc_interest_points.Location = new System.Drawing.Point(168, 9);
			txt_adoc_interest_points.MaxLength = 0;
			txt_adoc_interest_points.Name = "txt_adoc_interest_points";
			txt_adoc_interest_points.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_adoc_interest_points.Size = new System.Drawing.Size(33, 19);
			txt_adoc_interest_points.TabIndex = 47;
			txt_adoc_interest_points.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_adoc_number_payments
			// 
			txt_adoc_number_payments.AcceptsReturn = true;
			txt_adoc_number_payments.AllowDrop = true;
			txt_adoc_number_payments.BackColor = System.Drawing.SystemColors.Window;
			txt_adoc_number_payments.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_adoc_number_payments.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_adoc_number_payments.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_adoc_number_payments.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_adoc_number_payments.Location = new System.Drawing.Point(273, 11);
			txt_adoc_number_payments.MaxLength = 0;
			txt_adoc_number_payments.Name = "txt_adoc_number_payments";
			txt_adoc_number_payments.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_adoc_number_payments.Size = new System.Drawing.Size(33, 19);
			txt_adoc_number_payments.TabIndex = 46;
			txt_adoc_number_payments.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_adoc_payment_amount
			// 
			txt_adoc_payment_amount.AcceptsReturn = true;
			txt_adoc_payment_amount.AllowDrop = true;
			txt_adoc_payment_amount.BackColor = System.Drawing.SystemColors.Window;
			txt_adoc_payment_amount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_adoc_payment_amount.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_adoc_payment_amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_adoc_payment_amount.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_adoc_payment_amount.Location = new System.Drawing.Point(384, 9);
			txt_adoc_payment_amount.MaxLength = 0;
			txt_adoc_payment_amount.Name = "txt_adoc_payment_amount";
			txt_adoc_payment_amount.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_adoc_payment_amount.Size = new System.Drawing.Size(57, 19);
			txt_adoc_payment_amount.TabIndex = 45;
			txt_adoc_payment_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_adoc_last_payment_amount
			// 
			txt_adoc_last_payment_amount.AcceptsReturn = true;
			txt_adoc_last_payment_amount.AllowDrop = true;
			txt_adoc_last_payment_amount.BackColor = System.Drawing.SystemColors.Window;
			txt_adoc_last_payment_amount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_adoc_last_payment_amount.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_adoc_last_payment_amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_adoc_last_payment_amount.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_adoc_last_payment_amount.Location = new System.Drawing.Point(84, 34);
			txt_adoc_last_payment_amount.MaxLength = 0;
			txt_adoc_last_payment_amount.Name = "txt_adoc_last_payment_amount";
			txt_adoc_last_payment_amount.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_adoc_last_payment_amount.Size = new System.Drawing.Size(57, 19);
			txt_adoc_last_payment_amount.TabIndex = 44;
			txt_adoc_last_payment_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_adoc_last_payment_date
			// 
			txt_adoc_last_payment_date.AcceptsReturn = true;
			txt_adoc_last_payment_date.AllowDrop = true;
			txt_adoc_last_payment_date.BackColor = System.Drawing.SystemColors.Window;
			txt_adoc_last_payment_date.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_adoc_last_payment_date.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_adoc_last_payment_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_adoc_last_payment_date.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_adoc_last_payment_date.Location = new System.Drawing.Point(189, 34);
			txt_adoc_last_payment_date.MaxLength = 0;
			txt_adoc_last_payment_date.Name = "txt_adoc_last_payment_date";
			txt_adoc_last_payment_date.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_adoc_last_payment_date.Size = new System.Drawing.Size(77, 19);
			txt_adoc_last_payment_date.TabIndex = 43;
			txt_adoc_last_payment_date.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lbl_Amount
			// 
			lbl_Amount.AllowDrop = true;
			lbl_Amount.AutoSize = true;
			lbl_Amount.BackColor = System.Drawing.Color.Transparent;
			lbl_Amount.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_Amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_Amount.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_Amount.Location = new System.Drawing.Point(40, 12);
			lbl_Amount.MinimumSize = new System.Drawing.Size(39, 13);
			lbl_Amount.Name = "lbl_Amount";
			lbl_Amount.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_Amount.Size = new System.Drawing.Size(39, 13);
			lbl_Amount.TabIndex = 55;
			lbl_Amount.Text = "Amount:";
			// 
			// lbl_At
			// 
			lbl_At.AllowDrop = true;
			lbl_At.AutoSize = true;
			lbl_At.BackColor = System.Drawing.Color.Transparent;
			lbl_At.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_At.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_At.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_At.Location = new System.Drawing.Point(152, 12);
			lbl_At.MinimumSize = new System.Drawing.Size(9, 13);
			lbl_At.Name = "lbl_At";
			lbl_At.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_At.Size = new System.Drawing.Size(9, 13);
			lbl_At.TabIndex = 54;
			lbl_At.Text = "at";
			// 
			// lbl_Percent_Interest_with
			// 
			lbl_Percent_Interest_with.AllowDrop = true;
			lbl_Percent_Interest_with.AutoSize = true;
			lbl_Percent_Interest_with.BackColor = System.Drawing.Color.Transparent;
			lbl_Percent_Interest_with.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_Percent_Interest_with.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_Percent_Interest_with.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_Percent_Interest_with.Location = new System.Drawing.Point(200, 12);
			lbl_Percent_Interest_with.MinimumSize = new System.Drawing.Size(68, 13);
			lbl_Percent_Interest_with.Name = "lbl_Percent_Interest_with";
			lbl_Percent_Interest_with.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_Percent_Interest_with.Size = new System.Drawing.Size(68, 13);
			lbl_Percent_Interest_with.TabIndex = 53;
			lbl_Percent_Interest_with.Text = "% Interest with";
			// 
			// lbl_payments_of
			// 
			lbl_payments_of.AllowDrop = true;
			lbl_payments_of.AutoSize = true;
			lbl_payments_of.BackColor = System.Drawing.Color.Transparent;
			lbl_payments_of.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_payments_of.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_payments_of.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_payments_of.Location = new System.Drawing.Point(312, 12);
			lbl_payments_of.MinimumSize = new System.Drawing.Size(66, 13);
			lbl_payments_of.Name = "lbl_payments_of";
			lbl_payments_of.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_payments_of.Size = new System.Drawing.Size(66, 13);
			lbl_payments_of.TabIndex = 52;
			lbl_payments_of.Text = "payments of $";
			// 
			// lbl_each
			// 
			lbl_each.AllowDrop = true;
			lbl_each.AutoSize = true;
			lbl_each.BackColor = System.Drawing.Color.Transparent;
			lbl_each.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_each.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_each.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_each.Location = new System.Drawing.Point(449, 12);
			lbl_each.MinimumSize = new System.Drawing.Size(24, 13);
			lbl_each.Name = "lbl_each";
			lbl_each.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_each.Size = new System.Drawing.Size(24, 13);
			lbl_each.TabIndex = 51;
			lbl_each.Text = "each";
			// 
			// lbl_due_on
			// 
			lbl_due_on.AllowDrop = true;
			lbl_due_on.AutoSize = true;
			lbl_due_on.BackColor = System.Drawing.Color.Transparent;
			lbl_due_on.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_due_on.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_due_on.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_due_on.Location = new System.Drawing.Point(149, 37);
			lbl_due_on.MinimumSize = new System.Drawing.Size(33, 13);
			lbl_due_on.Name = "lbl_due_on";
			lbl_due_on.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_due_on.Size = new System.Drawing.Size(33, 13);
			lbl_due_on.TabIndex = 50;
			lbl_due_on.Text = "due on";
			// 
			// lbl_Last_payment_of
			// 
			lbl_Last_payment_of.AllowDrop = true;
			lbl_Last_payment_of.AutoSize = true;
			lbl_Last_payment_of.BackColor = System.Drawing.Color.Transparent;
			lbl_Last_payment_of.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_Last_payment_of.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_Last_payment_of.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_Last_payment_of.Location = new System.Drawing.Point(5, 37);
			lbl_Last_payment_of.MinimumSize = new System.Drawing.Size(75, 13);
			lbl_Last_payment_of.Name = "lbl_Last_payment_of";
			lbl_Last_payment_of.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_Last_payment_of.Size = new System.Drawing.Size(75, 13);
			lbl_Last_payment_of.TabIndex = 49;
			lbl_Last_payment_of.Text = "Last payment of";
			// 
			// pnl_Trustee
			// 
			pnl_Trustee.AllowDrop = true;
			pnl_Trustee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Trustee.Controls.Add(cmd_Trustee);
			pnl_Trustee.Controls.Add(lst_Trustee);
			pnl_Trustee.Controls.Add(txt_adoc_trustee_note);
			pnl_Trustee.Controls.Add(cmd_Clear_Trustee);
			pnl_Trustee.Controls.Add(lbl_Trustee_hdr);
			pnl_Trustee.Controls.Add(lbl_Trustee_Financial_Notes);
			pnl_Trustee.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Trustee.Location = new System.Drawing.Point(21, 204);
			pnl_Trustee.Name = "pnl_Trustee";
			pnl_Trustee.Size = new System.Drawing.Size(699, 86);
			pnl_Trustee.TabIndex = 35;
			// 
			// cmd_Trustee
			// 
			cmd_Trustee.AllowDrop = true;
			cmd_Trustee.BackColor = System.Drawing.SystemColors.Control;
			cmd_Trustee.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Trustee.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Trustee.Location = new System.Drawing.Point(266, 21);
			cmd_Trustee.Name = "cmd_Trustee";
			cmd_Trustee.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Trustee.Size = new System.Drawing.Size(65, 27);
			cmd_Trustee.TabIndex = 39;
			cmd_Trustee.Text = "Identify";
			cmd_Trustee.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Trustee.UseVisualStyleBackColor = false;
			cmd_Trustee.Click += new System.EventHandler(cmd_Trustee_Click);
			// 
			// lst_Trustee
			// 
			lst_Trustee.AllowDrop = true;
			lst_Trustee.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			lst_Trustee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lst_Trustee.CausesValidation = true;
			lst_Trustee.Enabled = false;
			lst_Trustee.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lst_Trustee.ForeColor = System.Drawing.SystemColors.WindowText;
			lst_Trustee.IntegralHeight = true;
			lst_Trustee.Location = new System.Drawing.Point(11, 23);
			lst_Trustee.MultiColumn = false;
			lst_Trustee.Name = "lst_Trustee";
			lst_Trustee.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lst_Trustee.Size = new System.Drawing.Size(243, 57);
			lst_Trustee.Sorted = false;
			lst_Trustee.TabIndex = 38;
			lst_Trustee.TabStop = true;
			lst_Trustee.Visible = true;
			// 
			// txt_adoc_trustee_note
			// 
			txt_adoc_trustee_note.AcceptsReturn = true;
			txt_adoc_trustee_note.AllowDrop = true;
			txt_adoc_trustee_note.BackColor = System.Drawing.SystemColors.Window;
			txt_adoc_trustee_note.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_adoc_trustee_note.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_adoc_trustee_note.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_adoc_trustee_note.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_adoc_trustee_note.Location = new System.Drawing.Point(342, 23);
			txt_adoc_trustee_note.MaxLength = 0;
			txt_adoc_trustee_note.Multiline = true;
			txt_adoc_trustee_note.Name = "txt_adoc_trustee_note";
			txt_adoc_trustee_note.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_adoc_trustee_note.Size = new System.Drawing.Size(346, 54);
			txt_adoc_trustee_note.TabIndex = 37;
			// 
			// cmd_Clear_Trustee
			// 
			cmd_Clear_Trustee.AllowDrop = true;
			cmd_Clear_Trustee.BackColor = System.Drawing.SystemColors.Control;
			cmd_Clear_Trustee.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Clear_Trustee.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Clear_Trustee.Location = new System.Drawing.Point(266, 52);
			cmd_Clear_Trustee.Name = "cmd_Clear_Trustee";
			cmd_Clear_Trustee.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Clear_Trustee.Size = new System.Drawing.Size(65, 27);
			cmd_Clear_Trustee.TabIndex = 36;
			cmd_Clear_Trustee.Text = "Clear";
			cmd_Clear_Trustee.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Clear_Trustee.UseVisualStyleBackColor = false;
			cmd_Clear_Trustee.Click += new System.EventHandler(cmd_Clear_Trustee_Click);
			// 
			// lbl_Trustee_hdr
			// 
			lbl_Trustee_hdr.AllowDrop = true;
			lbl_Trustee_hdr.BackColor = System.Drawing.Color.Transparent;
			lbl_Trustee_hdr.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_Trustee_hdr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_Trustee_hdr.ForeColor = System.Drawing.Color.Maroon;
			lbl_Trustee_hdr.Location = new System.Drawing.Point(4, 4);
			lbl_Trustee_hdr.MinimumSize = new System.Drawing.Size(181, 19);
			lbl_Trustee_hdr.Name = "lbl_Trustee_hdr";
			lbl_Trustee_hdr.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_Trustee_hdr.Size = new System.Drawing.Size(181, 19);
			lbl_Trustee_hdr.TabIndex = 41;
			lbl_Trustee_hdr.Text = "Trust Agreement/Trustee:";
			// 
			// lbl_Trustee_Financial_Notes
			// 
			lbl_Trustee_Financial_Notes.AllowDrop = true;
			lbl_Trustee_Financial_Notes.BackColor = System.Drawing.SystemColors.Control;
			lbl_Trustee_Financial_Notes.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_Trustee_Financial_Notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_Trustee_Financial_Notes.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_Trustee_Financial_Notes.Location = new System.Drawing.Point(342, 6);
			lbl_Trustee_Financial_Notes.MinimumSize = new System.Drawing.Size(81, 17);
			lbl_Trustee_Financial_Notes.Name = "lbl_Trustee_Financial_Notes";
			lbl_Trustee_Financial_Notes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_Trustee_Financial_Notes.Size = new System.Drawing.Size(81, 17);
			lbl_Trustee_Financial_Notes.TabIndex = 40;
			lbl_Trustee_Financial_Notes.Text = "Trustee Notes:";
			// 
			// _tab_Document_TabPage1
			// 
			_tab_Document_TabPage1.Controls.Add(WebBrowser1);
			_tab_Document_TabPage1.Controls.Add(pnl_faa_log);
			_tab_Document_TabPage1.Controls.Add(cmdTransOpenDocument);
			_tab_Document_TabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_tab_Document_TabPage1.Text = "View Document";
			// 
			// WebBrowser1
			// 
			WebBrowser1.AllowWebBrowserDrop = true;
			WebBrowser1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			WebBrowser1.Location = new System.Drawing.Point(12, 15);
			WebBrowser1.Name = "WebBrowser1";
			WebBrowser1.Size = new System.Drawing.Size(950, 401);
			WebBrowser1.TabIndex = 78;
			// 
			// pnl_faa_log
			// 
			pnl_faa_log.AllowDrop = true;
			pnl_faa_log.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_faa_log.Controls.Add(txt_faalog_tape_no);
			pnl_faa_log.Controls.Add(txt_faalog_starting_frame_no);
			pnl_faa_log.Controls.Add(txt_faalog_tape_date);
			pnl_faa_log.Controls.Add(txt_faalog_tape_of);
			pnl_faa_log.Controls.Add(txt_faalog_tape_to);
			pnl_faa_log.Controls.Add(txt_faalog_ending_frame_no);
			pnl_faa_log.Controls.Add(Label3);
			pnl_faa_log.Controls.Add(Label4);
			pnl_faa_log.Controls.Add(Label5);
			pnl_faa_log.Controls.Add(Label7);
			pnl_faa_log.Controls.Add(Label8);
			pnl_faa_log.Controls.Add(Label9);
			pnl_faa_log.Controls.Add(Label10);
			pnl_faa_log.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_faa_log.Location = new System.Drawing.Point(85, 423);
			pnl_faa_log.Name = "pnl_faa_log";
			pnl_faa_log.Size = new System.Drawing.Size(700, 45);
			pnl_faa_log.TabIndex = 21;
			// 
			// txt_faalog_tape_no
			// 
			txt_faalog_tape_no.AcceptsReturn = true;
			txt_faalog_tape_no.AllowDrop = true;
			txt_faalog_tape_no.BackColor = System.Drawing.SystemColors.Window;
			txt_faalog_tape_no.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_faalog_tape_no.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_faalog_tape_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_faalog_tape_no.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_faalog_tape_no.Location = new System.Drawing.Point(101, 19);
			txt_faalog_tape_no.MaxLength = 0;
			txt_faalog_tape_no.Name = "txt_faalog_tape_no";
			txt_faalog_tape_no.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_faalog_tape_no.Size = new System.Drawing.Size(80, 19);
			txt_faalog_tape_no.TabIndex = 22;
			txt_faalog_tape_no.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_faalog_starting_frame_no
			// 
			txt_faalog_starting_frame_no.AcceptsReturn = true;
			txt_faalog_starting_frame_no.AllowDrop = true;
			txt_faalog_starting_frame_no.BackColor = System.Drawing.SystemColors.Window;
			txt_faalog_starting_frame_no.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_faalog_starting_frame_no.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_faalog_starting_frame_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_faalog_starting_frame_no.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_faalog_starting_frame_no.Location = new System.Drawing.Point(489, 19);
			txt_faalog_starting_frame_no.MaxLength = 0;
			txt_faalog_starting_frame_no.Name = "txt_faalog_starting_frame_no";
			txt_faalog_starting_frame_no.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_faalog_starting_frame_no.Size = new System.Drawing.Size(64, 19);
			txt_faalog_starting_frame_no.TabIndex = 30;
			txt_faalog_starting_frame_no.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_faalog_tape_date
			// 
			txt_faalog_tape_date.AcceptsReturn = true;
			txt_faalog_tape_date.AllowDrop = true;
			txt_faalog_tape_date.BackColor = System.Drawing.SystemColors.Window;
			txt_faalog_tape_date.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_faalog_tape_date.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_faalog_tape_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_faalog_tape_date.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_faalog_tape_date.Location = new System.Drawing.Point(244, 19);
			txt_faalog_tape_date.MaxLength = 0;
			txt_faalog_tape_date.Name = "txt_faalog_tape_date";
			txt_faalog_tape_date.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_faalog_tape_date.Size = new System.Drawing.Size(70, 19);
			txt_faalog_tape_date.TabIndex = 24;
			txt_faalog_tape_date.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_faalog_tape_of
			// 
			txt_faalog_tape_of.AcceptsReturn = true;
			txt_faalog_tape_of.AllowDrop = true;
			txt_faalog_tape_of.BackColor = System.Drawing.SystemColors.Window;
			txt_faalog_tape_of.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_faalog_tape_of.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_faalog_tape_of.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_faalog_tape_of.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_faalog_tape_of.Location = new System.Drawing.Point(348, 19);
			txt_faalog_tape_of.MaxLength = 0;
			txt_faalog_tape_of.Name = "txt_faalog_tape_of";
			txt_faalog_tape_of.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_faalog_tape_of.Size = new System.Drawing.Size(21, 19);
			txt_faalog_tape_of.TabIndex = 26;
			txt_faalog_tape_of.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_faalog_tape_to
			// 
			txt_faalog_tape_to.AcceptsReturn = true;
			txt_faalog_tape_to.AllowDrop = true;
			txt_faalog_tape_to.BackColor = System.Drawing.SystemColors.Window;
			txt_faalog_tape_to.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_faalog_tape_to.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_faalog_tape_to.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_faalog_tape_to.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_faalog_tape_to.Location = new System.Drawing.Point(384, 19);
			txt_faalog_tape_to.MaxLength = 0;
			txt_faalog_tape_to.Name = "txt_faalog_tape_to";
			txt_faalog_tape_to.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_faalog_tape_to.Size = new System.Drawing.Size(21, 19);
			txt_faalog_tape_to.TabIndex = 28;
			txt_faalog_tape_to.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_faalog_ending_frame_no
			// 
			txt_faalog_ending_frame_no.AcceptsReturn = true;
			txt_faalog_ending_frame_no.AllowDrop = true;
			txt_faalog_ending_frame_no.BackColor = System.Drawing.SystemColors.Window;
			txt_faalog_ending_frame_no.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_faalog_ending_frame_no.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_faalog_ending_frame_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_faalog_ending_frame_no.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_faalog_ending_frame_no.Location = new System.Drawing.Point(628, 19);
			txt_faalog_ending_frame_no.MaxLength = 0;
			txt_faalog_ending_frame_no.Name = "txt_faalog_ending_frame_no";
			txt_faalog_ending_frame_no.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_faalog_ending_frame_no.Size = new System.Drawing.Size(64, 19);
			txt_faalog_ending_frame_no.TabIndex = 32;
			txt_faalog_ending_frame_no.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// Label3
			// 
			Label3.AllowDrop = true;
			Label3.BackColor = System.Drawing.Color.Transparent;
			Label3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label3.ForeColor = System.Drawing.SystemColors.ControlText;
			Label3.Location = new System.Drawing.Point(25, 20);
			Label3.MinimumSize = new System.Drawing.Size(80, 17);
			Label3.Name = "Label3";
			Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label3.Size = new System.Drawing.Size(80, 17);
			Label3.TabIndex = 34;
			Label3.Text = "Tape Number:";
			// 
			// Label4
			// 
			Label4.AllowDrop = true;
			Label4.BackColor = System.Drawing.Color.Transparent;
			Label4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label4.ForeColor = System.Drawing.SystemColors.ControlText;
			Label4.Location = new System.Drawing.Point(413, 20);
			Label4.MinimumSize = new System.Drawing.Size(80, 17);
			Label4.Name = "Label4";
			Label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label4.Size = new System.Drawing.Size(80, 17);
			Label4.TabIndex = 33;
			Label4.Text = "Frame # Start:";
			// 
			// Label5
			// 
			Label5.AllowDrop = true;
			Label5.AutoSize = true;
			Label5.BackColor = System.Drawing.Color.Transparent;
			Label5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label5.ForeColor = System.Drawing.Color.Maroon;
			Label5.Location = new System.Drawing.Point(4, 0);
			Label5.MinimumSize = new System.Drawing.Size(151, 16);
			Label5.Name = "Label5";
			Label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label5.Size = new System.Drawing.Size(151, 16);
			Label5.TabIndex = 31;
			Label5.Text = "FAA Tape Information";
			// 
			// Label7
			// 
			Label7.AllowDrop = true;
			Label7.BackColor = System.Drawing.Color.Transparent;
			Label7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label7.ForeColor = System.Drawing.SystemColors.ControlText;
			Label7.Location = new System.Drawing.Point(187, 20);
			Label7.MinimumSize = new System.Drawing.Size(80, 17);
			Label7.Name = "Label7";
			Label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label7.Size = new System.Drawing.Size(80, 17);
			Label7.TabIndex = 29;
			Label7.Text = "Tape Date:";
			// 
			// Label8
			// 
			Label8.AllowDrop = true;
			Label8.BackColor = System.Drawing.Color.Transparent;
			Label8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label8.ForeColor = System.Drawing.SystemColors.ControlText;
			Label8.Location = new System.Drawing.Point(318, 20);
			Label8.MinimumSize = new System.Drawing.Size(80, 17);
			Label8.Name = "Label8";
			Label8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label8.Size = new System.Drawing.Size(80, 17);
			Label8.TabIndex = 27;
			Label8.Text = "Tape ";
			// 
			// Label9
			// 
			Label9.AllowDrop = true;
			Label9.BackColor = System.Drawing.Color.Transparent;
			Label9.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label9.ForeColor = System.Drawing.SystemColors.ControlText;
			Label9.Location = new System.Drawing.Point(554, 20);
			Label9.MinimumSize = new System.Drawing.Size(80, 17);
			Label9.Name = "Label9";
			Label9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label9.Size = new System.Drawing.Size(80, 17);
			Label9.TabIndex = 25;
			Label9.Text = "Frame # End:";
			// 
			// Label10
			// 
			Label10.AllowDrop = true;
			Label10.BackColor = System.Drawing.Color.Transparent;
			Label10.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label10.ForeColor = System.Drawing.SystemColors.ControlText;
			Label10.Location = new System.Drawing.Point(370, 19);
			Label10.MinimumSize = new System.Drawing.Size(52, 17);
			Label10.Name = "Label10";
			Label10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label10.Size = new System.Drawing.Size(52, 17);
			Label10.TabIndex = 23;
			Label10.Text = "of";
			// 
			// cmdTransOpenDocument
			// 
			cmdTransOpenDocument.AllowDrop = true;
			cmdTransOpenDocument.BackColor = System.Drawing.SystemColors.Control;
			cmdTransOpenDocument.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdTransOpenDocument.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdTransOpenDocument.Location = new System.Drawing.Point(822, 434);
			cmdTransOpenDocument.Name = "cmdTransOpenDocument";
			cmdTransOpenDocument.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdTransOpenDocument.Size = new System.Drawing.Size(103, 28);
			cmdTransOpenDocument.TabIndex = 81;
			cmdTransOpenDocument.Text = "Open &Document";
			cmdTransOpenDocument.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdTransOpenDocument.UseVisualStyleBackColor = false;
			cmdTransOpenDocument.Click += new System.EventHandler(cmdTransOpenDocument_Click);
			// 
			// pnl_Document_Log
			// 
			pnl_Document_Log.AllowDrop = true;
			pnl_Document_Log.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Document_Log.Controls.Add(chkLeaveInProcessing);
			pnl_Document_Log.Controls.Add(cmd_Attach);
			pnl_Document_Log.Controls.Add(cmd_Close_Document_Log);
			pnl_Document_Log.Controls.Add(grd_DocumentLog);
			pnl_Document_Log.Controls.Add(lbl_Status);
			pnl_Document_Log.Controls.Add(Label11);
			pnl_Document_Log.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Document_Log.Location = new System.Drawing.Point(301, 228);
			pnl_Document_Log.Name = "pnl_Document_Log";
			pnl_Document_Log.Size = new System.Drawing.Size(377, 269);
			pnl_Document_Log.TabIndex = 15;
			// 
			// chkLeaveInProcessing
			// 
			chkLeaveInProcessing.AllowDrop = true;
			chkLeaveInProcessing.Appearance = System.Windows.Forms.Appearance.Normal;
			chkLeaveInProcessing.BackColor = System.Drawing.SystemColors.Control;
			chkLeaveInProcessing.CausesValidation = true;
			chkLeaveInProcessing.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkLeaveInProcessing.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkLeaveInProcessing.Enabled = true;
			chkLeaveInProcessing.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkLeaveInProcessing.ForeColor = System.Drawing.SystemColors.ControlText;
			chkLeaveInProcessing.Location = new System.Drawing.Point(216, 251);
			chkLeaveInProcessing.Name = "chkLeaveInProcessing";
			chkLeaveInProcessing.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkLeaveInProcessing.Size = new System.Drawing.Size(159, 13);
			chkLeaveInProcessing.TabIndex = 77;
			chkLeaveInProcessing.TabStop = true;
			chkLeaveInProcessing.Text = "Leave a copy in Processing";
			chkLeaveInProcessing.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkLeaveInProcessing.Visible = true;
			// 
			// cmd_Attach
			// 
			cmd_Attach.AllowDrop = true;
			cmd_Attach.BackColor = System.Drawing.SystemColors.Control;
			cmd_Attach.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Attach.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Attach.Location = new System.Drawing.Point(233, 219);
			cmd_Attach.Name = "cmd_Attach";
			cmd_Attach.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Attach.Size = new System.Drawing.Size(65, 27);
			cmd_Attach.TabIndex = 18;
			cmd_Attach.Text = "Attach File";
			cmd_Attach.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Attach.UseVisualStyleBackColor = false;
			cmd_Attach.Click += new System.EventHandler(cmd_Attach_Click);
			// 
			// cmd_Close_Document_Log
			// 
			cmd_Close_Document_Log.AllowDrop = true;
			cmd_Close_Document_Log.BackColor = System.Drawing.SystemColors.Control;
			cmd_Close_Document_Log.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Close_Document_Log.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Close_Document_Log.Location = new System.Drawing.Point(305, 218);
			cmd_Close_Document_Log.Name = "cmd_Close_Document_Log";
			cmd_Close_Document_Log.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Close_Document_Log.Size = new System.Drawing.Size(65, 27);
			cmd_Close_Document_Log.TabIndex = 16;
			cmd_Close_Document_Log.Text = "Close";
			cmd_Close_Document_Log.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Close_Document_Log.UseVisualStyleBackColor = false;
			cmd_Close_Document_Log.Click += new System.EventHandler(cmd_Close_Document_Log_Click);
			// 
			// grd_DocumentLog
			// 
			grd_DocumentLog.AllowDrop = true;
			grd_DocumentLog.AllowUserToAddRows = false;
			grd_DocumentLog.AllowUserToDeleteRows = false;
			grd_DocumentLog.AllowUserToResizeColumns = false;
			grd_DocumentLog.AllowUserToResizeRows = false;
			grd_DocumentLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grd_DocumentLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_DocumentLog.ColumnsCount = 2;
			grd_DocumentLog.FixedColumns = 1;
			grd_DocumentLog.FixedRows = 1;
			grd_DocumentLog.Location = new System.Drawing.Point(10, 102);
			grd_DocumentLog.Name = "grd_DocumentLog";
			grd_DocumentLog.ReadOnly = true;
			grd_DocumentLog.RowsCount = 2;
			grd_DocumentLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			grd_DocumentLog.ShowCellToolTips = false;
			grd_DocumentLog.Size = new System.Drawing.Size(358, 110);
			grd_DocumentLog.StandardTab = true;
			grd_DocumentLog.TabIndex = 17;
			grd_DocumentLog.Click += new System.EventHandler(grd_DocumentLog_Click);
			// 
			// lbl_Status
			// 
			lbl_Status.AllowDrop = true;
			lbl_Status.BackColor = System.Drawing.SystemColors.Control;
			lbl_Status.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_Status.ForeColor = System.Drawing.Color.Red;
			lbl_Status.Location = new System.Drawing.Point(6, 214);
			lbl_Status.MinimumSize = new System.Drawing.Size(223, 49);
			lbl_Status.Name = "lbl_Status";
			lbl_Status.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_Status.Size = new System.Drawing.Size(223, 49);
			lbl_Status.TabIndex = 76;
			// 
			// Label11
			// 
			Label11.AllowDrop = true;
			Label11.BackColor = System.Drawing.SystemColors.Control;
			Label11.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label11.ForeColor = System.Drawing.Color.Red;
			Label11.Location = new System.Drawing.Point(19, 26);
			Label11.MinimumSize = new System.Drawing.Size(348, 61);
			Label11.Name = "Label11";
			Label11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label11.Size = new System.Drawing.Size(348, 61);
			Label11.TabIndex = 19;
			Label11.Text = "The following documents have been found that have been scanned but not yet processed into Homebase.  To process a document, click on the document and then click on the <Attach File> button.";
			// 
			// lbl_Aircraft_Documents_hdr
			// 
			lbl_Aircraft_Documents_hdr.AllowDrop = true;
			lbl_Aircraft_Documents_hdr.AutoSize = true;
			lbl_Aircraft_Documents_hdr.BackColor = System.Drawing.Color.Transparent;
			lbl_Aircraft_Documents_hdr.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_Aircraft_Documents_hdr.Font = new System.Drawing.Font("Arial", 10.5f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_Aircraft_Documents_hdr.ForeColor = System.Drawing.Color.Maroon;
			lbl_Aircraft_Documents_hdr.Location = new System.Drawing.Point(436, 53);
			lbl_Aircraft_Documents_hdr.MinimumSize = new System.Drawing.Size(107, 16);
			lbl_Aircraft_Documents_hdr.Name = "lbl_Aircraft_Documents_hdr";
			lbl_Aircraft_Documents_hdr.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_Aircraft_Documents_hdr.Size = new System.Drawing.Size(107, 16);
			lbl_Aircraft_Documents_hdr.TabIndex = 80;
			lbl_Aircraft_Documents_hdr.Text = "Sold Financials";
			lbl_Aircraft_Documents_hdr.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// frm_Transaction_Documents
			// 
			AcceptButton = cmd_OK;
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			BackColor = System.Drawing.SystemColors.Control;
			CancelButton = cmd_Cancel;
			ClientSize = new System.Drawing.Size(979, 702);
			ControlBox = false;
			Controls.Add(pnl_FinancialDocList);
			Controls.Add(pnl_Doc_Info);
			Controls.Add(tbr_ToolBar);
			Controls.Add(tab_Document);
			Controls.Add(pnl_Document_Log);
			Controls.Add(lbl_Aircraft_Documents_hdr);
			Controls.Add(MainMenu1);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Location = new System.Drawing.Point(294, 233);
			MaximizeBox = true;
			MinimizeBox = false;
			Name = "frm_Transaction_Documents";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			Text = "Aircraft Documents";
			WindowState = System.Windows.Forms.FormWindowState.Maximized;
			commandButtonHelper1.SetStyle(cmd_OK, 0);
			commandButtonHelper1.SetStyle(cmd_Cancel, 0);
			commandButtonHelper1.SetStyle(cmd_Identify_On_Behalf_of, 0);
			commandButtonHelper1.SetStyle(cmd_Clear_On_Behalf_of, 0);
			commandButtonHelper1.SetStyle(cmd_Identify_Filed_By, 0);
			commandButtonHelper1.SetStyle(cmd_Clear_Filed_By, 0);
			commandButtonHelper1.SetStyle(cmd_Trustee, 0);
			commandButtonHelper1.SetStyle(cmd_Clear_Trustee, 0);
			commandButtonHelper1.SetStyle(cmdTransOpenDocument, 0);
			commandButtonHelper1.SetStyle(cmd_Attach, 0);
			commandButtonHelper1.SetStyle(cmd_Close_Document_Log, 0);
			listBoxHelper1.SetSelectionMode(lst_FinancialDoc, System.Windows.Forms.SelectionMode.One);
			listBoxHelper1.SetSelectionMode(lst_Aircraft_Info, System.Windows.Forms.SelectionMode.One);
			listBoxHelper1.SetSelectionMode(lst_SubLeased_to, System.Windows.Forms.SelectionMode.One);
			listBoxHelper1.SetSelectionMode(lst_On_Behalf_of, System.Windows.Forms.SelectionMode.One);
			listBoxHelper1.SetSelectionMode(lst_In_Favor_of, System.Windows.Forms.SelectionMode.One);
			listBoxHelper1.SetSelectionMode(lst_Trustee, System.Windows.Forms.SelectionMode.One);
			Activated += new System.EventHandler(Form_Activated);
			Closed += new System.EventHandler(Form_Closed);
			((System.ComponentModel.ISupportInitialize) grd_DocumentLog).EndInit();
			pnl_FinancialDocList.ResumeLayout(false);
			pnl_FinancialDocList.PerformLayout();
			pnl_Doc_Info.ResumeLayout(false);
			pnl_Doc_Info.PerformLayout();
			tbr_ToolBar.ResumeLayout(false);
			tbr_ToolBar.PerformLayout();
			tab_Document.ResumeLayout(false);
			tab_Document.PerformLayout();
			_tab_Document_TabPage0.ResumeLayout(false);
			_tab_Document_TabPage0.PerformLayout();
			pnl_SubLeased_to.ResumeLayout(false);
			pnl_SubLeased_to.PerformLayout();
			pnl_On_Behalf_of.ResumeLayout(false);
			pnl_On_Behalf_of.PerformLayout();
			pnl_In_Favor_of.ResumeLayout(false);
			pnl_In_Favor_of.PerformLayout();
			pnl_Values.ResumeLayout(false);
			pnl_Values.PerformLayout();
			pnl_Trustee.ResumeLayout(false);
			pnl_Trustee.PerformLayout();
			_tab_Document_TabPage1.ResumeLayout(false);
			_tab_Document_TabPage1.PerformLayout();
			pnl_faa_log.ResumeLayout(false);
			pnl_faa_log.PerformLayout();
			pnl_Document_Log.ResumeLayout(false);
			pnl_Document_Log.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
		void ReLoadForm(bool addEvents)
		{
			tab_DocumentPreviousTab = tab_Document.SelectedIndex;
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			MdiParent = JETNET_Homebase.mdi_ResearchAssistant.DefInstance;
			JETNET_Homebase.mdi_ResearchAssistant.DefInstance.Show();
		}
		#endregion
	}
}