using System;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace UpgradeHelpers.Gui.Controls
{
	public static partial class TabControlHelper
	{
		public static int GetOldTab(this TabControl tabControl)
		{
			FieldInfo field = tabControl.GetType().GetField("lastSelection", BindingFlags.NonPublic | BindingFlags.Instance);
			return (int)field.GetValue(tabControl);
		}
		/// <summary>
		/// Method that simulates the indexer of the TabControl
		/// </summary>
		/// <param name="tabControl"></param>
		/// <param name="key"></param>
		/// <returns></returns>
		public static TabPage TabPages(this TabControl tabControl, object key)
		{
			if (key != null && key is string)
			{
				string keyLocal = System.Convert.ToString(key);
				return tabControl.TabPages[tabControl.TabPages.ContainsKey(keyLocal) ? keyLocal : "tab" + keyLocal];
			}
			else
				return tabControl.TabPages[System.Convert.ToInt32(key)];
		}

		public static void SelectTab(this TabPage tab)
		{
			(tab.Parent as TabControl).SelectedTab = tab;
		}

		#region Enums TabControl
		/// <summary>
		///     Use bottom left corner pixel of image
		/// </summary>
		public enum Constants_MaskColorSource
		{
			//
			// Summary:
			//     No mask color (non-transparent)
			ssMaskColorNone = 0,
			//
			// Summary:
			//      Use bottom left corner pixel of image
			ssMaskColorUseImage = 1
		}

		/// <summary>
		///    Constants that specify the style of the Tab control
		/// </summary>
		public enum Constants_TabStyle
		{
			//
			// Summary:
			//      Note Page
			ssStyleNotePage = 1,
			//
			// Summary:
			//      Note Page Flat(no borders)
			ssStyleNotePageFlat = 2,

			//
			// Summary:
			//       Property Page
			ssStylePropertyPage = 0,


			//
			// Summary:
			//      Wizard (no runtime UI)
			ssStyleWizard = 3

		}

		/// <summary>
		///    Constants that specify which tab to select
		/// </summary>
		public enum Constants_SelectedTab
		{
			//
			// Summary:
			//     Select first visible(and enabled) tab
			ssSelectFirstTab = -3,
			//
			// Summary:
			//      Select last visible(and enabled) tab
			ssSelectLastTab = -4,

			//
			// Summary:
			//       Select next visible(and enabled) tab
			ssSelectNextTab = -1,

			//
			// Summary:
			//      Select previous visible(and enabled) tab
			ssSelectPreviousTab = -2
		}
		#endregion
	}
    /// <summary>
    /// Method that simulates the TabControl when it is mapped from TabproLib.vaTabPro control.
    /// </summary>
    /// <returns></returns>
    public static class TabControlExtensionMethods
    {
        /// <summary>
        /// Method that simulates the set for TabState of the TabControl
        /// when the control is mapped from TabproLib.vaTabPro control.
        /// </summary>
        /// <param name="instance">the instance of the TabControl to affect</param>
        /// <param name="TabState">
        /// state value to apply
        /// 0 TAB_STATE_ENABLED
        /// 1 TAB_STATE_HIDE
        /// 2 TAB_STATE_DISABLED
        /// 3 TAB_STATE_UNAVAILABLE
        /// any other value does not affect the control state
        /// </param>
        /// <returns></returns>
        public static void SetTabState(this TabControl instance, int TabState)
        {
            switch (TabState)
            {
                case 0:
                    instance.TabPages[System.Convert.ToInt32(instance.Tag)].Visible = true;
                    instance.TabPages[System.Convert.ToInt32(instance.Tag)].Enabled = true;
                    break;
                case 1:
                    instance.TabPages[System.Convert.ToInt32(instance.Tag)].Visible = false;
                    break;
                case 2:
                    instance.TabPages[System.Convert.ToInt32(instance.Tag)].Visible = true;
                    instance.TabPages[System.Convert.ToInt32(instance.Tag)].Enabled = false;
                    break;
                case 3:

                    break;
                default:
                    break;
            }

        }
    }
    public class TabControlExtension : TabControl
	{
		#region Windows Form Designer generated code

		public System.Windows.Forms.ToolTip ToolTipMain;
        public event DrawItemEventHandler CustomDrawItem; // Store DrawItem handler to use.

        public TabControlExtension()
			: base()
		{


			// This call is required by the Windows Form Designer.
			InitializeComponent();

			//Obtain ToolTipMain if possible
			ObtainToolTipMainFromHostedParent(ref ToolTipMain);


			this.DrawMode = TabDrawMode.OwnerDrawFixed;//So that mnemonics are shown properly in tab pages
		}

		/// <summary>
		//Analysis on current control (tabcontrol) hosts to look for the container ToolTipMain control and assign it to the local ToolTipMain variable
		/// </summary>
		/// <param name="ToolTipMain">System.Windows.Forms.ToolTip</param>
		/// <returns></returns>
		protected void ObtainToolTipMainFromHostedParent(ref System.Windows.Forms.ToolTip ToolTipMain)
		{
			try
			{
			Control theControl = this.Parent;
			Boolean bContinueAnalysis = theControl != null;
			while (bContinueAnalysis)
			{
				Type tTheControlType = theControl.GetType();
				String sTheControlTypeInheritance = "";
				if (tTheControlType.BaseType != null)
				{
					sTheControlTypeInheritance = tTheControlType.BaseType.FullName;
				}
				if (sTheControlTypeInheritance.Equals("System.Windows.Forms.Form"))
				{
					bContinueAnalysis = false;
					System.Reflection.FieldInfo fFieldInfo = theControl.GetType().GetField("ToolTipMain");
					if (fFieldInfo != null)
					{
						System.Windows.Forms.ToolTip tTheToolTip = ((System.Windows.Forms.ToolTip)fFieldInfo.GetValue(theControl));
						this.ToolTipMain = tTheToolTip;
					}
				}
				else
				{
					if (theControl.Parent != null)
					{
						theControl = theControl.Parent;
					}
					else
					{
						bContinueAnalysis = false;
					}
				}
			}
		}
			catch { }
		}

		/// <summary>
		/// Verify if there is a handler subscribed to CustomDrawItem event.
		/// </summary>
		/// <returns>True if there is at least one handler subscribed to CustomDrawItem, False if no handlers are subscribed</returns>
        public bool HasCustomDrawItemHandlers()
        {
            return CustomDrawItem != null;
        }

        protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (!((components == null)))
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}


		// Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;

		// NOTE: The following procedure is required by the Windows Form Designer
		// It can be modified using the Windows Form Designer.
		// Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			this.SuspendLayout();
			this.ShowToolTips = true;
			this.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.TabStrip_ControlAdded);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Tabcontrol_MouseMove);
			this.ResumeLayout();
		}

		/// <summary>
		//Analysis on added controls allow to simulate VB6 "selected tab"/"active tab" behaviour when new tabs are added to the control during runtime
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">ControlEventArgs</param>
		/// <returns></returns>
		private void TabStrip_ControlAdded(object sender, ControlEventArgs e)
		{
			if (
				(e.Control != null) && //robustness
				(e.Control.GetType().FullName.Equals("System.Windows.Forms.TabPage")) && //Item type validation
				(((System.Windows.Forms.TabPage)e.Control).Parent != null) && //robustness
				((((System.Windows.Forms.TabPage)e.Control).Parent.GetType().FullName.Equals("UpgradeHelpers.Gui.Controls.TabControlExtension") || ((System.Windows.Forms.TabPage)e.Control).Parent.GetType().FullName.Equals("System.Windows.Forms.TabControl"))) && //filter out TabControl or TabControlExtension parents 
				(((System.Windows.Forms.TabPage)((UpgradeHelpers.Gui.Controls.TabControlExtension)((System.Windows.Forms.TabPage)e.Control).Parent).SelectedTab) != null) && //robustness
				((UpgradeHelpers.Gui.Controls.TabControlExtension)((System.Windows.Forms.TabPage)e.Control).Parent).TabPages.IndexOf(((System.Windows.Forms.TabPage)e.Control)) <
				((UpgradeHelpers.Gui.Controls.TabControlExtension)((System.Windows.Forms.TabPage)e.Control).Parent).TabPages.IndexOf(((System.Windows.Forms.TabPage)((UpgradeHelpers.Gui.Controls.TabControlExtension)((System.Windows.Forms.TabPage)e.Control).Parent).SelectedTab))
				//items that are inserted to previous current selected tab requires to take action
				)
			{
				//set selected tab to previous item in the itemlist
				((UpgradeHelpers.Gui.Controls.TabControlExtension)((System.Windows.Forms.TabPage)e.Control).Parent).TabPages(((UpgradeHelpers.Gui.Controls.TabControlExtension)((System.Windows.Forms.TabPage)e.Control).Parent).TabPages.IndexOf(((System.Windows.Forms.TabPage)((UpgradeHelpers.Gui.Controls.TabControlExtension)((System.Windows.Forms.TabPage)e.Control).Parent).SelectedTab)) - 1).SelectTab();
			}
		}

		/// <summary>
		//Analysis on mousemove event to determine which tab is currently been pointed and set its tooltiptext value to the whole tabcontrol
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">MouseEventArgs</param>
		/// <returns></returns>
		private void Tabcontrol_MouseMove(object sender, MouseEventArgs e)
		{
			//set local ToolTipMain to reference tabcontrol host
			if (ToolTipMain == null)
			{
				ObtainToolTipMainFromHostedParent(ref ToolTipMain);
			}
			//if a valid ToolTipMain object was found
			if (ToolTipMain != null)
			{
				//look for the current pointed tabpage and set its tooltiptext to the whole tabcontrol
				for (int i = 0; i < this.TabPages.Count; i++)
				{
					Rectangle r = this.GetTabRect(i);
					if (r.Contains(e.Location) && ToolTipMain.GetToolTip(this) != ToolTipMain.GetToolTip(this.TabPages[i]))
					{
						//Set ToolTip Text
						ToolTipMain.SetToolTip(this, ToolTipMain.GetToolTip(this.TabPages[i]));
						break;
					}
				}
			}
		}

		#endregion
		public string Caption
		{
			get
			{
				StringBuilder toReturn = new StringBuilder("");
				foreach (TabPage TabPage in this.TabPages)
				{
					toReturn.AppendFormat(@"&{0}|", TabPage.Text);
				}
				return toReturn.ToString();
			}
			set
			{
				Regex rx = new Regex(@"&([\w ]+)\|");
				MatchCollection matches = rx.Matches(value);

				for (int i = 0; i < matches.Count; i++)
				{
					if (i < this.TabPages.Count)
					{
						this.TabPages[i].Text = matches[i].Groups[1].Value;
					}
				}
			}
		}

		public override string Text
		{
			get
			{
				return this.Caption;
			}
			set
			{
				this.Caption = value;
			}
		}

		#region tab page enable disable implementaion
		System.Collections.Generic.Dictionary<string, bool> _enableTabPageStatus = new System.Collections.Generic.Dictionary<string, bool>();
		public void SetTabPageEnabled(int tabPageIndex, bool enabled)
		{
			string tapPageName = this.TabPages[tabPageIndex].Name;
			SetTabPageEnabled(tapPageName, enabled);
		}

		public void SetTabPageEnabled(string tabPageName, bool enabled)
		{
			if (_enableTabPageStatus.ContainsKey(tabPageName))
			{
				_enableTabPageStatus[tabPageName] = enabled;
			}
			else
			{
				_enableTabPageStatus.Add(tabPageName, enabled);
			}
		}

		public bool IsTabPageEnabled(int tabPageIndex)
		{
			string tapPageName = this.TabPages[tabPageIndex].Name;
			return IsTabPageEnabled(tapPageName);

		}
		public bool IsTabPageEnabled(string tabPageName)
		{
			if (_enableTabPageStatus.ContainsKey(tabPageName))
			{
				return _enableTabPageStatus[tabPageName];
			}
			else
			{//Assume by default enabled
				return true;
			}
		}

		protected override void OnSelecting(TabControlCancelEventArgs e)
		{
			try
			{
				base.OnSelecting(e);
				if (e.Cancel != true)
				{
					e.Cancel = !this.IsTabPageEnabled(e.TabPage.Name);
				}
			}
			catch (Exception exception)
			{

			}
		}

		#endregion


		#region Overriden

		protected override bool ProcessMnemonic(char charCode)
		{
			foreach (TabPage page in this.TabPages)
			{
				if (Control.IsMnemonic(charCode, page.Text))
				{
					this.SelectedTab = page;
					this.Focus();
					return true;
				}
			}
			return false;
		}

		/// <summary>

		protected override void OnDrawItem(DrawItemEventArgs e)
		{
		
			if(HasCustomDrawItemHandlers())
			{
				CustomDrawItem(this, e);
			}
			else
			{
                base.OnDrawItem(e);
                Graphics g = null;
                try
                {
                    DrawItemImplementation(e, g);

                }
                catch (Exception ex)
                {
                    //eat the exception.  You dont want drawing exception to bubble up.
                }
                finally
                {
                    if (g != null)
                    {
                        g.Dispose();
                    }
                }
            }
		}

		/// <summary>

		/// </summary>
		/// <param name="e"></param>
		/// <param name="g"></param>
		/// <returns></returns>
		protected virtual void DrawItemImplementation(DrawItemEventArgs e, Graphics g)
		{
			g = e.Graphics;
			StringFormat sf = new StringFormat();
			TabPage tp = this.TabPages[e.Index];
			Rectangle rt = this.GetTabRect(e.Index);

			if (e.Index == this.SelectedIndex)
			{
				//For the current Tab draw little below so that the while line
				//will disappear making the current tab stand out. Otherwise it is hard to tell which is
				// the current tab.
				Rectangle rt2 = rt;
				rt2.Inflate(0, 1);
				g.FillRectangle(System.Drawing.SystemBrushes.Control, rt2);
			}

			rt.Offset(tp.Margin.Left, tp.Margin.Top);
			if (tp.ImageIndex > -1)
			{
				Image im = this.ImageList.Images[tp.ImageIndex];
				g.DrawImage(im, rt.Left, rt.Top);
				//Ofsset the start so that the text placed properly
				rt.Offset(im.Size.Width + tp.Margin.Left, 0);
			}

			Brush drawingBrush = GetBrush(tp);

			sf.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show;
			g.DrawString(tp.Text,
						 this.Font,
						 drawingBrush,
						 rt,
						 sf);
		}
		protected virtual Brush GetBrush(TabPage tp)
		{
			Brush drawingBrush = (this.IsTabPageEnabled(tp.Name)) ? SystemBrushes.WindowText : SystemBrushes.InactiveCaption;
			return drawingBrush;
		}

		#endregion
	}
	/// <summary>
	/// TabPage helper partial class
	/// </summary>
	public static partial class TabPageHelper
	{
		/// <summary>
		/// Set the TabPage's Image based on the referenced Image Index or Image Key
		/// </summary>
		/// <param name="tabPage">TabPage where the Image should be applied</param>
		/// <param name="image">Image Index/Key from ImageList associated to the TabControl</param>
		public static void SetImageIndex(this TabPage tabPage, object image)
		{
			if (tabPage != null && tabPage.Parent != null && ((TabControl)tabPage.Parent).ImageList != null)
			{
				int imageIndex = -1;
				System.Windows.Forms.ImageList imageList = ((TabControl)tabPage.Parent).ImageList;
				if (image is string) imageIndex = imageList.Images.IndexOfKey(image.ToString());
				if (image is int) imageIndex = (int)image - 1;
				tabPage.ImageIndex = imageIndex;
			}
		}
	}
}
