
namespace JETNET_Homebase
{
	partial class frm_AttachFAADocToCompany
	{

		#region "Upgrade Support "
		private static frm_AttachFAADocToCompany m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_AttachFAADocToCompany DefInstance
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
		public static frm_AttachFAADocToCompany CreateInstance()
		{
			frm_AttachFAADocToCompany theInstance = new frm_AttachFAADocToCompany();
			return theInstance;
		}
		private string[] visualControls = new string[]{"components", "ToolTipMain", "txtCompId", "cmdClose", "cmdAttach", "lblFAADocFileName", "lblCompany", "lblNotice", "lblCompId", "commandButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtCompId;
		public System.Windows.Forms.Button cmdClose;
		public System.Windows.Forms.Button cmdAttach;
		public System.Windows.Forms.Label lblFAADocFileName;
		public System.Windows.Forms.Label lblCompany;
		public System.Windows.Forms.Label lblNotice;
		public System.Windows.Forms.Label lblCompId;
		public UpgradeHelpers.Gui.Controls.CommandButtonHelper commandButtonHelper1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_AttachFAADocToCompany));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			txtCompId = new System.Windows.Forms.TextBox();
			cmdClose = new System.Windows.Forms.Button();
			cmdAttach = new System.Windows.Forms.Button();
			lblFAADocFileName = new System.Windows.Forms.Label();
			lblCompany = new System.Windows.Forms.Label();
			lblNotice = new System.Windows.Forms.Label();
			lblCompId = new System.Windows.Forms.Label();
			SuspendLayout();
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
			// 
			// txtCompId
			// 
			txtCompId.AcceptsReturn = true;
			txtCompId.AllowDrop = true;
			txtCompId.BackColor = System.Drawing.SystemColors.Window;
			txtCompId.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtCompId.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtCompId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtCompId.ForeColor = System.Drawing.SystemColors.WindowText;
			txtCompId.Location = new System.Drawing.Point(180, 14);
			txtCompId.MaxLength = 0;
			txtCompId.Name = "txtCompId";
			txtCompId.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtCompId.Size = new System.Drawing.Size(91, 19);
			txtCompId.TabIndex = 0;
			txtCompId.Leave += new System.EventHandler(txtCompId_Leave);
			// 
			// cmdClose
			// 
			cmdClose.AllowDrop = true;
			cmdClose.BackColor = System.Drawing.SystemColors.Control;
			cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdClose.Location = new System.Drawing.Point(304, 190);
			cmdClose.Name = "cmdClose";
			cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdClose.Size = new System.Drawing.Size(69, 29);
			cmdClose.TabIndex = 3;
			cmdClose.Text = "Close";
			cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdClose.UseVisualStyleBackColor = false;
			cmdClose.Click += new System.EventHandler(cmdClose_Click);
			// 
			// cmdAttach
			// 
			cmdAttach.AllowDrop = true;
			cmdAttach.BackColor = System.Drawing.SystemColors.Control;
			cmdAttach.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdAttach.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdAttach.Location = new System.Drawing.Point(40, 190);
			cmdAttach.Name = "cmdAttach";
			cmdAttach.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdAttach.Size = new System.Drawing.Size(69, 29);
			cmdAttach.TabIndex = 1;
			cmdAttach.Text = "Attach";
			cmdAttach.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdAttach.UseVisualStyleBackColor = false;
			cmdAttach.Click += new System.EventHandler(cmdAttach_Click);
			// 
			// lblFAADocFileName
			// 
			lblFAADocFileName.AllowDrop = true;
			lblFAADocFileName.BackColor = System.Drawing.SystemColors.Control;
			lblFAADocFileName.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblFAADocFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblFAADocFileName.ForeColor = System.Drawing.SystemColors.ControlText;
			lblFAADocFileName.Location = new System.Drawing.Point(6, 46);
			lblFAADocFileName.MinimumSize = new System.Drawing.Size(397, 13);
			lblFAADocFileName.Name = "lblFAADocFileName";
			lblFAADocFileName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblFAADocFileName.Size = new System.Drawing.Size(397, 13);
			lblFAADocFileName.TabIndex = 6;
			lblFAADocFileName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lblCompany
			// 
			lblCompany.AllowDrop = true;
			lblCompany.BackColor = System.Drawing.SystemColors.Control;
			lblCompany.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			lblCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblCompany.ForeColor = System.Drawing.SystemColors.ControlText;
			lblCompany.Location = new System.Drawing.Point(10, 96);
			lblCompany.MinimumSize = new System.Drawing.Size(391, 85);
			lblCompany.Name = "lblCompany";
			lblCompany.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblCompany.Size = new System.Drawing.Size(391, 85);
			lblCompany.TabIndex = 5;
			// 
			// lblNotice
			// 
			lblNotice.AllowDrop = true;
			lblNotice.BackColor = System.Drawing.SystemColors.Control;
			lblNotice.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblNotice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblNotice.ForeColor = System.Drawing.SystemColors.ControlText;
			lblNotice.Location = new System.Drawing.Point(52, 72);
			lblNotice.MinimumSize = new System.Drawing.Size(287, 13);
			lblNotice.Name = "lblNotice";
			lblNotice.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblNotice.Size = new System.Drawing.Size(287, 13);
			lblNotice.TabIndex = 4;
			lblNotice.Text = "Attach FAA Document To The Following Company Record";
			lblNotice.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lblCompId
			// 
			lblCompId.AllowDrop = true;
			lblCompId.BackColor = System.Drawing.SystemColors.Control;
			lblCompId.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblCompId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblCompId.ForeColor = System.Drawing.SystemColors.ControlText;
			lblCompId.Location = new System.Drawing.Point(90, 18);
			lblCompId.MinimumSize = new System.Drawing.Size(69, 15);
			lblCompId.Name = "lblCompId";
			lblCompId.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblCompId.Size = new System.Drawing.Size(69, 15);
			lblCompId.TabIndex = 2;
			lblCompId.Text = "Company Id";
			// 
			// frm_AttachFAADocToCompany
			// 
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			ClientSize = new System.Drawing.Size(412, 222);
			Controls.Add(txtCompId);
			Controls.Add(cmdClose);
			Controls.Add(cmdAttach);
			Controls.Add(lblFAADocFileName);
			Controls.Add(lblCompany);
			Controls.Add(lblNotice);
			Controls.Add(lblCompId);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Location = new System.Drawing.Point(616, 508);
			MaximizeBox = true;
			MinimizeBox = true;
			Name = "frm_AttachFAADocToCompany";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			Text = "Attach FAA Doc To Company";
			commandButtonHelper1.SetStyle(cmdClose, 0);
			commandButtonHelper1.SetStyle(cmdAttach, 0);
			ToolTipMain.SetToolTip(cmdClose, "Close Form");
			ToolTipMain.SetToolTip(cmdAttach, "Open Company Document Form To Attach FAA Document To");
			Activated += new System.EventHandler(frm_AttachFAADocToCompany_Activated);
			Closed += new System.EventHandler(Form_Closed);
			ResumeLayout(false);
			PerformLayout();
		}
		#endregion
	}
}