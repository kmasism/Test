
namespace JETNET_Homebase
{
	partial class frm_AircraftPictures
	{

		#region "Upgrade Support "
		private static frm_AircraftPictures m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_AircraftPictures DefInstance
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
		public static frm_AircraftPictures CreateInstance()
		{
			frm_AircraftPictures theInstance = new frm_AircraftPictures();
			theInstance.Form_Load();
			return theInstance;
		}
		private string[] visualControls = new string[]{"components", "ToolTipMain", "cmd_refresh", "cmd_upload_multiple", "cmd_add_subject", "cbo_subject_add", "cbo_subject_drop", "cmdClose", "cmdAdd", "cmdSave", "cmdRemove", "frmAction", "hide_all_button", "chkAutoResize", "txtUserId", "frmAddPicture", "Chk_ShowAll", "cmdUp", "cmdDown", "chkHide", "txtSubject", "txtDate", "lstACPics", "_lbl_pic_1", "_lbl_pic_0", "lblViewAllActivePictures", "lblOpenOriginalImageDirectory", "lblUserId", "lblFileName", "lblDate", "lblSubject", "imgACPicture", "lblACPictures", "lbl_pic", "listBoxHelper1", "commandButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Button cmd_refresh;
		public System.Windows.Forms.Button cmd_upload_multiple;
		public System.Windows.Forms.Button cmd_add_subject;
		public System.Windows.Forms.ComboBox cbo_subject_add;
		public System.Windows.Forms.ComboBox cbo_subject_drop;
		public System.Windows.Forms.Button cmdClose;
		public System.Windows.Forms.Button cmdAdd;
		public System.Windows.Forms.Button cmdSave;
		public System.Windows.Forms.Button cmdRemove;
		public System.Windows.Forms.GroupBox frmAction;
		public System.Windows.Forms.Button hide_all_button;
		public System.Windows.Forms.CheckBox chkAutoResize;
		public System.Windows.Forms.TextBox txtUserId;
		public System.Windows.Forms.GroupBox frmAddPicture;
		public System.Windows.Forms.CheckBox Chk_ShowAll;
		public System.Windows.Forms.Button cmdUp;
		public System.Windows.Forms.Button cmdDown;
		public System.Windows.Forms.CheckBox chkHide;
		public System.Windows.Forms.TextBox txtSubject;
		public System.Windows.Forms.TextBox txtDate;
		public System.Windows.Forms.ListBox lstACPics;
		private System.Windows.Forms.Label _lbl_pic_1;
		private System.Windows.Forms.Label _lbl_pic_0;
		public System.Windows.Forms.Label lblViewAllActivePictures;
		public System.Windows.Forms.Label lblOpenOriginalImageDirectory;
		public System.Windows.Forms.Label lblUserId;
		public System.Windows.Forms.Label lblFileName;
		public System.Windows.Forms.Label lblDate;
		public System.Windows.Forms.Label lblSubject;
		public System.Windows.Forms.PictureBox imgACPicture;
		public System.Windows.Forms.Label lblACPictures;
		public System.Windows.Forms.Label[] lbl_pic = new System.Windows.Forms.Label[2];
		public UpgradeHelpers.Gui.Controls.ListBoxHelper listBoxHelper1;
		public UpgradeHelpers.Gui.Controls.CommandButtonHelper commandButtonHelper1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_AircraftPictures));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			cmd_refresh = new System.Windows.Forms.Button();
			cmd_upload_multiple = new System.Windows.Forms.Button();
			cmd_add_subject = new System.Windows.Forms.Button();
			cbo_subject_add = new System.Windows.Forms.ComboBox();
			cbo_subject_drop = new System.Windows.Forms.ComboBox();
			frmAction = new System.Windows.Forms.GroupBox();
			cmdClose = new System.Windows.Forms.Button();
			cmdAdd = new System.Windows.Forms.Button();
			cmdSave = new System.Windows.Forms.Button();
			cmdRemove = new System.Windows.Forms.Button();
			hide_all_button = new System.Windows.Forms.Button();
			chkAutoResize = new System.Windows.Forms.CheckBox();
			txtUserId = new System.Windows.Forms.TextBox();
			frmAddPicture = new System.Windows.Forms.GroupBox();
			Chk_ShowAll = new System.Windows.Forms.CheckBox();
			cmdUp = new System.Windows.Forms.Button();
			cmdDown = new System.Windows.Forms.Button();
			chkHide = new System.Windows.Forms.CheckBox();
			txtSubject = new System.Windows.Forms.TextBox();
			txtDate = new System.Windows.Forms.TextBox();
			lstACPics = new System.Windows.Forms.ListBox();
			_lbl_pic_1 = new System.Windows.Forms.Label();
			_lbl_pic_0 = new System.Windows.Forms.Label();
			lblViewAllActivePictures = new System.Windows.Forms.Label();
			lblOpenOriginalImageDirectory = new System.Windows.Forms.Label();
			lblUserId = new System.Windows.Forms.Label();
			lblFileName = new System.Windows.Forms.Label();
			lblDate = new System.Windows.Forms.Label();
			lblSubject = new System.Windows.Forms.Label();
			imgACPicture = new System.Windows.Forms.PictureBox();
			lblACPictures = new System.Windows.Forms.Label();
			frmAction.SuspendLayout();
			SuspendLayout();
			listBoxHelper1 = new UpgradeHelpers.Gui.Controls.ListBoxHelper(components);
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
			// 
			// cmd_refresh
			// 
			cmd_refresh.AllowDrop = true;
			cmd_refresh.BackColor = System.Drawing.SystemColors.Control;
			cmd_refresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_refresh.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_refresh.Location = new System.Drawing.Point(8, 192);
			cmd_refresh.Name = "cmd_refresh";
			cmd_refresh.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_refresh.Size = new System.Drawing.Size(65, 25);
			cmd_refresh.TabIndex = 29;
			cmd_refresh.Text = "Refresh";
			cmd_refresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_refresh.UseVisualStyleBackColor = false;
			cmd_refresh.Click += new System.EventHandler(cmd_refresh_Click);
			// 
			// cmd_upload_multiple
			// 
			cmd_upload_multiple.AllowDrop = true;
			cmd_upload_multiple.BackColor = System.Drawing.SystemColors.Control;
			cmd_upload_multiple.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_upload_multiple.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_upload_multiple.Location = new System.Drawing.Point(624, 112);
			cmd_upload_multiple.Name = "cmd_upload_multiple";
			cmd_upload_multiple.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_upload_multiple.Size = new System.Drawing.Size(81, 41);
			cmd_upload_multiple.TabIndex = 28;
			cmd_upload_multiple.Text = "Upload ++";
			cmd_upload_multiple.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_upload_multiple.UseVisualStyleBackColor = false;
			cmd_upload_multiple.Click += new System.EventHandler(cmd_upload_multiple_Click);
			// 
			// cmd_add_subject
			// 
			cmd_add_subject.AllowDrop = true;
			cmd_add_subject.BackColor = System.Drawing.SystemColors.Control;
			cmd_add_subject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_add_subject.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_add_subject.Location = new System.Drawing.Point(752, 200);
			cmd_add_subject.Name = "cmd_add_subject";
			cmd_add_subject.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_add_subject.Size = new System.Drawing.Size(73, 24);
			cmd_add_subject.TabIndex = 27;
			cmd_add_subject.Text = "Add";
			cmd_add_subject.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_add_subject.UseVisualStyleBackColor = false;
			cmd_add_subject.Visible = false;
			cmd_add_subject.Click += new System.EventHandler(cmd_add_subject_Click);
			// 
			// cbo_subject_add
			// 
			cbo_subject_add.AllowDrop = true;
			cbo_subject_add.BackColor = System.Drawing.SystemColors.Window;
			cbo_subject_add.CausesValidation = true;
			cbo_subject_add.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_subject_add.Enabled = true;
			cbo_subject_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_subject_add.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_subject_add.IntegralHeight = true;
			cbo_subject_add.Location = new System.Drawing.Point(656, 176);
			cbo_subject_add.Name = "cbo_subject_add";
			cbo_subject_add.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_subject_add.Size = new System.Drawing.Size(169, 21);
			cbo_subject_add.Sorted = false;
			cbo_subject_add.TabIndex = 24;
			cbo_subject_add.TabStop = true;
			cbo_subject_add.Visible = false;
			// 
			// cbo_subject_drop
			// 
			cbo_subject_drop.AllowDrop = true;
			cbo_subject_drop.BackColor = System.Drawing.SystemColors.Window;
			cbo_subject_drop.CausesValidation = true;
			cbo_subject_drop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_subject_drop.Enabled = true;
			cbo_subject_drop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_subject_drop.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_subject_drop.IntegralHeight = true;
			cbo_subject_drop.Location = new System.Drawing.Point(88, 128);
			cbo_subject_drop.Name = "cbo_subject_drop";
			cbo_subject_drop.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_subject_drop.Size = new System.Drawing.Size(521, 21);
			cbo_subject_drop.Sorted = false;
			cbo_subject_drop.TabIndex = 23;
			cbo_subject_drop.TabStop = true;
			cbo_subject_drop.Visible = true;
			cbo_subject_drop.SelectionChangeCommitted += new System.EventHandler(cbo_subject_drop_SelectionChangeCommitted);
			cbo_subject_drop.TextChanged += new System.EventHandler(cbo_subject_drop_TextChanged);
			// 
			// frmAction
			// 
			frmAction.AllowDrop = true;
			frmAction.BackColor = System.Drawing.SystemColors.Control;
			frmAction.Controls.Add(cmdClose);
			frmAction.Controls.Add(cmdAdd);
			frmAction.Controls.Add(cmdSave);
			frmAction.Controls.Add(cmdRemove);
			frmAction.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmAction.Enabled = true;
			frmAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmAction.ForeColor = System.Drawing.SystemColors.ControlText;
			frmAction.Location = new System.Drawing.Point(716, 8);
			frmAction.Name = "frmAction";
			frmAction.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmAction.Size = new System.Drawing.Size(101, 149);
			frmAction.TabIndex = 18;
			frmAction.Text = "Action";
			frmAction.Visible = true;
			// 
			// cmdClose
			// 
			cmdClose.AllowDrop = true;
			cmdClose.BackColor = System.Drawing.SystemColors.Control;
			cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdClose.Location = new System.Drawing.Point(11, 105);
			cmdClose.Name = "cmdClose";
			cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdClose.Size = new System.Drawing.Size(79, 25);
			cmdClose.TabIndex = 22;
			cmdClose.Text = "&Close";
			cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdClose.UseVisualStyleBackColor = false;
			cmdClose.Click += new System.EventHandler(cmdClose_Click);
			// 
			// cmdAdd
			// 
			cmdAdd.AllowDrop = true;
			cmdAdd.BackColor = System.Drawing.SystemColors.Control;
			cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdAdd.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdAdd.Location = new System.Drawing.Point(11, 20);
			cmdAdd.Name = "cmdAdd";
			cmdAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdAdd.Size = new System.Drawing.Size(79, 25);
			cmdAdd.TabIndex = 21;
			cmdAdd.Text = "&Add";
			cmdAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdAdd.UseVisualStyleBackColor = false;
			cmdAdd.Click += new System.EventHandler(cmdAdd_Click);
			// 
			// cmdSave
			// 
			cmdSave.AllowDrop = true;
			cmdSave.BackColor = System.Drawing.SystemColors.Control;
			cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdSave.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdSave.Location = new System.Drawing.Point(11, 77);
			cmdSave.Name = "cmdSave";
			cmdSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdSave.Size = new System.Drawing.Size(79, 25);
			cmdSave.TabIndex = 20;
			cmdSave.Text = "&Save";
			cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdSave.UseVisualStyleBackColor = false;
			cmdSave.Click += new System.EventHandler(cmdSave_Click);
			// 
			// cmdRemove
			// 
			cmdRemove.AllowDrop = true;
			cmdRemove.BackColor = System.Drawing.SystemColors.Control;
			cmdRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdRemove.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdRemove.Location = new System.Drawing.Point(11, 49);
			cmdRemove.Name = "cmdRemove";
			cmdRemove.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdRemove.Size = new System.Drawing.Size(79, 25);
			cmdRemove.TabIndex = 19;
			cmdRemove.Text = "&Remove";
			cmdRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdRemove.UseVisualStyleBackColor = false;
			cmdRemove.Click += new System.EventHandler(cmdRemove_Click);
			// 
			// hide_all_button
			// 
			hide_all_button.AllowDrop = true;
			hide_all_button.BackColor = System.Drawing.SystemColors.Control;
			hide_all_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			hide_all_button.ForeColor = System.Drawing.SystemColors.ControlText;
			hide_all_button.Location = new System.Drawing.Point(8, 678);
			hide_all_button.Name = "hide_all_button";
			hide_all_button.RightToLeft = System.Windows.Forms.RightToLeft.No;
			hide_all_button.Size = new System.Drawing.Size(113, 21);
			hide_all_button.TabIndex = 17;
			hide_all_button.Text = "Hide All Images";
			hide_all_button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			hide_all_button.UseVisualStyleBackColor = false;
			hide_all_button.Click += new System.EventHandler(hide_all_button_Click);
			// 
			// chkAutoResize
			// 
			chkAutoResize.AllowDrop = true;
			chkAutoResize.Appearance = System.Windows.Forms.Appearance.Normal;
			chkAutoResize.BackColor = System.Drawing.SystemColors.Control;
			chkAutoResize.CausesValidation = true;
			chkAutoResize.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkAutoResize.CheckState = System.Windows.Forms.CheckState.Checked;
			chkAutoResize.Enabled = true;
			chkAutoResize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkAutoResize.ForeColor = System.Drawing.SystemColors.ControlText;
			chkAutoResize.Location = new System.Drawing.Point(526, 156);
			chkAutoResize.Name = "chkAutoResize";
			chkAutoResize.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkAutoResize.Size = new System.Drawing.Size(80, 13);
			chkAutoResize.TabIndex = 16;
			chkAutoResize.TabStop = true;
			chkAutoResize.Text = "Auto Resize";
			chkAutoResize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkAutoResize.Visible = true;
			// 
			// txtUserId
			// 
			txtUserId.AcceptsReturn = true;
			txtUserId.AllowDrop = true;
			txtUserId.BackColor = System.Drawing.SystemColors.Window;
			txtUserId.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtUserId.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtUserId.Enabled = false;
			txtUserId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtUserId.ForeColor = System.Drawing.SystemColors.WindowText;
			txtUserId.Location = new System.Drawing.Point(297, 153);
			txtUserId.MaxLength = 0;
			txtUserId.Name = "txtUserId";
			txtUserId.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtUserId.Size = new System.Drawing.Size(55, 17);
			txtUserId.TabIndex = 13;
			txtUserId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// frmAddPicture
			// 
			frmAddPicture.AllowDrop = true;
			frmAddPicture.BackColor = System.Drawing.SystemColors.Control;
			frmAddPicture.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmAddPicture.Enabled = true;
			frmAddPicture.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmAddPicture.ForeColor = System.Drawing.SystemColors.ControlText;
			frmAddPicture.Location = new System.Drawing.Point(612, 24);
			frmAddPicture.Name = "frmAddPicture";
			frmAddPicture.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmAddPicture.Size = new System.Drawing.Size(102, 81);
			frmAddPicture.TabIndex = 11;
			frmAddPicture.Text = "Drop New Picture";
			frmAddPicture.Visible = true;
			frmAddPicture.DoubleClick += new System.EventHandler(frmAddPicture_DoubleClick);
			// 
			// Chk_ShowAll
			// 
			Chk_ShowAll.AllowDrop = true;
			Chk_ShowAll.Appearance = System.Windows.Forms.Appearance.Normal;
			Chk_ShowAll.BackColor = System.Drawing.SystemColors.Control;
			Chk_ShowAll.CausesValidation = true;
			Chk_ShowAll.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			Chk_ShowAll.CheckState = System.Windows.Forms.CheckState.Unchecked;
			Chk_ShowAll.Enabled = true;
			Chk_ShowAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Chk_ShowAll.ForeColor = System.Drawing.SystemColors.ControlText;
			Chk_ShowAll.Location = new System.Drawing.Point(382, 156);
			Chk_ShowAll.Name = "Chk_ShowAll";
			Chk_ShowAll.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Chk_ShowAll.Size = new System.Drawing.Size(113, 13);
			Chk_ShowAll.TabIndex = 10;
			Chk_ShowAll.TabStop = true;
			Chk_ShowAll.Text = "Display All Pictures";
			Chk_ShowAll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			Chk_ShowAll.Visible = true;
			Chk_ShowAll.CheckStateChanged += new System.EventHandler(Chk_ShowAll_CheckStateChanged);
			// 
			// cmdUp
			// 
			cmdUp.AllowDrop = true;
			cmdUp.BackColor = System.Drawing.SystemColors.Control;
			cmdUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdUp.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdUp.Image = (System.Drawing.Image) resources.GetObject("cmdUp.Image");
			cmdUp.Location = new System.Drawing.Point(7, 29);
			cmdUp.Name = "cmdUp";
			cmdUp.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdUp.Size = new System.Drawing.Size(43, 33);
			cmdUp.TabIndex = 8;
			cmdUp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdUp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdUp.UseVisualStyleBackColor = false;
			cmdUp.Click += new System.EventHandler(cmdUp_Click);
			// 
			// cmdDown
			// 
			cmdDown.AllowDrop = true;
			cmdDown.BackColor = System.Drawing.SystemColors.Control;
			cmdDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdDown.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdDown.Image = (System.Drawing.Image) resources.GetObject("cmdDown.Image");
			cmdDown.Location = new System.Drawing.Point(7, 69);
			cmdDown.Name = "cmdDown";
			cmdDown.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdDown.Size = new System.Drawing.Size(43, 33);
			cmdDown.TabIndex = 7;
			cmdDown.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdDown.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdDown.UseVisualStyleBackColor = false;
			cmdDown.Click += new System.EventHandler(cmdDown_Click);
			// 
			// chkHide
			// 
			chkHide.AllowDrop = true;
			chkHide.Appearance = System.Windows.Forms.Appearance.Normal;
			chkHide.BackColor = System.Drawing.SystemColors.Control;
			chkHide.CausesValidation = true;
			chkHide.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkHide.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkHide.Enabled = true;
			chkHide.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkHide.ForeColor = System.Drawing.SystemColors.ControlText;
			chkHide.Location = new System.Drawing.Point(93, 156);
			chkHide.Name = "chkHide";
			chkHide.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkHide.Size = new System.Drawing.Size(126, 13);
			chkHide.TabIndex = 3;
			chkHide.TabStop = true;
			chkHide.Text = "Hide From Customers";
			chkHide.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkHide.Visible = true;
			chkHide.CheckStateChanged += new System.EventHandler(chkHide_CheckStateChanged);
			// 
			// txtSubject
			// 
			txtSubject.AcceptsReturn = true;
			txtSubject.AllowDrop = true;
			txtSubject.BackColor = System.Drawing.SystemColors.Window;
			txtSubject.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtSubject.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtSubject.ForeColor = System.Drawing.SystemColors.WindowText;
			txtSubject.Location = new System.Drawing.Point(92, 127);
			txtSubject.MaxLength = 120;
			txtSubject.Name = "txtSubject";
			txtSubject.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtSubject.Size = new System.Drawing.Size(514, 22);
			txtSubject.TabIndex = 2;
			txtSubject.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtSubject_KeyPress);
			// 
			// txtDate
			// 
			txtDate.AcceptsReturn = true;
			txtDate.AllowDrop = true;
			txtDate.BackColor = System.Drawing.SystemColors.Window;
			txtDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtDate.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtDate.ForeColor = System.Drawing.SystemColors.WindowText;
			txtDate.Location = new System.Drawing.Point(10, 147);
			txtDate.MaxLength = 0;
			txtDate.Name = "txtDate";
			txtDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtDate.Size = new System.Drawing.Size(73, 20);
			txtDate.TabIndex = 1;
			txtDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtDate_KeyPress);
			// 
			// lstACPics
			// 
			lstACPics.AllowDrop = true;
			lstACPics.BackColor = System.Drawing.SystemColors.Window;
			lstACPics.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lstACPics.CausesValidation = true;
			lstACPics.Enabled = true;
			lstACPics.Font = new System.Drawing.Font("Courier New", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lstACPics.ForeColor = System.Drawing.SystemColors.WindowText;
			lstACPics.IntegralHeight = true;
			lstACPics.Location = new System.Drawing.Point(56, 21);
			lstACPics.MultiColumn = false;
			lstACPics.Name = "lstACPics";
			lstACPics.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lstACPics.Size = new System.Drawing.Size(555, 89);
			lstACPics.Sorted = false;
			lstACPics.TabIndex = 0;
			lstACPics.TabStop = true;
			lstACPics.Visible = true;
			lstACPics.SelectedIndexChanged += new System.EventHandler(lstACPics_SelectedIndexChanged);
			// 
			// _lbl_pic_1
			// 
			_lbl_pic_1.AllowDrop = true;
			_lbl_pic_1.BackColor = System.Drawing.SystemColors.Control;
			_lbl_pic_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_pic_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_pic_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_pic_1.Location = new System.Drawing.Point(632, 160);
			_lbl_pic_1.MinimumSize = new System.Drawing.Size(193, 17);
			_lbl_pic_1.Name = "_lbl_pic_1";
			_lbl_pic_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_pic_1.Size = new System.Drawing.Size(193, 17);
			_lbl_pic_1.TabIndex = 26;
			_lbl_pic_1.Text = "Please Enter A Subject for This Picture";
			_lbl_pic_1.Visible = false;
			// 
			// _lbl_pic_0
			// 
			_lbl_pic_0.AllowDrop = true;
			_lbl_pic_0.BackColor = System.Drawing.SystemColors.Control;
			_lbl_pic_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_pic_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_pic_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_pic_0.Location = new System.Drawing.Point(616, 176);
			_lbl_pic_0.MinimumSize = new System.Drawing.Size(41, 17);
			_lbl_pic_0.Name = "_lbl_pic_0";
			_lbl_pic_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_pic_0.Size = new System.Drawing.Size(41, 17);
			_lbl_pic_0.TabIndex = 25;
			_lbl_pic_0.Text = "Subject";
			_lbl_pic_0.Visible = false;
			// 
			// lblViewAllActivePictures
			// 
			lblViewAllActivePictures.AllowDrop = true;
			lblViewAllActivePictures.AutoSize = true;
			lblViewAllActivePictures.BackColor = System.Drawing.SystemColors.Control;
			lblViewAllActivePictures.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblViewAllActivePictures.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblViewAllActivePictures.ForeColor = System.Drawing.Color.Blue;
			lblViewAllActivePictures.Location = new System.Drawing.Point(375, 111);
			lblViewAllActivePictures.MinimumSize = new System.Drawing.Size(112, 13);
			lblViewAllActivePictures.Name = "lblViewAllActivePictures";
			lblViewAllActivePictures.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblViewAllActivePictures.Size = new System.Drawing.Size(112, 13);
			lblViewAllActivePictures.TabIndex = 15;
			lblViewAllActivePictures.Text = "View All Active Pictures";
			lblViewAllActivePictures.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			lblViewAllActivePictures.Click += new System.EventHandler(lblViewAllActivePictures_Click);
			// 
			// lblOpenOriginalImageDirectory
			// 
			lblOpenOriginalImageDirectory.AllowDrop = true;
			lblOpenOriginalImageDirectory.AutoSize = true;
			lblOpenOriginalImageDirectory.BackColor = System.Drawing.SystemColors.Control;
			lblOpenOriginalImageDirectory.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblOpenOriginalImageDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblOpenOriginalImageDirectory.ForeColor = System.Drawing.Color.Blue;
			lblOpenOriginalImageDirectory.Location = new System.Drawing.Point(196, 111);
			lblOpenOriginalImageDirectory.MinimumSize = new System.Drawing.Size(142, 13);
			lblOpenOriginalImageDirectory.Name = "lblOpenOriginalImageDirectory";
			lblOpenOriginalImageDirectory.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblOpenOriginalImageDirectory.Size = new System.Drawing.Size(142, 13);
			lblOpenOriginalImageDirectory.TabIndex = 14;
			lblOpenOriginalImageDirectory.Text = "Open Original Image Directory";
			lblOpenOriginalImageDirectory.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			lblOpenOriginalImageDirectory.Click += new System.EventHandler(lblOpenOriginalImageDirectory_Click);
			// 
			// lblUserId
			// 
			lblUserId.AllowDrop = true;
			lblUserId.AutoSize = true;
			lblUserId.BackColor = System.Drawing.SystemColors.Control;
			lblUserId.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblUserId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblUserId.ForeColor = System.Drawing.SystemColors.ControlText;
			lblUserId.Location = new System.Drawing.Point(249, 156);
			lblUserId.MinimumSize = new System.Drawing.Size(43, 13);
			lblUserId.Name = "lblUserId";
			lblUserId.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblUserId.Size = new System.Drawing.Size(43, 13);
			lblUserId.TabIndex = 12;
			lblUserId.Text = "User Id";
			// 
			// lblFileName
			// 
			lblFileName.AllowDrop = true;
			lblFileName.AutoSize = true;
			lblFileName.BackColor = System.Drawing.SystemColors.Control;
			lblFileName.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblFileName.ForeColor = System.Drawing.SystemColors.ControlText;
			lblFileName.Location = new System.Drawing.Point(371, 5);
			lblFileName.MinimumSize = new System.Drawing.Size(84, 13);
			lblFileName.Name = "lblFileName";
			lblFileName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblFileName.Size = new System.Drawing.Size(84, 13);
			lblFileName.TabIndex = 9;
			lblFileName.Text = "Hide     File Name";
			// 
			// lblDate
			// 
			lblDate.AllowDrop = true;
			lblDate.AutoSize = true;
			lblDate.BackColor = System.Drawing.SystemColors.Control;
			lblDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblDate.ForeColor = System.Drawing.SystemColors.ControlText;
			lblDate.Location = new System.Drawing.Point(15, 117);
			lblDate.MinimumSize = new System.Drawing.Size(66, 26);
			lblDate.Name = "lblDate";
			lblDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblDate.Size = new System.Drawing.Size(66, 26);
			lblDate.TabIndex = 6;
			lblDate.Text = "Date Picture was added:";
			lblDate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lblSubject
			// 
			lblSubject.AllowDrop = true;
			lblSubject.AutoSize = true;
			lblSubject.BackColor = System.Drawing.SystemColors.Control;
			lblSubject.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblSubject.ForeColor = System.Drawing.SystemColors.ControlText;
			lblSubject.Location = new System.Drawing.Point(92, 111);
			lblSubject.MinimumSize = new System.Drawing.Size(39, 13);
			lblSubject.Name = "lblSubject";
			lblSubject.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblSubject.Size = new System.Drawing.Size(39, 13);
			lblSubject.TabIndex = 5;
			lblSubject.Text = "Subject:";
			// 
			// imgACPicture
			// 
			imgACPicture.AllowDrop = true;
			imgACPicture.BorderStyle = System.Windows.Forms.BorderStyle.None;
			imgACPicture.Enabled = true;
			imgACPicture.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			imgACPicture.Location = new System.Drawing.Point(0, 228);
			imgACPicture.Name = "imgACPicture";
			imgACPicture.Size = new System.Drawing.Size(800, 441);
			imgACPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			imgACPicture.Visible = true;
			// 
			// lblACPictures
			// 
			lblACPictures.AllowDrop = true;
			lblACPictures.AutoSize = true;
			lblACPictures.BackColor = System.Drawing.SystemColors.Control;
			lblACPictures.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblACPictures.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblACPictures.ForeColor = System.Drawing.SystemColors.ControlText;
			lblACPictures.Location = new System.Drawing.Point(54, 5);
			lblACPictures.MinimumSize = new System.Drawing.Size(74, 13);
			lblACPictures.Name = "lblACPictures";
			lblACPictures.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblACPictures.Size = new System.Drawing.Size(74, 13);
			lblACPictures.TabIndex = 4;
			lblACPictures.Text = "Aircraft Pictures";
			// 
			// frm_AircraftPictures
			// 
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			ClientSize = new System.Drawing.Size(847, 705);
			ControlBox = false;
			Controls.Add(cmd_refresh);
			Controls.Add(cmd_upload_multiple);
			Controls.Add(cmd_add_subject);
			Controls.Add(cbo_subject_add);
			Controls.Add(cbo_subject_drop);
			Controls.Add(frmAction);
			Controls.Add(hide_all_button);
			Controls.Add(chkAutoResize);
			Controls.Add(txtUserId);
			Controls.Add(frmAddPicture);
			Controls.Add(Chk_ShowAll);
			Controls.Add(cmdUp);
			Controls.Add(cmdDown);
			Controls.Add(chkHide);
			Controls.Add(txtSubject);
			Controls.Add(txtDate);
			Controls.Add(lstACPics);
			Controls.Add(_lbl_pic_1);
			Controls.Add(_lbl_pic_0);
			Controls.Add(lblViewAllActivePictures);
			Controls.Add(lblOpenOriginalImageDirectory);
			Controls.Add(lblUserId);
			Controls.Add(lblFileName);
			Controls.Add(lblDate);
			Controls.Add(lblSubject);
			Controls.Add(imgACPicture);
			Controls.Add(lblACPictures);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			Location = new System.Drawing.Point(923, 157);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "frm_AircraftPictures";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			Text = "Aircraft Pictures";
			commandButtonHelper1.SetStyle(cmd_refresh, 0);
			commandButtonHelper1.SetStyle(cmd_upload_multiple, 0);
			commandButtonHelper1.SetStyle(cmd_add_subject, 0);
			commandButtonHelper1.SetStyle(cmdClose, 0);
			commandButtonHelper1.SetStyle(cmdAdd, 0);
			commandButtonHelper1.SetStyle(cmdSave, 0);
			commandButtonHelper1.SetStyle(cmdRemove, 0);
			commandButtonHelper1.SetStyle(hide_all_button, 0);
			commandButtonHelper1.SetStyle(cmdUp, 1);
			commandButtonHelper1.SetStyle(cmdDown, 1);
			listBoxHelper1.SetSelectionMode(lstACPics, System.Windows.Forms.SelectionMode.One);
			ToolTipMain.SetToolTip(frmAddPicture, "Drag Aircraft Picture Here To Add or Double Click To Open Browse Window");
			ToolTipMain.SetToolTip(lblViewAllActivePictures, "Click To View Page With All Active Pictures");
			ToolTipMain.SetToolTip(lblOpenOriginalImageDirectory, "Click To Open The Original Picture Image Directory");
			Activated += new System.EventHandler(frm_AircraftPictures_Activated);
			Closed += new System.EventHandler(Form_Closed);
			frmAction.ResumeLayout(false);
			frmAction.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
		void ReLoadForm(bool addEvents) => Initializelbl_pic();

		void Initializelbl_pic()
		{
			lbl_pic = new System.Windows.Forms.Label[2];
			lbl_pic[1] = _lbl_pic_1;
			lbl_pic[0] = _lbl_pic_0;
		}
		#endregion
	}
}