using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Helpers;

namespace JETNET_Homebase
{
	internal static class modAircraft
	{


		internal static bool ChangeHistoricalContactType(int nPassedCompanyID, int nPassedContactID, int nPassedContactJID, ref string sPassedContactType, string sNewCompanyName, ref ADORecordSetHelper snp_Company, ref ADORecordSetHelper snp_Contacts, ref ADORecordSetHelper snp_Company_Phones, ref ADORecordSetHelper snp_Company_Btypes, ref string sOldCompanyType, ref string sOldCompanyName, ref string sWillOwnerChange, ref int nContactChangeJID, ref int nCompanyChangeJID, ref bool bIsAwaitingDoc)
		{

			bool result = false;
			bool owner_is_primary_POC = false;

			bool bHistoricalCompanyExists = false;
			bool bHistoricalContactExists = false;
			bool bNeedCurrentCompany = false;
			bool bRemoveOldReference = false;

			string Query = "";
			System.DateTime dtJournalDate = DateTime.FromOADate(0);
			string sJournalSubcategoryCode = "";

			int nPriorCompanyID = 0;
			int nPriorContactID = 0;
			int nPriorReferenceID = 0;
			int nNewContactID = 0;
			int nTmpJournalID = 0;
			int max_cref_id = 0;

			string sBusinessType = "";
			string sJournSubject = "";

			ADORecordSetHelper adoRs = new ADORecordSetHelper();
			ADORecordSetHelper adoc_new = new ADORecordSetHelper();
			ADORecordSetHelper snp_NextCrefid = null;

			string[] arrNames = new string[]{""};


			try
			{

				bNeedCurrentCompany = false;
				bHistoricalCompanyExists = false;
				bHistoricalContactExists = false;
				bRemoveOldReference = false;

				owner_is_primary_POC = false;
				bIsAwaitingDoc = false;

				sJournSubject = "";

				nTmpJournalID = 0;

				// CREATE A CURRENT COMPANY IF WE NEED ONE
				if (!modAdminCommon.Exist($"SELECT comp_name FROM Company WITH(NOLOCK) WHERE comp_id = {nPassedCompanyID.ToString()} AND comp_journ_id = 0"))
				{
					bNeedCurrentCompany = true;
					if (!modCommon.CreateCurrentCompanyRecordsets(nPassedCompanyID, ref nTmpJournalID))
					{
						throw new Exception();
					}
				}

				if (bNeedCurrentCompany)
				{
					sBusinessType = modCommon.GetBusinessTypeToUse(nPassedCompanyID, nTmpJournalID);
				}
				else
				{
					sBusinessType = modCommon.GetBusinessTypeToUse(nPassedCompanyID, 0);
				}

				if (sBusinessType == "")
				{
					MessageBox.Show($"Business Type is Blank!{Environment.NewLine}{Environment.NewLine}Please assign a business type to the company and try again.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					throw new Exception();
				}

				if (sPassedContactType.Trim() == "0")
				{
					sPassedContactType = "00";
				}

				// **************************************************
				// GET THE PRIOR COMPANY ID AND AIRCRAFT REFERENCE ID
				// this is the company/contact to be replaced in the aircraft_reference table

				Query = "SELECT cref_comp_id,cref_id,cref_contact_id FROM Aircraft_Reference WITH(NOLOCK)";
				Query = $"{Query} WHERE cref_contact_type = '{sPassedContactType}'";
				Query = $"{Query} AND cref_journ_id = {nPassedContactJID.ToString()}";

				adoRs.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(adoRs.EOF && adoRs.BOF))
				{

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(adoRs["cref_comp_id"]))
					{
						nPriorCompanyID = Convert.ToInt32(adoRs["cref_comp_id"]);
					}
					else
					{
						nPriorCompanyID = 0;
					}

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(adoRs["cref_id"]))
					{
						nPriorReferenceID = Convert.ToInt32(adoRs["cref_id"]);
					}
					else
					{
						nPriorReferenceID = 0;
					}

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(adoRs["cref_contact_id"]))
					{
						nPriorContactID = Convert.ToInt32(adoRs["cref_contact_id"]);
					}
					else
					{
						nPriorContactID = 0;
					}

				}

				adoRs.Close();

				// GET THE DATE OF THE JOURNAL RECORD
				Query = $"SELECT journ_date, journ_subcategory_code FROM Journal WITH(NOLOCK) WHERE journ_id = {nPassedContactJID.ToString()}";

				adoRs.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(adoRs.EOF && adoRs.BOF))
				{
					dtJournalDate = DateTime.Parse(Convert.ToString(adoRs["journ_date"]));
					sJournalSubcategoryCode = Convert.ToString(adoRs["journ_subcategory_code"]).Trim();
				}

				adoRs.Close();

				// CHECK FOR COMPANY HISTORY RECORD
				Query = "";
				Query = $"SELECT comp_id FROM Company WITH(NOLOCK) WHERE comp_id = {nPassedCompanyID.ToString()}";
				Query = $"{Query} AND comp_journ_id = {nPassedContactJID.ToString()}";

				bHistoricalCompanyExists = modAdminCommon.Exist(Query);

				// DETERMINE IF HISTORY RECORD FOR THE CONTACT SELECTED EXISTS.
				nNewContactID = 0;

				if (nPriorContactID > 0)
				{ //9/14/04 aey
					Query = "";
					Query = $"SELECT contact_id FROM Contact WITH(NOLOCK) WHERE contact_id = {nPriorContactID.ToString()}";
					Query = $"{Query} AND contact_journ_id = {nPassedContactJID.ToString()}";

					bHistoricalContactExists = modAdminCommon.Exist(Query); //Done checking for existence of contact_id

				} // IF CONTACT ID

				// GET A COPY OF THE NEW COMPANY IF NEEDED FOR USE IN MAKING A HISTORY RECORD
				if (!bHistoricalCompanyExists)
				{
					if (!modCommon.Transaction_Get_Company_History_Recordsets(nPassedCompanyID.ToString()))
					{
						throw new Exception();
					}
				}

				if (!bHistoricalContactExists)
				{

					nNewContactID = CreateHistoricalContact(nPassedCompanyID, nPassedContactID, nPassedContactJID);

					if (nNewContactID <= 0)
					{
						throw new Exception();
					}
					else if (nPassedContactID != 0)
					{ 
						nNewContactID = nPassedContactID;
					}

				}
				else
				{
					nNewContactID = nPassedContactID;
				}

				// ONLY NEED TO DO THIS IF CHANGING OWNER

				if (sWillOwnerChange.ToUpper() == "YES")
				{ //aey 6/8/04
					// DETERMINE IF THE OWNER IS AWAITING DOCUMENTATION AND WHETHER THE OWNER
					// IS THE PRIMARY POC FOR THE AIRCRAFT

					Query = "SELECT comp_id, comp_name, cref_primary_poc_flag";
					Query = $"{Query} FROM Company WITH(NOLOCK), Aircraft_Reference WITH(NOLOCK)";
					Query = $"{Query} WHERE comp_id = cref_comp_id";
					Query = $"{Query} AND cref_journ_id = comp_journ_id";
					Query = $"{Query} AND comp_journ_id = 0";
					Query = $"{Query} AND cref_contact_type = '00'";
					Query = $"{Query} AND cref_ac_id = {modAdminCommon.gbl_Aircraft_ID.ToString()}";

					adoRs.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!(adoRs.BOF && adoRs.EOF))
					{
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(adoRs["cref_primary_poc_flag"]))
						{
							if (Convert.ToString(adoRs["cref_primary_poc_flag"]).Trim().ToUpper() == "Y")
							{
								owner_is_primary_POC = true;
							}
						}
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(adoRs["Comp_Name"]))
						{
							if (Convert.ToString(adoRs["Comp_Name"]).Trim().ToUpper() == ("Awaiting Documentation").ToUpper())
							{
								bIsAwaitingDoc = true;
							}
						}
					}

					adoRs.Close();

				}

				// IF THE COMPANY HAS NO OTHER ROLES ON THE AIRCRAFT JOURNAL RECORD THEN MARK FOR REMOVAL
				if (!bIsAwaitingDoc)
				{
					//see if company has other roles on the aircraft reference table
					Query = "SELECT cref_id FROM Aircraft_Reference WITH(NOLOCK)";
					Query = $"{Query} WHERE cref_comp_id = {nPriorCompanyID.ToString()}";
					Query = $"{Query} AND cref_journ_id = {nPassedContactJID.ToString()}";
					Query = $"{Query} AND cref_contact_type <> '{sPassedContactType}'";

					if (!modAdminCommon.Exist(Query))
					{
						bRemoveOldReference = true;
					}
				}
				else
				{
					//see if this company is on other aircraft
					Query = "SELECT cref_id FROM Aircraft_Reference WITH(NOLOCK)";
					Query = $"{Query} WHERE cref_comp_id = {nPriorCompanyID.ToString()}";
					Query = $"{Query} AND cref_ac_id <> {modAdminCommon.gbl_Aircraft_ID.ToString()}";

					if (!modAdminCommon.Exist(Query))
					{
						bRemoveOldReference = true;
					}
				}

				// BEGIN TRANSACTION PROCESSING
				modAdminCommon.ADO_Transaction("BeginTrans");

				// CREATE A NEW HISTORICAL COMPANY IF WE NEED TO
				if (bNeedCurrentCompany)
				{
					if (!modCommon.CreateCurrentCompanyRecord(nPassedCompanyID, nPassedContactJID))
					{
						throw new Exception();
					}
				}

				// *************************************************************
				// SAVE COMPANY HISTORY.
				if (!bHistoricalCompanyExists)
				{
					// IF THE USER HAS SELECTED A NEW SELLER - OTHER THAN OWNER SAVE THE SELLER COMPANY HISTORY
					if (!modCommon.Transaction_Save_Company_History(nPassedContactJID, ref snp_Company, ref snp_Contacts, ref snp_Company_Phones, ref snp_Company_Btypes, ref modGlobalVars.snp_Company_Certs))
					{
						throw new Exception(); //aey 6/8/04
					}

				}

				// UPDATE THE HISTORICAL REFERENCE RECORD
				Query = $"UPDATE Aircraft_Reference SET cref_contact_id = {nNewContactID.ToString()}";
				Query = $"{Query}, cref_comp_id = {nPassedCompanyID.ToString()}";
				Query = $"{Query}, cref_business_type = '{sBusinessType.Substring(Math.Min(0, sBusinessType.Length), Math.Min(2, Math.Max(0, sBusinessType.Length))).Trim()}'";
				Query = $"{Query} WHERE cref_id = {nPriorReferenceID.ToString()}";

				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();

				//  MARK THE AIRCRAFT SO THAT WE KNOW IT WAS CHANGED
				Query = $"UPDATE Aircraft SET ac_upd_date = '{DateTime.Parse(modAdminCommon.GetDateTime()).ToString()}',";
				Query = $"{Query}ac_upd_user_id = '{modAdminCommon.gbl_User_ID}',ac_action_date = NULL";
				Query = $"{Query} WHERE ac_id = {modAdminCommon.gbl_Aircraft_ID.ToString()} AND ac_journ_id = {nPassedContactJID.ToString()}";

				DbCommand TempCommand_2 = null;
				TempCommand_2 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
				TempCommand_2.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand_2.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
				TempCommand_2.ExecuteNonQuery();

				// RECORD TRANSMITS FOR CHANGES TO FRACTIONAL SELLER
				if (sPassedContactType.Trim() == "69")
				{
					modAdminCommon.Record_Transmit("0", modAdminCommon.gbl_Aircraft_ID, nPassedContactJID, 0, "Fractional Sold", "Delete", ref arrNames, nPriorCompanyID);
					modAdminCommon.Record_Transmit("0", modAdminCommon.gbl_Aircraft_ID, nPassedContactJID, 0, "Fractional Sold", "Add", ref arrNames, nPassedCompanyID);
				}

				// RECORD A JOURNAL ENTRY FOR CHANGING THE PURCHASER
				modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(modAdminCommon.DateToday);

				// changed purchaser MSW 9/20/19
				if (sOldCompanyType.ToLower().Trim().IndexOf("seller") >= 0)
				{
					modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "CHSEL";
				}
				else if (sOldCompanyType.ToLower().Trim().IndexOf("purchaser") >= 0)
				{ 
					modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "CHPUR";
				}
				else
				{
					modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "AC"; // ac history action
				}


				// build the journal subject string
				sJournSubject = $"Modified {sOldCompanyType.Trim()} From {sOldCompanyName.Trim()} To {sNewCompanyName.Trim()}";
				sJournSubject = $"{sJournSubject}{((sOldCompanyName == sNewCompanyName) ? ((nPriorContactID == nNewContactID) ? "- No Change to Contact" : " - Contact Name Changed") : "")}";
				sJournSubject = $"{sJournSubject}{modGlobalVars.cSingleSpace}on{modGlobalVars.cSingleSpace}{DateTimeHelper.ToString(dtJournalDate).Trim()}";
				sJournSubject = sJournSubject.Trim().Substring(0, Math.Min(120, sJournSubject.Trim().Length));

				modAdminCommon.Rec_Journal_Info.journ_subject = sJournSubject;
				modAdminCommon.Rec_Journal_Info.journ_description = modGlobalVars.cEmptyString;
				modAdminCommon.Rec_Journal_Info.journ_ac_id = modAdminCommon.gbl_Aircraft_ID;
				modAdminCommon.Rec_Journal_Info.journ_comp_id = 0;
				modAdminCommon.Rec_Journal_Info.journ_contact_id = 0;
				modAdminCommon.Rec_Journal_Info.journ_account_id = modGlobalVars.cEmptyString;
				modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
				modAdminCommon.Rec_Journal_Info.journ_status = "A";

				nContactChangeJID = frm_Journal.DefInstance.Commit_Journal_Entry();

				if (nContactChangeJID > 0)
				{

					// IF THE OWNER CHANGED
					if (sWillOwnerChange.ToUpper() == "YES")
					{

						//ONLY ENTER A CHANGE OWNER IF WE ARE NOT
						//GOING TO ENTER A
						if (!bIsAwaitingDoc)
						{
							// RECORD A JOURNAL ENTRY FOR THE OWNER CHANGE
							modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(modAdminCommon.DateToday);
							modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "CHOWR";

							// build the journal subject string
							sJournSubject = $"Modified Owner From {DateTimeHelper.ToString(dtJournalDate).Trim()}{modGlobalVars.cSingleSpace}{sOldCompanyName.Trim()} To {sNewCompanyName.Trim()}";
							sJournSubject = sJournSubject.Substring(0, Math.Min(120, sJournSubject.Length));

							modAdminCommon.Rec_Journal_Info.journ_subject = sJournSubject;
							modAdminCommon.Rec_Journal_Info.journ_description = modGlobalVars.cEmptyString;
							modAdminCommon.Rec_Journal_Info.journ_ac_id = modAdminCommon.gbl_Aircraft_ID;
							modAdminCommon.Rec_Journal_Info.journ_comp_id = 0;
							modAdminCommon.Rec_Journal_Info.journ_contact_id = 0;
							modAdminCommon.Rec_Journal_Info.journ_account_id = modGlobalVars.cEmptyString;
							modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
							modAdminCommon.Rec_Journal_Info.journ_status = "A";

							nCompanyChangeJID = frm_Journal.DefInstance.Commit_Journal_Entry();

						}

						sWillOwnerChange = "";

						// IF OWNER IS THE PRIMARY POC, THEN REMOVE THEN CHECK FOR CHANGES TO THE POC
						if (owner_is_primary_POC)
						{
							modCommon.Check_For_Account_Reassignment(nPriorCompanyID, nPassedCompanyID, modAdminCommon.gbl_Aircraft_ID);
						}

						// IF OWNER IS AWAITING DOCUMENTATION, THEN REMOVE THE OLD AD RECORD
						if (bIsAwaitingDoc)
						{

							modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(modAdminCommon.DateToday);
							modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "CHAWD";

							sJournSubject = $"Identified Aircraft Owner: {sNewCompanyName.Trim()}";

							modAdminCommon.Rec_Journal_Info.journ_subject = sJournSubject;
							modAdminCommon.Rec_Journal_Info.journ_description = modGlobalVars.cEmptyString;
							modAdminCommon.Rec_Journal_Info.journ_ac_id = modAdminCommon.gbl_Aircraft_ID;
							modAdminCommon.Rec_Journal_Info.journ_comp_id = 0;
							modAdminCommon.Rec_Journal_Info.journ_contact_id = 0;
							modAdminCommon.Rec_Journal_Info.journ_account_id = modGlobalVars.cEmptyString;
							modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
							modAdminCommon.Rec_Journal_Info.journ_status = "A";

							nCompanyChangeJID = frm_Journal.DefInstance.Commit_Journal_Entry();

							// MOVE THE AWAITING DOCUMENTATION JOURNAL ENTRIES TO THE
							// NEW COMPANY BEFORE DELETING AND MARK THEM SO THAT IT IS
							// CLEAR THAT THEY WERE MOVED.
							Query = "UPDATE Journal";
							Query = $"{Query} set journ_description = 'Moved entry from awaiting documentation on {DateTime.Parse(modAdminCommon.DateToday).ToString("d")}: '+journ_description";
							Query = $"{Query},journ_comp_id = {nPassedCompanyID.ToString()}";
							Query = $"{Query},journ_contact_id = 0";
							Query = $"{Query} WHERE journ_comp_id = {nPriorCompanyID.ToString()}";

							DbCommand TempCommand_3 = null;
							TempCommand_3 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_3);
							TempCommand_3.CommandText = Query;
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
							TempCommand_3.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_3);
							TempCommand_3.ExecuteNonQuery();


							if (modAdminCommon.gbl_Aircraft_ID > 0 && bIsAwaitingDoc && bRemoveOldReference)
							{
								// ADDED MSW - to switch the hotbox to the new company from the old company id, only if its awaiting docs and going to get cleared
								Query = "UPDATE Hot_Box_Summary ";
								Query = $"{Query} set hbs_comp_id = {nPassedCompanyID.ToString()} where hbs_comp_id = {nPriorCompanyID.ToString()} and hbs_ac_id = {modAdminCommon.gbl_Aircraft_ID.ToString()}";

								DbCommand TempCommand_4 = null;
								TempCommand_4 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
								UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_4);
								TempCommand_4.CommandText = Query;
								//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
								//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
								TempCommand_4.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
								UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_4);
								TempCommand_4.ExecuteNonQuery();
							}

							if (bRemoveOldReference)
							{ //aey 9/20/04 -- remove if company is on only this aircraft
								Query = $"EXEC HomebaseDeleteAllCompanyRecordsBasedCompId {nPriorCompanyID.ToString()}, 0";
								DbCommand TempCommand_5 = null;
								TempCommand_5 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
								UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_5);
								TempCommand_5.CommandText = Query;
								//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
								//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
								TempCommand_5.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
								UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_5);
								TempCommand_5.ExecuteNonQuery();

								// RTW - 3/2/2004 - PUT AN ENTRY IN THE DELETE LOG
								modAdminCommon.Record_Delete_Log_Entry("Company", nPriorCompanyID, 0, 0);

								Query = "SELECT * FROM Aircraft_Reference WHERE cref_id = -1";

								adoc_new.Open(Query, modAdminCommon.ADODB_Trans_conn, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

								adoc_new.AddNew();
								adoc_new["cref_ac_id"] = modAdminCommon.gbl_Aircraft_ID;
								adoc_new["cref_journ_id"] = 0;
								adoc_new["cref_comp_id"] = nPassedCompanyID;
								adoc_new["cref_contact_id"] = nPassedContactID;

								adoc_new["cref_business_type"] = sBusinessType.Substring(Math.Min(0, sBusinessType.Length), Math.Min(2, Math.Max(0, sBusinessType.Length))).Trim();

								if (sBusinessType.Substring(Math.Min(0, sBusinessType.Length), Math.Min(2, Math.Max(0, sBusinessType.Length))).Trim().ToUpper() == "PH")
								{
									adoc_new["cref_contact_type"] = "17"; // if we are changing purch to a program holder, to match new company business type "PH" set contact type "17"
									adoc_new["cref_owner_percent"] = 100;
								}
								else
								{
									adoc_new["cref_contact_type"] = "00";
								}

								adoc_new["cref_transmit_seq_no"] = 1;

								if (owner_is_primary_POC)
								{
									adoc_new["cref_primary_poc_flag"] = "Y";
								}
								else
								{
									adoc_new["cref_primary_poc_flag"] = "N";
								}

								adoc_new.Update();
								adoc_new.Close();
								adoc_new = null;

							}
							else
							{
								//aey 9/21/04 company is on other aircraft -- use replace instead of delete + add to get owner
								// added 7/7/2015 MSW/RTW so that program holders are treated the saem added 17 in
								Query = $"UPDATE Aircraft_Reference SET cref_contact_id = {nPassedContactID.ToString()}";
								Query = $"{Query},cref_comp_id = {nPassedCompanyID.ToString()},cref_business_type = '{sBusinessType.Substring(Math.Min(0, sBusinessType.Length), Math.Min(2, Math.Max(0, sBusinessType.Length))).Trim()}'";
								Query = $"{Query} WHERE cref_ac_id = {modAdminCommon.gbl_Aircraft_ID.ToString()} AND cref_journ_id = 0 AND cref_contact_type in ('00','17') ";

								DbCommand TempCommand_6 = null;
								TempCommand_6 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
								UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_6);
								TempCommand_6.CommandText = Query;
								//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
								//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
								TempCommand_6.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
								UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_6);
								TempCommand_6.ExecuteNonQuery();

							} // bRemoveOldReference
						}
						else
						{
							Query = $"UPDATE Aircraft_Reference SET cref_contact_id = {nPassedContactID.ToString()}";
							Query = $"{Query},cref_comp_id = {nPassedCompanyID.ToString()},cref_business_type = '{sBusinessType.Substring(Math.Min(0, sBusinessType.Length), Math.Min(2, Math.Max(0, sBusinessType.Length))).Trim()}'";
							Query = $"{Query} WHERE cref_ac_id = {modAdminCommon.gbl_Aircraft_ID.ToString()} AND cref_journ_id = 0 AND cref_contact_type in ('00','17') ";

							DbCommand TempCommand_7 = null;
							TempCommand_7 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_7);
							TempCommand_7.CommandText = Query;
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
							TempCommand_7.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_7);
							TempCommand_7.ExecuteNonQuery();
						} // bIsAwaitingDoc

						// UPDATE THE LAST UPDATE DATE, ACTION DATE, AND USER
						Query = $"UPDATE Aircraft SET ac_upd_date = '{DateTime.Parse(modAdminCommon.GetDateTime()).ToString()}',";
						Query = $"{Query}ac_upd_user_id = '{modAdminCommon.gbl_User_ID}',ac_action_date = NULL";

						if (sBusinessType.Substring(Math.Min(0, sBusinessType.Length), Math.Min(2, Math.Max(0, sBusinessType.Length))).Trim().ToUpper() == "PH" && bIsAwaitingDoc)
						{ // if we are changing purch to a program holder from await docs, then ownership type needs to be set to "F"
							Query = $"{Query}, ac_ownership_type = 'F'";
						}

						Query = $"{Query} WHERE ac_id = {modAdminCommon.gbl_Aircraft_ID.ToString()} AND ac_journ_id = 0";

						DbCommand TempCommand_8 = null;
						TempCommand_8 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_8);
						TempCommand_8.CommandText = Query;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand_8.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_8);
						TempCommand_8.ExecuteNonQuery();

						// RECORD AN OWNER CHANGE TRANSMIT
						RecordOwnerChangeTransmit(nPassedCompanyID);
						if (sNewCompanyName.Trim().ToUpper() != ("Awaiting Documentation").ToUpper())
						{
							modCommon.Transaction_Insert_Priority_Event("NOWR", modAdminCommon.gbl_Aircraft_ID, nPassedContactJID, sNewCompanyName, nPassedCompanyID, nPassedContactID);
						}

					} // IF THERE IS A OWNER CHANGE AS WELL

				} // PURCHASER JOURNAL ENTRY WAS SUCCESSFUL

				// IF CHANGE WAS TO THE LESSEE
				if (sPassedContactType == "12")
				{

					// IF THE REFERENCE RECORD EXISTS, THEN CHANGE IT.
					Query = $"SELECT cref_id FROM Aircraft_Reference WITH(NOLOCK) WHERE cref_ac_id = {modAdminCommon.gbl_Aircraft_ID.ToString()}";
					Query = $"{Query} AND cref_journ_id = 0 AND cref_contact_type = '12' AND cref_comp_id = {nPriorCompanyID.ToString()}";

					if (modAdminCommon.Exist(Query))
					{

						Query = $"UPDATE Aircraft_Reference SET cref_contact_id = {nPassedContactID.ToString()}";
						Query = $"{Query},cref_comp_id = {nPassedCompanyID.ToString()},cref_business_type = '{sBusinessType.Substring(Math.Min(0, sBusinessType.Length), Math.Min(2, Math.Max(0, sBusinessType.Length))).Trim()}'";
						Query = $"{Query} WHERE cref_journ_id = 0 AND cref_contact_type = '12'";
						Query = $"{Query} AND cref_comp_id = {nPriorCompanyID.ToString()} AND cref_ac_id = {modAdminCommon.gbl_Aircraft_ID.ToString()}";

						DbCommand TempCommand_9 = null;
						TempCommand_9 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_9);
						TempCommand_9.CommandText = Query;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand_9.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_9);
						TempCommand_9.ExecuteNonQuery();

					} // if found lessee reference record

				} // if contact change requested is a lessee

				// IF CHANGE WAS TO THE sub-LESSEE  'aey 9/16/04 change sub-lesssee added
				if (sPassedContactType == "39")
				{

					// IF THE REFERENCE RECORD EXISTS, THEN CHANGE IT.
					Query = $"SELECT cref_id FROM Aircraft_Reference WITH(NOLOCK) WHERE cref_ac_id = {modAdminCommon.gbl_Aircraft_ID.ToString()}";
					Query = $"{Query} AND cref_journ_id = 0 AND cref_contact_type = '39' AND cref_comp_id = {nPriorCompanyID.ToString()}";

					if (modAdminCommon.Exist(Query))
					{

						Query = $"UPDATE Aircraft_Reference SET cref_contact_id = {nPassedContactID.ToString()}";
						Query = $"{Query},cref_comp_id = {nPassedCompanyID.ToString()},cref_business_type = '{sBusinessType.Substring(Math.Min(0, sBusinessType.Length), Math.Min(2, Math.Max(0, sBusinessType.Length))).Trim()}'";
						Query = $"{Query} WHERE cref_journ_id = 0 AND cref_contact_type = '39'";
						Query = $"{Query} AND cref_comp_id = {nPriorCompanyID.ToString()} AND cref_ac_id = {modAdminCommon.gbl_Aircraft_ID.ToString()}";

						DbCommand TempCommand_10 = null;
						TempCommand_10 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_10);
						TempCommand_10.CommandText = Query;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand_10.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_10);
						TempCommand_10.ExecuteNonQuery();

					} // if found sub-lessee reference record

				} // if contact change requested is a sub-lessee

				// IF CHANGE WAS TO THE LESSOR  aey 9/3/04
				if (sPassedContactType == "13")
				{

					// IF THE REFERENCE RECORD EXISTS, THEN CHANGE IT.
					Query = $"SELECT cref_id FROM Aircraft_Reference WITH(NOLOCK) WHERE cref_ac_id = {modAdminCommon.gbl_Aircraft_ID.ToString()}";
					Query = $"{Query} AND cref_journ_id = 0 AND cref_contact_type = '13' AND cref_comp_id = {nPriorCompanyID.ToString()}";

					if (modAdminCommon.Exist(Query))
					{

						Query = $"UPDATE Aircraft_Reference SET cref_contact_id = {nPassedContactID.ToString()}";
						Query = $"{Query},cref_comp_id = {nPassedCompanyID.ToString()},cref_business_type = '{sBusinessType.Substring(Math.Min(0, sBusinessType.Length), Math.Min(2, Math.Max(0, sBusinessType.Length))).Trim()}'";
						Query = $"{Query} WHERE cref_journ_id = 0 AND cref_contact_type = '13'";
						Query = $"{Query} AND cref_comp_id = {nPriorCompanyID.ToString()} AND cref_ac_id = {modAdminCommon.gbl_Aircraft_ID.ToString()}";

						DbCommand TempCommand_11 = null;
						TempCommand_11 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_11);
						TempCommand_11.CommandText = Query;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand_11.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_11);
						TempCommand_11.ExecuteNonQuery();

					} // if found lessor reference record

				} // if contact change requested is a lessor

				if (sPassedContactType == "51")
				{

					// IF THE REFERENCE RECORD EXISTS, THEN CHANGE IT.
					Query = $"SELECT cref_id FROM Aircraft_Reference WITH(NOLOCK) WHERE cref_ac_id = {modAdminCommon.gbl_Aircraft_ID.ToString()}";
					Query = $"{Query} AND cref_journ_id = 0 AND cref_contact_type = '51' AND cref_comp_id = {nPriorCompanyID.ToString()}";

					if (modAdminCommon.Exist(Query))
					{

						Query = $"UPDATE Aircraft_Reference SET cref_contact_id = {nPassedContactID.ToString()}";
						Query = $"{Query},cref_comp_id = {nPassedCompanyID.ToString()}, cref_business_type = '{sBusinessType.Substring(Math.Min(0, sBusinessType.Length), Math.Min(2, Math.Max(0, sBusinessType.Length))).Trim()}'";
						Query = $"{Query} WHERE cref_journ_id = 0 AND cref_contact_type = '51'";
						Query = $"{Query} AND cref_comp_id = {nPriorCompanyID.ToString()} AND cref_ac_id = {modAdminCommon.gbl_Aircraft_ID.ToString()}";

						DbCommand TempCommand_12 = null;
						TempCommand_12 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_12);
						TempCommand_12.CommandText = Query;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand_12.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_12);
						TempCommand_12.ExecuteNonQuery();

					} // if found record

				} // if contact change requested

				if (sPassedContactType == "52")
				{

					// IF THE REFERENCE RECORD EXISTS, THEN CHANGE IT.
					Query = $"SELECT cref_id FROM Aircraft_Reference WITH(NOLOCK) WHERE cref_ac_id = {modAdminCommon.gbl_Aircraft_ID.ToString()}";
					Query = $"{Query} AND cref_journ_id = 0 AND cref_contact_type = '52' AND cref_comp_id = {nPriorCompanyID.ToString()}";

					if (modAdminCommon.Exist(Query))
					{

						Query = $"UPDATE Aircraft_Reference SET cref_contact_id = {nPassedContactID.ToString()}";
						Query = $"{Query},cref_comp_id = {nPassedCompanyID.ToString()}, cref_business_type = '{sBusinessType.Substring(Math.Min(0, sBusinessType.Length), Math.Min(2, Math.Max(0, sBusinessType.Length))).Trim()}'";
						Query = $"{Query} WHERE cref_journ_id = 0 AND cref_contact_type = '52'";
						Query = $"{Query} AND cref_comp_id = {nPriorCompanyID.ToString()} AND cref_ac_id = {modAdminCommon.gbl_Aircraft_ID.ToString()}";

						DbCommand TempCommand_13 = null;
						TempCommand_13 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_13);
						TempCommand_13.CommandText = Query;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand_13.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_13);
						TempCommand_13.ExecuteNonQuery();

					} // if found record

				} // if contact change requested

				if (nPassedCompanyID == nPriorCompanyID)
				{
					bRemoveOldReference = false;
				} //aey 6/29/04

				//determine if new company is active -- aey 9/14/04
				modCommon.CompanyActivate(nPassedCompanyID, 0);


				Query = $"update Aircraft_Document set adoc_onbehalf_comp_id={nPassedCompanyID.ToString()},adoc_onbehalf_contact_id=0";
				Query = $"{Query} Where adoc_onbehalf_comp_id = {nPriorCompanyID.ToString()}";
				Query = $"{Query} and adoc_ac_id = {modAdminCommon.gbl_Aircraft_ID.ToString()}";
				Query = $"{Query} and adoc_journ_id={nPassedContactJID.ToString()}";
				DbCommand TempCommand_14 = null;
				TempCommand_14 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_14);
				TempCommand_14.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand_14.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_14);
				TempCommand_14.ExecuteNonQuery();

				Query = $"update Aircraft_Document set adoc_infavor_comp_id={nPassedCompanyID.ToString()},adoc_infavor_contact_id=0";
				Query = $"{Query} Where adoc_infavor_comp_id = {nPriorCompanyID.ToString()}";
				Query = $"{Query} and adoc_ac_id = {modAdminCommon.gbl_Aircraft_ID.ToString()}";
				Query = $"{Query} and adoc_journ_id={nPassedContactJID.ToString()}";
				DbCommand TempCommand_15 = null;
				TempCommand_15 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_15);
				TempCommand_15.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand_15.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_15);
				TempCommand_15.ExecuteNonQuery();

				// UPDATE THE TRUSTEE DOCUMENTS
				Query = $"update Aircraft_Document set adoc_trustee_comp_id={nPassedCompanyID.ToString()},adoc_trustee_contact_id=0";
				Query = $"{Query} Where adoc_trustee_comp_id = {nPriorCompanyID.ToString()}";
				Query = $"{Query} and adoc_ac_id = {modAdminCommon.gbl_Aircraft_ID.ToString()}";
				Query = $"{Query} and adoc_journ_id={nPassedContactJID.ToString()}";
				DbCommand TempCommand_16 = null;
				TempCommand_16 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_16);
				TempCommand_16.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand_16.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_16);
				TempCommand_16.ExecuteNonQuery();

				// UPDATE THE SUBLEASE DOCUMENTS
				Query = $"update Aircraft_Document set adoc_sublease_comp_id={nPassedCompanyID.ToString()},adoc_sublease_contact_id=0";
				Query = $"{Query} Where adoc_sublease_comp_id = {nPriorCompanyID.ToString()}";
				Query = $"{Query} and adoc_ac_id = {modAdminCommon.gbl_Aircraft_ID.ToString()}";
				Query = $"{Query} and adoc_journ_id={nPassedContactJID.ToString()}";
				DbCommand TempCommand_17 = null;
				TempCommand_17 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_17);
				TempCommand_17.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand_17.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_17);
				TempCommand_17.ExecuteNonQuery();

				// REMOVE THE HISTORICAL COMPANY RECORD
				if (bRemoveOldReference)
				{

					Query = $"EXEC HomebaseDeleteAllCompanyRecordsBasedCompId {nPriorCompanyID.ToString()}, {nPassedContactJID.ToString()}";
					DbCommand TempCommand_18 = null;
					TempCommand_18 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_18);
					TempCommand_18.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand_18.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_18);
					TempCommand_18.ExecuteNonQuery();

					modAdminCommon.Record_Delete_Log_Entry("Company", nPriorCompanyID, nPassedContactJID, 0);

				}

				sOldCompanyName = "";
				sOldCompanyType = "";

				if (nContactChangeJID > 0)
				{

					modAdminCommon.gbl_Aircraft_Journal_ID = nPassedContactJID;

					result = true;

					//=======================================================
					// KTH - 3/7/2003
					// Added "OM" and "MA" as types to ignore.
					//=======================================================
					if (sJournalSubcategoryCode.Substring(Math.Max(sJournalSubcategoryCode.Length - 2, 0)) != "IT" && sJournalSubcategoryCode.Substring(Math.Max(sJournalSubcategoryCode.Length - 4, 0)) != "CORR" && sJournalSubcategoryCode != "MA" && sJournalSubcategoryCode != "OM")
					{

						Query = $"UPDATE Journal SET journ_subcategory_code = '{sJournalSubcategoryCode.Substring(Math.Min(0, sJournalSubcategoryCode.Length), Math.Min(4, Math.Max(0, sJournalSubcategoryCode.Length)))}{sBusinessType.Substring(Math.Min(0, sBusinessType.Length), Math.Min(2, Math.Max(0, sBusinessType.Length))).Trim()}', ";

						Query = $"{Query} journ_subcat_code_part1 = '{sJournalSubcategoryCode.Substring(Math.Min(0, sJournalSubcategoryCode.Length), Math.Min(2, Math.Max(0, sJournalSubcategoryCode.Length)))}',";
						Query = $"{Query} journ_subcat_code_part2 = '{sJournalSubcategoryCode.Substring(Math.Min(2, sJournalSubcategoryCode.Length), Math.Min(2, Math.Max(0, sJournalSubcategoryCode.Length - 2)))}',";
						Query = $"{Query} journ_subcat_code_part3 = '{sBusinessType.Substring(Math.Min(0, sBusinessType.Length), Math.Min(2, Math.Max(0, sBusinessType.Length))).Trim()}',";

						//check to see if this category code is to have action date nullified 6/25/04 aey
						if (!modCommon.GetTransWeb($"{sJournalSubcategoryCode.Substring(Math.Min(0, sJournalSubcategoryCode.Length), Math.Min(4, Math.Max(0, sJournalSubcategoryCode.Length)))}{sBusinessType.Substring(Math.Min(0, sBusinessType.Length), Math.Min(2, Math.Max(0, sBusinessType.Length))).Trim()}"))
						{
							Query = $"{Query}journ_action_date = '{DateTime.Parse(modAdminCommon.GetDateTime()).ToString()}'";
						}
						else
						{
							Query = $"{Query}journ_action_date = NULL";
						}

						Query = $"{Query} WHERE journ_id = {nPassedContactJID.ToString()}";

						DbCommand TempCommand_19 = null;
						TempCommand_19 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_19);
						TempCommand_19.CommandText = Query;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand_19.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_19);
						TempCommand_19.ExecuteNonQuery();
					}

					modAircraft.FixJournalSubject(nPassedContactJID);

					modAdminCommon.ADO_Transaction("CommitTrans");


				}
				else
				{

					throw new Exception(); //aey 6/8/04

				} // nContactChangeJID > 0

				modCommon.Company_Stats_Update(nPriorCompanyID); //aey 6/15/05
				modCommon.Company_Stats_Update(nPassedCompanyID); //aey 6/15/05
				return result;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"ChangeHistoricalContactType ({Information.Err().Number.ToString()}) {excep.Message}", "Aircraft (modAircraft)");
				modAdminCommon.ADO_Transaction("RollbackTrans");
				return result;
			}
		}

		internal static int CreateHistoricalContact(int incompid, int inContactId, int inJournID)
		{
			int result = 0;
			string Query = "";
			ADORecordSetHelper snpReadContact = new ADORecordSetHelper();
			ADORecordSetHelper snpNewContact = new ADORecordSetHelper();
			ADORecordSetHelper snp_NextContactid = null; //aey 8/4/04
			int max_contact_id = 0;

			try
			{

				Query = "SELECT MAX(contact_id) AS max_contact_id FROM Contact WITH(NOLOCK)";

				snp_NextContactid = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

				if (Convert.ToDouble(snp_NextContactid["max_contact_id"]) > 0)
				{
					max_contact_id = Convert.ToInt32(Convert.ToDouble(snp_NextContactid["max_contact_id"]) + 1);
				}
				else
				{
					max_contact_id = 1;
				}

				snp_NextContactid.Close();
				snp_NextContactid = null;

				result = -1;

				Query = $"SELECT * FROM Contact WHERE contact_comp_id = {incompid.ToString()}";
				//added MSW - RTW / 9/12/17 - was getting 16,000 records in some cases, and possible historical stuff
				if (inContactId > 0)
				{
					Query = $"{Query} and contact_id = {inContactId.ToString()}";
				}


				// if the contact historical record already exists 6/13/22
				if (!modAdminCommon.Exist($"{Query} and contact_journ_id = {inJournID.ToString()} "))
				{

					Query = $"{Query} and contact_journ_id = 0 ";

					Query = $"{Query} ORDER BY contact_id desc";

					snpReadContact.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!(snpReadContact.BOF && snpReadContact.EOF))
					{

						Query = "SELECT * FROM contact WHERE contact_id = -1"; //opens faster when contact is selected

						snpNewContact.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

						snpNewContact.AddNew();

						int tempForEndVar = snpNewContact.FieldsMetadata.Count - 1;
						for (int K = 0; K <= tempForEndVar; K++)
						{
							snpNewContact[K] = snpReadContact[K];
						}

						snpNewContact["contact_comp_id"] = incompid;
						snpNewContact["contact_journ_id"] = inJournID;

						if (inContactId > 0)
						{
							snpNewContact["contact_id"] = inContactId;
						}
						else
						{
							snpNewContact["contact_id"] = max_contact_id;
						}

						snpNewContact.Update();

						result = max_contact_id;

						snpNewContact.Close();
						snpNewContact = null;

					}
					else
					{
						//history does not exist

						Query = "SELECT * FROM contact WHERE contact_id = -1";

						snpNewContact.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

						snpNewContact.AddNew();
						snpNewContact["contact_comp_id"] = incompid;
						snpNewContact["contact_journ_id"] = inJournID;
						snpNewContact["contact_id"] = max_contact_id;
						snpNewContact.Update();

						result = max_contact_id;

						snpNewContact.Close();
						snpNewContact = null;

					}


					snpReadContact.Close();
					snpReadContact = null;
				}
				else
				{
					result = inContactId;
				}


				return result;
			}
			catch (System.Exception excep)
			{

				result = -1;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"CreateHistoricalContact_Error ({Information.Err().Number.ToString()}) {excep.Message}", "Aircraft (modAircraft)");
				return result;
			}
		}

		internal static int Find_Operating_Company_ID(int AC_ID, int inJournal_ID)
		{

			int result = 0;

			ADORecordSetHelper rsReferences = new ADORecordSetHelper();

			string Query = $"select top 1 cref_comp_id from Aircraft_Reference where cref_ac_id = {AC_ID.ToString()}";
			Query = $"{Query} and cref_journ_id = {inJournal_ID.ToString()} and  cref_operator_flag IN ('Y','O')  ";

			rsReferences.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

			if (!(rsReferences.BOF && rsReferences.EOF))
			{


				while(!rsReferences.EOF)
				{

					result = Convert.ToInt32(rsReferences["cref_comp_id"]);

					rsReferences.MoveNext();
				};
			} // select of lease references

			rsReferences.Close();
			return result;
		}

		internal static string Find_Journal_Date(int AC_ID, int inJournal_ID)
		{

			string result = "";

			ADORecordSetHelper rsReferences = new ADORecordSetHelper();

			string Query = $"select top 1 journ_entry_date from journal where journ_ac_id = {AC_ID.ToString()}";
			Query = $"{Query} and  journ_id = {inJournal_ID.ToString()}";

			rsReferences.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

			if (!(rsReferences.BOF && rsReferences.EOF))
			{


				while(!rsReferences.EOF)
				{

					result = Convert.ToString(rsReferences["journ_entry_date"]);

					rsReferences.MoveNext();
				};
			} // select of lease references

			rsReferences.Close();


			return result;
		}
		internal static bool InsertExclusiveRep(ADORecordSetHelper adoACRecordset, int nPassedCompanyID, int nPassedCompanyJID, int nPassedContactID, ref ADORecordSetHelper snp_Company, ref ADORecordSetHelper snp_Contacts, ref ADORecordSetHelper snp_Company_Phones, ref ADORecordSetHelper snp_Company_Btypes)
		{

			bool result = false;
			string Query = "";
			int SeqNO = 0;
			string sBusinessType = "";

			try
			{

				result = false;

				sBusinessType = modCommon.GetBusinessTypeToUse(nPassedCompanyID, nPassedCompanyJID);

				SeqNO = GetExclusiveBrokerSeqNo(Convert.ToInt32(adoACRecordset["ac_id"]), Convert.ToInt32(adoACRecordset["ac_journ_id"]));

				Query = "INSERT INTO Aircraft_Reference (cref_ac_id,";
				Query = $"{Query}cref_journ_id,";
				Query = $"{Query}cref_comp_id,cref_contact_id,cref_contact_type,";
				Query = $"{Query}cref_transmit_seq_no,cref_business_type,cref_primary_poc_flag)";
				Query = $"{Query} values ({Convert.ToString(adoACRecordset["ac_id"])},";
				Query = $"{Query}{nPassedCompanyJID.ToString()},";
				Query = $"{Query}{nPassedCompanyID.ToString()},";
				Query = $"{Query}{nPassedContactID.ToString()},";
				Query = $"{Query}'93',";
				Query = $"{Query}{SeqNO.ToString()},";
				Query = $"{Query}'{sBusinessType.Substring(Math.Min(0, sBusinessType.Length), Math.Min(2, Math.Max(0, sBusinessType.Length))).Trim()}',";
				Query = $"{Query}'N')";

				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();

				if (nPassedCompanyJID > 0)
				{
					modCommon.Transaction_Get_Company_History_Recordsets(nPassedCompanyID.ToString());
					modCommon.Transaction_Save_Company_History(nPassedCompanyJID, ref snp_Company, ref snp_Contacts, ref snp_Company_Phones, ref snp_Company_Btypes, ref modGlobalVars.snp_Company_Certs);
				}


				return true;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"InsertExclusiveRep_Error ({Information.Err().Number.ToString()}) {excep.Message}", "Aircraft (modAircraft)");
				return result;
			}
		}

		internal static bool MakeExRepPrimary(ADORecordSetHelper adoACRecordset, int nPassedCompanyID, int nPassedContactID, int nRememberCompID)
		{

			bool result = false;
			string Query = "";

			try
			{

				result = false;

				Query = "UPDATE Aircraft_Reference SET cref_primary_poc_flag = 'N'";
				Query = $"{Query} WHERE cref_ac_id = {Convert.ToString(adoACRecordset["ac_id"])}";
				Query = $"{Query} AND cref_journ_id = {Convert.ToString(adoACRecordset["ac_journ_id"])}";
				Query = $"{Query} AND cref_primary_poc_flag = 'Y'";

				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();

				Query = $"UPDATE Aircraft_Reference SET  cref_primary_poc_flag = 'Y' WHERE cref_ac_id = {Convert.ToString(adoACRecordset["ac_id"])}";
				Query = $"{Query} AND cref_journ_id = 0 AND cref_comp_id = {nPassedCompanyID.ToString()}";
				Query = $"{Query} AND cref_contact_id = {nPassedContactID.ToString()}";
				Query = $"{Query} AND cref_contact_type = '93'";

				DbCommand TempCommand_2 = null;
				TempCommand_2 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
				TempCommand_2.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand_2.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
				TempCommand_2.ExecuteNonQuery();

				modCommon.Check_For_Account_Reassignment(nRememberCompID, nPassedCompanyID, Convert.ToInt32(adoACRecordset["ac_id"]));


				return true;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"MakeExRepPrimary_Error ({Information.Err().Number.ToString()}) {excep.Message}", "Aircraft (modAircraft)");
				return result;
			}
		}

		internal static bool MakeExclusivePrimary(ADORecordSetHelper adoACRecordset, int nPassedCompanyID, int nPassedContactID, int nRememberCompID)
		{

			bool result = false;
			string Query = "";

			try
			{

				result = false;

				Query = "UPDATE Aircraft_Reference SET cref_primary_poc_flag = 'N'";
				Query = $"{Query} WHERE cref_ac_id = {Convert.ToString(adoACRecordset["ac_id"])}";
				Query = $"{Query} AND cref_journ_id = {Convert.ToString(adoACRecordset["ac_journ_id"])}";
				Query = $"{Query} AND cref_primary_poc_flag = 'Y'";

				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();

				Query = "UPDATE Aircraft_Reference SET cref_primary_poc_flag = 'Y' WHERE";
				Query = $"{Query} cref_ac_id = {Convert.ToString(adoACRecordset["ac_id"])}";
				Query = $"{Query} AND cref_journ_id = 0";
				Query = $"{Query} AND cref_comp_id = {nPassedCompanyID.ToString()}";
				Query = $"{Query} AND cref_contact_id = {nPassedContactID.ToString()}";
				Query = $"{Query} AND cref_contact_type = '99'";

				DbCommand TempCommand_2 = null;
				TempCommand_2 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
				TempCommand_2.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand_2.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
				TempCommand_2.ExecuteNonQuery();

				modCommon.Check_For_Account_Reassignment(nRememberCompID, nPassedCompanyID, Convert.ToInt32(adoACRecordset["ac_id"]), "N");


				return true;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"MakeExclusivePrimary_Error ({Information.Err().Number.ToString()}) {excep.Message}", "Aircraft (modAircraft)");
				return result;
			}
		}

		internal static bool InsertExclusiveBroker(ADORecordSetHelper adoACRecordset, int nPassedCompanyID, int nPassedCompanyJID, int nPassedContactID, ref ADORecordSetHelper snp_Company, ref ADORecordSetHelper snp_Contacts, ref ADORecordSetHelper snp_Company_Phones, ref ADORecordSetHelper snp_Company_Btypes)
		{

			bool result = false;
			string Query = "";
			int SeqNO = 0;
			string sBusinessType = "";

			try
			{

				result = false;

				SeqNO = GetExclusiveBrokerSeqNo(Convert.ToInt32(adoACRecordset["ac_id"]), Convert.ToInt32(adoACRecordset["ac_journ_id"]));

				Query = "INSERT INTO Aircraft_Reference (cref_ac_id,cref_journ_id,cref_comp_id,cref_contact_id,";
				Query = $"{Query}cref_contact_type,cref_transmit_seq_no,";
				Query = $"{Query}cref_business_type,cref_primary_poc_flag)";
				Query = $"{Query} values ({Convert.ToString(adoACRecordset["ac_id"])},";
				Query = $"{Query}{nPassedCompanyJID.ToString()},";
				Query = $"{Query}{nPassedCompanyID.ToString()},";
				Query = $"{Query}{nPassedContactID.ToString()},";
				Query = $"{Query}'99',";
				Query = $"{Query}{SeqNO.ToString()},";
				Query = $"{Query}'DB',";
				Query = $"{Query}'N')";

				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();

				if (nPassedCompanyJID > 0)
				{
					modCommon.Transaction_Get_Company_History_Recordsets(nPassedCompanyID.ToString());
					modCommon.Transaction_Save_Company_History(nPassedCompanyJID, ref snp_Company, ref snp_Contacts, ref snp_Company_Phones, ref snp_Company_Btypes, ref modGlobalVars.snp_Company_Certs);
				}


				return true;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"InsertExclusiveBroker_Error ({Information.Err().Number.ToString()}) {excep.Message} ACID:[{Convert.ToString(adoACRecordset["ac_id"])}] COMID[{nPassedCompanyID.ToString()}] COMJID[{nPassedCompanyJID.ToString()}] CONID[{nPassedContactID.ToString()}] JID[{Convert.ToString(adoACRecordset["ac_journ_id"])}]", "Aircraft (modAircraft)");
				return result;
			}
		}

		internal static bool MakeAircraftExclusive(ADORecordSetHelper adoACRecordset, string dtExclusiveCallbackDate)
		{

			bool result = false;
			string Query = "";

			try
			{

				result = false;

				Query = "UPDATE Aircraft SET ac_exclusive_flag = 'Y',";
				Query = $"{Query}ac_exclusive_verify_date = '{DateTime.Parse(dtExclusiveCallbackDate).ToString()}',";
				Query = $"{Query}ac_action_date = NULL, ac_upd_date = '{DateTime.Parse(modAdminCommon.DateToday).ToString()}',";
				Query = $"{Query}ac_upd_user_id = '{modAdminCommon.gbl_User_ID}'";
				Query = $"{Query} WHERE ac_id = {Convert.ToString(adoACRecordset["ac_id"])} AND ac_journ_id = {Convert.ToString(adoACRecordset["ac_journ_id"])}";

				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();


				return true;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"MakeAircraftExclusive_Error ({Information.Err().Number.ToString()}) {excep.Message}", "Aircraft (modAircraft)");
				return result;
			}
		}

		internal static bool MakePurplePrimary(ADORecordSetHelper adoACRecordset)
		{

			bool result = false;
			try
			{

				string Query = "";
				int OldCompID = 0;
				OldCompID = 0;
				int NewCompID = 0;
				NewCompID = 0;
				ADORecordSetHelper snpOld = null;
				ADORecordSetHelper snpNew = null;

				result = false;

				Query = "SELECT cref_comp_id FROM Aircraft_Reference WITH(NOLOCK)";
				Query = $"{Query} WHERE cref_ac_id = {Convert.ToString(adoACRecordset["ac_id"])}";
				Query = $"{Query} AND cref_journ_id = {Convert.ToString(adoACRecordset["ac_journ_id"])}";
				Query = $"{Query} AND cref_primary_poc_flag = 'Y'";

				snpOld = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(snpOld.Fields) && !(snpOld.BOF && snpOld.EOF))
				{
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snpOld["cref_comp_id"]))
					{
						OldCompID = Convert.ToInt32(snpOld["cref_comp_id"]);
						snpOld.Close();
					}
				}

				snpOld = null;

				Query = "UPDATE Aircraft_Reference SET cref_primary_poc_flag = 'N'";
				Query = $"{Query} WHERE cref_primary_poc_flag = 'Y' AND cref_ac_id = {Convert.ToString(adoACRecordset["ac_id"])}";
				Query = $"{Query} AND cref_journ_id = 0";

				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();

				//'''''''''''''''''''''''''''''''''''''''''''''''''''''''
				// Now we can change the current "Exclusive" to primary'
				//'''''''''''''''''''''''''''''''''''''''''''''''''''''''
				Query = "SELECT cref_comp_id FROM Aircraft_Reference WITH(NOLOCK)";
				Query = $"{Query} WHERE cref_ac_id = {Convert.ToString(adoACRecordset["ac_id"])}";
				Query = $"{Query} AND cref_journ_id = {Convert.ToString(adoACRecordset["ac_journ_id"])}";
				Query = $"{Query} AND cref_primary_poc_flag = 'X'";

				snpNew = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(snpNew.Fields) && !(snpNew.BOF && snpNew.EOF))
				{

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snpNew["cref_comp_id"]))
					{
						NewCompID = Convert.ToInt32(snpNew["cref_comp_id"]);
						snpNew.Close();
					}

					Query = "UPDATE Aircraft_Reference SET cref_primary_poc_flag = 'Y'";
					Query = $"{Query} WHERE cref_ac_id = {Convert.ToString(adoACRecordset["ac_id"])}";
					Query = $"{Query} AND cref_journ_id = 0";
					Query = $"{Query} AND cref_primary_poc_flag = 'X'";

					DbCommand TempCommand_2 = null;
					TempCommand_2 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
					TempCommand_2.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand_2.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
					TempCommand_2.ExecuteNonQuery();

					// added N MSW - 7/5/23
					modCommon.Check_For_Account_Reassignment(OldCompID, NewCompID, Convert.ToInt32(adoACRecordset["ac_id"]), "N");

					result = true;

				}

				snpNew = null;

				return result;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"MakePurplePrimary_Error ({Information.Err().Number.ToString()}) {excep.Message}", "Aircraft (modAircraft)");
				return result;
			}
		}

		internal static int MakePrimaryExclusive(ADORecordSetHelper adoACRecordset)
		{

			int result = 0;
			try
			{

				string Query = "";
				ADORecordSetHelper snpOld = null;

				//''''''''''''''''''''''''''''''''''''''''''''''''''''
				// First clear out anyone already marked "Exclusive" '
				//''''''''''''''''''''''''''''''''''''''''''''''''''''
				result = 0;

				Query = "UPDATE Aircraft_Reference SET cref_primary_poc_flag = 'N'";
				Query = $"{Query} WHERE cref_ac_id = {Convert.ToString(adoACRecordset["ac_id"])}";
				Query = $"{Query} AND cref_journ_id = {Convert.ToString(adoACRecordset["ac_journ_id"])}";
				Query = $"{Query} AND cref_primary_poc_flag = 'X'";

				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();

				Query = "SELECT cref_comp_id FROM Aircraft_Reference WITH(NOLOCK)";
				Query = $"{Query} WHERE cref_ac_id = {Convert.ToString(adoACRecordset["ac_id"])}";
				Query = $"{Query} AND cref_journ_id = {Convert.ToString(adoACRecordset["ac_journ_id"])}";
				Query = $"{Query} AND cref_primary_poc_flag = 'Y'";

				snpOld = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(snpOld.Fields) && !(snpOld.BOF && snpOld.EOF))
				{
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snpOld["cref_comp_id"]))
					{
						result = Convert.ToInt32(snpOld["cref_comp_id"]);
						snpOld.Close();
					}
				}

				snpOld = null;

				//'''''''''''''''''''''''''''''''''''''''''''''''''''''''
				// Now we can change the current primary to "Exclusive" '
				//'''''''''''''''''''''''''''''''''''''''''''''''''''''''
				Query = "UPDATE Aircraft_Reference SET cref_primary_poc_flag = 'X'";
				Query = $"{Query} WHERE cref_ac_id = {Convert.ToString(adoACRecordset["ac_id"])}";
				Query = $"{Query} AND cref_journ_id = {Convert.ToString(adoACRecordset["ac_journ_id"])}";
				Query = $"{Query} AND cref_primary_poc_flag = 'Y'";

				DbCommand TempCommand_2 = null;
				TempCommand_2 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
				TempCommand_2.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand_2.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
				TempCommand_2.ExecuteNonQuery();

				return result;
			}
			catch (System.Exception excep)
			{

				result = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"MakePrimaryExclusive_Error ({Information.Err().Number.ToString()}) {excep.Message}", "Aircraft (modAircraft)");
				return result;
			}
		}

		internal static int GetExclusiveBrokerSeqNo(int nPassedACID, int nPassedACJID)
		{


			string Query = "SELECT cref_contact_type FROM Aircraft_Reference WITH(NOLOCK) WHERE cref_transmit_seq_no = '4'";
			Query = $"{Query} AND cref_ac_id = {nPassedACID.ToString()}";
			Query = $"{Query} AND cref_journ_id = {nPassedACJID.ToString()}";

			if (modAdminCommon.Exist(Query))
			{
				Query = "SELECT cref_contact_type FROM Aircraft_Reference WITH(NOLOCK) WHERE cref_transmit_seq_no = '5'";
				Query = $"{Query} AND cref_ac_id = {nPassedACID.ToString()}";
				Query = $"{Query} AND cref_journ_id = {nPassedACJID.ToString()}";

				if (modAdminCommon.Exist(Query))
				{
					return 99;
				}
				else
				{
					return 5;
				}
			}
			else
			{
				return 4;
			}

		}

		internal static void RecordOwnerChangeTransmit(int PassedCompID)
		{

			string Query = "";
			ADORecordSetHelper snpACInfo = new ADORecordSetHelper(); // Recordset  'aey 6/8/04
			string tmpSerNo = "";
			int tmpAmodID = 0;
			string tmpForSaleFlag = "";

			try
			{

				string[] arrTempFields = ArraysHelper.InitializeArray<string>(11);

				arrTempFields[0] = "owner_comp_name";
				arrTempFields[1] = "owner_comp_address";
				arrTempFields[2] = "owner_comp_city";
				arrTempFields[3] = "owner_comp_state";
				arrTempFields[4] = "owner_comp_zip_code";
				arrTempFields[7] = "owner_contact_name";
				arrTempFields[8] = "owner_contact_phone1";
				arrTempFields[9] = "owner_contact_phone2";

				Query = $"SELECT ac_ser_no_full, ac_amod_id, ac_forsale_flag FROM Aircraft WITH(NOLOCK) WHERE ac_id = {modAdminCommon.gbl_Aircraft_ID.ToString()} AND ac_journ_id = 0";

				snpACInfo.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpACInfo.BOF && snpACInfo.EOF))
				{
					tmpSerNo = ($"{Convert.ToString(snpACInfo["ac_ser_no_full"])}").Trim();
					tmpAmodID = Convert.ToInt32(Double.Parse(($"{Convert.ToString(snpACInfo["ac_amod_id"])}").Trim()));
					tmpForSaleFlag = ($"{Convert.ToString(snpACInfo["ac_forsale_flag"])}").Trim();
				}

				snpACInfo.Close();
				snpACInfo = null;

				modAdminCommon.Record_Transmit(tmpSerNo, modAdminCommon.gbl_Aircraft_ID, 0, tmpAmodID, "Aircraft", "Change", ref arrTempFields);
				if (tmpForSaleFlag.ToUpper() == "Y")
				{
					modAdminCommon.Record_Transmit(tmpSerNo, modAdminCommon.gbl_Aircraft_ID, 0, tmpAmodID, "Available", "Change", ref arrTempFields);
				}
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"RecordOwnerChangeTransmit_Error({Information.Err().Number.ToString()}) {excep.Message}", "Aircraft (modAircraft)");
				return;
			}

		}

		internal static bool BaseNeedsConfirm(string inBaseVerifyDate)
		{

			bool result = false;
			string tmpBaseDate = "";


			if (Information.IsDate(inBaseVerifyDate))
			{
				tmpBaseDate = DateTimeHelper.ToString(DateTime.Parse(inBaseVerifyDate).AddDays(modAdminCommon.gbl_ConfirmDays));

				if (DateTime.Parse(tmpBaseDate) <= DateTime.Parse(DateTimeHelper.ToString(DateTime.Now)))
				{
					result = true;
				}

			}
			else
			{
				result = true;
			}

			return result;
		}

		internal static bool RegNeedsConfirm(string inRegVerifyDate)
		{

			bool result = false;
			string tmpRegDate = "";


			if (Information.IsDate(inRegVerifyDate))
			{
				tmpRegDate = DateTimeHelper.ToString(DateTime.Parse(inRegVerifyDate).AddDays(modAdminCommon.gbl_ConfirmDays));

				if (DateTime.Parse(tmpRegDate) <= DateTime.Parse(DateTimeHelper.ToString(DateTime.Now)))
				{
					result = true;
				}

			}
			else
			{
				result = true;
			}

			return result;
		}

		internal static bool Transaction_Check_for_Status_Change(string tmp_OldStatus, string tmp_NewStatus, CheckState old_ac_forsale_flag, CheckState new_ac_forsale_flag, string old_ac_asking_price, string new_ac_asking_price, string ac_asking_text, string ac_asking_text_price, string ac_delivery_Text, ADORecordSetHelper adoAircraftRecordset, ref string[] arr_Transmit_Fields, ref int Status_Change_Journ_ID, ref int For_Sale_Journ_ID, ref bool AskingPriceChanged)
		{

			bool result = false;
			try
			{

				bool StatChangeJournalWritten = false;
				bool EventChangeWritten = false;
				string JOURNAL_SUBJECT = "";


				tmp_OldStatus = tmp_OldStatus.Trim().ToLower();
				tmp_NewStatus = tmp_NewStatus.Trim().ToLower();

				JOURNAL_SUBJECT = modGlobalVars.cEmptyString;

				StatChangeJournalWritten = false;
				EventChangeWritten = false;

				// ****************
				// ASSUME THAT THE ROUTINE WILL BE SUCCESSFUL
				result = true;

				if (old_ac_forsale_flag == new_ac_forsale_flag)
				{
					if (AskingPriceChanged && Convert.ToInt32(adoAircraftRecordset["ac_journ_id"]) == 0)
					{
						if (old_ac_asking_price != "[Blank]" || new_ac_asking_price != "[Blank]")
						{
							JOURNAL_SUBJECT = $"from: {old_ac_asking_price} to: {new_ac_asking_price}";
							modCommon.InsertPriorityEventChangeInAsking("CA", Convert.ToInt32(adoAircraftRecordset["AC_ID"]), Convert.ToInt32(adoAircraftRecordset["ac_journ_id"]), JOURNAL_SUBJECT.Trim(), old_ac_asking_price, new_ac_asking_price, "Y");
						}
					}
				}

				if (old_ac_forsale_flag != new_ac_forsale_flag)
				{

					modAdminCommon.Rec_Journal_Info.journ_ac_id = Convert.ToInt32(adoAircraftRecordset["ac_id"]);
					modAdminCommon.Rec_Journal_Info.journ_comp_id = 0;
					modAdminCommon.Rec_Journal_Info.journ_contact_id = 0;
					modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
					modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(modAdminCommon.DateToday);
					modAdminCommon.Rec_Journal_Info.journ_description = modGlobalVars.cEmptyString;
					modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
					modAdminCommon.Rec_Journal_Info.journ_status = "A";
					frm_Journal.DefInstance.Reference_Ac_Id = Convert.ToInt32(adoAircraftRecordset["ac_id"]);

					EventChangeWritten = true; // RTW - 7/19/2004

					if (new_ac_forsale_flag == CheckState.Checked)
					{
						// ************************************************
						// BUILD THE FORMAT OF AN ON MARKET JOURNAL ENTRY
						modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "MA";

						modAdminCommon.EventTempCompID = GetOwnerCompanyID(Convert.ToInt32(adoAircraftRecordset["ac_id"]), 0);
						modAdminCommon.EventTempContactID = GetOwnerContactID(Convert.ToInt32(adoAircraftRecordset["ac_id"]), 0);

						if (ac_asking_text.ToLower() == ("Price").ToLower())
						{
							modAdminCommon.EventTempAskingPrice = $"${StringsHelper.Format(ac_asking_text_price.Trim(), "###,###,###")}";
						}
						else
						{
							modAdminCommon.EventTempAskingPrice = ac_asking_text.Trim();
						}

						JOURNAL_SUBJECT = $"On Market, {modCommon.pf_Proper_Case(tmp_NewStatus)}";

						modAdminCommon.Rec_Journal_Info.journ_subject = JOURNAL_SUBJECT.Trim();

					}
					else
					{
						// ************************************************
						// BUILD THE FORMAT OF AN OFF MARKET JOURNAL ENTRY
						modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "OM";

						modAdminCommon.EventTempCompName = GetCurrentOwner(Convert.ToInt32(adoAircraftRecordset["ac_id"]));
						modAdminCommon.EventTempCompID = GetCurrentOwnerID(Convert.ToInt32(adoAircraftRecordset["ac_id"]));

						modAdminCommon.Rec_Journal_Info.journ_pcreckey = modCommon.Get_Next_PC_Record_Key();
						JOURNAL_SUBJECT = $"Off Market, {modCommon.pf_Proper_Case(tmp_NewStatus)}";

						modAdminCommon.Rec_Journal_Info.journ_subject = JOURNAL_SUBJECT.Trim();

					} // END IF AVAILABILITY HAS CHANGED

					AskingPriceChanged = false; // reset the asking price changed flag

					For_Sale_Journ_ID = frm_Journal.DefInstance.Commit_Journal_Entry();

					StatChangeJournalWritten = true; //aey 7/13/04

					// **************************************************
					// INSERT THE ON MARKET OR OFF MARKET JOURNAL ENTRY
					if (For_Sale_Journ_ID == 0)
					{ // check if no journal entry was made for on/off market
						throw new Exception();
					}
					else
					{
						// We know we did the On (or Off) market journal entry successfully
						modAdminCommon.Record_Transmit(Convert.ToString(adoAircraftRecordset["ac_ser_no_full"]), Convert.ToInt32(adoAircraftRecordset["ac_id"]), For_Sale_Journ_ID, Convert.ToInt32(adoAircraftRecordset["ac_amod_id"]), "Transaction", "Add", ref arr_Transmit_Fields);
					}

				} // IF CHANGE TO AVAILABILITY

				// *******************************************
				// IF THERE WAS A CHANGE TO THE STATUS FIELD
				if (tmp_NewStatus != tmp_OldStatus)
				{

					if (tmp_NewStatus.StartsWith("withdrawn from use", StringComparison.Ordinal) || tmp_NewStatus.StartsWith("written off", StringComparison.Ordinal) || tmp_NewStatus == "stolen" || tmp_NewStatus == "abandoned")
					{

						modAdminCommon.Rec_Journal_Info.journ_ac_id = Convert.ToInt32(adoAircraftRecordset["ac_id"]);
						modAdminCommon.Rec_Journal_Info.journ_comp_id = 0;
						modAdminCommon.Rec_Journal_Info.journ_contact_id = 0;

						modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(modAdminCommon.DateToday);
						modAdminCommon.Rec_Journal_Info.journ_description = modGlobalVars.cEmptyString;
						modAdminCommon.Rec_Journal_Info.journ_account_id = modGlobalVars.cEmptyString;
						modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
						modAdminCommon.Rec_Journal_Info.journ_status = "A";


						switch(tmp_NewStatus)
						{
							case "withdrawn from use" : 
								modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "WFU"; 
								 
								break;
							case "withdrawn from use - tech school" : 
								modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "WFUT"; 
								 
								break;
							case "withdrawn from use - display" : 
								modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "WFUD"; 
								 
								break;
							case "withdrawn from use - stored" : 
								modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "WFUS"; 
								 
								break;
							case "withdrawn from use - parked" : 
								modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "WFUP"; 
								 
								break;
							case "written off" : 
								modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "WO"; 
								 
								break;
							case "written off - accident" : 
								modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "WOA"; 
								 
								break;
							case "written off - parted out" : 
								modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "WOP"; 
								 
								break;
							case "written off - fire" : 
								modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "WOF"; 
								 
								break;
							case "written off - hurricane" : 
								modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "WOH"; 
								 
								break;
							case "written off - tornado" : 
								modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "WOT"; 
								 
								break;
							case "written off - war casualty" : 
								modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "WOWC"; 
								 
								break;
							case "written off - flood" : 
								modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "WOFD"; 
								 
								break;
							case "written off - damage" : 
								modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "WOD"; 
								 
								break;
							case "stolen" : 
								modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "STO"; 
								 
								break;
							case "abandoned" : 
								modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "ABN"; 
								 
								break;
						} //Case LCase(Trim(cbo_ac_status))

						JOURNAL_SUBJECT = $"Aircraft Status changed from: {modCommon.pf_Proper_Case(tmp_OldStatus)} to: {modCommon.pf_Proper_Case(tmp_NewStatus)}";
						modAdminCommon.Rec_Journal_Info.journ_subject = JOURNAL_SUBJECT.Trim();

						frm_Journal.DefInstance.Reference_Ac_Id = Convert.ToInt32(adoAircraftRecordset["ac_id"]);

						// RECORD THE JOURNAL ENTRY
						Status_Change_Journ_ID = frm_Journal.DefInstance.Commit_Journal_Entry();
						StatChangeJournalWritten = true; //aey 6/25/04

						if (Status_Change_Journ_ID == 0)
						{
							throw new Exception();
						}

						modAircraft.RemovePrimaryCompany(Convert.ToInt32(adoAircraftRecordset["ac_id"]), Convert.ToInt32(adoAircraftRecordset["ac_journ_id"]));

						// Change the Lifecycle Stage to 4 (Retired)
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(adoAircraftRecordset["ac_lifecycle_stage"]))
						{
							adoAircraftRecordset["ac_lifecycle_stage"] = 4;
						}

						// clear the TBO for retired aircraft
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						adoAircraftRecordset["ac_engine_1_tbo_hrs"] = DBNull.Value;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						adoAircraftRecordset["ac_engine_2_tbo_hrs"] = DBNull.Value;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						adoAircraftRecordset["ac_engine_3_tbo_hrs"] = DBNull.Value;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						adoAircraftRecordset["ac_engine_4_tbo_hrs"] = DBNull.Value;

						// clear the ON CONDITION TBO for retired aircraft
						adoAircraftRecordset["ac_engine_tbo_oc_flag"] = "N";

					}

					if (tmp_OldStatus.StartsWith("withdrawn from use", StringComparison.Ordinal) || tmp_OldStatus.StartsWith("written off", StringComparison.Ordinal) || tmp_OldStatus == "stolen" || tmp_OldStatus == "abandoned")
					{

						if (!tmp_NewStatus.StartsWith("withdrawn from use", StringComparison.Ordinal) && !tmp_NewStatus.StartsWith("written off", StringComparison.Ordinal) && tmp_NewStatus != "stolen" && tmp_NewStatus != "abandoned")
						{

							modAdminCommon.Rec_Journal_Info.journ_ac_id = Convert.ToInt32(adoAircraftRecordset["ac_id"]);
							modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(modAdminCommon.DateToday);
							modAdminCommon.Rec_Journal_Info.journ_comp_id = 0;
							modAdminCommon.Rec_Journal_Info.journ_contact_id = 0;
							modAdminCommon.Rec_Journal_Info.journ_description = modGlobalVars.cEmptyString;
							modAdminCommon.Rec_Journal_Info.journ_account_id = modGlobalVars.cEmptyString;
							modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
							modAdminCommon.Rec_Journal_Info.journ_status = "A";
							modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "BIS";

							JOURNAL_SUBJECT = $"Aircraft Back In Service - from: {modCommon.pf_Proper_Case(tmp_OldStatus)} to: {modCommon.pf_Proper_Case(tmp_NewStatus)}";

							modAdminCommon.Rec_Journal_Info.journ_subject = JOURNAL_SUBJECT.Trim();

							frm_Journal.DefInstance.Reference_Ac_Id = Convert.ToInt32(adoAircraftRecordset["ac_id"]);

							// RECORD THE BACK IN SERVICE JOURNAL ENTRY
							Status_Change_Journ_ID = frm_Journal.DefInstance.Commit_Journal_Entry();

							StatChangeJournalWritten = true;

							if (Status_Change_Journ_ID == 0)
							{
								throw new Exception();
							}

							// INSERT A PRIORITY EVENT FOR BACK IN SERVICE
							modCommon.InsertPriorityEvent("SC", Convert.ToInt32(adoAircraftRecordset["ac_id"]), Convert.ToInt32(adoAircraftRecordset["ac_journ_id"]), JOURNAL_SUBJECT.Trim(), 0, 0, "Y");

							// UPDATE THE CURRENT PREVIOUS OWNER TO BE THE CURRENT OWNER AND PREVIOUS OPERATOR TO BE OPERATOR
							modAircraft.RestorePreviousOwner(Convert.ToInt32(adoAircraftRecordset["ac_id"]), Convert.ToInt32(adoAircraftRecordset["ac_journ_id"]));

							// Set the lifecycle stage to 3 (In Operation)
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(adoAircraftRecordset["ac_lifecycle_stage"]))
							{
								adoAircraftRecordset["ac_lifecycle_stage"] = 3;
							}

							EventChangeWritten = true;

						}

					}

					if (!StatChangeJournalWritten)
					{ //aey 6/25/04
						// if nothing else wrote out a journal entry
						modAdminCommon.Rec_Journal_Info.journ_ac_id = Convert.ToInt32(adoAircraftRecordset["ac_id"]);
						modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(modAdminCommon.DateToday);
						modAdminCommon.Rec_Journal_Info.journ_comp_id = 0;
						modAdminCommon.Rec_Journal_Info.journ_contact_id = 0;
						modAdminCommon.Rec_Journal_Info.journ_description = modGlobalVars.cEmptyString;
						modAdminCommon.Rec_Journal_Info.journ_account_id = modGlobalVars.cEmptyString;
						modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
						modAdminCommon.Rec_Journal_Info.journ_status = "A";


						JOURNAL_SUBJECT = $"Aircraft Status changed from: {modCommon.pf_Proper_Case(tmp_OldStatus)} to: {modCommon.pf_Proper_Case(tmp_NewStatus)}";

						if (JOURNAL_SUBJECT.IndexOf("to: Deregistered") >= 0 || JOURNAL_SUBJECT.IndexOf(", Deregistered") >= 0)
						{
							modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "DEREG";
						}
						else if (JOURNAL_SUBJECT.IndexOf("from: Deregistered") >= 0 && JOURNAL_SUBJECT.IndexOf("Aircraft Status changed") >= 0)
						{ 
							modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "DEREG";
						}
						else
						{
							modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "RN";
						}

						modAdminCommon.Rec_Journal_Info.journ_subject = JOURNAL_SUBJECT.Trim();
						frm_Journal.DefInstance.Reference_Ac_Id = Convert.ToInt32(adoAircraftRecordset["ac_id"]);

						Status_Change_Journ_ID = frm_Journal.DefInstance.Commit_Journal_Entry();
						StatChangeJournalWritten = true;

						if (Status_Change_Journ_ID == 0)
						{
							throw new Exception();
						}

					}

					if (tmp_OldStatus == "for sale" && tmp_NewStatus == "sale pending")
					{
						JOURNAL_SUBJECT = $"from: {modCommon.pf_Proper_Case(tmp_OldStatus)} to: {modCommon.pf_Proper_Case(tmp_NewStatus)}";
						modCommon.InsertPriorityEvent("SALEP", Convert.ToInt32(adoAircraftRecordset["ac_id"]), Convert.ToInt32(adoAircraftRecordset["ac_journ_id"]), JOURNAL_SUBJECT.Trim(), 0, 0, "Y");
					}

					if (tmp_OldStatus == "sale pending" && tmp_NewStatus == "for sale")
					{

						if (ac_delivery_Text.Trim().ToLower() == "immediate")
						{
							JOURNAL_SUBJECT = $"from: {modCommon.pf_Proper_Case(tmp_OldStatus)} to: {modCommon.pf_Proper_Case(tmp_NewStatus)} [Delivery Immediate]";
						}
						else
						{
							JOURNAL_SUBJECT = $"from: {modCommon.pf_Proper_Case(tmp_OldStatus)} to: {modCommon.pf_Proper_Case(tmp_NewStatus)}";
						}

						modCommon.InsertPriorityEvent("SPTOIM", Convert.ToInt32(adoAircraftRecordset["ac_id"]), Convert.ToInt32(adoAircraftRecordset["ac_journ_id"]), JOURNAL_SUBJECT.Trim(), 0, 0, "Y");
					}

					if (!EventChangeWritten)
					{
						JOURNAL_SUBJECT = $"from: {modCommon.pf_Proper_Case(tmp_OldStatus)} to: {modCommon.pf_Proper_Case(tmp_NewStatus)}";
						modCommon.InsertPriorityEvent("SC", Convert.ToInt32(adoAircraftRecordset["ac_id"]), Convert.ToInt32(adoAircraftRecordset["ac_journ_id"]), JOURNAL_SUBJECT.Trim(), 0, 0, "Y");
						EventChangeWritten = true;
					}

				} //  LCase(Trim(tmp_NewStatus)) <> LCase(Trim(tmp_OldStatus)) Then

				return result;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Transaction_Check_for_Status_Change ({Information.Err().Number.ToString()}) {excep.Message}", "Aircraft (modAircraft)");
				return result;
			}
		}

		internal static int GetOwnerCompanyID(int inAircraft_ID, int inJournal_ID)
		{

			int result = 0;
			try
			{

				string Query = "";
				ADORecordSetHelper snpOwner = new ADORecordSetHelper(); //8/11/05 aey

				result = 0;

				Query = $"SELECT cref_comp_id FROM Aircraft_Reference WITH(NOLOCK) WHERE cref_ac_id = {inAircraft_ID.ToString()}";
				Query = $"{Query} AND cref_journ_id = {inJournal_ID.ToString()} AND cref_transmit_seq_no = 1";

				snpOwner.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpOwner.BOF && snpOwner.EOF))
				{
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snpOwner["cref_comp_id"]))
					{
						result = Convert.ToInt32(snpOwner["cref_comp_id"]);
					}
				}

				snpOwner.Close();
				snpOwner = null;

				return result;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"GetOwnerCompanyID_Error({Information.Err().Number.ToString()}) {excep.Message}", "Aircraft (modAircraft)");
				return result;
			}
		}

		internal static int GetOwnerContactID(int inAircraft_ID, int inJournal_ID)
		{

			int result = 0;
			try
			{

				string Query = "";
				ADORecordSetHelper snpOwner = new ADORecordSetHelper(); //8/11/05 aey

				result = 0;

				Query = "SELECT cref_contact_id FROM Aircraft_Reference WITH(NOLOCK)";
				Query = $"{Query} WHERE cref_ac_id = {inAircraft_ID.ToString()}";
				Query = $"{Query} AND cref_journ_id = {inJournal_ID.ToString()}";
				Query = $"{Query} AND cref_transmit_seq_no = 1";

				snpOwner.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpOwner.BOF && snpOwner.EOF))
				{
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snpOwner["cref_contact_id"]))
					{
						result = Convert.ToInt32(snpOwner["cref_contact_id"]);
					}
				}

				snpOwner.Close();
				snpOwner = null;

				return result;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"GetOwnerContactID_Error({Information.Err().Number.ToString()}) {excep.Message}", "Aircraft (modAircraft)");
				return result;
			}
		}

		internal static int GetCurrentOwnerID(int inAircraft_ID)
		{

			int result = 0;
			try
			{

				string Query = "";
				ADORecordSetHelper snpOwner = new ADORecordSetHelper();

				result = 0;

				Query = "SELECT comp_id FROM Company, Aircraft_Reference WITH(NOLOCK)";
				Query = $"{Query} WHERE comp_id = cref_comp_id AND cref_ac_id = {inAircraft_ID.ToString()}";
				Query = $"{Query} AND cref_journ_id = 0  AND cref_transmit_seq_no = 1";

				snpOwner.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpOwner.BOF && snpOwner.EOF))
				{
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snpOwner["Comp_id"]))
					{
						result = Convert.ToInt32(snpOwner["Comp_id"]);
					}
				}

				snpOwner.Close();
				snpOwner = null;

				return result;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"GetCurrentOwnerID_Error({Information.Err().Number.ToString()}) {excep.Message}", "Aircraft (modAircraft)");
				return result;
			}
		}

		internal static int GetCurrentExclID_From_Name(int inAircraft_ID, ref int contact_id, string comp_name, string Contact_Type = "")
		{

			int result = 0;
			try
			{

				string Query = "";
				ADORecordSetHelper snpOwner = new ADORecordSetHelper();

				result = 0;

				Query = "SELECT comp_id , comp_name";
				if (StringsHelper.ToDoubleSafe(contact_id.ToString().Trim()) > 0 || StringsHelper.ToDoubleSafe(contact_id.ToString().Trim()) == -2)
				{
					Query = $"{Query}, contact_id ";
				}
				Query = $"{Query} FROM Aircraft_Reference WITH(NOLOCK)";
				if (StringsHelper.ToDoubleSafe(contact_id.ToString().Trim()) > 0 || StringsHelper.ToDoubleSafe(contact_id.ToString().Trim()) == -2)
				{
					Query = $"{Query} inner join Contact on  contact_id = cref_contact_id and contact_journ_id = cref_journ_id ";
				}
				Query = $"{Query} left outer join Company on comp_id = cref_comp_id and comp_journ_id = cref_journ_id ";
				Query = $"{Query} WHERE cref_ac_id = {inAircraft_ID.ToString()}";
				Query = $"{Query} and comp_name = '{StringsHelper.Replace(comp_name, "'", "''", 1, -1, CompareMethod.Binary)}' ";
				Query = $"{Query} AND cref_journ_id = 0";

				// adding in MSW - for companies with multiple relationships this was sometimes adding the wrong contact into the event
				// - 7/29/22
				if (Contact_Type.Trim() != "")
				{
					Query = $"{Query} and cref_contact_type = '{Contact_Type}' ";
				}

				snpOwner.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpOwner.BOF && snpOwner.EOF))
				{
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snpOwner["Comp_id"]))
					{
						result = Convert.ToInt32(snpOwner["Comp_id"]);
						if (StringsHelper.ToDoubleSafe(contact_id.ToString().Trim()) > 0 || StringsHelper.ToDoubleSafe(contact_id.ToString().Trim()) == -2)
						{
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(snpOwner["contact_id"]))
							{
								contact_id = Convert.ToInt32(snpOwner["contact_id"]);
							}
							else
							{
								contact_id = 0;
							}
						}
					}
				}
				snpOwner.Close();

				if (StringsHelper.ToDoubleSafe(contact_id.ToString().Trim()) == -2 && Contact_Type.Trim() != "")
				{
					Query = "SELECT comp_id , comp_name";
					Query = $"{Query}, contact_id FROM Aircraft_Reference WITH(NOLOCK)";
					Query = $"{Query} inner join Contact on  contact_id = cref_contact_id and contact_journ_id = cref_journ_id ";
					Query = $"{Query} left outer join Company on comp_id = cref_comp_id and comp_journ_id = cref_journ_id ";
					Query = $"{Query} WHERE cref_ac_id = {inAircraft_ID.ToString()}";
					Query = $"{Query} and cref_contact_type = '{Contact_Type}' AND cref_journ_id = 0";

					snpOwner.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!(snpOwner.BOF && snpOwner.EOF))
					{
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snpOwner["Comp_id"]))
						{
							result = Convert.ToInt32(snpOwner["Comp_id"]);
							if (StringsHelper.ToDoubleSafe(contact_id.ToString().Trim()) > 0 || StringsHelper.ToDoubleSafe(contact_id.ToString().Trim()) == -2)
							{
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(snpOwner["contact_id"]))
								{
									contact_id = Convert.ToInt32(snpOwner["contact_id"]);
								}
								else
								{
									contact_id = 0;
								}
							}
						}
					}
					snpOwner.Close();
				}




				snpOwner = null;

				return result;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"GetCurrentExclID_From_Name_Error({Information.Err().Number.ToString()}) {excep.Message}", "Aircraft (modAircraft)");
				return result;
			}
		}


		internal static int GetCompany_From_Name(int inAircraft_ID, ref int contact_id, string comp_name, int comp_id)
		{

			int result = 0;
			try
			{

				string Query = "";
				ADORecordSetHelper snpOwner = new ADORecordSetHelper();

				result = 0;

				Query = "SELECT comp_id , comp_name, contact_id ";
				Query = $"{Query} FROM Aircraft_Reference WITH(NOLOCK)";
				Query = $"{Query} inner join Contact on  contact_id = cref_contact_id and contact_journ_id = cref_journ_id ";
				Query = $"{Query} left outer join Company on comp_id = cref_comp_id and comp_journ_id = cref_journ_id ";
				Query = $"{Query} WHERE cref_ac_id = {inAircraft_ID.ToString()}";
				Query = $"{Query} and comp_id = {comp_id.ToString()} AND cref_journ_id = 0";

				snpOwner.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpOwner.BOF && snpOwner.EOF))
				{
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snpOwner["Comp_id"]))
					{
						result = Convert.ToInt32(snpOwner["Comp_id"]);
						if (StringsHelper.ToDoubleSafe(contact_id.ToString().Trim()) > 0)
						{
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(snpOwner["contact_id"]))
							{
								contact_id = Convert.ToInt32(snpOwner["contact_id"]);
							}
							else
							{
								contact_id = 0;
							}
						}
					}
				}

				snpOwner.Close();
				snpOwner = null;

				return result;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"GetCompany_From_Name_Error({Information.Err().Number.ToString()}) {excep.Message}", "Aircraft (modAircraft)");
				return result;
			}
		}


		internal static string GetCurrentOwner(int inAircraft_ID)
		{

			string result = "";
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strResults = "";

			try
			{

				strResults = "";

				strQuery1 = "SELECT comp_name FROM Company WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}INNER JOIN Aircraft_Reference WITH (NOLOCK) ON cref_comp_id = comp_id AND cref_journ_id = comp_journ_id ";
				strQuery1 = $"{strQuery1}WHERE (cref_ac_id = {inAircraft_ID.ToString()}) ";
				strQuery1 = $"{strQuery1}AND (cref_journ_id = 0) ";
				strQuery1 = $"{strQuery1}AND (cref_transmit_seq_no = 1) ";

				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{
					strResults = ($"{Convert.ToString(rstRec1["comp_name"])} ").Trim();
				}

				rstRec1.Close();
				rstRec1 = null;


				return strResults;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"GetCurrentOwner_Error({Information.Err().Number.ToString()}) {excep.Message}", "Aircraft (modAircraft)");
				result = "";
			}
			return result;
		} // GetCurrentOwner

		internal static string GetCurrentExclusive(int inAircraft_ID, ref int comp_id, ref int contact_id)
		{

			string result = "";
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strResults = "";

			try
			{

				strResults = "";

				strQuery1 = "SELECT comp_name, comp_id, cref_contact_id ";
				strQuery1 = $"{strQuery1}FROM Company WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}INNER JOIN Aircraft_Reference WITH (NOLOCK) ON cref_comp_id = comp_id AND cref_journ_id = comp_journ_id ";
				strQuery1 = $"{strQuery1}WHERE (cref_ac_id = {inAircraft_ID.ToString()}) ";
				strQuery1 = $"{strQuery1}AND (cref_journ_id = 0) AND cref_contact_type = '99' ";

				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{
					strResults = ($"{Convert.ToString(rstRec1["comp_name"])} ").Trim();

					comp_id = Convert.ToInt32(Double.Parse(($"{Convert.ToString(rstRec1["comp_id"])} ").Trim()));
					contact_id = Convert.ToInt32(Double.Parse(($"{Convert.ToString(rstRec1["cref_contact_id"])} ").Trim()));
				}

				rstRec1.Close();
				rstRec1 = null;


				return strResults;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"GetCurrentExclusive_Error({Information.Err().Number.ToString()}) {excep.Message}", "Aircraft (modAircraft)");
				result = "";
			}
			return result;
		} // GetCurrentOwner
		internal static bool No_Exclusive(int inAircraft_ID)
		{
			bool result = false;
			string Query = "";
			ADORecordSetHelper adoExclusiveRep = new ADORecordSetHelper();

			try
			{

				result = true;

				Query = "SELECT count(*) as tcount from Aircraft_Reference";
				Query = $"{Query} WHERE cref_ac_id = {inAircraft_ID.ToString()}";
				Query = $"{Query} AND cref_journ_id = 0 AND cref_primary_poc_flag = 'X'";

				adoExclusiveRep.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(adoExclusiveRep.BOF && adoExclusiveRep.EOF))
				{

					if (Convert.ToDouble(adoExclusiveRep["tcount"]) > 0)
					{
						result = false;
					}

				}

				adoExclusiveRep.Close();
				adoExclusiveRep = null;

				return result;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"No_Exclusive_Error({Information.Err().Number.ToString()}) {excep.Message}", "Aircraft (modAircraft)");
				return result;
			}
		}

		internal static bool CanBeExpired(int inAircraft_ID, int inJournal_ID)
		{

			bool result = false;
			string Query = "";
			ADORecordSetHelper snpOwner = new ADORecordSetHelper(); //8/11/05 aey

			try
			{

				Query = $"SELECT cref_id FROM Aircraft_Reference WITH(NOLOCK) WHERE cref_ac_id = {inAircraft_ID.ToString()}";
				Query = $"{Query} AND cref_journ_id = 0 AND cref_contact_type = '57' ";
				Query = $"{Query} AND cref_comp_id IN";
				// GET THE LESSEE FROM THE TRANSACTION WE ARE TRYING TO REMOVE AND MAKE SURE HE IS NOT THE LESSEE-SUBLESSOR OF THE CURRENT AIRCRAFT
				Query = $"{Query} (SELECT cref_comp_id FROM Aircraft_Reference inner join journal on journ_id = cref_journ_id WHERE cref_ac_id = {inAircraft_ID.ToString()}";
				Query = $"{Query} AND cref_journ_id = {inJournal_ID.ToString()} AND cref_contact_type = '12' and left(journ_subcategory_code, 1) = 'L') ";

				if (!modAdminCommon.Exist(Query))
				{
					result = true;
				}
				else
				{

					Query = " SELECT top 1 journ_id FROM Aircraft_Reference WITH(NOLOCK)";
					Query = $"{Query} inner join journal on journ_id = cref_journ_id ";
					Query = $"{Query} Where cref_ac_id = {inAircraft_ID.ToString()}";
					Query = $"{Query} AND cref_contact_type = '12' ";
					Query = $"{Query} and left(journ_subcategory_code, 1) = 'L'";
					Query = $"{Query} order by journ_date desc, journ_id desc ";

					snpOwner.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!(snpOwner.BOF && snpOwner.EOF))
					{
						if (Convert.ToDouble(snpOwner["journ_id"]) != inJournal_ID)
						{
							result = true;
						}
					}

					snpOwner.Close();
					snpOwner = null;

				}

				return result;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"CanBeExpired_Error ({Information.Err().Number.ToString()}) {excep.Message}", "Aircraft (modAircraft)");
				return result;
			}
		}

		internal static void RemovePrimaryCompany(int inAircraftId, int inAircraftJID)
		{

			string Query = "";
			//
			// RTW - MODIFIED - 4/17/2011
			// CHANGED TO HAVE PRIMARY POC FLAG UPDATE NOTE REUPDTE THE SAME REFERENCE RECORDS
			try
			{

				Query = "UPDATE Aircraft_Reference SET cref_contact_type = '56', cref_primary_poc_flag = 'N',cref_operator_flag='N'";
				Query = $"{Query} WHERE cref_ac_id = {inAircraftId.ToString()}";
				Query = $"{Query} AND cref_journ_id = {inAircraftJID.ToString()}";
				Query = $"{Query} AND cref_contact_type IN ('00','08','97','50','55')";
				// 00 = Owner, 08 = Co-Owner, 97 = Fractional Owner, 50 = Owner-Operator, 55 = Owner-Lessor

				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();

				// Set the Operator(36) to Previous operator (2B)
				Query = "UPDATE Aircraft_Reference SET cref_contact_type = '2B', cref_primary_poc_flag = 'N',cref_operator_flag='N'";
				Query = $"{Query} WHERE cref_ac_id = {inAircraftId.ToString()}";
				Query = $"{Query} AND cref_journ_id = {inAircraftJID.ToString()}";
				Query = $"{Query} AND cref_contact_type ='36'";

				DbCommand TempCommand_2 = null;
				TempCommand_2 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
				TempCommand_2.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand_2.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
				TempCommand_2.ExecuteNonQuery();

				// Turn the operator flag off )
				Query = "UPDATE Aircraft_Reference SET cref_operator_flag='N', cref_primary_poc_flag = 'N'";
				Query = $"{Query} WHERE cref_ac_id = {inAircraftId.ToString()}";
				Query = $"{Query} AND cref_journ_id = {inAircraftJID.ToString()}";
				Query = $"{Query} AND cref_operator_flag='Y'";

				DbCommand TempCommand_3 = null;
				TempCommand_3 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_3);
				TempCommand_3.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand_3.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_3);
				TempCommand_3.ExecuteNonQuery();


				//**********************************************
				// Set the primary to (N)ot Primary
				Query = "UPDATE Aircraft_Reference SET cref_primary_poc_flag = 'N'";
				Query = $"{Query} WHERE cref_ac_id = {inAircraftId.ToString()}";
				Query = $"{Query} AND cref_journ_id={inAircraftJID.ToString()}";
				Query = $"{Query} AND cref_primary_poc_flag = 'Y'";

				DbCommand TempCommand_4 = null;
				TempCommand_4 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_4);
				TempCommand_4.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand_4.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_4);
				TempCommand_4.ExecuteNonQuery();
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"RemovePrimaryCompany_Error({Information.Err().Number.ToString()}) {excep.Message}", "Aircraft (modAircraft)");
				return;
			}

		}

		internal static void RestorePreviousOwner(int inAircraftId, int inAircraftJID)
		{

			// RTW - MODIFIED ON 4/17/2011
			// ADJUSTED THE WAY THE PRIMARY POC FLAG IS SET TO TRY TO AVOID UPDATING THE SAME RECORD
			//
			try
			{

				string Query = "";


				//***************************************************************
				// Set the previous Owner (56) to Owner (00) and also Primary
				Query = "UPDATE Aircraft_Reference SET cref_contact_type = '00', cref_primary_poc_flag = 'Y'";
				Query = $"{Query} WHERE cref_ac_id = {inAircraftId.ToString()}";
				Query = $"{Query} AND cref_journ_id = {inAircraftJID.ToString()}";
				Query = $"{Query} AND cref_contact_type = '56'";

				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();

				// Set the previous operator(2B) to Operator (36) and also set oper flag

				Query = "UPDATE Aircraft_Reference SET cref_contact_type = '36', cref_operator_flag = 'Y', cref_primary_poc_flag='N'";
				Query = $"{Query} WHERE cref_ac_id = {inAircraftId.ToString()}";
				Query = $"{Query} AND cref_journ_id = {inAircraftJID.ToString()}";
				Query = $"{Query} AND cref_contact_type = '2B'";

				DbCommand TempCommand_2 = null;
				TempCommand_2 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
				TempCommand_2.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand_2.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
				TempCommand_2.ExecuteNonQuery();

				//***************************************************************
				// Set all references to "(N)ot Primary-
				Query = "UPDATE Aircraft_Reference SET cref_primary_poc_flag = 'N'";
				Query = $"{Query} WHERE cref_ac_id = {inAircraftId.ToString()}";
				Query = $"{Query} AND cref_journ_id = {inAircraftJID.ToString()}";
				Query = $"{Query} and cref_contact_type NOT IN ('00','36')";

				DbCommand TempCommand_3 = null;
				TempCommand_3 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_3);
				TempCommand_3.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand_3.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_3);
				TempCommand_3.ExecuteNonQuery();
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"RestorePreviousOwner_Error({Information.Err().Number.ToString()}) {excep.Message}", "Aircraft (modAircraft)");
				return;
			}

		}

		internal static void AssignPrimaryPOC(int lACId, int primary_comp_id)
		{

			try
			{

				ADORecordSetHelper ado_POC = null;
				string Query = "";
				int lCRefId = 0;
				lCRefId = 0;
				int lCompId = 0;
				lCompId = 0;

				Query = $"SELECT * FROM Aircraft_Reference WITH(NOLOCK) WHERE (cref_ac_id = {lACId.ToString()})";
				Query = $"{Query}AND (cref_journ_id = 0) AND (cref_contact_type in ('00','17','08','56'))";

				ado_POC = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(ado_POC.Fields) && !(ado_POC.BOF && ado_POC.EOF))
				{

					lCRefId = Convert.ToInt32(ado_POC["cref_id"]);
					lCompId = Convert.ToInt32(ado_POC["cref_comp_id"]);
					ado_POC.Close();

				}

				ado_POC = null;

				// RTW - 4/28/2004 - MODIFIED TO ONLY USE UNIQUE REFERENCE ID FOR THE UPDATE
				Query = $"UPDATE Aircraft_Reference SET cref_primary_poc_flag = 'Y' WHERE cref_id = {lCRefId.ToString()}";

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

				modCommon.Check_For_Account_Reassignment(primary_comp_id, lCompId, lACId);

				modAdminCommon.ADO_Transaction("CommitTrans");
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"AssignPrimaryPOC_Error ({Information.Err().Number.ToString()}) {excep.Message}", "Aircraft (modAircraft)");
				modAdminCommon.ADO_Transaction("RollbackTrans");
				return;
			}

		}

		internal static bool NoPrimaryPOC(int lACId)
		{

			bool result = false;
			string Query = "";

			try
			{

				result = false;

				Query = "SELECT cref_primary_poc_flag FROM Aircraft_Reference WITH(NOLOCK)";
				Query = $"{Query} WHERE (cref_ac_id = {lACId.ToString()})";
				Query = $"{Query} AND (cref_journ_id = 0) AND (cref_primary_poc_flag = 'Y')";

				if (!modAdminCommon.Exist(Query))
				{
					result = true;
				}

				return result;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"NoPrimaryPOC_Error ({Information.Err().Number.ToString()}) {excep.Message}", "Aircraft (modAircraft)");
				return result;
			}
		}
		//================================================================================================
		//
		// 02/06/2008 - By David D. Cruger; Completely rewrote this routine based on meeting
		// with Lucia, Beth, Jackie and Courtney.
		// I also moved this routine to the modAircraft common module
		//
		// Rules:
		// 1) Only 1 Operator Flag can be set on an aircraft
		// 2) Do NOT Update if any reference has an 'O' for cref_operator_flag.  This means it was manually set
		// 3) Management Companies, both aircraft reference and/or business type
		// 4) Charter Companies, both aircraft reference and/or business type
		// 5) Co-Owners, use the one flagged Primary Point of Contact
		// 6) Sub-Lessee before Lessee
		// 7) Only to put Operator Flag on an Awaiting Documentation company
		// 8) Owners - Except if Business type is CD,DB,DS,FI,FS,FY,LS,MF,RE  (Then considered an End User)
		//
		// Sequence
		//  PreCheck Can Not Have Previous Owner or Previous Operator (Lifecycle=4) Aircraft
		//  1) Type 36 = Operator
		//  2) Type 31 = Aircraft Management Company
		//  3) Type 11 = Flight Department
		//  4) Type 35 = Hangar
		//  5) Type 94 = Charter Company
		//  6) Type 39 = Sublessee
		//  7) Type 12 = Lessee
		//  8) Type 18 = Program Manager
		//  9) Type 08 = Co-Owner - If Primary Point Of Contact
		// 10) Type 00 = Owner, If NOT CB,DB,DS,FI,FS,FY,LS,MF,RE
		//
		// Notes:
		// 04/04/2008 - By David D. Cruger; Per Lu; Exclude 71=Research Contact
		// 07/08/2008 - By David D. Cruger; Per Lu; Ignore Written Off Aircraft, do not process historical
		// records.
		// 09/12/2008 - By David D. Cruger; Per Lu; On CH, MC add if seqno = 22 so it only gets position 2
		//
		//================================================================================================

		internal static void SetOperatorFlag(int lACId, int lJournId)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			ADORecordSetHelper rstRec2 = new ADORecordSetHelper();

			string strQuery1 = "";
			string strQuery2 = "";

			string strUpdate1 = "";

			int lTotalRec = 0;
			int lWorking = 0;
			int lChg = 0;

			string strBT = ""; // Business Type

			bool bFound = false;
			bool bIsManualFlagSet = false;

			int temp_comp_id = 0;
			int last_operating_comp = 0;

			try
			{

				bFound = false;

				if (lJournId == 0)
				{ // Only Current Aircraft

					last_operating_comp = Find_Operating_Company_ID(lACId, Convert.ToInt32(Double.Parse(lJournId.ToString())));

					strQuery1 = "SELECT cref_id FROM Aircraft_Reference WITH(NOLOCK)";
					strQuery1 = $"{strQuery1} WHERE (cref_ac_id = {lACId.ToString()})";
					strQuery1 = $"{strQuery1} AND (cref_journ_id = {lJournId.ToString()})";
					strQuery1 = $"{strQuery1} AND (cref_operator_flag = 'O')";

					bIsManualFlagSet = modAdminCommon.Exist(strQuery1);
					if (!bIsManualFlagSet)
					{

						strUpdate1 = "UPDATE Aircraft_Reference SET cref_operator_flag = 'N'";
						strUpdate1 = $"{strUpdate1} WHERE (cref_ac_id = {lACId.ToString()})";
						strUpdate1 = $"{strUpdate1} AND (cref_journ_id = {lJournId.ToString()})";
						strUpdate1 = $"{strUpdate1} AND (cref_operator_flag = 'Y')";

						DbCommand TempCommand = null;
						TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
						TempCommand.CommandText = strUpdate1;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
						TempCommand.ExecuteNonQuery();

						//--------------------------------------------------------
						// There are 10 priorities to assigning the Opeartor Flag
						strQuery2 = "SELECT Aircraft_Reference.*";
						strQuery2 = $"{strQuery2} FROM Aircraft_Reference";
						strQuery2 = $"{strQuery2} INNER JOIN Aircraft ON cref_ac_id = ac_id AND cref_journ_id = ac_journ_id";
						strQuery2 = $"{strQuery2} WHERE (cref_ac_id = {lACId.ToString()})";
						strQuery2 = $"{strQuery2} AND (cref_journ_id = {lJournId.ToString()})";
						strQuery2 = $"{strQuery2} AND (cref_contact_type <> '71')";
						strQuery2 = $"{strQuery2} AND (ac_lifecycle_stage < 4)"; // No Written Off Aircraft

						rstRec2.Open(strQuery2, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

						if ((!rstRec2.BOF) && (!rstRec2.EOF))
						{

							bFound = true;

							//----------------------------------------------------------
							// First Test if any are of type='0' Do NOT Auto Update
							//----------------------------------------------------------
							rstRec2.Filter = ""; // Clear Filter
							rstRec2.Filter = "(cref_operator_flag = '0')";
							if ((rstRec2.BOF) && (rstRec2.EOF))
							{ // No Records Found, Ok to Auto Update

								//--------------------------------------------------------
								// Priority #1 = Type 36 - Operator
								//--------------------------------------------------------
								rstRec2.Filter = ""; // Clear Filter
								rstRec2.Filter = "(cref_contact_type = '36')";
								if ((rstRec2.BOF) && (rstRec2.EOF))
								{ // Nothing Found - Next

									//--------------------------------------------------------
									// Priority #2a = Type 31 - Aircraft Management Company
									//--------------------------------------------------------
									rstRec2.Filter = ""; // Clear Filter
									rstRec2.Filter = "(cref_contact_type = '31')";
									if ((rstRec2.BOF) && (rstRec2.EOF))
									{ // Nothing Found - Next

										//-----------------------------------------------------------------------
										// Priority #2b = Business Type MC - Aircraft Management Company
										//-----------------------------------------------------------------------
										rstRec2.Filter = ""; // Clear Filter
										rstRec2.Filter = "(cref_transmit_seq_no = 2 AND cref_business_type = 'MC')";
										if ((rstRec2.BOF) && (rstRec2.EOF))
										{ // Nothing Found - Next

											//--------------------------------------------------------
											// Priority #3 = Type 11 - Flight Department
											//--------------------------------------------------------
											rstRec2.Filter = ""; // Clear Filter
											rstRec2.Filter = "(cref_contact_type = '11')";
											if ((rstRec2.BOF) && (rstRec2.EOF))
											{ // Nothing Found - Next

												//--------------------------------------------------------
												// Priority #4 = Type 35 - Hangar
												//--------------------------------------------------------
												rstRec2.Filter = ""; // Clear Filter
												rstRec2.Filter = "(cref_contact_type = '35')";
												if ((rstRec2.BOF) && (rstRec2.EOF))
												{ // Nothing Found - Next

													//--------------------------------------------------------
													// Priority #5a = Type 94 - Charter Company
													//--------------------------------------------------------
													rstRec2.Filter = ""; // Clear Filter
													rstRec2.Filter = "(cref_contact_type = '94')";
													if ((rstRec2.BOF) && (rstRec2.EOF))
													{ // Nothing Found - Next

														//------------------------------------------------------------------------
														// Priority #5b = Business Type CH - Charter Company
														//------------------------------------------------------------------------
														rstRec2.Filter = ""; // Clear Filter
														rstRec2.Filter = "(cref_transmit_seq_no = 2 AND cref_business_type = 'CH')";
														if ((rstRec2.BOF) && (rstRec2.EOF))
														{ // Nothing Found - Next

															//--------------------------------------------------------
															// Priority #6 = Type 39 - SubLessee
															//--------------------------------------------------------
															rstRec2.Filter = ""; // Clear Filter
															rstRec2.Filter = "(cref_contact_type = '39')";
															if ((rstRec2.BOF) && (rstRec2.EOF))
															{ // Nothing Found - Next

																//--------------------------------------------------------
																// Priority #7 = Type 12 - Lessee
																//--------------------------------------------------------
																rstRec2.Filter = ""; // Clear Filter
																rstRec2.Filter = "(cref_contact_type = '12')";
																if ((rstRec2.BOF) && (rstRec2.EOF))
																{ // Nothing Found - Next

																	//--------------------------------------------------------
																	// Priority #7.5 = Type 1V - Certificate Holder
																	// ADDED BY RTW ON 5/13/2021 PER TASK PLANNING TEAM
																	//--------------------------------------------------------
																	rstRec2.Filter = ""; // Clear Filter
																	rstRec2.Filter = "(cref_contact_type = '1V')";
																	if ((rstRec2.BOF) && (rstRec2.EOF))
																	{ // Nothing Found - Next

																		//--------------------------------------------------------
																		// Priority #8a = Type 18 - Fractional - Program Manager
																		//--------------------------------------------------------
																		rstRec2.Filter = ""; // Clear Filter
																		rstRec2.Filter = "(cref_contact_type = '18')";
																		if ((rstRec2.BOF) && (rstRec2.EOF))
																		{ // Nothing Found - Next

																			//-----------------------------------------------------------------------
																			// Priority #8b = Business Type PM - Fractional - Program Manager
																			//-----------------------------------------------------------------------
																			rstRec2.Filter = ""; // Clear Filter
																			rstRec2.Filter = "(cref_business_type = 'PM')";
																			if ((rstRec2.BOF) && (rstRec2.EOF))
																			{ // Nothing Found - Next

																				//--------------------------------------------------------
																				// Priority #9 = Type 08 - Co-Owned
																				// Must Also Be The Primary Point Of Contact
																				//--------------------------------------------------------
																				rstRec2.Filter = ""; // Clear Filter
																				rstRec2.Filter = "(cref_contact_type = '08') AND (cref_primary_poc_flag <> 'N') ";
																				if ((rstRec2.BOF) && (rstRec2.EOF))
																				{ // Nothing Found - Next

																					rstRec2.Filter = ""; // Clear Filter
																					rstRec2.Filter = "(cref_contact_type = '08') AND (cref_transmit_seq_no = 1) ";
																					if ((rstRec2.BOF) && (rstRec2.EOF))
																					{ // Nothing Found - Next

																						//--------------------------------------------------------
																						// Priority #10 = Type 00 - Owner
																						//--------------------------------------------------------
																						rstRec2.Filter = ""; // Clear Filter
																						rstRec2.Filter = "(cref_contact_type = '00') ";
																						if ((rstRec2.BOF) && (rstRec2.EOF))
																						{ // Nothing Found - Next
																							bFound = false; //********** NOTHING Found ************
																						}
																						else
																						{
																							// Make Sure Owner Is An End User

																							strBT = ($"{Convert.ToString(rstRec2["cref_business_type"])} ").Trim();

																							bFound = true; // Considered An End User
																							//
																						} // If (rstRec2.BOF = True) And (rstRec2.EOF = True) Then ' Nothing Found - Next #10

																					} // If (rstRec2.BOF = True) And (rstRec2.EOF = True) Then ' Nothing Found - Next #9.5 ADDED 4/28/2014

																				} // If (rstRec2.BOF = True) And (rstRec2.EOF = True) Then ' Nothing Found - Next #9

																			} // If (rstRec2.BOF = True) And (rstRec2.EOF = True) Then ' Nothing Found - Next #8b

																		} // If (rstRec2.BOF = True) And (rstRec2.EOF = True) Then ' Nothing Found - Next #8a

																	} // If (rstRec2.BOF = True) And (rstRec2.EOF = True) Then ' Nothing Found - Next #7.5 Certificate Holder

																} // If (rstRec2.BOF = True) And (rstRec2.EOF = True) Then ' Nothing Found - Next #7

															} // If (rstRec2.BOF = True) And (rstRec2.EOF = True) Then ' Nothing Found - Next #6

														} // If (rstRec2.BOF = True) And (rstRec2.EOF = True) Then ' Nothing Found - Next #5b

													} // If (rstRec2.BOF = True) And (rstRec2.EOF = True) Then ' Nothing Found - Next #5a

												} // If (rstRec2.BOF = True) And (rstRec2.EOF = True) Then ' Nothing Found - Next #4

											} // If (rstRec2.BOF = True) And (rstRec2.EOF = True) Then ' Nothing Found - Next #3

										} // If (rstRec2.BOF = True) And (rstRec2.EOF = True) Then ' Nothing Found - Next #2b

									} // If (rstRec2.BOF = True) And (rstRec2.EOF = True) Then ' Nothing Found - Next #2a

								} // If (rstRec2.BOF = True) And (rstRec2.EOF = True) Then ' No Records Found, Ok to Auto Update

								//-------------------------------------------
								// Check To See If Something Was Found
								//-------------------------------------------
								if (bFound)
								{
									if ((!rstRec2.BOF) && (!rstRec2.EOF))
									{
										rstRec2["cref_operator_flag"] = "Y";
										rstRec2.Update();

										//FIND WHO THE CURRENT OPERATING COMPANY IS - THE LAST ONE IS FOUND AT THE TOP
										temp_comp_id = Find_Operating_Company_ID(lACId, Convert.ToInt32(Double.Parse(lJournId.ToString())));

									}
								} // If bFound = True Then

							} // ' If (rstRec2.BOF = True) And (rstRec2.EOF = True) Then ' Nothing Manually Updated Nothing Found - Next #1

							rstRec2.Filter = ""; // Clear Filter

						} // If (rstRec2.BOF = False) And (rstRec2.EOF = False) Then ' Found Some Aircraft References

						rstRec2.Close();

					} // If bIsManualFlagSet = False Then

				} // If lJournId = 0 Then ' Only Current Aircraft

				rstRec2 = null;
				rstRec1 = null;

				FixCurrentOperator(lACId);
			}
			catch
			{

				modAdminCommon.Display_Error("SetOperatorFlag_Error:");
			}

		} // SetOperatorFlag

		internal static bool FixJournalSubject(int inJournID)
		{

			bool result = false;
			string Query = "";
			ADORecordSetHelper snpSubCat = new ADORecordSetHelper();
			ADORecordSetHelper snpCategory = new ADORecordSetHelper();
			string NewSubject = "";

			try
			{
				NewSubject = "";

				result = false;

				Query = $"SELECT journ_subcategory_code FROM Journal WITH(NOLOCK) WHERE journ_id = {inJournID.ToString()}";
				snpSubCat.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpSubCat.BOF && snpSubCat.EOF))
				{

					if (modCommon.Validate_Trans_Type(($"{Convert.ToString(snpSubCat["journ_subcategory_code"])}").Trim()))
					{

						Query = "SELECT journ_subcategory_code, jcat_category_code, jcat_auto_subject_flag";
						Query = $"{Query} FROM Journal WITH(NOLOCK), Journal_Category WITH(NOLOCK)";
						Query = $"{Query} WHERE journ_id = {inJournID.ToString()}";
						Query = $"{Query} AND journ_subcategory_code = jcat_subcategory_code";

						snpCategory.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

						if (!(snpCategory.BOF && snpCategory.EOF))
						{

							if (($"{Convert.ToString(snpCategory["jcat_category_code"])}").Trim() == "AH" && ($"{Convert.ToString(snpCategory["jcat_auto_subject_flag"])}").Trim() == "Y")
							{
								NewSubject = modCommon.BuildJournalSubject(($"{Convert.ToString(snpCategory["journ_subcategory_code"])}").Trim(), frm_Journal.DefInstance.GetACRefCompID(inJournID, "1"), inJournID, frm_Journal.DefInstance.GetACRefCompID(inJournID, "10"), inJournID);
							}
							snpCategory.Close();

						}

						snpCategory = null;

					}

				}

				if (NewSubject.Trim() != modGlobalVars.cEmptyString)
				{

					Query = $"UPDATE Journal SET journ_subject = '{modAdminCommon.Fix_Quote(NewSubject)}' WHERE journ_id = {inJournID.ToString()}";

					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();

					result = true;

				}

				return result;
			}
			catch (System.Exception excep)
			{


				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"FixJournalSubject_Error ({Information.Err().Number.ToString()}) {excep.Message}", "Aircraft (modAircraft)");
				return result;
			}
		}
		internal static object delete_and_insert_hotbox(ref int InsertJournID, ref int AC_ID)
		{
			// CREATED MSW - 4/6/2012 - THIS WILL TAKE THE JOURNALS AND DELETE AND RE-INSERT
			// THEM INTO HOT BOX - WAS ORIGINAL INSDIE OF ANOTHER SECTION, CREATED AS COMMON
			// SO THAT EVERYONE CA
			try
			{


				string HotQuery = "";
				string del_query = "";

				del_query = "delete from Hot_Box_Summary ";
				if (InsertJournID > 0)
				{
					del_query = $"{del_query} Where hbs_journ_id = {InsertJournID.ToString()} ";
				}
				else if (AC_ID > 0)
				{ 
					del_query = $"{del_query} Where hbs_ac_id = {AC_ID.ToString()} ";
				}

				if ((InsertJournID > 0) || (AC_ID > 0))
				{
					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = del_query;
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();
					AC_ID = AC_ID;
					InsertJournID = InsertJournID;
				}

				// RTW - MODIFIED - 2/15/2012 - TO INSERT ENTRY INTO HOT BOX TABLE
				HotQuery = "INSERT INTO Hot_Box_Summary";
				// Journal Information
				HotQuery = $"{HotQuery}(hbs_entry_date,hbs_ac_id,hbs_journ_id,hbs_user_id,hbs_subject,hbs_description,hbs_status,";
				// AC Make/Model Information
				HotQuery = $"{HotQuery}hbs_amod_id, hbs_airframe_type_code,hbs_type_code,hbs_make_name,hbs_model_name,hbs_ser_no_full,";
				HotQuery = $"{HotQuery}hbs_reg_no,hbs_ac_product_business_flag,hbs_ac_product_helicopter_flag,hbs_ac_product_commercial_flag,";
				// Company Information
				HotQuery = $"{HotQuery}hbs_comp_id,hbs_comp_name,hbs_comp_account_id,hbs_contact_id) ";

				HotQuery = $"{HotQuery}SELECT ";
				//Journal Information
				HotQuery = $"{HotQuery}(CAST(CAST(journ_entry_date AS Date) AS DATETIME) + CAST(CAST(journ_entry_time AS Time) AS DATETIME)),";
				HotQuery = $"{HotQuery}journ_ac_id,";
				HotQuery = $"{HotQuery}journ_id,";
				HotQuery = $"{HotQuery}journ_user_id,";
				HotQuery = $"{HotQuery}journ_subject,";
				HotQuery = $"{HotQuery}journ_description,";
				HotQuery = $"{HotQuery}journ_status,";
				// Make/Model Information
				HotQuery = $"{HotQuery}amod_id,";
				HotQuery = $"{HotQuery}amod_airframe_type_code,";
				HotQuery = $"{HotQuery}amod_type_code,";
				HotQuery = $"{HotQuery}amod_make_name,";
				HotQuery = $"{HotQuery}amod_model_name,";
				HotQuery = $"{HotQuery}ac_ser_no_full,";
				HotQuery = $"{HotQuery}ac_reg_no,";
				HotQuery = $"{HotQuery}ac_product_business_flag,";
				HotQuery = $"{HotQuery}ac_product_helicopter_flag,";
				HotQuery = $"{HotQuery}ac_product_commercial_flag,";
				// Company Information
				HotQuery = $"{HotQuery}comp_id,";
				HotQuery = $"{HotQuery}comp_name,";
				HotQuery = $"{HotQuery}comp_account_id,";
				HotQuery = $"{HotQuery}cref_contact_id ";
				HotQuery = $"{HotQuery}From Journal ";
				HotQuery = $"{HotQuery}INNER JOIN Aircraft ON journ_ac_id = ac_id AND ac_journ_id = 0 ";
				HotQuery = $"{HotQuery}INNER JOIN Aircraft_Model ON ac_amod_id = amod_id ";
				HotQuery = $"{HotQuery}INNER JOIN Aircraft_Reference ON ac_id = cref_ac_id AND cref_journ_id = 0 ";
				HotQuery = $"{HotQuery}INNER JOIN Company ON cref_comp_id = comp_id AND comp_journ_id = 0 ";
				if (InsertJournID > 0)
				{
					HotQuery = $"{HotQuery}WHERE (journ_id={InsertJournID.ToString()}) ";
				}
				else if (AC_ID > 0)
				{ 
					HotQuery = $"{HotQuery}WHERE (journ_ac_id={AC_ID.ToString()}) ";
				}

				HotQuery = $"{HotQuery}and (journ_subcategory_code='RA')";

				if ((InsertJournID > 0) || (AC_ID > 0))
				{
					DbCommand TempCommand_2 = null;
					TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
					TempCommand_2.CommandText = HotQuery;
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
					TempCommand_2.ExecuteNonQuery();
					AC_ID = AC_ID;
					InsertJournID = InsertJournID;
				}
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"delete_and_insert_hotbox_error: {Information.Err().Number.ToString()} {excep.Message} ");
			}

			return null;
		}

		internal static void Return_Aircraft_Exclusive_Broker_CompName_CompId_ContactId(int lACId, ref string strCompName, ref int lCompId, ref int lContactId)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			try
			{

				strCompName = "";
				lCompId = 0;
				lContactId = 0;

				if (lACId > 0)
				{

					// Get Exclusive Broker CompId And Contact Id
					strQuery1 = "SELECT TOP 1 comp_name, cref_comp_id, cref_contact_id FROM Aircraft_Reference WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1}INNER JOIN Company WITH (NOLOCK) ON comp_id = cref_comp_id AND comp_journ_id = cref_journ_id ";
					strQuery1 = $"{strQuery1}WHERE (cref_ac_id = {lACId.ToString()}) AND (cref_journ_id = 0) ";
					strQuery1 = $"{strQuery1}AND cref_contact_type IN ('99','93')  ORDER BY cref_transmit_seq_no ";

					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!rstRec1.BOF && !rstRec1.EOF)
					{
						strCompName = ($"{Convert.ToString(rstRec1["comp_name"])} ").Trim();
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["cref_comp_id"]))
						{
							lCompId = Convert.ToInt32(rstRec1["cref_comp_id"]);
						}
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["cref_contact_id"]))
						{
							lContactId = Convert.ToInt32(rstRec1["cref_contact_id"]);
						}
					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

				} // If lACId > 0 Then

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Return_Aircraft_Exclusive_Broker_CompName_CompId_ContactId_Error", excep.Message);
			}

		} // Return_Aircraft_Exclusive_Broker_CompName_CompId_ContactId

		internal static void FixCurrentOperator(int inACID)
		{

			ADORecordSetHelper snpOpCheck = new ADORecordSetHelper();

			// GET THE CURRENT OPERATOR(COMPANY ID) FOR THE AIRCRAFT
			string strQuery = "Select top 1 cref_comp_id from Aircraft_Reference with (NOLOCK) ";
			strQuery = $"{strQuery} WHERE cref_journ_id = 0 and cref_operator_flag in ('Y','O') ";
			strQuery = $"{strQuery} AND cref_ac_id = {inACID.ToString()}";

			snpOpCheck.Open(strQuery, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

			ADORecordSetHelper snpHistCheck = null;
			if (!(snpOpCheck.BOF && snpOpCheck.EOF))
			{

				snpHistCheck = new ADORecordSetHelper();

				// CHECK TO SEE IF THE CURRENT OPERATOR IS ALSO THE LAST RECORD IN THE HISTORY TABLE
				strQuery = "SELECT acomprole_comp_id from Aircraft_Company_Role WITH (NOLOCK) ";
				strQuery = $"{strQuery}WHERE (acomprole_ac_id = {inACID.ToString()}) ";
				strQuery = $"{strQuery}and acomprole_end_date is NULL ";
				strQuery = $"{strQuery} AND acomprole_type = 1 ";
				strQuery = $"{strQuery}and (acomprole_comp_id = {Convert.ToString(snpOpCheck["cref_comp_id"])}) ";

				snpHistCheck.Open(strQuery, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpHistCheck.BOF && snpHistCheck.EOF))
				{

				}
				else
				{

					// IF THE LAST HISTORY RECORD THAT DOES NOT MATCH THE OPERATOR HAS A START DATE OF TODAY THEN JUST REMOVE IT
					strQuery = "DELETE FROM  Aircraft_Company_Role ";
					strQuery = $"{strQuery}WHERE (acomprole_ac_id = {inACID.ToString()}) ";
					strQuery = $"{strQuery}and acomprole_end_date is NULL ";
					strQuery = $"{strQuery} AND acomprole_type = 1 ";
					strQuery = $"{strQuery}and acomprole_START_date = '{DateTimeHelper.ToString(DateTime.Now)}'";

					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = strQuery;
					TempCommand.CommandType = CommandType.Text;
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();


					strQuery = $"Update Aircraft_Company_Role set acomprole_end_date = '{DateTimeHelper.ToString(DateTime.Now.AddDays(-1))}' ";
					strQuery = $"{strQuery}WHERE (acomprole_ac_id = {inACID.ToString()}) ";
					strQuery = $"{strQuery}and acomprole_end_date is NULL AND acomprole_type = 1 ";

					DbCommand TempCommand_2 = null;
					TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
					TempCommand_2.CommandText = strQuery;
					TempCommand_2.CommandType = CommandType.Text;
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
					TempCommand_2.ExecuteNonQuery();

					strQuery = "Insert into Aircraft_Company_Role (acomprole_ac_id, acomprole_journ_id, acomprole_comp_id, acomprole_type,acomprole_start_date, acomprole_end_date, acomprole_notes,acomprole_user_id) ";
					strQuery = $"{strQuery}Values (";
					strQuery = $"{strQuery}{inACID.ToString()}, "; // ACID
					strQuery = $"{strQuery}0,"; // JOURN ID
					strQuery = $"{strQuery}{Convert.ToString(snpOpCheck["cref_comp_id"])},"; // COMPANY ID
					strQuery = $"{strQuery}1,"; // TYPE
					strQuery = $"{strQuery}'{DateTimeHelper.ToString(DateTime.Now)}',"; // START DATE
					strQuery = $"{strQuery}NULL,"; // END DATE
					strQuery = $"{strQuery}'HOMEBASE',"; // NOTES
					strQuery = $"{strQuery}'mvit')"; // USER ID

					DbCommand TempCommand_3 = null;
					TempCommand_3 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_3);
					TempCommand_3.CommandText = strQuery;
					TempCommand_3.CommandType = CommandType.Text;
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_3);
					TempCommand_3.ExecuteNonQuery();

					modAdminCommon.Insert_Job("Update Aircraft Company Roles", inACID);


				} // CHECK ON HISTORY RECORD

				snpHistCheck = null;

			} // END IF CURRENT OPERATOR CHECK

		}
	}
}