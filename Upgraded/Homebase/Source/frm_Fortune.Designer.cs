
namespace JETNET_Homebase
{
	partial class frm_Fortune
	{

		#region "Upgrade Support "
		private static frm_Fortune m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_Fortune DefInstance
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
		public static frm_Fortune CreateInstance()
		{
			frm_Fortune theInstance = new frm_Fortune();
			theInstance.Form_Load();
			//The MDI form in the VB6 project had its
			//AutoShowChildren property set to True
			//To simulate the VB6 behavior, we need to
			//automatically Show the form whenever it
			//is loaded.  If you do not want this behavior
			//then delete the following line of code
			//UPGRADE_TODO: (2018) Remove the next line of code to stop form from automatically showing. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-2018
			theInstance.Show();
			return theInstance;
		}
		private string[] visualControls = new string[]{"components", "ToolTipMain", "mnuClose", "MainMenu1", "cmdGoToCompany", "cmb_YN", "cmdAddCompany", "cmb_Edit", "txt_EndRank", "txt_StartRank", "chk_edit", "cmdSaveEdits", "ChkRollup", "chkEdit", "txt_edit", "ChkCompID", "cmb_Start_year", "_opOrderBy_1", "_opOrderBy_0", "FrmOrderby", "txt_Comp_id", "cmdExcel", "cmdStop", "cmdDisplay", "grdFortune", "txt_company_name", "txt_Number_to_Display", "txt_prior_year", "_Label6_4", "_Label6_3", "_Label6_2", "_Label6_1", "_Label6_0", "Label5", "Label2", "lblEdit", "lblMsg", "Label4", "Label3", "LblCompare", "Label1", "Label6", "opOrderBy", "optionButtonHelper1", "commandButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.ToolStripMenuItem mnuClose;
		public System.Windows.Forms.MenuStrip MainMenu1;
		public System.Windows.Forms.Button cmdGoToCompany;
		public System.Windows.Forms.ComboBox cmb_YN;
		public System.Windows.Forms.Button cmdAddCompany;
		public System.Windows.Forms.ComboBox cmb_Edit;
		public System.Windows.Forms.TextBox txt_EndRank;
		public System.Windows.Forms.TextBox txt_StartRank;
		public System.Windows.Forms.CheckBox chk_edit;
		public System.Windows.Forms.Button cmdSaveEdits;
		public System.Windows.Forms.CheckBox ChkRollup;
		public System.Windows.Forms.CheckBox chkEdit;
		public System.Windows.Forms.TextBox txt_edit;
		public System.Windows.Forms.CheckBox ChkCompID;
		public System.Windows.Forms.ComboBox cmb_Start_year;
		private System.Windows.Forms.RadioButton _opOrderBy_1;
		private System.Windows.Forms.RadioButton _opOrderBy_0;
		public System.Windows.Forms.GroupBox FrmOrderby;
		public System.Windows.Forms.TextBox txt_Comp_id;
		public System.Windows.Forms.Button cmdExcel;
		public System.Windows.Forms.Button cmdStop;
		public System.Windows.Forms.Button cmdDisplay;
		public UpgradeHelpers.DataGridViewFlex grdFortune;
		public System.Windows.Forms.TextBox txt_company_name;
		public System.Windows.Forms.TextBox txt_Number_to_Display;
		public System.Windows.Forms.TextBox txt_prior_year;
		private System.Windows.Forms.Label _Label6_4;
		private System.Windows.Forms.Label _Label6_3;
		private System.Windows.Forms.Label _Label6_2;
		private System.Windows.Forms.Label _Label6_1;
		private System.Windows.Forms.Label _Label6_0;
		public System.Windows.Forms.Label Label5;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label lblEdit;
		public System.Windows.Forms.Label lblMsg;
		public System.Windows.Forms.Label Label4;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.Label LblCompare;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label[] Label6 = new System.Windows.Forms.Label[5];
		public System.Windows.Forms.RadioButton[] opOrderBy = new System.Windows.Forms.RadioButton[2];
		public UpgradeHelpers.Gui.Controls.OptionButtonHelper optionButtonHelper1;
		public UpgradeHelpers.Gui.Controls.CommandButtonHelper commandButtonHelper1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Fortune));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			MainMenu1 = new System.Windows.Forms.MenuStrip();
			mnuClose = new System.Windows.Forms.ToolStripMenuItem();
			cmdGoToCompany = new System.Windows.Forms.Button();
			cmb_YN = new System.Windows.Forms.ComboBox();
			cmdAddCompany = new System.Windows.Forms.Button();
			cmb_Edit = new System.Windows.Forms.ComboBox();
			txt_EndRank = new System.Windows.Forms.TextBox();
			txt_StartRank = new System.Windows.Forms.TextBox();
			chk_edit = new System.Windows.Forms.CheckBox();
			cmdSaveEdits = new System.Windows.Forms.Button();
			ChkRollup = new System.Windows.Forms.CheckBox();
			chkEdit = new System.Windows.Forms.CheckBox();
			txt_edit = new System.Windows.Forms.TextBox();
			ChkCompID = new System.Windows.Forms.CheckBox();
			cmb_Start_year = new System.Windows.Forms.ComboBox();
			FrmOrderby = new System.Windows.Forms.GroupBox();
			_opOrderBy_1 = new System.Windows.Forms.RadioButton();
			_opOrderBy_0 = new System.Windows.Forms.RadioButton();
			txt_Comp_id = new System.Windows.Forms.TextBox();
			cmdExcel = new System.Windows.Forms.Button();
			cmdStop = new System.Windows.Forms.Button();
			cmdDisplay = new System.Windows.Forms.Button();
			grdFortune = new UpgradeHelpers.DataGridViewFlex(components);
			txt_company_name = new System.Windows.Forms.TextBox();
			txt_Number_to_Display = new System.Windows.Forms.TextBox();
			txt_prior_year = new System.Windows.Forms.TextBox();
			_Label6_4 = new System.Windows.Forms.Label();
			_Label6_3 = new System.Windows.Forms.Label();
			_Label6_2 = new System.Windows.Forms.Label();
			_Label6_1 = new System.Windows.Forms.Label();
			_Label6_0 = new System.Windows.Forms.Label();
			Label5 = new System.Windows.Forms.Label();
			Label2 = new System.Windows.Forms.Label();
			lblEdit = new System.Windows.Forms.Label();
			lblMsg = new System.Windows.Forms.Label();
			Label4 = new System.Windows.Forms.Label();
			Label3 = new System.Windows.Forms.Label();
			LblCompare = new System.Windows.Forms.Label();
			Label1 = new System.Windows.Forms.Label();
			FrmOrderby.SuspendLayout();
			SuspendLayout();
			optionButtonHelper1 = new UpgradeHelpers.Gui.Controls.OptionButtonHelper(components);
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
			((System.ComponentModel.ISupportInitialize) grdFortune).BeginInit();
			// 
			// MainMenu1
			// 
			MainMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[]{mnuClose});
			// 
			// mnuClose
			// 
			mnuClose.Available = true;
			mnuClose.Checked = false;
			mnuClose.Enabled = true;
			mnuClose.Name = "mnuClose";
			mnuClose.Text = "Close";
			mnuClose.Click += new System.EventHandler(mnuClose_Click);
			// 
			// cmdGoToCompany
			// 
			cmdGoToCompany.AllowDrop = true;
			cmdGoToCompany.BackColor = System.Drawing.SystemColors.Control;
			cmdGoToCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdGoToCompany.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdGoToCompany.Location = new System.Drawing.Point(808, 88);
			cmdGoToCompany.Name = "cmdGoToCompany";
			cmdGoToCompany.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdGoToCompany.Size = new System.Drawing.Size(185, 17);
			cmdGoToCompany.TabIndex = 36;
			cmdGoToCompany.Text = "Go to Company";
			cmdGoToCompany.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdGoToCompany.UseVisualStyleBackColor = false;
			cmdGoToCompany.Visible = false;
			cmdGoToCompany.Click += new System.EventHandler(cmdGoToCompany_Click);
			// 
			// cmb_YN
			// 
			cmb_YN.AllowDrop = true;
			cmb_YN.BackColor = System.Drawing.Color.Yellow;
			cmb_YN.CausesValidation = true;
			cmb_YN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cmb_YN.Enabled = true;
			cmb_YN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmb_YN.ForeColor = System.Drawing.Color.Black;
			cmb_YN.IntegralHeight = true;
			cmb_YN.Location = new System.Drawing.Point(208, 159);
			cmb_YN.Name = "cmb_YN";
			cmb_YN.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmb_YN.Size = new System.Drawing.Size(49, 21);
			cmb_YN.Sorted = false;
			cmb_YN.TabIndex = 30;
			cmb_YN.TabStop = true;
			cmb_YN.Visible = false;
			cmb_YN.Enter += new System.EventHandler(cmb_YN_Enter);
			cmb_YN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(cmb_YN_KeyPress);
			cmb_YN.Leave += new System.EventHandler(cmb_YN_Leave);
			// 
			// cmdAddCompany
			// 
			cmdAddCompany.AllowDrop = true;
			cmdAddCompany.BackColor = System.Drawing.SystemColors.Control;
			cmdAddCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdAddCompany.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdAddCompany.Location = new System.Drawing.Point(176, 88);
			cmdAddCompany.Name = "cmdAddCompany";
			cmdAddCompany.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdAddCompany.Size = new System.Drawing.Size(185, 21);
			cmdAddCompany.TabIndex = 19;
			cmdAddCompany.Text = "Add Company to Fortune 1000 List";
			cmdAddCompany.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdAddCompany.UseVisualStyleBackColor = false;
			cmdAddCompany.Visible = false;
			cmdAddCompany.Click += new System.EventHandler(cmdAddCompany_Click);
			// 
			// cmb_Edit
			// 
			cmb_Edit.AllowDrop = true;
			cmb_Edit.BackColor = System.Drawing.Color.Yellow;
			cmb_Edit.CausesValidation = true;
			cmb_Edit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cmb_Edit.Enabled = true;
			cmb_Edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmb_Edit.ForeColor = System.Drawing.Color.Black;
			cmb_Edit.IntegralHeight = true;
			cmb_Edit.Location = new System.Drawing.Point(113, 159);
			cmb_Edit.Name = "cmb_Edit";
			cmb_Edit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmb_Edit.Size = new System.Drawing.Size(81, 21);
			cmb_Edit.Sorted = false;
			cmb_Edit.TabIndex = 29;
			cmb_Edit.TabStop = true;
			cmb_Edit.Visible = false;
			cmb_Edit.Enter += new System.EventHandler(cmb_Edit_Enter);
			cmb_Edit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(cmb_Edit_KeyPress);
			cmb_Edit.Leave += new System.EventHandler(cmb_Edit_Leave);
			// 
			// txt_EndRank
			// 
			txt_EndRank.AcceptsReturn = true;
			txt_EndRank.AllowDrop = true;
			txt_EndRank.BackColor = System.Drawing.SystemColors.Window;
			txt_EndRank.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_EndRank.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_EndRank.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_EndRank.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_EndRank.Location = new System.Drawing.Point(672, 56);
			txt_EndRank.MaxLength = 0;
			txt_EndRank.Name = "txt_EndRank";
			txt_EndRank.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_EndRank.Size = new System.Drawing.Size(41, 19);
			txt_EndRank.TabIndex = 27;
			txt_EndRank.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txt_EndRank_KeyPress);
			// 
			// txt_StartRank
			// 
			txt_StartRank.AcceptsReturn = true;
			txt_StartRank.AllowDrop = true;
			txt_StartRank.BackColor = System.Drawing.SystemColors.Window;
			txt_StartRank.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_StartRank.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_StartRank.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_StartRank.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_StartRank.Location = new System.Drawing.Point(592, 56);
			txt_StartRank.MaxLength = 0;
			txt_StartRank.Name = "txt_StartRank";
			txt_StartRank.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_StartRank.Size = new System.Drawing.Size(41, 19);
			txt_StartRank.TabIndex = 26;
			txt_StartRank.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txt_StartRank_KeyPress);
			// 
			// chk_edit
			// 
			chk_edit.AllowDrop = true;
			chk_edit.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_edit.BackColor = System.Drawing.Color.Yellow;
			chk_edit.CausesValidation = true;
			chk_edit.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			chk_edit.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_edit.Enabled = true;
			chk_edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_edit.ForeColor = System.Drawing.Color.Black;
			chk_edit.Location = new System.Drawing.Point(270, 159);
			chk_edit.Name = "chk_edit";
			chk_edit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_edit.Size = new System.Drawing.Size(33, 21);
			chk_edit.TabIndex = 23;
			chk_edit.TabStop = true;
			chk_edit.Text = "";
			chk_edit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_edit.Visible = false;
			chk_edit.Enter += new System.EventHandler(chk_edit_Enter);
			chk_edit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(chk_edit_KeyPress);
			chk_edit.Leave += new System.EventHandler(chk_edit_Leave);
			// 
			// cmdSaveEdits
			// 
			cmdSaveEdits.AllowDrop = true;
			cmdSaveEdits.BackColor = System.Drawing.SystemColors.Control;
			cmdSaveEdits.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdSaveEdits.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdSaveEdits.Location = new System.Drawing.Point(720, 88);
			cmdSaveEdits.Name = "cmdSaveEdits";
			cmdSaveEdits.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdSaveEdits.Size = new System.Drawing.Size(73, 17);
			cmdSaveEdits.TabIndex = 22;
			cmdSaveEdits.Text = "Save Edits";
			cmdSaveEdits.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdSaveEdits.UseVisualStyleBackColor = false;
			cmdSaveEdits.Visible = false;
			cmdSaveEdits.Click += new System.EventHandler(cmdSaveEdits_Click);
			// 
			// ChkRollup
			// 
			ChkRollup.AllowDrop = true;
			ChkRollup.Appearance = System.Windows.Forms.Appearance.Normal;
			ChkRollup.BackColor = System.Drawing.SystemColors.Control;
			ChkRollup.CausesValidation = true;
			ChkRollup.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			ChkRollup.CheckState = System.Windows.Forms.CheckState.Unchecked;
			ChkRollup.Enabled = true;
			ChkRollup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ChkRollup.ForeColor = System.Drawing.SystemColors.ControlText;
			ChkRollup.Location = new System.Drawing.Point(416, 88);
			ChkRollup.Name = "ChkRollup";
			ChkRollup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			ChkRollup.Size = new System.Drawing.Size(97, 17);
			ChkRollup.TabIndex = 21;
			ChkRollup.TabStop = true;
			ChkRollup.Text = "Show AC Info";
			ChkRollup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			ChkRollup.Visible = true;
			// 
			// chkEdit
			// 
			chkEdit.AllowDrop = true;
			chkEdit.Appearance = System.Windows.Forms.Appearance.Normal;
			chkEdit.BackColor = System.Drawing.SystemColors.Control;
			chkEdit.CausesValidation = true;
			chkEdit.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkEdit.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkEdit.Enabled = true;
			chkEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkEdit.ForeColor = System.Drawing.SystemColors.ControlText;
			chkEdit.Location = new System.Drawing.Point(32, 88);
			chkEdit.Name = "chkEdit";
			chkEdit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkEdit.Size = new System.Drawing.Size(153, 25);
			chkEdit.TabIndex = 20;
			chkEdit.TabStop = true;
			chkEdit.Text = "Display List for Editing";
			chkEdit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkEdit.Visible = true;
			chkEdit.CheckStateChanged += new System.EventHandler(chkEdit_CheckStateChanged);
			// 
			// txt_edit
			// 
			txt_edit.AcceptsReturn = true;
			txt_edit.AllowDrop = true;
			txt_edit.BackColor = System.Drawing.Color.Yellow;
			txt_edit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_edit.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_edit.ForeColor = System.Drawing.Color.Black;
			txt_edit.Location = new System.Drawing.Point(22, 159);
			txt_edit.MaxLength = 10;
			txt_edit.Name = "txt_edit";
			txt_edit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_edit.Size = new System.Drawing.Size(77, 21);
			txt_edit.TabIndex = 18;
			txt_edit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txt_edit.Visible = false;
			txt_edit.Enter += new System.EventHandler(txt_edit_Enter);
			txt_edit.KeyDown += new System.Windows.Forms.KeyEventHandler(txt_edit_KeyDown);
			txt_edit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txt_edit_KeyPress);
			txt_edit.Leave += new System.EventHandler(txt_edit_Leave);
			// 
			// ChkCompID
			// 
			ChkCompID.AllowDrop = true;
			ChkCompID.Appearance = System.Windows.Forms.Appearance.Normal;
			ChkCompID.BackColor = System.Drawing.SystemColors.Control;
			ChkCompID.CausesValidation = true;
			ChkCompID.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			ChkCompID.CheckState = System.Windows.Forms.CheckState.Unchecked;
			ChkCompID.Enabled = true;
			ChkCompID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			ChkCompID.ForeColor = System.Drawing.SystemColors.ControlText;
			ChkCompID.Location = new System.Drawing.Point(546, 27);
			ChkCompID.Name = "ChkCompID";
			ChkCompID.RightToLeft = System.Windows.Forms.RightToLeft.No;
			ChkCompID.Size = new System.Drawing.Size(108, 16);
			ChkCompID.TabIndex = 17;
			ChkCompID.TabStop = true;
			ChkCompID.Text = "Show Comp_id";
			ChkCompID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			ChkCompID.Visible = false;
			ChkCompID.CheckStateChanged += new System.EventHandler(ChkCompID_CheckStateChanged);
			// 
			// cmb_Start_year
			// 
			cmb_Start_year.AllowDrop = true;
			cmb_Start_year.BackColor = System.Drawing.SystemColors.Window;
			cmb_Start_year.CausesValidation = true;
			cmb_Start_year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cmb_Start_year.Enabled = true;
			cmb_Start_year.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmb_Start_year.ForeColor = System.Drawing.SystemColors.WindowText;
			cmb_Start_year.IntegralHeight = true;
			cmb_Start_year.Location = new System.Drawing.Point(91, 27);
			cmb_Start_year.Name = "cmb_Start_year";
			cmb_Start_year.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmb_Start_year.Size = new System.Drawing.Size(70, 21);
			cmb_Start_year.Sorted = false;
			cmb_Start_year.TabIndex = 16;
			cmb_Start_year.TabStop = true;
			cmb_Start_year.Visible = true;
			cmb_Start_year.SelectionChangeCommitted += new System.EventHandler(cmb_Start_year_SelectionChangeCommitted);
			// 
			// FrmOrderby
			// 
			FrmOrderby.AllowDrop = true;
			FrmOrderby.BackColor = System.Drawing.SystemColors.Control;
			FrmOrderby.Controls.Add(_opOrderBy_1);
			FrmOrderby.Controls.Add(_opOrderBy_0);
			FrmOrderby.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			FrmOrderby.Enabled = true;
			FrmOrderby.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			FrmOrderby.ForeColor = System.Drawing.SystemColors.ControlText;
			FrmOrderby.Location = new System.Drawing.Point(796, 43);
			FrmOrderby.Name = "FrmOrderby";
			FrmOrderby.RightToLeft = System.Windows.Forms.RightToLeft.No;
			FrmOrderby.Size = new System.Drawing.Size(136, 35);
			FrmOrderby.TabIndex = 13;
			FrmOrderby.Text = "Order By";
			FrmOrderby.Visible = true;
			// 
			// _opOrderBy_1
			// 
			_opOrderBy_1.AllowDrop = true;
			_opOrderBy_1.BackColor = System.Drawing.SystemColors.Control;
			_opOrderBy_1.CausesValidation = true;
			_opOrderBy_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opOrderBy_1.Checked = true;
			_opOrderBy_1.Enabled = true;
			_opOrderBy_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_opOrderBy_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_opOrderBy_1.Location = new System.Drawing.Point(71, 13);
			_opOrderBy_1.Name = "_opOrderBy_1";
			_opOrderBy_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_opOrderBy_1.Size = new System.Drawing.Size(56, 16);
			_opOrderBy_1.TabIndex = 15;
			_opOrderBy_1.TabStop = true;
			_opOrderBy_1.Text = "Rank";
			_opOrderBy_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opOrderBy_1.Visible = true;
			// 
			// _opOrderBy_0
			// 
			_opOrderBy_0.AllowDrop = true;
			_opOrderBy_0.BackColor = System.Drawing.SystemColors.Control;
			_opOrderBy_0.CausesValidation = true;
			_opOrderBy_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opOrderBy_0.Checked = false;
			_opOrderBy_0.Enabled = true;
			_opOrderBy_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_opOrderBy_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_opOrderBy_0.Location = new System.Drawing.Point(13, 14);
			_opOrderBy_0.Name = "_opOrderBy_0";
			_opOrderBy_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_opOrderBy_0.Size = new System.Drawing.Size(56, 16);
			_opOrderBy_0.TabIndex = 14;
			_opOrderBy_0.TabStop = true;
			_opOrderBy_0.Text = "Name";
			_opOrderBy_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_opOrderBy_0.Visible = true;
			// 
			// txt_Comp_id
			// 
			txt_Comp_id.AcceptsReturn = true;
			txt_Comp_id.AllowDrop = true;
			txt_Comp_id.BackColor = System.Drawing.SystemColors.Window;
			txt_Comp_id.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_Comp_id.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_Comp_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_Comp_id.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_Comp_id.Location = new System.Drawing.Point(764, 56);
			txt_Comp_id.MaxLength = 0;
			txt_Comp_id.Name = "txt_Comp_id";
			txt_Comp_id.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_Comp_id.Size = new System.Drawing.Size(20, 20);
			txt_Comp_id.TabIndex = 11;
			txt_Comp_id.Text = "0";
			txt_Comp_id.Visible = false;
			// 
			// cmdExcel
			// 
			cmdExcel.AllowDrop = true;
			cmdExcel.BackColor = System.Drawing.SystemColors.Control;
			cmdExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdExcel.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdExcel.Location = new System.Drawing.Point(176, 48);
			cmdExcel.Name = "cmdExcel";
			cmdExcel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdExcel.Size = new System.Drawing.Size(111, 21);
			cmdExcel.TabIndex = 10;
			cmdExcel.Text = "Export To Excel";
			cmdExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdExcel.UseVisualStyleBackColor = false;
			cmdExcel.Visible = false;
			cmdExcel.Click += new System.EventHandler(cmdExcel_Click);
			// 
			// cmdStop
			// 
			cmdStop.AllowDrop = true;
			cmdStop.BackColor = System.Drawing.SystemColors.Control;
			cmdStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdStop.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdStop.Location = new System.Drawing.Point(104, 48);
			cmdStop.Name = "cmdStop";
			cmdStop.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdStop.Size = new System.Drawing.Size(61, 21);
			cmdStop.TabIndex = 9;
			cmdStop.Text = "Stop";
			cmdStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdStop.UseVisualStyleBackColor = false;
			cmdStop.Visible = false;
			cmdStop.Click += new System.EventHandler(cmdStop_Click);
			// 
			// cmdDisplay
			// 
			cmdDisplay.AllowDrop = true;
			cmdDisplay.BackColor = System.Drawing.SystemColors.Control;
			cmdDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdDisplay.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdDisplay.Location = new System.Drawing.Point(32, 48);
			cmdDisplay.Name = "cmdDisplay";
			cmdDisplay.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdDisplay.Size = new System.Drawing.Size(49, 21);
			cmdDisplay.TabIndex = 8;
			cmdDisplay.Text = "Display";
			cmdDisplay.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdDisplay.UseVisualStyleBackColor = false;
			cmdDisplay.Click += new System.EventHandler(cmdDisplay_Click);
			// 
			// grdFortune
			// 
			grdFortune.AllowDrop = true;
			grdFortune.AllowUserToAddRows = false;
			grdFortune.AllowUserToDeleteRows = false;
			grdFortune.AllowUserToResizeColumns = false;
			grdFortune.AllowUserToResizeColumns = grdFortune.ColumnHeadersVisible;
			grdFortune.AllowUserToResizeRows = false;
			grdFortune.AllowUserToResizeRows = false;
			grdFortune.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grdFortune.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grdFortune.ColumnsCount = 2;
			grdFortune.FixedColumns = 0;
			grdFortune.FixedRows = 1;
			grdFortune.Location = new System.Drawing.Point(16, 120);
			grdFortune.Name = "grdFortune";
			grdFortune.ReadOnly = true;
			grdFortune.RowsCount = 2;
			grdFortune.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			grdFortune.ShowCellToolTips = false;
			grdFortune.Size = new System.Drawing.Size(965, 421);
			grdFortune.StandardTab = true;
			grdFortune.TabIndex = 7;
			grdFortune.Click += new System.EventHandler(grdFortune_Click);
			grdFortune.DoubleClick += new System.EventHandler(grdFortune_DoubleClick);
			grdFortune.GotFocus += new System.EventHandler(grdFortune_GotFocus);
			grdFortune.LostFocus += new System.EventHandler(grdFortune_LostFocus);
			grdFortune.Scroll += new System.Windows.Forms.ScrollEventHandler(grdFortune_Scroll);
			// 
			// txt_company_name
			// 
			txt_company_name.AcceptsReturn = true;
			txt_company_name.AllowDrop = true;
			txt_company_name.BackColor = System.Drawing.SystemColors.Window;
			txt_company_name.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_company_name.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_company_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_company_name.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_company_name.Location = new System.Drawing.Point(787, 26);
			txt_company_name.MaxLength = 0;
			txt_company_name.Name = "txt_company_name";
			txt_company_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_company_name.Size = new System.Drawing.Size(136, 19);
			txt_company_name.TabIndex = 6;
			txt_company_name.Leave += new System.EventHandler(txt_company_name_Leave);
			// 
			// txt_Number_to_Display
			// 
			txt_Number_to_Display.AcceptsReturn = true;
			txt_Number_to_Display.AllowDrop = true;
			txt_Number_to_Display.BackColor = System.Drawing.SystemColors.Window;
			txt_Number_to_Display.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_Number_to_Display.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_Number_to_Display.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_Number_to_Display.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_Number_to_Display.Location = new System.Drawing.Point(480, 24);
			txt_Number_to_Display.MaxLength = 0;
			txt_Number_to_Display.Name = "txt_Number_to_Display";
			txt_Number_to_Display.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_Number_to_Display.Size = new System.Drawing.Size(47, 19);
			txt_Number_to_Display.TabIndex = 4;
			txt_Number_to_Display.Leave += new System.EventHandler(txt_Number_to_Display_Leave);
			// 
			// txt_prior_year
			// 
			txt_prior_year.AcceptsReturn = true;
			txt_prior_year.AllowDrop = true;
			txt_prior_year.BackColor = System.Drawing.SystemColors.Window;
			txt_prior_year.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_prior_year.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_prior_year.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_prior_year.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_prior_year.Location = new System.Drawing.Point(243, 27);
			txt_prior_year.MaxLength = 0;
			txt_prior_year.Name = "txt_prior_year";
			txt_prior_year.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_prior_year.Size = new System.Drawing.Size(61, 19);
			txt_prior_year.TabIndex = 1;
			txt_prior_year.Leave += new System.EventHandler(txt_prior_year_Leave);
			// 
			// _Label6_4
			// 
			_Label6_4.AllowDrop = true;
			_Label6_4.BackColor = System.Drawing.Color.FromArgb(128, 128, 255);
			_Label6_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label6_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label6_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label6_4.Location = new System.Drawing.Point(448, 544);
			_Label6_4.MinimumSize = new System.Drawing.Size(73, 17);
			_Label6_4.Name = "_Label6_4";
			_Label6_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label6_4.Size = new System.Drawing.Size(73, 17);
			_Label6_4.TabIndex = 35;
			_Label6_4.Text = "Missing Data";
			// 
			// _Label6_3
			// 
			_Label6_3.AllowDrop = true;
			_Label6_3.BackColor = System.Drawing.Color.Fuchsia;
			_Label6_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label6_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label6_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label6_3.Location = new System.Drawing.Point(248, 544);
			_Label6_3.MinimumSize = new System.Drawing.Size(97, 17);
			_Label6_3.Name = "_Label6_3";
			_Label6_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label6_3.Size = new System.Drawing.Size(97, 17);
			_Label6_3.TabIndex = 34;
			_Label6_3.Text = "Duplicate Ranks";
			// 
			// _Label6_2
			// 
			_Label6_2.AllowDrop = true;
			_Label6_2.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			_Label6_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label6_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label6_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label6_2.Location = new System.Drawing.Point(168, 544);
			_Label6_2.MinimumSize = new System.Drawing.Size(73, 17);
			_Label6_2.Name = "_Label6_2";
			_Label6_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label6_2.Size = new System.Drawing.Size(73, 17);
			_Label6_2.TabIndex = 33;
			_Label6_2.Text = "Gap In Rank";
			// 
			// _Label6_1
			// 
			_Label6_1.AllowDrop = true;
			_Label6_1.BackColor = System.Drawing.Color.Lime;
			_Label6_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label6_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label6_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label6_1.Location = new System.Drawing.Point(24, 544);
			_Label6_1.MinimumSize = new System.Drawing.Size(129, 17);
			_Label6_1.Name = "_Label6_1";
			_Label6_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label6_1.Size = new System.Drawing.Size(129, 17);
			_Label6_1.TabIndex = 32;
			_Label6_1.Text = "Column Can Be Edited";
			// 
			// _Label6_0
			// 
			_Label6_0.AllowDrop = true;
			_Label6_0.BackColor = System.Drawing.Color.White;
			_Label6_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label6_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label6_0.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
			_Label6_0.Location = new System.Drawing.Point(352, 544);
			_Label6_0.MinimumSize = new System.Drawing.Size(89, 17);
			_Label6_0.Name = "_Label6_0";
			_Label6_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label6_0.Size = new System.Drawing.Size(89, 17);
			_Label6_0.TabIndex = 31;
			_Label6_0.Text = "Rank Unavailable";
			// 
			// Label5
			// 
			Label5.AllowDrop = true;
			Label5.BackColor = System.Drawing.SystemColors.Control;
			Label5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label5.ForeColor = System.Drawing.SystemColors.ControlText;
			Label5.Location = new System.Drawing.Point(640, 56);
			Label5.MinimumSize = new System.Drawing.Size(25, 17);
			Label5.Name = "Label5";
			Label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label5.Size = new System.Drawing.Size(25, 17);
			Label5.TabIndex = 28;
			Label5.Text = "Thru";
			// 
			// Label2
			// 
			Label2.AllowDrop = true;
			Label2.BackColor = System.Drawing.SystemColors.Control;
			Label2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label2.ForeColor = System.Drawing.SystemColors.ControlText;
			Label2.Location = new System.Drawing.Point(544, 48);
			Label2.MinimumSize = new System.Drawing.Size(49, 33);
			Label2.Name = "Label2";
			Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label2.Size = new System.Drawing.Size(49, 33);
			Label2.TabIndex = 25;
			Label2.Text = "Show Ranks:";
			// 
			// lblEdit
			// 
			lblEdit.AllowDrop = true;
			lblEdit.BackColor = System.Drawing.SystemColors.Control;
			lblEdit.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblEdit.ForeColor = System.Drawing.Color.Red;
			lblEdit.Location = new System.Drawing.Point(512, 80);
			lblEdit.MinimumSize = new System.Drawing.Size(193, 33);
			lblEdit.Name = "lblEdit";
			lblEdit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblEdit.Size = new System.Drawing.Size(193, 33);
			lblEdit.TabIndex = 24;
			lblEdit.Text = "Press the  <Tab>  key to Exit the edited cell";
			lblEdit.Visible = false;
			// 
			// lblMsg
			// 
			lblMsg.AllowDrop = true;
			lblMsg.BackColor = System.Drawing.SystemColors.Control;
			lblMsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblMsg.ForeColor = System.Drawing.SystemColors.ControlText;
			lblMsg.Location = new System.Drawing.Point(304, 48);
			lblMsg.MinimumSize = new System.Drawing.Size(189, 33);
			lblMsg.Name = "lblMsg";
			lblMsg.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblMsg.Size = new System.Drawing.Size(189, 33);
			lblMsg.TabIndex = 12;
			lblMsg.Text = "xx";
			// 
			// Label4
			// 
			Label4.AllowDrop = true;
			Label4.BackColor = System.Drawing.SystemColors.Control;
			Label4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label4.ForeColor = System.Drawing.SystemColors.ControlText;
			Label4.Location = new System.Drawing.Point(675, 26);
			Label4.MinimumSize = new System.Drawing.Size(107, 21);
			Label4.Name = "Label4";
			Label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label4.Size = new System.Drawing.Size(107, 21);
			Label4.TabIndex = 5;
			Label4.Text = "Company Name like:";
			// 
			// Label3
			// 
			Label3.AllowDrop = true;
			Label3.BackColor = System.Drawing.SystemColors.Control;
			Label3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label3.ForeColor = System.Drawing.SystemColors.ControlText;
			Label3.Location = new System.Drawing.Point(316, 25);
			Label3.MinimumSize = new System.Drawing.Size(162, 22);
			Label3.Name = "Label3";
			Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label3.Size = new System.Drawing.Size(162, 22);
			Label3.TabIndex = 3;
			Label3.Text = "Number of Companies to Display:";
			// 
			// LblCompare
			// 
			LblCompare.AllowDrop = true;
			LblCompare.BackColor = System.Drawing.SystemColors.Control;
			LblCompare.BorderStyle = System.Windows.Forms.BorderStyle.None;
			LblCompare.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			LblCompare.ForeColor = System.Drawing.SystemColors.ControlText;
			LblCompare.Location = new System.Drawing.Point(167, 27);
			LblCompare.MinimumSize = new System.Drawing.Size(86, 16);
			LblCompare.Name = "LblCompare";
			LblCompare.RightToLeft = System.Windows.Forms.RightToLeft.No;
			LblCompare.Size = new System.Drawing.Size(86, 16);
			LblCompare.TabIndex = 2;
			LblCompare.Text = "Compare Year:";
			// 
			// Label1
			// 
			Label1.AllowDrop = true;
			Label1.BackColor = System.Drawing.SystemColors.Control;
			Label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label1.ForeColor = System.Drawing.SystemColors.ControlText;
			Label1.Location = new System.Drawing.Point(5, 27);
			Label1.MinimumSize = new System.Drawing.Size(81, 18);
			Label1.Name = "Label1";
			Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label1.Size = new System.Drawing.Size(81, 18);
			Label1.TabIndex = 0;
			Label1.Text = "Year of Interest:";
			Label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// frm_Fortune
			// 
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			BackColor = System.Drawing.SystemColors.Control;
			ClientSize = new System.Drawing.Size(995, 580);
			Controls.Add(cmdGoToCompany);
			Controls.Add(cmb_YN);
			Controls.Add(cmdAddCompany);
			Controls.Add(cmb_Edit);
			Controls.Add(txt_EndRank);
			Controls.Add(txt_StartRank);
			Controls.Add(chk_edit);
			Controls.Add(cmdSaveEdits);
			Controls.Add(ChkRollup);
			Controls.Add(chkEdit);
			Controls.Add(txt_edit);
			Controls.Add(ChkCompID);
			Controls.Add(cmb_Start_year);
			Controls.Add(FrmOrderby);
			Controls.Add(txt_Comp_id);
			Controls.Add(cmdExcel);
			Controls.Add(cmdStop);
			Controls.Add(cmdDisplay);
			Controls.Add(grdFortune);
			Controls.Add(txt_company_name);
			Controls.Add(txt_Number_to_Display);
			Controls.Add(txt_prior_year);
			Controls.Add(_Label6_4);
			Controls.Add(_Label6_3);
			Controls.Add(_Label6_2);
			Controls.Add(_Label6_1);
			Controls.Add(_Label6_0);
			Controls.Add(Label5);
			Controls.Add(Label2);
			Controls.Add(lblEdit);
			Controls.Add(lblMsg);
			Controls.Add(Label4);
			Controls.Add(Label3);
			Controls.Add(LblCompare);
			Controls.Add(Label1);
			Controls.Add(MainMenu1);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Location = new System.Drawing.Point(214, 278);
			MaximizeBox = true;
			MinimizeBox = true;
			Name = "frm_Fortune";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			Text = "Fortune 1000";
			commandButtonHelper1.SetStyle(cmdGoToCompany, 0);
			commandButtonHelper1.SetStyle(cmdAddCompany, 0);
			commandButtonHelper1.SetStyle(cmdSaveEdits, 0);
			commandButtonHelper1.SetStyle(cmdExcel, 0);
			commandButtonHelper1.SetStyle(cmdStop, 0);
			commandButtonHelper1.SetStyle(cmdDisplay, 0);
			optionButtonHelper1.SetStyle(_opOrderBy_1, 0);
			optionButtonHelper1.SetStyle(_opOrderBy_0, 0);
			Activated += new System.EventHandler(Form_Activated);
			Closed += new System.EventHandler(Form_Closed);
			((System.ComponentModel.ISupportInitialize) grdFortune).EndInit();
			FrmOrderby.ResumeLayout(false);
			FrmOrderby.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
		void ReLoadForm(bool addEvents)
		{
			InitializeopOrderBy();
			InitializeLabel6();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			MdiParent = JETNET_Homebase.mdi_ResearchAssistant.DefInstance;
			JETNET_Homebase.mdi_ResearchAssistant.DefInstance.Show();
		}
		void InitializeopOrderBy()
		{
			opOrderBy = new System.Windows.Forms.RadioButton[2];
			opOrderBy[1] = _opOrderBy_1;
			opOrderBy[0] = _opOrderBy_0;
		}
		void InitializeLabel6()
		{
			Label6 = new System.Windows.Forms.Label[5];
			Label6[4] = _Label6_4;
			Label6[3] = _Label6_3;
			Label6[2] = _Label6_2;
			Label6[1] = _Label6_1;
			Label6[0] = _Label6_0;
		}
		#endregion
	}
}