using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Gui.Controls;
using UpgradeHelpers.Gui.Utils;
using UpgradeHelpers.Helpers;

namespace JETNET_Homebase
{
	internal partial class frm_CompanyBusinessTypes
		: System.Windows.Forms.Form
	{


		public int inCompID = 0;
		public int inJournID = 0;
		public bool SelectOnly = false;
		public string WhichOne = "";
		public bool ShowCancel = false;
		public string inMessage = "";
		public string inSelectionMode = "";

		private bool bIsABIInList = false;
		private bool isYACHTSelected = false;
		private bool isACSelected = false;
		private string primaryBusType = "";
		private int productListCount = 0;
		private bool bIsHistorical = false;

		private string RememberDefaultType = "";

		public frm_CompanyBusinessTypes()
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
			InitializeComponent();
		}




		public bool IsABI
		{
			get => bIsABIInList;
			set => bIsABIInList = value;
		}



		public bool IsAC
		{
			get => isACSelected;
			set => isACSelected = value;
		}




		public bool IsYacht
		{
			get => isYACHTSelected;
			set => isYACHTSelected = value;
		}





		public string PrimaryBusinessType
		{
			get => primaryBusType;
			set => primaryBusType = value;
		}


		private void FillAvailList()
		{

			string Query = "";
			ADORecordSetHelper snpBusTypes = new ADORecordSetHelper(); //aey 6/14/04
			string Separator = "";
			bool isABISelected = false;
			string found_one = "";
			try
			{

				if (SelectOnly)
				{

					cboAvailTypes.Visible = false;
					lblBusTypes.Text = "Select Business Type to Use";

					cmdAdd.Visible = false;
					cmdRemove.Visible = false;
					cmdUp.Visible = false;
					cmdDown.Visible = false;

					if (ShowCancel)
					{
						cmdCancel.Visible = true;
						ShowCancel = false;
					}
					else
					{
						cmdCancel.Visible = false;
					}

					cmdSave.Text = "Select";

				}
				else
				{

					Query = "SELECT * FROM Company_Business_Type WITH(NOLOCK) ";

					if (lstTypesUsed.Items.Count > 0)
					{
						Query = $"{Query}WHERE cbus_type NOT IN (";
						Separator = "";

						int tempForEndVar = lstTypesUsed.Items.Count - 1;
						for (int i = 0; i <= tempForEndVar; i++)
						{
							Query = $"{Query}{Separator}'{lstTypesUsed.GetListItem(i).Substring(0, Math.Min(2, lstTypesUsed.GetListItem(i).Length))}'";
							Separator = ",";
						}

						Query = $"{Query})";

						found_one = "N";

						if (bIsABIInList || isYACHTSelected || isACSelected)
						{
							Query = $"{Query} and ( ";

							if (bIsABIInList)
							{
								Query = $"{Query} cbus_abi_flag = 'Y' ";
								found_one = "Y";
							}

							if (isYACHTSelected)
							{
								if (found_one == "N")
								{
									Query = $"{Query} cbus_yacht_flag = 'Y'";
								}
								else
								{
									Query = $"{Query} or cbus_yacht_flag = 'Y'";
								}
								found_one = "Y";
							}


							if (isACSelected)
							{
								if (found_one == "N")
								{
									Query = $"{Query} cbus_aircraft_flag = 'Y'";
								}
								else
								{
									Query = $"{Query} or cbus_aircraft_flag = 'Y'";
								}
							}
							Query = $"{Query} ) ";
						}


						Query = $"{Query}ORDER BY cbus_abi_flag ASC";

					}

					snpBusTypes.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

					if (!(snpBusTypes.BOF && snpBusTypes.EOF))
					{


						while(!snpBusTypes.EOF)
						{

							if (Convert.ToString(snpBusTypes["cbus_abi_flag"]).ToUpper() == "Y")
							{
								cboAvailTypes.AddItem($"{Convert.ToString(snpBusTypes["cbus_type"]).Trim()} - * {Convert.ToString(snpBusTypes["cbus_name"]).Trim()} - (ABI)");
							}
							else
							{
								cboAvailTypes.AddItem($"{Convert.ToString(snpBusTypes["cbus_type"]).Trim()} - {Convert.ToString(snpBusTypes["cbus_name"]).Trim()}");
							}

							snpBusTypes.MoveNext();
						};

						snpBusTypes.Close();

					}

					snpBusTypes = null;

				}
			}
			catch (System.Exception excep)
			{

				snpBusTypes = null;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"FillAvailList_Error ({Information.Err().Number.ToString()}) {excep.Message} CMPID:[{inCompID.ToString()}] JID:[{inJournID.ToString()}]", "frm_CompanyBusinessTypes");
				return;
			}

		}

		private void FillUsedList()
		{

			string Query = "";
			ADORecordSetHelper snpBusTypes = new ADORecordSetHelper(); //6/14/04

			try
			{

				lstTypesUsed.Items.Clear();

				Query = "SELECT * FROM Business_Type_Reference WITH(NOLOCK), Company_Business_Type WITH(NOLOCK)";
				Query = $"{Query} WHERE cbus_type = bustypref_type";
				Query = $"{Query} AND bustypref_comp_id = {inCompID.ToString()}";
				Query = $"{Query} AND bustypref_journ_id = {inJournID.ToString()}";
				Query = $"{Query} ORDER BY bustypref_seq_no, cbus_abi_flag";

				snpBusTypes.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpBusTypes.BOF && snpBusTypes.EOF))
				{


					while(!snpBusTypes.EOF)
					{

						if (SelectOnly)
						{

							if (Convert.ToString(snpBusTypes["cbus_abi_flag"]).ToUpper() == "N")
							{

								lstTypesUsed.AddItem($"{Convert.ToString(snpBusTypes["bustypref_type"]).Trim()} - {Convert.ToString(snpBusTypes["cbus_name"]).Trim()}");
								lstTypesUsed.SetItemData(lstTypesUsed.GetNewIndex(), 0);

							}

						}
						else
						{
							if (Convert.ToString(snpBusTypes["cbus_abi_flag"]).ToUpper() == "Y")
							{

								lstTypesUsed.AddItem($"{Convert.ToString(snpBusTypes["bustypref_type"]).Trim()} - * {($"{Convert.ToString(snpBusTypes["cbus_name"])}").Trim()} - (ABI)");
								lstTypesUsed.SetItemData(lstTypesUsed.GetNewIndex(), 0);

							}
							else
							{

								lstTypesUsed.AddItem($"{Convert.ToString(snpBusTypes["bustypref_type"]).Trim()} - {Convert.ToString(snpBusTypes["cbus_name"]).Trim()}");
								lstTypesUsed.SetItemData(lstTypesUsed.GetNewIndex(), 0);

							}

						}

						snpBusTypes.MoveNext();
					};

					snpBusTypes.Close();

				}

				snpBusTypes = null;

				if (lstTypesUsed.Items.Count > 0)
				{
					RememberDefaultType = lstTypesUsed.GetListItem(0).Substring(0, Math.Min(2, lstTypesUsed.GetListItem(0).Length)).Trim();
					ListBoxHelper.SetSelectedIndex(lstTypesUsed, 0);
				}
				else
				{
					ListBoxHelper.SetSelectedIndex(lstTypesUsed, -1);
				}
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"FillUsedList_Error ({Information.Err().Number.ToString()}) {excep.Message} CMPID:[{inCompID.ToString()}] JID:[{inJournID.ToString()}]", "frm_CompanyBusinessTypes");
				return;
			}


		}

		private void SaveBusinessTypes()
		{

			string Query = "";
			int nCounter = 0;
			string Comma = "";
			string Msg = "";
			ADORecordSetHelper snpUsed = new ADORecordSetHelper(); //8/1/05 aey converted to ado

			try
			{

				StringBuilder business_types = new StringBuilder();
				string primary_business_name = "";
				if (lstTypesUsed.Items.Count > 0)
				{

					Query = "SELECT DISTINCT cref_business_type, cbus_name FROM Aircraft_Reference WITH(NOLOCK)";
					Query = $"{Query} INNER JOIN Company_Business_Type WITH(NOLOCK) ON cref_business_type = cbus_type";
					Query = $"{Query} inner join Aircraft with (NOLOCK) on  ac_id = cref_ac_id and ac_journ_id = 0 ";
					Query = $"{Query} WHERE cref_comp_id = {inCompID.ToString()} AND cref_journ_id = {inJournID.ToString()}";
					Query = $"{Query} and ac_lifecycle_stage = 3 ";
					Query = $"{Query} AND cref_business_type NOT IN (";
					Comma = "";

					int tempForEndVar = lstTypesUsed.Items.Count - 1;
					for (int i = 0; i <= tempForEndVar; i++)
					{
						Query = $"{Query}{Comma}'{lstTypesUsed.GetListItem(i).Substring(0, Math.Min(2, lstTypesUsed.GetListItem(i).Length)).Trim().ToUpper()}'";
						Comma = ", ";
					}

					Query = $"{Query})";

					snpUsed.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!(snpUsed.BOF && snpUsed.EOF))
					{

						Msg = $"The following Business Type(s) are in use on some Aircraft Reference(s).{Environment.NewLine}Please make sure that the business type listed below is included in the list prior to saving.{Environment.NewLine}{Environment.NewLine}";
						Comma = "";


						while(!snpUsed.EOF)
						{
							Msg = $"{Msg}{Comma}{Convert.ToString(snpUsed["cref_business_type"]).Trim()} - {Convert.ToString(snpUsed["cbus_name"]).Trim()}";
							Comma = Environment.NewLine;

							snpUsed.MoveNext();
						};

						snpUsed.Close();
						snpUsed = null;

						MessageBox.Show(Msg, "Save Business Type(s)", MessageBoxButtons.OK, MessageBoxIcon.Information);

					}
					else
					{

						modAdminCommon.ADO_Transaction("BeginTrans");

						business_types = new StringBuilder("");
						primary_business_name = "";

						int tempForEndVar2 = lstTypesUsed.Items.Count - 1;
						for (int x = 0; x <= tempForEndVar2; x++)
						{
							if (business_types.ToString().Trim() != "")
							{
								business_types.Append(",");
							}

							business_types.Append(lstTypesUsed.GetListItem(x).Substring(0, Math.Min(2, lstTypesUsed.GetListItem(x).Length)));

							if (x == 0)
							{
								primary_business_name = lstTypesUsed.GetListItem(0); // only get the primary
								primary_business_name = StringsHelper.Replace(primary_business_name, $"{business_types.ToString()} - ", "", 1, -1, CompareMethod.Binary);
							}
						}

						Query = "";
						Query = $" exec sp_Insert_Company_Business_Types {inCompID.ToString()} , '{lstTypesUsed.GetListItem(0).Substring(0, Math.Min(2, lstTypesUsed.GetListItem(0).Length)).Trim()}','{primary_business_name}','{business_types.ToString()}','{PrimaryBusinessType.Substring(0, Math.Min(2, PrimaryBusinessType.Length))}','{modAdminCommon.gbl_User_ID}','HB','{inJournID.ToString()}' ";
						DbCommand TempCommand = null;
						TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
						TempCommand.CommandText = Query;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
						TempCommand.ExecuteNonQuery();

						PrimaryBusinessType = lstTypesUsed.GetListItem(0).Trim();

						Query = $"UPDATE Company SET comp_action_date = NULL WHERE comp_id = {inCompID.ToString()} AND comp_journ_id = {inJournID.ToString()}";

						DbCommand TempCommand_2 = null;
						TempCommand_2 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
						TempCommand_2.CommandText = Query;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand_2.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
						TempCommand_2.ExecuteNonQuery();

						modAdminCommon.ADO_Transaction("CommitTrans");

						this.Close();

					}

				}
				else
				{
					MessageBox.Show("You must have at least one Business Type", "Save Business Type(s)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"SaveBusinessTypes_Error ({Information.Err().Number.ToString()}) {excep.Message} CMPID:[{inCompID.ToString()}] JID:[{inJournID.ToString()}]", "frm_CompanyBusinessTypes");
				return;
			}

		}

		private void cmdAdd_Click(Object eventSender, EventArgs eventArgs)
		{

			try
			{

				if (cboAvailTypes.Text.Trim() != "")
				{

					lstTypesUsed.AddItem(cboAvailTypes.Text.Trim());

					cmdSave.Visible = true;

					cmdRemove.Visible = !bIsHistorical;

					if (!SelectOnly)
					{
						if (cboAvailTypes.Items.Count > 0)
						{
							cboAvailTypes.RemoveItem(cboAvailTypes.SelectedIndex);
						}
					}

				}
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"cmdAdd_Click_Error ({Information.Err().Number.ToString()}) {excep.Message} CMPID:[{inCompID.ToString()}] JID:[{inJournID.ToString()}] listCT:[{cboAvailTypes.Items.Count.ToString()}] listIDX:[{cboAvailTypes.SelectedIndex.ToString()}] listITM:[{cboAvailTypes.Text.Trim()}]", "frm_CompanyBusunessTypes");
				return;
			}

		}

		private void cmdCancel_Click(Object eventSender, EventArgs eventArgs)
		{

			if (SelectOnly)
			{
				WhichOne = "";
			}

			this.Close();

		}

		private void cmdRemove_Click(Object eventSender, EventArgs eventArgs)
		{

			try
			{

				if (lstTypesUsed.SelectedItems.Count > 0)
				{
					if (lstTypesUsed.GetItemData(ListBoxHelper.GetSelectedIndex(lstTypesUsed)) == 0)
					{
						cboAvailTypes.AddItem(lstTypesUsed.Text);
						lstTypesUsed.RemoveItem(ListBoxHelper.GetSelectedIndex(lstTypesUsed));
					}
					else
					{
						if (inSelectionMode == "BusType")
						{
							MessageBox.Show("Cannot remove - Aircraft of this type exist on this Company", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						}
					}
				}

				if (lstTypesUsed.Items.Count == 0)
				{
					cmdSave.Visible = false;

					if (inSelectionMode == "BusType")
					{
						MessageBox.Show("Cannot remove the last Business Type", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					}

					lstTypesUsed.AddItem(cboAvailTypes.GetListItem(cboAvailTypes.Items.Count - 1));
					cboAvailTypes.RemoveItem(cboAvailTypes.Items.Count - 1);
				}
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"cmdRemove_Click_Error ({Information.Err().Number.ToString()}) {excep.Message} CMPID:[{inCompID.ToString()}] JID:[{inJournID.ToString()}] listCT:[{cboAvailTypes.Items.Count.ToString()}] listIDX:[{cboAvailTypes.SelectedIndex.ToString()}] listITM:[{cboAvailTypes.Text.Trim()}]", "frm_CompanyBusunessTypes");
				return;
			}

		}

		private void cmdSave_Click(Object eventSender, EventArgs eventArgs)
		{

			try
			{

				if (SelectOnly)
				{

					if (ListBoxHelper.GetSelectedIndex(lstTypesUsed) >= 0)
					{
						WhichOne = lstTypesUsed.Text;
						this.Close();
					}
					else
					{
						if (inSelectionMode == "BusType")
						{
							MessageBox.Show("You must select a Business Type", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						}
					}

				}
				else
				{

					if (inSelectionMode == "BusType")
					{
						SaveBusinessTypes();
					}

				}
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"cmdSave_Click_Error ({Information.Err().Number.ToString()}) {excep.Message} CMPID:[{inCompID.ToString()}] JID:[{inJournID.ToString()}]", "frm_CompanyBusunessTypes");
				return;
			}


		}

		private void cmdUp_Click(Object eventSender, EventArgs eventArgs)
		{

			int RememberIndex = 0;
			string RememberText = "";

			if (ListBoxHelper.GetSelectedIndex(lstTypesUsed) > 0)
			{
				RememberIndex = ListBoxHelper.GetSelectedIndex(lstTypesUsed);
				RememberText = lstTypesUsed.Text;

				lstTypesUsed.RemoveItem(ListBoxHelper.GetSelectedIndex(lstTypesUsed));

				lstTypesUsed.AddItem(RememberText, RememberIndex - 1);

				ListBoxHelper.SetSelectedIndex(lstTypesUsed, RememberIndex - 1);

			}

		}

		private void cmdDown_Click(Object eventSender, EventArgs eventArgs)
		{

			int RememberIndex = 0;
			string RememberText = "";

			if ((ListBoxHelper.GetSelectedIndex(lstTypesUsed) < lstTypesUsed.Items.Count - 1) && (ListBoxHelper.GetSelectedIndex(lstTypesUsed) >= 0))
			{
				RememberIndex = ListBoxHelper.GetSelectedIndex(lstTypesUsed);
				RememberText = lstTypesUsed.Text;

				lstTypesUsed.RemoveItem(ListBoxHelper.GetSelectedIndex(lstTypesUsed));
				lstTypesUsed.AddItem(RememberText, RememberIndex + 1);

				ListBoxHelper.SetSelectedIndex(lstTypesUsed, RememberIndex + 1);

			}

		}

		private void Form_Activated(Object eventSender, EventArgs eventArgs)
		{
			if (ActivateHelper.myActiveForm != eventSender)
			{
				ActivateHelper.myActiveForm = (Form) eventSender;

				if (bIsHistorical)
				{
					cmdRemove.Visible = false;
				}

			}
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
		private void Form_Load()
		{

			this.Cursor = CursorHelper.CursorDefault;

			if (inCompID > 0)
			{

				bIsHistorical = inJournID > 0;

				if (inSelectionMode == "BusType")
				{
					FillUsedList();
					FillAvailList();
				}

			}
			else
			{
				this.Close();
			}

		}
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}