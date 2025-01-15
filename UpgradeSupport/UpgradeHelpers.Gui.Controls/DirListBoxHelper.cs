using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
namespace UpgradeHelpers.Gui.Controls
{
    /// <summary>
    /// DirListBoxHelper emulates the VB6 DirListBox VB6 control 
    /// </summary>
    public class DirListBoxHelper : ListBox
    {
        #region "Declarations"

        private string m_path;
        private int m_level;
        private bool m_indexChanged;

        #endregion

        #region "Constructors"
        /// <summary>
        /// Constructor
        /// </summary>
        public DirListBoxHelper()
        {
            DrawMode = DrawMode.OwnerDrawFixed;
			m_path = Directory.Exists("C:\\WINDOWS\\System32") ? "C:\\WINDOWS\\System32" : Directory.GetCurrentDirectory();
			UpdateList();
        }

		#endregion

		#region "Public properties"

		/// <summary>
		/// Returns/sets the current path.
		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public string Path
        {
            get
            {
                return m_path;
            }
            set
            {
                if (value != m_path)
                {
                    SetPath(value);
                }
            }
        }

        /// <summary>
        /// Returns/sets the items contained in a control's list portion.
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Items contained in list portion</returns>
        public string DirList(int index)
        {
            return SetNewDirPath(checked(index), false);
        }

        /// <summary>
        /// Returns the number of items in the list portion of a control.
        /// </summary>
        public int DirListCount
        {
            get
            {
                return checked(Items.Count - m_level);
            }
        }

        /// <summary>
        /// Returns/sets the index of the currently selected item in the control.
        /// </summary>
        public int DirListIndex
        {
            get
            {
                return checked(SelectedIndex - m_level);
            }
            set
            {
                int num = checked(value + m_level);
                if (num == SelectedIndex)
                {
                    if (num < 0)
                    {
                        throw new IndexOutOfRangeException();
                    }

                    SelectedIndex = num;
                    OnClick(EventArgs.Empty);
                }
            }
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

		#endregion

		#region "Public events"
		protected virtual void OnPathChange(EventArgs e)
        {
            if( PathChangeEvent != null)
            {
                PathChangeEvent.Invoke(this, e);
            }
        }

        private EventHandler PathChangeEvent;

        public event EventHandler PathChange
        {
            add
            {
                EventHandler eventHandler = PathChangeEvent;
                EventHandler eventHandler2;
                do
                {
                    eventHandler2 = eventHandler;
                    EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
                    eventHandler = Interlocked.CompareExchange(ref PathChangeEvent, value2, eventHandler2);
                }
                while ((object)eventHandler != eventHandler2);
            }
            remove
            {
                EventHandler eventHandler = PathChangeEvent;
                EventHandler eventHandler2;
                do
                {
                    eventHandler2 = eventHandler;
                    EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
                    eventHandler = Interlocked.CompareExchange(ref PathChangeEvent, value2, eventHandler2);
                }
                while ((object)eventHandler != eventHandler2);
            }
        }

        protected override void OnDoubleClick(EventArgs e)
        {
            try
            {
                string dirPath = SetNewDirPath(SelectedIndex, true);
                SetPath(dirPath);
            }
            catch
            {

            }
            base.OnDoubleClick(e);
        }

        #endregion


        #region "Private methods"
        /// <summary>
        /// Sets the new path when the double click event is triggered or the path property is changed.
        /// </summary>
        /// <param name="text">New path to be used</param>
        private void SetPath(string text)
        {
            if(text.Contains("\\\\"))
            {
                throw new DirectoryNotFoundException("Directory " + text + " not found");
            }
            if (text.EndsWith("]") || text.EndsWith(":"))
            {
                text = Helpers.StringsHelper.Left(text, 1).ToLower();
                text += ":" + System.IO.Path.DirectorySeparatorChar;
            }
            if (text.Length > 0 && Directory.Exists(text))
            {
                m_path = text;
                UpdateList();
                OnPathChange(EventArgs.Empty);
            }
            else
            {
                //Do nothing //throw new DirectoryNotFoundException("Directory " + text + " not found");
            }
        }

        /// <summary>
        /// Refresh the current control's list.
        /// </summary>
        private void UpdateList()
        {
            BeginUpdate();
            Items.Clear();

            SetIndexLevel();

            ArrayList FoldersArray = ProcessPath(m_path);

            foreach (var folder in FoldersArray)
            {
                Items.Add(folder);
            }

            EndUpdate();
            SetCurrentIndex();
        }

        /// <summary>
        /// Sets the current index after update the control's list with the new elements.
        /// </summary>
        private void SetCurrentIndex()
        {
            bool isChanged = m_indexChanged;
            m_indexChanged = true;
            TopIndex = 0;
            SelectedIndex = checked(m_level - 1);
            m_indexChanged = isChanged;
        }

        /// <summary>
        /// Sets the index level before update the control's list with the new elements.
        /// </summary>
        private void SetIndexLevel()
        {
            m_level = 0;
            if (m_path.EndsWith("\\"))
            {
                m_path = m_path.Remove(m_path.Length - 1);
            }
            string[] currentDirectories = m_path.Split('\\');
            m_level = currentDirectories.Length;
        }

        /// <summary>
        /// Processes the path to get the folders and subfolders to be shown in the control.
        /// </summary>
        /// <param name="path"></param>
        /// <returns>An ArrayList with the new elements to be shown.</returns>
        private ArrayList ProcessPath(string path)
        {
            ArrayList result = new ArrayList();
            DirectoryInfo dir;

            if (path.EndsWith(":") || path.EndsWith(":\\"))
            {
                if (path.EndsWith(":"))
                {
                    path += '\\';
                }
                dir = new DirectoryInfo(path);
                result.Add(dir.Name);

                if (HasSubDirectories(path))
                {
                    AddSubDirectories(path, result);
                }

                return result;
            }

            string[] folderList = path.Split('\\');
            for (int i = 0; i < folderList.Length; i++)
            {
                string currentPath;
                int index = i + 1;
                string[] newPathArray = new string[index];
                for (int j = 0; j < index; j++)
                {
                    newPathArray[j] = folderList[j];
                }
                currentPath = System.IO.Path.Combine(newPathArray);
                dir = new DirectoryInfo(currentPath + '\\');
                result.Add(dir.Name);
                if (i == folderList.Length - 1)
                {
                    if (HasSubDirectories(path))
                    {
                        AddSubDirectories(path, result);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Sets a new path when the Double Click event is triggered.
        /// </summary>
        /// <param name="selectedIndex">Index of the selected element.</param>
        /// <param name="generateNewPath">True is a new path will be generated, false otherwise.</param>
        /// <returns>The new path to be used.</returns>
        private string SetNewDirPath(int selectedIndex, bool generateNewPath)
        {
            if (m_path.EndsWith(":"))
            {
                m_path += '\\';
            }
            if (selectedIndex < 0 || selectedIndex > Items.Count)
            {
                //Do nothing //throw new IndexOutOfRangeException("The selected value " + selectedIndex + " is out of range");
            }

            string[] subDirectories = Directory.GetDirectories(m_path);

            if (generateNewPath)
            {
                if (m_level > selectedIndex)
                {
                    int newIndex = selectedIndex + 1;
                    string[] fullPathDirectories = m_path.Split('\\');
                    string[] selectedIndexDirectories = new string[newIndex];
                    for (int i = 0; i < newIndex; i++)
                    {
#if !NET_CORE_APP
                        if (fullPathDirectories[i].EndsWith(":"))
                        {
                            fullPathDirectories[i] = fullPathDirectories[i] + "\\";
                        }
#endif 
                        selectedIndexDirectories[i] = fullPathDirectories[i];
                    }
                    m_path = System.IO.Path.Combine(selectedIndexDirectories);
                }
                else
                {
                    DirectoryInfo dir;
                    for (int i = 0; i <= subDirectories.Length - 1; i++)
                    {
                        dir = new DirectoryInfo(subDirectories[i]);
                        if (dir.Name == Convert.ToString(SelectedItem))
                        {
                            m_path = dir.FullName;
                            break;
                        }
                    }

                }
            }
            else
            {
                ArrayList ExpectedDirectories = new ArrayList();
                foreach (string subDir in subDirectories)
                {
                    DirectoryInfo dir = new DirectoryInfo(subDir);
                    FileAttributes attributes = dir.Attributes;
                    if (IsValidDirectory(subDir, attributes))
                    {
                        ExpectedDirectories.Add(subDir);
                    }
                }
                var elements = ExpectedDirectories.ToArray();
                try
                {
                    return Convert.ToString(elements[selectedIndex]);
                }
                catch
                {
                    return "";
                }
            }

            return m_path;
        }

        /// <summary>
        /// Add the subdirectories for a specific folder.
        /// </summary>
        /// <param name="path">Parent folder.</param>
        /// <param name="result">ArrayList with the previous elements where the subdirectories will be added.</param>
        private static void AddSubDirectories(string path, ArrayList result)
        {
            string[] subDirectories = Directory.GetDirectories(path);
            foreach (string subDir in subDirectories)
            {
                DirectoryInfo dir = new DirectoryInfo(subDir);
                FileAttributes attributes = dir.Attributes;

                if (IsValidDirectory(subDir, attributes))
                {
                    result.Add(dir.Name);
                }
            }
        }

        /// <summary>
        /// Verifies if a directory should be displayed or added to the control.
        /// </summary>
        /// <param name="subDir"></param>
        /// <param name="attributes"></param>
        /// <returns>True if the directory is valid, false otherwise.</returns>
        private static bool IsValidDirectory(string subDir, FileAttributes attributes)
        {
            return ((attributes & FileAttributes.Hidden) != FileAttributes.Hidden) && (!subDir.ToLower().Contains("$recycle"));
        }

        private bool HasSubDirectories(string folder)
        {
            string[] directories = Directory.GetDirectories(folder);
            if (directories.Length > 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Draws the icons and text for each folder.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                int num = (int)Math.Round((double)e.Graphics.MeasureString(" ", Font).Width + 0.5);
                if (num < 1)
                {
                    num = 1;
                }

                Icon icon;
                string element = Convert.ToString(Items[e.Index]);

                int num2;
                if (e.Index < m_level)
                {
                    icon = ShellIcons.FolderOpened;
                    num2 = num * e.Index;
                }
                else
                {
                    icon = ShellIcons.FolderClosed;
                    num2 = num * m_level;
                }

                Rectangle iconDraw = new Rectangle(e.Bounds.X + num2, e.Bounds.Y, e.Bounds.Height, e.Bounds.Height);

                e.DrawBackground();
                e.Graphics.DrawIcon(icon, iconDraw);

                icon.Dispose();

                e.Graphics.DrawString(element, e.Font, new SolidBrush(e.ForeColor), iconDraw.X + (num * 3), iconDraw.Y);// e.Bounds.X + iconDraw.Width + 1, e.Bounds.Y); ;

                if (e.State == DrawItemState.Focus)
                {
                    e.DrawFocusRectangle();
                }
            }
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            if (!m_indexChanged)
            {
                base.OnSelectedIndexChanged(e);
            }
        }

        #endregion
    }
}
