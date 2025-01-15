using System;
using System.Diagnostics;
using System.Windows.Forms;
using UpgradeHelpers.Gui.Utils;

namespace JETNET_Homebase
{
	internal partial class frm_info2
		: System.Windows.Forms.Form
	{




		private bool gbReSizing = false;
		private int glWidthDiff = 0;
		private int glHeightDiff = 0;
		public frm_info2()
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


		private void cmdClose_Click(Object eventSender, EventArgs eventArgs) => this.Close();


		private void Form_Activated(Object eventSender, EventArgs eventArgs)
		{
			if (ActivateHelper.myActiveForm != eventSender)
			{
				ActivateHelper.myActiveForm = (Form) eventSender;

				this.WindowState = FormWindowState.Normal;
				//UPGRADE_WARNING: (2065) Form method frm_info2.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
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