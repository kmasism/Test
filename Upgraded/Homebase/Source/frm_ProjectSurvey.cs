using System;
using System.Data.Common;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Gui.Controls;

namespace JETNET_Homebase
{
	internal partial class frm_ProjectSurvey
		: System.Windows.Forms.Form
	{

		public frm_ProjectSurvey()
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


		private void frm_ProjectSurvey_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}

		private bool bCancel = false;
		private bool bEMail = false;
		private bool bContactFlag = false;
		private bool bCompanyFlag = false;

		public void SetContactFlag(bool bFlag) => bContactFlag = bFlag;


		public void SetCompanyFlag(bool bFlag) => bCompanyFlag = bFlag;



		public void SetSendToLabel(string strSendTo)
		{
			if (lblSendingTo.Text != "NO ACTIVE PROJECT SURVEY FOUND")
			{
				lblSendingTo.Text = strSendTo;
			}
		}

		public void ReturnStatus(ref string strButton)
		{

			strButton = "Cancel";

			if (bEMail)
			{
				strButton = "EMail";
			}

		} // ReturnStatus

		public void ReturnSelectedProjectSurveyId(ref int lPSCId)
		{

			lPSCId = 0;
			if (cmbProjectSurvey.SelectedIndex >= 0)
			{
				lPSCId = cmbProjectSurvey.GetItemData(cmbProjectSurvey.SelectedIndex);
			}

		}

		private void cmdCancel_Click(Object eventSender, EventArgs eventArgs)
		{
			bCancel = true;
			this.Visible = false;
			this.Hide();
		}

		private void cmdSend_Click(Object eventSender, EventArgs eventArgs)
		{
			bEMail = true;
			this.Visible = false;
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
		private void Form_Load()
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			int iCnt1 = 0;

			bContactFlag = true;
			bCompanyFlag = false;
			cmdSend.Enabled = true;
			cmbProjectSurvey.Items.Clear();

			string strQuery1 = "SELECT * FROM Project_Survey_Configuration WITH (NOLOCK) ";
			strQuery1 = $"{strQuery1}WHERE (psc_active_flag = 'Y') ";
			strQuery1 = $"{strQuery1}AND (psc_start_date <= GetDate() OR psc_start_date IS NULL) ";
			strQuery1 = $"{strQuery1}AND (psc_end_date > GetDate() OR psc_end_date IS NULL) ";
			if (bCompanyFlag)
			{
				strQuery1 = $"{strQuery1}AND (psc_allow_company_flag = 'Y') ";
			}
			if (bContactFlag)
			{
				strQuery1 = $"{strQuery1}AND (psc_allow_contact_flag = 'Y') ";
			}
			strQuery1 = $"{strQuery1}ORDER BY psc_name ";

			rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

			if (!rstRec1.BOF && !rstRec1.EOF)
			{

				iCnt1 = -1;
				do 
				{ // Loop Until rstRec1.EOF = True

					iCnt1++;
					cmbProjectSurvey.AddItem(($"{Convert.ToString(rstRec1["psc_name"])} ").Trim(), iCnt1);
					cmbProjectSurvey.SetItemData(iCnt1, Convert.ToInt32(rstRec1["psc_id"]));

					rstRec1.MoveNext();

				}
				while(!rstRec1.EOF);

				cmbProjectSurvey.SelectedIndex = 0;

			}
			else
			{
				cmdSend.Enabled = false;
				lblSendingTo.Text = "NO ACTIVE PROJECT SURVEY FOUND";
			} // If rstRec1.BOF = False And rstRec1.EOF = False Then

			rstRec1.Close();


		} // Form_Load
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}