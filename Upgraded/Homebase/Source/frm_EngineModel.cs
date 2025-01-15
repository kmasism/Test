using Microsoft.VisualBasic;
using System;
using System.Data.Common;
using System.Drawing;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Helpers;

namespace JETNET_Homebase
{
	internal partial class frm_EngineModel
		: System.Windows.Forms.Form
	{

		public frm_EngineModel()
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


		private void frm_EngineModel_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}

		private string gstrEMId = "";
		private string gstrEMName = "";
		private string gstrEMPrefix = "";
		private string gstrEMCore = "";
		private string gstrEMSuffix1 = "";
		private string gstrEMSuffix2 = "";
		private string gstrEMTakeOffPower = "";
		private string gstrEMMaxConPower = "";
		private string gstrEMMfrCompId = "";
		private string gstrEMMfrAbbrev = "";
		private string gstrEMMfrName = "";
		private string gstrEMThrust = "";
		private string gstrEMTBOHours = "";
		private string gstrEMShaftHP = "";
		private string gstrEMHSI = "";
		private string gstrEMOnCond = "";

		public void Set_Engine_Model_Search_Name(string strSearchEngineModel) => txtSearchEngineModelName.Text = ($"{strSearchEngineModel} ").Trim();
		 // Set_Engine_Model_Search_Name

		public void Refresh_Engine_Model_Grid() => cmdEngineModelsRefresh_Click(cmdEngineModelsRefresh, new EventArgs());
		 // Refresh_Engine_Model_Grid

		public void Return_Engine_Model_Information(ref string strEMId, ref string strEMName, ref string strEMPrefix, ref string strEMCore, ref string strEMSuffix1, ref string strEMSuffix2, ref string strEMTakeOffPower, ref string strEMMaxConPower, ref string strEMMfrCompId, ref string strEMMfrAbbrev, ref string strEMMfrName, ref string strEMThrust, ref string strEMTBOHours, ref string strEMShaftHP, ref string strEMHSI, ref string strEMOnCond)
		{

			strEMId = gstrEMId;
			strEMName = gstrEMName;
			strEMPrefix = gstrEMPrefix;
			strEMCore = gstrEMCore;
			strEMSuffix1 = gstrEMSuffix1;
			strEMSuffix2 = gstrEMSuffix2;
			strEMTakeOffPower = gstrEMTakeOffPower;
			strEMMaxConPower = gstrEMMaxConPower;
			strEMMfrCompId = gstrEMMfrCompId;
			strEMMfrAbbrev = gstrEMMfrAbbrev;
			strEMMfrName = gstrEMMfrName;

			strEMThrust = gstrEMThrust;
			strEMTBOHours = gstrEMTBOHours;
			strEMShaftHP = gstrEMShaftHP;
			strEMHSI = gstrEMHSI;
			strEMOnCond = gstrEMOnCond;

		} // Return_Engine_Model_Information

		private void Clear_Engine_Model_Variables()
		{

			gstrEMId = "0";
			gstrEMName = "";
			gstrEMPrefix = "";
			gstrEMCore = "";
			gstrEMSuffix1 = "";
			gstrEMSuffix2 = "";
			gstrEMTakeOffPower = "0";
			gstrEMMaxConPower = "0";
			gstrEMMfrCompId = "0";
			gstrEMMfrAbbrev = "";
			gstrEMMfrName = "";

			gstrEMThrust = "0";
			gstrEMTBOHours = "0";
			gstrEMShaftHP = "0";
			gstrEMHSI = "0";
			gstrEMOnCond = "N";

		} // Clear_Engine_Model_Variables

		private void cmdCancel_Click(Object eventSender, EventArgs eventArgs)
		{

			Clear_Engine_Model_Variables();

			this.Hide();

		} // cmdCancel_Click

		private void cmdEngineModelsRefresh_Click(Object eventSender, EventArgs eventArgs)
		{

			if (cmdEngineModelsRefresh.Enabled)
			{

				cmdEngineModelsRefresh.Enabled = false;

				Load_Engine_Model_Grid();

				cmdEngineModelsRefresh.Enabled = true;

			} // If cmdEngineModelsRefresh.Enabled = True Then

		} // cmdEngineModelsRefresh_Click

		public void Load_Engine_Model_Grid_Headers()
		{


			grdEngineModels.Clear();
			grdEngineModels.RowsCount = 2;
			grdEngineModels.ColumnsCount = 17;

			int lRow1 = 0;
			grdEngineModels.CurrentRowIndex = lRow1;

			int lCol1 = 0;
			grdEngineModels.CurrentColumnIndex = lCol1;
			grdEngineModels.SetColumnWidth(lCol1, 40);
			grdEngineModels.CellBackColor = grdEngineModels.BackColorFixed;
			grdEngineModels.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			grdEngineModels[grdEngineModels.CurrentRowIndex, grdEngineModels.CurrentColumnIndex].Value = "EMId";

			lCol1++;
			grdEngineModels.CurrentColumnIndex = lCol1;
			grdEngineModels.SetColumnWidth(lCol1, 100);
			grdEngineModels.CellBackColor = grdEngineModels.BackColorFixed;
			grdEngineModels.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			grdEngineModels[grdEngineModels.CurrentRowIndex, grdEngineModels.CurrentColumnIndex].Value = "Engine Model";

			lCol1++;
			grdEngineModels.CurrentColumnIndex = lCol1;
			grdEngineModels.SetColumnWidth(lCol1, 50);
			grdEngineModels.CellBackColor = grdEngineModels.BackColorFixed;
			grdEngineModels.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			grdEngineModels[grdEngineModels.CurrentRowIndex, grdEngineModels.CurrentColumnIndex].Value = "Prefix";

			lCol1++;
			grdEngineModels.CurrentColumnIndex = lCol1;
			grdEngineModels.SetColumnWidth(lCol1, 83);
			grdEngineModels.CellBackColor = grdEngineModels.BackColorFixed;
			grdEngineModels.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			grdEngineModels[grdEngineModels.CurrentRowIndex, grdEngineModels.CurrentColumnIndex].Value = "Core";

			lCol1++;
			grdEngineModels.CurrentColumnIndex = lCol1;
			grdEngineModels.SetColumnWidth(lCol1, 47);
			grdEngineModels.CellBackColor = grdEngineModels.BackColorFixed;
			grdEngineModels.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			grdEngineModels[grdEngineModels.CurrentRowIndex, grdEngineModels.CurrentColumnIndex].Value = "Suffix1";

			lCol1++;
			grdEngineModels.CurrentColumnIndex = lCol1;
			grdEngineModels.SetColumnWidth(lCol1, 47);
			grdEngineModels.CellBackColor = grdEngineModels.BackColorFixed;
			grdEngineModels.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			grdEngineModels[grdEngineModels.CurrentRowIndex, grdEngineModels.CurrentColumnIndex].Value = "Suffix2";

			lCol1++;
			grdEngineModels.CurrentColumnIndex = lCol1;
			grdEngineModels.SetColumnWidth(lCol1, 40);
			grdEngineModels.CellBackColor = grdEngineModels.BackColorFixed;
			grdEngineModels.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			grdEngineModels[grdEngineModels.CurrentRowIndex, grdEngineModels.CurrentColumnIndex].Value = "Active";

			lCol1++;
			grdEngineModels.CurrentColumnIndex = lCol1;
			grdEngineModels.SetColumnWidth(lCol1, 83);
			grdEngineModels.CellBackColor = grdEngineModels.BackColorFixed;
			grdEngineModels.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			grdEngineModels[grdEngineModels.CurrentRowIndex, grdEngineModels.CurrentColumnIndex].Value = "Takeoff Power";

			lCol1++;
			grdEngineModels.CurrentColumnIndex = lCol1;
			grdEngineModels.SetColumnWidth(lCol1, 67);
			grdEngineModels.CellBackColor = grdEngineModels.BackColorFixed;
			grdEngineModels.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			grdEngineModels[grdEngineModels.CurrentRowIndex, grdEngineModels.CurrentColumnIndex].Value = "Max Power";

			lCol1++;
			grdEngineModels.CurrentColumnIndex = lCol1;
			grdEngineModels.SetColumnWidth(lCol1, 67);
			grdEngineModels.CellBackColor = grdEngineModels.BackColorFixed;
			grdEngineModels.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			grdEngineModels[grdEngineModels.CurrentRowIndex, grdEngineModels.CurrentColumnIndex].Value = "Mfr CompId";

			lCol1++;
			grdEngineModels.CurrentColumnIndex = lCol1;
			grdEngineModels.SetColumnWidth(lCol1, 60);
			grdEngineModels.CellBackColor = grdEngineModels.BackColorFixed;
			grdEngineModels.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			grdEngineModels[grdEngineModels.CurrentRowIndex, grdEngineModels.CurrentColumnIndex].Value = "Mfr Abbrev";

			lCol1++;
			grdEngineModels.CurrentColumnIndex = lCol1;
			grdEngineModels.SetColumnWidth(lCol1, 160);
			grdEngineModels.CellBackColor = grdEngineModels.BackColorFixed;
			grdEngineModels.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			grdEngineModels[grdEngineModels.CurrentRowIndex, grdEngineModels.CurrentColumnIndex].Value = "Mfr Name";

			lCol1++;
			grdEngineModels.CurrentColumnIndex = lCol1;
			grdEngineModels.SetColumnWidth(lCol1, 67);
			grdEngineModels.CellBackColor = grdEngineModels.BackColorFixed;
			grdEngineModels.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			grdEngineModels[grdEngineModels.CurrentRowIndex, grdEngineModels.CurrentColumnIndex].Value = "Thrust Lbs";

			lCol1++;
			grdEngineModels.CurrentColumnIndex = lCol1;
			grdEngineModels.SetColumnWidth(lCol1, 67);
			grdEngineModels.CellBackColor = grdEngineModels.BackColorFixed;
			grdEngineModels.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			grdEngineModels[grdEngineModels.CurrentRowIndex, grdEngineModels.CurrentColumnIndex].Value = "TBO Hours";

			lCol1++;
			grdEngineModels.CurrentColumnIndex = lCol1;
			grdEngineModels.SetColumnWidth(lCol1, 67);
			grdEngineModels.CellBackColor = grdEngineModels.BackColorFixed;
			grdEngineModels.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			grdEngineModels[grdEngineModels.CurrentRowIndex, grdEngineModels.CurrentColumnIndex].Value = "Shaft HP";

			lCol1++;
			grdEngineModels.CurrentColumnIndex = lCol1;
			grdEngineModels.SetColumnWidth(lCol1, 67);
			grdEngineModels.CellBackColor = grdEngineModels.BackColorFixed;
			grdEngineModels.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			grdEngineModels[grdEngineModels.CurrentRowIndex, grdEngineModels.CurrentColumnIndex].Value = "HSI";

			lCol1++;
			grdEngineModels.CurrentColumnIndex = lCol1;
			grdEngineModels.SetColumnWidth(lCol1, 47);
			grdEngineModels.CellBackColor = grdEngineModels.BackColorFixed;
			grdEngineModels.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			grdEngineModels[grdEngineModels.CurrentRowIndex, grdEngineModels.CurrentColumnIndex].Value = "On TBO";

			grdEngineModels.CurrentRowIndex = 1;
			grdEngineModels.FixedRows = 1;
			grdEngineModels.FixedColumns = 0;

		} // Load_Engine_Model_Grid_Headers

		public void Load_Engine_Model_Grid()
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			int lCnt1 = 0;
			int lTot1 = 0;

			string strSearchEngineModelName = "";

			int lMainColor = 0;
			int lInActiveColor = 0;
			object lTempColor = null;

			int lRow1 = 0;
			int lCol1 = 0;

			try
			{

				lblLoading.Text = "Loading ##,### of ##,### Records";
				lblEngineModelsStop.Visible = true;
				cmdSelect.Enabled = false;

				lMainColor = 0xFFFFFF;
				lInActiveColor = 0xC0C0FF;

				Clear_Engine_Model_Variables();

				Load_Engine_Model_Grid_Headers();

				strSearchEngineModelName = txtSearchEngineModelName.Text.Trim();

				strQuery1 = "SELECT EM1.* FROM Engine_Models AS EM1 WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (EM1.em_engine_name IS NOT NULL) ";
				strQuery1 = $"{strQuery1}AND (EM1.em_engine_name <> '') AND (EM1.em_active_flag = 'Y') ";

				if (strSearchEngineModelName != "")
				{
					strQuery1 = $"{strQuery1}AND (EM1.em_engine_name LIKE '{strSearchEngineModelName}%') ";
				}

				strQuery1 = $"{strQuery1}ORDER BY EM1.em_engine_name ";

				rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					rstRec1.ActiveConnection = null;

					lblEngineModelsStop.Visible = true;
					lblEngineModelsStop.Enabled = true;

					lTot1 = rstRec1.RecordCount;
					lCnt1 = 0;

					lRow1 = 0;

					grdEngineModels.Enabled = true;
					grdEngineModels.Redraw = false;

					do 
					{ // Loop Until rstRec1.EOF = True Or lblEngineModelsStop.Enabled = False

						lCnt1++;
						lblLoading.Text = $"Loading {StringsHelper.Format(lCnt1, "##,##0")} of {StringsHelper.Format(lTot1, "##,##0")} Records";
						Application.DoEvents();

						lTempColor = lMainColor;
						if (($"{Convert.ToString(rstRec1["em_active_flag"])} ").Trim() != "Y")
						{
							lTempColor = lInActiveColor;
						}

						lRow1++;
						grdEngineModels.RowsCount = lRow1 + 1;
						grdEngineModels.CurrentRowIndex = lRow1;

						lCol1 = 0;
						grdEngineModels.CurrentColumnIndex = lCol1;
						grdEngineModels.CellAlignment = DataGridViewContentAlignment.MiddleRight;
						//UPGRADE_WARNING: (1068) lTempColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						grdEngineModels.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lTempColor));
						grdEngineModels[grdEngineModels.CurrentRowIndex, grdEngineModels.CurrentColumnIndex].Value = Convert.ToString(rstRec1["em_id"]);

						lCol1++;
						grdEngineModels.CurrentColumnIndex = lCol1;
						grdEngineModels.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						//UPGRADE_WARNING: (1068) lTempColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						grdEngineModels.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lTempColor));
						grdEngineModels[grdEngineModels.CurrentRowIndex, grdEngineModels.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["em_engine_name"])} ").Trim();

						lCol1++;
						grdEngineModels.CurrentColumnIndex = lCol1;
						grdEngineModels.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						//UPGRADE_WARNING: (1068) lTempColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						grdEngineModels.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lTempColor));
						grdEngineModels[grdEngineModels.CurrentRowIndex, grdEngineModels.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["em_engine_prefix"])} ").Trim();

						lCol1++;
						grdEngineModels.CurrentColumnIndex = lCol1;
						grdEngineModels.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						//UPGRADE_WARNING: (1068) lTempColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						grdEngineModels.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lTempColor));
						grdEngineModels[grdEngineModels.CurrentRowIndex, grdEngineModels.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["em_engine_core"])} ").Trim();

						lCol1++;
						grdEngineModels.CurrentColumnIndex = lCol1;
						grdEngineModels.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						//UPGRADE_WARNING: (1068) lTempColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						grdEngineModels.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lTempColor));
						grdEngineModels[grdEngineModels.CurrentRowIndex, grdEngineModels.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["em_engine_suffix1"])} ").Trim();

						lCol1++;
						grdEngineModels.CurrentColumnIndex = lCol1;
						grdEngineModels.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						//UPGRADE_WARNING: (1068) lTempColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						grdEngineModels.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lTempColor));
						grdEngineModels[grdEngineModels.CurrentRowIndex, grdEngineModels.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["em_engine_suffix2"])} ").Trim();

						lCol1++;
						grdEngineModels.CurrentColumnIndex = lCol1;
						grdEngineModels.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
						//UPGRADE_WARNING: (1068) lTempColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						grdEngineModels.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lTempColor));
						grdEngineModels[grdEngineModels.CurrentRowIndex, grdEngineModels.CurrentColumnIndex].Value = modCommon.ReturnYesNo(($"{Convert.ToString(rstRec1["em_active_flag"])} ").Trim());

						lCol1++;
						grdEngineModels.CurrentColumnIndex = lCol1;
						grdEngineModels.CellAlignment = DataGridViewContentAlignment.MiddleRight;
						//UPGRADE_WARNING: (1068) lTempColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						grdEngineModels.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lTempColor));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["em_takeoff_power"]))
						{
							grdEngineModels[grdEngineModels.CurrentRowIndex, grdEngineModels.CurrentColumnIndex].Value = Convert.ToString(rstRec1["em_takeoff_power"]);
						}

						lCol1++;
						grdEngineModels.CurrentColumnIndex = lCol1;
						grdEngineModels.CellAlignment = DataGridViewContentAlignment.MiddleRight;
						//UPGRADE_WARNING: (1068) lTempColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						grdEngineModels.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lTempColor));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["em_max_continuous_power"]))
						{
							grdEngineModels[grdEngineModels.CurrentRowIndex, grdEngineModels.CurrentColumnIndex].Value = Convert.ToString(rstRec1["em_max_continuous_power"]);
						}

						lCol1++;
						grdEngineModels.CurrentColumnIndex = lCol1;
						grdEngineModels.CellAlignment = DataGridViewContentAlignment.MiddleRight;
						//UPGRADE_WARNING: (1068) lTempColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						grdEngineModels.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lTempColor));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["em_mfr_comp_id"]))
						{
							grdEngineModels[grdEngineModels.CurrentRowIndex, grdEngineModels.CurrentColumnIndex].Value = Convert.ToString(rstRec1["em_mfr_comp_id"]);
						}

						lCol1++;
						grdEngineModels.CurrentColumnIndex = lCol1;
						grdEngineModels.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						//UPGRADE_WARNING: (1068) lTempColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						grdEngineModels.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lTempColor));
						grdEngineModels[grdEngineModels.CurrentRowIndex, grdEngineModels.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["em_mfr_name_abbrev"])} ").Trim();

						lCol1++;
						grdEngineModels.CurrentColumnIndex = lCol1;
						grdEngineModels.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						//UPGRADE_WARNING: (1068) lTempColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						grdEngineModels.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lTempColor));
						grdEngineModels[grdEngineModels.CurrentRowIndex, grdEngineModels.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["em_mfr_name"])} ").Trim();

						lCol1++;
						grdEngineModels.CurrentColumnIndex = lCol1;
						grdEngineModels.CellAlignment = DataGridViewContentAlignment.MiddleRight;
						//UPGRADE_WARNING: (1068) lTempColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						grdEngineModels.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lTempColor));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["em_engine_thrust_lbs"]))
						{
							grdEngineModels[grdEngineModels.CurrentRowIndex, grdEngineModels.CurrentColumnIndex].Value = Convert.ToString(rstRec1["em_engine_thrust_lbs"]);
						}

						lCol1++;
						grdEngineModels.CurrentColumnIndex = lCol1;
						grdEngineModels.CellAlignment = DataGridViewContentAlignment.MiddleRight;
						//UPGRADE_WARNING: (1068) lTempColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						grdEngineModels.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lTempColor));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["em_engine_com_tbo_hrs"]))
						{
							grdEngineModels[grdEngineModels.CurrentRowIndex, grdEngineModels.CurrentColumnIndex].Value = Convert.ToString(rstRec1["em_engine_com_tbo_hrs"]);
						}

						lCol1++;
						grdEngineModels.CurrentColumnIndex = lCol1;
						grdEngineModels.CellAlignment = DataGridViewContentAlignment.MiddleRight;
						//UPGRADE_WARNING: (1068) lTempColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						grdEngineModels.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lTempColor));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["em_engine_shaft"]))
						{
							grdEngineModels[grdEngineModels.CurrentRowIndex, grdEngineModels.CurrentColumnIndex].Value = Convert.ToString(rstRec1["em_engine_shaft"]);
						}

						lCol1++;
						grdEngineModels.CurrentColumnIndex = lCol1;
						grdEngineModels.CellAlignment = DataGridViewContentAlignment.MiddleRight;
						//UPGRADE_WARNING: (1068) lTempColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						grdEngineModels.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lTempColor));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["em_engine_hsi"]))
						{
							grdEngineModels[grdEngineModels.CurrentRowIndex, grdEngineModels.CurrentColumnIndex].Value = Convert.ToString(rstRec1["em_engine_hsi"]);
						}

						lCol1++;
						grdEngineModels.CurrentColumnIndex = lCol1;
						grdEngineModels.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
						//UPGRADE_WARNING: (1068) lTempColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						grdEngineModels.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lTempColor));
						grdEngineModels[grdEngineModels.CurrentRowIndex, grdEngineModels.CurrentColumnIndex].Value = modCommon.ReturnYesNo(($"{Convert.ToString(rstRec1["em_on_condition_flag"])} ").Trim());

						rstRec1.MoveNext();

						if (lCnt1 == 15)
						{
							grdEngineModels.Redraw = true;
							grdEngineModels.Refresh();
							Application.DoEvents();
							grdEngineModels.Redraw = false;
						}

					}
					while(!(rstRec1.EOF || !lblEngineModelsStop.Enabled));

					grdEngineModels.Redraw = true;

				}
				else
				{
					grdEngineModels[1, 1].Value = "No Records Found";
					grdEngineModels.Enabled = false;
				} // If rstRec1.BOF = False And rstRec1.EOF = False Then

				rstRec1.Close();

				lblEngineModelsStop.Visible = false;

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Load_Engine_Model_Grid_Error", excep.Message);
			}

		} // Load_Engine_Model_Grid

		private void cmdSelect_Click(Object eventSender, EventArgs eventArgs)
		{

			if (gstrEMId != "0")
			{
				this.Hide();
			}
			else
			{
				MessageBox.Show("You Must Select An Engine Model Before Clicking Select", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		} // cmdSelect_Click

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
		private void Form_Load() => modCommon.CenterFormOnHomebaseMainForm(this);
		 // Form_Load

		private void grdEngineModels_Click(Object eventSender, EventArgs eventArgs)
		{


			int lRow1 = grdEngineModels.CurrentRowIndex;

			gstrEMId = Convert.ToString(grdEngineModels[lRow1, 0].Value);
			gstrEMName = Convert.ToString(grdEngineModels[lRow1, 1].Value);
			gstrEMPrefix = Convert.ToString(grdEngineModels[lRow1, 2].Value);
			gstrEMCore = Convert.ToString(grdEngineModels[lRow1, 3].Value);
			gstrEMSuffix1 = Convert.ToString(grdEngineModels[lRow1, 4].Value);
			gstrEMSuffix2 = Convert.ToString(grdEngineModels[lRow1, 5].Value);
			string strActive = Convert.ToString(grdEngineModels[lRow1, 6].Value);
			gstrEMTakeOffPower = Convert.ToString(grdEngineModels[lRow1, 7].Value);
			gstrEMMaxConPower = Convert.ToString(grdEngineModels[lRow1, 8].Value);
			gstrEMMfrCompId = Convert.ToString(grdEngineModels[lRow1, 9].Value);
			gstrEMMfrAbbrev = Convert.ToString(grdEngineModels[lRow1, 10].Value);
			gstrEMMfrName = Convert.ToString(grdEngineModels[lRow1, 11].Value);

			gstrEMThrust = Convert.ToString(grdEngineModels[lRow1, 12].Value);
			gstrEMTBOHours = Convert.ToString(grdEngineModels[lRow1, 13].Value);
			gstrEMShaftHP = Convert.ToString(grdEngineModels[lRow1, 14].Value);
			gstrEMHSI = Convert.ToString(grdEngineModels[lRow1, 15].Value);
			gstrEMOnCond = Convert.ToString(grdEngineModels[lRow1, 16].Value);

			modCommon.Highlight_Grid_Row(grdEngineModels);

			cmdSelect.Enabled = true;

		} // grdEngineModels_Click

		private void grdEngineModels_DoubleClick(Object eventSender, EventArgs eventArgs)
		{
			grdEngineModels_Click(grdEngineModels, new EventArgs());
			cmdSelect_Click(cmdSelect, new EventArgs());
		} // grdEngineModels_DblClick

		private void txtSearchEngineModelName_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{

				if (KeyAscii == 13)
				{
					cmdEngineModelsRefresh_Click(cmdEngineModelsRefresh, new EventArgs());
				}
			}
			finally
			{
				if (KeyAscii == 0)
				{
					eventArgs.Handled = true;
				}
				eventArgs.KeyChar = Convert.ToChar(KeyAscii);
			}

		} // txtSearchEngineModelName_KeyPress
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}