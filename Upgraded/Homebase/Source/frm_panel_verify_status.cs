using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
using System;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Gui;
using UpgradeHelpers.Gui.Controls;
using UpgradeHelpers.Helpers;
using UpgradeStubs;

namespace JETNET_Homebase
{
	internal partial class frm_verify_status
		: System.Windows.Forms.Form
	{

		public frm_verify_status()
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


		private void frm_verify_status_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}

		public int nReference_CompanyJID = 0;
		public int nReference_CompanyID = 0;

		public int nSelectedAircraftID = 0;
		public string strSelectedAircraft = "";

		public int nSelectedYachtID = 0;
		public string strSelectedYacht = "";

		public int nSelectedContactID = 0;
		public string strSelectedContact = "";

		public int nSelVerifyJournSub = 0;
		public int nSelVerifyAircraft = 0;
		private string[] arrConfirmAircraft = null;


		public string sVerifyAircraftStatus = "";
		public string form_company_name = "";
		public string picked_contact_name = "";
		public string current_status = "";



		public void display_verify_aircraft_status_pnl_form(Form temp_form, string in_sVerifyWhat, int nReference_CompanyID, int nReference_CompanyJID, int nSelectedContactID, UpgradeHelpers.DataGridViewFlex grd_Company_Aircraft, string[] arrConfirmAircraft_temp)
		{

			arrConfirmAircraft = arrConfirmAircraft_temp;


			try
			{

				//UPGRADE_ISSUE: (2064) Threed.SSPanel property pnl_verify_aircraft_status.Caption was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				pnl_verify_aircraft_status.setCaption("Verify Aircraft Status:");
				pnl_verify_aircraft_status.Visible = true;
				//UPGRADE_WARNING: (2065) Threed.SSPanel method pnl_verify_aircraft_status.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
				Support.ZOrder(pnl_verify_aircraft_status, 0);

				frame_verify_pnl.Visible = false;

				cbo_verify_journal_subject.Visible = false;
				cbo_verify_aircraft.Visible = false;
				cbo_verify_note_type.Visible = false;

				chk_verify_contact.Visible = false;
				chk_verify_contact.CheckState = CheckState.Checked;

				opt_verify_aircraft[modGlobalVars.opt_verify_ac_NONE].Visible = false;
				opt_verify_aircraft[modGlobalVars.opt_verify_ac_ONE].Visible = false;
				opt_verify_aircraft[modGlobalVars.opt_verify_ac_ALL].Visible = false;
				opt_verify_aircraft[modGlobalVars.opt_verify_ac_PRIMARY].Visible = false;

				Shape1[0].Visible = false;
				Shape1[2].Visible = false;

				Shape1[1].Visible = true;

				int RememberCol = 0;
				int RememberRow = 0;
				string Tname = "";
				Tname = modGlobalVars.cEmptyString;


				sVerifyAircraftStatus = in_sVerifyWhat.ToUpper();

				fill_verify_contact_list(nReference_CompanyID, nReference_CompanyJID, nSelectedContactID, cbo_verify_other_contacts);


				string temp_text = "";
				if (sVerifyAircraftStatus == ("One").ToUpper())
				{



					if (ColorTranslator.ToOle(grd_Company_Aircraft.CellBackColor).ToString() == modAdminCommon.ExclusiveColor)
					{

						Tname = $"Verify Exclusive Status of {grd_Company_Aircraft[grd_Company_Aircraft.CurrentRowIndex, grd_Company_Aircraft.CurrentColumnIndex].FormattedValue.ToString().Trim()} on: {DateTime.Now.ToString()}";
						lbl_verify_text_label[75].Text = Tname.Trim();
					}
					else if (ColorTranslator.ToOle(grd_Company_Aircraft.CellBackColor).ToString() == modAdminCommon.PrimaryColor)
					{ 

						Tname = $"Verify Status of {grd_Company_Aircraft[grd_Company_Aircraft.CurrentRowIndex, grd_Company_Aircraft.CurrentColumnIndex].FormattedValue.ToString().Trim()} as ";
						Tname = $"{Tname}{current_status.Trim()} on: {DateTime.Now.ToString()}";
						lbl_verify_text_label[75].Text = Tname.Trim();
					}
					else
					{
						// ADDED IN FOR ADDING A NEW NOTE
						grd_Company_Aircraft.CurrentColumnIndex = 1;
						temp_text = grd_Company_Aircraft[grd_Company_Aircraft.CurrentRowIndex, grd_Company_Aircraft.CurrentColumnIndex].FormattedValue.ToString();

						if (temp_text.Trim() == "Non-Exclusive Sales Contact" || temp_text.Trim() == "Sales Company/Contact")
						{
							Tname = $"Verify Status as {grd_Company_Aircraft[grd_Company_Aircraft.CurrentRowIndex, grd_Company_Aircraft.CurrentColumnIndex].FormattedValue.ToString().Trim()}";
						}

						lbl_verify_text_label[75].Text = Tname.Trim();

					}


				}

				modSubscription.search_off();

				cbo_verify_other_contacts.Refresh();
				cbo_verify_other_contacts.Focus();
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"display_verify_aircraft_status_pnl_Error ({Information.Err().Number.ToString()}) {excep.Message} CMPID:[{nReference_CompanyID.ToString()}] JID:[{nReference_CompanyJID.ToString()}]", "Company (frm_Company)");
				return;
			}

		}


		public void fill_verify_contact_list(int in_CompanyID, int in_JournalID, int in_verify_contactID, ComboBox cbo_to_fill)
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
				Query = $"{Query} AND contact_journ_id = {in_JournalID.ToString()} AND contact_active_flag = 'Y'";
				Query = $"{Query} ORDER BY contact_first_name, contact_last_name , contact_middle_initial";

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



		private void cbo_verify_other_contacts_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs)
		{


			frm_CompanyContact new_frm_CompanyContact = frm_CompanyContact.CreateInstance();



			if (cbo_verify_other_contacts.GetItemData(cbo_verify_other_contacts.SelectedIndex) == 0)
			{ // selected add new contact

				new_frm_CompanyContact.nContactID = -1;
				new_frm_CompanyContact.nJournID = nReference_CompanyJID;
				new_frm_CompanyContact.nCompanyID = nReference_CompanyID;
				new_frm_CompanyContact.CompanyName_Renamed = modCommon.GetCompanyName(nReference_CompanyID, nReference_CompanyJID);
				new_frm_CompanyContact.ServicesUsed = modCommon.GetCompanyServiceName(nReference_CompanyID, nReference_CompanyJID, modGlobalVars.ServicesUsed_Array);

				new_frm_CompanyContact.Top = Convert.ToInt32(mdi_ResearchAssistant.DefInstance.Top + ((mdi_ResearchAssistant.DefInstance.Height - new_frm_CompanyContact.Height) / 2d));
				new_frm_CompanyContact.Left = Convert.ToInt32(mdi_ResearchAssistant.DefInstance.Left + ((mdi_ResearchAssistant.DefInstance.Width - new_frm_CompanyContact.Width) / 2d)); // mdi_ResearchAssistant

				new_frm_CompanyContact.ShowDialog();

				fill_verify_contact_list(nReference_CompanyID, nReference_CompanyJID, nSelectedContactID, cbo_verify_other_contacts);

				new_frm_CompanyContact = null;
			}
			else
			{
				picked_contact_name = "Y";
			}


		}

		private void cbo_verify_other_contacts_KeyDown(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{

				picked_contact_name = "N";
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}

		}


		private void cmd_verify_status_cancel_Click(Object eventSender, EventArgs eventArgs) => frm_verify_status.DefInstance.Hide();


		private void cmd_verify_status_save_Click(Object eventSender, EventArgs eventArgs)
		{
			bool mvHasFocus = false;

			int nContact_ID = 0;
			int nAircraft_ID = 0;
			int yacht_id = 0;
			string strOwner = "";
			string marketing_note = "";
			int spot1 = 0;
			string strJournalSubject = "";

			try
			{


				if (picked_contact_name == "N")
				{
					//UPGRADE_ISSUE: (1046) MsgBox Parameter 'context' is not supported, and was removed. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-1046
					//UPGRADE_ISSUE: (1046) MsgBox Parameter 'helpfile' is not supported, and was removed. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-1046
					Interaction.MsgBox("Please Make Sure You Select a Contact.", MsgBoxStyle.OkCancel, "");
				}
				else
				{

					// ENSURE THAT THE USER HAS SELECTED A CONTACT BEFORE VERIFYING STATUS
					if (cbo_verify_other_contacts.SelectedIndex == -1 && chk_verify_contact.CheckState == CheckState.Checked)
					{
						if (sVerifyAircraftStatus.Trim().ToUpper() == "NOTE")
						{
							MessageBox.Show("You must select a contact for this note", "Company : Insert Research Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
						else
						{
							MessageBox.Show("Verify Aircraft Status By CONTACT is blank", "Company : Verify Aircraft Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
						}

						cbo_verify_other_contacts.Focus();

						return;

					}

					// ENSURE THAT THE USER HAS ENTERED A JOURNAL NOTE BEFORE VERIFYING STATUS
					if (sVerifyAircraftStatus.Trim().ToUpper() == "NOTE")
					{
						if (cbo_verify_note_type.Text.StartsWith("iQ", StringComparison.Ordinal))
						{
							strJournalSubject = cbo_verify_journal_auto_subject.Text.Trim();
							if (strJournalSubject == modGlobalVars.cEmptyString)
							{
								MessageBox.Show("You cannot add a blank note!", "Company : Insert Research Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
								cbo_verify_journal_auto_subject.Focus();
								return;
							}
						}
						else
						{
							strJournalSubject = cbo_verify_journal_subject.Text.Trim();
							if (strJournalSubject == modGlobalVars.cEmptyString)
							{
								MessageBox.Show("You cannot add a blank note!", "Company : Insert Research Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
								cbo_verify_journal_subject.Focus();
								return;
							}
						}
					}

					// set contact ID to zero(0) if we don't have a verify contact
					if (cbo_verify_other_contacts.SelectedIndex == -1 && chk_verify_contact.CheckState == CheckState.Unchecked)
					{
						nContact_ID = 0;
					}
					else
					{
						nContact_ID = cbo_verify_other_contacts.GetItemData(cbo_verify_other_contacts.SelectedIndex);
					}

					if (chk_verify_contact.CheckState == CheckState.Unchecked)
					{
						nContact_ID = 0;
					}
					else
					{
						nContact_ID = cbo_verify_other_contacts.GetItemData(cbo_verify_other_contacts.SelectedIndex);
					}


					if (sVerifyAircraftStatus.Trim().ToUpper() == ("Note").ToUpper())
					{

						if (!cbo_verify_aircraft.Visible)
						{ // cbo_verify_aircraft.ListIndex = -1 And
							if (cbo_yachts.Visible)
							{
								spot1 = (cbo_yachts.Text.IndexOf(" -") + 1);
								yacht_id = Convert.ToInt32(Double.Parse(cbo_yachts.Text.Substring(0, Math.Min(spot1 - 1, cbo_yachts.Text.Length))));
							}
							nAircraft_ID = 0;
						}
						else
						{
							yacht_id = 0;
							nAircraft_ID = cbo_verify_aircraft.GetItemData(cbo_verify_aircraft.SelectedIndex);
						}
					}
					else if (sVerifyAircraftStatus.Trim().ToUpper() == ("One").ToUpper())
					{ 
						nAircraft_ID = nSelectedAircraftID;

						// check and  see who has this aircraft record locked - if anyone
						strOwner = modCommon.AircraftLocked(nAircraft_ID, nReference_CompanyJID).ToLower();

						//If someone has this locked who is not "me" then say so
						if (strOwner != "false" && strOwner != modAdminCommon.gbl_User_ID.ToLower())
						{
							MessageBox.Show($"Aircraft locked: AC ID: {nAircraft_ID.ToString()} by {strOwner}", "Company : Verify Aircraft Status", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							return;
						} //Not (strOwner = "False") And Not (strOwner = LCase$(gbl_User_ID))

					}

					if (sVerifyAircraftStatus.Trim().ToUpper() == ("Note").ToUpper())
					{
						modSubscription.search_on("Adding Company Journal Note....");
					}
					else
					{
						modSubscription.search_on("Verifing Aircraft Status....");
					}

					if (txt_marketing_notes.Text.Trim() != "")
					{
						marketing_note = $"|| {StringsHelper.Replace(txt_marketing_notes.Text.Trim(), "'", "", 1, -1, CompareMethod.Binary)}";
					}

					string tempRefParam = $"{strJournalSubject}{marketing_note}";
					if (modCompany.verify_aircraft_status(nReference_CompanyID, nAircraft_ID, nContact_ID, nReference_CompanyJID, ref tempRefParam, cbo_verify_note_type.Text.Trim(), cbo_verify_other_contacts, cbo_verify_aircraft, nSelVerifyJournSub, nSelVerifyAircraft, grd_Company_Aircraft, ref arrConfirmAircraft, sVerifyAircraftStatus, yacht_id, cbo_yachts.Text, "", txt_description.Text))
					{



						if (nReference_CompanyJID == 0 && sVerifyAircraftStatus.Trim().ToUpper() != ("Note").ToUpper())
						{

							cmd_company_update_callback_date_Click();

							//update the company contact_date if any of the aircraft have been verified
							if (lbl_comp[11].Text.Trim() != "")
							{
								if (Information.IsDate(lbl_comp[11].Text.Trim()))
								{
									if (DateTime.Parse(DateTimeHelper.ToString(DateTime.Now)) != DateTime.Parse(lbl_comp[11].Text.Trim()))
									{
										update_last_contact_date(false);
									}
								}
								else
								{
									update_last_contact_date(false);
								} //IsDate(Trim$(lbl_comp(LAST_CALLED_INDEX).Caption))
							} //Trim$(lbl_comp(LAST_CALLED_INDEX).Caption) <> ""

						} //nReference_CompanyJID = 0

					} // modCompany.Verify_Aircraft_Status

					Application.DoEvents();
					cbo_yachts.Items.Clear();

					Application.DoEvents();

					Application.DoEvents();
					frm_verify_status.DefInstance.Hide();
					Application.DoEvents();
				}
			}
			catch (System.Exception excep)
			{

				if (mvHasFocus)
				{
					mvHasFocus = false;
				}

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"cmd_verify_status_save_Click_Error ({Information.Err().Number.ToString()}) {excep.Message} CMPID:[{nReference_CompanyID.ToString()}] JID:[{nReference_CompanyJID.ToString()}]", "Company (frm_Company)");
				modSubscription.search_off();
				return;
			}

		}


		private void cmd_verify_yacht_Click(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.cmd_verify_yacht, eventSender);
			dynamic cbo_comp_account_id = null;//gap-note this combo belongs to a different form which apparently is obsolete. Double check 
			dynamic frm_Company = null;//gap-note seems this property uses frmYacht which apparently is obsolete. Double check
			dynamic grd_company_yachts = null; //gap-note this grid belongs to frmYacht which apparently is obsolete. Double check 

			string strToday = DateTime.Now.ToString("d");
			string[] subjects = null;
			int[] yacht_id = new int[901];
			int last_yacht_id = 0;
			int yacht_id_spot = 0;
			int last_spot = 0;
			int Current_Row = 0;
			string subject1 = "";
			int contact_id = 0;


			cmd_verify_yacht[2].Tag = "";


			if (Index == 0)
			{
				//UPGRADE_TODO: (1067) Member RowSel is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				//UPGRADE_TODO: (1067) Member RowData is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				//UPGRADE_TODO: (1067) Member set_yacht_verify_date is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				frm_Company.set_yacht_verify_date(grd_company_yachts.RowData(grd_company_yachts.RowSel));
			}
			else if (Index == 1)
			{ 

				//UPGRADE_TODO: (1067) Member Rows is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				double tempForEndVar = Convert.ToDouble(grd_company_yachts.Rows) - 1;
				for (int i = 1; i <= tempForEndVar; i++)
				{
					//if the yacht id has changed
					//UPGRADE_TODO: (1067) Member Row is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					grd_company_yachts.Row = i;
					//UPGRADE_TODO: (1067) Member Col is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					grd_company_yachts.Col = 8;

					//UPGRADE_TODO: (1067) Member CellBackColor is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					if (Convert.ToString(grd_company_yachts.CellBackColor).Trim() == modAdminCommon.PrimaryColor.Trim())
					{
						//UPGRADE_TODO: (1067) Member RowData is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						if (last_yacht_id != Convert.ToDouble(grd_company_yachts.RowData(i)))
						{
							//UPGRADE_TODO: (1067) Member RowData is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
							//UPGRADE_TODO: (1067) Member set_yacht_verify_date is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
							frm_Company.set_yacht_verify_date(grd_company_yachts.RowData(i));
						}
						//UPGRADE_TODO: (1067) Member RowData is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						last_yacht_id = Convert.ToInt32(grd_company_yachts.RowData(i));
					}



				}


			}
			else if (Index == 2)
			{ 
				//----------- THIS IS A DUMMIED IN VERSION SO THAT YACHT PEOPLE CAN HAVE SPECIALIZED VERIFY NOTES---------------
				//---------------------------JOURNAL NOTE---------------------
				cmd_verify_status_save.Visible = true;
				subjects = lbl_comp[49].Text.Split(new string[]{"XXX"}, StringSplitOptions.None);


				//UPGRADE_TODO: (1067) Member Rows is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				double tempForEndVar2 = Convert.ToDouble(grd_company_yachts.Rows) - 1;
				for (int i = 1; i <= tempForEndVar2; i++)
				{
					//UPGRADE_TODO: (1067) Member RowData is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					if (last_yacht_id != Convert.ToDouble(grd_company_yachts.RowData(i)))
					{
						//UPGRADE_TODO: (1067) Member RowData is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						yacht_id[yacht_id_spot] = Convert.ToInt32(grd_company_yachts.RowData(i));
						yacht_id_spot++;
					}
					//UPGRADE_TODO: (1067) Member RowData is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					last_yacht_id = Convert.ToInt32(grd_company_yachts.RowData(i));
				}

				yacht_id_spot = 0;
				Current_Row = 0;
				int tempForEndVar3 = subjects.GetUpperBound(0) - 1;
				for (int i = 0; i <= tempForEndVar3; i++)
				{
					// subject1 = Replace(subjects(i), "XCONTACTX", cbo_verify_other_contacts.Text)
					subject1 = StringsHelper.Replace(subjects[i], " -> XCONTACTX", "", 1, -1, CompareMethod.Binary);

					if (cbo_verify_other_contacts.GetItemData(cbo_verify_other_contacts.SelectedIndex) != 0)
					{
						contact_id = cbo_verify_other_contacts.GetItemData(cbo_verify_other_contacts.SelectedIndex);
					}


					modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(strToday.Trim());
					modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "VS";
					modAdminCommon.Rec_Journal_Info.journ_subject = subject1;
					modAdminCommon.Rec_Journal_Info.journ_description = modGlobalVars.cEmptyString;
					modAdminCommon.Rec_Journal_Info.journ_ac_id = 0;
					modAdminCommon.Rec_Journal_Info.journ_comp_id = nReference_CompanyID;
					modAdminCommon.Rec_Journal_Info.journ_contact_id = contact_id;
					//UPGRADE_TODO: (1067) Member Text is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					modAdminCommon.Rec_Journal_Info.journ_account_id = Convert.ToString(cbo_comp_account_id.Text).Trim();
					modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
					modAdminCommon.Rec_Journal_Info.journ_status = "A";

					if (subjects.GetUpperBound(0) == 1)
					{ // then you are only verifying one
						//UPGRADE_TODO: (1067) Member RowSel is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						//UPGRADE_TODO: (1067) Member RowData is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						modAdminCommon.Rec_Journal_Info.journ_yacht_id = Convert.ToInt32(grd_company_yachts.RowData(grd_company_yachts.RowSel));
					}
					else
					{

						//UPGRADE_TODO: (1067) Member Row is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						grd_company_yachts.Row = Current_Row;
						//UPGRADE_TODO: (1067) Member Col is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						grd_company_yachts.Col = 8;

						for (int X = 0; X <= 10; X++)
						{
							//UPGRADE_TODO: (1067) Member Row is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
							grd_company_yachts.Row = Current_Row;
							//UPGRADE_TODO: (1067) Member CellBackColor is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
							if (Convert.ToString(grd_company_yachts.CellBackColor) != modAdminCommon.PrimaryColor)
							{
								Current_Row++;
							}
						}

						//UPGRADE_TODO: (1067) Member RowData is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						modAdminCommon.Rec_Journal_Info.journ_yacht_id = Convert.ToInt32(grd_company_yachts.RowData(Current_Row));


						Current_Row++;
					}


					frm_Journal.DefInstance.Commit_Journal_Entry();
				}

				//---------------------------JOURNAL NOTE-----------------------
				lbl_comp[49].Text = "Add Note:";
				pnl_verify_aircraft_status.Visible = false;
				cmd_verify_yacht[2].Visible = false;

			}


		}


		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
		private void Form_Load() => modFillCompConControls.fill_journ_subject_List(cbo_verify_journal_subject);


		private bool isInitializingComponent;
		private void opt_journal_subject_CheckedChanged(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.opt_journal_subject, eventSender);
			if (((RadioButton) eventSender).Checked)
			{
				if (isInitializingComponent)
				{
					return;
				}
				int bIsFormLoad = 0;

				cbo_verify_journal_subject.Visible = true;
				cbo_verify_journal_auto_subject.Visible = false;
				cbo_verify_journal_auto_subject.Text = "";

				if (~bIsFormLoad != 0)
				{
					if (Index != 3)
					{ //7/9/04 aey
						cbo_verify_journal_subject.SelectedIndex = Index;
					}
					else
					{
						cbo_verify_journal_subject.SelectedIndex = -1;
					}

					nSelVerifyJournSub = -1;


					switch(Index)
					{
						case modGlobalVars.opt_journ_subj_SHARES : 
							nSelVerifyJournSub = modGlobalVars.opt_journ_subj_SHARES; 
							break;
						case modGlobalVars.opt_journ_subj_LETTER : 
							nSelVerifyJournSub = modGlobalVars.opt_journ_subj_LETTER; 
							break;
						case modGlobalVars.opt_journ_subj_MESSAGE : 
							nSelVerifyJournSub = modGlobalVars.opt_journ_subj_MESSAGE; 
							break;
						case modGlobalVars.opt_journ_subj_CUSTOM : 
							nSelVerifyJournSub = modGlobalVars.opt_journ_subj_CUSTOM; 
							break;
					}

				}




			}
		}
		private void cmd_company_update_callback_date_Click()
		{
			bool mvHasFocus = false;
			string Query = "";
			ADORecordSetHelper adoPrimaryCallback = null;

			try
			{

				if (nReference_CompanyID > 0)
				{

					modSubscription.search_on("Updating Company Callback Date....");

					Query = $"EXEC HomebaseUpdateCompanyCallbackDate {nReference_CompanyID.ToString()}";

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

					modAdminCommon.ADO_Transaction("CommitTrans");


				}

				modSubscription.search_off();

				if (mvHasFocus)
				{
					mvHasFocus = false;
				}
			}
			catch (System.Exception excep)
			{

				if (mvHasFocus)
				{
					mvHasFocus = false;
				}

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"cmd_company_update_callback_date_Click_Error ({Information.Err().Number.ToString()}) {excep.Message} CMPID:[{nReference_CompanyID.ToString()}] JID:[{nReference_CompanyJID.ToString()}]", "Company (frm_Company)");
				modAdminCommon.ADO_Transaction("RollbackTrans");
				modSubscription.search_off();
				return;
			}

		}
		public bool update_last_contact_date(bool bAddJournalEntry)
		{
			dynamic cbo_comp_account_id = null;//gap-note this combo belongs to a different form which apparently is obsolete. Double check 

			string Query = "";
			string strToday = DateTime.Now.ToString("d");

			try
			{

				Query = $"UPDATE Company SET comp_last_contact_date = '{strToday.Trim()}'";
				Query = $"{Query} WHERE comp_id = {nReference_CompanyID.ToString()} AND comp_journ_id = {nReference_CompanyJID.ToString()}";

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


				if (bAddJournalEntry)
				{
					modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(strToday.Trim());
					modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "RN";
					modAdminCommon.Rec_Journal_Info.journ_subject = "Attempted to Contact";
					modAdminCommon.Rec_Journal_Info.journ_description = modGlobalVars.cEmptyString;
					modAdminCommon.Rec_Journal_Info.journ_ac_id = 0;
					modAdminCommon.Rec_Journal_Info.journ_comp_id = nReference_CompanyID;
					modAdminCommon.Rec_Journal_Info.journ_contact_id = 0;
					//UPGRADE_TODO: (1067) Member Text is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					modAdminCommon.Rec_Journal_Info.journ_account_id = Convert.ToString(cbo_comp_account_id.Text).Trim();
					modAdminCommon.Rec_Journal_Info.journ_prior_account_id = modGlobalVars.cEmptyString;
					modAdminCommon.Rec_Journal_Info.journ_status = "A";

					frm_Journal.DefInstance.Commit_Journal_Entry();
				}

				modAdminCommon.ADO_Transaction("CommitTrans");
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"update_last_contact_date_Error ({Information.Err().Number.ToString()}) {excep.Message} CMPID:[{nReference_CompanyID.ToString()}] JID:[{nReference_CompanyJID.ToString()}]", "Company (frm_Company)");
				modAdminCommon.ADO_Transaction("RollbackTrans");
				return false;
			}

			return false;
		}
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}