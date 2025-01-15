
namespace JETNET_Homebase
{
	partial class frm_OpenDocument
	{

		#region "Upgrade Support "
		private static frm_OpenDocument m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_OpenDocument DefInstance
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
		public static frm_OpenDocument CreateInstance()
		{
			frm_OpenDocument theInstance = new frm_OpenDocument();
			theInstance.Form_Load();
			return theInstance;
		}
		private string[] visualControls = new string[]{"components", "ToolTipMain", "wbOpenDocument", "txtDocGeneralNote", "_lbl_gen_0", "_lbl_gen_94", "frmDocInfo", "lbl_gen"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.WebBrowser wbOpenDocument;
		public System.Windows.Forms.TextBox txtDocGeneralNote;
		private System.Windows.Forms.Label _lbl_gen_0;
		private System.Windows.Forms.Label _lbl_gen_94;
		public System.Windows.Forms.GroupBox frmDocInfo;
		public System.Windows.Forms.Label[] lbl_gen = new System.Windows.Forms.Label[95];
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_OpenDocument));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			wbOpenDocument = new System.Windows.Forms.WebBrowser();
			frmDocInfo = new System.Windows.Forms.GroupBox();
			txtDocGeneralNote = new System.Windows.Forms.TextBox();
			_lbl_gen_0 = new System.Windows.Forms.Label();
			_lbl_gen_94 = new System.Windows.Forms.Label();
			frmDocInfo.SuspendLayout();
			SuspendLayout();
			// 
			// wbOpenDocument
			// 
			wbOpenDocument.AllowWebBrowserDrop = true;
			wbOpenDocument.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			wbOpenDocument.Location = new System.Drawing.Point(10, 136);
			wbOpenDocument.Name = "wbOpenDocument";
			wbOpenDocument.Size = new System.Drawing.Size(997, 583);
			wbOpenDocument.TabIndex = 1;
			// 
			// frmDocInfo
			// 
			frmDocInfo.AllowDrop = true;
			frmDocInfo.BackColor = System.Drawing.SystemColors.Control;
			frmDocInfo.Controls.Add(txtDocGeneralNote);
			frmDocInfo.Controls.Add(_lbl_gen_0);
			frmDocInfo.Controls.Add(_lbl_gen_94);
			frmDocInfo.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmDocInfo.Enabled = true;
			frmDocInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmDocInfo.ForeColor = System.Drawing.SystemColors.ControlText;
			frmDocInfo.Location = new System.Drawing.Point(10, 4);
			frmDocInfo.Name = "frmDocInfo";
			frmDocInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmDocInfo.Size = new System.Drawing.Size(999, 129);
			frmDocInfo.TabIndex = 0;
			frmDocInfo.Text = "Document Information";
			frmDocInfo.Visible = true;
			// 
			// txtDocGeneralNote
			// 
			txtDocGeneralNote.AcceptsReturn = true;
			txtDocGeneralNote.AllowDrop = true;
			txtDocGeneralNote.BackColor = System.Drawing.SystemColors.Window;
			txtDocGeneralNote.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtDocGeneralNote.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtDocGeneralNote.Enabled = false;
			txtDocGeneralNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtDocGeneralNote.ForeColor = System.Drawing.SystemColors.WindowText;
			txtDocGeneralNote.Location = new System.Drawing.Point(88, 22);
			txtDocGeneralNote.MaxLength = 0;
			txtDocGeneralNote.Multiline = true;
			txtDocGeneralNote.Name = "txtDocGeneralNote";
			txtDocGeneralNote.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtDocGeneralNote.Size = new System.Drawing.Size(891, 73);
			txtDocGeneralNote.TabIndex = 3;
			// 
			// _lbl_gen_0
			// 
			_lbl_gen_0.AllowDrop = true;
			_lbl_gen_0.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_0.Location = new System.Drawing.Point(8, 104);
			_lbl_gen_0.MinimumSize = new System.Drawing.Size(970, 19);
			_lbl_gen_0.Name = "_lbl_gen_0";
			_lbl_gen_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_0.Size = new System.Drawing.Size(970, 19);
			_lbl_gen_0.TabIndex = 4;
			_lbl_gen_0.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// _lbl_gen_94
			// 
			_lbl_gen_94.AllowDrop = true;
			_lbl_gen_94.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_94.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_94.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_94.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_94.Location = new System.Drawing.Point(12, 23);
			_lbl_gen_94.MinimumSize = new System.Drawing.Size(64, 19);
			_lbl_gen_94.Name = "_lbl_gen_94";
			_lbl_gen_94.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_94.Size = new System.Drawing.Size(64, 19);
			_lbl_gen_94.TabIndex = 2;
			_lbl_gen_94.Text = "General Note";
			// 
			// frm_OpenDocument
			// 
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			ClientSize = new System.Drawing.Size(1016, 712);
			Controls.Add(wbOpenDocument);
			Controls.Add(frmDocInfo);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Location = new System.Drawing.Point(446, 196);
			MaximizeBox = true;
			MinimizeBox = true;
			Name = "frm_OpenDocument";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			Text = "Open Document";
			Activated += new System.EventHandler(Form_Activated);
			Closed += new System.EventHandler(Form_Closed);
			Resize += new System.EventHandler(Form_Resize);
			frmDocInfo.ResumeLayout(false);
			frmDocInfo.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
		void ReLoadForm(bool addEvents) => Initializelbl_gen();

		void Initializelbl_gen()
		{
			lbl_gen = new System.Windows.Forms.Label[95];
			lbl_gen[0] = _lbl_gen_0;
			lbl_gen[94] = _lbl_gen_94;
		}
		#endregion
	}
}