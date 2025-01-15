
namespace JETNET_Homebase
{
	partial class frm_Subscription_EMail
	{

		#region "Upgrade Support "
		private static frm_Subscription_EMail m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_Subscription_EMail DefInstance
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
		public static frm_Subscription_EMail CreateInstance()
		{
			frm_Subscription_EMail theInstance = new frm_Subscription_EMail();
			return theInstance;
		}
		private string[] visualControls = new string[]{"components", "ToolTipMain", "optYachtSpot", "optEvoDotNet", "frmWebsite", "txtEMailAddressBCC", "txtEMailAddressCC", "optEMailAddlLoc", "optEMailDemo", "optEMailReSend", "optEMailNew", "frmEMail", "optStephanie", "optKarim", "optKen", "optPaul", "optGeneric", "optJason", "optTherese", "frmFrom", "txtEMailAddressTo", "txtEMailName", "cmdCancelEMail", "cmdSendEMail", "lstbContactName", "lblEMailAddressBCC", "lblEMailAddressCC", "lblNoContactsOnFile", "lblContactName", "Label1", "lblCompany", "lblCompanyData", "lblStatus", "lblServiceData", "lblService", "lblPasswordData", "lblLoginData", "lblSubIdData", "lblEMailAddressTo", "lblEMailName", "lblPassword", "lblLogin", "lblSubId", "listBoxHelper1", "commandButtonHelper1", "optionButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.RadioButton optYachtSpot;
		public System.Windows.Forms.RadioButton optEvoDotNet;
		public System.Windows.Forms.GroupBox frmWebsite;
		public System.Windows.Forms.TextBox txtEMailAddressBCC;
		public System.Windows.Forms.TextBox txtEMailAddressCC;
		public System.Windows.Forms.RadioButton optEMailAddlLoc;
		public System.Windows.Forms.RadioButton optEMailDemo;
		public System.Windows.Forms.RadioButton optEMailReSend;
		public System.Windows.Forms.RadioButton optEMailNew;
		public System.Windows.Forms.GroupBox frmEMail;
		public System.Windows.Forms.RadioButton optStephanie;
		public System.Windows.Forms.RadioButton optKarim;
		public System.Windows.Forms.RadioButton optKen;
		public System.Windows.Forms.RadioButton optPaul;
		public System.Windows.Forms.RadioButton optGeneric;
		public System.Windows.Forms.RadioButton optJason;
		public System.Windows.Forms.RadioButton optTherese;
		public System.Windows.Forms.GroupBox frmFrom;
		public System.Windows.Forms.TextBox txtEMailAddressTo;
		public System.Windows.Forms.TextBox txtEMailName;
		public System.Windows.Forms.Button cmdCancelEMail;
		public System.Windows.Forms.Button cmdSendEMail;
		public System.Windows.Forms.CheckedListBox lstbContactName;
		public System.Windows.Forms.Label lblEMailAddressBCC;
		public System.Windows.Forms.Label lblEMailAddressCC;
		public System.Windows.Forms.Label lblNoContactsOnFile;
		public System.Windows.Forms.Label lblContactName;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label lblCompany;
		public System.Windows.Forms.Label lblCompanyData;
		public System.Windows.Forms.Label lblStatus;
		public System.Windows.Forms.Label lblServiceData;
		public System.Windows.Forms.Label lblService;
		public System.Windows.Forms.Label lblPasswordData;
		public System.Windows.Forms.Label lblLoginData;
		public System.Windows.Forms.Label lblSubIdData;
		public System.Windows.Forms.Label lblEMailAddressTo;
		public System.Windows.Forms.Label lblEMailName;
		public System.Windows.Forms.Label lblPassword;
		public System.Windows.Forms.Label lblLogin;
		public System.Windows.Forms.Label lblSubId;
		public UpgradeHelpers.Gui.Controls.ListBoxHelper listBoxHelper1;
		public UpgradeHelpers.Gui.Controls.CommandButtonHelper commandButtonHelper1;
		public UpgradeHelpers.Gui.Controls.OptionButtonHelper optionButtonHelper1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Subscription_EMail));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			frmWebsite = new System.Windows.Forms.GroupBox();
			optYachtSpot = new System.Windows.Forms.RadioButton();
			optEvoDotNet = new System.Windows.Forms.RadioButton();
			txtEMailAddressBCC = new System.Windows.Forms.TextBox();
			txtEMailAddressCC = new System.Windows.Forms.TextBox();
			frmEMail = new System.Windows.Forms.GroupBox();
			optEMailAddlLoc = new System.Windows.Forms.RadioButton();
			optEMailDemo = new System.Windows.Forms.RadioButton();
			optEMailReSend = new System.Windows.Forms.RadioButton();
			optEMailNew = new System.Windows.Forms.RadioButton();
			frmFrom = new System.Windows.Forms.GroupBox();
			optStephanie = new System.Windows.Forms.RadioButton();
			optKarim = new System.Windows.Forms.RadioButton();
			optKen = new System.Windows.Forms.RadioButton();
			optPaul = new System.Windows.Forms.RadioButton();
			optGeneric = new System.Windows.Forms.RadioButton();
			optJason = new System.Windows.Forms.RadioButton();
			optTherese = new System.Windows.Forms.RadioButton();
			txtEMailAddressTo = new System.Windows.Forms.TextBox();
			txtEMailName = new System.Windows.Forms.TextBox();
			cmdCancelEMail = new System.Windows.Forms.Button();
			cmdSendEMail = new System.Windows.Forms.Button();
			lstbContactName = new System.Windows.Forms.CheckedListBox();
			lblEMailAddressBCC = new System.Windows.Forms.Label();
			lblEMailAddressCC = new System.Windows.Forms.Label();
			lblNoContactsOnFile = new System.Windows.Forms.Label();
			lblContactName = new System.Windows.Forms.Label();
			Label1 = new System.Windows.Forms.Label();
			lblCompany = new System.Windows.Forms.Label();
			lblCompanyData = new System.Windows.Forms.Label();
			lblStatus = new System.Windows.Forms.Label();
			lblServiceData = new System.Windows.Forms.Label();
			lblService = new System.Windows.Forms.Label();
			lblPasswordData = new System.Windows.Forms.Label();
			lblLoginData = new System.Windows.Forms.Label();
			lblSubIdData = new System.Windows.Forms.Label();
			lblEMailAddressTo = new System.Windows.Forms.Label();
			lblEMailName = new System.Windows.Forms.Label();
			lblPassword = new System.Windows.Forms.Label();
			lblLogin = new System.Windows.Forms.Label();
			lblSubId = new System.Windows.Forms.Label();
			frmWebsite.SuspendLayout();
			frmEMail.SuspendLayout();
			frmFrom.SuspendLayout();
			SuspendLayout();
			listBoxHelper1 = new UpgradeHelpers.Gui.Controls.ListBoxHelper(components);
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
			optionButtonHelper1 = new UpgradeHelpers.Gui.Controls.OptionButtonHelper(components);
			// 
			// frmWebsite
			// 
			frmWebsite.AllowDrop = true;
			frmWebsite.BackColor = System.Drawing.SystemColors.Control;
			frmWebsite.Controls.Add(optYachtSpot);
			frmWebsite.Controls.Add(optEvoDotNet);
			frmWebsite.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmWebsite.Enabled = true;
			frmWebsite.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmWebsite.ForeColor = System.Drawing.SystemColors.ControlText;
			frmWebsite.Location = new System.Drawing.Point(360, 184);
			frmWebsite.Name = "frmWebsite";
			frmWebsite.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmWebsite.Size = new System.Drawing.Size(97, 87);
			frmWebsite.TabIndex = 38;
			frmWebsite.Text = "Website";
			frmWebsite.Visible = true;
			// 
			// optYachtSpot
			// 
			optYachtSpot.AllowDrop = true;
			optYachtSpot.BackColor = System.Drawing.SystemColors.Control;
			optYachtSpot.CausesValidation = true;
			optYachtSpot.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			optYachtSpot.Checked = false;
			optYachtSpot.Enabled = true;
			optYachtSpot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			optYachtSpot.ForeColor = System.Drawing.SystemColors.ControlText;
			optYachtSpot.Location = new System.Drawing.Point(12, 40);
			optYachtSpot.Name = "optYachtSpot";
			optYachtSpot.RightToLeft = System.Windows.Forms.RightToLeft.No;
			optYachtSpot.Size = new System.Drawing.Size(75, 13);
			optYachtSpot.TabIndex = 40;
			optYachtSpot.TabStop = true;
			optYachtSpot.Text = "Yacht-Spot";
			optYachtSpot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			optYachtSpot.Visible = true;
			// 
			// optEvoDotNet
			// 
			optEvoDotNet.AllowDrop = true;
			optEvoDotNet.BackColor = System.Drawing.SystemColors.Control;
			optEvoDotNet.CausesValidation = true;
			optEvoDotNet.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			optEvoDotNet.Checked = true;
			optEvoDotNet.Enabled = true;
			optEvoDotNet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			optEvoDotNet.ForeColor = System.Drawing.SystemColors.ControlText;
			optEvoDotNet.Location = new System.Drawing.Point(12, 20);
			optEvoDotNet.Name = "optEvoDotNet";
			optEvoDotNet.RightToLeft = System.Windows.Forms.RightToLeft.No;
			optEvoDotNet.Size = new System.Drawing.Size(61, 13);
			optEvoDotNet.TabIndex = 39;
			optEvoDotNet.TabStop = true;
			optEvoDotNet.Text = "Evo.Net";
			optEvoDotNet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			optEvoDotNet.Visible = true;
			// 
			// txtEMailAddressBCC
			// 
			txtEMailAddressBCC.AcceptsReturn = true;
			txtEMailAddressBCC.AllowDrop = true;
			txtEMailAddressBCC.BackColor = System.Drawing.SystemColors.Window;
			txtEMailAddressBCC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtEMailAddressBCC.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtEMailAddressBCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtEMailAddressBCC.ForeColor = System.Drawing.SystemColors.WindowText;
			txtEMailAddressBCC.Location = new System.Drawing.Point(96, 369);
			txtEMailAddressBCC.MaxLength = 0;
			txtEMailAddressBCC.Name = "txtEMailAddressBCC";
			txtEMailAddressBCC.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtEMailAddressBCC.Size = new System.Drawing.Size(340, 21);
			txtEMailAddressBCC.TabIndex = 22;
			// 
			// txtEMailAddressCC
			// 
			txtEMailAddressCC.AcceptsReturn = true;
			txtEMailAddressCC.AllowDrop = true;
			txtEMailAddressCC.BackColor = System.Drawing.SystemColors.Window;
			txtEMailAddressCC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtEMailAddressCC.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtEMailAddressCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtEMailAddressCC.ForeColor = System.Drawing.SystemColors.WindowText;
			txtEMailAddressCC.Location = new System.Drawing.Point(96, 345);
			txtEMailAddressCC.MaxLength = 0;
			txtEMailAddressCC.Name = "txtEMailAddressCC";
			txtEMailAddressCC.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtEMailAddressCC.Size = new System.Drawing.Size(340, 21);
			txtEMailAddressCC.TabIndex = 21;
			// 
			// frmEMail
			// 
			frmEMail.AllowDrop = true;
			frmEMail.BackColor = System.Drawing.SystemColors.Control;
			frmEMail.Controls.Add(optEMailAddlLoc);
			frmEMail.Controls.Add(optEMailDemo);
			frmEMail.Controls.Add(optEMailReSend);
			frmEMail.Controls.Add(optEMailNew);
			frmEMail.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmEMail.Enabled = true;
			frmEMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmEMail.ForeColor = System.Drawing.SystemColors.ControlText;
			frmEMail.Location = new System.Drawing.Point(208, 9);
			frmEMail.Name = "frmEMail";
			frmEMail.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmEMail.Size = new System.Drawing.Size(145, 103);
			frmEMail.TabIndex = 25;
			frmEMail.Text = "EMail";
			frmEMail.Visible = true;
			// 
			// optEMailAddlLoc
			// 
			optEMailAddlLoc.AllowDrop = true;
			optEMailAddlLoc.BackColor = System.Drawing.SystemColors.Control;
			optEMailAddlLoc.CausesValidation = true;
			optEMailAddlLoc.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			optEMailAddlLoc.Checked = false;
			optEMailAddlLoc.Enabled = true;
			optEMailAddlLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			optEMailAddlLoc.ForeColor = System.Drawing.SystemColors.ControlText;
			optEMailAddlLoc.Location = new System.Drawing.Point(8, 80);
			optEMailAddlLoc.Name = "optEMailAddlLoc";
			optEMailAddlLoc.RightToLeft = System.Windows.Forms.RightToLeft.No;
			optEMailAddlLoc.Size = new System.Drawing.Size(95, 13);
			optEMailAddlLoc.TabIndex = 7;
			optEMailAddlLoc.TabStop = true;
			optEMailAddlLoc.Text = "Add'l Location";
			optEMailAddlLoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			optEMailAddlLoc.Visible = true;
			// 
			// optEMailDemo
			// 
			optEMailDemo.AllowDrop = true;
			optEMailDemo.BackColor = System.Drawing.SystemColors.Control;
			optEMailDemo.CausesValidation = true;
			optEMailDemo.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			optEMailDemo.Checked = false;
			optEMailDemo.Enabled = true;
			optEMailDemo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			optEMailDemo.ForeColor = System.Drawing.SystemColors.ControlText;
			optEMailDemo.Location = new System.Drawing.Point(8, 60);
			optEMailDemo.Name = "optEMailDemo";
			optEMailDemo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			optEMailDemo.Size = new System.Drawing.Size(117, 13);
			optEMailDemo.TabIndex = 6;
			optEMailDemo.TabStop = true;
			optEMailDemo.Text = "Demo Account";
			optEMailDemo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			optEMailDemo.Visible = true;
			// 
			// optEMailReSend
			// 
			optEMailReSend.AllowDrop = true;
			optEMailReSend.BackColor = System.Drawing.SystemColors.Control;
			optEMailReSend.CausesValidation = true;
			optEMailReSend.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			optEMailReSend.Checked = false;
			optEMailReSend.Enabled = true;
			optEMailReSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			optEMailReSend.ForeColor = System.Drawing.SystemColors.ControlText;
			optEMailReSend.Location = new System.Drawing.Point(8, 40);
			optEMailReSend.Name = "optEMailReSend";
			optEMailReSend.RightToLeft = System.Windows.Forms.RightToLeft.No;
			optEMailReSend.Size = new System.Drawing.Size(125, 13);
			optEMailReSend.TabIndex = 5;
			optEMailReSend.TabStop = true;
			optEMailReSend.Text = "Resend License Info";
			optEMailReSend.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			optEMailReSend.Visible = true;
			// 
			// optEMailNew
			// 
			optEMailNew.AllowDrop = true;
			optEMailNew.BackColor = System.Drawing.SystemColors.Control;
			optEMailNew.CausesValidation = true;
			optEMailNew.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			optEMailNew.Checked = true;
			optEMailNew.Enabled = true;
			optEMailNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			optEMailNew.ForeColor = System.Drawing.SystemColors.ControlText;
			optEMailNew.Location = new System.Drawing.Point(8, 20);
			optEMailNew.Name = "optEMailNew";
			optEMailNew.RightToLeft = System.Windows.Forms.RightToLeft.No;
			optEMailNew.Size = new System.Drawing.Size(121, 13);
			optEMailNew.TabIndex = 4;
			optEMailNew.TabStop = true;
			optEMailNew.Text = "New Subscriber";
			optEMailNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			optEMailNew.Visible = true;
			// 
			// frmFrom
			// 
			frmFrom.AllowDrop = true;
			frmFrom.BackColor = System.Drawing.SystemColors.Control;
			frmFrom.Controls.Add(optStephanie);
			frmFrom.Controls.Add(optKarim);
			frmFrom.Controls.Add(optKen);
			frmFrom.Controls.Add(optPaul);
			frmFrom.Controls.Add(optGeneric);
			frmFrom.Controls.Add(optJason);
			frmFrom.Controls.Add(optTherese);
			frmFrom.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmFrom.Enabled = true;
			frmFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmFrom.ForeColor = System.Drawing.SystemColors.ControlText;
			frmFrom.Location = new System.Drawing.Point(360, 9);
			frmFrom.Name = "frmFrom";
			frmFrom.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmFrom.Size = new System.Drawing.Size(97, 165);
			frmFrom.TabIndex = 30;
			frmFrom.Text = "From";
			frmFrom.Visible = true;
			// 
			// optStephanie
			// 
			optStephanie.AllowDrop = true;
			optStephanie.BackColor = System.Drawing.SystemColors.Control;
			optStephanie.CausesValidation = true;
			optStephanie.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			optStephanie.Checked = false;
			optStephanie.Enabled = true;
			optStephanie.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			optStephanie.ForeColor = System.Drawing.SystemColors.ControlText;
			optStephanie.Location = new System.Drawing.Point(10, 90);
			optStephanie.Name = "optStephanie";
			optStephanie.RightToLeft = System.Windows.Forms.RightToLeft.No;
			optStephanie.Size = new System.Drawing.Size(73, 13);
			optStephanie.TabIndex = 13;
			optStephanie.TabStop = true;
			optStephanie.Text = "Stephanie";
			optStephanie.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			optStephanie.Visible = true;
			// 
			// optKarim
			// 
			optKarim.AllowDrop = true;
			optKarim.BackColor = System.Drawing.SystemColors.Control;
			optKarim.CausesValidation = true;
			optKarim.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			optKarim.Checked = false;
			optKarim.Enabled = true;
			optKarim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			optKarim.ForeColor = System.Drawing.SystemColors.ControlText;
			optKarim.Location = new System.Drawing.Point(10, 73);
			optKarim.Name = "optKarim";
			optKarim.RightToLeft = System.Windows.Forms.RightToLeft.No;
			optKarim.Size = new System.Drawing.Size(65, 13);
			optKarim.TabIndex = 12;
			optKarim.TabStop = true;
			optKarim.Text = "Karim";
			optKarim.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			optKarim.Visible = true;
			// 
			// optKen
			// 
			optKen.AllowDrop = true;
			optKen.BackColor = System.Drawing.SystemColors.Control;
			optKen.CausesValidation = true;
			optKen.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			optKen.Checked = false;
			optKen.Enabled = true;
			optKen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			optKen.ForeColor = System.Drawing.SystemColors.ControlText;
			optKen.Location = new System.Drawing.Point(10, 145);
			optKen.Name = "optKen";
			optKen.RightToLeft = System.Windows.Forms.RightToLeft.No;
			optKen.Size = new System.Drawing.Size(65, 13);
			optKen.TabIndex = 11;
			optKen.TabStop = true;
			optKen.Text = "Ken";
			optKen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			optKen.Visible = false;
			// 
			// optPaul
			// 
			optPaul.AllowDrop = true;
			optPaul.BackColor = System.Drawing.SystemColors.Control;
			optPaul.CausesValidation = true;
			optPaul.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			optPaul.Checked = false;
			optPaul.Enabled = true;
			optPaul.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			optPaul.ForeColor = System.Drawing.SystemColors.ControlText;
			optPaul.Location = new System.Drawing.Point(10, 57);
			optPaul.Name = "optPaul";
			optPaul.RightToLeft = System.Windows.Forms.RightToLeft.No;
			optPaul.Size = new System.Drawing.Size(65, 13);
			optPaul.TabIndex = 10;
			optPaul.TabStop = true;
			optPaul.Text = "Paul";
			optPaul.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			optPaul.Visible = true;
			// 
			// optGeneric
			// 
			optGeneric.AllowDrop = true;
			optGeneric.BackColor = System.Drawing.SystemColors.Control;
			optGeneric.CausesValidation = true;
			optGeneric.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			optGeneric.Checked = false;
			optGeneric.Enabled = true;
			optGeneric.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			optGeneric.ForeColor = System.Drawing.SystemColors.ControlText;
			optGeneric.Location = new System.Drawing.Point(10, 107);
			optGeneric.Name = "optGeneric";
			optGeneric.RightToLeft = System.Windows.Forms.RightToLeft.No;
			optGeneric.Size = new System.Drawing.Size(65, 13);
			optGeneric.TabIndex = 14;
			optGeneric.TabStop = true;
			optGeneric.Text = "Generic";
			optGeneric.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			optGeneric.Visible = true;
			// 
			// optJason
			// 
			optJason.AllowDrop = true;
			optJason.BackColor = System.Drawing.SystemColors.Control;
			optJason.CausesValidation = true;
			optJason.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			optJason.Checked = false;
			optJason.Enabled = true;
			optJason.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			optJason.ForeColor = System.Drawing.SystemColors.ControlText;
			optJason.Location = new System.Drawing.Point(10, 39);
			optJason.Name = "optJason";
			optJason.RightToLeft = System.Windows.Forms.RightToLeft.No;
			optJason.Size = new System.Drawing.Size(65, 13);
			optJason.TabIndex = 9;
			optJason.TabStop = true;
			optJason.Text = "Jason";
			optJason.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			optJason.Visible = true;
			// 
			// optTherese
			// 
			optTherese.AllowDrop = true;
			optTherese.BackColor = System.Drawing.SystemColors.Control;
			optTherese.CausesValidation = true;
			optTherese.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			optTherese.Checked = true;
			optTherese.Enabled = true;
			optTherese.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			optTherese.ForeColor = System.Drawing.SystemColors.ControlText;
			optTherese.Location = new System.Drawing.Point(10, 20);
			optTherese.Name = "optTherese";
			optTherese.RightToLeft = System.Windows.Forms.RightToLeft.No;
			optTherese.Size = new System.Drawing.Size(65, 13);
			optTherese.TabIndex = 8;
			optTherese.TabStop = true;
			optTherese.Text = "Therese";
			optTherese.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			optTherese.Visible = true;
			// 
			// txtEMailAddressTo
			// 
			txtEMailAddressTo.AcceptsReturn = true;
			txtEMailAddressTo.AllowDrop = true;
			txtEMailAddressTo.BackColor = System.Drawing.SystemColors.Window;
			txtEMailAddressTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtEMailAddressTo.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtEMailAddressTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtEMailAddressTo.ForeColor = System.Drawing.SystemColors.WindowText;
			txtEMailAddressTo.Location = new System.Drawing.Point(96, 321);
			txtEMailAddressTo.MaxLength = 0;
			txtEMailAddressTo.Name = "txtEMailAddressTo";
			txtEMailAddressTo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtEMailAddressTo.Size = new System.Drawing.Size(223, 21);
			txtEMailAddressTo.TabIndex = 20;
			txtEMailAddressTo.TextChanged += new System.EventHandler(txtEMailAddressTo_TextChanged);
			// 
			// txtEMailName
			// 
			txtEMailName.AcceptsReturn = true;
			txtEMailName.AllowDrop = true;
			txtEMailName.BackColor = System.Drawing.SystemColors.Window;
			txtEMailName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtEMailName.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtEMailName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtEMailName.ForeColor = System.Drawing.SystemColors.WindowText;
			txtEMailName.Location = new System.Drawing.Point(96, 296);
			txtEMailName.MaxLength = 0;
			txtEMailName.Name = "txtEMailName";
			txtEMailName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtEMailName.Size = new System.Drawing.Size(223, 21);
			txtEMailName.TabIndex = 19;
			txtEMailName.TextChanged += new System.EventHandler(txtEMailName_TextChanged);
			// 
			// cmdCancelEMail
			// 
			cmdCancelEMail.AllowDrop = true;
			cmdCancelEMail.BackColor = System.Drawing.SystemColors.Control;
			cmdCancelEMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdCancelEMail.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdCancelEMail.Location = new System.Drawing.Point(366, 311);
			cmdCancelEMail.Name = "cmdCancelEMail";
			cmdCancelEMail.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdCancelEMail.Size = new System.Drawing.Size(81, 30);
			cmdCancelEMail.TabIndex = 24;
			cmdCancelEMail.Text = "&Cancel EMail";
			cmdCancelEMail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdCancelEMail.UseVisualStyleBackColor = false;
			cmdCancelEMail.Click += new System.EventHandler(cmdCancelEMail_Click);
			// 
			// cmdSendEMail
			// 
			cmdSendEMail.AllowDrop = true;
			cmdSendEMail.BackColor = System.Drawing.SystemColors.Control;
			cmdSendEMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdSendEMail.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdSendEMail.Location = new System.Drawing.Point(366, 278);
			cmdSendEMail.Name = "cmdSendEMail";
			cmdSendEMail.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdSendEMail.Size = new System.Drawing.Size(81, 30);
			cmdSendEMail.TabIndex = 23;
			cmdSendEMail.Text = "&Send EMail";
			cmdSendEMail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdSendEMail.UseVisualStyleBackColor = false;
			cmdSendEMail.Click += new System.EventHandler(cmdSendEMail_Click);
			// 
			// lstbContactName
			// 
			lstbContactName.AllowDrop = true;
			lstbContactName.BackColor = System.Drawing.SystemColors.Window;
			lstbContactName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			lstbContactName.CausesValidation = true;
			lstbContactName.Enabled = true;
			lstbContactName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lstbContactName.ForeColor = System.Drawing.SystemColors.WindowText;
			lstbContactName.IntegralHeight = true;
			lstbContactName.Location = new System.Drawing.Point(87, 210);
			lstbContactName.MultiColumn = false;
			lstbContactName.Name = "lstbContactName";
			lstbContactName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lstbContactName.Size = new System.Drawing.Size(238, 79);
			lstbContactName.Sorted = false;
			lstbContactName.TabIndex = 18;
			lstbContactName.TabStop = true;
			lstbContactName.Visible = true;
			lstbContactName.SelectedIndexChanged += new System.EventHandler(lstbContactName_SelectedIndexChanged);
			// 
			// lblEMailAddressBCC
			// 
			lblEMailAddressBCC.AllowDrop = true;
			lblEMailAddressBCC.AutoSize = true;
			lblEMailAddressBCC.BackColor = System.Drawing.SystemColors.Control;
			lblEMailAddressBCC.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblEMailAddressBCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblEMailAddressBCC.ForeColor = System.Drawing.SystemColors.ControlText;
			lblEMailAddressBCC.Location = new System.Drawing.Point(68, 374);
			lblEMailAddressBCC.MinimumSize = new System.Drawing.Size(21, 13);
			lblEMailAddressBCC.Name = "lblEMailAddressBCC";
			lblEMailAddressBCC.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblEMailAddressBCC.Size = new System.Drawing.Size(21, 13);
			lblEMailAddressBCC.TabIndex = 37;
			lblEMailAddressBCC.Text = "BCC";
			lblEMailAddressBCC.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblEMailAddressCC
			// 
			lblEMailAddressCC.AllowDrop = true;
			lblEMailAddressCC.AutoSize = true;
			lblEMailAddressCC.BackColor = System.Drawing.SystemColors.Control;
			lblEMailAddressCC.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblEMailAddressCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblEMailAddressCC.ForeColor = System.Drawing.SystemColors.ControlText;
			lblEMailAddressCC.Location = new System.Drawing.Point(3, 350);
			lblEMailAddressCC.MinimumSize = new System.Drawing.Size(86, 13);
			lblEMailAddressCC.Name = "lblEMailAddressCC";
			lblEMailAddressCC.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblEMailAddressCC.Size = new System.Drawing.Size(86, 13);
			lblEMailAddressCC.TabIndex = 36;
			lblEMailAddressCC.Text = "CC";
			lblEMailAddressCC.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblNoContactsOnFile
			// 
			lblNoContactsOnFile.AllowDrop = true;
			lblNoContactsOnFile.BackColor = System.Drawing.SystemColors.Control;
			lblNoContactsOnFile.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblNoContactsOnFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblNoContactsOnFile.ForeColor = System.Drawing.Color.Blue;
			lblNoContactsOnFile.Location = new System.Drawing.Point(6, 243);
			lblNoContactsOnFile.MinimumSize = new System.Drawing.Size(340, 22);
			lblNoContactsOnFile.Name = "lblNoContactsOnFile";
			lblNoContactsOnFile.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblNoContactsOnFile.Size = new System.Drawing.Size(340, 22);
			lblNoContactsOnFile.TabIndex = 35;
			lblNoContactsOnFile.Text = "No Contacts With EMail Addresses On File ";
			lblNoContactsOnFile.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			lblNoContactsOnFile.Visible = false;
			// 
			// lblContactName
			// 
			lblContactName.AllowDrop = true;
			lblContactName.AutoSize = true;
			lblContactName.BackColor = System.Drawing.SystemColors.Control;
			lblContactName.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblContactName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblContactName.ForeColor = System.Drawing.SystemColors.ControlText;
			lblContactName.Location = new System.Drawing.Point(5, 213);
			lblContactName.MinimumSize = new System.Drawing.Size(68, 13);
			lblContactName.Name = "lblContactName";
			lblContactName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblContactName.Size = new System.Drawing.Size(68, 13);
			lblContactName.TabIndex = 34;
			lblContactName.Text = "Contact Name";
			// 
			// Label1
			// 
			Label1.AllowDrop = true;
			Label1.AutoSize = true;
			Label1.BackColor = System.Drawing.SystemColors.Control;
			Label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label1.ForeColor = System.Drawing.SystemColors.ControlText;
			Label1.Location = new System.Drawing.Point(111, 99);
			Label1.MinimumSize = new System.Drawing.Size(35, 13);
			Label1.Name = "Label1";
			Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label1.Size = new System.Drawing.Size(35, 13);
			Label1.TabIndex = 33;
			Label1.Text = "Status:";
			Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lblCompany
			// 
			lblCompany.AllowDrop = true;
			lblCompany.AutoSize = true;
			lblCompany.BackColor = System.Drawing.SystemColors.Control;
			lblCompany.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblCompany.ForeColor = System.Drawing.SystemColors.ControlText;
			lblCompany.Location = new System.Drawing.Point(5, 146);
			lblCompany.MinimumSize = new System.Drawing.Size(47, 13);
			lblCompany.Name = "lblCompany";
			lblCompany.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblCompany.Size = new System.Drawing.Size(47, 13);
			lblCompany.TabIndex = 32;
			lblCompany.Text = "Company:";
			// 
			// lblCompanyData
			// 
			lblCompanyData.AllowDrop = true;
			lblCompanyData.BackColor = System.Drawing.SystemColors.Control;
			lblCompanyData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lblCompanyData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblCompanyData.ForeColor = System.Drawing.Color.Red;
			lblCompanyData.Location = new System.Drawing.Point(57, 142);
			lblCompanyData.MinimumSize = new System.Drawing.Size(297, 22);
			lblCompanyData.Name = "lblCompanyData";
			lblCompanyData.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblCompanyData.Size = new System.Drawing.Size(297, 22);
			lblCompanyData.TabIndex = 16;
			// 
			// lblStatus
			// 
			lblStatus.AllowDrop = true;
			lblStatus.BackColor = System.Drawing.SystemColors.Control;
			lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblStatus.ForeColor = System.Drawing.SystemColors.Highlight;
			lblStatus.Location = new System.Drawing.Point(5, 117);
			lblStatus.MinimumSize = new System.Drawing.Size(350, 19);
			lblStatus.Name = "lblStatus";
			lblStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblStatus.Size = new System.Drawing.Size(350, 19);
			lblStatus.TabIndex = 15;
			lblStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lblServiceData
			// 
			lblServiceData.AllowDrop = true;
			lblServiceData.BackColor = System.Drawing.SystemColors.Control;
			lblServiceData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lblServiceData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblServiceData.ForeColor = System.Drawing.Color.Red;
			lblServiceData.Location = new System.Drawing.Point(57, 166);
			lblServiceData.MinimumSize = new System.Drawing.Size(297, 38);
			lblServiceData.Name = "lblServiceData";
			lblServiceData.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblServiceData.Size = new System.Drawing.Size(297, 38);
			lblServiceData.TabIndex = 17;
			// 
			// lblService
			// 
			lblService.AllowDrop = true;
			lblService.AutoSize = true;
			lblService.BackColor = System.Drawing.SystemColors.Control;
			lblService.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblService.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblService.ForeColor = System.Drawing.SystemColors.ControlText;
			lblService.Location = new System.Drawing.Point(5, 174);
			lblService.MinimumSize = new System.Drawing.Size(39, 13);
			lblService.Name = "lblService";
			lblService.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblService.Size = new System.Drawing.Size(39, 13);
			lblService.TabIndex = 31;
			lblService.Text = "Service:";
			// 
			// lblPasswordData
			// 
			lblPasswordData.AllowDrop = true;
			lblPasswordData.BackColor = System.Drawing.SystemColors.Control;
			lblPasswordData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lblPasswordData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblPasswordData.ForeColor = System.Drawing.SystemColors.WindowText;
			lblPasswordData.Location = new System.Drawing.Point(93, 73);
			lblPasswordData.MinimumSize = new System.Drawing.Size(69, 17);
			lblPasswordData.Name = "lblPasswordData";
			lblPasswordData.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblPasswordData.Size = new System.Drawing.Size(69, 17);
			lblPasswordData.TabIndex = 3;
			// 
			// lblLoginData
			// 
			lblLoginData.AllowDrop = true;
			lblLoginData.BackColor = System.Drawing.SystemColors.Control;
			lblLoginData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lblLoginData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblLoginData.ForeColor = System.Drawing.SystemColors.WindowText;
			lblLoginData.Location = new System.Drawing.Point(93, 49);
			lblLoginData.MinimumSize = new System.Drawing.Size(69, 17);
			lblLoginData.Name = "lblLoginData";
			lblLoginData.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblLoginData.Size = new System.Drawing.Size(69, 17);
			lblLoginData.TabIndex = 2;
			// 
			// lblSubIdData
			// 
			lblSubIdData.AllowDrop = true;
			lblSubIdData.BackColor = System.Drawing.SystemColors.Control;
			lblSubIdData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lblSubIdData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblSubIdData.ForeColor = System.Drawing.SystemColors.WindowText;
			lblSubIdData.Location = new System.Drawing.Point(93, 25);
			lblSubIdData.MinimumSize = new System.Drawing.Size(69, 17);
			lblSubIdData.Name = "lblSubIdData";
			lblSubIdData.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblSubIdData.Size = new System.Drawing.Size(69, 17);
			lblSubIdData.TabIndex = 1;
			lblSubIdData.Text = "000000";
			// 
			// lblEMailAddressTo
			// 
			lblEMailAddressTo.AllowDrop = true;
			lblEMailAddressTo.AutoSize = true;
			lblEMailAddressTo.BackColor = System.Drawing.SystemColors.Control;
			lblEMailAddressTo.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblEMailAddressTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblEMailAddressTo.ForeColor = System.Drawing.SystemColors.ControlText;
			lblEMailAddressTo.Location = new System.Drawing.Point(5, 326);
			lblEMailAddressTo.MinimumSize = new System.Drawing.Size(85, 13);
			lblEMailAddressTo.Name = "lblEMailAddressTo";
			lblEMailAddressTo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblEMailAddressTo.Size = new System.Drawing.Size(85, 13);
			lblEMailAddressTo.TabIndex = 29;
			lblEMailAddressTo.Text = "EMail Address TO";
			// 
			// lblEMailName
			// 
			lblEMailName.AllowDrop = true;
			lblEMailName.AutoSize = true;
			lblEMailName.BackColor = System.Drawing.SystemColors.Control;
			lblEMailName.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblEMailName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblEMailName.ForeColor = System.Drawing.SystemColors.ControlText;
			lblEMailName.Location = new System.Drawing.Point(5, 300);
			lblEMailName.MinimumSize = new System.Drawing.Size(84, 13);
			lblEMailName.Name = "lblEMailName";
			lblEMailName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblEMailName.Size = new System.Drawing.Size(84, 13);
			lblEMailName.TabIndex = 28;
			lblEMailName.Text = "EMail Name";
			// 
			// lblPassword
			// 
			lblPassword.AllowDrop = true;
			lblPassword.BackColor = System.Drawing.SystemColors.Control;
			lblPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblPassword.ForeColor = System.Drawing.SystemColors.ControlText;
			lblPassword.Location = new System.Drawing.Point(5, 73);
			lblPassword.MinimumSize = new System.Drawing.Size(69, 17);
			lblPassword.Name = "lblPassword";
			lblPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblPassword.Size = new System.Drawing.Size(69, 17);
			lblPassword.TabIndex = 27;
			lblPassword.Text = "Password:";
			// 
			// lblLogin
			// 
			lblLogin.AllowDrop = true;
			lblLogin.BackColor = System.Drawing.SystemColors.Control;
			lblLogin.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblLogin.ForeColor = System.Drawing.SystemColors.ControlText;
			lblLogin.Location = new System.Drawing.Point(5, 49);
			lblLogin.MinimumSize = new System.Drawing.Size(69, 17);
			lblLogin.Name = "lblLogin";
			lblLogin.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblLogin.Size = new System.Drawing.Size(69, 17);
			lblLogin.TabIndex = 26;
			lblLogin.Text = "Login Name:";
			// 
			// lblSubId
			// 
			lblSubId.AllowDrop = true;
			lblSubId.BackColor = System.Drawing.SystemColors.Control;
			lblSubId.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblSubId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblSubId.ForeColor = System.Drawing.SystemColors.ControlText;
			lblSubId.Location = new System.Drawing.Point(5, 25);
			lblSubId.MinimumSize = new System.Drawing.Size(69, 17);
			lblSubId.Name = "lblSubId";
			lblSubId.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblSubId.Size = new System.Drawing.Size(69, 17);
			lblSubId.TabIndex = 0;
			lblSubId.Text = "SubId:";
			// 
			// frm_Subscription_EMail
			// 
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			ClientSize = new System.Drawing.Size(467, 399);
			Controls.Add(frmWebsite);
			Controls.Add(txtEMailAddressBCC);
			Controls.Add(txtEMailAddressCC);
			Controls.Add(frmEMail);
			Controls.Add(frmFrom);
			Controls.Add(txtEMailAddressTo);
			Controls.Add(txtEMailName);
			Controls.Add(cmdCancelEMail);
			Controls.Add(cmdSendEMail);
			Controls.Add(lstbContactName);
			Controls.Add(lblEMailAddressBCC);
			Controls.Add(lblEMailAddressCC);
			Controls.Add(lblNoContactsOnFile);
			Controls.Add(lblContactName);
			Controls.Add(Label1);
			Controls.Add(lblCompany);
			Controls.Add(lblCompanyData);
			Controls.Add(lblStatus);
			Controls.Add(lblServiceData);
			Controls.Add(lblService);
			Controls.Add(lblPasswordData);
			Controls.Add(lblLoginData);
			Controls.Add(lblSubIdData);
			Controls.Add(lblEMailAddressTo);
			Controls.Add(lblEMailName);
			Controls.Add(lblPassword);
			Controls.Add(lblLogin);
			Controls.Add(lblSubId);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			Location = new System.Drawing.Point(787, 255);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "frm_Subscription_EMail";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			Text = "Subscription EMail Notice";
			commandButtonHelper1.SetStyle(cmdCancelEMail, 0);
			commandButtonHelper1.SetStyle(cmdSendEMail, 0);
			listBoxHelper1.SetSelectionMode(lstbContactName, System.Windows.Forms.SelectionMode.One);
			optionButtonHelper1.SetStyle(optYachtSpot, 0);
			optionButtonHelper1.SetStyle(optEvoDotNet, 0);
			optionButtonHelper1.SetStyle(optEMailAddlLoc, 0);
			optionButtonHelper1.SetStyle(optEMailDemo, 0);
			optionButtonHelper1.SetStyle(optEMailReSend, 0);
			optionButtonHelper1.SetStyle(optEMailNew, 0);
			optionButtonHelper1.SetStyle(optStephanie, 0);
			optionButtonHelper1.SetStyle(optKarim, 0);
			optionButtonHelper1.SetStyle(optKen, 0);
			optionButtonHelper1.SetStyle(optPaul, 0);
			optionButtonHelper1.SetStyle(optGeneric, 0);
			optionButtonHelper1.SetStyle(optJason, 0);
			optionButtonHelper1.SetStyle(optTherese, 0);
			ToolTipMain.SetToolTip(optYachtSpot, "WWW.YACHT-SPOT.COM");
			ToolTipMain.SetToolTip(optEvoDotNet, "WWW.JETNETEVOLUTION.COM");
			ToolTipMain.SetToolTip(txtEMailAddressBCC, "Enter EMail To Address Here");
			ToolTipMain.SetToolTip(txtEMailAddressCC, "Enter EMail To Address Here");
			ToolTipMain.SetToolTip(optEMailAddlLoc, "Click to Send A New Additional Location Subscriber EMail Notice");
			ToolTipMain.SetToolTip(optEMailDemo, "Click to Send Existing Subscriber EMail Notice");
			ToolTipMain.SetToolTip(optEMailReSend, "Click to Send Existing Subscriber EMail Notice");
			ToolTipMain.SetToolTip(optEMailNew, "Click to Send New Subscriber EMail Notice");
			ToolTipMain.SetToolTip(optKen, "** Disabled 06/08/2020 **");
			ToolTipMain.SetToolTip(txtEMailAddressTo, "Enter EMail To Address Here");
			ToolTipMain.SetToolTip(txtEMailName, "Enter Dear Name Here");
			ToolTipMain.SetToolTip(cmdCancelEMail, "Click To Cancel EMail and Close Form");
			ToolTipMain.SetToolTip(cmdSendEMail, "Click to Send EMail");
			Activated += new System.EventHandler(Form_Activated);
			Closed += new System.EventHandler(Form_Closed);
			frmWebsite.ResumeLayout(false);
			frmWebsite.PerformLayout();
			frmEMail.ResumeLayout(false);
			frmEMail.PerformLayout();
			frmFrom.ResumeLayout(false);
			frmFrom.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
		void ReLoadForm(bool addEvents) => Form_Initialize();

		#endregion
	}
}