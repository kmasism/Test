
namespace JETNET_Homebase
{
	partial class frm_ProjectSurvey
	{

		#region "Upgrade Support "
		private static frm_ProjectSurvey m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_ProjectSurvey DefInstance
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
		public static frm_ProjectSurvey CreateInstance()
		{
			frm_ProjectSurvey theInstance = new frm_ProjectSurvey();
			theInstance.Form_Load();
			return theInstance;
		}
		private string[] visualControls = new string[]{"components", "ToolTipMain", "cmdCancel", "cmbProjectSurvey", "cmdSend", "lblSurveyName", "lblSendingTo", "frmLanguage", "commandButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Button cmdCancel;
		public System.Windows.Forms.ComboBox cmbProjectSurvey;
		public System.Windows.Forms.Button cmdSend;
		public System.Windows.Forms.Label lblSurveyName;
		public System.Windows.Forms.Label lblSendingTo;
		public System.Windows.Forms.GroupBox frmLanguage;
		public UpgradeHelpers.Gui.Controls.CommandButtonHelper commandButtonHelper1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ProjectSurvey));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			cmdCancel = new System.Windows.Forms.Button();
			frmLanguage = new System.Windows.Forms.GroupBox();
			cmbProjectSurvey = new System.Windows.Forms.ComboBox();
			cmdSend = new System.Windows.Forms.Button();
			lblSurveyName = new System.Windows.Forms.Label();
			lblSendingTo = new System.Windows.Forms.Label();
			frmLanguage.SuspendLayout();
			SuspendLayout();
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
			// 
			// cmdCancel
			// 
			cmdCancel.AllowDrop = true;
			cmdCancel.BackColor = System.Drawing.SystemColors.Control;
			cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdCancel.Location = new System.Drawing.Point(156, 210);
			cmdCancel.Name = "cmdCancel";
			cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdCancel.Size = new System.Drawing.Size(79, 25);
			cmdCancel.TabIndex = 3;
			cmdCancel.Text = "&Cancel";
			cmdCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdCancel.UseVisualStyleBackColor = false;
			cmdCancel.Click += new System.EventHandler(cmdCancel_Click);
			// 
			// frmLanguage
			// 
			frmLanguage.AllowDrop = true;
			frmLanguage.BackColor = System.Drawing.SystemColors.Control;
			frmLanguage.Controls.Add(cmbProjectSurvey);
			frmLanguage.Controls.Add(cmdSend);
			frmLanguage.Controls.Add(lblSurveyName);
			frmLanguage.Controls.Add(lblSendingTo);
			frmLanguage.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmLanguage.Enabled = true;
			frmLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmLanguage.ForeColor = System.Drawing.SystemColors.ControlText;
			frmLanguage.Location = new System.Drawing.Point(8, 8);
			frmLanguage.Name = "frmLanguage";
			frmLanguage.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmLanguage.Size = new System.Drawing.Size(382, 196);
			frmLanguage.TabIndex = 0;
			frmLanguage.Text = "Project Survey ";
			frmLanguage.Visible = true;
			// 
			// cmbProjectSurvey
			// 
			cmbProjectSurvey.AllowDrop = true;
			cmbProjectSurvey.BackColor = System.Drawing.SystemColors.Window;
			cmbProjectSurvey.CausesValidation = true;
			cmbProjectSurvey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cmbProjectSurvey.Enabled = true;
			cmbProjectSurvey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmbProjectSurvey.ForeColor = System.Drawing.SystemColors.WindowText;
			cmbProjectSurvey.IntegralHeight = true;
			cmbProjectSurvey.Location = new System.Drawing.Point(94, 20);
			cmbProjectSurvey.Name = "cmbProjectSurvey";
			cmbProjectSurvey.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmbProjectSurvey.Size = new System.Drawing.Size(279, 21);
			cmbProjectSurvey.Sorted = false;
			cmbProjectSurvey.TabIndex = 5;
			cmbProjectSurvey.TabStop = true;
			cmbProjectSurvey.Visible = true;
			// 
			// cmdSend
			// 
			cmdSend.AllowDrop = true;
			cmdSend.BackColor = System.Drawing.SystemColors.Control;
			cmdSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdSend.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdSend.Location = new System.Drawing.Point(138, 82);
			cmdSend.Name = "cmdSend";
			cmdSend.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdSend.Size = new System.Drawing.Size(79, 25);
			cmdSend.TabIndex = 1;
			cmdSend.Text = "Send &EMail";
			cmdSend.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdSend.UseVisualStyleBackColor = false;
			cmdSend.Click += new System.EventHandler(cmdSend_Click);
			// 
			// lblSurveyName
			// 
			lblSurveyName.AllowDrop = true;
			lblSurveyName.BackColor = System.Drawing.SystemColors.Control;
			lblSurveyName.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblSurveyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblSurveyName.ForeColor = System.Drawing.SystemColors.ControlText;
			lblSurveyName.Location = new System.Drawing.Point(8, 22);
			lblSurveyName.MinimumSize = new System.Drawing.Size(81, 17);
			lblSurveyName.Name = "lblSurveyName";
			lblSurveyName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblSurveyName.Size = new System.Drawing.Size(81, 17);
			lblSurveyName.TabIndex = 4;
			lblSurveyName.Text = "Select a Survey";
			// 
			// lblSendingTo
			// 
			lblSendingTo.AllowDrop = true;
			lblSendingTo.BackColor = System.Drawing.SystemColors.Control;
			lblSendingTo.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblSendingTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblSendingTo.ForeColor = System.Drawing.SystemColors.ControlText;
			lblSendingTo.Location = new System.Drawing.Point(9, 108);
			lblSendingTo.MinimumSize = new System.Drawing.Size(358, 79);
			lblSendingTo.Name = "lblSendingTo";
			lblSendingTo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblSendingTo.Size = new System.Drawing.Size(358, 79);
			lblSendingTo.TabIndex = 2;
			lblSendingTo.Text = "Sending To";
			lblSendingTo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// frm_ProjectSurvey
			// 
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			ClientSize = new System.Drawing.Size(396, 243);
			Controls.Add(cmdCancel);
			Controls.Add(frmLanguage);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Location = new System.Drawing.Point(471, 466);
			MaximizeBox = true;
			MinimizeBox = true;
			Name = "frm_ProjectSurvey";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			Text = "Project Survey - Send EMail";
			commandButtonHelper1.SetStyle(cmdCancel, 0);
			commandButtonHelper1.SetStyle(cmdSend, 0);
			ToolTipMain.SetToolTip(cmdCancel, "Click To Cancel and Close Form");
			ToolTipMain.SetToolTip(cmdSend, "Click To Send EMail");
			Activated += new System.EventHandler(frm_ProjectSurvey_Activated);
			Closed += new System.EventHandler(Form_Closed);
			frmLanguage.ResumeLayout(false);
			frmLanguage.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
		#endregion
	}
}