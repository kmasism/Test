using Microsoft.VisualBasic;
using System;
using System.Data.Common;
using System.Diagnostics;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Gui.Utils;
using UpgradeHelpers.Helpers;

namespace JETNET_Homebase
{
	internal partial class frm_Info
		: System.Windows.Forms.Form
	{


		private bool gbReSizing = false;
		private int glWidthDiff = 0;
		private int glHeightDiff = 0;
		public int ACID = 0;
		public frm_Info()
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


		public void SetFormCaption(string strCaption)
		{

			if (strCaption != "")
			{
				this.Text = strCaption;
			}

		}

		public void SetTextEnabled(bool bValue) => txtInfo.Enabled = bValue;


		public void SetText(string strText) => txtInfo.Text = strText;


		private void cmd_show_all_Click(Object eventSender, EventArgs eventArgs)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			ADORecordSetHelper rstRec2 = new ADORecordSetHelper();
			string strQuery2 = "";
			int lACId = 0;
			int lCompId = 0;
			int lContactId = 0;



			string strText = "";


			string strQuery1 = "SELECT ";
			strQuery1 = $"{strQuery1}A1.ac_id As ACId, AM1.amod_make_name As Make, AM1.amod_model_name As Model, ";
			strQuery1 = $"{strQuery1}A1.ac_ser_no_full As SerNbr,  A1.ac_reg_no As RegNbr, ";
			strQuery1 = $"{strQuery1}C1.comp_id As CompId, C1.comp_name As Company, ";
			strQuery1 = $"{strQuery1}C1.comp_address1 As Address1, C1.comp_address2 As Address2, ";
			strQuery1 = $"{strQuery1}C1.comp_city As City,  C1.comp_State As StateCode,  C1.comp_Country As Country, ";
			strQuery1 = $"{strQuery1}AR1.cref_contact_type As ContactType, ";
			strQuery1 = $"{strQuery1}ACT1.actype_name As ContactTypeName, AR1.cref_contact_id As ContactId, ";
			strQuery1 = $"{strQuery1}dbo.CreateContactFullNameTitle(CT1.contact_sirname, CT1.contact_first_name, CT1.contact_middle_initial, CT1.contact_last_name, CT1.contact_suffix, '') As ContactName, ";
			strQuery1 = $"{strQuery1}CT1.contact_title As ContactTitle ";

			strQuery1 = $"{strQuery1}FROM Aircraft_Model AS AM1 WITH (NOLOCK) ";
			strQuery1 = $"{strQuery1}INNER JOIN Aircraft AS A1 WITH (NOLOCK) ON A1.ac_amod_id = AM1.amod_id ";
			strQuery1 = $"{strQuery1}INNER JOIN Aircraft_Reference AS AR1 WITH (NOLOCK) ON AR1.cref_ac_id = A1.ac_id AND AR1.cref_journ_id = A1.ac_journ_id ";
			strQuery1 = $"{strQuery1}INNER JOIN Aircraft_Contact_Type AS ACT1 WITH (NOLOCK) ON ACT1.actype_code = AR1.cref_contact_type ";
			strQuery1 = $"{strQuery1}INNER JOIN Company AS C1 WITH (NOLOCK) ON C1.comp_id = AR1.cref_comp_id AND C1.comp_journ_id = AR1.cref_journ_id ";
			strQuery1 = $"{strQuery1}LEFT OUTER JOIN Contact AS CT1 WITH (NOLOCK) ON CT1.contact_id = AR1.cref_contact_id AND CT1.contact_journ_id = AR1.cref_journ_id ";
			strQuery1 = $"{strQuery1}WHERE (AR1.cref_ac_id = {ACID.ToString()}) ";
			strQuery1 = $"{strQuery1}AND (AR1.cref_journ_id = 0) ";

			strQuery1 = $"{strQuery1}ORDER BY AR1.cref_transmit_seq_no ";

			rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

			if (!rstRec1.BOF && !rstRec1.EOF)
			{

				//------------------------------------
				//-- Display Aircraft Information

				strText = $"{strText}ACID: {Convert.ToString(rstRec1["ACID"])}{Environment.NewLine}";
				strText = $"{strText}Make: {($"{Convert.ToString(rstRec1["make"])} ").Trim()}{Environment.NewLine}";
				strText = $"{strText}Model: {($"{Convert.ToString(rstRec1["model"])} ").Trim()}{Environment.NewLine}";
				strText = $"{strText}SerNbr: {($"{Convert.ToString(rstRec1["SerNbr"])} ").Trim()}{Environment.NewLine}";
				strText = $"{strText}RegNbr: {($"{Convert.ToString(rstRec1["RegNbr"])} ").Trim()}{Environment.NewLine}";
				strText = $"{strText}{new string('-', 50)}{Environment.NewLine}{Environment.NewLine}";

				do 
				{ // Loop Until rstRec1.EOF = True

					lCompId = Convert.ToInt32(rstRec1["CompID"]);
					lContactId = Convert.ToInt32(rstRec1["ContactId"]);

					//------------------------------------
					//-- Display Company Information

					strText = $"{strText}CompId: {Convert.ToString(rstRec1["CompID"])}{Environment.NewLine}";
					strText = $"{strText}{($"{Convert.ToString(rstRec1["ContactType"])} ").Trim()} - {($"{Convert.ToString(rstRec1["ContactTypeName"])} ").Trim()}{Environment.NewLine}";
					strText = $"{strText}{($"{Convert.ToString(rstRec1["Company"])} ").Trim()}{Environment.NewLine}";
					strText = $"{strText}{($"{Convert.ToString(rstRec1["Address1"])} ").Trim()}{Environment.NewLine}";
					if (($"{Convert.ToString(rstRec1["Address2"])} ").Trim() != "")
					{
						strText = $"{strText}{($"{Convert.ToString(rstRec1["Address2"])} ").Trim()}{Environment.NewLine}";
					}
					strText = $"{strText}{($"{Convert.ToString(rstRec1["city"])} ").Trim()}, {($"{Convert.ToString(rstRec1["StateCode"])} ").Trim()} {($"{Convert.ToString(rstRec1["country"])} ").Trim()}{Environment.NewLine}";

					//--------------------------------------
					//-- Company Phone Numbers

					strQuery2 = "SELECT * FROM Phone_Numbers WITH (NOLOCK) ";
					strQuery2 = $"{strQuery2}INNER JOIN Phone_Type WITH (NOLOCK) ON ptype_name = pnum_type ";
					strQuery2 = $"{strQuery2}WHERE (pnum_comp_id = {lCompId.ToString()}) ";
					strQuery2 = $"{strQuery2}AND (pnum_journ_id = 0) AND (pnum_contact_id = 0) ";
					strQuery2 = $"{strQuery2}AND (pnum_number_full IS NOT NULL)  AND (pnum_number_full <> '') ";
					strQuery2 = $"{strQuery2}ORDER BY ptype_seq_no ";

					rstRec2.Open(strQuery2, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
					if (!rstRec2.BOF && !rstRec2.EOF)
					{
						do 
						{ // Loop Until rstRec2.EOF = True
							strText = $"{strText}{($"{Convert.ToString(rstRec2["pnum_type"])} ").Trim()}: {($"{Convert.ToString(rstRec2["pnum_number_full"])} ").Trim()}{Environment.NewLine}";
							rstRec2.MoveNext();
						}
						while(!rstRec2.EOF);
					} // If rstRec2.BOF = False And rstRec2.EOF = False Then
					rstRec2.Close();

					//------------------------------------
					//-- Display Contact Information

					if (($"{Convert.ToString(rstRec1["ContactName"])} ").Trim() != "")
					{
						strText = $"{strText}{($"{Convert.ToString(rstRec1["ContactName"])} ").Trim()}{Environment.NewLine}";
					}
					if (($"{Convert.ToString(rstRec1["ContactTitle"])} ").Trim() != "")
					{
						strText = $"{strText}{($"{Convert.ToString(rstRec1["ContactTitle"])} ").Trim()}{Environment.NewLine}";
					}

					//--------------------------------------
					//-- Company Phone Numbers

					strQuery2 = "SELECT * FROM Phone_Numbers WITH (NOLOCK) ";
					strQuery2 = $"{strQuery2}INNER JOIN Phone_Type WITH (NOLOCK) ON ptype_name = pnum_type ";
					strQuery2 = $"{strQuery2}WHERE (pnum_comp_id = {lCompId.ToString()}) ";
					strQuery2 = $"{strQuery2}AND (pnum_journ_id = 0) ";
					strQuery2 = $"{strQuery2}AND (pnum_contact_id = {lContactId.ToString()}) ";
					strQuery2 = $"{strQuery2}AND (pnum_number_full IS NOT NULL) ";
					strQuery2 = $"{strQuery2}AND (pnum_number_full <> '') ";
					strQuery2 = $"{strQuery2}ORDER BY ptype_seq_no ";

					rstRec2.Open(strQuery2, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
					if (!rstRec2.BOF && !rstRec2.EOF)
					{
						do 
						{ // Loop Until rstRec2.EOF = True
							strText = $"{strText}{($"{Convert.ToString(rstRec2["pnum_type"])} ").Trim()}: {($"{Convert.ToString(rstRec2["pnum_number_full"])} ").Trim()}{Environment.NewLine}";
							rstRec2.MoveNext();
						}
						while(!rstRec2.EOF);
					} // If rstRec2.BOF = False And rstRec2.EOF = False Then
					rstRec2.Close();

					strText = $"{strText}{new string('-', 50)}{Environment.NewLine}{Environment.NewLine}";

					rstRec1.MoveNext();

				}
				while(!rstRec1.EOF);

			} // If rstRec1.BOF = False And rstRec1.EOF = False Then

			rstRec1.Close();

			if (strText != "")
			{

				if (frm_Info.DefInstance == null)
				{
					//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//VB.Global.Load(frm_Info.DefInstance);
				}

				frm_Info.DefInstance.SetFormCaption("All Relationships");
				frm_Info.DefInstance.SetText(strText);

			}
			else
			{
				MessageBox.Show("No Owner Found For This Aircraft", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
			} // If strText <> "" Then

			rstRec2 = null;
			rstRec1 = null;



		} // mnuShowExclusiveBroker_Click

		private void cmdClose_Click(Object eventSender, EventArgs eventArgs) => this.Close();


		private void Form_Activated(Object eventSender, EventArgs eventArgs)
		{
			if (ActivateHelper.myActiveForm != eventSender)
			{
				ActivateHelper.myActiveForm = (Form) eventSender;

				this.WindowState = FormWindowState.Normal;
				//UPGRADE_WARNING: (2065) Form method frm_Info.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
				this.BringToFront();

			}
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
		private void Form_Load()
		{

			gbReSizing = false;
			glWidthDiff = this.Width * 15 - txtInfo.Width * 15;
			glHeightDiff = this.Height * 15 - txtInfo.Height * 15;

			modCommon.CenterFormOnHomebaseMainForm(this);

		}

		private bool isInitializingComponent;
		private void Form_Resize(Object eventSender, EventArgs eventArgs)
		{
			if (isInitializingComponent)
			{
				return;
			}


			if (((int) this.WindowState) != ((int) FormWindowState.Minimized) && ((int) this.WindowState) != ((int) FormWindowState.Maximized) && ((int) this.WindowState) != ((int) ProcessWindowStyle.Minimized))
			{

				if (!gbReSizing)
				{

					gbReSizing = true;

					if (this.Width * 15 < 4500)
					{
						this.Width = 367;
					}
					if (this.Height * 15 < 4500)
					{
						this.Height = 367;
					}

					txtInfo.Width = this.Width - glWidthDiff / 15;
					txtInfo.Height = this.Height - glHeightDiff / 15;

					cmdClose.Top = txtInfo.Top + txtInfo.Height + 7;

					gbReSizing = false;

				} //If gbReSizing = False Then

			} // If .WindowState <> vbNormalFocus And .WindowState <> vbMinimizedFocus And .WindowState <> vbMinimizedNoFocus Then
			 // Me

		}
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}