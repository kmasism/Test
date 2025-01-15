using Microsoft.VisualBasic;
using System;
using System.Drawing;
using System.Windows.Forms;
using UpgradeHelpers.Gui.Utils;
using UpgradeHelpers.Helpers;

namespace JETNET_Homebase
{
	internal partial class mdi_ResearchAssistant
		: System.Windows.Forms.Form
	{


		private int glWidth = 0;
		private int glHeight = 0;
		public mdi_ResearchAssistant()
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


					//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
					// This code is in the 'Activate' event because the 'mdi' form
					// will be activated whenever no child form is visible.
					// A first time sentinel is employed to avoid an infinite loop.
					//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

					if (Been_Here_MDIForm_Activated)
					{
						return;
					}
					else
					{
						Been_Here_MDIForm_Activated = true;
					}

					mdi_ResearchAssistant.DefInstance.Width = glWidth / 15;
					mdi_ResearchAssistant.DefInstance.Height = glHeight / 15;

					modAdminCommon.CenterForm32(this);

					// Initialize the Status Bar

					modAdminCommon.SB = modStatusBar.Identify_Status_Bar(this.pnlStatusBar);

					modAdminCommon.NormalColor = (0x80000008).ToString();
					modAdminCommon.PrimaryColor = (0xC0FFFF).ToString();
					modAdminCommon.ConfirmColor = (0xC0C0FF).ToString();
					modAdminCommon.ForSaleColor = (0xC0FFC0).ToString();
					modAdminCommon.InactiveColor = (0xE0E0E0).ToString();
					modAdminCommon.NoColor = (0xFFFFFF).ToString();
					modAdminCommon.HeadingColor = (0x8000000F).ToString();
					modAdminCommon.ExclusiveColor = (0xFFC0C0).ToString();
					modAdminCommon.LeaseColor = (0x5BADFF).ToString();
					modAdminCommon.HiddenColor = (0xFF).ToString();

					modAdminCommon.ClassAColor = Color.Cyan;
					modAdminCommon.ClassBColor = Color.Magenta;
					modAdminCommon.ClassCColor = SystemColors.GrayText;
					modAdminCommon.ClassDColor = Color.Red;

					lbl_WhichDatabase.Visible = false;

					frm_Main_Menu.DefInstance.Show();

					return;
				}
				catch
				{

					this.Cursor = CursorHelper.CursorDefault;
					modAdminCommon.Report_Error("MDIForm_Load_Error: ");
					Environment.Exit(0);
				}

			}
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
		private void MDIForm_Load()
		{

			glWidth = mdi_ResearchAssistant.DefInstance.Width * 15;
			glHeight = mdi_ResearchAssistant.DefInstance.Height * 15;

		}

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
					M = $"Are you sure you want to exit Homebase?{Environment.NewLine}{Environment.NewLine}No data will be saved!";
					Response = ((int) MessageBox.Show(M, "Exit Homebase?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)).ToString();
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

		private void MDIForm_Closed(Object eventSender, EventArgs eventArgs) => modAdminCommon.UnloadAllForms();


		public void mnuFileExit_Click(Object eventSender, EventArgs eventArgs) => Environment.Exit(0);


		private void MouseTimer_Tick(Object eventSender, EventArgs eventArgs) => 

			//----------------------------------------------
			// Every 60 Seconds Check The Cursor Location

			modCommon.Monitor_Users_Cursor_Movement();
		 // MouseTimer_Timer
		//UPGRADE_NOTE: (7001) The following declaration (Form_Unload) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void Form_Unload(int Cancel)
		//{
		//}
	}
}