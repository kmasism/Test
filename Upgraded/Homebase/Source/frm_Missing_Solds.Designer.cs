
namespace JETNET_Homebase
{
	partial class frm_Missing_Solds
	{

		#region "Upgrade Support "
		private static frm_Missing_Solds m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_Missing_Solds DefInstance
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
		public static frm_Missing_Solds CreateInstance()
		{
			frm_Missing_Solds theInstance = new frm_Missing_Solds();
			theInstance.Form_Load();
			return theInstance;
		}
		private string[] visualControls = new string[]{"components", "ToolTipMain", "cmd_switch", "grd_prices_sum", "frm_company_summary", "cmd_Refresh", "cbo_amod_make_name", "chk_sold_prices", "cbo_year", "_lbl_class_1", "_lbl_class_2", "_lbl_class_3", "_lbl_class_0", "frm_actions", "cmd_export_list", "grd_sale_prices", "frame_Missing_Solds", "lbl_class", "commandButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Button cmd_switch;
		public UpgradeHelpers.DataGridViewFlex grd_prices_sum;
		public System.Windows.Forms.GroupBox frm_company_summary;
		public System.Windows.Forms.Button cmd_Refresh;
		public System.Windows.Forms.ComboBox cbo_amod_make_name;
		public System.Windows.Forms.CheckBox chk_sold_prices;
		public System.Windows.Forms.ComboBox cbo_year;
		private System.Windows.Forms.Label _lbl_class_1;
		private System.Windows.Forms.Label _lbl_class_2;
		private System.Windows.Forms.Label _lbl_class_3;
		private System.Windows.Forms.Label _lbl_class_0;
		public System.Windows.Forms.GroupBox frm_actions;
		public System.Windows.Forms.Button cmd_export_list;
		public UpgradeHelpers.DataGridViewFlex grd_sale_prices;
		public System.Windows.Forms.GroupBox frame_Missing_Solds;
		public System.Windows.Forms.Label[] lbl_class = new System.Windows.Forms.Label[4];
		public UpgradeHelpers.Gui.Controls.CommandButtonHelper commandButtonHelper1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Missing_Solds));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			frm_company_summary = new System.Windows.Forms.GroupBox();
			cmd_switch = new System.Windows.Forms.Button();
			grd_prices_sum = new UpgradeHelpers.DataGridViewFlex(components);
			frame_Missing_Solds = new System.Windows.Forms.GroupBox();
			frm_actions = new System.Windows.Forms.GroupBox();
			cmd_Refresh = new System.Windows.Forms.Button();
			cbo_amod_make_name = new System.Windows.Forms.ComboBox();
			chk_sold_prices = new System.Windows.Forms.CheckBox();
			cbo_year = new System.Windows.Forms.ComboBox();
			_lbl_class_1 = new System.Windows.Forms.Label();
			_lbl_class_2 = new System.Windows.Forms.Label();
			_lbl_class_3 = new System.Windows.Forms.Label();
			_lbl_class_0 = new System.Windows.Forms.Label();
			cmd_export_list = new System.Windows.Forms.Button();
			grd_sale_prices = new UpgradeHelpers.DataGridViewFlex(components);
			frm_company_summary.SuspendLayout();
			frame_Missing_Solds.SuspendLayout();
			frm_actions.SuspendLayout();
			SuspendLayout();
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
			((System.ComponentModel.ISupportInitialize) grd_prices_sum).BeginInit();
			((System.ComponentModel.ISupportInitialize) grd_sale_prices).BeginInit();
			// 
			// frm_company_summary
			// 
			frm_company_summary.AllowDrop = true;
			frm_company_summary.BackColor = System.Drawing.SystemColors.Control;
			frm_company_summary.Controls.Add(cmd_switch);
			frm_company_summary.Controls.Add(grd_prices_sum);
			frm_company_summary.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frm_company_summary.Enabled = true;
			frm_company_summary.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frm_company_summary.ForeColor = System.Drawing.SystemColors.ControlText;
			frm_company_summary.Location = new System.Drawing.Point(0, 410);
			frm_company_summary.Name = "frm_company_summary";
			frm_company_summary.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frm_company_summary.Size = new System.Drawing.Size(459, 225);
			frm_company_summary.TabIndex = 3;
			frm_company_summary.Text = "Submitted Sale Price Summary By Trans Date";
			frm_company_summary.Visible = true;
			// 
			// cmd_switch
			// 
			cmd_switch.AllowDrop = true;
			cmd_switch.BackColor = System.Drawing.SystemColors.Control;
			cmd_switch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_switch.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_switch.Location = new System.Drawing.Point(394, 162);
			cmd_switch.Name = "cmd_switch";
			cmd_switch.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_switch.Size = new System.Drawing.Size(63, 59);
			cmd_switch.TabIndex = 14;
			cmd_switch.Text = "Switch To View By Date Submitted";
			cmd_switch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_switch.UseVisualStyleBackColor = false;
			cmd_switch.Click += new System.EventHandler(cmd_switch_Click);
			// 
			// grd_prices_sum
			// 
			grd_prices_sum.AllowDrop = true;
			grd_prices_sum.AllowUserToAddRows = false;
			grd_prices_sum.AllowUserToDeleteRows = false;
			grd_prices_sum.AllowUserToResizeColumns = false;
			grd_prices_sum.AllowUserToResizeRows = false;
			grd_prices_sum.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_prices_sum.ColumnsCount = 2;
			grd_prices_sum.FixedColumns = 1;
			grd_prices_sum.FixedRows = 1;
			grd_prices_sum.Location = new System.Drawing.Point(12, 16);
			grd_prices_sum.Name = "grd_prices_sum";
			grd_prices_sum.ReadOnly = true;
			grd_prices_sum.RowsCount = 2;
			grd_prices_sum.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			grd_prices_sum.ShowCellToolTips = false;
			grd_prices_sum.Size = new System.Drawing.Size(381, 203);
			grd_prices_sum.StandardTab = true;
			grd_prices_sum.TabIndex = 4;
			// 
			// frame_Missing_Solds
			// 
			frame_Missing_Solds.AllowDrop = true;
			frame_Missing_Solds.BackColor = System.Drawing.SystemColors.Control;
			frame_Missing_Solds.Controls.Add(frm_actions);
			frame_Missing_Solds.Controls.Add(cmd_export_list);
			frame_Missing_Solds.Controls.Add(grd_sale_prices);
			frame_Missing_Solds.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frame_Missing_Solds.Enabled = true;
			frame_Missing_Solds.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frame_Missing_Solds.ForeColor = System.Drawing.SystemColors.ControlText;
			frame_Missing_Solds.Location = new System.Drawing.Point(-2, 2);
			frame_Missing_Solds.Name = "frame_Missing_Solds";
			frame_Missing_Solds.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frame_Missing_Solds.Size = new System.Drawing.Size(1041, 405);
			frame_Missing_Solds.TabIndex = 0;
			frame_Missing_Solds.Text = "Retail Transactions with Missing Sold Prices";
			frame_Missing_Solds.Visible = true;
			// 
			// frm_actions
			// 
			frm_actions.AllowDrop = true;
			frm_actions.BackColor = System.Drawing.SystemColors.Control;
			frm_actions.Controls.Add(cmd_Refresh);
			frm_actions.Controls.Add(cbo_amod_make_name);
			frm_actions.Controls.Add(chk_sold_prices);
			frm_actions.Controls.Add(cbo_year);
			frm_actions.Controls.Add(_lbl_class_1);
			frm_actions.Controls.Add(_lbl_class_2);
			frm_actions.Controls.Add(_lbl_class_3);
			frm_actions.Controls.Add(_lbl_class_0);
			frm_actions.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frm_actions.Enabled = true;
			frm_actions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frm_actions.ForeColor = System.Drawing.SystemColors.ControlText;
			frm_actions.Location = new System.Drawing.Point(106, 354);
			frm_actions.Name = "frm_actions";
			frm_actions.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frm_actions.Size = new System.Drawing.Size(859, 51);
			frm_actions.TabIndex = 5;
			frm_actions.Text = "Actions";
			frm_actions.Visible = true;
			// 
			// cmd_Refresh
			// 
			cmd_Refresh.AllowDrop = true;
			cmd_Refresh.BackColor = System.Drawing.SystemColors.Control;
			cmd_Refresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Refresh.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Refresh.Location = new System.Drawing.Point(786, 14);
			cmd_Refresh.Name = "cmd_Refresh";
			cmd_Refresh.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Refresh.Size = new System.Drawing.Size(65, 31);
			cmd_Refresh.TabIndex = 9;
			cmd_Refresh.Text = "Refresh";
			cmd_Refresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Refresh.UseVisualStyleBackColor = false;
			cmd_Refresh.Click += new System.EventHandler(cmd_Refresh_Click);
			// 
			// cbo_amod_make_name
			// 
			cbo_amod_make_name.AllowDrop = true;
			cbo_amod_make_name.BackColor = System.Drawing.SystemColors.Window;
			cbo_amod_make_name.CausesValidation = true;
			cbo_amod_make_name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_amod_make_name.Enabled = true;
			cbo_amod_make_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_amod_make_name.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_amod_make_name.IntegralHeight = true;
			cbo_amod_make_name.Location = new System.Drawing.Point(520, 12);
			cbo_amod_make_name.Name = "cbo_amod_make_name";
			cbo_amod_make_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_amod_make_name.Size = new System.Drawing.Size(253, 21);
			cbo_amod_make_name.Sorted = false;
			cbo_amod_make_name.TabIndex = 8;
			cbo_amod_make_name.TabStop = true;
			cbo_amod_make_name.Visible = true;
			// 
			// chk_sold_prices
			// 
			chk_sold_prices.AllowDrop = true;
			chk_sold_prices.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_sold_prices.BackColor = System.Drawing.SystemColors.Control;
			chk_sold_prices.CausesValidation = true;
			chk_sold_prices.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_sold_prices.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_sold_prices.Enabled = true;
			chk_sold_prices.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_sold_prices.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_sold_prices.Location = new System.Drawing.Point(206, 10);
			chk_sold_prices.Name = "chk_sold_prices";
			chk_sold_prices.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_sold_prices.Size = new System.Drawing.Size(95, 19);
			chk_sold_prices.TabIndex = 7;
			chk_sold_prices.TabStop = true;
			chk_sold_prices.Text = "Show Solds";
			chk_sold_prices.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_sold_prices.Visible = true;
			// 
			// cbo_year
			// 
			cbo_year.AllowDrop = true;
			cbo_year.BackColor = System.Drawing.SystemColors.Window;
			cbo_year.CausesValidation = true;
			cbo_year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_year.Enabled = true;
			cbo_year.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_year.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_year.IntegralHeight = true;
			cbo_year.Location = new System.Drawing.Point(366, 10);
			cbo_year.Name = "cbo_year";
			cbo_year.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_year.Size = new System.Drawing.Size(69, 21);
			cbo_year.Sorted = false;
			cbo_year.TabIndex = 6;
			cbo_year.TabStop = true;
			cbo_year.Visible = true;
			// 
			// _lbl_class_1
			// 
			_lbl_class_1.AllowDrop = true;
			_lbl_class_1.BackColor = System.Drawing.SystemColors.Control;
			_lbl_class_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_class_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_class_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_class_1.Location = new System.Drawing.Point(10, 12);
			_lbl_class_1.MinimumSize = new System.Drawing.Size(77, 17);
			_lbl_class_1.Name = "_lbl_class_1";
			_lbl_class_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_class_1.Size = new System.Drawing.Size(77, 17);
			_lbl_class_1.TabIndex = 13;
			_lbl_class_1.Text = "Records Found:";
			// 
			// _lbl_class_2
			// 
			_lbl_class_2.AllowDrop = true;
			_lbl_class_2.BackColor = System.Drawing.SystemColors.Control;
			_lbl_class_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_class_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_class_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_class_2.Location = new System.Drawing.Point(104, 12);
			_lbl_class_2.MinimumSize = new System.Drawing.Size(57, 17);
			_lbl_class_2.Name = "_lbl_class_2";
			_lbl_class_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_class_2.Size = new System.Drawing.Size(57, 17);
			_lbl_class_2.TabIndex = 12;
			_lbl_class_2.Text = "0";
			// 
			// _lbl_class_3
			// 
			_lbl_class_3.AllowDrop = true;
			_lbl_class_3.BackColor = System.Drawing.SystemColors.Control;
			_lbl_class_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_class_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_class_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_class_3.Location = new System.Drawing.Point(450, 12);
			_lbl_class_3.MinimumSize = new System.Drawing.Size(77, 17);
			_lbl_class_3.Name = "_lbl_class_3";
			_lbl_class_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_class_3.Size = new System.Drawing.Size(77, 17);
			_lbl_class_3.TabIndex = 11;
			_lbl_class_3.Text = "Make/Model: ";
			// 
			// _lbl_class_0
			// 
			_lbl_class_0.AllowDrop = true;
			_lbl_class_0.BackColor = System.Drawing.SystemColors.Control;
			_lbl_class_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_class_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_class_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_class_0.Location = new System.Drawing.Point(330, 12);
			_lbl_class_0.MinimumSize = new System.Drawing.Size(27, 17);
			_lbl_class_0.Name = "_lbl_class_0";
			_lbl_class_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_class_0.Size = new System.Drawing.Size(27, 17);
			_lbl_class_0.TabIndex = 10;
			_lbl_class_0.Text = "Year:";
			// 
			// cmd_export_list
			// 
			cmd_export_list.AllowDrop = true;
			cmd_export_list.BackColor = System.Drawing.SystemColors.Control;
			cmd_export_list.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_export_list.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_export_list.Location = new System.Drawing.Point(6, 366);
			cmd_export_list.Name = "cmd_export_list";
			cmd_export_list.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_export_list.Size = new System.Drawing.Size(99, 33);
			cmd_export_list.TabIndex = 2;
			cmd_export_list.Text = "Export to Excel";
			cmd_export_list.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_export_list.UseVisualStyleBackColor = false;
			cmd_export_list.Click += new System.EventHandler(cmd_export_list_Click);
			// 
			// grd_sale_prices
			// 
			grd_sale_prices.AllowDrop = true;
			grd_sale_prices.AllowUserToAddRows = false;
			grd_sale_prices.AllowUserToDeleteRows = false;
			grd_sale_prices.AllowUserToResizeColumns = false;
			grd_sale_prices.AllowUserToResizeRows = false;
			grd_sale_prices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_sale_prices.ColumnsCount = 2;
			grd_sale_prices.FixedColumns = 1;
			grd_sale_prices.FixedRows = 1;
			grd_sale_prices.Location = new System.Drawing.Point(8, 18);
			grd_sale_prices.Name = "grd_sale_prices";
			grd_sale_prices.ReadOnly = true;
			grd_sale_prices.RowsCount = 2;
			grd_sale_prices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grd_sale_prices.ShowCellToolTips = false;
			grd_sale_prices.Size = new System.Drawing.Size(957, 337);
			grd_sale_prices.StandardTab = true;
			grd_sale_prices.TabIndex = 1;
			grd_sale_prices.Click += new System.EventHandler(grd_sale_prices_Click);
			grd_sale_prices.DoubleClick += new System.EventHandler(grd_sale_prices_DoubleClick);
			// 
			// frm_Missing_Solds
			// 
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			ClientSize = new System.Drawing.Size(969, 637);
			Controls.Add(frm_company_summary);
			Controls.Add(frame_Missing_Solds);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Location = new System.Drawing.Point(313, 235);
			MaximizeBox = true;
			MinimizeBox = true;
			Name = "frm_Missing_Solds";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			Text = "Retail Transactions with Missing Sold Prices";
			commandButtonHelper1.SetStyle(cmd_switch, 0);
			commandButtonHelper1.SetStyle(cmd_Refresh, 0);
			commandButtonHelper1.SetStyle(cmd_export_list, 0);
			Activated += new System.EventHandler(frm_Missing_Solds_Activated);
			Closed += new System.EventHandler(Form_Closed);
			((System.ComponentModel.ISupportInitialize) grd_prices_sum).EndInit();
			((System.ComponentModel.ISupportInitialize) grd_sale_prices).EndInit();
			frm_company_summary.ResumeLayout(false);
			frm_company_summary.PerformLayout();
			frame_Missing_Solds.ResumeLayout(false);
			frame_Missing_Solds.PerformLayout();
			frm_actions.ResumeLayout(false);
			frm_actions.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
		void ReLoadForm(bool addEvents) => Initializelbl_class();

		void Initializelbl_class()
		{
			lbl_class = new System.Windows.Forms.Label[4];
			lbl_class[1] = _lbl_class_1;
			lbl_class[2] = _lbl_class_2;
			lbl_class[3] = _lbl_class_3;
			lbl_class[0] = _lbl_class_0;
		}
		#endregion
	}
}