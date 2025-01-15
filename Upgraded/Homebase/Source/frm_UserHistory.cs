using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Gui.Controls;
using UpgradeHelpers.Helpers;
using UpgradeStubs;

namespace JETNET_Homebase
{
	internal partial class frm_UserHistory
		: System.Windows.Forms.Form
	{

		public frm_UserHistory()
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


		private void frm_UserHistory_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}

		private ADORecordSetHelper _rstRec1 = null;
		private ADORecordSetHelper rstRec1
		{
			get
			{
				if (_rstRec1 is null)
				{
					_rstRec1 = new ADORecordSetHelper();
				}
				return _rstRec1;
			}
			set => _rstRec1 = value;
		}

		private ADORecordSetHelper _rstRec2 = null;
		private ADORecordSetHelper rstRec2
		{
			get
			{
				if (_rstRec2 is null)
				{
					_rstRec2 = new ADORecordSetHelper();
				}
				return _rstRec2;
			}
			set => _rstRec2 = value;
		}

		private string strQuery1 = "";
		private string strQuery2 = "";
		private int lCol1 = 0;
		private int lRow1 = 0;
		private int lACId = 0;
		private int lYTId = 0;
		private int lCompId = 0;
		private int lContactId = 0;
		private int lTabId = 0;
		private int lWantedId = 0;
		private int lJournId = 0;
		private string strMsg = "";
		private object lBkgColor = null;
		private bool bViewIds = false;
		private int bTotalRecords = 0;
		private int lEvtlId = 0;
		private int iMaxRec = 0;
		private string strLastForm = "";

		public void SetLastForm(string strFormName) => strLastForm = strFormName;


		private void ClearGridLeaveHeaders(UpgradeHelpers.DataGridViewFlex grdGrid)
		{

			grdGrid.RowsCount = 2;
			int tempForEndVar = grdGrid.ColumnsCount - 1;
			for (lCol1 = 0; lCol1 <= tempForEndVar; lCol1++)
			{
				grdGrid[1, lCol1].Value = "";
			}

		} // ClearGridLeaveHeaders


		public modGlobalVars.e_first_start_form StartForm
		{
			get => modGlobalVars.tStart_Form;
			set => modGlobalVars.tStart_Form = value;
		}


		private bool Already_In_Grid(UpgradeHelpers.DataGridViewFlex grdGrid, int lCol1, string strValue1, int lCol2, string strValue2)
		{


			bool bResults = false;

			if (grdGrid.RowsCount > 1)
			{

				if (Convert.ToString(grdGrid[1, 0].Value).Trim() != "")
				{

					int tempForEndVar = grdGrid.RowsCount - 1;
					for (int lCnt1 = 1; lCnt1 <= tempForEndVar; lCnt1++)
					{

						if (strValue1 != "")
						{
							if (Convert.ToString(grdGrid[lCnt1, lCol1].Value).Trim() == strValue1)
							{
								bResults = true;
							}
						}

						if (bResults)
						{
							if (strValue2 != "")
							{
								bResults = false;
								if (Convert.ToString(grdGrid[lCnt1, lCol2].Value).Trim() == strValue2)
								{
									bResults = true;
								}
							}
						}

						if (bResults)
						{
							break;
						}

					}

				} // If Trim(grdGrid.TextMatrix(1, 0)) <> "" Then

			} // If grdGrid.Rows > 1 Then


			return bResults;

		} // Already_In_Grid

		private void Read_User_History_Recordset()
		{

			strQuery1 = $"SELECT * FROM EventLog WITH (NOLOCK) WHERE (evtl_date >= '{DateTime.Now.ToString("MM/dd/yyyy")}') ";
			strQuery1 = $"{strQuery1}AND (evtl_type = 'Monitor Activity') AND (evtl_message LIKE 'Open%' OR evtl_message LIKE 'Callback%' OR evtl_message LIKE 'Aircraft Search%' OR evtl_message LIKE 'Company Search%' OR evtl_message LIKE 'Yacht Search%') ";
			strQuery1 = $"{strQuery1}AND (evtl_user_id = '{modAdminCommon.gbl_User_ID}') ORDER BY evtl_date DESC ";

			if (modAdminCommon.LOCAL_ADO_DB != null)
			{

				if (modAdminCommon.LOCAL_ADO_DB.State == ConnectionState.Open)
				{

					if (rstRec1 == null)
					{
						rstRec1 = new ADORecordSetHelper();
					}

					if (rstRec1.State == ConnectionState.Open)
					{
						rstRec1.Close();
					}

					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				} // If LOCAL_ADO_DB.State = adStateOpen Then

			} // If (LOCAL_ADO_DB Is Nothing) = False Then

		} // Read_User_History_Recordset

		private void Load_User_History_Aircraft_Grid_Headers()
		{

			grdAircraft.Clear();
			grdAircraft.RowsCount = 2;
			grdAircraft.ColumnsCount = 6;
			grdAircraft.CurrentRowIndex = 0;

			lCol1 = -1;

			lCol1++;
			grdAircraft.CurrentColumnIndex = lCol1;
			grdAircraft[grdAircraft.CurrentRowIndex, grdAircraft.CurrentColumnIndex].Value = "ACId";
			if (!bViewIds)
			{
				grdAircraft.SetColumnWidth(lCol1, 0);
			}
			else
			{
				grdAircraft.SetColumnWidth(lCol1, 60);
			}
			grdAircraft.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

			lCol1++;
			grdAircraft.CurrentColumnIndex = lCol1;
			grdAircraft[grdAircraft.CurrentRowIndex, grdAircraft.CurrentColumnIndex].Value = "JournId";
			if (!bViewIds)
			{
				grdAircraft.SetColumnWidth(lCol1, 0);
			}
			else
			{
				grdAircraft.SetColumnWidth(lCol1, 60);
			}
			grdAircraft.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

			lCol1++;
			grdAircraft.CurrentColumnIndex = lCol1;
			grdAircraft[grdAircraft.CurrentRowIndex, grdAircraft.CurrentColumnIndex].Value = "Make";
			grdAircraft.SetColumnWidth(lCol1, 120);
			grdAircraft.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			grdAircraft.CurrentColumnIndex = lCol1;
			grdAircraft[grdAircraft.CurrentRowIndex, grdAircraft.CurrentColumnIndex].Value = "Model";
			grdAircraft.SetColumnWidth(lCol1, 113);
			grdAircraft.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			grdAircraft.CurrentColumnIndex = lCol1;
			grdAircraft[grdAircraft.CurrentRowIndex, grdAircraft.CurrentColumnIndex].Value = "SerNbr";
			grdAircraft.SetColumnWidth(lCol1, 87);
			grdAircraft.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			grdAircraft.CurrentColumnIndex = lCol1;
			grdAircraft[grdAircraft.CurrentRowIndex, grdAircraft.CurrentColumnIndex].Value = "RegNbr";
			grdAircraft.SetColumnWidth(lCol1, 73);
			grdAircraft.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			grdAircraft.CurrentRowIndex = 1;
			grdAircraft.CurrentColumnIndex = 2;
			grdAircraft[grdAircraft.CurrentRowIndex, grdAircraft.CurrentColumnIndex].Value = "No Records Found";

			grdAircraft.FixedRows = 1;
			grdAircraft.FixedColumns = 0;
			grdAircraft.CurrentRowIndex = 1;

		} // Load_User_History_Aircraft_Grid_Headers

		private void Load_User_History_Aircraft_Grid(bool bRefreshRecordset = false)
		{

			try
			{

				if (bRefreshRecordset)
				{
					Read_User_History_Recordset();
				}

				ClearGridLeaveHeaders(grdAircraft);

				if (rstRec1.State == ConnectionState.Open)
				{

					if (rstRec1.RecordCount > 0)
					{

						rstRec1.MoveFirst();
						if (!rstRec1.BOF && !rstRec1.EOF)
						{

							lRow1 = 0;

							do 
							{ // Loop Until rstRec1.EOF = True

								strMsg = ($"{Convert.ToString(rstRec1["evtl_message"])} ").Trim();

								if (strMsg.StartsWith("Open Aircraft", StringComparison.Ordinal))
								{

									lACId = Convert.ToInt32(rstRec1["evtl_ac_id"]);
									lJournId = Convert.ToInt32(rstRec1["evtl_journ_id"]);

									if (!Already_In_Grid(grdAircraft, 0, lACId.ToString(), 1, lJournId.ToString()))
									{

										lBkgColor = 0x80000005; // White
										if (lJournId > 0)
										{
											lBkgColor = 0xC0C0C0;
										} // Gray

										strQuery2 = "SELECT amod_make_name, amod_model_name, ac_ser_no_full, ac_reg_no ";
										strQuery2 = $"{strQuery2}FROM Aircraft_Model WITH (NOLOCK) INNER JOIN Aircraft WITH (NOLOCK) ON ac_amod_id = amod_id ";
										strQuery2 = $"{strQuery2}WHERE (ac_id = {lACId.ToString()}) AND (ac_journ_id = {lJournId.ToString()}) ";

										rstRec2.Open(strQuery2, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

										if (!rstRec2.BOF && !rstRec2.EOF)
										{

											lRow1++;
											grdAircraft.RowsCount = lRow1 + 1;
											grdAircraft.CurrentRowIndex = lRow1;

											grdAircraft.set_RowData(lRow1,Convert.ToInt32( rstRec1.GetField("evtl_id")));

											lCol1 = -1;

											lCol1++;
											grdAircraft.CurrentColumnIndex = lCol1;
											grdAircraft[grdAircraft.CurrentRowIndex, grdAircraft.CurrentColumnIndex].Value = lACId.ToString();
											//UPGRADE_WARNING: (1068) lBkgColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
											grdAircraft.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lBkgColor));
											grdAircraft.CellAlignment = DataGridViewContentAlignment.MiddleRight;

											lCol1++;
											grdAircraft.CurrentColumnIndex = lCol1;
											grdAircraft[grdAircraft.CurrentRowIndex, grdAircraft.CurrentColumnIndex].Value = lJournId.ToString();
											//UPGRADE_WARNING: (1068) lBkgColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
											grdAircraft.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lBkgColor));
											grdAircraft.CellAlignment = DataGridViewContentAlignment.MiddleRight;

											lCol1++;
											grdAircraft.CurrentColumnIndex = lCol1;
											grdAircraft[grdAircraft.CurrentRowIndex, grdAircraft.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec2["amod_make_name"])} ").Trim();
											//UPGRADE_WARNING: (1068) lBkgColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
											grdAircraft.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lBkgColor));
											grdAircraft.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

											lCol1++;
											grdAircraft.CurrentColumnIndex = lCol1;
											grdAircraft[grdAircraft.CurrentRowIndex, grdAircraft.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec2["amod_model_name"])} ").Trim();
											//UPGRADE_WARNING: (1068) lBkgColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
											grdAircraft.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lBkgColor));
											grdAircraft.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

											lCol1++;
											grdAircraft.CurrentColumnIndex = lCol1;
											grdAircraft[grdAircraft.CurrentRowIndex, grdAircraft.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec2["ac_ser_no_full"])} ").Trim();
											//UPGRADE_WARNING: (1068) lBkgColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
											grdAircraft.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lBkgColor));
											grdAircraft.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

											lCol1++;
											grdAircraft.CurrentColumnIndex = lCol1;
											grdAircraft[grdAircraft.CurrentRowIndex, grdAircraft.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec2["ac_reg_no"])} ").Trim();
											//UPGRADE_WARNING: (1068) lBkgColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
											grdAircraft.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lBkgColor));
											grdAircraft.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

										} // If rstRec2.BOF = False And rstRec2.EOF = False Then

										rstRec2.Close();

									} // If Already_In_Grid(grdAircraft, 0, CStr(lACId), 1, CStr(lJournId)) = False Then

								} // If left(strMsg, 13) = "Open Aircraft" Then

								rstRec1.MoveNext();

							}
							while(!(rstRec1.EOF || grdAircraft.RowsCount >= iMaxRec));

							rstRec1.MoveFirst();

						}
						else
						{
							grdAircraft.CurrentColumnIndex = 2;
							grdAircraft[grdAircraft.CurrentRowIndex, grdAircraft.CurrentColumnIndex].Value = "No Records Found";
							//UPGRADE_WARNING: (1068) lBkgColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
							grdAircraft.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lBkgColor));
							grdAircraft.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					} // If rstRec1.RecordCount > 0 Then

				} // If rstRec1.State = adStateOpen Then
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Load_User_History_Aircraft_Grid_Error", excep.Message);
			}

		} // Load_User_History_Aircraft_Grid

		private void Load_User_History_Yacht_Grid_Headers()
		{

			grdYacht.Clear();
			grdYacht.RowsCount = 2;
			grdYacht.ColumnsCount = 5;
			grdYacht.CurrentRowIndex = 0;

			lCol1 = -1;

			lCol1++;
			grdYacht.CurrentColumnIndex = lCol1;
			grdYacht[grdYacht.CurrentRowIndex, grdYacht.CurrentColumnIndex].Value = "YTId";
			if (!bViewIds)
			{
				grdYacht.SetColumnWidth(lCol1, 0);
			}
			else
			{
				grdYacht.SetColumnWidth(lCol1, 60);
			}
			grdYacht.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

			lCol1++;
			grdYacht.CurrentColumnIndex = lCol1;
			grdYacht[grdYacht.CurrentRowIndex, grdYacht.CurrentColumnIndex].Value = "JournId";
			if (!bViewIds)
			{
				grdYacht.SetColumnWidth(lCol1, 0);
			}
			else
			{
				grdYacht.SetColumnWidth(lCol1, 60);
			}
			grdYacht.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

			lCol1++;
			grdYacht.CurrentColumnIndex = lCol1;
			grdYacht[grdYacht.CurrentRowIndex, grdYacht.CurrentColumnIndex].Value = "Brand";
			grdYacht.SetColumnWidth(lCol1, 133);
			grdYacht.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			grdYacht.CurrentColumnIndex = lCol1;
			grdYacht[grdYacht.CurrentRowIndex, grdYacht.CurrentColumnIndex].Value = "Model";
			grdYacht.SetColumnWidth(lCol1, 127);
			grdYacht.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			grdYacht.CurrentColumnIndex = lCol1;
			grdYacht[grdYacht.CurrentRowIndex, grdYacht.CurrentColumnIndex].Value = "Name";
			grdYacht.SetColumnWidth(lCol1, 127);
			grdYacht.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			grdYacht.CurrentRowIndex = 1;
			grdYacht.CurrentColumnIndex = 2;
			grdYacht[grdYacht.CurrentRowIndex, grdYacht.CurrentColumnIndex].Value = "No Records Found";

			grdYacht.FixedRows = 1;
			grdYacht.FixedColumns = 0;
			grdYacht.CurrentRowIndex = 1;

		} // Load_User_History_Yacht_Grid_Headers

		private void Load_User_History_Yacht_Grid(bool bRefreshRecordset = false)
		{

			try
			{

				if (bRefreshRecordset)
				{
					Read_User_History_Recordset();
				}

				ClearGridLeaveHeaders(grdYacht);

				if (rstRec1.State == ConnectionState.Open)
				{

					if (rstRec1.RecordCount > 0)
					{

						rstRec1.MoveFirst();
						if (!rstRec1.BOF && !rstRec1.EOF)
						{

							lRow1 = 0;

							do 
							{ // Loop Until rstRec1.EOF = True

								strMsg = ($"{Convert.ToString(rstRec1["evtl_message"])} ").Trim();

								if (strMsg.StartsWith("Open Yacht", StringComparison.Ordinal))
								{

									lYTId = Convert.ToInt32(rstRec1["evtl_yacht_id"]);
									lJournId = Convert.ToInt32(rstRec1["evtl_journ_id"]);

									if (!Already_In_Grid(grdYacht, 0, lYTId.ToString(), 1, lJournId.ToString()))
									{

										lBkgColor = 0x80000005; // White
										if (lJournId > 0)
										{
											lBkgColor = 0xC0C0C0;
										} // Gray

										strQuery2 = "SELECT yt_id, ym_brand_name, ym_model_name, yt_yacht_name ";
										strQuery2 = $"{strQuery2}FROM Yacht_Model WITH (NOLOCK) INNER JOIN Yacht WITH (NOLOCK) ON yt_model_id = ym_model_id ";
										strQuery2 = $"{strQuery2}WHERE (yt_id = {lYTId.ToString()}) AND (yt_journ_id = {lJournId.ToString()}) ";

										rstRec2.Open(strQuery2, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

										if (!rstRec2.BOF && !rstRec2.EOF)
										{

											lRow1++;
											grdYacht.RowsCount = lRow1 + 1;
											grdYacht.CurrentRowIndex = lRow1;

											grdYacht.set_RowData(lRow1,Convert.ToInt32( rstRec1.GetField("evtl_id")));

											lCol1 = -1;

											lCol1++;
											grdYacht.CurrentColumnIndex = lCol1;
											grdYacht[grdYacht.CurrentRowIndex, grdYacht.CurrentColumnIndex].Value = lYTId.ToString();
											//UPGRADE_WARNING: (1068) lBkgColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
											grdYacht.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lBkgColor));
											grdYacht.CellAlignment = DataGridViewContentAlignment.MiddleRight;

											lCol1++;
											grdYacht.CurrentColumnIndex = lCol1;
											grdYacht[grdYacht.CurrentRowIndex, grdYacht.CurrentColumnIndex].Value = lJournId.ToString();
											//UPGRADE_WARNING: (1068) lBkgColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
											grdYacht.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lBkgColor));
											grdYacht.CellAlignment = DataGridViewContentAlignment.MiddleRight;

											lCol1++;
											grdYacht.CurrentColumnIndex = lCol1;
											grdYacht[grdYacht.CurrentRowIndex, grdYacht.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec2["ym_brand_name"])} ").Trim();
											//UPGRADE_WARNING: (1068) lBkgColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
											grdYacht.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lBkgColor));
											grdYacht.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

											lCol1++;
											grdYacht.CurrentColumnIndex = lCol1;
											grdYacht[grdYacht.CurrentRowIndex, grdYacht.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec2["ym_model_name"])} ").Trim();
											//UPGRADE_WARNING: (1068) lBkgColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
											grdYacht.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lBkgColor));
											grdYacht.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

											lCol1++;
											grdYacht.CurrentColumnIndex = lCol1;
											grdYacht[grdYacht.CurrentRowIndex, grdYacht.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec2["yt_yacht_name"])} ").Trim();
											//UPGRADE_WARNING: (1068) lBkgColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
											grdYacht.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lBkgColor));
											grdYacht.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

										} // If rstRec2.BOF = False And rstRec2.EOF = False Then

										rstRec2.Close();

									} // If Already_In_Grid(grdYacht, 0, CStr(lYTId), 1, CStr(lJournId)) = False Then

								} // If left(strMsg, 10) = "Open Yacht" Then

								rstRec1.MoveNext();

							}
							while(!(rstRec1.EOF || grdYacht.RowsCount >= iMaxRec));

							rstRec1.MoveFirst();

						}
						else
						{
							grdYacht.CurrentColumnIndex = 2;
							grdYacht[grdYacht.CurrentRowIndex, grdYacht.CurrentColumnIndex].Value = "No Records Found";
							//UPGRADE_WARNING: (1068) lBkgColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
							grdYacht.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lBkgColor));
							grdYacht.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					} // If rstRec1.RecordCount > 0 Then

				} // If rstRec1.State = adStateOpen Then
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Load_User_History_Yacht_Grid_Error", excep.Message);
			}

		} // Load_User_History_Yacht_Grid

		private void Load_User_History_Company_Grid_Headers()
		{

			grdCompany.Clear();
			grdCompany.RowsCount = 2;
			grdCompany.ColumnsCount = 4;
			grdCompany.CurrentRowIndex = 0;

			lCol1 = -1;

			lCol1++;
			grdCompany.CurrentColumnIndex = lCol1;
			grdCompany[grdCompany.CurrentRowIndex, grdCompany.CurrentColumnIndex].Value = "CompId";
			if (!bViewIds)
			{
				grdCompany.SetColumnWidth(lCol1, 0);
			}
			else
			{
				grdCompany.SetColumnWidth(lCol1, 60);
			}
			grdCompany.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

			lCol1++;
			grdCompany.CurrentColumnIndex = lCol1;
			grdCompany[grdCompany.CurrentRowIndex, grdCompany.CurrentColumnIndex].Value = "JournId";
			if (!bViewIds)
			{
				grdCompany.SetColumnWidth(lCol1, 0);
			}
			else
			{
				grdCompany.SetColumnWidth(lCol1, 60);
			}
			grdCompany.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

			lCol1++;
			grdCompany.CurrentColumnIndex = lCol1;
			grdCompany[grdCompany.CurrentRowIndex, grdCompany.CurrentColumnIndex].Value = "Company";
			grdCompany.SetColumnWidth(lCol1, 187);
			grdCompany.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			grdCompany.CurrentColumnIndex = lCol1;
			grdCompany[grdCompany.CurrentRowIndex, grdCompany.CurrentColumnIndex].Value = "Country, State, City";
			grdCompany.SetColumnWidth(lCol1, 200);
			grdCompany.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			grdCompany.CurrentRowIndex = 1;
			grdCompany.CurrentColumnIndex = 2;
			grdCompany[grdCompany.CurrentRowIndex, grdCompany.CurrentColumnIndex].Value = "No Records Found";

			grdCompany.FixedRows = 1;
			grdCompany.FixedColumns = 0;
			grdCompany.CurrentRowIndex = 1;

		} // Load_User_History_Company_Grid_Headers

		private void Load_User_History_Company_Grid(bool bRefreshRecordset = false)
		{

			try
			{

				if (bRefreshRecordset)
				{
					Read_User_History_Recordset();
				}

				ClearGridLeaveHeaders(grdCompany);

				if (rstRec1.State == ConnectionState.Open)
				{

					if (rstRec1.RecordCount > 0)
					{

						rstRec1.MoveFirst();
						if (!rstRec1.BOF && !rstRec1.EOF)
						{

							lRow1 = 0;

							do 
							{ // Loop Until rstRec1.EOF = True

								strMsg = ($"{Convert.ToString(rstRec1["evtl_message"])} ").Trim();

								if (strMsg.StartsWith("Open Company", StringComparison.Ordinal))
								{

									lCompId = Convert.ToInt32(rstRec1["evtl_comp_id"]);
									lJournId = Convert.ToInt32(rstRec1["evtl_journ_id"]);

									if (!Already_In_Grid(grdCompany, 0, lCompId.ToString(), 1, lJournId.ToString()))
									{

										lBkgColor = 0x80000005; // White
										if (lJournId > 0)
										{
											lBkgColor = 0xC0C0C0;
										} // Gray

										strQuery2 = "SELECT comp_id, comp_name, comp_city, comp_state, comp_country ";
										strQuery2 = $"{strQuery2}FROM Company WITH (NOLOCK) WHERE (comp_id = {lCompId.ToString()}) ";
										strQuery2 = $"{strQuery2}AND (comp_journ_id = {lJournId.ToString()}) ";

										rstRec2.Open(strQuery2, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

										if (!rstRec2.BOF && !rstRec2.EOF)
										{

											lRow1++;
											grdCompany.RowsCount = lRow1 + 1;
											grdCompany.CurrentRowIndex = lRow1;

											grdCompany.set_RowData(lRow1,Convert.ToInt32( rstRec1.GetField("evtl_id")));

											lCol1 = -1;

											lCol1++;
											grdCompany.CurrentColumnIndex = lCol1;
											grdCompany[grdCompany.CurrentRowIndex, grdCompany.CurrentColumnIndex].Value = lCompId.ToString();
											//UPGRADE_WARNING: (1068) lBkgColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
											grdCompany.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lBkgColor));
											grdCompany.CellAlignment = DataGridViewContentAlignment.MiddleRight;

											lCol1++;
											grdCompany.CurrentColumnIndex = lCol1;
											grdCompany[grdCompany.CurrentRowIndex, grdCompany.CurrentColumnIndex].Value = lJournId.ToString();
											//UPGRADE_WARNING: (1068) lBkgColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
											grdCompany.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lBkgColor));
											grdCompany.CellAlignment = DataGridViewContentAlignment.MiddleRight;

											lCol1++;
											grdCompany.CurrentColumnIndex = lCol1;
											grdCompany[grdCompany.CurrentRowIndex, grdCompany.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec2["comp_name"])} ").Trim();
											//UPGRADE_WARNING: (1068) lBkgColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
											grdCompany.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lBkgColor));
											grdCompany.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

											lCol1++;
											grdCompany.CurrentColumnIndex = lCol1;
											grdCompany[grdCompany.CurrentRowIndex, grdCompany.CurrentColumnIndex].Value = $"{($"{Convert.ToString(rstRec2["Comp_country"])} ").Trim()} {($"{Convert.ToString(rstRec2["comp_state"])} ").Trim()} {($"{Convert.ToString(rstRec2["Comp_city"])} ").Trim()}";
											//UPGRADE_WARNING: (1068) lBkgColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
											grdCompany.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lBkgColor));
											grdCompany.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

										} // If rstRec2.BOF = False And rstRec2.EOF = False Then

										rstRec2.Close();

									} // If Already_In_Grid(grdCompany, 0, CStr(lCompId), 1, CStr(lJournId)) = False Then

								} // If left(strMsg, 12) = "Open Company" Then

								rstRec1.MoveNext();

							}
							while(!(rstRec1.EOF || grdCompany.RowsCount >= iMaxRec));

							rstRec1.MoveFirst();

						}
						else
						{
							grdCompany.CurrentColumnIndex = 2;
							grdCompany[grdCompany.CurrentRowIndex, grdCompany.CurrentColumnIndex].Value = "No Records Found";
							//UPGRADE_WARNING: (1068) lBkgColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
							grdCompany.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lBkgColor));
							grdCompany.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					} // If rstRec1.RecordCount > 0 Then

				} // If rstRec1.State = adStateOpen Then
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Load_User_History_Company_Grid_Error", excep.Message);
			}

		} // Load_User_History_Company_Grid

		private void Load_User_History_Contact_Grid_Headers()
		{

			grdContact.Clear();
			grdContact.RowsCount = 2;
			grdContact.ColumnsCount = 6;
			grdContact.CurrentRowIndex = 0;


			lCol1 = -1;

			lCol1++;
			grdContact.CurrentColumnIndex = lCol1;
			grdContact[grdContact.CurrentRowIndex, grdContact.CurrentColumnIndex].Value = "ContactId";
			if (!bViewIds)
			{
				grdContact.SetColumnWidth(lCol1, 0);
			}
			else
			{
				grdContact.SetColumnWidth(lCol1, 60);
			}
			grdContact.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

			lCol1++;
			grdContact.CurrentColumnIndex = lCol1;
			grdContact[grdContact.CurrentRowIndex, grdContact.CurrentColumnIndex].Value = "CompId";
			if (!bViewIds)
			{
				grdContact.SetColumnWidth(lCol1, 0);
			}
			else
			{
				grdContact.SetColumnWidth(lCol1, 60);
			}
			grdContact.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

			lCol1++;
			grdContact.CurrentColumnIndex = lCol1;
			grdContact[grdContact.CurrentRowIndex, grdContact.CurrentColumnIndex].Value = "JournId";
			if (!bViewIds)
			{
				grdContact.SetColumnWidth(lCol1, 0);
			}
			else
			{
				grdContact.SetColumnWidth(lCol1, 60);
			}
			grdContact.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

			lCol1++;
			grdContact.CurrentColumnIndex = lCol1;
			grdContact[grdContact.CurrentRowIndex, grdContact.CurrentColumnIndex].Value = "Contact";
			grdContact.SetColumnWidth(lCol1, 220);
			grdContact.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			grdContact.CurrentColumnIndex = lCol1;
			grdContact[grdContact.CurrentRowIndex, grdContact.CurrentColumnIndex].Value = "Title";
			grdContact.SetColumnWidth(lCol1, 173);
			grdContact.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			grdContact.CurrentColumnIndex = lCol1;
			grdContact[grdContact.CurrentRowIndex, grdContact.CurrentColumnIndex].Value = "Company";
			grdContact.SetColumnWidth(lCol1, 0);
			grdContact.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			grdContact.CurrentRowIndex = 1;
			grdContact.CurrentColumnIndex = 3;
			grdContact[grdContact.CurrentRowIndex, grdContact.CurrentColumnIndex].Value = "No Records Found";

			grdContact.FixedRows = 1;
			grdContact.FixedColumns = 0;
			grdContact.CurrentRowIndex = 1;

		} // Load_User_History_Contact_Grid_Headers

		private void Load_User_History_Contact_Grid(bool bRefreshRecordset = false)
		{

			try
			{

				if (bRefreshRecordset)
				{
					Read_User_History_Recordset();
				}

				ClearGridLeaveHeaders(grdContact);

				if (rstRec1.State == ConnectionState.Open)
				{

					if (rstRec1.RecordCount > 0)
					{

						rstRec1.MoveFirst();
						if (!rstRec1.BOF && !rstRec1.EOF)
						{

							lRow1 = 0;

							do 
							{ // Loop Until rstRec1.EOF = True

								strMsg = ($"{Convert.ToString(rstRec1["evtl_message"])} ").Trim();

								if (strMsg.StartsWith("Open Contact", StringComparison.Ordinal))
								{

									lCompId = Convert.ToInt32(rstRec1["evtl_comp_id"]);
									lContactId = Convert.ToInt32(rstRec1["evtl_contact_id"]);
									lJournId = Convert.ToInt32(rstRec1["evtl_journ_id"]);

									if (!Already_In_Grid(grdContact, 0, lContactId.ToString(), 2, lJournId.ToString()))
									{

										lBkgColor = 0x80000005; // White
										if (lJournId > 0)
										{
											lBkgColor = 0xC0C0C0;
										} // Gray

										strQuery2 = "SELECT contact_comp_id, contact_id, contact_title, ";
										strQuery2 = $"{strQuery2}dbo.CreateContactFullNameTitle(contact_sirname, contact_first_name, contact_middle_initial, contact_last_name, contact_suffix, '') As Contact, comp_name, comp_country ";
										strQuery2 = $"{strQuery2}FROM Contact WITH (NOLOCK) INNER JOIN Company WITH (NOLOCK) ON comp_id = contact_comp_id AND comp_journ_id = contact_journ_id ";
										strQuery2 = $"{strQuery2}WHERE (contact_comp_id = {lCompId.ToString()}) AND (contact_id = {lContactId.ToString()})  AND (contact_journ_id = {lJournId.ToString()}) ";

										rstRec2.Open(strQuery2, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

										if (!rstRec2.BOF && !rstRec2.EOF)
										{

											lRow1++;
											grdContact.RowsCount = lRow1 + 1;
											grdContact.CurrentRowIndex = lRow1;

											grdContact.set_RowData(lRow1,Convert.ToInt32( rstRec1.GetField("evtl_id")));

											lCol1 = -1;

											lCol1++;
											grdContact.CurrentColumnIndex = lCol1;
											grdContact[grdContact.CurrentRowIndex, grdContact.CurrentColumnIndex].Value = lContactId.ToString();
											//UPGRADE_WARNING: (1068) lBkgColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
											grdContact.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lBkgColor));
											grdContact.CellAlignment = DataGridViewContentAlignment.MiddleRight;

											lCol1++;
											grdContact.CurrentColumnIndex = lCol1;
											grdContact[grdContact.CurrentRowIndex, grdContact.CurrentColumnIndex].Value = lCompId.ToString();
											//UPGRADE_WARNING: (1068) lBkgColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
											grdContact.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lBkgColor));
											grdContact.CellAlignment = DataGridViewContentAlignment.MiddleRight;

											lCol1++;
											grdContact.CurrentColumnIndex = lCol1;
											grdContact[grdContact.CurrentRowIndex, grdContact.CurrentColumnIndex].Value = lJournId.ToString();
											//UPGRADE_WARNING: (1068) lBkgColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
											grdContact.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lBkgColor));
											grdContact.CellAlignment = DataGridViewContentAlignment.MiddleRight;

											lCol1++;
											grdContact.CurrentColumnIndex = lCol1;
											grdContact[grdContact.CurrentRowIndex, grdContact.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec2["CONTACT"])} ").Trim();
											//UPGRADE_WARNING: (1068) lBkgColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
											grdContact.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lBkgColor));
											grdContact.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

											lCol1++;
											grdContact.CurrentColumnIndex = lCol1;
											grdContact[grdContact.CurrentRowIndex, grdContact.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec2["contact_title"])} ").Trim();
											//UPGRADE_WARNING: (1068) lBkgColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
											grdContact.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lBkgColor));
											grdContact.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

											lCol1++;
											grdContact.CurrentColumnIndex = lCol1;
											grdContact[grdContact.CurrentRowIndex, grdContact.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec2["comp_name"])} ").Trim();
											if (($"{Convert.ToString(rstRec2["Comp_country"])} ").Trim() != "")
											{
												grdContact[grdContact.CurrentRowIndex, grdContact.CurrentColumnIndex].Value = $"{grdContact[grdContact.CurrentRowIndex, grdContact.CurrentColumnIndex].FormattedValue.ToString()}, {($"{Convert.ToString(rstRec2["Comp_country"])} ").Trim()}";
											}

											//UPGRADE_WARNING: (1068) lBkgColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
											grdContact.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lBkgColor));
											grdContact.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

										} // If rstRec2.BOF = False And rstRec2.EOF = False Then

										rstRec2.Close();

									} // If Already_In_Grid(grdContact, 0, CStr(lContactId), 2, CStr(lJournId)) = False Then

								} // If left(strMsg, 12) = "Open Contact" Then

								rstRec1.MoveNext();

							}
							while(!(rstRec1.EOF || grdContact.RowsCount >= iMaxRec));

							rstRec1.MoveFirst();

						}
						else
						{
							grdContact.CurrentColumnIndex = 3;
							grdContact[grdContact.CurrentRowIndex, grdContact.CurrentColumnIndex].Value = "No Records Found";
							//UPGRADE_WARNING: (1068) lBkgColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
							grdContact.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lBkgColor));
							grdContact.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					} // If rstRec1.RecordCount > 0 Then

				} // If rstRec1.State = adStateOpen Then
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Load_User_History_Contact_Grid_Error", excep.Message);
			}

		} // Load_User_History_Contact_Grid

		private void Load_User_History_Callback_Grid_Headers()
		{

			grdCallback.Clear();
			grdCallback.RowsCount = 2;
			grdCallback.ColumnsCount = 2;
			grdCallback.CurrentRowIndex = 0;

			lCol1 = -1;

			lCol1++;
			grdCallback.CurrentColumnIndex = lCol1;
			grdCallback[grdCallback.CurrentRowIndex, grdCallback.CurrentColumnIndex].Value = "TabId";
			if (!bViewIds)
			{
				grdCallback.SetColumnWidth(lCol1, 0);
			}
			else
			{
				grdCallback.SetColumnWidth(lCol1, 40);
			}
			grdCallback.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

			lCol1++;
			grdCallback.CurrentColumnIndex = lCol1;
			grdCallback[grdCallback.CurrentRowIndex, grdCallback.CurrentColumnIndex].Value = "Callback Name";
			grdCallback.SetColumnWidth(lCol1, 300);
			grdCallback.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			grdCallback.CurrentRowIndex = 1;
			grdCallback.CurrentColumnIndex = 1;
			grdCallback[grdCallback.CurrentRowIndex, grdCallback.CurrentColumnIndex].Value = "No Records Found";

			grdCallback.FixedRows = 1;
			grdCallback.FixedColumns = 0;
			grdCallback.CurrentRowIndex = 1;

		} // Load_User_History_Callback_Grid_Headers

		private int Return_Callback_Tab_Id(string strMsg, ref string strName)
		{


			int lResults = 0;

			int iPos1 = (strMsg.IndexOf(':') + 1);

			if (iPos1 > 0)
			{
				strName = strMsg.Substring(0, Math.Min(iPos1 - 1, strMsg.Length));


				switch(strName)
				{
					case "Callback Aircraft" : 
						lResults = 0; 
						 
						break;
					case "Callback Reassigns" : 
						lResults = 1; 
						 
						break;
					case "Callback Color Confirm" : 
						lResults = 2; 
						 
						break;
					case "Callback Exclusive" : 
						lResults = 3; 
						 
						break;
					case "Callback Hot Box" : 
						lResults = 4; 
						 
						break;
					case "Callback Expired Leases" : 
						lResults = 5; 
						 
						break;
					case "Callback Fractional Owners" : 
						lResults = 6; 
						 
						break;
					case "Callback Wanted" : 
						lResults = 7; 
						 
						break;
					case "Callback Available" : 
						lResults = 8; 
						 
						break;
					case "Callback Docs In Process" : 
						lResults = 9; 
						 
						break;
					case "Callback PEvents" : 
						lResults = 10; 
						 
						break;
					case "Callback ABI" : 
						lResults = 11; 
						 
						break;
					case "Callback AirBP" : 
						lResults = 12; 
						 
						break;
					case "Callback Yacht" : 
						lResults = 13; 
						 
						break;
					case "Callback Owner=Operator" : 
						lResults = 14; 
						 
						break;
					case "Callback Find Duplicate" : 
						lResults = 15; 
						 
						break;
					case "Callback AC No Base" : 
						lResults = 16; 
						 
						break;
					case "Callback AC wNo ChfPilot" : 
						lResults = 17; 
						 
						break;
					case "Callback Cust Submit Data" : 
						lResults = 18; 
						 
						break;
					case "Aircraft Search" : 
						lResults = 100; 
						 
						break;
					case "Company Search" : 
						lResults = 101; 
						 
						break;
					case "Yacht Search" : 
						lResults = 102; 
						 
						break;
				} // Cast strName

			} // If iPos1 > 0 Then

			return lResults;

		} // Return_Callback_Tab_Id

		private void Load_User_History_Callback_Grid(bool bRefreshRecordset = false)
		{

			string strName = "";

			try
			{

				if (bRefreshRecordset)
				{
					Read_User_History_Recordset();
				}

				ClearGridLeaveHeaders(grdCallback);

				if (rstRec1.State == ConnectionState.Open)
				{

					if (rstRec1.RecordCount > 0)
					{

						rstRec1.MoveFirst();
						if (!rstRec1.BOF && !rstRec1.EOF)
						{

							lRow1 = 0;

							do 
							{ // Loop Until rstRec1.EOF = True

								strMsg = ($"{Convert.ToString(rstRec1["evtl_message"])} ").Trim();

								if (strMsg.StartsWith("Callback", StringComparison.Ordinal) || strMsg.StartsWith("Aircraft Search", StringComparison.Ordinal) || strMsg.StartsWith("Company Search", StringComparison.Ordinal) || strMsg.StartsWith("Yacht Search", StringComparison.Ordinal))
								{

									lTabId = Return_Callback_Tab_Id(strMsg, ref strName);

									if (!Already_In_Grid(grdCallback, 0, lTabId.ToString(), 0, ""))
									{

										lBkgColor = 0x80000005; // White

										lRow1++;
										grdCallback.RowsCount = lRow1 + 1;
										grdCallback.CurrentRowIndex = lRow1;

										grdCallback.set_RowData(lRow1,Convert.ToInt32( rstRec1.GetField("evtl_id")));

										lCol1 = -1;

										lCol1++;
										grdCallback.CurrentColumnIndex = lCol1;
										grdCallback[grdCallback.CurrentRowIndex, grdCallback.CurrentColumnIndex].Value = lTabId.ToString();
										//UPGRADE_WARNING: (1068) lBkgColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
										grdCallback.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lBkgColor));
										grdCallback.CellAlignment = DataGridViewContentAlignment.MiddleRight;

										lCol1++;
										grdCallback.CurrentColumnIndex = lCol1;
										grdCallback[grdCallback.CurrentRowIndex, grdCallback.CurrentColumnIndex].Value = strName;
										//UPGRADE_WARNING: (1068) lBkgColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
										grdCallback.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lBkgColor));
										grdCallback.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

									} // If Already_In_Grid(grdCallback, 0, CStr(lTabId), 0, "") = False Then

								} // If left(strMsg, 8) = "Callback" Or left(strMsg, 15) = "Aircraft Search" Or left(strMsg, 14) = "Company Search" Or left(strMsg, 12) = "Yacht Search" Then

								rstRec1.MoveNext();

							}
							while(!(rstRec1.EOF || grdCallback.RowsCount >= iMaxRec));

							rstRec1.MoveFirst();

						}
						else
						{
							grdCallback.CurrentColumnIndex = 2;
							grdCallback[grdCallback.CurrentRowIndex, grdCallback.CurrentColumnIndex].Value = "No Records Found";
							//UPGRADE_WARNING: (1068) lBkgColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
							grdCallback.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lBkgColor));
							grdCallback.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					} // If rstRec1.RecordCount > 0 Then

				} // If rstRec1.State = adStateOpen Then
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Load_User_History_Callback_Grid_Error", excep.Message);
			}

		} // Load_User_History_Callback_Grid

		public void Refresh_User_History_Grids(string strGrid)
		{

			switch(strGrid)
			{
				case "Aircraft" : 
					Load_User_History_Aircraft_Grid(true); 
					break;
				case "Yacht" : 
					Load_User_History_Yacht_Grid(true); 
					break;
				case "Company" : 
					Load_User_History_Company_Grid(true); 
					break;
				case "Contact" : 
					Load_User_History_Contact_Grid(true); 
					break;
				case "Callback" : 
					Load_User_History_Callback_Grid(true); 
					break;
				case "All" : 
					Load_All_User_History_Grids(); 
					break;
			} // Case strGrid

		} // Refresh_User_History_Grids

		private void Load_All_User_History_Headers()
		{

			Load_User_History_Aircraft_Grid_Headers();
			Load_User_History_Yacht_Grid_Headers();
			Load_User_History_Company_Grid_Headers();
			Load_User_History_Contact_Grid_Headers();
			Load_User_History_Callback_Grid_Headers();

		} // Load_All_User_History_Headers

		private void Load_All_User_History_Grids()
		{

			if (modAdminCommon.LOCAL_ADO_DB != null)
			{

				if (modAdminCommon.LOCAL_ADO_DB.State == ConnectionState.Open)
				{

					Read_User_History_Recordset();

					if (!rstRec1.EOF && !rstRec1.BOF)
					{

						if (rstRec1.RecordCount != bTotalRecords)
						{
							Load_User_History_Aircraft_Grid();
							Load_User_History_Yacht_Grid();
							Load_User_History_Company_Grid();
							Load_User_History_Contact_Grid();
							Load_User_History_Callback_Grid();
							bTotalRecords = rstRec1.RecordCount;
						}

					} // If rstRec1.EOF = False And rstRec1.BOF = False Then

				} // If LOCAL_ADO_DB.State = adStateOpen Then

			} // If (LOCAL_ADO_DB Is Nothing) = False Then

		} // Load_All_User_History_Grids

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
            frm_Company frm_Company = null;

			Form Frm = null;

			foreach (Form FrmIterator in Application.OpenForms)
			{
				Frm = FrmIterator;


				switch(Frm.Name.Trim())
				{
					case "frm_ActionList" : 
						frm_ActionList.DefInstance.mnuActionListShowUserHistory.Text = "Show User History"; 
						 
						break;
					case "frm_Aircraft" : 
						frm_aircraft.DefInstance.mnuAircraftShowUserHistory.Text = "Show User History"; 
						 
						break;
					case "frm_AircraftList" : 
						frm_AircraftList.DefInstance.mnuAircraftListShowUserHistory.Text = "Show User History"; 
						 
						break;
					case "frm_Company" : 
						//UPGRADE_TODO: (1067) Member mnuCompanyShowUserHistory is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						frm_Company.mnuCompanyShowUserHistory.Text = "Show User History"; 
						 
						break;
					case "frm_Find_Company" : 
						frm_Find_Company.DefInstance.mnuFindCompanyShowUserHistory.Text = "Show User History"; 
						 
						break;
				} // Case Trim(Frm.Name)

				Frm = default(Form);
			} // Frm

			frm_Main_Menu.DefInstance.mnuShowUserHistory.Text = "Show User History";

			if (rstRec1 != null)
			{
				if (rstRec1.State == ConnectionState.Open)
				{
					rstRec1.Close();
				}
				rstRec1 = new ADORecordSetHelper();
			}

			modCommon.Show_Form(strLastForm);
			if (strLastForm != "")
			{
				if (strLastForm == "frm_Company")
				{
					//UPGRADE_TODO: (1067) Member SetSkipFormActivate is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					frm_Company.SetSkipFormActivate(true);
				}
				modCommon.Show_Form(strLastForm);
			}

		} // Form_Unload

		private void grdAircraft_Click(Object eventSender, EventArgs eventArgs)
		{


			int lRow = grdAircraft.MouseRow;
			int lCol = grdAircraft.MouseCol;

			if (lRow == 0)
			{

				if (grdAircraft.Enabled)
				{

					grdAircraft.CurrentColumnIndex = lCol;

					switch(lCol)
					{
						case 0 : case 1 : 
							//UPGRADE_WARNING: (2065) MSHierarchicalFlexGridLib.SortSettings property SortSettings.flexSortNumericAscending has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065 
							grdAircraft.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortNumericAscending)); 
							break;
						case 2 : case 3 : case 4 : case 5 : 
							grdAircraft.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortStringAscending)); 
							break;
					} // Case lCol

				} // If grdAircraft.Enabled = True Then

			} // If lRow = 0 Then

		} // grdAircraft_Click

		private void grdCompany_Click(Object eventSender, EventArgs eventArgs)
		{


			int lRow = grdCompany.MouseRow;
			int lCol = grdCompany.MouseCol;

			if (lRow == 0)
			{

				if (grdCompany.Enabled)
				{

					grdCompany.CurrentColumnIndex = lCol;

					switch(lCol)
					{
						case 0 : case 1 : 
							//UPGRADE_WARNING: (2065) MSHierarchicalFlexGridLib.SortSettings property SortSettings.flexSortNumericAscending has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065 
							grdCompany.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortNumericAscending)); 
							break;
						case 2 : case 3 : 
							grdCompany.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortStringAscending)); 
							break;
					} // Case lCol

				} // If grdCompany.Enabled = True Then

			} // If lRow = 0 Then

		} // grdCompany_Click

		private void grdYacht_Click(Object eventSender, EventArgs eventArgs)
		{


			int lRow = grdYacht.MouseRow;
			int lCol = grdYacht.MouseCol;

			if (lRow == 0)
			{

				if (grdYacht.Enabled)
				{

					grdYacht.CurrentColumnIndex = lCol;

					switch(lCol)
					{
						case 0 : case 1 : 
							//UPGRADE_WARNING: (2065) MSHierarchicalFlexGridLib.SortSettings property SortSettings.flexSortNumericAscending has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065 
							grdYacht.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortNumericAscending)); 
							break;
						case 2 : case 3 : case 4 : 
							grdYacht.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortStringAscending)); 
							break;
					} // Case lCol

				} // If grdYacht.Enabled = True Then

			} // If lRow = 0 Then

		} // grdYacht_Click

		private void grdContact_Click(Object eventSender, EventArgs eventArgs)
		{


			int lRow = grdContact.MouseRow;
			int lCol = grdContact.MouseCol;

			if (lRow == 0)
			{

				if (grdContact.Enabled)
				{

					grdContact.CurrentColumnIndex = lCol;

					switch(lCol)
					{
						case 0 : case 1 : case 2 : 
							//UPGRADE_WARNING: (2065) MSHierarchicalFlexGridLib.SortSettings property SortSettings.flexSortNumericAscending has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065 
							grdContact.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortNumericAscending)); 
							break;
						case 3 : case 4 : case 5 : 
							grdContact.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortStringAscending)); 
							break;
					} // Case lCol

				} // If grdContact.Enabled = True Then

			} // If lRow = 0 Then

		} // grdContact_Click

		private void grdCallback_Click(Object eventSender, EventArgs eventArgs)
		{


			int lRow = grdCallback.MouseRow;
			int lCol = grdCallback.MouseCol;

			if (lRow == 0)
			{

				if (grdCallback.Enabled)
				{

					grdCallback.CurrentColumnIndex = lCol;

					switch(lCol)
					{
						case 0 : 
							//UPGRADE_WARNING: (2065) MSHierarchicalFlexGridLib.SortSettings property SortSettings.flexSortNumericAscending has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065 
							grdCallback.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortNumericAscending)); 
							break;
						case 1 : 
							grdCallback.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortStringAscending)); 
							break;
					} // Case lCol

				} // If grdCallback.Enabled = True Then

			} // If lRow = 0 Then

		} // grdCallback_Click

		private void grdAircraft_DoubleClick(Object eventSender, EventArgs eventArgs)
		{

			string strACId = "";
			string strJournId = "";
			int lACId = 0;
			int lJournId = 0;

			int lRow2 = 0;

			if (grdAircraft.Enabled)
			{

				lRow2 = grdAircraft.CurrentRowIndex;

				grdAircraft.Enabled = false;

				if (grdAircraft.RowsCount > 1)
				{

					if (Convert.ToString(grdAircraft[1, 0].Value).Trim() != "")
					{

						lEvtlId = grdAircraft.get_RowData(lRow2);
						strACId = Convert.ToString(grdAircraft[lRow2, 0].Value).Trim();
						strJournId = Convert.ToString(grdAircraft[lRow2, 1].Value).Trim();

						if (Information.IsNumeric(strACId) && Information.IsNumeric(strJournId))
						{

							lACId = Convert.ToInt32(Double.Parse(strACId));
							lJournId = Convert.ToInt32(Double.Parse(strJournId));

							modGlobalVars.tStart_Form = modCommon.pubf_DecodeStartForm(modGlobalVars.gcMAINPAGE);

							modAdminCommon.gbl_Aircraft_ID = lACId;
							modAdminCommon.gbl_Aircraft_Journal_ID = lJournId;

							if (!modCommon.Is_Form_Already_Loaded("frm_Aircraft"))
							{
								//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
								//VB.Global.Load(frm_aircraft.DefInstance);
							}
							frm_aircraft.DefInstance.Form_Initialize();
							frm_aircraft.DefInstance.StartForm = modGlobalVars.tStart_Form;
							frm_aircraft.DefInstance.Reference_Aircraft_ID = lACId;
							frm_aircraft.DefInstance.Reference_Journal_ID = lJournId;
							frm_aircraft.DefInstance.Reference_Company_ID = 0;
							frm_aircraft.DefInstance.Show();
							//UPGRADE_WARNING: (2065) Form method frm_aircraft.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
							frm_aircraft.DefInstance.BringToFront();
							//UPGRADE_WARNING: (2065) Form event Form.Activated has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
							frm_aircraft.DefInstance.Form_Activated(frm_aircraft.DefInstance, new EventArgs());

							strLastForm = "frm_Aircraft";


						} // If IsNumeric(strACId) = True And IsNumeric(strJournId) = True Then

					} // If Trim(grdAircraft.TextMatrix(1, 0)) <> "" Then

				} // If grdAircraft.Rows > 1 Then

				grdAircraft.Enabled = true;

			} // If grdAircraft.Enabled = True Then

		} // grdAircraft_DblClick

		private void grdContact_MouseMove(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;

			string strCompany = "";

			int lRow1 = grdContact.MouseRow;
			int lCol1 = grdContact.MouseCol;

			ToolTipMain.SetToolTip(grdContact, Convert.ToString(grdContact[lRow1, 5].Value));

		}

		private void grdYacht_DoubleClick(Object eventSender, EventArgs eventArgs)
		{

			string strYTId = "";
			string strJournId = "";
			int lYTId = 0;
			int lJournId = 0;

			int lRow2 = 0;

			if (grdYacht.Enabled)
			{

				lRow2 = grdYacht.CurrentRowIndex;

				grdYacht.Enabled = false;

				if (grdYacht.RowsCount > 1)
				{

					if (Convert.ToString(grdYacht[1, 0].Value).Trim() != "")
					{

						lEvtlId = grdYacht.get_RowData(lRow2);
						strYTId = Convert.ToString(grdYacht[lRow2, 0].Value).Trim();
						strJournId = Convert.ToString(grdYacht[lRow2, 1].Value).Trim();

						if (Information.IsNumeric(strYTId) && Information.IsNumeric(strJournId))
						{

							lYTId = Convert.ToInt32(Double.Parse(strYTId));
							lJournId = Convert.ToInt32(Double.Parse(strJournId));

							modGlobalVars.tStart_Form = modCommon.pubf_DecodeStartForm(modGlobalVars.gcUSERHISTORY);
							modGlobalVars.tStart_Form = modCommon.pubf_DecodeStartForm(modGlobalVars.gcYACHT);

						}

					}

				} // If grdYacht.Rows > 1 Then

				grdYacht.Enabled = true;

			} // If grdYacht.Enabled = True Then

		} // grdYacht_DblClick

		private void grdCompany_DoubleClick(Object eventSender, EventArgs eventArgs)
		{
			frm_Company frm_Company = frm_Company.DefInstance;//gap-note check during stabilization if this is the right type

			string strCompId = "";
			string strJournId = "";
			int lCompId = 0;
			int lJournId = 0;

			int lRow2 = 0;

			if (grdCompany.Enabled)
			{

				lRow2 = grdCompany.CurrentRowIndex;

				grdCompany.Enabled = false;

				if (grdCompany.RowsCount > 1)
				{

					if (Convert.ToString(grdCompany[1, 0].Value).Trim() != "")
					{

						lEvtlId = grdCompany.get_RowData(lRow2);
						strCompId = Convert.ToString(grdCompany[lRow2, 0].Value).Trim();
						strJournId = Convert.ToString(grdCompany[lRow2, 1].Value).Trim();

						if (Information.IsNumeric(strCompId) && Information.IsNumeric(strJournId))
						{

							lCompId = Convert.ToInt32(Double.Parse(strCompId));
							lJournId = Convert.ToInt32(Double.Parse(strJournId));

							modGlobalVars.tStart_Form = modCommon.pubf_DecodeStartForm(modGlobalVars.gcCOMPANY);

							//Unload_Form "frm_Company"
							if (!modCommon.Is_Form_Already_Loaded("frm_Company"))
							{
								//UPGRADE_ISSUE: (2064) VB method VB.Global was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
								//UPGRADE_ISSUE: (1040) Load function is not supported. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-1040
								UpgradeStubs.VB.getGlobal().Load_Renamed(frm_Company);
							}

							//UPGRADE_TODO: (1067) Member SetForceReloadOnInit is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
							frm_Company.SetForceReloadOnInit(true);
							//UPGRADE_TODO: (1067) Member Form_Initialize is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
							frm_Company.Form_Initialize();
							//UPGRADE_TODO: (1067) Member StartForm is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
							frm_Company.StartForm = modGlobalVars.tStart_Form;
							//UPGRADE_TODO: (1067) Member Reference_CompanyID is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
							frm_Company.Reference_CompanyID = lCompId;
							//UPGRADE_TODO: (1067) Member Reference_CompanyJID is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
							frm_Company.Reference_CompanyJID = lJournId;
							//UPGRADE_TODO: (1067) Member Show is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
							frm_Company.Show();
							//UPGRADE_TODO: (1067) Member ZOrder is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
							frm_Company.ZOrder(0);
							//UPGRADE_TODO: (1067) Member Form_Activate is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
							frm_Company.Form_Activated(null,null);//gap-note Calling Form_Activated with no parameters

							strLastForm = "frm_Company";


						} // If IsNumeric(strCompId) = True And IsNumeric(strJournId) = True Then

					} // If Trim(grdCompany.TextMatrix(1, 0)) <> "" Then

				} // If grdCompany.Rows > 1 Then

				grdCompany.Enabled = true;

			} // If grdCompany.Enabled = True Then

		} // grdCompany_DblClick

		private void grdContact_DoubleClick(Object eventSender, EventArgs eventArgs)
		{

			string strContactId = "";
			int lContactId = 0;
			string strCompId = "";
			string strJournId = "";
			int lCompId = 0;
			int lJournId = 0;
			int lRow2 = 0;

			if (grdContact.Enabled)
			{

				lRow2 = grdContact.CurrentRowIndex;

				grdContact.Enabled = false;

				if (grdContact.RowsCount > 1)
				{

					if (Convert.ToString(grdContact[1, 0].Value).Trim() != "")
					{

						lEvtlId = grdContact.get_RowData(lRow2);
						strContactId = Convert.ToString(grdContact[lRow2, 0].Value).Trim();
						strCompId = Convert.ToString(grdContact[lRow2, 1].Value).Trim();
						strJournId = Convert.ToString(grdContact[lRow2, 2].Value).Trim();

						if (Information.IsNumeric(strContactId) && Information.IsNumeric(strCompId) && Information.IsNumeric(strJournId))
						{

							lContactId = Convert.ToInt32(Double.Parse(strContactId));
							lCompId = Convert.ToInt32(Double.Parse(strCompId));
							lJournId = Convert.ToInt32(Double.Parse(strJournId));

							modGlobalVars.tStart_Form = modCommon.pubf_DecodeStartForm(modGlobalVars.gcUSERHISTORY);

							if (!modCommon.Is_Form_Already_Loaded("frm_CompanyContact"))
							{
								//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
								//VB.Global.Load(frm_CompanyContact.DefInstance);
							}

							frm_CompanyContact.DefInstance.nContactID = lContactId;
							frm_CompanyContact.DefInstance.nCompanyID = lCompId;
							frm_CompanyContact.DefInstance.nJournID = lJournId;
							frm_CompanyContact.DefInstance.CompanyName_Renamed = modCommon.GetCompanyName(lCompId, lCompId);
							frm_CompanyContact.DefInstance.ServicesUsed = modCommon.GetCompanyServiceName(lCompId, lCompId, modGlobalVars.ServicesUsed_Array);

							modCommon.CenterFormOnHomebaseMainForm(frm_CompanyContact.DefInstance);

							//Timer1.Interval = 100
							frm_CompanyContact.DefInstance.ShowDialog();
							//UPGRADE_WARNING: (2065) Form method frm_CompanyContact.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
							frm_CompanyContact.DefInstance.BringToFront();

							strLastForm = "frm_CompanyContact";

						} // If IsNumeric(strContactId) = True And IsNumeric(strCompId) = True And IsNumeric(strJournId) = True Then

					} // If Trim(grdContact.TextMatrix(1, 0)) <> "" Then

				} // If grdContact.Rows > 1 Then

				grdContact.Enabled = true;

			} // If grdContact.Enabled = True Then

		} // grdContact_DblClick

		private void grdCallback_DoubleClick(Object eventSender, EventArgs eventArgs)
		{

			bool bFormExists = false;
			string strFormName = "";

			string strTabId = "";
			int lTabId = 0;
			int lRow2 = 0;

			if (grdCallback.Enabled)
			{

				lRow2 = grdCallback.CurrentRowIndex;

				grdCallback.Enabled = false;

				if (grdCallback.RowsCount > 1)
				{

					if (Convert.ToString(grdCallback[1, 0].Value).Trim() != "")
					{

						lEvtlId = grdCallback.get_RowData(lRow2);
						strTabId = Convert.ToString(grdCallback[lRow2, 0].Value).Trim();

						if (Information.IsNumeric(strTabId))
						{

							lTabId = Convert.ToInt32(Double.Parse(strTabId));

							strFormName = "frm_ActionList";
							switch(lTabId)
							{
								case 100 : 
									strFormName = "frm_AircraftList"; 
									break;
								case 101 : 
									strFormName = "frm_Find_Company"; 
									break;
								default:
									strFormName = "frm_ActionList"; 
									break;
							}

							bFormExists = modCommon.Is_Form_Already_Loaded(strFormName);

							if (!bFormExists)
							{


								switch(strFormName)
								{
									case "frm_ActionList" : 
										//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064 
										//VB.Global.Load(frm_ActionList.DefInstance); 
										 
										break;
									case "frm_AircraftList" : 
										//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064 
										//VB.Global.Load(frm_AircraftList.DefInstance); 
										 
										break;
									case "frm_Find_Company" : 
										//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064 
										//VB.Global.Load(frm_Find_Company.DefInstance); 
										 
										break;
									default:
										//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064 
										//VB.Global.Load(frm_ActionList.DefInstance); 
										 
										break;
								}

							} // If bFormExists = False Then


							switch(strFormName)
							{
								case "frm_ActionList" : 
									 
									modGlobalVars.tStart_Form = modCommon.pubf_DecodeStartForm(modGlobalVars.gcCALLBACKS); 
									frm_ActionList.DefInstance.Form_Initialize(); 
									frm_ActionList.DefInstance.SetTab(lTabId); 
									frm_ActionList.DefInstance.Show(); 
									//UPGRADE_WARNING: (2065) Form method frm_ActionList.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065 
									frm_ActionList.DefInstance.BringToFront(); 
									 
									break;
								case "frm_AircraftList" : 
									modGlobalVars.tStart_Form = modCommon.pubf_DecodeStartForm(modGlobalVars.gcAIRCRAFT); 
									frm_AircraftList.DefInstance.Show(); 
									//UPGRADE_WARNING: (2065) Form method frm_AircraftList.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065 
									frm_AircraftList.DefInstance.BringToFront(); 
									 
									break;
								case "frm_Find_Company" : 
									modGlobalVars.tStart_Form = modCommon.pubf_DecodeStartForm(modGlobalVars.gcCOMPANY); 
									modCommon.ShowAndLoadCompanyFindFormat(modGlobalVars.FIND_FORM_NEW); 
									 
									break;
								default:
									 
									modGlobalVars.tStart_Form = modCommon.pubf_DecodeStartForm(modGlobalVars.gcCALLBACKS); 
									frm_ActionList.DefInstance.StartForm = modGlobalVars.tStart_Form; 
									frm_ActionList.DefInstance.Form_Initialize(); 
									frm_ActionList.DefInstance.SetTab(lTabId); 
									frm_ActionList.DefInstance.Show(); 
									//UPGRADE_WARNING: (2065) Form method frm_ActionList.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065 
									frm_ActionList.DefInstance.BringToFront(); 
									 
									break;
							} // Case strFormName

							strLastForm = strFormName;

							modCommon.Unload_Form("frm_UserAccounts");

						} // If IsNumeric(strTabId) = True Then

					} // If Trim(grdCallback.TextMatrix(1, 0)) <> "" Then

				} // If grdCallback.Rows > 1 Then

				grdCallback.Enabled = true;

			} // If grdCallback.Enabled = True Then

		} // grdCallback_DblClick

		public void mnuEnterHoursWorked_Click(Object eventSender, EventArgs eventArgs)
		{

			//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			//VB.Global.Load(frm_UserHoursWorked.DefInstance);
			modCommon.CenterFormOnHomebaseMainForm(frm_UserHoursWorked.DefInstance);
			frm_UserHoursWorked.DefInstance.ShowDialog(); // vbModeless

			this.Activate();

		} // mnuEnterHoursWorked_Click

		public void mnuRefresh_Click(Object eventSender, EventArgs eventArgs)
		{

			bTotalRecords = 0;

			Load_All_User_History_Grids();

		} // mnuRefresh_Click

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
		private void Form_Load()
		{

			bViewIds = false;
			strLastForm = "";
			iMaxRec = 10;
			mnuSetMaxRecords.Text = $"Max Records ({iMaxRec.ToString()})";
			mnuViewIDs.Text = "View Id's";

			bTotalRecords = 0;
			lEvtlId = 0;

			modCommon.CenterFormOnHomebaseMainForm(this);

			Load_All_User_History_Headers();

			Load_All_User_History_Grids();

			Timer1.Enabled = true;

		} // Form_Load

		public void mnuSetMaxRecords_Click(Object eventSender, EventArgs eventArgs)
		{

			int lMaxRec = 0;

			string strMaxRec = InputBoxHelper.InputBox("Enter Max Records Per Grid (Limit 10-100)", "Max Records");

			if (strMaxRec != "")
			{

				if (Information.IsNumeric(strMaxRec))
				{

					lMaxRec = Convert.ToInt32(Double.Parse(strMaxRec));

					if (lMaxRec >= 10)
					{

						if (lMaxRec <= 100)
						{

							iMaxRec = lMaxRec;
							mnuSetMaxRecords.Text = $"Max Records ({iMaxRec.ToString()})";
							mnuRefresh_Click(mnuRefresh, new EventArgs());

						}
						else
						{
							MessageBox.Show($"Max Record Input Is Greater Than 100 = [{strMaxRec}]{Environment.NewLine}{Environment.NewLine}Range Limit 10-100", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						} // If lMaxRec <= 100 Then

					}
					else
					{
						MessageBox.Show($"Max Record Input Is Less Than 10 = [{strMaxRec}]{Environment.NewLine}{Environment.NewLine}Range Limit 10-100", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					} // If lMaxRec >= 10 Then

				}
				else
				{
					MessageBox.Show($"Max Record Input Is Invalid [{strMaxRec}]", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If IsNumeric(strMaxRec) = True Then

			} // If strMaxRec <> "" Then

		} // mnuSetMaxRecords_Click

		public void mnuViewIDs_Click(Object eventSender, EventArgs eventArgs)
		{

			if (!bViewIds)
			{
				bViewIds = true;
				mnuViewIDs.Text = "Hide Id's";
			}
			else
			{
				bViewIds = false;
				mnuViewIDs.Text = "View Id's";
			}

			Load_All_User_History_Headers();

			mnuRefresh_Click(mnuRefresh, new EventArgs());

		}

		public void TimerOff() => Timer1.Enabled = false;


		public void TimerOn() => Timer1.Enabled = true;


		private void Timer1_Tick(Object eventSender, EventArgs eventArgs)
		{

			Timer1.Enabled = false;
			Load_All_User_History_Grids();

		} // Timer1_Timer
	}
}