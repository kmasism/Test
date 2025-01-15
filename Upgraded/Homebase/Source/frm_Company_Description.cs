using System;
using System.Windows.Forms;

namespace JETNET_Homebase
{
	internal partial class frm_Company_Description
		: System.Windows.Forms.Form
	{

		public frm_Company_Description()
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


		private void frm_Company_Description_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		public int Comp_id = 0;
		public string comp_note_start = "";
		public string test_or_live = "";

		private void cmd_cancel_Click(Object eventSender, EventArgs eventArgs) => 

			// JUST UNLOAD THE FORM AND DO NOTHING ELSE SINCE NOTHING WAS SAVED
			frm_Company_Description.DefInstance.Close();//Call Form_Unload(0)


		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
		private void Form_Load()
		{

			//DoEvents

			web_comp_det.Navigate(new Uri($"http://jetnet14/help/admin/company_description.asp?comp_id={Comp_id.ToString()}&test={test_or_live}"));

			Application.DoEvents();

			while(web_comp_det.IsBusy)
			{
				Application.DoEvents();
			};
			web_comp_det.Refresh();

		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs) => frm_Company_Description.DefInstance.Close();// DoEvents

	}
}