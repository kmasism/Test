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
	internal partial class frm_Transaction_Documents
		: System.Windows.Forms.Form
	{



		public string Entry_Point = ""; //"Aircraft_Change" or "Aircraft"
		public string Action = ""; //Defines why the 'Contact_Find' form was called, i.e., "Get Seller", etc.

		private int Found_Contact_Id = 0; //Will contain the found Contact ID, put there by the 'frm_Contact_Find' form
		private int Found_Company_Id = 0; //Will contain the found Contact ID, put there by the 'frm_Contact_Find' form

		private modGlobalVars.e_find_form_action_types tCompFind_ActionTypes = (modGlobalVars.e_find_form_action_types) 0;
		private modGlobalVars.e_find_form_entry_points tCompFind_EntryPoints = (modGlobalVars.e_find_form_entry_points) 0;

		public int Buyer_Contact_ID = 0; //Buyer_contact_id, put there by the 'frm_Aircraft_Change' form
		public int Buyer_Comp_ID = 0; //Buyer_comp_id, put there by the 'frm_Aircraft_Change' form
		public string Transaction_Date = ""; //txt_transaction_date, put there by the 'frm_Aircraft_Change' form
		public int Journal_ID = 0; //Journal_ID, put there by the 'frm_Aircraft_Change' form
		public string From_Form = ""; // variable set from calling form indicating where the
		public bool IsHistory = false; // Identifies if the current journal entry is a important history transaction
		public string Startup_Document = ""; //identifies starting document aey 7/13/05

		private bool Been_Here = false; //First-Time flag used in 'Form_Activate' routine
		private bool New_Record = false; // Used to identify if we are adding or updating a document
		private string SubCategoryCode = "";
		private string Log_File_Name = ""; // Variable used to store new electronic file to be processed
		private string Current_File_Name = ""; // name of the electronic file that has been installed
		private int model_id = 0;
		private string Airframe_Type_Code = "";
		private bool bDocumentTypesFilled = false;

		private ADORecordSetHelper snp_Document_Type = null; //converted to ado 89/05 aey Snapshot
		private string Aircraft_Serial_Number = "";
		private string[] arr_Transmit_Fields = null;
		private int In_Favor_of_comp_id = 0;
		private int In_Favor_of_contact_id = 0;
		private int On_Behalf_of_comp_id = 0;
		private int On_Behalf_of_contact_id = 0;
		private int Trustee_comp_id = 0;
		private int Trustee_contact_id = 0;
		private int SubLeased_to_comp_id = 0;
		private int SubLeased_to_contact_id = 0;
		private int Total_Docs = 0;
		ADORecordSetHelper snp_DocLog = null;
		private ADORecordSetHelper snp_SF = null; // converted to ado 8/9/05 aey dao.Recordset

		private int Before_In_Favor_of_comp_id = 0; //aey 8/5/04
		private int Before_On_Behalf_of_comp_id = 0;
		private int Before_Trustee_comp_id = 0;
		private int Before_SubLeased_to_comp_id = 0;
		private bool gbFormLoaded = false;
		public frm_Transaction_Documents()
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



		private void DeleteUnreferencedCompany(int in_CompID)
		{

			string Query = "";
			ADORecordSetHelper ado_FindCompany = new ADORecordSetHelper();

			try
			{

				if (in_CompID > 0)
				{
					Query = $"EXEC HomebaseDoesCompanyHaveAnyReferencesWithJournalId {in_CompID.ToString()},{Journal_ID.ToString()}";
					ado_FindCompany.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);
					if (!(ado_FindCompany.BOF && ado_FindCompany.EOF))
					{
						if (Convert.ToDouble(ado_FindCompany["LinkFound"]) != 1)
						{
							//  remove unreferenced company
							Query = $"EXEC HomebaseDeleteAllCompanyRecordsBasedCompId {in_CompID.ToString()}, {Journal_ID.ToString()}";
							DbCommand TempCommand = null;
							TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
							TempCommand.CommandText = Query;
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
							TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
							TempCommand.ExecuteNonQuery();
						}
					}

					ado_FindCompany.Close();
					ado_FindCompany = null;

				}
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("TransDoc", $"Document Delete Error: {excep.Message} {in_CompID.ToString()},{Journal_ID.ToString()}");
			}

		} // DeleteUnreferencedCompany

		private string GetDocCode(string inDesc)
		{

			string result = "";
			ADORecordSetHelper snpDocCode = new ADORecordSetHelper();

			string Query = $"SELECT doctype_code FROM Document_Type WITH (NOLOCK)  WHERE (doctype_description = '{StringsHelper.Replace(inDesc, "'", "''", 1, -1, CompareMethod.Binary).Trim()}')";

			Query = $"{Query} AND (doctype_contract_doc_view = 'N')";

			snpDocCode.Open(Query, modAdminCommon.ADODB_Trans_conn, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

			if (!(snpDocCode.BOF && snpDocCode.EOF))
			{
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(snpDocCode["doctype_code"]))
				{
					result = Convert.ToString(snpDocCode["doctype_code"]).Trim();
				}
				else
				{
					result = "";
				}
			}
			else
			{
				result = "";
			}

			snpDocCode.Close();

			return result;
		}

		private void cbo_doc_type_SelectedIndexChanged(Object eventSender, EventArgs eventArgs) => Select_Document_Type();


		private void cmd_Attach_Click(Object eventSender, EventArgs eventArgs) => Install_New_Electronic_Document();


		private void cmd_cancel_Click(Object eventSender, EventArgs eventArgs) => Close_the_Form();


		private void cmd_Clear_Filed_By_Click(Object eventSender, EventArgs eventArgs)
		{

			lst_In_Favor_of.Items.Clear();
			lst_In_Favor_of.BackColor = Color.White;

			In_Favor_of_comp_id = 0; //aey 8/5/04

			lst_In_Favor_of.Visible = false;

		}

		private void cmd_Clear_On_Behalf_of_Click(Object eventSender, EventArgs eventArgs)
		{

			lst_On_Behalf_of.Items.Clear();
			lst_On_Behalf_of.BackColor = Color.White;

			On_Behalf_of_comp_id = 0; //aey 8/5/04

			lst_On_Behalf_of.Visible = false;

		}

		private void cmd_Clear_Trustee_Click(Object eventSender, EventArgs eventArgs)
		{

			lst_Trustee.Items.Clear();
			lst_Trustee.BackColor = Color.White;

			Trustee_comp_id = 0; //aey 8/5/04

			lst_Trustee.Visible = false;

		}

		private void cmd_Close_Document_Log_Click(Object eventSender, EventArgs eventArgs) => pnl_Document_Log.Visible = false;


		private void cmd_Identify_Filed_By_Click(Object eventSender, EventArgs eventArgs)
		{

			Found_Contact_Id = -1; //-1 indicates no contact identified
			Action = "Get In Favor of";

			tCompFind_ActionTypes = modGlobalVars.e_find_form_action_types.geInFavorOf;

			if (modGlobalVars.bCallShowAndLoadOnlyOnce)
			{

				//UPGRADE_TODO: (1067) Member Clear_Search_Criteria is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_DOCS].Clear_Search_Criteria(true, true, true);
				//UPGRADE_TODO: (1067) Member EntryPoint is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_DOCS].EntryPoint = modGlobalVars.e_find_form_entry_points.geAircraftDocument;
				//UPGRADE_TODO: (1067) Member ActionTypes is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_DOCS].ActionTypes = tCompFind_ActionTypes;
				//UPGRADE_TODO: (1067) Member Reference_AircraftID is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_DOCS].Reference_AircraftID = modAdminCommon.gbl_Aircraft_ID;
				//UPGRADE_TODO: (1067) Member Show is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_DOCS].Show();
                modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_DOCS].BringToFront(); //gap-note Manual change to fix BringToFront rule failing sometimes
				gbFormLoaded = false;

			}

		} // cmd_Identify_Filed_By_Click

		private void cmd_Identify_On_Behalf_of_Click(Object eventSender, EventArgs eventArgs)
		{
			Found_Contact_Id = -1; //-1 indicates no contact identified
			Action = "Get On Behalf of";

			tCompFind_ActionTypes = modGlobalVars.e_find_form_action_types.geOnBehalfOf;

			if (modGlobalVars.bCallShowAndLoadOnlyOnce)
			{

				//UPGRADE_TODO: (1067) Member Clear_Search_Criteria is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_DOCS].Clear_Search_Criteria(true, true, true);
				//UPGRADE_TODO: (1067) Member EntryPoint is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_DOCS].EntryPoint = modGlobalVars.e_find_form_entry_points.geAircraftDocument;
				//UPGRADE_TODO: (1067) Member ActionTypes is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_DOCS].ActionTypes = tCompFind_ActionTypes;
				//UPGRADE_TODO: (1067) Member Reference_AircraftID is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_DOCS].Reference_AircraftID = modAdminCommon.gbl_Aircraft_ID;
				//UPGRADE_TODO: (1067) Member Show is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_DOCS].Show();
                modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_DOCS].BringToFront(); //gap-note Manual change to fix BringToFront rule failing sometimes
				gbFormLoaded = false;

			}

		} // cmd_Identify_On_Behalf_of_Click

		private void cmd_OK_Click(Object eventSender, EventArgs eventArgs)
		{

			string M = "";
			string CompIDs = "";
			string Separator = "";
			string Query = "";
			int Trans_Comp_ID = 0;
			string strError = "";
			int K = 0;
			string tmpList = "";

			try
			{

				//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				// The user has requested us to save the screen contents to the Database
				strError = "init";
				Separator = "";
				CompIDs = "";
				Trans_Comp_ID = 0;
				if (In_Favor_of_comp_id > 0)
				{
					if (!Check_Company_History(In_Favor_of_comp_id, Journal_ID))
					{
						CompIDs = $"{CompIDs}{Separator}{In_Favor_of_comp_id.ToString()}";
						Separator = ",";
						Trans_Comp_ID = In_Favor_of_comp_id;
					}
				}
				if (On_Behalf_of_comp_id > 0)
				{
					if (!Check_Company_History(On_Behalf_of_comp_id, Journal_ID))
					{
						CompIDs = $"{CompIDs}{Separator}{On_Behalf_of_comp_id.ToString()}";
						Separator = ",";
						Trans_Comp_ID = On_Behalf_of_comp_id;
					}
				}
				if (Trustee_comp_id > 0)
				{
					if (!Check_Company_History(Trustee_comp_id, Journal_ID))
					{
						CompIDs = $"{CompIDs}{Separator}{Trustee_comp_id.ToString()}";
						Separator = ",";
						Trans_Comp_ID = Trustee_comp_id;
					}
				}
				if (SubLeased_to_comp_id > 0)
				{
					if (!Check_Company_History(SubLeased_to_comp_id, Journal_ID))
					{
						CompIDs = $"{CompIDs}{Separator}{SubLeased_to_comp_id.ToString()}";
						Separator = ",";
						Trans_Comp_ID = SubLeased_to_comp_id;
					}
				}

				strError = "IF";
				if (CompIDs != "")
				{
					strError = "get comp Hist";
					modCommon.Transaction_Get_Company_History_Recordsets(CompIDs);

					tmpList = $"{CompIDs},";
					while (Strings.Len($"{tmpList}") > 0)
					{
						K = (tmpList.IndexOf(',') + 1);

						Trans_Comp_ID = Convert.ToInt32(Conversion.Val(tmpList.Substring(Math.Min(0, tmpList.Length), Math.Min(K - 1, Math.Max(0, tmpList.Length)))));
						tmpList = tmpList.Substring(Math.Min(K, tmpList.Length)).Trim();

						if (Trans_Comp_ID > 0)
						{
							//update stats
							strError = "stats";

							// RTW - 6/27/06 - INTEGRATED NEW ASYNC COMPANY STATS UPDATE
							modCommon.Company_Stats_Update(Trans_Comp_ID);

							Select_Account_Rep(Trans_Comp_ID);

						}

					}

				}

				strError = "trans";
				modAdminCommon.ADO_Transaction("BeginTrans");
				if (Save_Aircraft_Document(CompIDs))
				{
					modAdminCommon.ADO_Transaction("CommitTrans");

					if ((In_Favor_of_comp_id != Before_In_Favor_of_comp_id) && Before_In_Favor_of_comp_id > 0)
					{
						DeleteUnreferencedCompany(Before_In_Favor_of_comp_id);
					}

					if ((SubLeased_to_comp_id != Before_SubLeased_to_comp_id) && Before_SubLeased_to_comp_id > 0)
					{
						DeleteUnreferencedCompany(Before_SubLeased_to_comp_id);
					}

					if ((Trustee_comp_id != Before_Trustee_comp_id) && Before_Trustee_comp_id > 0)
					{
						DeleteUnreferencedCompany(Before_Trustee_comp_id);
					}

					if ((On_Behalf_of_comp_id != Before_On_Behalf_of_comp_id) && Before_On_Behalf_of_comp_id > 0)
					{
						DeleteUnreferencedCompany(Before_On_Behalf_of_comp_id);
					}
					strError = "get docs";

					Get_Aircraft_Documents();
					M = "Aircraft Document Saved!";
					MessageBox.Show(M, "SOLD FINANCIAL COMPLETED", MessageBoxButtons.OK, MessageBoxIcon.Information);
					this.Cursor = CursorHelper.CursorDefault;
				}
				else
				{
					modAdminCommon.ADO_Transaction("RollbackTrans");
					M = "Sold Financial Data update Aborted!";
					MessageBox.Show(M, "SOLD FINANCIAL ABORTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
					this.Cursor = CursorHelper.CursorDefault;
				}

				//CLIENT_ADO_DB.Close
				strError = "close";
				modAdminCommon.CLIENT_ADO_DB = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Transdoc", $"Save_Document_Error: {excep.Message}, Journ_id: {Journal_ID.ToString()} {strError}");

				modAdminCommon.CLIENT_ADO_DB = null;
				return;
			}

		}

		private void Select_Account_Rep(int in_CompID)
		{

			string Query = "";
			string AcctRep = "";
			string AcctType = "";
			string CompName = "";
			string AssignChar = "";

			try
			{

				//get current rep, if any
				AcctRep = $"{modCommon.DLookUp("comp_account_id", "Company", $"Comp_journ_id=0 and comp_id={in_CompID.ToString()}")}";

				if (Strings.Len(AcctRep.Trim()) == 0)
				{ //get company name if no rep
					CompName = ($"{modCommon.DLookUp("comp_name", "Company", $"Comp_journ_id=0 and comp_id={in_CompID.ToString()}")}").Trim();
					AssignChar = $"{CompName.Substring(0, Math.Min(1, CompName.Length))}"; //get first character

					if (Strings.Len(AssignChar.Trim()) > 0)
					{ //get account type
						AcctType = ($"{modCommon.DLookUp("comp_account_type", "Company", $"Comp_journ_id=0 and comp_id={in_CompID.ToString()}")}").Trim();

						if (AcctType == "DB")
						{ //lookup rep
							AcctRep = ($"{modCommon.DLookUp("assign_db_account_id", "Account_Rep_Assignment", $"assign_character='{AssignChar}' ")}").Trim();
						}
						else
						{
							AcctRep = ($"{modCommon.DLookUp("assign_eu_account_id", "Account_Rep_Assignment", $"assign_character='{AssignChar}' ")}").Trim();
						}

						if (Strings.Len($"{AcctRep}") > 0)
						{ //update company
							Query = $"update company set comp_account_id ='{AcctRep}' ";
							DbCommand TempCommand = null;
							TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
							TempCommand.CommandText = Query;
							TempCommand.CommandType = CommandType.Text;
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
							TempCommand.ExecuteNonQuery();
						}
					}
				}
			}
			catch (System.Exception excep)
			{
				modAdminCommon.Report_Error($"Select_Account_Rep_Error:: {excep.Message} , Comp_id:{in_CompID.ToString()}");
			}

		}

		private void cmd_Trustee_Click(Object eventSender, EventArgs eventArgs)
		{
			Found_Contact_Id = -1; //-1 indicates no contact identified
			Action = "Get Trustee";

			tCompFind_ActionTypes = modGlobalVars.e_find_form_action_types.geTrustee;

			if (modGlobalVars.bCallShowAndLoadOnlyOnce)
			{

				//UPGRADE_TODO: (1067) Member Clear_Search_Criteria is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_DOCS].Clear_Search_Criteria(true, true, true);
				//UPGRADE_TODO: (1067) Member EntryPoint is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_DOCS].EntryPoint = modGlobalVars.e_find_form_entry_points.geAircraftDocument;
				//UPGRADE_TODO: (1067) Member ActionTypes is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_DOCS].ActionTypes = tCompFind_ActionTypes;
				//UPGRADE_TODO: (1067) Member Reference_AircraftID is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_DOCS].Reference_AircraftID = modAdminCommon.gbl_Aircraft_ID;
				//UPGRADE_TODO: (1067) Member Show is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_DOCS].Show();
                modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_DOCS].BringToFront(); //gap-note Manual change to fix BringToFront rule failing sometimes
				gbFormLoaded = false;

			}

		}


		private void cmdTransOpenDocument_Click(Object eventSender, EventArgs eventArgs)
		{

			string strPDFFile = "";

			if (cmdTransOpenDocument.Enabled)
			{

				cmdTransOpenDocument.Enabled = false;

				strPDFFile = Current_File_Name;

				modCommon.ShellOpenURLInBrowser(modAdminCommon.gbl_User_Browser, strPDFFile);

				cmdTransOpenDocument.Enabled = true;

			} // If cmdTransOpenDocument.Enabled = True Then

		} // cmdTransOpenDocument_Click

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
		private void Form_Load()
		{

			gbFormLoaded = false;

			Fill_Document_Types();

			tCompFind_ActionTypes = modGlobalVars.e_find_form_action_types.geNoAction;

		}

		private void Form_Activated(Object eventSender, EventArgs eventArgs)
		{
			if (ActivateHelper.myActiveForm != eventSender)
			{
				ActivateHelper.myActiveForm = (Form) eventSender;

				string Query = "";

				try
				{

					if (!gbFormLoaded)
					{
						ToolbarSetup();
						ToolbarButtonsSetup();

						pnl_Document_Log.Visible = false;
						if (Been_Here)
						{

							//UPGRADE_TODO: (1067) Member EntryPoint is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
							//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
							tCompFind_EntryPoints = (modGlobalVars.e_find_form_entry_points) Convert.ToInt32(modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_DOCS].EntryPoint);

							if (modCommon.pubf_EncodeEntryPoints(tCompFind_EntryPoints) == modGlobalVars.gFIND_ADOC)
							{
								//UPGRADE_TODO: (1067) Member ActionTypes is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
								tCompFind_ActionTypes = (modGlobalVars.e_find_form_action_types) Convert.ToInt32(modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_DOCS].ActionTypes);
								//UPGRADE_TODO: (1067) Member GetFormExitValues is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Found_Company_Id = Convert.ToInt32(modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_DOCS].GetFormExitValues(modGlobalVars.gcFOUNDCOMPANYID));
								//UPGRADE_TODO: (1067) Member GetFormExitValues is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Found_Contact_Id = Convert.ToInt32(modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_DOCS].GetFormExitValues(modGlobalVars.gcFOUNDCONTACTID));
							}

							if (tCompFind_ActionTypes == modGlobalVars.e_find_form_action_types.geInFavorOf && Found_Company_Id != 0)
							{

								In_Favor_of_comp_id = Found_Company_Id;
								In_Favor_of_contact_id = Found_Contact_Id;
								Display_Document_Company(lst_In_Favor_of, In_Favor_of_contact_id, In_Favor_of_comp_id, 0);

							}
							else if ((tCompFind_ActionTypes == modGlobalVars.e_find_form_action_types.geOnBehalfOf && Found_Company_Id != 0))
							{ 
								//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

								On_Behalf_of_comp_id = Found_Company_Id;
								On_Behalf_of_contact_id = Found_Contact_Id;
								Display_Document_Company(lst_On_Behalf_of, On_Behalf_of_contact_id, On_Behalf_of_comp_id, 0);

							}
							else if ((tCompFind_ActionTypes == modGlobalVars.e_find_form_action_types.geTrustee && Found_Company_Id != 0))
							{ 

								Trustee_comp_id = Found_Company_Id;
								Trustee_contact_id = Found_Contact_Id;
								Display_Document_Company(lst_Trustee, Trustee_contact_id, Trustee_comp_id, 0);

							}
							else if ((tCompFind_ActionTypes == modGlobalVars.e_find_form_action_types.geSubLeasedTo && Found_Company_Id != 0))
							{ 

								SubLeased_to_comp_id = Found_Company_Id;
								SubLeased_to_contact_id = Found_Contact_Id;

							}

						}
						else
						{
							// Pulling up a sold financial for update
							Been_Here = true;
							Total_Docs = 0;

							modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Retrieving Aircraft and Company Information, Please wait.", Color.Blue);
							Get_Aircraft();
							Setup_Form();
							Get_Journal_Subject();

							Query = $"SELECT * FROM Aircraft_Document WHERE adoc_ac_id = {modAdminCommon.gbl_Aircraft_ID.ToString()} AND adoc_journ_id = {Journal_ID.ToString()}";

							if (modAdminCommon.Exist(Query))
							{
								Get_Aircraft_Documents();
								New_Record = false;
							}
							else
							{
								pnl_FinancialDocList.Visible = false;

								Setup_New_Aircraft_Document();

							}

							modStatusBar.Clear_Status_Bar(modAdminCommon.SB);

						}

						this.Activate();

						tbr_ToolBar.Refresh();

						this.Cursor = CursorHelper.CursorDefault;

						gbFormLoaded = true;

					} // If gbFormLoaded = False Then

					return;
				}
				catch (System.Exception excep)
				{

					modAdminCommon.Report_Error($"Form_Activate_Error: {excep.Message} {Query}");
				}
			}
		} // Form_Activate

		public void Get_Aircraft()
		{

			try
			{

				ADORecordSetHelper snp_A = new ADORecordSetHelper(); //converted to ado 8/9/05 aey
				string Query = "";
				Query = "SELECT ac_forsale_flag, ac_id, ac_status, ac_delivery, ";
				Query = $"{Query}ac_asking, ac_asking_price,  ac_list_date, amod_make_name, amod_model_name, ";
				Query = $"{Query}amod_airframe_type_code, ac_amod_id, ac_ser_no_full ";
				Query = $"{Query}FROM Aircraft WITH(NOLOCK) , Aircraft_Model ";
				Query = $"{Query}WHERE ac_id = {modAdminCommon.gbl_Aircraft_ID.ToString()} AND ac_journ_id = 0 AND amod_id = ac_amod_id";

				snp_A.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_A.BOF && snp_A.EOF))
				{

					lst_Aircraft_Info.Items.Clear();

					Aircraft_Serial_Number = ($"{Convert.ToString(snp_A["ac_ser_no_full"])}").Trim();
					model_id = Convert.ToInt32(Double.Parse(($"{Convert.ToString(snp_A["ac_amod_id"])}").Trim()));
					Airframe_Type_Code = ($"{Convert.ToString(snp_A["amod_airframe_type_code"])}").Trim();

					lst_Aircraft_Info.AddItem($"Make:{($"{Convert.ToString(snp_A["amod_make_name"])}").Trim()} Model:{($"{Convert.ToString(snp_A["amod_model_name"])}").Trim()}");
					lst_Aircraft_Info.AddItem($"Serial#:{($"{Convert.ToString(snp_A["ac_ser_no_full"])}").Trim()}");
					lst_Aircraft_Info.AddItem($"Status: {($"{Convert.ToString(snp_A["ac_status"])}").Trim()}");

					if (($"{Convert.ToString(snp_A["ac_status"])}").Trim().ToLower() == ("For Sale").ToLower())
					{
						lst_Aircraft_Info.AddItem($"Availability: {($"{Convert.ToString(snp_A["ac_delivery"])}").Trim()}");

						if (($"{Convert.ToString(snp_A["ac_asking"])}").Trim().ToLower() == ("Price").ToLower())
						{
							lst_Aircraft_Info.AddItem($"Asking Price: ${modAdminCommon.gbl_LeftAdjust(($"{Convert.ToString(snp_A["ac_asking_price"])}").Trim(), "###,###,###")}");
						}
						else
						{
							lst_Aircraft_Info.AddItem(($"{Convert.ToString(snp_A["ac_asking"])}").Trim());
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snp_A["ac_list_date"]))
						{
							lst_Aircraft_Info.AddItem($"List Date: {DateTime.Parse(Convert.ToString(snp_A["ac_list_date"]).Trim()).ToString("d")}");
						}
						else
						{
							lst_Aircraft_Info.AddItem("List Date: None(Null)");
						}
					}

					lst_Aircraft_Info.SetItemData(0, Convert.ToInt32(snp_A["AC_ID"]));

				}

				snp_A.Close();
				snp_A = null;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Get_Aircraft_Error: {excep.Message} {Information.Err().Number.ToString()}");

				this.Cursor = CursorHelper.CursorDefault;

			}

		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{

			snp_SF = null;
			snp_Document_Type = null;
			modAdminCommon.CLIENT_ADO_DB = null;

		}

		private void grd_DocumentLog_Click(Object eventSender, EventArgs eventArgs)
		{
			string RootPath = "";

			if (grd_DocumentLog.CurrentRowIndex > 0)
			{
				Position_Document_Log();

				if (($"{Convert.ToString(snp_DocLog["faalog_doc_type"])} ").Trim().ToLower() == "nts")
				{
					RootPath = ($"{modCommon.DLookUp("aconfig_ntsb_maindir", "application_configuration")}").Trim();
					modAdminCommon.gbl_Documents = RootPath;
					Log_File_Name = $"{RootPath}\\PROCESSING\\{($"{Convert.ToString(snp_DocLog["faalog_id"])}").Trim()}.html";
				}
				else
				{
					RootPath = ($"{modCommon.DLookUp("aconfig_faapdf_maindir", "application_configuration")}").Trim();
					modAdminCommon.gbl_Documents = RootPath;

					Log_File_Name = $"{RootPath}\\PROCESSING\\{StringsHelper.Format(($"{Convert.ToString(snp_DocLog["faalog_tape_no"])} ").Trim(), "00000")}";
					Log_File_Name = $"{Log_File_Name}-{StringsHelper.Format(($"{Convert.ToString(snp_DocLog["faalog_tape_of"])} ").Trim(), "0")}";
					Log_File_Name = $"{Log_File_Name}of{StringsHelper.Format(($"{Convert.ToString(snp_DocLog["faalog_tape_to"])} ").Trim(), "0")}";
					Log_File_Name = $"{Log_File_Name}-{StringsHelper.Format(($"{Convert.ToString(snp_DocLog["faalog_starting_frame_no"])} ").Trim(), "00000")}";
					Log_File_Name = $"{Log_File_Name}-{StringsHelper.Format(($"{Convert.ToString(snp_DocLog["faalog_ending_frame_no"])} ").Trim(), "00000")}";
					Log_File_Name = $"{Log_File_Name}-{($"{Convert.ToString(snp_DocLog["faalog_doc_type"])} ").Trim().ToLower()}";
					Log_File_Name = $"{Log_File_Name}-{StringsHelper.Format(($"{Convert.ToString(snp_DocLog["faalog_ac_id"])} ").Trim(), "000000")}";
					Log_File_Name = $"{Log_File_Name}.pdf";
				}

				if (Check_for_New_Electronic_Document(Log_File_Name))
				{
					cmd_Attach.Visible = true;
					lbl_Status.Text = "Scanned File Found. Click <Attach> to Load.";
					lbl_Status.Visible = true;
				}
				else
				{
					cmd_Attach.Visible = false;
					lbl_Status.Text = $"Scanned File <{Log_File_Name}> Not Found. Check File Name";
					lbl_Status.Visible = true;
				}

			}

		}

		private void lst_FinancialDoc_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{

			lbl_FinancialDoc_Records.Text = $"Document {(ListBoxHelper.GetSelectedIndex(lst_FinancialDoc) + 1).ToString()} of {lst_FinancialDoc.Items.Count.ToString()}";

			Position_Aircraft_Document();
			Display_Aircraft_Document();

			if (SSTabHelper.GetSelectedIndex(tab_Document) == 1)
			{
				Display_Electronic_Document();
			}

		}

		public void mnuAttachDocument_Click(Object eventSender, EventArgs eventArgs)
		{

			//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.DialogTitle was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			mdi_ResearchAssistant.DefInstance.CommonDialog1Open.Title = "Attach Document";
			//UPGRADE_WARNING: (2074) MSComDlg.CommonDialog property mdi_ResearchAssistant.CommonDialog1.Flags was upgraded to mdi_ResearchAssistant.CommonDialog1Open.ShowReadOnly which has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2074
			//UPGRADE_WARNING: (2074) FileOpenConstants STRING RESOURCE ["IDS-CONSTANT"] NOT FOUND FileOpenConstants.cdlOFNHideReadOnly was upgraded to OpenFileDialog.ShowReadOnly which has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2074
			mdi_ResearchAssistant.DefInstance.CommonDialog1Open.ShowReadOnly = false;
			//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.Filter was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			//UPGRADE_WARNING: (2081) Filter has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
			mdi_ResearchAssistant.DefInstance.CommonDialog1Open.Filter = "PDF Files (*.pdf)|*.pdf|All Files (*.*)|*.*";
			//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.FileName was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			mdi_ResearchAssistant.DefInstance.CommonDialog1Open.FileName = "";
			mdi_ResearchAssistant.DefInstance.CommonDialog1Open.ShowDialog();

			this.Cursor = Cursors.WaitCursor;

			//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.FileName was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			if (mdi_ResearchAssistant.DefInstance.CommonDialog1Open.FileName != "")
			{
				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.FileName was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				if (!modCommon.AttachFile(mdi_ResearchAssistant.DefInstance.CommonDialog1Open.FileName, "Document", 0, Convert.ToInt32(snp_SF["adoc_journ_id"]), Convert.ToInt32(snp_SF["adoc_journ_seq_no"]), lst_Aircraft_Info.GetItemData(0)))
				{
					//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.FileName was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					MessageBox.Show($"AttachFileError: FileName[{mdi_ResearchAssistant.DefInstance.CommonDialog1Open.FileName}]", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}
			}

			Display_Aircraft_Document();

			this.Cursor = CursorHelper.CursorDefault;

		}

		public void mnuEditDelAttachment_Click(Object eventSender, EventArgs eventArgs)
		{
			DialogResult Msg = MessageBox.Show("Are you Sure?", "Remove Attachment", MessageBoxButtons.YesNo);
			if (Msg == System.Windows.Forms.DialogResult.Yes)
			{
				Remove_Aircraft_Document("Attachment");
			}

		}

		public void mnuEditDocDelete_Click(Object eventSender, EventArgs eventArgs)
		{
			DialogResult Msg = MessageBox.Show("Are you Sure?", "Delete Document", MessageBoxButtons.YesNo);
			if (Msg == System.Windows.Forms.DialogResult.Yes)
			{
				Remove_Aircraft_Document("Document");
			}

		}

		public void mnuEditNewDocument_Click(Object eventSender, EventArgs eventArgs) => Setup_New_Aircraft_Document();


		public void mnuFileClose_Click(Object eventSender, EventArgs eventArgs) => Close_the_Form();


		private bool Save_Aircraft_Document(string inCompIDs)
		{

			bool result = false;
			string Query = "";
			ADORecordSetHelper ado_Delete = null;
			ADORecordSetHelper ado_Add = null;
			string EventDesc = "";
			string DocCode = "";
			int tmpSeqNo = 0;
			bool DocUpdate = false;
			int Event_Comp_Id = 0; //8/15/05 aey
			int Event_Contact_Id = 0;
			string errMsg = "";
			string strTemp = "";
			string t1 = "";
			string strDocDate = "";

			try
			{

				result = false;

				strDocDate = ($"{txt_adoc_doc_date.Text} ").Trim();

				if (strDocDate != "")
				{
					if (Information.IsDate(strDocDate))
					{
						if (DateTime.Parse(strDocDate) > DateTime.Now)
						{
							MessageBox.Show("The Date Entered Cannot be Greater Than Today", "Fix Date", MessageBoxButtons.OK);
							return result;
						}
					}
				}

				errMsg = "start";
				DocUpdate = false;
				Event_Comp_Id = 0;
				Event_Contact_Id = 0;

				this.Cursor = Cursors.WaitCursor;
				if (!New_Record)
				{
					errMsg = "not new";
					DocUpdate = true;
					Query = $"SELECT * FROM Aircraft_Document WHERE adoc_ac_id = {modAdminCommon.gbl_Aircraft_ID.ToString()}";
					Query = $"{Query} AND adoc_journ_id = {Journal_ID.ToString()} AND adoc_journ_seq_no = {Convert.ToString(snp_SF["adoc_journ_seq_no"])}";

					ado_Delete = new ADORecordSetHelper();
					ado_Delete.ActiveConnection = modAdminCommon.ADODB_Trans_conn;

					ado_Delete.CursorType = CursorTypeEnum.adOpenDynamic;
					ado_Delete.LockType = UpgradeHelpers.DB.LockTypeEnum.LockOptimistic;
					ado_Delete.CursorLocation = CursorLocationEnum.adUseServer;
					ado_Delete.Open(Query, UpgradeHelpers.DB.LockTypeEnum.LockUnspecified, StringParameterType.Source);

					if (!(ado_Delete.BOF && ado_Delete.EOF))
					{
						ado_Delete.MoveFirst();
						//UPGRADE_ISSUE: (2064) ADODB.CursorOptionEnum property CursorOptionEnum.adDelete was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_ISSUE: (2064) ADODB.Recordset method ado_Delete.Supports was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						if (ado_Delete.Supports(UpgradeStubs.ADODB_CursorOptionEnum.getadDelete()))
						{

							while(!ado_Delete.EOF)
							{
								ado_Delete.Delete();
								ado_Delete.MoveNext();
							};
						}
					}
					if (ado_Delete.State == ConnectionState.Open)
					{
						ado_Delete.Close();
					}
					ado_Delete = null;

				} // IF UPDATING DOCUMENT

				errMsg = "add new";
				ado_Add = new ADORecordSetHelper();
				ado_Add.ActiveConnection = modAdminCommon.ADODB_Trans_conn;
				ado_Add.CursorType = CursorTypeEnum.adOpenDynamic;
				ado_Add.LockType = UpgradeHelpers.DB.LockTypeEnum.LockOptimistic;
				ado_Add.CursorLocation = CursorLocationEnum.adUseServer;
				ado_Add.Open("Aircraft_Document", UpgradeHelpers.DB.LockTypeEnum.LockUnspecified, StringParameterType.Source);

				//UPGRADE_ISSUE: (2064) ADODB.CursorOptionEnum property CursorOptionEnum.adAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method ado_Add.Supports was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				if (ado_Add.Supports(UpgradeStubs.ADODB_CursorOptionEnum.getadAddNew()))
				{

					ado_Add.AddNew();
					ado_Add["adoc_ac_id"] = modAdminCommon.gbl_Aircraft_ID;
					ado_Add["adoc_journ_id"] = Journal_ID;

					//04/28/2008 - By David D. Cruger; re-worked the saving and reading of the amounts, interest..etc for these documents

					if (($"{cbo_doc_type.Text} ").Trim() != "")
					{
						ado_Add["adoc_doc_type"] = ($"{cbo_doc_type.Text} ").Trim();
					}

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					ado_Add["adoc_doc_date"] = DBNull.Value;
					if (($"{txt_adoc_doc_date.Text} ").Trim() != "")
					{
						if (modCommon.pf_ValidateDate(($"{txt_adoc_doc_date.Text} ").Trim(), true))
						{
							ado_Add["adoc_doc_date"] = DateTime.Parse(($"{txt_adoc_doc_date.Text} ").Trim()).ToString("d");
						}
					}

					strTemp = ($"{txt_adoc_doc_amount.Text} ").Trim();
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					ado_Add["adoc_doc_amount"] = DBNull.Value;
					if (Information.IsNumeric(strTemp))
					{
						if (Double.Parse(strTemp) > 0)
						{
							ado_Add["adoc_doc_amount"] = Double.Parse(strTemp);
						}
					} // If IsNumeric(strTemp) = True Then

					strTemp = ($"{txt_adoc_interest_points.Text} ").Trim();
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					ado_Add["adoc_interest_points"] = DBNull.Value;
					if (Information.IsNumeric(strTemp))
					{
						if (Double.Parse(strTemp) > 0)
						{
							ado_Add["adoc_interest_points"] = Double.Parse(strTemp);
						}
					} // If IsNumeric(strTemp) = True Then

					strTemp = ($"{txt_adoc_number_payments.Text} ").Trim();
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					ado_Add["adoc_number_payments"] = DBNull.Value;
					if (Information.IsNumeric(strTemp))
					{
						if (Convert.ToInt32(Double.Parse(strTemp)) > 0)
						{
							ado_Add["adoc_number_payments"] = Convert.ToInt32(Double.Parse(strTemp));
						}
					} // If IsNumeric(strTemp) = True Then

					strTemp = ($"{txt_adoc_payment_amount.Text} ").Trim();
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					ado_Add["adoc_payment_amount"] = DBNull.Value;
					if (Information.IsNumeric(strTemp))
					{
						if (Double.Parse(strTemp) > 0)
						{
							ado_Add["adoc_payment_amount"] = Double.Parse(strTemp);
						}
					} // If IsNumeric(strTemp) = True Then

					strTemp = ($"{txt_adoc_last_payment_amount.Text} ").Trim();
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					ado_Add["adoc_last_payment_amount"] = DBNull.Value;
					if (Information.IsNumeric(strTemp))
					{
						if (Double.Parse(strTemp) > 0)
						{
							ado_Add["adoc_last_payment_amount"] = Double.Parse(strTemp);
						}
					} // If IsNumeric(strTemp) = True Then

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					ado_Add["adoc_last_payment_date"] = DBNull.Value;
					if (($"{txt_adoc_last_payment_date.Text} ").Trim() != "")
					{
						if (modCommon.pf_ValidateDate(($"{txt_adoc_last_payment_date.Text} ").Trim(), true))
						{
							ado_Add["adoc_last_payment_date"] = DateTime.Parse(($"{txt_adoc_last_payment_date.Text} ").Trim()).ToString("d");
						}
					}

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					ado_Add["adoc_trustee_note"] = DBNull.Value;
					if (($"{txt_adoc_trustee_note.Text} ").Trim() != "")
					{
						ado_Add["adoc_trustee_note"] = ($"{txt_adoc_trustee_note.Text} ").Trim();
					}

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					ado_Add["adoc_sublease_note"] = DBNull.Value;
					if (($"{txt_adoc_sublease_note.Text} ").Trim() != "")
					{
						ado_Add["adoc_sublease_note"] = ($"{txt_adoc_sublease_note.Text} ").Trim();
					}

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					ado_Add["adoc_general_note"] = DBNull.Value;
					if (($"{txt_adoc_general_note.Text} ").Trim() != "")
					{
						ado_Add["adoc_general_note"] = ($"{txt_adoc_general_note.Text} ").Trim();
					}

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					ado_Add["adoc_infavor_text"] = DBNull.Value;
					if (($"{txt_In_Favor_of_Notes.Text} ").Trim() != "")
					{
						ado_Add["adoc_infavor_text"] = ($"{txt_In_Favor_of_Notes.Text} ").Trim();
					}

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					ado_Add["adoc_onbehalf_text"] = DBNull.Value;
					if (($"{txt_On_Behalf_of_Notes.Text} ").Trim() != "")
					{
						ado_Add["adoc_onbehalf_text"] = ($"{txt_On_Behalf_of_Notes.Text} ").Trim();
					}

					ado_Add["adoc_hide_flag"] = "N";
					if (chk_adoc_hide_flag.CheckState == CheckState.Checked)
					{
						ado_Add["adoc_hide_flag"] = "Y";
					}

					//**************************************************************************
					// IF WE ARE ADDING A DOCUMENT
					if (New_Record)
					{
						ado_Add["adoc_journ_seq_no"] = Total_Docs + 1;
						tmpSeqNo = Total_Docs + 1;
						ado_Add["adoc_entered_date"] = modAdminCommon.GetDateTime();
					}
					else
					{
						ado_Add["adoc_journ_seq_no"] = snp_SF["adoc_journ_seq_no"];
						tmpSeqNo = Convert.ToInt32(snp_SF["adoc_journ_seq_no"]);
						ado_Add["adoc_update_date"] = modAdminCommon.GetDateTime();
					}

					ado_Add["adoc_user_id"] = modAdminCommon.snp_User["user_id"];
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					ado_Add["adoc_action_date"] = DBNull.Value;

					if (lst_SubLeased_to.Items.Count > 0)
					{
						ado_Add["adoc_sublease_comp_id"] = SubLeased_to_comp_id;
						if (SubLeased_to_contact_id > 0)
						{
							ado_Add["adoc_sublease_contact_id"] = SubLeased_to_contact_id;
						}
					}
					else
					{
						ado_Add["adoc_sublease_comp_id"] = 0;
						ado_Add["adoc_sublease_contact_id"] = 0;
						SubLeased_to_comp_id = 0;
					}

					errMsg = "behalf";
					if (lst_On_Behalf_of.Items.Count > 0)
					{
						ado_Add["adoc_onbehalf_comp_id"] = On_Behalf_of_comp_id;
						if (On_Behalf_of_contact_id > 0)
						{
							ado_Add["adoc_onbehalf_contact_id"] = On_Behalf_of_contact_id;
						}
					}
					else
					{
						ado_Add["adoc_onbehalf_comp_id"] = 0;
						ado_Add["adoc_onbehalf_contact_id"] = 0;
						On_Behalf_of_comp_id = 0;
					}

					if (lst_In_Favor_of.Items.Count > 0)
					{
						ado_Add["adoc_infavor_comp_id"] = In_Favor_of_comp_id;
						if (In_Favor_of_contact_id > 0)
						{
							ado_Add["adoc_infavor_contact_id"] = In_Favor_of_contact_id;
						}
					}
					else
					{
						ado_Add["adoc_infavor_comp_id"] = 0;
						ado_Add["adoc_infavor_contact_id"] = 0;
						In_Favor_of_comp_id = 0;
					}

					if (lst_Trustee.Items.Count > 0)
					{
						ado_Add["adoc_trustee_comp_id"] = Trustee_comp_id;
						if (Trustee_contact_id > 0)
						{
							ado_Add["adoc_trustee_contact_id"] = Trustee_contact_id;
						}
					}
					else
					{
						ado_Add["adoc_trustee_comp_id"] = 0;
						ado_Add["adoc_trustee_contact_id"] = 0;
						Trustee_comp_id = 0;
					}

					ado_Add.Update();

					if (($"{inCompIDs}").Trim() != "")
					{
						modCommon.Transaction_Save_Company_History(Journal_ID, ref modGlobalVars.snp_Company, ref modGlobalVars.snp_Contacts, ref modGlobalVars.snp_Company_Phones, ref modGlobalVars.snp_Company_Btypes, ref modGlobalVars.snp_Company_Certs);
					}

					result = true;

					if (pnl_Trustee.Visible)
					{
						DocCode = GetDocCode(cbo_doc_type.Text.Trim());

						if (("~LSE,~LST,~OLA").IndexOf($"~{DocCode}") >= 0)
						{ //lessee
							Event_Comp_Id = Convert.ToInt32(Conversion.Val($"{modCommon.DLookUp("cref_comp_id", "aircraft_reference", $"cref_contact_type = '12' and cref_ac_id= {modAdminCommon.gbl_Aircraft_ID.ToString()} and cref_journ_id= {Journal_ID.ToString()} ")}"));
							Event_Contact_Id = Convert.ToInt32(Conversion.Val($"{modCommon.DLookUp("cref_contact_id", "aircraft_reference", $"cref_contact_type = '12' and cref_ac_id= {modAdminCommon.gbl_Aircraft_ID.ToString()} and cref_journ_id= {Journal_ID.ToString()} ")}"));
						}
						else if (("~LSA,~EXP").IndexOf($"~{DocCode}") >= 0)
						{  //seller
							Event_Comp_Id = Convert.ToInt32(Conversion.Val($"{modCommon.DLookUp("cref_comp_id", "aircraft_reference", $"cref_contact_type in('69','95') and cref_ac_id={modAdminCommon.gbl_Aircraft_ID.ToString()} and cref_journ_id= {Journal_ID.ToString()} ")}"));
							Event_Contact_Id = Convert.ToInt32(Conversion.Val($"{modCommon.DLookUp("cref_contact_id", "aircraft_reference", $"cref_contact_type in('69','95') and cref_ac_id= {modAdminCommon.gbl_Aircraft_ID.ToString()} and cref_journ_id= {Journal_ID.ToString()} ")}"));
						}
						else
						{
							//all others = purchaser
							Event_Comp_Id = Convert.ToInt32(Conversion.Val($"{modCommon.DLookUp("cref_comp_id", "aircraft_reference", $"cref_contact_type in('70','96') and cref_ac_id= {modAdminCommon.gbl_Aircraft_ID.ToString()} and cref_journ_id= {Journal_ID.ToString()} ")}"));
							Event_Contact_Id = Convert.ToInt32(Conversion.Val($"{modCommon.DLookUp("cref_contact_id", "aircraft_reference", $"cref_contact_type in('70','96') and cref_ac_id= {modAdminCommon.gbl_Aircraft_ID.ToString()} and cref_journ_id= {Journal_ID.ToString()} ")}"));
						}

						EventDesc = cbo_doc_type.Text;


						switch(DocCode.ToUpper())
						{
							case "TRS" : 
								 
								if (lst_Trustee.Items.Count > 0)
								{
									EventDesc = modCommon.GetCompanyName(lst_Trustee.GetItemData(0), 0);
								}
								else
								{
									EventDesc = txt_adoc_trustee_note.Text;
								} 

								 
								break;
							case "SCA" : case "MTG" : case "HAG" : 
								 
								if (lst_In_Favor_of.Items.Count > 0)
								{
									EventDesc = $"In Favor Of {modCommon.GetCompanyName(lst_In_Favor_of.GetItemData(0), 0)} ";
								}
								else if (txt_In_Favor_of_Notes.Text.Trim() != "")
								{ 
									EventDesc = $"In Favor Of {txt_In_Favor_of_Notes.Text.Trim()} ";
								} 
								 
								if (lst_On_Behalf_of.Items.Count > 0)
								{
									EventDesc = $"{EventDesc}On Behalf Of {modCommon.GetCompanyName(lst_On_Behalf_of.GetItemData(0), 0)}";
								}
								else if (txt_On_Behalf_of_Notes.Text.Trim() != "")
								{ 
									EventDesc = $"{EventDesc}On Behalf Of {txt_On_Behalf_of_Notes.Text.Trim()}";
								} 
								 
								break;
							default:
								if (cbo_doc_type.Text.Trim().IndexOf("Amended", StringComparison.CurrentCultureIgnoreCase) >= 0 || cbo_doc_type.Text.Trim().IndexOf("Amendment", StringComparison.CurrentCultureIgnoreCase) >= 0 || cbo_doc_type.Text.Trim().StartsWith("Amended", StringComparison.Ordinal) || cbo_doc_type.Text.Trim().StartsWith("Amendment", StringComparison.Ordinal))
								{

									if (txt_adoc_general_note.Text.Trim() != "")
									{
										EventDesc = txt_adoc_general_note.Text.Trim();
									}

								} 
								 
								break;
						}


						if (tmpSeqNo == 0)
						{
							EventDesc = $"{EventDesc}ERROR:SEQNO=0";
							throw new Exception();
						}
						if (!DocUpdate)
						{
							// IF WE ARE ADDING A DOCUMENT
							modCommon.Transaction_Insert_Priority_Event($"DOC{DocCode}", modAdminCommon.gbl_Aircraft_ID, Journal_ID, EventDesc, Event_Comp_Id, Event_Contact_Id, tmpSeqNo, false);
						}

					}

					if (IsHistory)
					{
						if (Entry_Point != "Transaction" && SubCategoryCode != "ACDOC")
						{
							arr_Transmit_Fields = new string[]{"", ""};
							arr_Transmit_Fields[0] = " ";
							modAdminCommon.Record_Transmit(Aircraft_Serial_Number, modAdminCommon.gbl_Aircraft_ID, Journal_ID, model_id, "Transaction", "Change", ref arr_Transmit_Fields, 0);
							From_Form = "";
						}
					}
				}
				else
				{
					result = false;
				} // if add new

				if (ado_Add.State == ConnectionState.Open)
				{
					ado_Add.Close();
				}

				ado_Add = null;

				this.Cursor = CursorHelper.CursorDefault;

				if (modGlobalVars.bCallShowAndLoadOnlyOnce)
				{

					//UPGRADE_TODO: (1067) Member Clear_Search_Criteria is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_DOCS].Clear_Search_Criteria(true, true, true);

				}

				txt_adoc_doc_date.Text = txt_adoc_doc_date.Text;

				return result;
			}
			catch (System.Exception excep)
			{

				result = false;
				this.Cursor = CursorHelper.CursorDefault;
				modAdminCommon.Report_Error($"Save_Aircraft_Document_Error: {excep.Message} {inCompIDs} {DocCode} {EventDesc}");
				return result;
			}
		}

		private void ToolbarButtonsSetup()
		{


			ToolStrip tbr = tbr_ToolBar;

			tbr.Items[1].Visible = false;
			tbr.Items[3].Visible = true;
			tbr.Items[5].Visible = false;
			tbr.Items[7].Visible = true;

			tbr.Items[1].Enabled = false;
			tbr.Items[3].Enabled = true;
			tbr.Items[5].Enabled = false;
			tbr.Items[7].Enabled = true;

		}

		private void ToolbarSetup()
		{


			ToolStrip tbr = tbr_ToolBar;

			tbr.ImageList = mdi_ResearchAssistant.DefInstance.imgNormal;

			tbr.Items[1].ImageKey = "Home";
			tbr.Items[3].ImageKey = "Back";
			tbr.Items[5].ImageKey = "Save";
			tbr.Items[7].ImageKey = "Help";

			tbr.Items[1].Name = "Home";
			tbr.Items[3].Name = "Back";
			tbr.Items[5].Name = "Save";
			tbr.Items[7].Name = "Help";

			tbr.Items[1].ToolTipText = "Go to Main Menu";
			tbr.Items[3].ToolTipText = "Go to Previous Screen";
			tbr.Items[5].ToolTipText = "Save screen data";
			tbr.Items[7].ToolTipText = "Online Help";

		}

		private void tab_Document_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{

			if (SSTabHelper.GetSelectedIndex(tab_Document) == 1)
			{
				Display_Electronic_Document();
			}

			tab_DocumentPreviousTab = tab_Document.SelectedIndex;
		}

		private void tbr_ToolBar_ButtonClick(Object eventSender, EventArgs eventArgs)
		{
			ToolStripItem Button = (ToolStripItem) eventSender;
			try
			{


				switch(Button.Name)
				{
					case "Home" : 
						frm_Main_Menu.DefInstance.Show(); 
						this.Close(); 
						 
						break;
					case "Back" : 
						Close_the_Form(); 
						 
						break;
					case "Save" : 
						MessageBox.Show("This is nothing to Save", "Sold Financial", MessageBoxButtons.OK, MessageBoxIcon.Information); 
						 
						break;
					case "Help" : 
						MessageBox.Show("Help is forthcoming", "Sold Financial", MessageBoxButtons.OK, MessageBoxIcon.Information); 
						 
						break;
					default:
						MessageBox.Show("ToolBar Error", "Unrecognized Toolbar Reference", MessageBoxButtons.OK, MessageBoxIcon.Information); 
						break;
				}
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"tbr_ToolBar_Error: Trans_Docs {Button.Name} {excep.Message}");
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
				return;
			}

		}

		private void Setup_Form()
		{

			try
			{

				txt_adoc_doc_date.Text = "";

				if (modCommon.pf_ValidateDate(Transaction_Date, true))
				{
					txt_adoc_doc_date.Text = DateTime.Parse(Transaction_Date).ToString("d"); // From the 'frm_Aircraft_Change' form
				}

				txt_adoc_doc_amount.Text = "";
				txt_adoc_interest_points.Text = "";
				txt_adoc_number_payments.Text = "";
				txt_adoc_payment_amount.Text = "";
				txt_adoc_last_payment_amount.Text = "";
				txt_adoc_last_payment_date.Text = "";
				txt_adoc_trustee_note.Text = "";
				txt_adoc_sublease_note.Text = "";
				txt_adoc_general_note.Text = "";

				lst_In_Favor_of.Items.Clear();
				lst_On_Behalf_of.Items.Clear();
				lst_Trustee.Items.Clear();
				lst_SubLeased_to.Items.Clear();
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error("Setup_Form_Error: ", excep.Message);
			}

		} // Setup_Form

		public void Get_Aircraft_Documents()
		{

			string Query = "";
			int i = 0;

			try
			{

				i = 0;
				Total_Docs = 0;
				this.Cursor = Cursors.WaitCursor;

				lst_FinancialDoc.Items.Clear();

				Query = $"SELECT * FROM Aircraft_Document WHERE adoc_ac_id = {modAdminCommon.gbl_Aircraft_ID.ToString()}";
				Query = $"{Query} AND adoc_journ_id = {Journal_ID.ToString()} ORDER BY adoc_journ_seq_no";

				snp_SF = new ADORecordSetHelper();
				snp_SF.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_SF.BOF && snp_SF.EOF))
				{
					i++;

					while(!snp_SF.EOF)
					{
						lst_FinancialDoc.AddItem($"{($"0{Convert.ToString(snp_SF["adoc_journ_seq_no"])}").Trim()}-{($"{Convert.ToString(snp_SF["adoc_doc_type"])} ").Trim()}");
						Total_Docs = Convert.ToInt32(Conversion.Val(($"{Convert.ToString(snp_SF["adoc_journ_seq_no"])}").Trim()));
						snp_SF.MoveNext();
						i++;
					};

					lbl_FinancialDoc_Records.Text = $"Document 1 of {(i - 1).ToString()}";
					ListBoxHelper.SetSelectedIndex(lst_FinancialDoc, 0);
					pnl_FinancialDocList.Visible = true;

				}
				this.Cursor = CursorHelper.CursorDefault;
				New_Record = false;
			}
			catch (System.Exception excep)
			{
				modAdminCommon.Report_Error($"Get_Aircraft_Documents_Error: {excep.Message}");

				this.Cursor = CursorHelper.CursorDefault;

				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
			}

		} // Get_Aircraft_Documents

		public void Position_Aircraft_Document()
		{
			snp_SF.MoveFirst();
			int tempForEndVar = ListBoxHelper.GetSelectedIndex(lst_FinancialDoc);
			for (int i = 1; i <= tempForEndVar; i++)
			{
				snp_SF.MoveNext();
			}

		}

		public void Display_Aircraft_Document()
		{
			//******************************************************************************************

			try
			{

				int i = 0;

				this.Cursor = Cursors.WaitCursor;

				int tempForEndVar = cbo_doc_type.Items.Count - 1;
				for (i = 0; i <= tempForEndVar; i++)
				{
					if (cbo_doc_type.GetListItem(i) == ($"{Convert.ToString(snp_SF["adoc_doc_type"])}").Trim())
					{
						cbo_doc_type.SelectedIndex = i;
						break;
					}
				}
				cbo_doc_type.Enabled = false;
				lbl_On_Behalf_of_hdr.Text = "Borrower:";


				if (cbo_doc_type.GetListItem(i).Trim() == "Lease Agreement" || cbo_doc_type.GetListItem(i).Trim() == "Amendment to Aircraft Lease")
				{ // moved below Or Trim(cbo_doc_type.List(i)) = "Assignment of Aircraft Lease"
					lbl_In_Favor_of_hdr.Text = "Lessor";
					lbl_In_Favor_of_Notes.Text = "Lessor Notes";
				}
				else if (cbo_doc_type.GetListItem(i).Trim() == "Assignment of Aircraft Lease" || cbo_doc_type.GetListItem(i).Trim() == "Assignment")
				{ 
					lbl_In_Favor_of_hdr.Text = "Assignor ";
					lbl_In_Favor_of_Notes.Text = "Assignor Notes";

					lbl_On_Behalf_of_hdr.Text = "Assignee:";

				}
				else if (cbo_doc_type.GetListItem(i).Trim() == "Lien Release")
				{ 
					lbl_In_Favor_of_hdr.Text = "Released by";
					lbl_In_Favor_of_Notes.Text = "Released By Notes";
				}
				else
				{
					lbl_In_Favor_of_hdr.Text = "Lender";
					lbl_In_Favor_of_Notes.Text = "Lendor Notes";
				}

				txt_adoc_doc_date.Text = "";
				txt_adoc_doc_amount.Text = "";
				txt_adoc_interest_points.Text = "";
				txt_adoc_number_payments.Text = "";
				txt_adoc_payment_amount.Text = "";
				txt_adoc_last_payment_amount.Text = "";
				txt_adoc_last_payment_date.Text = "";

				// 10/23/2007 - By David D. Cruger - fixed 1/3/08 - mm
				// Clear The Text Box only fill in if date is valid

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(snp_SF["adoc_doc_date"]))
				{
					if (modCommon.pf_ValidateDate(($"{Convert.ToString(snp_SF["adoc_doc_date"])} ").Trim(), true))
					{
						txt_adoc_doc_date.Text = Convert.ToDateTime(snp_SF["adoc_doc_date"]).ToString("d");
					}
				}

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(snp_SF["adoc_doc_amount"]))
				{
					txt_adoc_doc_amount.Text = StringsHelper.Format(snp_SF["adoc_doc_amount"], "###,###.00");
				}

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(snp_SF["adoc_interest_points"]))
				{
					txt_adoc_interest_points.Text = StringsHelper.Format(snp_SF["adoc_interest_points"], "##.00");
				}

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(snp_SF["adoc_number_payments"]))
				{
					txt_adoc_number_payments.Text = ($"{Convert.ToString(snp_SF["adoc_number_payments"])} ").Trim();
				}

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(snp_SF["adoc_payment_amount"]))
				{
					txt_adoc_payment_amount.Text = StringsHelper.Format(snp_SF["adoc_payment_amount"], "###,###.00");
				}

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(snp_SF["adoc_last_payment_amount"]))
				{
					txt_adoc_last_payment_amount.Text = StringsHelper.Format(snp_SF["adoc_last_payment_amount"], "###,###.00");
				}

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(snp_SF["adoc_last_payment_date"]))
				{
					if (modCommon.pf_ValidateDate(Convert.ToString(snp_SF["adoc_last_payment_date"]), true))
					{
						txt_adoc_last_payment_date.Text = Convert.ToDateTime(snp_SF["adoc_last_payment_date"]).ToString("d");
					}
				}

				//04/28/2008 - By David D. Cruger; re-worked the saving and reading of the amounts, interest..etc for these documents

				txt_adoc_trustee_note.Text = ($"{Convert.ToString(snp_SF["adoc_trustee_note"])} ").Trim();
				txt_adoc_sublease_note.Text = ($"{Convert.ToString(snp_SF["adoc_sublease_note"])} ").Trim();
				txt_adoc_general_note.Text = ($"{Convert.ToString(snp_SF["adoc_general_note"])} ").Trim();

				txt_In_Favor_of_Notes.Text = ($"{Convert.ToString(snp_SF["adoc_infavor_text"])} ").Trim();
				txt_On_Behalf_of_Notes.Text = ($"{Convert.ToString(snp_SF["adoc_onbehalf_text"])} ").Trim();

				if (Convert.ToString(snp_SF["adoc_hide_flag"]) == "Y")
				{ //aey 10/6/04 new field added
					chk_adoc_hide_flag.CheckState = CheckState.Checked;
				}
				else
				{
					chk_adoc_hide_flag.CheckState = CheckState.Unchecked;
				}

				mnuEditDocDelete.Available = true;

				//get the previous comp id's --- aey 8/5/2004
				Before_Trustee_comp_id = Convert.ToInt32(snp_SF["adoc_trustee_comp_id"]);
				Before_SubLeased_to_comp_id = Convert.ToInt32(snp_SF["adoc_sublease_contact_id"]);
				Before_In_Favor_of_comp_id = Convert.ToInt32(snp_SF["adoc_infavor_comp_id"]);
				Before_On_Behalf_of_comp_id = Convert.ToInt32(snp_SF["adoc_onbehalf_comp_id"]);

				Display_Document_Company(lst_Trustee, Convert.ToInt32(Double.Parse(($"0{Convert.ToString(snp_SF["adoc_trustee_contact_id"])}").Trim())), Convert.ToInt32(Double.Parse(($"0{Convert.ToString(snp_SF["adoc_trustee_comp_id"])}").Trim())), Journal_ID);

				Display_Document_Company(lst_SubLeased_to, Convert.ToInt32(Double.Parse(($"0{Convert.ToString(snp_SF["adoc_sublease_contact_id"])}").Trim())), Convert.ToInt32(Double.Parse(($"0{Convert.ToString(snp_SF["adoc_sublease_comp_id"])}").Trim())), Journal_ID);
				pnl_SubLeased_to.Visible = Conversion.Val(($" {Convert.ToString(snp_SF["adoc_sublease_comp_id"])}").Trim()) > 0;
				Display_Document_Company(lst_On_Behalf_of, Convert.ToInt32(Double.Parse(($"0{Convert.ToString(snp_SF["adoc_onbehalf_contact_id"])}").Trim())), Convert.ToInt32(Double.Parse(($"0{Convert.ToString(snp_SF["adoc_onbehalf_comp_id"])}").Trim())), Journal_ID);

				Display_Document_Company(lst_In_Favor_of, Convert.ToInt32(Double.Parse(($"0{Convert.ToString(snp_SF["adoc_infavor_contact_id"])}").Trim())), Convert.ToInt32(Double.Parse(($"0{Convert.ToString(snp_SF["adoc_infavor_comp_id"])}").Trim())), Journal_ID);

				Display_FAA_Log_Data();

				mnuAttachDocument.Enabled = true;

				Check_For_Electronic_Document();

				this.Cursor = CursorHelper.CursorDefault;
			}
			catch (System.Exception excep)
			{

				this.Cursor = CursorHelper.CursorDefault;
				modAdminCommon.Report_Error($"Display_Aircraft_Document_Error: {excep.Message}");
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
			}
		}

		private void Get_Journal_Subject()
		{

			try
			{

				string Query = "";
				ADORecordSetHelper snp_JSubject = new ADORecordSetHelper(); //converted to ado 8/9/05 aey
				string RootPath = "";

				Query = $"SELECT * FROM Journal,Journal_Category WHERE journ_id = {Journal_ID.ToString()} AND journ_subcategory_code = jcat_subcategory_code";

				snp_JSubject.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_JSubject.BOF && snp_JSubject.EOF))
				{
					lbl_Aircraft_Documents_hdr.Text = $"Financial Documents for {($"{Convert.ToString(snp_JSubject["journ_subject"])} ").Trim()}";
					IsHistory = (Convert.ToString(snp_JSubject["jcat_category_code"]) == "AH") && Convert.ToString(snp_JSubject["journ_subcategory_code"]).Substring(Math.Max(Convert.ToString(snp_JSubject["journ_subcategory_code"]).Length - 4, 0)) != "CORR";

					SubCategoryCode = ($"{Convert.ToString(snp_JSubject["journ_subcategory_code"])}").Trim();

				}

				snp_JSubject.Close();
				snp_JSubject = null;
			}
			catch (System.Exception excep)
			{
				modAdminCommon.Report_Error($"Get_Journal_Subject_Error: {excep.Message}");

				this.Cursor = CursorHelper.CursorDefault;

				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
			}

		}

		public void Check_For_Electronic_Document()
		{

			string RootPath = "";

			try
			{

				if (lst_FinancialDoc.Text.Substring(Math.Min(lst_FinancialDoc.Text.IndexOf('-') + 1, lst_FinancialDoc.Text.Length), Math.Min(4, Math.Max(0, lst_FinancialDoc.Text.Length - (lst_FinancialDoc.Text.IndexOf('-') + 1)))).ToLower() == "ntsb")
				{
					RootPath = ($"{modCommon.DLookUp("aconfig_ntsb_maindir", "application_configuration")}").Trim();
					modAdminCommon.gbl_Documents = RootPath;

					Current_File_Name = modCommon.Get_Document_File_Name(lst_Aircraft_Info.GetItemData(0), Convert.ToInt32(snp_SF["adoc_journ_id"]), Convert.ToInt32(snp_SF["adoc_journ_seq_no"]), "NTSB", ".html");
				}
				else
				{
					RootPath = ($"{modCommon.DLookUp("aconfig_faapdf_maindir", "application_configuration")}").Trim();
					modAdminCommon.gbl_Documents = RootPath;

					Current_File_Name = modCommon.Get_Document_File_Name(lst_Aircraft_Info.GetItemData(0), Convert.ToInt32(snp_SF["adoc_journ_id"]), Convert.ToInt32(snp_SF["adoc_journ_seq_no"]), "FAAPDF", ".pdf");
				}

				// IF THE FILE IS FOUND THEN TURN ON THE FORM OPTIONS

				if (ErrorHandlingHelper.ResumeNextExpr<bool>(() => File.Exists(Current_File_Name)))
				{
					Exception ex = null;
					ErrorHandlingHelper.ResumeNext(out ex);

					if (ex == null)
					{
						ErrorHandlingHelper.ResumeNext(
							() => {SSTabHelper.SetTabVisible(tab_Document, 1, true);}, 
							() => {img_Document_Picture.Visible = true;}, 
							() => {pnl_faa_log.Visible = true;});
						mnuEditDelAttachment.Available = true;
					}
					else
					{
						ErrorHandlingHelper.ResumeNext(
							() => {SSTabHelper.SetTabVisible(tab_Document, 1, false);}, 
							() => {img_Document_Picture.Visible = false;}, 
							() => {pnl_faa_log.Visible = false;});
						mnuEditDelAttachment.Available = false;
					}
					try
					{

						Information.Err().Clear();
					}
					catch
					{
					}

				}
				else
				{
					try
					{

						// 10/08/2010 - By David D. Cruger - Trying to Fix a Windows 7 Issue
						//Call WebBrowser1.Navigate("about:blank", 256, "self", "", "")
						WebBrowser1.Navigate(new Uri("about:blank"));
					}
					catch
					{
					}

				} // If gfso.FileExists(Current_File_Name) = True Then
			}
			catch
			{

				img_Document_Picture.Visible = false;
				pnl_faa_log.Visible = false;
			}


		}

		public void Setup_New_Aircraft_Document()
		{

			img_Document_Picture.Visible = false;
			pnl_faa_log.Visible = false;
			mnuAttachDocument.Enabled = false;

			New_Record = true; // SET FLAG TO IDENTIFY THAT WE ARE ADDING A NEW DOCUMENT
			SSTabHelper.SetSelectedIndex(tab_Document, 0);
			SSTabHelper.SetTabVisible(tab_Document, 1, false);
			tab_Document.Visible = true;
			Clear_Aircraft_Document();
			Fill_Document_Types();
			WebBrowser1.Navigate(new Uri("about:blank"));

		}

		public void Clear_Aircraft_Document()
		{

			cbo_doc_type.Enabled = true;
			txt_adoc_doc_date.Text = "";
			txt_adoc_doc_amount.Text = "";
			txt_adoc_interest_points.Text = "";
			txt_adoc_number_payments.Text = "";
			txt_adoc_payment_amount.Text = "";
			txt_adoc_last_payment_amount.Text = "";
			txt_adoc_last_payment_date.Text = "";
			chk_adoc_hide_flag.CheckState = CheckState.Unchecked; //aey 10/06/04 new field

			txt_adoc_trustee_note.Text = "";
			txt_adoc_sublease_note.Text = "";
			txt_adoc_general_note.Text = "";

			txt_In_Favor_of_Notes.Text = "";
			txt_On_Behalf_of_Notes.Text = "";
			lst_On_Behalf_of.Items.Clear();
			lst_In_Favor_of.Items.Clear();
			lst_Trustee.Items.Clear();
			lst_SubLeased_to.Items.Clear();
			pnl_SubLeased_to.Visible = false;
			pnl_On_Behalf_of.Visible = false;
			pnl_In_Favor_of.Visible = false;
			pnl_Trustee.Visible = false;
			pnl_Values.Visible = false;
			pnl_faa_log.Visible = false;
			mnuEditDocDelete.Available = false;
			mnuEditDelAttachment.Available = false;
		}

		public void Fill_Document_Types()
		{

			string Query = "";

			try
			{

				bDocumentTypesFilled = false;
				Application.DoEvents();
				cbo_doc_type.Items.Clear();
				Application.DoEvents();
				Application.DoEvents();

				Query = "SELECT * FROM Document_Type WITH (NOLOCK) WHERE (doctype_contract_doc_view = 'N') ";
				Query = $"{Query}AND (doctype_company_doc_view = 'N') ";

				if (frm_Transaction_Documents.DefInstance.Entry_Point == "Transaction")
				{
					Query = $"{Query}AND (doctype_trans_flag = 'Y') ";
				}

				Query = $"{Query}ORDER BY doctype_description";

				snp_Document_Type = new ADORecordSetHelper();
				snp_Document_Type.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_Document_Type.BOF && snp_Document_Type.EOF))
				{


					while(!snp_Document_Type.EOF)
					{
						cbo_doc_type.AddItem(($"{Convert.ToString(snp_Document_Type["doctype_description"])} ").Trim());
						snp_Document_Type.MoveNext();
						bDocumentTypesFilled = true;
					};

					cbo_doc_type.SelectedIndex = 0;

					return;
				}

				snp_Document_Type.Close();
				snp_Document_Type = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"Fill_Document_Types_Error: {excep.Message} {Query}");
				this.Cursor = CursorHelper.CursorDefault;

				snp_Document_Type = null;
			}
		}

		public void Select_Document_Type()
		{
			if (bDocumentTypesFilled)
			{

				snp_Document_Type.MoveFirst();

				int tempForEndVar = cbo_doc_type.SelectedIndex;
				for (int i = 1; i <= tempForEndVar; i++)
				{
					snp_Document_Type.MoveNext();
				}


				switch(($" {Convert.ToString(snp_Document_Type["doctype_fin_flag"])}").Trim())
				{
					case "Y" : 
						pnl_Trustee.Visible = true; 
						pnl_In_Favor_of.Visible = true; 
						pnl_On_Behalf_of.Visible = true; 
						pnl_Values.Visible = true; 
						 
						break;
					default:
						pnl_Trustee.Visible = false; 
						pnl_In_Favor_of.Visible = false; 
						pnl_On_Behalf_of.Visible = false; 
						pnl_Values.Visible = false; 
						break;
				}

			}

		}

		public void Display_Document_Company(ListBox FormBox, int inContact_ID, int inComp_ID, int inJournal_ID)
		{

			if (inComp_ID > 0)
			{
				modCommon.Build_Company_NameAddress(FormBox, inComp_ID, inJournal_ID);
				FormBox.Enabled = false;
				FormBox.Visible = true;
			}
			else
			{
				FormBox.Visible = false;
			} //      FormBox.Visible = True


			switch(FormBox.Name)
			{
				case "lst_SubLeased_to" : 
					SubLeased_to_comp_id = inComp_ID; 
					 
					break;
				case "lst_On_Behalf_of" : 
					On_Behalf_of_comp_id = inComp_ID; 
					 
					break;
				case "lst_In_Favor_of" : 
					In_Favor_of_comp_id = inComp_ID; 
					 
					break;
				case "lst_Trustee" : 
					Trustee_comp_id = inComp_ID; 
					 
					break;
			}

			if (inComp_ID > 0)
			{
				FormBox.Enabled = true;
			}

		}

		public bool Check_Company_History(int inCompany_ID, int inJournal_ID)
		{


			//make sure a zero record exists
			string Query = $"exec HomebaseCheckForCurrentCompany {inCompany_ID.ToString()},{inJournal_ID.ToString()}";
			DbCommand TempCommand = null;
			TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
			UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
			TempCommand.CommandText = Query;
			//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
			TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
			UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
			TempCommand.ExecuteNonQuery();

			Query = $"SELECT comp_id FROM Company WHERE comp_id={inCompany_ID.ToString()} AND comp_journ_id={inJournal_ID.ToString()}";

			return modAdminCommon.Exist(Query);

		}

		public void Display_FAA_Log_Data()
		{
			ADORecordSetHelper snp_FAA_Doc_Log = new ADORecordSetHelper(); //converted to ado 8/9/05 aey

			string Query = $"select * from FAA_Document_Log WHERE faalog_ac_id={Convert.ToString(snp_SF["adoc_ac_id"])}";
			Query = $"{Query} and faalog_journ_id={Convert.ToString(snp_SF["adoc_journ_id"])} and faalog_journ_seq_no={Convert.ToString(snp_SF["adoc_journ_seq_no"])}";

			snp_FAA_Doc_Log.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

			if (!(snp_FAA_Doc_Log.BOF && snp_FAA_Doc_Log.EOF))
			{
				pnl_faa_log.Visible = true;
				txt_faalog_tape_no.Text = ($" {Convert.ToString(snp_FAA_Doc_Log["faalog_tape_no"])}").Trim();
				txt_faalog_starting_frame_no.Text = ($" {Convert.ToString(snp_FAA_Doc_Log["faalog_starting_frame_no"])}").Trim();
				txt_faalog_ending_frame_no.Text = ($" {Convert.ToString(snp_FAA_Doc_Log["faalog_ending_frame_no"])}").Trim();
				txt_faalog_tape_of.Text = ($" {Convert.ToString(snp_FAA_Doc_Log["faalog_tape_of"])}").Trim();
				txt_faalog_tape_to.Text = ($" {Convert.ToString(snp_FAA_Doc_Log["faalog_tape_to"])}").Trim();
				System.DateTime TempDate2 = DateTime.FromOADate(0);
				txt_faalog_tape_date.Text = (DateTime.TryParse(($" {Convert.ToString(snp_FAA_Doc_Log["faalog_tape_date"])}").Trim(), out TempDate2)) ? TempDate2.ToString("MM/dd/yyyy") : ($" {Convert.ToString(snp_FAA_Doc_Log["faalog_tape_date"])}").Trim();
			}
			else
			{
				pnl_faa_log.Visible = false;
				txt_faalog_tape_no.Text = "";
				txt_faalog_starting_frame_no.Text = "";
				txt_faalog_ending_frame_no.Text = "";
				txt_faalog_tape_of.Text = "";
				txt_faalog_tape_to.Text = "";
				txt_faalog_tape_date.Text = "";
				Fill_Document_Log();
			}
			snp_FAA_Doc_Log.Close();
			snp_FAA_Doc_Log = null;
			cmd_Attach.Visible = false;

		}

		public void Fill_Document_Log()
		{
			//******************************************************************************************

			//******************************************************************************************

			int TotFound = 0;
			string Query = "";
			string cellcolor = "";
			//Set snp_DocLog = New ADODB.Recordset

			try
			{ //aey 4/15/05
				cellcolor = modAdminCommon.NoColor;
				this.Cursor = Cursors.WaitCursor;
				TotFound = 0;
				grd_DocumentLog.Clear();
				grd_DocumentLog.Visible = false;
				grd_DocumentLog.ColumnsCount = 5;
				grd_DocumentLog.CurrentRowIndex = 0;
				grd_DocumentLog.CurrentColumnIndex = 0;
				grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = "Type";
				grd_DocumentLog.DefaultCellStyle.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_DocumentLog.SetColumnWidth(0, 47);

				grd_DocumentLog.CurrentColumnIndex = 1;
				grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = "Tape#";
				grd_DocumentLog.DefaultCellStyle.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_DocumentLog.SetColumnWidth(1, 60);

				grd_DocumentLog.CurrentColumnIndex = 2;
				grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = "Date";
				grd_DocumentLog.DefaultCellStyle.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_DocumentLog.SetColumnWidth(2, 67);

				grd_DocumentLog.CurrentColumnIndex = 3;
				grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = "Frame Start";
				grd_DocumentLog.DefaultCellStyle.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_DocumentLog.SetColumnWidth(3, 67);

				grd_DocumentLog.CurrentColumnIndex = 4;
				grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = "Frame End";
				grd_DocumentLog.DefaultCellStyle.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_DocumentLog.SetColumnWidth(4, 67);

				Query = $"SELECT * FROM FAA_Document_Log WHERE faalog_ac_id = {modAdminCommon.gbl_Aircraft_ID.ToString()}";
				Query = $"{Query} AND faalog_doc_type = '{Get_Document_Type()}' AND faalog_journ_id = 0 ORDER BY faalog_doc_type, faalog_starting_frame_no";

				snp_DocLog = new ADORecordSetHelper();
				snp_DocLog.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_DocLog.BOF && snp_DocLog.EOF))
				{

					grd_DocumentLog.RowsCount = 1;
					grd_DocumentLog.RowsCount++;
					grd_DocumentLog.CurrentRowIndex = 1;


					while(!snp_DocLog.EOF)
					{

						// DOCUMENT TYPE
						grd_DocumentLog.CurrentColumnIndex = 0;
						grd_DocumentLog.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
						grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = $" {($"{Convert.ToString(snp_DocLog["faalog_doc_type"])}").Trim()}";
						grd_DocumentLog.CurrentColumnIndex++;

						// TAPE#
						grd_DocumentLog.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
						grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = $" {($"{Convert.ToString(snp_DocLog["faalog_tape_no"])}").Trim()}";
						grd_DocumentLog.CurrentColumnIndex++;

						// TAPE DATE
						grd_DocumentLog.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snp_DocLog["faalog_tape_date"]))
						{
							grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = $" {DateTime.Parse(Convert.ToString(snp_DocLog["faalog_tape_date"]).Trim()).ToString("d")}";
						}
						else
						{
							grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = "";
						}

						grd_DocumentLog.CurrentColumnIndex++;

						// FRAME# START
						grd_DocumentLog.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
						grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_DocLog["faalog_starting_frame_no"])}").Trim();
						grd_DocumentLog.CurrentColumnIndex++;

						// FRAME# END
						grd_DocumentLog.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
						grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_DocLog["faalog_ending_frame_no"])}").Trim();

						TotFound++;
						snp_DocLog.MoveNext();
						grd_DocumentLog.RowsCount++;
						grd_DocumentLog.CurrentRowIndex++;
						grd_DocumentLog.CurrentColumnIndex = 0;
					};

					if (grd_DocumentLog.RowsCount > 2)
					{
						grd_DocumentLog.RemoveItem(grd_DocumentLog.RowsCount - 1);
					}

					chkLeaveInProcessing.CheckState = CheckState.Unchecked;
					pnl_Document_Log.Visible = true;

				}
				else
				{
					// no document log matches found
					pnl_Document_Log.Visible = false;
				} // if document log matches found

				grd_DocumentLog.CurrentRowIndex = 0;
				grd_DocumentLog.CurrentColumnIndex = 0;

				grd_DocumentLog.Redraw = true;

				grd_DocumentLog.Visible = true;

				this.Cursor = CursorHelper.CursorDefault;
			}
			catch (Exception e)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				if (Information.Err().Number == 3146)
				{
					MessageBox.Show($"There are too many records to display.{Environment.NewLine}{Environment.NewLine}Please refine your search criteria and try again.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					this.Cursor = CursorHelper.CursorDefault;

					return;
				}
				else
				{
					MessageBox.Show($"Fill Aircraft Grid Error Tran: {Environment.NewLine}{Environment.NewLine}{e.Message}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					this.Cursor = CursorHelper.CursorDefault;
					return;
				}
			}
		}

		public string Get_Document_Type()
		{

			string Query = "";
			try
			{

				ADORecordSetHelper snp_TypeLookup = new ADORecordSetHelper(); //converted to ado 8/9/05 aey

				Query = $"SELECT * FROM Document_Type WITH (NOLOCK) WHERE (doctype_description = '{cbo_doc_type.Text}') ";
				Query = $"{Query}ORDER BY doctype_description";

				snp_TypeLookup.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_TypeLookup.BOF && snp_TypeLookup.EOF))
				{
					return ($"{Convert.ToString(snp_TypeLookup["doctype_code"])} ").Trim();
				}

				snp_TypeLookup.Close();
				snp_TypeLookup = null;
			}
			catch (System.Exception excep)
			{

				this.Cursor = CursorHelper.CursorDefault;
				modAdminCommon.Report_Error($"Get_Document_Type_Error: {excep.Message} {Query}");
			}
			return "";
		}

		public bool Check_for_New_Electronic_Document(string inFile_Name)
		{
			bool result = false;

			if (inFile_Name.Trim() != "")
			{

				if (ErrorHandlingHelper.ResumeNextExpr<bool>(() => File.Exists(inFile_Name)))
				{
					Exception ex = null;
					ErrorHandlingHelper.ResumeNext(out ex);
					if (ex == null)
					{
						try
						{

							result = true;
						}
						catch
						{
						}

					}
					else
					{
						result = false;
					}
				}
				else
				{
					result = false;
				}
				Information.Err().Clear();
			}

			return result;

		}

		public void Position_Document_Log()
		{
			snp_DocLog.MoveFirst();
			int tempForEndVar = grd_DocumentLog.CurrentRowIndex - 1;
			for (int i = 1; i <= tempForEndVar; i++)
			{
				snp_DocLog.MoveNext();
			}
		}

		public void Install_New_Electronic_Document()
		{

			string Query = "";
			int Current_Row = 0;
			string DefaultNote = "";
			bool LeaveInProcessing = false;
			string Msg = "";
			int tmpJournID = 0;
			string tmpFileLocation = ""; // USED TO IDENTIFY WHERE THE FILE WILL BE STORED
			string tmpFileType = ""; // USED TO IDENTIFY THE TYPE OF FILE BEING STORED
			string errMsg = "";
			string RootPath = "";
			try
			{

				errMsg = "Note";
				DefaultNote = ($"{Convert.ToString(snp_DocLog["faalog_general_note"])}").Trim();
				Msg = InputBoxHelper.InputBox(DefaultNote, "Additional Document Notes?", $"per tape {DateTime.Parse(($"{Convert.ToString(snp_DocLog["faalog_tape_date"])}").Trim()).ToString("d")}");
				if (Msg != "")
				{
					DefaultNote = $"{DefaultNote}; {Msg}";
				}

				errMsg = "in processing";
				LeaveInProcessing = chkLeaveInProcessing.CheckState == CheckState.Checked;

				Current_Row = ListBoxHelper.GetSelectedIndex(lst_FinancialDoc);
				cmd_Attach.Visible = false;
				errMsg = "trans";
				modAdminCommon.ADO_Transaction("BeginTrans");

				Query = "UPDATE Aircraft_Document set adoc_action_date = null,";

				// ADDED BY RTW - ON 1/20/2011 - to make sure update date is changed when document is attached
				Query = $"{Query}adoc_update_date='{DateTime.Parse(modAdminCommon.GetDateTime()).ToString("MM/dd/yyyy HH:mm:ss")}',";

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(snp_DocLog["faalog_document_date"]))
				{
					Query = $"{Query}adoc_doc_date = '{Convert.ToDateTime(snp_DocLog["faalog_document_date"]).ToString("d")}'";
				}
				else
				{
					Query = $"{Query}adoc_doc_date = null";
				}

				// ******************************************************
				// FINISH THE QUERY AND PERFORM THE UPDATE TO THE DOCUMENT
				Query = $"{Query} Where adoc_journ_id = {Convert.ToString(snp_SF["adoc_journ_id"])} and adoc_journ_seq_no = {Convert.ToString(snp_SF["adoc_journ_seq_no"])}";
				Query = $"{Query} and adoc_ac_id = {Convert.ToString(snp_SF["adoc_ac_id"])}";

				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'ADODB.ExecuteOptionEnum' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();

				// ***********************************************************************
				// IF THE USER DESIRES TO LEAVE THE DOCUMENT FOR LATER ATTACHMENT TO
				// OTHER TRANSACTIONS THEN DO NOT UPDATE THE DOCUMENT LOG
				if (!LeaveInProcessing)
				{

					// 03/17/2014 - By David D. Cruger
					// Added Record Event For Attaching To Transaction
					modAdminCommon.Record_Event("HBFAADocLog", $"Attach FAA Doc To Transaction Document Id:=[{Convert.ToString(snp_DocLog["faalog_id"])}]", Convert.ToInt32(snp_SF["adoc_ac_id"]), Convert.ToInt32(snp_SF["adoc_journ_id"]), 0, false);

					Query = $"UPDATE faa_document_log set  faalog_journ_id={Convert.ToString(snp_SF["adoc_journ_id"])},";
					Query = $"{Query}faalog_update_date='{DateTime.Parse(modAdminCommon.GetDateTime()).ToString("MM/dd/yyyy HH:mm:ss")}', faalog_journ_seq_no={Convert.ToString(snp_SF["adoc_journ_seq_no"])}";
					Query = $"{Query} WHERE faalog_id = {Convert.ToString(snp_DocLog["faalog_id"])}";
					DbCommand TempCommand_2 = null;
					TempCommand_2 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
					TempCommand_2.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'ADODB.ExecuteOptionEnum' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand_2.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
					TempCommand_2.ExecuteNonQuery();
				}

				errMsg = "journal";
				// *****************************************************************
				// CREATE THE JOURNAL ENTRY INDICATING THAT A DOCUMENT WAS ATTACHED
				modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(modAdminCommon.DateToday);

				modAdminCommon.Rec_Journal_Info.journ_category_code = "AH";
				modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "RN";
				modAdminCommon.Rec_Journal_Info.journ_subject = $"Attached {($"{Convert.ToString(snp_SF["adoc_doc_type"])}").Trim()}";

				modAdminCommon.Rec_Journal_Info.journ_description = DefaultNote;
				modAdminCommon.Rec_Journal_Info.journ_ac_id = Convert.ToInt32(snp_SF["adoc_ac_id"]);
				modAdminCommon.Rec_Journal_Info.journ_comp_id = 0;
				modAdminCommon.Rec_Journal_Info.journ_contact_id = 0;
				modAdminCommon.Rec_Journal_Info.journ_account_id = "";
				modAdminCommon.Rec_Journal_Info.journ_prior_account_id = "";
				modAdminCommon.Rec_Journal_Info.journ_status = "A";
				tmpJournID = frm_Journal.DefInstance.Commit_Journal_Entry();

				// add the priority event in - MSW - 6/9/2020
				if (Convert.ToString(snp_SF["adoc_doc_type"]).Trim() == "DeRegistration")
				{
					modCommon.Transaction_Insert_Priority_Event("DOCDRG", Convert.ToInt32(snp_SF["adoc_ac_id"]), 0, "", 0, 0, 0, false, "");
				}

				errMsg = "doctype";
				switch(($"{Convert.ToString(snp_DocLog["faalog_doc_type"])}").Trim().ToUpper())
				{
					case "NTS" : 
						RootPath = ($"{modCommon.DLookUp("aconfig_ntsb_maindir", "application_configuration")}").Trim(); 
						modAdminCommon.gbl_Documents = RootPath; 
						 
						tmpFileType = "NTSB"; 
						// tmpFileLocation = Document_Processing_Directory & "\NTSB\" & Trim("" & snp_DocLog!faalog_id) & ".html" 
						tmpFileLocation = $"{RootPath}\\PROCESSING\\{($"{Convert.ToString(snp_DocLog["faalog_id"])}").Trim()}.html"; 

						 
						break;
					default:
						RootPath = ($"{modCommon.DLookUp("aconfig_faapdf_maindir", "application_configuration")}").Trim(); 
						modAdminCommon.gbl_Documents = RootPath; 
						 
						tmpFileType = "FAAPDF"; 
						//           tmpFileLocation = Document_Processing_Directory & "\" & Log_File_Name 
						tmpFileLocation = $"{RootPath}\\PROCESSING\\";  //& Log_File_Name 
						break;
				}

				errMsg = "attach";
				if (modCommon.AttachFile(Log_File_Name, tmpFileType, 0, Convert.ToInt32(snp_SF["adoc_journ_id"]), Convert.ToInt32(snp_SF["adoc_journ_seq_no"]), Convert.ToInt32(snp_SF["adoc_ac_id"]), LeaveInProcessing))
				{
					modAdminCommon.ADO_Transaction("CommitTrans");
					pnl_Document_Log.Visible = false;
					MessageBox.Show("File Successfully Attached.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					Get_Aircraft_Documents();
					ListBoxHelper.SetSelectedIndex(lst_FinancialDoc, Current_Row);
				}
				else
				{
					modAdminCommon.ADO_Transaction("RollbackTrans");
					pnl_Document_Log.Visible = false;
					MessageBox.Show($"AttachFileError: FileName[{tmpFileLocation}]", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}
			}
			catch (System.Exception excep)
			{

				modAdminCommon.ADO_Transaction("RollbackTrans");
				modAdminCommon.Report_Error($"Error in File Storage: Copy File Aborted during add document {errMsg} {excep.Message}");
			}

		}

		public void Display_Electronic_Document()
		{

			string strDisplayFile = "";

			modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Loading Scanned Document Image .....", Color.Blue);

			if (Current_File_Name.Substring(Math.Max(Current_File_Name.Length - 4, 0)).ToLower() == "html")
			{
				WebBrowser1.Navigate(new Uri(Current_File_Name));
			}
			else
			{

				strDisplayFile = Current_File_Name;

				if (!strDisplayFile.StartsWith("http:", StringComparison.Ordinal))
				{
					strDisplayFile = $"http:{StringsHelper.Replace(strDisplayFile, "\\", "/", 1, -1, CompareMethod.Binary)}";
				}

				if (!pnl_Document_Log.Visible)
				{

					if (File.Exists(Current_File_Name))
					{
						WebBrowser1.Navigate(new Uri(strDisplayFile));

					}

				} // If (pnl_Document_Log.Visible = False) Then

			} // If LCase(right(Current_File_Name, 4)) = "html" Then

			modStatusBar.Clear_Status_Bar(modAdminCommon.SB);

		}

		public void Close_the_Form()
		{

			Been_Here = false;
			SSTabHelper.SetSelectedIndex(tab_Document, 0);
			modGlobalVars.bKeepTransactionFocus = false;

			this.Close(); // Temp Hold - 03/28/2017- Per Matt; Move this here.

			if (!modCommon.Is_Form_Already_Loaded("frm_Aircraft"))
			{
				//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//VB.Global.Load(frm_aircraft.DefInstance);
			}
			Application.DoEvents();
			Application.DoEvents();
			frm_aircraft.DefInstance.Form_Initialize();
			frm_aircraft.DefInstance.StartForm = modGlobalVars.tStart_Form;
			frm_aircraft.DefInstance.Reference_Aircraft_ID = modAdminCommon.gbl_Aircraft_ID;
			frm_aircraft.DefInstance.Reference_Journal_ID = modAdminCommon.gbl_Aircraft_Journal_ID;
			Application.DoEvents();
			Application.DoEvents();
			if (Entry_Point == "Transaction" || Entry_Point == "Aircraft")
			{

				frm_aircraft.DefInstance.Reference_Aircraft_ID = modAdminCommon.gbl_Aircraft_ID;

			}
			else
			{

				frm_aircraft.DefInstance.JournalIDToShow = Journal_ID;

			}
			Application.DoEvents();
			frm_aircraft.DefInstance.Reference_Company_ID = 0;
			frm_aircraft.DefInstance.Show();
			//UPGRADE_WARNING: (2065) Form method frm_aircraft.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
			frm_aircraft.DefInstance.BringToFront();
			//UPGRADE_WARNING: (2065) Form event Form.Activated has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
			frm_aircraft.DefInstance.Form_Activated(frm_aircraft.DefInstance, new EventArgs());
			Application.DoEvents();
			Application.DoEvents();
			if (modGlobalVars.bCallShowAndLoadOnlyOnce)
			{

				//UPGRADE_TODO: (1067) Member Clear_Search_Criteria is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_DOCS].Clear_Search_Criteria(true, false, true);

			}
			Application.DoEvents();
		}

		public void Remove_Aircraft_Document(string inType)
		{

			string errMsg = "";
			try
			{
				string Query = "";
				ADORecordSetHelper snpGetLog = new ADORecordSetHelper(); //converted to ado 8/9/05 aey Recordset
				int tmpEventID = 0;
				ADORecordSetHelper snpEvent = new ADORecordSetHelper(); //ado
				string RootPath = "";
				int adoc_journ_id = 0;
				int adoc_journ_seq_no = 0;
				int adoc_ac_id = 0;
				string adoc_doc_type = "";
				int faalog_id = 0;

				WebBrowser1.Navigate(new Uri("about:blank"));

				adoc_journ_id = Convert.ToInt32(snp_SF["adoc_journ_id"]);
				adoc_journ_seq_no = Convert.ToInt32(snp_SF["adoc_journ_seq_no"]);
				adoc_ac_id = Convert.ToInt32(snp_SF["adoc_ac_id"]);
				adoc_doc_type = Convert.ToString(snp_SF["adoc_doc_type"]);

				tmpEventID = 0;
				errMsg = "step 0";

				if (inType == "Document")
				{
					errMsg = "Step 1";
					Query = $"SELECT priorev_id FROM Priority_Events WHERE priorev_journ_id = {adoc_journ_id.ToString()} ";
					Query = $"{Query}and priorev_journ_seq_no = {adoc_journ_seq_no.ToString()} and priorev_ac_id = {adoc_ac_id.ToString()}";

					snpEvent.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!(snpEvent.BOF && snpEvent.EOF))
					{
						tmpEventID = Convert.ToInt32(Double.Parse(($"{Convert.ToString(snpEvent["priorev_id"])}").Trim()));
					}

					snpEvent.Close();
					snpEvent = null;
				}

				// *******************************************
				// WRAP THE WHOLE THING AS A TRANSACTION
				errMsg = "Step 2";
				modAdminCommon.ADO_Transaction("BeginTrans");
				switch(inType)
				{
					case "Document" : 
						 
						if (tmpEventID > 0)
						{
							Query = $"DELETE FROM Priority_Events WHERE priorev_id = {tmpEventID.ToString()}";
							DbCommand TempCommand = null;
							TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
							TempCommand.CommandText = Query;
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'ADODB.ExecuteOptionEnum' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
							TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
							TempCommand.ExecuteNonQuery();

							modAdminCommon.Record_Delete_Log_Entry("Priority Event", 0, 0, 0, tmpEventID);
						} 
						 
						// RECORD AN EVENT THAT THE DOCUMENT WAS REMOVEDin home 
						modAdminCommon.Record_Event("Remove Document", $"Removed : {adoc_ac_id.ToString()}-{adoc_journ_id.ToString()}-{adoc_journ_seq_no.ToString()}", adoc_ac_id, adoc_journ_id); 
						 
						modAdminCommon.Record_Delete_Log_Entry("Document", adoc_ac_id, adoc_journ_id, adoc_journ_seq_no); 
						 
						// DELETE THE FILE FROM THE AIRCRAFT DOCUMENTS LOG 
						Query = $" Delete from Aircraft_Document where adoc_journ_id={adoc_journ_id.ToString()} "; 
						Query = $"{Query}and adoc_journ_seq_no={adoc_journ_seq_no.ToString()} and adoc_ac_id = {adoc_ac_id.ToString()}"; 
						DbCommand TempCommand_2 = null; 
						TempCommand_2 = modAdminCommon.ADODB_Trans_conn.CreateCommand(); 
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2); 
						TempCommand_2.CommandText = Query; 
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064 
						//UPGRADE_WARNING: (6021) Casting 'ADODB.ExecuteOptionEnum' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021 
						TempCommand_2.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2); 
						TempCommand_2.ExecuteNonQuery(); 
						 
						break;
					case "Attachment" : 
						if (($"{Convert.ToString(snp_SF["adoc_doc_type"])}").Trim().Substring(0, Math.Min(4, ($"{Convert.ToString(snp_SF["adoc_doc_type"])}").Trim().Length)).ToLower() != "ntsb")
						{

							//************************************************
							// set the document record to null so that it will transmit to the web
							Query = $"UPDATE Aircraft_Document set adoc_action_date = null Where adoc_journ_id={adoc_journ_id.ToString()} ";
							Query = $"{Query}and adoc_journ_seq_no={adoc_journ_seq_no.ToString()} and adoc_ac_id = {adoc_ac_id.ToString()}";
							DbCommand TempCommand_3 = null;
							TempCommand_3 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_3);
							TempCommand_3.CommandText = Query;
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'ADODB.ExecuteOptionEnum' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
							TempCommand_3.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_3);
							TempCommand_3.ExecuteNonQuery();

						} 
						 
						modAdminCommon.Record_Event("Remove Attachment", $"Removed : {adoc_ac_id.ToString()}-{adoc_journ_id.ToString()}-{adoc_journ_seq_no.ToString()}", adoc_ac_id, adoc_journ_id); 
						 
						break;
				}

				errMsg = "Step 3";
				// GET THE DOCUMENT LOG ENTRY
				Query = $"select * from faa_document_log where faalog_journ_id={adoc_journ_id.ToString()} ";
				Query = $"{Query}and faalog_journ_seq_no={adoc_journ_seq_no.ToString()} and faalog_ac_id = {adoc_ac_id.ToString()}";

				snpGetLog.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				Log_File_Name = "";
				faalog_id = 0;
				if (!(snpGetLog.BOF && snpGetLog.EOF))
				{
					snpGetLog.MoveFirst();
					faalog_id = Convert.ToInt32(snpGetLog["faalog_id"]);
					if (($"{adoc_doc_type}").Trim().Substring(0, Math.Min(4, ($"{adoc_doc_type}").Trim().Length)).ToLower() == "ntsb")
					{
						// IF IT IS AN NTSB FILE THEN ASSIGN THE PROCESSING DIRECTORY FILE NAME
						//Log_File_Name = "NTSB\" & Trim("" & snpGetLog!faalog_id) & ".html"
						RootPath = ($"{modCommon.DLookUp("aconfig_ntsb_maindir", "application_configuration")}").Trim();
						modAdminCommon.gbl_Documents = RootPath;
						Log_File_Name = $"{RootPath}\\PROCESSING\\{($"{Convert.ToString(snpGetLog["faalog_id"])}").Trim()}.html";
					}
					else
					{
						// IF IT IS AN FAA DOCUMENT THEN ASSIGN THE PROCESSING DIRECTORY FILE NAME
						RootPath = ($"{modCommon.DLookUp("aconfig_faapdf_maindir", "application_configuration")}").Trim();
						modAdminCommon.gbl_Documents = RootPath;

						//Log_File_Name = Format(Trim(snpGetLog!faalog_tape_no & " "), "00000")
						Log_File_Name = $"{RootPath}\\PROCESSING\\{StringsHelper.Format(($"{Convert.ToString(snpGetLog["faalog_tape_no"])} ").Trim(), "00000")}";
						Log_File_Name = $"{Log_File_Name}-{StringsHelper.Format(($"{Convert.ToString(snpGetLog["faalog_tape_of"])} ").Trim(), "0")}";
						Log_File_Name = $"{Log_File_Name}of{StringsHelper.Format(($"{Convert.ToString(snpGetLog["faalog_tape_to"])} ").Trim(), "0")}";
						Log_File_Name = $"{Log_File_Name}-{StringsHelper.Format(($"{Convert.ToString(snpGetLog["faalog_starting_frame_no"])} ").Trim(), "00000")}";
						Log_File_Name = $"{Log_File_Name}-{StringsHelper.Format(($"{Convert.ToString(snpGetLog["faalog_ending_frame_no"])} ").Trim(), "00000")}";
						Log_File_Name = $"{Log_File_Name}-{($"{Convert.ToString(snpGetLog["faalog_doc_type"])} ").Trim().ToLower()}";
						Log_File_Name = $"{Log_File_Name}-{StringsHelper.Format(($"{Convert.ToString(snpGetLog["faalog_ac_id"])} ").Trim(), "000000")}";
						Log_File_Name = $"{Log_File_Name}.pdf";
					}

				}
				snpGetLog.Close();
				snpGetLog = null;


				errMsg = "Step 4";
				if (Strings.Len(Log_File_Name.Trim()) > 0)
				{
					//************************************************
					// clear the information on the faa log so that the record is in process again

					modAdminCommon.Record_Event("HBFAADocLog", $"Un-Attach FAA Doc From Transaction Document Id:=[{faalog_id.ToString()}]", adoc_ac_id, adoc_journ_id, 0, false);

					Query = "UPDATE faa_document_log set faalog_journ_id=0,";
					Query = $"{Query}faalog_update_date='{DateTime.Parse(modAdminCommon.GetDateTime()).ToString("MM/dd/yyyy HH:mm:ss")}',";
					Query = $"{Query}faalog_journ_seq_no=0 Where faalog_id= {faalog_id.ToString()} ";

					DbCommand TempCommand_4 = null;
					TempCommand_4 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_4);
					TempCommand_4.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'ADODB.ExecuteOptionEnum' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand_4.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_4);
					TempCommand_4.ExecuteNonQuery();

					//**************************************************
					// MOVE THE FILE BACK TO THE PROCESSING DIRECTORY
					if (!modCommon.UnAttachFile(Log_File_Name, 0, adoc_journ_id, adoc_journ_seq_no, adoc_ac_id))
					{
						pnl_Document_Log.Visible = false;
						modAdminCommon.ADO_Transaction("RollbackTrans");
						MessageBox.Show($"Error in File Storage: Copy File Aborted -Document cannot be found {Information.Err().Description}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
				}

				modAdminCommon.ADO_Transaction("CommitTrans");

				errMsg = "Step 5";
				//company cleanup 8/17/05 aey
				DeleteUnreferencedCompany(Before_Trustee_comp_id);
				DeleteUnreferencedCompany(Before_SubLeased_to_comp_id);
				DeleteUnreferencedCompany(Before_In_Favor_of_comp_id);
				DeleteUnreferencedCompany(Before_On_Behalf_of_comp_id);

				errMsg = "Step 6";
				pnl_Document_Log.Visible = false;
				switch(inType)
				{
					case "Document" : 
						MessageBox.Show("Document Successfully Removed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly())); 
						break;
					default:
						MessageBox.Show("File Successfully Placed Back in Processing.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly())); 
						break;
				}

				errMsg = "Step 7";
				Query = $"SELECT * FROM Aircraft_Document WHERE adoc_ac_id = {modAdminCommon.gbl_Aircraft_ID.ToString()} AND adoc_journ_id = {Journal_ID.ToString()}";

				if (modAdminCommon.Exist(Query))
				{
					Get_Aircraft_Documents();
					New_Record = false;
				}
				else
				{
					pnl_FinancialDocList.Visible = false;
					Setup_New_Aircraft_Document();
				}
			}
			catch (System.Exception excep)
			{

				modAdminCommon.ADO_Transaction("RollbackTrans");

				modAdminCommon.Report_Error($"Remove_Aircraft_Document_Error: {excep.Message}{errMsg} ,ac_id: {modAdminCommon.gbl_Aircraft_ID.ToString()} , Journ_id: {Journal_ID.ToString()}, type: {inType}", "Transdoc");

			}

		}
	}
}