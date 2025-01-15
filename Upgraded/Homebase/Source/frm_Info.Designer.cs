
namespace JETNET_Homebase
{
	partial class frm_Info
	{

		#region "Upgrade Support "
		private static frm_Info m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_Info DefInstance
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
		public static frm_Info CreateInstance()
		{
			frm_Info theInstance = new frm_Info();
			theInstance.Form_Load();
			return theInstance;
		}
		private string[] visualControls = new string[]{"components", "ToolTipMain", "cmd_show_all", "cmdClose", "txtInfo", "commandButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Button cmd_show_all;
		public System.Windows.Forms.Button cmdClose;
		public System.Windows.Forms.TextBox txtInfo;
		public UpgradeHelpers.Gui.Controls.CommandButtonHelper commandButtonHelper1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Info));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			cmd_show_all = new System.Windows.Forms.Button();
			cmdClose = new System.Windows.Forms.Button();
			txtInfo = new System.Windows.Forms.TextBox();
			SuspendLayout();
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
			// 
			// cmd_show_all
			// 
			cmd_show_all.AllowDrop = true;
			cmd_show_all.BackColor = System.Drawing.SystemColors.Control;
			cmd_show_all.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_show_all.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_show_all.Location = new System.Drawing.Point(368, 536);
			cmd_show_all.Name = "cmd_show_all";
			cmd_show_all.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_show_all.Size = new System.Drawing.Size(145, 25);
			cmd_show_all.TabIndex = 2;
			cmd_show_all.Text = "Show All Relationships";
			cmd_show_all.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_show_all.UseVisualStyleBackColor = false;
			cmd_show_all.Visible = false;
			cmd_show_all.Click += new System.EventHandler(cmd_show_all_Click);
			// 
			// cmdClose
			// 
			cmdClose.AllowDrop = true;
			cmdClose.BackColor = System.Drawing.SystemColors.Control;
			cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdClose.Location = new System.Drawing.Point(8, 540);
			cmdClose.Name = "cmdClose";
			cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdClose.Size = new System.Drawing.Size(65, 21);
			cmdClose.TabIndex = 1;
			cmdClose.Text = "Close";
			cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdClose.UseVisualStyleBackColor = false;
			cmdClose.Click += new System.EventHandler(cmdClose_Click);
			// 
			// txtInfo
			// 
			txtInfo.AcceptsReturn = true;
			txtInfo.AllowDrop = true;
			txtInfo.BackColor = System.Drawing.SystemColors.Window;
			txtInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtInfo.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtInfo.Enabled = false;
			txtInfo.Font = new System.Drawing.Font("Arial", 11.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtInfo.ForeColor = System.Drawing.SystemColors.WindowText;
			txtInfo.Location = new System.Drawing.Point(6, 6);
			txtInfo.MaxLength = 0;
			txtInfo.Multiline = true;
			txtInfo.Name = "txtInfo";
			txtInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			txtInfo.Size = new System.Drawing.Size(529, 527);
			txtInfo.TabIndex = 0;
			// 
			// frm_Info
			// 
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			ClientSize = new System.Drawing.Size(542, 568);
			Controls.Add(cmd_show_all);
			Controls.Add(cmdClose);
			Controls.Add(txtInfo);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Location = new System.Drawing.Point(289, 173);
			MaximizeBox = true;
			MinimizeBox = true;
			Name = "frm_Info";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			Text = "Information";
			commandButtonHelper1.SetStyle(cmd_show_all, 0);
			commandButtonHelper1.SetStyle(cmdClose, 0);
			Activated += new System.EventHandler(Form_Activated);
			Closed += new System.EventHandler(Form_Closed);
			Resize += new System.EventHandler(Form_Resize);
			ResumeLayout(false);
			PerformLayout();
		}
		#endregion
	}
}