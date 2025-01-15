using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace UpgradeHelpers.Gui.Controls
{
    /// <summary>
    /// UpDownHelper emulates the UpDown VB6 control 
    /// </summary>
    public class UpDownHelper : VScrollBar
    {
        #region "Declarations"

        private PropertyInfo buddyProperty;
        private int _value;
        private bool Increased;

        #endregion

        #region "Constructors"
        /// <summary>
        /// Constructor
        /// </summary>
        public UpDownHelper()
        {
            buddyProperty = null;
            SyncBuddy = true;
            Increment = 1;
            Max = 10;
            Min = 0;
            _value = 0;
            Wrap = false;
        }

        #endregion

        #region "Public properties"

        /// <summary>
        /// Get/Set which property to use to sync with Buddy Control
        /// </summary>
        public string BuddyProperty
        {
            get
            {
                if (buddyProperty != null)
                {
                    return buddyProperty.Name;
                }
                else if (BuddyControl != null && BuddyControl.GetType().GetProperty("Text") != null)
                {
                    return "Text";
                }

                return "";
            }
            set
            {
                if (BuddyControl != null && !string.IsNullOrEmpty(value))
                {
                    buddyProperty = BuddyControl.GetType().GetProperty(value);
                }
            }
        }

        /// <summary>
        /// Get/Set the control for use as a buddy control
        /// </summary>
        public Control BuddyControl { get; set; }

        /// <summary>
        /// Get/Set the control's name for use as a buddy control
        /// </summary>
        [Obsolete("Unnecessary property, use BuddyControl instead.")]
        public string BuddyControlName
        {
            get
            {
                if (BuddyControl != null)
                {
                    return BuddyControl.Name;
                }
                else
                {
                    return "";
                }
            }
            set
            {
                if (string.IsNullOrEmpty(value) || this.Parent == null)
                {
                    return;
                }
                Control temp = this.FindForm().Controls.Find(value, true).First();
                if (temp != null)
                {
                    BuddyControl = temp;
                }

            }
        }

        /// <summary>
        /// Get/Set the flag to have the buddy control kept in sync
        /// </summary>
        public bool SyncBuddy { get; set; }

        /// <summary>
        /// Get/Set the amount by which the position changes on each click
        /// </summary>
        public int Increment { get; set; }

        /// <summary>
        /// Get/Set the upper bound of the scroll range
        /// </summary>
        public int Max { get; set; }

        /// <summary>
        /// Get/Set the lower bound of the scroll range
        /// </summary>
        public int Min { get; set; }

        /// <summary>
        /// Get/Set the current position in the scroll range
        /// </summary>
        public new int Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                if (Increased)
                {
                    OnUpClick(EventArgs.Empty);
                }
                else
                {
                    OnDownClick(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Get/Set whether the value (position) will wrap from max to min (or min to max)
        /// </summary>
        public bool Wrap { get; set; }

        #endregion

        #region "Private methods"

        protected virtual void OnDownClick(EventArgs e)
        {
            if (DownClickEvent != null)
            {
                DownClickEvent.Invoke(this, e);
            }
        }

        private EventHandler DownClickEvent;

        public event EventHandler DownClick
        {
            add
            {
                EventHandler eventHandler = DownClickEvent;
                EventHandler eventHandler2;
                do
                {
                    eventHandler2 = eventHandler;
                    EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
                    eventHandler = Interlocked.CompareExchange(ref DownClickEvent, value2, eventHandler2);
                }
                while ((object)eventHandler != eventHandler2);
            }
            remove
            {
                EventHandler eventHandler = DownClickEvent;
                EventHandler eventHandler2;
                do
                {
                    eventHandler2 = eventHandler;
                    EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
                    eventHandler = Interlocked.CompareExchange(ref DownClickEvent, value2, eventHandler2);
                }
                while ((object)eventHandler != eventHandler2);
            }
        }

        protected virtual void OnUpClick(EventArgs e)
        {
            if (UpClickEvent != null)
            {
                UpClickEvent.Invoke(this, e);
            }
        }

        private EventHandler UpClickEvent;

        public event EventHandler UpClick
        {
            add
            {
                EventHandler eventHandler = UpClickEvent;
                EventHandler eventHandler2;
                do
                {
                    eventHandler2 = eventHandler;
                    EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
                    eventHandler = Interlocked.CompareExchange(ref UpClickEvent, value2, eventHandler2);
                }
                while ((object)eventHandler != eventHandler2);
            }
            remove
            {
                EventHandler eventHandler = UpClickEvent;
                EventHandler eventHandler2;
                do
                {
                    eventHandler2 = eventHandler;
                    EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
                    eventHandler = Interlocked.CompareExchange(ref UpClickEvent, value2, eventHandler2);
                }
                while ((object)eventHandler != eventHandler2);
            }
        }

        protected new virtual void OnValueChanged(EventArgs e)
        {
            if (ChangeEvent != null)
            {
                ChangeEvent.Invoke(this, e);
            }
        }

        private EventHandler ChangeEvent;

        public new event EventHandler ValueChanged
        {
            add
            {
                EventHandler eventHandler = ChangeEvent;
                EventHandler eventHandler2;
                do
                {
                    eventHandler2 = eventHandler;
                    EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
                    eventHandler = Interlocked.CompareExchange(ref ChangeEvent, value2, eventHandler2);
                }
                while ((object)eventHandler != eventHandler2);
            }
            remove
            {
                EventHandler eventHandler = ChangeEvent;
                EventHandler eventHandler2;
                do
                {
                    eventHandler2 = eventHandler;
                    EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
                    eventHandler = Interlocked.CompareExchange(ref ChangeEvent, value2, eventHandler2);
                }
                while ((object)eventHandler != eventHandler2);
            }
        }


        /// <summary>
        /// The current position has changed
        /// </summary>
        /// <param name="sender">The form to be printed.</param>
        /// <param name="e">arg for Scroll</param>
        protected override void OnScroll(ScrollEventArgs se)
        {
            if (se.Type != ScrollEventType.EndScroll)
            {
                ChangeCurrentValue(se);

                if (BuddyControl != null && SyncBuddy)
                {
                    PropertyInfo property = BuddyControl.GetType().GetProperty(BuddyProperty);
                    property.SetValue(BuddyControl, Convert.ChangeType(this.Value, property.PropertyType), (object[])null);
                }
                OnValueChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Increment/Decrement the value of the UpDown Buddy Control.
        /// </summary>
        /// <param name="sender">The form to be printed.</param>
        /// <param name="e">arg for Scroll</param>
        private void ChangeCurrentValue(ScrollEventArgs e)
        {
            if (e.Type == ScrollEventType.SmallDecrement)
            {
                if (_value == 0)
                {
                    if (_value + Increment <= Max && _value + Increment >= Min)
                    {
                        _value += Increment;
                    }
                    else if (Wrap)
                    {
                        _value = Max;
                    }
                }
                else
                {
                    if (_value + Increment >= Min && _value + Increment <= Max)
                    {
                        _value += Increment;
                    }
                    else if (Wrap)
                    {
                        _value = Min;
                    }
                }
                Increased = true;
            }
            else if (e.Type == ScrollEventType.SmallIncrement)
            {
                if (_value <= 0)
                {
                    if (_value - Increment <= Max && _value - Increment >= Min)
                    {
                        _value -= Increment;
                    }
                    else if (Wrap)
                    {
                        _value = Max;
                    }
                }
                else
                {
                    if (_value - Increment >= Min && _value - Increment <= Max)
                    {
                        _value -= Increment;
                    }
                    else if (Wrap)
                    {
                        _value = Min;
                    }
                }
                Increased = false;
            }
            Value = _value;
        }
        #endregion
    }
}
