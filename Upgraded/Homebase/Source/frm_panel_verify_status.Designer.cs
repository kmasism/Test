
namespace JETNET_Homebase
{
	partial class frm_verify_status
	{

		#region "Upgrade Support "
		private static frm_verify_status m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_verify_status DefInstance
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
		public static frm_verify_status CreateInstance()
		{
			frm_verify_status theInstance = new frm_verify_status();
			theInstance.Form_Load();
			return theInstance;
		}
		private string[] visualControls = new string[]{"components", "ToolTipMain", "txt_description", "grd_Company_Aircraft", "cbo_verify_journal_subject", "cbo_verify_journal_auto_subject", "_pic_verify_ac_2", "_pic_verify_ac_3", "_pic_verify_ac_0", "_pic_verify_ac_1", "cbo_verify_other_contacts", "cmd_verify_status_cancel", "chk_verify_contact", "cbo_verify_aircraft", "_opt_verify_aircraft_0", "_opt_verify_aircraft_1", "_opt_verify_aircraft_2", "_opt_verify_aircraft_3", "cbo_verify_note_type", "_opt_verify_aircraft_4", "cbo_yachts", "_opt_journal_subject_10", "_opt_journal_subject_11", "_opt_journal_subject_13", "_opt_journal_subject_12", "frame_verify_pnl", "txt_marketing_notes", "frm_marketing_note", "_cmd_verify_yacht_2", "cmd_verify_status_save", "_opt_journal_subject_1", "_opt_journal_subject_2", "_opt_journal_subject_3", "_opt_journal_subject_0", "_lbl_comp_0", "_lbl_comp_11", "_Shape1_0", "_lbl_verify_text_label_75", "_lbl_comp_47", "_lbl_comp_48", "_lbl_comp_46", "_lbl_comp_17", "_lbl_comp_49", "_Shape1_1", "_Shape1_2", "_Shape1_3", "pnl_verify_aircraft_status", "Shape1", "cmd_verify_yacht", "lbl_comp", "lbl_verify_text_label", "opt_journal_subject", "opt_verify_aircraft", "pic_verify_ac", "optionButtonHelper1", "commandButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txt_description;
		public UpgradeHelpers.DataGridViewFlex grd_Company_Aircraft;
		public System.Windows.Forms.ComboBox cbo_verify_journal_subject;
		public System.Windows.Forms.ComboBox cbo_verify_journal_auto_subject;
		private System.Windows.Forms.PictureBox _pic_verify_ac_2;
		private System.Windows.Forms.PictureBox _pic_verify_ac_3;
		private System.Windows.Forms.PictureBox _pic_verify_ac_0;
		private System.Windows.Forms.PictureBox _pic_verify_ac_1;
		public System.Windows.Forms.ComboBox cbo_verify_other_contacts;
		public System.Windows.Forms.Button cmd_verify_status_cancel;
		public System.Windows.Forms.CheckBox chk_verify_contact;
		public System.Windows.Forms.ComboBox cbo_verify_aircraft;
		private System.Windows.Forms.RadioButton _opt_verify_aircraft_0;
		private System.Windows.Forms.RadioButton _opt_verify_aircraft_1;
		private System.Windows.Forms.RadioButton _opt_verify_aircraft_2;
		private System.Windows.Forms.RadioButton _opt_verify_aircraft_3;
		public System.Windows.Forms.ComboBox cbo_verify_note_type;
		private System.Windows.Forms.RadioButton _opt_verify_aircraft_4;
		public System.Windows.Forms.ComboBox cbo_yachts;
		private System.Windows.Forms.RadioButton _opt_journal_subject_10;
		private System.Windows.Forms.RadioButton _opt_journal_subject_11;
		private System.Windows.Forms.RadioButton _opt_journal_subject_13;
		private System.Windows.Forms.RadioButton _opt_journal_subject_12;
		public System.Windows.Forms.GroupBox frame_verify_pnl;
		public System.Windows.Forms.TextBox txt_marketing_notes;
		public System.Windows.Forms.GroupBox frm_marketing_note;
		private System.Windows.Forms.Button _cmd_verify_yacht_2;
		public System.Windows.Forms.Button cmd_verify_status_save;
		private System.Windows.Forms.RadioButton _opt_journal_subject_1;
		private System.Windows.Forms.RadioButton _opt_journal_subject_2;
		private System.Windows.Forms.RadioButton _opt_journal_subject_3;
		private System.Windows.Forms.RadioButton _opt_journal_subject_0;
		private System.Windows.Forms.Label _lbl_comp_0;
		private System.Windows.Forms.Label _lbl_comp_11;
		private UpgradeHelpers.Gui.ShapeHelper _Shape1_0;
		private System.Windows.Forms.Label _lbl_verify_text_label_75;
		private System.Windows.Forms.Label _lbl_comp_47;
		private System.Windows.Forms.Label _lbl_comp_48;
		private System.Windows.Forms.Label _lbl_comp_46;
		private System.Windows.Forms.Label _lbl_comp_17;
		private System.Windows.Forms.Label _lbl_comp_49;
		private UpgradeHelpers.Gui.ShapeHelper _Shape1_1;
		private UpgradeHelpers.Gui.ShapeHelper _Shape1_2;
		private UpgradeHelpers.Gui.ShapeHelper _Shape1_3;
		public System.Windows.Forms.Panel pnl_verify_aircraft_status;
		public UpgradeHelpers.Gui.ShapeHelper[] Shape1 = new UpgradeHelpers.Gui.ShapeHelper[4];
		public System.Windows.Forms.Button[] cmd_verify_yacht = new System.Windows.Forms.Button[3];
		public System.Windows.Forms.Label[] lbl_comp = new System.Windows.Forms.Label[50];
		public System.Windows.Forms.Label[] lbl_verify_text_label = new System.Windows.Forms.Label[76];
		public System.Windows.Forms.RadioButton[] opt_journal_subject = new System.Windows.Forms.RadioButton[14];
		public System.Windows.Forms.RadioButton[] opt_verify_aircraft = new System.Windows.Forms.RadioButton[5];
		public System.Windows.Forms.PictureBox[] pic_verify_ac = new System.Windows.Forms.PictureBox[4];
		public UpgradeHelpers.Gui.Controls.OptionButtonHelper optionButtonHelper1;
		public UpgradeHelpers.Gui.Controls.CommandButtonHelper commandButtonHelper1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_verify_status));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			pnl_verify_aircraft_status = new System.Windows.Forms.Panel();
			txt_description = new System.Windows.Forms.TextBox();
			grd_Company_Aircraft = new UpgradeHelpers.DataGridViewFlex(components);
			cbo_verify_journal_subject = new System.Windows.Forms.ComboBox();
			cbo_verify_journal_auto_subject = new System.Windows.Forms.ComboBox();
			_pic_verify_ac_2 = new System.Windows.Forms.PictureBox();
			_pic_verify_ac_3 = new System.Windows.Forms.PictureBox();
			_pic_verify_ac_0 = new System.Windows.Forms.PictureBox();
			_pic_verify_ac_1 = new System.Windows.Forms.PictureBox();
			cbo_verify_other_contacts = new System.Windows.Forms.ComboBox();
			cmd_verify_status_cancel = new System.Windows.Forms.Button();
			chk_verify_contact = new System.Windows.Forms.CheckBox();
			cbo_verify_aircraft = new System.Windows.Forms.ComboBox();
			_opt_verify_aircraft_0 = new System.Windows.Forms.RadioButton();
			_opt_verify_aircraft_1 = new System.Windows.Forms.RadioButton();
			_opt_verify_aircraft_2 = new System.Windows.Forms.RadioButton();
			_opt_verify_aircraft_3 = new System.Windows.Forms.RadioButton();
			cbo_verify_note_type = new System.Windows.Forms.ComboBox();
			_opt_verify_aircraft_4 = new System.Windows.Forms.RadioButton();
			cbo_yachts = new System.Windows.Forms.ComboBox();
			frame_verify_pnl = new System.Windows.Forms.GroupBox();
			_opt_journal_subject_10 = new System.Windows.Forms.RadioButton();
			_opt_journal_subject_11 = new System.Windows.Forms.RadioButton();
			_opt_journal_subject_13 = new System.Windows.Forms.RadioButton();
			_opt_journal_subject_12 = new System.Windows.Forms.RadioButton();
			frm_marketing_note = new System.Windows.Forms.GroupBox();
			txt_marketing_notes = new System.Windows.Forms.TextBox();
			_cmd_verify_yacht_2 = new System.Windows.Forms.Button();
			cmd_verify_status_save = new System.Windows.Forms.Button();
			_opt_journal_subject_1 = new System.Windows.Forms.RadioButton();
			_opt_journal_subject_2 = new System.Windows.Forms.RadioButton();
			_opt_journal_subject_3 = new System.Windows.Forms.RadioButton();
			_opt_journal_subject_0 = new System.Windows.Forms.RadioButton();
			_lbl_comp_0 = new System.Windows.Forms.Label();
			_lbl_comp_11 = new System.Windows.Forms.Label();
			_Shape1_0 = new UpgradeHelpers.Gui.ShapeHelper();
			_lbl_verify_text_label_75 = new System.Windows.Forms.Label();
			_lbl_comp_47 = new System.Windows.Forms.Label();
			_lbl_comp_48 = new System.Windows.Forms.Label();
			_lbl_comp_46 = new System.Windows.Forms.Label();
			_lbl_comp_17 = new System.Windows.Forms.Label();
			_lbl_comp_49 = new System.Windows.Forms.Label();
			_Shape1_1 = new UpgradeHelpers.Gui.ShapeHelper();
			_Shape1_2 = new UpgradeHelpers.Gui.ShapeHelper();
			_Shape1_3 = new UpgradeHelpers.Gui.ShapeHelper();
			pnl_verify_aircraft_status.SuspendLayout();
			frame_verify_pnl.SuspendLayout();
			frm_marketing_note.SuspendLayout();
			SuspendLayout();
			optionButtonHelper1 = new UpgradeHelpers.Gui.Controls.OptionButtonHelper(components);
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
			((System.ComponentModel.ISupportInitialize) grd_Company_Aircraft).BeginInit();
			// 
			// pnl_verify_aircraft_status
			// 
			pnl_verify_aircraft_status.AllowDrop = true;
			pnl_verify_aircraft_status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_verify_aircraft_status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_verify_aircraft_status.Controls.Add(txt_description);
			pnl_verify_aircraft_status.Controls.Add(grd_Company_Aircraft);
			pnl_verify_aircraft_status.Controls.Add(cbo_verify_journal_subject);
			pnl_verify_aircraft_status.Controls.Add(cbo_verify_journal_auto_subject);
			pnl_verify_aircraft_status.Controls.Add(_pic_verify_ac_2);
			pnl_verify_aircraft_status.Controls.Add(_pic_verify_ac_3);
			pnl_verify_aircraft_status.Controls.Add(_pic_verify_ac_0);
			pnl_verify_aircraft_status.Controls.Add(_pic_verify_ac_1);
			pnl_verify_aircraft_status.Controls.Add(cbo_verify_other_contacts);
			pnl_verify_aircraft_status.Controls.Add(cmd_verify_status_cancel);
			pnl_verify_aircraft_status.Controls.Add(chk_verify_contact);
			pnl_verify_aircraft_status.Controls.Add(cbo_verify_aircraft);
			pnl_verify_aircraft_status.Controls.Add(_opt_verify_aircraft_0);
			pnl_verify_aircraft_status.Controls.Add(_opt_verify_aircraft_1);
			pnl_verify_aircraft_status.Controls.Add(_opt_verify_aircraft_2);
			pnl_verify_aircraft_status.Controls.Add(_opt_verify_aircraft_3);
			pnl_verify_aircraft_status.Controls.Add(cbo_verify_note_type);
			pnl_verify_aircraft_status.Controls.Add(_opt_verify_aircraft_4);
			pnl_verify_aircraft_status.Controls.Add(cbo_yachts);
			pnl_verify_aircraft_status.Controls.Add(frame_verify_pnl);
			pnl_verify_aircraft_status.Controls.Add(frm_marketing_note);
			pnl_verify_aircraft_status.Controls.Add(_cmd_verify_yacht_2);
			pnl_verify_aircraft_status.Controls.Add(cmd_verify_status_save);
			pnl_verify_aircraft_status.Controls.Add(_opt_journal_subject_1);
			pnl_verify_aircraft_status.Controls.Add(_opt_journal_subject_2);
			pnl_verify_aircraft_status.Controls.Add(_opt_journal_subject_3);
			pnl_verify_aircraft_status.Controls.Add(_opt_journal_subject_0);
			pnl_verify_aircraft_status.Controls.Add(_lbl_comp_0);
			pnl_verify_aircraft_status.Controls.Add(_lbl_comp_11);
			pnl_verify_aircraft_status.Controls.Add(_Shape1_0);
			pnl_verify_aircraft_status.Controls.Add(_lbl_verify_text_label_75);
			pnl_verify_aircraft_status.Controls.Add(_lbl_comp_47);
			pnl_verify_aircraft_status.Controls.Add(_lbl_comp_48);
			pnl_verify_aircraft_status.Controls.Add(_lbl_comp_46);
			pnl_verify_aircraft_status.Controls.Add(_lbl_comp_17);
			pnl_verify_aircraft_status.Controls.Add(_lbl_comp_49);
			pnl_verify_aircraft_status.Controls.Add(_Shape1_1);
			pnl_verify_aircraft_status.Controls.Add(_Shape1_2);
			pnl_verify_aircraft_status.Controls.Add(_Shape1_3);
			pnl_verify_aircraft_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_verify_aircraft_status.ForeColor = System.Drawing.Color.Black;
			pnl_verify_aircraft_status.Location = new System.Drawing.Point(2, 0);
			pnl_verify_aircraft_status.Name = "pnl_verify_aircraft_status";
			pnl_verify_aircraft_status.Size = new System.Drawing.Size(487, 394);
			pnl_verify_aircraft_status.TabIndex = 0;
			// 
			// txt_description
			// 
			txt_description.AcceptsReturn = true;
			txt_description.AllowDrop = true;
			txt_description.BackColor = System.Drawing.SystemColors.Window;
			txt_description.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_description.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_description.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_description.Location = new System.Drawing.Point(165, 48);
			txt_description.MaxLength = 0;
			txt_description.Multiline = true;
			txt_description.Name = "txt_description";
			txt_description.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_description.Size = new System.Drawing.Size(303, 45);
			txt_description.TabIndex = 39;
			// 
			// grd_Company_Aircraft
			// 
			grd_Company_Aircraft.AllowDrop = true;
			grd_Company_Aircraft.AllowUserToAddRows = false;
			grd_Company_Aircraft.AllowUserToDeleteRows = false;
			grd_Company_Aircraft.AllowUserToResizeColumns = false;
			grd_Company_Aircraft.AllowUserToResizeRows = false;
			grd_Company_Aircraft.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_Company_Aircraft.ColumnsCount = 2;
			grd_Company_Aircraft.FixedColumns = 1;
			grd_Company_Aircraft.FixedRows = 1;
			grd_Company_Aircraft.Location = new System.Drawing.Point(22, 210);
			grd_Company_Aircraft.Name = "grd_Company_Aircraft";
			grd_Company_Aircraft.ReadOnly = true;
			grd_Company_Aircraft.RowsCount = 2;
			grd_Company_Aircraft.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			grd_Company_Aircraft.ShowCellToolTips = false;
			grd_Company_Aircraft.Size = new System.Drawing.Size(33, 23);
			grd_Company_Aircraft.StandardTab = true;
			grd_Company_Aircraft.TabIndex = 37;
			grd_Company_Aircraft.Visible = false;
			// 
			// cbo_verify_journal_subject
			// 
			cbo_verify_journal_subject.AllowDrop = true;
			cbo_verify_journal_subject.BackColor = System.Drawing.SystemColors.Window;
			cbo_verify_journal_subject.CausesValidation = true;
			cbo_verify_journal_subject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
			cbo_verify_journal_subject.Enabled = true;
			cbo_verify_journal_subject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_verify_journal_subject.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_verify_journal_subject.IntegralHeight = true;
			cbo_verify_journal_subject.Location = new System.Drawing.Point(165, 100);
			cbo_verify_journal_subject.Name = "cbo_verify_journal_subject";
			cbo_verify_journal_subject.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_verify_journal_subject.Size = new System.Drawing.Size(303, 21);
			cbo_verify_journal_subject.Sorted = false;
			cbo_verify_journal_subject.TabIndex = 30;
			cbo_verify_journal_subject.TabStop = true;
			cbo_verify_journal_subject.Text = "cbo_verify_journal_subject";
			cbo_verify_journal_subject.Visible = true;
			// 
			// cbo_verify_journal_auto_subject
			// 
			cbo_verify_journal_auto_subject.AllowDrop = true;
			cbo_verify_journal_auto_subject.BackColor = System.Drawing.SystemColors.Window;
			cbo_verify_journal_auto_subject.CausesValidation = true;
			cbo_verify_journal_auto_subject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_verify_journal_auto_subject.Enabled = true;
			cbo_verify_journal_auto_subject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_verify_journal_auto_subject.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_verify_journal_auto_subject.IntegralHeight = true;
			cbo_verify_journal_auto_subject.Location = new System.Drawing.Point(166, 100);
			cbo_verify_journal_auto_subject.Name = "cbo_verify_journal_auto_subject";
			cbo_verify_journal_auto_subject.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_verify_journal_auto_subject.Size = new System.Drawing.Size(303, 21);
			cbo_verify_journal_auto_subject.Sorted = false;
			cbo_verify_journal_auto_subject.TabIndex = 29;
			cbo_verify_journal_auto_subject.TabStop = true;
			cbo_verify_journal_auto_subject.Text = "cbo_verify_journal_auto_subject";
			cbo_verify_journal_auto_subject.Visible = false;
			// 
			// _pic_verify_ac_2
			// 
			_pic_verify_ac_2.AllowDrop = true;
			_pic_verify_ac_2.BackColor = System.Drawing.SystemColors.Window;
			_pic_verify_ac_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_pic_verify_ac_2.CausesValidation = true;
			_pic_verify_ac_2.Dock = System.Windows.Forms.DockStyle.None;
			_pic_verify_ac_2.Enabled = true;
			_pic_verify_ac_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_pic_verify_ac_2.Image = (System.Drawing.Image) resources.GetObject("_pic_verify_ac_2.Image");
			_pic_verify_ac_2.Location = new System.Drawing.Point(438, 8);
			_pic_verify_ac_2.Name = "_pic_verify_ac_2";
			_pic_verify_ac_2.Size = new System.Drawing.Size(31, 24);
			_pic_verify_ac_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
			_pic_verify_ac_2.TabIndex = 28;
			_pic_verify_ac_2.TabStop = true;
			_pic_verify_ac_2.Visible = false;
			// 
			// _pic_verify_ac_3
			// 
			_pic_verify_ac_3.AllowDrop = true;
			_pic_verify_ac_3.BackColor = System.Drawing.SystemColors.Window;
			_pic_verify_ac_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_pic_verify_ac_3.CausesValidation = true;
			_pic_verify_ac_3.Dock = System.Windows.Forms.DockStyle.None;
			_pic_verify_ac_3.Enabled = true;
			_pic_verify_ac_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_pic_verify_ac_3.Image = (System.Drawing.Image) resources.GetObject("_pic_verify_ac_3.Image");
			_pic_verify_ac_3.Location = new System.Drawing.Point(438, 8);
			_pic_verify_ac_3.Name = "_pic_verify_ac_3";
			_pic_verify_ac_3.Size = new System.Drawing.Size(31, 24);
			_pic_verify_ac_3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
			_pic_verify_ac_3.TabIndex = 27;
			_pic_verify_ac_3.TabStop = true;
			_pic_verify_ac_3.Visible = false;
			// 
			// _pic_verify_ac_0
			// 
			_pic_verify_ac_0.AllowDrop = true;
			_pic_verify_ac_0.BackColor = System.Drawing.SystemColors.Window;
			_pic_verify_ac_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_pic_verify_ac_0.CausesValidation = true;
			_pic_verify_ac_0.Dock = System.Windows.Forms.DockStyle.None;
			_pic_verify_ac_0.Enabled = true;
			_pic_verify_ac_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_pic_verify_ac_0.Image = (System.Drawing.Image) resources.GetObject("_pic_verify_ac_0.Image");
			_pic_verify_ac_0.Location = new System.Drawing.Point(438, 8);
			_pic_verify_ac_0.Name = "_pic_verify_ac_0";
			_pic_verify_ac_0.Size = new System.Drawing.Size(31, 24);
			_pic_verify_ac_0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
			_pic_verify_ac_0.TabIndex = 26;
			_pic_verify_ac_0.TabStop = true;
			_pic_verify_ac_0.Visible = false;
			// 
			// _pic_verify_ac_1
			// 
			_pic_verify_ac_1.AllowDrop = true;
			_pic_verify_ac_1.BackColor = System.Drawing.SystemColors.Window;
			_pic_verify_ac_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_pic_verify_ac_1.CausesValidation = true;
			_pic_verify_ac_1.Dock = System.Windows.Forms.DockStyle.None;
			_pic_verify_ac_1.Enabled = true;
			_pic_verify_ac_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_pic_verify_ac_1.Image = (System.Drawing.Image) resources.GetObject("_pic_verify_ac_1.Image");
			_pic_verify_ac_1.Location = new System.Drawing.Point(438, 8);
			_pic_verify_ac_1.Name = "_pic_verify_ac_1";
			_pic_verify_ac_1.Size = new System.Drawing.Size(31, 24);
			_pic_verify_ac_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
			_pic_verify_ac_1.TabIndex = 25;
			_pic_verify_ac_1.TabStop = true;
			_pic_verify_ac_1.Visible = false;
			// 
			// cbo_verify_other_contacts
			// 
			cbo_verify_other_contacts.AllowDrop = true;
			cbo_verify_other_contacts.BackColor = System.Drawing.SystemColors.Window;
			cbo_verify_other_contacts.CausesValidation = true;
			cbo_verify_other_contacts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_verify_other_contacts.Enabled = true;
			cbo_verify_other_contacts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_verify_other_contacts.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_verify_other_contacts.IntegralHeight = true;
			cbo_verify_other_contacts.Location = new System.Drawing.Point(148, 226);
			cbo_verify_other_contacts.Name = "cbo_verify_other_contacts";
			cbo_verify_other_contacts.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_verify_other_contacts.Size = new System.Drawing.Size(245, 21);
			cbo_verify_other_contacts.Sorted = false;
			cbo_verify_other_contacts.TabIndex = 24;
			cbo_verify_other_contacts.TabStop = true;
			cbo_verify_other_contacts.Text = "cbo_verify_other_contacts";
			cbo_verify_other_contacts.Visible = true;
			cbo_verify_other_contacts.KeyDown += new System.Windows.Forms.KeyEventHandler(cbo_verify_other_contacts_KeyDown);
			cbo_verify_other_contacts.SelectionChangeCommitted += new System.EventHandler(cbo_verify_other_contacts_SelectionChangeCommitted);
			// 
			// cmd_verify_status_cancel
			// 
			cmd_verify_status_cancel.AllowDrop = true;
			cmd_verify_status_cancel.BackColor = System.Drawing.SystemColors.Control;
			cmd_verify_status_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_verify_status_cancel.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_verify_status_cancel.Location = new System.Drawing.Point(410, 362);
			cmd_verify_status_cancel.Name = "cmd_verify_status_cancel";
			cmd_verify_status_cancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_verify_status_cancel.Size = new System.Drawing.Size(64, 24);
			cmd_verify_status_cancel.TabIndex = 23;
			cmd_verify_status_cancel.Text = "&Cancel";
			cmd_verify_status_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_verify_status_cancel.UseVisualStyleBackColor = false;
			cmd_verify_status_cancel.Click += new System.EventHandler(cmd_verify_status_cancel_Click);
			// 
			// chk_verify_contact
			// 
			chk_verify_contact.AllowDrop = true;
			chk_verify_contact.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_verify_contact.BackColor = System.Drawing.SystemColors.Control;
			chk_verify_contact.CausesValidation = true;
			chk_verify_contact.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_verify_contact.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_verify_contact.Enabled = true;
			chk_verify_contact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_verify_contact.ForeColor = System.Drawing.SystemColors.WindowText;
			chk_verify_contact.Location = new System.Drawing.Point(98, 212);
			chk_verify_contact.Name = "chk_verify_contact";
			chk_verify_contact.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_verify_contact.Size = new System.Drawing.Size(77, 13);
			chk_verify_contact.TabIndex = 22;
			chk_verify_contact.TabStop = true;
			chk_verify_contact.Text = "Contact?";
			chk_verify_contact.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_verify_contact.Visible = false;
			// 
			// cbo_verify_aircraft
			// 
			cbo_verify_aircraft.AllowDrop = true;
			cbo_verify_aircraft.BackColor = System.Drawing.SystemColors.Window;
			cbo_verify_aircraft.CausesValidation = true;
			cbo_verify_aircraft.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_verify_aircraft.Enabled = true;
			cbo_verify_aircraft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_verify_aircraft.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_verify_aircraft.IntegralHeight = true;
			cbo_verify_aircraft.Location = new System.Drawing.Point(15, 308);
			cbo_verify_aircraft.Name = "cbo_verify_aircraft";
			cbo_verify_aircraft.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_verify_aircraft.Size = new System.Drawing.Size(455, 21);
			cbo_verify_aircraft.Sorted = false;
			cbo_verify_aircraft.TabIndex = 21;
			cbo_verify_aircraft.TabStop = true;
			cbo_verify_aircraft.Visible = false;
			// 
			// _opt_verify_aircraft_0
			// 
			_opt_verify_aircraft_0.AllowDrop = true;
			_opt_verify_aircraft_0.BackColor = System.Drawing.SystemColors.Control;
			_opt_verify_aircraft_0.CausesValidation = true;
			_opt_verify_aircraft_0.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			_opt_verify_aircraft_0.Checked = false;
			_opt_verify_aircraft_0.Enabled = true;
			_opt_verify_aircraft_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_opt_verify_aircraft_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_opt_verify_aircraft_0.Location = new System.Drawing.Point(14, 292);
			_opt_verify_aircraft_0.Name = "_opt_verify_aircraft_0";
			_opt_verify_aircraft_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_opt_verify_aircraft_0.Size = new System.Drawing.Size(71, 13);
			_opt_verify_aircraft_0.TabIndex = 20;
			_opt_verify_aircraft_0.TabStop = true;
			_opt_verify_aircraft_0.Text = "No Aircraft";
			_opt_verify_aircraft_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opt_verify_aircraft_0.Visible = false;
			// 
			// _opt_verify_aircraft_1
			// 
			_opt_verify_aircraft_1.AllowDrop = true;
			_opt_verify_aircraft_1.BackColor = System.Drawing.SystemColors.Control;
			_opt_verify_aircraft_1.CausesValidation = true;
			_opt_verify_aircraft_1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			_opt_verify_aircraft_1.Checked = false;
			_opt_verify_aircraft_1.Enabled = true;
			_opt_verify_aircraft_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_opt_verify_aircraft_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_opt_verify_aircraft_1.Location = new System.Drawing.Point(105, 292);
			_opt_verify_aircraft_1.Name = "_opt_verify_aircraft_1";
			_opt_verify_aircraft_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_opt_verify_aircraft_1.Size = new System.Drawing.Size(71, 13);
			_opt_verify_aircraft_1.TabIndex = 19;
			_opt_verify_aircraft_1.TabStop = true;
			_opt_verify_aircraft_1.Text = "Aircraft";
			_opt_verify_aircraft_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opt_verify_aircraft_1.Visible = false;
			// 
			// _opt_verify_aircraft_2
			// 
			_opt_verify_aircraft_2.AllowDrop = true;
			_opt_verify_aircraft_2.BackColor = System.Drawing.SystemColors.Control;
			_opt_verify_aircraft_2.CausesValidation = true;
			_opt_verify_aircraft_2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			_opt_verify_aircraft_2.Checked = false;
			_opt_verify_aircraft_2.Enabled = true;
			_opt_verify_aircraft_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_opt_verify_aircraft_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_opt_verify_aircraft_2.Location = new System.Drawing.Point(195, 292);
			_opt_verify_aircraft_2.Name = "_opt_verify_aircraft_2";
			_opt_verify_aircraft_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_opt_verify_aircraft_2.Size = new System.Drawing.Size(71, 13);
			_opt_verify_aircraft_2.TabIndex = 18;
			_opt_verify_aircraft_2.TabStop = true;
			_opt_verify_aircraft_2.Text = "All Aircraft";
			_opt_verify_aircraft_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opt_verify_aircraft_2.Visible = false;
			// 
			// _opt_verify_aircraft_3
			// 
			_opt_verify_aircraft_3.AllowDrop = true;
			_opt_verify_aircraft_3.BackColor = System.Drawing.SystemColors.Control;
			_opt_verify_aircraft_3.CausesValidation = true;
			_opt_verify_aircraft_3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			_opt_verify_aircraft_3.Checked = false;
			_opt_verify_aircraft_3.Enabled = true;
			_opt_verify_aircraft_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_opt_verify_aircraft_3.ForeColor = System.Drawing.SystemColors.WindowText;
			_opt_verify_aircraft_3.Location = new System.Drawing.Point(286, 292);
			_opt_verify_aircraft_3.Name = "_opt_verify_aircraft_3";
			_opt_verify_aircraft_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_opt_verify_aircraft_3.Size = new System.Drawing.Size(79, 13);
			_opt_verify_aircraft_3.TabIndex = 17;
			_opt_verify_aircraft_3.TabStop = true;
			_opt_verify_aircraft_3.Text = "Primary Only";
			_opt_verify_aircraft_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opt_verify_aircraft_3.Visible = false;
			// 
			// cbo_verify_note_type
			// 
			cbo_verify_note_type.AllowDrop = true;
			cbo_verify_note_type.BackColor = System.Drawing.SystemColors.Window;
			cbo_verify_note_type.CausesValidation = true;
			cbo_verify_note_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_verify_note_type.Enabled = true;
			cbo_verify_note_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_verify_note_type.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_verify_note_type.IntegralHeight = true;
			cbo_verify_note_type.Location = new System.Drawing.Point(94, 154);
			cbo_verify_note_type.Name = "cbo_verify_note_type";
			cbo_verify_note_type.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_verify_note_type.Size = new System.Drawing.Size(380, 21);
			cbo_verify_note_type.Sorted = false;
			cbo_verify_note_type.TabIndex = 16;
			cbo_verify_note_type.TabStop = true;
			cbo_verify_note_type.Visible = true;
			// 
			// _opt_verify_aircraft_4
			// 
			_opt_verify_aircraft_4.AllowDrop = true;
			_opt_verify_aircraft_4.BackColor = System.Drawing.SystemColors.Control;
			_opt_verify_aircraft_4.CausesValidation = true;
			_opt_verify_aircraft_4.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			_opt_verify_aircraft_4.Checked = false;
			_opt_verify_aircraft_4.Enabled = true;
			_opt_verify_aircraft_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_opt_verify_aircraft_4.ForeColor = System.Drawing.SystemColors.WindowText;
			_opt_verify_aircraft_4.Location = new System.Drawing.Point(392, 292);
			_opt_verify_aircraft_4.Name = "_opt_verify_aircraft_4";
			_opt_verify_aircraft_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_opt_verify_aircraft_4.Size = new System.Drawing.Size(55, 13);
			_opt_verify_aircraft_4.TabIndex = 15;
			_opt_verify_aircraft_4.TabStop = true;
			_opt_verify_aircraft_4.Text = "Yacht";
			_opt_verify_aircraft_4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opt_verify_aircraft_4.Visible = false;
			// 
			// cbo_yachts
			// 
			cbo_yachts.AllowDrop = true;
			cbo_yachts.BackColor = System.Drawing.SystemColors.Window;
			cbo_yachts.CausesValidation = true;
			cbo_yachts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_yachts.Enabled = true;
			cbo_yachts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_yachts.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_yachts.IntegralHeight = true;
			cbo_yachts.Location = new System.Drawing.Point(16, 328);
			cbo_yachts.Name = "cbo_yachts";
			cbo_yachts.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_yachts.Size = new System.Drawing.Size(449, 21);
			cbo_yachts.Sorted = false;
			cbo_yachts.TabIndex = 14;
			cbo_yachts.TabStop = true;
			cbo_yachts.Text = "cbo_yachts";
			cbo_yachts.Visible = false;
			// 
			// frame_verify_pnl
			// 
			frame_verify_pnl.AllowDrop = true;
			frame_verify_pnl.BackColor = System.Drawing.SystemColors.Control;
			frame_verify_pnl.Controls.Add(_opt_journal_subject_10);
			frame_verify_pnl.Controls.Add(_opt_journal_subject_11);
			frame_verify_pnl.Controls.Add(_opt_journal_subject_13);
			frame_verify_pnl.Controls.Add(_opt_journal_subject_12);
			frame_verify_pnl.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frame_verify_pnl.Enabled = true;
			frame_verify_pnl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frame_verify_pnl.ForeColor = System.Drawing.SystemColors.WindowText;
			frame_verify_pnl.Location = new System.Drawing.Point(-348, 64);
			frame_verify_pnl.Name = "frame_verify_pnl";
			frame_verify_pnl.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frame_verify_pnl.Size = new System.Drawing.Size(144, 80);
			frame_verify_pnl.TabIndex = 9;
			frame_verify_pnl.Visible = true;
			// 
			// _opt_journal_subject_10
			// 
			_opt_journal_subject_10.AllowDrop = true;
			_opt_journal_subject_10.BackColor = System.Drawing.SystemColors.Control;
			_opt_journal_subject_10.CausesValidation = true;
			_opt_journal_subject_10.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			_opt_journal_subject_10.Checked = false;
			_opt_journal_subject_10.Enabled = true;
			_opt_journal_subject_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_opt_journal_subject_10.ForeColor = System.Drawing.SystemColors.WindowText;
			_opt_journal_subject_10.Location = new System.Drawing.Point(4, 28);
			_opt_journal_subject_10.Name = "_opt_journal_subject_10";
			_opt_journal_subject_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_opt_journal_subject_10.Size = new System.Drawing.Size(134, 13);
			_opt_journal_subject_10.TabIndex = 13;
			_opt_journal_subject_10.TabStop = true;
			_opt_journal_subject_10.Text = "Letter Sent";
			_opt_journal_subject_10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opt_journal_subject_10.Visible = true;
			_opt_journal_subject_10.CheckedChanged += new System.EventHandler(opt_journal_subject_CheckedChanged);
			// 
			// _opt_journal_subject_11
			// 
			_opt_journal_subject_11.AllowDrop = true;
			_opt_journal_subject_11.BackColor = System.Drawing.SystemColors.Control;
			_opt_journal_subject_11.CausesValidation = true;
			_opt_journal_subject_11.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			_opt_journal_subject_11.Checked = false;
			_opt_journal_subject_11.Enabled = true;
			_opt_journal_subject_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_opt_journal_subject_11.ForeColor = System.Drawing.SystemColors.WindowText;
			_opt_journal_subject_11.Location = new System.Drawing.Point(4, 45);
			_opt_journal_subject_11.Name = "_opt_journal_subject_11";
			_opt_journal_subject_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_opt_journal_subject_11.Size = new System.Drawing.Size(134, 13);
			_opt_journal_subject_11.TabIndex = 12;
			_opt_journal_subject_11.TabStop = true;
			_opt_journal_subject_11.Text = "Left Message";
			_opt_journal_subject_11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opt_journal_subject_11.Visible = true;
			_opt_journal_subject_11.CheckedChanged += new System.EventHandler(opt_journal_subject_CheckedChanged);
			// 
			// _opt_journal_subject_13
			// 
			_opt_journal_subject_13.AllowDrop = true;
			_opt_journal_subject_13.BackColor = System.Drawing.SystemColors.Control;
			_opt_journal_subject_13.CausesValidation = true;
			_opt_journal_subject_13.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			_opt_journal_subject_13.Checked = true;
			_opt_journal_subject_13.Enabled = true;
			_opt_journal_subject_13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_opt_journal_subject_13.ForeColor = System.Drawing.SystemColors.WindowText;
			_opt_journal_subject_13.Location = new System.Drawing.Point(4, 62);
			_opt_journal_subject_13.Name = "_opt_journal_subject_13";
			_opt_journal_subject_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_opt_journal_subject_13.Size = new System.Drawing.Size(134, 13);
			_opt_journal_subject_13.TabIndex = 11;
			_opt_journal_subject_13.TabStop = true;
			_opt_journal_subject_13.Text = "Custom Note";
			_opt_journal_subject_13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opt_journal_subject_13.Visible = true;
			_opt_journal_subject_13.CheckedChanged += new System.EventHandler(opt_journal_subject_CheckedChanged);
			// 
			// _opt_journal_subject_12
			// 
			_opt_journal_subject_12.AllowDrop = true;
			_opt_journal_subject_12.BackColor = System.Drawing.SystemColors.Control;
			_opt_journal_subject_12.CausesValidation = true;
			_opt_journal_subject_12.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			_opt_journal_subject_12.Checked = false;
			_opt_journal_subject_12.Enabled = true;
			_opt_journal_subject_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_opt_journal_subject_12.ForeColor = System.Drawing.SystemColors.WindowText;
			_opt_journal_subject_12.Location = new System.Drawing.Point(4, 11);
			_opt_journal_subject_12.Name = "_opt_journal_subject_12";
			_opt_journal_subject_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_opt_journal_subject_12.Size = new System.Drawing.Size(134, 13);
			_opt_journal_subject_12.TabIndex = 10;
			_opt_journal_subject_12.TabStop = true;
			_opt_journal_subject_12.Text = "Still has Shares Per ";
			_opt_journal_subject_12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opt_journal_subject_12.Visible = false;
			_opt_journal_subject_12.CheckedChanged += new System.EventHandler(opt_journal_subject_CheckedChanged);
			// 
			// frm_marketing_note
			// 
			frm_marketing_note.AllowDrop = true;
			frm_marketing_note.BackColor = System.Drawing.SystemColors.Control;
			frm_marketing_note.Controls.Add(txt_marketing_notes);
			frm_marketing_note.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frm_marketing_note.Enabled = true;
			frm_marketing_note.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frm_marketing_note.ForeColor = System.Drawing.SystemColors.ControlText;
			frm_marketing_note.Location = new System.Drawing.Point(8, 264);
			frm_marketing_note.Name = "frm_marketing_note";
			frm_marketing_note.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frm_marketing_note.Size = new System.Drawing.Size(465, 89);
			frm_marketing_note.TabIndex = 7;
			frm_marketing_note.Text = "Marketing Notes";
			frm_marketing_note.Visible = false;
			// 
			// txt_marketing_notes
			// 
			txt_marketing_notes.AcceptsReturn = true;
			txt_marketing_notes.AllowDrop = true;
			txt_marketing_notes.BackColor = System.Drawing.SystemColors.Window;
			txt_marketing_notes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_marketing_notes.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_marketing_notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_marketing_notes.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_marketing_notes.Location = new System.Drawing.Point(8, 16);
			txt_marketing_notes.MaxLength = 0;
			txt_marketing_notes.Multiline = true;
			txt_marketing_notes.Name = "txt_marketing_notes";
			txt_marketing_notes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_marketing_notes.Size = new System.Drawing.Size(449, 65);
			txt_marketing_notes.TabIndex = 8;
			// 
			// _cmd_verify_yacht_2
			// 
			_cmd_verify_yacht_2.AllowDrop = true;
			_cmd_verify_yacht_2.BackColor = System.Drawing.SystemColors.Control;
			_cmd_verify_yacht_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_cmd_verify_yacht_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_cmd_verify_yacht_2.Location = new System.Drawing.Point(320, 362);
			_cmd_verify_yacht_2.Name = "_cmd_verify_yacht_2";
			_cmd_verify_yacht_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_cmd_verify_yacht_2.Size = new System.Drawing.Size(64, 24);
			_cmd_verify_yacht_2.TabIndex = 6;
			_cmd_verify_yacht_2.Text = "Save";
			_cmd_verify_yacht_2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			_cmd_verify_yacht_2.UseVisualStyleBackColor = false;
			_cmd_verify_yacht_2.Visible = false;
			_cmd_verify_yacht_2.Click += new System.EventHandler(cmd_verify_yacht_Click);
			// 
			// cmd_verify_status_save
			// 
			cmd_verify_status_save.AllowDrop = true;
			cmd_verify_status_save.BackColor = System.Drawing.SystemColors.Control;
			cmd_verify_status_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_verify_status_save.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_verify_status_save.Location = new System.Drawing.Point(344, 360);
			cmd_verify_status_save.Name = "cmd_verify_status_save";
			cmd_verify_status_save.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_verify_status_save.Size = new System.Drawing.Size(64, 24);
			cmd_verify_status_save.TabIndex = 5;
			cmd_verify_status_save.Text = "&Save";
			cmd_verify_status_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_verify_status_save.UseVisualStyleBackColor = false;
			cmd_verify_status_save.Click += new System.EventHandler(cmd_verify_status_save_Click);
			// 
			// _opt_journal_subject_1
			// 
			_opt_journal_subject_1.AllowDrop = true;
			_opt_journal_subject_1.BackColor = System.Drawing.SystemColors.Control;
			_opt_journal_subject_1.CausesValidation = true;
			_opt_journal_subject_1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			_opt_journal_subject_1.Checked = false;
			_opt_journal_subject_1.Enabled = true;
			_opt_journal_subject_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_opt_journal_subject_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_opt_journal_subject_1.Location = new System.Drawing.Point(18, 60);
			_opt_journal_subject_1.Name = "_opt_journal_subject_1";
			_opt_journal_subject_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_opt_journal_subject_1.Size = new System.Drawing.Size(133, 19);
			_opt_journal_subject_1.TabIndex = 4;
			_opt_journal_subject_1.TabStop = true;
			_opt_journal_subject_1.Text = "Letter Sent";
			_opt_journal_subject_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opt_journal_subject_1.Visible = true;
			_opt_journal_subject_1.CheckedChanged += new System.EventHandler(opt_journal_subject_CheckedChanged);
			// 
			// _opt_journal_subject_2
			// 
			_opt_journal_subject_2.AllowDrop = true;
			_opt_journal_subject_2.BackColor = System.Drawing.SystemColors.Control;
			_opt_journal_subject_2.CausesValidation = true;
			_opt_journal_subject_2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			_opt_journal_subject_2.Checked = false;
			_opt_journal_subject_2.Enabled = true;
			_opt_journal_subject_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_opt_journal_subject_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_opt_journal_subject_2.Location = new System.Drawing.Point(18, 82);
			_opt_journal_subject_2.Name = "_opt_journal_subject_2";
			_opt_journal_subject_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_opt_journal_subject_2.Size = new System.Drawing.Size(133, 19);
			_opt_journal_subject_2.TabIndex = 3;
			_opt_journal_subject_2.TabStop = true;
			_opt_journal_subject_2.Text = "Left Message";
			_opt_journal_subject_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opt_journal_subject_2.Visible = true;
			_opt_journal_subject_2.CheckedChanged += new System.EventHandler(opt_journal_subject_CheckedChanged);
			// 
			// _opt_journal_subject_3
			// 
			_opt_journal_subject_3.AllowDrop = true;
			_opt_journal_subject_3.BackColor = System.Drawing.SystemColors.Control;
			_opt_journal_subject_3.CausesValidation = true;
			_opt_journal_subject_3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			_opt_journal_subject_3.Checked = true;
			_opt_journal_subject_3.Enabled = true;
			_opt_journal_subject_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_opt_journal_subject_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_opt_journal_subject_3.Location = new System.Drawing.Point(18, 98);
			_opt_journal_subject_3.Name = "_opt_journal_subject_3";
			_opt_journal_subject_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_opt_journal_subject_3.Size = new System.Drawing.Size(133, 19);
			_opt_journal_subject_3.TabIndex = 2;
			_opt_journal_subject_3.TabStop = true;
			_opt_journal_subject_3.Text = "Custom Note";
			_opt_journal_subject_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opt_journal_subject_3.Visible = true;
			_opt_journal_subject_3.CheckedChanged += new System.EventHandler(opt_journal_subject_CheckedChanged);
			// 
			// _opt_journal_subject_0
			// 
			_opt_journal_subject_0.AllowDrop = true;
			_opt_journal_subject_0.BackColor = System.Drawing.SystemColors.Control;
			_opt_journal_subject_0.CausesValidation = true;
			_opt_journal_subject_0.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			_opt_journal_subject_0.Checked = false;
			_opt_journal_subject_0.Enabled = true;
			_opt_journal_subject_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_opt_journal_subject_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_opt_journal_subject_0.Location = new System.Drawing.Point(18, 42);
			_opt_journal_subject_0.Name = "_opt_journal_subject_0";
			_opt_journal_subject_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_opt_journal_subject_0.Size = new System.Drawing.Size(133, 19);
			_opt_journal_subject_0.TabIndex = 1;
			_opt_journal_subject_0.TabStop = true;
			_opt_journal_subject_0.Text = "Still has Shares Per";
			_opt_journal_subject_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opt_journal_subject_0.Visible = true;
			_opt_journal_subject_0.CheckedChanged += new System.EventHandler(opt_journal_subject_CheckedChanged);
			// 
			// _lbl_comp_0
			// 
			_lbl_comp_0.AllowDrop = true;
			_lbl_comp_0.AutoSize = true;
			_lbl_comp_0.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_0.Location = new System.Drawing.Point(165, 32);
			_lbl_comp_0.MinimumSize = new System.Drawing.Size(69, 13);
			_lbl_comp_0.Name = "_lbl_comp_0";
			_lbl_comp_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_0.Size = new System.Drawing.Size(69, 13);
			_lbl_comp_0.TabIndex = 40;
			_lbl_comp_0.Text = "Description:";
			// 
			// _lbl_comp_11
			// 
			_lbl_comp_11.AllowDrop = true;
			_lbl_comp_11.AutoSize = true;
			_lbl_comp_11.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_11.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_11.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_11.Location = new System.Drawing.Point(12, 238);
			_lbl_comp_11.MinimumSize = new System.Drawing.Size(35, 13);
			_lbl_comp_11.Name = "_lbl_comp_11";
			_lbl_comp_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_11.Size = new System.Drawing.Size(35, 13);
			_lbl_comp_11.TabIndex = 38;
			_lbl_comp_11.Tag = "lbl_options";
			_lbl_comp_11.Text = "lbl_11";
			_lbl_comp_11.Visible = false;
			// 
			// _Shape1_0
			// 
			_Shape1_0.AllowDrop = true;
			_Shape1_0.BackColor = System.Drawing.SystemColors.Window;
			_Shape1_0.BackStyle = 0;
			_Shape1_0.BorderStyle = 1;
			_Shape1_0.Enabled = false;
			_Shape1_0.FillColor = System.Drawing.Color.Black;
			_Shape1_0.FillStyle = 1;
			_Shape1_0.Location = new System.Drawing.Point(8, 16);
			_Shape1_0.Name = "_Shape1_0";
			_Shape1_0.Size = new System.Drawing.Size(471, 110);
			_Shape1_0.Visible = true;
			// 
			// _lbl_verify_text_label_75
			// 
			_lbl_verify_text_label_75.AllowDrop = true;
			_lbl_verify_text_label_75.BackColor = System.Drawing.SystemColors.Window;
			_lbl_verify_text_label_75.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_lbl_verify_text_label_75.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_verify_text_label_75.ForeColor = System.Drawing.SystemColors.WindowText;
			_lbl_verify_text_label_75.Location = new System.Drawing.Point(13, 132);
			_lbl_verify_text_label_75.MinimumSize = new System.Drawing.Size(460, 17);
			_lbl_verify_text_label_75.Name = "_lbl_verify_text_label_75";
			_lbl_verify_text_label_75.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_verify_text_label_75.Size = new System.Drawing.Size(460, 17);
			_lbl_verify_text_label_75.TabIndex = 36;
			_lbl_verify_text_label_75.Tag = "N";
			_lbl_verify_text_label_75.Text = "Label75";
			_lbl_verify_text_label_75.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// _lbl_comp_47
			// 
			_lbl_comp_47.AllowDrop = true;
			_lbl_comp_47.AutoSize = true;
			_lbl_comp_47.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_47.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_47.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_47.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_47.Location = new System.Drawing.Point(98, 232);
			_lbl_comp_47.MinimumSize = new System.Drawing.Size(49, 13);
			_lbl_comp_47.Name = "_lbl_comp_47";
			_lbl_comp_47.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_47.Size = new System.Drawing.Size(49, 13);
			_lbl_comp_47.TabIndex = 35;
			_lbl_comp_47.Tag = "lbl_options";
			_lbl_comp_47.Text = "Contact:";
			// 
			// _lbl_comp_48
			// 
			_lbl_comp_48.AllowDrop = true;
			_lbl_comp_48.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_48.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_48.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_48.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_48.Location = new System.Drawing.Point(97, 192);
			_lbl_comp_48.MinimumSize = new System.Drawing.Size(297, 13);
			_lbl_comp_48.Name = "_lbl_comp_48";
			_lbl_comp_48.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_48.Size = new System.Drawing.Size(297, 13);
			_lbl_comp_48.TabIndex = 34;
			_lbl_comp_48.Tag = "lbl_AddThisNoteTo";
			_lbl_comp_48.Text = "Add this note to:";
			_lbl_comp_48.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// _lbl_comp_46
			// 
			_lbl_comp_46.AllowDrop = true;
			_lbl_comp_46.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_46.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_46.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_46.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_46.Location = new System.Drawing.Point(12, 273);
			_lbl_comp_46.MinimumSize = new System.Drawing.Size(461, 13);
			_lbl_comp_46.Name = "_lbl_comp_46";
			_lbl_comp_46.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_46.Size = new System.Drawing.Size(461, 13);
			_lbl_comp_46.TabIndex = 33;
			_lbl_comp_46.Text = "Add this note to:";
			_lbl_comp_46.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// _lbl_comp_17
			// 
			_lbl_comp_17.AllowDrop = true;
			_lbl_comp_17.AutoSize = true;
			_lbl_comp_17.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_17.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_17.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_17.Location = new System.Drawing.Point(12, 158);
			_lbl_comp_17.MinimumSize = new System.Drawing.Size(81, 13);
			_lbl_comp_17.Name = "_lbl_comp_17";
			_lbl_comp_17.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_17.Size = new System.Drawing.Size(81, 13);
			_lbl_comp_17.TabIndex = 32;
			_lbl_comp_17.Text = "Type of Note:";
			// 
			// _lbl_comp_49
			// 
			_lbl_comp_49.AllowDrop = true;
			_lbl_comp_49.AutoSize = true;
			_lbl_comp_49.BackColor = System.Drawing.Color.Transparent;
			_lbl_comp_49.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_comp_49.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_comp_49.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_comp_49.Location = new System.Drawing.Point(17, 23);
			_lbl_comp_49.MinimumSize = new System.Drawing.Size(58, 13);
			_lbl_comp_49.Name = "_lbl_comp_49";
			_lbl_comp_49.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_comp_49.Size = new System.Drawing.Size(58, 13);
			_lbl_comp_49.TabIndex = 31;
			_lbl_comp_49.Text = "Add Note:";
			// 
			// _Shape1_1
			// 
			_Shape1_1.AllowDrop = true;
			_Shape1_1.BackColor = System.Drawing.SystemColors.Window;
			_Shape1_1.BackStyle = 0;
			_Shape1_1.BorderStyle = 1;
			_Shape1_1.Enabled = false;
			_Shape1_1.FillColor = System.Drawing.Color.Black;
			_Shape1_1.FillStyle = 1;
			_Shape1_1.Location = new System.Drawing.Point(88, 184);
			_Shape1_1.Name = "_Shape1_1";
			_Shape1_1.Size = new System.Drawing.Size(312, 74);
			_Shape1_1.Visible = true;
			// 
			// _Shape1_2
			// 
			_Shape1_2.AllowDrop = true;
			_Shape1_2.BackColor = System.Drawing.SystemColors.Window;
			_Shape1_2.BackStyle = 0;
			_Shape1_2.BorderStyle = 1;
			_Shape1_2.Enabled = false;
			_Shape1_2.FillColor = System.Drawing.Color.Black;
			_Shape1_2.FillStyle = 1;
			_Shape1_2.Location = new System.Drawing.Point(8, 269);
			_Shape1_2.Name = "_Shape1_2";
			_Shape1_2.Size = new System.Drawing.Size(469, 86);
			_Shape1_2.Visible = true;
			// 
			// _Shape1_3
			// 
			_Shape1_3.AllowDrop = true;
			_Shape1_3.BackColor = System.Drawing.SystemColors.Window;
			_Shape1_3.BackStyle = 0;
			_Shape1_3.BorderStyle = 1;
			_Shape1_3.Enabled = false;
			_Shape1_3.FillColor = System.Drawing.Color.Black;
			_Shape1_3.FillStyle = 1;
			_Shape1_3.Location = new System.Drawing.Point(10, 38);
			_Shape1_3.Name = "_Shape1_3";
			_Shape1_3.Size = new System.Drawing.Size(151, 82);
			_Shape1_3.Visible = true;
			// 
			// frm_verify_status
			// 
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			ClientSize = new System.Drawing.Size(488, 395);
			Controls.Add(pnl_verify_aircraft_status);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Location = new System.Drawing.Point(433, 230);
			MaximizeBox = true;
			MinimizeBox = true;
			Name = "frm_verify_status";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			Text = "Verify Status";
			commandButtonHelper1.SetStyle(cmd_verify_status_cancel, 0);
			commandButtonHelper1.SetStyle(_cmd_verify_yacht_2, 0);
			commandButtonHelper1.SetStyle(cmd_verify_status_save, 0);
			optionButtonHelper1.SetStyle(_opt_verify_aircraft_0, 0);
			optionButtonHelper1.SetStyle(_opt_verify_aircraft_1, 0);
			optionButtonHelper1.SetStyle(_opt_verify_aircraft_2, 0);
			optionButtonHelper1.SetStyle(_opt_verify_aircraft_3, 0);
			optionButtonHelper1.SetStyle(_opt_verify_aircraft_4, 0);
			optionButtonHelper1.SetStyle(_opt_journal_subject_10, 0);
			optionButtonHelper1.SetStyle(_opt_journal_subject_11, 0);
			optionButtonHelper1.SetStyle(_opt_journal_subject_13, 0);
			optionButtonHelper1.SetStyle(_opt_journal_subject_12, 0);
			optionButtonHelper1.SetStyle(_opt_journal_subject_1, 0);
			optionButtonHelper1.SetStyle(_opt_journal_subject_2, 0);
			optionButtonHelper1.SetStyle(_opt_journal_subject_3, 0);
			optionButtonHelper1.SetStyle(_opt_journal_subject_0, 0);
			Activated += new System.EventHandler(frm_verify_status_Activated);
			Closed += new System.EventHandler(Form_Closed);
			((System.ComponentModel.ISupportInitialize) grd_Company_Aircraft).EndInit();
			pnl_verify_aircraft_status.ResumeLayout(false);
			pnl_verify_aircraft_status.PerformLayout();
			frame_verify_pnl.ResumeLayout(false);
			frame_verify_pnl.PerformLayout();
			frm_marketing_note.ResumeLayout(false);
			frm_marketing_note.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
		void ReLoadForm(bool addEvents)
		{
			Initializepic_verify_ac();
			Initializeopt_verify_aircraft();
			Initializeopt_journal_subject();
			Initializelbl_verify_text_label();
			Initializelbl_comp();
			Initializecmd_verify_yacht();
			InitializeShape1();
		}
		void Initializepic_verify_ac()
		{
			pic_verify_ac = new System.Windows.Forms.PictureBox[4];
			pic_verify_ac[2] = _pic_verify_ac_2;
			pic_verify_ac[3] = _pic_verify_ac_3;
			pic_verify_ac[0] = _pic_verify_ac_0;
			pic_verify_ac[1] = _pic_verify_ac_1;
		}
		void Initializeopt_verify_aircraft()
		{
			opt_verify_aircraft = new System.Windows.Forms.RadioButton[5];
			opt_verify_aircraft[0] = _opt_verify_aircraft_0;
			opt_verify_aircraft[1] = _opt_verify_aircraft_1;
			opt_verify_aircraft[2] = _opt_verify_aircraft_2;
			opt_verify_aircraft[3] = _opt_verify_aircraft_3;
			opt_verify_aircraft[4] = _opt_verify_aircraft_4;
		}
		void Initializeopt_journal_subject()
		{
			opt_journal_subject = new System.Windows.Forms.RadioButton[14];
			opt_journal_subject[10] = _opt_journal_subject_10;
			opt_journal_subject[11] = _opt_journal_subject_11;
			opt_journal_subject[13] = _opt_journal_subject_13;
			opt_journal_subject[12] = _opt_journal_subject_12;
			opt_journal_subject[1] = _opt_journal_subject_1;
			opt_journal_subject[2] = _opt_journal_subject_2;
			opt_journal_subject[3] = _opt_journal_subject_3;
			opt_journal_subject[0] = _opt_journal_subject_0;
		}
		void Initializelbl_verify_text_label()
		{
			lbl_verify_text_label = new System.Windows.Forms.Label[76];
			lbl_verify_text_label[75] = _lbl_verify_text_label_75;
		}
		void Initializelbl_comp()
		{
			lbl_comp = new System.Windows.Forms.Label[50];
			lbl_comp[0] = _lbl_comp_0;
			lbl_comp[11] = _lbl_comp_11;
			lbl_comp[47] = _lbl_comp_47;
			lbl_comp[48] = _lbl_comp_48;
			lbl_comp[46] = _lbl_comp_46;
			lbl_comp[17] = _lbl_comp_17;
			lbl_comp[49] = _lbl_comp_49;
		}
		void Initializecmd_verify_yacht()
		{
			cmd_verify_yacht = new System.Windows.Forms.Button[3];
			cmd_verify_yacht[2] = _cmd_verify_yacht_2;
		}
		void InitializeShape1()
		{
			Shape1 = new UpgradeHelpers.Gui.ShapeHelper[4];
			Shape1[0] = _Shape1_0;
			Shape1[1] = _Shape1_1;
			Shape1[2] = _Shape1_2;
			Shape1[3] = _Shape1_3;
		}
		#endregion
	}
}