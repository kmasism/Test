using Microsoft.VisualBasic;
using System;
using System.IO;
using System.Windows.Forms;

namespace JETNET_Homebase
{
	internal partial class frm_AttachFAADocToCompany
		: System.Windows.Forms.Form
	{

		public frm_AttachFAADocToCompany()
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


		private void frm_AttachFAADocToCompany_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}

		public void SetDocumentFileName(string strFileName)
		{
			lblFAADocFileName.Tag = strFileName;
			lblFAADocFileName.Text = (new FileInfo(strFileName)).Name;
		} // SetDocumentFileName

		public void SetCompId(int lCompId)
		{
			txtCompId.Text = lCompId.ToString();
			if (lCompId > 0)
			{
				lblCompany.Text = modCommon.GetCompanyInfo(lCompId);
			}
		} // SetCompId

		private void cmdAttach_Click(Object eventSender, EventArgs eventArgs)
		{

			if (txtCompId.Text != "" && txtCompId.Text != "0")
			{

				if (Information.IsNumeric(txtCompId.Text))
				{

					if (File.Exists(Convert.ToString(lblFAADocFileName.Tag)))
					{

						//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//VB.Global.Load(frm_CompanyDocument.DefInstance);

						modCommon.CenterFormOnHomebaseMainForm(frm_CompanyDocument.DefInstance);
						frm_CompanyDocument.DefInstance.SetCompanyId(Convert.ToInt32(Double.Parse(txtCompId.Text)));
						frm_CompanyDocument.DefInstance.Form_Load_Data();
						frm_CompanyDocument.DefInstance.SetDocumentFileName(Convert.ToString(lblFAADocFileName.Tag));
						frm_CompanyDocument.DefInstance.SetAttachFAADoc(true);

						this.Hide();
						frm_CompanyDocument.DefInstance.ShowDialog();
						frm_CompanyDocument.DefInstance.Close();
						this.Close();
					} // If gfso.FileExists(lblFAADocFileName.Tag) = True Then

				} // If IsNumeric(txtCompId.Text) = True Then

			} // If txtCompId.Text <> "" And txtCompId.Text <> "0" Then

		} // cmdAttach_Click

		private void cmdClose_Click(Object eventSender, EventArgs eventArgs) => this.Close();


		private void txtCompId_Leave(Object eventSender, EventArgs eventArgs)
		{

			if (txtCompId.Text != "" && txtCompId.Text != "0")
			{
				Fill_Company_Information_Label();
			}
			else
			{
				lblCompany.Text = "";
			}

		} // txtCompId_LostFocus

		private void Fill_Company_Information_Label()
		{

			if (txtCompId.Text != "" && txtCompId.Text != "0")
			{
				if (Information.IsNumeric(txtCompId.Text))
				{
					lblCompany.Text = modCommon.GetCompanyInfo(Convert.ToInt32(Double.Parse(txtCompId.Text)));
				}
			}

		} // Fill_Company_Information_Label
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}