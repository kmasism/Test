
namespace JETNET_Homebase
{
	partial class frm_Company_Description
	{

		#region "Upgrade Support "
		private static frm_Company_Description m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_Company_Description DefInstance
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
		public static frm_Company_Description CreateInstance()
		{
			frm_Company_Description theInstance = new frm_Company_Description();
			theInstance.Form_Load();
			return theInstance;
		}
		private string[] visualControls = new string[]{"components", "ToolTipMain", "cmd_cancel", "web_comp_det", "commandButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Button cmd_cancel;
		public System.Windows.Forms.WebBrowser web_comp_det;
		public UpgradeHelpers.Gui.Controls.CommandButtonHelper commandButtonHelper1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Company_Description));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			cmd_cancel = new System.Windows.Forms.Button();
			web_comp_det = new System.Windows.Forms.WebBrowser();
			SuspendLayout();
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
			// 
			// cmd_cancel
			// 
			cmd_cancel.AllowDrop = true;
			cmd_cancel.BackColor = System.Drawing.SystemColors.Control;
			cmd_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_cancel.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_cancel.Location = new System.Drawing.Point(16, 544);
			cmd_cancel.Name = "cmd_cancel";
			cmd_cancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_cancel.Size = new System.Drawing.Size(65, 25);
			cmd_cancel.TabIndex = 1;
			cmd_cancel.Text = "Close";
			cmd_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_cancel.UseVisualStyleBackColor = false;
			cmd_cancel.Click += new System.EventHandler(cmd_cancel_Click);
			// 
			// web_comp_det
			// 
			web_comp_det.AllowWebBrowserDrop = true;
			web_comp_det.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			web_comp_det.Location = new System.Drawing.Point(16, 24);
			web_comp_det.Name = "web_comp_det";
			web_comp_det.Size = new System.Drawing.Size(585, 497);
			web_comp_det.TabIndex = 0;
			// 
			// frm_Company_Description
			// 
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			ClientSize = new System.Drawing.Size(625, 588);
			Controls.Add(cmd_cancel);
			Controls.Add(web_comp_det);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Location = new System.Drawing.Point(399, 156);
			MaximizeBox = true;
			MinimizeBox = true;
			Name = "frm_Company_Description";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			Text = "Company Description";
			commandButtonHelper1.SetStyle(cmd_cancel, 0);
			Activated += new System.EventHandler(frm_Company_Description_Activated);
			Closed += new System.EventHandler(Form_Closed);
			ResumeLayout(false);
			PerformLayout();
		}
		#endregion
	}
}