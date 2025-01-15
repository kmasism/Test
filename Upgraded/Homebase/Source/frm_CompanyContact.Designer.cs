
namespace JETNET_Homebase
{
	partial class frm_CompanyContact
	{

		#region "Upgrade Support "
		private static frm_CompanyContact m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_CompanyContact DefInstance
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
		public static frm_CompanyContact CreateInstance()
		{
			frm_CompanyContact theInstance = new frm_CompanyContact();
			theInstance.Form_Load();
			return theInstance;
		}
		private void Ctx_mnuRightClickPhoneNumbers_Opening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			System.Collections.Generic.List<System.Windows.Forms.ToolStripItem> list = new System.Collections.Generic.List<System.Windows.Forms.ToolStripItem>();
			Ctx_mnuRightClickPhoneNumbers.Items.Clear();
			//We are moving the submenus from original menu to the context menu before displaying it
			foreach (System.Windows.Forms.ToolStripItem item in ((System.Windows.Forms.ToolStripMenuItem) mnuRightClickPhoneNumbers).DropDownItems)
			{
				list.Add(item);
			}
			foreach (System.Windows.Forms.ToolStripItem item in list)
			{
				Ctx_mnuRightClickPhoneNumbers.Items.Add(item);
			}
			e.Cancel = false;
		}
		private void Ctx_mnuRightClickPhoneNumbers_Closed(object sender, System.Windows.Forms.ToolStripDropDownClosedEventArgs e)
		{
			System.Collections.Generic.List<System.Windows.Forms.ToolStripItem> list = new System.Collections.Generic.List<System.Windows.Forms.ToolStripItem>();
			//We are moving the submenus the context menu back to the original menu after displaying
			foreach (System.Windows.Forms.ToolStripItem item in Ctx_mnuRightClickPhoneNumbers.Items)
			{
				list.Add(item);
			}
			foreach (System.Windows.Forms.ToolStripItem item in list)
			{
				((System.Windows.Forms.ToolStripMenuItem) mnuRightClickPhoneNumbers).DropDownItems.Add(item);
			}
		}
		private string[] visualControls = new string[]{"components", "ToolTipMain", "mnuContactDialPhoneNumber", "mnuRightClickPhoneNumbers", "MainMenu1", "chk_hidden_comp", "chk_contact_do_not_solicit", "chk_iq_auto", "txt_iq_email", "cmd_add_new_contact", "txt_contact_email_address", "cbo_replacement_contact", "txt_contact_research_email_address", "chkContactDoNotSendJNiQSurvey", "chkContactDoNotSendEMail", "cmdFindContactMatch", "cmd_add_contact_phone", "txt_ext", "chk_pnum_hide_customer", "cbo_pnum_type", "cmd_save_contact_phone", "txt_pnum_area_code", "txt_pnum_number", "txt_pnum_cntry_code", "cmd_cancel_contact_phone", "txt_pnum_prefix", "_lbl_comp_0", "_lbl_comp_53", "_lbl_comp_25", "_lbl_comp_52", "_lbl_comp_24", "_lbl_comp_45", "pnl_Contact_Phone", "_lbl_comp_40", "pnl_update_Message", "pgTimer1", "cmdDelete", "lstTitleGroup", "cmdViewBadContactEmails", "txt_contact_acpros_seq_no", "chk_HideFromCustomer", "cmd_delete_contact_Phone", "cmd_confirm_contact_Phone", "cmd_Save_Contact", "txt_contact_description", "cmd_Confirm_Contact", "cmd_Subscription", "cmd_Close", "cbo_contact_suffix", "txt_contact_last_name", "txt_contact_middle_initial", "txt_contact_first_name", "cbo_contact_sirname", "chk_contact_research_flag", "chk_contact_active_flag", "cbo_contact_title", "txt_contact_id", "grd_Contact_Phone_Numbers", "_lblCompanyContact_14", "_lblCompanyContact_13", "_lblCompanyContact_12", "lblTransmitContactRecord", "lblContactRelationships", "lblChanges", "_lblTitleGroup_12", "_lblCompanyContact_11", "_lblCompanyContact_10", "_lblCompanyContact_9", "lbl_contact_entry_date", "lbl_contact_update_date", "lblLockedBy", "_lblCompanyContact_7", "_lblCompanyContact_6", "_lblCompanyContact_5", "_lblCompanyContact_4", "_lblCompanyContact_3", "_lblCompanyContact_8", "_lblCompanyContact_2", "_lblCompanyContact_1", "_lblCompanyContact_0", "lblCompanyContact", "lblTitleGroup", "lbl_comp", "Ctx_mnuRightClickPhoneNumbers", "listBoxHelper1", "commandButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.ToolStripMenuItem mnuContactDialPhoneNumber;
		public System.Windows.Forms.ToolStripMenuItem mnuRightClickPhoneNumbers;
		public System.Windows.Forms.MenuStrip MainMenu1;
		public System.Windows.Forms.CheckBox chk_hidden_comp;
		public System.Windows.Forms.CheckBox chk_contact_do_not_solicit;
		public System.Windows.Forms.CheckBox chk_iq_auto;
		public System.Windows.Forms.TextBox txt_iq_email;
		public System.Windows.Forms.Button cmd_add_new_contact;
		public System.Windows.Forms.TextBox txt_contact_email_address;
		public System.Windows.Forms.ComboBox cbo_replacement_contact;
		public System.Windows.Forms.TextBox txt_contact_research_email_address;
		public System.Windows.Forms.CheckBox chkContactDoNotSendJNiQSurvey;
		public System.Windows.Forms.CheckBox chkContactDoNotSendEMail;
		public System.Windows.Forms.Button cmdFindContactMatch;
		public System.Windows.Forms.Button cmd_add_contact_phone;
		public System.Windows.Forms.TextBox txt_ext;
		public System.Windows.Forms.CheckBox chk_pnum_hide_customer;
		public System.Windows.Forms.ComboBox cbo_pnum_type;
		public System.Windows.Forms.Button cmd_save_contact_phone;
		public System.Windows.Forms.TextBox txt_pnum_area_code;
		public System.Windows.Forms.TextBox txt_pnum_number;
		public System.Windows.Forms.TextBox txt_pnum_cntry_code;
		public System.Windows.Forms.Button cmd_cancel_contact_phone;
		public System.Windows.Forms.TextBox txt_pnum_prefix;
		private System.Windows.Forms.Label _lbl_comp_0;
		private System.Windows.Forms.Label _lbl_comp_53;
		private System.Windows.Forms.Label _lbl_comp_25;
		private System.Windows.Forms.Label _lbl_comp_52;
		private System.Windows.Forms.Label _lbl_comp_24;
		private System.Windows.Forms.Label _lbl_comp_45;
		public System.Windows.Forms.GroupBox pnl_Contact_Phone;
		private System.Windows.Forms.Label _lbl_comp_40;
		public System.Windows.Forms.Panel pnl_update_Message;
		public System.Windows.Forms.Timer pgTimer1;
		public System.Windows.Forms.Button cmdDelete;
		public System.Windows.Forms.ListBox lstTitleGroup;
		public System.Windows.Forms.Button cmdViewBadContactEmails;
		public System.Windows.Forms.TextBox txt_contact_acpros_seq_no;
		public System.Windows.Forms.CheckBox chk_HideFromCustomer;
		public System.Windows.Forms.Button cmd_delete_contact_Phone;
		public System.Windows.Forms.Button cmd_confirm_contact_Phone;
		public System.Windows.Forms.Button cmd_Save_Contact;
		public System.Windows.Forms.TextBox txt_contact_description;
		public System.Windows.Forms.Button cmd_Confirm_Contact;
		public System.Windows.Forms.Button cmd_Subscription;
		public System.Windows.Forms.Button cmd_Close;
		public System.Windows.Forms.ComboBox cbo_contact_suffix;
		public System.Windows.Forms.TextBox txt_contact_last_name;
		public System.Windows.Forms.TextBox txt_contact_middle_initial;
		public System.Windows.Forms.TextBox txt_contact_first_name;
		public System.Windows.Forms.ComboBox cbo_contact_sirname;
		public System.Windows.Forms.CheckBox chk_contact_research_flag;
		public System.Windows.Forms.CheckBox chk_contact_active_flag;
		public System.Windows.Forms.ComboBox cbo_contact_title;
		public System.Windows.Forms.TextBox txt_contact_id;
		public UpgradeHelpers.DataGridViewFlex grd_Contact_Phone_Numbers;
		private System.Windows.Forms.Label _lblCompanyContact_14;
		private System.Windows.Forms.Label _lblCompanyContact_13;
		private System.Windows.Forms.Label _lblCompanyContact_12;
		public System.Windows.Forms.Label lblTransmitContactRecord;
		public System.Windows.Forms.Label lblContactRelationships;
		public System.Windows.Forms.Label lblChanges;
		private System.Windows.Forms.Label _lblTitleGroup_12;
		private System.Windows.Forms.Label _lblCompanyContact_11;
		private System.Windows.Forms.Label _lblCompanyContact_10;
		private System.Windows.Forms.Label _lblCompanyContact_9;
		public System.Windows.Forms.Label lbl_contact_entry_date;
		public System.Windows.Forms.Label lbl_contact_update_date;
		public System.Windows.Forms.Label lblLockedBy;
		private System.Windows.Forms.Label _lblCompanyContact_7;
		private System.Windows.Forms.Label _lblCompanyContact_6;
		private System.Windows.Forms.Label _lblCompanyContact_5;
		private System.Windows.Forms.Label _lblCompanyContact_4;
		private System.Windows.Forms.Label _lblCompanyContact_3;
		private System.Windows.Forms.Label _lblCompanyContact_8;
		private System.Windows.Forms.Label _lblCompanyContact_2;
		private System.Windows.Forms.Label _lblCompanyContact_1;
		private System.Windows.Forms.Label _lblCompanyContact_0;
		public System.Windows.Forms.Label[] lblCompanyContact = new System.Windows.Forms.Label[15];
		public System.Windows.Forms.Label[] lblTitleGroup = new System.Windows.Forms.Label[13];
		public System.Windows.Forms.Label[] lbl_comp = new System.Windows.Forms.Label[54];
		public System.Windows.Forms.ContextMenuStrip Ctx_mnuRightClickPhoneNumbers;
		public UpgradeHelpers.Gui.Controls.ListBoxHelper listBoxHelper1;
		public UpgradeHelpers.Gui.Controls.CommandButtonHelper commandButtonHelper1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_CompanyContact));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			MainMenu1 = new System.Windows.Forms.MenuStrip();
			mnuRightClickPhoneNumbers = new System.Windows.Forms.ToolStripMenuItem();
			mnuContactDialPhoneNumber = new System.Windows.Forms.ToolStripMenuItem();
			chk_hidden_comp = new System.Windows.Forms.CheckBox();
			chk_contact_do_not_solicit = new System.Windows.Forms.CheckBox();
			chk_iq_auto = new System.Windows.Forms.CheckBox();
			txt_iq_email = new System.Windows.Forms.TextBox();
			cmd_add_new_contact = new System.Windows.Forms.Button();
			txt_contact_email_address = new System.Windows.Forms.TextBox();
			cbo_replacement_contact = new System.Windows.Forms.ComboBox();
			txt_contact_research_email_address = new System.Windows.Forms.TextBox();
			chkContactDoNotSendJNiQSurvey = new System.Windows.Forms.CheckBox();
			chkContactDoNotSendEMail = new System.Windows.Forms.CheckBox();
			cmdFindContactMatch = new System.Windows.Forms.Button();
			cmd_add_contact_phone = new System.Windows.Forms.Button();
			pnl_Contact_Phone = new System.Windows.Forms.GroupBox();
			txt_ext = new System.Windows.Forms.TextBox();
			chk_pnum_hide_customer = new System.Windows.Forms.CheckBox();
			cbo_pnum_type = new System.Windows.Forms.ComboBox();
			cmd_save_contact_phone = new System.Windows.Forms.Button();
			txt_pnum_area_code = new System.Windows.Forms.TextBox();
			txt_pnum_number = new System.Windows.Forms.TextBox();
			txt_pnum_cntry_code = new System.Windows.Forms.TextBox();
			cmd_cancel_contact_phone = new System.Windows.Forms.Button();
			txt_pnum_prefix = new System.Windows.Forms.TextBox();
			_lbl_comp_0 = new System.Windows.Forms.Label();
			_lbl_comp_53 = new System.Windows.Forms.Label();
			_lbl_comp_25 = new System.Windows.Forms.Label();
			_lbl_comp_52 = new System.Windows.Forms.Label();
			_lbl_comp_24 = new System.Windows.Forms.Label();
			_lbl_comp_45 = new System.Windows.Forms.Label();
			pnl_update_Message = new System.Windows.Forms.Panel();
			_lbl_comp_40 = new System.Windows.Forms.Label();
			pgTimer1 = new System.Windows.Forms.Timer(components);
			cmdDelete = new System.Windows.Forms.Button();
			lstTitleGroup = new System.Windows.Forms.ListBox();
			cmdViewBadContactEmails = new System.Windows.Forms.Button();
			txt_contact_acpros_seq_no = new System.Windows.Forms.TextBox();
			chk_HideFromCustomer = new System.Windows.Forms.CheckBox();
			cmd_delete_contact_Phone = new System.Windows.Forms.Button();
			cmd_confirm_contact_Phone = new System.Windows.Forms.Button();
			cmd_Save_Contact = new System.Windows.Forms.Button();
			txt_contact_description = new System.Windows.Forms.TextBox();
			cmd_Confirm_Contact = new System.Windows.Forms.Button();
			cmd_Subscription = new System.Windows.Forms.Button();
			cmd_Close = new System.Windows.Forms.Button();
			cbo_contact_suffix = new System.Windows.Forms.ComboBox();
			txt_contact_last_name = new System.Windows.Forms.TextBox();
			txt_contact_middle_initial = new System.Windows.Forms.TextBox();
			txt_contact_first_name = new System.Windows.Forms.TextBox();
			cbo_contact_sirname = new System.Windows.Forms.ComboBox();
			chk_contact_research_flag = new System.Windows.Forms.CheckBox();
			chk_contact_active_flag = new System.Windows.Forms.CheckBox();
			cbo_contact_title = new System.Windows.Forms.ComboBox();
			txt_contact_id = new System.Windows.Forms.TextBox();
			grd_Contact_Phone_Numbers = new UpgradeHelpers.DataGridViewFlex(components);
			_lblCompanyContact_14 = new System.Windows.Forms.Label();
			_lblCompanyContact_13 = new System.Windows.Forms.Label();
			_lblCompanyContact_12 = new System.Windows.Forms.Label();
			lblTransmitContactRecord = new System.Windows.Forms.Label();
			lblContactRelationships = new System.Windows.Forms.Label();
			lblChanges = new System.Windows.Forms.Label();
			_lblTitleGroup_12 = new System.Windows.Forms.Label();
			_lblCompanyContact_11 = new System.Windows.Forms.Label();
			_lblCompanyContact_10 = new System.Windows.Forms.Label();
			_lblCompanyContact_9 = new System.Windows.Forms.Label();
			lbl_contact_entry_date = new System.Windows.Forms.Label();
			lbl_contact_update_date = new System.Windows.Forms.Label();
			lblLockedBy = new System.Windows.Forms.Label();
			_lblCompanyContact_7 = new System.Windows.Forms.Label();
			_lblCompanyContact_6 = new System.Windows.Forms.Label();
			_lblCompanyContact_5 = new System.Windows.Forms.Label();
			_lblCompanyContact_4 = new System.Windows.Forms.Label();
			_lblCompanyContact_3 = new System.Windows.Forms.Label();
			_lblCompanyContact_8 = new System.Windows.Forms.Label();
			_lblCompanyContact_2 = new System.Windows.Forms.Label();
			_lblCompanyContact_1 = new System.Windows.Forms.Label();
			_lblCompanyContact_0 = new System.Windows.Forms.Label();
			pnl_Contact_Phone.SuspendLayout();
			pnl_update_Message.SuspendLayout();
			SuspendLayout();
			//Ctx_mnuRightClickPhoneNumbers
			Ctx_mnuRightClickPhoneNumbers = new System.Windows.Forms.ContextMenuStrip(components);
			Ctx_mnuRightClickPhoneNumbers.Size = new System.Drawing.Size(153, 26);
			Ctx_mnuRightClickPhoneNumbers.Opening += new System.ComponentModel.CancelEventHandler(Ctx_mnuRightClickPhoneNumbers_Opening);
			Ctx_mnuRightClickPhoneNumbers.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(Ctx_mnuRightClickPhoneNumbers_Closed);
			listBoxHelper1 = new UpgradeHelpers.Gui.Controls.ListBoxHelper(components);
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
			((System.ComponentModel.ISupportInitialize) grd_Contact_Phone_Numbers).BeginInit();
			// 
			// MainMenu1
			// 
			MainMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[]{mnuRightClickPhoneNumbers});
			// 
			// mnuRightClickPhoneNumbers
			// 
			mnuRightClickPhoneNumbers.Available = false;
			mnuRightClickPhoneNumbers.Checked = false;
			mnuRightClickPhoneNumbers.Enabled = true;
			mnuRightClickPhoneNumbers.Name = "mnuRightClickPhoneNumbers";
			mnuRightClickPhoneNumbers.Text = "Right Click Phone Numbers";
			mnuRightClickPhoneNumbers.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]{mnuContactDialPhoneNumber});
			// 
			// mnuContactDialPhoneNumber
			// 
			mnuContactDialPhoneNumber.Available = true;
			mnuContactDialPhoneNumber.Checked = false;
			mnuContactDialPhoneNumber.Enabled = true;
			mnuContactDialPhoneNumber.Name = "mnuContactDialPhoneNumber";
			mnuContactDialPhoneNumber.Text = "&Dial Phone Number";
			mnuContactDialPhoneNumber.Click += new System.EventHandler(mnuContactDialPhoneNumber_Click);
			// 
			// chk_hidden_comp
			// 
			chk_hidden_comp.AllowDrop = true;
			chk_hidden_comp.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_hidden_comp.BackColor = System.Drawing.SystemColors.Control;
			chk_hidden_comp.CausesValidation = true;
			chk_hidden_comp.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_hidden_comp.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_hidden_comp.Enabled = true;
			chk_hidden_comp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_hidden_comp.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_hidden_comp.Location = new System.Drawing.Point(16, 768);
			chk_hidden_comp.Name = "chk_hidden_comp";
			chk_hidden_comp.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_hidden_comp.Size = new System.Drawing.Size(137, 13);
			chk_hidden_comp.TabIndex = 73;
			chk_hidden_comp.TabStop = true;
			chk_hidden_comp.Text = "Comp Is Hidden";
			chk_hidden_comp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_hidden_comp.Visible = false;
			// 
			// chk_contact_do_not_solicit
			// 
			chk_contact_do_not_solicit.AllowDrop = true;
			chk_contact_do_not_solicit.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_contact_do_not_solicit.BackColor = System.Drawing.SystemColors.Control;
			chk_contact_do_not_solicit.CausesValidation = true;
			chk_contact_do_not_solicit.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_contact_do_not_solicit.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_contact_do_not_solicit.Enabled = true;
			chk_contact_do_not_solicit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_contact_do_not_solicit.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_contact_do_not_solicit.Location = new System.Drawing.Point(152, 47);
			chk_contact_do_not_solicit.Name = "chk_contact_do_not_solicit";
			chk_contact_do_not_solicit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_contact_do_not_solicit.Size = new System.Drawing.Size(92, 13);
			chk_contact_do_not_solicit.TabIndex = 72;
			chk_contact_do_not_solicit.TabStop = true;
			chk_contact_do_not_solicit.Text = "Do Not Solicit";
			chk_contact_do_not_solicit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_contact_do_not_solicit.Visible = true;
			// 
			// chk_iq_auto
			// 
			chk_iq_auto.AllowDrop = true;
			chk_iq_auto.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_iq_auto.BackColor = System.Drawing.SystemColors.Control;
			chk_iq_auto.CausesValidation = true;
			chk_iq_auto.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			chk_iq_auto.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_iq_auto.Enabled = true;
			chk_iq_auto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_iq_auto.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_iq_auto.Location = new System.Drawing.Point(8, 264);
			chk_iq_auto.Name = "chk_iq_auto";
			chk_iq_auto.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_iq_auto.Size = new System.Drawing.Size(57, 17);
			chk_iq_auto.TabIndex = 71;
			chk_iq_auto.TabStop = true;
			chk_iq_auto.Text = "IQ Auto";
			chk_iq_auto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_iq_auto.Visible = false;
			// 
			// txt_iq_email
			// 
			txt_iq_email.AcceptsReturn = true;
			txt_iq_email.AllowDrop = true;
			txt_iq_email.BackColor = System.Drawing.SystemColors.Window;
			txt_iq_email.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_iq_email.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_iq_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_iq_email.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_iq_email.Location = new System.Drawing.Point(120, 264);
			txt_iq_email.MaxLength = 0;
			txt_iq_email.Name = "txt_iq_email";
			txt_iq_email.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_iq_email.Size = new System.Drawing.Size(289, 19);
			txt_iq_email.TabIndex = 70;
			// 
			// cmd_add_new_contact
			// 
			cmd_add_new_contact.AllowDrop = true;
			cmd_add_new_contact.BackColor = System.Drawing.SystemColors.Control;
			cmd_add_new_contact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_add_new_contact.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_add_new_contact.Location = new System.Drawing.Point(16, 736);
			cmd_add_new_contact.Name = "cmd_add_new_contact";
			cmd_add_new_contact.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_add_new_contact.Size = new System.Drawing.Size(105, 25);
			cmd_add_new_contact.TabIndex = 66;
			cmd_add_new_contact.Text = "Add New Contact";
			cmd_add_new_contact.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_add_new_contact.UseVisualStyleBackColor = false;
			cmd_add_new_contact.Visible = false;
			cmd_add_new_contact.Click += new System.EventHandler(cmd_add_new_contact_Click);
			// 
			// txt_contact_email_address
			// 
			txt_contact_email_address.AcceptsReturn = true;
			txt_contact_email_address.AllowDrop = true;
			txt_contact_email_address.BackColor = System.Drawing.SystemColors.Window;
			txt_contact_email_address.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_contact_email_address.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_contact_email_address.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_contact_email_address.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_contact_email_address.Location = new System.Drawing.Point(96, 200);
			txt_contact_email_address.MaxLength = 150;
			txt_contact_email_address.Name = "txt_contact_email_address";
			txt_contact_email_address.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_contact_email_address.Size = new System.Drawing.Size(289, 19);
			txt_contact_email_address.TabIndex = 9;
			txt_contact_email_address.DoubleClick += new System.EventHandler(txt_contact_email_address_DoubleClick);
			// 
			// cbo_replacement_contact
			// 
			cbo_replacement_contact.AllowDrop = true;
			cbo_replacement_contact.BackColor = System.Drawing.SystemColors.Window;
			cbo_replacement_contact.CausesValidation = true;
			cbo_replacement_contact.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_replacement_contact.Enabled = true;
			cbo_replacement_contact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_replacement_contact.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_replacement_contact.IntegralHeight = true;
			cbo_replacement_contact.Location = new System.Drawing.Point(248, 736);
			cbo_replacement_contact.Name = "cbo_replacement_contact";
			cbo_replacement_contact.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_replacement_contact.Size = new System.Drawing.Size(273, 21);
			cbo_replacement_contact.Sorted = false;
			cbo_replacement_contact.TabIndex = 64;
			cbo_replacement_contact.TabStop = true;
			cbo_replacement_contact.Visible = false;
			// 
			// txt_contact_research_email_address
			// 
			txt_contact_research_email_address.AcceptsReturn = true;
			txt_contact_research_email_address.AllowDrop = true;
			txt_contact_research_email_address.BackColor = System.Drawing.SystemColors.Window;
			txt_contact_research_email_address.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_contact_research_email_address.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_contact_research_email_address.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_contact_research_email_address.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_contact_research_email_address.Location = new System.Drawing.Point(97, 240);
			txt_contact_research_email_address.MaxLength = 150;
			txt_contact_research_email_address.Name = "txt_contact_research_email_address";
			txt_contact_research_email_address.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_contact_research_email_address.Size = new System.Drawing.Size(289, 19);
			txt_contact_research_email_address.TabIndex = 13;
			txt_contact_research_email_address.DoubleClick += new System.EventHandler(txt_contact_research_email_address_DoubleClick);
			// 
			// chkContactDoNotSendJNiQSurvey
			// 
			chkContactDoNotSendJNiQSurvey.AllowDrop = true;
			chkContactDoNotSendJNiQSurvey.Appearance = System.Windows.Forms.Appearance.Normal;
			chkContactDoNotSendJNiQSurvey.BackColor = System.Drawing.SystemColors.Control;
			chkContactDoNotSendJNiQSurvey.CausesValidation = true;
			chkContactDoNotSendJNiQSurvey.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkContactDoNotSendJNiQSurvey.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkContactDoNotSendJNiQSurvey.Enabled = true;
			chkContactDoNotSendJNiQSurvey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkContactDoNotSendJNiQSurvey.ForeColor = System.Drawing.SystemColors.WindowText;
			chkContactDoNotSendJNiQSurvey.Location = new System.Drawing.Point(288, 226);
			chkContactDoNotSendJNiQSurvey.Name = "chkContactDoNotSendJNiQSurvey";
			chkContactDoNotSendJNiQSurvey.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkContactDoNotSendJNiQSurvey.Size = new System.Drawing.Size(186, 13);
			chkContactDoNotSendJNiQSurvey.TabIndex = 12;
			chkContactDoNotSendJNiQSurvey.TabStop = true;
			chkContactDoNotSendJNiQSurvey.Text = "Do Not Send EMail JNiQ Survey";
			chkContactDoNotSendJNiQSurvey.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkContactDoNotSendJNiQSurvey.Visible = true;
			chkContactDoNotSendJNiQSurvey.CheckStateChanged += new System.EventHandler(chkContactDoNotSendJNiQSurvey_CheckStateChanged);
			// 
			// chkContactDoNotSendEMail
			// 
			chkContactDoNotSendEMail.AllowDrop = true;
			chkContactDoNotSendEMail.Appearance = System.Windows.Forms.Appearance.Normal;
			chkContactDoNotSendEMail.BackColor = System.Drawing.SystemColors.Control;
			chkContactDoNotSendEMail.CausesValidation = true;
			chkContactDoNotSendEMail.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkContactDoNotSendEMail.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkContactDoNotSendEMail.Enabled = true;
			chkContactDoNotSendEMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkContactDoNotSendEMail.ForeColor = System.Drawing.SystemColors.WindowText;
			chkContactDoNotSendEMail.Location = new System.Drawing.Point(68, 226);
			chkContactDoNotSendEMail.Name = "chkContactDoNotSendEMail";
			chkContactDoNotSendEMail.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkContactDoNotSendEMail.Size = new System.Drawing.Size(198, 13);
			chkContactDoNotSendEMail.TabIndex = 11;
			chkContactDoNotSendEMail.TabStop = true;
			chkContactDoNotSendEMail.Text = "JETNET Internal Do Not Send EMail";
			chkContactDoNotSendEMail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkContactDoNotSendEMail.Visible = true;
			chkContactDoNotSendEMail.CheckStateChanged += new System.EventHandler(chkContactDoNotSendEMail_CheckStateChanged);
			// 
			// cmdFindContactMatch
			// 
			cmdFindContactMatch.AllowDrop = true;
			cmdFindContactMatch.BackColor = System.Drawing.SystemColors.Control;
			cmdFindContactMatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdFindContactMatch.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdFindContactMatch.Location = new System.Drawing.Point(448, 52);
			cmdFindContactMatch.Name = "cmdFindContactMatch";
			cmdFindContactMatch.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdFindContactMatch.Size = new System.Drawing.Size(65, 25);
			cmdFindContactMatch.TabIndex = 60;
			cmdFindContactMatch.Text = "&Find Match";
			cmdFindContactMatch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdFindContactMatch.UseVisualStyleBackColor = false;
			cmdFindContactMatch.Click += new System.EventHandler(cmdFindContactMatch_Click);
			// 
			// cmd_add_contact_phone
			// 
			cmd_add_contact_phone.AllowDrop = true;
			cmd_add_contact_phone.BackColor = System.Drawing.SystemColors.Control;
			cmd_add_contact_phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_add_contact_phone.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_add_contact_phone.Location = new System.Drawing.Point(24, 521);
			cmd_add_contact_phone.Name = "cmd_add_contact_phone";
			cmd_add_contact_phone.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_add_contact_phone.Size = new System.Drawing.Size(122, 24);
			cmd_add_contact_phone.TabIndex = 15;
			cmd_add_contact_phone.Text = "Add Phone Number";
			cmd_add_contact_phone.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_add_contact_phone.UseVisualStyleBackColor = false;
			cmd_add_contact_phone.Click += new System.EventHandler(cmd_add_Contact_phone_Click);
			// 
			// pnl_Contact_Phone
			// 
			pnl_Contact_Phone.AllowDrop = true;
			pnl_Contact_Phone.BackColor = System.Drawing.SystemColors.Control;
			pnl_Contact_Phone.Controls.Add(txt_ext);
			pnl_Contact_Phone.Controls.Add(chk_pnum_hide_customer);
			pnl_Contact_Phone.Controls.Add(cbo_pnum_type);
			pnl_Contact_Phone.Controls.Add(cmd_save_contact_phone);
			pnl_Contact_Phone.Controls.Add(txt_pnum_area_code);
			pnl_Contact_Phone.Controls.Add(txt_pnum_number);
			pnl_Contact_Phone.Controls.Add(txt_pnum_cntry_code);
			pnl_Contact_Phone.Controls.Add(cmd_cancel_contact_phone);
			pnl_Contact_Phone.Controls.Add(txt_pnum_prefix);
			pnl_Contact_Phone.Controls.Add(_lbl_comp_0);
			pnl_Contact_Phone.Controls.Add(_lbl_comp_53);
			pnl_Contact_Phone.Controls.Add(_lbl_comp_25);
			pnl_Contact_Phone.Controls.Add(_lbl_comp_52);
			pnl_Contact_Phone.Controls.Add(_lbl_comp_24);
			pnl_Contact_Phone.Controls.Add(_lbl_comp_45);
			pnl_Contact_Phone.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			pnl_Contact_Phone.Enabled = true;
			pnl_Contact_Phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Contact_Phone.ForeColor = System.Drawing.SystemColors.ControlText;
			pnl_Contact_Phone.Location = new System.Drawing.Point(98, 336);
			pnl_Contact_Phone.Name = "pnl_Contact_Phone";
			pnl_Contact_Phone.RightToLeft = System.Windows.Forms.RightToLeft.No;
			pnl_Contact_Phone.Size = new System.Drawing.Size(399, 80);
			pnl_Contact_Phone.TabIndex = 54;
			pnl_Contact_Phone.Text = "Contact Phone Number Details";
			pnl_Contact_Phone.Visible = false;
			// 
			// txt_ext
			// 
			txt_ext.AcceptsReturn = true;
			txt_ext.AllowDrop = true;
			txt_ext.BackColor = System.Drawing.SystemColors.Window;
			txt_ext.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_ext.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ext.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ext.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ext.Location = new System.Drawing.Point(344, 28);
			txt_ext.MaxLength = 6;
			txt_ext.Name = "txt_ext";
			txt_ext.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ext.Size = new System.Drawing.Size(42, 21);
			txt_ext.TabIndex = 68;
			// 
			// chk_pnum_hide_customer
			// 
			chk_pnum_hide_customer.AllowDrop = true;
			chk_pnum_hide_customer.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_pnum_hide_customer.BackColor = System.Drawing.SystemColors.Control;
			chk_pnum_hide_customer.CausesValidation = true;
			chk_pnum_hide_customer.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			chk_pnum_hide_customer.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_pnum_hide_customer.Enabled = true;
			chk_pnum_hide_customer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_pnum_hide_customer.ForeColor = System.Drawing.SystemColors.WindowText;
			chk_pnum_hide_customer.Location = new System.Drawing.Point(136, 53);
			chk_pnum_hide_customer.Name = "chk_pnum_hide_customer";
			chk_pnum_hide_customer.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_pnum_hide_customer.Size = new System.Drawing.Size(121, 21);
			chk_pnum_hide_customer.TabIndex = 29;
			chk_pnum_hide_customer.TabStop = true;
			chk_pnum_hide_customer.Text = "Hide From Customer";
			chk_pnum_hide_customer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_pnum_hide_customer.Visible = true;
			// 
			// cbo_pnum_type
			// 
			cbo_pnum_type.AllowDrop = true;
			cbo_pnum_type.BackColor = System.Drawing.SystemColors.Window;
			cbo_pnum_type.CausesValidation = true;
			cbo_pnum_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_pnum_type.Enabled = true;
			cbo_pnum_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_pnum_type.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_pnum_type.IntegralHeight = true;
			cbo_pnum_type.Location = new System.Drawing.Point(11, 28);
			cbo_pnum_type.Name = "cbo_pnum_type";
			cbo_pnum_type.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_pnum_type.Size = new System.Drawing.Size(108, 21);
			cbo_pnum_type.Sorted = false;
			cbo_pnum_type.TabIndex = 24;
			cbo_pnum_type.TabStop = true;
			cbo_pnum_type.Visible = true;
			cbo_pnum_type.TextChanged += new System.EventHandler(cbo_pnum_type_TextChanged);
			// 
			// cmd_save_contact_phone
			// 
			cmd_save_contact_phone.AllowDrop = true;
			cmd_save_contact_phone.BackColor = System.Drawing.SystemColors.Control;
			cmd_save_contact_phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_save_contact_phone.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_save_contact_phone.Location = new System.Drawing.Point(8, 54);
			cmd_save_contact_phone.Name = "cmd_save_contact_phone";
			cmd_save_contact_phone.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_save_contact_phone.Size = new System.Drawing.Size(113, 21);
			cmd_save_contact_phone.TabIndex = 30;
			cmd_save_contact_phone.Text = "&Confirm/Save";
			cmd_save_contact_phone.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_save_contact_phone.UseVisualStyleBackColor = false;
			cmd_save_contact_phone.Click += new System.EventHandler(cmd_save_contact_phone_Click);
			// 
			// txt_pnum_area_code
			// 
			txt_pnum_area_code.AcceptsReturn = true;
			txt_pnum_area_code.AllowDrop = true;
			txt_pnum_area_code.BackColor = System.Drawing.SystemColors.Window;
			txt_pnum_area_code.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_pnum_area_code.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_pnum_area_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_pnum_area_code.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_pnum_area_code.Location = new System.Drawing.Point(172, 28);
			txt_pnum_area_code.MaxLength = 6;
			txt_pnum_area_code.Name = "txt_pnum_area_code";
			txt_pnum_area_code.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_pnum_area_code.Size = new System.Drawing.Size(42, 21);
			txt_pnum_area_code.TabIndex = 26;
			txt_pnum_area_code.TextChanged += new System.EventHandler(txt_pnum_area_code_TextChanged);
			// 
			// txt_pnum_number
			// 
			txt_pnum_number.AcceptsReturn = true;
			txt_pnum_number.AllowDrop = true;
			txt_pnum_number.BackColor = System.Drawing.SystemColors.Window;
			txt_pnum_number.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_pnum_number.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_pnum_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_pnum_number.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_pnum_number.Location = new System.Drawing.Point(267, 28);
			txt_pnum_number.MaxLength = 10;
			txt_pnum_number.Name = "txt_pnum_number";
			txt_pnum_number.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_pnum_number.Size = new System.Drawing.Size(66, 21);
			txt_pnum_number.TabIndex = 28;
			txt_pnum_number.TextChanged += new System.EventHandler(txt_pnum_number_TextChanged);
			// 
			// txt_pnum_cntry_code
			// 
			txt_pnum_cntry_code.AcceptsReturn = true;
			txt_pnum_cntry_code.AllowDrop = true;
			txt_pnum_cntry_code.BackColor = System.Drawing.SystemColors.Window;
			txt_pnum_cntry_code.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_pnum_cntry_code.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_pnum_cntry_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_pnum_cntry_code.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_pnum_cntry_code.Location = new System.Drawing.Point(125, 28);
			txt_pnum_cntry_code.MaxLength = 6;
			txt_pnum_cntry_code.Name = "txt_pnum_cntry_code";
			txt_pnum_cntry_code.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_pnum_cntry_code.Size = new System.Drawing.Size(42, 21);
			txt_pnum_cntry_code.TabIndex = 25;
			txt_pnum_cntry_code.TextChanged += new System.EventHandler(txt_pnum_cntry_code_TextChanged);
			// 
			// cmd_cancel_contact_phone
			// 
			cmd_cancel_contact_phone.AllowDrop = true;
			cmd_cancel_contact_phone.BackColor = System.Drawing.SystemColors.Control;
			cmd_cancel_contact_phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_cancel_contact_phone.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_cancel_contact_phone.Location = new System.Drawing.Point(269, 53);
			cmd_cancel_contact_phone.Name = "cmd_cancel_contact_phone";
			cmd_cancel_contact_phone.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_cancel_contact_phone.Size = new System.Drawing.Size(65, 21);
			cmd_cancel_contact_phone.TabIndex = 31;
			cmd_cancel_contact_phone.Text = "&Cancel";
			cmd_cancel_contact_phone.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_cancel_contact_phone.UseVisualStyleBackColor = false;
			cmd_cancel_contact_phone.Click += new System.EventHandler(cmd_cancel_contact_phone_Click);
			// 
			// txt_pnum_prefix
			// 
			txt_pnum_prefix.AcceptsReturn = true;
			txt_pnum_prefix.AllowDrop = true;
			txt_pnum_prefix.BackColor = System.Drawing.SystemColors.Window;
			txt_pnum_prefix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_pnum_prefix.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_pnum_prefix.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_pnum_prefix.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_pnum_prefix.Location = new System.Drawing.Point(220, 28);
			txt_pnum_prefix.MaxLength = 6;
			txt_pnum_prefix.Name = "txt_pnum_prefix";
			txt_pnum_prefix.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_pnum_prefix.Size = new System.Drawing.Size(42, 21);
			txt_pnum_prefix.TabIndex = 27;
			txt_pnum_prefix.TextChanged += new System.EventHandler(txt_pnum_prefix_TextChanged);
			// 
			// _lbl_comp_0
			// 
			_lbl_comp_0.AllowDrop = true;
			_lbl_comp_0.AutoSize = true;
			_lbl_comp_0.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_0.Location = new System.Drawing.Point(356, 13);
			_lbl_comp_0.MinimumSize = new System.Drawing.Size(18, 13);
			_lbl_comp_0.Name = "_lbl_comp_0";
			_lbl_comp_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_0.Size = new System.Drawing.Size(18, 13);
			_lbl_comp_0.TabIndex = 67;
			_lbl_comp_0.Text = "Ext.";
			_lbl_comp_0.Click += new System.EventHandler(lbl_comp_Click);
			// 
			// _lbl_comp_53
			// 
			_lbl_comp_53.AllowDrop = true;
			_lbl_comp_53.AutoSize = true;
			_lbl_comp_53.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_53.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_53.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_53.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_53.Location = new System.Drawing.Point(285, 13);
			_lbl_comp_53.MinimumSize = new System.Drawing.Size(31, 13);
			_lbl_comp_53.Name = "_lbl_comp_53";
			_lbl_comp_53.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_53.Size = new System.Drawing.Size(31, 13);
			_lbl_comp_53.TabIndex = 59;
			_lbl_comp_53.Text = "Phone";
			_lbl_comp_53.Click += new System.EventHandler(lbl_comp_Click);
			// 
			// _lbl_comp_25
			// 
			_lbl_comp_25.AllowDrop = true;
			_lbl_comp_25.AutoSize = true;
			_lbl_comp_25.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_25.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_25.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_25.Location = new System.Drawing.Point(128, 13);
			_lbl_comp_25.MinimumSize = new System.Drawing.Size(36, 13);
			_lbl_comp_25.Name = "_lbl_comp_25";
			_lbl_comp_25.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_25.Size = new System.Drawing.Size(36, 13);
			_lbl_comp_25.TabIndex = 58;
			_lbl_comp_25.Tag = "lbl_cntry_code";
			_lbl_comp_25.Text = "Country";
			_lbl_comp_25.Click += new System.EventHandler(lbl_comp_Click);
			// 
			// _lbl_comp_52
			// 
			_lbl_comp_52.AllowDrop = true;
			_lbl_comp_52.AutoSize = true;
			_lbl_comp_52.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_52.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_52.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_52.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_52.Location = new System.Drawing.Point(182, 13);
			_lbl_comp_52.MinimumSize = new System.Drawing.Size(22, 13);
			_lbl_comp_52.Name = "_lbl_comp_52";
			_lbl_comp_52.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_52.Size = new System.Drawing.Size(22, 13);
			_lbl_comp_52.TabIndex = 57;
			_lbl_comp_52.Text = "Area";
			_lbl_comp_52.Click += new System.EventHandler(lbl_comp_Click);
			// 
			// _lbl_comp_24
			// 
			_lbl_comp_24.AllowDrop = true;
			_lbl_comp_24.AutoSize = true;
			_lbl_comp_24.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_24.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_24.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_24.Location = new System.Drawing.Point(53, 13);
			_lbl_comp_24.MinimumSize = new System.Drawing.Size(24, 13);
			_lbl_comp_24.Name = "_lbl_comp_24";
			_lbl_comp_24.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_24.Size = new System.Drawing.Size(24, 13);
			_lbl_comp_24.TabIndex = 56;
			_lbl_comp_24.Tag = "lbl_type";
			_lbl_comp_24.Text = "Type";
			_lbl_comp_24.Click += new System.EventHandler(lbl_comp_Click);
			// 
			// _lbl_comp_45
			// 
			_lbl_comp_45.AllowDrop = true;
			_lbl_comp_45.AutoSize = true;
			_lbl_comp_45.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_45.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_45.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_45.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_45.Location = new System.Drawing.Point(228, 13);
			_lbl_comp_45.MinimumSize = new System.Drawing.Size(26, 13);
			_lbl_comp_45.Name = "_lbl_comp_45";
			_lbl_comp_45.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_45.Size = new System.Drawing.Size(26, 13);
			_lbl_comp_45.TabIndex = 55;
			_lbl_comp_45.Text = "Prefix";
			_lbl_comp_45.Click += new System.EventHandler(lbl_comp_Click);
			// 
			// pnl_update_Message
			// 
			pnl_update_Message.AllowDrop = true;
			pnl_update_Message.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_update_Message.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_update_Message.Controls.Add(_lbl_comp_40);
			pnl_update_Message.Font = new System.Drawing.Font("Tahoma", 13.5f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_update_Message.ForeColor = System.Drawing.Color.Black;
			pnl_update_Message.Location = new System.Drawing.Point(13, 308);
			pnl_update_Message.Name = "pnl_update_Message";
			pnl_update_Message.Size = new System.Drawing.Size(521, 129);
			pnl_update_Message.TabIndex = 45;
			pnl_update_Message.Visible = false;
			// 
			// _lbl_comp_40
			// 
			_lbl_comp_40.AllowDrop = true;
			_lbl_comp_40.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_40.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_40.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_40.ForeColor = System.Drawing.Color.Maroon;
			_lbl_comp_40.Location = new System.Drawing.Point(183, 57);
			_lbl_comp_40.MinimumSize = new System.Drawing.Size(153, 27);
			_lbl_comp_40.Name = "_lbl_comp_40";
			_lbl_comp_40.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_40.Size = new System.Drawing.Size(153, 27);
			_lbl_comp_40.TabIndex = 53;
			_lbl_comp_40.Tag = "N";
			_lbl_comp_40.Text = "PLEASE WAIT!";
			_lbl_comp_40.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_comp_40.Click += new System.EventHandler(lbl_comp_Click);
			// 
			// pgTimer1
			// 
			pgTimer1.Enabled = false;
			pgTimer1.Interval = 1;
			pgTimer1.Tick += new System.EventHandler(pgTimer1_Tick);
			// 
			// cmdDelete
			// 
			cmdDelete.AllowDrop = true;
			cmdDelete.BackColor = System.Drawing.SystemColors.Control;
			cmdDelete.Enabled = false;
			cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdDelete.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdDelete.Location = new System.Drawing.Point(418, 521);
			cmdDelete.Name = "cmdDelete";
			cmdDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdDelete.Size = new System.Drawing.Size(103, 24);
			cmdDelete.TabIndex = 18;
			cmdDelete.Text = "Delete Contact";
			cmdDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdDelete.Click += new System.EventHandler(cmdDelete_Click);
			// 
			// lstTitleGroup
			// 
			lstTitleGroup.AllowDrop = true;
			lstTitleGroup.BackColor = System.Drawing.SystemColors.Window;
			lstTitleGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lstTitleGroup.CausesValidation = true;
			lstTitleGroup.Enabled = true;
			lstTitleGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lstTitleGroup.ForeColor = System.Drawing.SystemColors.WindowText;
			lstTitleGroup.IntegralHeight = true;
			lstTitleGroup.Location = new System.Drawing.Point(24, 70);
			lstTitleGroup.MultiColumn = false;
			lstTitleGroup.Name = "lstTitleGroup";
			lstTitleGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lstTitleGroup.Size = new System.Drawing.Size(180, 70);
			lstTitleGroup.Sorted = false;
			lstTitleGroup.TabIndex = 1;
			lstTitleGroup.TabStop = true;
			lstTitleGroup.Visible = true;
			lstTitleGroup.SelectedIndexChanged += new System.EventHandler(lstTitleGroup_SelectedIndexChanged);
			// 
			// cmdViewBadContactEmails
			// 
			cmdViewBadContactEmails.AllowDrop = true;
			cmdViewBadContactEmails.BackColor = System.Drawing.SystemColors.Control;
			cmdViewBadContactEmails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdViewBadContactEmails.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdViewBadContactEmails.Location = new System.Drawing.Point(403, 201);
			cmdViewBadContactEmails.Name = "cmdViewBadContactEmails";
			cmdViewBadContactEmails.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdViewBadContactEmails.Size = new System.Drawing.Size(130, 19);
			cmdViewBadContactEmails.TabIndex = 10;
			cmdViewBadContactEmails.Text = "List Bad Contact Emails";
			cmdViewBadContactEmails.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdViewBadContactEmails.UseVisualStyleBackColor = false;
			// 
			// txt_contact_acpros_seq_no
			// 
			txt_contact_acpros_seq_no.AcceptsReturn = true;
			txt_contact_acpros_seq_no.AllowDrop = true;
			txt_contact_acpros_seq_no.BackColor = System.Drawing.SystemColors.Window;
			txt_contact_acpros_seq_no.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_contact_acpros_seq_no.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_contact_acpros_seq_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_contact_acpros_seq_no.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_contact_acpros_seq_no.Location = new System.Drawing.Point(24, 172);
			txt_contact_acpros_seq_no.MaxLength = 3;
			txt_contact_acpros_seq_no.Name = "txt_contact_acpros_seq_no";
			txt_contact_acpros_seq_no.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_contact_acpros_seq_no.Size = new System.Drawing.Size(25, 21);
			txt_contact_acpros_seq_no.TabIndex = 3;
			// 
			// chk_HideFromCustomer
			// 
			chk_HideFromCustomer.AllowDrop = true;
			chk_HideFromCustomer.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_HideFromCustomer.BackColor = System.Drawing.SystemColors.Control;
			chk_HideFromCustomer.CausesValidation = true;
			chk_HideFromCustomer.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			chk_HideFromCustomer.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_HideFromCustomer.Enabled = true;
			chk_HideFromCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_HideFromCustomer.ForeColor = System.Drawing.SystemColors.WindowText;
			chk_HideFromCustomer.Location = new System.Drawing.Point(253, 67);
			chk_HideFromCustomer.Name = "chk_HideFromCustomer";
			chk_HideFromCustomer.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_HideFromCustomer.Size = new System.Drawing.Size(186, 13);
			chk_HideFromCustomer.TabIndex = 34;
			chk_HideFromCustomer.TabStop = true;
			chk_HideFromCustomer.Text = "Internal Only (Hide From Customer)";
			chk_HideFromCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_HideFromCustomer.Visible = true;
			// 
			// cmd_delete_contact_Phone
			// 
			cmd_delete_contact_Phone.AllowDrop = true;
			cmd_delete_contact_Phone.BackColor = System.Drawing.SystemColors.Control;
			cmd_delete_contact_Phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_delete_contact_Phone.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_delete_contact_Phone.Location = new System.Drawing.Point(288, 521);
			cmd_delete_contact_Phone.Name = "cmd_delete_contact_Phone";
			cmd_delete_contact_Phone.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_delete_contact_Phone.Size = new System.Drawing.Size(122, 24);
			cmd_delete_contact_Phone.TabIndex = 17;
			cmd_delete_contact_Phone.Text = "Delete Phone Number";
			cmd_delete_contact_Phone.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_delete_contact_Phone.UseVisualStyleBackColor = false;
			cmd_delete_contact_Phone.Click += new System.EventHandler(cmd_delete_contact_phone_Click);
			// 
			// cmd_confirm_contact_Phone
			// 
			cmd_confirm_contact_Phone.AllowDrop = true;
			cmd_confirm_contact_Phone.BackColor = System.Drawing.SystemColors.Control;
			cmd_confirm_contact_Phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_confirm_contact_Phone.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_confirm_contact_Phone.Location = new System.Drawing.Point(154, 521);
			cmd_confirm_contact_Phone.Name = "cmd_confirm_contact_Phone";
			cmd_confirm_contact_Phone.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_confirm_contact_Phone.Size = new System.Drawing.Size(122, 24);
			cmd_confirm_contact_Phone.TabIndex = 16;
			cmd_confirm_contact_Phone.Text = "Confirm Phone Number";
			cmd_confirm_contact_Phone.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_confirm_contact_Phone.UseVisualStyleBackColor = false;
			cmd_confirm_contact_Phone.Click += new System.EventHandler(cmd_Confirm_Contact_Phone_Click);
			// 
			// cmd_Save_Contact
			// 
			cmd_Save_Contact.AllowDrop = true;
			cmd_Save_Contact.BackColor = System.Drawing.SystemColors.Control;
			cmd_Save_Contact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Save_Contact.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Save_Contact.Location = new System.Drawing.Point(64, 632);
			cmd_Save_Contact.Name = "cmd_Save_Contact";
			cmd_Save_Contact.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Save_Contact.Size = new System.Drawing.Size(91, 24);
			cmd_Save_Contact.TabIndex = 20;
			cmd_Save_Contact.Text = "&Save";
			cmd_Save_Contact.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Save_Contact.UseVisualStyleBackColor = false;
			cmd_Save_Contact.Click += new System.EventHandler(cmd_Save_Contact_Click);
			// 
			// txt_contact_description
			// 
			txt_contact_description.AcceptsReturn = true;
			txt_contact_description.AllowDrop = true;
			txt_contact_description.BackColor = System.Drawing.SystemColors.Window;
			txt_contact_description.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_contact_description.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_contact_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_contact_description.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_contact_description.Location = new System.Drawing.Point(24, 560);
			txt_contact_description.MaxLength = 250;
			txt_contact_description.Multiline = true;
			txt_contact_description.Name = "txt_contact_description";
			txt_contact_description.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_contact_description.Size = new System.Drawing.Size(497, 54);
			txt_contact_description.TabIndex = 19;
			// 
			// cmd_Confirm_Contact
			// 
			cmd_Confirm_Contact.AllowDrop = true;
			cmd_Confirm_Contact.BackColor = System.Drawing.SystemColors.Control;
			cmd_Confirm_Contact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Confirm_Contact.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Confirm_Contact.Location = new System.Drawing.Point(175, 635);
			cmd_Confirm_Contact.Name = "cmd_Confirm_Contact";
			cmd_Confirm_Contact.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Confirm_Contact.Size = new System.Drawing.Size(91, 24);
			cmd_Confirm_Contact.TabIndex = 21;
			cmd_Confirm_Contact.Text = "Confirm Contact";
			cmd_Confirm_Contact.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Confirm_Contact.UseVisualStyleBackColor = false;
			cmd_Confirm_Contact.Click += new System.EventHandler(cmd_Confirm_Contact_Click);
			// 
			// cmd_Subscription
			// 
			cmd_Subscription.AllowDrop = true;
			cmd_Subscription.BackColor = System.Drawing.SystemColors.Control;
			cmd_Subscription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Subscription.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Subscription.Location = new System.Drawing.Point(282, 635);
			cmd_Subscription.Name = "cmd_Subscription";
			cmd_Subscription.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Subscription.Size = new System.Drawing.Size(91, 24);
			cmd_Subscription.TabIndex = 22;
			cmd_Subscription.Text = "Subscription";
			cmd_Subscription.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Subscription.UseVisualStyleBackColor = false;
			cmd_Subscription.Click += new System.EventHandler(cmd_Subscription_Click);
			// 
			// cmd_Close
			// 
			cmd_Close.AllowDrop = true;
			cmd_Close.BackColor = System.Drawing.SystemColors.Control;
			cmd_Close.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Close.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Close.Location = new System.Drawing.Point(389, 636);
			cmd_Close.Name = "cmd_Close";
			cmd_Close.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Close.Size = new System.Drawing.Size(91, 24);
			cmd_Close.TabIndex = 23;
			cmd_Close.Text = "Close";
			cmd_Close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Close.UseVisualStyleBackColor = false;
			cmd_Close.Click += new System.EventHandler(cmd_Close_Click);
			// 
			// cbo_contact_suffix
			// 
			cbo_contact_suffix.AllowDrop = true;
			cbo_contact_suffix.BackColor = System.Drawing.SystemColors.Window;
			cbo_contact_suffix.CausesValidation = true;
			cbo_contact_suffix.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_contact_suffix.Enabled = true;
			cbo_contact_suffix.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_contact_suffix.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_contact_suffix.IntegralHeight = true;
			cbo_contact_suffix.Location = new System.Drawing.Point(432, 172);
			cbo_contact_suffix.Name = "cbo_contact_suffix";
			cbo_contact_suffix.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_contact_suffix.Size = new System.Drawing.Size(89, 21);
			cbo_contact_suffix.Sorted = false;
			cbo_contact_suffix.TabIndex = 8;
			cbo_contact_suffix.TabStop = true;
			cbo_contact_suffix.Text = "cbo_contact_suffix";
			cbo_contact_suffix.Visible = true;
			cbo_contact_suffix.Leave += new System.EventHandler(cbo_contact_suffix_Leave);
			// 
			// txt_contact_last_name
			// 
			txt_contact_last_name.AcceptsReturn = true;
			txt_contact_last_name.AllowDrop = true;
			txt_contact_last_name.BackColor = System.Drawing.SystemColors.Window;
			txt_contact_last_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_contact_last_name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_contact_last_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_contact_last_name.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_contact_last_name.Location = new System.Drawing.Point(283, 172);
			txt_contact_last_name.MaxLength = 50;
			txt_contact_last_name.Name = "txt_contact_last_name";
			txt_contact_last_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_contact_last_name.Size = new System.Drawing.Size(145, 21);
			txt_contact_last_name.TabIndex = 7;
			// 
			// txt_contact_middle_initial
			// 
			txt_contact_middle_initial.AcceptsReturn = true;
			txt_contact_middle_initial.AllowDrop = true;
			txt_contact_middle_initial.BackColor = System.Drawing.SystemColors.Window;
			txt_contact_middle_initial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_contact_middle_initial.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_contact_middle_initial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_contact_middle_initial.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_contact_middle_initial.Location = new System.Drawing.Point(258, 172);
			txt_contact_middle_initial.MaxLength = 1;
			txt_contact_middle_initial.Name = "txt_contact_middle_initial";
			txt_contact_middle_initial.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_contact_middle_initial.Size = new System.Drawing.Size(22, 21);
			txt_contact_middle_initial.TabIndex = 6;
			// 
			// txt_contact_first_name
			// 
			txt_contact_first_name.AcceptsReturn = true;
			txt_contact_first_name.AllowDrop = true;
			txt_contact_first_name.BackColor = System.Drawing.SystemColors.Window;
			txt_contact_first_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_contact_first_name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_contact_first_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_contact_first_name.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_contact_first_name.Location = new System.Drawing.Point(152, 172);
			txt_contact_first_name.MaxLength = 50;
			txt_contact_first_name.Name = "txt_contact_first_name";
			txt_contact_first_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_contact_first_name.Size = new System.Drawing.Size(100, 21);
			txt_contact_first_name.TabIndex = 5;
			// 
			// cbo_contact_sirname
			// 
			cbo_contact_sirname.AllowDrop = true;
			cbo_contact_sirname.BackColor = System.Drawing.SystemColors.Window;
			cbo_contact_sirname.CausesValidation = true;
			cbo_contact_sirname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_contact_sirname.Enabled = true;
			cbo_contact_sirname.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_contact_sirname.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_contact_sirname.IntegralHeight = true;
			cbo_contact_sirname.Location = new System.Drawing.Point(53, 172);
			cbo_contact_sirname.Name = "cbo_contact_sirname";
			cbo_contact_sirname.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_contact_sirname.Size = new System.Drawing.Size(98, 21);
			cbo_contact_sirname.Sorted = false;
			cbo_contact_sirname.TabIndex = 4;
			cbo_contact_sirname.TabStop = true;
			cbo_contact_sirname.Text = "cbo_contact_sirname";
			cbo_contact_sirname.Visible = true;
			cbo_contact_sirname.Leave += new System.EventHandler(cbo_contact_sirname_Leave);
			// 
			// chk_contact_research_flag
			// 
			chk_contact_research_flag.AllowDrop = true;
			chk_contact_research_flag.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_contact_research_flag.BackColor = System.Drawing.SystemColors.Control;
			chk_contact_research_flag.CausesValidation = true;
			chk_contact_research_flag.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			chk_contact_research_flag.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_contact_research_flag.Enabled = true;
			chk_contact_research_flag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_contact_research_flag.ForeColor = System.Drawing.SystemColors.WindowText;
			chk_contact_research_flag.Location = new System.Drawing.Point(326, 47);
			chk_contact_research_flag.Name = "chk_contact_research_flag";
			chk_contact_research_flag.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_contact_research_flag.Size = new System.Drawing.Size(113, 13);
			chk_contact_research_flag.TabIndex = 33;
			chk_contact_research_flag.TabStop = true;
			chk_contact_research_flag.Text = "Research Contact?";
			chk_contact_research_flag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_contact_research_flag.Visible = true;
			// 
			// chk_contact_active_flag
			// 
			chk_contact_active_flag.AllowDrop = true;
			chk_contact_active_flag.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_contact_active_flag.BackColor = System.Drawing.SystemColors.Control;
			chk_contact_active_flag.CausesValidation = true;
			chk_contact_active_flag.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			chk_contact_active_flag.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_contact_active_flag.Enabled = true;
			chk_contact_active_flag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_contact_active_flag.ForeColor = System.Drawing.SystemColors.WindowText;
			chk_contact_active_flag.Location = new System.Drawing.Point(256, 47);
			chk_contact_active_flag.Name = "chk_contact_active_flag";
			chk_contact_active_flag.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_contact_active_flag.Size = new System.Drawing.Size(52, 13);
			chk_contact_active_flag.TabIndex = 32;
			chk_contact_active_flag.TabStop = true;
			chk_contact_active_flag.Text = "Active";
			chk_contact_active_flag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_contact_active_flag.Visible = true;
			chk_contact_active_flag.CheckStateChanged += new System.EventHandler(chk_contact_active_flag_CheckStateChanged);
			chk_contact_active_flag.MouseDown += new System.Windows.Forms.MouseEventHandler(chk_contact_active_flag_MouseDown);
			// 
			// cbo_contact_title
			// 
			cbo_contact_title.AllowDrop = true;
			cbo_contact_title.BackColor = System.Drawing.SystemColors.Window;
			cbo_contact_title.CausesValidation = true;
			cbo_contact_title.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_contact_title.Enabled = true;
			cbo_contact_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_contact_title.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_contact_title.IntegralHeight = true;
			cbo_contact_title.Location = new System.Drawing.Point(211, 116);
			cbo_contact_title.Name = "cbo_contact_title";
			cbo_contact_title.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_contact_title.Size = new System.Drawing.Size(309, 21);
			cbo_contact_title.Sorted = false;
			cbo_contact_title.TabIndex = 2;
			cbo_contact_title.TabStop = true;
			cbo_contact_title.Text = "cbo_contact_title";
			cbo_contact_title.Visible = true;
			cbo_contact_title.Leave += new System.EventHandler(cbo_contact_title_Leave);
			// 
			// txt_contact_id
			// 
			txt_contact_id.AcceptsReturn = true;
			txt_contact_id.AllowDrop = true;
			txt_contact_id.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_contact_id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_contact_id.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_contact_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_contact_id.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_contact_id.Location = new System.Drawing.Point(57, 30);
			txt_contact_id.MaxLength = 0;
			txt_contact_id.Name = "txt_contact_id";
			txt_contact_id.ReadOnly = true;
			txt_contact_id.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_contact_id.Size = new System.Drawing.Size(57, 19);
			txt_contact_id.TabIndex = 0;
			txt_contact_id.TabStop = false;
			txt_contact_id.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// grd_Contact_Phone_Numbers
			// 
			grd_Contact_Phone_Numbers.AllowBigSelection = false;
			grd_Contact_Phone_Numbers.AllowDrop = true;
			grd_Contact_Phone_Numbers.AllowUserToAddRows = false;
			grd_Contact_Phone_Numbers.AllowUserToDeleteRows = false;
			grd_Contact_Phone_Numbers.AllowUserToResizeColumns = false;
			grd_Contact_Phone_Numbers.AllowUserToResizeColumns = grd_Contact_Phone_Numbers.ColumnHeadersVisible;
			grd_Contact_Phone_Numbers.AllowUserToResizeRows = false;
			grd_Contact_Phone_Numbers.AllowUserToResizeRows = false;
			grd_Contact_Phone_Numbers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grd_Contact_Phone_Numbers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_Contact_Phone_Numbers.ColumnsCount = 2;
			grd_Contact_Phone_Numbers.FixedColumns = 0;
			grd_Contact_Phone_Numbers.FixedRows = 1;
			grd_Contact_Phone_Numbers.FocusRect = UpgradeHelpers.FocusRectSettings.FocusNone;
			grd_Contact_Phone_Numbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			grd_Contact_Phone_Numbers.Location = new System.Drawing.Point(26, 288);
			grd_Contact_Phone_Numbers.Name = "grd_Contact_Phone_Numbers";
			grd_Contact_Phone_Numbers.ReadOnly = true;
			grd_Contact_Phone_Numbers.RowsCount = 2;
			grd_Contact_Phone_Numbers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grd_Contact_Phone_Numbers.ShowCellToolTips = false;
			grd_Contact_Phone_Numbers.Size = new System.Drawing.Size(497, 231);
			grd_Contact_Phone_Numbers.StandardTab = true;
			grd_Contact_Phone_Numbers.TabIndex = 14;
			grd_Contact_Phone_Numbers.Click += new System.EventHandler(grd_contact_phone_numbers_Click);
			grd_Contact_Phone_Numbers.DoubleClick += new System.EventHandler(grd_contact_phone_numbers_DoubleClick);
			grd_Contact_Phone_Numbers.MouseDown += new System.Windows.Forms.MouseEventHandler(grd_Contact_Phone_Numbers_MouseDown);
			// 
			// _lblCompanyContact_14
			// 
			_lblCompanyContact_14.AllowDrop = true;
			_lblCompanyContact_14.AutoSize = true;
			_lblCompanyContact_14.BackColor = System.Drawing.SystemColors.Control;
			_lblCompanyContact_14.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblCompanyContact_14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblCompanyContact_14.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblCompanyContact_14.Location = new System.Drawing.Point(72, 264);
			_lblCompanyContact_14.MinimumSize = new System.Drawing.Size(39, 13);
			_lblCompanyContact_14.Name = "_lblCompanyContact_14";
			_lblCompanyContact_14.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblCompanyContact_14.Size = new System.Drawing.Size(39, 13);
			_lblCompanyContact_14.TabIndex = 69;
			_lblCompanyContact_14.Text = "IQ Email";
			_lblCompanyContact_14.Click += new System.EventHandler(lblCompanyContact_Click);
			// 
			// _lblCompanyContact_13
			// 
			_lblCompanyContact_13.AllowDrop = true;
			_lblCompanyContact_13.AutoSize = true;
			_lblCompanyContact_13.BackColor = System.Drawing.SystemColors.Control;
			_lblCompanyContact_13.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblCompanyContact_13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblCompanyContact_13.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblCompanyContact_13.Location = new System.Drawing.Point(136, 736);
			_lblCompanyContact_13.MinimumSize = new System.Drawing.Size(106, 13);
			_lblCompanyContact_13.Name = "_lblCompanyContact_13";
			_lblCompanyContact_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblCompanyContact_13.Size = new System.Drawing.Size(106, 13);
			_lblCompanyContact_13.TabIndex = 65;
			_lblCompanyContact_13.Text = "Replacement Contact:";
			_lblCompanyContact_13.Visible = false;
			_lblCompanyContact_13.Click += new System.EventHandler(lblCompanyContact_Click);
			// 
			// _lblCompanyContact_12
			// 
			_lblCompanyContact_12.AllowDrop = true;
			_lblCompanyContact_12.AutoSize = true;
			_lblCompanyContact_12.BackColor = System.Drawing.SystemColors.Control;
			_lblCompanyContact_12.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblCompanyContact_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblCompanyContact_12.ForeColor = System.Drawing.Color.Black;
			_lblCompanyContact_12.Location = new System.Drawing.Point(5, 244);
			_lblCompanyContact_12.MinimumSize = new System.Drawing.Size(80, 13);
			_lblCompanyContact_12.Name = "_lblCompanyContact_12";
			_lblCompanyContact_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblCompanyContact_12.Size = new System.Drawing.Size(80, 13);
			_lblCompanyContact_12.TabIndex = 63;
			_lblCompanyContact_12.Text = "Research E-mail:";
			_lblCompanyContact_12.Click += new System.EventHandler(lblCompanyContact_Click);
			// 
			// lblTransmitContactRecord
			// 
			lblTransmitContactRecord.AllowDrop = true;
			lblTransmitContactRecord.BackColor = System.Drawing.SystemColors.Control;
			lblTransmitContactRecord.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblTransmitContactRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblTransmitContactRecord.ForeColor = System.Drawing.Color.Blue;
			lblTransmitContactRecord.Location = new System.Drawing.Point(206, 698);
			lblTransmitContactRecord.MinimumSize = new System.Drawing.Size(149, 13);
			lblTransmitContactRecord.Name = "lblTransmitContactRecord";
			lblTransmitContactRecord.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblTransmitContactRecord.Size = new System.Drawing.Size(149, 13);
			lblTransmitContactRecord.TabIndex = 62;
			lblTransmitContactRecord.Text = "Transmit Contact Record";
			lblTransmitContactRecord.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			lblTransmitContactRecord.Click += new System.EventHandler(lblTransmitContactRecord_Click);
			// 
			// lblContactRelationships
			// 
			lblContactRelationships.AllowDrop = true;
			lblContactRelationships.BackColor = System.Drawing.SystemColors.Control;
			lblContactRelationships.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblContactRelationships.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblContactRelationships.ForeColor = System.Drawing.Color.Blue;
			lblContactRelationships.Location = new System.Drawing.Point(408, 28);
			lblContactRelationships.MinimumSize = new System.Drawing.Size(135, 15);
			lblContactRelationships.Name = "lblContactRelationships";
			lblContactRelationships.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblContactRelationships.Size = new System.Drawing.Size(135, 15);
			lblContactRelationships.TabIndex = 61;
			lblContactRelationships.Text = "Contact Relationships";
			lblContactRelationships.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			lblContactRelationships.Visible = false;
			// 
			// lblChanges
			// 
			lblChanges.AllowDrop = true;
			lblChanges.BackColor = System.Drawing.SystemColors.Control;
			lblChanges.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lblChanges.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblChanges.ForeColor = System.Drawing.Color.Red;
			lblChanges.Location = new System.Drawing.Point(24, 660);
			lblChanges.MinimumSize = new System.Drawing.Size(497, 17);
			lblChanges.Name = "lblChanges";
			lblChanges.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblChanges.Size = new System.Drawing.Size(497, 17);
			lblChanges.TabIndex = 52;
			lblChanges.Text = "Changed Items :";
			lblChanges.Visible = false;
			// 
			// _lblTitleGroup_12
			// 
			_lblTitleGroup_12.AllowDrop = true;
			_lblTitleGroup_12.AutoSize = true;
			_lblTitleGroup_12.BackColor = System.Drawing.SystemColors.Control;
			_lblTitleGroup_12.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblTitleGroup_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblTitleGroup_12.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblTitleGroup_12.Location = new System.Drawing.Point(24, 56);
			_lblTitleGroup_12.MinimumSize = new System.Drawing.Size(55, 11);
			_lblTitleGroup_12.Name = "_lblTitleGroup_12";
			_lblTitleGroup_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblTitleGroup_12.Size = new System.Drawing.Size(55, 11);
			_lblTitleGroup_12.TabIndex = 51;
			_lblTitleGroup_12.Text = "Title Group:";
			// 
			// _lblCompanyContact_11
			// 
			_lblCompanyContact_11.AllowDrop = true;
			_lblCompanyContact_11.BackColor = System.Drawing.SystemColors.Control;
			_lblCompanyContact_11.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblCompanyContact_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblCompanyContact_11.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblCompanyContact_11.Location = new System.Drawing.Point(25, 145);
			_lblCompanyContact_11.MinimumSize = new System.Drawing.Size(24, 26);
			_lblCompanyContact_11.Name = "_lblCompanyContact_11";
			_lblCompanyContact_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblCompanyContact_11.Size = new System.Drawing.Size(24, 26);
			_lblCompanyContact_11.TabIndex = 50;
			_lblCompanyContact_11.Text = "Seq No";
			_lblCompanyContact_11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lblCompanyContact_11.Click += new System.EventHandler(lblCompanyContact_Click);
			// 
			// _lblCompanyContact_10
			// 
			_lblCompanyContact_10.AllowDrop = true;
			_lblCompanyContact_10.AutoSize = true;
			_lblCompanyContact_10.BackColor = System.Drawing.SystemColors.Control;
			_lblCompanyContact_10.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblCompanyContact_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblCompanyContact_10.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblCompanyContact_10.Location = new System.Drawing.Point(110, 615);
			_lblCompanyContact_10.MinimumSize = new System.Drawing.Size(53, 13);
			_lblCompanyContact_10.Name = "_lblCompanyContact_10";
			_lblCompanyContact_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblCompanyContact_10.Size = new System.Drawing.Size(53, 13);
			_lblCompanyContact_10.TabIndex = 49;
			_lblCompanyContact_10.Text = "Entry Date:";
			_lblCompanyContact_10.Click += new System.EventHandler(lblCompanyContact_Click);
			// 
			// _lblCompanyContact_9
			// 
			_lblCompanyContact_9.AllowDrop = true;
			_lblCompanyContact_9.AutoSize = true;
			_lblCompanyContact_9.BackColor = System.Drawing.SystemColors.Control;
			_lblCompanyContact_9.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblCompanyContact_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblCompanyContact_9.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblCompanyContact_9.Location = new System.Drawing.Point(266, 615);
			_lblCompanyContact_9.MinimumSize = new System.Drawing.Size(64, 13);
			_lblCompanyContact_9.Name = "_lblCompanyContact_9";
			_lblCompanyContact_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblCompanyContact_9.Size = new System.Drawing.Size(64, 13);
			_lblCompanyContact_9.TabIndex = 48;
			_lblCompanyContact_9.Text = "Update Date:";
			_lblCompanyContact_9.Click += new System.EventHandler(lblCompanyContact_Click);
			// 
			// lbl_contact_entry_date
			// 
			lbl_contact_entry_date.AllowDrop = true;
			lbl_contact_entry_date.AutoSize = true;
			lbl_contact_entry_date.BackColor = System.Drawing.SystemColors.Control;
			lbl_contact_entry_date.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_contact_entry_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_contact_entry_date.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_contact_entry_date.Location = new System.Drawing.Point(175, 615);
			lbl_contact_entry_date.MinimumSize = new System.Drawing.Size(70, 13);
			lbl_contact_entry_date.Name = "lbl_contact_entry_date";
			lbl_contact_entry_date.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_contact_entry_date.Size = new System.Drawing.Size(70, 13);
			lbl_contact_entry_date.TabIndex = 47;
			lbl_contact_entry_date.Text = "                    ";
			// 
			// lbl_contact_update_date
			// 
			lbl_contact_update_date.AllowDrop = true;
			lbl_contact_update_date.AutoSize = true;
			lbl_contact_update_date.BackColor = System.Drawing.SystemColors.Control;
			lbl_contact_update_date.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_contact_update_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_contact_update_date.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_contact_update_date.Location = new System.Drawing.Point(338, 615);
			lbl_contact_update_date.MinimumSize = new System.Drawing.Size(101, 13);
			lbl_contact_update_date.Name = "lbl_contact_update_date";
			lbl_contact_update_date.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_contact_update_date.Size = new System.Drawing.Size(101, 13);
			lbl_contact_update_date.TabIndex = 46;
			lbl_contact_update_date.Text = "                    ";
			// 
			// lblLockedBy
			// 
			lblLockedBy.AllowDrop = true;
			lblLockedBy.BackColor = System.Drawing.SystemColors.Control;
			lblLockedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lblLockedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblLockedBy.ForeColor = System.Drawing.Color.Blue;
			lblLockedBy.Location = new System.Drawing.Point(24, 679);
			lblLockedBy.MinimumSize = new System.Drawing.Size(497, 17);
			lblLockedBy.Name = "lblLockedBy";
			lblLockedBy.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblLockedBy.Size = new System.Drawing.Size(497, 17);
			lblLockedBy.TabIndex = 44;
			lblLockedBy.Text = "Locked By :";
			lblLockedBy.Visible = false;
			// 
			// _lblCompanyContact_7
			// 
			_lblCompanyContact_7.AllowDrop = true;
			_lblCompanyContact_7.AutoSize = true;
			_lblCompanyContact_7.BackColor = System.Drawing.SystemColors.Control;
			_lblCompanyContact_7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblCompanyContact_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblCompanyContact_7.ForeColor = System.Drawing.Color.Black;
			_lblCompanyContact_7.Location = new System.Drawing.Point(54, 204);
			_lblCompanyContact_7.MinimumSize = new System.Drawing.Size(31, 13);
			_lblCompanyContact_7.Name = "_lblCompanyContact_7";
			_lblCompanyContact_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblCompanyContact_7.Size = new System.Drawing.Size(31, 13);
			_lblCompanyContact_7.TabIndex = 43;
			_lblCompanyContact_7.Text = "E-mail:";
			_lblCompanyContact_7.Click += new System.EventHandler(lblCompanyContact_Click);
			// 
			// _lblCompanyContact_6
			// 
			_lblCompanyContact_6.AllowDrop = true;
			_lblCompanyContact_6.AutoSize = true;
			_lblCompanyContact_6.BackColor = System.Drawing.SystemColors.Control;
			_lblCompanyContact_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblCompanyContact_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblCompanyContact_6.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblCompanyContact_6.Location = new System.Drawing.Point(463, 156);
			_lblCompanyContact_6.MinimumSize = new System.Drawing.Size(29, 13);
			_lblCompanyContact_6.Name = "_lblCompanyContact_6";
			_lblCompanyContact_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblCompanyContact_6.Size = new System.Drawing.Size(29, 13);
			_lblCompanyContact_6.TabIndex = 42;
			_lblCompanyContact_6.Text = "Suffix:";
			_lblCompanyContact_6.Click += new System.EventHandler(lblCompanyContact_Click);
			// 
			// _lblCompanyContact_5
			// 
			_lblCompanyContact_5.AllowDrop = true;
			_lblCompanyContact_5.AutoSize = true;
			_lblCompanyContact_5.BackColor = System.Drawing.SystemColors.Control;
			_lblCompanyContact_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblCompanyContact_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblCompanyContact_5.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblCompanyContact_5.Location = new System.Drawing.Point(345, 156);
			_lblCompanyContact_5.MinimumSize = new System.Drawing.Size(23, 13);
			_lblCompanyContact_5.Name = "_lblCompanyContact_5";
			_lblCompanyContact_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblCompanyContact_5.Size = new System.Drawing.Size(23, 13);
			_lblCompanyContact_5.TabIndex = 41;
			_lblCompanyContact_5.Text = "Last:";
			_lblCompanyContact_5.Click += new System.EventHandler(lblCompanyContact_Click);
			// 
			// _lblCompanyContact_4
			// 
			_lblCompanyContact_4.AllowDrop = true;
			_lblCompanyContact_4.AutoSize = true;
			_lblCompanyContact_4.BackColor = System.Drawing.SystemColors.Control;
			_lblCompanyContact_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblCompanyContact_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblCompanyContact_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblCompanyContact_4.Location = new System.Drawing.Point(263, 156);
			_lblCompanyContact_4.MinimumSize = new System.Drawing.Size(12, 13);
			_lblCompanyContact_4.Name = "_lblCompanyContact_4";
			_lblCompanyContact_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblCompanyContact_4.Size = new System.Drawing.Size(12, 13);
			_lblCompanyContact_4.TabIndex = 40;
			_lblCompanyContact_4.Text = "M.";
			_lblCompanyContact_4.Click += new System.EventHandler(lblCompanyContact_Click);
			// 
			// _lblCompanyContact_3
			// 
			_lblCompanyContact_3.AllowDrop = true;
			_lblCompanyContact_3.AutoSize = true;
			_lblCompanyContact_3.BackColor = System.Drawing.SystemColors.Control;
			_lblCompanyContact_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblCompanyContact_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblCompanyContact_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblCompanyContact_3.Location = new System.Drawing.Point(195, 156);
			_lblCompanyContact_3.MinimumSize = new System.Drawing.Size(22, 13);
			_lblCompanyContact_3.Name = "_lblCompanyContact_3";
			_lblCompanyContact_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblCompanyContact_3.Size = new System.Drawing.Size(22, 13);
			_lblCompanyContact_3.TabIndex = 39;
			_lblCompanyContact_3.Text = "First:";
			_lblCompanyContact_3.Click += new System.EventHandler(lblCompanyContact_Click);
			// 
			// _lblCompanyContact_8
			// 
			_lblCompanyContact_8.AllowDrop = true;
			_lblCompanyContact_8.AutoSize = true;
			_lblCompanyContact_8.BackColor = System.Drawing.SystemColors.Control;
			_lblCompanyContact_8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblCompanyContact_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblCompanyContact_8.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblCompanyContact_8.Location = new System.Drawing.Point(24, 544);
			_lblCompanyContact_8.MinimumSize = new System.Drawing.Size(56, 13);
			_lblCompanyContact_8.Name = "_lblCompanyContact_8";
			_lblCompanyContact_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblCompanyContact_8.Size = new System.Drawing.Size(56, 13);
			_lblCompanyContact_8.TabIndex = 38;
			_lblCompanyContact_8.Text = "Description:";
			_lblCompanyContact_8.Click += new System.EventHandler(lblCompanyContact_Click);
			// 
			// _lblCompanyContact_2
			// 
			_lblCompanyContact_2.AllowDrop = true;
			_lblCompanyContact_2.AutoSize = true;
			_lblCompanyContact_2.BackColor = System.Drawing.SystemColors.Control;
			_lblCompanyContact_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblCompanyContact_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblCompanyContact_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblCompanyContact_2.Location = new System.Drawing.Point(88, 156);
			_lblCompanyContact_2.MinimumSize = new System.Drawing.Size(29, 13);
			_lblCompanyContact_2.Name = "_lblCompanyContact_2";
			_lblCompanyContact_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblCompanyContact_2.Size = new System.Drawing.Size(29, 13);
			_lblCompanyContact_2.TabIndex = 37;
			_lblCompanyContact_2.Text = "Prefix:";
			_lblCompanyContact_2.Click += new System.EventHandler(lblCompanyContact_Click);
			// 
			// _lblCompanyContact_1
			// 
			_lblCompanyContact_1.AllowDrop = true;
			_lblCompanyContact_1.AutoSize = true;
			_lblCompanyContact_1.BackColor = System.Drawing.SystemColors.Control;
			_lblCompanyContact_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblCompanyContact_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblCompanyContact_1.ForeColor = System.Drawing.Color.Black;
			_lblCompanyContact_1.Location = new System.Drawing.Point(210, 96);
			_lblCompanyContact_1.MinimumSize = new System.Drawing.Size(23, 13);
			_lblCompanyContact_1.Name = "_lblCompanyContact_1";
			_lblCompanyContact_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblCompanyContact_1.Size = new System.Drawing.Size(23, 13);
			_lblCompanyContact_1.TabIndex = 36;
			_lblCompanyContact_1.Text = "Title:";
			_lblCompanyContact_1.Click += new System.EventHandler(lblCompanyContact_Click);
			// 
			// _lblCompanyContact_0
			// 
			_lblCompanyContact_0.AllowDrop = true;
			_lblCompanyContact_0.AutoSize = true;
			_lblCompanyContact_0.BackColor = System.Drawing.Color.Transparent;
			_lblCompanyContact_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblCompanyContact_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblCompanyContact_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblCompanyContact_0.Location = new System.Drawing.Point(24, 33);
			_lblCompanyContact_0.MinimumSize = new System.Drawing.Size(21, 13);
			_lblCompanyContact_0.Name = "_lblCompanyContact_0";
			_lblCompanyContact_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblCompanyContact_0.Size = new System.Drawing.Size(21, 13);
			_lblCompanyContact_0.TabIndex = 35;
			_lblCompanyContact_0.Text = "ID#:";
			_lblCompanyContact_0.Click += new System.EventHandler(lblCompanyContact_Click);
			// 
			// frm_CompanyContact
			// 
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			ClientSize = new System.Drawing.Size(549, 787);
			Controls.Add(chk_hidden_comp);
			Controls.Add(chk_contact_do_not_solicit);
			Controls.Add(chk_iq_auto);
			Controls.Add(txt_iq_email);
			Controls.Add(cmd_add_new_contact);
			Controls.Add(txt_contact_email_address);
			Controls.Add(cbo_replacement_contact);
			Controls.Add(txt_contact_research_email_address);
			Controls.Add(chkContactDoNotSendJNiQSurvey);
			Controls.Add(chkContactDoNotSendEMail);
			Controls.Add(cmdFindContactMatch);
			Controls.Add(cmd_add_contact_phone);
			Controls.Add(pnl_Contact_Phone);
			Controls.Add(pnl_update_Message);
			Controls.Add(cmdDelete);
			Controls.Add(lstTitleGroup);
			Controls.Add(cmdViewBadContactEmails);
			Controls.Add(txt_contact_acpros_seq_no);
			Controls.Add(chk_HideFromCustomer);
			Controls.Add(cmd_delete_contact_Phone);
			Controls.Add(cmd_confirm_contact_Phone);
			Controls.Add(cmd_Save_Contact);
			Controls.Add(txt_contact_description);
			Controls.Add(cmd_Confirm_Contact);
			Controls.Add(cmd_Subscription);
			Controls.Add(cmd_Close);
			Controls.Add(cbo_contact_suffix);
			Controls.Add(txt_contact_last_name);
			Controls.Add(txt_contact_middle_initial);
			Controls.Add(txt_contact_first_name);
			Controls.Add(cbo_contact_sirname);
			Controls.Add(chk_contact_research_flag);
			Controls.Add(chk_contact_active_flag);
			Controls.Add(cbo_contact_title);
			Controls.Add(txt_contact_id);
			Controls.Add(grd_Contact_Phone_Numbers);
			Controls.Add(_lblCompanyContact_14);
			Controls.Add(_lblCompanyContact_13);
			Controls.Add(_lblCompanyContact_12);
			Controls.Add(lblTransmitContactRecord);
			Controls.Add(lblContactRelationships);
			Controls.Add(lblChanges);
			Controls.Add(_lblTitleGroup_12);
			Controls.Add(_lblCompanyContact_11);
			Controls.Add(_lblCompanyContact_10);
			Controls.Add(_lblCompanyContact_9);
			Controls.Add(lbl_contact_entry_date);
			Controls.Add(lbl_contact_update_date);
			Controls.Add(lblLockedBy);
			Controls.Add(_lblCompanyContact_7);
			Controls.Add(_lblCompanyContact_6);
			Controls.Add(_lblCompanyContact_5);
			Controls.Add(_lblCompanyContact_4);
			Controls.Add(_lblCompanyContact_3);
			Controls.Add(_lblCompanyContact_8);
			Controls.Add(_lblCompanyContact_2);
			Controls.Add(_lblCompanyContact_1);
			Controls.Add(_lblCompanyContact_0);
			Controls.Add(MainMenu1);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			Location = new System.Drawing.Point(653, 200);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "frm_CompanyContact";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			Text = "Company Contact";
			commandButtonHelper1.SetStyle(cmd_add_new_contact, 0);
			commandButtonHelper1.SetStyle(cmdFindContactMatch, 0);
			commandButtonHelper1.SetStyle(cmd_add_contact_phone, 0);
			commandButtonHelper1.SetStyle(cmd_save_contact_phone, 0);
			commandButtonHelper1.SetStyle(cmd_cancel_contact_phone, 0);
			commandButtonHelper1.SetStyle(cmdDelete, 0);
			commandButtonHelper1.SetStyle(cmdViewBadContactEmails, 0);
			commandButtonHelper1.SetStyle(cmd_delete_contact_Phone, 0);
			commandButtonHelper1.SetStyle(cmd_confirm_contact_Phone, 0);
			commandButtonHelper1.SetStyle(cmd_Save_Contact, 0);
			commandButtonHelper1.SetStyle(cmd_Confirm_Contact, 0);
			commandButtonHelper1.SetStyle(cmd_Subscription, 0);
			commandButtonHelper1.SetStyle(cmd_Close, 0);
			listBoxHelper1.SetSelectionMode(lstTitleGroup, System.Windows.Forms.SelectionMode.MultiExtended);
			ToolTipMain.SetToolTip(chkContactDoNotSendJNiQSurvey, "When checked this Contact's email is on JETNET's Do Not Send List");
			ToolTipMain.SetToolTip(chkContactDoNotSendEMail, "When checked this Contact's email is on JETNET's Do Not Send List");
			ToolTipMain.SetToolTip(cmdFindContactMatch, "Click To Find Contact Match");
			ToolTipMain.SetToolTip(lblTransmitContactRecord, "Transmit This Contact Record To Evolution");
			Activated += new System.EventHandler(Form_Activated);
			Closed += new System.EventHandler(Form_Closed);
			FormClosing += new System.Windows.Forms.FormClosingEventHandler(Form_FormClosing);
			((System.ComponentModel.ISupportInitialize) grd_Contact_Phone_Numbers).EndInit();
			pnl_Contact_Phone.ResumeLayout(false);
			pnl_Contact_Phone.PerformLayout();
			pnl_update_Message.ResumeLayout(false);
			pnl_update_Message.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
		void ReLoadForm(bool addEvents)
		{
			Initializelbl_comp();
			InitializelblTitleGroup();
			InitializelblCompanyContact();
			Form_Initialize();
		}
		void Initializelbl_comp()
		{
			lbl_comp = new System.Windows.Forms.Label[54];
			lbl_comp[0] = _lbl_comp_0;
			lbl_comp[53] = _lbl_comp_53;
			lbl_comp[25] = _lbl_comp_25;
			lbl_comp[52] = _lbl_comp_52;
			lbl_comp[24] = _lbl_comp_24;
			lbl_comp[45] = _lbl_comp_45;
			lbl_comp[40] = _lbl_comp_40;
		}
		void InitializelblTitleGroup()
		{
			lblTitleGroup = new System.Windows.Forms.Label[13];
			lblTitleGroup[12] = _lblTitleGroup_12;
		}
		void InitializelblCompanyContact()
		{
			lblCompanyContact = new System.Windows.Forms.Label[15];
			lblCompanyContact[14] = _lblCompanyContact_14;
			lblCompanyContact[13] = _lblCompanyContact_13;
			lblCompanyContact[12] = _lblCompanyContact_12;
			lblCompanyContact[11] = _lblCompanyContact_11;
			lblCompanyContact[10] = _lblCompanyContact_10;
			lblCompanyContact[9] = _lblCompanyContact_9;
			lblCompanyContact[7] = _lblCompanyContact_7;
			lblCompanyContact[6] = _lblCompanyContact_6;
			lblCompanyContact[5] = _lblCompanyContact_5;
			lblCompanyContact[4] = _lblCompanyContact_4;
			lblCompanyContact[3] = _lblCompanyContact_3;
			lblCompanyContact[8] = _lblCompanyContact_8;
			lblCompanyContact[2] = _lblCompanyContact_2;
			lblCompanyContact[1] = _lblCompanyContact_1;
			lblCompanyContact[0] = _lblCompanyContact_0;
		}
		#endregion
	}
}