using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Gui.Controls;
using UpgradeHelpers.Helpers;
using UpgradeStubs;

namespace JETNET_Homebase
{
	internal static class modCompanyFind
	{


		internal static void Assocate_Company_To_Company(int nRef_Company_ID, int nRef_Company_JID, modGlobalVars.t_find_form_exit_record reference_associate_rec, ComboBox cbo_selected_relation, ComboBox cbo_left_contact, ComboBox cbo_right_contact, bool bIsContactSearch, CheckState iHideFlag)
		{

			string Query = "";

			try
			{

				Query = $"SELECT compref_comp_id FROM Company_Reference WITH(NOLOCK) WHERE compref_comp_id = {nRef_Company_ID.ToString()}";
				Query = $"{Query} AND compref_journ_id = {nRef_Company_JID.ToString()} AND compref_rel_comp_id = {reference_associate_rec.nFoundCompanyID.ToString()}";

				if (bIsContactSearch)
				{
					Query = $"{Query} AND compref_rel_contact_id = {reference_associate_rec.nFoundContactID.ToString()}";
				}
				else
				{
					Query = $"{Query} AND compref_rel_contact_id = 0";
				}

				Query = $"{Query} AND compref_contact_type = '{reference_associate_rec.sFoundCompanyTYPE}'";

				if (modAdminCommon.Exist(Query))
				{
					MessageBox.Show("This Company Association Already Exists!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					return;
				}

				Query = "INSERT INTO Company_Reference ( compref_journ_id, compref_comp_id,  compref_contact_id,  compref_rel_comp_id, ";
				Query = $"{Query}compref_rel_contact_id,  compref_contact_type,  compref_internal_flag,  compref_hide_flag";
				Query = $"{Query}) VALUES ({nRef_Company_JID.ToString()},";

				if (cbo_selected_relation.SelectedIndex == 1)
				{

					// Right Side Company/Contact
					Query = $"{Query}{reference_associate_rec.nFoundCompanyID.ToString()},";

					if (cbo_right_contact.Items.Count > 0 && cbo_right_contact.SelectedIndex > -1)
					{
						Query = $"{Query}{cbo_right_contact.GetItemData(cbo_right_contact.SelectedIndex).ToString()},";
					}
					else
					{
						Query = $"{Query}0,";
					}

					// Left Side Company/Contact
					Query = $"{Query}{nRef_Company_ID.ToString()},";

					if (cbo_left_contact.Items.Count > 0 && cbo_left_contact.SelectedIndex > -1)
					{
						Query = $"{Query}{cbo_left_contact.GetItemData(cbo_left_contact.SelectedIndex).ToString()},";
					}
					else
					{
						Query = $"{Query}0,";
					}

				}
				else
				{
					// Swap the left/right

					// Left Side Company/Contact
					Query = $"{Query}{nRef_Company_ID.ToString()},";

					if (cbo_left_contact.Items.Count > 0 && cbo_left_contact.SelectedIndex > -1)
					{
						Query = $"{Query}{cbo_left_contact.GetItemData(cbo_left_contact.SelectedIndex).ToString()},";
					}
					else
					{
						Query = $"{Query}0,";
					}

					// Right Side Company/Contact
					Query = $"{Query}{reference_associate_rec.nFoundCompanyID.ToString()},";

					if (cbo_right_contact.Items.Count > 0 && cbo_right_contact.SelectedIndex > -1)
					{
						Query = $"{Query}{cbo_right_contact.GetItemData(cbo_right_contact.SelectedIndex).ToString()},";
					}
					else
					{
						Query = $"{Query}0,";
					}

				}

				Query = $"{Query}'{reference_associate_rec.sFoundCompanyTYPE}',";
				Query = $"{Query}'{Get_ItemFrom_Contact_Type_Array(reference_associate_rec.sFoundCompanyTYPE, reference_associate_rec.tEntryPoint, modGlobalVars.AIRCONT_INTERNAL)}',";

				// 03/19/2015 - By David D. Cruger
				// Added High Flag

				if (iHideFlag == CheckState.Checked)
				{
					Query = $"{Query}'Y'";
				}
				else
				{
					Query = $"{Query}'N'";
				}

				Query = $"{Query})";

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

				Query = $"UPDATE Company SET comp_action_date = NULL WHERE comp_id = {nRef_Company_ID.ToString()}";
				Query = $"{Query} AND comp_journ_id = {nRef_Company_JID.ToString()}";

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
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"Company to Company Association Error: {excep.Message}");
				modAdminCommon.ADO_Transaction("RollbackTrans");

				return;
			}

		}

		internal static bool CheckForProgramManager(int inCompanyId)
		{

			bool result = false;
			string Query = "";
			ADORecordSetHelper snpProgMgr = new ADORecordSetHelper();

			try
			{

				result = true;

				Query = "SELECT bustypref_type FROM Business_Type_Reference WITH(NOLOCK)";
				Query = $"{Query} WHERE bustypref_comp_id = {inCompanyId.ToString()} AND bustypref_journ_id = 0";

				//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseClient);

				snpProgMgr.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpProgMgr.BOF && snpProgMgr.EOF))
				{

					if (snpProgMgr.RecordCount > 2)
					{
						result = false;
					}
					else
					{

						while(!snpProgMgr.EOF)
						{
							if (Convert.ToString(snpProgMgr["bustypref_type"]).Trim().ToUpper() != "PN" && Convert.ToString(snpProgMgr["bustypref_type"]).Trim().ToUpper() != "PM")
							{
								result = false;
								break;
							}

							snpProgMgr.MoveNext();
						};
					}
				}

				//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseServer);

				snpProgMgr.Close();
				snpProgMgr = null;
				return result;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"CheckForProgramManager_Error: {excep.Message}");
				return result;
			}
		}

		internal static void Associate_Company(modGlobalVars.t_find_form_exit_record reference_associate_rec, bool bIsContactSearch, bool bIsAwaitingDocsCompany, bool is_yacht = false)
		{

			string Query = "";
			string tmpquery = "";
			DialogResult intPress = (DialogResult) 0;
			int OperatorSEQNo = 0; // sequence number for the operator
			string BusinessType = "";
			string strError = ""; // Hold The Error Description Value
			string strContactTypeName = "";
			string strDateTime = "";
			string strInsert1 = "";




			bool ac_has_bus_flag = false;
			bool ac_has_comm_flag = false;
			bool ac_has_heli_flag = false;
			bool comp_has_bus_flag = false;
			bool comp_has_comm_flag = false;
			bool comp_has_heli_flag = false;


			bool Historical_Company_Flag = false; // indicates if a historical company record is required
			bool Historical_Contact_Flag = false; // indicates if a historical contact record is required

			try
			{

				strError = $" Co_id:{reference_associate_rec.nFoundCompanyID.ToString()} {bIsContactSearch.ToString()}";

				OperatorSEQNo = 0;

				if (reference_associate_rec.sFoundContactTYPE.Trim() == "36")
				{
					tmpquery = "SELECT cref_transmit_seq_no FROM Aircraft_Reference WITH(NOLOCK)";
					tmpquery = $"{tmpquery} WHERE cref_comp_id = {reference_associate_rec.nFoundCompanyID.ToString()}";

					if (bIsContactSearch)
					{
						tmpquery = $"{tmpquery} AND cref_contact_id = {reference_associate_rec.nFoundContactID.ToString()}";
					}

					tmpquery = $"{tmpquery} AND cref_ac_id = {reference_associate_rec.nFoundAircraftID.ToString()}";
					tmpquery = $"{tmpquery} AND cref_transmit_seq_no = '2' AND cref_journ_id = {reference_associate_rec.nFoundAircraftJID.ToString()}";

					if (!modAdminCommon.Exist(tmpquery))
					{
						OperatorSEQNo = 2;
					}
					else
					{
						OperatorSEQNo = 99;
					}

				}

				//check to see if anyone has sequence number 2
				if (OperatorSEQNo == 2)
				{
					tmpquery = $"SELECT cref_transmit_seq_no FROM Aircraft_Reference WITH(NOLOCK) WHERE cref_ac_id = {reference_associate_rec.nFoundAircraftID.ToString()}";
					tmpquery = $"{tmpquery} AND cref_transmit_seq_no = '2'  AND cref_journ_id = {reference_associate_rec.nFoundAircraftJID.ToString()}";

					if (modAdminCommon.Exist(tmpquery))
					{
						OperatorSEQNo = 99;
					}

				}

				if (reference_associate_rec.nFoundAircraftJID > 0)
				{

					// CHECK FOR HISTORICAL COMPANY
					if (!modAdminCommon.Exist($"SELECT * FROM Company WITH(NOLOCK) WHERE comp_id = {reference_associate_rec.nFoundCompanyID.ToString()} AND comp_journ_id = {reference_associate_rec.nFoundAircraftJID.ToString()}"))
					{
						Historical_Company_Flag = true;
					} // if the historical company does not exist

					// CHECK FOR HISTORICAL CONTACT
					if (bIsContactSearch)
					{ // Contact was selected from list
						if (!modAdminCommon.Exist($"SELECT * FROM Contact WITH(NOLOCK) WHERE contact_id = {reference_associate_rec.nFoundContactID.ToString()} AND contact_journ_id = {reference_associate_rec.nFoundAircraftJID.ToString()}"))
						{
							Historical_Contact_Flag = true;
						} // if the historical contact does not exist
					} // if contact was selected
				} // if historical (with journal id)

				// ==================================================================================================
				// CHECK IF EXACT ASSOCIATION ALREADY EXISTS
				Query = $"SELECT * FROM Aircraft_Reference WITH(NOLOCK) WHERE cref_ac_id = {reference_associate_rec.nFoundAircraftID.ToString()}";
				Query = $"{Query} AND cref_journ_id = {reference_associate_rec.nFoundAircraftJID.ToString()}";
				Query = $"{Query} AND cref_comp_id = {reference_associate_rec.nFoundCompanyID.ToString()}";

				if (bIsContactSearch && bIsAwaitingDocsCompany)
				{
					Query = $"{Query} AND cref_contact_id = {reference_associate_rec.nFoundContactID.ToString()}";
				}
				else
				{
					Query = $"{Query} AND cref_contact_id = 0";
				}

				Query = $"{Query} AND cref_contact_type = '{reference_associate_rec.sFoundContactTYPE.Trim()}'";

				if (modAdminCommon.Exist(Query))
				{
					MessageBox.Show("The association identified already exists! Operation Cancelled.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					return;
				} // found the reference

				//Can't have multiples for:
				// 36 - Operator ' 44 - Chief Pilot  ' 62 - Registered As Owner ' 61 - Registered As Purchaser
				// 99 - Exclusive Broker  ' 93 - Exclusive Representative
				strError = "ctype:";

				if (reference_associate_rec.sFoundContactTYPE.Trim() == "36" || reference_associate_rec.sFoundContactTYPE.Trim() == "44" || reference_associate_rec.sFoundContactTYPE.Trim() == "62" || reference_associate_rec.sFoundContactTYPE.Trim() == "61" || reference_associate_rec.sFoundContactTYPE.Trim() == "99" || reference_associate_rec.sFoundContactTYPE.Trim() == "93")
				{

					// ***********************************************************
					// CHECK IF CONTACT TYPE EXISTS FOR THIS AIRCRAFT AND JOURNAL

					Query = $"SELECT * FROM Aircraft_Reference WITH(NOLOCK) WHERE cref_ac_id = {reference_associate_rec.nFoundAircraftID.ToString()}";
					Query = $"{Query} AND cref_journ_id = {reference_associate_rec.nFoundAircraftJID.ToString()}";
					Query = $"{Query} AND cref_contact_type = '{reference_associate_rec.sFoundContactTYPE.Trim()}'";

					if (modAdminCommon.Exist(Query))
					{ // contact type exists

						intPress = MessageBox.Show($"{Get_ItemFrom_Contact_Type_Array(reference_associate_rec.sFoundContactTYPE, reference_associate_rec.tEntryPoint, modGlobalVars.AIRCONT_NAME).Trim()} association already exists for this aircraft! Would you like to replace the existing reference?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo);

						if (intPress == System.Windows.Forms.DialogResult.No)
						{
							MessageBox.Show("Assocation Cancelled", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
							return;
						} // users wants to associate selected contact

					} // contact type exists for the ac/journal

				} // if actype_code = Operator or Chief Pilot or Registered as Owner...

				// **************************************************
				// ABORT IF THE COMPANY SELECTED HAS BEEN REMOVED
				if (!modAdminCommon.Exist($"SELECT * FROM Company WITH(NOLOCK) WHERE comp_id = {reference_associate_rec.nFoundCompanyID.ToString()} AND comp_journ_id = 0"))
				{
					MessageBox.Show($"Company No Longer Exists{Environment.NewLine}{Environment.NewLine}Association Cancelled", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					return;
				}

				// **********************************************************
				// QUIT IF ACTION REQUIRES DELETION OF THE OWNER
				if (Get_ItemFrom_Contact_Type_Array(reference_associate_rec.sFoundContactTYPE, reference_associate_rec.tEntryPoint, modGlobalVars.AIRCONT_NAME).Trim() == "Owner")
				{
					MessageBox.Show("Can't delete owner. Action Aborted!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					return;
				}

				if (reference_associate_rec.sFoundContactTYPE.Trim() == "44")
				{
					if (!bIsContactSearch)
					{
						MessageBox.Show("Must Select a Contact for Chief Pilot, not just a Company", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						return;
					}
				}

				// ******************************************************************
				// MAKE SURE THAT THE COMPANY SELECTED HAS A BUSINESS TYPE
				BusinessType = modCommon.GetBusinessTypeToUse(reference_associate_rec.nFoundCompanyID, 0);
				if (BusinessType == "")
				{
					return;
				}

				if (Historical_Company_Flag)
				{
					modCommon.Transaction_Get_Company_History_Recordsets(reference_associate_rec.nFoundCompanyID.ToString());
				}

				// -------------------------------------------------------------------------------------------
				// THIS AREA IS BEING ADDED IN - MSW - TO CHECK COMPANY FLAGS, and add flags if needed per the AC that we are attaching
				comp_has_bus_flag = modAdminCommon.Exist($"select top 1 comp_product_business_flag from company with (NOLOCK) where comp_journ_id = 0 and comp_id = {reference_associate_rec.nFoundCompanyID.ToString()} and comp_product_business_flag = 'Y'");
				comp_has_comm_flag = modAdminCommon.Exist($"select top 1 comp_product_commercial_flag from company with (NOLOCK) where comp_journ_id = 0 and comp_id = {reference_associate_rec.nFoundCompanyID.ToString()} and comp_product_commercial_flag = 'Y'");
				comp_has_heli_flag = modAdminCommon.Exist($"select top 1 comp_product_helicopter_flag from company with (NOLOCK) where comp_journ_id = 0 and comp_id = {reference_associate_rec.nFoundCompanyID.ToString()} and comp_product_helicopter_flag = 'Y' ");

				if (comp_has_bus_flag && comp_has_comm_flag && comp_has_heli_flag)
				{
					// then dont worry about it
				}
				else
				{
					if (!comp_has_bus_flag)
					{
						ac_has_bus_flag = modAdminCommon.Exist($"select top 1 ac_id from aircraft with (NOLOCK) where ac_journ_id = 0 and ac_id = {reference_associate_rec.nFoundAircraftID.ToString()} and ac_product_business_flag = 'Y'");
					}

					if (!comp_has_comm_flag)
					{
						ac_has_comm_flag = modAdminCommon.Exist($"select top 1 ac_id from aircraft with (NOLOCK) where ac_journ_id = 0 and ac_id = {reference_associate_rec.nFoundAircraftID.ToString()} and ac_product_commercial_flag = 'Y'");
					}

					if (!comp_has_heli_flag)
					{
						ac_has_heli_flag = modAdminCommon.Exist($"select top 1 ac_id from aircraft with (NOLOCK) where ac_journ_id = 0 and ac_id = {reference_associate_rec.nFoundAircraftID.ToString()} and ac_product_helicopter_flag = 'Y' ");
					}
				}


				// check if the ac has a flag but the company doesnt, then we need to update the company
				if (ac_has_bus_flag && !comp_has_bus_flag)
				{
					Query = $"UPDATE Company SET comp_product_business_flag = 'Y' WHERE (comp_id = {reference_associate_rec.nFoundCompanyID.ToString()}) and comp_journ_id = 0 ";
					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();
				}

				if (ac_has_comm_flag && !comp_has_comm_flag)
				{
					Query = $"UPDATE Company SET comp_product_commercial_flag = 'Y' WHERE (comp_id = {reference_associate_rec.nFoundCompanyID.ToString()}) and comp_journ_id = 0 ";
					DbCommand TempCommand_2 = null;
					TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
					TempCommand_2.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand_2.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
					TempCommand_2.ExecuteNonQuery();
				}

				if (ac_has_heli_flag && !comp_has_heli_flag)
				{
					Query = $"UPDATE Company SET comp_product_helicopter_flag = 'Y' WHERE (comp_id = {reference_associate_rec.nFoundCompanyID.ToString()}) and comp_journ_id = 0 ";
					DbCommand TempCommand_3 = null;
					TempCommand_3 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_3);
					TempCommand_3.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand_3.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_3);
					TempCommand_3.ExecuteNonQuery();
				}
				// -------------------------------------------------------------------------------------------


				// ***********************************************************
				// BEGIN THE TRANSACTION
				strError = $"start trans ctc:{reference_associate_rec.sFoundContactTYPE}";
				modAdminCommon.ADO_Transaction("BeginTrans");

				//Can't have multiples for:
				// 36 - Operator  ' 44 - Chief Pilot
				// 62 - Registered As Owner ' 61 - Registered As Purchaser
				// 99 - Exclusive Broker  ' 93 - Exclusive Representative
				if (reference_associate_rec.sFoundContactTYPE.Trim() == "36" || reference_associate_rec.sFoundContactTYPE.Trim() == "44" || reference_associate_rec.sFoundContactTYPE.Trim() == "62" || reference_associate_rec.sFoundContactTYPE.Trim() == "61" || reference_associate_rec.sFoundContactTYPE.Trim() == "99" || reference_associate_rec.sFoundContactTYPE.Trim() == "93")
				{

					//==============================================
					// DELETE THE CURRENT AC REFERENCE IF EXISTS
					Query = $"DELETE FROM Aircraft_Reference WHERE cref_ac_id = {reference_associate_rec.nFoundAircraftID.ToString()}";
					Query = $"{Query} AND cref_journ_id = {reference_associate_rec.nFoundAircraftJID.ToString()}";
					Query = $"{Query} AND cref_contact_type = '{reference_associate_rec.sFoundContactTYPE}'";

					DbCommand TempCommand_4 = null;
					TempCommand_4 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_4);
					TempCommand_4.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand_4.CommandType = (CommandType) (((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()) + ((int) CommandType.Text));
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_4);
					TempCommand_4.ExecuteNonQuery();

				}

				//===========================================================
				// SAVE A COPY OF THE HISTORICAL COMPANY/CONTACT WITH JOURNAL ID IF NECESSARY
				if (reference_associate_rec.nFoundAircraftJID > 0)
				{
					strError = "start trans j>0";
					// CHECK FOR HISTORICAL COMPANY
					if (Historical_Company_Flag)
					{
						if (!modCommon.Transaction_Save_Company_History(reference_associate_rec.nFoundAircraftJID, ref modGlobalVars.snp_Company, ref modGlobalVars.snp_Contacts, ref modGlobalVars.snp_Company_Phones, ref modGlobalVars.snp_Company_Btypes, ref modGlobalVars.snp_Company_Certs))
						{
							modAdminCommon.ADO_Transaction("RollbackTrans");
							return;
						}
						else
						{
							modAdminCommon.ADO_Transaction("CommitTrans");
						}

					} // if the historical company does not exist

				} // if historical (with journal id)

				Application.DoEvents();
				Application.DoEvents();
				// ADDED MSW - 4/14/2016 - to not insert ac record if we have already entrered a yacht reference record
				if (!is_yacht)
				{
					Application.DoEvents();
					Application.DoEvents();
					//============================================================
					// INSERT THE AIRCRAFT REFERENCE
					strError = "start trans insert";

					Query = "INSERT INTO Aircraft_Reference (cref_ac_id, cref_journ_id, cref_comp_id, cref_contact_id, cref_contact_type,";
					Query = $"{Query}cref_primary_poc_flag, cref_business_type, cref_transmit_seq_no, cref_owner_percent)"; //aey 3/10/05
					Query = $"{Query} values ({reference_associate_rec.nFoundAircraftID.ToString()},";
					Query = $"{Query}{reference_associate_rec.nFoundAircraftJID.ToString()},";

					if (bIsAwaitingDocsCompany)
					{
						Query = $"{Query}{reference_associate_rec.nFoundAwaitingDocsID.ToString()},";
					}
					else
					{
						Query = $"{Query}{reference_associate_rec.nFoundCompanyID.ToString()},";
					}

					if (bIsContactSearch && !bIsAwaitingDocsCompany)
					{
						Query = $"{Query}{reference_associate_rec.nFoundContactID.ToString()},";
					}
					else
					{
						Query = $"{Query}0,";
					}

					Query = $"{Query}'{reference_associate_rec.sFoundContactTYPE.Trim()}',";

					if (reference_associate_rec.sFoundContactTYPE.Trim() == "44" && !bIsAwaitingDocsCompany)
					{
						if (bIsContactSearch)
						{
							if (reference_associate_rec.nFoundContactID > 0)
							{
								modCommon.InsertPriorityEvent("NCHP", reference_associate_rec.nFoundAircraftID, 0, modCommon.GetContactName(reference_associate_rec.nFoundContactID, 0), reference_associate_rec.nFoundCompanyID, reference_associate_rec.nFoundContactID);
							}
							else
							{
								modCommon.InsertPriorityEvent("NCHP", reference_associate_rec.nFoundAircraftID, 0, modCommon.GetCompanyName(reference_associate_rec.nFoundCompanyID, 0, 1), reference_associate_rec.nFoundCompanyID);
							}
						}
						else
						{
							modCommon.InsertPriorityEvent("NCHP", reference_associate_rec.nFoundAircraftID, 0, modCommon.GetCompanyName(reference_associate_rec.nFoundCompanyID, 0, 1), reference_associate_rec.nFoundCompanyID);
						}

						// added MSW - 6/10/22
						strDateTime = DateTimeHelper.ToString(DateTime.Now);
						strInsert1 = "INSERT INTO Journal (journ_subcategory_code, journ_description,journ_subject, journ_contact_id, journ_comp_id, ";
						strInsert1 = $"{strInsert1}journ_user_id, journ_status, journ_entry_date, journ_entry_time, journ_action_date, journ_date, journ_ac_id ";
						strInsert1 = $"{strInsert1}) VALUES ('RN', '";

						strInsert1 = $"{strInsert1}New Chief Pilot - {modCommon.GetCompanyName(reference_associate_rec.nFoundCompanyID, 0, 1)}', 'New Chief Pilot - {modCommon.GetCompanyName(reference_associate_rec.nFoundCompanyID, 0, 1)}'";
						strInsert1 = $"{strInsert1},0, {reference_associate_rec.nFoundCompanyID.ToString()}, '{modAdminCommon.gbl_User_ID}', 'A', ";
						strInsert1 = $"{strInsert1}'{DateTime.Parse(strDateTime).ToString("d")}', ";
						strInsert1 = $"{strInsert1}'{Strings.FormatDateTime(DateTime.Parse(strDateTime), DateFormat.ShortTime)}', ";
						strInsert1 = $"{strInsert1}'{DateTime.Parse(strDateTime).ToString()}', '{DateTime.Parse(strDateTime).ToString("d")}'";
						strInsert1 = $"{strInsert1},{reference_associate_rec.nFoundAircraftID.ToString()}";
						strInsert1 = $"{strInsert1}) ";

						modAdminCommon.ADO_Transaction("BeginTrans");
						DbCommand TempCommand_5 = null;
						TempCommand_5 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_5);
						TempCommand_5.CommandText = strInsert1;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand_5.CommandType = (CommandType) (((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()) + ((int) CommandType.Text));
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_5);
						TempCommand_5.ExecuteNonQuery();
						modAdminCommon.ADO_Transaction("CommitTrans");
					}

					Application.DoEvents();
					Application.DoEvents();


					if (reference_associate_rec.sFoundContactTYPE.Trim() == "62")
					{
						modCommon.InsertPriorityEvent("NREGTO", reference_associate_rec.nFoundAircraftID, 0, modCommon.GetCompanyName(reference_associate_rec.nFoundCompanyID, 0, 1), reference_associate_rec.nFoundCompanyID);
					}



					if (reference_associate_rec.sFoundContactTYPE.Trim() == "94" && !bIsAwaitingDocsCompany)
					{
						modCommon.InsertPriorityEvent("NCHCMP", reference_associate_rec.nFoundAircraftID, 0, modCommon.GetCompanyName(reference_associate_rec.nFoundCompanyID, 0, 1), reference_associate_rec.nFoundCompanyID);

						strDateTime = DateTimeHelper.ToString(DateTime.Now);
						strInsert1 = "INSERT INTO Journal (journ_subcategory_code, journ_description,journ_subject, journ_contact_id, journ_comp_id, ";
						strInsert1 = $"{strInsert1}journ_user_id, journ_status, journ_entry_date, journ_entry_time, journ_action_date, journ_date, journ_ac_id ";
						strInsert1 = $"{strInsert1}) VALUES ('RN', '";

						strInsert1 = $"{strInsert1}New Charter Company - {modCommon.GetCompanyName(reference_associate_rec.nFoundCompanyID, 0, 1)}', 'New Charter Company - {modCommon.GetCompanyName(reference_associate_rec.nFoundCompanyID, 0, 1)}'";
						strInsert1 = $"{strInsert1},0, {reference_associate_rec.nFoundCompanyID.ToString()}, '{modAdminCommon.gbl_User_ID}', 'A', ";
						strInsert1 = $"{strInsert1}'{DateTime.Parse(strDateTime).ToString("d")}', ";
						strInsert1 = $"{strInsert1}'{Strings.FormatDateTime(DateTime.Parse(strDateTime), DateFormat.ShortTime)}', ";
						strInsert1 = $"{strInsert1}'{DateTime.Parse(strDateTime).ToString()}', '{DateTime.Parse(strDateTime).ToString("d")}'";
						strInsert1 = $"{strInsert1},{reference_associate_rec.nFoundAircraftID.ToString()}";
						strInsert1 = $"{strInsert1}) ";

						modAdminCommon.ADO_Transaction("BeginTrans");
						DbCommand TempCommand_6 = null;
						TempCommand_6 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_6);
						TempCommand_6.CommandText = strInsert1;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand_6.CommandType = (CommandType) (((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()) + ((int) CommandType.Text));
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_6);
						TempCommand_6.ExecuteNonQuery();
						modAdminCommon.ADO_Transaction("CommitTrans");
					}

					if (reference_associate_rec.sFoundContactTYPE.Trim() == "31" && !bIsAwaitingDocsCompany)
					{
						modCommon.InsertPriorityEvent("NAMCMP", reference_associate_rec.nFoundAircraftID, 0, modCommon.GetCompanyName(reference_associate_rec.nFoundCompanyID, 0, 1), reference_associate_rec.nFoundCompanyID);

						strDateTime = DateTimeHelper.ToString(DateTime.Now);
						strInsert1 = "INSERT INTO Journal (journ_subcategory_code, journ_description,journ_subject, journ_contact_id, journ_comp_id, ";
						strInsert1 = $"{strInsert1}journ_user_id, journ_status, journ_entry_date, journ_entry_time, journ_action_date, journ_date, journ_ac_id ";
						strInsert1 = $"{strInsert1}) VALUES ('RN', '";

						strInsert1 = $"{strInsert1}New Aircraft Management Company - {modCommon.GetCompanyName(reference_associate_rec.nFoundCompanyID, 0, 1)}', 'New Aircraft Management Company - {modCommon.GetCompanyName(reference_associate_rec.nFoundCompanyID, 0, 1)}'";
						strInsert1 = $"{strInsert1},0, {reference_associate_rec.nFoundCompanyID.ToString()}, '{modAdminCommon.gbl_User_ID}', 'A', ";
						strInsert1 = $"{strInsert1}'{DateTime.Parse(strDateTime).ToString("d")}', ";
						strInsert1 = $"{strInsert1}'{Strings.FormatDateTime(DateTime.Parse(strDateTime), DateFormat.ShortTime)}', ";
						strInsert1 = $"{strInsert1}'{DateTime.Parse(strDateTime).ToString()}', '{DateTime.Parse(strDateTime).ToString("d")}'";
						strInsert1 = $"{strInsert1},{reference_associate_rec.nFoundAircraftID.ToString()}";
						strInsert1 = $"{strInsert1}) ";

						modAdminCommon.ADO_Transaction("BeginTrans");
						DbCommand TempCommand_7 = null;
						TempCommand_7 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_7);
						TempCommand_7.CommandText = strInsert1;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand_7.CommandType = (CommandType) (((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()) + ((int) CommandType.Text));
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_7);
						TempCommand_7.ExecuteNonQuery();
						modAdminCommon.ADO_Transaction("CommitTrans");
					}

					if (reference_associate_rec.sFoundContactTYPE.Trim() == "38" && !bIsAwaitingDocsCompany)
					{
						modCommon.InsertPriorityEvent("NSCPCT", reference_associate_rec.nFoundAircraftID, 0, modCommon.GetCompanyName(reference_associate_rec.nFoundCompanyID, 0, 1), reference_associate_rec.nFoundCompanyID);
					}

					if (reference_associate_rec.sFoundContactTYPE.Trim() == "2X" && !bIsAwaitingDocsCompany)
					{
						modCommon.InsertPriorityEvent("NNESC", reference_associate_rec.nFoundAircraftID, 0, modCommon.GetCompanyName(reference_associate_rec.nFoundCompanyID, 0, 1), reference_associate_rec.nFoundCompanyID);
					}
					//----------------------------------------------

					Application.DoEvents();
					Application.DoEvents();


					// MSW/RTW this is inserting an event when a delivery position holder association is added - 7/19/2011
					if (reference_associate_rec.sFoundContactTYPE.Trim() == "42" && !bIsAwaitingDocsCompany)
					{
						modCommon.InsertPriorityEvent("NDP", reference_associate_rec.nFoundAircraftID, 0, modCommon.GetCompanyName(reference_associate_rec.nFoundCompanyID, 0, 1), reference_associate_rec.nFoundCompanyID);
					}

					if (reference_associate_rec.sFoundContactTYPE.Trim() == "36" && !bIsAwaitingDocsCompany)
					{
						modCommon.InsertPriorityEvent("NOPR", reference_associate_rec.nFoundAircraftID, 0, modCommon.GetCompanyName(reference_associate_rec.nFoundCompanyID, 0, 1), reference_associate_rec.nFoundCompanyID);
					}

					// 08/22/2016 - By David D. Cruger; Added
					// Record Event Log With Any Aircraft Reference Added
					strContactTypeName = modCommon.DLookUp("actype_name", "Aircraft_Contact_Type", $"(actype_code='{reference_associate_rec.sFoundContactTYPE}')");
					modAdminCommon.Record_Event("Aircraft Reference", $"Added Aircraft Reference Type {reference_associate_rec.sFoundContactTYPE}={strContactTypeName} [{modCommon.GetCompanyName(reference_associate_rec.nFoundCompanyID, 0, 1)}]", reference_associate_rec.nFoundAircraftID, 0, reference_associate_rec.nFoundCompanyID, false, 0, reference_associate_rec.nFoundContactID);

					Query = $"{Query}'N',";
					Query = $"{Query}'{BusinessType.Substring(0, Math.Min(BusinessType.IndexOf('-'), BusinessType.Length)).Trim()}',";

					strError = "start trans case";


					switch(reference_associate_rec.sFoundContactTYPE.Trim())
					{
						case "36" : 
							Query = $"{Query}{OperatorSEQNo.ToString()},0)"; 
							 
							break;
						case "44" : 
							Query = $"{Query}3,0)"; 
							 
							break;
						case "99" : 
							Query = $"{Query}4,0)"; 
							 
							break;
						case "93" : 
							Query = $"{Query}5,0)"; 
							 
							break;
						case "62" : case "60" : 
							Query = $"{Query}9,0)"; 
							 
							break;
						case "96" : 
							Query = $"{Query}10,0)"; 
							 
							break;
						case "61" : 
							Query = $"{Query}11,0)"; 
							 
							break;
						default:
							Query = $"{Query}99,0)"; 
							 
							break;
					}


					modAdminCommon.ADO_Transaction("BeginTrans");
					Application.DoEvents();
					Application.DoEvents();
					DbCommand TempCommand_8 = null;
					TempCommand_8 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_8);
					TempCommand_8.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand_8.CommandType = (CommandType) (((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()) + ((int) CommandType.Text));
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_8);
					TempCommand_8.ExecuteNonQuery();

					Application.DoEvents();
					modAdminCommon.ADO_Transaction("CommitTrans");
					Application.DoEvents();

					strError = "start trans update";
					modAdminCommon.ADO_Transaction("BeginTrans");

					Query = $"UPDATE Aircraft SET ac_upd_date = '{DateTime.Now.ToString("d")}',  ac_upd_user_id = '{modAdminCommon.gbl_User_ID}',";
					Query = $"{Query} ac_action_date = NULL  WHERE ac_id = {reference_associate_rec.nFoundAircraftID.ToString()}";
					Query = $"{Query} AND ac_journ_id = {reference_associate_rec.nFoundAircraftJID.ToString()}";

					DbCommand TempCommand_9 = null;
					TempCommand_9 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_9);
					TempCommand_9.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand_9.CommandType = (CommandType) (((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()) + ((int) CommandType.Text));
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_9);
					TempCommand_9.ExecuteNonQuery();

					strError = "close trans";

					modAdminCommon.ADO_Transaction("CommitTrans");
					Application.DoEvents();
					Application.DoEvents();

					strError = "stats";

					modCommon.Company_Stats_Update(reference_associate_rec.nFoundCompanyID);
					Application.DoEvents();
					Application.DoEvents();

					strError = "action date";

					modCommon.ClearAircraftActionDate(reference_associate_rec.nFoundAircraftID, reference_associate_rec.nFoundAircraftJID);
				}
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				strError = $"{strError} {Information.Err().Number.ToString()} {excep.Message}";
				modAdminCommon.Report_Error($"Associate_Company_Error: comp_id-{reference_associate_rec.nFoundCompanyID.ToString()} {strError}"); // aey 6/22/04
				modAdminCommon.ADO_Transaction("RollbackTrans");

				return;
			}


		}

		internal static bool VerifyExclusiveBusinessType(int inCompanyId, string inType)
		{

			string Query = "";

			try
			{

				Query = "SELECT * FROM Business_Type_Reference WITH(NOLOCK), Company_Business_Type WITH(NOLOCK) WHERE cbus_type = bustypref_type";
				Query = $"{Query} AND bustypref_comp_id = {inCompanyId.ToString()} AND bustypref_journ_id = 0";

				if (inType == "Exclusive Broker")
				{
					Query = $"{Query} AND cbus_type = 'DB'";
				}
				else
				{
					Query = $"{Query} AND cbus_type <> 'DB'";
				}


				return modAdminCommon.Exist(Query);
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"VerifyExclusiveBusinessType_Error ({Information.Err().Number.ToString()}) {excep.Message}");
				return false;
			}
		}

		internal static int Get_Company_Aircraft_Count(int in_company_id, int in_journal_id, UpgradeHelpers.DataGridViewFlex grd_selected_company)
		{

			int result = 0;
			string sQuery = "";
			int nCounter = 0;
			ADORecordSetHelper snpACCount = new ADORecordSetHelper();
			bool bPrimary = false;
			int nRememberID = 0;

			try
			{

				sQuery = "SELECT DISTINCT ac_id, cref_primary_poc_flag from Aircraft WITH(NOLOCK), Aircraft_Reference WITH(NOLOCK)";
				sQuery = $"{sQuery} WHERE (cref_comp_id = {in_company_id.ToString()} AND cref_journ_id = {in_journal_id.ToString()})";
				sQuery = $"{sQuery} AND (cref_ac_id = ac_id and cref_journ_id = ac_journ_id)  ORDER BY ac_id";

				snpACCount.Open(sQuery, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				nCounter = 0;
				nRememberID = 0;
				bPrimary = false;

				if (!(snpACCount.BOF && snpACCount.EOF))
				{

					while(!snpACCount.EOF)
					{
						if (nRememberID != Convert.ToInt32(snpACCount["ac_id"]))
						{
							nCounter++;
						}
						if (Convert.ToString(snpACCount["cref_primary_poc_flag"]).ToUpper() == "Y")
						{
							bPrimary = true;
						}
						nRememberID = Convert.ToInt32(snpACCount["ac_id"]);
						snpACCount.MoveNext();
					};
					result = nCounter;
				}
				else
				{
					result = 0;
				}

				if (bPrimary)
				{
					grd_selected_company.CellBackColor = Color.Yellow;
				}

				snpACCount.Close();
				snpACCount = null;

				return result;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Get_Company_Aircraft_Count_Error ({Information.Err().Number.ToString()}) {excep.Message}");
				return result;
			}
		}

		internal static void FillContactLists(int inCompany1ID, int inCompany2ID, int inContact2ID, ComboBox cbo_to_fill1, ComboBox cbo_to_fill2, bool bIsContactSearch)
		{

			string Query = "";
			ADORecordSetHelper snpContact = new ADORecordSetHelper();
			int i = 0;

			try
			{

				cbo_to_fill1.Visible = false;
				cbo_to_fill1.Items.Clear();
				cbo_to_fill1.AddItem("");

				Query = $"SELECT contact_id, contact_first_name, contact_last_name FROM Contact WITH(NOLOCK) WHERE contact_comp_id = {inCompany1ID.ToString()}";
				Query = $"{Query} AND contact_journ_id = 0 AND contact_active_flag = 'Y'";

				snpContact.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpContact.BOF && snpContact.EOF))
				{

					while(!snpContact.EOF)
					{
						cbo_to_fill1.AddItem($"{Convert.ToString(snpContact["contact_first_name"]).Trim()} {Convert.ToString(snpContact["contact_last_name"]).Trim()}");
						cbo_to_fill1.SetItemData(cbo_to_fill1.Items.Count - 1, Convert.ToInt32(snpContact["contact_id"]));
						snpContact.MoveNext();
					};

					if (cbo_to_fill1.Items.Count > 0)
					{
						cbo_to_fill1.SelectedIndex = 0;
					}
					else
					{
						cbo_to_fill1.SelectedIndex = -1;
					}

					cbo_to_fill1.Visible = true;

				}

				snpContact.Close();

				cbo_to_fill2.Visible = false;
				cbo_to_fill2.Items.Clear();
				cbo_to_fill2.AddItem("");

				if (inCompany2ID > 0)
				{

					Query = $"SELECT contact_id, contact_first_name, contact_last_name  FROM Contact WITH(NOLOCK) WHERE contact_comp_id = {inCompany2ID.ToString()}";
					Query = $"{Query} AND contact_journ_id = 0 AND contact_active_flag = 'Y'";

					snpContact.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!(snpContact.BOF && snpContact.EOF))
					{


						while(!snpContact.EOF)
						{
							cbo_to_fill2.AddItem($"{Convert.ToString(snpContact["contact_first_name"]).Trim()} {Convert.ToString(snpContact["contact_last_name"]).Trim()}");
							cbo_to_fill2.SetItemData(cbo_to_fill2.Items.Count - 1, Convert.ToInt32(snpContact["contact_id"]));
							snpContact.MoveNext();
						};

						if (cbo_to_fill2.Items.Count > 0)
						{
							cbo_to_fill2.SelectedIndex = 0;
						}
						else
						{
							cbo_to_fill2.SelectedIndex = -1;
						}

						cbo_to_fill2.Visible = true;

						snpContact.Close();


					} // Not (snpContact.BOF And snpContact.EOF)

				} // inCompany2ID > 0

				snpContact = null;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"FillContactLists_Error ({Information.Err().Number.ToString()}) {excep.Message}");
				return;
			}

		}

		internal static string GetCompanyRoles(int inCompanyId, int inJournalId)
		{

			string result = "";
			string Query = "";
			string Separator = "";
			ADORecordSetHelper snpRoles = new ADORecordSetHelper();

			try
			{

				result = "";

				Query = "SELECT compref_comp_id, actype_name, actype_compref_twoway_flag, actype_compref_name2";
				Query = $"{Query} FROM Company_Reference WITH(NOLOCK), Aircraft_Contact_Type WITH(NOLOCK)";
				Query = $"{Query} WHERE actype_code = compref_contact_type AND compref_journ_id = {inJournalId.ToString()}";
				Query = $"{Query} AND (compref_comp_id = {inCompanyId.ToString()} OR compref_rel_comp_id = {inCompanyId.ToString()})";

				snpRoles.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpRoles.BOF && snpRoles.EOF))
				{


					while(!snpRoles.EOF)
					{

						if (Convert.ToInt32(snpRoles["compref_comp_id"]) != inCompanyId)
						{
							if (Convert.ToString(snpRoles["actype_compref_twoway_flag"]).ToUpper() == "Y")
							{
								if (!(result.IndexOf(Convert.ToString(snpRoles["actype_compref_name2"]).Trim()) >= 0))
								{
									result = $"{result}{Separator}{Convert.ToString(snpRoles["actype_compref_name2"]).Trim()}";
								}
							}
							else
							{
								if (!(result.IndexOf(Convert.ToString(snpRoles["actype_name"]).Trim()) >= 0))
								{
									result = $"{result}{Separator}{Convert.ToString(snpRoles["actype_name"]).Trim()}";
								}
							}
						}
						else
						{
							if (!(result.IndexOf(Convert.ToString(snpRoles["actype_name"]).Trim()) >= 0))
							{
								result = $"{result}{Separator}{Convert.ToString(snpRoles["actype_name"]).Trim()}";
							}
						}

						snpRoles.MoveNext();

						Separator = "/";

					};
				}

				snpRoles.Close();
				snpRoles = null;

				return result;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"GetCompanyRoles_Error: {excep.Message}");
				return result;
			}
		}

		internal static bool CompanyAircraftLocked(int inCompanyId, int inJournalId)
		{

			bool result = false;
			string sQuery = "";
			ADORecordSetHelper snpACRef = null;

			try
			{

				result = false;

				sQuery = "SELECT * FROM Aircraft_Reference WITH(NOLOCK)";
				sQuery = $"{sQuery} WHERE cref_comp_id = {inCompanyId.ToString()}";
				sQuery = $"{sQuery} AND cref_journ_id = {inJournalId.ToString()}";

				snpACRef = ADORecordSetHelper.Open(sQuery, modAdminCommon.LOCAL_ADO_DB, "");

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(snpACRef.Fields) && !(snpACRef.EOF && snpACRef.EOF))
				{


					while(!snpACRef.EOF)
					{

						sQuery = "";
						sQuery = $"SELECT * FROM Aircraft_Lock WITH(NOLOCK) WHERE alock_ac_id = {Convert.ToString(snpACRef["cref_ac_id"])}";

						if (modAdminCommon.Exist(sQuery))
						{
							result = true;
							break;
						}

						snpACRef.MoveNext();
					};

					snpACRef.Close();

				}

				snpACRef = null;

				return result;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"CompanyAircraftLocked_Error ({Information.Err().Number.ToString()}) {excep.Message} : CMPID[{inCompanyId.ToString()}] JID[{inJournalId.ToString()}]", "modCompanyFind(ACLOCK)");

				return result;
			}
		}

		internal static void Remove_Duplicate(int inCompanyId, int inDupCompanyID, int inDupCompanyJID, Panel pnl_to_show, CheckState isHistorical)
		{

			DialogResult intPress = (DialogResult) 0;

			string Query = "";
			string Query1 = "";
			string Query2 = "";
			string Query3 = "";
			string strOwnerNew = "";
			string strOwnerOld = "";
			string strAircraftNew = "";
			string strAircraftOld = "";
			string[] arrChangedFields = new string[]{""};
			string strUpdate1 = "";
			string strQuery1 = "";
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper(); // recordset for checking on fractional owner
			bool bContinue = false;

			try
			{

				intPress = MessageBox.Show($"Are you sure that you want to remove {modCommon.GetCompanyName(inDupCompanyID, 0).Trim()}?", "Company Find", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

				if (intPress == System.Windows.Forms.DialogResult.Yes)
				{

					strUpdate1 = $"UPDATE Company SET comp_fractowr_id = 0 WHERE (comp_id = {inCompanyId.ToString()}) AND (comp_fractowr_id IS NULL) ";
					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = strUpdate1;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();

					strUpdate1 = $"UPDATE Company SET comp_fractowr_contact_id = 0 WHERE (comp_id = {inCompanyId.ToString()}) AND (comp_fractowr_contact_id IS NULL) ";
					DbCommand TempCommand_2 = null;
					TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
					TempCommand_2.CommandText = strUpdate1;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand_2.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
					TempCommand_2.ExecuteNonQuery();

					strUpdate1 = $"UPDATE Company SET comp_fractowr_id = 0 WHERE (comp_id = {inDupCompanyID.ToString()}) AND (comp_fractowr_id IS NULL) ";
					DbCommand TempCommand_3 = null;
					TempCommand_3 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_3);
					TempCommand_3.CommandText = strUpdate1;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand_3.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_3);
					TempCommand_3.ExecuteNonQuery();

					strUpdate1 = $"UPDATE Company SET comp_fractowr_contact_id = 0 WHERE (comp_id = {inDupCompanyID.ToString()}) AND (comp_fractowr_contact_id IS NULL) ";
					DbCommand TempCommand_4 = null;
					TempCommand_4 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_4);
					TempCommand_4.CommandText = strUpdate1;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand_4.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_4);
					TempCommand_4.ExecuteNonQuery();


					// --------------------------------------------------
					bContinue = true;

					if (bContinue)
					{

						Query1 = $"SELECT sub_id FROM subscription WITH(NOLOCK) WHERE (sub_comp_id = {inDupCompanyID.ToString()}) ";

						if (!modAdminCommon.Exist(Query1))
						{

							pnl_to_show.Visible = false;

							if (isHistorical == CheckState.Unchecked)
							{
								Query1 = $"SELECT comp_id FROM Company WITH(NOLOCK) WHERE comp_journ_id=0 and comp_id = {inDupCompanyID.ToString()}";
								Query2 = $"SELECT comp_id FROM Company WITH(NOLOCK) WHERE comp_journ_id=0 and comp_id = {inCompanyId.ToString()}";
							}
							else
							{
								Query1 = $"SELECT comp_id FROM Company WITH(NOLOCK) WHERE comp_id = {inDupCompanyID.ToString()}";
								Query2 = $"SELECT comp_id FROM Company WITH(NOLOCK) WHERE comp_id = {inCompanyId.ToString()}";
							}

							if (modAdminCommon.Exist(Query1))
							{

								if (modAdminCommon.Exist(Query2))
								{

									strOwnerOld = modCommon.CompanyLocked(inDupCompanyID, inDupCompanyJID);

									if (strOwnerOld == "False")
									{

										strOwnerNew = modCommon.CompanyLocked(inCompanyId, 0);

										if (strOwnerNew == "False")
										{

											modCommon.Combine_Company(inDupCompanyID, inCompanyId);

										}
										else
										{
											MessageBox.Show($"The Main Company Is Locked By '{strOwnerNew}'{Environment.NewLine}{Environment.NewLine}It Must Be Unlocked Before Removal", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
										} // If strOwnerNew = "False" Then

									}
									else
									{
										MessageBox.Show($"The Company To Be Removed Is Locked By '{strOwnerOld}'{Environment.NewLine}{Environment.NewLine}It Must Be Unlocked Before Removal", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
									} // If strOwnerOld = "False" Then

								}
								else
								{
									MessageBox.Show($"The Main Company No Longer Exists{Environment.NewLine}{Environment.NewLine}It May Have Already Been Removed", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
								} // If Exist(Query2) = True Then

							}
							else
							{
								MessageBox.Show($"The Company To Be Removed No Longer Exists{Environment.NewLine}{Environment.NewLine}It May Have Already Been Removed", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
							} // If Exist(Query1) = True Then

						}
						else
						{
							MessageBox.Show($"The Company To Be Removed Has Subscriptions{Environment.NewLine}{Environment.NewLine}They Must Be Moved Over To The Main Company{Environment.NewLine}{Environment.NewLine}Before It Can Be Removed", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						} // If Exist(Query1) = False Then

					} // If bContinue = True Then

				} // If intPress = vbYes Then
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Remove_Duplicate_Error: {Information.Err().Number.ToString()} {excep.Message}");
			}

		}

		internal static void Fill_Potential_Duplicate_List(int nMatchChars, CheckState bMatchCity, int nCompany_ID, ListBox lst_to_fill, Panel pnl_to_show, UpgradeHelpers.DataGridViewFlex grd_selected_company, bool bIsContactSearch)
		{

			string Query = "";
			string cline = "";
			string tmpCompName = "";
			string tmpCompCity = "";
			ADORecordSetHelper snp_Duplicates = new ADORecordSetHelper();

			try
			{

				if (nCompany_ID == 0)
				{
					return;
				}

				grd_selected_company.CurrentColumnIndex = 0;

				if (grd_selected_company[grd_selected_company.CurrentRowIndex, grd_selected_company.CurrentColumnIndex].FormattedValue.ToString() != "")
				{
					tmpCompName = grd_selected_company[grd_selected_company.CurrentRowIndex, grd_selected_company.CurrentColumnIndex].FormattedValue.ToString().Substring(0, Math.Min(grd_selected_company[grd_selected_company.CurrentRowIndex, grd_selected_company.CurrentColumnIndex].FormattedValue.ToString().IndexOf('['), grd_selected_company[grd_selected_company.CurrentRowIndex, grd_selected_company.CurrentColumnIndex].FormattedValue.ToString().Length)).Trim();
				}
				else
				{
					tmpCompName = modCommon.GetCompanyName(nCompany_ID, 0);
				}

				grd_selected_company.CurrentColumnIndex = 1;

				if (grd_selected_company[grd_selected_company.CurrentRowIndex, grd_selected_company.CurrentColumnIndex].FormattedValue.ToString() != "")
				{
					tmpCompCity = grd_selected_company[grd_selected_company.CurrentRowIndex, grd_selected_company.CurrentColumnIndex].FormattedValue.ToString().Trim();
				}
				else
				{
					tmpCompCity = modCommon.GetCompanyCity(nCompany_ID, 0);
				}

				lst_to_fill.Items.Clear();

				Query = "SELECT * from Company WITH(NOLOCK)";

				if (bIsContactSearch)
				{
					Query = $"{Query} WHERE comp_journ_id >= 0";
				}
				else
				{
					Query = $"{Query} WHERE comp_journ_id = 0";
				}

				if (nMatchChars > 0)
				{
					Query = $"{Query} AND comp_name like '{modAdminCommon.Fix_Quote(($"{tmpCompName} ").Trim().Substring(Math.Min(0, ($"{tmpCompName} ").Trim().Length), Math.Min(nMatchChars, Math.Max(0, ($"{tmpCompName} ").Trim().Length))))}%'";
				}
				else
				{
					Query = $"{Query} AND comp_name = '{modAdminCommon.Fix_Quote(tmpCompName.Trim())}'";
				}

				Query = $"{Query} AND comp_id <> {nCompany_ID.ToString()}";

				if (bMatchCity == CheckState.Checked)
				{
					Query = $"{Query} AND comp_city = '{tmpCompCity.Trim()}'";
				}

				Query = $"{Query} ORDER by comp_name,comp_city,comp_state";

				snp_Duplicates.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_Duplicates.BOF && snp_Duplicates.EOF))
				{

					lst_to_fill.AddItem(" ** SELECT POTENTIAL DUPLICATE TO REMOVE ** ");


					while(!snp_Duplicates.EOF)
					{

						cline = $"{($"{Convert.ToString(snp_Duplicates["comp_name"])} ").Trim()} ";

						if (Strings.Len(($"{Convert.ToString(snp_Duplicates["comp_address1"])}").Trim()) > 0)
						{
							cline = $"{cline}{($"{Convert.ToString(snp_Duplicates["comp_address1"])}").Trim()} ";
						}

						if (Strings.Len(Convert.ToString(snp_Duplicates["Comp_city"]).Trim()) > 0)
						{
							cline = $"{cline}{($"{Convert.ToString(snp_Duplicates["Comp_city"])} ").Trim()},";
						}
						else
						{
							cline = $"{cline} ";
						}

						if (Strings.Len(Convert.ToString(snp_Duplicates["comp_state"]).Trim()) > 0)
						{
							cline = $"{cline}{($"{Convert.ToString(snp_Duplicates["comp_state"])} ").Trim()}";
						}
						else
						{
							cline = $"{cline} ";
						}

						cline = $"{cline} id=({Conversion.Str(snp_Duplicates["comp_id"]).Trim()})"; //aey 5/19/04
						cline = $"{cline} jid=({Conversion.Str(snp_Duplicates["comp_journ_id"]).Trim()})"; //aey 1/3/06

						lst_to_fill.AddItem(cline);
						snp_Duplicates.MoveNext();
					};
				}
				else
				{
					lst_to_fill.AddItem(" ** NO POTENTIAL DUPLICATES FOUND ** ");
				}

				if (lst_to_fill.Items.Count > 0)
				{
					ListBoxHelper.SetSelectedIndex(lst_to_fill, 0);
					pnl_to_show.Visible = true;
				}

				return;

				snp_Duplicates.Close();
				snp_Duplicates = null;
			}
			catch
			{
			}


			snp_Duplicates = null;
			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
			modAdminCommon.Report_Error($"Fill_Potential_Duplicate_List_Error: {Information.Err().Description} {Information.Err().Number.ToString()}");

		}

		internal static void Run_Remove_Duplicate_Phone_Numbers(int in_company_id = 0)
		{

			string errString = "";
			try
			{
				string Query = "";
				ADORecordSetHelper snpDupComp_List = new ADORecordSetHelper();

				Cursor.Current = Cursors.WaitCursor;
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Selecting Duplicate Phone Numbers...", Color.Blue);

				//UPGRADE_WARNING: (2080) IsEmpty was upgraded to a comparison and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
				//UPGRADE_WARNING: (2065) Boolean method Information.IsMissing has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
				if (in_company_id != 0 && !in_company_id.Equals(0))
				{
					if (in_company_id > 0)
					{

						errString = $"TESTING FOR DUPLICATE PHONE NUMBERS, Co_id:{Conversion.Val($"{in_company_id.ToString()}").ToString()}";

						Query = $"EXEC HomebaseRemoveDuplicatePhoneNumbersonCompany {Conversion.Val($"{in_company_id.ToString()}").ToString()}";
						DbCommand TempCommand = null;
						TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
						TempCommand.CommandText = Query;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
						TempCommand.ExecuteNonQuery();

					}
				}
				else
				{

					Query = "SELECT distinct pnum_comp_id,pnum_contact_id  FROM View_Duplicate_Phone_Numbers ";
					Query = $"{Query}ORDER BY pnum_comp_id ";

					snpDupComp_List.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!(snpDupComp_List.BOF && snpDupComp_List.EOF))
					{

						while(!snpDupComp_List.EOF)
						{

							modStatusBar.Update_Status_Bar(modAdminCommon.SB, $"Removing Phone Numbers for Company [{Convert.ToString(snpDupComp_List["pnum_comp_id"])} - {Convert.ToString(snpDupComp_List["pnum_contact_id"])}] ...", Color.Blue);

							errString = "REMOVING DUPLICATE PHONE NUMBERS";

							modCommon.Remove_Duplicate_Phone_Numbers(Convert.ToInt32(snpDupComp_List["pnum_comp_id"]), Convert.ToInt32(snpDupComp_List["pnum_contact_id"]));

							snpDupComp_List.MoveNext();

						};
					}

					snpDupComp_List.Close();
					snpDupComp_List = null;

				}

				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Duplicate Phone Number Removal Complete.", Color.Blue);
				Cursor.Current = CursorHelper.CursorDefault;
			}
			catch (System.Exception excep)
			{

				Cursor.Current = CursorHelper.CursorDefault;
				modAdminCommon.Report_Error($"Run_Remove_Duplicate_Phone_Numbers_Error: {errString} {excep.Message}");
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
			}

		}

		internal static string Select_Contact_Type(ComboBox cbo_selected_contact_type, modGlobalVars.e_find_form_entry_points tIn_entry_point)
		{

			string result = "";

			try
			{

				if (cbo_selected_contact_type.SelectedIndex < 0 && cbo_selected_contact_type.Text == "")
				{

					return result;

				}
				else
				{
					// find the contact type for the cbo_select_contact_type
					int tempForEndVar = modGlobalVars.ContactType_Array.GetUpperBound(0);
					for (int a_row = modGlobalVars.ContactType_Array.GetLowerBound(0); a_row <= tempForEndVar; a_row++)
					{

						// grab the right contact type based on entry point

						switch(modCommon.pubf_EncodeEntryPoints(tIn_entry_point))
						{
							case modGlobalVars.gFIND_EXBK : 
								if (cbo_selected_contact_type.GetItemData(cbo_selected_contact_type.SelectedIndex) == Convert.ToInt32(Double.Parse(modGlobalVars.ContactType_Array[a_row, modGlobalVars.AIRCONT_INDEX])))
								{
									result = modGlobalVars.ContactType_Array[a_row, modGlobalVars.AIRCONT_TYPE];
									goto exit_for;
								} 
								 
								break;
							case modGlobalVars.gFIND_ACCA : 
								 
								if (modGlobalVars.ContactType_Array[a_row, modGlobalVars.AIRCONT_USE].ToLower() == ("R").ToLower())
								{
									if (cbo_selected_contact_type.GetItemData(cbo_selected_contact_type.SelectedIndex) == Convert.ToInt32(Double.Parse(modGlobalVars.ContactType_Array[a_row, modGlobalVars.AIRCONT_INDEX])))
									{
										result = modGlobalVars.ContactType_Array[a_row, modGlobalVars.AIRCONT_TYPE];
										goto exit_for;
									}
								} 
								 
								break;
							case modGlobalVars.gFIND_ACOR : 
								 
								if (modGlobalVars.ContactType_Array[a_row, modGlobalVars.AIRCONT_COMP].ToLower() == ("Y").ToLower())
								{
									if (cbo_selected_contact_type.GetItemData(cbo_selected_contact_type.SelectedIndex) == Convert.ToInt32(Double.Parse(modGlobalVars.ContactType_Array[a_row, modGlobalVars.AIRCONT_INDEX])))
									{
										result = modGlobalVars.ContactType_Array[a_row, modGlobalVars.AIRCONT_TYPE];
										goto exit_for;
									}
								} 
								 
								break;
							case modGlobalVars.gFIND_ASHR : 
								 
								if (modGlobalVars.ContactType_Array[a_row, modGlobalVars.AIRCONT_SHARE].ToLower() == ("Y").ToLower())
								{
									if (cbo_selected_contact_type.GetItemData(cbo_selected_contact_type.SelectedIndex) == Convert.ToInt32(Double.Parse(modGlobalVars.ContactType_Array[a_row, modGlobalVars.AIRCONT_INDEX])))
									{
										result = modGlobalVars.ContactType_Array[a_row, modGlobalVars.AIRCONT_TYPE];
										goto exit_for;
									}
								} 
								 
								break;
						}

					}
					exit_for:;

				}
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Select_Contact_Type_Error: {excep.Message} {Information.Err().Number.ToString()}");
			}

			return result;
		}

		internal static string Get_ItemFrom_Contact_Type_Array(string sIn_Contact_Type, modGlobalVars.e_find_form_entry_points tIn_entry_point, int nIndexItem)
		{


			string result = "";

			try
			{

				if (modGlobalVars.bContactType_IsLoaded)
				{

					// return the item that matches search name
					int tempForEndVar = modGlobalVars.ContactType_Array.GetUpperBound(0);
					for (int a_row = modGlobalVars.ContactType_Array.GetLowerBound(0); a_row <= tempForEndVar; a_row++)
					{

						// grab the right contact type based on entry point

						switch(modCommon.pubf_EncodeEntryPoints(tIn_entry_point))
						{
							case modGlobalVars.gFIND_ACCA : 
								break;
							case modGlobalVars.gFIND_EXBK : case modGlobalVars.gFIND_ACOR : case modGlobalVars.gFIND_ASHR : 
								 
								if (modGlobalVars.ContactType_Array[a_row, modGlobalVars.AIRCONT_TYPE].ToLower() == sIn_Contact_Type.Trim().ToLower())
								{
									result = modGlobalVars.ContactType_Array[a_row, nIndexItem];
									goto exit_for;
								} 
								 
								break;
						}

					}
					exit_for:;

				}
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Get_ItemFrom_Contact_Type_Array_Error: {excep.Message} {Information.Err().Number.ToString()}");
			}

			return result;
		}

		internal static int Create_Awaiting_Documentation_Company(int inCompany_ID, int inJournal_ID, string inCountry, string inState)
		{

			int result = 0;
			string Query = "";
			int New_Company_ID = 0;
			ADORecordSetHelper snpMaxComp = null;
			string AD_Business_Type = "";

			try
			{

				result = 0;

				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Getting Next Company ID for Awaiting Documentation Company ...", Color.Blue);
				if (inCompany_ID == 0)
				{ // we must calculate the next company id
					New_Company_ID = 0;
					Query = "SELECT max(comp_id) as MaxCompID FROM Company WITH(NOLOCK)";
					snpMaxComp = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snpMaxComp["MaxCompID"]))
					{
						New_Company_ID = Convert.ToInt32(snpMaxComp["MaxCompID"]) + 1;
						snpMaxComp.Close();
					}
					snpMaxComp = null;
				}
				else
				{
					// USE THE COMPANY ID THAT WAS PASSED IN
					New_Company_ID = inCompany_ID;
				} // IF NO COMPANY ID

				if (New_Company_ID == 0)
				{
					return result;
				}

				// Create new 'Awaiting Documentation' Company Record
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Saving New Awaiting Documentation Company Record ...", Color.Blue);

				Query = "INSERT INTO Company (comp_id, comp_journ_id, comp_name, comp_name_search, comp_state, comp_country, comp_awaitdoc_flag, ";
				Query = $"{Query}comp_assign_flag, comp_account_id, comp_business_type, comp_account_type, comp_ent_user_id, ";
				Query = $"{Query}comp_ent_date, comp_active_flag, comp_action_date, comp_product_business_flag) VALUES (";
				Query = $"{Query}{New_Company_ID.ToString()}";
				Query = $"{Query}, 0, 'Awaiting Documentation', 'AWAITINGDOCUMENTATION'";

				if (inState.Trim() != modGlobalVars.cEmptyString)
				{
					Query = $"{Query}, '{inState.Trim().Substring(0, Math.Min(inState.IndexOf(", "), inState.Trim().Length))}'";
				}
				else
				{
					Query = $"{Query},NULL";
				}

				if (inCountry.Trim() != modGlobalVars.cEmptyString)
				{
					Query = $"{Query}, '{inCountry.Trim()}'";
				}
				else
				{
					Query = $"{Query},NULL";
				}

				//changed from ID01 to ID03  - MSW - 10/30/18
				Query = $"{Query},'Y','M','ID03','EU','UI','{modAdminCommon.gbl_User_ID}','{DateTime.Now.ToString()}','Y',NULL,'Y')"; // default to business
				//comp_product_business_flag mjm 1/30/09

				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery(); //aey 7/16/04 converted to ado

				if (inJournal_ID > 0)
				{
					Query = "INSERT INTO Company (comp_id, comp_journ_id, comp_name, comp_name_search, comp_state, comp_country, comp_awaitdoc_flag, ";
					Query = $"{Query}comp_assign_flag, comp_account_id, comp_business_type, comp_account_type, comp_ent_user_id, ";
					Query = $"{Query}comp_ent_date, comp_active_flag, comp_action_date, comp_product_business_flag) VALUES (";
					Query = $"{Query}{New_Company_ID.ToString()}, {inJournal_ID.ToString()}";
					Query = $"{Query}, 'Awaiting Documentation', 'AWAITINGDOCUMENTATION'";

					if (inState.Trim() != modGlobalVars.cEmptyString)
					{
						Query = $"{Query}, '{inState.Trim().Substring(0, Math.Min(inState.IndexOf(", "), inState.Trim().Length))}'";
					}
					else
					{
						Query = $"{Query},NULL";
					}

					if (inCountry.Trim() != modGlobalVars.cEmptyString)
					{
						Query = $"{Query}, '{inCountry.Trim()}'";
					}
					else
					{
						Query = $"{Query},NULL";
					}

					Query = $"{Query},'Y','M','ID03','EU','UI','{modAdminCommon.gbl_User_ID}','{DateTime.Now.ToString()}','Y',NULL,'Y')"; // default to business
					//comp_product_business_flag mjm 1/30/09

					DbCommand TempCommand_2 = null;
					TempCommand_2 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
					TempCommand_2.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand_2.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
					TempCommand_2.ExecuteNonQuery(); //aey 7/16/04 converted to ado

				}

				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Saving Awaiting Documentation Business Type ...", Color.Blue);

				Query = "INSERT INTO Business_Type_Reference (bustypref_comp_id, bustypref_journ_id, bustypref_type, bustypref_seq_no)";
				Query = $"{Query} VALUES ({New_Company_ID.ToString()},0,'EU',1)";

				DbCommand TempCommand_3 = null;
				TempCommand_3 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_3);
				TempCommand_3.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand_3.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_3);
				TempCommand_3.ExecuteNonQuery();

				// INSERT HISTORICAL BUSINESS TYPE RECORD IF REQUIRED
				if (inJournal_ID > 0)
				{
					Query = "INSERT INTO Business_Type_Reference (bustypref_comp_id, bustypref_journ_id, bustypref_type, bustypref_seq_no)";
					Query = $"{Query} VALUES ({New_Company_ID.ToString()},{inJournal_ID.ToString()},'EU',1)";
					DbCommand TempCommand_4 = null;
					TempCommand_4 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_4);
					TempCommand_4.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand_4.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_4);
					TempCommand_4.ExecuteNonQuery();
				}

				modCommon.Company_Stats_Update(New_Company_ID);


				return New_Company_ID;
			}
			catch
			{

				result = 0;
				modAdminCommon.Report_Error($"Create_Awaiting_Documentation_Company_Error: CompId[{New_Company_ID.ToString()}]  JournId[{inJournal_ID.ToString()}] ");
				return result;
			}
		}
	}
}