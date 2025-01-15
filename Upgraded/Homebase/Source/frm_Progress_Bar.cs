using System;
using System.Windows.Forms;

namespace JETNET_Homebase
{
	internal partial class frm_Progress_Bar
		: System.Windows.Forms.Form
	{

		public frm_Progress_Bar()
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


		private void frm_Progress_Bar_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}

		public bool StopButtonEnabled()
		{

			bool result = false;
			result = true;
			if (cmdStop.Visible)
			{
				result = cmdStop.Enabled;
			}

			return result;
		}

		public void SetStopButtonVisible(bool bValue)
		{

			cmdStop.Visible = bValue;
			cmdStop.Enabled = bValue;

		}

		public void SetStatusCaption(string strText) => lblStatus.Text = strText;
		 // SetStatusCaption

		public void InitProgressBar(int lMin, int lMax, int lValue)
		{

			if (lMin > lMax)
			{
				lMin = lMax;
			}
			if (lValue < lMin)
			{
				lValue = lMin;
			}
			if (lValue > lMax)
			{
				lValue = lMax;
			}

			pbBar.Minimum = lMin;
			pbBar.Maximum = lMax;
			pbBar.Value = lValue;

		}

		public void IncProgressBar()
		{

			if (pbBar.Value < pbBar.Maximum)
			{
				pbBar.Value = Convert.ToInt32(pbBar.Value + 1);
			}

		}

		public void ProgressBarComplete() => pbBar.Value = Convert.ToInt32(pbBar.Maximum);


		private void cmdStop_Click(Object eventSender, EventArgs eventArgs) => cmdStop.Enabled = false;


		private void Form_Initialize()
		{

			modCommon.CenterFormOnHomebaseMainForm(this);
			SetStopButtonVisible(false);
			SetStatusCaption("");
			InitProgressBar(0, 100, 0);

		}
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}