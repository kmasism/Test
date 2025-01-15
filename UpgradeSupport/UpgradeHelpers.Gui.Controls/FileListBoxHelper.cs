using System;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace UpgradeHelpers.Gui.Controls
{
    /// <summary>
    /// FileListBoxHelper emulates the FileListBox VB6 control 
    /// </summary>
    public class FileListBoxHelper : ListBox
    {
        #region "Declarations"

        private string m_path;
        private string m_pattern;
        private bool m_archive;
        private bool m_hidden;
        private bool m_normal;
        private bool m_system;
        private bool m_readonly;
        private string m_filename;

        #endregion

        #region "Constructors"

        /// <summary>
        /// Constructor.
        /// </summary>
        public FileListBoxHelper()
        {
            m_archive = true;
            m_normal = true;
            m_readonly = true;
			m_path = Directory.Exists("C:\\WINDOWS\\System32") ? "C:\\WINDOWS\\System32" : Directory.GetCurrentDirectory();
			m_pattern = "*.*";
            m_hidden = false;
            m_system = false;
            UpdateList();
        }

		#endregion

		#region "Public properties"

		/// <summary>
		/// Returns/sets the current path.
		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public string CurrentPath
        {
            get
            {
                return m_path;
            }
            set
            {
                if (value != m_path)
                {
                    ProcessPath(value);
                }
            }
        }

        /// <summary>
        /// Returns/sets a value indicating the filenames displayed in a control at run time.
        /// </summary>
        public string Pattern
        {
            get
            {
                return m_pattern;
            }
            set
            {
                if (value != m_pattern)
                {
                    SetPattern(value);
                }
            }
        }

        /// <summary>
        /// Determines whether the control displays files with Hidden attributes.
        /// </summary>
        public bool Hidden
        {
            get
            {
                return m_hidden;
            }
            set
            {
                if (value != m_hidden)
                {
                    m_hidden = value;
                    UpdateList();
                }
            }
        }
        /// <summary>
        /// Determines whether the control displays files with Archive attributes.
        /// </summary>
        public bool Archive
        {
            get
            {
                return m_archive;
            }
            set
            {
                if (value != m_archive)
                {
                    m_archive = value;
                    UpdateList();
                }
            }
        }

        /// <summary>
        /// Determines whether the control displays files with Normal attributes.
        /// </summary>
        public bool Normal
        {
            get
            {
                return m_normal;
            }
            set
            {
                if (value != m_normal)
                {
                    m_normal = value;
                    UpdateList();
                }
            }
        }

        /// <summary>
        /// Determines whether the control displays files with System attributes.
        /// </summary>
        public bool System
        {
            get
            {
                return m_system;
            }
            set
            {
                if (value != m_system)
                {
                    m_system = value;
                    UpdateList();
                }
            }
        }

        /// <summary>
        /// Determines whether the control displays files with ReadOnly attributes.
        /// </summary>
        public bool ReadOnly
        {
            get
            {
                return m_readonly;
            }
            set
            {
                if (value != m_readonly)
                {
                    m_readonly = value;
                    UpdateList();
                }
            }
        }

		/// <summary>
		/// Returns/sets the path and filename of a selected file.
		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public string FileName
        {
            get
            {
                return Text;
            }
            set
            {
                if (value != m_filename)
                {
                    SetPattern(value);
                    if (value != "" && Items.Count > 0)
                    {
                        SelectedIndex = 0;
                    }
                    m_filename = Convert.ToString(SelectedValue);
                }
            }
        }

        /// <summary>
        /// Returns/sets the items contained in a control's list portion.
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Items contained in a list portion.</returns>
        public string List(int index)
        {
            try
            {
                return Convert.ToString(Items[index]);
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// Returns the selection status of an item in a control.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool Selected(int index)
        {
            try
            {
                return GetSelected(index);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Sets the selection status of an item in a control.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Selected(int index, bool value)
        {
            try
            {
                SetSelected(index, value);
            }
            catch
            {
                //Do nothing.
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

        #endregion

        #region "Events"

        /// <summary>
        /// Occurs when the path is changed by setting the FileName or Path property in code.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnPathChange(EventArgs e)
        {
            if (PathChangeEvent != null)
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

        /// <summary>
        /// Occurs when the file listing pattern, such as *.*, is changed using FileName or Pattern in code.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnPatternChange(EventArgs e)
        {
            if (PatternChangeEvent != null)
            {
                PatternChangeEvent.Invoke(this, e);
            }
        }

        private EventHandler PatternChangeEvent;

        public event EventHandler PatternChange
        {
            add
            {
                EventHandler eventHandler = PatternChangeEvent;
                EventHandler eventHandler2;
                do
                {
                    eventHandler2 = eventHandler;
                    EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
                    eventHandler = Interlocked.CompareExchange(ref PatternChangeEvent, value2, eventHandler2);
                }
                while ((object)eventHandler != eventHandler2);
            }
            remove
            {
                EventHandler eventHandler = PatternChangeEvent;
                EventHandler eventHandler2;
                do
                {
                    eventHandler2 = eventHandler;
                    EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
                    eventHandler = Interlocked.CompareExchange(ref PatternChangeEvent, value2, eventHandler2);
                }
                while ((object)eventHandler != eventHandler2);
            }
        }

        #endregion

        #region "Private methods"

        /// <summary>
        /// Processes the path to get the files in the folder
        /// </summary>
        /// <param name="text"></param>
        private void ProcessPath(string text)
        {
            if (text.EndsWith(":"))
            {
                text = text + Path.DirectorySeparatorChar;
            }
            if (text.Length > 0 && Directory.Exists(text))
            {
                DirectoryInfo dir = new DirectoryInfo(text);
                m_path = dir.FullName;
                UpdateList();
                OnPathChange(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Sets the pattern to be used.
        /// </summary>
        /// <param name="value"></param>
        private void SetPattern(string value)
        {
            string[] directoriesSplitted = value.Split(Path.DirectorySeparatorChar);
            if (m_path.EndsWith("\\"))
            {
                m_path = m_path.Remove(m_path.Length - 1);
            }
            string[] fullPathDirectories = m_path.Split('\\');
            string newPath = m_path;
            if (directoriesSplitted.Length > 1)
            {
                value = directoriesSplitted[directoriesSplitted.Length - 1];
                for (int i = 0; i < directoriesSplitted.Length - 1; i++)
                {
                    if (directoriesSplitted[i] == "..")
                    {
                        newPath = SetNewCurrentPath(fullPathDirectories, newPath);
                    }
                    else
                    {
                        newPath = Path.Combine(newPath, directoriesSplitted[i]);
                    }
                }
            }
            else if(value == "..")
            {
                newPath = SetNewCurrentPath(fullPathDirectories, newPath);
                value = "*.*";
            }

            DirectoryInfo dir = new DirectoryInfo(newPath);
            CurrentPath = dir.FullName;

            m_pattern = value;
            UpdateList();
            OnPatternChange(EventArgs.Empty);
        }

        /// <summary>
        /// Returns a new path after modifying the current.
        /// </summary>
        /// <param name="fullPathDirectories"></param>
        /// <param name="newPath"></param>
        /// <returns></returns>
        private static string SetNewCurrentPath(string[] fullPathDirectories, string newPath)
        {
            for (int j = 0; j < fullPathDirectories.Length - 1; j++)
            {
#if !NET_CORE_APP
                if (fullPathDirectories[j].EndsWith(":"))
                {
                    fullPathDirectories[j] += "\\";
                }
#endif
                newPath = Path.Combine(newPath, fullPathDirectories[j]);
            }

            return newPath;
        }

        /// <summary>
        /// Refresh the current control's list.
        /// </summary>
        private void UpdateList()
        {
            BeginUpdate();
            Items.Clear();

            FileAttributes attributes;
            try
            {
                foreach (string file in Directory.GetFiles(m_path, m_pattern))
                {
                    attributes = File.GetAttributes(file);
                    if (Archive && (attributes & FileAttributes.Archive) == FileAttributes.Archive)
                    {
                        AddFile(file);
                    }
                    else if (Hidden && (attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                    {
                        AddFile(file);
                    }
                    else if (Normal && (attributes & FileAttributes.Normal) == FileAttributes.Normal)
                    {
                        AddFile(file);
                    }
                    else if (ReadOnly && (attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                    {
                        AddFile(file);
                    }
                    else if (System && (attributes & FileAttributes.System) == FileAttributes.System)
                    {
                        AddFile(file);
                    }
                }
            }
            catch
            {
                //Do nothing.
            }

            EndUpdate();
        }

        /// <summary>
        /// Add the current file to the control.
        /// </summary>
        /// <param name="file"></param>
        private void AddFile(string file)
        {
            if (!Items.Contains(file))
            {
                Items.Add(Path.GetFileName(file));
            }
        }

        #endregion
    }
}
