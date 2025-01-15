using System;
using System.Data.Common;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;

namespace JETNET_Homebase
{
	internal partial class frm_JETNETiQSurvey
		: System.Windows.Forms.Form
	{

		public frm_JETNETiQSurvey()
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


		private void frm_JETNETiQSurvey_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}

		// Last Updated 12/20/2011 - By David D. Cruger
		// Last Updated 10/28/2013 - By David D. Cruger; Added Chinese

		private bool bCancel = false;
		private bool bEMail = false;

		public void ReturnStatus(ref string strButton, ref string strLanguage)
		{

			strButton = "Cancel";
			strLanguage = "English";

			if (bEMail)
			{
				strButton = "EMail";
			}

			if (opJIQLanguage[1].Checked)
			{
				strLanguage = "French";
			}
			if (opJIQLanguage[2].Checked)
			{
				strLanguage = "German";
			}
			if (opJIQLanguage[3].Checked)
			{
				strLanguage = "Spanish";
			}
			if (opJIQLanguage[4].Checked)
			{
				strLanguage = "Portguese";
			}
			if (opJIQLanguage[5].Checked)
			{
				strLanguage = "Russian";
			}
			if (opJIQLanguage[6].Checked)
			{
				strLanguage = "Arabic";
			}
			if (opJIQLanguage[7].Checked)
			{
				strLanguage = "Chinese";
			}

		} // ReturnStatus

		public void SetSendToLabel(string strSendTo) => lblSendingTo.Text = strSendTo;


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
			this.Hide();
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
		private void Form_Load()
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();

			for (int iCnt1 = 0; iCnt1 <= 6; iCnt1++)
			{
				opJIQLanguage[iCnt1].Enabled = true;
			}

			string strQuery1 = "SELECT * FROM JETNETiQ_Configuration";
			rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

			if ((!rstRec1.BOF) && (!rstRec1.EOF))
			{

				if (($"{Convert.ToString(rstRec1["jiq_english_active_flag"])} ").Trim() == "N")
				{
					opJIQLanguage[0].Enabled = false;
				}
				if (($"{Convert.ToString(rstRec1["jiq_french_active_flag"])} ").Trim() == "N")
				{
					opJIQLanguage[1].Enabled = false;
				}
				if (($"{Convert.ToString(rstRec1["jiq_german_active_flag"])} ").Trim() == "N")
				{
					opJIQLanguage[2].Enabled = false;
				}
				if (($"{Convert.ToString(rstRec1["jiq_spanish_active_flag"])} ").Trim() == "N")
				{
					opJIQLanguage[3].Enabled = false;
				}
				if (($"{Convert.ToString(rstRec1["jiq_portguese_active_flag"])} ").Trim() == "N")
				{
					opJIQLanguage[4].Enabled = false;
				}
				if (($"{Convert.ToString(rstRec1["jiq_russian_active_flag"])} ").Trim() == "N")
				{
					opJIQLanguage[5].Enabled = false;
				}
				if (($"{Convert.ToString(rstRec1["jiq_arabic_active_flag"])} ").Trim() == "N")
				{
					opJIQLanguage[6].Enabled = false;
				}
				if (($"{Convert.ToString(rstRec1["jiq_chinese_active_flag"])} ").Trim() == "N")
				{
					opJIQLanguage[7].Enabled = false;
				}
			} // If (rstRec1.BOF = False) And (rstRec1.EOF = False) Then

			rstRec1.Close();
			rstRec1 = null;

			bCancel = true;
			bEMail = false;

			//----------------------------------------
			// Always Make Sure English Is Selected

			opJIQLanguage[0].Checked = true;
			this.Visible = true;
			//UPGRADE_WARNING: (2065) Form method frm_JETNETiQSurvey.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
			this.BringToFront();

		}
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}