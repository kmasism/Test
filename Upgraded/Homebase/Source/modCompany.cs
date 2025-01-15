using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Gui.Controls;
using UpgradeHelpers.Helpers;
using UpgradeStubs;

namespace JETNET_Homebase
{
	internal static class modCompany
	{



		internal static void update_company_callback_date(int inCompany_ID, string inStatus)
		{

			string Query = modGlobalVars.cEmptyString;
			string NextVerifyDate = modGlobalVars.cEmptyString;
			bool bStartTrans = false;

			try
			{

				if (inCompany_ID == 0)
				{
					return;
				}

				// if we are not in a transaction and start one
				if (modAdminCommon.ADO_Transaction("CheckStatus") == 0)
				{
					modAdminCommon.ADO_Transaction("BeginTrans");
					bStartTrans = true;
				}

				// 6/13/03 - RTW - ADDED ABILITY TO PASS OPTIONAL STRING IF CALLBACK SET TO ONE DAY FOR UNCONFIRMED STATUS
				if (inStatus.Trim().ToLower() == "unconfirmed")
				{
					NextVerifyDate = DateTimeHelper.ToString(DateTime.Parse(DateTimeHelper.ToString(DateTime.Now)).AddDays(1));
					// 6/13/03 - RTW - MODIFIED THIS TO ADO UPDATE
					Query = $"UPDATE Company SET comp_account_callback_date = '{NextVerifyDate.Trim()}'";
					Query = $"{Query} WHERE comp_id = {inCompany_ID.ToString()} AND comp_journ_id = 0";

					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand.CommandType = (CommandType) (((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()) + ((int) CommandType.Text));
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();

				}
				else
				{

					Query = $"EXEC HomebaseUpdateCompanyCallbackDate {inCompany_ID.ToString()}";

					DbCommand TempCommand_2 = null;
					TempCommand_2 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
					TempCommand_2.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand_2.CommandType = (CommandType) (((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()) + ((int) CommandType.Text));
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
					TempCommand_2.ExecuteNonQuery();

				}

				// if we were in a transaction then commit it if we started it
				if (modAdminCommon.ADO_Transaction("CheckStatus") == 1 && bStartTrans)
				{
					modAdminCommon.ADO_Transaction("CommitTrans");
				}
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Update_Company_Callback_Date_Error ({Information.Err().Number.ToString()}) {excep.Message} CMPID:[{inCompany_ID.ToString()}]", "Company (modCompany)");
				if (modAdminCommon.ADO_Transaction("CheckStatus") == 1 && bStartTrans)
				{
					modAdminCommon.ADO_Transaction("RollbackTrans");
				}
				return;
			}

		}

		internal static bool verify_company_change(int in_CompanyID, int in_JournalID, ref string[] arrTransmitFields, ref string[] arrVerifyFields, ref string[] arrChangedFields, modGlobalVars.t_company_save_phone_info tmpPhone, modGlobalVars.t_company_save_info tmpcompany, ref bool updated_compay_ticker)
		{

			bool result = false;
			string Query = modGlobalVars.cEmptyString;
			string sFldName = modGlobalVars.cEmptyString;
			string sFldValue = modGlobalVars.cEmptyString;
			bool bWasChange = false;
			ADORecordSetHelper ado_Verify_Company = new ADORecordSetHelper();


			try
			{

				Query = "SELECT *  , (select top 1 comp_ticker_symbol  from Company_Ticker with (NOLOCK) where comp_ticker_jetnet_comp_id = comp_id) as ticker_symbol";

				Query = $"{Query} FROM Company WITH (NOLOCK) WHERE (comp_id = {in_CompanyID.ToString()}) ";
				Query = $"{Query}AND (comp_journ_id = {in_JournalID.ToString()}) ";

				ado_Verify_Company.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!ado_Verify_Company.BOF && !ado_Verify_Company.EOF)
				{

					int tempForEndVar = ado_Verify_Company.FieldsMetadata.Count - 1;
					for (int nLoop = 0; nLoop <= tempForEndVar; nLoop++)
					{

						if (!Convert.IsDBNull(ado_Verify_Company[nLoop]))
						{ // only compaire aginst non null fields

							sFldName = ado_Verify_Company.GetField(nLoop).FieldMetadata.ColumnName.Trim();
							if (ADORecordSetHelper.GetDBType(ado_Verify_Company.GetField(nLoop).FieldMetadata.DataType) != DbType.Decimal)
							{ // ok this a non numeric field compair aginst empty string
								sFldValue = Convert.ToString(ado_Verify_Company[nLoop]).Trim();
							}
							else
							{
								sFldValue = Convert.ToString(ado_Verify_Company[nLoop]);
							}

						}
						else
						{
							// if field is null

							sFldName = ado_Verify_Company.GetField(nLoop).FieldMetadata.ColumnName.Trim();
							if (ADORecordSetHelper.GetDBType(ado_Verify_Company.GetField(nLoop).FieldMetadata.DataType) != DbType.Decimal)
							{ // ok this a non numeric field compair aginst empty string
								sFldValue = modGlobalVars.cEmptyString;
							}
							else
							{
								sFldValue = "0";
							}

						} // Not IsNull(ado_Verify_Company.fields(nLoop))


						switch(sFldName)
						{
							case "comp_name" : 
								if (sFldValue.Trim() != tmpcompany.s_comp_name.Trim())
								{
									bWasChange = true;
								} 
								 
								break;
							case "comp_name_alt_type" : 
								if (sFldValue.Trim() != tmpcompany.s_comp_name_alt_type.Trim())
								{
									bWasChange = true;
								} 
								 
								break;
							case "comp_name_alt" : 
								if (sFldValue.Trim() != tmpcompany.s_comp_name_alt.Trim())
								{
									bWasChange = true;
								} 
								 
								break;
							case "comp_address1" : 
								if (sFldValue.Trim() != tmpcompany.s_comp_address1.Trim())
								{
									bWasChange = true;
								} 
								 
								break;
							case "comp_address2" : 
								if (sFldValue.Trim() != tmpcompany.s_comp_address2.Trim())
								{
									bWasChange = true;
								} 
								 
								break;
							case "comp_city" : 
								if (sFldValue.Trim() != tmpcompany.s_comp_city.Trim())
								{
									bWasChange = true;
								} 
								 
								break;
							case "comp_state" : 
								if (sFldValue.Trim() != tmpcompany.s_comp_state.Trim())
								{
									bWasChange = true;
								} 
								 
								break;
							case "comp_country" : 
								if (sFldValue.Trim() != tmpcompany.s_comp_country.Trim())
								{
									bWasChange = true;
								} 
								 
								break;
							case "comp_zip_code" : 
								if (sFldValue.Trim() != tmpcompany.s_comp_zip_code.Trim())
								{
									bWasChange = true;
								} 
								 
								break;
							case "comp_timezone" : 
								if (sFldValue.Trim() != tmpcompany.s_comp_timezone.Trim())
								{
									bWasChange = true;
								} 
								 
								break;
							case "comp_language" : 
								if (sFldValue.Trim() != tmpcompany.s_comp_language.Trim())
								{
									bWasChange = true;
								} 
								 
								break;
							case "comp_web_address" : 
								if (sFldValue.Trim() != tmpcompany.s_comp_web_address.Trim())
								{
									bWasChange = true;
								} 
								 
								break;
							case "comp_email_address" : 
								if (sFldValue.Trim() != tmpcompany.s_comp_email_address.Trim())
								{
									bWasChange = true;
								} 
								 
								break;
							case "ticker_symbol" : 
								if (sFldValue.Trim() != tmpcompany.s_comp_ticker_symbol.Trim())
								{
									bWasChange = true;
									updated_compay_ticker = true;
								} 
								 
								break;
							case "comp_description" : 
								if (modAdminCommon.Fix_Quote(sFldValue).Trim() != tmpcompany.s_comp_description.Trim())
								{
									bWasChange = true;
								} 

								 
								break;
							case "comp_marketing_notes" : 
								if (modAdminCommon.Fix_Quote(sFldValue).Trim() != tmpcompany.s_comp_marketing_notes.Trim())
								{
									bWasChange = true;
								} 
								 
								break;
							case "comp_sic_code" : 
								if (sFldValue.Trim() != tmpcompany.s_comp_sic_code.Trim())
								{
									bWasChange = true;
								} 
								 
								break;
							case "comp_dunnandbrad" : 
								if (sFldValue.Trim() != tmpcompany.s_comp_dunnandbrad.Trim())
								{
									bWasChange = true;
								} 
								 
								break;
							case "comp_fractowr_contact_id" : 
								if (Convert.ToInt32(Conversion.Val(sFldValue.Trim())) != tmpcompany.s_comp_fractowr_contact_id)
								{
									bWasChange = true;
								} 
								 
								break;
							case "comp_fractowr_id" : 
								if (Convert.ToInt32(Conversion.Val(sFldValue.Trim())) != tmpcompany.s_comp_fractowr_id)
								{
									bWasChange = true;
								} 
								 
								break;
							case "comp_fractowr_notes" : 
								if (modAdminCommon.Fix_Quote(sFldValue).Trim() != tmpcompany.s_comp_fractowr_notes.Trim())
								{
									bWasChange = true;
								} 
								 
								break;
							case "comp_assign_flag" : 
								if (sFldValue.Trim() != tmpcompany.s_comp_assign_flag.Trim())
								{
									bWasChange = true;
								} 
								 
								break;
							case "comp_account_id" : 
								if (sFldValue.Trim() != tmpcompany.s_comp_account_id.Trim())
								{
									bWasChange = true;
								} 
								 
								break;
							case "comp_acpros_flag" : 
								if (sFldValue.Trim() != tmpcompany.s_comp_acpros_flag.Trim())
								{
									bWasChange = true;
								} 
								 
								break;
							case "comp_do_not_solicit" : 
								if (sFldValue.Trim() != tmpcompany.s_comp_do_not_solicit.Trim())
								{
									bWasChange = true;
								} 

								 
								break;
							case "comp_agency_type" : 
								if (sFldValue.Trim() != tmpcompany.s_comp_agency_type.Trim())
								{
									bWasChange = true;
								} 
								 
								break;
							case "comp_government_id" : 
								if (Convert.ToInt32(Conversion.Val(sFldValue.Trim())) != tmpcompany.s_comp_government_id)
								{
									bWasChange = true;
								} 
								 
								break;
							case "comp_business_type" : 
								if (sFldValue.Trim() != tmpcompany.s_comp_business_type.Trim())
								{
									bWasChange = true;
								} 
								 
								break;
							case "comp_account_type" : 
								if (sFldValue.Trim() != tmpcompany.s_comp_account_type.Trim())
								{
									bWasChange = true;
								} 
								 
								break;
							case "comp_account_callback_date" : 
								if (sFldValue.Trim() != tmpcompany.s_comp_account_callback_date.Trim())
								{
									bWasChange = true;
								} 
								 
								break;
							case "comp_abi_callback_date" : 
								if (sFldValue.Trim() != tmpcompany.s_comp_abi_callback_date.Trim())
								{
									bWasChange = true;
								} 
								 
								break;
							case "comp_secondary_callback" : 
								if (sFldValue.Trim() != tmpcompany.s_comp_secondary_callback.Trim())
								{
									if (DateTime.Parse(sFldValue).ToString("d").Trim() != DateTime.Parse(tmpcompany.s_comp_secondary_callback.Trim()).ToString("d"))
									{
										bWasChange = true;
									}
								} 
								 
								// 06/18/2019 - By David D. Cruger; Added 
								break;
							case "comp_aport_id" : 
								if (sFldValue.Trim() != tmpcompany.s_comp_aport_id.ToString().Trim())
								{
									bWasChange = true;
								} 
								 
								break;
							case "comp_last_contact_date" : 
								if (sFldValue.Trim() != tmpcompany.s_comp_last_contact_date.Trim())
								{
									bWasChange = true;
								} 
								 
								break;
							case "comp_abi_last_contact_date" : 
								if (sFldValue.Trim() != tmpcompany.s_comp_abi_last_contact_date.Trim())
								{
									bWasChange = true;
								} 
								 
								break;
							case "comp_active_flag" : 
								if (sFldValue.Trim() != tmpcompany.s_comp_active_flag.Trim())
								{
									bWasChange = true;
								} 
								 
								break;
							case "comp_hide_flag" : 
								if (sFldValue.Trim() != tmpcompany.s_comp_hide_flag.Trim())
								{
									bWasChange = true;
								} 
								 
								break;
							case "comp_product_business_flag" : 
								if (sFldValue.Trim() != tmpcompany.s_comp_product_business_flag.Trim())
								{
									bWasChange = true;
								} 
								 
								break;
							case "comp_product_commercial_flag" : 
								if (sFldValue.Trim() != tmpcompany.s_comp_product_commercial_flag.Trim())
								{
									bWasChange = true;
								} 
								 
								break;
							case "comp_product_helicopter_flag" : 
								if (sFldValue.Trim() != tmpcompany.s_comp_product_helicopter_flag.Trim())
								{
									bWasChange = true;
								} 
								 
								break;
							case "comp_product_airbp_flag" : 
								if (sFldValue.Trim() != tmpcompany.s_comp_product_airbp_flag.Trim())
								{
									bWasChange = true;
								} 
								 
								break;
							case "comp_product_abi_flag" : 
								if (sFldValue.Trim() != tmpcompany.s_comp_product_abi_flag.Trim())
								{
									bWasChange = true;
								} 
								 
								break;
							case "comp_marketing_rep" : 
								if (($"{sFldValue} ").Trim() != ($"{tmpcompany.s_comp_marketing_rep} ").Trim())
								{
									bWasChange = true;
								} 
								 
								// 02/22/2018 - By David D. Cruger; Added 
								break;
							case "comp_line_access_code" : 
								if (($"{sFldValue} ").Trim() != ($"{tmpcompany.s_comp_line_access_code} ").Trim())
								{
									bWasChange = true;
								} 
								 
								// 02/19/2016 - By David D. Cruger; Added 
								break;
							case "comp_contact_address_flag" : 
								if (sFldValue.Trim() != tmpcompany.s_comp_contact_address_flag.Trim())
								{
									bWasChange = true;
								} 
								 
								break;
						} // Select Case sFldName

						if (bWasChange)
						{

							result = true;
							bWasChange = false;

							//Call MsgBox("FLD:[" & sFldName & "] VAL:[" & sFldValue & "] CHG:[" & UCase$(CStr(bWasChange)) & "]", vbOKOnly, "VERIFY COMPANY CHANGE")

							if (!modCompany.has_item_been_added(sFldName, arrChangedFields))
							{
								modCompany.add_items_to_array_fields(ref arrChangedFields, sFldName);
							}

							switch(ado_Verify_Company.GetField(nLoop).FieldMetadata.ColumnName.Trim())
							{
								case "comp_name" : case "comp_city" : case "comp_state" : case "comp_zip_code" : case "comp_timezone" : case "comp_country" : 
									if (!modCompany.has_item_been_added(ado_Verify_Company.GetField(nLoop).FieldMetadata.ColumnName.Trim(), arrTransmitFields))
									{
										modCompany.add_items_to_array_fields(ref arrTransmitFields, ado_Verify_Company.GetField(nLoop).FieldMetadata.ColumnName.Trim());
									} 
									 
									break;
								case "comp_address1" : case "comp_address2" : case "comp_web_address" : 
									 
									if (ado_Verify_Company.GetField(nLoop).FieldMetadata.ColumnName.Trim() == "comp_address1")
									{ // Or Trim$(ado_Verify_Company.fields(nLoop).Name) = "comp_address2"

										if (!modCompany.has_item_been_added("comp_address", arrTransmitFields))
										{
											modCompany.add_items_to_array_fields(ref arrTransmitFields, "comp_address");
										}
										if (!modCompany.has_item_been_added("comp_address", arrVerifyFields))
										{
											modCompany.add_items_to_array_fields(ref arrVerifyFields, "comp_address");
										}

									}
									else
									{

										if (!modCompany.has_item_been_added(ado_Verify_Company.GetField(nLoop).FieldMetadata.ColumnName.Trim(), arrTransmitFields))
										{
											modCompany.add_items_to_array_fields(ref arrTransmitFields, ado_Verify_Company.GetField(nLoop).FieldMetadata.ColumnName.Trim());
										}
										if (!modCompany.has_item_been_added(ado_Verify_Company.GetField(nLoop).FieldMetadata.ColumnName.Trim(), arrVerifyFields))
										{
											modCompany.add_items_to_array_fields(ref arrVerifyFields, ado_Verify_Company.GetField(nLoop).FieldMetadata.ColumnName.Trim());
										}

									} 
									 
									break;
								case "comp_email_address" : 
									// added to transmit company (transmit uses contact_email to transmit) email address if company changed 
									if (!modCompany.has_item_been_added("contact_email_address", arrTransmitFields))
									{
										modCompany.add_items_to_array_fields(ref arrTransmitFields, "contact_email_address");
									} 
									if (!modCompany.has_item_been_added("comp_email_address", arrVerifyFields))
									{
										modCompany.add_items_to_array_fields(ref arrVerifyFields, "comp_email_address");
									} 
									if (!modCompany.has_item_been_added(ado_Verify_Company.GetField(nLoop).FieldMetadata.ColumnName.Trim(), arrVerifyFields))
									{
										modCompany.add_items_to_array_fields(ref arrVerifyFields, ado_Verify_Company.GetField(nLoop).FieldMetadata.ColumnName.Trim());
									} 
									 
									break;
							}
						} // bWasChange

					}

					if (tmpPhone.company_phone1_changed_flag)
					{
						result = true;
						if (!modCompany.has_item_been_added("contact_phone1", arrTransmitFields))
						{
							modCompany.add_items_to_array_fields(ref arrTransmitFields, "contact_phone1");
						}
					}

					if (tmpPhone.company_phone2_changed_flag)
					{
						result = true;
						if (!modCompany.has_item_been_added("contact_phone2", arrTransmitFields))
						{
							modCompany.add_items_to_array_fields(ref arrTransmitFields, "contact_phone2");
						}
					}

					ado_Verify_Company.Close();

				}
				else
				{

					MessageBox.Show("Company Record Does Not Exist!", "Company : Verify Company Change", MessageBoxButtons.OK, MessageBoxIcon.Error);

				} //Not IsNull(ado_Verify_Company) And Not (ado_Verify_Company.BOF And ado_Verify_Company.EOF) Then

				ado_Verify_Company = null;

				return result;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"verify_company_change_Error ({Information.Err().Number.ToString()}) {excep.Message}", "Company (modCompany)");
				return result;
			}
		} // verify_company_change

		internal static bool save_company(int in_CompanyID, int in_JournalID, string inSQLUpdate, string inHistoricalDate, CheckState inDontConfirmFlag, bool bUserChangedCallbackDate, bool bWereSpacesStrippedFromName, bool bActiveFlag, bool bHideFlag, UpgradeHelpers.DataGridViewFlex inWantedGrd, ref string[] arrTransmitFields, ref string[] arrVerifyFields, ref string[] arrChangedFields, modGlobalVars.t_company_save_phone_info tExitPhone, modGlobalVars.t_company_save_info tEnterCompany, modGlobalVars.t_company_save_info tExitCompany, ref string sReturnValue, string address_change_text, ref bool updated_compay_ticker)
		{


			bool result = false;
			string Query = modGlobalVars.cEmptyString;
			//Dim bBuildSubject As Boolean: bBuildSubject = True
			bool bCompanyNameChange = false;
			bool bOnlyChangeIsSpaces = false;
			string strEMailBody = modGlobalVars.cEmptyString;
			string strEMailTo = modGlobalVars.cEmptyString;
			string strSubject = modGlobalVars.cEmptyString;
			string strBody = modGlobalVars.cEmptyString;
			string sFormalNameChangeDate = modGlobalVars.cEmptyString;
			string sTmpChangedFields = modGlobalVars.cEmptyString;
			int tmpWantedID = 0;
			int tmpWantedAmodID = 0;
			int nRememberJournID = 0;
			ADORecordSetHelper adoFixJournSubject = null;
			string sTempQry = modGlobalVars.cEmptyString;
			string CheckProdQuery = ""; //USED FOR QUERY TO CHECK IF THIS COMPANY HAS AIRCRAFT FOR A GIVEN PRODUCT CODE
			bool bResults = false;
			string strErrMsg = "";
			bool bSubscription = false;
			int lSubId = 0;
			int lParentId = 0;

			// ADDED BY RTW - AS FLAG TO INDICATE IF THE USE DECIDES TO ACTIVATE CONTACTS WHEN ACTIVATING A COMPANY
			bool ActivateContacts = false;

			// ADDED BY RTW - AS FLAG TO INDICATE IF THE USE DECIDES TO INACTIVATE CONTACTS WHEN INACTIVATING A COMPANY
			bool InActivateContacts = false;

			// ADDED BY RTW - AS FLAG TO INDICATE IF THE USE DECIDES TO HIDE CONTACTS WHEN HIDING A COMPANY
			bool HiddenContacts = false;


			sReturnValue = "";

			try
			{

				modAdminCommon.Record_Event("Monitor Activity", "Save Company", 0, in_JournalID, in_CompanyID, false, 0, 0);
				//Record_Event "User Action", "Save Company", 0, in_JournalID, in_CompanyID, False, 0, 0

				if (verify_company_change(in_CompanyID, in_JournalID, ref arrTransmitFields, ref arrVerifyFields, ref arrChangedFields, tExitPhone, tExitCompany, ref updated_compay_ticker))
				{

					if (bWereSpacesStrippedFromName)
					{
						if (String.Compare(strip_spaces_from_companyname(tEnterCompany.s_comp_name), tExitCompany.s_comp_name, true) == 0)
						{
							bOnlyChangeIsSpaces = true;
						}
					}

					bSubscription = modCommon.Does_Company_Have_An_Active_Subscription(in_CompanyID, ref lSubId, ref lParentId);

					if (in_JournalID == 0 && (tEnterCompany.s_comp_service == "J" || tEnterCompany.s_comp_service == "B" || tEnterCompany.s_comp_service == "E") || (bSubscription))
					{

						strEMailBody = "";
						strEMailTo = ($"{modCommon.DLookUp("aconfig_email_company_contact_chg", "Application_Configuration")}{modGlobalVars.cEmptyString}").Trim();
						//If gbl_User_ID = "mvit" Then
						//  strEMailTo = "david@jetnet.com"
						//End If

						if (!bOnlyChangeIsSpaces && String.Compare(tEnterCompany.s_comp_name, tExitCompany.s_comp_name, true) != 0)
						{
							strEMailBody = $"{strEMailBody}Company Name Changed From: {tEnterCompany.s_comp_name} to {tExitCompany.s_comp_name}{Environment.NewLine}";
						}

						if (tEnterCompany.s_comp_email_address != tExitCompany.s_comp_email_address)
						{
							strEMailBody = $"{strEMailBody}{Environment.NewLine} EMail Address Changed from: {tEnterCompany.s_comp_email_address} to {tExitCompany.s_comp_email_address}{Environment.NewLine}";
						}

						if (tEnterCompany.s_comp_address1 != tExitCompany.s_comp_address1)
						{
							strEMailBody = $"{strEMailBody}{Environment.NewLine}Address1 Changed From: {tEnterCompany.s_comp_address1} to {tExitCompany.s_comp_address1}{Environment.NewLine}";
						}

						if (tEnterCompany.s_comp_address2 != tExitCompany.s_comp_address2)
						{
							strEMailBody = $"{strEMailBody}{Environment.NewLine}Address2 Changed From: {tEnterCompany.s_comp_address2} to {tExitCompany.s_comp_address2}{Environment.NewLine}";
						}

						if (tEnterCompany.s_comp_city != tExitCompany.s_comp_city)
						{
							strEMailBody = $"{strEMailBody}{Environment.NewLine}City Changed From: {tEnterCompany.s_comp_city} to {tExitCompany.s_comp_city}{Environment.NewLine}";
						}

						if (tEnterCompany.s_comp_state != tExitCompany.s_comp_state)
						{
							strEMailBody = $"{strEMailBody}{Environment.NewLine}State Changed From: {tEnterCompany.s_comp_state} to {tExitCompany.s_comp_state}{Environment.NewLine}";
						}

						if (tEnterCompany.s_comp_zip_code != tExitCompany.s_comp_zip_code)
						{
							strEMailBody = $"{strEMailBody}{Environment.NewLine}Zip Code Changed From: {tEnterCompany.s_comp_zip_code} to {tExitCompany.s_comp_zip_code}{Environment.NewLine}";
						}

						if (tEnterCompany.s_comp_web_address != tExitCompany.s_comp_web_address)
						{
							strEMailBody = $"{strEMailBody}{Environment.NewLine}Website Changed From: {tEnterCompany.s_comp_web_address} to {tExitCompany.s_comp_web_address}{Environment.NewLine}";
						}

						if (strEMailBody.Trim() != "")
						{

							strSubject = $"Homebase Company Changes for {tEnterCompany.s_comp_name} [{in_CompanyID.ToString()}]";

							// 05/11/2017 - By David D. Cruger; Changed To Use EMail Queue
							// rather than directly sending email.

							bResults = modEmail.Simple_Insert_EMail_Queue_Record(strEMailTo, "", "", strSubject, strEMailBody, "", "N", "Open", "Homebase Company Change", "jetnet@jetnet.com", in_CompanyID, 0);

							if (bResults)
							{
								modEmail.Send_All_EMail_In_Queue(ref strErrMsg, in_CompanyID);
							}

							// 05/11/2017 - By David D. Cruger; Added Message Queue
							modCommon.Enter_Customer_Program_Message_Note("", strEMailTo, $"{strSubject}{Environment.NewLine}{strEMailBody}", lSubId, lParentId, in_CompanyID, 0);

						} // If Trim(strEMailBody) <> "" Then

						strEMailBody = "";

					} // If in_JournalID = 0 And (tEnterCompany.s_comp_service = "J" Or tEnterCompany.s_comp_service = "B" Or tEnterCompany.s_comp_service = "E") Or (bSubscription = True) Then

					// ramble through the changed fields array and display on status bar
					int tempForEndVar = arrChangedFields.GetUpperBound(0);
					for (int iLoop = 0; iLoop <= tempForEndVar; iLoop++)
					{

						if (arrChangedFields[iLoop].Trim() != modGlobalVars.cEmptyString)
						{
							if (iLoop == 0)
							{
								sTmpChangedFields = arrChangedFields[iLoop];
							}
							else
							{
								if ((arrChangedFields[iLoop].IndexOf(sTmpChangedFields, StringComparison.CurrentCultureIgnoreCase) + 1) == 0)
								{
									sTmpChangedFields = $"{sTmpChangedFields}, {arrChangedFields[iLoop]}";
								}
							}
						}

					}

					if (sTmpChangedFields.Trim() != modGlobalVars.cEmptyString)
					{
						modStatusBar.Update_Status_Bar(modAdminCommon.SB, sTmpChangedFields, Color.Blue);
					}

					if (MessageBox.Show("Do You Want to Save Company Changes?", "Company : Save Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
					{


						// check for business aircraft if business product code changes
						if (tEnterCompany.s_comp_product_business_flag == "Y" && tEnterCompany.s_comp_product_business_flag != tExitCompany.s_comp_product_business_flag)
						{

							// **************************************
							// VERIFY THAT COMPANY DOES NOT HAVE BUSINESS AIRCRAFT
							// MODIFIED - RTW - 1/5/2012
							CheckProdQuery = "SELECT cref_id FROM Aircraft WITH (NOLOCK)  INNER JOIN Aircraft_Reference WITH (NOLOCK) ON cref_ac_id = ac_id AND cref_journ_id = ac_journ_id ";
							CheckProdQuery = $"{CheckProdQuery}WHERE (cref_comp_id = {in_CompanyID.ToString()}) ";
							CheckProdQuery = $"{CheckProdQuery}AND (ac_product_business_flag = 'Y') ";

							if (modAdminCommon.Exist(CheckProdQuery))
							{
								MessageBox.Show("This Company has Business Aircraft - Business Product Code Can't be Removed", "Company : Business Product Code Change", MessageBoxButtons.OK, MessageBoxIcon.Error);
								sReturnValue = "has_B_Aircraft";
								return result;
							}

						}

						// check for commericial aircraft if commericial product code changes
						if (tEnterCompany.s_comp_product_commercial_flag == "Y" && tEnterCompany.s_comp_product_commercial_flag != tExitCompany.s_comp_product_commercial_flag)
						{

							// **************************************
							// VERIFY THAT COMPANY DOES NOT HAVE COMMERCIAL AIRCRAFT
							// MODIFIED - RTW - 1/5/2012
							CheckProdQuery = "SELECT cref_id FROM Aircraft WITH (NOLOCK) INNER JOIN Aircraft_Reference WITH (NOLOCK) ON cref_ac_id = ac_id and cref_journ_id = ac_journ_id ";
							CheckProdQuery = $"{CheckProdQuery}WHERE (cref_comp_id = {in_CompanyID.ToString()}) ";
							CheckProdQuery = $"{CheckProdQuery}AND (ac_product_commercial_flag = 'Y') ";

							if (modAdminCommon.Exist(CheckProdQuery))
							{
								MessageBox.Show("This Company has Commercial Aircraft - Commercial Product Code Can't be Removed", "Company : Commercial Product Code Change", MessageBoxButtons.OK, MessageBoxIcon.Error);
								sReturnValue = "has_C_Aircraft";
								return result;
							}

						}

						// check for helicopters if helicopters product code changes
						if (tEnterCompany.s_comp_product_helicopter_flag == "Y" && tEnterCompany.s_comp_product_helicopter_flag != tExitCompany.s_comp_product_helicopter_flag)
						{

							// **************************************
							// VERIFY THAT COMPANY DOES NOT HAVE HELICOPTER AIRCRAFT
							// MODIFIED - RTW - 1/5/2012

							CheckProdQuery = "SELECT cref_id FROM Aircraft WITH (NOLOCK) INNER JOIN Aircraft_Reference WITH (NOLOCK) ON cref_ac_id = ac_id AND cref_journ_id = ac_journ_id ";
							CheckProdQuery = $"{CheckProdQuery}WHERE (cref_comp_id = {in_CompanyID.ToString()}) ";
							CheckProdQuery = $"{CheckProdQuery}AND (ac_product_helicopter_flag = 'Y') ";

							if (modAdminCommon.Exist(CheckProdQuery))
							{
								MessageBox.Show("This Company has Helicopter(s) Aircraft - Helicopter Product Code Can't be Removed", "Company : Helicoopter Product Code Change", MessageBoxButtons.OK, MessageBoxIcon.Error);
								sReturnValue = "has_H_Aircraft";
								return result;
							}

						}


						if (tEnterCompany.s_comp_product_business_flag != tExitCompany.s_comp_product_business_flag)
						{
							modAdminCommon.Record_Event("Company Product Code Changed", $"The Company Product Business Flag Has Changed From [{tEnterCompany.s_comp_product_business_flag}] To [{tExitCompany.s_comp_product_business_flag}]", 0, in_JournalID, in_CompanyID, false, 0, 0);
						}

						if (tEnterCompany.s_comp_product_commercial_flag != tExitCompany.s_comp_product_commercial_flag)
						{
							modAdminCommon.Record_Event("Company Product Code Changed", $"The Company Product Commercial Flag Has Changed From [{tEnterCompany.s_comp_product_commercial_flag}] To [{tExitCompany.s_comp_product_commercial_flag}]", 0, in_JournalID, in_CompanyID, false, 0, 0);
						}

						if (tEnterCompany.s_comp_product_helicopter_flag != tExitCompany.s_comp_product_helicopter_flag)
						{
							modAdminCommon.Record_Event("Company Product Code Changed", $"The Company Product Helicopter Flag Has Changed From [{tEnterCompany.s_comp_product_helicopter_flag}] To [{tExitCompany.s_comp_product_helicopter_flag}]", 0, in_JournalID, in_CompanyID, false, 0, 0);
						}

						if (tEnterCompany.s_comp_product_yacht_flag != tExitCompany.s_comp_product_yacht_flag)
						{
							modAdminCommon.Record_Event("Company Product Code Changed", $"The Company Product Yacht Flag Has Changed From [{tEnterCompany.s_comp_product_yacht_flag}] To [{tExitCompany.s_comp_product_yacht_flag}]", 0, in_JournalID, in_CompanyID, false, 0, 0);
						}

						if (tEnterCompany.s_comp_product_abi_flag != tExitCompany.s_comp_product_abi_flag)
						{
							modAdminCommon.Record_Event("Company Product Code Changed", $"The Company Product ABI Flag Has Changed From [{tEnterCompany.s_comp_product_abi_flag}] To [{tExitCompany.s_comp_product_abi_flag}]", 0, in_JournalID, in_CompanyID, false, 0, 0);
						}

						if (tEnterCompany.s_comp_product_airbp_flag != tExitCompany.s_comp_product_airbp_flag)
						{
							modAdminCommon.Record_Event("Company Product Code Changed", $"The Company Product AirBP Flag Has Changed From [{tEnterCompany.s_comp_product_airbp_flag}] To [{tExitCompany.s_comp_product_airbp_flag}]", 0, in_JournalID, in_CompanyID, false, 0, 0);
						}

						// 02/22/2018 - By David D. Cruger
						if (tEnterCompany.s_comp_line_access_code != tExitCompany.s_comp_line_access_code)
						{
							modAdminCommon.Record_Event("Company Access Line Code Changed", $"The Company Access Line Code Has Changed From [{tEnterCompany.s_comp_line_access_code}] To [{tExitCompany.s_comp_line_access_code}]", 0, in_JournalID, in_CompanyID, false, 0, 0);
						}

						// inactivate company and/or contacts
						if (tEnterCompany.s_comp_active_flag == "Y" && tEnterCompany.s_comp_active_flag != tExitCompany.s_comp_active_flag)
						{
							if (MessageBox.Show("Do you want the contacts inactivated also?", "Company : Inactivate Contacts", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
							{
								InActivateContacts = true;
							}
						}

						// activate company and/or contacts
						if (tEnterCompany.s_comp_active_flag == "N" && tEnterCompany.s_comp_active_flag != tExitCompany.s_comp_active_flag)
						{
							if (MessageBox.Show("Do you want the contacts activated also?", "Company : Activate Contacts", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
							{
								ActivateContacts = true;
							}
						}

						// hide company and/or contacts
						if (tEnterCompany.s_comp_hide_flag == "N" && tEnterCompany.s_comp_hide_flag != tExitCompany.s_comp_hide_flag)
						{
							if (MessageBox.Show("Do you want the contacts hidden also?", "Company : Hide Contacts", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
							{
								HiddenContacts = true;
							}
						}

						// ----------------------------------------------
						// CHECK FOR A COMPANY NAME CHANGE
						if (in_JournalID == 0 && !bOnlyChangeIsSpaces && String.Compare(tEnterCompany.s_comp_name, tExitCompany.s_comp_name, true) != 0)
						{

							// SET A FLAG FOR INDICATING THAT THE COMPANY NAME CHANGED FOR POSSIBLE CHANGES TO TRANSACTIONS BELOW
							bCompanyNameChange = true;

							//If the company name changed, ask if it's a formal change
							frm_PopUp.DefInstance.ComingFrom = "Company Name Change";
							frm_PopUp.DefInstance.Text = "Formal Name Change?";
							frm_PopUp.DefInstance.ShowDialog();

							sFormalNameChangeDate = frm_PopUp.DefInstance.CallbackDate;

							if (sFormalNameChangeDate.Trim().ToUpper() == "CANCEL")
							{
								MessageBox.Show("User Canceled Formal Name Change! Exiting Company Save!", "Company : Save Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
								//Call modAdminCommon.ADO_Transaction("RollbackTrans")
								sReturnValue = "canceled_F_namechange";
								return result;
							}
						} // COMPANY NAME CHANGE



						// BEGIN THE TRANSACTION
						modAdminCommon.ADO_Transaction("BeginTrans");
						modStatusBar.Clear_Status_Bar(modAdminCommon.SB);


						// INACTIVATE CONTACTS
						if (InActivateContacts)
						{
							Query = $"UPDATE Contact SET contact_active_flag = 'N' WHERE contact_comp_id = {in_CompanyID.ToString()}";
							Query = $"{Query} AND contact_journ_id = {in_JournalID.ToString()} AND contact_active_flag = 'Y'";
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

						// ACTIVATE CONTACTS
						if (ActivateContacts)
						{
							Query = $"UPDATE Contact SET contact_active_flag ='Y' WHERE contact_comp_id = {in_CompanyID.ToString()}";
							Query = $"{Query} AND contact_journ_id = {in_JournalID.ToString()} AND contact_active_flag = 'N'";
							DbCommand TempCommand_2 = null;
							TempCommand_2 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
							TempCommand_2.CommandText = Query;
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
							TempCommand_2.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
							TempCommand_2.ExecuteNonQuery();
						}

						// HIDE CONTACTS
						if (HiddenContacts)
						{
							Query = $"UPDATE Contact SET contact_hide_flag ='Y' WHERE contact_comp_id = {in_CompanyID.ToString()}";
							Query = $"{Query} AND contact_journ_id = {in_JournalID.ToString()} AND contact_hide_flag = 'N'";
							DbCommand TempCommand_3 = null;
							TempCommand_3 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_3);
							TempCommand_3.CommandText = Query;
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
							TempCommand_3.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_3);
							TempCommand_3.ExecuteNonQuery();
						}


						if (bUserChangedCallbackDate)
						{
							modAdminCommon.Record_Event("Manual Callback", "User manually changed the callback date.", 0, in_JournalID, in_CompanyID, false, 0, 0);
						}

						// DID THE COMPANY NAME CHANGE
						if (in_JournalID == 0 && !bOnlyChangeIsSpaces && String.Compare(tEnterCompany.s_comp_name, tExitCompany.s_comp_name, true) != 0)
						{

							//If it is a formal change, put away a history record and a journal note
							if (Information.IsDate(sFormalNameChangeDate))
							{

								modCommon.Transaction_Get_Company_History_Recordsets(in_CompanyID.ToString());

								modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(sFormalNameChangeDate);
								modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "CNAME";
								modAdminCommon.Rec_Journal_Info.journ_subject = $"Formally Changed Company Name from: {tEnterCompany.s_comp_name} to: {tExitCompany.s_comp_name}";
								modAdminCommon.Rec_Journal_Info.journ_description = modGlobalVars.cEmptyString;
								modAdminCommon.Rec_Journal_Info.journ_ac_id = 0;
								modAdminCommon.Rec_Journal_Info.journ_comp_id = in_CompanyID;
								modAdminCommon.Rec_Journal_Info.journ_contact_id = 0;
								modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
								modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
								modAdminCommon.Rec_Journal_Info.journ_status = "A";

								nRememberJournID = frm_Journal.DefInstance.Commit_Journal_Entry();

								if (nRememberJournID > 0)
								{

									modCommon.InsertPriorityEvent("CFNC", 0, nRememberJournID, $"From: {tEnterCompany.s_comp_name} to: {tExitCompany.s_comp_name}", in_CompanyID, 0, "Y");
									modCommon.Transaction_Save_Company_History(nRememberJournID, ref modGlobalVars.snp_Company, ref modGlobalVars.snp_Contacts, ref modGlobalVars.snp_Company_Phones, ref modGlobalVars.snp_Company_Btypes, ref modGlobalVars.snp_Company_Certs);

								}

								modAdminCommon.Record_Event("NameChange", $"Formal Name Change From:{tEnterCompany.s_comp_name} to: {tExitCompany.s_comp_name}", 0, in_JournalID, in_CompanyID, false, 0, 0);

								// Need to Send EMail to Therese if this is a customer with a formal name changed
								if (tEnterCompany.s_comp_service == "J" || tEnterCompany.s_comp_service == "B" || tEnterCompany.s_comp_service == "E")
								{

									strBody = $"A Homebase Customer Formal Name Change Has Taken Place{Environment.NewLine}{Environment.NewLine}" +
									          $"CompId           : {in_CompanyID.ToString()} has changed there name from. {Environment.NewLine}{Environment.NewLine}" +
									          $"Old Company Name : {tEnterCompany.s_comp_name}{Environment.NewLine}" +
									          $"  To  {Environment.NewLine}" +
									          $"New Company Name : {tExitCompany.s_comp_name}{Environment.NewLine}{Environment.NewLine}" +
									          $"Date/Time        : {DateTime.Now.ToString()}{Environment.NewLine}" +
									          $"By User          : {modAdminCommon.gbl_User_ID} " +
									          $"{Convert.ToString(modAdminCommon.snp_User["user_first_name"])} " +
									          $"{Convert.ToString(modAdminCommon.snp_User["user_last_name"])} " +
									          $"AcctId: {modAdminCommon.gbl_Account_ID} {Environment.NewLine}";

									if (strBody.Trim() != modGlobalVars.cEmptyString)
									{

										modEmail.EMail_Message("Homebase", "jetnet@jetnet.com", "therese@jetnet.com", modGlobalVars.cEmptyString, modGlobalVars.cEmptyString, "Homebase Customer Formal Name Change", strBody, "", false);

									} // strBody <> cEmptyString

								} // tEnterCompany.s_comp_service = "J" Or tEnterCompany.s_comp_service = "B" Or tEnterCompany.s_comp_service = "E" Then

							}
							else if (sFormalNameChangeDate.Trim() == modGlobalVars.cEmptyString)
							{ 

								//If it's not a formal name change, put away a journal entry

								modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTimeHelper.ToString(DateTime.Now));
								modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "CNAME";

								if (in_JournalID == 0 && inHistoricalDate.Trim() == modGlobalVars.cEmptyString)
								{ //if not historical and non-formal name change
									modAdminCommon.Rec_Journal_Info.journ_subject = $"Changed Company Name From: {tEnterCompany.s_comp_name} to: {tExitCompany.s_comp_name}";
								}
								else
								{
									// if historical , non-formal name change
									modAdminCommon.Rec_Journal_Info.journ_subject = $"Changed Historical Company Name ({inHistoricalDate}, JournalID: {in_JournalID.ToString()}) From: {tEnterCompany.s_comp_name} to: {tExitCompany.s_comp_name}";
								}

								modAdminCommon.Rec_Journal_Info.journ_description = modGlobalVars.cEmptyString;
								modAdminCommon.Rec_Journal_Info.journ_ac_id = 0;
								modAdminCommon.Rec_Journal_Info.journ_comp_id = in_CompanyID;
								modAdminCommon.Rec_Journal_Info.journ_contact_id = 0;

								modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
								modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
								modAdminCommon.Rec_Journal_Info.journ_status = "A";

								frm_Journal.DefInstance.Commit_Journal_Entry();

								modAdminCommon.Record_Event("NameChange", $"Non-Formal Name Change From: {tEnterCompany.s_comp_name} to: {tExitCompany.s_comp_name}", 0, in_JournalID, in_CompanyID, false, 0, 0);

							} // IsDate(FormalNameChangeDate) Then

						}
						else if (in_JournalID > 0 && !bOnlyChangeIsSpaces && String.Compare(tEnterCompany.s_comp_name, tExitCompany.s_comp_name, true) != 0)
						{ 

							// SET A FLAG FOR INDICATING THAT THE COMPANY NAME CHANGED FOR POSSIBLE CHANGES TO TRANSACTIONS BELOW
							bCompanyNameChange = true;

							//If there was a name change to a historical record put away a journal entry
							modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTimeHelper.ToString(DateTime.Now));
							modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "CNAME";

							if (in_JournalID == 0 && inHistoricalDate.Trim() == modGlobalVars.cEmptyString)
							{ //if not historical and non-formal name change
								modAdminCommon.Rec_Journal_Info.journ_subject = $"Changed Company Name From: {tEnterCompany.s_comp_name} to: {tExitCompany.s_comp_name}";
							}
							else
							{
								// if historical , non-formal name change
								modAdminCommon.Rec_Journal_Info.journ_subject = $"Changed Historical Company Name ({inHistoricalDate}, JournalID: {in_JournalID.ToString()}) From: {tEnterCompany.s_comp_name} to: {tExitCompany.s_comp_name}";
							}

							modAdminCommon.Rec_Journal_Info.journ_description = modGlobalVars.cEmptyString;
							modAdminCommon.Rec_Journal_Info.journ_ac_id = 0;
							modAdminCommon.Rec_Journal_Info.journ_comp_id = in_CompanyID;
							modAdminCommon.Rec_Journal_Info.journ_contact_id = 0;

							modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
							modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
							modAdminCommon.Rec_Journal_Info.journ_status = "A";

							frm_Journal.DefInstance.Commit_Journal_Entry();

							modAdminCommon.Record_Event("NameChange", $"Historical Name Change From: {tEnterCompany.s_comp_name} to: {tExitCompany.s_comp_name}", 0, in_JournalID, in_CompanyID, false, 0, 0);

						} // in_JournalID = 0 And Not bOnlyChangeIsSpaces And StrComp(tEnterCompany.s_comp_name, tExitCompany.s_comp_name, vbTextCompare) <> 0 Then

						if (in_JournalID == 0)
						{

							if (modCompany.has_item_been_added("comp_account_id", arrChangedFields))
							{
								insert_accountrep_change_journal_note(in_CompanyID, tEnterCompany.s_comp_account_id, tExitCompany.s_comp_account_id);
							}

						} // in_JournalID = 0

						// EXECUTE THE COMPANY UPDATE -------------------------

						DbCommand TempCommand_4 = null;
						TempCommand_4 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_4);
						TempCommand_4.CommandText = inSQLUpdate;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand_4.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_4);
						TempCommand_4.ExecuteNonQuery();

						if (arrChangedFields.GetUpperBound(0) > 0)
						{

							modCommon.Record_CompanyContact_Aircraft_Transmits("Company", "Change", in_CompanyID, 0, in_JournalID, ref arrTransmitFields, 0, "", tExitCompany.s_comp_fractowr_id.ToString()); // process transmits

							// loop through wanted grid and transmit wanteds
							if ((inWantedGrd.CurrentRowIndex > 0) && Convert.ToString(inWantedGrd[1, 1].Value).Trim().ToUpper() != ("No Wanted Aircraft Found").ToUpper() && Convert.ToString(inWantedGrd[1, 1].Value).Trim().ToUpper() != ("").ToUpper())
							{

								int tempForEndVar2 = inWantedGrd.RowsCount - 1;
								for (int iLoop = 1; iLoop <= tempForEndVar2; iLoop++)
								{

									tmpWantedID = inWantedGrd.get_RowData(iLoop);
									//UPGRADE_ISSUE: (2064) MSHierarchicalFlexGridLib.MSHFlexGrid property inWantedGrd.BandData was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
									tmpWantedAmodID = inWantedGrd.BandData(iLoop);

									// only transmit fixed wing wanteds
									Query = $"SELECT amod_id FROM Aircraft_Model WITH(NOLOCK) WHERE amod_id = {tmpWantedAmodID.ToString()} AND amod_airframe_type_code ='F'";

									if (modAdminCommon.Exist(Query))
									{
										modAdminCommon.Record_Transmit(modGlobalVars.cEmptyString, tmpWantedID, in_JournalID, Convert.ToInt32(Double.Parse(tmpWantedAmodID.ToString())), "Wanted", "Change", ref arrTransmitFields, in_CompanyID);
									}

								}

							}

						} // UBound(arrChangedFields) > 0

						if (inDontConfirmFlag == CheckState.Unchecked && in_JournalID == 0)
						{
							modCompany.auto_confirm_company_fields(in_CompanyID, arrVerifyFields, address_change_text);
						}


						// IF THE COMPANY NAME CHANGED AND A HISTORICAL COMPANY THEN TRY TO CHANGE THE JOURNAL SUBJECT
						if (bCompanyNameChange && in_JournalID > 0)
						{
							modCompany.build_journal_subject_fornamechange(in_JournalID);
						}


						// *****************************************************************************
						// COMMIT THE TRANSACTION
						modAdminCommon.ADO_Transaction("CommitTrans");

						result = true;
						sReturnValue = "success";
						modAdminCommon.Record_Event("Monitor Activity", "Save Company - Save Completed", 0, in_JournalID, in_CompanyID, false, 0, 0);
						//Record_Event "User Action", "Save Company - Save Completed", 0, in_JournalID, in_CompanyID, False, 0, 0

					}
					else
					{
						sReturnValue = "no_save";
						modAdminCommon.Record_Event("Monitor Activity", "Save Company - User Does Not Want To Save Changes", 0, in_JournalID, in_CompanyID, false, 0, 0);
					} // MsgBox("Do You Want to Save Company Changes?", vbQuestion + vbYesNo, "Company : Save Changes") = vbYes

				}
				else
				{
					sReturnValue = "no_changes";
					modAdminCommon.Record_Event("Monitor Activity", "Save Company - No Changes", 0, in_JournalID, in_CompanyID, false, 0, 0);
				} // modCompany.Verify_Company_Change
			}
			catch (System.Exception excep)
			{

				sReturnValue = "save_error";

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"save_company_Error ({Information.Err().Number.ToString()}) {excep.Message}", "Company (modCompany)");
				modAdminCommon.ADO_Transaction("RollbackTrans");
			}

			return result;
		} // save_company

		internal static bool check_company_phone_for_changes_user_input(int in_CompanyID, int in_JournalID, string txt_Country, string txt_Area, string txt_Prefix, string txt_Number, modGlobalVars.t_company_save_phone_info tmpPhone)
		{


			bool result = false;
			bool bHasChanged = false;


			string Query = $"SELECT * FROM Phone_Numbers WITH(NOLOCK), Phone_type WITH(NOLOCK) WHERE pnum_comp_id = {in_CompanyID.ToString()}";
			Query = $"{Query} AND pnum_type = ptype_name AND pnum_contact_id = 0";
			Query = $"{Query} AND pnum_journ_id = {in_JournalID.ToString()} ORDER BY ptype_seq_no, pnum_number_full";

			//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseClient);

			ADORecordSetHelper adoPhoneCheck = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, ""); //aey 6/14/04

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(adoPhoneCheck.Fields) && !(adoPhoneCheck.BOF && adoPhoneCheck.EOF))
			{

				while(!adoPhoneCheck.EOF)
				{
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(adoPhoneCheck["pnum_cntry_code"]))
					{
						if (Convert.ToString(adoPhoneCheck["pnum_cntry_code"]).Trim() != modGlobalVars.cEmptyString)
						{
							if (txt_Country.Trim() != Convert.ToString(adoPhoneCheck["pnum_cntry_code"]).Trim())
							{
								bHasChanged = true;
							}
						}
					}
					else
					{
						if (txt_Country.Trim() != "")
						{
							bHasChanged = true;
						}
					}

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(adoPhoneCheck["pnum_area_code"]))
					{
						if (Convert.ToString(adoPhoneCheck["pnum_area_code"]).Trim() != modGlobalVars.cEmptyString)
						{
							if (txt_Area.Trim() != Convert.ToString(adoPhoneCheck["pnum_area_code"]).Trim())
							{
								bHasChanged = true;
							}
						}
					}
					else
					{
						if (txt_Area.Trim() != "")
						{
							bHasChanged = true;
						}
					}

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(adoPhoneCheck["pnum_prefix"]))
					{
						if (Convert.ToString(adoPhoneCheck["pnum_prefix"]).Trim() != modGlobalVars.cEmptyString)
						{
							if (txt_Prefix.Trim() != Convert.ToString(adoPhoneCheck["pnum_prefix"]).Trim())
							{
								bHasChanged = true;
							}
						}
					}
					else
					{
						if (txt_Prefix.Trim() != "")
						{
							bHasChanged = true;
						}
					}

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(adoPhoneCheck["pnum_number"]))
					{
						if (Convert.ToString(adoPhoneCheck["pnum_number"]).Trim() != modGlobalVars.cEmptyString)
						{
							if (txt_Number.Trim() != Convert.ToString(adoPhoneCheck["pnum_number"]).Trim())
							{
								bHasChanged = true;
							}
						}
					}
					else
					{
						if (txt_Number.Trim() != "")
						{
							bHasChanged = true;
						}
					}

					if (bHasChanged)
					{
						bHasChanged = false;
						result = true;
					}

					adoPhoneCheck.MoveNext();
				};

				adoPhoneCheck.Close();

			} // Not IsNull(adoPhoneCheck) And Not (adoPhoneCheck.BOF And adoPhoneCheck.EOF)

			//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseServer);


			return result;
		}

		internal static bool check_company_phone_for_changes(int in_CompanyID, int in_JournalID, UpgradeHelpers.DataGridViewFlex inPhoneGrd, ref string[] arrTransmitFields, ref string[] arrVerifyFields, modGlobalVars.t_company_save_phone_info tmpPhone)
		{


			bool bHasChanged = false;

			string Query = "SELECT * FROM Phone_Numbers WITH (NOLOCK) ";
			Query = $"{Query}INNER JOIN Phone_type WITH (NOLOCK) ON ptype_name = pnum_type ";
			Query = $"{Query}WHERE (pnum_comp_id = {in_CompanyID.ToString()}) ";
			Query = $"{Query}AND (pnum_contact_id = 0) ";
			Query = $"{Query}AND (pnum_journ_id = {in_JournalID.ToString()}) ";
			Query = $"{Query}ORDER BY ptype_seq_no, pnum_number_full";

			//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseClient);

			ADORecordSetHelper adoPhoneCheck = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, ""); //aey 6/14/04

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(adoPhoneCheck.Fields) && !(adoPhoneCheck.BOF && adoPhoneCheck.EOF))
			{

				int tempForEndVar = inPhoneGrd.RowsCount - 1;
				for (int i = 1; i <= tempForEndVar; i++)
				{

					if (i > 2)
					{
						break;
					}

					inPhoneGrd.CurrentRowIndex = i;
					inPhoneGrd.CurrentColumnIndex = 0;

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(adoPhoneCheck["pnum_type"]))
					{
						if (Convert.ToString(adoPhoneCheck["pnum_type"]).Trim() != modGlobalVars.cEmptyString)
						{
							if (inPhoneGrd[inPhoneGrd.CurrentRowIndex, inPhoneGrd.CurrentColumnIndex].FormattedValue.ToString().Trim() != Convert.ToString(adoPhoneCheck["pnum_type"]).Trim())
							{
								bHasChanged = true;
							}
						}
					}
					else
					{
						if (inPhoneGrd[inPhoneGrd.CurrentRowIndex, inPhoneGrd.CurrentColumnIndex].FormattedValue.ToString().Trim() != "")
						{
							bHasChanged = true;
						}
					}

					inPhoneGrd.CurrentColumnIndex = 1;
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(adoPhoneCheck["pnum_cntry_code"]))
					{
						if (Convert.ToString(adoPhoneCheck["pnum_cntry_code"]).Trim() != modGlobalVars.cEmptyString)
						{
							if (inPhoneGrd[inPhoneGrd.CurrentRowIndex, inPhoneGrd.CurrentColumnIndex].FormattedValue.ToString().Trim() != Convert.ToString(adoPhoneCheck["pnum_cntry_code"]).Trim())
							{
								bHasChanged = true;
							}
						}
					}
					else
					{
						if (inPhoneGrd[inPhoneGrd.CurrentRowIndex, inPhoneGrd.CurrentColumnIndex].FormattedValue.ToString().Trim() != "")
						{
							bHasChanged = true;
						}
					}

					inPhoneGrd.CurrentColumnIndex = 2;
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(adoPhoneCheck["pnum_area_code"]))
					{
						if (Convert.ToString(adoPhoneCheck["pnum_area_code"]).Trim() != modGlobalVars.cEmptyString)
						{
							if (inPhoneGrd[inPhoneGrd.CurrentRowIndex, inPhoneGrd.CurrentColumnIndex].FormattedValue.ToString().Trim() != Convert.ToString(adoPhoneCheck["pnum_area_code"]).Trim())
							{
								bHasChanged = true;
							}
						}
					}
					else
					{
						if (inPhoneGrd[inPhoneGrd.CurrentRowIndex, inPhoneGrd.CurrentColumnIndex].FormattedValue.ToString().Trim() != "")
						{
							bHasChanged = true;
						}
					}

					inPhoneGrd.CurrentColumnIndex = 3;
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(adoPhoneCheck["pnum_prefix"]))
					{
						if (Convert.ToString(adoPhoneCheck["pnum_prefix"]).Trim() != modGlobalVars.cEmptyString)
						{
							if (inPhoneGrd[inPhoneGrd.CurrentRowIndex, inPhoneGrd.CurrentColumnIndex].FormattedValue.ToString().Trim() != Convert.ToString(adoPhoneCheck["pnum_prefix"]).Trim())
							{
								bHasChanged = true;
							}
						}
					}
					else
					{
						if (inPhoneGrd[inPhoneGrd.CurrentRowIndex, inPhoneGrd.CurrentColumnIndex].FormattedValue.ToString().Trim() != "")
						{
							bHasChanged = true;
						}
					}

					inPhoneGrd.CurrentColumnIndex = 4;
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(adoPhoneCheck["pnum_number"]))
					{
						if (Convert.ToString(adoPhoneCheck["pnum_number"]).Trim() != modGlobalVars.cEmptyString)
						{
							if (inPhoneGrd[inPhoneGrd.CurrentRowIndex, inPhoneGrd.CurrentColumnIndex].FormattedValue.ToString().Trim() != Convert.ToString(adoPhoneCheck["pnum_number"]).Trim())
							{
								bHasChanged = true;
							}
						}
					}
					else
					{
						if (inPhoneGrd[inPhoneGrd.CurrentRowIndex, inPhoneGrd.CurrentColumnIndex].FormattedValue.ToString().Trim() != "")
						{
							bHasChanged = true;
						}
					}

					inPhoneGrd.CurrentColumnIndex = 5;
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(adoPhoneCheck["pnum_hide_customer"]))
					{
						if (Convert.ToString(adoPhoneCheck["pnum_hide_customer"]).Trim() != modGlobalVars.cEmptyString)
						{
							if (inPhoneGrd[inPhoneGrd.CurrentRowIndex, inPhoneGrd.CurrentColumnIndex].FormattedValue.ToString().Trim().ToUpper() != Convert.ToString(adoPhoneCheck["pnum_hide_customer"]).Trim().ToUpper())
							{
								if (inPhoneGrd[inPhoneGrd.CurrentRowIndex, inPhoneGrd.CurrentColumnIndex].FormattedValue.ToString().Trim() == "N")
								{
									bHasChanged = true;
								}
							}
						}
					}
					else
					{
						if (inPhoneGrd[inPhoneGrd.CurrentRowIndex, inPhoneGrd.CurrentColumnIndex].FormattedValue.ToString().Trim() != "")
						{
							bHasChanged = true;
						}
					}

					inPhoneGrd.CurrentColumnIndex = 6;
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(adoPhoneCheck["pnum_confirm_date"]))
					{
						if (Convert.ToString(adoPhoneCheck["pnum_confirm_date"]).Trim() != modGlobalVars.cEmptyString && Information.IsDate(adoPhoneCheck["pnum_confirm_date"]))
						{
							if (inPhoneGrd[inPhoneGrd.CurrentRowIndex, inPhoneGrd.CurrentColumnIndex].FormattedValue.ToString().Trim() != "" && Information.IsDate(inPhoneGrd[inPhoneGrd.CurrentRowIndex, inPhoneGrd.CurrentColumnIndex].FormattedValue.ToString()))
							{
								if (DateTime.Parse(inPhoneGrd[inPhoneGrd.CurrentRowIndex, inPhoneGrd.CurrentColumnIndex].FormattedValue.ToString()).ToString("d").Trim() != Convert.ToDateTime(adoPhoneCheck["pnum_confirm_date"]).ToString("d").Trim())
								{
									bHasChanged = true;
								}
							}
							else
							{
								bHasChanged = true;
							}
						}
					}
					else
					{
						if (inPhoneGrd[inPhoneGrd.CurrentRowIndex, inPhoneGrd.CurrentColumnIndex].FormattedValue.ToString().Trim() != "")
						{
							bHasChanged = true;
						}
					}

					if (bHasChanged)
					{
						bHasChanged = false;
						if (!modCompany.has_item_been_added($"contact_phone{i.ToString()}", arrTransmitFields))
						{
							modCompany.add_items_to_array_fields(ref arrTransmitFields, $"contact_phone{i.ToString()}");
						}
						if (!modCompany.has_item_been_added($"contact_phone{i.ToString()}", arrVerifyFields))
						{
							modCompany.add_items_to_array_fields(ref arrVerifyFields, $"contact_phone{i.ToString()}");
						}
					}

					if (!(i >= adoPhoneCheck.RecordCount))
					{
						adoPhoneCheck.MoveNext();
					}
					else
					{
						break;
					}
				}

				adoPhoneCheck.Close();

			}
			else
			{

				if (inPhoneGrd.CurrentRowIndex == 1 || tmpPhone.company_phone1_changed_flag)
				{
					if (!modCompany.has_item_been_added("contact_phone1", arrTransmitFields))
					{
						modCompany.add_items_to_array_fields(ref arrTransmitFields, "contact_phone1");
					}
				}
				else if (inPhoneGrd.CurrentRowIndex == 2 || tmpPhone.company_phone2_changed_flag)
				{ 
					if (!modCompany.has_item_been_added("contact_phone2", arrTransmitFields))
					{
						modCompany.add_items_to_array_fields(ref arrTransmitFields, "contact_phone2");
					}
				}

			} // Not IsNull(adoPhoneCheck) And Not (adoPhoneCheck.BOF And adoPhoneCheck.EOF)

			if (tmpPhone.company_phone1_changed_flag)
			{
				if (!modCompany.has_item_been_added("contact_phone1", arrTransmitFields))
				{
					modCompany.add_items_to_array_fields(ref arrTransmitFields, "contact_phone1");
				}
			}
			else if (tmpPhone.company_phone2_changed_flag)
			{ 
				if (!modCompany.has_item_been_added("contact_phone2", arrTransmitFields))
				{
					modCompany.add_items_to_array_fields(ref arrTransmitFields, "contact_phone2");
				}
			}

			//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseServer);


			return false;
		}

		internal static void delete_company_phone_number(int in_CompanyID, int in_JournalID, UpgradeHelpers.DataGridViewFlex inPhoneGrd, ref modGlobalVars.t_company_save_phone_info tmpPhone)
		{

			try
			{
				string pnum_delete = "";
				pnum_delete = "";
				string pnum_delete_type = "";
				pnum_delete_type = "";
				string tmp_message = "";
				tmp_message = modGlobalVars.cEmptyString;
				string Query = "";
				Query = modGlobalVars.cEmptyString;
				int pnum_id_temp = 0;
				pnum_id_temp = 0;


				pnum_delete_type = Convert.ToString(inPhoneGrd[inPhoneGrd.CurrentRowIndex, 0].Value).Trim();

				pnum_id_temp = Convert.ToInt32(Double.Parse(Convert.ToString(inPhoneGrd[inPhoneGrd.CurrentRowIndex, 7].Value).Trim()));


				for (int K = 1; K <= 4; K++)
				{
					if (Convert.ToString(inPhoneGrd[inPhoneGrd.CurrentRowIndex, K].Value).Trim() != modGlobalVars.cEmptyString)
					{
						pnum_delete = $"{pnum_delete}{Convert.ToString(inPhoneGrd[inPhoneGrd.CurrentRowIndex, K].Value).Trim()}{((K == 4) ? modGlobalVars.cEmptyString : modGlobalVars.cHyphen)}";
					}
				}

				if (pnum_delete.Trim() != modGlobalVars.cEmptyString)
				{
					pnum_delete = pnum_delete.Trim();
				}

				// make sure the phone number is not blank and that its all numeric
				if (pnum_delete == modGlobalVars.cEmptyString || !(Information.IsNumeric(StringsHelper.Replace(StringsHelper.Replace(pnum_delete, " ", modGlobalVars.cEmptyString, 1, -1, CompareMethod.Binary), modGlobalVars.cHyphen, modGlobalVars.cEmptyString, 1, -1, CompareMethod.Binary).Trim())))
				{
					return;
				}

				tmpPhone.company_phone_delete_number = modGlobalVars.cEmptyString;
				tmpPhone.company_phone_delete_subject = modGlobalVars.cEmptyString;
				tmpPhone.company_phone_delete_flag = false;

				if (inPhoneGrd.CurrentRowIndex > 0)
				{
					Query = $"SELECT * FROM Phone_Numbers WITH (NOLOCK) WHERE (pnum_comp_id = {in_CompanyID.ToString()}) ";
					Query = $"{Query}AND (pnum_journ_id = {in_JournalID.ToString()})  AND (pnum_contact_id > 0 ) ";
					Query = $"{Query}AND (pnum_type = '{pnum_delete_type}') ";
					Query = $"{Query}AND (pnum_number_full_search = '{StringsHelper.Replace(StringsHelper.Replace(pnum_delete, " ", modGlobalVars.cEmptyString, 1, -1, CompareMethod.Binary), modGlobalVars.cHyphen, modGlobalVars.cEmptyString, 1, -1, CompareMethod.Binary).Trim()}') ";

					if (modAdminCommon.Exist(Query))
					{

						tmp_message = "HOMEBASE ACTION: Homebase has detected that the company phone number being removed also exists on one or more company contacts.";
						tmp_message = $"{tmp_message}{Environment.NewLine}{Environment.NewLine}Would you also like to remove this phone number from ALL contacts for this company?";

						if (MessageBox.Show(tmp_message, "Company : Delete Company Phone Number", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
						{
							tmpPhone.company_phone_delete_number = $"{pnum_delete_type}:{pnum_delete}";
							tmpPhone.company_phone_delete_subject = $"Removed Company/Contact Phone Number ({pnum_delete_type}) {pnum_delete}";
							tmpPhone.company_phone_delete_flag = true;
							tmpPhone.company_phone_id = pnum_id_temp;
						}
						else
						{
							tmpPhone.company_phone_delete_number = $"{pnum_delete_type}:{pnum_delete}";
							tmpPhone.company_phone_delete_subject = $"Removed Company Phone Number ({pnum_delete_type}) {pnum_delete}";
							tmpPhone.company_phone_delete_flag = true;
							tmpPhone.company_phone_id = pnum_id_temp;
						} // if user wants to remove contact phone numbers too

					}
					else
					{


						Query = " select pnum_comp_id, pnum_contact_id, pnum_number_full_search, pnum_type From Phone_Numbers with (NOLOCK)";
						Query = $"{Query} Where  (";
						Query = $"{Query} pnum_comp_id in (";
						Query = $"{Query} select compref_comp_id from Company_Reference with (NOLOCK)";
						Query = $"{Query} inner join Company with (NOLOCK) on comp_id = compref_comp_id and comp_journ_id = 0";
						Query = $"{Query} Where (compref_comp_id = {in_CompanyID.ToString()} Or compref_rel_comp_id = {in_CompanyID.ToString()}) And compref_journ_id = 0";
						Query = $"{Query} )  or  pnum_comp_id in (";
						Query = $"{Query} select compref_rel_comp_id from Company_Reference with (NOLOCK)";
						Query = $"{Query} inner join Company with (NOLOCK) on comp_id = compref_rel_comp_id and comp_journ_id = 0";
						Query = $"{Query} Where (compref_comp_id = {in_CompanyID.ToString()} Or compref_rel_comp_id = {in_CompanyID.ToString()}) And compref_journ_id = 0";
						Query = $"{Query} )  )";
						Query = $"{Query} AND pnum_number_full_search = '{StringsHelper.Replace(StringsHelper.Replace(pnum_delete, " ", modGlobalVars.cEmptyString, 1, -1, CompareMethod.Binary), modGlobalVars.cHyphen, modGlobalVars.cEmptyString, 1, -1, CompareMethod.Binary).Trim()}'";
						Query = $"{Query} and pnum_comp_id <> {in_CompanyID.ToString()}  and pnum_journ_id = 0";

						if (modAdminCommon.Exist(Query))
						{

							tmp_message = "HOMEBASE ACTION: Homebase has detected that the company phone number being removed also exists on one or more companies or contacts related to this company.";
							tmp_message = $"{tmp_message}{Environment.NewLine}{Environment.NewLine}Would you also like to remove this phone number from ALL contacts for this company?";

							if (MessageBox.Show(tmp_message, "Company : Delete Company Phone Number", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
							{
								tmpPhone.company_phone_delete_number = $"{pnum_delete_type}:{pnum_delete}";
								tmpPhone.company_phone_delete_subject = $"Removed Company/Contact Phone Number ({pnum_delete_type}) {pnum_delete}";
								tmpPhone.company_phone_delete_flag = true;
								tmpPhone.company_phone_id = pnum_id_temp;
							}
							else
							{
								tmpPhone.company_phone_delete_number = $"{pnum_delete_type}:{pnum_delete}";
								tmpPhone.company_phone_delete_subject = $"Removed Company Phone Number ({pnum_delete_type}) {pnum_delete}";
								tmpPhone.company_phone_delete_flag = true;
								tmpPhone.company_phone_id = pnum_id_temp;
							} // if user wants to remove contact phone numbers too


						}
						else
						{
							tmp_message = $"Are you sure you want to delete{Environment.NewLine}Company Phone Number ({pnum_delete_type}) {pnum_delete}";

							if (MessageBox.Show(tmp_message, "Company : Delete Company Phone Number", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
							{
								tmpPhone.company_phone_delete_number = $"{pnum_delete_type}:{pnum_delete}";
								tmpPhone.company_phone_delete_subject = $"Removed Company Phone Number ({pnum_delete_type}) {pnum_delete}";
								tmpPhone.company_phone_delete_flag = true;
								tmpPhone.company_phone_id = pnum_id_temp;
							}

						} // if there are matching contact phone numbers
					}


					if (tmpPhone.company_phone_delete_flag)
					{

						if (inPhoneGrd.RowsCount == 2)
						{
							inPhoneGrd.FixedRows = 0;
						}

						inPhoneGrd.RemoveItem(inPhoneGrd.CurrentRowIndex);
						inPhoneGrd.Redraw = true;

					}

				}
				else
				{

					MessageBox.Show("No Number Selected", "Company : Delete Company Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;

				}
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"delete_phone_number_Error ({Information.Err().Number.ToString()}) {excep.Message}", "Company (modCompany)");
				return;
			}

		}

		internal static string Get_Company_Name(int inComp_ID, int inJourn_ID)
		{
			string result = "";
			ADORecordSetHelper snp_CompName = new ADORecordSetHelper(); // dao.Recordset aey 6/18/04
			string Query = $"select comp_name from Company WITH(NOLOCK) where comp_id={inComp_ID.ToString()}";
			Query = $"{Query} and comp_journ_id={inJourn_ID.ToString()}";
			//Set snp_CompName = LOCAL_DB.OpenRecordset(Query, dbOpenSnapshot, dbSQLPassThrough)
			snp_CompName.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

			if (!(snp_CompName.BOF && snp_CompName.EOF))
			{
				snp_CompName.MoveFirst();
				result = ($" {Convert.ToString(snp_CompName["comp_name"])}").Trim();
			}
			snp_CompName.Close();

			return result;
		} //
		internal static bool save_company_phone_number(int in_CompanyID, int in_JournalID, CheckState inDontConfirmFlag, int in_fractOwnerID, ComboBox inPhoneType, TextBox inPhoneCCode, TextBox inPhoneACode, TextBox inPhonePrefix, TextBox inPhoneNumber, CheckBox inHideNumber, UpgradeHelpers.DataGridViewFlex inPhoneGrd, ref string[] arrTransmitFields, ref string[] arrVerifyFields, modGlobalVars.t_company_save_phone_info tmpPhone, string pnum_id)
		{

			bool result = false;
			try
			{

				string Query = "";
				string[] tmpDeleteNumberAry = null;
				string strMsg = "";
				System.DateTime dtStartDate = DateTime.FromOADate(0);
				System.DateTime dtEndDate = DateTime.FromOADate(0);

				bool bSubscription = false;
				int lSubId = 0;
				int lParentId = 0;
				bool bResults = false;
				string strErrMsg = "";
				string strEMailTo = "";
				string strEMailSubject = "";
				string strEMailBody = "";
				ADORecordSetHelper snp_Contact = null;
				StringBuilder QueryD = new StringBuilder();
				string comp_name = "";


				result = false;

				check_company_phone_for_changes(in_CompanyID, in_JournalID, inPhoneGrd, ref arrTransmitFields, ref arrVerifyFields, tmpPhone);

				if (!(tmpPhone.company_phone_add_flag) && tmpPhone.company_phone_original_full.Trim() != modGlobalVars.cEmptyString && tmpPhone.company_phone_new_number.Trim() != modGlobalVars.cEmptyString)
				{ // change company phone number update it

					if (inPhoneType.Text.Trim() != modGlobalVars.cEmptyString)
					{
						Query = $"UPDATE Phone_Numbers SET pnum_type = '{inPhoneType.Text.Trim()}',";
					}
					else
					{
						Query = "UPDATE Phone_Numbers SET pnum_type = null,";
					}

					if (inPhoneCCode.Text.Trim() != modGlobalVars.cEmptyString)
					{
						Query = $"{Query}pnum_cntry_code = '{inPhoneCCode.Text.Trim()}',";
					}
					else
					{
						Query = $"{Query}pnum_cntry_code = null,";
					}

					if (inPhoneACode.Text.Trim() != modGlobalVars.cEmptyString)
					{
						Query = $"{Query}pnum_area_code = '{inPhoneACode.Text.Trim()}',";
					}
					else
					{
						Query = $"{Query}pnum_area_code = null,";
					}

					if (inPhonePrefix.Text.Trim() != modGlobalVars.cEmptyString)
					{
						Query = $"{Query}pnum_prefix = '{inPhonePrefix.Text.Trim()}',";
					}
					else
					{
						Query = $"{Query}pnum_prefix = null,";
					}

					if (inPhoneNumber.Text.Trim() != modGlobalVars.cEmptyString)
					{
						Query = $"{Query}pnum_number = '{inPhoneNumber.Text.Trim()}',";
					}
					else
					{
						Query = $"{Query}pnum_number = null,";
					}

					if (inHideNumber.CheckState == CheckState.Checked)
					{
						Query = $"{Query}pnum_hide_customer = 'Y',";
					}
					else
					{
						Query = $"{Query}pnum_hide_customer = 'N',";
					}

					if (inDontConfirmFlag == CheckState.Unchecked)
					{
						if (tmpPhone.company_only_change_is_hide_flag)
						{
							if (Information.IsDate(tmpPhone.company_phone_confirmdate))
							{
								Query = $"{Query}pnum_confirm_date = '{DateTime.Parse(tmpPhone.company_phone_confirmdate).ToString("d")}',"; // dont change if b_OnlyChangeIsHide
							}
							else
							{
								Query = $"{Query}pnum_confirm_date = '{DateTime.Now.ToString("d")}',"; // always set to today for update
							}
						}
						else
						{
							Query = $"{Query}pnum_confirm_date = '{DateTime.Now.ToString("d")}',"; // always set to today for update
						}
					}
					else if (!Information.IsDate(tmpPhone.company_phone_confirmdate))
					{  // if the confirm date is empty then set null
						Query = $"{Query}pnum_confirm_date = null,";
					}

					Query = $"{Query}pnum_number_full = '{StringsHelper.Replace(tmpPhone.company_phone_new_number, " ", modGlobalVars.cEmptyString, 1, -1, CompareMethod.Binary).Trim()}',";
					Query = $"{Query}pnum_number_full_search = '{StringsHelper.Replace(StringsHelper.Replace(tmpPhone.company_phone_new_number, " ", modGlobalVars.cEmptyString, 1, -1, CompareMethod.Binary), modGlobalVars.cHyphen, modGlobalVars.cEmptyString, 1, -1, CompareMethod.Binary).Trim()}'";


					// CHANGED TO DO IT BY ID - MSW - 5/25/23, incldue by id as long as its there
					if (pnum_id != "" && pnum_id != "0")
					{
						Query = $"{Query} where pnum_id = {pnum_id}";
					}
					else
					{
						Query = $"{Query} WHERE pnum_comp_id = {in_CompanyID.ToString()} AND pnum_journ_id = {in_JournalID.ToString()}";
						Query = $"{Query} AND pnum_contact_id = 0 AND pnum_type = '{tmpPhone.company_phone_original_type.Trim()}'";

						Query = $"{Query} AND pnum_number_full_search = '{StringsHelper.Replace(StringsHelper.Replace(tmpPhone.company_phone_original_full, modGlobalVars.cHyphen, modGlobalVars.cEmptyString, 1, -1, CompareMethod.Binary), " ", modGlobalVars.cEmptyString, 1, -1, CompareMethod.Binary).Trim()}'";
					}





					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand.CommandType = (CommandType) (((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()) + ((int) CommandType.Text));
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();

					if (inDontConfirmFlag == CheckState.Unchecked && !tmpPhone.company_phone_delete_flag && !tmpPhone.company_only_change_is_hide_flag)
					{

						// INSERT A COMPANY CONFIRMATION JOURNAL ENTRY
						modAdminCommon.Rec_Journal_Info.journ_subject = $"Confirmed Company Phone Number ({inPhoneType.Text}) {tmpPhone.company_phone_new_number}";
						modAdminCommon.Rec_Journal_Info.journ_description = $"Updated Company Phone Number - done by {modAdminCommon.gbl_User_ID}";
						modAdminCommon.Rec_Journal_Info.journ_ac_id = 0;
						modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "CPCFM";
						modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTime.Now.ToString("d").Trim());
						modAdminCommon.Rec_Journal_Info.journ_comp_id = in_CompanyID;
						modAdminCommon.Rec_Journal_Info.journ_contact_id = 0;
						modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
						modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
						modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
						modAdminCommon.Rec_Journal_Info.journ_status = "A";
						modAdminCommon.Rec_Journal_Info.journ_category_code = "AR";

						frm_Journal.DefInstance.Commit_Journal_Entry();

					}

				}
				else if (tmpPhone.company_phone_add_flag && tmpPhone.company_phone_original_full.Trim() == modGlobalVars.cEmptyString && tmpPhone.company_phone_new_number.Trim() != modGlobalVars.cEmptyString)
				{  // new company phone number insert it

					Query = "INSERT INTO Phone_Numbers (pnum_comp_id,pnum_journ_id,pnum_contact_id,pnum_type,";
					Query = $"{Query}pnum_cntry_code,pnum_area_code,pnum_prefix,pnum_number,pnum_hide_customer,";
					Query = $"{Query}pnum_confirm_date,pnum_number_full,pnum_number_full_search) VALUES ({in_CompanyID.ToString()},"; // company ID
					Query = $"{Query}{in_JournalID.ToString()}, 0,"; // contact ID

					if (inPhoneType.Text.Trim() != modGlobalVars.cEmptyString)
					{
						Query = $"{Query}'{inPhoneType.Text.Trim()}',";
					}
					else
					{
						Query = $"{Query}null,";
					}

					if (inPhoneCCode.Text.Trim() != modGlobalVars.cEmptyString)
					{
						Query = $"{Query}'{inPhoneCCode.Text.Trim()}',";
					}
					else
					{
						Query = $"{Query}null,";
					}

					if (inPhoneACode.Text.Trim() != modGlobalVars.cEmptyString)
					{
						Query = $"{Query}'{inPhoneACode.Text.Trim()}',";
					}
					else
					{
						Query = $"{Query}null,";
					}

					if (inPhonePrefix.Text.Trim() != modGlobalVars.cEmptyString)
					{
						Query = $"{Query}'{inPhonePrefix.Text.Trim()}',";
					}
					else
					{
						Query = $"{Query}null,";
					}

					if (inPhoneNumber.Text.Trim() != modGlobalVars.cEmptyString)
					{
						Query = $"{Query}'{inPhoneNumber.Text.Trim()}',";
					}
					else
					{
						Query = $"{Query}null,";
					}

					if (inHideNumber.CheckState == CheckState.Checked)
					{
						Query = $"{Query}'Y',";
					}
					else
					{
						Query = $"{Query}'N',";
					}

					if (inDontConfirmFlag == CheckState.Unchecked)
					{
						Query = $"{Query}'{DateTime.Now.ToString("d")}',";
					}
					else
					{
						Query = $"{Query}null,";
					}

					Query = $"{Query}'{StringsHelper.Replace(tmpPhone.company_phone_new_number, " ", modGlobalVars.cEmptyString, 1, -1, CompareMethod.Binary).Trim()}',";
					Query = $"{Query}'{StringsHelper.Replace(StringsHelper.Replace(tmpPhone.company_phone_new_number, " ", modGlobalVars.cEmptyString, 1, -1, CompareMethod.Binary), modGlobalVars.cHyphen, modGlobalVars.cEmptyString, 1, -1, CompareMethod.Binary).Trim()}')";

					DbCommand TempCommand_2 = null;
					TempCommand_2 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
					TempCommand_2.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand_2.CommandType = (CommandType) (((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()) + ((int) CommandType.Text));
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
					TempCommand_2.ExecuteNonQuery();

					if (!tmpPhone.company_phone_delete_flag)
					{

						// INSERT A COMPANY CONFIRMATION JOURNAL ENTRY

						if (inDontConfirmFlag == CheckState.Unchecked)
						{
							modAdminCommon.Rec_Journal_Info.journ_subject = $"Confirmed Company Phone Number ({inPhoneType.Text}) {tmpPhone.company_phone_new_number}";
							modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "CPCFM";
						}
						else
						{
							modAdminCommon.Rec_Journal_Info.journ_subject = $"Added New Company Phone Number ({inPhoneType.Text}) {tmpPhone.company_phone_new_number}";
							modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "RN";
						}

						modAdminCommon.Rec_Journal_Info.journ_description = $"Added New Company Phone Number - done by {modAdminCommon.gbl_User_ID}";
						modAdminCommon.Rec_Journal_Info.journ_ac_id = 0;

						modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTime.Now.ToString("d").Trim());
						modAdminCommon.Rec_Journal_Info.journ_comp_id = in_CompanyID;
						modAdminCommon.Rec_Journal_Info.journ_contact_id = 0;
						modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
						modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
						modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
						modAdminCommon.Rec_Journal_Info.journ_status = "A";
						modAdminCommon.Rec_Journal_Info.journ_category_code = "AR";

						frm_Journal.DefInstance.Commit_Journal_Entry();

						modCommon.Start_Activity_Monitor_Message("Company Phone Added", ref strMsg, ref dtStartDate, ref dtEndDate);
						strMsg = $" - {inPhoneType.Text} - {tmpPhone.company_phone_new_number}";
						modCommon.End_Activity_Monitor_Message("Company Phone Added", ref strMsg, dtStartDate, ref dtEndDate, 0, 0, in_CompanyID, 0, 0);

					}

				}
				else if (tmpPhone.company_phone_delete_number.Trim() != modGlobalVars.cEmptyString && tmpPhone.company_phone_delete_flag)
				{  // delete company phone number

					tmpDeleteNumberAry = tmpPhone.company_phone_delete_number.Split(':');

					// ADDED  - MSW 6/23/17 - TO GET RID OF COMPANIES WITH THE SAME PHONE NUMBER THAT ARE RELATED-----------------------
					Query = " select pnum_comp_id, pnum_contact_id, pnum_number_full_search, pnum_type, pnum_id From Phone_Numbers with (NOLOCK)";
					Query = $"{Query} Where  ( pnum_comp_id in (";
					Query = $"{Query} select compref_comp_id from Company_Reference with (NOLOCK)";
					Query = $"{Query} inner join Company with (NOLOCK) on comp_id = compref_comp_id and comp_journ_id = 0";
					Query = $"{Query} Where (compref_comp_id = {in_CompanyID.ToString()} Or compref_rel_comp_id = {in_CompanyID.ToString()}) And compref_journ_id = 0";
					Query = $"{Query} )  or";
					Query = $"{Query} pnum_comp_id in (";
					Query = $"{Query} select compref_rel_comp_id from Company_Reference with (NOLOCK)";
					Query = $"{Query} inner join Company with (NOLOCK) on comp_id = compref_rel_comp_id and comp_journ_id = 0";
					Query = $"{Query} Where (compref_comp_id = {in_CompanyID.ToString()} Or compref_rel_comp_id = {in_CompanyID.ToString()}) And compref_journ_id = 0";
					Query = $"{Query} ) )";
					Query = $"{Query} AND pnum_number_full_search = '{StringsHelper.Replace(tmpDeleteNumberAry[1], "-", "", 1, -1, CompareMethod.Binary)}'";
					Query = $"{Query} and pnum_comp_id <> {in_CompanyID.ToString()}  and pnum_journ_id = 0";

					if (modAdminCommon.Exist(Query))
					{
						if (MessageBox.Show("There are also Companies, and Possibly Their Contacts, Related To This Company That Have The Same Phone Number. Would You Like To Remove Them As Well?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
						{

							snp_Contact = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(snp_Contact.Fields) && !(snp_Contact.EOF && snp_Contact.BOF))
							{


								while(!snp_Contact.EOF)
								{

									QueryD = new StringBuilder($"DELETE from Phone_Numbers WHERE pnum_comp_id = {Convert.ToString(snp_Contact["pnum_comp_id"]).Trim()}");

									QueryD.Append($" AND pnum_id = {Convert.ToString(snp_Contact["pnum_id"]).Trim()}");

									// changed to just delet by pnum_id - MSW - 9/6/22
									QueryD.Append(" AND pnum_journ_id = 0 ");

									QueryD = new StringBuilder(QueryD.ToString());
									DbCommand TempCommand_3 = null;
									TempCommand_3 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
									UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_3);
									TempCommand_3.CommandText = QueryD.ToString();
									//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
									//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
									TempCommand_3.CommandType = (CommandType) (((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()) + ((int) CommandType.Text));
									UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_3);
									TempCommand_3.ExecuteNonQuery();

									modAdminCommon.Rec_Journal_Info.journ_subject = tmpPhone.company_phone_delete_subject;
									modAdminCommon.Rec_Journal_Info.journ_description = modGlobalVars.cEmptyString;
									modAdminCommon.Rec_Journal_Info.journ_ac_id = 0;
									modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "RN";
									modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTimeHelper.ToString(DateTime.Now));
									modAdminCommon.Rec_Journal_Info.journ_comp_id = Convert.ToInt32(Double.Parse(Convert.ToString(snp_Contact["pnum_comp_id"]).Trim()));
									modAdminCommon.Rec_Journal_Info.journ_contact_id = Convert.ToInt32(Double.Parse(Convert.ToString(snp_Contact["pnum_contact_id"]).Trim()));
									modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
									modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
									modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
									modAdminCommon.Rec_Journal_Info.journ_status = "A";
									modAdminCommon.Rec_Journal_Info.journ_category_code = "AR";
									frm_Journal.DefInstance.Commit_Journal_Entry();

									Application.DoEvents();
									Application.DoEvents();

									snp_Contact.MoveNext();

								}; // Do While Not snp_ContactPhone.EOF

							}

							snp_Contact.Close();
							snp_Contact = null;
						}
					}

					// ADDED  - MSW 6/23/17 - TO GET RID OF COMPANIES WITH THE SAME PHONE NUMBER THAT ARE RELATED-----------------------

					Application.DoEvents();
					Application.DoEvents();

					if (tmpPhone.company_phone_id > 0)
					{
						Query = $"DELETE from Phone_Numbers WHERE pnum_comp_id = {in_CompanyID.ToString()}";
						Query = $"{Query} AND pnum_journ_id = {in_JournalID.ToString()}";
						Query = $"{Query} AND pnum_id = {tmpPhone.company_phone_id.ToString().Trim()}";

						DbCommand TempCommand_4 = null;
						TempCommand_4 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_4);
						TempCommand_4.CommandText = Query;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand_4.CommandType = (CommandType) (((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()) + ((int) CommandType.Text));
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_4);
						TempCommand_4.ExecuteNonQuery();

						if (tmpPhone.company_phone_delete_subject.IndexOf("Contact") >= 0)
						{

							// we have matching contact phone numbers to remove ...
							Query = $"DELETE FROM Phone_Numbers  Where (( pnum_comp_id = {in_CompanyID.ToString()}";
							Query = $"{Query} AND pnum_journ_id = {in_JournalID.ToString()}";
							Query = $"{Query} AND pnum_contact_id > 0 AND pnum_type = '{tmpDeleteNumberAry[0].Trim()}'";
							Query = $"{Query} AND pnum_number_full_search = '{StringsHelper.Replace(StringsHelper.Replace(tmpDeleteNumberAry[1], modGlobalVars.cHyphen, modGlobalVars.cEmptyString, 1, -1, CompareMethod.Binary), " ", modGlobalVars.cEmptyString, 1, -1, CompareMethod.Binary).Trim()}'";
							Query = $"{Query} )   )";

							DbCommand TempCommand_5 = null;
							TempCommand_5 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_5);
							TempCommand_5.CommandText = Query;
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
							TempCommand_5.CommandType = (CommandType) (((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()) + ((int) CommandType.Text));
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_5);
							TempCommand_5.ExecuteNonQuery();

						}



						modAdminCommon.Rec_Journal_Info.journ_subject = tmpPhone.company_phone_delete_subject;
						modAdminCommon.Rec_Journal_Info.journ_description = modGlobalVars.cEmptyString;
						modAdminCommon.Rec_Journal_Info.journ_ac_id = 0;
						modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "RN";
						modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTimeHelper.ToString(DateTime.Now));
						modAdminCommon.Rec_Journal_Info.journ_comp_id = in_CompanyID;
						modAdminCommon.Rec_Journal_Info.journ_contact_id = 0;
						modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
						modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
						modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
						modAdminCommon.Rec_Journal_Info.journ_status = "A";
						modAdminCommon.Rec_Journal_Info.journ_category_code = "AR";
						frm_Journal.DefInstance.Commit_Journal_Entry();

						if (in_JournalID == 0)
						{

							bSubscription = modCommon.Does_Company_Have_An_Active_Subscription(in_CompanyID, ref lSubId, ref lParentId);

							if (bSubscription)
							{

								strEMailTo = ($"{modCommon.DLookUp("aconfig_email_company_contact_chg", "Application_Configuration")}").Trim();

								comp_name = Get_Company_Name(in_CompanyID, 0);

								strEMailSubject = $"Homebase Company Phone Nbr Deleted for {comp_name} [{in_CompanyID.ToString()}] ";

								strEMailBody = $"Homebase Company Phone Nbr Deleted{Environment.NewLine}{Environment.NewLine}";
								strEMailBody = $"{strEMailBody}Company: {comp_name} [{in_CompanyID.ToString()}] {Environment.NewLine}{Environment.NewLine}";
								strEMailBody = $"{strEMailBody}Phone Nbr: {tmpDeleteNumberAry[0].Trim()} - {tmpDeleteNumberAry[1].Trim()}{Environment.NewLine}{Environment.NewLine}";

								bResults = modEmail.Simple_Insert_EMail_Queue_Record(strEMailTo, "", "", strEMailSubject, strEMailBody, "", "N", "Open", "Homebase Company Phone Nbr Deleted", "jetnet@jetnet.com", in_CompanyID, 0);

								if (bResults)
								{
									modEmail.Send_All_EMail_In_Queue(ref strErrMsg, in_CompanyID);
								}

								modCommon.Enter_Customer_Program_Message_Note("", strEMailTo, $"{strEMailSubject}{Environment.NewLine}{strEMailBody}", lSubId, lParentId, in_CompanyID, 0);

							} // If bSubscription = True Then

						} // If in_JournalID = 0 Then


					} // ElseIf Trim$(tmpPhone.company_phone_delete_number) <> cEmptyString And tmpPhone.company_phone_delete_flag Then    ' delete company phone number
				}


				// if we have a new contact phone number then update the old phone number
				if (tmpPhone.contact_phone_toEdit.Trim() != modGlobalVars.cEmptyString)
				{

					if (tmpPhone.contact_phone_new.Trim() != modGlobalVars.cEmptyString && !tmpPhone.company_phone_delete_flag)
					{

						if (tmpPhone.contact_phone_typeNew.Trim() != modGlobalVars.cEmptyString)
						{
							Query = $"UPDATE Phone_Numbers SET pnum_type = '{tmpPhone.contact_phone_typeNew.Trim()}',";
						}
						else
						{
							Query = "UPDATE Phone_Numbers SET pnum_type = null,";
						}

						if (inPhoneCCode.Text.Trim() != modGlobalVars.cEmptyString)
						{
							Query = $"{Query}pnum_cntry_code = '{inPhoneCCode.Text.Trim()}',";
						}
						else
						{
							Query = $"{Query}pnum_cntry_code = null,";
						}

						if (inPhoneACode.Text.Trim() != modGlobalVars.cEmptyString)
						{
							Query = $"{Query}pnum_area_code = '{inPhoneACode.Text.Trim()}',";
						}
						else
						{
							Query = $"{Query}pnum_area_code = null,";
						}

						if (inPhonePrefix.Text.Trim() != modGlobalVars.cEmptyString)
						{
							Query = $"{Query}pnum_prefix = '{inPhonePrefix.Text.Trim()}',";
						}
						else
						{
							Query = $"{Query}pnum_prefix = null,";
						}

						if (inPhoneNumber.Text.Trim() != modGlobalVars.cEmptyString)
						{
							Query = $"{Query}pnum_number = '{inPhoneNumber.Text.Trim()}',";
						}
						else
						{
							Query = $"{Query}pnum_number = null,";
						}

						if (inHideNumber.CheckState == CheckState.Checked)
						{
							Query = $"{Query}pnum_hide_customer = 'Y',";
						}
						else
						{
							Query = $"{Query}pnum_hide_customer = 'N',";
						}

						if (inDontConfirmFlag == CheckState.Unchecked)
						{
							if (tmpPhone.company_only_change_is_hide_flag)
							{
								if (Information.IsDate(tmpPhone.company_phone_confirmdate))
								{
									Query = $"{Query}pnum_confirm_date = '{DateTime.Parse(tmpPhone.company_phone_confirmdate).ToString("d")}',"; // dont change if b_OnlyChangeIsHide
								}
								else
								{
									Query = $"{Query}pnum_confirm_date = '{DateTime.Now.ToString("d")}',"; // always set to today for update
								}
							}
							else
							{
								Query = $"{Query}pnum_confirm_date = '{DateTime.Now.ToString("d")}',"; // always set to today for update
							}
						}
						else if (!Information.IsDate(tmpPhone.company_phone_confirmdate))
						{  // if the confirm date is empty then set null
							Query = $"{Query}pnum_confirm_date = null,";
						}

						Query = $"{Query}pnum_number_full = '{StringsHelper.Replace(tmpPhone.contact_phone_new, " ", modGlobalVars.cEmptyString, 1, -1, CompareMethod.Binary).Trim()}',";
						Query = $"{Query}pnum_number_full_search = '{StringsHelper.Replace(StringsHelper.Replace(tmpPhone.contact_phone_new, " ", modGlobalVars.cEmptyString, 1, -1, CompareMethod.Binary), modGlobalVars.cHyphen, modGlobalVars.cEmptyString, 1, -1, CompareMethod.Binary).Trim()}'";
						Query = $"{Query} WHERE pnum_comp_id = {in_CompanyID.ToString()}";
						Query = $"{Query} AND pnum_journ_id = {in_JournalID.ToString()}";
						Query = $"{Query} AND pnum_contact_id > 0 AND pnum_type = '{tmpPhone.contact_phone_typeToEdit.Trim()}'";
						Query = $"{Query} AND pnum_number_full_search = '{StringsHelper.Replace(StringsHelper.Replace(tmpPhone.contact_phone_toEdit, modGlobalVars.cHyphen, modGlobalVars.cEmptyString, 1, -1, CompareMethod.Binary), " ", modGlobalVars.cEmptyString, 1, -1, CompareMethod.Binary).Trim()}'";

						DbCommand TempCommand_6 = null;
						TempCommand_6 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_6);
						TempCommand_6.CommandText = Query;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand_6.CommandType = (CommandType) (((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()) + ((int) CommandType.Text));
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_6);
						TempCommand_6.ExecuteNonQuery();

						if (inDontConfirmFlag == CheckState.Unchecked && !tmpPhone.company_phone_delete_flag && !tmpPhone.company_only_change_is_hide_flag)
						{

							// INSERT A CONTACT CONFIRMATION JOURNAL ENTRY
							modAdminCommon.Rec_Journal_Info.journ_subject = $"Confirmed Contact Phone Number ({tmpPhone.contact_phone_typeNew}) {tmpPhone.contact_phone_new}";
							modAdminCommon.Rec_Journal_Info.journ_description = $"Updated Contact Phone Number because Company Phone Number of Same Type Changed - done by {modAdminCommon.gbl_User_ID}";
							modAdminCommon.Rec_Journal_Info.journ_ac_id = 0;
							modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "CNCFM";
							modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTime.Now.ToString("d").Trim());
							modAdminCommon.Rec_Journal_Info.journ_comp_id = in_CompanyID;
							modAdminCommon.Rec_Journal_Info.journ_contact_id = 0;
							modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
							modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
							modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
							modAdminCommon.Rec_Journal_Info.journ_status = "A";
							modAdminCommon.Rec_Journal_Info.journ_category_code = "AR";

							frm_Journal.DefInstance.Commit_Journal_Entry();

						}

					}

				} // Trim(ContactPhoneNumberToEdit) <> cEmptyString
				Application.DoEvents();
				Application.DoEvents();

				if (arrTransmitFields.GetUpperBound(0) > 0 && !tmpPhone.company_phone_delete_flag)
				{
					//process transmits
					modCommon.Record_CompanyContact_Aircraft_Transmits("Company", "Change", in_CompanyID, 0, in_JournalID, ref arrTransmitFields, 0, "", in_fractOwnerID.ToString());

				}
				Application.DoEvents();

				return true;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"save_company_phone_number_Error ({Information.Err().Number.ToString()}) {excep.Message}", "Company (modCompany)");
				return result;
			}
		}


		internal static int get_inactive_aircraft_count(int inCompanyId, int inJournalId)
		{
			//count the number if inactive aircraft
			//3/27/2012 - RTW - THIS IS NO LONGER USED ON COMPANY FORM AS OF TODAY.

			int result = 0;
			string Query = "";
			ADORecordSetHelper Ado_Count = null;


			try
			{

				Query = "SELECT count(ac_id) AS InActiveCount FROM Aircraft WITH(NOLOCK) INNER JOIN Aircraft_Reference ON ac_id = cref_ac_id and ac_journ_id = cref_journ_id";
				Query = $"{Query} WHERE cref_comp_id = {inCompanyId.ToString()} AND cref_journ_id = {inJournalId.ToString()} AND ac_lifecycle_stage = 4";

				Ado_Count = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!(Convert.IsDBNull(Ado_Count.Fields) && (Ado_Count.EOF && Ado_Count.BOF)))
				{
					result = Convert.ToInt32(Ado_Count["InActiveCount"]);
					Ado_Count.Close();
				}

				Ado_Count = null;

				return result;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"get_inactive_aircraft_count_Error ({Information.Err().Number.ToString()}) {excep.Message}", "Company (modCompany)");
				return result;
			}
		}

		internal static int get_aicraft_count(int inCompanyId, int inJournalId)
		{

			int result = 0;
			string Query = "";
			ADORecordSetHelper Ado_Count = null; //aey 6/10/04

			try
			{

				result = 0;

				Query = "SELECT count(DISTINCT cref_ac_id) as AircraftCount FROM Aircraft_Reference WITH(NOLOCK)";
				Query = $"{Query} WHERE cref_comp_id = {inCompanyId.ToString()} AND cref_journ_id = {inJournalId.ToString()}";

				Ado_Count = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!(Convert.IsDBNull(Ado_Count.Fields) && (Ado_Count.EOF && Ado_Count.BOF)))
				{
					result = Convert.ToInt32(Ado_Count["AircraftCount"]);
					Ado_Count.Close();
				}

				Ado_Count = null;

				return result;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"get_aicraft_count_Error ({Information.Err().Number.ToString()}) {excep.Message}", "Company (modCompany)");
				return result;
			}
		}

		internal static string get_company_contact_information(int inContactId, int inJournalId)
		{


			string result = "";
			string Query = "";
			ADORecordSetHelper ado_ContactName = null;
			try
			{

				result = modGlobalVars.cEmptyString;

				// RETURN A BLANK AND EXIT IF THERE IS A 0 FOR A CONTACT ID
				if (inContactId > 0)
				{

					// SELECT THE CONTACT AND RETURN THE CONTACT INFORMATION
					Query = "SELECT contact_sirname, contact_middle_initial, contact_suffix, contact_first_name, contact_last_name, contact_title";
					Query = $"{Query} FROM Contact WITH(NOLOCK) WHERE contact_id = {inContactId.ToString()} AND contact_journ_id = {inJournalId.ToString()}";

					ado_ContactName = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(ado_ContactName.Fields) && !(ado_ContactName.BOF && ado_ContactName.EOF))
					{

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_ContactName["contact_first_name"]) && !Convert.IsDBNull(ado_ContactName["contact_last_name"]))
						{
							if (Convert.ToString(ado_ContactName["contact_first_name"]).Trim() == modGlobalVars.cEmptyString && Convert.ToString(ado_ContactName["contact_last_name"]).Trim() == modGlobalVars.cEmptyString)
							{
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(ado_ContactName["contact_title"]))
								{
									if (Convert.ToString(ado_ContactName["contact_title"]).Trim() != modGlobalVars.cEmptyString)
									{
										result = Convert.ToString(ado_ContactName["contact_title"]).Trim();
									}
								}
							}
							else
							{
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(ado_ContactName["contact_sirname"]))
								{
									if (Convert.ToString(ado_ContactName["contact_sirname"]).Trim() != modGlobalVars.cEmptyString)
									{
										result = $"{Convert.ToString(ado_ContactName["contact_sirname"]).Trim()}{modGlobalVars.cSingleSpace}";
									}
								}
								result = $"{result}{Convert.ToString(ado_ContactName["contact_first_name"]).Trim()}{modGlobalVars.cSingleSpace}";
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(ado_ContactName["contact_middle_initial"]))
								{
									if (Convert.ToString(ado_ContactName["contact_middle_initial"]).Trim() != modGlobalVars.cEmptyString)
									{
										result = $"{result}{Convert.ToString(ado_ContactName["contact_middle_initial"]).Trim()}. ";
									}
								}
								result = $"{result}{Convert.ToString(ado_ContactName["contact_last_name"]).Trim()}{modGlobalVars.cSingleSpace}";
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(ado_ContactName["contact_suffix"]))
								{
									if (Convert.ToString(ado_ContactName["contact_suffix"]).Trim() != modGlobalVars.cEmptyString)
									{
										result = $"{result}{Convert.ToString(ado_ContactName["contact_suffix"]).Trim()}";
									}
								}
							}
						}

						result = result.Trim();
						ado_ContactName.Close();

					}

					ado_ContactName = null;

				}

				return result;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"get_company_contact_information_Error ({Information.Err().Number.ToString()}) {excep.Message}", "Company (modCompany)");
				return result;
			}
		}

		internal static string get_contact_information_from_aircraft_reference(int inAircraftRefID, int inCompanyId, int inJournalId, ref int outContactID)
		{
			//
			// PURPOSE: THE PURPOSE OF THIS FUNCTION IS TO SELECT AND RETURN A SET OF
			// CONTACT INFORMATION FOR USE IN THE AIRCRAFT GRID ON THE COMPANY FORM.

			string result = "";
			string Query = "";
			string sNameStr = "";
			int nContactID = 0;
			ADORecordSetHelper ado_rs = null;
			try
			{

				result = modGlobalVars.cEmptyString;
				outContactID = 0;

				// RETURN A BLANK AND EXIT IF THERE IS A 0 FOR A CONTACT ID
				if (inAircraftRefID > 0)
				{

					Query = $"SELECT cref_contact_id FROM Aircraft_Reference WITH(NOLOCK)  WHERE cref_id = {inAircraftRefID.ToString()}";
					Query = $"{Query} AND cref_comp_id = {inCompanyId.ToString()} AND cref_journ_id = {inJournalId.ToString()}";

					ado_rs = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(ado_rs.Fields) && !(ado_rs.BOF && ado_rs.EOF))
					{
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_rs["cref_contact_id"]))
						{
							nContactID = Convert.ToInt32(ado_rs["cref_contact_id"]);
							ado_rs.Close();
						}
					}
					ado_rs = null;

					if (nContactID > 0)
					{

						// SELECT THE CONTACT AND RETURN THE CONTACT INFORMATION
						Query = "SELECT contact_sirname, contact_middle_initial, contact_suffix, contact_first_name, contact_last_name, contact_title";
						Query = $"{Query} FROM Contact WITH(NOLOCK) WHERE contact_id = {nContactID.ToString()} AND contact_journ_id = {inJournalId.ToString()}";

						ado_rs = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_rs.Fields) && !(ado_rs.BOF && ado_rs.EOF))
						{

							// if we have contact info set
							outContactID = nContactID;

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(ado_rs["contact_first_name"]) && !Convert.IsDBNull(ado_rs["contact_last_name"]))
							{
								if (Convert.ToString(ado_rs["contact_first_name"]).Trim() == modGlobalVars.cEmptyString && Convert.ToString(ado_rs["contact_last_name"]).Trim() == modGlobalVars.cEmptyString)
								{
									//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
									if (!Convert.IsDBNull(ado_rs["contact_title"]))
									{
										if (Convert.ToString(ado_rs["contact_title"]).Trim() != modGlobalVars.cEmptyString)
										{
											sNameStr = Convert.ToString(ado_rs["contact_title"]).Trim();
										}
									}
								}
								else
								{
									//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
									if (!Convert.IsDBNull(ado_rs["contact_sirname"]))
									{
										if (Convert.ToString(ado_rs["contact_sirname"]).Trim() != modGlobalVars.cEmptyString)
										{
											sNameStr = $"{Convert.ToString(ado_rs["contact_sirname"]).Trim()}{modGlobalVars.cSingleSpace}";
										}
									}
									sNameStr = $"{sNameStr}{Convert.ToString(ado_rs["contact_first_name"]).Trim()}{modGlobalVars.cSingleSpace}";
									//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
									if (!Convert.IsDBNull(ado_rs["contact_middle_initial"]))
									{
										if (Convert.ToString(ado_rs["contact_middle_initial"]).Trim() != modGlobalVars.cEmptyString)
										{
											sNameStr = $"{sNameStr}{Convert.ToString(ado_rs["contact_middle_initial"]).Trim()}. ";
										}
									}
									sNameStr = $"{sNameStr}{Convert.ToString(ado_rs["contact_last_name"]).Trim()}{modGlobalVars.cSingleSpace}";
									//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
									if (!Convert.IsDBNull(ado_rs["contact_suffix"]))
									{
										if (Convert.ToString(ado_rs["contact_suffix"]).Trim() != modGlobalVars.cEmptyString)
										{
											sNameStr = $"{sNameStr}{Convert.ToString(ado_rs["contact_suffix"]).Trim()}";
										}
									}
								}
							}

							result = sNameStr.Trim();
							ado_rs.Close();

						}

						ado_rs = null;

					} // nContactID > 0

				} // inAircraftRefID > 0

				return result;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"get_contact_information_from_aircraft_reference_Error ({Information.Err().Number.ToString()}) {excep.Message}", "Company (modCompany)");
				return result;
			}
		}

		internal static bool no_current_company(int inCompanyId)
		{

			bool result = false;
			result = true;

			if (modAdminCommon.Exist($"SELECT comp_id FROM Company WITH(NOLOCK) WHERE comp_id = {inCompanyId.ToString()} AND comp_journ_id = 0"))
			{
				result = false;
			}

			return result;
		}

		internal static int get_country_timezone_adjustment(string in_country_name, string in_state_name, string in_timezone)
		{

			// Function used to Select time zone and calculate adjusted time related to east coast time
			int result = 0;
			try
			{

				string Query = "";
				ADORecordSetHelper adoTimeVSEastern = null;

				result = 0;

				//other countries added aey 1/14/05
				if ((((in_country_name.Trim().ToLower() == ("United States").ToLower() || in_country_name.Trim().ToLower() == ("Canada").ToLower() || in_country_name.Trim().ToLower() == ("Mexico").ToLower() || in_country_name.Trim().ToLower() == ("Guatemala").ToLower()) ? -1 : 0) | (((in_state_name.Trim().ToLower() != "") ? -1 : 0) & Convert.ToInt32(Double.Parse((in_timezone != "").ToString().Trim().ToLower())))) != 0)
				{

					Query = $"SELECT tzone_time_vs_eastern FROM TimeZone WITH (NOLOCK) WHERE (tzone_name = '{in_timezone.Trim()}')";

					adoTimeVSEastern = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

					if (!(adoTimeVSEastern.BOF && adoTimeVSEastern.EOF))
					{
						result = Convert.ToInt32(adoTimeVSEastern["tzone_time_vs_eastern"]);
						adoTimeVSEastern.Close();
					}

					adoTimeVSEastern = null;

				}
				else
				{
					// OUTSIDE THE UNITED STATES, THEN LOOKUP THE COUNTRY TIME ADJUSTMENT
					if (in_country_name.Trim() != "")
					{
						result = get_country_timeadjustment(modAdminCommon.Fix_Quote(in_country_name));
					}

				}

				return result;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"get_country_timezone_adjustment_Error ({Information.Err().Number.ToString()}) {excep.Message}", "Company (modCompany)");
				return result;
			}
		}

		private static int get_country_timeadjustment(string in_country_name)
		{

			// PURPOSE: THE PURPOSE OF THIS PROCEDURE IS TO SELECT THE TIME ADJUSTMENT
			// FOR THE COUNTRY WHEN OUTSIDE THE US

			int result = 0;
			try
			{

				string Query = "";
				ADORecordSetHelper adoCountryAdjust = null;

				result = 0;

				if (in_country_name.Trim() != "")
				{

					Query = $"SELECT country_time_vs_eastern FROM Country WITH(NOLOCK) WHERE country_name = '{in_country_name.Trim()}'";

					adoCountryAdjust = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(adoCountryAdjust.Fields) && !(adoCountryAdjust.BOF && adoCountryAdjust.EOF))
					{
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(adoCountryAdjust["country_time_vs_eastern"]))
						{
							if (Information.IsNumeric(adoCountryAdjust["country_time_vs_eastern"]))
							{
								result = Convert.ToInt32(adoCountryAdjust["country_time_vs_eastern"]);
								adoCountryAdjust.Close();
							}
						}
					}

				}

				adoCountryAdjust = null;

				return result;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"get_country_timeadjustment_Error ({Information.Err().Number.ToString()}) {excep.Message}", "Company (modCompany)");
				return result;
			}
		}

		internal static void fill_fractional_owner_contact_list(int in_CompanyID, int in_JournalID, int in_fractowr_contactID, ComboBox cbo_to_fill)
		{

			string Query = modGlobalVars.cEmptyString;
			StringBuilder Tname = new StringBuilder();
			Tname.Append(modGlobalVars.cEmptyString);
			ADORecordSetHelper ado_FractContact = null;

			try
			{

				cbo_to_fill.Enabled = false;
				cbo_to_fill.Items.Clear();
				cbo_to_fill.AddItem("No Contact Specified", 0);
				cbo_to_fill.SetItemData(cbo_to_fill.Items.Count - 1, 0);
				cbo_to_fill.SelectedIndex = -1;

				// RTW - MODIFIED ON 11/15/2011- ADDED INDEX TO QUERY PER DAVID THAT WAS PREVIOUSLY LOST
				Query = "SELECT contact_id, contact_sirname, contact_first_name, contact_middle_initial, contact_last_name, contact_suffix, contact_title";
				// 07/18/2019 - By David D. Cruger; Removed INDEX HINT

				Query = $"{Query} FROM Contact WITH (NOLOCK) WHERE contact_comp_id = {in_CompanyID.ToString()}";
				Query = $"{Query} AND contact_journ_id = {in_JournalID.ToString()}";
				Query = $"{Query} AND contact_hide_flag = 'N' AND contact_active_flag = 'Y'";

				ado_FractContact = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(ado_FractContact.Fields) && !(ado_FractContact.BOF && ado_FractContact.EOF))
				{

					while(!ado_FractContact.EOF)
					{

						Tname = new StringBuilder(modGlobalVars.cEmptyString);

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_FractContact["contact_sirname"]))
						{
							if (Convert.ToString(ado_FractContact["contact_sirname"]).Trim() != modGlobalVars.cEmptyString)
							{
								Tname = new StringBuilder($"{Convert.ToString(ado_FractContact["contact_sirname"]).Trim()}{modGlobalVars.cSingleSpace}");
							}
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_FractContact["contact_first_name"]))
						{
							if (Convert.ToString(ado_FractContact["contact_first_name"]).Trim() != modGlobalVars.cEmptyString)
							{
								Tname.Append($"{Convert.ToString(ado_FractContact["contact_first_name"]).Trim()}{modGlobalVars.cSingleSpace}");
							}
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_FractContact["contact_middle_initial"]))
						{
							if (Convert.ToString(ado_FractContact["contact_middle_initial"]).Trim() != modGlobalVars.cEmptyString)
							{
								Tname.Append($"{Convert.ToString(ado_FractContact["contact_middle_initial"]).Trim()}.{modGlobalVars.cSingleSpace}");
							}
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_FractContact["contact_last_name"]))
						{
							if (Convert.ToString(ado_FractContact["contact_last_name"]).Trim() != modGlobalVars.cEmptyString)
							{
								Tname.Append($"{Convert.ToString(ado_FractContact["contact_last_name"]).Trim()}{modGlobalVars.cSingleSpace}");
							}
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_FractContact["contact_suffix"]))
						{
							if (Convert.ToString(ado_FractContact["contact_suffix"]).Trim() != modGlobalVars.cEmptyString)
							{
								Tname.Append($"{Convert.ToString(ado_FractContact["contact_suffix"]).Trim()}{modGlobalVars.cSingleSpace}");
							}
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_FractContact["contact_title"]))
						{
							if (Convert.ToString(ado_FractContact["contact_title"]).Trim() != modGlobalVars.cEmptyString)
							{
								Tname.Append($"({Convert.ToString(ado_FractContact["contact_title"]).Trim()})");
							}
						}

						cbo_to_fill.AddItem(Tname.ToString().Trim());
						cbo_to_fill.SetItemData(cbo_to_fill.Items.Count - 1, Convert.ToInt32(ado_FractContact["contact_id"]));

						if (Convert.ToInt32(ado_FractContact["contact_id"]) == in_fractowr_contactID)
						{
							cbo_to_fill.SelectedIndex = cbo_to_fill.Items.Count - 1;
						}

						ado_FractContact.MoveNext();
					};

					ado_FractContact.Close();

				}

				cbo_to_fill.Enabled = true;

				ado_FractContact = null;
			}
			catch (System.Exception excep)
			{

				cbo_to_fill.Enabled = false;
				ado_FractContact = null;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"fill_fractional_owner_contact_list_Error ({Information.Err().Number.ToString()}) {excep.Message}", "Company (modCompany)");
				return;
			}

		}

		internal static void fill_verify_contact_list(int in_CompanyID, int in_JournalID, int in_verify_contactID, ComboBox cbo_to_fill)
		{
			// need to fix

			try
			{
				string Query = "";
				Query = modGlobalVars.cEmptyString;
				StringBuilder Tname = new StringBuilder();
				Tname = new StringBuilder(modGlobalVars.cEmptyString);
				ADORecordSetHelper ado_otherContact = null;

				cbo_to_fill.Enabled = false;
				cbo_to_fill.Items.Clear();
				cbo_to_fill.AddItem("Add New Contact", 0);
				cbo_to_fill.SetItemData(cbo_to_fill.Items.Count - 1, 0);
				cbo_to_fill.SelectedIndex = -1;

				Query = "SELECT contact_id, contact_sirname, contact_first_name, contact_middle_initial, contact_last_name, contact_suffix, contact_title";
				Query = $"{Query} FROM Contact WITH(NOLOCK) WHERE contact_comp_id = {in_CompanyID.ToString()}";
				Query = $"{Query} AND contact_journ_id = {in_JournalID.ToString()}";
				Query = $"{Query} AND contact_active_flag = 'Y'  ORDER BY contact_first_name, contact_last_name, contact_middle_initial";

				ado_otherContact = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(ado_otherContact.Fields) && !(ado_otherContact.BOF && ado_otherContact.EOF))
				{

					while(!ado_otherContact.EOF)
					{

						Tname = new StringBuilder(modGlobalVars.cEmptyString);



						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_otherContact["contact_first_name"]))
						{
							if (Convert.ToString(ado_otherContact["contact_first_name"]).Trim() != modGlobalVars.cEmptyString)
							{
								Tname.Append($"{Convert.ToString(ado_otherContact["contact_first_name"]).Trim()}{modGlobalVars.cSingleSpace}");
							}
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_otherContact["contact_middle_initial"]))
						{
							if (Convert.ToString(ado_otherContact["contact_middle_initial"]).Trim() != modGlobalVars.cEmptyString)
							{
								Tname.Append($"{Convert.ToString(ado_otherContact["contact_middle_initial"]).Trim()}.{modGlobalVars.cSingleSpace}");
							}
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_otherContact["contact_last_name"]))
						{
							if (Convert.ToString(ado_otherContact["contact_last_name"]).Trim() != modGlobalVars.cEmptyString)
							{
								Tname.Append($"{Convert.ToString(ado_otherContact["contact_last_name"]).Trim()}{modGlobalVars.cSingleSpace}");
							}
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_otherContact["contact_suffix"]))
						{
							if (Convert.ToString(ado_otherContact["contact_suffix"]).Trim() != modGlobalVars.cEmptyString)
							{
								Tname.Append($"{Convert.ToString(ado_otherContact["contact_suffix"]).Trim()}{modGlobalVars.cSingleSpace}");
							}
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_otherContact["contact_title"]))
						{
							if (Convert.ToString(ado_otherContact["contact_title"]).Trim() != modGlobalVars.cEmptyString)
							{
								Tname.Append($"[{Convert.ToString(ado_otherContact["contact_title"]).Trim()}]");
							}
						}

						cbo_to_fill.AddItem(Tname.ToString().Trim());
						cbo_to_fill.SetItemData(cbo_to_fill.Items.Count - 1, Convert.ToInt32(ado_otherContact["contact_id"]));

						if (in_verify_contactID > 0)
						{
							if (Convert.ToInt32(ado_otherContact["contact_id"]) == in_verify_contactID)
							{
								cbo_to_fill.SelectedIndex = cbo_to_fill.Items.Count - 1;
							}
						}

						ado_otherContact.MoveNext();
					};

					ado_otherContact.Close();

				}

				cbo_to_fill.Enabled = true;
				ado_otherContact = null;
			}
			catch (System.Exception excep)
			{

				cbo_to_fill.Enabled = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"fill_verify_contact_list_Error ({Information.Err().Number.ToString()}) {excep.Message}", "Company (modCompany)");
				return;
			}

		}

		internal static void fill_related_company_contact_list(int in_CompanyID, int in_JournalID, int in_related_contactID, ComboBox cbo_to_fill)
		{

			string Query = modGlobalVars.cEmptyString;
			StringBuilder Tname = new StringBuilder();
			Tname.Append(modGlobalVars.cEmptyString);
			ADORecordSetHelper ado_relatedContact = null;

			try
			{

				cbo_to_fill.Visible = false;
				cbo_to_fill.Enabled = false;
				cbo_to_fill.Items.Clear();
				cbo_to_fill.AddItem("", 0);
				cbo_to_fill.SetItemData(cbo_to_fill.Items.Count - 1, 0);
				cbo_to_fill.SelectedIndex = -1;

				Query = "SELECT contact_id, contact_sirname, contact_first_name, contact_middle_initial, contact_last_name, contact_suffix, contact_title";
				Query = $"{Query} FROM Company WITH(NOLOCK), Contact WITH(NOLOCK)";

				if (in_related_contactID > 0)
				{
					Query = $"{Query} WHERE contact_journ_id = {in_JournalID.ToString()}"; // contact_id = " & CStr(in_related_contactID) & " AND
					Query = $"{Query} AND contact_comp_id = comp_id AND contact_journ_id = comp_journ_id AND contact_active_flag = 'Y'";
					Query = $"{Query} and contact_comp_id = {in_CompanyID.ToString()} ";
				}
				else
				{
					Query = $"{Query} WHERE contact_comp_id = {in_CompanyID.ToString()} AND contact_journ_id = {in_JournalID.ToString()}";
					Query = $"{Query} AND contact_comp_id = comp_id AND contact_journ_id = comp_journ_id AND contact_active_flag = 'Y'";
				}

				ado_relatedContact = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(ado_relatedContact.Fields) && !(ado_relatedContact.BOF && ado_relatedContact.EOF))
				{

					while(!ado_relatedContact.EOF)
					{

						Tname = new StringBuilder(modGlobalVars.cEmptyString);

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_relatedContact["contact_first_name"]))
						{
							if (Convert.ToString(ado_relatedContact["contact_first_name"]).Trim() != modGlobalVars.cEmptyString)
							{
								Tname.Append($"{Convert.ToString(ado_relatedContact["contact_first_name"]).Trim()}{modGlobalVars.cSingleSpace}");
							}
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_relatedContact["contact_middle_initial"]))
						{
							if (Convert.ToString(ado_relatedContact["contact_middle_initial"]).Trim() != modGlobalVars.cEmptyString)
							{
								Tname.Append($"{Convert.ToString(ado_relatedContact["contact_middle_initial"]).Trim()}.{modGlobalVars.cSingleSpace}");
							}
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_relatedContact["contact_last_name"]))
						{
							if (Convert.ToString(ado_relatedContact["contact_last_name"]).Trim() != modGlobalVars.cEmptyString)
							{
								Tname.Append($"{Convert.ToString(ado_relatedContact["contact_last_name"]).Trim()}{modGlobalVars.cSingleSpace}");
							}
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_relatedContact["contact_suffix"]))
						{
							if (Convert.ToString(ado_relatedContact["contact_suffix"]).Trim() != modGlobalVars.cEmptyString)
							{
								Tname.Append($"{Convert.ToString(ado_relatedContact["contact_suffix"]).Trim()}{modGlobalVars.cSingleSpace}");
							}
						}


						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_relatedContact["contact_sirname"]))
						{
							if (Convert.ToString(ado_relatedContact["contact_sirname"]).Trim() != modGlobalVars.cEmptyString)
							{
								Tname.Append($" ({Convert.ToString(ado_relatedContact["contact_sirname"]).Trim()}){modGlobalVars.cSingleSpace}");
							}
						}


						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_relatedContact["contact_title"]))
						{
							if (Convert.ToString(ado_relatedContact["contact_title"]).Trim() != modGlobalVars.cEmptyString)
							{
								Tname.Append($"[{Convert.ToString(ado_relatedContact["contact_title"]).Trim()}]");
							}
						}


						cbo_to_fill.AddItem(Tname.ToString().Trim());
						cbo_to_fill.SetItemData(cbo_to_fill.Items.Count - 1, Convert.ToInt32(ado_relatedContact["contact_id"]));

						if (Convert.ToInt32(ado_relatedContact["contact_id"]) == in_related_contactID)
						{
							cbo_to_fill.SelectedIndex = cbo_to_fill.Items.Count - 1;
						}

						ado_relatedContact.MoveNext();
					};





					cbo_to_fill.Visible = true;
					cbo_to_fill.Enabled = true;

					ado_relatedContact.Close();
				}
				else
				{
					// make the blank visisble
					cbo_to_fill.Visible = true;
					cbo_to_fill.Enabled = true;
				}

				ado_relatedContact = null;
			}
			catch (System.Exception excep)
			{

				cbo_to_fill.Enabled = false;
				ado_relatedContact = null;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"fill_related_company_contact_list_Error ({Information.Err().Number.ToString()}) {excep.Message}", "Company (modCompany)");
				return;
			}

		}

		internal static bool update_aircraft_research_contact(int in_CompanyID, int in_JournalID, int in_AircraftID, string in_newContactName, int in_newContactID, string in_oldContactName, int in_oldContactID, string in_oldContactType, int in_oldContactSeq, int in_fractOwnerID, bool bChangeSameTypeOnly)
		{

			// Function used to update aircraft research contact

			bool result = false;
			string upQuery = "";
			string transQuery = "";
			string[] arrTransFlds = null;
			ADORecordSetHelper ado_ACUpdate = null;

			try
			{

				if (in_oldContactName.Trim() == modGlobalVars.cEmptyString && in_AircraftID > 0)
				{
					in_oldContactName = "[Blank]";
				}

				upQuery = $"UPDATE Aircraft_Reference SET cref_contact_id = {in_newContactID.ToString()}";

				if (in_AircraftID > 0)
				{ // we are changing contact on this aircraft

					upQuery = $"{upQuery} WHERE cref_ac_id = {in_AircraftID.ToString()}";
					upQuery = $"{upQuery} AND cref_transmit_seq_no = {in_oldContactSeq.ToString()}";

					if (bChangeSameTypeOnly)
					{ // we only want to change same contact type only
						upQuery = $"{upQuery} AND cref_contact_type = '{in_oldContactType}'";
					}

					//       If in_oldContactType <> "OWNER" Then

					//       Else
					//           upQuery = upQuery & " AND cref_contact_type = '00'"
					//       End If
					//
					upQuery = $"{upQuery} AND cref_comp_id = {in_CompanyID.ToString()} AND cref_journ_id = {in_JournalID.ToString()}";

				}
				else
				{

					upQuery = $"{upQuery} WHERE cref_comp_id = {in_CompanyID.ToString()} AND cref_journ_id = {in_JournalID.ToString()}";

					if (bChangeSameTypeOnly)
					{ // we only want to change same contact type only
						upQuery = $"{upQuery} AND cref_contact_type = '{in_oldContactType}'";
					}

				} //in_aircraftID > 0


				modAdminCommon.ADO_Transaction("BeginTrans");

				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = upQuery;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = (CommandType) (((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()) + ((int) CommandType.Text));
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();

				// CLEAR THE ACTION DATE ON THE AIRCRAFT SINCE A CONTACT HAS BEEN CHANGED

				if (in_AircraftID > 0)
				{

					upQuery = $"UPDATE Aircraft SET ac_action_date = NULL  WHERE ac_id = {in_AircraftID.ToString()}";
					upQuery = $"{upQuery} AND ac_journ_id = {in_JournalID.ToString()}";

					// ok now use the records we just updated to send out transmits
					transQuery = $"SELECT ac_id FROM Aircraft WITH(NOLOCK)  WHERE ac_id = {in_AircraftID.ToString()}";
					transQuery = $"{transQuery} AND ac_journ_id = {in_JournalID.ToString()} AND ac_action_date IS NULL";

				}
				else
				{

					upQuery = "UPDATE Aircraft SET ac_action_date = NULL WHERE ac_id IN (SELECT cref_ac_id FROM Aircraft_Reference WITH(NOLOCK)";
					upQuery = $"{upQuery} WHERE cref_comp_id = {in_CompanyID.ToString()}";
					upQuery = $"{upQuery} AND cref_journ_id = {in_JournalID.ToString()})  AND ac_journ_id = {in_JournalID.ToString()}";

					// ok now use the records we just updated to send out transmits
					transQuery = "SELECT ac_id FROM Aircraft WITH(NOLOCK)  WHERE ac_id IN (SELECT cref_ac_id FROM Aircraft_Reference WITH(NOLOCK)";
					transQuery = $"{transQuery} WHERE cref_comp_id = {in_CompanyID.ToString()} AND cref_journ_id = {in_JournalID.ToString()})";
					transQuery = $"{transQuery} AND ac_journ_id = {in_JournalID.ToString()} AND ac_action_date IS NULL";
				}

				DbCommand TempCommand_2 = null;
				TempCommand_2 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
				TempCommand_2.CommandText = upQuery;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand_2.CommandType = (CommandType) (((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()) + ((int) CommandType.Text));
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
				TempCommand_2.ExecuteNonQuery();

				add_items_to_array_fields(ref arrTransFlds, "contact_name");
				add_items_to_array_fields(ref arrTransFlds, "contact_phone1");
				add_items_to_array_fields(ref arrTransFlds, "contact_phone2");
				add_items_to_array_fields(ref arrTransFlds, "contact_email_address");

				ado_ACUpdate = ADORecordSetHelper.Open(transQuery, modAdminCommon.LOCAL_ADO_DB, "");

				if (!(ado_ACUpdate.BOF && ado_ACUpdate.EOF))
				{


					while(!ado_ACUpdate.EOF)
					{
						modCommon.Record_CompanyContact_Aircraft_Transmits("Contact", "Change", in_CompanyID, in_newContactID, in_JournalID, ref arrTransFlds, Convert.ToInt32(ado_ACUpdate["ac_id"]), in_oldContactType, in_fractOwnerID.ToString());
						// process transmits

						ado_ACUpdate.MoveNext();

					};
					ado_ACUpdate.Close();

				}

				ado_ACUpdate = null;

				// CREATE A JOURNAL ENTRY DOCUMENTING THE CHANGE
				modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTimeHelper.ToString(DateTime.Now));
				modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "RN";
				modAdminCommon.Rec_Journal_Info.journ_subject = $"Changed Contact to {((in_newContactName.Trim() != "") ? in_newContactName : "[Blank]")}{((in_oldContactName.Trim() != "") ? $" From {in_oldContactName.Trim()}" : "")}";
				modAdminCommon.Rec_Journal_Info.journ_description = modGlobalVars.cEmptyString;

				if (in_AircraftID > 0)
				{
					modAdminCommon.Rec_Journal_Info.journ_ac_id = in_AircraftID;
				}
				else
				{
					modAdminCommon.Rec_Journal_Info.journ_ac_id = 0;
				}

				modAdminCommon.Rec_Journal_Info.journ_comp_id = in_CompanyID;
				modAdminCommon.Rec_Journal_Info.journ_contact_id = in_newContactID;
				modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
				modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
				modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
				modAdminCommon.Rec_Journal_Info.journ_status = "A";

				frm_Journal.DefInstance.Commit_Journal_Entry();

				modAdminCommon.ADO_Transaction("CommitTrans");

				return true;
			}
			catch (System.Exception excep)
			{

				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"update_aircraft_research_contact_Error ({Information.Err().Number.ToString()}) {excep.Message}", "Company (modCompany)");
				modAdminCommon.ADO_Transaction("RollbackTrans");
				return result;
			}
		}

		internal static bool update_internal_flag(CheckBox in_ChkBox, int in_CompanyID)
		{

			bool result = false;
			string sQuery = "";

			try
			{

				sQuery = "UPDATE Company_Reference SET compref_internal_flag = '";

				if (in_ChkBox.CheckState == CheckState.Checked)
				{
					sQuery = $"{sQuery}Y";
				}
				else
				{
					sQuery = $"{sQuery}N";
				}

				sQuery = $"{sQuery}' WHERE compref_key = {in_CompanyID.ToString()}";

				modAdminCommon.ADO_Transaction("BeginTrans");
				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = sQuery;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = (CommandType) (((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()) + ((int) CommandType.Text));
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();
				modAdminCommon.ADO_Transaction("CommitTrans");


				return true;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"update_internal_flag_Error ({Information.Err().Number.ToString()}) {excep.Message}", "Company (modCompany)");
				modAdminCommon.ADO_Transaction("RollbackTrans");
				return result;
			}
		}

		internal static string get_share_company_info(int inCompany_ID)
		{
			//
			// THE PURPOSE OF THIS FUNCTION IS TO LOOKUP AND RETURN
			// COMPANY AND PHONE NUMBER INFORMATION FOR COMPANIES RELATED TO SHARES.
			string result = "";
			try
			{

				string Query = "";
				ADORecordSetHelper ado_ShareComp = null;
				ADORecordSetHelper ado_SharePhones = null;

				result = modGlobalVars.cEmptyString;

				if (inCompany_ID > 0)
				{

					Query = $"SELECT comp_name, comp_city, comp_state FROM Company WITH(NOLOCK) WHERE comp_id = {inCompany_ID.ToString()}";
					Query = $"{Query} AND comp_journ_id = 0";

					ado_ShareComp = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(ado_ShareComp.Fields) && !(ado_ShareComp.BOF && ado_ShareComp.EOF))
					{

						result = "Unknown";
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_ShareComp["comp_name"]))
						{
							if (Convert.ToString(ado_ShareComp["comp_name"]).Trim() != modGlobalVars.cEmptyString)
							{
								result = Convert.ToString(ado_ShareComp["comp_name"]).Trim();
							}
						}

						result = $"{result} (";

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_ShareComp["comp_city"]))
						{
							if (Convert.ToString(ado_ShareComp["comp_city"]).Trim() != modGlobalVars.cEmptyString)
							{
								result = $"{result}{Convert.ToString(ado_ShareComp["comp_city"]).Trim()}";
							}
						}
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_ShareComp["comp_state"]))
						{
							if (Convert.ToString(ado_ShareComp["comp_state"]).Trim() != modGlobalVars.cEmptyString)
							{
								result = $"{result}, {Convert.ToString(ado_ShareComp["comp_state"]).Trim()}";
							}
						}

						result = $"{result})";

						// GET PHONE NUMBERS FOR COMPANY
						// MSW  - 2/28/2012 - CHANGED QUERY TO USE FULL INDEX - TEMP HOLD - NO CONTACT
						Query = $"SELECT pnum_type, pnum_number_full  FROM Phone_Numbers WITH(NOLOCK) WHERE pnum_comp_id = {inCompany_ID.ToString()}";
						Query = $"{Query} AND pnum_journ_id = 0 AND pnum_contact_id = 0";

						ado_SharePhones = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_SharePhones.Fields) && !(ado_SharePhones.BOF && ado_SharePhones.EOF))
						{

							result = $"{result} Phone(s):";


							while(!ado_SharePhones.EOF)
							{

								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(ado_SharePhones["pnum_type"]))
								{
									if (Convert.ToString(ado_SharePhones["pnum_type"]).Trim() != modGlobalVars.cEmptyString)
									{
										result = $"{result}{Convert.ToString(ado_SharePhones["pnum_type"]).Trim()}";
									}
								}
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(ado_SharePhones["pnum_number_full"]))
								{
									if (Convert.ToString(ado_SharePhones["pnum_number_full"]).Trim() != modGlobalVars.cEmptyString)
									{
										result = $"{result} {Convert.ToString(ado_SharePhones["pnum_number_full"]).Trim()}";
									}
								}

								ado_SharePhones.MoveNext();

							};

							ado_SharePhones.Close();

						} // Not IsNull(ado_SharePhones) And Not (ado_SharePhones.BOF And ado_SharePhones.EOF)

						ado_SharePhones = null;

						ado_ShareComp.Close();

					} //  Not IsNull(ado_ShareComp) And Not (ado_ShareComp.BOF And ado_ShareComp.EOF)

				} // inCompany_ID > 0

				result = result.Trim();

				ado_ShareComp = null;

				return result;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"get_share_company_info_Error ({Information.Err().Number.ToString()}) {excep.Message}", "Company (modCompany)");
				return result;
			}
		}

		internal static string get_aircraft_contact_type(string inCtype)
		{

			string result = "";
			try
			{

				string Query = "";
				ADORecordSetHelper adoConTypeRS = null;

				result = modGlobalVars.cEmptyString;

				Query = $"SELECT actype_abbrev FROM Aircraft_Contact_Type WITH(NOLOCK) WHERE actype_code = '{inCtype.Trim()}'";

				adoConTypeRS = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(adoConTypeRS.Fields) && !(adoConTypeRS.BOF && adoConTypeRS.EOF))
				{
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(adoConTypeRS["actype_abbrev"]))
					{
						if (Convert.ToString(adoConTypeRS["actype_abbrev"]).Trim() != modGlobalVars.cEmptyString)
						{
							result = Convert.ToString(adoConTypeRS["actype_abbrev"]).Trim();
						}
					}
					adoConTypeRS.Close();
				}

				adoConTypeRS = null;

				return result;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"get_aircraft_contact_type_Error ({Information.Err().Number.ToString()}) {excep.Message}", "Company (modCompany)");
				return result;
			}
		}

		internal static string get_aircraft_contact_code(string inCtype)
		{

			string result = "";
			try
			{

				string Query = "";
				ADORecordSetHelper adoConCodeRS = null;

				result = modGlobalVars.cEmptyString;

				Query = $"SELECT actype_code FROM Aircraft_Contact_Type WITH(NOLOCK) WHERE actype_abbrev = '{inCtype.Trim()}'";

				adoConCodeRS = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(adoConCodeRS.Fields) && !(adoConCodeRS.BOF && adoConCodeRS.EOF))
				{
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(adoConCodeRS["actype_code"]))
					{
						if (Convert.ToString(adoConCodeRS["actype_code"]).Trim() != modGlobalVars.cEmptyString)
						{
							result = Convert.ToString(adoConCodeRS["actype_code"]).Trim();
						}
					}
					adoConCodeRS.Close();
				}

				adoConCodeRS = null;

				return result;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"get_aircraft_contact_code_Error ({Information.Err().Number.ToString()}) {excep.Message}", "Company (modCompany)");
				return result;
			}
		}

		internal static string get_make_model(int inModel_ID)
		{

			//Function used to select class 'A' aircraft

			string result = "";
			string Query = "";
			ADORecordSetHelper adoModNames = null;

			result = "Not Found!";

			try
			{

				Query = $"SELECT amod_make_name, amod_model_name FROM Aircraft_Model WITH(NOLOCK) WHERE amod_id = {inModel_ID.ToString()}";

				adoModNames = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(adoModNames.Fields) && !(adoModNames.BOF && adoModNames.EOF))
				{
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(adoModNames["amod_make_name"]))
					{
						if (Convert.ToString(adoModNames["amod_make_name"]).Trim() != modGlobalVars.cEmptyString)
						{
							result = Convert.ToString(adoModNames["amod_make_name"]).Trim();
						}
					}
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(adoModNames["amod_model_name"]))
					{
						if (Convert.ToString(adoModNames["amod_model_name"]).Trim() != modGlobalVars.cEmptyString)
						{
							result = $"{result}/{Convert.ToString(adoModNames["amod_model_name"]).Trim()}";
						}
					}
					adoModNames.Close();
				}

				adoModNames = null;

				return result;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"get_make_model_Error ({Information.Err().Number.ToString()}) {excep.Message}", "Company (modCompany)");
				return result;
			}
		}

		internal static bool has_aircraft_been_verified(int in_AircraftID, string[] in_arrAircraft)
		{

			bool result = false;
			int nLoop = 0;

			// array has to be initilaized inorder to do this
			nLoop = in_arrAircraft.GetUpperBound(0);

			if (nLoop > 0)
			{
				int tempForEndVar = in_arrAircraft.GetUpperBound(0);
				for (nLoop = 0; nLoop <= tempForEndVar; nLoop++)
				{
					if (Convert.ToInt32(Conversion.Val(in_arrAircraft[nLoop])) == in_AircraftID)
					{
						result = true;
						break;
					}
				}
			}

			return result;
		}

		internal static bool has_wanted_been_verified(int in_AircraftID, string[] in_arrWantedAircraft)
		{

			bool result = false;
			int nLoop = 0;

			// array has to be initilaized inorder to do this
			nLoop = in_arrWantedAircraft.GetUpperBound(0);

			if (nLoop > 0)
			{
				int tempForEndVar = in_arrWantedAircraft.GetUpperBound(0);
				for (nLoop = 0; nLoop <= tempForEndVar; nLoop++)
				{
					if (Convert.ToInt32(Conversion.Val(in_arrWantedAircraft[nLoop])) == in_AircraftID)
					{
						result = true;
						break;
					}
				}
			}

			return result;
		}

		internal static bool has_item_been_added(string in_Item, string[] in_arrItems)
		{

			bool result = false;
			int nLoop = 0;

			// array has to be initilaized inorder to do this
			nLoop = in_arrItems.GetUpperBound(0);

			if (nLoop > 0)
			{
				int tempForEndVar = in_arrItems.GetUpperBound(0);
				for (nLoop = 0; nLoop <= tempForEndVar; nLoop++)
				{
					if (in_arrItems[nLoop].Trim() == in_Item.Trim())
					{
						result = true;
						break;
					}
				}
			}

			return result;
		}

		internal static bool verify_aircraft_status(int in_CompanyID, int in_AircraftID, int in_ContactID, int in_JournalID, ref string inJournSubjectCbo, string inNoteTypeCbo, ComboBox inContactCbo, ComboBox inAircraftCbo, int inSelJournalOpt, int inSelAircraftOpt, UpgradeHelpers.DataGridViewFlex inAircraftGrd, ref string[] inArrConfirmAircraft, string in_verifyText, int yacht_id = 0, string yacht_info_string = "", string ac_list = "", string journ_description = "", string from_spot = "")
		{

			// PURPOSE: THE PURPOSE OF THIS FUNCTION IS TO VERIFY THE STATUS OF
			//          A SINGLE AIRCRAFT OR ALL AIRCRAFT IN THE COMPANY LIST
			//          THAT THE COMPANY IS PRIMARY FOR OR TO JUST ADD A RESEARCH NOTE

			bool result = false;
			try
			{
				result = false;

				string Query = "";
				bool bAlreadyVerifiedFlag = false;
				bAlreadyVerifiedFlag = false;
				int nGridCol = 0;
				nGridCol = 0;
				string strOwner = "";
				strOwner = "";
				ADORecordSetHelper ado_PrimaryAircaft = null;
				int intExclusiveVerifyDays = 0;


				switch(in_verifyText.ToUpper())
				{
					case "OWNER" : 
						if (in_AircraftID > 0 || yacht_id > 0)
						{
							if (in_AircraftID > 0)
							{
								modAdminCommon.ADO_Transaction("BeginTrans");

								modAdminCommon.Rec_Journal_Info.journ_subject = "Verified Aircraft Ownership";
								modAdminCommon.Rec_Journal_Info.journ_description = StringsHelper.Replace(journ_description, "'", "''", 1, -1, CompareMethod.Binary);
								modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "VAO";
								modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTimeHelper.ToString(DateTime.Now));
								modAdminCommon.Rec_Journal_Info.journ_ac_id = in_AircraftID;
								modAdminCommon.Rec_Journal_Info.journ_comp_id = in_CompanyID;
								modAdminCommon.Rec_Journal_Info.journ_contact_id = in_ContactID;
								modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
								modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
								modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
								modAdminCommon.Rec_Journal_Info.journ_status = "A";

								frm_Journal.DefInstance.Commit_Journal_Entry();


								// ADDED MSW - 3/18/20 so that verifying owner also clears the re-assign
								Query = $" EXEC HomebaseClearAircraftReassigns {in_AircraftID.ToString()},' ','{modAdminCommon.gbl_Account_ID}','{modAdminCommon.gbl_User_ID}'";
								DbCommand TempCommand = null;
								TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
								UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
								TempCommand.CommandText = Query;
								//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
								//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
								TempCommand.CommandType = (CommandType) (((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()) + ((int) CommandType.Text));
								UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
								TempCommand.ExecuteNonQuery();
								Query = "";


								modAdminCommon.ADO_Transaction("CommitTrans");

							}
							else if (yacht_id > 0)
							{ 
								modAdminCommon.ADO_Transaction("BeginTrans");

								modAdminCommon.Rec_Journal_Info.journ_subject = "Verified Yacht Ownership";

								// added in MSW - 7/27/18
								journ_description = "Verified Yacht Owner as ";
								journ_description = $"{journ_description}{inContactCbo.Text}";
								journ_description = $"{journ_description} - {get_yacht_name_mfr(yacht_id)}";

								modAdminCommon.Rec_Journal_Info.journ_description = journ_description;


								modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "VYO";
								modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTimeHelper.ToString(DateTime.Now));
								modAdminCommon.Rec_Journal_Info.journ_ac_id = in_AircraftID;
								modAdminCommon.Rec_Journal_Info.journ_comp_id = in_CompanyID;
								modAdminCommon.Rec_Journal_Info.journ_contact_id = in_ContactID;
								modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
								modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
								modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
								modAdminCommon.Rec_Journal_Info.journ_status = "A";
								modAdminCommon.Rec_Journal_Info.journ_yacht_id = yacht_id;

								frm_Journal.DefInstance.Commit_Journal_Entry();

								modAdminCommon.ADO_Transaction("CommitTrans");
							}
						} 
						break;
					case "ONE" : 
						// USER DESIRES TO VERIFY ONE AIRCRAFT ONLY 
						if (in_AircraftID > 0 || yacht_id > 0)
						{

							bAlreadyVerifiedFlag = has_aircraft_been_verified(in_AircraftID, inArrConfirmAircraft);

							if (!bAlreadyVerifiedFlag)
							{

								modAdminCommon.ADO_Transaction("BeginTrans");

								add_items_to_array_fields(ref inArrConfirmAircraft, in_AircraftID.ToString());

								// COMMENTED OUT MSW - SEEMS TO WORK BETTER WITHOUT SETTING COLUMN - 11/21/18
								nGridCol = inAircraftGrd.CurrentColumnIndex;


								if (from_spot == "COMP")
								{
									inAircraftGrd.CurrentColumnIndex = 8;
								}
								else
								{
									inAircraftGrd.CurrentColumnIndex = 1;
								}

								if (ColorTranslator.ToOle(inAircraftGrd.CellBackColor).ToString() == modAdminCommon.ExclusiveColor)
								{

									// IF EXCLUSIVE THEN UPDATE THE EXCLUSIVE VERIFICATION DATE
									// RTW MODIFIED THE EXLUSIVE VERIFY DAYS TO 90 PER JACKIE REQUEST ON 12/23/2015 - WAS SET TO gbl_ConfirmDays
									intExclusiveVerifyDays = 90;
									Query = $"UPDATE Aircraft SET ac_exclusive_verify_date = '{DateTimeHelper.ToString(DateTime.Parse(DateTimeHelper.ToString(DateTime.Now)).AddDays(intExclusiveVerifyDays))}'";
									Query = $"{Query} WHERE ac_id = {in_AircraftID.ToString()} AND ac_journ_id = {in_JournalID.ToString()}";

									DbCommand TempCommand_2 = null;
									TempCommand_2 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
									UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
									TempCommand_2.CommandText = Query;
									//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
									//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
									TempCommand_2.CommandType = (CommandType) (((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()) + ((int) CommandType.Text));
									UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
									TempCommand_2.ExecuteNonQuery();

									// RECORD A VERIFY EXCLUSIVE STATUS JOURNAL ENTRY
									modAdminCommon.Rec_Journal_Info.journ_subject = "Verified Exclusive Status";
									modAdminCommon.Rec_Journal_Info.journ_description = StringsHelper.Replace(journ_description, "'", "''", 1, -1, CompareMethod.Binary);
									modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "VS";
									modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTimeHelper.ToString(DateTime.Now));
									modAdminCommon.Rec_Journal_Info.journ_ac_id = in_AircraftID;
									modAdminCommon.Rec_Journal_Info.journ_comp_id = in_CompanyID;
									modAdminCommon.Rec_Journal_Info.journ_contact_id = in_ContactID;
									modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
									modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
									modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
									modAdminCommon.Rec_Journal_Info.journ_status = "A";

									frm_Journal.DefInstance.Commit_Journal_Entry();
								}
								else if (inAircraftGrd[inAircraftGrd.CurrentRowIndex, inAircraftGrd.CurrentColumnIndex].FormattedValue.ToString() == "Non-Exclusive Sales Contact" || inAircraftGrd[inAircraftGrd.CurrentRowIndex, inAircraftGrd.CurrentColumnIndex].FormattedValue.ToString() == "Sales Company/Contact")
								{ 


									if (inAircraftGrd[inAircraftGrd.CurrentRowIndex, inAircraftGrd.CurrentColumnIndex].FormattedValue.ToString().Trim() == "Non-Exclusive Sales Contact")
									{
										modAdminCommon.Rec_Journal_Info.journ_subject = "Verified as Non-Exclusive Sales Contact";
									}
									else
									{
										modAdminCommon.Rec_Journal_Info.journ_subject = "Verified as Sales Company/Contact";
									}

									modAdminCommon.Rec_Journal_Info.journ_description = StringsHelper.Replace(journ_description, "'", "''", 1, -1, CompareMethod.Binary);
									modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "VS";
									modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTimeHelper.ToString(DateTime.Now));
									modAdminCommon.Rec_Journal_Info.journ_ac_id = in_AircraftID;
									modAdminCommon.Rec_Journal_Info.journ_comp_id = in_CompanyID;
									modAdminCommon.Rec_Journal_Info.journ_contact_id = in_ContactID;
									modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
									modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
									modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
									modAdminCommon.Rec_Journal_Info.journ_status = "A";

									frm_Journal.DefInstance.Commit_Journal_Entry();


								}
								else
								{
									// NOT EXCLUSIVE

									// VERIFY THE AIRCRAFT
									Query = $"EXEC HomebaseVerifyAircraft {in_AircraftID.ToString()},{in_CompanyID.ToString()},{in_ContactID.ToString()},{in_JournalID.ToString()},'{modAdminCommon.gbl_User_ID}','{modAdminCommon.gbl_Account_ID}','{StringsHelper.Replace(journ_description, "'", "''", 1, -1, CompareMethod.Binary).Trim()}' ";
									DbCommand TempCommand_3 = null;
									TempCommand_3 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
									UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_3);
									TempCommand_3.CommandText = Query;
									//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
									//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
									TempCommand_3.CommandType = (CommandType) (((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()) + ((int) CommandType.Text));
									UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_3);
									TempCommand_3.ExecuteNonQuery();

								} // inAircraftGrd.CellBackColor = PrimaryColor

								inAircraftGrd.CurrentColumnIndex = nGridCol;

								modAdminCommon.ADO_Transaction("CommitTrans");

							} //Not AlreadyVerifiedFlag

						}  // in_AircraftID > 0 
						 
						break;
					case "ALL" : case "ROTARY" : case "FIXED" : case "AVAILABLE" : 
						 
						Query = "SELECT distinct ac_id FROM Aircraft WITH(NOLOCK), Aircraft_Model WITH(NOLOCK), Aircraft_Reference WITH(NOLOCK)"; 
						Query = $"{Query} WHERE cref_comp_id = {in_CompanyID.ToString()} AND cref_journ_id = {in_JournalID.ToString()}"; 
						Query = $"{Query} AND cref_ac_id = ac_id AND cref_journ_id = ac_journ_id AND ac_amod_id = amod_id AND cref_primary_poc_flag = 'Y'"; 
						//' RTW - TEMP HOLD - REMOVED CRITERIA FOR CLASS A ON HELICOPTERS. 
						if (in_verifyText.ToUpper() == "FIXED")
						{
							Query = $"{Query} AND amod_airframe_type_code = 'F'";
						}
						else if (in_verifyText.ToUpper() == "ROTARY")
						{ 
							Query = $"{Query} AND (amod_airframe_type_code = 'R')";
						}
						else if (in_verifyText.ToUpper() == "ALL")
						{ 
							Query = $"{Query} AND (amod_airframe_type_code = 'F' OR amod_airframe_type_code = 'R')";
						}
						else if (in_verifyText.ToUpper() == "AVAILABLE")
						{ 
							Query = $"{Query} AND ac_forsale_flag = 'Y'  ";
						} 
						 
						ado_PrimaryAircaft = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, ""); 
						 
						if (!(ado_PrimaryAircaft.BOF && ado_PrimaryAircaft.EOF))
						{

							modAdminCommon.ADO_Transaction("BeginTrans");


							while(!ado_PrimaryAircaft.EOF)
							{


								if (ac_list.IndexOf($"'{Convert.ToString(ado_PrimaryAircaft["ac_id"]).Trim()}'") >= 0 || ac_list.Trim() == "")
								{

									bAlreadyVerifiedFlag = has_aircraft_been_verified(Convert.ToInt32(ado_PrimaryAircaft["ac_id"]), inArrConfirmAircraft);

									if (!bAlreadyVerifiedFlag)
									{

										//see who has this aircraft record locked - if anyone
										strOwner = modCommon.AircraftLocked(Convert.ToInt32(ado_PrimaryAircaft["ac_id"]), in_JournalID).ToLower();

										//If someone has this locked who is not "me" then say so
										if (strOwner != "false" && strOwner != modAdminCommon.gbl_User_ID.ToLower())
										{
											MessageBox.Show($"Aircraft locked: AC ID: {Convert.ToString(ado_PrimaryAircaft["AC_ID"])} by {strOwner}", "Company : Verify Aircraft Status", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
										}
										else
										{
											add_items_to_array_fields(ref inArrConfirmAircraft, Convert.ToString(ado_PrimaryAircaft["AC_ID"]));

											// VERIFY THE AIRCRAFT
											Query = $"EXEC HomebaseVerifyAircraft {Convert.ToString(ado_PrimaryAircaft["ac_id"])},{in_CompanyID.ToString()},{in_ContactID.ToString()},{in_JournalID.ToString()},'{modAdminCommon.gbl_User_ID}','{modAdminCommon.gbl_Account_ID}','{StringsHelper.Replace(journ_description, "'", "''", 1, -1, CompareMethod.Binary).Trim()}' ";
											DbCommand TempCommand_4 = null;
											TempCommand_4 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
											UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_4);
											TempCommand_4.CommandText = Query;
											//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
											//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
											TempCommand_4.CommandType = (CommandType) (((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()) + ((int) CommandType.Text));
											UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_4);
											TempCommand_4.ExecuteNonQuery();

										} // Not (strOwner = "false") And Not (strOwner = LCase$(gbl_User_ID))

									} // Not bAlreadyVerifiedFlag

								}

								ado_PrimaryAircaft.MoveNext();

							}; // While Not ado_PrimaryAircaft.EOF

							ado_PrimaryAircaft.Close();

							modAdminCommon.ADO_Transaction("CommitTrans");

						}  // Not (ado_PrimaryAircaft.BOF And ado_PrimaryAircaft.EOF) 
						 
						ado_PrimaryAircaft = null; 
						 
						break;
					case "NOTE" :  // USER IS JUST ADDING A RESEARCH NOTE 
						if (inNoteTypeCbo.StartsWith("PBNOTE", StringComparison.Ordinal))
						{ // Pub Note
							result = insert_research_note(in_CompanyID, in_AircraftID, in_ContactID, ref inJournSubjectCbo, inNoteTypeCbo, inSelAircraftOpt, yacht_id, yacht_info_string, ac_list, StringsHelper.Replace(journ_description, "'", "''", 1, -1, CompareMethod.Binary));
						}
						else if (inNoteTypeCbo.StartsWith("REGCHK", StringComparison.Ordinal))
						{  // Reassign Attempted
							result = insert_research_note(in_CompanyID, in_AircraftID, in_ContactID, ref inJournSubjectCbo, inNoteTypeCbo, inSelAircraftOpt, yacht_id, yacht_info_string, ac_list, StringsHelper.Replace(journ_description, "'", "''", 1, -1, CompareMethod.Binary));
						}
						else if (inNoteTypeCbo.StartsWith("RAAT", StringComparison.Ordinal))
						{  // Reassign Attempted
							result = insert_research_note(in_CompanyID, in_AircraftID, in_ContactID, ref inJournSubjectCbo, inNoteTypeCbo, inSelAircraftOpt, yacht_id, yacht_info_string, ac_list, StringsHelper.Replace(journ_description, "'", "''", 1, -1, CompareMethod.Binary));
						}
						else if (inNoteTypeCbo.StartsWith("RADN", StringComparison.Ordinal))
						{  // Reassign  Procedures Done
							result = insert_research_note(in_CompanyID, in_AircraftID, in_ContactID, ref inJournSubjectCbo, inNoteTypeCbo, inSelAircraftOpt, yacht_id, yacht_info_string, ac_list, StringsHelper.Replace(journ_description, "'", "''", 1, -1, CompareMethod.Binary));
						}
						else if (inNoteTypeCbo.StartsWith("PROJ", StringComparison.Ordinal))
						{  // PROJ
							result = insert_research_note(in_CompanyID, in_AircraftID, in_ContactID, ref inJournSubjectCbo, inNoteTypeCbo, inSelAircraftOpt, yacht_id, yacht_info_string, ac_list, StringsHelper.Replace(journ_description, "'", "''", 1, -1, CompareMethod.Binary));
						}
						else if (inNoteTypeCbo.StartsWith("DOCAT", StringComparison.Ordinal))
						{  // Doc Attempted
							result = insert_research_note(in_CompanyID, in_AircraftID, in_ContactID, ref inJournSubjectCbo, inNoteTypeCbo, inSelAircraftOpt, yacht_id, yacht_info_string, ac_list, StringsHelper.Replace(journ_description, "'", "''", 1, -1, CompareMethod.Binary));
						}
						else if (inNoteTypeCbo.StartsWith("RVEAT", StringComparison.Ordinal))
						{  // Reverify Exclusive Attempted
							result = insert_research_note(in_CompanyID, in_AircraftID, in_ContactID, ref inJournSubjectCbo, inNoteTypeCbo, inSelAircraftOpt, yacht_id, yacht_info_string, ac_list, StringsHelper.Replace(journ_description, "'", "''", 1, -1, CompareMethod.Binary));
						}
						else
						{
							result = insert_research_note(in_CompanyID, in_AircraftID, in_ContactID, ref inJournSubjectCbo, inNoteTypeCbo, inSelAircraftOpt, yacht_id, yacht_info_string, ac_list, StringsHelper.Replace(journ_description, "'", "''", 1, -1, CompareMethod.Binary));
						} 
						 
						break;
				} // CASE ON VERIFY STATUS PURPOSE


				return true;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"verify_aircraft_status_Error ({Information.Err().Number.ToString()}) {excep.Message} ACID:[{in_AircraftID.ToString()}] CMPID[{in_CompanyID.ToString()}] CONID[{in_ContactID.ToString()}] JID[{in_JournalID.ToString()}]", "Company (modCompany)");
				modAdminCommon.ADO_Transaction("RollbackTrans");
				return result;
			}
		}

		internal static string get_yacht_name_mfr(int yacht_id)
		{
			//----------------------------------------------------------------------------------------------
			//Function used to select class 'A' aircraft
			//----------------------------------------------------------------------------------------------
			string result = "";
			ADORecordSetHelper snp_ModNames = new ADORecordSetHelper(); // dao.Recordset aey 6/18/04

			string Query = "SELECT yt_yacht_name, comp_name  FROM yacht WITH(NOLOCK) ";
			Query = $"{Query} inner join Yacht_Model WITH(NOLOCK) on ym_model_id = yt_model_id   left outer join company with (NOLOCK) on comp_journ_id = 0 and comp_id = ym_mfr_comp_id ";
			Query = $"{Query}WHERE yt_journ_id = 0 and yt_id ={yacht_id.ToString()}";

			// Set snp_ModNames = LOCAL_DB.OpenRecordset(Query, dbOpenSnapshot, dbSQLPassThrough)
			snp_ModNames.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

			if (!(snp_ModNames.EOF && snp_ModNames.BOF))
			{
				snp_ModNames.MoveFirst(); //aey 6/18/04    'If snp_ModNames.RecordCount > 0 Then
				result = $"{($" {Convert.ToString(snp_ModNames["yt_yacht_name"])}").Trim()}/{($" {Convert.ToString(snp_ModNames["comp_name"])}").Trim()}";
			}
			else
			{
				result = "";
			}
			snp_ModNames.Close();
			return result;
		}

		internal static string Confirm_Matching_Contacts(int contact_id, ref int number_of_contacts, string phone_to_match, ref string company_id_list, int current_comp_id, bool no_phone = false, string email_to_change = "", string email_new = "")
		{

			string result = "";
			string contact_phone_add = "";
			string contact_phone_add2 = "";
			int temp_comp_id = 0;
			int last_contact_id = 0;

			// RUN THIS QUERY TO FIND MATCHING

			phone_to_match = StringsHelper.Replace(phone_to_match, "-", "", 1, -1, CompareMethod.Binary);
			phone_to_match = StringsHelper.Replace(phone_to_match, ".", "", 1, -1, CompareMethod.Binary);

			// ADDED MSW - 7/27/16 - if there is no phone number, look for all connected contacts
			if (phone_to_match.Trim() != "" && phone_to_match.Trim() != "NO_MATCH")
			{
				// changed msw - 7/9/2020
				// contact_phone_add = " inner join Phone_Numbers  with (NOLOCK) on pnum_contact_id  = cr_contact_id and pnum_number_full_search = '" & Trim(phone_to_match) & "' "
				contact_phone_add = $" inner join Phone_Numbers  with (NOLOCK) on pnum_contact_id  = cr_contact_rel_id and pnum_number_full_search = '{phone_to_match.Trim()}' ";
			}
			else
			{
				contact_phone_add = "";
			}

			if (phone_to_match.Trim() != "" && phone_to_match.Trim() != "NO_MATCH")
			{
				// commented out/changed msw - 7/9/20
				//contact_phone_add2 = " inner join Phone_Numbers  with (NOLOCK) on pnum_contact_id  = cr_contact_id and pnum_number_full_search = '" & Trim(phone_to_match) & "' "
				contact_phone_add2 = $" inner join Phone_Numbers  with (NOLOCK) on pnum_contact_id  = cr_contact_rel_id and pnum_number_full_search = '{phone_to_match.Trim()}' ";

			}
			else
			{
				contact_phone_add2 = "";
			}


			string query_contacts = " select distinct cr_comp_id, cr_contact_id, cr_comp_rel_id, cr_contact_rel_id, a.comp_id, b.comp_id";
			query_contacts = $"{query_contacts} from contact_reference with (NOLOCK)";
			query_contacts = $"{query_contacts}  inner join Contact c1 with (NOLOCK) on cr_contact_id = c1.contact_id and c1.contact_journ_id = 0 and (c1.contact_active_flag = 'Y' or c1.contact_id = {contact_id.ToString()}) ";
			query_contacts = $"{query_contacts}  inner join Contact c2 with (NOLOCK) on cr_contact_rel_id = c2.contact_id and c2.contact_journ_id = 0 and (c2.contact_active_flag = 'Y' or c2.contact_id = {contact_id.ToString()})  ";
			if (email_to_change.Trim() != "" && (email_new.Trim() != email_to_change.Trim()))
			{
				query_contacts = $"{query_contacts}  inner join Contact c3 with (NOLOCK) on (cr_contact_rel_id = c3.contact_id or cr_contact_id = c3.contact_id) and c3.contact_journ_id = 0 and c3.contact_active_flag = 'Y' ";
				query_contacts = $"{query_contacts} and c3.contact_id = {contact_id.ToString()}";
			}
			query_contacts = $"{query_contacts} LEFT outer join Company a with (NOLOCK) on  (";
			query_contacts = $"{query_contacts} a.comp_id = cr_comp_rel_id And a.comp_journ_id = cr_journ_id AND a.comp_active_flag = 'Y'";
			query_contacts = $"{query_contacts} AND ( a.comp_product_business_flag = 'Y'  OR  a.comp_product_commercial_flag = 'Y'  OR  a.comp_product_helicopter_flag = 'Y' OR  a.comp_product_yacht_flag = 'Y')";
			query_contacts = $"{query_contacts} )";
			query_contacts = $"{query_contacts} LEFT outer join Company b with (NOLOCK) on  (";
			query_contacts = $"{query_contacts} b.comp_id = cr_comp_rel_id and b.comp_journ_id = cr_journ_id  AND b.comp_active_flag = 'Y'";
			query_contacts = $"{query_contacts} AND ( b.comp_product_business_flag = 'Y'  OR  b.comp_product_commercial_flag = 'Y'  OR  b.comp_product_helicopter_flag = 'Y' OR  b.comp_product_yacht_flag = 'Y')";
			query_contacts = $"{query_contacts} )  where  ( cr_contact_id in  (";
			query_contacts = $"{query_contacts} select distinct cr_contact_id from contact_reference with  (NOLOCK)  {contact_phone_add2}";
			query_contacts = $"{query_contacts} where (cr_contact_rel_id = {contact_id.ToString()} And cr_journ_id = 0)  )";
			query_contacts = $"{query_contacts} or cr_contact_rel_id in";
			query_contacts = $"{query_contacts} (select distinct cr_contact_rel_id from contact_reference with (NOLOCK) {contact_phone_add2}";
			query_contacts = $"{query_contacts} where cr_contact_id= {contact_id.ToString()} and cr_journ_id = 0  )";
			query_contacts = $"{query_contacts} or cr_contact_rel_id in  (select distinct cr_contact_id from contact_reference with (NOLOCK) {contact_phone_add}";
			query_contacts = $"{query_contacts} where (cr_contact_rel_id = {contact_id.ToString()} And cr_journ_id = 0)  )";
			query_contacts = $"{query_contacts} or cr_contact_id in   (select distinct cr_contact_rel_id from contact_reference with (NOLOCK) {contact_phone_add}";
			query_contacts = $"{query_contacts} where cr_contact_id= {contact_id.ToString()} and cr_journ_id = 0  ) )";


			if (phone_to_match.Trim() == "" && !no_phone)
			{
				query_contacts = $"{query_contacts} and cr_contact_id not in  (select distinct subins_contact_id from Subscription_Install   with (NOLOCK) inner join Subscription with (NOLOCK) on subins_sub_id = sub_id where subins_contact_id = contact_reference.cr_contact_id and (sub_end_date > GETDATE() or sub_end_date is null))";
				query_contacts = $"{query_contacts} and cr_contact_rel_id not in  (select distinct subins_contact_id from Subscription_Install   with (NOLOCK) inner join Subscription with (NOLOCK) on subins_sub_id = sub_id where subins_contact_id  = contact_reference.cr_contact_rel_id and (sub_end_date > GETDATE() or sub_end_date is null))";
			}

			// adding in MSW - if the
			if (email_to_change.Trim() != "" && (email_new.Trim() != email_to_change.Trim()))
			{
				query_contacts = $"{query_contacts} and   C3.contact_email_address = '{email_new}' "; // has already been updated
				query_contacts = $"{query_contacts} and (C1.contact_email_address = '{email_to_change}' or C2.contact_email_address = '{email_to_change}') ";
			}

			query_contacts = $"{query_contacts} and  a.comp_id is not null   and  b.comp_id is not null";



			ADORecordSetHelper snp_Contact = ADORecordSetHelper.Open(query_contacts, modAdminCommon.LOCAL_ADO_DB, "");

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Contact.Fields) && !(snp_Contact.EOF && snp_Contact.BOF))
			{


				while(!snp_Contact.EOF)
				{

					number_of_contacts++;


					// added MSW - 8/2/16 - if its not current company, then add in rel company
					temp_comp_id = 0;
					if (current_comp_id == Convert.ToDouble(snp_Contact["cr_comp_id"]))
					{
						temp_comp_id = Convert.ToInt32(snp_Contact["cr_comp_rel_id"]);
					}
					else
					{
						temp_comp_id = Convert.ToInt32(snp_Contact["cr_comp_id"]);
					}

					// ADDED IN MSW - WAS NOT GETTING THE IDS CORRECT, NEED TO FIND A WAY TO DO SO
					if (Convert.ToDouble(snp_Contact["cr_contact_id"]) == contact_id)
					{
						if (result.Trim() != "")
						{
							result = $"{result},'{Convert.ToString(snp_Contact["cr_contact_rel_id"])}'";
							company_id_list = $"{company_id_list},'{temp_comp_id.ToString()}'";
						}
						else
						{
							result = $"'{Convert.ToString(snp_Contact["cr_contact_rel_id"])}'";
							company_id_list = $"'{temp_comp_id.ToString()}'";
						}
						last_contact_id = Convert.ToInt32(snp_Contact["cr_contact_rel_id"]);
					}
					else if (Convert.ToDouble(snp_Contact["cr_contact_rel_id"]) == contact_id)
					{ 
						if (result.Trim() != "")
						{
							result = $"{result},'{Convert.ToString(snp_Contact["cr_contact_id"])}'";
							company_id_list = $"{company_id_list},'{temp_comp_id.ToString()}'";
						}
						else
						{
							result = $"'{Convert.ToString(snp_Contact["cr_contact_id"])}'";
							company_id_list = $"'{temp_comp_id.ToString()}'";
						}
						last_contact_id = Convert.ToInt32(snp_Contact["cr_contact_id"]);
					}
					else if (Convert.ToDouble(snp_Contact["cr_contact_id"]) == last_contact_id)
					{ 
						if (result.Trim() != "")
						{
							result = $"{result},'{Convert.ToString(snp_Contact["cr_contact_rel_id"])}'";
							company_id_list = $"{company_id_list},'{temp_comp_id.ToString()}'";
						}
						else
						{
							result = $"'{Convert.ToString(snp_Contact["cr_contact_rel_id"])}'";
							company_id_list = $"'{temp_comp_id.ToString()}'";
						}
						last_contact_id = Convert.ToInt32(snp_Contact["cr_contact_rel_id"]);
					}
					else if (Convert.ToDouble(snp_Contact["cr_contact_rel_id"]) == last_contact_id)
					{ 
						if (result.Trim() != "")
						{
							result = $"{result},'{Convert.ToString(snp_Contact["cr_contact_id"])}'";
							company_id_list = $"{company_id_list},'{temp_comp_id.ToString()}'";
						}
						else
						{
							result = $"'{Convert.ToString(snp_Contact["cr_contact_id"])}'";
							company_id_list = $"'{temp_comp_id.ToString()}'";
						}
						last_contact_id = Convert.ToInt32(snp_Contact["cr_contact_id"]);
					}
					else
					{
						if (result.Trim() != "")
						{
							result = $"{result},'{Convert.ToString(snp_Contact["cr_contact_rel_id"])}'";
							company_id_list = $"{company_id_list},'{temp_comp_id.ToString()}'";
						}
						else
						{
							result = $"'{Convert.ToString(snp_Contact["cr_contact_rel_id"])}'";
							company_id_list = $"'{temp_comp_id.ToString()}'";
						}
						last_contact_id = Convert.ToInt32(snp_Contact["cr_contact_rel_id"]);
					}


					snp_Contact.MoveNext();

				}; // Do While Not snp_ContactPhone.EOF

			}

			snp_Contact.Close();


			return result;
		}

		internal static int Get_Company_ID(int contact_id)
		{

			int result = 0;
			ADORecordSetHelper snp_CID = new ADORecordSetHelper(); // dao.Recordset aey 6/18/04
			string Query = "SELECT contact_comp_id ";
			Query = $"{Query}FROM contact WITH(NOLOCK) ";
			Query = $"{Query}WHERE contact_id ={contact_id.ToString()} ";
			Query = $"{Query}AND contact_journ_id = 0  ";

			//Set snp_CID = LOCAL_DB.OpenRecordset(Query, dbOpenSnapshot, dbSQLPassThrough)
			snp_CID.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

			if (!(snp_CID.BOF && snp_CID.EOF))
			{
				snp_CID.MoveFirst(); //If snp_CID.RecordCount > 0 Then aey 6/18/04
				result = Convert.ToInt32(Double.Parse(Convert.ToString(snp_CID["contact_comp_id"]).Trim()));
			}
			else
			{
				result = 0;
			}
			snp_CID.Close();
			return result;
		}





		private static bool insert_research_note(int in_CompanyID, int in_AircraftID, int in_ContactID, ref string inJournSubject, string inNoteTypeText, int inSelAircraftOpt, int in_YachtID = 0, string yacht_info = "", string ac_list = "", string journ_description = "")
		{

			bool result = false;
			try
			{

				int nPreviousACID = 0;

				DbConnection cntCRM = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateConnection();
				ADORecordSetHelper ado_CompanyAircaft = new ADORecordSetHelper();
				ADORecordSetHelper ado_Primary = new ADORecordSetHelper();
				ADORecordSetHelper snpCRM = new ADORecordSetHelper();

				ADORecordSetHelper snpcomp_info = new ADORecordSetHelper();
				snpcomp_info = new ADORecordSetHelper();

				string Query = "";

				string user_first_name = "";
				string user_last_name = "";
				string user_email = "";
				string crm_user_login_id = "";
				string insert_string = "";
				string SQL = "";

				string insert_client_company = "";
				string insert_client_contact = "";
				string insert_client_phone_numbers = "";
				string insert_client_reference = "";
				string insert_client_reference_contact = "";
				int client_company_id = 0;
				string temp_date = "";
				string comp_orig_name = "";
				string comp_orig_city = "";
				string comp_orig_state = "";
				string u_string = "";
				bool client_company_exists = false;
				string marketing_desc = "";
				string JCatPart1 = "";
				result = false;

				nPreviousACID = 0;
				u_string = "";
				marketing_desc = "";
				comp_orig_name = "";
				comp_orig_city = "";
				comp_orig_state = "";

				// || inserted to break out the string
				if (inJournSubject.IndexOf("||") >= 0)
				{
					marketing_desc = inJournSubject.Substring(Math.Max(inJournSubject.Length - (Strings.Len(inJournSubject) - (inJournSubject.IndexOf("||") + 1) - 2), 0));
					inJournSubject = inJournSubject.Substring(0, Math.Min(inJournSubject.IndexOf("||"), inJournSubject.Length));
				}

				client_company_exists = false;
				client_company_id = 0;

				modAdminCommon.ADO_Transaction("BeginTrans");


				string[] ac_list_split = null;
				int i = 0;
				if (ac_list.Trim() != "")
				{
					i = 0;
					ac_list_split = ac_list.Split(',');

					int tempForEndVar = ac_list_split.GetUpperBound(0);
					for (i = 0; i <= tempForEndVar; i++)
					{
						//' COPIED FROM THE SINGLE AIRCRAFT SECTION
						modAdminCommon.Rec_Journal_Info.journ_subject = inJournSubject;
						modAdminCommon.Rec_Journal_Info.journ_description = journ_description;

						if (inNoteTypeText.Substring(0, Math.Min(4, inNoteTypeText.Length)).ToUpper() == "RAAT")
						{
							modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "RAAT";
						}
						else if (inNoteTypeText.Substring(0, Math.Min(5, inNoteTypeText.Length)).ToUpper() == "DOCAT")
						{ 
							modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "DOCAT";
						}
						else if (inNoteTypeText.Substring(0, Math.Min(5, inNoteTypeText.Length)).ToUpper() == "RVEAT")
						{ 
							modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "RVEAT";
						}
						else if (inNoteTypeText.Substring(0, Math.Min(4, inNoteTypeText.Length)).ToUpper() == "RADN")
						{ 
							modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "RADN";
						}
						else if (inNoteTypeText.Substring(0, Math.Min(4, inNoteTypeText.Length)).ToUpper() == "SPEC")
						{ 
							modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "SPEC";
						}
						else
						{
							modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "RN";
						}

						modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTimeHelper.ToString(DateTime.Now));
						modAdminCommon.Rec_Journal_Info.journ_ac_id = Convert.ToInt32(Double.Parse(StringsHelper.Replace(ac_list_split[i], "'", "", 1, -1, CompareMethod.Binary)));
						modAdminCommon.Rec_Journal_Info.journ_comp_id = in_CompanyID;
						modAdminCommon.Rec_Journal_Info.journ_contact_id = in_ContactID;
						modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
						modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
						modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
						modAdminCommon.Rec_Journal_Info.journ_status = "A";

						frm_Journal.DefInstance.Commit_Journal_Entry();

					}

				}


				//  create journal entry for one aircraft selected
				if (inSelAircraftOpt == modGlobalVars.opt_verify_ac_ONE && inNoteTypeText.Substring(0, Math.Min(2, inNoteTypeText.Length)).ToUpper() == "RN")
				{

					modAdminCommon.Rec_Journal_Info.journ_subject = inJournSubject;
					modAdminCommon.Rec_Journal_Info.journ_description = journ_description;
					modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "RN";
					modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTimeHelper.ToString(DateTime.Now));
					modAdminCommon.Rec_Journal_Info.journ_ac_id = in_AircraftID;
					modAdminCommon.Rec_Journal_Info.journ_comp_id = in_CompanyID;
					modAdminCommon.Rec_Journal_Info.journ_contact_id = in_ContactID;
					modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
					modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
					modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
					modAdminCommon.Rec_Journal_Info.journ_status = "A";

					frm_Journal.DefInstance.Commit_Journal_Entry();

				}
				else if (in_YachtID > 0 && (inNoteTypeText.Substring(0, Math.Min(2, inNoteTypeText.Length)).ToUpper() == "RN" || inNoteTypeText.Substring(0, Math.Min(2, inNoteTypeText.Length)).ToUpper() == "YN"))
				{ 
					// MSW - 11/14/2012 - - FOR YACHT NOTE
					//    The yahct note needed a seperate place to go in.
					// it is put in just like an ac note, but instead the yaxcht id is > 0

					modAdminCommon.Rec_Journal_Info.journ_subject = inJournSubject; //& "- " & yacht_info
					modAdminCommon.Rec_Journal_Info.journ_description = journ_description;
					modAdminCommon.Rec_Journal_Info.journ_subcategory_code = inNoteTypeText.Substring(0, Math.Min(2, inNoteTypeText.Length)).ToUpper();
					modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTimeHelper.ToString(DateTime.Now));
					modAdminCommon.Rec_Journal_Info.journ_ac_id = in_AircraftID;
					modAdminCommon.Rec_Journal_Info.journ_comp_id = in_CompanyID;
					modAdminCommon.Rec_Journal_Info.journ_contact_id = in_ContactID;
					modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
					modAdminCommon.Rec_Journal_Info.journ_yacht_id = in_YachtID;
					modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
					modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
					modAdminCommon.Rec_Journal_Info.journ_status = "A";

					frm_Journal.DefInstance.Commit_Journal_Entry();


					// ADDED IN MSW 2/24/2014
				}
				else if ((inNoteTypeText.Substring(0, Math.Min(2, inNoteTypeText.Length)).ToUpper() == "CN" || inNoteTypeText.Substring(0, Math.Min(2, inNoteTypeText.Length)).ToUpper() == "FN"))
				{ 

					modAdminCommon.Rec_Journal_Info.journ_subject = inJournSubject; //& "- " & yacht_info
					modAdminCommon.Rec_Journal_Info.journ_description = journ_description;
					modAdminCommon.Rec_Journal_Info.journ_subcategory_code = inNoteTypeText.Substring(0, Math.Min(2, inNoteTypeText.Length)).ToUpper();
					modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTimeHelper.ToString(DateTime.Now));
					modAdminCommon.Rec_Journal_Info.journ_ac_id = in_AircraftID;
					modAdminCommon.Rec_Journal_Info.journ_comp_id = in_CompanyID;
					modAdminCommon.Rec_Journal_Info.journ_contact_id = in_ContactID;
					modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
					modAdminCommon.Rec_Journal_Info.journ_yacht_id = 0;
					modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
					modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
					modAdminCommon.Rec_Journal_Info.journ_status = "A";

					frm_Journal.DefInstance.Commit_Journal_Entry();

				}

				//  create journal entry for all aircraft selected
				if (inSelAircraftOpt == modGlobalVars.opt_verify_ac_ALL && (inNoteTypeText.Substring(0, Math.Min(2, inNoteTypeText.Length)).ToUpper() == "RN" || inNoteTypeText.Substring(0, Math.Min(4, inNoteTypeText.Length)).ToUpper() == "RAAT" || inNoteTypeText.Substring(0, Math.Min(4, inNoteTypeText.Length)).ToUpper() == "RADN" || inNoteTypeText.Substring(0, Math.Min(6, inNoteTypeText.Length)).ToUpper() == "IDNOTE"))
				{


					Query = $"EXEC HomebaseGetCompanyAircraftList_Note {in_CompanyID.ToString()}, 0";

					ado_CompanyAircaft = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(ado_CompanyAircaft.Fields) && !(ado_CompanyAircaft.BOF && ado_CompanyAircaft.EOF))
					{


						while(!ado_CompanyAircaft.EOF)
						{
							// process each unique aircraft
							if (nPreviousACID != Convert.ToInt32(ado_CompanyAircaft["ac_id"]))
							{

								if (inNoteTypeText.Substring(0, Math.Min(4, inNoteTypeText.Length)).ToUpper() == "RAAT")
								{
									modAdminCommon.Rec_Journal_Info.journ_subject = "Reassign Attempted";
								}
								else
								{
									modAdminCommon.Rec_Journal_Info.journ_subject = inJournSubject;
								}

								modAdminCommon.Rec_Journal_Info.journ_description = journ_description;
								if (inNoteTypeText.Substring(0, Math.Min(4, inNoteTypeText.Length)).ToUpper() == "RAAT")
								{
									modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "RAAT";
								}
								else if (inNoteTypeText.Substring(0, Math.Min(6, inNoteTypeText.Length)).ToUpper() == "IDNOTE")
								{ 
									modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "IDNOTE";
								}
								else
								{
									modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "RN";
								}
								modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTimeHelper.ToString(DateTime.Now));

								modAdminCommon.Rec_Journal_Info.journ_ac_id = Convert.ToInt32(ado_CompanyAircaft["ac_id"]);

								modAdminCommon.Rec_Journal_Info.journ_comp_id = in_CompanyID;
								modAdminCommon.Rec_Journal_Info.journ_contact_id = in_ContactID;
								modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
								modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
								modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
								modAdminCommon.Rec_Journal_Info.journ_status = "A";
								modAdminCommon.Rec_Journal_Info.journ_yacht_id = in_YachtID;

								frm_Journal.DefInstance.Commit_Journal_Entry();
							}

							nPreviousACID = Convert.ToInt32(ado_CompanyAircaft["ac_id"]);
							ado_CompanyAircaft.MoveNext();

						}; // While Not ado_CompanyAircaft.EOF

						ado_CompanyAircaft.Close();

					} // Not (ado_CompanyAircaft.BOF And ado_CompanyAircaft.EOF)

					ado_CompanyAircaft = null;

				}

				//ADDED MSW - 11/15/16
				if (inNoteTypeText.Substring(0, Math.Min(6, inNoteTypeText.Length)).ToUpper() == "IDNOTE")
				{
					modAdminCommon.Rec_Journal_Info.journ_subject = inJournSubject;

					if (journ_description.Trim() != "" && marketing_desc.Trim() == "")
					{
						modAdminCommon.Rec_Journal_Info.journ_description = journ_description.Trim();
					}
					else
					{
						modAdminCommon.Rec_Journal_Info.journ_description = marketing_desc;
					}

					modAdminCommon.Rec_Journal_Info.journ_subcategory_code = inNoteTypeText.Substring(0, Math.Min(6, inNoteTypeText.Length)).ToUpper();
					modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTimeHelper.ToString(DateTime.Now));
					modAdminCommon.Rec_Journal_Info.journ_ac_id = in_AircraftID;
					modAdminCommon.Rec_Journal_Info.journ_comp_id = in_CompanyID;
					modAdminCommon.Rec_Journal_Info.journ_contact_id = in_ContactID;
					modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
					modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
					modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
					modAdminCommon.Rec_Journal_Info.journ_status = "A";
					modAdminCommon.Rec_Journal_Info.journ_yacht_id = in_YachtID;

					frm_Journal.DefInstance.Commit_Journal_Entry();
				}

				// 03/09/2017 - By David D. Cruger; Added
				if (inNoteTypeText.Substring(0, Math.Min(6, inNoteTypeText.Length)).ToUpper() == "PBNOTE")
				{
					modAdminCommon.Rec_Journal_Info.journ_subject = inJournSubject;

					if (journ_description.Trim() != "" && marketing_desc.Trim() == "")
					{
						modAdminCommon.Rec_Journal_Info.journ_description = journ_description.Trim();
					}
					else
					{
						modAdminCommon.Rec_Journal_Info.journ_description = marketing_desc;
					}

					modAdminCommon.Rec_Journal_Info.journ_subcategory_code = inNoteTypeText.Substring(0, Math.Min(6, inNoteTypeText.Length)).ToUpper();
					modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTimeHelper.ToString(DateTime.Now));
					modAdminCommon.Rec_Journal_Info.journ_ac_id = in_AircraftID;
					modAdminCommon.Rec_Journal_Info.journ_comp_id = in_CompanyID;
					modAdminCommon.Rec_Journal_Info.journ_contact_id = in_ContactID;
					modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
					modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
					modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
					modAdminCommon.Rec_Journal_Info.journ_status = "A";
					modAdminCommon.Rec_Journal_Info.journ_yacht_id = in_YachtID;

					frm_Journal.DefInstance.Commit_Journal_Entry();
				}

				// ADDED MSW - 3/18/19
				if (inNoteTypeText.Substring(0, Math.Min(4, inNoteTypeText.Length)).ToUpper() == "MEMO")
				{
					modAdminCommon.Rec_Journal_Info.journ_subject = inJournSubject;

					if (journ_description.Trim() != "" && marketing_desc.Trim() == "")
					{
						modAdminCommon.Rec_Journal_Info.journ_description = journ_description.Trim();
					}
					else
					{
						modAdminCommon.Rec_Journal_Info.journ_description = marketing_desc;
					}

					modAdminCommon.Rec_Journal_Info.journ_subcategory_code = inNoteTypeText.Substring(0, Math.Min(4, inNoteTypeText.Length)).ToUpper();
					modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTimeHelper.ToString(DateTime.Now));
					modAdminCommon.Rec_Journal_Info.journ_ac_id = in_AircraftID;
					modAdminCommon.Rec_Journal_Info.journ_comp_id = in_CompanyID;
					modAdminCommon.Rec_Journal_Info.journ_contact_id = in_ContactID;
					modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
					modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
					modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
					modAdminCommon.Rec_Journal_Info.journ_status = "A";
					modAdminCommon.Rec_Journal_Info.journ_yacht_id = in_YachtID;

					frm_Journal.DefInstance.Commit_Journal_Entry();
				}



				// ADDED MSW - 10/9/18
				if (ac_list.Trim() == "")
				{

					// 05/12/2017 - By David D. Cruger; Added
					if (inNoteTypeText.Substring(0, Math.Min(4, inNoteTypeText.Length)).ToUpper() == "RAAT")
					{
						modAdminCommon.Rec_Journal_Info.journ_subject = "Reassign Attempted";

						if (journ_description.Trim() != "" && marketing_desc.Trim() == "")
						{
							modAdminCommon.Rec_Journal_Info.journ_description = journ_description.Trim();
						}
						else
						{
							modAdminCommon.Rec_Journal_Info.journ_description = marketing_desc;
						}

						modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "RAAT";
						modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTimeHelper.ToString(DateTime.Now));
						modAdminCommon.Rec_Journal_Info.journ_ac_id = in_AircraftID;
						modAdminCommon.Rec_Journal_Info.journ_comp_id = in_CompanyID;
						modAdminCommon.Rec_Journal_Info.journ_contact_id = in_ContactID;
						modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
						modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
						modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
						modAdminCommon.Rec_Journal_Info.journ_status = "A";
						modAdminCommon.Rec_Journal_Info.journ_yacht_id = in_YachtID;

						frm_Journal.DefInstance.Commit_Journal_Entry();
					}

					// 05/12/2017 - By David D. Cruger; Added
					if (inNoteTypeText.Substring(0, Math.Min(5, inNoteTypeText.Length)).ToUpper() == "DOCAT")
					{
						modAdminCommon.Rec_Journal_Info.journ_subject = "Doc Attempted";

						if (journ_description.Trim() != "" && marketing_desc.Trim() == "")
						{
							modAdminCommon.Rec_Journal_Info.journ_description = journ_description.Trim();
						}
						else
						{
							modAdminCommon.Rec_Journal_Info.journ_description = marketing_desc;
						}

						modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "DOCAT";
						modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTimeHelper.ToString(DateTime.Now));
						modAdminCommon.Rec_Journal_Info.journ_ac_id = in_AircraftID;
						modAdminCommon.Rec_Journal_Info.journ_comp_id = in_CompanyID;
						modAdminCommon.Rec_Journal_Info.journ_contact_id = in_ContactID;
						modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
						modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
						modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
						modAdminCommon.Rec_Journal_Info.journ_status = "A";
						modAdminCommon.Rec_Journal_Info.journ_yacht_id = in_YachtID;

						frm_Journal.DefInstance.Commit_Journal_Entry();
					}

					// 09/27/2017 - By David D. Cruger; Added
					if (inNoteTypeText.Substring(0, Math.Min(4, inNoteTypeText.Length)).ToUpper() == "RADN")
					{
						modAdminCommon.Rec_Journal_Info.journ_subject = "Reassign Procedures Done";

						if (journ_description.Trim() != "" && marketing_desc.Trim() == "")
						{
							modAdminCommon.Rec_Journal_Info.journ_description = journ_description.Trim();
						}
						else
						{
							modAdminCommon.Rec_Journal_Info.journ_description = marketing_desc;
						}

						modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "RADN";
						modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTimeHelper.ToString(DateTime.Now));
						modAdminCommon.Rec_Journal_Info.journ_ac_id = in_AircraftID;
						modAdminCommon.Rec_Journal_Info.journ_comp_id = in_CompanyID;
						modAdminCommon.Rec_Journal_Info.journ_contact_id = in_ContactID;
						modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
						modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
						modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
						modAdminCommon.Rec_Journal_Info.journ_status = "A";
						modAdminCommon.Rec_Journal_Info.journ_yacht_id = in_YachtID;

						frm_Journal.DefInstance.Commit_Journal_Entry();
					}


					// 12/3/17 msw
					if (inNoteTypeText.Substring(0, Math.Min(4, inNoteTypeText.Length)).ToUpper() == "PROJ")
					{
						modAdminCommon.Rec_Journal_Info.journ_subject = inJournSubject;
						modAdminCommon.Rec_Journal_Info.journ_description = journ_description;
						modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "PROJ";
						modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTimeHelper.ToString(DateTime.Now));
						modAdminCommon.Rec_Journal_Info.journ_ac_id = in_AircraftID;
						modAdminCommon.Rec_Journal_Info.journ_comp_id = in_CompanyID;
						modAdminCommon.Rec_Journal_Info.journ_contact_id = in_ContactID;
						modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
						modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
						modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
						modAdminCommon.Rec_Journal_Info.journ_status = "A";
						modAdminCommon.Rec_Journal_Info.journ_yacht_id = in_YachtID;

						frm_Journal.DefInstance.Commit_Journal_Entry();
					}

					if (inNoteTypeText.Substring(0, Math.Min(6, inNoteTypeText.Length)).ToUpper() == "REGCHK")
					{
						modAdminCommon.Rec_Journal_Info.journ_subject = inJournSubject;
						modAdminCommon.Rec_Journal_Info.journ_description = journ_description;
						modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "REGCHK";
						modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTimeHelper.ToString(DateTime.Now));
						modAdminCommon.Rec_Journal_Info.journ_ac_id = in_AircraftID;
						modAdminCommon.Rec_Journal_Info.journ_comp_id = in_CompanyID;
						modAdminCommon.Rec_Journal_Info.journ_contact_id = in_ContactID;
						modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
						modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
						modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
						modAdminCommon.Rec_Journal_Info.journ_status = "A";
						modAdminCommon.Rec_Journal_Info.journ_yacht_id = in_YachtID;

						frm_Journal.DefInstance.Commit_Journal_Entry();
					}


					if (inNoteTypeText.Substring(0, Math.Min(4, inNoteTypeText.Length)).ToUpper() == "SPEC")
					{
						modAdminCommon.Rec_Journal_Info.journ_subject = inJournSubject;
						modAdminCommon.Rec_Journal_Info.journ_description = journ_description;
						modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "SPEC";
						modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTimeHelper.ToString(DateTime.Now));
						modAdminCommon.Rec_Journal_Info.journ_ac_id = in_AircraftID;
						modAdminCommon.Rec_Journal_Info.journ_comp_id = in_CompanyID;
						modAdminCommon.Rec_Journal_Info.journ_contact_id = in_ContactID;
						modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
						modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
						modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
						modAdminCommon.Rec_Journal_Info.journ_status = "A";
						modAdminCommon.Rec_Journal_Info.journ_yacht_id = in_YachtID;

						frm_Journal.DefInstance.Commit_Journal_Entry();
					}



					// 09/27/2017 - By David D. Cruger; Added
					if (inNoteTypeText.Substring(0, Math.Min(5, inNoteTypeText.Length)).ToUpper() == "RVEAT")
					{
						modAdminCommon.Rec_Journal_Info.journ_subject = "Reverify Exclusive Attempted";

						if (marketing_desc.Trim() == "" && journ_description.Trim() != "")
						{
							modAdminCommon.Rec_Journal_Info.journ_description = journ_description;
						}
						else
						{
							modAdminCommon.Rec_Journal_Info.journ_description = marketing_desc;
						}

						modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "RVEAT";
						modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTimeHelper.ToString(DateTime.Now));
						modAdminCommon.Rec_Journal_Info.journ_ac_id = in_AircraftID;
						modAdminCommon.Rec_Journal_Info.journ_comp_id = in_CompanyID;
						modAdminCommon.Rec_Journal_Info.journ_contact_id = in_ContactID;
						modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
						modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
						modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
						modAdminCommon.Rec_Journal_Info.journ_status = "A";
						modAdminCommon.Rec_Journal_Info.journ_yacht_id = in_YachtID;

						frm_Journal.DefInstance.Commit_Journal_Entry();
					}
				}


				string contact_id_list = "";
				int number_of_contacts = 0;
				int temp_comp_id = 0;
				int contact_count = 0;
				string[] contact_Array = null;
				if (inNoteTypeText.Substring(0, Math.Min(2, inNoteTypeText.Length)).ToUpper() == "IQ")
				{


					modAdminCommon.Rec_Journal_Info.journ_subject = inJournSubject;

					if (journ_description.Trim() != "" && marketing_desc.Trim() == "")
					{
						modAdminCommon.Rec_Journal_Info.journ_description = journ_description.Trim();
					}
					else
					{
						modAdminCommon.Rec_Journal_Info.journ_description = marketing_desc;
					}

					modAdminCommon.Rec_Journal_Info.journ_subcategory_code = inNoteTypeText.Substring(0, Math.Min(2, inNoteTypeText.Length)).ToUpper();
					modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTimeHelper.ToString(DateTime.Now));
					modAdminCommon.Rec_Journal_Info.journ_ac_id = in_AircraftID;
					modAdminCommon.Rec_Journal_Info.journ_comp_id = in_CompanyID;
					modAdminCommon.Rec_Journal_Info.journ_contact_id = in_ContactID;
					modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
					modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
					modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
					modAdminCommon.Rec_Journal_Info.journ_status = "A";
					modAdminCommon.Rec_Journal_Info.journ_yacht_id = in_YachtID;

					frm_Journal.DefInstance.Commit_Journal_Entry();

					if (in_ContactID > 0)
					{
						number_of_contacts = 0;

						string tempRefParam = "";
						contact_id_list = Confirm_Matching_Contacts(Convert.ToInt32(Double.Parse(in_ContactID.ToString())), ref number_of_contacts, "NO_MATCH", ref tempRefParam, in_CompanyID);
						if (contact_id_list.Trim() != "")
						{

							contact_Array = contact_id_list.Split(',');
							contact_count = contact_Array.GetUpperBound(0);

							// COMMENTED OUT MSW - 6/12/18 - DOESNT NEED TO ASK, JUST DO IT - PER RESULT
							// If MsgBox("This Contact Has " & contact_count + 1 & " Other Contacts Connected To It. Would you like to also insert a Journal Note for These?", vbYesNo) = vbYes Then

							int tempForEndVar2 = contact_count;
							for (i = 0; i <= tempForEndVar2; i++)
							{

								contact_Array[i] = StringsHelper.Replace(contact_Array[i], "'", "", 1, -1, CompareMethod.Binary);

								if (in_ContactID.ToString().Trim() != contact_Array[i].Trim())
								{
									temp_comp_id = 0;
									temp_comp_id = Get_Company_ID(Convert.ToInt32(Double.Parse(contact_Array[i])));

									modAdminCommon.Rec_Journal_Info.journ_subject = inJournSubject;
									// copy added in MSW - 7/3/19
									if (journ_description.Trim() != "" && marketing_desc.Trim() == "")
									{
										modAdminCommon.Rec_Journal_Info.journ_description = $"Copy: {journ_description.Trim()}";
									}
									else
									{
										modAdminCommon.Rec_Journal_Info.journ_description = $"Copy: {marketing_desc}";
									}

									modAdminCommon.Rec_Journal_Info.journ_subcategory_code = inNoteTypeText.Substring(0, Math.Min(2, inNoteTypeText.Length)).ToUpper();
									modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTimeHelper.ToString(DateTime.Now));
									modAdminCommon.Rec_Journal_Info.journ_ac_id = in_AircraftID;
									modAdminCommon.Rec_Journal_Info.journ_comp_id = temp_comp_id;
									modAdminCommon.Rec_Journal_Info.journ_contact_id = Convert.ToInt32(Double.Parse(contact_Array[i]));
									modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
									modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
									modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
									modAdminCommon.Rec_Journal_Info.journ_status = "A";
									modAdminCommon.Rec_Journal_Info.journ_yacht_id = in_YachtID;

									frm_Journal.DefInstance.Commit_Journal_Entry();

								}
							}
							//End If
						}
					}

				}


				//  create journal entry for no aircraft selected
				JCatPart1 = inNoteTypeText.Substring(0, Math.Min(2, inNoteTypeText.Length)).ToUpper();
				string temp_inner_journal = "";
				if (JCatPart1 != "CN" && JCatPart1 != "FN" && JCatPart1 != "ID" && JCatPart1 != "PB" && JCatPart1 != "RA" && JCatPart1 != "DO" && JCatPart1 != "RV" && JCatPart1 != "PR" && JCatPart1 != "IQ" && JCatPart1 != "ME" && JCatPart1 != "RE")
				{

					if (inSelAircraftOpt == modGlobalVars.opt_verify_ac_NONE)
					{


						if (inJournSubject.Substring(0, Math.Min(2, inJournSubject.Length)).Trim() == "MN" || inJournSubject.Substring(0, Math.Min(3, inJournSubject.Length)).Trim() == "MND" || inJournSubject.Substring(0, Math.Min(3, inJournSubject.Length)).Trim() == "MNC" || inJournSubject.Substring(0, Math.Min(3, inJournSubject.Length)).Trim() == "MNQ" || inJournSubject.Substring(0, Math.Min(3, inJournSubject.Length)).Trim() == "MNL" || inJournSubject.Substring(0, Math.Min(4, inJournSubject.Length)).Trim() == "CSAC" || inJournSubject.Substring(0, Math.Min(4, inJournSubject.Length)).Trim() == "CSCO" || inJournSubject.Substring(0, Math.Min(4, inJournSubject.Length)).Trim() == "CSCS")
						{

							temp_inner_journal = inJournSubject;

							if (temp_inner_journal.Trim().IndexOf(" - ") >= 0)
							{
								temp_inner_journal = temp_inner_journal.Trim().Substring(Math.Max(temp_inner_journal.Trim().Length - (Strings.Len(temp_inner_journal.Trim()) - (temp_inner_journal.Trim().IndexOf(" - ") + 1) - 2), 0));
							}

							modAdminCommon.Rec_Journal_Info.journ_subject = temp_inner_journal;
						}
						else
						{
							modAdminCommon.Rec_Journal_Info.journ_subject = inJournSubject;
						}




						if (marketing_desc.Trim() == "" && journ_description.Trim() != "")
						{
							modAdminCommon.Rec_Journal_Info.journ_description = journ_description;
						}
						else
						{
							modAdminCommon.Rec_Journal_Info.journ_description = marketing_desc;
						}
						// 01/23/2013 - By David D. Cruger
						// Per Lucia; Added ADN-Aircraft Delivery Note
						if (inNoteTypeText.Substring(0, Math.Min(2, inNoteTypeText.Length)).ToUpper() == "AN")
						{
							modAdminCommon.Rec_Journal_Info.journ_category_code = "AN";
							modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "ADN"; // Aircraft Delivery Notes
						}
						else if (inJournSubject.Substring(0, Math.Min(3, inJournSubject.Length)).Trim() == "MND" || inJournSubject.Substring(0, Math.Min(3, inJournSubject.Length)).Trim() == "MNC" || inJournSubject.Substring(0, Math.Min(3, inJournSubject.Length)).Trim() == "MNQ" || inJournSubject.Substring(0, Math.Min(3, inJournSubject.Length)).Trim() == "MNL")
						{ 
							modAdminCommon.Rec_Journal_Info.journ_subcategory_code = inJournSubject.Substring(0, Math.Min(3, inJournSubject.Length)).ToUpper();
						}
						else if (inJournSubject.Substring(0, Math.Min(4, inJournSubject.Length)).Trim() == "CSAC" || inJournSubject.Substring(0, Math.Min(4, inJournSubject.Length)).Trim() == "CSCO" || inJournSubject.Substring(0, Math.Min(4, inJournSubject.Length)).Trim() == "CSCS")
						{ 
							modAdminCommon.Rec_Journal_Info.journ_subcategory_code = inJournSubject.Substring(0, Math.Min(4, inJournSubject.Length)).ToUpper();
						}
						else
						{
							modAdminCommon.Rec_Journal_Info.journ_subcategory_code = inNoteTypeText.Substring(0, Math.Min(2, inNoteTypeText.Length)).ToUpper();
						}
						modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTimeHelper.ToString(DateTime.Now));
						modAdminCommon.Rec_Journal_Info.journ_ac_id = 0;
						modAdminCommon.Rec_Journal_Info.journ_comp_id = in_CompanyID;
						modAdminCommon.Rec_Journal_Info.journ_contact_id = in_ContactID;
						modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
						modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
						modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
						modAdminCommon.Rec_Journal_Info.journ_status = "A";
						modAdminCommon.Rec_Journal_Info.journ_yacht_id = in_YachtID;

						frm_Journal.DefInstance.Commit_Journal_Entry();

					}
				}

				//  create journal entry for primary aircraft selected
				if (inSelAircraftOpt == modGlobalVars.opt_verify_ac_PRIMARY && inNoteTypeText.Substring(0, Math.Min(2, inNoteTypeText.Length)).ToUpper() == "RN")
				{
					Query = $"EXEC HomebaseGetCompanyAircraftList {in_CompanyID.ToString()}, 0";

					ado_CompanyAircaft = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");
					nPreviousACID = 0;
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(ado_CompanyAircaft.Fields) && !(ado_CompanyAircaft.BOF && ado_CompanyAircaft.EOF))
					{


						while(!ado_CompanyAircaft.EOF)
						{

							//create journal entry for primary aircraft selected
							if (Convert.ToString(ado_CompanyAircaft["cref_primary_poc_flag"]).Trim().ToUpper() == "Y" || Convert.ToString(ado_CompanyAircaft["cref_primary_poc_flag"]).Trim().ToUpper() == "X")
							{

								// process each unique aircraft   ' added the or = 0 so that it gets the first one - msw 6/7/17
								if ((nPreviousACID != Convert.ToInt32(ado_CompanyAircaft["ac_id"])) || nPreviousACID == 0)
								{

									modAdminCommon.Rec_Journal_Info.journ_subject = inJournSubject;
									modAdminCommon.Rec_Journal_Info.journ_description = journ_description;
									modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "RN";
									modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTimeHelper.ToString(DateTime.Now));

									modAdminCommon.Rec_Journal_Info.journ_ac_id = Convert.ToInt32(ado_CompanyAircaft["ac_id"]);

									modAdminCommon.Rec_Journal_Info.journ_comp_id = in_CompanyID;
									modAdminCommon.Rec_Journal_Info.journ_contact_id = in_ContactID;
									modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
									modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
									modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
									modAdminCommon.Rec_Journal_Info.journ_status = "A";

									frm_Journal.DefInstance.Commit_Journal_Entry();

									nPreviousACID = Convert.ToInt32(ado_CompanyAircaft["ac_id"]); // moved this inside block, so that it only changed if note is added

								}


							}



							ado_CompanyAircaft.MoveNext();

						}; // While Not ado_CompanyAircaft.EOF

						ado_CompanyAircaft.Close();

					} // Not (ado_CompanyAircaft.BOF And ado_CompanyAircaft.EOF)

					ado_CompanyAircaft = null;

				}

				modAdminCommon.ADO_Transaction("CommitTrans");


				return true;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"insert_research_note_Error ({Information.Err().Number.ToString()}) {excep.Message}", "Company (modCompany)");
				modAdminCommon.ADO_Transaction("RollbackTrans");
			}
			return result;
		} // insert_research_note
		internal static bool Check_Company_Office_Number(string phone_to_match, int current_comp_id)
		{

			bool result = false;
			string contact_phone_add = "";
			int temp_comp_id = 0;
			StringBuilder Query = new StringBuilder();

			string query_contacts = " select comp_id from company with (NOLOCK) ";
			query_contacts = $"{query_contacts} inner join Phone_Numbers with (NOLOCK) on pnum_comp_id = comp_id and pnum_journ_id = comp_journ_id ";
			query_contacts = $"{query_contacts} where comp_journ_id = 0 and comp_id = {current_comp_id.ToString()} ";
			query_contacts = $"{query_contacts} and pnum_number_full_search = '{phone_to_match}' and pnum_contact_id = 0  ";
			query_contacts = $"{query_contacts} and pnum_type = 'Office'  ";

			ADORecordSetHelper snp_Contact = ADORecordSetHelper.Open(query_contacts, modAdminCommon.LOCAL_ADO_DB, "");

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Contact.Fields) && !(snp_Contact.EOF && snp_Contact.BOF))
			{


				while(!snp_Contact.EOF)
				{


					Query = new StringBuilder($"UPDATE Phone_Numbers SET pnum_confirm_date = '{DateTime.Now.ToString()}' ");
					Query.Append($" WHERE  pnum_comp_id = {current_comp_id.ToString()} AND pnum_contact_id = 0 ");
					Query.Append($"   and pnum_journ_id = 0 and pnum_number_full_search = '{phone_to_match}'  ");
					Query.Append("  and pnum_type = 'Office'  ");


					modAdminCommon.ADO_Transaction("BeginTrans");
					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = Query.ToString();
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand.CommandType = (CommandType) (((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()) + ((int) CommandType.Text));
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();
					modAdminCommon.ADO_Transaction("CommitTrans");

					result = true;

					snp_Contact.MoveNext();

				}; // Do While Not snp_ContactPhone.EOF

			}

			snp_Contact.Close();


			return result;
		}


		internal static void add_fractional_owner(int in_CompanyID, int in_JournalID)
		{

			string Query = "";
			string[] tmpFields = new string[]{"", ""};
			tmpFields[0] = modGlobalVars.cEmptyString;
			int tmpFractOwner_ID = 0;

			try
			{

				tmpFractOwner_ID = modCommon.Get_Next_Fractional_Owner_ID();

				modAdminCommon.ADO_Transaction("BeginTrans");

				Query = $"UPDATE Company SET comp_fractowr_id = {tmpFractOwner_ID.ToString()} WHERE comp_id = {in_CompanyID.ToString()}";
				Query = $"{Query} AND comp_journ_id={in_JournalID.ToString()}";

				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = (CommandType) (((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()) + ((int) CommandType.Text));
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();
				modAdminCommon.Record_Transmit(modGlobalVars.cEmptyString, 0, in_JournalID, 0, "Fractional Owner", "Add", ref tmpFields, in_CompanyID);
				modAdminCommon.ADO_Transaction("CommitTrans");
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"add_fractional_owner_Error ({Information.Err().Number.ToString()}) {excep.Message}", "Company (modCompany)");
				modAdminCommon.ADO_Transaction("RollbackTrans");
				return;
			}

		}

		internal static void remove_fractional_owner(int in_CompanyID, int in_JournalID)
		{

			string Query = "";
			string[] tmpFields = new string[]{"", ""};
			tmpFields[0] = modGlobalVars.cEmptyString;

			try
			{

				modAdminCommon.ADO_Transaction("BeginTrans");

				Query = "UPDATE Company SET comp_fractowr_id = 0, comp_fractowr_contact_id = 0, comp_fractowr_notes = NULL";
				Query = $"{Query} WHERE comp_id = {in_CompanyID.ToString()} AND comp_journ_id={in_JournalID.ToString()}";

				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = (CommandType) (((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()) + ((int) CommandType.Text));
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();
				modAdminCommon.Record_Transmit(modGlobalVars.cEmptyString, 0, in_JournalID, 0, "Fractional Owner", "Delete", ref tmpFields, in_CompanyID);
				modAdminCommon.ADO_Transaction("CommitTrans");
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"remove_fractional_owner_Error ({Information.Err().Number.ToString()}) {excep.Message}", "Company (modCompany)");
				modAdminCommon.ADO_Transaction("RollbackTrans");
				return;
			}

		}

		internal static bool wanted_aircraft_delete(int in_CompanyID, int in_JournalID, modGlobalVars.t_company_save_wanted_info tmpWanted)
		{

			// Function used to delete wanteds from the aircraft_model_wanted table

			bool result = false;
			string Query = "";
			string[] tmpFields = new string[]{"", ""};
			string strMsg = "";
			System.DateTime dtStartDate = DateTime.FromOADate(0);
			System.DateTime dtEndDate = DateTime.FromOADate(0);

			tmpFields[0] = "";


			try
			{

				if (tmpWanted.save_amwant_id > 0)
				{

					modAdminCommon.ADO_Transaction("BeginTrans");

					Query = "INSERT INTO Delete_Log ( dlog_type, ";
					Query = $"{Query}dlog_amod_id,  dlog_wanted_id, ";
					Query = $"{Query}dlog_entry_user ) VALUES (";
					Query = $"{Query}'Wanted', ";
					Query = $"{Query}{tmpWanted.save_amwant_modelID.ToString()}, ";
					Query = $"{Query}{tmpWanted.save_amwant_id.ToString()}, ";
					Query = $"{Query}'{modAdminCommon.gbl_User_ID}' )";

					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand.CommandType = (CommandType) (((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()) + ((int) CommandType.Text));
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery(); //7/1/04

					Query = $"DELETE FROM Aircraft_Model_Wanted WHERE amwant_id = {tmpWanted.save_amwant_id.ToString()}";

					DbCommand TempCommand_2 = null;
					TempCommand_2 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
					TempCommand_2.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand_2.CommandType = (CommandType) (((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()) + ((int) CommandType.Text));
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
					TempCommand_2.ExecuteNonQuery();

					modAdminCommon.ADO_Transaction("CommitTrans");

				} // tmpWanted.save_amwant_id > 0


				return true;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"wanted_aircraft_delete_Error ({Information.Err().Number.ToString()}) {excep.Message}", "Company (modCompany)");
				modAdminCommon.ADO_Transaction("RollbackTrans");
				return result;
			}
		}

		internal static bool wanted_aircraft_insert(int in_CompanyID, int in_JournalID, int in_ContactID, ref modGlobalVars.t_company_save_wanted_info tmpWanted)
		{
			// Function used to insert wanted record

			bool result = false;
			string Query = "";
			ADORecordSetHelper ado_NextWantedID = null;
			int next_amwant_id = 0;
			string[] tmpFields = new string[]{"", ""};
			tmpFields[0] = "";

			try
			{

				result = false;

				Query = "SELECT max(amwant_id) AS max_amwant_id from Aircraft_Model_Wanted WITH(NOLOCK)";
				ado_NextWantedID = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(ado_NextWantedID.Fields) && !(ado_NextWantedID.EOF && ado_NextWantedID.BOF))
				{
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(ado_NextWantedID["max_amwant_id"]))
					{
						next_amwant_id = Convert.ToInt32(ado_NextWantedID["max_amwant_id"]) + 1;
						ado_NextWantedID.Close();
					}
				}

				ado_NextWantedID = null;

				//build Aircraft_Model_Wanted table record amwant_auto_distribute_flag
				Query = "INSERT INTO Aircraft_Model_Wanted (amwant_id, amwant_amod_id, amwant_listed_date,";
				Query = $"{Query} amwant_verified_date, amwant_start_year, amwant_end_year, amwant_max_price, amwant_max_aftt,";
				Query = $"{Query} amwant_accept_damage_hist, amwant_accept_dam_cur, amwant_comp_id, amwant_journ_id, amwant_contact_id,";
				Query = $"{Query} amwant_year_note, amwant_amount_note, amwant_notes, amwant_entry_user_id,";
				Query = $"{Query} amwant_auto_distribute_flag, amwant_auto_distribute_email, amwant_auto_distribute_replyname, amwant_auto_unsubscribe_date) values (";

				Query = $"{Query}{next_amwant_id.ToString()},{tmpWanted.save_amwant_modelID.ToString()}";

				if (tmpWanted.save_amwant_listed_date.Trim() != modGlobalVars.cEmptyString)
				{
					if (Information.IsDate(tmpWanted.save_amwant_listed_date.Trim()))
					{
						Query = $"{Query},'{DateTime.Parse(tmpWanted.save_amwant_listed_date.Trim()).ToString("d")}'";
					}
					else
					{
						Query = $"{Query},NULL";
					}
				}
				else
				{
					Query = $"{Query},NULL";
				}

				if (tmpWanted.save_amwant_verified_date.Trim() != modGlobalVars.cEmptyString)
				{
					if (Information.IsDate(tmpWanted.save_amwant_verified_date.Trim()))
					{
						Query = $"{Query},'{DateTime.Parse(tmpWanted.save_amwant_verified_date.Trim()).ToString("d")}'";
					}
					else
					{
						Query = $"{Query},'{DateTime.Now.ToString("d")}'";
					}
				}
				else
				{
					Query = $"{Query},NULL";
				}

				if (tmpWanted.save_amwant_start_year.Trim() != modGlobalVars.cEmptyString && tmpWanted.save_amwant_start_year.Trim().ToUpper() != "OPEN")
				{

					if (!Information.IsNumeric(tmpWanted.save_amwant_start_year.Trim()) || Conversion.Val(tmpWanted.save_amwant_start_year.Trim()) < 1950 || Conversion.Val(tmpWanted.save_amwant_start_year.Trim()) > DateTime.Now.Year + 5)
					{ // cant want anything greater than 2 years from this year
						// cant want anything greater than 5 years from this year
						// keep eye on this this might need to expand
						MessageBox.Show("Start Year is Not Valid. Save Aborted.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						return result;
					}
					else
					{
						Query = $"{Query},'{StringsHelper.Format(tmpWanted.save_amwant_start_year.Trim(), "####")}'";
					}

					//if the start year is 'Open' then don't want to save end year.

					if (tmpWanted.save_amwant_end_year.Trim() != modGlobalVars.cEmptyString)
					{
						if (Information.IsNumeric(tmpWanted.save_amwant_end_year.Trim()))
						{
							Query = $"{Query},'{StringsHelper.Format(tmpWanted.save_amwant_end_year.Trim(), "####")}'";
						}
						else
						{
							Query = $"{Query},NULL";
						}
					}
					else
					{
						Query = $"{Query},NULL";
					}

				}
				else
				{
					Query = $"{Query},'Open',NULL";
				}

				if (tmpWanted.save_amwant_max_price > 0)
				{
					Query = $"{Query},{tmpWanted.save_amwant_max_price.ToString()}";
				}
				else
				{
					Query = $"{Query},NULL";
				}

				if (tmpWanted.save_amwant_max_aftt > 0)
				{
					Query = $"{Query},{tmpWanted.save_amwant_max_aftt.ToString()}";
				}
				else
				{
					Query = $"{Query},NULL";
				}

				Query = $"{Query},'{tmpWanted.save_amwant_accept_damage_hist.Trim()}'";
				Query = $"{Query},'{tmpWanted.save_amwant_accept_damage_cur.Trim()}' ,{in_CompanyID.ToString()},{in_JournalID.ToString()}";

				if (in_ContactID > 0)
				{
					Query = $"{Query},{in_ContactID.ToString()}";
				}
				else
				{
					Query = $"{Query},0";
				}

				if (tmpWanted.save_amwant_yearnote.Trim() != modGlobalVars.cEmptyString)
				{
					Query = $"{Query},'{modAdminCommon.Fix_Quote(tmpWanted.save_amwant_yearnote).Trim()}'";
				}
				else
				{
					Query = $"{Query},NULL";
				}

				if (tmpWanted.save_amwant_pricenote.Trim() != modGlobalVars.cEmptyString)
				{
					Query = $"{Query},'{modAdminCommon.Fix_Quote(tmpWanted.save_amwant_pricenote).Trim()}'";
				}
				else
				{
					Query = $"{Query},NULL";
				}

				if (tmpWanted.save_amwant_notes.Trim() != modGlobalVars.cEmptyString)
				{
					Query = $"{Query},'{modAdminCommon.Fix_Quote(tmpWanted.save_amwant_notes).Trim()}'";
				}
				else
				{
					Query = $"{Query},NULL";
				}

				if (modAdminCommon.gbl_User_ID.Trim() != modGlobalVars.cEmptyString)
				{
					Query = $"{Query},'{modAdminCommon.gbl_User_ID}'";
				}
				else
				{
					Query = $"{Query},NULL";
				}

				if (tmpWanted.save_amwant_auto_distribute_flag == ((short) CheckState.Checked))
				{
					Query = $"{Query},'Y'";

					if (tmpWanted.save_amwant_auto_distribute_email.Trim() != modGlobalVars.cEmptyString)
					{
						Query = $"{Query},'{modAdminCommon.Fix_Quote(tmpWanted.save_amwant_auto_distribute_email).Trim()}'";
					}
					else
					{
						Query = $"{Query},NULL";
					}

					if (tmpWanted.save_amwant_auto_distribute_replyname.Trim() != modGlobalVars.cEmptyString)
					{
						Query = $"{Query},'{modAdminCommon.Fix_Quote(tmpWanted.save_amwant_auto_distribute_replyname).Trim()}'";
					}
					else
					{
						Query = $"{Query},NULL";
					}

					Query = $"{Query},NULL)";

				}
				else
				{
					// if not checked on insert, enter null for all values
					Query = $"{Query},NULL,NULL,NULL,NULL)";
				}

				modAdminCommon.ADO_Transaction("BeginTrans");

				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = (CommandType) (((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()) + ((int) CommandType.Text));
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();

				modAdminCommon.Rec_Journal_Info.journ_subject = $"Added Wanted: {tmpWanted.save_amwant_model}";
				modAdminCommon.Rec_Journal_Info.journ_description = modGlobalVars.cEmptyString;
				modAdminCommon.Rec_Journal_Info.journ_ac_id = 0;
				modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "RN";
				modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTimeHelper.ToString(DateTime.Now));

				modAdminCommon.Rec_Journal_Info.journ_comp_id = in_CompanyID;
				modAdminCommon.Rec_Journal_Info.journ_contact_id = in_ContactID;
				modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
				modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
				modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
				modAdminCommon.Rec_Journal_Info.journ_status = "A";
				modAdminCommon.Rec_Journal_Info.journ_category_code = "AH";

				frm_Journal.DefInstance.Commit_Journal_Entry();

				if (Information.IsDate(tmpWanted.save_amwant_verified_date.Trim()) && next_amwant_id > 0)
				{

					tmpWanted.save_amwant_id = next_amwant_id;

					//send only fixed wing ac
					Query = $"SELECT amod_id FROM Aircraft_Model WITH(NOLOCK) WHERE amod_id = {tmpWanted.save_amwant_modelID.ToString()} AND amod_airframe_type_code ='F'";

					if (modAdminCommon.Exist(Query))
					{
						modAdminCommon.Record_Transmit(modGlobalVars.cEmptyString, next_amwant_id, in_JournalID, tmpWanted.save_amwant_modelID, "Wanted", "Add", ref tmpFields, in_CompanyID);
					}

				}

				modAdminCommon.ADO_Transaction("CommitTrans");


				return true;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"wanted_aircraft_insert_Error ({Information.Err().Number.ToString()}) {excep.Message}", "Company (modCompany)");
				modAdminCommon.ADO_Transaction("RollbackTrans");
				return result;
			}
		}

		internal static bool wanted_aircraft_update(int in_CompanyID, int in_JournalID, int in_ContactID, modGlobalVars.t_company_save_wanted_info tmpWanted, ref string[] arrConfirmWanted, string is_from_spot = "")
		{
			// Function used to update wanted record

			bool result = false;
			string Query = "";
			bool bInVerifiedList = false;
			int nLoop = 0;
			string[] tmpFields = new string[]{"", ""};
			tmpFields[0] = "";


			try
			{

				//build Aircraft_Model_Wanted table record
				Query = "UPDATE Aircraft_Model_Wanted SET";
				Query = $"{Query} amwant_amod_id = {tmpWanted.save_amwant_modelID.ToString().Trim()}";

				if (tmpWanted.save_amwant_listed_date.Trim() != modGlobalVars.cEmptyString)
				{
					if (Information.IsDate(tmpWanted.save_amwant_listed_date.Trim()))
					{
						Query = $"{Query}, amwant_listed_date = '{DateTime.Parse(tmpWanted.save_amwant_listed_date.Trim()).ToString("d")}'";
					}
					else
					{
						Query = $"{Query}, amwant_listed_date = NULL";
					}
				}
				else
				{
					Query = $"{Query}, amwant_listed_date = NULL";
				}

				if (tmpWanted.save_amwant_verified_date.Trim() != modGlobalVars.cEmptyString)
				{
					if (Information.IsDate(tmpWanted.save_amwant_verified_date.Trim()))
					{
						Query = $"{Query}, amwant_verified_date = '{DateTime.Parse(tmpWanted.save_amwant_verified_date.Trim()).ToString("d")}'";
					}
					else
					{
						Query = $"{Query}, amwant_verified_date = '{DateTime.Now.ToString("d")}'";
					}
				}
				else
				{
					Query = $"{Query}, amwant_verified_date = NULL";
				}

				if (tmpWanted.save_amwant_start_year.Trim() != modGlobalVars.cEmptyString && tmpWanted.save_amwant_start_year.Trim().ToUpper() != "OPEN")
				{

					if (!Information.IsNumeric(tmpWanted.save_amwant_start_year.Trim()) || Conversion.Val(tmpWanted.save_amwant_start_year.Trim()) < 1950 || Conversion.Val(tmpWanted.save_amwant_start_year.Trim()) > DateTime.Now.Year + 5)
					{
						// cant want anything greater than 5 years from this year
						// keep eye on this this might need to expand
						MessageBox.Show("Start Year is Not Valid. Update Aborted.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK);
						return result;
					}
					else
					{
						Query = $"{Query}, amwant_start_year = '{StringsHelper.Format(tmpWanted.save_amwant_start_year.Trim(), "####")}'";
					}

					//if the start year is 'Open' then don't want to save end year.

					if (tmpWanted.save_amwant_end_year.Trim() != modGlobalVars.cEmptyString)
					{
						if (Information.IsNumeric(tmpWanted.save_amwant_end_year.Trim()))
						{
							Query = $"{Query}, amwant_end_year = '{StringsHelper.Format(tmpWanted.save_amwant_end_year.Trim(), "####")}'";
						}
						else
						{
							Query = $"{Query}, amwant_end_year = NULL";
						}
					}
					else
					{
						Query = $"{Query}, amwant_end_year = NULL";
					}

				}
				else
				{
					Query = $"{Query}, amwant_start_year = 'Open', amwant_end_year = NULL";
				}

				if (tmpWanted.save_amwant_max_price > 0)
				{
					Query = $"{Query}, amwant_max_price = {tmpWanted.save_amwant_max_price.ToString()}";
				}
				else
				{
					Query = $"{Query}, amwant_max_price = NULL";
				}

				if (tmpWanted.save_amwant_max_aftt > 0)
				{
					Query = $"{Query}, amwant_max_aftt = {tmpWanted.save_amwant_max_aftt.ToString()}";
				}
				else
				{
					Query = $"{Query}, amwant_max_aftt = NULL";
				}

				Query = $"{Query}, amwant_accept_damage_hist = '{tmpWanted.save_amwant_accept_damage_hist.Trim()}'";
				Query = $"{Query}, amwant_accept_dam_cur = '{tmpWanted.save_amwant_accept_damage_cur.Trim()}'";
				Query = $"{Query}, amwant_comp_id = {in_CompanyID.ToString()}, amwant_journ_id = {in_JournalID.ToString()}";

				if (in_ContactID == 0)
				{
					Query = $"{Query}, amwant_contact_id = 0";
				}
				else
				{
					Query = $"{Query}, amwant_contact_id = {in_ContactID.ToString()}";
				}

				if (tmpWanted.save_amwant_yearnote.Trim() != modGlobalVars.cEmptyString)
				{
					Query = $"{Query}, amwant_year_note = '{modAdminCommon.Fix_Quote(tmpWanted.save_amwant_yearnote).Trim()}'";
				}
				else
				{
					Query = $"{Query}, amwant_year_note = NULL";
				}

				if (tmpWanted.save_amwant_pricenote.Trim() != modGlobalVars.cEmptyString)
				{
					Query = $"{Query}, amwant_amount_note = '{modAdminCommon.Fix_Quote(tmpWanted.save_amwant_pricenote).Trim()}'";
				}
				else
				{
					Query = $"{Query}, amwant_amount_note = NULL";
				}

				if (tmpWanted.save_amwant_notes.Trim() != modGlobalVars.cEmptyString)
				{
					Query = $"{Query}, amwant_notes = '{modAdminCommon.Fix_Quote(tmpWanted.save_amwant_notes).Trim()}'";
				}
				else
				{
					Query = $"{Query}, amwant_notes = NULL";
				}

				if (modAdminCommon.gbl_User_ID.Trim() != modGlobalVars.cEmptyString)
				{
					Query = $"{Query}, amwant_entry_user_id = '{modAdminCommon.gbl_User_ID}'";
				}
				else
				{
					Query = $"{Query}, amwant_entry_user_id = NULL";
				}

				if (tmpWanted.save_amwant_auto_distribute_flag == ((short) CheckState.Checked))
				{
					Query = $"{Query}, amwant_auto_distribute_flag = 'Y'";

					if (tmpWanted.save_amwant_auto_distribute_email.Trim() != modGlobalVars.cEmptyString)
					{
						Query = $"{Query}, amwant_auto_distribute_email = '{modAdminCommon.Fix_Quote(tmpWanted.save_amwant_auto_distribute_email).Trim()}'";
					}
					else
					{
						Query = $"{Query}, amwant_auto_distribute_email = NULL";
					}

					if (tmpWanted.save_amwant_auto_distribute_replyname.Trim() != modGlobalVars.cEmptyString)
					{
						Query = $"{Query}, amwant_auto_distribute_replyname = '{modAdminCommon.Fix_Quote(tmpWanted.save_amwant_auto_distribute_replyname).Trim()}'";
					}
					else
					{
						Query = $"{Query}, amwant_auto_distribute_replyname = NULL";
					}

					Query = $"{Query}, amwant_auto_unsubscribe_date = NULL";

				}
				else
				{
					Query = $"{Query}, amwant_auto_distribute_flag = 'N'";
					Query = $"{Query}, amwant_auto_unsubscribe_date = '{DateTime.Now.ToString()}'";
				}

				Query = $"{Query}, amwant_action_date = NULL, amwant_web_action_date = NULL";
				Query = $"{Query} WHERE amwant_id = {tmpWanted.save_amwant_id.ToString()}";

				modAdminCommon.ADO_Transaction("BeginTrans");

				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = (CommandType) (((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()) + ((int) CommandType.Text));
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();

				bInVerifiedList = has_wanted_been_verified(tmpWanted.save_amwant_id, arrConfirmWanted);

				if (is_from_spot.Trim() == "Save")
				{
					// if we just hit save, do not re-verify the wanted
				}
				else
				{
					if (!bInVerifiedList)
					{

						add_items_to_array_fields(ref arrConfirmWanted, tmpWanted.save_amwant_id.ToString());

						// RECORD A VERIFIED WANTED JOURNAL ENTRY
						// RTW - ADDED THIS ON 3/19/2004
						modAdminCommon.Rec_Journal_Info.journ_subject = $"Verified Wanted: {tmpWanted.save_amwant_model}";
						modAdminCommon.Rec_Journal_Info.journ_description = modGlobalVars.cEmptyString;
						modAdminCommon.Rec_Journal_Info.journ_ac_id = 0;
						modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "VW";
						modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTimeHelper.ToString(DateTime.Now));

						modAdminCommon.Rec_Journal_Info.journ_comp_id = in_CompanyID;
						modAdminCommon.Rec_Journal_Info.journ_contact_id = in_ContactID;
						modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
						modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
						modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
						modAdminCommon.Rec_Journal_Info.journ_status = "A";
						modAdminCommon.Rec_Journal_Info.journ_category_code = "AH";

						frm_Journal.DefInstance.Commit_Journal_Entry();
					}
				}

				if (Information.IsDate(tmpWanted.save_amwant_verified_date.Trim()))
				{
					//send only fixed wing ac
					Query = $"SELECT amod_id FROM Aircraft_Model WITH(NOLOCK) WHERE amod_id = {tmpWanted.save_amwant_modelID.ToString()} AND amod_airframe_type_code ='F'";

					if (modAdminCommon.Exist(Query))
					{
						modAdminCommon.Record_Transmit(modGlobalVars.cEmptyString, tmpWanted.save_amwant_id, in_JournalID, tmpWanted.save_amwant_modelID, "Wanted", "Change", ref tmpFields, in_CompanyID);
					}

				} //IsDate(Trim$(tmpWanted.save_amwant_verified_date))

				modAdminCommon.ADO_Transaction("CommitTrans");


				return true;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"wanted_aircraft_update_Error ({Information.Err().Number.ToString()}) {excep.Message}", "Company (modCompany)");
				modAdminCommon.ADO_Transaction("RollbackTrans");
				return result;
			}
		}

		internal static void add_items_to_array_fields(ref string[] arrFields, string inFieldValue)
		{

			try
			{

				// can only check this if array is initilized(0) = 0
				if (arrFields.GetUpperBound(0) == 0)
				{ // if the bounds of this array = 0 then put first element there
					arrFields[arrFields.GetUpperBound(0)] = inFieldValue.Trim();
					arrFields = ArraysHelper.RedimPreserve(arrFields, new int[]{arrFields.GetUpperBound(0) + 2});
					return;
				}

				arrFields[arrFields.GetUpperBound(0)] = inFieldValue.Trim();
				arrFields = ArraysHelper.RedimPreserve(arrFields, new int[]{arrFields.GetUpperBound(0) + 2});
			}
			catch
			{

				arrFields = new string[]{""};
				arrFields[arrFields.GetUpperBound(0)] = inFieldValue.Trim();
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1065
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
				return;
			}

		}

		internal static string strip_spaces_from_companyname(string in_CompanyName)
		{

			string result = "";
			result = modGlobalVars.cEmptyString;

			// ok - run the strip extra spaces routine on the company name
			string st_comp = $"{in_CompanyName.Trim()} ";
			StringBuilder tmp = new StringBuilder();
			tmp.Append(modGlobalVars.cEmptyString);
			int K = (st_comp.IndexOf(' ') + 1);

			while (K > 0)
			{
				tmp.Append($" {st_comp.Substring(Math.Min(0, st_comp.Length), Math.Min(K, Math.Max(0, st_comp.Length))).Trim()}");
				st_comp = $"{st_comp.Substring(Math.Min(K - 1, st_comp.Length)).Trim()} ";
				K = (st_comp.IndexOf(' ') + 1);
				if (Strings.Len(st_comp) == 1)
				{
					K = 0;
				}
			}

			return tmp.ToString();

		}

		internal static void auto_confirm_company_fields(int in_CompanyID, string[] arrVerifyFields, string address_change_text = "")
		{

			// PURPOSE: THE PURPOSE OF THIS PROCEDURE TO AUTOMATICALLY CONFIRM FIELDS THAT
			// HAVE BEEN CHANGED AS PART OF SAVING A COMPANY RECORD.
			//
			try
			{

				int iLoop = 0;
				iLoop = 0;
				string tmpField = "";
				tmpField = modGlobalVars.cEmptyString;
				string dsplyField = "";
				dsplyField = modGlobalVars.cEmptyString;
				StringBuilder Query = new StringBuilder();
				Query = new StringBuilder(modGlobalVars.cEmptyString);
				bool bSawFirstAddress = false;
				bSawFirstAddress = false;
				bool bSawSecondAddress = false;
				bSawSecondAddress = false;

				int tempForEndVar = arrVerifyFields.GetUpperBound(0);
				for (iLoop = 0; iLoop <= tempForEndVar; iLoop++)
				{

					switch(arrVerifyFields[iLoop].ToLower())
					{
						case "comp_address" : 
							tmpField = "comp_address"; 
							dsplyField = "Address"; 
							bSawFirstAddress = true; 
							break;
						case "comp_address2" : 
							tmpField = "comp_address"; 
							dsplyField = "Address"; 
							bSawSecondAddress = true; 
							break;
						case "comp_email_address" : 
							tmpField = "comp_email"; 
							dsplyField = "Email"; 
							break;
						case "comp_web_address" : 
							tmpField = "comp_web"; 
							dsplyField = "Web Address"; 
							break;
					}

					if (tmpField.Trim() != modGlobalVars.cEmptyString)
					{

						if ((bSawFirstAddress && !bSawSecondAddress) || (!bSawFirstAddress && bSawSecondAddress) || (!bSawFirstAddress && !bSawSecondAddress))
						{

							Query = new StringBuilder($"UPDATE company SET {tmpField}_confirm_date = '{DateTime.Now.ToString()}'");
							Query.Append($" WHERE comp_id = {in_CompanyID.ToString()} AND comp_journ_id = 0");

							modAdminCommon.ADO_Transaction("BeginTrans");
							DbCommand TempCommand = null;
							TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
							TempCommand.CommandText = Query.ToString();
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
							TempCommand.CommandType = (CommandType) (((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()) + ((int) CommandType.Text));
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
							TempCommand.ExecuteNonQuery();

							// INSERT A COMPANY CONFIRMATION JOURNAL ENTRY
							modAdminCommon.Rec_Journal_Info.journ_subject = $"Confirmed Company: {dsplyField}";
							modAdminCommon.Rec_Journal_Info.journ_description = address_change_text;
							modAdminCommon.Rec_Journal_Info.journ_ac_id = 0;
							modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "CPCFM";
							modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTimeHelper.ToString(DateTime.Now));
							modAdminCommon.Rec_Journal_Info.journ_comp_id = in_CompanyID;
							modAdminCommon.Rec_Journal_Info.journ_contact_id = 0;
							modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
							modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
							modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
							modAdminCommon.Rec_Journal_Info.journ_status = "A";
							modAdminCommon.Rec_Journal_Info.journ_category_code = "AR";

							frm_Journal.DefInstance.Commit_Journal_Entry();

							modAdminCommon.ADO_Transaction("CommitTrans");

							tmpField = modGlobalVars.cEmptyString;
							dsplyField = modGlobalVars.cEmptyString;

						}
						else
						{

							tmpField = modGlobalVars.cEmptyString;
							dsplyField = modGlobalVars.cEmptyString;

						}

					}

				}
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"auto_confirm_company_fields_Error ({Information.Err().Number.ToString()}) {excep.Message}", "Company (modCompany)");
				modAdminCommon.ADO_Transaction("RollbackTrans");

				return;
			}

		}

		internal static bool insert_accountrep_change_journal_note(int in_CompanyID, string enterAccountID, string exitAccountID)
		{

			// Function used to insert account rep changed journal note

			bool result = false;
			string Query = modGlobalVars.cEmptyString;
			ADORecordSetHelper ado_PrimaryAircraft = null;


			try
			{

				Query = "UPDATE Journal SET journ_subcategory_code = 'ANV'  WHERE journ_ac_id IN (";
				Query = $"{Query} SELECT ac_id FROM Aircraft_Model WITH(NOLOCK), Aircraft WITH(NOLOCK), Aircraft_Reference WITH(NOLOCK)";
				Query = $"{Query} WHERE cref_comp_id = {in_CompanyID.ToString()} and cref_journ_id = 0";
				Query = $"{Query} AND cref_ac_id = ac_id AND cref_journ_id = ac_journ_id AND ac_amod_id = amod_id AND cref_primary_poc_flag = 'Y'";
				Query = $"{Query} AND (amod_airframe_type_code = 'F' OR (amod_airframe_type_code = 'R' AND amod_class_code = 'A'))";
				Query = $"{Query} ) AND journ_subcategory_code = 'AA'";

				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = (CommandType) (((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()) + ((int) CommandType.Text));
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();

				// select fields from Aircraft_Model, Aircraft, Aircraft_Reference tables
				Query = "SELECT ac_id FROM Aircraft WITH(NOLOCK), Aircraft_Model WITH(NOLOCK), Aircraft_Reference WITH(NOLOCK)";
				Query = $"{Query} WHERE cref_comp_id = {in_CompanyID.ToString()} AND cref_journ_id = 0";
				Query = $"{Query} AND cref_ac_id = ac_id AND cref_journ_id = ac_journ_id AND ac_amod_id = amod_id AND cref_primary_poc_flag = 'Y'";
				Query = $"{Query} AND (amod_airframe_type_code = 'F' OR (amod_airframe_type_code = 'R' AND amod_class_code = 'A'))";

				ado_PrimaryAircraft = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(ado_PrimaryAircraft.Fields) && !(ado_PrimaryAircraft.BOF && ado_PrimaryAircraft.EOF))
				{


					while(!ado_PrimaryAircraft.EOF)
					{

						modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTimeHelper.ToString(DateTime.Now));
						modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "AA";
						modAdminCommon.Rec_Journal_Info.journ_subject = $"Account Rep Re-assigned From {enterAccountID} to {exitAccountID}";
						modAdminCommon.Rec_Journal_Info.journ_description = modGlobalVars.cEmptyString;
						modAdminCommon.Rec_Journal_Info.journ_ac_id = Convert.ToInt32(ado_PrimaryAircraft["ac_id"]);
						modAdminCommon.Rec_Journal_Info.journ_comp_id = in_CompanyID;
						modAdminCommon.Rec_Journal_Info.journ_contact_id = 0;
						modAdminCommon.Rec_Journal_Info.journ_prior_account_id = enterAccountID;

						modAdminCommon.Rec_Journal_Info.journ_account_id = exitAccountID;
						modAdminCommon.Rec_Journal_Info.journ_status = "A";

						frm_Journal.DefInstance.Commit_Journal_Entry();

						ado_PrimaryAircraft.MoveNext();

					};

					ado_PrimaryAircraft.Close();

				}

				ado_PrimaryAircraft = null;


				return true;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"insert_accountrep_change_journal_note_Error ({Information.Err().Number.ToString()}) {excep.Message}", "Company (modCompany)");
				return result;
			}
		}

		internal static bool build_journal_subject_fornamechange(int nSellerJournalID)
		{

			bool result = false;
			string sPrefix = "";
			string sSeparator = "";
			string Query = "";
			ADORecordSetHelper adoRs = null;
			int nSeqNO = 0;
			string sSubCatCode = "";
			int nSellerCompanyID = 0;
			int nBuyerCompanyID = 0;
			string sJournalSubject = "";

			try
			{

				result = false;

				//open the journal record
				Query = $"SELECT * FROM Journal WITH(NOLOCK) WHERE journ_id = {nSellerJournalID.ToString()}";
				adoRs = ADORecordSetHelper.Open(Query, modAdminCommon.ADODB_Trans_conn, "");

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(adoRs.Fields) && !(adoRs.BOF && adoRs.EOF))
				{
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(adoRs["journ_subcategory_code"]))
					{
						sSubCatCode = Convert.ToString(adoRs["journ_subcategory_code"]).Trim();
					}
					adoRs.Close();
				}
				else
				{
					adoRs = null;
					return result;
				}

				//use journal sub cat to find separator
				Query = $"SELECT jcat_subcategory_subjectprefix, jcat_subcategory_subjectseparator FROM Journal_Category WITH(NOLOCK) WHERE jcat_subcategory_code = '{sSubCatCode}'";

				adoRs = null;
				adoRs = ADORecordSetHelper.Open(Query, modAdminCommon.ADODB_Trans_conn, "");

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(adoRs.Fields) && !(adoRs.BOF && adoRs.EOF))
				{
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(adoRs["jcat_subcategory_subjectprefix"]))
					{
						sPrefix = Convert.ToString(adoRs["jcat_subcategory_subjectprefix"]).Trim();
					}
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(adoRs["jcat_subcategory_subjectseparator"]))
					{
						sSeparator = Convert.ToString(adoRs["jcat_subcategory_subjectseparator"]).Trim();
					}
					adoRs.Close();
				}

				adoRs = null;




				//----------------------------------------------------------------------------------------------------
				//get company ids for buyer and seller names
				Query = $"SELECT cref_transmit_seq_no,cref_comp_id FROM aircraft_reference WITH(NOLOCK)  WHERE cref_journ_id = {nSellerJournalID.ToString()}";
				Query = $"{Query} AND (cref_transmit_seq_no = 1 OR cref_transmit_seq_no = 10)  ORDER BY cref_transmit_seq_no";

				adoRs = ADORecordSetHelper.Open(Query, modAdminCommon.ADODB_Trans_conn, "");

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(adoRs.Fields) && !(adoRs.BOF && adoRs.EOF))
				{

					while (!adoRs.EOF)
					{

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(adoRs["cref_transmit_seq_no"]))
						{
							nSeqNO = Convert.ToInt32(adoRs["cref_transmit_seq_no"]);


							switch(nSeqNO)
							{
								case 1 : 
									//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049 
									if (!Convert.IsDBNull(adoRs["cref_comp_id"]))
									{
										nSellerCompanyID = Convert.ToInt32(adoRs["cref_comp_id"]);
									} 
									break;
								case 10 : 
									//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049 
									if (!Convert.IsDBNull(adoRs["cref_comp_id"]))
									{
										nBuyerCompanyID = Convert.ToInt32(adoRs["cref_comp_id"]);
									} 
									 
									break;
							}

						}

						adoRs.MoveNext();
					}

					adoRs.Close();

				}
				else
				{
					//--------------------------- IF JOURNAL ID DOESNT MATCH AN AC REFERENCE- --- TRY A YACHT


					//----------------------------------------------------------------------------------------------------
					//get company ids for buyer and seller names
					Query = $"SELECT yr_seq_no, yr_comp_id  FROM yacht_reference WITH(NOLOCK)  WHERE yr_journ_id = {nSellerJournalID.ToString()}";
					Query = $"{Query} AND (yr_seq_no = 1 OR yr_seq_no = 10)  ORDER BY yr_seq_no";

					adoRs = ADORecordSetHelper.Open(Query, modAdminCommon.ADODB_Trans_conn, "");

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(adoRs.Fields) && !(adoRs.BOF && adoRs.EOF))
					{

						while (!adoRs.EOF)
						{

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(adoRs["yr_seq_no"]))
							{
								nSeqNO = Convert.ToInt32(adoRs["yr_seq_no"]);


								switch(nSeqNO)
								{
									case 1 : 
										//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049 
										if (!Convert.IsDBNull(adoRs["yr_comp_id"]))
										{
											nSellerCompanyID = Convert.ToInt32(adoRs["yr_comp_id"]);
										} 
										break;
									case 10 : 
										//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049 
										if (!Convert.IsDBNull(adoRs["yr_comp_id"]))
										{
											nBuyerCompanyID = Convert.ToInt32(adoRs["yr_comp_id"]);
										} 
										 
										break;
								}

							}

							adoRs.MoveNext();
						}

						adoRs.Close();

					}
					else
					{
						adoRs = null; // if its neither, exit
						return result;
					}

					//--------------------------- IF JOURNAL ID DOESNT MATCH AN AC REFERENCE- --- TRY A YACHT
				}
				//----------------------------------------------------------------------------------------------------

				adoRs = null;

				if (nSellerCompanyID == 0 || nBuyerCompanyID == 0)
				{
					return result;
				}

				sJournalSubject = ($"{sPrefix}{modGlobalVars.cSingleSpace}{modCommon.GetCompanyName(nSellerCompanyID, nSellerJournalID).Trim()}" +
				                  $"{modGlobalVars.cSingleSpace}{sSeparator}{modGlobalVars.cSingleSpace}{modCommon.GetCompanyName(nBuyerCompanyID, nSellerJournalID).Trim()}").Trim();

				// Added MSW 10/05/15 ' to replace ' so that it doesnt error
				sJournalSubject = StringsHelper.Replace(sJournalSubject, "'", "''", 1, -1, CompareMethod.Binary);

				Query = $"UPDATE Journal SET journ_subject = '{sJournalSubject.Substring(0, Math.Min(120, sJournalSubject.Length))}' WHERE journ_id = {nSellerJournalID.ToString()}";

				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = (CommandType) (((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()) + ((int) CommandType.Text));
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();


				return true;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"build_journal_subject_fornamechange_Error ({Information.Err().Number.ToString()}) {excep.Message}", "Company (modCompany)");
				return result;
			}
		}



		internal static bool DoesCompanyHaveContactWithThisTitle(int nCompanyID, int nJournalID, string strTitle)
		{

			bool result = false;
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strMsg = "";
			string strType = "";

			try
			{

				result = false;
				strTitle = strTitle.Trim();

				if ((nCompanyID > 0) && (strTitle != ""))
				{
					strQuery1 = $"SELECT contact_id FROM Contact WITH (NOLOCK) WHERE (contact_comp_id = {nCompanyID.ToString()}) ";
					strQuery1 = $"{strQuery1}AND (contact_journ_id = {nJournalID.ToString()}) AND (contact_title = '{strTitle}') ";
					strQuery1 = $"{strQuery1}AND (contact_active_flag = 'Y')  AND (contact_hide_flag = 'N') ";

					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!(rstRec1.BOF && rstRec1.EOF))
					{
						result = true;
					}

					rstRec1.Close();

				} // If (lCompId > 0) And (strTitle <> "") Then

				rstRec1 = null;

				return result;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"DoesCompanyHaveContactWithThisTitle_Error ({Information.Err().Number.ToString()}) {excep.Message}", "Company (frm_Company)");
				return result;
			}
		} // DoesCompanyHaveContactWithThisTitle

		internal static bool Remove_AirBP_Company(int COMPANY_ID)
		{

			bool result = false;
			string Update_Query = "";
			string Query = "";
			ADORecordSetHelper snp_remove_check = new ADORecordSetHelper();
			string msg_to_display = "";
			string string_to_replace = "";

			//defaulting to false
			try
			{

				// making sure there is an id
				if (COMPANY_ID > 0)
				{

					msg_to_display = "Are You Sure You Want To Remove This Company From AirBP Listing?";
					Query = "SELECT comp_id, comp_name, comp_country, comp_description   from Company where ";
					Query = $"{Query} comp_journ_id = 0 and comp_product_airbp_flag = 'Y' and comp_id = {COMPANY_ID.ToString()}";

					if (snp_remove_check.State == ConnectionState.Open)
					{
						snp_remove_check.Close();
					}
					snp_remove_check = null;

					//changed to openstatic from forward only aey 7/28/04
					snp_remove_check.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!(snp_remove_check.BOF && snp_remove_check.EOF))
					{
						Update_Query = "";
						string_to_replace = "";
						if (Strings.Len(Convert.ToString(snp_remove_check["comp_description"])) > 0)
						{
							string_to_replace = Convert.ToString(snp_remove_check["comp_description"]);
							// if the is something in description set temp field for storage
						}
						string_to_replace = StringsHelper.Replace(string_to_replace, "'", "''", 1, -1, CompareMethod.Binary);
						// replace to make sure it goes in fine

						msg_to_display = $"{msg_to_display}{Environment.NewLine}{Environment.NewLine}{Convert.ToString(snp_remove_check["comp_name"])}";
						//Alert (snp_remove_check!Comp_Name)
						if (MessageBox.Show(msg_to_display, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
						{
							if (Strings.Len(string_to_replace) < 1970)
							{
								string_to_replace = $"{string_to_replace} *** NOT AN AIRBP COMPANY *** ";


								// changes the airbp_flag to N and adds text to description
								Update_Query = $"Update Company set comp_product_airbp_flag = 'N', comp_description = '{string_to_replace}' ";
								Update_Query = $"{Update_Query}where comp_id ={COMPANY_ID.ToString()}";
								DbCommand TempCommand = null;
								TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
								UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
								TempCommand.CommandText = Update_Query;
								UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
								TempCommand.ExecuteNonQuery();


								// inserts journal note when it is removed
								modAdminCommon.Rec_Journal_Info.journ_subject = "Removed Company from AirBP List";
								modAdminCommon.Rec_Journal_Info.journ_description = modGlobalVars.cEmptyString;
								modAdminCommon.Rec_Journal_Info.journ_ac_id = 0;
								modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "RN";
								modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTimeHelper.ToString(DateTime.Now));
								modAdminCommon.Rec_Journal_Info.journ_comp_id = COMPANY_ID;
								modAdminCommon.Rec_Journal_Info.journ_contact_id = 0;
								modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
								modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
								modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
								modAdminCommon.Rec_Journal_Info.journ_status = "A";
								modAdminCommon.Rec_Journal_Info.journ_category_code = "AR";
								frm_Journal.DefInstance.Commit_Journal_Entry();


							}
						}
						else
						{
							//dont remove
						}

					}

				}


				return true;
			}
			catch (System.Exception excep)
			{
				result = false;
				MessageBox.Show($"Remove_AirBP_Company_error: Company Not Removed From AirBP List - {excep.Message}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
			return result;
		}

		internal static void UpdateCompanyRecordWithNewAVDataId(int lCompId, int lJournId)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strAVDataId = "";

			try
			{

				if (lCompId > 0)
				{

					if (lJournId == 0)
					{

						strQuery1 = $"SELECT * FROM Company WHERE (comp_id = {lCompId.ToString()}) AND (comp_journ_id = {lJournId.ToString()}) ";

						rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);

						if (!rstRec1.BOF && !rstRec1.EOF)
						{

							if (($"{Convert.ToString(rstRec1["comp_avdata_id"])} ").Trim() == "")
							{
								strAVDataId = modCommon.CreateNewAVDataId();
								rstRec1["comp_avdata_id"] = strAVDataId;
								rstRec1["comp_action_date"] = DateTime.Parse("1/1/1900");
								rstRec1.UpdateBatch();
							}

						} // If rstRec1.BOF = False And rstRec1.EOF = False Then

						rstRec1.Close();

					} // If lJournId = 0 Then

				} // If lCompId > 0 Then

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"UpdateCompanyRecordWithNewAVDataId_Error: {excep.Message}");
			}

		} // UpdateCompanyRecordWithNewAVDataId
	}
}