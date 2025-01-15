using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using UpgradeHelpers.Helpers;

namespace UpgradeHelpers.Gui.Controls
{
    /// <summary>
    /// Extender Provider for handling CheckBox properties which are not present in .NET check boxes.
    /// </summary>
    [ProvideProperty("DownPicture", typeof(CheckBox))]
    [ProvideProperty("Style", typeof(CheckBox))]
    [ProvideProperty("DisabledPicture", typeof(CheckBox))]
    [ProvideProperty("CorrectEventsBehavior", typeof(CheckBox))]
    public partial class CheckBoxHelper : Component, IExtenderProvider, ISupportInitialize
    {
        /// <summary>
        /// Default Constructor.
        /// </summary>
        public CheckBoxHelper()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor with container.
        /// </summary>
        /// <param name="container">The container where the checkbox is included.</param>
        public CheckBoxHelper(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        /// <summary>
        /// Determinates which controls can use these extra properties.
        /// </summary>
        /// <param name="extender">The object to test.</param>
        /// <returns>True if the object can extend the properties.</returns>
        public bool CanExtend(object extender)
        {
            return extender is CheckBox;
        }

        private enum NewPropertiesEnum
        {
            CorrectEventsBehavior = 0
        }

        #region STATIC VARIABLES TO MANAGE EXTRA PROPERTIES
        private static readonly object ObjLockEvents = new object();
        private static readonly WeakDictionary<CheckBox, Image> DownPictures = new WeakDictionary<CheckBox, Image>();
        private static readonly WeakDictionary<CheckBox, Image> UpPictures = new WeakDictionary<CheckBox, Image>();
        private static readonly WeakDictionary<CheckBox, Image> DisabledPictures = new WeakDictionary<CheckBox, Image>();
        private static readonly List<CheckBox> Checked = new List<CheckBox>();
        private static readonly Queue<KeyValuePair<CheckBox, int>> SetStylePendingList = new Queue<KeyValuePair<CheckBox, int>>();
        private static readonly WeakDictionary<CheckBox, Dictionary<NewPropertiesEnum, object>> NewProperties = new WeakDictionary<CheckBox, Dictionary<NewPropertiesEnum, object>>();
        private static readonly WeakDictionary<CheckBox, Dictionary<String, List<Delegate>>> EventsPatched = new WeakDictionary<CheckBox, Dictionary<string, List<Delegate>>>();
        private static readonly Dictionary<string, Delegate> EventsToCorrect = new Dictionary<string, Delegate>();

        /// <summary>
        /// Variable for the management of the property Style.
        /// </summary>
        private static readonly WeakDictionary<CheckBox, int> Styles = new WeakDictionary<CheckBox, int>();
        #endregion

        #region INSTANCE IMPLEMENTATION FOR EXTRA PROPERTIES

        /// <summary>
        /// Instance - Gets the disabled picture bound to this checkbox.
        /// </summary>
        /// <param name="checkBox">The checkbox bound to the disabled picture.</param>
        /// <returns>The image bound for disable picture of this checkbox.</returns>
        [Description("Returns/sets a graphic to be displayed when the checkbox is disabled, if Style is set to 1")]
        public Image GetDisabledPicture(CheckBox checkBox)
        {
            return GetDisabledPictureProperty(checkBox);
        }
        /// <summary>
        /// Instance - Sets the disabled picture for a checkbox.
        /// </summary>
        /// <param name="checkBox">The checkbox to bind the disabled picture.</param>
        /// <param name="image">The iamge to use as disable picture.</param>
        public void SetDisabledPicture(CheckBox checkBox, Image image)
        {
            SetDisabledPictureProperty(checkBox, image);
        }

        /// <summary>
        /// Instance - Gets the down picture bound to this checkbox.
        /// </summary>
        /// <param name="checkBox">The checkbox bound to the down picture.</param>
        /// <returns>The image bound for down picture of this checkbox.</returns>
        [Description("Returns/sets a graphic to be displayed when the checkbox is in the down position, if Style is set to 1")]
        public Image GetDownPicture(CheckBox checkBox)
        {
            return GetDownPictureProperty(checkBox);
        }
        /// <summary>
        /// Instance - Sets the down picture for a checkbox.
        /// </summary>
        /// <param name="checkBox">The checkbox to bind the down picture.</param>
        /// <param name="image">The image to use as down picture.</param>
        public void SetDownPicture(CheckBox checkBox, Image image)
        {
            SetDownPictureProperty(checkBox, image);
        }

        /// <summary>
        /// Instance - Gets the current value of the property Style.
        /// </summary>
        /// <param name="checkBox">The checkbox to get the property.</param>
        /// <returns>The current value.</returns>
        [Description("Returns/sets the appearance of the control, whether standard (standard Windows style) or graphical (with a custom picture)")]
        public int GetStyle(CheckBox checkBox)
        {
            return GetStyleProperty(checkBox);
        }
        /// <summary>
        /// Instance - Sets the value of the property Style.
        /// </summary>
        /// <param name="checkBox">The checkbox to set the property.</param>
        /// <param name="style">The style to set.</param>
        public void SetStyle(CheckBox checkBox, int style)
        {
            SetStyleProperty(DesignMode, checkBox, style);
        }

        #endregion

        #region STATIC IMPLEMENTATION FOR EXTRA PROPERTIES

        /// <summary>
        /// Static - Gets the disabled picture bound to this checkbox.
        /// </summary>
        /// <param name="checkBox">The checkbox bound to the disabled picture.</param>
        /// <returns>The image bound for disable picture of this checkbox.</returns>
        public static Image GetDisabledPictureProperty(CheckBox checkBox)
        {
            if (!DisabledPictures.ContainsKey(checkBox))
                return null;
            return DisabledPictures[checkBox];
        }

        /// <summary>
        /// Static - Sets the disabled picture for a checkbox.
        /// </summary>
        /// <param name="checkBox">The checkbox to bind the disabled picture.</param>
        /// <param name="image">The image to use as disable picture.</param>
        public static void SetDisabledPictureProperty(CheckBox checkBox, Image image)
        {
            checkBox.EnabledChanged -= CheckBox_EnabledChanged;

            DisabledPictures[checkBox] = image;

            if (image != null)
                checkBox.EnabledChanged += CheckBox_EnabledChanged;
        }

        /// <summary>
        /// Static - Gets the down picture bound to this checkbox.
        /// </summary>
        /// <param name="checkBox">The checkbox bound to the down picture.</param>
        /// <returns>The image bound for down picture of this checkbox.</returns>
        public static Image GetDownPictureProperty(CheckBox checkBox)
        {
            if (!DownPictures.ContainsKey(checkBox))
                return null;
            return DownPictures[checkBox];
        }

        /// <summary>
        /// Static - Sets the down picture for a checkbox.
        /// </summary>
        /// <param name="checkBox">The checkbox to bind the down picture.</param>
        /// <param name="image">The image to use as down picture.</param>
        public static void SetDownPictureProperty(CheckBox checkBox, Image image)
        {
            checkBox.CheckedChanged -= CheckBox_CheckedChanged;

            DownPictures[checkBox] = image;

            if (image != null)
                checkBox.CheckedChanged += CheckBox_CheckedChanged;
        }

        /// <summary>
        /// Static - Gets the current value of the property Style.
        /// </summary>
        /// <param name="checkBox">The checkbox to get the property.</param>
        /// <returns>The current value.</returns>
        public static int GetStyleProperty(CheckBox checkBox)
        {
            if (!Styles.ContainsKey(checkBox))
                return 0;
            return Styles[checkBox];
        }

        /// <summary>
        /// Static - Sets the value of the property Style.
        /// </summary>
        /// <param name="checkBox">The checkbox to set the property.</param>
        /// <param name="style">The style to set.</param>
        public static void SetStyleProperty(CheckBox checkBox, int style)
        {
            SetStyleProperty(false, checkBox, style);
        }
        /// <summary>
        /// Static - Sets the value of the property Style.
        /// </summary>
        /// <param name="designMode">To indicate if the operation is done in design mode.</param>
        /// <param name="checkBox">The checkbox to set the property.</param>
        /// <param name="style">The style to set.</param>
        public static void SetStyleProperty(bool designMode, CheckBox checkBox, int style)
        {
            if (Checked.Contains(checkBox))
            {
                SetStylePendingList.Enqueue(new KeyValuePair<CheckBox, int>(checkBox, style));
                return;
            }

            Styles[checkBox] = (style == 0) ? 0 : 1;

            if (designMode)
                return;

            checkBox.Paint -= CheckBox_Paint;

            if ((Styles[checkBox] == 0) && (checkBox.Image != null))
            {
                if (checkBox.Checked)
                    DownPictures[checkBox] = checkBox.Image;
                else
                    UpPictures[checkBox] = checkBox.Image;
                checkBox.Image = null;
            }
            else if ((Styles[checkBox] == 1) && !checkBox.Checked && UpPictures.ContainsKey(checkBox))
                checkBox.Image = UpPictures[checkBox];
            else if ((Styles[checkBox] == 1) && checkBox.Checked && DownPictures.ContainsKey(checkBox))
                checkBox.Image = DownPictures[checkBox];

            checkBox.Appearance = (style == 1) ? Appearance.Button : Appearance.Normal;

            checkBox.Paint += CheckBox_Paint;
        }
        #endregion

        /// <summary>
        /// Paint event management so when the style is set to 0 and the checkbox has a graphic, 
        /// this is not displayed.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private static void CheckBox_Paint(object sender, PaintEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            if (Styles.ContainsKey(checkBox) && (Styles[checkBox] == 0) && (checkBox.Image != null))
            {
                if (!UpPictures.ContainsKey(checkBox) && !checkBox.Checked)
                    UpPictures[checkBox] = checkBox.Image;
                else if (!UpPictures.ContainsKey(checkBox) && checkBox.Checked)
                    DownPictures[checkBox] = checkBox.Image;
                checkBox.Image = null;
            }
        }

        /// <summary>
        /// Event handler to change the current checkbox image when the checkbox is enabled or disabled.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private static void CheckBox_EnabledChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;

            if (checkBox.Enabled)
            {
                if (!(Styles.ContainsKey(checkBox) && Styles[checkBox] == 0))
                {
                    checkBox.Image = checkBox.Checked? DownPictures[checkBox] : UpPictures[checkBox];
                }
            }
            else
            {
                if (Styles.ContainsKey(checkBox) && Styles[checkBox] == 0)
                    return;

                if (checkBox.Checked)
                    DownPictures[checkBox] = checkBox.Image;
                else
                    UpPictures[checkBox] = checkBox.Image;
                checkBox.Image = DisabledPictures[checkBox];
            }

        }

        /// <summary>
        /// Event handler to change the current Check Box image for the Original Picture or Down Picture based on Check Box Checked property.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="eventArgs">The event arguments.</param>
        private static void CheckBox_CheckedChanged(object sender, EventArgs eventArgs)
        {
            CheckBox checkBox = (CheckBox)sender;
            if (checkBox.Checked)
            {
                Checked.Add(checkBox);
                if (Styles.ContainsKey(checkBox) && Styles[checkBox] == 0)
                    return;

                UpPictures[checkBox] = checkBox.Image;
                checkBox.Image = DownPictures[checkBox];
            }
            else
            {
                if(!Checked.Contains(checkBox))
                    return;
                Checked.Remove(checkBox);

                if (!(Styles.ContainsKey(checkBox) && Styles[checkBox] == 0))
                    checkBox.Image = UpPictures[checkBox];
                
                while (SetStylePendingList.Count > 0)
                {
                    KeyValuePair<CheckBox, int> styleParameters = SetStylePendingList.Dequeue();
                    SetStyleProperty(styleParameters.Key, styleParameters.Value);
                }
            }
        }

        /// <summary>
        ///Signals the object that initialization is starting.
        /// </summary>
        public void BeginInit()
        {
            /*
             //Necessary for ISupportInitialize. 
             */
        }

        /// <summary>
        ///Signals the object that initialization is complete.
        /// </summary>
        public void EndInit()
        {
            if (!DesignMode)
            {
                CleanDeadReferences();
                CorrectEventsBehavior();
            }
        }

        /// <summary>
        /// It will clean the internal dictionaries from old references of checkboxes already disposed.
        /// </summary>
        private static void CleanDeadReferences()
        {
            try
            {
                List<CheckBox> toClean = new List<CheckBox>();
                foreach (CheckBox chk in NewProperties.Keys)
                {
                    if (chk.IsDisposed)
                        toClean.Add(chk);
                }
                foreach (CheckBox chk in toClean)
                {
                    NewProperties.Remove(chk);
                }

                toClean.Clear();
                foreach (CheckBox chk in EventsPatched.Keys)
                {
                    if (chk.IsDisposed)
                        toClean.Add(chk);
                }
                foreach (CheckBox chk in toClean)
                {
                    EventsPatched.Remove(chk);
                }
            }
            catch
            {
                //TODO: Handle exceptions
            }
        }

        #region FUNCTIONS TO PATCH THE EVENTS
        /* This is how this path of events is going to work:
         *  When in design code the property "CorrectEventsBehavior" is set to true for a specific 
         *  CheckBox, the following code will be applied at the end of execution of InitializeComponent,
         *  that means at the end of the design code.
         *  This code will:
         *      - Remove the event handlers for certains event as they were specified in design time
         *      - Add a custom event handler for the specific event being patch (defined below)
         *      - The custome events defined here will decide how and under what circunstances the
         *          original events will be called
         * 
         *  This mean that we will remove the events defined by the user and add our owns and we decide
         *  how and when to call the user defined events.
         * 
         *  Restrictions:
         *      This will path the events defined in design time, if the user specify another events in
         *      runtime code they will not be patched.
         */

        /// <summary>
        /// Deattach some events for the checkboxes in order to be managed internally.
        /// </summary>
        private static void CorrectEventsBehavior()
        {
            List<CheckBox> btnsToCorrects = new List<CheckBox>();
            lock (ObjLockEvents)
            {
                foreach (CheckBox chk in NewProperties.Keys)
                {
                    if (NewProperties[chk].ContainsKey(NewPropertiesEnum.CorrectEventsBehavior)
                        && Convert.ToBoolean(NewProperties[chk][NewPropertiesEnum.CorrectEventsBehavior]))
                    {
                        btnsToCorrects.Add(chk);
                        CorretEventsForCheckBox(chk);
                    }
                }

                foreach (CheckBox chk in btnsToCorrects)
                {
                    NewProperties[chk].Remove(NewPropertiesEnum.CorrectEventsBehavior);
                }
            }
        }

        /// <summary>
        /// Patches the events for a specific checkbox.
        /// </summary>
        /// <param name="chk">The checkbox to patch.</param>
        private static void CorretEventsForCheckBox(CheckBox chk)
        {
            if (EventsPatched.ContainsKey(chk))
                throw new InvalidOperationException("Events for this checkbox has been previously patched: '" + chk.Name + "'");

            EventsPatched.Add(chk, new Dictionary<string, List<Delegate>>());
            foreach (string eventName in EventsToCorrect.Keys)
            {
                EventInfo eventInfo = chk.GetType().GetEvent(eventName);
                if (eventInfo == null)
                    throw new InvalidOperationException("Event info for event '" + eventName + "' could not be found");

                EventsPatched[chk].Add(eventName, new List<Delegate>());
                Delegate[] eventDelegates = ContainerHelper.GetEventSubscribers(chk, eventName);
                if (eventDelegates != null)
                {

                    foreach (Delegate del in eventDelegates)
                    {
                        EventsPatched[chk][eventName].Add(del);
                        eventInfo.RemoveEventHandler(chk, del);
                    }
                }
                eventInfo.AddEventHandler(chk, EventsToCorrect[eventName]);
            }
        }
        #endregion
    }
}
