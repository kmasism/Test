
namespace JETNET_Homebase
{
	partial class frm_AddAircraft
	{

		#region "Upgrade Support "
		private static frm_AddAircraft m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_AddAircraft DefInstance
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
		public static frm_AddAircraft CreateInstance()
		{
			frm_AddAircraft theInstance = new frm_AddAircraft();
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
		private string[] visualControls = new string[]{"components", "ToolTipMain", "mnuClose", "mnuLogout", "mnuFile", "MainMenu1", "cmd_override", "cboCountry", "cboState", "chkAwaitingDocs", "cmdFindManufacturer", "lstManufacturer", "lblCountry", "lblState", "pnl_Manufacturer", "cbo_usage", "chk_Exclusive_Flag", "chk_forsale", "chk_ac_previously_owned_flag", "txt_model_config", "cbo_ac_stage", "cbo_ac_status", "txt_ac_purchase_date", "txt_exclusive_verify_date", "cbo_ac_owner_type", "txt_ac_foreign_currency_price", "cbo_ac_foreign_currency_name", "txt_ac_delivery_date", "cbo_ac_asking", "txt_ac_asking_price", "txt_ac_list_date", "cbo_ac_delivery", "_lbl_gen_33", "_lbl_gen_32", "_lbl_gen_31", "_lbl_gen_17", "_lbl_gen_9", "_lbl_gen_10", "_lbl_gen_6", "pnl_Sale_Data", "lbl_usage", "Label1", "_lbl_gen_8", "_lbl_gen_7", "_lbl_gen_11", "_lbl_gen_1", "_lbl_gen_2", "pnlStatusInfo", "cmdCancel", "cmdSave", "cbo_ac_country_of_registration", "cbo_amod_make_name", "txt_amod_type_code", "_lblMakeModel_1", "_lbl_gen_0", "_lblMakeModel_0", "_pnl_gen_5", "_txt_ac_engine_tbo_hrs_1", "_txt_ac_engine_tbo_hrs_3", "_txt_ac_engine_tbo_hrs_2", "_txt_ac_engine_tbo_hrs_0", "txt_engine_noise_rating", "cbo_ac_engine_name", "chk_oncondtbo", "_lbl_engine_8", "_lbl_engine_10", "_lbl_engine_7", "_lbl_engine_9", "Label2", "_lbl_gen_19", "_lbl_gen_26", "_pnl_gen_1", "_ac_product_chk_0", "_ac_product_chk_1", "_ac_product_chk_2", "_ac_product_chk_4", "_ac_product_chk_5", "_ac_product_chk_3", "SSPanel_productCode", "_txtBaseCode_3", "cboBaseCountry", "cboBaseState", "chk_ac_aport_private", "_txtBaseCode_5", "chkHyphen", "_txtBaseCode_0", "_txtBaseCode_1", "_txtBaseCode_2", "txt_ac_mfr_year", "txt_ac_year", "txt_ac_reg_no", "txt_ac_ser_no_prefix", "txt_ac_id", "txt_ac_prev_reg_no", "txt_ac_ser_no", "txt_ac_ser_no_suffix", "txt_ac_alt_ser_no_prefix", "txt_ac_alt_ser_no", "txt_ac_alt_ser_no_suffix", "_lbl_gen_14", "_lbl_gen_13", "_lbl_gen_12", "_lbl_gen_66", "_lbl_gen_67", "_lbl_gen_68", "_lbl_gen_69", "_lbl_gen_74", "_lbl_gen_240", "_lbl_gen_5", "_lbl_gen_4", "_lbl_gen_3", "_lbl_gen_241", "_lbl_gen_30", "_pnl_gen_0", "ac_product_chk", "lblMakeModel", "lbl_engine", "lbl_gen", "pnl_gen", "txtBaseCode", "txt_ac_engine_tbo_hrs", "listBoxHelper1", "commandButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.ToolStripMenuItem mnuClose;
		public System.Windows.Forms.ToolStripMenuItem mnuLogout;
		public System.Windows.Forms.ToolStripMenuItem mnuFile;
		public System.Windows.Forms.MenuStrip MainMenu1;
		public System.Windows.Forms.Button cmd_override;
		public System.Windows.Forms.ComboBox cboCountry;
		public System.Windows.Forms.ComboBox cboState;
		public System.Windows.Forms.CheckBox chkAwaitingDocs;
		public System.Windows.Forms.Button cmdFindManufacturer;
		public System.Windows.Forms.ListBox lstManufacturer;
		public System.Windows.Forms.Label lblCountry;
		public System.Windows.Forms.Label lblState;
		public System.Windows.Forms.Panel pnl_Manufacturer;
		public System.Windows.Forms.ComboBox cbo_usage;
		public System.Windows.Forms.CheckBox chk_Exclusive_Flag;
		public System.Windows.Forms.CheckBox chk_forsale;
		public System.Windows.Forms.CheckBox chk_ac_previously_owned_flag;
		public System.Windows.Forms.TextBox txt_model_config;
		public System.Windows.Forms.ComboBox cbo_ac_stage;
		public System.Windows.Forms.ComboBox cbo_ac_status;
		public System.Windows.Forms.TextBox txt_ac_purchase_date;
		public System.Windows.Forms.TextBox txt_exclusive_verify_date;
		public System.Windows.Forms.ComboBox cbo_ac_owner_type;
		public System.Windows.Forms.TextBox txt_ac_foreign_currency_price;
		public System.Windows.Forms.ComboBox cbo_ac_foreign_currency_name;
		public System.Windows.Forms.TextBox txt_ac_delivery_date;
		public System.Windows.Forms.ComboBox cbo_ac_asking;
		public System.Windows.Forms.TextBox txt_ac_asking_price;
		public System.Windows.Forms.TextBox txt_ac_list_date;
		public System.Windows.Forms.ComboBox cbo_ac_delivery;
		private System.Windows.Forms.Label _lbl_gen_33;
		private System.Windows.Forms.Label _lbl_gen_32;
		private System.Windows.Forms.Label _lbl_gen_31;
		private System.Windows.Forms.Label _lbl_gen_17;
		private System.Windows.Forms.Label _lbl_gen_9;
		private System.Windows.Forms.Label _lbl_gen_10;
		private System.Windows.Forms.Label _lbl_gen_6;
		public System.Windows.Forms.Panel pnl_Sale_Data;
		public System.Windows.Forms.Label lbl_usage;
		public System.Windows.Forms.Label Label1;
		private System.Windows.Forms.Label _lbl_gen_8;
		private System.Windows.Forms.Label _lbl_gen_7;
		private System.Windows.Forms.Label _lbl_gen_11;
		private System.Windows.Forms.Label _lbl_gen_1;
		private System.Windows.Forms.Label _lbl_gen_2;
		public System.Windows.Forms.Panel pnlStatusInfo;
		public System.Windows.Forms.Button cmdCancel;
		public System.Windows.Forms.Button cmdSave;
		public System.Windows.Forms.ComboBox cbo_ac_country_of_registration;
		public System.Windows.Forms.ComboBox cbo_amod_make_name;
		public System.Windows.Forms.TextBox txt_amod_type_code;
		private System.Windows.Forms.Label _lblMakeModel_1;
		private System.Windows.Forms.Label _lbl_gen_0;
		private System.Windows.Forms.Label _lblMakeModel_0;
		private System.Windows.Forms.Panel _pnl_gen_5;
		private System.Windows.Forms.TextBox _txt_ac_engine_tbo_hrs_1;
		private System.Windows.Forms.TextBox _txt_ac_engine_tbo_hrs_3;
		private System.Windows.Forms.TextBox _txt_ac_engine_tbo_hrs_2;
		private System.Windows.Forms.TextBox _txt_ac_engine_tbo_hrs_0;
		public System.Windows.Forms.TextBox txt_engine_noise_rating;
		public System.Windows.Forms.ComboBox cbo_ac_engine_name;
		public System.Windows.Forms.CheckBox chk_oncondtbo;
		private System.Windows.Forms.Label _lbl_engine_8;
		private System.Windows.Forms.Label _lbl_engine_10;
		private System.Windows.Forms.Label _lbl_engine_7;
		private System.Windows.Forms.Label _lbl_engine_9;
		public System.Windows.Forms.Label Label2;
		private System.Windows.Forms.Label _lbl_gen_19;
		private System.Windows.Forms.Label _lbl_gen_26;
		private System.Windows.Forms.Panel _pnl_gen_1;
		private System.Windows.Forms.CheckBox _ac_product_chk_0;
		private System.Windows.Forms.CheckBox _ac_product_chk_1;
		private System.Windows.Forms.CheckBox _ac_product_chk_2;
		private System.Windows.Forms.CheckBox _ac_product_chk_4;
		private System.Windows.Forms.CheckBox _ac_product_chk_5;
		private System.Windows.Forms.CheckBox _ac_product_chk_3;
		public System.Windows.Forms.Panel SSPanel_productCode;
		private System.Windows.Forms.TextBox _txtBaseCode_3;
		public System.Windows.Forms.ComboBox cboBaseCountry;
		public System.Windows.Forms.ComboBox cboBaseState;
		public System.Windows.Forms.CheckBox chk_ac_aport_private;
		private System.Windows.Forms.TextBox _txtBaseCode_5;
		public System.Windows.Forms.CheckBox chkHyphen;
		private System.Windows.Forms.TextBox _txtBaseCode_0;
		private System.Windows.Forms.TextBox _txtBaseCode_1;
		private System.Windows.Forms.TextBox _txtBaseCode_2;
		public System.Windows.Forms.TextBox txt_ac_mfr_year;
		public System.Windows.Forms.TextBox txt_ac_year;
		public System.Windows.Forms.TextBox txt_ac_reg_no;
		public System.Windows.Forms.TextBox txt_ac_ser_no_prefix;
		public System.Windows.Forms.TextBox txt_ac_id;
		public System.Windows.Forms.TextBox txt_ac_prev_reg_no;
		public System.Windows.Forms.TextBox txt_ac_ser_no;
		public System.Windows.Forms.TextBox txt_ac_ser_no_suffix;
		public System.Windows.Forms.TextBox txt_ac_alt_ser_no_prefix;
		public System.Windows.Forms.TextBox txt_ac_alt_ser_no;
		public System.Windows.Forms.TextBox txt_ac_alt_ser_no_suffix;
		private System.Windows.Forms.Label _lbl_gen_14;
		private System.Windows.Forms.Label _lbl_gen_13;
		private System.Windows.Forms.Label _lbl_gen_12;
		private System.Windows.Forms.Label _lbl_gen_66;
		private System.Windows.Forms.Label _lbl_gen_67;
		private System.Windows.Forms.Label _lbl_gen_68;
		private System.Windows.Forms.Label _lbl_gen_69;
		private System.Windows.Forms.Label _lbl_gen_74;
		private System.Windows.Forms.Label _lbl_gen_240;
		private System.Windows.Forms.Label _lbl_gen_5;
		private System.Windows.Forms.Label _lbl_gen_4;
		private System.Windows.Forms.Label _lbl_gen_3;
		private System.Windows.Forms.Label _lbl_gen_241;
		private System.Windows.Forms.Label _lbl_gen_30;
		private System.Windows.Forms.Panel _pnl_gen_0;
		public System.Windows.Forms.CheckBox[] ac_product_chk = new System.Windows.Forms.CheckBox[6];
		public System.Windows.Forms.Label[] lblMakeModel = new System.Windows.Forms.Label[2];
		public System.Windows.Forms.Label[] lbl_engine = new System.Windows.Forms.Label[11];
		public System.Windows.Forms.Label[] lbl_gen = new System.Windows.Forms.Label[242];
		public System.Windows.Forms.Panel[] pnl_gen = new System.Windows.Forms.Panel[6];
		public System.Windows.Forms.TextBox[] txtBaseCode = new System.Windows.Forms.TextBox[6];
		public System.Windows.Forms.TextBox[] txt_ac_engine_tbo_hrs = new System.Windows.Forms.TextBox[4];
		public UpgradeHelpers.Gui.Controls.ListBoxHelper listBoxHelper1;
		public UpgradeHelpers.Gui.Controls.CommandButtonHelper commandButtonHelper1;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_AddAircraft));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			MainMenu1 = new System.Windows.Forms.MenuStrip();
			mnuFile = new System.Windows.Forms.ToolStripMenuItem();
			mnuClose = new System.Windows.Forms.ToolStripMenuItem();
			mnuLogout = new System.Windows.Forms.ToolStripMenuItem();
			cmd_override = new System.Windows.Forms.Button();
			pnl_Manufacturer = new System.Windows.Forms.Panel();
			cboCountry = new System.Windows.Forms.ComboBox();
			cboState = new System.Windows.Forms.ComboBox();
			chkAwaitingDocs = new System.Windows.Forms.CheckBox();
			cmdFindManufacturer = new System.Windows.Forms.Button();
			lstManufacturer = new System.Windows.Forms.ListBox();
			lblCountry = new System.Windows.Forms.Label();
			lblState = new System.Windows.Forms.Label();
			pnlStatusInfo = new System.Windows.Forms.Panel();
			cbo_usage = new System.Windows.Forms.ComboBox();
			chk_Exclusive_Flag = new System.Windows.Forms.CheckBox();
			chk_forsale = new System.Windows.Forms.CheckBox();
			chk_ac_previously_owned_flag = new System.Windows.Forms.CheckBox();
			txt_model_config = new System.Windows.Forms.TextBox();
			cbo_ac_stage = new System.Windows.Forms.ComboBox();
			cbo_ac_status = new System.Windows.Forms.ComboBox();
			txt_ac_purchase_date = new System.Windows.Forms.TextBox();
			txt_exclusive_verify_date = new System.Windows.Forms.TextBox();
			cbo_ac_owner_type = new System.Windows.Forms.ComboBox();
			pnl_Sale_Data = new System.Windows.Forms.Panel();
			txt_ac_foreign_currency_price = new System.Windows.Forms.TextBox();
			cbo_ac_foreign_currency_name = new System.Windows.Forms.ComboBox();
			txt_ac_delivery_date = new System.Windows.Forms.TextBox();
			cbo_ac_asking = new System.Windows.Forms.ComboBox();
			txt_ac_asking_price = new System.Windows.Forms.TextBox();
			txt_ac_list_date = new System.Windows.Forms.TextBox();
			cbo_ac_delivery = new System.Windows.Forms.ComboBox();
			_lbl_gen_33 = new System.Windows.Forms.Label();
			_lbl_gen_32 = new System.Windows.Forms.Label();
			_lbl_gen_31 = new System.Windows.Forms.Label();
			_lbl_gen_17 = new System.Windows.Forms.Label();
			_lbl_gen_9 = new System.Windows.Forms.Label();
			_lbl_gen_10 = new System.Windows.Forms.Label();
			_lbl_gen_6 = new System.Windows.Forms.Label();
			lbl_usage = new System.Windows.Forms.Label();
			Label1 = new System.Windows.Forms.Label();
			_lbl_gen_8 = new System.Windows.Forms.Label();
			_lbl_gen_7 = new System.Windows.Forms.Label();
			_lbl_gen_11 = new System.Windows.Forms.Label();
			_lbl_gen_1 = new System.Windows.Forms.Label();
			_lbl_gen_2 = new System.Windows.Forms.Label();
			cmdCancel = new System.Windows.Forms.Button();
			cmdSave = new System.Windows.Forms.Button();
			_pnl_gen_5 = new System.Windows.Forms.Panel();
			cbo_ac_country_of_registration = new System.Windows.Forms.ComboBox();
			cbo_amod_make_name = new System.Windows.Forms.ComboBox();
			txt_amod_type_code = new System.Windows.Forms.TextBox();
			_lblMakeModel_1 = new System.Windows.Forms.Label();
			_lbl_gen_0 = new System.Windows.Forms.Label();
			_lblMakeModel_0 = new System.Windows.Forms.Label();
			_pnl_gen_1 = new System.Windows.Forms.Panel();
			_txt_ac_engine_tbo_hrs_1 = new System.Windows.Forms.TextBox();
			_txt_ac_engine_tbo_hrs_3 = new System.Windows.Forms.TextBox();
			_txt_ac_engine_tbo_hrs_2 = new System.Windows.Forms.TextBox();
			_txt_ac_engine_tbo_hrs_0 = new System.Windows.Forms.TextBox();
			txt_engine_noise_rating = new System.Windows.Forms.TextBox();
			cbo_ac_engine_name = new System.Windows.Forms.ComboBox();
			chk_oncondtbo = new System.Windows.Forms.CheckBox();
			_lbl_engine_8 = new System.Windows.Forms.Label();
			_lbl_engine_10 = new System.Windows.Forms.Label();
			_lbl_engine_7 = new System.Windows.Forms.Label();
			_lbl_engine_9 = new System.Windows.Forms.Label();
			Label2 = new System.Windows.Forms.Label();
			_lbl_gen_19 = new System.Windows.Forms.Label();
			_lbl_gen_26 = new System.Windows.Forms.Label();
			SSPanel_productCode = new System.Windows.Forms.Panel();
			_ac_product_chk_0 = new System.Windows.Forms.CheckBox();
			_ac_product_chk_1 = new System.Windows.Forms.CheckBox();
			_ac_product_chk_2 = new System.Windows.Forms.CheckBox();
			_ac_product_chk_4 = new System.Windows.Forms.CheckBox();
			_ac_product_chk_5 = new System.Windows.Forms.CheckBox();
			_ac_product_chk_3 = new System.Windows.Forms.CheckBox();
			_pnl_gen_0 = new System.Windows.Forms.Panel();
			_txtBaseCode_3 = new System.Windows.Forms.TextBox();
			cboBaseCountry = new System.Windows.Forms.ComboBox();
			cboBaseState = new System.Windows.Forms.ComboBox();
			chk_ac_aport_private = new System.Windows.Forms.CheckBox();
			_txtBaseCode_5 = new System.Windows.Forms.TextBox();
			chkHyphen = new System.Windows.Forms.CheckBox();
			_txtBaseCode_0 = new System.Windows.Forms.TextBox();
			_txtBaseCode_1 = new System.Windows.Forms.TextBox();
			_txtBaseCode_2 = new System.Windows.Forms.TextBox();
			txt_ac_mfr_year = new System.Windows.Forms.TextBox();
			txt_ac_year = new System.Windows.Forms.TextBox();
			txt_ac_reg_no = new System.Windows.Forms.TextBox();
			txt_ac_ser_no_prefix = new System.Windows.Forms.TextBox();
			txt_ac_id = new System.Windows.Forms.TextBox();
			txt_ac_prev_reg_no = new System.Windows.Forms.TextBox();
			txt_ac_ser_no = new System.Windows.Forms.TextBox();
			txt_ac_ser_no_suffix = new System.Windows.Forms.TextBox();
			txt_ac_alt_ser_no_prefix = new System.Windows.Forms.TextBox();
			txt_ac_alt_ser_no = new System.Windows.Forms.TextBox();
			txt_ac_alt_ser_no_suffix = new System.Windows.Forms.TextBox();
			_lbl_gen_14 = new System.Windows.Forms.Label();
			_lbl_gen_13 = new System.Windows.Forms.Label();
			_lbl_gen_12 = new System.Windows.Forms.Label();
			_lbl_gen_66 = new System.Windows.Forms.Label();
			_lbl_gen_67 = new System.Windows.Forms.Label();
			_lbl_gen_68 = new System.Windows.Forms.Label();
			_lbl_gen_69 = new System.Windows.Forms.Label();
			_lbl_gen_74 = new System.Windows.Forms.Label();
			_lbl_gen_240 = new System.Windows.Forms.Label();
			_lbl_gen_5 = new System.Windows.Forms.Label();
			_lbl_gen_4 = new System.Windows.Forms.Label();
			_lbl_gen_3 = new System.Windows.Forms.Label();
			_lbl_gen_241 = new System.Windows.Forms.Label();
			_lbl_gen_30 = new System.Windows.Forms.Label();
			pnl_Manufacturer.SuspendLayout();
			pnlStatusInfo.SuspendLayout();
			pnl_Sale_Data.SuspendLayout();
			_pnl_gen_5.SuspendLayout();
			_pnl_gen_1.SuspendLayout();
			SSPanel_productCode.SuspendLayout();
			_pnl_gen_0.SuspendLayout();
			SuspendLayout();
			listBoxHelper1 = new UpgradeHelpers.Gui.Controls.ListBoxHelper(components);
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
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
			// cmd_override
			// 
			cmd_override.AllowDrop = true;
			cmd_override.BackColor = System.Drawing.SystemColors.Control;
			cmd_override.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_override.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_override.Location = new System.Drawing.Point(896, 304);
			cmd_override.Name = "cmd_override";
			cmd_override.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_override.Size = new System.Drawing.Size(73, 25);
			cmd_override.TabIndex = 107;
			cmd_override.Text = "Override";
			cmd_override.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_override.UseVisualStyleBackColor = false;
			cmd_override.Click += new System.EventHandler(cmd_override_Click);
			// 
			// pnl_Manufacturer
			// 
			pnl_Manufacturer.AllowDrop = true;
			pnl_Manufacturer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Manufacturer.Controls.Add(cboCountry);
			pnl_Manufacturer.Controls.Add(cboState);
			pnl_Manufacturer.Controls.Add(chkAwaitingDocs);
			pnl_Manufacturer.Controls.Add(cmdFindManufacturer);
			pnl_Manufacturer.Controls.Add(lstManufacturer);
			pnl_Manufacturer.Controls.Add(lblCountry);
			pnl_Manufacturer.Controls.Add(lblState);
			pnl_Manufacturer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Manufacturer.Location = new System.Drawing.Point(590, 23);
			pnl_Manufacturer.Name = "pnl_Manufacturer";
			pnl_Manufacturer.Size = new System.Drawing.Size(385, 169);
			pnl_Manufacturer.TabIndex = 65;
			// 
			// cboCountry
			// 
			cboCountry.AllowDrop = true;
			cboCountry.BackColor = System.Drawing.SystemColors.Window;
			cboCountry.CausesValidation = true;
			cboCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cboCountry.Enabled = true;
			cboCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cboCountry.ForeColor = System.Drawing.SystemColors.WindowText;
			cboCountry.IntegralHeight = true;
			cboCountry.Location = new System.Drawing.Point(115, 66);
			cboCountry.Name = "cboCountry";
			cboCountry.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cboCountry.Size = new System.Drawing.Size(143, 21);
			cboCountry.Sorted = false;
			cboCountry.TabIndex = 68;
			cboCountry.TabStop = true;
			cboCountry.Visible = false;
			// 
			// cboState
			// 
			cboState.AllowDrop = true;
			cboState.BackColor = System.Drawing.SystemColors.Window;
			cboState.CausesValidation = true;
			cboState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cboState.Enabled = true;
			cboState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cboState.ForeColor = System.Drawing.SystemColors.WindowText;
			cboState.IntegralHeight = true;
			cboState.Location = new System.Drawing.Point(115, 29);
			cboState.Name = "cboState";
			cboState.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cboState.Size = new System.Drawing.Size(143, 21);
			cboState.Sorted = false;
			cboState.TabIndex = 67;
			cboState.TabStop = true;
			cboState.Visible = false;
			cboState.SelectionChangeCommitted += new System.EventHandler(cboState_SelectionChangeCommitted);
			// 
			// chkAwaitingDocs
			// 
			chkAwaitingDocs.AllowDrop = true;
			chkAwaitingDocs.Appearance = System.Windows.Forms.Appearance.Normal;
			chkAwaitingDocs.BackColor = System.Drawing.SystemColors.Control;
			chkAwaitingDocs.CausesValidation = true;
			chkAwaitingDocs.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkAwaitingDocs.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkAwaitingDocs.Enabled = true;
			chkAwaitingDocs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkAwaitingDocs.ForeColor = System.Drawing.SystemColors.WindowText;
			chkAwaitingDocs.Location = new System.Drawing.Point(50, 141);
			chkAwaitingDocs.Name = "chkAwaitingDocs";
			chkAwaitingDocs.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkAwaitingDocs.Size = new System.Drawing.Size(139, 13);
			chkAwaitingDocs.TabIndex = 66;
			chkAwaitingDocs.TabStop = true;
			chkAwaitingDocs.Text = "Awaiting Documentation";
			chkAwaitingDocs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkAwaitingDocs.Visible = true;
			chkAwaitingDocs.CheckStateChanged += new System.EventHandler(chkAwaitingDocs_CheckStateChanged);
			// 
			// cmdFindManufacturer
			// 
			cmdFindManufacturer.AllowDrop = true;
			cmdFindManufacturer.BackColor = System.Drawing.SystemColors.Control;
			cmdFindManufacturer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdFindManufacturer.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdFindManufacturer.Location = new System.Drawing.Point(203, 134);
			cmdFindManufacturer.Name = "cmdFindManufacturer";
			cmdFindManufacturer.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdFindManufacturer.Size = new System.Drawing.Size(144, 26);
			cmdFindManufacturer.TabIndex = 70;
			cmdFindManufacturer.Text = "Identify Current Owner";
			cmdFindManufacturer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdFindManufacturer.UseVisualStyleBackColor = false;
			cmdFindManufacturer.Click += new System.EventHandler(cmdFindManufacturer_Click);
			// 
			// lstManufacturer
			// 
			lstManufacturer.AllowDrop = true;
			lstManufacturer.BackColor = System.Drawing.SystemColors.Window;
			lstManufacturer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lstManufacturer.CausesValidation = true;
			lstManufacturer.Enabled = true;
			lstManufacturer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lstManufacturer.ForeColor = System.Drawing.SystemColors.WindowText;
			lstManufacturer.IntegralHeight = true;
			lstManufacturer.Location = new System.Drawing.Point(7, 15);
			lstManufacturer.MultiColumn = false;
			lstManufacturer.Name = "lstManufacturer";
			lstManufacturer.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lstManufacturer.Size = new System.Drawing.Size(370, 109);
			lstManufacturer.Sorted = false;
			lstManufacturer.TabIndex = 35;
			lstManufacturer.TabStop = true;
			lstManufacturer.Visible = true;
			// 
			// lblCountry
			// 
			lblCountry.AllowDrop = true;
			lblCountry.AutoSize = true;
			lblCountry.BackColor = System.Drawing.SystemColors.Control;
			lblCountry.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblCountry.ForeColor = System.Drawing.SystemColors.ControlText;
			lblCountry.Location = new System.Drawing.Point(72, 70);
			lblCountry.MinimumSize = new System.Drawing.Size(39, 13);
			lblCountry.Name = "lblCountry";
			lblCountry.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblCountry.Size = new System.Drawing.Size(39, 13);
			lblCountry.TabIndex = 71;
			lblCountry.Text = "Country:";
			lblCountry.Visible = false;
			// 
			// lblState
			// 
			lblState.AllowDrop = true;
			lblState.AutoSize = true;
			lblState.BackColor = System.Drawing.SystemColors.Control;
			lblState.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lblState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblState.ForeColor = System.Drawing.SystemColors.ControlText;
			lblState.Location = new System.Drawing.Point(83, 33);
			lblState.MinimumSize = new System.Drawing.Size(28, 13);
			lblState.Name = "lblState";
			lblState.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lblState.Size = new System.Drawing.Size(28, 13);
			lblState.TabIndex = 69;
			lblState.Text = "State:";
			lblState.Visible = false;
			// 
			// pnlStatusInfo
			// 
			pnlStatusInfo.AllowDrop = true;
			pnlStatusInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnlStatusInfo.Controls.Add(cbo_usage);
			pnlStatusInfo.Controls.Add(chk_Exclusive_Flag);
			pnlStatusInfo.Controls.Add(chk_forsale);
			pnlStatusInfo.Controls.Add(chk_ac_previously_owned_flag);
			pnlStatusInfo.Controls.Add(txt_model_config);
			pnlStatusInfo.Controls.Add(cbo_ac_stage);
			pnlStatusInfo.Controls.Add(cbo_ac_status);
			pnlStatusInfo.Controls.Add(txt_ac_purchase_date);
			pnlStatusInfo.Controls.Add(txt_exclusive_verify_date);
			pnlStatusInfo.Controls.Add(cbo_ac_owner_type);
			pnlStatusInfo.Controls.Add(pnl_Sale_Data);
			pnlStatusInfo.Controls.Add(lbl_usage);
			pnlStatusInfo.Controls.Add(Label1);
			pnlStatusInfo.Controls.Add(_lbl_gen_8);
			pnlStatusInfo.Controls.Add(_lbl_gen_7);
			pnlStatusInfo.Controls.Add(_lbl_gen_11);
			pnlStatusInfo.Controls.Add(_lbl_gen_1);
			pnlStatusInfo.Controls.Add(_lbl_gen_2);
			pnlStatusInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnlStatusInfo.Location = new System.Drawing.Point(0, 192);
			pnlStatusInfo.Name = "pnlStatusInfo";
			pnlStatusInfo.Size = new System.Drawing.Size(513, 215);
			pnlStatusInfo.TabIndex = 51;
			// 
			// cbo_usage
			// 
			cbo_usage.AllowDrop = true;
			cbo_usage.BackColor = System.Drawing.SystemColors.Window;
			cbo_usage.CausesValidation = true;
			cbo_usage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_usage.Enabled = true;
			cbo_usage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_usage.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_usage.IntegralHeight = true;
			cbo_usage.Location = new System.Drawing.Point(307, 96);
			cbo_usage.Name = "cbo_usage";
			cbo_usage.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_usage.Size = new System.Drawing.Size(180, 21);
			cbo_usage.Sorted = false;
			cbo_usage.TabIndex = 104;
			cbo_usage.TabStop = true;
			cbo_usage.Visible = true;
			// 
			// chk_Exclusive_Flag
			// 
			chk_Exclusive_Flag.AllowDrop = true;
			chk_Exclusive_Flag.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_Exclusive_Flag.BackColor = System.Drawing.SystemColors.Control;
			chk_Exclusive_Flag.CausesValidation = true;
			chk_Exclusive_Flag.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_Exclusive_Flag.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_Exclusive_Flag.Enabled = true;
			chk_Exclusive_Flag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_Exclusive_Flag.ForeColor = System.Drawing.SystemColors.WindowText;
			chk_Exclusive_Flag.Location = new System.Drawing.Point(6, 56);
			chk_Exclusive_Flag.Name = "chk_Exclusive_Flag";
			chk_Exclusive_Flag.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_Exclusive_Flag.Size = new System.Drawing.Size(81, 13);
			chk_Exclusive_Flag.TabIndex = 103;
			chk_Exclusive_Flag.TabStop = true;
			chk_Exclusive_Flag.Text = "Exclusive?";
			chk_Exclusive_Flag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_Exclusive_Flag.Visible = false;
			// 
			// chk_forsale
			// 
			chk_forsale.AllowDrop = true;
			chk_forsale.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_forsale.BackColor = System.Drawing.SystemColors.Control;
			chk_forsale.CausesValidation = true;
			chk_forsale.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_forsale.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_forsale.Enabled = true;
			chk_forsale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_forsale.ForeColor = System.Drawing.SystemColors.WindowText;
			chk_forsale.Location = new System.Drawing.Point(6, 34);
			chk_forsale.Name = "chk_forsale";
			chk_forsale.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_forsale.Size = new System.Drawing.Size(74, 17);
			chk_forsale.TabIndex = 102;
			chk_forsale.TabStop = true;
			chk_forsale.Text = "Available?";
			chk_forsale.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_forsale.Visible = true;
			chk_forsale.CheckStateChanged += new System.EventHandler(chk_forsale_CheckStateChanged);
			// 
			// chk_ac_previously_owned_flag
			// 
			chk_ac_previously_owned_flag.AllowDrop = true;
			chk_ac_previously_owned_flag.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_ac_previously_owned_flag.BackColor = System.Drawing.SystemColors.Control;
			chk_ac_previously_owned_flag.CausesValidation = true;
			chk_ac_previously_owned_flag.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_ac_previously_owned_flag.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_ac_previously_owned_flag.Enabled = true;
			chk_ac_previously_owned_flag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_ac_previously_owned_flag.ForeColor = System.Drawing.SystemColors.WindowText;
			chk_ac_previously_owned_flag.Location = new System.Drawing.Point(6, 6);
			chk_ac_previously_owned_flag.Name = "chk_ac_previously_owned_flag";
			chk_ac_previously_owned_flag.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_ac_previously_owned_flag.Size = new System.Drawing.Size(59, 28);
			chk_ac_previously_owned_flag.TabIndex = 101;
			chk_ac_previously_owned_flag.TabStop = true;
			chk_ac_previously_owned_flag.Text = "Used Aircraft?";
			chk_ac_previously_owned_flag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_ac_previously_owned_flag.Visible = true;
			// 
			// txt_model_config
			// 
			txt_model_config.AcceptsReturn = true;
			txt_model_config.AllowDrop = true;
			txt_model_config.BackColor = System.Drawing.SystemColors.Window;
			txt_model_config.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_model_config.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_model_config.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_model_config.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_model_config.Location = new System.Drawing.Point(6, 159);
			txt_model_config.MaxLength = 4;
			txt_model_config.Name = "txt_model_config";
			txt_model_config.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_model_config.Size = new System.Drawing.Size(57, 19);
			txt_model_config.TabIndex = 34;
			// 
			// cbo_ac_stage
			// 
			cbo_ac_stage.AllowDrop = true;
			cbo_ac_stage.BackColor = System.Drawing.SystemColors.Window;
			cbo_ac_stage.CausesValidation = true;
			cbo_ac_stage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_ac_stage.Enabled = true;
			cbo_ac_stage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_ac_stage.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_ac_stage.IntegralHeight = true;
			cbo_ac_stage.Location = new System.Drawing.Point(89, 68);
			cbo_ac_stage.Name = "cbo_ac_stage";
			cbo_ac_stage.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_ac_stage.Size = new System.Drawing.Size(213, 21);
			cbo_ac_stage.Sorted = false;
			cbo_ac_stage.TabIndex = 24;
			cbo_ac_stage.TabStop = true;
			cbo_ac_stage.Visible = true;
			// 
			// cbo_ac_status
			// 
			cbo_ac_status.AllowDrop = true;
			cbo_ac_status.BackColor = System.Drawing.SystemColors.Window;
			cbo_ac_status.CausesValidation = true;
			cbo_ac_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_ac_status.Enabled = true;
			cbo_ac_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_ac_status.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_ac_status.IntegralHeight = true;
			cbo_ac_status.Location = new System.Drawing.Point(126, 25);
			cbo_ac_status.Name = "cbo_ac_status";
			cbo_ac_status.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_ac_status.Size = new System.Drawing.Size(177, 21);
			cbo_ac_status.Sorted = false;
			cbo_ac_status.TabIndex = 22;
			cbo_ac_status.TabStop = true;
			cbo_ac_status.Visible = true;
			// 
			// txt_ac_purchase_date
			// 
			txt_ac_purchase_date.AcceptsReturn = true;
			txt_ac_purchase_date.AllowDrop = true;
			txt_ac_purchase_date.BackColor = System.Drawing.SystemColors.Window;
			txt_ac_purchase_date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_ac_purchase_date.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ac_purchase_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ac_purchase_date.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ac_purchase_date.Location = new System.Drawing.Point(422, 26);
			txt_ac_purchase_date.MaxLength = 0;
			txt_ac_purchase_date.Name = "txt_ac_purchase_date";
			txt_ac_purchase_date.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_purchase_date.Size = new System.Drawing.Size(65, 19);
			txt_ac_purchase_date.TabIndex = 23;
			// 
			// txt_exclusive_verify_date
			// 
			txt_exclusive_verify_date.AcceptsReturn = true;
			txt_exclusive_verify_date.AllowDrop = true;
			txt_exclusive_verify_date.BackColor = System.Drawing.SystemColors.Window;
			txt_exclusive_verify_date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_exclusive_verify_date.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_exclusive_verify_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_exclusive_verify_date.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_exclusive_verify_date.Location = new System.Drawing.Point(6, 104);
			txt_exclusive_verify_date.MaxLength = 0;
			txt_exclusive_verify_date.Name = "txt_exclusive_verify_date";
			txt_exclusive_verify_date.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_exclusive_verify_date.Size = new System.Drawing.Size(73, 19);
			txt_exclusive_verify_date.TabIndex = 33;
			txt_exclusive_verify_date.Visible = false;
			// 
			// cbo_ac_owner_type
			// 
			cbo_ac_owner_type.AllowDrop = true;
			cbo_ac_owner_type.BackColor = System.Drawing.SystemColors.Window;
			cbo_ac_owner_type.CausesValidation = true;
			cbo_ac_owner_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_ac_owner_type.Enabled = true;
			cbo_ac_owner_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_ac_owner_type.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_ac_owner_type.IntegralHeight = true;
			cbo_ac_owner_type.Location = new System.Drawing.Point(307, 68);
			cbo_ac_owner_type.Name = "cbo_ac_owner_type";
			cbo_ac_owner_type.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_ac_owner_type.Size = new System.Drawing.Size(180, 21);
			cbo_ac_owner_type.Sorted = false;
			cbo_ac_owner_type.TabIndex = 25;
			cbo_ac_owner_type.TabStop = true;
			cbo_ac_owner_type.Visible = true;
			// 
			// pnl_Sale_Data
			// 
			pnl_Sale_Data.AllowDrop = true;
			pnl_Sale_Data.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
			pnl_Sale_Data.BorderStyle = System.Windows.Forms.BorderStyle.None;
			pnl_Sale_Data.Controls.Add(txt_ac_foreign_currency_price);
			pnl_Sale_Data.Controls.Add(cbo_ac_foreign_currency_name);
			pnl_Sale_Data.Controls.Add(txt_ac_delivery_date);
			pnl_Sale_Data.Controls.Add(cbo_ac_asking);
			pnl_Sale_Data.Controls.Add(txt_ac_asking_price);
			pnl_Sale_Data.Controls.Add(txt_ac_list_date);
			pnl_Sale_Data.Controls.Add(cbo_ac_delivery);
			pnl_Sale_Data.Controls.Add(_lbl_gen_33);
			pnl_Sale_Data.Controls.Add(_lbl_gen_32);
			pnl_Sale_Data.Controls.Add(_lbl_gen_31);
			pnl_Sale_Data.Controls.Add(_lbl_gen_17);
			pnl_Sale_Data.Controls.Add(_lbl_gen_9);
			pnl_Sale_Data.Controls.Add(_lbl_gen_10);
			pnl_Sale_Data.Controls.Add(_lbl_gen_6);
			pnl_Sale_Data.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Sale_Data.Location = new System.Drawing.Point(88, 128);
			pnl_Sale_Data.Name = "pnl_Sale_Data";
			pnl_Sale_Data.Size = new System.Drawing.Size(398, 77);
			pnl_Sale_Data.TabIndex = 52;
			pnl_Sale_Data.Visible = false;
			// 
			// txt_ac_foreign_currency_price
			// 
			txt_ac_foreign_currency_price.AcceptsReturn = true;
			txt_ac_foreign_currency_price.AllowDrop = true;
			txt_ac_foreign_currency_price.BackColor = System.Drawing.SystemColors.Window;
			txt_ac_foreign_currency_price.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_ac_foreign_currency_price.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ac_foreign_currency_price.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ac_foreign_currency_price.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ac_foreign_currency_price.Location = new System.Drawing.Point(305, 53);
			txt_ac_foreign_currency_price.MaxLength = 0;
			txt_ac_foreign_currency_price.Name = "txt_ac_foreign_currency_price";
			txt_ac_foreign_currency_price.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_foreign_currency_price.Size = new System.Drawing.Size(88, 19);
			txt_ac_foreign_currency_price.TabIndex = 32;
			txt_ac_foreign_currency_price.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// cbo_ac_foreign_currency_name
			// 
			cbo_ac_foreign_currency_name.AllowDrop = true;
			cbo_ac_foreign_currency_name.BackColor = System.Drawing.SystemColors.Window;
			cbo_ac_foreign_currency_name.CausesValidation = true;
			cbo_ac_foreign_currency_name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_ac_foreign_currency_name.Enabled = true;
			cbo_ac_foreign_currency_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_ac_foreign_currency_name.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_ac_foreign_currency_name.IntegralHeight = true;
			cbo_ac_foreign_currency_name.Location = new System.Drawing.Point(305, 28);
			cbo_ac_foreign_currency_name.Name = "cbo_ac_foreign_currency_name";
			cbo_ac_foreign_currency_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_ac_foreign_currency_name.Size = new System.Drawing.Size(88, 21);
			cbo_ac_foreign_currency_name.Sorted = false;
			cbo_ac_foreign_currency_name.TabIndex = 31;
			cbo_ac_foreign_currency_name.TabStop = true;
			cbo_ac_foreign_currency_name.Visible = true;
			// 
			// txt_ac_delivery_date
			// 
			txt_ac_delivery_date.AcceptsReturn = true;
			txt_ac_delivery_date.AllowDrop = true;
			txt_ac_delivery_date.BackColor = System.Drawing.SystemColors.Window;
			txt_ac_delivery_date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_ac_delivery_date.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ac_delivery_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ac_delivery_date.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ac_delivery_date.Location = new System.Drawing.Point(305, 5);
			txt_ac_delivery_date.MaxLength = 0;
			txt_ac_delivery_date.Name = "txt_ac_delivery_date";
			txt_ac_delivery_date.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_delivery_date.Size = new System.Drawing.Size(88, 19);
			txt_ac_delivery_date.TabIndex = 30;
			txt_ac_delivery_date.Visible = false;
			// 
			// cbo_ac_asking
			// 
			cbo_ac_asking.AllowDrop = true;
			cbo_ac_asking.BackColor = System.Drawing.SystemColors.Window;
			cbo_ac_asking.CausesValidation = true;
			cbo_ac_asking.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_ac_asking.Enabled = true;
			cbo_ac_asking.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_ac_asking.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_ac_asking.IntegralHeight = true;
			cbo_ac_asking.Location = new System.Drawing.Point(55, 28);
			cbo_ac_asking.Name = "cbo_ac_asking";
			cbo_ac_asking.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_ac_asking.Size = new System.Drawing.Size(81, 21);
			cbo_ac_asking.Sorted = false;
			cbo_ac_asking.TabIndex = 27;
			cbo_ac_asking.TabStop = true;
			cbo_ac_asking.Visible = true;
			// 
			// txt_ac_asking_price
			// 
			txt_ac_asking_price.AcceptsReturn = true;
			txt_ac_asking_price.AllowDrop = true;
			txt_ac_asking_price.BackColor = System.Drawing.SystemColors.Window;
			txt_ac_asking_price.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_ac_asking_price.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ac_asking_price.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ac_asking_price.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ac_asking_price.Location = new System.Drawing.Point(137, 28);
			txt_ac_asking_price.MaxLength = 0;
			txt_ac_asking_price.Name = "txt_ac_asking_price";
			txt_ac_asking_price.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_asking_price.Size = new System.Drawing.Size(73, 21);
			txt_ac_asking_price.TabIndex = 28;
			txt_ac_asking_price.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_ac_list_date
			// 
			txt_ac_list_date.AcceptsReturn = true;
			txt_ac_list_date.AllowDrop = true;
			txt_ac_list_date.BackColor = System.Drawing.SystemColors.Window;
			txt_ac_list_date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_ac_list_date.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ac_list_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ac_list_date.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ac_list_date.Location = new System.Drawing.Point(55, 53);
			txt_ac_list_date.MaxLength = 0;
			txt_ac_list_date.Name = "txt_ac_list_date";
			txt_ac_list_date.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_list_date.Size = new System.Drawing.Size(65, 19);
			txt_ac_list_date.TabIndex = 29;
			// 
			// cbo_ac_delivery
			// 
			cbo_ac_delivery.AllowDrop = true;
			cbo_ac_delivery.BackColor = System.Drawing.SystemColors.Window;
			cbo_ac_delivery.CausesValidation = true;
			cbo_ac_delivery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_ac_delivery.Enabled = true;
			cbo_ac_delivery.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_ac_delivery.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_ac_delivery.IntegralHeight = true;
			cbo_ac_delivery.Location = new System.Drawing.Point(55, 4);
			cbo_ac_delivery.Name = "cbo_ac_delivery";
			cbo_ac_delivery.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_ac_delivery.Size = new System.Drawing.Size(145, 21);
			cbo_ac_delivery.Sorted = false;
			cbo_ac_delivery.TabIndex = 26;
			cbo_ac_delivery.TabStop = true;
			cbo_ac_delivery.Visible = true;
			// 
			// _lbl_gen_33
			// 
			_lbl_gen_33.AllowDrop = true;
			_lbl_gen_33.AutoSize = true;
			_lbl_gen_33.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_33.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_33.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_33.Location = new System.Drawing.Point(274, 56);
			_lbl_gen_33.MinimumSize = new System.Drawing.Size(27, 13);
			_lbl_gen_33.Name = "_lbl_gen_33";
			_lbl_gen_33.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_33.Size = new System.Drawing.Size(27, 13);
			_lbl_gen_33.TabIndex = 59;
			_lbl_gen_33.Text = "Price:";
			_lbl_gen_33.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// _lbl_gen_32
			// 
			_lbl_gen_32.AllowDrop = true;
			_lbl_gen_32.AutoSize = true;
			_lbl_gen_32.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_32.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_32.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_32.Location = new System.Drawing.Point(274, 32);
			_lbl_gen_32.MinimumSize = new System.Drawing.Size(27, 13);
			_lbl_gen_32.Name = "_lbl_gen_32";
			_lbl_gen_32.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_32.Size = new System.Drawing.Size(27, 13);
			_lbl_gen_32.TabIndex = 58;
			_lbl_gen_32.Text = "Type:";
			_lbl_gen_32.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// _lbl_gen_31
			// 
			_lbl_gen_31.AllowDrop = true;
			_lbl_gen_31.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_31.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_31.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_31.Location = new System.Drawing.Point(215, 37);
			_lbl_gen_31.MinimumSize = new System.Drawing.Size(57, 32);
			_lbl_gen_31.Name = "_lbl_gen_31";
			_lbl_gen_31.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_31.Size = new System.Drawing.Size(57, 32);
			_lbl_gen_31.TabIndex = 57;
			_lbl_gen_31.Text = "Foreign Currency:";
			_lbl_gen_31.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// _lbl_gen_17
			// 
			_lbl_gen_17.AllowDrop = true;
			_lbl_gen_17.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_17.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_17.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_17.Location = new System.Drawing.Point(228, 6);
			_lbl_gen_17.MinimumSize = new System.Drawing.Size(73, 17);
			_lbl_gen_17.Name = "_lbl_gen_17";
			_lbl_gen_17.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_17.Size = new System.Drawing.Size(73, 17);
			_lbl_gen_17.TabIndex = 56;
			_lbl_gen_17.Text = "Delivery Date:";
			_lbl_gen_17.Visible = false;
			_lbl_gen_17.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// _lbl_gen_9
			// 
			_lbl_gen_9.AllowDrop = true;
			_lbl_gen_9.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_9.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_9.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_9.Location = new System.Drawing.Point(3, 30);
			_lbl_gen_9.MinimumSize = new System.Drawing.Size(57, 17);
			_lbl_gen_9.Name = "_lbl_gen_9";
			_lbl_gen_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_9.Size = new System.Drawing.Size(57, 17);
			_lbl_gen_9.TabIndex = 55;
			_lbl_gen_9.Text = "Asking:";
			_lbl_gen_9.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// _lbl_gen_10
			// 
			_lbl_gen_10.AllowDrop = true;
			_lbl_gen_10.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_10.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_10.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_10.Location = new System.Drawing.Point(3, 45);
			_lbl_gen_10.MinimumSize = new System.Drawing.Size(33, 33);
			_lbl_gen_10.Name = "_lbl_gen_10";
			_lbl_gen_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_10.Size = new System.Drawing.Size(33, 33);
			_lbl_gen_10.TabIndex = 54;
			_lbl_gen_10.Text = "Date Listed:";
			_lbl_gen_10.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// _lbl_gen_6
			// 
			_lbl_gen_6.AllowDrop = true;
			_lbl_gen_6.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_6.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_6.Location = new System.Drawing.Point(3, 6);
			_lbl_gen_6.MinimumSize = new System.Drawing.Size(57, 17);
			_lbl_gen_6.Name = "_lbl_gen_6";
			_lbl_gen_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_6.Size = new System.Drawing.Size(57, 17);
			_lbl_gen_6.TabIndex = 53;
			_lbl_gen_6.Text = "Delivery:";
			_lbl_gen_6.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// lbl_usage
			// 
			lbl_usage.AllowDrop = true;
			lbl_usage.BackColor = System.Drawing.SystemColors.Control;
			lbl_usage.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_usage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_usage.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_usage.Location = new System.Drawing.Point(264, 96);
			lbl_usage.MinimumSize = new System.Drawing.Size(41, 17);
			lbl_usage.Name = "lbl_usage";
			lbl_usage.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_usage.Size = new System.Drawing.Size(41, 17);
			lbl_usage.TabIndex = 105;
			lbl_usage.Text = "Usage: ";
			// 
			// Label1
			// 
			Label1.AllowDrop = true;
			Label1.BackColor = System.Drawing.SystemColors.Control;
			Label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label1.ForeColor = System.Drawing.SystemColors.ControlText;
			Label1.Location = new System.Drawing.Point(6, 128);
			Label1.MinimumSize = new System.Drawing.Size(75, 32);
			Label1.Name = "Label1";
			Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label1.Size = new System.Drawing.Size(75, 32);
			Label1.TabIndex = 83;
			Label1.Text = "Model Configuration:";
			// 
			// _lbl_gen_8
			// 
			_lbl_gen_8.AllowDrop = true;
			_lbl_gen_8.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_8.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_8.Location = new System.Drawing.Point(89, 27);
			_lbl_gen_8.MinimumSize = new System.Drawing.Size(39, 17);
			_lbl_gen_8.Name = "_lbl_gen_8";
			_lbl_gen_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_8.Size = new System.Drawing.Size(39, 17);
			_lbl_gen_8.TabIndex = 64;
			_lbl_gen_8.Text = "Status:";
			_lbl_gen_8.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// _lbl_gen_7
			// 
			_lbl_gen_7.AllowDrop = true;
			_lbl_gen_7.AutoSize = true;
			_lbl_gen_7.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_7.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_7.Location = new System.Drawing.Point(337, 29);
			_lbl_gen_7.MinimumSize = new System.Drawing.Size(80, 13);
			_lbl_gen_7.Name = "_lbl_gen_7";
			_lbl_gen_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_7.Size = new System.Drawing.Size(80, 13);
			_lbl_gen_7.TabIndex = 63;
			_lbl_gen_7.Text = "Date Purchased:";
			_lbl_gen_7.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// _lbl_gen_11
			// 
			_lbl_gen_11.AllowDrop = true;
			_lbl_gen_11.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_11.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_11.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_11.Location = new System.Drawing.Point(6, 75);
			_lbl_gen_11.MinimumSize = new System.Drawing.Size(74, 29);
			_lbl_gen_11.Name = "_lbl_gen_11";
			_lbl_gen_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_11.Size = new System.Drawing.Size(74, 29);
			_lbl_gen_11.TabIndex = 62;
			_lbl_gen_11.Text = "Next Exclusive Verify Date:";
			_lbl_gen_11.Visible = false;
			_lbl_gen_11.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// _lbl_gen_1
			// 
			_lbl_gen_1.AllowDrop = true;
			_lbl_gen_1.AutoSize = true;
			_lbl_gen_1.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_1.Location = new System.Drawing.Point(309, 54);
			_lbl_gen_1.MinimumSize = new System.Drawing.Size(80, 13);
			_lbl_gen_1.Name = "_lbl_gen_1";
			_lbl_gen_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_1.Size = new System.Drawing.Size(80, 13);
			_lbl_gen_1.TabIndex = 61;
			_lbl_gen_1.Text = "Ownership Type:";
			_lbl_gen_1.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// _lbl_gen_2
			// 
			_lbl_gen_2.AllowDrop = true;
			_lbl_gen_2.AutoSize = true;
			_lbl_gen_2.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_2.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_2.Location = new System.Drawing.Point(89, 53);
			_lbl_gen_2.MinimumSize = new System.Drawing.Size(76, 13);
			_lbl_gen_2.Name = "_lbl_gen_2";
			_lbl_gen_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_2.Size = new System.Drawing.Size(76, 13);
			_lbl_gen_2.TabIndex = 60;
			_lbl_gen_2.Text = "Lifecycle Stage:";
			_lbl_gen_2.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// cmdCancel
			// 
			cmdCancel.AllowDrop = true;
			cmdCancel.BackColor = System.Drawing.SystemColors.Control;
			cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdCancel.Location = new System.Drawing.Point(264, 424);
			cmdCancel.Name = "cmdCancel";
			cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdCancel.Size = new System.Drawing.Size(66, 23);
			cmdCancel.TabIndex = 41;
			cmdCancel.Text = "Cancel";
			cmdCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdCancel.UseVisualStyleBackColor = false;
			cmdCancel.Click += new System.EventHandler(cmdCancel_Click);
			// 
			// cmdSave
			// 
			cmdSave.AllowDrop = true;
			cmdSave.BackColor = System.Drawing.SystemColors.Control;
			cmdSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdSave.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdSave.Location = new System.Drawing.Point(178, 424);
			cmdSave.Name = "cmdSave";
			cmdSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdSave.Size = new System.Drawing.Size(66, 23);
			cmdSave.TabIndex = 39;
			cmdSave.Text = "Save";
			cmdSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdSave.UseVisualStyleBackColor = false;
			cmdSave.Click += new System.EventHandler(cmdSave_Click);
			// 
			// _pnl_gen_5
			// 
			_pnl_gen_5.AllowDrop = true;
			_pnl_gen_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_pnl_gen_5.Controls.Add(cbo_ac_country_of_registration);
			_pnl_gen_5.Controls.Add(cbo_amod_make_name);
			_pnl_gen_5.Controls.Add(txt_amod_type_code);
			_pnl_gen_5.Controls.Add(_lblMakeModel_1);
			_pnl_gen_5.Controls.Add(_lbl_gen_0);
			_pnl_gen_5.Controls.Add(_lblMakeModel_0);
			_pnl_gen_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_pnl_gen_5.Location = new System.Drawing.Point(0, 23);
			_pnl_gen_5.Name = "_pnl_gen_5";
			_pnl_gen_5.Size = new System.Drawing.Size(205, 169);
			_pnl_gen_5.TabIndex = 48;
			// 
			// cbo_ac_country_of_registration
			// 
			cbo_ac_country_of_registration.AllowDrop = true;
			cbo_ac_country_of_registration.BackColor = System.Drawing.SystemColors.Window;
			cbo_ac_country_of_registration.CausesValidation = true;
			cbo_ac_country_of_registration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_ac_country_of_registration.Enabled = true;
			cbo_ac_country_of_registration.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_ac_country_of_registration.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_ac_country_of_registration.IntegralHeight = true;
			cbo_ac_country_of_registration.Location = new System.Drawing.Point(6, 133);
			cbo_ac_country_of_registration.Name = "cbo_ac_country_of_registration";
			cbo_ac_country_of_registration.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_ac_country_of_registration.Size = new System.Drawing.Size(195, 21);
			cbo_ac_country_of_registration.Sorted = false;
			cbo_ac_country_of_registration.TabIndex = 81;
			cbo_ac_country_of_registration.TabStop = true;
			cbo_ac_country_of_registration.Visible = true;
			// 
			// cbo_amod_make_name
			// 
			cbo_amod_make_name.AllowDrop = true;
			cbo_amod_make_name.BackColor = System.Drawing.SystemColors.Window;
			cbo_amod_make_name.CausesValidation = true;
			cbo_amod_make_name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_amod_make_name.Enabled = true;
			cbo_amod_make_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_amod_make_name.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_amod_make_name.IntegralHeight = true;
			cbo_amod_make_name.Location = new System.Drawing.Point(7, 72);
			cbo_amod_make_name.Name = "cbo_amod_make_name";
			cbo_amod_make_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_amod_make_name.Size = new System.Drawing.Size(193, 21);
			cbo_amod_make_name.Sorted = false;
			cbo_amod_make_name.TabIndex = 1;
			cbo_amod_make_name.TabStop = true;
			cbo_amod_make_name.Visible = true;
			cbo_amod_make_name.SelectionChangeCommitted += new System.EventHandler(cbo_amod_make_name_SelectionChangeCommitted);
			// 
			// txt_amod_type_code
			// 
			txt_amod_type_code.AcceptsReturn = true;
			txt_amod_type_code.AllowDrop = true;
			txt_amod_type_code.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_amod_type_code.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_amod_type_code.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_amod_type_code.Enabled = false;
			txt_amod_type_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_amod_type_code.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_amod_type_code.Location = new System.Drawing.Point(8, 31);
			txt_amod_type_code.MaxLength = 20;
			txt_amod_type_code.Name = "txt_amod_type_code";
			txt_amod_type_code.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_amod_type_code.Size = new System.Drawing.Size(97, 19);
			txt_amod_type_code.TabIndex = 0;
			// 
			// _lblMakeModel_1
			// 
			_lblMakeModel_1.AllowDrop = true;
			_lblMakeModel_1.BackColor = System.Drawing.SystemColors.Control;
			_lblMakeModel_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblMakeModel_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblMakeModel_1.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblMakeModel_1.Location = new System.Drawing.Point(4, 115);
			_lblMakeModel_1.MinimumSize = new System.Drawing.Size(153, 17);
			_lblMakeModel_1.Name = "_lblMakeModel_1";
			_lblMakeModel_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblMakeModel_1.Size = new System.Drawing.Size(153, 17);
			_lblMakeModel_1.TabIndex = 82;
			_lblMakeModel_1.Text = "Country of Registration:";
			// 
			// _lbl_gen_0
			// 
			_lbl_gen_0.AllowDrop = true;
			_lbl_gen_0.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_0.Location = new System.Drawing.Point(8, 16);
			_lbl_gen_0.MinimumSize = new System.Drawing.Size(33, 17);
			_lbl_gen_0.Name = "_lbl_gen_0";
			_lbl_gen_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_0.Size = new System.Drawing.Size(33, 17);
			_lbl_gen_0.TabIndex = 50;
			_lbl_gen_0.Text = "Type: ";
			_lbl_gen_0.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// _lblMakeModel_0
			// 
			_lblMakeModel_0.AllowDrop = true;
			_lblMakeModel_0.BackColor = System.Drawing.SystemColors.Control;
			_lblMakeModel_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lblMakeModel_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblMakeModel_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_lblMakeModel_0.Location = new System.Drawing.Point(8, 57);
			_lblMakeModel_0.MinimumSize = new System.Drawing.Size(153, 17);
			_lblMakeModel_0.Name = "_lblMakeModel_0";
			_lblMakeModel_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lblMakeModel_0.Size = new System.Drawing.Size(153, 17);
			_lblMakeModel_0.TabIndex = 49;
			_lblMakeModel_0.Text = "Make / Model:";
			// 
			// _pnl_gen_1
			// 
			_pnl_gen_1.AllowDrop = true;
			_pnl_gen_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_pnl_gen_1.Controls.Add(_txt_ac_engine_tbo_hrs_1);
			_pnl_gen_1.Controls.Add(_txt_ac_engine_tbo_hrs_3);
			_pnl_gen_1.Controls.Add(_txt_ac_engine_tbo_hrs_2);
			_pnl_gen_1.Controls.Add(_txt_ac_engine_tbo_hrs_0);
			_pnl_gen_1.Controls.Add(txt_engine_noise_rating);
			_pnl_gen_1.Controls.Add(cbo_ac_engine_name);
			_pnl_gen_1.Controls.Add(chk_oncondtbo);
			_pnl_gen_1.Controls.Add(_lbl_engine_8);
			_pnl_gen_1.Controls.Add(_lbl_engine_10);
			_pnl_gen_1.Controls.Add(_lbl_engine_7);
			_pnl_gen_1.Controls.Add(_lbl_engine_9);
			_pnl_gen_1.Controls.Add(Label2);
			_pnl_gen_1.Controls.Add(_lbl_gen_19);
			_pnl_gen_1.Controls.Add(_lbl_gen_26);
			_pnl_gen_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_pnl_gen_1.Location = new System.Drawing.Point(513, 192);
			_pnl_gen_1.Name = "_pnl_gen_1";
			_pnl_gen_1.Size = new System.Drawing.Size(214, 285);
			_pnl_gen_1.TabIndex = 77;
			// 
			// _txt_ac_engine_tbo_hrs_1
			// 
			_txt_ac_engine_tbo_hrs_1.AcceptsReturn = true;
			_txt_ac_engine_tbo_hrs_1.AllowDrop = true;
			_txt_ac_engine_tbo_hrs_1.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_engine_tbo_hrs_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_engine_tbo_hrs_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_engine_tbo_hrs_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_engine_tbo_hrs_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_engine_tbo_hrs_1.Location = new System.Drawing.Point(84, 115);
			_txt_ac_engine_tbo_hrs_1.MaxLength = 0;
			_txt_ac_engine_tbo_hrs_1.Name = "_txt_ac_engine_tbo_hrs_1";
			_txt_ac_engine_tbo_hrs_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_engine_tbo_hrs_1.Size = new System.Drawing.Size(57, 19);
			_txt_ac_engine_tbo_hrs_1.TabIndex = 99;
			_txt_ac_engine_tbo_hrs_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// _txt_ac_engine_tbo_hrs_3
			// 
			_txt_ac_engine_tbo_hrs_3.AcceptsReturn = true;
			_txt_ac_engine_tbo_hrs_3.AllowDrop = true;
			_txt_ac_engine_tbo_hrs_3.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_engine_tbo_hrs_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_engine_tbo_hrs_3.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_engine_tbo_hrs_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_engine_tbo_hrs_3.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_engine_tbo_hrs_3.Location = new System.Drawing.Point(84, 164);
			_txt_ac_engine_tbo_hrs_3.MaxLength = 0;
			_txt_ac_engine_tbo_hrs_3.Name = "_txt_ac_engine_tbo_hrs_3";
			_txt_ac_engine_tbo_hrs_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_engine_tbo_hrs_3.Size = new System.Drawing.Size(57, 19);
			_txt_ac_engine_tbo_hrs_3.TabIndex = 95;
			_txt_ac_engine_tbo_hrs_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// _txt_ac_engine_tbo_hrs_2
			// 
			_txt_ac_engine_tbo_hrs_2.AcceptsReturn = true;
			_txt_ac_engine_tbo_hrs_2.AllowDrop = true;
			_txt_ac_engine_tbo_hrs_2.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_engine_tbo_hrs_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_engine_tbo_hrs_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_engine_tbo_hrs_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_engine_tbo_hrs_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_engine_tbo_hrs_2.Location = new System.Drawing.Point(84, 140);
			_txt_ac_engine_tbo_hrs_2.MaxLength = 0;
			_txt_ac_engine_tbo_hrs_2.Name = "_txt_ac_engine_tbo_hrs_2";
			_txt_ac_engine_tbo_hrs_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_engine_tbo_hrs_2.Size = new System.Drawing.Size(57, 19);
			_txt_ac_engine_tbo_hrs_2.TabIndex = 94;
			_txt_ac_engine_tbo_hrs_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// _txt_ac_engine_tbo_hrs_0
			// 
			_txt_ac_engine_tbo_hrs_0.AcceptsReturn = true;
			_txt_ac_engine_tbo_hrs_0.AllowDrop = true;
			_txt_ac_engine_tbo_hrs_0.BackColor = System.Drawing.SystemColors.Window;
			_txt_ac_engine_tbo_hrs_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txt_ac_engine_tbo_hrs_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txt_ac_engine_tbo_hrs_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txt_ac_engine_tbo_hrs_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_txt_ac_engine_tbo_hrs_0.Location = new System.Drawing.Point(84, 90);
			_txt_ac_engine_tbo_hrs_0.MaxLength = 0;
			_txt_ac_engine_tbo_hrs_0.Name = "_txt_ac_engine_tbo_hrs_0";
			_txt_ac_engine_tbo_hrs_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txt_ac_engine_tbo_hrs_0.Size = new System.Drawing.Size(57, 19);
			_txt_ac_engine_tbo_hrs_0.TabIndex = 93;
			_txt_ac_engine_tbo_hrs_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_engine_noise_rating
			// 
			txt_engine_noise_rating.AcceptsReturn = true;
			txt_engine_noise_rating.AllowDrop = true;
			txt_engine_noise_rating.BackColor = System.Drawing.SystemColors.Window;
			txt_engine_noise_rating.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_engine_noise_rating.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_engine_noise_rating.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_engine_noise_rating.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_engine_noise_rating.Location = new System.Drawing.Point(118, 256);
			txt_engine_noise_rating.MaxLength = 1;
			txt_engine_noise_rating.Name = "txt_engine_noise_rating";
			txt_engine_noise_rating.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_engine_noise_rating.Size = new System.Drawing.Size(33, 19);
			txt_engine_noise_rating.TabIndex = 38;
			txt_engine_noise_rating.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txt_engine_noise_rating_KeyPress);
			// 
			// cbo_ac_engine_name
			// 
			cbo_ac_engine_name.AllowDrop = true;
			cbo_ac_engine_name.BackColor = System.Drawing.SystemColors.Window;
			cbo_ac_engine_name.CausesValidation = true;
			cbo_ac_engine_name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cbo_ac_engine_name.Enabled = true;
			cbo_ac_engine_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_ac_engine_name.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_ac_engine_name.IntegralHeight = true;
			cbo_ac_engine_name.Location = new System.Drawing.Point(7, 233);
			cbo_ac_engine_name.Name = "cbo_ac_engine_name";
			cbo_ac_engine_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_ac_engine_name.Size = new System.Drawing.Size(201, 21);
			cbo_ac_engine_name.Sorted = false;
			cbo_ac_engine_name.TabIndex = 37;
			cbo_ac_engine_name.TabStop = true;
			cbo_ac_engine_name.Visible = true;
			cbo_ac_engine_name.SelectionChangeCommitted += new System.EventHandler(cbo_ac_engine_name_SelectionChangeCommitted);
			// 
			// chk_oncondtbo
			// 
			chk_oncondtbo.AllowDrop = true;
			chk_oncondtbo.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_oncondtbo.BackColor = System.Drawing.SystemColors.Control;
			chk_oncondtbo.CausesValidation = true;
			chk_oncondtbo.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_oncondtbo.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_oncondtbo.Enabled = true;
			chk_oncondtbo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_oncondtbo.ForeColor = System.Drawing.SystemColors.WindowText;
			chk_oncondtbo.Location = new System.Drawing.Point(33, 191);
			chk_oncondtbo.Name = "chk_oncondtbo";
			chk_oncondtbo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_oncondtbo.Size = new System.Drawing.Size(113, 17);
			chk_oncondtbo.TabIndex = 36;
			chk_oncondtbo.TabStop = true;
			chk_oncondtbo.Text = "On Condition TBO?";
			chk_oncondtbo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_oncondtbo.Visible = true;
			// 
			// _lbl_engine_8
			// 
			_lbl_engine_8.AllowDrop = true;
			_lbl_engine_8.AutoSize = true;
			_lbl_engine_8.BackColor = System.Drawing.Color.Transparent;
			_lbl_engine_8.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_engine_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_engine_8.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_engine_8.Location = new System.Drawing.Point(33, 115);
			_lbl_engine_8.MinimumSize = new System.Drawing.Size(45, 19);
			_lbl_engine_8.Name = "_lbl_engine_8";
			_lbl_engine_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_engine_8.Size = new System.Drawing.Size(45, 19);
			_lbl_engine_8.TabIndex = 100;
			_lbl_engine_8.Text = "Engine 2:";
			// 
			// _lbl_engine_10
			// 
			_lbl_engine_10.AllowDrop = true;
			_lbl_engine_10.AutoSize = true;
			_lbl_engine_10.BackColor = System.Drawing.Color.Transparent;
			_lbl_engine_10.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_engine_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_engine_10.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_engine_10.Location = new System.Drawing.Point(33, 164);
			_lbl_engine_10.MinimumSize = new System.Drawing.Size(45, 19);
			_lbl_engine_10.Name = "_lbl_engine_10";
			_lbl_engine_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_engine_10.Size = new System.Drawing.Size(45, 19);
			_lbl_engine_10.TabIndex = 98;
			_lbl_engine_10.Text = "Engine 4:";
			// 
			// _lbl_engine_7
			// 
			_lbl_engine_7.AllowDrop = true;
			_lbl_engine_7.AutoSize = true;
			_lbl_engine_7.BackColor = System.Drawing.Color.Transparent;
			_lbl_engine_7.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_engine_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_engine_7.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_engine_7.Location = new System.Drawing.Point(33, 90);
			_lbl_engine_7.MinimumSize = new System.Drawing.Size(45, 19);
			_lbl_engine_7.Name = "_lbl_engine_7";
			_lbl_engine_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_engine_7.Size = new System.Drawing.Size(45, 19);
			_lbl_engine_7.TabIndex = 97;
			_lbl_engine_7.Text = "Engine 1:";
			// 
			// _lbl_engine_9
			// 
			_lbl_engine_9.AllowDrop = true;
			_lbl_engine_9.AutoSize = true;
			_lbl_engine_9.BackColor = System.Drawing.Color.Transparent;
			_lbl_engine_9.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_engine_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_engine_9.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_engine_9.Location = new System.Drawing.Point(33, 140);
			_lbl_engine_9.MinimumSize = new System.Drawing.Size(45, 19);
			_lbl_engine_9.Name = "_lbl_engine_9";
			_lbl_engine_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_engine_9.Size = new System.Drawing.Size(45, 19);
			_lbl_engine_9.TabIndex = 96;
			_lbl_engine_9.Text = "Engine 3:";
			// 
			// Label2
			// 
			Label2.AllowDrop = true;
			Label2.BackColor = System.Drawing.SystemColors.Control;
			Label2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label2.ForeColor = System.Drawing.SystemColors.ControlText;
			Label2.Location = new System.Drawing.Point(7, 257);
			Label2.MinimumSize = new System.Drawing.Size(113, 17);
			Label2.Name = "Label2";
			Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label2.Size = new System.Drawing.Size(113, 17);
			Label2.TabIndex = 84;
			Label2.Text = "Engine Noise Rating:";
			// 
			// _lbl_gen_19
			// 
			_lbl_gen_19.AllowDrop = true;
			_lbl_gen_19.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_19.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_19.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_19.Location = new System.Drawing.Point(7, 214);
			_lbl_gen_19.MinimumSize = new System.Drawing.Size(73, 17);
			_lbl_gen_19.Name = "_lbl_gen_19";
			_lbl_gen_19.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_19.Size = new System.Drawing.Size(73, 17);
			_lbl_gen_19.TabIndex = 79;
			_lbl_gen_19.Text = "Engine Model:";
			_lbl_gen_19.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// _lbl_gen_26
			// 
			_lbl_gen_26.AllowDrop = true;
			_lbl_gen_26.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_26.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_26.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_26.Location = new System.Drawing.Point(81, 20);
			_lbl_gen_26.MinimumSize = new System.Drawing.Size(65, 73);
			_lbl_gen_26.Name = "_lbl_gen_26";
			_lbl_gen_26.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_26.Size = new System.Drawing.Size(65, 73);
			_lbl_gen_26.TabIndex = 78;
			_lbl_gen_26.Text = "Time Between Overhaul (TBO/TBCI) Hours";
			_lbl_gen_26.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_gen_26.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// SSPanel_productCode
			// 
			SSPanel_productCode.AllowDrop = true;
			SSPanel_productCode.BackColor = System.Drawing.Color.FromArgb(236, 233, 216);
			SSPanel_productCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			SSPanel_productCode.Controls.Add(_ac_product_chk_0);
			SSPanel_productCode.Controls.Add(_ac_product_chk_1);
			SSPanel_productCode.Controls.Add(_ac_product_chk_2);
			SSPanel_productCode.Controls.Add(_ac_product_chk_4);
			SSPanel_productCode.Controls.Add(_ac_product_chk_5);
			SSPanel_productCode.Controls.Add(_ac_product_chk_3);
			SSPanel_productCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			SSPanel_productCode.Location = new System.Drawing.Point(727, 192);
			SSPanel_productCode.Name = "SSPanel_productCode";
			SSPanel_productCode.Size = new System.Drawing.Size(248, 105);
			SSPanel_productCode.TabIndex = 86;
			// 
			// _ac_product_chk_0
			// 
			_ac_product_chk_0.AllowDrop = true;
			_ac_product_chk_0.Appearance = System.Windows.Forms.Appearance.Normal;
			_ac_product_chk_0.BackColor = System.Drawing.SystemColors.Control;
			_ac_product_chk_0.CausesValidation = true;
			_ac_product_chk_0.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			_ac_product_chk_0.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_ac_product_chk_0.Enabled = true;
			_ac_product_chk_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_ac_product_chk_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_ac_product_chk_0.Location = new System.Drawing.Point(4, 19);
			_ac_product_chk_0.Name = "_ac_product_chk_0";
			_ac_product_chk_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_ac_product_chk_0.Size = new System.Drawing.Size(103, 17);
			_ac_product_chk_0.TabIndex = 92;
			_ac_product_chk_0.TabStop = true;
			_ac_product_chk_0.Text = "Business Aircraft";
			_ac_product_chk_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_ac_product_chk_0.Visible = true;
			_ac_product_chk_0.CheckStateChanged += new System.EventHandler(ac_product_chk_CheckStateChanged);
			// 
			// _ac_product_chk_1
			// 
			_ac_product_chk_1.AllowDrop = true;
			_ac_product_chk_1.Appearance = System.Windows.Forms.Appearance.Normal;
			_ac_product_chk_1.BackColor = System.Drawing.SystemColors.Control;
			_ac_product_chk_1.CausesValidation = true;
			_ac_product_chk_1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			_ac_product_chk_1.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_ac_product_chk_1.Enabled = true;
			_ac_product_chk_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_ac_product_chk_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_ac_product_chk_1.Location = new System.Drawing.Point(4, 45);
			_ac_product_chk_1.Name = "_ac_product_chk_1";
			_ac_product_chk_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_ac_product_chk_1.Size = new System.Drawing.Size(103, 17);
			_ac_product_chk_1.TabIndex = 91;
			_ac_product_chk_1.TabStop = true;
			_ac_product_chk_1.Text = "Helicopters";
			_ac_product_chk_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_ac_product_chk_1.Visible = true;
			_ac_product_chk_1.CheckStateChanged += new System.EventHandler(ac_product_chk_CheckStateChanged);
			// 
			// _ac_product_chk_2
			// 
			_ac_product_chk_2.AllowDrop = true;
			_ac_product_chk_2.Appearance = System.Windows.Forms.Appearance.Normal;
			_ac_product_chk_2.BackColor = System.Drawing.SystemColors.Control;
			_ac_product_chk_2.CausesValidation = true;
			_ac_product_chk_2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			_ac_product_chk_2.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_ac_product_chk_2.Enabled = true;
			_ac_product_chk_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_ac_product_chk_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_ac_product_chk_2.Location = new System.Drawing.Point(4, 71);
			_ac_product_chk_2.Name = "_ac_product_chk_2";
			_ac_product_chk_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_ac_product_chk_2.Size = new System.Drawing.Size(103, 17);
			_ac_product_chk_2.TabIndex = 90;
			_ac_product_chk_2.TabStop = true;
			_ac_product_chk_2.Text = "Commercial";
			_ac_product_chk_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_ac_product_chk_2.Visible = true;
			_ac_product_chk_2.CheckStateChanged += new System.EventHandler(ac_product_chk_CheckStateChanged);
			// 
			// _ac_product_chk_4
			// 
			_ac_product_chk_4.AllowDrop = true;
			_ac_product_chk_4.Appearance = System.Windows.Forms.Appearance.Normal;
			_ac_product_chk_4.BackColor = System.Drawing.SystemColors.Control;
			_ac_product_chk_4.CausesValidation = true;
			_ac_product_chk_4.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			_ac_product_chk_4.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_ac_product_chk_4.Enabled = true;
			_ac_product_chk_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_ac_product_chk_4.ForeColor = System.Drawing.SystemColors.WindowText;
			_ac_product_chk_4.Location = new System.Drawing.Point(119, 45);
			_ac_product_chk_4.Name = "_ac_product_chk_4";
			_ac_product_chk_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_ac_product_chk_4.Size = new System.Drawing.Size(103, 17);
			_ac_product_chk_4.TabIndex = 89;
			_ac_product_chk_4.TabStop = true;
			_ac_product_chk_4.Text = "Air BP";
			_ac_product_chk_4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_ac_product_chk_4.Visible = true;
			_ac_product_chk_4.CheckStateChanged += new System.EventHandler(ac_product_chk_CheckStateChanged);
			// 
			// _ac_product_chk_5
			// 
			_ac_product_chk_5.AllowDrop = true;
			_ac_product_chk_5.Appearance = System.Windows.Forms.Appearance.Normal;
			_ac_product_chk_5.BackColor = System.Drawing.SystemColors.Control;
			_ac_product_chk_5.CausesValidation = true;
			_ac_product_chk_5.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			_ac_product_chk_5.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_ac_product_chk_5.Enabled = true;
			_ac_product_chk_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_ac_product_chk_5.ForeColor = System.Drawing.SystemColors.WindowText;
			_ac_product_chk_5.Location = new System.Drawing.Point(119, 71);
			_ac_product_chk_5.Name = "_ac_product_chk_5";
			_ac_product_chk_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_ac_product_chk_5.Size = new System.Drawing.Size(103, 17);
			_ac_product_chk_5.TabIndex = 88;
			_ac_product_chk_5.TabStop = true;
			_ac_product_chk_5.Text = "Regional";
			_ac_product_chk_5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_ac_product_chk_5.Visible = true;
			_ac_product_chk_5.CheckStateChanged += new System.EventHandler(ac_product_chk_CheckStateChanged);
			// 
			// _ac_product_chk_3
			// 
			_ac_product_chk_3.AllowDrop = true;
			_ac_product_chk_3.Appearance = System.Windows.Forms.Appearance.Normal;
			_ac_product_chk_3.BackColor = System.Drawing.SystemColors.Control;
			_ac_product_chk_3.CausesValidation = true;
			_ac_product_chk_3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			_ac_product_chk_3.CheckState = System.Windows.Forms.CheckState.Unchecked;
			_ac_product_chk_3.Enabled = true;
			_ac_product_chk_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_ac_product_chk_3.ForeColor = System.Drawing.SystemColors.WindowText;
			_ac_product_chk_3.Location = new System.Drawing.Point(119, 19);
			_ac_product_chk_3.Name = "_ac_product_chk_3";
			_ac_product_chk_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_ac_product_chk_3.Size = new System.Drawing.Size(103, 17);
			_ac_product_chk_3.TabIndex = 87;
			_ac_product_chk_3.TabStop = true;
			_ac_product_chk_3.Text = "ABI";
			_ac_product_chk_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			_ac_product_chk_3.Visible = true;
			_ac_product_chk_3.CheckStateChanged += new System.EventHandler(ac_product_chk_CheckStateChanged);
			// 
			// _pnl_gen_0
			// 
			_pnl_gen_0.AllowDrop = true;
			_pnl_gen_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_pnl_gen_0.Controls.Add(_txtBaseCode_3);
			_pnl_gen_0.Controls.Add(cboBaseCountry);
			_pnl_gen_0.Controls.Add(cboBaseState);
			_pnl_gen_0.Controls.Add(chk_ac_aport_private);
			_pnl_gen_0.Controls.Add(_txtBaseCode_5);
			_pnl_gen_0.Controls.Add(chkHyphen);
			_pnl_gen_0.Controls.Add(_txtBaseCode_0);
			_pnl_gen_0.Controls.Add(_txtBaseCode_1);
			_pnl_gen_0.Controls.Add(_txtBaseCode_2);
			_pnl_gen_0.Controls.Add(txt_ac_mfr_year);
			_pnl_gen_0.Controls.Add(txt_ac_year);
			_pnl_gen_0.Controls.Add(txt_ac_reg_no);
			_pnl_gen_0.Controls.Add(txt_ac_ser_no_prefix);
			_pnl_gen_0.Controls.Add(txt_ac_id);
			_pnl_gen_0.Controls.Add(txt_ac_prev_reg_no);
			_pnl_gen_0.Controls.Add(txt_ac_ser_no);
			_pnl_gen_0.Controls.Add(txt_ac_ser_no_suffix);
			_pnl_gen_0.Controls.Add(txt_ac_alt_ser_no_prefix);
			_pnl_gen_0.Controls.Add(txt_ac_alt_ser_no);
			_pnl_gen_0.Controls.Add(txt_ac_alt_ser_no_suffix);
			_pnl_gen_0.Controls.Add(_lbl_gen_14);
			_pnl_gen_0.Controls.Add(_lbl_gen_13);
			_pnl_gen_0.Controls.Add(_lbl_gen_12);
			_pnl_gen_0.Controls.Add(_lbl_gen_66);
			_pnl_gen_0.Controls.Add(_lbl_gen_67);
			_pnl_gen_0.Controls.Add(_lbl_gen_68);
			_pnl_gen_0.Controls.Add(_lbl_gen_69);
			_pnl_gen_0.Controls.Add(_lbl_gen_74);
			_pnl_gen_0.Controls.Add(_lbl_gen_240);
			_pnl_gen_0.Controls.Add(_lbl_gen_5);
			_pnl_gen_0.Controls.Add(_lbl_gen_4);
			_pnl_gen_0.Controls.Add(_lbl_gen_3);
			_pnl_gen_0.Controls.Add(_lbl_gen_241);
			_pnl_gen_0.Controls.Add(_lbl_gen_30);
			_pnl_gen_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_pnl_gen_0.Location = new System.Drawing.Point(205, 21);
			_pnl_gen_0.Name = "_pnl_gen_0";
			_pnl_gen_0.Size = new System.Drawing.Size(385, 171);
			_pnl_gen_0.TabIndex = 40;
			// 
			// _txtBaseCode_3
			// 
			_txtBaseCode_3.AcceptsReturn = true;
			_txtBaseCode_3.AllowDrop = true;
			_txtBaseCode_3.BackColor = System.Drawing.SystemColors.Window;
			_txtBaseCode_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txtBaseCode_3.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtBaseCode_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtBaseCode_3.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtBaseCode_3.Location = new System.Drawing.Point(88, 120);
			_txtBaseCode_3.MaxLength = 0;
			_txtBaseCode_3.Name = "_txtBaseCode_3";
			_txtBaseCode_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtBaseCode_3.Size = new System.Drawing.Size(43, 21);
			_txtBaseCode_3.TabIndex = 16;
			_txtBaseCode_3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtBaseCode_KeyPress);
			_txtBaseCode_3.Leave += new System.EventHandler(txtBaseCode_Leave);
			// 
			// cboBaseCountry
			// 
			cboBaseCountry.AllowDrop = true;
			cboBaseCountry.BackColor = System.Drawing.SystemColors.Window;
			cboBaseCountry.CausesValidation = true;
			cboBaseCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cboBaseCountry.Enabled = true;
			cboBaseCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cboBaseCountry.ForeColor = System.Drawing.SystemColors.WindowText;
			cboBaseCountry.IntegralHeight = true;
			cboBaseCountry.Location = new System.Drawing.Point(264, 120);
			cboBaseCountry.Name = "cboBaseCountry";
			cboBaseCountry.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cboBaseCountry.Size = new System.Drawing.Size(117, 21);
			cboBaseCountry.Sorted = false;
			cboBaseCountry.TabIndex = 19;
			cboBaseCountry.TabStop = true;
			cboBaseCountry.Tag = "txtBaseCode(4)";
			cboBaseCountry.Visible = true;
			cboBaseCountry.Leave += new System.EventHandler(cboBaseCountry_Leave);
			// 
			// cboBaseState
			// 
			cboBaseState.AllowDrop = true;
			cboBaseState.BackColor = System.Drawing.SystemColors.Window;
			cboBaseState.CausesValidation = true;
			cboBaseState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			cboBaseState.Enabled = true;
			cboBaseState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cboBaseState.ForeColor = System.Drawing.SystemColors.WindowText;
			cboBaseState.IntegralHeight = true;
			cboBaseState.Location = new System.Drawing.Point(220, 120);
			cboBaseState.Name = "cboBaseState";
			cboBaseState.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cboBaseState.Size = new System.Drawing.Size(43, 21);
			cboBaseState.Sorted = false;
			cboBaseState.TabIndex = 18;
			cboBaseState.TabStop = true;
			cboBaseState.Tag = "txtBaseCode(3)";
			cboBaseState.Visible = true;
			cboBaseState.Leave += new System.EventHandler(cboBaseState_Leave);
			cboBaseState.SelectionChangeCommitted += new System.EventHandler(cboBaseState_SelectionChangeCommitted);
			// 
			// chk_ac_aport_private
			// 
			chk_ac_aport_private.AllowDrop = true;
			chk_ac_aport_private.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_ac_aport_private.BackColor = System.Drawing.SystemColors.Control;
			chk_ac_aport_private.CausesValidation = true;
			chk_ac_aport_private.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_ac_aport_private.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_ac_aport_private.Enabled = true;
			chk_ac_aport_private.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_ac_aport_private.ForeColor = System.Drawing.SystemColors.WindowText;
			chk_ac_aport_private.Location = new System.Drawing.Point(315, 147);
			chk_ac_aport_private.Name = "chk_ac_aport_private";
			chk_ac_aport_private.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_ac_aport_private.Size = new System.Drawing.Size(53, 13);
			chk_ac_aport_private.TabIndex = 21;
			chk_ac_aport_private.TabStop = true;
			chk_ac_aport_private.Text = "Private";
			chk_ac_aport_private.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_ac_aport_private.Visible = true;
			// 
			// _txtBaseCode_5
			// 
			_txtBaseCode_5.AcceptsReturn = true;
			_txtBaseCode_5.AllowDrop = true;
			_txtBaseCode_5.BackColor = System.Drawing.SystemColors.Window;
			_txtBaseCode_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txtBaseCode_5.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtBaseCode_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtBaseCode_5.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtBaseCode_5.Location = new System.Drawing.Point(133, 120);
			_txtBaseCode_5.MaxLength = 0;
			_txtBaseCode_5.Name = "_txtBaseCode_5";
			_txtBaseCode_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtBaseCode_5.Size = new System.Drawing.Size(84, 21);
			_txtBaseCode_5.TabIndex = 17;
			_txtBaseCode_5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtBaseCode_KeyPress);
			_txtBaseCode_5.Leave += new System.EventHandler(txtBaseCode_Leave);
			// 
			// chkHyphen
			// 
			chkHyphen.AllowDrop = true;
			chkHyphen.Appearance = System.Windows.Forms.Appearance.Normal;
			chkHyphen.BackColor = System.Drawing.SystemColors.Control;
			chkHyphen.CausesValidation = true;
			chkHyphen.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkHyphen.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkHyphen.Enabled = true;
			chkHyphen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkHyphen.ForeColor = System.Drawing.SystemColors.WindowText;
			chkHyphen.Location = new System.Drawing.Point(309, 32);
			chkHyphen.Name = "chkHyphen";
			chkHyphen.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkHyphen.Size = new System.Drawing.Size(58, 13);
			chkHyphen.TabIndex = 9;
			chkHyphen.TabStop = true;
			chkHyphen.Text = "Hyphen";
			chkHyphen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkHyphen.Visible = true;
			// 
			// _txtBaseCode_0
			// 
			_txtBaseCode_0.AcceptsReturn = true;
			_txtBaseCode_0.AllowDrop = true;
			_txtBaseCode_0.BackColor = System.Drawing.SystemColors.Window;
			_txtBaseCode_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txtBaseCode_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtBaseCode_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtBaseCode_0.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtBaseCode_0.Location = new System.Drawing.Point(3, 120);
			_txtBaseCode_0.MaxLength = 0;
			_txtBaseCode_0.Name = "_txtBaseCode_0";
			_txtBaseCode_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtBaseCode_0.Size = new System.Drawing.Size(39, 21);
			_txtBaseCode_0.TabIndex = 14;
			_txtBaseCode_0.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtBaseCode_KeyPress);
			_txtBaseCode_0.Leave += new System.EventHandler(txtBaseCode_Leave);
			// 
			// _txtBaseCode_1
			// 
			_txtBaseCode_1.AcceptsReturn = true;
			_txtBaseCode_1.AllowDrop = true;
			_txtBaseCode_1.BackColor = System.Drawing.SystemColors.Window;
			_txtBaseCode_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txtBaseCode_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtBaseCode_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtBaseCode_1.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtBaseCode_1.Location = new System.Drawing.Point(44, 120);
			_txtBaseCode_1.MaxLength = 0;
			_txtBaseCode_1.Name = "_txtBaseCode_1";
			_txtBaseCode_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtBaseCode_1.Size = new System.Drawing.Size(43, 21);
			_txtBaseCode_1.TabIndex = 15;
			_txtBaseCode_1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtBaseCode_KeyPress);
			_txtBaseCode_1.Leave += new System.EventHandler(txtBaseCode_Leave);
			// 
			// _txtBaseCode_2
			// 
			_txtBaseCode_2.AcceptsReturn = true;
			_txtBaseCode_2.AllowDrop = true;
			_txtBaseCode_2.BackColor = System.Drawing.SystemColors.Window;
			_txtBaseCode_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_txtBaseCode_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtBaseCode_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_txtBaseCode_2.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtBaseCode_2.Location = new System.Drawing.Point(56, 143);
			_txtBaseCode_2.MaxLength = 0;
			_txtBaseCode_2.Name = "_txtBaseCode_2";
			_txtBaseCode_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtBaseCode_2.Size = new System.Drawing.Size(249, 21);
			_txtBaseCode_2.TabIndex = 20;
			_txtBaseCode_2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtBaseCode_KeyPress);
			_txtBaseCode_2.Leave += new System.EventHandler(txtBaseCode_Leave);
			// 
			// txt_ac_mfr_year
			// 
			txt_ac_mfr_year.AcceptsReturn = true;
			txt_ac_mfr_year.AllowDrop = true;
			txt_ac_mfr_year.BackColor = System.Drawing.SystemColors.Window;
			txt_ac_mfr_year.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_ac_mfr_year.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ac_mfr_year.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ac_mfr_year.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ac_mfr_year.Location = new System.Drawing.Point(212, 85);
			txt_ac_mfr_year.MaxLength = 0;
			txt_ac_mfr_year.Name = "txt_ac_mfr_year";
			txt_ac_mfr_year.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_mfr_year.Size = new System.Drawing.Size(50, 21);
			txt_ac_mfr_year.TabIndex = 12;
			// 
			// txt_ac_year
			// 
			txt_ac_year.AcceptsReturn = true;
			txt_ac_year.AllowDrop = true;
			txt_ac_year.BackColor = System.Drawing.SystemColors.Window;
			txt_ac_year.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_ac_year.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ac_year.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ac_year.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ac_year.Location = new System.Drawing.Point(264, 85);
			txt_ac_year.MaxLength = 0;
			txt_ac_year.Name = "txt_ac_year";
			txt_ac_year.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_year.Size = new System.Drawing.Size(50, 21);
			txt_ac_year.TabIndex = 13;
			// 
			// txt_ac_reg_no
			// 
			txt_ac_reg_no.AcceptsReturn = true;
			txt_ac_reg_no.AllowDrop = true;
			txt_ac_reg_no.BackColor = System.Drawing.SystemColors.Window;
			txt_ac_reg_no.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_ac_reg_no.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ac_reg_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ac_reg_no.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ac_reg_no.Location = new System.Drawing.Point(93, 63);
			txt_ac_reg_no.MaxLength = 12;
			txt_ac_reg_no.Name = "txt_ac_reg_no";
			txt_ac_reg_no.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_reg_no.Size = new System.Drawing.Size(97, 21);
			txt_ac_reg_no.TabIndex = 10;
			// 
			// txt_ac_ser_no_prefix
			// 
			txt_ac_ser_no_prefix.AcceptsReturn = true;
			txt_ac_ser_no_prefix.AllowDrop = true;
			txt_ac_ser_no_prefix.BackColor = System.Drawing.SystemColors.Control;
			txt_ac_ser_no_prefix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_ac_ser_no_prefix.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ac_ser_no_prefix.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ac_ser_no_prefix.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ac_ser_no_prefix.Location = new System.Drawing.Point(138, 40);
			txt_ac_ser_no_prefix.MaxLength = 7;
			txt_ac_ser_no_prefix.Name = "txt_ac_ser_no_prefix";
			txt_ac_ser_no_prefix.ReadOnly = true;
			txt_ac_ser_no_prefix.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_ser_no_prefix.Size = new System.Drawing.Size(41, 21);
			txt_ac_ser_no_prefix.TabIndex = 6;
			// 
			// txt_ac_id
			// 
			txt_ac_id.AcceptsReturn = true;
			txt_ac_id.AllowDrop = true;
			txt_ac_id.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_ac_id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_ac_id.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ac_id.Enabled = false;
			txt_ac_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ac_id.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ac_id.Location = new System.Drawing.Point(34, 18);
			txt_ac_id.MaxLength = 0;
			txt_ac_id.Name = "txt_ac_id";
			txt_ac_id.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_id.Size = new System.Drawing.Size(41, 21);
			txt_ac_id.TabIndex = 2;
			txt_ac_id.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt_ac_prev_reg_no
			// 
			txt_ac_prev_reg_no.AcceptsReturn = true;
			txt_ac_prev_reg_no.AllowDrop = true;
			txt_ac_prev_reg_no.BackColor = System.Drawing.SystemColors.Window;
			txt_ac_prev_reg_no.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_ac_prev_reg_no.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ac_prev_reg_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ac_prev_reg_no.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ac_prev_reg_no.Location = new System.Drawing.Point(93, 85);
			txt_ac_prev_reg_no.MaxLength = 12;
			txt_ac_prev_reg_no.Name = "txt_ac_prev_reg_no";
			txt_ac_prev_reg_no.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_prev_reg_no.Size = new System.Drawing.Size(97, 21);
			txt_ac_prev_reg_no.TabIndex = 11;
			// 
			// txt_ac_ser_no
			// 
			txt_ac_ser_no.AcceptsReturn = true;
			txt_ac_ser_no.AllowDrop = true;
			txt_ac_ser_no.BackColor = System.Drawing.SystemColors.Window;
			txt_ac_ser_no.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_ac_ser_no.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ac_ser_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ac_ser_no.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ac_ser_no.Location = new System.Drawing.Point(180, 40);
			txt_ac_ser_no.MaxLength = 8;
			txt_ac_ser_no.Name = "txt_ac_ser_no";
			txt_ac_ser_no.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_ser_no.Size = new System.Drawing.Size(57, 21);
			txt_ac_ser_no.TabIndex = 7;
			// 
			// txt_ac_ser_no_suffix
			// 
			txt_ac_ser_no_suffix.AcceptsReturn = true;
			txt_ac_ser_no_suffix.AllowDrop = true;
			txt_ac_ser_no_suffix.BackColor = System.Drawing.SystemColors.Control;
			txt_ac_ser_no_suffix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_ac_ser_no_suffix.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ac_ser_no_suffix.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ac_ser_no_suffix.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ac_ser_no_suffix.Location = new System.Drawing.Point(238, 40);
			txt_ac_ser_no_suffix.MaxLength = 7;
			txt_ac_ser_no_suffix.Name = "txt_ac_ser_no_suffix";
			txt_ac_ser_no_suffix.ReadOnly = true;
			txt_ac_ser_no_suffix.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_ser_no_suffix.Size = new System.Drawing.Size(57, 21);
			txt_ac_ser_no_suffix.TabIndex = 8;
			// 
			// txt_ac_alt_ser_no_prefix
			// 
			txt_ac_alt_ser_no_prefix.AcceptsReturn = true;
			txt_ac_alt_ser_no_prefix.AllowDrop = true;
			txt_ac_alt_ser_no_prefix.BackColor = System.Drawing.SystemColors.Window;
			txt_ac_alt_ser_no_prefix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_ac_alt_ser_no_prefix.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ac_alt_ser_no_prefix.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ac_alt_ser_no_prefix.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ac_alt_ser_no_prefix.Location = new System.Drawing.Point(138, 18);
			txt_ac_alt_ser_no_prefix.MaxLength = 0;
			txt_ac_alt_ser_no_prefix.Name = "txt_ac_alt_ser_no_prefix";
			txt_ac_alt_ser_no_prefix.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_alt_ser_no_prefix.Size = new System.Drawing.Size(41, 21);
			txt_ac_alt_ser_no_prefix.TabIndex = 3;
			// 
			// txt_ac_alt_ser_no
			// 
			txt_ac_alt_ser_no.AcceptsReturn = true;
			txt_ac_alt_ser_no.AllowDrop = true;
			txt_ac_alt_ser_no.BackColor = System.Drawing.SystemColors.Window;
			txt_ac_alt_ser_no.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_ac_alt_ser_no.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ac_alt_ser_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ac_alt_ser_no.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ac_alt_ser_no.Location = new System.Drawing.Point(180, 18);
			txt_ac_alt_ser_no.MaxLength = 0;
			txt_ac_alt_ser_no.Name = "txt_ac_alt_ser_no";
			txt_ac_alt_ser_no.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_alt_ser_no.Size = new System.Drawing.Size(57, 21);
			txt_ac_alt_ser_no.TabIndex = 4;
			// 
			// txt_ac_alt_ser_no_suffix
			// 
			txt_ac_alt_ser_no_suffix.AcceptsReturn = true;
			txt_ac_alt_ser_no_suffix.AllowDrop = true;
			txt_ac_alt_ser_no_suffix.BackColor = System.Drawing.SystemColors.Window;
			txt_ac_alt_ser_no_suffix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_ac_alt_ser_no_suffix.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ac_alt_ser_no_suffix.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ac_alt_ser_no_suffix.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ac_alt_ser_no_suffix.Location = new System.Drawing.Point(238, 18);
			txt_ac_alt_ser_no_suffix.MaxLength = 0;
			txt_ac_alt_ser_no_suffix.Name = "txt_ac_alt_ser_no_suffix";
			txt_ac_alt_ser_no_suffix.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_alt_ser_no_suffix.Size = new System.Drawing.Size(57, 21);
			txt_ac_alt_ser_no_suffix.TabIndex = 5;
			// 
			// _lbl_gen_14
			// 
			_lbl_gen_14.AllowDrop = true;
			_lbl_gen_14.AutoSize = true;
			_lbl_gen_14.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_14.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_14.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_14.Location = new System.Drawing.Point(90, 107);
			_lbl_gen_14.MinimumSize = new System.Drawing.Size(32, 13);
			_lbl_gen_14.Name = "_lbl_gen_14";
			_lbl_gen_14.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_14.Size = new System.Drawing.Size(32, 13);
			_lbl_gen_14.TabIndex = 106;
			_lbl_gen_14.Text = "FAA Id";
			_lbl_gen_14.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// _lbl_gen_13
			// 
			_lbl_gen_13.AllowDrop = true;
			_lbl_gen_13.AutoSize = true;
			_lbl_gen_13.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_13.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_13.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_13.Location = new System.Drawing.Point(326, 81);
			_lbl_gen_13.MinimumSize = new System.Drawing.Size(41, 29);
			_lbl_gen_13.Name = "_lbl_gen_13";
			_lbl_gen_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_13.Size = new System.Drawing.Size(41, 29);
			_lbl_gen_13.TabIndex = 85;
			_lbl_gen_13.Text = "Show Airports";
			_lbl_gen_13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			_lbl_gen_13.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// _lbl_gen_12
			// 
			_lbl_gen_12.AllowDrop = true;
			_lbl_gen_12.AutoSize = true;
			_lbl_gen_12.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_12.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_12.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_12.Location = new System.Drawing.Point(132, 107);
			_lbl_gen_12.MinimumSize = new System.Drawing.Size(17, 13);
			_lbl_gen_12.Name = "_lbl_gen_12";
			_lbl_gen_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_12.Size = new System.Drawing.Size(17, 13);
			_lbl_gen_12.TabIndex = 80;
			_lbl_gen_12.Text = "City";
			_lbl_gen_12.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// _lbl_gen_66
			// 
			_lbl_gen_66.AllowDrop = true;
			_lbl_gen_66.AutoSize = true;
			_lbl_gen_66.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_66.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_66.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_66.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_66.Location = new System.Drawing.Point(4, 107);
			_lbl_gen_66.MinimumSize = new System.Drawing.Size(24, 13);
			_lbl_gen_66.Name = "_lbl_gen_66";
			_lbl_gen_66.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_66.Size = new System.Drawing.Size(24, 13);
			_lbl_gen_66.TabIndex = 76;
			_lbl_gen_66.Text = "IATA";
			_lbl_gen_66.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// _lbl_gen_67
			// 
			_lbl_gen_67.AllowDrop = true;
			_lbl_gen_67.AutoSize = true;
			_lbl_gen_67.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_67.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_67.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_67.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_67.Location = new System.Drawing.Point(46, 107);
			_lbl_gen_67.MinimumSize = new System.Drawing.Size(25, 13);
			_lbl_gen_67.Name = "_lbl_gen_67";
			_lbl_gen_67.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_67.Size = new System.Drawing.Size(25, 13);
			_lbl_gen_67.TabIndex = 75;
			_lbl_gen_67.Text = "ICAO";
			_lbl_gen_67.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// _lbl_gen_68
			// 
			_lbl_gen_68.AllowDrop = true;
			_lbl_gen_68.AutoSize = true;
			_lbl_gen_68.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_68.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_68.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_68.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_68.Location = new System.Drawing.Point(18, 147);
			_lbl_gen_68.MinimumSize = new System.Drawing.Size(28, 13);
			_lbl_gen_68.Name = "_lbl_gen_68";
			_lbl_gen_68.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_68.Size = new System.Drawing.Size(28, 13);
			_lbl_gen_68.TabIndex = 74;
			_lbl_gen_68.Text = "Name";
			_lbl_gen_68.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// _lbl_gen_69
			// 
			_lbl_gen_69.AllowDrop = true;
			_lbl_gen_69.AutoSize = true;
			_lbl_gen_69.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_69.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_69.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_69.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_69.Location = new System.Drawing.Point(224, 107);
			_lbl_gen_69.MinimumSize = new System.Drawing.Size(25, 13);
			_lbl_gen_69.Name = "_lbl_gen_69";
			_lbl_gen_69.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_69.Size = new System.Drawing.Size(25, 13);
			_lbl_gen_69.TabIndex = 73;
			_lbl_gen_69.Text = "State";
			_lbl_gen_69.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// _lbl_gen_74
			// 
			_lbl_gen_74.AllowDrop = true;
			_lbl_gen_74.AutoSize = true;
			_lbl_gen_74.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_74.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_74.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_74.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_74.Location = new System.Drawing.Point(267, 106);
			_lbl_gen_74.MinimumSize = new System.Drawing.Size(36, 13);
			_lbl_gen_74.Name = "_lbl_gen_74";
			_lbl_gen_74.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_74.Size = new System.Drawing.Size(36, 13);
			_lbl_gen_74.TabIndex = 72;
			_lbl_gen_74.Text = "Country";
			_lbl_gen_74.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// _lbl_gen_240
			// 
			_lbl_gen_240.AllowDrop = true;
			_lbl_gen_240.AutoSize = true;
			_lbl_gen_240.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_240.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_240.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_240.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_240.Location = new System.Drawing.Point(18, 67);
			_lbl_gen_240.MinimumSize = new System.Drawing.Size(69, 13);
			_lbl_gen_240.Name = "_lbl_gen_240";
			_lbl_gen_240.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_240.Size = new System.Drawing.Size(69, 13);
			_lbl_gen_240.TabIndex = 47;
			_lbl_gen_240.Text = "Registration #:";
			_lbl_gen_240.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// _lbl_gen_5
			// 
			_lbl_gen_5.AllowDrop = true;
			_lbl_gen_5.AutoSize = true;
			_lbl_gen_5.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_5.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_5.Location = new System.Drawing.Point(213, 67);
			_lbl_gen_5.MinimumSize = new System.Drawing.Size(96, 13);
			_lbl_gen_5.Name = "_lbl_gen_5";
			_lbl_gen_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_5.Size = new System.Drawing.Size(96, 13);
			_lbl_gen_5.TabIndex = 46;
			_lbl_gen_5.Text = "Year Mfg/Delivered:";
			_lbl_gen_5.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// _lbl_gen_4
			// 
			_lbl_gen_4.AllowDrop = true;
			_lbl_gen_4.AutoSize = true;
			_lbl_gen_4.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_4.ForeColor = System.Drawing.Color.Blue;
			_lbl_gen_4.Location = new System.Drawing.Point(18, 44);
			_lbl_gen_4.MinimumSize = new System.Drawing.Size(118, 13);
			_lbl_gen_4.Name = "_lbl_gen_4";
			_lbl_gen_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_4.Size = new System.Drawing.Size(118, 13);
			_lbl_gen_4.TabIndex = 45;
			_lbl_gen_4.Text = "Serial # Prefix/No/Suffix:";
			_lbl_gen_4.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// _lbl_gen_3
			// 
			_lbl_gen_3.AllowDrop = true;
			_lbl_gen_3.AutoSize = true;
			_lbl_gen_3.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_3.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_3.Location = new System.Drawing.Point(18, 22);
			_lbl_gen_3.MinimumSize = new System.Drawing.Size(14, 13);
			_lbl_gen_3.Name = "_lbl_gen_3";
			_lbl_gen_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_3.Size = new System.Drawing.Size(14, 13);
			_lbl_gen_3.TabIndex = 44;
			_lbl_gen_3.Text = "ID:";
			_lbl_gen_3.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// _lbl_gen_241
			// 
			_lbl_gen_241.AllowDrop = true;
			_lbl_gen_241.AutoSize = true;
			_lbl_gen_241.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_241.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_241.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_241.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_241.Location = new System.Drawing.Point(18, 89);
			_lbl_gen_241.MinimumSize = new System.Drawing.Size(58, 13);
			_lbl_gen_241.Name = "_lbl_gen_241";
			_lbl_gen_241.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_241.Size = new System.Drawing.Size(58, 13);
			_lbl_gen_241.TabIndex = 43;
			_lbl_gen_241.Text = "Prev. Reg#:";
			_lbl_gen_241.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// _lbl_gen_30
			// 
			_lbl_gen_30.AllowDrop = true;
			_lbl_gen_30.AutoSize = true;
			_lbl_gen_30.BackColor = System.Drawing.SystemColors.Control;
			_lbl_gen_30.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_30.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_30.Location = new System.Drawing.Point(88, 22);
			_lbl_gen_30.MinimumSize = new System.Drawing.Size(41, 13);
			_lbl_gen_30.Name = "_lbl_gen_30";
			_lbl_gen_30.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_30.Size = new System.Drawing.Size(41, 13);
			_lbl_gen_30.TabIndex = 42;
			_lbl_gen_30.Text = "Alt. S/N:";
			_lbl_gen_30.Click += new System.EventHandler(lbl_gen_Click);
			// 
			// frm_AddAircraft
			// 
			AcceptButton = cmdSave;
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(6, 13);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			BackColor = System.Drawing.SystemColors.Control;
			ClientSize = new System.Drawing.Size(975, 481);
			ControlBox = false;
			Controls.Add(cmd_override);
			Controls.Add(pnl_Manufacturer);
			Controls.Add(pnlStatusInfo);
			Controls.Add(cmdCancel);
			Controls.Add(cmdSave);
			Controls.Add(_pnl_gen_5);
			Controls.Add(_pnl_gen_1);
			Controls.Add(SSPanel_productCode);
			Controls.Add(_pnl_gen_0);
			Controls.Add(MainMenu1);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Location = new System.Drawing.Point(224, 220);
			MaximizeBox = true;
			MinimizeBox = true;
			Name = "frm_AddAircraft";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			Text = "Add Aircraft";
			commandButtonHelper1.SetStyle(cmd_override, 0);
			commandButtonHelper1.SetStyle(cmdFindManufacturer, 0);
			commandButtonHelper1.SetStyle(cmdCancel, 0);
			commandButtonHelper1.SetStyle(cmdSave, 0);
			listBoxHelper1.SetSelectionMode(lstManufacturer, System.Windows.Forms.SelectionMode.One);
			ToolTipMain.SetToolTip(_lbl_gen_4, "Click to Change Default Prefix and/or Suffix");
			Activated += new System.EventHandler(Form_Activated);
			Closed += new System.EventHandler(Form_Closed);
			pnl_Manufacturer.ResumeLayout(false);
			pnl_Manufacturer.PerformLayout();
			pnlStatusInfo.ResumeLayout(false);
			pnlStatusInfo.PerformLayout();
			pnl_Sale_Data.ResumeLayout(false);
			pnl_Sale_Data.PerformLayout();
			_pnl_gen_5.ResumeLayout(false);
			_pnl_gen_5.PerformLayout();
			_pnl_gen_1.ResumeLayout(false);
			_pnl_gen_1.PerformLayout();
			SSPanel_productCode.ResumeLayout(false);
			SSPanel_productCode.PerformLayout();
			_pnl_gen_0.ResumeLayout(false);
			_pnl_gen_0.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
		void ReLoadForm(bool addEvents)
		{
			Initializetxt_ac_engine_tbo_hrs();
			InitializetxtBaseCode();
			Initializepnl_gen();
			Initializelbl_gen();
			Initializelbl_engine();
			InitializelblMakeModel();
			Initializeac_product_chk();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			MdiParent = JETNET_Homebase.mdi_ResearchAssistant.DefInstance;
			JETNET_Homebase.mdi_ResearchAssistant.DefInstance.Show();
			Form_Initialize();
		}
		void Initializetxt_ac_engine_tbo_hrs()
		{
			txt_ac_engine_tbo_hrs = new System.Windows.Forms.TextBox[4];
			txt_ac_engine_tbo_hrs[1] = _txt_ac_engine_tbo_hrs_1;
			txt_ac_engine_tbo_hrs[3] = _txt_ac_engine_tbo_hrs_3;
			txt_ac_engine_tbo_hrs[2] = _txt_ac_engine_tbo_hrs_2;
			txt_ac_engine_tbo_hrs[0] = _txt_ac_engine_tbo_hrs_0;
		}
		void InitializetxtBaseCode()
		{
			txtBaseCode = new System.Windows.Forms.TextBox[6];
			txtBaseCode[3] = _txtBaseCode_3;
			txtBaseCode[5] = _txtBaseCode_5;
			txtBaseCode[0] = _txtBaseCode_0;
			txtBaseCode[1] = _txtBaseCode_1;
			txtBaseCode[2] = _txtBaseCode_2;
		}
		void Initializepnl_gen()
		{
			pnl_gen = new System.Windows.Forms.Panel[6];
			pnl_gen[5] = _pnl_gen_5;
			pnl_gen[1] = _pnl_gen_1;
			pnl_gen[0] = _pnl_gen_0;
		}
		void Initializelbl_gen()
		{
			lbl_gen = new System.Windows.Forms.Label[242];
			lbl_gen[33] = _lbl_gen_33;
			lbl_gen[32] = _lbl_gen_32;
			lbl_gen[31] = _lbl_gen_31;
			lbl_gen[17] = _lbl_gen_17;
			lbl_gen[9] = _lbl_gen_9;
			lbl_gen[10] = _lbl_gen_10;
			lbl_gen[6] = _lbl_gen_6;
			lbl_gen[8] = _lbl_gen_8;
			lbl_gen[7] = _lbl_gen_7;
			lbl_gen[11] = _lbl_gen_11;
			lbl_gen[1] = _lbl_gen_1;
			lbl_gen[2] = _lbl_gen_2;
			lbl_gen[0] = _lbl_gen_0;
			lbl_gen[19] = _lbl_gen_19;
			lbl_gen[26] = _lbl_gen_26;
			lbl_gen[14] = _lbl_gen_14;
			lbl_gen[13] = _lbl_gen_13;
			lbl_gen[12] = _lbl_gen_12;
			lbl_gen[66] = _lbl_gen_66;
			lbl_gen[67] = _lbl_gen_67;
			lbl_gen[68] = _lbl_gen_68;
			lbl_gen[69] = _lbl_gen_69;
			lbl_gen[74] = _lbl_gen_74;
			lbl_gen[240] = _lbl_gen_240;
			lbl_gen[5] = _lbl_gen_5;
			lbl_gen[4] = _lbl_gen_4;
			lbl_gen[3] = _lbl_gen_3;
			lbl_gen[241] = _lbl_gen_241;
			lbl_gen[30] = _lbl_gen_30;
		}
		void Initializelbl_engine()
		{
			lbl_engine = new System.Windows.Forms.Label[11];
			lbl_engine[8] = _lbl_engine_8;
			lbl_engine[10] = _lbl_engine_10;
			lbl_engine[7] = _lbl_engine_7;
			lbl_engine[9] = _lbl_engine_9;
		}
		void InitializelblMakeModel()
		{
			lblMakeModel = new System.Windows.Forms.Label[2];
			lblMakeModel[1] = _lblMakeModel_1;
			lblMakeModel[0] = _lblMakeModel_0;
		}
		void Initializeac_product_chk()
		{
			ac_product_chk = new System.Windows.Forms.CheckBox[6];
			ac_product_chk[0] = _ac_product_chk_0;
			ac_product_chk[1] = _ac_product_chk_1;
			ac_product_chk[2] = _ac_product_chk_2;
			ac_product_chk[4] = _ac_product_chk_4;
			ac_product_chk[5] = _ac_product_chk_5;
			ac_product_chk[3] = _ac_product_chk_3;
		}
		#endregion
	}
}