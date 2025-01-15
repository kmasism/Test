
namespace JETNET_Homebase
{
	partial class frm_ContactRelationships
	{

		#region "Upgrade Support "
		private static frm_ContactRelationships m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_ContactRelationships DefInstance
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
		public static frm_ContactRelationships CreateInstance()
		{
			frm_ContactRelationships theInstance = new frm_ContactRelationships();
			return theInstance;
		}
		private string[] visualControls = new string[]{"components", "ToolTipMain", "cmdStop", "txtMainContactId", "lblMainContactName", "frmMainContact", "txtMainCompId", "cmdDelete", "cmdAdd", "txtRelationship", "chkSearchLNameOnly", "chkSearchFNameOnly", "cmdRefresh", "txtSearchDifferentLName", "txtSearchDifferentFName", "chkSearchCellNbrOnly", "lblDifferentName", "lblSearchLName", "lblSearchFName", "frmSearch", "mfgPossibleContacts", "mfgRelatedContacts", "lblMainContactId", "lblMainCompId", "lblPossibleContacts", "lblRelatedContacts", "lblRelationship", "lblStatus", "commandButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Button cmdStop;
		public System.Windows.Forms.TextBox txtMainContactId;
		public System.Windows.Forms.Label lblMainContactName;
		public System.Windows.Forms.GroupBox frmMainContact;
		public System.Windows.Forms.TextBox txtMainCompId;
		public System.Windows.Forms.Button cmdDelete;
		public System.Windows.Forms.Button cmdAdd;
		public System.Windows.Forms.TextBox txtRelationship;
		public System.Windows.Forms.CheckBox chkSearchLNameOnly;
		public System.Windows.Forms.CheckBox chkSearchFNameOnly;
		public System.Windows.Forms.Button cmdRefresh;
		public System.Windows.Forms.TextBox txtSearchDifferentLName;
		public System.Windows.Forms.TextBox txtSearchDifferentFName;
		public System.Windows.Forms.CheckBox chkSearchCellNbrOnly;
		public System.Windows.Forms.Label lblDifferentName;
		public System.Windows.Forms.Label lblSearchLName;
		public System.Windows.Forms.Label lblSearchFName;
		public System.Windows.Forms.GroupBox frmSearch;
		public UpgradeHelpers.DataGridViewFlex mfgPossibleContacts;
		public UpgradeHelpers.DataGridViewFlex mfgRelatedContacts;
		public System.Windows.Forms.Label lblMainContactId;
		public System.Windows.Forms.Label lblMainCompId;
		public System.Windows.Forms.Label lblPossibleContacts;
		public System.Windows.Forms.Label lblRelatedContacts;
		public System.Windows.Forms.Label lblRelationship;
		public System.Windows.Forms.Label lblStatus;
		public UpgradeHelpers.Gui.Controls.CommandButtonHelper commandButtonHelper1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ContactRelationships));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			cmdStop = new System.Windows.Forms.Button();
			txtMainContactId = new System.Windows.Forms.TextBox();
			frmMainContact = new System.Windows.Forms.GroupBox();
			lblMainContactName = new System.Windows.Forms.Label();
			txtMainCompId = new System.Windows.Forms.TextBox();
			cmdDelete = new System.Windows.Forms.Button();
			cmdAdd = new System.Windows.Forms.Button();
			txtRelationship = new System.Windows.Forms.TextBox();
			frmSearch = new System.Windows.Forms.GroupBox();
			chkSearchLNameOnly = new System.Windows.Forms.CheckBox();
			chkSearchFNameOnly = new System.Windows.Forms.CheckBox();
			cmdRefresh = new System.Windows.Forms.Button();
			txtSearchDifferentLName = new System.Windows.Forms.TextBox();
			txtSearchDifferentFName = new System.Windows.Forms.TextBox();
			chkSearchCellNbrOnly = new System.Windows.Forms.CheckBox();
			lblDifferentName = new System.Windows.Forms.Label();
			lblSearchLName = new System.Windows.Forms.Label();
			lblSearchFName = new System.Windows.Forms.Label();
			mfgPossibleContacts = new UpgradeHelpers.DataGridViewFlex(components);
			mfgRelatedContacts = new UpgradeHelpers.DataGridViewFlex(components);
			lblMainContactId = new System.Windows.Forms.Label();
			lblMainCompId = new System.Windows.Forms.Label();
			lblPossibleContacts = new System.Windows.Forms.Label();
			lblRelatedContacts = new System.Windows.Forms.Label();
			lblRelationship = new System.Windows.Forms.Label();
			lblStatus = new System.Windows.Forms.Label();
			frmMainContact.SuspendLayout();
			frmSearch.SuspendLayout();
			SuspendLayout();
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
			((System.ComponentModel.ISupportInitialize) mfgPossibleContacts).BeginInit();
			((System.ComponentModel.ISupportInitialize) mfgRelatedContacts).BeginInit();
			// 
			// cmdStop
			// 
			cmdStop.AllowDrop = true;
			cmdStop.BackColor = System.Drawing.SystemColors.Control;
			cmdStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdStop.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdStop.Location = new System.Drawing.Point(742, 24);
			cmdStop.Name = "cmdStop";
			cmdStop.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdStop.Size = new System.Drawing.Size(65, 35);
			cmdStop.TabIndex = 25;
			cmdStop.Text = "Stop Loading";
			cmdStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdStop.UseVisualStyleBackColor = false;
			cmdStop.Visible = false;
			cmdStop.Click += new System.EventHandler(cmdStop_Click);
			// 
			// txtMainContactId
			// 
			txtMainContactId.AcceptsReturn = true;
			txtMainContactId.AllowDrop = true;
			txtMainContactId.BackColor = System.Drawing.SystemColors.Window;
			txtMainContactId.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtMainContactId.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtMainContactId.Enabled = false;
			txtMainContactId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtMainContactId.ForeColor = System.Drawing.SystemColors.WindowText;
			txtMainContactId.Location = new System.Drawing.Point(104, 12);
			txtMainContactId.MaxLength = 0;
			txtMainContactId.Name = "txtMainContactId";
			txtMainContactId.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtMainContactId.Size = new System.Drawing.Size(65, 23);
			txtMainContactId.TabIndex = 1;
			txtMainContactId.Text = "0";
			txtMainContactId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// frmMainContact
			// 
			frmMainContact.AllowDrop = true;
			frmMainContact.BackColor = System.Drawing.SystemColors.Control;
			frmMainContact.Controls.Add(lblMainContactName);
			frmMainContact.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmMainContact.Enabled = true;
			frmMainContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmMainContact.ForeColor = System.Drawing.SystemColors.ControlText;
			frmMainContact.Location = new System.Drawing.Point(236, 6);
			frmMainContact.Name = "frmMainContact";
			frmMainContact.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmMainContact.Size = new System.Drawing.Size(353, 179);
			frmMainContact.TabIndex = 17;
			frmMainContact.Text = "Main Contact";
			frmMainContact.Visible = true;
			// 
			// lblMainContactName
			// 
			lblMainContactName.AllowDrop = true;
			lblMainContactName.BackColor = System.Drawing.SystemColors.Control;
			lblMainContactName.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblMainContactName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblMainContactName.ForeColor = System.Drawing.SystemColors.ControlText;
			lblMainContactName.Location = new System.Drawing.Point(10, 20);
			lblMainContactName.MinimumSize = new System.Drawing.Size(333, 117);
			lblMainContactName.Name = "lblMainContactName";
			lblMainContactName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblMainContactName.Size = new System.Drawing.Size(333, 117);
			lblMainContactName.TabIndex = 18;
			lblMainContactName.Text = "Contact Name";
			// 
			// txtMainCompId
			// 
			txtMainCompId.AcceptsReturn = true;
			txtMainCompId.AllowDrop = true;
			txtMainCompId.BackColor = System.Drawing.SystemColors.Window;
			txtMainCompId.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtMainCompId.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtMainCompId.Enabled = false;
			txtMainCompId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtMainCompId.ForeColor = System.Drawing.SystemColors.WindowText;
			txtMainCompId.Location = new System.Drawing.Point(104, 40);
			txtMainCompId.MaxLength = 0;
			txtMainCompId.Name = "txtMainCompId";
			txtMainCompId.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtMainCompId.Size = new System.Drawing.Size(65, 23);
			txtMainCompId.TabIndex = 2;
			txtMainCompId.Text = "0";
			txtMainCompId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// cmdDelete
			// 
			cmdDelete.AllowDrop = true;
			cmdDelete.BackColor = System.Drawing.SystemColors.Control;
			cmdDelete.Enabled = false;
			cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdDelete.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdDelete.Location = new System.Drawing.Point(162, 342);
			cmdDelete.Name = "cmdDelete";
			cmdDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdDelete.Size = new System.Drawing.Size(57, 21);
			cmdDelete.TabIndex = 11;
			cmdDelete.Text = "Delete";
			cmdDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdDelete.Click += new System.EventHandler(cmdDelete_Click);
			// 
			// cmdAdd
			// 
			cmdAdd.AllowDrop = true;
			cmdAdd.BackColor = System.Drawing.SystemColors.Control;
			cmdAdd.Enabled = false;
			cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdAdd.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdAdd.Location = new System.Drawing.Point(8, 166);
			cmdAdd.Name = "cmdAdd";
			cmdAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdAdd.Size = new System.Drawing.Size(65, 21);
			cmdAdd.TabIndex = 16;
			cmdAdd.Text = "Add";
			cmdAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdAdd.Click += new System.EventHandler(cmdAdd_Click);
			// 
			// txtRelationship
			// 
			txtRelationship.AcceptsReturn = true;
			txtRelationship.AllowDrop = true;
			txtRelationship.BackColor = System.Drawing.SystemColors.Window;
			txtRelationship.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtRelationship.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtRelationship.Enabled = false;
			txtRelationship.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtRelationship.ForeColor = System.Drawing.SystemColors.WindowText;
			txtRelationship.Location = new System.Drawing.Point(8, 138);
			txtRelationship.MaxLength = 100;
			txtRelationship.Name = "txtRelationship";
			txtRelationship.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtRelationship.Size = new System.Drawing.Size(221, 23);
			txtRelationship.TabIndex = 3;
			txtRelationship.Text = "Also Known As";
			// 
			// frmSearch
			// 
			frmSearch.AllowDrop = true;
			frmSearch.BackColor = System.Drawing.SystemColors.Control;
			frmSearch.Controls.Add(chkSearchLNameOnly);
			frmSearch.Controls.Add(chkSearchFNameOnly);
			frmSearch.Controls.Add(cmdRefresh);
			frmSearch.Controls.Add(txtSearchDifferentLName);
			frmSearch.Controls.Add(txtSearchDifferentFName);
			frmSearch.Controls.Add(chkSearchCellNbrOnly);
			frmSearch.Controls.Add(lblDifferentName);
			frmSearch.Controls.Add(lblSearchLName);
			frmSearch.Controls.Add(lblSearchFName);
			frmSearch.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmSearch.Enabled = true;
			frmSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmSearch.ForeColor = System.Drawing.SystemColors.ControlText;
			frmSearch.Location = new System.Drawing.Point(596, 6);
			frmSearch.Name = "frmSearch";
			frmSearch.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmSearch.Size = new System.Drawing.Size(221, 179);
			frmSearch.TabIndex = 0;
			frmSearch.Text = "Search";
			frmSearch.Visible = true;
			// 
			// chkSearchLNameOnly
			// 
			chkSearchLNameOnly.AllowDrop = true;
			chkSearchLNameOnly.Appearance = System.Windows.Forms.Appearance.Normal;
			chkSearchLNameOnly.BackColor = System.Drawing.SystemColors.Control;
			chkSearchLNameOnly.CausesValidation = true;
			chkSearchLNameOnly.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkSearchLNameOnly.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkSearchLNameOnly.Enabled = true;
			chkSearchLNameOnly.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkSearchLNameOnly.ForeColor = System.Drawing.SystemColors.ControlText;
			chkSearchLNameOnly.Location = new System.Drawing.Point(16, 36);
			chkSearchLNameOnly.Name = "chkSearchLNameOnly";
			chkSearchLNameOnly.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkSearchLNameOnly.Size = new System.Drawing.Size(137, 17);
			chkSearchLNameOnly.TabIndex = 5;
			chkSearchLNameOnly.TabStop = true;
			chkSearchLNameOnly.Text = "Last Name Only";
			chkSearchLNameOnly.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkSearchLNameOnly.Visible = true;
			chkSearchLNameOnly.CheckStateChanged += new System.EventHandler(chkSearchLNameOnly_CheckStateChanged);
			// 
			// chkSearchFNameOnly
			// 
			chkSearchFNameOnly.AllowDrop = true;
			chkSearchFNameOnly.Appearance = System.Windows.Forms.Appearance.Normal;
			chkSearchFNameOnly.BackColor = System.Drawing.SystemColors.Control;
			chkSearchFNameOnly.CausesValidation = true;
			chkSearchFNameOnly.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkSearchFNameOnly.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkSearchFNameOnly.Enabled = true;
			chkSearchFNameOnly.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkSearchFNameOnly.ForeColor = System.Drawing.SystemColors.ControlText;
			chkSearchFNameOnly.Location = new System.Drawing.Point(16, 16);
			chkSearchFNameOnly.Name = "chkSearchFNameOnly";
			chkSearchFNameOnly.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkSearchFNameOnly.Size = new System.Drawing.Size(137, 17);
			chkSearchFNameOnly.TabIndex = 4;
			chkSearchFNameOnly.TabStop = true;
			chkSearchFNameOnly.Text = "First Name Only";
			chkSearchFNameOnly.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkSearchFNameOnly.Visible = true;
			chkSearchFNameOnly.CheckStateChanged += new System.EventHandler(chkSearchFNameOnly_CheckStateChanged);
			// 
			// cmdRefresh
			// 
			cmdRefresh.AllowDrop = true;
			cmdRefresh.BackColor = System.Drawing.SystemColors.Control;
			cmdRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdRefresh.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdRefresh.Location = new System.Drawing.Point(80, 152);
			cmdRefresh.Name = "cmdRefresh";
			cmdRefresh.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdRefresh.Size = new System.Drawing.Size(65, 21);
			cmdRefresh.TabIndex = 9;
			cmdRefresh.Text = "Refresh";
			cmdRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdRefresh.UseVisualStyleBackColor = false;
			cmdRefresh.Click += new System.EventHandler(cmdRefresh_Click);
			// 
			// txtSearchDifferentLName
			// 
			txtSearchDifferentLName.AcceptsReturn = true;
			txtSearchDifferentLName.AllowDrop = true;
			txtSearchDifferentLName.BackColor = System.Drawing.SystemColors.Window;
			txtSearchDifferentLName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtSearchDifferentLName.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtSearchDifferentLName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtSearchDifferentLName.ForeColor = System.Drawing.SystemColors.WindowText;
			txtSearchDifferentLName.Location = new System.Drawing.Point(44, 122);
			txtSearchDifferentLName.MaxLength = 100;
			txtSearchDifferentLName.Name = "txtSearchDifferentLName";
			txtSearchDifferentLName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtSearchDifferentLName.Size = new System.Drawing.Size(169, 23);
			txtSearchDifferentLName.TabIndex = 8;
			// 
			// txtSearchDifferentFName
			// 
			txtSearchDifferentFName.AcceptsReturn = true;
			txtSearchDifferentFName.AllowDrop = true;
			txtSearchDifferentFName.BackColor = System.Drawing.SystemColors.Window;
			txtSearchDifferentFName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtSearchDifferentFName.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtSearchDifferentFName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtSearchDifferentFName.ForeColor = System.Drawing.SystemColors.WindowText;
			txtSearchDifferentFName.Location = new System.Drawing.Point(44, 96);
			txtSearchDifferentFName.MaxLength = 100;
			txtSearchDifferentFName.Name = "txtSearchDifferentFName";
			txtSearchDifferentFName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtSearchDifferentFName.Size = new System.Drawing.Size(119, 23);
			txtSearchDifferentFName.TabIndex = 7;
			// 
			// chkSearchCellNbrOnly
			// 
			chkSearchCellNbrOnly.AllowDrop = true;
			chkSearchCellNbrOnly.Appearance = System.Windows.Forms.Appearance.Normal;
			chkSearchCellNbrOnly.BackColor = System.Drawing.SystemColors.Control;
			chkSearchCellNbrOnly.CausesValidation = true;
			chkSearchCellNbrOnly.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkSearchCellNbrOnly.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkSearchCellNbrOnly.Enabled = true;
			chkSearchCellNbrOnly.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkSearchCellNbrOnly.ForeColor = System.Drawing.SystemColors.ControlText;
			chkSearchCellNbrOnly.Location = new System.Drawing.Point(16, 56);
			chkSearchCellNbrOnly.Name = "chkSearchCellNbrOnly";
			chkSearchCellNbrOnly.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkSearchCellNbrOnly.Size = new System.Drawing.Size(137, 17);
			chkSearchCellNbrOnly.TabIndex = 6;
			chkSearchCellNbrOnly.TabStop = true;
			chkSearchCellNbrOnly.Text = "Cell Nbr Only";
			chkSearchCellNbrOnly.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkSearchCellNbrOnly.Visible = true;
			chkSearchCellNbrOnly.CheckStateChanged += new System.EventHandler(chkSearchCellNbrOnly_CheckStateChanged);
			// 
			// lblDifferentName
			// 
			lblDifferentName.AllowDrop = true;
			lblDifferentName.BackColor = System.Drawing.SystemColors.Control;
			lblDifferentName.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblDifferentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblDifferentName.ForeColor = System.Drawing.SystemColors.ControlText;
			lblDifferentName.Location = new System.Drawing.Point(10, 78);
			lblDifferentName.MinimumSize = new System.Drawing.Size(83, 15);
			lblDifferentName.Name = "lblDifferentName";
			lblDifferentName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblDifferentName.Size = new System.Drawing.Size(83, 15);
			lblDifferentName.TabIndex = 15;
			lblDifferentName.Text = "Different Name";
			// 
			// lblSearchLName
			// 
			lblSearchLName.AllowDrop = true;
			lblSearchLName.BackColor = System.Drawing.SystemColors.Control;
			lblSearchLName.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblSearchLName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblSearchLName.ForeColor = System.Drawing.SystemColors.ControlText;
			lblSearchLName.Location = new System.Drawing.Point(12, 126);
			lblSearchLName.MinimumSize = new System.Drawing.Size(23, 15);
			lblSearchLName.Name = "lblSearchLName";
			lblSearchLName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblSearchLName.Size = new System.Drawing.Size(23, 15);
			lblSearchLName.TabIndex = 14;
			lblSearchLName.Text = "Last";
			// 
			// lblSearchFName
			// 
			lblSearchFName.AllowDrop = true;
			lblSearchFName.BackColor = System.Drawing.SystemColors.Control;
			lblSearchFName.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblSearchFName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblSearchFName.ForeColor = System.Drawing.SystemColors.ControlText;
			lblSearchFName.Location = new System.Drawing.Point(12, 100);
			lblSearchFName.MinimumSize = new System.Drawing.Size(23, 15);
			lblSearchFName.Name = "lblSearchFName";
			lblSearchFName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblSearchFName.Size = new System.Drawing.Size(23, 15);
			lblSearchFName.TabIndex = 13;
			lblSearchFName.Text = "First";
			// 
			// mfgPossibleContacts
			// 
			mfgPossibleContacts.AllowDrop = true;
			mfgPossibleContacts.AllowUserToAddRows = false;
			mfgPossibleContacts.AllowUserToDeleteRows = false;
			mfgPossibleContacts.AllowUserToResizeColumns = false;
			mfgPossibleContacts.AllowUserToResizeColumns = mfgPossibleContacts.ColumnHeadersVisible;
			mfgPossibleContacts.AllowUserToResizeRows = false;
			mfgPossibleContacts.AllowUserToResizeRows = false;
			mfgPossibleContacts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			mfgPossibleContacts.ColumnsCount = 2;
			mfgPossibleContacts.FixedColumns = 1;
			mfgPossibleContacts.FixedRows = 1;
			mfgPossibleContacts.Location = new System.Drawing.Point(8, 192);
			mfgPossibleContacts.Name = "mfgPossibleContacts";
			mfgPossibleContacts.ReadOnly = true;
			mfgPossibleContacts.RowsCount = 2;
			mfgPossibleContacts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			mfgPossibleContacts.ShowCellToolTips = false;
			mfgPossibleContacts.Size = new System.Drawing.Size(957, 139);
			mfgPossibleContacts.StandardTab = true;
			mfgPossibleContacts.TabIndex = 10;
			mfgPossibleContacts.Click += new System.EventHandler(mfgPossibleContacts_Click);
			// 
			// mfgRelatedContacts
			// 
			mfgRelatedContacts.AllowDrop = true;
			mfgRelatedContacts.AllowUserToAddRows = false;
			mfgRelatedContacts.AllowUserToDeleteRows = false;
			mfgRelatedContacts.AllowUserToResizeColumns = false;
			mfgRelatedContacts.AllowUserToResizeColumns = mfgRelatedContacts.ColumnHeadersVisible;
			mfgRelatedContacts.AllowUserToResizeRows = false;
			mfgRelatedContacts.AllowUserToResizeRows = false;
			mfgRelatedContacts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			mfgRelatedContacts.ColumnsCount = 2;
			mfgRelatedContacts.FixedColumns = 1;
			mfgRelatedContacts.FixedRows = 1;
			mfgRelatedContacts.Location = new System.Drawing.Point(10, 372);
			mfgRelatedContacts.Name = "mfgRelatedContacts";
			mfgRelatedContacts.ReadOnly = true;
			mfgRelatedContacts.RowsCount = 2;
			mfgRelatedContacts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			mfgRelatedContacts.ShowCellToolTips = false;
			mfgRelatedContacts.Size = new System.Drawing.Size(953, 151);
			mfgRelatedContacts.StandardTab = true;
			mfgRelatedContacts.TabIndex = 12;
			mfgRelatedContacts.Click += new System.EventHandler(mfgRelatedContacts_Click);
			// 
			// lblMainContactId
			// 
			lblMainContactId.AllowDrop = true;
			lblMainContactId.BackColor = System.Drawing.SystemColors.Control;
			lblMainContactId.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblMainContactId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblMainContactId.ForeColor = System.Drawing.SystemColors.ControlText;
			lblMainContactId.Location = new System.Drawing.Point(12, 14);
			lblMainContactId.MinimumSize = new System.Drawing.Size(85, 19);
			lblMainContactId.Name = "lblMainContactId";
			lblMainContactId.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblMainContactId.Size = new System.Drawing.Size(85, 19);
			lblMainContactId.TabIndex = 24;
			lblMainContactId.Text = "Main Contact Id";
			// 
			// lblMainCompId
			// 
			lblMainCompId.AllowDrop = true;
			lblMainCompId.BackColor = System.Drawing.SystemColors.Control;
			lblMainCompId.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblMainCompId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblMainCompId.ForeColor = System.Drawing.SystemColors.ControlText;
			lblMainCompId.Location = new System.Drawing.Point(12, 42);
			lblMainCompId.MinimumSize = new System.Drawing.Size(85, 19);
			lblMainCompId.Name = "lblMainCompId";
			lblMainCompId.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblMainCompId.Size = new System.Drawing.Size(85, 19);
			lblMainCompId.TabIndex = 23;
			lblMainCompId.Text = "Main Comp Id";
			// 
			// lblPossibleContacts
			// 
			lblPossibleContacts.AllowDrop = true;
			lblPossibleContacts.BackColor = System.Drawing.SystemColors.Control;
			lblPossibleContacts.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblPossibleContacts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblPossibleContacts.ForeColor = System.Drawing.SystemColors.ControlText;
			lblPossibleContacts.Location = new System.Drawing.Point(80, 168);
			lblPossibleContacts.MinimumSize = new System.Drawing.Size(149, 19);
			lblPossibleContacts.Name = "lblPossibleContacts";
			lblPossibleContacts.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblPossibleContacts.Size = new System.Drawing.Size(149, 19);
			lblPossibleContacts.TabIndex = 22;
			lblPossibleContacts.Text = "Possible Related Contacts";
			// 
			// lblRelatedContacts
			// 
			lblRelatedContacts.AllowDrop = true;
			lblRelatedContacts.BackColor = System.Drawing.SystemColors.Control;
			lblRelatedContacts.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblRelatedContacts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblRelatedContacts.ForeColor = System.Drawing.SystemColors.ControlText;
			lblRelatedContacts.Location = new System.Drawing.Point(8, 344);
			lblRelatedContacts.MinimumSize = new System.Drawing.Size(143, 19);
			lblRelatedContacts.Name = "lblRelatedContacts";
			lblRelatedContacts.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblRelatedContacts.Size = new System.Drawing.Size(143, 19);
			lblRelatedContacts.TabIndex = 21;
			lblRelatedContacts.Text = "Related Contacts";
			// 
			// lblRelationship
			// 
			lblRelationship.AllowDrop = true;
			lblRelationship.BackColor = System.Drawing.SystemColors.Control;
			lblRelationship.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblRelationship.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblRelationship.ForeColor = System.Drawing.SystemColors.ControlText;
			lblRelationship.Location = new System.Drawing.Point(10, 116);
			lblRelationship.MinimumSize = new System.Drawing.Size(123, 19);
			lblRelationship.Name = "lblRelationship";
			lblRelationship.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblRelationship.Size = new System.Drawing.Size(123, 19);
			lblRelationship.TabIndex = 20;
			lblRelationship.Text = "Relationship Description";
			// 
			// lblStatus
			// 
			lblStatus.AllowDrop = true;
			lblStatus.BackColor = System.Drawing.SystemColors.Control;
			lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblStatus.ForeColor = System.Drawing.SystemColors.ControlText;
			lblStatus.Location = new System.Drawing.Point(228, 342);
			lblStatus.MinimumSize = new System.Drawing.Size(735, 19);
			lblStatus.Name = "lblStatus";
			lblStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblStatus.Size = new System.Drawing.Size(735, 19);
			lblStatus.TabIndex = 19;
			lblStatus.Text = "Status:";
			// 
			// frm_ContactRelationships
			// 
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			ClientSize = new System.Drawing.Size(973, 537);
			Controls.Add(cmdStop);
			Controls.Add(txtMainContactId);
			Controls.Add(frmMainContact);
			Controls.Add(txtMainCompId);
			Controls.Add(cmdDelete);
			Controls.Add(cmdAdd);
			Controls.Add(txtRelationship);
			Controls.Add(frmSearch);
			Controls.Add(mfgPossibleContacts);
			Controls.Add(mfgRelatedContacts);
			Controls.Add(lblMainContactId);
			Controls.Add(lblMainCompId);
			Controls.Add(lblPossibleContacts);
			Controls.Add(lblRelatedContacts);
			Controls.Add(lblRelationship);
			Controls.Add(lblStatus);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			Location = new System.Drawing.Point(278, 230);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "frm_ContactRelationships";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			ShowInTaskbar = false;
			Text = "Contact - Relationships";
			commandButtonHelper1.SetStyle(cmdStop, 0);
			commandButtonHelper1.SetStyle(cmdDelete, 0);
			commandButtonHelper1.SetStyle(cmdAdd, 0);
			commandButtonHelper1.SetStyle(cmdRefresh, 0);
			ToolTipMain.SetToolTip(txtRelationship, "Enter the relationship wordage \"Also Known As\"");
			Activated += new System.EventHandler(frm_ContactRelationships_Activated);
			Closed += new System.EventHandler(Form_Closed);
			((System.ComponentModel.ISupportInitialize) mfgPossibleContacts).EndInit();
			((System.ComponentModel.ISupportInitialize) mfgRelatedContacts).EndInit();
			frmMainContact.ResumeLayout(false);
			frmMainContact.PerformLayout();
			frmSearch.ResumeLayout(false);
			frmSearch.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
		#endregion
	}
}