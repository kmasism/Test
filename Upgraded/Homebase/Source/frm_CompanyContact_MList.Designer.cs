
namespace JETNET_Homebase
{
	partial class frm_CompanyContact_MList
	{

		#region "Upgrade Support "
		private static frm_CompanyContact_MList m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_CompanyContact_MList DefInstance
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
		public static frm_CompanyContact_MList CreateInstance()
		{
			frm_CompanyContact_MList theInstance = new frm_CompanyContact_MList();
			theInstance.Form_Load();
			return theInstance;
		}
		private string[] visualControls = new string[]{"components", "ToolTipMain", "cmd_Add_Note", "grd_MLNotes", "frame_Note_List", "cbo_Mail_List_Selected", "cmd_Add_ML_Notes", "cmd_cancel", "txt_note_description", "txt_Note_Subject", "Label7", "Label6", "Label5", "frame_Add_Notes", "cmd_close_form", "cmd_Remove_From_List", "cmd_Add_To_List", "cbo_ContactList", "txt_ContactInfo", "txt_CompanyInfo", "lst_MailListActive", "lst_MailListMaster", "lblDoNotSendEMail", "Label4", "Label3", "Label2", "Label1", "listBoxHelper1", "commandButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Button cmd_Add_Note;
		public UpgradeHelpers.DataGridViewFlex grd_MLNotes;
		public System.Windows.Forms.GroupBox frame_Note_List;
		public System.Windows.Forms.ComboBox cbo_Mail_List_Selected;
		public System.Windows.Forms.Button cmd_Add_ML_Notes;
		public System.Windows.Forms.Button cmd_cancel;
		public System.Windows.Forms.TextBox txt_note_description;
		public System.Windows.Forms.TextBox txt_Note_Subject;
		public System.Windows.Forms.Label Label7;
		public System.Windows.Forms.Label Label6;
		public System.Windows.Forms.Label Label5;
		public System.Windows.Forms.GroupBox frame_Add_Notes;
		public System.Windows.Forms.Button cmd_close_form;
		public System.Windows.Forms.Button cmd_Remove_From_List;
		public System.Windows.Forms.Button cmd_Add_To_List;
		public System.Windows.Forms.ComboBox cbo_ContactList;
		public System.Windows.Forms.TextBox txt_ContactInfo;
		public System.Windows.Forms.TextBox txt_CompanyInfo;
		public System.Windows.Forms.ListBox lst_MailListActive;
		public System.Windows.Forms.ListBox lst_MailListMaster;
		public System.Windows.Forms.Label lblDoNotSendEMail;
		public System.Windows.Forms.Label Label4;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label1;
		public UpgradeHelpers.Gui.Controls.ListBoxHelper listBoxHelper1;
		public UpgradeHelpers.Gui.Controls.CommandButtonHelper commandButtonHelper1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_CompanyContact_MList));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			cmd_Add_Note = new System.Windows.Forms.Button();
			frame_Note_List = new System.Windows.Forms.GroupBox();
			grd_MLNotes = new UpgradeHelpers.DataGridViewFlex(components);
			frame_Add_Notes = new System.Windows.Forms.GroupBox();
			cbo_Mail_List_Selected = new System.Windows.Forms.ComboBox();
			cmd_Add_ML_Notes = new System.Windows.Forms.Button();
			cmd_cancel = new System.Windows.Forms.Button();
			txt_note_description = new System.Windows.Forms.TextBox();
			txt_Note_Subject = new System.Windows.Forms.TextBox();
			Label7 = new System.Windows.Forms.Label();
			Label6 = new System.Windows.Forms.Label();
			Label5 = new System.Windows.Forms.Label();
			cmd_close_form = new System.Windows.Forms.Button();
			cmd_Remove_From_List = new System.Windows.Forms.Button();
			cmd_Add_To_List = new System.Windows.Forms.Button();
			cbo_ContactList = new System.Windows.Forms.ComboBox();
			txt_ContactInfo = new System.Windows.Forms.TextBox();
			txt_CompanyInfo = new System.Windows.Forms.TextBox();
			lst_MailListActive = new System.Windows.Forms.ListBox();
			lst_MailListMaster = new System.Windows.Forms.ListBox();
			lblDoNotSendEMail = new System.Windows.Forms.Label();
			Label4 = new System.Windows.Forms.Label();
			Label3 = new System.Windows.Forms.Label();
			Label2 = new System.Windows.Forms.Label();
			Label1 = new System.Windows.Forms.Label();
			frame_Note_List.SuspendLayout();
			frame_Add_Notes.SuspendLayout();
			SuspendLayout();
			listBoxHelper1 = new UpgradeHelpers.Gui.Controls.ListBoxHelper(components);
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
			((System.ComponentModel.ISupportInitialize) grd_MLNotes).BeginInit();
			// 
			// cmd_Add_Note
			// 
			cmd_Add_Note.AllowDrop = true;
			cmd_Add_Note.BackColor = System.Drawing.SystemColors.Control;
			cmd_Add_Note.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Add_Note.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Add_Note.Location = new System.Drawing.Point(288, 304);
			cmd_Add_Note.Name = "cmd_Add_Note";
			cmd_Add_Note.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Add_Note.Size = new System.Drawing.Size(81, 41);
			cmd_Add_Note.TabIndex = 15;
			cmd_Add_Note.Text = "Add Mail List Note";
			cmd_Add_Note.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Add_Note.UseVisualStyleBackColor = false;
			cmd_Add_Note.Click += new System.EventHandler(cmd_Add_Note_Click);
			// 
			// frame_Note_List
			// 
			frame_Note_List.AllowDrop = true;
			frame_Note_List.BackColor = System.Drawing.SystemColors.Control;
			frame_Note_List.Controls.Add(grd_MLNotes);
			frame_Note_List.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frame_Note_List.Enabled = true;
			frame_Note_List.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frame_Note_List.ForeColor = System.Drawing.SystemColors.ControlText;
			frame_Note_List.Location = new System.Drawing.Point(8, 384);
			frame_Note_List.Name = "frame_Note_List";
			frame_Note_List.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frame_Note_List.Size = new System.Drawing.Size(657, 161);
			frame_Note_List.TabIndex = 13;
			frame_Note_List.Text = "Mail List Notes";
			frame_Note_List.Visible = true;
			// 
			// grd_MLNotes
			// 
			grd_MLNotes.AllowDrop = true;
			grd_MLNotes.AllowUserToAddRows = false;
			grd_MLNotes.AllowUserToDeleteRows = false;
			grd_MLNotes.AllowUserToResizeColumns = false;
			grd_MLNotes.AllowUserToResizeRows = false;
			grd_MLNotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_MLNotes.ColumnsCount = 2;
			grd_MLNotes.FixedColumns = 1;
			grd_MLNotes.FixedRows = 1;
			grd_MLNotes.Location = new System.Drawing.Point(8, 16);
			grd_MLNotes.Name = "grd_MLNotes";
			grd_MLNotes.ReadOnly = true;
			grd_MLNotes.RowsCount = 2;
			grd_MLNotes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			grd_MLNotes.ShowCellToolTips = false;
			grd_MLNotes.Size = new System.Drawing.Size(641, 137);
			grd_MLNotes.StandardTab = true;
			grd_MLNotes.TabIndex = 14;
			// 
			// frame_Add_Notes
			// 
			frame_Add_Notes.AllowDrop = true;
			frame_Add_Notes.BackColor = System.Drawing.SystemColors.Control;
			frame_Add_Notes.Controls.Add(cbo_Mail_List_Selected);
			frame_Add_Notes.Controls.Add(cmd_Add_ML_Notes);
			frame_Add_Notes.Controls.Add(cmd_cancel);
			frame_Add_Notes.Controls.Add(txt_note_description);
			frame_Add_Notes.Controls.Add(txt_Note_Subject);
			frame_Add_Notes.Controls.Add(Label7);
			frame_Add_Notes.Controls.Add(Label6);
			frame_Add_Notes.Controls.Add(Label5);
			frame_Add_Notes.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frame_Add_Notes.Enabled = true;
			frame_Add_Notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frame_Add_Notes.ForeColor = System.Drawing.SystemColors.ControlText;
			frame_Add_Notes.Location = new System.Drawing.Point(8, 384);
			frame_Add_Notes.Name = "frame_Add_Notes";
			frame_Add_Notes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frame_Add_Notes.Size = new System.Drawing.Size(649, 153);
			frame_Add_Notes.TabIndex = 12;
			frame_Add_Notes.Text = "Add Mail List Note";
			frame_Add_Notes.Visible = true;
			// 
			// cbo_Mail_List_Selected
			// 
			cbo_Mail_List_Selected.AllowDrop = true;
			cbo_Mail_List_Selected.BackColor = System.Drawing.SystemColors.Window;
			cbo_Mail_List_Selected.CausesValidation = true;
			cbo_Mail_List_Selected.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_Mail_List_Selected.Enabled = true;
			cbo_Mail_List_Selected.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_Mail_List_Selected.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_Mail_List_Selected.IntegralHeight = true;
			cbo_Mail_List_Selected.Location = new System.Drawing.Point(88, 16);
			cbo_Mail_List_Selected.Name = "cbo_Mail_List_Selected";
			cbo_Mail_List_Selected.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_Mail_List_Selected.Size = new System.Drawing.Size(345, 21);
			cbo_Mail_List_Selected.Sorted = false;
			cbo_Mail_List_Selected.TabIndex = 22;
			cbo_Mail_List_Selected.TabStop = true;
			cbo_Mail_List_Selected.Text = "Select Mail List";
			cbo_Mail_List_Selected.Visible = true;
			// 
			// cmd_Add_ML_Notes
			// 
			cmd_Add_ML_Notes.AllowDrop = true;
			cmd_Add_ML_Notes.BackColor = System.Drawing.SystemColors.Control;
			cmd_Add_ML_Notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Add_ML_Notes.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Add_ML_Notes.Location = new System.Drawing.Point(440, 16);
			cmd_Add_ML_Notes.Name = "cmd_Add_ML_Notes";
			cmd_Add_ML_Notes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Add_ML_Notes.Size = new System.Drawing.Size(81, 25);
			cmd_Add_ML_Notes.TabIndex = 21;
			cmd_Add_ML_Notes.Text = "Add Note";
			cmd_Add_ML_Notes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Add_ML_Notes.UseVisualStyleBackColor = false;
			cmd_Add_ML_Notes.Click += new System.EventHandler(cmd_Add_ML_Notes_Click);
			// 
			// cmd_cancel
			// 
			cmd_cancel.AllowDrop = true;
			cmd_cancel.BackColor = System.Drawing.SystemColors.Control;
			cmd_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_cancel.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_cancel.Location = new System.Drawing.Point(552, 16);
			cmd_cancel.Name = "cmd_cancel";
			cmd_cancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_cancel.Size = new System.Drawing.Size(81, 25);
			cmd_cancel.TabIndex = 20;
			cmd_cancel.Text = "Cancel";
			cmd_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_cancel.UseVisualStyleBackColor = false;
			cmd_cancel.Click += new System.EventHandler(cmd_cancel_Click);
			// 
			// txt_note_description
			// 
			txt_note_description.AcceptsReturn = true;
			txt_note_description.AllowDrop = true;
			txt_note_description.BackColor = System.Drawing.SystemColors.Window;
			txt_note_description.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_note_description.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_note_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_note_description.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_note_description.Location = new System.Drawing.Point(88, 80);
			txt_note_description.MaxLength = 0;
			txt_note_description.Multiline = true;
			txt_note_description.Name = "txt_note_description";
			txt_note_description.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_note_description.Size = new System.Drawing.Size(545, 65);
			txt_note_description.TabIndex = 17;
			// 
			// txt_Note_Subject
			// 
			txt_Note_Subject.AcceptsReturn = true;
			txt_Note_Subject.AllowDrop = true;
			txt_Note_Subject.BackColor = System.Drawing.SystemColors.Window;
			txt_Note_Subject.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_Note_Subject.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_Note_Subject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_Note_Subject.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_Note_Subject.Location = new System.Drawing.Point(88, 48);
			txt_Note_Subject.MaxLength = 0;
			txt_Note_Subject.Name = "txt_Note_Subject";
			txt_Note_Subject.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_Note_Subject.Size = new System.Drawing.Size(545, 25);
			txt_Note_Subject.TabIndex = 16;
			// 
			// Label7
			// 
			Label7.AllowDrop = true;
			Label7.BackColor = System.Drawing.Color.Transparent;
			Label7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label7.ForeColor = System.Drawing.SystemColors.ControlText;
			Label7.Location = new System.Drawing.Point(16, 16);
			Label7.MinimumSize = new System.Drawing.Size(41, 25);
			Label7.Name = "Label7";
			Label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label7.Size = new System.Drawing.Size(41, 25);
			Label7.TabIndex = 23;
			Label7.Text = "Mail List:";
			// 
			// Label6
			// 
			Label6.AllowDrop = true;
			Label6.BackColor = System.Drawing.SystemColors.Control;
			Label6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label6.ForeColor = System.Drawing.SystemColors.ControlText;
			Label6.Location = new System.Drawing.Point(16, 80);
			Label6.MinimumSize = new System.Drawing.Size(65, 17);
			Label6.Name = "Label6";
			Label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label6.Size = new System.Drawing.Size(65, 17);
			Label6.TabIndex = 19;
			Label6.Text = "Description:";
			// 
			// Label5
			// 
			Label5.AllowDrop = true;
			Label5.BackColor = System.Drawing.Color.Transparent;
			Label5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label5.ForeColor = System.Drawing.SystemColors.ControlText;
			Label5.Location = new System.Drawing.Point(16, 48);
			Label5.MinimumSize = new System.Drawing.Size(41, 25);
			Label5.Name = "Label5";
			Label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label5.Size = new System.Drawing.Size(41, 25);
			Label5.TabIndex = 18;
			Label5.Text = "Subject:";
			// 
			// cmd_close_form
			// 
			cmd_close_form.AllowDrop = true;
			cmd_close_form.BackColor = System.Drawing.SystemColors.Control;
			cmd_close_form.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_close_form.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_close_form.Location = new System.Drawing.Point(288, 352);
			cmd_close_form.Name = "cmd_close_form";
			cmd_close_form.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_close_form.Size = new System.Drawing.Size(81, 25);
			cmd_close_form.TabIndex = 11;
			cmd_close_form.Text = "Close";
			cmd_close_form.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_close_form.UseVisualStyleBackColor = false;
			cmd_close_form.Click += new System.EventHandler(cmd_close_form_Click);
			// 
			// cmd_Remove_From_List
			// 
			cmd_Remove_From_List.AllowDrop = true;
			cmd_Remove_From_List.BackColor = System.Drawing.SystemColors.Control;
			cmd_Remove_From_List.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Remove_From_List.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Remove_From_List.Location = new System.Drawing.Point(288, 256);
			cmd_Remove_From_List.Name = "cmd_Remove_From_List";
			cmd_Remove_From_List.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Remove_From_List.Size = new System.Drawing.Size(81, 25);
			cmd_Remove_From_List.TabIndex = 6;
			cmd_Remove_From_List.Text = "<< Remove";
			cmd_Remove_From_List.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Remove_From_List.UseVisualStyleBackColor = false;
			cmd_Remove_From_List.Click += new System.EventHandler(cmd_Remove_From_List_Click);
			// 
			// cmd_Add_To_List
			// 
			cmd_Add_To_List.AllowDrop = true;
			cmd_Add_To_List.BackColor = System.Drawing.SystemColors.Control;
			cmd_Add_To_List.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Add_To_List.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Add_To_List.Location = new System.Drawing.Point(288, 216);
			cmd_Add_To_List.Name = "cmd_Add_To_List";
			cmd_Add_To_List.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Add_To_List.Size = new System.Drawing.Size(81, 25);
			cmd_Add_To_List.TabIndex = 5;
			cmd_Add_To_List.Text = "Add >>";
			cmd_Add_To_List.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Add_To_List.UseVisualStyleBackColor = false;
			cmd_Add_To_List.Click += new System.EventHandler(cmd_Add_To_List_Click);
			// 
			// cbo_ContactList
			// 
			cbo_ContactList.AllowDrop = true;
			cbo_ContactList.BackColor = System.Drawing.SystemColors.Window;
			cbo_ContactList.CausesValidation = true;
			cbo_ContactList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_ContactList.Enabled = true;
			cbo_ContactList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_ContactList.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_ContactList.IntegralHeight = true;
			cbo_ContactList.Location = new System.Drawing.Point(336, 24);
			cbo_ContactList.Name = "cbo_ContactList";
			cbo_ContactList.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_ContactList.Size = new System.Drawing.Size(321, 21);
			cbo_ContactList.Sorted = false;
			cbo_ContactList.TabIndex = 4;
			cbo_ContactList.TabStop = true;
			cbo_ContactList.Text = "Combo1";
			cbo_ContactList.Visible = true;
			// 
			// txt_ContactInfo
			// 
			txt_ContactInfo.AcceptsReturn = true;
			txt_ContactInfo.AllowDrop = true;
			txt_ContactInfo.BackColor = System.Drawing.SystemColors.Window;
			txt_ContactInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_ContactInfo.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ContactInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ContactInfo.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ContactInfo.Location = new System.Drawing.Point(336, 48);
			txt_ContactInfo.MaxLength = 0;
			txt_ContactInfo.Multiline = true;
			txt_ContactInfo.Name = "txt_ContactInfo";
			txt_ContactInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ContactInfo.Size = new System.Drawing.Size(321, 97);
			txt_ContactInfo.TabIndex = 3;
			txt_ContactInfo.Text = "ContactInfo";
			// 
			// txt_CompanyInfo
			// 
			txt_CompanyInfo.AcceptsReturn = true;
			txt_CompanyInfo.AllowDrop = true;
			txt_CompanyInfo.BackColor = System.Drawing.SystemColors.Window;
			txt_CompanyInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_CompanyInfo.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_CompanyInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_CompanyInfo.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_CompanyInfo.Location = new System.Drawing.Point(16, 24);
			txt_CompanyInfo.MaxLength = 0;
			txt_CompanyInfo.Multiline = true;
			txt_CompanyInfo.Name = "txt_CompanyInfo";
			txt_CompanyInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_CompanyInfo.Size = new System.Drawing.Size(313, 121);
			txt_CompanyInfo.TabIndex = 2;
			txt_CompanyInfo.Text = "CompanyInfo";
			// 
			// lst_MailListActive
			// 
			lst_MailListActive.AllowDrop = true;
			lst_MailListActive.BackColor = System.Drawing.SystemColors.Window;
			lst_MailListActive.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			lst_MailListActive.CausesValidation = true;
			lst_MailListActive.Enabled = true;
			lst_MailListActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lst_MailListActive.ForeColor = System.Drawing.SystemColors.WindowText;
			lst_MailListActive.IntegralHeight = true;
			lst_MailListActive.Location = new System.Drawing.Point(384, 176);
			lst_MailListActive.MultiColumn = false;
			lst_MailListActive.Name = "lst_MailListActive";
			lst_MailListActive.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lst_MailListActive.Size = new System.Drawing.Size(273, 202);
			lst_MailListActive.Sorted = false;
			lst_MailListActive.TabIndex = 1;
			lst_MailListActive.TabStop = true;
			lst_MailListActive.Visible = true;
			lst_MailListActive.SelectedIndexChanged += new System.EventHandler(lst_MailListActive_SelectedIndexChanged);
			// 
			// lst_MailListMaster
			// 
			lst_MailListMaster.AllowDrop = true;
			lst_MailListMaster.BackColor = System.Drawing.SystemColors.Window;
			lst_MailListMaster.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			lst_MailListMaster.CausesValidation = true;
			lst_MailListMaster.Enabled = true;
			lst_MailListMaster.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lst_MailListMaster.ForeColor = System.Drawing.SystemColors.WindowText;
			lst_MailListMaster.IntegralHeight = true;
			lst_MailListMaster.Location = new System.Drawing.Point(16, 176);
			lst_MailListMaster.MultiColumn = false;
			lst_MailListMaster.Name = "lst_MailListMaster";
			lst_MailListMaster.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lst_MailListMaster.Size = new System.Drawing.Size(257, 202);
			lst_MailListMaster.Sorted = false;
			lst_MailListMaster.TabIndex = 0;
			lst_MailListMaster.TabStop = true;
			lst_MailListMaster.Visible = true;
			lst_MailListMaster.SelectedIndexChanged += new System.EventHandler(lst_MailListMaster_SelectedIndexChanged);
			// 
			// lblDoNotSendEMail
			// 
			lblDoNotSendEMail.AllowDrop = true;
			lblDoNotSendEMail.BackColor = System.Drawing.Color.Transparent;
			lblDoNotSendEMail.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblDoNotSendEMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblDoNotSendEMail.ForeColor = System.Drawing.Color.Red;
			lblDoNotSendEMail.Location = new System.Drawing.Point(240, 156);
			lblDoNotSendEMail.MinimumSize = new System.Drawing.Size(181, 21);
			lblDoNotSendEMail.Name = "lblDoNotSendEMail";
			lblDoNotSendEMail.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblDoNotSendEMail.Size = new System.Drawing.Size(181, 21);
			lblDoNotSendEMail.TabIndex = 24;
			lblDoNotSendEMail.Text = "EMail Is On Do Not Send List";
			lblDoNotSendEMail.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// Label4
			// 
			Label4.AllowDrop = true;
			Label4.BackColor = System.Drawing.Color.Transparent;
			Label4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label4.ForeColor = System.Drawing.SystemColors.ControlText;
			Label4.Location = new System.Drawing.Point(384, 160);
			Label4.MinimumSize = new System.Drawing.Size(265, 25);
			Label4.Name = "Label4";
			Label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label4.Size = new System.Drawing.Size(265, 25);
			Label4.TabIndex = 10;
			Label4.Text = "Assigned Mailing Lists";
			Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// Label3
			// 
			Label3.AllowDrop = true;
			Label3.BackColor = System.Drawing.Color.Transparent;
			Label3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label3.ForeColor = System.Drawing.SystemColors.ControlText;
			Label3.Location = new System.Drawing.Point(16, 160);
			Label3.MinimumSize = new System.Drawing.Size(257, 25);
			Label3.Name = "Label3";
			Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label3.Size = new System.Drawing.Size(257, 25);
			Label3.TabIndex = 9;
			Label3.Text = "Available Mailing Lists";
			Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// Label2
			// 
			Label2.AllowDrop = true;
			Label2.BackColor = System.Drawing.Color.Transparent;
			Label2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label2.ForeColor = System.Drawing.SystemColors.ControlText;
			Label2.Location = new System.Drawing.Point(336, 8);
			Label2.MinimumSize = new System.Drawing.Size(257, 25);
			Label2.Name = "Label2";
			Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label2.Size = new System.Drawing.Size(257, 25);
			Label2.TabIndex = 8;
			Label2.Text = "Contact Information";
			// 
			// Label1
			// 
			Label1.AllowDrop = true;
			Label1.BackColor = System.Drawing.Color.Transparent;
			Label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label1.ForeColor = System.Drawing.SystemColors.ControlText;
			Label1.Location = new System.Drawing.Point(16, 8);
			Label1.MinimumSize = new System.Drawing.Size(257, 25);
			Label1.Name = "Label1";
			Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label1.Size = new System.Drawing.Size(257, 25);
			Label1.TabIndex = 7;
			Label1.Text = "Company Information";
			// 
			// frm_CompanyContact_MList
			// 
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			ClientSize = new System.Drawing.Size(671, 550);
			Controls.Add(cmd_Add_Note);
			Controls.Add(frame_Note_List);
			Controls.Add(frame_Add_Notes);
			Controls.Add(cmd_close_form);
			Controls.Add(cmd_Remove_From_List);
			Controls.Add(cmd_Add_To_List);
			Controls.Add(cbo_ContactList);
			Controls.Add(txt_ContactInfo);
			Controls.Add(txt_CompanyInfo);
			Controls.Add(lst_MailListActive);
			Controls.Add(lst_MailListMaster);
			Controls.Add(lblDoNotSendEMail);
			Controls.Add(Label4);
			Controls.Add(Label3);
			Controls.Add(Label2);
			Controls.Add(Label1);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Location = new System.Drawing.Point(124, 135);
			MaximizeBox = true;
			MinimizeBox = true;
			Name = "frm_CompanyContact_MList";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			Text = "Company/Contact Mailing List";
			commandButtonHelper1.SetStyle(cmd_Add_Note, 0);
			commandButtonHelper1.SetStyle(cmd_Add_ML_Notes, 0);
			commandButtonHelper1.SetStyle(cmd_cancel, 0);
			commandButtonHelper1.SetStyle(cmd_close_form, 0);
			commandButtonHelper1.SetStyle(cmd_Remove_From_List, 0);
			commandButtonHelper1.SetStyle(cmd_Add_To_List, 0);
			listBoxHelper1.SetSelectionMode(lst_MailListActive, System.Windows.Forms.SelectionMode.One);
			listBoxHelper1.SetSelectionMode(lst_MailListMaster, System.Windows.Forms.SelectionMode.One);
			Activated += new System.EventHandler(frm_CompanyContact_MList_Activated);
			Closed += new System.EventHandler(Form_Closed);
			((System.ComponentModel.ISupportInitialize) grd_MLNotes).EndInit();
			frame_Note_List.ResumeLayout(false);
			frame_Note_List.PerformLayout();
			frame_Add_Notes.ResumeLayout(false);
			frame_Add_Notes.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
		#endregion
	}
}