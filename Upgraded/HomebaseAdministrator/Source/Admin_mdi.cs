using Microsoft.VisualBasic;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using UpgradeHelpers.Gui.Utils;
using UpgradeHelpers.Helpers;

namespace HomebaseAdministrator
{
	internal partial class mdi_AdminAssistant
		: System.Windows.Forms.Form
	{



		public mdi_AdminAssistant()
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



		bool Been_Here_MDIForm_Activated = false;
		private void MDIForm_Activated(Object eventSender, EventArgs eventArgs)
		{
			if (!(ActivateHelper.myActiveForm is null) && ActivateHelper.myActiveForm != eventSender && (Information.IsNothing(Convert.ToString(ActivateHelper.myActiveForm)) || !ActivateHelper.myActiveForm.IsMdiChild || ActivateHelper.myActiveForm.Parent.Parent != eventSender))
			{
				ActivateHelper.myActiveForm = (Form) eventSender;


				try
				{

					Process[] processes = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
					if (processes.Length > 1 && Process.GetCurrentProcess().StartTime != processes[0].StartTime)
					{
						MessageBox.Show("An instance of Administrator is already running", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						Environment.Exit(0); //quit if it is already running
						return;
					}



					if (Been_Here_MDIForm_Activated)
					{
						return;
					}
					else
					{
						Been_Here_MDIForm_Activated = true;
					}

					this.Cursor = Cursors.WaitCursor;
					modAdminCommon.PrimaryColor = (0xC0FFFF).ToString();
					modAdminCommon.ConfirmColor = (0xC0C0FF).ToString();
					modAdminCommon.ForSaleColor = (0xC0FFC0).ToString();
					modAdminCommon.InactiveColor = (0xE0E0E0).ToString();
					modAdminCommon.NoColor = (0xFFFFFF).ToString();
					modAdminCommon.HeadingColor = (0x8000000F).ToString();
					modAdminCommon.ExclusiveColor = (0xFFC0C0).ToString();
					modAdminCommon.LeaseColor = (0x5BADFF).ToString();
					modAdminCommon.HiddenColor = (0xFF).ToString();

					modAdminCommon.CenterForm32(this);

					modAdminCommon.SB = modStatusBar.Identify_Status_Bar(this.pnlStatusBar);

					lbl_WhichDatabase.Visible = false;

					frm_Admin_Menu.DefInstance.Show();

					this.Cursor = CursorHelper.CursorDefault;

					Application.DoEvents();

					return;
				}
				catch
				{

					modAdminCommon.Report_Error("MDIForm_Load_Error: ");
					this.Cursor = CursorHelper.CursorDefault;
					Environment.Exit(0);
				}
				return;

			}
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
		private void MDIForm_Load() => modAdminCommon.SetColorVariables();


		private void MDIForm_FormClosing(Object eventSender, FormClosingEventArgs eventArgs)
		{
			int Cancel = (eventArgs.Cancel) ? 1 : 0;
			int UnloadMode = (int) eventArgs.CloseReason;
			try
			{

				string Response = "";
				string M = "";

				//UPGRADE_WARNING: (2065) QueryUnloadConstants property QueryUnloadConstants.vbFormControlMenu has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
				if (UnloadMode == ((int) CloseReason.UserClosing))
				{
					M = "Are you sure you want to exit the application, no data will be saved?";
					Response = ((int) MessageBox.Show(M, "Exit Application", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)).ToString();
					if (Response == ((int) System.Windows.Forms.DialogResult.No).ToString())
					{
						Cancel = -1;
					}
				}
			}
			finally
			{
				eventArgs.Cancel = Cancel != 0;
			}
		}

		private void MDIForm_Closed(Object eventSender, EventArgs eventArgs)
		{

			modAdminCommon.UnloadAllForms();

			if (modAdminCommon.gbl_User_ID != "")
			{
				modAdminCommon.ClearAllLocksForCurrentUser(modAdminCommon.gbl_User_ID);
			}

		}

		public void mnuFileExit_Click(Object eventSender, EventArgs eventArgs) => Environment.Exit(0);

		[STAThread]
		static void Main() => Application.Run(CreateInstance());

	}
}