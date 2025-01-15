
namespace JETNET_Homebase
{
	partial class frm_Progress_Bar
	{

		#region "Upgrade Support "
		private static frm_Progress_Bar m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_Progress_Bar DefInstance
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
		public static frm_Progress_Bar CreateInstance()
		{
			frm_Progress_Bar theInstance = new frm_Progress_Bar();
			return theInstance;
		}
		private string[] visualControls = new string[]{"components", "ToolTipMain", "cmdStop", "pbBar", "lblStatus", "commandButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Button cmdStop;
		public System.Windows.Forms.ProgressBar pbBar;
		public System.Windows.Forms.Label lblStatus;
		public UpgradeHelpers.Gui.Controls.CommandButtonHelper commandButtonHelper1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Progress_Bar));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			cmdStop = new System.Windows.Forms.Button();
			pbBar = new System.Windows.Forms.ProgressBar();
			lblStatus = new System.Windows.Forms.Label();
			SuspendLayout();
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
			// 
			// cmdStop
			// 
			cmdStop.AllowDrop = true;
			cmdStop.BackColor = System.Drawing.SystemColors.Control;
			cmdStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdStop.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdStop.Location = new System.Drawing.Point(348, 80);
			cmdStop.Name = "cmdStop";
			cmdStop.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdStop.Size = new System.Drawing.Size(89, 27);
			cmdStop.TabIndex = 2;
			cmdStop.Text = "Stop";
			cmdStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdStop.UseVisualStyleBackColor = false;
			cmdStop.Click += new System.EventHandler(cmdStop_Click);
			// 
			// pbBar
			// 
			pbBar.AllowDrop = true;
			pbBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pbBar.Location = new System.Drawing.Point(22, 50);
			pbBar.Name = "pbBar";
			pbBar.Size = new System.Drawing.Size(735, 21);
			pbBar.TabIndex = 1;
			// 
			// lblStatus
			// 
			lblStatus.AllowDrop = true;
			lblStatus.BackColor = System.Drawing.SystemColors.Control;
			lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblStatus.ForeColor = System.Drawing.SystemColors.ControlText;
			lblStatus.Location = new System.Drawing.Point(22, 16);
			lblStatus.MinimumSize = new System.Drawing.Size(735, 23);
			lblStatus.Name = "lblStatus";
			lblStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblStatus.Size = new System.Drawing.Size(735, 23);
			lblStatus.TabIndex = 0;
			lblStatus.Text = "Status";
			lblStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// frm_Progress_Bar
			// 
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			ClientSize = new System.Drawing.Size(772, 119);
			Controls.Add(cmdStop);
			Controls.Add(pbBar);
			Controls.Add(lblStatus);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Location = new System.Drawing.Point(455, 293);
			MaximizeBox = true;
			MinimizeBox = true;
			Name = "frm_Progress_Bar";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			Text = "Progress Bar";
			commandButtonHelper1.SetStyle(cmdStop, 0);
			ToolTipMain.SetToolTip(cmdStop, "Click To Stop Process");
			Activated += new System.EventHandler(frm_Progress_Bar_Activated);
			Closed += new System.EventHandler(Form_Closed);
			ResumeLayout(false);
			PerformLayout();
		}
		void ReLoadForm(bool addEvents) => Form_Initialize();

		#endregion
	}
}