using Microsoft.VisualBasic;
using System;
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
	internal partial class frm_CompanyContact_MList
		: System.Windows.Forms.Form
	{

		public frm_CompanyContact_MList()
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
		}


		private void frm_CompanyContact_MList_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}

		public int nContactID = 0;
		public int nJournID = 0;
		public int nCompanyID = 0;

		private string gstrEMail = "";
		private string AddMailListCode = "";
		private string RemoveMailListCode = "";

		private bool SelectCompany()
		{
			object nReference_CompanyID = null;
			object nReference_CompanyJID = null;
			//
			// CREATED: 4/23/2011 - RTW
			// REMOVES AN ENTRY FROM THE MAIL LIST AND ADDS A MAIL LIST NOTE TO THE JOURNAL
			//
			string Query = "";
			ADORecordSetHelper ado_ML_Company = null;

			bool Select_Company = false;

			try
			{

				txt_CompanyInfo.Text = "";
				txt_CompanyInfo.Enabled = false;
				txt_ContactInfo.Text = "";
				txt_ContactInfo.Enabled = false;

				Query = "SELECT comp_id, comp_name, comp_address1, comp_address2, comp_city,";
				Query = $"{Query}comp_state, comp_country, comp_zip_code, comp_web_address ";
				Query = $"{Query} FROM Company WITH(NOLOCK)";
				Query = $"{Query} WHERE comp_id = {nCompanyID.ToString()} AND comp_journ_id = 0";

				ado_ML_Company = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(ado_ML_Company.Fields) && !(ado_ML_Company.BOF && ado_ML_Company.EOF))
				{

					txt_CompanyInfo.Text = Convert.ToString(ado_ML_Company["comp_name"]);
					txt_CompanyInfo.Text = $"{txt_CompanyInfo.Text}{Environment.NewLine}{Convert.ToString(ado_ML_Company["comp_address1"])}";
					if (Strings.Len(Convert.ToString(ado_ML_Company["Comp_address2"]).Trim()) > 0)
					{
						txt_CompanyInfo.Text = $"{txt_CompanyInfo.Text}{Environment.NewLine}{Convert.ToString(ado_ML_Company["Comp_address2"])}";
					}
					txt_CompanyInfo.Text = $"{txt_CompanyInfo.Text}{Environment.NewLine}{Convert.ToString(ado_ML_Company["Comp_city"])}";
					txt_CompanyInfo.Text = $"{txt_CompanyInfo.Text}, {Convert.ToString(ado_ML_Company["comp_state"])}";
					txt_CompanyInfo.Text = $"{txt_CompanyInfo.Text} {Convert.ToString(ado_ML_Company["Comp_zip_code"])}";
					txt_CompanyInfo.Text = $"{txt_CompanyInfo.Text}{Environment.NewLine}{Convert.ToString(ado_ML_Company["Comp_country"])}";
					if (Strings.Len(Convert.ToString(ado_ML_Company["comp_web_address"]).Trim()) > 0)
					{
						txt_CompanyInfo.Text = $"{txt_CompanyInfo.Text}{Environment.NewLine}{Convert.ToString(ado_ML_Company["comp_web_address"])}";
					}

					txt_CompanyInfo.Refresh();
					ado_ML_Company.Close();

				}
				else
				{
					// no company record was found

					ado_ML_Company = null;

				} // if company found in database
				Application.DoEvents();
				Select_Company = true;
				ado_ML_Company = null;
				Fill_Comp_Contact_List();
			}
			catch (System.Exception excep)
			{

				Select_Company = false;
				//UPGRADE_WARNING: (1068) nReference_CompanyJID of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
				//UPGRADE_WARNING: (1068) nReference_CompanyID of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"MList SelectCompany_Error ({Information.Err().Number.ToString()}) {excep.Message} CMPID:[{Convert.ToString(nReference_CompanyID)}] JID:[{Convert.ToString(nReference_CompanyJID)}]", "Company (frm_Company)");
			}
			return false;
		}

		private void cmd_Add_ML_Notes_Click(Object eventSender, EventArgs eventArgs)
		{
			//
			// RTW - MODIFIED - 4/23/2011
			// THIS PROCEDURE ADDS A NOTE FOR A GIVEN MAIL LIST
			//

			string tmp_ML_List = "";
			int i = 0;

			frame_Add_Notes.Visible = false;

			if (Strings.Len(cbo_Mail_List_Selected.Text.Trim()) == 0)
			{
				MessageBox.Show("You must select a mail list from the drop down before adding a note.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
			else
			{

				i = (cbo_Mail_List_Selected.Text.IndexOf('-') + 1);
				tmp_ML_List = cbo_Mail_List_Selected.Text.Substring(0, Math.Min(i - 1, cbo_Mail_List_Selected.Text.Length));

				if (Strings.Len(txt_Note_Subject.Text.Trim()) > 0)
				{

					modAdminCommon.Rec_Journal_Info.journ_subject = txt_Note_Subject.Text;
					if (Strings.Len(txt_note_description.Text.Trim()) > 0)
					{
						modAdminCommon.Rec_Journal_Info.journ_description = StringsHelper.Replace(txt_note_description.Text, "'", "", 1, -1, CompareMethod.Binary).Substring(0, Math.Min(4000, StringsHelper.Replace(txt_note_description.Text, "'", "", 1, -1, CompareMethod.Binary).Length));
					}
					else
					{
						modAdminCommon.Rec_Journal_Info.journ_description = modGlobalVars.cEmptyString;
					}
					modAdminCommon.Rec_Journal_Info.journ_ac_id = 0;
					modAdminCommon.Rec_Journal_Info.journ_subcategory_code = tmp_ML_List;
					modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTimeHelper.ToString(DateTime.Now));
					modAdminCommon.Rec_Journal_Info.journ_comp_id = nCompanyID;
					modAdminCommon.Rec_Journal_Info.journ_contact_id = nContactID;
					modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
					modAdminCommon.Rec_Journal_Info.journ_account_id = modGlobalVars.cEmptyString;
					modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
					modAdminCommon.Rec_Journal_Info.journ_status = "A";
					modAdminCommon.Rec_Journal_Info.journ_category_code = "ML";
					frm_Journal.DefInstance.Commit_Journal_Entry();
					Fill_ML_Journals();
					frame_Add_Notes.Visible = false;
					cmd_Add_Note.Visible = true;
				}
				else
				{
					MessageBox.Show("No Note Subject Entered. Please enter subject before adding note.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}


			}


		}

		private void cmd_Add_Note_Click(Object eventSender, EventArgs eventArgs)
		{
			frame_Note_List.Visible = false;
			frame_Add_Notes.Visible = true;
			txt_note_description.Text = "";
			txt_Note_Subject.Text = "";
			cmd_Add_Note.Visible = false;


		}

		private void cmd_Add_To_List_Click(Object eventSender, EventArgs eventArgs)
		{


			if (!Insert_Mail_List_Entry(nCompanyID, nContactID, AddMailListCode))
			{

				MessageBox.Show("Mail List Insert Failed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
			else
			{
				Fill_Master_Mail_List();
				Fill_CompContact_Mail_List();
				Fill_ML_Journals();
				MessageBox.Show($"Added to Mail List ->{AddMailListCode}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}

		private void cmd_cancel_Click(Object eventSender, EventArgs eventArgs)
		{
			frame_Add_Notes.Visible = false;
			frame_Note_List.Visible = true;

		}

		private void cmd_close_form_Click(Object eventSender, EventArgs eventArgs) => this.Close();


		private void cmd_Remove_From_List_Click(Object eventSender, EventArgs eventArgs)
		{

			if (!Remove_Mail_List_Entry(nCompanyID, nContactID, RemoveMailListCode))
			{

				MessageBox.Show("Mail List Delete Failed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
			else
			{
				Fill_Master_Mail_List();
				Fill_CompContact_Mail_List();
				Fill_ML_Journals();
				MessageBox.Show($"Removed From Mail List ->{RemoveMailListCode}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
		private void Form_Load()
		{
			Fill_Mail_List_Options();
			frame_Note_List.Visible = false;
			frame_Add_Notes.Visible = false;
			SelectCompany();
			Fill_Master_Mail_List();
			Fill_CompContact_Mail_List();
			Fill_ML_Journals();
		}


		public void Fill_Comp_Contact_List()
		{
			//
			// CREATED: 4/23/2011 - RTW
			// FILLS LIST OF CONTACTS FOR A GIVEN COMPANY INTO COMBO BOX
			// AND SELECTS THE CONTACT PASSED TO THE FORM AND PUTS INTO THE TEXT BOX.
			//
			string Query = "";
			try
			{

				ADORecordSetHelper snp_SelectContact = null;
				string tmp_contact = "";
				int i = 0;
				int tmpListNum = 0;

				gstrEMail = "";
				lblDoNotSendEMail.Visible = false;

				Query = $"SELECT * from contact where contact_comp_id ={nCompanyID.ToString()} and contact_journ_id = 0 ";
				Query = $"{Query}order by contact_first_name, contact_last_name ";
				cbo_ContactList.Items.Clear();
				i = 0;
				tmpListNum = 0;
				snp_SelectContact = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(snp_SelectContact.Fields) && !(snp_SelectContact.BOF && snp_SelectContact.EOF))
				{


					while(!snp_SelectContact.EOF)
					{
						i++;
						tmp_contact = $"{Convert.ToString(snp_SelectContact["contact_first_name"])} {Convert.ToString(snp_SelectContact["contact_last_name"])}";
						if (Strings.Len(Convert.ToString(snp_SelectContact["contact_title"]).Trim()) > 0)
						{
							tmp_contact = $"{tmp_contact} ({Convert.ToString(snp_SelectContact["contact_title"])})";
						}

						if (Convert.ToDouble(snp_SelectContact["contact_id"]) == nContactID)
						{

							tmpListNum = i;
							txt_ContactInfo.Text = $"{Convert.ToString(snp_SelectContact["contact_first_name"])} {Convert.ToString(snp_SelectContact["contact_last_name"])}";
							if (Strings.Len(Convert.ToString(snp_SelectContact["contact_title"]).Trim()) > 0)
							{
								txt_ContactInfo.Text = $"{txt_ContactInfo.Text}{Environment.NewLine}{Convert.ToString(snp_SelectContact["contact_title"])}";
							}

							// 03/04/2014 - By David D. Cruger
							// Check To See If Contact Is On Do Not Send List
							gstrEMail = ($"{Convert.ToString(snp_SelectContact["contact_email_address"])} ").Trim();
							if (gstrEMail != "")
							{
								txt_ContactInfo.Text = $"{txt_ContactInfo.Text}{Environment.NewLine}{gstrEMail}";
								if (modCommon.DLookUp("DNSEMail_Id", "Do_Not_Send_EMail", $"DNSEMail_Address='{gstrEMail}'") != "")
								{
									lblDoNotSendEMail.Visible = true;
								}
							}

						} // If snp_SelectContact!contact_id = nContactID Then

						cbo_ContactList.AddItem(tmp_contact);
						snp_SelectContact.MoveNext();
					};
					if (tmpListNum > 0)
					{
						cbo_ContactList.SelectedIndex = tmpListNum - 1;
					}

					snp_SelectContact.Close();

				}
				txt_ContactInfo.Refresh();
				txt_ContactInfo.Enabled = false;
				cbo_ContactList.Enabled = false;
				snp_SelectContact = null;
			}
			catch
			{
				MessageBox.Show($"Fill_Comp_Contact_List Error: Error filling contat list: {Query}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
		}


		public void Fill_Master_Mail_List()
		{
			string Query = "";
			try
			{

				ADORecordSetHelper snp_MailListMaster = null;
				string tmp_contact = "";
				int i = 0;
				int tmpListNum = 0;

				Query = "select jcat_subcategory_code,jcat_subcategory_name from journal_category ";
				Query = $"{Query}where jcat_category_code='ML' ";
				Query = $"{Query}and jcat_subcategory_code not in (";
				Query = $"{Query}select ml_jcat_subcategory_code from Mailing_List ";
				Query = $"{Query}where ml_comp_id={nCompanyID.ToString()} and ml_contact_id={nContactID.ToString()}";
				Query = $"{Query}) ";
				Query = $"{Query}order by jcat_subcategory_name ";
				lst_MailListMaster.Items.Clear();
				i = 0;
				tmpListNum = 0;
				snp_MailListMaster = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(snp_MailListMaster.Fields) && !(snp_MailListMaster.BOF && snp_MailListMaster.EOF))
				{


					while(!snp_MailListMaster.EOF)
					{
						i++;
						lst_MailListMaster.AddItem($"{StringsHelper.Replace(Convert.ToString(snp_MailListMaster["jcat_subcategory_name"]), "Mailing List -", "", 1, -1, CompareMethod.Binary)} [{Convert.ToString(snp_MailListMaster["jcat_subcategory_code"])}]");
						snp_MailListMaster.MoveNext();
					};

					snp_MailListMaster.Close();

				}

				lst_MailListMaster.Enabled = true;
				snp_MailListMaster = null;
				cmd_Add_To_List.Visible = false;
			}
			catch
			{
				MessageBox.Show($"Fill_Master_Mail_List Error: Error filling contat list: {Query}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
		}

		public void Fill_CompContact_Mail_List()
		{

			//
			// CREATED: 4/23/2011 - RTW
			// FILLS MAIL LISTS THAT THE COMPANY OR CONTACT IS A PART OF
			//
			string Query = "";
			try
			{

				ADORecordSetHelper snp_MailListMaster = null;
				string tmp_contact = "";
				int i = 0;
				int tmpListNum = 0;

				Query = "select jcat_subcategory_code,jcat_subcategory_name from journal_category ";
				Query = $"{Query}where jcat_category_code='ML' ";
				Query = $"{Query}and jcat_subcategory_code in (";
				Query = $"{Query}select ml_jcat_subcategory_code from Mailing_List ";
				Query = $"{Query}where ml_comp_id={nCompanyID.ToString()} and ml_contact_id={nContactID.ToString()}";
				Query = $"{Query}) ";
				Query = $"{Query}order by jcat_subcategory_name ";
				lst_MailListActive.Items.Clear();
				i = 0;
				tmpListNum = 0;
				snp_MailListMaster = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(snp_MailListMaster.Fields) && !(snp_MailListMaster.BOF && snp_MailListMaster.EOF))
				{


					while(!snp_MailListMaster.EOF)
					{
						i++;
						lst_MailListActive.AddItem($"{StringsHelper.Replace(Convert.ToString(snp_MailListMaster["jcat_subcategory_name"]), "Mailing List -", "", 1, -1, CompareMethod.Binary)} [{Convert.ToString(snp_MailListMaster["jcat_subcategory_code"])}]");
						snp_MailListMaster.MoveNext();
					};

					snp_MailListMaster.Close();

				}

				lst_MailListActive.Enabled = true;
				snp_MailListMaster = null;
				cmd_Remove_From_List.Visible = false;
			}
			catch
			{
				MessageBox.Show($"Fill_CompContact_Mail_List Error: Error filling contat list: {Query}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
		}

		private void lst_MailListActive_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{
			RemoveMailListCode = lst_MailListActive.Text;
			int i = (RemoveMailListCode.IndexOf('[') + 1);
			RemoveMailListCode = StringsHelper.Replace(RemoveMailListCode.Substring(Math.Min(i, RemoveMailListCode.Length), Math.Min(Strings.Len(RemoveMailListCode) - 1, Math.Max(0, RemoveMailListCode.Length - i))), "]", "", 1, -1, CompareMethod.Binary);
			cmd_Remove_From_List.Visible = true;
			//MsgBox ("Remove From Mail List ->" & RemoveMailListCode)
		}

		private void lst_MailListMaster_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{
			AddMailListCode = lst_MailListMaster.Text;
			int i = (AddMailListCode.IndexOf('[') + 1);
			AddMailListCode = StringsHelper.Replace(AddMailListCode.Substring(Math.Min(i, AddMailListCode.Length), Math.Min(Strings.Len(AddMailListCode) - 1, Math.Max(0, AddMailListCode.Length - i))), "]", "", 1, -1, CompareMethod.Binary);
			cmd_Add_To_List.Visible = true;

		}


		private bool Insert_Mail_List_Entry(int incompid, int inContactId, string insubcat)
		{
			//
			// CREATED: 4/23/2011 - RTW
			// INSERTS AN ENTRY INTO THE MAIL LIST AND ADDS A MAIL LIST NOTE TO THE JOURNAL
			//
			bool result = false;
			string Query = "insert into Mailing_List (ml_comp_id, ml_contact_id, ml_user_id, ml_entry_date, ml_jcat_subcategory_code) ";
			Query = $"{Query}values ({incompid.ToString()},";
			Query = $"{Query}{inContactId.ToString()},";
			Query = $"{Query}'{modAdminCommon.gbl_User_ID}',";
			Query = $"{Query}'{modAdminCommon.DateToday}',";
			Query = $"{Query}'{insubcat}')";

			DbCommand TempCommand = null;
			TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
			UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
			TempCommand.CommandText = Query;
			UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
			TempCommand.ExecuteNonQuery();
			string temp_list_name = lst_MailListMaster.Text;
			temp_list_name = StringsHelper.Replace(temp_list_name, $"[{insubcat}]", "", 1, -1, CompareMethod.Binary);
			modAdminCommon.Rec_Journal_Info.journ_subject = $"Added to {temp_list_name} List";
			modAdminCommon.Rec_Journal_Info.journ_description = modGlobalVars.cEmptyString;
			modAdminCommon.Rec_Journal_Info.journ_ac_id = 0;
			modAdminCommon.Rec_Journal_Info.journ_subcategory_code = insubcat;
			modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTimeHelper.ToString(DateTime.Now));
			modAdminCommon.Rec_Journal_Info.journ_comp_id = incompid;
			modAdminCommon.Rec_Journal_Info.journ_contact_id = inContactId;
			modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
			modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
			modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
			modAdminCommon.Rec_Journal_Info.journ_status = "A";
			modAdminCommon.Rec_Journal_Info.journ_category_code = "ML";
			frm_Journal.DefInstance.Commit_Journal_Entry();
			return true;

		}

		public bool Remove_Mail_List_Entry(int incompid, int inContactId, string insubcat)
		{
			bool result = false;
			string Query = $"delete from Mailing_List where ml_comp_id= {incompid.ToString()} ";
			Query = $"{Query}and ml_contact_id={inContactId.ToString()} ";
			Query = $"{Query}and ml_jcat_subcategory_code='{insubcat}'";
			string temp_list_name = lst_MailListActive.Text;
			temp_list_name = StringsHelper.Replace(temp_list_name, $"[{insubcat}]", "", 1, -1, CompareMethod.Binary);

			DbCommand TempCommand = null;
			TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
			UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
			TempCommand.CommandText = Query;
			UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
			TempCommand.ExecuteNonQuery();
			modAdminCommon.Rec_Journal_Info.journ_subject = $"Removed from {temp_list_name} List";
			modAdminCommon.Rec_Journal_Info.journ_description = modGlobalVars.cEmptyString;
			modAdminCommon.Rec_Journal_Info.journ_ac_id = 0;
			modAdminCommon.Rec_Journal_Info.journ_subcategory_code = insubcat;
			modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(DateTimeHelper.ToString(DateTime.Now));
			modAdminCommon.Rec_Journal_Info.journ_comp_id = incompid;
			modAdminCommon.Rec_Journal_Info.journ_contact_id = inContactId;
			modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
			modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
			modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
			modAdminCommon.Rec_Journal_Info.journ_status = "A";
			modAdminCommon.Rec_Journal_Info.journ_category_code = "ML";
			frm_Journal.DefInstance.Commit_Journal_Entry();


			return true;
		}

		public void Fill_ML_Journals()
		{
			object nReference_CompanyID = null;
			object nReference_CompanyJID = null;

			//
			// CREATED: 4/23/2011 - RTW
			// FILLS THE MASTER LIST OF MAIL LIST CHOICES THAT THE COMPANY OR CONTACT ARE NOT ALREADY A PART OF
			//
			int nRememberTimeout = 0;
			try
			{

				string Query = "";
				Query = modGlobalVars.cEmptyString;
				string TempSubject = "";
				ADORecordSetHelper ado_tmpRS = null;
				ADORecordSetHelper grd_MLJournal = new ADORecordSetHelper();

				string tmpCompName = "";
				tmpCompName = "";
				StringBuilder tmpContactName = new StringBuilder();
				tmpContactName = new StringBuilder("");
				string tmpMakeModelName = "";
				tmpMakeModelName = "";
				string whereIstheError = "";
				whereIstheError = "";


				grd_MLNotes.Visible = false;
				grd_MLNotes.Enabled = false;

				grd_MLNotes.Clear();
				grd_MLNotes.ColumnsCount = 6;
				grd_MLNotes.RowsCount = 2;

				grd_MLNotes.FixedRows = 1;
				grd_MLNotes.FixedColumns = 0;

				grd_MLNotes.CurrentRowIndex = 0;
				grd_MLNotes.CurrentColumnIndex = 0;
				grd_MLNotes.SetColumnWidth(grd_MLNotes.CurrentColumnIndex, 67);
				grd_MLNotes.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_MLNotes[grd_MLNotes.CurrentRowIndex, grd_MLNotes.CurrentColumnIndex].Value = "Date";

				grd_MLNotes.CurrentColumnIndex = 1;
				grd_MLNotes.SetColumnWidth(grd_MLNotes.CurrentColumnIndex, 100);
				grd_MLNotes.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_MLNotes[grd_MLNotes.CurrentRowIndex, grd_MLNotes.CurrentColumnIndex].Value = "User";

				grd_MLNotes.CurrentColumnIndex = 2;
				grd_MLNotes.SetColumnWidth(grd_MLNotes.CurrentColumnIndex, 200);
				grd_MLNotes.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_MLNotes.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
				grd_MLNotes[grd_MLNotes.CurrentRowIndex, grd_MLNotes.CurrentColumnIndex].Value = "Subject";

				grd_MLNotes.CurrentColumnIndex = 3;
				grd_MLNotes.SetColumnWidth(grd_MLNotes.CurrentColumnIndex, 140);
				grd_MLNotes.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_MLNotes[grd_MLNotes.CurrentRowIndex, grd_MLNotes.CurrentColumnIndex].Value = "Description";

				grd_MLNotes.CurrentColumnIndex = 4;
				grd_MLNotes.SetColumnWidth(grd_MLNotes.CurrentColumnIndex, 60);
				grd_MLNotes.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_MLNotes[grd_MLNotes.CurrentRowIndex, grd_MLNotes.CurrentColumnIndex].Value = "Type";

				grd_MLNotes.CurrentColumnIndex = 5;
				grd_MLNotes.SetColumnWidth(grd_MLNotes.CurrentColumnIndex, 60);
				grd_MLNotes.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_MLNotes[grd_MLNotes.CurrentRowIndex, grd_MLNotes.CurrentColumnIndex].Value = "Journal ID";

				Query = modGlobalVars.cEmptyString;
				Query = "SELECT Journal.*, Journal_Category.*, contact_first_name, contact_last_name, contact_title, user_first_name, user_last_name ";
				Query = $"{Query}FROM Journal WITH(NOLOCK) INNER JOIN Journal_Category WITH(NOLOCK) ON journ_subcategory_code = jcat_subcategory_code ";
				Query = $"{Query}LEFT OUTER JOIN Contact WITH(NOLOCK) ON journ_contact_id = contact_id AND contact_journ_id = 0 ";
				Query = $"{Query}left outer join [User] on journ_user_id = [user].user_id ";
				Query = $"{Query}WHERE journ_subcategory_code = jcat_subcategory_code ";
				Query = $"{Query}AND jcat_category_code = 'ML' ";
				Query = $"{Query}AND journ_comp_id = {nCompanyID.ToString()} ";
				Query = $"{Query}AND journ_contact_id = {nContactID.ToString()} ";

				Query = $"{Query}order by journ_id desc";
				nRememberTimeout = UpgradeHelpers.DB.DbConnectionHelper.GetCommandTimeOut(modAdminCommon.LOCAL_ADO_DB);
				UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(modAdminCommon.LOCAL_ADO_DB, 5000);
				//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseClient);
				//Set grd_MLJournal = LOCAL_ADO_DB.Execute(Query, , adCmdText)
				grd_MLJournal.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);


				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(grd_MLJournal.Fields) && !(grd_MLJournal.BOF && grd_MLJournal.EOF))
				{

					grd_MLJournal.ActiveConnection = null;

					grd_MLNotes.CurrentRowIndex = 1;


					while(!grd_MLJournal.EOF)
					{

						tmpCompName = modGlobalVars.cEmptyString;
						tmpContactName = new StringBuilder(modGlobalVars.cEmptyString);


						if (Convert.ToDouble(grd_MLJournal["journ_contact_id"]) > 0)
						{

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(grd_MLJournal.Fields))
							{
								if (!(grd_MLJournal.BOF && grd_MLJournal.EOF))
								{
									//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
									if (!Convert.IsDBNull(grd_MLJournal["contact_first_name"]))
									{
										if (Convert.ToString(grd_MLJournal["contact_first_name"]).Trim() != modGlobalVars.cEmptyString)
										{
											tmpContactName = new StringBuilder(Convert.ToString(grd_MLJournal["contact_first_name"]).Trim());
										}
									}
									//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
									if (!Convert.IsDBNull(grd_MLJournal["contact_last_name"]))
									{
										if (Convert.ToString(grd_MLJournal["contact_last_name"]).Trim() != modGlobalVars.cEmptyString)
										{
											tmpContactName.Append($" {Convert.ToString(grd_MLJournal["contact_last_name"]).Trim()}");
										}
									}
									if (tmpContactName.ToString().Trim() == modGlobalVars.cEmptyString)
									{
										//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
										if (!Convert.IsDBNull(grd_MLJournal["contact_title"]))
										{
											if (Convert.ToString(grd_MLJournal["contact_title"]).Trim() != modGlobalVars.cEmptyString)
											{
												tmpContactName.Append($" {Convert.ToString(grd_MLJournal["contact_title"]).Trim()}");
											}
										}
									}

								}

							} //Not IsNull(ado_tmpRS) And Not (ado_tmpRS.BOF And ado_tmpRS.EOF)

						} //grd_MLJournal("journ_contact_id").Value > 0


						//Date
						grd_MLNotes.CurrentColumnIndex = 0;
						grd_MLNotes.CellAlignment = DataGridViewContentAlignment.TopCenter;
						grd_MLNotes[grd_MLNotes.CurrentRowIndex, grd_MLNotes.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(grd_MLJournal["journ_date"]))
						{
							if (Information.IsDate(grd_MLJournal["journ_date"]) && Convert.ToString(grd_MLJournal["journ_date"]).Trim() != modGlobalVars.cEmptyString)
							{
								grd_MLNotes[grd_MLNotes.CurrentRowIndex, grd_MLNotes.CurrentColumnIndex].Value = Convert.ToDateTime(grd_MLJournal["journ_date"]).ToString("d");
							}
						}

						//User
						grd_MLNotes.CurrentColumnIndex = 1;
						grd_MLNotes.CellAlignment = DataGridViewContentAlignment.TopCenter;
						grd_MLNotes[grd_MLNotes.CurrentRowIndex, grd_MLNotes.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(grd_MLJournal["journ_user_id"]))
						{
							//        If Trim$(grd_MLJournal("journ_user_id").Value) <> cEmptyString Then
							//          grd_MLNotes.Text = Trim$(grd_MLJournal("journ_user_id").Value)
							//        End If
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(grd_MLJournal["user_first_name"]))
							{
								if (Convert.ToString(grd_MLJournal["user_first_name"]).Trim() != modGlobalVars.cEmptyString)
								{
									grd_MLNotes[grd_MLNotes.CurrentRowIndex, grd_MLNotes.CurrentColumnIndex].Value = $"{Convert.ToString(grd_MLJournal["user_first_name"]).Trim()} {Convert.ToString(grd_MLJournal["user_last_name"]).Trim()}";
								}
								else
								{
									if (Convert.ToString(grd_MLJournal["journ_user_id"]).Trim() != modGlobalVars.cEmptyString)
									{
										grd_MLNotes[grd_MLNotes.CurrentRowIndex, grd_MLNotes.CurrentColumnIndex].Value = Convert.ToString(grd_MLJournal["journ_user_id"]).Trim();
									}
									else
									{
										if (Convert.ToString(grd_MLJournal["journ_user_id"]).Trim() == "adm")
										{
											grd_MLNotes[grd_MLNotes.CurrentRowIndex, grd_MLNotes.CurrentColumnIndex].Value = "Admin";
										}
									}
								}
							}
							else
							{
								if (Convert.ToString(grd_MLJournal["journ_user_id"]).Trim() == "adm")
								{
									grd_MLNotes[grd_MLNotes.CurrentRowIndex, grd_MLNotes.CurrentColumnIndex].Value = "Admin";
								}
								else
								{
									if (Convert.ToString(grd_MLJournal["journ_user_id"]).Trim() != modGlobalVars.cEmptyString)
									{
										grd_MLNotes[grd_MLNotes.CurrentRowIndex, grd_MLNotes.CurrentColumnIndex].Value = Convert.ToString(grd_MLJournal["journ_user_id"]).Trim();
									}
								}
							}
						}

						// DISPLAY SUBJECT
						grd_MLNotes.CurrentColumnIndex = 2;
						grd_MLNotes.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						grd_MLNotes[grd_MLNotes.CurrentRowIndex, grd_MLNotes.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
						TempSubject = modGlobalVars.cEmptyString;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(grd_MLJournal["jcat_auto_subject_flag"]))
						{
							if (Convert.ToString(grd_MLJournal["jcat_auto_subject_flag"]).Trim() != modGlobalVars.cEmptyString)
							{
								if (Convert.ToString(grd_MLJournal["jcat_auto_subject_flag"]).Trim().ToUpper() == "Y")
								{

									//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
									if (!Convert.IsDBNull(grd_MLJournal["jcat_subcategory_transtype"]))
									{
										if (Convert.ToString(grd_MLJournal["jcat_subcategory_transtype"]).Trim() != modGlobalVars.cEmptyString)
										{
											TempSubject = $"{Convert.ToString(grd_MLJournal["jcat_subcategory_transtype"]).Trim()} - ";
										}
									}

									//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
									if (!Convert.IsDBNull(grd_MLJournal["journ_subject"]))
									{
										if (Convert.ToString(grd_MLJournal["journ_subject"]).Trim() != modGlobalVars.cEmptyString)
										{
											TempSubject = $"{Convert.ToString(grd_MLJournal["journ_subject"]).Trim()} ";
										}
									}

								}
								else
								{

									//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
									if (!Convert.IsDBNull(grd_MLJournal["journ_subject"]))
									{
										if (Convert.ToString(grd_MLJournal["journ_subject"]).Trim() != modGlobalVars.cEmptyString)
										{
											TempSubject = $"{Convert.ToString(grd_MLJournal["journ_subject"]).Trim()} ";
										}
									}

								} // UCase$(Trim$(grd_MLJournal("jcat_auto_subject_flag").Value)) = "Y"

							}
						}



						// DISPLAY SUBJECT
						grd_MLNotes[grd_MLNotes.CurrentRowIndex, grd_MLNotes.CurrentColumnIndex].Value = TempSubject.Trim();

						// DISPLAY DESCRIPTION
						grd_MLNotes.CurrentColumnIndex = 3;
						grd_MLNotes.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						grd_MLNotes[grd_MLNotes.CurrentRowIndex, grd_MLNotes.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(grd_MLJournal["journ_description"]))
						{
							if (Convert.ToString(grd_MLJournal["journ_description"]).Trim() != modGlobalVars.cEmptyString)
							{
								grd_MLNotes[grd_MLNotes.CurrentRowIndex, grd_MLNotes.CurrentColumnIndex].Value = "X";
							}
						}



						//Type
						grd_MLNotes.CurrentColumnIndex = 4;
						grd_MLNotes.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						grd_MLNotes[grd_MLNotes.CurrentRowIndex, grd_MLNotes.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(grd_MLJournal["journ_subcategory_code"]))
						{
							if (Convert.ToString(grd_MLJournal["journ_subcategory_code"]).Trim() != modGlobalVars.cEmptyString)
							{
								grd_MLNotes[grd_MLNotes.CurrentRowIndex, grd_MLNotes.CurrentColumnIndex].Value = Convert.ToString(grd_MLJournal["journ_subcategory_code"]).Trim();
							}
						}

						//Journal ID
						grd_MLNotes.CurrentColumnIndex = 5;
						grd_MLNotes.CellAlignment = DataGridViewContentAlignment.MiddleRight;
						grd_MLNotes[grd_MLNotes.CurrentRowIndex, grd_MLNotes.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(grd_MLJournal["journ_id"]))
						{
							if (Convert.ToInt32(grd_MLJournal["journ_id"]) > 0)
							{
								grd_MLNotes[grd_MLNotes.CurrentRowIndex, grd_MLNotes.CurrentColumnIndex].Value = Convert.ToString(grd_MLJournal["journ_id"]).Trim();
							}
						}

						grd_MLNotes.set_RowData(grd_MLNotes.CurrentRowIndex, Convert.ToInt32(grd_MLJournal["journ_id"]));

						grd_MLNotes.RowsCount++;
						grd_MLNotes.CurrentRowIndex++;

						grd_MLJournal.MoveNext();

					};

					grd_MLNotes.RowsCount--;
					grd_MLNotes.CurrentRowIndex = 1;

					grd_MLNotes.Enabled = true;

					grd_MLJournal.Close();
					UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(modAdminCommon.LOCAL_ADO_DB, nRememberTimeout);
					//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseServer);
				}
				else
				{

					grd_MLNotes.CurrentRowIndex = 1;
					grd_MLNotes.CurrentColumnIndex = 2;
					grd_MLNotes[grd_MLNotes.CurrentRowIndex, grd_MLNotes.CurrentColumnIndex].Value = "No Journal Entries Found";

					grd_MLNotes.Enabled = false;

				}

				grd_MLNotes.Visible = true;
				grd_MLNotes.Redraw = true;

				grd_MLJournal = null;
				ado_tmpRS = null;
				frame_Note_List.Visible = true;
			}
			catch (System.Exception excep)
			{

				//MsgBox ("Error: " & whereIstheError)
				UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(modAdminCommon.LOCAL_ADO_DB, nRememberTimeout);
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1065
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
				//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseServer);
				//UPGRADE_WARNING: (1068) nReference_CompanyJID of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
				//UPGRADE_WARNING: (1068) nReference_CompanyID of type Variant is being forced to string. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"fill_company_journal_grid_Error ({Information.Err().Number.ToString()}) {excep.Message} CMPID:[{Convert.ToString(nReference_CompanyID)}] JID:[{Convert.ToString(nReference_CompanyJID)}]", "Company (frm_Company)");


				return;
			}

		}

		public void Fill_Mail_List_Options()
		{
			//
			// CREATED: 4/23/2011 - RTW
			// FILLS LIST OF AVAILABLE MAIL LIST ENTRIES TO SELECT FROM
			//
			string Query = "";
			try
			{

				ADORecordSetHelper snp_SelectMLList = null;
				int i = 0;

				Query = "select jcat_subcategory_code,jcat_subcategory_name from journal_category ";
				Query = $"{Query}where jcat_category_code='ML' ";
				Query = $"{Query}order by jcat_subcategory_name ";
				cbo_Mail_List_Selected.Items.Clear();
				snp_SelectMLList = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(snp_SelectMLList.Fields) && !(snp_SelectMLList.BOF && snp_SelectMLList.EOF))
				{

					while(!snp_SelectMLList.EOF)
					{
						cbo_Mail_List_Selected.AddItem($"{Convert.ToString(snp_SelectMLList["jcat_subcategory_code"])}-{Convert.ToString(snp_SelectMLList["jcat_subcategory_name"])}");
						snp_SelectMLList.MoveNext();
					};
					snp_SelectMLList.Close();
				}

				cbo_Mail_List_Selected.Enabled = true;
				snp_SelectMLList = null;
			}
			catch
			{
				MessageBox.Show($"Fill_Mail_List_Options Error: Error list of mail lists into combo box: {Query}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
		}
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}