
namespace HomebaseAdministrator
{
	partial class mdi_AdminAssistant
	{

		#region "Upgrade Support "
		private static mdi_AdminAssistant m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static mdi_AdminAssistant DefInstance
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
		public static mdi_AdminAssistant CreateInstance()
		{
			mdi_AdminAssistant theInstance = new mdi_AdminAssistant();
			theInstance.MDIForm_Load();
			return theInstance;
		}
		private string[] visualControls = new string[]{"components", "ToolTipMain", "mnuFileExit", "mnuFile", "MainMenu1", "CommonDialog1", "prg_Progress_Bar", "lbl_WhichDatabase", "pnlStatusBar", "imgNormal"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.ToolStripMenuItem mnuFileExit;
		public System.Windows.Forms.ToolStripMenuItem mnuFile;
		public System.Windows.Forms.MenuStrip MainMenu1;
		public System.Windows.Forms.OpenFileDialog CommonDialog1Open;
		public System.Windows.Forms.SaveFileDialog CommonDialog1Save;
		public System.Windows.Forms.FontDialog CommonDialog1Font;
		public System.Windows.Forms.ColorDialog CommonDialog1Color;
		public System.Windows.Forms.PrintDialog CommonDialog1Print;
		public UpgradeStubs.AxMSComDlg_AxCommonDialog CommonDialog1;
		public System.Windows.Forms.ProgressBar prg_Progress_Bar;
		public System.Windows.Forms.Label lbl_WhichDatabase;
		public System.Windows.Forms.Panel pnlStatusBar;
		public System.Windows.Forms.ImageList imgNormal;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mdi_AdminAssistant));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			MainMenu1 = new System.Windows.Forms.MenuStrip();
			mnuFile = new System.Windows.Forms.ToolStripMenuItem();
			mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
			CommonDialog1Open = new System.Windows.Forms.OpenFileDialog();
			CommonDialog1Save = new System.Windows.Forms.SaveFileDialog();
			CommonDialog1Font = new System.Windows.Forms.FontDialog();
			CommonDialog1Color = new System.Windows.Forms.ColorDialog();
			CommonDialog1Print = new System.Windows.Forms.PrintDialog();
			CommonDialog1 = new UpgradeStubs.AxMSComDlg_AxCommonDialog();
			pnlStatusBar = new System.Windows.Forms.Panel();
			prg_Progress_Bar = new System.Windows.Forms.ProgressBar();
			lbl_WhichDatabase = new System.Windows.Forms.Label();
			imgNormal = new System.Windows.Forms.ImageList();
			pnlStatusBar.SuspendLayout();
			SuspendLayout();
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
			mnuFile.MergeAction = System.Windows.Forms.MergeAction.Remove;
			mnuFile.Name = "mnuFile";
			mnuFile.Text = "&File";
			mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]{mnuFileExit});
			// 
			// mnuFileExit
			// 
			mnuFileExit.Available = true;
			mnuFileExit.Checked = false;
			mnuFileExit.Enabled = true;
			mnuFileExit.Name = "mnuFileExit";
			mnuFileExit.Text = "&Exit";
			mnuFileExit.Click += new System.EventHandler(mnuFileExit_Click);
			// 
			// pnlStatusBar
			// 
			pnlStatusBar.AllowDrop = true;
			pnlStatusBar.BackColor = System.Drawing.Color.Silver;
			pnlStatusBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnlStatusBar.Controls.Add(prg_Progress_Bar);
			pnlStatusBar.Controls.Add(lbl_WhichDatabase);
			pnlStatusBar.Dock = System.Windows.Forms.DockStyle.Bottom;
			pnlStatusBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnlStatusBar.Location = new System.Drawing.Point(0, 742);
			pnlStatusBar.Name = "pnlStatusBar";
			pnlStatusBar.Size = new System.Drawing.Size(1086, 21);
			pnlStatusBar.TabIndex = 0;
			// 
			// prg_Progress_Bar
			// 
			prg_Progress_Bar.AllowDrop = true;
			prg_Progress_Bar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			prg_Progress_Bar.Location = new System.Drawing.Point(539, 4);
			prg_Progress_Bar.Name = "prg_Progress_Bar";
			prg_Progress_Bar.Size = new System.Drawing.Size(269, 13);
			prg_Progress_Bar.TabIndex = 1;
			prg_Progress_Bar.Visible = false;
			// 
			// lbl_WhichDatabase
			// 
			lbl_WhichDatabase.AllowDrop = true;
			lbl_WhichDatabase.AutoSize = true;
			lbl_WhichDatabase.BackColor = System.Drawing.Color.Transparent;
			lbl_WhichDatabase.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_WhichDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_WhichDatabase.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
			lbl_WhichDatabase.Location = new System.Drawing.Point(913, 2);
			lbl_WhichDatabase.MinimumSize = new System.Drawing.Size(85, 16);
			lbl_WhichDatabase.Name = "lbl_WhichDatabase";
			lbl_WhichDatabase.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_WhichDatabase.Size = new System.Drawing.Size(85, 16);
			lbl_WhichDatabase.TabIndex = 2;
			lbl_WhichDatabase.Text = "Live System";
			// 
			// imgNormal
			// 
			imgNormal.ImageSize = new System.Drawing.Size(16, 16);
			imgNormal.ImageStream = (System.Windows.Forms.ImageListStreamer) resources.GetObject("imgNormal.ImageStream");
			imgNormal.TransparentColor = System.Drawing.Color.Silver;
			imgNormal.Images.SetKeyName(0, "Save");
			imgNormal.Images.SetKeyName(1, "Home");
			imgNormal.Images.SetKeyName(2, "Back");
			imgNormal.Images.SetKeyName(3, "Help");
			// 
			// mdi_AdminAssistant
			// 
			AllowDrop = true;
			BackColor = System.Drawing.Color.White;
			ClientSize = new System.Drawing.Size(1086, 763);
			Controls.Add(pnlStatusBar);
			Controls.Add(MainMenu1);
			Enabled = true;
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Icon = (System.Drawing.Icon) resources.GetObject("mdi_AdminAssistant.Icon");
			IsMdiContainer = true;
			Location = new System.Drawing.Point(73, 136);
			Name = "mdi_AdminAssistant";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			Text = "JETNET Homebase Administrator";
			WindowState = System.Windows.Forms.FormWindowState.Normal;
			Activated += new System.EventHandler(MDIForm_Activated);
			Closed += new System.EventHandler(MDIForm_Closed);
			FormClosing += new System.Windows.Forms.FormClosingEventHandler(MDIForm_FormClosing);
			pnlStatusBar.ResumeLayout(false);
			pnlStatusBar.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
		#endregion
	}
}