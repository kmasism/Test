
namespace JETNET_Homebase
{
	partial class frm_EventsList
	{

		#region "Upgrade Support "
		private static frm_EventsList m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_EventsList DefInstance
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
		public static frm_EventsList CreateInstance()
		{
			frm_EventsList theInstance = new frm_EventsList();
			theInstance.Form_Load();
			//The MDI form in the VB6 project had its
			//AutoShowChildren property set to True
			//To simulate the VB6 behavior, we need to
			//automatically Show the form whenever it
			//is loaded.  If you do not want this behavior
			//then delete the following line of code
			//UPGRADE_TODO: (2018) Remove the next line of code to stop form from automatically showing. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-2018
			theInstance.Show();
			return theInstance;
		}
		private string[] visualControls = new string[]{"components", "ToolTipMain", "mnuClose", "mnuLogout", "mnuFile", "MainMenu1", "cmdClose", "cmdSave", "chkEdit", "grdEvents", "commandButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.ToolStripMenuItem mnuClose;
		public System.Windows.Forms.ToolStripMenuItem mnuLogout;
		public System.Windows.Forms.ToolStripMenuItem mnuFile;
		public System.Windows.Forms.MenuStrip MainMenu1;
		public System.Windows.Forms.Button cmdClose;
		public System.Windows.Forms.Button cmdSave;
		public System.Windows.Forms.CheckBox chkEdit;
		public UpgradeHelpers.DataGridViewFlex grdEvents;
		public UpgradeHelpers.Gui.Controls.CommandButtonHelper commandButtonHelper1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_EventsList));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			MainMenu1 = new System.Windows.Forms.MenuStrip();
			mnuFile = new System.Windows.Forms.ToolStripMenuItem();
			mnuClose = new System.Windows.Forms.ToolStripMenuItem();
			mnuLogout = new System.Windows.Forms.ToolStripMenuItem();
			cmdClose = new System.Windows.Forms.Button();
			cmdSave = new System.Windows.Forms.Button();
			chkEdit = new System.Windows.Forms.CheckBox();
			grdEvents = new UpgradeHelpers.DataGridViewFlex(components);
			SuspendLayout();
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
			((System.ComponentModel.ISupportInitialize) grdEvents).BeginInit();
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
			mnuFile.Text = "&File";
			mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]{mnuClose, mnuLogout});
			// 
			// mnuClose
			// 
			mnuClose.Available = true;
			mnuClose.Checked = false;
			mnuClose.Enabled = true;
			mnuClose.Name = "mnuClose";
			mnuClose.Text = "&Close";
			mnuClose.Click += new System.EventHandler(mnuClose_Click);
			// 
			// mnuLogout
			// 
			mnuLogout.Available = true;
			mnuLogout.Checked = false;
			mnuLogout.Enabled = true;
			mnuLogout.Name = "mnuLogout";
			mnuLogout.Text = "&Logout";
			mnuLogout.Click += new System.EventHandler(mnuLogout_Click);
			// 
			// cmdClose
			// 
			cmdClose.AllowDrop = true;
			cmdClose.BackColor = System.Drawing.SystemColors.Control;
			cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdClose.Location = new System.Drawing.Point(167, 454);
			cmdClose.Name = "cmdClose";
			cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdClose.Size = new System.Drawing.Size(74, 23);
			cmdClose.TabIndex = 3;
			cmdClose.Text = "&Close";
			cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdClose.UseVisualStyleBackColor = false;
			cmdClose.Click += new System.EventHandler(cmdClose_Click);
			// 
			// cmdSave
			// 
			cmdSave.AllowDrop = true;
			cmdSave.BackColor = System.Drawing.SystemColors.Control;
			cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdSave.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdSave.Location = new System.Drawing.Point(89, 456);
			cmdSave.Name = "cmdSave";
			cmdSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdSave.Size = new System.Drawing.Size(74, 23);
			cmdSave.TabIndex = 2;
			cmdSave.Text = "&Save";
			cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdSave.UseVisualStyleBackColor = false;
			cmdSave.Click += new System.EventHandler(cmdSave_Click);
			// 
			// chkEdit
			// 
			chkEdit.AllowDrop = true;
			chkEdit.Appearance = System.Windows.Forms.Appearance.Normal;
			chkEdit.BackColor = System.Drawing.Color.Yellow;
			chkEdit.CausesValidation = true;
			chkEdit.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			chkEdit.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkEdit.Enabled = true;
			chkEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkEdit.ForeColor = System.Drawing.SystemColors.WindowText;
			chkEdit.Location = new System.Drawing.Point(13, 72);
			chkEdit.Name = "chkEdit";
			chkEdit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkEdit.Size = new System.Drawing.Size(76, 21);
			chkEdit.TabIndex = 1;
			chkEdit.TabStop = true;
			chkEdit.Text = "Hide Event";
			chkEdit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkEdit.Visible = false;
			// 
			// grdEvents
			// 
			grdEvents.AllowDrop = true;
			grdEvents.AllowUserToAddRows = false;
			grdEvents.AllowUserToDeleteRows = false;
			grdEvents.AllowUserToResizeColumns = false;
			grdEvents.AllowUserToResizeColumns = grdEvents.ColumnHeadersVisible;
			grdEvents.AllowUserToResizeRows = false;
			grdEvents.AllowUserToResizeRows = false;
			grdEvents.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grdEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grdEvents.ColumnsCount = 2;
			grdEvents.FixedColumns = 0;
			grdEvents.FixedRows = 1;
			grdEvents.Location = new System.Drawing.Point(7, 32);
			grdEvents.Name = "grdEvents";
			grdEvents.ReadOnly = true;
			grdEvents.RowsCount = 2;
			grdEvents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			grdEvents.ShowCellToolTips = false;
			grdEvents.Size = new System.Drawing.Size(1003, 402);
			grdEvents.StandardTab = true;
			grdEvents.TabIndex = 0;
			grdEvents.Click += new System.EventHandler(grdEvents_Click);
			grdEvents.DoubleClick += new System.EventHandler(grdEvents_DoubleClick);
			// 
			// frm_EventsList
			// 
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			BackColor = System.Drawing.SystemColors.Control;
			ClientSize = new System.Drawing.Size(1016, 493);
			ControlBox = false;
			Controls.Add(cmdClose);
			Controls.Add(cmdSave);
			Controls.Add(chkEdit);
			Controls.Add(grdEvents);
			Controls.Add(MainMenu1);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Location = new System.Drawing.Point(4, 164);
			MaximizeBox = true;
			MinimizeBox = true;
			Name = "frm_EventsList";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			Text = "Evolution Events";
			WindowState = System.Windows.Forms.FormWindowState.Maximized;
			commandButtonHelper1.SetStyle(cmdClose, 0);
			commandButtonHelper1.SetStyle(cmdSave, 0);
			Activated += new System.EventHandler(frm_EventsList_Activated);
			Closed += new System.EventHandler(Form_Closed);
			((System.ComponentModel.ISupportInitialize) grdEvents).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
		void ReLoadForm(bool addEvents)
		{
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			MdiParent = JETNET_Homebase.mdi_ResearchAssistant.DefInstance;
			JETNET_Homebase.mdi_ResearchAssistant.DefInstance.Show();
		}
		#endregion
	}
}