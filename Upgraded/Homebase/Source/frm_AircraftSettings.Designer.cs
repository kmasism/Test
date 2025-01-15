
namespace JETNET_Homebase
{
	partial class frm_AircraftSettings
	{

		#region "Upgrade Support "
		private static frm_AircraftSettings m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_AircraftSettings DefInstance
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
		public static frm_AircraftSettings CreateInstance()
		{
			frm_AircraftSettings theInstance = new frm_AircraftSettings();
			theInstance.Form_Load();
			return theInstance;
		}
		private string[] visualControls = new string[]{"components", "ToolTipMain", "opt_avail_leave", "opt_avail_clear", "Label1", "SSPanel1", "cmd_Cancel", "cmd_OK", "opt_contact_clear", "opt_contact_leave", "Label7", "SSPanel2", "opt_base_leave", "opt_base_clear", "Label2", "SSPanel3", "opt_spec_clear", "opt_spec_leave", "Label4", "Label3", "SSPanel4", "opt_New", "opt_Used", "Label5", "pnl_newused", "frame_settings", "commandButtonHelper1", "optionButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.RadioButton opt_avail_leave;
		public System.Windows.Forms.RadioButton opt_avail_clear;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Panel SSPanel1;
		public System.Windows.Forms.Button cmd_Cancel;
		public System.Windows.Forms.Button cmd_OK;
		public System.Windows.Forms.RadioButton opt_contact_clear;
		public System.Windows.Forms.RadioButton opt_contact_leave;
		public System.Windows.Forms.Label Label7;
		public System.Windows.Forms.Panel SSPanel2;
		public System.Windows.Forms.RadioButton opt_base_leave;
		public System.Windows.Forms.RadioButton opt_base_clear;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Panel SSPanel3;
		public System.Windows.Forms.RadioButton opt_spec_clear;
		public System.Windows.Forms.RadioButton opt_spec_leave;
		public System.Windows.Forms.Label Label4;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.Panel SSPanel4;
		public System.Windows.Forms.RadioButton opt_New;
		public System.Windows.Forms.RadioButton opt_Used;
		public System.Windows.Forms.Label Label5;
		public System.Windows.Forms.Panel pnl_newused;
		public System.Windows.Forms.GroupBox frame_settings;
		public UpgradeHelpers.Gui.Controls.CommandButtonHelper commandButtonHelper1;
		public UpgradeHelpers.Gui.Controls.OptionButtonHelper optionButtonHelper1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_AircraftSettings));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			frame_settings = new System.Windows.Forms.GroupBox();
			SSPanel1 = new System.Windows.Forms.Panel();
			opt_avail_leave = new System.Windows.Forms.RadioButton();
			opt_avail_clear = new System.Windows.Forms.RadioButton();
			Label1 = new System.Windows.Forms.Label();
			cmd_Cancel = new System.Windows.Forms.Button();
			cmd_OK = new System.Windows.Forms.Button();
			SSPanel2 = new System.Windows.Forms.Panel();
			opt_contact_clear = new System.Windows.Forms.RadioButton();
			opt_contact_leave = new System.Windows.Forms.RadioButton();
			Label7 = new System.Windows.Forms.Label();
			SSPanel3 = new System.Windows.Forms.Panel();
			opt_base_leave = new System.Windows.Forms.RadioButton();
			opt_base_clear = new System.Windows.Forms.RadioButton();
			Label2 = new System.Windows.Forms.Label();
			SSPanel4 = new System.Windows.Forms.Panel();
			opt_spec_clear = new System.Windows.Forms.RadioButton();
			opt_spec_leave = new System.Windows.Forms.RadioButton();
			Label4 = new System.Windows.Forms.Label();
			Label3 = new System.Windows.Forms.Label();
			pnl_newused = new System.Windows.Forms.Panel();
			opt_New = new System.Windows.Forms.RadioButton();
			opt_Used = new System.Windows.Forms.RadioButton();
			Label5 = new System.Windows.Forms.Label();
			frame_settings.SuspendLayout();
			SSPanel1.SuspendLayout();
			SSPanel2.SuspendLayout();
			SSPanel3.SuspendLayout();
			SSPanel4.SuspendLayout();
			pnl_newused.SuspendLayout();
			SuspendLayout();
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
			optionButtonHelper1 = new UpgradeHelpers.Gui.Controls.OptionButtonHelper(components);
			// 
			// frame_settings
			// 
			frame_settings.AllowDrop = true;
			frame_settings.Controls.Add(SSPanel1);
			frame_settings.Controls.Add(cmd_Cancel);
			frame_settings.Controls.Add(cmd_OK);
			frame_settings.Controls.Add(SSPanel2);
			frame_settings.Controls.Add(SSPanel3);
			frame_settings.Controls.Add(SSPanel4);
			frame_settings.Controls.Add(pnl_newused);
			frame_settings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frame_settings.Location = new System.Drawing.Point(1, 2);
			frame_settings.Name = "frame_settings";
			frame_settings.Size = new System.Drawing.Size(312, 237);
			frame_settings.TabIndex = 0;
			frame_settings.Text = "Aircraft Settings";
			// 
			// SSPanel1
			// 
			SSPanel1.AllowDrop = true;
			SSPanel1.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
			SSPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			SSPanel1.Controls.Add(opt_avail_leave);
			SSPanel1.Controls.Add(opt_avail_clear);
			SSPanel1.Controls.Add(Label1);
			SSPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			SSPanel1.Location = new System.Drawing.Point(8, 24);
			SSPanel1.Name = "SSPanel1";
			SSPanel1.Size = new System.Drawing.Size(294, 26);
			SSPanel1.TabIndex = 3;
			// 
			// opt_avail_leave
			// 
			opt_avail_leave.AllowDrop = true;
			opt_avail_leave.BackColor = System.Drawing.SystemColors.Control;
			opt_avail_leave.CausesValidation = true;
			opt_avail_leave.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opt_avail_leave.Checked = false;
			opt_avail_leave.Enabled = true;
			opt_avail_leave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			opt_avail_leave.ForeColor = System.Drawing.SystemColors.ControlText;
			opt_avail_leave.Location = new System.Drawing.Point(192, 6);
			opt_avail_leave.Name = "opt_avail_leave";
			opt_avail_leave.RightToLeft = System.Windows.Forms.RightToLeft.No;
			opt_avail_leave.Size = new System.Drawing.Size(78, 17);
			opt_avail_leave.TabIndex = 6;
			opt_avail_leave.TabStop = true;
			opt_avail_leave.Text = "Leave";
			opt_avail_leave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opt_avail_leave.Visible = true;
			// 
			// opt_avail_clear
			// 
			opt_avail_clear.AllowDrop = true;
			opt_avail_clear.BackColor = System.Drawing.SystemColors.Control;
			opt_avail_clear.CausesValidation = true;
			opt_avail_clear.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opt_avail_clear.Checked = true;
			opt_avail_clear.Enabled = true;
			opt_avail_clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			opt_avail_clear.ForeColor = System.Drawing.SystemColors.ControlText;
			opt_avail_clear.Location = new System.Drawing.Point(110, 6);
			opt_avail_clear.Name = "opt_avail_clear";
			opt_avail_clear.RightToLeft = System.Windows.Forms.RightToLeft.No;
			opt_avail_clear.Size = new System.Drawing.Size(78, 17);
			opt_avail_clear.TabIndex = 5;
			opt_avail_clear.TabStop = true;
			opt_avail_clear.Text = "Clear";
			opt_avail_clear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opt_avail_clear.Visible = true;
			// 
			// Label1
			// 
			Label1.AllowDrop = true;
			Label1.BackColor = System.Drawing.Color.Transparent;
			Label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label1.ForeColor = System.Drawing.SystemColors.ControlText;
			Label1.Location = new System.Drawing.Point(12, 6);
			Label1.MinimumSize = new System.Drawing.Size(57, 21);
			Label1.Name = "Label1";
			Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label1.Size = new System.Drawing.Size(57, 21);
			Label1.TabIndex = 4;
			Label1.Text = "Availability:";
			// 
			// cmd_Cancel
			// 
			cmd_Cancel.AllowDrop = true;
			cmd_Cancel.BackColor = System.Drawing.SystemColors.Control;
			cmd_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Cancel.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Cancel.Location = new System.Drawing.Point(208, 200);
			cmd_Cancel.Name = "cmd_Cancel";
			cmd_Cancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Cancel.Size = new System.Drawing.Size(96, 24);
			cmd_Cancel.TabIndex = 2;
			cmd_Cancel.Text = "Cancel";
			cmd_Cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Cancel.UseVisualStyleBackColor = false;
			cmd_Cancel.Click += new System.EventHandler(cmd_cancel_Click);
			// 
			// cmd_OK
			// 
			cmd_OK.AllowDrop = true;
			cmd_OK.BackColor = System.Drawing.SystemColors.Control;
			cmd_OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_OK.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_OK.Location = new System.Drawing.Point(104, 200);
			cmd_OK.Name = "cmd_OK";
			cmd_OK.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_OK.Size = new System.Drawing.Size(100, 24);
			cmd_OK.TabIndex = 1;
			cmd_OK.Text = "Continue";
			cmd_OK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_OK.UseVisualStyleBackColor = false;
			cmd_OK.Click += new System.EventHandler(cmd_OK_Click);
			// 
			// SSPanel2
			// 
			SSPanel2.AllowDrop = true;
			SSPanel2.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
			SSPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			SSPanel2.Controls.Add(opt_contact_clear);
			SSPanel2.Controls.Add(opt_contact_leave);
			SSPanel2.Controls.Add(Label7);
			SSPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			SSPanel2.Location = new System.Drawing.Point(8, 50);
			SSPanel2.Name = "SSPanel2";
			SSPanel2.Size = new System.Drawing.Size(294, 26);
			SSPanel2.TabIndex = 7;
			// 
			// opt_contact_clear
			// 
			opt_contact_clear.AllowDrop = true;
			opt_contact_clear.BackColor = System.Drawing.SystemColors.Control;
			opt_contact_clear.CausesValidation = true;
			opt_contact_clear.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opt_contact_clear.Checked = true;
			opt_contact_clear.Enabled = true;
			opt_contact_clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			opt_contact_clear.ForeColor = System.Drawing.SystemColors.ControlText;
			opt_contact_clear.Location = new System.Drawing.Point(110, 7);
			opt_contact_clear.Name = "opt_contact_clear";
			opt_contact_clear.RightToLeft = System.Windows.Forms.RightToLeft.No;
			opt_contact_clear.Size = new System.Drawing.Size(78, 17);
			opt_contact_clear.TabIndex = 9;
			opt_contact_clear.TabStop = true;
			opt_contact_clear.Text = "Clear";
			opt_contact_clear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opt_contact_clear.Visible = true;
			// 
			// opt_contact_leave
			// 
			opt_contact_leave.AllowDrop = true;
			opt_contact_leave.BackColor = System.Drawing.SystemColors.Control;
			opt_contact_leave.CausesValidation = true;
			opt_contact_leave.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opt_contact_leave.Checked = false;
			opt_contact_leave.Enabled = true;
			opt_contact_leave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			opt_contact_leave.ForeColor = System.Drawing.SystemColors.ControlText;
			opt_contact_leave.Location = new System.Drawing.Point(192, 7);
			opt_contact_leave.Name = "opt_contact_leave";
			opt_contact_leave.RightToLeft = System.Windows.Forms.RightToLeft.No;
			opt_contact_leave.Size = new System.Drawing.Size(78, 17);
			opt_contact_leave.TabIndex = 8;
			opt_contact_leave.TabStop = true;
			opt_contact_leave.Text = "Leave";
			opt_contact_leave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opt_contact_leave.Visible = true;
			// 
			// Label7
			// 
			Label7.AllowDrop = true;
			Label7.BackColor = System.Drawing.Color.Transparent;
			Label7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label7.ForeColor = System.Drawing.SystemColors.ControlText;
			Label7.Location = new System.Drawing.Point(11, 6);
			Label7.MinimumSize = new System.Drawing.Size(57, 21);
			Label7.Name = "Label7";
			Label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label7.Size = new System.Drawing.Size(57, 21);
			Label7.TabIndex = 10;
			Label7.Text = "Contacts:";
			// 
			// SSPanel3
			// 
			SSPanel3.AllowDrop = true;
			SSPanel3.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
			SSPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			SSPanel3.Controls.Add(opt_base_leave);
			SSPanel3.Controls.Add(opt_base_clear);
			SSPanel3.Controls.Add(Label2);
			SSPanel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			SSPanel3.Location = new System.Drawing.Point(8, 76);
			SSPanel3.Name = "SSPanel3";
			SSPanel3.Size = new System.Drawing.Size(294, 26);
			SSPanel3.TabIndex = 11;
			// 
			// opt_base_leave
			// 
			opt_base_leave.AllowDrop = true;
			opt_base_leave.BackColor = System.Drawing.SystemColors.Control;
			opt_base_leave.CausesValidation = true;
			opt_base_leave.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opt_base_leave.Checked = false;
			opt_base_leave.Enabled = true;
			opt_base_leave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			opt_base_leave.ForeColor = System.Drawing.SystemColors.ControlText;
			opt_base_leave.Location = new System.Drawing.Point(192, 7);
			opt_base_leave.Name = "opt_base_leave";
			opt_base_leave.RightToLeft = System.Windows.Forms.RightToLeft.No;
			opt_base_leave.Size = new System.Drawing.Size(78, 17);
			opt_base_leave.TabIndex = 13;
			opt_base_leave.TabStop = true;
			opt_base_leave.Text = "Leave";
			opt_base_leave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opt_base_leave.Visible = true;
			// 
			// opt_base_clear
			// 
			opt_base_clear.AllowDrop = true;
			opt_base_clear.BackColor = System.Drawing.SystemColors.Control;
			opt_base_clear.CausesValidation = true;
			opt_base_clear.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opt_base_clear.Checked = true;
			opt_base_clear.Enabled = true;
			opt_base_clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			opt_base_clear.ForeColor = System.Drawing.SystemColors.ControlText;
			opt_base_clear.Location = new System.Drawing.Point(110, 6);
			opt_base_clear.Name = "opt_base_clear";
			opt_base_clear.RightToLeft = System.Windows.Forms.RightToLeft.No;
			opt_base_clear.Size = new System.Drawing.Size(78, 17);
			opt_base_clear.TabIndex = 12;
			opt_base_clear.TabStop = true;
			opt_base_clear.Text = "Clear";
			opt_base_clear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opt_base_clear.Visible = true;
			// 
			// Label2
			// 
			Label2.AllowDrop = true;
			Label2.BackColor = System.Drawing.Color.Transparent;
			Label2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label2.ForeColor = System.Drawing.SystemColors.ControlText;
			Label2.Location = new System.Drawing.Point(11, 6);
			Label2.MinimumSize = new System.Drawing.Size(96, 21);
			Label2.Name = "Label2";
			Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label2.Size = new System.Drawing.Size(96, 21);
			Label2.TabIndex = 14;
			Label2.Text = "Base Information:";
			// 
			// SSPanel4
			// 
			SSPanel4.AllowDrop = true;
			SSPanel4.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
			SSPanel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			SSPanel4.Controls.Add(opt_spec_clear);
			SSPanel4.Controls.Add(opt_spec_leave);
			SSPanel4.Controls.Add(Label4);
			SSPanel4.Controls.Add(Label3);
			SSPanel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			SSPanel4.Location = new System.Drawing.Point(8, 102);
			SSPanel4.Name = "SSPanel4";
			SSPanel4.Size = new System.Drawing.Size(294, 55);
			SSPanel4.TabIndex = 15;
			// 
			// opt_spec_clear
			// 
			opt_spec_clear.AllowDrop = true;
			opt_spec_clear.BackColor = System.Drawing.SystemColors.Control;
			opt_spec_clear.CausesValidation = true;
			opt_spec_clear.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opt_spec_clear.Checked = true;
			opt_spec_clear.Enabled = true;
			opt_spec_clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			opt_spec_clear.ForeColor = System.Drawing.SystemColors.ControlText;
			opt_spec_clear.Location = new System.Drawing.Point(110, 6);
			opt_spec_clear.Name = "opt_spec_clear";
			opt_spec_clear.RightToLeft = System.Windows.Forms.RightToLeft.No;
			opt_spec_clear.Size = new System.Drawing.Size(78, 17);
			opt_spec_clear.TabIndex = 17;
			opt_spec_clear.TabStop = true;
			opt_spec_clear.Text = "Clear";
			opt_spec_clear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opt_spec_clear.Visible = true;
			// 
			// opt_spec_leave
			// 
			opt_spec_leave.AllowDrop = true;
			opt_spec_leave.BackColor = System.Drawing.SystemColors.Control;
			opt_spec_leave.CausesValidation = true;
			opt_spec_leave.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opt_spec_leave.Checked = false;
			opt_spec_leave.Enabled = true;
			opt_spec_leave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			opt_spec_leave.ForeColor = System.Drawing.SystemColors.ControlText;
			opt_spec_leave.Location = new System.Drawing.Point(192, 7);
			opt_spec_leave.Name = "opt_spec_leave";
			opt_spec_leave.RightToLeft = System.Windows.Forms.RightToLeft.No;
			opt_spec_leave.Size = new System.Drawing.Size(78, 17);
			opt_spec_leave.TabIndex = 16;
			opt_spec_leave.TabStop = true;
			opt_spec_leave.Text = "Leave";
			opt_spec_leave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opt_spec_leave.Visible = true;
			// 
			// Label4
			// 
			Label4.AllowDrop = true;
			Label4.BackColor = System.Drawing.Color.Transparent;
			Label4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label4.ForeColor = System.Drawing.SystemColors.ControlText;
			Label4.Location = new System.Drawing.Point(10, 22);
			Label4.MinimumSize = new System.Drawing.Size(279, 28);
			Label4.Name = "Label4";
			Label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label4.Size = new System.Drawing.Size(279, 28);
			Label4.TabIndex = 19;
			Label4.Text = "Note: Clearing specifications does not clear the important feature codes.";
			// 
			// Label3
			// 
			Label3.AllowDrop = true;
			Label3.BackColor = System.Drawing.Color.Transparent;
			Label3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label3.ForeColor = System.Drawing.SystemColors.ControlText;
			Label3.Location = new System.Drawing.Point(11, 6);
			Label3.MinimumSize = new System.Drawing.Size(96, 21);
			Label3.Name = "Label3";
			Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label3.Size = new System.Drawing.Size(96, 21);
			Label3.TabIndex = 18;
			Label3.Text = "Specifications:";
			// 
			// pnl_newused
			// 
			pnl_newused.AllowDrop = true;
			pnl_newused.BackColor = System.Drawing.Color.FromArgb(212, 208, 200);
			pnl_newused.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_newused.Controls.Add(opt_New);
			pnl_newused.Controls.Add(opt_Used);
			pnl_newused.Controls.Add(Label5);
			pnl_newused.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_newused.Location = new System.Drawing.Point(8, 152);
			pnl_newused.Name = "pnl_newused";
			pnl_newused.Size = new System.Drawing.Size(294, 34);
			pnl_newused.TabIndex = 20;
			// 
			// opt_New
			// 
			opt_New.AllowDrop = true;
			opt_New.BackColor = System.Drawing.SystemColors.Control;
			opt_New.CausesValidation = true;
			opt_New.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opt_New.Checked = true;
			opt_New.Enabled = true;
			opt_New.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			opt_New.ForeColor = System.Drawing.SystemColors.ControlText;
			opt_New.Location = new System.Drawing.Point(110, 12);
			opt_New.Name = "opt_New";
			opt_New.RightToLeft = System.Windows.Forms.RightToLeft.No;
			opt_New.Size = new System.Drawing.Size(78, 13);
			opt_New.TabIndex = 22;
			opt_New.TabStop = true;
			opt_New.Text = "New";
			opt_New.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opt_New.Visible = true;
			// 
			// opt_Used
			// 
			opt_Used.AllowDrop = true;
			opt_Used.BackColor = System.Drawing.SystemColors.Control;
			opt_Used.CausesValidation = true;
			opt_Used.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opt_Used.Checked = false;
			opt_Used.Enabled = true;
			opt_Used.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			opt_Used.ForeColor = System.Drawing.SystemColors.ControlText;
			opt_Used.Location = new System.Drawing.Point(192, 12);
			opt_Used.Name = "opt_Used";
			opt_Used.RightToLeft = System.Windows.Forms.RightToLeft.No;
			opt_Used.Size = new System.Drawing.Size(78, 13);
			opt_Used.TabIndex = 21;
			opt_Used.TabStop = true;
			opt_Used.Text = "Used";
			opt_Used.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opt_Used.Visible = true;
			// 
			// Label5
			// 
			Label5.AllowDrop = true;
			Label5.BackColor = System.Drawing.Color.Transparent;
			Label5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label5.ForeColor = System.Drawing.SystemColors.ControlText;
			Label5.Location = new System.Drawing.Point(8, 8);
			Label5.MinimumSize = new System.Drawing.Size(93, 17);
			Label5.Name = "Label5";
			Label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label5.Size = new System.Drawing.Size(93, 17);
			Label5.TabIndex = 23;
			Label5.Text = "New or Used:";
			// 
			// frm_AircraftSettings
			// 
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			ClientSize = new System.Drawing.Size(321, 243);
			Controls.Add(frame_settings);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Location = new System.Drawing.Point(234, 138);
			MaximizeBox = true;
			MinimizeBox = true;
			Name = "frm_AircraftSettings";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Aircraft Settings";
			commandButtonHelper1.SetStyle(cmd_Cancel, 0);
			commandButtonHelper1.SetStyle(cmd_OK, 0);
			optionButtonHelper1.SetStyle(opt_avail_leave, 0);
			optionButtonHelper1.SetStyle(opt_avail_clear, 0);
			optionButtonHelper1.SetStyle(opt_contact_clear, 0);
			optionButtonHelper1.SetStyle(opt_contact_leave, 0);
			optionButtonHelper1.SetStyle(opt_base_leave, 0);
			optionButtonHelper1.SetStyle(opt_base_clear, 0);
			optionButtonHelper1.SetStyle(opt_spec_clear, 0);
			optionButtonHelper1.SetStyle(opt_spec_leave, 0);
			optionButtonHelper1.SetStyle(opt_New, 0);
			optionButtonHelper1.SetStyle(opt_Used, 0);
			Activated += new System.EventHandler(frm_AircraftSettings_Activated);
			Closed += new System.EventHandler(Form_Closed);
			frame_settings.ResumeLayout(false);
			frame_settings.PerformLayout();
			SSPanel1.ResumeLayout(false);
			SSPanel1.PerformLayout();
			SSPanel2.ResumeLayout(false);
			SSPanel2.PerformLayout();
			SSPanel3.ResumeLayout(false);
			SSPanel3.PerformLayout();
			SSPanel4.ResumeLayout(false);
			SSPanel4.PerformLayout();
			pnl_newused.ResumeLayout(false);
			pnl_newused.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
		#endregion
	}
}