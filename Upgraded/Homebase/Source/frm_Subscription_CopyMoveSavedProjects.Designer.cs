
namespace JETNET_Homebase
{
	partial class frm_Subscription_CopyMoveSavedProjects
	{

		#region "Upgrade Support "
		private static frm_Subscription_CopyMoveSavedProjects m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_Subscription_CopyMoveSavedProjects DefInstance
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
		public static frm_Subscription_CopyMoveSavedProjects CreateInstance()
		{
			frm_Subscription_CopyMoveSavedProjects theInstance = new frm_Subscription_CopyMoveSavedProjects();
			return theInstance;
		}
		private string[] visualControls = new string[]{"components", "ToolTipMain", "txtCFId", "txtSISEId", "optSavedExports", "txtSISSCId", "optFolders", "optProjects", "lblCFId", "lblSISEId", "lblSISSCId", "frmType", "optCopy", "optMove", "lblMoveTo", "frmCenter", "txtSeqNbrNew", "txtLoginNew", "txtSubIdNew", "lblSeqNbrNew", "lblLoginNew", "lblSubIdNew", "frmTo", "txtCompId", "lblCompId", "lblCompany", "frmCompany", "lstbCopyMove", "cmdClose", "cmdCopyMove", "txtSeqNbrOld", "txtLoginOld", "txtSubIdOld", "lblSeqNbrOld", "lblLoginOld", "lblSubIdOld", "frmFrom", "lblStatus", "commandButtonHelper1", "listBoxHelper1", "optionButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.TextBox txtCFId;
		public System.Windows.Forms.TextBox txtSISEId;
		public System.Windows.Forms.RadioButton optSavedExports;
		public System.Windows.Forms.TextBox txtSISSCId;
		public System.Windows.Forms.RadioButton optFolders;
		public System.Windows.Forms.RadioButton optProjects;
		public System.Windows.Forms.Label lblCFId;
		public System.Windows.Forms.Label lblSISEId;
		public System.Windows.Forms.Label lblSISSCId;
		public System.Windows.Forms.GroupBox frmType;
		public System.Windows.Forms.RadioButton optCopy;
		public System.Windows.Forms.RadioButton optMove;
		public System.Windows.Forms.Label lblMoveTo;
		public System.Windows.Forms.GroupBox frmCenter;
		public System.Windows.Forms.TextBox txtSeqNbrNew;
		public System.Windows.Forms.TextBox txtLoginNew;
		public System.Windows.Forms.TextBox txtSubIdNew;
		public System.Windows.Forms.Label lblSeqNbrNew;
		public System.Windows.Forms.Label lblLoginNew;
		public System.Windows.Forms.Label lblSubIdNew;
		public System.Windows.Forms.GroupBox frmTo;
		public System.Windows.Forms.TextBox txtCompId;
		public System.Windows.Forms.Label lblCompId;
		public System.Windows.Forms.Label lblCompany;
		public System.Windows.Forms.GroupBox frmCompany;
		public System.Windows.Forms.ListBox lstbCopyMove;
		public System.Windows.Forms.Button cmdClose;
		public System.Windows.Forms.Button cmdCopyMove;
		public System.Windows.Forms.TextBox txtSeqNbrOld;
		public System.Windows.Forms.TextBox txtLoginOld;
		public System.Windows.Forms.TextBox txtSubIdOld;
		public System.Windows.Forms.Label lblSeqNbrOld;
		public System.Windows.Forms.Label lblLoginOld;
		public System.Windows.Forms.Label lblSubIdOld;
		public System.Windows.Forms.GroupBox frmFrom;
		public System.Windows.Forms.Label lblStatus;
		public UpgradeHelpers.Gui.Controls.CommandButtonHelper commandButtonHelper1;
		public UpgradeHelpers.Gui.Controls.ListBoxHelper listBoxHelper1;
		public UpgradeHelpers.Gui.Controls.OptionButtonHelper optionButtonHelper1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Subscription_CopyMoveSavedProjects));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			frmType = new System.Windows.Forms.GroupBox();
			txtCFId = new System.Windows.Forms.TextBox();
			txtSISEId = new System.Windows.Forms.TextBox();
			optSavedExports = new System.Windows.Forms.RadioButton();
			txtSISSCId = new System.Windows.Forms.TextBox();
			optFolders = new System.Windows.Forms.RadioButton();
			optProjects = new System.Windows.Forms.RadioButton();
			lblCFId = new System.Windows.Forms.Label();
			lblSISEId = new System.Windows.Forms.Label();
			lblSISSCId = new System.Windows.Forms.Label();
			frmCenter = new System.Windows.Forms.GroupBox();
			optCopy = new System.Windows.Forms.RadioButton();
			optMove = new System.Windows.Forms.RadioButton();
			lblMoveTo = new System.Windows.Forms.Label();
			frmTo = new System.Windows.Forms.GroupBox();
			txtSeqNbrNew = new System.Windows.Forms.TextBox();
			txtLoginNew = new System.Windows.Forms.TextBox();
			txtSubIdNew = new System.Windows.Forms.TextBox();
			lblSeqNbrNew = new System.Windows.Forms.Label();
			lblLoginNew = new System.Windows.Forms.Label();
			lblSubIdNew = new System.Windows.Forms.Label();
			frmCompany = new System.Windows.Forms.GroupBox();
			txtCompId = new System.Windows.Forms.TextBox();
			lblCompId = new System.Windows.Forms.Label();
			lblCompany = new System.Windows.Forms.Label();
			lstbCopyMove = new System.Windows.Forms.ListBox();
			cmdClose = new System.Windows.Forms.Button();
			cmdCopyMove = new System.Windows.Forms.Button();
			frmFrom = new System.Windows.Forms.GroupBox();
			txtSeqNbrOld = new System.Windows.Forms.TextBox();
			txtLoginOld = new System.Windows.Forms.TextBox();
			txtSubIdOld = new System.Windows.Forms.TextBox();
			lblSeqNbrOld = new System.Windows.Forms.Label();
			lblLoginOld = new System.Windows.Forms.Label();
			lblSubIdOld = new System.Windows.Forms.Label();
			lblStatus = new System.Windows.Forms.Label();
			frmType.SuspendLayout();
			frmCenter.SuspendLayout();
			frmTo.SuspendLayout();
			frmCompany.SuspendLayout();
			frmFrom.SuspendLayout();
			SuspendLayout();
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
			listBoxHelper1 = new UpgradeHelpers.Gui.Controls.ListBoxHelper(components);
			optionButtonHelper1 = new UpgradeHelpers.Gui.Controls.OptionButtonHelper(components);
			// 
			// frmType
			// 
			frmType.AllowDrop = true;
			frmType.BackColor = System.Drawing.SystemColors.Control;
			frmType.Controls.Add(txtCFId);
			frmType.Controls.Add(txtSISEId);
			frmType.Controls.Add(optSavedExports);
			frmType.Controls.Add(txtSISSCId);
			frmType.Controls.Add(optFolders);
			frmType.Controls.Add(optProjects);
			frmType.Controls.Add(lblCFId);
			frmType.Controls.Add(lblSISEId);
			frmType.Controls.Add(lblSISSCId);
			frmType.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmType.Enabled = true;
			frmType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmType.ForeColor = System.Drawing.SystemColors.ControlText;
			frmType.Location = new System.Drawing.Point(84, 172);
			frmType.Name = "frmType";
			frmType.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmType.Size = new System.Drawing.Size(291, 91);
			frmType.TabIndex = 32;
			frmType.Text = "Type";
			frmType.Visible = true;
			// 
			// txtCFId
			// 
			txtCFId.AcceptsReturn = true;
			txtCFId.AllowDrop = true;
			txtCFId.BackColor = System.Drawing.SystemColors.Window;
			txtCFId.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtCFId.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtCFId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtCFId.ForeColor = System.Drawing.SystemColors.WindowText;
			txtCFId.Location = new System.Drawing.Point(196, 34);
			txtCFId.MaxLength = 0;
			txtCFId.Name = "txtCFId";
			txtCFId.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtCFId.Size = new System.Drawing.Size(55, 22);
			txtCFId.TabIndex = 11;
			txtCFId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtSISEId
			// 
			txtSISEId.AcceptsReturn = true;
			txtSISEId.AllowDrop = true;
			txtSISEId.BackColor = System.Drawing.SystemColors.Window;
			txtSISEId.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtSISEId.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtSISEId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtSISEId.ForeColor = System.Drawing.SystemColors.WindowText;
			txtSISEId.Location = new System.Drawing.Point(196, 58);
			txtSISEId.MaxLength = 0;
			txtSISEId.Name = "txtSISEId";
			txtSISEId.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtSISEId.Size = new System.Drawing.Size(55, 22);
			txtSISEId.TabIndex = 12;
			txtSISEId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// optSavedExports
			// 
			optSavedExports.AllowDrop = true;
			optSavedExports.BackColor = System.Drawing.SystemColors.Control;
			optSavedExports.CausesValidation = true;
			optSavedExports.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			optSavedExports.Checked = false;
			optSavedExports.Enabled = true;
			optSavedExports.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			optSavedExports.ForeColor = System.Drawing.SystemColors.ControlText;
			optSavedExports.Location = new System.Drawing.Point(10, 60);
			optSavedExports.Name = "optSavedExports";
			optSavedExports.RightToLeft = System.Windows.Forms.RightToLeft.No;
			optSavedExports.Size = new System.Drawing.Size(94, 19);
			optSavedExports.TabIndex = 9;
			optSavedExports.TabStop = true;
			optSavedExports.Text = "Saved Exports";
			optSavedExports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			optSavedExports.Visible = true;
			optSavedExports.CheckedChanged += new System.EventHandler(optSavedExports_CheckedChanged);
			// 
			// txtSISSCId
			// 
			txtSISSCId.AcceptsReturn = true;
			txtSISSCId.AllowDrop = true;
			txtSISSCId.BackColor = System.Drawing.SystemColors.Window;
			txtSISSCId.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtSISSCId.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtSISSCId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtSISSCId.ForeColor = System.Drawing.SystemColors.WindowText;
			txtSISSCId.Location = new System.Drawing.Point(196, 11);
			txtSISSCId.MaxLength = 0;
			txtSISSCId.Name = "txtSISSCId";
			txtSISSCId.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtSISSCId.Size = new System.Drawing.Size(55, 22);
			txtSISSCId.TabIndex = 10;
			txtSISSCId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// optFolders
			// 
			optFolders.AllowDrop = true;
			optFolders.BackColor = System.Drawing.SystemColors.Control;
			optFolders.CausesValidation = true;
			optFolders.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			optFolders.Checked = false;
			optFolders.Enabled = true;
			optFolders.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			optFolders.ForeColor = System.Drawing.SystemColors.ControlText;
			optFolders.Location = new System.Drawing.Point(11, 36);
			optFolders.Name = "optFolders";
			optFolders.RightToLeft = System.Windows.Forms.RightToLeft.No;
			optFolders.Size = new System.Drawing.Size(94, 19);
			optFolders.TabIndex = 8;
			optFolders.TabStop = true;
			optFolders.Text = "Client Folders";
			optFolders.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			optFolders.Visible = true;
			optFolders.CheckedChanged += new System.EventHandler(optFolders_CheckedChanged);
			// 
			// optProjects
			// 
			optProjects.AllowDrop = true;
			optProjects.BackColor = System.Drawing.SystemColors.Control;
			optProjects.CausesValidation = true;
			optProjects.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			optProjects.Checked = true;
			optProjects.Enabled = true;
			optProjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			optProjects.ForeColor = System.Drawing.SystemColors.ControlText;
			optProjects.Location = new System.Drawing.Point(11, 13);
			optProjects.Name = "optProjects";
			optProjects.RightToLeft = System.Windows.Forms.RightToLeft.No;
			optProjects.Size = new System.Drawing.Size(94, 19);
			optProjects.TabIndex = 7;
			optProjects.TabStop = true;
			optProjects.Text = "Saved Projects";
			optProjects.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			optProjects.Visible = true;
			optProjects.CheckedChanged += new System.EventHandler(optProjects_CheckedChanged);
			// 
			// lblCFId
			// 
			lblCFId.AllowDrop = true;
			lblCFId.BackColor = System.Drawing.SystemColors.Control;
			lblCFId.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblCFId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblCFId.ForeColor = System.Drawing.SystemColors.ControlText;
			lblCFId.Location = new System.Drawing.Point(143, 39);
			lblCFId.MinimumSize = new System.Drawing.Size(46, 16);
			lblCFId.Name = "lblCFId";
			lblCFId.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblCFId.Size = new System.Drawing.Size(46, 16);
			lblCFId.TabIndex = 35;
			lblCFId.Text = "CFId";
			// 
			// lblSISEId
			// 
			lblSISEId.AllowDrop = true;
			lblSISEId.BackColor = System.Drawing.SystemColors.Control;
			lblSISEId.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblSISEId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblSISEId.ForeColor = System.Drawing.SystemColors.ControlText;
			lblSISEId.Location = new System.Drawing.Point(143, 63);
			lblSISEId.MinimumSize = new System.Drawing.Size(46, 16);
			lblSISEId.Name = "lblSISEId";
			lblSISEId.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblSISEId.Size = new System.Drawing.Size(46, 16);
			lblSISEId.TabIndex = 34;
			lblSISEId.Text = "SISEId";
			// 
			// lblSISSCId
			// 
			lblSISSCId.AllowDrop = true;
			lblSISSCId.BackColor = System.Drawing.SystemColors.Control;
			lblSISSCId.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblSISSCId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblSISSCId.ForeColor = System.Drawing.SystemColors.ControlText;
			lblSISSCId.Location = new System.Drawing.Point(143, 16);
			lblSISSCId.MinimumSize = new System.Drawing.Size(46, 16);
			lblSISSCId.Name = "lblSISSCId";
			lblSISSCId.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblSISSCId.Size = new System.Drawing.Size(46, 16);
			lblSISSCId.TabIndex = 33;
			lblSISSCId.Text = "SISSCId";
			// 
			// frmCenter
			// 
			frmCenter.AllowDrop = true;
			frmCenter.BackColor = System.Drawing.SystemColors.Control;
			frmCenter.Controls.Add(optCopy);
			frmCenter.Controls.Add(optMove);
			frmCenter.Controls.Add(lblMoveTo);
			frmCenter.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmCenter.Enabled = true;
			frmCenter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmCenter.ForeColor = System.Drawing.SystemColors.ControlText;
			frmCenter.Location = new System.Drawing.Point(191, 60);
			frmCenter.Name = "frmCenter";
			frmCenter.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmCenter.Size = new System.Drawing.Size(91, 107);
			frmCenter.TabIndex = 30;
			frmCenter.Text = "Action";
			frmCenter.Visible = true;
			// 
			// optCopy
			// 
			optCopy.AllowDrop = true;
			optCopy.BackColor = System.Drawing.SystemColors.Control;
			optCopy.CausesValidation = true;
			optCopy.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			optCopy.Checked = true;
			optCopy.Enabled = true;
			optCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			optCopy.ForeColor = System.Drawing.SystemColors.ControlText;
			optCopy.Location = new System.Drawing.Point(21, 25);
			optCopy.Name = "optCopy";
			optCopy.RightToLeft = System.Windows.Forms.RightToLeft.No;
			optCopy.Size = new System.Drawing.Size(52, 19);
			optCopy.TabIndex = 5;
			optCopy.TabStop = true;
			optCopy.Text = "Copy";
			optCopy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			optCopy.Visible = true;
			optCopy.CheckedChanged += new System.EventHandler(optCopy_CheckedChanged);
			// 
			// optMove
			// 
			optMove.AllowDrop = true;
			optMove.BackColor = System.Drawing.SystemColors.Control;
			optMove.CausesValidation = true;
			optMove.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			optMove.Checked = false;
			optMove.Enabled = true;
			optMove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			optMove.ForeColor = System.Drawing.SystemColors.ControlText;
			optMove.Location = new System.Drawing.Point(21, 72);
			optMove.Name = "optMove";
			optMove.RightToLeft = System.Windows.Forms.RightToLeft.No;
			optMove.Size = new System.Drawing.Size(52, 19);
			optMove.TabIndex = 6;
			optMove.TabStop = true;
			optMove.Text = "Move";
			optMove.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			optMove.Visible = true;
			optMove.CheckedChanged += new System.EventHandler(optMove_CheckedChanged);
			// 
			// lblMoveTo
			// 
			lblMoveTo.AllowDrop = true;
			lblMoveTo.BackColor = System.Drawing.SystemColors.Control;
			lblMoveTo.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblMoveTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblMoveTo.ForeColor = System.Drawing.SystemColors.ControlText;
			lblMoveTo.Location = new System.Drawing.Point(33, 46);
			lblMoveTo.MinimumSize = new System.Drawing.Size(28, 22);
			lblMoveTo.Name = "lblMoveTo";
			lblMoveTo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblMoveTo.Size = new System.Drawing.Size(28, 22);
			lblMoveTo.TabIndex = 31;
			lblMoveTo.Text = ">>";
			lblMoveTo.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// frmTo
			// 
			frmTo.AllowDrop = true;
			frmTo.BackColor = System.Drawing.SystemColors.Control;
			frmTo.Controls.Add(txtSeqNbrNew);
			frmTo.Controls.Add(txtLoginNew);
			frmTo.Controls.Add(txtSubIdNew);
			frmTo.Controls.Add(lblSeqNbrNew);
			frmTo.Controls.Add(lblLoginNew);
			frmTo.Controls.Add(lblSubIdNew);
			frmTo.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmTo.Enabled = true;
			frmTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmTo.ForeColor = System.Drawing.SystemColors.ControlText;
			frmTo.Location = new System.Drawing.Point(296, 61);
			frmTo.Name = "frmTo";
			frmTo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmTo.Size = new System.Drawing.Size(166, 107);
			frmTo.TabIndex = 26;
			frmTo.Text = "To";
			frmTo.Visible = true;
			// 
			// txtSeqNbrNew
			// 
			txtSeqNbrNew.AcceptsReturn = true;
			txtSeqNbrNew.AllowDrop = true;
			txtSeqNbrNew.BackColor = System.Drawing.SystemColors.Window;
			txtSeqNbrNew.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtSeqNbrNew.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtSeqNbrNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtSeqNbrNew.ForeColor = System.Drawing.SystemColors.WindowText;
			txtSeqNbrNew.Location = new System.Drawing.Point(66, 72);
			txtSeqNbrNew.MaxLength = 0;
			txtSeqNbrNew.Name = "txtSeqNbrNew";
			txtSeqNbrNew.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtSeqNbrNew.Size = new System.Drawing.Size(44, 22);
			txtSeqNbrNew.TabIndex = 15;
			txtSeqNbrNew.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtLoginNew
			// 
			txtLoginNew.AcceptsReturn = true;
			txtLoginNew.AllowDrop = true;
			txtLoginNew.BackColor = System.Drawing.SystemColors.Window;
			txtLoginNew.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtLoginNew.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtLoginNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtLoginNew.ForeColor = System.Drawing.SystemColors.WindowText;
			txtLoginNew.Location = new System.Drawing.Point(66, 48);
			txtLoginNew.MaxLength = 0;
			txtLoginNew.Name = "txtLoginNew";
			txtLoginNew.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtLoginNew.Size = new System.Drawing.Size(90, 22);
			txtLoginNew.TabIndex = 14;
			// 
			// txtSubIdNew
			// 
			txtSubIdNew.AcceptsReturn = true;
			txtSubIdNew.AllowDrop = true;
			txtSubIdNew.BackColor = System.Drawing.SystemColors.Window;
			txtSubIdNew.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtSubIdNew.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtSubIdNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtSubIdNew.ForeColor = System.Drawing.SystemColors.WindowText;
			txtSubIdNew.Location = new System.Drawing.Point(66, 24);
			txtSubIdNew.MaxLength = 0;
			txtSubIdNew.Name = "txtSubIdNew";
			txtSubIdNew.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtSubIdNew.Size = new System.Drawing.Size(44, 22);
			txtSubIdNew.TabIndex = 13;
			txtSubIdNew.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lblSeqNbrNew
			// 
			lblSeqNbrNew.AllowDrop = true;
			lblSeqNbrNew.BackColor = System.Drawing.SystemColors.Control;
			lblSeqNbrNew.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblSeqNbrNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblSeqNbrNew.ForeColor = System.Drawing.SystemColors.ControlText;
			lblSeqNbrNew.Location = new System.Drawing.Point(9, 75);
			lblSeqNbrNew.MinimumSize = new System.Drawing.Size(49, 16);
			lblSeqNbrNew.Name = "lblSeqNbrNew";
			lblSeqNbrNew.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblSeqNbrNew.Size = new System.Drawing.Size(49, 16);
			lblSeqNbrNew.TabIndex = 29;
			lblSeqNbrNew.Text = "SeqNbr";
			// 
			// lblLoginNew
			// 
			lblLoginNew.AllowDrop = true;
			lblLoginNew.BackColor = System.Drawing.SystemColors.Control;
			lblLoginNew.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblLoginNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblLoginNew.ForeColor = System.Drawing.SystemColors.ControlText;
			lblLoginNew.Location = new System.Drawing.Point(9, 51);
			lblLoginNew.MinimumSize = new System.Drawing.Size(49, 16);
			lblLoginNew.Name = "lblLoginNew";
			lblLoginNew.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblLoginNew.Size = new System.Drawing.Size(49, 16);
			lblLoginNew.TabIndex = 28;
			lblLoginNew.Text = "Login";
			// 
			// lblSubIdNew
			// 
			lblSubIdNew.AllowDrop = true;
			lblSubIdNew.BackColor = System.Drawing.SystemColors.Control;
			lblSubIdNew.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblSubIdNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblSubIdNew.ForeColor = System.Drawing.SystemColors.ControlText;
			lblSubIdNew.Location = new System.Drawing.Point(9, 27);
			lblSubIdNew.MinimumSize = new System.Drawing.Size(49, 16);
			lblSubIdNew.Name = "lblSubIdNew";
			lblSubIdNew.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblSubIdNew.Size = new System.Drawing.Size(49, 16);
			lblSubIdNew.TabIndex = 27;
			lblSubIdNew.Text = "SubId";
			// 
			// frmCompany
			// 
			frmCompany.AllowDrop = true;
			frmCompany.BackColor = System.Drawing.SystemColors.Control;
			frmCompany.Controls.Add(txtCompId);
			frmCompany.Controls.Add(lblCompId);
			frmCompany.Controls.Add(lblCompany);
			frmCompany.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmCompany.Enabled = true;
			frmCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmCompany.ForeColor = System.Drawing.SystemColors.ControlText;
			frmCompany.Location = new System.Drawing.Point(7, 9);
			frmCompany.Name = "frmCompany";
			frmCompany.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmCompany.Size = new System.Drawing.Size(456, 43);
			frmCompany.TabIndex = 23;
			frmCompany.Visible = true;
			// 
			// txtCompId
			// 
			txtCompId.AcceptsReturn = true;
			txtCompId.AllowDrop = true;
			txtCompId.BackColor = System.Drawing.SystemColors.Window;
			txtCompId.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtCompId.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtCompId.Enabled = false;
			txtCompId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtCompId.ForeColor = System.Drawing.SystemColors.WindowText;
			txtCompId.Location = new System.Drawing.Point(57, 12);
			txtCompId.MaxLength = 0;
			txtCompId.Name = "txtCompId";
			txtCompId.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtCompId.Size = new System.Drawing.Size(67, 22);
			txtCompId.TabIndex = 1;
			txtCompId.Text = "0";
			txtCompId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lblCompId
			// 
			lblCompId.AllowDrop = true;
			lblCompId.BackColor = System.Drawing.SystemColors.Control;
			lblCompId.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblCompId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblCompId.ForeColor = System.Drawing.SystemColors.ControlText;
			lblCompId.Location = new System.Drawing.Point(9, 15);
			lblCompId.MinimumSize = new System.Drawing.Size(49, 16);
			lblCompId.Name = "lblCompId";
			lblCompId.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblCompId.Size = new System.Drawing.Size(49, 16);
			lblCompId.TabIndex = 25;
			lblCompId.Text = "CompId";
			lblCompId.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lblCompany
			// 
			lblCompany.AllowDrop = true;
			lblCompany.BackColor = System.Drawing.SystemColors.Control;
			lblCompany.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblCompany.ForeColor = System.Drawing.SystemColors.ControlText;
			lblCompany.Location = new System.Drawing.Point(129, 15);
			lblCompany.MinimumSize = new System.Drawing.Size(315, 19);
			lblCompany.Name = "lblCompany";
			lblCompany.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblCompany.Size = new System.Drawing.Size(315, 19);
			lblCompany.TabIndex = 24;
			lblCompany.Text = "Company";
			// 
			// lstbCopyMove
			// 
			lstbCopyMove.AllowDrop = true;
			lstbCopyMove.BackColor = System.Drawing.SystemColors.Window;
			lstbCopyMove.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			lstbCopyMove.CausesValidation = true;
			lstbCopyMove.Enabled = true;
			lstbCopyMove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lstbCopyMove.ForeColor = System.Drawing.SystemColors.WindowText;
			lstbCopyMove.IntegralHeight = true;
			lstbCopyMove.Location = new System.Drawing.Point(7, 297);
			lstbCopyMove.MultiColumn = false;
			lstbCopyMove.Name = "lstbCopyMove";
			lstbCopyMove.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lstbCopyMove.Size = new System.Drawing.Size(458, 111);
			lstbCopyMove.Sorted = false;
			lstbCopyMove.TabIndex = 18;
			lstbCopyMove.TabStop = true;
			lstbCopyMove.Visible = true;
			// 
			// cmdClose
			// 
			cmdClose.AllowDrop = true;
			cmdClose.BackColor = System.Drawing.SystemColors.Control;
			cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdClose.Location = new System.Drawing.Point(392, 188);
			cmdClose.Name = "cmdClose";
			cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdClose.Size = new System.Drawing.Size(64, 28);
			cmdClose.TabIndex = 17;
			cmdClose.Text = "C&lose";
			cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdClose.UseVisualStyleBackColor = false;
			cmdClose.Click += new System.EventHandler(cmdClose_Click);
			// 
			// cmdCopyMove
			// 
			cmdCopyMove.AllowDrop = true;
			cmdCopyMove.BackColor = System.Drawing.SystemColors.Control;
			cmdCopyMove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdCopyMove.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdCopyMove.Location = new System.Drawing.Point(10, 186);
			cmdCopyMove.Name = "cmdCopyMove";
			cmdCopyMove.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdCopyMove.Size = new System.Drawing.Size(64, 28);
			cmdCopyMove.TabIndex = 16;
			cmdCopyMove.Text = "&Copy";
			cmdCopyMove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdCopyMove.UseVisualStyleBackColor = false;
			cmdCopyMove.Click += new System.EventHandler(cmdCopyMove_Click);
			// 
			// frmFrom
			// 
			frmFrom.AllowDrop = true;
			frmFrom.BackColor = System.Drawing.SystemColors.Control;
			frmFrom.Controls.Add(txtSeqNbrOld);
			frmFrom.Controls.Add(txtLoginOld);
			frmFrom.Controls.Add(txtSubIdOld);
			frmFrom.Controls.Add(lblSeqNbrOld);
			frmFrom.Controls.Add(lblLoginOld);
			frmFrom.Controls.Add(lblSubIdOld);
			frmFrom.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmFrom.Enabled = true;
			frmFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmFrom.ForeColor = System.Drawing.SystemColors.ControlText;
			frmFrom.Location = new System.Drawing.Point(7, 61);
			frmFrom.Name = "frmFrom";
			frmFrom.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmFrom.Size = new System.Drawing.Size(166, 105);
			frmFrom.TabIndex = 19;
			frmFrom.Text = "Copy From";
			frmFrom.Visible = true;
			// 
			// txtSeqNbrOld
			// 
			txtSeqNbrOld.AcceptsReturn = true;
			txtSeqNbrOld.AllowDrop = true;
			txtSeqNbrOld.BackColor = System.Drawing.SystemColors.Window;
			txtSeqNbrOld.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtSeqNbrOld.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtSeqNbrOld.Enabled = false;
			txtSeqNbrOld.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtSeqNbrOld.ForeColor = System.Drawing.SystemColors.WindowText;
			txtSeqNbrOld.Location = new System.Drawing.Point(66, 72);
			txtSeqNbrOld.MaxLength = 0;
			txtSeqNbrOld.Name = "txtSeqNbrOld";
			txtSeqNbrOld.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtSeqNbrOld.Size = new System.Drawing.Size(44, 22);
			txtSeqNbrOld.TabIndex = 4;
			txtSeqNbrOld.Text = "0";
			txtSeqNbrOld.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtLoginOld
			// 
			txtLoginOld.AcceptsReturn = true;
			txtLoginOld.AllowDrop = true;
			txtLoginOld.BackColor = System.Drawing.SystemColors.Window;
			txtLoginOld.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtLoginOld.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtLoginOld.Enabled = false;
			txtLoginOld.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtLoginOld.ForeColor = System.Drawing.SystemColors.WindowText;
			txtLoginOld.Location = new System.Drawing.Point(66, 48);
			txtLoginOld.MaxLength = 0;
			txtLoginOld.Name = "txtLoginOld";
			txtLoginOld.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtLoginOld.Size = new System.Drawing.Size(90, 22);
			txtLoginOld.TabIndex = 3;
			// 
			// txtSubIdOld
			// 
			txtSubIdOld.AcceptsReturn = true;
			txtSubIdOld.AllowDrop = true;
			txtSubIdOld.BackColor = System.Drawing.SystemColors.Window;
			txtSubIdOld.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtSubIdOld.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtSubIdOld.Enabled = false;
			txtSubIdOld.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtSubIdOld.ForeColor = System.Drawing.SystemColors.WindowText;
			txtSubIdOld.Location = new System.Drawing.Point(66, 24);
			txtSubIdOld.MaxLength = 0;
			txtSubIdOld.Name = "txtSubIdOld";
			txtSubIdOld.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtSubIdOld.Size = new System.Drawing.Size(44, 22);
			txtSubIdOld.TabIndex = 2;
			txtSubIdOld.Text = "0";
			txtSubIdOld.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lblSeqNbrOld
			// 
			lblSeqNbrOld.AllowDrop = true;
			lblSeqNbrOld.BackColor = System.Drawing.SystemColors.Control;
			lblSeqNbrOld.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblSeqNbrOld.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblSeqNbrOld.ForeColor = System.Drawing.SystemColors.ControlText;
			lblSeqNbrOld.Location = new System.Drawing.Point(9, 75);
			lblSeqNbrOld.MinimumSize = new System.Drawing.Size(49, 16);
			lblSeqNbrOld.Name = "lblSeqNbrOld";
			lblSeqNbrOld.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblSeqNbrOld.Size = new System.Drawing.Size(49, 16);
			lblSeqNbrOld.TabIndex = 22;
			lblSeqNbrOld.Text = "SeqNbr";
			// 
			// lblLoginOld
			// 
			lblLoginOld.AllowDrop = true;
			lblLoginOld.BackColor = System.Drawing.SystemColors.Control;
			lblLoginOld.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblLoginOld.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblLoginOld.ForeColor = System.Drawing.SystemColors.ControlText;
			lblLoginOld.Location = new System.Drawing.Point(9, 51);
			lblLoginOld.MinimumSize = new System.Drawing.Size(49, 16);
			lblLoginOld.Name = "lblLoginOld";
			lblLoginOld.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblLoginOld.Size = new System.Drawing.Size(49, 16);
			lblLoginOld.TabIndex = 21;
			lblLoginOld.Text = "Login";
			// 
			// lblSubIdOld
			// 
			lblSubIdOld.AllowDrop = true;
			lblSubIdOld.BackColor = System.Drawing.SystemColors.Control;
			lblSubIdOld.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblSubIdOld.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblSubIdOld.ForeColor = System.Drawing.SystemColors.ControlText;
			lblSubIdOld.Location = new System.Drawing.Point(9, 27);
			lblSubIdOld.MinimumSize = new System.Drawing.Size(49, 16);
			lblSubIdOld.Name = "lblSubIdOld";
			lblSubIdOld.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblSubIdOld.Size = new System.Drawing.Size(49, 16);
			lblSubIdOld.TabIndex = 20;
			lblSubIdOld.Text = "SubId";
			// 
			// lblStatus
			// 
			lblStatus.AllowDrop = true;
			lblStatus.BackColor = System.Drawing.SystemColors.Window;
			lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblStatus.ForeColor = System.Drawing.SystemColors.WindowText;
			lblStatus.Location = new System.Drawing.Point(7, 267);
			lblStatus.MinimumSize = new System.Drawing.Size(458, 28);
			lblStatus.Name = "lblStatus";
			lblStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblStatus.Size = new System.Drawing.Size(458, 28);
			lblStatus.TabIndex = 0;
			lblStatus.Text = "This Will Copy Saved Project(s)";
			lblStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// frm_Subscription_CopyMoveSavedProjects
			// 
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			ClientSize = new System.Drawing.Size(472, 415);
			Controls.Add(frmType);
			Controls.Add(frmCenter);
			Controls.Add(frmTo);
			Controls.Add(frmCompany);
			Controls.Add(lstbCopyMove);
			Controls.Add(cmdClose);
			Controls.Add(cmdCopyMove);
			Controls.Add(frmFrom);
			Controls.Add(lblStatus);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Location = new System.Drawing.Point(2537, 305);
			MaximizeBox = true;
			MinimizeBox = true;
			Name = "frm_Subscription_CopyMoveSavedProjects";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			Text = "Copy/Move Saved Project(s), Client Folder(s) or Saved Export(s)";
			commandButtonHelper1.SetStyle(cmdClose, 0);
			commandButtonHelper1.SetStyle(cmdCopyMove, 0);
			listBoxHelper1.SetSelectionMode(lstbCopyMove, System.Windows.Forms.SelectionMode.One);
			optionButtonHelper1.SetStyle(optSavedExports, 0);
			optionButtonHelper1.SetStyle(optFolders, 0);
			optionButtonHelper1.SetStyle(optProjects, 0);
			optionButtonHelper1.SetStyle(optCopy, 0);
			optionButtonHelper1.SetStyle(optMove, 0);
			ToolTipMain.SetToolTip(txtCFId, "Enter a Specific CFIdTo Copy/Move Just One Client Folder");
			ToolTipMain.SetToolTip(txtSISEId, "Enter a Specific SISEId To Copy/Move Just One Saved Export");
			ToolTipMain.SetToolTip(optSavedExports, "Click To Copy Client Folders");
			ToolTipMain.SetToolTip(txtSISSCId, "Enter a Specific SiSSCId To Copy/Move Just One Project");
			ToolTipMain.SetToolTip(optFolders, "Click To Copy Client Folders");
			ToolTipMain.SetToolTip(optProjects, "Click To Copy Saved Projects");
			ToolTipMain.SetToolTip(optCopy, "Click To COPY To Install");
			ToolTipMain.SetToolTip(optMove, "Click To MOVE To Install");
			Activated += new System.EventHandler(Form_Activated);
			Closed += new System.EventHandler(Form_Closed);
			frmType.ResumeLayout(false);
			frmType.PerformLayout();
			frmCenter.ResumeLayout(false);
			frmCenter.PerformLayout();
			frmTo.ResumeLayout(false);
			frmTo.PerformLayout();
			frmCompany.ResumeLayout(false);
			frmCompany.PerformLayout();
			frmFrom.ResumeLayout(false);
			frmFrom.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
		void ReLoadForm(bool addEvents) => Form_Initialize();

		#endregion
	}
}