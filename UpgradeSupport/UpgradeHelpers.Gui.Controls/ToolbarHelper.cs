using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace UpgradeHelpers.Gui.Controls
{
    #region Extension methods
    /// <summary>
    /// Class that stores extension methods for Toolbar 
    /// </summary>
    public static class Extensions
    {
        #region Constants
        private const string SEPARATOR = "separator"; //Used to create ToolStripItems of type Separator ( apparently in VB6 if the tool id is "separator" creates it automatically )
        #endregion

        #region ToolStrip Add
        /// <summary>
        /// Adds a new ToolStripItem
        /// </summary>
        /// <param name="tools">List of ToolStrip Items</param>
        /// <param name="toolId">Id of the tool </param>
        /// <returns>A new ToolStrip Item</returns>
        public static ToolStripItem Add(this ITools tools, string toolId)
        {
            return Add(tools, toolId, 0);
        }
        /// <summary>
        /// Adds a new ToolStripItem
        /// </summary>
        /// <param name="tools">List of ToolStrip Items</param>
        /// <param name="toolId">Id of the tool</param>
        /// <param name="index">Index to insert</param>
        /// <returns>A new ToolStrip Item</returns>
        public static ToolStripItem Add(this ITools tools, string toolId, int index)
        {
            return Add(tools, toolId, ToolbarHelper.ConstantsType.ssTypeButton, index);
        }
        /// <summary>
        /// Adds a new ToolStripItem
        /// </summary>
        /// <param name="tools">List of ToolStrip Items</param>
        /// <param name="toolId">Id of the tool. Empty by default</param>
        /// <param name="style">Type of ToolStrip Item . Button by default</param>
        /// <param name="index">Index to insert. 0 by default </param>
        /// <returns>A new ToolStrip Item</returns>
        public static ToolStripItem Add(this ITools tools, string toolId = "",
            ToolbarHelper.ConstantsType style = ToolbarHelper.ConstantsType.ssTypeButton, int index = 0)
        {
            if (tools is ToolsList) // If the list belongs to the tools of the toolbar
                return Add(tools as ToolsList, toolId, style, index);
            else // If the list belongs to the menu tools of a ToolStripItem
                return Add(tools as ToolsListMenu, toolId, style, index);
        }

        /// <summary>
        /// Adds a new ToolStripItem of type Menu
        /// </summary>
        /// <param name="toolListMenu">List of Menu Tools</param>
        /// <param name="toolId">Id of the tool</param>
        /// <param name="style">Type of ToolStrip Item . Button by default</param>
        /// <param name="index">Index to insert.</param>
        /// <returns>A new ToolStrip Item</returns>
        private static ToolStripItem Add(ToolsListMenu toolListMenu, string toolId, ToolbarHelper.ConstantsType style, int index)
        {
            ToolStripMenuItem ToolStripMenuItem = null;

            //First we get the ToolStripDropDown located by ID in the list of Popup Menus
            var toolStripDropDown = toolListMenu.ToolbarParent.PopupMenus[toolListMenu.MenuId];

            //Let's check if the type/style of the ToolStripItem should be modified
            style = ChangeTypeIfNeeded(style, toolId);

            //Second we get the ToolStripItem by ID from the tools of the Toolbar
            var toolInTools = toolListMenu.ToolbarParent.Tools[toolId];

            //If the ToolStripItem does not exist means the Tool was not created, then we create a new one and continue the execution
            if (toolInTools == null && toolId != SEPARATOR)
            {
                //Add the new ToolStripItem to the tools of the Toolbar**
                toolListMenu.ToolbarParent.Tools.Add(toolId, style, index);
                //Now is inserted, let's try to get again the ToolStripItem by ID from the tools of the Toolbar
                toolInTools = toolListMenu.ToolbarParent.Tools[toolId];
            }

            //Then we need to create the real ToolStripItem which is the one that will be displayed/painted in the Form.
            ToolStripItem item = CreateToolStripItem(style, toolInTools);

            //The new ToolStripItem is added to the ToolStripDropDown, in other words the submenu of the menu is created
            toolStripDropDown.Items.Add(item);

            //Then we need to insert the new ToolStripItem( the submenu ) in all menus of the toolbars ( just in case the menu is present in several toolbars at once).
            //Example, suppose you have 2 toolbars "toolbar1" and "toolbar2", also you have a ToolStripItem of type Menu "Menu1" which was inserted in both toolbars.
            //Let's say you are adding a submenu "Close" that belongs to the Menu "Menu1", since "Menu1" is present in two toolbars both collections must be modified

            foreach (IToolbar toolbar in toolListMenu.ToolbarParent.Toolbars)
            {
                //Get the ToolStripItem(Menu) from the items of the ToolStripItems
                var menu = (toolbar as ToolStrip).Items[toolListMenu.MenuId];
                if (menu != null)
                {
                    //The SubMenu is added to the Items of the Menu
                    ToolStripMenuItem = new ToolStripMenuItem();
                    ToolStripMenuItem.Text = SetText(ToolStripMenuItem.Text, toolId); ;
                    ToolStripMenuItem.Name = toolId;
                    (menu as ToolStripDropDownButton).DropDownItems.Add(ToolStripMenuItem);
                }
            }

            //If the ToolStripItem was not present initially we must set correctly the ToolbarParent**
            if (toolInTools != null)
            {
                toolInTools.ToolbarParent = toolListMenu.ToolbarParent;
                toolInTools.MenuId = toolListMenu.MenuId;
                //Finally we must add the submenu (ToolStripItemWrapped) to the tools of the menu
                toolListMenu.Add(toolInTools);
            }
            //Return the ToolStripItem created
            return toolInTools;
        }

        /// <summary>
        /// Adds a new ToolStripItem 
        /// </summary>
        /// <param name="toolList">List of Tools of the Toolbar</param>
        /// <param name="toolId">Id of the tool</param>
        /// <param name="style">Type of ToolStripItem</param>
        /// <param name="index">Index to insert</param>
        /// <returns>A new ToolStrip Item</returns>
        private static ToolStripItem Add(ToolsList toolList, string toolId = "", ToolbarHelper.ConstantsType style = ToolbarHelper.ConstantsType.ssTypeButton, int index = 0)
        {
            //First we check if we are inserting in the Tools of the Toolbar or in the Tools of a ToolStripItem
            if (InsertionInToolsOfToolStripItem(toolList))
            {
                //Let's create the real ToolStripItem which is the one that will be displayed in the Form
                var tuple = AddToolStripItem(toolList, toolId, index);
                if (tuple != null)
                {
                    //If index is greater that List Count assign back the count to the index to keep consistency
                    if (index > toolList.Count)
                        index = toolList.Count;

                    //Now the ToolStripItem is included as part of the tools of the ToolStripItem
                    toolList.Insert(index, tuple.Item2);

                    //Return the ToolStripItem created
                    return tuple.Item1;
                }
            }
            else
            {
                //If the code jumps here means we are inserting ToolStripItems in the Tools of the Toolbar

                //Create the wrapper for ToolStripItem
                ToolStripItemWrapper itemWrapper = new ToolStripItemWrapper();
                itemWrapper.ToolbarParent = toolList.ToolbarParent;//Assign its Toolbar parent
                itemWrapper.Name = toolId; //Assign its id
                itemWrapper.Text = SetText(itemWrapper.Text, toolId); //Assign its text
                itemWrapper.ConstantsType = style; //Assign the type

                //If the Type of the ToolStripItem will be Combobox, then create the combobox instance for its handling
                if (style == ToolbarHelper.ConstantsType.ssTypeComboBox)
                {
                    itemWrapper.ComboBox = new ComboBoxWrapper(itemWrapper.ToolbarParent, itemWrapper.Name);
                }
                //If the Type of the ToolStripItem will be Menu, then create the menu instance for its handling
                else if (style == ToolbarHelper.ConstantsType.ssTypeMenu)
                {
                    itemWrapper.Menu = new ToolStripItemWrapperMenu(toolId, toolList.ToolbarParent);

                    //It's important to mention this: When a ToolStripItem of type Menu is created it can be work as a popup menu into any other control.
                    //To support this we add a new ToolStripDown and we include the id of the tool in the list of popup menus

                    toolList.ToolbarParent.PopupMenus.Add(toolId, CreateToolStripDown(itemWrapper, toolId));
                }

                //Finally the new ToolStripItem is added to the list of tools of the toolbar
                toolList.Add(itemWrapper);

                //Return the ToolStripItem created
                return itemWrapper;
            }

            return null;
        }

        /// <summary>
        /// Creates a new instance of ToolStrip (Wrapped)
        /// </summary>
        /// <param name="toolbarList">Toolbar List of the Main Toolbar</param>
        /// <param name="toolbarId">Id of the Toolbar</param>
        /// <param name="style">Toolbar type</param>
        /// <returns>A new instance of the Toolbar (wrapped)</returns>
        public static ToolStripWrapper Add(this ToolbarsList toolbarList, string toolbarId, ToolbarHelper.ToolbarStyle style)
        {
            ToolStripWrapper toolbar = new ToolStripWrapper(toolbarId, toolbarList.ToolbarParent);
            toolbar.Dock = DockStyle.Top;
            toolbar.CaptionStyle = style;
            toolbarList.Add(toolbar);
            (toolbarList.ToolbarParent as ToolStripWrapper).Parent.Controls.Add(toolbar); //The Toolbar is inserted in the Controls of the Form

            return toolbar;
        }
        #endregion

        #region ToolStrip Remove
        /// <summary>
        /// Remove a ToolStripItem from all its instances
        /// </summary>
        /// <param name="tools">List of ToolStripItem</param>
        /// <param name="key">Key to remove the ToolStripItem</param>
        public static void Remove(this ITools tools, object key)
        {
            if (tools is ToolsList)
            {
                Remove(tools as ToolsList, key.ToString());
            }
            else
            {
                Remove(tools, key);
            }
        }
        /// <summary>
        /// Remove a ToolStripItem from all its instances
        /// </summary>
        /// <param name="toolList">List of ToolStripItem</param>
        /// <param name="toolId">Key to remove the ToolStripItem</param>
        public static void Remove(this ToolsList toolList, string toolId)
        {
            bool popupMenuAlreadyChecked = false;
            
            //The ToolStripItem is seeked in all toolbars
            foreach (IToolbar toolbar in toolList.ToolbarParent.Toolbars)
            {
                if (!String.IsNullOrWhiteSpace(toolList[toolId].MenuId))
                {
                    var toolMenu = toolbar.Tools[toolList[toolId].MenuId];
                    if (toolMenu != null)
                    {
                        var menu = toolMenu.Menu;
                        if (menu != null)
                        {
                            menu.Tools.Remove(toolList[toolId]);
                        }
                    }
                }

                //Is removed from the tools of the toolbar
                toolbar.Tools.Remove(toolList[toolId]);

                //Is removed from the items of the toolbar (ToolStrip .NET)
                (toolbar as ToolStrip).Items.RemoveByKey(toolId);

                //Now let's check if should be removed from the popup menus etc
                if (toolbar.ToolbarRoot != null && !popupMenuAlreadyChecked)
                {
                    //The popup menus are gotten
                    var popupMenus = toolbar.ToolbarRoot.PopupMenus;
                    if (popupMenus.Count > 0)
                    {
                        //If is in the popup menus list is removed
                        if (popupMenus.ContainsKey(toolId))
                            popupMenus.Remove(toolId);

                        //The popup menus of the control are iterated
                        foreach (var popupMenu in popupMenus)
                        {
                            if (popupMenu.Value != null)
                            {
                                //The ToolStripItem is removed from the Items of the ToolStripDropDown
                                popupMenu.Value.Items.RemoveByKey(toolId);

                                //Finally let's check if the ToolStripItem was included as DropDownItem, if so must be removed as well
                                var menu = ((toolbar as ToolStrip).Items[popupMenu.Key.ToString()] as ToolStripDropDownButton);
                                if (menu != null && menu.DropDownItems.ContainsKey(toolId))
                                {
                                    menu.DropDownItems.RemoveByKey(toolId);
                                    popupMenuAlreadyChecked = true;
                                }

                            }
                        }
                    }
                }
            }
            toolList.Remove(toolList[toolId]);
        }

        #endregion

        #region ToolStripItem

        /// <summary>
        /// Determines whether the type/style of a ToolStripItem is changed or not
        /// </summary>
        /// <param name="style">ToolStripItem style</param>
        /// <param name="toolID">ID of the Tool</param>
        /// <returns>The new ToolStripItem style</returns>
        private static ToolbarHelper.ConstantsType ChangeTypeIfNeeded(ToolbarHelper.ConstantsType style, string toolID)
        {
            if (toolID.Equals(SEPARATOR))
                return ToolbarHelper.ConstantsType.ssTypeSeparator;

            return style;
        }
        /// <summary>
        /// Creates a new instance of ToolStripDropDown used to handle the popup menus
        /// </summary>
        /// <param name="itemWrapper">ToolStripItem wrapped</param>
        /// <param name="toolId">ID of the tool</param>
        /// <returns>A new instance of ToolStripItem</returns>
        private static ToolStripDropDown CreateToolStripDown(ToolStripItemWrapper itemWrapper, string toolId)
        {
            //Create a new instance of ToolStripDropDown
            ToolStripDropDown _toolStripDropDown = new ToolStripDropDown
            {
                CanOverflow = true,
                AutoClose = true,
                DropShadowEnabled = true,
                Name = toolId
            };
            //Assign the ItemClick and a delegate is defined to invoke the click logic (behind the hoods)
            AssignClickToToolStripDropDown(itemWrapper, ref _toolStripDropDown);

            //Return the instance of ToolStripDropDown
            return _toolStripDropDown;
        }

        /// <summary>
        /// Assigns the itemclick event to the ToolStripDropDown
        /// </summary>
        /// <param name="itemWrapper">ToolStripItem of type Menu</param>
        /// <param name="_toolStripDropDown">Instance of the ToolStripDropDown</param>
        private static void AssignClickToToolStripDropDown(ToolStripItemWrapper itemWrapper, ref ToolStripDropDown _toolStripDropDown)
        {
            //By reflection the method info and create the delegate which will invoke the logic when the items of the ToolStripDropDown are clicked
            Type parentType = (itemWrapper.ToolbarParent as ToolStripWrapper).Parent.GetType();
            MethodInfo methodInfo = parentType.GetMethod((itemWrapper.ToolbarParent as ToolStripWrapper).Name +
                ToolbarHelper.HANDLER_PREFIX, BindingFlags.NonPublic | BindingFlags.Instance);

            if (methodInfo != null)
            {
                _toolStripDropDown.ItemClicked += (sender, args) =>
                {
                    methodInfo.Invoke((itemWrapper.ToolbarParent as ToolStripWrapper).Parent, new object[]
                   {
                            itemWrapper.ToolbarParent, args
                   });
                };
            }
        }

        /// <summary>
        /// Checks if the Insertion is in the tools of the toolbar or in the tools of a ToolStripItem
        /// </summary>
        /// <param name="toolList"></param>
        /// <returns></returns>
        private static bool InsertionInToolsOfToolStripItem(ToolsList toolList)
        {
            //If ToolbarRoot is null means the insertion is in the Tools of a ToolStripItem, not in the Tools of a Toolbar
            return toolList.ToolbarParent.ToolbarRoot != null;
        }

        /// <summary>
        /// Extension method created to define the state of a ToolStripItem
        /// </summary>
        /// <param name="item">Instance of ToolStripItem</param>
        /// <param name="state">New State</param>
        public static void setState(this ToolStripItemWrapper item, ToolbarHelper.ConstantsState state)
        {
            //Change the state in the tools of each toolbar and also in the items of each Toolbar
            foreach (IToolbar toolbar in item.ToolbarParent.Toolbars)
            {
                var toolStripButtonState = (toolbar as ToolStrip).Items[item.Name] as ToolStripButton;
                if (toolStripButtonState != null)
                {
                    toolStripButtonState.CheckState = (state == ToolbarHelper.ConstantsState.ssChecked) ? CheckState.Checked : CheckState.Unchecked;
                }

                var toolStripItem = toolbar.Tools[item.Name];
                if (toolStripItem != null)
                {
                    toolStripItem.State = state;
                }
            }
        }
        #endregion

        #region ComboBox
        /// <summary>
        /// Get the data of item by index
        /// </summary>
        /// <param name="combo">Instance of ComboBox</param>
        /// <param name="Index">Index to find</param>
        /// <returns>Value of the item</returns>
        public static object ItemData(this ComboBoxWrapper combo, int Index)
        {
            return combo.Items[Index];
        }

        /// <summary>
        /// Adds a new entry to the ComboBox ToolStripItem
        /// </summary>
        /// <param name="combo">Instance of ComboBoxWrapper</param>
        /// <param name="value">Value to insert</param>
        public static void Add(this ComboBoxWrapper combo, object value)
        {
            foreach (IToolbar toolbar in combo.ToolbarParent.Toolbars)
            {
                var comboItem = (toolbar as ToolStrip).Items[combo.Name] as ToolStripComboBox;
                if (comboItem != null)
                {
                    combo.Items.Add(value);
                }
            }
        }

        /// <summary>
        /// Removes an entry from the ComboBox ToolStripItem
        /// </summary>
        /// <param name="combo">Instance of ComboBoxWrapper</param>
        /// <param name="value">Value to remove</param>
        public static void Remove(this ComboBoxWrapper combo, object value)
        {
            foreach (IToolbar toolbar in combo.ToolbarParent.Toolbars)
            {
                var comboItem = (toolbar as ToolStrip).Items[combo.Name] as ToolStripComboBox;
                if (comboItem != null)
                {
                    combo.Items.Remove(value);
                }
            }
        }

        /// <summary>
        /// Gets the text of a ComboBox ToolStripItem
        /// </summary>
        /// <param name="combo">Instance of Combobox</param>
        /// <returns>Text of the ComboBox</returns>
        public static string getText(this ComboBoxWrapper combo)
        {
            return combo.Text;
        }
        /// <summary>
        /// Gets the index list of a ComboBox ToolStripItem
        /// </summary>
        /// <param name="combo">Instance of Combobox</param>
        /// <returns>Index in the liset</returns>
        public static int getListIndex(this ComboBoxWrapper combo)
        {
            int index = -1;
            foreach (IToolbar toolbar in combo.ToolbarParent.Toolbars)
            {
                var comboItem = (toolbar as ToolStrip).Items[combo.Name] as ToolStripComboBox;
                if (comboItem != null)
                {
                    index = (toolbar as ToolStrip).Items.IndexOf(comboItem);
                }
            }

            return index;
        }

        #endregion

        #region Other functions
        /// <summary>
        /// Defines the text for the ToolStripItems
        /// </summary>
        /// <param name="text">Text to set</param>
        /// <param name="toolId">ID of ToolStripItem</param>
        /// <returns>Text to set</returns>
        private static string SetText(string text, string toolId)
        {
            return String.IsNullOrWhiteSpace(text) ? toolId : text;
        }

        /// <summary>
        /// Creates a new instance of ToolStripItem
        /// </summary>
        /// <param name="type">ToolStripItem type</param>
        /// <param name="wrapper">ToolStripItem wrapped</param>
        /// <returns>A new instance of ToolStripItem</returns>
        private static ToolStripItem CreateToolStripItem(ToolbarHelper.ConstantsType type, ToolStripItemWrapper wrapper)
        {
            ToolStripItem item = null;
            switch (type)
            {
                case ToolbarHelper.ConstantsType.ssTypeButton:
                    item = new ToolStripButton();
                    break;
                case ToolbarHelper.ConstantsType.ssTypeStateButton:
                    item = new ToolStripButton();
                    break;
                case ToolbarHelper.ConstantsType.ssTypeMenu:
                    item = new ToolStripDropDownButton();
                    break;
                case ToolbarHelper.ConstantsType.ssTypeComboBox:
                    item = new ToolStripComboBox();
                    break;
                case ToolbarHelper.ConstantsType.ssTypeSeparator:
                    item = new ToolStripSeparator();
                    break;
                default:
                    item = new ToolStripButton();
                    break;
            }

            if (wrapper != null)
            {
                //The properties of the wrapped object are cloned in the real ToolStripItem
                item = CloneProperties(item, wrapper);
            }

            return item;
        }

        /// <summary>
        /// Clones the properties from the ToolStripItem wrapped to the real ToolStripItem
        /// </summary>
        /// <param name="item">ToolStripItem target</param>
        /// <param name="wrapper">ToolStripItem wrapped</param>
        /// <returns>A new instance of ToolStripItem</returns>
        private static ToolStripItem CloneProperties(ToolStripItem item, ToolStripItemWrapper wrapper)
        {
            var propertiesTarget = item.GetType().GetProperties();

            foreach (var propertyTarget in propertiesTarget)
            {
                try
                {
                    if (null != propertyTarget && propertyTarget.CanWrite)
                    {
                        //Visible and Enabled properties are handled internally depending on the life cycle events. That's the reason why are not copied.
                        if (propertyTarget.Name.Equals("Visible") || propertyTarget.Name.Equals("Enabled")) continue;

                        var propertySrc = wrapper.GetType().GetProperty(propertyTarget.Name, BindingFlags.Public | BindingFlags.Instance);
                        if (null != propertySrc)
                        {
                            propertyTarget.SetValue(item, propertySrc.GetValue(wrapper, null), null);
                        }
                    }
                }
                catch { }
            }

            return item;
        }
        /// <summary>
        /// Adds a ToolStripItem to the Items of a Toolbar
        /// </summary>
        /// <param name="toolList">Tools List</param>
        /// <param name="toolId">Tool ID to insert</param>
        /// <param name="index">Index to Insert</param>
        /// <returns>A tuple that contains the instance of the new ToolStripItem and the instance of ToolStripItem wrapped</returns>
        private static Tuple<ToolStripItem, ToolStripItemWrapper> AddToolStripItem(ToolsList toolList, string toolId, int index)
        {
            //In VB6 sometimes the tool is gotten with symbol "&" so we had to try twice (just in case)
            var toolInTools = toolList.ToolbarParent.ToolbarRoot.Tools[toolId];
            if (toolInTools == null)
                toolInTools = toolList.ToolbarParent.ToolbarRoot.Tools["&" + toolId];

            if (toolInTools != null)
            {
                //Let's check if the type/style of the ToolStripItem should be modified
                toolInTools.ConstantsType = ChangeTypeIfNeeded(toolInTools.ConstantsType, toolId);

                //Create the real ToolStripItem (the one that will be displayed in the Form)
                ToolStripItem item = CreateToolStripItem(toolInTools.ConstantsType, toolInTools);
                if (index > (toolList.ToolbarParent as ToolStrip).Items.Count)
                    index = (toolList.ToolbarParent as ToolStrip).Items.Count;

                //Add the real ToolStripItem to the items of the Toolbar
                (toolList.ToolbarParent as ToolStrip).Items.Insert(index, item);

                //Finally return the tuple with both instances
                return new Tuple<ToolStripItem, ToolStripItemWrapper>(item, toolInTools);
            }
            return null;
        }

        /// <summary>
        /// Changes a specific ToolStripItem property in all its instances
        /// </summary>
        /// <param name="item">ToolStripItem instance</param>
        /// <param name="change">Property to change</param>
        /// <param name="newValue">New value to change</param>
        public static void ChangeAll(this ToolStripItem item, ToolbarHelper.ConstantsChangeAll change, object newValue)
        {
            ToolStripItemWrapper itemWrapper = (item as ToolStripItemWrapper);
            switch (change)
            {
                case ToolbarHelper.ConstantsChangeAll.ssChangeAllName:
                    itemWrapper.Text = Convert.ToString(newValue); // Text in .NET is the equivalent for Name in VB6
                    break;
                case ToolbarHelper.ConstantsChangeAll.ssChangeAllVisible:
                    itemWrapper.Visible = Convert.ToBoolean(newValue);
                    break;
                case ToolbarHelper.ConstantsChangeAll.ssChangeAllDisplayStyle:
                    //pending
                    break;
                case ToolbarHelper.ConstantsChangeAll.ssChangeAllCtlWidth:
                    //no uses in the code
                    break;
                case ToolbarHelper.ConstantsChangeAll.ssChangeAllForeColor:
                    //no uses in the code
                    break;
            }
        }

        public static object GetRealOldValue(this ToolStripItem item, string property, object value)
        {
            object valueToReturn = value;

            if (property.Equals("Visible") || property.Equals("Enabled"))
            {
                ToolStripWrapper toolbarRoot = (item as ToolStripItemWrapper).ToolbarParent as ToolStripWrapper;
                if (toolbarRoot == null) return valueToReturn;

                ToolStripItemWrapper itemInTools = toolbarRoot.Tools[item.Name];
                if (itemInTools == null) return valueToReturn;

                foreach (ToolStripWrapper toolbar in toolbarRoot.Toolbars)
                {
                    if (toolbar.Items.ContainsKey(item.Name))
                    {
                        if (property.Equals("Visible"))
                        {
                            valueToReturn = toolbar.Items[item.Name].Visible;
                            break;
                        }

                        if (property.Equals("Enabled"))
                        {
                            valueToReturn = toolbar.Items[item.Name].Enabled;
                            break;
                        }

                    }
                }
            }
            return valueToReturn;
        }
        /// <summary>
        /// Gets the real value of the property and changes its value in the instance
        /// </summary>
        /// <param name="item">Instance of ToolStripItem</param>
        /// <param name="oldValue">Old Value</param>
        /// <param name="newValue">New Value to update</param>
        /// <param name="property">Property to update</param>
        public static void SpreadChange(this ToolStripItem item, object oldValue, object newValue, string property)
        {
            PropertyInfo prop = null;

            //The following line tries to get the real value of the property in the collection of .NET
            //Something happens, specifically for Visible and Enabled that are changed automatically depending on the life cycle
            object realOldValue = item.GetRealOldValue(property, oldValue);
            bool oldValueWasNotCorrect = realOldValue != oldValue;

            //Get the property and update its value
            prop = item.GetType().BaseType.GetProperty(property, BindingFlags.Public | BindingFlags.Instance);
            if (null != prop && prop.CanWrite)
            {
                prop.SetValue(item, newValue, null);
            }

            //If the value was updated and must be spread in all instances
            if (!realOldValue.Equals(newValue))
                item.SpreadChange(property, newValue, oldValueWasNotCorrect);
        }

        /// <summary>
        /// Spread the change of the property in all instances ( tools of toolbar, tools of tools, tools of menu, popup menu etc)
        /// </summary>
        /// <param name="item">ToolStripItem instance</param>
        /// <param name="property">Name of the property to update</param>
        /// <param name="value">Value to update</param>
        /// <param name="excludeChangeInToolList">True to avoid updating in the instance(first parameter) because was updated previously</param>
        public static void SpreadChange(this ToolStripItem item, string property, object value, bool excludeChangeInToolList = false)
        {
            PropertyInfo prop = null;

            //Get the toolbar of the ToolStripItem
            ToolStripWrapper toolbarRoot = (item as ToolStripItemWrapper).ToolbarParent as ToolStripWrapper;
            if (toolbarRoot == null) return; //No change needed

            //Get the tool in the tools of toolbar
            ToolStripItemWrapper itemInTools = toolbarRoot.Tools[item.Name];
            if (itemInTools == null) return; //No change needed

            //The property in the tools list of the toolbar is updated
            prop = itemInTools.GetType().GetProperty(property, BindingFlags.Public | BindingFlags.Instance);
            if (null != prop && prop.CanWrite && !excludeChangeInToolList)
            {
                prop.SetValue(itemInTools, value, null);
            }

            //Checks if the popupmenus collection was already reviewed. The popup menus collection is stored in the toolbar root ( the one defined in the designer ). Must be checked 1 time.
            bool popupMenuAlreadyChecked = false;

            //Then we need to get all instances of the ToolStripItem in the toolbars
            foreach (IToolbar toolbar in toolbarRoot.Toolbars)
            {
                //Get the tool in the toolbar items
                var itemInToolbar = (toolbar as ToolStrip).Items[item.Name];
                if (itemInToolbar != null)
                {
                    //The property is updated in the tool
                    prop = itemInToolbar.GetType().GetProperty(property, BindingFlags.Public | BindingFlags.Instance);
                    if (null != prop && prop.CanWrite)
                    {
                        prop.SetValue(itemInToolbar, value, null);
                    }

                    if (toolbar.ToolbarRoot != null && !popupMenuAlreadyChecked)
                    {
                        //Get the popup menus
                        var popupMenus = toolbar.ToolbarRoot.PopupMenus;
                        if (popupMenus.Count > 0)
                        {
                            //Iterate the popup menus of the control
                            foreach (var popupMenu in popupMenus)
                            {
                                if (popupMenu.Value != null)
                                {
                                    //If the key of the tool is present in the popup menus list
                                    if (popupMenu.Value.Items.ContainsKey(item.Name))
                                    {
                                        //Get the Value of the PopupMenu and update its value in the list
                                        var itemInPopupMenu = popupMenu.Value.Items[item.Name];
                                        prop = itemInPopupMenu.GetType().GetProperty(property, BindingFlags.Public | BindingFlags.Instance);
                                        if (null != prop && prop.CanWrite)
                                        {
                                            prop.SetValue(itemInPopupMenu, value, null);
                                        }

                                    }

                                    //Then we must update the GUI. For this we get the item in the toolbar items
                                    var menu = ((toolbar as ToolStrip).Items[popupMenu.Key.ToString()] as ToolStripDropDownButton);
                                    if (menu != null && menu.DropDownItems.ContainsKey(item.Name))
                                    {
                                        //If the key is present in the dropdown items we must update the value as well
                                        var submenu = menu.DropDownItems[item.Name];
                                        prop = submenu.GetType().GetProperty(property, BindingFlags.Public | BindingFlags.Instance);
                                        if (null != prop && prop.CanWrite)
                                        {
                                            prop.SetValue(submenu, value, null);
                                        }
                                        popupMenuAlreadyChecked = true; //The popup menus list was already reviewed
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Shows or simulates a Context/Popup Menu according to the tool ID or ToolStripItem instance
        /// </summary>
        /// <param name="toolbar">Toolbar Instance</param>
        /// <param name="tool">Tool to get, can be instance of string</param>
        /// <param name="flags"></param>
        /// <param name="x">Position X</param>
        /// <param name="y">Position Y</param>
        public static void PopupMenu(this ToolStripWrapper toolbar, object tool, object flags = null, int x = 0, int y = 0)
        {
            string toolName = string.Empty;

            if (tool is String)
            {
                var toolFromToolbar = toolbar.Tools[Convert.ToString(tool)];
                if (toolFromToolbar != null)
                    toolName = toolFromToolbar.Name;
            }
            else
            if (tool is ToolStripItem)
            {
                toolName = (tool as ToolStripItem).Name;
            }

            var toolStripDropDown = toolbar.PopupMenus[toolName];
            toolStripDropDown.Show(x == 0 && y == 0 ? Cursor.Position : new Point(x, y));
        }
        #endregion
    }

    #endregion

    #region Custom Lists

    /// <summary>
    /// Handles the list of toolbars
    /// </summary>
    public class ToolbarsList : List<ToolStripWrapper>, IToolbarParent
    {
        public ToolbarsList(IToolbar toolbar)
        {
            this.ToolbarParent = toolbar;
        }

        new public ToolStripWrapper this[string index]
        {
            get
            {
                return this.Where(item => item.Name.Equals(index)).FirstOrDefault();
            }
        }
        public IToolbar ToolbarParent { get; set; }
    }

    /// <summary>
    /// Handles the list of Tools
    /// </summary>
    public class ToolsList : List<ToolStripItemWrapper>, IToolbarParent, ITools
    {
        public ToolsList(IToolbar toolStripWrapper)
        {
            this.ToolbarParent = toolStripWrapper;
        }

        new public ToolStripItemWrapper this[string index]
        {
            get
            {
                return this.Where(item => item.Name.Equals(index)).FirstOrDefault();
            }
        }
        public IToolbar ToolbarParent { get; set; }
    }

    /// <summary>
    /// Handles the list of tools ( type menu )
    /// </summary>
    public class ToolsListMenu : List<ToolStripItemWrapper>, IToolbarParent, ITools
    {
        new public ToolStripItemWrapper this[string index]
        {
            get
            {
                return this.Where(item => item.Name.Equals(index)).FirstOrDefault();
            }
        }

        public ToolsListMenu(string toolId, IToolbar toolbarRoot)
        {
            this.MenuId = toolId;
            this.ToolbarParent = toolbarRoot;
        }
        public string MenuId;
        public IToolbar ToolbarParent { get; set; }
    }

    #endregion

    #region Wrappers
    /// <summary>
    /// Wrapper for Toolbar. The designer  uses this control to simulate the behavior of the ToolStrip
    /// </summary>
    public class ToolStripWrapper : ToolStrip, IToolbar
    {
        public ToolStripWrapper()
        {
            Tools = new ToolsList(this);
            Toolbars = new ToolbarsList(this);
            PopupMenus = new Dictionary<string, ToolStripDropDown>();
        }

        public ToolStripWrapper(string ID, IToolbar ToolBarRoot) : this()
        {
            this.Name = ID;
            this.ToolbarRoot = ToolBarRoot;

            object toolbarRootParent = (this.ToolbarRoot as ToolStripWrapper).Parent;
            string toolbarRootName = (this.ToolbarRoot as ToolStripWrapper).Name;

            //Every Toolbar must clone the click event of the toolbar parent ( the default defined in the designer )
            Type parentType = toolbarRootParent.GetType();
            EventInfo eventInfo = this.ToolbarRoot.GetType().GetEvent(ToolbarHelper.EVENT_NAME);
            MethodInfo methodInfo = parentType.GetMethod(toolbarRootName + ToolbarHelper.HANDLER_PREFIX, BindingFlags.NonPublic | BindingFlags.Instance);

            if (eventInfo != null && methodInfo != null)
            {
#if !(NET10 || NET20 || NET30 || NET35 || NET40)
                eventInfo.AddEventHandler(this, methodInfo.CreateDelegate(eventInfo.EventHandlerType, toolbarRootParent));
#endif
            }
        }

        public IToolbar ToolbarRoot { get; set; }
        public IToolbar ToolbarParent { get; set; }
        public ToolbarsList Toolbars { get; set; }
        public ToolsList Tools { get; set; }
        public Dictionary<string, ToolStripDropDown> PopupMenus { get; set; }
        public ToolbarHelper.ToolbarStyle CaptionStyle { get; set; }
        public ToolbarHelper.DockFlags DockCustom { get; set; }
        public new DockStyle Dock { get { return base.Dock; } set { if (value != DockStyle.None) base.Dock = value; } }
    }

    /// <summary>
    /// Wrapper for Tools type Menu
    /// </summary>
    public class ToolStripItemWrapperMenu : ToolStripItem, IToolStripMenu
    {
        public ToolStripItemWrapperMenu(string toolId, IToolbar toolbarRoot)
        {
            Tools = new ToolsListMenu(toolId, toolbarRoot);
        }

        public ToolsListMenu Tools { get; set; }

    }

    /// <summary>
    /// Wrapper for Tools ToolStripItems in general
    /// </summary>
    public class ToolStripItemWrapper : ToolStripItem, IToolStripItem
    {
        public ToolStripItemWrapper() : base()
        {
            this.Visible = true;
            this.Enabled = true;
        }
        public IToolStripMenu Menu { get; set; }
        public ComboBoxWrapper ComboBox { get; set; }
        public ToolbarHelper.ConstantsState State { get; set; }
        public ToolbarHelper.ConstantsType ConstantsType { get; set; }
        public IToolbar ToolbarParent { get; set; }
        public string MenuId { get; set; }
        #region Overriden Properties ( add new entries in case the toolbar does not update automatically )
        public new string Name
        {
            get { return base.Name; }
            set
            {
                this.SpreadChange(base.Name, value, "Name");
            }
        }

        public new string Text
        {
            get { return base.Text; }
            set
            {
                this.SpreadChange(base.Text, value, "Text");
            }
        }
        public new bool Visible
        {
            get { return base.Visible; }
            set
            {
                this.SpreadChange(base.Visible, value, "Visible");
            }
        }
        public new bool Enabled
        {
            get { return base.Enabled; }
            set
            {
                this.SpreadChange(base.Enabled, value, "Enabled");
            }
        }
        public new object Tag
        {
            get { return base.Tag; }
            set
            {
                this.SpreadChange(base.Tag, value, "Tag");
            }
        }
        #endregion
    }

    /// <summary>
    /// Wrapper for ToolStripItem ComboBox 
    /// </summary>
    public class ComboBoxWrapper : ComboBox, IComboBox
    {
        public ComboBoxWrapper(IToolbar toolbarParent, string name)
        {
            this.ToolbarParent = toolbarParent;
            this.Name = name;
        }
        public IToolbar ToolbarParent { get; set; }
        public int ListCount { get; set; }
        public int ListIndex { get; set; }
        public dynamic List(int chain) { return null; }
        new public object this[int index]
        {
            get
            {
                return this.Items[index];
            }
            set
            {
                this.Items[index] = value;
            }
        }

    }
    #endregion

    #region Interfaces
    public interface IToolbarParent
    {
        IToolbar ToolbarParent { get; set; }
    }
    public interface IToolbar : IToolbarParent
    {
        IToolbar ToolbarRoot { get; set; }
        ToolbarsList Toolbars { get; set; }
        ToolsList Tools { get; set; }
        Dictionary<string, ToolStripDropDown> PopupMenus { get; set; }
        ToolbarHelper.ToolbarStyle CaptionStyle { get; set; }
        ToolbarHelper.DockFlags DockCustom { get; set; }

    }

    public interface IToolStripMenu
    {
        ToolsListMenu Tools { get; set; }
    }
    public interface IComboBox
    {
        IToolbar ToolbarParent { get; set; }
    }
    public interface IToolStripItem
    {
        IToolbar ToolbarParent { get; set; }
        IToolStripMenu Menu { get; set; }
        ComboBoxWrapper ComboBox { get; set; }
        ToolbarHelper.ConstantsState State { get; set; }
        ToolbarHelper.ConstantsType ConstantsType { get; set; }
        string Name { get; set; }
        string Text { get; set; }
        bool Visible { get; set; }
        bool Enabled { get; set; }
        object Tag { get; set; }
        string MenuId { get; set; }
    }

    public interface ITools : IList { }

    #endregion

    /// <summary>
    /// Defines some generic constants and enums for Toolbar Control
    /// </summary>
    public class ToolbarHelper
    {
        #region Constants
        public const string HANDLER_PREFIX = "_ToolClick";
        public const string EVENT_NAME = "ItemClicked";
        #endregion

        #region Enums
        public enum ConstantsType
        {
            ssTypeButton,
            ssTypeComboBox,
            ssTypeDropDown,
            ssTypeDropDownState,
            ssTypeEdit,
            ssTypeMenu,
            ssTypeSeparator,
            ssTypeStateButton,
            ssTypeLabel
        }
        public enum ToolbarStyle
        {
            ssStandard,
            ssWrapped,
            ssMenuBar
        }

        public enum ConstantsChangeAll
        {
            ssChangeAllVisible,
            ssChangeAllName,
            ssChangeAllDisplayStyle,
            ssChangeAllCtlWidth,
            ssChangeAllForeColor
        }

        public enum ConstantsState
        {
            ssChecked,
            ssUnchecked
        }

        public enum ComboBoxStyle
        {
            ssComboDropDown,
            ssComboDropDownList
        }
        public enum ForeColorSource
        {
            ssUseControl,
            ssUseTool
        }

        public enum DockedStatus
        {
            ssDockedBottom,
            ssDockedLeft,
            ssDockedRight,
            ssDockedTop,
            ssFloating
        }

        public enum DockFlags
        {
            ssDFBottom,
            ssDFFloating,
            ssDFLeft,
            ssDFRight,
            ssDFTop,
            ssPositionLocked,
            ssStretched
        }

        public enum Constants_ShortcutKeys
        {
            ssF1,
            ssF2,
            ssF3,
            ssF4,
            ssF5,
            ssF6,
            ssF7,
            ssF8,
            ssF9,
            ssF10,
            ssF11,
            ssF12,
            ssCtrlA,
            ssCtrlN,
            ssCtrlS,
            ssCtrlO,
            ssCtrlF1,
            ssCtrlF2,
            ssCtrlF3,
            ssCtrlF4,
            ssCtrlF5,
            ssCtrlF6,
            ssCtrlF7,
            ssCtrlF8,
            ssCtrlF9,
            ssCtrlF10,
            ssCtrlF11,
            ssCtrlF12
        }
        #endregion
    }

}
