
namespace JETNET_Homebase
{
	partial class frm_EngineModel
	{

		#region "Upgrade Support "
		private static frm_EngineModel m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_EngineModel DefInstance
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
		public static frm_EngineModel CreateInstance()
		{
			frm_EngineModel theInstance = new frm_EngineModel();
			theInstance.Form_Load();
			return theInstance;
		}
		private string[] visualControls = new string[]{"components", "ToolTipMain", "cmdSelect", "cmdCancel", "cmdEngineModelsRefresh", "txtSearchEngineModelName", "grdEngineModels", "lblEngineModelsStop", "lblSearchEngineModelName", "lblLoading", "commandButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Button cmdSelect;
		public System.Windows.Forms.Button cmdCancel;
		public System.Windows.Forms.Button cmdEngineModelsRefresh;
		public System.Windows.Forms.TextBox txtSearchEngineModelName;
		public UpgradeHelpers.DataGridViewFlex grdEngineModels;
		public System.Windows.Forms.Label lblEngineModelsStop;
		public System.Windows.Forms.Label lblSearchEngineModelName;
		public System.Windows.Forms.Label lblLoading;
		public UpgradeHelpers.Gui.Controls.CommandButtonHelper commandButtonHelper1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_EngineModel));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			cmdSelect = new System.Windows.Forms.Button();
			cmdCancel = new System.Windows.Forms.Button();
			cmdEngineModelsRefresh = new System.Windows.Forms.Button();
			txtSearchEngineModelName = new System.Windows.Forms.TextBox();
			grdEngineModels = new UpgradeHelpers.DataGridViewFlex(components);
			lblEngineModelsStop = new System.Windows.Forms.Label();
			lblSearchEngineModelName = new System.Windows.Forms.Label();
			lblLoading = new System.Windows.Forms.Label();
			SuspendLayout();
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
			((System.ComponentModel.ISupportInitialize) grdEngineModels).BeginInit();
			// 
			// cmdSelect
			// 
			cmdSelect.AllowDrop = true;
			cmdSelect.BackColor = System.Drawing.SystemColors.Control;
			cmdSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdSelect.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdSelect.Location = new System.Drawing.Point(500, 306);
			cmdSelect.Name = "cmdSelect";
			cmdSelect.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdSelect.Size = new System.Drawing.Size(81, 25);
			cmdSelect.TabIndex = 7;
			cmdSelect.Text = "&Select";
			cmdSelect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdSelect.UseVisualStyleBackColor = false;
			cmdSelect.Click += new System.EventHandler(cmdSelect_Click);
			// 
			// cmdCancel
			// 
			cmdCancel.AllowDrop = true;
			cmdCancel.BackColor = System.Drawing.SystemColors.Control;
			cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdCancel.Location = new System.Drawing.Point(350, 306);
			cmdCancel.Name = "cmdCancel";
			cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdCancel.Size = new System.Drawing.Size(81, 25);
			cmdCancel.TabIndex = 6;
			cmdCancel.Text = "&Cancel";
			cmdCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdCancel.UseVisualStyleBackColor = false;
			cmdCancel.Click += new System.EventHandler(cmdCancel_Click);
			// 
			// cmdEngineModelsRefresh
			// 
			cmdEngineModelsRefresh.AllowDrop = true;
			cmdEngineModelsRefresh.BackColor = System.Drawing.SystemColors.Control;
			cmdEngineModelsRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdEngineModelsRefresh.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdEngineModelsRefresh.Location = new System.Drawing.Point(778, 6);
			cmdEngineModelsRefresh.Name = "cmdEngineModelsRefresh";
			cmdEngineModelsRefresh.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdEngineModelsRefresh.Size = new System.Drawing.Size(81, 25);
			cmdEngineModelsRefresh.TabIndex = 1;
			cmdEngineModelsRefresh.Text = "&Refresh";
			cmdEngineModelsRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdEngineModelsRefresh.UseVisualStyleBackColor = false;
			cmdEngineModelsRefresh.Click += new System.EventHandler(cmdEngineModelsRefresh_Click);
			// 
			// txtSearchEngineModelName
			// 
			txtSearchEngineModelName.AcceptsReturn = true;
			txtSearchEngineModelName.AllowDrop = true;
			txtSearchEngineModelName.BackColor = System.Drawing.SystemColors.Window;
			txtSearchEngineModelName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtSearchEngineModelName.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtSearchEngineModelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtSearchEngineModelName.ForeColor = System.Drawing.SystemColors.WindowText;
			txtSearchEngineModelName.Location = new System.Drawing.Point(152, 6);
			txtSearchEngineModelName.MaxLength = 0;
			txtSearchEngineModelName.Name = "txtSearchEngineModelName";
			txtSearchEngineModelName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtSearchEngineModelName.Size = new System.Drawing.Size(233, 23);
			txtSearchEngineModelName.TabIndex = 0;
			txtSearchEngineModelName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtSearchEngineModelName_KeyPress);
			// 
			// grdEngineModels
			// 
			grdEngineModels.AllowDrop = true;
			grdEngineModels.AllowUserToAddRows = false;
			grdEngineModels.AllowUserToDeleteRows = false;
			grdEngineModels.AllowUserToResizeColumns = false;
			grdEngineModels.AllowUserToResizeRows = false;
			grdEngineModels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grdEngineModels.ColumnsCount = 2;
			grdEngineModels.FixedColumns = 1;
			grdEngineModels.FixedRows = 1;
			grdEngineModels.Location = new System.Drawing.Point(0, 36);
			grdEngineModels.Name = "grdEngineModels";
			grdEngineModels.ReadOnly = true;
			grdEngineModels.RowsCount = 2;
			grdEngineModels.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			grdEngineModels.ShowCellToolTips = false;
			grdEngineModels.Size = new System.Drawing.Size(867, 261);
			grdEngineModels.StandardTab = true;
			grdEngineModels.TabIndex = 2;
			grdEngineModels.Click += new System.EventHandler(grdEngineModels_Click);
			grdEngineModels.DoubleClick += new System.EventHandler(grdEngineModels_DoubleClick);
			// 
			// lblEngineModelsStop
			// 
			lblEngineModelsStop.AllowDrop = true;
			lblEngineModelsStop.BackColor = System.Drawing.SystemColors.Control;
			lblEngineModelsStop.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblEngineModelsStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblEngineModelsStop.ForeColor = System.Drawing.Color.Blue;
			lblEngineModelsStop.Location = new System.Drawing.Point(780, 308);
			lblEngineModelsStop.MinimumSize = new System.Drawing.Size(85, 17);
			lblEngineModelsStop.Name = "lblEngineModelsStop";
			lblEngineModelsStop.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblEngineModelsStop.Size = new System.Drawing.Size(85, 17);
			lblEngineModelsStop.TabIndex = 5;
			lblEngineModelsStop.Text = "Stop Loading";
			lblEngineModelsStop.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lblSearchEngineModelName
			// 
			lblSearchEngineModelName.AllowDrop = true;
			lblSearchEngineModelName.BackColor = System.Drawing.SystemColors.Control;
			lblSearchEngineModelName.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblSearchEngineModelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblSearchEngineModelName.ForeColor = System.Drawing.SystemColors.ControlText;
			lblSearchEngineModelName.Location = new System.Drawing.Point(2, 10);
			lblSearchEngineModelName.MinimumSize = new System.Drawing.Size(143, 15);
			lblSearchEngineModelName.Name = "lblSearchEngineModelName";
			lblSearchEngineModelName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblSearchEngineModelName.Size = new System.Drawing.Size(143, 15);
			lblSearchEngineModelName.TabIndex = 4;
			lblSearchEngineModelName.Text = "Search Engine Model Name";
			// 
			// lblLoading
			// 
			lblLoading.AllowDrop = true;
			lblLoading.BackColor = System.Drawing.SystemColors.Control;
			lblLoading.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblLoading.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblLoading.ForeColor = System.Drawing.SystemColors.ControlText;
			lblLoading.Location = new System.Drawing.Point(6, 308);
			lblLoading.MinimumSize = new System.Drawing.Size(253, 15);
			lblLoading.Name = "lblLoading";
			lblLoading.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblLoading.Size = new System.Drawing.Size(253, 15);
			lblLoading.TabIndex = 3;
			lblLoading.Text = "Loading ##,### of ##,### Records";
			// 
			// frm_EngineModel
			// 
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			ClientSize = new System.Drawing.Size(884, 344);
			Controls.Add(cmdSelect);
			Controls.Add(cmdCancel);
			Controls.Add(cmdEngineModelsRefresh);
			Controls.Add(txtSearchEngineModelName);
			Controls.Add(grdEngineModels);
			Controls.Add(lblEngineModelsStop);
			Controls.Add(lblSearchEngineModelName);
			Controls.Add(lblLoading);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Location = new System.Drawing.Point(646, 320);
			MaximizeBox = true;
			MinimizeBox = true;
			Name = "frm_EngineModel";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			Text = "Search Engine Model";
			commandButtonHelper1.SetStyle(cmdSelect, 0);
			commandButtonHelper1.SetStyle(cmdCancel, 0);
			commandButtonHelper1.SetStyle(cmdEngineModelsRefresh, 0);
			Activated += new System.EventHandler(frm_EngineModel_Activated);
			Closed += new System.EventHandler(Form_Closed);
			((System.ComponentModel.ISupportInitialize) grdEngineModels).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
		#endregion
	}
}