using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Gui.Controls;
using UpgradeHelpers.Gui.Utils;
using UpgradeHelpers.Helpers;
using UpgradeStubs;

namespace JETNET_Homebase
{
	internal partial class frm_Aircraft_Model
		: System.Windows.Forms.Form
	{

		//******************************************************************************************

		//******************************************************************************************


		private ADORecordSetHelper snp_Model = null;

		//===================
		// Private Variables
		//===================
		bool ModelStopped = false;
		bool KeyFeatureWasActive = false;
		bool NeedTransaction = false;
		string EngineStat = "";
		int TotalModel = 0;
		int TotalEngine = 0;
		string RecordStat = "";
		string s_PrevEngineName = "";
		string where_am_I = ""; //7-16-09 Tom (For Terry)

		private ADORecordSetHelper _snp_AircraftType = null;
		public frm_Aircraft_Model()
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
			ReLoadForm(false);
		}


		ADORecordSetHelper snp_AircraftType
		{
			get
			{
				if (_snp_AircraftType is null)
				{
					_snp_AircraftType = new ADORecordSetHelper();
				}
				return _snp_AircraftType;
			}
			set => _snp_AircraftType = value;
		}
		 //8/11/05 aey
		private ADORecordSetHelper _snp_AircraftClass = null;
		ADORecordSetHelper snp_AircraftClass
		{
			get
			{
				if (_snp_AircraftClass is null)
				{
					_snp_AircraftClass = new ADORecordSetHelper();
				}
				return _snp_AircraftClass;
			}
			set => _snp_AircraftClass = value;
		}
		 //8/11/05 aey
		private ADORecordSetHelper _snp_MasterFeature = null;
		ADORecordSetHelper snp_MasterFeature
		{
			get
			{
				if (_snp_MasterFeature is null)
				{
					_snp_MasterFeature = new ADORecordSetHelper();
				}
				return _snp_MasterFeature;
			}
			set => _snp_MasterFeature = value;
		}
		 //8/11/05 aey
		private ADORecordSetHelper _snp_ModelAircraft = null;
		ADORecordSetHelper snp_ModelAircraft
		{
			get
			{
				if (_snp_ModelAircraft is null)
				{
					_snp_ModelAircraft = new ADORecordSetHelper();
				}
				return _snp_ModelAircraft;
			}
			set => _snp_ModelAircraft = value;
		}
		 //8/11/05 aey
		private ADORecordSetHelper _adoModelmap = null;
		ADORecordSetHelper adoModelmap
		{
			get
			{
				if (_adoModelmap is null)
				{
					_adoModelmap = new ADORecordSetHelper();
				}
				return _adoModelmap;
			}
			set => _adoModelmap = value;
		}

		string RememberPrefix = "";
		string RememberSuffix = "";
		bool RememberHyphenFlag = false;
		private ADORecordSetHelper _snp_AirframeType = null;
		ADORecordSetHelper snp_AirframeType
		{
			get
			{
				if (_snp_AirframeType is null)
				{
					_snp_AirframeType = new ADORecordSetHelper();
				}
				return _snp_AirframeType;
			}
			set => _snp_AirframeType = value;
		}

		private bool ResearchRefresh = false;
		private string hold_amod_customer_flag = "";
		private bool bIsFormLoad = false;

		private ADORecordSetHelper _snp_AircraftEngine = null;
		ADORecordSetHelper snp_AircraftEngine
		{
			get
			{
				if (_snp_AircraftEngine is null)
				{
					_snp_AircraftEngine = new ADORecordSetHelper();
				}
				return _snp_AircraftEngine;
			}
			set => _snp_AircraftEngine = value;
		}
		 //8/11/05 aey
		private ADORecordSetHelper _snp_AC_Engine_Check = null;
		ADORecordSetHelper snp_AC_Engine_Check
		{
			get
			{
				if (_snp_AC_Engine_Check is null)
				{
					_snp_AC_Engine_Check = new ADORecordSetHelper();
				}
				return _snp_AC_Engine_Check;
			}
			set => _snp_AC_Engine_Check = value;
		}
		 //7/1/10 Tom

		bool IgnoreClick = false;

		private bool bFilledEngineList = false;
		private frm_AddAircraft newfrm_AddAircraft = null;
		private bool bControlProductCodeMsg = false;
		private bool bUpdate = false;

		private string Mapped_homebase_ac_list = "";

		public void check_for_model_changes(ref string changes_subject, ref string changes_made, string strAModId)
		{

			changes_made = "";



			if (StringsHelper.Replace(Convert.ToString(txt_amod_start_price.Tag), ",", "", 1, -1, CompareMethod.Binary) != StringsHelper.Replace(txt_amod_start_price.Text, ",", "", 1, -1, CompareMethod.Binary))
			{
				changes_subject = "Updated Start Price";
				changes_made = $"Updated Start Price from {Convert.ToString(txt_amod_start_price.Tag)} to {txt_amod_start_price.Text}";
				Insert_Model_Research_Note($"Aircraft Model Update: {changes_subject}", changes_made, Convert.ToInt32(Double.Parse(txt_amod_id.Text)));
				// Record_Event "Update Aircraft Model", "AModId: " & strAModId & "  Make: " & txt_amod_make_name.Text & " Model: " & txt_amod_model_name.Text & " : " & changes_made
			}

			if (StringsHelper.Replace(Convert.ToString(txt_amod_end_price.Tag), ",", "", 1, -1, CompareMethod.Binary) != StringsHelper.Replace(txt_amod_end_price.Text, ",", "", 1, -1, CompareMethod.Binary))
			{
				changes_subject = "Updated End Price";
				changes_made = $"Updated End Price from {Convert.ToString(txt_amod_end_price.Tag)} to {txt_amod_end_price.Text}";
				Insert_Model_Research_Note($"Aircraft Model Update: {changes_subject}", changes_made, Convert.ToInt32(Double.Parse(txt_amod_id.Text)));
				//  Record_Event "Update Aircraft Model", "AModId: " & strAModId & "  Make: " & txt_amod_make_name.Text & " Model: " & txt_amod_model_name.Text & " : " & changes_made
			}


			if (StringsHelper.Replace(Convert.ToString(txt_amod_basic_op_weight.Tag), ",", "", 1, -1, CompareMethod.Binary) != StringsHelper.Replace(txt_amod_basic_op_weight.Text, ",", "", 1, -1, CompareMethod.Binary))
			{
				changes_subject = "Updated Op Weight";
				changes_made = $"Updated Op Weight from {Convert.ToString(txt_amod_basic_op_weight.Tag)} to {txt_amod_basic_op_weight.Text}";
				Insert_Model_Research_Note($"Aircraft Model Update: {changes_subject}", changes_made, Convert.ToInt32(Double.Parse(txt_amod_id.Text)));
				//  Record_Event "Update Aircraft Model", "AModId: " & strAModId & "  Make: " & txt_amod_make_name.Text & " Model: " & txt_amod_model_name.Text & " : " & changes_made
			}

			if (StringsHelper.Replace(Convert.ToString(txt_amod_weight_eow.Tag), ",", "", 1, -1, CompareMethod.Binary) != StringsHelper.Replace(txt_amod_weight_eow.Text, ",", "", 1, -1, CompareMethod.Binary))
			{
				changes_subject = "Updated EOW Weight";
				changes_made = $"Updated EOW Weight from {Convert.ToString(txt_amod_weight_eow.Tag)} to {txt_amod_weight_eow.Text}";
				Insert_Model_Research_Note($"Aircraft Model Update: {changes_subject}", changes_made, Convert.ToInt32(Double.Parse(txt_amod_id.Text)));
				// Record_Event "Update Aircraft Model", "AModId: " & strAModId & "  Make: " & txt_amod_make_name.Text & " Model: " & txt_amod_model_name.Text & " : " & changes_made
			}


			if (StringsHelper.Replace(Convert.ToString(txt_amod_misc_train_cost.Tag), ",", "", 1, -1, CompareMethod.Binary) != StringsHelper.Replace(txt_amod_misc_train_cost.Text, ",", "", 1, -1, CompareMethod.Binary))
			{
				changes_subject = "Updated Training Cost";
				changes_made = $"Updated Training Cost from {Convert.ToString(txt_amod_misc_train_cost.Tag)} to {txt_amod_misc_train_cost.Text}";
				Insert_Model_Research_Note($"Aircraft Model Update: {changes_subject}", changes_made, Convert.ToInt32(Double.Parse(txt_amod_id.Text)));
				// Record_Event "Update Aircraft Model", "AModId: " & strAModId & "  Make: " & txt_amod_make_name.Text & " Model: " & txt_amod_model_name.Text & " : " & changes_made
			}

			if (StringsHelper.Replace(Convert.ToString(txt_amod_misc_modern_cost.Tag), ",", "", 1, -1, CompareMethod.Binary) != StringsHelper.Replace(txt_amod_misc_modern_cost.Text, ",", "", 1, -1, CompareMethod.Binary))
			{
				changes_subject = "Updated Modern Cost";
				changes_made = $"Updated Modern Cost from {Convert.ToString(txt_amod_misc_modern_cost.Tag)} to {txt_amod_misc_modern_cost.Text}";
				Insert_Model_Research_Note($"Aircraft Model Update: {changes_subject}", changes_made, Convert.ToInt32(Double.Parse(txt_amod_id.Text)));
				// Record_Event "Update Aircraft Model", "AModId: " & strAModId & "  Make: " & txt_amod_make_name.Text & " Model: " & txt_amod_model_name.Text & " : " & changes_made
			}


			if (StringsHelper.Replace(Convert.ToString(txt_amod_capt_salary_cost.Tag), ",", "", 1, -1, CompareMethod.Binary) != StringsHelper.Replace(txt_amod_capt_salary_cost.Text, ",", "", 1, -1, CompareMethod.Binary))
			{
				changes_subject = "Updated Captain Salary";
				changes_made = $"Updated Captain Salary from {Convert.ToString(txt_amod_capt_salary_cost.Tag)} to {txt_amod_capt_salary_cost.Text}";
				Insert_Model_Research_Note($"Aircraft Model Update: {changes_subject}", changes_made, Convert.ToInt32(Double.Parse(txt_amod_id.Text)));
				// Record_Event "Update Aircraft Model", "AModId: " & strAModId & "  Make: " & txt_amod_make_name.Text & " Model: " & txt_amod_model_name.Text & " : " & changes_made
			}


			if (StringsHelper.Replace(Convert.ToString(txt_amod_cpilot_salary_cost.Tag), ",", "", 1, -1, CompareMethod.Binary) != StringsHelper.Replace(txt_amod_cpilot_salary_cost.Text, ",", "", 1, -1, CompareMethod.Binary))
			{
				changes_subject = "Updated Co-Pilot Salary";
				changes_made = $"Updated Co-Pilot Salary from {Convert.ToString(txt_amod_cpilot_salary_cost.Tag)} to {txt_amod_cpilot_salary_cost.Text}";
				Insert_Model_Research_Note($"Aircraft Model Update: {changes_subject}", changes_made, Convert.ToInt32(Double.Parse(txt_amod_id.Text)));
				// Record_Event "Update Aircraft Model", "AModId: " & strAModId & "  Make: " & txt_amod_make_name.Text & " Model: " & txt_amod_model_name.Text & " : " & changes_made
			}




			if (changes_made.Trim() == "")
			{
				Insert_Model_Research_Note("Aircraft Model Update: ", "", Convert.ToInt32(Double.Parse(txt_amod_id.Text)));
			}


		}

		public void check_if_limiting_initials()
		{

			string initials_to_ignore = "'EAD','EDPB'";


			if (initials_to_ignore.IndexOf($"'{modAdminCommon.gbl_User_ID.ToUpper()}'") >= 0)
			{


				cbo_amod_Airframe_Type_Code.Enabled = false;
				cbo_amod_Airframe_Type_Code.Enabled = false;
				txt_amod_start_year.Enabled = false;
				txt_amod_end_year.Enabled = false;
				txt_amod_ser_no_prefix.Enabled = false;
				txt_amod_ser_no_start.Enabled = false;
				txt_amod_ser_no_end.Enabled = false;
				txt_amod_ser_no_suffix.Enabled = false;
				cbo_amod_type_code.Enabled = false;
				cbo_amod_class.Enabled = false;
				txt_amod_manufacturer[0].Enabled = false;
				txt_amod_manufacturer[1].Enabled = false;
				txt_amod_manufacturer[2].Enabled = false;
				txt_amod_make_name.Enabled = false;
				txt_amod_model_name.Enabled = false;
				txt_amod_make_abbrev.Enabled = false;
				chk_amod_hyphen_flag.Enabled = false;
				cboJIQSize.Enabled = false;
				cmbBodyConfig.Enabled = false;


				tab_Aircraft_Model.Visible = true;
				int tempForEndVar = SSTabHelper.GetTabCount(tab_Aircraft_Model) - 1;
				for (int iCnt1 = 0; iCnt1 <= tempForEndVar; iCnt1++)
				{
					if (iCnt1 == 1 || iCnt1 == 7 || iCnt1 == 8 || iCnt1 == 9 || iCnt1 == 10 || iCnt1 == 13)
					{
						SSTabHelper.SetTabVisible(tab_Aircraft_Model, iCnt1, false);
					}
					else
					{
						SSTabHelper.SetTabVisible(tab_Aircraft_Model, iCnt1, true);
					}
				}


			}



		}

		private void Fill_Aircraft_Usage_List()
		{
			ADORecordSetHelper ado_Usage = new ADORecordSetHelper();

			cmbUsage.Items.Clear();
			cmbUsage.AddItem("None Selected");

			string Query = "Select * from Aircraft_Useage WITH(NOLOCK) order by acuse_name ";
			ado_Usage.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

			if (!(ado_Usage.BOF && ado_Usage.EOF))
			{

				while (!ado_Usage.EOF)
				{
					cmbUsage.AddItem($"{Convert.ToString(ado_Usage["acuse_code"])} {Convert.ToString(ado_Usage["acuse_name"])}");
					ado_Usage.MoveNext();
				}

				cmbUsage.SelectedIndex = 0;
				ado_Usage.Close();
			}


		}

		private void Fill_Body_Config()
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();

			cmbBodyConfig.Items.Clear();
			cmbBodyConfig.AddItem("Unknown");

			string strQuery1 = "SELECT * FROM Aircraft_Model_Body_Config WITH (NOLOCK) WHERE (ambc_type <> 'U') ORDER BY ambc_name ";
			rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

			if (!rstRec1.BOF && !rstRec1.EOF)
			{

				do 
				{

					cmbBodyConfig.AddItem(($"{Convert.ToString(rstRec1["ambc_name"])} ").Trim());
					rstRec1.MoveNext();

				}
				while(!rstRec1.EOF);

				cmbBodyConfig.SelectedIndex = 0;

			} // If (rstRec1.BOF = False And rstRec1.EOF = False) Then

			rstRec1.Close();

		} // Fill_Body_Config

		private void Fill_Airframe_Type_List()
		{

			string Query = "";

			try
			{

				cbo_amod_Airframe_Type_Code.Items.Clear();
				Query = "SELECT * FROM Airframe_Type WITH(NOLOCK) ORDER BY aftype_code ";

				snp_AirframeType.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_AirframeType.BOF && snp_AirframeType.EOF))
				{


					while(!snp_AirframeType.EOF)
					{
						cbo_amod_Airframe_Type_Code.AddItem(($"{Convert.ToString(snp_AirframeType["aftype_code"])}-{Convert.ToString(snp_AirframeType["aftype_name"])}").Trim());
						snp_AirframeType.MoveNext();
					};
				}

				this.Cursor = CursorHelper.CursorDefault;
				cbo_amod_Airframe_Type_Code.SelectedIndex = 0;
			}
			catch (System.Exception excep)
			{

				this.Cursor = CursorHelper.CursorDefault;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_Airframe_Type_Error: {Information.Err().Number.ToString()} {excep.Message}");
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
				return;
			}
		}

		private void Fill_Anti_Torque_List()
		{

			cmb_amod_rotor_anti_torque_system.Items.Clear();
			cmb_amod_rotor_anti_torque_system.AddItem("");
			cmb_amod_rotor_anti_torque_system.AddItem("Unknown");
			cmb_amod_rotor_anti_torque_system.AddItem("None");
			cmb_amod_rotor_anti_torque_system.SelectedIndex = 0;


		}

		private void Fill_CBO_DropDown()
		{
			cbo_tbo_list.Items.Clear();
			cbo_tbo_list.AddItem("1200");
			cbo_tbo_list.AddItem("1400");
			cbo_tbo_list.AddItem("1600");
			cbo_tbo_list.AddItem("1700"); //added 6/3/04 aey
			cbo_tbo_list.AddItem("2000");
			cbo_tbo_list.AddItem("2500");
			cbo_tbo_list.AddItem("3000");
			cbo_tbo_list.AddItem("3500");
			cbo_tbo_list.AddItem("3600");
			cbo_tbo_list.AddItem("3800");
			cbo_tbo_list.AddItem("4000");
			cbo_tbo_list.AddItem("4500");
			cbo_tbo_list.AddItem("5000");
			cbo_tbo_list.AddItem("5400");
			cbo_tbo_list.AddItem("5500");
			cbo_tbo_list.AddItem("6000");
			cbo_tbo_list.AddItem("8000");
			cbo_tbo_list.SelectedIndex = -1;

		}


		private void Fill_Commercial_Model_Map()
		{
			int homebase_amod_id = 0;
			int commercial_amod_id = 0;
			int amod_id = 0;
			ADORecordSetHelper adoModels = new ADORecordSetHelper();
			int grdRow = 0;
			int J = 0;


			grdAircraftMap.Visible = false;
			string Query = "Select * from Map_Model ";
			adoModelmap.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

			grdModelMap.Visible = false;
			grdModelMap.Enabled = false;

			grdModelMap.Clear();
			grdModelMap.ColumnsCount = 5;
			grdModelMap.RowsCount = 2;

			grdModelMap.CurrentRowIndex = 0;
			grdModelMap.CurrentColumnIndex = 0;
			grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].Value = "commercial_amod_id";
			grdModelMap.SetColumnWidth(0, 0);
			grdModelMap.CurrentColumnIndex = 1;
			grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].Value = "homebase_amod_id";
			grdModelMap.SetColumnWidth(1, 0);
			grdModelMap.CurrentColumnIndex = 2;
			grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].Value = "Commercial Make/Model";
			grdModelMap.SetColumnWidth(2, 200);
			grdModelMap.CurrentColumnIndex = 3;
			grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].Value = "Type";
			grdModelMap.SetColumnWidth(3, 40);
			grdModelMap.CurrentColumnIndex = 4;
			grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].Value = "Homebase Make/Model";
			grdModelMap.SetColumnWidth(4, 200);


			//get commercial model list
			//Query = "SELECT distinct *  FROM Aircraft_Model WITH(NOLOCK) "
			Query = "SELECT distinct amod_id, amod_make_name , amod_model_name, mapMod_homebase_amod_id, mapmod_model_name, mapmod_load_flag, amod_type_code  FROM Aircraft_Model WITH(NOLOCK)";
			Query = $"{Query}left outer join Map_Model on amod_id=mapmod_com_amod_id ";
			Query = $"{Query}ORDER BY amod_make_name,amod_model_name ";
			adoModels.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
			lbl_spec[3].Text = " Loading Please Wait";
			lbl_spec[3].BackColor = Color.Red;
			lbl_spec[3].Refresh();
			if (!(adoModels.BOF && adoModels.EOF))
			{
				adoModels.MoveFirst();
				grdModelMap.CurrentRowIndex = 1;


				while(!adoModels.EOF)
				{
					grdModelMap.CurrentColumnIndex = 0;
					amod_id = Convert.ToInt32(adoModels["amod_id"]);
					grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].Value = amod_id;

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(adoModels["mapMod_homebase_amod_id"]))
					{
						homebase_amod_id = Convert.ToInt32(adoModels["mapMod_homebase_amod_id"]);
					}
					else
					{
						homebase_amod_id = 0;
					}

					grdModelMap.CurrentColumnIndex = 1;
					grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].Value = homebase_amod_id;

					grdModelMap.CurrentColumnIndex = 2;

					grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].Value = ($"{Convert.ToString(adoModels["amod_make_name"]).Trim()}-{Convert.ToString(adoModels["amod_model_name"]).Trim()}");


					grdModelMap.CurrentColumnIndex = 3;
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(adoModels["amod_type_code"]))
					{
						grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].Value = adoModels.GetField("amod_type_code");
					}

					if (homebase_amod_id > 0)
					{
						grdModelMap.CurrentColumnIndex = 4;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(adoModels["mapmod_model_name"]))
						{
							if (Convert.ToString(adoModels["mapmod_model_name"]) != "")
							{
								grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].Value = adoModels.GetField("mapmod_model_name");
							}
							else
							{
								grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].Value = "To Load";
							}
						}
						else
						{
							grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].Value = "To Load";
						}
					}
					else
					{
						grdModelMap.CurrentColumnIndex = 4;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(adoModels["mapmod_model_name"]))
						{
							if (Convert.ToString(adoModels["mapmod_model_name"]) == "")
							{
								grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].Value = "To Load";
							}
							else
							{
								grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].Value = adoModels.GetField("mapmod_model_name");
							}
						}
						else
						{
							grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].Value = "To Load";
						}
					}


					grdModelMap.set_RowData(grdModelMap.CurrentRowIndex, homebase_amod_id);

					grdModelMap.RowsCount++;
					grdModelMap.CurrentRowIndex++;

					adoModels.MoveNext();
				};

				adoModels.Close();
				adoModels = null;

				grdModelMap.RowsCount--;
				grdModelMap.CurrentRowIndex = 1;
				grdModelMap.Enabled = true;
				grdModelMap.Visible = true;
				grdModelMap.Redraw = true;
				adoModelmap.Close();
				adoModelmap = null;
				lbl_spec[3].Text = " Data Is Ready";
				lbl_spec[3].BackColor = Color.Lime;
				lbl_spec[3].Refresh();
			}

		}
		private bool Key_Feature_Add_Update_Stored_Procedure(int amod_id, string feature_code)
		{

			ADORecordSetHelper ado_FeatureCount = new ADORecordSetHelper();


			string Query = $" exec Update_Model_Key_Feature {amod_id.ToString()},'{feature_code.Trim()}'";
			Query = Query;
			DbCommand TempCommand = null;
			TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
			UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
			TempCommand.CommandText = Query;
			//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
			TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
			UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
			TempCommand.ExecuteNonQuery();

			return false;
		}





		//UPGRADE_NOTE: (7001) The following declaration (View_Commercial_Model_Map) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void View_Commercial_Model_Map(string selected_amod_id)
		//{
			//
			//int homebase_amod_id = 0;
			//int commercial_amod_id = 0;
			//int amod_id = 0;
			//ADORecordSetHelper adoModels = new ADORecordSetHelper();
			//int grdRow = 0;
			//int J = 0;
			//
			//string Query = "Select * from Map_Model ";
			//adoModelmap.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);
			//
			//grdModelMap.Clear();
			//grdModelMap.ColumnsCount = 8;
			//grdModelMap.RowsCount = 2;
			//
			//grdModelMap.CurrentRowIndex = 0;
			//grdModelMap.CurrentColumnIndex = 0;
			//grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].Value = "commercial_amod_id";
			//grdModelMap.SetColumnWidth(0, 0);
			//grdModelMap.CurrentColumnIndex = 1;
			//grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].Value = "homebase_amod_id";
			//grdModelMap.SetColumnWidth(1, 0);
			//grdModelMap.CurrentColumnIndex = 2;
			//grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].Value = "Commercial Make/Model";
			//grdModelMap.SetColumnWidth(2, 233);
			//grdModelMap.CurrentColumnIndex = 3;
			//grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].Value = "Homebase Make/Model";
			//grdModelMap.SetColumnWidth(3, 233);
			//grdModelMap.CurrentColumnIndex = 4;
			//grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].Value = "Model Type Code";
			//grdModelMap.SetColumnWidth(4, 103);
			//grdModelMap.CurrentColumnIndex = 5;
			//grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].Value = "AC ID";
			//grdModelMap.SetColumnWidth(5, 100);
			//grdModelMap.CurrentColumnIndex = 6;
			//grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].Value = "Serial #";
			//grdModelMap.SetColumnWidth(6, 100);
			//grdModelMap.CurrentColumnIndex = 7;
			//grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].Value = "Reg #";
			//grdModelMap.SetColumnWidth(7, 100);
			//
			////get commercial model list
			////Query = "SELECT distinct *  FROM Aircraft_Model WITH(NOLOCK) "
			//Query = "SELECT distinct amod_id, amod_make_name , amod_model_name, mapMod_homebase_amod_id, mapmod_model_name, mapmod_load_flag, amod_type_code,ac_id,ac_ser_no_full,ac_reg_no  FROM Aircraft_Model WITH(NOLOCK)";
			//Query = $"{Query}left outer join Map_Model on amod_id=mapmod_com_amod_id left outer join aircraft on amod_id=ac_amod_id ";
			//Query = $"{Query}WHERE mapMod_homebase_amod_id = {selected_amod_id}";
			//Query = $"{Query}ORDER BY amod_make_name,amod_model_name ";
			//adoModels.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);
			//lbl_spec[3].Text = " Loading Please Wait";
			//lbl_spec[3].BackColor = Color.Red;
			//lbl_spec[3].Refresh();
			//if (!(adoModels.BOF && adoModels.EOF))
			//{
				//adoModels.MoveFirst();
				//grdRow = 0;
				//
				//while(!adoModels.EOF)
				//{
					//grdRow++;
					//grdModelMap.RowsCount++;
					//grdModelMap.CurrentRowIndex = grdRow;
					//grdModelMap.CurrentColumnIndex = 0;
					//amod_id = Convert.ToInt32(adoModels["amod_id"]);
					//grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].Value = amod_id;
					//
					//grdModelMap.CurrentColumnIndex = 2;
					//
					//grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].Value = ($"{Convert.ToString(adoModels["amod_make_name"]).Trim()} / {Convert.ToString(adoModels["amod_model_name"]).Trim()}");
					//
					////UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					//if (!Convert.IsDBNull(adoModels["mapMod_homebase_amod_id"]))
					//{
						//homebase_amod_id = Convert.ToInt32(Double.Parse($"{Convert.ToString(adoModels["mapMod_homebase_amod_id"])}"));
					//}
					//
					//grdModelMap.CurrentColumnIndex = 1;
					//grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].Value = homebase_amod_id;
					//
					//if (homebase_amod_id > 0)
					//{
						//grdModelMap.CurrentColumnIndex = 3;
						////UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						//if (!Convert.IsDBNull(adoModels["mapmod_model_name"]))
						//{
							//if (Convert.ToString(adoModels["mapmod_model_name"]) != "")
							//{
								//grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].Value = adoModels.GetField("mapmod_model_name");
							//}
							//else
							//{
								//grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].Value = "To Load";
							//}
						//}
						//else
						//{
							//grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].Value = "To Load";
						//}
					//}
					//else
					//{
						//grdModelMap.CurrentColumnIndex = 3;
						////UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						//if (!Convert.IsDBNull(adoModels["mapmod_model_name"]))
						//{
							//if (Convert.ToString(adoModels["mapmod_model_name"]) == "")
							//{
								//grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].Value = "To Load";
							//}
							//else
							//{
								//grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].Value = adoModels.GetField("mapmod_model_name");
							//}
						//}
						//else
						//{
							//grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].Value = "To Load";
						//}
					//}
					//grdModelMap.CurrentColumnIndex = 4;
					////UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					//if (!Convert.IsDBNull(adoModels["amod_type_code"]))
					//{
						//grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].Value = adoModels.GetField("amod_type_code");
					//}
					//grdModelMap.CurrentColumnIndex = 5;
					////UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					//if (!Convert.IsDBNull(adoModels["ac_id"]))
					//{
						//grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].Value = adoModels.GetField("ac_id");
					//}
					//grdModelMap.CurrentColumnIndex = 6;
					////UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					//if (!Convert.IsDBNull(adoModels["ac_ser_no_full"]))
					//{
						//grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].Value = adoModels.GetField("ac_ser_no_full");
					//}
					//grdModelMap.CurrentColumnIndex = 7;
					////UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					//if (!Convert.IsDBNull(adoModels["ac_reg_no"]))
					//{
						//grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].Value = adoModels.GetField("ac_reg_no");
					//}
					//Application.DoEvents();
					//adoModels.MoveNext();
				//};
				//adoModels.Close();
				//adoModels = null;
				//grdModelMap.RowsCount--;
				//grdModelMap.Visible = true;
				//adoModelmap.Close();
				//adoModelmap = null;
				//lbl_spec[3].Text = " Data Is Ready";
				//lbl_spec[3].BackColor = Color.Lime;
				//lbl_spec[3].Refresh();
			//}
			//
		//}
		private void Fill_IFR_Certification_List()
		{

			cmb_amod_ifr_certification.Items.Clear();
			cmb_amod_ifr_certification.AddItem("Unknown");
			cmb_amod_ifr_certification.AddItem("Not Certified");
			cmb_amod_ifr_certification.AddItem("1 Pilot");
			cmb_amod_ifr_certification.AddItem("2 Pilot");
			cmb_amod_ifr_certification.SelectedIndex = 0;

		}

		private void Fill_Model_Usage_List()
		{

			ADORecordSetHelper ado_Usage = new ADORecordSetHelper();

			UsageList.Items.Clear();

			string Query = "SELECT * FROM aircraft_model_useage WITH(NOLOCK)";
			Query = $"{Query} Inner join Aircraft_Useage WITH(NOLOCK) on acuse_code = acmoduse_use_code";
			Query = $"{Query} WHERE acmoduse_amod_id = {Convert.ToInt32(Conversion.Val(txt_amod_id.Text.Trim())).ToString()}";
			Query = $"{Query} ORDER BY acuse_name ";

			ado_Usage.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
			if (!(ado_Usage.BOF && ado_Usage.EOF))
			{

				while (!ado_Usage.EOF)
				{
					UsageList.AddItem($"{Convert.ToString(ado_Usage["acuse_code"])} {Convert.ToString(ado_Usage["acuse_name"])}");
					UsageList.SetItemData(UsageList.GetNewIndex(), Convert.ToInt32(Double.Parse($"{Convert.ToString(ado_Usage["acmoduse_id"])}")));
					ado_Usage.MoveNext();
				}

				ListBoxHelper.SetSelectedIndex(UsageList, -1);
				ado_Usage.Close();
			}


		}

		private void Fill_Research_Type()
		{
			//get codes for airframe type
			//aey 1/7/05
			//******************************************************************************************

			string Query = "";
			int FixedRow = 0;

			try
			{

				CmbResearchType.Items.Clear();
				CmbResearchType.AddItem("A - All");
				FixedRow = 0;

				Query = "SELECT * FROM Airframe_Type ORDER BY aftype_code ";

				snp_AirframeType.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_AirframeType.BOF && snp_AirframeType.EOF))
				{

					while(!snp_AirframeType.EOF)
					{
						CmbResearchType.AddItem(($"{Convert.ToString(snp_AirframeType["aftype_code"])}-{Convert.ToString(snp_AirframeType["aftype_name"])}").Trim());
						if (snp_AirframeType["aftype_code"] == modAdminCommon.snp_User["user_default_airframe"])
						{
							FixedRow = CmbResearchType.GetNewIndex();
						}

						snp_AirframeType.MoveNext();
					};
				}

				this.Cursor = CursorHelper.CursorDefault;
				CmbResearchType.SelectedIndex = FixedRow;
				snp_AirframeType.Close();
				snp_AirframeType = null;
			}
			catch (System.Exception excep)
			{

				this.Cursor = CursorHelper.CursorDefault;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_Research_Type_Error: {Information.Err().Number.ToString()} {excep.Message}");
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
				return;
			}

		}

		private void FillWeightClass(string inClass)
		{

			try
			{

				string Query = "";
				//    Dim snpWeightClass As Recordset converted to ado 7/25/05 aey
				ADORecordSetHelper snpWeightClass = new ADORecordSetHelper();

				cboWeightClass.Items.Clear();

				Query = $"SELECT acwgtcls_code, acwgtcls_name FROM Aircraft_Weight_Class WHERE acwgtcls_maketype = '{inClass}'";

				snpWeightClass.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpWeightClass.BOF && snpWeightClass.EOF))
				{

					while(!snpWeightClass.EOF)
					{
						cboWeightClass.AddItem($"{($"{Convert.ToString(snpWeightClass["acwgtcls_code"])}").Trim()} - {($"{Convert.ToString(snpWeightClass["acwgtcls_name"])}").Trim()}");
						snpWeightClass.MoveNext();
					}; //Do While Not snpWeightClass.EOF

				} //If Not (snpWeightClass.BOF And snpWeightClass.EOF) Then

				snpWeightClass.Close();
				snpWeightClass = null;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"FillWeightClassError: {Information.Err().Number.ToString()} {excep.Message}");
			}

		}


		private void Key_Feature_Update_Grid_Row()
		{
			//
			// PURPOSE: THE PURPOSE OF THIS PROCEDURE IS TO UPDATE THE AIRCRAFT MODEL
			// KEY FEATURE RECORD
			//
			// RTW - 4/8/2004 - MODIFIED TO NOT BE DEPENDENT ON SNAPSHOT & DOCUMENTED
			// *****************************************************************
			try
			{

				if (Key_Feature_Valid_For_Update())
				{
					this.Cursor = Cursors.WaitCursor;

					grd_Keyfeature.CurrentColumnIndex = 1;

					// UPDATE THE STANDARD EQUIPMENT FLAG IN THE GRID
					grd_Keyfeature.CurrentColumnIndex = 3;
					if (chkStandard.CheckState == CheckState.Checked)
					{
						grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].Value = "Y";
					}
					else
					{
						grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].Value = "N";
					}

					// UPDATE THE STANDARD EQUIPMENT START SER NO IN THE GRID
					grd_Keyfeature.CurrentColumnIndex = 4;
					if (txtFeatStartSerNo.Text.Trim() != "")
					{
						grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].Value = txtFeatStartSerNo.Text.Trim();
					}
					else
					{
						grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].Value = "";
					}

					// UPDATE THE STANDARD EQUIPMENT START SER NO IN THE GRID
					grd_Keyfeature.CurrentColumnIndex = 5;
					if (txtFeatEndSerNo.Text.Trim() != "")
					{
						grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].Value = txtFeatEndSerNo.Text.Trim();
					}
					else
					{
						grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].Value = "";
					}

					if (chk_Inactive_Feature_Code.CheckState == CheckState.Checked)
					{
						grd_Keyfeature.CurrentColumnIndex = 7;
						grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].Value = modAdminCommon.DateToday;
						grd_Keyfeature.CurrentColumnIndex = 8;
						grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].Value = "INACTIVE";
					}
					else
					{
						grd_Keyfeature.CurrentColumnIndex = 8;
						grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].Value = "UPDATE";
					}

					grd_Keyfeature.RowSel = grd_Keyfeature.CurrentRowIndex;

					if (NeedTransaction)
					{
						MessageBox.Show("No Transactions Are Currently Being Written Here", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						NeedTransaction = false;
					}
					this.Cursor = CursorHelper.CursorDefault;
					//UPGRADE_ISSUE: (207) An invalid structure was generated in this location, inside Key_Feature_Update_Grid_Row. Please check source code. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-207
					//cmd_button_array().Visible = True
					grd_Keyfeature_Click(grd_Keyfeature, new EventArgs());
				}
			}
			catch
			{
				modAdminCommon.Report_Error($"Key_Feature_Update_Grid_Row_Error:KEY FEATURE MAY NOT HAVE BEEN SAVED.");
			}


		}

		private void Select_Aircraft_Weight_Class()
		{


			int tempForEndVar = cboWeightClass.Items.Count - 1;
			for (int i = 0; i <= tempForEndVar; i++)
			{

				if (cboWeightClass.GetListItem(i).StartsWith(($"{Convert.ToString(snp_Model["amod_weight_class"])}").Trim(), StringComparison.Ordinal))
				{
					cboWeightClass.SelectedIndex = i;
					break;
				}

			}

		}

		private void Select_Body_Configuration()
		{


			string strType = ($"{Convert.ToString(snp_Model["amod_body_config"])} ").Trim();
			string strName = modCommon.DLookUp("ambc_name", "Aircraft_Model_Body_Config", $"(ambc_type='{strType}')");

			if (strName != "")
			{

				int tempForEndVar = cmbBodyConfig.Items.Count - 1;
				for (int iCnt1 = 0; iCnt1 <= tempForEndVar; iCnt1++)
				{
					if (cmbBodyConfig.GetListItem(iCnt1) == strName)
					{
						cmbBodyConfig.SelectedIndex = iCnt1;
					}
				}

			}
			else
			{
				strName = "Unknown";
				cmbBodyConfig.SelectedIndex = 0;
			}

		}

		public void Select_Airframe_Type()
		{
			try
			{

				int i = 0;

				snp_AirframeType.MoveFirst();
				i = 0;

				while(!snp_AirframeType.EOF)
				{
					if (snp_AirframeType["aftype_code"] == snp_Model["amod_airframe_type_code"])
					{
						cbo_amod_Airframe_Type_Code.SelectedIndex = i;
						return;
					}
					snp_AirframeType.MoveNext();
					i++;
				};
			}
			catch (System.Exception excep)
			{

				this.Cursor = CursorHelper.CursorDefault;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Select_Airframe_Type_Error: {Information.Err().Number.ToString()} {excep.Message}");
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
				return;
			}

		}

		private void cbo_amod_Airframe_Type_Code_SelectedIndexChanged(Object eventSender, EventArgs eventArgs) => ToolTipMain.SetToolTip(cbo_amod_Airframe_Type_Code, $"Modify Model Type from: {cbo_amod_Airframe_Type_Code.Text}");



		private void cbo_amod_type_code_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{

			if (cbo_amod_type_code.Text.Trim() != "")
			{
				FillWeightClass(cbo_amod_type_code.Text);
			}

		}


		private void cbo_MakeSelect_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs) => Fill_Make_Model_Sort_Grid();


		private void cbo_Model_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs)
		{

			if (!bIsFormLoad)
			{

				scr_Models.Value = cbo_Model.SelectedIndex + 1;
				txt_model_number.Text = (cbo_Model.SelectedIndex + 1).ToString();
				mnuDeleteModel.Available = false;
				RecordStat = "Update";
				ToolTipMain.SetToolTip(cbo_Model, cbo_Model.Text); //aey 2/14/05 display wider fields as tooltip

				Select_Aircraft_Model();

			}

		} // cbo_Model_Click

		private void cbo_tbo_list_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{
				string char_Renamed = Strings.Chr(KeyAscii).ToString();
				if (char_Renamed.Trim() == "" || KeyAscii <= 13)
				{
					if (KeyAscii == 0)
					{
						eventArgs.Handled = true;
					}
					return;
				}
				if (String.CompareOrdinal(char_Renamed, "0") < 0 || String.CompareOrdinal(char_Renamed, "9") > 0)
				{
					KeyAscii = 0;
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
		}

		private void chk_amod_product_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.chk_amod_product, eventSender);
			// 7/21/2011 - MSW when business is checked helicopter shouldnt be able to be, and vice-versa
			if (chk_amod_product[Index].CheckState == CheckState.Checked)
			{

				if (Index == 0)
				{
					chk_amod_product[1].Enabled = false;
				}
				else if (Index == 1)
				{ 
					chk_amod_product[0].Enabled = false;
				}

				chk_amod_product[Index].CheckState = CheckState.Checked;
			}
			else
			{
				if (Index == 0)
				{
					chk_amod_product[1].Enabled = true;
				}
				else if (Index == 1)
				{ 
					chk_amod_product[0].Enabled = true;
				}
			}

		}

		private void chk_Inactive_Feature_Code_CheckStateChanged(Object eventSender, EventArgs eventArgs) => Key_Feature_Update_Active_Status();


		private void chk_oncondtbox_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{
			//aey 5/30/04

			cbo_tbo_list.Visible = true; //set default
			lbl_specs[18].Visible = true;
			if (chk_oncondtbox.CheckState == CheckState.Checked)
			{
				cbo_tbo_list.Visible = false;
				lbl_specs[18].Visible = false;
				//txt_amod_engine_com_tbo_hrs.Visible = True
			}

		}

		private void chkFeatCount_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{

			if (chkFeatCount.CheckState == CheckState.Unchecked)
			{
				lblFeatureYes.Visible = false;
				lblFeatureNo.Visible = false;
				lblFeatureUnknown.Visible = false;
			}
			else
			{
				Display_Key_Feature_Counts();
			}

		}

		private void cmb_amod_ifr_certification_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs) => ToolTipMain.SetToolTip(cmb_amod_ifr_certification, cmb_amod_ifr_certification.Text);



		private void cmb_amod_rotor_anti_torque_system_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs) => ToolTipMain.SetToolTip(cmb_amod_rotor_anti_torque_system, cmb_amod_rotor_anti_torque_system.Text);



		private void cmbResearchType_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs)
		{
			ToolTipMain.SetToolTip(CmbResearchType, $"Change View from: {CmbResearchType.Text}");
			if (ResearchRefresh)
			{
				Fill_Aircraft_Model_List(0);
			}

			if (CmbResearchType.Text == "R" || CmbResearchType.Text == "F")
			{
				cbo_amod_type_code.Text = CmbResearchType.Text;
			}

		}

		private void cmd_Add_Engine_Click(Object eventSender, EventArgs eventArgs)
		{

			lbl_specs[93].Text = "Engine Model Id: 0";
			lbl_specs[93].Tag = "0";

			txt_ameng_mfr_CompID.Text = "0";
			txt_ameng_mfr_name.Text = "";
			txt_ameng_mfr_name_short.Text = "";
			txt_ameng_engine_prefix.Text = "";
			txt_ameng_engine_core.Text = "";
			txt_ameng_engine_suffix1.Text = "";
			txt_ameng_engine_suffix2.Text = "";
			txt_ameng_seq_no.Text = "";
			txt_ameng_takeoff_power.Text = "";
			txt_ameng_max_continuous_power.Text = "";
			Chk_ameng_active_flag.CheckState = CheckState.Checked;
			EngineStat = "Add";

			s_PrevEngineName = "";
			pnl_Aircraft_Model_Engine_Add.Visible = true;

		}

		private void cmd_button_array_Click(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.cmd_button_array, eventSender);

			if (Index == 0)
			{
				Key_Feature_Move_Row("Down"); // move feature down
			}
			else if (Index == 1)
			{ 
				Key_Feature_Move_Row("Up"); //move feature down
			}
			else if (Index == 2)
			{ 
				pnl_MasterKeyFeatures.Visible = true; // get master feature list
				//UPGRADE_ISSUE: (207) An invalid structure was generated in this location, inside cmd_button_array_Click. Please check source code. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-207
				//cmd_button_array().Visible = False
			}
			else if (Index == 3)
			{ 
				Key_Feature_Add_Grid_Row();
			}
			else if (Index == 4)
			{ 
				pnl_MasterKeyFeatures.Visible = false; // cancel button
				//Fill_Aircraft_Model_Feature_List
				Key_Feature_Fill_Grid();
			}
			else if (Index == 5)
			{ 
				// CALL THE PROCEDURE TO SAVE ENTRIES IN THE GRID
				Key_Feature_Save_Grid();
			}
			else if (Index == 6)
			{ 
				Key_Feature_Update_Grid_Row();
			}
			else if (Index == 7)
			{ 
				Key_Feature_Remove_Grid_Row();
			}

			//UPGRADE_ISSUE: (207) An invalid structure was generated in this location, inside cmd_button_array_Click. Please check source code. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-207
			//cmd_button_array().Caption = Changed

		}

		private void cmd_button_Click(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.cmd_button, eventSender);
			switch(Index)
			{
				case 0 : 
					if (lbl_specs[80].Text == "hide")
					{
						lbl_specs[80].Text = "in:";
						pnlCabinDimension.Visible = true;
						cmd_button[0].Text = "Hide Cabin Dimensions";
					}
					else
					{
						lbl_specs[80].Text = "hide";
						pnlCabinDimension.Visible = false;
						cmd_button[0].Text = "Show Cabin Dimensions";
					} 
					break;
			}
		}

		//UPGRADE_NOTE: (7001) The following declaration (Command1_Click) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void Command1_Click()
		//{
			//
			//
		//}

		private void cmd_Make_Move1_Click(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.cmd_Make_Move1, eventSender);


			if (Index == 0)
			{
				Key_Feature_Move_Row("Up");
			}
			else if (Index == 1)
			{ 
				Make_Sort_Move_Row("Down");
			}
			else if (Index == 2)
			{ 
				Save_MakeSort_Grid();
			}


		}

		private void cmd_new_Click(Object eventSender, EventArgs eventArgs)
		{


			frm_Journal.DefInstance.Reference_Journal_ID = 0;
			frm_Journal.DefInstance.Historical_Journal_ID = 0;
			frm_Journal.DefInstance.Reference_Ac_Id = 0;
			frm_Journal.DefInstance.Reference_Comp_Id = 0;
			frm_Journal.DefInstance.Reference_Subject = "";
			frm_Journal.DefInstance.Reference_Yacht_Id = 0;
			frm_Journal.DefInstance.Reference_Amod_Id = Convert.ToInt32(Double.Parse(txt_amod_id.Text));
			frm_Journal.DefInstance.Reference_Contact_Id = 0;
			frm_Journal.DefInstance.Reference_Category_Code = "AR";
			frm_Journal.DefInstance.Reference_SubCategory_Code = "RN";
			frm_Journal.DefInstance.pnl_Journal_Heading.Visible = false;
			modAdminCommon.Rec_Journal_Info.journ_account_id = modAdminCommon.gbl_Account_ID;
			frm_Journal.DefInstance.txt_journ_subject.Enabled = true;
			frm_Journal.DefInstance.ShowDialog();

			frm_Journal.DefInstance.Reference_Amod_Id = 0;


			fill_amod_journal_grid();

			this.Activate();

		}

		public void GenericReport_Click(Object eventSender, EventArgs eventArgs)
		{

			//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			//VB.Global.Load(frm_WebReport.DefInstance);
			modCommon.CenterFormOnHomebaseMainForm(frm_WebReport.DefInstance);
			frm_WebReport.DefInstance.WhichReport = "Aircraft Generic Model";
			frm_WebReport.DefInstance.PassedModelID = Convert.ToInt32(Double.Parse(txt_amod_id.Text));
			frm_WebReport.DefInstance.Show();


		}

		private void grd_amod_journal_DoubleClick(Object eventSender, EventArgs eventArgs)
		{

			if (grd_amod_journal.CurrentRowIndex > 0)
			{

				frm_Journal.DefInstance.Reference_Journal_ID = grd_amod_journal.get_RowData(grd_amod_journal.CurrentRowIndex);
				frm_Journal.DefInstance.Reference_Comp_Id = 0;
				frm_Journal.DefInstance.Reference_Ac_Id = 0;

				frm_Journal.DefInstance.ShowDialog();

				frm_Journal.DefInstance.Reference_Amod_Id = 0;

			}

			fill_amod_journal_grid();

			grd_amod_journal.Enabled = true;

		}


		private void lbl_specs_DoubleClick(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.lbl_specs, eventSender);


			int lEMId = 0;
			if (Index == 18)
			{
				lEMId = 0;
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(snp_AircraftEngine["ameng_engine_model_id"]))
				{
					lEMId = Convert.ToInt32(snp_AircraftEngine["ameng_engine_model_id"]);
				}

			}


		}


		public void Update_Aircraft_TBO_Hours(int engine_id, int engine_old_tbo_hours, int engine_new_tbo_hours, int amod_id)
		{


			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strUpdate1 = "";
			int ac_id = 0;
			StringBuilder ac_id_list = new StringBuilder();
			int total_count = 0;
			string where_Addition = "";


			if (MessageBox.Show("Would You Like To Update All 'On Market' Aircraft for this Engine Model with Matching TBO", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
			{
			}
			else
			{
				where_Addition = " and ac_forsale_flag = 'N' "; // off markets only
			}

			if (engine_id > 0)
			{

				for (int i = 1; i <= 4; i++)
				{

					ac_id_list = new StringBuilder("");
					total_count = 0;

					strQuery1 = "SELECT distinct ac_id FROM Aircraft_Model_Engine ";
					strQuery1 = $"{strQuery1} inner join aircraft with (NOLOCK) on ac_amod_id = ameng_amod_id and ac_journ_id = 0 ";
					strQuery1 = $"{strQuery1} inner join Aircraft_Model with (NOLOCK) on ac_amod_id = amod_id ";
					strQuery1 = $"{strQuery1} where ameng_engine_model_id = {engine_id.ToString()}";

					if (where_Addition.Trim() != "")
					{
						strQuery1 = $"{strQuery1}{where_Addition}";
					}

					strQuery1 = $"{strQuery1} and (ac_engine_{i.ToString()}_tbo_hrs = '{engine_old_tbo_hours.ToString()}' or ((ac_engine_{i.ToString()}_tbo_hrs = '0' or ac_engine_{i.ToString()}_tbo_hrs IS NULL)  and amod_number_of_engines >= {i.ToString()}) ) ";

					strQuery1 = $"{strQuery1} ORDER BY ac_id desc ";

					rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						do 
						{ //Loop Until snpAC.EOF = True

							ac_id = Convert.ToInt32(rstRec1["ac_id"]);
							total_count++;

							if (ac_id_list.ToString().Trim() != "")
							{
								ac_id_list.Append(", ");
							}

							ac_id_list.Append(ac_id.ToString());

							rstRec1.MoveNext();
						}
						while(!rstRec1.EOF);

					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();



				}




			} // If lAModId > 0 Then


		}


		public void mnuDeleteModel_Click(Object eventSender, EventArgs eventArgs)
		{
			if (MessageBox.Show("Are You Sure You Want To Delete This Model?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
			{
				Delete_Model();
			}
		}

		private void cmd_Engine_Cancel_Click(Object eventSender, EventArgs eventArgs)
		{
			// write to table action log
			modAdminCommon.Record_Event("Aircraft Model Engine Cancel", $"User clicked the Cancel button on the panel: AModId:=[{txt_amod_id.Text}]  Manufacturer:=[{txt_ameng_mfr_name.Text}] Core:=[{txt_ameng_engine_core.Text}]", 0, 0, 0);

			pnl_Aircraft_Model_Engine_Add.Visible = false;
		}

		private void cmd_Engine_Save_Click(Object eventSender, EventArgs eventArgs)
		{


			string s_EngineName = modCommon.BuildEngineModelName(txt_ameng_engine_prefix.Text, txt_ameng_engine_core.Text, txt_ameng_engine_suffix1.Text, txt_ameng_engine_suffix2.Text);

			if (Check_Engine_Info())
			{

				if (Save_Engine_Data(s_EngineName))
				{
					Fill_Aircraft_Engine_List();
				}

			} // If Check_Engine_Info() = True Then

		}

		public bool AC_Engine_Mass_Update(string s_EngineName)
		{
			bool result = false;
			string aErrorMsg = "";
			try
			{
				// Create a string to query the DB with the Affected Ac info
				string strQuery = "";
				strQuery = "";
				// create an int to hold the # of locked AC's
				int intLocked_AC = 0;
				intLocked_AC = 0;
				// create a string to hold the new engine name
				string new_EngineName = "";
				new_EngineName = "";
				// create a string to hold the reason why evo update faild
				string strEvo_Update_status = "";
				strEvo_Update_status = "";
				// setup the query to get the number of AC effected

				strQuery = "SELECT ac_id, ac_journ_id, ac_amod_id FROM Aircraft WITH (NOLOCK) ";
				strQuery = $"{strQuery} WHERE ac_amod_id = {Convert.ToString(snp_AircraftEngine["ameng_amod_id"])}";
				strQuery = $"{strQuery} AND ac_engine_name = '{s_PrevEngineName}'";
				strQuery = $"{strQuery} AND ac_journ_id = 0";
				snp_AC_Engine_Check.Open(strQuery, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_AC_Engine_Check.BOF && snp_AC_Engine_Check.EOF))
				{
					//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
					// prompt to the user that this will affect 'x' amount of AC
					//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
					if (MessageBox.Show($"This will affect: {snp_AC_Engine_Check.RecordCount.ToString()} Aircraft are you sure you want to continue", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
					{
						if (Check_For_Locked_AC_Engines(ref intLocked_AC, snp_AC_Engine_Check, s_EngineName))
						{
							// prompt the user that the update cannot continue
							MessageBox.Show($"Update cannot continue {intLocked_AC.ToString()} ac's are locked, please try again later", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						}
						else
						{
							// proceed with the update
							// Update the Engine name where the ac_amod_id = X and the journ_id = 0 and previous engine name
							strQuery = $"UPDATE Aircraft SET ac_engine_name_search='{StringsHelper.Replace(s_EngineName.Trim(), modGlobalVars.cHyphen, modGlobalVars.cEmptyString, 1, -1, CompareMethod.Binary)}', ac_engine_name='{s_EngineName}', ac_action_date='{DateTimeHelper.ToString(DateTime.Parse(DateTimeHelper.ToString(DateTime.Now)))} {DateTimeHelper.ToString(DateTime.Now)}' WHERE ac_amod_id = {Convert.ToString(snp_AircraftEngine["ameng_amod_id"])} AND ac_journ_id = 0 AND ac_engine_name='{s_PrevEngineName}'";
							// check to see if we are on the live database if we are we need to update evo
							if (modAdminCommon.gDatabaseName == "jetnet_ra")
							{
								if (Update_Evo_AC_Engine_Info(strQuery, ref strEvo_Update_status))
								{
									if (!Update_Inhouse_AC_Engine_Info(strQuery, s_EngineName))
									{
										MessageBox.Show("There was an error while updating the Inhouse database, updated failed", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
									}
									else
									{
										result = true;
									} // If Update_Inhouse_AC_Engine_Info Then
								}
								else
								{
									MessageBox.Show($"There was an error while updating the Evo database, updated failed: {strEvo_Update_status}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
								} // If Update_Evo_AC_Engine_Info Then
							}
							else
							{
								if (!Update_Inhouse_AC_Engine_Info(strQuery, s_EngineName))
								{
									MessageBox.Show("There was an error while updating the Inhouse database, updated failed", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
								}
								else
								{
									result = true;
								} // If Update_Inhouse_AC_Engine_Info Then
							} // gDatabaseName
						} // If Check_For_Locked_AC_Engines(intLocked, snp_AC_Engine_Check) Then
					} // If MsgBox("This will affect: " & snp_AC_Engine_Check.RecordCount & " Aircraft are you sure you want to continue", vbYesNo) = vbYes Then
				} // If Not (snp_AC_Engine_Check.BOF And snp_AC_Engine_Check.EOF) Then

				snp_AC_Engine_Check.Close();
			}
			catch (System.Exception excep)
			{
				aErrorMsg = excep.Message;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"AC_Engine_Mass_Update: {Information.Err().Number.ToString()} {aErrorMsg}");
				MessageBox.Show($"Error in AC_Engine_Mass_Update: {aErrorMsg}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
			return result;
		}

		public bool Update_Inhouse_AC_Engine_Info(string strUpdate, string s_EngineName)
		{
			bool result = false;
			string aErrorMsg = "";
			try
			{
				// update inhouse
				modAdminCommon.ADO_Transaction("BeginTrans");
				// set this to a function
				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = strUpdate;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();
				modAdminCommon.ADO_Transaction("CommitTrans");
				// update the record
				if (Save_Engine_Data(s_EngineName))
				{
					// function will accomdate for 15 instances of this happening
					// it will only load it one time
					modAdminCommon.Table_Action_Log("Aircraft_Model_Engine");
					result = true;
				}
			}
			catch (System.Exception excep)
			{
				aErrorMsg = excep.Message;
				modAdminCommon.ADO_Transaction("RollbackTrans");
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Update_Inhouse_AC_Engine_Info: {Information.Err().Number.ToString()} {aErrorMsg}");
				MessageBox.Show($"Error in Error_Update_Inhouse_AC_Engine_Info: {aErrorMsg}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

			return result;
		}

		public bool Update_Evo_AC_Engine_Info(string strUpdate, ref string strEvo_Update_status)
		{
			bool result = false;
			ADORecordSetHelper snpAppCfg = new ADORecordSetHelper();
			string aErrorMsg = "";
			try
			{
				// create a string to query the application configuration table
				string strQuery = "";
				strQuery = "";
				strQuery = "SELECT aconfig_evo_sql_server, aconfig_evo_sql_user, aconfig_evo_sql_password FROM Application_Configuration WITH (NOLOCK)";
				// create the variables for the connection to Evo
				// grab info from the Evo Configuration
				string Evo_IP_Address = "";
				Evo_IP_Address = "";
				string Evo_DB_User_ID = "";
				Evo_DB_User_ID = "";
				string Evo_DB_Password = "";
				Evo_DB_Password = "";
				string Evo_DB_Name = "";
				Evo_DB_Name = "jetnet_ra";
				DbConnection Evo_adoConnection = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateConnection();

				snpAppCfg.Open(strQuery, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpAppCfg.BOF && snpAppCfg.EOF))
				{
					// set the IP Address
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snpAppCfg["aconfig_evo_sql_server"]))
					{
						Evo_IP_Address = Convert.ToString(snpAppCfg["aconfig_evo_sql_server"]);
					}
					// set the User_ID
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snpAppCfg["aconfig_evo_sql_user"]))
					{
						Evo_DB_User_ID = Convert.ToString(snpAppCfg["aconfig_evo_sql_user"]);
					}
					// set the the Password
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snpAppCfg["aconfig_evo_sql_password"]))
					{
						Evo_DB_Password = Convert.ToString(snpAppCfg["aconfig_evo_sql_password"]);
					}
					if (Evo_IP_Address != "" && Evo_DB_User_ID != "" && Evo_DB_Password != "")
					{
						UserMessage("Saving Data To Evo Please Wait ....");
						// update Evo
						//UPGRADE_ISSUE: (2064) ADODB.Connection property Evo_adoConnection.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						Evo_adoConnection.setCursorLocation(CursorLocationEnum.adUseServer);
						//UPGRADE_ISSUE: (2064) ADODB.Connection property Evo_adoConnection.ConnectionTimeout was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						Evo_adoConnection.setConnectionTimeout(60);
						UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(Evo_adoConnection, 120);
						Evo_adoConnection.ConnectionString = $"Provider=SQLOLEDB;Data Source={Evo_IP_Address.Trim()};INITIAL CATALOG={Evo_DB_Name.Trim()};UID={Evo_DB_User_ID};PWD={Evo_DB_Password}";
						//UPGRADE_TODO: (7010) The connection string must be verified to fullfill the .NET data provider connection string requirements. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-7010
						Evo_adoConnection.Open();
						DbCommand TempCommand = null;
						TempCommand = Evo_adoConnection.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
						TempCommand.CommandText = strUpdate;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
						TempCommand.ExecuteNonQuery();
						UpgradeHelpers.DB.TransactionManager.DeEnlist(Evo_adoConnection);
						Evo_adoConnection.Close();
						result = true;
						UserMessage("Off");
					}
					else
					{
						strEvo_Update_status = "Evo Connection Info Is Blank";
					} // If Evo_IP_Address <> "" And Evo_DB_User_ID <> "" And Evo_DB_Password <> "" Then
				}
				else
				{
					strEvo_Update_status = "Unable to get Evo connection info";
				} // If Not (snpAppCfg.BOF And snpAppCfg.EOF) Then

				snpAppCfg.Close();
				snpAppCfg = null;
			}
			catch (System.Exception excep)
			{
				aErrorMsg = excep.Message;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Update_Evo_AC_Engine_Info: {Information.Err().Number.ToString()} {aErrorMsg}");
				MessageBox.Show($"Error in Update_Evo_AC_Engine_Info: {aErrorMsg}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

			return result;
		}

		//'''''''''''''''''''''''''''''''''''''''''''''''''''
		public bool Check_For_Locked_AC_Engines(ref int intLocked_AC, ADORecordSetHelper snp_AC_Engine_Check, string s_EngineName)
		{
			bool result = false;
			string aErrorMsg = "";
			try
			{
				// create a record set to hold the # of AC's locked
				ADORecordSetHelper rsLocked_ACs = new ADORecordSetHelper();
				// create a string to hold the query to get the # of AC's locked
				string strQuery_Locked_ACs = "";
				strQuery_Locked_ACs = "";
				// setup the query
				strQuery_Locked_ACs = "SELECT Count(*) As TotalLocked FROM Aircraft WITH (NOLOCK)";
				strQuery_Locked_ACs = $"{strQuery_Locked_ACs} WHERE(ac_amod_id = {Convert.ToString(snp_AC_Engine_Check["ac_amod_id"])})";
				strQuery_Locked_ACs = $"{strQuery_Locked_ACs} AND (ac_engine_name = '{s_PrevEngineName}')";
				strQuery_Locked_ACs = $"{strQuery_Locked_ACs} AND (ac_journ_id = 0)";
				strQuery_Locked_ACs = $"{strQuery_Locked_ACs} AND (EXISTS (SELECT NULL FROM Aircraft_Lock WITH (NOLOCK)";
				strQuery_Locked_ACs = $"{strQuery_Locked_ACs} WHERE (alock_ac_id = AC_ID)";
				strQuery_Locked_ACs = $"{strQuery_Locked_ACs} AND (alock_journ_id = ac_journ_id)";
				strQuery_Locked_ACs = $"{strQuery_Locked_ACs} )";
				strQuery_Locked_ACs = $"{strQuery_Locked_ACs} )";
				// open the record set
				rsLocked_ACs.Open(strQuery_Locked_ACs, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				// check to see if the AC are locked and if the Evo connection is allowed
				//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				if (!(rsLocked_ACs.BOF && rsLocked_ACs.EOF))
				{
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(rsLocked_ACs["TotalLocked"]))
					{
						intLocked_AC = Convert.ToInt32(rsLocked_ACs["TotalLocked"]);
					} // If Not IsNull(rsLocked_ACs("Count")) Then
				} // If Not (rsLocked_ACs.BOF And rsLocked_ACs.EOF) Then
				if (intLocked_AC > 0)
				{
					result = true;
				}
				rsLocked_ACs.Close();
				rsLocked_ACs = null;
			}
			catch (System.Exception excep)
			{
				aErrorMsg = excep.Message;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Check_For_Locked_AC_Engines: {Information.Err().Number.ToString()} {aErrorMsg}");
				MessageBox.Show($"Error in Check_For_Locked_AC_Engines: {aErrorMsg}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

			return result;
		}
		//'''''''''''''''''''''''''''''''''''''''''''''''''''
		public bool Check_Engine_Info()
		{
			bool result = false;
			string aErrorMsg = "";
			try
			{
				if (!cbo_amod_Airframe_Type_Code.Text.StartsWith("R", StringComparison.Ordinal))
				{
					if (Strings.Len(txt_ameng_engine_core.Text.Trim()) == 0)
					{
						MessageBox.Show("Engine Core Required", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						txt_ameng_engine_core.Focus();
						return result;
					}
				}

				if (Convert.ToInt32(Double.Parse($"0{txt_ameng_seq_no.Text}")) == 0)
				{
					MessageBox.Show("Numeric Sequence Required", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					txt_ameng_seq_no.Focus();
					return result;
				}

				if (Convert.ToInt32(Double.Parse(txt_ameng_mfr_CompID.Text)).ToString() != "0")
				{
					if (!modAdminCommon.Exist($"SELECT * FROM Company WHERE comp_id = '{Convert.ToInt32(Double.Parse(txt_ameng_mfr_CompID.Text)).ToString()}' AND comp_journ_id = 0"))
					{
						MessageBox.Show("Manufacturer Company ID NOT VALID", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						txt_ameng_mfr_CompID.Focus();
						return result;
					}
				}

				return true;
			}
			catch (System.Exception excep)
			{
				aErrorMsg = excep.Message;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Check_Engine_Info: {Information.Err().Number.ToString()} {aErrorMsg}");
				MessageBox.Show($"Error in Check_Engine_Info: {aErrorMsg}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
			return result;
		}




		private void cmd_Remove_Engine_Click(Object eventSender, EventArgs eventArgs)
		{

			Delete_Aircraft_Model_Engine();
			Select_Aircraft_Model();

		}

		//UPGRADE_NOTE: (7001) The following declaration (cmd_SaveMakeSortChanges_Click) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void cmd_SaveMakeSortChanges_Click() => Save_MakeSort_Grid();
		//

		//UPGRADE_NOTE: (7001) The following declaration (cmd_Up_Click) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void cmd_Up_Click() => Key_Feature_Move_Row("Up");//
		//

		private void cmd_Update_Click(Object eventSender, EventArgs eventArgs)
		{

			bool HyphenChanged = false;
			string strMake = "";
			string strModel = "";

			cmd_Update.Enabled = false; // added to make sure it wasnt double clicked- 5/6/24


			switch(RecordStat)
			{
				case "Add" : 
					 
					if (!Check_For_Aircraft_Model_Duplicate())
					{

						if (Validate_Aircraft_Model_Main())
						{

							strMake = ($"{txt_amod_make_name.Text} ").Trim();
							strModel = ($"{txt_amod_model_name.Text} ").Trim();

							Insert_Aircraft_Model();

							cbo_Model.Enabled = false;
							Fill_Aircraft_Model_List(0);
							cbo_Model.Enabled = true;

							RecordStat = "Update";
							pnl_Model_Top.Visible = true;
							SSTabHelper.SetSelectedIndex(tab_Aircraft_Model, 0);

							modCommon.SetComboBoxValue(cbo_Model, $"{strMake} / {strModel}");

						} // If Validate_Aircraft_Model_Main() = True Then

					}
					else
					{
						MessageBox.Show("DUPLICATE MAKE/MODEL/MODEL ABBREV", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					} 
					 
					break;
				case "Update" : 
					 
					if (Validate_Aircraft_Model_Main())
					{

						if (Valid_Specs_Data() && Valid_OpCosts_Data())
						{

							if (RememberHyphenFlag && chk_amod_hyphen_flag.CheckState == CheckState.Unchecked)
							{
								HyphenChanged = true;
							}
							else if (!RememberHyphenFlag && chk_amod_hyphen_flag.CheckState == CheckState.Checked)
							{ 
								HyphenChanged = true;
							}
							else
							{
								HyphenChanged = false;
							}

							grd_Aircraft.Visible = false;
							lbl_Message.Visible = true;
							lbl_Message.Text = "Saving Aircraft Data ...";
							lbl_Message.Refresh();

							Update_Aircraft_Model();

							Fill_Aircraft_Model_List(cbo_Model.SelectedIndex);

							pnl_Model_Top.Visible = true;
							grd_Aircraft.Visible = true;

						} // If Valid_Specs_Data() = True And Valid_OpCosts_Data() = True Then

					}  // If Validate_Aircraft_Model_Main() = True Then 
					 
					break;
			} // RecordStat


			cmd_Update.Enabled = true; // added to make sure it wasnt double clicked - 5/6/24

		} // cmd_Update_Click

		private void SetEngineModelFieldsEnabled(bool bValue)
		{

			txt_ameng_engine_prefix.Enabled = bValue;
			txt_ameng_engine_core.Enabled = bValue;
			txt_ameng_engine_suffix1.Enabled = bValue;
			txt_ameng_engine_suffix2.Enabled = bValue;
			txt_ameng_takeoff_power.Enabled = bValue;
			txt_ameng_max_continuous_power.Enabled = bValue;
			txt_ameng_mfr_CompID.Enabled = bValue;
			txt_ameng_mfr_name_short.Enabled = bValue;
			txt_ameng_mfr_name.Enabled = bValue;
			txt_amod_engine_thrust_lbs.Enabled = bValue;
			cbo_tbo_list.Enabled = bValue;
			txt_amod_engine_shaft.Enabled = bValue;
			txt_amod_engine_hsi.Enabled = bValue;
			chk_oncondtbox.Enabled = bValue;

		} // SetEngineModelFieldsEnabled

		private void cmdFindEngineModel_Click(Object eventSender, EventArgs eventArgs)
		{

			string strEMId = "";
			string strEMPrefix = "";
			string strEMCore = "";
			string strEMSuffix1 = "";
			string strEMSuffix2 = "";
			string strEMTakeOffPower = "";
			string strEMMaxConPower = "";
			string strEMMfrCompId = "";
			string strEMMfrAbbrev = "";
			string strEMMfrName = "";

			string strEMThrust = "";
			string strEMTBOHours = "";
			string strEMShaftHP = "";
			string strEMHSI = "";
			string strEMOnCond = "";

			//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			//VB.Global.Load(frm_EngineModel.DefInstance);

			string strEMName = modCommon.BuildEngineModelName(txt_ameng_engine_prefix.Text, txt_ameng_engine_core.Text, txt_ameng_engine_suffix1.Text, txt_ameng_engine_suffix2.Text);

			frm_EngineModel.DefInstance.Set_Engine_Model_Search_Name(strEMName);

			frm_EngineModel.DefInstance.Refresh_Engine_Model_Grid();

			frm_EngineModel.DefInstance.ShowDialog();

			frm_EngineModel.DefInstance.Return_Engine_Model_Information(ref strEMId, ref strEMName, ref strEMPrefix, ref strEMCore, ref strEMSuffix1, ref strEMSuffix2, ref strEMTakeOffPower, ref strEMMaxConPower, ref strEMMfrCompId, ref strEMMfrAbbrev, ref strEMMfrName, ref strEMThrust, ref strEMTBOHours, ref strEMShaftHP, ref strEMHSI, ref strEMOnCond);

			if (strEMId != "0")
			{

				lbl_specs[93].Text = $"Engine Model Id: {strEMId}";
				lbl_specs[93].Tag = strEMId;

				txt_ameng_engine_prefix.Text = strEMPrefix;
				txt_ameng_engine_core.Text = strEMCore;
				txt_ameng_engine_suffix1.Text = strEMSuffix1;
				txt_ameng_engine_suffix2.Text = strEMSuffix2;
				txt_ameng_takeoff_power.Text = strEMTakeOffPower;
				txt_ameng_max_continuous_power.Text = strEMMaxConPower;
				txt_ameng_mfr_CompID.Text = strEMMfrCompId;
				txt_ameng_mfr_name_short.Text = strEMMfrAbbrev;
				txt_ameng_mfr_name.Text = strEMMfrName;

				txt_amod_engine_thrust_lbs.Text = strEMThrust;
				modCommon.SetComboText(cbo_tbo_list, strEMTBOHours);
				txt_amod_engine_shaft.Text = strEMShaftHP;
				txt_amod_engine_hsi.Text = strEMHSI;

				modCommon.SetCheckBoxYesNo(chk_oncondtbox, strEMOnCond, CheckState.Unchecked);

				if (chk_oncondtbox.CheckState == CheckState.Checked)
				{
					cbo_tbo_list.Visible = false;
					lbl_specs[18].Visible = false;
				}
				else
				{
					cbo_tbo_list.Visible = true;
					lbl_specs[18].Visible = true;
				}

				SetEngineModelFieldsEnabled(false);

			} // If strEMId <> "0" Then

			frm_EngineModel.DefInstance.Close();

		} // cmdFindEngineModel_Click

		private void CMDModelMap_Click(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.CMDModelMap, eventSender);

			int homebase_amod_id = 0;
			int commercial_amod_id = 0;
			int J = 0;
			string Query = "";
			string make_mod_name = "";
			string make_mod_name_com = "";
			string home_serNbr_regNbr = "";
			ADORecordSetHelper aRS = new ADORecordSetHelper();
			int grdRow = grdModelMap.CurrentRowIndex;
			int RememberRow = 0;
			int nRememberGridRowCount = 0;
			lbl_spec[3].Text = " Loading Please Wait";
			lbl_spec[3].BackColor = Color.Red;
			lbl_spec[3].Refresh();
			int i = 0;
			int aInt = 0;
			if (grdRow > 0)
			{
				switch(Index)
				{
					case 0 :  //insert into grid and table 
						if (CMDModelMap[0].Text == "Save")
						{
							J = cmbHbaseModels.SelectedIndex;
							if (J > 0)
							{
								grdModelMap.CurrentColumnIndex = 0;
								commercial_amod_id = Convert.ToInt32(Double.Parse(grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].FormattedValue.ToString()));
								homebase_amod_id = cmbHbaseModels.GetItemData(J);
								make_mod_name = cmbHbaseModels.Text;
								Query = $"select * from Map_Model where mapmod_com_amod_id ={commercial_amod_id.ToString()} ";
								if (modAdminCommon.Exist(Query))
								{
									// get the mapmod_key
									aRS.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

									// update the record
									Query = $"Update Map_Model set mapmod_homebase_amod_id={homebase_amod_id.ToString()}, mapmod_com_amod_id ={commercial_amod_id.ToString()}, mapmod_model_name = '{make_mod_name}', mapmod_load_flag = 'D'  WHERE mapmod_key = {Convert.ToString(aRS["mapmod_key"])}";

									aRS.Close();
									aRS = null;

								}
								else
								{
									Query = "Insert Map_Model(mapmod_homebase_amod_id,mapmod_com_amod_id, mapmod_model_name, mapmod_load_flag) ";
									Query = $"{Query} Values({homebase_amod_id.ToString()},{commercial_amod_id.ToString()},'{make_mod_name}','D') ";
								}
								DbCommand TempCommand = null;
								TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
								UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
								TempCommand.CommandText = Query;
								//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
								//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
								TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
								UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
								TempCommand.ExecuteNonQuery();

								grdModelMap.CurrentColumnIndex = 1;
								grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].Value = homebase_amod_id;
								grdModelMap.CurrentColumnIndex = 4;
								grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].Value = cmbHbaseModels.GetListItem(J);
							}
							else
							{
								// check that the ac does not exist in homebase
								grdModelMap.CurrentColumnIndex = 2;
								if (!Check_Hombase_For_Model(grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].FormattedValue.ToString()))
								{
									grdModelMap.CurrentColumnIndex = 0;
									commercial_amod_id = Convert.ToInt32(Double.Parse(grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].FormattedValue.ToString()));
									homebase_amod_id = 0;
									grdModelMap.CurrentColumnIndex = 2;
									make_mod_name = "";
									Query = $"select * from Map_Model where mapmod_com_amod_id ={commercial_amod_id.ToString()} ";
									if (modAdminCommon.Exist(Query))
									{
										// get the mapmod_key
										//make_mod_name = grdModelMap.Text
										aRS.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

										// update the record
										Query = $"Update Map_Model set mapmod_homebase_amod_id={homebase_amod_id.ToString()}, mapmod_com_amod_id ={commercial_amod_id.ToString()}, mapmod_model_name = '{make_mod_name}', mapmod_load_flag = 'L' WHERE mapmod_key = {Convert.ToString(aRS["mapmod_key"])}";

										aRS.Close();
										aRS = null;

									}
									else
									{
										Query = "Insert Map_Model(mapmod_homebase_amod_id,mapmod_com_amod_id, mapmod_model_name, mapmod_load_flag) ";
										Query = $"{Query} Values({homebase_amod_id.ToString()},{commercial_amod_id.ToString()},'{make_mod_name}','L') ";
									}
									DbCommand TempCommand_2 = null;
									TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
									UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
									TempCommand_2.CommandText = Query;
									//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
									//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
									TempCommand_2.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
									UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
									TempCommand_2.ExecuteNonQuery();

									// ripple the changes to the AC mapping table
									// get the mapac_key ID's where the amod_id is equal to the commerical amod_id

									if (!Aircraft_Model_ToLoad_Aircraft(commercial_amod_id.ToString()))
									{
										MessageBox.Show("Error while updating Aircraft Mapping table", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
									}

									grdModelMap.CurrentColumnIndex = 1;
									grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].Value = homebase_amod_id;
									grdModelMap.CurrentColumnIndex = 4;
									grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].Value = "To Load";
								}
								else
								{
									MessageBox.Show("This AC Model cannot be set ''To Load'', a matching model is in Homebase", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
									grdModelMap.CurrentColumnIndex = 1;
									grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].Value = homebase_amod_id;
								}


							}
							frmodelMap.Visible = false;

						}
						else if (CMDModelMap[0].Text == "Save AC Map Model")
						{ 
							RememberRow = grdAircraftMap.CurrentRowIndex;
							nRememberGridRowCount = grdAircraftMap.RowsCount;
							CMDModelMap[0].Text = "Save";
						} 
						break;
					case 1 : 
						 
						if (CMDModelMap[1].Text == "View Aircraft Mapping (Homebase)")
						{
							// lbl_spec(3).Caption = " Loading Please Wait"
							//  lbl_spec(3).BackColor = vbRed
							grdModelMap.CurrentColumnIndex = 1;
							commercial_amod_id = Convert.ToInt32(Double.Parse(grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].FormattedValue.ToString()));
							grdModelMap.CurrentColumnIndex = 2;
							make_mod_name = grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].FormattedValue.ToString();
							lbl_spec[2].Text = grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].FormattedValue.ToString();
							i = 0;
							i = (make_mod_name.IndexOf('-') + 1);
							make_mod_name = make_mod_name.Substring(0, Math.Min(i - 1, make_mod_name.Length));
							grdModelMap.CurrentColumnIndex = 0;
							Fill_Commercial_Aircraft_Map(commercial_amod_id.ToString(), grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].FormattedValue.ToString(), make_mod_name, "Homebase");

							CMDModelMap[1].Text = "View Aircraft Mapping (Commerical)";
							CMDModelMap[1].Refresh();
						}
						else if (CMDModelMap[1].Text == "View Aircraft Mapping (Commerical)")
						{ 
							//lbl_spec(3).Caption = " Loading Please Wait"
							//lbl_spec(3).BackColor = vbRed
							grdModelMap.CurrentColumnIndex = 1;
							commercial_amod_id = Convert.ToInt32(Double.Parse(grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].FormattedValue.ToString()));
							grdModelMap.CurrentColumnIndex = 2;
							make_mod_name = grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].FormattedValue.ToString();
							lbl_spec[2].Text = grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].FormattedValue.ToString();
							aInt = 0;
							aInt = (make_mod_name.IndexOf('-') + 1);
							make_mod_name = make_mod_name.Substring(0, Math.Min(aInt - 1, make_mod_name.Length));
							grdModelMap.CurrentColumnIndex = 0;
							Fill_Commercial_Aircraft_Map(commercial_amod_id.ToString(), grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].FormattedValue.ToString(), make_mod_name, "Commerical");
							CMDModelMap[1].Text = "View Aircraft Mapping (Homebase)";
							CMDModelMap[1].Refresh();
						} 
						break;
					case 2 : 
						CMDModelMap[1].Text = "View Aircraft Mapping (Homebase)"; 
						CMDModelMap[1].Refresh(); 
						Fill_Commercial_Model_Map(); 
						CMDModelMap[0].Text = "Save"; 
						lbl_spec[1].Text = "Homebase Model List"; 
						frmodelMap.Visible = false; 
						break;
				}
				this.Cursor = CursorHelper.CursorDefault;
			}
			else
			{
				MessageBox.Show("no commercial models selected", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
			lbl_spec[3].Text = " Data Is Ready";
			lbl_spec[3].BackColor = Color.Lime;
			lbl_spec[3].Refresh();
		}

		private void cmdStop_Click(Object eventSender, EventArgs eventArgs) => ModelStopped = true;



		private void cmdTemp_Click(Object eventSender, EventArgs eventArgs)
		{

			int Counter = 0;
			ADORecordSetHelper snpModel = new ADORecordSetHelper();
			int RememberModel = 0;
			int SeqNO = 0;

			this.Cursor = Cursors.WaitCursor;

			string Query = "SELECT * ";
			Query = $"{Query}FROM Aircraft_Model_Key_Feature WITH(NOLOCK) ";
			Query = $"{Query}ORDER BY amfeat_amod_id";

			snpModel.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

			if (!(snpModel.BOF && snpModel.EOF))
			{
				snpModel.MoveLast();
				snpModel.MoveFirst();
				Counter = 1;
				RememberModel = Convert.ToInt32(Double.Parse(""));

				while(!snpModel.EOF)
				{
					modStatusBar.Update_Status_Bar(modAdminCommon.SB, $"Updating Model: {Counter.ToString()} of {snpModel.RecordCount.ToString()}", Color.Blue);

					if (RememberModel == StringsHelper.ToDoubleSafe(($"{Convert.ToString(snpModel["amfeat_amod_id"])}").Trim()))
					{
						SeqNO++;
					}
					else
					{
						SeqNO = 1;
					}
					RememberModel = Convert.ToInt32(Double.Parse(($"{Convert.ToString(snpModel["amfeat_amod_id"])}").Trim()));

					Query = "UPDATE Aircraft_Model_Key_Feature ";
					Query = $"{Query}SET amfeat_seq_no = {SeqNO.ToString()} ";
					Query = $"{Query}WHERE amfeat_feature_code = '{($"{Convert.ToString(snpModel["amfeat_feature_code"])}").Trim()}' ";
					Query = $"{Query}AND amfeat_amod_id = {($"{Convert.ToString(snpModel["amfeat_amod_id"])}").Trim()}";

					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();



					Query = "UPDATE Aircraft_Key_Feature ";
					Query = $"{Query}SET afeat_seq_no = {SeqNO.ToString()} ";
					Query = $"{Query}WHERE afeat_feature_code = '{($"{Convert.ToString(snpModel["amfeat_feature_code"])}").Trim()}' ";
					Query = $"{Query}AND afeat_journ_id = 0 ";
					Query = $"{Query}AND afeat_ac_id IN (";
					Query = $"{Query}SELECT ac_id FROM Aircraft WITH(NOLOCK) WHERE ac_amod_id = {($"{Convert.ToString(snpModel["amfeat_amod_id"])}").Trim()}";
					Query = $"{Query})";

					DbCommand TempCommand_2 = null;
					TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
					TempCommand_2.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand_2.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
					TempCommand_2.ExecuteNonQuery();




					Counter++;
					snpModel.MoveNext();
				};
			}

			modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
			this.Cursor = CursorHelper.CursorDefault;

		}



		private bool Key_Feature_Valid_For_Update()
		{
			bool result = false;
			string Query = "";
			ADORecordSetHelper snpKey = new ADORecordSetHelper();

			result = true;

			//MAKE SURE THAT THERE ARE NUMERIC VALUES IN THE SERIAL NUMBER FIELDS
			if (Double.Parse($"0{txtFeatStartSerNo.Text}") > Double.Parse($"0{txtFeatEndSerNo.Text}") && Double.Parse($"0{txtFeatEndSerNo.Text}") > 0)
			{
				result = false;
				MessageBox.Show("Invalid Serial Number Range", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				return result;
			}

			if (chk_Inactive_Feature_Code.CheckState == CheckState.Checked && KeyFeatureWasActive)
			{

				Query = "SELECT count(*) as KeyCount FROM Aircraft_Key_Feature WITH(NOLOCK) ";
				Query = $"{Query}WHERE afeat_journ_id = 0 ";
				grd_Keyfeature.CurrentColumnIndex = 1;
				Query = $"{Query}AND afeat_feature_code = '{($"{grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString()}").Trim()}' ";
				Query = $"{Query}and afeat_ac_id in (select distinct ac_id from Aircraft WITH(NOLOCK), Aircraft_Key_Feature ";
				Query = $"{Query}where (ac_id = afeat_ac_id and ac_journ_id = afeat_journ_id) ";
				Query = $"{Query}and ac_journ_id = 0 ";
				Query = $"{Query}and afeat_feature_code = '{($"{grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString()}").Trim()}' ";
				Query = $"{Query}and ac_amod_id = {Convert.ToString(snp_Model["amod_id"])}) ";
				snpKey.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
				if (!(snpKey.BOF && snpKey.EOF))
				{
					snpKey.MoveFirst();
					if (Convert.ToDouble(snpKey["KeyCount"]) > 0)
					{
						if (MessageBox.Show($"Feature Code {($"{grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString()}").Trim()} is used on {Convert.ToString(snpKey["KeyCount"])} aircraft.{Environment.NewLine}{Environment.NewLine}Are you sure you want to make this feature code inactive?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
						{
							result = false;
						}
						else
						{
							grd_Keyfeature.CurrentColumnIndex = 7;
							grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].Value = modAdminCommon.DateToday;
							grd_Keyfeature.CurrentColumnIndex = 8;
							grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].Value = "INACTIVE";
							for (int i = 1; i <= 9; i++)
							{
								grd_Keyfeature.CurrentColumnIndex = i - 1;
								grd_Keyfeature.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.ConfirmColor)));
							}
						}
					}
				}

				// CLOSE RECORSET
				if (snpKey != null)
				{
					if (snpKey.State == ConnectionState.Open)
					{ // Already Open Close It
						snpKey.Close();
					}
					snpKey = null;
				}
			}

			return result;
		}

		private void cmdUseage_Click(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.cmdUseage, eventSender);


			string strQuery1 = "";
			string strDelete1 = "";

			int lAModId = 0;
			int lAModUsageId = 0;
			string strAModUsageCode = "";

			if (txt_amod_id.Text.Trim() != "")
			{

				lAModId = Convert.ToInt32(Double.Parse(txt_amod_id.Text));


				switch(Index)
				{
					case 0 :  // Add 
						 
						pnl_Useage_Add.Visible = true; 
						 
						break;
					case 1 :  // Remove 
						 
						if (ListBoxHelper.GetSelectedIndex(UsageList) > -1)
						{

							lAModUsageId = UsageList.GetItemData(ListBoxHelper.GetSelectedIndex(UsageList));
							strAModUsageCode = ($"{UsageList.Text}").Trim().Substring(0, Math.Min(1, ($"{UsageList.Text}").Trim().Length));

							//------------------------------------------------------
							// Check To See If Any Aircraft Exist With This Code
							//------------------------------------------------------
							strQuery1 = "SELECT TOP 1 ac_id FROM Aircraft WITH (NOLOCK) ";
							strQuery1 = $"{strQuery1}WHERE (ac_amod_id = {lAModId.ToString()}) ";
							strQuery1 = $"{strQuery1}AND (ac_use_code = '{strAModUsageCode}')";

							if (modAdminCommon.Exist(strQuery1))
							{
								modAdminCommon.Record_Event("Aircraft Model", $"Model Usage Removed (Failed) Aircraft Exist With Usage Code: AModId:=[{lAModId.ToString()}]  Code:=[{strAModUsageCode}]", 0, 0, 0);
								MessageBox.Show("This Usage Code is being used on Aircraft, Cannot Remove", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
								return;
							}
							else
							{

								modAdminCommon.Record_Event("Aircraft Model", $"Model Usage Removed: AModId:=[{lAModId.ToString()}]  Code:=[{strAModUsageCode}]", 0, 0, 0);

								strDelete1 = "DELETE FROM Aircraft_Model_Useage ";
								strDelete1 = $"{strDelete1}WHERE (acmoduse_id= {lAModUsageId.ToString()}) ";
								strDelete1 = $"{strDelete1}AND (acmoduse_amod_id = {lAModId.ToString()}) ";

								UpgradeHelpers.DB.TransactionManager.Enlist(modAdminCommon.LOCAL_ADO_DB.BeginTransaction());
								DbCommand TempCommand = null;
								TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
								UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
								TempCommand.CommandText = strDelete1;
								//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
								//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
								TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
								UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
								TempCommand.ExecuteNonQuery();
								UpgradeHelpers.DB.TransactionManager.Commit(modAdminCommon.LOCAL_ADO_DB);

								Fill_Model_Usage_List();

							} // If Exist(strQuery1) Then

						}  // If UsageList.ListIndex > -1 Then 
						 
						break;
					case 2 :  // Save  (Is Add) 
						 
						if (cmbUsage.SelectedIndex > 0)
						{

							strAModUsageCode = ($"{cmbUsage.Text} ").Trim().Substring(0, Math.Min(1, ($"{cmbUsage.Text} ").Trim().Length));
							if (strAModUsageCode != "")
							{

								strQuery1 = "SELECT * FROM Aircraft_Model_Useage ";
								strQuery1 = $"{strQuery1}WHERE (acmoduse_amod_id = {lAModId.ToString()}) ";
								strQuery1 = $"{strQuery1}AND (acmoduse_use_code = '{strAModUsageCode}') ";

								if (!modAdminCommon.Exist(strQuery1))
								{

									modAdminCommon.Record_Event("Aircraft Model", $"Model Usage Added: AModId:=[{lAModId.ToString()}]  Code:=[{strAModUsageCode}]", 0, 0, 0);

									strQuery1 = "INSERT INTO Aircraft_Model_Useage (acmoduse_amod_id, acmoduse_use_code) ";
									strQuery1 = $"{strQuery1}VALUES({lAModId.ToString()}, '{strAModUsageCode}') ";

									UpgradeHelpers.DB.TransactionManager.Enlist(modAdminCommon.LOCAL_ADO_DB.BeginTransaction());
									DbCommand TempCommand_2 = null;
									TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
									UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
									TempCommand_2.CommandText = strQuery1;
									//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
									//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
									TempCommand_2.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
									UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
									TempCommand_2.ExecuteNonQuery();
									UpgradeHelpers.DB.TransactionManager.Commit(modAdminCommon.LOCAL_ADO_DB);

									Fill_Model_Usage_List();

									pnl_Useage_Add.Visible = false;

								}
								else
								{
									MessageBox.Show($"Usage Code ({($"{cmbUsage.Text} ").Trim()}) Already Exists", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
								} // If Exist(strQuery1) = False Then

							} // If strAModUsageCode <> "" Then

						}  // If cmbUsage.ListIndex > 0 Then 
						 
						break;
					case 3 :  // Cancel 
						 
						pnl_Useage_Add.Visible = false; 
						 
						break;
					case 4 :  // Refresh list 
						 
						Fill_Model_Usage_List(); 
						 
						break;
				} // Select Case Index

			} // If Trim(txt_amod_id.Text) <> "" Then

		} // cmdUseage_Click

		private void Form_Activated(Object eventSender, EventArgs eventArgs)
		{
			if (ActivateHelper.myActiveForm != eventSender)
			{
				ActivateHelper.myActiveForm = (Form) eventSender;

				bControlProductCodeMsg = false;
				NeedTransaction = false;

				if (modAdminCommon.gbl_bHomeClicked)
				{
					this.Close();
				}
				bUpdate = false;
				if (where_am_I == "AddAircraft")
				{
					Fill_Aircraft_Model_List(cbo_Model.SelectedIndex);
					cbo_Model.Refresh();
				}
			}
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
		private void Form_Load()
		{

			bIsFormLoad = true;

			bControlProductCodeMsg = false;
			bFilledEngineList = false;
			s_PrevEngineName = "";
			this.Cursor = Cursors.WaitCursor;
			Setup_Form();
			Check_Permission();
			Select_Aircraft_Model();

			modStatusBar.Clear_Status_Bar(modAdminCommon.SB);

			bIsFormLoad = false;


			check_if_limiting_initials();

		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{

			snp_AirframeType = null;
			snp_AircraftType = null;
			snp_AircraftEngine = null;
			snp_MasterFeature = null;
			snp_ModelAircraft = null;

			newfrm_AddAircraft = null;

		}

		private void grd_Aircraft_DoubleClick(Object eventSender, EventArgs eventArgs)
		{
			Select_Aircraft();
			where_am_I = "grd_Aircraft_DblClick";
		}

		private void grd_Keyfeature_Click(Object eventSender, EventArgs eventArgs)
		{

			int lngResult = 0;

			// TURN ON THE APPROPRIATE UP AND DOWN BUTTONS FOR MOVING
			// ELEMENTS IN THE GRID
			if (grd_Keyfeature.CurrentRowIndex > 1)
			{
				//UPGRADE_ISSUE: (207) An invalid structure was generated in this location, inside grd_Keyfeature_Click. Please check source code. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-207
				//cmd_button_array().Visible = True
				//UPGRADE_ISSUE: (207) An invalid structure was generated in this location, inside grd_Keyfeature_Click. Please check source code. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-207
				//cmd_button_array().Visible = True
			}
			else
			{
				//UPGRADE_ISSUE: (207) An invalid structure was generated in this location, inside grd_Keyfeature_Click. Please check source code. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-207
				//cmd_button_array().Visible = False
				//UPGRADE_ISSUE: (207) An invalid structure was generated in this location, inside grd_Keyfeature_Click. Please check source code. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-207
				//cmd_button_array().Visible = False
			}
			if (grd_Keyfeature.CurrentRowIndex == grd_Keyfeature.RowsCount - 1)
			{
				//UPGRADE_ISSUE: (207) An invalid structure was generated in this location, inside grd_Keyfeature_Click. Please check source code. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-207
				//cmd_button_array().Visible = False
			}
			else
			{
				//UPGRADE_ISSUE: (207) An invalid structure was generated in this location, inside grd_Keyfeature_Click. Please check source code. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-207
				//cmd_button_array().Visible = True
			}

			//UPGRADE_ISSUE: (207) An invalid structure was generated in this location, inside grd_Keyfeature_Click. Please check source code. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-207
			//cmd_button_array().Visible = True // save

			// DISABLE THE REMOVE BUTTON FOR STAFF WITHOUT PERMISSIONS
			if (Convert.ToString(modAdminCommon.snp_User["user_type"]) == "Research Manager" || Convert.ToString(modAdminCommon.snp_User["user_type"]) == "Administrator")
			{
				//  cmd_Remove_Feature.Visible = True
			}
			else
			{
				//UPGRADE_ISSUE: (207) An invalid structure was generated in this location, inside grd_Keyfeature_Click. Please check source code. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-207
				//cmd_button_array().Visible = False //remove
			}

			//UPGRADE_ISSUE: (207) An invalid structure was generated in this location, inside grd_Keyfeature_Click. Please check source code. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-207
			//cmd_button_array().Visible = True // cancel
			pnl_MasterKeyFeatures.Visible = true;
			Select_Aircraft_Model_Key_Feature();

			if (chkFeatCount.CheckState == CheckState.Checked)
			{

				Display_Key_Feature_Counts();

			}
			else
			{

				lblFeatureYes.Visible = false;
				lblFeatureNo.Visible = false;
				lblFeatureUnknown.Visible = false;

			}

			pnl_FeatureDisplay.Visible = true;
			grd_Keyfeature.CurrentColumnIndex = 0;
			grd_Keyfeature.ColSel = grd_Keyfeature.ColumnsCount - 1;

		}



		//UPGRADE_NOTE: (7001) The following declaration (lbl_Engine_Add_Mfr_Click) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void lbl_Engine_Add_Mfr_Click(int Index)
		//{
			//
		//}

		//UPGRADE_NOTE: (7001) The following declaration (lbl_Engine_Add_Prefix_Click) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void lbl_Engine_Add_Prefix_Click(int Index)
		//{
			//
		//}


		//UPGRADE_NOTE: (7001) The following declaration (lbl_Engine_Add_Suffix2_Click) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void lbl_Engine_Add_Suffix2_Click(int Index)
		//{
			//
		//}

		private void grd_MakeSort_Click(Object eventSender, EventArgs eventArgs)
		{
			int lngResult = 0;

			cmd_Make_Move1[0].Visible = grd_MakeSort.CurrentRowIndex > 1;
			cmd_Make_Move1[1].Visible = grd_MakeSort.CurrentRowIndex != grd_MakeSort.RowsCount - 1;
			if (grd_MakeSort.CurrentRowIndex == 0)
			{
				cmd_Make_Move1[1].Visible = false;
			}

			grd_MakeSort.CurrentColumnIndex = 0;
			grd_MakeSort.ColSel = grd_MakeSort.ColumnsCount - 1;
		}

		private void grdAircraftMap_DoubleClick(Object eventSender, EventArgs eventArgs)
		{
			int RememberRow = 0;
			int nRememberGridRowCount = 0;
			// DISPLAY PANEL ALMOST THE SAME AS THAT FOR MAPPING AIRCRAFT ON THE AIRCRAFT FORM
			// BUT SINCE WE KNOW THE MODEL WE CAN ACTUALLY INCLUDE A DROP DOWN OF ALL OF THE
			// REG#'S, AND SERIAL#'S FOR THE CURRENT MODEL FROM HOMEBASE
			// THAT HAVE NOT ALREADY BEEN MAPPED BY MAKING A LIST OF MAPPED ID'S
			// WHILE THE GRID DISPLAYS
			grdModelMap.CurrentColumnIndex = 2;
			lbl_spec[2].Text = grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].FormattedValue.ToString();
			lbl_spec[1].Text = "Homebase Model List";
			RememberRow = grdAircraftMap.CurrentRowIndex;
			nRememberGridRowCount = grdAircraftMap.RowsCount;
			string tempMapped_homebase_ac_list = "";
			if (Mapped_homebase_ac_list != "")
			{
				tempMapped_homebase_ac_list = Mapped_homebase_ac_list;
				// move the col to the ACID so we can get what the user selected
				grdAircraftMap.CurrentColumnIndex = 4;
				// remove the selected ACID from the string
				tempMapped_homebase_ac_list = StringsHelper.Replace(Mapped_homebase_ac_list, grdAircraftMap[grdAircraftMap.CurrentRowIndex, grdAircraftMap.CurrentColumnIndex].FormattedValue.ToString().Trim(), " ", 1, -1, CompareMethod.Binary);
				// remove any ", ," incase the ACID was in the middle of the string
				tempMapped_homebase_ac_list = StringsHelper.Replace(tempMapped_homebase_ac_list, ", ,", "", 1, -1, CompareMethod.Binary);
				// remove any " ,"
				tempMapped_homebase_ac_list = StringsHelper.Replace(tempMapped_homebase_ac_list, " ,", "", 1, -1, CompareMethod.Binary);
				// remove any ", "
				tempMapped_homebase_ac_list = StringsHelper.Replace(tempMapped_homebase_ac_list, ", ", "", 1, -1, CompareMethod.Binary);
				// repopulate the combobox with the list of avaiable AC's
				Fill_AircraftModel_List_Homebase(tempMapped_homebase_ac_list, grdAircraftMap[grdAircraftMap.CurrentRowIndex, grdAircraftMap.CurrentColumnIndex].FormattedValue.ToString().Trim(), grdModelMap.get_RowData(grdModelMap.CurrentRowIndex));
				// reset the label
				grdAircraftMap.CurrentColumnIndex = 1;
				lbl_spec[2].Text = $"{lbl_spec[2].Text}-{grdAircraftMap[grdAircraftMap.CurrentRowIndex, grdAircraftMap.CurrentColumnIndex].FormattedValue.ToString().Trim()}";
				grdAircraftMap.CurrentColumnIndex = 2;
				lbl_spec[2].Text = $"{lbl_spec[2].Text}-{grdAircraftMap[grdAircraftMap.CurrentRowIndex, grdAircraftMap.CurrentColumnIndex].FormattedValue.ToString().Trim()}";
				lbl_spec[1].Text = $"{lbl_spec[1].Text} Reg # / Serial #";
				// rest the save button text
				CMDModelMap[0].Text = "Save AC Map Model";
			}
			else
			{
				MessageBox.Show("No Mapped Homebase AC List", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
			grdAircraftMap.CurrentRowIndex = RememberRow;
			grdAircraftMap.RowSel = grdAircraftMap.CurrentRowIndex;
			grdAircraftMap.ColSel = 0;
		}


		private void grdModelMap_Click(Object eventSender, EventArgs eventArgs)
		{
			string make_mod_name = "";
			string commercial_amod_id = "";

			string selectedMakeMod = "";
			int i = 0;
			if (grdModelMap.CurrentRowIndex > 0)
			{
				grdAircraftMap.Visible = false;
				grdModelMap.CurrentColumnIndex = 2;
				lbl_spec[2].Text = grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].FormattedValue.ToString();
				selectedMakeMod = grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].FormattedValue.ToString(); //grdModelMap.BandData(grdModelMap.Row)
				grdModelMap.RowSel = grdModelMap.CurrentRowIndex;
				grdModelMap.CurrentColumnIndex = 1;
				grdModelMap.ColSel = 3;
				//grdModelMap.RowSel = grdModelMap.Row
				frmodelMap.Visible = true;
				lbl_spec[3].Text = " Loading Please Wait";
				lbl_spec[3].BackColor = Color.Red;
				lbl_spec[3].Refresh();
				// populate the combobox
				Fill_AircraftModel_List(0, selectedMakeMod);
				//''''''''''''''''''''''''''''''''''''''''''''''''''''
				// get the matching AC from Homebase
				//''''''''''''''''''''''''''''''''''''''''''''''''''''


				grdModelMap.CurrentColumnIndex = 1;
				commercial_amod_id = grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].FormattedValue.ToString();
				grdModelMap.CurrentColumnIndex = 2;
				make_mod_name = grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].FormattedValue.ToString();
				i = 0;
				i = (make_mod_name.IndexOf('-') + 1);
				make_mod_name = make_mod_name.Substring(0, Math.Min(i - 1, make_mod_name.Length));
				grdModelMap.CurrentColumnIndex = 0;
				//'''''''''''''''''''''''''''''''''''''''''''''''
				// call the fill based on what the text says
				//'''''''''''''''''''''''''''''''''''''''''''''''
				if (CMDModelMap[1].Text == "View Aircraft Mapping (Homebase)")
				{
					Fill_Commercial_Aircraft_Map(commercial_amod_id, grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].FormattedValue.ToString(), make_mod_name, "Homebase");
					CMDModelMap[1].Text = "View Aircraft Mapping (Commerical)";
					CMDModelMap[1].Refresh();
				}
				else if (CMDModelMap[1].Text == "View Aircraft Mapping (Commerical)")
				{ 
					Fill_Commercial_Aircraft_Map(commercial_amod_id, grdModelMap[grdModelMap.CurrentRowIndex, grdModelMap.CurrentColumnIndex].FormattedValue.ToString(), make_mod_name, "Commerical");
					CMDModelMap[1].Text = "View Aircraft Mapping (Homebase)";
					CMDModelMap[1].Refresh();
				}
				lbl_spec[3].Text = " Data Is Ready";
				lbl_spec[3].BackColor = Color.Lime;

				lbl_spec[3].Text = " Data Is Ready";
				lbl_spec[3].BackColor = Color.Lime;
				lbl_spec[3].Refresh();
			}

		}

		private void lbl_specs_Click(Object eventSender, EventArgs eventArgs)
		{
			bool Fill_lbl_specs_Error = false;
			int Index = Array.IndexOf(this.lbl_specs, eventSender);
			string Query = "";
			string cellcolor = "";
			int ACount = 0;
			string sEngineName = "";

			try
			{
				if (Index == 20)
				{

					Fill_lbl_specs_Error = true;
					this.Cursor = Cursors.WaitCursor;
					cmdStop.Visible = false;

					SSTabHelper.SetSelectedIndex(tab_Aircraft_Model, 0);
					grd_Aircraft.Visible = false;

					sEngineName = ($"{txt_ameng_engine_prefix.Text.Trim()}{txt_ameng_engine_core.Text.Trim()}{txt_ameng_engine_suffix1.Text.Trim()}{txt_ameng_engine_suffix2.Text.Trim()}").Substring(0, Math.Min(20, ($"{txt_ameng_engine_prefix.Text.Trim()}{txt_ameng_engine_core.Text.Trim()}{txt_ameng_engine_suffix1.Text.Trim()}{txt_ameng_engine_suffix2.Text.Trim()}").Length));

					ModelStopped = false;

					grd_Aircraft.Clear();
					grd_Aircraft.ColumnsCount = 8;
					grd_Aircraft.RowsCount = 1;

					grd_Aircraft.CurrentRowIndex = 0;
					grd_Aircraft.CurrentColumnIndex = 0;
					grd_Aircraft.SetColumnWidth(0, 67);
					grd_Aircraft[grd_Aircraft.CurrentRowIndex, grd_Aircraft.CurrentColumnIndex].Value = "Serial#";
					grd_Aircraft.CurrentColumnIndex = 1;
					grd_Aircraft.SetColumnWidth(1, 80);
					grd_Aircraft[grd_Aircraft.CurrentRowIndex, grd_Aircraft.CurrentColumnIndex].Value = "Registration#";
					grd_Aircraft.CurrentColumnIndex = 2;
					grd_Aircraft.SetColumnWidth(2, 33);
					grd_Aircraft[grd_Aircraft.CurrentRowIndex, grd_Aircraft.CurrentColumnIndex].Value = "Year";
					grd_Aircraft.CurrentColumnIndex = 3;
					grd_Aircraft.SetColumnWidth(3, 80);
					grd_Aircraft[grd_Aircraft.CurrentRowIndex, grd_Aircraft.CurrentColumnIndex].Value = "Last Verified";
					grd_Aircraft.CurrentColumnIndex = 4;
					grd_Aircraft.SetColumnWidth(4, 80);
					grd_Aircraft[grd_Aircraft.CurrentRowIndex, grd_Aircraft.CurrentColumnIndex].Value = "Next Verified";
					grd_Aircraft.CurrentColumnIndex = 5;
					grd_Aircraft.SetColumnWidth(5, 87);
					grd_Aircraft[grd_Aircraft.CurrentRowIndex, grd_Aircraft.CurrentColumnIndex].Value = "Status";



					ACount = 0;

					lbl_Message.Text = "Searching for Aircraft ...";

					Query = "SELECT ac_ser_no_full,ac_delivery,ac_asking_price,ac_id,ac_forsale_flag,";
					Query = $"{Query}ac_forsale_flag,ac_year,ac_reg_no,ac_asking,ac_status,ac_last_verified_date,ac_next_verified_date,ac_exclusive_flag,ac_lease_flag ";
					Query = $"{Query} FROM Aircraft WHERE ac_amod_id = {Convert.ToString(snp_Model["amod_id"])}";
					Query = $"{Query} and ac_engine_name_search = '{StringsHelper.Replace(sEngineName.Trim(), modGlobalVars.cHyphen, modGlobalVars.cEmptyString, 1, -1, CompareMethod.Binary)}' and ac_journ_id=0";
					Query = $"{Query} ORDER BY ac_ser_no_sort";

					snp_ModelAircraft = new ADORecordSetHelper();
					snp_ModelAircraft.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!(snp_ModelAircraft.BOF && snp_ModelAircraft.EOF))
					{

						lbl_Message.Text = "Filling Aircraft List ...";
						cmdStop.Visible = true;

						while(!snp_ModelAircraft.EOF)
						{
							Application.DoEvents();
							if (ModelStopped)
							{
								break;
							}
							if (Convert.ToString(snp_ModelAircraft["ac_forsale_flag"]) == "Y")
							{
								cellcolor = modAdminCommon.ForSaleColor;
							}
							else
							{
								cellcolor = modAdminCommon.NoColor;
							}
							grd_Aircraft.RowsCount++;
							grd_Aircraft.CurrentRowIndex++;
							ACount++;
							grd_Aircraft.CurrentColumnIndex = 0;
							grd_Aircraft.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
							grd_Aircraft[grd_Aircraft.CurrentRowIndex, grd_Aircraft.CurrentColumnIndex].Value = $" {($"{Convert.ToString(snp_ModelAircraft["ac_ser_no_full"])} ").Trim()}";
							grd_Aircraft.CurrentColumnIndex = 1;
							grd_Aircraft.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
							grd_Aircraft[grd_Aircraft.CurrentRowIndex, grd_Aircraft.CurrentColumnIndex].Value = $" {($"{Convert.ToString(snp_ModelAircraft["ac_reg_no"])} ").Trim()}";
							grd_Aircraft.CurrentColumnIndex = 2;
							grd_Aircraft.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
							grd_Aircraft[grd_Aircraft.CurrentRowIndex, grd_Aircraft.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_ModelAircraft["ac_year"])}").Trim();
							grd_Aircraft.CurrentColumnIndex = 3;
							grd_Aircraft.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
							grd_Aircraft[grd_Aircraft.CurrentRowIndex, grd_Aircraft.CurrentColumnIndex].Value = Convert.ToDateTime(snp_ModelAircraft["ac_last_verified_date"]).ToString("d");
							grd_Aircraft.CurrentColumnIndex = 4;
							grd_Aircraft.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
							grd_Aircraft[grd_Aircraft.CurrentRowIndex, grd_Aircraft.CurrentColumnIndex].Value = Convert.ToDateTime(snp_ModelAircraft["ac_next_verified_date"]).ToString("d");
							grd_Aircraft.CurrentColumnIndex = 5;
							grd_Aircraft.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
							grd_Aircraft[grd_Aircraft.CurrentRowIndex, grd_Aircraft.CurrentColumnIndex].Value = $" {($"{Convert.ToString(snp_ModelAircraft["ac_status"])} ").Trim()}";

							grd_Aircraft.CurrentColumnIndex = 6;
							grd_Aircraft.SetColumnWidth(grd_Aircraft.CurrentColumnIndex, 13);
							if (Convert.ToString(snp_ModelAircraft["ac_exclusive_flag"]) == "Y")
							{
								grd_Aircraft.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.ExclusiveColor)));
							}
							else
							{
								grd_Aircraft.CellBackColor = Color.White;
							}

							grd_Aircraft.CurrentColumnIndex = 7;
							grd_Aircraft.SetColumnWidth(grd_Aircraft.CurrentColumnIndex, 13);
							if (Convert.ToString(snp_ModelAircraft["ac_lease_flag"]) == "Y")
							{
								grd_Aircraft.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.LeaseColor)));
							}
							else
							{
								grd_Aircraft.CellBackColor = Color.White;
							}


							snp_ModelAircraft.MoveNext();
							txt_TotalAircraft.Text = StringsHelper.Format(ACount, "###,###");
						};

						grd_Aircraft.FixedRows = 1;
						grd_Aircraft.Visible = true;
						mnuDeleteModel.Available = false;

						Label6[11].Text = $"Engine: {sEngineName}";

					}
					else
					{

						lbl_Message.Text = "No Aircraft Found.";
						mnuDeleteModel.Available = true;

					}
					txt_TotalAircraft.Text = StringsHelper.Format(ACount, "###,###");
					this.Cursor = CursorHelper.CursorDefault;
					return;

				}
			}
			catch (Exception excep)
			{
				if (!Fill_lbl_specs_Error)
				{
					throw excep;
				}

				if (Fill_lbl_specs_Error)
				{

					//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
					MessageBox.Show($"Fill_lbl_specs_Error: {Information.Err().Number.ToString()} {excep.Message}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));

				}
			}

		}

		private void lst_MasterKeyFeature_SelectedIndexChanged(Object eventSender, EventArgs eventArgs) => Select_Master_Key_Feature();


		private void lst_Spec_Engines_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{

			ToolTipMain.SetToolTip(lst_Spec_Engines, lst_Spec_Engines.Text);
			EngineStat = "Update";
			Select_Aircraft_Engine();

		}

		private void lst_Spec_Engines_DoubleClick(Object eventSender, EventArgs eventArgs)
		{

			RecordStat = "Update";
			EngineStat = "Update";
			pnl_Aircraft_Model_Engine_Add.Visible = true;
			Select_Aircraft_Engine();

		}

		public void mnu_EditAdd_Click(Object eventSender, EventArgs eventArgs)
		{


			Clear_Aircraft_Model();

			txt_amod_icao.Text = ""; // added MSW - 8/12/22

			int tempForEndVar = SSTabHelper.GetTabCount(tab_Aircraft_Model) - 1;
			for (int iCnt1 = 0; iCnt1 <= tempForEndVar; iCnt1++)
			{
				if (iCnt1 != 7)
				{
					SSTabHelper.SetTabVisible(tab_Aircraft_Model, iCnt1, false);
				}
			}

			ZeroFill_Aircraft_Model_OpCosts();
			Clear_Aircraft_Model_Specs();
			Clear_Aircraft_Model_Maint();
			Clear_Aircraft_Admin();
			txt_amod_id.Enabled = true;
			txt_amod_id.BackColor = Color.White;
			txt_amod_make_name.Enabled = true;
			txt_amod_model_name.Enabled = true;
			txt_amod_model_abbrev.Enabled = true;
			txt_amod_make_abbrev.Enabled = true;
			pnl_Model_Top.Visible = false;

			mnuDeleteModel.Available = false;
			RecordStat = "Add";
			SSPanel1.Visible = true;
		}

		public void mnu_File_Close_Click(Object eventSender, EventArgs eventArgs)
		{
			// CHECK TO SEE IF THE USER MADE CHANGES TO THE KEY FEATURE GRID
			// IF THEY DID, SEE IF THEY WANT TO SAVE THEM BEFORE CLOSING
			DialogResult intPress = (DialogResult) 0;

			//UPGRADE_WARNING: (206) Untranslated statement in mnu_File_Close_Click. Please check source code. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-206
			this.Close();
		}

		public void Fill_Aircraft_Model_List(int setindex)
		{
			//******************************************************************************************
			try
			{
				string Query = "";
				int i = 0;

				i = 0;
				this.Cursor = Cursors.WaitCursor;
				cbo_Model.Items.Clear();

				snp_Model = new ADORecordSetHelper();
				Query = "SELECT * FROM Aircraft_Model";

				if (CmbResearchType.SelectedIndex > 0)
				{
					Query = $"{Query} WHERE amod_airframe_type_code ='{CmbResearchType.Text.Substring(0, Math.Min(1, CmbResearchType.Text.Length))}'";
				}

				Query = $"{Query} ORDER BY amod_make_name, amod_model_name ";
				snp_Model.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

				if (!(snp_Model.BOF && snp_Model.EOF))
				{
					snp_Model.MoveFirst();
					i++;

					while(!snp_Model.EOF)
					{
						cbo_Model.AddItem($"{Convert.ToString(snp_Model["amod_make_name"]).Trim()} / {Convert.ToString(snp_Model["amod_model_name"]).Trim()}");
						snp_Model.MoveNext();
						i++;
					};
					TotalModel = i - 1;
					txt_model_total.Text = TotalModel.ToString();

					if (setindex > 0)
					{
						cbo_Model.SelectedIndex = setindex;
					}
					else
					{
						cbo_Model.SelectedIndex = 0;
					}

				}
				scr_Models.Minimum = 1;
				scr_Models.Maximum = (i + scr_Models.LargeChange - 1);
				scr_Models.Value = 1;
				this.Cursor = CursorHelper.CursorDefault;
			}
			catch (System.Exception excep)
			{
				this.Cursor = CursorHelper.CursorDefault;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_Make_Model_List_Error: {Information.Err().Number.ToString()} {excep.Message}");
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
			}
		}
		public void Fill_AircraftModel_List_Homebase(string acIDs_NotIN, string ac_id, int amod_id)
		{
			//******************************************************************************************
			try
			{

				string Query = "";
				int i = 0;
				ADORecordSetHelper adoRs = new ADORecordSetHelper();
				string sSelectedItem = "";
				bool bValidAcID = false;
				bValidAcID = false;
				bool bolFoundMatch = false;
				int countMatch = 0;

				i = 0;
				this.Cursor = Cursors.WaitCursor;
				cmbHbaseModels.Items.Clear();

				//Set snp_Model = New ADODB.Recordset
				Query = "SELECT ac_id, ac_ser_no_full, ac_reg_no, amod_make_name, amod_model_name FROM Aircraft";
				Query = $"{Query} INNER JOIN Aircraft_Model ON amod_id = ac_amod_id";

				Query = $"{Query} WHERE ac_id NOT IN({acIDs_NotIN}) AND ac_amod_id ={amod_id.ToString()} AND ac_journ_id = 0";
				Query = $"{Query} ORDER BY ac_ser_no_full, ac_reg_no ";

				adoRs.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(adoRs.BOF && adoRs.EOF))
				{
					//cmbHbaseModels.Clear
					adoRs.MoveFirst();
					i++;
					cmbHbaseModels.AddItem("To Load");
					cmbHbaseModels.SetItemData(cmbHbaseModels.GetNewIndex(), 0);

					while(!adoRs.EOF)
					{
						cmbHbaseModels.AddItem($"{Convert.ToString(adoRs["amod_make_name"]).Trim()}-{Convert.ToString(adoRs["amod_model_name"]).Trim()}-{Convert.ToString(adoRs["ac_reg_no"]).Trim()}-{Convert.ToString(adoRs["ac_ser_no_full"]).Trim()}");
						cmbHbaseModels.SetItemData(cmbHbaseModels.GetNewIndex(), Convert.ToInt32(adoRs["ac_id"]));
						if (ac_id == Convert.ToString(adoRs["ac_id"]).Trim())
						{
							bolFoundMatch = true;
							countMatch = i;
						}
						adoRs.MoveNext();
						i++;
					};
					adoRs.Close();
					adoRs = null;
					TotalModel = i - 1;
					txt_model_total.Text = TotalModel.ToString();

					if (bolFoundMatch)
					{
						cmbHbaseModels.SelectedIndex = countMatch;
					}
					else
					{
						cmbHbaseModels.SelectedIndex = 0;
					}

				}
				else
				{
					MessageBox.Show($"No homebase matches found for ac_amod_id = {amod_id.ToString()}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}
				scr_Models.Minimum = 1;
				scr_Models.Maximum = (i + scr_Models.LargeChange - 1);
				scr_Models.Value = 1;
				this.Cursor = CursorHelper.CursorDefault;
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_MakeModel_List_Error: {Information.Err().Number.ToString()} {excep.Message}");
				this.Cursor = CursorHelper.CursorDefault;
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
			}

		}

		public void Fill_AircraftModel_List(int setindex, string selectMake_Mod)
		{
			//******************************************************************************************
			try
			{

				string Query = "";
				int i = 0;
				ADORecordSetHelper adoRs = new ADORecordSetHelper();
				string sSelectedItem = "";
				bool bValidAcID = false;
				bValidAcID = false;
				bool bolFoundMatch = false;
				int countMatch = 0;

				i = 0;
				this.Cursor = Cursors.WaitCursor;
				cmbHbaseModels.Items.Clear();

				// Set snp_Model = New ADODB.Recordset
				Query = "SELECT amod_id, amod_make_name, amod_model_name FROM Aircraft_Model ";

				if (CmbResearchType.SelectedIndex > 0)
				{
					Query = $"{Query} WHERE amod_airframe_type_code ='{CmbResearchType.Text.Substring(0, Math.Min(1, CmbResearchType.Text.Length))}'";
				}

				Query = $"{Query} ORDER BY amod_make_name, amod_model_name ";
				adoRs.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(adoRs.BOF && adoRs.EOF))
				{
					adoRs.MoveFirst();
					i++;
					cmbHbaseModels.AddItem("To Load");
					cmbHbaseModels.SetItemData(cmbHbaseModels.GetNewIndex(), 0);

					while(!adoRs.EOF)
					{
						cmbHbaseModels.AddItem($"{Convert.ToString(adoRs["amod_make_name"]).Trim()}-{Convert.ToString(adoRs["amod_model_name"]).Trim()}");
						cmbHbaseModels.SetItemData(cmbHbaseModels.GetNewIndex(), Convert.ToInt32(adoRs["amod_id"]));
						if (selectMake_Mod == ($"{Convert.ToString(adoRs["amod_make_name"]).Trim()}-{Convert.ToString(adoRs["amod_model_name"]).Trim()}"))
						{
							bolFoundMatch = true;
							countMatch = i;
						}
						adoRs.MoveNext();
						i++;
					};
					adoRs.Close();
					adoRs = null;
					TotalModel = i - 1;
					txt_model_total.Text = TotalModel.ToString();

					if (bolFoundMatch)
					{
						cmbHbaseModels.SelectedIndex = countMatch;
					}
					else
					{
						cmbHbaseModels.SelectedIndex = 0;
					}

				}

				scr_Models.Minimum = 1;
				scr_Models.Maximum = (i + scr_Models.LargeChange - 1);
				scr_Models.Value = 1;
				this.Cursor = CursorHelper.CursorDefault;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_MakeModel_List_Error: {Information.Err().Number.ToString()} {excep.Message}");
				this.Cursor = CursorHelper.CursorDefault;
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
			}

		}

		public bool Fill_Aircraft_Engine_List()
		{
			bool result = false;
			try
			{
				string Query = "";
				string s_temp = "";
				s_temp = "";
				TotalEngine = 0;

				lst_Spec_Engines.Enabled = false;
				lst_Spec_Engines.Items.Clear();

				if ((snp_Model.EOF && snp_Model.BOF))
				{
					return result;
				}

				Query = $"SELECT * FROM Aircraft_Model_Engine where ameng_amod_id = {Convert.ToString(snp_Model["amod_id"])}";
				Query = $"{Query} ORDER BY ameng_seq_no,ameng_engine_name";


				if (snp_AircraftEngine.State == ConnectionState.Open)
				{
					snp_AircraftEngine.Close();
				}
				else
				{
					snp_AircraftEngine = null;
					snp_AircraftEngine = new ADORecordSetHelper();
				}

				snp_AircraftEngine.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_AircraftEngine.EOF && snp_AircraftEngine.BOF))
				{


					while(!snp_AircraftEngine.EOF)
					{

						TotalEngine++;


						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snp_AircraftEngine["ameng_engine_name"]))
						{
							if (Convert.ToString(snp_AircraftEngine["ameng_engine_name"]).Trim() != "")
							{
								string tempRefParam = $"{Convert.ToString(snp_AircraftEngine["ameng_engine_name"]).Trim()}[{Convert.ToString(snp_AircraftEngine["ameng_engine_prefix"]).Trim()}.{Convert.ToString(snp_AircraftEngine["ameng_engine_core"]).Trim()}.{Convert.ToString(snp_AircraftEngine["ameng_engine_suffix1"]).Trim()}.{Convert.ToString(snp_AircraftEngine["ameng_engine_suffix2"]).Trim()}]";
								s_temp = modCommon.pf_PadString(30, ref tempRefParam);
							}
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snp_AircraftEngine["ameng_mfr_name"]))
						{
							if (Convert.ToString(snp_AircraftEngine["ameng_mfr_name"]).Trim() != "")
							{
								s_temp = $"{s_temp} {Convert.ToString(snp_AircraftEngine["ameng_mfr_name"]).Trim()}";
							}
						}

						if (Convert.ToString(snp_AircraftEngine["ameng_active_flag"]).ToUpper() == "N")
						{
							s_temp = $"{s_temp} ** Inactive **";
						}

						lst_Spec_Engines.AddItem(s_temp);

						s_temp = "";

						snp_AircraftEngine.MoveNext();

					};

					result = true;

					// reset the record pointer to the first record
					snp_AircraftEngine.MoveFirst();

				}

				this.Cursor = CursorHelper.CursorDefault;

				lst_Spec_Engines.Enabled = true;

				return result;
			}
			catch (System.Exception excep)
			{

				this.Cursor = CursorHelper.CursorDefault;
				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_Aircraft_Engine_List_Error: {Information.Err().Number.ToString()} {excep.Message} {excep.Source}");
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
				return result;
			}
		}

		public void Select_Aircraft_Model()
		{

			string errMsg = "";

			try
			{

				if (cbo_Model.Enabled)
				{

					errMsg = "Clear";
					Clear_Aircraft_Model();

					Clear_Aircraft_Model_OpCosts();
					Clear_Aircraft_List();
					Clear_Aircraft_Model_Specs();
					Clear_Aircraft_Model_Maint();
					Clear_Aircraft_Admin();
					SetEngineModelFieldsEnabled(true);

					bFilledEngineList = false;

					errMsg = "reposition 1";
					snp_Model.MoveFirst();

					errMsg = "reposition 2";
					int tempForEndVar = cbo_Model.SelectedIndex;
					for (int i = 1; i <= tempForEndVar; i++)
					{
						snp_Model.MoveNext();
					}

					errMsg = "display";
					Display_Aircraft_Model();
					Display_Aircraft_Model_Specifications();
					Display_Aircraft_Model_Maintenance();
					errMsg = "fill";

					Fill_Aircraft_Engine_List();

					Fill_Model_Usage_List();

					// added MSW - 5/2/19 -
					if (SSTabHelper.GetSelectedIndex(tab_Aircraft_Model) == 12)
					{
						fill_amod_journal_grid();
						fill_fuel_eventlog();
					}

					// Display_Aircraft_
					errMsg = "Calculate";

					Calculate_Bucket_Totals();
					ToolTipMain.SetToolTip(lst_Spec_Engines, "");

				} // If cbo_Model.Enabled = True Then
			}
			catch (System.Exception excep)
			{

				this.Cursor = CursorHelper.CursorDefault;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Get_Model_Error: {excep.Message} {Information.Err().Number.ToString()} {errMsg}");
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
			}

		} // Select_Aircraft_Model

		public void Clear_Aircraft_Model()
		{

			txt_amod_id.Text = "";
			txt_amod_make_name.Text = "";
			txt_amod_model_name.Text = "";
			txt_amod_model_abbrev.Text = "";
			txt_amod_make_abbrev.Text = "";

			//  txt_amod_ser_no_full = ""
			txt_amod_start_price.Text = "";
			txt_amod_end_price.Text = "";
			txt_amod_description.Text = "";

			// 1/23/2009 - By David D. Cruger
			// Added CompId and made these a control array
			txt_amod_manufacturer[0].Text = ""; // Manufacturer Name
			txt_amod_manufacturer[1].Text = ""; // Common Name
			txt_amod_manufacturer[2].Text = ""; // Comp Id

			txt_intel.Text = "";
			txt_amod_ser_no_prefix.Text = "";
			txt_amod_ser_no_start.Text = "";
			txt_amod_ser_no_end.Text = "";
			txt_amod_ser_no_suffix.Text = "";
			txt_amod_start_year.Text = "";
			txt_amod_end_year.Text = "";
			cbo_amod_type_code.SelectedIndex = -1;
			cbo_amod_class.SelectedIndex = -1;
			cboWeightClass.SelectedIndex = -1;
			cbo_amod_Airframe_Type_Code.SelectedIndex = -1;
			//cbo_Model.ListIndex = -1

		}



		public void Clear_Aircraft_List() => txt_TotalAircraft.Text = "";


		public void Clear_Aircraft_Model_OpCosts()
		{

			txt_amod_fuel_tot_cost.Text = "";
			txt_amod_fuel_gal_cost.Text = "";
			txt_amod_fuel_add_cost.Text = "";
			txt_amod_fuel_burn_rate.Text = "";
			txt_amod_maint_tot_cost.Text = "";
			txt_amod_maint_lab_cost.Text = "";
			txt_amod_maint_labor_man_hour_multiplier.Text = "";
			txt_amod_maint_parts_cost.Text = "";
			txt_amod_maint_parts_man_hour_multiplier.Text = "";
			txt_amod_engine_ovh_cost.Text = "";
			txt_amod_thrust_rev_ovh_cost.Text = "";
			txt_amod_misc_flight_cost.Text = "";
			txt_amod_land_park_cost.Text = "";
			txt_amod_crew_exp_cost.Text = "";
			txt_amod_supplies_cost.Text = "";
			txt_amod_tot_hour_direct_cost.Text = "";
			txt_amod_avg_block_speed.Text = "";
			txt_amod_tot_stat_mile_cost.Text = "";
			txt_amod_tot_crew_salary_cost.Text = "";
			//  txt_amod_tot_cpilot_salary_cost.Text = ""
			txt_amod_cpilot_salary_cost.Text = "";
			//   txt_amod_tot_crew_benefit_cost.Text = ""
			txt_amod_crew_benefit_cost.Text = "";
			txt_amod_hangar_cost.Text = "";
			txt_amod_insurance_cost.Text = "";
			txt_amod_hull_insurance_cost.Text = "";
			//txt_amod_admit_insurance_cost.Text = ""
			txt_amod_insurance_cost.Text = "";
			txt_amod_liability_insurance_cost.Text = "";
			txt_amod_tot_misc_ovh_cost.Text = "";
			txt_amod_misc_train_cost.Text = "";
			txt_amod_misc_modern_cost.Text = "";
			txt_amod_misc_naveq_cost.Text = "";
			// txt_amod_dprec_cost.Text = ""
			txt_amod_deprec_cost.Text = "";
			txt_amod_tot_fixed_cost.Text = "";
			txt_amod_tot_variable_cost.Text = "";
			txt_var_misc.Text = "";
			txt_amod_tot_fixed_cost2.Text = "";
			txt_amod_number_of_seats.Text = "";
			txt_amod_annual_miles.Text = "";
			txt_amod_annual_hours.Text = "";
			txt_amod_tot_direct_cost.Text = "";
			txt_amod_tot_df_annual_cost.Text = "";
			txt_amod_tot_df_hour_cost.Text = "";
			txt_amod_tot_df_statmile_cost.Text = "";
			txt_amod_tot_df_seat_cost.Text = "";
			txt_amod_tot_nd_annual_cost.Text = "";
			txt_amod_tot_nd_hour_cost.Text = "";
			txt_amod_tot_nd_statmile_cost.Text = "";
			txt_amod_tot_nd_seat_cost.Text = "";

		} // Clear_Aircraft_Model_OpCosts

		public void ZeroFill_Aircraft_Model_OpCosts()
		{

			txt_amod_fuel_tot_cost.Text = "0";
			txt_amod_fuel_gal_cost.Text = "0";
			txt_amod_fuel_add_cost.Text = "0";
			txt_amod_fuel_burn_rate.Text = "0";
			txt_amod_maint_tot_cost.Text = "0";
			txt_amod_maint_lab_cost.Text = "0";
			txt_amod_maint_labor_man_hour_multiplier.Text = "0.0";
			txt_amod_maint_parts_cost.Text = "0";
			txt_amod_maint_parts_man_hour_multiplier.Text = "0.0";
			txt_amod_engine_ovh_cost.Text = "0";
			txt_amod_thrust_rev_ovh_cost.Text = "0";
			txt_amod_misc_flight_cost.Text = "0";
			txt_amod_land_park_cost.Text = "0";
			txt_amod_crew_exp_cost.Text = "0";
			txt_amod_supplies_cost.Text = "0";
			txt_amod_tot_hour_direct_cost.Text = "0";
			txt_amod_avg_block_speed.Text = "0";
			txt_amod_tot_stat_mile_cost.Text = "0";
			txt_amod_tot_crew_salary_cost.Text = "0";
			txt_amod_cpilot_salary_cost.Text = "0";
			txt_amod_crew_benefit_cost.Text = "0";
			txt_amod_hangar_cost.Text = "0";
			txt_amod_insurance_cost.Text = "0";
			txt_amod_hull_insurance_cost.Text = "0";
			txt_amod_insurance_cost.Text = "0";
			txt_amod_liability_insurance_cost.Text = "0";
			txt_amod_tot_misc_ovh_cost.Text = "0";
			txt_amod_misc_train_cost.Text = "0";
			txt_amod_misc_modern_cost.Text = "0";
			txt_amod_misc_naveq_cost.Text = "0";
			txt_amod_deprec_cost.Text = "0";
			txt_amod_tot_fixed_cost.Text = "0";
			txt_amod_tot_fixed_cost2.Text = "0";
			txt_amod_tot_variable_cost.Text = "0";
			txt_var_misc.Text = "0";
			txt_amod_number_of_seats.Text = "0";
			txt_amod_annual_miles.Text = "0";
			txt_amod_annual_hours.Text = "0";
			txt_amod_tot_direct_cost.Text = "0";
			txt_amod_tot_df_annual_cost.Text = "0";
			txt_amod_tot_df_hour_cost.Text = "0";
			txt_amod_tot_df_statmile_cost.Text = "0";
			txt_amod_tot_df_seat_cost.Text = "0";
			txt_amod_tot_nd_annual_cost.Text = "0";
			txt_amod_tot_nd_hour_cost.Text = "0";
			txt_amod_tot_nd_statmile_cost.Text = "0";
			txt_amod_tot_nd_seat_cost.Text = "0";

		}

		public void Clear_Aircraft_Model_Specs()
		{

			lst_Spec_Engines.Items.Clear();
			txt_amod_number_of_engines.Text = "0";
			// txt_amod_engine_make = ""
			txt_amod_engine_thrust_lbs.Text = "0";
			txt_amod_prop_model_name.Text = "";
			txt_amod_prop_mfr_name.Text = "";
			//  txt_amod_engine_model = ""
			txt_amod_engine_thrust_lbs.Text = "0";
			txt_amod_engine_shaft.Text = "0";
			//txt_amod_engine_com_tbo_hrs = "0"
			cbo_tbo_list.Text = "0";
			txt_amod_engine_hsi.Text = "0";
			txt_amod_fuselage_length[0].Text = "0";
			txt_amod_fuselage_length[1].Text = "0";
			txt_amod_fuselage_length[2].Text = "0";
			txt_amod_fuselage_length[3].Text = "0";
			txt_amod_fuselage_length[4].Text = "0";
			txt_amod_fuselage_length[5].Text = "0";
			txt_amod_fuselage_length[6].Text = "0";

			txt_amod_fuselage_length[7].Text = ""; // FAA Model Id

			// 07/28/2017 - By David D. Cruger; Added
			txt_amod_fuselage_length[8].Text = "0"; // Cabin Volume
			txt_amod_fuselage_length[9].Text = "0"; // Baggage Volume

			txt_amod_fuselage_height.Text = "0";
			txt_amod_fuselage_wingspan.Text = "0";
			txt_amod_number_of_crew.Text = "0";
			txt_amod_number_of_passengers.Text = "0";
			txt_amod_pressure.Text = "0";
			txt_amod_max_ramp_weight.Text = "0";
			txt_amod_max_takeoff_weight.Text = "0";
			txt_amod_zero_fuel_weight.Text = "0";
			txt_amod_basic_op_weight.Text = "0";
			txt_amod_max_landing_weight.Text = "0";
			txt_amod_fuel_cap_std_weight.Text = "0";
			txt_amod_fuel_cap_std_gal.Text = "0";
			txt_amod_fuel_cap_opt_weight.Text = "0";
			txt_amod_fuel_cap_opt_gal.Text = "0";
			txt_amod_takeoff_ali.Text = "0";
			txt_amod_takeoff_500.Text = "0";
			txt_amod_field_length.Text = "0";
			txt_amod_max_range_miles.Text = "0";
			txt_amod_climb_normal_feet.Text = "0";
			txt_amod_ceiling_feet.Text = "0";
			txt_amod_number_of_props.Text = "0";
			txt_amod_prop_model_name.Text = "";
			txt_amod_prop_mfr_name.Text = "";
			txt_amod_prop_com_tbo_hrs.Text = "0";
			txt_amod_prop_shaft.Text = "0";
			txt_amod_prop_hsi.Text = "0";
			txt_amod_other_config_note.Text = "";
			txt_amod_climb_engout_feet.Text = "0";

			txt_amod_speed[0].Text = "0"; // Stall VS
			txt_amod_speed[1].Text = "0"; // Stall VSO
			txt_amod_speed[2].Text = "0"; // Cruis Speed
			txt_amod_speed[3].Text = "0"; // Max Speed ' Vmo(MaxOp) IAS

			// 07/28/2017 - By David D. Cruger; Added
			txt_amod_speed[4].Text = "0"; // V1 Takeoff Speed
			txt_amod_speed[5].Text = "0"; // VFE Max Flap Ext Speec
			txt_amod_speed[6].Text = "0"; // VLE Max Land Gear Ext Speed
			txt_amod_speed[7].Text = "0"; // Vne (MaxOp) IAS

			lbl_specs[93].Text = "Engine Model Id: 0";
			lbl_specs[93].Tag = "0";

			txt_ameng_mfr_name.Text = "";
			txt_ameng_engine_prefix.Text = "";
			txt_ameng_engine_core.Text = "";
			txt_ameng_mfr_CompID.Text = "0";
			txt_ameng_engine_suffix1.Text = "";
			txt_ameng_engine_suffix2.Text = "";

		}

		public void Clear_Aircraft_Model_Maint()
		{

			txt_amod_maint_note.Text = "";
			txt_amod_inspection_note.Text = "";

		}

		public void Display_Aircraft_Model()
		{


			txt_amod_id.Text = Convert.ToString(snp_Model["amod_id"]).Trim();
			txt_amod_id.Enabled = false;
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_faa_model_id"]))
			{
				txt_amod_fuselage_length[7].Text = ($"{Convert.ToString(snp_Model["amod_faa_model_id"])} ").Trim();
			}
			else
			{
				txt_amod_fuselage_length[7].Text = "";
			}
			txt_amod_make_name.Text = ($"{Convert.ToString(snp_Model["amod_make_name"])} ").Trim();
			//   txt_amod_make_name.Enabled = False
			txt_amod_model_name.Text = ($"{Convert.ToString(snp_Model["amod_model_name"])} ").Trim();
			txt_amod_model_abbrev.Text = ($"{Convert.ToString(snp_Model["amod_model_abbrev"])} ").Trim();
			txt_amod_make_abbrev.Text = ($"{Convert.ToString(snp_Model["amod_make_abbrev"])} ").Trim();
			//   txt_amod_model_name.Enabled = False

			// 1/23/2009 - By David D. Cruger
			// Added CompId and made these a control array
			txt_amod_manufacturer[0].Text = ($"{Convert.ToString(snp_Model["amod_manufacturer"])}").Trim();
			txt_amod_manufacturer[1].Text = ($"{Convert.ToString(snp_Model["amod_manufacturer_common_name"])}").Trim();
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_manufacturer_comp_id"]))
			{
				txt_amod_manufacturer[2].Text = Convert.ToString(snp_Model["amod_manufacturer_comp_id"]);
			}
			else
			{
				txt_amod_manufacturer[2].Text = "0";
			}

			//added MSW - 2/2/21
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_icao_code"]))
			{
				txt_amod_icao.Text = Convert.ToString(snp_Model["amod_icao_code"]);
			}
			else
			{
				txt_amod_icao.Text = "0";
			}


			txt_amod_description.Text = ($"{Convert.ToString(snp_Model["amod_description"])}").Trim();
			if (($"{Convert.ToString(snp_Model["amod_start_price"])}").Trim() != "")
			{
				txt_amod_start_price.Text = StringsHelper.Format(snp_Model["amod_start_price"], "###,###,##0");
				txt_amod_start_price.Tag = txt_amod_start_price.Text;
			}
			else
			{
				txt_amod_start_price.Text = "";
				txt_amod_start_price.Tag = txt_amod_start_price.Text;
			}
			if (($"{Convert.ToString(snp_Model["amod_end_price"])}").Trim() != "")
			{
				txt_amod_end_price.Text = StringsHelper.Format(snp_Model["amod_end_price"], "###,###,##0");
				txt_amod_end_price.Tag = txt_amod_end_price.Text;
			}
			else
			{
				txt_amod_end_price.Text = "";
				txt_amod_end_price.Tag = txt_amod_end_price.Text;
			}

			txt_amod_ser_no_prefix.Text = ($"{Convert.ToString(snp_Model["amod_ser_no_prefix"])}").Trim().ToUpper();
			txt_amod_ser_no_suffix.Text = ($"{Convert.ToString(snp_Model["amod_ser_no_suffix"])}").Trim().ToUpper();
			txt_amod_ser_no_start.Text = ($"{Convert.ToString(snp_Model["amod_ser_no_start"])}").Trim().ToUpper();
			txt_amod_ser_no_end.Text = ($"{Convert.ToString(snp_Model["amod_ser_no_end"])}").Trim().ToUpper();

			RememberPrefix = txt_amod_ser_no_prefix.Text;
			RememberSuffix = txt_amod_ser_no_suffix.Text;

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_internal_note"]))
			{
				txt_intel.Text = Convert.ToString(snp_Model["amod_internal_note"]).Trim().Substring(0, Math.Min(2000, Convert.ToString(snp_Model["amod_internal_note"]).Trim().Length));
			}
			else
			{
				txt_intel.Text = "";
			}

			//6/29/2001 rje start
			if (Convert.ToString(snp_Model["amod_serno_hyphen_flag"]) == "Y")
			{
				chk_amod_hyphen_flag.CheckState = CheckState.Checked;
				RememberHyphenFlag = true;
			}
			else
			{
				chk_amod_hyphen_flag.CheckState = CheckState.Unchecked;
				RememberHyphenFlag = false;
			}
			//6/29/2001 rje end

			Select_Aircraft_Type();
			Select_Aircraft_Class();
			modCommon.SetComboBoxValue(cboJIQSize, ($"{Convert.ToString(snp_Model["amod_jniq_size"])} ").Trim());
			Select_Aircraft_Weight_Class();
			Select_Body_Configuration();
			Select_Airframe_Type();

			if (Strings.Len(Convert.ToString(snp_Model["amod_start_year"]).Trim()) > 0)
			{
				txt_amod_start_year.Text = ($"{Convert.ToString(snp_Model["amod_start_year"])} ").Trim();
			}

			if (Strings.Len(Convert.ToString(snp_Model["amod_end_year"]).Trim()) > 0)
			{
				txt_amod_end_year.Text = ($"{Convert.ToString(snp_Model["amod_end_year"])} ").Trim();
			}

			display_model_product_Codes(snp_Model);

			tab_Aircraft_Model.Visible = true;
			int tempForEndVar = SSTabHelper.GetTabCount(tab_Aircraft_Model) - 1;
			for (int iCnt1 = 0; iCnt1 <= tempForEndVar; iCnt1++)
			{
				if (iCnt1 != 7)
				{
					SSTabHelper.SetTabVisible(tab_Aircraft_Model, iCnt1, true);
				}
				else if (modAdminCommon.gbl_User_ID.ToLower() == "mvit" || modAdminCommon.gbl_User_ID.ToLower() == "gwk" || modAdminCommon.gbl_User_ID.ToLower() == "pls" || modAdminCommon.gbl_User_ID.ToLower() == "kkf" || modAdminCommon.gbl_User_ID.ToLower() == "jas" || modAdminCommon.gbl_User_ID.ToLower() == "ms")
				{ 
					SSTabHelper.SetTabVisible(tab_Aircraft_Model, iCnt1, true); // so that if its 7 (admin) add back in
				}
				else
				{
					SSTabHelper.SetTabVisible(tab_Aircraft_Model, iCnt1, false);
				}
			}

			//   tab_Aircraft_Model.Tab = 0
			Key_Feature_Fill_Grid();

			Display_Aircraft_Model_Op_Costs();
			Display_Aircraft_Model_Specifications();
			Display_Aircraft_Model_Maintenance();
			Check_For_Model_Picture();
			Fill_Aircraft_Model_Aircraft_Grid();
			Display_Aircraft_Model_Administration();
			Fill_Aircraft_Model_Trend_List();
			Fill_Aircraft_Model_Wanted();

			if (Convert.ToString(modAdminCommon.snp_User["user_type"]) == "Research Manager")
			{
				if (grd_Aircraft.RowsCount == 1)
				{
					mnuDeleteModel.Available = true;
				}
			}

			//If InStr(1, LCase(LOCAL_ADO_DB), "helicopter") > 0 Then

			if (cbo_amod_Airframe_Type_Code.Text.StartsWith("R", StringComparison.Ordinal))
			{
				txt_amod_make_name.MaxLength = 20;
				txt_amod_model_name.MaxLength = 20;
				txt_amod_model_abbrev.MaxLength = 10;
				txt_amod_ser_no_prefix.MaxLength = 7;
				txt_amod_ser_no_start.MaxLength = 20;
				txt_amod_ser_no_end.MaxLength = 20;
				txt_amod_ser_no_suffix.MaxLength = 7;

				//pnl_Props.Visible = False
			}
			else
			{
				txt_amod_make_name.MaxLength = 20;
				txt_amod_model_name.MaxLength = 20;
				txt_amod_model_abbrev.MaxLength = 10;
				txt_amod_ser_no_prefix.MaxLength = 7;
				txt_amod_ser_no_start.MaxLength = 8;
				txt_amod_ser_no_end.MaxLength = 8;
				txt_amod_ser_no_suffix.MaxLength = 5;

				pnl_Props.Visible = true;
			}

		}

		private void display_model_product_Codes(ADORecordSetHelper in_modelRS)
		{

			bool bIsBusiness = false;
			bool bIsHelicopter = false;
			bool bIsCommercial = false;
			bool bIsRegional = false;
			bool bIsAirBP = false;
			bool bIsABI = false;

			// first turn off all check boxes
			int tempForEndVar = chk_amod_product.GetUpperBound(0);
			for (int X = 0; X <= tempForEndVar; X++)
			{
				chk_amod_product[X].Visible = false;
				chk_amod_product[X].Enabled = false;
				chk_amod_product[X].CheckState = CheckState.Unchecked;
			}

			if (in_modelRS != null)
			{

				if (in_modelRS.State == ConnectionState.Open)
				{

					if (!(in_modelRS.EOF && in_modelRS.BOF))
					{

						// bIsHelicopter and bIsBusiness are mutualy exclusive, can have only one or the other
						if (Convert.ToString(in_modelRS["amod_product_business_flag"]).ToUpper() == "Y")
						{
							bIsBusiness = true;
							bIsHelicopter = false;
						}

						if (Convert.ToString(in_modelRS["amod_product_helicopter_flag"]).ToUpper() == "Y" || Convert.ToString(in_modelRS["amod_airframe_type_code"]).ToUpper() == "R")
						{ // this will default any helicopter amod_product_helicopter_flag = 'Y'
							bIsHelicopter = true;
							bIsBusiness = false;
						}

						if (Convert.ToString(in_modelRS["amod_product_commercial_flag"]).ToUpper() == "Y")
						{
							bIsCommercial = true;
						}

						if (Convert.ToString(in_modelRS["amod_product_airbp_flag"]).ToUpper() == "Y")
						{
							bIsAirBP = true;
						}

						// special case if there is no product codes selected warn the user that
						// until a product code is selected the aircraft will not be transmitted

						if (!bIsBusiness && !bIsHelicopter && !bIsCommercial && !bIsAirBP && !bControlProductCodeMsg)
						{

							bControlProductCodeMsg = true; // make sure this only pops up once per form load.
							MessageBox.Show($"** NO MODEL PRODUCT CODE SELECTED **{Environment.NewLine}Plese Select a PRODUCT CODE before SAVING Aircraft MODEL", "NO PRODUCT CODE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

						}

						int tempForEndVar2 = chk_amod_product.GetUpperBound(0);
						for (int X = 0; X <= tempForEndVar2; X++)
						{


							switch((X))
							{
								case modGlobalVars.CHK_BUSINESS_IDX : 
									 
									chk_amod_product[X].Visible = true; 
									chk_amod_product[X].Enabled = true; 
									if (bIsBusiness)
									{
										chk_amod_product[X].CheckState = CheckState.Checked;
									} 
									 
									break;
								case modGlobalVars.CHK_HELICOPTER_IDX : 
									 
									chk_amod_product[X].Visible = true; 
									 
									if (!bIsBusiness)
									{
										chk_amod_product[X].Enabled = true;
									} 
									 
									if (bIsHelicopter && !bIsBusiness)
									{
										chk_amod_product[X].CheckState = CheckState.Checked;
									} 
									 
									break;
								case modGlobalVars.CHK_COMMERCIAL_IDX : 
									 
									chk_amod_product[X].Visible = true; 
									chk_amod_product[X].Enabled = true; 
									if (bIsCommercial)
									{
										chk_amod_product[X].CheckState = CheckState.Checked;
									} 
									 
									break;
								case modGlobalVars.CHK_AIRBP_IDX : 
									 
									chk_amod_product[X].Visible = true; 
									chk_amod_product[X].Enabled = true; 
									if (bIsAirBP)
									{
										chk_amod_product[X].CheckState = CheckState.Checked;
									} 
									 
									break;
								case modGlobalVars.CHK_ABI_IDX : 
									 
									chk_amod_product[X].Visible = true; 
									if (bIsABI)
									{
										chk_amod_product[X].CheckState = CheckState.Checked;
									} 
									 
									break;
								case modGlobalVars.CHK_REGIONAL_IDX : 
									 
									chk_amod_product[X].Visible = true; 
									if (bIsRegional)
									{
										chk_amod_product[X].CheckState = CheckState.Checked;
									} 
									 
									break;
								default:
									goto exit_for;
							}

						}
						exit_for:;

					}

				}

			}

		}

		public bool Check_For_Aircraft_Model_Duplicate()
		{
			bool result = false;
			string tmp = ""; //aey 3/23/05
			string errMsg = ""; //aey 4/13/05

			try
			{

				result = false;

				errMsg = "make-model list";
				if (!(snp_Model.BOF && snp_Model.EOF))
				{
					snp_Model.MoveFirst();

					while(!snp_Model.EOF)
					{
						if (Convert.ToString(snp_Model["amod_make_name"]).Trim() == txt_amod_make_name.Text.Trim() && Convert.ToString(snp_Model["amod_model_name"]).Trim() == txt_amod_model_name.Text.Trim())
						{
							return true;
						}

						snp_Model.MoveNext();
					};
				}

				//aey 3/23/05
				errMsg = "abbrev";
				if (($"{modCommon.DLookUp("amod_model_abbrev", "aircraft_model", $"amod_id <> {Convert.ToInt32(Conversion.Val(txt_amod_id.Text)).ToString()} and amod_model_abbrev ='{modAdminCommon.Fix_Quote(txt_amod_model_abbrev)}'")}").Trim() != "")
				{
					MessageBox.Show("Duplicate Model Abbreviation", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					result = true;
				}

				return result;
			}
			catch (System.Exception excep)
			{

				this.Cursor = CursorHelper.CursorDefault;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Aircraft_Model_Duplicate_Error: {errMsg} {excep.Message} {Information.Err().Number.ToString()}");
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
				return result;
			}
		}

		public void Setup_Form()
		{

			frame_Status.Height = 81;
			frame_Status.Left = 253;
			frame_Status.Top = 307;
			frame_Status.Width = 625;

			frame_Status.Visible = false;
			RecordStat = "Update";
			ResearchRefresh = false; //aey 6/17/05
			Fill_Research_Type();
			ResearchRefresh = true;

			Fill_Airframe_Type_List(); //aey 1/7/05
			Fill_Aircraft_Type_List();
			Fill_Aircraft_Class_List();
			Fill_Master_Key_Feature_List();

			Fill_CBO_DropDown();
			Fill_Aircraft_Model_List(0);

			Fill_Aircraft_Usage_List(); //aey 5/27/05

			Fill_IFR_Certification_List();
			Fill_Anti_Torque_List();

			Fill_Body_Config();

			Calculate_Bucket_Totals();

			modFillCompConControls.Fill_Aircraft_Model_JETNET_iQ_Size_Category_Combo_Box(cboJIQSize);

			SSTabHelper.SetSelectedIndex(tab_Aircraft_Model, 0);
			pnl_Model_Top.Visible = true;
			tab_Aircraft_Model.Visible = true;

			//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			// Initialize the ToolBar
			//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			ToolbarSetup();
			ToolbarButtonsSetup();

		}

		private void ToolbarSetup()
		{


			ToolStrip tbr = tbr_ToolBar;

			tbr.ImageList = mdi_ResearchAssistant.DefInstance.imgNormal;

			tbr.Items[1].ImageKey = "Home";
			tbr.Items[3].ImageKey = "Back";
			tbr.Items[5].ImageKey = "Save";
			tbr.Items[7].ImageKey = "Help";

			tbr.Items[1].Name = "Home";
			tbr.Items[3].Name = "Back";
			tbr.Items[5].Name = "Save";
			tbr.Items[7].Name = "Help";

			tbr.Items[1].ToolTipText = "Go to Main Menu";
			tbr.Items[3].ToolTipText = "Go to Previous Screen";
			tbr.Items[5].ToolTipText = "Save screen data";
			tbr.Items[7].ToolTipText = "Online Help";

		}

		public void mnuAddAircraft_Click(Object eventSender, EventArgs eventArgs)
		{
			where_am_I = "AddAircraft";
			newfrm_AddAircraft = frm_AddAircraft.CreateInstance();


			newfrm_AddAircraft.MFR_Comp_id = Convert.ToInt32(Double.Parse(txt_amod_manufacturer[2].Text));
			newfrm_AddAircraft.PassedModelID = Convert.ToInt32(Double.Parse(txt_amod_id.Text));
			newfrm_AddAircraft.Show();

		}

		public void mnuAttachPicture_Click(Object eventSender, EventArgs eventArgs)
		{

			string Query = "";

			//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.FileName was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			mdi_ResearchAssistant.DefInstance.CommonDialog1Open.FileName = "";
			//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.DialogTitle was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			mdi_ResearchAssistant.DefInstance.CommonDialog1Open.Title = "Attach Model Picture";
			//UPGRADE_WARNING: (2074) MSComDlg.CommonDialog property mdi_ResearchAssistant.CommonDialog1.Flags was upgraded to mdi_ResearchAssistant.CommonDialog1Open.ShowReadOnly which has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2074
			//UPGRADE_WARNING: (2074) FileOpenConstants STRING RESOURCE ["IDS-CONSTANT"] NOT FOUND FileOpenConstants.cdlOFNHideReadOnly was upgraded to OpenFileDialog.ShowReadOnly which has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2074
			mdi_ResearchAssistant.DefInstance.CommonDialog1Open.ShowReadOnly = false;
			//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.Filter was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			//UPGRADE_WARNING: (2081) Filter has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
			mdi_ResearchAssistant.DefInstance.CommonDialog1Open.Filter = "Image Files (*.jpg),(*.gif)|*.jpg;*.gif|All Files (*.*)|*.*";
			mdi_ResearchAssistant.DefInstance.CommonDialog1Open.ShowDialog();

			//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.FileName was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			if (mdi_ResearchAssistant.DefInstance.CommonDialog1Open.FileName != "")
			{

				//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.FileName was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				if (modCommon.AttachFile(mdi_ResearchAssistant.DefInstance.CommonDialog1Open.FileName, "Model", Convert.ToInt32(Double.Parse(txt_amod_id.Text)), 0, 0, 0, true))
				{
					Query = $"UPDATE Aircraft_Model SET amod_action_date = NULL, amod_picture_exists_flag = 'Y' WHERE amod_id = {Convert.ToString(snp_Model["amod_id"])}";
					//LOCAL_DB.Execute Query, dbSQLPassThrough
					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();

				}
				else
				{
					//UPGRADE_ISSUE: (2064) MSComDlg.CommonDialog property CommonDialog1.FileName was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					modAdminCommon.Report_Error($"AttachFile: FileName[{mdi_ResearchAssistant.DefInstance.CommonDialog1Open.FileName}] ");
				}
				cbo_Model_SelectionChangeCommitted(cbo_Model, new EventArgs());
			}

		}

		public void mnuEditSummaries_Click(Object eventSender, EventArgs eventArgs)
		{

			//  frm_MarketSummaries.Show

		}

		public void mnuHelp_Click(Object eventSender, EventArgs eventArgs)
		{

			//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			//VB.Global.Load(frm_WebReport.DefInstance);
			modCommon.CenterFormOnHomebaseMainForm(frm_WebReport.DefInstance);
			frm_WebReport.DefInstance.WhichReport = "MakeModel Help";
			frm_WebReport.DefInstance.Show();

		}

		public void ModelSpec_Click(Object eventSender, EventArgs eventArgs)
		{

			//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			//VB.Global.Load(frm_WebReport.DefInstance);
			modCommon.CenterFormOnHomebaseMainForm(frm_WebReport.DefInstance);
			frm_WebReport.DefInstance.WhichReport = "Aircraft Model";
			frm_WebReport.DefInstance.PassedModelID = Convert.ToInt32(Double.Parse(txt_amod_id.Text));
			frm_WebReport.DefInstance.Show();

		}

		private void tab_Aircraft_Model_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{


			int Ntab = SSTabHelper.GetSelectedIndex(tab_Aircraft_Model);

			if (txt_amod_id.Text.Trim() != "")
			{


				switch(Ntab)
				{
					case 0 :  // Aircraft List 
						 
						break;
					case 1 :  // Important Features 
						 
						break;
					case 2 :  // Market Summaries 
						 
						Fill_Aircraft_Model_Trend_List(); 
						 
						break;
					case 3 :  // Wanted 
						 
						break;
					case 4 :  // Operating Costs 
						 
						break;
					case 5 :  // Specifications 
						 
						break;
					case 6 :  // Maintenance 
						 
						break;
					case 7 :  // Administration 
						 
						break;
					case 8 :  // Usage 
						 
						//------------------------------------------------------------------ 
						// 05/13/2008 - By David D. Cruger 
						// Only A Research Mgr or Admin can add/remove Usage from Models 
						//------------------------------------------------------------------ 
						if (Convert.ToString(modAdminCommon.snp_User["user_type"]) == "Research Manager" || Convert.ToString(modAdminCommon.snp_User["user_type"]) == "Administrator")
						{
							cmdUseage[0].Enabled = true; // Add
							cmdUseage[1].Enabled = true; // Remove
						}
						else
						{
							cmdUseage[0].Enabled = false; // Add
							cmdUseage[1].Enabled = false; // Remove
						} 
						 
						break;
					case 9 :  // Make Sort 
						 
						Fill_Make_Sort_List(); 
						Fill_Make_Model_Sort_Grid(); 
						 
						break;
					case 10 :  // Model Map 
						 
						// Fill_Commercial_Model_Map 
						 
						break;
					case 12 : 
						 
						fill_amod_journal_grid(); 
						fill_fuel_eventlog(); 
						 
						break;
				} // Select Case Ntab

			} // If Trim(txt_amod_id.Text) <> "" Then

			tab_Aircraft_ModelPreviousTab = tab_Aircraft_Model.SelectedIndex;
		} // tab_Aircraft_Model_Click

		private void fill_amod_journal_grid()
		{

			// Function used to fill company journal list

			int nRememberTimeout = 0;
			try
			{

				string Query = "";
				Query = modGlobalVars.cEmptyString;
				string TempSubject = "";
				ADORecordSetHelper ado_tmpRS = null;
				ADORecordSetHelper ado_Journal = new ADORecordSetHelper();

				string tmpCompName = "";
				tmpCompName = "";
				string tmpContactName = "";
				tmpContactName = "";
				string tmpMakeModelName = "";
				tmpMakeModelName = "";
				string whereIstheError = "";
				whereIstheError = "";

				int lCnt1 = 0;
				string strJSubject = "";
				string NORMAL_TXT_BACKCOLOR = "";
				NORMAL_TXT_BACKCOLOR = ColorTranslator.ToOle(Color.White).ToString();
				string DISABLED_BACKCOLOR = "";
				DISABLED_BACKCOLOR = (0x8000000F).ToString();

				modSubscription.search_on("Getting Company Journal Entries....");

				grd_amod_journal.Visible = false;
				grd_amod_journal.Enabled = false;
				grd_amod_journal.Redraw = false;

				grd_amod_journal.Clear();
				grd_amod_journal.ColumnsCount = 7;
				grd_amod_journal.RowsCount = 2;

				grd_amod_journal.FixedRows = 1;
				grd_amod_journal.FixedColumns = 0;

				grd_amod_journal.CurrentRowIndex = 0;
				grd_amod_journal.CurrentColumnIndex = 0;
				grd_amod_journal.SetColumnWidth(grd_amod_journal.CurrentColumnIndex, 67);
				grd_amod_journal.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_amod_journal[grd_amod_journal.CurrentRowIndex, grd_amod_journal.CurrentColumnIndex].Value = "Date";

				grd_amod_journal.CurrentColumnIndex = 1;
				grd_amod_journal.SetColumnWidth(grd_amod_journal.CurrentColumnIndex, 127);
				grd_amod_journal.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_amod_journal[grd_amod_journal.CurrentRowIndex, grd_amod_journal.CurrentColumnIndex].Value = "User";

				grd_amod_journal.CurrentColumnIndex = 2;
				grd_amod_journal.SetColumnWidth(grd_amod_journal.CurrentColumnIndex, 267);
				grd_amod_journal.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_amod_journal.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
				grd_amod_journal[grd_amod_journal.CurrentRowIndex, grd_amod_journal.CurrentColumnIndex].Value = "Subject";

				grd_amod_journal.CurrentColumnIndex = 3;
				grd_amod_journal.SetColumnWidth(grd_amod_journal.CurrentColumnIndex, 433);
				grd_amod_journal.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_amod_journal[grd_amod_journal.CurrentRowIndex, grd_amod_journal.CurrentColumnIndex].Value = "Description";

				grd_amod_journal.CurrentColumnIndex = 4;
				grd_amod_journal.SetColumnWidth(grd_amod_journal.CurrentColumnIndex, 0);
				grd_amod_journal.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_amod_journal[grd_amod_journal.CurrentRowIndex, grd_amod_journal.CurrentColumnIndex].Value = "Customer Notes";

				grd_amod_journal.CurrentColumnIndex = 5;
				grd_amod_journal.SetColumnWidth(grd_amod_journal.CurrentColumnIndex, 0);
				grd_amod_journal.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_amod_journal[grd_amod_journal.CurrentRowIndex, grd_amod_journal.CurrentColumnIndex].Value = "Type";

				grd_amod_journal.CurrentColumnIndex = 6;
				grd_amod_journal.SetColumnWidth(grd_amod_journal.CurrentColumnIndex, 60);
				grd_amod_journal.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_amod_journal[grd_amod_journal.CurrentRowIndex, grd_amod_journal.CurrentColumnIndex].Value = "Journal ID";

				if (txt_amod_id.Text.Trim() != "")
				{

					Query = "SELECT J1.*, JC1.*, U1.user_first_name, U1.user_last_name ";

					//Query = Query & " FROM Journal WITH(NOLOCK), Journal_Category WITH(NOLOCK)"
					Query = $"{Query}FROM Journal AS J1 WITH (NOLOCK) ";
					Query = $"{Query}INNER JOIN Journal_Category AS JC1 WITH (NOLOCK) ON J1.journ_subcategory_code = JC1.jcat_subcategory_code ";
					Query = $"{Query}LEFT OUTER JOIN [User] AS U1 WITH (NOLOCK) ON J1.journ_user_id = U1.user_id ";
					Query = $"{Query}WHERE (J1.journ_id > 0) ";

					if (modAdminCommon.gbl_User_ID == "mvit" || modAdminCommon.gbl_User_ID == "dcr" || modAdminCommon.gbl_User_ID == "aja" || modAdminCommon.gbl_User_ID == "mah")
					{
					}
					else
					{
						Query = $"{Query}AND (JC1.jcat_subcategory_code <> 'SP') ";
					}

					Query = $"{Query}AND (J1.journ_amod_id = {txt_amod_id.Text}) ";
					Query = $"{Query}ORDER BY journ_date DESC ";

					nRememberTimeout = UpgradeHelpers.DB.DbConnectionHelper.GetCommandTimeOut(modAdminCommon.LOCAL_ADO_DB);
					UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(modAdminCommon.LOCAL_ADO_DB, 5000);
					//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseClient);
					//Set ado_Journal = LOCAL_ADO_DB.Execute(Query, , adCmdText)
					ado_Journal.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(ado_Journal.Fields) && !(ado_Journal.BOF && ado_Journal.EOF))
					{

						ado_Journal.ActiveConnection = null;

						grd_amod_journal.CurrentRowIndex = 1;

						lCnt1 = 0;

						while(!ado_Journal.EOF)
						{

							tmpCompName = modGlobalVars.cEmptyString;
							tmpContactName = modGlobalVars.cEmptyString;
							tmpMakeModelName = modGlobalVars.cEmptyString;

							//Date
							grd_amod_journal.CurrentColumnIndex = 0;
							grd_amod_journal.CellAlignment = DataGridViewContentAlignment.TopCenter;
							grd_amod_journal[grd_amod_journal.CurrentRowIndex, grd_amod_journal.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(ado_Journal["journ_date"]))
							{
								if (Information.IsDate(ado_Journal["journ_date"]) && Convert.ToString(ado_Journal["journ_date"]).Trim() != modGlobalVars.cEmptyString)
								{
									grd_amod_journal[grd_amod_journal.CurrentRowIndex, grd_amod_journal.CurrentColumnIndex].Value = Convert.ToDateTime(ado_Journal["journ_date"]).ToString("d");
								}
							}

							//User
							grd_amod_journal.CurrentColumnIndex = 1;
							grd_amod_journal.CellAlignment = DataGridViewContentAlignment.TopCenter;
							grd_amod_journal[grd_amod_journal.CurrentRowIndex, grd_amod_journal.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(ado_Journal["journ_user_id"]))
							{
								//        If Trim$(ado_Journal("journ_user_id").Value) <> cEmptyString Then
								//          grd_amod_journal.Text = Trim$(ado_Journal("journ_user_id").Value)
								//        End If
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(ado_Journal["user_first_name"]))
								{
									if (Convert.ToString(ado_Journal["user_first_name"]).Trim() != modGlobalVars.cEmptyString)
									{
										grd_amod_journal[grd_amod_journal.CurrentRowIndex, grd_amod_journal.CurrentColumnIndex].Value = $"{Convert.ToString(ado_Journal["user_first_name"]).Trim()} {Convert.ToString(ado_Journal["user_last_name"]).Trim()}";
									}
									else
									{
										if (Convert.ToString(ado_Journal["journ_user_id"]).Trim() != modGlobalVars.cEmptyString)
										{
											grd_amod_journal[grd_amod_journal.CurrentRowIndex, grd_amod_journal.CurrentColumnIndex].Value = Convert.ToString(ado_Journal["journ_user_id"]).Trim();
										}
										else
										{
											if (Convert.ToString(ado_Journal["journ_user_id"]).Trim() == "adm")
											{
												grd_amod_journal[grd_amod_journal.CurrentRowIndex, grd_amod_journal.CurrentColumnIndex].Value = "Admin";
											}
										}
									}
								}
								else
								{
									if (Convert.ToString(ado_Journal["journ_user_id"]).Trim() == "adm")
									{
										grd_amod_journal[grd_amod_journal.CurrentRowIndex, grd_amod_journal.CurrentColumnIndex].Value = "Admin";
									}
									else
									{
										if (Convert.ToString(ado_Journal["journ_user_id"]).Trim() != modGlobalVars.cEmptyString)
										{
											grd_amod_journal[grd_amod_journal.CurrentRowIndex, grd_amod_journal.CurrentColumnIndex].Value = Convert.ToString(ado_Journal["journ_user_id"]).Trim();
										}
									}
								}
							}

							// DISPLAY SUBJECT
							grd_amod_journal.CurrentColumnIndex = 2;
							grd_amod_journal.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
							grd_amod_journal[grd_amod_journal.CurrentRowIndex, grd_amod_journal.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
							TempSubject = modGlobalVars.cEmptyString;

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(ado_Journal["journ_subject"]))
							{
								if (Convert.ToString(ado_Journal["journ_subject"]).Trim() != modGlobalVars.cEmptyString)
								{
									TempSubject = $"{Convert.ToString(ado_Journal["journ_subject"]).Trim()} ";
								}
							}

							grd_amod_journal[grd_amod_journal.CurrentRowIndex, grd_amod_journal.CurrentColumnIndex].Value = TempSubject;




							// DISPLAY DESCRIPTION
							grd_amod_journal.CurrentColumnIndex = 3;
							grd_amod_journal.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
							grd_amod_journal[grd_amod_journal.CurrentRowIndex, grd_amod_journal.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(ado_Journal["journ_description"]))
							{
								if (Convert.ToString(ado_Journal["journ_description"]).Trim() != modGlobalVars.cEmptyString)
								{
									grd_amod_journal[grd_amod_journal.CurrentRowIndex, grd_amod_journal.CurrentColumnIndex].Value = ado_Journal["journ_description"];
								}
							}

							//Customer note
							if (($"{modGlobalVars.cEmptyString}{Convert.ToString(ado_Journal["journ_customer_note"])}").Trim() != modGlobalVars.cEmptyString)
							{
								grd_amod_journal.CurrentColumnIndex = 4;
								grd_amod_journal[grd_amod_journal.CurrentRowIndex, grd_amod_journal.CurrentColumnIndex].Value = "X";
								grd_amod_journal.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(NORMAL_TXT_BACKCOLOR))); //white
								grd_amod_journal.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
							}
							else if (($"{modGlobalVars.cEmptyString}{Convert.ToString(ado_Journal["journ_subcategory_code"])}").Trim().ToUpper() == "RN")
							{ 
								//grey out customer note if not applicable.
								grd_amod_journal.CurrentColumnIndex = 4;
								grd_amod_journal.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(DISABLED_BACKCOLOR))); //grey
								grd_amod_journal.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
							}
							else
							{
								grd_amod_journal.CurrentColumnIndex = 4;
								grd_amod_journal.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(NORMAL_TXT_BACKCOLOR))); //white
								grd_amod_journal.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
							}

							grd_amod_journal.CurrentColumnIndex = 4;
							grd_amod_journal.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
							grd_amod_journal[grd_amod_journal.CurrentRowIndex, grd_amod_journal.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
							grd_amod_journal.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(NORMAL_TXT_BACKCOLOR))); //white
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(ado_Journal["journ_customer_note"]))
							{
								if (Convert.ToString(ado_Journal["journ_customer_note"]).Trim() != modGlobalVars.cEmptyString)
								{
									grd_amod_journal[grd_amod_journal.CurrentRowIndex, grd_amod_journal.CurrentColumnIndex].Value = "X";
								}
								else
								{

									//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
									if (!Convert.IsDBNull(ado_Journal["journ_subcategory_code"]))
									{
										if (Convert.ToString(ado_Journal["journ_subcategory_code"]).Trim() != modGlobalVars.cEmptyString)
										{
											if (Convert.ToString(ado_Journal["journ_subcategory_code"]).Trim().ToUpper() == "RN")
											{
												grd_amod_journal.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(DISABLED_BACKCOLOR))); //grey
											}
										}
									}

								}
							}

							//Type
							grd_amod_journal.CurrentColumnIndex = 5;
							grd_amod_journal.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
							grd_amod_journal[grd_amod_journal.CurrentRowIndex, grd_amod_journal.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(ado_Journal["journ_subcategory_code"]))
							{
								if (Convert.ToString(ado_Journal["journ_subcategory_code"]).Trim() != modGlobalVars.cEmptyString)
								{
									grd_amod_journal[grd_amod_journal.CurrentRowIndex, grd_amod_journal.CurrentColumnIndex].Value = Convert.ToString(ado_Journal["journ_subcategory_code"]).Trim();
								}
							}

							//Journal ID
							grd_amod_journal.CurrentColumnIndex = 6;
							grd_amod_journal.CellAlignment = DataGridViewContentAlignment.MiddleRight;
							grd_amod_journal[grd_amod_journal.CurrentRowIndex, grd_amod_journal.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(ado_Journal["journ_id"]))
							{
								if (Convert.ToInt32(ado_Journal["journ_id"]) > 0)
								{
									grd_amod_journal[grd_amod_journal.CurrentRowIndex, grd_amod_journal.CurrentColumnIndex].Value = Convert.ToString(ado_Journal["journ_id"]).Trim();
								}
							}

							grd_amod_journal.set_RowData(grd_amod_journal.CurrentRowIndex, Convert.ToInt32(ado_Journal["journ_id"]));

							grd_amod_journal.RowsCount++;
							grd_amod_journal.CurrentRowIndex++;

							lCnt1++;
							if (lCnt1 == 13)
							{
								grd_amod_journal.Visible = true;
								grd_amod_journal.Enabled = true;
								grd_amod_journal.Redraw = true;
								Application.DoEvents();
								grd_amod_journal.Enabled = false;
								grd_amod_journal.Redraw = false;
							}

							ado_Journal.MoveNext();

						};

						grd_amod_journal.RowsCount--;
						grd_amod_journal.CurrentRowIndex = 1;


						UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(modAdminCommon.LOCAL_ADO_DB, nRememberTimeout);
						//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseServer);

						grd_amod_journal.Enabled = true;

					}
					else
					{

						grd_amod_journal.CurrentRowIndex = 1;
						grd_amod_journal.CurrentColumnIndex = 2;
						grd_amod_journal[grd_amod_journal.CurrentRowIndex, grd_amod_journal.CurrentColumnIndex].Value = "No Journal Entries Found";
						//  lbl_comp(JOURNAL_COUNT_INDEX).Caption = cEmptyString
						grd_amod_journal.Enabled = false;

					} // If Not IsNull(ado_Journal) And Not (ado_Journal.BOF And ado_Journal.EOF) Then

					ado_Journal.Close();

				} // If Trim(txt_amod_id.Text) <> "" Then

				grd_amod_journal.Visible = true;
				grd_amod_journal.Redraw = true;

				modSubscription.search_off();

				ado_Journal = null;
				ado_tmpRS = null;
			}
			catch
			{

				UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(modAdminCommon.LOCAL_ADO_DB, nRememberTimeout);
				//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseServer);

				modSubscription.search_off();
			}

		}
		private void fill_fuel_eventlog()
		{

			// Function used to fill company journal list

			int nRememberTimeout = 0;
			try
			{

				string Query = "";
				Query = modGlobalVars.cEmptyString;
				string TempSubject = "";
				ADORecordSetHelper ado_tmpRS = null;
				ADORecordSetHelper ado_Journal = new ADORecordSetHelper();

				string tmpCompName = "";
				tmpCompName = "";
				string tmpContactName = "";
				tmpContactName = "";
				string tmpMakeModelName = "";
				tmpMakeModelName = "";
				string whereIstheError = "";
				whereIstheError = "";

				int lCnt1 = 0;
				string strJSubject = "";
				string NORMAL_TXT_BACKCOLOR = "";
				NORMAL_TXT_BACKCOLOR = ColorTranslator.ToOle(Color.White).ToString();
				string DISABLED_BACKCOLOR = "";
				DISABLED_BACKCOLOR = (0x8000000F).ToString();

				modSubscription.search_on("Getting Company Journal Entries....");

				grd_eventlog.Visible = false;
				grd_eventlog.Enabled = false;
				grd_eventlog.Redraw = false;

				grd_eventlog.Clear();
				grd_eventlog.ColumnsCount = 3;
				grd_eventlog.RowsCount = 2;

				grd_eventlog.FixedRows = 1;
				grd_eventlog.FixedColumns = 0;

				grd_eventlog.CurrentRowIndex = 0;
				grd_eventlog.CurrentColumnIndex = 0;
				grd_eventlog.SetColumnWidth(grd_eventlog.CurrentColumnIndex, 67);
				grd_eventlog.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_eventlog[grd_eventlog.CurrentRowIndex, grd_eventlog.CurrentColumnIndex].Value = "Date";

				grd_eventlog.CurrentColumnIndex = 1;
				grd_eventlog.SetColumnWidth(grd_eventlog.CurrentColumnIndex, 127);
				grd_eventlog.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_eventlog[grd_eventlog.CurrentRowIndex, grd_eventlog.CurrentColumnIndex].Value = "User";

				grd_eventlog.CurrentColumnIndex = 2;
				grd_eventlog.SetColumnWidth(grd_eventlog.CurrentColumnIndex, 400);
				grd_eventlog.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_eventlog.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
				grd_eventlog[grd_eventlog.CurrentRowIndex, grd_eventlog.CurrentColumnIndex].Value = "Message";



				Query = "select top 50 evtl_date, user_first_name, user_last_name, evtl_message, evtl_id from EventLog with (NOLOCK) ";
				Query = $"{Query} inner join [User] with (NOLOCK) on user_id = evtl_user_id  ";
				Query = $"{Query} where evtl_type = 'Aircraft Model' ";
				Query = $"{Query} order by evtl_id desc  ";

				nRememberTimeout = UpgradeHelpers.DB.DbConnectionHelper.GetCommandTimeOut(modAdminCommon.LOCAL_ADO_DB);
				UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(modAdminCommon.LOCAL_ADO_DB, 5000);
				//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseClient);
				//Set ado_Journal = LOCAL_ADO_DB.Execute(Query, , adCmdText)
				ado_Journal.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(ado_Journal.Fields) && !(ado_Journal.BOF && ado_Journal.EOF))
				{

					ado_Journal.ActiveConnection = null;

					grd_eventlog.CurrentRowIndex = 1;

					lCnt1 = 0;

					while(!ado_Journal.EOF)
					{

						tmpCompName = modGlobalVars.cEmptyString;
						tmpContactName = modGlobalVars.cEmptyString;
						tmpMakeModelName = modGlobalVars.cEmptyString;

						//Date
						grd_eventlog.CurrentColumnIndex = 0;
						grd_eventlog.CellAlignment = DataGridViewContentAlignment.TopCenter;
						grd_eventlog[grd_eventlog.CurrentRowIndex, grd_eventlog.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_Journal["evtl_date"]))
						{
							if (Information.IsDate(ado_Journal["evtl_date"]) && Convert.ToString(ado_Journal["evtl_date"]).Trim() != modGlobalVars.cEmptyString)
							{
								grd_eventlog[grd_eventlog.CurrentRowIndex, grd_eventlog.CurrentColumnIndex].Value = Convert.ToDateTime(ado_Journal["evtl_date"]).ToString("d");
							}
						}

						// DISPLAY DESCRIPTION
						grd_eventlog.CurrentColumnIndex = 1;
						grd_eventlog.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						grd_eventlog[grd_eventlog.CurrentRowIndex, grd_eventlog.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_Journal["user_first_name"]))
						{
							if (Convert.ToString(ado_Journal["user_first_name"]).Trim() != modGlobalVars.cEmptyString)
							{
								grd_eventlog[grd_eventlog.CurrentRowIndex, grd_eventlog.CurrentColumnIndex].Value = ado_Journal["user_first_name"];
							}
						}

						grd_eventlog[grd_eventlog.CurrentRowIndex, grd_eventlog.CurrentColumnIndex].Value = $"{grd_eventlog[grd_eventlog.CurrentRowIndex, grd_eventlog.CurrentColumnIndex].FormattedValue.ToString()} ";

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_Journal["user_last_name"]))
						{
							if (Convert.ToString(ado_Journal["user_last_name"]).Trim() != modGlobalVars.cEmptyString)
							{
								grd_eventlog[grd_eventlog.CurrentRowIndex, grd_eventlog.CurrentColumnIndex].Value = $"{grd_eventlog[grd_eventlog.CurrentRowIndex, grd_eventlog.CurrentColumnIndex].FormattedValue.ToString()}{Convert.ToString(ado_Journal["user_last_name"])}";
							}
						}


						grd_eventlog.CurrentColumnIndex = 2;
						grd_eventlog.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						grd_eventlog[grd_eventlog.CurrentRowIndex, grd_eventlog.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_Journal["evtl_message"]))
						{
							if (Convert.ToString(ado_Journal["evtl_message"]).Trim() != modGlobalVars.cEmptyString)
							{
								grd_eventlog[grd_eventlog.CurrentRowIndex, grd_eventlog.CurrentColumnIndex].Value = ado_Journal["evtl_message"];
							}
						}

						grd_eventlog.set_RowData(grd_eventlog.CurrentRowIndex, Convert.ToInt32(ado_Journal["evtl_id"]));

						grd_eventlog.RowsCount++;
						grd_eventlog.CurrentRowIndex++;

						lCnt1++;
						if (lCnt1 == 13)
						{
							grd_eventlog.Visible = true;
							grd_eventlog.Enabled = true;
							grd_eventlog.Redraw = true;
							Application.DoEvents();
							grd_eventlog.Enabled = false;
							grd_eventlog.Redraw = false;
						}

						ado_Journal.MoveNext();

					};

					grd_eventlog.RowsCount--;
					grd_eventlog.CurrentRowIndex = 1;


					UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(modAdminCommon.LOCAL_ADO_DB, nRememberTimeout);
					//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseServer);

					grd_eventlog.Enabled = true;

				}
				else
				{

					grd_eventlog.CurrentRowIndex = 1;
					grd_eventlog.CurrentColumnIndex = 2;
					grd_eventlog[grd_eventlog.CurrentRowIndex, grd_eventlog.CurrentColumnIndex].Value = "No Journal Entries Found";
					//  lbl_comp(JOURNAL_COUNT_INDEX).Caption = cEmptyString
					grd_eventlog.Enabled = false;

				} // If Not IsNull(ado_Journal) And Not (ado_Journal.BOF And ado_Journal.EOF) Then

				ado_Journal.Close();


				grd_eventlog.Visible = true;
				grd_eventlog.Redraw = true;

				modSubscription.search_off();

				ado_Journal = null;
				ado_tmpRS = null;
			}
			catch
			{

				UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(modAdminCommon.LOCAL_ADO_DB, nRememberTimeout);
				//UPGRADE_ISSUE: (2064) ADODB.Connection property LOCAL_ADO_DB.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				modAdminCommon.LOCAL_ADO_DB.setCursorLocation(CursorLocationEnum.adUseServer);

				modSubscription.search_off();
			}

		}




		private void tbr_ToolBar_ButtonClick(Object eventSender, EventArgs eventArgs)
		{
			ToolStripItem Button = (ToolStripItem) eventSender;
			//******************************************************************************************
			//******************************************************************************************

			try
			{
				DialogResult intPress = (DialogResult) 0;

				switch(Button.Name)
				{
					case "Home" : 
						//Call MsgBox("This is the Aircraft Screen", vbApplicationModal + vbInformation, "Aircraft") 
						modAdminCommon.gbl_bHomeClicked = true; 
						this.Close(); 
						 
						break;
					case "Back" : 
						// CHECK TO SEE IF THE USER MADE CHANGES TO THE KEY FEATURE GRID 
						// IF THEY DID, SEE IF THEY WANT TO SAVE THEM BEFORE CLOSING 
						//UPGRADE_WARNING: (206) Untranslated statement in tbr_ToolBar_ButtonClick. Please check source code. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-206 
						this.Close(); 
						 
						break;
					case "Save" : 
						MessageBox.Show("This is nothing to Save", "Aircraft", MessageBoxButtons.OK, MessageBoxIcon.Information); 
						 
						break;
					case "Help" : 
						MessageBox.Show("Help is forthcoming", "Aircraft", MessageBoxButtons.OK, MessageBoxIcon.Information); 
						 
						break;
					default:
						//RESP = MsgBox("ToolBar Error", vbInformation, "Unrecognized Toolbar Reference") 
						break;
				}
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"tbr_ToolBar_Error: AC_Model {Button.Name} {excep.Message}");
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
				return;
			}

		}

		private void ToolbarButtonsSetup()
		{


			ToolStrip tbr = tbr_ToolBar;

			tbr.Items[1].Visible = true;
			tbr.Items[3].Visible = true;
			tbr.Items[7].Visible = true;

			tbr.Items[1].Enabled = true;
			tbr.Items[3].Enabled = true;
			tbr.Items[7].Enabled = true;

		}

		public void Fill_Aircraft_Type_List()
		{



			cbo_amod_type_code.Items.Clear();
			string Query = "SELECT * FROM Aircraft_Type WITH(NOLOCK) ORDER BY atype_code ";

			snp_AircraftType = new ADORecordSetHelper();
			snp_AircraftType.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

			if (!(snp_AircraftType.BOF && snp_AircraftType.EOF))
			{


				while(!snp_AircraftType.EOF)
				{
					cbo_amod_type_code.AddItem(Convert.ToString(snp_AircraftType["atype_code"]).Trim());
					snp_AircraftType.MoveNext();
				};
			}
			this.Cursor = CursorHelper.CursorDefault;
			cbo_amod_type_code.SelectedIndex = 0;
			return;

			this.Cursor = CursorHelper.CursorDefault;
			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
			modAdminCommon.Report_Error($"fFill_Make_Model_List_Error: {Information.Err().Number.ToString()} {Information.Err().Description}");
			modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
			return;

		}

		public void Fill_Aircraft_Class_List()
		{
			try
			{

				string Query = "";

				cbo_amod_class.Items.Clear();
				Query = "SELECT * FROM Aircraft_Class WITH(NOLOCK) ORDER BY aclass_code ";

				snp_AircraftClass = new ADORecordSetHelper();
				snp_AircraftClass.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_AircraftClass.BOF && snp_AircraftClass.EOF))
				{


					while(!snp_AircraftClass.EOF)
					{

						cbo_amod_class.AddItem($"{Convert.ToString(snp_AircraftClass["aclass_code"]).Trim()}");
						snp_AircraftClass.MoveNext();
					};
				}

				this.Cursor = CursorHelper.CursorDefault;
			}
			catch (System.Exception excep)
			{

				this.Cursor = CursorHelper.CursorDefault;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_Aircraft_Class_List_Error: {Information.Err().Number.ToString()} {excep.Message}");
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
				return;
			}

		}

		public void Update_Aircraft_Model_Record_With_Aircraft_Model_Engine_Lowest_Seq(int lAModId)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strUpdate1 = "";

			if (lAModId > 0)
			{

				strQuery1 = "SELECT TOP 1 EM1.* ";
				strQuery1 = $"{strQuery1}FROM Aircraft_Model_Engine AS AME1 WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}INNER JOIN Engine_Models AS EM1 WITH (NOLOCK) ON EM1.em_id = AME1.ameng_engine_model_id ";
				strQuery1 = $"{strQuery1}WHERE (AME1.ameng_amod_id = {lAModId.ToString()}) ";
				strQuery1 = $"{strQuery1}ORDER BY AME1.ameng_seq_no ";

				rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					strUpdate1 = "UPDATE Aircraft_Model ";

					strUpdate1 = $"{strUpdate1}SET ";
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(rstRec1["em_engine_thrust_lbs"]))
					{
						strUpdate1 = $"{strUpdate1}amod_engine_thrust_lbs = {Convert.ToString(rstRec1["em_engine_thrust_lbs"])}, ";
					}
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(rstRec1["em_engine_shaft"]))
					{
						strUpdate1 = $"{strUpdate1}amod_engine_shaft = {Convert.ToString(rstRec1["em_engine_shaft"])}, ";
					}
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(rstRec1["em_engine_com_tbo_hrs"]))
					{
						strUpdate1 = $"{strUpdate1}amod_engine_com_tbo_hrs = {Convert.ToString(rstRec1["em_engine_com_tbo_hrs"])}, ";
					}
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(rstRec1["em_engine_hsi"]))
					{
						strUpdate1 = $"{strUpdate1}amod_engine_hsi = {Convert.ToString(rstRec1["em_engine_hsi"])}, ";
					}

					strUpdate1 = $"{strUpdate1}amod_on_condition_flag = '{($"{Convert.ToString(rstRec1["em_on_condition_flag"])} ").Trim()}', ";
					strUpdate1 = $"{strUpdate1}amod_action_date = '1/1/1900' ";

					strUpdate1 = $"{strUpdate1}WHERE (amod_id = {lAModId.ToString()}) ";

					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = strUpdate1;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();

				} // If rstRec1.BOF = False And rstRec1.EOF = False Then

				rstRec1.Close();

			} // If lAModId > 0 Then

		} // Update_Aircraft_Model_Record_With_Aircraft_Model_Engine_Lowest_Seq

		public void Update_Aircraft_Model()
		{

			try
			{
				StringBuilder Query = new StringBuilder();
				DialogResult Ans = (DialogResult) 0;
				string amod_customer_flag = "";
				bool bAtLeastOneProduct = false;
				bAtLeastOneProduct = false;
				int lAModId = 0;
				string strAModId = "";
				string strType = "";
				string strName = "";
				string strJIQSize = "";
				int iPos1 = 0;

				lAModId = Convert.ToInt32(snp_Model["amod_id"]);
				strAModId = lAModId.ToString();

				Query = new StringBuilder("UPDATE Aircraft_Model SET ");
				Query.Append($"amod_description='{modAdminCommon.Fix_Quote(txt_amod_description).Trim()}', ");
				Query.Append($"amod_class_code='{modAdminCommon.Fix_Quote(cbo_amod_class).Trim()}', ");
				Query.Append($"amod_weight_class='{cboWeightClass.Text.Substring(0, Math.Min(1, cboWeightClass.Text.Length))}', ");
				Query.Append($"amod_type_code='{modAdminCommon.Fix_Quote(cbo_amod_type_code).Trim()}', ");
				Query.Append($"amod_airframe_type_code='{cbo_amod_Airframe_Type_Code.Text.Substring(0, Math.Min(1, cbo_amod_Airframe_Type_Code.Text.Length))}', ");

				Query.Append($"amod_start_year='{txt_amod_start_year.Text.Trim()}', ");
				Query.Append($"amod_end_year='{txt_amod_end_year.Text.Trim()}', ");
				if (txt_amod_start_price.Text.Trim() != "")
				{
					Query.Append($"amod_start_price = {Double.Parse(txt_amod_start_price.Text).ToString()}, ");
				}
				else
				{
					Query.Append("amod_start_price = NULL, ");
				}
				if (txt_amod_end_price.Text.Trim() != "")
				{
					Query.Append($"amod_end_price = {Double.Parse(txt_amod_end_price.Text).ToString()}, ");
				}
				else
				{
					Query.Append("amod_end_price = NULL, ");
				}

				Query.Append($"amod_ser_no_prefix='{txt_amod_ser_no_prefix.Text.Trim()}', ");
				Query.Append($"amod_ser_no_start='{txt_amod_ser_no_start.Text.Trim()}', ");
				Query.Append($"amod_ser_no_end='{txt_amod_ser_no_end.Text.Trim()}', ");
				Query.Append($"amod_ser_no_suffix='{txt_amod_ser_no_suffix.Text.Trim()}', ");

				// 1/23/2009 - By David D. Cruger
				// Added CompId and made into a control array
				Query.Append($"amod_manufacturer='{modAdminCommon.Fix_Quote(txt_amod_manufacturer[0].Text).Trim()}', ");
				Query.Append($"amod_manufacturer_common_name='{modAdminCommon.Fix_Quote(txt_amod_manufacturer[1].Text).Trim()} ', ");

				if (($"{txt_amod_manufacturer[2].Text} ").Trim() != "")
				{
					Query.Append($"amod_manufacturer_comp_id = {($"{txt_amod_manufacturer[2].Text} ").Trim()}, ");
				}
				else
				{
					Query.Append("amod_manufacturer_comp_id = 0, ");
				}

				Query.Append($"amod_make_name = '{modAdminCommon.Fix_Quote(txt_amod_make_name.Text).Trim()}', ");
				Query.Append($"amod_model_name = '{modAdminCommon.Fix_Quote(txt_amod_model_name.Text).Trim()}', ");
				Query.Append($"amod_model_abbrev = '{modAdminCommon.Fix_Quote(txt_amod_model_abbrev.Text).Trim()}', ");
				Query.Append($"amod_make_abbrev = '{modAdminCommon.Fix_Quote(txt_amod_make_abbrev.Text).Trim()}', ");

				if (chk_amod_hyphen_flag.CheckState == CheckState.Checked)
				{
					Query.Append("amod_serno_hyphen_flag='Y', ");
				}
				else
				{
					Query.Append("amod_serno_hyphen_flag='N', ");
				}

				Query.Append($"amod_upd_user_id = '{modAdminCommon.gbl_User_ID}', ");
				Query.Append("amod_upd_date = GetDate(), ");

				//SPECS TAB UPDATE
				Query.Append($"amod_engine_thrust_lbs={txt_amod_engine_thrust_lbs.Text.Trim()}, ");
				Query.Append($"amod_engine_shaft={txt_amod_engine_shaft.Text.Trim()}, ");

				Query.Append($"amod_engine_com_tbo_hrs={cbo_tbo_list.Text.Trim()}, ");
				Query.Append($"amod_on_condition_flag = {((chk_oncondtbox.CheckState == CheckState.Checked) ? "'Y'" : "'N'")}, ");
				Query.Append($"amod_number_of_engines= {txt_amod_number_of_engines.Text.Trim()}, ");
				Query.Append($"amod_engine_hsi={txt_amod_engine_hsi.Text.Trim()},");
				Query.Append($"amod_fuselage_length={txt_amod_fuselage_length[0].Text.Trim()},");
				Query.Append($"amod_fuselage_height={txt_amod_fuselage_height.Text.Trim()},");
				Query.Append($"amod_fuselage_wingspan={txt_amod_fuselage_wingspan.Text.Trim()},");
				Query.Append($"amod_number_of_crew={txt_amod_number_of_crew.Text.Trim()},");
				Query.Append($"amod_number_of_passengers={txt_amod_number_of_passengers.Text.Trim()},");
				Query.Append($"amod_pressure={txt_amod_pressure.Text.Trim()},");
				Query.Append($"amod_max_ramp_weight={txt_amod_max_ramp_weight.Text.Trim()},");

				// 07/28/2017 - By David D. Cruger; Added
				strJIQSize = cboJIQSize.Text.Trim();
				if (strJIQSize != "")
				{
					iPos1 = (strJIQSize.IndexOf(" - ") + 1);
					if (iPos1 > 0)
					{
						strJIQSize = strJIQSize.Substring(0, Math.Min(iPos1, strJIQSize.Length));
					}
				}
				Query.Append($"amod_jniq_size='{strJIQSize}',");

				Query.Append($"amod_max_takeoff_weight={txt_amod_max_takeoff_weight.Text.Trim()},");
				Query.Append($"amod_zero_fuel_weight={txt_amod_zero_fuel_weight.Text.Trim()},");
				Query.Append($"amod_basic_op_weight={txt_amod_basic_op_weight.Text.Trim()},");
				Query.Append($"amod_max_landing_weight={txt_amod_max_landing_weight.Text.Trim()},");
				Query.Append($"amod_fuel_cap_std_weight={txt_amod_fuel_cap_std_weight.Text.Trim()},");
				Query.Append($"amod_fuel_cap_std_gal={txt_amod_fuel_cap_std_gal.Text.Trim()},");
				Query.Append($"amod_fuel_cap_opt_weight={txt_amod_fuel_cap_opt_weight.Text.Trim()},");
				Query.Append($"amod_fuel_cap_opt_gal={txt_amod_fuel_cap_opt_gal.Text.Trim()},");
				Query.Append($"amod_takeoff_ali={txt_amod_takeoff_ali.Text.Trim()},");
				Query.Append($"amod_takeoff_500={txt_amod_takeoff_500.Text.Trim()},");
				Query.Append($"amod_field_length={txt_amod_field_length.Text.Trim()},");
				Query.Append($"amod_max_range_miles={txt_amod_max_range_miles.Text.Trim()},");
				Query.Append($"amod_climb_normal_feet={txt_amod_climb_normal_feet.Text.Trim()},");
				Query.Append($"amod_ceiling_feet={txt_amod_ceiling_feet.Text.Trim()},");
				Query.Append($"amod_number_of_props={txt_amod_number_of_props.Text.Trim()},");
				Query.Append($"amod_prop_model_name='{modAdminCommon.Fix_Quote(txt_amod_prop_model_name.Text).Trim()}',");
				Query.Append($"amod_prop_mfr_name='{modAdminCommon.Fix_Quote(txt_amod_prop_mfr_name.Text).Trim()}',");
				Query.Append($"amod_prop_com_tbo_hrs={txt_amod_prop_com_tbo_hrs.Text.Trim()},");
				Query.Append($"amod_prop_shaft={txt_amod_prop_shaft.Text.Trim()},");
				Query.Append($"amod_prop_hsi={txt_amod_prop_hsi.Text.Trim()},");
				Query.Append($"amod_other_config_note='{modAdminCommon.Fix_Quote(txt_amod_other_config_note.Text).Trim()}',");
				Query.Append($"amod_climb_engout_feet={txt_amod_climb_engout_feet.Text.Trim()},");

				Query.Append($"amod_stall_vs = {txt_amod_speed[0].Text.Trim()},");
				Query.Append($"amod_stall_vso = {txt_amod_speed[1].Text.Trim()},");
				Query.Append($"amod_cruis_speed = {txt_amod_speed[2].Text.Trim()},");
				Query.Append($"amod_max_speed = {txt_amod_speed[3].Text.Trim()},"); // Vmo(MaxOp) IAS

				// 07/28/2017 - By David D. Cruger; Added
				Query.Append($"amod_v1_takeoff_speed = {txt_amod_speed[4].Text.Trim()},");
				Query.Append($"amod_vfe_max_flap_extended_speed = {txt_amod_speed[5].Text.Trim()},");
				Query.Append($"amod_vle_max_landing_gear_ext_speed = {txt_amod_speed[6].Text.Trim()},");

				// 08/02/2017 - By David D. Cruger; Added
				Query.Append($"amod_vne_maxop_speed = {txt_amod_speed[7].Text.Trim()},");

				//2/3/21 MSW - added ------------
				Query.Append($"amod_icao_code = '{txt_amod_icao.Text.Trim()}',");

				//new specs fields 10/27/05 aey
				Query.Append($"amod_main_rotor_1_blade_count = {Double.Parse($"{txt_amod_main_rotor_1_blade_count.Text}").ToString()},");
				Query.Append($"amod_main_rotor_1_blade_diameter = {Double.Parse($"{txt_amod_main_rotor_1_blade_diameter.Text}").ToString()},");
				Query.Append($"amod_main_rotor_2_blade_count = {Double.Parse($"{txt_amod_main_rotor_2_blade_count.Text}").ToString()},");
				Query.Append($"amod_main_rotor_2_blade_diameter = {Double.Parse($"{txt_amod_main_rotor_2_blade_diameter.Text}").ToString()},");
				Query.Append($"amod_tail_rotor_blade_count = {Double.Parse($"{txt_amod_tail_rotor_blade_count.Text}").ToString()},");
				Query.Append($"amod_tail_rotor_blade_diameter = {Double.Parse($"{txt_amod_tail_rotor_blade_diameter.Text}").ToString()},");
				Query.Append($"amod_rotor_anti_torque_system ='{modAdminCommon.Fix_Quote($"{cmb_amod_rotor_anti_torque_system.Text}").Trim()}', ");
				Query.Append($"amod_fuselage_width = {Double.Parse($"{txt_amod_fuselage_width.Text}").ToString()},");
				Query.Append($"amod_climb_hoge= {Double.Parse($"{txt_amod_climb_hoge.Text}").ToString()},");
				Query.Append($"amod_climb_hige = {Double.Parse($"{txt_amod_climb_hige.Text}").ToString()},");
				Query.Append($"amod_range_tanks_full = {Double.Parse($"{txt_amod_range_tanks_full.Text}").ToString()},");
				Query.Append($"amod_range_seats_full = {Double.Parse($"{txt_amod_range_seats_full.Text}").ToString()},");

				// 07/28/2017 - By David D. Cruger; Added
				Query.Append($"amod_range_4_passenger = {Double.Parse($"{txt_amod_range_4_passenger.Text}").ToString()},");
				Query.Append($"amod_range_8_passenger = {Double.Parse($"{txt_amod_range_8_passenger.Text}").ToString()},");

				Query.Append($"amod_ifr_certification = '{modAdminCommon.Fix_Quote(cmb_amod_ifr_certification).Trim()}', ");
				Query.Append($"amod_weight_eow = {Double.Parse($"{txt_amod_weight_eow.Text}").ToString()}, ");
				Query.Append($"amod_internal_note = '{StringsHelper.Replace(txt_intel.Text, "'", "''", 1, -1, CompareMethod.Binary)}', ");

				//new cabin dimensions tab 4/21/10 Tom
				// create doubles to hold the ft/in
				int cabin_height_ft = 0;
				int cabin_height_in = 0;
				int cabin_length_ft = 0;
				int cabin_length_in = 0;
				int cabin_width_ft = 0;
				int cabin_width_in = 0;
				double cabin_volume = 0;
				double baggage_volume = 0;

				// set the default values
				cabin_height_ft = 0;
				cabin_height_in = 0;
				cabin_length_ft = 0;
				cabin_length_in = 0;
				cabin_width_ft = 0;
				cabin_width_in = 0;

				cabin_volume = 0;
				baggage_volume = 0;

				// check the textbox values
				// height ft/in
				if (txt_amod_fuselage_length[1].Text != "")
				{
					if (Information.IsNumeric(txt_amod_fuselage_length[1].Text))
					{
						cabin_height_ft = Convert.ToInt32(Double.Parse(txt_amod_fuselage_length[1].Text));
					}
				}
				if (txt_amod_fuselage_length[2].Text != "")
				{
					if (Information.IsNumeric(txt_amod_fuselage_length[2].Text))
					{
						cabin_height_in = Convert.ToInt32(Double.Parse(txt_amod_fuselage_length[2].Text));
					}
				}
				// length ft/in
				if (txt_amod_fuselage_length[3].Text != "")
				{
					if (Information.IsNumeric(txt_amod_fuselage_length[3].Text))
					{
						cabin_length_ft = Convert.ToInt32(Double.Parse(txt_amod_fuselage_length[3].Text));
					}
				}
				if (txt_amod_fuselage_length[4].Text != "")
				{
					if (Information.IsNumeric(txt_amod_fuselage_length[4].Text))
					{
						cabin_length_in = Convert.ToInt32(Double.Parse(txt_amod_fuselage_length[4].Text));
					}
				}
				// width ft/in
				if (txt_amod_fuselage_length[5].Text != "")
				{
					if (Information.IsNumeric(txt_amod_fuselage_length[5].Text))
					{
						cabin_width_ft = Convert.ToInt32(Double.Parse(txt_amod_fuselage_length[5].Text));
					}
				}
				if (txt_amod_fuselage_length[6].Text != "")
				{
					if (Information.IsNumeric(txt_amod_fuselage_length[6].Text))
					{
						cabin_width_in = Convert.ToInt32(Double.Parse(txt_amod_fuselage_length[6].Text));
					}
				}

				// 07/28/2017 - By David D. Cruger; Added
				if (txt_amod_fuselage_length[8].Text != "")
				{
					if (Information.IsNumeric(txt_amod_fuselage_length[8].Text))
					{
						cabin_volume = Double.Parse(txt_amod_fuselage_length[8].Text);
					}
				}

				if (txt_amod_fuselage_length[9].Text != "")
				{
					if (Information.IsNumeric(txt_amod_fuselage_length[9].Text))
					{
						baggage_volume = Double.Parse(txt_amod_fuselage_length[9].Text);
					}
				}

				Query.Append($"amod_cabinsize_height_feet={cabin_height_ft.ToString()},");
				Query.Append($"amod_cabinsize_height_inches={cabin_height_in.ToString()},");
				Query.Append($"amod_cabinsize_width_feet={cabin_width_ft.ToString()},");
				Query.Append($"amod_cabinsize_width_inches={cabin_width_in.ToString()},");
				Query.Append($"amod_cabinsize_length_feet={cabin_length_ft.ToString()},");
				Query.Append($"amod_cabinsize_length_inches={cabin_length_in.ToString()},");

				// 07/28/2017 - By David D. Cruger; Added
				Query.Append($"amod_cabin_volume={cabin_volume.ToString()},");
				Query.Append($"amod_baggage_volume={baggage_volume.ToString()},");

				//OP COSTS TAB UPDATE
				Query.Append($"amod_fuel_tot_cost={modAdminCommon.Fix_Quote(Double.Parse(txt_amod_fuel_tot_cost.Text)).Trim()},");
				Query.Append($"amod_fuel_gal_cost={modAdminCommon.Fix_Quote(Double.Parse(txt_amod_fuel_gal_cost.Text)).Trim()},");
				Query.Append($"amod_fuel_add_cost={modAdminCommon.Fix_Quote(Double.Parse(txt_amod_fuel_add_cost.Text)).Trim()},");
				Query.Append($"amod_fuel_burn_rate={modAdminCommon.Fix_Quote(Double.Parse(txt_amod_fuel_burn_rate.Text)).Trim()},");
				Query.Append($"amod_maint_tot_cost={modAdminCommon.Fix_Quote(Double.Parse(txt_amod_maint_tot_cost.Text)).Trim()},");
				Query.Append($"amod_maint_lab_cost={modAdminCommon.Fix_Quote(Double.Parse(txt_amod_maint_lab_cost.Text)).Trim()},");
				Query.Append($"amod_maint_labor_cost_man_hours_multiplier={modAdminCommon.Fix_Quote(Double.Parse(txt_amod_maint_labor_man_hour_multiplier.Text)).Trim()},");
				Query.Append($"amod_maint_parts_cost={modAdminCommon.Fix_Quote(Double.Parse(txt_amod_maint_parts_cost.Text)).Trim()},");
				Query.Append($"amod_maint_parts_cost_man_hours_multiplier={modAdminCommon.Fix_Quote(Double.Parse(txt_amod_maint_parts_man_hour_multiplier.Text)).Trim()},");
				Query.Append($"amod_engine_ovh_cost={modAdminCommon.Fix_Quote(Double.Parse(txt_amod_engine_ovh_cost.Text)).Trim()},");
				Query.Append($"amod_thrust_rev_ovh_cost={modAdminCommon.Fix_Quote(Double.Parse(txt_amod_thrust_rev_ovh_cost.Text)).Trim()},");
				Query.Append($"amod_misc_flight_cost={modAdminCommon.Fix_Quote(Double.Parse(txt_amod_misc_flight_cost.Text)).Trim()},");
				Query.Append($"amod_land_park_cost={modAdminCommon.Fix_Quote(Double.Parse(txt_amod_land_park_cost.Text)).Trim()},");
				Query.Append($"amod_crew_exp_cost={modAdminCommon.Fix_Quote(Double.Parse(txt_amod_crew_exp_cost.Text)).Trim()},");
				Query.Append($"amod_supplies_cost={modAdminCommon.Fix_Quote(Double.Parse(txt_amod_supplies_cost.Text)).Trim()},");
				Query.Append($"amod_tot_hour_direct_cost={Double.Parse($"{txt_amod_tot_hour_direct_cost.Text}").ToString()},");

				Query.Append($"amod_avg_block_speed={Double.Parse(modAdminCommon.Fix_Quote(txt_amod_avg_block_speed)).ToString().Trim()},");
				Query.Append($"amod_tot_stat_mile_cost={modAdminCommon.Fix_Quote(Double.Parse(txt_amod_tot_stat_mile_cost.Text)).Trim()},");
				Query.Append($"amod_tot_crew_salary_cost={modAdminCommon.Fix_Quote(Double.Parse(txt_amod_tot_crew_salary_cost.Text)).Trim()},");
				Query.Append($"amod_capt_salary_cost={modAdminCommon.Fix_Quote(Double.Parse(txt_amod_capt_salary_cost.Text)).Trim()},");
				Query.Append($"amod_cpilot_salary_cost={modAdminCommon.Fix_Quote(Double.Parse(txt_amod_cpilot_salary_cost.Text)).Trim()},");
				Query.Append($"amod_crew_benefit_cost={modAdminCommon.Fix_Quote(Double.Parse(txt_amod_crew_benefit_cost.Text)).Trim()},");
				Query.Append($"amod_hangar_cost={modAdminCommon.Fix_Quote(Double.Parse(txt_amod_hangar_cost.Text)).Trim()},");
				Query.Append($"amod_insurance_cost={modAdminCommon.Fix_Quote(Double.Parse(txt_amod_insurance_cost.Text)).Trim()},");
				Query.Append($"amod_hull_insurance_cost={modAdminCommon.Fix_Quote(Double.Parse(txt_amod_hull_insurance_cost.Text)).Trim()},");
				Query.Append($"amod_liability_insurance_cost={modAdminCommon.Fix_Quote(Double.Parse(txt_amod_liability_insurance_cost.Text)).Trim()},");
				Query.Append($"amod_tot_misc_ovh_cost={modAdminCommon.Fix_Quote(Double.Parse(txt_amod_tot_misc_ovh_cost.Text)).Trim()},");
				Query.Append($"amod_misc_train_cost={modAdminCommon.Fix_Quote(Double.Parse(txt_amod_misc_train_cost.Text)).Trim()},");
				Query.Append($"amod_misc_modern_cost={modAdminCommon.Fix_Quote(Double.Parse(txt_amod_misc_modern_cost.Text)).Trim()},");
				Query.Append($"amod_misc_naveq_cost={modAdminCommon.Fix_Quote(Double.Parse(txt_amod_misc_naveq_cost.Text)).Trim()},");
				Query.Append($"amod_deprec_cost={modAdminCommon.Fix_Quote(Double.Parse(txt_amod_deprec_cost.Text)).Trim()},");
				Query.Append($"amod_tot_fixed_cost={modAdminCommon.Fix_Quote(Double.Parse(txt_amod_tot_fixed_cost.Text)).Trim()},");
				Query.Append($"amod_number_of_seats={modAdminCommon.Fix_Quote(Double.Parse(txt_amod_number_of_seats.Text)).Trim()},");
				Query.Append($"amod_annual_miles={modAdminCommon.Fix_Quote(Double.Parse(txt_amod_annual_miles.Text)).Trim()},");
				Query.Append($"amod_annual_hours={modAdminCommon.Fix_Quote(Math.Round((double) Double.Parse(txt_amod_annual_hours.Text), 0)).Trim()},");
				if (txt_amod_tot_direct_cost.Text == "")
				{
					txt_amod_tot_direct_cost.Text = "0";
				}
				Query.Append($"amod_tot_direct_cost={Double.Parse($"{txt_amod_tot_direct_cost.Text}").ToString()},");
				Query.Append($"amod_tot_df_annual_cost={modAdminCommon.Fix_Quote(Double.Parse($"0{txt_amod_tot_df_annual_cost.Text}")).Trim()},");
				Query.Append($"amod_tot_df_hour_cost={modAdminCommon.Fix_Quote(Double.Parse($"0{txt_amod_tot_df_hour_cost.Text}")).Trim()},");
				Query.Append($"amod_tot_df_statmile_cost={modAdminCommon.Fix_Quote(Double.Parse($"0{txt_amod_tot_df_statmile_cost.Text}")).Trim()},");
				Query.Append($"amod_tot_df_seat_cost={modAdminCommon.Fix_Quote(Math.Abs(Double.Parse($"0{txt_amod_tot_df_seat_cost.Text}"))).Trim()},");
				Query.Append($"amod_tot_nd_annual_cost={modAdminCommon.Fix_Quote(Math.Abs(Double.Parse(txt_amod_tot_nd_annual_cost.Text))).Trim()},");
				Query.Append($"amod_tot_nd_hour_cost={Double.Parse($"{txt_amod_tot_nd_hour_cost.Text}").ToString()},");
				Query.Append($"amod_tot_nd_statmile_cost={Double.Parse($"{txt_amod_tot_nd_statmile_cost.Text}").ToString()},");
				Query.Append($"amod_tot_nd_seat_cost={Double.Parse($"{txt_amod_tot_nd_seat_cost.Text}").ToString()},");

				// 02/09/2018 - By David D. Cruger; Added
				if (txt_amod_tot_variable_cost.Text == "")
				{
					txt_amod_tot_variable_cost.Text = "0";
				}
				Query.Append($"amod_variable_costs={Double.Parse($"{txt_amod_tot_variable_cost.Text}").ToString()},");

				//ADMINISTRAION TAB UPDATE

				Query.Append($"amod_common_verify_days={modAdminCommon.Fix_Quote(txt_amod_common_verify_days).Trim()},");
				Query.Append($"amod_sale_verify_days={modAdminCommon.Fix_Quote(txt_amod_sale_verify_days).Trim()},");

				// commented out .. as the whole tab will be - just to make the update cant change anything here
				// msw -8 / 31 / 23
				amod_customer_flag = "";
				if (chk_amod_customer_flag.CheckState == CheckState.Checked)
				{
					Query.Append("amod_customer_flag='Y',");
					amod_customer_flag = "Y";
				}
				else
				{
					Query.Append("amod_customer_flag='N',");
					amod_customer_flag = "N";
				}

				// 03/21/2008 - By David D. Cruger
				// Set Model Picture Flag
				if (img_Model_Picture.Visible)
				{
					Query.Append("amod_picture_exists_flag='Y',");
				}
				else
				{
					Query.Append("amod_picture_exists_flag='N',");
				}

				// 01/15/2016 - By David D. Cruger
				strName = cmbBodyConfig.Text;
				strType = modCommon.DLookUp("ambc_type", "Aircraft_Model_Body_Config", $"(ambc_name = '{strName}')");
				if (strType == "")
				{
					strType = "U";
				}
				Query.Append($"amod_body_config = '{strType}', ");

				//MAINTENANCE TAB UPDATE
				Query.Append($"amod_maint_note='{modAdminCommon.Fix_Quote(txt_amod_maint_note).Trim()} ',");
				Query.Append($"amod_inspection_note = '{modAdminCommon.Fix_Quote(txt_amod_inspection_note).Trim()} ', ");

				// add the checks for product codes
				// only update if value has changed
				int tempForEndVar = chk_amod_product.GetUpperBound(0);
				for (int i = 0; i <= tempForEndVar; i++)
				{


					switch((i))
					{
						case modGlobalVars.CHK_BUSINESS_IDX : 
							//UPGRADE_ISSUE: (2064) CheckBox property chk_amod_product.DataChanged was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064 
							if (chk_amod_product[i].CheckState == CheckState.Checked) //&& chk_amod_product[i].getDataChanged()) //gap-note: jgamboa. Remove deprecated property; validation is handled by the inner condition.
							{
								if (Convert.ToString(snp_Model["amod_product_business_flag"]) != "Y")
								{
									if (chk_amod_product[modGlobalVars.CHK_BUSINESS_IDX].CheckState == CheckState.Checked)
									{
										Query.Append("amod_product_business_flag = 'Y' , ");
										bAtLeastOneProduct = true;
									}
								}
							}
							else if (chk_amod_product[i].CheckState == CheckState.Unchecked) //&& chk_amod_product[i].getDataChanged()) //gap-note: jgamboa. Remove deprecated property; validation is handled by the inner condition.
							{ 
								if (Convert.ToString(snp_Model["amod_product_business_flag"]) != "N")
								{
									// check for business aircraft for this model if business product code changes
									if (Conversion.Val(modCommon.DLookUp("count(ac_amod_id) as AircraftCount", "Aircraft WITH(NOLOCK)", $"ac_product_business_flag = 'Y' and ac_amod_id = {Convert.ToString(snp_Model["amod_id"])} and ac_journ_id = 0")) > 0)
									{
										MessageBox.Show("This Model has Business Aircraft - Business Product Code Can't be Removed", "Model : Business Product Code Change", MessageBoxButtons.OK, MessageBoxIcon.Error);
										return;
									}

									if (chk_amod_product[modGlobalVars.CHK_BUSINESS_IDX].CheckState == CheckState.Unchecked)
									{
										Query.Append("amod_product_business_flag = 'N' , ");
									}
								}
							} 
							break;
						case modGlobalVars.CHK_HELICOPTER_IDX : 
							//UPGRADE_ISSUE: (2064) CheckBox property chk_amod_product.DataChanged was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064 
							if (chk_amod_product[i].CheckState == CheckState.Checked) //&& chk_amod_product[i].getDataChanged()) //gap-note: jgamboa. Remove deprecated property; validation is handled by the inner condition.
							{
								if (Convert.ToString(snp_Model["amod_product_helicopter_flag"]) != "Y")
								{
									if (chk_amod_product[modGlobalVars.CHK_HELICOPTER_IDX].CheckState == CheckState.Checked)
									{
										Query.Append("amod_product_helicopter_flag = 'Y' , ");
										bAtLeastOneProduct = true;
									}
								}
							}
							else if (chk_amod_product[i].CheckState == CheckState.Unchecked) //&& chk_amod_product[i].getDataChanged()) //gap-note: jgamboa. Remove deprecated property; validation is handled by the inner condition.
							{ 

								if (Convert.ToString(snp_Model["amod_product_helicopter_flag"]) != "N")
								{
									// check for business aircraft for this model if business product code changes
									if (Conversion.Val(modCommon.DLookUp("count(ac_amod_id) as AircraftCount", "Aircraft WITH(NOLOCK)", $"ac_product_helicopter_flag = 'Y' and ac_amod_id = {Convert.ToString(snp_Model["amod_id"])} and ac_journ_id = 0")) > 0)
									{
										MessageBox.Show("This Model has Helicopter(s) - Helicopter Product Code Can't be Removed", "Model : Helicopter Product Code Change", MessageBoxButtons.OK, MessageBoxIcon.Error);
										return;
									}

									if (chk_amod_product[modGlobalVars.CHK_HELICOPTER_IDX].CheckState == CheckState.Unchecked)
									{
										Query.Append("amod_product_helicopter_flag = 'N' , ");
									}
								}
							} 
							break;
						case modGlobalVars.CHK_COMMERCIAL_IDX : 
							//UPGRADE_ISSUE: (2064) CheckBox property chk_amod_product.DataChanged was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064 
							if (chk_amod_product[i].CheckState == CheckState.Checked) //&& chk_amod_product[i].getDataChanged()) //gap-note: jgamboa. Remove deprecated property; validation is handled by the inner condition.
							{
								if (Convert.ToString(snp_Model["amod_product_commercial_flag"]) != "Y")
								{
									if (chk_amod_product[modGlobalVars.CHK_COMMERCIAL_IDX].CheckState == CheckState.Checked)
									{
										Query.Append("amod_product_commercial_flag = 'Y' , ");
										bAtLeastOneProduct = true;
									}
								}
							}
							else if (chk_amod_product[i].CheckState == CheckState.Unchecked) //&& chk_amod_product[i].getDataChanged()) //gap-note: jgamboa. Remove deprecated property; validation is handled by the inner condition.
							{ 
								// check for business aircraft for this model if business product code changes
								if (Convert.ToString(snp_Model["amod_product_commercial_flag"]) != "N")
								{

									if (Conversion.Val(modCommon.DLookUp("count(ac_amod_id) as AircraftCount", "Aircraft WITH(NOLOCK)", $"ac_product_commercial_flag = 'Y' and ac_amod_id = {Convert.ToString(snp_Model["amod_id"])} and ac_journ_id = 0")) > 0)
									{
										MessageBox.Show("This Model has Commercial Aircraft - Commercial Product Code Can't be Removed", "Model : Commercial Product Code Change", MessageBoxButtons.OK, MessageBoxIcon.Error);
										return;
									}

									if (chk_amod_product[modGlobalVars.CHK_COMMERCIAL_IDX].CheckState == CheckState.Unchecked)
									{
										Query.Append("amod_product_commercial_flag = 'N' , ");
									}
								}
							} 
							break;
						case modGlobalVars.CHK_AIRBP_IDX : 
							//UPGRADE_ISSUE: (2064) CheckBox property chk_amod_product.DataChanged was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064 
							if (chk_amod_product[i].CheckState == CheckState.Checked) //&& chk_amod_product[i].getDataChanged()) //gap-note: jgamboa. Remove deprecated property; validation is handled by the inner condition.
							{
								if (chk_amod_product[modGlobalVars.CHK_AIRBP_IDX].CheckState == CheckState.Checked)
								{
									if (Convert.ToString(snp_Model["amod_product_airbp_flag"]) != "Y")
									{
										Query.Append("amod_product_airbp_flag = 'Y' , ");
										bAtLeastOneProduct = true;
									}
								}
							}
							else if (chk_amod_product[i].CheckState == CheckState.Unchecked) //&& chk_amod_product[i].getDataChanged()) //gap-note: jgamboa. Remove deprecated property; validation is handled by the inner condition.
							{ 
								if (Convert.ToString(snp_Model["amod_product_airbp_flag"]) != "N")
								{
									if (chk_amod_product[modGlobalVars.CHK_AIRBP_IDX].CheckState == CheckState.Unchecked)
									{
										Query.Append("amod_product_airbp_flag = 'N' , ");
									}
								}
							} 
							break;
						case modGlobalVars.CHK_ABI_IDX : case modGlobalVars.CHK_REGIONAL_IDX : 
							 
							break;
						default:
							 
							goto exit_for; 
							 
							break;
					}

				}
				exit_for:

				// if there is not at least one product code then default to business and tell user
				if (Convert.ToString(snp_Model["amod_product_business_flag"]) == "N" && Convert.ToString(snp_Model["amod_product_helicopter_flag"]) == "N" && Convert.ToString(snp_Model["amod_product_commercial_flag"]) == "N" && Convert.ToString(snp_Model["amod_product_airbp_flag"]) == "N" && !bAtLeastOneProduct)
				{
					Query.Append("amod_product_business_flag = 'Y' , ");
					MessageBox.Show("NO MODEL Product Code! Defaulting to Business!", "Model : Update Model", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

				// RTW - MODIFIED - 8/23/2010 - WAS MISSING QUOTES
				if (txt_amod_fuselage_length[7].Text != "")
				{
					Query.Append($" amod_faa_model_id = '{txt_amod_fuselage_length[7].Text}' , ");
				}

				Query.Append($"amod_action_date = NULL WHERE amod_id = {Convert.ToString(snp_Model["amod_id"])}");

				// commented out
				if (amod_customer_flag != hold_amod_customer_flag)
				{
					Ans = MessageBox.Show($"The Customer Releasable Flag has Changed{Environment.NewLine}Do you want to cancel this update?", "Release to Customer Flag", MessageBoxButtons.YesNo);
					if (Ans == System.Windows.Forms.DialogResult.Yes)
					{
						if (hold_amod_customer_flag == "Y")
						{
							chk_amod_customer_flag.CheckState = CheckState.Checked;
						}
						else
						{
							chk_amod_customer_flag.CheckState = CheckState.Unchecked;
						}

						return;
					}
				}

				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = Query.ToString();
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();

				Update_Aircraft_Model_Record_With_Aircraft_Model_Engine_Lowest_Seq(Convert.ToInt32(snp_Model["amod_id"]));

				// 02/12/2013 - By David D. Cruger

				string changes_made = "";
				string change_subject = "";
				check_for_model_changes(ref change_subject, ref changes_made, strAModId);

				modAdminCommon.Record_Event("Update Aircraft Model", $"Updating Aircraft Model: AModId: {strAModId}  Make: {txt_amod_make_name.Text} Model: {txt_amod_model_name.Text}");

				//refresh if we are on that tab
				if (SSTabHelper.GetSelectedIndex(tab_Aircraft_Model) == 12)
				{
					fill_amod_journal_grid();
					fill_fuel_eventlog();
				}
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				MessageBox.Show($"Update_Aircraft_Model_Error: {Information.Err().Number.ToString()} {excep.Message}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}

		private bool Insert_Model_Research_Note(string Subject, string description, int temp_Amod_id)
		{


			bool result = false;
			modAdminCommon.ADO_Transaction("BeginTrans");


			modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(modAdminCommon.DateToday);
			modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "RN";
			modAdminCommon.Rec_Journal_Info.journ_subject = Subject;
			modAdminCommon.Rec_Journal_Info.journ_description = description;
			modAdminCommon.Rec_Journal_Info.journ_ac_id = 0;
			modAdminCommon.Rec_Journal_Info.journ_comp_id = 0;
			modAdminCommon.Rec_Journal_Info.journ_amod_id = temp_Amod_id;
			modAdminCommon.Rec_Journal_Info.journ_contact_id = 0;

			modAdminCommon.Rec_Journal_Info.journ_account_id = "0";
			modAdminCommon.Rec_Journal_Info.journ_prior_account_id = " ";
			modAdminCommon.Rec_Journal_Info.journ_status = "A";

			frm_Journal.DefInstance.Commit_Journal_Entry();

			modAdminCommon.ADO_Transaction("CommitTrans");


			return true;



		}
		public void Select_Aircraft_Engine()
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strEMId = "";
			int lEMId = 0;


			try
			{

				if (snp_AircraftEngine.EOF && snp_AircraftEngine.BOF)
				{
					return;
				}

				snp_AircraftEngine.MoveFirst();
				int tempForEndVar = ListBoxHelper.GetSelectedIndex(lst_Spec_Engines);
				for (int i = 1; i <= tempForEndVar; i++)
				{
					snp_AircraftEngine.MoveNext();
				}

				txt_ameng_mfr_name.Text = "";
				txt_ameng_mfr_name_short.Text = "";
				txt_ameng_mfr_CompID.Text = "0";
				txt_ameng_engine_prefix.Text = "";
				txt_ameng_engine_core.Text = "";
				txt_ameng_engine_suffix1.Text = "";
				txt_ameng_engine_suffix2.Text = "";
				txt_ameng_takeoff_power.Text = "0";
				txt_ameng_max_continuous_power.Text = "0";
				txt_ameng_seq_no.Text = "0";
				Chk_ameng_active_flag.CheckState = CheckState.Checked;

				lEMId = 0;
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(snp_AircraftEngine["ameng_engine_model_id"]))
				{
					lEMId = Convert.ToInt32(snp_AircraftEngine["ameng_engine_model_id"]);
				}

				if (lEMId > 0)
				{

					strEMId = lEMId.ToString();
					lbl_specs[93].Text = $"Engine Model Id: {strEMId}";
					lbl_specs[93].Tag = strEMId;

					strQuery1 = $"SELECT * FROM Engine_Models WITH (NOLOCK) WHERE (em_id = {strEMId}) ";

					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						txt_amod_engine_thrust_lbs.Text = "0";
						chk_oncondtbox.CheckState = CheckState.Unchecked;
						cbo_tbo_list.SelectedIndex = -1;
						txt_amod_engine_shaft.Text = "0";
						txt_amod_engine_hsi.Text = "0";

						txt_ameng_mfr_name.Text = ($"{Convert.ToString(rstRec1["em_mfr_name"])} ").Trim();
						txt_ameng_mfr_name_short.Text = ($"{Convert.ToString(rstRec1["em_mfr_name_abbrev"])} ").Trim();

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["em_mfr_comp_id"]))
						{
							txt_ameng_mfr_CompID.Text = Convert.ToString(rstRec1["em_mfr_comp_id"]);
						}

						txt_ameng_engine_prefix.Text = ($"{Convert.ToString(rstRec1["em_engine_prefix"])} ").Trim();
						txt_ameng_engine_core.Text = ($"{Convert.ToString(rstRec1["em_engine_core"])} ").Trim();
						txt_ameng_engine_suffix1.Text = ($"{Convert.ToString(rstRec1["em_engine_suffix1"])} ").Trim();
						txt_ameng_engine_suffix2.Text = ($"{Convert.ToString(rstRec1["em_engine_suffix2"])} ").Trim();

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["em_takeoff_power"]))
						{
							txt_ameng_takeoff_power.Text = Convert.ToString(rstRec1["em_takeoff_power"]);
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["em_max_continuous_power"]))
						{
							txt_ameng_max_continuous_power.Text = Convert.ToString(rstRec1["em_max_continuous_power"]);
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snp_AircraftEngine["ameng_seq_no"]))
						{
							txt_ameng_seq_no.Text = Convert.ToString(snp_AircraftEngine["ameng_seq_no"]);
						}

						modCommon.SetCheckBoxYesNo(Chk_ameng_active_flag, ($"{Convert.ToString(snp_AircraftEngine["ameng_active_flag"])} ").Trim(), CheckState.Checked);

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["em_engine_shaft"]))
						{
							txt_amod_engine_thrust_lbs.Text = Convert.ToString(rstRec1["em_engine_thrust_lbs"]);
						}

						modCommon.SetCheckBoxYesNo(chk_oncondtbox, ($"{Convert.ToString(rstRec1["em_on_condition_flag"])} ").Trim(), CheckState.Unchecked);

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["em_engine_com_tbo_hrs"]))
						{
							modCommon.SetComboText(cbo_tbo_list, Convert.ToString(rstRec1["em_engine_com_tbo_hrs"]));
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["em_engine_shaft"]))
						{
							txt_amod_engine_shaft.Text = Convert.ToString(rstRec1["em_engine_shaft"]);
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["em_engine_hsi"]))
						{
							txt_amod_engine_hsi.Text = Convert.ToString(rstRec1["em_engine_hsi"]);
						}

						SetEngineModelFieldsEnabled(false);

					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

				}
				else
				{
					// If lEMId > 0 Then

					lbl_specs[93].Text = "Engine Model Id: 0";
					lbl_specs[93].Tag = "0";

					txt_ameng_mfr_name.Text = Convert.ToString(snp_AircraftEngine["ameng_mfr_name"]).Trim().Substring(0, Math.Min(100, Convert.ToString(snp_AircraftEngine["ameng_mfr_name"]).Trim().Length));
					txt_ameng_mfr_name_short.Text = Convert.ToString(snp_AircraftEngine["ameng_mfr_name_abbrev"]).Trim().Substring(0, Math.Min(4, Convert.ToString(snp_AircraftEngine["ameng_mfr_name_abbrev"]).Trim().Length));

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snp_AircraftEngine["ameng_mfr_comp_id"]))
					{
						txt_ameng_mfr_CompID.Text = Convert.ToString(snp_AircraftEngine["ameng_mfr_comp_id"]);
					}

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snp_AircraftEngine["ameng_engine_model_id"]))
					{
						lbl_specs[93].Text = $"Engine Model Id: {Convert.ToString(snp_AircraftEngine["ameng_engine_model_id"])}";
						lbl_specs[93].Tag = Convert.ToString(snp_AircraftEngine["ameng_engine_model_id"]);
					}

					txt_ameng_engine_prefix.Text = Convert.ToString(snp_AircraftEngine["ameng_engine_prefix"]).Trim();
					txt_ameng_engine_core.Text = Convert.ToString(snp_AircraftEngine["ameng_engine_core"]).Trim();
					txt_ameng_engine_suffix1.Text = Convert.ToString(snp_AircraftEngine["ameng_engine_suffix1"]).Trim();
					txt_ameng_engine_suffix2.Text = Convert.ToString(snp_AircraftEngine["ameng_engine_suffix2"]).Trim();

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snp_AircraftEngine["ameng_takeoff_power"]))
					{
						txt_ameng_takeoff_power.Text = Convert.ToString(snp_AircraftEngine["ameng_takeoff_power"]);
					}

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snp_AircraftEngine["ameng_max_continuous_power"]))
					{
						txt_ameng_max_continuous_power.Text = Convert.ToString(snp_AircraftEngine["ameng_max_continuous_power"]);
					}

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(snp_AircraftEngine["ameng_seq_no"]))
					{
						txt_ameng_seq_no.Text = Convert.ToString(snp_AircraftEngine["ameng_seq_no"]);
					}

					modCommon.SetCheckBoxYesNo(Chk_ameng_active_flag, ($"{Convert.ToString(snp_AircraftEngine["ameng_active_flag"])} ").Trim(), CheckState.Checked);

					SetEngineModelFieldsEnabled(true);

				} // If lEMId > 0 Then

				s_PrevEngineName = ($"{txt_ameng_engine_prefix.Text.Trim()}{txt_ameng_engine_core.Text.Trim()}{txt_ameng_engine_suffix1.Text.Trim()}{txt_ameng_engine_suffix2.Text.Trim()}").Substring(0, Math.Min(20, ($"{txt_ameng_engine_prefix.Text.Trim()}{txt_ameng_engine_core.Text.Trim()}{txt_ameng_engine_suffix1.Text.Trim()}{txt_ameng_engine_suffix2.Text.Trim()}").Length));

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				snp_AircraftEngine = null;
				this.Cursor = CursorHelper.CursorDefault;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Select_Aircraft_Model_Engine_Error: {Information.Err().Number.ToString()} {excep.Message}");
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
			}

		} // Select_Aircraft_Engine

		public bool Insert_Aircraft_Model_Engine(string sEngineName)
		{
			bool result = false;

			string Query = "Insert into Aircraft_Model_Engine (ameng_amod_id, ameng_engine_model_id, ameng_engine_name, ameng_mfr_name, ameng_mfr_name_abbrev, ameng_mfr_comp_id, ";
			Query = $"{Query}ameng_engine_prefix, ameng_engine_core, ameng_engine_suffix1, ameng_engine_suffix2, ameng_takeoff_power, ameng_max_continuous_power, ameng_seq_no, ameng_active_flag)";
			Query = $"{Query} VALUES ({Convert.ToString(snp_Model["amod_id"])},";

			if (Convert.ToString(lbl_specs[93].Tag) == "")
			{
				lbl_specs[93].Tag = "0";
			} // Engine Model Id
			Query = $"{Query} {Convert.ToString(lbl_specs[93].Tag)}, ";

			Query = $"{Query}'{sEngineName.Trim()}',";
			Query = $"{Query}'{modAdminCommon.Fix_Quote(txt_ameng_mfr_name).Trim().Substring(0, Math.Min(100, modAdminCommon.Fix_Quote(txt_ameng_mfr_name).Trim().Length))}',";
			Query = $"{Query}'{modAdminCommon.Fix_Quote(txt_ameng_mfr_name_short.Text.ToUpper()).Trim().Substring(0, Math.Min(4, modAdminCommon.Fix_Quote(txt_ameng_mfr_name_short.Text.ToUpper()).Trim().Length))}',";
			Query = $"{Query}{Convert.ToInt32(Double.Parse(txt_ameng_mfr_CompID.Text.Trim())).ToString()},";

			Query = $"{Query}'{modAdminCommon.Fix_Quote(txt_ameng_engine_prefix).Trim()}',";
			Query = $"{Query}'{modAdminCommon.Fix_Quote(txt_ameng_engine_core).Trim()}',";
			Query = $"{Query}'{modAdminCommon.Fix_Quote(txt_ameng_engine_suffix1).Trim()}',";
			Query = $"{Query}'{modAdminCommon.Fix_Quote(txt_ameng_engine_suffix2).Trim()}',";

			if (txt_ameng_takeoff_power.Text == "")
			{
				txt_ameng_takeoff_power.Text = "0";
			}
			Query = $"{Query} {txt_ameng_takeoff_power.Text}, ";

			if (txt_ameng_max_continuous_power.Text == "")
			{
				txt_ameng_max_continuous_power.Text = "0";
			}

			Query = $"{Query} {txt_ameng_max_continuous_power.Text}, ";
			Query = $"{Query} {Convert.ToInt32(Double.Parse($"{txt_ameng_seq_no.Text}")).ToString()}, ";

			if (Chk_ameng_active_flag.CheckState == CheckState.Checked)
			{
				Query = $"{Query}'Y')";
			}
			else
			{
				Query = $"{Query}'N')";
			}

			DbCommand TempCommand = null;
			TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
			UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
			TempCommand.CommandText = Query;
			//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
			TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
			UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
			TempCommand.ExecuteNonQuery();
			result = true;
			modAdminCommon.Table_Action_Log("Aircraft_Model_Engine");
			//Call Fill_Aircraft_Engine_List

			return result;
		}

		public bool Save_Engine_Data(string s_EngineName)
		{
			bool result = false;
			if (EngineStat == "Update")
			{
				if (Update_Aircraft_Model_Engine(s_EngineName, s_PrevEngineName))
				{
					result = true;
					modAdminCommon.Record_Event("Engine Model Change", $"Updated Engine Model: Changed AmodID-{Convert.ToString(snp_Model["amod_id"])} old_name: {s_PrevEngineName} new_name: {s_EngineName}");
				}
			}
			else
			{
				if (modAdminCommon.Exist($"SELECT * FROM Aircraft_Model_Engine WHERE ameng_amod_id = {Convert.ToString(snp_Model["amod_id"])} AND ameng_engine_name = '{s_EngineName.Trim()}'"))
				{
					MessageBox.Show("Engine Exists in Aircraft Model Engine Table - Insert Aborted", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
				{
					if (Insert_Aircraft_Model_Engine(s_EngineName))
					{
						result = true;
						modAdminCommon.Record_Event("Engine Model Change", $"Insert Engine Model: AmodID-{Convert.ToString(snp_Model["amod_id"])} new_name: {s_EngineName}");
					}
				}

			}

			pnl_Aircraft_Model_Engine_Add.Visible = false;

			return result;
		}

		public bool Update_Aircraft_Model_Engine(string sEngineName, string sPrevEngineName)
		{
			bool result = false;
			try
			{
				string Query = "";

				Query = "UPDATE Aircraft_Model_Engine SET ";

				// 08/08/2017 - By David D. Cruger; Added Engine Model Id

				if (Convert.ToString(lbl_specs[93].Tag) == "")
				{
					lbl_specs[93].Tag = "0";
				} // Engine Model Id
				Query = $"{Query} ameng_engine_model_id = {Convert.ToString(lbl_specs[93].Tag)},";

				Query = $"{Query} ameng_engine_name = '{sEngineName.Trim()}',";
				Query = $"{Query} ameng_mfr_name = '{modAdminCommon.Fix_Quote(txt_ameng_mfr_name).Trim().Substring(0, Math.Min(100, modAdminCommon.Fix_Quote(txt_ameng_mfr_name).Trim().Length))}',";
				Query = $"{Query} ameng_mfr_name_abbrev = '{modAdminCommon.Fix_Quote(txt_ameng_mfr_name_short.Text.ToUpper()).Trim().Substring(0, Math.Min(4, modAdminCommon.Fix_Quote(txt_ameng_mfr_name_short.Text.ToUpper()).Trim().Length))}',";
				Query = $"{Query} ameng_mfr_comp_id = {Convert.ToInt32(Double.Parse(txt_ameng_mfr_CompID.Text.Trim())).ToString()},";
				Query = $"{Query} ameng_engine_prefix = '{modAdminCommon.Fix_Quote(txt_ameng_engine_prefix).Trim()}',";
				Query = $"{Query} ameng_engine_core = '{modAdminCommon.Fix_Quote(txt_ameng_engine_core).Trim()}',";
				Query = $"{Query} ameng_engine_suffix1 = '{modAdminCommon.Fix_Quote(txt_ameng_engine_suffix1).Trim()}',";
				Query = $"{Query} ameng_engine_suffix2 = '{modAdminCommon.Fix_Quote(txt_ameng_engine_suffix2).Trim()}',";
				Query = $"{Query} ameng_takeoff_power = {Double.Parse($"{txt_ameng_takeoff_power.Text}").ToString()},";
				Query = $"{Query} ameng_max_continuous_power = {Double.Parse($"{txt_ameng_max_continuous_power.Text}").ToString()},";
				Query = $"{Query} ameng_seq_no = {Double.Parse($"{txt_ameng_seq_no.Text}").ToString()},";

				if (Chk_ameng_active_flag.CheckState == CheckState.Checked)
				{
					Query = $"{Query} ameng_active_flag = 'Y'";
				}
				else
				{
					Query = $"{Query} ameng_active_flag = 'N'";
				}

				Query = $"{Query} WHERE ameng_amod_id = {Convert.ToString(snp_Model["amod_id"])} AND ameng_engine_name = '{sPrevEngineName}'";

				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();

				return true;
			}
			catch
			{

				MessageBox.Show("Update_Aircraft_Model_Engine_Error:", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
			return result;
		}

		public void Delete_Aircraft_Model_Engine()
		{

			try
			{
				string Query = "";
				DialogResult intPress = (DialogResult) 0;

				if (snp_AircraftEngine.EOF && snp_AircraftEngine.BOF)
				{
					return;
				}

				snp_AircraftEngine.MoveFirst();
				int tempForEndVar = ListBoxHelper.GetSelectedIndex(lst_Spec_Engines);
				for (int i = 1; i <= tempForEndVar; i++)
				{
					snp_AircraftEngine.MoveNext();
				}

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(snp_AircraftEngine["ameng_engine_name"]))
				{
					if (Convert.ToString(snp_AircraftEngine["ameng_engine_name"]) == "")
					{

						MessageBox.Show("<No Engine Selected to Remove>", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

					}
					else
					{

						if (modAdminCommon.Exist($"SELECT * FROM Aircraft WHERE ac_amod_id = {Convert.ToString(snp_AircraftEngine["ameng_amod_id"])} AND ac_engine_name_search = '{StringsHelper.Replace(Convert.ToString(snp_AircraftEngine["ameng_engine_name"]).Trim(), modGlobalVars.cHyphen, modGlobalVars.cEmptyString, 1, -1, CompareMethod.Binary)}' AND ac_journ_id = 0"))
						{

							MessageBox.Show("Engine Exists on Aircraft Table - Delete Aborted", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							return;

						}
						else
						{

							MessageBox.Show("Engine Not Found on Aircraft Table - OK To Remove", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);

						}

						Query = "DELETE FROM Aircraft_Model_Engine";
						Query = $"{Query} WHERE ameng_engine_name = '{Convert.ToString(snp_AircraftEngine["ameng_engine_name"]).Trim()}'";
						Query = $"{Query} AND ameng_amod_id = {Convert.ToString(snp_Model["amod_id"])}";

						intPress = MessageBox.Show($"Engine Delete for Aircraft Model : {Convert.ToString(snp_AircraftEngine["ameng_engine_name"]).Trim().ToUpper()}", "Confirm Delete!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

						if (intPress == System.Windows.Forms.DialogResult.Yes)
						{

							DbCommand TempCommand = null;
							TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
							TempCommand.CommandText = Query;
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
							TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
							TempCommand.ExecuteNonQuery();
							Fill_Aircraft_Engine_List();

							MessageBox.Show("Delete Successfully Completed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);

						}
						else
						{
							MessageBox.Show("Delete Cancelled!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						}
					}
				}
			}
			catch (System.Exception excep)
			{

				snp_AircraftEngine = null;
				this.Cursor = CursorHelper.CursorDefault;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Delete_Aircraft_Model_Engine_Error: {Information.Err().Number.ToString()} {excep.Message}");
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
				return;
			}

		}

		//******************************************************************************
		public void Insert_Aircraft_Model()
		{

			string Query = "";
			string strQuery2 = "";
			string cnv_amod_type_code = "";
			ADORecordSetHelper snp_Nextamodid = new ADORecordSetHelper();
			ADORecordSetHelper snp_Nextacid = new ADORecordSetHelper();
			int nextacid = 0;
			StringBuilder tempserno = new StringBuilder();
			DialogResult intPress = (DialogResult) 0;
			int Next_Amod_id = 0;
			string strStatus = "";
			string strErrDesc = "";
			string strBCName = "";
			string strBCType = "";

			string strQuery1 = "";
			string strInsert1 = "";

			try
			{

				//BeginTrans
				modAdminCommon.ADO_Transaction("BeginTrans");

				strStatus = "Max";

				// Get Next AModId Value
				strQuery1 = "SELECT MAX(amod_id)+1 AS NextAModId FROM Aircraft_Model WITH (NOLOCK) ";
				snp_Nextamodid.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
				Next_Amod_id = Convert.ToInt32(snp_Nextamodid["NextAModId"]);
				snp_Nextamodid.Close();

				txt_amod_make_name.Focus();
				cnv_amod_type_code = cbo_amod_type_code.Text.Substring(Math.Min(0, cbo_amod_type_code.Text.Length), Math.Min(1, Math.Max(0, cbo_amod_type_code.Text.Length)));

				Query = "INSERT INTO Aircraft_Model (";
				Query = $"{Query}amod_id, ";
				Query = $"{Query}amod_airframe_type_code, ";
				Query = $"{Query}amod_type_code, ";
				Query = $"{Query}amod_make_name, ";
				Query = $"{Query}amod_model_name, ";
				Query = $"{Query}amod_model_abbrev, ";
				Query = $"{Query}amod_make_abbrev, ";
				Query = $"{Query}amod_class_code, ";
				Query = $"{Query}amod_weight_class, ";
				Query = $"{Query}amod_manufacturer, ";
				Query = $"{Query}amod_manufacturer_common_name, ";
				Query = $"{Query}amod_manufacturer_comp_id, ";
				Query = $"{Query}amod_start_year, ";
				Query = $"{Query}amod_end_year, ";
				Query = $"{Query}amod_start_price, ";
				Query = $"{Query}amod_end_price, ";
				Query = $"{Query}amod_description, ";
				Query = $"{Query}amod_ser_no_prefix, ";
				Query = $"{Query}amod_ser_no_start, ";
				Query = $"{Query}amod_ser_no_end, ";
				Query = $"{Query}amod_ser_no_suffix, ";
				Query = $"{Query}amod_customer_flag, ";
				Query = $"{Query}amod_serno_hyphen_flag, ";
				Query = $"{Query}amod_ent_user_id, ";
				Query = $"{Query}amod_ent_date, ";
				Query = $"{Query}amod_upd_user_id, ";
				Query = $"{Query}amod_upd_date, ";

				Query = $"{Query}amod_product_business_flag, ";
				Query = $"{Query}amod_product_helicopter_flag, ";
				Query = $"{Query}amod_product_commercial_flag, ";
				Query = $"{Query}amod_product_airbp_flag, ";

				Query = $"{Query}amod_common_verify_days, ";
				Query = $"{Query}amod_sale_verify_days, ";

				Query = $"{Query}amod_body_config, ";
				Query = $"{Query}amod_faa_model_id, ";

				// added MSW - 2/3/21-----------------
				Query = $"{Query}amod_icao_code ";

				Query = $"{Query}) values (";

				Query = $"{Query}{Next_Amod_id.ToString()},";
				Query = $"{Query}'{cbo_amod_Airframe_Type_Code.Text.Substring(0, Math.Min(1, cbo_amod_Airframe_Type_Code.Text.Length))}',";
				Query = $"{Query}'{cnv_amod_type_code.Trim()}',";
				Query = $"{Query}'{txt_amod_make_name.Text.Trim()}',";
				Query = $"{Query}'{txt_amod_model_name.Text.Trim()}',";
				Query = $"{Query}'{txt_amod_model_abbrev.Text.Trim()}',";
				Query = $"{Query}'{txt_amod_make_abbrev.Text.Trim()}',";
				Query = $"{Query}'{cbo_amod_class.Text.Trim()}',";
				Query = $"{Query}'{cboWeightClass.Text.Substring(0, Math.Min(1, cboWeightClass.Text.Length))}',";

				// 1/23/2009 - By David D. Cruger
				// Added amod_manufacturer_comp_id AND made into a control array
				Query = $"{Query}'{txt_amod_manufacturer[0].Text.Trim()}',";
				Query = $"{Query}'{txt_amod_manufacturer[1].Text.Trim()}',";
				Query = $"{Query}{Convert.ToInt32(Conversion.Val(txt_amod_manufacturer[2].Text)).ToString().Trim()},";

				Query = $"{Query}'{txt_amod_start_year.Text.Trim()}',";
				Query = $"{Query}'{txt_amod_end_year.Text.Trim()}',";

				if (txt_amod_start_price.Text.Trim() != "")
				{
					Query = $"{Query}'{StringsHelper.Replace(txt_amod_start_price.Text, ",", "", 1, -1, CompareMethod.Binary).Trim()}',";
				}
				else
				{
					Query = $"{Query}NULL,";
				}
				if (txt_amod_end_price.Text.Trim() != "")
				{
					Query = $"{Query}'{StringsHelper.Replace(txt_amod_end_price.Text, ",", "", 1, -1, CompareMethod.Binary).Trim()}',";
				}
				else
				{
					Query = $"{Query}NULL,";
				}

				Query = $"{Query}'{txt_amod_description.Text.Trim()}',";
				Query = $"{Query}'{txt_amod_ser_no_prefix.Text.Trim()}',";
				Query = $"{Query}'{txt_amod_ser_no_start.Text.Trim()}',";
				Query = $"{Query}'{txt_amod_ser_no_end.Text.Trim()}',";
				Query = $"{Query}'{txt_amod_ser_no_suffix.Text.Trim()}',";


				Query = $"{Query}'N', ";

				if (chk_amod_hyphen_flag.CheckState == CheckState.Checked)
				{
					Query = $"{Query}'Y', ";
				}
				else
				{
					Query = $"{Query}'N', ";
				}

				// Entry Date
				Query = $"{Query}'{modAdminCommon.gbl_User_ID}', ";
				Query = $"{Query}GetDate(), ";
				// Update Date
				Query = $"{Query}'{modAdminCommon.gbl_User_ID}', ";
				Query = $"{Query}GetDate(), ";

				if (chk_amod_product[modGlobalVars.CHK_BUSINESS_IDX].CheckState == CheckState.Checked)
				{
					Query = $"{Query}'Y',";
				}
				else
				{
					Query = $"{Query}'N',";
				}

				if (chk_amod_product[modGlobalVars.CHK_HELICOPTER_IDX].CheckState == CheckState.Checked)
				{
					Query = $"{Query}'Y',";
				}
				else
				{
					Query = $"{Query}'N',";
				}

				if (chk_amod_product[modGlobalVars.CHK_COMMERCIAL_IDX].CheckState == CheckState.Checked)
				{
					Query = $"{Query}'Y',";
				}
				else
				{
					Query = $"{Query}'N',";
				}

				if (chk_amod_product[modGlobalVars.CHK_AIRBP_IDX].CheckState == CheckState.Checked)
				{
					Query = $"{Query}'Y',";
				}
				else
				{
					Query = $"{Query}'N',";
				}

				// 01/13/2020 - By David D. Cruger
				Query = $"{Query}{txt_amod_common_verify_days.Text}, ";
				Query = $"{Query}{txt_amod_sale_verify_days.Text}, ";

				// 01/13/2020 - By David D. Cruger
				strBCName = cmbBodyConfig.Text;
				strBCType = modCommon.DLookUp("ambc_type", "Aircraft_Model_Body_Config", $"(ambc_name = '{strBCName}')");
				if (strBCType == "")
				{
					strBCType = "U";
				}
				Query = $"{Query}'{strBCType}', ";

				// amod_faa_model_id - Last Field No Comma
				Query = $"{Query}'{($"{txt_amod_fuselage_length[7].Text} ").Trim()}', ";

				// added MSW - 2/3/21
				Query = $"{Query}'{($"{txt_amod_icao.Text} ").Trim()}' ";

				Query = $"{Query})";

				strStatus = "insert model";

				// Insert Make Model into new table
				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();

				// INSERT A Default IFC - DAM
				Query = $"SELECT amfeat_amod_id FROM Aircraft_Model_Key_Feature WHERE (amfeat_amod_id = {Next_Amod_id.ToString()}) ";
				if (!modAdminCommon.Exist(Query))
				{

					strStatus = "insert ifc";
					strInsert1 = "INSERT INTO Aircraft_Model_Key_Feature (amfeat_amod_id, amfeat_feature_code, amfeat_seq_no, amfeat_standard_equip) ";
					strInsert1 = $"{strInsert1}VALUES ";
					strInsert1 = $"{strInsert1}({Next_Amod_id.ToString()},'DAM',1,'N') ";
					DbCommand TempCommand_2 = null;
					TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
					TempCommand_2.CommandText = strInsert1;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand_2.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
					TempCommand_2.ExecuteNonQuery();

				} // If Exist(Query) = False Then

				// INSERT A Default Usage
				Query = $"SELECT acmoduse_amod_id FROM Aircraft_model_Useage WHERE (acmoduse_amod_id = {Next_Amod_id.ToString()}) ";
				if (!modAdminCommon.Exist(Query))
				{

					strStatus = "insert usage";
					if (chk_amod_product[modGlobalVars.CHK_COMMERCIAL_IDX].CheckState == CheckState.Checked)
					{
						strInsert1 = $"INSERT INTO Aircraft_Model_Useage (acmoduse_amod_id,acmoduse_use_code) values({Next_Amod_id.ToString()},'A') ";
						DbCommand TempCommand_3 = null;
						TempCommand_3 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_3);
						TempCommand_3.CommandText = strInsert1;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand_3.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_3);
						TempCommand_3.ExecuteNonQuery();
					}

					if (chk_amod_product[modGlobalVars.CHK_BUSINESS_IDX].CheckState == CheckState.Checked || chk_amod_product[modGlobalVars.CHK_HELICOPTER_IDX].CheckState == CheckState.Checked)
					{
						strInsert1 = $"INSERT INTO Aircraft_Model_Useage (acmoduse_amod_id,acmoduse_use_code) values({Next_Amod_id.ToString()},'B') ";
						DbCommand TempCommand_4 = null;
						TempCommand_4 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_4);
						TempCommand_4.CommandText = strInsert1;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand_4.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_4);
						TempCommand_4.ExecuteNonQuery();
					}

				} // If Exist(Query) = False Then

				strStatus = "Serial Number";
				if (Information.IsNumeric(txt_amod_ser_no_start.Text) && Information.IsNumeric(txt_amod_ser_no_end.Text))
				{
					intPress = MessageBox.Show(" Do you want to create Aircraft Records for Start/End range ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo);
					if (intPress == System.Windows.Forms.DialogResult.Yes)
					{
						Query = "select max(ac_id) as max_ac_id from Aircraft WITH(NOLOCK) ";
						//Set snp_nextacid = LOCAL_DB.OpenRecordset(Query, dbOpenSnapshot, dbSQLPassThrough)
						snp_Nextacid.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

						snp_Nextacid.MoveFirst();
						nextacid = Convert.ToInt32(Convert.ToDouble(snp_Nextacid["max_ac_id"]) + 1);
						double tempForEndVar = Math.Floor(Double.Parse(txt_amod_ser_no_end.Text));
						for (int i = Convert.ToInt32(Math.Floor(Double.Parse(txt_amod_ser_no_start.Text))); i <= tempForEndVar; i++)
						{
							tempserno = new StringBuilder(txt_amod_ser_no_prefix.Text.Trim());
							tempserno.Append(i.ToString());
							tempserno.Append(txt_amod_ser_no_suffix.Text.Trim());

							Query = "INSERT INTO Aircraft (ac_id,ac_amod_id,ac_year,ac_ser_no_prefix,ac_ser_no,ac_ser_no_suffix,ac_status,ac_forsale_flag,ac_ser_no_full) values (";
							Query = $"{Query}{nextacid.ToString()},";
							Query = $"{Query}{Next_Amod_id.ToString()},\"\",'{txt_amod_ser_no_prefix.Text.Trim()} ','{txt_amod_ser_no_start.Text.Trim()} ','{txt_amod_ser_no_suffix.Text.Trim()} ','Not For Sale ','N','{tempserno.ToString()}')";

							//LOCAL_DB.Execute Query, dbSQLPassThrough
							DbCommand TempCommand_5 = null;
							TempCommand_5 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_5);
							TempCommand_5.CommandText = Query;
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
							TempCommand_5.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_5);
							TempCommand_5.ExecuteNonQuery();

							nextacid++;
							tempserno = new StringBuilder("");
						}
					}
				}

				tab_Aircraft_Model.Visible = true;
				int tempForEndVar2 = SSTabHelper.GetTabCount(tab_Aircraft_Model) - 1;
				for (int iCnt1 = 0; iCnt1 <= tempForEndVar2; iCnt1++)
				{
					SSTabHelper.SetTabVisible(tab_Aircraft_Model, iCnt1, true);
				}

				modAdminCommon.ADO_Transaction("CommitTrans");

				// 02/12/2013 - By David D. Cruger
				modAdminCommon.Record_Event("Insert Aircraft Model", $"Inserting Aircraft Model - AModId: {Next_Amod_id.ToString()} - {txt_amod_make_name.Text} {txt_amod_model_name.Text}");

				snp_Nextacid = null;
				snp_Nextamodid = null;
			}
			catch (System.Exception excep)
			{

				strErrDesc = excep.Message;
				modAdminCommon.ADO_Transaction("RollbackTrans");

				modAdminCommon.Record_Error($"Insert_Aircraft_Model_Error:{strStatus}", strErrDesc);

				MessageBox.Show($"Insert_Aircraft_Model_Error:{Environment.NewLine}{Environment.NewLine}Status: {strStatus}{Environment.NewLine}{Environment.NewLine}{strErrDesc}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		} // Insert_Aircraft_Model

		public void Select_Aircraft_Model_Key_Feature()
		{

			int i = 0;
			string FeatureName = "";

			try
			{

				lbl_FeatureDescription.Text = "";
				lbl_FeatureMessage.Text = "";

				// GET THE FEATURE NAME OUT OF THE GRID
				grd_Keyfeature.CurrentColumnIndex = 2;
				FeatureName = grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString();

				// DISPLAY THE CODE AND NAME TO THE LABEL
				grd_Keyfeature.CurrentColumnIndex = 1;
				lbl_FeatureMessage.Text = $"{($"{grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString()}").Trim()} - {($"{FeatureName}").Trim()}";

				// DISPLAY THE DESCIPTION TO THE LABEL
				grd_Keyfeature.CurrentColumnIndex = 6;
				lbl_FeatureDescription.Text = grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString();

				// DISPLAY THE FLAG FOR STANDARD EQUIPMENT
				grd_Keyfeature.CurrentColumnIndex = 3;
				if (($"{grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString()}").Trim() == "Y")
				{
					chkStandard.CheckState = CheckState.Checked;
				}
				else
				{
					chkStandard.CheckState = CheckState.Unchecked;
				}

				// DISPLAY THE STANDARD EQUIPMENT START SER NO
				grd_Keyfeature.CurrentColumnIndex = 4;
				if (($"{grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString()}").Trim() != "")
				{
					txtFeatStartSerNo.Text = ($"{grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString()}").Trim();
				}
				else
				{
					txtFeatStartSerNo.Text = "";
				}

				// DISPLAY THE STANDARD EQUIPMENT END SER NO
				grd_Keyfeature.CurrentColumnIndex = 5;
				if (($"{grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString()}").Trim() != "")
				{
					txtFeatEndSerNo.Text = ($"{grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString()}").Trim();
				}
				else
				{
					txtFeatEndSerNo.Text = "";
				}

				// DISPLAY THE INACTIVE DATE
				grd_Keyfeature.CurrentColumnIndex = 7;
				if (grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString().Trim() != "")
				{
					chk_Inactive_Feature_Code.CheckState = CheckState.Checked;
					KeyFeatureWasActive = false;
					txt_InactiveDate.Text = grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString().Trim();
					txt_InactiveDate.Visible = true;
				}
				else
				{
					chk_Inactive_Feature_Code.CheckState = CheckState.Unchecked;
					KeyFeatureWasActive = true;
					txt_InactiveDate.Text = "";
					txt_InactiveDate.Visible = false;
				}
			}
			catch
			{

				this.Cursor = CursorHelper.CursorDefault;
				modAdminCommon.Report_Error("Select_Key_Feature_Error: ");
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
				return;
			}

		}

		public void mnu_File_Logout_Click(Object eventSender, EventArgs eventArgs) => frm_Main_Menu.DefInstance.Close();


		private void pnl_FeatureDisplay_Click(Object eventSender, EventArgs eventArgs)
		{
			//   pnl_FeatureDisplay.Visible = False
		}

		private void pnl_MasterKeyFeatures_Click(Object eventSender, EventArgs eventArgs)
		{
			//   pnl_MasterKeyFeatures.Visible = False
		}

		public void Fill_Master_Key_Feature_List()
		{
			//******************************************************************************************


			lst_MasterKeyFeature.Items.Clear();
			string Query = "SELECT * ";
			Query = $"{Query}FROM Key_Feature WITH(NOLOCK) ";
			Query = $"{Query}WHERE kfeat_inactive_date IS NULL ";
			Query = $"{Query}ORDER BY kfeat_code ";
			snp_MasterFeature = new ADORecordSetHelper();
			snp_MasterFeature.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

			if (!(snp_MasterFeature.BOF && snp_MasterFeature.EOF))
			{
				snp_MasterFeature.MoveFirst();

				while(!snp_MasterFeature.EOF)
				{
					lst_MasterKeyFeature.AddItem($"{Convert.ToString(snp_MasterFeature["kfeat_code"]).Trim()}  {($"{Convert.ToString(snp_MasterFeature["kfeat_name"])} ").Trim()}");
					snp_MasterFeature.MoveNext();
				};
				// lst_MasterKeyFeature.ListIndex = 0
				//UPGRADE_ISSUE: (207) An invalid structure was generated in this location, inside Fill_Master_Key_Feature_List. Please check source code. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-207
				//cmd_button_array().Visible = False
			}

			this.Cursor = CursorHelper.CursorDefault;
			return;

			this.Cursor = CursorHelper.CursorDefault;
			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
			modAdminCommon.Report_Error($"fFill_Make_Model_List_Error: {Information.Err().Number.ToString()} {Information.Err().Description}");
			modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
			return;
		}

		private void txt_ameng_engine_core_Click(Object eventSender, EventArgs eventArgs) => ToolTipMain.SetToolTip(txt_ameng_engine_core, txt_ameng_engine_core.Text);


		private void txt_ameng_engine_prefix_Click(Object eventSender, EventArgs eventArgs) => ToolTipMain.SetToolTip(txt_ameng_engine_prefix, txt_ameng_engine_prefix.Text);


		private void txt_ameng_engine_suffix1_Click(Object eventSender, EventArgs eventArgs) => ToolTipMain.SetToolTip(txt_ameng_engine_suffix1, txt_ameng_engine_suffix1.Text);


		private void txt_ameng_engine_suffix2_Click(Object eventSender, EventArgs eventArgs) => ToolTipMain.SetToolTip(txt_ameng_engine_suffix2, txt_ameng_engine_suffix2.Text);


		private void txt_ameng_mfr_name_Click(Object eventSender, EventArgs eventArgs) => ToolTipMain.SetToolTip(txt_ameng_mfr_name, txt_ameng_mfr_name.Text);


		private void txt_amod_annual_hours_Leave(Object eventSender, EventArgs eventArgs)
		{
			if (Valid_OpCosts_Data())
			{
				txt_amod_annual_hours.Text = StringsHelper.Format(txt_amod_annual_hours.Text, "###,###,###,##0");
				Calculate_Bucket_Totals();
			}
		}

		//UPGRADE_NOTE: (7001) The following declaration (txt_amod_engine_com_tbo_hrs_KeyPress) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void txt_amod_engine_com_tbo_hrs_KeyPress(ref int KeyAscii)
		//{
			//string char_Renamed = Strings.Chr(KeyAscii).ToString();
			//if (char_Renamed.Trim() == "" || KeyAscii <= 13)
			//{
				//return;
			//}
			//if (String.CompareOrdinal(char_Renamed, "0") < 0 || String.CompareOrdinal(char_Renamed, "9") > 0)
			//{
				//KeyAscii = 0;
			//}
		//}

		private void txt_amod_fuselage_length_Leave(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.txt_amod_fuselage_length, eventSender);
			switch(Index)
			{
				case 7 :  // FAA Model Id 
					 
					break;
			}
		}

		private void txt_amod_make_abbrev_Click(Object eventSender, EventArgs eventArgs) => ToolTipMain.SetToolTip(txt_amod_make_abbrev, txt_amod_make_abbrev.Text);


		private void txt_amod_make_abbrev_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{
				//UPGRADE_ISSUE: (1058) Assignment not supported: KeyAscii to a non-positive constant More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-1058
				KeyAscii = Strings.Asc(Strings.Chr(KeyAscii).ToString().ToUpper()[0]);
			}
			finally
			{
				if (KeyAscii == 0)
				{
					eventArgs.Handled = true;
				}
				eventArgs.KeyChar = Convert.ToChar(KeyAscii);
			}
		}

		private void txt_amod_make_name_Click(Object eventSender, EventArgs eventArgs) => ToolTipMain.SetToolTip(txt_amod_make_name, txt_amod_make_name.Text);


		private void txt_amod_make_name_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{
				//UPGRADE_ISSUE: (1058) Assignment not supported: KeyAscii to a non-positive constant More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-1058
				KeyAscii = Strings.Asc(Strings.Chr(KeyAscii).ToString().ToUpper()[0]);
			}
			finally
			{
				if (KeyAscii == 0)
				{
					eventArgs.Handled = true;
				}
				eventArgs.KeyChar = Convert.ToChar(KeyAscii);
			}
		}

		private void txt_amod_make_name_Leave(Object eventSender, EventArgs eventArgs)
		{
			txt_amod_make_name.Text = txt_amod_make_name.Text.ToUpper();

			if (Strings.Len(($"{txt_amod_make_abbrev.Text}").Trim()) == 0)
			{
				txt_amod_make_abbrev.Text = txt_amod_make_name.Text.Substring(0, Math.Min(2, txt_amod_make_name.Text.Length));
			}

		}

		private void txt_amod_manufacturer_TextChanged(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.txt_amod_manufacturer, eventSender);
			ToolTipMain.SetToolTip(txt_amod_manufacturer[Index], txt_amod_manufacturer[Index].Text);
		}

		private void txt_amod_model_abbrev_Click(Object eventSender, EventArgs eventArgs) => ToolTipMain.SetToolTip(txt_amod_model_abbrev, txt_amod_model_abbrev.Text);


		private void txt_amod_model_abbrev_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{
				//UPGRADE_ISSUE: (1058) Assignment not supported: KeyAscii to a non-positive constant More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-1058
				KeyAscii = Strings.Asc(Strings.Chr(KeyAscii).ToString().ToUpper()[0]);
			}
			finally
			{
				if (KeyAscii == 0)
				{
					eventArgs.Handled = true;
				}
				eventArgs.KeyChar = Convert.ToChar(KeyAscii);
			}
		}

		private void txt_amod_model_name_TextChanged(Object eventSender, EventArgs eventArgs)
		{
			if (cbo_amod_Airframe_Type_Code.Text.StartsWith("F", StringComparison.Ordinal))
			{
				txt_amod_model_name.Text = txt_amod_model_name.Text.ToUpper();
			}
		}

		private void txt_amod_model_name_Click(Object eventSender, EventArgs eventArgs) => ToolTipMain.SetToolTip(txt_amod_model_name, txt_amod_model_name.Text);



		private void txt_amod_model_name_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{
				if (cbo_amod_Airframe_Type_Code.Text.StartsWith("F", StringComparison.Ordinal))
				{
					//UPGRADE_ISSUE: (1058) Assignment not supported: KeyAscii to a non-positive constant More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-1058
					KeyAscii = Strings.Asc(Strings.Chr(KeyAscii).ToString().ToUpper()[0]);
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
		}

		private void txt_amod_model_name_Leave(Object eventSender, EventArgs eventArgs)
		{
			txt_amod_model_name.Text = ($"{txt_amod_model_name.Text}").ToUpper();

			if (Strings.Len(($"{txt_amod_model_abbrev.Text}").Trim()) == 0)
			{
				txt_amod_model_abbrev.Text = txt_amod_model_name.Text.Substring(0, Math.Min(10, txt_amod_model_name.Text.Length));
			}
		}


		private void txt_amod_prop_mfr_name_Click(Object eventSender, EventArgs eventArgs) => ToolTipMain.SetToolTip(txt_amod_prop_mfr_name, txt_amod_prop_mfr_name.Text);



		private void txt_amod_prop_model_name_Click(Object eventSender, EventArgs eventArgs) => ToolTipMain.SetToolTip(txt_amod_prop_model_name, txt_amod_prop_model_name.Text);



		private void txt_amod_ser_no_prefix_TextChanged(Object eventSender, EventArgs eventArgs) => txt_amod_ser_no_prefix.Text = txt_amod_ser_no_prefix.Text.ToUpper();


		private void txt_amod_ser_no_prefix_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{
				//UPGRADE_ISSUE: (1058) Assignment not supported: KeyAscii to a non-positive constant More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-1058
				KeyAscii = Strings.Asc(Strings.Chr(KeyAscii).ToString().ToUpper()[0]);
			}
			finally
			{
				if (KeyAscii == 0)
				{
					eventArgs.Handled = true;
				}
				eventArgs.KeyChar = Convert.ToChar(KeyAscii);
			}
		}

		private void txt_amod_ser_no_prefix_Leave(Object eventSender, EventArgs eventArgs)
		{
			//txt_amod_ser_no_prefix.Text = Format(txt_amod_ser_no_prefix, "0000000")
		}

		private void txt_amod_ser_no_suffix_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{
				//UPGRADE_ISSUE: (1058) Assignment not supported: KeyAscii to a non-positive constant More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-1058
				KeyAscii = Strings.Asc(Strings.Chr(KeyAscii).ToString().ToUpper()[0]);
			}
			finally
			{
				if (KeyAscii == 0)
				{
					eventArgs.Handled = true;
				}
				eventArgs.KeyChar = Convert.ToChar(KeyAscii);
			}
		}

		private void txt_amod_ser_no_suffix_Leave(Object eventSender, EventArgs eventArgs) => txt_amod_ser_no_suffix.Text = txt_amod_ser_no_suffix.Text.ToUpper();


		private void txt_amod_start_price_Leave(Object eventSender, EventArgs eventArgs)
		{
			if (txt_amod_start_price.Text.Trim() != "")
			{
				txt_amod_start_price.Text = StringsHelper.Format(txt_amod_start_price.Text, "###,###,###,##0");
			}
		}

		private void txt_amod_end_price_Leave(Object eventSender, EventArgs eventArgs)
		{

			if (txt_amod_end_price.Text.Trim() != "")
			{
				txt_amod_end_price.Text = StringsHelper.Format(txt_amod_end_price.Text, "###,###,###,##0");
			}

		}

		private void txt_amod_annual_miles_Leave(Object eventSender, EventArgs eventArgs)
		{
			if (Valid_OpCosts_Data())
			{
				txt_amod_annual_miles.Text = StringsHelper.Format(txt_amod_annual_miles.Text, "###,###,###,##0");
				Calculate_Bucket_Totals();
			}
		}

		private void txt_amod_avg_block_speed_Leave(Object eventSender, EventArgs eventArgs)
		{
			if (Valid_OpCosts_Data())
			{
				txt_amod_avg_block_speed.Text = StringsHelper.Format(txt_amod_avg_block_speed.Text, "###,###,###,##0");
				Calculate_Bucket_Totals();
			}
		}

		private void txt_amod_capt_salary_cost_Leave(Object eventSender, EventArgs eventArgs)
		{
			if (Valid_OpCosts_Data())
			{
				txt_amod_capt_salary_cost.Text = StringsHelper.Format(txt_amod_capt_salary_cost.Text, "###,###,###,##0");
				Calculate_Bucket_Totals();
			}
		}

		private void txt_amod_cpilot_salary_cost_Leave(Object eventSender, EventArgs eventArgs)
		{
			if (Valid_OpCosts_Data())
			{
				txt_amod_cpilot_salary_cost.Text = StringsHelper.Format(txt_amod_cpilot_salary_cost.Text, "###,###,###,##0");
				Calculate_Bucket_Totals();
			}
		}

		private void txt_amod_crew_benefit_cost_Leave(Object eventSender, EventArgs eventArgs)
		{
			if (Valid_OpCosts_Data())
			{
				txt_amod_crew_benefit_cost.Text = StringsHelper.Format(txt_amod_crew_benefit_cost.Text, "###,###,###,##0");
				Calculate_Bucket_Totals();
			}
		}

		private void txt_amod_crew_exp_cost_Leave(Object eventSender, EventArgs eventArgs)
		{
			if (Valid_OpCosts_Data())
			{
				txt_amod_crew_exp_cost.Text = StringsHelper.Format(txt_amod_crew_exp_cost.Text, "###,###,###,##0.00");
				Calculate_Bucket_Totals();
			}
		}

		private void txt_amod_deprec_cost_Leave(Object eventSender, EventArgs eventArgs)
		{
			if (Valid_OpCosts_Data())
			{
				txt_amod_deprec_cost.Text = StringsHelper.Format(txt_amod_deprec_cost.Text, "###,###,###,##0");
				Calculate_Bucket_Totals();
			}
		}

		private void txt_amod_engine_ovh_cost_Leave(Object eventSender, EventArgs eventArgs)
		{
			if (Valid_OpCosts_Data())
			{
				txt_amod_engine_ovh_cost.Text = StringsHelper.Format(txt_amod_engine_ovh_cost.Text, "###,###,###,##0.00");
				Calculate_Bucket_Totals();
			}
		}

		private void txt_amod_ent_user_id_TextChanged(Object eventSender, EventArgs eventArgs)
		{
			txt_amod_upd_user_id.Enabled = false;
			txt_amod_upd_date.Enabled = false;
		}

		private void txt_amod_fuel_add_cost_Leave(Object eventSender, EventArgs eventArgs)
		{
			if (Valid_OpCosts_Data())
			{
				txt_amod_fuel_add_cost.Text = StringsHelper.Format(txt_amod_fuel_add_cost.Text, "###,###,###,##0.00");
				Calculate_Bucket_Totals();
			}

		}

		private void txt_amod_fuel_burn_rate_Leave(Object eventSender, EventArgs eventArgs)
		{
			if (Valid_OpCosts_Data())
			{
				txt_amod_fuel_burn_rate.Text = StringsHelper.Format(txt_amod_fuel_burn_rate.Text, "###,###,###,##0.00");
				Calculate_Bucket_Totals();
			}

		}

		private void txt_amod_fuel_gal_cost_Leave(Object eventSender, EventArgs eventArgs)
		{
			if (Valid_OpCosts_Data())
			{
				txt_amod_fuel_gal_cost.Text = StringsHelper.Format(txt_amod_fuel_gal_cost.Text, "###,###,###,##0.00");
				Calculate_Bucket_Totals();
			}
		}

		private void Calculate_Bucket_Totals()
		{

			double dblTotalStatMile = 0;
			double dblTemp = 0;
			double dblAnnualHours = 0;
			double dblAnnTotalDirect = 0;
			double dblTotalFixedDirect = 0;
			double dblAnnCostHour = 0;
			double dblAnnCostStatMile = 0;
			double dblAnnCostSeatMile = 0;
			double dblAnnCostHrNoDprec = 0;
			double dblAnnCostStatMileNoDprec = 0;
			double dblAnnCostSeatMileNoDprec = 0;

			// calculate total fuel cost
			//If CDbl(txt_amod_fuel_burn_rate) > "0" Or CDbl(txt_amod_fuel_burn_rate) <> "" Then
			// 05/28/2008 - By David D. Cruger; Added () to combine fuel gal/cost + add cost before
			// multiplying by fuel burn
			double dblFuelTotCost = (Double.Parse(txt_amod_fuel_gal_cost.Text) + Double.Parse(txt_amod_fuel_add_cost.Text)) * Double.Parse(txt_amod_fuel_burn_rate.Text);
			dblFuelTotCost = Math.Round((double) dblFuelTotCost, 2);

			//Else
			txt_amod_fuel_tot_cost.Text = StringsHelper.Format(dblFuelTotCost, "###,##0.00");
			//End If

			// calculate total maintenance cost
			double dblPartsCosts = Double.Parse(txt_amod_maint_parts_cost.Text);

			double dblMaintTotCost = Double.Parse(txt_amod_maint_lab_cost.Text) + dblPartsCosts;
			dblMaintTotCost = Math.Round((double) dblMaintTotCost, 2);
			txt_amod_maint_tot_cost.Text = StringsHelper.Format(dblMaintTotCost, "###,##0.00");

			// calculate total Misc. Flight Expenses

			double dblLandParkCosts = Double.Parse(txt_amod_land_park_cost.Text);
			double dblMiscFlightCost = dblLandParkCosts + Double.Parse(txt_amod_crew_exp_cost.Text) + Double.Parse(txt_amod_supplies_cost.Text);
			dblMiscFlightCost = Math.Round((double) dblMiscFlightCost, 2);
			txt_amod_misc_flight_cost.Text = StringsHelper.Format(dblMiscFlightCost, "###,##0.00");

			// calculate Total Direct Cost
			double dblEngineOVHCost = Double.Parse(txt_amod_engine_ovh_cost.Text);
			// dblTotalDirectCost = dblFuelTotCost + dblMaintTotCost + dblMiscFlightCost + dblEngineOVHCost + CDbl(txt_amod_thrust_rev_ovh_cost.Text)
			double dblTotalDirectCost = dblFuelTotCost + dblMaintTotCost + dblEngineOVHCost + Double.Parse(txt_amod_thrust_rev_ovh_cost.Text);

			dblTotalDirectCost = Math.Round((double) dblTotalDirectCost, 2);
			txt_amod_tot_hour_direct_cost.Text = StringsHelper.Format(dblTotalDirectCost, "###,##0.00");
			//txt_amod_tot_direct_cost.Text = txt_amod_tot_hour_direct_cost.Text

			// calculate Total Direct Cost
			double dblavg_block_speed = Double.Parse(txt_amod_avg_block_speed.Text);
			if (dblavg_block_speed > 0)
			{
				dblTotalStatMile = dblTotalDirectCost / dblavg_block_speed;
				dblTotalStatMile = Math.Round((double) dblTotalStatMile, 2);
				txt_amod_tot_stat_mile_cost.Text = StringsHelper.Format(dblTotalStatMile, "###,##0.00");
			}
			else
			{
				txt_amod_tot_stat_mile_cost.Text = "0";
			}

			// calculate Crew Salaries
			double dblTotalCrewSalary = Double.Parse(txt_amod_capt_salary_cost.Text) + Double.Parse(txt_amod_cpilot_salary_cost.Text) + Double.Parse(txt_amod_crew_benefit_cost.Text);
			dblTotalCrewSalary = Math.Round((double) dblTotalCrewSalary, 0);
			txt_amod_tot_crew_salary_cost.Text = StringsHelper.Format(dblTotalCrewSalary, "###,##0");

			// calculate Insurance
			if (txt_amod_hull_insurance_cost.Text == "")
			{
				txt_amod_hull_insurance_cost.Text = "0";
			}

			double dblTotalInsurance = Double.Parse(txt_amod_hull_insurance_cost.Text) + Double.Parse(txt_amod_liability_insurance_cost.Text);
			dblTotalInsurance = Math.Round((double) dblTotalInsurance, 0);
			txt_amod_insurance_cost.Text = StringsHelper.Format(dblTotalInsurance, "###,##0");

			// calculate Misc. Overhead
			double dblTotalMiscOverhead = Double.Parse(txt_amod_misc_train_cost.Text) + Double.Parse(txt_amod_misc_modern_cost.Text) + Double.Parse(txt_amod_misc_naveq_cost.Text);
			dblTotalMiscOverhead = Math.Round((double) dblTotalMiscOverhead, 0);
			txt_amod_tot_misc_ovh_cost.Text = StringsHelper.Format(dblTotalMiscOverhead, "###,##0");

			// calculate Total Fixed Cost
			if (txt_amod_hangar_cost.Text.Trim() != "" && txt_amod_deprec_cost.Text.Trim() != "")
			{
				dblTemp = Double.Parse(txt_amod_hangar_cost.Text) + Double.Parse(txt_amod_deprec_cost.Text);
			}
			else if (txt_amod_hangar_cost.Text.Trim() != "")
			{ 
				dblTemp = Double.Parse(txt_amod_hangar_cost.Text) + Convert.ToDouble(0);
			}
			else if (txt_amod_deprec_cost.Text.Trim() != "")
			{ 
				dblTemp = Convert.ToDouble(0) + Double.Parse(txt_amod_deprec_cost.Text);
			}
			else
			{

			}
			double dblTotalFixed = dblTotalCrewSalary + dblTotalInsurance + dblTotalMiscOverhead + dblTemp;
			dblTotalFixed = Math.Round((double) dblTotalFixed, 0);
			txt_amod_tot_fixed_cost.Text = StringsHelper.Format(dblTotalFixed, "###,##0");

			// calculate annual hours
			dblTemp = Double.Parse(txt_amod_avg_block_speed.Text);
			if (dblTemp > 0)
			{
				dblAnnualHours = Math.Round((double) (Double.Parse(txt_amod_annual_miles.Text) / dblTemp), 0);
				dblAnnualHours = Math.Round((double) dblAnnualHours, 0);
				txt_amod_annual_hours.Text = StringsHelper.Format(dblAnnualHours, "##0");
			}

			// 02/09/2018 - By David D. Cruger
			double dblTotalVariableCosts = (Double.Parse(txt_amod_fuel_tot_cost.Text) + Double.Parse(txt_amod_maint_lab_cost.Text) + Double.Parse(txt_amod_maint_parts_cost.Text)) * Double.Parse(txt_amod_annual_hours.Text);
			txt_amod_tot_variable_cost.Text = StringsHelper.Format(dblTotalVariableCosts, "###,##0.00");

			// added IN MSW - 5/11/21
			int temp_misc_hours = Convert.ToInt32(Double.Parse(txt_amod_misc_flight_cost.Text));
			int annual_hours = Convert.ToInt32(Double.Parse(txt_amod_annual_hours.Text));

			txt_var_misc.Text = StringsHelper.Format(dblTotalVariableCosts + (temp_misc_hours * annual_hours), "###,##0");

			// calculate annual Total Direct Cost

			if (dblAnnualHours > 0)
			{
				dblAnnTotalDirect = dblAnnualHours * dblTotalDirectCost;
				dblAnnTotalDirect = Math.Round((double) dblAnnTotalDirect, 0);
				txt_amod_tot_direct_cost.Text = StringsHelper.Format(dblAnnTotalDirect, "###,##0");
			}
			else if (cbo_amod_Airframe_Type_Code.Text.StartsWith("R", StringComparison.Ordinal))
			{ 
				dblAnnTotalDirect = Math.Round((double) dblAnnTotalDirect, 0);
				txt_amod_tot_direct_cost.Text = StringsHelper.Format(dblTotalDirectCost, "###,##0");
			}

			// calculate annual Total Fixed Cost
			if (dblAnnTotalDirect > 0)
			{
				dblTotalFixedDirect = dblTotalFixed + dblAnnTotalDirect;
				dblTotalFixedDirect = Math.Round((double) dblTotalFixedDirect, 0);
				txt_amod_tot_df_annual_cost.Text = StringsHelper.Format(dblTotalFixedDirect, "###,##0");
			}

			// calculate annual Total Fixed Cost

			txt_amod_tot_fixed_cost2.Text = StringsHelper.Format(dblTotalFixed, "###,##0.00");

			// calculate annual Cost/Hour
			if (dblAnnualHours > 0)
			{
				dblAnnCostHour = dblTotalFixedDirect / dblAnnualHours;
				dblAnnCostHour = Math.Round((double) dblAnnCostHour, 0);
				txt_amod_tot_df_hour_cost.Text = StringsHelper.Format(dblAnnCostHour, "###,##0");
			}

			// calculate annual cost statute mile
			dblTemp = Double.Parse(txt_amod_annual_miles.Text);
			if (dblTemp > 0)
			{
				dblAnnCostStatMile = dblTotalFixedDirect / dblTemp;
				dblAnnCostStatMile = Math.Round((double) dblAnnCostStatMile, 2);
				txt_amod_tot_df_statmile_cost.Text = StringsHelper.Format(dblAnnCostStatMile, "###,##0.00");
			}

			// calculate annual Cost/Seat Mile
			dblTemp = Double.Parse(txt_amod_number_of_seats.Text);
			if (dblTemp > 0)
			{
				dblAnnCostSeatMile = dblAnnCostStatMile / dblTemp;
				dblAnnCostSeatMile = Math.Round((double) dblAnnCostSeatMile, 2);
				txt_amod_tot_df_seat_cost.Text = StringsHelper.Format(dblAnnCostSeatMile, "###,##0.00");
			}

			// calculate Total Cost/No depreciation
			dblTemp = Double.Parse(txt_amod_deprec_cost.Text);
			double dblAnnTotCostNoDprec = dblTotalFixedDirect - dblTemp;
			dblAnnTotCostNoDprec = Math.Round((double) dblAnnTotCostNoDprec, 0);
			txt_amod_tot_nd_annual_cost.Text = StringsHelper.Format(dblAnnTotCostNoDprec, "###,##0");

			// calculate Cost per Hour/No depreciation
			if (dblAnnualHours > 0)
			{
				dblAnnCostHrNoDprec = dblAnnTotCostNoDprec / dblAnnualHours;
				dblAnnCostHrNoDprec = Math.Round((double) dblAnnCostHrNoDprec, 0);
				txt_amod_tot_nd_hour_cost.Text = StringsHelper.Format(dblAnnCostHrNoDprec, "###,##0");
			}

			// calculate Cost Statute Mile/No depreciation
			dblTemp = Double.Parse(txt_amod_annual_miles.Text);
			if (dblTemp > 0)
			{
				dblAnnCostStatMileNoDprec = dblAnnTotCostNoDprec / dblTemp;
				dblAnnCostStatMileNoDprec = Math.Round((double) dblAnnCostStatMileNoDprec, 2);
				txt_amod_tot_nd_statmile_cost.Text = StringsHelper.Format(dblAnnCostStatMileNoDprec, "###,##0.00");
			}

			// calculate Cost/Seat per mile/No depreciation
			dblTemp = Double.Parse(txt_amod_number_of_seats.Text);
			if (dblTemp > 0)
			{
				dblAnnCostSeatMileNoDprec = dblAnnCostStatMileNoDprec / dblTemp;
				txt_amod_tot_nd_seat_cost.Text = StringsHelper.Format(dblAnnCostSeatMileNoDprec, "###,##0.00");
				dblAnnCostStatMileNoDprec = Math.Round((double) dblAnnCostStatMileNoDprec, 2);

			}
			Application.DoEvents();
		}

		private bool Valid_OpCosts_Data()
		{

			bool result = false;
			try
			{

				result = true;

				if (!Information.IsNumeric(Double.Parse(txt_amod_fuel_add_cost.Text)))
				{
					result = false;
					MessageBox.Show("Fuel Add Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					txt_amod_fuel_add_cost.Focus();
				}

				if (!Information.IsNumeric(Double.Parse(txt_amod_fuel_gal_cost.Text)))
				{
					result = false;
					MessageBox.Show("Cost/Gallon Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					txt_amod_fuel_gal_cost.Focus();
				}

				if (!Information.IsNumeric(Double.Parse(txt_amod_fuel_burn_rate.Text)))
				{
					result = false;
					MessageBox.Show("Burn/Hour Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					txt_amod_fuel_burn_rate.Focus();
				}

				if (!Information.IsNumeric(Double.Parse(txt_amod_maint_lab_cost.Text)))
				{
					result = false;
					MessageBox.Show("Maint. Labor/Hour Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					txt_amod_maint_lab_cost.Focus();
				}

				if (!Information.IsNumeric(Double.Parse(txt_amod_maint_labor_man_hour_multiplier.Text)))
				{
					result = false;
					MessageBox.Show("Maint. Labor/Man Hour Multiplier Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					txt_amod_maint_labor_man_hour_multiplier.Focus();
				}

				if (!Information.IsNumeric(Double.Parse(txt_amod_maint_parts_cost.Text)))
				{
					result = false;
					MessageBox.Show("Maint. Parts/Hour Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					txt_amod_maint_parts_cost.Focus();
				}

				if (!Information.IsNumeric(Double.Parse(txt_amod_maint_parts_man_hour_multiplier.Text)))
				{
					result = false;
					MessageBox.Show("Maint. Parts/Man Hour Multiplier Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					txt_amod_maint_parts_man_hour_multiplier.Focus();
				}

				if (!Information.IsNumeric(Double.Parse(txt_amod_engine_ovh_cost.Text)))
				{
					result = false;
					MessageBox.Show("Engine Overhaul Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					txt_amod_engine_ovh_cost.Focus();
				}

				if (!Information.IsNumeric(Double.Parse(txt_amod_thrust_rev_ovh_cost.Text)))
				{
					result = false;
					MessageBox.Show("Thrust Reverse Overhaul Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					txt_amod_thrust_rev_ovh_cost.Focus();
				}

				if (!Information.IsNumeric(Double.Parse(txt_amod_land_park_cost.Text)))
				{
					result = false;
					MessageBox.Show("Land/Parking Fee Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					txt_amod_land_park_cost.Focus();
				}

				if (!Information.IsNumeric(Double.Parse(txt_amod_crew_exp_cost.Text)))
				{
					result = false;
					MessageBox.Show("Crew Expenses Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					txt_amod_crew_exp_cost.Focus();
				}

				if (!Information.IsNumeric(Double.Parse(txt_amod_supplies_cost.Text)))
				{
					result = false;
					MessageBox.Show("Supplies Catering Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					txt_amod_supplies_cost.Focus();
				}

				if (!Information.IsNumeric(Double.Parse(txt_amod_avg_block_speed.Text)))
				{
					result = false;
					MessageBox.Show("Block Speed Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					txt_amod_avg_block_speed.Focus();
				}

				if (!Information.IsNumeric(Double.Parse(txt_amod_capt_salary_cost.Text)))
				{
					result = false;
					MessageBox.Show("Capt. Salary Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					txt_amod_capt_salary_cost.Focus();
				}

				if (!Information.IsNumeric(Double.Parse(txt_amod_cpilot_salary_cost.Text)))
				{
					result = false;
					MessageBox.Show("Copilot Salary Salary Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					txt_amod_cpilot_salary_cost.Focus();
				}

				if (!Information.IsNumeric(Double.Parse(txt_amod_crew_benefit_cost.Text)))
				{
					result = false;
					MessageBox.Show("Benefits Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					txt_amod_crew_benefit_cost.Focus();
				}

				if (!Information.IsNumeric(Double.Parse(txt_amod_hangar_cost.Text)))
				{
					result = false;
					MessageBox.Show("Hangar Cost Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					txt_amod_hangar_cost.Focus();
				}

				if (!Information.IsNumeric(Double.Parse(txt_amod_hull_insurance_cost.Text)))
				{
					result = false;
					MessageBox.Show("Hull Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					txt_amod_hull_insurance_cost.Focus();
				}

				if (!Information.IsNumeric(Double.Parse(txt_amod_liability_insurance_cost.Text)))
				{
					result = false;
					MessageBox.Show("Legal Liability Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					txt_amod_liability_insurance_cost.Focus();
				}

				if (!Information.IsNumeric(Double.Parse(txt_amod_misc_train_cost.Text)))
				{
					result = false;
					MessageBox.Show("Training Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					txt_amod_misc_train_cost.Focus();
				}

				if (!Information.IsNumeric(Double.Parse(txt_amod_misc_modern_cost.Text)))
				{
					result = false;
					MessageBox.Show("Modernization Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					txt_amod_misc_modern_cost.Focus();
				}

				if (!Information.IsNumeric(Double.Parse(txt_amod_misc_naveq_cost.Text)))
				{
					result = false;
					MessageBox.Show("Nav. Equipment Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					txt_amod_misc_naveq_cost.Focus();
				}

				if (!Information.IsNumeric(Double.Parse(txt_amod_deprec_cost.Text)))
				{
					result = false;
					MessageBox.Show("Depreciation Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					txt_amod_deprec_cost.Focus();
				}

				if (!Information.IsNumeric(Double.Parse(txt_amod_number_of_seats.Text)))
				{
					result = false;
					MessageBox.Show("Passengers Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					txt_amod_number_of_seats.Focus();
				}

				if (!Information.IsNumeric(Double.Parse(txt_amod_annual_miles.Text)))
				{
					result = false;
					MessageBox.Show("Miles Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					txt_amod_annual_miles.Focus();
				}
			}
			catch
			{

				result = false;
			}

			return result;
		}

		private bool Valid_Specs_Data()
		{

			bool result = false;
			result = true;

			if (!Information.IsNumeric(Double.Parse(txt_amod_number_of_engines.Text)))
			{
				result = false;
				MessageBox.Show("Number Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txt_amod_number_of_engines.Focus();
			}
			else
			{
				txt_amod_number_of_engines.Text = Double.Parse(txt_amod_number_of_engines.Text).ToString();
			}

			if (!Information.IsNumeric(Double.Parse(txt_amod_prop_shaft.Text)))
			{
				result = false;
				MessageBox.Show("Prop Shaft Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txt_amod_prop_shaft.Focus();
			}
			else
			{
				txt_amod_prop_shaft.Text = Double.Parse(txt_amod_prop_shaft.Text).ToString();
			}

			if (!Information.IsNumeric(Double.Parse(txt_amod_prop_hsi.Text)))
			{
				result = false;
				MessageBox.Show("Prop HSI Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txt_amod_prop_hsi.Focus();
			}
			else
			{
				txt_amod_prop_hsi.Text = Double.Parse(txt_amod_prop_hsi.Text).ToString();
			}

			if (!Information.IsNumeric(Double.Parse(txt_amod_engine_shaft.Text)))
			{
				result = false;
				MessageBox.Show("Engine Shaft Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txt_amod_engine_shaft.Focus();
			}
			else
			{
				txt_amod_engine_shaft.Text = Double.Parse(txt_amod_engine_shaft.Text).ToString();
			}

			if (!Information.IsNumeric(Double.Parse(txt_amod_engine_hsi.Text)))
			{
				result = false;
				MessageBox.Show("Engine HSI Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txt_amod_engine_hsi.Focus();
			}
			else
			{
				txt_amod_engine_hsi.Text = Double.Parse(txt_amod_engine_hsi.Text).ToString();
			}

			if (!Information.IsNumeric(Double.Parse(txt_amod_engine_thrust_lbs.Text)))
			{
				result = false;
				MessageBox.Show("Thrust per Engine Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txt_amod_engine_thrust_lbs.Focus();
			}
			else
			{
				txt_amod_engine_thrust_lbs.Text = Double.Parse(txt_amod_engine_thrust_lbs.Text).ToString();
			}

			if (!Information.IsNumeric(Double.Parse(cbo_tbo_list.Text)))
			{ //aey 6/2/04
				result = false;
				MessageBox.Show("Common (TBO)Hours Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				//txt_amod_engine_com_tbo_hrs.SetFocus
				cbo_tbo_list.Focus();
			}
			else
			{
				//txt_amod_engine_com_tbo_hrs = CDbl(txt_amod_engine_com_tbo_hrs)
				cbo_tbo_list.Text = Double.Parse(cbo_tbo_list.Text).ToString();
			}

			if (!Information.IsNumeric(Double.Parse(txt_amod_fuselage_length[0].Text)))
			{
				result = false;
				MessageBox.Show("Length Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txt_amod_fuselage_length[0].Focus();
			}
			else
			{
				txt_amod_fuselage_length[0].Text = Double.Parse(txt_amod_fuselage_length[0].Text).ToString();
			}

			if (!Information.IsNumeric(Double.Parse(txt_amod_fuselage_height.Text)))
			{
				result = false;
				MessageBox.Show("Height Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txt_amod_fuselage_height.Focus();
			}
			else
			{
				txt_amod_fuselage_height.Text = Double.Parse(txt_amod_fuselage_height.Text).ToString();
			}

			if (!Information.IsNumeric(Double.Parse(txt_amod_fuselage_wingspan.Text)))
			{
				result = false;
				MessageBox.Show("Wingspan Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txt_amod_fuselage_wingspan.Focus();
			}
			else
			{
				txt_amod_fuselage_wingspan.Text = Double.Parse(txt_amod_fuselage_wingspan.Text).ToString();
			}

			if (!Information.IsNumeric(Double.Parse(txt_amod_number_of_crew.Text)))
			{
				result = false;
				MessageBox.Show("Crew Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txt_amod_number_of_crew.Focus();
			}
			else
			{
				txt_amod_number_of_crew.Text = Double.Parse(txt_amod_number_of_crew.Text).ToString();
			}

			if ((!Information.IsNumeric(Double.Parse(txt_amod_number_of_passengers.Text))) && (txt_amod_number_of_passengers.Text.Trim() != ""))
			{
				result = false;
				MessageBox.Show("Passengers Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txt_amod_number_of_passengers.Focus();
			}
			else
			{
				txt_amod_number_of_passengers.Text = Double.Parse($"0{txt_amod_number_of_passengers.Text}").ToString();
			}

			if (!Information.IsNumeric(Double.Parse(txt_amod_pressure.Text)))
			{
				result = false;
				MessageBox.Show("Pressurization (psi) Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txt_amod_pressure.Focus();
			}
			else
			{
				txt_amod_pressure.Text = Double.Parse(txt_amod_pressure.Text).ToString();
			}

			if (!Information.IsNumeric(Double.Parse(txt_amod_max_ramp_weight.Text)))
			{
				result = false;
				MessageBox.Show("Max Ramp Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txt_amod_max_ramp_weight.Focus();
			}
			else
			{
				txt_amod_max_ramp_weight.Text = Double.Parse(txt_amod_max_ramp_weight.Text).ToString();
			}

			if (!Information.IsNumeric(Double.Parse(txt_amod_max_takeoff_weight.Text)))
			{
				result = false;
				MessageBox.Show("Max Takeoff Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txt_amod_max_takeoff_weight.Focus();
			}
			else
			{
				txt_amod_max_takeoff_weight.Text = Double.Parse(txt_amod_max_takeoff_weight.Text).ToString();
			}

			if (!Information.IsNumeric(Double.Parse(txt_amod_zero_fuel_weight.Text)))
			{
				result = false;
				MessageBox.Show("Zero Fuel Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txt_amod_zero_fuel_weight.Focus();
			}
			else
			{
				txt_amod_zero_fuel_weight.Text = Double.Parse(txt_amod_zero_fuel_weight.Text).ToString();
			}

			if (!Information.IsNumeric(Double.Parse(txt_amod_basic_op_weight.Text)))
			{
				result = false;
				MessageBox.Show("Basic Operating Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txt_amod_basic_op_weight.Focus();
			}
			else
			{
				txt_amod_basic_op_weight.Text = Double.Parse(txt_amod_basic_op_weight.Text).ToString();
			}

			if (!Information.IsNumeric(Double.Parse(txt_amod_basic_op_weight.Text)))
			{
				result = false;
				MessageBox.Show("Basic Operating Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txt_amod_basic_op_weight.Focus();
			}
			else
			{
				txt_amod_basic_op_weight.Text = Double.Parse(txt_amod_basic_op_weight.Text).ToString();
			}

			if (!Information.IsNumeric(txt_amod_max_landing_weight.Text))
			{
				result = false;
				MessageBox.Show("Max Landing Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txt_amod_max_landing_weight.Focus();
			}
			else
			{
				txt_amod_max_landing_weight.Text = Double.Parse(txt_amod_max_landing_weight.Text).ToString();
			}

			if (!Information.IsNumeric(txt_amod_fuel_cap_std_weight.Text))
			{
				result = false;
				MessageBox.Show("Standard lbs Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txt_amod_fuel_cap_std_weight.Focus();
			}
			else
			{
				txt_amod_fuel_cap_std_weight.Text = Double.Parse(txt_amod_fuel_cap_std_weight.Text).ToString();
			}

			if (!Information.IsNumeric(txt_amod_fuel_cap_std_gal.Text))
			{
				result = false;
				MessageBox.Show("Standard gal Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txt_amod_fuel_cap_std_gal.Focus();
			}
			else
			{
				txt_amod_fuel_cap_std_gal.Text = Double.Parse(txt_amod_fuel_cap_std_gal.Text).ToString();
			}

			if (!Information.IsNumeric(txt_amod_fuel_cap_opt_weight.Text))
			{
				result = false;
				MessageBox.Show("Optional lbs Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txt_amod_fuel_cap_opt_weight.Focus();
			}
			else
			{
				txt_amod_fuel_cap_opt_weight.Text = Double.Parse(txt_amod_fuel_cap_opt_weight.Text).ToString();
			}

			if (!Information.IsNumeric(txt_amod_fuel_cap_opt_gal.Text))
			{
				result = false;
				MessageBox.Show("Optional gal Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txt_amod_fuel_cap_opt_gal.Focus();
			}
			else
			{
				txt_amod_fuel_cap_opt_gal.Text = Double.Parse(txt_amod_fuel_cap_opt_gal.Text).ToString();
			}

			if (!Information.IsNumeric(txt_amod_takeoff_ali.Text))
			{
				result = false;
				MessageBox.Show("SLISABFL Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txt_amod_takeoff_ali.Focus();
			}
			else
			{
				txt_amod_takeoff_ali.Text = Double.Parse(txt_amod_takeoff_ali.Text).ToString();
			}

			if (!Information.IsNumeric(txt_amod_takeoff_500.Text))
			{
				result = false;
				MessageBox.Show("500 + 20CBFL Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txt_amod_takeoff_500.Focus();
			}
			else
			{
				txt_amod_takeoff_500.Text = Double.Parse(txt_amod_takeoff_500.Text).ToString();
			}

			if (!Information.IsNumeric(txt_amod_field_length.Text))
			{
				result = false;
				MessageBox.Show("FAA Field Length Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txt_amod_field_length.Focus();
			}
			else
			{
				txt_amod_field_length.Text = Double.Parse(txt_amod_field_length.Text).ToString();
			}

			if (!Information.IsNumeric(txt_amod_max_range_miles.Text))
			{
				result = false;
				MessageBox.Show("Max Range (MBAA IFR) Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txt_amod_max_range_miles.Focus();
			}
			else
			{
				txt_amod_max_range_miles.Text = Double.Parse(txt_amod_max_range_miles.Text).ToString();
			}

			if (!Information.IsNumeric(txt_amod_climb_normal_feet.Text))
			{
				result = false;
				MessageBox.Show("Normal (fpm) Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txt_amod_climb_normal_feet.Focus();
			}
			else
			{
				txt_amod_climb_normal_feet.Text = Double.Parse(txt_amod_climb_normal_feet.Text).ToString();
			}

			if (!Information.IsNumeric(txt_amod_climb_engout_feet.Text))
			{
				result = false;
				MessageBox.Show("Engine Out (fpm) Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txt_amod_climb_engout_feet.Focus();
			}
			else
			{
				txt_amod_climb_engout_feet.Text = Double.Parse(txt_amod_climb_engout_feet.Text).ToString();
			}

			if (!Information.IsNumeric(txt_amod_ceiling_feet.Text))
			{
				result = false;
				MessageBox.Show("Ceiling Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txt_amod_ceiling_feet.Focus();
			}
			else
			{
				txt_amod_ceiling_feet.Text = Double.Parse(txt_amod_ceiling_feet.Text).ToString();
			}

			if (!Information.IsNumeric(txt_amod_number_of_props.Text))
			{
				result = false;
				MessageBox.Show("Number of Props Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txt_amod_number_of_props.Focus();
			}
			else
			{
				txt_amod_number_of_props.Text = Double.Parse(txt_amod_number_of_props.Text).ToString();
			}

			if (!Information.IsNumeric(txt_amod_prop_com_tbo_hrs.Text))
			{
				result = false;
				MessageBox.Show("Com TBO Hours Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txt_amod_prop_mfr_name.Focus();
			}
			else
			{
				txt_amod_prop_com_tbo_hrs.Text = Double.Parse(txt_amod_prop_com_tbo_hrs.Text).ToString();
			}

			// Stall VS
			if (!Information.IsNumeric(txt_amod_speed[0].Text))
			{
				result = false;
				MessageBox.Show("Vs Clean Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txt_amod_speed[0].Focus();
			}
			else
			{
				txt_amod_speed[0].Text = Double.Parse(txt_amod_speed[0].Text).ToString();
			}

			// Stall VSO
			if (!Information.IsNumeric(txt_amod_speed[1].Text))
			{
				result = false;
				MessageBox.Show("Vso Landing Clean Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txt_amod_speed[1].Focus();
			}
			else
			{
				txt_amod_speed[1].Text = Double.Parse(txt_amod_speed[1].Text).ToString();
			}

			// Cruis Speed
			if (!Information.IsNumeric(txt_amod_speed[2].Text))
			{
				result = false;
				MessageBox.Show("Normal Cruise TAS Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txt_amod_speed[2].Focus();
			}
			else
			{
				txt_amod_speed[2].Text = Double.Parse(txt_amod_speed[2].Text).ToString();
			}

			// ' Vmo(MaxOp) IAS Max Speed
			if (!Information.IsNumeric(txt_amod_speed[3].Text))
			{
				result = false;
				MessageBox.Show("Vmo (Max Op) IAS Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txt_amod_speed[3].Focus();
			}
			else
			{
				txt_amod_speed[3].Text = Double.Parse(txt_amod_speed[3].Text).ToString();
			}

			// 07/28/2017 - By David D. Cruger; Added

			// V1 Takeoff Speed
			if (!Information.IsNumeric(txt_amod_speed[4].Text))
			{
				result = false;
				MessageBox.Show("VL Taqkeoff Speed Is Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txt_amod_speed[4].Focus();
			}
			else
			{
				txt_amod_speed[4].Text = Double.Parse(txt_amod_speed[4].Text).ToString();
			}

			// VFE Max Flap Ext Speed
			if (!Information.IsNumeric(txt_amod_speed[5].Text))
			{
				result = false;
				MessageBox.Show("VFE Max Flap Ext Speed Is Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txt_amod_speed[5].Focus();
			}
			else
			{
				txt_amod_speed[5].Text = Double.Parse(txt_amod_speed[5].Text).ToString();
			}

			// VFE Max Flap Ext Speed
			if (!Information.IsNumeric(txt_amod_speed[6].Text))
			{
				result = false;
				MessageBox.Show("VLE Max Land Gear Ext Speed Is Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txt_amod_speed[6].Focus();
			}
			else
			{
				txt_amod_speed[6].Text = Double.Parse(txt_amod_speed[6].Text).ToString();
			}

			// 08/02/2017 - By David D. Cruger; Added

			// Vne (MaxOp) IAS
			if (!Information.IsNumeric(txt_amod_speed[7].Text))
			{
				result = false;
				MessageBox.Show("Vne (MaxOp) IAS Is Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txt_amod_speed[7].Focus();
			}
			else
			{
				txt_amod_speed[7].Text = Double.Parse(txt_amod_speed[7].Text).ToString();
			}

			if (!Information.IsNumeric(txt_amod_max_range_miles.Text))
			{
				result = false;
				MessageBox.Show("Max Range Miles Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				txt_amod_max_range_miles.Focus();
			}
			else
			{
				txt_amod_max_range_miles.Text = Double.Parse(txt_amod_max_range_miles.Text).ToString();
			}
			// check the cabing dimensions
			// height ft/in
			if (txt_amod_fuselage_length[1].Text != "")
			{
				if (!Information.IsNumeric(txt_amod_fuselage_length[1].Text))
				{
					result = false;
					MessageBox.Show("Cabin height ft. not numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					txt_amod_fuselage_length[1].Focus();
				}
			}
			if (txt_amod_fuselage_length[2].Text != "")
			{
				if (!Information.IsNumeric(txt_amod_fuselage_length[2].Text))
				{
					result = false;
					MessageBox.Show("Cabin height in. not numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					txt_amod_fuselage_length[2].Focus();
				}
			}
			// length ft/in
			if (txt_amod_fuselage_length[3].Text != "")
			{
				if (!Information.IsNumeric(txt_amod_fuselage_length[3].Text))
				{
					result = false;
					MessageBox.Show("Cabin length ft. not numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					txt_amod_fuselage_length[3].Focus();
				}
			}
			if (txt_amod_fuselage_length[4].Text != "")
			{
				if (!Information.IsNumeric(txt_amod_fuselage_length[4].Text))
				{
					result = false;
					MessageBox.Show("Cabin length in. not numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					txt_amod_fuselage_length[4].Focus();
				}
			}
			// width ft/in
			if (txt_amod_fuselage_length[5].Text != "")
			{
				if (!Information.IsNumeric(txt_amod_fuselage_length[5].Text))
				{
					result = false;
					MessageBox.Show("Cabin width ft. not numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					txt_amod_fuselage_length[5].Focus();
				}
			}

			if (txt_amod_fuselage_length[6].Text != "")
			{
				if (!Information.IsNumeric(txt_amod_fuselage_length[6].Text))
				{
					result = false;
					MessageBox.Show("Cabin width in. not numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					txt_amod_fuselage_length[6].Focus();
				}
			}

			// 07/28/2017 - By David D. Cruger; Added
			if (txt_amod_fuselage_length[8].Text != "")
			{
				if (!Information.IsNumeric(txt_amod_fuselage_length[8].Text))
				{
					result = false;
					MessageBox.Show("Cabine Volume Is Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					txt_amod_fuselage_length[8].Focus();
				}
			}

			if (txt_amod_fuselage_length[9].Text != "")
			{
				if (!Information.IsNumeric(txt_amod_fuselage_length[9].Text))
				{
					result = false;
					MessageBox.Show("Baggage Volume Is Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					txt_amod_fuselage_length[9].Focus();
				}
			}

			return result;
		}

		private void txt_amod_hangar_cost_Leave(Object eventSender, EventArgs eventArgs)
		{
			if (Valid_OpCosts_Data())
			{
				txt_amod_hangar_cost.Text = StringsHelper.Format(txt_amod_hangar_cost.Text, "###,###,###,###");
				Calculate_Bucket_Totals();
			}
		}

		private void txt_amod_hull_insurance_cost_Leave(Object eventSender, EventArgs eventArgs)
		{
			if (Valid_OpCosts_Data())
			{
				txt_amod_hull_insurance_cost.Text = StringsHelper.Format(txt_amod_hull_insurance_cost.Text, "###,###,###,###");
				Calculate_Bucket_Totals();
			}
		}

		private void txt_amod_land_park_cost_Leave(Object eventSender, EventArgs eventArgs)
		{
			if (Valid_OpCosts_Data())
			{
				txt_amod_land_park_cost.Text = StringsHelper.Format(txt_amod_land_park_cost.Text, "###,###,###,##0.00");
				Calculate_Bucket_Totals();
			}
		}

		private void txt_amod_liability_insurance_cost_Leave(Object eventSender, EventArgs eventArgs)
		{
			if (Valid_OpCosts_Data())
			{
				txt_amod_liability_insurance_cost.Text = StringsHelper.Format(txt_amod_liability_insurance_cost.Text, "###,###,###,##0");
				Calculate_Bucket_Totals();
			}
		}

		private void txt_amod_maint_lab_cost_Leave(Object eventSender, EventArgs eventArgs)
		{
			if (Valid_OpCosts_Data())
			{
				txt_amod_maint_lab_cost.Text = StringsHelper.Format(txt_amod_maint_lab_cost.Text, "###,###,###,##0.00");
				Calculate_Bucket_Totals();
			}
		}

		private void txt_amod_maint_labor_man_hour_multiplier_Leave(Object eventSender, EventArgs eventArgs)
		{
			if (Valid_OpCosts_Data())
			{
				txt_amod_maint_labor_man_hour_multiplier.Text = StringsHelper.Format(txt_amod_maint_labor_man_hour_multiplier.Text, "#,##0.00");
			}
		}

		private void txt_amod_maint_parts_cost_Leave(Object eventSender, EventArgs eventArgs)
		{
			if (Valid_OpCosts_Data())
			{
				txt_amod_maint_parts_cost.Text = StringsHelper.Format(txt_amod_maint_parts_cost.Text, "###,###,###,##0.00");
				Calculate_Bucket_Totals();
			}
		}

		private void txt_amod_maint_parts_man_hour_multiplier_Leave(Object eventSender, EventArgs eventArgs)
		{
			if (Valid_OpCosts_Data())
			{
				txt_amod_maint_parts_man_hour_multiplier.Text = StringsHelper.Format(txt_amod_maint_parts_man_hour_multiplier.Text, "#,##0.00");
			}
		}

		private void txt_amod_misc_modern_cost_Leave(Object eventSender, EventArgs eventArgs)
		{
			if (Valid_OpCosts_Data())
			{
				txt_amod_misc_modern_cost.Text = StringsHelper.Format(txt_amod_misc_modern_cost.Text, "###,###,###,##0");
				Calculate_Bucket_Totals();
			}
		}

		private void txt_amod_misc_naveq_cost_Leave(Object eventSender, EventArgs eventArgs)
		{
			if (Valid_OpCosts_Data())
			{
				txt_amod_misc_naveq_cost.Text = StringsHelper.Format(txt_amod_misc_naveq_cost.Text, "###,###,###,##0");
				Calculate_Bucket_Totals();
			}
		}

		private void txt_amod_misc_train_cost_Leave(Object eventSender, EventArgs eventArgs)
		{
			if (Valid_OpCosts_Data())
			{
				txt_amod_misc_train_cost.Text = StringsHelper.Format(txt_amod_misc_train_cost.Text, "###,###,###,##0");
				Calculate_Bucket_Totals();
			}
		}

		private void txt_amod_number_of_seats_Leave(Object eventSender, EventArgs eventArgs)
		{
			if (Valid_OpCosts_Data())
			{
				txt_amod_number_of_seats.Text = StringsHelper.Format(txt_amod_number_of_seats.Text, "###,###,###,##0");
				Calculate_Bucket_Totals();
			}
		}

		private void txt_amod_supplies_cost_Leave(Object eventSender, EventArgs eventArgs)
		{
			if (Valid_OpCosts_Data())
			{
				txt_amod_supplies_cost.Text = StringsHelper.Format(txt_amod_supplies_cost.Text, "###,###,###,##0.00");
				Calculate_Bucket_Totals();
			}
		}

		private void txt_amod_thrust_rev_ovh_cost_Leave(Object eventSender, EventArgs eventArgs)
		{
			if (Valid_OpCosts_Data())
			{
				txt_amod_thrust_rev_ovh_cost.Text = StringsHelper.Format(txt_amod_thrust_rev_ovh_cost.Text, "###,###,###,##0.00");
				Calculate_Bucket_Totals();
			}
		}

		private void txt_amod_tot_crew_salary_cost_Leave(Object eventSender, EventArgs eventArgs) => txt_amod_tot_crew_salary_cost.Text = StringsHelper.Format(txt_amod_tot_crew_salary_cost.Text, "###,###,###,##0");


		private void txt_amod_tot_df_annual_cost_Leave(Object eventSender, EventArgs eventArgs) => txt_amod_tot_df_annual_cost.Text = StringsHelper.Format(txt_amod_tot_df_annual_cost.Text, "###,###,###,##0");


		private void txt_amod_tot_df_hour_cost_Leave(Object eventSender, EventArgs eventArgs) => txt_amod_tot_df_hour_cost.Text = StringsHelper.Format(txt_amod_tot_df_hour_cost.Text, "###,###,###,###");


		private void txt_amod_tot_df_seat_cost_Leave(Object eventSender, EventArgs eventArgs) => txt_amod_tot_df_seat_cost.Text = StringsHelper.Format(txt_amod_tot_df_seat_cost.Text, "###,###,###,###");


		private void txt_amod_tot_df_statmile_cost_Leave(Object eventSender, EventArgs eventArgs) => txt_amod_tot_df_statmile_cost.Text = StringsHelper.Format(txt_amod_tot_df_statmile_cost.Text, "###,###,###,###");


		private void txt_amod_tot_direct_cost_TextChanged(Object eventSender, EventArgs eventArgs)
		{
			// txt_amod_tot_direct_cost.Text = Format(txt_amod_tot_direct_cost, "###,###,###,###")
		}

		private void txt_amod_tot_fixed_cost2_TextChanged(Object eventSender, EventArgs eventArgs) => txt_amod_tot_fixed_cost2.Text = StringsHelper.Format(txt_amod_tot_fixed_cost2.Text, "###,###,###,###");


		private void txt_amod_tot_nd_annual_cost_Leave(Object eventSender, EventArgs eventArgs) => txt_amod_tot_nd_annual_cost.Text = StringsHelper.Format(txt_amod_tot_nd_annual_cost.Text, "###,###,###,###");


		private void txt_amod_tot_nd_hour_cost_Leave(Object eventSender, EventArgs eventArgs) => txt_amod_tot_nd_hour_cost.Text = StringsHelper.Format(txt_amod_tot_nd_hour_cost.Text, "###,###,###,###");


		private void txt_amod_tot_nd_seat_cost_Leave(Object eventSender, EventArgs eventArgs) => txt_amod_tot_nd_seat_cost.Text = StringsHelper.Format(txt_amod_tot_nd_seat_cost.Text, "###,###,###,###");


		private void txt_amod_tot_nd_statmile_cost_Leave(Object eventSender, EventArgs eventArgs) => txt_amod_tot_nd_statmile_cost.Text = StringsHelper.Format(txt_amod_tot_nd_statmile_cost.Text, "###,###,###,###");


		private void txt_amod_tot_stat_mile_cost_Leave(Object eventSender, EventArgs eventArgs)
		{
			if (Valid_OpCosts_Data())
			{
				//  Calculate_Bucket_Totals
			}
		}

		public void Display_Aircraft_Model_Op_Costs()
		{

			//Display Fuel total Cost
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_fuel_tot_cost"]))
			{
				txt_amod_fuel_tot_cost.Text = StringsHelper.Format(snp_Model["amod_fuel_tot_cost"], "###,###.00");
			}
			else
			{
				txt_amod_fuel_tot_cost.Text = "0";
			}

			// Display Fuel Cost Per Gallon
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_fuel_gal_cost"]))
			{
				txt_amod_fuel_gal_cost.Text = StringsHelper.Format(snp_Model["amod_fuel_gal_cost"], "###,###.00");
			}
			else
			{
				txt_amod_fuel_gal_cost.Text = "0";
			}

			// Display Additive Cost Per Gallon
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_fuel_add_cost"]))
			{
				txt_amod_fuel_add_cost.Text = StringsHelper.Format(snp_Model["amod_fuel_add_cost"], "###,###.00");
			}
			else
			{
				txt_amod_fuel_add_cost.Text = "0";
			}

			// Display burn/hour
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_fuel_burn_rate"]))
			{
				txt_amod_fuel_burn_rate.Text = StringsHelper.Format(snp_Model["amod_fuel_burn_rate"], "###,###.00");
			}
			else
			{
				txt_amod_fuel_burn_rate.Text = "0";
			}

			// Display maintenance total cost
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_maint_tot_cost"]))
			{
				txt_amod_maint_tot_cost.Text = StringsHelper.Format(snp_Model["amod_maint_tot_cost"], "###,###.00");
			}
			else
			{
				txt_amod_maint_tot_cost.Text = "0";
			}

			// Display maintenance labor cost
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_maint_lab_cost"]))
			{
				txt_amod_maint_lab_cost.Text = StringsHelper.Format(snp_Model["amod_maint_lab_cost"], "###,###.00");
			}
			else
			{
				txt_amod_maint_lab_cost.Text = "0";
			}

			// Display maintenance labor cost man hour multiplier
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_maint_labor_cost_man_hours_multiplier"]))
			{
				txt_amod_maint_labor_man_hour_multiplier.Text = StringsHelper.Format(snp_Model["amod_maint_labor_cost_man_hours_multiplier"], "#,###.00");
			}
			else
			{
				txt_amod_maint_labor_man_hour_multiplier.Text = "0.0";
			}

			// Display maintenance parts cost
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_maint_parts_cost"]))
			{
				txt_amod_maint_parts_cost.Text = StringsHelper.Format(snp_Model["amod_maint_parts_cost"], "###,###.00");
			}
			else
			{
				txt_amod_maint_parts_cost.Text = "0";
			}

			// Display maintenance parts cost man hour multiplier
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_maint_parts_cost_man_hours_multiplier"]))
			{
				txt_amod_maint_parts_man_hour_multiplier.Text = StringsHelper.Format(snp_Model["amod_maint_parts_cost_man_hours_multiplier"], "#,###.00");
			}
			else
			{
				txt_amod_maint_parts_man_hour_multiplier.Text = "0.0";
			}

			// Display maintenance engine overhaul cost
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_engine_ovh_cost"]))
			{
				txt_amod_engine_ovh_cost.Text = StringsHelper.Format(snp_Model["amod_engine_ovh_cost"], "###,###.00");
			}
			else
			{
				txt_amod_engine_ovh_cost.Text = "0";
			}

			// Display maintenance thrust reverse overhaul cost
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_thrust_rev_ovh_cost"]))
			{
				txt_amod_thrust_rev_ovh_cost.Text = StringsHelper.Format(snp_Model["amod_thrust_rev_ovh_cost"], "###,###.00");
			}
			else
			{
				txt_amod_thrust_rev_ovh_cost.Text = "0";
			}

			// Display misc. flight cost
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_misc_flight_cost"]))
			{
				txt_amod_misc_flight_cost.Text = StringsHelper.Format(snp_Model["amod_misc_flight_cost"], "###,###.00");
			}
			else
			{
				txt_amod_misc_flight_cost.Text = "0";
			}

			// Display landing/parking cost
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_land_park_cost"]))
			{
				txt_amod_land_park_cost.Text = StringsHelper.Format(snp_Model["amod_land_park_cost"], "###,###.00");
			}
			else
			{
				txt_amod_land_park_cost.Text = "0";
			}

			// Display crew exp. cost
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_crew_exp_cost"]))
			{
				txt_amod_crew_exp_cost.Text = StringsHelper.Format(snp_Model["amod_crew_exp_cost"], "###,###.00");
			}
			else
			{
				txt_amod_crew_exp_cost.Text = "0";
			}

			// Display supplies/catering cost
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_supplies_cost"]))
			{
				txt_amod_supplies_cost.Text = StringsHelper.Format(snp_Model["amod_supplies_cost"], "###,###.00");
			}
			else
			{
				txt_amod_supplies_cost.Text = "0";
			}

			// Display total hour direct cost
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_tot_hour_direct_cost"]))
			{
				txt_amod_tot_hour_direct_cost.Text = StringsHelper.Format(snp_Model["amod_tot_hour_direct_cost"], "###,###.00");
			}
			else
			{
				txt_amod_tot_hour_direct_cost.Text = "0";
			}

			// Display average block speed
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_avg_block_speed"]))
			{
				txt_amod_avg_block_speed.Text = StringsHelper.Format(snp_Model["amod_avg_block_speed"], "###,##0");
			}
			else
			{
				txt_amod_avg_block_speed.Text = "0";
			}

			// Display total cost statute mile
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_tot_stat_mile_cost"]))
			{
				txt_amod_tot_stat_mile_cost.Text = StringsHelper.Format(snp_Model["amod_tot_stat_mile_cost"], "###,###.00");
			}
			else
			{
				txt_amod_tot_stat_mile_cost.Text = "0";
			}

			// Display total crew salary cost
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_tot_crew_salary_cost"]))
			{
				txt_amod_tot_crew_salary_cost.Text = StringsHelper.Format(snp_Model["amod_tot_crew_salary_cost"], "###,##0");
			}
			else
			{
				txt_amod_tot_crew_salary_cost.Text = "0";
			}

			// Display capt. salary cost
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_capt_salary_cost"]))
			{
				txt_amod_capt_salary_cost.Text = StringsHelper.Format(snp_Model["amod_capt_salary_cost"], "###,##0");
				txt_amod_capt_salary_cost.Tag = txt_amod_capt_salary_cost.Text;
			}
			else
			{
				txt_amod_capt_salary_cost.Text = "0";
				txt_amod_capt_salary_cost.Tag = "0";
			}

			// Display copilot. salary cost
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_cpilot_salary_cost"]))
			{
				txt_amod_cpilot_salary_cost.Text = StringsHelper.Format(snp_Model["amod_cpilot_salary_cost"], "###,###.00");
				txt_amod_cpilot_salary_cost.Tag = txt_amod_cpilot_salary_cost.Text;
			}
			else
			{
				txt_amod_cpilot_salary_cost.Text = "0";
				txt_amod_cpilot_salary_cost.Tag = "0";
			}

			// Display crew benefit cost
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_crew_benefit_cost"]))
			{
				txt_amod_crew_benefit_cost.Text = StringsHelper.Format(snp_Model["amod_crew_benefit_cost"], "###,##0");
			}
			else
			{
				txt_amod_crew_benefit_cost.Text = "0";
			}

			// Display hangar cost
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_hangar_cost"]))
			{
				txt_amod_hangar_cost.Text = StringsHelper.Format(snp_Model["amod_hangar_cost"], "###,##0");
			}
			else
			{
				txt_amod_hangar_cost.Text = "0";
			}

			// Display insurance cost
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_insurance_cost"]))
			{
				txt_amod_insurance_cost.Text = StringsHelper.Format(snp_Model["amod_insurance_cost"], "###,##0");
			}
			else
			{
				txt_amod_insurance_cost.Text = "0";
			}

			// Display hull insurance cost
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_hull_insurance_cost"]))
			{
				txt_amod_hull_insurance_cost.Text = StringsHelper.Format(snp_Model["amod_hull_insurance_cost"], "###,##0");
			}
			else
			{
				txt_amod_hull_insurance_cost.Text = "0";
			}

			// Display liability insurance cost
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_liability_insurance_cost"]))
			{
				txt_amod_liability_insurance_cost.Text = StringsHelper.Format(snp_Model["amod_liability_insurance_cost"], "###,##0");
			}
			else
			{
				txt_amod_liability_insurance_cost.Text = "0";
			}

			// Display total misc. overhead cost
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_tot_misc_ovh_cost"]))
			{
				txt_amod_tot_misc_ovh_cost.Text = StringsHelper.Format(snp_Model["amod_tot_misc_ovh_cost"], "###,##0");
			}
			else
			{
				txt_amod_tot_misc_ovh_cost.Text = "0";
			}

			// Display misc. training cost
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_misc_train_cost"]))
			{
				txt_amod_misc_train_cost.Text = StringsHelper.Format(snp_Model["amod_misc_train_cost"], "###,##0");
				txt_amod_misc_train_cost.Tag = txt_amod_misc_train_cost.Text;
			}
			else
			{
				txt_amod_misc_train_cost.Text = "0";
				txt_amod_misc_train_cost.Tag = txt_amod_misc_train_cost.Text;
			}

			// Display misc. modernization cost
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_misc_modern_cost"]))
			{
				txt_amod_misc_modern_cost.Text = StringsHelper.Format(snp_Model["amod_misc_modern_cost"], "###,##0");
				txt_amod_misc_modern_cost.Tag = txt_amod_misc_modern_cost.Text;
			}
			else
			{
				txt_amod_misc_modern_cost.Text = "0";
				txt_amod_misc_modern_cost.Tag = txt_amod_misc_modern_cost.Text;
			}

			// Display misc. navigation equipment cost
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_misc_naveq_cost"]))
			{
				txt_amod_misc_naveq_cost.Text = StringsHelper.Format(snp_Model["amod_misc_naveq_cost"], "###,##0");
			}
			else
			{
				txt_amod_misc_naveq_cost.Text = "0";
			}

			// Display depreciation cost
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_deprec_cost"]))
			{
				txt_amod_deprec_cost.Text = StringsHelper.Format(snp_Model["amod_deprec_cost"], "###,##0");
			}
			else
			{
				txt_amod_deprec_cost.Text = "0";
			}

			// Display total fixed cost
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_tot_fixed_cost"]))
			{
				txt_amod_tot_fixed_cost.Text = StringsHelper.Format(snp_Model["amod_tot_fixed_cost"], "###,##0");
			}
			else
			{
				txt_amod_tot_fixed_cost.Text = "0";
			}

			// Display passengers
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_number_of_seats"]))
			{
				txt_amod_number_of_seats.Text = StringsHelper.Format(snp_Model["amod_number_of_seats"], "###,####0");
			}
			else
			{
				txt_amod_number_of_seats.Text = "0";
			}

			// Display annual miles
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_annual_miles"]))
			{
				txt_amod_annual_miles.Text = StringsHelper.Format(snp_Model["amod_annual_miles"], "###,####0");
			}
			else
			{
				txt_amod_annual_miles.Text = "0";
			}

			// Display annual hours
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_annual_hours"]))
			{
				txt_amod_annual_hours.Text = StringsHelper.Format(snp_Model["amod_annual_hours"], "###,####0");
			}
			else
			{
				txt_amod_annual_hours.Text = "0";
			}

			// Display total direct cost
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_tot_direct_cost"]))
			{
				txt_amod_tot_direct_cost.Text = StringsHelper.Format(snp_Model["amod_tot_direct_cost"], "###,###");
			}
			else
			{
				txt_amod_tot_direct_cost.Text = "0";
			}

			// Display total fixed cost2
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_tot_fixed_cost"]))
			{
				txt_amod_tot_fixed_cost2.Text = StringsHelper.Format(snp_Model["amod_tot_fixed_cost"], "###,###");
			}
			else
			{
				txt_amod_tot_fixed_cost2.Text = "0";
			}

			// Display total cost /fixed and direct
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_tot_df_annual_cost"]))
			{
				txt_amod_tot_df_annual_cost.Text = StringsHelper.Format(snp_Model["amod_tot_df_annual_cost"], "###,###");
			}
			else
			{
				txt_amod_tot_df_annual_cost.Text = "0";
			}

			// Display total cost/hour - fixed and direct
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_tot_df_hour_cost"]))
			{
				txt_amod_tot_df_hour_cost.Text = StringsHelper.Format(snp_Model["amod_tot_df_hour_cost"], "###,###");
			}
			else
			{
				txt_amod_tot_df_hour_cost.Text = "0";
			}

			// Display total status mile - fixed and direct
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_tot_df_statmile_cost"]))
			{
				txt_amod_tot_df_statmile_cost.Text = StringsHelper.Format(snp_Model["amod_tot_df_statmile_cost"], "###,###.00");
			}
			else
			{
				txt_amod_tot_df_statmile_cost.Text = "0";
			}

			// Display total seat cost - fixed and direct
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_tot_df_seat_cost"]))
			{
				txt_amod_tot_df_seat_cost.Text = StringsHelper.Format(snp_Model["amod_tot_df_seat_cost"], "###,###.00");
			}
			else
			{
				txt_amod_tot_df_seat_cost.Text = "0";
			}

			// Display total annual cost - no depreciation
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_tot_nd_annual_cost"]))
			{
				txt_amod_tot_nd_annual_cost.Text = StringsHelper.Format(snp_Model["amod_tot_nd_annual_cost"], "###,###");
			}
			else
			{
				txt_amod_tot_nd_annual_cost.Text = "0";
			}

			// Display total hour cost - no depreciation
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_tot_nd_hour_cost"]))
			{
				txt_amod_tot_nd_hour_cost.Text = StringsHelper.Format(snp_Model["amod_tot_nd_hour_cost"], "###,###.00");
			}
			else
			{
				txt_amod_tot_nd_hour_cost.Text = "0";
			}

			// Display total statute mile cost - no depreciation
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_tot_nd_statmile_cost"]))
			{
				txt_amod_tot_nd_statmile_cost.Text = StringsHelper.Format(snp_Model["amod_tot_nd_statmile_cost"], "###,###.00");
			}
			else
			{
				txt_amod_tot_nd_statmile_cost.Text = "0";
			}

			// Display total seat cost - no depreciation
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_tot_nd_seat_cost"]))
			{
				txt_amod_tot_nd_seat_cost.Text = StringsHelper.Format(snp_Model["amod_tot_nd_seat_cost"], "###,###.00");
			}
			else
			{
				txt_amod_tot_nd_seat_cost.Text = "0";
			}
		}

		public void Display_Aircraft_Model_Specifications()
		{
			bool FoundIt = false;

			//D'Display prop mfr name
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_prop_mfr_name"]))
			{
				txt_amod_prop_mfr_name.Text = snp_Model["amod_prop_mfr_name"].ToString();
			}
			else
			{
				txt_amod_prop_mfr_name.Text = " ";
			}
			//display number of engines
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_number_of_engines"]))
			{
				txt_amod_number_of_engines.Text = snp_Model["amod_number_of_engines"].ToString();
			}
			else
			{
				txt_amod_number_of_engines.Text = "0";
			}

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_engine_thrust_lbs"]))
			{
				txt_amod_engine_thrust_lbs.Text = StringsHelper.Format(snp_Model["amod_engine_thrust_lbs"], "###,##0");
			}
			else
			{
				txt_amod_engine_thrust_lbs.Text = "0";
			}

			//Display common tbo hours aey 5/30/04
			chk_oncondtbox.CheckState = CheckState.Unchecked;
			cbo_tbo_list.Visible = true;
			lbl_specs[18].Visible = true;

			if (Convert.ToString(snp_Model["amod_on_condition_flag"]) == "Y")
			{
				chk_oncondtbox.CheckState = CheckState.Checked;
				cbo_tbo_list.Visible = false;
				lbl_specs[18].Visible = false;
			}
			else
			{
				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(snp_Model["amod_engine_com_tbo_hrs"]))
				{
					cbo_tbo_list.Text = StringsHelper.Format(Double.Parse($"{Convert.ToString(snp_Model["amod_engine_com_tbo_hrs"])}"), "#0");
				}
				else
				{
					cbo_tbo_list.Text = "0";
				}
			}

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_engine_shaft"]))
			{
				//If Not IsNumeric(snp_Model!amod_engine_shaft) Then
				txt_amod_engine_shaft.Text = snp_Model["amod_engine_shaft"].ToString();
			}
			else
			{
				txt_amod_engine_shaft.Text = "0";
			}

			//Display engine hsi
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_engine_hsi"]))
			{
				// If Not IsNumeric(snp_Model!amod_engine_hsi) Then
				txt_amod_engine_hsi.Text = snp_Model["amod_engine_hsi"].ToString();
			}
			else
			{
				txt_amod_engine_hsi.Text = "0";
			}

			//Display fuselage length
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_fuselage_length"]))
			{
				txt_amod_fuselage_length[0].Text = StringsHelper.Format(snp_Model["amod_fuselage_length"], "###,##0.0");
			}
			else
			{
				txt_amod_fuselage_length[0].Text = "0.0";
			}

			//Display fuselage height
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_fuselage_height"]))
			{
				txt_amod_fuselage_height.Text = StringsHelper.Format(snp_Model["amod_fuselage_height"], "###,##0.0");
			}
			else
			{
				txt_amod_fuselage_height.Text = "0.0";
			}

			//Display fuselage wingspan
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_fuselage_wingspan"]))
			{
				txt_amod_fuselage_wingspan.Text = StringsHelper.Format(snp_Model["amod_fuselage_wingspan"], "###,##0.0");
			}
			else
			{
				txt_amod_fuselage_wingspan.Text = "0.0";
			}

			//Display number of crew
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_number_of_crew"]))
			{
				txt_amod_number_of_crew.Text = snp_Model["amod_number_of_crew"].ToString();
			}
			else
			{
				txt_amod_number_of_crew.Text = "0";
			}

			//Display number of passengers
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_number_of_passengers"]))
			{
				txt_amod_number_of_passengers.Text = StringsHelper.Format(snp_Model["amod_number_of_passengers"], "0");
			}
			else
			{
				txt_amod_number_of_passengers.Text = " ";
			}

			//Display pressure
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_pressure"]))
			{
				txt_amod_pressure.Text = StringsHelper.Format(snp_Model["amod_pressure"], "0.0");
			}
			else
			{
				txt_amod_pressure.Text = "0";
			}

			//Display max ramp weight
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_max_ramp_weight"]))
			{
				txt_amod_max_ramp_weight.Text = StringsHelper.Format(snp_Model["amod_max_ramp_weight"], "##,##0");
			}
			else
			{
				txt_amod_max_ramp_weight.Text = "0";
			}

			//Display max takeoff weight
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_max_takeoff_weight"]))
			{
				txt_amod_max_takeoff_weight.Text = StringsHelper.Format(snp_Model["amod_max_takeoff_weight"], "##,##0");
			}
			else
			{
				txt_amod_max_takeoff_weight.Text = "0";
			}

			//Display zero fuel weight
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_zero_fuel_weight"]))
			{
				txt_amod_zero_fuel_weight.Text = StringsHelper.Format(snp_Model["amod_zero_fuel_weight"], "##,##0");
			}
			else
			{
				txt_amod_zero_fuel_weight.Text = "0";
			}

			//Display basic op weight
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_basic_op_weight"]))
			{
				txt_amod_basic_op_weight.Text = StringsHelper.Format(snp_Model["amod_basic_op_weight"], "##,##0");
				txt_amod_basic_op_weight.Tag = txt_amod_basic_op_weight.Text;
			}
			else
			{
				txt_amod_basic_op_weight.Text = "0";
				txt_amod_basic_op_weight.Tag = txt_amod_basic_op_weight.Text;
			}

			//Display max landing weight
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_max_landing_weight"]))
			{
				txt_amod_max_landing_weight.Text = StringsHelper.Format(snp_Model["amod_max_landing_weight"], "##,##0");
			}
			else
			{
				txt_amod_max_landing_weight.Text = "0";
			}

			//Display fuel capacity standard weight
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_fuel_cap_std_weight"]))
			{
				txt_amod_fuel_cap_std_weight.Text = StringsHelper.Format(snp_Model["amod_fuel_cap_std_weight"], "##,##0");
			}
			else
			{
				txt_amod_fuel_cap_std_weight.Text = "0";
			}

			//Display fuel capacity standard gallons
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_fuel_cap_std_gal"]))
			{
				txt_amod_fuel_cap_std_gal.Text = StringsHelper.Format(snp_Model["amod_fuel_cap_std_gal"], "##,##0");
			}
			else
			{
				txt_amod_fuel_cap_std_gal.Text = "0";
			}


			//Display fuel capacity optional weight
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_fuel_cap_opt_weight"]))
			{
				txt_amod_fuel_cap_opt_weight.Text = StringsHelper.Format(snp_Model["amod_fuel_cap_opt_weight"], "##,##0");
			}
			else
			{
				txt_amod_fuel_cap_opt_weight.Text = "0";
			}

			//Display fuel capacity optional gallons
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_fuel_cap_opt_gal"]))
			{
				txt_amod_fuel_cap_opt_gal.Text = StringsHelper.Format(snp_Model["amod_fuel_cap_opt_gal"], "##,##0");
			}
			else
			{
				txt_amod_fuel_cap_opt_gal.Text = "0";
			}

			//Display takeoff performance ali
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_takeoff_ali"]))
			{
				txt_amod_takeoff_ali.Text = StringsHelper.Format(snp_Model["amod_takeoff_ali"], "##,##0");
			}
			else
			{
				txt_amod_takeoff_ali.Text = "0";
			}

			//Display takeoff performance 500
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_takeoff_500"]))
			{
				txt_amod_takeoff_500.Text = StringsHelper.Format(snp_Model["amod_takeoff_500"], "##,##0");
			}
			else
			{
				txt_amod_takeoff_500.Text = "0";
			}

			//Display landing performance
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_field_length"]))
			{
				txt_amod_field_length.Text = StringsHelper.Format(snp_Model["amod_field_length"], "##,##0");
			}
			else
			{
				txt_amod_field_length.Text = "0";
			}

			//Display range
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_max_range_miles"]))
			{
				txt_amod_max_range_miles.Text = StringsHelper.Format(snp_Model["amod_max_range_miles"], "##,##0");
			}
			else
			{
				txt_amod_max_range_miles.Text = "0";
			}

			//Display climb normal
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_climb_normal_feet"]))
			{
				txt_amod_climb_normal_feet.Text = StringsHelper.Format(snp_Model["amod_climb_normal_feet"], "##,##0");
			}
			else
			{
				txt_amod_climb_normal_feet.Text = "0";
			}

			//Display climb engine
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_climb_engout_feet"]))
			{
				txt_amod_climb_engout_feet.Text = StringsHelper.Format(snp_Model["amod_climb_engout_feet"], "##,##0");
			}
			else
			{
				txt_amod_climb_engout_feet.Text = "0";
			}

			//Display ceiling
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_ceiling_feet"]))
			{
				txt_amod_ceiling_feet.Text = StringsHelper.Format(snp_Model["amod_ceiling_feet"], "##,##0");
			}
			else
			{
				txt_amod_ceiling_feet.Text = "0";
			}

			//Display number of props
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_number_of_props"]))
			{
				txt_amod_number_of_props.Text = StringsHelper.Format(snp_Model["amod_number_of_props"], "##,##0");
			}
			else
			{
				txt_amod_number_of_props.Text = "0";
			}

			//Display prop model name
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_prop_model_name"]))
			{
				txt_amod_prop_model_name.Text = snp_Model["amod_prop_model_name"].ToString();
			}
			else
			{
				txt_amod_prop_model_name.Text = " ";
			}

			//Display prop mfr name
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_prop_mfr_name"]))
			{
				txt_amod_prop_mfr_name.Text = snp_Model["amod_prop_mfr_name"].ToString();
			}
			else
			{
				txt_amod_prop_mfr_name.Text = " ";
			}

			//Display prop com tbo hrs
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_prop_com_tbo_hrs"]))
			{
				txt_amod_prop_com_tbo_hrs.Text = StringsHelper.Format(snp_Model["amod_prop_com_tbo_hrs"], "##,##0");
			}
			else
			{
				txt_amod_prop_com_tbo_hrs.Text = "0";
			}

			//Display prop shaft
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_prop_shaft"]))
			{
				//If Not IsNumeric(snp_Model!amod_prop_shaft) Then
				txt_amod_prop_shaft.Text = snp_Model["amod_prop_shaft"].ToString();
			}
			else
			{
				txt_amod_prop_shaft.Text = "0";
			}

			//Display prop his
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_prop_hsi"]))
			{
				//If Not IsNumeric(snp_Model!amod_prop_hsi) Then
				txt_amod_prop_hsi.Text = snp_Model["amod_prop_hsi"].ToString();
			}
			else
			{
				txt_amod_prop_hsi.Text = "0";
			}

			//Display prop config note
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_other_config_note"]))
			{
				txt_amod_other_config_note.Text = Convert.ToString(snp_Model["amod_other_config_note"]).Trim();
			}
			else
			{
				txt_amod_other_config_note.Text = " ";
			}

			//Display speed stall vs
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_stall_vs"]))
			{
				txt_amod_speed[0].Text = StringsHelper.Format(snp_Model["amod_stall_vs"], "##,##0");
			}
			else
			{
				txt_amod_speed[0].Text = "0";
			}

			//Display speed stall vso
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_stall_vso"]))
			{
				txt_amod_speed[1].Text = StringsHelper.Format(snp_Model["amod_stall_vso"], "##,##0");
			}
			else
			{
				txt_amod_speed[1].Text = "0";
			}

			//Display cruise speed
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_cruis_speed"]))
			{
				txt_amod_speed[2].Text = StringsHelper.Format(snp_Model["amod_cruis_speed"], "##,##0");
			}
			else
			{
				txt_amod_speed[2].Text = "0";
			}

			//Display max speed - ' Vmo(MaxOp) IAS
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_max_speed"]))
			{
				txt_amod_speed[3].Text = StringsHelper.Format(snp_Model["amod_max_speed"], "##,##0");
			}
			else
			{
				txt_amod_speed[3].Text = "0";
			}

			// 07/28/2017 - By David D. Cruger; Added

			//V1 Takeoff Speed
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_v1_takeoff_speed"]))
			{
				txt_amod_speed[4].Text = StringsHelper.Format(snp_Model["amod_v1_takeoff_speed"], "##,##0");
			}
			else
			{
				txt_amod_speed[4].Text = "0";
			}

			//VFE Max Flap Ext Speed
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_vfe_max_flap_extended_speed"]))
			{
				txt_amod_speed[5].Text = StringsHelper.Format(snp_Model["amod_vfe_max_flap_extended_speed"], "##,##0");
			}
			else
			{
				txt_amod_speed[5].Text = "0";
			}

			//VFE Max Flap Ext Speed
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_vle_max_landing_gear_ext_speed"]))
			{
				txt_amod_speed[6].Text = StringsHelper.Format(snp_Model["amod_vle_max_landing_gear_ext_speed"], "##,##0");
			}
			else
			{
				txt_amod_speed[6].Text = "0";
			}

			// Vne (MaxOp) IAS
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_vne_maxop_speed"]))
			{
				txt_amod_speed[7].Text = StringsHelper.Format(snp_Model["amod_vne_maxop_speed"], "##,##0");
			}
			else
			{
				txt_amod_speed[7].Text = "0";
			}

			//new fields 10/27/2005
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_main_rotor_1_blade_count"]))
			{
				txt_amod_main_rotor_1_blade_count.Text = StringsHelper.Format(snp_Model["amod_main_rotor_1_blade_count"], "##,###0");
			}
			else
			{
				txt_amod_main_rotor_1_blade_count.Text = "0";
			}

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_main_rotor_1_blade_diameter"]))
			{
				txt_amod_main_rotor_1_blade_diameter.Text = StringsHelper.Format(snp_Model["amod_main_rotor_1_blade_diameter"], "##,###0.0");
			}
			else
			{
				txt_amod_main_rotor_1_blade_diameter.Text = "0.0";
			}

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_main_rotor_2_blade_count"]))
			{
				txt_amod_main_rotor_2_blade_count.Text = StringsHelper.Format(snp_Model["amod_main_rotor_2_blade_count"], "##,###0");
			}
			else
			{
				txt_amod_main_rotor_2_blade_count.Text = "0";
			}

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_main_rotor_2_blade_diameter"]))
			{
				txt_amod_main_rotor_2_blade_diameter.Text = StringsHelper.Format(snp_Model["amod_main_rotor_2_blade_diameter"], "##,###0.0");
			}
			else
			{
				txt_amod_main_rotor_2_blade_diameter.Text = "0.0";
			}

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_tail_rotor_blade_count"]))
			{
				txt_amod_tail_rotor_blade_count.Text = StringsHelper.Format(snp_Model["amod_tail_rotor_blade_count"], "##,###0");
			}
			else
			{
				txt_amod_tail_rotor_blade_count.Text = "0";
			}

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_tail_rotor_blade_diameter"]))
			{
				txt_amod_tail_rotor_blade_diameter.Text = StringsHelper.Format(snp_Model["amod_tail_rotor_blade_diameter"], "##,###0.0");
			}
			else
			{
				txt_amod_tail_rotor_blade_diameter.Text = "0.0";
			}

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_rotor_anti_torque_system"]))
			{
				//cmb_amod_rotor_anti_torque_system.Text = snp_Model!amod_rotor_anti_torque_system & ""
				FoundIt = false;
				int tempForEndVar = cmb_amod_rotor_anti_torque_system.Items.Count - 1;
				for (int K = 0; K <= tempForEndVar; K++)
				{
					if (cmb_amod_rotor_anti_torque_system.GetListItem(K) == Convert.ToString(snp_Model["amod_rotor_anti_torque_system"]))
					{
						FoundIt = true;
						cmb_amod_rotor_anti_torque_system.SelectedIndex = K;
						break;
					}
				}

				if (!FoundIt)
				{
					cmb_amod_rotor_anti_torque_system.AddItem($"{Convert.ToString(snp_Model["amod_rotor_anti_torque_system"])}");
					cmb_amod_rotor_anti_torque_system.SelectedIndex = cmb_amod_rotor_anti_torque_system.Items.Count - 1;
				}
			}
			else
			{
				cmb_amod_rotor_anti_torque_system.Text = "Unknown";
			}

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_ifr_certification"]))
			{
				//cmb_amod_ifr_certification = snp_Model!amod_ifr_certification & ""
				FoundIt = false;
				int tempForEndVar2 = cmb_amod_ifr_certification.Items.Count - 1;
				for (int K = 0; K <= tempForEndVar2; K++)
				{
					if (cmb_amod_ifr_certification.GetListItem(K) == Convert.ToString(snp_Model["amod_ifr_certification"]))
					{
						FoundIt = true;
						cmb_amod_ifr_certification.SelectedIndex = K;
						break;
					}
				}

				if (!FoundIt)
				{
					cmb_amod_ifr_certification.AddItem($"{Convert.ToString(snp_Model["amod_ifr_certification"])}");
					cmb_amod_ifr_certification.SelectedIndex = cmb_amod_ifr_certification.Items.Count - 1;
				}


			}
			else
			{
				cmb_amod_ifr_certification.Text = "Unknown";
			}

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_fuselage_width"]))
			{
				txt_amod_fuselage_width.Text = StringsHelper.Format(snp_Model["amod_fuselage_width"], "##,###0.0");
			}
			else
			{
				txt_amod_fuselage_width.Text = "0.0";
			}

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_climb_hoge"]))
			{
				txt_amod_climb_hoge.Text = StringsHelper.Format(snp_Model["amod_climb_hoge"], "##,###0");
			}
			else
			{
				txt_amod_climb_hoge.Text = "0";
			}

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_climb_hige"]))
			{
				txt_amod_climb_hige.Text = StringsHelper.Format(snp_Model["amod_climb_hige"], "##,###0");
			}
			else
			{
				txt_amod_climb_hige.Text = "0";
			}

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_range_tanks_full"]))
			{
				txt_amod_range_tanks_full.Text = StringsHelper.Format(snp_Model["amod_range_tanks_full"], "##,###0");
			}
			else
			{
				txt_amod_range_tanks_full.Text = "0";
			}

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_range_seats_full"]))
			{
				txt_amod_range_seats_full.Text = StringsHelper.Format(snp_Model["amod_range_seats_full"], "##,###0");
			}
			else
			{
				txt_amod_range_seats_full.Text = "0";
			}

			// 07/28/2017 - By David D. Cruger; Added
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_range_4_passenger"]))
			{
				txt_amod_range_4_passenger.Text = StringsHelper.Format(snp_Model["amod_range_4_passenger"], "##,###0");
			}
			else
			{
				txt_amod_range_4_passenger.Text = "0";
			}

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_range_8_passenger"]))
			{
				txt_amod_range_8_passenger.Text = StringsHelper.Format(snp_Model["amod_range_8_passenger"], "##,###0");
			}
			else
			{
				txt_amod_range_8_passenger.Text = "0";
			}

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_weight_eow"]))
			{
				txt_amod_weight_eow.Text = StringsHelper.Format(snp_Model["amod_weight_eow"], "##,###0");
				txt_amod_weight_eow.Tag = txt_amod_weight_eow.Text;
			}
			else
			{
				txt_amod_weight_eow.Text = "0";
				txt_amod_weight_eow.Tag = txt_amod_weight_eow.Text;
			}

			//Display cabin height ft
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_cabinsize_height_feet"]))
			{
				txt_amod_fuselage_length[1].Text = Convert.ToString(snp_Model["amod_cabinsize_height_feet"]);
			}
			else
			{
				txt_amod_fuselage_length[1].Text = "0";
			}
			//Display cabin height in
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_cabinsize_height_inches"]))
			{
				txt_amod_fuselage_length[2].Text = Convert.ToString(snp_Model["amod_cabinsize_height_inches"]);
			}
			else
			{
				txt_amod_fuselage_length[2].Text = "0";
			}
			//Display cabin length ft
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_cabinsize_length_feet"]))
			{
				txt_amod_fuselage_length[3].Text = Convert.ToString(snp_Model["amod_cabinsize_length_feet"]);
			}
			else
			{
				txt_amod_fuselage_length[3].Text = "0";
			}
			//Display cabin length in
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_cabinsize_length_inches"]))
			{
				txt_amod_fuselage_length[4].Text = Convert.ToString(snp_Model["amod_cabinsize_length_inches"]);
			}
			else
			{
				txt_amod_fuselage_length[4].Text = "0";
			}
			//Display cabin with ft
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_cabinsize_width_feet"]))
			{
				txt_amod_fuselage_length[5].Text = Convert.ToString(snp_Model["amod_cabinsize_width_feet"]);
			}
			else
			{
				txt_amod_fuselage_length[5].Text = "0";
			}
			//Display cabin width in
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_cabinsize_width_inches"]))
			{
				txt_amod_fuselage_length[6].Text = Convert.ToString(snp_Model["amod_cabinsize_width_inches"]);
			}
			else
			{
				txt_amod_fuselage_length[6].Text = "0";
			}

			// 07/28/2017 - By David D. Cruger; Added

			//Display Cabin Volume
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_cabin_volume"]))
			{
				txt_amod_fuselage_length[8].Text = Convert.ToString(snp_Model["amod_cabin_volume"]);
			}
			else
			{
				txt_amod_fuselage_length[8].Text = "0";
			}

			//Display Baggage Volume
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_baggage_volume"]))
			{
				txt_amod_fuselage_length[9].Text = Convert.ToString(snp_Model["amod_baggage_volume"]);
			}
			else
			{
				txt_amod_fuselage_length[9].Text = "0";
			}

		}

		public void Display_Aircraft_Model_Administration()
		{

			txt_amod_ent_date.Text = "";
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_ent_date"]))
			{
				txt_amod_ent_date.Text = StringsHelper.Format(snp_Model["amod_ent_date"], "mm/dd/yyyy hh:MM:ss AMPM");
			}

			txt_amod_upd_date.Text = "";
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_upd_date"]))
			{
				txt_amod_upd_date.Text = StringsHelper.Format(snp_Model["amod_upd_date"], "mm/dd/yyyy hh:MM:ss AMPM");
			}

			txt_amod_common_verify_days.Text = "0";
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_common_verify_days"]))
			{
				txt_amod_common_verify_days.Text = Convert.ToString(snp_Model["amod_common_verify_days"]);
			}

			txt_amod_sale_verify_days.Text = "0";
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_sale_verify_days"]))
			{
				txt_amod_sale_verify_days.Text = Convert.ToString(snp_Model["amod_sale_verify_days"]);
			}

			txt_amod_ent_user_id.Text = ($"{Convert.ToString(snp_Model["amod_ent_user_id"])} ").Trim();
			txt_amod_upd_user_id.Text = ($"{Convert.ToString(snp_Model["amod_upd_user_id"])} ").Trim();

			hold_amod_customer_flag = ($"{Convert.ToString(snp_Model["amod_customer_flag"])} ").Trim().ToUpper();

			chk_amod_customer_flag.CheckState = CheckState.Unchecked;
			if (hold_amod_customer_flag == "Y")
			{
				chk_amod_customer_flag.CheckState = CheckState.Checked;
			}

		} // Display_Aircraft_Model_Administration

		private bool Key_Feature_Insert()
		{

			bool result = false;
			ADORecordSetHelper ado_FeatureCount = default(ADORecordSetHelper);
			ADORecordSetHelper ado_new_model_feature = default(ADORecordSetHelper);
			ADORecordSetHelper ado_new_aircraft_feature = default(ADORecordSetHelper);
			string errMsg = "";
			try
			{
				string Query = "";
				ado_FeatureCount = new ADORecordSetHelper();
				ADORecordSetHelper ado_MasterFeature = new ADORecordSetHelper();
				bool StandardEquipment = false;
				int StartSerNo = 0;
				string RuleString = "";
				int EndSerNo = 0;
				ado_new_model_feature = new ADORecordSetHelper();
				ado_new_aircraft_feature = new ADORecordSetHelper();
				string RuleStatus = "";
				string strDel1 = "";

				int tcount = 0;
				DialogResult intPress = (DialogResult) 0;

				result = false;

				this.Cursor = Cursors.WaitCursor;
				//========================================================================
				// COUNT THE AIRCRAFT IMPACTED AND GET CONFIRMATION FROM THE USER TO ADD
				// RTW - 5/3/2017 - ADDED NO LOCKS TO QUERIES
				errMsg = "init";

				tcount = 0;
				UserMessage("Checking on Aircraft for Feature Insert");
				Query = "SELECT DISTINCT ac_id, ac_ser_no_value ";
				Query = $"{Query}FROM Aircraft with (NOLOCK)";
				Query = $"{Query}WHERE ac_amod_id = {Convert.ToString(snp_Model["amod_id"])} ";
				Query = $"{Query}AND ac_journ_id = 0 ";

				ado_FeatureCount.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(ado_FeatureCount.BOF && ado_FeatureCount.EOF))
				{
					ado_FeatureCount.MoveFirst();
					errMsg = "tcount";

					while(!ado_FeatureCount.EOF)
					{
						tcount++;
						ado_FeatureCount.MoveNext();
					};
				}
				errMsg = "feat code";
				UserMessage("Off");
				intPress = MessageBox.Show($"Feature Code {grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString().Trim()} will be added to {tcount.ToString()} Aircraft Records. Confirm Add!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo);
				if (intPress == System.Windows.Forms.DialogResult.No)
				{
					result = false;
					MessageBox.Show("Important Feature Code Add Aborted!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					return result;
				}

				errMsg = "Query rules";
				// GET THE QUERY RULES AND STRING FOR THIS FEATURE CODE
				grd_Keyfeature.CurrentColumnIndex = 1;
				RuleString = modAdminCommon.Key_Feature_Get_Rule(grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString().Trim());

				errMsg = "Trans";
				modAdminCommon.ADO_Transaction("BeginTrans");

				//===============================================
				// INSERT AIRCRAFT MODEL KEY FEATURE RECORD
				errMsg = "tr Model list";

				ado_new_model_feature.Open("Select * from Aircraft_Model_Key_Feature where amfeat_feature_code='...'", modAdminCommon.ADODB_Trans_conn, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

				//UPGRADE_ISSUE: (2064) ADODB.CursorOptionEnum property CursorOptionEnum.adAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method ado_new_model_feature.Supports was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				if (ado_new_model_feature.Supports(UpgradeStubs.ADODB_CursorOptionEnum.getadAddNew()))
				{
					ado_new_model_feature.AddNew();
					grd_Keyfeature.CurrentColumnIndex = 1;
					ado_new_model_feature["amfeat_feature_code"] = grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString().Trim();
					UserMessage($"Inserting Aircraft Model Feature Record {grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString().Trim()}");
					ado_new_model_feature["amfeat_seq_no"] = grd_Keyfeature.CurrentRowIndex;
					ado_new_model_feature["amfeat_amod_id"] = snp_Model["amod_id"];
					grd_Keyfeature.CurrentColumnIndex = 3;
					ado_new_model_feature["amfeat_standard_equip"] = grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString().Trim();
					grd_Keyfeature.CurrentColumnIndex = 4;
					if (grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString().Trim() != "")
					{
						ado_new_model_feature["amfeat_stdeq_start_ser_no_value"] = Convert.ToInt32(Double.Parse(grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString().Trim()));
					}
					grd_Keyfeature.CurrentColumnIndex = 5;
					if (grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString().Trim() != "")
					{
						ado_new_model_feature["amfeat_stdeq_end_ser_no_value"] = Convert.ToInt32(Double.Parse(grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString().Trim()));
					}
					grd_Keyfeature.CurrentColumnIndex = 7;
					if (grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString().Trim() != "")
					{
						ado_new_model_feature["amfeat_inactive_date"] = DateTime.Parse(grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString().Trim());
					}
					ado_new_model_feature.Update();
				} // ADD NEW AIRCRAFT MODEL FEATURE CODE

				errMsg = "tr ac list";




				modAdminCommon.ADO_Transaction("CommitTrans");
				UserMessage("Off");


				grd_Keyfeature.CurrentColumnIndex = 1;
				if (Key_Feature_Add_Update_Stored_Procedure(Convert.ToInt32(snp_Model["amod_id"]), grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString()))
				{

				}



				errMsg = "Close RS";

				// CLOSE RECORDSETS
				if (ado_FeatureCount != null)
				{
					if (ado_FeatureCount.State == ConnectionState.Open)
					{ // Already Open Close It
						ado_FeatureCount.Close();
					}
					ado_FeatureCount = null;
				}

				if (ado_new_model_feature != null)
				{
					if (ado_new_model_feature.State == ConnectionState.Open)
					{ // Already Open Close It
						ado_new_model_feature.Close();
					}
					ado_new_model_feature = null;
				}


				if (ado_new_aircraft_feature != null)
				{
					if (ado_new_aircraft_feature.State == ConnectionState.Open)
					{ // Already Open Close It
						ado_new_aircraft_feature.Close();
					}
					ado_new_aircraft_feature = null;
				}


				this.Cursor = CursorHelper.CursorDefault;
				return true;
			}
			catch (System.Exception excep)
			{

				result = false;

				modAdminCommon.ADO_Transaction("RollbackTrans");
				UserMessage("Off");
				if (ado_FeatureCount != null)
				{
					if (ado_FeatureCount.State == ConnectionState.Open)
					{ // Already Open Close It
						ado_FeatureCount.Close();
					}
					ado_FeatureCount = null;
				}

				if (ado_new_model_feature != null)
				{
					if (ado_new_model_feature.State == ConnectionState.Open)
					{ // Already Open Close It
						ado_new_model_feature.Close();
					}
					ado_new_model_feature = null;
				}


				if (ado_new_aircraft_feature != null)
				{
					if (ado_new_aircraft_feature.State == ConnectionState.Open)
					{ // Already Open Close It
						ado_new_aircraft_feature.Close();
					}
					ado_new_aircraft_feature = null;
				}

				this.Cursor = CursorHelper.CursorDefault;
				modAdminCommon.Report_Error($"Insert_Aircraft_Model_Key_Feature_Error: {excep.Message} {errMsg}");
			}
			return result;
		}

		public void Select_Master_Key_Feature()
		{
			try
			{


				snp_MasterFeature.MoveFirst();
				int tempForEndVar = ListBoxHelper.GetSelectedIndex(lst_MasterKeyFeature);
				for (int i = 1; i <= tempForEndVar; i++)
				{
					snp_MasterFeature.MoveNext();
				}
				//UPGRADE_ISSUE: (207) An invalid structure was generated in this location, inside Select_Master_Key_Feature. Please check source code. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-207
				//cmd_button_array().Visible = True
			}
			catch
			{

				this.Cursor = CursorHelper.CursorDefault;
				modAdminCommon.Report_Error("Select_Master_Key_Feature_Error: ");
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
				return;
			}

		}

		public void Select_Aircraft_Type()
		{
			try
			{

				int i = 0;

				snp_AircraftType.MoveFirst();
				i = 0;

				while(!snp_AircraftType.EOF)
				{
					if (snp_AircraftType["atype_code"] == snp_Model["amod_type_code"])
					{
						cbo_amod_type_code.SelectedIndex = i;
						return;
					}
					snp_AircraftType.MoveNext();
					i++;
				};
			}
			catch
			{

				this.Cursor = CursorHelper.CursorDefault;
				modAdminCommon.Report_Error("Select_Aircraft_Type_Error: ");
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
				return;
			}

		}
		public void Select_Aircraft_Class()
		{
			try
			{

				int i = 0;

				snp_AircraftClass.MoveFirst();

				i = 0;

				while(!snp_AircraftClass.EOF)
				{
					if (snp_AircraftClass["aclass_code"] == snp_Model["amod_class_code"])
					{
						cbo_amod_class.SelectedIndex = i;
						return;
					}
					snp_AircraftClass.MoveNext();
					i++;
				};
				cbo_amod_class.SelectedIndex = i - 1;
			}
			catch
			{

				this.Cursor = CursorHelper.CursorDefault;
				modAdminCommon.Report_Error("Select_Aircraft_Class_Error: ");
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
				return;
			}

		}

		private bool Validate_Aircraft_Model_Main()
		{

			string strMfrName = "";
			int lMfrCompId = 0;

			bool bResults = true;

			string strMsg = "";

			// Airframe Type
			if (cbo_amod_Airframe_Type_Code.Text == "")
			{
				bResults = false;
				strMsg = $"{strMsg}Failed - <Airframe Type Is Blank>{Environment.NewLine}";
			}

			// Aircraft MakeType
			if (cbo_amod_type_code.Text == "")
			{
				bResults = false;
				strMsg = $"{strMsg}Failed - <Make Type Is Blank>{Environment.NewLine}";
			}

			// Aircaft Make Name
			if (($"{txt_amod_make_name.Text} ").Trim() == "")
			{
				bResults = false;
				strMsg = $"{strMsg}Failed - <Make Name Is Blank>{Environment.NewLine}";
			}

			// Aircraft Make Abbrev
			if (($"{txt_amod_make_abbrev.Text} ").Trim() == "")
			{
				bResults = false;
				strMsg = $"{strMsg}Failed - <Make Abbrev Is Blank{Environment.NewLine}";
			}

			// Aircraft Model Name
			if (($"{txt_amod_model_name.Text} ").Trim() == "")
			{
				bResults = false;
				strMsg = $"{strMsg}Failed - <Model Name Is Blank{Environment.NewLine}";
			}

			// Aircraft Model Abbrev
			if (($"{txt_amod_model_abbrev.Text} ").Trim() == "")
			{
				bResults = false;
				strMsg = $"{strMsg}Failed - <Model Abbrev Name Is Blank{Environment.NewLine}";
			}

			// Manufacturer Name
			if (($"{txt_amod_manufacturer[0].Text} ").Trim() == "")
			{
				bResults = false;
				strMsg = $"{strMsg}Failed - <Manufacturer Name Is Blank{Environment.NewLine}";
			}

			// Manufacturer Common Name
			if (($"{txt_amod_manufacturer[1].Text} ").Trim() == "")
			{
				bResults = false;
				strMsg = $"{strMsg}Failed - <Manufacturer Common Name Is Blank{Environment.NewLine}";
			}

			// Starting Price
			double dbl_amod_start_price = 0d;
			if (($"{txt_amod_start_price.Text} ").Trim() != "")
			{
				if (!Information.IsNumeric(txt_amod_start_price.Text))
				{
					bResults = false;
					strMsg = $"{strMsg}Failed - <Start Price Is NOT Numeric>{Environment.NewLine}";
				}
				else
				{
					dbl_amod_start_price = Double.Parse(txt_amod_start_price.Text);
				}
			}

			// Ending Price
			double dbl_amod_end_price = 0d;
			if (($"{txt_amod_end_price.Text} ").Trim() != "")
			{
				if (!Information.IsNumeric(txt_amod_end_price.Text))
				{
					bResults = false;
					strMsg = $"{strMsg}Failed - <End Price Is NOT Numeric>{Environment.NewLine}";
				}
				else
				{
					dbl_amod_end_price = Double.Parse(txt_amod_end_price.Text);
				}
			}

			// Starting Price Cannot Be Larger Than Ending Price
			if (dbl_amod_start_price > 0 && dbl_amod_end_price > 0)
			{
				if (dbl_amod_start_price > dbl_amod_end_price)
				{
					bResults = false;
					strMsg = $"{strMsg}Failed - <Start Price Is Greater Than End Price>{Environment.NewLine}";
				}
			}

			// Starting Year
			if (($"{txt_amod_start_year.Text} ").Trim() != "")
			{
				if (!Information.IsNumeric(txt_amod_start_year.Text))
				{
					bResults = false;
					strMsg = $"{strMsg}Failed - <Start Year Is NOT Numeric>{Environment.NewLine}";
				}
			}

			// Ending Year
			if (($"{txt_amod_end_year.Text} ").Trim() != "")
			{
				if (!Information.IsNumeric(txt_amod_end_year.Text))
				{
					bResults = false;
					strMsg = $"{strMsg}Failed - <End Year Is NOT Numeric>{Environment.NewLine}";
				}
			}

			// Starting Year Cannot Be Larger Than Ending Year
			if (($"{txt_amod_start_year.Text} ").Trim() != "" && ($"{txt_amod_end_year.Text} ").Trim() != "")
			{
				if (Information.IsNumeric(txt_amod_start_year.Text) && Information.IsNumeric(txt_amod_end_year.Text))
				{
					if (String.CompareOrdinal(txt_amod_start_year.Text, txt_amod_end_year.Text) > 0)
					{
						bResults = false;
						strMsg = $"{strMsg}Failed - <Start Year Is Greater Than End Year>{Environment.NewLine}";
					}
				}
			}

			// Starting SerNbr Cannot Be Larger Than Ending SerNbr
			if (Information.IsNumeric(txt_amod_ser_no_start.Text) && Information.IsNumeric(txt_amod_ser_no_end.Text))
			{
				if (Double.Parse(txt_amod_ser_no_start.Text) > Double.Parse(txt_amod_ser_no_end.Text))
				{
					bResults = false;
					strMsg = $"{strMsg}Failed - <Serial Number Start Is Greater Than Serial Number End>{Environment.NewLine}";
				}
			}

			// Model Class
			if (cbo_amod_class.Text == "")
			{
				bResults = false;
				strMsg = $"{strMsg}Failed - <Model Class Is Blank>{Environment.NewLine}";
			}

			// Weight Class
			if (cboWeightClass.Text == "")
			{
				bResults = false;
				strMsg = $"{strMsg}Failed - <Model Weight Class Is Blank>{Environment.NewLine}";
			}

			if (chk_amod_product[0].CheckState == CheckState.Unchecked && chk_amod_product[1].CheckState == CheckState.Unchecked && chk_amod_product[2].CheckState == CheckState.Unchecked)
			{
				bResults = false;
				strMsg = $"{strMsg}Failed - <No Product Code Checked.  BFlag, CFlag or HFlag Must Be Checked>{Environment.NewLine}";
			}

			// Commercial Model - Body Config - Ask
			if (chk_amod_product[2].CheckState == CheckState.Checked)
			{
				if (cmbBodyConfig.Text == "")
				{
					if (MessageBox.Show("Commercial Model with NO Body Config.  Continue?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
					{
						bResults = false;
						strMsg = $"{strMsg}Failed - <Commercial Model - Body Config Is Blank>{Environment.NewLine}";
					}
				}
			}

			// JETNETiQ Size - Ask
			if (chk_amod_product[1].CheckState == CheckState.Unchecked)
			{ // added in MSW - 10/10/19, heli shouldnt check
				if (cboJIQSize.Text == "")
				{
					if (MessageBox.Show("JNiQ Size Is Blank.  Continue?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
					{
						bResults = false;
						strMsg = $"{strMsg}Failed - <JNiQ Size Is Blank>{Environment.NewLine}";
					}
				}
			}

			// 1/23/2009 - By David D. Cruger
			// Added Validation For CompId
			if (($"{txt_amod_manufacturer[2].Text} ").Trim() == "" || ($"{txt_amod_manufacturer[2].Text} ").Trim() == "0")
			{
				bResults = false;
				strMsg = $"{strMsg}Failed - <Manufacturer CompId Is Blank or Zero>{Environment.NewLine}";
			}
			else
			{

				if (!Information.IsNumeric(txt_amod_manufacturer[2].Text))
				{
					bResults = false;
					strMsg = $"{strMsg}Failed - <Manufacturer CompId Is NOT Numeric>{Environment.NewLine}";
				}
				else
				{

					lMfrCompId = Convert.ToInt32(Double.Parse(txt_amod_manufacturer[2].Text));
					strMfrName = modCommon.DLookUp("comp_name", "Company", $"(comp_id = {lMfrCompId.ToString()} AND comp_journ_id = 0)");

					if (strMfrName == "")
					{
						bResults = false;
						strMsg = $"{strMsg}Failed - <Manufacturer CompId Cannot Be Found>{Environment.NewLine}";
					}

				} // If IsNumeric(txt_amod_manufacturer(2).Text) = False Then

			} // If Trim(txt_amod_manufacturer(2).Text & " ") = "" Or Trim(txt_amod_manufacturer(2).Text & " ") = "0" Then

			if (!bResults)
			{
				MessageBox.Show($"Failed Model Validation{Environment.NewLine}{Environment.NewLine}{strMsg}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				txt_amod_make_name.Focus();
			}

			return bResults;

		} // Validate_Aircraft_Model_Main

		public void Display_Aircraft_Model_Maintenance()
		{

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_maint_note"]))
			{
				frm_Aircraft_Model.DefInstance.txt_amod_maint_note.Text = ($"{Convert.ToString(snp_Model["amod_maint_note"])} ").Trim();
			}
			else
			{
				frm_Aircraft_Model.DefInstance.txt_amod_maint_note.Text = " ";
			}

			//Display inspection note
			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snp_Model["amod_inspection_note"]))
			{
				frm_Aircraft_Model.DefInstance.txt_amod_inspection_note.Text = ($"{Convert.ToString(snp_Model["amod_inspection_note"])} ").Trim();
			}
			else
			{
				frm_Aircraft_Model.DefInstance.txt_amod_inspection_note.Text = " ";
			}

		}

		public void Select_Aircraft()
		{

			string strStatus = ""; // Added For Error Checking

			try
			{
				this.Cursor = Cursors.WaitCursor;

				strStatus = "MoveFirst";
				snp_ModelAircraft.MoveFirst();
				int tempForEndVar = grd_Aircraft.CurrentRowIndex - 1;
				for (int i = 1; i <= tempForEndVar; i++)
				{
					strStatus = $"MoveNext ({i.ToString()}]";

					// 10/11/2002 - By David D. Cruger; Wrapped EOF around MoveNext
					if (!snp_ModelAircraft.EOF)
					{
						snp_ModelAircraft.MoveNext();
					}
					else
					{
						strStatus = "MoveNext EOF";
					}

				}

				strStatus = "Assign !acid";
				// 10/11/2002 - By David D. Cruger; Wrapped EOF around MoveNext
				if (snp_ModelAircraft.EOF)
				{
					strStatus = "Assign !acid EOF";
					snp_ModelAircraft.MoveLast(); // Just to make sure we're on a valid record
				}

				modAdminCommon.gbl_Aircraft_ID = Convert.ToInt32(snp_ModelAircraft["ac_id"]);
				modAdminCommon.gbl_Aircraft_Journal_ID = 0;

				if (!modCommon.Is_Form_Already_Loaded("frm_Aircraft"))
				{
					//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//VB.Global.Load(frm_aircraft.DefInstance);
				}

				frm_aircraft.DefInstance.Form_Initialize();
				frm_aircraft.DefInstance.StartForm = modGlobalVars.tStart_Form;
				frm_aircraft.DefInstance.Reference_Aircraft_ID = modAdminCommon.gbl_Aircraft_ID;
				frm_aircraft.DefInstance.Reference_Journal_ID = modAdminCommon.gbl_Aircraft_Journal_ID;
				frm_aircraft.DefInstance.tmp_ac_journ_id = 0;
				frm_aircraft.DefInstance.Reference_Company_ID = 0;
				frm_aircraft.DefInstance.Show();
				//UPGRADE_WARNING: (2065) Form method frm_aircraft.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
				frm_aircraft.DefInstance.BringToFront();
				//UPGRADE_WARNING: (2065) Form event Form.Activated has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
				frm_aircraft.DefInstance.Form_Activated(frm_aircraft.DefInstance, new EventArgs());
			}
			catch
			{

				this.Cursor = CursorHelper.CursorDefault;
				modAdminCommon.Report_Error($"Select_Aircraft_for_Model_Error: Status: [{strStatus}]");
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
			}

		}

		private void Check_Permission()
		{

			if (Convert.ToString(modAdminCommon.snp_User["user_type"]) == "Research Manager" || Convert.ToString(modAdminCommon.snp_User["user_type"]) == "Administrator")
			{
				Enable_Aircraft_Model();
			}
			else
			{
				Disable_Aircraft_Model();
			}

			if (Convert.ToString(modAdminCommon.snp_User["user_type"]) == "Research Manager" || Convert.ToString(modAdminCommon.snp_User["user_type"]) == "Administrator")
			{
				mnuEditSummaries.Available = true;
				txt_amod_make_name.Enabled = true;
				txt_amod_model_name.Enabled = true;
				cbo_amod_Airframe_Type_Code.Enabled = true;
				cbo_amod_type_code.Enabled = true;
				chk_amod_customer_flag.Enabled = true;
				mnuDeleteModel.Enabled = true;
				mnu_EditAdd.Enabled = true;
			}
			else
			{
				mnuEditSummaries.Available = false;
				txt_amod_make_name.Enabled = false;
				txt_amod_model_name.Enabled = false;
				cbo_amod_Airframe_Type_Code.Enabled = false;
				cbo_amod_type_code.Enabled = false;
				chk_amod_customer_flag.Enabled = false;
				mnuDeleteModel.Enabled = false;
				mnu_EditAdd.Enabled = false;
			}

		} // Check_Permission

		public void Enable_Aircraft_Model()
		{

			cmd_Update.Visible = true;
			//UPGRADE_ISSUE: (207) An invalid structure was generated in this location, inside Enable_Aircraft_Model. Please check source code. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-207
			//cmd_button_array().Visible = True
			//UPGRADE_ISSUE: (207) An invalid structure was generated in this location, inside Enable_Aircraft_Model. Please check source code. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-207
			//cmd_button_array().Visible = True
			cmd_Add_Engine.Visible = true;
			cmd_Remove_Engine.Visible = true;

			cmdUseage[0].Enabled = true;
			cmdUseage[1].Enabled = true;
			cmdUseage[2].Enabled = true;
			cmdUseage[3].Enabled = true;
			cmdUseage[4].Enabled = true;

		}

		public void Disable_Aircraft_Model()
		{

			cmd_Update.Visible = false;
			//UPGRADE_ISSUE: (207) An invalid structure was generated in this location, inside Disable_Aircraft_Model. Please check source code. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-207
			//cmd_button_array().Visible = False
			//UPGRADE_ISSUE: (207) An invalid structure was generated in this location, inside Disable_Aircraft_Model. Please check source code. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-207
			//cmd_button_array().Visible = False
			cmd_Add_Engine.Visible = false;
			cmd_Remove_Engine.Visible = false;

		}

		public void Fill_Aircraft_Model_Trend_List()
		{

			ADORecordSetHelper snp_ModelTrend = new ADORecordSetHelper(); // Snapshot

			string errMsg = "";
			try
			{

				System.DateTime dtCurrentDateTime = DateTime.FromOADate(0);
				string strTemp = "";
				string Query = "";
				int ColCount = 0;

				int iACNewOnMKT = 0; // A/C New On Market
				double iChgMktInvt = 0; // Change in Market Inventory
				double iChgDlrInvt = 0; // Change in Market Inventory
				int iACForSalePrev = 0; // Number of A/C For Sale Previous Month
				int iDealerOwnedPrev = 0; // Number of A/C For Sale Dealer Owned Previous Month
				int iACForSaleCurr = 0; // Number of A/C For Sale Current Month
				int iDealerOwnedCurr = 0; // Number of A/C For Sale Dealer Owned Current Month

				errMsg = "setup grid";
				this.Cursor = Cursors.WaitCursor;
				//grd_ModelTrend.ClearFields
				// SET UP GRID
				grd_ModelTrend.Clear();

				grd_ModelTrend.SetColumnWidth(0, 117); // Default Was 3000
				grd_ModelTrend.RowsCount = 42;
				grd_ModelTrend.ColumnsCount = 2;
				grd_ModelTrend.CurrentRowIndex = 0;
				grd_ModelTrend.CurrentColumnIndex = 0;
				grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = "YEAR \\ MONTH";

				grd_ModelTrend.CurrentRowIndex = 1;
				grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = " # of A/C for Sale";
				grd_ModelTrend.CurrentRowIndex = 2;
				grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = " End User";
				grd_ModelTrend.CurrentRowIndex = 3;
				grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = " End User w/Excl";
				grd_ModelTrend.CurrentRowIndex = 4;
				grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = " Dealer Owned";
				grd_ModelTrend.CurrentRowIndex = 5;
				grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = " Domestic";
				grd_ModelTrend.CurrentRowIndex = 6;
				grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = " International";

				grd_ModelTrend.CurrentRowIndex = 7;
				grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = " Asking: Avg";
				grd_ModelTrend.CurrentRowIndex = 8;
				grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = " (,000) High)";
				grd_ModelTrend.CurrentRowIndex = 9;
				grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = "      Low";
				grd_ModelTrend.CurrentRowIndex = 10;
				grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = "      Mk Offer";

				grd_ModelTrend.CurrentRowIndex = 11;
				grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = " Avg Year";
				grd_ModelTrend.CurrentRowIndex = 12;
				grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = " Airframe TT Avg";
				grd_ModelTrend.CurrentRowIndex = 13;
				grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = " Engine TT Avg";

				grd_ModelTrend.CurrentRowIndex = 14;
				grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = " A/C NEW on Mkt";

				grd_ModelTrend.CurrentRowIndex = 15;
				grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = " Chg Mkt Invtry";
				grd_ModelTrend.CurrentRowIndex = 16;
				grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = " Chg Dlr Invtry";

				grd_ModelTrend.CurrentRowIndex = 17;
				grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = " "; // Blank Cell

				grd_ModelTrend.CurrentRowIndex = 18;
				grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = " # of A/C Sold";

				grd_ModelTrend.CurrentRowIndex = 19;
				grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = " Retail to Retail";
				grd_ModelTrend.CurrentRowIndex = 20;
				grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = " Retail to Dealer";
				grd_ModelTrend.CurrentRowIndex = 21;
				grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = " Dealer to Retail";
				grd_ModelTrend.CurrentRowIndex = 22;
				grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = " Dealer to Dealer";

				grd_ModelTrend.CurrentRowIndex = 23;
				grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = " New to Retail";
				grd_ModelTrend.CurrentRowIndex = 24;
				grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = " New to Dealer";
				grd_ModelTrend.CurrentRowIndex = 25;
				grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = " Awaiting Doc";

				grd_ModelTrend.CurrentRowIndex = 26;
				grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = " Domest. to Domest.";
				grd_ModelTrend.CurrentRowIndex = 27;
				grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = " Domest. to Intl.";
				grd_ModelTrend.CurrentRowIndex = 28;
				grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = " Intl. to Intl.";
				grd_ModelTrend.CurrentRowIndex = 29;
				grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = " Intl. to Domest.";
				grd_ModelTrend.CurrentRowIndex = 30;
				grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = " Awaiting Doc";

				grd_ModelTrend.CurrentRowIndex = 31;
				grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = " Asking: Avg";
				grd_ModelTrend.CurrentRowIndex = 32;
				grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = " (,000) High";
				grd_ModelTrend.CurrentRowIndex = 33;
				grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = "      Low";
				grd_ModelTrend.CurrentRowIndex = 34;
				grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = "      Mk Offer";

				grd_ModelTrend.CurrentRowIndex = 35;
				grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = " Avg Year";
				grd_ModelTrend.CurrentRowIndex = 36;
				grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = " Avg Days On Mkt";

				grd_ModelTrend.CurrentRowIndex = 37;
				grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = " "; // Blank Cell

				grd_ModelTrend.CurrentRowIndex = 38;
				grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = " Leased";
				grd_ModelTrend.CurrentRowIndex = 39;
				grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = " Foreclosures";
				grd_ModelTrend.CurrentRowIndex = 40;
				grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = " Off Market";
				grd_ModelTrend.CurrentRowIndex = 41;
				grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = " Internal Trans.";

				// ----------------------------------------------------------------------
				// Temp Hold Limit to the last 11 months. - By David D. Cruger
				// The Current Month is not used as there isn't any available data yet.
				// ----------------------------------------------------------------------
				dtCurrentDateTime = DateTime.Now.AddMonths(-12);

				errMsg = "Query";
				Query = "SELECT * ";
				Query = $"{Query}FROM Aircraft_Model_Trend WITH(NOLOCK) ";
				Query = $"{Query}WHERE (mtrend_amod_id={Convert.ToString(snp_Model["amod_id"])}) ";
				Query = $"{Query}AND ((mtrend_year > {dtCurrentDateTime.Year.ToString()}) ";
				Query = $"{Query}OR  ((mtrend_year = {dtCurrentDateTime.Year.ToString()}) ";
				Query = $"{Query}AND (mtrend_month > {dtCurrentDateTime.Month.ToString()}))) ";
				Query = $"{Query}ORDER BY mtrend_year,mtrend_month";

				ColCount = 0;
				//Set snp_ModelTrend = LOCAL_DB.OpenRecordset(Query, dbOpenSnapshot, dbSQLPassThrough)
				snp_ModelTrend.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_ModelTrend.BOF && snp_ModelTrend.EOF))
				{
					errMsg = "move first";
					snp_ModelTrend.MoveFirst();

					while(!snp_ModelTrend.EOF)
					{
						grd_ModelTrend.CurrentRowIndex = 0;
						ColCount++;
						grd_ModelTrend.ColumnsCount++;
						grd_ModelTrend.CurrentColumnIndex = ColCount;

						grd_ModelTrend.CurrentRowIndex = 0;
						grd_ModelTrend.SetColumnWidth(grd_ModelTrend.CurrentColumnIndex, 73);
						strTemp = $"{StringsHelper.Format(snp_ModelTrend["mtrend_year"], "####")}/" +
						          $"{StringsHelper.Format(snp_ModelTrend["mtrend_month"], "00")}";
						grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = modAdminCommon.gbl_RightAdjust(strTemp, "@@@@@@@@@@");

						grd_ModelTrend.CurrentRowIndex = 1;
						grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = modAdminCommon.gbl_RightAdjust(snp_ModelTrend.GetField("mtrend_total_aircraft_for_sale"), "##,###,##0");
						grd_ModelTrend.CurrentRowIndex = 2;
						grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = modAdminCommon.gbl_RightAdjust(snp_ModelTrend.GetField("mtrend_end_user_count"), "##,###,##0");
						grd_ModelTrend.CurrentRowIndex = 3;
						grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = modAdminCommon.gbl_RightAdjust(snp_ModelTrend.GetField("mtrend_euser_exclusive_count"), "##,###,##0");
						grd_ModelTrend.CurrentRowIndex = 4;
						grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = modAdminCommon.gbl_RightAdjust(snp_ModelTrend.GetField("mtrend_dealer_owned_count"), "##,###,##0");
						grd_ModelTrend.CurrentRowIndex = 5;
						grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = modAdminCommon.gbl_RightAdjust(snp_ModelTrend.GetField("mtrend_domestic_count"), "##,###,##0");
						grd_ModelTrend.CurrentRowIndex = 6;
						grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = modAdminCommon.gbl_RightAdjust(snp_ModelTrend.GetField("mtrend_international_count"), "##,###,##0");

						grd_ModelTrend.CurrentRowIndex = 7;
						grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = modAdminCommon.gbl_RightAdjust(snp_ModelTrend.GetField("mtrend_avg_asking_price"), "##,###,##0");
						grd_ModelTrend.CurrentRowIndex = 8;
						grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = modAdminCommon.gbl_RightAdjust(snp_ModelTrend.GetField("mtrend_high_asking_price"), "##,###,##0");
						grd_ModelTrend.CurrentRowIndex = 9;
						grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = modAdminCommon.gbl_RightAdjust(snp_ModelTrend.GetField("mtrend_low_asking_price"), "##,###,##0");
						grd_ModelTrend.CurrentRowIndex = 10;
						grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = modAdminCommon.gbl_RightAdjust(snp_ModelTrend.GetField("mtrend_make_offer_count"), "##,###,##0");

						grd_ModelTrend.CurrentRowIndex = 11;
						grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = modAdminCommon.gbl_RightAdjust(snp_ModelTrend.GetField("mtrend_avg_year"), "#########0");
						grd_ModelTrend.CurrentRowIndex = 12;
						grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = modAdminCommon.gbl_RightAdjust(snp_ModelTrend.GetField("mtrend_avg_airframe_time"), "##,###,##0");
						grd_ModelTrend.CurrentRowIndex = 13;
						grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = modAdminCommon.gbl_RightAdjust(snp_ModelTrend.GetField("mtrend_avg_engine_time"), "##,###,##0");

						//A/C NEW on Mkt
						iACNewOnMKT = Convert.ToInt32(snp_ModelTrend["mtrend_new_onmarket_count"]);
						if (iACNewOnMKT == 0)
						{ // Use New Fields
							//UPGRADE-WARNING: It was not possible to determine if this addition expression should use an addition operator (+) or a concatenation operator (&)
							iACNewOnMKT = Convert.ToInt32(Convert.ToDouble(snp_ModelTrend["mtrend_avail_new_onmarket_count"]) + Convert.ToDouble(snp_ModelTrend["mtrend_sold_new_onmarket_count"]));
						}

						grd_ModelTrend.CurrentRowIndex = 14;
						grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = modAdminCommon.gbl_RightAdjust(iACNewOnMKT, "##,###,##0");

						// Temp Hold Not Completed Yet
						// Change In Inventory Goes Here.  Mkt/Dlr Inventory
						iChgMktInvt = 0; // Change in Market Inventory
						iChgDlrInvt = 0; // Change in Dealer Inventory
						iACForSalePrev = 0; // Number of A/C For Sale Previous Month
						iDealerOwnedPrev = 0; // Number of A/C For Sale Dealer Owned Current Month
						iACForSaleCurr = 0; // Number of A/C For Sale Previous Month
						iDealerOwnedCurr = 0; // Number of A/C For Sale Dealer Owned Current Month

						if (ColCount > 1)
						{ // There are Previous Colums
							errMsg = "colcount+1";
							// Get Previous Months Data
							ColCount--;
							grd_ModelTrend.CurrentColumnIndex = ColCount;

							grd_ModelTrend.CurrentRowIndex = 1; // # of A/C For Sale
							iACForSalePrev = Convert.ToInt32(Double.Parse(grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].FormattedValue.ToString().Trim()));
							grd_ModelTrend.CurrentRowIndex = 4; // Dealer Owned
							iDealerOwnedPrev = Convert.ToInt32(Double.Parse(grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].FormattedValue.ToString().Trim()));

							ColCount++; // Put The Colum Back
							grd_ModelTrend.CurrentColumnIndex = ColCount;

							// Get Current Months Data
							iACForSaleCurr = Convert.ToInt32(snp_ModelTrend["mtrend_total_aircraft_for_sale"]);
							iDealerOwnedCurr = Convert.ToInt32(snp_ModelTrend["mtrend_dealer_owned_count"]);

							// Now Calculate the Percentage Differenct between the previous/current Months

							//-- Market Change
							if (iACForSalePrev == 0 && iACForSaleCurr != 0)
							{ // 100% Gain
								iChgMktInvt = iACForSaleCurr * 100;
							}
							if (iACForSalePrev != 0 && iACForSaleCurr == 0)
							{ // 100% Lose
								iChgMktInvt = -100;
							}
							if (iACForSalePrev != 0 && iACForSaleCurr != 0)
							{ // Calculate Gain/Lose
								iChgMktInvt = ((iACForSaleCurr / ((double) iACForSalePrev)) - 1) * 100;
							}

							//-- Dealer Change
							if (iDealerOwnedPrev == 0 && iDealerOwnedCurr != 0)
							{ // 100% Gain
								iChgDlrInvt = iACForSaleCurr * 100;
							}
							if (iDealerOwnedPrev != 0 && iDealerOwnedCurr == 0)
							{ // 100% Lose
								iChgDlrInvt = -100;
							}
							if (iDealerOwnedPrev != 0 && iDealerOwnedCurr != 0)
							{ // Calculate Gain/Lose
								iChgDlrInvt = ((iDealerOwnedCurr / ((double) iDealerOwnedPrev)) - 1) * 100;
							}

						} // ColCount > 1

						grd_ModelTrend.CurrentRowIndex = 15; // Mkt Inventory
						strTemp = $"{StringsHelper.Format(iChgMktInvt, "00.00")}%";
						grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = modAdminCommon.gbl_RightAdjust(strTemp, "@@@@@@@@@@");

						grd_ModelTrend.CurrentRowIndex = 16; // Dlr Inventory
						strTemp = $"{StringsHelper.Format(iChgDlrInvt, "00.00")}%";
						grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = modAdminCommon.gbl_RightAdjust(strTemp, "@@@@@@@@@@");

						grd_ModelTrend.CurrentRowIndex = 17; // Blank Cell
						grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = " ";

						grd_ModelTrend.CurrentRowIndex = 18;
						grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = modAdminCommon.gbl_RightAdjust(snp_ModelTrend.GetField("mtrend_sold_total_count"), "##,###,##0");

						grd_ModelTrend.CurrentRowIndex = 19;
						grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = modAdminCommon.gbl_RightAdjust(snp_ModelTrend.GetField("mtrend_sold_r_to_r_count"), "##,###,##0");
						grd_ModelTrend.CurrentRowIndex = 20;
						grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = modAdminCommon.gbl_RightAdjust(snp_ModelTrend.GetField("mtrend_sold_r_to_d_count"), "##,###,##0");
						grd_ModelTrend.CurrentRowIndex = 21;
						grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = modAdminCommon.gbl_RightAdjust(snp_ModelTrend.GetField("mtrend_sold_d_to_r_count"), "##,###,##0");
						grd_ModelTrend.CurrentRowIndex = 22;
						grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = modAdminCommon.gbl_RightAdjust(snp_ModelTrend.GetField("mtrend_sold_d_to_d_count"), "##,###,##0");

						grd_ModelTrend.CurrentRowIndex = 23;
						grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = modAdminCommon.gbl_RightAdjust(snp_ModelTrend.GetField("mtrend_sold_new_to_retail_count"), "##,###,##0");
						grd_ModelTrend.CurrentRowIndex = 24;
						grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = modAdminCommon.gbl_RightAdjust(snp_ModelTrend.GetField("mtrend_sold_new_to_dealer_count"), "##,###,##0");
						grd_ModelTrend.CurrentRowIndex = 25;
						grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = modAdminCommon.gbl_RightAdjust(snp_ModelTrend.GetField("mtrend_sold_to_ad_all_count"), "##,###,##0");

						grd_ModelTrend.CurrentRowIndex = 26;
						grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = modAdminCommon.gbl_RightAdjust(snp_ModelTrend.GetField("mtrend_sold_dom_to_dom_count"), "##,###,##0");
						grd_ModelTrend.CurrentRowIndex = 27;
						grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = modAdminCommon.gbl_RightAdjust(snp_ModelTrend.GetField("mtrend_sold_dom_to_int_count"), "##,###,##0");
						grd_ModelTrend.CurrentRowIndex = 28;
						grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = modAdminCommon.gbl_RightAdjust(snp_ModelTrend.GetField("mtrend_sold_int_to_int_count"), "##,###,##0");
						grd_ModelTrend.CurrentRowIndex = 29;
						grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = modAdminCommon.gbl_RightAdjust(snp_ModelTrend.GetField("mtrend_sold_int_to_dom_count"), "##,###,##0");
						grd_ModelTrend.CurrentRowIndex = 30;
						grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = modAdminCommon.gbl_RightAdjust(snp_ModelTrend.GetField("mtrend_sold_to_ad_unknown_count"), "##,###,##0");

						grd_ModelTrend.CurrentRowIndex = 31;
						grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = modAdminCommon.gbl_RightAdjust(snp_ModelTrend.GetField("mtrend_avg_selling_price"), "##,###,##0");
						grd_ModelTrend.CurrentRowIndex = 32;
						grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = modAdminCommon.gbl_RightAdjust(snp_ModelTrend.GetField("mtrend_high_selling_price"), "##,###,##0");
						grd_ModelTrend.CurrentRowIndex = 33;
						grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = modAdminCommon.gbl_RightAdjust(snp_ModelTrend.GetField("mtrend_low_selling_price"), "##,###,##0");
						grd_ModelTrend.CurrentRowIndex = 34;
						grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = modAdminCommon.gbl_RightAdjust(snp_ModelTrend.GetField("mtrend_sold_make_offer_count"), "##,###,##0");

						grd_ModelTrend.CurrentRowIndex = 35;
						grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = modAdminCommon.gbl_RightAdjust(snp_ModelTrend.GetField("mtrend_avg_selling_year"), "#########0");
						grd_ModelTrend.CurrentRowIndex = 36;
						grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = modAdminCommon.gbl_RightAdjust(snp_ModelTrend.GetField("mtrend_avg_market_days"), "##,###,##0");

						grd_ModelTrend.CurrentRowIndex = 37; // Blank Cell
						grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = " ";

						grd_ModelTrend.CurrentRowIndex = 38;
						grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = modAdminCommon.gbl_RightAdjust(snp_ModelTrend.GetField("mtrend_lease_count"), "##,###,##0");
						grd_ModelTrend.CurrentRowIndex = 39;
						grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = modAdminCommon.gbl_RightAdjust(snp_ModelTrend.GetField("mtrend_foreclosed_count"), "##,###,##0");
						grd_ModelTrend.CurrentRowIndex = 40;
						grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = modAdminCommon.gbl_RightAdjust(snp_ModelTrend.GetField("mtrend_off_market_count"), "##,###,##0");
						grd_ModelTrend.CurrentRowIndex = 41;
						grd_ModelTrend[grd_ModelTrend.CurrentRowIndex, grd_ModelTrend.CurrentColumnIndex].Value = modAdminCommon.gbl_RightAdjust(snp_ModelTrend.GetField("mtrend_inttrns_count"), "##,###,##0");

						snp_ModelTrend.MoveNext();
						Application.DoEvents();
					};
					snp_ModelTrend.Close();
					grd_ModelTrend.FixedRows = 1;
					grd_ModelTrend.FixedColumns = 1;
					errMsg = "end";
				}
				this.Cursor = CursorHelper.CursorDefault;
				snp_ModelTrend = null;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				errMsg = $"{errMsg} {excep.Message} {Information.Err().Number.ToString()}";
				this.Cursor = CursorHelper.CursorDefault;
				MessageBox.Show($"Fill_Aircraft_Model_Trend_List_Error: {errMsg}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				return;
			}
		}

		//UPGRADE_NOTE: (7001) The following declaration (Valid_Admin_Data) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private bool Valid_Admin_Data()
		//{
			//
			//bool result = false;
			//try
			//{
				//
				//result = true;
				//
				//if (!Information.IsNumeric(txt_amod_common_verify_days.Text))
				//{
					//result = false;
					//MessageBox.Show("Common Verify Days Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					//txt_amod_common_verify_days.Focus();
					//return result;
				//}
				//else
				//{
					//txt_amod_common_verify_days.Text = Double.Parse(txt_amod_common_verify_days.Text).ToString();
				//}
				//
				//if (!Information.IsNumeric(txt_amod_sale_verify_days.Text))
				//{
					//result = false;
					//MessageBox.Show("Sale Verify Days Not Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					//txt_amod_sale_verify_days.Focus();
					//return result;
				//}
				//else
				//{
					//txt_amod_sale_verify_days.Text = Double.Parse(txt_amod_sale_verify_days.Text).ToString();
				//}
			//}
			//catch (System.Exception excep)
			//{
				//
				//modAdminCommon.Report_Error($"Valid_Admin_Data_Error: {excep.Message}");
			//}
			//
			//return result;
		//}

		public void Clear_Aircraft_Admin()
		{

			chk_amod_customer_flag.CheckState = CheckState.Unchecked;
			txt_amod_ent_user_id.Text = modAdminCommon.gbl_User_ID;
			txt_amod_ent_date.Text = StringsHelper.Format(DateTime.Now, "mm/dd/yyyy hh:MM:ss AMPM");
			txt_amod_upd_user_id.Text = modAdminCommon.gbl_User_ID;
			txt_amod_upd_date.Text = StringsHelper.Format(DateTime.Now, "mm/dd/yyyy hh:MM:ss AMPM");
			txt_amod_common_verify_days.Text = "0";
			txt_amod_sale_verify_days.Text = "0";

		}

		public void Fill_Aircraft_Model_Wanted()
		{
			try
			{

				string Query = "";
				string acline = "";
				int i = 0;
				int total = 0;
				string temploc = "";
				//    Dim snp_Model_Wanted As Snapshot converted to ado 7/25/05 aey
				ADORecordSetHelper snp_Model_Wanted = new ADORecordSetHelper();

				i = 0;
				lst_aircraft_wanted.Items.Clear();
				Query = $"SELECT * FROM Aircraft_Model_Wanted, Aircraft_Model, Company WHERE amwant_amod_id = {Convert.ToString(snp_Model["amod_id"])}";
				Query = $"{Query} AND amwant_amod_id = amod_id AND amwant_comp_id = comp_id AND comp_journ_id = 0 AND amod_customer_flag = 'Y'";
				Query = $"{Query} ORDER BY amwant_listed_date";

				snp_Model_Wanted.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_Model_Wanted.BOF && snp_Model_Wanted.EOF))
				{
					snp_Model_Wanted.MoveFirst();
					i++;

					while(!snp_Model_Wanted.EOF)
					{
						acline = $"{Convert.ToDateTime(snp_Model_Wanted["amwant_listed_date"]).ToString("MM/dd/yy")}   ";
						acline = $"{acline}{modAdminCommon.gbl_LeftAdjust(Convert.ToString(snp_Model_Wanted["comp_name"]).Substring(Math.Min(0, Convert.ToString(snp_Model_Wanted["comp_name"]).Length), Math.Min(20, Math.Max(0, Convert.ToString(snp_Model_Wanted["comp_name"]).Length))), "@@@@@@@@@@@@@@@@@@@@")}        ";
						temploc = $"{($"{Convert.ToString(snp_Model_Wanted["Comp_city"])}")},{($"{Convert.ToString(snp_Model_Wanted["comp_state"])} ")}";
						acline = $"{acline}{modAdminCommon.gbl_LeftAdjust(temploc.Substring(Math.Min(0, temploc.Length), Math.Min(15, Math.Max(0, temploc.Length))), "@@@@@@@@@@@@@@@")}   ";
						acline = $"{acline}{modAdminCommon.gbl_LeftAdjust(snp_Model_Wanted.GetField("amwant_start_year"), "@@@@")}        ";
						acline = $"{acline}{modAdminCommon.gbl_LeftAdjust(snp_Model_Wanted.GetField("amwant_end_year"), "@@@@")} ";
						acline = $"{acline}{modAdminCommon.gbl_RightAdjust(snp_Model_Wanted.GetField("amwant_max_price"), "###,###,###,##0")}  ";
						acline = $"{acline}{modAdminCommon.gbl_RightAdjust(snp_Model_Wanted.GetField("amwant_max_aftt"), "##############")}      ";

						//        acline = acline & gbl_LeftAdjust(snp_Model_Wanted!amwant_damage_flag, "@") & " "

						lst_aircraft_wanted.AddItem(acline);
						snp_Model_Wanted.MoveNext();
						i++;
					};
					total = i - 1;
				}

				this.Cursor = CursorHelper.CursorDefault;
			}
			catch (System.Exception excep)
			{

				this.Cursor = CursorHelper.CursorDefault;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_Aircraft_Model_Wanted_Error: {Information.Err().Number.ToString()} {excep.Message} {excep.Source}");
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
				return;
			}

		}

		private void Fill_Aircraft_Model_Aircraft_Grid()
		{

			try
			{
				string Query = "";
				string cellcolor = "";
				int ACount = 0;
				this.Cursor = Cursors.WaitCursor;
				cmdStop.Visible = false;
				Application.DoEvents();
				grd_Aircraft.Visible = false;

				ModelStopped = false;
				Label6[11].Text = "";
				grd_Aircraft.Clear();
				grd_Aircraft.ColumnsCount = 12;
				grd_Aircraft.RowsCount = 1;

				grd_Aircraft.CurrentRowIndex = 0;
				grd_Aircraft.CurrentColumnIndex = 0;
				grd_Aircraft.SetColumnWidth(0, 67);
				grd_Aircraft[grd_Aircraft.CurrentRowIndex, grd_Aircraft.CurrentColumnIndex].Value = "Serial#";
				grd_Aircraft.CurrentColumnIndex = 1;
				grd_Aircraft.SetColumnWidth(1, 80);
				grd_Aircraft[grd_Aircraft.CurrentRowIndex, grd_Aircraft.CurrentColumnIndex].Value = "Registration#";
				grd_Aircraft.CurrentColumnIndex = 3;
				grd_Aircraft.SetColumnWidth(3, 33);
				grd_Aircraft[grd_Aircraft.CurrentRowIndex, grd_Aircraft.CurrentColumnIndex].Value = "DLV";
				grd_Aircraft.CurrentColumnIndex = 2;
				grd_Aircraft.SetColumnWidth(2, 33);
				grd_Aircraft[grd_Aircraft.CurrentRowIndex, grd_Aircraft.CurrentColumnIndex].Value = "MFR";
				grd_Aircraft.CurrentColumnIndex = 4;
				grd_Aircraft.SetColumnWidth(4, 80);
				grd_Aircraft[grd_Aircraft.CurrentRowIndex, grd_Aircraft.CurrentColumnIndex].Value = "Last Verified";
				grd_Aircraft.CurrentColumnIndex = 5;
				grd_Aircraft.SetColumnWidth(5, 80);
				grd_Aircraft[grd_Aircraft.CurrentRowIndex, grd_Aircraft.CurrentColumnIndex].Value = "Next Verified";
				grd_Aircraft.CurrentColumnIndex = 6;
				grd_Aircraft.SetColumnWidth(6, 87);
				grd_Aircraft[grd_Aircraft.CurrentRowIndex, grd_Aircraft.CurrentColumnIndex].Value = "Status";

				grd_Aircraft.CurrentColumnIndex = 9;
				grd_Aircraft.SetColumnWidth(9, 20);
				grd_Aircraft[grd_Aircraft.CurrentRowIndex, grd_Aircraft.CurrentColumnIndex].Value = "B";
				grd_Aircraft.CurrentColumnIndex = 10;
				grd_Aircraft.SetColumnWidth(10, 20);
				grd_Aircraft[grd_Aircraft.CurrentRowIndex, grd_Aircraft.CurrentColumnIndex].Value = "C";
				grd_Aircraft.CurrentColumnIndex = 11;
				grd_Aircraft.SetColumnWidth(11, 20);
				grd_Aircraft[grd_Aircraft.CurrentRowIndex, grd_Aircraft.CurrentColumnIndex].Value = "H";
				ACount = 0;
				lbl_Message.Text = "Searching for Aircraft ...";
				Application.DoEvents();
				Query = "SELECT ac_ser_no_full,ac_delivery,ac_asking_price,ac_id,ac_forsale_flag, ac_mfr_year, ";
				Query = $"{Query}ac_forsale_flag,ac_year,ac_reg_no,ac_asking,ac_status,ac_last_verified_date,ac_next_verified_date,ac_exclusive_flag,ac_lease_flag ";
				Query = $"{Query}, ac_product_business_flag,  ac_product_commercial_flag,  ac_product_helicopter_flag ";
				Query = $"{Query}FROM Aircraft WITH(NOLOCK) ";
				Query = $"{Query}WHERE ac_amod_id={Convert.ToString(snp_Model["amod_id"])} ";
				Query = $"{Query}and ac_journ_id=0 ";
				Query = $"{Query}ORDER BY ac_ser_no_sort";
				//Set snp_ModelAircraft = LOCAL_DB.OpenRecordset(Query, dbOpenSnapshot, dbSQLPassThrough)
				snp_ModelAircraft = new ADORecordSetHelper();
				snp_ModelAircraft.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_ModelAircraft.BOF && snp_ModelAircraft.EOF))
				{
					snp_ModelAircraft.MoveLast();
					snp_ModelAircraft.MoveFirst();
					lbl_Message.Text = "Filling Aircraft List ...";
					cmdStop.Visible = true;

					while(!snp_ModelAircraft.EOF)
					{
						if (ModelStopped)
						{
							break;
						}
						if (Convert.ToString(snp_ModelAircraft["ac_forsale_flag"]) == "Y")
						{
							cellcolor = modAdminCommon.ForSaleColor;
						}
						else
						{
							cellcolor = modAdminCommon.NoColor;
						}
						grd_Aircraft.RowsCount++;
						grd_Aircraft.CurrentRowIndex++;
						ACount++;
						grd_Aircraft.CurrentColumnIndex = 0;
						grd_Aircraft.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
						grd_Aircraft[grd_Aircraft.CurrentRowIndex, grd_Aircraft.CurrentColumnIndex].Value = $" {($"{Convert.ToString(snp_ModelAircraft["ac_ser_no_full"])} ").Trim()}";
						grd_Aircraft.CurrentColumnIndex = 1;
						grd_Aircraft.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
						grd_Aircraft[grd_Aircraft.CurrentRowIndex, grd_Aircraft.CurrentColumnIndex].Value = $" {($"{Convert.ToString(snp_ModelAircraft["ac_reg_no"])} ").Trim()}";
						grd_Aircraft.CurrentColumnIndex = 2;
						grd_Aircraft.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
						grd_Aircraft[grd_Aircraft.CurrentRowIndex, grd_Aircraft.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_ModelAircraft["ac_mfr_year"])}").Trim();
						grd_Aircraft.CurrentColumnIndex = 3;
						grd_Aircraft.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
						grd_Aircraft[grd_Aircraft.CurrentRowIndex, grd_Aircraft.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_ModelAircraft["ac_year"])}").Trim();
						grd_Aircraft.CurrentColumnIndex = 4;
						grd_Aircraft.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
						grd_Aircraft[grd_Aircraft.CurrentRowIndex, grd_Aircraft.CurrentColumnIndex].Value = Convert.ToDateTime(snp_ModelAircraft["ac_last_verified_date"]).ToString("MM/dd/yy");
						grd_Aircraft.CurrentColumnIndex = 5;
						grd_Aircraft.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
						grd_Aircraft[grd_Aircraft.CurrentRowIndex, grd_Aircraft.CurrentColumnIndex].Value = Convert.ToDateTime(snp_ModelAircraft["ac_next_verified_date"]).ToString("MM/dd/yy");
						grd_Aircraft.CurrentColumnIndex = 6;
						grd_Aircraft.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
						grd_Aircraft[grd_Aircraft.CurrentRowIndex, grd_Aircraft.CurrentColumnIndex].Value = $" {($"{Convert.ToString(snp_ModelAircraft["ac_status"])} ").Trim()}";

						grd_Aircraft.CurrentColumnIndex = 7;
						grd_Aircraft.SetColumnWidth(grd_Aircraft.CurrentColumnIndex, 13);
						if (Convert.ToString(snp_ModelAircraft["ac_exclusive_flag"]) == "Y")
						{
							grd_Aircraft.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.ExclusiveColor)));
						}
						else
						{
							grd_Aircraft.CellBackColor = Color.White;
						}

						grd_Aircraft.CurrentColumnIndex = 8;
						grd_Aircraft.SetColumnWidth(grd_Aircraft.CurrentColumnIndex, 13);
						if (Convert.ToString(snp_ModelAircraft["ac_lease_flag"]) == "Y")
						{
							grd_Aircraft.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.LeaseColor)));
						}
						else
						{
							grd_Aircraft.CellBackColor = Color.White;
						}


						grd_Aircraft.CurrentColumnIndex = 9;
						grd_Aircraft.SetColumnWidth(grd_Aircraft.CurrentColumnIndex, 20);
						if (Convert.ToString(snp_ModelAircraft["ac_product_business_flag"]) == "Y")
						{
							grd_Aircraft[grd_Aircraft.CurrentRowIndex, grd_Aircraft.CurrentColumnIndex].Value = "B";
						}
						else
						{
							grd_Aircraft[grd_Aircraft.CurrentRowIndex, grd_Aircraft.CurrentColumnIndex].Value = "";
						}

						grd_Aircraft.CurrentColumnIndex = 10;
						grd_Aircraft.SetColumnWidth(grd_Aircraft.CurrentColumnIndex, 20);
						if (Convert.ToString(snp_ModelAircraft["ac_product_commercial_flag"]) == "Y")
						{
							grd_Aircraft[grd_Aircraft.CurrentRowIndex, grd_Aircraft.CurrentColumnIndex].Value = "C";
						}
						else
						{
							grd_Aircraft[grd_Aircraft.CurrentRowIndex, grd_Aircraft.CurrentColumnIndex].Value = "";
						}

						grd_Aircraft.CurrentColumnIndex = 11;
						grd_Aircraft.SetColumnWidth(grd_Aircraft.CurrentColumnIndex, 20);
						if (Convert.ToString(snp_ModelAircraft["ac_product_helicopter_flag"]) == "Y")
						{
							grd_Aircraft[grd_Aircraft.CurrentRowIndex, grd_Aircraft.CurrentColumnIndex].Value = "H";
						}
						else
						{
							grd_Aircraft[grd_Aircraft.CurrentRowIndex, grd_Aircraft.CurrentColumnIndex].Value = "";
						}

						snp_ModelAircraft.MoveNext();
						txt_TotalAircraft.Text = StringsHelper.Format(ACount, "###,###");
						Application.DoEvents();
					};
					grd_Aircraft.FixedRows = 1;
					grd_Aircraft.Visible = true;
					mnuDeleteModel.Available = false;
				}
				else
				{
					lbl_Message.Text = "No Aircraft Found.";
					mnuDeleteModel.Available = true;
				}
				txt_TotalAircraft.Text = StringsHelper.Format(ACount, "###,###");
				this.Cursor = CursorHelper.CursorDefault;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				MessageBox.Show($"Fill_Aircraft_Model_Aircraft_Grid_Error: {Information.Err().Number.ToString()} {excep.Message}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				return;
			}
		}

		private void Check_For_Model_Picture()
		{

			string strFileName = "";

			try
			{

				img_Model_Picture.Visible = false;

				if (Strings.Len(modAdminCommon.gbl_ModelPictures.Trim()) > 0)
				{

					strFileName = $"{modAdminCommon.gbl_ModelPictures}\\{Convert.ToString(snp_Model["amod_id"])}.jpg";

					if (File.Exists(strFileName))
					{

						img_Model_Picture.Image = Image.FromFile($"{modAdminCommon.gbl_ModelPictures}\\{Convert.ToString(snp_Model["amod_id"])}.jpg");
						img_Model_Picture.Visible = true;

					}

				} // If gfso.FileExists(strFileName) = True Then
			}
			catch
			{

				img_Model_Picture.Visible = false;
			}

		}


		public void Delete_Model()
		{

			string Query = "Delete from Aircraft_Model";
			Query = $"{Query} where amod_id='{Convert.ToString(snp_Model["amod_id"])}'";
			DbCommand TempCommand = null;
			TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
			UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
			TempCommand.CommandText = Query;
			//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
			TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
			UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
			TempCommand.ExecuteNonQuery();

			Fill_Aircraft_Model_List(0);

		}

		public void Key_Feature_Fill_Grid()
		{

			ADORecordSetHelper ado_KeyFeature = default(ADORecordSetHelper);
			try
			{
				string Query = "";
				ado_KeyFeature = new ADORecordSetHelper();

				// MAKE THE MOVE UP AND DOWN BUTTONS INVISIBLE
				//UPGRADE_ISSUE: (207) An invalid structure was generated in this location, inside Key_Feature_Fill_Grid. Please check source code. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-207
				//cmd_button_array().Visible = False
				//UPGRADE_ISSUE: (207) An invalid structure was generated in this location, inside Key_Feature_Fill_Grid. Please check source code. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-207
				//cmd_button_array().Visible = False
				//UPGRADE_ISSUE: (207) An invalid structure was generated in this location, inside Key_Feature_Fill_Grid. Please check source code. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-207
				//cmd_button_array().Visible = False

				pnl_MasterKeyFeatures.Visible = false;
				pnl_FeatureDisplay.Visible = false;

				lblFeatureYes.Visible = false;
				lblFeatureNo.Visible = false;
				lblFeatureUnknown.Visible = false;

				// ************************************************
				// SETUP THE FEATURE GRID
				grd_Keyfeature.Clear();
				grd_Keyfeature.ColumnsCount = 9;
				grd_Keyfeature.RowsCount = 1;

				grd_Keyfeature.CurrentRowIndex = 0;
				grd_Keyfeature.CurrentColumnIndex = 0;
				grd_Keyfeature.SetColumnWidth(0, 27);
				grd_Keyfeature.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
				grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].Value = "Seq No";
				grd_Keyfeature.CellBackColor = grd_Keyfeature.BackColorFixed;

				grd_Keyfeature.CurrentColumnIndex = 1;
				grd_Keyfeature.SetColumnWidth(1, 60);
				grd_Keyfeature.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
				grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].Value = "Code";
				grd_Keyfeature.CellBackColor = grd_Keyfeature.BackColorFixed;

				grd_Keyfeature.CurrentColumnIndex = 2;
				grd_Keyfeature.SetColumnWidth(2, 333);
				grd_Keyfeature.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
				grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].Value = "Name";
				grd_Keyfeature.CellBackColor = grd_Keyfeature.BackColorFixed;

				// COLUMN HEADER FOR STANDARD EQUIP
				grd_Keyfeature.CurrentColumnIndex = 3;
				grd_Keyfeature.SetColumnWidth(3, 67);
				grd_Keyfeature.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
				grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].Value = "Standard?";
				grd_Keyfeature.CellBackColor = grd_Keyfeature.BackColorFixed;

				// COLUMN HEADER FOR STANDARD EQUIP START SER NO
				grd_Keyfeature.CurrentColumnIndex = 4;
				grd_Keyfeature.SetColumnWidth(4, 67);
				grd_Keyfeature.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
				grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].Value = "S/NBR Start";
				grd_Keyfeature.CellBackColor = grd_Keyfeature.BackColorFixed;

				// COLUMN HEADER FOR STANDARD EQUIP END SER NO
				grd_Keyfeature.CurrentColumnIndex = 5;
				grd_Keyfeature.SetColumnWidth(5, 67);
				grd_Keyfeature.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
				grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].Value = "S/NBR End";
				grd_Keyfeature.CellBackColor = grd_Keyfeature.BackColorFixed;

				// COLUMN HEADER DESCRIPTION
				grd_Keyfeature.CurrentColumnIndex = 6;
				grd_Keyfeature.SetColumnWidth(6, 333);
				grd_Keyfeature.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
				grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].Value = "Description";
				grd_Keyfeature.CellBackColor = grd_Keyfeature.BackColorFixed;

				// COLUMN HEADER INACTIVE DATE
				grd_Keyfeature.CurrentColumnIndex = 7;
				grd_Keyfeature.SetColumnWidth(7, 100);
				grd_Keyfeature.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
				grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].Value = "Inactive";
				grd_Keyfeature.CellBackColor = grd_Keyfeature.BackColorFixed;

				// COLUMN HEADER EDIT STATUS
				grd_Keyfeature.CurrentColumnIndex = 8;
				grd_Keyfeature.SetColumnWidth(8, 100);
				grd_Keyfeature.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
				grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].Value = "Edit Status";
				grd_Keyfeature.CellBackColor = grd_Keyfeature.BackColorFixed;

				Query = "SELECT * FROM Aircraft_Model_Key_Feature WITH (NOLOCK) ";
				Query = $"{Query}INNER JOIN Key_Feature WITH (NOLOCK) ON kfeat_code = amfeat_feature_code ";
				Query = $"{Query}WHERE (amfeat_amod_id = {Convert.ToString(snp_Model["amod_id"])}) ";
				Query = $"{Query}ORDER BY amfeat_seq_no ";

				ado_KeyFeature.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
				if (!(ado_KeyFeature.BOF && ado_KeyFeature.EOF))
				{
					ado_KeyFeature.MoveFirst();

					while(!ado_KeyFeature.EOF)
					{

						grd_Keyfeature.RowsCount++;
						grd_Keyfeature.CurrentRowIndex++;

						// ENTER THE SEQUENCE NUMBER TO THE GRID
						grd_Keyfeature.CurrentColumnIndex = 0;
						grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].Value = grd_Keyfeature.CurrentRowIndex;
						if (Convert.ToDouble(ado_KeyFeature["amfeat_seq_no"]) != grd_Keyfeature.CurrentRowIndex && Convert.ToDouble(ado_KeyFeature["amfeat_seq_no"]) != 99)
						{
							grd_Keyfeature.CurrentColumnIndex = 8;
							grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].Value = "UPDATE";
							//UPGRADE_ISSUE: (207) An invalid structure was generated in this location, inside Key_Feature_Fill_Grid. Please check source code. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-207
							//cmd_button_array().Visible = True
						}
						// ENTER THE FEATURE CODE TO THE GRID
						grd_Keyfeature.CurrentColumnIndex = 1;
						grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].Value = $" {($"{Convert.ToString(ado_KeyFeature["amfeat_feature_code"])} ").Trim()}";
						if (($"{Convert.ToString(ado_KeyFeature["amfeat_inactive_date"])}").Trim() != "")
						{
							grd_Keyfeature.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.ConfirmColor)));
						}

						// ENTER THE FEATURE NAME TO THE GRID
						grd_Keyfeature.CurrentColumnIndex = 2;
						grd_Keyfeature.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].Value = Convert.ToString(ado_KeyFeature["kfeat_name"]).Trim();
						if (($"{Convert.ToString(ado_KeyFeature["amfeat_inactive_date"])}").Trim() != "")
						{
							grd_Keyfeature.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.ConfirmColor)));
						}

						// ENTER THE STANDARD EQUIPMENT FLAG TO THE GRID
						grd_Keyfeature.CurrentColumnIndex = 3;
						grd_Keyfeature.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].Value = Convert.ToString(ado_KeyFeature["amfeat_standard_equip"]).Trim();

						// ENTER THE EQUIPMENT START SER NO TO THE GRID
						grd_Keyfeature.CurrentColumnIndex = 4;
						grd_Keyfeature.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].Value = ($"{Convert.ToString(ado_KeyFeature["amfeat_stdeq_start_ser_no_value"])}").Trim();

						// ENTER THE EQUIPMENT END SER NO TO THE GRID
						grd_Keyfeature.CurrentColumnIndex = 5;
						grd_Keyfeature.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].Value = ($"{Convert.ToString(ado_KeyFeature["amfeat_stdeq_end_ser_no_value"])}").Trim();

						// ENTER THE FEATURE DESCRIPTION TO THE GRID
						grd_Keyfeature.CurrentColumnIndex = 6;
						grd_Keyfeature.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].Value = $"{Convert.ToString(ado_KeyFeature["kfeat_description"]).Trim()}({Convert.ToString(ado_KeyFeature["kfeat_research_notes"]).Trim()})";

						// ENTER THE INACTIVE DATE TO THE GRID
						grd_Keyfeature.CurrentColumnIndex = 7;
						grd_Keyfeature.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].Value = ($"{Convert.ToString(ado_KeyFeature["amfeat_inactive_date"])}").Trim();

						ado_KeyFeature.MoveNext();
					};
				}
				else
				{
					// INDICATE NO FEATURES FOR THIS MODEL
					grd_Keyfeature.RowsCount++;
					grd_Keyfeature.CurrentRowIndex++;
					grd_Keyfeature.CurrentColumnIndex = 2;
					grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].Value = "None Found";

				}


				this.Cursor = CursorHelper.CursorDefault;
				// CLOSE RECORSET
				if (ado_KeyFeature != null)
				{
					if (ado_KeyFeature.State == ConnectionState.Open)
					{ // Already Open Close It
						ado_KeyFeature.Close();
					}
					ado_KeyFeature = null;
				}
			}
			catch
			{

				// CLOSE RECORSET
				if (ado_KeyFeature != null)
				{
					if (ado_KeyFeature.State == ConnectionState.Open)
					{ // Already Open Close It
						ado_KeyFeature.Close();
					}
					ado_KeyFeature = null;
				}
				this.Cursor = CursorHelper.CursorDefault;
				modAdminCommon.Report_Error("Key_Feature_Fill_Grid_Error: ");
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
				return;
			}

		}


		private void Key_Feature_Move_Row(string inDirection)
		{


			string[] CurrentRow = ArraysHelper.InitializeArray<string>(11);
			string[] MoveToRow = ArraysHelper.InitializeArray<string>(11);


			int CurrentRow_Number = grd_Keyfeature.CurrentRowIndex;

			string MoveToRow_Color = "";
			grd_Keyfeature.CurrentColumnIndex = 8;
			if (grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString().Trim() == "ADD")
			{
				MoveToRow_Color = modAdminCommon.ForSaleColor;
			}
			if (grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString().Trim() == "DELETE")
			{
				MoveToRow_Color = (0x80000003).ToString();
			}
			if (grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString().Trim() == "")
			{
				grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].Value = "UPDATE";
			}
			grd_Keyfeature.CurrentColumnIndex = 7;
			if (grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString().Trim() != "")
			{
				MoveToRow_Color = modAdminCommon.ConfirmColor;
			}

			if (MoveToRow_Color == "")
			{
				MoveToRow_Color = ColorTranslator.ToOle(Color.White).ToString();
			}

			// SAVE THE VALUES OF THE CURRENT ROW
			for (int i = 2; i <= 9; i++)
			{
				grd_Keyfeature.CurrentColumnIndex = i - 1;
				CurrentRow[i] = grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString();
			}

			if (inDirection == "Up")
			{
				// MOVE THE GRID ROW UP
				grd_Keyfeature.CurrentRowIndex--;
			}
			else
			{
				// MUST BE MOVING THE GRID ROW DOWN
				grd_Keyfeature.CurrentRowIndex++;
			}
			int MoveToRow_Number = grd_Keyfeature.CurrentRowIndex;

			// ASSIGN THE COLOR FROM THE MOVETOROW TO THE CURRENT ROW
			string CurrentRow_Color = "";
			grd_Keyfeature.CurrentColumnIndex = 8;
			if (grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString().Trim() == "ADD")
			{
				CurrentRow_Color = modAdminCommon.ForSaleColor;
			}
			if (grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString().Trim() == "DELETE")
			{
				CurrentRow_Color = (0x80000003).ToString();
			}
			if (grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString().Trim() == "")
			{
				grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].Value = "UPDATE";
			}
			grd_Keyfeature.CurrentColumnIndex = 7;
			if (grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString().Trim() != "")
			{
				CurrentRow_Color = modAdminCommon.ConfirmColor;
			}

			if (CurrentRow_Color == "")
			{
				CurrentRow_Color = ColorTranslator.ToOle(Color.White).ToString();
			}

			// SAVE THE VALUES ROW THE CURRENT ROW IS BEING MOVED TO
			for (int i = 2; i <= 9; i++)
			{
				grd_Keyfeature.CurrentColumnIndex = i - 1;
				MoveToRow[i] = grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString();
			}


			// COPY THE VALUES FROM THE CURRENT ROW INTO THE MOVE TO ROW
			for (int i = 2; i <= 9; i++)
			{
				grd_Keyfeature.CurrentColumnIndex = i - 1;
				grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].Value = CurrentRow[i];
				grd_Keyfeature.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			}

			// COPY THE VALUES FROM THE MOVE TO ROW TO THE CURRENT ROW
			grd_Keyfeature.CurrentRowIndex = CurrentRow_Number;
			for (int i = 2; i <= 9; i++)
			{
				grd_Keyfeature.CurrentColumnIndex = i - 1;
				grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].Value = MoveToRow[i];
				grd_Keyfeature.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			}

			// HANDLE GRID COLORING
			// CURRENT ROW
			for (int i = 1; i <= 9; i++)
			{
				grd_Keyfeature.CurrentRowIndex = CurrentRow_Number;
				grd_Keyfeature.CurrentColumnIndex = i - 1;
				grd_Keyfeature.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(CurrentRow_Color)));

				grd_Keyfeature.CurrentRowIndex = MoveToRow_Number;
				grd_Keyfeature.CurrentColumnIndex = i - 1;
				grd_Keyfeature.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(MoveToRow_Color)));
			}

			grd_Keyfeature.CurrentRowIndex = MoveToRow_Number;
			//UPGRADE_ISSUE: (207) An invalid structure was generated in this location, inside Key_Feature_Move_Row. Please check source code. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-207
			//cmd_button_array().Visible = True
			//grd_Keyfeature.RowSel = MoveToRow_Number
			grd_Keyfeature_Click(grd_Keyfeature, new EventArgs());

		}


		private bool Key_Feature_Delete(string inDelete_Type)
		{
			bool result = false;
			string Target_Feature_Code = "";
			try
			{

				string Query = "";
				ADORecordSetHelper snp_Important_Feature = new ADORecordSetHelper(); //8/11/05 aey
				double tcount = 0;
				DialogResult intPress = (DialogResult) 0;
				int Target_Seq_No = 0;
				string M = "";

				result = false;

				// GET THE KEY FEATURE CODE AND SEQUENCE NUMBER FROM THE GRID

				if (grd_Keyfeature.CurrentRowIndex >= 0)
				{
					UserMessage("Checking on Aircraft for Feature Delete");
					grd_Keyfeature.CurrentColumnIndex = 1;
					Target_Feature_Code = grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString().Trim();
					grd_Keyfeature.CurrentColumnIndex = 0;
					Target_Seq_No = Convert.ToInt32(Double.Parse(grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString().Trim()));

					Query = "SELECT afeat_ac_id AS AC_ID ";
					Query = $"{Query}FROM Aircraft_Key_Feature WITH (NOLOCK) ";
					Query = $"{Query}INNER JOIN Aircraft WITH (NOLOCK) ON ac_id = afeat_ac_id AND ac_journ_id = afeat_journ_id ";
					Query = $"{Query}WHERE (afeat_journ_id = 0) ";
					Query = $"{Query}AND (afeat_feature_code = '{Target_Feature_Code}') ";
					Query = $"{Query}AND (ac_amod_Id = {Convert.ToString(snp_Model["amod_id"])}) ";
					Query = $"{Query}ORDER BY afeat_ac_id ";

					snp_Important_Feature.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					tcount = 0;
					if (!(snp_Important_Feature.BOF && snp_Important_Feature.EOF))
					{
						do 
						{
							tcount++;
							snp_Important_Feature.MoveNext();
						}
						while(!snp_Important_Feature.EOF);
					}
					UserMessage("Off");

					if (inDelete_Type == "DELETE")
					{
						M = $"The Delete of the Feature Code {Target_Feature_Code} will impact {tcount.ToString()} Aircraft Records. Confirm Delete!";
					}
					else
					{
						M = $"The Inactivating of the Feature Code {Target_Feature_Code} will impact {tcount.ToString()} Aircraft Records. Confirm Inactivate!";
					}

					intPress = MessageBox.Show(M, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo);

					if (intPress == System.Windows.Forms.DialogResult.Yes)
					{

						modAdminCommon.ADO_Transaction("BeginTrans");
						grd_Keyfeature.CurrentColumnIndex = 1;
						if (!(snp_Important_Feature.BOF && snp_Important_Feature.EOF))
						{
							snp_Important_Feature.MoveFirst();

							while(!snp_Important_Feature.EOF)
							{

								// DELETE THE FEATURE CODE FROM ALL AIRCRAFT
								UserMessage($"Deleting Feature {Target_Feature_Code} from Aircraft ID {Convert.ToString(snp_Important_Feature["ac_id"])}");
								Query = $"DELETE FROM Aircraft_Key_Feature WHERE afeat_ac_id = {Convert.ToString(snp_Important_Feature["ac_id"])}";
								Query = $"{Query} AND afeat_journ_id = 0";
								Query = $"{Query} and afeat_feature_code = '{Target_Feature_Code}'";
								DbCommand TempCommand = null;
								TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
								UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
								TempCommand.CommandText = Query;
								//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
								//UPGRADE_WARNING: (6021) Casting 'ADODB.ExecuteOptionEnum' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
								TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
								UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
								TempCommand.ExecuteNonQuery();

								// RECORD AN ENTRY IN THE DELETE LOG
								// SO THAT EVOLUTION WILL DELETE THE KEY FEATURE
								modAdminCommon.Record_Delete_Log_Entry("Key_Feature", Convert.ToInt32(snp_Important_Feature["ac_id"]), 0, 0, 0, Target_Feature_Code);
								snp_Important_Feature.MoveNext();
							};
						}

						if (inDelete_Type == "DELETE")
						{
							// DELETE THE FEATURE CODE FROM THE AIRCRAFT MODEL KEY FEATURE TABLE
							Query = $"DELETE FROM Aircraft_Model_Key_Feature WHERE amfeat_amod_id = {Convert.ToString(snp_Model["amod_id"])}";
							Query = $"{Query} AND amfeat_feature_code = '{grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString().Trim()}'";
							DbCommand TempCommand_2 = null;
							TempCommand_2 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
							TempCommand_2.CommandText = Query;
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'ADODB.ExecuteOptionEnum' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
							TempCommand_2.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
							TempCommand_2.ExecuteNonQuery();
						}
						else
						{
							// IF INACTIVE, THEN DON'T DELETE FROM THE MODEL LEVEL TABLE
							// BUT UPDATE IT
							grd_Keyfeature.CurrentColumnIndex = 7;
							Query = $"UPDATE Aircraft_Model_Key_Feature set amfeat_inactive_date = '{grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString().Trim()}' WHERE amfeat_amod_id = {Convert.ToString(snp_Model["amod_id"])}";
							grd_Keyfeature.CurrentColumnIndex = 1;
							Query = $"{Query} AND amfeat_feature_code = '{grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString().Trim()}'";
							DbCommand TempCommand_3 = null;
							TempCommand_3 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_3);
							TempCommand_3.CommandText = Query;
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'ADODB.ExecuteOptionEnum' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
							TempCommand_3.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_3);
							TempCommand_3.ExecuteNonQuery();
						}
						modAdminCommon.ADO_Transaction("CommitTrans");
						UserMessage("Off");
						result = true;
					}
					else
					{
						// USER DECIDED TO QUIT
						result = false;
					}
				}
				else
				{
					// ROW WAS NOT A DATA ROW SO ABORT
					result = false;
				}

				snp_Important_Feature = null;
			}
			catch (System.Exception excep)
			{

				result = false;
				modAdminCommon.Report_Error($"Key_Feature_Delete_Error: {excep.Message} {Target_Feature_Code} {inDelete_Type}");
			}

			return result;
		}


		public void Key_Feature_Update_Active_Status()
		{
			try
			{

				if (!KeyFeatureWasActive && chk_Inactive_Feature_Code.CheckState == CheckState.Unchecked)
				{
					grd_Keyfeature.CurrentColumnIndex = 7;
					grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].Value = "";
					KeyFeatureWasActive = true;
					grd_Keyfeature.CurrentColumnIndex = 8;
					grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].Value = "UPDATE";
				}
			}
			catch (System.Exception excep)
			{

				MessageBox.Show($"Update_Key_Feature_Active_Status_Error:{excep.Message}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

		}

		private void Key_Feature_Save_Grid()
		{
			ADORecordSetHelper LockCheck = new ADORecordSetHelper();
			bool ProcessedChange = true; // USE THIS TO IDENTIFY IF UPDATES WERE PROCESSED FROM THE GRID

			// ***********************************************************
			// MAKE SURE THAT NONE OF THE AIRCRAFT ABOUT TO BE UPDATED
			// ARE LOCKED. IF THEY ARE LOCKED, THEN ABORT THE UPDATE.
			UserMessage("Checking for Locked Aircraft ...");
			string Query = "SELECT count(*) as KeyCount FROM Aircraft_Lock WITH(NOLOCK),Aircraft ";
			Query = $"{Query}WHERE ac_journ_id = 0 ";
			Query = $"{Query}and ac_id = alock_ac_id and ac_journ_id = alock_journ_id ";
			Query = $"{Query}and ac_amod_id = {Convert.ToString(snp_Model["amod_id"])} ";
			LockCheck.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
			if (!(LockCheck.BOF && LockCheck.EOF))
			{
				UserMessage("Off");
				if (Convert.ToDouble(LockCheck["KeyCount"]) > 0 && modAdminCommon.gbl_User_ID != "mvit")
				{
					MessageBox.Show($"There are currently {Convert.ToString(LockCheck["KeyCount"])} Aircraft relating to this Model that are locked by a user.  Therefore Homebase is currently unable to process grid changes.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					return;
				}
			}
			else
			{
				UserMessage("Off");
			}


			// CLOSE RECORSET
			if (LockCheck != null)
			{
				if (LockCheck.State == ConnectionState.Open)
				{ // Already Open Close It
					LockCheck.Close();
				}
				LockCheck = null;
			}

			// RUN THROUGH THE GRID AND PROCESS CHANGES
			// IDENTIFIED IN THE LAST COLUMN AS ADD, UPDATE, OR DELETE
			int tempForEndVar = grd_Keyfeature.RowsCount - 1;
			for (int i = 1; i <= tempForEndVar; i++)
			{
				grd_Keyfeature.CurrentRowIndex = i;
				grd_Keyfeature.CurrentColumnIndex = 8;
				if (grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString().Trim() == "ADD")
				{
					// CALL FUNCTION TO INSERT THE KEY FEATURE FOR
					// MODEL AND ALL RELATED AIRCRAFT
					if (Key_Feature_Insert())
					{
						grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].Value = "";
					}
					else
					{
						ProcessedChange = false;
					}
				}
				if (grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString().Trim() == "UPDATE")
				{
					// CALL FUNCTION TO UPDATE THE FEATURE FOR THE
					// MODEL AND ALL RELATED AIRCRAFT
					if (Key_Feature_Update())
					{
						grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].Value = "";
					}
					else
					{
						ProcessedChange = false;
					}
				}
				if (grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString().Trim() == "DELETE")
				{
					if (Key_Feature_Delete("DELETE"))
					{
						grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].Value = "";
					}
					else
					{
						ProcessedChange = false;
					}
				}
				if (grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString().Trim() == "INACTIVE")
				{
					if (Key_Feature_Delete("INACTIVE"))
					{
						grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].Value = "";
					}
					else
					{
						ProcessedChange = false;
					}
				}
			}

			if (ProcessedChange)
			{
				modAdminCommon.Table_Action_Log("Aircraft_Model_Key_Feature");
				Key_Feature_Fill_Grid();
				//UPGRADE_ISSUE: (207) An invalid structure was generated in this location, inside Key_Feature_Save_Grid. Please check source code. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-207
				//cmd_button_array().Visible = False
			}
		}

		private void Key_Feature_Remove_Grid_Row()
		{
			grd_Keyfeature.CurrentColumnIndex = 8;
			grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].Value = "DELETE";

			// CHANGE THE COLOR OF THE ROWS TO INDICATE DELETED
			for (int i = 1; i <= 9; i++)
			{
				grd_Keyfeature.CurrentColumnIndex = i - 1;
				grd_Keyfeature.CellBackColor = SystemColors.InactiveCaption;
			}
			//UPGRADE_ISSUE: (207) An invalid structure was generated in this location, inside Key_Feature_Remove_Grid_Row. Please check source code. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-207
			//cmd_button_array().Visible = True

			// INFORM THE USER THAT THE FEATURE CODE BEING REMOVED IS
			// IN AN AREA THAT WILL IMPACT JETNET FOR WINDOWS
			// I.E. (SEQUENCE NUMBERS 1-6)
			if (grd_Keyfeature.CurrentRowIndex <= 6)
			{
				MessageBox.Show("Please note that removal of this feature code will directly impact JETNET for windows since it is in position 1-6. It is recommended that you move this feature code down in the list before saving changes.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
		}



		private void Key_Feature_Add_Grid_Row()
		{
			if (ListBoxHelper.GetSelectedIndex(lst_MasterKeyFeature) > -1)
			{
				if (!modAdminCommon.Exist($"select * from Aircraft_Model_Key_Feature WITH(NOLOCK) where amfeat_feature_code = '{Convert.ToString(snp_MasterFeature["kfeat_code"])}' and amfeat_amod_id =   {Convert.ToString(snp_Model["amod_id"])}"))
				{

					// ADD AN ENTRY TO THE END OF THE GRID FOR THE NEW FEATURE CODE
					// MAKE IT A SEQUENCE OF 99
					// PLACE A MARKER IN THE FINAL COLUMN INDICATING THAT IT IS NEW
					grd_Keyfeature.RowsCount++;
					grd_Keyfeature.CurrentRowIndex = grd_Keyfeature.RowsCount - 1;

					grd_Keyfeature.CurrentColumnIndex = 0;
					grd_Keyfeature.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
					grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].Value = grd_Keyfeature.CurrentRowIndex;

					grd_Keyfeature.CurrentColumnIndex = 1;
					grd_Keyfeature.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
					grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].Value = snp_MasterFeature.GetField("kfeat_code");

					grd_Keyfeature.CurrentColumnIndex = 2;
					grd_Keyfeature.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
					grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].Value = snp_MasterFeature.GetField("kfeat_name");

					grd_Keyfeature.CurrentColumnIndex = 3;
					grd_Keyfeature.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
					grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].Value = "N";

					grd_Keyfeature.CurrentColumnIndex = 4;
					grd_Keyfeature.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
					grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].Value = "0";

					grd_Keyfeature.CurrentColumnIndex = 5;
					grd_Keyfeature.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
					grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].Value = "0";

					grd_Keyfeature.CurrentColumnIndex = 8;
					grd_Keyfeature.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
					grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].Value = "ADD";

					// COLOR THE ROW GREEN FOR ADDED
					for (int i = 1; i <= 9; i++)
					{
						grd_Keyfeature.CurrentColumnIndex = i - 1;
						grd_Keyfeature.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.ForSaleColor)));
					}

					//UPGRADE_ISSUE: (207) An invalid structure was generated in this location, inside Key_Feature_Add_Grid_Row. Please check source code. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-207
					//cmd_button_array().Visible = True
				}
				else
				{
					MessageBox.Show("already in list", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}
			}
			else
			{
				MessageBox.Show("Please select Key Feature from list!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}
		}

		private bool Key_Feature_Update()
		{
			//
			// PURPOSE: THE PURPOSE OF THIS PROCEDURE IS TO TAKE UPDATED
			// ROWS FROM THE AIRCRAFT MODEL KEY FEATURE GRID AND APPLY THEM
			// TO ALL RELATED AIRCRAFT AS WELL AS THE MODEL KEY FEATURE TABLE.
			bool result = false;
			ADORecordSetHelper ado_FeatureCheck = default(ADORecordSetHelper);
			ADORecordSetHelper ado_model_feature = default(ADORecordSetHelper);
			string strError = "";
			try
			{
				this.Cursor = Cursors.WaitCursor;
				string RuleStatus = ""; // USED TO IDENTIFY THE RESULTS OF TRYING TO APPLY RULES
				int StartSerNo = 0;
				int EndSerNo = 0;
				bool StandardEquipment = false;
				string RuleString = "";
				ado_FeatureCheck = new ADORecordSetHelper();
				string Query = "";
				ado_model_feature = new ADORecordSetHelper(); //7/15/04 aey

				result = false;

				// CHECK TO SEE IF THE CURRENT KEY FEATURE EXISTS ON THE AIRCRAFT
				// IF NOT, THEN ADD IT
				// IF THE KEY FEATURE EXISTS, THEN DETERMINE WHAT CHANGES HAVE BEEN
				// MADE:
				//    1. A SEQUENCE NUMBER CHANGE
				//    2. IT NOW MAY BE INACTIVE
				//    3. MAY JUST HAVE HAD CHANGES TO THE MODEL KEY FEATURE TABLE
				strError = "start trans";
				modAdminCommon.ADO_Transaction("BeginTrans");
				grd_Keyfeature.CurrentColumnIndex = 1;
				Query = $"Select * from Aircraft_Model_Key_Feature where amfeat_feature_code='{grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString().Trim()}' ";
				Query = $"{Query}and amfeat_amod_id = {Convert.ToString(snp_Model["amod_id"])}";
				ado_model_feature.Open(Query, modAdminCommon.ADODB_Trans_conn, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);
				if (!(ado_model_feature.BOF && ado_model_feature.EOF))
				{
					strError = "model feature";
					ado_model_feature.MoveFirst();
					grd_Keyfeature.CurrentColumnIndex = 1;
					UserMessage($"Updating Aircraft Model Feature Record {grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString().Trim()}");
					ado_model_feature["amfeat_seq_no"] = grd_Keyfeature.CurrentRowIndex;
					grd_Keyfeature.CurrentColumnIndex = 3;
					ado_model_feature["amfeat_standard_equip"] = grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString().Trim();
					grd_Keyfeature.CurrentColumnIndex = 4;
					if (grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString().Trim() != "")
					{
						ado_model_feature["amfeat_stdeq_start_ser_no_value"] = Convert.ToInt32(Double.Parse(grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString().Trim()));
					}
					grd_Keyfeature.CurrentColumnIndex = 5;
					if (grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString().Trim() != "")
					{
						ado_model_feature["amfeat_stdeq_end_ser_no_value"] = Convert.ToInt32(Double.Parse(grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString().Trim()));
					}
					grd_Keyfeature.CurrentColumnIndex = 7;
					if (grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString().Trim() != "")
					{
						ado_model_feature["amfeat_inactive_date"] = DateTime.Parse(grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString().Trim());
					}
					else if (KeyFeatureWasActive && grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString().Trim() == "")
					{ 
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						ado_model_feature["amfeat_inactive_date"] = DBNull.Value;
					}
					ado_model_feature.Update();
				} // ADD NEW AIRCRAFT MODEL FEATURE CODE






				modAdminCommon.ADO_Transaction("CommitTrans");
				UserMessage("Off");


				grd_Keyfeature.CurrentColumnIndex = 1;
				if (Key_Feature_Add_Update_Stored_Procedure(Convert.ToInt32(snp_Model["amod_id"]), grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString()))
				{


				}


				if (ado_model_feature != null)
				{
					if (ado_model_feature.State == ConnectionState.Open)
					{ // Already Open Close It
						ado_model_feature.Close();
					}
					ado_model_feature = null;
				}
				this.Cursor = CursorHelper.CursorDefault;
				return true;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				strError = $"{Information.Err().Number.ToString()} {excep.Message} {strError}";
				result = false;
				modAdminCommon.ADO_Transaction("RollbackTrans");
				// CLOSE RECORSET
				if (ado_FeatureCheck != null)
				{
					if (ado_FeatureCheck.State == ConnectionState.Open)
					{ // Already Open Close It
						ado_FeatureCheck.Close();
					}
					ado_FeatureCheck = null;
				}
				if (ado_model_feature != null)
				{
					if (ado_model_feature.State == ConnectionState.Open)
					{ // Already Open Close It
						ado_model_feature.Close();
					}
					ado_model_feature = null;
				}
				modAdminCommon.Report_Error($"Key_Feature_Update_Error: {strError}");
			}
			return result;
		}

		private void UserMessage(string inMessage)
		{
			frame_Status.Visible = inMessage != "Off";
			lbl_Status.Text = inMessage;
			Application.DoEvents();
		}


		private void Display_Key_Feature_Counts()
		{

			this.Cursor = Cursors.WaitCursor;
			Application.DoEvents();

			grd_Keyfeature.CurrentColumnIndex = 1;
			lblFeatureYes.Text = $"Yes: {modAdminCommon.CountACFeatures(Convert.ToInt32(Double.Parse(($"{Convert.ToString(snp_Model["amod_id"])}").Trim())), ($"{grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString()}").Trim(), "Y").ToString()}";
			lblFeatureYes.Visible = true;

			lblFeatureNo.Text = $"No: {modAdminCommon.CountACFeatures(Convert.ToInt32(Double.Parse(($"{Convert.ToString(snp_Model["amod_id"])}").Trim())), ($"{grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString()}").Trim(), "N").ToString()}";
			lblFeatureNo.Visible = true;

			UserMessage($"Counting Aircraft Information for Feature '{grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString().Trim()}' ....");
			int lngResult = modAdminCommon.Key_Feature_Auto_Count(($"{grd_Keyfeature[grd_Keyfeature.CurrentRowIndex, grd_Keyfeature.CurrentColumnIndex].FormattedValue.ToString()}").Trim(), Convert.ToInt32(Double.Parse(($"{Convert.ToString(snp_Model["amod_id"])}").Trim())));
			UserMessage("Off");
			if (lngResult == -1)
			{
				lblFeatureUnknown.Text = "Data: N/A";
			}
			else
			{
				lblFeatureUnknown.Text = $"Data: {lngResult.ToString()}";
			}
			lblFeatureUnknown.Visible = true;
			this.Cursor = CursorHelper.CursorDefault;
		}

		private void Fill_Make_Model_Sort_Grid()
		{
			ADORecordSetHelper ado_MakeSort = default(ADORecordSetHelper);
			try
			{
				string Query = "";
				ado_MakeSort = new ADORecordSetHelper();

				// MAKE THE MOVE UP AND DOWN BUTTONS INVISIBLE
				cmd_Make_Move1[0].Visible = false;
				cmd_Make_Move1[1].Visible = false;

				grd_MakeSort.Visible = false;
				grd_MakeSort.Enabled = false;

				// ************************************************
				// SETUP THE FEATURE GRID
				grd_MakeSort.Clear();
				grd_MakeSort.ColumnsCount = 4;
				grd_MakeSort.RowsCount = 1;

				grd_MakeSort.CurrentRowIndex = 0;
				grd_MakeSort.CurrentColumnIndex = 0;
				grd_MakeSort.SetColumnWidth(0, 27);
				grd_MakeSort.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
				grd_MakeSort[grd_MakeSort.CurrentRowIndex, grd_MakeSort.CurrentColumnIndex].Value = "Seq No";
				grd_MakeSort.CellBackColor = grd_MakeSort.BackColorFixed;

				grd_MakeSort.CurrentColumnIndex = 1;
				grd_MakeSort.SetColumnWidth(1, 160);
				grd_MakeSort.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
				grd_MakeSort[grd_MakeSort.CurrentRowIndex, grd_MakeSort.CurrentColumnIndex].Value = "Model";
				grd_MakeSort.CellBackColor = grd_MakeSort.BackColorFixed;

				grd_MakeSort.CurrentColumnIndex = 2;
				grd_MakeSort.SetColumnWidth(2, 60);
				grd_MakeSort.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
				grd_MakeSort[grd_MakeSort.CurrentRowIndex, grd_MakeSort.CurrentColumnIndex].Value = "Status";
				grd_MakeSort.CellBackColor = grd_MakeSort.BackColorFixed;

				grd_MakeSort.CurrentColumnIndex = 3;
				grd_MakeSort.SetColumnWidth(3, 50);
				grd_MakeSort.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
				grd_MakeSort[grd_MakeSort.CurrentRowIndex, grd_MakeSort.CurrentColumnIndex].Value = "ID";
				grd_MakeSort.CellBackColor = grd_MakeSort.BackColorFixed;

				Query = "SELECT amod_model_name, amod_id,amod_model_sub_sort_no FROM Aircraft_Model";
				Query = $"{Query} where amod_make_name='{cbo_MakeSelect.Text}' ";
				Query = $"{Query}ORDER BY amod_model_sub_sort_no ";
				ado_MakeSort.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
				if (!(ado_MakeSort.BOF && ado_MakeSort.EOF))
				{

					while(!ado_MakeSort.EOF)
					{

						grd_MakeSort.RowsCount++;
						grd_MakeSort.CurrentRowIndex++;

						// ENTER THE SEQUENCE NUMBER TO THE GRID
						grd_MakeSort.CurrentColumnIndex = 0;
						grd_MakeSort[grd_MakeSort.CurrentRowIndex, grd_MakeSort.CurrentColumnIndex].Value = grd_MakeSort.CurrentRowIndex;
						if (Convert.ToDouble(ado_MakeSort["amod_model_sub_sort_no"]) != grd_MakeSort.CurrentRowIndex)
						{
							grd_MakeSort.CurrentColumnIndex = 2;
							grd_MakeSort[grd_MakeSort.CurrentRowIndex, grd_MakeSort.CurrentColumnIndex].Value = "UPDATE";
						}

						// ENTER THE FEATURE CODE TO THE GRID
						grd_MakeSort.CurrentColumnIndex = 1;
						grd_MakeSort[grd_MakeSort.CurrentRowIndex, grd_MakeSort.CurrentColumnIndex].Value = $" {($"{Convert.ToString(ado_MakeSort["amod_model_name"])} ").Trim()}";


						grd_MakeSort.CurrentColumnIndex = 3;
						grd_MakeSort[grd_MakeSort.CurrentRowIndex, grd_MakeSort.CurrentColumnIndex].Value = $" {($"{Convert.ToString(ado_MakeSort["amod_id"])} ").Trim()}";

						ado_MakeSort.MoveNext();
						Application.DoEvents();
					};
				}
				else
				{
					// INDICATE NO FEATURES FOR THIS MODEL
					grd_MakeSort.RowsCount++;
					grd_MakeSort.CurrentRowIndex++;
					grd_MakeSort.CurrentColumnIndex = 2;
					grd_MakeSort[grd_MakeSort.CurrentRowIndex, grd_MakeSort.CurrentColumnIndex].Value = "None Found";

				}


				this.Cursor = CursorHelper.CursorDefault;
				// CLOSE RECORSET
				if (ado_MakeSort != null)
				{
					if (ado_MakeSort.State == ConnectionState.Open)
					{ // Already Open Close It
						ado_MakeSort.Close();
					}
					ado_MakeSort = null;
				}

				grd_MakeSort.Visible = true;
				grd_MakeSort.Redraw = true;
				grd_MakeSort.Enabled = true;
			}
			catch
			{

				// CLOSE RECORSET
				if (ado_MakeSort != null)
				{
					if (ado_MakeSort.State == ConnectionState.Open)
					{ // Already Open Close It
						ado_MakeSort.Close();
					}
					ado_MakeSort = null;
				}
				this.Cursor = CursorHelper.CursorDefault;
				modAdminCommon.Report_Error("Fill_Make_Model_Sort_Grid_Error: ");
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
				return;
			}

		}

		private void Fill_Make_Sort_List()
		{
			//******************************************************************************************
			try
			{
				string Query = "";
				ADORecordSetHelper ado_MakeList = new ADORecordSetHelper();
				this.Cursor = Cursors.WaitCursor;
				cbo_MakeSelect.Items.Clear();

				Query = "SELECT distinct amod_make_name FROM Aircraft_Model WITH(NOLOCK) ";
				Query = $"{Query}ORDER BY amod_make_name";
				ado_MakeList.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);
				if (!(ado_MakeList.BOF && ado_MakeList.EOF))
				{
					ado_MakeList.MoveFirst();

					while(!ado_MakeList.EOF)
					{
						cbo_MakeSelect.AddItem(Convert.ToString(ado_MakeList["amod_make_name"]).Trim());
						ado_MakeList.MoveNext();
					};
					cbo_MakeSelect.SelectedIndex = 0;
				}
				this.Cursor = CursorHelper.CursorDefault;

				// CLOSE RECORSET
				if (ado_MakeList != null)
				{
					if (ado_MakeList.State == ConnectionState.Open)
					{ // Already Open Close It
						ado_MakeList.Close();
					}
					ado_MakeList = null;
				}
				cbo_MakeSelect.Refresh();
			}
			catch (System.Exception excep)
			{
				this.Cursor = CursorHelper.CursorDefault;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_Make_Sort_List_Error: {Information.Err().Number.ToString()} {excep.Message}");
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
			}
		}

		public object Make_Sort_Move_Row(string inDirection)
		{
			//


			string[] CurrentRow = ArraysHelper.InitializeArray<string>(11);
			string[] MoveToRow = ArraysHelper.InitializeArray<string>(11);


			int CurrentRow_Number = grd_MakeSort.CurrentRowIndex;
			if (CurrentRow_Number == 0)
			{
				return null;
			}
			string MoveToRow_Color = "";
			grd_MakeSort.CurrentColumnIndex = 2;

			if (grd_MakeSort[grd_MakeSort.CurrentRowIndex, grd_MakeSort.CurrentColumnIndex].FormattedValue.ToString().Trim() == "")
			{
				grd_MakeSort[grd_MakeSort.CurrentRowIndex, grd_MakeSort.CurrentColumnIndex].Value = "UPDATE";
			}

			if (MoveToRow_Color == "")
			{
				MoveToRow_Color = ColorTranslator.ToOle(Color.White).ToString();
			}



			// SAVE THE VALUES OF THE CURRENT ROW
			for (int i = 2; i <= 4; i++)
			{
				grd_MakeSort.CurrentColumnIndex = i - 1;
				CurrentRow[i] = grd_MakeSort[grd_MakeSort.CurrentRowIndex, grd_MakeSort.CurrentColumnIndex].FormattedValue.ToString();
			}

			if (inDirection == "Up")
			{
				// MOVE THE GRID ROW UP
				grd_MakeSort.CurrentRowIndex--;
			}
			else
			{
				// MUST BE MOVING THE GRID ROW DOWN
				grd_MakeSort.CurrentRowIndex++;
			}
			int MoveToRow_Number = grd_MakeSort.CurrentRowIndex;

			// ASSIGN THE COLOR FROM THE MOVETOROW TO THE CURRENT ROW
			string CurrentRow_Color = "";
			grd_MakeSort.CurrentColumnIndex = 2;

			if (grd_MakeSort[grd_MakeSort.CurrentRowIndex, grd_MakeSort.CurrentColumnIndex].FormattedValue.ToString().Trim() == "")
			{
				grd_MakeSort[grd_MakeSort.CurrentRowIndex, grd_MakeSort.CurrentColumnIndex].Value = "UPDATE";
			}


			if (CurrentRow_Color == "")
			{
				CurrentRow_Color = ColorTranslator.ToOle(Color.White).ToString();
			}

			// SAVE THE VALUES ROW THE CURRENT ROW IS BEING MOVED TO
			for (int i = 2; i <= 4; i++)
			{
				grd_MakeSort.CurrentColumnIndex = i - 1;
				MoveToRow[i] = grd_MakeSort[grd_MakeSort.CurrentRowIndex, grd_MakeSort.CurrentColumnIndex].FormattedValue.ToString();
			}


			// COPY THE VALUES FROM THE CURRENT ROW INTO THE MOVE TO ROW
			for (int i = 2; i <= 4; i++)
			{
				grd_MakeSort.CurrentColumnIndex = i - 1;
				grd_MakeSort[grd_MakeSort.CurrentRowIndex, grd_MakeSort.CurrentColumnIndex].Value = CurrentRow[i];
				grd_MakeSort.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			}

			// COPY THE VALUES FROM THE MOVE TO ROW TO THE CURRENT ROW
			grd_MakeSort.CurrentRowIndex = CurrentRow_Number;
			for (int i = 2; i <= 4; i++)
			{
				grd_MakeSort.CurrentColumnIndex = i - 1;
				grd_MakeSort[grd_MakeSort.CurrentRowIndex, grd_MakeSort.CurrentColumnIndex].Value = MoveToRow[i];
				grd_MakeSort.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			}

			// HANDLE GRID COLORING
			// CURRENT ROW
			for (int i = 1; i <= 4; i++)
			{
				grd_MakeSort.CurrentRowIndex = CurrentRow_Number;
				grd_MakeSort.CurrentColumnIndex = i - 1;
				grd_MakeSort.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(CurrentRow_Color)));

				grd_MakeSort.CurrentRowIndex = MoveToRow_Number;
				grd_MakeSort.CurrentColumnIndex = i - 1;
				grd_MakeSort.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(MoveToRow_Color)));
			}

			grd_MakeSort.CurrentRowIndex = MoveToRow_Number;
			//UPGRADE_ISSUE: (207) An invalid structure was generated in this location, inside Make_Sort_Move_Row. Please check source code. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-207
			//cmd_button_array().Visible = True
			//grd_MakeSort.RowSel = MoveToRow_Number
			grd_MakeSort_Click(grd_MakeSort, new EventArgs());

			return null;
		}

		private void Save_MakeSort_Grid()
		{
			StringBuilder Query = new StringBuilder();
			int tempForEndVar = grd_MakeSort.RowsCount - 1;
			for (int i = 1; i <= tempForEndVar; i++)
			{
				grd_MakeSort.CurrentRowIndex = i;
				grd_MakeSort.CurrentColumnIndex = 2;
				if (grd_MakeSort[grd_MakeSort.CurrentRowIndex, grd_MakeSort.CurrentColumnIndex].FormattedValue.ToString().Trim() == "UPDATE")
				{
					// CALL FUNCTION TO UPDATE
					// update the sort number
					grd_MakeSort[grd_MakeSort.CurrentRowIndex, grd_MakeSort.CurrentColumnIndex].Value = "";

					Query = new StringBuilder("UPDATE Aircraft_Model ");
					grd_MakeSort.CurrentColumnIndex = 0;
					Query.Append($"SET amod_model_sub_sort_no = {grd_MakeSort[grd_MakeSort.CurrentRowIndex, grd_MakeSort.CurrentColumnIndex].FormattedValue.ToString()} ");
					grd_MakeSort.CurrentColumnIndex = 3;
					Query.Append($"WHERE amod_id = {grd_MakeSort[grd_MakeSort.CurrentRowIndex, grd_MakeSort.CurrentColumnIndex].FormattedValue.ToString()}");

					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = Query.ToString();
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();
				}
			}

			Fill_Make_Model_Sort_Grid();
		}

		public void Fill_Commercial_Aircraft_Map(string ac_amod_id, string ac_amod_id_com, string make_mod_name, string whichView)
		{
			// -- 1  SELECT LIST OF HOMEBASE AIRCRAFT FOR MAPPED HOMEBASE MODEL
			// Check Live Homebase Connection

			string amod_make_name = "";
			string amod_model_name = "";
			ADORecordSetHelper adoRs = new ADORecordSetHelper();
			ADORecordSetHelper adoRs_Com = new ADORecordSetHelper();
			string Query = "";
			int intMapped = 0;
			int intToLoad = 0;
			int intDuplicates = 0;

			if (whichView == "Homebase")
			{

				Query = "SELECT ac_id, ac_reg_no, ac_ser_no_full, amod_make_name, amod_model_name ";
				Query = $"{Query} FROM aircraft WITH (NOLOCK) INNER JOIN aircraft_model WITH (NOLOCK) ON amod_id = ac_amod_id";
				Query = $"{Query} WHERE ac_amod_id = {ac_amod_id} AND AC_Journ_id = 0";
				adoRs.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				//  ' CLEAR THE LIST OF AIRCRAFT IDS MAPPED FOR THIS MODEL
				Mapped_homebase_ac_list = "";

				grdAircraftMap.Visible = true;
				grdAircraftMap.Enabled = false;

				grdAircraftMap.Clear();
				grdAircraftMap.ColumnsCount = 5;
				grdAircraftMap.RowsCount = 2;

				grdAircraftMap.CurrentRowIndex = 0;
				grdAircraftMap.CurrentColumnIndex = 0;
				grdAircraftMap[grdAircraftMap.CurrentRowIndex, grdAircraftMap.CurrentColumnIndex].Value = "HOM AC ID";
				grdAircraftMap.SetColumnWidth(0, 73);

				grdAircraftMap.CurrentColumnIndex = 1;
				grdAircraftMap[grdAircraftMap.CurrentRowIndex, grdAircraftMap.CurrentColumnIndex].Value = "HOM REG#";
				grdAircraftMap.SetColumnWidth(1, 70);

				grdAircraftMap.CurrentColumnIndex = 2;
				grdAircraftMap[grdAircraftMap.CurrentRowIndex, grdAircraftMap.CurrentColumnIndex].Value = "HOM SER#";
				grdAircraftMap.SetColumnWidth(2, 70);

				grdAircraftMap.CurrentColumnIndex = 3;
				grdAircraftMap[grdAircraftMap.CurrentRowIndex, grdAircraftMap.CurrentColumnIndex].Value = "COM REG-SER#";
				grdAircraftMap.SetColumnWidth(3, 220);

				grdAircraftMap.CurrentColumnIndex = 4;
				grdAircraftMap[grdAircraftMap.CurrentRowIndex, grdAircraftMap.CurrentColumnIndex].Value = "COM AC ID";
				grdAircraftMap.SetColumnWidth(4, 73);

				if (!(adoRs.BOF && adoRs.EOF))
				{
					adoRs.MoveFirst();
					grdAircraftMap.CurrentRowIndex = 1;


					while(!adoRs.EOF)
					{
						grdAircraftMap.CurrentColumnIndex = 0;
						grdAircraftMap[grdAircraftMap.CurrentRowIndex, grdAircraftMap.CurrentColumnIndex].Value = $" {Convert.ToString(adoRs["ac_id"])}";

						grdAircraftMap.CurrentColumnIndex = 1;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(adoRs["ac_reg_no"]))
						{
							grdAircraftMap[grdAircraftMap.CurrentRowIndex, grdAircraftMap.CurrentColumnIndex].Value = $" {Convert.ToString(adoRs["ac_reg_no"])}";
						}
						else
						{
							grdAircraftMap[grdAircraftMap.CurrentRowIndex, grdAircraftMap.CurrentColumnIndex].Value = "";
						}

						grdAircraftMap.CurrentColumnIndex = 2;
						grdAircraftMap[grdAircraftMap.CurrentRowIndex, grdAircraftMap.CurrentColumnIndex].Value = $" {Convert.ToString(adoRs["ac_ser_no_full"])}";

						grdAircraftMap.CurrentColumnIndex = 3;

						// -- 2 SELECT ASSOCIATED RECORD FROM COMMERCIAL MAP_AIRCRAFT TABLE WITH SAME HOMEBASE AC ID
						Query = "SELECT *";
						Query = $"{Query} FROM Map_Aircraft WITH (NOLOCK)";
						Query = $"{Query} WHERE mapac_homebase_ac_id = {Convert.ToString(adoRs["ac_id"])}";
						adoRs_Com.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
						if (!(adoRs_Com.BOF && adoRs_Com.EOF))
						{
							intMapped++;
							if (Convert.ToString(adoRs_Com["mapac_load_flag"]) == "L")
							{
								grdAircraftMap[grdAircraftMap.CurrentRowIndex, grdAircraftMap.CurrentColumnIndex].Value = "";
							}
							else
							{
								// USE THE NAME FROM THE HOMEBASE MODEL COMBO BOX TO STRIP OFF THE HOMEBASE MODEL NAME AND
								// ONLY DISPLAY THE REG AND SERIAL NUMBER FROM THE MAPPING TABLE IF POSSIBLE
								grdAircraftMap.CellBackColor = Color.Lime;
								// grdAircraftMap.Text = " " & Replace(adoRs_Com("mapac_home_name").Value, cmbHbaseModels.Text & "-", "")
								grdAircraftMap[grdAircraftMap.CurrentRowIndex, grdAircraftMap.CurrentColumnIndex].Value = $" {Convert.ToString(adoRs_Com["mapac_home_name"])}";

							}
							// DISPLAY THE HOMEBASE AIRCRAFT ID IF A DUPLICATE AIRCRAFT OTHERWISE THE WORDS TO LOAD
							grdAircraftMap.CurrentColumnIndex = 4;
							if (Convert.ToString(adoRs_Com["mapac_load_flag"]) == "L")
							{
								grdAircraftMap[grdAircraftMap.CurrentRowIndex, grdAircraftMap.CurrentColumnIndex].Value = "";
							}
							else
							{
								grdAircraftMap[grdAircraftMap.CurrentRowIndex, grdAircraftMap.CurrentColumnIndex].Value = $" {Convert.ToString(adoRs_Com["mapac_com_ac_id"])}";

								// FILL IN A LIST OF HOMEBASE AC IDS MAPPED TO COMMERCIAL AIRCRFT FOR THIS MODEL
								// WE CAN THEN USE THIS TO SELECT ONLY THE ONES THAT ARE NOT MAPPED TO SUPPORT
								// MORE EFFICIENT MAPPING
								if (Mapped_homebase_ac_list != "")
								{
									Mapped_homebase_ac_list = $"{Mapped_homebase_ac_list},{Convert.ToString(adoRs_Com["mapac_com_ac_id"])}";
								}
								else
								{
									Mapped_homebase_ac_list = Convert.ToString(adoRs_Com["mapac_com_ac_id"]);
								}
							}
						}
						else
						{
							// If Not (adoRs_Com.BOF And adoRs_Com.EOF) Then for the Aircraft Mapping
							adoRs_Com.Close();
							// -- 3 IF NO RECORD FOUND BY #2 THEN ATTEMPT TO FIND A RECORD IN COMMERCIAL WITH SAME MAPPED MODEL ID AND DESIGNATED SERIAL NUMBER
							Query = "select ac_id, ac_reg_no, ac_ser_no_full, amod_make_name, amod_model_name";
							Query = $"{Query} from aircraft WITH (NOLOCK) INNER JOIN aircraft_model WITH (NOLOCK) ON ac_amod_id = amod_id";
							Query = $"{Query} where ac_amod_id = {ac_amod_id_com} and ac_journ_id = 0 AND ac_ser_no_full='{Convert.ToString(adoRs["ac_ser_no_full"])}'";
							adoRs_Com.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

							if (!(adoRs_Com.BOF && adoRs_Com.EOF))
							{
								grdAircraftMap[grdAircraftMap.CurrentRowIndex, grdAircraftMap.CurrentColumnIndex].Value = $" {Convert.ToString(adoRs_Com["amod_make_name"])}-{Convert.ToString(adoRs_Com["amod_model_name"])}  {Convert.ToString(adoRs_Com["ac_reg_no"])}-{Convert.ToString(adoRs_Com["ac_ser_no_full"])}";
								grdAircraftMap.CellBackColor = Color.Lime;
								intMapped++;
								grdAircraftMap.CurrentColumnIndex = 4;
								Query = "SELECT mapac_key";
								Query = $"{Query} FROM Map_Aircraft WITH(NOLOCK)";
								Query = $"{Query} WHERE mapac_com_ac_id= {Convert.ToString(adoRs_Com["ac_id"])}";
								if (modAdminCommon.Exist(Query))
								{
									//'''''''''''''''''''''''''''''''''''''''''''''''''
									// update the map_aircraft table with the info
									//'''''''''''''''''''''''''''''''''''''''''''''''''
									Query = $"UPDATE Map_Aircraft SET  mapac_home_name ='{Convert.ToString(adoRs["amod_make_name"])}-{Convert.ToString(adoRs["amod_model_name"])}-{Convert.ToString(adoRs["ac_reg_no"])}-{Convert.ToString(adoRs["ac_ser_no_full"])}', mapac_com_name ='{Convert.ToString(adoRs_Com["amod_make_name"])}-{Convert.ToString(adoRs_Com["amod_model_name"])}-{Convert.ToString(adoRs_Com["ac_reg_no"])}-{Convert.ToString(adoRs_Com["ac_ser_no_full"])}', mapac_homebase_ac_id = {Convert.ToString(adoRs["ac_id"])}, mapac_load_flag = 'D' WHERE mapac_com_ac_id= {Convert.ToString(adoRs_Com["ac_id"])}";
									DbCommand TempCommand = null;
									TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
									UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
									TempCommand.CommandText = Query;
									//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
									//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
									TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
									UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
									TempCommand.ExecuteNonQuery();

									grdAircraftMap[grdAircraftMap.CurrentRowIndex, grdAircraftMap.CurrentColumnIndex].Value = adoRs_Com["ac_id"];
								}
								else
								{
									Query = "SELECT mapac_key";
									Query = $"{Query} FROM Map_Aircraft WITH(NOLOCK)";
									Query = $"{Query} WHERE mapac_homebase_ac_id= {Convert.ToString(adoRs["ac_id"])}";

									if (modAdminCommon.Exist(Query))
									{
										Query = $"UPDATE Map_Aircraft SET  mapac_home_name ='{Convert.ToString(adoRs["amod_make_name"])}-{Convert.ToString(adoRs["amod_model_name"])}-{Convert.ToString(adoRs["ac_reg_no"])}-{Convert.ToString(adoRs["ac_ser_no_full"])}', mapac_com_name ='{Convert.ToString(adoRs_Com["amod_make_name"])}-{Convert.ToString(adoRs_Com["amod_model_name"])}-{Convert.ToString(adoRs_Com["ac_reg_no"])}-{Convert.ToString(adoRs_Com["ac_ser_no_full"])}', mapac_homebase_ac_id = {Convert.ToString(adoRs["ac_id"])}, mapac_load_flag = 'D' WHERE mapac_com_ac_id= {Convert.ToString(adoRs_Com["ac_id"])}";
										DbCommand TempCommand_2 = null;
										TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
										UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
										TempCommand_2.CommandText = Query;
										//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
										//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
										TempCommand_2.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
										UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
										TempCommand_2.ExecuteNonQuery();

										grdAircraftMap[grdAircraftMap.CurrentRowIndex, grdAircraftMap.CurrentColumnIndex].Value = adoRs_Com["ac_id"];
									}
									else
									{
										Query = "Insert Map_Aircraft(mapac_com_ac_id, mapac_homebase_ac_id, mapac_com_name, mapac_home_name, mapac_load_flag) ";
										Query = $"{Query} Values({Convert.ToString(adoRs_Com["ac_id"])},{Convert.ToString(adoRs["ac_id"])},'{Convert.ToString(adoRs_Com["amod_make_name"])}-{Convert.ToString(adoRs_Com["amod_model_name"])}-{Convert.ToString(adoRs_Com["ac_reg_no"])}-{Convert.ToString(adoRs_Com["ac_ser_no_full"])}','{Convert.ToString(adoRs["amod_make_name"])}-{Convert.ToString(adoRs["amod_model_name"])}-{Convert.ToString(adoRs["ac_reg_no"])}-{Convert.ToString(adoRs["ac_ser_no_full"])}','D') ";
										DbCommand TempCommand_3 = null;
										TempCommand_3 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
										UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_3);
										TempCommand_3.CommandText = Query;
										//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
										//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
										TempCommand_3.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
										UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_3);
										TempCommand_3.ExecuteNonQuery();

										grdAircraftMap[grdAircraftMap.CurrentRowIndex, grdAircraftMap.CurrentColumnIndex].Value = adoRs_Com["ac_id"];
									}
								} // If Not IsExists(Query) Then 1st check
							}
							else
							{
								adoRs_Com.Close();
								// -- 4 IF NO RECORD FOUND BY #3 THEN ATTEMPT TO FIND A RECORD IN COMMERCIAL WITH SAME Make Name AND DESIGNATED SERIAL NUMBER
								Query = "select ac_id, ac_reg_no, ac_ser_no_full, amod_make_name, amod_model_name";
								Query = $"{Query} from aircraft WITH (NOLOCK) INNER JOIN Aircraft_Model WITH (NOLOCK) ON ac_amod_id = amod_id";
								Query = $"{Query} where amod_make_name = '{make_mod_name}' and ac_journ_id = 0 AND ac_ser_no_full='{Convert.ToString(adoRs["ac_ser_no_full"])}'";
								adoRs_Com.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
								if (!(adoRs_Com.BOF && adoRs_Com.EOF))
								{
									grdAircraftMap[grdAircraftMap.CurrentRowIndex, grdAircraftMap.CurrentColumnIndex].Value = $" {Convert.ToString(adoRs_Com["amod_make_name"])}-{Convert.ToString(adoRs_Com["amod_model_name"])}  {Convert.ToString(adoRs_Com["ac_reg_no"])}-{Convert.ToString(adoRs_Com["ac_ser_no_full"])}";
									grdAircraftMap.CellBackColor = Color.Yellow;
									intDuplicates++;
									intToLoad++;
									grdAircraftMap.CurrentColumnIndex = 4;
									grdAircraftMap[grdAircraftMap.CurrentRowIndex, grdAircraftMap.CurrentColumnIndex].Value = "PMWM";
								}
								else
								{
									intToLoad++;
									grdAircraftMap[grdAircraftMap.CurrentRowIndex, grdAircraftMap.CurrentColumnIndex].Value = "";
									grdAircraftMap.CurrentColumnIndex = 4;
									grdAircraftMap[grdAircraftMap.CurrentRowIndex, grdAircraftMap.CurrentColumnIndex].Value = "";
								} // If Not (adoRs_Com.BOF And adoRs_Com.EOF) Then --4

							} // If Not (adoRs.BOF And adoRs.EOF) Then --3

						} // If Not (adoRs.BOF And adoRs.EOF) Then for -- 2
						adoRs_Com.Close();

						grdAircraftMap.set_RowData(grdAircraftMap.CurrentRowIndex, Convert.ToInt32(adoRs["ac_id"]));

						grdAircraftMap.RowsCount++;
						grdAircraftMap.CurrentRowIndex++;

						adoRs.MoveNext();
					};

					adoRs.Close();
					adoRs = null;

					grdAircraftMap.RowsCount--;
					grdAircraftMap.CurrentRowIndex = 1;
					grdAircraftMap.Enabled = true;
					grdAircraftMap.Visible = true;
					grdAircraftMap.Redraw = true;

				} // BOF EOF

			}
			else if (whichView == "Commerical")
			{ 

				Query = "SELECT ac_id, ac_reg_no, ac_ser_no_full, amod_make_name, amod_model_name ";
				Query = $"{Query} FROM aircraft WITH (NOLOCK) INNER JOIN aircraft_model WITH (NOLOCK) ON amod_id = ac_amod_id";
				Query = $"{Query} WHERE ac_amod_id = {ac_amod_id_com} AND AC_Journ_id = 0";

				adoRs_Com.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				//  ' CLEAR THE LIST OF AIRCRAFT IDS MAPPED FOR THIS MODEL
				Mapped_homebase_ac_list = "";

				grdAircraftMap.Visible = true;
				grdAircraftMap.Enabled = false;

				grdAircraftMap.Clear();
				grdAircraftMap.ColumnsCount = 5;
				grdAircraftMap.RowsCount = 2;

				grdAircraftMap.CurrentRowIndex = 0;
				grdAircraftMap.CurrentColumnIndex = 0;
				grdAircraftMap[grdAircraftMap.CurrentRowIndex, grdAircraftMap.CurrentColumnIndex].Value = "COM AC ID";
				grdAircraftMap.SetColumnWidth(0, 73);

				grdAircraftMap.CurrentColumnIndex = 1;
				grdAircraftMap[grdAircraftMap.CurrentRowIndex, grdAircraftMap.CurrentColumnIndex].Value = "COM REG#";
				grdAircraftMap.SetColumnWidth(1, 70);

				grdAircraftMap.CurrentColumnIndex = 2;
				grdAircraftMap[grdAircraftMap.CurrentRowIndex, grdAircraftMap.CurrentColumnIndex].Value = "COM SER#";
				grdAircraftMap.SetColumnWidth(2, 70);

				grdAircraftMap.CurrentColumnIndex = 3;
				grdAircraftMap[grdAircraftMap.CurrentRowIndex, grdAircraftMap.CurrentColumnIndex].Value = "HOM REG-SER#";
				grdAircraftMap.SetColumnWidth(3, 220);

				grdAircraftMap.CurrentColumnIndex = 4;
				grdAircraftMap[grdAircraftMap.CurrentRowIndex, grdAircraftMap.CurrentColumnIndex].Value = "HOM AC ID";
				grdAircraftMap.SetColumnWidth(4, 73);

				if (!(adoRs_Com.BOF && adoRs_Com.EOF))
				{
					adoRs_Com.MoveFirst();
					grdAircraftMap.CurrentRowIndex = 1;


					while(!adoRs_Com.EOF)
					{
						grdAircraftMap.CurrentColumnIndex = 0;
						grdAircraftMap[grdAircraftMap.CurrentRowIndex, grdAircraftMap.CurrentColumnIndex].Value = $" {Convert.ToString(adoRs_Com["ac_id"])}";

						grdAircraftMap.CurrentColumnIndex = 1;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(adoRs_Com["ac_reg_no"]))
						{
							grdAircraftMap[grdAircraftMap.CurrentRowIndex, grdAircraftMap.CurrentColumnIndex].Value = $" {Convert.ToString(adoRs_Com["ac_reg_no"])}";
						}
						else
						{
							grdAircraftMap[grdAircraftMap.CurrentRowIndex, grdAircraftMap.CurrentColumnIndex].Value = "";
						}

						grdAircraftMap.CurrentColumnIndex = 2;
						grdAircraftMap[grdAircraftMap.CurrentRowIndex, grdAircraftMap.CurrentColumnIndex].Value = $" {Convert.ToString(adoRs_Com["ac_ser_no_full"])}";

						grdAircraftMap.CurrentColumnIndex = 3;

						// -- 2 SELECT ASSOCIATED RECORD FROM COMMERCIAL MAP_AIRCRAFT TABLE WITH SAME HOMEBASE AC ID
						Query = "SELECT *";
						Query = $"{Query} FROM Map_Aircraft WITH (NOLOCK)";
						Query = $"{Query} WHERE mapac_com_ac_id  = {Convert.ToString(adoRs_Com["ac_id"])}";
						//adoRs_Com.Open Query, LOCAL_ADO_DB, adOpenStatic, adLockReadOnly, adCmdText
						adoRs = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

						if (!(adoRs.BOF && adoRs.EOF))
						{
							intMapped++;
							if (Convert.ToString(adoRs["mapac_load_flag"]) == "L")
							{
								grdAircraftMap[grdAircraftMap.CurrentRowIndex, grdAircraftMap.CurrentColumnIndex].Value = "";
							}
							else
							{
								// USE THE NAME FROM THE HOMEBASE MODEL COMBO BOX TO STRIP OFF THE HOMEBASE MODEL NAME AND
								// ONLY DISPLAY THE REG AND SERIAL NUMBER FROM THE MAPPING TABLE IF POSSIBLE
								//''''''''''''''''''''''''''''''''''''''''''''''''
								// go get the live data for the serial-reg#
								//''''''''''''''''''''''''''''''''''''''''''''''''
								grdAircraftMap.CellBackColor = Color.Lime;
								// grdAircraftMap.Text = " " & Replace(adoRs_Com("mapac_home_name").Value, cmbHbaseModels.Text & "-", "")
								grdAircraftMap[grdAircraftMap.CurrentRowIndex, grdAircraftMap.CurrentColumnIndex].Value = $" {Convert.ToString(adoRs["mapac_home_name"])}";
							}
							// DISPLAY THE HOMEBASE AIRCRAFT ID IF A DUPLICATE AIRCRAFT OTHERWISE THE WORDS TO LOAD
							grdAircraftMap.CurrentColumnIndex = 4;
							if (Convert.ToString(adoRs["mapac_load_flag"]) == "L")
							{
								grdAircraftMap[grdAircraftMap.CurrentRowIndex, grdAircraftMap.CurrentColumnIndex].Value = "";
							}
							else
							{
								grdAircraftMap[grdAircraftMap.CurrentRowIndex, grdAircraftMap.CurrentColumnIndex].Value = $" {Convert.ToString(adoRs["mapac_homebase_ac_id"])}";

								// FILL IN A LIST OF HOMEBASE AC IDS MAPPED TO COMMERCIAL AIRCRFT FOR THIS MODEL
								// WE CAN THEN USE THIS TO SELECT ONLY THE ONES THAT ARE NOT MAPPED TO SUPPORT
								// MORE EFFICIENT MAPPING
								if (Mapped_homebase_ac_list != "")
								{
									Mapped_homebase_ac_list = $"{Mapped_homebase_ac_list},{Convert.ToString(adoRs["mapac_homebase_ac_id"])}";
								}
								else
								{
									Mapped_homebase_ac_list = Convert.ToString(adoRs["mapac_homebase_ac_id"]);
								}
							}
						}
						else
						{
							// If Not (adoRs_Com.BOF And adoRs_Com.EOF) Then for the Aircraft Mapping
							adoRs.Close();
							// -- 3 IF NO RECORD FOUND BY #2 THEN ATTEMPT TO FIND A RECORD IN COMMERCIAL WITH SAME MAPPED MODEL ID AND DESIGNATED SERIAL NUMBER
							Query = "select ac_id, ac_reg_no, ac_ser_no_full, amod_make_name, amod_model_name";
							Query = $"{Query} from aircraft WITH (NOLOCK) INNER JOIN aircraft_model WITH (NOLOCK) ON ac_amod_id = amod_id";
							Query = $"{Query} where ac_amod_id = {ac_amod_id} and ac_journ_id = 0 AND ac_ser_no_full='{Convert.ToString(adoRs_Com["ac_ser_no_full"])}'";
							//adoRs_Com.Open Query, LOCAL_ADO_DB, adOpenStatic, adLockReadOnly, adCmdText
							adoRs = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

							if (!(adoRs.BOF && adoRs.EOF))
							{
								grdAircraftMap[grdAircraftMap.CurrentRowIndex, grdAircraftMap.CurrentColumnIndex].Value = $" {Convert.ToString(adoRs["amod_make_name"])}-{Convert.ToString(adoRs["amod_model_name"])}  {Convert.ToString(adoRs["ac_reg_no"])}-{Convert.ToString(adoRs["ac_ser_no_full"])}";
								grdAircraftMap.CellBackColor = Color.Lime;
								intMapped++;
								// check that a record Exists with the com_ac_id
								Query = "SELECT mapac_com_ac_id";
								Query = $"{Query} FROM Map_Aircraft WITH(NOLOCK)";
								Query = $"{Query} WHERE mapac_com_ac_id= {Convert.ToString(adoRs_Com["ac_id"])}";
								if (modAdminCommon.Exist(Query))
								{
									Query = $"UPDATE Map_Aircraft SET  mapac_home_name ='{Convert.ToString(adoRs["amod_make_name"])}-{Convert.ToString(adoRs["amod_model_name"])}-{Convert.ToString(adoRs["ac_reg_no"])}-{Convert.ToString(adoRs["ac_ser_no_full"])}', mapac_com_name ='{Convert.ToString(adoRs_Com["amod_make_name"])}-{Convert.ToString(adoRs_Com["amod_model_name"])}-{Convert.ToString(adoRs_Com["ac_reg_no"])}-{Convert.ToString(adoRs_Com["ac_ser_no_full"])}', mapac_homebase_ac_id = {Convert.ToString(adoRs["ac_id"])}, mapac_load_flag = 'D' WHERE mapac_com_ac_id= {Convert.ToString(adoRs_Com["ac_id"])}";

									DbCommand TempCommand_4 = null;
									TempCommand_4 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
									UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_4);
									TempCommand_4.CommandText = Query;
									//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
									//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
									TempCommand_4.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
									UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_4);
									TempCommand_4.ExecuteNonQuery();

									grdAircraftMap.CurrentColumnIndex = 4;
									grdAircraftMap[grdAircraftMap.CurrentRowIndex, grdAircraftMap.CurrentColumnIndex].Value = adoRs["ac_id"];
								}
								else
								{
									// check for a commmerical ac id
									Query = "SELECT mapac_com_ac_id";
									Query = $"{Query} FROM Map_Aircraft WITH(NOLOCK)";
									Query = $"{Query} WHERE mapac_com_ac_id= {Convert.ToString(adoRs["ac_id"])}";
									if (modAdminCommon.Exist(Query))
									{
										Query = $"UPDATE Map_Aircraft SET  mapac_home_name ='{Convert.ToString(adoRs["amod_make_name"])}-{Convert.ToString(adoRs["amod_model_name"])}-{Convert.ToString(adoRs["ac_reg_no"])}-{Convert.ToString(adoRs["ac_ser_no_full"])}', mapac_com_name ='{Convert.ToString(adoRs_Com["amod_make_name"])}-{Convert.ToString(adoRs_Com["amod_model_name"])}-{Convert.ToString(adoRs_Com["ac_reg_no"])}-{Convert.ToString(adoRs_Com["ac_ser_no_full"])}', mapac_homebase_ac_id = {Convert.ToString(adoRs["ac_id"])}, mapac_load_flag = 'D' WHERE mapac_com_ac_id= {Convert.ToString(adoRs_Com["ac_id"])}";

										DbCommand TempCommand_5 = null;
										TempCommand_5 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
										UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_5);
										TempCommand_5.CommandText = Query;
										//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
										//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
										TempCommand_5.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
										UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_5);
										TempCommand_5.ExecuteNonQuery();

										grdAircraftMap.CurrentColumnIndex = 4;
										grdAircraftMap[grdAircraftMap.CurrentRowIndex, grdAircraftMap.CurrentColumnIndex].Value = adoRs["ac_id"];
									}
									else
									{
										Query = "Insert Map_Aircraft(mapac_com_ac_id, mapac_homebase_ac_id, mapac_com_name, mapac_home_name, mapac_load_flag) ";
										Query = $"{Query} Values({Convert.ToString(adoRs_Com["ac_id"])},{Convert.ToString(adoRs["ac_id"])},'{Convert.ToString(adoRs_Com["amod_make_name"])}-{Convert.ToString(adoRs_Com["amod_model_name"])}-{Convert.ToString(adoRs_Com["ac_reg_no"])}-{Convert.ToString(adoRs_Com["ac_ser_no_full"])}','{Convert.ToString(adoRs["amod_make_name"])}-{Convert.ToString(adoRs["amod_model_name"])}-{Convert.ToString(adoRs["ac_reg_no"])}-{Convert.ToString(adoRs["ac_ser_no_full"])}','D') ";

										DbCommand TempCommand_6 = null;
										TempCommand_6 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
										UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_6);
										TempCommand_6.CommandText = Query;
										//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
										//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
										TempCommand_6.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
										UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_6);
										TempCommand_6.ExecuteNonQuery();

										grdAircraftMap[grdAircraftMap.CurrentRowIndex, grdAircraftMap.CurrentColumnIndex].Value = adoRs_Com["ac_id"];
									} // If Not IsExists(Query) then 2nd check

								} // If Not IsExists(Query) Then 1st check

							}
							else
							{
								adoRs.Close();
								// -- 4 IF NO RECORD FOUND BY #3 THEN ATTEMPT TO FIND A RECORD IN COMMERCIAL WITH SAME Make Name AND DESIGNATED SERIAL NUMBER
								Query = "select ac_id, ac_reg_no, ac_ser_no_full, amod_make_name, amod_model_name";
								Query = $"{Query} from aircraft WITH (NOLOCK) INNER JOIN Aircraft_Model WITH (NOLOCK) ON ac_amod_id = amod_id";
								Query = $"{Query} where amod_make_name = '{make_mod_name}' and ac_journ_id = 0 AND ac_ser_no_full='{Convert.ToString(adoRs_Com["ac_ser_no_full"])}'";
								adoRs = ADORecordSetHelper.Open(Query, modAdminCommon.LOCAL_ADO_DB, "");

								if (!(adoRs.BOF && adoRs.EOF))
								{
									grdAircraftMap[grdAircraftMap.CurrentRowIndex, grdAircraftMap.CurrentColumnIndex].Value = $" {Convert.ToString(adoRs["amod_make_name"])}-{Convert.ToString(adoRs["amod_model_name"])}-{Convert.ToString(adoRs["ac_reg_no"])}-{Convert.ToString(adoRs["ac_ser_no_full"])}";
									grdAircraftMap.CellBackColor = Color.Yellow;
									intDuplicates++;
									intToLoad++;
									grdAircraftMap.CurrentColumnIndex = 4;
									grdAircraftMap[grdAircraftMap.CurrentRowIndex, grdAircraftMap.CurrentColumnIndex].Value = "PMWM";
								}
								else
								{
									grdAircraftMap[grdAircraftMap.CurrentRowIndex, grdAircraftMap.CurrentColumnIndex].Value = "";
									intToLoad++;
									grdAircraftMap.CurrentColumnIndex = 4;
									grdAircraftMap[grdAircraftMap.CurrentRowIndex, grdAircraftMap.CurrentColumnIndex].Value = "";
								} // If Not (adoRs_Com.BOF And adoRs_Com.EOF) Then --4

							} // If Not (adoRs.BOF And adoRs.EOF) Then --3

						} // If Not (adoRs.BOF And adoRs.EOF) Then for -- 2
						adoRs.Close();




						grdAircraftMap.set_RowData(grdAircraftMap.CurrentRowIndex, Convert.ToInt32(adoRs_Com["ac_id"]));

						grdAircraftMap.RowsCount++;
						grdAircraftMap.CurrentRowIndex++;

						adoRs_Com.MoveNext();
					};

					adoRs_Com.Close();
					adoRs = null;

					grdAircraftMap.RowsCount--;
					grdAircraftMap.CurrentRowIndex = 1;
					grdAircraftMap.Enabled = true;
					grdAircraftMap.Visible = true;
					grdAircraftMap.Redraw = true;
				} // BOF EOF
			} // If whichView = "Homebase" Then

			lbl_spec[2].Text = $"{lbl_spec[2].Text}{Environment.NewLine} Mapped #{intMapped.ToString()}, ToLoad #{intToLoad.ToString()}, Possible Duplicates #{intDuplicates.ToString()}";

		}

		public bool Check_Hombase_For_Model(string amod_make_model_name)
		{

			bool result = false;
			ADORecordSetHelper adoRs = new ADORecordSetHelper();
			string sSelectedItem = "";
			bool bValidAcID = false;

			string amod_make_name = "";
			string amod_model_name = "";

			int i = 0;
			this.Cursor = Cursors.WaitCursor;
			cmbHbaseModels.Items.Clear();
			// split out the amod_make_name and the amod_model_name
			i = (amod_make_model_name.IndexOf('-') + 1);
			amod_make_name = amod_make_model_name.Substring(0, Math.Min(i - 1, amod_make_model_name.Length));
			amod_model_name = amod_make_model_name.Substring(Math.Max(amod_make_model_name.Length - (Strings.Len(amod_make_model_name) - i), 0));
			snp_Model = new ADORecordSetHelper();
			string Query = "SELECT amod_id, amod_make_name, amod_model_name FROM Aircraft_Model";
			Query = $"{Query} WHERE amod_make_name = '{amod_make_name}' AND amod_model_name = '{amod_model_name}'";
			Query = $"{Query} ORDER BY amod_make_name, amod_model_name ";

			adoRs.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

			if (!(adoRs.BOF && adoRs.EOF))
			{
				result = true;
			}
			adoRs.Close();

			return result;
		}

		public bool Aircraft_Model_ToLoad_Aircraft(string com_amod_id)
		{
			bool result = false;
			ADORecordSetHelper adoModels = new ADORecordSetHelper();
			StringBuilder mapac_key = new StringBuilder();
			bool firstRun = false;
			string Query = "SELECT mapac_key FROM Map_Aircraft WITH(NOLOCK)";
			Query = $"{Query} INNER JOIN Aircraft WITH(NOLOCK) ON Map_Aircraft.mapac_com_ac_id = Aircraft.ac_id AND Aircraft.ac_journ_id = 0 and Aircraft.ac_amod_id = {com_amod_id}";
			adoModels.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

			if (!(adoModels.BOF && adoModels.EOF))
			{

				while(!adoModels.EOF)
				{
					if (firstRun)
					{
						firstRun = true;
						mapac_key.Append(",");
					}
					else
					{
						firstRun = true;
					}
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(adoModels["mapac_key"]))
					{
						mapac_key.Append(Convert.ToString(adoModels["mapac_key"]));
					}
					adoModels.MoveNext();
				};
				// update the AC mapping table
				Query = $"Update Map_Aircraft set  mapac_homebase_ac_id= 0,  mapac_home_name= '', mapac_load_flag = 'L'  WHERE mapac_key IN({mapac_key.ToString()})";
				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();
				adoModels.Close();
				result = true;
			}

			return result;
		}
	}
}