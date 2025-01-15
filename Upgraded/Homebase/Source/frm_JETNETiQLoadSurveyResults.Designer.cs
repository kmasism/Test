
namespace JETNET_Homebase
{
	partial class frm_JETNETiQLoadSurveyResults
	{

		#region "Upgrade Support "
		private static frm_JETNETiQLoadSurveyResults m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_JETNETiQLoadSurveyResults DefInstance
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
		public static frm_JETNETiQLoadSurveyResults CreateInstance()
		{
			frm_JETNETiQLoadSurveyResults theInstance = new frm_JETNETiQLoadSurveyResults();
			theInstance.Form_Load();
			return theInstance;
		}
		private string[] visualControls = new string[]{"components", "ToolTipMain", "cmdBrowse", "cmdImport", "lstbJETNETiQSurvey", "txtFileName", "txtJournalSubject", "frmLoadFile", "cDialog", "lblCopyListBoxToClipboard", "lblStatus", "lblFileName", "lblJournalSubject", "listBoxHelper1", "commandButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Button cmdBrowse;
		public System.Windows.Forms.Button cmdImport;
		public System.Windows.Forms.ListBox lstbJETNETiQSurvey;
		public System.Windows.Forms.TextBox txtFileName;
		public System.Windows.Forms.TextBox txtJournalSubject;
		public System.Windows.Forms.GroupBox frmLoadFile;
		public System.Windows.Forms.OpenFileDialog cDialogOpen;
		public System.Windows.Forms.SaveFileDialog cDialogSave;
		public System.Windows.Forms.FontDialog cDialogFont;
		public System.Windows.Forms.ColorDialog cDialogColor;
		public System.Windows.Forms.PrintDialog cDialogPrint;
		public UpgradeStubs.AxMSComDlg_AxCommonDialog cDialog;
		public System.Windows.Forms.Label lblCopyListBoxToClipboard;
		public System.Windows.Forms.Label lblStatus;
		public System.Windows.Forms.Label lblFileName;
		public System.Windows.Forms.Label lblJournalSubject;
		public UpgradeHelpers.Gui.Controls.ListBoxHelper listBoxHelper1;
		public UpgradeHelpers.Gui.Controls.CommandButtonHelper commandButtonHelper1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_JETNETiQLoadSurveyResults));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			cmdBrowse = new System.Windows.Forms.Button();
			cmdImport = new System.Windows.Forms.Button();
			lstbJETNETiQSurvey = new System.Windows.Forms.ListBox();
			txtFileName = new System.Windows.Forms.TextBox();
			txtJournalSubject = new System.Windows.Forms.TextBox();
			frmLoadFile = new System.Windows.Forms.GroupBox();
			cDialogOpen = new System.Windows.Forms.OpenFileDialog();
			cDialogSave = new System.Windows.Forms.SaveFileDialog();
			cDialogFont = new System.Windows.Forms.FontDialog();
			cDialogColor = new System.Windows.Forms.ColorDialog();
			cDialogPrint = new System.Windows.Forms.PrintDialog();
			cDialog = new UpgradeStubs.AxMSComDlg_AxCommonDialog();
			lblCopyListBoxToClipboard = new System.Windows.Forms.Label();
			lblStatus = new System.Windows.Forms.Label();
			lblFileName = new System.Windows.Forms.Label();
			lblJournalSubject = new System.Windows.Forms.Label();
			SuspendLayout();
			listBoxHelper1 = new UpgradeHelpers.Gui.Controls.ListBoxHelper(components);
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
			// 
			// cmdBrowse
			// 
			cmdBrowse.AllowDrop = true;
			cmdBrowse.BackColor = System.Drawing.SystemColors.Control;
			cmdBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdBrowse.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdBrowse.Location = new System.Drawing.Point(434, 24);
			cmdBrowse.Name = "cmdBrowse";
			cmdBrowse.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdBrowse.Size = new System.Drawing.Size(79, 21);
			cmdBrowse.TabIndex = 6;
			cmdBrowse.Text = "Browse File";
			cmdBrowse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdBrowse.UseVisualStyleBackColor = false;
			cmdBrowse.Click += new System.EventHandler(cmdBrowse_Click);
			// 
			// cmdImport
			// 
			cmdImport.AllowDrop = true;
			cmdImport.BackColor = System.Drawing.SystemColors.Control;
			cmdImport.Enabled = false;
			cmdImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdImport.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdImport.Location = new System.Drawing.Point(10, 94);
			cmdImport.Name = "cmdImport";
			cmdImport.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdImport.Size = new System.Drawing.Size(71, 27);
			cmdImport.TabIndex = 5;
			cmdImport.Text = "Import";
			cmdImport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdImport.Click += new System.EventHandler(cmdImport_Click);
			// 
			// lstbJETNETiQSurvey
			// 
			lstbJETNETiQSurvey.AllowDrop = true;
			lstbJETNETiQSurvey.BackColor = System.Drawing.SystemColors.Window;
			lstbJETNETiQSurvey.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			lstbJETNETiQSurvey.CausesValidation = true;
			lstbJETNETiQSurvey.Enabled = true;
			lstbJETNETiQSurvey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lstbJETNETiQSurvey.ForeColor = System.Drawing.SystemColors.WindowText;
			lstbJETNETiQSurvey.IntegralHeight = true;
			lstbJETNETiQSurvey.Location = new System.Drawing.Point(0, 148);
			lstbJETNETiQSurvey.MultiColumn = false;
			lstbJETNETiQSurvey.Name = "lstbJETNETiQSurvey";
			lstbJETNETiQSurvey.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lstbJETNETiQSurvey.Size = new System.Drawing.Size(653, 202);
			lstbJETNETiQSurvey.Sorted = false;
			lstbJETNETiQSurvey.TabIndex = 7;
			lstbJETNETiQSurvey.TabStop = true;
			lstbJETNETiQSurvey.Visible = true;
			// 
			// txtFileName
			// 
			txtFileName.AcceptsReturn = true;
			txtFileName.AllowDrop = true;
			txtFileName.BackColor = System.Drawing.SystemColors.Window;
			txtFileName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtFileName.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtFileName.ForeColor = System.Drawing.SystemColors.WindowText;
			txtFileName.Location = new System.Drawing.Point(144, 50);
			txtFileName.MaxLength = 0;
			txtFileName.Name = "txtFileName";
			txtFileName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtFileName.Size = new System.Drawing.Size(369, 23);
			txtFileName.TabIndex = 3;
			// 
			// txtJournalSubject
			// 
			txtJournalSubject.AcceptsReturn = true;
			txtJournalSubject.AllowDrop = true;
			txtJournalSubject.BackColor = System.Drawing.SystemColors.Window;
			txtJournalSubject.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtJournalSubject.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtJournalSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtJournalSubject.ForeColor = System.Drawing.SystemColors.WindowText;
			txtJournalSubject.Location = new System.Drawing.Point(144, 22);
			txtJournalSubject.MaxLength = 0;
			txtJournalSubject.Name = "txtJournalSubject";
			txtJournalSubject.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtJournalSubject.Size = new System.Drawing.Size(279, 21);
			txtJournalSubject.TabIndex = 2;
			txtJournalSubject.Text = "{STATUS} Q#/YYYY Survey {CONTACTNAME}";
			// 
			// frmLoadFile
			// 
			frmLoadFile.AllowDrop = true;
			frmLoadFile.BackColor = System.Drawing.SystemColors.Control;
			frmLoadFile.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmLoadFile.Enabled = true;
			frmLoadFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmLoadFile.ForeColor = System.Drawing.SystemColors.ControlText;
			frmLoadFile.Location = new System.Drawing.Point(520, 20);
			frmLoadFile.Name = "frmLoadFile";
			frmLoadFile.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmLoadFile.Size = new System.Drawing.Size(131, 109);
			frmLoadFile.TabIndex = 0;
			frmLoadFile.Text = "Drag Excel File Here";
			frmLoadFile.Visible = true;
			frmLoadFile.DoubleClick += new System.EventHandler(frmLoadFile_DoubleClick);
			// 
			// lblCopyListBoxToClipboard
			// 
			lblCopyListBoxToClipboard.AllowDrop = true;
			lblCopyListBoxToClipboard.BackColor = System.Drawing.SystemColors.Control;
			lblCopyListBoxToClipboard.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblCopyListBoxToClipboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblCopyListBoxToClipboard.ForeColor = System.Drawing.Color.Blue;
			lblCopyListBoxToClipboard.Location = new System.Drawing.Point(246, 360);
			lblCopyListBoxToClipboard.MinimumSize = new System.Drawing.Size(165, 13);
			lblCopyListBoxToClipboard.Name = "lblCopyListBoxToClipboard";
			lblCopyListBoxToClipboard.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblCopyListBoxToClipboard.Size = new System.Drawing.Size(165, 13);
			lblCopyListBoxToClipboard.TabIndex = 9;
			lblCopyListBoxToClipboard.Text = "Copy Import Results to Clipboard";
			lblCopyListBoxToClipboard.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			lblCopyListBoxToClipboard.Visible = false;
			lblCopyListBoxToClipboard.Click += new System.EventHandler(lblCopyListBoxToClipboard_Click);
			// 
			// lblStatus
			// 
			lblStatus.AllowDrop = true;
			lblStatus.BackColor = System.Drawing.SystemColors.Control;
			lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblStatus.ForeColor = System.Drawing.SystemColors.ControlText;
			lblStatus.Location = new System.Drawing.Point(144, 90);
			lblStatus.MinimumSize = new System.Drawing.Size(369, 23);
			lblStatus.Name = "lblStatus";
			lblStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblStatus.Size = new System.Drawing.Size(369, 23);
			lblStatus.TabIndex = 8;
			lblStatus.Text = "Working [0]  Added [0]  Not Found [0]";
			lblStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lblFileName
			// 
			lblFileName.AllowDrop = true;
			lblFileName.BackColor = System.Drawing.SystemColors.Control;
			lblFileName.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblFileName.ForeColor = System.Drawing.SystemColors.ControlText;
			lblFileName.Location = new System.Drawing.Point(6, 54);
			lblFileName.MinimumSize = new System.Drawing.Size(131, 17);
			lblFileName.Name = "lblFileName";
			lblFileName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblFileName.Size = new System.Drawing.Size(131, 17);
			lblFileName.TabIndex = 4;
			lblFileName.Text = "Survey Results File Name";
			// 
			// lblJournalSubject
			// 
			lblJournalSubject.AllowDrop = true;
			lblJournalSubject.BackColor = System.Drawing.SystemColors.Control;
			lblJournalSubject.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblJournalSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblJournalSubject.ForeColor = System.Drawing.SystemColors.ControlText;
			lblJournalSubject.Location = new System.Drawing.Point(6, 24);
			lblJournalSubject.MinimumSize = new System.Drawing.Size(79, 17);
			lblJournalSubject.Name = "lblJournalSubject";
			lblJournalSubject.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblJournalSubject.Size = new System.Drawing.Size(79, 17);
			lblJournalSubject.TabIndex = 1;
			lblJournalSubject.Text = "Journal Subject";
			// 
			// frm_JETNETiQLoadSurveyResults
			// 
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			ClientSize = new System.Drawing.Size(659, 379);
			Controls.Add(cmdBrowse);
			Controls.Add(cmdImport);
			Controls.Add(lstbJETNETiQSurvey);
			Controls.Add(txtFileName);
			Controls.Add(txtJournalSubject);
			Controls.Add(frmLoadFile);
			Controls.Add(lblCopyListBoxToClipboard);
			Controls.Add(lblStatus);
			Controls.Add(lblFileName);
			Controls.Add(lblJournalSubject);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Location = new System.Drawing.Point(488, 196);
			MaximizeBox = true;
			MinimizeBox = true;
			Name = "frm_JETNETiQLoadSurveyResults";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			Text = "JETNETiQ Load Survey Results";
			commandButtonHelper1.SetStyle(cmdBrowse, 0);
			commandButtonHelper1.SetStyle(cmdImport, 0);
			listBoxHelper1.SetSelectionMode(lstbJETNETiQSurvey, System.Windows.Forms.SelectionMode.One);
			ToolTipMain.SetToolTip(cmdBrowse, "Click To Browse For Download Excel File (.xls, .xlsx)");
			ToolTipMain.SetToolTip(frmLoadFile, "Drag Excel Here To Add or Double Click To Open Browse Window");
			Activated += new System.EventHandler(frm_JETNETiQLoadSurveyResults_Activated);
			Closed += new System.EventHandler(Form_Closed);
			ResumeLayout(false);
			PerformLayout();
		}
		#endregion
	}
}