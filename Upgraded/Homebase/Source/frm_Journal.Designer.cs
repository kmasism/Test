
namespace JETNET_Homebase
{
	partial class frm_Journal
	{

		#region "Upgrade Support "
		private static frm_Journal m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_Journal DefInstance
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
		public static frm_Journal CreateInstance()
		{
			frm_Journal theInstance = new frm_Journal();
			theInstance.Form_Load();
			return theInstance;
		}
		private string[] visualControls = new string[]{"components", "ToolTipMain", "cbo_comp_info", "lst_comp_info", "pnl_Company", "cbo_contact_info", "lst_contact_info", "pnl_Contact", "lst_aircraft", "lst_aircraft_info", "pnl_Aircraft", "cmdCancelAddContact", "cmdSaveAddContact", "txt_cont_first_name", "txt_cont_last_name", "txt_cont_middle_initial", "cboNewContactTitle", "txt_contact_email_address", "cbo_contact_sirname", "cbo_contact_suffix", "_lbl_Journal_6", "_lbl_Journal_7", "_lbl_Journal_8", "_lbl_Journal_9", "lbl_contact_email", "lbl_Prefix", "lbl_contact_name", "pnl_AddContact", "cbo_journ_cat", "cbp_journ_sub_type", "chkAskedForSoldPrice", "chkAskedForSoldPriceRefused", "txt_journ_customer_note", "_radio_id_2", "_radio_id_1", "_radio_id_0", "txt_User", "txt_pcreckey", "txt_journ_prior_account_id", "txt_journ_account_id", "txt_journ_entry_time", "txt_journ_entry_date", "txt_journ_id", "lbl_User", "_lbl_Journal_10", "lbl_prioracctid", "lbl_acctid", "lbl_date_time", "_lbl_Journal_0", "pnl_Journal_Heading", "txt_journ_description", "grdTransactionDocuments", "chk_journ_internal_trans_flag", "cmd_Change_Trans_Type", "chk_New_to_Market", "cmdDelete", "cmdDocuments", "txt_journ_subcategory_code", "cmd_Cancel", "cmd_Save", "txt_journ_subject", "txt_category", "txt_journ_date", "cboDocumentType", "cboNewSubcategoryCode", "_lbl_Journal_5", "lblSubCategoryCode", "_lbl_Journal_3", "_lbl_Journal_4", "_lbl_Journal_2", "_lbl_Journal_1", "pnl_Journal_Data", "cmd_MajorChange", "chk_ApplytoCurrent", "txt_Current_Seller_Percent", "txt_Current_Purchaser_Percent", "Label7", "Label6", "Label5", "frame_Current", "txt_Purchaser_Percent", "Line5", "Line4", "Label1", "Label2", "lbl_Seller_Name", "lbl_Purchaser_Name", "Line1", "Line2", "Line3", "frame_BuyerSeller", "cmd_Major_Cancel", "cbo_New_TransType", "Label4", "lbl_Current_TransType", "Label3", "frame_MajorChange", "lbl_Journal", "radio_id", "optionButtonHelper1", "commandButtonHelper1", "listBoxHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.ComboBox cbo_comp_info;
		public System.Windows.Forms.ListBox lst_comp_info;
		public System.Windows.Forms.Panel pnl_Company;
		public System.Windows.Forms.ComboBox cbo_contact_info;
		public System.Windows.Forms.ListBox lst_contact_info;
		public System.Windows.Forms.Panel pnl_Contact;
		public System.Windows.Forms.ComboBox lst_aircraft;
		public System.Windows.Forms.ListBox lst_aircraft_info;
		public System.Windows.Forms.Panel pnl_Aircraft;
		public System.Windows.Forms.Button cmdCancelAddContact;
		public System.Windows.Forms.Button cmdSaveAddContact;
		public System.Windows.Forms.TextBox txt_cont_first_name;
		public System.Windows.Forms.TextBox txt_cont_last_name;
		public System.Windows.Forms.TextBox txt_cont_middle_initial;
		public System.Windows.Forms.ComboBox cboNewContactTitle;
		public System.Windows.Forms.TextBox txt_contact_email_address;
		public System.Windows.Forms.ComboBox cbo_contact_sirname;
		public System.Windows.Forms.ComboBox cbo_contact_suffix;
		private System.Windows.Forms.Label _lbl_Journal_6;
		private System.Windows.Forms.Label _lbl_Journal_7;
		private System.Windows.Forms.Label _lbl_Journal_8;
		private System.Windows.Forms.Label _lbl_Journal_9;
		public System.Windows.Forms.Label lbl_contact_email;
		public System.Windows.Forms.Label lbl_Prefix;
		public System.Windows.Forms.Label lbl_contact_name;
		public System.Windows.Forms.Panel pnl_AddContact;
		public System.Windows.Forms.ComboBox cbo_journ_cat;
		public System.Windows.Forms.ComboBox cbp_journ_sub_type;
		public System.Windows.Forms.CheckBox chkAskedForSoldPrice;
		public System.Windows.Forms.CheckBox chkAskedForSoldPriceRefused;
		public System.Windows.Forms.TextBox txt_journ_customer_note;
		private System.Windows.Forms.RadioButton _radio_id_2;
		private System.Windows.Forms.RadioButton _radio_id_1;
		private System.Windows.Forms.RadioButton _radio_id_0;
		public System.Windows.Forms.TextBox txt_User;
		public System.Windows.Forms.TextBox txt_pcreckey;
		public System.Windows.Forms.TextBox txt_journ_prior_account_id;
		public System.Windows.Forms.TextBox txt_journ_account_id;
		public System.Windows.Forms.TextBox txt_journ_entry_time;
		public System.Windows.Forms.TextBox txt_journ_entry_date;
		public System.Windows.Forms.TextBox txt_journ_id;
		public System.Windows.Forms.Label lbl_User;
		private System.Windows.Forms.Label _lbl_Journal_10;
		public System.Windows.Forms.Label lbl_prioracctid;
		public System.Windows.Forms.Label lbl_acctid;
		public System.Windows.Forms.Label lbl_date_time;
		private System.Windows.Forms.Label _lbl_Journal_0;
		public System.Windows.Forms.Panel pnl_Journal_Heading;
		public System.Windows.Forms.TextBox txt_journ_description;
		public UpgradeHelpers.DataGridViewFlex grdTransactionDocuments;
		public System.Windows.Forms.CheckBox chk_journ_internal_trans_flag;
		public System.Windows.Forms.Button cmd_Change_Trans_Type;
		public System.Windows.Forms.CheckBox chk_New_to_Market;
		public System.Windows.Forms.Button cmdDelete;
		public System.Windows.Forms.Button cmdDocuments;
		public System.Windows.Forms.TextBox txt_journ_subcategory_code;
		public System.Windows.Forms.Button cmd_Cancel;
		public System.Windows.Forms.Button cmd_Save;
		public System.Windows.Forms.TextBox txt_journ_subject;
		public System.Windows.Forms.TextBox txt_category;
		public System.Windows.Forms.TextBox txt_journ_date;
		public System.Windows.Forms.ComboBox cboDocumentType;
		public System.Windows.Forms.ComboBox cboNewSubcategoryCode;
		private System.Windows.Forms.Label _lbl_Journal_5;
		public System.Windows.Forms.Label lblSubCategoryCode;
		private System.Windows.Forms.Label _lbl_Journal_3;
		private System.Windows.Forms.Label _lbl_Journal_4;
		private System.Windows.Forms.Label _lbl_Journal_2;
		private System.Windows.Forms.Label _lbl_Journal_1;
		public System.Windows.Forms.Panel pnl_Journal_Data;
		public System.Windows.Forms.Button cmd_MajorChange;
		public System.Windows.Forms.CheckBox chk_ApplytoCurrent;
		public System.Windows.Forms.TextBox txt_Current_Seller_Percent;
		public System.Windows.Forms.TextBox txt_Current_Purchaser_Percent;
		public System.Windows.Forms.Label Label7;
		public System.Windows.Forms.Label Label6;
		public System.Windows.Forms.Label Label5;
		public System.Windows.Forms.GroupBox frame_Current;
		public System.Windows.Forms.TextBox txt_Purchaser_Percent;
		public System.Windows.Forms.Label Line5;
		public System.Windows.Forms.Label Line4;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label lbl_Seller_Name;
		public System.Windows.Forms.Label lbl_Purchaser_Name;
		public System.Windows.Forms.Label Line1;
		public System.Windows.Forms.Label Line2;
		public System.Windows.Forms.Label Line3;
		public System.Windows.Forms.GroupBox frame_BuyerSeller;
		public System.Windows.Forms.Button cmd_Major_Cancel;
		public System.Windows.Forms.ComboBox cbo_New_TransType;
		public System.Windows.Forms.Label Label4;
		public System.Windows.Forms.Label lbl_Current_TransType;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.GroupBox frame_MajorChange;
		public System.Windows.Forms.Label[] lbl_Journal = new System.Windows.Forms.Label[11];
		public System.Windows.Forms.RadioButton[] radio_id = new System.Windows.Forms.RadioButton[3];
		public UpgradeHelpers.Gui.Controls.OptionButtonHelper optionButtonHelper1;
		public UpgradeHelpers.Gui.Controls.CommandButtonHelper commandButtonHelper1;
		public UpgradeHelpers.Gui.Controls.ListBoxHelper listBoxHelper1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Journal));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			pnl_Company = new System.Windows.Forms.Panel();
			cbo_comp_info = new System.Windows.Forms.ComboBox();
			lst_comp_info = new System.Windows.Forms.ListBox();
			pnl_Contact = new System.Windows.Forms.Panel();
			cbo_contact_info = new System.Windows.Forms.ComboBox();
			lst_contact_info = new System.Windows.Forms.ListBox();
			pnl_Aircraft = new System.Windows.Forms.Panel();
			lst_aircraft = new System.Windows.Forms.ComboBox();
			lst_aircraft_info = new System.Windows.Forms.ListBox();
			pnl_AddContact = new System.Windows.Forms.Panel();
			cmdCancelAddContact = new System.Windows.Forms.Button();
			cmdSaveAddContact = new System.Windows.Forms.Button();
			txt_cont_first_name = new System.Windows.Forms.TextBox();
			txt_cont_last_name = new System.Windows.Forms.TextBox();
			txt_cont_middle_initial = new System.Windows.Forms.TextBox();
			cboNewContactTitle = new System.Windows.Forms.ComboBox();
			txt_contact_email_address = new System.Windows.Forms.TextBox();
			cbo_contact_sirname = new System.Windows.Forms.ComboBox();
			cbo_contact_suffix = new System.Windows.Forms.ComboBox();
			_lbl_Journal_6 = new System.Windows.Forms.Label();
			_lbl_Journal_7 = new System.Windows.Forms.Label();
			_lbl_Journal_8 = new System.Windows.Forms.Label();
			_lbl_Journal_9 = new System.Windows.Forms.Label();
			lbl_contact_email = new System.Windows.Forms.Label();
			lbl_Prefix = new System.Windows.Forms.Label();
			lbl_contact_name = new System.Windows.Forms.Label();
			pnl_Journal_Data = new System.Windows.Forms.Panel();
			cbo_journ_cat = new System.Windows.Forms.ComboBox();
			cbp_journ_sub_type = new System.Windows.Forms.ComboBox();
			chkAskedForSoldPrice = new System.Windows.Forms.CheckBox();
			chkAskedForSoldPriceRefused = new System.Windows.Forms.CheckBox();
			txt_journ_customer_note = new System.Windows.Forms.TextBox();
			_radio_id_2 = new System.Windows.Forms.RadioButton();
			_radio_id_1 = new System.Windows.Forms.RadioButton();
			_radio_id_0 = new System.Windows.Forms.RadioButton();
			pnl_Journal_Heading = new System.Windows.Forms.Panel();
			txt_User = new System.Windows.Forms.TextBox();
			txt_pcreckey = new System.Windows.Forms.TextBox();
			txt_journ_prior_account_id = new System.Windows.Forms.TextBox();
			txt_journ_account_id = new System.Windows.Forms.TextBox();
			txt_journ_entry_time = new System.Windows.Forms.TextBox();
			txt_journ_entry_date = new System.Windows.Forms.TextBox();
			txt_journ_id = new System.Windows.Forms.TextBox();
			lbl_User = new System.Windows.Forms.Label();
			_lbl_Journal_10 = new System.Windows.Forms.Label();
			lbl_prioracctid = new System.Windows.Forms.Label();
			lbl_acctid = new System.Windows.Forms.Label();
			lbl_date_time = new System.Windows.Forms.Label();
			_lbl_Journal_0 = new System.Windows.Forms.Label();
			txt_journ_description = new System.Windows.Forms.TextBox();
			grdTransactionDocuments = new UpgradeHelpers.DataGridViewFlex(components);
			chk_journ_internal_trans_flag = new System.Windows.Forms.CheckBox();
			cmd_Change_Trans_Type = new System.Windows.Forms.Button();
			chk_New_to_Market = new System.Windows.Forms.CheckBox();
			cmdDelete = new System.Windows.Forms.Button();
			cmdDocuments = new System.Windows.Forms.Button();
			txt_journ_subcategory_code = new System.Windows.Forms.TextBox();
			cmd_Cancel = new System.Windows.Forms.Button();
			cmd_Save = new System.Windows.Forms.Button();
			txt_journ_subject = new System.Windows.Forms.TextBox();
			txt_category = new System.Windows.Forms.TextBox();
			txt_journ_date = new System.Windows.Forms.TextBox();
			cboDocumentType = new System.Windows.Forms.ComboBox();
			cboNewSubcategoryCode = new System.Windows.Forms.ComboBox();
			_lbl_Journal_5 = new System.Windows.Forms.Label();
			lblSubCategoryCode = new System.Windows.Forms.Label();
			_lbl_Journal_3 = new System.Windows.Forms.Label();
			_lbl_Journal_4 = new System.Windows.Forms.Label();
			_lbl_Journal_2 = new System.Windows.Forms.Label();
			_lbl_Journal_1 = new System.Windows.Forms.Label();
			frame_MajorChange = new System.Windows.Forms.GroupBox();
			cmd_MajorChange = new System.Windows.Forms.Button();
			frame_BuyerSeller = new System.Windows.Forms.GroupBox();
			frame_Current = new System.Windows.Forms.GroupBox();
			chk_ApplytoCurrent = new System.Windows.Forms.CheckBox();
			txt_Current_Seller_Percent = new System.Windows.Forms.TextBox();
			txt_Current_Purchaser_Percent = new System.Windows.Forms.TextBox();
			Label7 = new System.Windows.Forms.Label();
			Label6 = new System.Windows.Forms.Label();
			Label5 = new System.Windows.Forms.Label();
			txt_Purchaser_Percent = new System.Windows.Forms.TextBox();
			Line5 = new System.Windows.Forms.Label();
			Line4 = new System.Windows.Forms.Label();
			Label1 = new System.Windows.Forms.Label();
			Label2 = new System.Windows.Forms.Label();
			lbl_Seller_Name = new System.Windows.Forms.Label();
			lbl_Purchaser_Name = new System.Windows.Forms.Label();
			Line1 = new System.Windows.Forms.Label();
			Line2 = new System.Windows.Forms.Label();
			Line3 = new System.Windows.Forms.Label();
			cmd_Major_Cancel = new System.Windows.Forms.Button();
			cbo_New_TransType = new System.Windows.Forms.ComboBox();
			Label4 = new System.Windows.Forms.Label();
			lbl_Current_TransType = new System.Windows.Forms.Label();
			Label3 = new System.Windows.Forms.Label();
			pnl_Company.SuspendLayout();
			pnl_Contact.SuspendLayout();
			pnl_Aircraft.SuspendLayout();
			pnl_AddContact.SuspendLayout();
			pnl_Journal_Data.SuspendLayout();
			pnl_Journal_Heading.SuspendLayout();
			frame_MajorChange.SuspendLayout();
			frame_BuyerSeller.SuspendLayout();
			frame_Current.SuspendLayout();
			SuspendLayout();
			optionButtonHelper1 = new UpgradeHelpers.Gui.Controls.OptionButtonHelper(components);
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
			listBoxHelper1 = new UpgradeHelpers.Gui.Controls.ListBoxHelper(components);
			((System.ComponentModel.ISupportInitialize) grdTransactionDocuments).BeginInit();
			// 
			// pnl_Company
			// 
			pnl_Company.AllowDrop = true;
			pnl_Company.BackColor = System.Drawing.SystemColors.Control;
			pnl_Company.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Company.Controls.Add(cbo_comp_info);
			pnl_Company.Controls.Add(lst_comp_info);
			pnl_Company.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Company.Location = new System.Drawing.Point(233, 7);
			pnl_Company.Name = "pnl_Company";
			pnl_Company.Size = new System.Drawing.Size(370, 138);
			pnl_Company.TabIndex = 76;
			// 
			// cbo_comp_info
			// 
			cbo_comp_info.AllowDrop = true;
			cbo_comp_info.BackColor = System.Drawing.SystemColors.Window;
			cbo_comp_info.CausesValidation = true;
			cbo_comp_info.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_comp_info.Enabled = true;
			cbo_comp_info.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_comp_info.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_comp_info.IntegralHeight = true;
			cbo_comp_info.Location = new System.Drawing.Point(10, 110);
			cbo_comp_info.Name = "cbo_comp_info";
			cbo_comp_info.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_comp_info.Size = new System.Drawing.Size(358, 21);
			cbo_comp_info.Sorted = false;
			cbo_comp_info.TabIndex = 78;
			cbo_comp_info.TabStop = true;
			cbo_comp_info.Visible = false;
			cbo_comp_info.SelectedIndexChanged += new System.EventHandler(cbo_comp_info_SelectedIndexChanged);
			// 
			// lst_comp_info
			// 
			lst_comp_info.AllowDrop = true;
			lst_comp_info.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			lst_comp_info.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lst_comp_info.CausesValidation = true;
			lst_comp_info.Enabled = true;
			lst_comp_info.Font = new System.Drawing.Font("Courier New", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lst_comp_info.ForeColor = System.Drawing.SystemColors.WindowText;
			lst_comp_info.IntegralHeight = true;
			lst_comp_info.Location = new System.Drawing.Point(6, 18);
			lst_comp_info.MultiColumn = false;
			lst_comp_info.Name = "lst_comp_info";
			lst_comp_info.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lst_comp_info.Size = new System.Drawing.Size(357, 89);
			lst_comp_info.Sorted = false;
			lst_comp_info.TabIndex = 77;
			lst_comp_info.TabStop = true;
			lst_comp_info.Visible = true;
			// 
			// pnl_Contact
			// 
			pnl_Contact.AllowDrop = true;
			pnl_Contact.BackColor = System.Drawing.SystemColors.Control;
			pnl_Contact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Contact.Controls.Add(cbo_contact_info);
			pnl_Contact.Controls.Add(lst_contact_info);
			pnl_Contact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Contact.Location = new System.Drawing.Point(604, 7);
			pnl_Contact.Name = "pnl_Contact";
			pnl_Contact.Size = new System.Drawing.Size(390, 138);
			pnl_Contact.TabIndex = 79;
			// 
			// cbo_contact_info
			// 
			cbo_contact_info.AllowDrop = true;
			cbo_contact_info.BackColor = System.Drawing.SystemColors.Window;
			cbo_contact_info.CausesValidation = true;
			cbo_contact_info.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_contact_info.Enabled = true;
			cbo_contact_info.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_contact_info.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_contact_info.IntegralHeight = true;
			cbo_contact_info.Location = new System.Drawing.Point(6, 110);
			cbo_contact_info.Name = "cbo_contact_info";
			cbo_contact_info.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_contact_info.Size = new System.Drawing.Size(379, 21);
			cbo_contact_info.Sorted = false;
			cbo_contact_info.TabIndex = 81;
			cbo_contact_info.TabStop = true;
			cbo_contact_info.Text = "cbo_contact_info";
			cbo_contact_info.Visible = false;
			cbo_contact_info.SelectionChangeCommitted += new System.EventHandler(cbo_contact_info_SelectionChangeCommitted);
			// 
			// lst_contact_info
			// 
			lst_contact_info.AllowDrop = true;
			lst_contact_info.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			lst_contact_info.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lst_contact_info.CausesValidation = true;
			lst_contact_info.Enabled = true;
			lst_contact_info.Font = new System.Drawing.Font("Courier New", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lst_contact_info.ForeColor = System.Drawing.SystemColors.WindowText;
			lst_contact_info.IntegralHeight = true;
			lst_contact_info.Location = new System.Drawing.Point(8, 16);
			lst_contact_info.MultiColumn = false;
			lst_contact_info.Name = "lst_contact_info";
			lst_contact_info.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lst_contact_info.Size = new System.Drawing.Size(377, 89);
			lst_contact_info.Sorted = false;
			lst_contact_info.TabIndex = 80;
			lst_contact_info.TabStop = true;
			lst_contact_info.Visible = true;
			// 
			// pnl_Aircraft
			// 
			pnl_Aircraft.AllowDrop = true;
			pnl_Aircraft.BackColor = System.Drawing.SystemColors.Control;
			pnl_Aircraft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Aircraft.Controls.Add(lst_aircraft);
			pnl_Aircraft.Controls.Add(lst_aircraft_info);
			pnl_Aircraft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Aircraft.Location = new System.Drawing.Point(7, 8);
			pnl_Aircraft.Name = "pnl_Aircraft";
			pnl_Aircraft.Size = new System.Drawing.Size(226, 138);
			pnl_Aircraft.TabIndex = 57;
			// 
			// lst_aircraft
			// 
			lst_aircraft.AllowDrop = true;
			lst_aircraft.BackColor = System.Drawing.SystemColors.Window;
			lst_aircraft.CausesValidation = true;
			lst_aircraft.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			lst_aircraft.Enabled = true;
			lst_aircraft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lst_aircraft.ForeColor = System.Drawing.SystemColors.WindowText;
			lst_aircraft.IntegralHeight = true;
			lst_aircraft.Location = new System.Drawing.Point(8, 112);
			lst_aircraft.Name = "lst_aircraft";
			lst_aircraft.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lst_aircraft.Size = new System.Drawing.Size(209, 21);
			lst_aircraft.Sorted = false;
			lst_aircraft.TabIndex = 89;
			lst_aircraft.TabStop = true;
			lst_aircraft.Visible = true;
			// 
			// lst_aircraft_info
			// 
			lst_aircraft_info.AllowDrop = true;
			lst_aircraft_info.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			lst_aircraft_info.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lst_aircraft_info.CausesValidation = true;
			lst_aircraft_info.Enabled = true;
			lst_aircraft_info.Font = new System.Drawing.Font("Courier New", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lst_aircraft_info.ForeColor = System.Drawing.SystemColors.WindowText;
			lst_aircraft_info.IntegralHeight = true;
			lst_aircraft_info.Location = new System.Drawing.Point(4, 18);
			lst_aircraft_info.MultiColumn = false;
			lst_aircraft_info.Name = "lst_aircraft_info";
			lst_aircraft_info.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lst_aircraft_info.Size = new System.Drawing.Size(217, 61);
			lst_aircraft_info.Sorted = false;
			lst_aircraft_info.TabIndex = 58;
			lst_aircraft_info.TabStop = true;
			lst_aircraft_info.Visible = true;
			// 
			// pnl_AddContact
			// 
			pnl_AddContact.AllowDrop = true;
			pnl_AddContact.BackColor = System.Drawing.SystemColors.Control;
			pnl_AddContact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_AddContact.Controls.Add(cmdCancelAddContact);
			pnl_AddContact.Controls.Add(cmdSaveAddContact);
			pnl_AddContact.Controls.Add(txt_cont_first_name);
			pnl_AddContact.Controls.Add(txt_cont_last_name);
			pnl_AddContact.Controls.Add(txt_cont_middle_initial);
			pnl_AddContact.Controls.Add(cboNewContactTitle);
			pnl_AddContact.Controls.Add(txt_contact_email_address);
			pnl_AddContact.Controls.Add(cbo_contact_sirname);
			pnl_AddContact.Controls.Add(cbo_contact_suffix);
			pnl_AddContact.Controls.Add(_lbl_Journal_6);
			pnl_AddContact.Controls.Add(_lbl_Journal_7);
			pnl_AddContact.Controls.Add(_lbl_Journal_8);
			pnl_AddContact.Controls.Add(_lbl_Journal_9);
			pnl_AddContact.Controls.Add(lbl_contact_email);
			pnl_AddContact.Controls.Add(lbl_Prefix);
			pnl_AddContact.Controls.Add(lbl_contact_name);
			pnl_AddContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_AddContact.Location = new System.Drawing.Point(603, 7);
			pnl_AddContact.Name = "pnl_AddContact";
			pnl_AddContact.Size = new System.Drawing.Size(390, 138);
			pnl_AddContact.TabIndex = 59;
			pnl_AddContact.Visible = false;
			// 
			// cmdCancelAddContact
			// 
			cmdCancelAddContact.AllowDrop = true;
			cmdCancelAddContact.BackColor = System.Drawing.SystemColors.Control;
			cmdCancelAddContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdCancelAddContact.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdCancelAddContact.Location = new System.Drawing.Point(314, 113);
			cmdCancelAddContact.Name = "cmdCancelAddContact";
			cmdCancelAddContact.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdCancelAddContact.Size = new System.Drawing.Size(57, 19);
			cmdCancelAddContact.TabIndex = 68;
			cmdCancelAddContact.Text = "&Cancel";
			cmdCancelAddContact.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdCancelAddContact.UseVisualStyleBackColor = false;
			cmdCancelAddContact.Click += new System.EventHandler(cmdCancelAddContact_Click);
			// 
			// cmdSaveAddContact
			// 
			cmdSaveAddContact.AllowDrop = true;
			cmdSaveAddContact.BackColor = System.Drawing.SystemColors.Control;
			cmdSaveAddContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdSaveAddContact.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdSaveAddContact.Location = new System.Drawing.Point(250, 113);
			cmdSaveAddContact.Name = "cmdSaveAddContact";
			cmdSaveAddContact.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdSaveAddContact.Size = new System.Drawing.Size(57, 19);
			cmdSaveAddContact.TabIndex = 67;
			cmdSaveAddContact.Text = "&Save";
			cmdSaveAddContact.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdSaveAddContact.UseVisualStyleBackColor = false;
			cmdSaveAddContact.Click += new System.EventHandler(cmdSaveAddContact_Click);
			// 
			// txt_cont_first_name
			// 
			txt_cont_first_name.AcceptsReturn = true;
			txt_cont_first_name.AllowDrop = true;
			txt_cont_first_name.BackColor = System.Drawing.SystemColors.Window;
			txt_cont_first_name.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_cont_first_name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_cont_first_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_cont_first_name.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_cont_first_name.Location = new System.Drawing.Point(95, 31);
			txt_cont_first_name.MaxLength = 15;
			txt_cont_first_name.Name = "txt_cont_first_name";
			txt_cont_first_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_cont_first_name.Size = new System.Drawing.Size(78, 21);
			txt_cont_first_name.TabIndex = 66;
			// 
			// txt_cont_last_name
			// 
			txt_cont_last_name.AcceptsReturn = true;
			txt_cont_last_name.AllowDrop = true;
			txt_cont_last_name.BackColor = System.Drawing.SystemColors.Window;
			txt_cont_last_name.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_cont_last_name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_cont_last_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_cont_last_name.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_cont_last_name.Location = new System.Drawing.Point(206, 31);
			txt_cont_last_name.MaxLength = 25;
			txt_cont_last_name.Name = "txt_cont_last_name";
			txt_cont_last_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_cont_last_name.Size = new System.Drawing.Size(102, 21);
			txt_cont_last_name.TabIndex = 65;
			// 
			// txt_cont_middle_initial
			// 
			txt_cont_middle_initial.AcceptsReturn = true;
			txt_cont_middle_initial.AllowDrop = true;
			txt_cont_middle_initial.BackColor = System.Drawing.SystemColors.Window;
			txt_cont_middle_initial.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_cont_middle_initial.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_cont_middle_initial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_cont_middle_initial.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_cont_middle_initial.Location = new System.Drawing.Point(182, 31);
			txt_cont_middle_initial.MaxLength = 1;
			txt_cont_middle_initial.Name = "txt_cont_middle_initial";
			txt_cont_middle_initial.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_cont_middle_initial.Size = new System.Drawing.Size(20, 21);
			txt_cont_middle_initial.TabIndex = 64;
			// 
			// cboNewContactTitle
			// 
			cboNewContactTitle.AllowDrop = true;
			cboNewContactTitle.BackColor = System.Drawing.SystemColors.Window;
			cboNewContactTitle.CausesValidation = true;
			cboNewContactTitle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboNewContactTitle.Enabled = true;
			cboNewContactTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cboNewContactTitle.ForeColor = System.Drawing.SystemColors.WindowText;
			cboNewContactTitle.IntegralHeight = true;
			cboNewContactTitle.Location = new System.Drawing.Point(84, 57);
			cboNewContactTitle.Name = "cboNewContactTitle";
			cboNewContactTitle.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cboNewContactTitle.Size = new System.Drawing.Size(175, 21);
			cboNewContactTitle.Sorted = false;
			cboNewContactTitle.TabIndex = 63;
			cboNewContactTitle.TabStop = true;
			cboNewContactTitle.Visible = true;
			// 
			// txt_contact_email_address
			// 
			txt_contact_email_address.AcceptsReturn = true;
			txt_contact_email_address.AllowDrop = true;
			txt_contact_email_address.BackColor = System.Drawing.SystemColors.Window;
			txt_contact_email_address.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_contact_email_address.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_contact_email_address.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_contact_email_address.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_contact_email_address.Location = new System.Drawing.Point(84, 88);
			txt_contact_email_address.MaxLength = 0;
			txt_contact_email_address.Name = "txt_contact_email_address";
			txt_contact_email_address.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_contact_email_address.Size = new System.Drawing.Size(175, 19);
			txt_contact_email_address.TabIndex = 62;
			// 
			// cbo_contact_sirname
			// 
			cbo_contact_sirname.AllowDrop = true;
			cbo_contact_sirname.BackColor = System.Drawing.SystemColors.Window;
			cbo_contact_sirname.CausesValidation = true;
			cbo_contact_sirname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_contact_sirname.Enabled = true;
			cbo_contact_sirname.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_contact_sirname.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_contact_sirname.IntegralHeight = true;
			cbo_contact_sirname.Location = new System.Drawing.Point(25, 31);
			cbo_contact_sirname.Name = "cbo_contact_sirname";
			cbo_contact_sirname.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_contact_sirname.Size = new System.Drawing.Size(65, 21);
			cbo_contact_sirname.Sorted = false;
			cbo_contact_sirname.TabIndex = 61;
			cbo_contact_sirname.TabStop = true;
			cbo_contact_sirname.Visible = true;
			// 
			// cbo_contact_suffix
			// 
			cbo_contact_suffix.AllowDrop = true;
			cbo_contact_suffix.BackColor = System.Drawing.SystemColors.Window;
			cbo_contact_suffix.CausesValidation = true;
			cbo_contact_suffix.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_contact_suffix.Enabled = true;
			cbo_contact_suffix.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_contact_suffix.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_contact_suffix.IntegralHeight = true;
			cbo_contact_suffix.Location = new System.Drawing.Point(314, 31);
			cbo_contact_suffix.Name = "cbo_contact_suffix";
			cbo_contact_suffix.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_contact_suffix.Size = new System.Drawing.Size(57, 21);
			cbo_contact_suffix.Sorted = false;
			cbo_contact_suffix.TabIndex = 60;
			cbo_contact_suffix.TabStop = true;
			cbo_contact_suffix.Visible = true;
			// 
			// _lbl_Journal_6
			// 
			_lbl_Journal_6.AllowDrop = true;
			_lbl_Journal_6.AutoSize = true;
			_lbl_Journal_6.BackColor = System.Drawing.SystemColors.Control;
			_lbl_Journal_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_Journal_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_Journal_6.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_Journal_6.Location = new System.Drawing.Point(95, 18);
			_lbl_Journal_6.MinimumSize = new System.Drawing.Size(19, 13);
			_lbl_Journal_6.Name = "_lbl_Journal_6";
			_lbl_Journal_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_Journal_6.Size = new System.Drawing.Size(19, 13);
			_lbl_Journal_6.TabIndex = 75;
			_lbl_Journal_6.Text = "First";
			// 
			// _lbl_Journal_7
			// 
			_lbl_Journal_7.AllowDrop = true;
			_lbl_Journal_7.AutoSize = true;
			_lbl_Journal_7.BackColor = System.Drawing.SystemColors.Control;
			_lbl_Journal_7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_Journal_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_Journal_7.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_Journal_7.Location = new System.Drawing.Point(206, 18);
			_lbl_Journal_7.MinimumSize = new System.Drawing.Size(20, 13);
			_lbl_Journal_7.Name = "_lbl_Journal_7";
			_lbl_Journal_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_Journal_7.Size = new System.Drawing.Size(20, 13);
			_lbl_Journal_7.TabIndex = 74;
			_lbl_Journal_7.Text = "Last";
			// 
			// _lbl_Journal_8
			// 
			_lbl_Journal_8.AllowDrop = true;
			_lbl_Journal_8.AutoSize = true;
			_lbl_Journal_8.BackColor = System.Drawing.SystemColors.Control;
			_lbl_Journal_8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_Journal_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_Journal_8.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_Journal_8.Location = new System.Drawing.Point(182, 18);
			_lbl_Journal_8.MinimumSize = new System.Drawing.Size(18, 13);
			_lbl_Journal_8.Name = "_lbl_Journal_8";
			_lbl_Journal_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_Journal_8.Size = new System.Drawing.Size(18, 13);
			_lbl_Journal_8.TabIndex = 73;
			_lbl_Journal_8.Text = "M.I.";
			// 
			// _lbl_Journal_9
			// 
			_lbl_Journal_9.AllowDrop = true;
			_lbl_Journal_9.AutoSize = true;
			_lbl_Journal_9.BackColor = System.Drawing.SystemColors.Control;
			_lbl_Journal_9.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_Journal_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_Journal_9.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_Journal_9.Location = new System.Drawing.Point(54, 62);
			_lbl_Journal_9.MinimumSize = new System.Drawing.Size(23, 13);
			_lbl_Journal_9.Name = "_lbl_Journal_9";
			_lbl_Journal_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_Journal_9.Size = new System.Drawing.Size(23, 13);
			_lbl_Journal_9.TabIndex = 72;
			_lbl_Journal_9.Text = "Title:";
			// 
			// lbl_contact_email
			// 
			lbl_contact_email.AllowDrop = true;
			lbl_contact_email.AutoSize = true;
			lbl_contact_email.BackColor = System.Drawing.SystemColors.Control;
			lbl_contact_email.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_contact_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_contact_email.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_contact_email.Location = new System.Drawing.Point(46, 89);
			lbl_contact_email.MinimumSize = new System.Drawing.Size(31, 13);
			lbl_contact_email.Name = "lbl_contact_email";
			lbl_contact_email.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_contact_email.Size = new System.Drawing.Size(31, 13);
			lbl_contact_email.TabIndex = 71;
			lbl_contact_email.Text = "E-mail:";
			// 
			// lbl_Prefix
			// 
			lbl_Prefix.AllowDrop = true;
			lbl_Prefix.AutoSize = true;
			lbl_Prefix.BackColor = System.Drawing.SystemColors.Control;
			lbl_Prefix.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_Prefix.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_Prefix.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_Prefix.Location = new System.Drawing.Point(25, 18);
			lbl_Prefix.MinimumSize = new System.Drawing.Size(29, 13);
			lbl_Prefix.Name = "lbl_Prefix";
			lbl_Prefix.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_Prefix.Size = new System.Drawing.Size(29, 13);
			lbl_Prefix.TabIndex = 70;
			lbl_Prefix.Text = "Prefix:";
			// 
			// lbl_contact_name
			// 
			lbl_contact_name.AllowDrop = true;
			lbl_contact_name.AutoSize = true;
			lbl_contact_name.BackColor = System.Drawing.SystemColors.Control;
			lbl_contact_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_contact_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_contact_name.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_contact_name.Location = new System.Drawing.Point(314, 18);
			lbl_contact_name.MinimumSize = new System.Drawing.Size(26, 13);
			lbl_contact_name.Name = "lbl_contact_name";
			lbl_contact_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_contact_name.Size = new System.Drawing.Size(26, 13);
			lbl_contact_name.TabIndex = 69;
			lbl_contact_name.Text = "Suffix";
			// 
			// pnl_Journal_Data
			// 
			pnl_Journal_Data.AllowDrop = true;
			pnl_Journal_Data.BackColor = System.Drawing.SystemColors.Control;
			pnl_Journal_Data.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Journal_Data.Controls.Add(cbo_journ_cat);
			pnl_Journal_Data.Controls.Add(cbp_journ_sub_type);
			pnl_Journal_Data.Controls.Add(chkAskedForSoldPrice);
			pnl_Journal_Data.Controls.Add(chkAskedForSoldPriceRefused);
			pnl_Journal_Data.Controls.Add(txt_journ_customer_note);
			pnl_Journal_Data.Controls.Add(_radio_id_2);
			pnl_Journal_Data.Controls.Add(_radio_id_1);
			pnl_Journal_Data.Controls.Add(_radio_id_0);
			pnl_Journal_Data.Controls.Add(pnl_Journal_Heading);
			pnl_Journal_Data.Controls.Add(txt_journ_description);
			pnl_Journal_Data.Controls.Add(grdTransactionDocuments);
			pnl_Journal_Data.Controls.Add(chk_journ_internal_trans_flag);
			pnl_Journal_Data.Controls.Add(cmd_Change_Trans_Type);
			pnl_Journal_Data.Controls.Add(chk_New_to_Market);
			pnl_Journal_Data.Controls.Add(cmdDelete);
			pnl_Journal_Data.Controls.Add(cmdDocuments);
			pnl_Journal_Data.Controls.Add(txt_journ_subcategory_code);
			pnl_Journal_Data.Controls.Add(cmd_Cancel);
			pnl_Journal_Data.Controls.Add(cmd_Save);
			pnl_Journal_Data.Controls.Add(txt_journ_subject);
			pnl_Journal_Data.Controls.Add(txt_category);
			pnl_Journal_Data.Controls.Add(txt_journ_date);
			pnl_Journal_Data.Controls.Add(cboDocumentType);
			pnl_Journal_Data.Controls.Add(cboNewSubcategoryCode);
			pnl_Journal_Data.Controls.Add(_lbl_Journal_5);
			pnl_Journal_Data.Controls.Add(lblSubCategoryCode);
			pnl_Journal_Data.Controls.Add(_lbl_Journal_3);
			pnl_Journal_Data.Controls.Add(_lbl_Journal_4);
			pnl_Journal_Data.Controls.Add(_lbl_Journal_2);
			pnl_Journal_Data.Controls.Add(_lbl_Journal_1);
			pnl_Journal_Data.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Journal_Data.Location = new System.Drawing.Point(8, 145);
			pnl_Journal_Data.Name = "pnl_Journal_Data";
			pnl_Journal_Data.Size = new System.Drawing.Size(986, 272);
			pnl_Journal_Data.TabIndex = 3;
			// 
			// cbo_journ_cat
			// 
			cbo_journ_cat.AllowDrop = true;
			cbo_journ_cat.BackColor = System.Drawing.SystemColors.Window;
			cbo_journ_cat.CausesValidation = true;
			cbo_journ_cat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_journ_cat.Enabled = true;
			cbo_journ_cat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_journ_cat.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_journ_cat.IntegralHeight = true;
			cbo_journ_cat.Location = new System.Drawing.Point(560, 88);
			cbo_journ_cat.Name = "cbo_journ_cat";
			cbo_journ_cat.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_journ_cat.Size = new System.Drawing.Size(91, 21);
			cbo_journ_cat.Sorted = false;
			cbo_journ_cat.TabIndex = 88;
			cbo_journ_cat.TabStop = true;
			cbo_journ_cat.Visible = false;
			cbo_journ_cat.SelectionChangeCommitted += new System.EventHandler(cbo_journ_cat_SelectionChangeCommitted);
			// 
			// cbp_journ_sub_type
			// 
			cbp_journ_sub_type.AllowDrop = true;
			cbp_journ_sub_type.BackColor = System.Drawing.SystemColors.Window;
			cbp_journ_sub_type.CausesValidation = true;
			cbp_journ_sub_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbp_journ_sub_type.Enabled = true;
			cbp_journ_sub_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbp_journ_sub_type.ForeColor = System.Drawing.SystemColors.WindowText;
			cbp_journ_sub_type.IntegralHeight = true;
			cbp_journ_sub_type.Location = new System.Drawing.Point(57, 123);
			cbp_journ_sub_type.Name = "cbp_journ_sub_type";
			cbp_journ_sub_type.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbp_journ_sub_type.Size = new System.Drawing.Size(240, 21);
			cbp_journ_sub_type.Sorted = false;
			cbp_journ_sub_type.TabIndex = 87;
			cbp_journ_sub_type.TabStop = true;
			cbp_journ_sub_type.Visible = true;
			cbp_journ_sub_type.SelectionChangeCommitted += new System.EventHandler(cbp_journ_sub_type_SelectionChangeCommitted);
			// 
			// chkAskedForSoldPrice
			// 
			chkAskedForSoldPrice.AllowDrop = true;
			chkAskedForSoldPrice.Appearance = System.Windows.Forms.Appearance.Normal;
			chkAskedForSoldPrice.BackColor = System.Drawing.SystemColors.Control;
			chkAskedForSoldPrice.CausesValidation = true;
			chkAskedForSoldPrice.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkAskedForSoldPrice.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkAskedForSoldPrice.Enabled = true;
			chkAskedForSoldPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkAskedForSoldPrice.ForeColor = System.Drawing.SystemColors.WindowText;
			chkAskedForSoldPrice.Location = new System.Drawing.Point(338, 108);
			chkAskedForSoldPrice.Name = "chkAskedForSoldPrice";
			chkAskedForSoldPrice.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkAskedForSoldPrice.Size = new System.Drawing.Size(119, 15);
			chkAskedForSoldPrice.TabIndex = 86;
			chkAskedForSoldPrice.TabStop = true;
			chkAskedForSoldPrice.Text = "Asked for sale price";
			chkAskedForSoldPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkAskedForSoldPrice.Visible = true;
			// 
			// chkAskedForSoldPriceRefused
			// 
			chkAskedForSoldPriceRefused.AllowDrop = true;
			chkAskedForSoldPriceRefused.Appearance = System.Windows.Forms.Appearance.Normal;
			chkAskedForSoldPriceRefused.BackColor = System.Drawing.SystemColors.Control;
			chkAskedForSoldPriceRefused.CausesValidation = true;
			chkAskedForSoldPriceRefused.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkAskedForSoldPriceRefused.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkAskedForSoldPriceRefused.Enabled = true;
			chkAskedForSoldPriceRefused.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkAskedForSoldPriceRefused.ForeColor = System.Drawing.SystemColors.WindowText;
			chkAskedForSoldPriceRefused.Location = new System.Drawing.Point(116, 108);
			chkAskedForSoldPriceRefused.Name = "chkAskedForSoldPriceRefused";
			chkAskedForSoldPriceRefused.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkAskedForSoldPriceRefused.Size = new System.Drawing.Size(161, 15);
			chkAskedForSoldPriceRefused.TabIndex = 85;
			chkAskedForSoldPriceRefused.TabStop = true;
			chkAskedForSoldPriceRefused.Text = "Refused to provide sale price";
			chkAskedForSoldPriceRefused.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkAskedForSoldPriceRefused.Visible = true;
			// 
			// txt_journ_customer_note
			// 
			txt_journ_customer_note.AcceptsReturn = true;
			txt_journ_customer_note.AllowDrop = true;
			txt_journ_customer_note.BackColor = System.Drawing.SystemColors.Window;
			txt_journ_customer_note.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_journ_customer_note.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_journ_customer_note.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_journ_customer_note.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_journ_customer_note.Location = new System.Drawing.Point(58, 206);
			txt_journ_customer_note.MaxLength = 250;
			txt_journ_customer_note.Multiline = true;
			txt_journ_customer_note.Name = "txt_journ_customer_note";
			txt_journ_customer_note.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_journ_customer_note.Size = new System.Drawing.Size(500, 59);
			txt_journ_customer_note.TabIndex = 2;
			// 
			// _radio_id_2
			// 
			_radio_id_2.AllowDrop = true;
			_radio_id_2.BackColor = System.Drawing.SystemColors.Control;
			_radio_id_2.CausesValidation = true;
			_radio_id_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_radio_id_2.Checked = false;
			_radio_id_2.Enabled = true;
			_radio_id_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_radio_id_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_radio_id_2.Location = new System.Drawing.Point(280, 204);
			_radio_id_2.Name = "_radio_id_2";
			_radio_id_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_radio_id_2.Size = new System.Drawing.Size(103, 17);
			_radio_id_2.TabIndex = 84;
			_radio_id_2.TabStop = true;
			_radio_id_2.Text = "ID Lead Sent";
			_radio_id_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_radio_id_2.Visible = false;
			_radio_id_2.CheckedChanged += new System.EventHandler(radio_id_CheckedChanged);
			// 
			// _radio_id_1
			// 
			_radio_id_1.AllowDrop = true;
			_radio_id_1.BackColor = System.Drawing.SystemColors.Control;
			_radio_id_1.CausesValidation = true;
			_radio_id_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_radio_id_1.Checked = false;
			_radio_id_1.Enabled = true;
			_radio_id_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_radio_id_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_radio_id_1.Location = new System.Drawing.Point(197, 204);
			_radio_id_1.Name = "_radio_id_1";
			_radio_id_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_radio_id_1.Size = new System.Drawing.Size(55, 17);
			_radio_id_1.TabIndex = 83;
			_radio_id_1.TabStop = true;
			_radio_id_1.Text = "IDd";
			_radio_id_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_radio_id_1.Visible = false;
			_radio_id_1.CheckedChanged += new System.EventHandler(radio_id_CheckedChanged);
			// 
			// _radio_id_0
			// 
			_radio_id_0.AllowDrop = true;
			_radio_id_0.BackColor = System.Drawing.SystemColors.Control;
			_radio_id_0.CausesValidation = true;
			_radio_id_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_radio_id_0.Checked = false;
			_radio_id_0.Enabled = true;
			_radio_id_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_radio_id_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_radio_id_0.Location = new System.Drawing.Point(66, 204);
			_radio_id_0.Name = "_radio_id_0";
			_radio_id_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_radio_id_0.Size = new System.Drawing.Size(103, 17);
			_radio_id_0.TabIndex = 82;
			_radio_id_0.TabStop = true;
			_radio_id_0.Text = "Attempted to ID";
			_radio_id_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_radio_id_0.Visible = false;
			_radio_id_0.CheckedChanged += new System.EventHandler(radio_id_CheckedChanged);
			// 
			// pnl_Journal_Heading
			// 
			pnl_Journal_Heading.AllowDrop = true;
			pnl_Journal_Heading.BackColor = System.Drawing.SystemColors.Control;
			pnl_Journal_Heading.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Journal_Heading.Controls.Add(txt_User);
			pnl_Journal_Heading.Controls.Add(txt_pcreckey);
			pnl_Journal_Heading.Controls.Add(txt_journ_prior_account_id);
			pnl_Journal_Heading.Controls.Add(txt_journ_account_id);
			pnl_Journal_Heading.Controls.Add(txt_journ_entry_time);
			pnl_Journal_Heading.Controls.Add(txt_journ_entry_date);
			pnl_Journal_Heading.Controls.Add(txt_journ_id);
			pnl_Journal_Heading.Controls.Add(lbl_User);
			pnl_Journal_Heading.Controls.Add(_lbl_Journal_10);
			pnl_Journal_Heading.Controls.Add(lbl_prioracctid);
			pnl_Journal_Heading.Controls.Add(lbl_acctid);
			pnl_Journal_Heading.Controls.Add(lbl_date_time);
			pnl_Journal_Heading.Controls.Add(_lbl_Journal_0);
			pnl_Journal_Heading.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Journal_Heading.Location = new System.Drawing.Point(62, 6);
			pnl_Journal_Heading.Name = "pnl_Journal_Heading";
			pnl_Journal_Heading.Size = new System.Drawing.Size(621, 60);
			pnl_Journal_Heading.TabIndex = 14;
			// 
			// txt_User
			// 
			txt_User.AcceptsReturn = true;
			txt_User.AllowDrop = true;
			txt_User.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_User.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_User.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_User.Enabled = false;
			txt_User.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_User.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_User.Location = new System.Drawing.Point(343, 36);
			txt_User.MaxLength = 0;
			txt_User.Name = "txt_User";
			txt_User.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_User.Size = new System.Drawing.Size(40, 19);
			txt_User.TabIndex = 11;
			txt_User.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_pcreckey
			// 
			txt_pcreckey.AcceptsReturn = true;
			txt_pcreckey.AllowDrop = true;
			txt_pcreckey.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_pcreckey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_pcreckey.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_pcreckey.Enabled = false;
			txt_pcreckey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_pcreckey.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_pcreckey.Location = new System.Drawing.Point(93, 36);
			txt_pcreckey.MaxLength = 0;
			txt_pcreckey.Name = "txt_pcreckey";
			txt_pcreckey.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_pcreckey.Size = new System.Drawing.Size(49, 19);
			txt_pcreckey.TabIndex = 8;
			txt_pcreckey.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_journ_prior_account_id
			// 
			txt_journ_prior_account_id.AcceptsReturn = true;
			txt_journ_prior_account_id.AllowDrop = true;
			txt_journ_prior_account_id.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_journ_prior_account_id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_journ_prior_account_id.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_journ_prior_account_id.Enabled = false;
			txt_journ_prior_account_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_journ_prior_account_id.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_journ_prior_account_id.Location = new System.Drawing.Point(260, 36);
			txt_journ_prior_account_id.MaxLength = 0;
			txt_journ_prior_account_id.Name = "txt_journ_prior_account_id";
			txt_journ_prior_account_id.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_journ_prior_account_id.Size = new System.Drawing.Size(48, 19);
			txt_journ_prior_account_id.TabIndex = 10;
			txt_journ_prior_account_id.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_journ_account_id
			// 
			txt_journ_account_id.AcceptsReturn = true;
			txt_journ_account_id.AllowDrop = true;
			txt_journ_account_id.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_journ_account_id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_journ_account_id.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_journ_account_id.Enabled = false;
			txt_journ_account_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_journ_account_id.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_journ_account_id.Location = new System.Drawing.Point(177, 36);
			txt_journ_account_id.MaxLength = 0;
			txt_journ_account_id.Name = "txt_journ_account_id";
			txt_journ_account_id.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_journ_account_id.Size = new System.Drawing.Size(48, 19);
			txt_journ_account_id.TabIndex = 9;
			txt_journ_account_id.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_journ_entry_time
			// 
			txt_journ_entry_time.AcceptsReturn = true;
			txt_journ_entry_time.AllowDrop = true;
			txt_journ_entry_time.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_journ_entry_time.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_journ_entry_time.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_journ_entry_time.Enabled = false;
			txt_journ_entry_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_journ_entry_time.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_journ_entry_time.Location = new System.Drawing.Point(523, 36);
			txt_journ_entry_time.MaxLength = 0;
			txt_journ_entry_time.Name = "txt_journ_entry_time";
			txt_journ_entry_time.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_journ_entry_time.Size = new System.Drawing.Size(89, 19);
			txt_journ_entry_time.TabIndex = 13;
			txt_journ_entry_time.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_journ_entry_date
			// 
			txt_journ_entry_date.AcceptsReturn = true;
			txt_journ_entry_date.AllowDrop = true;
			txt_journ_entry_date.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_journ_entry_date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_journ_entry_date.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_journ_entry_date.Enabled = false;
			txt_journ_entry_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_journ_entry_date.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_journ_entry_date.Location = new System.Drawing.Point(455, 36);
			txt_journ_entry_date.MaxLength = 0;
			txt_journ_entry_date.Name = "txt_journ_entry_date";
			txt_journ_entry_date.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_journ_entry_date.Size = new System.Drawing.Size(65, 19);
			txt_journ_entry_date.TabIndex = 12;
			txt_journ_entry_date.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_journ_id
			// 
			txt_journ_id.AcceptsReturn = true;
			txt_journ_id.AllowDrop = true;
			txt_journ_id.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_journ_id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_journ_id.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_journ_id.Enabled = false;
			txt_journ_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_journ_id.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_journ_id.Location = new System.Drawing.Point(9, 36);
			txt_journ_id.MaxLength = 0;
			txt_journ_id.Name = "txt_journ_id";
			txt_journ_id.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_journ_id.Size = new System.Drawing.Size(67, 19);
			txt_journ_id.TabIndex = 7;
			txt_journ_id.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lbl_User
			// 
			lbl_User.AllowDrop = true;
			lbl_User.AutoSize = true;
			lbl_User.BackColor = System.Drawing.Color.Transparent;
			lbl_User.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_User.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_User.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_User.Location = new System.Drawing.Point(337, 19);
			lbl_User.MinimumSize = new System.Drawing.Size(52, 13);
			lbl_User.Name = "lbl_User";
			lbl_User.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_User.Size = new System.Drawing.Size(52, 13);
			lbl_User.TabIndex = 27;
			lbl_User.Text = "Entry User:";
			// 
			// _lbl_Journal_10
			// 
			_lbl_Journal_10.AllowDrop = true;
			_lbl_Journal_10.AutoSize = true;
			_lbl_Journal_10.BackColor = System.Drawing.SystemColors.Control;
			_lbl_Journal_10.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_Journal_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_Journal_10.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_Journal_10.Location = new System.Drawing.Point(87, 19);
			_lbl_Journal_10.MinimumSize = new System.Drawing.Size(61, 13);
			_lbl_Journal_10.Name = "_lbl_Journal_10";
			_lbl_Journal_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_Journal_10.Size = new System.Drawing.Size(61, 13);
			_lbl_Journal_10.TabIndex = 26;
			_lbl_Journal_10.Text = "PC Rec Key:";
			// 
			// lbl_prioracctid
			// 
			lbl_prioracctid.AllowDrop = true;
			lbl_prioracctid.AutoSize = true;
			lbl_prioracctid.BackColor = System.Drawing.Color.Transparent;
			lbl_prioracctid.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_prioracctid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_prioracctid.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_prioracctid.Location = new System.Drawing.Point(244, 19);
			lbl_prioracctid.MinimumSize = new System.Drawing.Size(81, 13);
			lbl_prioracctid.Name = "lbl_prioracctid";
			lbl_prioracctid.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_prioracctid.Size = new System.Drawing.Size(81, 13);
			lbl_prioracctid.TabIndex = 21;
			lbl_prioracctid.Text = "Prior Account ID:";
			// 
			// lbl_acctid
			// 
			lbl_acctid.AllowDrop = true;
			lbl_acctid.AutoSize = true;
			lbl_acctid.BackColor = System.Drawing.SystemColors.Control;
			lbl_acctid.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_acctid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_acctid.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_acctid.Location = new System.Drawing.Point(173, 18);
			lbl_acctid.MinimumSize = new System.Drawing.Size(57, 13);
			lbl_acctid.Name = "lbl_acctid";
			lbl_acctid.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_acctid.Size = new System.Drawing.Size(57, 13);
			lbl_acctid.TabIndex = 20;
			lbl_acctid.Text = "Account ID:";
			// 
			// lbl_date_time
			// 
			lbl_date_time.AllowDrop = true;
			lbl_date_time.AutoSize = true;
			lbl_date_time.BackColor = System.Drawing.SystemColors.Control;
			lbl_date_time.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_date_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_date_time.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_date_time.Location = new System.Drawing.Point(455, 19);
			lbl_date_time.MinimumSize = new System.Drawing.Size(96, 13);
			lbl_date_time.Name = "lbl_date_time";
			lbl_date_time.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_date_time.Size = new System.Drawing.Size(96, 13);
			lbl_date_time.TabIndex = 19;
			lbl_date_time.Text = "Entry      Date/Time:";
			// 
			// _lbl_Journal_0
			// 
			_lbl_Journal_0.AllowDrop = true;
			_lbl_Journal_0.AutoSize = true;
			_lbl_Journal_0.BackColor = System.Drawing.SystemColors.Control;
			_lbl_Journal_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_Journal_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_Journal_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_Journal_0.Location = new System.Drawing.Point(9, 19);
			_lbl_Journal_0.MinimumSize = new System.Drawing.Size(21, 13);
			_lbl_Journal_0.Name = "_lbl_Journal_0";
			_lbl_Journal_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_Journal_0.Size = new System.Drawing.Size(21, 13);
			_lbl_Journal_0.TabIndex = 16;
			_lbl_Journal_0.Text = "ID#:";
			// 
			// txt_journ_description
			// 
			txt_journ_description.AcceptsReturn = true;
			txt_journ_description.AllowDrop = true;
			txt_journ_description.BackColor = System.Drawing.SystemColors.Window;
			txt_journ_description.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_journ_description.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_journ_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_journ_description.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_journ_description.Location = new System.Drawing.Point(57, 152);
			txt_journ_description.MaxLength = 4000;
			txt_journ_description.Multiline = true;
			txt_journ_description.Name = "txt_journ_description";
			txt_journ_description.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_journ_description.Size = new System.Drawing.Size(500, 51);
			txt_journ_description.TabIndex = 1;
			// 
			// grdTransactionDocuments
			// 
			grdTransactionDocuments.AllowDrop = true;
			grdTransactionDocuments.AllowUserToAddRows = false;
			grdTransactionDocuments.AllowUserToDeleteRows = false;
			grdTransactionDocuments.AllowUserToResizeColumns = false;
			grdTransactionDocuments.AllowUserToResizeColumns = grdTransactionDocuments.ColumnHeadersVisible;
			grdTransactionDocuments.AllowUserToResizeRows = false;
			grdTransactionDocuments.AllowUserToResizeRows = grdTransactionDocuments.RowHeadersVisible;
			grdTransactionDocuments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grdTransactionDocuments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grdTransactionDocuments.ColumnsCount = 2;
			grdTransactionDocuments.FixedColumns = 0;
			grdTransactionDocuments.FixedRows = 1;
			grdTransactionDocuments.FocusRect = UpgradeHelpers.FocusRectSettings.FocusNone;
			grdTransactionDocuments.Location = new System.Drawing.Point(719, 6);
			grdTransactionDocuments.Name = "grdTransactionDocuments";
			grdTransactionDocuments.ReadOnly = true;
			grdTransactionDocuments.RowsCount = 2;
			grdTransactionDocuments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			grdTransactionDocuments.ShowCellToolTips = false;
			grdTransactionDocuments.Size = new System.Drawing.Size(262, 218);
			grdTransactionDocuments.StandardTab = true;
			grdTransactionDocuments.TabIndex = 32;
			grdTransactionDocuments.Visible = false;
			// 
			// chk_journ_internal_trans_flag
			// 
			chk_journ_internal_trans_flag.AllowDrop = true;
			chk_journ_internal_trans_flag.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_journ_internal_trans_flag.BackColor = System.Drawing.SystemColors.Control;
			chk_journ_internal_trans_flag.CausesValidation = true;
			chk_journ_internal_trans_flag.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_journ_internal_trans_flag.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_journ_internal_trans_flag.Enabled = false;
			chk_journ_internal_trans_flag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_journ_internal_trans_flag.ForeColor = System.Drawing.SystemColors.WindowText;
			chk_journ_internal_trans_flag.Location = new System.Drawing.Point(657, 88);
			chk_journ_internal_trans_flag.Name = "chk_journ_internal_trans_flag";
			chk_journ_internal_trans_flag.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_journ_internal_trans_flag.Size = new System.Drawing.Size(55, 14);
			chk_journ_internal_trans_flag.TabIndex = 55;
			chk_journ_internal_trans_flag.TabStop = true;
			chk_journ_internal_trans_flag.Text = "Internal";
			chk_journ_internal_trans_flag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_journ_internal_trans_flag.Visible = true;
			chk_journ_internal_trans_flag.CheckStateChanged += new System.EventHandler(chk_journ_internal_trans_flag_CheckStateChanged);
			// 
			// cmd_Change_Trans_Type
			// 
			cmd_Change_Trans_Type.AllowDrop = true;
			cmd_Change_Trans_Type.BackColor = System.Drawing.SystemColors.Control;
			cmd_Change_Trans_Type.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Change_Trans_Type.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Change_Trans_Type.Location = new System.Drawing.Point(562, 229);
			cmd_Change_Trans_Type.Name = "cmd_Change_Trans_Type";
			cmd_Change_Trans_Type.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Change_Trans_Type.Size = new System.Drawing.Size(149, 28);
			cmd_Change_Trans_Type.TabIndex = 54;
			cmd_Change_Trans_Type.Text = "Change Transaction Type";
			cmd_Change_Trans_Type.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Change_Trans_Type.UseVisualStyleBackColor = false;
			cmd_Change_Trans_Type.Visible = false;
			cmd_Change_Trans_Type.Click += new System.EventHandler(cmd_Change_Trans_Type_Click);
			// 
			// chk_New_to_Market
			// 
			chk_New_to_Market.AllowDrop = true;
			chk_New_to_Market.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_New_to_Market.BackColor = System.Drawing.SystemColors.Control;
			chk_New_to_Market.CausesValidation = true;
			chk_New_to_Market.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_New_to_Market.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_New_to_Market.Enabled = true;
			chk_New_to_Market.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_New_to_Market.ForeColor = System.Drawing.SystemColors.WindowText;
			chk_New_to_Market.Location = new System.Drawing.Point(560, 142);
			chk_New_to_Market.Name = "chk_New_to_Market";
			chk_New_to_Market.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_New_to_Market.Size = new System.Drawing.Size(149, 15);
			chk_New_to_Market.TabIndex = 31;
			chk_New_to_Market.TabStop = true;
			chk_New_to_Market.Text = "New to Market Transaction";
			chk_New_to_Market.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_New_to_Market.Visible = true;
			chk_New_to_Market.CheckStateChanged += new System.EventHandler(chk_New_to_Market_CheckStateChanged);
			// 
			// cmdDelete
			// 
			cmdDelete.AllowDrop = true;
			cmdDelete.BackColor = System.Drawing.SystemColors.Control;
			cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdDelete.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdDelete.Location = new System.Drawing.Point(564, 163);
			cmdDelete.Name = "cmdDelete";
			cmdDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdDelete.Size = new System.Drawing.Size(149, 28);
			cmdDelete.TabIndex = 30;
			cmdDelete.Text = "Delete This Journal Entry";
			cmdDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdDelete.UseVisualStyleBackColor = false;
			cmdDelete.Visible = false;
			cmdDelete.Click += new System.EventHandler(cmdDelete_Click);
			// 
			// cmdDocuments
			// 
			cmdDocuments.AllowDrop = true;
			cmdDocuments.BackColor = System.Drawing.SystemColors.Control;
			cmdDocuments.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdDocuments.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdDocuments.Location = new System.Drawing.Point(802, 228);
			cmdDocuments.Name = "cmdDocuments";
			cmdDocuments.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdDocuments.Size = new System.Drawing.Size(99, 28);
			cmdDocuments.TabIndex = 28;
			cmdDocuments.Text = "Documents";
			cmdDocuments.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdDocuments.UseVisualStyleBackColor = false;
			cmdDocuments.Click += new System.EventHandler(cmdDocuments_Click);
			// 
			// txt_journ_subcategory_code
			// 
			txt_journ_subcategory_code.AcceptsReturn = true;
			txt_journ_subcategory_code.AllowDrop = true;
			txt_journ_subcategory_code.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_journ_subcategory_code.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_journ_subcategory_code.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_journ_subcategory_code.Enabled = false;
			txt_journ_subcategory_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_journ_subcategory_code.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_journ_subcategory_code.Location = new System.Drawing.Point(560, 85);
			txt_journ_subcategory_code.MaxLength = 0;
			txt_journ_subcategory_code.Name = "txt_journ_subcategory_code";
			txt_journ_subcategory_code.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_journ_subcategory_code.Size = new System.Drawing.Size(91, 19);
			txt_journ_subcategory_code.TabIndex = 18;
			// 
			// cmd_Cancel
			// 
			cmd_Cancel.AllowDrop = true;
			cmd_Cancel.BackColor = System.Drawing.SystemColors.Control;
			cmd_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Cancel.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Cancel.Location = new System.Drawing.Point(654, 198);
			cmd_Cancel.Name = "cmd_Cancel";
			cmd_Cancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Cancel.Size = new System.Drawing.Size(57, 28);
			cmd_Cancel.TabIndex = 25;
			cmd_Cancel.Text = "&Cancel";
			cmd_Cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Cancel.UseVisualStyleBackColor = false;
			cmd_Cancel.Visible = false;
			cmd_Cancel.Click += new System.EventHandler(cmd_cancel_Click);
			// 
			// cmd_Save
			// 
			cmd_Save.AllowDrop = true;
			cmd_Save.BackColor = System.Drawing.SystemColors.Control;
			cmd_Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Save.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Save.Location = new System.Drawing.Point(560, 198);
			cmd_Save.Name = "cmd_Save";
			cmd_Save.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Save.Size = new System.Drawing.Size(57, 28);
			cmd_Save.TabIndex = 23;
			cmd_Save.Text = "&Save";
			cmd_Save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Save.UseVisualStyleBackColor = false;
			cmd_Save.Visible = false;
			cmd_Save.Click += new System.EventHandler(cmd_Save_Click);
			// 
			// txt_journ_subject
			// 
			txt_journ_subject.AcceptsReturn = true;
			txt_journ_subject.AllowDrop = true;
			txt_journ_subject.BackColor = System.Drawing.SystemColors.Window;
			txt_journ_subject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_journ_subject.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_journ_subject.Enabled = false;
			txt_journ_subject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_journ_subject.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_journ_subject.Location = new System.Drawing.Point(57, 123);
			txt_journ_subject.MaxLength = 120;
			txt_journ_subject.Name = "txt_journ_subject";
			txt_journ_subject.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_journ_subject.Size = new System.Drawing.Size(500, 21);
			txt_journ_subject.TabIndex = 0;
			// 
			// txt_category
			// 
			txt_category.AcceptsReturn = true;
			txt_category.AllowDrop = true;
			txt_category.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_category.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_category.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_category.Enabled = false;
			txt_category.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_category.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_category.Location = new System.Drawing.Point(84, 85);
			txt_category.MaxLength = 0;
			txt_category.Name = "txt_category";
			txt_category.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_category.Size = new System.Drawing.Size(473, 19);
			txt_category.TabIndex = 17;
			// 
			// txt_journ_date
			// 
			txt_journ_date.AcceptsReturn = true;
			txt_journ_date.AllowDrop = true;
			txt_journ_date.BackColor = System.Drawing.SystemColors.Window;
			txt_journ_date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_journ_date.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_journ_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_journ_date.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_journ_date.Location = new System.Drawing.Point(7, 85);
			txt_journ_date.MaxLength = 10;
			txt_journ_date.Name = "txt_journ_date";
			txt_journ_date.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_journ_date.Size = new System.Drawing.Size(73, 19);
			txt_journ_date.TabIndex = 15;
			txt_journ_date.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// cboDocumentType
			// 
			cboDocumentType.AllowDrop = true;
			cboDocumentType.BackColor = System.Drawing.SystemColors.Window;
			cboDocumentType.CausesValidation = true;
			cboDocumentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboDocumentType.Enabled = true;
			cboDocumentType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cboDocumentType.ForeColor = System.Drawing.SystemColors.WindowText;
			cboDocumentType.IntegralHeight = true;
			cboDocumentType.Location = new System.Drawing.Point(560, 113);
			cboDocumentType.Name = "cboDocumentType";
			cboDocumentType.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cboDocumentType.Size = new System.Drawing.Size(149, 21);
			cboDocumentType.Sorted = false;
			cboDocumentType.TabIndex = 33;
			cboDocumentType.TabStop = true;
			cboDocumentType.Visible = false;
			cboDocumentType.SelectedIndexChanged += new System.EventHandler(cboDocumentType_SelectedIndexChanged);
			// 
			// cboNewSubcategoryCode
			// 
			cboNewSubcategoryCode.AllowDrop = true;
			cboNewSubcategoryCode.BackColor = System.Drawing.SystemColors.Window;
			cboNewSubcategoryCode.CausesValidation = true;
			cboNewSubcategoryCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cboNewSubcategoryCode.Enabled = true;
			cboNewSubcategoryCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cboNewSubcategoryCode.ForeColor = System.Drawing.SystemColors.WindowText;
			cboNewSubcategoryCode.IntegralHeight = true;
			cboNewSubcategoryCode.Location = new System.Drawing.Point(562, 115);
			cboNewSubcategoryCode.Name = "cboNewSubcategoryCode";
			cboNewSubcategoryCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cboNewSubcategoryCode.Size = new System.Drawing.Size(149, 21);
			cboNewSubcategoryCode.Sorted = false;
			cboNewSubcategoryCode.TabIndex = 29;
			cboNewSubcategoryCode.TabStop = true;
			cboNewSubcategoryCode.Visible = false;
			cboNewSubcategoryCode.SelectedIndexChanged += new System.EventHandler(cboNewSubcategoryCode_SelectedIndexChanged);
			// 
			// _lbl_Journal_5
			// 
			_lbl_Journal_5.AllowDrop = true;
			_lbl_Journal_5.BackColor = System.Drawing.SystemColors.Control;
			_lbl_Journal_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_Journal_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_Journal_5.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_Journal_5.Location = new System.Drawing.Point(6, 161);
			_lbl_Journal_5.MinimumSize = new System.Drawing.Size(48, 28);
			_lbl_Journal_5.Name = "_lbl_Journal_5";
			_lbl_Journal_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_Journal_5.Size = new System.Drawing.Size(48, 28);
			_lbl_Journal_5.TabIndex = 56;
			_lbl_Journal_5.Text = "Internal Notes:";
			_lbl_Journal_5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblSubCategoryCode
			// 
			lblSubCategoryCode.AllowDrop = true;
			lblSubCategoryCode.AutoSize = true;
			lblSubCategoryCode.BackColor = System.Drawing.Color.Transparent;
			lblSubCategoryCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblSubCategoryCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblSubCategoryCode.ForeColor = System.Drawing.SystemColors.ControlText;
			lblSubCategoryCode.Location = new System.Drawing.Point(562, 71);
			lblSubCategoryCode.MinimumSize = new System.Drawing.Size(90, 13);
			lblSubCategoryCode.Name = "lblSubCategoryCode";
			lblSubCategoryCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblSubCategoryCode.Size = new System.Drawing.Size(90, 13);
			lblSubCategoryCode.TabIndex = 24;
			lblSubCategoryCode.Text = "Subcategory Code:";
			lblSubCategoryCode.DoubleClick += new System.EventHandler(lblSubCategoryCode_DoubleClick);
			// 
			// _lbl_Journal_3
			// 
			_lbl_Journal_3.AllowDrop = true;
			_lbl_Journal_3.BackColor = System.Drawing.SystemColors.Control;
			_lbl_Journal_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_Journal_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_Journal_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_Journal_3.Location = new System.Drawing.Point(6, 222);
			_lbl_Journal_3.MinimumSize = new System.Drawing.Size(48, 28);
			_lbl_Journal_3.Name = "_lbl_Journal_3";
			_lbl_Journal_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_Journal_3.Size = new System.Drawing.Size(48, 28);
			_lbl_Journal_3.TabIndex = 22;
			_lbl_Journal_3.Text = "Customer Notes:";
			_lbl_Journal_3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// _lbl_Journal_4
			// 
			_lbl_Journal_4.AllowDrop = true;
			_lbl_Journal_4.AutoSize = true;
			_lbl_Journal_4.BackColor = System.Drawing.SystemColors.Control;
			_lbl_Journal_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_Journal_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_Journal_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_Journal_4.Location = new System.Drawing.Point(6, 125);
			_lbl_Journal_4.MinimumSize = new System.Drawing.Size(48, 17);
			_lbl_Journal_4.Name = "_lbl_Journal_4";
			_lbl_Journal_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_Journal_4.Size = new System.Drawing.Size(48, 17);
			_lbl_Journal_4.TabIndex = 6;
			_lbl_Journal_4.Text = "Subject:";
			_lbl_Journal_4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// _lbl_Journal_2
			// 
			_lbl_Journal_2.AllowDrop = true;
			_lbl_Journal_2.AutoSize = true;
			_lbl_Journal_2.BackColor = System.Drawing.SystemColors.Control;
			_lbl_Journal_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_Journal_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_Journal_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_Journal_2.Location = new System.Drawing.Point(84, 71);
			_lbl_Journal_2.MinimumSize = new System.Drawing.Size(45, 13);
			_lbl_Journal_2.Name = "_lbl_Journal_2";
			_lbl_Journal_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_Journal_2.Size = new System.Drawing.Size(45, 13);
			_lbl_Journal_2.TabIndex = 5;
			_lbl_Journal_2.Text = "Category:";
			// 
			// _lbl_Journal_1
			// 
			_lbl_Journal_1.AllowDrop = true;
			_lbl_Journal_1.AutoSize = true;
			_lbl_Journal_1.BackColor = System.Drawing.SystemColors.Control;
			_lbl_Journal_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_Journal_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_Journal_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_Journal_1.Location = new System.Drawing.Point(7, 71);
			_lbl_Journal_1.MinimumSize = new System.Drawing.Size(26, 13);
			_lbl_Journal_1.Name = "_lbl_Journal_1";
			_lbl_Journal_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_Journal_1.Size = new System.Drawing.Size(26, 13);
			_lbl_Journal_1.TabIndex = 4;
			_lbl_Journal_1.Text = "Date:";
			// 
			// frame_MajorChange
			// 
			frame_MajorChange.AllowDrop = true;
			frame_MajorChange.BackColor = System.Drawing.SystemColors.Control;
			frame_MajorChange.Controls.Add(cmd_MajorChange);
			frame_MajorChange.Controls.Add(frame_BuyerSeller);
			frame_MajorChange.Controls.Add(cmd_Major_Cancel);
			frame_MajorChange.Controls.Add(cbo_New_TransType);
			frame_MajorChange.Controls.Add(Label4);
			frame_MajorChange.Controls.Add(lbl_Current_TransType);
			frame_MajorChange.Controls.Add(Label3);
			frame_MajorChange.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frame_MajorChange.Enabled = true;
			frame_MajorChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frame_MajorChange.ForeColor = System.Drawing.SystemColors.ControlText;
			frame_MajorChange.Location = new System.Drawing.Point(187, 51);
			frame_MajorChange.Name = "frame_MajorChange";
			frame_MajorChange.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frame_MajorChange.Size = new System.Drawing.Size(609, 305);
			frame_MajorChange.TabIndex = 34;
			frame_MajorChange.Text = "Change the Transaction Type";
			frame_MajorChange.Visible = true;
			// 
			// cmd_MajorChange
			// 
			cmd_MajorChange.AllowDrop = true;
			cmd_MajorChange.BackColor = System.Drawing.SystemColors.Control;
			cmd_MajorChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_MajorChange.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_MajorChange.Location = new System.Drawing.Point(440, 264);
			cmd_MajorChange.Name = "cmd_MajorChange";
			cmd_MajorChange.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_MajorChange.Size = new System.Drawing.Size(145, 25);
			cmd_MajorChange.TabIndex = 53;
			cmd_MajorChange.Text = "Commit Transaction Change";
			cmd_MajorChange.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_MajorChange.UseVisualStyleBackColor = false;
			cmd_MajorChange.Click += new System.EventHandler(cmd_MajorChange_Click);
			// 
			// frame_BuyerSeller
			// 
			frame_BuyerSeller.AllowDrop = true;
			frame_BuyerSeller.BackColor = System.Drawing.SystemColors.Control;
			frame_BuyerSeller.Controls.Add(frame_Current);
			frame_BuyerSeller.Controls.Add(txt_Purchaser_Percent);
			frame_BuyerSeller.Controls.Add(Line5);
			frame_BuyerSeller.Controls.Add(Line4);
			frame_BuyerSeller.Controls.Add(Label1);
			frame_BuyerSeller.Controls.Add(Label2);
			frame_BuyerSeller.Controls.Add(lbl_Seller_Name);
			frame_BuyerSeller.Controls.Add(lbl_Purchaser_Name);
			frame_BuyerSeller.Controls.Add(Line1);
			frame_BuyerSeller.Controls.Add(Line2);
			frame_BuyerSeller.Controls.Add(Line3);
			frame_BuyerSeller.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frame_BuyerSeller.Enabled = true;
			frame_BuyerSeller.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frame_BuyerSeller.ForeColor = System.Drawing.SystemColors.ControlText;
			frame_BuyerSeller.Location = new System.Drawing.Point(16, 80);
			frame_BuyerSeller.Name = "frame_BuyerSeller";
			frame_BuyerSeller.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frame_BuyerSeller.Size = new System.Drawing.Size(569, 177);
			frame_BuyerSeller.TabIndex = 40;
			frame_BuyerSeller.Text = "Seller and Purchaser Information";
			frame_BuyerSeller.Visible = true;
			// 
			// frame_Current
			// 
			frame_Current.AllowDrop = true;
			frame_Current.BackColor = System.Drawing.SystemColors.Control;
			frame_Current.Controls.Add(chk_ApplytoCurrent);
			frame_Current.Controls.Add(txt_Current_Seller_Percent);
			frame_Current.Controls.Add(txt_Current_Purchaser_Percent);
			frame_Current.Controls.Add(Label7);
			frame_Current.Controls.Add(Label6);
			frame_Current.Controls.Add(Label5);
			frame_Current.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frame_Current.Enabled = true;
			frame_Current.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frame_Current.ForeColor = System.Drawing.SystemColors.ControlText;
			frame_Current.Location = new System.Drawing.Point(368, 8);
			frame_Current.Name = "frame_Current";
			frame_Current.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frame_Current.Size = new System.Drawing.Size(193, 161);
			frame_Current.TabIndex = 46;
			frame_Current.Text = "Apply to Current Aircraft";
			frame_Current.Visible = true;
			// 
			// chk_ApplytoCurrent
			// 
			chk_ApplytoCurrent.AllowDrop = true;
			chk_ApplytoCurrent.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_ApplytoCurrent.BackColor = System.Drawing.SystemColors.Control;
			chk_ApplytoCurrent.CausesValidation = true;
			chk_ApplytoCurrent.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_ApplytoCurrent.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_ApplytoCurrent.Enabled = true;
			chk_ApplytoCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_ApplytoCurrent.ForeColor = System.Drawing.SystemColors.WindowText;
			chk_ApplytoCurrent.Location = new System.Drawing.Point(8, 120);
			chk_ApplytoCurrent.Name = "chk_ApplytoCurrent";
			chk_ApplytoCurrent.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_ApplytoCurrent.Size = new System.Drawing.Size(161, 33);
			chk_ApplytoCurrent.TabIndex = 49;
			chk_ApplytoCurrent.TabStop = true;
			chk_ApplytoCurrent.Text = "Apply to the Current Aircraft";
			chk_ApplytoCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_ApplytoCurrent.Visible = true;
			chk_ApplytoCurrent.CheckStateChanged += new System.EventHandler(chk_ApplytoCurrent_CheckStateChanged);
			// 
			// txt_Current_Seller_Percent
			// 
			txt_Current_Seller_Percent.AcceptsReturn = true;
			txt_Current_Seller_Percent.AllowDrop = true;
			txt_Current_Seller_Percent.BackColor = System.Drawing.SystemColors.Window;
			txt_Current_Seller_Percent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_Current_Seller_Percent.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_Current_Seller_Percent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_Current_Seller_Percent.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_Current_Seller_Percent.Location = new System.Drawing.Point(8, 40);
			txt_Current_Seller_Percent.MaxLength = 0;
			txt_Current_Seller_Percent.Name = "txt_Current_Seller_Percent";
			txt_Current_Seller_Percent.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_Current_Seller_Percent.Size = new System.Drawing.Size(33, 19);
			txt_Current_Seller_Percent.TabIndex = 48;
			// 
			// txt_Current_Purchaser_Percent
			// 
			txt_Current_Purchaser_Percent.AcceptsReturn = true;
			txt_Current_Purchaser_Percent.AllowDrop = true;
			txt_Current_Purchaser_Percent.BackColor = System.Drawing.SystemColors.Window;
			txt_Current_Purchaser_Percent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_Current_Purchaser_Percent.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_Current_Purchaser_Percent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_Current_Purchaser_Percent.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_Current_Purchaser_Percent.Location = new System.Drawing.Point(8, 72);
			txt_Current_Purchaser_Percent.MaxLength = 0;
			txt_Current_Purchaser_Percent.Name = "txt_Current_Purchaser_Percent";
			txt_Current_Purchaser_Percent.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_Current_Purchaser_Percent.Size = new System.Drawing.Size(33, 19);
			txt_Current_Purchaser_Percent.TabIndex = 47;
			// 
			// Label7
			// 
			Label7.AllowDrop = true;
			Label7.BackColor = System.Drawing.Color.Transparent;
			Label7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label7.ForeColor = System.Drawing.SystemColors.ControlText;
			Label7.Location = new System.Drawing.Point(40, 72);
			Label7.MinimumSize = new System.Drawing.Size(17, 17);
			Label7.Name = "Label7";
			Label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label7.Size = new System.Drawing.Size(17, 17);
			Label7.TabIndex = 52;
			Label7.Text = "%";
			// 
			// Label6
			// 
			Label6.AllowDrop = true;
			Label6.BackColor = System.Drawing.Color.Transparent;
			Label6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label6.ForeColor = System.Drawing.SystemColors.ControlText;
			Label6.Location = new System.Drawing.Point(40, 40);
			Label6.MinimumSize = new System.Drawing.Size(17, 17);
			Label6.Name = "Label6";
			Label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label6.Size = new System.Drawing.Size(17, 17);
			Label6.TabIndex = 51;
			Label6.Text = "%";
			// 
			// Label5
			// 
			Label5.AllowDrop = true;
			Label5.BackColor = System.Drawing.Color.Transparent;
			Label5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label5.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
			Label5.Location = new System.Drawing.Point(56, 16);
			Label5.MinimumSize = new System.Drawing.Size(137, 113);
			Label5.Name = "Label5";
			Label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label5.Size = new System.Drawing.Size(137, 113);
			Label5.TabIndex = 50;
			Label5.Text = "The purchaser on this transaction is the same as the current owner. Check the box below if you would also like to make changes to ownership on the current aircraft.";
			// 
			// txt_Purchaser_Percent
			// 
			txt_Purchaser_Percent.AcceptsReturn = true;
			txt_Purchaser_Percent.AllowDrop = true;
			txt_Purchaser_Percent.BackColor = System.Drawing.SystemColors.Window;
			txt_Purchaser_Percent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_Purchaser_Percent.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_Purchaser_Percent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_Purchaser_Percent.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_Purchaser_Percent.Location = new System.Drawing.Point(328, 80);
			txt_Purchaser_Percent.MaxLength = 0;
			txt_Purchaser_Percent.Name = "txt_Purchaser_Percent";
			txt_Purchaser_Percent.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_Purchaser_Percent.Size = new System.Drawing.Size(33, 19);
			txt_Purchaser_Percent.TabIndex = 41;
			txt_Purchaser_Percent.Text = "%";
			// 
			// Line5
			// 
			Line5.AllowDrop = true;
			Line5.BackColor = System.Drawing.SystemColors.WindowText;
			Line5.Enabled = false;
			Line5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Line5.Location = new System.Drawing.Point(368, 40);
			Line5.Name = "Line5";
			Line5.Size = new System.Drawing.Size(1, 64);
			Line5.Visible = true;
			// 
			// Line4
			// 
			Line4.AllowDrop = true;
			Line4.BackColor = System.Drawing.SystemColors.WindowText;
			Line4.Enabled = false;
			Line4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Line4.Location = new System.Drawing.Point(320, 40);
			Line4.Name = "Line4";
			Line4.Size = new System.Drawing.Size(1, 64);
			Line4.Visible = true;
			// 
			// Label1
			// 
			Label1.AllowDrop = true;
			Label1.BackColor = System.Drawing.Color.Transparent;
			Label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label1.ForeColor = System.Drawing.SystemColors.ControlText;
			Label1.Location = new System.Drawing.Point(8, 48);
			Label1.MinimumSize = new System.Drawing.Size(41, 17);
			Label1.Name = "Label1";
			Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label1.Size = new System.Drawing.Size(41, 17);
			Label1.TabIndex = 45;
			Label1.Text = "Seller:";
			// 
			// Label2
			// 
			Label2.AllowDrop = true;
			Label2.BackColor = System.Drawing.Color.Transparent;
			Label2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label2.ForeColor = System.Drawing.SystemColors.ControlText;
			Label2.Location = new System.Drawing.Point(8, 80);
			Label2.MinimumSize = new System.Drawing.Size(65, 17);
			Label2.Name = "Label2";
			Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label2.Size = new System.Drawing.Size(65, 17);
			Label2.TabIndex = 44;
			Label2.Text = "Purchaser:";
			// 
			// lbl_Seller_Name
			// 
			lbl_Seller_Name.AllowDrop = true;
			lbl_Seller_Name.BackColor = System.Drawing.Color.Transparent;
			lbl_Seller_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_Seller_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_Seller_Name.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_Seller_Name.Location = new System.Drawing.Point(64, 48);
			lbl_Seller_Name.MinimumSize = new System.Drawing.Size(249, 17);
			lbl_Seller_Name.Name = "lbl_Seller_Name";
			lbl_Seller_Name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_Seller_Name.Size = new System.Drawing.Size(249, 17);
			lbl_Seller_Name.TabIndex = 43;
			lbl_Seller_Name.Text = "Purchaser Name";
			// 
			// lbl_Purchaser_Name
			// 
			lbl_Purchaser_Name.AllowDrop = true;
			lbl_Purchaser_Name.BackColor = System.Drawing.Color.Transparent;
			lbl_Purchaser_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_Purchaser_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_Purchaser_Name.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_Purchaser_Name.Location = new System.Drawing.Point(64, 80);
			lbl_Purchaser_Name.MinimumSize = new System.Drawing.Size(249, 17);
			lbl_Purchaser_Name.Name = "lbl_Purchaser_Name";
			lbl_Purchaser_Name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_Purchaser_Name.Size = new System.Drawing.Size(249, 17);
			lbl_Purchaser_Name.TabIndex = 42;
			lbl_Purchaser_Name.Text = "Purchaser Name";
			// 
			// Line1
			// 
			Line1.AllowDrop = true;
			Line1.BackColor = System.Drawing.SystemColors.WindowText;
			Line1.Enabled = false;
			Line1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Line1.Location = new System.Drawing.Point(8, 40);
			Line1.Name = "Line1";
			Line1.Size = new System.Drawing.Size(360, 1);
			Line1.Visible = true;
			// 
			// Line2
			// 
			Line2.AllowDrop = true;
			Line2.BackColor = System.Drawing.SystemColors.WindowText;
			Line2.Enabled = false;
			Line2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Line2.Location = new System.Drawing.Point(8, 72);
			Line2.Name = "Line2";
			Line2.Size = new System.Drawing.Size(360, 1);
			Line2.Visible = true;
			// 
			// Line3
			// 
			Line3.AllowDrop = true;
			Line3.BackColor = System.Drawing.SystemColors.WindowText;
			Line3.Enabled = false;
			Line3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Line3.Location = new System.Drawing.Point(8, 104);
			Line3.Name = "Line3";
			Line3.Size = new System.Drawing.Size(360, 1);
			Line3.Visible = true;
			// 
			// cmd_Major_Cancel
			// 
			cmd_Major_Cancel.AllowDrop = true;
			cmd_Major_Cancel.BackColor = System.Drawing.SystemColors.Control;
			cmd_Major_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Major_Cancel.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Major_Cancel.Location = new System.Drawing.Point(360, 264);
			cmd_Major_Cancel.Name = "cmd_Major_Cancel";
			cmd_Major_Cancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Major_Cancel.Size = new System.Drawing.Size(73, 25);
			cmd_Major_Cancel.TabIndex = 39;
			cmd_Major_Cancel.Text = "Cancel";
			cmd_Major_Cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Major_Cancel.UseVisualStyleBackColor = false;
			cmd_Major_Cancel.Click += new System.EventHandler(cmd_Major_Cancel_Click);
			// 
			// cbo_New_TransType
			// 
			cbo_New_TransType.AllowDrop = true;
			cbo_New_TransType.BackColor = System.Drawing.SystemColors.Window;
			cbo_New_TransType.CausesValidation = true;
			cbo_New_TransType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_New_TransType.Enabled = true;
			cbo_New_TransType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_New_TransType.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_New_TransType.IntegralHeight = true;
			cbo_New_TransType.Location = new System.Drawing.Point(96, 48);
			cbo_New_TransType.Name = "cbo_New_TransType";
			cbo_New_TransType.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_New_TransType.Size = new System.Drawing.Size(193, 21);
			cbo_New_TransType.Sorted = false;
			cbo_New_TransType.TabIndex = 38;
			cbo_New_TransType.TabStop = true;
			cbo_New_TransType.Visible = true;
			cbo_New_TransType.SelectedIndexChanged += new System.EventHandler(cbo_New_TransType_SelectedIndexChanged);
			// 
			// Label4
			// 
			Label4.AllowDrop = true;
			Label4.BackColor = System.Drawing.SystemColors.Control;
			Label4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label4.ForeColor = System.Drawing.SystemColors.ControlText;
			Label4.Location = new System.Drawing.Point(16, 48);
			Label4.MinimumSize = new System.Drawing.Size(105, 25);
			Label4.Name = "Label4";
			Label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label4.Size = new System.Drawing.Size(105, 25);
			Label4.TabIndex = 37;
			Label4.Text = "Changing To:";
			// 
			// lbl_Current_TransType
			// 
			lbl_Current_TransType.AllowDrop = true;
			lbl_Current_TransType.BackColor = System.Drawing.SystemColors.Control;
			lbl_Current_TransType.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_Current_TransType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_Current_TransType.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_Current_TransType.Location = new System.Drawing.Point(96, 24);
			lbl_Current_TransType.MinimumSize = new System.Drawing.Size(233, 25);
			lbl_Current_TransType.Name = "lbl_Current_TransType";
			lbl_Current_TransType.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_Current_TransType.Size = new System.Drawing.Size(233, 25);
			lbl_Current_TransType.TabIndex = 36;
			lbl_Current_TransType.Text = "Changing From:";
			// 
			// Label3
			// 
			Label3.AllowDrop = true;
			Label3.BackColor = System.Drawing.SystemColors.Control;
			Label3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label3.ForeColor = System.Drawing.SystemColors.ControlText;
			Label3.Location = new System.Drawing.Point(16, 24);
			Label3.MinimumSize = new System.Drawing.Size(105, 25);
			Label3.Name = "Label3";
			Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label3.Size = new System.Drawing.Size(105, 25);
			Label3.TabIndex = 35;
			Label3.Text = "Changing From:";
			// 
			// frm_Journal
			// 
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Window;
			ClientSize = new System.Drawing.Size(1000, 421);
			Controls.Add(pnl_Company);
			Controls.Add(pnl_Contact);
			Controls.Add(pnl_Aircraft);
			Controls.Add(pnl_AddContact);
			Controls.Add(pnl_Journal_Data);
			Controls.Add(frame_MajorChange);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			Location = new System.Drawing.Point(397, 271);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "frm_Journal";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			Text = "Journal";
			commandButtonHelper1.SetStyle(cmdCancelAddContact, 0);
			commandButtonHelper1.SetStyle(cmdSaveAddContact, 0);
			commandButtonHelper1.SetStyle(cmd_Change_Trans_Type, 0);
			commandButtonHelper1.SetStyle(cmdDelete, 0);
			commandButtonHelper1.SetStyle(cmdDocuments, 0);
			commandButtonHelper1.SetStyle(cmd_Cancel, 0);
			commandButtonHelper1.SetStyle(cmd_Save, 0);
			commandButtonHelper1.SetStyle(cmd_MajorChange, 0);
			commandButtonHelper1.SetStyle(cmd_Major_Cancel, 0);
			listBoxHelper1.SetSelectionMode(lst_comp_info, System.Windows.Forms.SelectionMode.One);
			listBoxHelper1.SetSelectionMode(lst_contact_info, System.Windows.Forms.SelectionMode.One);
			listBoxHelper1.SetSelectionMode(lst_aircraft_info, System.Windows.Forms.SelectionMode.One);
			optionButtonHelper1.SetStyle(_radio_id_2, 0);
			optionButtonHelper1.SetStyle(_radio_id_1, 0);
			optionButtonHelper1.SetStyle(_radio_id_0, 0);
			Activated += new System.EventHandler(Form_Activated);
			Closed += new System.EventHandler(Form_Closed);
			((System.ComponentModel.ISupportInitialize) grdTransactionDocuments).EndInit();
			pnl_Company.ResumeLayout(false);
			pnl_Company.PerformLayout();
			pnl_Contact.ResumeLayout(false);
			pnl_Contact.PerformLayout();
			pnl_Aircraft.ResumeLayout(false);
			pnl_Aircraft.PerformLayout();
			pnl_AddContact.ResumeLayout(false);
			pnl_AddContact.PerformLayout();
			pnl_Journal_Data.ResumeLayout(false);
			pnl_Journal_Data.PerformLayout();
			pnl_Journal_Heading.ResumeLayout(false);
			pnl_Journal_Heading.PerformLayout();
			frame_MajorChange.ResumeLayout(false);
			frame_MajorChange.PerformLayout();
			frame_BuyerSeller.ResumeLayout(false);
			frame_BuyerSeller.PerformLayout();
			frame_Current.ResumeLayout(false);
			frame_Current.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
		void ReLoadForm(bool addEvents)
		{
			Initializeradio_id();
			Initializelbl_Journal();
		}
		void Initializeradio_id()
		{
			radio_id = new System.Windows.Forms.RadioButton[3];
			radio_id[2] = _radio_id_2;
			radio_id[1] = _radio_id_1;
			radio_id[0] = _radio_id_0;
		}
		void Initializelbl_Journal()
		{
			lbl_Journal = new System.Windows.Forms.Label[11];
			lbl_Journal[6] = _lbl_Journal_6;
			lbl_Journal[7] = _lbl_Journal_7;
			lbl_Journal[8] = _lbl_Journal_8;
			lbl_Journal[9] = _lbl_Journal_9;
			lbl_Journal[10] = _lbl_Journal_10;
			lbl_Journal[0] = _lbl_Journal_0;
			lbl_Journal[5] = _lbl_Journal_5;
			lbl_Journal[3] = _lbl_Journal_3;
			lbl_Journal[4] = _lbl_Journal_4;
			lbl_Journal[2] = _lbl_Journal_2;
			lbl_Journal[1] = _lbl_Journal_1;
		}
		#endregion
	}
}