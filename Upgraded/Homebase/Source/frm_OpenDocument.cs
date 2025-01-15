using Microsoft.VisualBasic;
using System;
using System.Data.Common;
using System.Diagnostics;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Gui.Utils;

namespace JETNET_Homebase
{
	internal partial class frm_OpenDocument
		: System.Windows.Forms.Form
	{


		private int glWidth = 0;
		private int glHeight = 0;
		private int glWidthDiff = 0;
		private int glHeightDiff = 0;
		private bool gbReSizing = false;

		private int glFAALogId = 0;
		private string gstrDocURL = "";
		private bool gbLoaded = false;
		public frm_OpenDocument()
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
			isInitializingComponent = true;
			InitializeComponent();
			isInitializingComponent = false;
			ReLoadForm(false);
		}



		public void SetDocURL(string strURL) => gstrDocURL = strURL;
		 // SetDocURL

		public void SetFAALogId(int lFAALogId)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strGNote = "";
			string strLabel = "";

			try
			{

				glFAALogId = lFAALogId;
				txtDocGeneralNote.Text = "";
				lbl_gen[0].Text = "";

				if (lFAALogId > 0)
				{

					gbLoaded = false;

					strQuery1 = $"SELECT * FROM FAA_Document_Log WITH (NOLOCK) WHERE (faalog_id = {glFAALogId.ToString()}) ";

					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						strGNote = ($"{Convert.ToString(rstRec1["faalog_general_note"])} ").Trim();
						txtDocGeneralNote.Text = strGNote;

						strLabel = $"LogId: {Convert.ToString(rstRec1["faalog_id"])}   ";
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["faalog_tape_date"]))
						{
							strLabel = $"{strLabel}Tape Date: {Convert.ToDateTime(rstRec1["faalog_tape_date"]).ToString("MM/dd/yyyy")}   ";
						}
						strLabel = $"{strLabel}Tape Nbr: {Convert.ToString(rstRec1["faalog_tape_no"])}   ";
						strLabel = $"{strLabel}Tape of: {Convert.ToString(rstRec1["faalog_tape_of"])} of {Convert.ToString(rstRec1["faalog_tape_to"])}   ";
						strLabel = $"{strLabel}Frame Start: {Convert.ToString(rstRec1["faalog_starting_frame_no"])}   ";
						strLabel = $"{strLabel}Frame End: {Convert.ToString(rstRec1["faalog_ending_frame_no"])}    Doc Type: {($"{Convert.ToString(rstRec1["faalog_doc_type"])} ").Trim()}   ";

						lbl_gen[0].Text = strLabel;

					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

				} // If lFAALogId > 0 Then

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("SetFAALogId_Error", excep.Message);
			}

		} // SetFAALogId

		private void Form_Activated(Object eventSender, EventArgs eventArgs)
		{
			if (ActivateHelper.myActiveForm != eventSender)
			{
				ActivateHelper.myActiveForm = (Form) eventSender;

				if (!gbLoaded)
				{

					if (gstrDocURL != "")
					{

						//UPGRADE_WARNING: (2080) Navigate2 was upgraded to Navigate and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
						wbOpenDocument.Navigate(new Uri(gstrDocURL));

					} // If gstrDocURL <> "" Then

					gbLoaded = true;
				} // If gbLoaded = False Then

			}
		} // Form_Activate

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
		private void Form_Load()
		{

			glWidth = this.Width * 15;
			glHeight = this.Height * 15;

			glWidthDiff = this.Width * 15;
			glHeightDiff = this.Height * 15;

			glFAALogId = 0;
			gbReSizing = false;
			gbLoaded = false;
			gstrDocURL = "";

			//UPGRADE_WARNING: (2080) Navigate2 was upgraded to Navigate and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
			wbOpenDocument.Navigate(new Uri("about:blank"));

		} // Form_Load

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

					if (this.Width * 15 < glWidth)
					{
						this.Width = glWidth / 15;
					}
					if (this.Height * 15 < glHeight)
					{
						this.Height = glHeight / 15;
					}

					glWidthDiff = this.Width * 15 - glWidthDiff;
					glHeightDiff = this.Height * 15 - glHeightDiff;

					frmDocInfo.Width += glWidthDiff / 15;
					txtDocGeneralNote.Width += glWidthDiff / 15;
					wbOpenDocument.Width += glWidthDiff / 15;

					wbOpenDocument.Height += glHeightDiff / 15;

					glWidthDiff = this.Width * 15;
					glHeightDiff = this.Height * 15;

					gbReSizing = false;

				} // If gbReSizing = False Then

			} // If .WindowState <> vbNormalFocus Or .WindowState <> vbMinimizedFocus Or .WindowState <> vbMinimizedNoFocus Then
			 // Me

		} // Form_Resize
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}