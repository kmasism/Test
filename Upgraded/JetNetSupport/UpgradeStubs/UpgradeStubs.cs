using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Gui.Controls;

namespace UpgradeStubs
{
	public class ADODB_CursorOptionEnum
	{

		public static UpgradeStubs.ADODB_CursorOptionEnumEnum getadAddNew()
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("ADODB.CursorOptionEnum.adAddNew");
			return (UpgradeStubs.ADODB_CursorOptionEnumEnum) ADODB_CursorOptionEnumEnum.adAddNew;
		}
		public static UpgradeStubs.ADODB_CursorOptionEnumEnum getadDelete()
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("ADODB.CursorOptionEnum.adDelete");
			return (UpgradeStubs.ADODB_CursorOptionEnumEnum) ADODB_CursorOptionEnumEnum.adDelete;
		}
		public static UpgradeStubs.ADODB_CursorOptionEnumEnum getadResync()
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("ADODB.CursorOptionEnum.adResync");
			return (UpgradeStubs.ADODB_CursorOptionEnumEnum) ADODB_CursorOptionEnumEnum.adResync;
		}
	} 
	public class ADODB_ExecuteOptionEnum
	{

		public static UpgradeStubs.ADODB_ExecuteOptionEnumEnum getadAsyncExecute()
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("ADODB.ExecuteOptionEnum.adAsyncExecute");
			return (UpgradeStubs.ADODB_ExecuteOptionEnumEnum) ADODB_ExecuteOptionEnumEnum.adAsyncExecute;
		}
		public static UpgradeStubs.ADODB_ExecuteOptionEnumEnum getadExecuteNoRecords()
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("ADODB.ExecuteOptionEnum.adExecuteNoRecords");
			return (UpgradeStubs.ADODB_ExecuteOptionEnumEnum) ADODB_ExecuteOptionEnumEnum.adExecuteNoRecords;
		}
	} 
	public class ADODB_ResyncEnum
	{

		public static UpgradeStubs.ADODB_ResyncEnumEnum getadResyncAllValues()
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("ADODB.ResyncEnum.adResyncAllValues");
			return (UpgradeStubs.ADODB_ResyncEnumEnum) ADODB_ResyncEnumEnum.adResyncAllValues;
		}
		public static UpgradeStubs.ADODB_ResyncEnumEnum getadResyncUnderlyingValues()
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("ADODB.ResyncEnum.adResyncUnderlyingValues");
			return (UpgradeStubs.ADODB_ResyncEnumEnum) ADODB_ResyncEnumEnum.adResyncUnderlyingValues;
		}
	} 
	public class AxMSComDlg_AxCommonDialog
		: System.Windows.Forms.Control
	{

		public string getFileName()
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("MSComDlg.CommonDialog.FileName");
			return default(string);
		}
		public void setDialogTitle(string DialogTitle) => UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("MSComDlg.CommonDialog.DialogTitle");

		public void setFileName(string FileName) => UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("MSComDlg.CommonDialog.FileName");

		public void setFilter(string Filter) => UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("MSComDlg.CommonDialog.Filter");

		public void setInitDir(string InitDir) => UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("MSComDlg.CommonDialog.InitDir");

	} 
	//public class frm_Yacht
	//{

	//} 
	public class System_Data_CommandType
	{

		public static CommandType getadModeShareDenyNone()
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("ADODB.ConnectModeEnum.adModeShareDenyNone");
			return (CommandType) System_Data_CommandTypeEnum.adModeShareDenyNone;
		}
	} 
	public static class System_Data_Common_DbConnection
	{

		public static void setConnectionTimeout(this DbConnection instance, int ConnectionTimeout) => UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("ADODB.Connection.ConnectionTimeout");

		public static void setCursorLocation(this DbConnection instance, CursorLocationEnum CursorLocation) => UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("ADODB.Connection.CursorLocation");

		public static void setMode(this DbConnection instance, CommandType Mode) => UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("ADODB.Connection.Mode");

	} 
	public static class System_IO_FileInfo
	{
		public static string getType(this FileInfo instance)
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Scripting.File.Type");
			return default(string);
		}
	} 
	public static class System_Windows_Forms_ComboBox
	{

		public static void setLocked(this ComboBox instance, bool Locked) => UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("VB.ComboBox.Locked");

	}

public static class System_Windows_Forms_Control
	{
		public static void ZOrder(this ContainerControl ctl, int position=0)
		{
			ctl.BringToFront();
		}

        //public static bool getDataChanged(this Component instance) //gap-note: jgamboa. Remove deprecated property.
        //{
        //	UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("VB.Control.DataChanged");
        //	return default(bool);
        //}
        //public static bool getDataChanged(this Control instance) //gap-note: jgamboa. Remove deprecated property.
        //{
        //	UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("VB.Control.DataChanged");
        //	return default(bool);
        //}
        public static void SetToolTipText(this Control instance, string ToolTipText) => UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("VB.Control.ToolTipText");

		public static void setToolTipText(this Component instance, string ToolTipText) => UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("VB.Control.ToolTipText");

	} 
	public static class System_Windows_Forms_MonthCalendar
	{

		public static void set_Value(this MonthCalendar instance, System.DateTime _Value) => UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("MSComCtl2.MonthView._Value");

	} 
	public static class System_Windows_Forms_Panel
	{

		public static void setCaption(this Panel instance, string Caption) => UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Threed.SSPanel.Caption");

	} 
	public static class System_Windows_Forms_WebBrowser
	{

		public static dynamic getObject(this WebBrowser instance)
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("SHDocVw.WebBrowser.Object");
			return default(object);
		}
		public static void setSilent(this WebBrowser instance, bool Silent) => UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("SHDocVw.WebBrowser.Silent");

	} 
	public static class UpgradeHelpers_DataGridViewFlex
	{
		public static int BandData(this UpgradeHelpers.DataGridViewFlex instance, int BandData_Arg)
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("MSHierarchicalFlexGridLib.MSHFlexGrid.BandData");
			return default(int);
		}
		//public static int getColAlignment(this UpgradeHelpers.DataGridViewFlex instance)
		//{
		//	UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("MSHierarchicalFlexGridLib.MSHFlexGrid.ColAlignment");
		//	return default(int);
		//}
		public static int RowPosition(this UpgradeHelpers.DataGridViewFlex instance, int Index)
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("MSHierarchicalFlexGridLib.MSHFlexGrid.RowPosition");
			return default(int);
		}
		public static void setBandData(this UpgradeHelpers.DataGridViewFlex instance, int BandData, int BandData2) => UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("MSHierarchicalFlexGridLib.MSHFlexGrid.BandData");

		public static void setRowPosition(this UpgradeHelpers.DataGridViewFlex instance, int RowPosition, int Index) => UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("MSHierarchicalFlexGridLib.MSHFlexGrid.RowPosition");

	} 
	public static class UpgradeHelpers_DB_ADO_ADORecordSetHelper
	{

		public static ADORecordSetHelper getClone(this ADORecordSetHelper instance)
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("ADODB.Recordset.Clone");
			return default(ADORecordSetHelper);
		}
		public static void Resync(this ADORecordSetHelper instance, AffectEnum AffectRecords, UpgradeStubs.ADODB_ResyncEnumEnum ResyncValues) => UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("ADODB.Recordset.Resync");

		public static bool Supports(this ADORecordSetHelper instance, UpgradeStubs.ADODB_CursorOptionEnumEnum CursorOptions)
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("ADODB.Recordset.Supports");
			return default(bool);
		}
	} 
	public static class UpgradeHelpers_Gui_Controls_TabControlExtension
	{

		public static void setTabsPerRow(this TabControlExtension instance, int TabsPerRow) => UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("TabDlg.SSTab.TabsPerRow");

	} 
	public class VB
	{

		public static UpgradeStubs.VB_Global getGlobal()
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("VB.Global");
			return default(UpgradeStubs.VB_Global);
		}
	} 
	public class VB_ControlArray
	{

	} 
	public class VB_Global
	{

		public void Load_Renamed(object object_Renamed) => UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("VB.Global.Load");

	} 
	public class VBA__HiddenModule
	{

		public static string InputB(int Number, short FileNumber)
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("VBA._HiddenModule.InputB");
			return default(string);
		}
	} 
	public class VBRUN_DataObjectFiles
	{

		public string Item(int index)
		{
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("VBRUN.DataObjectFiles.Item");
			return default(string);
		}
	} 

	public enum ADODB_CursorOptionEnumEnum
	{
		adResync = 131072,
		adAddNew = 16778240,
		adDelete = 16779264
	} 
	public enum ADODB_ExecuteOptionEnumEnum
	{
		adAsyncExecute = 16,
		adExecuteNoRecords = 128
	} 
	public enum ADODB_ResyncEnumEnum
	{
		adResyncUnderlyingValues = 1,
		adResyncAllValues = 2
	} 
	public enum System_Data_CommandTypeEnum
	{
		adModeShareDenyNone = 16
	}
}