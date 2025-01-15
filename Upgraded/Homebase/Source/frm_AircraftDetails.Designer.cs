
namespace JETNET_Homebase
{
	partial class frm_AircraftDetails
	{

		#region "Upgrade Support "
		private static frm_AircraftDetails m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_AircraftDetails DefInstance
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
		public static frm_AircraftDetails CreateInstance()
		{
			frm_AircraftDetails theInstance = new frm_AircraftDetails();
			theInstance.Form_Load();
			return theInstance;
		}
		private string[] visualControls = new string[]{"components", "ToolTipMain", "cmdDelete", "lst_aircraft_info", "cmdSave", "cmd_Close", "txt_adet_data_description", "cbo_adet_data_name", "lblMessage", "lblTitle", "listBoxHelper1", "commandButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Button cmdDelete;
		public System.Windows.Forms.ListBox lst_aircraft_info;
		public System.Windows.Forms.Button cmdSave;
		public System.Windows.Forms.Button cmd_Close;
		public System.Windows.Forms.TextBox txt_adet_data_description;
		public System.Windows.Forms.ComboBox cbo_adet_data_name;
		public System.Windows.Forms.Label lblMessage;
		public System.Windows.Forms.Label lblTitle;
		public UpgradeHelpers.Gui.Controls.ListBoxHelper listBoxHelper1;
		public UpgradeHelpers.Gui.Controls.CommandButtonHelper commandButtonHelper1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_AircraftDetails));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			cmdDelete = new System.Windows.Forms.Button();
			lst_aircraft_info = new System.Windows.Forms.ListBox();
			cmdSave = new System.Windows.Forms.Button();
			cmd_Close = new System.Windows.Forms.Button();
			txt_adet_data_description = new System.Windows.Forms.TextBox();
			cbo_adet_data_name = new System.Windows.Forms.ComboBox();
			lblMessage = new System.Windows.Forms.Label();
			lblTitle = new System.Windows.Forms.Label();
			SuspendLayout();
			listBoxHelper1 = new UpgradeHelpers.Gui.Controls.ListBoxHelper(components);
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
			// 
			// cmdDelete
			// 
			cmdDelete.AllowDrop = true;
			cmdDelete.BackColor = System.Drawing.SystemColors.Control;
			cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdDelete.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdDelete.Location = new System.Drawing.Point(328, 259);
			cmdDelete.Name = "cmdDelete";
			cmdDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdDelete.Size = new System.Drawing.Size(128, 18);
			cmdDelete.TabIndex = 6;
			cmdDelete.Text = "Delete This Detail";
			cmdDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdDelete.UseVisualStyleBackColor = false;
			cmdDelete.Click += new System.EventHandler(cmdDelete_Click);
			// 
			// lst_aircraft_info
			// 
			lst_aircraft_info.AllowDrop = true;
			lst_aircraft_info.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			lst_aircraft_info.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			lst_aircraft_info.CausesValidation = true;
			lst_aircraft_info.Enabled = true;
			lst_aircraft_info.Font = new System.Drawing.Font("Courier New", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lst_aircraft_info.ForeColor = System.Drawing.SystemColors.WindowText;
			lst_aircraft_info.IntegralHeight = true;
			lst_aircraft_info.Location = new System.Drawing.Point(86, 8);
			lst_aircraft_info.MultiColumn = false;
			lst_aircraft_info.Name = "lst_aircraft_info";
			lst_aircraft_info.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lst_aircraft_info.Size = new System.Drawing.Size(297, 91);
			lst_aircraft_info.Sorted = false;
			lst_aircraft_info.TabIndex = 4;
			lst_aircraft_info.TabStop = true;
			lst_aircraft_info.Visible = true;
			// 
			// cmdSave
			// 
			cmdSave.AllowDrop = true;
			cmdSave.BackColor = System.Drawing.SystemColors.Control;
			cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdSave.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdSave.Location = new System.Drawing.Point(312, 281);
			cmdSave.Name = "cmdSave";
			cmdSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdSave.Size = new System.Drawing.Size(76, 19);
			cmdSave.TabIndex = 3;
			cmdSave.Text = "Save";
			cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdSave.UseVisualStyleBackColor = false;
			cmdSave.Click += new System.EventHandler(cmdSave_Click);
			// 
			// cmd_Close
			// 
			cmd_Close.AllowDrop = true;
			cmd_Close.BackColor = System.Drawing.SystemColors.Control;
			cmd_Close.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Close.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Close.Location = new System.Drawing.Point(392, 280);
			cmd_Close.Name = "cmd_Close";
			cmd_Close.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Close.Size = new System.Drawing.Size(76, 19);
			cmd_Close.TabIndex = 2;
			cmd_Close.Text = "Close";
			cmd_Close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Close.UseVisualStyleBackColor = false;
			cmd_Close.Click += new System.EventHandler(cmd_Close_Click);
			// 
			// txt_adet_data_description
			// 
			txt_adet_data_description.AcceptsReturn = true;
			txt_adet_data_description.AllowDrop = true;
			txt_adet_data_description.BackColor = System.Drawing.SystemColors.Window;
			txt_adet_data_description.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_adet_data_description.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_adet_data_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_adet_data_description.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_adet_data_description.Location = new System.Drawing.Point(5, 156);
			txt_adet_data_description.MaxLength = 0;
			txt_adet_data_description.Multiline = true;
			txt_adet_data_description.Name = "txt_adet_data_description";
			txt_adet_data_description.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_adet_data_description.Size = new System.Drawing.Size(456, 86);
			txt_adet_data_description.TabIndex = 1;
			txt_adet_data_description.KeyUp += new System.Windows.Forms.KeyEventHandler(txt_adet_data_description_KeyUp);
			// 
			// cbo_adet_data_name
			// 
			cbo_adet_data_name.AllowDrop = true;
			cbo_adet_data_name.BackColor = System.Drawing.SystemColors.Window;
			cbo_adet_data_name.CausesValidation = true;
			cbo_adet_data_name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_adet_data_name.Enabled = true;
			cbo_adet_data_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_adet_data_name.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_adet_data_name.IntegralHeight = true;
			cbo_adet_data_name.Location = new System.Drawing.Point(5, 131);
			cbo_adet_data_name.Name = "cbo_adet_data_name";
			cbo_adet_data_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_adet_data_name.Size = new System.Drawing.Size(190, 21);
			cbo_adet_data_name.Sorted = false;
			cbo_adet_data_name.TabIndex = 0;
			cbo_adet_data_name.TabStop = true;
			cbo_adet_data_name.Visible = true;
			cbo_adet_data_name.SelectedIndexChanged += new System.EventHandler(cbo_adet_data_name_SelectedIndexChanged);
			// 
			// lblMessage
			// 
			lblMessage.AllowDrop = true;
			lblMessage.BackColor = System.Drawing.Color.Transparent;
			lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblMessage.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
			lblMessage.Location = new System.Drawing.Point(12, 248);
			lblMessage.MinimumSize = new System.Drawing.Size(275, 51);
			lblMessage.Name = "lblMessage";
			lblMessage.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblMessage.Size = new System.Drawing.Size(275, 51);
			lblMessage.TabIndex = 7;
			// 
			// lblTitle
			// 
			lblTitle.AllowDrop = true;
			lblTitle.BackColor = System.Drawing.Color.Transparent;
			lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblTitle.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
			lblTitle.Location = new System.Drawing.Point(12, 101);
			lblTitle.MinimumSize = new System.Drawing.Size(456, 28);
			lblTitle.Name = "lblTitle";
			lblTitle.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblTitle.Size = new System.Drawing.Size(456, 28);
			lblTitle.TabIndex = 5;
			lblTitle.Text = "Title";
			lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// frm_AircraftDetails
			// 
			AcceptButton = cmdSave;
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			CancelButton = cmd_Close;
			ClientSize = new System.Drawing.Size(471, 302);
			Controls.Add(cmdDelete);
			Controls.Add(lst_aircraft_info);
			Controls.Add(cmdSave);
			Controls.Add(cmd_Close);
			Controls.Add(txt_adet_data_description);
			Controls.Add(cbo_adet_data_name);
			Controls.Add(lblMessage);
			Controls.Add(lblTitle);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Location = new System.Drawing.Point(550, 265);
			MaximizeBox = true;
			MinimizeBox = true;
			Name = "frm_AircraftDetails";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			Text = "Aircraft Details";
			commandButtonHelper1.SetStyle(cmdDelete, 0);
			commandButtonHelper1.SetStyle(cmdSave, 0);
			commandButtonHelper1.SetStyle(cmd_Close, 0);
			listBoxHelper1.SetSelectionMode(lst_aircraft_info, System.Windows.Forms.SelectionMode.One);
			Activated += new System.EventHandler(frm_AircraftDetails_Activated);
			Closed += new System.EventHandler(Form_Closed);
			ResumeLayout(false);
			PerformLayout();
		}
		#endregion
	}
}