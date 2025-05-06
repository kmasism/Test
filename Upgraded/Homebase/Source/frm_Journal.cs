using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Gui.Controls;
using UpgradeHelpers.Gui.Utils;
using UpgradeHelpers.Helpers;
using UpgradeStubs;

namespace JETNET_Homebase
{
	internal partial class frm_Journal
		: System.Windows.Forms.Form
	{

		//******************************************************************************************



		public string ACModel = "";
		public string ACSerial = "";
		public string ACYear = "";
		public int Reference_Journal_ID = 0;
		public int Reference_Comp_Id = 0;
		public int Reference_Contact_Id = 0;
		public int Reference_Ac_Id = 0;
		public int Reference_Yacht_Id = 0;
		public string Reference_Category_Code = "";
		public string Reference_SubCategory_Code = "";
		public string Reference_Subject = "";
		public int Historical_Journal_ID = 0;
		public int Reference_Amod_Id = 0;

		public string tmpOwnershipType = "";

		public int current_contact_id = 0;
		public int current_comp_id = 0;
		public bool is_historical_yacht = false;

		private bool ClickSkip = false;
		private ADORecordSetHelper snp_Journal = null; //8/1/05
		private ADORecordSetHelper snpComp = null; //8/1/05 aey converted to ado
		private string tmp_journ_subcategory_code = "";
		private string tmp_journ_description = "";
		private string tmp_journ_customer_note = "";
		private string tmp_journ_date = "";
		private string tmp_journ_newmarket_flag = "";
		private string tmp_serial_no = "";
		private int tmp_amod_id = 0;
		private bool DataNotValid = false;
		private int SellerReference = 0;
		private int PurchaserReference = 0;
		private int Purchaser_ID = 0;
		private int Seller_ID = 0;
		private int Seller_Contact_ID = 0;
		private string Seller_Type = "";

		private int Original_Company_ID = 0;
		private int Original_Contact_ID = 0;

		private int nRefJournalID = 0;
		private string nRefJcat_subcategory_name = "";
		private bool tmp_JournHitoryFlag = false; // identifies whether journal is of type history
		private bool is_new_to_market_on_load = false;
		private bool gbAlreadyLoaded = false;
		private int lAFSPREventId = 0; // Asked For Sold Price Refused Event Id
		private int lAFSPEventId = 0; // Asked For Sold Price Event Id
		public frm_Journal()
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
			isInitializingComponent = true;
			InitializeComponent();
			isInitializingComponent = false;
			ReLoadForm(false);
		}




		private void CheckPermission()
		{

			// ******************************************************
			// DETERMINE WHETHER TO DISPLAY THE CHANGE TRANSACTION TYPE BUTTON
			if (Convert.ToString(modAdminCommon.snp_User["user_type"]).Trim().ToLower() == ("Research Manager").Trim().ToLower() || Convert.ToString(modAdminCommon.snp_User["user_type"]).Trim().ToLower() == ("Administrator").Trim().ToLower())
			{
				if (txt_journ_subcategory_code.Text.Substring(0, Math.Min(2, txt_journ_subcategory_code.Text.Length)).ToUpper() == "WS")
				{
					//                left(txt_journ_subcategory_code, 2) = "SS" Or _
					//                       '                left(txt_journ_subcategory_code, 2) = "FS" Then
					cmd_Change_Trans_Type.Visible = true;
				}
				else
				{
					cmd_Change_Trans_Type.Visible = false;
				}
			}
			else
			{
				cmd_Change_Trans_Type.Visible = false;
			}


			txt_journ_customer_note.Enabled = true;
			txt_journ_customer_note.Visible = true;
			lbl_Journal[3].Visible = true;

			if (!(snp_Journal.BOF && snp_Journal.EOF))
			{
				if (Reference_Category_Code.ToUpper() == "AR" || Reference_Category_Code.ToUpper() == "ME" || Reference_SubCategory_Code.ToUpper() == "IN" || Reference_SubCategory_Code.ToUpper() == "CN" || Reference_SubCategory_Code.ToUpper() == "FN")
				{


					if (Convert.ToString(modAdminCommon.snp_User["user_type"]).Trim().ToLower() == ("Research Manager").Trim().ToLower() || Convert.ToString(modAdminCommon.snp_User["user_type"]).Trim().ToLower() == ("Administrator").Trim().ToLower() || Convert.ToString(modAdminCommon.snp_User["user_id"]).Trim().ToLower() == txt_User.Text.Trim().ToLower())
					{

						txt_journ_subject.Enabled = true;
						txt_journ_subject.ReadOnly = false;
						txt_journ_description.Enabled = true;
						txt_journ_customer_note.Enabled = true;
						cmd_Save.Visible = true;
						cmdDelete.Visible = true;

					}
					else
					{
						cmd_Save.Visible = false;
						cmdDelete.Visible = false;
					}
				}
				else
				{
					cmdDelete.Visible = (Convert.ToString(modAdminCommon.snp_User["user_id"]).Trim().ToLower() == "lf" || Convert.ToString(modAdminCommon.snp_User["user_id"]).Trim().ToLower() == "mah" || Convert.ToString(modAdminCommon.snp_User["user_id"]).Trim().ToLower() == "gb" || Convert.ToString(modAdminCommon.snp_User["user_id"]).Trim().ToLower() == "ts" || Convert.ToString(modAdminCommon.snp_User["user_id"]).Trim().ToLower() == "kab" || Convert.ToString(modAdminCommon.snp_User["user_id"]).Trim().ToLower() == "lmc") && txt_journ_subcategory_code.Text.Trim().ToUpper() == "LX";


					if (Convert.ToString(modAdminCommon.snp_User["user_type"]).Trim().ToLower() == ("Research Manager").Trim().ToLower() || Convert.ToString(modAdminCommon.snp_User["user_type"]).Trim().ToLower() == ("Administrator").Trim().ToLower())
					{
						txt_journ_subject.ReadOnly = false;
						txt_journ_subject.Enabled = true;
					}
					else
					{
						txt_journ_subject.ReadOnly = true;
					}

				}

				if ((Reference_Category_Code.ToUpper() == "MR" && Reference_SubCategory_Code.ToUpper() == "MN") || (Reference_Category_Code.ToUpper() == "TR" && Reference_SubCategory_Code.ToUpper() == "TN"))
				{

					txt_journ_subject.Enabled = true;
					txt_journ_subject.ReadOnly = false;

					if (Convert.ToString(modAdminCommon.snp_User["user_id"]).Trim().ToLower() == txt_User.Text.Trim().ToLower())
					{
						cmd_Save.Visible = true;
						cmdDelete.Visible = true;
					} //

				} //  If a Marketing Note or a Technical Note

				// aircraft history
				if (Reference_Category_Code.ToUpper() == "AH")
				{
					txt_journ_subject.Enabled = false;
					if (Convert.ToString(modAdminCommon.snp_User["user_type"]).Trim().ToLower() == ("Research Manager").Trim().ToLower() || Convert.ToString(modAdminCommon.snp_User["user_type"]).Trim().ToLower() == ("Administrator").Trim().ToLower() || Convert.ToString(modAdminCommon.snp_User["user_id"]).Trim().ToLower() == txt_User.Text.Trim().ToLower())
					{

						txt_journ_description.Enabled = true;
						txt_journ_customer_note.Enabled = true;
						cmd_Save.Visible = true;
					}
					else
					{
						cmd_Save.Visible = false;
					}
				}

				// TURN ON DAMAGE NOTE DELETE TO ANYONE
				if (Reference_SubCategory_Code.ToUpper() == "DM")
				{
					cmdDelete.Visible = true;
				}

				if (Convert.ToString(modAdminCommon.snp_User["user_id"]).Trim().ToLower() == "mvit" || ($"{Convert.ToString(modAdminCommon.snp_User["user_remove_journal_subject_flag"])}{modGlobalVars.cEmptyString}").ToUpper() == "Y")
				{ //8/24/05 aey
					cmdDelete.Visible = true;
				}

				// added in MSW - 7/19/22 - dont allow anyone to delete a journal item
				if (cmdDelete.Visible)
				{
					if (modAdminCommon.Exist($"select top 1 ac_id from aircraft with (NOLOCK) where ac_journ_id = {txt_journ_id.Text}"))
					{
						cmdDelete.Visible = false;
					}
				}


			}





		} // CheckPermission


		private bool CodeValid(string inCode)
		{

			bool result = false;
			string strQuery = "";

			int lSeller = 0;
			bool bFoundSeller = false;
			string strSellerType = "";

			int lPurchaser = 0;
			bool bFoundPurchaser = false;
			string strPurchaserType = "";

			int lJournId = 0;
			bool bResults = false;

			try
			{

				bResults = false;
				bFoundSeller = false;
				bFoundPurchaser = false;

				inCode = ($"{inCode} ").Trim();

				if (inCode == "AAV" || inCode.Substring(Math.Max(inCode.Length - 4, 0)) == "CORR")
				{ //No need to check when it's not a transaction
					return true;
				} //If inCode = "AAV"

				// Must Have A Valid Journal Subcategory Transaction Code
				if (inCode != "")
				{

					strSellerType = ($"{inCode.Substring(Math.Min(2, inCode.Length), Math.Min(2, Math.Max(0, inCode.Length - 2)))} ").Trim();
					strPurchaserType = ($"{inCode.Substring(Math.Min(4, inCode.Length), Math.Min(2, Math.Max(0, inCode.Length - 4)))} ").Trim();

					// Must Have Valid seller/purchaser business_type_codes
					if ((strSellerType != "") && (strPurchaserType != ""))
					{

						lJournId = nRefJournalID; // Current Journal Id

						// Must Have A Valid Journal Id
						if (lJournId > 0)
						{

							if (Reference_Ac_Id > 0)
							{
								lSeller = GetACRefCompID(lJournId, "1");
								lPurchaser = GetACRefCompID(lJournId, "10");
							}

							if (Reference_Yacht_Id > 0)
							{
								lSeller = GetYachtRefCompID(lJournId, "1");
								lPurchaser = GetYachtRefCompID(lJournId, "10");
							}

							// Always must have both a valid seller and purchaser company id number
							if ((lSeller > 0) && (lPurchaser > 0))
							{

								strQuery = "SELECT bustypref_id FROM Business_Type_Reference WITH(NOLOCK) ";
								strQuery = $"{strQuery}WHERE bustypref_comp_id = {lSeller.ToString()} ";
								strQuery = $"{strQuery}AND bustypref_journ_id = {lJournId.ToString()} ";
								strQuery = $"{strQuery}AND bustypref_type = '{strSellerType}' ";

								bFoundSeller = modAdminCommon.Exist(strQuery);

								// Don't Process Purchaser If The Transaction is an IT (Internal)
								if (strPurchaserType != "IT")
								{

									strQuery = "SELECT bustypref_id FROM Business_Type_Reference WITH(NOLOCK)";
									strQuery = $"{strQuery}WHERE bustypref_comp_id = {lPurchaser.ToString()} ";
									strQuery = $"{strQuery}AND bustypref_journ_id = {lJournId.ToString()} ";
									strQuery = $"{strQuery}AND bustypref_type = '{strPurchaserType}' ";

									bFoundPurchaser = modAdminCommon.Exist(strQuery);

								}
								else
								{
									bFoundPurchaser = true; // Force True if Internal
								} // If strPurchaserType <> "IT" Then ' Don't Process if IT (Internal)

							}
							else
							{
								// If (lSeller > 0) And (lPurchaser > 0) Then
								bResults = false;
							}

						}
						else
						{
							// If (ljournid > 0) Then
							bResults = false;
						}

					}
					else
					{
						// If (strSellerType <> "") And (strPurchaserType <> "") Then
						bResults = false;
					}

				}
				else
				{
					// If inCode <> "" Then
					bResults = false;
				}

				if (Convert.ToString(modAdminCommon.snp_User["user_id"]).ToLower() == "lf")
				{

					bResults = true;

					if ((!bFoundSeller) && (strSellerType != "AD"))
					{
						if (!AddBusinessTypeToCurrentAndHistoricalCompanyRecord(lSeller, lJournId, strSellerType))
						{
							bResults = false;
						}
						else
						{
							bFoundSeller = true; // It's Added This is Now True
						}
					} // If (bFoundSeller = False) And (strSellerType <> "AD") Then

					if ((!bFoundPurchaser) && (strPurchaserType != "IT") && (strPurchaserType != "AD") && (bFoundSeller))
					{
						if (!AddBusinessTypeToCurrentAndHistoricalCompanyRecord(lPurchaser, lJournId, strPurchaserType))
						{
							bResults = false;
						}
						else
						{
							bFoundPurchaser = true; // It's Added This is Now True
						}
					} //If (bFoundPurchaser = False) And (strPurchaserType <> "IT") And (strPurchaserType <> "AD") And (bFoundSeller = True) Then

				}
				else
				{
					// User is NOT LF

					if (!bFoundSeller)
					{

						if (strSellerType != "AD" && inCode.Substring(Math.Max(inCode.Length - 4, 0)) != "CORR")
						{
							MessageBox.Show($"Seller does not have correct Business Type" +
							                $"{Environment.NewLine}{Environment.NewLine}You must Add the '{strSellerType}" +
							                $"' Business Type to the Historical Seller before changing this code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						}
						else
						{
							bFoundSeller = true; // If AD Just Ignore
						}

					}
					else
					{
						// If bFoundSeller = False Then

						if (!bFoundPurchaser)
						{

							if ((strPurchaserType != "IT") && (strPurchaserType != "AD"))
							{
								MessageBox.Show($"Purchaser does not have correct Business Type" +
								                $"{Environment.NewLine}{Environment.NewLine}You must Add the '{strPurchaserType}" +
								                $"' Business Type to the Historical Seller before changing this code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
							}
							else
							{
								bFoundPurchaser = true; // If IT or AD Just Ignore
							}

						} // If (bFoundPurchaser = False) Then

					} // If bFoundSeller = False Then

					bResults = bFoundSeller && bFoundPurchaser; // Both Must Be Found

				} // If LCase(snp_User!user_id) = "lf" Then


				return bResults;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Journal", $"CodeValid_Error {excep.Message} {strQuery} Database Error");
				bResults = false;
				this.Cursor = CursorHelper.CursorDefault;


				result = false;
			}
			return result;
		} // CodeValid

		public void display_ac_inbox(int comp_id)
		{


			string sVerifyAc = "";

			string Query = $"EXEC HomebaseGetCompanyAircraftList {comp_id.ToString()}, 0";

			ADORecordSetHelper ado_aircraft = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

			if (!ado_aircraft.EOF)
			{
				do 
				{

					sVerifyAc = ($"{Convert.ToString(ado_aircraft["amod_make_name"])} ").Trim();
					sVerifyAc = $"{sVerifyAc}{($"{Convert.ToString(ado_aircraft["amod_model_name"])} - ").Trim()}";
					sVerifyAc = $"{sVerifyAc}{($"{Convert.ToString(ado_aircraft["ac_ser_no_full"])} ").Trim()}";
					sVerifyAc = $"{sVerifyAc} REG: ({Convert.ToString(ado_aircraft["ac_reg_no"]).Trim()})";

					lst_aircraft.AddItem(sVerifyAc);
					lst_aircraft.SetItemData(lst_aircraft.Items.Count - 1, Convert.ToInt32(ado_aircraft["ac_id"]));


					ado_aircraft.MoveNext();
				}
				while(!ado_aircraft.EOF);
			}



		}

		private void FillCboCompany()
		{

			string Query = "";
			bool FoundComp = false;
			bool CompInList = false;

			try
			{

				cbo_comp_info.Items.Clear();

				cbo_comp_info.AddItem("<None>");
				cbo_comp_info.SetItemData(0, 0);

				// If Reference_Ac_Id > 0 Then
				if (Reference_Journal_ID > 0 || Historical_Journal_ID > 0)
				{
					if ((Reference_Category_Code == "AH" || Reference_Category_Code == "ME" || Historical_Journal_ID > 0 || Reference_Category_Code == "AR") && nRefJcat_subcategory_name.ToUpper() != ("Changed Company Name").ToUpper())
					{
						// ME added for memo notes on 4/25/19 by MSW
						Query = "SELECT distinct comp_id, comp_journ_id, comp_name, comp_city, comp_state ";
						Query = $"{Query}FROM Company WITH(NOLOCK) ";
						Query = $"{Query}WHERE "; //MSW - moved Query = Query & " (comp_journ_id = 0) "  that was here - 10/23/19

						if (Reference_Yacht_Id > 0)
						{
							Query = $"{Query} (comp_journ_id = 0) ";
							Query = $"{Query}and comp_id in (select distinct yr_comp_id from Yacht_Reference ";
							Query = $"{Query} where (";
							if (Reference_Yacht_Id > 0 && Historical_Journal_ID > 0)
							{
								Query = $"{Query} (yr_yt_id={Reference_Yacht_Id.ToString()} and yr_journ_id = {Historical_Journal_ID.ToString()})";
							}
							else if (Reference_Yacht_Id > 0)
							{ 
								Query = $"{Query} (yr_yt_id={Reference_Yacht_Id.ToString()} and yr_journ_id = {Reference_Journal_ID.ToString()})";
							}
							else if (Reference_Comp_Id > 0)
							{ 
								Query = $"{Query} (yr_comp_id={Reference_Comp_Id.ToString()} )";
							}
							else if (Reference_Journal_ID > 0)
							{ 
								Query = $"{Query} (yr_journ_id={Reference_Journal_ID.ToString()} )";
							}
							else if (Historical_Journal_ID > 0)
							{ 
								Query = $"{Query} ( yr_journ_id = {Historical_Journal_ID.ToString()})";
							}

							Query = $"{Query} )  or (yr_yt_id={Reference_Yacht_Id.ToString()} and yr_journ_id = 0))";

						}
						else if (Reference_Ac_Id > 0)
						{ 
							Query = $"{Query} (comp_journ_id = 0)  and comp_id in (select distinct cref_comp_id from Aircraft_Reference ";
							Query = $"{Query} where (";

							if (Reference_Ac_Id > 0 && Historical_Journal_ID > 0)
							{
								Query = $"{Query} (cref_ac_id={Reference_Ac_Id.ToString()} and cref_journ_id = {Historical_Journal_ID.ToString()})";
							}
							else if (Reference_Ac_Id > 0)
							{ 
								Query = $"{Query} (cref_ac_id={Reference_Ac_Id.ToString()} and cref_journ_id = {Reference_Journal_ID.ToString()})";
							}
							else if (Reference_Comp_Id > 0)
							{ 
								Query = $"{Query} (cref_comp_id={Reference_Comp_Id.ToString()} )";
							}
							else if (Reference_Journal_ID > 0)
							{ 
								Query = $"{Query} (cref_journ_id={Reference_Journal_ID.ToString()} )";
							}
							else if (Historical_Journal_ID > 0)
							{ 
								Query = $"{Query} ( cref_journ_id = {Historical_Journal_ID.ToString()})";
							}

							Query = $"{Query} )  or (cref_ac_id={Reference_Ac_Id.ToString()} and cref_journ_id = 0)";

							if (modAdminCommon.gbl_Aircraft_Journal_ID != Reference_Ac_Id)
							{
								Query = $"{Query}or (cref_ac_id={Reference_Ac_Id.ToString()} and cref_journ_id = {modAdminCommon.gbl_Aircraft_Journal_ID.ToString()})";
							}

							Query = $"{Query})";

						}
						else
						{

							if (Reference_Comp_Id > 0)
							{
								Query = $"{Query} (comp_journ_id = 0) ";
								Query = $"{Query} and (comp_id={Reference_Comp_Id.ToString()} )";
							}
							else if (Reference_Journal_ID > 0)
							{ 
								Query = $"{Query} (comp_journ_id={Reference_Journal_ID.ToString()} ) ";
							}
							else if (Historical_Journal_ID > 0)
							{ 
								Query = $"{Query} ( comp_journ_id = {Historical_Journal_ID.ToString()}) ";
							}
						}


						Query = $"{Query}GROUP BY comp_id, comp_journ_id, comp_name, comp_city, comp_state  ";
						Query = $"{Query}ORDER BY comp_id, comp_journ_id desc, comp_name, comp_city, comp_state ";

					}
					else
					{
						// NO REASON TO JOIN REFERENCE TABLE WHEN NO AIRCRAFT ID
						Query = "SELECT distinct comp_id, comp_journ_id, comp_name, comp_city, comp_state ";
						Query = $"{Query}FROM Company WITH(NOLOCK)  WHERE comp_id = {Reference_Comp_Id.ToString()} and comp_journ_id=0 ";
						Query = $"{Query}GROUP BY comp_id, comp_journ_id, comp_name, comp_city, comp_state ";
						Query = $"{Query}ORDER BY comp_id, comp_journ_id desc, comp_name, comp_city, comp_state";

					}
				}
				else
				{
					if (Reference_Ac_Id > 0)
					{
						Query = "SELECT distinct comp_id, comp_journ_id, comp_name, comp_city, comp_state ";
						Query = $"{Query}FROM Company WITH(NOLOCK)  WHERE (comp_journ_id = 0)";
						Query = $"{Query}and comp_id in (select distinct cref_comp_id from Aircraft_Reference where ";
						Query = $"{Query}(cref_ac_id={Reference_Ac_Id.ToString()} and cref_journ_id = 0))";
						Query = $"{Query}GROUP BY comp_id, comp_journ_id, comp_name, comp_city, comp_state  ";
						Query = $"{Query}ORDER BY comp_id, comp_journ_id desc, comp_name, comp_city, comp_state ";

					}
					else
					{
						// NO REASON TO JOIN REFERENCE TABLE WHEN NO AIRCRAFT ID
						Query = "SELECT distinct comp_id, comp_journ_id, comp_name, comp_city, comp_state ";
						Query = $"{Query}FROM Company WITH(NOLOCK)  WHERE comp_id = {Reference_Comp_Id.ToString()} and comp_journ_id=0 ";
						Query = $"{Query}GROUP BY comp_id, comp_journ_id, comp_name, comp_city, comp_state ";
						Query = $"{Query}ORDER BY comp_id, comp_journ_id desc, comp_name, comp_city, comp_state";
					}
				}

				snpComp = new ADORecordSetHelper();
				snpComp.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpComp.BOF && snpComp.EOF))
				{


					while(!snpComp.EOF)
					{
						CompInList = false;
						int tempForEndVar = cbo_comp_info.Items.Count - 1;
						for (int i = 0; i <= tempForEndVar; i++)
						{
							if (cbo_comp_info.GetItemData(i) == StringsHelper.ToDoubleSafe(($"{Convert.ToString(snpComp["comp_id"])}").Trim()))
							{
								CompInList = true;
								break;
							}
						}
						if (!CompInList)
						{
							cbo_comp_info.AddItem($"{($"{Convert.ToString(snpComp["comp_name"])}").Trim()} [{($"{Convert.ToString(snpComp["Comp_city"])}").Trim()}, {($"{Convert.ToString(snpComp["comp_state"])}").Trim()}]");
							cbo_comp_info.SetItemData(cbo_comp_info.Items.Count - 1, Convert.ToInt32(Double.Parse(($"{Convert.ToString(snpComp["comp_id"])}").Trim())));
						}
						snpComp.MoveNext();
					};

					cbo_comp_info.Visible = true;

					int tempForEndVar2 = cbo_comp_info.Items.Count - 1;
					for (int i = 0; i <= tempForEndVar2; i++)
					{
						if (cbo_comp_info.GetItemData(i) == Reference_Comp_Id)
						{
							cbo_comp_info.SelectedIndex = i;
							break;
						}
					}

				}

				if (Reference_Comp_Id > 0)
				{
					FoundComp = false;

					int tempForEndVar3 = cbo_comp_info.Items.Count - 1;
					for (int i = 0; i <= tempForEndVar3; i++)
					{
						if (cbo_comp_info.GetItemData(i) == Reference_Comp_Id)
						{
							FoundComp = true;
							break;
						}
					}

					if (!FoundComp)
					{
						if (lst_comp_info.GetListItem(0).LastIndexOf("(") >= 0)
						{
							cbo_comp_info.AddItem(lst_comp_info.GetListItem(0).Substring(0, Math.Min(lst_comp_info.GetListItem(0).LastIndexOf("(") + 1 - 1, lst_comp_info.GetListItem(0).Length)));
							cbo_comp_info.SetItemData(cbo_comp_info.Items.Count - 1, Reference_Comp_Id);
							cbo_comp_info.SelectedIndex = cbo_comp_info.Items.Count - 1;
						}
						else
						{
							cbo_comp_info.AddItem($"Company ID: {Reference_Comp_Id.ToString()} not found.");
						}
					}
				}

				cbo_comp_info.Visible = true;
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"FillCboCompany_Error ({Information.Err().Number.ToString()}) {excep.Message}", "frm_Journal(FILLCBO)");
				this.Cursor = CursorHelper.CursorDefault;
			}

		}

		private void FillCboContact()
		{
			//
			// 7/17/03 - RTW - ADDED ERROR TRAPPING AND CHANGED TO ADO
			try
			{
				string Query = "";
				ADORecordSetHelper snpContact = new ADORecordSetHelper();
				bool ContInList = false;

				cbo_contact_info.Items.Clear();
				cbo_contact_info.AddItem("<None>");

				if (Reference_Comp_Id > 0)
				{

					if (lst_comp_info.Items.Count > 0)
					{

						Query = "SELECT contact_id, contact_journ_id,contact_last_name, contact_first_name, contact_title  FROM Contact WITH (NOLOCK) ";
						Query = $"{Query}WHERE (contact_comp_id = {Reference_Comp_Id.ToString()})  AND (contact_journ_id = 0) ";
						Query = $"{Query}AND (contact_active_flag = 'Y') "; //active flag - aey 7/30/04
						Query = $"{Query}ORDER BY contact_first_name, contact_last_name, contact_journ_id desc";

						snpContact.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

						if (!(snpContact.BOF && snpContact.EOF))
						{
							snpContact.MoveFirst();

							while(!snpContact.EOF)
							{
								ContInList = false;
								int tempForEndVar = cbo_contact_info.Items.Count - 1;
								for (int i = 0; i <= tempForEndVar; i++)
								{
									if (cbo_contact_info.GetItemData(i) == StringsHelper.ToDoubleSafe(($"{Convert.ToString(snpContact["contact_id"])}").Trim()))
									{
										ContInList = true;
										break;
									}
								}
								if (!ContInList)
								{
									cbo_contact_info.AddItem($"{($"{($"{Convert.ToString(snpContact["contact_first_name"])}").Trim()} {Convert.ToString(snpContact["contact_last_name"])}").Trim()} [{($"{Convert.ToString(snpContact["contact_title"])}").Trim()}]");
									cbo_contact_info.SetItemData(cbo_contact_info.Items.Count - 1, Convert.ToInt32(Double.Parse(($"{Convert.ToString(snpContact["contact_id"])}").Trim())));
									cbo_contact_info.Tag = "0";
								}
								snpContact.MoveNext();
							};

							if (Reference_Contact_Id > 0)
							{
								int tempForEndVar2 = cbo_contact_info.Items.Count - 1;
								for (int i = 0; i <= tempForEndVar2; i++)
								{
									if (cbo_contact_info.GetItemData(i) == Reference_Contact_Id)
									{
										cbo_contact_info.SelectedIndex = i;
										break;
									}
								}
							} // If Reference_Contact_Id > 0 Then

						} // If Not (snpContact.BOF And snpContact.EOF) Then

						cbo_contact_info.AddItem("Add New Contact");
						cbo_contact_info.Visible = true;

						snpContact.Close();

					} // If lst_comp_info.ListCount > 0 Then

				} // If Reference_Comp_Id > 0 Then

				snpContact = null;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"FillCBOContact_Error ({Information.Err().Number.ToString()}) {excep.Message}", "frm_Journal(FILLCBO)");
				return;
			}

		} // FillCboContact

		private void FillDocumentType()
		{

			string Query = "";
			ADORecordSetHelper snpDocType = new ADORecordSetHelper(); // Recordset aey 7/16/04 convereted to ado

			try
			{

				Query = "SELECT doctype_description  ";
				Query = $"{Query}FROM Document_Type WITH (NOLOCK) ";
				// 12/10/2007 - By David D. Cruger
				// Do not show contract document types here
				Query = $"{Query}WHERE (doctype_contract_doc_view = 'N') ";
				Query = $"{Query}AND (doctype_company_doc_view = 'N') ";
				Query = $"{Query}ORDER BY doctype_description";

				snpDocType.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

				cboDocumentType.Items.Clear();
				cboDocumentType.AddItem("<Other>");
				if (!(snpDocType.BOF && snpDocType.EOF))
				{

					while(!snpDocType.EOF)
					{

						cboDocumentType.AddItem(($"{Convert.ToString(snpDocType["doctype_description"])}").Trim());
						snpDocType.MoveNext();

					};
					cboDocumentType.SelectedIndex = 0;
				}

				snpDocType.Close();
				snpDocType = null;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"FillDocumentType_Error ({Information.Err().Number.ToString()}) {excep.Message}", "frm_Journal(FILLDOC)");
				return;
			}

		} // FillDocumentType

		private void FillNewSubCatCode()
		{

			string strQuery1 = "";
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();

			try
			{

				cboNewSubcategoryCode.Items.Clear();

				strQuery1 = "SELECT jcat_subcategory_code FROM Journal_Category WITH (NOLOCK) ";
				if (txt_journ_subcategory_code.Text.StartsWith("WS", StringComparison.Ordinal) || txt_journ_subcategory_code.Text.StartsWith("DP", StringComparison.Ordinal))
				{
					strQuery1 = $"{strQuery1}WHERE (jcat_subcategory_code LIKE 'WS%' OR jcat_subcategory_code LIKE 'DP%' OR jcat_subcategory_code LIKE 'FC%' OR jcat_subcategory_code LIKE 'SZ%') ";
					strQuery1 = $"{strQuery1}AND jcat_subcategory_code not like '%CORR' ";
				}
				else
				{
					strQuery1 = $"{strQuery1}WHERE (jcat_subcategory_code LIKE '{txt_journ_subcategory_code.Text.Substring(0, Math.Min(2, txt_journ_subcategory_code.Text.Length))}%') ";
				}

				strQuery1 = $"{strQuery1}ORDER BY jcat_subcategory_code";

				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					do 
					{
						cboNewSubcategoryCode.AddItem(($"{Convert.ToString(rstRec1["jcat_subcategory_code"])} ").Trim());
						rstRec1.MoveNext();
					}
					while(!rstRec1.EOF);

				} // If rstRec1.BOF = False And rstRec1.EOF = False Then

				rstRec1.Close();
				rstRec1 = null;

				int tempForEndVar = cboNewSubcategoryCode.Items.Count - 1;
				for (int lCnt1 = 0; lCnt1 <= tempForEndVar; lCnt1++)
				{
					if (cboNewSubcategoryCode.GetListItem(lCnt1) == txt_journ_subcategory_code.Text.Trim())
					{
						cboNewSubcategoryCode.SelectedIndex = lCnt1;
					}
				}
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"FillNewSubCatCode_Error ({Information.Err().Number.ToString()}) {excep.Message}", "frm_Journal(FILLSUBCAT)");
			}

		} // FillNewSubCatCode

		public int GetACRefCompID(int inJournID, string inType)
		{

			string strQuery1 = "";
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			int lResults = 0;

			try
			{

				lResults = 0;
				SellerReference = 0;
				PurchaserReference = 0;

				strQuery1 = "SELECT cref_id, cref_comp_id  FROM Aircraft_Reference WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (cref_journ_id = {inJournID.ToString()})  AND (cref_transmit_seq_no = {inType}) ";

				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					lResults = Convert.ToInt32(rstRec1["cref_comp_id"]);
					if (inType == "1")
					{
						SellerReference = Convert.ToInt32(rstRec1["cref_id"]);
					}
					if (inType == "10")
					{
						PurchaserReference = Convert.ToInt32(rstRec1["cref_id"]);
					}

				} // If (rstRec1.BOF = False And rstRec1.EOF = False) Then

				rstRec1.Close();
				rstRec1 = null;


				return lResults;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"GetACRefCompID_Error ({Information.Err().Number.ToString()}) {excep.Message}", "frm_Journal(GETID)");
			}
			return 0;
		} // GetACRefCompID

		public int GetYachtRefCompID(int inJournID, string inType)
		{

			string strQuery1 = "";
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			int lResults = 0;

			try
			{

				lResults = 0;
				SellerReference = 0;
				PurchaserReference = 0;

				strQuery1 = "SELECT yr_id, yr_comp_id  FROM Yacht_Reference WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (yr_journ_id = {inJournID.ToString()})  AND (yr_seq_no = {inType}) ";

				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					lResults = Convert.ToInt32(rstRec1["yr_comp_id"]);
					if (inType == "1")
					{
						SellerReference = Convert.ToInt32(rstRec1["yr_id"]);
					}
					if (inType == "10")
					{
						PurchaserReference = Convert.ToInt32(rstRec1["yr_id"]);
					}

				} // If (rstRec1.BOF = False And rstRec1.EOF = False) Then

				rstRec1.Close();
				rstRec1 = null;


				return lResults;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"GetYachtRefCompID_Error ({Information.Err().Number.ToString()}) {excep.Message}", "frm_Journal(GETID)");
			}
			return 0;
		} // GetYachtRefCompID

		private string GetTapeDate(int inACID, int inJournID, int inSeq)
		{

			string result = "";
			string Query = "";
			ADORecordSetHelper snpTDate = new ADORecordSetHelper(); //8/1/05 aey updated to ado

			try
			{

				result = "";

				Query = "SELECT faalog_tape_date  FROM FAA_Document_Log WITH(NOLOCK)";
				Query = $"{Query}WHERE faalog_ac_id = {inACID.ToString()}  AND faalog_journ_id = {inJournID.ToString()} ";
				Query = $"{Query}AND faalog_journ_seq_no = {inSeq.ToString()}";

				snpTDate.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpTDate.BOF && snpTDate.EOF))
				{
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snpTDate["faalog_tape_date"]))
					{
						if (Convert.ToString(snpTDate["faalog_tape_date"]).Trim() != modGlobalVars.cEmptyString && Information.IsDate(snpTDate["faalog_tape_date"]))
						{
							result = Convert.ToDateTime(snpTDate["faalog_tape_date"]).ToString("d");
						}
					}
				}

				snpTDate.Close();
				snpTDate = null;

				return result;
			}
			catch (System.Exception excep)
			{

				this.Cursor = CursorHelper.CursorDefault;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"GetTapeDate_Error ({Information.Err().Number.ToString()}) {excep.Message}", "frm_Journal(GETTAPE)");
				return result;
			}
		} // GetTapeDate

		private bool NeedsTransmit()
		{

			bool result = false;
			try
			{

				result = false;

				if ((tmp_journ_subcategory_code != txt_journ_subcategory_code.Text) || (tmp_journ_description != txt_journ_description.Text) || (tmp_journ_customer_note != txt_journ_customer_note.Text) || (tmp_journ_date != txt_journ_date.Text))
				{ //Or |     '(chk_New_to_Market.Value = vbChecked And tmp_journ_newmarket_flag = "N") Or |     '(chk_New_to_Market.Value = vbUnchecked And tmp_journ_newmarket_flag = "Y") Then


					if (Reference_Category_Code.Trim().ToUpper() == "AH" && Reference_SubCategory_Code.Trim().ToUpper() != "ACDOC" && Reference_SubCategory_Code.Trim().ToUpper() != "EXON" && Reference_SubCategory_Code.Trim().ToUpper() != "EXOFF" && Reference_SubCategory_Code.Trim().ToUpper() != "WOP")
					{

						result = true;

					}

				}

				return result;
			}
			catch (System.Exception excep)
			{

				this.Cursor = CursorHelper.CursorDefault;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"NeedsTransmit_Error ({Information.Err().Number.ToString()}) {excep.Message}", "frm_Journal(TRANS)");
				return result;
			}
		} // NeedsTransmit

		private bool CheckForNUTransaction(int inACID)
		{

			string Query = "";

			try
			{

				Query = "SELECT journ_newac_flag FROM Journal WITH(NOLOCK)";
				Query = $"{Query}WHERE journ_ac_id = {inACID.ToString()}  AND journ_newac_flag = 'Y'";
				if (Reference_Journal_ID > 0)
				{
					Query = $"{Query} AND journ_id <> {Reference_Journal_ID.ToString()}";
				}


				return modAdminCommon.Exist(Query);
			}
			catch (System.Exception excep)
			{

				this.Cursor = CursorHelper.CursorDefault;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"CheckForNUTransaction_Error ({Information.Err().Number.ToString()}) {excep.Message}", "frm_Journal(NEWTX)");
				return false;
			}
		} // CheckForNUTransaction

		private object UpdateBusinessTypes()
		{

			// FIX THE BUSINESS TYPES ON THE AIRCRAFT REFERENCE FILE
			string Query = "";

			try
			{

				if (cboNewSubcategoryCode.Text.Trim().Substring(Math.Max(cboNewSubcategoryCode.Text.Trim().Length - 4, 0)).ToUpper() != "CORR")
				{

					Query = $"UPDATE Aircraft_Reference SET cref_business_type = '{cboNewSubcategoryCode.Text.Trim().Substring(Math.Min(2, cboNewSubcategoryCode.Text.Trim().Length), Math.Min(2, Math.Max(0, cboNewSubcategoryCode.Text.Trim().Length - 2))).ToUpper()}' ";
					Query = $"{Query}WHERE cref_id = {SellerReference.ToString()}";

					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery(); //aey 7/16/04

					if (cboNewSubcategoryCode.Text.Trim().Substring(Math.Max(cboNewSubcategoryCode.Text.Trim().Length - 2, 0)).ToUpper() != "IT")
					{

						Query = $"UPDATE Aircraft_Reference SET cref_business_type = '{cboNewSubcategoryCode.Text.Trim().Substring(Math.Max(cboNewSubcategoryCode.Text.Trim().Length - 2, 0)).ToUpper()}' ";
						Query = $"{Query}WHERE cref_id = {PurchaserReference.ToString()}";

						DbCommand TempCommand_2 = null;
						TempCommand_2 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
						TempCommand_2.CommandText = Query;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand_2.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
						TempCommand_2.ExecuteNonQuery(); //aey 7/16/04

					}
				}
			}
			catch (System.Exception excep)
			{

				this.Cursor = CursorHelper.CursorDefault;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"UpdateBusinessTypes_Error ({Information.Err().Number.ToString()}) {excep.Message}", "frm_Journal(UPBUSTYPE)");
				return null;
			}

			return null;
		} // UpdateBusinessTypes


		public object UpdateJournalSubjectWithSellerPurchaserInfo(int lJournId, string strSubCatCode, ref string strSubject)
		{

			string strSellerName = ""; // Sellers Company Name
			string strPurchaserName = ""; // Purchasers Company Name
			string strPart1 = ""; // WS or DP
			string strPart2 = ""; // Sellers Code
			string strPart3 = ""; // Purchasers Code

			try
			{

				strSubCatCode = ($"{strSubCatCode} ").Trim();

				if ((lJournId != 0) && (strSubCatCode != ""))
				{

					strPart1 = strSubCatCode.Substring(Math.Min(0, strSubCatCode.Length), Math.Min(2, Math.Max(0, strSubCatCode.Length)));
					strPart2 = strSubCatCode.Substring(Math.Min(2, strSubCatCode.Length), Math.Min(2, Math.Max(0, strSubCatCode.Length - 2)));
					strPart3 = strSubCatCode.Substring(Math.Min(4, strSubCatCode.Length), Math.Min(2, Math.Max(0, strSubCatCode.Length - 4)));

					// All 3 Parts Must Have Valid Data
					if ((strPart1 != "") && (strPart2 != "") && (strPart3 != ""))
					{

						// Must be a Full Sale or a Delivery Position
						if ((strPart1 == "WS") || (strPart1 == "DP") || (strPart1 == "HS"))
						{

							if ($"{strPart2}{strPart3}" != "CORR")
							{

								strSellerName = modCommon.GetCompanyNameBySeqNo(lJournId, 1);
								strPurchaserName = modCommon.GetCompanyNameBySeqNo(lJournId, 10);

								// Only Special Condition for Subject is DP, AD
								if ((strPart2 == "DP") && (strPart3 == "AD"))
								{
									strPurchaserName = "DELIVERY POSITION HOLDER UNKNOWN";
								}

								if ((strSellerName != "") && (strPurchaserName != ""))
								{
									strSubject = $"Sold from {strSellerName} to {strPurchaserName}";
								}

								if ((strSellerName != "") && (strPurchaserName == ""))
								{
									strSubject = $"Sold from {strSellerName}";
								}

							} // If (strPart2 & strPart3 <> "CORR") Then

						} // If (strPart1 = "WS") Or (strPart1 = "DP") Then

					} // If (strPart1 <> "") And (strPart2 <> "") And (strPart3 <> "") Then

				} // If (ljournid <> 0) And (strSubCatCode <> "") Then
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"UpdateJournalSubjectWithSellerPurchaserInfo_Error ({Information.Err().Number.ToString()}) {excep.Message}", "frm_Journal(UPJOURN)");
				return null;
			}

			return null;
		} // UpdateJournalSubjectWithSellerPurchaserInfo


		private bool AddBusinessTypeToCurrentAndHistoricalCompanyRecord(int lcomp_id, int lcomp_journ_id, string strBusinessType)
		{

			bool result = false;
			string strQuery = ""; // Query String
			string strInsert = ""; // Insert String

			try
			{

				result = false;

				strBusinessType = ($"{strBusinessType} ").Trim();

				if ((lcomp_id != 0) && (lcomp_journ_id != 0) && (strBusinessType != ""))
				{ // All Three Are Valid
					//-------------------------------------------------
					// Check Current Company First
					//-------------------------------------------------
					strQuery = $"SELECT bustypref_id FROM Business_Type_Reference WITH(NOLOCK) WHERE (bustypref_comp_id = {(lcomp_id.ToString())}) ";
					strQuery = $"{strQuery}AND (bustypref_journ_id = 0)  AND (bustypref_type = '{strBusinessType} ') ";

					if (!modAdminCommon.Exist(strQuery))
					{ // Current Company Does NOT Have Business_Type_Reference

						strInsert = "INSERT INTO Business_Type_Reference (bustypref_comp_id, bustypref_journ_id, bustypref_type, bustypref_seq_no) ";
						strInsert = $"{strInsert}VALUES  ({lcomp_id.ToString()}, ";
						strInsert = $"{strInsert}0, ";
						strInsert = $"{strInsert}'{strBusinessType}', ";
						strInsert = $"{strInsert}{modCommon.GetNextBusTypeSeqNo(lcomp_id, 0).ToString()}) ";

						modAdminCommon.ADO_Transaction("BeginTrans");
						DbCommand TempCommand = null;
						TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
						TempCommand.CommandText = strInsert;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
						TempCommand.ExecuteNonQuery();
						modAdminCommon.ADO_Transaction("CommitTrans");

					} // If Exist(strQuery) = False Then ' Current Company Does NOT Have Business_Type_Reference


					strQuery = $"SELECT bustypref_id  FROM Business_Type_Reference WITH(NOLOCK) WHERE (bustypref_comp_id = {(lcomp_id.ToString())}) ";
					strQuery = $"{strQuery}AND (bustypref_journ_id = {(lcomp_journ_id.ToString())}) ";
					strQuery = $"{strQuery}AND (bustypref_type = '{strBusinessType} ') ";

					if (!modAdminCommon.Exist(strQuery))
					{ // Historical Company Does NOT Have Business_Type_Reference

						strInsert = "INSERT INTO Business_Type_Reference  (bustypref_comp_id, bustypref_journ_id, bustypref_type, bustypref_seq_no) ";
						strInsert = $"{strInsert}VALUES  ({lcomp_id.ToString()}, ";
						strInsert = $"{strInsert}{lcomp_journ_id.ToString()}, ";
						strInsert = $"{strInsert}'{strBusinessType}', ";
						strInsert = $"{strInsert}{modCommon.GetNextBusTypeSeqNo(lcomp_id, lcomp_journ_id).ToString()}) ";

						modAdminCommon.ADO_Transaction("BeginTrans");
						DbCommand TempCommand_2 = null;
						TempCommand_2 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
						TempCommand_2.CommandText = strInsert;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand_2.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
						TempCommand_2.ExecuteNonQuery();
						modAdminCommon.ADO_Transaction("CommitTrans");

					} // If Exist(strQuery) = False Then ' Historical Company Does NOT Have Business_Type_Reference

					result = true; // If here everything is ok

				} // If (lcomp_id <> 0) And (lcomp_journ_id <> 0) And (strBusinessType <> "") Then ' All Three Are Valid

				return result;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"UpdateJournalSubjectWithSellerPurchaserInfo_Error ({Information.Err().Number.ToString()}) {excep.Message}", "frm_Journal(ADDBUSTYPE)");
				modAdminCommon.ADO_Transaction("RollbackTrans");

				return result;
			}
		} // AddBusinessTypeToCurrentAndHistoricalCompanyRecord

		private void cbo_comp_info_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{

			cmd_Save.Enabled = false;

			if (!(snpComp.BOF && snpComp.EOF))
			{
				snpComp.MoveFirst();
				int tempForEndVar = cbo_comp_info.SelectedIndex - 1;
				for (int i = 1; i <= tempForEndVar; i++)
				{
					snpComp.MoveNext();
				}
			}

			Reference_Comp_Id = cbo_comp_info.GetItemData(cbo_comp_info.SelectedIndex);
			if (Reference_Comp_Id != current_comp_id)
			{
				Display_Company_Info();
			}
			cmd_Save.Enabled = true;

		} // cbo_comp_info_Click

		private void cbo_contact_info_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs)
		{

			frm_CompanyContact new_frm_CompanyContact = frm_CompanyContact.CreateInstance();
			string strSubject = "";
			string strDesc = "";
			string strCustNote = "";
			string strJDate = "";
			CheckState iInternal = CheckState.Unchecked;
			CheckState iNewtoMkt = CheckState.Unchecked;


			if (cbo_contact_info.Enabled)
			{

				strSubject = txt_journ_subject.Text;
				strDesc = txt_journ_description.Text;
				strCustNote = txt_journ_customer_note.Text;
				strJDate = txt_journ_date.Text;
				iInternal = chk_journ_internal_trans_flag.CheckState;
				iNewtoMkt = chk_New_to_Market.CheckState;

				cbo_contact_info.Enabled = false;

				if (Reference_Comp_Id > 0)
				{

					if (cbo_contact_info.SelectedIndex > 0)
					{

						if (cbo_contact_info.Text == "Add New Contact")
						{

							new_frm_CompanyContact.nContactID = -1;
							new_frm_CompanyContact.nJournID = 0;
							new_frm_CompanyContact.nCompanyID = cbo_comp_info.GetItemData(cbo_comp_info.SelectedIndex);
							new_frm_CompanyContact.CompanyName_Renamed = modCommon.GetCompanyName(new_frm_CompanyContact.nCompanyID, new_frm_CompanyContact.nJournID);
							new_frm_CompanyContact.ServicesUsed = modCommon.GetCompanyServiceName(new_frm_CompanyContact.nCompanyID, new_frm_CompanyContact.nJournID, modGlobalVars.ServicesUsed_Array);

							this.Cursor = Cursors.WaitCursor;

							new_frm_CompanyContact.ShowDialog();

							new_frm_CompanyContact = null;

							//----------------------------------------------------
							// Get The CompId On The Contact Just Added

							Reference_Contact_Id = Convert.ToInt32(Double.Parse(modCommon.DLookUp("contact_id", "Contact", $"(contact_comp_id = {Reference_Comp_Id.ToString()}) AND (contact_journ_id = 0) AND (contact_active_flag='Y') ORDER BY contact_id DESC")));

							FillCboContact();

							Display_Contact_Info();

							txt_journ_subject.Text = strSubject;
							txt_journ_description.Text = strDesc;
							txt_journ_customer_note.Text = strCustNote;
							txt_journ_date.Text = strJDate;
							chk_journ_internal_trans_flag.CheckState = iInternal;
							chk_New_to_Market.CheckState = iNewtoMkt;

						}
						else
						{

							Reference_Contact_Id = cbo_contact_info.GetItemData(cbo_contact_info.SelectedIndex);

							if (Reference_Contact_Id != current_contact_id)
							{
								Display_Contact_Info();
							}

						} // If cbo_contact_info.Text = "Add New Contact" Then

					} // If cbo_contact_info.ListIndex > 0 Then

					if (cbo_contact_info.SelectedIndex == 0)
					{
						lst_contact_info.Items.Clear();
						Reference_Contact_Id = 0;
					}

				} // If Reference_Comp_Id > 0 Then

				cbo_contact_info.Enabled = true;

			} // If cbo_contact_info.Enabled = True Then

		} // cbo_contact_info_Click

		private void cbo_journ_cat_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs)
		{

			if (cbo_journ_cat.Visible)
			{
				cbp_journ_sub_type.Visible = false;
				if (cbo_journ_cat.Text.Trim() == "IQ")
				{
					modFillCompConControls.fill_journ_auto_subject_List(cbp_journ_sub_type, "IQ", "Journal");
					cbp_journ_sub_type.Visible = true;
					Reference_SubCategory_Code = "IQ";
				}
				else if (cbo_journ_cat.Text.Trim() == "REGCHK")
				{ 
					modFillCompConControls.fill_journ_auto_subject_List(cbp_journ_sub_type, "REGCHK", "Journal");
					cbp_journ_sub_type.Visible = true;
					Reference_SubCategory_Code = "REGCHK";
				}
				else if (cbo_journ_cat.Text.Trim() == "DOCAT")
				{ 
					modFillCompConControls.fill_journ_auto_subject_List(cbp_journ_sub_type, "DOCAT", "Journal");
					cbp_journ_sub_type.Visible = true;
					Reference_SubCategory_Code = "DOCAT";
					txt_journ_subject.Text = cbp_journ_sub_type.Text;
				}
				else if (cbo_journ_cat.Text.Trim() == "RVEAT")
				{ 
					modFillCompConControls.fill_journ_auto_subject_List(cbp_journ_sub_type, "RVEAT", "Journal");
					cbp_journ_sub_type.Visible = true;
					Reference_SubCategory_Code = "RVEAT";
					txt_journ_subject.Text = cbp_journ_sub_type.Text;
				}
				else if (cbo_journ_cat.Text.Trim() == "RADN")
				{ 
					modFillCompConControls.fill_journ_auto_subject_List(cbp_journ_sub_type, "RADN", "Journal");
					cbp_journ_sub_type.Visible = true;
					Reference_SubCategory_Code = "RADN";
					txt_journ_subject.Text = cbp_journ_sub_type.Text;
				}
				else if (cbo_journ_cat.Text.Trim() == "PB")
				{ 
					modFillCompConControls.fill_journ_auto_subject_List(cbp_journ_sub_type, "PB", "Journal");
					cbp_journ_sub_type.Visible = true;
					Reference_SubCategory_Code = "PBNOTE";
					txt_journ_subject.Text = cbp_journ_sub_type.Text;
				}
				else if (cbo_journ_cat.Text.Trim() == "SPEC")
				{ 
					modFillCompConControls.fill_journ_auto_subject_List(cbp_journ_sub_type, "SPEC", "Journal");
					cbp_journ_sub_type.Visible = true;
					Reference_SubCategory_Code = "SPEC";
					txt_journ_subject.Text = cbp_journ_sub_type.Text;
				}
				else if (cbo_journ_cat.Text.Trim() == "IDNOTE")
				{ 
					modFillCompConControls.fill_journ_auto_subject_List(cbp_journ_sub_type, "IDNOTE", "Journal");
					cbp_journ_sub_type.Visible = true;
					Reference_SubCategory_Code = "IDNOTE";
					cbp_journ_sub_type.Text = "IDNOTE - Attempted to ID";
					txt_journ_subject.Text = cbp_journ_sub_type.Text;
				}
				else if (cbo_journ_cat.Text.Trim() == "PROJ")
				{ 
					modFillCompConControls.fill_journ_auto_subject_List(cbp_journ_sub_type, "PROJ", "Journal");
					// cbp_journ_sub_type.Visible = True
					Reference_SubCategory_Code = "PROJ";
					txt_journ_subject.Text = cbp_journ_sub_type.Text;
				}
				else if (cbo_journ_cat.Text.Trim() == "MEMO")
				{ 
					modFillCompConControls.fill_journ_auto_subject_List(cbp_journ_sub_type, "MEMO", "Journal");
					cbp_journ_sub_type.Visible = true;
					Reference_SubCategory_Code = "MEMO";
					txt_journ_subject.Text = cbp_journ_sub_type.Text;

				}
				else if (cbo_journ_cat.Text.Trim() == "RN")
				{ 
					Reference_SubCategory_Code = "RN";
				}
			}


		}


		private void cbo_New_TransType_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{

			if (cbo_New_TransType.Text.Trim() != modGlobalVars.cEmptyString)
			{
				frame_BuyerSeller.Visible = true;
				cmd_MajorChange.Visible = true;
				chk_ApplytoCurrent_CheckStateChanged(chk_ApplytoCurrent, new EventArgs());
				txt_Purchaser_Percent.Visible = cbo_New_TransType.Text.Trim().ToLower() == ("Share Sale").ToLower() || cbo_New_TransType.Text.Trim().ToLower() == ("Fractional Sale").ToLower();
			}
			else
			{
				frame_BuyerSeller.Visible = false;
				cmd_MajorChange.Visible = false;
			}

		} // cbo_New_TransType_Click

		private void cboDocumentType_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{

			if (cboDocumentType.SelectedIndex == 0)
			{
				txt_journ_subject.Enabled = true;
			}
			else
			{
				txt_journ_subject.Text = cboDocumentType.Text;
				txt_journ_subject.Enabled = false;
			}

		} // cboDocumentType_Click

		private void cboNewSubcategoryCode_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{

			int BuyerID = 0;
			int SellerID = 0;

			if (Reference_Ac_Id > 0)
			{
				BuyerID = GetACRefCompID(Convert.ToInt32(Double.Parse(txt_journ_id.Text)), "10");
				SellerID = GetACRefCompID(Convert.ToInt32(Double.Parse(txt_journ_id.Text)), "1");
			}
			if (Reference_Yacht_Id > 0)
			{
				BuyerID = GetYachtRefCompID(Convert.ToInt32(Double.Parse(txt_journ_id.Text)), "10");
				SellerID = GetYachtRefCompID(Convert.ToInt32(Double.Parse(txt_journ_id.Text)), "1");
			}

			txt_journ_subject.Text = modCommon.BuildJournalSubject(cboNewSubcategoryCode.Text, SellerID, Convert.ToInt32(Double.Parse(txt_journ_id.Text)), BuyerID, Convert.ToInt32(Double.Parse(txt_journ_id.Text)));

			if (BuyerID == 0 || SellerID == 0)
			{
				MessageBox.Show($"Warning!{Environment.NewLine}The Subject Line was not properly fixed.{Environment.NewLine}Please report this problem to Tech", "Journal", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			if (cboNewSubcategoryCode.Text.Trim().Substring(Math.Max(cboNewSubcategoryCode.Text.Trim().Length - 2, 0)).ToUpper() == "IT")
			{
				chk_journ_internal_trans_flag.Enabled = true;
				chk_journ_internal_trans_flag.CheckState = CheckState.Checked;
			}

		} // cboNewSubcategoryCode_Click

		private void cbp_journ_sub_type_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs)
		{


			if (cbp_journ_sub_type.Visible && cbp_journ_sub_type.Text.Trim() != "")
			{
				txt_journ_subject.Text = cbp_journ_sub_type.Text.Trim();
			}


		}

		private void chk_ApplytoCurrent_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{

			if (chk_ApplytoCurrent.CheckState == CheckState.Checked)
			{
				txt_Current_Seller_Percent.Visible = true;
				txt_Current_Purchaser_Percent.Visible = true;
			}
			else
			{
				txt_Current_Seller_Percent.Visible = false;
				txt_Current_Purchaser_Percent.Visible = false;
			}

		} // chk_ApplytoCurrent_Click

		private void chk_journ_internal_trans_flag_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{

			if (chk_journ_internal_trans_flag.Enabled)
			{

				if (Reference_Yacht_Id > 0)
				{

					if (chk_journ_internal_trans_flag.CheckState == CheckState.Checked)
					{

						if (!txt_journ_subject.Text.StartsWith("Internal ", StringComparison.Ordinal))
						{
							txt_journ_subject.Text = $"Internal {txt_journ_subject.Text}";
						}

					}
					else
					{

						if (txt_journ_subject.Text.StartsWith("Internal ", StringComparison.Ordinal))
						{
							txt_journ_subject.Text = txt_journ_subject.Text.Substring(Math.Min(9, txt_journ_subject.Text.Length));
						}

					} // If chk_journ_internal_trans_flag.Value = vbChecked Then

				} // If Reference_Yacht_Id > 0 Then

			} // If chk_journ_internal_trans_flag.Enabled = True Then

		} // chk_journ_internal_trans_flag_Click

		private void chk_New_to_Market_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{

			if (chk_New_to_Market.CheckState == CheckState.Checked && !ClickSkip)
			{
				if (CheckForNUTransaction(Reference_Ac_Id))
				{
					MessageBox.Show("NU Transaction Already Exists For This Aircraft", "Journal", MessageBoxButtons.OK, MessageBoxIcon.Information);
					chk_New_to_Market.CheckState = CheckState.Unchecked;
				}
			}

		} // chk_New_to_Market_Click

		private void cmd_cancel_Click(Object eventSender, EventArgs eventArgs)
		{

			Reference_Category_Code = "";
			Reference_SubCategory_Code = "";
			Reference_Subject = "";

			this.Close();

		} // cmd_cancel_Click

		private void cmd_Change_Trans_Type_Click(Object eventSender, EventArgs eventArgs) => Display_MajorChangeFrame();


		private void cmd_Major_Cancel_Click(Object eventSender, EventArgs eventArgs) => frame_MajorChange.Visible = false;


		private void cmd_MajorChange_Click(Object eventSender, EventArgs eventArgs)
		{

			ADORecordSetHelper snpRefs = new ADORecordSetHelper(); //8/1/05 aey converted to ado
			string Query = "";
			double CountPercent = 0;

			try
			{

				if (Conversion.Val(txt_Purchaser_Percent.Text.Trim()) == 0)
				{
					MessageBox.Show("Percentage field for the purchaser must be a number > 0.", "Journal:MajorChange", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				// IF THE CHANGE APPLIES TO THE CURRENT AIRCRAFT
				if (chk_ApplytoCurrent.CheckState == CheckState.Checked)
				{
					if (Conversion.Val(txt_Current_Purchaser_Percent.Text.Trim()) == 0)
					{
						MessageBox.Show("Percentage field for current owner must be a number > 0", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						return;
					}
					if (Conversion.Val(txt_Current_Seller_Percent.Text.Trim()) == 0)
					{
						MessageBox.Show("Percentage field for the seller being placed onto the current aircraft must be a number >0.", "Journal:MajorChange", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

					// DETERMINE IF THIS WILL LEAVE THE AIRCRAFT WITH 100% OWNERSHIP
					Query = $"Select * from Aircraft_Reference WITH(NOLOCK) where cref_ac_id = {Reference_Ac_Id.ToString()}";
					Query = $"{Query} AND cref_journ_id = 0";
					switch(cbo_New_TransType.Text.Substring(0, Math.Min(1, cbo_New_TransType.Text.Length)))
					{
						case "W" : 
							 
							break;
						case "S" : 
							Query = $"{Query} and (cref_contact_type='08')"; 
							 
							break;
						case "F" : 
							Query = $"{Query} and (cref_contact_type='97 or cref_contact_type='17')"; 
							 
							break;
					}

					snpRefs.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!(snpRefs.BOF && snpRefs.EOF))
					{


						while(!snpRefs.EOF)
						{
							if (Convert.ToString(snpRefs["cref_contact_type"]) == "00")
							{
								CountPercent += 100;
							}
							else
							{
								CountPercent += Conversion.Val($"{Convert.ToString(snpRefs["cref_owner_percent"])}");
							}
							snpRefs.MoveNext();
						};
					}

					snpRefs.Close();
					snpRefs = null;

					CountPercent = CountPercent + Conversion.Val(txt_Current_Purchaser_Percent.Text.Trim()) + Conversion.Val(txt_Current_Seller_Percent.Text.Trim());

					if (Convert.ToInt32(CountPercent) == 100)
					{
						// CALL THE TRANSACTION CHANGE PROCEDURE
						Change_Transaction_Type();
					}
					else
					{
						MessageBox.Show("Unable to complete transaction type change.  The would not result in 100% ownership of the aircraft.", "Journal:MajorChange", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				else
				{
					Change_Transaction_Type();
				} // IF CHANGING THE CURRENT AIRCRAFT
			}
			catch (System.Exception excep)
			{

				this.Cursor = CursorHelper.CursorDefault;
				snpRefs = null;

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"cmd_MajorChange_Error ({Information.Err().Number.ToString()}) {excep.Message}", "frm_Journal(MAJORCHANGE)");
				return;
			}

		} // cmd_MajorChange_Click

		private void cmd_Save_Click(Object eventSender, EventArgs eventArgs)
		{
			// THIS PROCEDURE DETERMINES WHETHER TO UPDATE
			// OR ADD A JOURNAL ENTRY
			int comp_id1 = 0;
			int contact_id1 = 0;
			string journ_subject1 = "";
			int ac_id1 = 0;

			if (txt_journ_subject.Text.Trim() == "")
			{
				MessageBox.Show("You must have a Subject", "Journal", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{

				modGlobalVars.RefreshACFromJournal = true;

				if (Reference_Journal_ID > 0)
				{
					Update_Journal_Record();

					if (Original_Company_ID == 0)
					{
						if (txt_journ_subcategory_code.Text.Trim() == "DOCAT")
						{
							if (cbo_comp_info.GetItemData(cbo_comp_info.SelectedIndex) > 0)
							{
								comp_id1 = cbo_comp_info.GetItemData(cbo_comp_info.SelectedIndex);
								if (cbo_contact_info.SelectedIndex > 0)
								{
									contact_id1 = cbo_contact_info.GetItemData(cbo_contact_info.SelectedIndex);
								}
								else
								{
									contact_id1 = 0;
								}

								ac_id1 = Reference_Ac_Id;
								journ_subject1 = modAdminCommon.Rec_Journal_Info.journ_subject;
							}

							if (comp_id1 > 0)
							{
								do_last_attempted_comp(comp_id1, contact_id1, journ_subject1, ac_id1);
							}
						}
					}


				}
				else
				{
					Populate_Journal_Entry();

					ac_id1 = 0;
					comp_id1 = 0;
					contact_id1 = 0;
					journ_subject1 = "";

					if (modAdminCommon.Rec_Journal_Info.journ_subcategory_code.Trim() == "DOCAT")
					{
						if (modAdminCommon.Rec_Journal_Info.journ_comp_id > 0)
						{
							comp_id1 = modAdminCommon.Rec_Journal_Info.journ_comp_id;
							contact_id1 = modAdminCommon.Rec_Journal_Info.journ_contact_id;
							ac_id1 = modAdminCommon.Rec_Journal_Info.journ_ac_id;
							journ_subject1 = modAdminCommon.Rec_Journal_Info.journ_subject;
						}

					}


					Commit_Journal_Entry();

					// then its a DOCAT and we need to do the doc attempted for the company - MSW - 4/13/22
					if (comp_id1 > 0)
					{
						do_last_attempted_comp(comp_id1, contact_id1, journ_subject1, ac_id1);
					}

				}

				if (!DataNotValid)
				{
					this.Close();
				}
				else
				{
					DataNotValid = false;
				}

			}

		} // cmd_Save_Click

		public object do_last_attempted_comp(int comp_id, int contact_id, string journ_Description, int ac_id1)
		{

			string strToday = DateTime.Now.ToString("d");
			//

			string Query = $"UPDATE Company SET comp_last_contact_date = '{strToday.Trim()}'";
			Query = $"{Query} WHERE comp_id = {comp_id.ToString()} AND comp_journ_id = 0 ";

			modAdminCommon.ADO_Transaction("BeginTrans");

			DbCommand TempCommand = null;
			TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
			UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
			TempCommand.CommandText = Query;
			//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
			TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
			UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
			TempCommand.ExecuteNonQuery();


			modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(strToday.Trim());
			modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "RN";
			modAdminCommon.Rec_Journal_Info.journ_subject = "Attempted to Contact";
			modAdminCommon.Rec_Journal_Info.journ_description = journ_Description;
			modAdminCommon.Rec_Journal_Info.journ_ac_id = 0; // commented out - not to AC
			modAdminCommon.Rec_Journal_Info.journ_comp_id = comp_id;

			if (contact_id > 0)
			{
				modAdminCommon.Rec_Journal_Info.journ_contact_id = contact_id;
			}
			else
			{
				modAdminCommon.Rec_Journal_Info.journ_contact_id = 0;
			}

			modAdminCommon.Rec_Journal_Info.journ_account_id = ""; // Trim$(cbo_comp_account(COMP_ACCOUNT_REP).Text)
			modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
			modAdminCommon.Rec_Journal_Info.journ_status = "A";

			frm_Journal.DefInstance.Commit_Journal_Entry();

			modAdminCommon.ADO_Transaction("CommitTrans");

			return null;
		}

		private void cmdCancelAddContact_Click(Object eventSender, EventArgs eventArgs)
		{

			pnl_AddContact.Visible = false;
			pnl_Contact.Visible = true;

			cbo_comp_info_SelectedIndexChanged(cbo_comp_info, new EventArgs());

		} // cmdCancelAddContact_Click

		private void cmdDelete_Click(Object eventSender, EventArgs eventArgs)
		{

			string Query = "";
			bool SendtoWeb = false;
			string strNoteType = "";

			try
			{

				if (MessageBox.Show("Are you sure you want to delete this journal entry?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
				{
					// IF IT IS A LEASE EXPIRATION - MAKE SURE THAT IT USES THE FUNCTION
					// FOR DELETING TRANSACTIONS

					SendtoWeb = modCommon.GetTransWeb($"{txt_journ_subcategory_code.Text}");

					//If Trim(txt_journ_subcategory_code) = "LX" Or Trim(txt_journ_subcategory_code) = "CMAKE" Or Trim(txt_journ_subcategory_code) = "CNAME" Then

					if (SendtoWeb || txt_journ_subcategory_code.Text.Trim() == "YONM")
					{

						if (Reference_Ac_Id > 0)
						{
							modCommon.Delete_Transaction(Reference_Ac_Id, Reference_Journal_ID);
							MessageBox.Show("Journal Entry Deleted Successfully.", "Journal: Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
							cmd_cancel_Click(cmd_Cancel, new EventArgs());
						}
						else if (Reference_Yacht_Id > 0)
						{ 
							modCommon.Delete_Yacht_Transaction(Reference_Yacht_Id, Reference_Journal_ID);
							MessageBox.Show("Journal Entry Deleted Successfully.", "Journal: Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
							cmd_cancel_Click(cmd_Cancel, new EventArgs());
						}
						else
						{

							strNoteType = $"Delete {txt_category.Text.Trim()}: {txt_journ_subject.Text.Trim()}";

							Query = $"DELETE FROM Journal WHERE journ_id = {Reference_Journal_ID.ToString()}";

							modAdminCommon.ADO_Transaction("BeginTrans");
							DbCommand TempCommand = null;
							TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
							TempCommand.CommandText = Query;
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
							TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
							TempCommand.ExecuteNonQuery();
							modAdminCommon.ADO_Transaction("CommitTrans");

							// 05/28/2008 - By David D. Cruger
							// When deleting a Journal Note must include the CompId
							// RN=Research Note, MN=Marketing Note, TN=Tecnical Note
							//
							modAdminCommon.Record_Event("Journal", strNoteType, Reference_Ac_Id, Reference_Journal_ID, Reference_Comp_Id);

							MessageBox.Show("Journal Entry Deleted Successfully.", "Journal: Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);

							cmd_cancel_Click(cmd_Cancel, new EventArgs());

							modGlobalVars.RefreshACFromJournal = true;

						}

					}
					else
					{

						strNoteType = $"Delete {txt_category.Text.Trim()}: {txt_journ_subject.Text.Trim()}";

						// JUST DELETE THE JOURNAL ENTRY
						Query = $"DELETE FROM Journal WHERE journ_id = {Reference_Journal_ID.ToString()}";

						modAdminCommon.ADO_Transaction("BeginTrans");
						DbCommand TempCommand_2 = null;
						TempCommand_2 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
						TempCommand_2.CommandText = Query;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand_2.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
						TempCommand_2.ExecuteNonQuery();
						modAdminCommon.ADO_Transaction("CommitTrans");

						// 05/28/2008 - By David D. Cruger
						// When deleting a Journal Note must include the CompId
						// If it was attached. Also based on the SubCategory the Note Type May Change
						// RN=Research Note, MN=Marketing Note, TN=Tecnical Note
						//
						modAdminCommon.Record_Event("Journal", strNoteType, Reference_Ac_Id, Reference_Journal_ID, Reference_Comp_Id);

						MessageBox.Show("Journal Entry Deleted Successfully.", "Journal: Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);

						cmd_cancel_Click(cmd_Cancel, new EventArgs());

						modGlobalVars.RefreshACFromJournal = true;
					}

				}
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"cmdDelete_Click_Error ({Information.Err().Number.ToString()}) {excep.Message} : ACID[{Reference_Ac_Id.ToString()}] CMPID[{Reference_Comp_Id.ToString()}] JID[{Reference_Journal_ID.ToString()}]", "frm_journal(DELETE)");
				modAdminCommon.ADO_Transaction("RollbackTrans");

				return;
			}

		} // cmdDelete_Click

		private void cmdDocuments_Click(Object eventSender, EventArgs eventArgs)
		{

			Form Frm = null;
			Form f = null;

			// cleanup any aircraft forms and open a clean form
			modCommon.Unload_Form("frm_Transaction_Documents");
			modAdminCommon.gbl_Aircraft_ID = Reference_Ac_Id;
			frm_Transaction_Documents.DefInstance.Startup_Document = cboDocumentType.Text;
			frm_Transaction_Documents.DefInstance.Transaction_Date = DateTime.Parse(txt_journ_date.Text.Trim()).ToString("d");
			frm_Transaction_Documents.DefInstance.Journal_ID = Reference_Journal_ID;
			frm_Transaction_Documents.DefInstance.Entry_Point = "Journal";

			this.Hide();

			modGlobalVars.bKeepTransactionFocus = true;

			frm_Transaction_Documents.DefInstance.Show();
			frm_Transaction_Documents.DefInstance.Activate();

			this.Close();

		} // cmdDocuments_Click

		private void cmdSaveAddContact_Click(Object eventSender, EventArgs eventArgs)
		{

			InsertContact();
			cmdCancelAddContact_Click(cmdCancelAddContact, new EventArgs());
			pnl_AddContact.Visible = false;
			pnl_Contact.Visible = true;

		} // cmdSaveAddContact_Click

		private void InsertContact()
		{

			string Query = "";
			ADORecordSetHelper snp_NextContactid = new ADORecordSetHelper(); //8/1/05 aey converted to ado
			int nMaxId = 0;

			try
			{

				Query = "select max(contact_id) as max_contact_id from Contact WITH(NOLOCK)";

				snp_NextContactid.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				nMaxId = 1;
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(snp_NextContactid["max_contact_id"]))
				{
					if (Convert.ToInt32(snp_NextContactid["max_contact_id"]) > 0)
					{
						nMaxId = Convert.ToInt32(snp_NextContactid["max_contact_id"]) + 1;
					}
				}

				snp_NextContactid.Close();
				snp_NextContactid = null;

				Query = "INSERT INTO Contact (contact_id,";
				Query = $"{Query}contact_journ_id,contact_comp_id,";
				Query = $"{Query}contact_sirname,contact_last_name,contact_first_name,";
				Query = $"{Query}contact_middle_initial,contact_suffix,";
				Query = $"{Query}contact_email_address,contact_title,";
				Query = $"{Query}contact_active_flag, contact_user_id)"; // 05/25/2018 - By David D. Cruger; Added

				Query = $"{Query} values ({nMaxId.ToString()}, 0,";
				Query = $"{Query}{Reference_Comp_Id.ToString()} ,";
				Query = $"{Query}'{modAdminCommon.Fix_Quote(cbo_contact_sirname.Text).Trim()}',";
				Query = $"{Query}'{modAdminCommon.Fix_Quote(txt_cont_last_name.Text).Trim()}',";
				Query = $"{Query}'{modAdminCommon.Fix_Quote(txt_cont_first_name.Text).Trim()}',";
				Query = $"{Query}'{modAdminCommon.Fix_Quote(txt_cont_middle_initial.Text).Trim()}',";
				Query = $"{Query}'{modAdminCommon.Fix_Quote(cbo_contact_suffix.Text).Trim()}',";
				Query = $"{Query}'{modAdminCommon.Fix_Quote(txt_contact_email_address.Text).Trim()}',";
				Query = $"{Query}'{modAdminCommon.Fix_Quote(cboNewContactTitle.Text).Trim()}',";
				Query = $"{Query}'A',";
				Query = $"{Query}'{modAdminCommon.gbl_User_ID}')"; // 05/25/2018 - By David D. Cruger; Added

				modAdminCommon.ADO_Transaction("BeginTrans");
				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();
				modAdminCommon.ADO_Transaction("CommitTrans");

				Reference_Contact_Id = nMaxId;

				Display_Contact_Info();
				cbo_comp_info_SelectedIndexChanged(cbo_comp_info, new EventArgs());
			}
			catch (System.Exception excep)
			{

				this.Cursor = CursorHelper.CursorDefault;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"InsertContact_Error ({Information.Err().Number.ToString()}) {excep.Message}", "frm_Journal(ADDCONTACT)");
				modAdminCommon.ADO_Transaction("RollbackTrans");
			}

		} // InsertContact

		private void Form_Activated(Object eventSender, EventArgs eventArgs)
		{
			if (ActivateHelper.myActiveForm != eventSender)
			{
				ActivateHelper.myActiveForm = (Form) eventSender;


				try
				{

					if (!gbAlreadyLoaded)
					{

						this.WindowState = FormWindowState.Normal;

						frame_MajorChange.Visible = false;
						cmd_MajorChange.Visible = false;

						nRefJournalID = 0;
						nRefJcat_subcategory_name = "";

						snp_Journal = null;
						snpComp = null;

						if (ReflectionHelper.GetCursorValueForcedToInteger(this.Cursor) != 0)
						{
							this.Cursor = CursorHelper.CursorDefault;
						}

						ClickSkip = true;

						if (Reference_Journal_ID > 0)
						{

							Display_Journal_Entry();

							CheckPermission();

							if (txt_journ_subcategory_code.Text.Trim().ToUpper() == ("ACDOC").ToUpper())
							{
								FillDocumentType();
								cboDocumentType.Visible = true;

								int tempForEndVar = cboDocumentType.Items.Count - 1;
								for (int i = 0; i <= tempForEndVar; i++)
								{
									if (txt_journ_subject.Text.Trim().ToUpper() == cboDocumentType.GetListItem(i).Trim().ToUpper())
									{
										cboDocumentType.SelectedIndex = i;
										break;
									}
								}

								if (txt_journ_subject.Text.Trim().ToUpper() != cboDocumentType.Text.Trim().ToUpper())
								{
									cboDocumentType.SelectedIndex = 0;
								}
							}

						}
						else
						{

							Reference_Contact_Id = 0;
							Display_Journal_Entry_Form();

						}

						ClickSkip = false;

						Load_Check_Box_Asked_For_Sold_Price();

						modCommon.CenterFormOnHomebaseMainForm(this);

						modAdminCommon.Record_Event("Monitor Activity", "User Loaded Journal Record End");

						gbAlreadyLoaded = true;

					} // If gbAlreadyLoaded = False Then

					return;
				}
				catch (System.Exception excep)
				{

					this.Cursor = CursorHelper.CursorDefault;
					//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
					modAdminCommon.Report_Error($"Journal_Form_Activate_Error ({Information.Err().Number.ToString()}) {excep.Message}", "frm_journal(ACTIVATE)");
				}
			}
		} // Form_Activate

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
		private void Form_Load()
		{

			try
			{

				gbAlreadyLoaded = false;

				this.WindowState = FormWindowState.Normal;

				frame_MajorChange.Visible = false;
				cmd_MajorChange.Visible = false;
				modAdminCommon.Record_Event("Monitor Activity", "User Loaded Journal Record");

				snp_Journal = null;
				snpComp = null;

				modCommon.CenterFormOnHomebaseMainForm(this);
			}
			catch (System.Exception excep)
			{

				this.Cursor = CursorHelper.CursorDefault;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Journal_Form_Load_Error ({Information.Err().Number.ToString()}) {excep.Message}", "frm_journal(LOAD)");
			}

		} // Form_Load

		private void Load_Check_Box_Asked_For_Sold_Price()
		{

			string strEventId1 = "";
			string strQuery1 = "";

			string strEventId2 = "";
			string strQuery2 = "";

			int lEventId1 = 0;
			int lEventId2 = 0;

			chkAskedForSoldPriceRefused.CheckState = CheckState.Unchecked;
			chkAskedForSoldPrice.CheckState = CheckState.Unchecked;

			if (Reference_Ac_Id > 0)
			{

				strQuery1 = $"(evtl_ac_id = {Reference_Ac_Id.ToString()}) ";
				strQuery1 = $"{strQuery1}AND (evtl_journ_id = {Reference_Journal_ID.ToString()}) ";
				strQuery1 = $"{strQuery1}AND (evtl_type = 'Sold Price Refused') ";
				strQuery1 = $"{strQuery1}AND (evtl_date >= '{txt_journ_date.Text}') ";

				strEventId1 = modCommon.DLookUp("evtl_id", "EventLog", strQuery1);

				strQuery2 = $"(evtl_ac_id = {Reference_Ac_Id.ToString()})  AND (evtl_journ_id = {Reference_Journal_ID.ToString()}) ";
				strQuery2 = $"{strQuery2}AND (evtl_type = 'Asked For Sold Price') ";
				strQuery2 = $"{strQuery2}AND (evtl_date >= '{txt_journ_date.Text}') ";

				strEventId2 = modCommon.DLookUp("evtl_id", "EventLog", strQuery2);

			} // If Reference_Ac_Id > 0 Then

			if (Reference_Yacht_Id > 0)
			{

				strQuery1 = $"(evtl_yacht_id = {Reference_Yacht_Id.ToString()})  AND (evtl_journ_id = {Reference_Journal_ID.ToString()}) ";
				strQuery1 = $"{strQuery1}AND (evtl_type = 'Sold Price Refused') ";
				strQuery1 = $"{strQuery1}AND (evtl_date >= '{txt_journ_date.Text}') ";

				strEventId1 = modCommon.DLookUp("evtl_id", "EventLog", strQuery1);

				strQuery2 = $"(evtl_yacht_id = {Reference_Yacht_Id.ToString()})  AND (evtl_journ_id = {Reference_Journal_ID.ToString()}) ";
				strQuery2 = $"{strQuery2}AND (evtl_type = 'Asked For Sold Price') ";
				strQuery2 = $"{strQuery2}AND (evtl_date >= '{txt_journ_date.Text}') ";

				strEventId2 = modCommon.DLookUp("evtl_id", "EventLog", strQuery2);

			} // If Reference_Yacht_Id > 0 Then

			if (strEventId1 != "")
			{
				lEventId1 = Convert.ToInt32(Double.Parse(strEventId1));
			}
			if (strEventId2 != "")
			{
				lEventId2 = Convert.ToInt32(Double.Parse(strEventId2));
			}

			if (lEventId1 > 0)
			{
				chkAskedForSoldPriceRefused.CheckState = CheckState.Checked;
			}
			if (lEventId2 > 0)
			{
				chkAskedForSoldPrice.CheckState = CheckState.Checked;
			}

			lAFSPREventId = lEventId1; // Asked For Sold Price Refused
			lAFSPEventId = lEventId2; // Asked For Sold Price

		} // Load_Check_Box_Asked_For_Sold_Price

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{

			string strDelete1 = "";

			try
			{

				snp_Journal = null;
				snpComp = null;

				Reference_Category_Code = "";
				Reference_SubCategory_Code = "";
				Reference_Subject = "";

				if (lAFSPREventId == 0 && chkAskedForSoldPriceRefused.CheckState == CheckState.Checked)
				{
					modAdminCommon.Record_Event("Sold Price Refused", "Asked For Sold Price - Refused", Reference_Ac_Id, Reference_Journal_ID, Reference_Comp_Id, Reference_Contact_Id != 0, Reference_Yacht_Id);
				}

				if (lAFSPEventId == 0 && chkAskedForSoldPrice.CheckState == CheckState.Checked)
				{
					modAdminCommon.Record_Event("Asked For Sold Price", "Asked For Sold Price", Reference_Ac_Id, Reference_Journal_ID, Reference_Comp_Id, Reference_Contact_Id != 0, Reference_Yacht_Id);
				}

				if (lAFSPREventId > 0 && chkAskedForSoldPriceRefused.CheckState == CheckState.Unchecked)
				{
					strDelete1 = $"DELETE FROM EventLog WHERE (evtl_id = {lAFSPREventId.ToString()}) ";
					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = strDelete1;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();
				}

				if (lAFSPEventId > 0 && chkAskedForSoldPrice.CheckState == CheckState.Unchecked)
				{
					strDelete1 = $"DELETE FROM EventLog WHERE (evtl_id = {lAFSPEventId.ToString()}) ";
					DbCommand TempCommand_2 = null;
					TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
					TempCommand_2.CommandText = strDelete1;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand_2.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
					TempCommand_2.ExecuteNonQuery();
				}
			}
			catch (System.Exception excep)
			{

				this.Cursor = CursorHelper.CursorDefault;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Journal_Form_Unload_Error ({Information.Err().Number.ToString()}) {excep.Message}", "frm_journal(UNLOAD)");
				return;
			}

		} // Form_Unload

		private void FillDocumentGrid()
		{

			string Query = "";
			ADORecordSetHelper snpTransDocs = new ADORecordSetHelper(); //aey 7/1/04 convert to ado
			string TheFileName = "";
			Object fso = new Object();
			int DocCount = 0;
			string RootPath = "";

			try
			{

				DocCount = 0;
				grdTransactionDocuments.Visible = false;

				grdTransactionDocuments.Clear();
				grdTransactionDocuments.ColumnsCount = 4;
				grdTransactionDocuments.RowsCount = 2;
				grdTransactionDocuments.FixedRows = 1;

				grdTransactionDocuments.CurrentRowIndex = 0;

				grdTransactionDocuments.CurrentColumnIndex = 0;
				grdTransactionDocuments[grdTransactionDocuments.CurrentRowIndex, grdTransactionDocuments.CurrentColumnIndex].Value = "Seq";
				grdTransactionDocuments.SetColumnWidth(0, 27);

				grdTransactionDocuments.CurrentColumnIndex = 1;
				grdTransactionDocuments[grdTransactionDocuments.CurrentRowIndex, grdTransactionDocuments.CurrentColumnIndex].Value = "Tape Date";
				grdTransactionDocuments.SetColumnWidth(1, 65);

				grdTransactionDocuments.CurrentColumnIndex = 2;
				grdTransactionDocuments[grdTransactionDocuments.CurrentRowIndex, grdTransactionDocuments.CurrentColumnIndex].Value = "Type";
				grdTransactionDocuments.SetColumnWidth(2, 133);

				grdTransactionDocuments.CurrentColumnIndex = 3;
				grdTransactionDocuments[grdTransactionDocuments.CurrentRowIndex, grdTransactionDocuments.CurrentColumnIndex].Value = "Doc";
				grdTransactionDocuments.SetColumnWidth(3, 32);

				Query = "SELECT * FROM Aircraft_Document WITH(NOLOCK)";
				Query = $"{Query} WHERE adoc_ac_id = {Reference_Ac_Id.ToString()}";
				Query = $"{Query} AND adoc_journ_id = {Reference_Journal_ID.ToString()}";
				Query = $"{Query} ORDER BY adoc_journ_seq_no";

				snpTransDocs.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpTransDocs.BOF && snpTransDocs.EOF))
				{

					grdTransactionDocuments.Visible = true;
					grdTransactionDocuments.Top = 2;
					grdTransactionDocuments.Left = 719;
					grdTransactionDocuments.Height = 212;
					grdTransactionDocuments.Width = 262;


					while(!snpTransDocs.EOF)
					{
						DocCount++;
						grdTransactionDocuments.CurrentRowIndex = grdTransactionDocuments.RowsCount - 1;
						grdTransactionDocuments.SetRowHeight(grdTransactionDocuments.CurrentRowIndex, 33);

						grdTransactionDocuments.CurrentColumnIndex = 0;
						grdTransactionDocuments.ColAlignment[0] = DataGridViewContentAlignment.TopLeft;
						grdTransactionDocuments[grdTransactionDocuments.CurrentRowIndex, grdTransactionDocuments.CurrentColumnIndex].Value = ($"{Convert.ToString(snpTransDocs["adoc_journ_seq_no"])}").Trim();

						grdTransactionDocuments.CurrentColumnIndex = 1;
						grdTransactionDocuments.ColAlignment[1] = DataGridViewContentAlignment.TopLeft;
						grdTransactionDocuments[grdTransactionDocuments.CurrentRowIndex, grdTransactionDocuments.CurrentColumnIndex].Value = GetTapeDate(Reference_Ac_Id, Reference_Journal_ID, Convert.ToInt32(Double.Parse(($"{Convert.ToString(snpTransDocs["adoc_journ_seq_no"])}").Trim())));

						grdTransactionDocuments.CurrentColumnIndex = 2;
						grdTransactionDocuments.ColAlignment[2] = DataGridViewContentAlignment.TopLeft;
						grdTransactionDocuments.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
						grdTransactionDocuments[grdTransactionDocuments.CurrentRowIndex, grdTransactionDocuments.CurrentColumnIndex].Value = ($"{Convert.ToString(snpTransDocs["adoc_doc_type"])}").Trim();

						grdTransactionDocuments.CurrentColumnIndex = 3;
						grdTransactionDocuments.ColAlignment[3] = DataGridViewContentAlignment.TopLeft;

						if (Strings.Len(modAdminCommon.gbl_Documents.Trim()) > 0)
						{

							if (($"{Convert.ToString(snpTransDocs["adoc_doc_type"])}").Trim().Substring(0, Math.Min(4, ($"{Convert.ToString(snpTransDocs["adoc_doc_type"])}").Trim().Length)).ToLower() == "ntsb")
							{
								RootPath = ($"{modCommon.DLookUp("aconfig_ntsb_maindir", "application_configuration")}").Trim();
								modAdminCommon.gbl_Documents = RootPath;
								TheFileName = modCommon.Get_Document_File_Name(Reference_Ac_Id, Reference_Journal_ID, Convert.ToInt32(Double.Parse(($"{Convert.ToString(snpTransDocs["adoc_journ_seq_no"])}").Trim())), "NTSB", ".html");
							}
							else
							{
								RootPath = ($"{modCommon.DLookUp("aconfig_faapdf_maindir", "application_configuration")}").Trim();
								modAdminCommon.gbl_Documents = RootPath;
								TheFileName = modCommon.Get_Document_File_Name(Reference_Ac_Id, Reference_Journal_ID, Convert.ToInt32(Double.Parse(($"{Convert.ToString(snpTransDocs["adoc_journ_seq_no"])}").Trim())), "FAAPDF", ".pdf");
							}


							if (ErrorHandlingHelper.ResumeNextExpr<bool>(() => File.Exists(TheFileName)))
							{
								Exception ex = null;
								ErrorHandlingHelper.ResumeNext(out ex);

								if (ex == null)
								{
									ErrorHandlingHelper.ResumeNext(

										() => {grdTransactionDocuments[grdTransactionDocuments.CurrentRowIndex, grdTransactionDocuments.CurrentColumnIndex].Value = "Yes";}, 
										() => { grdTransactionDocuments.set_RowData(grdTransactionDocuments.CurrentRowIndex, Convert.ToInt32(snpTransDocs["adoc_journ_seq_no"].ToString().Trim())); }
									);

								}
								else
								{
									try
									{

										grdTransactionDocuments[grdTransactionDocuments.CurrentRowIndex, grdTransactionDocuments.CurrentColumnIndex].Value = "No";
									}
									catch
									{
									}

								}
								try
								{

									Information.Err().Clear();
								}
								catch
								{
								}

							} // If gfso.FileExists(TheFileName) = True Then

						}
						else
						{
							grdTransactionDocuments[grdTransactionDocuments.CurrentRowIndex, grdTransactionDocuments.CurrentColumnIndex].Value = "No";
						} // If Len(Trim(gbl_Documents)) > 0 Then


						snpTransDocs.MoveNext();
						grdTransactionDocuments.RowsCount++;

					};

					grdTransactionDocuments.RowsCount--;
				}

				fso = null;
				snpTransDocs.Close(); //aey 7/1/04
				snpTransDocs = null;

				if (!tmp_JournHitoryFlag && DocCount == 0)
				{
					cmdDocuments.Visible = false;
				}
			}
			catch (System.Exception excep)
			{

				this.Cursor = CursorHelper.CursorDefault;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"FillDocumentGrid_Error ({Information.Err().Number.ToString()}) {excep.Message} : ACID[{Reference_Ac_Id.ToString()}] CMPID[{Reference_Comp_Id.ToString()}] JID[{Reference_Journal_ID.ToString()}]", "frm_Journal(FILLDOCS)");
			}

		} // FillDocumentGrid

		public void Display_Journal_Entry()
		{
			try
			{
				string Query = "";

				Clear_Journal_Form(Reference_Journal_ID.ToString());

				Query = "SELECT * FROM Journal WITH (NOLOCK) ";
				Query = $"{Query}INNER JOIN Journal_Category WITH (NOLOCK) ON journ_subcategory_code = jcat_subcategory_code ";
				Query = $"{Query}WHERE (journ_id = {Reference_Journal_ID.ToString()}) ";

				snp_Journal = new ADORecordSetHelper();

				snp_Journal.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_Journal.BOF && snp_Journal.EOF))
				{

					pnl_Journal_Heading.Visible = true;

					txt_journ_id.Text = "0";
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snp_Journal["journ_id"]))
					{
						if (Convert.ToDouble(snp_Journal["journ_id"]) > 0)
						{
							nRefJournalID = Convert.ToInt32(snp_Journal["journ_id"]);
							txt_journ_id.Text = Convert.ToString(snp_Journal["journ_id"]);
						}
					}

					txt_pcreckey.Text = "0";
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snp_Journal["journ_pcreckey"]))
					{
						if (Convert.ToDouble(snp_Journal["journ_pcreckey"]) > 0)
						{
							txt_pcreckey.Text = Convert.ToString(snp_Journal["journ_pcreckey"]);
						}
					}

					txt_journ_date.Text = modGlobalVars.cEmptyString;
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snp_Journal["journ_date"]))
					{
						if (Convert.ToString(snp_Journal["journ_date"]).Trim() != modGlobalVars.cEmptyString)
						{
							txt_journ_date.Text = DateTime.Parse(Convert.ToString(snp_Journal["journ_date"]).Trim()).ToString("d");
						}
					}

					txt_journ_subject.Text = modGlobalVars.cEmptyString;
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snp_Journal["journ_subject"]))
					{
						if (Convert.ToString(snp_Journal["journ_subject"]).Trim() != modGlobalVars.cEmptyString)
						{
							txt_journ_subject.Text = Convert.ToString(snp_Journal["journ_subject"]).Trim();
						}
					}

					txt_journ_description.Text = modGlobalVars.cEmptyString;
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snp_Journal["journ_description"]))
					{
						if (Convert.ToString(snp_Journal["journ_description"]).Trim() != modGlobalVars.cEmptyString)
						{
							txt_journ_description.Text = Convert.ToString(snp_Journal["journ_description"]).Trim();
						}
					}

					txt_journ_customer_note.Text = modGlobalVars.cEmptyString;
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snp_Journal["journ_customer_note"]))
					{
						if (Convert.ToString(snp_Journal["journ_customer_note"]).Trim() != modGlobalVars.cEmptyString)
						{
							txt_journ_customer_note.Text = Convert.ToString(snp_Journal["journ_customer_note"]).Trim();
						}
					}

					txt_category.Text = modGlobalVars.cEmptyString;
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snp_Journal["jcat_category_name"]) && !Convert.IsDBNull(snp_Journal["jcat_subcategory_transtype"]))
					{
						if (Convert.ToString(snp_Journal["jcat_subcategory_transtype"]).Trim() != modGlobalVars.cEmptyString)
						{
							txt_category.Text = Convert.ToString(snp_Journal["jcat_subcategory_transtype"]).Trim();
						}
					}

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snp_Journal["jcat_subcategory_code"]) && !Convert.IsDBNull(snp_Journal["jcat_subcategory_transtofrom"]))
					{
						if (Convert.ToString(snp_Journal["jcat_subcategory_transtofrom"]).Trim() != modGlobalVars.cEmptyString)
						{
							txt_category.Text = $"{txt_category.Text}/{Convert.ToString(snp_Journal["jcat_subcategory_transtofrom"]).Trim()}";
						}
					}

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snp_Journal["jcat_subcategory_name"]))
					{
						if (Convert.ToString(snp_Journal["jcat_subcategory_name"]).Trim() != modGlobalVars.cEmptyString)
						{
							nRefJcat_subcategory_name = Convert.ToString(snp_Journal["jcat_subcategory_name"]).Trim();
						}
					}

					txt_journ_subcategory_code.Text = modGlobalVars.cEmptyString;
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snp_Journal["journ_subcategory_code"]))
					{
						if (Convert.ToString(snp_Journal["journ_subcategory_code"]).Trim() != modGlobalVars.cEmptyString)
						{
							txt_journ_subcategory_code.Text = Convert.ToString(snp_Journal["journ_subcategory_code"]).Trim();
							Reference_SubCategory_Code = Convert.ToString(snp_Journal["journ_subcategory_code"]).Trim();
							chk_New_to_Market.Enabled = Reference_SubCategory_Code != "RN";
						}
					}

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snp_Journal["jcat_category_code"]))
					{
						if (Convert.ToString(snp_Journal["jcat_category_code"]).Trim() != modGlobalVars.cEmptyString)
						{
							Reference_Category_Code = Convert.ToString(snp_Journal["jcat_category_code"]).Trim().ToUpper();
							if (Reference_Category_Code == "AH")
							{
								txt_journ_customer_note.Visible = true;
								lbl_Journal[3].Visible = true;
							}
							else
							{
								txt_journ_customer_note.Visible = false;
								lbl_Journal[3].Visible = false;
							}
						}
					}

					txt_User.Text = modGlobalVars.cEmptyString;
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snp_Journal["journ_user_id"]))
					{
						if (Convert.ToString(snp_Journal["journ_user_id"]).Trim() != modGlobalVars.cEmptyString)
						{
							txt_User.Text = Convert.ToString(snp_Journal["journ_user_id"]).Trim();
						}
					}

					txt_journ_entry_date.Text = modGlobalVars.cEmptyString;
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snp_Journal["journ_entry_date"]))
					{
						if (Convert.ToString(snp_Journal["journ_entry_date"]).Trim() != modGlobalVars.cEmptyString)
						{
							txt_journ_entry_date.Text = DateTime.Parse(Convert.ToString(snp_Journal["journ_entry_date"]).Trim()).ToString("d");
						}
					}

					txt_journ_entry_time.Text = modGlobalVars.cEmptyString;
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snp_Journal["journ_entry_time"]))
					{
						if (Convert.ToString(snp_Journal["journ_entry_time"]).Trim() != modGlobalVars.cEmptyString)
						{
							txt_journ_entry_time.Text = DateTime.Parse(Convert.ToString(snp_Journal["journ_entry_time"]).Trim()).ToString("T");
						}
					}

					txt_journ_account_id.Text = modGlobalVars.cEmptyString;
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snp_Journal["journ_account_id"]))
					{
						if (Convert.ToString(snp_Journal["journ_account_id"]).Trim() != modGlobalVars.cEmptyString)
						{
							txt_journ_account_id.Text = Convert.ToString(snp_Journal["journ_account_id"]).Trim();
						}
					}

					txt_journ_prior_account_id.Text = modGlobalVars.cEmptyString;
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snp_Journal["journ_prior_account_id"]))
					{
						if (Convert.ToString(snp_Journal["journ_prior_account_id"]).Trim() != modGlobalVars.cEmptyString)
						{
							txt_journ_prior_account_id.Text = Convert.ToString(snp_Journal["journ_prior_account_id"]).Trim();
						}
					}

					chk_New_to_Market.CheckState = CheckState.Unchecked;
					chk_New_to_Market.Visible = true;
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snp_Journal["journ_newac_flag"]))
					{
						if (Convert.ToString(snp_Journal["journ_newac_flag"]).Trim() != modGlobalVars.cEmptyString)
						{
							if (Convert.ToString(snp_Journal["journ_newac_flag"]).Trim().ToUpper() == "Y")
							{
								chk_New_to_Market.CheckState = CheckState.Checked;
								is_new_to_market_on_load = true;
							}
							else
							{
								chk_New_to_Market.CheckState = CheckState.Unchecked;
								is_new_to_market_on_load = false;
							}
						}
					}

					chk_journ_internal_trans_flag.CheckState = CheckState.Unchecked;
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snp_Journal["journ_internal_trans_flag"]))
					{
						if (Convert.ToString(snp_Journal["journ_internal_trans_flag"]).Trim() != modGlobalVars.cEmptyString)
						{
							if (Convert.ToString(snp_Journal["journ_internal_trans_flag"]).Trim().ToUpper() == "Y")
							{
								chk_journ_internal_trans_flag.CheckState = CheckState.Checked;
							}
							else
							{
								chk_journ_internal_trans_flag.CheckState = CheckState.Unchecked;
							}
						}
					}

					if (Reference_Yacht_Id > 0)
					{
						if (Convert.ToString(snp_Journal["jcat_subcategory_code"]) != "RN" && Convert.ToString(snp_Journal["jcat_subcategory_code"]) != "VS" && Convert.ToString(snp_Journal["jcat_subcategory_code"]) != "DM" && Convert.ToString(snp_Journal["jcat_subcategory_code"]) != "YN")
						{
							chk_journ_internal_trans_flag.Enabled = true;
						}
					}

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snp_Journal["journ_ac_id"]))
					{
						if (Convert.ToInt32(snp_Journal["journ_ac_id"]) > 0)
						{
							//Display Aircraft if one is associated
							Reference_Ac_Id = Convert.ToInt32(snp_Journal["journ_ac_id"]);
							Display_Aircraft_Info();
							pnl_Aircraft.Visible = true;
							lst_aircraft.Visible = false;

							lst_aircraft_info.Height = 114;
						}
						else
						{
							Reference_Ac_Id = 0;
							pnl_Aircraft.Visible = true; // changed to true - MSW 11/19/15 so its not white

							lst_aircraft_info.Height = 67;
							lst_aircraft.Visible = true;

							display_ac_inbox(Convert.ToInt32(snp_Journal["journ_comp_id"]));
						}
					}

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snp_Journal["journ_yacht_id"]))
					{
						if (Convert.ToDouble(snp_Journal["journ_yacht_id"]) > 0)
						{
							Reference_Yacht_Id = Convert.ToInt32(snp_Journal["journ_yacht_id"]);
							Display_Yacht_Info();
							pnl_Aircraft.Visible = true;
							//UPGRADE_ISSUE: (2064) Threed.SSPanel property pnl_aircraft.Caption was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							pnl_Aircraft.setCaption("Yacht Information");
						}
						else
						{
							Reference_Yacht_Id = 0;
						}
					}

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snp_Journal["journ_comp_id"]))
					{
						if (Convert.ToDouble(snp_Journal["journ_comp_id"]) > 0)
						{
							//Display Company if one is associated
							Reference_Comp_Id = Convert.ToInt32(snp_Journal["journ_comp_id"]);
							Display_Company_Info();
							FillCboCompany();
							if (snpComp != null)
							{
								if (!(snpComp.BOF && snpComp.EOF))
								{
									snpComp.MoveFirst();
									int tempForEndVar = cbo_comp_info.SelectedIndex - 1;
									for (int i = 1; i <= tempForEndVar; i++)
									{
										snpComp.MoveNext();
									}
								}
								else
								{
									cbo_contact_info.Visible = false;
								}
							}
							else
							{
								cbo_contact_info.Visible = false;
							}
						}
						else
						{
							Reference_Comp_Id = 0;
							if (Convert.ToDouble(snp_Journal["journ_yacht_id"]) > 0)
							{
								FillCboCompany_Yacht();
							}
							else
							{
								if (txt_journ_subject.Text.IndexOf("Aircraft Model Update:") >= 0 || Convert.ToDouble(snp_Journal["journ_amod_id"]) > 0)
								{
									// dont load company box
								}
								else
								{
									FillCboCompany();
								}
							}
						}
					}

					Original_Company_ID = Reference_Comp_Id;

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snp_Journal["journ_contact_id"]))
					{
						if (Convert.ToDouble(snp_Journal["journ_contact_id"]) > 0)
						{
							//Display Aircraft if one is associated
							Reference_Contact_Id = Convert.ToInt32(snp_Journal["journ_contact_id"]);

							Display_Contact_Info();
						}
						else
						{
							Reference_Contact_Id = 0;
						}
					}

					Original_Contact_ID = Reference_Contact_Id;


					tmp_JournHitoryFlag = Convert.ToString(snp_Journal["jcat_category_code"]) == "AH";


					Enable_Journal();

					if (Reference_Journal_ID > 0)
					{
						cmd_Cancel.Text = "Close";
					}

					cmd_Cancel.Visible = true;

					txt_category.Enabled = false;
					txt_journ_subcategory_code.Enabled = false;
					txt_journ_id.Enabled = false;
					txt_journ_account_id.Enabled = false;
					txt_journ_prior_account_id.Enabled = false;
					txt_journ_entry_date.Enabled = false;
					txt_User.Enabled = false;
					txt_journ_entry_time.Enabled = false;

					//  SET TEMPORARY VARIABLES TO DETERMINE IF TRANSMIT IS REQUIRED

					tmp_journ_subcategory_code = txt_journ_subcategory_code.Text.Trim();
					tmp_journ_description = txt_journ_description.Text.Trim();
					tmp_journ_customer_note = txt_journ_customer_note.Text.Trim();
					tmp_journ_date = txt_journ_date.Text.Trim();

					if (chk_New_to_Market.CheckState == CheckState.Checked)
					{
						tmp_journ_newmarket_flag = "Y";
					}
					else
					{
						tmp_journ_newmarket_flag = "N";
					}

					FillDocumentGrid();

				} // If Not (snp_Journal.BOF And snp_Journal.EOF) Then
			}
			catch (System.Exception excep)
			{

				snp_Journal = null;
				this.Cursor = CursorHelper.CursorDefault;
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Display_Journal_Entry_Error ({Information.Err().Number.ToString()}) {excep.Message} : ACID[{Reference_Ac_Id.ToString()}] CMPID[{Reference_Comp_Id.ToString()}] JID[{Reference_Journal_ID.ToString()}]", "frm_Journal(DISPLAY)");
				return;
			}


		} // Display_Journal_Entry

		public void Display_Journal_Entry_Form()
		{

			Clear_Journal_Form();
			cmdDocuments.Visible = false;
			Enable_Journal();

			if (Reference_Ac_Id > 0)
			{
				Display_Aircraft_Info();
				FillCboCompany();
				pnl_Aircraft.Visible = true;
				lst_aircraft.Visible = false;
				lst_aircraft_info.Height = 114;
			}
			else if (Reference_Yacht_Id > 0)
			{ 
				Display_Yacht_Info();
				FillCboCompany_Yacht();
				//UPGRADE_ISSUE: (2064) Threed.SSPanel property pnl_aircraft.Caption was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				pnl_Aircraft.setCaption("Yacht Information");
				pnl_Aircraft.Visible = true;
				txt_journ_subject.Focus();
			}
			else
			{
				pnl_Aircraft.Visible = false;
			}

			if (Reference_Comp_Id > 0)
			{
				Display_Company_Info();
			}

			if (Reference_Contact_Id > 0)
			{
				Display_Contact_Info();
				FillCboContact();
			}

			if (Reference_Yacht_Id == 0)
			{
				FillCboCompany();
			}

			Get_Journal_Categories();

			if (Reference_Subject.Trim() != modGlobalVars.cEmptyString)
			{
				txt_journ_subject.Text = Reference_Subject.Trim();
			}
			else
			{
				if (txt_journ_subcategory_code.Text == "IDNOTE")
				{
					txt_journ_subject.Enabled = true;
				}
				else
				{
					txt_journ_subject.Enabled = true;
				}
			}

			if (Reference_Category_Code.Trim().ToUpper() == "AH" || is_historical_yacht)
			{
				txt_journ_customer_note.Visible = true;
				lbl_Journal[3].Visible = true;
			}
			else
			{
				txt_journ_customer_note.Visible = false;
				lbl_Journal[3].Visible = false;
			}

			if (Reference_SubCategory_Code.Trim().ToUpper() == "ACDOC")
			{
				FillDocumentType();
				cboDocumentType.Visible = true;
			}
			else
			{
				cboDocumentType.Visible = false;
			}

			if (Reference_Journal_ID > 0)
			{
				cmd_Cancel.Text = "Close";
			}

			cmd_Cancel.Visible = true;

		} // Display_Journal_Entry_Form

		public void Clear_Journal_Form(string journ_id = "")
		{
			lst_aircraft_info.Items.Clear();
			lst_comp_info.Items.Clear();
			lst_contact_info.Items.Clear();
			txt_journ_id.Text = "";
			txt_journ_date.Text = "";
			txt_category.Text = "";
			txt_journ_subcategory_code.Text = "";
			txt_journ_subject.Text = "";
			txt_journ_description.Text = "";
			txt_journ_customer_note.Text = "";
			txt_pcreckey.Text = "";
			chk_New_to_Market.CheckState = CheckState.Unchecked;
			chk_New_to_Market.Visible = false;

			cbo_journ_cat.Visible = false;
			cbp_journ_sub_type.Visible = false;
			if (Reference_SubCategory_Code.Trim() == "NOTE" || Reference_SubCategory_Code.Trim() == "NOTERN")
			{
				cbo_journ_cat.Visible = true;
				cbo_journ_cat.Items.Clear();
				cbo_journ_cat.AddItem("");
				cbo_journ_cat.AddItem("IQ");
				//added MSW - 3/1/23
				if (journ_id.Trim() != "")
				{
					cbo_journ_cat.AddItem("DOCAT");
				}
				else
				{
					// dont show on add
				}
				cbo_journ_cat.AddItem("RVEAT");
				cbo_journ_cat.AddItem("RADN");
				cbo_journ_cat.AddItem("PB");
				cbo_journ_cat.AddItem("IDNOTE");
				cbo_journ_cat.AddItem("RN");
				cbo_journ_cat.AddItem("SPEC");
				cbo_journ_cat.AddItem("PROJ");
				cbo_journ_cat.AddItem("MEMO");
				cbo_journ_cat.AddItem("REGCHK");
			}
			else if (Reference_SubCategory_Code.Trim() == "IDNOTE")
			{ 
				cbo_journ_cat.Visible = true;
				cbo_journ_cat.Items.Clear();
				cbo_journ_cat.AddItem("IDNOTE");
				cbo_journ_cat.Text = "IDNOTE";
				cbo_journ_cat_SelectionChangeCommitted(cbo_journ_cat, new EventArgs());
			}

			if (Reference_SubCategory_Code.Trim() == "NOTERN")
			{
				cbo_journ_cat.Text = "RN";
				Reference_SubCategory_Code = "RN";
			}

		} // Clear_Journal_Form

		private void Display_Aircraft_Info()
		{

			string Query = "";
			ADORecordSetHelper snp_AircraftInfo = new ADORecordSetHelper(); //aey 7/1/04 convert to ado
			string tmp_reg_no = "";

			lst_aircraft_info.Items.Clear();

			if (ACModel != "" && ACSerial != "" && ACYear != "")
			{
				lst_aircraft_info.AddItem($"MAKE/MODEL: {ACModel}");
				lst_aircraft_info.AddItem($"SERIAL#: {ACSerial}");
				lst_aircraft_info.AddItem($"YEAR: {ACYear}");
			}
			else
			{

				//reset these values so we have the right data for transmit
				tmp_amod_id = 0;
				tmp_serial_no = "";


				Query = "Select amod_make_name,amod_model_name,ac_ser_no_full,ac_year,amod_id, ac_reg_no";
				Query = $"{Query} from Aircraft WITH(NOLOCK) ";
				Query = $"{Query} inner join Aircraft_Model WITH(NOLOCK) on amod_id = ac_amod_id ";
				Query = $"{Query} where ac_id = {Reference_Ac_Id.ToString()} and ac_journ_id = 0 ";


				snp_AircraftInfo.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_AircraftInfo.BOF && snp_AircraftInfo.EOF))
				{
					lst_aircraft_info.AddItem($"MAKE/MODEL: {($"{Convert.ToString(snp_AircraftInfo["amod_make_name"])} ").Trim()}/{($"{Convert.ToString(snp_AircraftInfo["amod_model_name"])} ").Trim()}");
					lst_aircraft_info.AddItem($"SERIAL#: {($"{Convert.ToString(snp_AircraftInfo["ac_ser_no_full"])} ").Trim()}");
					lst_aircraft_info.AddItem($"YEAR: {($"{Convert.ToString(snp_AircraftInfo["ac_year"])} ").Trim()}");

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snp_AircraftInfo["amod_ID"]))
					{
						if (Convert.ToString(snp_AircraftInfo["amod_ID"]).Trim() != "")
						{
							tmp_amod_id = Convert.ToInt32(snp_AircraftInfo["amod_ID"]);
						}
					}

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snp_AircraftInfo["ac_ser_no_full"]))
					{
						if (Convert.ToString(snp_AircraftInfo["ac_ser_no_full"]).Trim() != "")
						{
							tmp_serial_no = Convert.ToString(snp_AircraftInfo["ac_ser_no_full"]);
						}
					}


					tmp_reg_no = "";
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snp_AircraftInfo["ac_reg_no"]))
					{
						if (Convert.ToString(snp_AircraftInfo["ac_reg_no"]).Trim() != "")
						{
							tmp_reg_no = Convert.ToString(snp_AircraftInfo["ac_reg_no"]);
							lst_aircraft_info.AddItem($"REGNO: {tmp_reg_no.Trim()}");
						}
					}



				}

				snp_AircraftInfo.Close();
				snp_AircraftInfo = null;

			}

		} // Display_Aircraft_Info

		private void Display_Yacht_Info()
		{

			ADORecordSetHelper snp_AircraftInfo = new ADORecordSetHelper(); //aey 7/1/04 convert to ado

			lst_aircraft_info.Items.Clear();


			//reset these values so we have the right data for transmit
			tmp_amod_id = 0;
			tmp_serial_no = "";

			string Query = "Select yt_yacht_name, yt_radio_call_sign, ym_model_name from Yacht  ";
			Query = $"{Query} inner join yacht_model on ym_model_id = yt_model_id ";
			Query = $"{Query} Where yt_id = {Reference_Yacht_Id.ToString()}";
			Query = $"{Query} and yt_journ_id = 0 ";

			snp_AircraftInfo.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

			if (!(snp_AircraftInfo.BOF && snp_AircraftInfo.EOF))
			{


				lst_aircraft_info.AddItem($"YACHT NAME: {Convert.ToString(snp_AircraftInfo["yt_yacht_name"])}");
				lst_aircraft_info.AddItem($"YACHT CALL SIGN: {Convert.ToString(snp_AircraftInfo["yt_radio_call_sign"])}");
				lst_aircraft_info.AddItem($"MODEL: {Convert.ToString(snp_AircraftInfo["ym_model_name"]).Trim()}");

			}

			snp_AircraftInfo.Close();

		} // Display_Yacht_Info

		private void FillCboCompany_Yacht()
		{


			cbo_comp_info.Items.Clear();
			cbo_comp_info.AddItem("<None>");
			cbo_comp_info.SetItemData(0, 0);

			//reset these values so we have the right data for transmit
			tmp_amod_id = 0;
			tmp_serial_no = "";

			string Query = "SELECT DISTINCT comp_id, comp_name  FROM Company WITH (NOLOCK) ";
			Query = $"{Query}INNER JOIN Yacht_Reference WITH (NOLOCK) ON yr_comp_id = comp_id AND yr_journ_id = comp_journ_id ";
			Query = $"{Query}WHERE (yr_yt_id = {Reference_Yacht_Id.ToString()})  AND (yr_journ_id = 0) ";


			Query = $"{Query}AND (comp_journ_id = 0) ORDER BY comp_name ";

			snpComp = new ADORecordSetHelper();
			snpComp.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

			if (!snpComp.BOF && !snpComp.EOF)
			{

				do 
				{ // Loop Until snpComp.EOF = True

					cbo_comp_info.AddItem(($"{Convert.ToString(snpComp["comp_name"])} ").Trim());
					cbo_comp_info.SetItemData(cbo_comp_info.Items.Count - 1, Convert.ToInt32(snpComp["comp_id"]));

					snpComp.MoveNext();

				}
				while(!snpComp.EOF);

			} // If (snpComp.BOF = False And snpComp.EOF = False) Then


			cbo_comp_info.SelectedIndex = 0;

			cbo_comp_info.Visible = true;

		} // FillCboCompany_Yacht

		private void Display_Company_Info()
		{

			string Query = "";

			try
			{

				lst_comp_info.Items.Clear();
				current_comp_id = Reference_Comp_Id;
				if (Reference_Comp_Id > 0)
				{ //check for comp_id greater than zero
					Query = $"select comp_id from company WITH(NOLOCK) where comp_id = {Reference_Comp_Id.ToString()}";
					if (modAdminCommon.Exist(Query))
					{
						modCommon.Build_Company_NameAddress(lst_comp_info, Reference_Comp_Id, 0, "No Details");
						FillCboContact();
						lst_comp_info.Visible = true;
					}
					else
					{
						lst_comp_info.Visible = false;
					}

				}
				else
				{
					cbo_contact_info.Visible = false;
				}
			}
			catch (System.Exception excep)
			{

				this.Cursor = CursorHelper.CursorDefault;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Display_Company_Info_Error ({Information.Err().Number.ToString()}) {excep.Message} : ACID[{Reference_Ac_Id.ToString()}] CMPID[{Reference_Comp_Id.ToString()}] JID[{Reference_Journal_ID.ToString()}]", "frm_Journal(COMPANY)");
				return;
			}

		} // Display_Company_Info

		private void Display_Contact_Info()
		{

			try
			{


				// DISPLAY CONTACT INFORMATION
				lst_contact_info.Items.Clear();

				lst_contact_info.Visible = true;

				current_contact_id = Reference_Contact_Id;

				if (Reference_Contact_Id > 0)
				{
					modCommon.Build_Contact_Info(lst_contact_info, Reference_Contact_Id, Convert.ToString(cbo_contact_info.Tag));
					int tempForEndVar = cbo_contact_info.Items.Count - 1;
					for (int i = 0; i <= tempForEndVar; i++)
					{
						if (cbo_contact_info.GetItemData(i) == Reference_Contact_Id)
						{
							cbo_contact_info.SelectedIndex = i;
							break;
						}
					}
				}
			}
			catch (System.Exception excep)
			{

				this.Cursor = CursorHelper.CursorDefault;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Display_Contact_Info_Error ({Information.Err().Number.ToString()}) {excep.Message} : ACID[{Reference_Ac_Id.ToString()}] CMPID[{Reference_Comp_Id.ToString()}] JID[{Reference_Journal_ID.ToString()}]", "frm_Journal(CONTACT)");
				return;
			}
		} // Display_Contact_Info

		public void Update_Journal_Record()
		{

			string strSubCatCode = "";
			string strSubject = "";
			string strMsg = "";
			int tmpCurrentCompID = 0;
			int tmpCurrentContactID = 0;
			string Query = "";
			bool SaveCompanyCopy = false; // flags if a historical copy of the company needs to be made

			int lError = 0; // Hold The Error Number Value
			string strError = ""; // Hold The Error Description Value
			StreamWriter errMsg = null;
			string[] tmpFields = new string[]{"", ""};
			// RTW - 11/3/2011 - ADDED NEW SPLIT OF CODES
			string tmp_journ_part1 = "";
			string tmp_journ_part2 = "";
			string tmp_journ_part3 = "";
			bool add_new_to_market_event = false;
			int temp_ac_id = 0;
			tmpFields[0] = "";

			int ErrCount = 0; // NO ERRORS TO START
			this.Cursor = Cursors.WaitCursor;
			string WriteToWeB = "Y";

			try
			{

				strMsg = "";
				strError = "init";
				if (cboNewSubcategoryCode.Visible)
				{

					if (txt_journ_subcategory_code.Text.Trim() != cboNewSubcategoryCode.Text.Trim())
					{

						//-----------------------------------------------
						// Only need to check the code for transactions
						//-----------------------------------------------
						if (Reference_Category_Code.Trim().ToUpper() == "AH" || Reference_Category_Code.Trim().ToUpper() == "YH" && Reference_SubCategory_Code.Trim().ToUpper() != "ACDOC" && Reference_SubCategory_Code.Trim().ToUpper() != "EXON" && Reference_SubCategory_Code.Trim().ToUpper() != "EXOFF" && Reference_SubCategory_Code.Trim().ToUpper() != "WOP")
						{

							if (!CodeValid(cboNewSubcategoryCode.Text.Trim()))
							{

								DataNotValid = true;
								this.Cursor = CursorHelper.CursorDefault;
								return;

							}
							else
							{

								strSubCatCode = cboNewSubcategoryCode.Text;
								strSubject = txt_journ_subject.Text;

								UpdateJournalSubjectWithSellerPurchaserInfo(nRefJournalID, strSubCatCode, ref strSubject);

								if (strSubject != "")
								{
									txt_journ_subject.Text = strSubject;
								}

							} // If CodeValid(Trim(cboNewSubcategoryCode.Text)) = False Then

						} //If UCase(Trim("" & snp_Journal!jcat_category_code)) = "AH" And
					} // If (txt_journ_subcategory_code.Text <> cboNewSubcategoryCode.Text) Then

				} // If cboNewSubcategoryCode.Visible = True Then

				strError = "Begin Trans";
				// ********************************
				// BEGIN THE TRANSACTION
				modAdminCommon.ADO_Transaction("BeginTrans");

				if (cbo_comp_info.SelectedIndex == -1)
				{
					tmpCurrentCompID = 0;
				}
				else
				{
					tmpCurrentCompID = cbo_comp_info.GetItemData(cbo_comp_info.SelectedIndex);
				}

				if (cbo_contact_info.SelectedIndex == -1)
				{
					tmpCurrentContactID = 0;
				}
				else
				{
					tmpCurrentContactID = cbo_contact_info.GetItemData(cbo_contact_info.SelectedIndex);
				}

				if (tmp_journ_description != txt_journ_description.Text || tmp_journ_customer_note != txt_journ_customer_note.Text || tmp_journ_date != txt_journ_date.Text || Original_Company_ID != tmpCurrentCompID || Original_Contact_ID != tmpCurrentContactID)
				{

					strMsg = "";

					if (tmp_journ_description != txt_journ_description.Text)
					{
						strMsg = $"{strMsg}Description Changed From [{tmp_journ_description}] To [{txt_journ_description.Text}] ";
					}

					if (tmp_journ_customer_note != txt_journ_customer_note.Text)
					{
						strMsg = $"{strMsg}Customer Note Changed From [{tmp_journ_customer_note}] To [{txt_journ_customer_note.Text}] ";
					}

					if (tmp_journ_date != txt_journ_date.Text)
					{
						if (Information.IsDate(txt_journ_date.Text))
						{
							if (((int) DateAndTime.DateDiff("D", DateTime.Parse(modAdminCommon.GetDateTime()), DateTime.Parse(txt_journ_date.Text), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) > 0)
							{
								MessageBox.Show("Invalid Journal Date entered. Restoring Original Date.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
								txt_journ_date.Text = tmp_journ_date;
							}
							else
							{
								strMsg = $"{strMsg}Date Changed From [{tmp_journ_date}] To [{txt_journ_date.Text}] ";
							}
						}
						else
						{
							MessageBox.Show("Invalid Journal Date entered. Restoring Original Date.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
							txt_journ_date.Text = tmp_journ_date;
						}
					}

					if (Original_Company_ID != tmpCurrentCompID)
					{
						strMsg = $"{strMsg}Company ID Changed From [{Original_Company_ID.ToString()}] To [{tmpCurrentCompID.ToString()}] ";
					}

					if (Original_Contact_ID != tmpCurrentContactID)
					{
						strMsg = $"{strMsg}Contact ID Changed From [{Original_Contact_ID.ToString()}] To [{tmpCurrentContactID.ToString()}] ";
					}

					//If we are going to go over the 200 character limit, cut the
					//message and add "..."
					if (Strings.Len(strMsg.Trim()) > 176)
					{
						strMsg = $"{strMsg.Substring(0, Math.Min(173, strMsg.Length))}...";
					}
					if (cbo_comp_info.SelectedIndex > -1)
					{
						modAdminCommon.Record_Event("Journal Update", $"Journal Record Changed: {strMsg.Trim()}", Reference_Ac_Id, nRefJournalID, cbo_comp_info.GetItemData(cbo_comp_info.SelectedIndex));
					}
					else
					{
						modAdminCommon.Record_Event("Journal Update", $"Journal Record Changed: {strMsg.Trim()}", Reference_Ac_Id, nRefJournalID, 0);
					}
				}

				Query = "Update Journal SET";
				// JOURNAL DATE
				Query = $"{Query} journ_date = '{DateTime.Parse(txt_journ_date.Text.Trim()).ToString("d")}',";

				if (lst_aircraft.Visible)
				{
					if (lst_aircraft.SelectedIndex > -1)
					{ // changed from 0 to -1 - MSW - 12/10/2020
						if (lst_aircraft.GetItemData(lst_aircraft.SelectedIndex) > 0)
						{
							Query = $"{Query} journ_ac_id = '{lst_aircraft.GetItemData(lst_aircraft.SelectedIndex).ToString()}',";
						}
					}
				}

				// SUBCATEGORY CODE
				if (cboNewSubcategoryCode.Visible)
				{
					Query = $"{Query} journ_subcategory_code = '{cboNewSubcategoryCode.Text.Trim()}',";
					UpdateBusinessTypes();
					// RTW - 11/3/2011 - ADDED NEW SPLIT OF CODES
					tmp_journ_part1 = cboNewSubcategoryCode.Text.Trim().Substring(0, Math.Min(2, cboNewSubcategoryCode.Text.Trim().Length));
					tmp_journ_part2 = cboNewSubcategoryCode.Text.Trim().Substring(Math.Min(2, cboNewSubcategoryCode.Text.Trim().Length), Math.Min(2, Math.Max(0, cboNewSubcategoryCode.Text.Trim().Length - 2)));
					tmp_journ_part3 = cboNewSubcategoryCode.Text.Trim().Substring(Math.Max(cboNewSubcategoryCode.Text.Trim().Length - 2, 0));
					Query = $"{Query} journ_subcat_code_part1 = '{tmp_journ_part1}',";
					Query = $"{Query} journ_subcat_code_part2 = '{tmp_journ_part2}',  journ_subcat_code_part3 = '{tmp_journ_part3}',";
				}
				else
				{
					Query = $"{Query} journ_subcategory_code = '{Reference_SubCategory_Code.Trim()}',";
					tmp_journ_part1 = Reference_SubCategory_Code.Trim().Substring(0, Math.Min(2, Reference_SubCategory_Code.Trim().Length));
					tmp_journ_part2 = Reference_SubCategory_Code.Trim().Substring(Math.Min(2, Reference_SubCategory_Code.Trim().Length), Math.Min(2, Math.Max(0, Reference_SubCategory_Code.Trim().Length - 2)));
					tmp_journ_part3 = Reference_SubCategory_Code.Trim().Substring(Math.Max(Reference_SubCategory_Code.Trim().Length - 2, 0));
					Query = $"{Query} journ_subcat_code_part1 = '{tmp_journ_part1}',";
					Query = $"{Query} journ_subcat_code_part2 = '{tmp_journ_part2}',  journ_subcat_code_part3 = '{tmp_journ_part3}',";
				}

				//internal trans code   --- aey 7/21/04
				if (chk_journ_internal_trans_flag.CheckState == CheckState.Checked)
				{
					Query = $"{Query} journ_internal_trans_flag = 'Y' ,";
				}
				else
				{
					Query = $"{Query} journ_internal_trans_flag = 'N' ,";
				}

				// SUBJECT
				Query = $"{Query} journ_subject = '{modAdminCommon.Fix_Quote(txt_journ_subject.Text.Trim())}',";

				// ACCOUNT REP ID
				Query = $"{Query} journ_account_id = '{txt_journ_account_id.Text.Trim()}',";

				Query = $"{Query} journ_prior_account_id = '{txt_journ_prior_account_id.Text.Trim()}',";

				// COMPANY REFERENCE ID
				if (cbo_comp_info.Text.Trim() != modGlobalVars.cEmptyString || cbo_comp_info.Visible)
				{
					Query = $"{Query} journ_comp_id = {Reference_Comp_Id.ToString()},";
				}
				else
				{
					Query = $"{Query} journ_comp_id = 0,";
				}


				if (cbo_contact_info.Text.Trim() != modGlobalVars.cEmptyString && cbo_contact_info.Visible)
				{
					Query = $"{Query} journ_contact_id = {Reference_Contact_Id.ToString()},";
				}
				else
				{
					Query = $"{Query} journ_contact_id = 0,";
				}

				add_new_to_market_event = false;
				if (chk_New_to_Market.CheckState == CheckState.Checked)
				{
					Query = $"{Query} journ_newac_flag = 'Y',";
					if (!is_new_to_market_on_load)
					{
						// THIS MEANS THIS WAS CHANGED TO BE NEW TO MARKET
						add_new_to_market_event = true;
					}
				}
				else
				{
					Query = $"{Query} journ_newac_flag = 'N',";
				}

				Query = $"{Query} journ_description = '{modAdminCommon.Fix_Quote(txt_journ_description.Text.Trim())}',";

				Query = $"{Query} journ_customer_note = '{modAdminCommon.Fix_Quote(txt_journ_customer_note.Text.Trim())}',";

				if (modCommon.GetTransWeb(Reference_SubCategory_Code.Trim()))
				{
					Query = $"{Query} journ_action_date = '1/1/1900'";
					WriteToWeB = "Y";
				}
				else
				{
					Query = $"{Query} journ_action_date = '{DateTime.Now.ToString()}'";
					WriteToWeB = "N";
				}

				Query = $"{Query} WHERE journ_id = {nRefJournalID.ToString()}";

				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();

				if (Reference_Ac_Id > 0)
				{
					if (WriteToWeB == "Y")
					{
						Query = "UPDATE Aircraft SET ac_action_date = NULL";
					}
					else
					{
						Query = $"UPDATE Aircraft SET ac_action_date = '{DateTime.Now.ToString()}'";
					}

					Query = $"{Query} WHERE ac_id = {Reference_Ac_Id.ToString()} AND ac_journ_id = {nRefJournalID.ToString()}";

					DbCommand TempCommand_2 = null;
					TempCommand_2 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
					TempCommand_2.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand_2.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
					TempCommand_2.ExecuteNonQuery();
				}

				Reference_Contact_Id = 0;

				strError = "transmit";
				// STORE TRANSMITS IF NECESSARY
				if (NeedsTransmit())
				{
					modAdminCommon.Record_Transmit(tmp_serial_no, Reference_Ac_Id, nRefJournalID, tmp_amod_id, "Transaction", "Change", ref tmpFields, 0);
				}

				if (add_new_to_market_event)
				{
					if (tmpCurrentCompID > 0 && tmpCurrentContactID > 0)
					{
						modCommon.Transaction_Insert_Priority_Event("WSND", Reference_Ac_Id, nRefJournalID, txt_journ_subject.Text, tmpCurrentCompID, tmpCurrentContactID);
					}
					else if (tmpCurrentCompID > 0)
					{ 
						modCommon.Transaction_Insert_Priority_Event("WSND", Reference_Ac_Id, nRefJournalID, txt_journ_subject.Text, tmpCurrentCompID, Original_Contact_ID);
					}
					else if (tmpCurrentContactID > 0)
					{ 
						modCommon.Transaction_Insert_Priority_Event("WSND", Reference_Ac_Id, nRefJournalID, txt_journ_subject.Text, Original_Company_ID, tmpCurrentContactID);
					}
					else
					{
						modCommon.Transaction_Insert_Priority_Event("WSND", Reference_Ac_Id, nRefJournalID, txt_journ_subject.Text, Original_Company_ID, Original_Contact_ID);
					}
				}

				modAdminCommon.ADO_Transaction("CommitTrans");

				this.Cursor = CursorHelper.CursorDefault;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Update_Journal_Record_Error ({Information.Err().Number.ToString()}) {excep.Message} : ACID[{Reference_Ac_Id.ToString()}] CMPID[{Reference_Comp_Id.ToString()}] JID[{Reference_Journal_ID.ToString()}]", "frm_Journal(UPDATE)");
				modAdminCommon.ADO_Transaction("Rollback");
				this.Cursor = CursorHelper.CursorDefault;
			}

		} // Update_Journal_Record

		public void Enable_Journal()
		{

			txt_journ_date.Enabled = true;
			txt_category.Enabled = true;
			txt_journ_description.Enabled = true;
			txt_journ_subject.Enabled = true;
			txt_journ_customer_note.Enabled = true;
			cmd_Cancel.Visible = true;
			cmd_Save.Visible = true;

		} // Enable_Journal

		public void Get_Journal_Categories()
		{

			try
			{

				string Query = "";
				string TempCategory = "";
				ADORecordSetHelper snp_Cat = new ADORecordSetHelper(); //8/1/05 aey converted to ado

				txt_journ_date.Text = DateTime.Now.ToString("d");

				Query = $"SELECT * FROM Journal_Category WITH(NOLOCK) WHERE jcat_subcategory_code='{StringsHelper.Replace(Reference_SubCategory_Code, "NOTERN", "RN", 1, -1, CompareMethod.Binary)}'";

				snp_Cat.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_Cat.BOF && snp_Cat.EOF))
				{
					txt_category.Text = $"{Convert.ToString(snp_Cat["jcat_category_name"]).Trim()}/{Convert.ToString(snp_Cat["jcat_subcategory_name"]).Trim()}";
					txt_category.Enabled = false;
				}

				if (txt_category.Text.Trim() == "Account Representative/ID Note")
				{
					txt_category.Text = "ID Note";
					txt_journ_subcategory_code.Text = "IDNOTE";
					txt_journ_subject.Text = "IDNOTE - Attempted to ID";
					txt_journ_subject.Enabled = false;
					radio_id[0].Visible = true;
					radio_id[1].Visible = true;
					radio_id[2].Visible = true;
					radio_id[0].Checked = true;
				}


				snp_Cat.Close();
				snp_Cat = null;
			}
			catch (System.Exception excep)
			{

				this.Cursor = CursorHelper.CursorDefault;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Get_Journal_Categories_Error ({Information.Err().Number.ToString()}) {excep.Message}", "frm_Journal(GETCAT)");
				return;
			}

		} // Get_Journal_Categories

		public void Populate_Journal_Entry()
		{

			modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(txt_journ_date.Text.Trim());
			modAdminCommon.Rec_Journal_Info.journ_ac_id = Reference_Ac_Id;
			modAdminCommon.Rec_Journal_Info.journ_contact_id = Reference_Contact_Id;
			modAdminCommon.Rec_Journal_Info.journ_comp_id = Reference_Comp_Id;
			modAdminCommon.Rec_Journal_Info.journ_yacht_id = Reference_Yacht_Id;

			modAdminCommon.Rec_Journal_Info.journ_subcategory_code = Reference_SubCategory_Code.Trim();
			modAdminCommon.Rec_Journal_Info.journ_subject = txt_journ_subject.Text.Trim();
			modAdminCommon.Rec_Journal_Info.journ_description = txt_journ_description.Text.Trim();
			modAdminCommon.Rec_Journal_Info.journ_customer_note = txt_journ_customer_note.Text.Trim();

			modAdminCommon.Rec_Journal_Info.journ_account_id = txt_journ_account_id.Text.Trim();
			modAdminCommon.Rec_Journal_Info.journ_prior_account_id = txt_journ_prior_account_id.Text.Trim();
			modAdminCommon.Rec_Journal_Info.journ_status = "A";

		} // Populate_Journal_Entry

		//UPGRADE_NOTE: (7001) The following declaration (Store_Transaction) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void Store_Transaction()
		//{
			//
			//string tmpOwnershipType = "";
			//
			//if (modAdminCommon.Rec_Journal_Info.journ_subcategory_code == "MA" || modAdminCommon.Rec_Journal_Info.journ_subcategory_code == "OM")
			//{
				//modCommon.Aircraft_History_Create_Recordsets();
				//tmpOwnershipType = modCommon.GetOwnershipType(Reference_Ac_Id, Reference_Journal_ID);
				//
				//modAdminCommon.ADO_Transaction("BeginTrans");
				//if (modCommon.Transaction_Save_Aircraft_History(Reference_Journal_ID, tmpOwnershipType, modGlobalVars.snp_TransAircraft, modGlobalVars.snp_TransAircraft_Reference, modGlobalVars.snp_TransAircraft_Features, modGlobalVars.snp_TransAircraft_Avionics, modGlobalVars.snp_TransAircraft_Certified, modGlobalVars.snp_TransAircraft_Specification, modGlobalVars.snp_TransAircraft_Details, modGlobalVars.snp_TransAircraft_FAA_Document, false, "", true, modAdminCommon.Rec_Journal_Info.journ_subcategory_code))
				//{
					//
					//modAdminCommon.ADO_Transaction("CommitTrans");
				//}
				//else
				//{
					//modAdminCommon.ADO_Transaction("RollbackTrans");
				//}
			//}
			//
		//} // Store_Transaction

		private void lblSubCategoryCode_DoubleClick(Object eventSender, EventArgs eventArgs)
		{

			string sCurCategory = "";

			if (Reference_Category_Code.Trim() == "AH" || Reference_Category_Code.Trim() == "YH")
			{
				if (!cboDocumentType.Visible)
				{
					sCurCategory = txt_journ_subcategory_code.Text;
					if (Convert.ToString(modAdminCommon.snp_User["user_type"]) == "Administrator" || Convert.ToString(modAdminCommon.snp_User["user_type"]) == "Research Manager")
					{
						FillNewSubCatCode();
						cboNewSubcategoryCode.Visible = true;
						if (sCurCategory.Substring(Math.Max(sCurCategory.Length - 2, 0)) == "IT" || chk_journ_internal_trans_flag.CheckState == CheckState.Checked)
						{
							chk_journ_internal_trans_flag.Enabled = true;
						}
					}
				}

			}

		} // lblSubCategoryCode_DblClick

		public void Display_MajorChangeFrame()
		{

			string Query = "";
			ADORecordSetHelper snpRefs = new ADORecordSetHelper(); //8/1/05 aey converted to ado
			ADORecordSetHelper snpCurOwn = new ADORecordSetHelper();

			try
			{

				frame_MajorChange.Visible = true;
				frame_MajorChange.BringToFront(); // 06/06/2008 - By David D. Cruger; Added ZOrder To Make Sure This Frame Is On Top

				cbo_New_TransType.Items.Clear();

				switch(txt_journ_subcategory_code.Text.Substring(0, Math.Min(2, txt_journ_subcategory_code.Text.Length)))
				{
					case "WS" : 
						lbl_Current_TransType.Text = "Whole Sale"; 
						cbo_New_TransType.AddItem("Share Sale"); 
						break;
				}

				// ******************************
				// DISPLAY THE BUYER AND SELLER


				Seller_ID = 0;
				Seller_Contact_ID = 0;
				Seller_Type = "";
				Purchaser_ID = 0;
				Query = "Select comp_name,comp_city,comp_state,comp_id,cref_contact_type, cref_owner_percent,cref_contact_id, cref_business_type ";
				Query = $"{Query}from Aircraft_Reference, Company ";
				Query = $"{Query}where cref_ac_id={Reference_Ac_Id.ToString()} and cref_journ_id={Reference_Journal_ID.ToString()}";
				Query = $"{Query} and (cref_comp_id = comp_id and cref_journ_id = comp_journ_id)  and (cref_contact_type='95' or cref_contact_type='96')";

				snpRefs.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpRefs.BOF && snpRefs.EOF))
				{

					while(!snpRefs.EOF)
					{
						if (Convert.ToString(snpRefs["cref_contact_type"]) == "95")
						{
							lbl_Seller_Name.Text = Convert.ToString(snpRefs["comp_name"]);
							Seller_ID = Convert.ToInt32(snpRefs["comp_id"]);
							Seller_Contact_ID = Convert.ToInt32(snpRefs["cref_contact_id"]);
							Seller_Type = Convert.ToString(snpRefs["cref_business_type"]);
						}
						if (Convert.ToString(snpRefs["cref_contact_type"]) == "96")
						{
							lbl_Purchaser_Name.Text = Convert.ToString(snpRefs["comp_name"]);
							txt_Purchaser_Percent.Text = Convert.ToString(snpRefs["cref_owner_percent"]);
							Purchaser_ID = Convert.ToInt32(snpRefs["comp_id"]);
						}

						snpRefs.MoveNext();
					};
				}

				snpRefs.Close();
				snpRefs = null;
				frame_BuyerSeller.Visible = false;


				Query = "select cref_comp_id  from Aircraft_Reference WITH(NOLOCK)";
				Query = $"{Query}where cref_ac_id={Reference_Ac_Id.ToString()}";
				Query = $"{Query} and cref_journ_id=0  and cref_comp_id={Purchaser_ID.ToString()}";
				Query = $"{Query} and (cref_contact_type='08' or cref_contact_type='00' or cref_contact_type='97')";

				snpCurOwn.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				frame_Current.Visible = !(snpCurOwn.BOF && snpCurOwn.EOF);

				snpCurOwn.Close();
				snpCurOwn = null;
			}
			catch (System.Exception excep)
			{

				this.Cursor = CursorHelper.CursorDefault;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Display_MajorChangeFrame_Error ({Information.Err().Number.ToString()}) {excep.Message}", "frm_Journal(SHOWMAJOR)");
				return;
			}

		} // Display_MajorChangeFrame

		private void Change_Transaction_Type()
		{



			try
			{

				string new_owner_type = "";
				string tmp_serno = "";
				tmp_serno = "";
				int tmp_modid = 0;
				tmp_modid = 0;
				string[] arr_Transmit_Fields = null;
				string newTransType = "";

				ADORecordSetHelper snpRefs = new ADORecordSetHelper(); //8/1/05 aey converted to ado
				string Query = "";

				// GET THE AIRCRAFT SERIAL NUMBER AND MODEL ID FOR TRANSMITS
				Query = "SELECT ac_ser_no_full, ac_amod_id FROM Aircraft WITH(NOLOCK)";
				Query = $"{Query} WHERE ac_id = {Reference_Ac_Id.ToString()} and ac_journ_id = 0";

				snpRefs.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpRefs.BOF && snpRefs.EOF))
				{
					tmp_serno = Convert.ToString(snpRefs["ac_ser_no_full"]);
					tmp_modid = Convert.ToInt32(snpRefs["ac_amod_id"]);
				}
				snpRefs.Close();
				snpRefs = null;

				// MODIFY THE TRANSACTION TYPE AND SUBJECT ON THE CURRENT JOURNAL RECORD
				// START A TRANSACTION
				modAdminCommon.ADO_Transaction("BeginTrans");

				// UPDATE THE SELLER
				Query = $"UPDATE Aircraft_Reference  SET cref_owner_percent={txt_Purchaser_Percent.Text.Trim()}";
				Query = $"{Query} where cref_ac_id={Reference_Ac_Id.ToString()}";
				Query = $"{Query} and cref_journ_id={Reference_Journal_ID.ToString()}";
				Query = $"{Query} and cref_contact_type='95'";
				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();

				// UPDATE THE PURCHASER
				Query = $"UPDATE Aircraft_Reference  SET cref_owner_percent={txt_Purchaser_Percent.Text.Trim()}";
				Query = $"{Query} where cref_ac_id={Reference_Ac_Id.ToString()}";
				Query = $"{Query} and cref_journ_id={Reference_Journal_ID.ToString()}";
				Query = $"{Query} and cref_contact_type='96'";
				DbCommand TempCommand_2 = null;
				TempCommand_2 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
				TempCommand_2.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand_2.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
				TempCommand_2.ExecuteNonQuery();

				// UPDATE THE JOURNAL ENTRY
				Query = "update Journal";


				switch(cbo_New_TransType.Text.Trim().Substring(0, Math.Min(1, cbo_New_TransType.Text.Trim().Length)))
				{
					case "S" : 
						newTransType = $"SS{txt_journ_subcategory_code.Text.Trim().Substring(Math.Max(txt_journ_subcategory_code.Text.Trim().Length - 4, 0))}"; 
						Query = $"{Query} set journ_subcategory_code = '{newTransType}',"; 
						Query = $"{Query} journ_subcat_code_part1 = 'SS',";  // added MSW - 7/28/22 
						 
						if (modCommon.GetTransWeb(newTransType))
						{
							Query = $"{Query} journ_action_date = '1/1/1900', "; //6/25/04
						}
						else
						{
							Query = $"{Query} journ_action_date = '{DateTime.Now.ToString()}', ";
						} 
						 
						Query = $"{Query} journ_subject = '{modAdminCommon.Fix_Quote(modCommon.BuildJournalSubject(newTransType, Seller_ID, Reference_Journal_ID, Purchaser_ID, Reference_Journal_ID))}'"; 
						Query = $"{Query} where journ_id = {Reference_Journal_ID.ToString()}"; 
						 
						DbCommand TempCommand_3 = null; 
						TempCommand_3 = modAdminCommon.ADODB_Trans_conn.CreateCommand(); 
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_3); 
						TempCommand_3.CommandText = Query; 
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064 
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021 
						TempCommand_3.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_3); 
						TempCommand_3.ExecuteNonQuery(); 
						 
						new_owner_type = "08"; 
						 
						break;
				}

				if (chk_ApplytoCurrent.CheckState == CheckState.Checked)
				{

					// CHANGE THE CURRENT AIRCRAFT
					Query = $"update aircraft SET ac_ownership_type = '{cbo_New_TransType.Text.Trim().Substring(0, Math.Min(1, cbo_New_TransType.Text.Trim().Length))}', ac_action_date = null";
					Query = $"{Query} WHERE ac_id = {Reference_Ac_Id.ToString()} and ac_journ_id = 0";

					DbCommand TempCommand_4 = null;
					TempCommand_4 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_4);
					TempCommand_4.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand_4.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_4);
					TempCommand_4.ExecuteNonQuery();

					// UPDATE THE OWNER
					Query = $"update Aircraft_Reference  set cref_owner_percent={txt_Current_Purchaser_Percent.Text},";
					Query = $"{Query} cref_contact_type='{new_owner_type}'";
					Query = $"{Query} where cref_ac_id={Reference_Ac_Id.ToString()}";
					Query = $"{Query} and cref_journ_id=0  and (cref_contact_type='00' or cref_contact_type='08' or cref_contact_type='97')";
					Query = $"{Query} and cref_comp_id={Purchaser_ID.ToString()}";

					DbCommand TempCommand_5 = null;
					TempCommand_5 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_5);
					TempCommand_5.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand_5.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_5);
					TempCommand_5.ExecuteNonQuery();

					// UPDATE THE SELLER IF THEY ARE ON THE RECORD
					Query = "insert into Aircraft_Reference  (cref_ac_id,cref_journ_id,cref_comp_id,cref_contact_type,cref_contact_id, cref_business_type,cref_transmit_seq_no,cref_primary_poc_flag,cref_owner_percent)";

					Query = $"{Query}values({Reference_Ac_Id.ToString()},";
					Query = $"{Query}0,";
					Query = $"{Query}{Seller_ID.ToString()},";
					Query = $"{Query}'{new_owner_type}',"; // contact type
					Query = $"{Query}'{Seller_Contact_ID.ToString()}',"; // contact id
					Query = $"{Query}'{Seller_Type}',"; // business type
					Query = $"{Query}99, 'N',"; // primary poc flag
					Query = $"{Query}{txt_Current_Seller_Percent.Text})";

					DbCommand TempCommand_6 = null;
					TempCommand_6 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_6);
					TempCommand_6.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand_6.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_6);
					TempCommand_6.ExecuteNonQuery();

					// RECORD AIRCRAFT TRANSMIT
					modAdminCommon.Record_Transmit(tmp_serno, Reference_Ac_Id, 0, tmp_modid, "Aircraft", "Change", ref arr_Transmit_Fields);

				}

				// RECORD TRANSACTION TRANSMIT
				modAdminCommon.Record_Transmit(tmp_serno, Reference_Ac_Id, Reference_Journal_ID, tmp_modid, "Transaction", "Change", ref arr_Transmit_Fields);

				// COMMIT THE TRANSACTION
				modAdminCommon.ADO_Transaction("CommitTrans");

				modAdminCommon.Record_Event("Transaction Change", $"Whole Sale to Share Sale- (Serial#{tmp_serno})", Reference_Ac_Id, Reference_Journal_ID, 0);

				modGlobalVars.RefreshACFromJournal = true;
				MessageBox.Show("Transaction Type Successfully Modified!", "Journal", MessageBoxButtons.OK, MessageBoxIcon.Information);
				this.Close();
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Change_Transaction_Type_Error ({Information.Err().Number.ToString()}) {excep.Message} : ACID[{Reference_Ac_Id.ToString()}] CMPID[{Reference_Comp_Id.ToString()}] JID[{Reference_Journal_ID.ToString()}]", "frm_Journal(CHANGETX)");
				modAdminCommon.ADO_Transaction("RollbackTrans");
				return;
			}
		} // Change_Transaction_Type

		public int Commit_Journal_Entry(bool skip_insert = false, string exclusive_name = "", int Exclusive_Comp_ID = 0, int exclusive_contact_id = 0)
		{

			int result = 0;
			ADORecordSetHelper ado_J = null;
			bool NeedsCommit = false;
			string Query = "";
			int C_Journal_Entry = 0;
			string dtToDay = DateTimeHelper.ToString(DateTime.Now).Trim();
			bool is_dereg = false;

			try
			{

				result = 0;
				is_dereg = false;

				// This routine will insert an entry into the 'Journal' table.
				this.Cursor = Cursors.WaitCursor;

				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Inserting a Journal Entry", Color.Blue);

				modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
				Reference_Ac_Id = modAdminCommon.Rec_Journal_Info.journ_ac_id;

				// INSERT the Journal Entry into the 'Journal' table
				ado_J = new ADORecordSetHelper();
				ado_J.CursorLocation = CursorLocationEnum.adUseClient;

				// If the "CheckStatus" gives us a 1, we are in a wrapped
				// transaction and we must use ADODB_Trans_conn.
				if (modAdminCommon.ADO_Transaction("CheckStatus") > 0)
				{
					ado_J.Open("SELECT * FROM Journal WHERE journ_id = -1", modAdminCommon.ADODB_Trans_conn, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);
				}
				else
				{
					ado_J.Open("SELECT * FROM Journal WHERE journ_id = -1", modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);
				}

				//UPGRADE_ISSUE: (2064) ADODB.CursorOptionEnum property CursorOptionEnum.adAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method ado_J.Supports was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				if (ado_J.Supports(UpgradeStubs.ADODB_CursorOptionEnum.getadAddNew()))
				{
					ado_J.AddNew();

					ado_J["journ_date"] = DateTime.Parse(DateTimeHelper.ToString(modAdminCommon.Rec_Journal_Info.journ_date).Trim()).ToString("d");

					ado_J["journ_subcategory_code"] = modAdminCommon.Rec_Journal_Info.journ_subcategory_code.Trim().Substring(0, Math.Min(6, modAdminCommon.Rec_Journal_Info.journ_subcategory_code.Trim().Length));

					ado_J["journ_subject"] = modAdminCommon.Rec_Journal_Info.journ_subject.Trim().Substring(0, Math.Min(120, modAdminCommon.Rec_Journal_Info.journ_subject.Trim().Length));

					if (Convert.ToString(ado_J["journ_subject"]).IndexOf("to: Deregistered") >= 0 || Convert.ToString(ado_J["journ_subject"]).IndexOf(", Deregistered") >= 0)
					{
						is_dereg = true;
					}
					else if (Convert.ToString(ado_J["journ_subject"]).IndexOf("from: Deregistered") >= 0 && Convert.ToString(ado_J["journ_subject"]).IndexOf("Aircraft Status changed") >= 0)
					{ 
						is_dereg = true; // this is to also create historical when you change from deregistered back to not that - 6/22/22
					}


					ado_J["journ_description"] = modAdminCommon.Rec_Journal_Info.journ_description.Trim().Substring(0, Math.Min(2000, modAdminCommon.Rec_Journal_Info.journ_description.Trim().Length));

					ado_J["journ_customer_note"] = modAdminCommon.Rec_Journal_Info.journ_customer_note.Trim().Substring(0, Math.Min(250, modAdminCommon.Rec_Journal_Info.journ_customer_note.Trim().Length));
					ado_J["journ_ac_id"] = modAdminCommon.Rec_Journal_Info.journ_ac_id;
					// MSW - 11/13/2012 ' this updates the yacht id field with the value placed in the temp Rec_Journal_Info.journ_yacht_id field
					ado_J["journ_yacht_id"] = modAdminCommon.Rec_Journal_Info.journ_yacht_id;

					ado_J["journ_contact_id"] = modAdminCommon.Rec_Journal_Info.journ_contact_id;
					ado_J["journ_comp_id"] = modAdminCommon.Rec_Journal_Info.journ_comp_id;

					ado_J["journ_user_id"] = modAdminCommon.Rec_Journal_Info.journ_user_id.Trim().Substring(0, Math.Min(4, modAdminCommon.Rec_Journal_Info.journ_user_id.Trim().Length));

					ado_J["journ_entry_date"] = DateTime.Parse(dtToDay).ToString("d");
					ado_J["journ_entry_time"] = DateTime.Parse(dtToDay).ToString("T");

					ado_J["journ_account_id"] = modAdminCommon.Rec_Journal_Info.journ_account_id.Trim().Substring(0, Math.Min(4, modAdminCommon.Rec_Journal_Info.journ_account_id.Trim().Length));
					ado_J["journ_prior_account_id"] = modAdminCommon.Rec_Journal_Info.journ_prior_account_id.Trim().Substring(0, Math.Min(4, modAdminCommon.Rec_Journal_Info.journ_prior_account_id.Trim().Length));
					ado_J["journ_status"] = modAdminCommon.Rec_Journal_Info.journ_status.Trim().Substring(0, Math.Min(1, modAdminCommon.Rec_Journal_Info.journ_status.Trim().Length));

					if (is_historical_yacht)
					{
						ado_J["journ_customer_note"] = modAdminCommon.Fix_Quote(txt_journ_customer_note.Text.Trim());
					}
					else
					{
						ado_J["journ_customer_note"] = modGlobalVars.cEmptyString;
					}

					// added in MSW - 3/29/19 - to create add from the aircraft model form
					if (Reference_Amod_Id > 0 && modAdminCommon.Rec_Journal_Info.journ_contact_id == 0 && modAdminCommon.Rec_Journal_Info.journ_yacht_id == 0 && modAdminCommon.Rec_Journal_Info.journ_ac_id == 0 && modAdminCommon.Rec_Journal_Info.journ_comp_id == 0)
					{
						ado_J["journ_amod_id"] = Reference_Amod_Id;
					}
					else
					{
						if (modAdminCommon.Rec_Journal_Info.journ_subject.IndexOf("Aircraft Model Update") >= 0)
						{
							ado_J["journ_amod_id"] = modAdminCommon.Rec_Journal_Info.journ_amod_id;
						}
						else
						{
							ado_J["journ_amod_id"] = 0;
						}
					}


					ado_J["journ_pcreckey"] = modAdminCommon.Rec_Journal_Info.journ_pcreckey;

					if (modCommon.GetTransWeb(modAdminCommon.Rec_Journal_Info.journ_subcategory_code.Trim()))
					{
						ado_J["journ_action_date"] = "1/1/1900"; //7/7/04 aey
					}
					else
					{
						ado_J["journ_action_date"] = DateTime.Parse(dtToDay).ToString().Trim();
					}

					ado_J.Update();

					modAdminCommon.Rec_Journal_Info.journ_pcreckey = 0;
					modAdminCommon.Rec_Journal_Info.journ_entry_date = DateTime.Parse(dtToDay);

					result = Convert.ToInt32(ado_J["journ_id"]);
					C_Journal_Entry = result;

					ado_J.Close();
					ado_J = null;

					modAdminCommon.Rec_Journal_Info.journ_yacht_id = 0;


					switch(modAdminCommon.Rec_Journal_Info.journ_subcategory_code.Trim().Substring(0, Math.Min(2, modAdminCommon.Rec_Journal_Info.journ_subcategory_code.Trim().Length)).ToUpper())
					{
						case "MA" : 
							modCommon.InsertPriorityEvent(modAdminCommon.Rec_Journal_Info.journ_subcategory_code.Trim().Substring(0, Math.Min(2, modAdminCommon.Rec_Journal_Info.journ_subcategory_code.Trim().Length)).ToUpper(), modAdminCommon.Rec_Journal_Info.journ_ac_id, C_Journal_Entry, modAdminCommon.EventTempAskingPrice, modAdminCommon.EventTempCompID, modAdminCommon.EventTempContactID); 
							 
							modAdminCommon.EventTempCompID = 0; 
							modAdminCommon.EventTempContactID = 0; 
							modAdminCommon.EventTempAskingPrice = ""; 
							 
							break;
						case "OM" : 
							if (modAdminCommon.EventTempCompName == "Awaiting Documentation")
							{
								modCommon.InsertPriorityEvent(modAdminCommon.Rec_Journal_Info.journ_subcategory_code.Trim().Substring(0, Math.Min(2, modAdminCommon.Rec_Journal_Info.journ_subcategory_code.Trim().Length)).ToUpper(), modAdminCommon.Rec_Journal_Info.journ_ac_id, C_Journal_Entry, $"Current Owner: {modAdminCommon.EventTempCompName}", 0);
							}
							else
							{
								modCommon.InsertPriorityEvent(modAdminCommon.Rec_Journal_Info.journ_subcategory_code.Trim().Substring(0, Math.Min(2, modAdminCommon.Rec_Journal_Info.journ_subcategory_code.Trim().Length)).ToUpper(), modAdminCommon.Rec_Journal_Info.journ_ac_id, C_Journal_Entry, $"Current Owner: {modAdminCommon.EventTempCompName}", modAdminCommon.EventTempCompID);
							} 
							 
							modAdminCommon.EventTempCompName = ""; 
							modAdminCommon.EventTempCompID = 0; 
							 
							break;
					}

					if (skip_insert)
					{
					}
					else
					{

						switch(modAdminCommon.Rec_Journal_Info.journ_subcategory_code.Trim().ToUpper())
						{
							case "EXOFF" : 
								 
								modAdminCommon.EventTempCompName = exclusive_name; 
								modAdminCommon.EventTempCompID = Exclusive_Comp_ID; 
								modAdminCommon.EventTempContactID = exclusive_contact_id; 
								 
								if (modAdminCommon.EventTempCompName.Trim() != "")
								{
									modCommon.InsertPriorityEvent("EXOFF", modAdminCommon.Rec_Journal_Info.journ_ac_id, C_Journal_Entry, $"Previously With: {modAdminCommon.EventTempCompName}", modAdminCommon.EventTempCompID, modAdminCommon.EventTempContactID);
									modAdminCommon.EventTempCompName = "";
									modAdminCommon.EventTempCompID = 0;
									modAdminCommon.EventTempContactID = 0;
								}
								else
								{
									// CHANGED MSW - 2/19/20 - EXOFF CHANGE
									modCommon.InsertPriorityEvent("EXOFF", modAdminCommon.Rec_Journal_Info.journ_ac_id, C_Journal_Entry, "", modAdminCommon.EventTempCompID, modAdminCommon.EventTempContactID);
								} 
								 
								break;
							case "EXON" : 
								 
								if (modAdminCommon.EventTempCompName.Trim() == "")
								{
									modAircraft.Return_Aircraft_Exclusive_Broker_CompName_CompId_ContactId(modAdminCommon.Rec_Journal_Info.journ_ac_id, ref modAdminCommon.EventTempCompName, ref modAdminCommon.EventTempCompID, ref modAdminCommon.EventTempContactID);
								} 
								 
								if (modAdminCommon.EventTempCompName.Trim() != "")
								{
									modCommon.InsertPriorityEvent("EXON", modAdminCommon.Rec_Journal_Info.journ_ac_id, C_Journal_Entry, modAdminCommon.EventTempCompName, modAdminCommon.EventTempCompID, modAdminCommon.EventTempContactID);
									modAdminCommon.EventTempCompName = "";
									modAdminCommon.EventTempCompID = 0;
									modAdminCommon.EventTempContactID = 0;
								}
								else
								{
									modCommon.InsertPriorityEvent("EXON", modAdminCommon.Rec_Journal_Info.journ_ac_id, C_Journal_Entry);
								} 
								 
								break;
						}
					}

				} // ado_J.Supports(adAddNew)


				switch(modAdminCommon.Rec_Journal_Info.journ_subcategory_code.Trim().Substring(0, Math.Min(2, modAdminCommon.Rec_Journal_Info.journ_subcategory_code.Trim().Length)).ToUpper())
				{
					// Create a history record for anything with a type like:
					// "Withdrawn from Use", "Written Off", "Stolen", "Back In Service", "Made Available", or "Off Market", or "Abandoned"
					case "WF" : case "WO" : case "ST" : case "BI" : case "MA" : case "OM" : case "AB" : 
						 
						modCommon.Transaction_Save_Aircraft_History(C_Journal_Entry, tmpOwnershipType, modGlobalVars.snp_TransAircraft, modGlobalVars.snp_TransAircraft_Reference, modGlobalVars.snp_TransAircraft_Features, modGlobalVars.snp_TransAircraft_Avionics, modGlobalVars.snp_TransAircraft_Certified, modGlobalVars.snp_TransAircraft_Specification, modGlobalVars.snp_TransAircraft_Details, modGlobalVars.snp_TransAircraft_FAA_Document, false, "", true, modAdminCommon.Rec_Journal_Info.journ_subcategory_code.Trim()); 
						 
						modCommon.Transaction_Save_Aircraft_Company_History(C_Journal_Entry, modGlobalVars.snp_TransAircraft_Companies, modGlobalVars.snp_TransAircraft_Contacts, modGlobalVars.snp_TransAircraft_Company_Phones, modGlobalVars.snp_TransAircraft_Company_Btypes, modGlobalVars.snp_TransAircraft_Company_Certs); 
						 
						break;
				}


				// if its dereg, it will be an RN, so it wont fall in above
				// BUT REMAKE HISTORY THE SAME - MSW - 11/8/21 -----------------------------------------
				if (is_dereg)
				{
					modCommon.Transaction_Save_Aircraft_History(C_Journal_Entry, tmpOwnershipType, modGlobalVars.snp_TransAircraft, modGlobalVars.snp_TransAircraft_Reference, modGlobalVars.snp_TransAircraft_Features, modGlobalVars.snp_TransAircraft_Avionics, modGlobalVars.snp_TransAircraft_Certified, modGlobalVars.snp_TransAircraft_Specification, modGlobalVars.snp_TransAircraft_Details, modGlobalVars.snp_TransAircraft_FAA_Document, false, "", true, modAdminCommon.Rec_Journal_Info.journ_subcategory_code.Trim());

					modCommon.Transaction_Save_Aircraft_Company_History(C_Journal_Entry, modGlobalVars.snp_TransAircraft_Companies, modGlobalVars.snp_TransAircraft_Contacts, modGlobalVars.snp_TransAircraft_Company_Phones, modGlobalVars.snp_TransAircraft_Company_Btypes, modGlobalVars.snp_TransAircraft_Company_Certs);

				}
				//-----------------------------------------------------------------------------------------



				this.Cursor = CursorHelper.CursorDefault;
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);

				return result;
			}
			catch (System.Exception excep)
			{

				this.Cursor = CursorHelper.CursorDefault;
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
				result = 0;

				if (ado_J.State == ConnectionState.Open)
				{
					ado_J.CancelUpdate();
					ado_J.Close();
				}


				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Commit_Journal_Entry_Error ({Information.Err().Number.ToString()}) {excep.Message} : ACID[{Reference_Ac_Id.ToString()}] CMPID[{Reference_Comp_Id.ToString()}] JID[{Reference_Journal_ID.ToString()}]", "frm_Journal(COMMIT)");
				return result;
			}
		} // Commit_Journal_Entry

		public int Commit_Journal_Entry_Long_Subject(bool skip_insert = false, string exclusive_name = "", int Exclusive_Comp_ID = 0, int exclusive_contact_id = 0)
		{

			int result = 0;
			ADORecordSetHelper ado_J = null;
			bool NeedsCommit = false;
			string Query = "";
			int C_Journal_Entry = 0;
			string dtToDay = DateTimeHelper.ToString(DateTime.Now).Trim();

			try
			{

				result = 0;
				// This routine will insert an entry into the 'Journal' table.
				this.Cursor = Cursors.WaitCursor;

				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Inserting a Journal Entry", Color.Blue);

				modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
				Reference_Ac_Id = modAdminCommon.Rec_Journal_Info.journ_ac_id;

				// INSERT the Journal Entry into the 'Journal' table
				ado_J = new ADORecordSetHelper();
				ado_J.CursorLocation = CursorLocationEnum.adUseClient;

				if (modAdminCommon.ADO_Transaction("CheckStatus") > 0)
				{
					ado_J.Open("SELECT * FROM Journal WHERE journ_id = -1", modAdminCommon.ADODB_Trans_conn, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);
				}
				else
				{
					ado_J.Open("SELECT * FROM Journal WHERE journ_id = -1", modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);
				}

				//UPGRADE_ISSUE: (2064) ADODB.CursorOptionEnum property CursorOptionEnum.adAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method ado_J.Supports was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				if (ado_J.Supports(UpgradeStubs.ADODB_CursorOptionEnum.getadAddNew()))
				{
					ado_J.AddNew();

					ado_J["journ_date"] = DateTime.Parse(DateTimeHelper.ToString(modAdminCommon.Rec_Journal_Info.journ_date).Trim()).ToString("d");

					ado_J["journ_subcategory_code"] = modAdminCommon.Rec_Journal_Info.journ_subcategory_code.Trim().Substring(0, Math.Min(6, modAdminCommon.Rec_Journal_Info.journ_subcategory_code.Trim().Length));

					ado_J["journ_subject"] = modAdminCommon.Rec_Journal_Info.journ_subject.Trim().Substring(0, Math.Min(199, modAdminCommon.Rec_Journal_Info.journ_subject.Trim().Length));

					ado_J["journ_description"] = modAdminCommon.Rec_Journal_Info.journ_description.Trim().Substring(0, Math.Min(2000, modAdminCommon.Rec_Journal_Info.journ_description.Trim().Length));

					ado_J["journ_customer_note"] = modAdminCommon.Rec_Journal_Info.journ_customer_note.Trim().Substring(0, Math.Min(250, modAdminCommon.Rec_Journal_Info.journ_customer_note.Trim().Length));
					ado_J["journ_ac_id"] = modAdminCommon.Rec_Journal_Info.journ_ac_id;
					// MSW - 11/13/2012 ' this updates the yacht id field with the value placed in the temp Rec_Journal_Info.journ_yacht_id field
					ado_J["journ_yacht_id"] = modAdminCommon.Rec_Journal_Info.journ_yacht_id;

					ado_J["journ_contact_id"] = modAdminCommon.Rec_Journal_Info.journ_contact_id;
					ado_J["journ_comp_id"] = modAdminCommon.Rec_Journal_Info.journ_comp_id;

					ado_J["journ_user_id"] = modAdminCommon.Rec_Journal_Info.journ_user_id.Trim().Substring(0, Math.Min(4, modAdminCommon.Rec_Journal_Info.journ_user_id.Trim().Length));

					ado_J["journ_entry_date"] = DateTime.Parse(dtToDay).ToString("d");
					ado_J["journ_entry_time"] = DateTime.Parse(dtToDay).ToString("T");

					ado_J["journ_account_id"] = modAdminCommon.Rec_Journal_Info.journ_account_id.Trim().Substring(0, Math.Min(4, modAdminCommon.Rec_Journal_Info.journ_account_id.Trim().Length));
					ado_J["journ_prior_account_id"] = modAdminCommon.Rec_Journal_Info.journ_prior_account_id.Trim().Substring(0, Math.Min(4, modAdminCommon.Rec_Journal_Info.journ_prior_account_id.Trim().Length));
					ado_J["journ_status"] = modAdminCommon.Rec_Journal_Info.journ_status.Trim().Substring(0, Math.Min(1, modAdminCommon.Rec_Journal_Info.journ_status.Trim().Length));

					if (is_historical_yacht)
					{
						ado_J["journ_customer_note"] = modAdminCommon.Fix_Quote(txt_journ_customer_note.Text.Trim());
					}
					else
					{
						ado_J["journ_customer_note"] = modGlobalVars.cEmptyString;
					}

					// added in MSW - 3/29/19 - to create add from the aircraft model form
					if (Reference_Amod_Id > 0 && modAdminCommon.Rec_Journal_Info.journ_contact_id == 0 && modAdminCommon.Rec_Journal_Info.journ_yacht_id == 0 && modAdminCommon.Rec_Journal_Info.journ_ac_id == 0 && modAdminCommon.Rec_Journal_Info.journ_comp_id == 0)
					{
						ado_J["journ_amod_id"] = Reference_Amod_Id;
					}
					else
					{
						if (modAdminCommon.Rec_Journal_Info.journ_subject.IndexOf("Aircraft Model Update") >= 0)
						{
							ado_J["journ_amod_id"] = modAdminCommon.Rec_Journal_Info.journ_amod_id;
						}
						else
						{
							ado_J["journ_amod_id"] = 0;
						}
					}


					ado_J["journ_pcreckey"] = modAdminCommon.Rec_Journal_Info.journ_pcreckey;

					if (modCommon.GetTransWeb(modAdminCommon.Rec_Journal_Info.journ_subcategory_code.Trim()))
					{
						ado_J["journ_action_date"] = "1/1/1900"; //7/7/04 aey
					}
					else
					{
						ado_J["journ_action_date"] = DateTime.Parse(dtToDay).ToString().Trim();
					}

					ado_J.Update();

					modAdminCommon.Rec_Journal_Info.journ_pcreckey = 0;
					modAdminCommon.Rec_Journal_Info.journ_entry_date = DateTime.Parse(dtToDay);

					result = Convert.ToInt32(ado_J["journ_id"]);
					C_Journal_Entry = result;

					ado_J.Close();
					ado_J = null;

					modAdminCommon.Rec_Journal_Info.journ_yacht_id = 0;


					switch(modAdminCommon.Rec_Journal_Info.journ_subcategory_code.Trim().Substring(0, Math.Min(2, modAdminCommon.Rec_Journal_Info.journ_subcategory_code.Trim().Length)).ToUpper())
					{
						case "MA" : 
							modCommon.InsertPriorityEvent(modAdminCommon.Rec_Journal_Info.journ_subcategory_code.Trim().Substring(0, Math.Min(2, modAdminCommon.Rec_Journal_Info.journ_subcategory_code.Trim().Length)).ToUpper(), modAdminCommon.Rec_Journal_Info.journ_ac_id, C_Journal_Entry, modAdminCommon.EventTempAskingPrice, modAdminCommon.EventTempCompID, modAdminCommon.EventTempContactID); 
							 
							modAdminCommon.EventTempCompID = 0; 
							modAdminCommon.EventTempContactID = 0; 
							modAdminCommon.EventTempAskingPrice = ""; 
							 
							break;
						case "OM" : 
							if (modAdminCommon.EventTempCompName == "Awaiting Documentation")
							{
								modCommon.InsertPriorityEvent(modAdminCommon.Rec_Journal_Info.journ_subcategory_code.Trim().Substring(0, Math.Min(2, modAdminCommon.Rec_Journal_Info.journ_subcategory_code.Trim().Length)).ToUpper(), modAdminCommon.Rec_Journal_Info.journ_ac_id, C_Journal_Entry, $"Current Owner: {modAdminCommon.EventTempCompName}", 0);
							}
							else
							{
								modCommon.InsertPriorityEvent(modAdminCommon.Rec_Journal_Info.journ_subcategory_code.Trim().Substring(0, Math.Min(2, modAdminCommon.Rec_Journal_Info.journ_subcategory_code.Trim().Length)).ToUpper(), modAdminCommon.Rec_Journal_Info.journ_ac_id, C_Journal_Entry, $"Current Owner: {modAdminCommon.EventTempCompName}", modAdminCommon.EventTempCompID);
							} 
							 
							modAdminCommon.EventTempCompName = ""; 
							modAdminCommon.EventTempCompID = 0; 
							 
							break;
					}

					if (skip_insert)
					{
					}
					else
					{

						switch(modAdminCommon.Rec_Journal_Info.journ_subcategory_code.Trim().ToUpper())
						{
							case "EXOFF" : 
								 
								modAdminCommon.EventTempCompName = exclusive_name; 
								modAdminCommon.EventTempCompID = Exclusive_Comp_ID; 
								modAdminCommon.EventTempContactID = exclusive_contact_id; 
								 
								if (modAdminCommon.EventTempCompName.Trim() != "")
								{
									modCommon.InsertPriorityEvent("EXOFF", modAdminCommon.Rec_Journal_Info.journ_ac_id, C_Journal_Entry, $"Previously With: {modAdminCommon.EventTempCompName}", modAdminCommon.EventTempCompID, modAdminCommon.EventTempContactID);
									modAdminCommon.EventTempCompName = "";
									modAdminCommon.EventTempCompID = 0;
									modAdminCommon.EventTempContactID = 0;
								}
								else
								{
									// CHANGED MSW - 2/19/20 - EXOFF CHANGE
									modCommon.InsertPriorityEvent("EXOFF", modAdminCommon.Rec_Journal_Info.journ_ac_id, C_Journal_Entry, "", modAdminCommon.EventTempCompID, modAdminCommon.EventTempContactID);
								} 
								 
								break;
							case "EXON" : 
								 
								if (modAdminCommon.EventTempCompName.Trim() == "")
								{
									modAircraft.Return_Aircraft_Exclusive_Broker_CompName_CompId_ContactId(modAdminCommon.Rec_Journal_Info.journ_ac_id, ref modAdminCommon.EventTempCompName, ref modAdminCommon.EventTempCompID, ref modAdminCommon.EventTempContactID);
								} 
								 
								if (modAdminCommon.EventTempCompName.Trim() != "")
								{
									modCommon.InsertPriorityEvent("EXON", modAdminCommon.Rec_Journal_Info.journ_ac_id, C_Journal_Entry, modAdminCommon.EventTempCompName, modAdminCommon.EventTempCompID, modAdminCommon.EventTempContactID);
									modAdminCommon.EventTempCompName = "";
									modAdminCommon.EventTempCompID = 0;
									modAdminCommon.EventTempContactID = 0;
								}
								else
								{
									modCommon.InsertPriorityEvent("EXON", modAdminCommon.Rec_Journal_Info.journ_ac_id, C_Journal_Entry);
								} 
								 
								break;
						}
					}

				} // ado_J.Supports(adAddNew)


				switch(modAdminCommon.Rec_Journal_Info.journ_subcategory_code.Trim().Substring(0, Math.Min(2, modAdminCommon.Rec_Journal_Info.journ_subcategory_code.Trim().Length)).ToUpper())
				{
					// Create a history record for anything with a type like:
					// "Withdrawn from Use", "Written Off", "Stolen", "Back In Service", "Made Available", or "Off Market", or "Abandoned"
					case "WF" : case "WO" : case "ST" : case "BI" : case "MA" : case "OM" : case "AB" : 
						 
						modCommon.Transaction_Save_Aircraft_History(C_Journal_Entry, tmpOwnershipType, modGlobalVars.snp_TransAircraft, modGlobalVars.snp_TransAircraft_Reference, modGlobalVars.snp_TransAircraft_Features, modGlobalVars.snp_TransAircraft_Avionics, modGlobalVars.snp_TransAircraft_Certified, modGlobalVars.snp_TransAircraft_Specification, modGlobalVars.snp_TransAircraft_Details, modGlobalVars.snp_TransAircraft_FAA_Document, false, "", true, modAdminCommon.Rec_Journal_Info.journ_subcategory_code.Trim()); 
						 
						modCommon.Transaction_Save_Aircraft_Company_History(C_Journal_Entry, modGlobalVars.snp_TransAircraft_Companies, modGlobalVars.snp_TransAircraft_Contacts, modGlobalVars.snp_TransAircraft_Company_Phones, modGlobalVars.snp_TransAircraft_Company_Btypes, modGlobalVars.snp_TransAircraft_Company_Certs); 
						 
						break;
				}

				this.Cursor = CursorHelper.CursorDefault;
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);

				return result;
			}
			catch (System.Exception excep)
			{

				this.Cursor = CursorHelper.CursorDefault;
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
				result = 0;

				if (ado_J.State == ConnectionState.Open)
				{
					ado_J.CancelUpdate();
					ado_J.Close();
				}


				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Commit_Journal_Entry_Error ({Information.Err().Number.ToString()}) {excep.Message} : ACID[{Reference_Ac_Id.ToString()}] CMPID[{Reference_Comp_Id.ToString()}] JID[{Reference_Journal_ID.ToString()}]", "frm_Journal(COMMIT)");
				return result;
			}
		} // Commit_Journal_Entry


		private bool isInitializingComponent;
		private void radio_id_CheckedChanged(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.radio_id, eventSender);
			if (((RadioButton) eventSender).Checked)
			{
				if (isInitializingComponent)
				{
					return;
				}

				if (Index == 0)
				{
					txt_journ_subject.Text = "IDNOTE - Attempted to ID";
				}
				else if (Index == 1)
				{ 
					txt_journ_subject.Text = "IDNOTE - IDd";
				}
				else if (Index == 2)
				{ 
					txt_journ_subject.Text = "IDNOTE - ID Lead Sent";
				}



			}
		}
	}
}