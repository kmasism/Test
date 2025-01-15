using System;
using System.Windows.Forms;
using UpgradeHelpers.Gui.Utils;

namespace JETNET_Homebase
{
	internal partial class frm_Tips
		: System.Windows.Forms.Form
	{


		//==================
		// Public Variables
		//==================
		public string TopCaption = "";
		public string BottomCaption = "";
		public frm_Tips()
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

		private void cmdClose_Click(Object eventSender, EventArgs eventArgs) => this.Close();


		private void Form_Activated(Object eventSender, EventArgs eventArgs)
		{
			if (ActivateHelper.myActiveForm != eventSender)
			{
				ActivateHelper.myActiveForm = (Form) eventSender;

				lblCaption1.Text = TopCaption;
				lblCaption2.Text = BottomCaption;

				lblCaption1.Visible = true;
				lblCaption2.Visible = true;

			}
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
		private void Form_Load() => modCommon.CenterFormOnHomebaseMainForm(this);

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}