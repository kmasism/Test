
namespace JETNET_Homebase
{
	partial class frm_ShareRelationships
	{

		#region "Upgrade Support "
		private static frm_ShareRelationships m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_ShareRelationships DefInstance
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
		public static frm_ShareRelationships CreateInstance()
		{
			frm_ShareRelationships theInstance = new frm_ShareRelationships();
			theInstance.Form_Load();
			return theInstance;
		}
		private string[] visualControls = new string[]{"components", "ToolTipMain", "cmd_Close", "cmdRemoveRelationship", "cmdAddRelationship", "grdRelationships", "lst_Aircraft", "lst_Contact", "lst_Company", "_lbl_gen_3", "_lbl_gen_2", "_lbl_gen_1", "_lbl_gen_0", "lblTitle", "lbl_gen", "listBoxHelper1", "commandButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Button cmd_Close;
		public System.Windows.Forms.Button cmdRemoveRelationship;
		public System.Windows.Forms.Button cmdAddRelationship;
		public UpgradeHelpers.DataGridViewFlex grdRelationships;
		public System.Windows.Forms.ListBox lst_Aircraft;
		public System.Windows.Forms.ListBox lst_Contact;
		public System.Windows.Forms.ListBox lst_Company;
		private System.Windows.Forms.Label _lbl_gen_3;
		private System.Windows.Forms.Label _lbl_gen_2;
		private System.Windows.Forms.Label _lbl_gen_1;
		private System.Windows.Forms.Label _lbl_gen_0;
		public System.Windows.Forms.Label lblTitle;
		public System.Windows.Forms.Label[] lbl_gen = new System.Windows.Forms.Label[4];
		public UpgradeHelpers.Gui.Controls.ListBoxHelper listBoxHelper1;
		public UpgradeHelpers.Gui.Controls.CommandButtonHelper commandButtonHelper1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ShareRelationships));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			cmd_Close = new System.Windows.Forms.Button();
			cmdRemoveRelationship = new System.Windows.Forms.Button();
			cmdAddRelationship = new System.Windows.Forms.Button();
			grdRelationships = new UpgradeHelpers.DataGridViewFlex(components);
			lst_Aircraft = new System.Windows.Forms.ListBox();
			lst_Contact = new System.Windows.Forms.ListBox();
			lst_Company = new System.Windows.Forms.ListBox();
			_lbl_gen_3 = new System.Windows.Forms.Label();
			_lbl_gen_2 = new System.Windows.Forms.Label();
			_lbl_gen_1 = new System.Windows.Forms.Label();
			_lbl_gen_0 = new System.Windows.Forms.Label();
			lblTitle = new System.Windows.Forms.Label();
			SuspendLayout();
			listBoxHelper1 = new UpgradeHelpers.Gui.Controls.ListBoxHelper(components);
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
			((System.ComponentModel.ISupportInitialize) grdRelationships).BeginInit();
			// 
			// cmd_Close
			// 
			cmd_Close.AllowDrop = true;
			cmd_Close.BackColor = System.Drawing.SystemColors.Control;
			cmd_Close.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Close.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Close.Location = new System.Drawing.Point(533, 541);
			cmd_Close.Name = "cmd_Close";
			cmd_Close.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Close.Size = new System.Drawing.Size(133, 25);
			cmd_Close.TabIndex = 11;
			cmd_Close.Text = "Close";
			cmd_Close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Close.UseVisualStyleBackColor = false;
			cmd_Close.Click += new System.EventHandler(cmd_close_Click);
			// 
			// cmdRemoveRelationship
			// 
			cmdRemoveRelationship.AllowDrop = true;
			cmdRemoveRelationship.BackColor = System.Drawing.SystemColors.Control;
			cmdRemoveRelationship.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdRemoveRelationship.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdRemoveRelationship.Location = new System.Drawing.Point(357, 541);
			cmdRemoveRelationship.Name = "cmdRemoveRelationship";
			cmdRemoveRelationship.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdRemoveRelationship.Size = new System.Drawing.Size(167, 25);
			cmdRemoveRelationship.TabIndex = 10;
			cmdRemoveRelationship.Text = "Remove Relationship";
			cmdRemoveRelationship.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdRemoveRelationship.UseVisualStyleBackColor = false;
			cmdRemoveRelationship.Click += new System.EventHandler(cmdRemoveRelationship_Click);
			// 
			// cmdAddRelationship
			// 
			cmdAddRelationship.AllowDrop = true;
			cmdAddRelationship.BackColor = System.Drawing.SystemColors.Control;
			cmdAddRelationship.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdAddRelationship.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdAddRelationship.Location = new System.Drawing.Point(180, 542);
			cmdAddRelationship.Name = "cmdAddRelationship";
			cmdAddRelationship.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdAddRelationship.Size = new System.Drawing.Size(167, 25);
			cmdAddRelationship.TabIndex = 9;
			cmdAddRelationship.Text = "Add Relationship";
			cmdAddRelationship.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdAddRelationship.UseVisualStyleBackColor = false;
			cmdAddRelationship.Click += new System.EventHandler(cmdAddRelationship_Click);
			// 
			// grdRelationships
			// 
			grdRelationships.AllowDrop = true;
			grdRelationships.AllowUserToAddRows = false;
			grdRelationships.AllowUserToDeleteRows = false;
			grdRelationships.AllowUserToResizeColumns = false;
			grdRelationships.AllowUserToResizeColumns = grdRelationships.ColumnHeadersVisible;
			grdRelationships.AllowUserToResizeRows = false;
			grdRelationships.AllowUserToResizeRows = grdRelationships.RowHeadersVisible;
			grdRelationships.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grdRelationships.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grdRelationships.ColumnsCount = 2;
			grdRelationships.FixedColumns = 1;
			grdRelationships.FixedRows = 1;
			grdRelationships.Location = new System.Drawing.Point(14, 183);
			grdRelationships.Name = "grdRelationships";
			grdRelationships.ReadOnly = true;
			grdRelationships.RowsCount = 2;
			grdRelationships.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grdRelationships.ShowCellToolTips = false;
			grdRelationships.Size = new System.Drawing.Size(817, 350);
			grdRelationships.StandardTab = true;
			grdRelationships.TabIndex = 7;
			grdRelationships.Click += new System.EventHandler(grdRelationships_Click);
			// 
			// lst_Aircraft
			// 
			lst_Aircraft.AllowDrop = true;
			lst_Aircraft.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			lst_Aircraft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lst_Aircraft.CausesValidation = true;
			lst_Aircraft.Enabled = true;
			lst_Aircraft.Font = new System.Drawing.Font("Courier New", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lst_Aircraft.ForeColor = System.Drawing.SystemColors.WindowText;
			lst_Aircraft.IntegralHeight = true;
			lst_Aircraft.Location = new System.Drawing.Point(13, 63);
			lst_Aircraft.MultiColumn = false;
			lst_Aircraft.Name = "lst_Aircraft";
			lst_Aircraft.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lst_Aircraft.Size = new System.Drawing.Size(269, 95);
			lst_Aircraft.Sorted = false;
			lst_Aircraft.TabIndex = 2;
			lst_Aircraft.TabStop = true;
			lst_Aircraft.Visible = true;
			// 
			// lst_Contact
			// 
			lst_Contact.AllowDrop = true;
			lst_Contact.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			lst_Contact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lst_Contact.CausesValidation = true;
			lst_Contact.Enabled = true;
			lst_Contact.Font = new System.Drawing.Font("Courier New", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lst_Contact.ForeColor = System.Drawing.SystemColors.WindowText;
			lst_Contact.IntegralHeight = true;
			lst_Contact.Location = new System.Drawing.Point(561, 63);
			lst_Contact.MultiColumn = false;
			lst_Contact.Name = "lst_Contact";
			lst_Contact.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lst_Contact.Size = new System.Drawing.Size(269, 95);
			lst_Contact.Sorted = false;
			lst_Contact.TabIndex = 1;
			lst_Contact.TabStop = true;
			lst_Contact.Visible = true;
			// 
			// lst_Company
			// 
			lst_Company.AllowDrop = true;
			lst_Company.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			lst_Company.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lst_Company.CausesValidation = true;
			lst_Company.Enabled = true;
			lst_Company.Font = new System.Drawing.Font("Courier New", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lst_Company.ForeColor = System.Drawing.SystemColors.WindowText;
			lst_Company.IntegralHeight = true;
			lst_Company.Location = new System.Drawing.Point(287, 63);
			lst_Company.MultiColumn = false;
			lst_Company.Name = "lst_Company";
			lst_Company.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lst_Company.Size = new System.Drawing.Size(269, 95);
			lst_Company.Sorted = false;
			lst_Company.TabIndex = 0;
			lst_Company.TabStop = true;
			lst_Company.Visible = true;
			// 
			// _lbl_gen_3
			// 
			_lbl_gen_3.AllowDrop = true;
			_lbl_gen_3.AutoSize = true;
			_lbl_gen_3.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_3.Location = new System.Drawing.Point(365, 164);
			_lbl_gen_3.MinimumSize = new System.Drawing.Size(141, 16);
			_lbl_gen_3.Name = "_lbl_gen_3";
			_lbl_gen_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_3.Size = new System.Drawing.Size(141, 16);
			_lbl_gen_3.TabIndex = 8;
			_lbl_gen_3.Text = "Share Relationships";
			// 
			// _lbl_gen_2
			// 
			_lbl_gen_2.AllowDrop = true;
			_lbl_gen_2.AutoSize = true;
			_lbl_gen_2.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_2.Location = new System.Drawing.Point(561, 48);
			_lbl_gen_2.MinimumSize = new System.Drawing.Size(49, 13);
			_lbl_gen_2.Name = "_lbl_gen_2";
			_lbl_gen_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_2.Size = new System.Drawing.Size(49, 13);
			_lbl_gen_2.TabIndex = 6;
			_lbl_gen_2.Text = "Contact:";
			// 
			// _lbl_gen_1
			// 
			_lbl_gen_1.AllowDrop = true;
			_lbl_gen_1.AutoSize = true;
			_lbl_gen_1.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_1.Location = new System.Drawing.Point(287, 48);
			_lbl_gen_1.MinimumSize = new System.Drawing.Size(56, 13);
			_lbl_gen_1.Name = "_lbl_gen_1";
			_lbl_gen_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_1.Size = new System.Drawing.Size(56, 13);
			_lbl_gen_1.TabIndex = 5;
			_lbl_gen_1.Text = "Company:";
			// 
			// _lbl_gen_0
			// 
			_lbl_gen_0.AllowDrop = true;
			_lbl_gen_0.AutoSize = true;
			_lbl_gen_0.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_0.Location = new System.Drawing.Point(13, 48);
			_lbl_gen_0.MinimumSize = new System.Drawing.Size(46, 13);
			_lbl_gen_0.Name = "_lbl_gen_0";
			_lbl_gen_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_0.Size = new System.Drawing.Size(46, 13);
			_lbl_gen_0.TabIndex = 4;
			_lbl_gen_0.Text = "Aircraft:";
			// 
			// lblTitle
			// 
			lblTitle.AllowDrop = true;
			lblTitle.BackColor = System.Drawing.Color.Transparent;
			lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblTitle.ForeColor = System.Drawing.SystemColors.ControlText;
			lblTitle.Location = new System.Drawing.Point(18, 5);
			lblTitle.MinimumSize = new System.Drawing.Size(808, 42);
			lblTitle.Name = "lblTitle";
			lblTitle.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblTitle.Size = new System.Drawing.Size(808, 42);
			lblTitle.TabIndex = 3;
			lblTitle.Text = "Label1";
			lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// frm_ShareRelationships
			// 
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			ClientSize = new System.Drawing.Size(845, 575);
			Controls.Add(cmd_Close);
			Controls.Add(cmdRemoveRelationship);
			Controls.Add(cmdAddRelationship);
			Controls.Add(grdRelationships);
			Controls.Add(lst_Aircraft);
			Controls.Add(lst_Contact);
			Controls.Add(lst_Company);
			Controls.Add(_lbl_gen_3);
			Controls.Add(_lbl_gen_2);
			Controls.Add(_lbl_gen_1);
			Controls.Add(_lbl_gen_0);
			Controls.Add(lblTitle);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Location = new System.Drawing.Point(197, 212);
			MaximizeBox = true;
			MinimizeBox = true;
			Name = "frm_ShareRelationships";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			Text = "Share Relationships";
			commandButtonHelper1.SetStyle(cmd_Close, 0);
			commandButtonHelper1.SetStyle(cmdRemoveRelationship, 0);
			commandButtonHelper1.SetStyle(cmdAddRelationship, 0);
			listBoxHelper1.SetSelectionMode(lst_Aircraft, System.Windows.Forms.SelectionMode.One);
			listBoxHelper1.SetSelectionMode(lst_Contact, System.Windows.Forms.SelectionMode.One);
			listBoxHelper1.SetSelectionMode(lst_Company, System.Windows.Forms.SelectionMode.One);
			Activated += new System.EventHandler(Form_Activated);
			Closed += new System.EventHandler(Form_Closed);
			((System.ComponentModel.ISupportInitialize) grdRelationships).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
		void ReLoadForm(bool addEvents) => Initializelbl_gen();

		void Initializelbl_gen()
		{
			lbl_gen = new System.Windows.Forms.Label[4];
			lbl_gen[3] = _lbl_gen_3;
			lbl_gen[2] = _lbl_gen_2;
			lbl_gen[1] = _lbl_gen_1;
			lbl_gen[0] = _lbl_gen_0;
		}
		#endregion
	}
}