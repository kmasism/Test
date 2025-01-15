
namespace JETNET_Homebase
{
	partial class frm_UserHistory
	{

		#region "Upgrade Support "
		private static frm_UserHistory m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_UserHistory DefInstance
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
		public static frm_UserHistory CreateInstance()
		{
			frm_UserHistory theInstance = new frm_UserHistory();
			theInstance.Form_Load();
			return theInstance;
		}
		private string[] visualControls = new string[]{"components", "ToolTipMain", "mnuRefresh", "mnuViewIDs", "mnuSetMaxRecords", "mnuEnterHoursWorked", "MainMenu1", "grdYacht", "frmYacht", "Timer1", "grdCallback", "frmCallback", "grdContact", "frmContact", "grdCompany", "frmCompany", "grdAircraft", "frmAircraft"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.ToolStripMenuItem mnuRefresh;
		public System.Windows.Forms.ToolStripMenuItem mnuViewIDs;
		public System.Windows.Forms.ToolStripMenuItem mnuSetMaxRecords;
		public System.Windows.Forms.ToolStripMenuItem mnuEnterHoursWorked;
		public System.Windows.Forms.MenuStrip MainMenu1;
		public UpgradeHelpers.DataGridViewFlex grdYacht;
		public System.Windows.Forms.GroupBox frmYacht;
		public System.Windows.Forms.Timer Timer1;
		public UpgradeHelpers.DataGridViewFlex grdCallback;
		public System.Windows.Forms.GroupBox frmCallback;
		public UpgradeHelpers.DataGridViewFlex grdContact;
		public System.Windows.Forms.GroupBox frmContact;
		public UpgradeHelpers.DataGridViewFlex grdCompany;
		public System.Windows.Forms.GroupBox frmCompany;
		public UpgradeHelpers.DataGridViewFlex grdAircraft;
		public System.Windows.Forms.GroupBox frmAircraft;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_UserHistory));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			MainMenu1 = new System.Windows.Forms.MenuStrip();
			mnuRefresh = new System.Windows.Forms.ToolStripMenuItem();
			mnuViewIDs = new System.Windows.Forms.ToolStripMenuItem();
			mnuSetMaxRecords = new System.Windows.Forms.ToolStripMenuItem();
			mnuEnterHoursWorked = new System.Windows.Forms.ToolStripMenuItem();
			frmYacht = new System.Windows.Forms.GroupBox();
			grdYacht = new UpgradeHelpers.DataGridViewFlex(components);
			Timer1 = new System.Windows.Forms.Timer(components);
			frmCallback = new System.Windows.Forms.GroupBox();
			grdCallback = new UpgradeHelpers.DataGridViewFlex(components);
			frmContact = new System.Windows.Forms.GroupBox();
			grdContact = new UpgradeHelpers.DataGridViewFlex(components);
			frmCompany = new System.Windows.Forms.GroupBox();
			grdCompany = new UpgradeHelpers.DataGridViewFlex(components);
			frmAircraft = new System.Windows.Forms.GroupBox();
			grdAircraft = new UpgradeHelpers.DataGridViewFlex(components);
			frmYacht.SuspendLayout();
			frmCallback.SuspendLayout();
			frmContact.SuspendLayout();
			frmCompany.SuspendLayout();
			frmAircraft.SuspendLayout();
			SuspendLayout();
			((System.ComponentModel.ISupportInitialize) grdYacht).BeginInit();
			((System.ComponentModel.ISupportInitialize) grdCallback).BeginInit();
			((System.ComponentModel.ISupportInitialize) grdContact).BeginInit();
			((System.ComponentModel.ISupportInitialize) grdCompany).BeginInit();
			((System.ComponentModel.ISupportInitialize) grdAircraft).BeginInit();
			// 
			// MainMenu1
			// 
			MainMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[]{mnuRefresh, mnuViewIDs, mnuSetMaxRecords, mnuEnterHoursWorked});
			// 
			// mnuRefresh
			// 
			mnuRefresh.Available = true;
			mnuRefresh.Checked = false;
			mnuRefresh.Enabled = true;
			mnuRefresh.Name = "mnuRefresh";
			mnuRefresh.Text = "&Refresh";
			mnuRefresh.Click += new System.EventHandler(mnuRefresh_Click);
			// 
			// mnuViewIDs
			// 
			mnuViewIDs.Available = true;
			mnuViewIDs.Checked = false;
			mnuViewIDs.Enabled = true;
			mnuViewIDs.Name = "mnuViewIDs";
			mnuViewIDs.Text = "&View Id's";
			mnuViewIDs.Click += new System.EventHandler(mnuViewIDs_Click);
			// 
			// mnuSetMaxRecords
			// 
			mnuSetMaxRecords.Available = true;
			mnuSetMaxRecords.Checked = false;
			mnuSetMaxRecords.Enabled = true;
			mnuSetMaxRecords.Name = "mnuSetMaxRecords";
			mnuSetMaxRecords.Text = "&Max Records";
			mnuSetMaxRecords.Click += new System.EventHandler(mnuSetMaxRecords_Click);
			// 
			// mnuEnterHoursWorked
			// 
			mnuEnterHoursWorked.Available = true;
			mnuEnterHoursWorked.Checked = false;
			mnuEnterHoursWorked.Enabled = true;
			mnuEnterHoursWorked.Name = "mnuEnterHoursWorked";
			mnuEnterHoursWorked.Text = "&Enter Hours Worked";
			mnuEnterHoursWorked.Click += new System.EventHandler(mnuEnterHoursWorked_Click);
			// 
			// frmYacht
			// 
			frmYacht.AllowDrop = true;
			frmYacht.BackColor = System.Drawing.SystemColors.Control;
			frmYacht.Controls.Add(grdYacht);
			frmYacht.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmYacht.Enabled = true;
			frmYacht.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmYacht.ForeColor = System.Drawing.SystemColors.ControlText;
			frmYacht.Location = new System.Drawing.Point(4, 166);
			frmYacht.Name = "frmYacht";
			frmYacht.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmYacht.Size = new System.Drawing.Size(431, 137);
			frmYacht.TabIndex = 2;
			frmYacht.Text = "Yacht";
			frmYacht.Visible = true;
			// 
			// grdYacht
			// 
			grdYacht.AllowDrop = true;
			grdYacht.AllowUserToAddRows = false;
			grdYacht.AllowUserToDeleteRows = false;
			grdYacht.AllowUserToResizeColumns = false;
			grdYacht.AllowUserToResizeRows = false;
			grdYacht.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grdYacht.ColumnsCount = 2;
			grdYacht.FixedColumns = 1;
			grdYacht.FixedRows = 1;
			grdYacht.Location = new System.Drawing.Point(6, 14);
			grdYacht.Name = "grdYacht";
			grdYacht.ReadOnly = true;
			grdYacht.RowsCount = 2;
			grdYacht.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grdYacht.ShowCellToolTips = false;
			grdYacht.Size = new System.Drawing.Size(415, 117);
			grdYacht.StandardTab = true;
			grdYacht.TabIndex = 3;
			grdYacht.Click += new System.EventHandler(grdYacht_Click);
			grdYacht.DoubleClick += new System.EventHandler(grdYacht_DoubleClick);
			// 
			// Timer1
			// 
			Timer1.Enabled = true;
			Timer1.Interval = 10000;
			Timer1.Tick += new System.EventHandler(Timer1_Tick);
			// 
			// frmCallback
			// 
			frmCallback.AllowDrop = true;
			frmCallback.BackColor = System.Drawing.SystemColors.Control;
			frmCallback.Controls.Add(grdCallback);
			frmCallback.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmCallback.Enabled = true;
			frmCallback.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmCallback.ForeColor = System.Drawing.SystemColors.ControlText;
			frmCallback.Location = new System.Drawing.Point(4, 578);
			frmCallback.Name = "frmCallback";
			frmCallback.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmCallback.Size = new System.Drawing.Size(431, 137);
			frmCallback.TabIndex = 8;
			frmCallback.Text = "Callback";
			frmCallback.Visible = true;
			// 
			// grdCallback
			// 
			grdCallback.AllowDrop = true;
			grdCallback.AllowUserToAddRows = false;
			grdCallback.AllowUserToDeleteRows = false;
			grdCallback.AllowUserToResizeColumns = false;
			grdCallback.AllowUserToResizeRows = false;
			grdCallback.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grdCallback.ColumnsCount = 2;
			grdCallback.FixedColumns = 1;
			grdCallback.FixedRows = 1;
			grdCallback.Location = new System.Drawing.Point(6, 14);
			grdCallback.Name = "grdCallback";
			grdCallback.ReadOnly = true;
			grdCallback.RowsCount = 2;
			grdCallback.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grdCallback.ShowCellToolTips = false;
			grdCallback.Size = new System.Drawing.Size(415, 117);
			grdCallback.StandardTab = true;
			grdCallback.TabIndex = 9;
			grdCallback.Click += new System.EventHandler(grdCallback_Click);
			grdCallback.DoubleClick += new System.EventHandler(grdCallback_DoubleClick);
			// 
			// frmContact
			// 
			frmContact.AllowDrop = true;
			frmContact.BackColor = System.Drawing.SystemColors.Control;
			frmContact.Controls.Add(grdContact);
			frmContact.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmContact.Enabled = true;
			frmContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmContact.ForeColor = System.Drawing.SystemColors.ControlText;
			frmContact.Location = new System.Drawing.Point(4, 440);
			frmContact.Name = "frmContact";
			frmContact.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmContact.Size = new System.Drawing.Size(431, 137);
			frmContact.TabIndex = 6;
			frmContact.Text = "Contact";
			frmContact.Visible = true;
			// 
			// grdContact
			// 
			grdContact.AllowDrop = true;
			grdContact.AllowUserToAddRows = false;
			grdContact.AllowUserToDeleteRows = false;
			grdContact.AllowUserToResizeColumns = false;
			grdContact.AllowUserToResizeRows = false;
			grdContact.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grdContact.ColumnsCount = 2;
			grdContact.FixedColumns = 1;
			grdContact.FixedRows = 1;
			grdContact.Location = new System.Drawing.Point(6, 14);
			grdContact.Name = "grdContact";
			grdContact.ReadOnly = true;
			grdContact.RowsCount = 2;
			grdContact.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grdContact.ShowCellToolTips = false;
			grdContact.Size = new System.Drawing.Size(415, 117);
			grdContact.StandardTab = true;
			grdContact.TabIndex = 7;
			grdContact.Click += new System.EventHandler(grdContact_Click);
			grdContact.DoubleClick += new System.EventHandler(grdContact_DoubleClick);
			grdContact.MouseMove += new System.Windows.Forms.MouseEventHandler(grdContact_MouseMove);
			// 
			// frmCompany
			// 
			frmCompany.AllowDrop = true;
			frmCompany.BackColor = System.Drawing.SystemColors.Control;
			frmCompany.Controls.Add(grdCompany);
			frmCompany.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmCompany.Enabled = true;
			frmCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmCompany.ForeColor = System.Drawing.SystemColors.ControlText;
			frmCompany.Location = new System.Drawing.Point(4, 302);
			frmCompany.Name = "frmCompany";
			frmCompany.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmCompany.Size = new System.Drawing.Size(431, 137);
			frmCompany.TabIndex = 4;
			frmCompany.Text = "Company";
			frmCompany.Visible = true;
			// 
			// grdCompany
			// 
			grdCompany.AllowDrop = true;
			grdCompany.AllowUserToAddRows = false;
			grdCompany.AllowUserToDeleteRows = false;
			grdCompany.AllowUserToResizeColumns = false;
			grdCompany.AllowUserToResizeRows = false;
			grdCompany.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grdCompany.ColumnsCount = 2;
			grdCompany.FixedColumns = 1;
			grdCompany.FixedRows = 1;
			grdCompany.Location = new System.Drawing.Point(6, 14);
			grdCompany.Name = "grdCompany";
			grdCompany.ReadOnly = true;
			grdCompany.RowsCount = 2;
			grdCompany.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grdCompany.ShowCellToolTips = false;
			grdCompany.Size = new System.Drawing.Size(415, 117);
			grdCompany.StandardTab = true;
			grdCompany.TabIndex = 5;
			grdCompany.Click += new System.EventHandler(grdCompany_Click);
			grdCompany.DoubleClick += new System.EventHandler(grdCompany_DoubleClick);
			// 
			// frmAircraft
			// 
			frmAircraft.AllowDrop = true;
			frmAircraft.BackColor = System.Drawing.SystemColors.Control;
			frmAircraft.Controls.Add(grdAircraft);
			frmAircraft.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmAircraft.Enabled = true;
			frmAircraft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmAircraft.ForeColor = System.Drawing.SystemColors.ControlText;
			frmAircraft.Location = new System.Drawing.Point(4, 28);
			frmAircraft.Name = "frmAircraft";
			frmAircraft.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmAircraft.Size = new System.Drawing.Size(431, 137);
			frmAircraft.TabIndex = 0;
			frmAircraft.Text = "Aircraft";
			frmAircraft.Visible = true;
			// 
			// grdAircraft
			// 
			grdAircraft.AllowDrop = true;
			grdAircraft.AllowUserToAddRows = false;
			grdAircraft.AllowUserToDeleteRows = false;
			grdAircraft.AllowUserToResizeColumns = false;
			grdAircraft.AllowUserToResizeRows = false;
			grdAircraft.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grdAircraft.ColumnsCount = 2;
			grdAircraft.FixedColumns = 1;
			grdAircraft.FixedRows = 1;
			grdAircraft.Location = new System.Drawing.Point(6, 14);
			grdAircraft.Name = "grdAircraft";
			grdAircraft.ReadOnly = true;
			grdAircraft.RowsCount = 2;
			grdAircraft.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grdAircraft.ShowCellToolTips = false;
			grdAircraft.Size = new System.Drawing.Size(415, 117);
			grdAircraft.StandardTab = true;
			grdAircraft.TabIndex = 1;
			grdAircraft.Click += new System.EventHandler(grdAircraft_Click);
			grdAircraft.DoubleClick += new System.EventHandler(grdAircraft_DoubleClick);
			// 
			// frm_UserHistory
			// 
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			ClientSize = new System.Drawing.Size(441, 722);
			Controls.Add(frmYacht);
			Controls.Add(frmCallback);
			Controls.Add(frmContact);
			Controls.Add(frmCompany);
			Controls.Add(frmAircraft);
			Controls.Add(MainMenu1);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			Location = new System.Drawing.Point(773, 171);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "frm_UserHistory";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			ShowInTaskbar = false;
			Text = "User History";
			Activated += new System.EventHandler(frm_UserHistory_Activated);
			Closed += new System.EventHandler(Form_Closed);
			((System.ComponentModel.ISupportInitialize) grdYacht).EndInit();
			((System.ComponentModel.ISupportInitialize) grdCallback).EndInit();
			((System.ComponentModel.ISupportInitialize) grdContact).EndInit();
			((System.ComponentModel.ISupportInitialize) grdCompany).EndInit();
			((System.ComponentModel.ISupportInitialize) grdAircraft).EndInit();
			frmYacht.ResumeLayout(false);
			frmYacht.PerformLayout();
			frmCallback.ResumeLayout(false);
			frmCallback.PerformLayout();
			frmContact.ResumeLayout(false);
			frmContact.PerformLayout();
			frmCompany.ResumeLayout(false);
			frmCompany.PerformLayout();
			frmAircraft.ResumeLayout(false);
			frmAircraft.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
		#endregion
	}
}