
namespace JETNET_Homebase
{
	partial class frm_NTSB_New
	{

		#region "Upgrade Support "
		private static frm_NTSB_New m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_NTSB_New DefInstance
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
		public static frm_NTSB_New CreateInstance()
		{
			frm_NTSB_New theInstance = new frm_NTSB_New();
			theInstance.Form_Load();
			return theInstance;
		}
		private string[] visualControls = new string[]{"components", "ToolTipMain", "pbNTSB", "cmdProcessNTSBReport", "cmdReloadNTSBReport", "txtACID", "txtNTSBURLParameters", "inNTSBInet", "txtNTSBURL", "cmdDownloadNTSBReport", "fgridNTSB", "txtNTSBDate", "mvNTSBCal", "cmdClose", "lblNTSBURLParameters", "lblNTSBURL", "commandButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.ProgressBar pbNTSB;
		public System.Windows.Forms.Button cmdProcessNTSBReport;
		public System.Windows.Forms.Button cmdReloadNTSBReport;
		public System.Windows.Forms.TextBox txtACID;
		public System.Windows.Forms.TextBox txtNTSBURLParameters;
		public dynamic inNTSBInet; //gap-note this control must be defined during Blazor stabilization
		public System.Windows.Forms.TextBox txtNTSBURL;
		public System.Windows.Forms.Button cmdDownloadNTSBReport;
		public UpgradeHelpers.DataGridViewFlex fgridNTSB;
		public System.Windows.Forms.TextBox txtNTSBDate;
		public System.Windows.Forms.MonthCalendar mvNTSBCal;
		public System.Windows.Forms.Button cmdClose;
		public System.Windows.Forms.Label lblNTSBURLParameters;
		public System.Windows.Forms.Label lblNTSBURL;
		public UpgradeHelpers.Gui.Controls.CommandButtonHelper commandButtonHelper1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_NTSB_New));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			pbNTSB = new System.Windows.Forms.ProgressBar();
			cmdProcessNTSBReport = new System.Windows.Forms.Button();
			cmdReloadNTSBReport = new System.Windows.Forms.Button();
			txtACID = new System.Windows.Forms.TextBox();
			txtNTSBURLParameters = new System.Windows.Forms.TextBox();
			//inNTSBInet = new AxInetCtlsObjects.AxInet(); //gap-note this control must be defined during Blazor stabilization
			txtNTSBURL = new System.Windows.Forms.TextBox();
			cmdDownloadNTSBReport = new System.Windows.Forms.Button();
			fgridNTSB = new UpgradeHelpers.DataGridViewFlex(components);
			txtNTSBDate = new System.Windows.Forms.TextBox();
			mvNTSBCal = new System.Windows.Forms.MonthCalendar();
			cmdClose = new System.Windows.Forms.Button();
			lblNTSBURLParameters = new System.Windows.Forms.Label();
			lblNTSBURL = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize) inNTSBInet).BeginInit();
			SuspendLayout();
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
			((System.ComponentModel.ISupportInitialize) fgridNTSB).BeginInit();
			// 
			// pbNTSB
			// 
			pbNTSB.AllowDrop = true;
			pbNTSB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pbNTSB.Location = new System.Drawing.Point(748, 216);
			pbNTSB.Name = "pbNTSB";
			pbNTSB.Size = new System.Drawing.Size(233, 19);
			pbNTSB.TabIndex = 12;
			// 
			// cmdProcessNTSBReport
			// 
			cmdProcessNTSBReport.AllowDrop = true;
			cmdProcessNTSBReport.BackColor = System.Drawing.SystemColors.Control;
			cmdProcessNTSBReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdProcessNTSBReport.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdProcessNTSBReport.Location = new System.Drawing.Point(506, 130);
			cmdProcessNTSBReport.Name = "cmdProcessNTSBReport";
			cmdProcessNTSBReport.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdProcessNTSBReport.Size = new System.Drawing.Size(145, 29);
			cmdProcessNTSBReport.TabIndex = 11;
			cmdProcessNTSBReport.Text = "Process NTSB Report";
			cmdProcessNTSBReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdProcessNTSBReport.UseVisualStyleBackColor = false;
			cmdProcessNTSBReport.Visible = false;
			cmdProcessNTSBReport.Click += new System.EventHandler(cmdProcessNTSBReport_Click);
			// 
			// cmdReloadNTSBReport
			// 
			cmdReloadNTSBReport.AllowDrop = true;
			cmdReloadNTSBReport.BackColor = System.Drawing.SystemColors.Control;
			cmdReloadNTSBReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdReloadNTSBReport.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdReloadNTSBReport.Location = new System.Drawing.Point(506, 94);
			cmdReloadNTSBReport.Name = "cmdReloadNTSBReport";
			cmdReloadNTSBReport.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdReloadNTSBReport.Size = new System.Drawing.Size(145, 29);
			cmdReloadNTSBReport.TabIndex = 10;
			cmdReloadNTSBReport.Text = "Reload NTSB Report";
			cmdReloadNTSBReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdReloadNTSBReport.UseVisualStyleBackColor = false;
			cmdReloadNTSBReport.Visible = false;
			cmdReloadNTSBReport.Click += new System.EventHandler(cmdReloadNTSBReport_Click);
			// 
			// txtACID
			// 
			txtACID.AcceptsReturn = true;
			txtACID.AllowDrop = true;
			txtACID.BackColor = System.Drawing.Color.Yellow;
			txtACID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtACID.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtACID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtACID.ForeColor = System.Drawing.SystemColors.WindowText;
			txtACID.Location = new System.Drawing.Point(18, 100);
			txtACID.MaxLength = 0;
			txtACID.Name = "txtACID";
			txtACID.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtACID.Size = new System.Drawing.Size(89, 19);
			txtACID.TabIndex = 9;
			txtACID.Visible = false;
			txtACID.Leave += new System.EventHandler(txtACID_Leave);
			// 
			// txtNTSBURLParameters
			// 
			txtNTSBURLParameters.AcceptsReturn = true;
			txtNTSBURLParameters.AllowDrop = true;
			txtNTSBURLParameters.BackColor = System.Drawing.SystemColors.Window;
			txtNTSBURLParameters.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtNTSBURLParameters.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtNTSBURLParameters.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtNTSBURLParameters.ForeColor = System.Drawing.SystemColors.WindowText;
			txtNTSBURLParameters.Location = new System.Drawing.Point(458, 216);
			txtNTSBURLParameters.MaxLength = 0;
			txtNTSBURLParameters.Name = "txtNTSBURLParameters";
			txtNTSBURLParameters.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtNTSBURLParameters.Size = new System.Drawing.Size(287, 19);
			txtNTSBURLParameters.TabIndex = 7;
			txtNTSBURLParameters.Tag = "f?p=100:93:::NO";
			txtNTSBURLParameters.Text = "f?p=100:93:::NO";
			// 
			// inNTSBInet
			// 
			inNTSBInet.AllowDrop = true;
			inNTSBInet.Location = new System.Drawing.Point(16, 58);
			inNTSBInet.Name = "inNTSBInet";
			inNTSBInet.OcxState = (System.Windows.Forms.AxHost.State) resources.GetObject("inNTSBInet.OcxState");
			// 
			// txtNTSBURL
			// 
			txtNTSBURL.AcceptsReturn = true;
			txtNTSBURL.AllowDrop = true;
			txtNTSBURL.BackColor = System.Drawing.SystemColors.Window;
			txtNTSBURL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtNTSBURL.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtNTSBURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtNTSBURL.ForeColor = System.Drawing.SystemColors.WindowText;
			txtNTSBURL.Location = new System.Drawing.Point(48, 216);
			txtNTSBURL.MaxLength = 0;
			txtNTSBURL.Name = "txtNTSBURL";
			txtNTSBURL.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtNTSBURL.Size = new System.Drawing.Size(287, 19);
			txtNTSBURL.TabIndex = 6;
			txtNTSBURL.Tag = "https://www.asias.faa.gov/apex/";
			txtNTSBURL.Text = "https://www.asias.faa.gov/apex/";
			// 
			// cmdDownloadNTSBReport
			// 
			cmdDownloadNTSBReport.AllowDrop = true;
			cmdDownloadNTSBReport.BackColor = System.Drawing.SystemColors.Control;
			cmdDownloadNTSBReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdDownloadNTSBReport.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdDownloadNTSBReport.Location = new System.Drawing.Point(506, 56);
			cmdDownloadNTSBReport.Name = "cmdDownloadNTSBReport";
			cmdDownloadNTSBReport.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdDownloadNTSBReport.Size = new System.Drawing.Size(145, 29);
			cmdDownloadNTSBReport.TabIndex = 4;
			cmdDownloadNTSBReport.Text = "Download NTSB Report";
			cmdDownloadNTSBReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdDownloadNTSBReport.UseVisualStyleBackColor = false;
			cmdDownloadNTSBReport.Click += new System.EventHandler(cmdDownloadNTSBReport_Click);
			// 
			// fgridNTSB
			// 
			fgridNTSB.AllowDrop = true;
			fgridNTSB.AllowUserToAddRows = false;
			fgridNTSB.AllowUserToDeleteRows = false;
			fgridNTSB.AllowUserToResizeColumns = false;
			fgridNTSB.AllowUserToResizeColumns = fgridNTSB.ColumnHeadersVisible;
			fgridNTSB.AllowUserToResizeRows = false;
			fgridNTSB.AllowUserToResizeRows = false;
			fgridNTSB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			fgridNTSB.ColumnsCount = 2;
			fgridNTSB.FixedColumns = 1;
			fgridNTSB.FixedRows = 1;
			fgridNTSB.Location = new System.Drawing.Point(8, 236);
			fgridNTSB.Name = "fgridNTSB";
			fgridNTSB.ReadOnly = true;
			fgridNTSB.RowsCount = 2;
			fgridNTSB.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			fgridNTSB.ShowCellToolTips = false;
			fgridNTSB.Size = new System.Drawing.Size(975, 379);
			fgridNTSB.StandardTab = true;
			fgridNTSB.TabIndex = 3;
			fgridNTSB.Click += new System.EventHandler(fgridNTSB_Click);
			// 
			// txtNTSBDate
			// 
			txtNTSBDate.AcceptsReturn = true;
			txtNTSBDate.AllowDrop = true;
			txtNTSBDate.BackColor = System.Drawing.SystemColors.Window;
			txtNTSBDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtNTSBDate.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtNTSBDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtNTSBDate.ForeColor = System.Drawing.SystemColors.WindowText;
			txtNTSBDate.Location = new System.Drawing.Point(330, 18);
			txtNTSBDate.MaxLength = 0;
			txtNTSBDate.Name = "txtNTSBDate";
			txtNTSBDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtNTSBDate.Size = new System.Drawing.Size(103, 23);
			txtNTSBDate.TabIndex = 2;
			txtNTSBDate.Text = "mm/dd/ccyy";
			txtNTSBDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			txtNTSBDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtNTSBDate_KeyPress);
			// 
			// mvNTSBCal
			// 
			mvNTSBCal.AllowDrop = true;
			mvNTSBCal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			mvNTSBCal.ForeColor = System.Drawing.SystemColors.ControlText;
			mvNTSBCal.Location = new System.Drawing.Point(290, 54);
			mvNTSBCal.Name = "mvNTSBCal";
			mvNTSBCal.Size = new System.Drawing.Size(180, 158);
			mvNTSBCal.TabIndex = 1;
			// 
			// cmdClose
			// 
			cmdClose.AllowDrop = true;
			cmdClose.BackColor = System.Drawing.SystemColors.Control;
			cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdClose.Location = new System.Drawing.Point(8, 12);
			cmdClose.Name = "cmdClose";
			cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdClose.Size = new System.Drawing.Size(63, 31);
			cmdClose.TabIndex = 0;
			cmdClose.Text = "Close";
			cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdClose.UseVisualStyleBackColor = false;
			cmdClose.Click += new System.EventHandler(cmdClose_Click);
			// 
			// lblNTSBURLParameters
			// 
			lblNTSBURLParameters.AllowDrop = true;
			lblNTSBURLParameters.BackColor = System.Drawing.SystemColors.Control;
			lblNTSBURLParameters.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblNTSBURLParameters.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblNTSBURLParameters.ForeColor = System.Drawing.SystemColors.ControlText;
			lblNTSBURLParameters.Location = new System.Drawing.Point(364, 218);
			lblNTSBURLParameters.MinimumSize = new System.Drawing.Size(87, 17);
			lblNTSBURLParameters.Name = "lblNTSBURLParameters";
			lblNTSBURLParameters.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblNTSBURLParameters.Size = new System.Drawing.Size(87, 17);
			lblNTSBURLParameters.TabIndex = 8;
			lblNTSBURLParameters.Text = "URL Parameters";
			// 
			// lblNTSBURL
			// 
			lblNTSBURL.AllowDrop = true;
			lblNTSBURL.BackColor = System.Drawing.SystemColors.Control;
			lblNTSBURL.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblNTSBURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblNTSBURL.ForeColor = System.Drawing.SystemColors.ControlText;
			lblNTSBURL.Location = new System.Drawing.Point(12, 218);
			lblNTSBURL.MinimumSize = new System.Drawing.Size(33, 17);
			lblNTSBURL.Name = "lblNTSBURL";
			lblNTSBURL.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblNTSBURL.Size = new System.Drawing.Size(33, 17);
			lblNTSBURL.TabIndex = 5;
			lblNTSBURL.Text = "URL";
			// 
			// frm_NTSB_New
			// 
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			ClientSize = new System.Drawing.Size(991, 627);
			Controls.Add(pbNTSB);
			Controls.Add(cmdProcessNTSBReport);
			Controls.Add(cmdReloadNTSBReport);
			Controls.Add(txtACID);
			Controls.Add(txtNTSBURLParameters);
			Controls.Add(inNTSBInet);
			Controls.Add(txtNTSBURL);
			Controls.Add(cmdDownloadNTSBReport);
			Controls.Add(fgridNTSB);
			Controls.Add(txtNTSBDate);
			Controls.Add(mvNTSBCal);
			Controls.Add(cmdClose);
			Controls.Add(lblNTSBURLParameters);
			Controls.Add(lblNTSBURL);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Location = new System.Drawing.Point(136, 158);
			MaximizeBox = true;
			MinimizeBox = true;
			Name = "frm_NTSB_New";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			Text = "NTSB ";
			commandButtonHelper1.SetStyle(cmdProcessNTSBReport, 0);
			commandButtonHelper1.SetStyle(cmdReloadNTSBReport, 0);
			commandButtonHelper1.SetStyle(cmdDownloadNTSBReport, 0);
			commandButtonHelper1.SetStyle(cmdClose, 0);
			ToolTipMain.SetToolTip(cmdProcessNTSBReport, "Click To Process NTSB CSV File");
			ToolTipMain.SetToolTip(cmdReloadNTSBReport, "Click To Reload Grid With Already Downloaded NTSB CSV File");
			ToolTipMain.SetToolTip(cmdDownloadNTSBReport, "Click To Download New NTSB CSV File");
			Activated += new System.EventHandler(frm_NTSB_New_Activated);
			Closed += new System.EventHandler(Form_Closed);
			((System.ComponentModel.ISupportInitialize) fgridNTSB).EndInit();
			((System.ComponentModel.ISupportInitialize) inNTSBInet).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
		#endregion
	}
}