
namespace JETNET_Homebase
{
	partial class frm_Aircraft_Change
	{

		#region "Upgrade Support "
		private static frm_Aircraft_Change m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_Aircraft_Change DefInstance
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
		public static frm_Aircraft_Change CreateInstance()
		{
			frm_Aircraft_Change theInstance = new frm_Aircraft_Change();
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
		private string[] visualControls = new string[]{"components", "ToolTipMain", "mnuTest", "mnuFileClose", "mnuFile", "MainMenu1", "cmd_Identify_Registered_As", "lst_Registered_As", "lbl_Step_4a", "pnl_Registered_As", "cbo_Trans_Buyer", "cbo_Trans_Seller", "chk_Correction_Transaction", "txt_Transaction_Type", "chk_Internal_Transaction", "chk_NewAircraft", "Line1", "lbl_Trans_Buyer", "lbl_Trans_Seller", "Label5", "pnl_Verify", "chk_Date_Sold_Unknown", "txt_transaction_date", "cal_transaction_date", "lbl_test_omg4", "lbl_Step_2", "pnl_Date", "tbr_ToolBar_Buttons_Button1", "tbr_ToolBar_Buttons_Button2", "tbr_ToolBar_Buttons_Button3", "tbr_ToolBar_Buttons_Button4", "tbr_ToolBar_Buttons_Button5", "tbr_ToolBar_Buttons_Button6", "tbr_ToolBar_Buttons_Button7", "tbr_ToolBar_Buttons_Button8", "tbr_ToolBar", "lst_Aircraft_Info", "pnl_Current_Status", "txt_Registration_No", "opt_Historical", "opt_Current", "lbl_Registration_No", "lbl_Step_1", "pnl_Sale_Type", "cmdShowFractionalGrid", "cmd_Identify_Seller", "lst_Seller", "lbl_Step_3", "pnl_Seller", "chk_Financial_Documents", "txt_Customer_Notes", "txt_Internal_Notes", "cmd_Commit_Transaction", "cmd_Cancel", "lbl_no_bus_types", "lbl_Customer_Notes", "lbl_Internal_Notes", "pnl_Commit_Transaction", "cbo_ac_delivery", "txt_ac_list_date", "txt_ac_asking_price", "cbo_ac_asking", "_lbl_gen_6", "lbl_ac_list_date", "_lbl_gen_9", "pnl_Asking_Info", "txt_exp_comfirm_date", "chk_Lease_Take_Off_Market", "chk_Avail_Prior", "txt_lease_notes", "txt_lease_term", "txt_lease_type", "txt_lease_expiration_date", "lbl_Avail_Prior", "lbl_exp_comfirm_date", "lbl_lease_notes", "lbl_lease_term", "lbl_lease_type", "lbl_lease_expiration_date", "pnl_Lease_Information", "cmd_Identify_Buyer", "cbo_Unknown_State", "cbo_Unknown_Country", "lbl_Unknown_Country", "lbl_Unknown_City", "fra_Awaiting_Documentation", "cmd_Fractional_Buyer_Cancel", "cmd_Fractional_Buyer_OK", "chk_Awaiting_Documentation", "lst_Buyer", "lbl_Step_4", "pnl_Buyer", "cmd_remove_grid_row", "cmd_Fractional_Cancel", "cmd_Fractional_OK", "opt_Fractional_Buyer", "opt_Fractional_Seller", "txt_Percentage", "lbl_To_Buy_Sell", "lbl_Percentage", "pnl_Indicate_Seller_Buyer", "chkFractionalAwaitDocs", "cmd_Ident_Hist_Frac_Seller", "cmdDoneWithGrid", "cmd_await_doc_Seller", "cmd_await_doc", "chk_Fractional_Correction", "cmd_Identify_Fractional_Buyer", "grd_Fractional", "lbl_Aircrft_Ownership_Worksheet", "lbl_Fraction_Sale", "pnl_Fractional_Seller", "Label1", "pnl_Please_Wait", "chk_Take_Off_Market", "chk_was_available", "pnl_Update_Aircraft_row", "_lbl_gen_0", "lbl_Message", "lbl_gen", "optionButtonHelper1", "listBoxHelper1", "commandButtonHelper1"};
		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;
		public System.Windows.Forms.ToolTip ToolTipMain;
		public System.Windows.Forms.ToolStripMenuItem mnuTest;
		public System.Windows.Forms.ToolStripMenuItem mnuFileClose;
		public System.Windows.Forms.ToolStripMenuItem mnuFile;
		public System.Windows.Forms.MenuStrip MainMenu1;
		public System.Windows.Forms.Button cmd_Identify_Registered_As;
		public System.Windows.Forms.ListBox lst_Registered_As;
		public System.Windows.Forms.Label lbl_Step_4a;
		public System.Windows.Forms.Panel pnl_Registered_As;
		public System.Windows.Forms.ComboBox cbo_Trans_Buyer;
		public System.Windows.Forms.ComboBox cbo_Trans_Seller;
		public System.Windows.Forms.CheckBox chk_Correction_Transaction;
		public System.Windows.Forms.TextBox txt_Transaction_Type;
		public System.Windows.Forms.CheckBox chk_Internal_Transaction;
		public System.Windows.Forms.CheckBox chk_NewAircraft;
		public System.Windows.Forms.Label Line1;
		public System.Windows.Forms.Label lbl_Trans_Buyer;
		public System.Windows.Forms.Label lbl_Trans_Seller;
		public System.Windows.Forms.Label Label5;
		public System.Windows.Forms.Panel pnl_Verify;
		public System.Windows.Forms.CheckBox chk_Date_Sold_Unknown;
		public System.Windows.Forms.TextBox txt_transaction_date;
		public System.Windows.Forms.MonthCalendar cal_transaction_date;
		public System.Windows.Forms.Label lbl_test_omg4;
		public System.Windows.Forms.Label lbl_Step_2;
		public System.Windows.Forms.Panel pnl_Date;
		public System.Windows.Forms.ToolStripSeparator tbr_ToolBar_Buttons_Button1;
		public System.Windows.Forms.ToolStripButton tbr_ToolBar_Buttons_Button2;
		public System.Windows.Forms.ToolStripSeparator tbr_ToolBar_Buttons_Button3;
		public System.Windows.Forms.ToolStripButton tbr_ToolBar_Buttons_Button4;
		public System.Windows.Forms.ToolStripSeparator tbr_ToolBar_Buttons_Button5;
		public System.Windows.Forms.ToolStripButton tbr_ToolBar_Buttons_Button6;
		public System.Windows.Forms.ToolStripSeparator tbr_ToolBar_Buttons_Button7;
		public System.Windows.Forms.ToolStripButton tbr_ToolBar_Buttons_Button8;
		public System.Windows.Forms.ToolStrip tbr_ToolBar;
		public System.Windows.Forms.ListBox lst_Aircraft_Info;
		public System.Windows.Forms.Panel pnl_Current_Status;
		public System.Windows.Forms.TextBox txt_Registration_No;
		public System.Windows.Forms.RadioButton opt_Historical;
		public System.Windows.Forms.RadioButton opt_Current;
		public System.Windows.Forms.Label lbl_Registration_No;
		public System.Windows.Forms.Label lbl_Step_1;
		public System.Windows.Forms.Panel pnl_Sale_Type;
		public System.Windows.Forms.Button cmdShowFractionalGrid;
		public System.Windows.Forms.Button cmd_Identify_Seller;
		public System.Windows.Forms.ListBox lst_Seller;
		public System.Windows.Forms.Label lbl_Step_3;
		public System.Windows.Forms.Panel pnl_Seller;
		public System.Windows.Forms.CheckBox chk_Financial_Documents;
		public System.Windows.Forms.TextBox txt_Customer_Notes;
		public System.Windows.Forms.TextBox txt_Internal_Notes;
		public System.Windows.Forms.Button cmd_Commit_Transaction;
		public System.Windows.Forms.Button cmd_Cancel;
		public System.Windows.Forms.Label lbl_no_bus_types;
		public System.Windows.Forms.Label lbl_Customer_Notes;
		public System.Windows.Forms.Label lbl_Internal_Notes;
		public System.Windows.Forms.Panel pnl_Commit_Transaction;
		public System.Windows.Forms.ComboBox cbo_ac_delivery;
		public System.Windows.Forms.TextBox txt_ac_list_date;
		public System.Windows.Forms.TextBox txt_ac_asking_price;
		public System.Windows.Forms.ComboBox cbo_ac_asking;
		private System.Windows.Forms.Label _lbl_gen_6;
		public System.Windows.Forms.Label lbl_ac_list_date;
		private System.Windows.Forms.Label _lbl_gen_9;
		public System.Windows.Forms.Panel pnl_Asking_Info;
		public System.Windows.Forms.TextBox txt_exp_comfirm_date;
		public System.Windows.Forms.CheckBox chk_Lease_Take_Off_Market;
		public System.Windows.Forms.CheckBox chk_Avail_Prior;
		public System.Windows.Forms.TextBox txt_lease_notes;
		public System.Windows.Forms.TextBox txt_lease_term;
		public System.Windows.Forms.TextBox txt_lease_type;
		public System.Windows.Forms.TextBox txt_lease_expiration_date;
		public System.Windows.Forms.Label lbl_Avail_Prior;
		public System.Windows.Forms.Label lbl_exp_comfirm_date;
		public System.Windows.Forms.Label lbl_lease_notes;
		public System.Windows.Forms.Label lbl_lease_term;
		public System.Windows.Forms.Label lbl_lease_type;
		public System.Windows.Forms.Label lbl_lease_expiration_date;
		public System.Windows.Forms.Panel pnl_Lease_Information;
		public System.Windows.Forms.Button cmd_Identify_Buyer;
		public System.Windows.Forms.ComboBox cbo_Unknown_State;
		public System.Windows.Forms.ComboBox cbo_Unknown_Country;
		public System.Windows.Forms.Label lbl_Unknown_Country;
		public System.Windows.Forms.Label lbl_Unknown_City;
		public System.Windows.Forms.GroupBox fra_Awaiting_Documentation;
		public System.Windows.Forms.Button cmd_Fractional_Buyer_Cancel;
		public System.Windows.Forms.Button cmd_Fractional_Buyer_OK;
		public System.Windows.Forms.CheckBox chk_Awaiting_Documentation;
		public System.Windows.Forms.ListBox lst_Buyer;
		public System.Windows.Forms.Label lbl_Step_4;
		public System.Windows.Forms.Panel pnl_Buyer;
		public System.Windows.Forms.Button cmd_remove_grid_row;
		public System.Windows.Forms.Button cmd_Fractional_Cancel;
		public System.Windows.Forms.Button cmd_Fractional_OK;
		public System.Windows.Forms.RadioButton opt_Fractional_Buyer;
		public System.Windows.Forms.RadioButton opt_Fractional_Seller;
		public System.Windows.Forms.TextBox txt_Percentage;
		public System.Windows.Forms.Label lbl_To_Buy_Sell;
		public System.Windows.Forms.Label lbl_Percentage;
		public System.Windows.Forms.Panel pnl_Indicate_Seller_Buyer;
		public System.Windows.Forms.CheckBox chkFractionalAwaitDocs;
		public System.Windows.Forms.Button cmd_Ident_Hist_Frac_Seller;
		public System.Windows.Forms.Button cmdDoneWithGrid;
		public System.Windows.Forms.Button cmd_await_doc_Seller;
		public System.Windows.Forms.Button cmd_await_doc;
		public System.Windows.Forms.CheckBox chk_Fractional_Correction;
		public System.Windows.Forms.Button cmd_Identify_Fractional_Buyer;
		public UpgradeHelpers.DataGridViewFlex grd_Fractional;
		public System.Windows.Forms.Label lbl_Aircrft_Ownership_Worksheet;
		public System.Windows.Forms.Label lbl_Fraction_Sale;
		public System.Windows.Forms.Panel pnl_Fractional_Seller;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Panel pnl_Please_Wait;
		public System.Windows.Forms.CheckBox chk_Take_Off_Market;
		public System.Windows.Forms.CheckBox chk_was_available;
		public System.Windows.Forms.Panel pnl_Update_Aircraft_row;
		private System.Windows.Forms.Label _lbl_gen_0;
		public System.Windows.Forms.Label lbl_Message;
		public System.Windows.Forms.Label[] lbl_gen = new System.Windows.Forms.Label[10];
		public UpgradeHelpers.Gui.Controls.OptionButtonHelper optionButtonHelper1;
		public UpgradeHelpers.Gui.Controls.ListBoxHelper listBoxHelper1;
		public UpgradeHelpers.Gui.Controls.CommandButtonHelper commandButtonHelper1;
		public System.ComponentModel.ComponentResourceManager resources;
        //NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Aircraft_Change));
			ToolTipMain = new System.Windows.Forms.ToolTip(components);
			MainMenu1 = new System.Windows.Forms.MenuStrip();
			mnuFile = new System.Windows.Forms.ToolStripMenuItem();
			mnuTest = new System.Windows.Forms.ToolStripMenuItem();
			mnuFileClose = new System.Windows.Forms.ToolStripMenuItem();
			pnl_Registered_As = new System.Windows.Forms.Panel();
			cmd_Identify_Registered_As = new System.Windows.Forms.Button();
			lst_Registered_As = new System.Windows.Forms.ListBox();
			lbl_Step_4a = new System.Windows.Forms.Label();
			pnl_Verify = new System.Windows.Forms.Panel();
			cbo_Trans_Buyer = new System.Windows.Forms.ComboBox();
			cbo_Trans_Seller = new System.Windows.Forms.ComboBox();
			chk_Correction_Transaction = new System.Windows.Forms.CheckBox();
			txt_Transaction_Type = new System.Windows.Forms.TextBox();
			chk_Internal_Transaction = new System.Windows.Forms.CheckBox();
			chk_NewAircraft = new System.Windows.Forms.CheckBox();
			Line1 = new System.Windows.Forms.Label();
			lbl_Trans_Buyer = new System.Windows.Forms.Label();
			lbl_Trans_Seller = new System.Windows.Forms.Label();
			Label5 = new System.Windows.Forms.Label();
			pnl_Date = new System.Windows.Forms.Panel();
			chk_Date_Sold_Unknown = new System.Windows.Forms.CheckBox();
			txt_transaction_date = new System.Windows.Forms.TextBox();
			cal_transaction_date = new System.Windows.Forms.MonthCalendar();
			lbl_test_omg4 = new System.Windows.Forms.Label();
			lbl_Step_2 = new System.Windows.Forms.Label();
			tbr_ToolBar = new System.Windows.Forms.ToolStrip();
			tbr_ToolBar_Buttons_Button1 = new System.Windows.Forms.ToolStripSeparator();
			tbr_ToolBar_Buttons_Button2 = new System.Windows.Forms.ToolStripButton();
			tbr_ToolBar_Buttons_Button3 = new System.Windows.Forms.ToolStripSeparator();
			tbr_ToolBar_Buttons_Button4 = new System.Windows.Forms.ToolStripButton();
			tbr_ToolBar_Buttons_Button5 = new System.Windows.Forms.ToolStripSeparator();
			tbr_ToolBar_Buttons_Button6 = new System.Windows.Forms.ToolStripButton();
			tbr_ToolBar_Buttons_Button7 = new System.Windows.Forms.ToolStripSeparator();
			tbr_ToolBar_Buttons_Button8 = new System.Windows.Forms.ToolStripButton();
			pnl_Current_Status = new System.Windows.Forms.Panel();
			lst_Aircraft_Info = new System.Windows.Forms.ListBox();
			pnl_Sale_Type = new System.Windows.Forms.Panel();
			txt_Registration_No = new System.Windows.Forms.TextBox();
			opt_Historical = new System.Windows.Forms.RadioButton();
			opt_Current = new System.Windows.Forms.RadioButton();
			lbl_Registration_No = new System.Windows.Forms.Label();
			lbl_Step_1 = new System.Windows.Forms.Label();
			pnl_Seller = new System.Windows.Forms.Panel();
			cmdShowFractionalGrid = new System.Windows.Forms.Button();
			cmd_Identify_Seller = new System.Windows.Forms.Button();
			lst_Seller = new System.Windows.Forms.ListBox();
			lbl_Step_3 = new System.Windows.Forms.Label();
			pnl_Commit_Transaction = new System.Windows.Forms.Panel();
			chk_Financial_Documents = new System.Windows.Forms.CheckBox();
			txt_Customer_Notes = new System.Windows.Forms.TextBox();
			txt_Internal_Notes = new System.Windows.Forms.TextBox();
			cmd_Commit_Transaction = new System.Windows.Forms.Button();
			cmd_Cancel = new System.Windows.Forms.Button();
			lbl_no_bus_types = new System.Windows.Forms.Label();
			lbl_Customer_Notes = new System.Windows.Forms.Label();
			lbl_Internal_Notes = new System.Windows.Forms.Label();
			pnl_Lease_Information = new System.Windows.Forms.Panel();
			pnl_Asking_Info = new System.Windows.Forms.Panel();
			cbo_ac_delivery = new System.Windows.Forms.ComboBox();
			txt_ac_list_date = new System.Windows.Forms.TextBox();
			txt_ac_asking_price = new System.Windows.Forms.TextBox();
			cbo_ac_asking = new System.Windows.Forms.ComboBox();
			_lbl_gen_6 = new System.Windows.Forms.Label();
			lbl_ac_list_date = new System.Windows.Forms.Label();
			_lbl_gen_9 = new System.Windows.Forms.Label();
			txt_exp_comfirm_date = new System.Windows.Forms.TextBox();
			chk_Lease_Take_Off_Market = new System.Windows.Forms.CheckBox();
			chk_Avail_Prior = new System.Windows.Forms.CheckBox();
			txt_lease_notes = new System.Windows.Forms.TextBox();
			txt_lease_term = new System.Windows.Forms.TextBox();
			txt_lease_type = new System.Windows.Forms.TextBox();
			txt_lease_expiration_date = new System.Windows.Forms.TextBox();
			lbl_Avail_Prior = new System.Windows.Forms.Label();
			lbl_exp_comfirm_date = new System.Windows.Forms.Label();
			lbl_lease_notes = new System.Windows.Forms.Label();
			lbl_lease_term = new System.Windows.Forms.Label();
			lbl_lease_type = new System.Windows.Forms.Label();
			lbl_lease_expiration_date = new System.Windows.Forms.Label();
			pnl_Buyer = new System.Windows.Forms.Panel();
			cmd_Identify_Buyer = new System.Windows.Forms.Button();
			fra_Awaiting_Documentation = new System.Windows.Forms.GroupBox();
			cbo_Unknown_State = new System.Windows.Forms.ComboBox();
			cbo_Unknown_Country = new System.Windows.Forms.ComboBox();
			lbl_Unknown_Country = new System.Windows.Forms.Label();
			lbl_Unknown_City = new System.Windows.Forms.Label();
			cmd_Fractional_Buyer_Cancel = new System.Windows.Forms.Button();
			cmd_Fractional_Buyer_OK = new System.Windows.Forms.Button();
			chk_Awaiting_Documentation = new System.Windows.Forms.CheckBox();
			lst_Buyer = new System.Windows.Forms.ListBox();
			lbl_Step_4 = new System.Windows.Forms.Label();
			pnl_Indicate_Seller_Buyer = new System.Windows.Forms.Panel();
			cmd_remove_grid_row = new System.Windows.Forms.Button();
			cmd_Fractional_Cancel = new System.Windows.Forms.Button();
			cmd_Fractional_OK = new System.Windows.Forms.Button();
			opt_Fractional_Buyer = new System.Windows.Forms.RadioButton();
			opt_Fractional_Seller = new System.Windows.Forms.RadioButton();
			txt_Percentage = new System.Windows.Forms.TextBox();
			lbl_To_Buy_Sell = new System.Windows.Forms.Label();
			lbl_Percentage = new System.Windows.Forms.Label();
			pnl_Fractional_Seller = new System.Windows.Forms.Panel();
			chkFractionalAwaitDocs = new System.Windows.Forms.CheckBox();
			cmd_Ident_Hist_Frac_Seller = new System.Windows.Forms.Button();
			cmdDoneWithGrid = new System.Windows.Forms.Button();
			cmd_await_doc_Seller = new System.Windows.Forms.Button();
			cmd_await_doc = new System.Windows.Forms.Button();
			chk_Fractional_Correction = new System.Windows.Forms.CheckBox();
			cmd_Identify_Fractional_Buyer = new System.Windows.Forms.Button();
			grd_Fractional = new UpgradeHelpers.DataGridViewFlex(components);
			lbl_Aircrft_Ownership_Worksheet = new System.Windows.Forms.Label();
			lbl_Fraction_Sale = new System.Windows.Forms.Label();
			pnl_Please_Wait = new System.Windows.Forms.Panel();
			Label1 = new System.Windows.Forms.Label();
			pnl_Update_Aircraft_row = new System.Windows.Forms.Panel();
			chk_Take_Off_Market = new System.Windows.Forms.CheckBox();
			chk_was_available = new System.Windows.Forms.CheckBox();
			_lbl_gen_0 = new System.Windows.Forms.Label();
			lbl_Message = new System.Windows.Forms.Label();
			pnl_Registered_As.SuspendLayout();
			pnl_Verify.SuspendLayout();
			pnl_Date.SuspendLayout();
			tbr_ToolBar.SuspendLayout();
			pnl_Current_Status.SuspendLayout();
			pnl_Sale_Type.SuspendLayout();
			pnl_Seller.SuspendLayout();
			pnl_Commit_Transaction.SuspendLayout();
			pnl_Lease_Information.SuspendLayout();
			pnl_Asking_Info.SuspendLayout();
			pnl_Buyer.SuspendLayout();
			fra_Awaiting_Documentation.SuspendLayout();
			pnl_Indicate_Seller_Buyer.SuspendLayout();
			pnl_Fractional_Seller.SuspendLayout();
			pnl_Please_Wait.SuspendLayout();
			pnl_Update_Aircraft_row.SuspendLayout();
			SuspendLayout();
			optionButtonHelper1 = new UpgradeHelpers.Gui.Controls.OptionButtonHelper(components);
			listBoxHelper1 = new UpgradeHelpers.Gui.Controls.ListBoxHelper(components);
			commandButtonHelper1 = new UpgradeHelpers.Gui.Controls.CommandButtonHelper(components);
			((System.ComponentModel.ISupportInitialize) grd_Fractional).BeginInit();
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
			mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]{mnuTest, mnuFileClose});
			// 
			// mnuTest
			// 
			mnuTest.Available = false;
			mnuTest.Checked = false;
			mnuTest.Enabled = true;
			mnuTest.Name = "mnuTest";
			mnuTest.Text = "Test";
			// 
			// mnuFileClose
			// 
			mnuFileClose.Available = true;
			mnuFileClose.Checked = false;
			mnuFileClose.Enabled = true;
			mnuFileClose.Name = "mnuFileClose";
			mnuFileClose.Text = "&Close";
			mnuFileClose.Click += new System.EventHandler(mnuFileClose_Click);
			// 
			// pnl_Registered_As
			// 
			pnl_Registered_As.AllowDrop = true;
			pnl_Registered_As.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Registered_As.Controls.Add(cmd_Identify_Registered_As);
			pnl_Registered_As.Controls.Add(lst_Registered_As);
			pnl_Registered_As.Controls.Add(lbl_Step_4a);
			pnl_Registered_As.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Registered_As.Location = new System.Drawing.Point(418, 576);
			pnl_Registered_As.Name = "pnl_Registered_As";
			pnl_Registered_As.Size = new System.Drawing.Size(454, 101);
			pnl_Registered_As.TabIndex = 66;
			// 
			// cmd_Identify_Registered_As
			// 
			cmd_Identify_Registered_As.AllowDrop = true;
			cmd_Identify_Registered_As.BackColor = System.Drawing.SystemColors.Control;
			cmd_Identify_Registered_As.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Identify_Registered_As.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Identify_Registered_As.Location = new System.Drawing.Point(254, 70);
			cmd_Identify_Registered_As.Name = "cmd_Identify_Registered_As";
			cmd_Identify_Registered_As.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Identify_Registered_As.Size = new System.Drawing.Size(192, 27);
			cmd_Identify_Registered_As.TabIndex = 94;
			cmd_Identify_Registered_As.TabStop = false;
			cmd_Identify_Registered_As.Text = "Identify Registered as Purchaser";
			cmd_Identify_Registered_As.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Identify_Registered_As.UseVisualStyleBackColor = false;
			cmd_Identify_Registered_As.Click += new System.EventHandler(cmd_Identify_Registered_As_Click);
			cmd_Identify_Registered_As.MouseUp += new System.Windows.Forms.MouseEventHandler(cmd_Identify_Registered_As_MouseUp);
			// 
			// lst_Registered_As
			// 
			lst_Registered_As.AllowDrop = true;
			lst_Registered_As.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			lst_Registered_As.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lst_Registered_As.CausesValidation = true;
			lst_Registered_As.Enabled = true;
			lst_Registered_As.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lst_Registered_As.ForeColor = System.Drawing.SystemColors.WindowText;
			lst_Registered_As.IntegralHeight = true;
			lst_Registered_As.Location = new System.Drawing.Point(4, 4);
			lst_Registered_As.MultiColumn = false;
			lst_Registered_As.Name = "lst_Registered_As";
			lst_Registered_As.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lst_Registered_As.Size = new System.Drawing.Size(243, 96);
			lst_Registered_As.Sorted = false;
			lst_Registered_As.TabIndex = 67;
			lst_Registered_As.TabStop = false;
			lst_Registered_As.Visible = true;
			// 
			// lbl_Step_4a
			// 
			lbl_Step_4a.AllowDrop = true;
			lbl_Step_4a.BackColor = System.Drawing.Color.Transparent;
			lbl_Step_4a.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_Step_4a.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_Step_4a.ForeColor = System.Drawing.Color.Maroon;
			lbl_Step_4a.Location = new System.Drawing.Point(294, 16);
			lbl_Step_4a.MinimumSize = new System.Drawing.Size(113, 35);
			lbl_Step_4a.Name = "lbl_Step_4a";
			lbl_Step_4a.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_Step_4a.Size = new System.Drawing.Size(113, 35);
			lbl_Step_4a.TabIndex = 95;
			lbl_Step_4a.Text = "STEP 4a: Registered as";
			lbl_Step_4a.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// pnl_Verify
			// 
			pnl_Verify.AllowDrop = true;
			pnl_Verify.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Verify.Controls.Add(cbo_Trans_Buyer);
			pnl_Verify.Controls.Add(cbo_Trans_Seller);
			pnl_Verify.Controls.Add(chk_Correction_Transaction);
			pnl_Verify.Controls.Add(txt_Transaction_Type);
			pnl_Verify.Controls.Add(chk_Internal_Transaction);
			pnl_Verify.Controls.Add(chk_NewAircraft);
			pnl_Verify.Controls.Add(Line1);
			pnl_Verify.Controls.Add(lbl_Trans_Buyer);
			pnl_Verify.Controls.Add(lbl_Trans_Seller);
			pnl_Verify.Controls.Add(Label5);
			pnl_Verify.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Verify.Location = new System.Drawing.Point(417, 91);
			pnl_Verify.Name = "pnl_Verify";
			pnl_Verify.Size = new System.Drawing.Size(592, 114);
			pnl_Verify.TabIndex = 21;
			// 
			// cbo_Trans_Buyer
			// 
			cbo_Trans_Buyer.AllowDrop = true;
			cbo_Trans_Buyer.BackColor = System.Drawing.Color.White;
			cbo_Trans_Buyer.CausesValidation = true;
			cbo_Trans_Buyer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_Trans_Buyer.Enabled = true;
			cbo_Trans_Buyer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_Trans_Buyer.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_Trans_Buyer.IntegralHeight = true;
			cbo_Trans_Buyer.Location = new System.Drawing.Point(214, 84);
			cbo_Trans_Buyer.Name = "cbo_Trans_Buyer";
			cbo_Trans_Buyer.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_Trans_Buyer.Size = new System.Drawing.Size(195, 21);
			cbo_Trans_Buyer.Sorted = false;
			cbo_Trans_Buyer.TabIndex = 97;
			cbo_Trans_Buyer.TabStop = true;
			cbo_Trans_Buyer.Visible = true;
			cbo_Trans_Buyer.SelectedIndexChanged += new System.EventHandler(cbo_Trans_Buyer_SelectedIndexChanged);
			// 
			// cbo_Trans_Seller
			// 
			cbo_Trans_Seller.AllowDrop = true;
			cbo_Trans_Seller.BackColor = System.Drawing.Color.White;
			cbo_Trans_Seller.CausesValidation = true;
			cbo_Trans_Seller.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_Trans_Seller.Enabled = true;
			cbo_Trans_Seller.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_Trans_Seller.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_Trans_Seller.IntegralHeight = true;
			cbo_Trans_Seller.Location = new System.Drawing.Point(12, 84);
			cbo_Trans_Seller.Name = "cbo_Trans_Seller";
			cbo_Trans_Seller.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_Trans_Seller.Size = new System.Drawing.Size(195, 21);
			cbo_Trans_Seller.Sorted = false;
			cbo_Trans_Seller.TabIndex = 96;
			cbo_Trans_Seller.TabStop = true;
			cbo_Trans_Seller.Visible = true;
			cbo_Trans_Seller.SelectedIndexChanged += new System.EventHandler(cbo_Trans_Seller_SelectedIndexChanged);
			// 
			// chk_Correction_Transaction
			// 
			chk_Correction_Transaction.AllowDrop = true;
			chk_Correction_Transaction.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_Correction_Transaction.BackColor = System.Drawing.SystemColors.Control;
			chk_Correction_Transaction.CausesValidation = true;
			chk_Correction_Transaction.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_Correction_Transaction.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_Correction_Transaction.Enabled = true;
			chk_Correction_Transaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_Correction_Transaction.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_Correction_Transaction.Location = new System.Drawing.Point(233, 18);
			chk_Correction_Transaction.Name = "chk_Correction_Transaction";
			chk_Correction_Transaction.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_Correction_Transaction.Size = new System.Drawing.Size(158, 15);
			chk_Correction_Transaction.TabIndex = 70;
			chk_Correction_Transaction.TabStop = false;
			chk_Correction_Transaction.Text = "Correction Transaction";
			chk_Correction_Transaction.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_Correction_Transaction.Visible = true;
			chk_Correction_Transaction.CheckStateChanged += new System.EventHandler(chk_Correction_Transaction_CheckStateChanged);
			// 
			// txt_Transaction_Type
			// 
			txt_Transaction_Type.AcceptsReturn = true;
			txt_Transaction_Type.AllowDrop = true;
			txt_Transaction_Type.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_Transaction_Type.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_Transaction_Type.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_Transaction_Type.Enabled = false;
			txt_Transaction_Type.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_Transaction_Type.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_Transaction_Type.Location = new System.Drawing.Point(476, 59);
			txt_Transaction_Type.MaxLength = 0;
			txt_Transaction_Type.Name = "txt_Transaction_Type";
			txt_Transaction_Type.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_Transaction_Type.Size = new System.Drawing.Size(59, 19);
			txt_Transaction_Type.TabIndex = 34;
			txt_Transaction_Type.TabStop = false;
			// 
			// chk_Internal_Transaction
			// 
			chk_Internal_Transaction.AllowDrop = true;
			chk_Internal_Transaction.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_Internal_Transaction.BackColor = System.Drawing.SystemColors.Control;
			chk_Internal_Transaction.CausesValidation = true;
			chk_Internal_Transaction.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_Internal_Transaction.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_Internal_Transaction.Enabled = true;
			chk_Internal_Transaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_Internal_Transaction.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_Internal_Transaction.Location = new System.Drawing.Point(39, 18);
			chk_Internal_Transaction.Name = "chk_Internal_Transaction";
			chk_Internal_Transaction.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_Internal_Transaction.Size = new System.Drawing.Size(142, 15);
			chk_Internal_Transaction.TabIndex = 33;
			chk_Internal_Transaction.TabStop = false;
			chk_Internal_Transaction.Text = "Internal Transaction";
			chk_Internal_Transaction.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_Internal_Transaction.Visible = true;
			chk_Internal_Transaction.CheckStateChanged += new System.EventHandler(chk_Internal_Transaction_CheckStateChanged);
			// 
			// chk_NewAircraft
			// 
			chk_NewAircraft.AllowDrop = true;
			chk_NewAircraft.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_NewAircraft.BackColor = System.Drawing.SystemColors.Control;
			chk_NewAircraft.CausesValidation = true;
			chk_NewAircraft.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_NewAircraft.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_NewAircraft.Enabled = true;
			chk_NewAircraft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_NewAircraft.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_NewAircraft.Location = new System.Drawing.Point(425, 89);
			chk_NewAircraft.Name = "chk_NewAircraft";
			chk_NewAircraft.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_NewAircraft.Size = new System.Drawing.Size(158, 15);
			chk_NewAircraft.TabIndex = 88;
			chk_NewAircraft.TabStop = false;
			chk_NewAircraft.Text = "New Aircraft in Market";
			chk_NewAircraft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_NewAircraft.Visible = true;
			chk_NewAircraft.CheckStateChanged += new System.EventHandler(chk_NewAircraft_CheckStateChanged);
			// 
			// Line1
			// 
			Line1.AllowDrop = true;
			Line1.BackColor = System.Drawing.SystemColors.WindowText;
			Line1.Enabled = false;
			Line1.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Line1.Location = new System.Drawing.Point(11, 49);
			Line1.Name = "Line1";
			Line1.Size = new System.Drawing.Size(398, 1);
			Line1.Visible = true;
			// 
			// lbl_Trans_Buyer
			// 
			lbl_Trans_Buyer.AllowDrop = true;
			lbl_Trans_Buyer.BackColor = System.Drawing.Color.Transparent;
			lbl_Trans_Buyer.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_Trans_Buyer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_Trans_Buyer.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_Trans_Buyer.Location = new System.Drawing.Point(226, 62);
			lbl_Trans_Buyer.MinimumSize = new System.Drawing.Size(171, 17);
			lbl_Trans_Buyer.Name = "lbl_Trans_Buyer";
			lbl_Trans_Buyer.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_Trans_Buyer.Size = new System.Drawing.Size(171, 17);
			lbl_Trans_Buyer.TabIndex = 99;
			lbl_Trans_Buyer.Text = "Buyer type";
			lbl_Trans_Buyer.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lbl_Trans_Seller
			// 
			lbl_Trans_Seller.AllowDrop = true;
			lbl_Trans_Seller.BackColor = System.Drawing.Color.Transparent;
			lbl_Trans_Seller.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_Trans_Seller.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_Trans_Seller.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_Trans_Seller.Location = new System.Drawing.Point(24, 62);
			lbl_Trans_Seller.MinimumSize = new System.Drawing.Size(171, 17);
			lbl_Trans_Seller.Name = "lbl_Trans_Seller";
			lbl_Trans_Seller.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_Trans_Seller.Size = new System.Drawing.Size(171, 17);
			lbl_Trans_Seller.TabIndex = 98;
			lbl_Trans_Seller.Text = "Seller Type";
			lbl_Trans_Seller.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// Label5
			// 
			Label5.AllowDrop = true;
			Label5.BackColor = System.Drawing.Color.Transparent;
			Label5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label5.ForeColor = System.Drawing.Color.Maroon;
			Label5.Location = new System.Drawing.Point(440, 8);
			Label5.MinimumSize = new System.Drawing.Size(136, 49);
			Label5.Name = "Label5";
			Label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label5.Size = new System.Drawing.Size(136, 49);
			Label5.TabIndex = 22;
			Label5.Text = "STEP 5: Transaction Type";
			Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// pnl_Date
			// 
			pnl_Date.AllowDrop = true;
			pnl_Date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Date.Controls.Add(chk_Date_Sold_Unknown);
			pnl_Date.Controls.Add(txt_transaction_date);
			pnl_Date.Controls.Add(cal_transaction_date);
			pnl_Date.Controls.Add(lbl_test_omg4);
			pnl_Date.Controls.Add(lbl_Step_2);
			pnl_Date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Date.Location = new System.Drawing.Point(8, 205);
			pnl_Date.Name = "pnl_Date";
			pnl_Date.Size = new System.Drawing.Size(409, 183);
			pnl_Date.TabIndex = 12;
			// 
			// chk_Date_Sold_Unknown
			// 
			chk_Date_Sold_Unknown.AllowDrop = true;
			chk_Date_Sold_Unknown.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_Date_Sold_Unknown.BackColor = System.Drawing.SystemColors.Control;
			chk_Date_Sold_Unknown.CausesValidation = true;
			chk_Date_Sold_Unknown.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_Date_Sold_Unknown.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_Date_Sold_Unknown.Enabled = true;
			chk_Date_Sold_Unknown.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_Date_Sold_Unknown.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_Date_Sold_Unknown.Location = new System.Drawing.Point(260, 136);
			chk_Date_Sold_Unknown.Name = "chk_Date_Sold_Unknown";
			chk_Date_Sold_Unknown.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_Date_Sold_Unknown.Size = new System.Drawing.Size(142, 15);
			chk_Date_Sold_Unknown.TabIndex = 87;
			chk_Date_Sold_Unknown.TabStop = false;
			chk_Date_Sold_Unknown.Text = "Date Sold Unknown";
			chk_Date_Sold_Unknown.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_Date_Sold_Unknown.Visible = false;
			// 
			// txt_transaction_date
			// 
			txt_transaction_date.AcceptsReturn = true;
			txt_transaction_date.AllowDrop = true;
			txt_transaction_date.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			txt_transaction_date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_transaction_date.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_transaction_date.Enabled = false;
			txt_transaction_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_transaction_date.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_transaction_date.Location = new System.Drawing.Point(294, 80);
			txt_transaction_date.MaxLength = 0;
			txt_transaction_date.Name = "txt_transaction_date";
			txt_transaction_date.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_transaction_date.Size = new System.Drawing.Size(73, 19);
			txt_transaction_date.TabIndex = 18;
			txt_transaction_date.TabStop = false;
			// 
			// cal_transaction_date
			// 
			cal_transaction_date.AllowDrop = true;
			cal_transaction_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cal_transaction_date.ForeColor = System.Drawing.SystemColors.ControlText;
			cal_transaction_date.Location = new System.Drawing.Point(35, 15);
			cal_transaction_date.Name = "cal_transaction_date";
			cal_transaction_date.Size = new System.Drawing.Size(178, 154);
			cal_transaction_date.TabIndex = 17;
			cal_transaction_date.TabStop = false;
			cal_transaction_date.Enter += new System.EventHandler(cal_transaction_date_Enter);
			// 
			// lbl_test_omg4
			// 
			lbl_test_omg4.AllowDrop = true;
			lbl_test_omg4.BackColor = System.Drawing.Color.Aqua;
			lbl_test_omg4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_test_omg4.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_test_omg4.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_test_omg4.Location = new System.Drawing.Point(248, 48);
			lbl_test_omg4.MinimumSize = new System.Drawing.Size(145, 17);
			lbl_test_omg4.Name = "lbl_test_omg4";
			lbl_test_omg4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_test_omg4.Size = new System.Drawing.Size(145, 17);
			lbl_test_omg4.TabIndex = 103;
			lbl_test_omg4.Text = "-- You Are On Test --";
			lbl_test_omg4.Visible = false;
			// 
			// lbl_Step_2
			// 
			lbl_Step_2.AllowDrop = true;
			lbl_Step_2.BackColor = System.Drawing.Color.Transparent;
			lbl_Step_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_Step_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_Step_2.ForeColor = System.Drawing.Color.Maroon;
			lbl_Step_2.Location = new System.Drawing.Point(266, 8);
			lbl_Step_2.MinimumSize = new System.Drawing.Size(129, 35);
			lbl_Step_2.Name = "lbl_Step_2";
			lbl_Step_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_Step_2.Size = new System.Drawing.Size(129, 35);
			lbl_Step_2.TabIndex = 19;
			lbl_Step_2.Text = "STEP 2: Transaction Date";
			lbl_Step_2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// tbr_ToolBar
			// 
			tbr_ToolBar.AllowDrop = true;
			tbr_ToolBar.Dock = System.Windows.Forms.DockStyle.Top;
			tbr_ToolBar.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			tbr_ToolBar.Location = new System.Drawing.Point(0, 24);
			tbr_ToolBar.Name = "tbr_ToolBar";
			tbr_ToolBar.ShowItemToolTips = true;
			tbr_ToolBar.Size = new System.Drawing.Size(1010, 28);
			tbr_ToolBar.TabIndex = 9;
			tbr_ToolBar.Items.Add(tbr_ToolBar_Buttons_Button1);
			tbr_ToolBar.Items.Add(tbr_ToolBar_Buttons_Button2);
			tbr_ToolBar.Items.Add(tbr_ToolBar_Buttons_Button3);
			tbr_ToolBar.Items.Add(tbr_ToolBar_Buttons_Button4);
			tbr_ToolBar.Items.Add(tbr_ToolBar_Buttons_Button5);
			tbr_ToolBar.Items.Add(tbr_ToolBar_Buttons_Button6);
			tbr_ToolBar.Items.Add(tbr_ToolBar_Buttons_Button7);
			tbr_ToolBar.Items.Add(tbr_ToolBar_Buttons_Button8);
			// 
			// tbr_ToolBar_Buttons_Button1
			// 
			tbr_ToolBar_Buttons_Button1.Size = new System.Drawing.Size(6, 22);
			tbr_ToolBar_Buttons_Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			tbr_ToolBar_Buttons_Button1.Click += new System.EventHandler(tbr_ToolBar_ButtonClick);
			// 
			// tbr_ToolBar_Buttons_Button2
			// 
			tbr_ToolBar_Buttons_Button2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
			tbr_ToolBar_Buttons_Button2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			tbr_ToolBar_Buttons_Button2.Size = new System.Drawing.Size(24, 22);
			tbr_ToolBar_Buttons_Button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			tbr_ToolBar_Buttons_Button2.Click += new System.EventHandler(tbr_ToolBar_ButtonClick);
			// 
			// tbr_ToolBar_Buttons_Button3
			// 
			tbr_ToolBar_Buttons_Button3.Size = new System.Drawing.Size(6, 22);
			tbr_ToolBar_Buttons_Button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			tbr_ToolBar_Buttons_Button3.Click += new System.EventHandler(tbr_ToolBar_ButtonClick);
			// 
			// tbr_ToolBar_Buttons_Button4
			// 
			tbr_ToolBar_Buttons_Button4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
			tbr_ToolBar_Buttons_Button4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			tbr_ToolBar_Buttons_Button4.Size = new System.Drawing.Size(24, 22);
			tbr_ToolBar_Buttons_Button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			tbr_ToolBar_Buttons_Button4.Click += new System.EventHandler(tbr_ToolBar_ButtonClick);
			// 
			// tbr_ToolBar_Buttons_Button5
			// 
			tbr_ToolBar_Buttons_Button5.Size = new System.Drawing.Size(6, 22);
			tbr_ToolBar_Buttons_Button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			tbr_ToolBar_Buttons_Button5.Click += new System.EventHandler(tbr_ToolBar_ButtonClick);
			// 
			// tbr_ToolBar_Buttons_Button6
			// 
			tbr_ToolBar_Buttons_Button6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
			tbr_ToolBar_Buttons_Button6.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			tbr_ToolBar_Buttons_Button6.Size = new System.Drawing.Size(24, 22);
			tbr_ToolBar_Buttons_Button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			tbr_ToolBar_Buttons_Button6.Click += new System.EventHandler(tbr_ToolBar_ButtonClick);
			// 
			// tbr_ToolBar_Buttons_Button7
			// 
			tbr_ToolBar_Buttons_Button7.Size = new System.Drawing.Size(6, 22);
			tbr_ToolBar_Buttons_Button7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			tbr_ToolBar_Buttons_Button7.Click += new System.EventHandler(tbr_ToolBar_ButtonClick);
			// 
			// tbr_ToolBar_Buttons_Button8
			// 
			tbr_ToolBar_Buttons_Button8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
			tbr_ToolBar_Buttons_Button8.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			tbr_ToolBar_Buttons_Button8.Size = new System.Drawing.Size(24, 22);
			tbr_ToolBar_Buttons_Button8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			tbr_ToolBar_Buttons_Button8.Click += new System.EventHandler(tbr_ToolBar_ButtonClick);
			// 
			// pnl_Current_Status
			// 
			pnl_Current_Status.AllowDrop = true;
			pnl_Current_Status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Current_Status.Controls.Add(lst_Aircraft_Info);
			pnl_Current_Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Current_Status.Location = new System.Drawing.Point(8, 52);
			pnl_Current_Status.Name = "pnl_Current_Status";
			pnl_Current_Status.Size = new System.Drawing.Size(409, 104);
			pnl_Current_Status.TabIndex = 0;
			// 
			// lst_Aircraft_Info
			// 
			lst_Aircraft_Info.AllowDrop = true;
			lst_Aircraft_Info.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			lst_Aircraft_Info.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lst_Aircraft_Info.CausesValidation = true;
			lst_Aircraft_Info.Enabled = true;
			lst_Aircraft_Info.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lst_Aircraft_Info.ForeColor = System.Drawing.SystemColors.WindowText;
			lst_Aircraft_Info.IntegralHeight = true;
			lst_Aircraft_Info.Location = new System.Drawing.Point(45, 18);
			lst_Aircraft_Info.MultiColumn = false;
			lst_Aircraft_Info.Name = "lst_Aircraft_Info";
			lst_Aircraft_Info.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lst_Aircraft_Info.Size = new System.Drawing.Size(306, 83);
			lst_Aircraft_Info.Sorted = false;
			lst_Aircraft_Info.TabIndex = 11;
			lst_Aircraft_Info.TabStop = false;
			lst_Aircraft_Info.Visible = true;
			// 
			// pnl_Sale_Type
			// 
			pnl_Sale_Type.AllowDrop = true;
			pnl_Sale_Type.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Sale_Type.Controls.Add(txt_Registration_No);
			pnl_Sale_Type.Controls.Add(opt_Historical);
			pnl_Sale_Type.Controls.Add(opt_Current);
			pnl_Sale_Type.Controls.Add(lbl_Registration_No);
			pnl_Sale_Type.Controls.Add(lbl_Step_1);
			pnl_Sale_Type.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Sale_Type.Location = new System.Drawing.Point(8, 156);
			pnl_Sale_Type.Name = "pnl_Sale_Type";
			pnl_Sale_Type.Size = new System.Drawing.Size(409, 49);
			pnl_Sale_Type.TabIndex = 24;
			// 
			// txt_Registration_No
			// 
			txt_Registration_No.AcceptsReturn = true;
			txt_Registration_No.AllowDrop = true;
			txt_Registration_No.BackColor = System.Drawing.SystemColors.Window;
			txt_Registration_No.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_Registration_No.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_Registration_No.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_Registration_No.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_Registration_No.Location = new System.Drawing.Point(113, 24);
			txt_Registration_No.MaxLength = 0;
			txt_Registration_No.Name = "txt_Registration_No";
			txt_Registration_No.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_Registration_No.Size = new System.Drawing.Size(135, 19);
			txt_Registration_No.TabIndex = 1;
			txt_Registration_No.TextChanged += new System.EventHandler(txt_Registration_No_TextChanged);
			// 
			// opt_Historical
			// 
			opt_Historical.AllowDrop = true;
			opt_Historical.BackColor = System.Drawing.SystemColors.Control;
			opt_Historical.CausesValidation = true;
			opt_Historical.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opt_Historical.Checked = false;
			opt_Historical.Enabled = true;
			opt_Historical.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			opt_Historical.ForeColor = System.Drawing.SystemColors.ControlText;
			opt_Historical.Location = new System.Drawing.Point(122, 3);
			opt_Historical.Name = "opt_Historical";
			opt_Historical.RightToLeft = System.Windows.Forms.RightToLeft.No;
			opt_Historical.Size = new System.Drawing.Size(120, 17);
			opt_Historical.TabIndex = 26;
			opt_Historical.TabStop = false;
			opt_Historical.Text = "Insert Historical";
			opt_Historical.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opt_Historical.Visible = true;
			opt_Historical.CheckedChanged += new System.EventHandler(opt_Historical_CheckedChanged);
			// 
			// opt_Current
			// 
			opt_Current.AllowDrop = true;
			opt_Current.BackColor = System.Drawing.SystemColors.Control;
			opt_Current.CausesValidation = true;
			opt_Current.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opt_Current.Checked = true;
			opt_Current.Enabled = true;
			opt_Current.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			opt_Current.ForeColor = System.Drawing.SystemColors.ControlText;
			opt_Current.Location = new System.Drawing.Point(22, 3);
			opt_Current.Name = "opt_Current";
			opt_Current.RightToLeft = System.Windows.Forms.RightToLeft.No;
			opt_Current.Size = new System.Drawing.Size(82, 17);
			opt_Current.TabIndex = 25;
			opt_Current.TabStop = false;
			opt_Current.Text = "Current";
			opt_Current.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opt_Current.Visible = true;
			opt_Current.CheckedChanged += new System.EventHandler(opt_Current_CheckedChanged);
			// 
			// lbl_Registration_No
			// 
			lbl_Registration_No.AllowDrop = true;
			lbl_Registration_No.BackColor = System.Drawing.SystemColors.Control;
			lbl_Registration_No.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_Registration_No.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_Registration_No.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_Registration_No.Location = new System.Drawing.Point(16, 27);
			lbl_Registration_No.MinimumSize = new System.Drawing.Size(99, 17);
			lbl_Registration_No.Name = "lbl_Registration_No";
			lbl_Registration_No.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_Registration_No.Size = new System.Drawing.Size(99, 17);
			lbl_Registration_No.TabIndex = 56;
			lbl_Registration_No.Text = "Registration No:";
			// 
			// lbl_Step_1
			// 
			lbl_Step_1.AllowDrop = true;
			lbl_Step_1.AutoSize = true;
			lbl_Step_1.BackColor = System.Drawing.Color.Transparent;
			lbl_Step_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_Step_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_Step_1.ForeColor = System.Drawing.Color.Maroon;
			lbl_Step_1.Location = new System.Drawing.Point(274, 8);
			lbl_Step_1.MinimumSize = new System.Drawing.Size(110, 32);
			lbl_Step_1.Name = "lbl_Step_1";
			lbl_Step_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_Step_1.Size = new System.Drawing.Size(110, 32);
			lbl_Step_1.TabIndex = 27;
			lbl_Step_1.Text = "STEP 1: Type of Sale";
			lbl_Step_1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// pnl_Seller
			// 
			pnl_Seller.AllowDrop = true;
			pnl_Seller.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Seller.Controls.Add(cmdShowFractionalGrid);
			pnl_Seller.Controls.Add(cmd_Identify_Seller);
			pnl_Seller.Controls.Add(lst_Seller);
			pnl_Seller.Controls.Add(lbl_Step_3);
			pnl_Seller.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Seller.Location = new System.Drawing.Point(8, 388);
			pnl_Seller.Name = "pnl_Seller";
			pnl_Seller.Size = new System.Drawing.Size(409, 190);
			pnl_Seller.TabIndex = 13;
			// 
			// cmdShowFractionalGrid
			// 
			cmdShowFractionalGrid.AllowDrop = true;
			cmdShowFractionalGrid.BackColor = System.Drawing.SystemColors.Control;
			cmdShowFractionalGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdShowFractionalGrid.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdShowFractionalGrid.Location = new System.Drawing.Point(256, 152);
			cmdShowFractionalGrid.Name = "cmdShowFractionalGrid";
			cmdShowFractionalGrid.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdShowFractionalGrid.Size = new System.Drawing.Size(140, 27);
			cmdShowFractionalGrid.TabIndex = 91;
			cmdShowFractionalGrid.TabStop = false;
			cmdShowFractionalGrid.Text = "Show Buyer/Seller Grid";
			cmdShowFractionalGrid.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdShowFractionalGrid.UseVisualStyleBackColor = false;
			cmdShowFractionalGrid.Visible = false;
			cmdShowFractionalGrid.Click += new System.EventHandler(cmdShowFractionalGrid_Click);
			cmdShowFractionalGrid.MouseUp += new System.Windows.Forms.MouseEventHandler(cmdShowFractionalGrid_MouseUp);
			// 
			// cmd_Identify_Seller
			// 
			cmd_Identify_Seller.AllowDrop = true;
			cmd_Identify_Seller.BackColor = System.Drawing.SystemColors.Control;
			cmd_Identify_Seller.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Identify_Seller.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Identify_Seller.Location = new System.Drawing.Point(256, 80);
			cmd_Identify_Seller.Name = "cmd_Identify_Seller";
			cmd_Identify_Seller.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Identify_Seller.Size = new System.Drawing.Size(140, 27);
			cmd_Identify_Seller.TabIndex = 23;
			cmd_Identify_Seller.TabStop = false;
			cmd_Identify_Seller.Text = "Identify Seller";
			cmd_Identify_Seller.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Identify_Seller.UseVisualStyleBackColor = false;
			cmd_Identify_Seller.Click += new System.EventHandler(cmd_Identify_Seller_Click);
			cmd_Identify_Seller.MouseUp += new System.Windows.Forms.MouseEventHandler(cmd_Identify_Seller_MouseUp);
			// 
			// lst_Seller
			// 
			lst_Seller.AllowDrop = true;
			lst_Seller.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			lst_Seller.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lst_Seller.CausesValidation = true;
			lst_Seller.Enabled = true;
			lst_Seller.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lst_Seller.ForeColor = System.Drawing.SystemColors.WindowText;
			lst_Seller.IntegralHeight = true;
			lst_Seller.Location = new System.Drawing.Point(8, 7);
			lst_Seller.MultiColumn = false;
			lst_Seller.Name = "lst_Seller";
			lst_Seller.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lst_Seller.Size = new System.Drawing.Size(241, 174);
			lst_Seller.Sorted = false;
			lst_Seller.TabIndex = 15;
			lst_Seller.TabStop = false;
			lst_Seller.Visible = true;
			// 
			// lbl_Step_3
			// 
			lbl_Step_3.AllowDrop = true;
			lbl_Step_3.BackColor = System.Drawing.Color.Transparent;
			lbl_Step_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_Step_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_Step_3.ForeColor = System.Drawing.Color.Maroon;
			lbl_Step_3.Location = new System.Drawing.Point(256, 8);
			lbl_Step_3.MinimumSize = new System.Drawing.Size(140, 35);
			lbl_Step_3.Name = "lbl_Step_3";
			lbl_Step_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_Step_3.Size = new System.Drawing.Size(140, 35);
			lbl_Step_3.TabIndex = 20;
			lbl_Step_3.Text = "STEP 3: Seller";
			lbl_Step_3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// pnl_Commit_Transaction
			// 
			pnl_Commit_Transaction.AllowDrop = true;
			pnl_Commit_Transaction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Commit_Transaction.Controls.Add(chk_Financial_Documents);
			pnl_Commit_Transaction.Controls.Add(txt_Customer_Notes);
			pnl_Commit_Transaction.Controls.Add(txt_Internal_Notes);
			pnl_Commit_Transaction.Controls.Add(cmd_Commit_Transaction);
			pnl_Commit_Transaction.Controls.Add(cmd_Cancel);
			pnl_Commit_Transaction.Controls.Add(lbl_no_bus_types);
			pnl_Commit_Transaction.Controls.Add(lbl_Customer_Notes);
			pnl_Commit_Transaction.Controls.Add(lbl_Internal_Notes);
			pnl_Commit_Transaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Commit_Transaction.Location = new System.Drawing.Point(417, 205);
			pnl_Commit_Transaction.Name = "pnl_Commit_Transaction";
			pnl_Commit_Transaction.Size = new System.Drawing.Size(592, 183);
			pnl_Commit_Transaction.TabIndex = 40;
			// 
			// chk_Financial_Documents
			// 
			chk_Financial_Documents.AllowDrop = true;
			chk_Financial_Documents.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_Financial_Documents.BackColor = System.Drawing.SystemColors.Control;
			chk_Financial_Documents.CausesValidation = true;
			chk_Financial_Documents.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_Financial_Documents.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_Financial_Documents.Enabled = true;
			chk_Financial_Documents.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_Financial_Documents.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_Financial_Documents.Location = new System.Drawing.Point(32, 141);
			chk_Financial_Documents.Name = "chk_Financial_Documents";
			chk_Financial_Documents.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_Financial_Documents.Size = new System.Drawing.Size(153, 15);
			chk_Financial_Documents.TabIndex = 45;
			chk_Financial_Documents.TabStop = false;
			chk_Financial_Documents.Text = "Financial Documents";
			chk_Financial_Documents.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_Financial_Documents.Visible = true;
			// 
			// txt_Customer_Notes
			// 
			txt_Customer_Notes.AcceptsReturn = true;
			txt_Customer_Notes.AllowDrop = true;
			txt_Customer_Notes.BackColor = System.Drawing.SystemColors.Window;
			txt_Customer_Notes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_Customer_Notes.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_Customer_Notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_Customer_Notes.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_Customer_Notes.Location = new System.Drawing.Point(10, 84);
			txt_Customer_Notes.MaxLength = 255;
			txt_Customer_Notes.Multiline = true;
			txt_Customer_Notes.Name = "txt_Customer_Notes";
			txt_Customer_Notes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_Customer_Notes.Size = new System.Drawing.Size(561, 45);
			txt_Customer_Notes.TabIndex = 3;
			// 
			// txt_Internal_Notes
			// 
			txt_Internal_Notes.AcceptsReturn = true;
			txt_Internal_Notes.AllowDrop = true;
			txt_Internal_Notes.BackColor = System.Drawing.SystemColors.Window;
			txt_Internal_Notes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_Internal_Notes.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_Internal_Notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_Internal_Notes.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_Internal_Notes.Location = new System.Drawing.Point(10, 18);
			txt_Internal_Notes.MaxLength = 255;
			txt_Internal_Notes.Multiline = true;
			txt_Internal_Notes.Name = "txt_Internal_Notes";
			txt_Internal_Notes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_Internal_Notes.Size = new System.Drawing.Size(561, 45);
			txt_Internal_Notes.TabIndex = 2;
			// 
			// cmd_Commit_Transaction
			// 
			cmd_Commit_Transaction.AllowDrop = true;
			cmd_Commit_Transaction.BackColor = System.Drawing.SystemColors.Control;
			cmd_Commit_Transaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Commit_Transaction.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Commit_Transaction.Location = new System.Drawing.Point(328, 136);
			cmd_Commit_Transaction.Name = "cmd_Commit_Transaction";
			cmd_Commit_Transaction.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Commit_Transaction.Size = new System.Drawing.Size(114, 27);
			cmd_Commit_Transaction.TabIndex = 42;
			cmd_Commit_Transaction.TabStop = false;
			cmd_Commit_Transaction.Text = "Commit Transaction";
			cmd_Commit_Transaction.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Commit_Transaction.UseVisualStyleBackColor = false;
			cmd_Commit_Transaction.Click += new System.EventHandler(cmd_Commit_Transaction_Click);
			cmd_Commit_Transaction.MouseUp += new System.Windows.Forms.MouseEventHandler(cmd_Commit_Transaction_MouseUp);
			// 
			// cmd_Cancel
			// 
			cmd_Cancel.AllowDrop = true;
			cmd_Cancel.BackColor = System.Drawing.SystemColors.Control;
			cmd_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Cancel.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Cancel.Location = new System.Drawing.Point(194, 135);
			cmd_Cancel.Name = "cmd_Cancel";
			cmd_Cancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Cancel.Size = new System.Drawing.Size(114, 27);
			cmd_Cancel.TabIndex = 41;
			cmd_Cancel.TabStop = false;
			cmd_Cancel.Text = "Cancel Transaction";
			cmd_Cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Cancel.UseVisualStyleBackColor = false;
			cmd_Cancel.Click += new System.EventHandler(cmd_cancel_Click);
			cmd_Cancel.MouseUp += new System.Windows.Forms.MouseEventHandler(cmd_Cancel_MouseUp);
			// 
			// lbl_no_bus_types
			// 
			lbl_no_bus_types.AllowDrop = true;
			lbl_no_bus_types.BackColor = System.Drawing.SystemColors.Control;
			lbl_no_bus_types.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_no_bus_types.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_no_bus_types.ForeColor = System.Drawing.Color.Red;
			lbl_no_bus_types.Location = new System.Drawing.Point(8, 164);
			lbl_no_bus_types.MinimumSize = new System.Drawing.Size(569, 17);
			lbl_no_bus_types.Name = "lbl_no_bus_types";
			lbl_no_bus_types.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_no_bus_types.Size = new System.Drawing.Size(569, 17);
			lbl_no_bus_types.TabIndex = 102;
			lbl_no_bus_types.Text = "Bus Type Issues";
			lbl_no_bus_types.Visible = false;
			// 
			// lbl_Customer_Notes
			// 
			lbl_Customer_Notes.AllowDrop = true;
			lbl_Customer_Notes.BackColor = System.Drawing.SystemColors.Control;
			lbl_Customer_Notes.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_Customer_Notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_Customer_Notes.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_Customer_Notes.Location = new System.Drawing.Point(12, 70);
			lbl_Customer_Notes.MinimumSize = new System.Drawing.Size(103, 17);
			lbl_Customer_Notes.Name = "lbl_Customer_Notes";
			lbl_Customer_Notes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_Customer_Notes.Size = new System.Drawing.Size(103, 17);
			lbl_Customer_Notes.TabIndex = 44;
			lbl_Customer_Notes.Text = "Customer Notes:";
			// 
			// lbl_Internal_Notes
			// 
			lbl_Internal_Notes.AllowDrop = true;
			lbl_Internal_Notes.BackColor = System.Drawing.SystemColors.Control;
			lbl_Internal_Notes.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_Internal_Notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_Internal_Notes.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_Internal_Notes.Location = new System.Drawing.Point(14, 6);
			lbl_Internal_Notes.MinimumSize = new System.Drawing.Size(93, 17);
			lbl_Internal_Notes.Name = "lbl_Internal_Notes";
			lbl_Internal_Notes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_Internal_Notes.Size = new System.Drawing.Size(93, 17);
			lbl_Internal_Notes.TabIndex = 43;
			lbl_Internal_Notes.Text = "Internal Notes:";
			// 
			// pnl_Lease_Information
			// 
			pnl_Lease_Information.AllowDrop = true;
			pnl_Lease_Information.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Lease_Information.Controls.Add(pnl_Asking_Info);
			pnl_Lease_Information.Controls.Add(txt_exp_comfirm_date);
			pnl_Lease_Information.Controls.Add(chk_Lease_Take_Off_Market);
			pnl_Lease_Information.Controls.Add(chk_Avail_Prior);
			pnl_Lease_Information.Controls.Add(txt_lease_notes);
			pnl_Lease_Information.Controls.Add(txt_lease_term);
			pnl_Lease_Information.Controls.Add(txt_lease_type);
			pnl_Lease_Information.Controls.Add(txt_lease_expiration_date);
			pnl_Lease_Information.Controls.Add(lbl_Avail_Prior);
			pnl_Lease_Information.Controls.Add(lbl_exp_comfirm_date);
			pnl_Lease_Information.Controls.Add(lbl_lease_notes);
			pnl_Lease_Information.Controls.Add(lbl_lease_term);
			pnl_Lease_Information.Controls.Add(lbl_lease_type);
			pnl_Lease_Information.Controls.Add(lbl_lease_expiration_date);
			pnl_Lease_Information.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Lease_Information.ForeColor = System.Drawing.Color.Maroon;
			pnl_Lease_Information.Location = new System.Drawing.Point(417, 578);
			pnl_Lease_Information.Name = "pnl_Lease_Information";
			pnl_Lease_Information.Size = new System.Drawing.Size(592, 101);
			pnl_Lease_Information.TabIndex = 57;
			// 
			// pnl_Asking_Info
			// 
			pnl_Asking_Info.AllowDrop = true;
			pnl_Asking_Info.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
			pnl_Asking_Info.BorderStyle = System.Windows.Forms.BorderStyle.None;
			pnl_Asking_Info.Controls.Add(cbo_ac_delivery);
			pnl_Asking_Info.Controls.Add(txt_ac_list_date);
			pnl_Asking_Info.Controls.Add(txt_ac_asking_price);
			pnl_Asking_Info.Controls.Add(cbo_ac_asking);
			pnl_Asking_Info.Controls.Add(_lbl_gen_6);
			pnl_Asking_Info.Controls.Add(lbl_ac_list_date);
			pnl_Asking_Info.Controls.Add(_lbl_gen_9);
			pnl_Asking_Info.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Asking_Info.Location = new System.Drawing.Point(377, 1);
			pnl_Asking_Info.Name = "pnl_Asking_Info";
			pnl_Asking_Info.Size = new System.Drawing.Size(211, 76);
			pnl_Asking_Info.TabIndex = 73;
			pnl_Asking_Info.Visible = false;
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
			cbo_ac_delivery.Location = new System.Drawing.Point(46, 3);
			cbo_ac_delivery.Name = "cbo_ac_delivery";
			cbo_ac_delivery.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_ac_delivery.Size = new System.Drawing.Size(162, 21);
			cbo_ac_delivery.Sorted = false;
			cbo_ac_delivery.TabIndex = 77;
			cbo_ac_delivery.TabStop = false;
			cbo_ac_delivery.Visible = true;
			// 
			// txt_ac_list_date
			// 
			txt_ac_list_date.AcceptsReturn = true;
			txt_ac_list_date.AllowDrop = true;
			txt_ac_list_date.BackColor = System.Drawing.SystemColors.Window;
			txt_ac_list_date.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_ac_list_date.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_ac_list_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_ac_list_date.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_ac_list_date.Location = new System.Drawing.Point(46, 51);
			txt_ac_list_date.MaxLength = 0;
			txt_ac_list_date.Name = "txt_ac_list_date";
			txt_ac_list_date.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_list_date.Size = new System.Drawing.Size(81, 21);
			txt_ac_list_date.TabIndex = 76;
			txt_ac_list_date.TabStop = false;
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
			txt_ac_asking_price.Location = new System.Drawing.Point(128, 27);
			txt_ac_asking_price.MaxLength = 0;
			txt_ac_asking_price.Name = "txt_ac_asking_price";
			txt_ac_asking_price.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_ac_asking_price.Size = new System.Drawing.Size(79, 21);
			txt_ac_asking_price.TabIndex = 75;
			txt_ac_asking_price.TabStop = false;
			txt_ac_asking_price.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			txt_ac_asking_price.Visible = false;
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
			cbo_ac_asking.Location = new System.Drawing.Point(46, 27);
			cbo_ac_asking.Name = "cbo_ac_asking";
			cbo_ac_asking.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_ac_asking.Size = new System.Drawing.Size(81, 21);
			cbo_ac_asking.Sorted = false;
			cbo_ac_asking.TabIndex = 74;
			cbo_ac_asking.TabStop = false;
			cbo_ac_asking.Visible = true;
			cbo_ac_asking.SelectionChangeCommitted += new System.EventHandler(cbo_ac_asking_SelectionChangeCommitted);
			// 
			// _lbl_gen_6
			// 
			_lbl_gen_6.AllowDrop = true;
			_lbl_gen_6.AutoSize = true;
			_lbl_gen_6.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_6.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_6.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_6.Location = new System.Drawing.Point(3, 5);
			_lbl_gen_6.MinimumSize = new System.Drawing.Size(41, 13);
			_lbl_gen_6.Name = "_lbl_gen_6";
			_lbl_gen_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_6.Size = new System.Drawing.Size(41, 13);
			_lbl_gen_6.TabIndex = 80;
			_lbl_gen_6.Text = "Delivery:";
			// 
			// lbl_ac_list_date
			// 
			lbl_ac_list_date.AllowDrop = true;
			lbl_ac_list_date.BackColor = System.Drawing.Color.Transparent;
			lbl_ac_list_date.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_ac_list_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_ac_list_date.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_ac_list_date.Location = new System.Drawing.Point(13, 47);
			lbl_ac_list_date.MinimumSize = new System.Drawing.Size(31, 24);
			lbl_ac_list_date.Name = "lbl_ac_list_date";
			lbl_ac_list_date.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_ac_list_date.Size = new System.Drawing.Size(31, 24);
			lbl_ac_list_date.TabIndex = 79;
			lbl_ac_list_date.Text = "Date Listed:";
			lbl_ac_list_date.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// _lbl_gen_9
			// 
			_lbl_gen_9.AllowDrop = true;
			_lbl_gen_9.AutoSize = true;
			_lbl_gen_9.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_9.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_9.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_9.Location = new System.Drawing.Point(9, 28);
			_lbl_gen_9.MinimumSize = new System.Drawing.Size(35, 13);
			_lbl_gen_9.Name = "_lbl_gen_9";
			_lbl_gen_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_9.Size = new System.Drawing.Size(35, 13);
			_lbl_gen_9.TabIndex = 78;
			_lbl_gen_9.Text = "Asking:";
			// 
			// txt_exp_comfirm_date
			// 
			txt_exp_comfirm_date.AcceptsReturn = true;
			txt_exp_comfirm_date.AllowDrop = true;
			txt_exp_comfirm_date.BackColor = System.Drawing.SystemColors.Window;
			txt_exp_comfirm_date.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_exp_comfirm_date.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_exp_comfirm_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_exp_comfirm_date.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_exp_comfirm_date.Location = new System.Drawing.Point(121, 27);
			txt_exp_comfirm_date.MaxLength = 0;
			txt_exp_comfirm_date.Name = "txt_exp_comfirm_date";
			txt_exp_comfirm_date.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_exp_comfirm_date.Size = new System.Drawing.Size(88, 19);
			txt_exp_comfirm_date.TabIndex = 5;
			// 
			// chk_Lease_Take_Off_Market
			// 
			chk_Lease_Take_Off_Market.AllowDrop = true;
			chk_Lease_Take_Off_Market.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_Lease_Take_Off_Market.BackColor = System.Drawing.SystemColors.Control;
			chk_Lease_Take_Off_Market.CausesValidation = true;
			chk_Lease_Take_Off_Market.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_Lease_Take_Off_Market.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_Lease_Take_Off_Market.Enabled = true;
			chk_Lease_Take_Off_Market.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_Lease_Take_Off_Market.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_Lease_Take_Off_Market.Location = new System.Drawing.Point(233, 35);
			chk_Lease_Take_Off_Market.Name = "chk_Lease_Take_Off_Market";
			chk_Lease_Take_Off_Market.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_Lease_Take_Off_Market.Size = new System.Drawing.Size(140, 17);
			chk_Lease_Take_Off_Market.TabIndex = 63;
			chk_Lease_Take_Off_Market.TabStop = true;
			chk_Lease_Take_Off_Market.Text = "Take Aircraft Off Market";
			chk_Lease_Take_Off_Market.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_Lease_Take_Off_Market.Visible = true;
			chk_Lease_Take_Off_Market.CheckStateChanged += new System.EventHandler(chk_Lease_Take_Off_Market_CheckStateChanged);
			// 
			// chk_Avail_Prior
			// 
			chk_Avail_Prior.AllowDrop = true;
			chk_Avail_Prior.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_Avail_Prior.BackColor = System.Drawing.SystemColors.Control;
			chk_Avail_Prior.CausesValidation = true;
			chk_Avail_Prior.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_Avail_Prior.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_Avail_Prior.Enabled = false;
			chk_Avail_Prior.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_Avail_Prior.ForeColor = System.Drawing.SystemColors.MenuText;
			chk_Avail_Prior.Location = new System.Drawing.Point(233, 19);
			chk_Avail_Prior.Name = "chk_Avail_Prior";
			chk_Avail_Prior.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_Avail_Prior.Size = new System.Drawing.Size(16, 17);
			chk_Avail_Prior.TabIndex = 62;
			chk_Avail_Prior.TabStop = true;
			chk_Avail_Prior.Text = "Available Prior to Lease";
			chk_Avail_Prior.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_Avail_Prior.Visible = true;
			// 
			// txt_lease_notes
			// 
			txt_lease_notes.AcceptsReturn = true;
			txt_lease_notes.AllowDrop = true;
			txt_lease_notes.BackColor = System.Drawing.SystemColors.Window;
			txt_lease_notes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_lease_notes.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_lease_notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_lease_notes.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_lease_notes.Location = new System.Drawing.Point(34, 78);
			txt_lease_notes.MaxLength = 400;
			txt_lease_notes.Multiline = true;
			txt_lease_notes.Name = "txt_lease_notes";
			txt_lease_notes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_lease_notes.Size = new System.Drawing.Size(554, 21);
			txt_lease_notes.TabIndex = 8;
			txt_lease_notes.TabStop = false;
			// 
			// txt_lease_term
			// 
			txt_lease_term.AcceptsReturn = true;
			txt_lease_term.AllowDrop = true;
			txt_lease_term.BackColor = System.Drawing.SystemColors.Window;
			txt_lease_term.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_lease_term.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_lease_term.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_lease_term.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_lease_term.Location = new System.Drawing.Point(271, 55);
			txt_lease_term.MaxLength = 15;
			txt_lease_term.Name = "txt_lease_term";
			txt_lease_term.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_lease_term.Size = new System.Drawing.Size(106, 19);
			txt_lease_term.TabIndex = 7;
			// 
			// txt_lease_type
			// 
			txt_lease_type.AcceptsReturn = true;
			txt_lease_type.AllowDrop = true;
			txt_lease_type.BackColor = System.Drawing.SystemColors.Window;
			txt_lease_type.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_lease_type.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_lease_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_lease_type.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_lease_type.Location = new System.Drawing.Point(78, 55);
			txt_lease_type.MaxLength = 15;
			txt_lease_type.Name = "txt_lease_type";
			txt_lease_type.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_lease_type.Size = new System.Drawing.Size(108, 19);
			txt_lease_type.TabIndex = 6;
			// 
			// txt_lease_expiration_date
			// 
			txt_lease_expiration_date.AcceptsReturn = true;
			txt_lease_expiration_date.AllowDrop = true;
			txt_lease_expiration_date.BackColor = System.Drawing.SystemColors.Window;
			txt_lease_expiration_date.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			txt_lease_expiration_date.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_lease_expiration_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_lease_expiration_date.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_lease_expiration_date.Location = new System.Drawing.Point(121, 5);
			txt_lease_expiration_date.MaxLength = 0;
			txt_lease_expiration_date.Name = "txt_lease_expiration_date";
			txt_lease_expiration_date.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_lease_expiration_date.Size = new System.Drawing.Size(89, 19);
			txt_lease_expiration_date.TabIndex = 4;
			// 
			// lbl_Avail_Prior
			// 
			lbl_Avail_Prior.AllowDrop = true;
			lbl_Avail_Prior.BackColor = System.Drawing.SystemColors.Control;
			lbl_Avail_Prior.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_Avail_Prior.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_Avail_Prior.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_Avail_Prior.Location = new System.Drawing.Point(252, 20);
			lbl_Avail_Prior.MinimumSize = new System.Drawing.Size(121, 15);
			lbl_Avail_Prior.Name = "lbl_Avail_Prior";
			lbl_Avail_Prior.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_Avail_Prior.Size = new System.Drawing.Size(121, 15);
			lbl_Avail_Prior.TabIndex = 82;
			lbl_Avail_Prior.Text = "Available Prior to Lease";
			// 
			// lbl_exp_comfirm_date
			// 
			lbl_exp_comfirm_date.AllowDrop = true;
			lbl_exp_comfirm_date.AutoSize = true;
			lbl_exp_comfirm_date.BackColor = System.Drawing.SystemColors.Control;
			lbl_exp_comfirm_date.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_exp_comfirm_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_exp_comfirm_date.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_exp_comfirm_date.Location = new System.Drawing.Point(25, 29);
			lbl_exp_comfirm_date.MinimumSize = new System.Drawing.Size(91, 13);
			lbl_exp_comfirm_date.Name = "lbl_exp_comfirm_date";
			lbl_exp_comfirm_date.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_exp_comfirm_date.Size = new System.Drawing.Size(91, 13);
			lbl_exp_comfirm_date.TabIndex = 65;
			lbl_exp_comfirm_date.Text = "Actual Expire Date:";
			// 
			// lbl_lease_notes
			// 
			lbl_lease_notes.AllowDrop = true;
			lbl_lease_notes.BackColor = System.Drawing.SystemColors.Control;
			lbl_lease_notes.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_lease_notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_lease_notes.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_lease_notes.Location = new System.Drawing.Point(4, 80);
			lbl_lease_notes.MinimumSize = new System.Drawing.Size(31, 19);
			lbl_lease_notes.Name = "lbl_lease_notes";
			lbl_lease_notes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_lease_notes.Size = new System.Drawing.Size(31, 19);
			lbl_lease_notes.TabIndex = 61;
			lbl_lease_notes.Text = "Note:";
			// 
			// lbl_lease_term
			// 
			lbl_lease_term.AllowDrop = true;
			lbl_lease_term.BackColor = System.Drawing.SystemColors.Control;
			lbl_lease_term.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_lease_term.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_lease_term.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_lease_term.Location = new System.Drawing.Point(194, 55);
			lbl_lease_term.MinimumSize = new System.Drawing.Size(77, 19);
			lbl_lease_term.Name = "lbl_lease_term";
			lbl_lease_term.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_lease_term.Size = new System.Drawing.Size(77, 19);
			lbl_lease_term.TabIndex = 60;
			lbl_lease_term.Text = "Term of Lease:";
			// 
			// lbl_lease_type
			// 
			lbl_lease_type.AllowDrop = true;
			lbl_lease_type.BackColor = System.Drawing.SystemColors.Control;
			lbl_lease_type.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_lease_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_lease_type.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_lease_type.Location = new System.Drawing.Point(4, 55);
			lbl_lease_type.MinimumSize = new System.Drawing.Size(81, 19);
			lbl_lease_type.Name = "lbl_lease_type";
			lbl_lease_type.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_lease_type.Size = new System.Drawing.Size(81, 19);
			lbl_lease_type.TabIndex = 59;
			lbl_lease_type.Text = "Type of Lease:";
			// 
			// lbl_lease_expiration_date
			// 
			lbl_lease_expiration_date.AllowDrop = true;
			lbl_lease_expiration_date.AutoSize = true;
			lbl_lease_expiration_date.BackColor = System.Drawing.SystemColors.Control;
			lbl_lease_expiration_date.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_lease_expiration_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_lease_expiration_date.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_lease_expiration_date.Location = new System.Drawing.Point(4, 7);
			lbl_lease_expiration_date.MinimumSize = new System.Drawing.Size(112, 13);
			lbl_lease_expiration_date.Name = "lbl_lease_expiration_date";
			lbl_lease_expiration_date.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_lease_expiration_date.Size = new System.Drawing.Size(112, 13);
			lbl_lease_expiration_date.TabIndex = 58;
			lbl_lease_expiration_date.Text = "Scheduled Expire Date:";
			// 
			// pnl_Buyer
			// 
			pnl_Buyer.AllowDrop = true;
			pnl_Buyer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Buyer.Controls.Add(cmd_Identify_Buyer);
			pnl_Buyer.Controls.Add(fra_Awaiting_Documentation);
			pnl_Buyer.Controls.Add(cmd_Fractional_Buyer_Cancel);
			pnl_Buyer.Controls.Add(cmd_Fractional_Buyer_OK);
			pnl_Buyer.Controls.Add(chk_Awaiting_Documentation);
			pnl_Buyer.Controls.Add(lst_Buyer);
			pnl_Buyer.Controls.Add(lbl_Step_4);
			pnl_Buyer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Buyer.Location = new System.Drawing.Point(8, 578);
			pnl_Buyer.Name = "pnl_Buyer";
			pnl_Buyer.Size = new System.Drawing.Size(409, 101);
			pnl_Buyer.TabIndex = 14;
			// 
			// cmd_Identify_Buyer
			// 
			cmd_Identify_Buyer.AllowDrop = true;
			cmd_Identify_Buyer.BackColor = System.Drawing.SystemColors.Control;
			cmd_Identify_Buyer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Identify_Buyer.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Identify_Buyer.Location = new System.Drawing.Point(265, 42);
			cmd_Identify_Buyer.Name = "cmd_Identify_Buyer";
			cmd_Identify_Buyer.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Identify_Buyer.Size = new System.Drawing.Size(129, 27);
			cmd_Identify_Buyer.TabIndex = 100;
			cmd_Identify_Buyer.TabStop = false;
			cmd_Identify_Buyer.Text = "Identify Buyer";
			cmd_Identify_Buyer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Identify_Buyer.UseVisualStyleBackColor = false;
			cmd_Identify_Buyer.Click += new System.EventHandler(cmd_Identify_Buyer_Click);
			cmd_Identify_Buyer.MouseUp += new System.Windows.Forms.MouseEventHandler(cmd_Identify_Buyer_MouseUp);
			// 
			// fra_Awaiting_Documentation
			// 
			fra_Awaiting_Documentation.AllowDrop = true;
			fra_Awaiting_Documentation.BackColor = System.Drawing.SystemColors.Control;
			fra_Awaiting_Documentation.Controls.Add(cbo_Unknown_State);
			fra_Awaiting_Documentation.Controls.Add(cbo_Unknown_Country);
			fra_Awaiting_Documentation.Controls.Add(lbl_Unknown_Country);
			fra_Awaiting_Documentation.Controls.Add(lbl_Unknown_City);
			fra_Awaiting_Documentation.Cursor = UpgradeHelpers.Helpers.CursorHelper.CursorDefault;
			fra_Awaiting_Documentation.Enabled = true;
			fra_Awaiting_Documentation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			fra_Awaiting_Documentation.ForeColor = System.Drawing.SystemColors.ControlText;
			fra_Awaiting_Documentation.Location = new System.Drawing.Point(7, 25);
			fra_Awaiting_Documentation.Name = "fra_Awaiting_Documentation";
			fra_Awaiting_Documentation.RightToLeft = System.Windows.Forms.RightToLeft.No;
			fra_Awaiting_Documentation.Size = new System.Drawing.Size(253, 71);
			fra_Awaiting_Documentation.TabIndex = 29;
			fra_Awaiting_Documentation.Text = "Location of Unknown Company";
			fra_Awaiting_Documentation.Visible = true;
			// 
			// cbo_Unknown_State
			// 
			cbo_Unknown_State.AllowDrop = true;
			cbo_Unknown_State.BackColor = System.Drawing.SystemColors.Window;
			cbo_Unknown_State.CausesValidation = true;
			cbo_Unknown_State.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_Unknown_State.Enabled = true;
			cbo_Unknown_State.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_Unknown_State.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_Unknown_State.IntegralHeight = true;
			cbo_Unknown_State.Location = new System.Drawing.Point(63, 18);
			cbo_Unknown_State.Name = "cbo_Unknown_State";
			cbo_Unknown_State.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_Unknown_State.Size = new System.Drawing.Size(176, 21);
			cbo_Unknown_State.Sorted = false;
			cbo_Unknown_State.TabIndex = 89;
			cbo_Unknown_State.TabStop = true;
			cbo_Unknown_State.Visible = true;
			cbo_Unknown_State.SelectedIndexChanged += new System.EventHandler(cbo_Unknown_State_SelectedIndexChanged);
			// 
			// cbo_Unknown_Country
			// 
			cbo_Unknown_Country.AllowDrop = true;
			cbo_Unknown_Country.BackColor = System.Drawing.SystemColors.Window;
			cbo_Unknown_Country.CausesValidation = true;
			cbo_Unknown_Country.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbo_Unknown_Country.Enabled = true;
			cbo_Unknown_Country.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbo_Unknown_Country.ForeColor = System.Drawing.SystemColors.WindowText;
			cbo_Unknown_Country.IntegralHeight = true;
			cbo_Unknown_Country.Location = new System.Drawing.Point(63, 44);
			cbo_Unknown_Country.Name = "cbo_Unknown_Country";
			cbo_Unknown_Country.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cbo_Unknown_Country.Size = new System.Drawing.Size(176, 21);
			cbo_Unknown_Country.Sorted = false;
			cbo_Unknown_Country.TabIndex = 72;
			cbo_Unknown_Country.TabStop = true;
			cbo_Unknown_Country.Visible = true;
			cbo_Unknown_Country.SelectedIndexChanged += new System.EventHandler(cbo_Unknown_Country_SelectedIndexChanged);
			// 
			// lbl_Unknown_Country
			// 
			lbl_Unknown_Country.AllowDrop = true;
			lbl_Unknown_Country.BackColor = System.Drawing.SystemColors.Control;
			lbl_Unknown_Country.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_Unknown_Country.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_Unknown_Country.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_Unknown_Country.Location = new System.Drawing.Point(6, 48);
			lbl_Unknown_Country.MinimumSize = new System.Drawing.Size(47, 13);
			lbl_Unknown_Country.Name = "lbl_Unknown_Country";
			lbl_Unknown_Country.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_Unknown_Country.Size = new System.Drawing.Size(47, 13);
			lbl_Unknown_Country.TabIndex = 31;
			lbl_Unknown_Country.Text = "Country:";
			// 
			// lbl_Unknown_City
			// 
			lbl_Unknown_City.AllowDrop = true;
			lbl_Unknown_City.BackColor = System.Drawing.SystemColors.Control;
			lbl_Unknown_City.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_Unknown_City.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_Unknown_City.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_Unknown_City.Location = new System.Drawing.Point(6, 24);
			lbl_Unknown_City.MinimumSize = new System.Drawing.Size(61, 13);
			lbl_Unknown_City.Name = "lbl_Unknown_City";
			lbl_Unknown_City.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_Unknown_City.Size = new System.Drawing.Size(61, 13);
			lbl_Unknown_City.TabIndex = 30;
			lbl_Unknown_City.Text = "State:";
			// 
			// cmd_Fractional_Buyer_Cancel
			// 
			cmd_Fractional_Buyer_Cancel.AllowDrop = true;
			cmd_Fractional_Buyer_Cancel.BackColor = System.Drawing.SystemColors.Control;
			cmd_Fractional_Buyer_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Fractional_Buyer_Cancel.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Fractional_Buyer_Cancel.Location = new System.Drawing.Point(334, 76);
			cmd_Fractional_Buyer_Cancel.Name = "cmd_Fractional_Buyer_Cancel";
			cmd_Fractional_Buyer_Cancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Fractional_Buyer_Cancel.Size = new System.Drawing.Size(59, 20);
			cmd_Fractional_Buyer_Cancel.TabIndex = 55;
			cmd_Fractional_Buyer_Cancel.TabStop = false;
			cmd_Fractional_Buyer_Cancel.Text = "Cancel";
			cmd_Fractional_Buyer_Cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Fractional_Buyer_Cancel.UseVisualStyleBackColor = false;
			cmd_Fractional_Buyer_Cancel.Click += new System.EventHandler(cmd_Fractional_Buyer_Cancel_Click);
			cmd_Fractional_Buyer_Cancel.MouseUp += new System.Windows.Forms.MouseEventHandler(cmd_Fractional_Buyer_Cancel_MouseUp);
			// 
			// cmd_Fractional_Buyer_OK
			// 
			cmd_Fractional_Buyer_OK.AllowDrop = true;
			cmd_Fractional_Buyer_OK.BackColor = System.Drawing.SystemColors.Control;
			cmd_Fractional_Buyer_OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Fractional_Buyer_OK.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Fractional_Buyer_OK.Location = new System.Drawing.Point(265, 76);
			cmd_Fractional_Buyer_OK.Name = "cmd_Fractional_Buyer_OK";
			cmd_Fractional_Buyer_OK.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Fractional_Buyer_OK.Size = new System.Drawing.Size(49, 20);
			cmd_Fractional_Buyer_OK.TabIndex = 46;
			cmd_Fractional_Buyer_OK.TabStop = false;
			cmd_Fractional_Buyer_OK.Text = "OK";
			cmd_Fractional_Buyer_OK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Fractional_Buyer_OK.UseVisualStyleBackColor = false;
			cmd_Fractional_Buyer_OK.Click += new System.EventHandler(cmd_Fractional_Buyer_OK_Click);
			cmd_Fractional_Buyer_OK.MouseUp += new System.Windows.Forms.MouseEventHandler(cmd_Fractional_Buyer_OK_MouseUp);
			// 
			// chk_Awaiting_Documentation
			// 
			chk_Awaiting_Documentation.AllowDrop = true;
			chk_Awaiting_Documentation.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_Awaiting_Documentation.BackColor = System.Drawing.SystemColors.Control;
			chk_Awaiting_Documentation.CausesValidation = true;
			chk_Awaiting_Documentation.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_Awaiting_Documentation.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_Awaiting_Documentation.Enabled = true;
			chk_Awaiting_Documentation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_Awaiting_Documentation.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_Awaiting_Documentation.Location = new System.Drawing.Point(11, 6);
			chk_Awaiting_Documentation.Name = "chk_Awaiting_Documentation";
			chk_Awaiting_Documentation.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_Awaiting_Documentation.Size = new System.Drawing.Size(163, 15);
			chk_Awaiting_Documentation.TabIndex = 28;
			chk_Awaiting_Documentation.TabStop = false;
			chk_Awaiting_Documentation.Text = "Awaiting Documentation";
			chk_Awaiting_Documentation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_Awaiting_Documentation.Visible = true;
			chk_Awaiting_Documentation.CheckStateChanged += new System.EventHandler(chk_Awaiting_Documentation_CheckStateChanged);
			// 
			// lst_Buyer
			// 
			lst_Buyer.AllowDrop = true;
			lst_Buyer.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			lst_Buyer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lst_Buyer.CausesValidation = true;
			lst_Buyer.Enabled = true;
			lst_Buyer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lst_Buyer.ForeColor = System.Drawing.SystemColors.WindowText;
			lst_Buyer.IntegralHeight = true;
			lst_Buyer.Location = new System.Drawing.Point(8, 28);
			lst_Buyer.MultiColumn = false;
			lst_Buyer.Name = "lst_Buyer";
			lst_Buyer.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lst_Buyer.Size = new System.Drawing.Size(241, 70);
			lst_Buyer.Sorted = false;
			lst_Buyer.TabIndex = 16;
			lst_Buyer.TabStop = true;
			lst_Buyer.Visible = true;
			// 
			// lbl_Step_4
			// 
			lbl_Step_4.AllowDrop = true;
			lbl_Step_4.BackColor = System.Drawing.Color.Transparent;
			lbl_Step_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_Step_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_Step_4.ForeColor = System.Drawing.Color.Maroon;
			lbl_Step_4.Location = new System.Drawing.Point(265, 5);
			lbl_Step_4.MinimumSize = new System.Drawing.Size(129, 35);
			lbl_Step_4.Name = "lbl_Step_4";
			lbl_Step_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_Step_4.Size = new System.Drawing.Size(129, 35);
			lbl_Step_4.TabIndex = 101;
			lbl_Step_4.Text = "STEP 4: Buyer ";
			lbl_Step_4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// pnl_Indicate_Seller_Buyer
			// 
			pnl_Indicate_Seller_Buyer.AllowDrop = true;
			pnl_Indicate_Seller_Buyer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Indicate_Seller_Buyer.Controls.Add(cmd_remove_grid_row);
			pnl_Indicate_Seller_Buyer.Controls.Add(cmd_Fractional_Cancel);
			pnl_Indicate_Seller_Buyer.Controls.Add(cmd_Fractional_OK);
			pnl_Indicate_Seller_Buyer.Controls.Add(opt_Fractional_Buyer);
			pnl_Indicate_Seller_Buyer.Controls.Add(opt_Fractional_Seller);
			pnl_Indicate_Seller_Buyer.Controls.Add(txt_Percentage);
			pnl_Indicate_Seller_Buyer.Controls.Add(lbl_To_Buy_Sell);
			pnl_Indicate_Seller_Buyer.Controls.Add(lbl_Percentage);
			pnl_Indicate_Seller_Buyer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Indicate_Seller_Buyer.Location = new System.Drawing.Point(9, 578);
			pnl_Indicate_Seller_Buyer.Name = "pnl_Indicate_Seller_Buyer";
			pnl_Indicate_Seller_Buyer.Size = new System.Drawing.Size(208, 101);
			pnl_Indicate_Seller_Buyer.TabIndex = 47;
			// 
			// cmd_remove_grid_row
			// 
			cmd_remove_grid_row.AllowDrop = true;
			cmd_remove_grid_row.BackColor = System.Drawing.SystemColors.Control;
			cmd_remove_grid_row.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_remove_grid_row.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_remove_grid_row.Location = new System.Drawing.Point(141, 63);
			cmd_remove_grid_row.Name = "cmd_remove_grid_row";
			cmd_remove_grid_row.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_remove_grid_row.Size = new System.Drawing.Size(48, 30);
			cmd_remove_grid_row.TabIndex = 64;
			cmd_remove_grid_row.TabStop = false;
			cmd_remove_grid_row.Text = "Remove Row";
			cmd_remove_grid_row.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_remove_grid_row.UseVisualStyleBackColor = false;
			cmd_remove_grid_row.Click += new System.EventHandler(cmd_remove_grid_row_Click);
			cmd_remove_grid_row.MouseUp += new System.Windows.Forms.MouseEventHandler(cmd_remove_grid_row_MouseUp);
			// 
			// cmd_Fractional_Cancel
			// 
			cmd_Fractional_Cancel.AllowDrop = true;
			cmd_Fractional_Cancel.BackColor = System.Drawing.SystemColors.Control;
			cmd_Fractional_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Fractional_Cancel.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Fractional_Cancel.Location = new System.Drawing.Point(81, 63);
			cmd_Fractional_Cancel.Name = "cmd_Fractional_Cancel";
			cmd_Fractional_Cancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Fractional_Cancel.Size = new System.Drawing.Size(48, 30);
			cmd_Fractional_Cancel.TabIndex = 52;
			cmd_Fractional_Cancel.TabStop = false;
			cmd_Fractional_Cancel.Text = "Cancel";
			cmd_Fractional_Cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Fractional_Cancel.UseVisualStyleBackColor = false;
			cmd_Fractional_Cancel.Click += new System.EventHandler(cmd_Fractional_Cancel_Click);
			cmd_Fractional_Cancel.MouseUp += new System.Windows.Forms.MouseEventHandler(cmd_Fractional_Cancel_MouseUp);
			// 
			// cmd_Fractional_OK
			// 
			cmd_Fractional_OK.AllowDrop = true;
			cmd_Fractional_OK.BackColor = System.Drawing.SystemColors.Control;
			cmd_Fractional_OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Fractional_OK.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Fractional_OK.Location = new System.Drawing.Point(22, 63);
			cmd_Fractional_OK.Name = "cmd_Fractional_OK";
			cmd_Fractional_OK.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Fractional_OK.Size = new System.Drawing.Size(48, 30);
			cmd_Fractional_OK.TabIndex = 51;
			cmd_Fractional_OK.TabStop = false;
			cmd_Fractional_OK.Text = "OK";
			cmd_Fractional_OK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Fractional_OK.UseVisualStyleBackColor = false;
			cmd_Fractional_OK.Click += new System.EventHandler(cmd_Fractional_OK_Click);
			cmd_Fractional_OK.MouseUp += new System.Windows.Forms.MouseEventHandler(cmd_Fractional_OK_MouseUp);
			// 
			// opt_Fractional_Buyer
			// 
			opt_Fractional_Buyer.AllowDrop = true;
			opt_Fractional_Buyer.BackColor = System.Drawing.SystemColors.Control;
			opt_Fractional_Buyer.CausesValidation = true;
			opt_Fractional_Buyer.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opt_Fractional_Buyer.Checked = false;
			opt_Fractional_Buyer.Enabled = true;
			opt_Fractional_Buyer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			opt_Fractional_Buyer.ForeColor = System.Drawing.SystemColors.ControlText;
			opt_Fractional_Buyer.Location = new System.Drawing.Point(107, 20);
			opt_Fractional_Buyer.Name = "opt_Fractional_Buyer";
			opt_Fractional_Buyer.RightToLeft = System.Windows.Forms.RightToLeft.No;
			opt_Fractional_Buyer.Size = new System.Drawing.Size(77, 17);
			opt_Fractional_Buyer.TabIndex = 50;
			opt_Fractional_Buyer.TabStop = false;
			opt_Fractional_Buyer.Text = "Buyer";
			opt_Fractional_Buyer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opt_Fractional_Buyer.Visible = true;
			opt_Fractional_Buyer.CheckedChanged += new System.EventHandler(opt_Fractional_Buyer_CheckedChanged);
			// 
			// opt_Fractional_Seller
			// 
			opt_Fractional_Seller.AllowDrop = true;
			opt_Fractional_Seller.BackColor = System.Drawing.SystemColors.Control;
			opt_Fractional_Seller.CausesValidation = true;
			opt_Fractional_Seller.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opt_Fractional_Seller.Checked = false;
			opt_Fractional_Seller.Enabled = true;
			opt_Fractional_Seller.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			opt_Fractional_Seller.ForeColor = System.Drawing.SystemColors.ControlText;
			opt_Fractional_Seller.Location = new System.Drawing.Point(31, 20);
			opt_Fractional_Seller.Name = "opt_Fractional_Seller";
			opt_Fractional_Seller.RightToLeft = System.Windows.Forms.RightToLeft.No;
			opt_Fractional_Seller.Size = new System.Drawing.Size(71, 17);
			opt_Fractional_Seller.TabIndex = 49;
			opt_Fractional_Seller.TabStop = false;
			opt_Fractional_Seller.Text = "Seller";
			opt_Fractional_Seller.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			opt_Fractional_Seller.Visible = true;
			opt_Fractional_Seller.CheckedChanged += new System.EventHandler(opt_Fractional_Seller_CheckedChanged);
			// 
			// txt_Percentage
			// 
			txt_Percentage.AcceptsReturn = true;
			txt_Percentage.AllowDrop = true;
			txt_Percentage.BackColor = System.Drawing.SystemColors.Window;
			txt_Percentage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txt_Percentage.Cursor = System.Windows.Forms.Cursors.IBeam;
			txt_Percentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txt_Percentage.ForeColor = System.Drawing.SystemColors.WindowText;
			txt_Percentage.Location = new System.Drawing.Point(59, 40);
			txt_Percentage.MaxLength = 6;
			txt_Percentage.Name = "txt_Percentage";
			txt_Percentage.RightToLeft = System.Windows.Forms.RightToLeft.No;
			txt_Percentage.Size = new System.Drawing.Size(56, 19);
			txt_Percentage.TabIndex = 48;
			txt_Percentage.TabStop = false;
			txt_Percentage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lbl_To_Buy_Sell
			// 
			lbl_To_Buy_Sell.AllowDrop = true;
			lbl_To_Buy_Sell.BackColor = System.Drawing.SystemColors.Control;
			lbl_To_Buy_Sell.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_To_Buy_Sell.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_To_Buy_Sell.ForeColor = System.Drawing.SystemColors.WindowText;
			lbl_To_Buy_Sell.Location = new System.Drawing.Point(120, 43);
			lbl_To_Buy_Sell.MinimumSize = new System.Drawing.Size(63, 13);
			lbl_To_Buy_Sell.Name = "lbl_To_Buy_Sell";
			lbl_To_Buy_Sell.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_To_Buy_Sell.Size = new System.Drawing.Size(63, 13);
			lbl_To_Buy_Sell.TabIndex = 54;
			lbl_To_Buy_Sell.Text = "to Sell";
			// 
			// lbl_Percentage
			// 
			lbl_Percentage.AllowDrop = true;
			lbl_Percentage.BackColor = System.Drawing.SystemColors.Control;
			lbl_Percentage.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_Percentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_Percentage.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_Percentage.Location = new System.Drawing.Point(40, 43);
			lbl_Percentage.MinimumSize = new System.Drawing.Size(21, 13);
			lbl_Percentage.Name = "lbl_Percentage";
			lbl_Percentage.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_Percentage.Size = new System.Drawing.Size(21, 13);
			lbl_Percentage.TabIndex = 53;
			lbl_Percentage.Text = "%:";
			// 
			// pnl_Fractional_Seller
			// 
			pnl_Fractional_Seller.AllowDrop = true;
			pnl_Fractional_Seller.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Fractional_Seller.Controls.Add(chkFractionalAwaitDocs);
			pnl_Fractional_Seller.Controls.Add(cmd_Ident_Hist_Frac_Seller);
			pnl_Fractional_Seller.Controls.Add(cmdDoneWithGrid);
			pnl_Fractional_Seller.Controls.Add(cmd_await_doc_Seller);
			pnl_Fractional_Seller.Controls.Add(cmd_await_doc);
			pnl_Fractional_Seller.Controls.Add(chk_Fractional_Correction);
			pnl_Fractional_Seller.Controls.Add(cmd_Identify_Fractional_Buyer);
			pnl_Fractional_Seller.Controls.Add(grd_Fractional);
			pnl_Fractional_Seller.Controls.Add(lbl_Aircrft_Ownership_Worksheet);
			pnl_Fractional_Seller.Controls.Add(lbl_Fraction_Sale);
			pnl_Fractional_Seller.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Fractional_Seller.Location = new System.Drawing.Point(217, 388);
			pnl_Fractional_Seller.Name = "pnl_Fractional_Seller";
			pnl_Fractional_Seller.Size = new System.Drawing.Size(792, 190);
			pnl_Fractional_Seller.TabIndex = 35;
			// 
			// chkFractionalAwaitDocs
			// 
			chkFractionalAwaitDocs.AllowDrop = true;
			chkFractionalAwaitDocs.Appearance = System.Windows.Forms.Appearance.Normal;
			chkFractionalAwaitDocs.BackColor = System.Drawing.SystemColors.Control;
			chkFractionalAwaitDocs.CausesValidation = true;
			chkFractionalAwaitDocs.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkFractionalAwaitDocs.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chkFractionalAwaitDocs.Enabled = true;
			chkFractionalAwaitDocs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chkFractionalAwaitDocs.ForeColor = System.Drawing.SystemColors.ControlText;
			chkFractionalAwaitDocs.Location = new System.Drawing.Point(208, 152);
			chkFractionalAwaitDocs.Name = "chkFractionalAwaitDocs";
			chkFractionalAwaitDocs.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chkFractionalAwaitDocs.Size = new System.Drawing.Size(258, 30);
			chkFractionalAwaitDocs.TabIndex = 90;
			chkFractionalAwaitDocs.TabStop = true;
			chkFractionalAwaitDocs.Text = "Buyer Unknown/Awaiting Documentation";
			chkFractionalAwaitDocs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chkFractionalAwaitDocs.Visible = true;
			chkFractionalAwaitDocs.CheckStateChanged += new System.EventHandler(chkFractionalAwaitDocs_CheckStateChanged);
			// 
			// cmd_Ident_Hist_Frac_Seller
			// 
			cmd_Ident_Hist_Frac_Seller.AllowDrop = true;
			cmd_Ident_Hist_Frac_Seller.BackColor = System.Drawing.SystemColors.Control;
			cmd_Ident_Hist_Frac_Seller.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Ident_Hist_Frac_Seller.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Ident_Hist_Frac_Seller.Location = new System.Drawing.Point(633, 151);
			cmd_Ident_Hist_Frac_Seller.Name = "cmd_Ident_Hist_Frac_Seller";
			cmd_Ident_Hist_Frac_Seller.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Ident_Hist_Frac_Seller.Size = new System.Drawing.Size(52, 30);
			cmd_Ident_Hist_Frac_Seller.TabIndex = 93;
			cmd_Ident_Hist_Frac_Seller.Text = "Identify Seller";
			cmd_Ident_Hist_Frac_Seller.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Ident_Hist_Frac_Seller.UseVisualStyleBackColor = false;
			cmd_Ident_Hist_Frac_Seller.Visible = false;
			cmd_Ident_Hist_Frac_Seller.Click += new System.EventHandler(cmd_Ident_Hist_Frac_Seller_Click);
			cmd_Ident_Hist_Frac_Seller.MouseUp += new System.Windows.Forms.MouseEventHandler(cmd_Ident_Hist_Frac_Seller_MouseUp);
			// 
			// cmdDoneWithGrid
			// 
			cmdDoneWithGrid.AllowDrop = true;
			cmdDoneWithGrid.BackColor = System.Drawing.SystemColors.Control;
			cmdDoneWithGrid.Enabled = false;
			cmdDoneWithGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmdDoneWithGrid.ForeColor = System.Drawing.SystemColors.ControlText;
			cmdDoneWithGrid.Location = new System.Drawing.Point(474, 151);
			cmdDoneWithGrid.Name = "cmdDoneWithGrid";
			cmdDoneWithGrid.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmdDoneWithGrid.Size = new System.Drawing.Size(140, 30);
			cmdDoneWithGrid.TabIndex = 92;
			cmdDoneWithGrid.TabStop = false;
			cmdDoneWithGrid.Text = "Done With Grid";
			cmdDoneWithGrid.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmdDoneWithGrid.Visible = false;
			cmdDoneWithGrid.Click += new System.EventHandler(cmdDoneWithGrid_Click);
			cmdDoneWithGrid.MouseUp += new System.Windows.Forms.MouseEventHandler(cmdDoneWithGrid_MouseUp);
			// 
			// cmd_await_doc_Seller
			// 
			cmd_await_doc_Seller.AllowDrop = true;
			cmd_await_doc_Seller.BackColor = System.Drawing.SystemColors.Control;
			cmd_await_doc_Seller.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_await_doc_Seller.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_await_doc_Seller.Location = new System.Drawing.Point(434, 151);
			cmd_await_doc_Seller.Name = "cmd_await_doc_Seller";
			cmd_await_doc_Seller.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_await_doc_Seller.Size = new System.Drawing.Size(220, 30);
			cmd_await_doc_Seller.TabIndex = 83;
			cmd_await_doc_Seller.TabStop = false;
			cmd_await_doc_Seller.Text = "Seller Unknown/Awaiting Documentation";
			cmd_await_doc_Seller.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_await_doc_Seller.UseVisualStyleBackColor = false;
			cmd_await_doc_Seller.Visible = false;
			cmd_await_doc_Seller.Click += new System.EventHandler(cmd_await_doc_Seller_Click);
			cmd_await_doc_Seller.MouseUp += new System.Windows.Forms.MouseEventHandler(cmd_await_doc_Seller_MouseUp);
			// 
			// cmd_await_doc
			// 
			cmd_await_doc.AllowDrop = true;
			cmd_await_doc.BackColor = System.Drawing.SystemColors.Control;
			cmd_await_doc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_await_doc.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_await_doc.Location = new System.Drawing.Point(207, 151);
			cmd_await_doc.Name = "cmd_await_doc";
			cmd_await_doc.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_await_doc.Size = new System.Drawing.Size(220, 30);
			cmd_await_doc.TabIndex = 81;
			cmd_await_doc.TabStop = false;
			cmd_await_doc.Text = "Lessee Unknown/Awaiting Documentation";
			cmd_await_doc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_await_doc.UseVisualStyleBackColor = false;
			cmd_await_doc.Visible = false;
			cmd_await_doc.Click += new System.EventHandler(cmd_await_doc_Click);
			cmd_await_doc.MouseUp += new System.Windows.Forms.MouseEventHandler(cmd_await_doc_MouseUp);
			// 
			// chk_Fractional_Correction
			// 
			chk_Fractional_Correction.AllowDrop = true;
			chk_Fractional_Correction.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_Fractional_Correction.BackColor = System.Drawing.SystemColors.Control;
			chk_Fractional_Correction.CausesValidation = true;
			chk_Fractional_Correction.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_Fractional_Correction.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_Fractional_Correction.Enabled = true;
			chk_Fractional_Correction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_Fractional_Correction.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_Fractional_Correction.Location = new System.Drawing.Point(689, 151);
			chk_Fractional_Correction.Name = "chk_Fractional_Correction";
			chk_Fractional_Correction.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_Fractional_Correction.Size = new System.Drawing.Size(92, 30);
			chk_Fractional_Correction.TabIndex = 71;
			chk_Fractional_Correction.TabStop = false;
			chk_Fractional_Correction.Text = "Correction Transaction";
			chk_Fractional_Correction.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_Fractional_Correction.Visible = true;
			chk_Fractional_Correction.CheckStateChanged += new System.EventHandler(chk_Fractional_Correction_CheckStateChanged);
			// 
			// cmd_Identify_Fractional_Buyer
			// 
			cmd_Identify_Fractional_Buyer.AllowDrop = true;
			cmd_Identify_Fractional_Buyer.BackColor = System.Drawing.SystemColors.Control;
			cmd_Identify_Fractional_Buyer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cmd_Identify_Fractional_Buyer.ForeColor = System.Drawing.SystemColors.ControlText;
			cmd_Identify_Fractional_Buyer.Location = new System.Drawing.Point(10, 151);
			cmd_Identify_Fractional_Buyer.Name = "cmd_Identify_Fractional_Buyer";
			cmd_Identify_Fractional_Buyer.RightToLeft = System.Windows.Forms.RightToLeft.No;
			cmd_Identify_Fractional_Buyer.Size = new System.Drawing.Size(173, 30);
			cmd_Identify_Fractional_Buyer.TabIndex = 39;
			cmd_Identify_Fractional_Buyer.TabStop = false;
			cmd_Identify_Fractional_Buyer.Text = "Lessee from Available Companies";
			cmd_Identify_Fractional_Buyer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			cmd_Identify_Fractional_Buyer.UseVisualStyleBackColor = false;
			cmd_Identify_Fractional_Buyer.Click += new System.EventHandler(cmd_Identify_Fractional_Buyer_Click);
			cmd_Identify_Fractional_Buyer.MouseUp += new System.Windows.Forms.MouseEventHandler(cmd_Identify_Fractional_Buyer_MouseUp);
			// 
			// grd_Fractional
			// 
			grd_Fractional.AllowDrop = true;
			grd_Fractional.AllowUserToAddRows = false;
			grd_Fractional.AllowUserToDeleteRows = false;
			grd_Fractional.AllowUserToResizeColumns = false;
			grd_Fractional.AllowUserToResizeColumns = grd_Fractional.ColumnHeadersVisible;
			grd_Fractional.AllowUserToResizeRows = false;
			grd_Fractional.AllowUserToResizeRows = false;
			grd_Fractional.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			grd_Fractional.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			grd_Fractional.ColumnsCount = 2;
			grd_Fractional.FixedColumns = 1;
			grd_Fractional.FixedRows = 1;
			grd_Fractional.Font = new System.Drawing.Font("Arial", 7.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			grd_Fractional.Location = new System.Drawing.Point(9, 28);
			grd_Fractional.Name = "grd_Fractional";
			grd_Fractional.ReadOnly = true;
			grd_Fractional.RowsCount = 2;
			grd_Fractional.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			grd_Fractional.ShowCellToolTips = false;
			grd_Fractional.Size = new System.Drawing.Size(777, 118);
			grd_Fractional.StandardTab = true;
			grd_Fractional.TabIndex = 36;
			grd_Fractional.TabStop = false;
			grd_Fractional.Click += new System.EventHandler(grd_Fractional_Click);
			// 
			// lbl_Aircrft_Ownership_Worksheet
			// 
			lbl_Aircrft_Ownership_Worksheet.AllowDrop = true;
			lbl_Aircrft_Ownership_Worksheet.AutoSize = true;
			lbl_Aircrft_Ownership_Worksheet.BackColor = System.Drawing.SystemColors.Control;
			lbl_Aircrft_Ownership_Worksheet.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_Aircrft_Ownership_Worksheet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_Aircrft_Ownership_Worksheet.ForeColor = System.Drawing.SystemColors.ControlText;
			lbl_Aircrft_Ownership_Worksheet.Location = new System.Drawing.Point(284, 8);
			lbl_Aircrft_Ownership_Worksheet.MinimumSize = new System.Drawing.Size(204, 16);
			lbl_Aircrft_Ownership_Worksheet.Name = "lbl_Aircrft_Ownership_Worksheet";
			lbl_Aircrft_Ownership_Worksheet.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_Aircrft_Ownership_Worksheet.Size = new System.Drawing.Size(204, 16);
			lbl_Aircrft_Ownership_Worksheet.TabIndex = 38;
			lbl_Aircrft_Ownership_Worksheet.Text = "Aircraft Ownership Worksheet";
			lbl_Aircrft_Ownership_Worksheet.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lbl_Fraction_Sale
			// 
			lbl_Fraction_Sale.AllowDrop = true;
			lbl_Fraction_Sale.AutoSize = true;
			lbl_Fraction_Sale.BackColor = System.Drawing.Color.Transparent;
			lbl_Fraction_Sale.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lbl_Fraction_Sale.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_Fraction_Sale.ForeColor = System.Drawing.Color.Maroon;
			lbl_Fraction_Sale.Location = new System.Drawing.Point(584, 8);
			lbl_Fraction_Sale.MinimumSize = new System.Drawing.Size(159, 16);
			lbl_Fraction_Sale.Name = "lbl_Fraction_Sale";
			lbl_Fraction_Sale.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_Fraction_Sale.Size = new System.Drawing.Size(159, 16);
			lbl_Fraction_Sale.TabIndex = 37;
			lbl_Fraction_Sale.Text = "Step 3: Fractional Sale";
			lbl_Fraction_Sale.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// pnl_Please_Wait
			// 
			pnl_Please_Wait.AllowDrop = true;
			pnl_Please_Wait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Please_Wait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Please_Wait.Controls.Add(Label1);
			pnl_Please_Wait.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Please_Wait.Location = new System.Drawing.Point(261, 298);
			pnl_Please_Wait.Name = "pnl_Please_Wait";
			pnl_Please_Wait.Size = new System.Drawing.Size(521, 118);
			pnl_Please_Wait.TabIndex = 84;
			pnl_Please_Wait.Visible = false;
			// 
			// Label1
			// 
			Label1.AllowDrop = true;
			Label1.BackColor = System.Drawing.Color.Transparent;
			Label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Label1.ForeColor = System.Drawing.Color.Maroon;
			Label1.Location = new System.Drawing.Point(184, 64);
			Label1.MinimumSize = new System.Drawing.Size(153, 27);
			Label1.Name = "Label1";
			Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Label1.Size = new System.Drawing.Size(153, 27);
			Label1.TabIndex = 85;
			Label1.Text = "PLEASE WAIT!";
			Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// pnl_Update_Aircraft_row
			// 
			pnl_Update_Aircraft_row.AllowDrop = true;
			pnl_Update_Aircraft_row.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnl_Update_Aircraft_row.Controls.Add(chk_Take_Off_Market);
			pnl_Update_Aircraft_row.Controls.Add(chk_was_available);
			pnl_Update_Aircraft_row.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			pnl_Update_Aircraft_row.Location = new System.Drawing.Point(788, 429);
			pnl_Update_Aircraft_row.Name = "pnl_Update_Aircraft_row";
			pnl_Update_Aircraft_row.Size = new System.Drawing.Size(208, 93);
			pnl_Update_Aircraft_row.TabIndex = 68;
			pnl_Update_Aircraft_row.Visible = false;
			// 
			// chk_Take_Off_Market
			// 
			chk_Take_Off_Market.AllowDrop = true;
			chk_Take_Off_Market.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_Take_Off_Market.BackColor = System.Drawing.SystemColors.Control;
			chk_Take_Off_Market.CausesValidation = true;
			chk_Take_Off_Market.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_Take_Off_Market.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_Take_Off_Market.Enabled = true;
			chk_Take_Off_Market.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_Take_Off_Market.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_Take_Off_Market.Location = new System.Drawing.Point(24, 64);
			chk_Take_Off_Market.Name = "chk_Take_Off_Market";
			chk_Take_Off_Market.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_Take_Off_Market.Size = new System.Drawing.Size(173, 17);
			chk_Take_Off_Market.TabIndex = 86;
			chk_Take_Off_Market.TabStop = false;
			chk_Take_Off_Market.Text = "Take Aircraft Off Market";
			chk_Take_Off_Market.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_Take_Off_Market.Visible = true;
			// 
			// chk_was_available
			// 
			chk_was_available.AllowDrop = true;
			chk_was_available.Appearance = System.Windows.Forms.Appearance.Normal;
			chk_was_available.BackColor = System.Drawing.SystemColors.Control;
			chk_was_available.CausesValidation = true;
			chk_was_available.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_was_available.CheckState = System.Windows.Forms.CheckState.Unchecked;
			chk_was_available.Enabled = false;
			chk_was_available.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			chk_was_available.ForeColor = System.Drawing.SystemColors.ControlText;
			chk_was_available.Location = new System.Drawing.Point(24, 40);
			chk_was_available.Name = "chk_was_available";
			chk_was_available.RightToLeft = System.Windows.Forms.RightToLeft.No;
			chk_was_available.Size = new System.Drawing.Size(173, 17);
			chk_was_available.TabIndex = 69;
			chk_was_available.TabStop = false;
			chk_was_available.Text = "Available Prior to Transaction";
			chk_was_available.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			chk_was_available.Visible = true;
			// 
			// _lbl_gen_0
			// 
			_lbl_gen_0.AllowDrop = true;
			_lbl_gen_0.BackColor = System.Drawing.Color.Transparent;
			_lbl_gen_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lbl_gen_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lbl_gen_0.ForeColor = System.Drawing.SystemColors.ControlText;
			_lbl_gen_0.Location = new System.Drawing.Point(4, 24);
			_lbl_gen_0.MinimumSize = new System.Drawing.Size(183, 17);
			_lbl_gen_0.Name = "_lbl_gen_0";
			_lbl_gen_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbl_gen_0.Size = new System.Drawing.Size(183, 17);
			_lbl_gen_0.TabIndex = 32;
			_lbl_gen_0.Text = "Transaction type";
			_lbl_gen_0.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lbl_Message
			// 
			lbl_Message.AllowDrop = true;
			lbl_Message.BackColor = System.Drawing.Color.Transparent;
			lbl_Message.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lbl_Message.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lbl_Message.ForeColor = System.Drawing.Color.Maroon;
			lbl_Message.Location = new System.Drawing.Point(419, 58);
			lbl_Message.MinimumSize = new System.Drawing.Size(588, 27);
			lbl_Message.Name = "lbl_Message";
			lbl_Message.RightToLeft = System.Windows.Forms.RightToLeft.No;
			lbl_Message.Size = new System.Drawing.Size(588, 27);
			lbl_Message.TabIndex = 10;
			lbl_Message.Text = "Repossession/Foreclosure Transaction";
			lbl_Message.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// frm_Aircraft_Change
			// 
			AcceptButton = cmd_Commit_Transaction;
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(7, 15);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			BackColor = System.Drawing.SystemColors.Control;
			CancelButton = cmd_Cancel;
			ClientSize = new System.Drawing.Size(1010, 708);
			ControlBox = false;
			Controls.Add(pnl_Registered_As);
			Controls.Add(pnl_Verify);
			Controls.Add(pnl_Date);
			Controls.Add(tbr_ToolBar);
			Controls.Add(pnl_Current_Status);
			Controls.Add(pnl_Sale_Type);
			Controls.Add(pnl_Seller);
			Controls.Add(pnl_Commit_Transaction);
			Controls.Add(pnl_Lease_Information);
			Controls.Add(pnl_Buyer);
			Controls.Add(pnl_Indicate_Seller_Buyer);
			Controls.Add(pnl_Fractional_Seller);
			Controls.Add(pnl_Please_Wait);
			Controls.Add(pnl_Update_Aircraft_row);
			Controls.Add(_lbl_gen_0);
			Controls.Add(lbl_Message);
			Controls.Add(MainMenu1);
			Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			Location = new System.Drawing.Point(246, 178);
			MaximizeBox = true;
			MinimizeBox = false;
			Name = "frm_Aircraft_Change";
			RightToLeft = System.Windows.Forms.RightToLeft.No;
			StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			Text = "Aircraft Status Change";
			WindowState = System.Windows.Forms.FormWindowState.Maximized;
			commandButtonHelper1.SetStyle(cmd_Identify_Registered_As, 0);
			commandButtonHelper1.SetStyle(cmdShowFractionalGrid, 0);
			commandButtonHelper1.SetStyle(cmd_Identify_Seller, 0);
			commandButtonHelper1.SetStyle(cmd_Commit_Transaction, 0);
			commandButtonHelper1.SetStyle(cmd_Cancel, 0);
			commandButtonHelper1.SetStyle(cmd_Identify_Buyer, 0);
			commandButtonHelper1.SetStyle(cmd_Fractional_Buyer_Cancel, 0);
			commandButtonHelper1.SetStyle(cmd_Fractional_Buyer_OK, 0);
			commandButtonHelper1.SetStyle(cmd_remove_grid_row, 0);
			commandButtonHelper1.SetStyle(cmd_Fractional_Cancel, 0);
			commandButtonHelper1.SetStyle(cmd_Fractional_OK, 0);
			commandButtonHelper1.SetStyle(cmd_Ident_Hist_Frac_Seller, 0);
			commandButtonHelper1.SetStyle(cmdDoneWithGrid, 0);
			commandButtonHelper1.SetStyle(cmd_await_doc_Seller, 0);
			commandButtonHelper1.SetStyle(cmd_await_doc, 0);
			commandButtonHelper1.SetStyle(cmd_Identify_Fractional_Buyer, 0);
			listBoxHelper1.SetSelectionMode(lst_Registered_As, System.Windows.Forms.SelectionMode.One);
			listBoxHelper1.SetSelectionMode(lst_Aircraft_Info, System.Windows.Forms.SelectionMode.One);
			listBoxHelper1.SetSelectionMode(lst_Seller, System.Windows.Forms.SelectionMode.One);
			listBoxHelper1.SetSelectionMode(lst_Buyer, System.Windows.Forms.SelectionMode.One);
			optionButtonHelper1.SetStyle(opt_Historical, 0);
			optionButtonHelper1.SetStyle(opt_Current, 0);
			optionButtonHelper1.SetStyle(opt_Fractional_Buyer, 0);
			optionButtonHelper1.SetStyle(opt_Fractional_Seller, 0);
			Activated += new System.EventHandler(Form_Activated);
			Closed += new System.EventHandler(Form_Closed);
			((System.ComponentModel.ISupportInitialize) grd_Fractional).EndInit();
			pnl_Registered_As.ResumeLayout(false);
			pnl_Registered_As.PerformLayout();
			pnl_Verify.ResumeLayout(false);
			pnl_Verify.PerformLayout();
			pnl_Date.ResumeLayout(false);
			pnl_Date.PerformLayout();
			tbr_ToolBar.ResumeLayout(false);
			tbr_ToolBar.PerformLayout();
			pnl_Current_Status.ResumeLayout(false);
			pnl_Current_Status.PerformLayout();
			pnl_Sale_Type.ResumeLayout(false);
			pnl_Sale_Type.PerformLayout();
			pnl_Seller.ResumeLayout(false);
			pnl_Seller.PerformLayout();
			pnl_Commit_Transaction.ResumeLayout(false);
			pnl_Commit_Transaction.PerformLayout();
			pnl_Lease_Information.ResumeLayout(false);
			pnl_Lease_Information.PerformLayout();
			pnl_Asking_Info.ResumeLayout(false);
			pnl_Asking_Info.PerformLayout();
			pnl_Buyer.ResumeLayout(false);
			pnl_Buyer.PerformLayout();
			fra_Awaiting_Documentation.ResumeLayout(false);
			fra_Awaiting_Documentation.PerformLayout();
			pnl_Indicate_Seller_Buyer.ResumeLayout(false);
			pnl_Indicate_Seller_Buyer.PerformLayout();
			pnl_Fractional_Seller.ResumeLayout(false);
			pnl_Fractional_Seller.PerformLayout();
			pnl_Please_Wait.ResumeLayout(false);
			pnl_Please_Wait.PerformLayout();
			pnl_Update_Aircraft_row.ResumeLayout(false);
			pnl_Update_Aircraft_row.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
		void ReLoadForm(bool addEvents)
		{
			Initializelbl_gen();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			MdiParent = JETNET_Homebase.mdi_ResearchAssistant.DefInstance;
			JETNET_Homebase.mdi_ResearchAssistant.DefInstance.Show();
		}
		void Initializelbl_gen()
		{
			lbl_gen = new System.Windows.Forms.Label[10];
			lbl_gen[6] = _lbl_gen_6;
			lbl_gen[9] = _lbl_gen_9;
			lbl_gen[0] = _lbl_gen_0;
		}
		#endregion
	}
}