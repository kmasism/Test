
namespace JETNET_Homebase
{
	partial class frm_Web_Page
	{

		#region "Upgrade Support "
		private static frm_Web_Page m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_Web_Page DefInstance
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
		public static frm_Web_Page CreateInstance()
		{
			frm_Web_Page theInstance = new frm_Web_Page();
			theInstance.Form_Load();
			return theInstance;
		}
		private string[] visualControls = new string[]{"components", "ToolTipMain", "cmd_launch_webpage", "WebBrowser1", "commandButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Button cmd_launch_webpage;
		public System.Windows.Forms.WebBrowser WebBrowser1;
		public UpgradeHelpers.Gui.Controls.CommandButtonHelper commandButtonHelper1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Web_Page));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			cmd_launch_webpage = new System.Windows.Forms.Button();
			WebBrowser1 = new System.Windows.Forms.WebBrowser();
			SuspendLayout();
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
			// 
			// cmd_launch_webpage
			// 
			cmd_launch_webpage.AllowDrop = true;
			cmd_launch_webpage.BackColor = System.Drawing.SystemColors.Control;
			cmd_launch_webpage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_launch_webpage.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_launch_webpage.Location = new System.Drawing.Point(948, 552);
			cmd_launch_webpage.Name = "cmd_launch_webpage";
			cmd_launch_webpage.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_launch_webpage.Size = new System.Drawing.Size(133, 31);
			cmd_launch_webpage.TabIndex = 1;
			cmd_launch_webpage.Text = "Launch Web Page";
			cmd_launch_webpage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_launch_webpage.UseVisualStyleBackColor = false;
			cmd_launch_webpage.Click += new System.EventHandler(cmd_launch_webpage_Click);
			// 
			// WebBrowser1
			// 
			WebBrowser1.AllowWebBrowserDrop = true;
			WebBrowser1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			WebBrowser1.Location = new System.Drawing.Point(6, 4);
			WebBrowser1.Name = "WebBrowser1";
			WebBrowser1.Size = new System.Drawing.Size(1077, 541);
			WebBrowser1.TabIndex = 0;
			// 
			// frm_Web_Page
			// 
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			ClientSize = new System.Drawing.Size(1087, 589);
			Controls.Add(cmd_launch_webpage);
			Controls.Add(WebBrowser1);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Location = new System.Drawing.Point(144, 181);
			MaximizeBox = true;
			MinimizeBox = true;
			Name = "frm_Web_Page";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			Text = "Web Page";
			commandButtonHelper1.SetStyle(cmd_launch_webpage, 0);
			Activated += new System.EventHandler(frm_Web_Page_Activated);
			Closed += new System.EventHandler(Form_Closed);
			ResumeLayout(false);
			PerformLayout();
		}
		#endregion
	}
}