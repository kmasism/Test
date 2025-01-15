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
    /// Extender Provider for handling RadioButton properties which are not present in .NET radio buttons.
    /// </summary>
    [ProvideProperty("DownPicture", typeof(RadioButton))]
    [ProvideProperty("Style", typeof(RadioButton))]
    [ProvideProperty("DisabledPicture", typeof(RadioButton))]
    [ProvideProperty("CorrectEventsBehavior", typeof(RadioButton))]
    public partial class OptionButtonHelper : Component, IExtenderProvider, ISupportInitialize
    {
        /// <summary>
        /// Default Constructor.
        /// </summary>
        public OptionButtonHelper()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor with container.
        /// </summary>
        /// <param name="container">The container where the radiobutton is included.</param>
        public OptionButtonHelper(IContainer container)
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
            return extender is RadioButton;
        }

        private enum NewPropertiesEnum
        {
            CorrectEventsBehavior = 0
        }

        #region STATIC VARIABLES TO MANAGE EXTRA PROPERTIES
        private static readonly object ObjLockEvents = new object();
        private static readonly WeakDictionary<RadioButton, Image> DownPictures = new WeakDictionary<RadioButton, Image>();
        private static readonly WeakDictionary<RadioButton, Image> UpPictures = new WeakDictionary<RadioButton, Image>();
        private static readonly WeakDictionary<RadioButton, Image> DisabledPictures = new WeakDictionary<RadioButton, Image>();
        private static readonly List<RadioButton> Checked = new List<RadioButton>();
        private static readonly Queue<KeyValuePair<RadioButton, int>> SetStylePendingList = new Queue<KeyValuePair<RadioButton, int>>();
        private static readonly WeakDictionary<RadioButton, Dictionary<NewPropertiesEnum, object>> NewProperties = new WeakDictionary<RadioButton, Dictionary<NewPropertiesEnum, object>>();
        private static readonly WeakDictionary<RadioButton, Dictionary<String, List<Delegate>>> EventsPatched = new WeakDictionary<RadioButton, Dictionary<string, List<Delegate>>>();
        private static readonly Dictionary<string, Delegate> EventsToCorrect = new Dictionary<string, Delegate>();

        /// <summary>
        /// Variable for the management of the property Style.
        /// </summary>
        private static readonly WeakDictionary<RadioButton, int> Styles = new WeakDictionary<RadioButton, int>();
        #endregion

        #region INSTANCE IMPLEMENTATION FOR EXTRA PROPERTIES

        /// <summary>
        /// Instance - Gets the disabled picture bound to this radiobutton.
        /// </summary>
        /// <param name="radioButton">The radiobutton bound to the disabled picture.</param>
        /// <returns>The image bound for disable picture of this radiobutton.</returns>
        [Description("Returns/sets a graphic to be displayed when the radiobutton is disabled, if Style is set to 1")]
        public Image GetDisabledPicture(RadioButton radioButton)
        {
            return GetDisabledPictureProperty(radioButton);
        }
        /// <summary>
        /// Instance - Sets the disabled picture for a radiobutton.
        /// </summary>
        /// <param name="radioButton">The radiobutton to bind the disabled picture.</param>
        /// <param name="image">The iamge to use as disable picture.</param>
        public void SetDisabledPicture(RadioButton radioButton, Image image)
        {
            SetDisabledPictureProperty(radioButton, image);
        }

        /// <summary>
        /// Instance - Gets the down picture bound to this radiobutton.
        /// </summary>
        /// <param name="radioButton">The radiobutton bound to the down picture.</param>
        /// <returns>The image bound for down picture of this radiobutton.</returns>
        [Description("Returns/sets a graphic to be displayed when the radiobutton is in the down position, if Style is set to 1")]
        public Image GetDownPicture(RadioButton radioButton)
        {
            return GetDownPictureProperty(radioButton);
        }
        /// <summary>
        /// Instance - Sets the down picture for a radiobutton.
        /// </summary>
        /// <param name="radioButton">The radiobutton to bind the down picture.</param>
        /// <param name="image">The image to use as down picture.</param>
        public void SetDownPicture(RadioButton radioButton, Image image)
        {
            SetDownPictureProperty(radioButton, image);
        }

        /// <summary>
        /// Instance - Gets the current value of the property Style.
        /// </summary>
        /// <param name="radioButton">The radiobutton to get the property.</param>
        /// <returns>The current value.</returns>
        [Description("Returns/sets the appearance of the control, whether standard (standard Windows style) or graphical (with a custom picture)")]
        public int GetStyle(RadioButton radioButton)
        {
            return GetStyleProperty(radioButton);
        }
        /// <summary>
        /// Instance - Sets the value of the property Style.
        /// </summary>
        /// <param name="radioButton">The radiobutton to set the property.</param>
        /// <param name="style">The style to set.</param>
        public void SetStyle(RadioButton radioButton, int style)
        {
            SetStyleProperty(DesignMode, radioButton, style);
        }

        #endregion

        #region STATIC IMPLEMENTATION FOR EXTRA PROPERTIES

        /// <summary>
        /// Static - Gets the disabled picture bound to this radiobutton.
        /// </summary>
        /// <param name="radioButton">The radiobutton bound to the disabled picture.</param>
        /// <returns>The image bound for disable picture of this radiobutton.</returns>
        public static Image GetDisabledPictureProperty(RadioButton radioButton)
        {
            if (!DisabledPictures.ContainsKey(radioButton))
                return null;
            return DisabledPictures[radioButton];
        }

        /// <summary>
        /// Static - Sets the disabled picture for a radiobutton.
        /// </summary>
        /// <param name="radioButton">The radiobutton to bind the disabled picture.</param>
        /// <param name="image">The image to use as disable picture.</param>
        public static void SetDisabledPictureProperty(RadioButton radioButton, Image image)
        {
            radioButton.EnabledChanged -= RadioButton_EnabledChanged;

            DisabledPictures[radioButton] = image;

            if (image != null)
                radioButton.EnabledChanged += RadioButton_EnabledChanged;
        }

        /// <summary>
        /// Static - Gets the down picture bound to this radiobutton.
        /// </summary>
        /// <param name="radioButton">The radiobutton bound to the down picture.</param>
        /// <returns>The image bound for down picture of this radiobutton.</returns>
        public static Image GetDownPictureProperty(RadioButton radioButton)
        {
            if (!DownPictures.ContainsKey(radioButton))
                return null;
            return DownPictures[radioButton];
        }

        /// <summary>
        /// Static - Sets the down picture for a radiobutton.
        /// </summary>
        /// <param name="radioButton">The radioButton to bind the down picture.</param>
        /// <param name="image">The image to use as down picture.</param>
        public static void SetDownPictureProperty(RadioButton radioButton, Image image)
        {
            radioButton.CheckedChanged -= RadioButton_CheckedChanged;

            DownPictures[radioButton] = image;

            if (image != null)
                radioButton.CheckedChanged += RadioButton_CheckedChanged;
        }

        /// <summary>
        /// Static - Gets the current value of the property Style.
        /// </summary>
        /// <param name="radioButton">The radiobutton to get the property.</param>
        /// <returns>The current value.</returns>
        public static int GetStyleProperty(RadioButton radioButton)
        {
            if (!Styles.ContainsKey(radioButton))
                return 0;
            return Styles[radioButton];
        }

        /// <summary>
        /// Static - Sets the value of the property Style.
        /// </summary>
        /// <param name="radioButton">The radiobutton to set the property.</param>
        /// <param name="style">The style to set.</param>
        public static void SetStyleProperty(RadioButton radioButton, int style)
        {
            SetStyleProperty(false, radioButton, style);
        }
        /// <summary>
        /// Static - Sets the value of the property Style.
        /// </summary>
        /// <param name="designMode">To indicate if the operation is done in design mode.</param>
        /// <param name="radioButton">The radiobutton to set the property.</param>
        /// <param name="style">The style to set.</param>
        public static void SetStyleProperty(bool designMode, RadioButton radioButton, int style)
        {
            if (Checked.Contains(radioButton))
            {
                SetStylePendingList.Enqueue(new KeyValuePair<RadioButton, int>(radioButton, style));
                return;
            }

            Styles[radioButton] = (style == 0) ? 0 : 1;

            if (designMode)
                return;

            radioButton.Paint -= RadioButton_Paint;

            if ((Styles[radioButton] == 0) && (radioButton.Image != null))
            {
                if (radioButton.Checked)
                    DownPictures[radioButton] = radioButton.Image;
                else
                    UpPictures[radioButton] = radioButton.Image;
                radioButton.Image = null;
            }
            else if ((Styles[radioButton] == 1) && !radioButton.Checked && UpPictures.ContainsKey(radioButton))
                radioButton.Image = UpPictures[radioButton];
            else if ((Styles[radioButton] == 1) && radioButton.Checked && DownPictures.ContainsKey(radioButton))
                radioButton.Image = DownPictures[radioButton];

            radioButton.Appearance = (style == 1) ? Appearance.Button : Appearance.Normal;

            radioButton.Paint += RadioButton_Paint;
        }
        #endregion

        /// <summary>
        /// Paint event management so when the style is set to 0 and the radiobutton has a graphic, 
        /// this is not displayed.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private static void RadioButton_Paint(object sender, PaintEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (Styles.ContainsKey(radioButton) && (Styles[radioButton] == 0) && (radioButton.Image != null))
            {
                if (!UpPictures.ContainsKey(radioButton) && !radioButton.Checked)
                    UpPictures[radioButton] = radioButton.Image;
                else if (!UpPictures.ContainsKey(radioButton) && radioButton.Checked)
                    DownPictures[radioButton] = radioButton.Image;
                radioButton.Image = null;
            }
        }

        /// <summary>
        /// Event handler to change the current radiobutton image when the radiobutton is enabled or disabled.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private static void RadioButton_EnabledChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;

            if (radioButton.Enabled)
            {
                if (!(Styles.ContainsKey(radioButton) && Styles[radioButton] == 0))
                {
                    radioButton.Image = radioButton.Checked? DownPictures[radioButton] : UpPictures[radioButton];
                }
            }
            else
            {
                if (Styles.ContainsKey(radioButton) && Styles[radioButton] == 0)
                    return;

                if (radioButton.Checked)
                    DownPictures[radioButton] = radioButton.Image;
                else
                    UpPictures[radioButton] = radioButton.Image;
                radioButton.Image = DisabledPictures[radioButton];
            }

        }

        /// <summary>
        /// Event handler to change the current radio button image for the Original Picture or Down Picture based on Radio Button Checked property.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="eventArgs">The event arguments.</param>
        private static void RadioButton_CheckedChanged(object sender, EventArgs eventArgs)
        {
            RadioButton radioButton = (RadioButton)sender;

            if (radioButton.Checked)
            {
                Checked.Add(radioButton);
                if (Styles.ContainsKey(radioButton) && Styles[radioButton] == 0)
                    return;

                UpPictures[radioButton] = radioButton.Image;
                radioButton.Image = DownPictures[radioButton];
            }
            else
            {
                if (!Checked.Contains(radioButton))
                    return;
                Checked.Remove(radioButton);

                if (!(Styles.ContainsKey(radioButton) && Styles[radioButton] == 0))
                    radioButton.Image = UpPictures[radioButton];

                while (SetStylePendingList.Count > 0)
                {
                    KeyValuePair<RadioButton, int> styleParameters = SetStylePendingList.Dequeue();
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
        /// It will clean the internal dictionaries from old references of radiobuttons already disposed.
        /// </summary>
        private static void CleanDeadReferences()
        {
            try
            {
                List<RadioButton> toClean = new List<RadioButton>();
                foreach (RadioButton rdbtn in NewProperties.Keys)
                {
                    if (rdbtn.IsDisposed)
                        toClean.Add(rdbtn);
                }
                foreach (RadioButton rdbtn in toClean)
                {
                    NewProperties.Remove(rdbtn);
                }

                toClean.Clear();
                foreach (RadioButton rdbtn in EventsPatched.Keys)
                {
                    if (rdbtn.IsDisposed)
                        toClean.Add(rdbtn);
                }
                foreach (RadioButton rdbtn in toClean)
                {
                    EventsPatched.Remove(rdbtn);
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
         *  RadioButton, the following code will be applied at the end of execution of InitializeComponent,
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
        /// Deattach some events for the radiobuttons in order to be managed internally.
        /// </summary>
        private static void CorrectEventsBehavior()
        {
            List<RadioButton> rdbtnsToCorrects = new List<RadioButton>();
            lock (ObjLockEvents)
            {
                foreach (RadioButton rdBtn in NewProperties.Keys)
                {
                    if (NewProperties[rdBtn].ContainsKey(NewPropertiesEnum.CorrectEventsBehavior)
                        && Convert.ToBoolean(NewProperties[rdBtn][NewPropertiesEnum.CorrectEventsBehavior]))
                    {
                        rdbtnsToCorrects.Add(rdBtn);
                        CorretEventsForRadioButton(rdBtn);
                    }
                }

                foreach (RadioButton rdBtn in rdbtnsToCorrects)
                {
                    NewProperties[rdBtn].Remove(NewPropertiesEnum.CorrectEventsBehavior);
                }
            }
        }

        /// <summary>
        /// Patches the events for a specific radiobutton.
        /// </summary>
        /// <param name="rdbtn">The radiobutton to patch.</param>
        private static void CorretEventsForRadioButton(RadioButton rdBtn)
        {
            if (EventsPatched.ContainsKey(rdBtn))
                throw new InvalidOperationException("Events for this radiobutton has been previously patched: '" + rdBtn.Name + "'");

            EventsPatched.Add(rdBtn, new Dictionary<string, List<Delegate>>());
            foreach (string eventName in EventsToCorrect.Keys)
            {
                EventInfo eventInfo = rdBtn.GetType().GetEvent(eventName);
                if (eventInfo == null)
                    throw new InvalidOperationException("Event info for event '" + eventName + "' could not be found");

                EventsPatched[rdBtn].Add(eventName, new List<Delegate>());
                Delegate[] eventDelegates = ContainerHelper.GetEventSubscribers(rdBtn, eventName);
                if (eventDelegates != null)
                {

                    foreach (Delegate del in eventDelegates)
                    {
                        EventsPatched[rdBtn][eventName].Add(del);
                        eventInfo.RemoveEventHandler(rdBtn, del);
                    }
                }
                eventInfo.AddEventHandler(rdBtn, EventsToCorrect[eventName]);
            }
        }
        #endregion
    }
}
