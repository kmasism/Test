
namespace JETNET_Homebase
{
	partial class frm_JETNETiQSurvey
	{

		#region "Upgrade Support "
		private static frm_JETNETiQSurvey m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_JETNETiQSurvey DefInstance
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
		public static frm_JETNETiQSurvey CreateInstance()
		{
			frm_JETNETiQSurvey theInstance = new frm_JETNETiQSurvey();
			theInstance.Form_Load();
			return theInstance;
		}
		private string[] visualControls = new string[]{"components", "ToolTipMain", "_opJIQLanguage_7", "_opJIQLanguage_6", "_opJIQLanguage_5", "_opJIQLanguage_4", "_opJIQLanguage_3", "cmdSend", "_opJIQLanguage_2", "_opJIQLanguage_1", "_opJIQLanguage_0", "lblSendingTo", "frmLanguage", "cmdCancel", "opJIQLanguage", "commandButtonHelper1", "optionButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		private System.Windows.Forms.RadioButton _opJIQLanguage_7;
		private System.Windows.Forms.RadioButton _opJIQLanguage_6;
		private System.Windows.Forms.RadioButton _opJIQLanguage_5;
		private System.Windows.Forms.RadioButton _opJIQLanguage_4;
		private System.Windows.Forms.RadioButton _opJIQLanguage_3;
		public System.Windows.Forms.Button cmdSend;
		private System.Windows.Forms.RadioButton _opJIQLanguage_2;
		private System.Windows.Forms.RadioButton _opJIQLanguage_1;
		private System.Windows.Forms.RadioButton _opJIQLanguage_0;
		public System.Windows.Forms.Label lblSendingTo;
		public System.Windows.Forms.GroupBox frmLanguage;
		public System.Windows.Forms.Button cmdCancel;
		public System.Windows.Forms.RadioButton[] opJIQLanguage = new System.Windows.Forms.RadioButton[8];
		public UpgradeHelpers.Gui.Controls.CommandButtonHelper commandButtonHelper1;
		public UpgradeHelpers.Gui.Controls.OptionButtonHelper optionButtonHelper1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_JETNETiQSurvey));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			frmLanguage = new System.Windows.Forms.GroupBox();
			_opJIQLanguage_7 = new System.Windows.Forms.RadioButton();
			_opJIQLanguage_6 = new System.Windows.Forms.RadioButton();
			_opJIQLanguage_5 = new System.Windows.Forms.RadioButton();
			_opJIQLanguage_4 = new System.Windows.Forms.RadioButton();
			_opJIQLanguage_3 = new System.Windows.Forms.RadioButton();
			cmdSend = new System.Windows.Forms.Button();
			_opJIQLanguage_2 = new System.Windows.Forms.RadioButton();
			_opJIQLanguage_1 = new System.Windows.Forms.RadioButton();
			_opJIQLanguage_0 = new System.Windows.Forms.RadioButton();
			lblSendingTo = new System.Windows.Forms.Label();
			cmdCancel = new System.Windows.Forms.Button();
			frmLanguage.SuspendLayout();
			SuspendLayout();
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
			optionButtonHelper1 = new UpgradeHelpers.Gui.Controls.OptionButtonHelper(components);
			// 
			// frmLanguage
			// 
			frmLanguage.AllowDrop = true;
			frmLanguage.BackColor = System.Drawing.SystemColors.Control;
			frmLanguage.Controls.Add(_opJIQLanguage_7);
			frmLanguage.Controls.Add(_opJIQLanguage_6);
			frmLanguage.Controls.Add(_opJIQLanguage_5);
			frmLanguage.Controls.Add(_opJIQLanguage_4);
			frmLanguage.Controls.Add(_opJIQLanguage_3);
			frmLanguage.Controls.Add(cmdSend);
			frmLanguage.Controls.Add(_opJIQLanguage_2);
			frmLanguage.Controls.Add(_opJIQLanguage_1);
			frmLanguage.Controls.Add(_opJIQLanguage_0);
			frmLanguage.Controls.Add(lblSendingTo);
			frmLanguage.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmLanguage.Enabled = true;
			frmLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmLanguage.ForeColor = System.Drawing.SystemColors.ControlText;
			frmLanguage.Location = new System.Drawing.Point(24, 24);
			frmLanguage.Name = "frmLanguage";
			frmLanguage.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmLanguage.Size = new System.Drawing.Size(382, 196);
			frmLanguage.TabIndex = 6;
			frmLanguage.Text = "JETNET iQ - EMail Language";
			frmLanguage.Visible = true;
			// 
			// _opJIQLanguage_7
			// 
			_opJIQLanguage_7.AllowDrop = true;
			_opJIQLanguage_7.BackColor = System.Drawing.SystemColors.Control;
			_opJIQLanguage_7.CausesValidation = true;
			_opJIQLanguage_7.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opJIQLanguage_7.Checked = false;
			_opJIQLanguage_7.Enabled = true;
			_opJIQLanguage_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_opJIQLanguage_7.ForeColor = System.Drawing.SystemColors.ControlText;
			_opJIQLanguage_7.Location = new System.Drawing.Point(274, 57);
			_opJIQLanguage_7.Name = "_opJIQLanguage_7";
			_opJIQLanguage_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_opJIQLanguage_7.Size = new System.Drawing.Size(85, 13);
			_opJIQLanguage_7.TabIndex = 11;
			_opJIQLanguage_7.TabStop = true;
			_opJIQLanguage_7.Tag = "Chinese";
			_opJIQLanguage_7.Text = "Chinese";
			_opJIQLanguage_7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opJIQLanguage_7.Visible = true;
			// 
			// _opJIQLanguage_6
			// 
			_opJIQLanguage_6.AllowDrop = true;
			_opJIQLanguage_6.BackColor = System.Drawing.SystemColors.Control;
			_opJIQLanguage_6.CausesValidation = true;
			_opJIQLanguage_6.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opJIQLanguage_6.Checked = false;
			_opJIQLanguage_6.Enabled = false;
			_opJIQLanguage_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_opJIQLanguage_6.ForeColor = System.Drawing.SystemColors.ControlText;
			_opJIQLanguage_6.Location = new System.Drawing.Point(276, 27);
			_opJIQLanguage_6.Name = "_opJIQLanguage_6";
			_opJIQLanguage_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_opJIQLanguage_6.Size = new System.Drawing.Size(85, 13);
			_opJIQLanguage_6.TabIndex = 9;
			_opJIQLanguage_6.TabStop = true;
			_opJIQLanguage_6.Tag = "Arabic";
			_opJIQLanguage_6.Text = "Arabic";
			_opJIQLanguage_6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opJIQLanguage_6.Visible = true;
			// 
			// _opJIQLanguage_5
			// 
			_opJIQLanguage_5.AllowDrop = true;
			_opJIQLanguage_5.BackColor = System.Drawing.SystemColors.Control;
			_opJIQLanguage_5.CausesValidation = true;
			_opJIQLanguage_5.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opJIQLanguage_5.Checked = false;
			_opJIQLanguage_5.Enabled = false;
			_opJIQLanguage_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_opJIQLanguage_5.ForeColor = System.Drawing.SystemColors.ControlText;
			_opJIQLanguage_5.Location = new System.Drawing.Point(141, 84);
			_opJIQLanguage_5.Name = "_opJIQLanguage_5";
			_opJIQLanguage_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_opJIQLanguage_5.Size = new System.Drawing.Size(85, 13);
			_opJIQLanguage_5.TabIndex = 8;
			_opJIQLanguage_5.TabStop = true;
			_opJIQLanguage_5.Tag = "Russian";
			_opJIQLanguage_5.Text = "Russian";
			_opJIQLanguage_5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opJIQLanguage_5.Visible = true;
			// 
			// _opJIQLanguage_4
			// 
			_opJIQLanguage_4.AllowDrop = true;
			_opJIQLanguage_4.BackColor = System.Drawing.SystemColors.Control;
			_opJIQLanguage_4.CausesValidation = true;
			_opJIQLanguage_4.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opJIQLanguage_4.Checked = false;
			_opJIQLanguage_4.Enabled = true;
			_opJIQLanguage_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_opJIQLanguage_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_opJIQLanguage_4.Location = new System.Drawing.Point(141, 57);
			_opJIQLanguage_4.Name = "_opJIQLanguage_4";
			_opJIQLanguage_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_opJIQLanguage_4.Size = new System.Drawing.Size(85, 13);
			_opJIQLanguage_4.TabIndex = 5;
			_opJIQLanguage_4.TabStop = true;
			_opJIQLanguage_4.Tag = "Portguese";
			_opJIQLanguage_4.Text = "Portguese";
			_opJIQLanguage_4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opJIQLanguage_4.Visible = true;
			// 
			// _opJIQLanguage_3
			// 
			_opJIQLanguage_3.AllowDrop = true;
			_opJIQLanguage_3.BackColor = System.Drawing.SystemColors.Control;
			_opJIQLanguage_3.CausesValidation = true;
			_opJIQLanguage_3.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opJIQLanguage_3.Checked = false;
			_opJIQLanguage_3.Enabled = true;
			_opJIQLanguage_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_opJIQLanguage_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_opJIQLanguage_3.Location = new System.Drawing.Point(141, 27);
			_opJIQLanguage_3.Name = "_opJIQLanguage_3";
			_opJIQLanguage_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_opJIQLanguage_3.Size = new System.Drawing.Size(85, 13);
			_opJIQLanguage_3.TabIndex = 4;
			_opJIQLanguage_3.TabStop = true;
			_opJIQLanguage_3.Tag = "Spanish";
			_opJIQLanguage_3.Text = "Spanish";
			_opJIQLanguage_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opJIQLanguage_3.Visible = true;
			// 
			// cmdSend
			// 
			cmdSend.AllowDrop = true;
			cmdSend.BackColor = System.Drawing.SystemColors.Control;
			cmdSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdSend.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdSend.Location = new System.Drawing.Point(276, 81);
			cmdSend.Name = "cmdSend";
			cmdSend.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdSend.Size = new System.Drawing.Size(79, 25);
			cmdSend.TabIndex = 0;
			cmdSend.Text = "Send &EMail";
			cmdSend.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdSend.UseVisualStyleBackColor = false;
			cmdSend.Click += new System.EventHandler(cmdSend_Click);
			// 
			// _opJIQLanguage_2
			// 
			_opJIQLanguage_2.AllowDrop = true;
			_opJIQLanguage_2.BackColor = System.Drawing.SystemColors.Control;
			_opJIQLanguage_2.CausesValidation = true;
			_opJIQLanguage_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opJIQLanguage_2.Checked = false;
			_opJIQLanguage_2.Enabled = false;
			_opJIQLanguage_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_opJIQLanguage_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_opJIQLanguage_2.Location = new System.Drawing.Point(30, 80);
			_opJIQLanguage_2.Name = "_opJIQLanguage_2";
			_opJIQLanguage_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_opJIQLanguage_2.Size = new System.Drawing.Size(85, 13);
			_opJIQLanguage_2.TabIndex = 3;
			_opJIQLanguage_2.TabStop = true;
			_opJIQLanguage_2.Tag = "German";
			_opJIQLanguage_2.Text = "German";
			_opJIQLanguage_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opJIQLanguage_2.Visible = true;
			// 
			// _opJIQLanguage_1
			// 
			_opJIQLanguage_1.AllowDrop = true;
			_opJIQLanguage_1.BackColor = System.Drawing.SystemColors.Control;
			_opJIQLanguage_1.CausesValidation = true;
			_opJIQLanguage_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opJIQLanguage_1.Checked = false;
			_opJIQLanguage_1.Enabled = true;
			_opJIQLanguage_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_opJIQLanguage_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_opJIQLanguage_1.Location = new System.Drawing.Point(30, 54);
			_opJIQLanguage_1.Name = "_opJIQLanguage_1";
			_opJIQLanguage_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_opJIQLanguage_1.Size = new System.Drawing.Size(85, 13);
			_opJIQLanguage_1.TabIndex = 2;
			_opJIQLanguage_1.TabStop = true;
			_opJIQLanguage_1.Tag = "French";
			_opJIQLanguage_1.Text = "French";
			_opJIQLanguage_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opJIQLanguage_1.Visible = true;
			// 
			// _opJIQLanguage_0
			// 
			_opJIQLanguage_0.AllowDrop = true;
			_opJIQLanguage_0.BackColor = System.Drawing.SystemColors.Control;
			_opJIQLanguage_0.CausesValidation = true;
			_opJIQLanguage_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opJIQLanguage_0.Checked = true;
			_opJIQLanguage_0.Enabled = true;
			_opJIQLanguage_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_opJIQLanguage_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_opJIQLanguage_0.Location = new System.Drawing.Point(30, 27);
			_opJIQLanguage_0.Name = "_opJIQLanguage_0";
			_opJIQLanguage_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_opJIQLanguage_0.Size = new System.Drawing.Size(85, 13);
			_opJIQLanguage_0.TabIndex = 1;
			_opJIQLanguage_0.TabStop = true;
			_opJIQLanguage_0.Tag = "English";
			_opJIQLanguage_0.Text = "English";
			_opJIQLanguage_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opJIQLanguage_0.Visible = true;
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
			lblSendingTo.TabIndex = 10;
			lblSendingTo.Text = "Sending To";
			lblSendingTo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// cmdCancel
			// 
			cmdCancel.AllowDrop = true;
			cmdCancel.BackColor = System.Drawing.SystemColors.Control;
			cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdCancel.Location = new System.Drawing.Point(180, 231);
			cmdCancel.Name = "cmdCancel";
			cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdCancel.Size = new System.Drawing.Size(79, 25);
			cmdCancel.TabIndex = 7;
			cmdCancel.Text = "&Cancel";
			cmdCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdCancel.UseVisualStyleBackColor = false;
			cmdCancel.Click += new System.EventHandler(cmdCancel_Click);
			// 
			// frm_JETNETiQSurvey
			// 
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			ClientSize = new System.Drawing.Size(426, 263);
			Controls.Add(frmLanguage);
			Controls.Add(cmdCancel);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Location = new System.Drawing.Point(413, 147);
			MaximizeBox = true;
			MinimizeBox = true;
			Name = "frm_JETNETiQSurvey";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			Text = "JETNET iQ - Send EMail";
			commandButtonHelper1.SetStyle(cmdSend, 0);
			commandButtonHelper1.SetStyle(cmdCancel, 0);
			optionButtonHelper1.SetStyle(_opJIQLanguage_7, 0);
			optionButtonHelper1.SetStyle(_opJIQLanguage_6, 0);
			optionButtonHelper1.SetStyle(_opJIQLanguage_5, 0);
			optionButtonHelper1.SetStyle(_opJIQLanguage_4, 0);
			optionButtonHelper1.SetStyle(_opJIQLanguage_3, 0);
			optionButtonHelper1.SetStyle(_opJIQLanguage_2, 0);
			optionButtonHelper1.SetStyle(_opJIQLanguage_1, 0);
			optionButtonHelper1.SetStyle(_opJIQLanguage_0, 0);
			Activated += new System.EventHandler(frm_JETNETiQSurvey_Activated);
			Closed += new System.EventHandler(Form_Closed);
			frmLanguage.ResumeLayout(false);
			frmLanguage.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
		void ReLoadForm(bool addEvents) => InitializeopJIQLanguage();

		void InitializeopJIQLanguage()
		{
			opJIQLanguage = new System.Windows.Forms.RadioButton[8];
			opJIQLanguage[7] = _opJIQLanguage_7;
			opJIQLanguage[6] = _opJIQLanguage_6;
			opJIQLanguage[5] = _opJIQLanguage_5;
			opJIQLanguage[4] = _opJIQLanguage_4;
			opJIQLanguage[3] = _opJIQLanguage_3;
			opJIQLanguage[2] = _opJIQLanguage_2;
			opJIQLanguage[1] = _opJIQLanguage_1;
			opJIQLanguage[0] = _opJIQLanguage_0;
		}
		#endregion
	}
}