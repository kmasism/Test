
namespace JETNET_Homebase
{
	partial class frm_CanReg
	{

		#region "Upgrade Support "
		private static frm_CanReg m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_CanReg DefInstance
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
		public static frm_CanReg CreateInstance()
		{
			frm_CanReg theInstance = new frm_CanReg();
			theInstance.Form_Load();
			return theInstance;
		}
		private string[] visualControls = new string[]{"components", "ToolTipMain", "mnuClose", "mnuFile", "mnuAddNewCREG", "mnuedit", "MainMenu1", "cmdBrowse", "frmDragDrop", "txtFileName", "txtDocumentDir", "txtWebsite", "cmdDownload", "cmdUnZip", "StatusList", "Picture1", "txt_EMailAddress", "cmdImport", "cmdCompare", "pbCanReg", "DTSelect", "axInetTran", "_lblTotalImported_5", "_lblTotalImported_4", "_lblTotalImported_3", "_lblTotalImported_2", "_lblTotalImported_1", "_lblTotalImported_0", "lblFileName", "lblDocumentDir", "lblWebsite", "lbl_Status", "Label4", "Label7", "pnl_aircraft", "lblTotalImported", "listBoxHelper1", "commandButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.ToolStripMenuItem mnuClose;
		public System.Windows.Forms.ToolStripMenuItem mnuFile;
		public System.Windows.Forms.ToolStripMenuItem mnuAddNewCREG;
		public System.Windows.Forms.ToolStripMenuItem mnuedit;
		public System.Windows.Forms.MenuStrip MainMenu1;
		public System.Windows.Forms.Button cmdBrowse;
		public System.Windows.Forms.GroupBox frmDragDrop;
		public System.Windows.Forms.TextBox txtFileName;
		public System.Windows.Forms.TextBox txtDocumentDir;
		public System.Windows.Forms.TextBox txtWebsite;
		public System.Windows.Forms.Button cmdDownload;
		public System.Windows.Forms.Button cmdUnZip;
		public System.Windows.Forms.ListBox StatusList;
		public System.Windows.Forms.PictureBox Picture1;
		public System.Windows.Forms.TextBox txt_EMailAddress;
		public System.Windows.Forms.Button cmdImport;
		public System.Windows.Forms.Button cmdCompare;
		public System.Windows.Forms.ProgressBar pbCanReg;
		public System.Windows.Forms.DateTimePicker DTSelect;
		public dynamic axInetTran; // gap-note AxInetCtlsObjects.AxInet must be checked during Blazor stabilization.
		private System.Windows.Forms.Label _lblTotalImported_5;
		private System.Windows.Forms.Label _lblTotalImported_4;
		private System.Windows.Forms.Label _lblTotalImported_3;
		private System.Windows.Forms.Label _lblTotalImported_2;
		private System.Windows.Forms.Label _lblTotalImported_1;
		private System.Windows.Forms.Label _lblTotalImported_0;
		public System.Windows.Forms.Label lblFileName;
		public System.Windows.Forms.Label lblDocumentDir;
		public System.Windows.Forms.Label lblWebsite;
		public System.Windows.Forms.Label lbl_Status;
		public System.Windows.Forms.Label Label4;
		public System.Windows.Forms.Label Label7;
		public System.Windows.Forms.GroupBox pnl_aircraft;
		public System.Windows.Forms.Label[] lblTotalImported = new System.Windows.Forms.Label[6];
		public UpgradeHelpers.Gui.Controls.ListBoxHelper listBoxHelper1;
		public UpgradeHelpers.Gui.Controls.CommandButtonHelper commandButtonHelper1;
        //NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_CanReg));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			MainMenu1 = new System.Windows.Forms.MenuStrip();
			mnuFile = new System.Windows.Forms.ToolStripMenuItem();
			mnuClose = new System.Windows.Forms.ToolStripMenuItem();
			mnuedit = new System.Windows.Forms.ToolStripMenuItem();
			mnuAddNewCREG = new System.Windows.Forms.ToolStripMenuItem();
			pnl_aircraft = new System.Windows.Forms.GroupBox();
			cmdBrowse = new System.Windows.Forms.Button();
			frmDragDrop = new System.Windows.Forms.GroupBox();
			txtFileName = new System.Windows.Forms.TextBox();
			txtDocumentDir = new System.Windows.Forms.TextBox();
			txtWebsite = new System.Windows.Forms.TextBox();
			cmdDownload = new System.Windows.Forms.Button();
			cmdUnZip = new System.Windows.Forms.Button();
			StatusList = new System.Windows.Forms.ListBox();
			Picture1 = new System.Windows.Forms.PictureBox();
			txt_EMailAddress = new System.Windows.Forms.TextBox();
			cmdImport = new System.Windows.Forms.Button();
			cmdCompare = new System.Windows.Forms.Button();
			pbCanReg = new System.Windows.Forms.ProgressBar();
			DTSelect = new System.Windows.Forms.DateTimePicker();
			axInetTran = null;//new AxInetCtlsObjects.AxInet();// gap-note AxInetCtlsObjects.AxInet must be checked during Blazor stabilization.
			_lblTotalImported_5 = new System.Windows.Forms.Label();
			_lblTotalImported_4 = new System.Windows.Forms.Label();
			_lblTotalImported_3 = new System.Windows.Forms.Label();
			_lblTotalImported_2 = new System.Windows.Forms.Label();
			_lblTotalImported_1 = new System.Windows.Forms.Label();
			_lblTotalImported_0 = new System.Windows.Forms.Label();
			lblFileName = new System.Windows.Forms.Label();
			lblDocumentDir = new System.Windows.Forms.Label();
			lblWebsite = new System.Windows.Forms.Label();
			lbl_Status = new System.Windows.Forms.Label();
			Label4 = new System.Windows.Forms.Label();
			Label7 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize) axInetTran).BeginInit();
			pnl_aircraft.SuspendLayout();
			SuspendLayout();
			listBoxHelper1 = new UpgradeHelpers.Gui.Controls.ListBoxHelper(components);
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
			// 
			// MainMenu1
			// 
			MainMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[]{mnuFile, mnuedit});
			// 
			// mnuFile
			// 
			mnuFile.Available = true;
			mnuFile.Checked = false;
			mnuFile.Enabled = true;
			mnuFile.Name = "mnuFile";
			mnuFile.Text = "&File";
			mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]{mnuClose});
			// 
			// mnuClose
			// 
			mnuClose.Available = true;
			mnuClose.Checked = false;
			mnuClose.Enabled = true;
			mnuClose.Name = "mnuClose";
			mnuClose.Text = "&Close";
			// 
			// mnuedit
			// 
			mnuedit.Available = true;
			mnuedit.Checked = false;
			mnuedit.Enabled = true;
			mnuedit.Name = "mnuedit";
			mnuedit.Text = "&Edit";
			mnuedit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]{mnuAddNewCREG});
			// 
			// mnuAddNewCREG
			// 
			mnuAddNewCREG.Available = true;
			mnuAddNewCREG.Checked = false;
			mnuAddNewCREG.Enabled = true;
			mnuAddNewCREG.Name = "mnuAddNewCREG";
			mnuAddNewCREG.Text = "&Add New Registry Entry";
			// 
			// pnl_aircraft
			// 
			pnl_aircraft.AllowDrop = true;
			pnl_aircraft.BackColor = System.Drawing.SystemColors.Control;
			pnl_aircraft.Controls.Add(cmdBrowse);
			pnl_aircraft.Controls.Add(frmDragDrop);
			pnl_aircraft.Controls.Add(txtFileName);
			pnl_aircraft.Controls.Add(txtDocumentDir);
			pnl_aircraft.Controls.Add(txtWebsite);
			pnl_aircraft.Controls.Add(cmdDownload);
			pnl_aircraft.Controls.Add(cmdUnZip);
			pnl_aircraft.Controls.Add(StatusList);
			pnl_aircraft.Controls.Add(Picture1);
			pnl_aircraft.Controls.Add(txt_EMailAddress);
			pnl_aircraft.Controls.Add(cmdImport);
			pnl_aircraft.Controls.Add(cmdCompare);
			pnl_aircraft.Controls.Add(pbCanReg);
			pnl_aircraft.Controls.Add(DTSelect);
			pnl_aircraft.Controls.Add(axInetTran);
			pnl_aircraft.Controls.Add(_lblTotalImported_5);
			pnl_aircraft.Controls.Add(_lblTotalImported_4);
			pnl_aircraft.Controls.Add(_lblTotalImported_3);
			pnl_aircraft.Controls.Add(_lblTotalImported_2);
			pnl_aircraft.Controls.Add(_lblTotalImported_1);
			pnl_aircraft.Controls.Add(_lblTotalImported_0);
			pnl_aircraft.Controls.Add(lblFileName);
			pnl_aircraft.Controls.Add(lblDocumentDir);
			pnl_aircraft.Controls.Add(lblWebsite);
			pnl_aircraft.Controls.Add(lbl_Status);
			pnl_aircraft.Controls.Add(Label4);
			pnl_aircraft.Controls.Add(Label7);
			pnl_aircraft.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			pnl_aircraft.Enabled = true;
			pnl_aircraft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_aircraft.ForeColor = System.Drawing.SystemColors.ControlText;
			pnl_aircraft.Location = new System.Drawing.Point(10, 38);
			pnl_aircraft.Name = "pnl_aircraft";
			pnl_aircraft.RightToLeft = System.Windows.Forms.RightToLeft.No;
			pnl_aircraft.Size = new System.Drawing.Size(811, 327);
			pnl_aircraft.TabIndex = 0;
			pnl_aircraft.Visible = true;
			// 
			// cmdBrowse
			// 
			cmdBrowse.AllowDrop = true;
			cmdBrowse.BackColor = System.Drawing.SystemColors.Control;
			cmdBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdBrowse.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdBrowse.Location = new System.Drawing.Point(320, 18);
			cmdBrowse.Name = "cmdBrowse";
			cmdBrowse.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdBrowse.Size = new System.Drawing.Size(79, 21);
			cmdBrowse.TabIndex = 26;
			cmdBrowse.Text = "&Browse File";
			cmdBrowse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdBrowse.UseVisualStyleBackColor = false;
			cmdBrowse.Click += new System.EventHandler(cmdBrowse_Click);
			// 
			// frmDragDrop
			// 
			frmDragDrop.AllowDrop = true;
			frmDragDrop.BackColor = System.Drawing.SystemColors.Control;
			frmDragDrop.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmDragDrop.Enabled = true;
			frmDragDrop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmDragDrop.ForeColor = System.Drawing.SystemColors.ControlText;
			frmDragDrop.Location = new System.Drawing.Point(420, 8);
			frmDragDrop.Name = "frmDragDrop";
			frmDragDrop.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmDragDrop.Size = new System.Drawing.Size(127, 57);
			frmDragDrop.TabIndex = 25;
			frmDragDrop.Text = "Drop File Here";
			frmDragDrop.Visible = true;
			frmDragDrop.DoubleClick += new System.EventHandler(frmDragDrop_DoubleClick);
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
			txtFileName.Location = new System.Drawing.Point(408, 96);
			txtFileName.MaxLength = 0;
			txtFileName.Name = "txtFileName";
			txtFileName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtFileName.Size = new System.Drawing.Size(137, 23);
			txtFileName.TabIndex = 17;
			txtFileName.Text = "ccyymmdd_hhmmss.zip";
			// 
			// txtDocumentDir
			// 
			txtDocumentDir.AcceptsReturn = true;
			txtDocumentDir.AllowDrop = true;
			txtDocumentDir.BackColor = System.Drawing.SystemColors.Window;
			txtDocumentDir.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtDocumentDir.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtDocumentDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtDocumentDir.ForeColor = System.Drawing.SystemColors.WindowText;
			txtDocumentDir.Location = new System.Drawing.Point(125, 96);
			txtDocumentDir.MaxLength = 0;
			txtDocumentDir.Name = "txtDocumentDir";
			txtDocumentDir.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtDocumentDir.Size = new System.Drawing.Size(211, 23);
			txtDocumentDir.TabIndex = 15;
			txtDocumentDir.Text = "\\\\JETNET4\\CANREG\\MASTERS\\";
			// 
			// txtWebsite
			// 
			txtWebsite.AcceptsReturn = true;
			txtWebsite.AllowDrop = true;
			txtWebsite.BackColor = System.Drawing.SystemColors.Window;
			txtWebsite.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtWebsite.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtWebsite.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtWebsite.ForeColor = System.Drawing.SystemColors.WindowText;
			txtWebsite.Location = new System.Drawing.Point(125, 70);
			txtWebsite.MaxLength = 0;
			txtWebsite.Name = "txtWebsite";
			txtWebsite.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtWebsite.Size = new System.Drawing.Size(421, 23);
			txtWebsite.TabIndex = 13;
			txtWebsite.Text = "http://wwwapps.tc.gc.ca/Saf-Sec-Sur/2/CCARCS-RIACC/DDZip.aspx";
			// 
			// cmdDownload
			// 
			cmdDownload.AllowDrop = true;
			cmdDownload.BackColor = System.Drawing.SystemColors.Control;
			cmdDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdDownload.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdDownload.Location = new System.Drawing.Point(36, 120);
			cmdDownload.Name = "cmdDownload";
			cmdDownload.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdDownload.Size = new System.Drawing.Size(71, 22);
			cmdDownload.TabIndex = 9;
			cmdDownload.Text = "Download";
			cmdDownload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdDownload.UseVisualStyleBackColor = false;
			cmdDownload.Click += new System.EventHandler(cmdDownload_Click);
			// 
			// cmdUnZip
			// 
			cmdUnZip.AllowDrop = true;
			cmdUnZip.BackColor = System.Drawing.SystemColors.Control;
			cmdUnZip.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdUnZip.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdUnZip.Location = new System.Drawing.Point(36, 146);
			cmdUnZip.Name = "cmdUnZip";
			cmdUnZip.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdUnZip.Size = new System.Drawing.Size(71, 22);
			cmdUnZip.TabIndex = 8;
			cmdUnZip.Text = "Unzip";
			cmdUnZip.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdUnZip.UseVisualStyleBackColor = false;
			cmdUnZip.Click += new System.EventHandler(cmdUnZip_Click);
			// 
			// StatusList
			// 
			StatusList.AllowDrop = true;
			StatusList.BackColor = System.Drawing.SystemColors.Window;
			StatusList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			StatusList.CausesValidation = true;
			StatusList.Enabled = true;
			StatusList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			StatusList.ForeColor = System.Drawing.SystemColors.WindowText;
			StatusList.IntegralHeight = true;
			StatusList.Location = new System.Drawing.Point(126, 128);
			StatusList.MultiColumn = false;
			StatusList.Name = "StatusList";
			StatusList.RightToLeft = System.Windows.Forms.RightToLeft.No;
			StatusList.Size = new System.Drawing.Size(419, 122);
			StatusList.Sorted = false;
			StatusList.TabIndex = 7;
			StatusList.TabStop = true;
			StatusList.Visible = true;
			// 
			// Picture1
			// 
			Picture1.AllowDrop = true;
			Picture1.BackColor = System.Drawing.SystemColors.Window;
			Picture1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Picture1.CausesValidation = true;
			Picture1.Dock = System.Windows.Forms.DockStyle.None;
			Picture1.Enabled = true;
			Picture1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Picture1.Image = (System.Drawing.Image) resources.GetObject("Picture1.Image");
			Picture1.Location = new System.Drawing.Point(564, 44);
			Picture1.Name = "Picture1";
			Picture1.Size = new System.Drawing.Size(226, 147);
			Picture1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			Picture1.TabIndex = 6;
			Picture1.TabStop = true;
			Picture1.Visible = true;
			// 
			// txt_EMailAddress
			// 
			txt_EMailAddress.AcceptsReturn = true;
			txt_EMailAddress.AllowDrop = true;
			txt_EMailAddress.BackColor = System.Drawing.SystemColors.Window;
			txt_EMailAddress.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_EMailAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_EMailAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_EMailAddress.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_EMailAddress.Location = new System.Drawing.Point(125, 44);
			txt_EMailAddress.MaxLength = 0;
			txt_EMailAddress.Name = "txt_EMailAddress";
			txt_EMailAddress.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_EMailAddress.Size = new System.Drawing.Size(281, 23);
			txt_EMailAddress.TabIndex = 5;
			txt_EMailAddress.Text = "jackie@jetnet.com";
			// 
			// cmdImport
			// 
			cmdImport.AllowDrop = true;
			cmdImport.BackColor = System.Drawing.SystemColors.Control;
			cmdImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdImport.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdImport.Location = new System.Drawing.Point(34, 172);
			cmdImport.Name = "cmdImport";
			cmdImport.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdImport.Size = new System.Drawing.Size(71, 22);
			cmdImport.TabIndex = 3;
			cmdImport.Text = "Import";
			cmdImport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdImport.UseVisualStyleBackColor = false;
			cmdImport.Click += new System.EventHandler(cmdImport_Click);
			// 
			// cmdCompare
			// 
			cmdCompare.AllowDrop = true;
			cmdCompare.BackColor = System.Drawing.SystemColors.Control;
			cmdCompare.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdCompare.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdCompare.Location = new System.Drawing.Point(34, 198);
			cmdCompare.Name = "cmdCompare";
			cmdCompare.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdCompare.Size = new System.Drawing.Size(71, 22);
			cmdCompare.TabIndex = 2;
			cmdCompare.Text = "Compare";
			cmdCompare.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdCompare.UseVisualStyleBackColor = false;
			cmdCompare.Click += new System.EventHandler(cmdCompare_Click);
			// 
			// pbCanReg
			// 
			pbCanReg.AllowDrop = true;
			pbCanReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pbCanReg.Location = new System.Drawing.Point(128, 260);
			pbCanReg.Name = "pbCanReg";
			pbCanReg.Size = new System.Drawing.Size(415, 21);
			pbCanReg.TabIndex = 1;
			pbCanReg.Visible = false;
			// 
			// DTSelect
			// 
			DTSelect.AllowDrop = true;
			DTSelect.Checked = false;
			DTSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			DTSelect.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			DTSelect.Location = new System.Drawing.Point(192, 14);
			DTSelect.Name = "DTSelect";
			DTSelect.Size = new System.Drawing.Size(106, 21);
			DTSelect.TabIndex = 4;
			// 
			// axInetTran
			// 
			axInetTran.AllowDrop = true;
			axInetTran.Location = new System.Drawing.Point(28, 226);
			axInetTran.Name = "axInetTran";
			axInetTran.OcxState = (System.Windows.Forms.AxHost.State) resources.GetObject("axInetTran.OcxState");
			// 
			// _lblTotalImported_5
			// 
			_lblTotalImported_5.AllowDrop = true;
			_lblTotalImported_5.BackColor = System.Drawing.SystemColors.Control;
			_lblTotalImported_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblTotalImported_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblTotalImported_5.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblTotalImported_5.Location = new System.Drawing.Point(706, 262);
			_lblTotalImported_5.MinimumSize = new System.Drawing.Size(73, 20);
			_lblTotalImported_5.Name = "_lblTotalImported_5";
			_lblTotalImported_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblTotalImported_5.Size = new System.Drawing.Size(73, 20);
			_lblTotalImported_5.TabIndex = 24;
			_lblTotalImported_5.Text = "ccyymmdd";
			_lblTotalImported_5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// _lblTotalImported_4
			// 
			_lblTotalImported_4.AllowDrop = true;
			_lblTotalImported_4.BackColor = System.Drawing.SystemColors.Control;
			_lblTotalImported_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblTotalImported_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblTotalImported_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblTotalImported_4.Location = new System.Drawing.Point(566, 262);
			_lblTotalImported_4.MinimumSize = new System.Drawing.Size(111, 20);
			_lblTotalImported_4.Name = "_lblTotalImported_4";
			_lblTotalImported_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblTotalImported_4.Size = new System.Drawing.Size(111, 20);
			_lblTotalImported_4.TabIndex = 23;
			_lblTotalImported_4.Text = "Highest Registry Date";
			// 
			// _lblTotalImported_3
			// 
			_lblTotalImported_3.AllowDrop = true;
			_lblTotalImported_3.BackColor = System.Drawing.SystemColors.Control;
			_lblTotalImported_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblTotalImported_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblTotalImported_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblTotalImported_3.Location = new System.Drawing.Point(720, 234);
			_lblTotalImported_3.MinimumSize = new System.Drawing.Size(59, 20);
			_lblTotalImported_3.Name = "_lblTotalImported_3";
			_lblTotalImported_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblTotalImported_3.Size = new System.Drawing.Size(59, 20);
			_lblTotalImported_3.TabIndex = 22;
			_lblTotalImported_3.Text = "#,##0";
			_lblTotalImported_3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// _lblTotalImported_2
			// 
			_lblTotalImported_2.AllowDrop = true;
			_lblTotalImported_2.BackColor = System.Drawing.SystemColors.Control;
			_lblTotalImported_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblTotalImported_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblTotalImported_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblTotalImported_2.Location = new System.Drawing.Point(566, 234);
			_lblTotalImported_2.MinimumSize = new System.Drawing.Size(117, 20);
			_lblTotalImported_2.Name = "_lblTotalImported_2";
			_lblTotalImported_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblTotalImported_2.Size = new System.Drawing.Size(117, 20);
			_lblTotalImported_2.TabIndex = 21;
			_lblTotalImported_2.Text = "Total Owner  Imported";
			// 
			// _lblTotalImported_1
			// 
			_lblTotalImported_1.AllowDrop = true;
			_lblTotalImported_1.BackColor = System.Drawing.SystemColors.Control;
			_lblTotalImported_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblTotalImported_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblTotalImported_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblTotalImported_1.Location = new System.Drawing.Point(720, 204);
			_lblTotalImported_1.MinimumSize = new System.Drawing.Size(59, 20);
			_lblTotalImported_1.Name = "_lblTotalImported_1";
			_lblTotalImported_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblTotalImported_1.Size = new System.Drawing.Size(59, 20);
			_lblTotalImported_1.TabIndex = 20;
			_lblTotalImported_1.Text = "#,##0";
			_lblTotalImported_1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// _lblTotalImported_0
			// 
			_lblTotalImported_0.AllowDrop = true;
			_lblTotalImported_0.BackColor = System.Drawing.SystemColors.Control;
			_lblTotalImported_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblTotalImported_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblTotalImported_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblTotalImported_0.Location = new System.Drawing.Point(566, 206);
			_lblTotalImported_0.MinimumSize = new System.Drawing.Size(141, 20);
			_lblTotalImported_0.Name = "_lblTotalImported_0";
			_lblTotalImported_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblTotalImported_0.Size = new System.Drawing.Size(141, 20);
			_lblTotalImported_0.TabIndex = 19;
			_lblTotalImported_0.Text = "Total A/C Registry Imported";
			// 
			// lblFileName
			// 
			lblFileName.AllowDrop = true;
			lblFileName.BackColor = System.Drawing.SystemColors.Control;
			lblFileName.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblFileName.ForeColor = System.Drawing.Color.Blue;
			lblFileName.Location = new System.Drawing.Point(350, 98);
			lblFileName.MinimumSize = new System.Drawing.Size(50, 20);
			lblFileName.Name = "lblFileName";
			lblFileName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblFileName.Size = new System.Drawing.Size(50, 20);
			lblFileName.TabIndex = 18;
			lblFileName.Text = "File Name";
			lblFileName.Click += new System.EventHandler(lblFileName_Click);
			// 
			// lblDocumentDir
			// 
			lblDocumentDir.AllowDrop = true;
			lblDocumentDir.BackColor = System.Drawing.SystemColors.Control;
			lblDocumentDir.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblDocumentDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblDocumentDir.ForeColor = System.Drawing.Color.Blue;
			lblDocumentDir.Location = new System.Drawing.Point(46, 98);
			lblDocumentDir.MinimumSize = new System.Drawing.Size(66, 20);
			lblDocumentDir.Name = "lblDocumentDir";
			lblDocumentDir.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblDocumentDir.Size = new System.Drawing.Size(66, 20);
			lblDocumentDir.TabIndex = 16;
			lblDocumentDir.Text = "Document Dir";
			lblDocumentDir.Click += new System.EventHandler(lblDocumentDir_Click);
			// 
			// lblWebsite
			// 
			lblWebsite.AllowDrop = true;
			lblWebsite.BackColor = System.Drawing.SystemColors.Control;
			lblWebsite.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblWebsite.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblWebsite.ForeColor = System.Drawing.Color.Blue;
			lblWebsite.Location = new System.Drawing.Point(46, 72);
			lblWebsite.MinimumSize = new System.Drawing.Size(60, 20);
			lblWebsite.Name = "lblWebsite";
			lblWebsite.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblWebsite.Size = new System.Drawing.Size(60, 20);
			lblWebsite.TabIndex = 14;
			lblWebsite.Text = "Website";
			lblWebsite.Click += new System.EventHandler(lblWebsite_Click);
			// 
			// lbl_Status
			// 
			lbl_Status.AllowDrop = true;
			lbl_Status.BackColor = System.Drawing.SystemColors.Control;
			lbl_Status.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 18f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_Status.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_Status.Location = new System.Drawing.Point(126, 288);
			lbl_Status.MinimumSize = new System.Drawing.Size(674, 35);
			lbl_Status.Name = "lbl_Status";
			lbl_Status.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_Status.Size = new System.Drawing.Size(674, 35);
			lbl_Status.TabIndex = 12;
			lbl_Status.Text = "Status";
			// 
			// Label4
			// 
			Label4.AllowDrop = true;
			Label4.BackColor = System.Drawing.SystemColors.Control;
			Label4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label4.ForeColor = System.Drawing.SystemColors.ControlText;
			Label4.Location = new System.Drawing.Point(46, 46);
			Label4.MinimumSize = new System.Drawing.Size(60, 20);
			Label4.Name = "Label4";
			Label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label4.Size = new System.Drawing.Size(60, 20);
			Label4.TabIndex = 11;
			Label4.Text = "EMail To";
			// 
			// Label7
			// 
			Label7.AllowDrop = true;
			Label7.BackColor = System.Drawing.SystemColors.Control;
			Label7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label7.ForeColor = System.Drawing.SystemColors.ControlText;
			Label7.Location = new System.Drawing.Point(48, 16);
			Label7.MinimumSize = new System.Drawing.Size(135, 22);
			Label7.Name = "Label7";
			Label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label7.Size = new System.Drawing.Size(135, 22);
			Label7.TabIndex = 10;
			Label7.Text = "Select Aircraft Modified on:";
			// 
			// frm_CanReg
			// 
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			ClientSize = new System.Drawing.Size(831, 375);
			Controls.Add(pnl_aircraft);
			Controls.Add(MainMenu1);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Location = new System.Drawing.Point(379, 222);
			MaximizeBox = true;
			MinimizeBox = true;
			Name = "frm_CanReg";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			Text = "Canadian Registry";
			commandButtonHelper1.SetStyle(cmdBrowse, 0);
			commandButtonHelper1.SetStyle(cmdDownload, 0);
			commandButtonHelper1.SetStyle(cmdUnZip, 0);
			commandButtonHelper1.SetStyle(cmdImport, 0);
			commandButtonHelper1.SetStyle(cmdCompare, 0);
			listBoxHelper1.SetSelectionMode(StatusList, System.Windows.Forms.SelectionMode.One);
			ToolTipMain.SetToolTip(cmdBrowse, "Click To Browse For Download Zip File");
			ToolTipMain.SetToolTip(frmDragDrop, "Drag File Here To Add or Double Click To Open Browse Window");
			ToolTipMain.SetToolTip(lblFileName, "Click To Find Latest Registry File");
			ToolTipMain.SetToolTip(lblDocumentDir, "Click To Open Document Directory");
			ToolTipMain.SetToolTip(lblWebsite, "Click To View Website");
			Activated += new System.EventHandler(frm_CanReg_Activated);
			Closed += new System.EventHandler(Form_Closed);
			FormClosing += new System.Windows.Forms.FormClosingEventHandler(Form_FormClosing);
			((System.ComponentModel.ISupportInitialize) axInetTran).EndInit();
			pnl_aircraft.ResumeLayout(false);
			pnl_aircraft.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
		void ReLoadForm(bool addEvents) => InitializelblTotalImported();

		void InitializelblTotalImported()
		{
			lblTotalImported = new System.Windows.Forms.Label[6];
			lblTotalImported[5] = _lblTotalImported_5;
			lblTotalImported[4] = _lblTotalImported_4;
			lblTotalImported[3] = _lblTotalImported_3;
			lblTotalImported[2] = _lblTotalImported_2;
			lblTotalImported[1] = _lblTotalImported_1;
			lblTotalImported[0] = _lblTotalImported_0;
		}
		#endregion
	}
}