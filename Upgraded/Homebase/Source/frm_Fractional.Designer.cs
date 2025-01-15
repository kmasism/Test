
namespace JETNET_Homebase
{
	partial class frm_Fractional
	{

		#region "Upgrade Support "
		private static frm_Fractional m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_Fractional DefInstance
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
		public static frm_Fractional CreateInstance()
		{
			frm_Fractional theInstance = new frm_Fractional();
			theInstance.Form_Load();
			return theInstance;
		}
		private string[] visualControls = new string[]{"components", "ToolTipMain", "mnuClose", "mnuFile", "MainMenu1", "chkDead", "chkShowInactive", "Chk_IncludeSS", "Chk_ShowTransactions", "chk_analyze", "Chk_internal", "cmdStop", "FG_Transactions", "_TranPrefix_0", "_TranPrefix_1", "_TranPrefix_2", "Frame1", "chk_FindOtherWS", "_DetailTab_TabPage0", "GrdSubscribers", "_DetailTab_TabPage1", "_Opt_notinTable_4", "_Opt_notinTable_3", "_Opt_notinTable_2", "_Opt_notinTable_1", "_Opt_notinTable_0", "Frame2", "GrdNotInTable", "LBLNotCount", "_DetailTab_TabPage2", "DetailTab", "cmdAircraft", "cmb_Models", "cmdFracProgram", "chk_history", "FG_ProgAircraft", "FG_ProgCompany", "cmdRefresh", "lblStatus", "LblOther", "lblTrans", "lblModels", "FLeetAC", "PMPHCompanies", "Label4", "Label2", "Label1", "Label40", "Opt_notinTable", "TranPrefix", "listBoxHelper1", "optionButtonHelper1", "commandButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.ToolStripMenuItem mnuClose;
		public System.Windows.Forms.ToolStripMenuItem mnuFile;
		public System.Windows.Forms.MenuStrip MainMenu1;
		public System.Windows.Forms.CheckBox chkDead;
		public System.Windows.Forms.CheckBox chkShowInactive;
		public System.Windows.Forms.CheckBox Chk_IncludeSS;
		public System.Windows.Forms.CheckBox Chk_ShowTransactions;
		public System.Windows.Forms.CheckBox chk_analyze;
		public System.Windows.Forms.CheckBox Chk_internal;
		public System.Windows.Forms.Button cmdStop;
		public UpgradeHelpers.DataGridViewFlex FG_Transactions;
		private System.Windows.Forms.RadioButton _TranPrefix_0;
		private System.Windows.Forms.RadioButton _TranPrefix_1;
		private System.Windows.Forms.RadioButton _TranPrefix_2;
		public System.Windows.Forms.GroupBox Frame1;
		public System.Windows.Forms.CheckBox chk_FindOtherWS;
		private System.Windows.Forms.TabPage _DetailTab_TabPage0;
		public UpgradeHelpers.DataGridViewFlex GrdSubscribers;
		private System.Windows.Forms.TabPage _DetailTab_TabPage1;
		private System.Windows.Forms.RadioButton _Opt_notinTable_4;
		private System.Windows.Forms.RadioButton _Opt_notinTable_3;
		private System.Windows.Forms.RadioButton _Opt_notinTable_2;
		private System.Windows.Forms.RadioButton _Opt_notinTable_1;
		private System.Windows.Forms.RadioButton _Opt_notinTable_0;
		public System.Windows.Forms.GroupBox Frame2;
		public UpgradeHelpers.DataGridViewFlex GrdNotInTable;
		public System.Windows.Forms.Label LBLNotCount;
		private System.Windows.Forms.TabPage _DetailTab_TabPage2;
		public UpgradeHelpers.Gui.Controls.TabControlExtension DetailTab;
		public System.Windows.Forms.Button cmdAircraft;
		public System.Windows.Forms.ListBox cmb_Models;
		public System.Windows.Forms.ListBox cmdFracProgram;
		public System.Windows.Forms.CheckBox chk_history;
		public UpgradeHelpers.DataGridViewFlex FG_ProgAircraft;
		public UpgradeHelpers.DataGridViewFlex FG_ProgCompany;
		public System.Windows.Forms.Button cmdRefresh;
		public System.Windows.Forms.Label lblStatus;
		public System.Windows.Forms.Label LblOther;
		public System.Windows.Forms.Label lblTrans;
		public System.Windows.Forms.Label lblModels;
		public System.Windows.Forms.Label FLeetAC;
		public System.Windows.Forms.Label PMPHCompanies;
		public System.Windows.Forms.Label Label4;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label Label40;
		public System.Windows.Forms.RadioButton[] Opt_notinTable = new System.Windows.Forms.RadioButton[5];
		public System.Windows.Forms.RadioButton[] TranPrefix = new System.Windows.Forms.RadioButton[3];
		public UpgradeHelpers.Gui.Controls.ListBoxHelper listBoxHelper1;
		public UpgradeHelpers.Gui.Controls.OptionButtonHelper optionButtonHelper1;
		public UpgradeHelpers.Gui.Controls.CommandButtonHelper commandButtonHelper1;
		private int DetailTabPreviousTab;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Fractional));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			MainMenu1 = new System.Windows.Forms.MenuStrip();
			mnuFile = new System.Windows.Forms.ToolStripMenuItem();
			mnuClose = new System.Windows.Forms.ToolStripMenuItem();
			chkDead = new System.Windows.Forms.CheckBox();
			chkShowInactive = new System.Windows.Forms.CheckBox();
			Chk_IncludeSS = new System.Windows.Forms.CheckBox();
			Chk_ShowTransactions = new System.Windows.Forms.CheckBox();
			chk_analyze = new System.Windows.Forms.CheckBox();
			Chk_internal = new System.Windows.Forms.CheckBox();
			cmdStop = new System.Windows.Forms.Button();
			DetailTab = new UpgradeHelpers.Gui.Controls.TabControlExtension();
			_DetailTab_TabPage0 = new System.Windows.Forms.TabPage();
			FG_Transactions = new UpgradeHelpers.DataGridViewFlex(components);
			Frame1 = new System.Windows.Forms.GroupBox();
			_TranPrefix_0 = new System.Windows.Forms.RadioButton();
			_TranPrefix_1 = new System.Windows.Forms.RadioButton();
			_TranPrefix_2 = new System.Windows.Forms.RadioButton();
			chk_FindOtherWS = new System.Windows.Forms.CheckBox();
			_DetailTab_TabPage1 = new System.Windows.Forms.TabPage();
			GrdSubscribers = new UpgradeHelpers.DataGridViewFlex(components);
			_DetailTab_TabPage2 = new System.Windows.Forms.TabPage();
			Frame2 = new System.Windows.Forms.GroupBox();
			_Opt_notinTable_4 = new System.Windows.Forms.RadioButton();
			_Opt_notinTable_3 = new System.Windows.Forms.RadioButton();
			_Opt_notinTable_2 = new System.Windows.Forms.RadioButton();
			_Opt_notinTable_1 = new System.Windows.Forms.RadioButton();
			_Opt_notinTable_0 = new System.Windows.Forms.RadioButton();
			GrdNotInTable = new UpgradeHelpers.DataGridViewFlex(components);
			LBLNotCount = new System.Windows.Forms.Label();
			cmdAircraft = new System.Windows.Forms.Button();
			cmb_Models = new System.Windows.Forms.ListBox();
			cmdFracProgram = new System.Windows.Forms.ListBox();
			chk_history = new System.Windows.Forms.CheckBox();
			FG_ProgAircraft = new UpgradeHelpers.DataGridViewFlex(components);
			FG_ProgCompany = new UpgradeHelpers.DataGridViewFlex(components);
			cmdRefresh = new System.Windows.Forms.Button();
			lblStatus = new System.Windows.Forms.Label();
			LblOther = new System.Windows.Forms.Label();
			lblTrans = new System.Windows.Forms.Label();
			lblModels = new System.Windows.Forms.Label();
			FLeetAC = new System.Windows.Forms.Label();
			PMPHCompanies = new System.Windows.Forms.Label();
			Label4 = new System.Windows.Forms.Label();
			Label2 = new System.Windows.Forms.Label();
			Label1 = new System.Windows.Forms.Label();
			Label40 = new System.Windows.Forms.Label();
			DetailTab.SuspendLayout();
			_DetailTab_TabPage0.SuspendLayout();
			Frame1.SuspendLayout();
			_DetailTab_TabPage1.SuspendLayout();
			_DetailTab_TabPage2.SuspendLayout();
			Frame2.SuspendLayout();
			SuspendLayout();
			listBoxHelper1 = new UpgradeHelpers.Gui.Controls.ListBoxHelper(components);
			optionButtonHelper1 = new UpgradeHelpers.Gui.Controls.OptionButtonHelper(components);
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
			((System.ComponentModel.ISupportInitialize) FG_Transactions).BeginInit();
			((System.ComponentModel.ISupportInitialize) GrdSubscribers).BeginInit();
			((System.ComponentModel.ISupportInitialize) GrdNotInTable).BeginInit();
			((System.ComponentModel.ISupportInitialize) FG_ProgAircraft).BeginInit();
			((System.ComponentModel.ISupportInitialize) FG_ProgCompany).BeginInit();
			// 
			// MainMenu1
			// 
			MainMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[]{mnuFile});
			// 
			// mnuFile
			// 
			mnuFile.Available = true;
			mnuFile.Checked = false;
			mnuFile.Enabled = true;
			mnuFile.Name = "mnuFile";
			mnuFile.Text = "File";
			mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]{mnuClose});
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
			// chkDead
			// 
			chkDead.AllowDrop = true;
			chkDead.Appearance = System.Windows.Forms.Appearance.Normal;
			chkDead.BackColor = System.Drawing.SystemColors.Control;
			chkDead.CausesValidation = true;
			chkDead.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkDead.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkDead.Enabled = true;
			chkDead.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkDead.ForeColor = System.Drawing.SystemColors.ControlText;
			chkDead.Location = new System.Drawing.Point(542, 20);
			chkDead.Name = "chkDead";
			chkDead.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkDead.Size = new System.Drawing.Size(93, 32);
			chkDead.TabIndex = 39;
			chkDead.TabStop = true;
			chkDead.Text = "Show Non- Frac Models";
			chkDead.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkDead.Visible = true;
			chkDead.CheckStateChanged += new System.EventHandler(chkDead_CheckStateChanged);
			// 
			// chkShowInactive
			// 
			chkShowInactive.AllowDrop = true;
			chkShowInactive.Appearance = System.Windows.Forms.Appearance.Normal;
			chkShowInactive.BackColor = System.Drawing.SystemColors.Control;
			chkShowInactive.CausesValidation = true;
			chkShowInactive.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkShowInactive.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkShowInactive.Enabled = true;
			chkShowInactive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkShowInactive.ForeColor = System.Drawing.SystemColors.ControlText;
			chkShowInactive.Location = new System.Drawing.Point(744, 349);
			chkShowInactive.Name = "chkShowInactive";
			chkShowInactive.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkShowInactive.Size = new System.Drawing.Size(98, 13);
			chkShowInactive.TabIndex = 38;
			chkShowInactive.TabStop = true;
			chkShowInactive.Text = "Show Inactive";
			chkShowInactive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkShowInactive.Visible = true;
			chkShowInactive.CheckStateChanged += new System.EventHandler(chkShowInactive_CheckStateChanged);
			// 
			// Chk_IncludeSS
			// 
			Chk_IncludeSS.AllowDrop = true;
			Chk_IncludeSS.Appearance = System.Windows.Forms.Appearance.Normal;
			Chk_IncludeSS.BackColor = System.Drawing.SystemColors.Control;
			Chk_IncludeSS.CausesValidation = true;
			Chk_IncludeSS.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			Chk_IncludeSS.CheckState = System.Windows.Forms.CheckState.Checked;
			Chk_IncludeSS.Enabled = true;
			Chk_IncludeSS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Chk_IncludeSS.ForeColor = System.Drawing.SystemColors.ControlText;
			Chk_IncludeSS.Location = new System.Drawing.Point(414, 27);
			Chk_IncludeSS.Name = "Chk_IncludeSS";
			Chk_IncludeSS.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Chk_IncludeSS.Size = new System.Drawing.Size(125, 13);
			Chk_IncludeSS.TabIndex = 34;
			Chk_IncludeSS.TabStop = true;
			Chk_IncludeSS.Text = "Include SS with WS";
			Chk_IncludeSS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			Chk_IncludeSS.Visible = true;
			// 
			// Chk_ShowTransactions
			// 
			Chk_ShowTransactions.AllowDrop = true;
			Chk_ShowTransactions.Appearance = System.Windows.Forms.Appearance.Normal;
			Chk_ShowTransactions.BackColor = System.Drawing.SystemColors.Control;
			Chk_ShowTransactions.CausesValidation = true;
			Chk_ShowTransactions.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			Chk_ShowTransactions.CheckState = System.Windows.Forms.CheckState.Unchecked;
			Chk_ShowTransactions.Enabled = true;
			Chk_ShowTransactions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Chk_ShowTransactions.ForeColor = System.Drawing.SystemColors.ControlText;
			Chk_ShowTransactions.Location = new System.Drawing.Point(629, 349);
			Chk_ShowTransactions.Name = "Chk_ShowTransactions";
			Chk_ShowTransactions.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Chk_ShowTransactions.Size = new System.Drawing.Size(120, 13);
			Chk_ShowTransactions.TabIndex = 26;
			Chk_ShowTransactions.TabStop = true;
			Chk_ShowTransactions.Text = "Show Transactions";
			Chk_ShowTransactions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			Chk_ShowTransactions.Visible = true;
			Chk_ShowTransactions.CheckStateChanged += new System.EventHandler(Chk_ShowTransactions_CheckStateChanged);
			// 
			// chk_analyze
			// 
			chk_analyze.AllowDrop = true;
			chk_analyze.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_analyze.BackColor = System.Drawing.SystemColors.Control;
			chk_analyze.CausesValidation = true;
			chk_analyze.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_analyze.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_analyze.Enabled = true;
			chk_analyze.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_analyze.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_analyze.Location = new System.Drawing.Point(660, 127);
			chk_analyze.Name = "chk_analyze";
			chk_analyze.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_analyze.Size = new System.Drawing.Size(99, 14);
			chk_analyze.TabIndex = 25;
			chk_analyze.TabStop = true;
			chk_analyze.Text = "Analyze Aircraft";
			chk_analyze.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_analyze.Visible = true;
			chk_analyze.CheckStateChanged += new System.EventHandler(chk_analyze_CheckStateChanged);
			// 
			// Chk_internal
			// 
			Chk_internal.AllowDrop = true;
			Chk_internal.Appearance = System.Windows.Forms.Appearance.Normal;
			Chk_internal.BackColor = System.Drawing.SystemColors.Control;
			Chk_internal.CausesValidation = true;
			Chk_internal.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			Chk_internal.CheckState = System.Windows.Forms.CheckState.Checked;
			Chk_internal.Enabled = true;
			Chk_internal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Chk_internal.ForeColor = System.Drawing.SystemColors.ControlText;
			Chk_internal.Location = new System.Drawing.Point(251, 27);
			Chk_internal.Name = "Chk_internal";
			Chk_internal.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Chk_internal.Size = new System.Drawing.Size(170, 13);
			Chk_internal.TabIndex = 24;
			Chk_internal.TabStop = true;
			Chk_internal.Text = "Exclude Internal Transactions";
			Chk_internal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			Chk_internal.Visible = false;
			Chk_internal.CheckStateChanged += new System.EventHandler(Chk_internal_CheckStateChanged);
			// 
			// cmdStop
			// 
			cmdStop.AllowDrop = true;
			cmdStop.BackColor = System.Drawing.SystemColors.Control;
			cmdStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdStop.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdStop.Location = new System.Drawing.Point(184, 24);
			cmdStop.Name = "cmdStop";
			cmdStop.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdStop.Size = new System.Drawing.Size(56, 20);
			cmdStop.TabIndex = 23;
			cmdStop.Text = "Stop";
			cmdStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdStop.UseVisualStyleBackColor = false;
			cmdStop.Click += new System.EventHandler(cmdStop_Click);
			// 
			// DetailTab
			// 
			DetailTab.Alignment = System.Windows.Forms.TabAlignment.Top;
			DetailTab.AllowDrop = true;
			DetailTab.Controls.Add(_DetailTab_TabPage0);
			DetailTab.Controls.Add(_DetailTab_TabPage1);
			DetailTab.Controls.Add(_DetailTab_TabPage2);
			DetailTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			DetailTab.ItemSize = new System.Drawing.Size(268, 18);
			DetailTab.Location = new System.Drawing.Point(0, 363);
			DetailTab.Multiline = true;
			DetailTab.Name = "DetailTab";
			DetailTab.Size = new System.Drawing.Size(813, 242);
			DetailTab.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			DetailTab.TabIndex = 15;
			DetailTab.Visible = false;
			DetailTab.SelectedIndexChanged += new System.EventHandler(DetailTab_SelectedIndexChanged);
			// 
			// _DetailTab_TabPage0
			// 
			_DetailTab_TabPage0.Controls.Add(FG_Transactions);
			_DetailTab_TabPage0.Controls.Add(Frame1);
			_DetailTab_TabPage0.Controls.Add(chk_FindOtherWS);
			_DetailTab_TabPage0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_DetailTab_TabPage0.Text = "Transactions";
			// 
			// FG_Transactions
			// 
			FG_Transactions.AllowDrop = true;
			FG_Transactions.AllowUserToAddRows = false;
			FG_Transactions.AllowUserToDeleteRows = false;
			FG_Transactions.AllowUserToResizeColumns = false;
			FG_Transactions.AllowUserToResizeColumns = FG_Transactions.ColumnHeadersVisible;
			FG_Transactions.AllowUserToResizeRows = false;
			FG_Transactions.AllowUserToResizeRows = false;
			FG_Transactions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			FG_Transactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			FG_Transactions.ColumnsCount = 7;
			FG_Transactions.FixedColumns = 0;
			FG_Transactions.FixedRows = 1;
			FG_Transactions.Location = new System.Drawing.Point(11, 31);
			FG_Transactions.Name = "FG_Transactions";
			FG_Transactions.ReadOnly = true;
			FG_Transactions.RowsCount = 2;
			FG_Transactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			FG_Transactions.ShowCellToolTips = false;
			FG_Transactions.Size = new System.Drawing.Size(789, 180);
			FG_Transactions.StandardTab = true;
			FG_Transactions.TabIndex = 16;
			FG_Transactions.DoubleClick += new System.EventHandler(FG_Transactions_DoubleClick);
			// 
			// Frame1
			// 
			Frame1.AllowDrop = true;
			Frame1.BackColor = System.Drawing.SystemColors.Control;
			Frame1.Controls.Add(_TranPrefix_0);
			Frame1.Controls.Add(_TranPrefix_1);
			Frame1.Controls.Add(_TranPrefix_2);
			Frame1.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			Frame1.Enabled = true;
			Frame1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
			Frame1.Location = new System.Drawing.Point(16, -1);
			Frame1.Name = "Frame1";
			Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Frame1.Size = new System.Drawing.Size(174, 32);
			Frame1.TabIndex = 17;
			Frame1.Visible = true;
			// 
			// _TranPrefix_0
			// 
			_TranPrefix_0.AllowDrop = true;
			_TranPrefix_0.BackColor = System.Drawing.SystemColors.Control;
			_TranPrefix_0.CausesValidation = true;
			_TranPrefix_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_TranPrefix_0.Checked = true;
			_TranPrefix_0.Enabled = true;
			_TranPrefix_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_TranPrefix_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_TranPrefix_0.Location = new System.Drawing.Point(5, 10);
			_TranPrefix_0.Name = "_TranPrefix_0";
			_TranPrefix_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_TranPrefix_0.Size = new System.Drawing.Size(45, 16);
			_TranPrefix_0.TabIndex = 20;
			_TranPrefix_0.TabStop = true;
			_TranPrefix_0.Text = "WS";
			_TranPrefix_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_TranPrefix_0.Visible = true;
			_TranPrefix_0.CheckedChanged += new System.EventHandler(TranPrefix_CheckedChanged);
			// 
			// _TranPrefix_1
			// 
			_TranPrefix_1.AllowDrop = true;
			_TranPrefix_1.BackColor = System.Drawing.SystemColors.Control;
			_TranPrefix_1.CausesValidation = true;
			_TranPrefix_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_TranPrefix_1.Checked = false;
			_TranPrefix_1.Enabled = true;
			_TranPrefix_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_TranPrefix_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_TranPrefix_1.Location = new System.Drawing.Point(56, 10);
			_TranPrefix_1.Name = "_TranPrefix_1";
			_TranPrefix_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_TranPrefix_1.Size = new System.Drawing.Size(44, 18);
			_TranPrefix_1.TabIndex = 19;
			_TranPrefix_1.TabStop = true;
			_TranPrefix_1.Text = "FS";
			_TranPrefix_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_TranPrefix_1.Visible = true;
			_TranPrefix_1.CheckedChanged += new System.EventHandler(TranPrefix_CheckedChanged);
			// 
			// _TranPrefix_2
			// 
			_TranPrefix_2.AllowDrop = true;
			_TranPrefix_2.BackColor = System.Drawing.SystemColors.Control;
			_TranPrefix_2.CausesValidation = true;
			_TranPrefix_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_TranPrefix_2.Checked = false;
			_TranPrefix_2.Enabled = true;
			_TranPrefix_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_TranPrefix_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_TranPrefix_2.Location = new System.Drawing.Point(110, 9);
			_TranPrefix_2.Name = "_TranPrefix_2";
			_TranPrefix_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_TranPrefix_2.Size = new System.Drawing.Size(60, 18);
			_TranPrefix_2.TabIndex = 18;
			_TranPrefix_2.TabStop = true;
			_TranPrefix_2.Text = "EUEU";
			_TranPrefix_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_TranPrefix_2.Visible = true;
			_TranPrefix_2.CheckedChanged += new System.EventHandler(TranPrefix_CheckedChanged);
			// 
			// chk_FindOtherWS
			// 
			chk_FindOtherWS.AllowDrop = true;
			chk_FindOtherWS.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_FindOtherWS.BackColor = System.Drawing.SystemColors.Control;
			chk_FindOtherWS.CausesValidation = true;
			chk_FindOtherWS.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_FindOtherWS.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_FindOtherWS.Enabled = true;
			chk_FindOtherWS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_FindOtherWS.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_FindOtherWS.Location = new System.Drawing.Point(205, 8);
			chk_FindOtherWS.Name = "chk_FindOtherWS";
			chk_FindOtherWS.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_FindOtherWS.Size = new System.Drawing.Size(176, 14);
			chk_FindOtherWS.TabIndex = 32;
			chk_FindOtherWS.TabStop = true;
			chk_FindOtherWS.Text = "Find Other Companies for WS";
			chk_FindOtherWS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_FindOtherWS.Visible = true;
			chk_FindOtherWS.CheckStateChanged += new System.EventHandler(chk_FindOtherWS_CheckStateChanged);
			// 
			// _DetailTab_TabPage1
			// 
			_DetailTab_TabPage1.Controls.Add(GrdSubscribers);
			_DetailTab_TabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_DetailTab_TabPage1.Text = "Shareholders";
			// 
			// GrdSubscribers
			// 
			GrdSubscribers.AllowDrop = true;
			GrdSubscribers.AllowUserToAddRows = false;
			GrdSubscribers.AllowUserToDeleteRows = false;
			GrdSubscribers.AllowUserToResizeColumns = false;
			GrdSubscribers.AllowUserToResizeColumns = GrdSubscribers.ColumnHeadersVisible;
			GrdSubscribers.AllowUserToResizeRows = false;
			GrdSubscribers.AllowUserToResizeRows = false;
			GrdSubscribers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			GrdSubscribers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			GrdSubscribers.ColumnsCount = 6;
			GrdSubscribers.FixedColumns = 0;
			GrdSubscribers.FixedRows = 1;
			GrdSubscribers.Location = new System.Drawing.Point(10, 20);
			GrdSubscribers.Name = "GrdSubscribers";
			GrdSubscribers.ReadOnly = true;
			GrdSubscribers.RowsCount = 2;
			GrdSubscribers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			GrdSubscribers.ShowCellToolTips = false;
			GrdSubscribers.Size = new System.Drawing.Size(779, 184);
			GrdSubscribers.StandardTab = true;
			GrdSubscribers.TabIndex = 21;
			GrdSubscribers.DoubleClick += new System.EventHandler(GrdSubscribers_DoubleClick);
			// 
			// _DetailTab_TabPage2
			// 
			_DetailTab_TabPage2.Controls.Add(Frame2);
			_DetailTab_TabPage2.Controls.Add(GrdNotInTable);
			_DetailTab_TabPage2.Controls.Add(LBLNotCount);
			_DetailTab_TabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_DetailTab_TabPage2.Text = "Orphans";
			// 
			// Frame2
			// 
			Frame2.AllowDrop = true;
			Frame2.BackColor = System.Drawing.SystemColors.Control;
			Frame2.Controls.Add(_Opt_notinTable_4);
			Frame2.Controls.Add(_Opt_notinTable_3);
			Frame2.Controls.Add(_Opt_notinTable_2);
			Frame2.Controls.Add(_Opt_notinTable_1);
			Frame2.Controls.Add(_Opt_notinTable_0);
			Frame2.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			Frame2.Enabled = true;
			Frame2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Frame2.ForeColor = System.Drawing.SystemColors.ControlText;
			Frame2.Location = new System.Drawing.Point(16, 7);
			Frame2.Name = "Frame2";
			Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Frame2.Size = new System.Drawing.Size(782, 48);
			Frame2.TabIndex = 28;
			Frame2.Visible = true;
			// 
			// _Opt_notinTable_4
			// 
			_Opt_notinTable_4.AllowDrop = true;
			_Opt_notinTable_4.BackColor = System.Drawing.SystemColors.Control;
			_Opt_notinTable_4.CausesValidation = true;
			_Opt_notinTable_4.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_Opt_notinTable_4.Checked = false;
			_Opt_notinTable_4.Enabled = true;
			_Opt_notinTable_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Opt_notinTable_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_Opt_notinTable_4.Location = new System.Drawing.Point(434, 7);
			_Opt_notinTable_4.Name = "_Opt_notinTable_4";
			_Opt_notinTable_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Opt_notinTable_4.Size = new System.Drawing.Size(175, 17);
			_Opt_notinTable_4.TabIndex = 37;
			_Opt_notinTable_4.TabStop = true;
			_Opt_notinTable_4.Text = "Inactive Shareholders - No Sells";
			_Opt_notinTable_4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_Opt_notinTable_4.Visible = true;
			_Opt_notinTable_4.CheckedChanged += new System.EventHandler(Opt_notinTable_CheckedChanged);
			// 
			// _Opt_notinTable_3
			// 
			_Opt_notinTable_3.AllowDrop = true;
			_Opt_notinTable_3.BackColor = System.Drawing.SystemColors.Control;
			_Opt_notinTable_3.CausesValidation = true;
			_Opt_notinTable_3.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_Opt_notinTable_3.Checked = false;
			_Opt_notinTable_3.Enabled = true;
			_Opt_notinTable_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Opt_notinTable_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_Opt_notinTable_3.Location = new System.Drawing.Point(219, 27);
			_Opt_notinTable_3.Name = "_Opt_notinTable_3";
			_Opt_notinTable_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Opt_notinTable_3.Size = new System.Drawing.Size(175, 17);
			_Opt_notinTable_3.TabIndex = 36;
			_Opt_notinTable_3.TabStop = true;
			_Opt_notinTable_3.Text = "Inactive Shareholders - No Buys";
			_Opt_notinTable_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_Opt_notinTable_3.Visible = true;
			_Opt_notinTable_3.CheckedChanged += new System.EventHandler(Opt_notinTable_CheckedChanged);
			// 
			// _Opt_notinTable_2
			// 
			_Opt_notinTable_2.AllowDrop = true;
			_Opt_notinTable_2.BackColor = System.Drawing.SystemColors.Control;
			_Opt_notinTable_2.CausesValidation = true;
			_Opt_notinTable_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_Opt_notinTable_2.Checked = false;
			_Opt_notinTable_2.Enabled = true;
			_Opt_notinTable_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Opt_notinTable_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_Opt_notinTable_2.Location = new System.Drawing.Point(219, 10);
			_Opt_notinTable_2.Name = "_Opt_notinTable_2";
			_Opt_notinTable_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Opt_notinTable_2.Size = new System.Drawing.Size(216, 17);
			_Opt_notinTable_2.TabIndex = 35;
			_Opt_notinTable_2.TabStop = true;
			_Opt_notinTable_2.Text = "Shareholders with missing Sells or Buys";
			_Opt_notinTable_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_Opt_notinTable_2.Visible = true;
			_Opt_notinTable_2.CheckedChanged += new System.EventHandler(Opt_notinTable_CheckedChanged);
			// 
			// _Opt_notinTable_1
			// 
			_Opt_notinTable_1.AllowDrop = true;
			_Opt_notinTable_1.BackColor = System.Drawing.SystemColors.Control;
			_Opt_notinTable_1.CausesValidation = true;
			_Opt_notinTable_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_Opt_notinTable_1.Checked = false;
			_Opt_notinTable_1.Enabled = true;
			_Opt_notinTable_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Opt_notinTable_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_Opt_notinTable_1.Location = new System.Drawing.Point(4, 29);
			_Opt_notinTable_1.Name = "_Opt_notinTable_1";
			_Opt_notinTable_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Opt_notinTable_1.Size = new System.Drawing.Size(180, 17);
			_Opt_notinTable_1.TabIndex = 30;
			_Opt_notinTable_1.TabStop = true;
			_Opt_notinTable_1.Text = "Shareholders not in Share Table";
			_Opt_notinTable_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_Opt_notinTable_1.Visible = true;
			_Opt_notinTable_1.CheckedChanged += new System.EventHandler(Opt_notinTable_CheckedChanged);
			// 
			// _Opt_notinTable_0
			// 
			_Opt_notinTable_0.AllowDrop = true;
			_Opt_notinTable_0.BackColor = System.Drawing.SystemColors.Control;
			_Opt_notinTable_0.CausesValidation = true;
			_Opt_notinTable_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_Opt_notinTable_0.Checked = true;
			_Opt_notinTable_0.Enabled = true;
			_Opt_notinTable_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Opt_notinTable_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_Opt_notinTable_0.Location = new System.Drawing.Point(5, 11);
			_Opt_notinTable_0.Name = "_Opt_notinTable_0";
			_Opt_notinTable_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Opt_notinTable_0.Size = new System.Drawing.Size(222, 17);
			_Opt_notinTable_0.TabIndex = 29;
			_Opt_notinTable_0.TabStop = true;
			_Opt_notinTable_0.Text = "Programholders not in PH Table";
			_Opt_notinTable_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_Opt_notinTable_0.Visible = true;
			_Opt_notinTable_0.CheckedChanged += new System.EventHandler(Opt_notinTable_CheckedChanged);
			// 
			// GrdNotInTable
			// 
			GrdNotInTable.AllowDrop = true;
			GrdNotInTable.AllowUserToAddRows = false;
			GrdNotInTable.AllowUserToDeleteRows = false;
			GrdNotInTable.AllowUserToResizeColumns = false;
			GrdNotInTable.AllowUserToResizeColumns = GrdNotInTable.ColumnHeadersVisible;
			GrdNotInTable.AllowUserToResizeRows = false;
			GrdNotInTable.AllowUserToResizeRows = false;
			GrdNotInTable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			GrdNotInTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			GrdNotInTable.ColumnsCount = 4;
			GrdNotInTable.FixedColumns = 0;
			GrdNotInTable.FixedRows = 1;
			GrdNotInTable.Location = new System.Drawing.Point(17, 69);
			GrdNotInTable.Name = "GrdNotInTable";
			GrdNotInTable.ReadOnly = true;
			GrdNotInTable.RowsCount = 2;
			GrdNotInTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			GrdNotInTable.ShowCellToolTips = false;
			GrdNotInTable.Size = new System.Drawing.Size(530, 128);
			GrdNotInTable.StandardTab = true;
			GrdNotInTable.TabIndex = 27;
			GrdNotInTable.DoubleClick += new System.EventHandler(GrdNotInTable_DoubleClick);
			// 
			// LBLNotCount
			// 
			LBLNotCount.AllowDrop = true;
			LBLNotCount.BackColor = System.Drawing.SystemColors.Control;
			LBLNotCount.BorderStyle = System.Windows.Forms.BorderStyle.None;
			LBLNotCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			LBLNotCount.ForeColor = System.Drawing.SystemColors.ControlText;
			LBLNotCount.Location = new System.Drawing.Point(613, 89);
			LBLNotCount.MinimumSize = new System.Drawing.Size(97, 30);
			LBLNotCount.Name = "LBLNotCount";
			LBLNotCount.RightToLeft = System.Windows.Forms.RightToLeft.No;
			LBLNotCount.Size = new System.Drawing.Size(97, 30);
			LBLNotCount.TabIndex = 31;
			LBLNotCount.Text = "_";
			// 
			// cmdAircraft
			// 
			cmdAircraft.AllowDrop = true;
			cmdAircraft.BackColor = System.Drawing.SystemColors.Control;
			cmdAircraft.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdAircraft.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdAircraft.Location = new System.Drawing.Point(678, 150);
			cmdAircraft.Name = "cmdAircraft";
			cmdAircraft.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdAircraft.Size = new System.Drawing.Size(102, 19);
			cmdAircraft.TabIndex = 14;
			cmdAircraft.Text = "Go To Aircraft";
			cmdAircraft.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdAircraft.UseVisualStyleBackColor = false;
			cmdAircraft.Click += new System.EventHandler(cmdAircraft_Click);
			// 
			// cmb_Models
			// 
			cmb_Models.AllowDrop = true;
			cmb_Models.BackColor = System.Drawing.SystemColors.Window;
			cmb_Models.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			cmb_Models.CausesValidation = true;
			cmb_Models.Enabled = true;
			cmb_Models.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmb_Models.ForeColor = System.Drawing.SystemColors.WindowText;
			cmb_Models.IntegralHeight = true;
			cmb_Models.Location = new System.Drawing.Point(339, 71);
			cmb_Models.MultiColumn = false;
			cmb_Models.Name = "cmb_Models";
			cmb_Models.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmb_Models.Size = new System.Drawing.Size(295, 83);
			cmb_Models.Sorted = false;
			cmb_Models.TabIndex = 9;
			cmb_Models.TabStop = true;
			cmb_Models.Visible = true;
			cmb_Models.SelectedIndexChanged += new System.EventHandler(cmb_Models_SelectedIndexChanged);
			// 
			// cmdFracProgram
			// 
			cmdFracProgram.AllowDrop = true;
			cmdFracProgram.BackColor = System.Drawing.SystemColors.Window;
			cmdFracProgram.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			cmdFracProgram.CausesValidation = true;
			cmdFracProgram.Enabled = true;
			cmdFracProgram.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdFracProgram.ForeColor = System.Drawing.SystemColors.WindowText;
			cmdFracProgram.IntegralHeight = true;
			cmdFracProgram.Location = new System.Drawing.Point(7, 70);
			cmdFracProgram.MultiColumn = false;
			cmdFracProgram.Name = "cmdFracProgram";
			cmdFracProgram.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdFracProgram.Size = new System.Drawing.Size(290, 83);
			cmdFracProgram.Sorted = false;
			cmdFracProgram.TabIndex = 8;
			cmdFracProgram.TabStop = true;
			cmdFracProgram.Visible = true;
			cmdFracProgram.SelectedIndexChanged += new System.EventHandler(cmdFracProgram_SelectedIndexChanged);
			// 
			// chk_history
			// 
			chk_history.AllowDrop = true;
			chk_history.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_history.BackColor = System.Drawing.SystemColors.Control;
			chk_history.CausesValidation = true;
			chk_history.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_history.CheckState = System.Windows.Forms.CheckState.Checked;
			chk_history.Enabled = true;
			chk_history.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_history.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_history.Location = new System.Drawing.Point(414, 51);
			chk_history.Name = "chk_history";
			chk_history.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_history.Size = new System.Drawing.Size(154, 18);
			chk_history.TabIndex = 7;
			chk_history.TabStop = true;
			chk_history.Text = "Include Historical Aircraft";
			chk_history.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_history.Visible = false;
			chk_history.CheckStateChanged += new System.EventHandler(chk_history_CheckStateChanged);
			// 
			// FG_ProgAircraft
			// 
			FG_ProgAircraft.AllowDrop = true;
			FG_ProgAircraft.AllowUserToAddRows = false;
			FG_ProgAircraft.AllowUserToDeleteRows = false;
			FG_ProgAircraft.AllowUserToResizeColumns = false;
			FG_ProgAircraft.AllowUserToResizeColumns = FG_ProgAircraft.ColumnHeadersVisible;
			FG_ProgAircraft.AllowUserToResizeRows = false;
			FG_ProgAircraft.AllowUserToResizeRows = false;
			FG_ProgAircraft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			FG_ProgAircraft.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			FG_ProgAircraft.ColumnsCount = 6;
			FG_ProgAircraft.FixedColumns = 0;
			FG_ProgAircraft.FixedRows = 1;
			FG_ProgAircraft.Location = new System.Drawing.Point(340, 169);
			FG_ProgAircraft.Name = "FG_ProgAircraft";
			FG_ProgAircraft.ReadOnly = true;
			FG_ProgAircraft.RowsCount = 2;
			FG_ProgAircraft.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			FG_ProgAircraft.ShowCellToolTips = false;
			FG_ProgAircraft.Size = new System.Drawing.Size(454, 176);
			FG_ProgAircraft.StandardTab = true;
			FG_ProgAircraft.TabIndex = 4;
			FG_ProgAircraft.Click += new System.EventHandler(FG_ProgAircraft_Click);
			FG_ProgAircraft.DoubleClick += new System.EventHandler(FG_ProgAircraft_DoubleClick);
			// 
			// FG_ProgCompany
			// 
			FG_ProgCompany.AllowDrop = true;
			FG_ProgCompany.AllowUserToAddRows = false;
			FG_ProgCompany.AllowUserToDeleteRows = false;
			FG_ProgCompany.AllowUserToResizeColumns = false;
			FG_ProgCompany.AllowUserToResizeColumns = FG_ProgCompany.ColumnHeadersVisible;
			FG_ProgCompany.AllowUserToResizeRows = false;
			FG_ProgCompany.AllowUserToResizeRows = false;
			FG_ProgCompany.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			FG_ProgCompany.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			FG_ProgCompany.ColumnsCount = 4;
			FG_ProgCompany.FixedColumns = 0;
			FG_ProgCompany.FixedRows = 1;
			FG_ProgCompany.Location = new System.Drawing.Point(11, 172);
			FG_ProgCompany.Name = "FG_ProgCompany";
			FG_ProgCompany.ReadOnly = true;
			FG_ProgCompany.RowsCount = 2;
			FG_ProgCompany.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			FG_ProgCompany.ShowCellToolTips = false;
			FG_ProgCompany.Size = new System.Drawing.Size(294, 173);
			FG_ProgCompany.StandardTab = true;
			FG_ProgCompany.TabIndex = 1;
			FG_ProgCompany.Visible = false;
			FG_ProgCompany.Click += new System.EventHandler(FG_ProgCompany_Click);
			FG_ProgCompany.DoubleClick += new System.EventHandler(FG_ProgCompany_DoubleClick);
			// 
			// cmdRefresh
			// 
			cmdRefresh.AllowDrop = true;
			cmdRefresh.BackColor = System.Drawing.SystemColors.Control;
			cmdRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdRefresh.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdRefresh.Location = new System.Drawing.Point(791, 345);
			cmdRefresh.Name = "cmdRefresh";
			cmdRefresh.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdRefresh.Size = new System.Drawing.Size(44, 17);
			cmdRefresh.TabIndex = 5;
			cmdRefresh.Text = "Show Transactions";
			cmdRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdRefresh.UseVisualStyleBackColor = false;
			cmdRefresh.Visible = false;
			cmdRefresh.Click += new System.EventHandler(cmdRefresh_Click);
			// 
			// lblStatus
			// 
			lblStatus.AllowDrop = true;
			lblStatus.BackColor = System.Drawing.SystemColors.Control;
			lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblStatus.ForeColor = System.Drawing.SystemColors.ControlText;
			lblStatus.Location = new System.Drawing.Point(655, 105);
			lblStatus.MinimumSize = new System.Drawing.Size(154, 23);
			lblStatus.Name = "lblStatus";
			lblStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblStatus.Size = new System.Drawing.Size(154, 23);
			lblStatus.TabIndex = 33;
			lblStatus.Text = "_";
			// 
			// LblOther
			// 
			LblOther.AllowDrop = true;
			LblOther.BackColor = System.Drawing.SystemColors.Control;
			LblOther.BorderStyle = System.Windows.Forms.BorderStyle.None;
			LblOther.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			LblOther.ForeColor = System.Drawing.Color.Red;
			LblOther.Location = new System.Drawing.Point(653, 25);
			LblOther.MinimumSize = new System.Drawing.Size(176, 85);
			LblOther.Name = "LblOther";
			LblOther.RightToLeft = System.Windows.Forms.RightToLeft.No;
			LblOther.Size = new System.Drawing.Size(176, 85);
			LblOther.TabIndex = 22;
			LblOther.Text = "These Companies, Aircraft, and Transactions are NOT connected to any Program";
			LblOther.Visible = false;
			// 
			// lblTrans
			// 
			lblTrans.AllowDrop = true;
			lblTrans.BackColor = System.Drawing.SystemColors.Control;
			lblTrans.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblTrans.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblTrans.ForeColor = System.Drawing.SystemColors.ControlText;
			lblTrans.Location = new System.Drawing.Point(13, 601);
			lblTrans.MinimumSize = new System.Drawing.Size(611, 17);
			lblTrans.Name = "lblTrans";
			lblTrans.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblTrans.Size = new System.Drawing.Size(611, 17);
			lblTrans.TabIndex = 13;
			lblTrans.Text = "_";
			// 
			// lblModels
			// 
			lblModels.AllowDrop = true;
			lblModels.BackColor = System.Drawing.SystemColors.Control;
			lblModels.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblModels.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblModels.ForeColor = System.Drawing.SystemColors.ControlText;
			lblModels.Location = new System.Drawing.Point(582, 53);
			lblModels.MinimumSize = new System.Drawing.Size(71, 18);
			lblModels.Name = "lblModels";
			lblModels.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblModels.Size = new System.Drawing.Size(71, 18);
			lblModels.TabIndex = 12;
			lblModels.Text = "_";
			// 
			// FLeetAC
			// 
			FLeetAC.AllowDrop = true;
			FLeetAC.BackColor = System.Drawing.SystemColors.Control;
			FLeetAC.BorderStyle = System.Windows.Forms.BorderStyle.None;
			FLeetAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			FLeetAC.ForeColor = System.Drawing.SystemColors.ControlText;
			FLeetAC.Location = new System.Drawing.Point(349, 346);
			FLeetAC.MinimumSize = new System.Drawing.Size(287, 14);
			FLeetAC.Name = "FLeetAC";
			FLeetAC.RightToLeft = System.Windows.Forms.RightToLeft.No;
			FLeetAC.Size = new System.Drawing.Size(287, 14);
			FLeetAC.TabIndex = 11;
			FLeetAC.Text = "_";
			// 
			// PMPHCompanies
			// 
			PMPHCompanies.AllowDrop = true;
			PMPHCompanies.BackColor = System.Drawing.SystemColors.Control;
			PMPHCompanies.BorderStyle = System.Windows.Forms.BorderStyle.None;
			PMPHCompanies.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			PMPHCompanies.ForeColor = System.Drawing.SystemColors.ControlText;
			PMPHCompanies.Location = new System.Drawing.Point(25, 346);
			PMPHCompanies.MinimumSize = new System.Drawing.Size(283, 15);
			PMPHCompanies.Name = "PMPHCompanies";
			PMPHCompanies.RightToLeft = System.Windows.Forms.RightToLeft.No;
			PMPHCompanies.Size = new System.Drawing.Size(283, 15);
			PMPHCompanies.TabIndex = 10;
			PMPHCompanies.Text = "_";
			// 
			// Label4
			// 
			Label4.AllowDrop = true;
			Label4.BackColor = System.Drawing.SystemColors.Control;
			Label4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label4.ForeColor = System.Drawing.SystemColors.ControlText;
			Label4.Location = new System.Drawing.Point(355, 52);
			Label4.MinimumSize = new System.Drawing.Size(50, 21);
			Label4.Name = "Label4";
			Label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label4.Size = new System.Drawing.Size(50, 21);
			Label4.TabIndex = 6;
			Label4.Text = "Model:";
			// 
			// Label2
			// 
			Label2.AllowDrop = true;
			Label2.BackColor = System.Drawing.SystemColors.Control;
			Label2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label2.ForeColor = System.Drawing.SystemColors.ControlText;
			Label2.Location = new System.Drawing.Point(424, 154);
			Label2.MinimumSize = new System.Drawing.Size(123, 13);
			Label2.Name = "Label2";
			Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label2.Size = new System.Drawing.Size(123, 13);
			Label2.TabIndex = 3;
			Label2.Text = "Aircraft in Fleet";
			// 
			// Label1
			// 
			Label1.AllowDrop = true;
			Label1.BackColor = System.Drawing.SystemColors.Control;
			Label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label1.ForeColor = System.Drawing.SystemColors.ControlText;
			Label1.Location = new System.Drawing.Point(23, 154);
			Label1.MinimumSize = new System.Drawing.Size(254, 16);
			Label1.Name = "Label1";
			Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label1.Size = new System.Drawing.Size(254, 16);
			Label1.TabIndex = 2;
			Label1.Text = "Program Management/Holder Companies";
			// 
			// Label40
			// 
			Label40.AllowDrop = true;
			Label40.BackColor = System.Drawing.SystemColors.Control;
			Label40.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label40.ForeColor = System.Drawing.SystemColors.ControlText;
			Label40.Location = new System.Drawing.Point(13, 53);
			Label40.MinimumSize = new System.Drawing.Size(145, 16);
			Label40.Name = "Label40";
			Label40.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label40.Size = new System.Drawing.Size(145, 16);
			Label40.TabIndex = 0;
			Label40.Text = "Fractional Program";
			// 
			// frm_Fractional
			// 
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			ClientSize = new System.Drawing.Size(840, 617);
			Controls.Add(chkDead);
			Controls.Add(chkShowInactive);
			Controls.Add(Chk_IncludeSS);
			Controls.Add(Chk_ShowTransactions);
			Controls.Add(chk_analyze);
			Controls.Add(Chk_internal);
			Controls.Add(cmdStop);
			Controls.Add(DetailTab);
			Controls.Add(cmdAircraft);
			Controls.Add(cmb_Models);
			Controls.Add(cmdFracProgram);
			Controls.Add(chk_history);
			Controls.Add(FG_ProgAircraft);
			Controls.Add(FG_ProgCompany);
			Controls.Add(cmdRefresh);
			Controls.Add(lblStatus);
			Controls.Add(LblOther);
			Controls.Add(lblTrans);
			Controls.Add(lblModels);
			Controls.Add(FLeetAC);
			Controls.Add(PMPHCompanies);
			Controls.Add(Label4);
			Controls.Add(Label2);
			Controls.Add(Label1);
			Controls.Add(Label40);
			Controls.Add(MainMenu1);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Location = new System.Drawing.Point(221, 225);
			MaximizeBox = true;
			MinimizeBox = true;
			Name = "frm_Fractional";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			Text = "Fractional Programs";
			commandButtonHelper1.SetStyle(cmdStop, 0);
			commandButtonHelper1.SetStyle(cmdAircraft, 0);
			commandButtonHelper1.SetStyle(cmdRefresh, 0);
			listBoxHelper1.SetSelectionMode(cmb_Models, System.Windows.Forms.SelectionMode.One);
			listBoxHelper1.SetSelectionMode(cmdFracProgram, System.Windows.Forms.SelectionMode.One);
			optionButtonHelper1.SetStyle(_TranPrefix_0, 0);
			optionButtonHelper1.SetStyle(_TranPrefix_1, 0);
			optionButtonHelper1.SetStyle(_TranPrefix_2, 0);
			optionButtonHelper1.SetStyle(_Opt_notinTable_4, 0);
			optionButtonHelper1.SetStyle(_Opt_notinTable_3, 0);
			optionButtonHelper1.SetStyle(_Opt_notinTable_2, 0);
			optionButtonHelper1.SetStyle(_Opt_notinTable_1, 0);
			optionButtonHelper1.SetStyle(_Opt_notinTable_0, 0);
			Activated += new System.EventHandler(frm_Fractional_Activated);
			Closed += new System.EventHandler(Form_Closed);
			((System.ComponentModel.ISupportInitialize) FG_Transactions).EndInit();
			((System.ComponentModel.ISupportInitialize) GrdSubscribers).EndInit();
			((System.ComponentModel.ISupportInitialize) GrdNotInTable).EndInit();
			((System.ComponentModel.ISupportInitialize) FG_ProgAircraft).EndInit();
			((System.ComponentModel.ISupportInitialize) FG_ProgCompany).EndInit();
			DetailTab.ResumeLayout(false);
			DetailTab.PerformLayout();
			_DetailTab_TabPage0.ResumeLayout(false);
			_DetailTab_TabPage0.PerformLayout();
			Frame1.ResumeLayout(false);
			Frame1.PerformLayout();
			_DetailTab_TabPage1.ResumeLayout(false);
			_DetailTab_TabPage1.PerformLayout();
			_DetailTab_TabPage2.ResumeLayout(false);
			_DetailTab_TabPage2.PerformLayout();
			Frame2.ResumeLayout(false);
			Frame2.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
		void ReLoadForm(bool addEvents)
		{
			InitializeTranPrefix();
			InitializeOpt_notinTable();
			DetailTabPreviousTab = DetailTab.SelectedIndex;
		}
		void InitializeTranPrefix()
		{
			TranPrefix = new System.Windows.Forms.RadioButton[3];
			TranPrefix[0] = _TranPrefix_0;
			TranPrefix[1] = _TranPrefix_1;
			TranPrefix[2] = _TranPrefix_2;
		}
		void InitializeOpt_notinTable()
		{
			Opt_notinTable = new System.Windows.Forms.RadioButton[5];
			Opt_notinTable[4] = _Opt_notinTable_4;
			Opt_notinTable[3] = _Opt_notinTable_3;
			Opt_notinTable[2] = _Opt_notinTable_2;
			Opt_notinTable[1] = _Opt_notinTable_1;
			Opt_notinTable[0] = _Opt_notinTable_0;
		}
		#endregion
	}
}