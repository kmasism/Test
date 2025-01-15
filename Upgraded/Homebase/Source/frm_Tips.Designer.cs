
namespace JETNET_Homebase
{
	partial class frm_Tips
	{

		#region "Upgrade Support "
		private static frm_Tips m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_Tips DefInstance
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
		public static frm_Tips CreateInstance()
		{
			frm_Tips theInstance = new frm_Tips();
			theInstance.Form_Load();
			return theInstance;
		}
		private string[] visualControls = new string[]{"components", "ToolTipMain", "cmdClose", "lblCaption2", "lblCaption1", "commandButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Button cmdClose;
		public System.Windows.Forms.Label lblCaption2;
		public System.Windows.Forms.Label lblCaption1;
		public UpgradeHelpers.Gui.Controls.CommandButtonHelper commandButtonHelper1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Tips));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			cmdClose = new System.Windows.Forms.Button();
			lblCaption2 = new System.Windows.Forms.Label();
			lblCaption1 = new System.Windows.Forms.Label();
			SuspendLayout();
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
			// 
			// cmdClose
			// 
			cmdClose.AllowDrop = true;
			cmdClose.BackColor = System.Drawing.SystemColors.Control;
			cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdClose.Location = new System.Drawing.Point(1, 588);
			cmdClose.Name = "cmdClose";
			cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdClose.Size = new System.Drawing.Size(55, 20);
			cmdClose.TabIndex = 0;
			cmdClose.Text = "Close";
			cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdClose.UseVisualStyleBackColor = false;
			cmdClose.Click += new System.EventHandler(cmdClose_Click);
			// 
			// lblCaption2
			// 
			lblCaption2.AllowDrop = true;
			lblCaption2.BackColor = System.Drawing.Color.Transparent;
			lblCaption2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblCaption2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblCaption2.ForeColor = System.Drawing.Color.Maroon;
			lblCaption2.Location = new System.Drawing.Point(6, 274);
			lblCaption2.MinimumSize = new System.Drawing.Size(722, 310);
			lblCaption2.Name = "lblCaption2";
			lblCaption2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblCaption2.Size = new System.Drawing.Size(722, 310);
			lblCaption2.TabIndex = 2;
			lblCaption2.Text = "DAM - Damage To Aircraft Description: Ask the following question on entry";
			lblCaption2.Visible = false;
			// 
			// lblCaption1
			// 
			lblCaption1.AllowDrop = true;
			lblCaption1.BackColor = System.Drawing.Color.Transparent;
			lblCaption1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblCaption1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblCaption1.ForeColor = System.Drawing.Color.Maroon;
			lblCaption1.Location = new System.Drawing.Point(6, 6);
			lblCaption1.MinimumSize = new System.Drawing.Size(722, 257);
			lblCaption1.Name = "lblCaption1";
			lblCaption1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblCaption1.Size = new System.Drawing.Size(722, 257);
			lblCaption1.TabIndex = 1;
			lblCaption1.Text = "DAM - Damage To Aircraft Description: Ask the following question on entry";
			lblCaption1.Visible = false;
			// 
			// frm_Tips
			// 
			AcceptButton = cmdClose;
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			CancelButton = cmdClose;
			ClientSize = new System.Drawing.Size(731, 610);
			Controls.Add(cmdClose);
			Controls.Add(lblCaption2);
			Controls.Add(lblCaption1);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			Location = new System.Drawing.Point(519, 175);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "frm_Tips";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			ShowInTaskbar = false;
			Text = "Tips";
			commandButtonHelper1.SetStyle(cmdClose, 0);
			Activated += new System.EventHandler(Form_Activated);
			Closed += new System.EventHandler(Form_Closed);
			ResumeLayout(false);
			PerformLayout();
		}
		#endregion
	}
}