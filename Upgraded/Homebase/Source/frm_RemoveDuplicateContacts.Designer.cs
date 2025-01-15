
namespace JETNET_Homebase
{
	partial class frm_RemoveDuplicateContacts
	{

		#region "Upgrade Support "
		private static frm_RemoveDuplicateContacts m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_RemoveDuplicateContacts DefInstance
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
		public static frm_RemoveDuplicateContacts CreateInstance()
		{
			frm_RemoveDuplicateContacts theInstance = new frm_RemoveDuplicateContacts();
			theInstance.Form_Load();
			return theInstance;
		}
		private string[] visualControls = new string[]{"components", "ToolTipMain", "cmdClose", "cmdRemoveDups", "lstOtherContacts", "lstContact", "lblMsg2", "lblMessage", "listBoxHelper1", "commandButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.Button cmdClose;
		public System.Windows.Forms.Button cmdRemoveDups;
		public System.Windows.Forms.ListBox lstOtherContacts;
		public System.Windows.Forms.ListBox lstContact;
		public System.Windows.Forms.Label lblMsg2;
		public System.Windows.Forms.Label lblMessage;
		public UpgradeHelpers.Gui.Controls.ListBoxHelper listBoxHelper1;
		public UpgradeHelpers.Gui.Controls.CommandButtonHelper commandButtonHelper1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_RemoveDuplicateContacts));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			cmdClose = new System.Windows.Forms.Button();
			cmdRemoveDups = new System.Windows.Forms.Button();
			lstOtherContacts = new System.Windows.Forms.ListBox();
			lstContact = new System.Windows.Forms.ListBox();
			lblMsg2 = new System.Windows.Forms.Label();
			lblMessage = new System.Windows.Forms.Label();
			SuspendLayout();
			listBoxHelper1 = new UpgradeHelpers.Gui.Controls.ListBoxHelper(components);
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
			// 
			// cmdClose
			// 
			cmdClose.AllowDrop = true;
			cmdClose.BackColor = System.Drawing.SystemColors.Control;
			cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdClose.Location = new System.Drawing.Point(601, 205);
			cmdClose.Name = "cmdClose";
			cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdClose.Size = new System.Drawing.Size(73, 24);
			cmdClose.TabIndex = 3;
			cmdClose.Text = "Close";
			cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdClose.UseVisualStyleBackColor = false;
			cmdClose.Click += new System.EventHandler(cmdClose_Click);
			// 
			// cmdRemoveDups
			// 
			cmdRemoveDups.AllowDrop = true;
			cmdRemoveDups.BackColor = System.Drawing.SystemColors.Control;
			cmdRemoveDups.Enabled = false;
			cmdRemoveDups.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdRemoveDups.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdRemoveDups.Location = new System.Drawing.Point(349, 170);
			cmdRemoveDups.Name = "cmdRemoveDups";
			cmdRemoveDups.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdRemoveDups.Size = new System.Drawing.Size(86, 24);
			cmdRemoveDups.TabIndex = 2;
			cmdRemoveDups.Text = "Remove";
			cmdRemoveDups.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdRemoveDups.Click += new System.EventHandler(cmdRemoveDups_Click);
			// 
			// lstOtherContacts
			// 
			lstOtherContacts.AllowDrop = true;
			lstOtherContacts.BackColor = System.Drawing.SystemColors.Window;
			lstOtherContacts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			lstOtherContacts.CausesValidation = true;
			lstOtherContacts.Enabled = true;
			lstOtherContacts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lstOtherContacts.ForeColor = System.Drawing.SystemColors.WindowText;
			lstOtherContacts.IntegralHeight = true;
			lstOtherContacts.Location = new System.Drawing.Point(460, 13);
			lstOtherContacts.MultiColumn = false;
			lstOtherContacts.Name = "lstOtherContacts";
			lstOtherContacts.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lstOtherContacts.Size = new System.Drawing.Size(226, 176);
			lstOtherContacts.Sorted = false;
			lstOtherContacts.TabIndex = 1;
			lstOtherContacts.TabStop = true;
			lstOtherContacts.Visible = true;
			lstOtherContacts.SelectedIndexChanged += new System.EventHandler(lstOtherContacts_SelectedIndexChanged);
			// 
			// lstContact
			// 
			lstContact.AllowDrop = true;
			lstContact.BackColor = System.Drawing.SystemColors.Window;
			lstContact.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			lstContact.CausesValidation = true;
			lstContact.Enabled = true;
			lstContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lstContact.ForeColor = System.Drawing.SystemColors.WindowText;
			lstContact.IntegralHeight = true;
			lstContact.Location = new System.Drawing.Point(4, 13);
			lstContact.MultiColumn = false;
			lstContact.Name = "lstContact";
			lstContact.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lstContact.Size = new System.Drawing.Size(323, 176);
			lstContact.Sorted = false;
			lstContact.TabIndex = 0;
			lstContact.TabStop = true;
			lstContact.Visible = true;
			// 
			// lblMsg2
			// 
			lblMsg2.AllowDrop = true;
			lblMsg2.BackColor = System.Drawing.SystemColors.Control;
			lblMsg2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblMsg2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblMsg2.ForeColor = System.Drawing.SystemColors.ControlText;
			lblMsg2.Location = new System.Drawing.Point(334, 69);
			lblMsg2.MinimumSize = new System.Drawing.Size(120, 97);
			lblMsg2.Name = "lblMsg2";
			lblMsg2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblMsg2.Size = new System.Drawing.Size(120, 97);
			lblMsg2.TabIndex = 5;
			lblMsg2.Text = "The contact on the right will be removed and all of the associated information (phone numbers, etc...) will be moved to the contact on the left.";
			// 
			// lblMessage
			// 
			lblMessage.AllowDrop = true;
			lblMessage.BackColor = System.Drawing.SystemColors.Control;
			lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblMessage.ForeColor = System.Drawing.SystemColors.ControlText;
			lblMessage.Location = new System.Drawing.Point(334, 16);
			lblMessage.MinimumSize = new System.Drawing.Size(120, 47);
			lblMessage.Name = "lblMessage";
			lblMessage.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblMessage.Size = new System.Drawing.Size(120, 47);
			lblMessage.TabIndex = 4;
			lblMessage.Text = "Select the contact on the right that is a duplicate of the one on the left.";
			// 
			// frm_RemoveDuplicateContacts
			// 
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			CancelButton = cmdClose;
			ClientSize = new System.Drawing.Size(691, 233);
			Controls.Add(cmdClose);
			Controls.Add(cmdRemoveDups);
			Controls.Add(lstOtherContacts);
			Controls.Add(lstContact);
			Controls.Add(lblMsg2);
			Controls.Add(lblMessage);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Location = new System.Drawing.Point(36, 48);
			MaximizeBox = true;
			MinimizeBox = true;
			Name = "frm_RemoveDuplicateContacts";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			Text = "Remove Duplicate Contacts";
			commandButtonHelper1.SetStyle(cmdClose, 0);
			commandButtonHelper1.SetStyle(cmdRemoveDups, 0);
			listBoxHelper1.SetSelectionMode(lstOtherContacts, System.Windows.Forms.SelectionMode.One);
			listBoxHelper1.SetSelectionMode(lstContact, System.Windows.Forms.SelectionMode.One);
			Activated += new System.EventHandler(frm_RemoveDuplicateContacts_Activated);
			Closed += new System.EventHandler(Form_Closed);
			ResumeLayout(false);
			PerformLayout();
		}
		#endregion
	}
}