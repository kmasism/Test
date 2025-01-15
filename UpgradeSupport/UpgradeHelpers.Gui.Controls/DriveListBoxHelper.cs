using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using UpgradeHelpers.Helpers;

namespace UpgradeHelpers.Gui.Controls
{
    /// <summary>
    /// DriveListBoxHelper emulates the DriveListBox VB6 control 
    /// </summary>
    public class DriveListBoxHelper : ComboBox
    {
        #region "Declarations"

        private string m_LastDrive;
        private int m_LastIndex;

        #endregion

        #region "Constructors"

        /// <summary>
        /// Constructor.
        /// </summary>
        public DriveListBoxHelper()
        {
            DrawMode = DrawMode.OwnerDrawFixed;
            DropDownStyle = ComboBoxStyle.DropDownList;
            RefreshList();
            OnSelectedIndexChanged(new EventArgs());
        }

		#endregion

		#region "Public properties"

		/// <summary>
		/// Returns/sets the selected drive at runtime.
		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public string Drive
        {
            get
            {
                if (SelectedIndex >= 0 && SelectedIndex < Items.Count)
                {
                    return GetItem(SelectedIndex);
                }

                return "";
            }
            set
            {
                SetDrive(value);
            }
        }

        /// <summary>
        /// Returns/sets the items contained in a control's list portion.
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Items contained in a list portion.</returns>
        public string List(int index)
        {
            return Convert.ToString(Items[index]).ToLower();
        }

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public new ObjectCollection Items
        {
            get
            {
                return base.Items;
            }
        }

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
        public new DrawMode DrawMode
        {
            get
            {
                return base.DrawMode;
            }
            set
            {
                base.DrawMode = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public new ComboBoxStyle DropDownStyle
        {
            get
            {
                return base.DropDownStyle;
            }
            set
            {
                base.DropDownStyle = value;
            }
        }

		#endregion

		#region "Private methods"

		/// <summary>
		/// </summary>
		/// <param name="index"></param>
		/// <returns>Returns the selected item.</returns>
		private string GetItem(int index)
        {
            try
            {
                DriveInfo drive = new DriveInfo(Convert.ToString(Items[index]));

                return GetDriveName(drive);
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// Sets the new drive when the Drive property is changed.
        /// </summary>
        /// <param name="text"></param>
        private void SetDrive(string text)
        {
            if (text.Length == 0)
            {
                throw new ArgumentException("Drive can't be null or empty");
            }
            if (!text.Equals(SelectedItem))
            {
                text = StringsHelper.Left(text, 1).ToLower();
                string text2 = text + ":";
                string currentDirectory = Directory.GetCurrentDirectory();
                string Drive = text + ":\\";

                try
                {
                    Directory.SetCurrentDirectory(Drive);
                }
                catch
                {
                    throw new ArgumentException("Drive does not exists");
                }
                finally
                {
                    Directory.SetCurrentDirectory(currentDirectory);
                }

                int selectedIndex = -1;
                int index;
                for (index = 0; index <= Items.Count - 1; index++)
                {
                    if (StringsHelper.BinaryCompare(StringsHelper.Left(Convert.ToString(Items[index]).ToLower(), 2), text2) == 0)
                    {
                        selectedIndex = index;
                        break;
                    }
                }
                SelectedIndex = selectedIndex;

                OnSelectedIndexChanged(new EventArgs());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void RefreshList()
        {
            try
            {
                ResetList();
                string drive = Text;
                if (string.IsNullOrEmpty(drive))
                {
                    drive = "c";
                }
                SetDrive(drive);
            }
            catch
            {
                SetCurrentDrive();
            }
        }

        /// <summary>
        /// Sets the current selected drive.
        /// </summary>
        private void SetCurrentDrive()
        {
            string Drive;
            try
            {
                Drive = StringsHelper.Left(Directory.GetCurrentDirectory(), 1);
            }
            catch
            {
                Drive = "c";
            }
            SetDrive(Drive);
        }

        /// <summary>
        /// Refresh the current control's list.
        /// </summary>
        private void ResetList()
        {
            BeginUpdate();
            Items.Clear();

            foreach (string LogicalDrive in Directory.GetLogicalDrives())
            {
                string name = LogicalDrive.Remove(2);
                Items.Add(name);
            }

            EndUpdate();
        }

        /// <summary>
        /// </summary>
        /// <param name="driveInfo"></param>
        /// <returns>Returns the drive label</returns>
        private string GetDriveName(DriveInfo driveInfo)
        {
            string DriveName = driveInfo.Name.Remove(2).ToLower();

            if (driveInfo.IsReady)
            {
                string DriveLabel = driveInfo.VolumeLabel;
                if (!string.IsNullOrEmpty(DriveLabel))
                {
                    DriveName = DriveName + " [" + DriveLabel + "]";
                }
            }

            return DriveName;
        }

        #endregion

        #region "Events"

        /// <summary>
        /// Draws the icons and text for each element.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index != -1)
            {
                DriveInfo driveInfo = new DriveInfo(Convert.ToString(Items[e.Index]));
                Icon icon;

                DriveType driveType = driveInfo.DriveType;
                switch (driveType)
                {
                    case DriveType.Removable:
                        icon = ShellIcons.Removable;
                        break;
                    case DriveType.Fixed:
                        icon = ShellIcons.Fixed;
                        break;
                    case DriveType.Network:
                        icon = ShellIcons.Network;
                        break;
                    case DriveType.CDRom:
                        icon = ShellIcons.CDRom;
                        break;
                    case DriveType.Ram:
                        icon = ShellIcons.Ram;
                        break;
                    default:
                        icon = ShellIcons.Unknown;
                        break;
                }

                Rectangle iconDraw = new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Height, e.Bounds.Height);

                e.DrawBackground();
                e.Graphics.DrawIcon(icon, iconDraw);

                icon.Dispose();
                string DriveName = GetDriveName(driveInfo);
                e.Graphics.DrawString(DriveName, e.Font, new SolidBrush(e.ForeColor), e.Bounds.X + iconDraw.Width + 1, e.Bounds.Y);

                if (e.State == DrawItemState.Focus)
                {
                    e.DrawFocusRectangle();
                }
            }
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            if (string.IsNullOrEmpty(m_LastDrive))
            {
                m_LastDrive = "";
            }
            if (!m_LastDrive.Equals(SelectedItem) || (m_LastIndex != SelectedIndex))
            {
                m_LastDrive = Convert.ToString(SelectedItem);
                m_LastIndex = SelectedIndex;
                base.OnSelectedIndexChanged(e);
            }
        }

        #endregion

    }

    #region "Get Shell32 Icons"

    /// <summary>
    /// Additional class to get the icons to be used with the DriveListBox and FileListBox controls.
    /// </summary>
    static class ShellIcons
    {
        [DllImport("shell32.dll", EntryPoint = "ExtractIcon")]
        extern static IntPtr ExtractIcon(IntPtr hInst, string lpszExeFileName, int nIconIndex);

        const string IconsLib = "C:\\Windows\\System32\\shell32.dll";

        /// <summary>
        /// Gets the icon for each element.
        /// </summary>
        /// <param name="index"></param>
        /// <returns>An icon</returns>
        static private Icon GetIcon(int index)
        {
            IntPtr hIcon = ExtractIcon(IntPtr.Zero, IconsLib, index);
            Icon icon = Icon.FromHandle(hIcon);

            return icon;
        }

        /// <summary>
        /// Returns the icon to be used with Closed folders.
        /// </summary>
        static public Icon FolderClosed
        {
            get
            {
                return GetIcon(3);
            }
        }

        /// <summary>
        /// Returns the icon to be used with Opened folders.
        /// </summary>
        static public Icon FolderOpened
        {
            get
            {
                return GetIcon(4);
            }
        }

        /// <summary>
        /// Returns the icon to be used with Unknown drives.
        /// </summary>
        static public Icon Unknown
        {
            get
            {
                return GetIcon(53);
            }
        }

        /// <summary>
        /// Returns the icon to be used with Removable drives.
        /// </summary>
        static public Icon Removable
        {
            get
            {
                return GetIcon(7);
            }
        }

        /// <summary>
        /// Returns the icon to be used with Hard-Disk drives.
        /// </summary>
        static public Icon Fixed
        {
            get
            {
                return GetIcon(8);
            }
        }

        /// <summary>
        /// Returns the icon to be used with Network drives.
        /// </summary>
        static public Icon Network
        {
            get
            {
                return GetIcon(9);
            }
        }

        /// <summary>
        /// Returns the icon to be used with Reading/Writting drives.
        /// </summary>
        static public Icon CDRom
        {
            get
            {
                return GetIcon(11);
            }
        }

        /// <summary>
        /// Returns the icon to be used with RAM drives.
        /// </summary>
        static public Icon Ram
        {
            get
            {
                return GetIcon(12);
            }
        }

        #endregion
    }
}
