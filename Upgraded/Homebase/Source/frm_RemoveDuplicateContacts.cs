using Microsoft.VisualBasic;
using System;
using System.Data.Common;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Gui.Controls;
using UpgradeHelpers.Helpers;

namespace JETNET_Homebase
{
	internal partial class frm_RemoveDuplicateContacts
		: System.Windows.Forms.Form
	{

		public frm_RemoveDuplicateContacts()
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


		private void frm_RemoveDuplicateContacts_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		//******************************************************************************************
		//***** VB Compress Pro 6.11.32 generated this copy of frm_RemoveDuplicateContacts.frm on Mo
		//***** Mode: AutoSelect Standard Mode (Internal References Only)***************************
		//******************************************************************************************



		//==================
		// Public Variables
		//==================
		public int PassedContactID = 0;
		public int PassedCompanyID = 0;

		private void GetOtherContacts()
		{

			string Query = "";
			ADORecordSetHelper snpOther = new ADORecordSetHelper(); //8/1/05 aey converted to ado
			string strAdd = "";

			try
			{

				strAdd = "open RS";

				Query = "SELECT contact_id, contact_first_name, contact_last_name, contact_title ";
				Query = $"{Query}FROM Contact WITH(NOLOCK) ";
				Query = $"{Query}WHERE contact_comp_id = {PassedCompanyID.ToString()}";
				Query = $"{Query} AND contact_id <> {PassedContactID.ToString()}";
				// Query = Query & " AND contact_active_flag = 'Y'"
				Query = $"{Query} AND contact_journ_id = 0";

				//Set snpOther = LOCAL_DB.OpenRecordset(Query, dbOpenSnapshot, dbSQLPassThrough)
				snpOther.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpOther.BOF && snpOther.EOF))
				{
					snpOther.MoveFirst();
					lstOtherContacts.Items.Clear();

					while(!snpOther.EOF)
					{
						strAdd = ($"{Convert.ToString(snpOther["contact_first_name"])}").Trim();
						strAdd = $"{strAdd} {($"{Convert.ToString(snpOther["contact_last_name"])}").Trim()}";
						strAdd = $"{strAdd} ({($"{Convert.ToString(snpOther["contact_title"])}").Trim()})";

						lstOtherContacts.AddItem(strAdd);
						lstOtherContacts.SetItemData(lstOtherContacts.Items.Count - 1, Convert.ToInt32(Double.Parse(($"{Convert.ToString(snpOther["contact_id"])}").Trim())));
						snpOther.MoveNext();
					};
				}

				snpOther.Close();
				snpOther = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"GetOtherContacts_Error: {excep.Message} {strAdd}", "Remove_Dups");
				this.Cursor = CursorHelper.CursorDefault;
			}

		}

		private void cmdClose_Click(Object eventSender, EventArgs eventArgs) => this.Close();


		private void cmdRemoveDups_Click(Object eventSender, EventArgs eventArgs)
		{

			int lContactId1 = 0;
			int lContactId2 = 0;
			int lCompId = 0;
			int lCRId = 0;
			string strCRId = "";
			if (MessageBox.Show("Are you sure you want to remove this duplicate contact?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
			{

				lCompId = PassedCompanyID;
				lContactId1 = PassedContactID;
				lContactId2 = lstOtherContacts.GetItemData(ListBoxHelper.GetSelectedIndex(lstOtherContacts));

				// 03/17/2014 - By David D. Cruger
				// Can NOT Remove Duplicate Contact If
				// There is a Contact Relationship

				strCRId = modCommon.DLookUp("cr_id", "Contact_Reference", $"(cr_contact_id = {lContactId2.ToString()}) OR (cr_contact_rel_id = {lContactId2.ToString()}) ");

				if (strCRId == "")
				{

					this.Cursor = Cursors.WaitCursor;
					modAdminCommon.ADO_Transaction("BeginTrans");
					modCommon.Combine_Contact(lCompId, lContactId2, lContactId1);
					modAdminCommon.ADO_Transaction("CommitTrans");
					modCommon.Remove_Duplicate_Phone_Numbers(lCompId, lContactId1);
					this.Cursor = CursorHelper.CursorDefault;

				}
				else
				{
					MessageBox.Show($"Can NOT Remove Contact{Environment.NewLine}{lstOtherContacts.GetListItem(ListBoxHelper.GetSelectedIndex(lstOtherContacts))} Has A Contact Relationship", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If strCRId = "" Then

				Application.DoEvents();

				cmdClose_Click(cmdClose, new EventArgs());

			} // If MsgBox("Are you sure you want to remove this duplicate contact?", vbYesNo) = vbYes Then

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
		private void Form_Load()
		{

			//Call CenterForm32(Me)
			modCommon.CenterFormOnHomebaseMainForm(this);
			modCommon.Build_Contact_Info(lstContact, PassedContactID, 0);
			GetOtherContacts();

		}

		private void lstOtherContacts_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{

			if (ListBoxHelper.GetSelectedIndex(lstOtherContacts) >= 0)
			{
				cmdRemoveDups.Enabled = true;
			}

		}
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}