
namespace JETNET_Homebase
{
	partial class frm_CompanyBusinessTypes
	{

		#region "Upgrade Support "
		private static frm_CompanyBusinessTypes m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_CompanyBusinessTypes DefInstance
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
		public static frm_CompanyBusinessTypes CreateInstance()
		{
			frm_CompanyBusinessTypes theInstance = new frm_CompanyBusinessTypes();
			theInstance.Form_Load();
			return theInstance;
		}
		private string[] visualControls = new string[]{"components", "ToolTipMain", "cmdAdd", "cmdSave", "cboAvailTypes", "cmdRemove", "cmdDown", "cmdUp", "lstTypesUsed", "cmdCancel", "lblBusTypes", "listBoxHelper1", "commandButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Button cmdAdd;
		public System.Windows.Forms.Button cmdSave;
		public System.Windows.Forms.ComboBox cboAvailTypes;
		public System.Windows.Forms.Button cmdRemove;
		public System.Windows.Forms.Button cmdDown;
		public System.Windows.Forms.Button cmdUp;
		public System.Windows.Forms.ListBox lstTypesUsed;
		public System.Windows.Forms.Button cmdCancel;
		public System.Windows.Forms.Label lblBusTypes;
		public UpgradeHelpers.Gui.Controls.ListBoxHelper listBoxHelper1;
		public UpgradeHelpers.Gui.Controls.CommandButtonHelper commandButtonHelper1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_CompanyBusinessTypes));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			cmdAdd = new System.Windows.Forms.Button();
			cmdSave = new System.Windows.Forms.Button();
			cboAvailTypes = new System.Windows.Forms.ComboBox();
			cmdRemove = new System.Windows.Forms.Button();
			cmdDown = new System.Windows.Forms.Button();
			cmdUp = new System.Windows.Forms.Button();
			lstTypesUsed = new System.Windows.Forms.ListBox();
			cmdCancel = new System.Windows.Forms.Button();
			lblBusTypes = new System.Windows.Forms.Label();
			SuspendLayout();
			listBoxHelper1 = new UpgradeHelpers.Gui.Controls.ListBoxHelper(components);
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
			// 
			// cmdAdd
			// 
			cmdAdd.AllowDrop = true;
			cmdAdd.BackColor = System.Drawing.SystemColors.Control;
			cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdAdd.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdAdd.Location = new System.Drawing.Point(79, 38);
			cmdAdd.Name = "cmdAdd";
			cmdAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdAdd.Size = new System.Drawing.Size(63, 22);
			cmdAdd.TabIndex = 8;
			cmdAdd.Text = "Add";
			cmdAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdAdd.UseVisualStyleBackColor = false;
			cmdAdd.Click += new System.EventHandler(cmdAdd_Click);
			// 
			// cmdSave
			// 
			cmdSave.AllowDrop = true;
			cmdSave.BackColor = System.Drawing.SystemColors.Control;
			cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdSave.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdSave.Location = new System.Drawing.Point(79, 211);
			cmdSave.Name = "cmdSave";
			cmdSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdSave.Size = new System.Drawing.Size(63, 22);
			cmdSave.TabIndex = 7;
			cmdSave.Text = "Save";
			cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdSave.UseVisualStyleBackColor = false;
			cmdSave.Click += new System.EventHandler(cmdSave_Click);
			// 
			// cboAvailTypes
			// 
			cboAvailTypes.AllowDrop = true;
			cboAvailTypes.BackColor = System.Drawing.SystemColors.Window;
			cboAvailTypes.CausesValidation = true;
			cboAvailTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cboAvailTypes.Enabled = true;
			cboAvailTypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cboAvailTypes.ForeColor = System.Drawing.SystemColors.WindowText;
			cboAvailTypes.IntegralHeight = true;
			cboAvailTypes.Location = new System.Drawing.Point(9, 7);
			cboAvailTypes.Name = "cboAvailTypes";
			cboAvailTypes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cboAvailTypes.Size = new System.Drawing.Size(278, 21);
			cboAvailTypes.Sorted = false;
			cboAvailTypes.TabIndex = 6;
			cboAvailTypes.TabStop = true;
			cboAvailTypes.Visible = true;
			// 
			// cmdRemove
			// 
			cmdRemove.AllowDrop = true;
			cmdRemove.BackColor = System.Drawing.SystemColors.Control;
			cmdRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdRemove.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdRemove.Location = new System.Drawing.Point(153, 38);
			cmdRemove.Name = "cmdRemove";
			cmdRemove.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdRemove.Size = new System.Drawing.Size(63, 22);
			cmdRemove.TabIndex = 3;
			cmdRemove.Text = "Remove";
			cmdRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdRemove.UseVisualStyleBackColor = false;
			cmdRemove.Click += new System.EventHandler(cmdRemove_Click);
			// 
			// cmdDown
			// 
			cmdDown.AllowDrop = true;
			cmdDown.BackColor = System.Drawing.SystemColors.Control;
			cmdDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdDown.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdDown.Image = (System.Drawing.Image) resources.GetObject("cmdDown.Image");
			cmdDown.Location = new System.Drawing.Point(261, 149);
			cmdDown.Name = "cmdDown";
			cmdDown.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdDown.Size = new System.Drawing.Size(26, 37);
			cmdDown.TabIndex = 2;
			cmdDown.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdDown.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdDown.UseVisualStyleBackColor = false;
			cmdDown.Click += new System.EventHandler(cmdDown_Click);
			// 
			// cmdUp
			// 
			cmdUp.AllowDrop = true;
			cmdUp.BackColor = System.Drawing.SystemColors.Control;
			cmdUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdUp.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdUp.Image = (System.Drawing.Image) resources.GetObject("cmdUp.Image");
			cmdUp.Location = new System.Drawing.Point(261, 107);
			cmdUp.Name = "cmdUp";
			cmdUp.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdUp.Size = new System.Drawing.Size(26, 35);
			cmdUp.TabIndex = 0;
			cmdUp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdUp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdUp.UseVisualStyleBackColor = false;
			cmdUp.Click += new System.EventHandler(cmdUp_Click);
			// 
			// lstTypesUsed
			// 
			lstTypesUsed.AllowDrop = true;
			lstTypesUsed.BackColor = System.Drawing.SystemColors.Window;
			lstTypesUsed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lstTypesUsed.CausesValidation = true;
			lstTypesUsed.Enabled = true;
			lstTypesUsed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lstTypesUsed.ForeColor = System.Drawing.SystemColors.WindowText;
			lstTypesUsed.IntegralHeight = true;
			lstTypesUsed.Location = new System.Drawing.Point(9, 93);
			lstTypesUsed.MultiColumn = false;
			lstTypesUsed.Name = "lstTypesUsed";
			lstTypesUsed.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lstTypesUsed.Size = new System.Drawing.Size(248, 109);
			lstTypesUsed.Sorted = false;
			lstTypesUsed.TabIndex = 1;
			lstTypesUsed.TabStop = true;
			lstTypesUsed.Visible = true;
			// 
			// cmdCancel
			// 
			cmdCancel.AllowDrop = true;
			cmdCancel.BackColor = System.Drawing.SystemColors.Control;
			cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdCancel.Location = new System.Drawing.Point(153, 211);
			cmdCancel.Name = "cmdCancel";
			cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdCancel.Size = new System.Drawing.Size(63, 22);
			cmdCancel.TabIndex = 5;
			cmdCancel.Text = "Cancel";
			cmdCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdCancel.UseVisualStyleBackColor = false;
			cmdCancel.Click += new System.EventHandler(cmdCancel_Click);
			// 
			// lblBusTypes
			// 
			lblBusTypes.AllowDrop = true;
			lblBusTypes.BackColor = System.Drawing.SystemColors.Control;
			lblBusTypes.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblBusTypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblBusTypes.ForeColor = System.Drawing.SystemColors.ControlText;
			lblBusTypes.Location = new System.Drawing.Point(51, 70);
			lblBusTypes.MinimumSize = new System.Drawing.Size(194, 13);
			lblBusTypes.Name = "lblBusTypes";
			lblBusTypes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblBusTypes.Size = new System.Drawing.Size(194, 13);
			lblBusTypes.TabIndex = 4;
			lblBusTypes.Text = "Business Types: (Primary type on top)";
			lblBusTypes.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// frm_CompanyBusinessTypes
			// 
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			CancelButton = cmdCancel;
			ClientSize = new System.Drawing.Size(295, 240);
			ControlBox = false;
			Controls.Add(cmdAdd);
			Controls.Add(cmdSave);
			Controls.Add(cboAvailTypes);
			Controls.Add(cmdRemove);
			Controls.Add(cmdDown);
			Controls.Add(cmdUp);
			Controls.Add(lstTypesUsed);
			Controls.Add(cmdCancel);
			Controls.Add(lblBusTypes);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			Location = new System.Drawing.Point(543, 362);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "frm_CompanyBusinessTypes";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			Text = "Company Business Types";
			commandButtonHelper1.SetStyle(cmdAdd, 0);
			commandButtonHelper1.SetStyle(cmdSave, 0);
			commandButtonHelper1.SetStyle(cmdRemove, 0);
			commandButtonHelper1.SetStyle(cmdDown, 1);
			commandButtonHelper1.SetStyle(cmdUp, 1);
			commandButtonHelper1.SetStyle(cmdCancel, 0);
			listBoxHelper1.SetSelectionMode(lstTypesUsed, System.Windows.Forms.SelectionMode.One);
			Activated += new System.EventHandler(Form_Activated);
			Closed += new System.EventHandler(Form_Closed);
			ResumeLayout(false);
			PerformLayout();
		}
		#endregion
	}
}