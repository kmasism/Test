using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Gui;
using UpgradeHelpers.Gui.Controls;
using UpgradeHelpers.Gui.Utils;
using UpgradeHelpers.Helpers;
using UpgradeStubs;

namespace JETNET_Homebase
{
	internal partial class frm_AddAircraft
		: System.Windows.Forms.Form
	{


		//==================
		// Public Variables
		//==================
		public int PassedModelID = 0;
		public int MFR_Comp_id = 0;

		//===================
		// Private Variables
		//===================
		private bool FirstLoad = false;

		private string[] arr_Transmit_Fields = null;
		private bool Stop_Airport_Fill = false;
		private string Airframe_Type_Code = "";
		private string Company_Product = "";
		private int NewACID = 0;
		private int comp_id = 0;
		private bool bInsertedAircraft = false;
		private bool bIsValidForInsert = false;
		private modGlobalVars.e_find_form_action_types tCompFind_ActionTypes = (modGlobalVars.e_find_form_action_types) 0;
		private modGlobalVars.e_find_form_entry_points tCompFind_EntryPoints = (modGlobalVars.e_find_form_entry_points) 0;

		private int FoundCompanyID = 0;
		private int FoundContactID = 0;
		private bool bHasMaxCompID = false;
		public frm_AddAircraft()
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




		private void SetupSerialNumbers()
		{
			//aey 4/21/05

			if (cbo_amod_make_name.SelectedIndex > -1)
			{
				Airframe_Type_Code = modCommon.DLookUp("amod_airframe_type_code", "Aircraft_Model", $"amod_id ={cbo_amod_make_name.GetItemData(cbo_amod_make_name.SelectedIndex).ToString()}");
				Company_Product = "B"; //aey 6/23/05 default

				if (Airframe_Type_Code == "R")
				{
					txt_ac_alt_ser_no_prefix.MaxLength = 7;
					txt_ac_alt_ser_no.MaxLength = 20;
					txt_ac_alt_ser_no_suffix.MaxLength = 7;
					txt_ac_ser_no_prefix.MaxLength = 7;
					txt_ac_ser_no.MaxLength = 20;
					txt_ac_ser_no_suffix.MaxLength = 7;
					Company_Product = "H";
				}
				else
				{
					txt_ac_alt_ser_no_prefix.MaxLength = 7;
					txt_ac_alt_ser_no.MaxLength = 8;
					txt_ac_alt_ser_no_suffix.MaxLength = 7;
					txt_ac_ser_no_prefix.MaxLength = 7;
					txt_ac_ser_no.MaxLength = 8;
					txt_ac_ser_no_suffix.MaxLength = 7;
				}
			}

		}

		private void FillEngineModelList()
		{

			string Query = "";
			ADORecordSetHelper snp_Aircraft_Model_Engine = new ADORecordSetHelper();

			try
			{

				cbo_ac_engine_name.Items.Clear();
				cbo_ac_engine_name.AddItem("");

				if (cbo_amod_make_name.SelectedIndex >= 0)
				{

					Query = "SELECT * FROM Aircraft_Model_Engine WITH(NOLOCK)";
					Query = $"{Query} WHERE (ameng_amod_id={cbo_amod_make_name.GetItemData(cbo_amod_make_name.SelectedIndex).ToString()})";

					snp_Aircraft_Model_Engine.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!(snp_Aircraft_Model_Engine.BOF && snp_Aircraft_Model_Engine.EOF))
					{

						while(!snp_Aircraft_Model_Engine.EOF)
						{
							cbo_ac_engine_name.AddItem(($"{Convert.ToString(snp_Aircraft_Model_Engine["ameng_engine_name"])} ").Trim());
							cbo_ac_engine_name.SetItemData(cbo_ac_engine_name.Items.Count - 1, Convert.ToInt32(snp_Aircraft_Model_Engine["ameng_engine_model_id"]));

							snp_Aircraft_Model_Engine.MoveNext();
						};
						cbo_ac_engine_name.SelectedIndex = 0;
					}

					snp_Aircraft_Model_Engine.Close();

				}

				snp_Aircraft_Model_Engine = null;
			}
			catch
			{

				this.Cursor = CursorHelper.CursorDefault;
				modAdminCommon.Report_Error("FillEngineModelList_Error: ");
			}

		}

		//UPGRADE_NOTE: (7001) The following declaration (GetAccountID) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private string GetAccountID(int incompid)
		//{
			//
			//string result = "";
			//ADORecordSetHelper snpAcct = new ADORecordSetHelper();
			//
			//
			//string Query = "SELECT comp_account_id FROM Company WITH(NOLOCK)";
			//Query = $"{Query} WHERE (comp_id = {incompid.ToString()}) AND (comp_journ_id = 0)";
			//
			//snpAcct.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
			//
			//if (!(snpAcct.BOF && snpAcct.EOF))
			//{
				//result = ($"{Convert.ToString(snpAcct["comp_account_id"])}").Trim();
			//}
			//
			//snpAcct.Close();
			//
			//return result;
		//}

		private void GetACPrefixSuffix(int PassedModelID)
		{

			ADORecordSetHelper snpSerial = new ADORecordSetHelper();

			chkHyphen.CheckState = CheckState.Unchecked;
			string Query = "SELECT amod_ser_no_prefix, amod_ser_no_suffix, amod_serno_hyphen_flag";
			Query = $"{Query} FROM Aircraft_Model WITH(NOLOCK) WHERE (amod_id = {PassedModelID.ToString()})";

			snpSerial.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

			if (!(snpSerial.BOF && snpSerial.EOF))
			{
				txt_ac_ser_no_prefix.Text = ($"{Convert.ToString(snpSerial["amod_ser_no_prefix"])}").Trim();
				txt_ac_ser_no_suffix.Text = ($"{Convert.ToString(snpSerial["amod_ser_no_suffix"])}").Trim();

				if (($"{Convert.ToString(snpSerial["amod_serno_hyphen_flag"])}").Trim() == "Y")
				{
					chkHyphen.CheckState = CheckState.Checked;
				}

			}

			snpSerial.Close();

		}

		private void InsertFeatureCodes()
		{

			ADORecordSetHelper snpFeature = new ADORecordSetHelper();
			string FeatureStatus = "";


			string Query = "SELECT * FROM Aircraft_Model_Key_Feature WITH(NOLOCK)";
			ErrorHandlingHelper.ResumeNext(
				() => {Query = $"{Query}WHERE (amfeat_amod_id = {cbo_amod_make_name.GetItemData(cbo_amod_make_name.SelectedIndex).ToString()}) ";}, 
				() => {Query = $"{Query}AND (amfeat_inactive_date IS NULL) ";}, 

				() => {snpFeature.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);});

			if (!(snpFeature.BOF && snpFeature.EOF))
			{
				// 08/25/2006 - By David D. Cruger; Removed the MoveFirst statement

				while(!snpFeature.EOF)
				{
					DbCommand TempCommand = null;
					FeatureStatus = "U";
					if (ErrorHandlingHelper.ResumeNextExpr<bool>(() => Convert.ToString(snpFeature["amfeat_standard_equip"]) == "Y"))
					{
						FeatureStatus = "Y";
					}
					Query = "INSERT INTO Aircraft_Key_Feature (";
					ErrorHandlingHelper.ResumeNext(
						() => {Query = $"{Query}afeat_ac_id, afeat_journ_id, afeat_feature_code, afeat_status_flag, afeat_seq_no";}, 
						() => {Query = $"{Query}) VALUES (";}, 

						() => {Query = $"{Query}{modAdminCommon.gbl_Aircraft_ID.ToString()},";}, 

						() => {Query = $"{Query}0,";}, 
						() => {Query = $"{Query}'{Convert.ToString(snpFeature["amfeat_feature_code"])}',";}, 
						() => {Query = $"{Query}'{FeatureStatus}',";}, 
						() => {Query = $"{Query}{($"{Convert.ToString(snpFeature["amfeat_seq_no"])}").Trim()})";}, 

						() => {TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();}, 
						() => {UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);}, 
						() => {TempCommand.CommandText = Query;}, 
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'ADODB.ExecuteOptionEnum' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						() => {TempCommand.CommandType = (CommandType) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords();}, 
						() => {UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);}, 
						() => {TempCommand.ExecuteNonQuery();}, 

						() => {snpFeature.MoveNext();});
				};
			}
			ErrorHandlingHelper.ResumeNext(

				() => {snpFeature.Close();}, 
				() => {snpFeature = null;});

		}

		private void InsertNewACJournalNote()
		{


			modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(modAdminCommon.DateToday);
			modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "RN";
			modAdminCommon.Rec_Journal_Info.journ_subject = "Aircraft Added To System";
			modAdminCommon.Rec_Journal_Info.journ_description = " ";
			modAdminCommon.Rec_Journal_Info.journ_ac_id = modAdminCommon.gbl_Aircraft_ID;
			modAdminCommon.Rec_Journal_Info.journ_comp_id = 0;
			modAdminCommon.Rec_Journal_Info.journ_contact_id = 0;
			modAdminCommon.Rec_Journal_Info.journ_account_id = "";
			modAdminCommon.Rec_Journal_Info.journ_prior_account_id = "";
			modAdminCommon.Rec_Journal_Info.journ_status = "A";

			int tmpJournID = frm_Journal.DefInstance.Commit_Journal_Entry();

			if (!(tmpJournID > 0))
			{
				MessageBox.Show("Error Inserting Journal Note", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}

		private void ac_product_chk_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{

			if ((SSPanel_productCode.BorderStyle == BorderStyle.FixedSingle) && bIsValidForInsert)
			{
				SSPanel_productCode.BorderStyle = BorderStyle.None;
			}

		}

		private void cbo_ac_engine_name_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs)
		{



			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strEMId = "";

			if (cbo_ac_engine_name.SelectedIndex > 0)
			{
				strEMId = cbo_ac_engine_name.GetItemData(cbo_ac_engine_name.SelectedIndex).ToString();

				if (StringsHelper.ToDoubleSafe(strEMId) > 0)
				{

					strQuery1 = $"SELECT * FROM Engine_Models WITH (NOLOCK) WHERE (em_id = {strEMId}) ";

					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["em_engine_com_tbo_hrs"]))
						{
							txt_ac_engine_tbo_hrs[0].Text = Convert.ToString(rstRec1["em_engine_com_tbo_hrs"]);
						}


					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

				}
			}





		}

		private void cbo_amod_make_name_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs)
		{

			GetACType(cbo_amod_make_name.GetItemData(cbo_amod_make_name.SelectedIndex));
			GetACPrefixSuffix(cbo_amod_make_name.GetItemData(cbo_amod_make_name.SelectedIndex));
			FillEngineModelList();
			SetupSerialNumbers();
			display_product_Codes();

			// added MSW - if its one of these models, add in the commercial check box
			if (cbo_amod_make_name.GetItemData(cbo_amod_make_name.SelectedIndex) == 180 || cbo_amod_make_name.GetItemData(cbo_amod_make_name.SelectedIndex) == 181 || cbo_amod_make_name.GetItemData(cbo_amod_make_name.SelectedIndex) == 1170)
			{
				ac_product_chk[2].CheckState = CheckState.Checked;
			}


		}

		private void cboBaseCountry_Leave(Object eventSender, EventArgs eventArgs)
		{
			if (Stop_Airport_Fill)
			{
				return;
			} //aey 9/27/04
			if (Strings.Len(cboBaseCountry.Text.Trim()) == 0)
			{
				return;
			}

			GetBaseCodeInformation(4);
		}

		private void cboBaseState_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs) => modFillCompConControls.Select_Unknown_Country(cboBaseState, cboBaseCountry);


		private void cboBaseState_Leave(Object eventSender, EventArgs eventArgs)
		{
			if (Stop_Airport_Fill)
			{
				return;
			} //aey 9/27/04
			if (Strings.Len(cboBaseState.Text.Trim()) == 0)
			{
				return;
			}

			GetBaseCodeInformation(3);
		}

		private void cboState_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs) => modFillCompConControls.Select_Unknown_Country(cboState, cboCountry);


		private void chk_forsale_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{

			chk_Exclusive_Flag.CheckState = CheckState.Unchecked;

			if (chk_forsale.CheckState == CheckState.Checked)
			{
				pnl_Sale_Data.Visible = true;
				chk_Exclusive_Flag.Visible = true;
				cbo_ac_asking.SelectedIndex = 0;
			}
			else
			{
				pnl_Sale_Data.Visible = false;
				chk_Exclusive_Flag.Visible = false;
				txt_exclusive_verify_date.Visible = false;
				lbl_gen[11].Visible = false;
			}

			modFillAircraftControls.Fill_Aircraft_Status_List(cbo_ac_status, (int) chk_forsale.CheckState);

		}

		private void chkAwaitingDocs_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{

			if (chkAwaitingDocs.CheckState != CheckState.Unchecked)
			{
				lstManufacturer.Visible = false;
				cmdFindManufacturer.Visible = false;
				lblState.Visible = true;
				lblCountry.Visible = true;
				cboState.Visible = true;
				cboCountry.Visible = true;
			}
			else
			{
				lstManufacturer.Visible = true;
				cmdFindManufacturer.Visible = true;
				lblState.Visible = false;
				lblCountry.Visible = false;
				cboState.Visible = false;
				cboCountry.Visible = false;
			}

		}

		//UPGRADE_NOTE: (7001) The following declaration (Last_Journal_ID) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private string Last_Journal_ID(int inAC_ID)
		//{
			////
			//// PURPOSE: THE PURPOSE OF THIS FUNCTION IS TO CHECK TO SEE IF THE LAST TRANSACTION
			//// FOR THE AIRCRAFT IS A NEW TO MARKET IN ORDER TO DETERMINE
			//// IF THE CURRENT TRANSACTION BEING PROCESSED WILL MAKE THE AIRCRAFT
			//// BE CONSIDERED AS A "USED" AIRCRAFT.
			////
			//// LAST MODIFIED BY: RTW
			//// LAST MODIFIED ON: 3/30/2004
			//// *****************************************************************
			//string result = "";
			//
			//ADORecordSetHelper snp_Exist = new ADORecordSetHelper();
			//
			//string Query = "SELECT TOP 1 journ_id From Journal ";
			//Query = $"{Query}WHERE journ_ac_id = {inAC_ID.ToString()} ";
			//Query = $"{Query}AND (journ_subcategory_code='AA') ";
			//Query = $"{Query}ORDER BY journ_id DESC";
			//
			//
			//snp_Exist.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
			//if (!(snp_Exist.BOF && snp_Exist.EOF))
			//{
				//result = Convert.ToString(snp_Exist["journ_id"]);
			//}
			//else
			//{
			//}
			//snp_Exist.Close();
			//return result;
		//}
		private string Last_Journal_ID_New(int inAC_ID)
		{
			//
			// PURPOSE: THE PURPOSE OF THIS FUNCTION IS TO CHECK TO SEE IF THE LAST TRANSACTION
			// FOR THE AIRCRAFT IS A NEW TO MARKET IN ORDER TO DETERMINE
			// IF THE CURRENT TRANSACTION BEING PROCESSED WILL MAKE THE AIRCRAFT
			// BE CONSIDERED AS A "USED" AIRCRAFT.
			//
			// LAST MODIFIED BY: RTW
			// LAST MODIFIED ON: 3/30/2004
			// *****************************************************************
			string result = "";

			ADORecordSetHelper snp_Exist = new ADORecordSetHelper();

			string Query = "SELECT TOP 1 journ_id From Journal ";
			Query = $"{Query}WHERE journ_ac_id = {inAC_ID.ToString()} ";
			Query = $"{Query}AND (journ_subcategory_code='RN') ";
			Query = $"{Query}ORDER BY journ_id DESC";


			snp_Exist.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
			if (!(snp_Exist.BOF && snp_Exist.EOF))
			{
				result = Convert.ToString(snp_Exist["journ_id"]);
			}
			else
			{
			}
			snp_Exist.Close();
			return result;
		}
		private void cmd_override_Click(Object eventSender, EventArgs eventArgs)
		{

			int tempForEndVar = ac_product_chk.GetUpperBound(0);
			for (int X = 0; X <= tempForEndVar; X++)
			{
				ac_product_chk[X].Visible = true;
				ac_product_chk[X].Enabled = true;
			}


		}

		private void cmdCancel_Click(Object eventSender, EventArgs eventArgs) => this.Close();


		private void InsertAircraft()
		{

			string Query = "";
			string fields = "";
			StringBuilder Values = new StringBuilder();
			bool HasAlt = false;
			string Hyphen = "";
			int lAltSerNbrValue = 0;
			string serNumFull = ""; //aey 9/15/04
			string errMsg = "";
			string strErrDesc = "";
			int lErrNbr = 0;

			try
			{

				this.Cursor = CursorHelper.CursorDefault;
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Starting Insert Aircraft ...", Color.Blue);

				errMsg = "init";
				NewACID = GetNextACID();

				if (chkHyphen.CheckState == CheckState.Checked)
				{
					Hyphen = "-";
				}
				else
				{
					Hyphen = "";
				}

				errMsg = "Fields";
				Query = "INSERT INTO Aircraft (";

				fields = "ac_id, ";
				Values = new StringBuilder($"{NewACID.ToString()}, ");

				fields = $"{fields}ac_journ_id, ";
				Values.Append("0, ");

				fields = $"{fields}ac_amod_id, ";
				Values.Append($"{cbo_amod_make_name.GetItemData(cbo_amod_make_name.SelectedIndex).ToString()}, ");

				if (($"{txt_ac_ser_no_prefix.Text} ").Trim() != "")
				{
					fields = $"{fields}ac_ser_no_prefix, ";
					Values.Append($"'{($"{txt_ac_ser_no_prefix.Text} ").Trim()}', ");
				}
				if (($"{txt_ac_ser_no.Text} ").Trim() != "")
				{
					fields = $"{fields}ac_ser_no, ";
					Values.Append($"'{($"{txt_ac_ser_no.Text} ").Trim()}', ");

					fields = $"{fields}ac_ser_no_value, ";
					//UPGRADE_WARNING: (1068) GetSerNoValue() of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
					Values.Append($"{Convert.ToString(modCommon.GetSerNoValue(($"{txt_ac_ser_no.Text} ").Trim()))}, ");
				}
				if (($"{txt_ac_ser_no_suffix.Text} ").Trim() != "")
				{
					fields = $"{fields}ac_ser_no_suffix, ";
					Values.Append($"'{($"{txt_ac_ser_no_suffix.Text} ").Trim()}', ");
				}

				fields = $"{fields}ac_ser_no_full, ";
				Values.Append($"'{($"{txt_ac_ser_no_prefix.Text} ").Trim()}{Hyphen}{($"{txt_ac_ser_no.Text} ").Trim()}{($"{txt_ac_ser_no_suffix.Text} ").Trim()}', ");

				serNumFull = $"{($"{txt_ac_ser_no_prefix.Text} ").Trim()}{Hyphen}{($"{txt_ac_ser_no.Text} ").Trim()}{($"{txt_ac_ser_no_suffix.Text} ").Trim()}";

				fields = $"{fields}ac_ser_no_sort, ";
				Values.Append($"'{modCommon.Format_Ser_No_Sort(($"{txt_ac_ser_no_prefix.Text} ").Trim(), ($"{txt_ac_ser_no.Text} ").Trim(), ($"{txt_ac_ser_no_suffix.Text} ").Trim(), Airframe_Type_Code)}', ");

				HasAlt = false;
				if (($"{txt_ac_alt_ser_no_prefix.Text} ").Trim() != "")
				{
					fields = $"{fields}ac_alt_ser_no_prefix, ";
					Values.Append($"'{($"{txt_ac_alt_ser_no_prefix.Text} ").Trim()}', ");
					HasAlt = true;
				}
				if (($"{txt_ac_alt_ser_no.Text} ").Trim() != "")
				{
					fields = $"{fields}ac_alt_ser_no, ";
					Values.Append($"'{($"{txt_ac_alt_ser_no.Text} ").Trim()}', ");

					// 04/02/2004 - By David D. Cruger; Added the ac_alt_ser_no_value
					//UPGRADE_WARNING: (1068) GetSerNoValue() of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
					lAltSerNbrValue = Convert.ToInt32(modCommon.GetSerNoValue(($"{txt_ac_alt_ser_no.Text} ").Trim()));

					fields = $"{fields}ac_alt_ser_no_value, ";
					if (lAltSerNbrValue > 0)
					{
						Values.Append($"{lAltSerNbrValue.ToString()}, ");
					}
					else
					{
						Values.Append("Null, ");
					}

					HasAlt = true;
				}
				if (($"{txt_ac_alt_ser_no_suffix.Text} ").Trim() != "")
				{
					fields = $"{fields}ac_alt_ser_no_suffix, ";
					Values.Append($"'{($"{txt_ac_alt_ser_no_suffix.Text} ").Trim()}', ");
					HasAlt = true;
				}

				errMsg = "has alt";
				if (HasAlt)
				{
					// 04/02/2004 - By David D. Cruger
					// No Hyphen Variable Here.  On the AltSerNbr's that is controlled by the researcher
					// They must manually enter it in the prefix.
					fields = $"{fields}ac_alt_ser_no_full, ";
					Values.Append($"'{($"{txt_ac_alt_ser_no_prefix.Text} ").Trim()}{($"{txt_ac_alt_ser_no.Text} ").Trim()}{($"{txt_ac_alt_ser_no_suffix.Text} ").Trim()}', ");

					// 04/02/2004 - By David D. Cruger; Added the ac_alt_ser_no_sort
					fields = $"{fields}ac_alt_ser_no_sort, ";
					Values.Append($"'{modCommon.Format_Ser_No_Sort(($"{txt_ac_alt_ser_no_prefix.Text} ").Trim(), ($"{txt_ac_alt_ser_no.Text} ").Trim(), ($"{txt_ac_alt_ser_no_suffix.Text} ").Trim(), Airframe_Type_Code)}', ");
				}

				if (($"{txt_ac_reg_no.Text} ").Trim() != "")
				{
					fields = $"{fields}ac_reg_no, ";
					Values.Append($"'{($"{txt_ac_reg_no.Text} ").Trim()}', ");
					//3/17/06 aey
					fields = $"{fields}ac_reg_no_sort, ";
					Values.Append($"'{modCommon.Format_Reg_No_Sort($"{txt_ac_reg_no.Text} ")}', ");

					fields = $"{fields}ac_reg_no_search, ";
					Values.Append($"'{StringsHelper.Replace(StringsHelper.Replace(($"{txt_ac_reg_no.Text} ").Trim(), Hyphen, "", 1, -1, CompareMethod.Binary), "-", "", 1, -1, CompareMethod.Binary)}', ");
				}

				if (($"{txt_ac_prev_reg_no.Text} ").Trim() != "")
				{
					fields = $"{fields}ac_prev_reg_no, ";
					Values.Append($"'{($"{txt_ac_prev_reg_no.Text} ").Trim()}', ");
				}

				if (($"{txt_ac_mfr_year.Text} ").Trim() != "")
				{
					fields = $"{fields}ac_mfr_year, ";
					Values.Append($"'{($"{txt_ac_mfr_year.Text} ").Trim()}', ");
				}

				if (($"{txt_ac_year.Text} ").Trim() != "")
				{
					fields = $"{fields}ac_year, ";
					Values.Append($"'{($"{txt_ac_year.Text} ").Trim()}', ");
				}

				if (($"{Convert.ToString(txtBaseCode[0].Tag)} ").Trim() != "")
				{
					if (Information.IsNumeric(Convert.ToString(txtBaseCode[0].Tag)))
					{
						fields = $"{fields}ac_aport_id, ";
						Values.Append($"'{Convert.ToString(txtBaseCode[0].Tag).Trim()}', ");
					}
				}

				if (($"{txtBaseCode[0].Text} ").Trim() != "")
				{
					fields = $"{fields}ac_aport_iata_code, ";
					Values.Append($"'{($"{txtBaseCode[0].Text} ").Trim()}', ");
				}

				if (($"{txtBaseCode[1].Text} ").Trim() != "")
				{
					fields = $"{fields}ac_aport_icao_code, ";
					Values.Append($"'{($"{txtBaseCode[1].Text} ").Trim()}', ");
				}

				if (($"{txtBaseCode[2].Text} ").Trim() != "")
				{
					fields = $"{fields}ac_aport_name, ";
					Values.Append($"'{modAdminCommon.Fix_Quote($"{txtBaseCode[2].Text.Trim()} ")}', ");
				}

				if (($"{txtBaseCode[3].Text} ").Trim() != "")
				{
					fields = $"{fields}ac_aport_faaid_code, ";
					Values.Append($"'{($"{txtBaseCode[3].Text} ").Trim()}', ");
				}

				if (($"{cboBaseState.Text} ").Trim() != "")
				{
					fields = $"{fields}ac_aport_state, ";
					Values.Append($"'{($"{cboBaseState.Text} ").Trim()}', ");
				}

				if (($"{cboBaseCountry.Text} ").Trim() != "")
				{
					fields = $"{fields}ac_aport_country, ";
					Values.Append($"'{modAdminCommon.Fix_Quote(($"{cboBaseCountry.Text} ").Trim())}', ");
				}

				if (($"{txtBaseCode[5].Text} ").Trim() != "")
				{
					fields = $"{fields}ac_aport_city, ";
					Values.Append($"'{modAdminCommon.Fix_Quote(($"{txtBaseCode[5].Text} ").Trim())}', ");
				}

				fields = $"{fields}ac_previously_owned_flag, ";
				if (chk_ac_previously_owned_flag.CheckState == CheckState.Unchecked)
				{
					Values.Append("'N', ");
				}
				else
				{
					Values.Append("'Y', ");
				}

				if (cbo_ac_country_of_registration.Text.Trim() != "")
				{
					fields = $"{fields}ac_country_of_registration, ";
					Values.Append($"'{modAdminCommon.Fix_Quote(cbo_ac_country_of_registration.Text)}', ");
				}

				if (chk_ac_aport_private.CheckState == CheckState.Checked)
				{
					fields = $"{fields}ac_aport_private, ";
					Values.Append("'Y', ");
				}

				fields = $"{fields}ac_forsale_flag, ";
				if (chk_forsale.CheckState == CheckState.Checked)
				{
					Values.Append("'Y', ");
				}
				else
				{
					Values.Append("'N', ");
				}

				if (chk_Exclusive_Flag.CheckState == CheckState.Checked)
				{
					fields = $"{fields}ac_exclusive_flag, ";
					Values.Append("'Y', ");
				}

				if (($"{txt_exclusive_verify_date.Text} ").Trim() != "")
				{
					fields = $"{fields}ac_exclusive_verify_date, ";
					System.DateTime TempDate2 = DateTime.FromOADate(0);
					Values.Append($"'{((DateTime.TryParse(($"{txt_exclusive_verify_date.Text} ").Trim(), out TempDate2)) ? TempDate2.ToString("MM/dd/yyyy") : ($"{txt_exclusive_verify_date.Text} ").Trim())}', ");
				}

				if (($"{cbo_ac_status.Text} ").Trim() != "")
				{
					fields = $"{fields}ac_status, ";
					Values.Append($"'{($"{cbo_ac_status.Text} ").Trim()}', ");
				}

				if (txt_ac_purchase_date.Text.Trim() != "")
				{
					fields = $"{fields}ac_purchase_date, ";
					System.DateTime TempDate3 = DateTime.FromOADate(0);
					Values.Append($"'{((DateTime.TryParse(($"{txt_ac_purchase_date.Text} ").Trim(), out TempDate3)) ? TempDate3.ToString("MM/dd/yyyy") : ($"{txt_ac_purchase_date.Text} ").Trim())}', ");
				}

				if (($"{cbo_ac_stage.Text} ").Trim() != "")
				{
					fields = $"{fields}ac_lifecycle_stage, ";
					Values.Append($"'{($"{cbo_ac_stage.Text.Substring(0, Math.Min(cbo_ac_stage.Text.IndexOf('-'), cbo_ac_stage.Text.Length))} ").Trim()}', ");
				}

				if (($"{cbo_ac_owner_type.Text} ").Trim() != "")
				{
					fields = $"{fields}ac_ownership_type, ";
					Values.Append($"'{($"{cbo_ac_owner_type.Text.Substring(0, Math.Min(cbo_ac_owner_type.Text.IndexOf('-'), cbo_ac_owner_type.Text.Length))} ").Trim()}', ");
				}

				if (($"{cbo_ac_delivery.Text} ").Trim() != "")
				{
					fields = $"{fields}ac_delivery, ";
					Values.Append($"'{($"{cbo_ac_delivery.Text} ").Trim()}', ");
				}

				if (($"{txt_ac_delivery_date.Text} ").Trim() != "")
				{
					fields = $"{fields}ac_delivery_date, ";
					System.DateTime TempDate4 = DateTime.FromOADate(0);
					Values.Append($"'{((DateTime.TryParse(($"{txt_ac_delivery_date.Text} ").Trim(), out TempDate4)) ? TempDate4.ToString("MM/dd/yyyy") : ($"{txt_ac_delivery_date.Text} ").Trim())}', ");
				}

				if (chk_forsale.CheckState == CheckState.Checked)
				{
					if (($"{cbo_ac_asking.Text} ").Trim() != "")
					{
						fields = $"{fields}ac_asking, ";
						Values.Append($"'{($"{cbo_ac_asking.Text} ").Trim()}', ");
					}
				}

				if (($"{txt_ac_asking_price.Text} ").Trim() != "")
				{
					fields = $"{fields}ac_asking_price, ";
					Values.Append($"{StringsHelper.Format(($"{txt_ac_asking_price.Text} ").Trim(), "#####")}, ");
				}

				if (($"{txt_ac_list_date.Text} ").Trim() != "")
				{
					fields = $"{fields}ac_list_date, ";
					System.DateTime TempDate5 = DateTime.FromOADate(0);
					Values.Append($"'{((DateTime.TryParse(($"{txt_ac_list_date.Text} ").Trim(), out TempDate5)) ? TempDate5.ToString("MM/dd/yyyy") : ($"{txt_ac_list_date.Text} ").Trim())}', ");
				}

				if (($"{cbo_ac_foreign_currency_name.Text} ").Trim() != "")
				{
					fields = $"{fields}ac_foreign_currency_name, ";
					Values.Append($"'{($"{cbo_ac_foreign_currency_name.Text} ").Trim()}', ");
				}

				if (($"{txt_ac_foreign_currency_price.Text} ").Trim() != "")
				{
					fields = $"{fields}ac_foreign_currency_price, ";
					Values.Append($"{($"{txt_ac_foreign_currency_price.Text} ").Trim()}, ");
				}

				if (($"{txt_ac_engine_tbo_hrs[0].Text} ").Trim() != "")
				{


					if (Information.IsNumeric(txt_ac_engine_tbo_hrs[0].Text))
					{
						fields = $"{fields}ac_engine_1_tbo_hrs, ";
						if (StringsHelper.ToDoubleSafe(txt_ac_engine_tbo_hrs[0].Text) > 0)
						{
							Values.Append($"{StringsHelper.Format(($"{txt_ac_engine_tbo_hrs[0].Text} ").Trim(), "######")}, ");
						}
						else
						{
							Values.Append("0, ");
						}

					}

				}
				if (($"{txt_ac_engine_tbo_hrs[1].Text} ").Trim() != "")
				{
					fields = $"{fields}ac_engine_2_tbo_hrs, ";
					Values.Append($"{StringsHelper.Format(($"{txt_ac_engine_tbo_hrs[1].Text} ").Trim(), "######")}, ");
				}
				if (($"{txt_ac_engine_tbo_hrs[2].Text} ").Trim() != "")
				{
					fields = $"{fields}ac_engine_3_tbo_hrs, ";
					Values.Append($"{StringsHelper.Format(($"{txt_ac_engine_tbo_hrs[2].Text} ").Trim(), "######")}, ");
				}
				if (($"{txt_ac_engine_tbo_hrs[3].Text} ").Trim() != "")
				{
					fields = $"{fields}ac_engine_4_tbo_hrs, ";
					Values.Append($"{StringsHelper.Format(($"{txt_ac_engine_tbo_hrs[3].Text} ").Trim(), "######")}, ");
				}

				if (chk_oncondtbo.CheckState == CheckState.Checked)
				{
					fields = $"{fields}ac_engine_tbo_oc_flag, ";
					Values.Append("'Y', ");
				}

				if (($"{cbo_ac_engine_name.Text} ").Trim() != "")
				{
					fields = $"{fields}ac_engine_name, ";
					Values.Append($"'{($"{cbo_ac_engine_name.Text} ").Trim()}', ");
					fields = $"{fields}ac_engine_name_search, ";
					Values.Append($"'{StringsHelper.Replace(($"{cbo_ac_engine_name.Text} ").Trim(), modGlobalVars.cHyphen, modGlobalVars.cEmptyString, 1, -1, CompareMethod.Binary)}', ");
				}

				if (($"{txt_model_config.Text} ").Trim() != "")
				{ //4/10/2006 aey
					fields = $"{fields}ac_model_config, ";
					Values.Append($"'{StringsHelper.Replace(($"{txt_model_config.Text} ").Trim(), "'", "", 1, -1, CompareMethod.Binary)}', ");
				}

				if (($"{txt_engine_noise_rating.Text} ").Trim() != "")
				{ //4/10/2006 aey
					fields = $"{fields}ac_engine_noise_rating, ";
					Values.Append($"{($"{txt_engine_noise_rating.Text} ").Trim()}, ");
				}

				fields = $"{fields}ac_ent_user_id, ";
				Values.Append($"'{modAdminCommon.gbl_User_ID}', ");

				fields = $"{fields}ac_use_code, "; //6/2/05 aey
				Values.Append($"'{cbo_usage.Text.Substring(0, Math.Min(1, cbo_usage.Text.Length))}', ");

				fields = $"{fields}ac_ent_date, ";
				Values.Append($"'{StringsHelper.Format(DateTime.Now, "mm/dd/yyyy hh:mm:ss AM/PM")}', ");
				// add the checks for product codes

				int tempForEndVar = ac_product_chk.GetUpperBound(0);
				for (int X = 0; X <= tempForEndVar; X++)
				{


					switch((X))
					{
						case modGlobalVars.CHK_BUSINESS_IDX : 
							if (ac_product_chk[X].CheckState == CheckState.Checked)
							{
								fields = $"{fields}ac_product_business_flag, ";
								Values.Append("'Y', ");
							} 
							break;
						case modGlobalVars.CHK_HELICOPTER_IDX : 
							if (ac_product_chk[X].CheckState == CheckState.Checked)
							{
								fields = $"{fields}ac_product_helicopter_flag, ";
								Values.Append("'Y', ");
							} 
							break;
						case modGlobalVars.CHK_COMMERCIAL_IDX : 
							if (ac_product_chk[X].CheckState == CheckState.Checked)
							{
								fields = $"{fields}ac_product_commercial_flag, ";
								Values.Append("'Y', ");
							} 
							break;
						case modGlobalVars.CHK_ABI_IDX : case modGlobalVars.CHK_REGIONAL_IDX : 
							// Nothing At This Time 
							break;
						case modGlobalVars.CHK_AIRBP_IDX : 
							if (ac_product_chk[X].CheckState == CheckState.Checked)
							{
								fields = $"{fields}ac_product_airbp_flag, ";
								Values.Append("'Y', ");
							} 
							break;
						default:
							 
							goto exit_for; 
							 
							break;
					}

				}
				exit_for:

				Query = $"{Query}{fields.Substring(0, Math.Min(Strings.Len(fields) - 2, fields.Length))}) VALUES ({Values.ToString()}";
				Query = $"{Query.Substring(0, Math.Min(Strings.Len(Query) - 2, Query.Length))})";
				errMsg = "insert";

				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Begin Transaction ...", Color.Blue);


				// ******************************************
				// BEGIN THE TRANSACTION
				//
				modAdminCommon.ADO_Transaction("BeginTrans");

				// INSERT THE NEW AIRCRAFT
				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();

				modAdminCommon.gbl_Aircraft_ID = NewACID;

				// MAKE SURE THAT THE AIRCRAFT HAS AN OWNER
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Associate MFG ...", Color.Blue);

				AssociateManufacturer();

				// ADD THE AIRCRAFT FEATURE CODES
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Inserting Feature Codes ...", Color.Blue);

				InsertFeatureCodes();

				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Inserting Journal Note ...", Color.Blue);

				InsertNewACJournalNote();

				//prepare record for JFW - aey 9/14/04
				errMsg = "redim";
				if (chkAwaitingDocs.CheckState == CheckState.Unchecked)
				{
					comp_id = lstManufacturer.GetItemData(0);
				}
				else
				{
					comp_id = GetAwaitDocsCompID();
				}

				arr_Transmit_Fields = new string[]{""};
				arr_Transmit_Fields[0] = "";


				errMsg = "transmit";

				// ********************************************
				// RECORD A NEW AIRCRAFT OWNER FILE TRANSMIT
				modAdminCommon.Record_Transmit(serNumFull, NewACID, 0, cbo_amod_make_name.GetItemData(cbo_amod_make_name.SelectedIndex), "Aircraft", "Add", ref arr_Transmit_Fields, comp_id);

				// **************************************************
				//  IF THE NEW AIRCRAFT IS FOR SALE THEN RECORD AN AVAILABE TRANSMIT
				if (chk_forsale.CheckState == CheckState.Checked)
				{
					modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Writing Transmit record ...", Color.Blue);

					modAdminCommon.Record_Transmit(serNumFull, NewACID, 0, cbo_amod_make_name.GetItemData(cbo_amod_make_name.SelectedIndex), "Available", "Add", ref arr_Transmit_Fields, comp_id);
				}

				//==============================================
				// 5/1/2003 Keith Humpf
				// We need to store a "Reassign" so the researcher
				// will get this new aircraft on their list
				// (per Laurie)
				//==============================================

				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Saving Reassign ...", Color.Blue);

				// COMMIT THE TRANSACTION
				modAdminCommon.ADO_Transaction("CommitTrans");


				Insert_EventLog_On_Add_Delete_AC("AddAC", NewACID);

				// -- ADDED MSW - per request - 5/17/19
				string temp_journ_id = "";
				temp_journ_id = Last_Journal_ID_New(modAdminCommon.gbl_Aircraft_ID);

				//gbl_Aircraft_ID
				frm_Journal.DefInstance.Reference_Journal_ID = Convert.ToInt32(Double.Parse(temp_journ_id));
				frm_Journal.DefInstance.Reference_Comp_Id = 0;
				frm_Journal.DefInstance.Reference_Contact_Id = 0;
				frm_Journal.DefInstance.ShowDialog();
				// **************************************
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Building Stats ...", Color.Blue);

				modCommon.Company_Stats_Update(comp_id); //aey 6/23/05

				bInsertedAircraft = true;

				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
				this.Cursor = CursorHelper.CursorDefault;
				// note that no transmit is done for this per Dave Cruger
				if (MessageBox.Show($"Insert Successful. {Environment.NewLine}{Environment.NewLine}Would you like to add another aircraft?", "Insert Successful", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
				{
					cmdCancel_Click(cmdCancel, new EventArgs());
				}
				else
				{
					ResetForm();
					txt_ac_ser_no.Focus();
				}
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr = Information.Err().Number;
				strErrDesc = strErrDesc;

				// 06/30/2008 - By David D. Cruger
				// Rollback Should Be Before the MsgBox
				ErrorHandlingHelper.ResumeNext(
					() => {modAdminCommon.ADO_Transaction("RollbackTrans");}, 

					() => {this.Cursor = CursorHelper.CursorDefault;}, 
					() => {modStatusBar.Clear_Status_Bar(modAdminCommon.SB);}, 

					() => {Information.Err().Number = lErrNbr;}, 
					() => {Information.Err().Description = strErrDesc;}, 

					() => {modAdminCommon.Record_Error("InsertAircraft_Error: ", strErrDesc);}, 

					() => {MessageBox.Show($"Error Inserting Aircraft: {Environment.NewLine}{strErrDesc}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));});
			}

		}
		public void Insert_EventLog_On_Add_Delete_AC(string type_of, int AC_ID)
		{

			ADORecordSetHelper snpACSelect = new ADORecordSetHelper();
			string temp_make_name = "";
			string temp_model_name = "";
			string temp_ac_amod_id = "";
			string temp_ser_no = "";

			string Query = "SELECT amod_make_name, amod_model_name, ac_amod_id, ac_ser_no_full";
			Query = $"{Query} FROM Aircraft WITH(NOLOCK) ";
			Query = $"{Query} INNER JOIN Aircraft_Model WITH(NOLOCK) ON  amod_id = ac_amod_id";
			Query = $"{Query} WHERE ac_id = {AC_ID.ToString()}";

			snpACSelect.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

			if (!(snpACSelect.BOF && snpACSelect.EOF))
			{
				temp_make_name = Convert.ToString(snpACSelect["amod_make_name"]);
				temp_model_name = Convert.ToString(snpACSelect["amod_model_name"]);
				temp_ac_amod_id = Convert.ToString(snpACSelect["ac_amod_id"]);
				temp_ser_no = Convert.ToString(snpACSelect["ac_ser_no_full"]);
			}

			snpACSelect.Close();
			snpACSelect = null;


			string Query2 = "INSERT INTO Eventlog ";
			Query2 = $"{Query2} ( ";
			Query2 = $"{Query2}evtl_date, evtl_user_id, evtl_type, evtl_message, evtl_ac_id, evtl_journ_id";
			Query2 = $"{Query2} ) VALUES (";
			Query2 = $"{Query2}'{DateTimeHelper.ToString(DateTime.Today)} {DateTimeHelper.ToString(DateTimeHelper.Time)}',"; // date
			Query2 = $"{Query2}'{modAdminCommon.gbl_User_ID}',"; // user id
			Query2 = $"{Query2}'{type_of}',"; // type
			Query2 = $"{Query2}'Model: {temp_make_name} {temp_model_name}- Ser No: {temp_ser_no}',"; // message
			Query2 = $"{Query2}{AC_ID.ToString()},"; // ac_id
			Query2 = $"{Query2}0"; // journ_id
			Query2 = $"{Query2} ) ";

			DbCommand TempCommand = null;
			TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
			UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
			TempCommand.CommandText = Query2;
			UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
			TempCommand.ExecuteNonQuery();


		}

		private void AssociateManufacturer()
		{

			string BusinessType = "";
			int comp_id = 0; //aey 6/23/05

			if (chkAwaitingDocs.CheckState == CheckState.Unchecked)
			{
				BusinessType = modCommon.GetBusinessTypeToUse(lstManufacturer.GetItemData(0), 0);
				comp_id = lstManufacturer.GetItemData(0);
			}
			else
			{
				comp_id = GetAwaitDocsCompID();
				BusinessType = modCommon.GetBusinessTypeToUse(comp_id, 0);
			}

			string Query = "INSERT INTO Aircraft_Reference (";
			Query = $"{Query}cref_ac_id, cref_journ_id, cref_comp_id, cref_contact_id, cref_primary_poc_flag, cref_contact_type, cref_business_type, cref_transmit_seq_no, cref_owner_percent,cref_operator_flag";
			Query = $"{Query}) VALUES (";
			Query = $"{Query}{modAdminCommon.gbl_Aircraft_ID.ToString()}, ";
			Query = $"{Query}0, ";

			if (chkAwaitingDocs.CheckState == CheckState.Unchecked)
			{
				Query = $"{Query}{comp_id.ToString()}, ";
				Query = $"{Query}{FoundContactID.ToString()}, ";
			}
			else
			{
				Query = $"{Query}{comp_id.ToString()}, ";
				Query = $"{Query}0, ";
			}

			if (chk_Exclusive_Flag.CheckState != CheckState.Unchecked)
			{
				Query = $"{Query}'X', ";
			}
			else
			{
				Query = $"{Query}'Y', ";
			}
			Query = $"{Query}'00', ";
			if (BusinessType.Trim() == modGlobalVars.cEmptyString)
			{
				BusinessType = "UI-";
			}

			Query = $"{Query}'{BusinessType.Substring(0, Math.Min(BusinessType.IndexOf('-'), BusinessType.Length)).Trim()}', ";
			Query = $"{Query}1,0,'N')";

			DbCommand TempCommand = null;
			TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
			UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
			TempCommand.CommandText = Query;
			//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
			TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
			UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
			TempCommand.ExecuteNonQuery();

		}

		private int GetAwaitDocsCompID()
		{

			//******************************************************************************************
			//
			// PURPOSE: THE PURPOSE OF THIS FUNCTION IS TO INSERT A NEW AWAITING DOCUMENTS
			//          COMPANY RECORD AND SUPPORTING BUSINESS TYPE RECORD AND PRODUCT CODE.
			//
			// MODIFIED: MJM - 03/06/09 - made similar to Transaction_Create_Awaiting_Documentation_Company, and GetAwaitDocsCompID
			//******************************************************************************************

			int result = 0;
			string Query = "";
			ADORecordSetHelper snpMaxComp = null;
			int MaxId = 0;
			string ProdCode = "";

			try
			{

				if (!bHasMaxCompID)
				{
					Query = "SELECT max(comp_id) as MaxCompID FROM Company WITH(NOLOCK)";
					snpMaxComp = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snpMaxComp["MaxCompID"]))
					{
						result = Convert.ToInt32(snpMaxComp["MaxCompID"]) + 1;
						bHasMaxCompID = true;
						snpMaxComp.Close();
					}
					snpMaxComp = null;

				}
				else
				{
					Query = "SELECT max(comp_id) as MaxCompID FROM Company WITH(NOLOCK)";
					snpMaxComp = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snpMaxComp["MaxCompID"]))
					{
						result = Convert.ToInt32(snpMaxComp["MaxCompID"]);
						snpMaxComp.Close();
					}
					snpMaxComp = null;
					return result;
				}

				if (result == 0)
				{
					return result;
				}

				Query = "INSERT INTO Company (comp_id, comp_journ_id, comp_name, comp_name_search, comp_state, comp_country, comp_awaitdoc_flag, ";
				Query = $"{Query}comp_assign_flag, comp_account_id, comp_business_type, comp_account_type, comp_ent_user_id, ";
				Query = $"{Query}comp_ent_date, comp_active_flag, comp_action_date, comp_product_business_flag, comp_product_helicopter_flag) VALUES (";
				Query = $"{Query}{result.ToString()}";
				Query = $"{Query}, 0";
				Query = $"{Query}, 'Awaiting Documentation'";
				Query = $"{Query}, 'AWAITINGDOCUMENTATION'";

				if (cboState.Text.Trim() != modGlobalVars.cEmptyString)
				{
					Query = $"{Query}, '{cboState.Text.Trim().Substring(0, Math.Min(2, cboState.Text.Trim().Length)).ToUpper()}'";
				}
				else
				{
					Query = $"{Query},NULL";
				}

				if (cboCountry.Text.Trim() != modGlobalVars.cEmptyString)
				{
					Query = $"{Query}, '{cboCountry.Text.Trim()}'";
				}
				else
				{
					Query = $"{Query},NULL";
				}

				Query = $"{Query},'Y','M','ID03','EU','UI','{modAdminCommon.gbl_User_ID}','{DateTime.Now.ToString()}','Y'";
				// IDBC to ID01 Account rep change mjm 8/9/06

				if (Airframe_Type_Code == "H")
				{
					Query = $"{Query},NULL,'N','Y')";
				}
				else
				{
					Query = $"{Query},NULL,'Y','N')";
				}
				//comp_product_business_flag, comp_product_helicopter_flag mjm 1/30/09

				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery(); //aey 7/16/04 converted to ado

				// hack - keep untill new company_product_codes table is not needed
				ProdCode = "B";
				if (Airframe_Type_Code == "H")
				{
					ProdCode = "H";
				}

				Query = "INSERT INTO Business_Type_Reference (bustypref_comp_id, bustypref_journ_id, bustypref_type, bustypref_seq_no) ";
				Query = $"{Query}Values ({result.ToString()},0,'EU',1) ";
				DbCommand TempCommand_2 = null;
				TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
				TempCommand_2.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand_2.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
				TempCommand_2.ExecuteNonQuery(); //aey 7/29/05

				modCommon.Company_Stats_Update(result);

				return result;
			}
			catch
			{

				result = 0;
				modAdminCommon.Report_Error($"GetAwaitDocsCompID_error: CompId[{result.ToString()}]");
				return result;
			}
		}

		private bool ValidForInsert()
		{

			bool result = false;
			bool bHasProductCode = false;

			string Hyphen = "";

			if (chkHyphen.CheckState == CheckState.Checked)
			{
				Hyphen = "-";
			}

			result = true;

			if (!(lstManufacturer.Items.Count > 0 || chkAwaitingDocs.CheckState == CheckState.Checked))
			{
				MessageBox.Show("You must choose an Owner", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				return false;
			}

			if (cbo_amod_make_name.SelectedIndex < 0)
			{
				MessageBox.Show("You must select a Make/Model", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				cbo_amod_make_name.Focus();
				return false;
			}

			if (txt_exclusive_verify_date.Text.Trim() != "")
			{
				if (!Information.IsDate(txt_exclusive_verify_date.Text.Trim()))
				{
					MessageBox.Show("Next Exclusive Verify Date must be a date value (mm/dd/yyyy)", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					txt_exclusive_verify_date.Focus();
					return false;
				}
			}

			if (txt_ac_asking_price.Text.Trim() != "")
			{
				if (!Information.IsNumeric(txt_ac_asking_price.Text.Trim()))
				{
					MessageBox.Show("Asking Price must be a number", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					txt_ac_asking_price.Focus();
					return false;
				}
			}

			if (txt_ac_list_date.Text.Trim() != "")
			{
				if (!Information.IsDate(txt_ac_list_date.Text.Trim()))
				{
					MessageBox.Show("Date Listed must be a date value (mm/dd/yyyy)", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					txt_ac_list_date.Focus();
					return false;
				}
			}

			if (txt_ac_foreign_currency_price.Text.Trim() != "")
			{
				if (!Information.IsNumeric(txt_ac_foreign_currency_price.Text.Trim()))
				{
					MessageBox.Show("Foreign Currency Price must be a number", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					txt_ac_foreign_currency_price.Focus();
					return false;
				}
			}

			if (txt_ac_delivery_date.Text.Trim() != "")
			{
				if (!Information.IsDate(txt_ac_delivery_date.Text.Trim()))
				{
					MessageBox.Show("Delivery Date must be a date value (mm/dd/yyyy)", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					txt_ac_delivery_date.Focus();
					return false;
				}
			}

			if (txt_ac_purchase_date.Text.Trim() != "")
			{
				if (!Information.IsDate(txt_ac_purchase_date.Text.Trim()))
				{
					MessageBox.Show("Date Purchased must be a date value (mm/dd/yyyy)", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					txt_ac_purchase_date.Focus();
					return false;
				}
			}

			if (txt_ac_ser_no_prefix.Text.Trim() == "" && txt_ac_ser_no.Text.Trim() == "" && txt_ac_ser_no_suffix.Text.Trim() == "")
			{
				MessageBox.Show("Aircraft Must Have a Serial Number", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txt_ac_ser_no.Focus();
				return false;
			}

			string Query = $"SELECT ac_id FROM Aircraft WHERE ac_journ_id=0 and ac_ser_no_full = '{txt_ac_ser_no_prefix.Text.Trim()}{Hyphen}{txt_ac_ser_no.Text.Trim()}{txt_ac_ser_no_suffix.Text.Trim()}' AND ac_amod_id = {Conversion.Val(cbo_amod_make_name.GetItemData(cbo_amod_make_name.SelectedIndex).ToString().Trim()).ToString()}";
			if (modAdminCommon.Exist(Query))
			{
				MessageBox.Show("Serial Number Already Exists for this Model", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txt_ac_ser_no.Focus();
				return false;
			}

			if (txt_ac_reg_no.Text.Trim() != "")
			{
				if (Strings.Len(txt_ac_reg_no.Text.Trim()) > 1)
				{ // added MSW - 2/1/22
					if (Strings.Len(StringsHelper.Replace(txt_ac_reg_no.Text.Trim(), "-", "", 1, -1, CompareMethod.Binary)) > 2)
					{ // added MSW - 1/24 - make sure length > 2

						if (modCommon.RegNoDuplicate(txt_ac_reg_no.Text.Trim(), ""))
						{
							if (MessageBox.Show($"Registration Number already exists{Environment.NewLine}{Environment.NewLine}Do you still want to Save this Aircraft?", "Registration Number Exists", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
							{
								txt_ac_reg_no.Focus();
								return false;
							}
						}
					}
				}

			}

			if (txt_ac_mfr_year.Text.Trim() == "" && txt_ac_year.Text.Trim() == "")
			{
				MessageBox.Show("Aircraft Must Have a Year Mfg OR Year Delivered", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txt_ac_mfr_year.Focus();
				return false;
			}

			if (!(Information.IsNumeric(txt_ac_engine_tbo_hrs[0].Text) || txt_ac_engine_tbo_hrs[0].Text == ""))
			{
				result = false;
				MessageBox.Show("Engine 1 TBO hours must be numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txt_ac_engine_tbo_hrs[0].Focus();
			}

			if (!(Information.IsNumeric(txt_ac_engine_tbo_hrs[1].Text) || txt_ac_engine_tbo_hrs[1].Text == ""))
			{
				result = false;
				MessageBox.Show("Engine 2 TBO hours must be numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txt_ac_engine_tbo_hrs[1].Focus();
			}

			if (!(Information.IsNumeric(txt_ac_engine_tbo_hrs[2].Text) || txt_ac_engine_tbo_hrs[2].Text == ""))
			{
				result = false;
				MessageBox.Show("Engine 3 TBO hours must be numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txt_ac_engine_tbo_hrs[2].Focus();
			}

			if (!(Information.IsNumeric(txt_ac_engine_tbo_hrs[3].Text) || txt_ac_engine_tbo_hrs[3].Text == ""))
			{
				result = false;
				MessageBox.Show("Engine 4 TBO hours must be numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txt_ac_engine_tbo_hrs[3].Focus();
			}

			int tempForEndVar = ac_product_chk.GetUpperBound(0);
			for (int X = 0; X <= tempForEndVar; X++)
			{
				SSPanel_productCode.BorderStyle = BorderStyle.None;

				switch((X))
				{
					case modGlobalVars.CHK_BUSINESS_IDX : case modGlobalVars.CHK_HELICOPTER_IDX : case modGlobalVars.CHK_COMMERCIAL_IDX : case modGlobalVars.CHK_AIRBP_IDX : 
						if (ac_product_chk[X].CheckState == CheckState.Checked)
						{
							bHasProductCode = true;
						} 
						break;
					default:
						 
						goto exit_for; 
						 
						break;
				}

			}
			exit_for:

			if (!bHasProductCode)
			{

				MessageBox.Show($"** NO PRODUCT CODE SELECTED **{Environment.NewLine}Aircraft can't be SAVED untill a PRODUCT CODE is chosen!", "NO PRODUCT CODE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				SSPanel_productCode.BorderStyle = BorderStyle.FixedSingle;
				result = false;

			}

			return result;
		}

		private int GetNextACID()
		{

			int result = 0;
			ADORecordSetHelper snpAC = new ADORecordSetHelper();

			result = 1;

			string Query = "SELECT MAX(ac_id) AS maxID FROM Aircraft WITH(NOLOCK) ";

			snpAC.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

			if (!(snpAC.BOF && snpAC.EOF))
			{
				result = Convert.ToInt32(Convert.ToDouble(snpAC["MaxId"]) + 1);
			}

			snpAC.Close();

			return result;
		}

		private void cmdFindManufacturer_Click(Object eventSender, EventArgs eventArgs)
		{

			tCompFind_ActionTypes = modGlobalVars.e_find_form_action_types.geGetManufacturer;

			if (modGlobalVars.bCallShowAndLoadOnlyOnce)
			{

				//UPGRADE_TODO: (1067) Member Clear_Search_Criteria is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_MISC].Clear_Search_Criteria(true, true, true);
				//UPGRADE_TODO: (1067) Member EntryPoint is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_MISC].EntryPoint = modGlobalVars.e_find_form_entry_points.geFindManufacturer;
				//UPGRADE_TODO: (1067) Member ActionTypes is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_MISC].ActionTypes =tCompFind_ActionTypes;

				//UPGRADE_TODO: (1067) Member txt_company_id is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_MISC].txt_company_id[0].Text = MFR_Comp_id.ToString();
				//UPGRADE_TODO: (1067) Member opt_contacts is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_MISC].opt_contacts.Checked = true;
				//UPGRADE_TODO: (1067) Member cmd_find_Click is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_MISC].cmd_find_Click(null,null);
				//UPGRADE_TODO: (1067) Member Show is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_MISC].Show();
				//UPGRADE_TODO: (1067) Member ZOrder is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_MISC].ZOrder(0);

			}

		}

		private void FillManufacturerList()
		{

			ADORecordSetHelper snpMFG = new ADORecordSetHelper();

			lstManufacturer.Items.Clear();

			string Query = "SELECT comp_name, comp_address1, comp_address2, comp_city, comp_state, comp_zip_code ";
			Query = $"{Query}FROM Company WITH(NOLOCK) WHERE (comp_id = {FoundCompanyID.ToString()} AND comp_journ_id = 0) ";

			snpMFG.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

			if (!(snpMFG.BOF && snpMFG.EOF) && FoundCompanyID > 0)
			{
				lstManufacturer.AddItem(($"{Convert.ToString(snpMFG["comp_name"])}").Trim());
				lstManufacturer.AddItem(($"{Convert.ToString(snpMFG["comp_address1"])}").Trim());
				if (($"{Convert.ToString(snpMFG["Comp_address2"])}").Trim() != "")
				{
					lstManufacturer.AddItem(($"{Convert.ToString(snpMFG["Comp_address2"])}").Trim());
				}
				lstManufacturer.AddItem($"{($"{Convert.ToString(snpMFG["Comp_city"])}").Trim()}, {($"{Convert.ToString(snpMFG["comp_state"])}").Trim()} {($"{Convert.ToString(snpMFG["Comp_zip_code"])}").Trim()}");
				lstManufacturer.SetItemData(0, FoundCompanyID);
			}

			snpMFG.Close();

		}
		private void cmdSave_Click(Object eventSender, EventArgs eventArgs)
		{

			bIsValidForInsert = ValidForInsert();

			if (bIsValidForInsert)
			{
				InsertAircraft();
			}

		}

		private void Form_Initialize()
		{

			FirstLoad = true;
			tCompFind_EntryPoints = modGlobalVars.e_find_form_entry_points.geNoEntryPoint;
			bHasMaxCompID = false;

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
		private void Form_Load()
		{

			bInsertedAircraft = false;
			bIsValidForInsert = false;

			FoundCompanyID = 0;
			FoundContactID = 0;
			bHasMaxCompID = false;

			modFillAircraftControls.Fill_Aircraft_Usage_List(cbo_usage);
			cbo_usage.SelectedText = "N - New";

		}

		private void Form_Activated(Object eventSender, EventArgs eventArgs)
		{
			if (ActivateHelper.myActiveForm != eventSender)
			{
				ActivateHelper.myActiveForm = (Form) eventSender;

				SetupSerialNumbers();



				if (FirstLoad)
				{
					ResetForm();
					FirstLoad = false;
				}

				FoundCompanyID = 0;
				FoundContactID = 0;
				bHasMaxCompID = false;

				SSPanel_productCode.BorderStyle = BorderStyle.None;

				//UPGRADE_TODO: (1067) Member EntryPoint is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				tCompFind_EntryPoints = (modGlobalVars.e_find_form_entry_points) Convert.ToInt32(modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_MISC].EntryPoint);

				if (modCommon.pubf_EncodeEntryPoints(tCompFind_EntryPoints) == modGlobalVars.gFIND_FDMF)
				{

					//UPGRADE_TODO: (1067) Member GetFormExitValues is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					FoundCompanyID = Convert.ToInt32(modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_MISC].GetFormExitValues(modGlobalVars.gcFOUNDAIRCRAFTCOMPID));
					//UPGRADE_TODO: (1067) Member GetFormExitValues is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					FoundContactID = Convert.ToInt32(modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_MISC].GetFormExitValues(modGlobalVars.gcFOUNDCONTACTID));

					if (modCommon.pubf_EncodeEntryPoints(tCompFind_EntryPoints) == modGlobalVars.gFIND_FDMF && FoundCompanyID > 0)
					{
						FillManufacturerList();
						//UPGRADE_TODO: (1067) Member Clear_Search_Criteria is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_MISC].Clear_Search_Criteria(true, true, true);
					}

				}

			}
		}

		private void GetACType(int PassedModelID)
		{

			ADORecordSetHelper snpMakeModel = new ADORecordSetHelper();

			txt_amod_type_code.Text = "";

			string Query = "SELECT atype_code, atype_name, amod_airframe_type_code";
			Query = $"{Query} FROM Aircraft_Model WITH(NOLOCK) INNER JOIN Aircraft_Type WITH(NOLOCK) ON amod_type_code = atype_code";
			Query = $"{Query} WHERE (amod_id = {PassedModelID.ToString()}) ";

			snpMakeModel.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

			if (!(snpMakeModel.BOF && snpMakeModel.EOF))
			{
				txt_amod_type_code.Text = $"{($"{Convert.ToString(snpMakeModel["atype_code"])}").Trim()} - {($"{Convert.ToString(snpMakeModel["atype_name"])}").Trim()} - {($"{Convert.ToString(snpMakeModel["amod_airframe_type_code"])}").Trim()}";
			}

			snpMakeModel.Close();

		}

		private void ResetForm()
		{


			this.Cursor = Cursors.WaitCursor;

			bHasMaxCompID = false;

			DialogResult Ans = System.Windows.Forms.DialogResult.Yes;
			if (!FirstLoad)
			{
				Ans = MessageBox.Show("Clear Fields?", "Add Another Aircraft", MessageBoxButtons.YesNo);
			}

			if (Ans == System.Windows.Forms.DialogResult.Yes)
			{

				modFillAircraftControls.Fill_Aircraft_Status_List(cbo_ac_status, (int) chk_forsale.CheckState);
				cbo_ac_status.SelectedIndex = 3; // changed from 2 - MSW - dereg now in spot 2 instead of not for sale- 9/2/21
				FillAircraftStage();
				FillAircraftOwnerType();
				Fill_Aircraft_Asking_List();

				cbo_ac_delivery.AddItem("Immediate");
				cbo_ac_delivery.AddItem("Date");


				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Getting List of Aircraft Makes ...", Color.Blue);
				Fill_Aircraft_Make_List();


				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Getting List of States ...", Color.Blue);
				modFillCompConControls.fill_state_FromArray(cboState, false, true, false);
				modFillCompConControls.fill_state_FromArray(cboBaseState, true, false, false);

				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Getting List of Countries ...", Color.Blue);
				modFillCompConControls.fill_country_FromArray(cboCountry);
				modFillCompConControls.Fill_baseAndRegCountryCbos(cboBaseCountry, cbo_ac_country_of_registration);

				cbo_ac_stage.SelectedIndex = 1;

				cbo_ac_owner_type.SelectedIndex = 0;
				int tempForEndVar = cbo_ac_owner_type.Items.Count - 1;
				for (int i = 0; i <= tempForEndVar; i++)
				{
					if (cbo_ac_owner_type.GetListItem(i).StartsWith("W", StringComparison.Ordinal))
					{
						cbo_ac_owner_type.SelectedIndex = i;
						break;
					}
				}

				for (int i = 0; i <= 5; i++)
				{
					if (i == 4)
					{
					}
					else
					{
						txtBaseCode[i].Text = "";
					}
				}

				txtBaseCode[0].Tag = ""; // Airport Id

				chk_ac_previously_owned_flag.CheckState = CheckState.Unchecked;
				chk_forsale.CheckState = CheckState.Unchecked;
				txt_ac_mfr_year.Text = "";
				txt_ac_year.Text = "";
				txt_ac_alt_ser_no_prefix.Text = "";
				txt_ac_alt_ser_no.Text = "";
				txt_ac_alt_ser_no_suffix.Text = "";
				txt_ac_ser_no.Text = "";
				txt_ac_ser_no_prefix.Text = "";
				txt_ac_ser_no_prefix.ReadOnly = true;
				txt_ac_ser_no_prefix.BackColor = SystemColors.Control;
				txt_ac_ser_no_suffix.Text = "";
				txt_ac_ser_no_suffix.ReadOnly = true;
				txt_ac_ser_no_suffix.BackColor = SystemColors.Control;
				txt_ac_reg_no.Text = "";
				txt_ac_prev_reg_no.Text = "";
				txt_ac_purchase_date.Text = "";

				chk_ac_aport_private.CheckState = CheckState.Unchecked;
				chkAwaitingDocs.CheckState = CheckState.Unchecked;
				lstManufacturer.Items.Clear();

				cbo_ac_engine_name.SelectedIndex = -1;

				RefreshForm();

				if (PassedModelID.ToString().Trim() != "")
				{
					int tempForEndVar3 = cbo_amod_make_name.Items.Count - 1;
					for (int i = 0; i <= tempForEndVar3; i++)
					{
						if (StringsHelper.ToDoubleSafe(PassedModelID.ToString().Trim()) == cbo_amod_make_name.GetItemData(i))
						{
							cbo_amod_make_name.SelectedIndex = i;
							break;
						}
					}
				}
			}

			modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
			this.Cursor = CursorHelper.CursorDefault;

		}

		private void RefreshForm()
		{

			Control Control = null;

			//UPGRADE_WARNING: (2065) Form property frm_AddAircraft.Controls has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
			foreach (Control ControlIterator in ContainerHelper.Controls(this))
			{
				Control = ControlIterator;
				if ((Control is ComboBox) || (Control is Panel) || (Control is RadioButton) || (Control is Label) || (Control is ToolStrip) || (Control is TextBox))
				{
					Control.Refresh();
				}
				//Control
				Control = default(Control);
			}
			Application.DoEvents();

		}

		private void FillAircraftStage()
		{

			string strLine = "";
			ADORecordSetHelper snpAircraftStage = new ADORecordSetHelper();

			string strQuery = "SELECT * FROM Aircraft_Stage WITH(NOLOCK) ORDER BY acs_code";

			snpAircraftStage.Open(strQuery, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

			if (!(snpAircraftStage.BOF && snpAircraftStage.EOF))
			{

				while(!snpAircraftStage.EOF)
				{
					strLine = $"{($"{Convert.ToString(snpAircraftStage["acs_code"])} ").Trim()} - ";
					strLine = $"{strLine}{($"{Convert.ToString(snpAircraftStage["acs_name"])} ").Trim()}";
					cbo_ac_stage.AddItem(strLine);
					snpAircraftStage.MoveNext();
				};

			}

			snpAircraftStage.Close();

		}

		private void FillAircraftOwnerType()
		{

			string strLine = "";
			ADORecordSetHelper snpAircraftOwnerType = new ADORecordSetHelper();

			string strQuery = "SELECT * FROM Aircraft_Owner_Type WITH(NOLOCK)";

			snpAircraftOwnerType.Open(strQuery, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

			if (!(snpAircraftOwnerType.BOF && snpAircraftOwnerType.EOF))
			{

				while(!snpAircraftOwnerType.EOF)
				{
					strLine = $"{($"{Convert.ToString(snpAircraftOwnerType["acot_code"])} ").Trim()} - ";
					strLine = $"{strLine}{($"{Convert.ToString(snpAircraftOwnerType["acot_name"])} ").Trim()}";
					cbo_ac_owner_type.AddItem(strLine);
					snpAircraftOwnerType.MoveNext();
				};
			}

			snpAircraftOwnerType.Close();

		}

		private void Fill_Aircraft_Asking_List()
		{

			string Query = "";
			ADORecordSetHelper snp_acasking = new ADORecordSetHelper();

			try
			{

				Query = "SELECT * FROM Aircraft_Asking WITH(NOLOCK)";

				snp_acasking.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_acasking.BOF && snp_acasking.EOF))
				{

					while(!snp_acasking.EOF)
					{
						cbo_ac_asking.AddItem(($"{Convert.ToString(snp_acasking["aask_name"])} ").Trim());
						snp_acasking.MoveNext();
					};
					cbo_ac_asking.SelectedIndex = 0;
				}

				snp_acasking.Close();
				snp_acasking = null;
			}
			catch
			{

				this.Cursor = CursorHelper.CursorDefault;
				modAdminCommon.Report_Error("Fill_Aircraft_Asking_List_Error: ");
			}

		}

		private void Fill_Aircraft_Make_List()
		{

			ADORecordSetHelper snpAircraftMakeList = new ADORecordSetHelper();

			cbo_amod_make_name.Items.Clear();

			string strQuery = "SELECT DISTINCT * FROM Aircraft_Model WITH(NOLOCK) ORDER BY amod_make_name, amod_model_name ";

			snpAircraftMakeList.Open(strQuery, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

			if (!(snpAircraftMakeList.BOF && snpAircraftMakeList.EOF))
			{

				while(!snpAircraftMakeList.EOF)
				{
					cbo_amod_make_name.AddItem($"{($"{Convert.ToString(snpAircraftMakeList["amod_make_name"])} ").Trim()} / {($"{Convert.ToString(snpAircraftMakeList["amod_model_name"])} ").Trim()}");
					cbo_amod_make_name.SetItemData(cbo_amod_make_name.Items.Count - 1, Convert.ToInt32(snpAircraftMakeList["amod_id"]));
					snpAircraftMakeList.MoveNext();
				};
			}

			snpAircraftMakeList.Close();

		}

		private void lbl_gen_Click(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.lbl_gen, eventSender);

			lbl_gen[Index].Enabled = false;

			switch(Index)
			{
				case 4 :  // Serial Nbr Label 
					txt_ac_ser_no_prefix.ReadOnly = false; 
					txt_ac_ser_no_prefix.BackColor = SystemColors.Window; 
					 
					txt_ac_ser_no_suffix.ReadOnly = false; 
					txt_ac_ser_no_suffix.BackColor = SystemColors.Window; 
					 
					break;
				case 13 : 
					GetBaseCodeInformation(6); 
					break;
			}

			lbl_gen[Index].Enabled = true;

		}

		public void mnuClose_Click(Object eventSender, EventArgs eventArgs) => this.Close();


		public void mnuLogout_Click(Object eventSender, EventArgs eventArgs) => frm_Main_Menu.DefInstance.Close();


		private void txt_engine_noise_rating_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{
				//limit input to numbers only
				//UPGRADE_ISSUE: (1058) Assignment not supported: KeyAscii to a non-positive constant More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-1058
				KeyAscii = (KeyAscii != 8 && !(Conversion.Val(Strings.Chr(KeyAscii).ToString()) > 0)) ? 0 : KeyAscii;
			}
			finally
			{
				if (KeyAscii == 0)
				{
					eventArgs.Handled = true;
				}
				eventArgs.KeyChar = Convert.ToChar(KeyAscii);
			}


		}

		private void txtBaseCode_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.txtBaseCode, eventSender);
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{
				Stop_Airport_Fill = false;
				// IATA, ICAO, FAAID
				if (Index == 0 || Index == 1 || Index == 3)
				{
					//UPGRADE_ISSUE: (1058) Assignment not supported: KeyAscii to a non-positive constant More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-1058
					KeyAscii = Strings.Asc(Strings.Chr(KeyAscii).ToString().ToUpper()[0]);
				}
			}
			finally
			{
				if (KeyAscii == 0)
				{
					eventArgs.Handled = true;
				}
				eventArgs.KeyChar = Convert.ToChar(KeyAscii);
			}
		}

		private void txtBaseCode_Leave(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.txtBaseCode, eventSender);

			//private airport added 9/29/05 aey
			if (chk_ac_aport_private.CheckState == CheckState.Checked)
			{
				Stop_Airport_Fill = true;
			}

			if (Stop_Airport_Fill)
			{
				return;
			}

			if (txtBaseCode[Index].Text != "")
			{

				switch(Index)
				{
					case 0 :  // IATA 
						 
						GetBaseCodeInformation(0); 
						break;
					case 1 :  // ICAO 
						GetBaseCodeInformation(1); 
						break;
					case 2 :  // NAME 
						if (txtBaseCode[2].Text != "")
						{
							GetBaseCodeInformation(2);
						} 
						break;
					case 3 :  // FAA Id 
						GetBaseCodeInformation(3); 
						break;
					case 5 :  // CITY 
						if (txtBaseCode[5].Text != "")
						{
							GetBaseCodeInformation(5);
						} 
						break;
				}

			} // If txtBaseCode(Index).Text <> "" Then

			Application.DoEvents();

		}

		private void GetBaseCodeInformation(int PassedIndex)
		{

			ADORecordSetHelper snpBase = new ADORecordSetHelper();
			string strQuery1 = "";
			string strMsg = "";

			try
			{

				strQuery1 = "SELECT * FROM Airport ";
				strQuery1 = $"{strQuery1}WHERE (aport_id > 0) ";
				strQuery1 = $"{strQuery1}AND (aport_active_flag = 'Y') ";
				strQuery1 = $"{strQuery1}AND (aport_name <> '') ";
				strQuery1 = $"{strQuery1}AND (aport_name IS NOT NULL) ";

				switch(PassedIndex)
				{
					case 0 :  // IATA 
						strMsg = "IATA Code"; 
						strQuery1 = $"{strQuery1}AND (aport_iata_code = '{txtBaseCode[0].Text}') "; 
						break;
					case 1 :  // ICAO 
						strMsg = "ICAO Code"; 
						strQuery1 = $"{strQuery1}AND (aport_icao_code = '{txtBaseCode[1].Text}') "; 
						break;
					case 2 :  // NAME 
						strMsg = "Base Name"; 
						strQuery1 = $"{strQuery1}AND (aport_name LIKE '{modAdminCommon.Fix_Quote(txtBaseCode[2].Text)}%') "; 
						break;
					case 3 :  // FAAId 
						strMsg = "FAAId Code"; 
						strQuery1 = $"{strQuery1}AND (aport_faaid_code = '{txtBaseCode[3].Text}') "; 
						break;
					case 4 :  // COUNTRY 
						strMsg = "Country"; 
						strQuery1 = $"{strQuery1}AND (aport_country LIKE '{modAdminCommon.Fix_Quote(cboBaseCountry.Text)}%') "; 
						break;
					case 5 :  // CITY 
						strMsg = "City"; 
						strQuery1 = $"{strQuery1}AND (aport_city LIKE '{modAdminCommon.Fix_Quote(txtBaseCode[5].Text)}%') "; 
						break;
					case 6 :  // ALL 
						if (txtBaseCode[0].Text.Trim() != "")
						{
							strQuery1 = $"{strQuery1}AND (aport_iata_code = '{txtBaseCode[0].Text}') ";
						} 
						if (txtBaseCode[1].Text.Trim() != "")
						{
							strQuery1 = $"{strQuery1}AND (aport_icao_code = '{txtBaseCode[1].Text}') ";
						} 
						if (txtBaseCode[2].Text.Trim() != "")
						{
							strQuery1 = $"{strQuery1}AND (aport_name LIKE '{modAdminCommon.Fix_Quote(txtBaseCode[2].Text)}%') ";
						} 
						if (txtBaseCode[3].Text.Trim() != "")
						{
							strQuery1 = $"{strQuery1}AND (aport_faaid_code = '{txtBaseCode[3].Text}') ";
						} 
						if (cboBaseState.Text.Trim() != "")
						{
							strQuery1 = $"{strQuery1}AND (aport_state = '{cboBaseState.Text}') ";
						} 
						if (cboBaseCountry.Text.Trim() != "")
						{
							strQuery1 = $"{strQuery1}AND (aport_country LIKE '{modAdminCommon.Fix_Quote(cboBaseCountry.Text)}%') ";
						} 
						if (txtBaseCode[5].Text.Trim() != "")
						{
							strQuery1 = $"{strQuery1}AND (aport_city LIKE '{modAdminCommon.Fix_Quote(txtBaseCode[5].Text)}%') ";
						} 
						break;
				}

				strQuery1 = $"{strQuery1}ORDER BY aport_name, aport_country, aport_state, aport_city ";

				snpBase.CursorLocation = CursorLocationEnum.adUseClient;
				snpBase.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!snpBase.BOF && !snpBase.EOF)
				{

					if (snpBase.RecordCount == 1)
					{

						txtBaseCode[0].Text = ($"{Convert.ToString(snpBase["aport_iata_code"])}").Trim();
						txtBaseCode[0].Tag = Convert.ToString(snpBase["aport_id"]);
						txtBaseCode[1].Text = ($"{Convert.ToString(snpBase["aport_icao_code"])}").Trim();
						txtBaseCode[2].Text = ($"{Convert.ToString(snpBase["aport_name"])}").Trim();
						txtBaseCode[3].Text = ($"{Convert.ToString(snpBase["aport_faaid_code"])}").Trim();
						txtBaseCode[5].Text = ($"{Convert.ToString(snpBase["Aport_city"])}").Trim();
						cboBaseState.Text = ($"{Convert.ToString(snpBase["aport_state"])}").Trim();
						cboBaseCountry.Text = ($"{Convert.ToString(snpBase["aport_country"])}").Trim();

						txt_ac_mfr_year.Focus();

					}
					else
					{

						if (snpBase.RecordCount <= 100)
						{
							frm_JournalListPopUp.DefInstance.Close();
							frm_JournalListPopUp.DefInstance.inEntryPoint = "AddAircraft";
							frm_JournalListPopUp.DefInstance.inQuery = strQuery1;
							frm_JournalListPopUp.DefInstance.ShowDialog();
							frm_JournalListPopUp.DefInstance.Close();
						}
						else
						{
							MessageBox.Show("This Will Result In Too Many Records. Please Try Again", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						}

					} // If snpBase.RecordCount = 1 Then

				}
				else
				{

					MessageBox.Show($"Cannot Find Any Airport For The Entered {strMsg}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));

					txtBaseCode[0].Text = ""; // IATA
					txtBaseCode[0].Tag = "0";
					txtBaseCode[1].Text = ""; // ICAO
					txtBaseCode[2].Text = ""; // NAME
					txtBaseCode[3].Text = ""; // FAAID
					txtBaseCode[5].Text = ""; // CITY
					cboBaseState.Text = "";
					cboBaseCountry.Text = "";
					txtBaseCode[PassedIndex].Focus();

				} // If (snpBase.BOF = False And snpBase.EOF = False) Then

				snpBase.Close();
				snpBase = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error("GetBaseCodeInformation_Error: ", excep.Message);
			}

		} // GetBaseCodeInformation

		private object display_product_Codes()
		{

			bool modelProductB = false;
			bool modelProductH = false;
			bool modelProductC = false;
			bool modelProductP = false;

			// first turn off all check boxes

			int tempForEndVar = ac_product_chk.GetUpperBound(0);
			for (int X = 0; X <= tempForEndVar; X++)
			{
				ac_product_chk[X].Visible = false;
				ac_product_chk[X].Enabled = false;
				ac_product_chk[X].CheckState = CheckState.Unchecked;
			}

			if (cbo_amod_make_name.SelectedIndex > -1)
			{

				modelProductB = modCommon.DLookUp("amod_product_business_flag", "Aircraft_Model WITH(NOLOCK)", $"amod_id = {cbo_amod_make_name.GetItemData(cbo_amod_make_name.SelectedIndex).ToString()}") == "Y";
				modelProductH = modCommon.DLookUp("amod_product_helicopter_flag", "Aircraft_Model WITH(NOLOCK)", $"amod_id = {cbo_amod_make_name.GetItemData(cbo_amod_make_name.SelectedIndex).ToString()}") == "Y";
				modelProductC = modCommon.DLookUp("amod_product_commercial_flag", "Aircraft_Model WITH(NOLOCK)", $"amod_id = {cbo_amod_make_name.GetItemData(cbo_amod_make_name.SelectedIndex).ToString()}") == "Y";
				modelProductP = modCommon.DLookUp("amod_product_airbp_flag", "Aircraft_Model WITH(NOLOCK)", $"amod_id = {cbo_amod_make_name.GetItemData(cbo_amod_make_name.SelectedIndex).ToString()}") == "Y";

				int tempForEndVar2 = ac_product_chk.GetUpperBound(0);
				for (int X = 0; X <= tempForEndVar2; X++)
				{


					switch((X))
					{
						case modGlobalVars.CHK_BUSINESS_IDX : 
							// default to business product 
							ac_product_chk[X].Visible = true; 
							if (modelProductB)
							{
								ac_product_chk[X].CheckState = CheckState.Checked;
							} 
							break;
						case modGlobalVars.CHK_HELICOPTER_IDX : 
							ac_product_chk[X].Visible = true; 
							if (modelProductH)
							{
								ac_product_chk[X].CheckState = CheckState.Checked;
							} 
							break;
						case modGlobalVars.CHK_COMMERCIAL_IDX : 
							ac_product_chk[X].Visible = true; 
							if (modelProductC)
							{
								ac_product_chk[X].Enabled = true;
								//   added MSW 9/21/18 to make sure these get checked both automatically
								if (PassedModelID == 180 || PassedModelID == 181 || PassedModelID == 1170)
								{
									ac_product_chk[2].CheckState = CheckState.Checked;
								}
							} 
							 
							break;
						case modGlobalVars.CHK_ABI_IDX : case modGlobalVars.CHK_REGIONAL_IDX : 
							ac_product_chk[X].Visible = true; 
							 
							break;
						case modGlobalVars.CHK_AIRBP_IDX : 
							ac_product_chk[X].Visible = true; 
							if (modelProductP)
							{
								ac_product_chk[X].Enabled = true;
							} 
							 
							break;
						default:
							goto exit_for;
					}

				}
				exit_for:;

			}

			return null;
		}
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}