using System;
using System.Windows.Forms;
using UpgradeHelpers.Helpers;
using UpgradeStubs;

namespace JETNET_Homebase
{
	internal partial class frm_Web_Page
		: System.Windows.Forms.Form
	{

		public frm_Web_Page()
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


		private void frm_Web_Page_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}

		public int Ac_Maint_ID = 0;
		public int AC_ID = 0;



		private void cmd_launch_webpage_Click(Object eventSender, EventArgs eventArgs)
		{

			//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			//VB.Global.Load(frm_WebReport.DefInstance);
			frm_WebReport.DefInstance.ac_id = AC_ID;
			frm_WebReport.DefInstance.Ac_Maint_ID = 0;
			frm_WebReport.DefInstance.WhichReport = "View Maintenance Details";
			frm_WebReport.DefInstance.Show();

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
		private void Form_Load()
		{

			string URL = "";

			this.Cursor = Cursors.WaitCursor;
			int LoopCount = 0;

			if (Ac_Maint_ID > 0)
			{
				URL = $"http://www.homebase.com/maintenance.aspx?acID={AC_ID.ToString()}&jID=0&maint_row={Ac_Maint_ID.ToString()}&homebase=Y";
			}
			else
			{
				URL = $"http://www.homebase.com/maintenance.aspx?acID={AC_ID.ToString()}&jID=0&homebase=Y";
			}

			//UPGRADE_ISSUE: (2064) SHDocVw.WebBrowser property WebBrowser1.Silent was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			WebBrowser1.setSilent(true);
			WebBrowser1.Navigate(new Uri(URL));
			Application.DoEvents();
			Application.DoEvents();
			Application.DoEvents();


			while(!(WebBrowser1.ReadyState == WebBrowserReadyState.Interactive || WebBrowser1.ReadyState == WebBrowserReadyState.Complete || LoopCount > 100000))
			{
				LoopCount++;
			};

			Application.DoEvents();
			Application.DoEvents();
			JetNetSupport.PInvoke.SafeNative.kernel32.Sleep(50);
			Application.DoEvents();
			Application.DoEvents();


			try
			{


				WebBrowser1.Refresh();


				JetNetSupport.PInvoke.SafeNative.kernel32.Sleep(10);
				Application.DoEvents();
				Application.DoEvents();
				Application.DoEvents();
				Application.DoEvents();

				this.Cursor = CursorHelper.CursorDefault;
				Application.DoEvents();
				Application.DoEvents();
			}
			catch
			{

				JetNetSupport.PInvoke.SafeNative.kernel32.Sleep(10);
				Application.DoEvents();
				Application.DoEvents();
				Application.DoEvents();
				Application.DoEvents();

				this.Cursor = CursorHelper.CursorDefault;
				Application.DoEvents();
				Application.DoEvents();
			}

		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{

			frm_aircraft.DefInstance.Fill_Aircraft_Maintenance_Grid();
			frm_aircraft.DefInstance.Key_Feature_Auto_Update();
			this.Close();

		}
	}
}