
namespace JETNET_Homebase
{
	partial class frm_JournalListPopUp
	{

		#region "Upgrade Support "
		private static frm_JournalListPopUp m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_JournalListPopUp DefInstance
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
		public static frm_JournalListPopUp CreateInstance()
		{
			frm_JournalListPopUp theInstance = new frm_JournalListPopUp();
			return theInstance;
		}
		private string[] visualControls = new string[]{"components", "ToolTipMain", "cmdClose", "CmdSelect", "cmdStop", "grdJournal", "commandButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Button cmdClose;
		public System.Windows.Forms.Button CmdSelect;
		public System.Windows.Forms.Button cmdStop;
		public UpgradeHelpers.DataGridViewFlex grdJournal;
		public UpgradeHelpers.Gui.Controls.CommandButtonHelper commandButtonHelper1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_JournalListPopUp));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			cmdClose = new System.Windows.Forms.Button();
			CmdSelect = new System.Windows.Forms.Button();
			cmdStop = new System.Windows.Forms.Button();
			grdJournal = new UpgradeHelpers.DataGridViewFlex(components);
			SuspendLayout();
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
			((System.ComponentModel.ISupportInitialize) grdJournal).BeginInit();
			// 
			// cmdClose
			// 
			cmdClose.AllowDrop = true;
			cmdClose.BackColor = System.Drawing.SystemColors.Control;
			cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdClose.Location = new System.Drawing.Point(324, 366);
			cmdClose.Name = "cmdClose";
			cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdClose.Size = new System.Drawing.Size(66, 21);
			cmdClose.TabIndex = 2;
			cmdClose.Text = "Close";
			cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdClose.UseVisualStyleBackColor = false;
			cmdClose.Click += new System.EventHandler(cmdClose_Click);
			// 
			// CmdSelect
			// 
			CmdSelect.AllowDrop = true;
			CmdSelect.BackColor = System.Drawing.SystemColors.Control;
			CmdSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			CmdSelect.ForeColor = System.Drawing.SystemColors.ControlText;
			CmdSelect.Location = new System.Drawing.Point(237, 366);
			CmdSelect.Name = "CmdSelect";
			CmdSelect.RightToLeft = System.Windows.Forms.RightToLeft.No;
			CmdSelect.Size = new System.Drawing.Size(66, 21);
			CmdSelect.TabIndex = 1;
			CmdSelect.Text = "Select";
			CmdSelect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			CmdSelect.UseVisualStyleBackColor = false;
			CmdSelect.Click += new System.EventHandler(CmdSelect_Click);
			// 
			// cmdStop
			// 
			cmdStop.AllowDrop = true;
			cmdStop.BackColor = System.Drawing.SystemColors.Control;
			cmdStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdStop.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdStop.Location = new System.Drawing.Point(411, 366);
			cmdStop.Name = "cmdStop";
			cmdStop.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdStop.Size = new System.Drawing.Size(66, 21);
			cmdStop.TabIndex = 0;
			cmdStop.Text = "Stop";
			cmdStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdStop.UseVisualStyleBackColor = false;
			cmdStop.Visible = false;
			cmdStop.Click += new System.EventHandler(cmdStop_Click);
			// 
			// grdJournal
			// 
			grdJournal.AllowDrop = true;
			grdJournal.AllowUserToAddRows = false;
			grdJournal.AllowUserToDeleteRows = false;
			grdJournal.AllowUserToResizeColumns = false;
			grdJournal.AllowUserToResizeColumns = grdJournal.ColumnHeadersVisible;
			grdJournal.AllowUserToResizeRows = false;
			grdJournal.AllowUserToResizeRows = grdJournal.RowHeadersVisible;
			grdJournal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grdJournal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grdJournal.ColumnsCount = 2;
			grdJournal.FixedColumns = 0;
			grdJournal.FixedRows = 1;
			grdJournal.Location = new System.Drawing.Point(14, 12);
			grdJournal.Name = "grdJournal";
			grdJournal.ReadOnly = true;
			grdJournal.RowsCount = 2;
			grdJournal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grdJournal.ShowCellToolTips = false;
			grdJournal.Size = new System.Drawing.Size(684, 345);
			grdJournal.StandardTab = true;
			grdJournal.TabIndex = 3;
			grdJournal.Click += new System.EventHandler(grdJournal_Click);
			grdJournal.DoubleClick += new System.EventHandler(grdJournal_DoubleClick);
			// 
			// frm_JournalListPopUp
			// 
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			ClientSize = new System.Drawing.Size(713, 395);
			ControlBox = false;
			Controls.Add(cmdClose);
			Controls.Add(CmdSelect);
			Controls.Add(cmdStop);
			Controls.Add(grdJournal);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			Location = new System.Drawing.Point(439, 295);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "frm_JournalListPopUp";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			Text = "Journal List";
			commandButtonHelper1.SetStyle(cmdClose, 0);
			commandButtonHelper1.SetStyle(CmdSelect, 0);
			commandButtonHelper1.SetStyle(cmdStop, 0);
			Activated += new System.EventHandler(Form_Activated);
			Closed += new System.EventHandler(Form_Closed);
			((System.ComponentModel.ISupportInitialize) grdJournal).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
		#endregion
	}
}