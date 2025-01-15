
namespace JETNET_Homebase
{
	partial class frm_info2
	{

		#region "Upgrade Support "
		private static frm_info2 m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_info2 DefInstance
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
		public static frm_info2 CreateInstance()
		{
			frm_info2 theInstance = new frm_info2();
			theInstance.Form_Load();
			return theInstance;
		}
		private string[] visualControls = new string[]{"components", "ToolTipMain", "cmdClose", "txtInfo", "commandButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_info2));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			cmdClose = new System.Windows.Forms.Button();
			txtInfo = new System.Windows.Forms.TextBox();
			SuspendLayout();
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
			// 
			// cmdClose
			// 
			cmdClose.AllowDrop = true;
			cmdClose.BackColor = System.Drawing.SystemColors.Control;
			cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdClose.Location = new System.Drawing.Point(8, 536);
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
			txtInfo.Location = new System.Drawing.Point(0, 0);
			txtInfo.MaxLength = 0;
			txtInfo.Multiline = true;
			txtInfo.Name = "txtInfo";
			txtInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			txtInfo.Size = new System.Drawing.Size(529, 527);
			txtInfo.TabIndex = 0;
			// 
			// frm_info2
			// 
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			ClientSize = new System.Drawing.Size(543, 570);
			Controls.Add(cmdClose);
			Controls.Add(txtInfo);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Location = new System.Drawing.Point(4, 27);
			MaximizeBox = true;
			MinimizeBox = true;
			Name = "frm_info2";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			Text = "Information";
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