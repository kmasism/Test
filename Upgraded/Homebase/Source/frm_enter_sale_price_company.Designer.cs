
namespace JETNET_Homebase
{
	partial class frm_enter_sale_price_company
	{

		#region "Upgrade Support "
		private static frm_enter_sale_price_company m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_enter_sale_price_company DefInstance
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
		public static frm_enter_sale_price_company CreateInstance()
		{
			frm_enter_sale_price_company theInstance = new frm_enter_sale_price_company();
			theInstance.Form_Load();
			return theInstance;
		}
		private string[] visualControls = new string[]{"components", "ToolTipMain", "cmd_select_company", "txtAddress", "txtPhoneNbr", "chk_inactive", "txt_contact_last", "txt_contact_first", "cmd_clear", "cmd_find_now", "cbo_country", "text_state", "text_city", "text_company_id", "text_company_name", "lbl_loc_address", "lblPhoneNbr", "Label1", "lbl_contact_first", "lbl_country", "lbl_state", "lbl_loc_city", "lbl_comp_id", "lbl_comp_name", "frame_search", "grd_company_list", "frm_company_search", "lst_aircraft_info", "txt_notes", "txt_total_landings", "txt_aftt", "company_details_list", "frame_comp_details", "txt_asking_price", "txt_sale_price", "txt_comp_id", "txt_contact_name", "cmd_find_company_id", "cmd_submit_record", "_lbl_asking_4", "_lbl_asking_3", "_lbl_asking_2", "_lbl_asking_1", "_lbl_asking_0", "lbl_sub_id", "lbl_contact_name", "lbl_comp_id_enter", "lbl_warning", "frm_Sale_Price_Data", "lbl_asking", "listBoxHelper1", "commandButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Button cmd_select_company;
		public System.Windows.Forms.TextBox txtAddress;
		public System.Windows.Forms.TextBox txtPhoneNbr;
		public System.Windows.Forms.CheckBox chk_inactive;
		public System.Windows.Forms.TextBox txt_contact_last;
		public System.Windows.Forms.TextBox txt_contact_first;
		public System.Windows.Forms.Button cmd_clear;
		public System.Windows.Forms.Button cmd_find_now;
		public System.Windows.Forms.ComboBox cbo_country;
		public System.Windows.Forms.TextBox text_state;
		public System.Windows.Forms.TextBox text_city;
		public System.Windows.Forms.TextBox text_company_id;
		public System.Windows.Forms.TextBox text_company_name;
		public System.Windows.Forms.Label lbl_loc_address;
		public System.Windows.Forms.Label lblPhoneNbr;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label lbl_contact_first;
		public System.Windows.Forms.Label lbl_country;
		public System.Windows.Forms.Label lbl_state;
		public System.Windows.Forms.Label lbl_loc_city;
		public System.Windows.Forms.Label lbl_comp_id;
		public System.Windows.Forms.Label lbl_comp_name;
		public System.Windows.Forms.GroupBox frame_search;
		public UpgradeHelpers.DataGridViewFlex grd_company_list;
		public System.Windows.Forms.GroupBox frm_company_search;
		public System.Windows.Forms.ListBox lst_aircraft_info;
		public System.Windows.Forms.TextBox txt_notes;
		public System.Windows.Forms.TextBox txt_total_landings;
		public System.Windows.Forms.TextBox txt_aftt;
		public System.Windows.Forms.ListBox company_details_list;
		public System.Windows.Forms.GroupBox frame_comp_details;
		public System.Windows.Forms.TextBox txt_asking_price;
		public System.Windows.Forms.TextBox txt_sale_price;
		public System.Windows.Forms.TextBox txt_comp_id;
		public System.Windows.Forms.TextBox txt_contact_name;
		public System.Windows.Forms.Button cmd_find_company_id;
		public System.Windows.Forms.Button cmd_submit_record;
		private System.Windows.Forms.Label _lbl_asking_4;
		private System.Windows.Forms.Label _lbl_asking_3;
		private System.Windows.Forms.Label _lbl_asking_2;
		private System.Windows.Forms.Label _lbl_asking_1;
		private System.Windows.Forms.Label _lbl_asking_0;
		public System.Windows.Forms.Label lbl_sub_id;
		public System.Windows.Forms.Label lbl_contact_name;
		public System.Windows.Forms.Label lbl_comp_id_enter;
		public System.Windows.Forms.Label lbl_warning;
		public System.Windows.Forms.GroupBox frm_Sale_Price_Data;
		public System.Windows.Forms.Label[] lbl_asking = new System.Windows.Forms.Label[5];
		public UpgradeHelpers.Gui.Controls.ListBoxHelper listBoxHelper1;
		public UpgradeHelpers.Gui.Controls.CommandButtonHelper commandButtonHelper1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_enter_sale_price_company));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			frm_company_search = new System.Windows.Forms.GroupBox();
			cmd_select_company = new System.Windows.Forms.Button();
			frame_search = new System.Windows.Forms.GroupBox();
			txtAddress = new System.Windows.Forms.TextBox();
			txtPhoneNbr = new System.Windows.Forms.TextBox();
			chk_inactive = new System.Windows.Forms.CheckBox();
			txt_contact_last = new System.Windows.Forms.TextBox();
			txt_contact_first = new System.Windows.Forms.TextBox();
			cmd_clear = new System.Windows.Forms.Button();
			cmd_find_now = new System.Windows.Forms.Button();
			cbo_country = new System.Windows.Forms.ComboBox();
			text_state = new System.Windows.Forms.TextBox();
			text_city = new System.Windows.Forms.TextBox();
			text_company_id = new System.Windows.Forms.TextBox();
			text_company_name = new System.Windows.Forms.TextBox();
			lbl_loc_address = new System.Windows.Forms.Label();
			lblPhoneNbr = new System.Windows.Forms.Label();
			Label1 = new System.Windows.Forms.Label();
			lbl_contact_first = new System.Windows.Forms.Label();
			lbl_country = new System.Windows.Forms.Label();
			lbl_state = new System.Windows.Forms.Label();
			lbl_loc_city = new System.Windows.Forms.Label();
			lbl_comp_id = new System.Windows.Forms.Label();
			lbl_comp_name = new System.Windows.Forms.Label();
			grd_company_list = new UpgradeHelpers.DataGridViewFlex(components);
			frm_Sale_Price_Data = new System.Windows.Forms.GroupBox();
			lst_aircraft_info = new System.Windows.Forms.ListBox();
			txt_notes = new System.Windows.Forms.TextBox();
			txt_total_landings = new System.Windows.Forms.TextBox();
			txt_aftt = new System.Windows.Forms.TextBox();
			frame_comp_details = new System.Windows.Forms.GroupBox();
			company_details_list = new System.Windows.Forms.ListBox();
			txt_asking_price = new System.Windows.Forms.TextBox();
			txt_sale_price = new System.Windows.Forms.TextBox();
			txt_comp_id = new System.Windows.Forms.TextBox();
			txt_contact_name = new System.Windows.Forms.TextBox();
			cmd_find_company_id = new System.Windows.Forms.Button();
			cmd_submit_record = new System.Windows.Forms.Button();
			_lbl_asking_4 = new System.Windows.Forms.Label();
			_lbl_asking_3 = new System.Windows.Forms.Label();
			_lbl_asking_2 = new System.Windows.Forms.Label();
			_lbl_asking_1 = new System.Windows.Forms.Label();
			_lbl_asking_0 = new System.Windows.Forms.Label();
			lbl_sub_id = new System.Windows.Forms.Label();
			lbl_contact_name = new System.Windows.Forms.Label();
			lbl_comp_id_enter = new System.Windows.Forms.Label();
			lbl_warning = new System.Windows.Forms.Label();
			frm_company_search.SuspendLayout();
			frame_search.SuspendLayout();
			frm_Sale_Price_Data.SuspendLayout();
			frame_comp_details.SuspendLayout();
			SuspendLayout();
			listBoxHelper1 = new UpgradeHelpers.Gui.Controls.ListBoxHelper(components);
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
			((System.ComponentModel.ISupportInitialize) grd_company_list).BeginInit();
			// 
			// frm_company_search
			// 
			frm_company_search.AllowDrop = true;
			frm_company_search.BackColor = System.Drawing.SystemColors.Control;
			frm_company_search.Controls.Add(cmd_select_company);
			frm_company_search.Controls.Add(frame_search);
			frm_company_search.Controls.Add(grd_company_list);
			frm_company_search.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frm_company_search.Enabled = true;
			frm_company_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frm_company_search.ForeColor = System.Drawing.SystemColors.ControlText;
			frm_company_search.Location = new System.Drawing.Point(2, 198);
			frm_company_search.Name = "frm_company_search";
			frm_company_search.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frm_company_search.Size = new System.Drawing.Size(779, 469);
			frm_company_search.TabIndex = 1;
			frm_company_search.Text = "Frame1";
			frm_company_search.Visible = false;
			// 
			// cmd_select_company
			// 
			cmd_select_company.AllowDrop = true;
			cmd_select_company.BackColor = System.Drawing.SystemColors.Control;
			cmd_select_company.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_select_company.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_select_company.Location = new System.Drawing.Point(678, 398);
			cmd_select_company.Name = "cmd_select_company";
			cmd_select_company.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_select_company.Size = new System.Drawing.Size(93, 31);
			cmd_select_company.TabIndex = 25;
			cmd_select_company.Text = "Select Company";
			cmd_select_company.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_select_company.UseVisualStyleBackColor = false;
			cmd_select_company.Click += new System.EventHandler(cmd_select_company_Click);
			cmd_select_company.KeyPress += new System.Windows.Forms.KeyPressEventHandler(cmd_select_company_KeyPress);
			// 
			// frame_search
			// 
			frame_search.AllowDrop = true;
			frame_search.BackColor = System.Drawing.SystemColors.Control;
			frame_search.Controls.Add(txtAddress);
			frame_search.Controls.Add(txtPhoneNbr);
			frame_search.Controls.Add(chk_inactive);
			frame_search.Controls.Add(txt_contact_last);
			frame_search.Controls.Add(txt_contact_first);
			frame_search.Controls.Add(cmd_clear);
			frame_search.Controls.Add(cmd_find_now);
			frame_search.Controls.Add(cbo_country);
			frame_search.Controls.Add(text_state);
			frame_search.Controls.Add(text_city);
			frame_search.Controls.Add(text_company_id);
			frame_search.Controls.Add(text_company_name);
			frame_search.Controls.Add(lbl_loc_address);
			frame_search.Controls.Add(lblPhoneNbr);
			frame_search.Controls.Add(Label1);
			frame_search.Controls.Add(lbl_contact_first);
			frame_search.Controls.Add(lbl_country);
			frame_search.Controls.Add(lbl_state);
			frame_search.Controls.Add(lbl_loc_city);
			frame_search.Controls.Add(lbl_comp_id);
			frame_search.Controls.Add(lbl_comp_name);
			frame_search.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frame_search.Enabled = true;
			frame_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frame_search.ForeColor = System.Drawing.SystemColors.ControlText;
			frame_search.Location = new System.Drawing.Point(2, 2);
			frame_search.Name = "frame_search";
			frame_search.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frame_search.Size = new System.Drawing.Size(773, 133);
			frame_search.TabIndex = 2;
			frame_search.Text = "Search";
			frame_search.Visible = true;
			// 
			// txtAddress
			// 
			txtAddress.AcceptsReturn = true;
			txtAddress.AllowDrop = true;
			txtAddress.BackColor = System.Drawing.SystemColors.Window;
			txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtAddress.ForeColor = System.Drawing.SystemColors.WindowText;
			txtAddress.Location = new System.Drawing.Point(94, 106);
			txtAddress.MaxLength = 0;
			txtAddress.Name = "txtAddress";
			txtAddress.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtAddress.Size = new System.Drawing.Size(153, 19);
			txtAddress.TabIndex = 8;
			txtAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtAddress_KeyPress);
			// 
			// txtPhoneNbr
			// 
			txtPhoneNbr.AcceptsReturn = true;
			txtPhoneNbr.AllowDrop = true;
			txtPhoneNbr.BackColor = System.Drawing.SystemColors.Window;
			txtPhoneNbr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtPhoneNbr.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtPhoneNbr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtPhoneNbr.ForeColor = System.Drawing.SystemColors.WindowText;
			txtPhoneNbr.Location = new System.Drawing.Point(94, 84);
			txtPhoneNbr.MaxLength = 0;
			txtPhoneNbr.Name = "txtPhoneNbr";
			txtPhoneNbr.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtPhoneNbr.Size = new System.Drawing.Size(145, 19);
			txtPhoneNbr.TabIndex = 7;
			txtPhoneNbr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtPhoneNbr_KeyPress);
			// 
			// chk_inactive
			// 
			chk_inactive.AllowDrop = true;
			chk_inactive.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_inactive.BackColor = System.Drawing.SystemColors.Control;
			chk_inactive.CausesValidation = true;
			chk_inactive.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_inactive.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_inactive.Enabled = true;
			chk_inactive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_inactive.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_inactive.Location = new System.Drawing.Point(178, 18);
			chk_inactive.Name = "chk_inactive";
			chk_inactive.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_inactive.Size = new System.Drawing.Size(169, 17);
			chk_inactive.TabIndex = 14;
			chk_inactive.TabStop = true;
			chk_inactive.Text = "Include Inactive Companies";
			chk_inactive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_inactive.Visible = true;
			// 
			// txt_contact_last
			// 
			txt_contact_last.AcceptsReturn = true;
			txt_contact_last.AllowDrop = true;
			txt_contact_last.BackColor = System.Drawing.SystemColors.Window;
			txt_contact_last.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_contact_last.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_contact_last.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_contact_last.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_contact_last.Location = new System.Drawing.Point(218, 60);
			txt_contact_last.MaxLength = 0;
			txt_contact_last.Name = "txt_contact_last";
			txt_contact_last.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_contact_last.Size = new System.Drawing.Size(101, 19);
			txt_contact_last.TabIndex = 6;
			txt_contact_last.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txt_contact_last_KeyPress);
			// 
			// txt_contact_first
			// 
			txt_contact_first.AcceptsReturn = true;
			txt_contact_first.AllowDrop = true;
			txt_contact_first.BackColor = System.Drawing.SystemColors.Window;
			txt_contact_first.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_contact_first.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_contact_first.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_contact_first.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_contact_first.Location = new System.Drawing.Point(94, 62);
			txt_contact_first.MaxLength = 0;
			txt_contact_first.Name = "txt_contact_first";
			txt_contact_first.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_contact_first.Size = new System.Drawing.Size(81, 19);
			txt_contact_first.TabIndex = 5;
			txt_contact_first.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txt_contact_first_KeyPress);
			// 
			// cmd_clear
			// 
			cmd_clear.AllowDrop = true;
			cmd_clear.BackColor = System.Drawing.SystemColors.Control;
			cmd_clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_clear.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_clear.Location = new System.Drawing.Point(568, 54);
			cmd_clear.Name = "cmd_clear";
			cmd_clear.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_clear.Size = new System.Drawing.Size(41, 25);
			cmd_clear.TabIndex = 13;
			cmd_clear.Text = "Clear";
			cmd_clear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_clear.UseVisualStyleBackColor = false;
			cmd_clear.Click += new System.EventHandler(cmd_Clear_Click);
			// 
			// cmd_find_now
			// 
			cmd_find_now.AllowDrop = true;
			cmd_find_now.BackColor = System.Drawing.SystemColors.Control;
			cmd_find_now.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_find_now.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_find_now.Location = new System.Drawing.Point(552, 16);
			cmd_find_now.Name = "cmd_find_now";
			cmd_find_now.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_find_now.Size = new System.Drawing.Size(79, 33);
			cmd_find_now.TabIndex = 11;
			cmd_find_now.Text = "&Find Now";
			cmd_find_now.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_find_now.UseVisualStyleBackColor = false;
			cmd_find_now.Click += new System.EventHandler(cmd_find_now_Click);
			// 
			// cbo_country
			// 
			cbo_country.AllowDrop = true;
			cbo_country.BackColor = System.Drawing.SystemColors.Window;
			cbo_country.CausesValidation = true;
			cbo_country.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_country.Enabled = true;
			cbo_country.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_country.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_country.IntegralHeight = true;
			cbo_country.Location = new System.Drawing.Point(552, 106);
			cbo_country.Name = "cbo_country";
			cbo_country.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_country.Size = new System.Drawing.Size(145, 21);
			cbo_country.Sorted = false;
			cbo_country.TabIndex = 12;
			cbo_country.TabStop = true;
			cbo_country.Visible = true;
			cbo_country.KeyPress += new System.Windows.Forms.KeyPressEventHandler(cbo_country_KeyPress);
			// 
			// text_state
			// 
			text_state.AcceptsReturn = true;
			text_state.AllowDrop = true;
			text_state.BackColor = System.Drawing.SystemColors.Window;
			text_state.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			text_state.Cursor = System.Windows.Forms.Cursors.IBeam;
			text_state.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			text_state.ForeColor = System.Drawing.SystemColors.WindowText;
			text_state.Location = new System.Drawing.Point(464, 106);
			text_state.MaxLength = 0;
			text_state.Name = "text_state";
			text_state.RightToLeft = System.Windows.Forms.RightToLeft.No;
			text_state.Size = new System.Drawing.Size(37, 19);
			text_state.TabIndex = 10;
			text_state.KeyPress += new System.Windows.Forms.KeyPressEventHandler(text_state_KeyPress);
			// 
			// text_city
			// 
			text_city.AcceptsReturn = true;
			text_city.AllowDrop = true;
			text_city.BackColor = System.Drawing.SystemColors.Window;
			text_city.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			text_city.Cursor = System.Windows.Forms.Cursors.IBeam;
			text_city.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			text_city.ForeColor = System.Drawing.SystemColors.WindowText;
			text_city.Location = new System.Drawing.Point(290, 106);
			text_city.MaxLength = 0;
			text_city.Name = "text_city";
			text_city.RightToLeft = System.Windows.Forms.RightToLeft.No;
			text_city.Size = new System.Drawing.Size(137, 19);
			text_city.TabIndex = 9;
			text_city.KeyPress += new System.Windows.Forms.KeyPressEventHandler(text_city_KeyPress);
			// 
			// text_company_id
			// 
			text_company_id.AcceptsReturn = true;
			text_company_id.AllowDrop = true;
			text_company_id.BackColor = System.Drawing.SystemColors.Window;
			text_company_id.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			text_company_id.Cursor = System.Windows.Forms.Cursors.IBeam;
			text_company_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			text_company_id.ForeColor = System.Drawing.SystemColors.WindowText;
			text_company_id.Location = new System.Drawing.Point(94, 18);
			text_company_id.MaxLength = 0;
			text_company_id.Name = "text_company_id";
			text_company_id.RightToLeft = System.Windows.Forms.RightToLeft.No;
			text_company_id.Size = new System.Drawing.Size(65, 19);
			text_company_id.TabIndex = 3;
			text_company_id.KeyPress += new System.Windows.Forms.KeyPressEventHandler(text_company_id_KeyPress);
			// 
			// text_company_name
			// 
			text_company_name.AcceptsReturn = true;
			text_company_name.AllowDrop = true;
			text_company_name.BackColor = System.Drawing.SystemColors.Window;
			text_company_name.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			text_company_name.Cursor = System.Windows.Forms.Cursors.IBeam;
			text_company_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			text_company_name.ForeColor = System.Drawing.SystemColors.WindowText;
			text_company_name.Location = new System.Drawing.Point(98, 40);
			text_company_name.MaxLength = 0;
			text_company_name.Name = "text_company_name";
			text_company_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			text_company_name.Size = new System.Drawing.Size(225, 19);
			text_company_name.TabIndex = 4;
			text_company_name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(text_company_name_KeyPress);
			// 
			// lbl_loc_address
			// 
			lbl_loc_address.AllowDrop = true;
			lbl_loc_address.BackColor = System.Drawing.SystemColors.Control;
			lbl_loc_address.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_loc_address.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_loc_address.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_loc_address.Location = new System.Drawing.Point(6, 108);
			lbl_loc_address.MinimumSize = new System.Drawing.Size(41, 17);
			lbl_loc_address.Name = "lbl_loc_address";
			lbl_loc_address.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_loc_address.Size = new System.Drawing.Size(41, 17);
			lbl_loc_address.TabIndex = 23;
			lbl_loc_address.Text = "Address:";
			// 
			// lblPhoneNbr
			// 
			lblPhoneNbr.AllowDrop = true;
			lblPhoneNbr.BackColor = System.Drawing.SystemColors.Control;
			lblPhoneNbr.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblPhoneNbr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblPhoneNbr.ForeColor = System.Drawing.SystemColors.ControlText;
			lblPhoneNbr.Location = new System.Drawing.Point(6, 86);
			lblPhoneNbr.MinimumSize = new System.Drawing.Size(79, 17);
			lblPhoneNbr.Name = "lblPhoneNbr";
			lblPhoneNbr.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblPhoneNbr.Size = new System.Drawing.Size(79, 17);
			lblPhoneNbr.TabIndex = 22;
			lblPhoneNbr.Text = "Phone Number";
			// 
			// Label1
			// 
			Label1.AllowDrop = true;
			Label1.BackColor = System.Drawing.SystemColors.Control;
			Label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label1.ForeColor = System.Drawing.SystemColors.ControlText;
			Label1.Location = new System.Drawing.Point(186, 64);
			Label1.MinimumSize = new System.Drawing.Size(27, 17);
			Label1.Name = "Label1";
			Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label1.Size = new System.Drawing.Size(27, 17);
			Label1.TabIndex = 21;
			Label1.Text = "Last:";
			// 
			// lbl_contact_first
			// 
			lbl_contact_first.AllowDrop = true;
			lbl_contact_first.BackColor = System.Drawing.SystemColors.Control;
			lbl_contact_first.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_contact_first.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_contact_first.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_contact_first.Location = new System.Drawing.Point(6, 63);
			lbl_contact_first.MinimumSize = new System.Drawing.Size(69, 17);
			lbl_contact_first.Name = "lbl_contact_first";
			lbl_contact_first.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_contact_first.Size = new System.Drawing.Size(69, 17);
			lbl_contact_first.TabIndex = 20;
			lbl_contact_first.Text = "Contact:  First:";
			// 
			// lbl_country
			// 
			lbl_country.AllowDrop = true;
			lbl_country.BackColor = System.Drawing.SystemColors.Control;
			lbl_country.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_country.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_country.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_country.Location = new System.Drawing.Point(506, 108);
			lbl_country.MinimumSize = new System.Drawing.Size(41, 17);
			lbl_country.Name = "lbl_country";
			lbl_country.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_country.Size = new System.Drawing.Size(41, 17);
			lbl_country.TabIndex = 19;
			lbl_country.Text = "Country:";
			// 
			// lbl_state
			// 
			lbl_state.AllowDrop = true;
			lbl_state.BackColor = System.Drawing.SystemColors.Control;
			lbl_state.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_state.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_state.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_state.Location = new System.Drawing.Point(434, 108);
			lbl_state.MinimumSize = new System.Drawing.Size(29, 17);
			lbl_state.Name = "lbl_state";
			lbl_state.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_state.Size = new System.Drawing.Size(29, 17);
			lbl_state.TabIndex = 18;
			lbl_state.Text = "State:";
			// 
			// lbl_loc_city
			// 
			lbl_loc_city.AllowDrop = true;
			lbl_loc_city.BackColor = System.Drawing.SystemColors.Control;
			lbl_loc_city.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_loc_city.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_loc_city.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_loc_city.Location = new System.Drawing.Point(258, 108);
			lbl_loc_city.MinimumSize = new System.Drawing.Size(25, 17);
			lbl_loc_city.Name = "lbl_loc_city";
			lbl_loc_city.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_loc_city.Size = new System.Drawing.Size(25, 17);
			lbl_loc_city.TabIndex = 17;
			lbl_loc_city.Text = "City:";
			// 
			// lbl_comp_id
			// 
			lbl_comp_id.AllowDrop = true;
			lbl_comp_id.BackColor = System.Drawing.SystemColors.Control;
			lbl_comp_id.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_comp_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_comp_id.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_comp_id.Location = new System.Drawing.Point(6, 18);
			lbl_comp_id.MinimumSize = new System.Drawing.Size(65, 17);
			lbl_comp_id.Name = "lbl_comp_id";
			lbl_comp_id.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_comp_id.Size = new System.Drawing.Size(65, 17);
			lbl_comp_id.TabIndex = 16;
			lbl_comp_id.Text = "Company ID:";
			// 
			// lbl_comp_name
			// 
			lbl_comp_name.AllowDrop = true;
			lbl_comp_name.BackColor = System.Drawing.SystemColors.Control;
			lbl_comp_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_comp_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_comp_name.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_comp_name.Location = new System.Drawing.Point(6, 40);
			lbl_comp_name.MinimumSize = new System.Drawing.Size(89, 17);
			lbl_comp_name.Name = "lbl_comp_name";
			lbl_comp_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_comp_name.Size = new System.Drawing.Size(89, 17);
			lbl_comp_name.TabIndex = 15;
			lbl_comp_name.Text = "Company Name:";
			// 
			// grd_company_list
			// 
			grd_company_list.AllowDrop = true;
			grd_company_list.AllowUserToAddRows = false;
			grd_company_list.AllowUserToDeleteRows = false;
			grd_company_list.AllowUserToResizeColumns = false;
			grd_company_list.AllowUserToResizeRows = false;
			grd_company_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_company_list.ColumnsCount = 2;
			grd_company_list.FixedColumns = 1;
			grd_company_list.FixedRows = 1;
			grd_company_list.Location = new System.Drawing.Point(6, 140);
			grd_company_list.Name = "grd_company_list";
			grd_company_list.ReadOnly = true;
			grd_company_list.RowsCount = 2;
			grd_company_list.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			grd_company_list.ShowCellToolTips = false;
			grd_company_list.Size = new System.Drawing.Size(765, 255);
			grd_company_list.StandardTab = true;
			grd_company_list.TabIndex = 24;
			grd_company_list.Click += new System.EventHandler(grd_company_list_Click);
			// 
			// frm_Sale_Price_Data
			// 
			frm_Sale_Price_Data.AllowDrop = true;
			frm_Sale_Price_Data.BackColor = System.Drawing.SystemColors.Control;
			frm_Sale_Price_Data.Controls.Add(lst_aircraft_info);
			frm_Sale_Price_Data.Controls.Add(txt_notes);
			frm_Sale_Price_Data.Controls.Add(txt_total_landings);
			frm_Sale_Price_Data.Controls.Add(txt_aftt);
			frm_Sale_Price_Data.Controls.Add(frame_comp_details);
			frm_Sale_Price_Data.Controls.Add(txt_asking_price);
			frm_Sale_Price_Data.Controls.Add(txt_sale_price);
			frm_Sale_Price_Data.Controls.Add(txt_comp_id);
			frm_Sale_Price_Data.Controls.Add(txt_contact_name);
			frm_Sale_Price_Data.Controls.Add(cmd_find_company_id);
			frm_Sale_Price_Data.Controls.Add(cmd_submit_record);
			frm_Sale_Price_Data.Controls.Add(_lbl_asking_4);
			frm_Sale_Price_Data.Controls.Add(_lbl_asking_3);
			frm_Sale_Price_Data.Controls.Add(_lbl_asking_2);
			frm_Sale_Price_Data.Controls.Add(_lbl_asking_1);
			frm_Sale_Price_Data.Controls.Add(_lbl_asking_0);
			frm_Sale_Price_Data.Controls.Add(lbl_sub_id);
			frm_Sale_Price_Data.Controls.Add(lbl_contact_name);
			frm_Sale_Price_Data.Controls.Add(lbl_comp_id_enter);
			frm_Sale_Price_Data.Controls.Add(lbl_warning);
			frm_Sale_Price_Data.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frm_Sale_Price_Data.Enabled = true;
			frm_Sale_Price_Data.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frm_Sale_Price_Data.ForeColor = System.Drawing.SystemColors.ControlText;
			frm_Sale_Price_Data.Location = new System.Drawing.Point(4, 2);
			frm_Sale_Price_Data.Name = "frm_Sale_Price_Data";
			frm_Sale_Price_Data.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frm_Sale_Price_Data.Size = new System.Drawing.Size(775, 193);
			frm_Sale_Price_Data.TabIndex = 0;
			frm_Sale_Price_Data.Text = "Sale Price Data";
			frm_Sale_Price_Data.Visible = true;
			// 
			// lst_aircraft_info
			// 
			lst_aircraft_info.AllowDrop = true;
			lst_aircraft_info.BackColor = System.Drawing.SystemColors.Window;
			lst_aircraft_info.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			lst_aircraft_info.CausesValidation = true;
			lst_aircraft_info.Enabled = true;
			lst_aircraft_info.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lst_aircraft_info.ForeColor = System.Drawing.SystemColors.WindowText;
			lst_aircraft_info.IntegralHeight = true;
			lst_aircraft_info.Location = new System.Drawing.Point(244, 14);
			lst_aircraft_info.MultiColumn = false;
			lst_aircraft_info.Name = "lst_aircraft_info";
			lst_aircraft_info.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lst_aircraft_info.Size = new System.Drawing.Size(225, 111);
			lst_aircraft_info.Sorted = false;
			lst_aircraft_info.TabIndex = 46;
			lst_aircraft_info.TabStop = true;
			lst_aircraft_info.Visible = true;
			// 
			// txt_notes
			// 
			txt_notes.AcceptsReturn = true;
			txt_notes.AllowDrop = true;
			txt_notes.BackColor = System.Drawing.SystemColors.Window;
			txt_notes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_notes.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_notes.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_notes.Location = new System.Drawing.Point(86, 136);
			txt_notes.MaxLength = 0;
			txt_notes.Name = "txt_notes";
			txt_notes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_notes.Size = new System.Drawing.Size(347, 19);
			txt_notes.TabIndex = 37;
			// 
			// txt_total_landings
			// 
			txt_total_landings.AcceptsReturn = true;
			txt_total_landings.AllowDrop = true;
			txt_total_landings.BackColor = System.Drawing.SystemColors.Window;
			txt_total_landings.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_total_landings.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_total_landings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_total_landings.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_total_landings.Location = new System.Drawing.Point(86, 106);
			txt_total_landings.MaxLength = 0;
			txt_total_landings.Name = "txt_total_landings";
			txt_total_landings.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_total_landings.Size = new System.Drawing.Size(151, 19);
			txt_total_landings.TabIndex = 36;
			// 
			// txt_aftt
			// 
			txt_aftt.AcceptsReturn = true;
			txt_aftt.AllowDrop = true;
			txt_aftt.BackColor = System.Drawing.SystemColors.Window;
			txt_aftt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_aftt.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_aftt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_aftt.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_aftt.Location = new System.Drawing.Point(86, 76);
			txt_aftt.MaxLength = 0;
			txt_aftt.Name = "txt_aftt";
			txt_aftt.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_aftt.Size = new System.Drawing.Size(151, 19);
			txt_aftt.TabIndex = 35;
			// 
			// frame_comp_details
			// 
			frame_comp_details.AllowDrop = true;
			frame_comp_details.BackColor = System.Drawing.SystemColors.Control;
			frame_comp_details.Controls.Add(company_details_list);
			frame_comp_details.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frame_comp_details.Enabled = true;
			frame_comp_details.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frame_comp_details.ForeColor = System.Drawing.SystemColors.ControlText;
			frame_comp_details.Location = new System.Drawing.Point(476, 10);
			frame_comp_details.Name = "frame_comp_details";
			frame_comp_details.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frame_comp_details.Size = new System.Drawing.Size(295, 105);
			frame_comp_details.TabIndex = 38;
			frame_comp_details.Text = "Company Details";
			frame_comp_details.Visible = true;
			// 
			// company_details_list
			// 
			company_details_list.AllowDrop = true;
			company_details_list.BackColor = System.Drawing.SystemColors.Window;
			company_details_list.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			company_details_list.CausesValidation = true;
			company_details_list.Enabled = true;
			company_details_list.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			company_details_list.ForeColor = System.Drawing.SystemColors.WindowText;
			company_details_list.IntegralHeight = true;
			company_details_list.Location = new System.Drawing.Point(6, 16);
			company_details_list.MultiColumn = false;
			company_details_list.Name = "company_details_list";
			company_details_list.RightToLeft = System.Windows.Forms.RightToLeft.No;
			company_details_list.Size = new System.Drawing.Size(283, 85);
			company_details_list.Sorted = false;
			company_details_list.TabIndex = 40;
			company_details_list.TabStop = true;
			company_details_list.Visible = true;
			// 
			// txt_asking_price
			// 
			txt_asking_price.AcceptsReturn = true;
			txt_asking_price.AllowDrop = true;
			txt_asking_price.BackColor = System.Drawing.SystemColors.Window;
			txt_asking_price.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_asking_price.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_asking_price.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_asking_price.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_asking_price.Location = new System.Drawing.Point(86, 16);
			txt_asking_price.MaxLength = 0;
			txt_asking_price.Name = "txt_asking_price";
			txt_asking_price.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_asking_price.Size = new System.Drawing.Size(151, 19);
			txt_asking_price.TabIndex = 33;
			// 
			// txt_sale_price
			// 
			txt_sale_price.AcceptsReturn = true;
			txt_sale_price.AllowDrop = true;
			txt_sale_price.BackColor = System.Drawing.SystemColors.Window;
			txt_sale_price.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_sale_price.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_sale_price.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_sale_price.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_sale_price.Location = new System.Drawing.Point(86, 46);
			txt_sale_price.MaxLength = 0;
			txt_sale_price.Name = "txt_sale_price";
			txt_sale_price.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_sale_price.Size = new System.Drawing.Size(151, 19);
			txt_sale_price.TabIndex = 34;
			// 
			// txt_comp_id
			// 
			txt_comp_id.AcceptsReturn = true;
			txt_comp_id.AllowDrop = true;
			txt_comp_id.BackColor = System.Drawing.SystemColors.Window;
			txt_comp_id.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_comp_id.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_comp_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_comp_id.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_comp_id.Location = new System.Drawing.Point(86, 163);
			txt_comp_id.MaxLength = 0;
			txt_comp_id.Name = "txt_comp_id";
			txt_comp_id.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_comp_id.Size = new System.Drawing.Size(85, 21);
			txt_comp_id.TabIndex = 39;
			txt_comp_id.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txt_comp_id_KeyPress);
			// 
			// txt_contact_name
			// 
			txt_contact_name.AcceptsReturn = true;
			txt_contact_name.AllowDrop = true;
			txt_contact_name.BackColor = System.Drawing.SystemColors.Window;
			txt_contact_name.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_contact_name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_contact_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_contact_name.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_contact_name.Location = new System.Drawing.Point(370, 164);
			txt_contact_name.MaxLength = 0;
			txt_contact_name.Name = "txt_contact_name";
			txt_contact_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_contact_name.Size = new System.Drawing.Size(129, 21);
			txt_contact_name.TabIndex = 41;
			// 
			// cmd_find_company_id
			// 
			cmd_find_company_id.AllowDrop = true;
			cmd_find_company_id.BackColor = System.Drawing.SystemColors.Control;
			cmd_find_company_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_find_company_id.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_find_company_id.Location = new System.Drawing.Point(194, 164);
			cmd_find_company_id.Name = "cmd_find_company_id";
			cmd_find_company_id.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_find_company_id.Size = new System.Drawing.Size(79, 19);
			cmd_find_company_id.TabIndex = 28;
			cmd_find_company_id.Text = "Find Company";
			cmd_find_company_id.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_find_company_id.UseVisualStyleBackColor = false;
			cmd_find_company_id.Click += new System.EventHandler(cmd_find_company_id_Click);
			// 
			// cmd_submit_record
			// 
			cmd_submit_record.AllowDrop = true;
			cmd_submit_record.BackColor = System.Drawing.SystemColors.Control;
			cmd_submit_record.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_submit_record.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_submit_record.Location = new System.Drawing.Point(614, 158);
			cmd_submit_record.Name = "cmd_submit_record";
			cmd_submit_record.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_submit_record.Size = new System.Drawing.Size(155, 25);
			cmd_submit_record.TabIndex = 26;
			cmd_submit_record.Text = "Submit Displayable Sale Price";
			cmd_submit_record.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_submit_record.UseVisualStyleBackColor = false;
			cmd_submit_record.Visible = false;
			cmd_submit_record.Click += new System.EventHandler(cmd_submit_record_Click);
			// 
			// _lbl_asking_4
			// 
			_lbl_asking_4.AllowDrop = true;
			_lbl_asking_4.BackColor = System.Drawing.SystemColors.Control;
			_lbl_asking_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_asking_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_asking_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_asking_4.Location = new System.Drawing.Point(6, 134);
			_lbl_asking_4.MinimumSize = new System.Drawing.Size(75, 15);
			_lbl_asking_4.Name = "_lbl_asking_4";
			_lbl_asking_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_asking_4.Size = new System.Drawing.Size(75, 15);
			_lbl_asking_4.TabIndex = 45;
			_lbl_asking_4.Text = "Notes:";
			// 
			// _lbl_asking_3
			// 
			_lbl_asking_3.AllowDrop = true;
			_lbl_asking_3.BackColor = System.Drawing.SystemColors.Control;
			_lbl_asking_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_asking_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_asking_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_asking_3.Location = new System.Drawing.Point(6, 105);
			_lbl_asking_3.MinimumSize = new System.Drawing.Size(75, 15);
			_lbl_asking_3.Name = "_lbl_asking_3";
			_lbl_asking_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_asking_3.Size = new System.Drawing.Size(75, 15);
			_lbl_asking_3.TabIndex = 44;
			_lbl_asking_3.Text = "Total Landings";
			// 
			// _lbl_asking_2
			// 
			_lbl_asking_2.AllowDrop = true;
			_lbl_asking_2.BackColor = System.Drawing.SystemColors.Control;
			_lbl_asking_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_asking_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_asking_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_asking_2.Location = new System.Drawing.Point(6, 75);
			_lbl_asking_2.MinimumSize = new System.Drawing.Size(75, 15);
			_lbl_asking_2.Name = "_lbl_asking_2";
			_lbl_asking_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_asking_2.Size = new System.Drawing.Size(75, 15);
			_lbl_asking_2.TabIndex = 43;
			_lbl_asking_2.Text = "AFTT:";
			// 
			// _lbl_asking_1
			// 
			_lbl_asking_1.AllowDrop = true;
			_lbl_asking_1.BackColor = System.Drawing.SystemColors.Control;
			_lbl_asking_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_asking_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_asking_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_asking_1.Location = new System.Drawing.Point(6, 46);
			_lbl_asking_1.MinimumSize = new System.Drawing.Size(75, 15);
			_lbl_asking_1.Name = "_lbl_asking_1";
			_lbl_asking_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_asking_1.Size = new System.Drawing.Size(75, 15);
			_lbl_asking_1.TabIndex = 42;
			_lbl_asking_1.Text = "Sale Price:";
			// 
			// _lbl_asking_0
			// 
			_lbl_asking_0.AllowDrop = true;
			_lbl_asking_0.BackColor = System.Drawing.SystemColors.Control;
			_lbl_asking_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_asking_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_asking_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_asking_0.Location = new System.Drawing.Point(6, 16);
			_lbl_asking_0.MinimumSize = new System.Drawing.Size(75, 15);
			_lbl_asking_0.Name = "_lbl_asking_0";
			_lbl_asking_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_asking_0.Size = new System.Drawing.Size(75, 15);
			_lbl_asking_0.TabIndex = 32;
			_lbl_asking_0.Text = "Asking Price:";
			// 
			// lbl_sub_id
			// 
			lbl_sub_id.AllowDrop = true;
			lbl_sub_id.BackColor = System.Drawing.SystemColors.Control;
			lbl_sub_id.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_sub_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_sub_id.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_sub_id.Location = new System.Drawing.Point(160, 164);
			lbl_sub_id.MinimumSize = new System.Drawing.Size(49, 21);
			lbl_sub_id.Name = "lbl_sub_id";
			lbl_sub_id.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_sub_id.Size = new System.Drawing.Size(49, 21);
			lbl_sub_id.TabIndex = 31;
			lbl_sub_id.Text = "sub_id";
			lbl_sub_id.Visible = false;
			// 
			// lbl_contact_name
			// 
			lbl_contact_name.AllowDrop = true;
			lbl_contact_name.BackColor = System.Drawing.SystemColors.Control;
			lbl_contact_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_contact_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_contact_name.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_contact_name.Location = new System.Drawing.Point(293, 164);
			lbl_contact_name.MinimumSize = new System.Drawing.Size(77, 11);
			lbl_contact_name.Name = "lbl_contact_name";
			lbl_contact_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_contact_name.Size = new System.Drawing.Size(77, 11);
			lbl_contact_name.TabIndex = 30;
			lbl_contact_name.Text = "Contact Name:";
			// 
			// lbl_comp_id_enter
			// 
			lbl_comp_id_enter.AllowDrop = true;
			lbl_comp_id_enter.BackColor = System.Drawing.SystemColors.Control;
			lbl_comp_id_enter.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_comp_id_enter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_comp_id_enter.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_comp_id_enter.Location = new System.Drawing.Point(8, 165);
			lbl_comp_id_enter.MinimumSize = new System.Drawing.Size(77, 11);
			lbl_comp_id_enter.Name = "lbl_comp_id_enter";
			lbl_comp_id_enter.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_comp_id_enter.Size = new System.Drawing.Size(77, 11);
			lbl_comp_id_enter.TabIndex = 29;
			lbl_comp_id_enter.Text = "Company ID:";
			// 
			// lbl_warning
			// 
			lbl_warning.AllowDrop = true;
			lbl_warning.BackColor = System.Drawing.SystemColors.Control;
			lbl_warning.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_warning.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_warning.ForeColor = System.Drawing.Color.Red;
			lbl_warning.Location = new System.Drawing.Point(528, 118);
			lbl_warning.MinimumSize = new System.Drawing.Size(227, 35);
			lbl_warning.Name = "lbl_warning";
			lbl_warning.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_warning.Size = new System.Drawing.Size(227, 35);
			lbl_warning.TabIndex = 27;
			lbl_warning.Text = "Saving this sale price record will display this sale price by serial number in JETNET products.\"";
			// 
			// frm_enter_sale_price_company
			// 
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			ClientSize = new System.Drawing.Size(783, 638);
			Controls.Add(frm_company_search);
			Controls.Add(frm_Sale_Price_Data);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Location = new System.Drawing.Point(645, 170);
			MaximizeBox = true;
			MinimizeBox = true;
			Name = "frm_enter_sale_price_company";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			Text = "Enter Transaction Sale Price";
			commandButtonHelper1.SetStyle(cmd_select_company, 0);
			commandButtonHelper1.SetStyle(cmd_clear, 0);
			commandButtonHelper1.SetStyle(cmd_find_now, 0);
			commandButtonHelper1.SetStyle(cmd_find_company_id, 0);
			commandButtonHelper1.SetStyle(cmd_submit_record, 0);
			listBoxHelper1.SetSelectionMode(lst_aircraft_info, System.Windows.Forms.SelectionMode.One);
			listBoxHelper1.SetSelectionMode(company_details_list, System.Windows.Forms.SelectionMode.One);
			Activated += new System.EventHandler(Form_Activated);
			Closed += new System.EventHandler(Form_Closed);
			KeyUp += new System.Windows.Forms.KeyEventHandler(Form_KeyUp);
			Resize += new System.EventHandler(Form_Resize);
			((System.ComponentModel.ISupportInitialize) grd_company_list).EndInit();
			frm_company_search.ResumeLayout(false);
			frm_company_search.PerformLayout();
			frame_search.ResumeLayout(false);
			frame_search.PerformLayout();
			frm_Sale_Price_Data.ResumeLayout(false);
			frm_Sale_Price_Data.PerformLayout();
			frame_comp_details.ResumeLayout(false);
			frame_comp_details.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
		void ReLoadForm(bool addEvents) => Initializelbl_asking();

		void Initializelbl_asking()
		{
			lbl_asking = new System.Windows.Forms.Label[5];
			lbl_asking[4] = _lbl_asking_4;
			lbl_asking[3] = _lbl_asking_3;
			lbl_asking[2] = _lbl_asking_2;
			lbl_asking[1] = _lbl_asking_1;
			lbl_asking[0] = _lbl_asking_0;
		}
		#endregion
	}
}