
namespace JETNET_Homebase
{
	partial class frm_CompanyAdd
	{

		#region "Upgrade Support "
		private static frm_CompanyAdd m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_CompanyAdd DefInstance
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
		public static frm_CompanyAdd CreateInstance()
		{
			frm_CompanyAdd theInstance = new frm_CompanyAdd();
			theInstance.Form_Load();
			return theInstance;
		}
		bool fTerminateCalled_Form_Terminate;
		private string[] visualControls = new string[]{"components", "ToolTipMain", "chk_hide_company", "cmd_copy_company", "chkCompContactAddressFlag", "_Text1_33", "_Text1_32", "cmb_product_code", "cmb_agency_type", "cmb_state_code", "cmb_country_code", "chk_auto_account_rep", "_Text1_31", "_Text1_12", "_Text1_27", "chk_attach_to_contact", "_Text1_30", "_Text1_29", "_Text1_28", "cmb_comp_name_alt_type", "_Text1_26", "chk_hide_from_customer", "_Text1_25", "_cmd_CompanyAction_0", "_cmd_CompanyAction_1", "_cmd_CompanyAction_2", "_Text1_22", "cmb_contact_title", "cmb_suffix", "_Text1_24", "_Text1_23", "cmb_sirname", "_Text1_21", "_Text1_18", "_Text1_20", "_Text1_17", "_Text1_19", "_Text1_14", "_Text1_16", "_Text1_13", "_Text1_15", "_cmb_phone_type_2", "_cmb_phone_type_3", "_Text1_10", "_Text1_9", "_Text1_11", "_Text1_6", "_Text1_8", "_Text1_5", "_Text1_7", "_cmb_phone_type_1", "_cmb_phone_type_0", "cmb_account_id", "cmb_account_type", "cmb_language", "cmb_business_type", "_Text1_4", "_Text1_3", "_Text1_2", "_Text1_1", "_Text1_0", "_Label1_52", "_Label1_51", "_Label1_50", "_Shape1_0", "_Label1_7", "_Label1_6", "_Label1_10", "_Label1_49", "_Shape1_2", "_Label1_48", "_Label1_47", "_Label1_46", "_Label1_45", "_Label1_44", "_Label1_43", "_Label1_42", "_Label1_37", "_Label1_41", "_Shape1_1", "_Label1_40", "_Label1_39", "_Label1_38", "_Label1_36", "_Label1_35", "_Label1_34", "_Label1_33", "_Label1_32", "_Label1_31", "_Label1_30", "_Label1_29", "_Label1_28", "_Label1_27", "_Label1_26", "_Label1_25", "_Label1_24", "_Label1_23", "_Label1_22", "_Label1_21", "_Label1_20", "_Label1_19", "_Label1_18", "_Label1_15", "_Label1_16", "_Label1_17", "_Label1_14", "_Label1_13", "_Label1_0", "_Label1_1", "_Label1_2", "_Label1_3", "_Label1_4", "_Label1_12", "_Label1_11", "lbl_status_display", "_Label1_9", "_Label1_8", "_Label1_5", "Label1", "Shape1", "Text1", "cmb_phone_type", "cmd_CompanyAction", "listBoxComboBoxHelper1", "commandButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.CheckBox chk_hide_company;
		public System.Windows.Forms.Button cmd_copy_company;
		public System.Windows.Forms.CheckBox chkCompContactAddressFlag;
		private System.Windows.Forms.TextBox _Text1_33;
		private System.Windows.Forms.TextBox _Text1_32;
		public System.Windows.Forms.ComboBox cmb_product_code;
		public System.Windows.Forms.ComboBox cmb_agency_type;
		public System.Windows.Forms.ComboBox cmb_state_code;
		public System.Windows.Forms.ComboBox cmb_country_code;
		public System.Windows.Forms.CheckBox chk_auto_account_rep;
		private System.Windows.Forms.TextBox _Text1_31;
		private System.Windows.Forms.TextBox _Text1_12;
		private System.Windows.Forms.TextBox _Text1_27;
		public System.Windows.Forms.CheckBox chk_attach_to_contact;
		private System.Windows.Forms.TextBox _Text1_30;
		private System.Windows.Forms.TextBox _Text1_29;
		private System.Windows.Forms.TextBox _Text1_28;
		public System.Windows.Forms.ComboBox cmb_comp_name_alt_type;
		private System.Windows.Forms.TextBox _Text1_26;
		public System.Windows.Forms.CheckBox chk_hide_from_customer;
		private System.Windows.Forms.TextBox _Text1_25;
		private System.Windows.Forms.Button _cmd_CompanyAction_0;
		private System.Windows.Forms.Button _cmd_CompanyAction_1;
		private System.Windows.Forms.Button _cmd_CompanyAction_2;
		private System.Windows.Forms.TextBox _Text1_22;
		public System.Windows.Forms.ComboBox cmb_contact_title;
		public System.Windows.Forms.ComboBox cmb_suffix;
		private System.Windows.Forms.TextBox _Text1_24;
		private System.Windows.Forms.TextBox _Text1_23;
		public System.Windows.Forms.ComboBox cmb_sirname;
		private System.Windows.Forms.TextBox _Text1_21;
		private System.Windows.Forms.TextBox _Text1_18;
		private System.Windows.Forms.TextBox _Text1_20;
		private System.Windows.Forms.TextBox _Text1_17;
		private System.Windows.Forms.TextBox _Text1_19;
		private System.Windows.Forms.TextBox _Text1_14;
		private System.Windows.Forms.TextBox _Text1_16;
		private System.Windows.Forms.TextBox _Text1_13;
		private System.Windows.Forms.TextBox _Text1_15;
		private System.Windows.Forms.ComboBox _cmb_phone_type_2;
		private System.Windows.Forms.ComboBox _cmb_phone_type_3;
		private System.Windows.Forms.TextBox _Text1_10;
		private System.Windows.Forms.TextBox _Text1_9;
		private System.Windows.Forms.TextBox _Text1_11;
		private System.Windows.Forms.TextBox _Text1_6;
		private System.Windows.Forms.TextBox _Text1_8;
		private System.Windows.Forms.TextBox _Text1_5;
		private System.Windows.Forms.TextBox _Text1_7;
		private System.Windows.Forms.ComboBox _cmb_phone_type_1;
		private System.Windows.Forms.ComboBox _cmb_phone_type_0;
		public System.Windows.Forms.ComboBox cmb_account_id;
		public System.Windows.Forms.ComboBox cmb_account_type;
		public System.Windows.Forms.ComboBox cmb_language;
		public System.Windows.Forms.ComboBox cmb_business_type;
		private System.Windows.Forms.TextBox _Text1_4;
		private System.Windows.Forms.TextBox _Text1_3;
		private System.Windows.Forms.TextBox _Text1_2;
		private System.Windows.Forms.TextBox _Text1_1;
		private System.Windows.Forms.TextBox _Text1_0;
		private System.Windows.Forms.Label _Label1_52;
		private System.Windows.Forms.Label _Label1_51;
		private System.Windows.Forms.Label _Label1_50;
		private UpgradeHelpers.Gui.ShapeHelper _Shape1_0;
		private System.Windows.Forms.Label _Label1_7;
		private System.Windows.Forms.Label _Label1_6;
		private System.Windows.Forms.Label _Label1_10;
		private System.Windows.Forms.Label _Label1_49;
		private UpgradeHelpers.Gui.ShapeHelper _Shape1_2;
		private System.Windows.Forms.Label _Label1_48;
		private System.Windows.Forms.Label _Label1_47;
		private System.Windows.Forms.Label _Label1_46;
		private System.Windows.Forms.Label _Label1_45;
		private System.Windows.Forms.Label _Label1_44;
		private System.Windows.Forms.Label _Label1_43;
		private System.Windows.Forms.Label _Label1_42;
		private System.Windows.Forms.Label _Label1_37;
		private System.Windows.Forms.Label _Label1_41;
		private UpgradeHelpers.Gui.ShapeHelper _Shape1_1;
		private System.Windows.Forms.Label _Label1_40;
		private System.Windows.Forms.Label _Label1_39;
		private System.Windows.Forms.Label _Label1_38;
		private System.Windows.Forms.Label _Label1_36;
		private System.Windows.Forms.Label _Label1_35;
		private System.Windows.Forms.Label _Label1_34;
		private System.Windows.Forms.Label _Label1_33;
		private System.Windows.Forms.Label _Label1_32;
		private System.Windows.Forms.Label _Label1_31;
		private System.Windows.Forms.Label _Label1_30;
		private System.Windows.Forms.Label _Label1_29;
		private System.Windows.Forms.Label _Label1_28;
		private System.Windows.Forms.Label _Label1_27;
		private System.Windows.Forms.Label _Label1_26;
		private System.Windows.Forms.Label _Label1_25;
		private System.Windows.Forms.Label _Label1_24;
		private System.Windows.Forms.Label _Label1_23;
		private System.Windows.Forms.Label _Label1_22;
		private System.Windows.Forms.Label _Label1_21;
		private System.Windows.Forms.Label _Label1_20;
		private System.Windows.Forms.Label _Label1_19;
		private System.Windows.Forms.Label _Label1_18;
		private System.Windows.Forms.Label _Label1_15;
		private System.Windows.Forms.Label _Label1_16;
		private System.Windows.Forms.Label _Label1_17;
		private System.Windows.Forms.Label _Label1_14;
		private System.Windows.Forms.Label _Label1_13;
		private System.Windows.Forms.Label _Label1_0;
		private System.Windows.Forms.Label _Label1_1;
		private System.Windows.Forms.Label _Label1_2;
		private System.Windows.Forms.Label _Label1_3;
		private System.Windows.Forms.Label _Label1_4;
		private System.Windows.Forms.Label _Label1_12;
		private System.Windows.Forms.Label _Label1_11;
		public System.Windows.Forms.Label lbl_status_display;
		private System.Windows.Forms.Label _Label1_9;
		private System.Windows.Forms.Label _Label1_8;
		private System.Windows.Forms.Label _Label1_5;
		public System.Windows.Forms.Label[] Label1 = new System.Windows.Forms.Label[53];
		public UpgradeHelpers.Gui.ShapeHelper[] Shape1 = new UpgradeHelpers.Gui.ShapeHelper[3];
		public System.Windows.Forms.TextBox[] Text1 = new System.Windows.Forms.TextBox[34];
		public System.Windows.Forms.ComboBox[] cmb_phone_type = new System.Windows.Forms.ComboBox[4];
		public System.Windows.Forms.Button[] cmd_CompanyAction = new System.Windows.Forms.Button[3];
		public UpgradeHelpers.Gui.Controls.ListControlHelper listBoxComboBoxHelper1;
		public UpgradeHelpers.Gui.Controls.CommandButtonHelper commandButtonHelper1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_CompanyAdd));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			chk_hide_company = new System.Windows.Forms.CheckBox();
			cmd_copy_company = new System.Windows.Forms.Button();
			chkCompContactAddressFlag = new System.Windows.Forms.CheckBox();
			_Text1_33 = new System.Windows.Forms.TextBox();
			_Text1_32 = new System.Windows.Forms.TextBox();
			cmb_product_code = new System.Windows.Forms.ComboBox();
			cmb_agency_type = new System.Windows.Forms.ComboBox();
			cmb_state_code = new System.Windows.Forms.ComboBox();
			cmb_country_code = new System.Windows.Forms.ComboBox();
			chk_auto_account_rep = new System.Windows.Forms.CheckBox();
			_Text1_31 = new System.Windows.Forms.TextBox();
			_Text1_12 = new System.Windows.Forms.TextBox();
			_Text1_27 = new System.Windows.Forms.TextBox();
			chk_attach_to_contact = new System.Windows.Forms.CheckBox();
			_Text1_30 = new System.Windows.Forms.TextBox();
			_Text1_29 = new System.Windows.Forms.TextBox();
			_Text1_28 = new System.Windows.Forms.TextBox();
			cmb_comp_name_alt_type = new System.Windows.Forms.ComboBox();
			_Text1_26 = new System.Windows.Forms.TextBox();
			chk_hide_from_customer = new System.Windows.Forms.CheckBox();
			_Text1_25 = new System.Windows.Forms.TextBox();
			_cmd_CompanyAction_0 = new System.Windows.Forms.Button();
			_cmd_CompanyAction_1 = new System.Windows.Forms.Button();
			_cmd_CompanyAction_2 = new System.Windows.Forms.Button();
			_Text1_22 = new System.Windows.Forms.TextBox();
			cmb_contact_title = new System.Windows.Forms.ComboBox();
			cmb_suffix = new System.Windows.Forms.ComboBox();
			_Text1_24 = new System.Windows.Forms.TextBox();
			_Text1_23 = new System.Windows.Forms.TextBox();
			cmb_sirname = new System.Windows.Forms.ComboBox();
			_Text1_21 = new System.Windows.Forms.TextBox();
			_Text1_18 = new System.Windows.Forms.TextBox();
			_Text1_20 = new System.Windows.Forms.TextBox();
			_Text1_17 = new System.Windows.Forms.TextBox();
			_Text1_19 = new System.Windows.Forms.TextBox();
			_Text1_14 = new System.Windows.Forms.TextBox();
			_Text1_16 = new System.Windows.Forms.TextBox();
			_Text1_13 = new System.Windows.Forms.TextBox();
			_Text1_15 = new System.Windows.Forms.TextBox();
			_cmb_phone_type_2 = new System.Windows.Forms.ComboBox();
			_cmb_phone_type_3 = new System.Windows.Forms.ComboBox();
			_Text1_10 = new System.Windows.Forms.TextBox();
			_Text1_9 = new System.Windows.Forms.TextBox();
			_Text1_11 = new System.Windows.Forms.TextBox();
			_Text1_6 = new System.Windows.Forms.TextBox();
			_Text1_8 = new System.Windows.Forms.TextBox();
			_Text1_5 = new System.Windows.Forms.TextBox();
			_Text1_7 = new System.Windows.Forms.TextBox();
			_cmb_phone_type_1 = new System.Windows.Forms.ComboBox();
			_cmb_phone_type_0 = new System.Windows.Forms.ComboBox();
			cmb_account_id = new System.Windows.Forms.ComboBox();
			cmb_account_type = new System.Windows.Forms.ComboBox();
			cmb_language = new System.Windows.Forms.ComboBox();
			cmb_business_type = new System.Windows.Forms.ComboBox();
			_Text1_4 = new System.Windows.Forms.TextBox();
			_Text1_3 = new System.Windows.Forms.TextBox();
			_Text1_2 = new System.Windows.Forms.TextBox();
			_Text1_1 = new System.Windows.Forms.TextBox();
			_Text1_0 = new System.Windows.Forms.TextBox();
			_Label1_52 = new System.Windows.Forms.Label();
			_Label1_51 = new System.Windows.Forms.Label();
			_Label1_50 = new System.Windows.Forms.Label();
			_Shape1_0 = new UpgradeHelpers.Gui.ShapeHelper();
			_Label1_7 = new System.Windows.Forms.Label();
			_Label1_6 = new System.Windows.Forms.Label();
			_Label1_10 = new System.Windows.Forms.Label();
			_Label1_49 = new System.Windows.Forms.Label();
			_Shape1_2 = new UpgradeHelpers.Gui.ShapeHelper();
			_Label1_48 = new System.Windows.Forms.Label();
			_Label1_47 = new System.Windows.Forms.Label();
			_Label1_46 = new System.Windows.Forms.Label();
			_Label1_45 = new System.Windows.Forms.Label();
			_Label1_44 = new System.Windows.Forms.Label();
			_Label1_43 = new System.Windows.Forms.Label();
			_Label1_42 = new System.Windows.Forms.Label();
			_Label1_37 = new System.Windows.Forms.Label();
			_Label1_41 = new System.Windows.Forms.Label();
			_Shape1_1 = new UpgradeHelpers.Gui.ShapeHelper();
			_Label1_40 = new System.Windows.Forms.Label();
			_Label1_39 = new System.Windows.Forms.Label();
			_Label1_38 = new System.Windows.Forms.Label();
			_Label1_36 = new System.Windows.Forms.Label();
			_Label1_35 = new System.Windows.Forms.Label();
			_Label1_34 = new System.Windows.Forms.Label();
			_Label1_33 = new System.Windows.Forms.Label();
			_Label1_32 = new System.Windows.Forms.Label();
			_Label1_31 = new System.Windows.Forms.Label();
			_Label1_30 = new System.Windows.Forms.Label();
			_Label1_29 = new System.Windows.Forms.Label();
			_Label1_28 = new System.Windows.Forms.Label();
			_Label1_27 = new System.Windows.Forms.Label();
			_Label1_26 = new System.Windows.Forms.Label();
			_Label1_25 = new System.Windows.Forms.Label();
			_Label1_24 = new System.Windows.Forms.Label();
			_Label1_23 = new System.Windows.Forms.Label();
			_Label1_22 = new System.Windows.Forms.Label();
			_Label1_21 = new System.Windows.Forms.Label();
			_Label1_20 = new System.Windows.Forms.Label();
			_Label1_19 = new System.Windows.Forms.Label();
			_Label1_18 = new System.Windows.Forms.Label();
			_Label1_15 = new System.Windows.Forms.Label();
			_Label1_16 = new System.Windows.Forms.Label();
			_Label1_17 = new System.Windows.Forms.Label();
			_Label1_14 = new System.Windows.Forms.Label();
			_Label1_13 = new System.Windows.Forms.Label();
			_Label1_0 = new System.Windows.Forms.Label();
			_Label1_1 = new System.Windows.Forms.Label();
			_Label1_2 = new System.Windows.Forms.Label();
			_Label1_3 = new System.Windows.Forms.Label();
			_Label1_4 = new System.Windows.Forms.Label();
			_Label1_12 = new System.Windows.Forms.Label();
			_Label1_11 = new System.Windows.Forms.Label();
			lbl_status_display = new System.Windows.Forms.Label();
			_Label1_9 = new System.Windows.Forms.Label();
			_Label1_8 = new System.Windows.Forms.Label();
			_Label1_5 = new System.Windows.Forms.Label();
			SuspendLayout();
			listBoxComboBoxHelper1 = new UpgradeHelpers.Gui.Controls.ListControlHelper(components);
			((System.ComponentModel.ISupportInitialize) listBoxComboBoxHelper1).BeginInit();
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
			// 
			// chk_hide_company
			// 
			chk_hide_company.AllowDrop = true;
			chk_hide_company.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_hide_company.BackColor = System.Drawing.SystemColors.Control;
			chk_hide_company.CausesValidation = true;
			chk_hide_company.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_hide_company.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_hide_company.Enabled = true;
			chk_hide_company.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_hide_company.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_hide_company.Location = new System.Drawing.Point(296, 192);
			chk_hide_company.Name = "chk_hide_company";
			chk_hide_company.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_hide_company.Size = new System.Drawing.Size(89, 17);
			chk_hide_company.TabIndex = 112;
			chk_hide_company.TabStop = true;
			chk_hide_company.Text = "Hide Company";
			chk_hide_company.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_hide_company.Visible = true;
			// 
			// cmd_copy_company
			// 
			cmd_copy_company.AllowDrop = true;
			cmd_copy_company.BackColor = System.Drawing.SystemColors.Control;
			cmd_copy_company.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_copy_company.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_copy_company.Location = new System.Drawing.Point(280, 10);
			cmd_copy_company.Name = "cmd_copy_company";
			cmd_copy_company.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_copy_company.Size = new System.Drawing.Size(65, 19);
			cmd_copy_company.TabIndex = 111;
			cmd_copy_company.Text = "Duplicate";
			cmd_copy_company.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_copy_company.UseVisualStyleBackColor = false;
			cmd_copy_company.Visible = false;
			cmd_copy_company.Click += new System.EventHandler(cmd_copy_company_Click);
			// 
			// chkCompContactAddressFlag
			// 
			chkCompContactAddressFlag.AllowDrop = true;
			chkCompContactAddressFlag.Appearance = System.Windows.Forms.Appearance.Normal;
			chkCompContactAddressFlag.BackColor = System.Drawing.SystemColors.Control;
			chkCompContactAddressFlag.CausesValidation = true;
			chkCompContactAddressFlag.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			chkCompContactAddressFlag.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkCompContactAddressFlag.Enabled = true;
			chkCompContactAddressFlag.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkCompContactAddressFlag.ForeColor = System.Drawing.SystemColors.WindowText;
			chkCompContactAddressFlag.Location = new System.Drawing.Point(442, 188);
			chkCompContactAddressFlag.Name = "chkCompContactAddressFlag";
			chkCompContactAddressFlag.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkCompContactAddressFlag.Size = new System.Drawing.Size(191, 17);
			chkCompContactAddressFlag.TabIndex = 22;
			chkCompContactAddressFlag.TabStop = true;
			chkCompContactAddressFlag.Text = "Individual/Company";
			chkCompContactAddressFlag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkCompContactAddressFlag.Visible = true;
			// 
			// _Text1_33
			// 
			_Text1_33.AcceptsReturn = true;
			_Text1_33.AllowDrop = true;
			_Text1_33.BackColor = System.Drawing.SystemColors.Window;
			_Text1_33.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_Text1_33.Cursor = System.Windows.Forms.Cursors.IBeam;
			_Text1_33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Text1_33.ForeColor = System.Drawing.SystemColors.WindowText;
			_Text1_33.Location = new System.Drawing.Point(179, 445);
			_Text1_33.MaxLength = 40;
			_Text1_33.Name = "_Text1_33";
			_Text1_33.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Text1_33.Size = new System.Drawing.Size(49, 21);
			_Text1_33.TabIndex = 109;
			_Text1_33.Leave += new System.EventHandler(Text1_Leave);
			// 
			// _Text1_32
			// 
			_Text1_32.AcceptsReturn = true;
			_Text1_32.AllowDrop = true;
			_Text1_32.BackColor = System.Drawing.SystemColors.Window;
			_Text1_32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_Text1_32.Cursor = System.Windows.Forms.Cursors.IBeam;
			_Text1_32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Text1_32.ForeColor = System.Drawing.SystemColors.WindowText;
			_Text1_32.Location = new System.Drawing.Point(179, 292);
			_Text1_32.MaxLength = 40;
			_Text1_32.Name = "_Text1_32";
			_Text1_32.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Text1_32.Size = new System.Drawing.Size(49, 21);
			_Text1_32.TabIndex = 106;
			_Text1_32.Leave += new System.EventHandler(Text1_Leave);
			// 
			// cmb_product_code
			// 
			cmb_product_code.AllowDrop = true;
			cmb_product_code.BackColor = System.Drawing.SystemColors.Window;
			cmb_product_code.CausesValidation = true;
			cmb_product_code.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cmb_product_code.Enabled = true;
			cmb_product_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmb_product_code.ForeColor = System.Drawing.SystemColors.WindowText;
			cmb_product_code.IntegralHeight = true;
			cmb_product_code.Location = new System.Drawing.Point(440, 210);
			cmb_product_code.Name = "cmb_product_code";
			cmb_product_code.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmb_product_code.Size = new System.Drawing.Size(195, 21);
			cmb_product_code.Sorted = false;
			cmb_product_code.TabIndex = 24;
			cmb_product_code.TabStop = true;
			cmb_product_code.Visible = true;
			cmb_product_code.SelectedIndexChanged += new System.EventHandler(cmb_product_code_SelectedIndexChanged);
			// 
			// cmb_agency_type
			// 
			cmb_agency_type.AllowDrop = true;
			cmb_agency_type.BackColor = System.Drawing.SystemColors.Window;
			cmb_agency_type.CausesValidation = true;
			cmb_agency_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cmb_agency_type.Enabled = true;
			cmb_agency_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmb_agency_type.ForeColor = System.Drawing.SystemColors.WindowText;
			cmb_agency_type.IntegralHeight = true;
			cmb_agency_type.Location = new System.Drawing.Point(130, 210);
			cmb_agency_type.Name = "cmb_agency_type";
			cmb_agency_type.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmb_agency_type.Size = new System.Drawing.Size(195, 21);
			cmb_agency_type.Sorted = false;
			cmb_agency_type.TabIndex = 23;
			cmb_agency_type.TabStop = true;
			cmb_agency_type.Visible = true;
			cmb_agency_type.SelectedIndexChanged += new System.EventHandler(cmb_agency_type_SelectedIndexChanged);
			// 
			// cmb_state_code
			// 
			cmb_state_code.AllowDrop = true;
			cmb_state_code.BackColor = System.Drawing.SystemColors.Window;
			cmb_state_code.CausesValidation = true;
			cmb_state_code.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cmb_state_code.Enabled = true;
			cmb_state_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmb_state_code.ForeColor = System.Drawing.SystemColors.WindowText;
			cmb_state_code.IntegralHeight = true;
			cmb_state_code.Location = new System.Drawing.Point(64, 168);
			cmb_state_code.Name = "cmb_state_code";
			cmb_state_code.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmb_state_code.Size = new System.Drawing.Size(103, 21);
			cmb_state_code.Sorted = false;
			cmb_state_code.TabIndex = 7;
			cmb_state_code.TabStop = true;
			cmb_state_code.Visible = true;
			cmb_state_code.SelectedIndexChanged += new System.EventHandler(cmb_state_code_SelectedIndexChanged);
			// 
			// cmb_country_code
			// 
			cmb_country_code.AllowDrop = true;
			cmb_country_code.BackColor = System.Drawing.SystemColors.Window;
			cmb_country_code.CausesValidation = true;
			cmb_country_code.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cmb_country_code.Enabled = true;
			cmb_country_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmb_country_code.ForeColor = System.Drawing.SystemColors.WindowText;
			cmb_country_code.IntegralHeight = true;
			cmb_country_code.Location = new System.Drawing.Point(225, 168);
			cmb_country_code.Name = "cmb_country_code";
			cmb_country_code.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmb_country_code.Size = new System.Drawing.Size(124, 21);
			cmb_country_code.Sorted = false;
			cmb_country_code.TabIndex = 8;
			cmb_country_code.TabStop = true;
			cmb_country_code.Text = "cmb_country_code";
			cmb_country_code.Visible = true;
			cmb_country_code.Leave += new System.EventHandler(cmb_country_code_Leave);
			cmb_country_code.SelectionChangeCommitted += new System.EventHandler(cmb_country_code_SelectionChangeCommitted);
			// 
			// chk_auto_account_rep
			// 
			chk_auto_account_rep.AllowDrop = true;
			chk_auto_account_rep.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_auto_account_rep.BackColor = System.Drawing.SystemColors.Control;
			chk_auto_account_rep.CausesValidation = true;
			chk_auto_account_rep.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			chk_auto_account_rep.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_auto_account_rep.Enabled = true;
			chk_auto_account_rep.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_auto_account_rep.ForeColor = System.Drawing.SystemColors.WindowText;
			chk_auto_account_rep.Location = new System.Drawing.Point(441, 166);
			chk_auto_account_rep.Name = "chk_auto_account_rep";
			chk_auto_account_rep.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_auto_account_rep.Size = new System.Drawing.Size(191, 17);
			chk_auto_account_rep.TabIndex = 21;
			chk_auto_account_rep.TabStop = true;
			chk_auto_account_rep.Text = "Auto Assign Account Rep";
			chk_auto_account_rep.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_auto_account_rep.Visible = true;
			chk_auto_account_rep.CheckStateChanged += new System.EventHandler(chk_auto_account_rep_CheckStateChanged);
			// 
			// _Text1_31
			// 
			_Text1_31.AcceptsReturn = true;
			_Text1_31.AllowDrop = true;
			_Text1_31.BackColor = System.Drawing.SystemColors.Window;
			_Text1_31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_Text1_31.Cursor = System.Windows.Forms.Cursors.IBeam;
			_Text1_31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Text1_31.ForeColor = System.Drawing.SystemColors.WindowText;
			_Text1_31.Location = new System.Drawing.Point(66, 60);
			_Text1_31.MaxLength = 40;
			_Text1_31.Name = "_Text1_31";
			_Text1_31.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Text1_31.Size = new System.Drawing.Size(212, 21);
			_Text1_31.TabIndex = 2;
			_Text1_31.Leave += new System.EventHandler(Text1_Leave);
			// 
			// _Text1_12
			// 
			_Text1_12.AcceptsReturn = true;
			_Text1_12.AllowDrop = true;
			_Text1_12.BackColor = System.Drawing.SystemColors.Window;
			_Text1_12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_Text1_12.Cursor = System.Windows.Forms.Cursors.IBeam;
			_Text1_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Text1_12.ForeColor = System.Drawing.SystemColors.WindowText;
			_Text1_12.Location = new System.Drawing.Point(600, 86);
			_Text1_12.MaxLength = 10;
			_Text1_12.Name = "_Text1_12";
			_Text1_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Text1_12.Size = new System.Drawing.Size(68, 21);
			_Text1_12.TabIndex = 18;
			_Text1_12.Leave += new System.EventHandler(Text1_Leave);
			// 
			// _Text1_27
			// 
			_Text1_27.AcceptsReturn = true;
			_Text1_27.AllowDrop = true;
			_Text1_27.BackColor = System.Drawing.SystemColors.Window;
			_Text1_27.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_Text1_27.Cursor = System.Windows.Forms.Cursors.IBeam;
			_Text1_27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Text1_27.ForeColor = System.Drawing.SystemColors.WindowText;
			_Text1_27.Location = new System.Drawing.Point(408, 141);
			_Text1_27.MaxLength = 150;
			_Text1_27.Name = "_Text1_27";
			_Text1_27.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Text1_27.Size = new System.Drawing.Size(258, 21);
			_Text1_27.TabIndex = 20;
			_Text1_27.Leave += new System.EventHandler(Text1_Leave);
			// 
			// chk_attach_to_contact
			// 
			chk_attach_to_contact.AllowDrop = true;
			chk_attach_to_contact.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_attach_to_contact.BackColor = System.Drawing.SystemColors.Control;
			chk_attach_to_contact.CausesValidation = true;
			chk_attach_to_contact.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			chk_attach_to_contact.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_attach_to_contact.Enabled = true;
			chk_attach_to_contact.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_attach_to_contact.ForeColor = System.Drawing.SystemColors.WindowText;
			chk_attach_to_contact.Location = new System.Drawing.Point(461, 448);
			chk_attach_to_contact.Name = "chk_attach_to_contact";
			chk_attach_to_contact.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_attach_to_contact.Size = new System.Drawing.Size(203, 16);
			chk_attach_to_contact.TabIndex = 50;
			chk_attach_to_contact.TabStop = true;
			chk_attach_to_contact.Text = "Attach Note to Contact:";
			chk_attach_to_contact.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_attach_to_contact.Visible = true;
			// 
			// _Text1_30
			// 
			_Text1_30.AcceptsReturn = true;
			_Text1_30.AllowDrop = true;
			_Text1_30.BackColor = System.Drawing.SystemColors.Window;
			_Text1_30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_Text1_30.Cursor = System.Windows.Forms.Cursors.IBeam;
			_Text1_30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Text1_30.ForeColor = System.Drawing.SystemColors.WindowText;
			_Text1_30.Location = new System.Drawing.Point(70, 496);
			_Text1_30.MaxLength = 2000;
			_Text1_30.Multiline = true;
			_Text1_30.Name = "_Text1_30";
			_Text1_30.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Text1_30.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			_Text1_30.Size = new System.Drawing.Size(596, 63);
			_Text1_30.TabIndex = 49;
			_Text1_30.WordWrap = false;
			_Text1_30.Leave += new System.EventHandler(Text1_Leave);
			// 
			// _Text1_29
			// 
			_Text1_29.AcceptsReturn = true;
			_Text1_29.AllowDrop = true;
			_Text1_29.BackColor = System.Drawing.SystemColors.Window;
			_Text1_29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_Text1_29.Cursor = System.Windows.Forms.Cursors.IBeam;
			_Text1_29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Text1_29.ForeColor = System.Drawing.SystemColors.WindowText;
			_Text1_29.Location = new System.Drawing.Point(70, 470);
			_Text1_29.MaxLength = 120;
			_Text1_29.Name = "_Text1_29";
			_Text1_29.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Text1_29.Size = new System.Drawing.Size(595, 21);
			_Text1_29.TabIndex = 48;
			_Text1_29.Leave += new System.EventHandler(Text1_Leave);
			// 
			// _Text1_28
			// 
			_Text1_28.AcceptsReturn = true;
			_Text1_28.AllowDrop = true;
			_Text1_28.BackColor = System.Drawing.SystemColors.Window;
			_Text1_28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_Text1_28.Cursor = System.Windows.Forms.Cursors.IBeam;
			_Text1_28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Text1_28.ForeColor = System.Drawing.SystemColors.WindowText;
			_Text1_28.Location = new System.Drawing.Point(53, 409);
			_Text1_28.MaxLength = 150;
			_Text1_28.Name = "_Text1_28";
			_Text1_28.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Text1_28.Size = new System.Drawing.Size(239, 21);
			_Text1_28.TabIndex = 46;
			_Text1_28.Leave += new System.EventHandler(Text1_Leave);
			// 
			// cmb_comp_name_alt_type
			// 
			cmb_comp_name_alt_type.AllowDrop = true;
			cmb_comp_name_alt_type.BackColor = System.Drawing.SystemColors.Window;
			cmb_comp_name_alt_type.CausesValidation = true;
			cmb_comp_name_alt_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cmb_comp_name_alt_type.Enabled = true;
			cmb_comp_name_alt_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmb_comp_name_alt_type.ForeColor = System.Drawing.SystemColors.WindowText;
			cmb_comp_name_alt_type.IntegralHeight = true;
			cmb_comp_name_alt_type.Location = new System.Drawing.Point(281, 60);
			cmb_comp_name_alt_type.Name = "cmb_comp_name_alt_type";
			cmb_comp_name_alt_type.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmb_comp_name_alt_type.Size = new System.Drawing.Size(68, 21);
			cmb_comp_name_alt_type.Sorted = false;
			cmb_comp_name_alt_type.TabIndex = 1;
			cmb_comp_name_alt_type.TabStop = true;
			cmb_comp_name_alt_type.Visible = true;
			cmb_comp_name_alt_type.Items.AddRange(new object[]{"", "C/O", "DBA"});
			cmb_comp_name_alt_type.SelectedIndexChanged += new System.EventHandler(cmb_comp_name_alt_type_SelectedIndexChanged);
			// 
			// _Text1_26
			// 
			_Text1_26.AcceptsReturn = true;
			_Text1_26.AllowDrop = true;
			_Text1_26.BackColor = System.Drawing.SystemColors.Window;
			_Text1_26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_Text1_26.Cursor = System.Windows.Forms.Cursors.IBeam;
			_Text1_26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Text1_26.ForeColor = System.Drawing.SystemColors.WindowText;
			_Text1_26.Location = new System.Drawing.Point(409, 113);
			_Text1_26.MaxLength = 150;
			_Text1_26.Name = "_Text1_26";
			_Text1_26.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Text1_26.Size = new System.Drawing.Size(258, 21);
			_Text1_26.TabIndex = 19;
			_Text1_26.Leave += new System.EventHandler(Text1_Leave);
			// 
			// chk_hide_from_customer
			// 
			chk_hide_from_customer.AllowDrop = true;
			chk_hide_from_customer.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_hide_from_customer.BackColor = System.Drawing.SystemColors.Control;
			chk_hide_from_customer.CausesValidation = true;
			chk_hide_from_customer.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			chk_hide_from_customer.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_hide_from_customer.Enabled = true;
			chk_hide_from_customer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_hide_from_customer.ForeColor = System.Drawing.SystemColors.WindowText;
			chk_hide_from_customer.Location = new System.Drawing.Point(461, 411);
			chk_hide_from_customer.Name = "chk_hide_from_customer";
			chk_hide_from_customer.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_hide_from_customer.Size = new System.Drawing.Size(203, 16);
			chk_hide_from_customer.TabIndex = 47;
			chk_hide_from_customer.TabStop = true;
			chk_hide_from_customer.Text = "Hide Contact From Customer";
			chk_hide_from_customer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_hide_from_customer.Visible = true;
			// 
			// _Text1_25
			// 
			_Text1_25.AcceptsReturn = true;
			_Text1_25.AllowDrop = true;
			_Text1_25.BackColor = System.Drawing.SystemColors.Window;
			_Text1_25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_Text1_25.Cursor = System.Windows.Forms.Cursors.IBeam;
			_Text1_25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Text1_25.ForeColor = System.Drawing.SystemColors.WindowText;
			_Text1_25.Location = new System.Drawing.Point(179, 10);
			_Text1_25.MaxLength = 40;
			_Text1_25.Name = "_Text1_25";
			_Text1_25.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Text1_25.Size = new System.Drawing.Size(49, 21);
			_Text1_25.TabIndex = 94;
			_Text1_25.Leave += new System.EventHandler(Text1_Leave);
			// 
			// _cmd_CompanyAction_0
			// 
			_cmd_CompanyAction_0.AllowDrop = true;
			_cmd_CompanyAction_0.BackColor = System.Drawing.SystemColors.Control;
			_cmd_CompanyAction_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_CompanyAction_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_CompanyAction_0.Location = new System.Drawing.Point(216, 569);
			_cmd_CompanyAction_0.Name = "_cmd_CompanyAction_0";
			_cmd_CompanyAction_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_CompanyAction_0.Size = new System.Drawing.Size(61, 28);
			_cmd_CompanyAction_0.TabIndex = 51;
			_cmd_CompanyAction_0.Text = "Add";
			_cmd_CompanyAction_0.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_CompanyAction_0.UseVisualStyleBackColor = false;
			_cmd_CompanyAction_0.Click += new System.EventHandler(cmd_CompanyAction_Click);
			// 
			// _cmd_CompanyAction_1
			// 
			_cmd_CompanyAction_1.AllowDrop = true;
			_cmd_CompanyAction_1.BackColor = System.Drawing.SystemColors.Control;
			_cmd_CompanyAction_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_CompanyAction_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_CompanyAction_1.Location = new System.Drawing.Point(312, 569);
			_cmd_CompanyAction_1.Name = "_cmd_CompanyAction_1";
			_cmd_CompanyAction_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_CompanyAction_1.Size = new System.Drawing.Size(61, 28);
			_cmd_CompanyAction_1.TabIndex = 52;
			_cmd_CompanyAction_1.Text = "Clear";
			_cmd_CompanyAction_1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_CompanyAction_1.UseVisualStyleBackColor = false;
			_cmd_CompanyAction_1.Click += new System.EventHandler(cmd_CompanyAction_Click);
			// 
			// _cmd_CompanyAction_2
			// 
			_cmd_CompanyAction_2.AllowDrop = true;
			_cmd_CompanyAction_2.BackColor = System.Drawing.SystemColors.Control;
			_cmd_CompanyAction_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_CompanyAction_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_CompanyAction_2.Location = new System.Drawing.Point(414, 569);
			_cmd_CompanyAction_2.Name = "_cmd_CompanyAction_2";
			_cmd_CompanyAction_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_CompanyAction_2.Size = new System.Drawing.Size(61, 28);
			_cmd_CompanyAction_2.TabIndex = 53;
			_cmd_CompanyAction_2.Text = "Exit";
			_cmd_CompanyAction_2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_CompanyAction_2.UseVisualStyleBackColor = false;
			_cmd_CompanyAction_2.Click += new System.EventHandler(cmd_CompanyAction_Click);
			// 
			// _Text1_22
			// 
			_Text1_22.AcceptsReturn = true;
			_Text1_22.AllowDrop = true;
			_Text1_22.BackColor = System.Drawing.SystemColors.Window;
			_Text1_22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_Text1_22.Cursor = System.Windows.Forms.Cursors.IBeam;
			_Text1_22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Text1_22.ForeColor = System.Drawing.SystemColors.WindowText;
			_Text1_22.Location = new System.Drawing.Point(76, 334);
			_Text1_22.MaxLength = 50;
			_Text1_22.Name = "_Text1_22";
			_Text1_22.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Text1_22.Size = new System.Drawing.Size(91, 21);
			_Text1_22.TabIndex = 30;
			_Text1_22.Leave += new System.EventHandler(Text1_Leave);
			// 
			// cmb_contact_title
			// 
			cmb_contact_title.AllowDrop = true;
			cmb_contact_title.BackColor = System.Drawing.SystemColors.Window;
			cmb_contact_title.CausesValidation = true;
			cmb_contact_title.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cmb_contact_title.Enabled = true;
			cmb_contact_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmb_contact_title.ForeColor = System.Drawing.SystemColors.WindowText;
			cmb_contact_title.IntegralHeight = true;
			cmb_contact_title.Location = new System.Drawing.Point(102, 378);
			cmb_contact_title.Name = "cmb_contact_title";
			cmb_contact_title.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmb_contact_title.Size = new System.Drawing.Size(245, 21);
			cmb_contact_title.Sorted = false;
			cmb_contact_title.TabIndex = 35;
			cmb_contact_title.TabStop = true;
			cmb_contact_title.Text = "cmb_contact_title";
			cmb_contact_title.Visible = true;
			cmb_contact_title.SelectionChangeCommitted += new System.EventHandler(cmb_contact_title_SelectionChangeCommitted);
			// 
			// cmb_suffix
			// 
			cmb_suffix.AllowDrop = true;
			cmb_suffix.BackColor = System.Drawing.SystemColors.Window;
			cmb_suffix.CausesValidation = true;
			cmb_suffix.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cmb_suffix.Enabled = true;
			cmb_suffix.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmb_suffix.ForeColor = System.Drawing.SystemColors.WindowText;
			cmb_suffix.IntegralHeight = true;
			cmb_suffix.Location = new System.Drawing.Point(297, 334);
			cmb_suffix.Name = "cmb_suffix";
			cmb_suffix.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmb_suffix.Size = new System.Drawing.Size(50, 21);
			cmb_suffix.Sorted = false;
			cmb_suffix.TabIndex = 33;
			cmb_suffix.TabStop = true;
			cmb_suffix.Text = "cmb_suffix";
			cmb_suffix.Visible = true;
			cmb_suffix.Leave += new System.EventHandler(cmb_suffix_Leave);
			cmb_suffix.SelectionChangeCommitted += new System.EventHandler(cmb_suffix_SelectionChangeCommitted);
			// 
			// _Text1_24
			// 
			_Text1_24.AcceptsReturn = true;
			_Text1_24.AllowDrop = true;
			_Text1_24.BackColor = System.Drawing.SystemColors.Window;
			_Text1_24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_Text1_24.Cursor = System.Windows.Forms.Cursors.IBeam;
			_Text1_24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Text1_24.ForeColor = System.Drawing.SystemColors.WindowText;
			_Text1_24.Location = new System.Drawing.Point(201, 334);
			_Text1_24.MaxLength = 50;
			_Text1_24.Name = "_Text1_24";
			_Text1_24.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Text1_24.Size = new System.Drawing.Size(90, 21);
			_Text1_24.TabIndex = 32;
			_Text1_24.Leave += new System.EventHandler(Text1_Leave);
			// 
			// _Text1_23
			// 
			_Text1_23.AcceptsReturn = true;
			_Text1_23.AllowDrop = true;
			_Text1_23.BackColor = System.Drawing.SystemColors.Window;
			_Text1_23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_Text1_23.Cursor = System.Windows.Forms.Cursors.IBeam;
			_Text1_23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Text1_23.ForeColor = System.Drawing.SystemColors.WindowText;
			_Text1_23.Location = new System.Drawing.Point(173, 334);
			_Text1_23.MaxLength = 1;
			_Text1_23.Name = "_Text1_23";
			_Text1_23.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Text1_23.Size = new System.Drawing.Size(22, 21);
			_Text1_23.TabIndex = 31;
			_Text1_23.Leave += new System.EventHandler(Text1_Leave);
			// 
			// cmb_sirname
			// 
			cmb_sirname.AllowDrop = true;
			cmb_sirname.BackColor = System.Drawing.SystemColors.Window;
			cmb_sirname.CausesValidation = true;
			cmb_sirname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cmb_sirname.Enabled = true;
			cmb_sirname.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmb_sirname.ForeColor = System.Drawing.SystemColors.WindowText;
			cmb_sirname.IntegralHeight = true;
			cmb_sirname.Location = new System.Drawing.Point(13, 334);
			cmb_sirname.Name = "cmb_sirname";
			cmb_sirname.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmb_sirname.Size = new System.Drawing.Size(59, 21);
			cmb_sirname.Sorted = false;
			cmb_sirname.TabIndex = 29;
			cmb_sirname.TabStop = true;
			cmb_sirname.Text = "cmb_sirname";
			cmb_sirname.Visible = true;
			cmb_sirname.Leave += new System.EventHandler(cmb_sirname_Leave);
			cmb_sirname.SelectionChangeCommitted += new System.EventHandler(cmb_sirname_SelectionChangeCommitted);
			// 
			// _Text1_21
			// 
			_Text1_21.AcceptsReturn = true;
			_Text1_21.AllowDrop = true;
			_Text1_21.BackColor = System.Drawing.SystemColors.Window;
			_Text1_21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_Text1_21.Cursor = System.Windows.Forms.Cursors.IBeam;
			_Text1_21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Text1_21.ForeColor = System.Drawing.SystemColors.WindowText;
			_Text1_21.Location = new System.Drawing.Point(53, 378);
			_Text1_21.MaxLength = 2;
			_Text1_21.Name = "_Text1_21";
			_Text1_21.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Text1_21.Size = new System.Drawing.Size(29, 21);
			_Text1_21.TabIndex = 34;
			_Text1_21.Leave += new System.EventHandler(Text1_Leave);
			// 
			// _Text1_18
			// 
			_Text1_18.AcceptsReturn = true;
			_Text1_18.AllowDrop = true;
			_Text1_18.BackColor = System.Drawing.SystemColors.Window;
			_Text1_18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_Text1_18.Cursor = System.Windows.Forms.Cursors.IBeam;
			_Text1_18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Text1_18.ForeColor = System.Drawing.SystemColors.WindowText;
			_Text1_18.Location = new System.Drawing.Point(498, 378);
			_Text1_18.MaxLength = 6;
			_Text1_18.Name = "_Text1_18";
			_Text1_18.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Text1_18.Size = new System.Drawing.Size(44, 21);
			_Text1_18.TabIndex = 43;
			_Text1_18.Leave += new System.EventHandler(Text1_Leave);
			// 
			// _Text1_20
			// 
			_Text1_20.AcceptsReturn = true;
			_Text1_20.AllowDrop = true;
			_Text1_20.BackColor = System.Drawing.SystemColors.Window;
			_Text1_20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_Text1_20.Cursor = System.Windows.Forms.Cursors.IBeam;
			_Text1_20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Text1_20.ForeColor = System.Drawing.SystemColors.WindowText;
			_Text1_20.Location = new System.Drawing.Point(600, 378);
			_Text1_20.MaxLength = 10;
			_Text1_20.Name = "_Text1_20";
			_Text1_20.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Text1_20.Size = new System.Drawing.Size(68, 21);
			_Text1_20.TabIndex = 45;
			_Text1_20.Leave += new System.EventHandler(Text1_Leave);
			// 
			// _Text1_17
			// 
			_Text1_17.AcceptsReturn = true;
			_Text1_17.AllowDrop = true;
			_Text1_17.BackColor = System.Drawing.SystemColors.Window;
			_Text1_17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_Text1_17.Cursor = System.Windows.Forms.Cursors.IBeam;
			_Text1_17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Text1_17.ForeColor = System.Drawing.SystemColors.WindowText;
			_Text1_17.Location = new System.Drawing.Point(448, 378);
			_Text1_17.MaxLength = 6;
			_Text1_17.Name = "_Text1_17";
			_Text1_17.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Text1_17.Size = new System.Drawing.Size(44, 21);
			_Text1_17.TabIndex = 42;
			_Text1_17.Leave += new System.EventHandler(Text1_Leave);
			// 
			// _Text1_19
			// 
			_Text1_19.AcceptsReturn = true;
			_Text1_19.AllowDrop = true;
			_Text1_19.BackColor = System.Drawing.SystemColors.Window;
			_Text1_19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_Text1_19.Cursor = System.Windows.Forms.Cursors.IBeam;
			_Text1_19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Text1_19.ForeColor = System.Drawing.SystemColors.WindowText;
			_Text1_19.Location = new System.Drawing.Point(549, 378);
			_Text1_19.MaxLength = 6;
			_Text1_19.Name = "_Text1_19";
			_Text1_19.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Text1_19.Size = new System.Drawing.Size(44, 21);
			_Text1_19.TabIndex = 44;
			_Text1_19.Leave += new System.EventHandler(Text1_Leave);
			// 
			// _Text1_14
			// 
			_Text1_14.AcceptsReturn = true;
			_Text1_14.AllowDrop = true;
			_Text1_14.BackColor = System.Drawing.SystemColors.Window;
			_Text1_14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_Text1_14.Cursor = System.Windows.Forms.Cursors.IBeam;
			_Text1_14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Text1_14.ForeColor = System.Drawing.SystemColors.WindowText;
			_Text1_14.Location = new System.Drawing.Point(498, 334);
			_Text1_14.MaxLength = 6;
			_Text1_14.Name = "_Text1_14";
			_Text1_14.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Text1_14.Size = new System.Drawing.Size(44, 21);
			_Text1_14.TabIndex = 38;
			_Text1_14.Leave += new System.EventHandler(Text1_Leave);
			// 
			// _Text1_16
			// 
			_Text1_16.AcceptsReturn = true;
			_Text1_16.AllowDrop = true;
			_Text1_16.BackColor = System.Drawing.SystemColors.Window;
			_Text1_16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_Text1_16.Cursor = System.Windows.Forms.Cursors.IBeam;
			_Text1_16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Text1_16.ForeColor = System.Drawing.SystemColors.WindowText;
			_Text1_16.Location = new System.Drawing.Point(600, 334);
			_Text1_16.MaxLength = 10;
			_Text1_16.Name = "_Text1_16";
			_Text1_16.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Text1_16.Size = new System.Drawing.Size(68, 21);
			_Text1_16.TabIndex = 40;
			_Text1_16.Leave += new System.EventHandler(Text1_Leave);
			// 
			// _Text1_13
			// 
			_Text1_13.AcceptsReturn = true;
			_Text1_13.AllowDrop = true;
			_Text1_13.BackColor = System.Drawing.SystemColors.Window;
			_Text1_13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_Text1_13.Cursor = System.Windows.Forms.Cursors.IBeam;
			_Text1_13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Text1_13.ForeColor = System.Drawing.SystemColors.WindowText;
			_Text1_13.Location = new System.Drawing.Point(448, 334);
			_Text1_13.MaxLength = 6;
			_Text1_13.Name = "_Text1_13";
			_Text1_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Text1_13.Size = new System.Drawing.Size(44, 21);
			_Text1_13.TabIndex = 37;
			_Text1_13.Leave += new System.EventHandler(Text1_Leave);
			// 
			// _Text1_15
			// 
			_Text1_15.AcceptsReturn = true;
			_Text1_15.AllowDrop = true;
			_Text1_15.BackColor = System.Drawing.SystemColors.Window;
			_Text1_15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_Text1_15.Cursor = System.Windows.Forms.Cursors.IBeam;
			_Text1_15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Text1_15.ForeColor = System.Drawing.SystemColors.WindowText;
			_Text1_15.Location = new System.Drawing.Point(549, 334);
			_Text1_15.MaxLength = 6;
			_Text1_15.Name = "_Text1_15";
			_Text1_15.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Text1_15.Size = new System.Drawing.Size(44, 21);
			_Text1_15.TabIndex = 39;
			_Text1_15.Leave += new System.EventHandler(Text1_Leave);
			// 
			// _cmb_phone_type_2
			// 
			_cmb_phone_type_2.AllowDrop = true;
			_cmb_phone_type_2.BackColor = System.Drawing.SystemColors.Window;
			_cmb_phone_type_2.CausesValidation = true;
			_cmb_phone_type_2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			_cmb_phone_type_2.Enabled = true;
			_cmb_phone_type_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmb_phone_type_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_cmb_phone_type_2.IntegralHeight = true;
			_cmb_phone_type_2.Location = new System.Drawing.Point(357, 334);
			_cmb_phone_type_2.Name = "_cmb_phone_type_2";
			_cmb_phone_type_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmb_phone_type_2.Size = new System.Drawing.Size(86, 21);
			_cmb_phone_type_2.Sorted = false;
			_cmb_phone_type_2.TabIndex = 36;
			_cmb_phone_type_2.TabStop = true;
			_cmb_phone_type_2.Visible = true;
			_cmb_phone_type_2.SelectedIndexChanged += new System.EventHandler(cmb_phone_type_SelectedIndexChanged);
			// 
			// _cmb_phone_type_3
			// 
			_cmb_phone_type_3.AllowDrop = true;
			_cmb_phone_type_3.BackColor = System.Drawing.SystemColors.Window;
			_cmb_phone_type_3.CausesValidation = true;
			_cmb_phone_type_3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			_cmb_phone_type_3.Enabled = true;
			_cmb_phone_type_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmb_phone_type_3.ForeColor = System.Drawing.SystemColors.WindowText;
			_cmb_phone_type_3.IntegralHeight = true;
			_cmb_phone_type_3.Location = new System.Drawing.Point(357, 376);
			_cmb_phone_type_3.Name = "_cmb_phone_type_3";
			_cmb_phone_type_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmb_phone_type_3.Size = new System.Drawing.Size(86, 21);
			_cmb_phone_type_3.Sorted = false;
			_cmb_phone_type_3.TabIndex = 41;
			_cmb_phone_type_3.TabStop = true;
			_cmb_phone_type_3.Visible = true;
			_cmb_phone_type_3.SelectedIndexChanged += new System.EventHandler(cmb_phone_type_SelectedIndexChanged);
			// 
			// _Text1_10
			// 
			_Text1_10.AcceptsReturn = true;
			_Text1_10.AllowDrop = true;
			_Text1_10.BackColor = System.Drawing.SystemColors.Window;
			_Text1_10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_Text1_10.Cursor = System.Windows.Forms.Cursors.IBeam;
			_Text1_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Text1_10.ForeColor = System.Drawing.SystemColors.WindowText;
			_Text1_10.Location = new System.Drawing.Point(498, 86);
			_Text1_10.MaxLength = 6;
			_Text1_10.Name = "_Text1_10";
			_Text1_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Text1_10.Size = new System.Drawing.Size(44, 21);
			_Text1_10.TabIndex = 16;
			_Text1_10.Leave += new System.EventHandler(Text1_Leave);
			// 
			// _Text1_9
			// 
			_Text1_9.AcceptsReturn = true;
			_Text1_9.AllowDrop = true;
			_Text1_9.BackColor = System.Drawing.SystemColors.Window;
			_Text1_9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_Text1_9.Cursor = System.Windows.Forms.Cursors.IBeam;
			_Text1_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Text1_9.ForeColor = System.Drawing.SystemColors.WindowText;
			_Text1_9.Location = new System.Drawing.Point(448, 86);
			_Text1_9.MaxLength = 6;
			_Text1_9.Name = "_Text1_9";
			_Text1_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Text1_9.Size = new System.Drawing.Size(44, 21);
			_Text1_9.TabIndex = 15;
			_Text1_9.Leave += new System.EventHandler(Text1_Leave);
			// 
			// _Text1_11
			// 
			_Text1_11.AcceptsReturn = true;
			_Text1_11.AllowDrop = true;
			_Text1_11.BackColor = System.Drawing.SystemColors.Window;
			_Text1_11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_Text1_11.Cursor = System.Windows.Forms.Cursors.IBeam;
			_Text1_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Text1_11.ForeColor = System.Drawing.SystemColors.WindowText;
			_Text1_11.Location = new System.Drawing.Point(549, 86);
			_Text1_11.MaxLength = 6;
			_Text1_11.Name = "_Text1_11";
			_Text1_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Text1_11.Size = new System.Drawing.Size(44, 21);
			_Text1_11.TabIndex = 17;
			_Text1_11.Leave += new System.EventHandler(Text1_Leave);
			// 
			// _Text1_6
			// 
			_Text1_6.AcceptsReturn = true;
			_Text1_6.AllowDrop = true;
			_Text1_6.BackColor = System.Drawing.SystemColors.Window;
			_Text1_6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_Text1_6.Cursor = System.Windows.Forms.Cursors.IBeam;
			_Text1_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Text1_6.ForeColor = System.Drawing.SystemColors.WindowText;
			_Text1_6.Location = new System.Drawing.Point(498, 35);
			_Text1_6.MaxLength = 6;
			_Text1_6.Name = "_Text1_6";
			_Text1_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Text1_6.Size = new System.Drawing.Size(44, 21);
			_Text1_6.TabIndex = 11;
			_Text1_6.Leave += new System.EventHandler(Text1_Leave);
			// 
			// _Text1_8
			// 
			_Text1_8.AcceptsReturn = true;
			_Text1_8.AllowDrop = true;
			_Text1_8.BackColor = System.Drawing.SystemColors.Window;
			_Text1_8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_Text1_8.Cursor = System.Windows.Forms.Cursors.IBeam;
			_Text1_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Text1_8.ForeColor = System.Drawing.SystemColors.WindowText;
			_Text1_8.Location = new System.Drawing.Point(600, 35);
			_Text1_8.MaxLength = 10;
			_Text1_8.Name = "_Text1_8";
			_Text1_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Text1_8.Size = new System.Drawing.Size(68, 21);
			_Text1_8.TabIndex = 13;
			_Text1_8.Leave += new System.EventHandler(Text1_Leave);
			// 
			// _Text1_5
			// 
			_Text1_5.AcceptsReturn = true;
			_Text1_5.AllowDrop = true;
			_Text1_5.BackColor = System.Drawing.SystemColors.Window;
			_Text1_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_Text1_5.Cursor = System.Windows.Forms.Cursors.IBeam;
			_Text1_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Text1_5.ForeColor = System.Drawing.SystemColors.WindowText;
			_Text1_5.Location = new System.Drawing.Point(448, 35);
			_Text1_5.MaxLength = 6;
			_Text1_5.Name = "_Text1_5";
			_Text1_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Text1_5.Size = new System.Drawing.Size(44, 21);
			_Text1_5.TabIndex = 10;
			_Text1_5.Leave += new System.EventHandler(Text1_Leave);
			// 
			// _Text1_7
			// 
			_Text1_7.AcceptsReturn = true;
			_Text1_7.AllowDrop = true;
			_Text1_7.BackColor = System.Drawing.SystemColors.Window;
			_Text1_7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_Text1_7.Cursor = System.Windows.Forms.Cursors.IBeam;
			_Text1_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Text1_7.ForeColor = System.Drawing.SystemColors.WindowText;
			_Text1_7.Location = new System.Drawing.Point(549, 35);
			_Text1_7.MaxLength = 6;
			_Text1_7.Name = "_Text1_7";
			_Text1_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Text1_7.Size = new System.Drawing.Size(44, 21);
			_Text1_7.TabIndex = 12;
			_Text1_7.Leave += new System.EventHandler(Text1_Leave);
			// 
			// _cmb_phone_type_1
			// 
			_cmb_phone_type_1.AllowDrop = true;
			_cmb_phone_type_1.BackColor = System.Drawing.SystemColors.Window;
			_cmb_phone_type_1.CausesValidation = true;
			_cmb_phone_type_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			_cmb_phone_type_1.Enabled = true;
			_cmb_phone_type_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmb_phone_type_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_cmb_phone_type_1.IntegralHeight = true;
			_cmb_phone_type_1.Location = new System.Drawing.Point(357, 86);
			_cmb_phone_type_1.Name = "_cmb_phone_type_1";
			_cmb_phone_type_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmb_phone_type_1.Size = new System.Drawing.Size(86, 21);
			_cmb_phone_type_1.Sorted = false;
			_cmb_phone_type_1.TabIndex = 14;
			_cmb_phone_type_1.TabStop = true;
			_cmb_phone_type_1.Visible = true;
			_cmb_phone_type_1.SelectedIndexChanged += new System.EventHandler(cmb_phone_type_SelectedIndexChanged);
			// 
			// _cmb_phone_type_0
			// 
			_cmb_phone_type_0.AllowDrop = true;
			_cmb_phone_type_0.BackColor = System.Drawing.SystemColors.Window;
			_cmb_phone_type_0.CausesValidation = true;
			_cmb_phone_type_0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			_cmb_phone_type_0.Enabled = true;
			_cmb_phone_type_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmb_phone_type_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_cmb_phone_type_0.IntegralHeight = true;
			_cmb_phone_type_0.Location = new System.Drawing.Point(357, 35);
			_cmb_phone_type_0.Name = "_cmb_phone_type_0";
			_cmb_phone_type_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmb_phone_type_0.Size = new System.Drawing.Size(86, 21);
			_cmb_phone_type_0.Sorted = false;
			_cmb_phone_type_0.TabIndex = 9;
			_cmb_phone_type_0.TabStop = true;
			_cmb_phone_type_0.Visible = true;
			_cmb_phone_type_0.SelectedIndexChanged += new System.EventHandler(cmb_phone_type_SelectedIndexChanged);
			// 
			// cmb_account_id
			// 
			cmb_account_id.AllowDrop = true;
			cmb_account_id.BackColor = System.Drawing.Color.White;
			cmb_account_id.CausesValidation = true;
			cmb_account_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cmb_account_id.Enabled = false;
			cmb_account_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmb_account_id.ForeColor = System.Drawing.SystemColors.WindowText;
			cmb_account_id.IntegralHeight = true;
			cmb_account_id.Location = new System.Drawing.Point(440, 259);
			cmb_account_id.Name = "cmb_account_id";
			cmb_account_id.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmb_account_id.Size = new System.Drawing.Size(195, 21);
			cmb_account_id.Sorted = false;
			cmb_account_id.TabIndex = 28;
			cmb_account_id.TabStop = true;
			cmb_account_id.Visible = true;
			cmb_account_id.SelectedIndexChanged += new System.EventHandler(cmb_account_id_SelectedIndexChanged);
			// 
			// cmb_account_type
			// 
			cmb_account_type.AllowDrop = true;
			cmb_account_type.BackColor = System.Drawing.SystemColors.Window;
			cmb_account_type.CausesValidation = true;
			cmb_account_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cmb_account_type.Enabled = true;
			cmb_account_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmb_account_type.ForeColor = System.Drawing.SystemColors.WindowText;
			cmb_account_type.IntegralHeight = true;
			cmb_account_type.Location = new System.Drawing.Point(130, 259);
			cmb_account_type.Name = "cmb_account_type";
			cmb_account_type.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmb_account_type.Size = new System.Drawing.Size(195, 21);
			cmb_account_type.Sorted = false;
			cmb_account_type.TabIndex = 27;
			cmb_account_type.TabStop = true;
			cmb_account_type.Visible = true;
			cmb_account_type.SelectedIndexChanged += new System.EventHandler(cmb_account_type_SelectedIndexChanged);
			// 
			// cmb_language
			// 
			cmb_language.AllowDrop = true;
			cmb_language.BackColor = System.Drawing.SystemColors.Window;
			cmb_language.CausesValidation = true;
			cmb_language.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cmb_language.Enabled = true;
			cmb_language.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmb_language.ForeColor = System.Drawing.SystemColors.WindowText;
			cmb_language.IntegralHeight = true;
			cmb_language.Location = new System.Drawing.Point(440, 234);
			cmb_language.Name = "cmb_language";
			cmb_language.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmb_language.Size = new System.Drawing.Size(195, 21);
			cmb_language.Sorted = false;
			cmb_language.TabIndex = 26;
			cmb_language.TabStop = true;
			cmb_language.Visible = true;
			cmb_language.SelectedIndexChanged += new System.EventHandler(cmb_language_SelectedIndexChanged);
			// 
			// cmb_business_type
			// 
			cmb_business_type.AllowDrop = true;
			cmb_business_type.BackColor = System.Drawing.SystemColors.Window;
			cmb_business_type.CausesValidation = true;
			cmb_business_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cmb_business_type.Enabled = false;
			cmb_business_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmb_business_type.ForeColor = System.Drawing.SystemColors.WindowText;
			cmb_business_type.IntegralHeight = true;
			cmb_business_type.Location = new System.Drawing.Point(130, 234);
			cmb_business_type.Name = "cmb_business_type";
			cmb_business_type.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmb_business_type.Size = new System.Drawing.Size(195, 21);
			cmb_business_type.Sorted = false;
			cmb_business_type.TabIndex = 25;
			cmb_business_type.TabStop = true;
			cmb_business_type.Visible = true;
			cmb_business_type.SelectedIndexChanged += new System.EventHandler(cmb_business_type_SelectedIndexChanged);
			// 
			// _Text1_4
			// 
			_Text1_4.AcceptsReturn = true;
			_Text1_4.AllowDrop = true;
			_Text1_4.BackColor = System.Drawing.SystemColors.Window;
			_Text1_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_Text1_4.Cursor = System.Windows.Forms.Cursors.IBeam;
			_Text1_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Text1_4.ForeColor = System.Drawing.SystemColors.WindowText;
			_Text1_4.Location = new System.Drawing.Point(278, 141);
			_Text1_4.MaxLength = 10;
			_Text1_4.Name = "_Text1_4";
			_Text1_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Text1_4.Size = new System.Drawing.Size(72, 21);
			_Text1_4.TabIndex = 6;
			_Text1_4.Leave += new System.EventHandler(Text1_Leave);
			// 
			// _Text1_3
			// 
			_Text1_3.AcceptsReturn = true;
			_Text1_3.AllowDrop = true;
			_Text1_3.BackColor = System.Drawing.SystemColors.Window;
			_Text1_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_Text1_3.Cursor = System.Windows.Forms.Cursors.IBeam;
			_Text1_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Text1_3.ForeColor = System.Drawing.SystemColors.WindowText;
			_Text1_3.Location = new System.Drawing.Point(66, 141);
			_Text1_3.MaxLength = 50;
			_Text1_3.Name = "_Text1_3";
			_Text1_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Text1_3.Size = new System.Drawing.Size(142, 21);
			_Text1_3.TabIndex = 5;
			_Text1_3.Leave += new System.EventHandler(Text1_Leave);
			// 
			// _Text1_2
			// 
			_Text1_2.AcceptsReturn = true;
			_Text1_2.AllowDrop = true;
			_Text1_2.BackColor = System.Drawing.SystemColors.Window;
			_Text1_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_Text1_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			_Text1_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Text1_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_Text1_2.Location = new System.Drawing.Point(66, 113);
			_Text1_2.MaxLength = 50;
			_Text1_2.Name = "_Text1_2";
			_Text1_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Text1_2.Size = new System.Drawing.Size(282, 21);
			_Text1_2.TabIndex = 4;
			_Text1_2.Leave += new System.EventHandler(Text1_Leave);
			// 
			// _Text1_1
			// 
			_Text1_1.AcceptsReturn = true;
			_Text1_1.AllowDrop = true;
			_Text1_1.BackColor = System.Drawing.SystemColors.Window;
			_Text1_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_Text1_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			_Text1_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Text1_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_Text1_1.Location = new System.Drawing.Point(66, 86);
			_Text1_1.MaxLength = 50;
			_Text1_1.Name = "_Text1_1";
			_Text1_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Text1_1.Size = new System.Drawing.Size(282, 21);
			_Text1_1.TabIndex = 3;
			_Text1_1.Leave += new System.EventHandler(Text1_Leave);
			// 
			// _Text1_0
			// 
			_Text1_0.AcceptsReturn = true;
			_Text1_0.AllowDrop = true;
			_Text1_0.BackColor = System.Drawing.SystemColors.Window;
			_Text1_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_Text1_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_Text1_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Text1_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_Text1_0.Location = new System.Drawing.Point(66, 35);
			_Text1_0.MaxLength = 100;
			_Text1_0.Name = "_Text1_0";
			_Text1_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Text1_0.Size = new System.Drawing.Size(212, 21);
			_Text1_0.TabIndex = 0;
			_Text1_0.Leave += new System.EventHandler(Text1_Leave);
			// 
			// _Label1_52
			// 
			_Label1_52.AllowDrop = true;
			_Label1_52.AutoSize = true;
			_Label1_52.BackColor = System.Drawing.Color.Transparent;
			_Label1_52.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_52.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_52.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_52.Location = new System.Drawing.Point(163, 449);
			_Label1_52.MinimumSize = new System.Drawing.Size(14, 13);
			_Label1_52.Name = "_Label1_52";
			_Label1_52.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_52.Size = new System.Drawing.Size(14, 13);
			_Label1_52.TabIndex = 110;
			_Label1_52.Text = "ID:";
			// 
			// _Label1_51
			// 
			_Label1_51.AllowDrop = true;
			_Label1_51.AutoSize = true;
			_Label1_51.BackColor = System.Drawing.Color.Transparent;
			_Label1_51.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_51.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_51.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_51.Location = new System.Drawing.Point(17, 66);
			_Label1_51.MinimumSize = new System.Drawing.Size(46, 13);
			_Label1_51.Name = "_Label1_51";
			_Label1_51.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_51.Size = new System.Drawing.Size(46, 13);
			_Label1_51.TabIndex = 108;
			_Label1_51.Text = "Alt Name:";
			_Label1_51.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// _Label1_50
			// 
			_Label1_50.AllowDrop = true;
			_Label1_50.AutoSize = true;
			_Label1_50.BackColor = System.Drawing.Color.Transparent;
			_Label1_50.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_50.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_50.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_50.Location = new System.Drawing.Point(163, 296);
			_Label1_50.MinimumSize = new System.Drawing.Size(14, 13);
			_Label1_50.Name = "_Label1_50";
			_Label1_50.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_50.Size = new System.Drawing.Size(14, 13);
			_Label1_50.TabIndex = 107;
			_Label1_50.Text = "ID:";
			// 
			// _Shape1_0
			// 
			_Shape1_0.AllowDrop = true;
			_Shape1_0.BackColor = System.Drawing.SystemColors.Window;
			_Shape1_0.BackStyle = 0;
			_Shape1_0.BorderColor = System.Drawing.Color.FromArgb(192, 0, 0);
			_Shape1_0.BorderStyle = 1;
			_Shape1_0.Enabled = false;
			_Shape1_0.FillColor = System.Drawing.Color.Black;
			_Shape1_0.FillStyle = 1;
			_Shape1_0.Location = new System.Drawing.Point(6, 4);
			_Shape1_0.Name = "_Shape1_0";
			_Shape1_0.Size = new System.Drawing.Size(665, 279);
			_Shape1_0.Visible = true;
			// 
			// _Label1_7
			// 
			_Label1_7.AllowDrop = true;
			_Label1_7.AutoSize = true;
			_Label1_7.BackColor = System.Drawing.Color.Transparent;
			_Label1_7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_7.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_7.Location = new System.Drawing.Point(365, 214);
			_Label1_7.MinimumSize = new System.Drawing.Size(68, 13);
			_Label1_7.Name = "_Label1_7";
			_Label1_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_7.Size = new System.Drawing.Size(68, 13);
			_Label1_7.TabIndex = 105;
			_Label1_7.Text = "Product Code:";
			_Label1_7.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// _Label1_6
			// 
			_Label1_6.AllowDrop = true;
			_Label1_6.AutoSize = true;
			_Label1_6.BackColor = System.Drawing.Color.Transparent;
			_Label1_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_6.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_6.Location = new System.Drawing.Point(57, 214);
			_Label1_6.MinimumSize = new System.Drawing.Size(66, 13);
			_Label1_6.Name = "_Label1_6";
			_Label1_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_6.Size = new System.Drawing.Size(66, 13);
			_Label1_6.TabIndex = 104;
			_Label1_6.Text = "Agency Type:";
			_Label1_6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// _Label1_10
			// 
			_Label1_10.AllowDrop = true;
			_Label1_10.AutoSize = true;
			_Label1_10.BackColor = System.Drawing.Color.Transparent;
			_Label1_10.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_10.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_10.Location = new System.Drawing.Point(183, 172);
			_Label1_10.MinimumSize = new System.Drawing.Size(39, 13);
			_Label1_10.Name = "_Label1_10";
			_Label1_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_10.Size = new System.Drawing.Size(39, 13);
			_Label1_10.TabIndex = 103;
			_Label1_10.Text = "Country:";
			_Label1_10.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// _Label1_49
			// 
			_Label1_49.AllowDrop = true;
			_Label1_49.AutoSize = true;
			_Label1_49.BackColor = System.Drawing.Color.Transparent;
			_Label1_49.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_49.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_49.ForeColor = System.Drawing.Color.Purple;
			_Label1_49.Location = new System.Drawing.Point(13, 447);
			_Label1_49.MinimumSize = new System.Drawing.Size(132, 16);
			_Label1_49.Name = "_Label1_49";
			_Label1_49.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_49.Size = new System.Drawing.Size(132, 16);
			_Label1_49.TabIndex = 102;
			_Label1_49.Text = "Journal Information:";
			// 
			// _Shape1_2
			// 
			_Shape1_2.AllowDrop = true;
			_Shape1_2.BackColor = System.Drawing.SystemColors.Window;
			_Shape1_2.BackStyle = 0;
			_Shape1_2.BorderColor = System.Drawing.Color.Purple;
			_Shape1_2.BorderStyle = 1;
			_Shape1_2.Enabled = false;
			_Shape1_2.FillColor = System.Drawing.Color.Black;
			_Shape1_2.FillStyle = 1;
			_Shape1_2.Location = new System.Drawing.Point(8, 441);
			_Shape1_2.Name = "_Shape1_2";
			_Shape1_2.Size = new System.Drawing.Size(665, 122);
			_Shape1_2.Visible = true;
			// 
			// _Label1_48
			// 
			_Label1_48.AllowDrop = true;
			_Label1_48.AutoSize = true;
			_Label1_48.BackColor = System.Drawing.Color.Transparent;
			_Label1_48.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_48.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_48.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_48.Location = new System.Drawing.Point(23, 505);
			_Label1_48.MinimumSize = new System.Drawing.Size(39, 26);
			_Label1_48.Name = "_Label1_48";
			_Label1_48.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_48.Size = new System.Drawing.Size(39, 26);
			_Label1_48.TabIndex = 101;
			_Label1_48.Text = "Internal Notes:";
			_Label1_48.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// _Label1_47
			// 
			_Label1_47.AllowDrop = true;
			_Label1_47.AutoSize = true;
			_Label1_47.BackColor = System.Drawing.Color.Transparent;
			_Label1_47.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_47.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_47.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_47.Location = new System.Drawing.Point(23, 474);
			_Label1_47.MinimumSize = new System.Drawing.Size(39, 13);
			_Label1_47.Name = "_Label1_47";
			_Label1_47.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_47.Size = new System.Drawing.Size(39, 13);
			_Label1_47.TabIndex = 100;
			_Label1_47.Text = "Subject:";
			_Label1_47.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// _Label1_46
			// 
			_Label1_46.AllowDrop = true;
			_Label1_46.AutoSize = true;
			_Label1_46.BackColor = System.Drawing.Color.Transparent;
			_Label1_46.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_46.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_46.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_46.Location = new System.Drawing.Point(294, 44);
			_Label1_46.MinimumSize = new System.Drawing.Size(42, 13);
			_Label1_46.Name = "_Label1_46";
			_Label1_46.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_46.Size = new System.Drawing.Size(42, 13);
			_Label1_46.TabIndex = 99;
			_Label1_46.Text = "Alt Type:";
			_Label1_46.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// _Label1_45
			// 
			_Label1_45.AllowDrop = true;
			_Label1_45.AutoSize = true;
			_Label1_45.BackColor = System.Drawing.Color.Transparent;
			_Label1_45.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_45.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_45.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_45.Location = new System.Drawing.Point(15, 413);
			_Label1_45.MinimumSize = new System.Drawing.Size(32, 13);
			_Label1_45.Name = "_Label1_45";
			_Label1_45.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_45.Size = new System.Drawing.Size(32, 13);
			_Label1_45.TabIndex = 98;
			_Label1_45.Text = "E-Mail:";
			_Label1_45.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// _Label1_44
			// 
			_Label1_44.AllowDrop = true;
			_Label1_44.AutoSize = true;
			_Label1_44.BackColor = System.Drawing.Color.Transparent;
			_Label1_44.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_44.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_44.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_44.Location = new System.Drawing.Point(372, 145);
			_Label1_44.MinimumSize = new System.Drawing.Size(32, 13);
			_Label1_44.Name = "_Label1_44";
			_Label1_44.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_44.Size = new System.Drawing.Size(32, 13);
			_Label1_44.TabIndex = 97;
			_Label1_44.Text = "E-Mail:";
			_Label1_44.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// _Label1_43
			// 
			_Label1_43.AllowDrop = true;
			_Label1_43.AutoSize = true;
			_Label1_43.BackColor = System.Drawing.Color.Transparent;
			_Label1_43.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_43.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_43.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_43.Location = new System.Drawing.Point(357, 117);
			_Label1_43.MinimumSize = new System.Drawing.Size(47, 13);
			_Label1_43.Name = "_Label1_43";
			_Label1_43.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_43.Size = new System.Drawing.Size(47, 13);
			_Label1_43.TabIndex = 96;
			_Label1_43.Text = "Web Site:";
			_Label1_43.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// _Label1_42
			// 
			_Label1_42.AllowDrop = true;
			_Label1_42.AutoSize = true;
			_Label1_42.BackColor = System.Drawing.Color.Transparent;
			_Label1_42.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_42.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_42.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_42.Location = new System.Drawing.Point(163, 14);
			_Label1_42.MinimumSize = new System.Drawing.Size(14, 13);
			_Label1_42.Name = "_Label1_42";
			_Label1_42.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_42.Size = new System.Drawing.Size(14, 13);
			_Label1_42.TabIndex = 95;
			_Label1_42.Text = "ID:";
			// 
			// _Label1_37
			// 
			_Label1_37.AllowDrop = true;
			_Label1_37.AutoSize = true;
			_Label1_37.BackColor = System.Drawing.Color.Transparent;
			_Label1_37.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_37.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_37.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_37.Location = new System.Drawing.Point(110, 316);
			_Label1_37.MinimumSize = new System.Drawing.Size(22, 13);
			_Label1_37.Name = "_Label1_37";
			_Label1_37.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_37.Size = new System.Drawing.Size(22, 13);
			_Label1_37.TabIndex = 93;
			_Label1_37.Text = "First:";
			// 
			// _Label1_41
			// 
			_Label1_41.AllowDrop = true;
			_Label1_41.AutoSize = true;
			_Label1_41.BackColor = System.Drawing.Color.Transparent;
			_Label1_41.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_41.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_41.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_41.Location = new System.Drawing.Point(212, 362);
			_Label1_41.MinimumSize = new System.Drawing.Size(23, 13);
			_Label1_41.Name = "_Label1_41";
			_Label1_41.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_41.Size = new System.Drawing.Size(23, 13);
			_Label1_41.TabIndex = 92;
			_Label1_41.Text = "Title:";
			// 
			// _Shape1_1
			// 
			_Shape1_1.AllowDrop = true;
			_Shape1_1.BackColor = System.Drawing.SystemColors.Window;
			_Shape1_1.BackStyle = 0;
			_Shape1_1.BorderColor = System.Drawing.Color.FromArgb(0, 0, 192);
			_Shape1_1.BorderStyle = 1;
			_Shape1_1.Enabled = false;
			_Shape1_1.FillColor = System.Drawing.Color.Black;
			_Shape1_1.FillStyle = 1;
			_Shape1_1.Location = new System.Drawing.Point(8, 288);
			_Shape1_1.Name = "_Shape1_1";
			_Shape1_1.Size = new System.Drawing.Size(665, 149);
			_Shape1_1.Visible = true;
			// 
			// _Label1_40
			// 
			_Label1_40.AllowDrop = true;
			_Label1_40.AutoSize = true;
			_Label1_40.BackColor = System.Drawing.Color.Transparent;
			_Label1_40.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_40.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_40.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_40.Location = new System.Drawing.Point(307, 316);
			_Label1_40.MinimumSize = new System.Drawing.Size(29, 13);
			_Label1_40.Name = "_Label1_40";
			_Label1_40.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_40.Size = new System.Drawing.Size(29, 13);
			_Label1_40.TabIndex = 91;
			_Label1_40.Tag = "lbl_cntry_code";
			_Label1_40.Text = "Suffix:";
			// 
			// _Label1_39
			// 
			_Label1_39.AllowDrop = true;
			_Label1_39.AutoSize = true;
			_Label1_39.BackColor = System.Drawing.Color.Transparent;
			_Label1_39.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_39.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_39.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_39.Location = new System.Drawing.Point(13, 375);
			_Label1_39.MinimumSize = new System.Drawing.Size(36, 26);
			_Label1_39.Name = "_Label1_39";
			_Label1_39.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_39.Size = new System.Drawing.Size(36, 26);
			_Label1_39.TabIndex = 90;
			_Label1_39.Text = "AC Pro Seq. #:";
			_Label1_39.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// _Label1_38
			// 
			_Label1_38.AllowDrop = true;
			_Label1_38.AutoSize = true;
			_Label1_38.BackColor = System.Drawing.Color.Transparent;
			_Label1_38.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_38.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_38.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_38.Location = new System.Drawing.Point(167, 316);
			_Label1_38.MinimumSize = new System.Drawing.Size(34, 13);
			_Label1_38.Name = "_Label1_38";
			_Label1_38.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_38.Size = new System.Drawing.Size(34, 13);
			_Label1_38.TabIndex = 89;
			_Label1_38.Text = "Middle:";
			// 
			// _Label1_36
			// 
			_Label1_36.AllowDrop = true;
			_Label1_36.AutoSize = true;
			_Label1_36.BackColor = System.Drawing.Color.Transparent;
			_Label1_36.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_36.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_36.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_36.Location = new System.Drawing.Point(16, 316);
			_Label1_36.MinimumSize = new System.Drawing.Size(29, 13);
			_Label1_36.Name = "_Label1_36";
			_Label1_36.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_36.Size = new System.Drawing.Size(29, 13);
			_Label1_36.TabIndex = 88;
			_Label1_36.Tag = "lbl_cntry_code";
			_Label1_36.Text = "Prefix:";
			// 
			// _Label1_35
			// 
			_Label1_35.AllowDrop = true;
			_Label1_35.AutoSize = true;
			_Label1_35.BackColor = System.Drawing.Color.Transparent;
			_Label1_35.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_35.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_35.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_35.Location = new System.Drawing.Point(235, 315);
			_Label1_35.MinimumSize = new System.Drawing.Size(23, 13);
			_Label1_35.Name = "_Label1_35";
			_Label1_35.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_35.Size = new System.Drawing.Size(23, 13);
			_Label1_35.TabIndex = 87;
			_Label1_35.Text = "Last:";
			// 
			// _Label1_34
			// 
			_Label1_34.AllowDrop = true;
			_Label1_34.AutoSize = true;
			_Label1_34.BackColor = System.Drawing.Color.Transparent;
			_Label1_34.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_34.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_34.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
			_Label1_34.Location = new System.Drawing.Point(13, 12);
			_Label1_34.MinimumSize = new System.Drawing.Size(144, 16);
			_Label1_34.Name = "_Label1_34";
			_Label1_34.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_34.Size = new System.Drawing.Size(144, 16);
			_Label1_34.TabIndex = 86;
			_Label1_34.Text = "Company Information:";
			// 
			// _Label1_33
			// 
			_Label1_33.AllowDrop = true;
			_Label1_33.AutoSize = true;
			_Label1_33.BackColor = System.Drawing.Color.Transparent;
			_Label1_33.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_33.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_33.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
			_Label1_33.Location = new System.Drawing.Point(13, 294);
			_Label1_33.MinimumSize = new System.Drawing.Size(136, 16);
			_Label1_33.Name = "_Label1_33";
			_Label1_33.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_33.Size = new System.Drawing.Size(136, 16);
			_Label1_33.TabIndex = 85;
			_Label1_33.Text = "Contact Information:";
			// 
			// _Label1_32
			// 
			_Label1_32.AllowDrop = true;
			_Label1_32.AutoSize = true;
			_Label1_32.BackColor = System.Drawing.Color.Transparent;
			_Label1_32.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_32.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_32.Location = new System.Drawing.Point(617, 362);
			_Label1_32.MinimumSize = new System.Drawing.Size(34, 13);
			_Label1_32.Name = "_Label1_32";
			_Label1_32.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_32.Size = new System.Drawing.Size(34, 13);
			_Label1_32.TabIndex = 84;
			_Label1_32.Text = "Phone:";
			// 
			// _Label1_31
			// 
			_Label1_31.AllowDrop = true;
			_Label1_31.AutoSize = true;
			_Label1_31.BackColor = System.Drawing.Color.Transparent;
			_Label1_31.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_31.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_31.Location = new System.Drawing.Point(450, 362);
			_Label1_31.MinimumSize = new System.Drawing.Size(39, 13);
			_Label1_31.Name = "_Label1_31";
			_Label1_31.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_31.Size = new System.Drawing.Size(39, 13);
			_Label1_31.TabIndex = 83;
			_Label1_31.Tag = "lbl_cntry_code";
			_Label1_31.Text = "Country:";
			// 
			// _Label1_30
			// 
			_Label1_30.AllowDrop = true;
			_Label1_30.AutoSize = true;
			_Label1_30.BackColor = System.Drawing.Color.Transparent;
			_Label1_30.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_30.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_30.Location = new System.Drawing.Point(508, 362);
			_Label1_30.MinimumSize = new System.Drawing.Size(25, 13);
			_Label1_30.Name = "_Label1_30";
			_Label1_30.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_30.Size = new System.Drawing.Size(25, 13);
			_Label1_30.TabIndex = 82;
			_Label1_30.Text = "Area:";
			// 
			// _Label1_29
			// 
			_Label1_29.AllowDrop = true;
			_Label1_29.AutoSize = true;
			_Label1_29.BackColor = System.Drawing.Color.Transparent;
			_Label1_29.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_29.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_29.Location = new System.Drawing.Point(557, 362);
			_Label1_29.MinimumSize = new System.Drawing.Size(29, 13);
			_Label1_29.Name = "_Label1_29";
			_Label1_29.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_29.Size = new System.Drawing.Size(29, 13);
			_Label1_29.TabIndex = 81;
			_Label1_29.Text = "Prefix:";
			// 
			// _Label1_28
			// 
			_Label1_28.AllowDrop = true;
			_Label1_28.AutoSize = true;
			_Label1_28.BackColor = System.Drawing.Color.Transparent;
			_Label1_28.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_28.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_28.Location = new System.Drawing.Point(617, 316);
			_Label1_28.MinimumSize = new System.Drawing.Size(34, 13);
			_Label1_28.Name = "_Label1_28";
			_Label1_28.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_28.Size = new System.Drawing.Size(34, 13);
			_Label1_28.TabIndex = 80;
			_Label1_28.Text = "Phone:";
			// 
			// _Label1_27
			// 
			_Label1_27.AllowDrop = true;
			_Label1_27.AutoSize = true;
			_Label1_27.BackColor = System.Drawing.Color.Transparent;
			_Label1_27.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_27.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_27.Location = new System.Drawing.Point(450, 316);
			_Label1_27.MinimumSize = new System.Drawing.Size(39, 13);
			_Label1_27.Name = "_Label1_27";
			_Label1_27.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_27.Size = new System.Drawing.Size(39, 13);
			_Label1_27.TabIndex = 79;
			_Label1_27.Tag = "lbl_cntry_code";
			_Label1_27.Text = "Country:";
			// 
			// _Label1_26
			// 
			_Label1_26.AllowDrop = true;
			_Label1_26.AutoSize = true;
			_Label1_26.BackColor = System.Drawing.Color.Transparent;
			_Label1_26.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_26.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_26.Location = new System.Drawing.Point(508, 316);
			_Label1_26.MinimumSize = new System.Drawing.Size(25, 13);
			_Label1_26.Name = "_Label1_26";
			_Label1_26.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_26.Size = new System.Drawing.Size(25, 13);
			_Label1_26.TabIndex = 78;
			_Label1_26.Text = "Area:";
			// 
			// _Label1_25
			// 
			_Label1_25.AllowDrop = true;
			_Label1_25.AutoSize = true;
			_Label1_25.BackColor = System.Drawing.Color.Transparent;
			_Label1_25.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_25.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_25.Location = new System.Drawing.Point(557, 316);
			_Label1_25.MinimumSize = new System.Drawing.Size(29, 13);
			_Label1_25.Name = "_Label1_25";
			_Label1_25.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_25.Size = new System.Drawing.Size(29, 13);
			_Label1_25.TabIndex = 77;
			_Label1_25.Text = "Prefix:";
			// 
			// _Label1_24
			// 
			_Label1_24.AllowDrop = true;
			_Label1_24.AutoSize = true;
			_Label1_24.BackColor = System.Drawing.Color.Transparent;
			_Label1_24.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_24.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_24.Location = new System.Drawing.Point(375, 316);
			_Label1_24.MinimumSize = new System.Drawing.Size(50, 13);
			_Label1_24.Name = "_Label1_24";
			_Label1_24.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_24.Size = new System.Drawing.Size(50, 13);
			_Label1_24.TabIndex = 76;
			_Label1_24.Text = "Phone #1:";
			_Label1_24.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// _Label1_23
			// 
			_Label1_23.AllowDrop = true;
			_Label1_23.AutoSize = true;
			_Label1_23.BackColor = System.Drawing.Color.Transparent;
			_Label1_23.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_23.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_23.Location = new System.Drawing.Point(375, 362);
			_Label1_23.MinimumSize = new System.Drawing.Size(50, 13);
			_Label1_23.Name = "_Label1_23";
			_Label1_23.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_23.Size = new System.Drawing.Size(50, 13);
			_Label1_23.TabIndex = 75;
			_Label1_23.Text = "Phone #2:";
			_Label1_23.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// _Label1_22
			// 
			_Label1_22.AllowDrop = true;
			_Label1_22.AutoSize = true;
			_Label1_22.BackColor = System.Drawing.Color.Transparent;
			_Label1_22.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_22.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_22.Location = new System.Drawing.Point(617, 71);
			_Label1_22.MinimumSize = new System.Drawing.Size(34, 13);
			_Label1_22.Name = "_Label1_22";
			_Label1_22.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_22.Size = new System.Drawing.Size(34, 13);
			_Label1_22.TabIndex = 74;
			_Label1_22.Text = "Phone:";
			// 
			// _Label1_21
			// 
			_Label1_21.AllowDrop = true;
			_Label1_21.AutoSize = true;
			_Label1_21.BackColor = System.Drawing.Color.Transparent;
			_Label1_21.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_21.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_21.Location = new System.Drawing.Point(450, 71);
			_Label1_21.MinimumSize = new System.Drawing.Size(39, 13);
			_Label1_21.Name = "_Label1_21";
			_Label1_21.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_21.Size = new System.Drawing.Size(39, 13);
			_Label1_21.TabIndex = 73;
			_Label1_21.Tag = "lbl_cntry_code";
			_Label1_21.Text = "Country:";
			// 
			// _Label1_20
			// 
			_Label1_20.AllowDrop = true;
			_Label1_20.AutoSize = true;
			_Label1_20.BackColor = System.Drawing.Color.Transparent;
			_Label1_20.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_20.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_20.Location = new System.Drawing.Point(508, 71);
			_Label1_20.MinimumSize = new System.Drawing.Size(25, 13);
			_Label1_20.Name = "_Label1_20";
			_Label1_20.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_20.Size = new System.Drawing.Size(25, 13);
			_Label1_20.TabIndex = 72;
			_Label1_20.Text = "Area:";
			// 
			// _Label1_19
			// 
			_Label1_19.AllowDrop = true;
			_Label1_19.AutoSize = true;
			_Label1_19.BackColor = System.Drawing.Color.Transparent;
			_Label1_19.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_19.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_19.Location = new System.Drawing.Point(557, 71);
			_Label1_19.MinimumSize = new System.Drawing.Size(29, 13);
			_Label1_19.Name = "_Label1_19";
			_Label1_19.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_19.Size = new System.Drawing.Size(29, 13);
			_Label1_19.TabIndex = 71;
			_Label1_19.Text = "Prefix:";
			// 
			// _Label1_18
			// 
			_Label1_18.AllowDrop = true;
			_Label1_18.AutoSize = true;
			_Label1_18.BackColor = System.Drawing.Color.Transparent;
			_Label1_18.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_18.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_18.Location = new System.Drawing.Point(617, 20);
			_Label1_18.MinimumSize = new System.Drawing.Size(34, 13);
			_Label1_18.Name = "_Label1_18";
			_Label1_18.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_18.Size = new System.Drawing.Size(34, 13);
			_Label1_18.TabIndex = 70;
			_Label1_18.Text = "Phone:";
			// 
			// _Label1_15
			// 
			_Label1_15.AllowDrop = true;
			_Label1_15.AutoSize = true;
			_Label1_15.BackColor = System.Drawing.Color.Transparent;
			_Label1_15.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_15.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_15.Location = new System.Drawing.Point(450, 20);
			_Label1_15.MinimumSize = new System.Drawing.Size(39, 13);
			_Label1_15.Name = "_Label1_15";
			_Label1_15.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_15.Size = new System.Drawing.Size(39, 13);
			_Label1_15.TabIndex = 69;
			_Label1_15.Tag = "lbl_cntry_code";
			_Label1_15.Text = "Country:";
			// 
			// _Label1_16
			// 
			_Label1_16.AllowDrop = true;
			_Label1_16.AutoSize = true;
			_Label1_16.BackColor = System.Drawing.Color.Transparent;
			_Label1_16.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_16.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_16.Location = new System.Drawing.Point(508, 20);
			_Label1_16.MinimumSize = new System.Drawing.Size(25, 13);
			_Label1_16.Name = "_Label1_16";
			_Label1_16.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_16.Size = new System.Drawing.Size(25, 13);
			_Label1_16.TabIndex = 68;
			_Label1_16.Text = "Area:";
			// 
			// _Label1_17
			// 
			_Label1_17.AllowDrop = true;
			_Label1_17.AutoSize = true;
			_Label1_17.BackColor = System.Drawing.Color.Transparent;
			_Label1_17.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_17.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_17.Location = new System.Drawing.Point(557, 20);
			_Label1_17.MinimumSize = new System.Drawing.Size(29, 13);
			_Label1_17.Name = "_Label1_17";
			_Label1_17.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_17.Size = new System.Drawing.Size(29, 13);
			_Label1_17.TabIndex = 67;
			_Label1_17.Text = "Prefix:";
			// 
			// _Label1_14
			// 
			_Label1_14.AllowDrop = true;
			_Label1_14.AutoSize = true;
			_Label1_14.BackColor = System.Drawing.Color.Transparent;
			_Label1_14.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_14.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_14.Location = new System.Drawing.Point(375, 71);
			_Label1_14.MinimumSize = new System.Drawing.Size(50, 13);
			_Label1_14.Name = "_Label1_14";
			_Label1_14.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_14.Size = new System.Drawing.Size(50, 13);
			_Label1_14.TabIndex = 66;
			_Label1_14.Text = "Phone #2:";
			_Label1_14.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// _Label1_13
			// 
			_Label1_13.AllowDrop = true;
			_Label1_13.AutoSize = true;
			_Label1_13.BackColor = System.Drawing.Color.Transparent;
			_Label1_13.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_13.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_13.Location = new System.Drawing.Point(375, 20);
			_Label1_13.MinimumSize = new System.Drawing.Size(50, 13);
			_Label1_13.Name = "_Label1_13";
			_Label1_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_13.Size = new System.Drawing.Size(50, 13);
			_Label1_13.TabIndex = 65;
			_Label1_13.Text = "Phone #1:";
			_Label1_13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// _Label1_0
			// 
			_Label1_0.AllowDrop = true;
			_Label1_0.AutoSize = true;
			_Label1_0.BackColor = System.Drawing.Color.Transparent;
			_Label1_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_0.Location = new System.Drawing.Point(32, 38);
			_Label1_0.MinimumSize = new System.Drawing.Size(31, 13);
			_Label1_0.Name = "_Label1_0";
			_Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_0.Size = new System.Drawing.Size(31, 13);
			_Label1_0.TabIndex = 64;
			_Label1_0.Text = "Name:";
			_Label1_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// _Label1_1
			// 
			_Label1_1.AllowDrop = true;
			_Label1_1.AutoSize = true;
			_Label1_1.BackColor = System.Drawing.Color.Transparent;
			_Label1_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_1.Location = new System.Drawing.Point(13, 90);
			_Label1_1.MinimumSize = new System.Drawing.Size(50, 13);
			_Label1_1.Name = "_Label1_1";
			_Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_1.Size = new System.Drawing.Size(50, 13);
			_Label1_1.TabIndex = 63;
			_Label1_1.Text = "Address 1:";
			_Label1_1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// _Label1_2
			// 
			_Label1_2.AllowDrop = true;
			_Label1_2.AutoSize = true;
			_Label1_2.BackColor = System.Drawing.Color.Transparent;
			_Label1_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_2.Location = new System.Drawing.Point(13, 117);
			_Label1_2.MinimumSize = new System.Drawing.Size(50, 13);
			_Label1_2.Name = "_Label1_2";
			_Label1_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_2.Size = new System.Drawing.Size(50, 13);
			_Label1_2.TabIndex = 62;
			_Label1_2.Text = "Address 2:";
			_Label1_2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// _Label1_3
			// 
			_Label1_3.AllowDrop = true;
			_Label1_3.AutoSize = true;
			_Label1_3.BackColor = System.Drawing.Color.Transparent;
			_Label1_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_3.Location = new System.Drawing.Point(43, 146);
			_Label1_3.MinimumSize = new System.Drawing.Size(20, 13);
			_Label1_3.Name = "_Label1_3";
			_Label1_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_3.Size = new System.Drawing.Size(20, 13);
			_Label1_3.TabIndex = 61;
			_Label1_3.Text = "City:";
			_Label1_3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// _Label1_4
			// 
			_Label1_4.AllowDrop = true;
			_Label1_4.AutoSize = true;
			_Label1_4.BackColor = System.Drawing.Color.Transparent;
			_Label1_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_4.Location = new System.Drawing.Point(35, 172);
			_Label1_4.MinimumSize = new System.Drawing.Size(28, 13);
			_Label1_4.Name = "_Label1_4";
			_Label1_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_4.Size = new System.Drawing.Size(28, 13);
			_Label1_4.TabIndex = 60;
			_Label1_4.Text = "State:";
			_Label1_4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// _Label1_12
			// 
			_Label1_12.AllowDrop = true;
			_Label1_12.AutoSize = true;
			_Label1_12.BackColor = System.Drawing.Color.Transparent;
			_Label1_12.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_12.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_12.Location = new System.Drawing.Point(367, 263);
			_Label1_12.MinimumSize = new System.Drawing.Size(66, 13);
			_Label1_12.Name = "_Label1_12";
			_Label1_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_12.Size = new System.Drawing.Size(66, 13);
			_Label1_12.TabIndex = 59;
			_Label1_12.Text = "Account Rep:";
			_Label1_12.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// _Label1_11
			// 
			_Label1_11.AllowDrop = true;
			_Label1_11.AutoSize = true;
			_Label1_11.BackColor = System.Drawing.Color.Transparent;
			_Label1_11.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_11.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_11.Location = new System.Drawing.Point(53, 263);
			_Label1_11.MinimumSize = new System.Drawing.Size(70, 13);
			_Label1_11.Name = "_Label1_11";
			_Label1_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_11.Size = new System.Drawing.Size(70, 13);
			_Label1_11.TabIndex = 58;
			_Label1_11.Text = "Account Type:";
			_Label1_11.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lbl_status_display
			// 
			lbl_status_display.AllowDrop = true;
			lbl_status_display.BackColor = System.Drawing.Color.Transparent;
			lbl_status_display.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lbl_status_display.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_status_display.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
			lbl_status_display.Location = new System.Drawing.Point(8, 602);
			lbl_status_display.MinimumSize = new System.Drawing.Size(667, 20);
			lbl_status_display.Name = "lbl_status_display";
			lbl_status_display.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_status_display.Size = new System.Drawing.Size(667, 20);
			lbl_status_display.TabIndex = 57;
			lbl_status_display.Text = "Ready :";
			// 
			// _Label1_9
			// 
			_Label1_9.AllowDrop = true;
			_Label1_9.AutoSize = true;
			_Label1_9.BackColor = System.Drawing.Color.Transparent;
			_Label1_9.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_9.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_9.Location = new System.Drawing.Point(382, 238);
			_Label1_9.MinimumSize = new System.Drawing.Size(51, 13);
			_Label1_9.Name = "_Label1_9";
			_Label1_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_9.Size = new System.Drawing.Size(51, 13);
			_Label1_9.TabIndex = 56;
			_Label1_9.Text = "Language:";
			_Label1_9.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// _Label1_8
			// 
			_Label1_8.AllowDrop = true;
			_Label1_8.AutoSize = true;
			_Label1_8.BackColor = System.Drawing.Color.Transparent;
			_Label1_8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_8.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_8.Location = new System.Drawing.Point(51, 238);
			_Label1_8.MinimumSize = new System.Drawing.Size(72, 13);
			_Label1_8.Name = "_Label1_8";
			_Label1_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_8.Size = new System.Drawing.Size(72, 13);
			_Label1_8.TabIndex = 55;
			_Label1_8.Text = "Business Type:";
			_Label1_8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// _Label1_5
			// 
			_Label1_5.AllowDrop = true;
			_Label1_5.AutoSize = true;
			_Label1_5.BackColor = System.Drawing.Color.Transparent;
			_Label1_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_5.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_5.Location = new System.Drawing.Point(213, 145);
			_Label1_5.MinimumSize = new System.Drawing.Size(60, 13);
			_Label1_5.Name = "_Label1_5";
			_Label1_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_5.Size = new System.Drawing.Size(60, 13);
			_Label1_5.TabIndex = 54;
			_Label1_5.Text = "Postal Code:";
			_Label1_5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// frm_CompanyAdd
			// 
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			ClientSize = new System.Drawing.Size(680, 625);
			Controls.Add(chk_hide_company);
			Controls.Add(cmd_copy_company);
			Controls.Add(chkCompContactAddressFlag);
			Controls.Add(_Text1_33);
			Controls.Add(_Text1_32);
			Controls.Add(cmb_product_code);
			Controls.Add(cmb_agency_type);
			Controls.Add(cmb_state_code);
			Controls.Add(cmb_country_code);
			Controls.Add(chk_auto_account_rep);
			Controls.Add(_Text1_31);
			Controls.Add(_Text1_12);
			Controls.Add(_Text1_27);
			Controls.Add(chk_attach_to_contact);
			Controls.Add(_Text1_30);
			Controls.Add(_Text1_29);
			Controls.Add(_Text1_28);
			Controls.Add(cmb_comp_name_alt_type);
			Controls.Add(_Text1_26);
			Controls.Add(chk_hide_from_customer);
			Controls.Add(_Text1_25);
			Controls.Add(_cmd_CompanyAction_0);
			Controls.Add(_cmd_CompanyAction_1);
			Controls.Add(_cmd_CompanyAction_2);
			Controls.Add(_Text1_22);
			Controls.Add(cmb_contact_title);
			Controls.Add(cmb_suffix);
			Controls.Add(_Text1_24);
			Controls.Add(_Text1_23);
			Controls.Add(cmb_sirname);
			Controls.Add(_Text1_21);
			Controls.Add(_Text1_18);
			Controls.Add(_Text1_20);
			Controls.Add(_Text1_17);
			Controls.Add(_Text1_19);
			Controls.Add(_Text1_14);
			Controls.Add(_Text1_16);
			Controls.Add(_Text1_13);
			Controls.Add(_Text1_15);
			Controls.Add(_cmb_phone_type_2);
			Controls.Add(_cmb_phone_type_3);
			Controls.Add(_Text1_10);
			Controls.Add(_Text1_9);
			Controls.Add(_Text1_11);
			Controls.Add(_Text1_6);
			Controls.Add(_Text1_8);
			Controls.Add(_Text1_5);
			Controls.Add(_Text1_7);
			Controls.Add(_cmb_phone_type_1);
			Controls.Add(_cmb_phone_type_0);
			Controls.Add(cmb_account_id);
			Controls.Add(cmb_account_type);
			Controls.Add(cmb_language);
			Controls.Add(cmb_business_type);
			Controls.Add(_Text1_4);
			Controls.Add(_Text1_3);
			Controls.Add(_Text1_2);
			Controls.Add(_Text1_1);
			Controls.Add(_Text1_0);
			Controls.Add(_Label1_52);
			Controls.Add(_Label1_51);
			Controls.Add(_Label1_50);
			Controls.Add(_Shape1_0);
			Controls.Add(_Label1_7);
			Controls.Add(_Label1_6);
			Controls.Add(_Label1_10);
			Controls.Add(_Label1_49);
			Controls.Add(_Shape1_2);
			Controls.Add(_Label1_48);
			Controls.Add(_Label1_47);
			Controls.Add(_Label1_46);
			Controls.Add(_Label1_45);
			Controls.Add(_Label1_44);
			Controls.Add(_Label1_43);
			Controls.Add(_Label1_42);
			Controls.Add(_Label1_37);
			Controls.Add(_Label1_41);
			Controls.Add(_Shape1_1);
			Controls.Add(_Label1_40);
			Controls.Add(_Label1_39);
			Controls.Add(_Label1_38);
			Controls.Add(_Label1_36);
			Controls.Add(_Label1_35);
			Controls.Add(_Label1_34);
			Controls.Add(_Label1_33);
			Controls.Add(_Label1_32);
			Controls.Add(_Label1_31);
			Controls.Add(_Label1_30);
			Controls.Add(_Label1_29);
			Controls.Add(_Label1_28);
			Controls.Add(_Label1_27);
			Controls.Add(_Label1_26);
			Controls.Add(_Label1_25);
			Controls.Add(_Label1_24);
			Controls.Add(_Label1_23);
			Controls.Add(_Label1_22);
			Controls.Add(_Label1_21);
			Controls.Add(_Label1_20);
			Controls.Add(_Label1_19);
			Controls.Add(_Label1_18);
			Controls.Add(_Label1_15);
			Controls.Add(_Label1_16);
			Controls.Add(_Label1_17);
			Controls.Add(_Label1_14);
			Controls.Add(_Label1_13);
			Controls.Add(_Label1_0);
			Controls.Add(_Label1_1);
			Controls.Add(_Label1_2);
			Controls.Add(_Label1_3);
			Controls.Add(_Label1_4);
			Controls.Add(_Label1_12);
			Controls.Add(_Label1_11);
			Controls.Add(lbl_status_display);
			Controls.Add(_Label1_9);
			Controls.Add(_Label1_8);
			Controls.Add(_Label1_5);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			Location = new System.Drawing.Point(291, 211);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "frm_CompanyAdd";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			Text = "Quick Entry Company/Contact Form";
			commandButtonHelper1.SetStyle(cmd_copy_company, 0);
			commandButtonHelper1.SetStyle(_cmd_CompanyAction_0, 0);
			commandButtonHelper1.SetStyle(_cmd_CompanyAction_1, 0);
			commandButtonHelper1.SetStyle(_cmd_CompanyAction_2, 0);
			listBoxComboBoxHelper1.SetItemData(cmb_comp_name_alt_type, new int[]{0, 1, 2});
			ToolTipMain.SetToolTip(chkCompContactAddressFlag, "Check If This Company Record Is A Contact Address Record");
			Activated += new System.EventHandler(Form_Activated);
			Closed += new System.EventHandler(Form_Closed);
			((System.ComponentModel.ISupportInitialize) listBoxComboBoxHelper1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
		void ReLoadForm(bool addEvents)
		{
			Initializecmd_CompanyAction();
			Initializecmb_phone_type();
			InitializeText1();
			InitializeShape1();
			InitializeLabel1();
			Form_Initialize();
		}
		void Initializecmd_CompanyAction()
		{
			cmd_CompanyAction = new System.Windows.Forms.Button[3];
			cmd_CompanyAction[0] = _cmd_CompanyAction_0;
			cmd_CompanyAction[1] = _cmd_CompanyAction_1;
			cmd_CompanyAction[2] = _cmd_CompanyAction_2;
		}
		void Initializecmb_phone_type()
		{
			cmb_phone_type = new System.Windows.Forms.ComboBox[4];
			cmb_phone_type[2] = _cmb_phone_type_2;
			cmb_phone_type[3] = _cmb_phone_type_3;
			cmb_phone_type[1] = _cmb_phone_type_1;
			cmb_phone_type[0] = _cmb_phone_type_0;
		}
		void InitializeText1()
		{
			Text1 = new System.Windows.Forms.TextBox[34];
			Text1[33] = _Text1_33;
			Text1[32] = _Text1_32;
			Text1[31] = _Text1_31;
			Text1[12] = _Text1_12;
			Text1[27] = _Text1_27;
			Text1[30] = _Text1_30;
			Text1[29] = _Text1_29;
			Text1[28] = _Text1_28;
			Text1[26] = _Text1_26;
			Text1[25] = _Text1_25;
			Text1[22] = _Text1_22;
			Text1[24] = _Text1_24;
			Text1[23] = _Text1_23;
			Text1[21] = _Text1_21;
			Text1[18] = _Text1_18;
			Text1[20] = _Text1_20;
			Text1[17] = _Text1_17;
			Text1[19] = _Text1_19;
			Text1[14] = _Text1_14;
			Text1[16] = _Text1_16;
			Text1[13] = _Text1_13;
			Text1[15] = _Text1_15;
			Text1[10] = _Text1_10;
			Text1[9] = _Text1_9;
			Text1[11] = _Text1_11;
			Text1[6] = _Text1_6;
			Text1[8] = _Text1_8;
			Text1[5] = _Text1_5;
			Text1[7] = _Text1_7;
			Text1[4] = _Text1_4;
			Text1[3] = _Text1_3;
			Text1[2] = _Text1_2;
			Text1[1] = _Text1_1;
			Text1[0] = _Text1_0;
		}
		void InitializeShape1()
		{
			Shape1 = new UpgradeHelpers.Gui.ShapeHelper[3];
			Shape1[0] = _Shape1_0;
			Shape1[2] = _Shape1_2;
			Shape1[1] = _Shape1_1;
		}
		void InitializeLabel1()
		{
			Label1 = new System.Windows.Forms.Label[53];
			Label1[52] = _Label1_52;
			Label1[51] = _Label1_51;
			Label1[50] = _Label1_50;
			Label1[7] = _Label1_7;
			Label1[6] = _Label1_6;
			Label1[10] = _Label1_10;
			Label1[49] = _Label1_49;
			Label1[48] = _Label1_48;
			Label1[47] = _Label1_47;
			Label1[46] = _Label1_46;
			Label1[45] = _Label1_45;
			Label1[44] = _Label1_44;
			Label1[43] = _Label1_43;
			Label1[42] = _Label1_42;
			Label1[37] = _Label1_37;
			Label1[41] = _Label1_41;
			Label1[40] = _Label1_40;
			Label1[39] = _Label1_39;
			Label1[38] = _Label1_38;
			Label1[36] = _Label1_36;
			Label1[35] = _Label1_35;
			Label1[34] = _Label1_34;
			Label1[33] = _Label1_33;
			Label1[32] = _Label1_32;
			Label1[31] = _Label1_31;
			Label1[30] = _Label1_30;
			Label1[29] = _Label1_29;
			Label1[28] = _Label1_28;
			Label1[27] = _Label1_27;
			Label1[26] = _Label1_26;
			Label1[25] = _Label1_25;
			Label1[24] = _Label1_24;
			Label1[23] = _Label1_23;
			Label1[22] = _Label1_22;
			Label1[21] = _Label1_21;
			Label1[20] = _Label1_20;
			Label1[19] = _Label1_19;
			Label1[18] = _Label1_18;
			Label1[15] = _Label1_15;
			Label1[16] = _Label1_16;
			Label1[17] = _Label1_17;
			Label1[14] = _Label1_14;
			Label1[13] = _Label1_13;
			Label1[0] = _Label1_0;
			Label1[1] = _Label1_1;
			Label1[2] = _Label1_2;
			Label1[3] = _Label1_3;
			Label1[4] = _Label1_4;
			Label1[12] = _Label1_12;
			Label1[11] = _Label1_11;
			Label1[9] = _Label1_9;
			Label1[8] = _Label1_8;
			Label1[5] = _Label1_5;
		}
		#endregion
	}
}