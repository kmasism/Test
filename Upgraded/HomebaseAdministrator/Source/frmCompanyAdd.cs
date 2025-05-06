using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Gui.Controls;
using UpgradeHelpers.Helpers;

namespace HomebaseAdministrator
{
	internal partial class frmCompanyAdd
		: System.Windows.Forms.Form
	{

		public frmCompanyAdd()
			: base()
		{
			if (m_vb6FormDefInstance is null)
			{
				if (m_InitializingDefInstance)
				{
					m_vb6FormDefInstance = this;
				}
				else
				{
					try
					{
						//For the start-up form, the first instance created is the default instance.
						if (!(System.Reflection.Assembly.GetExecutingAssembly().EntryPoint is null) && System.Reflection.Assembly.GetExecutingAssembly().EntryPoint.DeclaringType == this.GetType())
						{
							m_vb6FormDefInstance = this;
						}
					}
					catch
					{
					}
				}
			}
			//This call is required by the Windows Form Designer.
			InitializeComponent();
			ReLoadForm(false);
		}


		private void frmCompanyAdd_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}

		//-----------------------------------------------------------
		// Created: 03/18/2014 - By David D. Cruger
		// Used For Adding Company Records In The Yacht Port Form
		//-----------------------------------------------------------

		private string gstrCompanyName = "";
		private int glCompId = 0;
		private bool gbAdded = false;

		public void SetCompanyName(string strCompany) => gstrCompanyName = ($"{strCompany} ").Trim().Substring(0, Math.Min(100, ($"{strCompany} ").Trim().Length));
		 // SetCompanyName

		public int Get_Company_Id() => glCompId;


		public string Get_Company_Name_Country() => gstrCompanyName;


		public bool Was_Company_Added() => gbAdded;


		public void Clear_Form_Values()
		{

			glCompId = 0;
			gbAdded = false;

			txtCompany.Text = gstrCompanyName;
			txtAddress1.Text = "";
			txtAddress2.Text = "";
			txtCity.Text = "";

			cmbState.Text = "";
			cmbState.SelectedIndex = 0;

			txtZipCode.Text = "";

			cmbCountry.Text = "";
			cmbCountry.SelectedIndex = 0;

			txtWebsite.Text = "";
			txtCompEMail.Text = "";

			cmbAgencyType.Text = "";
			cmbAgencyType.SelectedIndex = 0;
			modAdminCommon.SetComboBox(cmbAgencyType, "C-Civilian");

			cmbAccountType.Text = "";
			cmbAccountType.SelectedIndex = 0;
			modAdminCommon.SetComboBox(cmbAccountType, "EU-End User");

			cmbAccountRep.Text = "";
			cmbAccountRep.SelectedIndex = 0;
			modAdminCommon.SetComboBox(cmbAccountRep, "YT01");

			cmbBusinessType.Text = "";
			cmbBusinessType.SelectedIndex = 0;
			modAdminCommon.SetComboBox(cmbBusinessType, "YH-Yacht Related Business");

			cmbLanguage.Text = "";
			cmbLanguage.SelectedIndex = 0;

			txtCompOfficeCountryCode.Text = "";
			txtCompOfficeAreaCode.Text = "";
			txtCompOfficePrefix.Text = "";
			txtCompOfficeNumber.Text = "";

			txtCompFaxCountryCode.Text = "";
			txtCompFaxAreaCode.Text = "";
			txtCompFaxPrefix.Text = "";
			txtCompFaxNumber.Text = "";

			cmbSirName.Text = "";
			cmbSirName.SelectedIndex = 0;

			txtFirstName.Text = "";
			txtMiddleInit.Text = "";
			txtLastName.Text = "";

			cmbSuffix.Text = "";
			cmbSuffix.SelectedIndex = 0;

			cmbTitle.Text = "";
			cmbTitle.SelectedIndex = 0;

			txtContactEMail.Text = "";

			txtContactOfficeCountryCode.Text = "";
			txtContactOfficeAreaCode.Text = "";
			txtContactOfficePrefix.Text = "";
			txtContactOfficeNumber.Text = "";

			txtContactFaxCountryCode.Text = "";
			txtContactFaxAreaCode.Text = "";
			txtContactFaxPrefix.Text = "";
			txtContactFaxNumber.Text = "";

			chkCompContactAddressFlag.CheckState = CheckState.Unchecked;

		} // Clear_Form_Values

		private void Load_Form_Combo_Box_Values()
		{

			if (cmbState.Items.Count <= 0)
			{
				Load_State_Combo_Box();
			}
			if (cmbCountry.Items.Count <= 0)
			{
				Load_Country_Combo_Box();
			}
			if (cmbSirName.Items.Count <= 0)
			{
				Load_SirName_Combo_Box();
			}
			if (cmbSuffix.Items.Count <= 0)
			{
				Load_Suffix_Combo_Box();
			}
			if (cmbTitle.Items.Count <= 0)
			{
				Load_Title_Combo_Box();
			}

			if (cmbAgencyType.Items.Count <= 0)
			{
				Load_AgencyType_Combo_Box();
			}
			if (cmbAccountType.Items.Count <= 0)
			{
				Load_AccountType_Combo_Box();
			}
			if (cmbAccountRep.Items.Count <= 0)
			{
				Load_AccountRep_Combo_Box();
			}
			if (cmbBusinessType.Items.Count <= 0)
			{
				Load_BusinessType_Combo_Box();
			}
			if (cmbLanguage.Items.Count <= 0)
			{
				Load_Language_Combo_Box();
			}

		} // Load_Form_Combo_Box_Values

		private void Load_State_Combo_Box()
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strCountry = "";

			try
			{

				cmbState.Enabled = false;
				cmbState.Items.Clear();
				cmbState.AddItem("");
				cmbState.SetItemData(cmbState.GetNewIndex(), 0);

				strCountry = cmbCountry.Text;

				strQuery1 = "SELECT state_code_id, state_code, state_name, state_country ";
				strQuery1 = $"{strQuery1}FROM State WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (state_active_flag = 'Y') ";

				if (strCountry != "")
				{
					strQuery1 = $"{strQuery1}AND (state_country = '{StringsHelper.Replace(strCountry, "'", "''", 1, -1, CompareMethod.Binary)}') ";
				}

				strQuery1 = $"{strQuery1}ORDER BY state_country, state_code ";

				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					do 
					{ // Loop Until rstRec1.EOF = True

						cmbState.AddItem($"{($"{Convert.ToString(rstRec1["State_code"])} ").Trim()}-{($"{Convert.ToString(rstRec1["State_name"])} ").Trim()}");
						cmbState.SetItemData(cmbState.GetNewIndex(), Convert.ToInt32(rstRec1["state_code_id"]));

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If rstRec1.BOF = False And rstRec1.EOF = False Then

				rstRec1.Close();

				cmbState.Enabled = true;

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Load_State_Combo_Box_Error", excep.Message);
			}

		} // Load_State_Combo_Box

		private void Load_Country_Combo_Box()
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			try
			{

				cmbCountry.Enabled = false;
				cmbCountry.Items.Clear();
				cmbCountry.AddItem("");
				cmbCountry.AddItem("United States");

				strQuery1 = "SELECT country_name FROM Country WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (country_active_flag = 'Y') ";
				strQuery1 = $"{strQuery1}AND (country_name <> 'United States') ";
				strQuery1 = $"{strQuery1}ORDER BY country_name ";

				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					do 
					{ // Loop Until rstRec1.EOF = True

						cmbCountry.AddItem(Convert.ToString(rstRec1["country_name"]));
						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If rstRec1.BOF = False And rstRec1.EOF = False Then

				rstRec1.Close();

				cmbCountry.Enabled = true;

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Load_Country_Combo_Box_Error", excep.Message);
			}

		} // Load_Country_Combo_Box

		private void Load_SirName_Combo_Box()
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			try
			{

				cmbSirName.Enabled = false;
				cmbSirName.Items.Clear();
				cmbSirName.AddItem("");

				strQuery1 = "SELECT csir_name FROM Contact_Sirname ORDER BY csir_name";

				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					do 
					{ // Loop Until rstRec1.EOF = True

						cmbSirName.AddItem(($"{Convert.ToString(rstRec1["csir_name"])} ").Trim());
						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If rstRec1.BOF = False And rstRec1.EOF = False Then

				rstRec1.Close();

				cmbSirName.Enabled = true;

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Load_SirName_Combo_Box_Error", excep.Message);
			}

		} // Load_SirName_Combo_Box

		private void Load_Suffix_Combo_Box()
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			try
			{

				cmbSuffix.Enabled = false;
				cmbSuffix.Items.Clear();
				cmbSuffix.AddItem("");

				strQuery1 = "SELECT csuffix_name FROM Contact_Suffix ORDER BY csuffix_name";

				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					do 
					{ // Loop Until rstRec1.EOF = True

						cmbSuffix.AddItem(($"{Convert.ToString(rstRec1["csuffix_name"])} ").Trim());
						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If rstRec1.BOF = False And rstRec1.EOF = False Then

				rstRec1.Close();

				cmbSuffix.Enabled = true;

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Load_Suffix_Combo_Box_Error", excep.Message);
			}

		} // Load_Suffix_Combo_Box

		private void Load_Title_Combo_Box()
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			try
			{

				cmbTitle.Enabled = false;
				cmbTitle.Items.Clear();
				cmbTitle.AddItem("");

				strQuery1 = "SELECT ctitle_name FROM Contact_Title ";
				strQuery1 = $"{strQuery1}WHERE (ctitle_active_flag = 'Y') ";
				strQuery1 = $"{strQuery1}ORDER BY ctitle_name";

				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					do 
					{ // Loop Until rstRec1.EOF = True

						cmbTitle.AddItem(($"{Convert.ToString(rstRec1["ctitle_name"])} ").Trim());
						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If rstRec1.BOF = False And rstRec1.EOF = False Then

				rstRec1.Close();

				cmbTitle.Enabled = true;

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Load_Title_Combo_Box_Error", excep.Message);
			}

		} // Load_Title_Combo_Box

		private void Load_AgencyType_Combo_Box()
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			try
			{

				cmbAgencyType.Enabled = false;
				cmbAgencyType.Items.Clear();
				cmbAgencyType.AddItem("");

				strQuery1 = "SELECT cagtype_code, cagtype_name ";
				strQuery1 = $"{strQuery1}FROM Company_Agency_Type WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}ORDER BY cagtype_code";

				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					do 
					{ // Loop Until rstRec1.EOF = True

						cmbAgencyType.AddItem($"{($"{Convert.ToString(rstRec1["cagtype_code"])} ").Trim()}-{($"{Convert.ToString(rstRec1["cagtype_name"])} ").Trim()}");

						//--------------------------
						// C-Civilian

						if (Convert.ToString(rstRec1["cagtype_code"]).Trim() == "C")
						{
							cmbAgencyType.Text = $"{($"{Convert.ToString(rstRec1["cagtype_code"])} ").Trim()}-{($"{Convert.ToString(rstRec1["cagtype_name"])} ").Trim()}";
							cmbAgencyType.SelectedIndex = cmbAgencyType.GetNewIndex();
						}

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If rstRec1.BOF = False And rstRec1.EOF = False Then

				rstRec1.Close();

				cmbAgencyType.Enabled = true;

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Load_AgencyType_Combo_Box_Error", excep.Message);
			}

		} // Load_AgencyType_Combo_Box

		private void Load_AccountType_Combo_Box()
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			try
			{

				cmbAccountType.Enabled = false;
				cmbAccountType.Items.Clear();
				cmbAccountType.AddItem("");

				strQuery1 = "SELECT cacctype_code, cacctype_name ";
				strQuery1 = $"{strQuery1}FROM Company_Account_Type WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}ORDER BY cacctype_code";

				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					do 
					{ // Loop Until rstRec1.EOF = True

						cmbAccountType.AddItem($"{($"{Convert.ToString(rstRec1["cacctype_code"])} ").Trim()}-{($"{Convert.ToString(rstRec1["cacctype_name"])} ").Trim()}");

						//--------------------------
						// EU-End User

						if (Convert.ToString(rstRec1["cacctype_code"]).Trim() == "EU")
						{
							cmbAccountType.Text = $"{($"{Convert.ToString(rstRec1["cacctype_code"])} ").Trim()}-{($"{Convert.ToString(rstRec1["cacctype_name"])} ").Trim()}";
							cmbAccountType.SelectedIndex = cmbAccountType.GetNewIndex();
						}

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If rstRec1.BOF = False And rstRec1.EOF = False Then

				rstRec1.Close();

				cmbAccountType.Enabled = true;

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Load_AccountType_Combo_Box_Error", excep.Message);
			}

		} // Load_AccountType_Combo_Box

		private void Load_AccountRep_Combo_Box()
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			try
			{

				cmbAccountRep.Enabled = false;
				cmbAccountRep.Items.Clear();
				cmbAccountRep.AddItem("");

				strQuery1 = "SELECT DISTINCT accrep_account_id FROM Account_Rep WITH (NOLOCK) ";

				//If cmbAccountType.Text <> "" Then
				//  strQuery1 = strQuery1 & "WHERE (accrep_account_type = '" & left(cmbAccountType.Text, 2) & "') "
				//End If

				strQuery1 = $"{strQuery1}ORDER BY accrep_account_id";

				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					do 
					{ // Loop Until rstRec1.EOF = True

						cmbAccountRep.AddItem(($"{Convert.ToString(rstRec1["accrep_account_id"])} ").Trim());

						//--------------------------
						// YT01

						if (Convert.ToString(rstRec1["accrep_account_id"]).Trim() == "YT01")
						{
							cmbAccountRep.Text = ($"{Convert.ToString(rstRec1["accrep_account_id"])} ").Trim();
							cmbAccountRep.SelectedIndex = cmbAccountRep.GetNewIndex();
						}

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If rstRec1.BOF = False And rstRec1.EOF = False Then

				rstRec1.Close();

				cmbAccountRep.Enabled = true;

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Load_AccountRep_Combo_Box_Error", excep.Message);
			}

		} // Load_AccountRep_Combo_Box

		private void Load_BusinessType_Combo_Box()
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			try
			{

				cmbBusinessType.Enabled = false;
				cmbBusinessType.Items.Clear();
				cmbBusinessType.AddItem("");

				strQuery1 = "SELECT cbus_type, cbus_name ";
				strQuery1 = $"{strQuery1}FROM Company_Business_Type WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (cbus_yacht_flag = 'Y') ";
				strQuery1 = $"{strQuery1}ORDER BY cbus_type";

				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					do 
					{ // Loop Until rstRec1.EOF = True

						cmbBusinessType.AddItem($"{($"{Convert.ToString(rstRec1["cbus_type"])} ").Trim()}-{($"{Convert.ToString(rstRec1["cbus_name"])} ").Trim()}");

						//--------------------------
						// YH-Yacht Related Business

						if (Convert.ToString(rstRec1["cbus_type"]).Trim() == "YH")
						{
							cmbBusinessType.Text = $"{($"{Convert.ToString(rstRec1["cbus_type"])} ").Trim()}-{($"{Convert.ToString(rstRec1["cbus_name"])} ").Trim()}";
							cmbBusinessType.SelectedIndex = cmbBusinessType.GetNewIndex();
						}

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If rstRec1.BOF = False And rstRec1.EOF = False Then

				rstRec1.Close();

				cmbBusinessType.Enabled = true;

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Load_BusinessType_Combo_Box_Error", excep.Message);
			}

		} // Load_BusinessType_Combo_Box

		private void Load_Language_Combo_Box()
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			try
			{

				cmbLanguage.Enabled = false;
				cmbLanguage.Items.Clear();
				cmbLanguage.AddItem("");

				strQuery1 = "SELECT language_name ";
				strQuery1 = $"{strQuery1}FROM Language WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}ORDER BY language_name";

				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					do 
					{ // Loop Until rstRec1.EOF = True

						cmbLanguage.AddItem(($"{Convert.ToString(rstRec1["language_name"])} ").Trim());
						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If rstRec1.BOF = False And rstRec1.EOF = False Then

				rstRec1.Close();

				cmbLanguage.Enabled = true;

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Load_Language_Combo_Box_Error", excep.Message);
			}

		} // Load_Language_Combo_Box

		private void cmbCountry_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs)
		{

			if (cmbCountry.Enabled)
			{

				Load_State_Combo_Box();

			} // If cmbCountry.Enabled = True Then

		} // cmbCountry_Click

		private bool Valid_Company_Add_Form(ref string strMsg)
		{


			bool bResults = true;
			strMsg = "";

			if (txtCompany.Text.Trim() == "")
			{
				bResults = false;
				strMsg = $"{strMsg}Company Name Is Blank";
			}

			if (cmbAgencyType.Text.Trim() == "")
			{
				bResults = false;
				strMsg = $"{strMsg}Agency Type Is Blank";
			}

			if (cmbAccountType.Text.Trim() == "")
			{
				bResults = false;
				strMsg = $"{strMsg}Account Type Is Blank";
			}

			if (cmbAccountRep.Text.Trim() == "")
			{
				bResults = false;
				strMsg = $"{strMsg}Account Rep Is Blank";
			}

			if (cmbBusinessType.Text.Trim() == "")
			{
				bResults = false;
				strMsg = $"{strMsg}Business Type Is Blank";
			}

			if (cmbLanguage.Text.Trim() == "")
			{
				bResults = false;
				strMsg = $"{strMsg}Language Is Blank";
			}

			return bResults;

		} // Valid_Company_Add_Form

		private void cmdAdd_Click(Object eventSender, EventArgs eventArgs)
		{

			ADORecordSetHelper rstComp = new ADORecordSetHelper();
			string strQuery1 = "";
			string strInsert1 = "";
			string strMsg = "";

			ADORecordSetHelper rstContact = new ADORecordSetHelper();
			string strQuery2 = "";

			ADORecordSetHelper rstPhone = new ADORecordSetHelper();
			string strQuery3 = "";

			int lContactId = 0;
			string strPhoneFull = "";
			string strPhoneSearch = "";
			string strAVDataId = "";

			System.DateTime dtStartDate = DateTime.FromOADate(0);
			System.DateTime dtEndDate = DateTime.FromOADate(0);

			try
			{

				glCompId = 0;

				if (Valid_Company_Add_Form(ref strMsg))
				{

					strAVDataId = modAdminCommon.CreateNewAVDataId();

					//------------------------------------------
					// Add Company Record First

					strQuery1 = "SELECT * FROM Company WHERE (comp_id = -1) AND (comp_journ_id = 0) ";

					rstComp.CursorLocation = CursorLocationEnum.adUseClient;
					rstComp.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);

					glCompId = Convert.ToInt32(Double.Parse(modAdminCommon.DLookUp("MAX(comp_id)", "Company")));
					glCompId++;

					rstComp.AddNew();

					rstComp["comp_id"] = glCompId;
					rstComp["comp_journ_id"] = 0;
					rstComp["comp_active_flag"] = "Y";
					rstComp["comp_acpros_flag"] = "N";
					rstComp["comp_awaitdoc_flag"] = "N";
					rstComp["comp_hide_flag"] = "N";
					rstComp["comp_product_business_flag"] = "N";
					rstComp["comp_product_commercial_flag"] = "N";
					rstComp["comp_product_helicopter_flag"] = "N";
					rstComp["comp_product_airbp_flag"] = "N";
					rstComp["comp_product_abi_flag"] = "N";
					rstComp["comp_product_yacht_flag"] = "Y";
					rstComp["comp_assign_flag"] = "A";
					rstComp["comp_avdata_id"] = strAVDataId;
					rstComp["comp_ent_user_id"] = modAdminCommon.gbl_User_ID;

					rstComp["comp_name"] = txtCompany.Text.Trim();
					rstComp["comp_name_search"] = modAdminCommon.LeaveOnlyAlphaAndNumeric(txtCompany.Text.Trim()).ToUpper();

					if (txtAddress1.Text.Trim() != "")
					{
						rstComp["comp_address1"] = txtAddress1.Text.Trim();
						rstComp["comp_address1_search"] = txtAddress1.Text.Trim();
						rstComp["comp_address1_search"] = modAdminCommon.LeaveOnlyAlphaAndNumeric(txtAddress1.Text.Trim()).ToUpper();
					}
					if (txtAddress2.Text.Trim() != "")
					{
						rstComp["comp_address2"] = txtAddress2.Text.Trim();
						rstComp["comp_address2_search"] = modAdminCommon.LeaveOnlyAlphaAndNumeric(txtAddress2.Text.Trim()).ToUpper();
					}

					if (txtCity.Text.Trim() != "")
					{
						rstComp["comp_city"] = txtCity.Text.Trim();
					}
					if (cmbState.Text.Substring(0, Math.Min(2, cmbState.Text.Length)).Trim() != "")
					{
						rstComp["comp_state"] = cmbState.Text.Substring(0, Math.Min(2, cmbState.Text.Length)).Trim();
					}
					if (txtZipCode.Text.Trim() != "")
					{
						rstComp["comp_zip_code"] = txtZipCode.Text.Trim();
					}
					if (cmbCountry.Text.Trim() != "")
					{
						rstComp["comp_country"] = cmbCountry.Text.Trim();
					}
					if (txtWebsite.Text.Trim() != "")
					{
						rstComp["comp_web_address"] = txtWebsite.Text.Trim();
					}
					if (txtCompEMail.Text.Trim() != "")
					{
						rstComp["comp_email_address"] = txtCompEMail.Text.Trim();
					}

					if (cmbAgencyType.Text.Trim() != "")
					{
						rstComp["comp_agency_type"] = cmbAgencyType.Text.Trim().Substring(0, Math.Min(1, cmbAgencyType.Text.Trim().Length));
					}
					if (cmbAccountType.Text.Trim() != "")
					{
						rstComp["comp_account_type"] = cmbAccountType.Text.Trim().Substring(0, Math.Min(2, cmbAccountType.Text.Trim().Length));
					}
					if (cmbAccountRep.Text.Trim() != "")
					{
						rstComp["comp_account_id"] = cmbAccountRep.Text.Trim();
					}
					if (cmbBusinessType.Text.Trim() != "")
					{
						rstComp["comp_business_type"] = cmbBusinessType.Text.Trim().Substring(0, Math.Min(2, cmbBusinessType.Text.Trim().Length));
					}
					if (cmbLanguage.Text.Trim() != "")
					{
						rstComp["comp_language"] = cmbLanguage.Text.Trim();
					}

					// 02/19/2016 - By David D. Cruger; Added
					if (chkCompContactAddressFlag.CheckState == CheckState.Checked)
					{
						rstComp["comp_contact_address_flag"] = "Y";
					}
					else
					{
						rstComp["comp_contact_address_flag"] = "N";
					}

					rstComp.UpdateBatch();

					glCompId = Convert.ToInt32(rstComp["comp_id"]);

					rstComp.Close();

					modAdminCommon.Start_Activity_Monitor_Message("Company Added", ref strMsg, ref dtStartDate, ref dtEndDate);
					strMsg = $" - {txtCompany.Text.Trim()}";
					modAdminCommon.End_Activity_Monitor_Message("Company Added", ref strMsg, dtStartDate, ref dtEndDate, 0, 0, glCompId, 0, 0);

					if (txtWebsite.Text.Trim() != "")
					{
						modAdminCommon.Start_Activity_Monitor_Message("Company WebSite Added", ref strMsg, ref dtStartDate, ref dtEndDate);
						strMsg = $" - {txtWebsite.Text.Trim()}";
						modAdminCommon.End_Activity_Monitor_Message("Company WebSite Added", ref strMsg, dtStartDate, ref dtEndDate, 0, 0, glCompId, 0, 0);
					}

					if (txtCompEMail.Text.Trim() != "")
					{
						modAdminCommon.Start_Activity_Monitor_Message("Company EMail Added", ref strMsg, ref dtStartDate, ref dtEndDate);
						strMsg = $" - {txtCompEMail.Text.Trim()}";
						modAdminCommon.End_Activity_Monitor_Message("Company EMail Added", ref strMsg, dtStartDate, ref dtEndDate, 0, 0, glCompId, 0, 0);
					}

					gstrCompanyName = txtCompany.Text.Trim();
					if (cmbCountry.Text.Trim() != "")
					{
						gstrCompanyName = $"{gstrCompanyName}, {cmbCountry.Text.Trim()}";
					}

					//---------------------------------------
					// Insert Business Type Reference

					strInsert1 = "INSERT INTO Business_Type_Reference ";
					strInsert1 = $"{strInsert1}(bustypref_comp_id, bustypref_journ_id, bustypref_type, bustypref_seq_no) ";
					strInsert1 = $"{strInsert1}VALUES (";
					strInsert1 = $"{strInsert1}{glCompId.ToString()},";
					strInsert1 = $"{strInsert1}0,";
					strInsert1 = $"{strInsert1}'{cmbBusinessType.Text.Trim().Substring(0, Math.Min(2, cmbBusinessType.Text.Trim().Length))}',";
					strInsert1 = $"{strInsert1}1";
					strInsert1 = $"{strInsert1}) ";

					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = strInsert1;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();

					//-------------------------------------------------
					// Check For Either Company Office Or Fax Number

					if ((((txtCompOfficeNumber.Text.Trim() != "") ? -1 : 0) | Convert.ToInt32(Double.Parse((txtCompFaxNumber.Text != "").ToString().Trim()))) != 0)
					{

						strQuery2 = "SELECT * FROM Phone_Numbers WHERE (pnum_comp_id = -1) ";

						rstPhone.Open(strQuery2, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);

						if (txtCompOfficeNumber.Text.Trim() != "")
						{

							modAdminCommon.BuildPhoneNumberFull(txtCompOfficeCountryCode.Text, txtCompOfficeAreaCode.Text, txtCompOfficePrefix.Text, txtCompOfficeNumber.Text, ref strPhoneFull, ref strPhoneSearch);

							rstPhone.AddNew();

							rstPhone["pnum_comp_id"] = glCompId;
							rstPhone["pnum_contact_id"] = 0;
							rstPhone["pnum_journ_id"] = 0;
							rstPhone["pnum_type"] = "Office";
							if (txtCompOfficeCountryCode.Text.Trim() != "")
							{
								rstPhone["pnum_cntry_code"] = txtCompOfficeCountryCode.Text.Trim();
							}
							if (txtCompOfficeAreaCode.Text.Trim() != "")
							{
								rstPhone["pnum_area_code"] = txtCompOfficeAreaCode.Text.Trim();
							}
							if (txtCompOfficePrefix.Text.Trim() != "")
							{
								rstPhone["pnum_prefix"] = txtCompOfficePrefix.Text.Trim();
							}
							rstPhone["pnum_number"] = txtCompOfficeNumber.Text.Trim();
							rstPhone["pnum_number_full"] = strPhoneFull;
							rstPhone["pnum_hide_customer"] = "N";
							rstPhone["pnum_number_full_search"] = strPhoneSearch;

							rstPhone.UpdateBatch();

							modAdminCommon.Start_Activity_Monitor_Message("Company Phone Added", ref strMsg, ref dtStartDate, ref dtEndDate);
							strMsg = $" - Office - {strPhoneFull}";
							modAdminCommon.End_Activity_Monitor_Message("Company Phone Added", ref strMsg, dtStartDate, ref dtEndDate, 0, 0, glCompId, 0, 0);

						} // If Trim(txtCompOfficeNumber.Text) <> "" Then

						if (txtCompFaxNumber.Text.Trim() != "")
						{

							modAdminCommon.BuildPhoneNumberFull(txtCompFaxCountryCode.Text, txtCompFaxAreaCode.Text, txtCompFaxPrefix.Text, txtCompFaxNumber.Text, ref strPhoneFull, ref strPhoneSearch);

							rstPhone.AddNew();

							rstPhone["pnum_comp_id"] = glCompId;
							rstPhone["pnum_contact_id"] = 0;
							rstPhone["pnum_journ_id"] = 0;
							rstPhone["pnum_type"] = "Fax";
							if (txtCompFaxCountryCode.Text.Trim() != "")
							{
								rstPhone["pnum_cntry_code"] = txtCompFaxCountryCode.Text.Trim();
							}
							if (txtCompFaxAreaCode.Text.Trim() != "")
							{
								rstPhone["pnum_area_code"] = txtCompFaxAreaCode.Text.Trim();
							}
							if (txtCompFaxPrefix.Text.Trim() != "")
							{
								rstPhone["pnum_prefix"] = txtCompFaxPrefix.Text.Trim();
							}
							rstPhone["pnum_number"] = txtCompFaxNumber.Text.Trim();
							rstPhone["pnum_number_full"] = strPhoneFull;
							rstPhone["pnum_hide_customer"] = "N";
							rstPhone["pnum_number_full_search"] = strPhoneSearch;

							rstPhone.UpdateBatch();

							modAdminCommon.Start_Activity_Monitor_Message("Company Phone Added", ref strMsg, ref dtStartDate, ref dtEndDate);
							strMsg = $" - Fax - {strPhoneFull}";
							modAdminCommon.End_Activity_Monitor_Message("Company Phone Added", ref strMsg, dtStartDate, ref dtEndDate, 0, 0, glCompId, 0, 0);

						} // If Trim(txtCompFaxNumber.Text) <> "" Then

						rstPhone.Close();

					} // If Trim(txtCompOfficeNumber.Text) <> "" Or Trim(txtCompFaxNumber.Text <> "") Then

					//-------------------------------------------
					// Now Add Contact

					if (txtFirstName.Text.Trim() != "" && txtLastName.Text.Trim() != "")
					{

						strQuery3 = "SELECT * FROM Contact WHERE (contact_id = -1) ";

						rstContact.CursorLocation = CursorLocationEnum.adUseClient;
						rstContact.Open(strQuery3, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);

						lContactId = Convert.ToInt32(Double.Parse(modAdminCommon.DLookUp("MAX(contact_id)", "Contact")));
						lContactId++;

						rstContact.AddNew();

						rstContact["contact_id"] = lContactId;
						rstContact["contact_comp_id"] = glCompId;

						rstContact["contact_active_flag"] = "N";
						if (cmbSirName.Text.Trim() != "")
						{
							rstContact["contact_sirname"] = cmbSirName.Text.Trim();
						}
						if (txtFirstName.Text.Trim() != "")
						{
							rstContact["contact_first_name"] = txtFirstName.Text.Trim();
						}
						if (!txtMiddleInit.Text.Trim().StartsWith("", StringComparison.Ordinal))
						{
							rstContact["contact_middle_initial"] = txtMiddleInit.Text.Trim().Substring(0, Math.Min(1, txtMiddleInit.Text.Trim().Length));
						}
						if (txtLastName.Text.Trim() != "")
						{
							rstContact["contact_last_name"] = txtLastName.Text.Trim();
						}
						if (cmbSuffix.Text.Trim() != "")
						{
							rstContact["contact_suffix"] = cmbSuffix.Text.Trim();
						}
						if (cmbTitle.Text.Trim() != "")
						{
							rstContact["contact_title"] = cmbTitle.Text.Trim();
						}
						if (txtContactEMail.Text.Trim() != "")
						{
							rstContact["contact_email_address"] = txtContactEMail.Text.Trim();
						}

						rstContact.UpdateBatch();

						lContactId = Convert.ToInt32(rstContact["contact_id"]);

						rstContact.Close();

						if (lContactId > 0)
						{

							modAdminCommon.Start_Activity_Monitor_Message("Contact Added", ref strMsg, ref dtStartDate, ref dtEndDate);
							strMsg = $" - {txtFirstName.Text.Trim()} {txtLastName.Text.Trim()}";
							modAdminCommon.End_Activity_Monitor_Message("Contact Added", ref strMsg, dtStartDate, ref dtEndDate, 0, 0, glCompId, 0, lContactId);

							if (txtContactEMail.Text.Trim() != "")
							{
								modAdminCommon.Start_Activity_Monitor_Message("Contact EMail Added", ref strMsg, ref dtStartDate, ref dtEndDate);
								strMsg = $" - {txtContactEMail.Text.Trim()}";
								modAdminCommon.End_Activity_Monitor_Message("Contact EMail Added", ref strMsg, dtStartDate, ref dtEndDate, 0, 0, glCompId, 0, lContactId);
							}

							//-------------------------------------------------
							// Check For Either Contact Office Or Fax Number

							if ((((txtContactOfficeNumber.Text.Trim() != "") ? -1 : 0) | Convert.ToInt32(Double.Parse((txtContactFaxNumber.Text != "").ToString().Trim()))) != 0)
							{

								strQuery2 = "SELECT * FROM Phone_Numbers WHERE (pnum_Contact_id = -1) ";

								rstPhone.Open(strQuery2, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);

								if (txtContactOfficeNumber.Text.Trim() != "")
								{

									modAdminCommon.BuildPhoneNumberFull(txtContactOfficeCountryCode.Text, txtContactOfficeAreaCode.Text, txtContactOfficePrefix.Text, txtContactOfficeNumber.Text, ref strPhoneFull, ref strPhoneSearch);

									rstPhone.AddNew();

									rstPhone["pnum_comp_id"] = glCompId;
									rstPhone["pnum_contact_id"] = lContactId;
									rstPhone["pnum_journ_id"] = 0;
									rstPhone["pnum_type"] = "Office";
									if (txtContactOfficeCountryCode.Text.Trim() != "")
									{
										rstPhone["pnum_cntry_code"] = txtContactOfficeCountryCode.Text.Trim();
									}
									if (txtContactOfficeAreaCode.Text.Trim() != "")
									{
										rstPhone["pnum_area_code"] = txtContactOfficeAreaCode.Text.Trim();
									}
									if (txtContactOfficePrefix.Text.Trim() != "")
									{
										rstPhone["pnum_prefix"] = txtContactOfficePrefix.Text.Trim();
									}
									rstPhone["pnum_number"] = txtContactOfficeNumber.Text.Trim();
									rstPhone["pnum_number_full"] = strPhoneFull;
									rstPhone["pnum_hide_customer"] = "N";
									rstPhone["pnum_number_full_search"] = strPhoneSearch;

									rstPhone.UpdateBatch();

									modAdminCommon.Start_Activity_Monitor_Message("Contact Phone Added", ref strMsg, ref dtStartDate, ref dtEndDate);
									strMsg = $" - Office - {strPhoneFull}";
									modAdminCommon.End_Activity_Monitor_Message("Contact Phone Added", ref strMsg, dtStartDate, ref dtEndDate, 0, 0, glCompId, 0, lContactId);

								} // If Trim(txtContactOfficeNumber.Text) <> "" Then

								if (txtContactFaxNumber.Text.Trim() != "")
								{

									modAdminCommon.BuildPhoneNumberFull(txtContactFaxCountryCode.Text, txtContactFaxAreaCode.Text, txtContactFaxPrefix.Text, txtContactFaxNumber.Text, ref strPhoneFull, ref strPhoneSearch);

									rstPhone.AddNew();

									rstPhone["pnum_comp_id"] = glCompId;
									rstPhone["pnum_contact_id"] = lContactId;
									rstPhone["pnum_journ_id"] = 0;
									rstPhone["pnum_type"] = "Fax";
									if (txtContactFaxCountryCode.Text.Trim() != "")
									{
										rstPhone["pnum_cntry_code"] = txtContactFaxCountryCode.Text.Trim();
									}
									if (txtContactFaxAreaCode.Text.Trim() != "")
									{
										rstPhone["pnum_area_code"] = txtContactFaxAreaCode.Text.Trim();
									}
									if (txtContactFaxPrefix.Text.Trim() != "")
									{
										rstPhone["pnum_prefix"] = txtContactFaxPrefix.Text.Trim();
									}
									rstPhone["pnum_number"] = txtContactFaxNumber.Text.Trim();
									rstPhone["pnum_number_full"] = strPhoneFull;
									rstPhone["pnum_hide_customer"] = "N";
									rstPhone["pnum_number_full_search"] = strPhoneSearch;

									rstPhone.UpdateBatch();

									modAdminCommon.Start_Activity_Monitor_Message("Contact Phone Added", ref strMsg, ref dtStartDate, ref dtEndDate);
									strMsg = $" - Fax - {strPhoneFull}";
									modAdminCommon.End_Activity_Monitor_Message("Contact Phone Added", ref strMsg, dtStartDate, ref dtEndDate, 0, 0, glCompId, 0, lContactId);

								} // If Trim(txtContactFaxNumber.Text) <> "" Then

								rstPhone.Close();

							} // If Trim(txtContactOfficeNumber.Text) <> "" Or Trim(txtContactFaxNumber.Text <> "") Then

						} // If lContactId > 0 Then

					} // If Trim(txtFirstName.Text) <> "" And Trim(txtLastName.Text) <> "" Then

					gbAdded = true;
					this.Hide();

				}
				else
				{
					MessageBox.Show($"Add Company Record Form Validation Failed{Environment.NewLine}{Environment.NewLine}{strMsg}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If Valid_Company_Add_Form(strMsg) = True Then

				rstPhone = null;
				rstContact = null;
				rstComp = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error("cmdAdd_Click_Error", excep.Message);
			}

		} // cmdAdd_Click

		private void cmdClose_Click(Object eventSender, EventArgs eventArgs) => this.Hide();


		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
		private void Form_Load()
		{

			gstrCompanyName = "";

			Load_Form_Combo_Box_Values();

		} // Form_Load
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}