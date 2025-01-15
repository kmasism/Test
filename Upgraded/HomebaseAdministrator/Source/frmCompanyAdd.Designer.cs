
namespace HomebaseAdministrator
{
	partial class frmCompanyAdd
	{

		#region "Upgrade Support "
		private static frmCompanyAdd m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmCompanyAdd DefInstance
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
		public static frmCompanyAdd CreateInstance()
		{
			frmCompanyAdd theInstance = new frmCompanyAdd();
			theInstance.Form_Load();
			return theInstance;
		}
		private string[] visualControls = new string[]{"components", "ToolTipMain", "cmbSuffix", "txtLastName", "txtMiddleInit", "txtFirstName", "txtContactEMail", "cmbTitle", "cmbSirName", "txtContactOfficeCountryCode", "txtContactOfficeAreaCode", "txtContactOfficePrefix", "txtContactOfficeNumber", "txtContactFaxCountryCode", "txtContactFaxAreaCode", "txtContactFaxPrefix", "txtContactFaxNumber", "_Label1_26", "_Label1_25", "_Label1_24", "_Label1_23", "_Label1_18", "_Label1_17", "frmContactPhone", "_Label1_27", "_Label1_16", "_Label1_15", "_Label1_14", "_Label1_13", "_Label1_12", "_Label1_11", "frmContact", "chkCompContactAddressFlag", "cmbLanguage", "cmbBusinessType", "cmbAccountRep", "cmbAccountType", "cmbAgencyType", "cmdClose", "cmdAdd", "frmButtons", "txtCompEMail", "txtWebsite", "cmbCountry", "txtZipCode", "cmbState", "txtCity", "txtAddress2", "txtAddress1", "txtCompany", "txtCompFaxNumber", "txtCompFaxPrefix", "txtCompFaxAreaCode", "txtCompFaxCountryCode", "txtCompOfficeNumber", "txtCompOfficePrefix", "txtCompOfficeAreaCode", "txtCompOfficeCountryCode", "_Label1_22", "_Label1_21", "_Label1_20", "_Label1_19", "_Label1_8", "_Label1_7", "frmCompanyPhone", "_Label1_32", "_Label1_31", "_Label1_30", "_Label1_29", "_Label1_28", "_Label1_10", "_Label1_9", "_Label1_6", "_Label1_5", "_Label1_4", "_Label1_3", "_Label1_2", "_Label1_1", "_Label1_0", "frmComopany", "Label1", "commandButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.ComboBox cmbSuffix;
		public System.Windows.Forms.TextBox txtLastName;
		public System.Windows.Forms.TextBox txtMiddleInit;
		public System.Windows.Forms.TextBox txtFirstName;
		public System.Windows.Forms.TextBox txtContactEMail;
		public System.Windows.Forms.ComboBox cmbTitle;
		public System.Windows.Forms.ComboBox cmbSirName;
		public System.Windows.Forms.TextBox txtContactOfficeCountryCode;
		public System.Windows.Forms.TextBox txtContactOfficeAreaCode;
		public System.Windows.Forms.TextBox txtContactOfficePrefix;
		public System.Windows.Forms.TextBox txtContactOfficeNumber;
		public System.Windows.Forms.TextBox txtContactFaxCountryCode;
		public System.Windows.Forms.TextBox txtContactFaxAreaCode;
		public System.Windows.Forms.TextBox txtContactFaxPrefix;
		public System.Windows.Forms.TextBox txtContactFaxNumber;
		private System.Windows.Forms.Label _Label1_26;
		private System.Windows.Forms.Label _Label1_25;
		private System.Windows.Forms.Label _Label1_24;
		private System.Windows.Forms.Label _Label1_23;
		private System.Windows.Forms.Label _Label1_18;
		private System.Windows.Forms.Label _Label1_17;
		public System.Windows.Forms.GroupBox frmContactPhone;
		private System.Windows.Forms.Label _Label1_27;
		private System.Windows.Forms.Label _Label1_16;
		private System.Windows.Forms.Label _Label1_15;
		private System.Windows.Forms.Label _Label1_14;
		private System.Windows.Forms.Label _Label1_13;
		private System.Windows.Forms.Label _Label1_12;
		private System.Windows.Forms.Label _Label1_11;
		public System.Windows.Forms.GroupBox frmContact;
		public System.Windows.Forms.CheckBox chkCompContactAddressFlag;
		public System.Windows.Forms.ComboBox cmbLanguage;
		public System.Windows.Forms.ComboBox cmbBusinessType;
		public System.Windows.Forms.ComboBox cmbAccountRep;
		public System.Windows.Forms.ComboBox cmbAccountType;
		public System.Windows.Forms.ComboBox cmbAgencyType;
		public System.Windows.Forms.Button cmdClose;
		public System.Windows.Forms.Button cmdAdd;
		public System.Windows.Forms.GroupBox frmButtons;
		public System.Windows.Forms.TextBox txtCompEMail;
		public System.Windows.Forms.TextBox txtWebsite;
		public System.Windows.Forms.ComboBox cmbCountry;
		public System.Windows.Forms.TextBox txtZipCode;
		public System.Windows.Forms.ComboBox cmbState;
		public System.Windows.Forms.TextBox txtCity;
		public System.Windows.Forms.TextBox txtAddress2;
		public System.Windows.Forms.TextBox txtAddress1;
		public System.Windows.Forms.TextBox txtCompany;
		public System.Windows.Forms.TextBox txtCompFaxNumber;
		public System.Windows.Forms.TextBox txtCompFaxPrefix;
		public System.Windows.Forms.TextBox txtCompFaxAreaCode;
		public System.Windows.Forms.TextBox txtCompFaxCountryCode;
		public System.Windows.Forms.TextBox txtCompOfficeNumber;
		public System.Windows.Forms.TextBox txtCompOfficePrefix;
		public System.Windows.Forms.TextBox txtCompOfficeAreaCode;
		public System.Windows.Forms.TextBox txtCompOfficeCountryCode;
		private System.Windows.Forms.Label _Label1_22;
		private System.Windows.Forms.Label _Label1_21;
		private System.Windows.Forms.Label _Label1_20;
		private System.Windows.Forms.Label _Label1_19;
		private System.Windows.Forms.Label _Label1_8;
		private System.Windows.Forms.Label _Label1_7;
		public System.Windows.Forms.GroupBox frmCompanyPhone;
		private System.Windows.Forms.Label _Label1_32;
		private System.Windows.Forms.Label _Label1_31;
		private System.Windows.Forms.Label _Label1_30;
		private System.Windows.Forms.Label _Label1_29;
		private System.Windows.Forms.Label _Label1_28;
		private System.Windows.Forms.Label _Label1_10;
		private System.Windows.Forms.Label _Label1_9;
		private System.Windows.Forms.Label _Label1_6;
		private System.Windows.Forms.Label _Label1_5;
		private System.Windows.Forms.Label _Label1_4;
		private System.Windows.Forms.Label _Label1_3;
		private System.Windows.Forms.Label _Label1_2;
		private System.Windows.Forms.Label _Label1_1;
		private System.Windows.Forms.Label _Label1_0;
		public System.Windows.Forms.GroupBox frmComopany;
		public System.Windows.Forms.Label[] Label1 = new System.Windows.Forms.Label[33];
		public UpgradeHelpers.Gui.Controls.CommandButtonHelper commandButtonHelper1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCompanyAdd));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			frmContact = new System.Windows.Forms.GroupBox();
			cmbSuffix = new System.Windows.Forms.ComboBox();
			txtLastName = new System.Windows.Forms.TextBox();
			txtMiddleInit = new System.Windows.Forms.TextBox();
			txtFirstName = new System.Windows.Forms.TextBox();
			txtContactEMail = new System.Windows.Forms.TextBox();
			cmbTitle = new System.Windows.Forms.ComboBox();
			cmbSirName = new System.Windows.Forms.ComboBox();
			frmContactPhone = new System.Windows.Forms.GroupBox();
			txtContactOfficeCountryCode = new System.Windows.Forms.TextBox();
			txtContactOfficeAreaCode = new System.Windows.Forms.TextBox();
			txtContactOfficePrefix = new System.Windows.Forms.TextBox();
			txtContactOfficeNumber = new System.Windows.Forms.TextBox();
			txtContactFaxCountryCode = new System.Windows.Forms.TextBox();
			txtContactFaxAreaCode = new System.Windows.Forms.TextBox();
			txtContactFaxPrefix = new System.Windows.Forms.TextBox();
			txtContactFaxNumber = new System.Windows.Forms.TextBox();
			_Label1_26 = new System.Windows.Forms.Label();
			_Label1_25 = new System.Windows.Forms.Label();
			_Label1_24 = new System.Windows.Forms.Label();
			_Label1_23 = new System.Windows.Forms.Label();
			_Label1_18 = new System.Windows.Forms.Label();
			_Label1_17 = new System.Windows.Forms.Label();
			_Label1_27 = new System.Windows.Forms.Label();
			_Label1_16 = new System.Windows.Forms.Label();
			_Label1_15 = new System.Windows.Forms.Label();
			_Label1_14 = new System.Windows.Forms.Label();
			_Label1_13 = new System.Windows.Forms.Label();
			_Label1_12 = new System.Windows.Forms.Label();
			_Label1_11 = new System.Windows.Forms.Label();
			frmComopany = new System.Windows.Forms.GroupBox();
			chkCompContactAddressFlag = new System.Windows.Forms.CheckBox();
			cmbLanguage = new System.Windows.Forms.ComboBox();
			cmbBusinessType = new System.Windows.Forms.ComboBox();
			cmbAccountRep = new System.Windows.Forms.ComboBox();
			cmbAccountType = new System.Windows.Forms.ComboBox();
			cmbAgencyType = new System.Windows.Forms.ComboBox();
			frmButtons = new System.Windows.Forms.GroupBox();
			cmdClose = new System.Windows.Forms.Button();
			cmdAdd = new System.Windows.Forms.Button();
			txtCompEMail = new System.Windows.Forms.TextBox();
			txtWebsite = new System.Windows.Forms.TextBox();
			cmbCountry = new System.Windows.Forms.ComboBox();
			txtZipCode = new System.Windows.Forms.TextBox();
			cmbState = new System.Windows.Forms.ComboBox();
			txtCity = new System.Windows.Forms.TextBox();
			txtAddress2 = new System.Windows.Forms.TextBox();
			txtAddress1 = new System.Windows.Forms.TextBox();
			txtCompany = new System.Windows.Forms.TextBox();
			frmCompanyPhone = new System.Windows.Forms.GroupBox();
			txtCompFaxNumber = new System.Windows.Forms.TextBox();
			txtCompFaxPrefix = new System.Windows.Forms.TextBox();
			txtCompFaxAreaCode = new System.Windows.Forms.TextBox();
			txtCompFaxCountryCode = new System.Windows.Forms.TextBox();
			txtCompOfficeNumber = new System.Windows.Forms.TextBox();
			txtCompOfficePrefix = new System.Windows.Forms.TextBox();
			txtCompOfficeAreaCode = new System.Windows.Forms.TextBox();
			txtCompOfficeCountryCode = new System.Windows.Forms.TextBox();
			_Label1_22 = new System.Windows.Forms.Label();
			_Label1_21 = new System.Windows.Forms.Label();
			_Label1_20 = new System.Windows.Forms.Label();
			_Label1_19 = new System.Windows.Forms.Label();
			_Label1_8 = new System.Windows.Forms.Label();
			_Label1_7 = new System.Windows.Forms.Label();
			_Label1_32 = new System.Windows.Forms.Label();
			_Label1_31 = new System.Windows.Forms.Label();
			_Label1_30 = new System.Windows.Forms.Label();
			_Label1_29 = new System.Windows.Forms.Label();
			_Label1_28 = new System.Windows.Forms.Label();
			_Label1_10 = new System.Windows.Forms.Label();
			_Label1_9 = new System.Windows.Forms.Label();
			_Label1_6 = new System.Windows.Forms.Label();
			_Label1_5 = new System.Windows.Forms.Label();
			_Label1_4 = new System.Windows.Forms.Label();
			_Label1_3 = new System.Windows.Forms.Label();
			_Label1_2 = new System.Windows.Forms.Label();
			_Label1_1 = new System.Windows.Forms.Label();
			_Label1_0 = new System.Windows.Forms.Label();
			frmContact.SuspendLayout();
			frmContactPhone.SuspendLayout();
			frmComopany.SuspendLayout();
			frmButtons.SuspendLayout();
			frmCompanyPhone.SuspendLayout();
			SuspendLayout();
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
			// 
			// frmContact
			// 
			frmContact.AllowDrop = true;
			frmContact.BackColor = System.Drawing.SystemColors.Control;
			frmContact.Controls.Add(cmbSuffix);
			frmContact.Controls.Add(txtLastName);
			frmContact.Controls.Add(txtMiddleInit);
			frmContact.Controls.Add(txtFirstName);
			frmContact.Controls.Add(txtContactEMail);
			frmContact.Controls.Add(cmbTitle);
			frmContact.Controls.Add(cmbSirName);
			frmContact.Controls.Add(frmContactPhone);
			frmContact.Controls.Add(_Label1_27);
			frmContact.Controls.Add(_Label1_16);
			frmContact.Controls.Add(_Label1_15);
			frmContact.Controls.Add(_Label1_14);
			frmContact.Controls.Add(_Label1_13);
			frmContact.Controls.Add(_Label1_12);
			frmContact.Controls.Add(_Label1_11);
			frmContact.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmContact.Enabled = true;
			frmContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmContact.ForeColor = System.Drawing.SystemColors.ControlText;
			frmContact.Location = new System.Drawing.Point(22, 404);
			frmContact.Name = "frmContact";
			frmContact.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmContact.Size = new System.Drawing.Size(467, 289);
			frmContact.TabIndex = 38;
			frmContact.Text = "Contact";
			frmContact.Visible = true;
			// 
			// cmbSuffix
			// 
			cmbSuffix.AllowDrop = true;
			cmbSuffix.BackColor = System.Drawing.SystemColors.Window;
			cmbSuffix.CausesValidation = true;
			cmbSuffix.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cmbSuffix.Enabled = true;
			cmbSuffix.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmbSuffix.ForeColor = System.Drawing.SystemColors.WindowText;
			cmbSuffix.IntegralHeight = true;
			cmbSuffix.Location = new System.Drawing.Point(76, 108);
			cmbSuffix.Name = "cmbSuffix";
			cmbSuffix.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmbSuffix.Size = new System.Drawing.Size(95, 21);
			cmbSuffix.Sorted = false;
			cmbSuffix.TabIndex = 71;
			cmbSuffix.TabStop = true;
			cmbSuffix.Visible = true;
			// 
			// txtLastName
			// 
			txtLastName.AcceptsReturn = true;
			txtLastName.AllowDrop = true;
			txtLastName.BackColor = System.Drawing.SystemColors.Window;
			txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtLastName.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtLastName.ForeColor = System.Drawing.SystemColors.WindowText;
			txtLastName.Location = new System.Drawing.Point(76, 86);
			txtLastName.MaxLength = 50;
			txtLastName.Name = "txtLastName";
			txtLastName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtLastName.Size = new System.Drawing.Size(177, 21);
			txtLastName.TabIndex = 26;
			// 
			// txtMiddleInit
			// 
			txtMiddleInit.AcceptsReturn = true;
			txtMiddleInit.AllowDrop = true;
			txtMiddleInit.BackColor = System.Drawing.SystemColors.Window;
			txtMiddleInit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtMiddleInit.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtMiddleInit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtMiddleInit.ForeColor = System.Drawing.SystemColors.WindowText;
			txtMiddleInit.Location = new System.Drawing.Point(76, 64);
			txtMiddleInit.MaxLength = 1;
			txtMiddleInit.Name = "txtMiddleInit";
			txtMiddleInit.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtMiddleInit.Size = new System.Drawing.Size(27, 21);
			txtMiddleInit.TabIndex = 25;
			// 
			// txtFirstName
			// 
			txtFirstName.AcceptsReturn = true;
			txtFirstName.AllowDrop = true;
			txtFirstName.BackColor = System.Drawing.SystemColors.Window;
			txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtFirstName.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtFirstName.ForeColor = System.Drawing.SystemColors.WindowText;
			txtFirstName.Location = new System.Drawing.Point(76, 42);
			txtFirstName.MaxLength = 50;
			txtFirstName.Name = "txtFirstName";
			txtFirstName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtFirstName.Size = new System.Drawing.Size(177, 21);
			txtFirstName.TabIndex = 24;
			// 
			// txtContactEMail
			// 
			txtContactEMail.AcceptsReturn = true;
			txtContactEMail.AllowDrop = true;
			txtContactEMail.BackColor = System.Drawing.SystemColors.Window;
			txtContactEMail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtContactEMail.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtContactEMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtContactEMail.ForeColor = System.Drawing.SystemColors.WindowText;
			txtContactEMail.Location = new System.Drawing.Point(76, 152);
			txtContactEMail.MaxLength = 150;
			txtContactEMail.Name = "txtContactEMail";
			txtContactEMail.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtContactEMail.Size = new System.Drawing.Size(379, 21);
			txtContactEMail.TabIndex = 28;
			// 
			// cmbTitle
			// 
			cmbTitle.AllowDrop = true;
			cmbTitle.BackColor = System.Drawing.SystemColors.Window;
			cmbTitle.CausesValidation = true;
			cmbTitle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cmbTitle.Enabled = true;
			cmbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmbTitle.ForeColor = System.Drawing.SystemColors.WindowText;
			cmbTitle.IntegralHeight = true;
			cmbTitle.Location = new System.Drawing.Point(76, 130);
			cmbTitle.Name = "cmbTitle";
			cmbTitle.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmbTitle.Size = new System.Drawing.Size(281, 21);
			cmbTitle.Sorted = false;
			cmbTitle.TabIndex = 27;
			cmbTitle.TabStop = true;
			cmbTitle.Visible = true;
			// 
			// cmbSirName
			// 
			cmbSirName.AllowDrop = true;
			cmbSirName.BackColor = System.Drawing.SystemColors.Window;
			cmbSirName.CausesValidation = true;
			cmbSirName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cmbSirName.Enabled = true;
			cmbSirName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmbSirName.ForeColor = System.Drawing.SystemColors.WindowText;
			cmbSirName.IntegralHeight = true;
			cmbSirName.Location = new System.Drawing.Point(76, 20);
			cmbSirName.Name = "cmbSirName";
			cmbSirName.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmbSirName.Size = new System.Drawing.Size(95, 21);
			cmbSirName.Sorted = false;
			cmbSirName.TabIndex = 23;
			cmbSirName.TabStop = true;
			cmbSirName.Visible = true;
			// 
			// frmContactPhone
			// 
			frmContactPhone.AllowDrop = true;
			frmContactPhone.BackColor = System.Drawing.SystemColors.Control;
			frmContactPhone.Controls.Add(txtContactOfficeCountryCode);
			frmContactPhone.Controls.Add(txtContactOfficeAreaCode);
			frmContactPhone.Controls.Add(txtContactOfficePrefix);
			frmContactPhone.Controls.Add(txtContactOfficeNumber);
			frmContactPhone.Controls.Add(txtContactFaxCountryCode);
			frmContactPhone.Controls.Add(txtContactFaxAreaCode);
			frmContactPhone.Controls.Add(txtContactFaxPrefix);
			frmContactPhone.Controls.Add(txtContactFaxNumber);
			frmContactPhone.Controls.Add(_Label1_26);
			frmContactPhone.Controls.Add(_Label1_25);
			frmContactPhone.Controls.Add(_Label1_24);
			frmContactPhone.Controls.Add(_Label1_23);
			frmContactPhone.Controls.Add(_Label1_18);
			frmContactPhone.Controls.Add(_Label1_17);
			frmContactPhone.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmContactPhone.Enabled = true;
			frmContactPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmContactPhone.ForeColor = System.Drawing.SystemColors.ControlText;
			frmContactPhone.Location = new System.Drawing.Point(8, 186);
			frmContactPhone.Name = "frmContactPhone";
			frmContactPhone.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmContactPhone.Size = new System.Drawing.Size(349, 87);
			frmContactPhone.TabIndex = 61;
			frmContactPhone.Text = "Phone Numbers";
			frmContactPhone.Visible = true;
			// 
			// txtContactOfficeCountryCode
			// 
			txtContactOfficeCountryCode.AcceptsReturn = true;
			txtContactOfficeCountryCode.AllowDrop = true;
			txtContactOfficeCountryCode.BackColor = System.Drawing.SystemColors.Window;
			txtContactOfficeCountryCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtContactOfficeCountryCode.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtContactOfficeCountryCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtContactOfficeCountryCode.ForeColor = System.Drawing.SystemColors.WindowText;
			txtContactOfficeCountryCode.Location = new System.Drawing.Point(66, 30);
			txtContactOfficeCountryCode.MaxLength = 6;
			txtContactOfficeCountryCode.Name = "txtContactOfficeCountryCode";
			txtContactOfficeCountryCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtContactOfficeCountryCode.Size = new System.Drawing.Size(47, 21);
			txtContactOfficeCountryCode.TabIndex = 29;
			// 
			// txtContactOfficeAreaCode
			// 
			txtContactOfficeAreaCode.AcceptsReturn = true;
			txtContactOfficeAreaCode.AllowDrop = true;
			txtContactOfficeAreaCode.BackColor = System.Drawing.SystemColors.Window;
			txtContactOfficeAreaCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtContactOfficeAreaCode.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtContactOfficeAreaCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtContactOfficeAreaCode.ForeColor = System.Drawing.SystemColors.WindowText;
			txtContactOfficeAreaCode.Location = new System.Drawing.Point(130, 30);
			txtContactOfficeAreaCode.MaxLength = 6;
			txtContactOfficeAreaCode.Name = "txtContactOfficeAreaCode";
			txtContactOfficeAreaCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtContactOfficeAreaCode.Size = new System.Drawing.Size(47, 21);
			txtContactOfficeAreaCode.TabIndex = 30;
			// 
			// txtContactOfficePrefix
			// 
			txtContactOfficePrefix.AcceptsReturn = true;
			txtContactOfficePrefix.AllowDrop = true;
			txtContactOfficePrefix.BackColor = System.Drawing.SystemColors.Window;
			txtContactOfficePrefix.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtContactOfficePrefix.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtContactOfficePrefix.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtContactOfficePrefix.ForeColor = System.Drawing.SystemColors.WindowText;
			txtContactOfficePrefix.Location = new System.Drawing.Point(188, 30);
			txtContactOfficePrefix.MaxLength = 6;
			txtContactOfficePrefix.Name = "txtContactOfficePrefix";
			txtContactOfficePrefix.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtContactOfficePrefix.Size = new System.Drawing.Size(47, 21);
			txtContactOfficePrefix.TabIndex = 31;
			// 
			// txtContactOfficeNumber
			// 
			txtContactOfficeNumber.AcceptsReturn = true;
			txtContactOfficeNumber.AllowDrop = true;
			txtContactOfficeNumber.BackColor = System.Drawing.SystemColors.Window;
			txtContactOfficeNumber.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtContactOfficeNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtContactOfficeNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtContactOfficeNumber.ForeColor = System.Drawing.SystemColors.WindowText;
			txtContactOfficeNumber.Location = new System.Drawing.Point(244, 30);
			txtContactOfficeNumber.MaxLength = 10;
			txtContactOfficeNumber.Name = "txtContactOfficeNumber";
			txtContactOfficeNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtContactOfficeNumber.Size = new System.Drawing.Size(91, 21);
			txtContactOfficeNumber.TabIndex = 32;
			// 
			// txtContactFaxCountryCode
			// 
			txtContactFaxCountryCode.AcceptsReturn = true;
			txtContactFaxCountryCode.AllowDrop = true;
			txtContactFaxCountryCode.BackColor = System.Drawing.SystemColors.Window;
			txtContactFaxCountryCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtContactFaxCountryCode.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtContactFaxCountryCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtContactFaxCountryCode.ForeColor = System.Drawing.SystemColors.WindowText;
			txtContactFaxCountryCode.Location = new System.Drawing.Point(66, 52);
			txtContactFaxCountryCode.MaxLength = 6;
			txtContactFaxCountryCode.Name = "txtContactFaxCountryCode";
			txtContactFaxCountryCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtContactFaxCountryCode.Size = new System.Drawing.Size(47, 21);
			txtContactFaxCountryCode.TabIndex = 33;
			// 
			// txtContactFaxAreaCode
			// 
			txtContactFaxAreaCode.AcceptsReturn = true;
			txtContactFaxAreaCode.AllowDrop = true;
			txtContactFaxAreaCode.BackColor = System.Drawing.SystemColors.Window;
			txtContactFaxAreaCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtContactFaxAreaCode.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtContactFaxAreaCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtContactFaxAreaCode.ForeColor = System.Drawing.SystemColors.WindowText;
			txtContactFaxAreaCode.Location = new System.Drawing.Point(130, 52);
			txtContactFaxAreaCode.MaxLength = 6;
			txtContactFaxAreaCode.Name = "txtContactFaxAreaCode";
			txtContactFaxAreaCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtContactFaxAreaCode.Size = new System.Drawing.Size(47, 21);
			txtContactFaxAreaCode.TabIndex = 34;
			// 
			// txtContactFaxPrefix
			// 
			txtContactFaxPrefix.AcceptsReturn = true;
			txtContactFaxPrefix.AllowDrop = true;
			txtContactFaxPrefix.BackColor = System.Drawing.SystemColors.Window;
			txtContactFaxPrefix.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtContactFaxPrefix.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtContactFaxPrefix.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtContactFaxPrefix.ForeColor = System.Drawing.SystemColors.WindowText;
			txtContactFaxPrefix.Location = new System.Drawing.Point(188, 52);
			txtContactFaxPrefix.MaxLength = 6;
			txtContactFaxPrefix.Name = "txtContactFaxPrefix";
			txtContactFaxPrefix.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtContactFaxPrefix.Size = new System.Drawing.Size(47, 21);
			txtContactFaxPrefix.TabIndex = 35;
			// 
			// txtContactFaxNumber
			// 
			txtContactFaxNumber.AcceptsReturn = true;
			txtContactFaxNumber.AllowDrop = true;
			txtContactFaxNumber.BackColor = System.Drawing.SystemColors.Window;
			txtContactFaxNumber.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtContactFaxNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtContactFaxNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtContactFaxNumber.ForeColor = System.Drawing.SystemColors.WindowText;
			txtContactFaxNumber.Location = new System.Drawing.Point(244, 52);
			txtContactFaxNumber.MaxLength = 10;
			txtContactFaxNumber.Name = "txtContactFaxNumber";
			txtContactFaxNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtContactFaxNumber.Size = new System.Drawing.Size(91, 21);
			txtContactFaxNumber.TabIndex = 36;
			// 
			// _Label1_26
			// 
			_Label1_26.AllowDrop = true;
			_Label1_26.BackColor = System.Drawing.SystemColors.Control;
			_Label1_26.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_26.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_26.Location = new System.Drawing.Point(12, 34);
			_Label1_26.MinimumSize = new System.Drawing.Size(45, 17);
			_Label1_26.Name = "_Label1_26";
			_Label1_26.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_26.Size = new System.Drawing.Size(45, 17);
			_Label1_26.TabIndex = 67;
			_Label1_26.Text = "Office";
			// 
			// _Label1_25
			// 
			_Label1_25.AllowDrop = true;
			_Label1_25.BackColor = System.Drawing.SystemColors.Control;
			_Label1_25.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_25.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_25.Location = new System.Drawing.Point(12, 54);
			_Label1_25.MinimumSize = new System.Drawing.Size(45, 17);
			_Label1_25.Name = "_Label1_25";
			_Label1_25.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_25.Size = new System.Drawing.Size(45, 17);
			_Label1_25.TabIndex = 66;
			_Label1_25.Text = "Fax";
			// 
			// _Label1_24
			// 
			_Label1_24.AllowDrop = true;
			_Label1_24.BackColor = System.Drawing.SystemColors.Control;
			_Label1_24.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_24.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_24.Location = new System.Drawing.Point(66, 14);
			_Label1_24.MinimumSize = new System.Drawing.Size(53, 17);
			_Label1_24.Name = "_Label1_24";
			_Label1_24.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_24.Size = new System.Drawing.Size(53, 17);
			_Label1_24.TabIndex = 65;
			_Label1_24.Text = "Country";
			// 
			// _Label1_23
			// 
			_Label1_23.AllowDrop = true;
			_Label1_23.BackColor = System.Drawing.SystemColors.Control;
			_Label1_23.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_23.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_23.Location = new System.Drawing.Point(130, 14);
			_Label1_23.MinimumSize = new System.Drawing.Size(53, 17);
			_Label1_23.Name = "_Label1_23";
			_Label1_23.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_23.Size = new System.Drawing.Size(53, 17);
			_Label1_23.TabIndex = 64;
			_Label1_23.Text = "Area";
			// 
			// _Label1_18
			// 
			_Label1_18.AllowDrop = true;
			_Label1_18.BackColor = System.Drawing.SystemColors.Control;
			_Label1_18.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_18.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_18.Location = new System.Drawing.Point(188, 14);
			_Label1_18.MinimumSize = new System.Drawing.Size(53, 17);
			_Label1_18.Name = "_Label1_18";
			_Label1_18.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_18.Size = new System.Drawing.Size(53, 17);
			_Label1_18.TabIndex = 63;
			_Label1_18.Text = "Prefix";
			// 
			// _Label1_17
			// 
			_Label1_17.AllowDrop = true;
			_Label1_17.BackColor = System.Drawing.SystemColors.Control;
			_Label1_17.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_17.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_17.Location = new System.Drawing.Point(244, 14);
			_Label1_17.MinimumSize = new System.Drawing.Size(53, 17);
			_Label1_17.Name = "_Label1_17";
			_Label1_17.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_17.Size = new System.Drawing.Size(53, 17);
			_Label1_17.TabIndex = 62;
			_Label1_17.Text = "Number";
			// 
			// _Label1_27
			// 
			_Label1_27.AllowDrop = true;
			_Label1_27.BackColor = System.Drawing.SystemColors.Control;
			_Label1_27.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_27.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_27.Location = new System.Drawing.Point(10, 112);
			_Label1_27.MinimumSize = new System.Drawing.Size(45, 17);
			_Label1_27.Name = "_Label1_27";
			_Label1_27.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_27.Size = new System.Drawing.Size(45, 17);
			_Label1_27.TabIndex = 72;
			_Label1_27.Text = "Suffix";
			// 
			// _Label1_16
			// 
			_Label1_16.AllowDrop = true;
			_Label1_16.BackColor = System.Drawing.SystemColors.Control;
			_Label1_16.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_16.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_16.Location = new System.Drawing.Point(10, 158);
			_Label1_16.MinimumSize = new System.Drawing.Size(45, 17);
			_Label1_16.Name = "_Label1_16";
			_Label1_16.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_16.Size = new System.Drawing.Size(45, 17);
			_Label1_16.TabIndex = 56;
			_Label1_16.Text = "EMail";
			// 
			// _Label1_15
			// 
			_Label1_15.AllowDrop = true;
			_Label1_15.BackColor = System.Drawing.SystemColors.Control;
			_Label1_15.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_15.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_15.Location = new System.Drawing.Point(10, 136);
			_Label1_15.MinimumSize = new System.Drawing.Size(45, 17);
			_Label1_15.Name = "_Label1_15";
			_Label1_15.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_15.Size = new System.Drawing.Size(45, 17);
			_Label1_15.TabIndex = 55;
			_Label1_15.Text = "Title";
			// 
			// _Label1_14
			// 
			_Label1_14.AllowDrop = true;
			_Label1_14.BackColor = System.Drawing.SystemColors.Control;
			_Label1_14.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_14.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_14.Location = new System.Drawing.Point(10, 88);
			_Label1_14.MinimumSize = new System.Drawing.Size(59, 17);
			_Label1_14.Name = "_Label1_14";
			_Label1_14.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_14.Size = new System.Drawing.Size(59, 17);
			_Label1_14.TabIndex = 54;
			_Label1_14.Text = "Last Name";
			// 
			// _Label1_13
			// 
			_Label1_13.AllowDrop = true;
			_Label1_13.BackColor = System.Drawing.SystemColors.Control;
			_Label1_13.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_13.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_13.Location = new System.Drawing.Point(10, 66);
			_Label1_13.MinimumSize = new System.Drawing.Size(57, 17);
			_Label1_13.Name = "_Label1_13";
			_Label1_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_13.Size = new System.Drawing.Size(57, 17);
			_Label1_13.TabIndex = 53;
			_Label1_13.Text = "Middle Init";
			// 
			// _Label1_12
			// 
			_Label1_12.AllowDrop = true;
			_Label1_12.BackColor = System.Drawing.SystemColors.Control;
			_Label1_12.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_12.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_12.Location = new System.Drawing.Point(10, 44);
			_Label1_12.MinimumSize = new System.Drawing.Size(59, 17);
			_Label1_12.Name = "_Label1_12";
			_Label1_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_12.Size = new System.Drawing.Size(59, 17);
			_Label1_12.TabIndex = 52;
			_Label1_12.Text = "First Name";
			// 
			// _Label1_11
			// 
			_Label1_11.AllowDrop = true;
			_Label1_11.BackColor = System.Drawing.SystemColors.Control;
			_Label1_11.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_11.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_11.Location = new System.Drawing.Point(10, 22);
			_Label1_11.MinimumSize = new System.Drawing.Size(45, 17);
			_Label1_11.Name = "_Label1_11";
			_Label1_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_11.Size = new System.Drawing.Size(45, 17);
			_Label1_11.TabIndex = 51;
			_Label1_11.Text = "SirName";
			// 
			// frmComopany
			// 
			frmComopany.AllowDrop = true;
			frmComopany.BackColor = System.Drawing.SystemColors.Control;
			frmComopany.Controls.Add(chkCompContactAddressFlag);
			frmComopany.Controls.Add(cmbLanguage);
			frmComopany.Controls.Add(cmbBusinessType);
			frmComopany.Controls.Add(cmbAccountRep);
			frmComopany.Controls.Add(cmbAccountType);
			frmComopany.Controls.Add(cmbAgencyType);
			frmComopany.Controls.Add(frmButtons);
			frmComopany.Controls.Add(txtCompEMail);
			frmComopany.Controls.Add(txtWebsite);
			frmComopany.Controls.Add(cmbCountry);
			frmComopany.Controls.Add(txtZipCode);
			frmComopany.Controls.Add(cmbState);
			frmComopany.Controls.Add(txtCity);
			frmComopany.Controls.Add(txtAddress2);
			frmComopany.Controls.Add(txtAddress1);
			frmComopany.Controls.Add(txtCompany);
			frmComopany.Controls.Add(frmCompanyPhone);
			frmComopany.Controls.Add(_Label1_32);
			frmComopany.Controls.Add(_Label1_31);
			frmComopany.Controls.Add(_Label1_30);
			frmComopany.Controls.Add(_Label1_29);
			frmComopany.Controls.Add(_Label1_28);
			frmComopany.Controls.Add(_Label1_10);
			frmComopany.Controls.Add(_Label1_9);
			frmComopany.Controls.Add(_Label1_6);
			frmComopany.Controls.Add(_Label1_5);
			frmComopany.Controls.Add(_Label1_4);
			frmComopany.Controls.Add(_Label1_3);
			frmComopany.Controls.Add(_Label1_2);
			frmComopany.Controls.Add(_Label1_1);
			frmComopany.Controls.Add(_Label1_0);
			frmComopany.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmComopany.Enabled = true;
			frmComopany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmComopany.ForeColor = System.Drawing.SystemColors.ControlText;
			frmComopany.Location = new System.Drawing.Point(22, 22);
			frmComopany.Name = "frmComopany";
			frmComopany.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmComopany.Size = new System.Drawing.Size(465, 371);
			frmComopany.TabIndex = 37;
			frmComopany.Text = "Company";
			frmComopany.Visible = true;
			// 
			// chkCompContactAddressFlag
			// 
			chkCompContactAddressFlag.AllowDrop = true;
			chkCompContactAddressFlag.Appearance = System.Windows.Forms.Appearance.Normal;
			chkCompContactAddressFlag.BackColor = System.Drawing.SystemColors.Control;
			chkCompContactAddressFlag.CausesValidation = true;
			chkCompContactAddressFlag.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			chkCompContactAddressFlag.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkCompContactAddressFlag.Enabled = true;
			chkCompContactAddressFlag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkCompContactAddressFlag.ForeColor = System.Drawing.SystemColors.WindowText;
			chkCompContactAddressFlag.Location = new System.Drawing.Point(208, 230);
			chkCompContactAddressFlag.Name = "chkCompContactAddressFlag";
			chkCompContactAddressFlag.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkCompContactAddressFlag.Size = new System.Drawing.Size(133, 17);
			chkCompContactAddressFlag.TabIndex = 13;
			chkCompContactAddressFlag.TabStop = true;
			chkCompContactAddressFlag.Text = "Individual/Company";
			chkCompContactAddressFlag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkCompContactAddressFlag.Visible = true;
			// 
			// cmbLanguage
			// 
			cmbLanguage.AllowDrop = true;
			cmbLanguage.BackColor = System.Drawing.SystemColors.Window;
			cmbLanguage.CausesValidation = true;
			cmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cmbLanguage.Enabled = true;
			cmbLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmbLanguage.ForeColor = System.Drawing.SystemColors.WindowText;
			cmbLanguage.IntegralHeight = true;
			cmbLanguage.Location = new System.Drawing.Point(78, 224);
			cmbLanguage.Name = "cmbLanguage";
			cmbLanguage.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmbLanguage.Size = new System.Drawing.Size(127, 21);
			cmbLanguage.Sorted = false;
			cmbLanguage.TabIndex = 14;
			cmbLanguage.TabStop = true;
			cmbLanguage.Visible = true;
			// 
			// cmbBusinessType
			// 
			cmbBusinessType.AllowDrop = true;
			cmbBusinessType.BackColor = System.Drawing.SystemColors.Window;
			cmbBusinessType.CausesValidation = true;
			cmbBusinessType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cmbBusinessType.Enabled = true;
			cmbBusinessType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmbBusinessType.ForeColor = System.Drawing.SystemColors.WindowText;
			cmbBusinessType.IntegralHeight = true;
			cmbBusinessType.Location = new System.Drawing.Point(286, 202);
			cmbBusinessType.Name = "cmbBusinessType";
			cmbBusinessType.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmbBusinessType.Size = new System.Drawing.Size(173, 21);
			cmbBusinessType.Sorted = false;
			cmbBusinessType.TabIndex = 12;
			cmbBusinessType.TabStop = true;
			cmbBusinessType.Visible = true;
			// 
			// cmbAccountRep
			// 
			cmbAccountRep.AllowDrop = true;
			cmbAccountRep.BackColor = System.Drawing.SystemColors.Window;
			cmbAccountRep.CausesValidation = true;
			cmbAccountRep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cmbAccountRep.Enabled = true;
			cmbAccountRep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmbAccountRep.ForeColor = System.Drawing.SystemColors.WindowText;
			cmbAccountRep.IntegralHeight = true;
			cmbAccountRep.Location = new System.Drawing.Point(78, 202);
			cmbAccountRep.Name = "cmbAccountRep";
			cmbAccountRep.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmbAccountRep.Size = new System.Drawing.Size(77, 21);
			cmbAccountRep.Sorted = false;
			cmbAccountRep.TabIndex = 11;
			cmbAccountRep.TabStop = true;
			cmbAccountRep.Visible = true;
			// 
			// cmbAccountType
			// 
			cmbAccountType.AllowDrop = true;
			cmbAccountType.BackColor = System.Drawing.SystemColors.Window;
			cmbAccountType.CausesValidation = true;
			cmbAccountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cmbAccountType.Enabled = true;
			cmbAccountType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmbAccountType.ForeColor = System.Drawing.SystemColors.WindowText;
			cmbAccountType.IntegralHeight = true;
			cmbAccountType.Location = new System.Drawing.Point(286, 180);
			cmbAccountType.Name = "cmbAccountType";
			cmbAccountType.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmbAccountType.Size = new System.Drawing.Size(173, 21);
			cmbAccountType.Sorted = false;
			cmbAccountType.TabIndex = 10;
			cmbAccountType.TabStop = true;
			cmbAccountType.Visible = true;
			// 
			// cmbAgencyType
			// 
			cmbAgencyType.AllowDrop = true;
			cmbAgencyType.BackColor = System.Drawing.SystemColors.Window;
			cmbAgencyType.CausesValidation = true;
			cmbAgencyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cmbAgencyType.Enabled = true;
			cmbAgencyType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmbAgencyType.ForeColor = System.Drawing.SystemColors.WindowText;
			cmbAgencyType.IntegralHeight = true;
			cmbAgencyType.Location = new System.Drawing.Point(78, 180);
			cmbAgencyType.Name = "cmbAgencyType";
			cmbAgencyType.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmbAgencyType.Size = new System.Drawing.Size(125, 21);
			cmbAgencyType.Sorted = false;
			cmbAgencyType.TabIndex = 9;
			cmbAgencyType.TabStop = true;
			cmbAgencyType.Visible = true;
			// 
			// frmButtons
			// 
			frmButtons.AllowDrop = true;
			frmButtons.BackColor = System.Drawing.SystemColors.Control;
			frmButtons.Controls.Add(cmdClose);
			frmButtons.Controls.Add(cmdAdd);
			frmButtons.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmButtons.Enabled = true;
			frmButtons.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmButtons.ForeColor = System.Drawing.SystemColors.ControlText;
			frmButtons.Location = new System.Drawing.Point(362, 274);
			frmButtons.Name = "frmButtons";
			frmButtons.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmButtons.Size = new System.Drawing.Size(89, 87);
			frmButtons.TabIndex = 68;
			frmButtons.Visible = true;
			// 
			// cmdClose
			// 
			cmdClose.AllowDrop = true;
			cmdClose.BackColor = System.Drawing.SystemColors.Control;
			cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdClose.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdClose.Location = new System.Drawing.Point(18, 54);
			cmdClose.Name = "cmdClose";
			cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdClose.Size = new System.Drawing.Size(47, 21);
			cmdClose.TabIndex = 70;
			cmdClose.Text = "&Close";
			cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdClose.UseVisualStyleBackColor = false;
			cmdClose.Click += new System.EventHandler(cmdClose_Click);
			// 
			// cmdAdd
			// 
			cmdAdd.AllowDrop = true;
			cmdAdd.BackColor = System.Drawing.SystemColors.Control;
			cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdAdd.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdAdd.Location = new System.Drawing.Point(18, 22);
			cmdAdd.Name = "cmdAdd";
			cmdAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdAdd.Size = new System.Drawing.Size(47, 21);
			cmdAdd.TabIndex = 69;
			cmdAdd.Text = "&Add";
			cmdAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdAdd.UseVisualStyleBackColor = false;
			cmdAdd.Click += new System.EventHandler(cmdAdd_Click);
			// 
			// txtCompEMail
			// 
			txtCompEMail.AcceptsReturn = true;
			txtCompEMail.AllowDrop = true;
			txtCompEMail.BackColor = System.Drawing.SystemColors.Window;
			txtCompEMail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtCompEMail.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtCompEMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtCompEMail.ForeColor = System.Drawing.SystemColors.WindowText;
			txtCompEMail.Location = new System.Drawing.Point(78, 156);
			txtCompEMail.MaxLength = 150;
			txtCompEMail.Name = "txtCompEMail";
			txtCompEMail.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtCompEMail.Size = new System.Drawing.Size(379, 21);
			txtCompEMail.TabIndex = 8;
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
			txtWebsite.Location = new System.Drawing.Point(78, 134);
			txtWebsite.MaxLength = 150;
			txtWebsite.Name = "txtWebsite";
			txtWebsite.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtWebsite.Size = new System.Drawing.Size(379, 21);
			txtWebsite.TabIndex = 7;
			// 
			// cmbCountry
			// 
			cmbCountry.AllowDrop = true;
			cmbCountry.BackColor = System.Drawing.SystemColors.Window;
			cmbCountry.CausesValidation = true;
			cmbCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cmbCountry.Enabled = true;
			cmbCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmbCountry.ForeColor = System.Drawing.SystemColors.WindowText;
			cmbCountry.IntegralHeight = true;
			cmbCountry.Location = new System.Drawing.Point(78, 112);
			cmbCountry.Name = "cmbCountry";
			cmbCountry.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmbCountry.Size = new System.Drawing.Size(177, 21);
			cmbCountry.Sorted = false;
			cmbCountry.TabIndex = 6;
			cmbCountry.TabStop = true;
			cmbCountry.Visible = true;
			cmbCountry.SelectionChangeCommitted += new System.EventHandler(cmbCountry_SelectionChangeCommitted);
			// 
			// txtZipCode
			// 
			txtZipCode.AcceptsReturn = true;
			txtZipCode.AllowDrop = true;
			txtZipCode.BackColor = System.Drawing.SystemColors.Window;
			txtZipCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtZipCode.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtZipCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtZipCode.ForeColor = System.Drawing.SystemColors.WindowText;
			txtZipCode.Location = new System.Drawing.Point(380, 90);
			txtZipCode.MaxLength = 10;
			txtZipCode.Name = "txtZipCode";
			txtZipCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtZipCode.Size = new System.Drawing.Size(77, 21);
			txtZipCode.TabIndex = 5;
			// 
			// cmbState
			// 
			cmbState.AllowDrop = true;
			cmbState.BackColor = System.Drawing.SystemColors.Window;
			cmbState.CausesValidation = true;
			cmbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cmbState.Enabled = true;
			cmbState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmbState.ForeColor = System.Drawing.SystemColors.WindowText;
			cmbState.IntegralHeight = true;
			cmbState.Location = new System.Drawing.Point(260, 90);
			cmbState.Name = "cmbState";
			cmbState.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmbState.Size = new System.Drawing.Size(117, 21);
			cmbState.Sorted = false;
			cmbState.TabIndex = 4;
			cmbState.TabStop = true;
			cmbState.Visible = true;
			// 
			// txtCity
			// 
			txtCity.AcceptsReturn = true;
			txtCity.AllowDrop = true;
			txtCity.BackColor = System.Drawing.SystemColors.Window;
			txtCity.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtCity.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtCity.ForeColor = System.Drawing.SystemColors.WindowText;
			txtCity.Location = new System.Drawing.Point(78, 90);
			txtCity.MaxLength = 50;
			txtCity.Name = "txtCity";
			txtCity.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtCity.Size = new System.Drawing.Size(177, 21);
			txtCity.TabIndex = 3;
			// 
			// txtAddress2
			// 
			txtAddress2.AcceptsReturn = true;
			txtAddress2.AllowDrop = true;
			txtAddress2.BackColor = System.Drawing.SystemColors.Window;
			txtAddress2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtAddress2.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtAddress2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtAddress2.ForeColor = System.Drawing.SystemColors.WindowText;
			txtAddress2.Location = new System.Drawing.Point(78, 68);
			txtAddress2.MaxLength = 50;
			txtAddress2.Name = "txtAddress2";
			txtAddress2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtAddress2.Size = new System.Drawing.Size(177, 21);
			txtAddress2.TabIndex = 2;
			// 
			// txtAddress1
			// 
			txtAddress1.AcceptsReturn = true;
			txtAddress1.AllowDrop = true;
			txtAddress1.BackColor = System.Drawing.SystemColors.Window;
			txtAddress1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtAddress1.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtAddress1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtAddress1.ForeColor = System.Drawing.SystemColors.WindowText;
			txtAddress1.Location = new System.Drawing.Point(78, 46);
			txtAddress1.MaxLength = 50;
			txtAddress1.Name = "txtAddress1";
			txtAddress1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtAddress1.Size = new System.Drawing.Size(177, 21);
			txtAddress1.TabIndex = 1;
			// 
			// txtCompany
			// 
			txtCompany.AcceptsReturn = true;
			txtCompany.AllowDrop = true;
			txtCompany.BackColor = System.Drawing.SystemColors.Window;
			txtCompany.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtCompany.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtCompany.ForeColor = System.Drawing.SystemColors.WindowText;
			txtCompany.Location = new System.Drawing.Point(78, 24);
			txtCompany.MaxLength = 100;
			txtCompany.Name = "txtCompany";
			txtCompany.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtCompany.Size = new System.Drawing.Size(379, 21);
			txtCompany.TabIndex = 0;
			// 
			// frmCompanyPhone
			// 
			frmCompanyPhone.AllowDrop = true;
			frmCompanyPhone.BackColor = System.Drawing.SystemColors.Control;
			frmCompanyPhone.Controls.Add(txtCompFaxNumber);
			frmCompanyPhone.Controls.Add(txtCompFaxPrefix);
			frmCompanyPhone.Controls.Add(txtCompFaxAreaCode);
			frmCompanyPhone.Controls.Add(txtCompFaxCountryCode);
			frmCompanyPhone.Controls.Add(txtCompOfficeNumber);
			frmCompanyPhone.Controls.Add(txtCompOfficePrefix);
			frmCompanyPhone.Controls.Add(txtCompOfficeAreaCode);
			frmCompanyPhone.Controls.Add(txtCompOfficeCountryCode);
			frmCompanyPhone.Controls.Add(_Label1_22);
			frmCompanyPhone.Controls.Add(_Label1_21);
			frmCompanyPhone.Controls.Add(_Label1_20);
			frmCompanyPhone.Controls.Add(_Label1_19);
			frmCompanyPhone.Controls.Add(_Label1_8);
			frmCompanyPhone.Controls.Add(_Label1_7);
			frmCompanyPhone.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			frmCompanyPhone.Enabled = true;
			frmCompanyPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			frmCompanyPhone.ForeColor = System.Drawing.SystemColors.ControlText;
			frmCompanyPhone.Location = new System.Drawing.Point(6, 274);
			frmCompanyPhone.Name = "frmCompanyPhone";
			frmCompanyPhone.RightToLeft = System.Windows.Forms.RightToLeft.No;
			frmCompanyPhone.Size = new System.Drawing.Size(349, 87);
			frmCompanyPhone.TabIndex = 39;
			frmCompanyPhone.Text = "Phone Numbers";
			frmCompanyPhone.Visible = true;
			// 
			// txtCompFaxNumber
			// 
			txtCompFaxNumber.AcceptsReturn = true;
			txtCompFaxNumber.AllowDrop = true;
			txtCompFaxNumber.BackColor = System.Drawing.SystemColors.Window;
			txtCompFaxNumber.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtCompFaxNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtCompFaxNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtCompFaxNumber.ForeColor = System.Drawing.SystemColors.WindowText;
			txtCompFaxNumber.Location = new System.Drawing.Point(244, 52);
			txtCompFaxNumber.MaxLength = 10;
			txtCompFaxNumber.Name = "txtCompFaxNumber";
			txtCompFaxNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtCompFaxNumber.Size = new System.Drawing.Size(91, 21);
			txtCompFaxNumber.TabIndex = 22;
			// 
			// txtCompFaxPrefix
			// 
			txtCompFaxPrefix.AcceptsReturn = true;
			txtCompFaxPrefix.AllowDrop = true;
			txtCompFaxPrefix.BackColor = System.Drawing.SystemColors.Window;
			txtCompFaxPrefix.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtCompFaxPrefix.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtCompFaxPrefix.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtCompFaxPrefix.ForeColor = System.Drawing.SystemColors.WindowText;
			txtCompFaxPrefix.Location = new System.Drawing.Point(188, 52);
			txtCompFaxPrefix.MaxLength = 6;
			txtCompFaxPrefix.Name = "txtCompFaxPrefix";
			txtCompFaxPrefix.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtCompFaxPrefix.Size = new System.Drawing.Size(47, 21);
			txtCompFaxPrefix.TabIndex = 21;
			// 
			// txtCompFaxAreaCode
			// 
			txtCompFaxAreaCode.AcceptsReturn = true;
			txtCompFaxAreaCode.AllowDrop = true;
			txtCompFaxAreaCode.BackColor = System.Drawing.SystemColors.Window;
			txtCompFaxAreaCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtCompFaxAreaCode.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtCompFaxAreaCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtCompFaxAreaCode.ForeColor = System.Drawing.SystemColors.WindowText;
			txtCompFaxAreaCode.Location = new System.Drawing.Point(130, 52);
			txtCompFaxAreaCode.MaxLength = 6;
			txtCompFaxAreaCode.Name = "txtCompFaxAreaCode";
			txtCompFaxAreaCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtCompFaxAreaCode.Size = new System.Drawing.Size(47, 21);
			txtCompFaxAreaCode.TabIndex = 20;
			// 
			// txtCompFaxCountryCode
			// 
			txtCompFaxCountryCode.AcceptsReturn = true;
			txtCompFaxCountryCode.AllowDrop = true;
			txtCompFaxCountryCode.BackColor = System.Drawing.SystemColors.Window;
			txtCompFaxCountryCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtCompFaxCountryCode.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtCompFaxCountryCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtCompFaxCountryCode.ForeColor = System.Drawing.SystemColors.WindowText;
			txtCompFaxCountryCode.Location = new System.Drawing.Point(66, 52);
			txtCompFaxCountryCode.MaxLength = 6;
			txtCompFaxCountryCode.Name = "txtCompFaxCountryCode";
			txtCompFaxCountryCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtCompFaxCountryCode.Size = new System.Drawing.Size(47, 21);
			txtCompFaxCountryCode.TabIndex = 19;
			// 
			// txtCompOfficeNumber
			// 
			txtCompOfficeNumber.AcceptsReturn = true;
			txtCompOfficeNumber.AllowDrop = true;
			txtCompOfficeNumber.BackColor = System.Drawing.SystemColors.Window;
			txtCompOfficeNumber.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtCompOfficeNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtCompOfficeNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtCompOfficeNumber.ForeColor = System.Drawing.SystemColors.WindowText;
			txtCompOfficeNumber.Location = new System.Drawing.Point(244, 30);
			txtCompOfficeNumber.MaxLength = 10;
			txtCompOfficeNumber.Name = "txtCompOfficeNumber";
			txtCompOfficeNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtCompOfficeNumber.Size = new System.Drawing.Size(91, 21);
			txtCompOfficeNumber.TabIndex = 18;
			// 
			// txtCompOfficePrefix
			// 
			txtCompOfficePrefix.AcceptsReturn = true;
			txtCompOfficePrefix.AllowDrop = true;
			txtCompOfficePrefix.BackColor = System.Drawing.SystemColors.Window;
			txtCompOfficePrefix.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtCompOfficePrefix.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtCompOfficePrefix.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtCompOfficePrefix.ForeColor = System.Drawing.SystemColors.WindowText;
			txtCompOfficePrefix.Location = new System.Drawing.Point(188, 30);
			txtCompOfficePrefix.MaxLength = 6;
			txtCompOfficePrefix.Name = "txtCompOfficePrefix";
			txtCompOfficePrefix.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtCompOfficePrefix.Size = new System.Drawing.Size(47, 21);
			txtCompOfficePrefix.TabIndex = 17;
			// 
			// txtCompOfficeAreaCode
			// 
			txtCompOfficeAreaCode.AcceptsReturn = true;
			txtCompOfficeAreaCode.AllowDrop = true;
			txtCompOfficeAreaCode.BackColor = System.Drawing.SystemColors.Window;
			txtCompOfficeAreaCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtCompOfficeAreaCode.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtCompOfficeAreaCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtCompOfficeAreaCode.ForeColor = System.Drawing.SystemColors.WindowText;
			txtCompOfficeAreaCode.Location = new System.Drawing.Point(130, 30);
			txtCompOfficeAreaCode.MaxLength = 6;
			txtCompOfficeAreaCode.Name = "txtCompOfficeAreaCode";
			txtCompOfficeAreaCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtCompOfficeAreaCode.Size = new System.Drawing.Size(47, 21);
			txtCompOfficeAreaCode.TabIndex = 16;
			// 
			// txtCompOfficeCountryCode
			// 
			txtCompOfficeCountryCode.AcceptsReturn = true;
			txtCompOfficeCountryCode.AllowDrop = true;
			txtCompOfficeCountryCode.BackColor = System.Drawing.SystemColors.Window;
			txtCompOfficeCountryCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txtCompOfficeCountryCode.Cursor = System.Windows.Forms.Cursors.IBeam;
			txtCompOfficeCountryCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtCompOfficeCountryCode.ForeColor = System.Drawing.SystemColors.WindowText;
			txtCompOfficeCountryCode.Location = new System.Drawing.Point(66, 30);
			txtCompOfficeCountryCode.MaxLength = 6;
			txtCompOfficeCountryCode.Name = "txtCompOfficeCountryCode";
			txtCompOfficeCountryCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txtCompOfficeCountryCode.Size = new System.Drawing.Size(47, 21);
			txtCompOfficeCountryCode.TabIndex = 15;
			// 
			// _Label1_22
			// 
			_Label1_22.AllowDrop = true;
			_Label1_22.BackColor = System.Drawing.SystemColors.Control;
			_Label1_22.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_22.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_22.Location = new System.Drawing.Point(244, 14);
			_Label1_22.MinimumSize = new System.Drawing.Size(53, 17);
			_Label1_22.Name = "_Label1_22";
			_Label1_22.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_22.Size = new System.Drawing.Size(53, 17);
			_Label1_22.TabIndex = 60;
			_Label1_22.Text = "Number";
			// 
			// _Label1_21
			// 
			_Label1_21.AllowDrop = true;
			_Label1_21.BackColor = System.Drawing.SystemColors.Control;
			_Label1_21.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_21.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_21.Location = new System.Drawing.Point(188, 14);
			_Label1_21.MinimumSize = new System.Drawing.Size(53, 17);
			_Label1_21.Name = "_Label1_21";
			_Label1_21.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_21.Size = new System.Drawing.Size(53, 17);
			_Label1_21.TabIndex = 59;
			_Label1_21.Text = "Prefix";
			// 
			// _Label1_20
			// 
			_Label1_20.AllowDrop = true;
			_Label1_20.BackColor = System.Drawing.SystemColors.Control;
			_Label1_20.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_20.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_20.Location = new System.Drawing.Point(130, 14);
			_Label1_20.MinimumSize = new System.Drawing.Size(53, 17);
			_Label1_20.Name = "_Label1_20";
			_Label1_20.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_20.Size = new System.Drawing.Size(53, 17);
			_Label1_20.TabIndex = 58;
			_Label1_20.Text = "Area";
			// 
			// _Label1_19
			// 
			_Label1_19.AllowDrop = true;
			_Label1_19.BackColor = System.Drawing.SystemColors.Control;
			_Label1_19.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_19.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_19.Location = new System.Drawing.Point(66, 14);
			_Label1_19.MinimumSize = new System.Drawing.Size(53, 17);
			_Label1_19.Name = "_Label1_19";
			_Label1_19.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_19.Size = new System.Drawing.Size(53, 17);
			_Label1_19.TabIndex = 57;
			_Label1_19.Text = "Country";
			// 
			// _Label1_8
			// 
			_Label1_8.AllowDrop = true;
			_Label1_8.BackColor = System.Drawing.SystemColors.Control;
			_Label1_8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_8.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_8.Location = new System.Drawing.Point(12, 54);
			_Label1_8.MinimumSize = new System.Drawing.Size(45, 17);
			_Label1_8.Name = "_Label1_8";
			_Label1_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_8.Size = new System.Drawing.Size(45, 17);
			_Label1_8.TabIndex = 48;
			_Label1_8.Text = "Fax";
			// 
			// _Label1_7
			// 
			_Label1_7.AllowDrop = true;
			_Label1_7.BackColor = System.Drawing.SystemColors.Control;
			_Label1_7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_7.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_7.Location = new System.Drawing.Point(12, 34);
			_Label1_7.MinimumSize = new System.Drawing.Size(45, 17);
			_Label1_7.Name = "_Label1_7";
			_Label1_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_7.Size = new System.Drawing.Size(45, 17);
			_Label1_7.TabIndex = 47;
			_Label1_7.Text = "Office";
			// 
			// _Label1_32
			// 
			_Label1_32.AllowDrop = true;
			_Label1_32.BackColor = System.Drawing.SystemColors.Control;
			_Label1_32.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_32.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_32.Location = new System.Drawing.Point(10, 230);
			_Label1_32.MinimumSize = new System.Drawing.Size(53, 17);
			_Label1_32.Name = "_Label1_32";
			_Label1_32.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_32.Size = new System.Drawing.Size(53, 17);
			_Label1_32.TabIndex = 77;
			_Label1_32.Text = "Language";
			// 
			// _Label1_31
			// 
			_Label1_31.AllowDrop = true;
			_Label1_31.BackColor = System.Drawing.SystemColors.Control;
			_Label1_31.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_31.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_31.Location = new System.Drawing.Point(208, 208);
			_Label1_31.MinimumSize = new System.Drawing.Size(71, 17);
			_Label1_31.Name = "_Label1_31";
			_Label1_31.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_31.Size = new System.Drawing.Size(71, 17);
			_Label1_31.TabIndex = 76;
			_Label1_31.Text = "Business Type";
			// 
			// _Label1_30
			// 
			_Label1_30.AllowDrop = true;
			_Label1_30.BackColor = System.Drawing.SystemColors.Control;
			_Label1_30.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_30.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_30.Location = new System.Drawing.Point(10, 208);
			_Label1_30.MinimumSize = new System.Drawing.Size(63, 17);
			_Label1_30.Name = "_Label1_30";
			_Label1_30.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_30.Size = new System.Drawing.Size(63, 17);
			_Label1_30.TabIndex = 75;
			_Label1_30.Text = "Account Rep";
			// 
			// _Label1_29
			// 
			_Label1_29.AllowDrop = true;
			_Label1_29.BackColor = System.Drawing.SystemColors.Control;
			_Label1_29.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_29.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_29.Location = new System.Drawing.Point(208, 186);
			_Label1_29.MinimumSize = new System.Drawing.Size(71, 17);
			_Label1_29.Name = "_Label1_29";
			_Label1_29.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_29.Size = new System.Drawing.Size(71, 17);
			_Label1_29.TabIndex = 74;
			_Label1_29.Text = "Account Type";
			// 
			// _Label1_28
			// 
			_Label1_28.AllowDrop = true;
			_Label1_28.BackColor = System.Drawing.SystemColors.Control;
			_Label1_28.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_28.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_28.Location = new System.Drawing.Point(10, 186);
			_Label1_28.MinimumSize = new System.Drawing.Size(63, 17);
			_Label1_28.Name = "_Label1_28";
			_Label1_28.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_28.Size = new System.Drawing.Size(63, 17);
			_Label1_28.TabIndex = 73;
			_Label1_28.Text = "Agency Type";
			// 
			// _Label1_10
			// 
			_Label1_10.AllowDrop = true;
			_Label1_10.BackColor = System.Drawing.SystemColors.Control;
			_Label1_10.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_10.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_10.Location = new System.Drawing.Point(10, 162);
			_Label1_10.MinimumSize = new System.Drawing.Size(45, 17);
			_Label1_10.Name = "_Label1_10";
			_Label1_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_10.Size = new System.Drawing.Size(45, 17);
			_Label1_10.TabIndex = 50;
			_Label1_10.Text = "EMail";
			// 
			// _Label1_9
			// 
			_Label1_9.AllowDrop = true;
			_Label1_9.BackColor = System.Drawing.SystemColors.Control;
			_Label1_9.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_9.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_9.Location = new System.Drawing.Point(10, 140);
			_Label1_9.MinimumSize = new System.Drawing.Size(45, 17);
			_Label1_9.Name = "_Label1_9";
			_Label1_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_9.Size = new System.Drawing.Size(45, 17);
			_Label1_9.TabIndex = 49;
			_Label1_9.Text = "Website";
			// 
			// _Label1_6
			// 
			_Label1_6.AllowDrop = true;
			_Label1_6.BackColor = System.Drawing.SystemColors.Control;
			_Label1_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_6.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_6.Location = new System.Drawing.Point(10, 118);
			_Label1_6.MinimumSize = new System.Drawing.Size(45, 17);
			_Label1_6.Name = "_Label1_6";
			_Label1_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_6.Size = new System.Drawing.Size(45, 17);
			_Label1_6.TabIndex = 46;
			_Label1_6.Text = "Country";
			// 
			// _Label1_5
			// 
			_Label1_5.AllowDrop = true;
			_Label1_5.BackColor = System.Drawing.SystemColors.Control;
			_Label1_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_5.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_5.Location = new System.Drawing.Point(382, 74);
			_Label1_5.MinimumSize = new System.Drawing.Size(45, 17);
			_Label1_5.Name = "_Label1_5";
			_Label1_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_5.Size = new System.Drawing.Size(45, 17);
			_Label1_5.TabIndex = 45;
			_Label1_5.Text = "ZipCode";
			// 
			// _Label1_4
			// 
			_Label1_4.AllowDrop = true;
			_Label1_4.BackColor = System.Drawing.SystemColors.Control;
			_Label1_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_4.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_4.Location = new System.Drawing.Point(260, 74);
			_Label1_4.MinimumSize = new System.Drawing.Size(33, 17);
			_Label1_4.Name = "_Label1_4";
			_Label1_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_4.Size = new System.Drawing.Size(33, 17);
			_Label1_4.TabIndex = 44;
			_Label1_4.Text = "State";
			// 
			// _Label1_3
			// 
			_Label1_3.AllowDrop = true;
			_Label1_3.BackColor = System.Drawing.SystemColors.Control;
			_Label1_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_3.Location = new System.Drawing.Point(10, 96);
			_Label1_3.MinimumSize = new System.Drawing.Size(45, 17);
			_Label1_3.Name = "_Label1_3";
			_Label1_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_3.Size = new System.Drawing.Size(45, 17);
			_Label1_3.TabIndex = 43;
			_Label1_3.Text = "City";
			// 
			// _Label1_2
			// 
			_Label1_2.AllowDrop = true;
			_Label1_2.BackColor = System.Drawing.SystemColors.Control;
			_Label1_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_2.Location = new System.Drawing.Point(10, 74);
			_Label1_2.MinimumSize = new System.Drawing.Size(45, 17);
			_Label1_2.Name = "_Label1_2";
			_Label1_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_2.Size = new System.Drawing.Size(45, 17);
			_Label1_2.TabIndex = 42;
			_Label1_2.Text = "Address2";
			// 
			// _Label1_1
			// 
			_Label1_1.AllowDrop = true;
			_Label1_1.BackColor = System.Drawing.SystemColors.Control;
			_Label1_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_1.Location = new System.Drawing.Point(10, 48);
			_Label1_1.MinimumSize = new System.Drawing.Size(45, 17);
			_Label1_1.Name = "_Label1_1";
			_Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_1.Size = new System.Drawing.Size(45, 17);
			_Label1_1.TabIndex = 41;
			_Label1_1.Text = "Address1";
			// 
			// _Label1_0
			// 
			_Label1_0.AllowDrop = true;
			_Label1_0.BackColor = System.Drawing.SystemColors.Control;
			_Label1_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_Label1_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_Label1_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_Label1_0.Location = new System.Drawing.Point(10, 26);
			_Label1_0.MinimumSize = new System.Drawing.Size(37, 17);
			_Label1_0.Name = "_Label1_0";
			_Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1_0.Size = new System.Drawing.Size(37, 17);
			_Label1_0.TabIndex = 40;
			_Label1_0.Text = "Name";
			// 
			// frmCompanyAdd
			// 
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			ClientSize = new System.Drawing.Size(504, 709);
			Controls.Add(frmContact);
			Controls.Add(frmComopany);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Location = new System.Drawing.Point(589, 175);
			MaximizeBox = true;
			MinimizeBox = true;
			Name = "frmCompanyAdd";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			Text = "Yacht Company - Add New Record";
			commandButtonHelper1.SetStyle(cmdClose, 0);
			commandButtonHelper1.SetStyle(cmdAdd, 0);
			ToolTipMain.SetToolTip(chkCompContactAddressFlag, "Check If This Company Record Is A Contact Address Record");
			ToolTipMain.SetToolTip(cmdClose, "Close The Company Add New Record Form");
			ToolTipMain.SetToolTip(cmdAdd, "Add The New Company Record");
			Activated += new System.EventHandler(frmCompanyAdd_Activated);
			Closed += new System.EventHandler(Form_Closed);
			frmContact.ResumeLayout(false);
			frmContact.PerformLayout();
			frmContactPhone.ResumeLayout(false);
			frmContactPhone.PerformLayout();
			frmComopany.ResumeLayout(false);
			frmComopany.PerformLayout();
			frmButtons.ResumeLayout(false);
			frmButtons.PerformLayout();
			frmCompanyPhone.ResumeLayout(false);
			frmCompanyPhone.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
		void ReLoadForm(bool addEvents) => InitializeLabel1();

		void InitializeLabel1()
		{
			Label1 = new System.Windows.Forms.Label[33];
			Label1[26] = _Label1_26;
			Label1[25] = _Label1_25;
			Label1[24] = _Label1_24;
			Label1[23] = _Label1_23;
			Label1[18] = _Label1_18;
			Label1[17] = _Label1_17;
			Label1[27] = _Label1_27;
			Label1[16] = _Label1_16;
			Label1[15] = _Label1_15;
			Label1[14] = _Label1_14;
			Label1[13] = _Label1_13;
			Label1[12] = _Label1_12;
			Label1[11] = _Label1_11;
			Label1[22] = _Label1_22;
			Label1[21] = _Label1_21;
			Label1[20] = _Label1_20;
			Label1[19] = _Label1_19;
			Label1[8] = _Label1_8;
			Label1[7] = _Label1_7;
			Label1[32] = _Label1_32;
			Label1[31] = _Label1_31;
			Label1[30] = _Label1_30;
			Label1[29] = _Label1_29;
			Label1[28] = _Label1_28;
			Label1[10] = _Label1_10;
			Label1[9] = _Label1_9;
			Label1[6] = _Label1_6;
			Label1[5] = _Label1_5;
			Label1[4] = _Label1_4;
			Label1[3] = _Label1_3;
			Label1[2] = _Label1_2;
			Label1[1] = _Label1_1;
			Label1[0] = _Label1_0;
		}
		#endregion
	}
}