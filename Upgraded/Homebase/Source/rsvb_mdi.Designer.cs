
namespace JETNET_Homebase
{
	partial class mdi_ResearchAssistant
	{

		#region "Upgrade Support "
		private static mdi_ResearchAssistant m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static mdi_ResearchAssistant DefInstance
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
		public static mdi_ResearchAssistant CreateInstance()
		{
			mdi_ResearchAssistant theInstance = new mdi_ResearchAssistant();
			theInstance.MDIForm_Load();
			return theInstance;
		}
		private string[] visualControls = new string[]{"components", "ToolTipMain", "mnuFileExit", "mnuFile", "MainMenu1", "Inet1", "MouseTimer", "CommonDialog1", "prg_Progress_Bar", "lbl_test_omg", "lbl_WhichDatabase", "pnlStatusBar", "imgNormal"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.ToolStripMenuItem mnuFileExit;
		public System.Windows.Forms.ToolStripMenuItem mnuFile;
		public System.Windows.Forms.MenuStrip MainMenu1;
		public dynamic Inet1; //gap-note this control must be defined during Blazor stabilization
		public System.Windows.Forms.Timer MouseTimer;
		public System.Windows.Forms.OpenFileDialog CommonDialog1Open;
		public System.Windows.Forms.SaveFileDialog CommonDialog1Save;
		public System.Windows.Forms.FontDialog CommonDialog1Font;
		public System.Windows.Forms.ColorDialog CommonDialog1Color;
		public System.Windows.Forms.PrintDialog CommonDialog1Print;
		public UpgradeStubs.AxMSComDlg_AxCommonDialog CommonDialog1;
		public System.Windows.Forms.ProgressBar prg_Progress_Bar;
		public System.Windows.Forms.Label lbl_test_omg;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mdi_ResearchAssistant));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			MainMenu1 = new System.Windows.Forms.MenuStrip();
			mnuFile = new System.Windows.Forms.ToolStripMenuItem();
			mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
			//Inet1 = new AxInetCtlsObjects.AxInet(); //gap-note this control must be defined during Blazor stabilization
			MouseTimer = new System.Windows.Forms.Timer(components);
			CommonDialog1Open = new System.Windows.Forms.OpenFileDialog();
			CommonDialog1Save = new System.Windows.Forms.SaveFileDialog();
			CommonDialog1Font = new System.Windows.Forms.FontDialog();
			CommonDialog1Color = new System.Windows.Forms.ColorDialog();
			CommonDialog1Print = new System.Windows.Forms.PrintDialog();
			CommonDialog1 = new UpgradeStubs.AxMSComDlg_AxCommonDialog();
			pnlStatusBar = new System.Windows.Forms.Panel();
			prg_Progress_Bar = new System.Windows.Forms.ProgressBar();
			lbl_test_omg = new System.Windows.Forms.Label();
			lbl_WhichDatabase = new System.Windows.Forms.Label();
			imgNormal = new System.Windows.Forms.ImageList();
			((System.ComponentModel.ISupportInitialize) Inet1).BeginInit();
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
			// Inet1
			// 
			Inet1.AllowDrop = true;
			Inet1.Location = new System.Drawing.Point(180, 38);
			Inet1.Name = "Inet1";
			Inet1.OcxState = (System.Windows.Forms.AxHost.State) resources.GetObject("Inet1.OcxState");
			// 
			// MouseTimer
			// 
			MouseTimer.Enabled = false;
			MouseTimer.Interval = 60000;
			MouseTimer.Tick += new System.EventHandler(MouseTimer_Tick);
			// 
			// pnlStatusBar
			// 
			pnlStatusBar.AllowDrop = true;
			pnlStatusBar.BackColor = System.Drawing.Color.Silver;
			pnlStatusBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnlStatusBar.Controls.Add(prg_Progress_Bar);
			pnlStatusBar.Controls.Add(lbl_test_omg);
			pnlStatusBar.Controls.Add(lbl_WhichDatabase);
			pnlStatusBar.Dock = System.Windows.Forms.DockStyle.Bottom;
			pnlStatusBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.26f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnlStatusBar.Location = new System.Drawing.Point(0, 725);
			pnlStatusBar.Name = "pnlStatusBar";
			pnlStatusBar.Size = new System.Drawing.Size(1031, 21);
			pnlStatusBar.TabIndex = 0;
			// 
			// prg_Progress_Bar
			// 
			prg_Progress_Bar.AllowDrop = true;
			prg_Progress_Bar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			prg_Progress_Bar.Location = new System.Drawing.Point(504, 3);
			prg_Progress_Bar.Name = "prg_Progress_Bar";
			prg_Progress_Bar.Size = new System.Drawing.Size(269, 15);
			prg_Progress_Bar.TabIndex = 1;
			prg_Progress_Bar.Visible = false;
			// 
			// lbl_test_omg
			// 
			lbl_test_omg.AllowDrop = true;
			lbl_test_omg.BackColor = System.Drawing.Color.Aqua;
			lbl_test_omg.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_test_omg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_test_omg.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_test_omg.Location = new System.Drawing.Point(352, 1);
			lbl_test_omg.MinimumSize = new System.Drawing.Size(141, 16);
			lbl_test_omg.Name = "lbl_test_omg";
			lbl_test_omg.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_test_omg.Size = new System.Drawing.Size(141, 16);
			lbl_test_omg.TabIndex = 3;
			lbl_test_omg.Text = "--- YOU ARE ON TEST ---";
			lbl_test_omg.Visible = false;
			// 
			// lbl_WhichDatabase
			// 
			lbl_WhichDatabase.AllowDrop = true;
			lbl_WhichDatabase.AutoSize = true;
			lbl_WhichDatabase.BackColor = System.Drawing.Color.Transparent;
			lbl_WhichDatabase.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_WhichDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_WhichDatabase.ForeColor = System.Drawing.Color.Maroon;
			lbl_WhichDatabase.Location = new System.Drawing.Point(785, 1);
			lbl_WhichDatabase.MinimumSize = new System.Drawing.Size(213, 16);
			lbl_WhichDatabase.Name = "lbl_WhichDatabase";
			lbl_WhichDatabase.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_WhichDatabase.Size = new System.Drawing.Size(213, 16);
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
			imgNormal.Images.SetKeyName(4, "Delete");
			// 
			// mdi_ResearchAssistant
			// 
			AllowDrop = true;
			BackColor = System.Drawing.Color.White;
			ClientSize = new System.Drawing.Size(1031, 746);
			Controls.Add(Inet1);
			Controls.Add(pnlStatusBar);
			Controls.Add(MainMenu1);
			Enabled = true;
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Icon = (System.Drawing.Icon) resources.GetObject("mdi_ResearchAssistant.Icon");
			IsMdiContainer = true;
			Location = new System.Drawing.Point(542, 224);
			Name = "mdi_ResearchAssistant";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			Text = "JETNET Homebase";
			WindowState = System.Windows.Forms.FormWindowState.Normal;
			Activated += new System.EventHandler(MDIForm_Activated);
			Closed += new System.EventHandler(MDIForm_Closed);
			FormClosing += new System.Windows.Forms.FormClosingEventHandler(MDIForm_FormClosing);
			((System.ComponentModel.ISupportInitialize) Inet1).EndInit();
			pnlStatusBar.ResumeLayout(false);
			pnlStatusBar.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
		#endregion
	}
}