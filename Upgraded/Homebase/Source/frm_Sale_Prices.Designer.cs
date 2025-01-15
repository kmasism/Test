
namespace JETNET_Homebase
{
	partial class frm_Sale_Prices
	{

		#region "Upgrade Support "
		private static frm_Sale_Prices m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_Sale_Prices DefInstance
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
		public static frm_Sale_Prices CreateInstance()
		{
			frm_Sale_Prices theInstance = new frm_Sale_Prices();
			theInstance.Form_Load();
			return theInstance;
		}
		private string[] visualControls = new string[]{"components", "ToolTipMain", "cmd_refresh", "txt_ac_id", "lbl_class", "frm_search_criteria", "cbo_search_type", "grd_sale_prices", "_lbl_class2_1", "_lbl_class2_2", "_lbl_class2_3", "frm_list", "button_hide", "clear_button", "cmd_update_selected", "txt_update_note", "lbl_update", "_lbl_class2_0", "frm_update_click", "grd_ac_sale", "lbl_ac_id", "lbl_journ_id", "lbl_class2", "commandButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Button cmd_refresh;
		public System.Windows.Forms.TextBox txt_ac_id;
		public System.Windows.Forms.Label lbl_class;
		public System.Windows.Forms.GroupBox frm_search_criteria;
		public System.Windows.Forms.ComboBox cbo_search_type;
		public UpgradeHelpers.DataGridViewFlex grd_sale_prices;
		private System.Windows.Forms.Label _lbl_class2_1;
		private System.Windows.Forms.Label _lbl_class2_2;
		private System.Windows.Forms.Label _lbl_class2_3;
		public System.Windows.Forms.GroupBox frm_list;
		public System.Windows.Forms.Button button_hide;
		public System.Windows.Forms.Button clear_button;
		public System.Windows.Forms.Button cmd_update_selected;
		public System.Windows.Forms.TextBox txt_update_note;
		public System.Windows.Forms.Label lbl_update;
		private System.Windows.Forms.Label _lbl_class2_0;
		public System.Windows.Forms.GroupBox frm_update_click;
		public UpgradeHelpers.DataGridViewFlex grd_ac_sale;
		public System.Windows.Forms.Label lbl_ac_id;
		public System.Windows.Forms.Label lbl_journ_id;
		public System.Windows.Forms.Label[] lbl_class2 = new System.Windows.Forms.Label[4];
		public UpgradeHelpers.Gui.Controls.CommandButtonHelper commandButtonHelper1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Sale_Prices));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			frm_list = new System.Windows.Forms.GroupBox();
			cmd_refresh = new System.Windows.Forms.Button();
			frm_search_criteria = new System.Windows.Forms.GroupBox();
			txt_ac_id = new System.Windows.Forms.TextBox();
			lbl_class = new System.Windows.Forms.Label();
			cbo_search_type = new System.Windows.Forms.ComboBox();
			grd_sale_prices = new UpgradeHelpers.DataGridViewFlex(components);
			_lbl_class2_1 = new System.Windows.Forms.Label();
			_lbl_class2_2 = new System.Windows.Forms.Label();
			_lbl_class2_3 = new System.Windows.Forms.Label();
			frm_update_click = new System.Windows.Forms.GroupBox();
			button_hide = new System.Windows.Forms.Button();
			clear_button = new System.Windows.Forms.Button();
			cmd_update_selected = new System.Windows.Forms.Button();
			txt_update_note = new System.Windows.Forms.TextBox();
			lbl_update = new System.Windows.Forms.Label();
			_lbl_class2_0 = new System.Windows.Forms.Label();
			grd_ac_sale = new UpgradeHelpers.DataGridViewFlex(components);
			lbl_ac_id = new System.Windows.Forms.Label();
			lbl_journ_id = new System.Windows.Forms.Label();
			frm_list.SuspendLayout();
			frm_search_criteria.SuspendLayout();
			frm_update_click.SuspendLayout();
			SuspendLayout();
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
			((System.ComponentModel.ISupportInitialize) grd_sale_prices).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_ac_sale).BeginInit();
			// 
			// frm_list
			// 
			frm_list.AllowDrop = true;
			frm_list.BackColor = System.Drawing.SystemColors.Control;
			frm_list.Controls.Add(cmd_refresh);
			frm_list.Controls.Add(frm_search_criteria);
			frm_list.Controls.Add(cbo_search_type);
			frm_list.Controls.Add(grd_sale_prices);
			frm_list.Controls.Add(_lbl_class2_1);
			frm_list.Controls.Add(_lbl_class2_2);
			frm_list.Controls.Add(_lbl_class2_3);
			frm_list.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frm_list.Enabled = true;
			frm_list.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frm_list.ForeColor = System.Drawing.SystemColors.ControlText;
			frm_list.Location = new System.Drawing.Point(0, 8);
			frm_list.Name = "frm_list";
			frm_list.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frm_list.Size = new System.Drawing.Size(933, 295);
			frm_list.TabIndex = 9;
			frm_list.Text = "Frame1";
			frm_list.Visible = true;
			// 
			// cmd_refresh
			// 
			cmd_refresh.AllowDrop = true;
			cmd_refresh.BackColor = System.Drawing.SystemColors.Control;
			cmd_refresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_refresh.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_refresh.Location = new System.Drawing.Point(848, 232);
			cmd_refresh.Name = "cmd_refresh";
			cmd_refresh.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_refresh.Size = new System.Drawing.Size(77, 23);
			cmd_refresh.TabIndex = 14;
			cmd_refresh.Text = "Refresh";
			cmd_refresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_refresh.UseVisualStyleBackColor = false;
			cmd_refresh.Click += new System.EventHandler(cmd_Refresh_Click);
			// 
			// frm_search_criteria
			// 
			frm_search_criteria.AllowDrop = true;
			frm_search_criteria.BackColor = System.Drawing.SystemColors.Control;
			frm_search_criteria.Controls.Add(txt_ac_id);
			frm_search_criteria.Controls.Add(lbl_class);
			frm_search_criteria.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frm_search_criteria.Enabled = true;
			frm_search_criteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frm_search_criteria.ForeColor = System.Drawing.SystemColors.ControlText;
			frm_search_criteria.Location = new System.Drawing.Point(2, 226);
			frm_search_criteria.Name = "frm_search_criteria";
			frm_search_criteria.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frm_search_criteria.Size = new System.Drawing.Size(357, 51);
			frm_search_criteria.TabIndex = 11;
			frm_search_criteria.Text = "Search Criteria";
			frm_search_criteria.Visible = false;
			// 
			// txt_ac_id
			// 
			txt_ac_id.AcceptsReturn = true;
			txt_ac_id.AllowDrop = true;
			txt_ac_id.BackColor = System.Drawing.SystemColors.Window;
			txt_ac_id.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_ac_id.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ac_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ac_id.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ac_id.Location = new System.Drawing.Point(50, 14);
			txt_ac_id.MaxLength = 0;
			txt_ac_id.Name = "txt_ac_id";
			txt_ac_id.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_id.Size = new System.Drawing.Size(79, 21);
			txt_ac_id.TabIndex = 12;
			// 
			// lbl_class
			// 
			lbl_class.AllowDrop = true;
			lbl_class.BackColor = System.Drawing.SystemColors.Control;
			lbl_class.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_class.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_class.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_class.Location = new System.Drawing.Point(10, 14);
			lbl_class.MinimumSize = new System.Drawing.Size(33, 19);
			lbl_class.Name = "lbl_class";
			lbl_class.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_class.Size = new System.Drawing.Size(33, 19);
			lbl_class.TabIndex = 13;
			lbl_class.Text = "ACID";
			// 
			// cbo_search_type
			// 
			cbo_search_type.AllowDrop = true;
			cbo_search_type.BackColor = System.Drawing.SystemColors.Window;
			cbo_search_type.CausesValidation = true;
			cbo_search_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_search_type.Enabled = true;
			cbo_search_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_search_type.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_search_type.IntegralHeight = true;
			cbo_search_type.Location = new System.Drawing.Point(80, 0);
			cbo_search_type.Name = "cbo_search_type";
			cbo_search_type.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_search_type.Size = new System.Drawing.Size(309, 21);
			cbo_search_type.Sorted = false;
			cbo_search_type.TabIndex = 10;
			cbo_search_type.TabStop = true;
			cbo_search_type.Visible = true;
			cbo_search_type.SelectionChangeCommitted += new System.EventHandler(cbo_search_type_SelectionChangeCommitted);
			// 
			// grd_sale_prices
			// 
			grd_sale_prices.AllowDrop = true;
			grd_sale_prices.AllowUserToAddRows = false;
			grd_sale_prices.AllowUserToDeleteRows = false;
			grd_sale_prices.AllowUserToResizeColumns = false;
			grd_sale_prices.AllowUserToResizeColumns = grd_sale_prices.ColumnHeadersVisible;
			grd_sale_prices.AllowUserToResizeRows = false;
			grd_sale_prices.AllowUserToResizeRows = false;
			grd_sale_prices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_sale_prices.ColumnsCount = 2;
			grd_sale_prices.FixedColumns = 1;
			grd_sale_prices.FixedRows = 1;
			grd_sale_prices.Location = new System.Drawing.Point(2, 26);
			grd_sale_prices.Name = "grd_sale_prices";
			grd_sale_prices.ReadOnly = true;
			grd_sale_prices.RowsCount = 2;
			grd_sale_prices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grd_sale_prices.ShowCellToolTips = false;
			grd_sale_prices.Size = new System.Drawing.Size(935, 195);
			grd_sale_prices.StandardTab = true;
			grd_sale_prices.TabIndex = 15;
			grd_sale_prices.Click += new System.EventHandler(grd_sale_prices_Click);
			grd_sale_prices.DoubleClick += new System.EventHandler(grd_sale_prices_DoubleClick);
			// 
			// _lbl_class2_1
			// 
			_lbl_class2_1.AllowDrop = true;
			_lbl_class2_1.BackColor = System.Drawing.SystemColors.Control;
			_lbl_class2_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_class2_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_class2_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_class2_1.Location = new System.Drawing.Point(0, 2);
			_lbl_class2_1.MinimumSize = new System.Drawing.Size(75, 17);
			_lbl_class2_1.Name = "_lbl_class2_1";
			_lbl_class2_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_class2_1.Size = new System.Drawing.Size(75, 17);
			_lbl_class2_1.TabIndex = 18;
			_lbl_class2_1.Text = "Search Type:";
			// 
			// _lbl_class2_2
			// 
			_lbl_class2_2.AllowDrop = true;
			_lbl_class2_2.BackColor = System.Drawing.SystemColors.Control;
			_lbl_class2_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_class2_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_class2_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_class2_2.Location = new System.Drawing.Point(420, 226);
			_lbl_class2_2.MinimumSize = new System.Drawing.Size(109, 21);
			_lbl_class2_2.Name = "_lbl_class2_2";
			_lbl_class2_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_class2_2.Size = new System.Drawing.Size(109, 21);
			_lbl_class2_2.TabIndex = 17;
			_lbl_class2_2.Text = "Records Found";
			// 
			// _lbl_class2_3
			// 
			_lbl_class2_3.AllowDrop = true;
			_lbl_class2_3.BackColor = System.Drawing.SystemColors.Control;
			_lbl_class2_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_class2_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_class2_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_class2_3.Location = new System.Drawing.Point(390, 258);
			_lbl_class2_3.MinimumSize = new System.Drawing.Size(103, 17);
			_lbl_class2_3.Name = "_lbl_class2_3";
			_lbl_class2_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_class2_3.Size = new System.Drawing.Size(103, 17);
			_lbl_class2_3.TabIndex = 16;
			_lbl_class2_3.Text = "SUBMITTED DATA";
			// 
			// frm_update_click
			// 
			frm_update_click.AllowDrop = true;
			frm_update_click.BackColor = System.Drawing.SystemColors.Control;
			frm_update_click.Controls.Add(button_hide);
			frm_update_click.Controls.Add(clear_button);
			frm_update_click.Controls.Add(cmd_update_selected);
			frm_update_click.Controls.Add(txt_update_note);
			frm_update_click.Controls.Add(lbl_update);
			frm_update_click.Controls.Add(_lbl_class2_0);
			frm_update_click.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frm_update_click.Enabled = true;
			frm_update_click.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frm_update_click.ForeColor = System.Drawing.SystemColors.ControlText;
			frm_update_click.Location = new System.Drawing.Point(254, 408);
			frm_update_click.Name = "frm_update_click";
			frm_update_click.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frm_update_click.Size = new System.Drawing.Size(679, 155);
			frm_update_click.TabIndex = 3;
			frm_update_click.Text = "Update Frame";
			frm_update_click.Visible = false;
			// 
			// button_hide
			// 
			button_hide.AllowDrop = true;
			button_hide.BackColor = System.Drawing.SystemColors.Control;
			button_hide.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			button_hide.ForeColor = System.Drawing.SystemColors.ControlText;
			button_hide.Location = new System.Drawing.Point(592, 78);
			button_hide.Name = "button_hide";
			button_hide.RightToLeft = System.Windows.Forms.RightToLeft.No;
			button_hide.Size = new System.Drawing.Size(79, 27);
			button_hide.TabIndex = 8;
			button_hide.Text = "Hide";
			button_hide.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			button_hide.UseVisualStyleBackColor = false;
			button_hide.Click += new System.EventHandler(button_hide_Click);
			// 
			// clear_button
			// 
			clear_button.AllowDrop = true;
			clear_button.BackColor = System.Drawing.SystemColors.Control;
			clear_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			clear_button.ForeColor = System.Drawing.SystemColors.ControlText;
			clear_button.Location = new System.Drawing.Point(476, 78);
			clear_button.Name = "clear_button";
			clear_button.RightToLeft = System.Windows.Forms.RightToLeft.No;
			clear_button.Size = new System.Drawing.Size(79, 27);
			clear_button.TabIndex = 7;
			clear_button.Text = "Clear/Delete";
			clear_button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			clear_button.UseVisualStyleBackColor = false;
			clear_button.Click += new System.EventHandler(clear_button_Click);
			// 
			// cmd_update_selected
			// 
			cmd_update_selected.AllowDrop = true;
			cmd_update_selected.BackColor = System.Drawing.SystemColors.Control;
			cmd_update_selected.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_update_selected.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_update_selected.Location = new System.Drawing.Point(530, 16);
			cmd_update_selected.Name = "cmd_update_selected";
			cmd_update_selected.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_update_selected.Size = new System.Drawing.Size(147, 33);
			cmd_update_selected.TabIndex = 5;
			cmd_update_selected.Text = "Set as Primary Sale Price";
			cmd_update_selected.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_update_selected.UseVisualStyleBackColor = false;
			cmd_update_selected.Click += new System.EventHandler(cmd_update_selected_Click);
			// 
			// txt_update_note
			// 
			txt_update_note.AcceptsReturn = true;
			txt_update_note.AllowDrop = true;
			txt_update_note.BackColor = System.Drawing.SystemColors.Window;
			txt_update_note.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_update_note.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_update_note.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_update_note.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_update_note.Location = new System.Drawing.Point(88, 16);
			txt_update_note.MaxLength = 0;
			txt_update_note.Name = "txt_update_note";
			txt_update_note.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_update_note.Size = new System.Drawing.Size(427, 23);
			txt_update_note.TabIndex = 4;
			// 
			// lbl_update
			// 
			lbl_update.AllowDrop = true;
			lbl_update.BackColor = System.Drawing.SystemColors.Control;
			lbl_update.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_update.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_update.ForeColor = System.Drawing.Color.Red;
			lbl_update.Location = new System.Drawing.Point(530, 122);
			lbl_update.MinimumSize = new System.Drawing.Size(95, 17);
			lbl_update.Name = "lbl_update";
			lbl_update.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_update.Size = new System.Drawing.Size(95, 17);
			lbl_update.TabIndex = 19;
			lbl_update.Text = "Record Updated";
			lbl_update.Visible = false;
			// 
			// _lbl_class2_0
			// 
			_lbl_class2_0.AllowDrop = true;
			_lbl_class2_0.BackColor = System.Drawing.SystemColors.Control;
			_lbl_class2_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_class2_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_class2_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_class2_0.Location = new System.Drawing.Point(16, 16);
			_lbl_class2_0.MinimumSize = new System.Drawing.Size(63, 21);
			_lbl_class2_0.Name = "_lbl_class2_0";
			_lbl_class2_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_class2_0.Size = new System.Drawing.Size(63, 21);
			_lbl_class2_0.TabIndex = 6;
			_lbl_class2_0.Text = "Update Note";
			// 
			// grd_ac_sale
			// 
			grd_ac_sale.AllowDrop = true;
			grd_ac_sale.AllowUserToAddRows = false;
			grd_ac_sale.AllowUserToDeleteRows = false;
			grd_ac_sale.AllowUserToResizeColumns = false;
			grd_ac_sale.AllowUserToResizeRows = false;
			grd_ac_sale.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_ac_sale.ColumnsCount = 2;
			grd_ac_sale.FixedColumns = 1;
			grd_ac_sale.FixedRows = 1;
			grd_ac_sale.Location = new System.Drawing.Point(0, 308);
			grd_ac_sale.Name = "grd_ac_sale";
			grd_ac_sale.ReadOnly = true;
			grd_ac_sale.RowsCount = 2;
			grd_ac_sale.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grd_ac_sale.ShowCellToolTips = false;
			grd_ac_sale.Size = new System.Drawing.Size(935, 95);
			grd_ac_sale.StandardTab = true;
			grd_ac_sale.TabIndex = 0;
			grd_ac_sale.Visible = false;
			grd_ac_sale.Click += new System.EventHandler(grd_ac_sale_Click);
			// 
			// lbl_ac_id
			// 
			lbl_ac_id.AllowDrop = true;
			lbl_ac_id.BackColor = System.Drawing.SystemColors.Control;
			lbl_ac_id.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_ac_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_ac_id.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_ac_id.Location = new System.Drawing.Point(76, 542);
			lbl_ac_id.MinimumSize = new System.Drawing.Size(67, 19);
			lbl_ac_id.Name = "lbl_ac_id";
			lbl_ac_id.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_ac_id.Size = new System.Drawing.Size(67, 19);
			lbl_ac_id.TabIndex = 2;
			lbl_ac_id.Text = "ACID";
			// 
			// lbl_journ_id
			// 
			lbl_journ_id.AllowDrop = true;
			lbl_journ_id.BackColor = System.Drawing.SystemColors.Control;
			lbl_journ_id.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_journ_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_journ_id.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_journ_id.Location = new System.Drawing.Point(8, 542);
			lbl_journ_id.MinimumSize = new System.Drawing.Size(59, 19);
			lbl_journ_id.Name = "lbl_journ_id";
			lbl_journ_id.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_journ_id.Size = new System.Drawing.Size(59, 19);
			lbl_journ_id.TabIndex = 1;
			lbl_journ_id.Text = "JournID";
			// 
			// frm_Sale_Prices
			// 
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			ClientSize = new System.Drawing.Size(938, 573);
			Controls.Add(frm_list);
			Controls.Add(frm_update_click);
			Controls.Add(grd_ac_sale);
			Controls.Add(lbl_ac_id);
			Controls.Add(lbl_journ_id);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Location = new System.Drawing.Point(398, 287);
			MaximizeBox = true;
			MinimizeBox = true;
			Name = "frm_Sale_Prices";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			Text = "Sale Prices";
			commandButtonHelper1.SetStyle(cmd_refresh, 0);
			commandButtonHelper1.SetStyle(button_hide, 0);
			commandButtonHelper1.SetStyle(clear_button, 0);
			commandButtonHelper1.SetStyle(cmd_update_selected, 0);
			Activated += new System.EventHandler(frm_Sale_Prices_Activated);
			Closed += new System.EventHandler(Form_Closed);
			((System.ComponentModel.ISupportInitialize) grd_sale_prices).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_ac_sale).EndInit();
			frm_list.ResumeLayout(false);
			frm_list.PerformLayout();
			frm_search_criteria.ResumeLayout(false);
			frm_search_criteria.PerformLayout();
			frm_update_click.ResumeLayout(false);
			frm_update_click.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
		void ReLoadForm(bool addEvents) => Initializelbl_class2();

		void Initializelbl_class2()
		{
			lbl_class2 = new System.Windows.Forms.Label[4];
			lbl_class2[1] = _lbl_class2_1;
			lbl_class2[2] = _lbl_class2_2;
			lbl_class2[3] = _lbl_class2_3;
			lbl_class2[0] = _lbl_class2_0;
		}
		#endregion
	}
}