
namespace JETNET_Homebase
{
	partial class frm_AttachSpecDoc
	{

		#region "Upgrade Support "
		private static frm_AttachSpecDoc m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_AttachSpecDoc DefInstance
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
		public static frm_AttachSpecDoc CreateInstance()
		{
			frm_AttachSpecDoc theInstance = new frm_AttachSpecDoc();
			theInstance.Form_Load();
			return theInstance;
		}
		private string[] visualControls = new string[]{"components", "ToolTipMain", "txtSpecACId", "txtSpecDocumentDescription", "txtSpecDocumentSubject", "cmdSpecDocumentDelete", "cmdSpecDocumentNew", "cmdSpecDocumentSave", "cmdSpecDocumentView", "frmSpecDocumentControl", "txtSpecDocumentId", "txtSpecDocumentDate", "txtSpecDragDocument", "grd_SpecDocument", "calSpecDocumentDate", "wbSpecBrowser1", "lblSpecACId", "lblSpecContractDescription", "lblSpecDocumentSubject", "lblSpecDocumentlId", "lblSpecDocumentDate", "frmSpecDocuments", "commandButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtSpecACId;
		public System.Windows.Forms.TextBox txtSpecDocumentDescription;
		public System.Windows.Forms.TextBox txtSpecDocumentSubject;
		public System.Windows.Forms.Button cmdSpecDocumentDelete;
		public System.Windows.Forms.Button cmdSpecDocumentNew;
		public System.Windows.Forms.Button cmdSpecDocumentSave;
		public System.Windows.Forms.Button cmdSpecDocumentView;
		public System.Windows.Forms.GroupBox frmSpecDocumentControl;
		public System.Windows.Forms.TextBox txtSpecDocumentId;
		public System.Windows.Forms.TextBox txtSpecDocumentDate;
		public System.Windows.Forms.TextBox txtSpecDragDocument;
		public UpgradeHelpers.DataGridViewFlex grd_SpecDocument;
		public System.Windows.Forms.MonthCalendar calSpecDocumentDate;
		public System.Windows.Forms.WebBrowser wbSpecBrowser1;
		public System.Windows.Forms.Label lblSpecACId;
		public System.Windows.Forms.Label lblSpecContractDescription;
		public System.Windows.Forms.Label lblSpecDocumentSubject;
		public System.Windows.Forms.Label lblSpecDocumentlId;
		public System.Windows.Forms.Label lblSpecDocumentDate;
		public System.Windows.Forms.GroupBox frmSpecDocuments;
		public UpgradeHelpers.Gui.Controls.CommandButtonHelper commandButtonHelper1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_AttachSpecDoc));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			frmSpecDocuments = new System.Windows.Forms.GroupBox();
			txtSpecACId = new System.Windows.Forms.TextBox();
			txtSpecDocumentDescription = new System.Windows.Forms.TextBox();
			txtSpecDocumentSubject = new System.Windows.Forms.TextBox();
			frmSpecDocumentControl = new System.Windows.Forms.GroupBox();
			cmdSpecDocumentDelete = new System.Windows.Forms.Button();
			cmdSpecDocumentNew = new System.Windows.Forms.Button();
			cmdSpecDocumentSave = new System.Windows.Forms.Button();
			cmdSpecDocumentView = new System.Windows.Forms.Button();
			txtSpecDocumentId = new System.Windows.Forms.TextBox();
			txtSpecDocumentDate = new System.Windows.Forms.TextBox();
			txtSpecDragDocument = new System.Windows.Forms.TextBox();
			grd_SpecDocument = new UpgradeHelpers.DataGridViewFlex(components);
			calSpecDocumentDate = new System.Windows.Forms.MonthCalendar();
			wbSpecBrowser1 = new System.Windows.Forms.WebBrowser();
			lblSpecACId = new System.Windows.Forms.Label();
			lblSpecContractDescription = new System.Windows.Forms.Label();
			lblSpecDocumentSubject = new System.Windows.Forms.Label();
			lblSpecDocumentlId = new System.Windows.Forms.Label();
			lblSpecDocumentDate = new System.Windows.Forms.Label();
			frmSpecDocuments.SuspendLayout();
			frmSpecDocumentControl.SuspendLayout();
			SuspendLayout();
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
			((System.ComponentModel.ISupportInitialize) grd_SpecDocument).BeginInit();
			// 
			// frmSpecDocuments
			// 
			frmSpecDocuments.AllowDrop = true;
			frmSpecDocuments.BackColor = System.Drawing.SystemColors.Control;
			frmSpecDocuments.Controls.Add(txtSpecACId);
			frmSpecDocuments.Controls.Add(txtSpecDocumentDescription);
			frmSpecDocuments.Controls.Add(txtSpecDocumentSubject);
			frmSpecDocuments.Controls.Add(frmSpecDocumentControl);
			frmSpecDocuments.Controls.Add(txtSpecDocumentId);
			frmSpecDocuments.Controls.Add(txtSpecDocumentDate);
			frmSpecDocuments.Controls.Add(txtSpecDragDocument);
			frmSpecDocuments.Controls.Add(grd_SpecDocument);
			frmSpecDocuments.Controls.Add(calSpecDocumentDate);
			frmSpecDocuments.Controls.Add(wbSpecBrowser1);
			frmSpecDocuments.Controls.Add(lblSpecACId);
			frmSpecDocuments.Controls.Add(lblSpecContractDescription);
			frmSpecDocuments.Controls.Add(lblSpecDocumentSubject);
			frmSpecDocuments.Controls.Add(lblSpecDocumentlId);
			frmSpecDocuments.Controls.Add(lblSpecDocumentDate);
			frmSpecDocuments.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmSpecDocuments.Enabled = true;
			frmSpecDocuments.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmSpecDocuments.ForeColor = System.Drawing.SystemColors.ControlText;
			frmSpecDocuments.Location = new System.Drawing.Point(4, 3);
			frmSpecDocuments.Name = "frmSpecDocuments";
			frmSpecDocuments.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmSpecDocuments.Size = new System.Drawing.Size(937, 599);
			frmSpecDocuments.TabIndex = 0;
			frmSpecDocuments.Text = "Specification Documents";
			frmSpecDocuments.Visible = true;
			// 
			// txtSpecACId
			// 
			txtSpecACId.AcceptsReturn = true;
			txtSpecACId.AllowDrop = true;
			txtSpecACId.BackColor = System.Drawing.SystemColors.Window;
			txtSpecACId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtSpecACId.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtSpecACId.Enabled = false;
			txtSpecACId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtSpecACId.ForeColor = System.Drawing.SystemColors.WindowText;
			txtSpecACId.Location = new System.Drawing.Point(71, 36);
			txtSpecACId.MaxLength = 120;
			txtSpecACId.Name = "txtSpecACId";
			txtSpecACId.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtSpecACId.Size = new System.Drawing.Size(68, 21);
			txtSpecACId.TabIndex = 17;
			txtSpecACId.Text = "0";
			txtSpecACId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtSpecDocumentDescription
			// 
			txtSpecDocumentDescription.AcceptsReturn = true;
			txtSpecDocumentDescription.AllowDrop = true;
			txtSpecDocumentDescription.BackColor = System.Drawing.SystemColors.Window;
			txtSpecDocumentDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtSpecDocumentDescription.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtSpecDocumentDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtSpecDocumentDescription.ForeColor = System.Drawing.SystemColors.WindowText;
			txtSpecDocumentDescription.Location = new System.Drawing.Point(9, 108);
			txtSpecDocumentDescription.MaxLength = 2000;
			txtSpecDocumentDescription.Multiline = true;
			txtSpecDocumentDescription.Name = "txtSpecDocumentDescription";
			txtSpecDocumentDescription.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtSpecDocumentDescription.Size = new System.Drawing.Size(533, 75);
			txtSpecDocumentDescription.TabIndex = 9;
			// 
			// txtSpecDocumentSubject
			// 
			txtSpecDocumentSubject.AcceptsReturn = true;
			txtSpecDocumentSubject.AllowDrop = true;
			txtSpecDocumentSubject.BackColor = System.Drawing.SystemColors.Window;
			txtSpecDocumentSubject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtSpecDocumentSubject.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtSpecDocumentSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtSpecDocumentSubject.ForeColor = System.Drawing.SystemColors.WindowText;
			txtSpecDocumentSubject.Location = new System.Drawing.Point(70, 60);
			txtSpecDocumentSubject.MaxLength = 120;
			txtSpecDocumentSubject.Name = "txtSpecDocumentSubject";
			txtSpecDocumentSubject.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtSpecDocumentSubject.Size = new System.Drawing.Size(563, 21);
			txtSpecDocumentSubject.TabIndex = 1;
			// 
			// frmSpecDocumentControl
			// 
			frmSpecDocumentControl.AllowDrop = true;
			frmSpecDocumentControl.BackColor = System.Drawing.SystemColors.Control;
			frmSpecDocumentControl.Controls.Add(cmdSpecDocumentDelete);
			frmSpecDocumentControl.Controls.Add(cmdSpecDocumentNew);
			frmSpecDocumentControl.Controls.Add(cmdSpecDocumentSave);
			frmSpecDocumentControl.Controls.Add(cmdSpecDocumentView);
			frmSpecDocumentControl.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmSpecDocumentControl.Enabled = true;
			frmSpecDocumentControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmSpecDocumentControl.ForeColor = System.Drawing.SystemColors.ControlText;
			frmSpecDocumentControl.Location = new System.Drawing.Point(362, 9);
			frmSpecDocumentControl.Name = "frmSpecDocumentControl";
			frmSpecDocumentControl.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmSpecDocumentControl.Size = new System.Drawing.Size(261, 49);
			frmSpecDocumentControl.TabIndex = 5;
			frmSpecDocumentControl.Visible = true;
			// 
			// cmdSpecDocumentDelete
			// 
			cmdSpecDocumentDelete.AllowDrop = true;
			cmdSpecDocumentDelete.BackColor = System.Drawing.SystemColors.Control;
			cmdSpecDocumentDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdSpecDocumentDelete.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdSpecDocumentDelete.Location = new System.Drawing.Point(194, 14);
			cmdSpecDocumentDelete.Name = "cmdSpecDocumentDelete";
			cmdSpecDocumentDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdSpecDocumentDelete.Size = new System.Drawing.Size(55, 25);
			cmdSpecDocumentDelete.TabIndex = 19;
			cmdSpecDocumentDelete.Text = "&Delete";
			cmdSpecDocumentDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdSpecDocumentDelete.UseVisualStyleBackColor = false;
			cmdSpecDocumentDelete.Click += new System.EventHandler(cmdSpecDocumentDelete_Click);
			// 
			// cmdSpecDocumentNew
			// 
			cmdSpecDocumentNew.AllowDrop = true;
			cmdSpecDocumentNew.BackColor = System.Drawing.SystemColors.Control;
			cmdSpecDocumentNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdSpecDocumentNew.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdSpecDocumentNew.Location = new System.Drawing.Point(9, 15);
			cmdSpecDocumentNew.Name = "cmdSpecDocumentNew";
			cmdSpecDocumentNew.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdSpecDocumentNew.Size = new System.Drawing.Size(55, 25);
			cmdSpecDocumentNew.TabIndex = 8;
			cmdSpecDocumentNew.Text = "&New";
			cmdSpecDocumentNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdSpecDocumentNew.UseVisualStyleBackColor = false;
			cmdSpecDocumentNew.Click += new System.EventHandler(cmdSpecDocumentNew_Click);
			// 
			// cmdSpecDocumentSave
			// 
			cmdSpecDocumentSave.AllowDrop = true;
			cmdSpecDocumentSave.BackColor = System.Drawing.SystemColors.Control;
			cmdSpecDocumentSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdSpecDocumentSave.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdSpecDocumentSave.Location = new System.Drawing.Point(71, 15);
			cmdSpecDocumentSave.Name = "cmdSpecDocumentSave";
			cmdSpecDocumentSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdSpecDocumentSave.Size = new System.Drawing.Size(55, 25);
			cmdSpecDocumentSave.TabIndex = 7;
			cmdSpecDocumentSave.Text = "&Save";
			cmdSpecDocumentSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdSpecDocumentSave.UseVisualStyleBackColor = false;
			cmdSpecDocumentSave.Click += new System.EventHandler(cmdSpecDocumentSave_Click);
			// 
			// cmdSpecDocumentView
			// 
			cmdSpecDocumentView.AllowDrop = true;
			cmdSpecDocumentView.BackColor = System.Drawing.SystemColors.Control;
			cmdSpecDocumentView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdSpecDocumentView.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdSpecDocumentView.Location = new System.Drawing.Point(132, 15);
			cmdSpecDocumentView.Name = "cmdSpecDocumentView";
			cmdSpecDocumentView.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdSpecDocumentView.Size = new System.Drawing.Size(55, 25);
			cmdSpecDocumentView.TabIndex = 6;
			cmdSpecDocumentView.Text = "&View";
			cmdSpecDocumentView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdSpecDocumentView.UseVisualStyleBackColor = false;
			cmdSpecDocumentView.Click += new System.EventHandler(cmdSpecDocumentView_Click);
			// 
			// txtSpecDocumentId
			// 
			txtSpecDocumentId.AcceptsReturn = true;
			txtSpecDocumentId.AllowDrop = true;
			txtSpecDocumentId.BackColor = System.Drawing.SystemColors.Window;
			txtSpecDocumentId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtSpecDocumentId.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtSpecDocumentId.Enabled = false;
			txtSpecDocumentId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtSpecDocumentId.ForeColor = System.Drawing.SystemColors.WindowText;
			txtSpecDocumentId.Location = new System.Drawing.Point(236, 36);
			txtSpecDocumentId.MaxLength = 120;
			txtSpecDocumentId.Name = "txtSpecDocumentId";
			txtSpecDocumentId.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtSpecDocumentId.Size = new System.Drawing.Size(68, 21);
			txtSpecDocumentId.TabIndex = 4;
			txtSpecDocumentId.Text = "0";
			txtSpecDocumentId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtSpecDocumentDate
			// 
			txtSpecDocumentDate.AcceptsReturn = true;
			txtSpecDocumentDate.AllowDrop = true;
			txtSpecDocumentDate.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txtSpecDocumentDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtSpecDocumentDate.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtSpecDocumentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtSpecDocumentDate.ForeColor = System.Drawing.SystemColors.WindowText;
			txtSpecDocumentDate.Location = new System.Drawing.Point(649, 51);
			txtSpecDocumentDate.MaxLength = 0;
			txtSpecDocumentDate.Name = "txtSpecDocumentDate";
			txtSpecDocumentDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtSpecDocumentDate.Size = new System.Drawing.Size(82, 19);
			txtSpecDocumentDate.TabIndex = 3;
			txtSpecDocumentDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			txtSpecDocumentDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtSpecDocumentDate_KeyPress);
			// 
			// txtSpecDragDocument
			// 
			txtSpecDragDocument.AcceptsReturn = true;
			txtSpecDragDocument.AllowDrop = true;
			txtSpecDragDocument.BackColor = System.Drawing.SystemColors.Menu;
			txtSpecDragDocument.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtSpecDragDocument.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtSpecDragDocument.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtSpecDragDocument.ForeColor = System.Drawing.SystemColors.WindowText;
			txtSpecDragDocument.Location = new System.Drawing.Point(552, 108);
			txtSpecDragDocument.MaxLength = 2000;
			txtSpecDragDocument.Multiline = true;
			txtSpecDragDocument.Name = "txtSpecDragDocument";
			txtSpecDragDocument.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtSpecDragDocument.Size = new System.Drawing.Size(181, 75);
			txtSpecDragDocument.TabIndex = 2;
			txtSpecDragDocument.TabStop = false;
			txtSpecDragDocument.Text = "Drag Document Here\r\n";
			txtSpecDragDocument.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			txtSpecDragDocument.DoubleClick += new System.EventHandler(txtSpecDragDocument_DoubleClick);
			// 
			// grd_SpecDocument
			// 
			grd_SpecDocument.AllowDrop = true;
			grd_SpecDocument.AllowUserToAddRows = false;
			grd_SpecDocument.AllowUserToDeleteRows = false;
			grd_SpecDocument.AllowUserToResizeColumns = false;
			grd_SpecDocument.AllowUserToResizeRows = false;
			grd_SpecDocument.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_SpecDocument.ColumnsCount = 2;
			grd_SpecDocument.FixedColumns = 1;
			grd_SpecDocument.FixedRows = 1;
			grd_SpecDocument.Location = new System.Drawing.Point(9, 189);
			grd_SpecDocument.Name = "grd_SpecDocument";
			grd_SpecDocument.ReadOnly = true;
			grd_SpecDocument.RowsCount = 2;
			grd_SpecDocument.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			grd_SpecDocument.ShowCellToolTips = false;
			grd_SpecDocument.Size = new System.Drawing.Size(919, 85);
			grd_SpecDocument.StandardTab = true;
			grd_SpecDocument.TabIndex = 10;
			grd_SpecDocument.Click += new System.EventHandler(grd_SpecDocument_Click);
			// 
			// calSpecDocumentDate
			// 
			calSpecDocumentDate.AllowDrop = true;
			calSpecDocumentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			calSpecDocumentDate.ForeColor = System.Drawing.SystemColors.ControlText;
			calSpecDocumentDate.Location = new System.Drawing.Point(744, 30);
			calSpecDocumentDate.Name = "calSpecDocumentDate";
			calSpecDocumentDate.Size = new System.Drawing.Size(178, 154);
			calSpecDocumentDate.TabIndex = 11;
			calSpecDocumentDate.TabStop = false;
			// 
			// wbSpecBrowser1
			// 
			wbSpecBrowser1.AllowWebBrowserDrop = true;
			wbSpecBrowser1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			wbSpecBrowser1.Location = new System.Drawing.Point(9, 280);
			wbSpecBrowser1.Name = "wbSpecBrowser1";
			wbSpecBrowser1.Size = new System.Drawing.Size(917, 309);
			wbSpecBrowser1.TabIndex = 12;
			// 
			// lblSpecACId
			// 
			lblSpecACId.AllowDrop = true;
			lblSpecACId.BackColor = System.Drawing.SystemColors.Control;
			lblSpecACId.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblSpecACId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblSpecACId.ForeColor = System.Drawing.SystemColors.ControlText;
			lblSpecACId.Location = new System.Drawing.Point(15, 39);
			lblSpecACId.MinimumSize = new System.Drawing.Size(52, 16);
			lblSpecACId.Name = "lblSpecACId";
			lblSpecACId.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblSpecACId.Size = new System.Drawing.Size(52, 16);
			lblSpecACId.TabIndex = 18;
			lblSpecACId.Text = "Aircraft Id";
			// 
			// lblSpecContractDescription
			// 
			lblSpecContractDescription.AllowDrop = true;
			lblSpecContractDescription.BackColor = System.Drawing.SystemColors.Control;
			lblSpecContractDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblSpecContractDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblSpecContractDescription.ForeColor = System.Drawing.SystemColors.ControlText;
			lblSpecContractDescription.Location = new System.Drawing.Point(15, 87);
			lblSpecContractDescription.MinimumSize = new System.Drawing.Size(70, 16);
			lblSpecContractDescription.Name = "lblSpecContractDescription";
			lblSpecContractDescription.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblSpecContractDescription.Size = new System.Drawing.Size(70, 16);
			lblSpecContractDescription.TabIndex = 16;
			lblSpecContractDescription.Text = "Description";
			// 
			// lblSpecDocumentSubject
			// 
			lblSpecDocumentSubject.AllowDrop = true;
			lblSpecDocumentSubject.BackColor = System.Drawing.SystemColors.Control;
			lblSpecDocumentSubject.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblSpecDocumentSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblSpecDocumentSubject.ForeColor = System.Drawing.SystemColors.ControlText;
			lblSpecDocumentSubject.Location = new System.Drawing.Point(15, 63);
			lblSpecDocumentSubject.MinimumSize = new System.Drawing.Size(51, 16);
			lblSpecDocumentSubject.Name = "lblSpecDocumentSubject";
			lblSpecDocumentSubject.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblSpecDocumentSubject.Size = new System.Drawing.Size(51, 16);
			lblSpecDocumentSubject.TabIndex = 15;
			lblSpecDocumentSubject.Text = "Subject:";
			// 
			// lblSpecDocumentlId
			// 
			lblSpecDocumentlId.AllowDrop = true;
			lblSpecDocumentlId.BackColor = System.Drawing.SystemColors.Control;
			lblSpecDocumentlId.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblSpecDocumentlId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblSpecDocumentlId.ForeColor = System.Drawing.SystemColors.ControlText;
			lblSpecDocumentlId.Location = new System.Drawing.Point(152, 39);
			lblSpecDocumentlId.MinimumSize = new System.Drawing.Size(70, 16);
			lblSpecDocumentlId.Name = "lblSpecDocumentlId";
			lblSpecDocumentlId.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblSpecDocumentlId.Size = new System.Drawing.Size(70, 16);
			lblSpecDocumentlId.TabIndex = 14;
			lblSpecDocumentlId.Text = "Document Id";
			// 
			// lblSpecDocumentDate
			// 
			lblSpecDocumentDate.AllowDrop = true;
			lblSpecDocumentDate.BackColor = System.Drawing.SystemColors.Control;
			lblSpecDocumentDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblSpecDocumentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblSpecDocumentDate.ForeColor = System.Drawing.SystemColors.ControlText;
			lblSpecDocumentDate.Location = new System.Drawing.Point(649, 30);
			lblSpecDocumentDate.MinimumSize = new System.Drawing.Size(76, 16);
			lblSpecDocumentDate.Name = "lblSpecDocumentDate";
			lblSpecDocumentDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblSpecDocumentDate.Size = new System.Drawing.Size(76, 16);
			lblSpecDocumentDate.TabIndex = 13;
			lblSpecDocumentDate.Text = "Document Date";
			// 
			// frm_AttachSpecDoc
			// 
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			ClientSize = new System.Drawing.Size(946, 603);
			Controls.Add(frmSpecDocuments);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Location = new System.Drawing.Point(695, 158);
			MaximizeBox = true;
			MinimizeBox = true;
			Name = "frm_AttachSpecDoc";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			Text = "Attach Specification Document";
			commandButtonHelper1.SetStyle(cmdSpecDocumentDelete, 0);
			commandButtonHelper1.SetStyle(cmdSpecDocumentNew, 0);
			commandButtonHelper1.SetStyle(cmdSpecDocumentSave, 0);
			commandButtonHelper1.SetStyle(cmdSpecDocumentView, 0);
			ToolTipMain.SetToolTip(txtSpecDocumentSubject, "Enter Subject of Document");
			ToolTipMain.SetToolTip(cmdSpecDocumentDelete, "Click To Delete Document");
			ToolTipMain.SetToolTip(cmdSpecDocumentNew, "Click To Clear Form And Enter New Document");
			ToolTipMain.SetToolTip(cmdSpecDocumentSave, "Click To Save New or Edited Document");
			ToolTipMain.SetToolTip(cmdSpecDocumentView, "Click To View Document In Seperate Window");
			ToolTipMain.SetToolTip(txtSpecDragDocument, "Drag Document Here To Add or Double Click To Open Browse Window");
			Activated += new System.EventHandler(Form_Activated);
			Closed += new System.EventHandler(Form_Closed);
			((System.ComponentModel.ISupportInitialize) grd_SpecDocument).EndInit();
			frmSpecDocuments.ResumeLayout(false);
			frmSpecDocuments.PerformLayout();
			frmSpecDocumentControl.ResumeLayout(false);
			frmSpecDocumentControl.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
		#endregion
	}
}