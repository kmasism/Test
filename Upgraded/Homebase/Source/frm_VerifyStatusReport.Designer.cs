
namespace JETNET_Homebase
{
	partial class frm_VerifyStatusReport
	{

		#region "Upgrade Support "
		private static frm_VerifyStatusReport m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_VerifyStatusReport DefInstance
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
		public static frm_VerifyStatusReport CreateInstance()
		{
			frm_VerifyStatusReport theInstance = new frm_VerifyStatusReport();
			theInstance.Form_Load();
			return theInstance;
		}
		private string[] visualControls = new string[]{"components", "ToolTipMain", "cmdClose", "cmdClipboard", "msfgResults", "lblVerifyStatus", "commandButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Button cmdClose;
		public System.Windows.Forms.Button cmdClipboard;
		public UpgradeHelpers.DataGridViewFlex msfgResults;
		public System.Windows.Forms.Label lblVerifyStatus;
		public UpgradeHelpers.Gui.Controls.CommandButtonHelper commandButtonHelper1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_VerifyStatusReport));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			cmdClose = new System.Windows.Forms.Button();
			cmdClipboard = new System.Windows.Forms.Button();
			msfgResults = new UpgradeHelpers.DataGridViewFlex(components);
			lblVerifyStatus = new System.Windows.Forms.Label();
			SuspendLayout();
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
			((System.ComponentModel.ISupportInitialize) msfgResults).BeginInit();
			// 
			// cmdClose
			// 
			cmdClose.AllowDrop = true;
			cmdClose.BackColor = System.Drawing.SystemColors.Control;
			cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdClose.Location = new System.Drawing.Point(413, 206);
			cmdClose.Name = "cmdClose";
			cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdClose.Size = new System.Drawing.Size(107, 28);
			cmdClose.TabIndex = 3;
			cmdClose.Text = "&Close";
			cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdClose.UseVisualStyleBackColor = false;
			cmdClose.Click += new System.EventHandler(cmdClose_Click);
			// 
			// cmdClipboard
			// 
			cmdClipboard.AllowDrop = true;
			cmdClipboard.BackColor = System.Drawing.SystemColors.Control;
			cmdClipboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdClipboard.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdClipboard.Location = new System.Drawing.Point(254, 206);
			cmdClipboard.Name = "cmdClipboard";
			cmdClipboard.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdClipboard.Size = new System.Drawing.Size(107, 28);
			cmdClipboard.TabIndex = 2;
			cmdClipboard.Text = "Clip&board";
			cmdClipboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdClipboard.UseVisualStyleBackColor = false;
			cmdClipboard.Click += new System.EventHandler(cmdClipboard_Click);
			// 
			// msfgResults
			// 
			msfgResults.AllowDrop = true;
			msfgResults.AllowUserToAddRows = false;
			msfgResults.AllowUserToDeleteRows = false;
			msfgResults.AllowUserToResizeColumns = false;
			msfgResults.AllowUserToResizeRows = false;
			msfgResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			msfgResults.ColumnsCount = 2;
			msfgResults.FixedColumns = 1;
			msfgResults.FixedRows = 1;
			msfgResults.Location = new System.Drawing.Point(25, 53);
			msfgResults.Name = "msfgResults";
			msfgResults.ReadOnly = true;
			msfgResults.RowsCount = 2;
			msfgResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			msfgResults.ShowCellToolTips = false;
			msfgResults.Size = new System.Drawing.Size(738, 133);
			msfgResults.StandardTab = true;
			msfgResults.TabIndex = 0;
			// 
			// lblVerifyStatus
			// 
			lblVerifyStatus.AllowDrop = true;
			lblVerifyStatus.BackColor = System.Drawing.SystemColors.Control;
			lblVerifyStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblVerifyStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblVerifyStatus.ForeColor = System.Drawing.SystemColors.ControlText;
			lblVerifyStatus.Location = new System.Drawing.Point(314, 13);
			lblVerifyStatus.MinimumSize = new System.Drawing.Size(178, 19);
			lblVerifyStatus.Name = "lblVerifyStatus";
			lblVerifyStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblVerifyStatus.Size = new System.Drawing.Size(178, 19);
			lblVerifyStatus.TabIndex = 1;
			lblVerifyStatus.Text = "Verify Status Report";
			lblVerifyStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// frm_VerifyStatusReport
			// 
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			ClientSize = new System.Drawing.Size(787, 241);
			Controls.Add(cmdClose);
			Controls.Add(cmdClipboard);
			Controls.Add(msfgResults);
			Controls.Add(lblVerifyStatus);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Location = new System.Drawing.Point(268, 169);
			MaximizeBox = true;
			MinimizeBox = true;
			Name = "frm_VerifyStatusReport";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			Text = "Verify Status Report";
			commandButtonHelper1.SetStyle(cmdClose, 0);
			commandButtonHelper1.SetStyle(cmdClipboard, 0);
			Activated += new System.EventHandler(Form_Activated);
			Closed += new System.EventHandler(Form_Closed);
			FormClosing += new System.Windows.Forms.FormClosingEventHandler(Form_FormClosing);
			((System.ComponentModel.ISupportInitialize) msfgResults).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
		#endregion
	}
}