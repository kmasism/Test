
namespace JETNET_Homebase
{
	partial class frm_WebReport
	{

		#region "Upgrade Support "
		private static frm_WebReport m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_WebReport DefInstance
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
		public static frm_WebReport CreateInstance()
		{
			frm_WebReport theInstance = new frm_WebReport();
			theInstance.Form_Load();
			return theInstance;
		}
		private string[] visualControls = new string[]{"components", "ToolTipMain", "brw_Report", "pnl_Please_Wait"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.WebBrowser brw_Report;
		public System.Windows.Forms.Panel pnl_Please_Wait;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_WebReport));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			brw_Report = new System.Windows.Forms.WebBrowser();
			pnl_Please_Wait = new System.Windows.Forms.Panel();
			SuspendLayout();
			// 
			// brw_Report
			// 
			brw_Report.AllowWebBrowserDrop = true;
			brw_Report.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			brw_Report.Location = new System.Drawing.Point(44, 18);
			brw_Report.Name = "brw_Report";
			brw_Report.Size = new System.Drawing.Size(95, 82);
			brw_Report.TabIndex = 1;
			brw_Report.Visible = false;
			// 
			// pnl_Please_Wait
			// 
			pnl_Please_Wait.AllowDrop = true;
			pnl_Please_Wait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Please_Wait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Please_Wait.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Please_Wait.Location = new System.Drawing.Point(2, 3);
			pnl_Please_Wait.Name = "pnl_Please_Wait";
			pnl_Please_Wait.Size = new System.Drawing.Size(521, 113);
			pnl_Please_Wait.TabIndex = 0;
			// 
			// frm_WebReport
			// 
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			ClientSize = new System.Drawing.Size(525, 118);
			ControlBox = false;
			Controls.Add(brw_Report);
			Controls.Add(pnl_Please_Wait);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Location = new System.Drawing.Point(484, 347);
			MaximizeBox = true;
			MinimizeBox = true;
			Name = "frm_WebReport";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			Text = "Web Report";
			Activated += new System.EventHandler(Form_Activated);
			Closed += new System.EventHandler(Form_Closed);
			ResumeLayout(false);
			PerformLayout();
		}
		void ReLoadForm(bool addEvents) => Form_Initialize();

		#endregion
	}
}