using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
using Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6;
using System;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using UpgradeHelpers;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Gui.Controls;
using UpgradeHelpers.Helpers;
using UpgradeStubs;

namespace HomebaseAdministrator
{
	internal partial class frm_AircraftLookup
		: System.Windows.Forms.Form
	{

		public frm_AircraftLookup()
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


		private void frm_AircraftLookup_Activated(System.Object eventSender, System.EventArgs eventArgs)
		{
			if (UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm != eventSender)
			{
				UpgradeHelpers.Gui.Utils.ActivateHelper.myActiveForm = (System.Windows.Forms.Form) eventSender;
			}
		}
		//******************************************************************************************
		//******************************************************************************************



		private ADORecordSetHelper _snp_Airport = null;
		public ADORecordSetHelper snp_Airport
		{
			get
			{
				if (_snp_Airport is null)
				{
					_snp_Airport = new ADORecordSetHelper();
				}
				return _snp_Airport;
			}
			set => _snp_Airport = value;
		}
		 //Airport
		public int ac_count = 0; // used for pnl_airport_update Aircraft Airport tab 6-10-09 Tom J.

		private int lNbrFlights = 0;
		private string AirportSort = ""; // Order by clause
		private string RecordStat = ""; // add, delete, update
		private bool KeyFeatureWasActive = false;
		private string RememberAirport = "";

		private string Airport_Active_Status = "";
		double TempAirportIndex = 0;
		bool Is_Dirty = false;
		bool StopIt = false;
		bool bEngineModelChanged = false;

		const int iAPORTNAME_INDEX = 0;
		const int iIATA_INDEX = 1;
		const int iICAO_INDEX = 2;
		const int iCITY_INDEX = 3;
		const int iLAT_INDEX = 16;
		const int iLONG_INDEX = 17;
		const int iFAAID_INDEX = 18;
		const int iCOMPID_INDEX = 19;

		//-- Engine Model
		const int iEMID = 0;
		const int iEMNAME = 1;
		const int iEMPREFIX = 2;
		const int iEMCORE = 3;
		const int iEMTAKEOFFPOWER = 4;
		const int iEMMAXCONPOWER = 5;
		const int iEMSUFFIX1 = 6;
		const int iEMSUFFIX2 = 7;
		const int iEMMFRCOMPID = 8;
		const int iEMMFRABBREV = 9;
		const int iEMMFRNAME = 10;
		const int iEMTHRUSTLBS = 11;
		const int iEMCOMTBOHRS = 12;
		const int iEMSHAFTHP = 13;
		const int iEMHSI = 14;
		const int iEMMAKEMODEL = 15;

		const int iEMACTIVE = 0;
		const int iEMONCONDITIONTBO = 1;

		const int APortActiveOnly = 0;
		const int APortACCounts = 1;
		const int APortWCoord = 2;
		const int APortWOCoord = 3;
		const int APortWRunway = 4;
		const int APortWORunway = 5;
		const int APortWFlightData = 6;
		const int APortTransmitAC = 7;
		const int APortFAACounts = 8;

		const int iExportEngineModels = 0;
		const int iExportEMP = 1;

		public bool was_model_dependant = false;

		public void clear_fields_maint()
		{
			txt_maint[0].Text = "0";
			txt_maint[0].Visible = false;
			txt_maint[1].Text = "";
			txt_maint[2].Text = "";
			txt_maint[3].Text = "";
			chk_maint[0].CheckState = CheckState.Unchecked;
			chk_maint[1].CheckState = CheckState.Unchecked;
			cbo_maint_type.Text = "Inspection";
		}


		public void Clear_Grid_Row(UpgradeHelpers.DataGridViewFlex gGrid)
		{

			gGrid.CurrentRowIndex = gGrid.FixedRows;
			gGrid.CurrentColumnIndex = gGrid.FixedColumns;
			gGrid.HighLight = UpgradeHelpers.HighLightSettings.HighlightNever;

		} // Clear_Grid_Row

		private object get_keyfeat()
		{
			ADORecordSetHelper RS_Table = new ADORecordSetHelper();
			string RowColor = "";

			FG_KeyFeature.ColumnsCount = 3;

			DataGridViewFlex Grd = FG_KeyFeature;
			//UPGRADE_TODO: (1067) Member Clear is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			Grd.Clear();
			//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			Grd.Row = 0;
			//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			Grd.Col = 0;
			Grd.Text = "Code";
			//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			Grd.Col = 1;
			Grd.Text = "Name";
			//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			Grd.ColWidth[0] = 800;
			//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			Grd.ColWidth[1] = 4500;
			//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			Grd.ColWidth[2] = 600;
			//UPGRADE_TODO: (1067) Member CellAlignment is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			Grd.CellAlignment = DataGridViewContentAlignment.TopCenter;
			//UPGRADE_TODO: (1067) Member ColAlignment is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			Grd.ColAlignment[0] = DataGridViewContentAlignment.TopLeft;
            //UPGRADE_TODO: (1067) Member ColAlignment is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
            Grd.ColAlignment[1] = DataGridViewContentAlignment.TopLeft;
            //UPGRADE_TODO: (1067) Member ColAlignment is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
            Grd.ColAlignment[2] = DataGridViewContentAlignment.TopLeft;
            //UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
            Grd.Col = 2;
			Grd.Text = "MOD";
			//UPGRADE_TODO: (1067) Member CellAlignment is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			Grd.CellAlignment = DataGridViewContentAlignment.TopLeft;
            //UPGRADE_TODO: (1067) Member ColAlignment is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
            Grd.ColAlignment[0] = DataGridViewContentAlignment.TopLeft;
            //UPGRADE_TODO: (1067) Member ColAlignment is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
            Grd.ColAlignment[1] = DataGridViewContentAlignment.TopLeft;
            int nRow = 1; //Current row counter
			//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			Grd.Row = nRow;

			string Query = "SELECT * from Key_Feature ";

			if (chk_show_inactive.CheckState == CheckState.Checked)
			{
				Query = $"{Query} ";
			}
			else if (chk_show_inactive.CheckState == CheckState.Unchecked)
			{ 
				Query = $"{Query} where kfeat_inactive_date is  null ";
			}

			Query = $"{Query} ORDER BY kfeat_code ";
			RS_Table.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

			if (!(RS_Table.BOF && RS_Table.EOF))
			{

				while(!RS_Table.EOF)
				{
                    //lst_Kfeat_List.AddItem (Trim(snp_Feature!kfeat_code) & "-" & Trim(snp_Feature!kfeat_name))
                    //UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
                    Grd.Col = 0;
                    Grd.Text = ($"{Convert.ToString(RS_Table["kfeat_code"])}").Trim();
                    //UPGRADE_TODO: (1067) Member CellBackColor is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
                    Grd.CellBackColor = Color.FromArgb(SystemColorConstants.vbWindowBackground); // gap-note color 0x80000005 is equivalent to vbWindowBackground. See https://learn.microsoft.com/es-es/office/vba/language/reference/user-interface-help/system-color-constants;
                    if (Strings.Len(($"{Convert.ToString(RS_Table["kfeat_query"])}").Trim()) > 0)
                    {
                        //UPGRADE_TODO: (1067) Member CellBackColor is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
                        Grd.CellBackColor = Color.FromArgb(SystemColorConstants.vbButtonFace); // gap-note color 0x8000000F is equivalent to vbButtonFace. See https://learn.microsoft.com/es-es/office/vba/language/reference/user-interface-help/system-color-constants;
                    }

                    //UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
                    Grd.Col = 1;
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(Convert.ToString(RS_Table["kfeat_inactive_date"]).Trim()))
					{
                        //UPGRADE_TODO: (1067) Member CellBackColor is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
                        Grd.CellBackColor = System.Drawing.ColorTranslator.FromHtml("#C0C0FF"); // gap-note color 0xC0C0FF . Important: Check this color in runtime to see if is the same of VB6
                    }
					Grd.Text = ($"{Convert.ToString(RS_Table["kfeat_name"])}").Trim();

					//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					Grd.Col = 2;
					if (($"{Convert.ToString(RS_Table["kfeat_model_dependent_flag"])}").Trim() == "Y")
					{
                        //UPGRADE_TODO: (1067) Member CellBackColor is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
                        Grd.CellBackColor = Color.FromArgb(SystemColorConstants.vbButtonFace); // gap-note color 0x8000000F is equivalent to vbButtonFace. See https://learn.microsoft.com/es-es/office/vba/language/reference/user-interface-help/system-color-constants;;
                    }
					Grd.Text = "";


					nRow++;
					//UPGRADE_TODO: (1067) Member Rows is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					Grd.RowCount = nRow + 1;//gap-note Grd.Rows was changed to GrdRow.RowCount
					//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					Grd.Row = nRow;
					RS_Table.MoveNext();
				};
			}
			RS_Table.Close();
            //UPGRADE_TODO: (1067) Member Rows is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
            Grd.RowCount = nRow + 1;//gap-note Grd.Rows was changed to GrdRow.RowCount
            Grd.Refresh();

			return null;
		}

		public void Highlight_Grid_Row(UpgradeHelpers.DataGridViewFlex gGrid, int lStartingColumn = 0)
		{

			try
			{

				gGrid.HighLight = UpgradeHelpers.HighLightSettings.HighlightAlways;
				if (gGrid.FixedColumns > 0)
				{
					if (lStartingColumn == 0)
					{
						gGrid.CurrentColumnIndex = gGrid.FixedColumns - 1;
					}
					else
					{
						gGrid.CurrentColumnIndex = lStartingColumn;
					}
				}
				else
				{
					if (lStartingColumn == 0)
					{
						gGrid.CurrentColumnIndex = gGrid.FixedColumns;
					}
					else
					{
						gGrid.CurrentColumnIndex = lStartingColumn;
					}
				}
				gGrid.ColSel = gGrid.ColumnsCount - 1;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error("Highlight_Grid_Row_Error", excep.Message);
			}

		} // Highlight_Grid_Row'
		public void display_maintenance_items(string order_by, int id_temp)
		{
			string Query = ""; //Current query sql
			ADORecordSetHelper RS_Table = new ADORecordSetHelper(); //Current recordset
			int nRow = 0; //Current row counter
            DataGridViewFlex Grd = null;
			string RowColor = "";

			int x = 0;
			string sTopic = "";
			int temp_sort = 0;
			int rem_row = 0;
			grd_maint_items.Visible = false;

			try
			{

				this.Cursor = Cursors.WaitCursor;
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Selecting Aircraft Topics ...", Color.Blue);

				Grd = grd_maint_items;

				//UPGRADE_TODO: (1067) Member Clear is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				Grd.Clear();
				//UPGRADE_TODO: (1067) Member Cols is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				Grd.Cols = 4;
				//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				Grd.Row = 0;
				//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				Grd.Col = 0;
				Grd.Text = "ID";
				//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				Grd.Col = 1;
				Grd.Text = "Name";
				//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				Grd.Col = 2;
				Grd.Text = "Count";
				//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				Grd.Col = 3;
				Grd.Text = "SRT";
				//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				Grd.ColWidth[0] = 600;
				//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				Grd.ColWidth[1] = 3800;
				//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				Grd.ColWidth[2] = 600;
				//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				Grd.ColWidth[3] = 400;
				//UPGRADE_TODO: (1067) Member CellAlignment is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				Grd.CellAlignment = DataGridViewContentAlignment.TopLeft;
                //UPGRADE_TODO: (1067) Member ColAlignment is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
                Grd.ColAlignment[0] = DataGridViewContentAlignment.TopLeft;
                //UPGRADE_TODO: (1067) Member ColAlignment is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
                Grd.ColAlignment[1] = DataGridViewContentAlignment.TopLeft;
                //UPGRADE_TODO: (1067) Member ColAlignment is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
                Grd.ColAlignment[2] = DataGridViewContentAlignment.TopLeft;
                nRow = 1;
				//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				Grd.Row = nRow;

				sTopic = "Inspection";


				Query = "SELECT distinct mitem_id, mitem_name, mitem_active_flag, mitem_load_flag, mitem_sort ";
				Query = $"{Query}, (select COUNT(*) from Aircraft_Maintenance with (NOLOCK) where acmaint_name = mitem_name) as tcount ";
				Query = $"{Query} from maintenance_item  with (NOLOCK) WHERE mitem_type = '{sTopic.Trim()}'";

				if (order_by.Trim() == "id")
				{
					Query = $"{Query} ORDER BY mitem_id asc ";
				}
				else if (order_by.Trim() == "count")
				{ 
					Query = $"{Query} ORDER BY tcount desc ";
				}
				else if (order_by.Trim() == "name")
				{ 
					Query = $"{Query} ORDER BY mitem_name asc ";
				}
				else
				{
					Query = $"{Query} ORDER BY mitem_sort asc, mitem_name asc ";
				}




				RS_Table.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);
				if (!(RS_Table.BOF && RS_Table.EOF))
				{
					RS_Table.MoveFirst();

					while(!RS_Table.EOF)
					{

						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						Grd.Col = 0;
						RowColor = "&H80000005";


						if (($"{Convert.ToString(RS_Table["mitem_active_flag"])}").Trim() == "N")
						{
							// MARK THOSE THAT HAVE NO DESCRIPTION AS PINK
							RowColor = "&H8080FF";
						}


						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						Grd.Col = 0;
                        //UPGRADE_TODO: (1067) Member CellBackColor is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
                        Grd.CellBackColor = Color.FromName(RowColor);
                        Grd.Text = ($"{Convert.ToString(RS_Table["mitem_id"])}").Trim();
						//UPGRADE_TODO: (1067) Member RowData is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						Grd.RowData[nRow] = ($"{Convert.ToString(RS_Table["mitem_id"])}").Trim();

						if (id_temp > 0)
						{
							if (id_temp == Convert.ToInt32(Double.Parse(($"{Convert.ToString(RS_Table["mitem_id"])}").Trim())))
							{
								rem_row = nRow;
							}
						}

						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						Grd.Col = 1;
                        //UPGRADE_TODO: (1067) Member CellBackColor is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
                        Grd.CellBackColor = Color.FromName(RowColor);
                        Grd.Text = ($"{Convert.ToString(RS_Table["mitem_name"])}").Trim();


						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						Grd.Col = 2;
                        //UPGRADE_TODO: (1067) Member CellBackColor is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
                        Grd.CellBackColor = Color.FromName(RowColor);
                        Grd.Text = ($"{Convert.ToString(RS_Table["tcount"])}").Trim();


						temp_sort = Convert.ToInt32(Double.Parse(($"{Convert.ToString(RS_Table["mitem_sort"])}").Trim()));

						if (order_by.Trim() != "")
						{
						}
						else
						{
							if (temp_sort != nRow)
							{
								Query = "UPDATE Maintenance_Item set ";
								Query = $"{Query}mitem_sort = '{nRow.ToString()}' where mitem_id = {Convert.ToInt32(Double.Parse(Convert.ToString(RS_Table["mitem_id"]).Trim())).ToString()}";
								Query = Query;
								DbCommand TempCommand = null;
								TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
								UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
								TempCommand.CommandText = Query;
								UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
								TempCommand.ExecuteNonQuery();
							}
						}


						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						Grd.Col = 3;
                        //UPGRADE_TODO: (1067) Member CellBackColor is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
                        Grd.CellBackColor = Color.FromName(RowColor);
                        Grd.Text = temp_sort.ToString();


						nRow++;
                        //UPGRADE_TODO: (1067) Member Rows is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
                        Grd.RowCount = nRow + 1;//gap-note Grd.Rows was changed to GrdRow.RowCount
                        //UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
                        Grd.Row = nRow;

						RS_Table.MoveNext();
					};
				}

				if (rem_row > 0)
				{
					//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					Grd.Col = 0;
					//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					Grd.Row = rem_row;
					Highlight_Grid_Row((UpgradeHelpers.DataGridViewFlex) Grd, 0);
					//UPGRADE_TODO: (1067) Member TopRow is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					Grd.TopRow = Grd.Row - 1; // gap-note review this property during runtime
				}

                //UPGRADE_TODO: (1067) Member Rows is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
                Grd.RowCount = nRow + 1;//gap-note Grd.Rows was changed to GrdRow.RowCount

                Grd.Refresh();

				// CLOSE RECORSET
				if (RS_Table != null)
				{
					if (RS_Table.State == ConnectionState.Open)
					{ // Already Open Close It
						RS_Table.Close();
					}
					RS_Table = null;
				}



				this.Cursor = CursorHelper.CursorDefault;
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);

				grd_maint_items.Visible = true;

				Application.DoEvents();
			}
			catch (System.Exception excep)
			{

				// INDICATE ERROR IN GETTING RULE FOR THE MODEL

				//UPGRADE_TODO: (1067) Member Rows is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				Grd.RowCount = nRow + 1;//gap-note Grd.Rows was changed to GrdRow.RowCount
				//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				Grd.Row = Grd.Row + 1; //gap-note modified. Review during runtime
				//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				Grd.Col = 0;
				Grd.Text = "No Topics for this area";

				// CLOSE RECORSET
				if (RS_Table != null)
				{
					if (RS_Table.State == ConnectionState.Open)
					{ // Already Open Close It
						RS_Table.Close();
					}
					RS_Table = null;
				}

				this.Cursor = CursorHelper.CursorDefault;
				modAdminCommon.Report_Error($"Aircraft_Topic_List_By_Topic_Fill_Error: {excep.Message}");

				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);

				return;
			}


		}

		public void fill_maintenance_item(int topicID)
		{

			ADORecordSetHelper ado_acTopicQuery = default(ADORecordSetHelper);
			try
			{


				string Query = "";
				ado_acTopicQuery = new ADORecordSetHelper();

				Query = $"SELECT * from Maintenance_Item WHERE mitem_id = {topicID.ToString()}";

				ado_acTopicQuery.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

				if (!(ado_acTopicQuery.BOF && ado_acTopicQuery.EOF))
				{
					ado_acTopicQuery.MoveFirst();

					while(!ado_acTopicQuery.EOF)
					{

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_acTopicQuery["mitem_id"]))
						{
							txt_maint[0].Text = Convert.ToString(ado_acTopicQuery["mitem_id"]);
						}
						else
						{
							txt_maint[0].Text = "";
						}
						txt_maint[0].Visible = true;

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_acTopicQuery["mitem_name"]))
						{
							txt_maint[1].Text = Convert.ToString(ado_acTopicQuery["mitem_name"]);
						}
						else
						{
							txt_maint[1].Text = "";
						}


						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_acTopicQuery["mitem_description"]))
						{
							txt_maint[2].Text = Convert.ToString(ado_acTopicQuery["mitem_description"]);
						}
						else
						{
							txt_maint[2].Text = "";
						}


						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_acTopicQuery["mitem_duration"]))
						{
							txt_maint[3].Text = Convert.ToString(ado_acTopicQuery["mitem_duration"]);
						}
						else
						{
							txt_maint[3].Text = "";
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_acTopicQuery["mitem_sort"]))
						{
							txt_maint[4].Text = Convert.ToString(ado_acTopicQuery["mitem_sort"]);
						}
						else
						{
							txt_maint[4].Text = "";
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_acTopicQuery["mitem_type"]))
						{
							cbo_maint_type.Text = Convert.ToString(ado_acTopicQuery["mitem_type"]);
						}
						else
						{
							cbo_maint_type.Text = "";
						}


						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_acTopicQuery["mitem_active_flag"]))
						{
							if (Convert.ToString(ado_acTopicQuery["mitem_active_flag"]).Trim() == "Y")
							{
								chk_maint[1].CheckState = CheckState.Checked;
							}
							else
							{
								chk_maint[1].CheckState = CheckState.Unchecked;
							}
						}
						else
						{
							chk_maint[1].CheckState = CheckState.Unchecked;
						}


						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(ado_acTopicQuery["mitem_load_flag"]))
						{
							if (Convert.ToString(ado_acTopicQuery["mitem_load_flag"]).Trim() == "Y")
							{
								chk_maint[0].CheckState = CheckState.Checked;
							}
							else
							{
								chk_maint[0].CheckState = CheckState.Unchecked;
							}
						}
						else
						{
							chk_maint[0].CheckState = CheckState.Unchecked;
						}



						ado_acTopicQuery.MoveNext();

					};

				}


				// CLOSE RECORSET
				if (ado_acTopicQuery != null)
				{
					if (ado_acTopicQuery.State == ConnectionState.Open)
					{ // Already Open Close It
						ado_acTopicQuery.Close();
					}
					ado_acTopicQuery = null;
				}

				cmd_maint[0].Visible = true;
				cmd_maint[1].Visible = true;
				cmd_maint[4].Visible = true;
			}
			catch (System.Exception excep)
			{
				// CLOSE RECORSET
				if (ado_acTopicQuery != null)
				{
					if (ado_acTopicQuery.State == ConnectionState.Open)
					{ // Already Open Close It
						ado_acTopicQuery.Close();
					}
					ado_acTopicQuery = null;
				}

				modAdminCommon.Report_Error($"Fill_Aircraft_Topic_Item_Error: {excep.Message}");

				this.Cursor = CursorHelper.CursorDefault;

				return;
			}

		}

		public void Fill_Topic_Area(ComboBox inCbo, string sInArea = "")
		{

			string Query = "";
			int I = 0;
			int RememberI = 0;
			ADORecordSetHelper RS_Table = new ADORecordSetHelper();

			try
			{

				Query = "select distinct actop_area from Aircraft_Topic with (NOLOCK) order by actop_area asc";

				RS_Table.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

				if (!(RS_Table.BOF && RS_Table.EOF))
				{

					inCbo.Enabled = false;
					inCbo.Items.Clear();
					inCbo.SelectedIndex = -1;
					inCbo.AddItem("All");
					I = 0;

					do 
					{

						I++;
						inCbo.AddItem(($"{Convert.ToString(RS_Table["actop_area"])}").Trim());

						if (sInArea.Trim() != "")
						{
							if (($"{Convert.ToString(RS_Table["actop_area"])}").Trim() == sInArea)
							{
								RememberI = I;
							}
						}

						RS_Table.MoveNext();

					}
					while(!RS_Table.EOF);

					if (RememberI >= 0)
					{
						inCbo.SelectedIndex = RememberI;
					}

					inCbo.Enabled = true;

				}

				RS_Table.Close();
				RS_Table = null;
			}
			catch (System.Exception excep)
			{

				// CLOSE RECORSET
				if (RS_Table != null)
				{
					if (RS_Table.State == ConnectionState.Open)
					{ // Already Open Close It
						RS_Table.Close();
					}
					RS_Table = null;
				}

				modAdminCommon.Report_Error($"Fill_Topic_Area_Error: {excep.Message}");
				this.Cursor = CursorHelper.CursorDefault;

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1065
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
				return;
			}

		}

		public void Fill_Parent_Topic_Area(ComboBox inCbo, string sInArea = "", int nInTopicID = 0, int nInParentID = 0)
		{

			string Query = "";
			int I = 0;
			int RememberI = 0;
			ADORecordSetHelper RS_Table = new ADORecordSetHelper();
			int RememberTimeout = 0;

			try
			{

				Query = "select actop_id, actop_name FROM aircraft_topic WITH(NOLOCK)";
				Query = $"{Query} WHERE actop_reference_id = 0 {((sInArea.Trim() != "") ? $"AND actop_area='{sInArea.Trim()}' " : "")}ORDER BY actop_name";

				RememberTimeout = UpgradeHelpers.DB.DbConnectionHelper.GetCommandTimeOut(modAdminCommon.LOCAL_ADO_DB);
				UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(modAdminCommon.LOCAL_ADO_DB, 1000);
				RS_Table.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);
				UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(modAdminCommon.LOCAL_ADO_DB, RememberTimeout);

				if (!(RS_Table.BOF && RS_Table.EOF))
				{

					inCbo.Enabled = false;
					inCbo.Items.Clear();
					inCbo.SelectedIndex = -1;
					inCbo.AddItem("0  - No Reference Topic");
					I = 0;

					do 
					{

						I++;

						if (nInTopicID != Convert.ToInt32(Double.Parse($"{Convert.ToString(RS_Table["actop_id"])}")))
						{

							inCbo.AddItem($"{($"{Convert.ToString(RS_Table["actop_id"])}").Trim()} - {($"{Convert.ToString(RS_Table["actop_name"])}").Trim()}");

							if (nInParentID > 0)
							{

								if (Convert.ToInt32(Double.Parse($"{Convert.ToString(RS_Table["actop_id"])}")) == nInParentID)
								{
									RememberI = I;
								}

							}

						}

						RS_Table.MoveNext();

					}
					while(!RS_Table.EOF);

					if (RememberI >= 0)
					{
						inCbo.SelectedIndex = RememberI;
					}

					inCbo.Enabled = true;
				}
				else
				{

					inCbo.Enabled = false;
					inCbo.Items.Clear();
					inCbo.SelectedIndex = -1;
					inCbo.AddItem("0  - Error Reference Topic");
					inCbo.SelectedIndex = 0;

				}

				RS_Table.Close();
				RS_Table = null;
			}
			catch (System.Exception excep)
			{

				// CLOSE RECORSET
				if (RS_Table != null)
				{
					if (RS_Table.State == ConnectionState.Open)
					{ // Already Open Close It
						RS_Table.Close();
					}
					RS_Table = null;
				}

				modAdminCommon.Report_Error($"Fill_Parent_Topic_Area_Error: {excep.Message}");
				this.Cursor = CursorHelper.CursorDefault;

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1065
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
				return;
			}

		}

		private void Insert_Update_Aircraft_Topic_item(int topicID, bool bIsDelete)
		{

			try
			{

				string Query = "";
				string ParentQuery = "";
				ADORecordSetHelper RS_Table = new ADORecordSetHelper(); //Current recordset
				ADORecordSetHelper ParentRecord = new ADORecordSetHelper();
				DialogResult RESP = (DialogResult) 0;
				string M = "";
				int RefTopic = 0;
				bool bIsParentTopic = false;
				int new_topic_id = 0;
				string get_last_id_Query = "";
				ADORecordSetHelper IDRecord = new ADORecordSetHelper();

				bIsParentTopic = false;

				//  SET THE REFERENCE ID FROM THE DROP DOWN
				if (StringsHelper.ToDoubleSafe(acTopicParentTopic.Text.Substring(0, Math.Min(1, acTopicParentTopic.Text.Length))) == 0)
				{
					RefTopic = 0;
				}
				else
				{
					RefTopic = Convert.ToInt32(Double.Parse(StringsHelper.Replace(acTopicParentTopic.Text.Substring(0, Math.Min(3, acTopicParentTopic.Text.Length)).Trim(), "-", "", 1, -1, CompareMethod.Binary)));
				}

				if (!bIsDelete && topicID == 0)
				{

					Query = "SELECT actop_name FROM aircraft_topic WITH(NOLOCK) ";
					Query = $"{Query}WHERE actop_name = '{modAdminCommon.Fix_Quote(acTopicItemName).Trim()}'";

					RS_Table.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

					if (!(RS_Table.BOF && RS_Table.EOF))
					{

						M = $"Aircraft Topic Name For : {acTopicItemName.Text.Trim()}{"\r"}{"\r"}";
						M = $"{M}Is not unique please re-enter!";

						MessageBox.Show(M, "Operation Cancled!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

						RS_Table.Close();

						return;

					}

					RS_Table = null;
				}

				if (topicID == 0 && !bIsDelete)
				{

					Query = "INSERT INTO Aircraft_Topic ( actop_area,  actop_name, actop_query, ";
					Query = $"{Query}actop_description, actop_reference_id,  actop_aerodex_flag ";

					Query = $"{Query}) values ( '{acTopicAreaItem.Text.Trim()}', ";
					Query = $"{Query}'{modAdminCommon.Fix_Quote(acTopicItemName).Trim()}', ";
					Query = $"{Query}'{StringsHelper.Replace(acTopicItemQuery.Text, "'", "''", 1, -1, CompareMethod.Binary).Trim()}', ";
					Query = $"{Query}'{modAdminCommon.Fix_Quote(acTopicItemDescription).Trim()}',{RefTopic.ToString()}, ";

					if (acTopicAerodexFlag.CheckState == CheckState.Checked)
					{
						Query = $"{Query}'Y'";
					}
					else
					{
						Query = $"{Query}'N'";
					}

					Query = $"{Query})";

					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = Query;
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();

					MessageBox.Show("Insert of Aircraft Topic Successfully Completed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));

					Aircraft_Topic_List_By_Topic_Fill(acTopicAreaItem.Text.Trim());

					// ADDED MSW - 9.8.15 get id of item just inserted
					//--------------------------------------------------
					get_last_id_Query = "select actop_id FROM Aircraft_Topic WITH(NOLOCK) order by actop_id desc ";

					IDRecord.Open(get_last_id_Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

					if (!(IDRecord.BOF && IDRecord.EOF))
					{

						new_topic_id = Convert.ToInt32(IDRecord["actop_id"]);

					}

					IDRecord.Close();
					IDRecord = null;
					//-----------------------------------------------------

					acTopicsPanel.Visible = false;
					acTopicAdd.Enabled = true;

					Is_Dirty = true;

				}
				else if (topicID > 0 && !bIsDelete)
				{ 

					// THIS IS THE UPDATE OF AN AIRCRAFT TOPIC

					Query = "UPDATE Aircraft_Topic SET ";
					Query = $"{Query}actop_name='{modAdminCommon.Fix_Quote(acTopicItemName.Text).Trim()}',";

					// ONLY UPDATE THE DESCRIPTION, AREA, QUERY, AND AERODEX IF 0 REFERENCE - OTHERWISE GET IT LATER
					// FROM THE PARENT TOPIC
					if (RefTopic == 0)
					{

						Query = $"{Query}actop_description = '{modAdminCommon.Fix_Quote(acTopicItemDescription).Trim()}',";
						Query = $"{Query}actop_area = '{modAdminCommon.Fix_Quote(acTopicAreaItem).Trim()}',";
						Query = $"{Query}actop_query = '{StringsHelper.Replace(acTopicItemQuery.Text, "'", "''", 1, -1, CompareMethod.Binary).Trim()}',";

						if (acTopicAerodexFlag.CheckState == CheckState.Checked)
						{
							Query = $"{Query}actop_aerodex_flag = 'Y',";
						}
						else
						{
							Query = $"{Query}actop_aerodex_flag = 'N',";
						}

						if (check_prod_code[0].CheckState == CheckState.Checked)
						{
							Query = $"{Query}actop_product_business_flag = 'Y',";
						}
						else
						{
							Query = $"{Query}actop_product_business_flag = 'N',";
						}

						if (check_prod_code[1].CheckState == CheckState.Checked)
						{
							Query = $"{Query}actop_product_commercial_flag = 'Y',";
						}
						else
						{
							Query = $"{Query}actop_product_commercial_flag = 'N',";
						}

						if (check_prod_code[2].CheckState == CheckState.Checked)
						{
							Query = $"{Query}actop_product_helicopter_flag = 'Y',";
						}
						else
						{
							Query = $"{Query}actop_product_helicopter_flag = 'N',";
						}



					}

					Query = $"{Query}actop_reference_id = {RefTopic.ToString()} WHERE actop_id = {topicID.ToString()}";

					// UPDATE THE AIRCRAFT TOPIC RECORD
					DbCommand TempCommand_2 = null;
					TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
					TempCommand_2.CommandText = Query;
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
					TempCommand_2.ExecuteNonQuery();

					MessageBox.Show("Update Successfully Completed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));

					Is_Dirty = true;

				}
				else if (topicID > 0 && bIsDelete)
				{ 

					Query = $"DELETE FROM Aircraft_Topic  WHERE actop_id = {topicID.ToString()}";

					M = $"Aircraft Topic Type Delete For: {topicID.ToString().Trim()} : {acTopicItemName.Text.Trim()}{"\r"}{"\r"}";
					M = $"{M}Do you wish to perform the delete at this time?";

					RESP = MessageBox.Show(M, "Confirm Delete!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

					ParentQuery = "SELECT * FROM aircraft_topic WITH(NOLOCK) ";
					ParentQuery = $"{ParentQuery}WHERE actop_reference_id = {topicID.ToString()}";

					ParentRecord.Open(ParentQuery, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

					if (!(ParentRecord.BOF && ParentRecord.EOF))
					{
						bIsParentTopic = true;
					}

					ParentRecord.Close();
					ParentRecord = null;

					if (RESP == System.Windows.Forms.DialogResult.Yes && !bIsParentTopic)
					{
						DbCommand TempCommand_3 = null;
						TempCommand_3 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_3);
						TempCommand_3.CommandText = Query;
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_3);
						TempCommand_3.ExecuteNonQuery();
						Is_Dirty = true;
						MessageBox.Show("Delete Successfully Completed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					}
					else
					{
						MessageBox.Show($"Delete Cancelled!{Environment.NewLine}{Environment.NewLine}Can't delete parent topics", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					}

					Aircraft_Topic_List_By_Topic_Fill(acTopicAreaItem.Text.Trim());

					acTopicsPanel.Visible = false;
					acTopicAdd.Enabled = true;

				}

				if (!bIsDelete && (topicID > 0 || new_topic_id > 0))
				{

					// NOW CHECK TO SEE IF THIS TOPIC IS A PARENT TOPIC AND IF SO COPY ITS DATA TO OTHER REFERENCE TOPICS
					if (RefTopic == 0 && topicID > 0)
					{
						Query = $"UPDATE Aircraft_Topic SET actop_description = '{modAdminCommon.Fix_Quote(acTopicItemDescription).Trim()}',";
						Query = $"{Query}actop_area = '{modAdminCommon.Fix_Quote(acTopicAreaItem).Trim()}',";
						Query = $"{Query}actop_query = '{StringsHelper.Replace(acTopicItemQuery.Text, "'", "''", 1, -1, CompareMethod.Binary).Trim()}',";

						if (acTopicAerodexFlag.CheckState == CheckState.Checked)
						{
							Query = $"{Query}actop_aerodex_flag = 'Y' ";
						}
						else
						{
							Query = $"{Query}actop_aerodex_flag = 'N' ";
						}

						Query = $"{Query} WHERE actop_reference_id = {topicID.ToString()}";

						DbCommand TempCommand_4 = null;
						TempCommand_4 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_4);
						TempCommand_4.CommandText = Query;
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_4);
						TempCommand_4.ExecuteNonQuery();

					}

					// NOW CHECK IF I HAVE A REFERENCE TOPIC
					if (RefTopic > 0)
					{

						// GET THE DESCRIPTION, AREA, QUERY, AND AERODEX FLAG FROM PARENT AND STORE ON MY RECORD
						ParentQuery = "select * FROM aircraft_topic WITH(NOLOCK) ";
						ParentQuery = $"{ParentQuery}WHERE actop_id={RefTopic.ToString()}";

						ParentRecord.Open(ParentQuery, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

						if (!(ParentRecord.BOF && ParentRecord.EOF))
						{
							ParentQuery = $"UPDATE Aircraft_Topic SET  actop_description='{modAdminCommon.Fix_Quote(ParentRecord.GetField("actop_description")).Trim()}',";
							ParentQuery = $"{ParentQuery}actop_area='{modAdminCommon.Fix_Quote(ParentRecord.GetField("actop_area")).Trim()}',";
							ParentQuery = $"{ParentQuery}actop_query='{StringsHelper.Replace(Convert.ToString(ParentRecord["actop_query"]), "'", "''", 1, -1, CompareMethod.Binary).Trim()}',";

							if (Convert.ToString(ParentRecord["actop_aerodex_flag"]) == "Y")
							{
								ParentQuery = $"{ParentQuery}actop_aerodex_flag='Y' ";
							}
							else
							{
								ParentQuery = $"{ParentQuery}actop_aerodex_flag='N' ";
							}

							if (new_topic_id > 0)
							{
								ParentQuery = $"{ParentQuery} WHERE actop_id={new_topic_id.ToString()}";
							}
							else
							{
								ParentQuery = $"{ParentQuery} WHERE actop_id={topicID.ToString()}";
							}



							DbCommand TempCommand_5 = null;
							TempCommand_5 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_5);
							TempCommand_5.CommandText = ParentQuery;
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_5);
							TempCommand_5.ExecuteNonQuery();

						}

						ParentRecord.Close();
						ParentRecord = null;

					}

				}
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"Fill_Aircraft_Topic_Item_Error: {excep.Message}");

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1065
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
				return;
			}


		}

		private void Fill_Aircraft_Topic_Item(int topicID)
		{

			ADORecordSetHelper ado_acTopicQuery = default(ADORecordSetHelper);
			try
			{

				string Query = "";
				ado_acTopicQuery = new ADORecordSetHelper();

				ADORecordSetHelper RS_Table = new ADORecordSetHelper(); //Current recordset

				string sTopicArea = "";
				string sTopicName = "";
				string sTopicQuery = "";
				int nTopicParentID = 0;
				string bTopicAerodexFlag = "";
				string sTopicDescription = "";
				string bTopicProductFlag = "";

				if (topicID > 0)
				{

					Query = $"SELECT * from Aircraft_Topic WHERE actop_id = {topicID.ToString()}";

					ado_acTopicQuery.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

					if (!(ado_acTopicQuery.BOF && ado_acTopicQuery.EOF))
					{
						ado_acTopicQuery.MoveFirst();

						while(!ado_acTopicQuery.EOF)
						{

							acTopicIDLabel.Text = $"Topic ID : {topicID.ToString()}";
							ToolTipMain.SetToolTip(acTopicIDLabel, topicID.ToString());

							sTopicArea = ($"{Convert.ToString(ado_acTopicQuery["actop_area"])}").Trim();

							Fill_Topic_Area(acTopicAreaItem, sTopicArea);

							sTopicName = ($"{Convert.ToString(ado_acTopicQuery["actop_name"])}").Trim();

							nTopicParentID = Convert.ToInt32(Double.Parse($"{Convert.ToString(ado_acTopicQuery["actop_reference_id"])}"));

							Fill_Parent_Topic_Area(acTopicParentTopic, sTopicArea, topicID, nTopicParentID);

							sTopicQuery = ($"{Convert.ToString(ado_acTopicQuery["actop_query"])}").Trim();

							if (nTopicParentID > 0)
							{
								acTopicItemQuery.Enabled = false;
								acTopicItemDescription.Enabled = false;
								acTopicAerodexFlag.Enabled = false;
							}
							else
							{
								acTopicItemQuery.Enabled = true;
								acTopicItemDescription.Enabled = true;
								acTopicAerodexFlag.Enabled = true;
								// ONLY ENABLE FOR MVINTECH AND DAVID
								acTopicItemQuery.Enabled = modAdminCommon.gbl_User_ID.ToUpper() == "MVIT" || modAdminCommon.gbl_User_ID.ToUpper() == "DCR";
							}


							sTopicDescription = ($"{Convert.ToString(ado_acTopicQuery["actop_description"])}").Trim();

							bTopicAerodexFlag = ($"{Convert.ToString(ado_acTopicQuery["actop_aerodex_flag"])}").Trim();

							acTopicAerodexFlag.CheckState = (bTopicAerodexFlag == "Y") ? CheckState.Checked : CheckState.Unchecked;

							bTopicProductFlag = ($"{Convert.ToString(ado_acTopicQuery["actop_product_business_flag"])}").Trim();
							check_prod_code[0].CheckState = (bTopicProductFlag == "Y") ? CheckState.Checked : CheckState.Unchecked;

							bTopicProductFlag = ($"{Convert.ToString(ado_acTopicQuery["actop_product_commercial_flag"])}").Trim();
							check_prod_code[1].CheckState = (bTopicProductFlag == "Y") ? CheckState.Checked : CheckState.Unchecked;

							bTopicProductFlag = ($"{Convert.ToString(ado_acTopicQuery["actop_product_helicopter_flag"])}").Trim();
							check_prod_code[2].CheckState = (bTopicProductFlag == "Y") ? CheckState.Checked : CheckState.Unchecked;


							ado_acTopicQuery.MoveNext();

						};

					}

					acTopicItemName.Text = "";
					acTopicItemDescription.Text = "";
					acTopicItemQuery.Text = "";

					acTopicItemName.Text = sTopicName;
					acTopicItemDescription.Text = sTopicDescription;
					acTopicItemQuery.Text = sTopicQuery;

				}
				else
				{

					acTopicIDLabel.Text = "Topic ID : New Topic";
					ToolTipMain.SetToolTip(acTopicIDLabel, "0");

					Fill_Topic_Area(acTopicAreaItem);
					Fill_Parent_Topic_Area(acTopicParentTopic);

					acTopicItemName.Text = "";
					acTopicItemDescription.Text = "";
					acTopicItemQuery.Text = "";

					acTopicAerodexFlag.CheckState = CheckState.Unchecked;

				}

				// CLOSE RECORSET
				if (ado_acTopicQuery != null)
				{
					if (ado_acTopicQuery.State == ConnectionState.Open)
					{ // Already Open Close It
						ado_acTopicQuery.Close();
					}
					ado_acTopicQuery = null;
				}
			}
			catch (System.Exception excep)
			{

				// CLOSE RECORSET
				if (ado_acTopicQuery != null)
				{
					if (ado_acTopicQuery.State == ConnectionState.Open)
					{ // Already Open Close It
						ado_acTopicQuery.Close();
					}
					ado_acTopicQuery = null;
				}

				modAdminCommon.Report_Error($"Fill_Aircraft_Topic_Item_Error: {excep.Message}");

				this.Cursor = CursorHelper.CursorDefault;

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1065
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
				return;
			}

		}

		private void Fill_Topic_Aircraft_List()
		{

			ADORecordSetHelper ado_acTopicQuery = default(ADORecordSetHelper);
			try
			{

				string Query = "";
				ado_acTopicQuery = new ADORecordSetHelper();

				int RememberTimeout = 0;
				int nCounter = 0;
				nCounter = 0;

				this.Cursor = Cursors.WaitCursor;
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Selecting Aircraft List Based on Rules ...", Color.Blue);

				// ************************************************
				// SETUP THE FEATURE GRID
				acTopicAircraftList.Clear();
				acTopicAircraftList.ColumnsCount = 1;
				acTopicAircraftList.RowsCount = 1;

				acTopicAircraftList.CurrentRowIndex = 0;
				acTopicAircraftList.CurrentColumnIndex = 0;
				acTopicAircraftList.SetColumnWidth(0, 167);
				acTopicAircraftList.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
				acTopicAircraftList[acTopicAircraftList.CurrentRowIndex, acTopicAircraftList.CurrentColumnIndex].Value = "ACID";
				acTopicAircraftList.CellBackColor = acTopicAircraftList.BackColorFixed;

				RememberTimeout = UpgradeHelpers.DB.DbConnectionHelper.GetCommandTimeOut(modAdminCommon.LOCAL_ADO_DB);
				UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(modAdminCommon.LOCAL_ADO_DB, 1000);
				ado_acTopicQuery.Open(acTopicItemQuery.Text, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
				UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(modAdminCommon.LOCAL_ADO_DB, RememberTimeout);

				if (!(ado_acTopicQuery.BOF && ado_acTopicQuery.EOF))
				{

					while(!ado_acTopicQuery.EOF)
					{

						if (nCounter < 20)
						{
							acTopicAircraftList.RowsCount++;
							acTopicAircraftList.CurrentRowIndex++;

							acTopicAircraftList.CurrentColumnIndex = 0;
							acTopicAircraftList[acTopicAircraftList.CurrentRowIndex, acTopicAircraftList.CurrentColumnIndex].Value = ($" {Convert.ToString(ado_acTopicQuery["ACID"])}").Trim();
							acTopicAircraftList.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

						}
						else
						{

							if (nCounter == 20)
							{
								acTopicAircraftList.RowsCount++;
								acTopicAircraftList.CurrentRowIndex++;
								acTopicAircraftList.CurrentColumnIndex = 0;
								acTopicAircraftList.SetColumnWidth(0, 167);
								acTopicAircraftList[acTopicAircraftList.CurrentRowIndex, acTopicAircraftList.CurrentColumnIndex].Value = "showing first 20 aircraft found";
							}

						}

						nCounter++;

						ado_acTopicQuery.MoveNext();

					};

					acTopicAircraftListLabel.Text = $"{nCounter.ToString()} Aircraft Found";

				}
				else
				{
					acTopicAircraftList.RowsCount++;
					acTopicAircraftList.CurrentRowIndex++;
					acTopicAircraftList.CurrentColumnIndex = 0;
					acTopicAircraftList[acTopicAircraftList.CurrentRowIndex, acTopicAircraftList.CurrentColumnIndex].Value = "No Aircraft Found";

				}

				this.Cursor = CursorHelper.CursorDefault;
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);

				if (ado_acTopicQuery != null)
				{
					if (ado_acTopicQuery.State == ConnectionState.Open)
					{ // Already Open Close It
						ado_acTopicQuery.Close();
					}
					ado_acTopicQuery = null;
				}

				Application.DoEvents();
			}
			catch (System.Exception excep)
			{

				acTopicAircraftList.RowsCount++;
				acTopicAircraftList.CurrentRowIndex++;
				acTopicAircraftList.CurrentColumnIndex = 0;
				acTopicAircraftList[acTopicAircraftList.CurrentRowIndex, acTopicAircraftList.CurrentColumnIndex].Value = "Unable to select Aircraft";

				if (ado_acTopicQuery != null)
				{
					if (ado_acTopicQuery.State == ConnectionState.Open)
					{ // Already Open Close It
						ado_acTopicQuery.Close();
					}
					ado_acTopicQuery = null;
				}

				this.Cursor = CursorHelper.CursorDefault;
				modAdminCommon.Report_Error($"Fill_Topic_Aircraft_List: {excep.Message}");

				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);

				return;
			}

		}

		private void Aircraft_Topic_List_By_Topic_Fill(string sTopic)
		{

			string Query = ""; //Current query sql
			ADORecordSetHelper RS_Table = new ADORecordSetHelper(); //Current recordset
			int nRow = 0; //Current row counter
            DataGridViewFlex Grd = null;
			string RowColor = "";

			int x = 0;

			acTopicsPanel.Visible = false;

			try
			{

				this.Cursor = Cursors.WaitCursor;
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Selecting Aircraft Topics ...", Color.Blue);

				Fill_Topic_Area(acTopicArea, sTopic);

				Grd = acTopicsGrid;

				//UPGRADE_TODO: (1067) Member Clear is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				Grd.Clear();
				//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				Grd.Row = 0;
				//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				Grd.Col = 0;
				Grd.Text = "Code";
				//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				Grd.Col = 1;
				Grd.Text = "Name";
				//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				Grd.ColWidth[0] = 800;
				//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				Grd.ColWidth[1] = 4200;
				//UPGRADE_TODO: (1067) Member CellAlignment is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				Grd.CellAlignment = DataGridViewContentAlignment.TopLeft;
                //UPGRADE_TODO: (1067) Member ColAlignment is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
                Grd.ColAlignment[0] = DataGridViewContentAlignment.TopLeft;
                //UPGRADE_TODO: (1067) Member ColAlignment is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
                Grd.ColAlignment[1] = DataGridViewContentAlignment.TopLeft;
                nRow = 1;
				//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				Grd.Row = nRow;

				Query = "SELECT * from Aircraft_Topic ";

				if ((sTopic.Trim() != "") && (sTopic.Trim() != "All"))
				{
					Query = $"{Query}WHERE actop_area = '{sTopic.Trim()}'";
				}

				Query = $"{Query} ORDER BY actop_name ";

				RS_Table.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);
				if (!(RS_Table.BOF && RS_Table.EOF))
				{
					RS_Table.MoveFirst();

					while(!RS_Table.EOF)
					{

						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						Grd.Col = 0;
						RowColor = "&H80000005";

						if (($"{Convert.ToString(RS_Table["actop_description"])}").Trim() == "")
						{
							// MARK THOSE THAT HAVE NO DESCRIPTION AS PINK
							RowColor = "&H8080FF";
						}
						if (Convert.ToInt32(RS_Table["actop_reference_id"]) > 0)
						{
							// MARK THOSE ROWS THAT ARE REFERENCE TOPICS WITH GRAY
							RowColor = "&H8000000B";
						}

						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						Grd.Col = 0;
                        //UPGRADE_TODO: (1067) Member CellBackColor is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
                        Grd.CellBackColor = Color.FromName(RowColor);
                        Grd.Text = ($"{Convert.ToString(RS_Table["actop_id"])}").Trim();

						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						Grd.Col = 1;
                        //UPGRADE_TODO: (1067) Member CellBackColor is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
                        Grd.CellBackColor = Color.FromName(RowColor);
                        Grd.Text = ($"{Convert.ToString(RS_Table["actop_name"])}").Trim();

						nRow++;
						//UPGRADE_TODO: (1067) Member Rows is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						Grd.RowCount = nRow + 1;//gap-note Grd.Rows was changed to GrdRow.RowCount
						//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						Grd.Row = nRow;

						RS_Table.MoveNext();
					};
				}

                //UPGRADE_TODO: (1067) Member Rows is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
                Grd.RowCount = nRow + 1;//gap-note Grd.Rows was changed to GrdRow.RowCount
                Grd.Refresh();

				// CLOSE RECORSET
				if (RS_Table != null)
				{
					if (RS_Table.State == ConnectionState.Open)
					{ // Already Open Close It
						RS_Table.Close();
					}
					RS_Table = null;
				}

				this.Cursor = CursorHelper.CursorDefault;
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);

				Application.DoEvents();
			}
			catch (System.Exception excep)
			{

				//UPGRADE_TODO: (1067) Member Rows is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				Grd.RowCount = nRow + 1;//gap-note Grd.Rows was changed to GrdRow.RowCount
				//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				Grd.Row = Grd.Row + 1;
				//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				Grd.Col = 0;
				Grd.Text = "No Topics for this area";

				if (RS_Table != null)
				{
					if (RS_Table.State == ConnectionState.Open)
					{ // Already Open Close It
						RS_Table.Close();
					}
					RS_Table = null;
				}

				this.Cursor = CursorHelper.CursorDefault;
				modAdminCommon.Report_Error($"Aircraft_Topic_List_By_Topic_Fill_Error: {excep.Message}");

				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1065
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
				return;
			}

		}

		private void AircraftContactTypeFill()
		{
			//aey 4/28/2004  fill function split out from Aircraft_Contact_Type
			// needed to call from tab change event

			string Separator = "";
			ADORecordSetHelper snp_aircraft_contact_type = new ADORecordSetHelper();

			pnl_ACTypeMain.Visible = false;
			pnl_Aircraft_Contact_Type_AddUpdate.Visible = false;
			Application.DoEvents();

            DataGridViewFlex Grd = FGRD_AircraftContactType;
			//UPGRADE_TODO: (1067) Member Clear is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			Grd.Clear();

			string Query = "SELECT * from Aircraft_Contact_Type ";
			if (cboShow.Text.Trim() != "All")
			{

				Query = $"{Query}WHERE ";

				switch(cboShow.Text.Trim())
				{
					case "Aircraft Relationships" : 
						 
						Query = $"{Query}{Separator}actype_acref_flag = 'Y'"; 
						 
						break;
					case "Company Relationships" : 
						 
						Query = $"{Query}{Separator}actype_compref_flag = 'Y'"; 
						 
						break;
					case "Transaction Relationships" : 
						Query = $"{Query}{Separator}actype_transref_flag = 'Y'"; 
						 
						break;
					case "Fractional Share Relationships" : 
						Query = $"{Query}{Separator}actype_shareref_flag = 'Y'"; 
						 
						break;
				}
			}

			Query = $"{Query} ORDER BY actype_code ";

			//Set snp_aircraft_contact_type = LOCAL_DB.OpenRecordset(QUERY, dbOpenSnapshot)
			snp_aircraft_contact_type.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);
			//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			Grd.Row = 0;
			//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			Grd.Col = 0;
			Grd.Text = "Code"; //actype_code
			//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			Grd.Col = 1;
			Grd.Text = "Name"; //actype_name
			//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			Grd.Col = 2;
			Grd.Text = "Secnd Name"; //actype_compref_name2
			//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			Grd.Col = 3;
			Grd.Text = "2Way"; //actype_compref_twoway_flag
			//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			Grd.Col = 4;
			Grd.Text = "AC/Cmp"; //actype_acref_flag
			//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			Grd.Col = 5;
			Grd.Text = "Cmp/Cmp"; //actype_compref_flag
			//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			Grd.Col = 6;
			Grd.Text = "Tran"; //actype_transref_flag
			//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			Grd.Col = 7;
			Grd.Text = "Share"; //actype_shareref_flag
			//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			Grd.Col = 8;
			Grd.Text = "Intr"; //actype_compref_internal_flag
			//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			Grd.Col = 9;
			Grd.Text = "Abbv"; //actype_abbrev
			//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			Grd.Col = 10;
			Grd.Text = "Use"; //actype_use_flag
			//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			Grd.Col = 11;
			Grd.Text = "NCode"; //actype_name_code
			//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			Grd.Col = 12;
			Grd.Text = "N2Code"; //actype_compref_name2_code
			//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			Grd.ColWidth[0] = 500;
			//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			Grd.ColWidth[1] = 2500;
			//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			Grd.ColWidth[2] = 1300;
			//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			Grd.ColWidth[3] = 500;
			//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			Grd.ColWidth[4] = 600;
			//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			Grd.ColWidth[5] = 600;
			//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			Grd.ColWidth[6] = 600;
			//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			Grd.ColWidth[7] = 600;
			//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			Grd.ColWidth[8] = 600;
			//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			Grd.ColWidth[9] = 700;
			//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			Grd.ColWidth[10] = 600;
			//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			Grd.ColWidth[11] = 0;
			//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			Grd.ColWidth[12] = 0;

			int nRow = 1;
			//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			Grd.Row = nRow;
			if (!(snp_aircraft_contact_type.BOF && snp_aircraft_contact_type.EOF))
			{
				snp_aircraft_contact_type.MoveFirst();

				while(!snp_aircraft_contact_type.EOF)
				{
					//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					Grd.Col = 0;
					Grd.Text = Convert.ToString(snp_aircraft_contact_type["actype_code"]).Trim();
					if (($"{Convert.ToString(snp_aircraft_contact_type["actype_compref_twoway_flag"])} ").Trim() == "Y" && (modAdminCommon.Fix_Quote(snp_aircraft_contact_type.GetField("actype_name")).Trim() != modAdminCommon.Fix_Quote(snp_aircraft_contact_type.GetField("actype_compref_name2")).Trim()))
					{
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						Grd.Col = 1;
						Grd.Text = modAdminCommon.Fix_Quote(snp_aircraft_contact_type.GetField("actype_name")).Trim();
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						Grd.Col = 2;
						Grd.Text = modAdminCommon.Fix_Quote(snp_aircraft_contact_type.GetField("actype_compref_name2")).Trim();
					}
					else
					{
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						Grd.Col = 1;
						Grd.Text = modAdminCommon.Fix_Quote(snp_aircraft_contact_type.GetField("actype_name")).Trim();
					}
					//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					Grd.Col = 3;
					Grd.Text = ($"{Convert.ToString(snp_aircraft_contact_type["actype_compref_twoway_flag"])} ").Trim();
					//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					Grd.Col = 4;
					Grd.Text = ($"{Convert.ToString(snp_aircraft_contact_type["actype_acref_flag"])}").Trim();
					//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					Grd.Col = 5;
					Grd.Text = ($"{Convert.ToString(snp_aircraft_contact_type["actype_compref_flag"])}").Trim();
					//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					Grd.Col = 6;
					Grd.Text = ($"{Convert.ToString(snp_aircraft_contact_type["actype_transref_flag"])}").Trim();
					//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					Grd.Col = 7;
					Grd.Text = ($"{Convert.ToString(snp_aircraft_contact_type["actype_shareref_flag"])}").Trim();
					//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					Grd.Col = 8;
					Grd.Text = ($"{Convert.ToString(snp_aircraft_contact_type["actype_compref_internal_flag"])}").Trim();
					//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					Grd.Col = 9;
					Grd.Text = ($"{Convert.ToString(snp_aircraft_contact_type["actype_abbrev"])}").Trim();
					//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					Grd.Col = 10;
					Grd.Text = ($"{Convert.ToString(snp_aircraft_contact_type["actype_use_flag"])}").Trim();
					//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					Grd.Col = 11;
					Grd.Text = ($"{Convert.ToString(snp_aircraft_contact_type["actype_name_code"])}").Trim();
					//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					Grd.Col = 12;
					Grd.Text = ($"{Convert.ToString(snp_aircraft_contact_type["actype_compref_name2_code"])}").Trim();
					nRow++;
					//UPGRADE_TODO: (1067) Member Rows is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					Grd.RowCount = nRow + 1;//gap-note Grd.Rows was changed to GrdRow.RowCount
					//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					Grd.Row = nRow;
					snp_aircraft_contact_type.MoveNext();
				};
			}
			snp_aircraft_contact_type.Close();
            //UPGRADE_TODO: (1067) Member Rows is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
            Grd.RowCount = nRow + 1;//gap-note Grd.Rows was changed to GrdRow.RowCount
            Grd.Refresh();

		}

		private string CheckForAircraftLocksByAirportId(int lAPortId)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			string Separator = "";
			StringBuilder LockUsers = new StringBuilder();

			try
			{

				Separator = "";
				LockUsers = new StringBuilder("");

				strQuery1 = "SELECT DISTINCT alock_user_id, user_first_name, user_last_name ";
				strQuery1 = $"{strQuery1}FROM Aircraft WITH (NOLOCK) INNER JOIN Aircraft_Lock WITH (NOLOCK) ON ac_id = alock_ac_id AND ac_journ_id = alock_journ_id ";
				strQuery1 = $"{strQuery1}INNER JOIN [User] WITH (NOLOCK) ON alock_user_id = user_id ";
				strQuery1 = $"{strQuery1}WHERE (ac_journ_id = 0)  AND (ac_aport_id = {lAPortId.ToString()}) ";

				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					do 
					{ // Loop Until rstRec1.EOF=True

						LockUsers.Append($"{Separator}{($"{Convert.ToString(rstRec1["user_first_name"])}").Trim()} {($"{Convert.ToString(rstRec1["user_last_name"])}").Trim()}");
						Separator = ", ";

						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If (rstRec1.BOF = False And rstRec1.EOF = False) Then

				rstRec1.Close();
				rstRec1 = null;


				return LockUsers.ToString();
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"CheckForAircraftLocksByAirportId_Error: {lAPortId.ToString()} - {excep.Message}");
				this.Cursor = CursorHelper.CursorDefault;
			}
			return "";
		} // CheckForAircraftLocksByAirportId

		private void Fill_Country(ComboBox inCbo, string InCountry = "")
		{
			// fill combo box for county selection

			string Query = "";
			int I = 0;
			int RememberI = 0;
			ADORecordSetHelper snp_airport_country = new ADORecordSetHelper();

			try
			{

				Query = "SELECT * from Country  ORDER BY Country_name ";

				snp_airport_country.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

				if (!snp_airport_country.BOF && !snp_airport_country.EOF)
				{

					inCbo.Enabled = false;
					inCbo.Items.Clear();
					inCbo.SelectedIndex = -1;
					inCbo.AddItem("");
					I = 0;

					do 
					{ // Loop Until snp_airport_country.EOF = True

						I++;
						inCbo.AddItem(($"{Convert.ToString(snp_airport_country["country_name"])} ").Trim());

						if (($"{Convert.ToString(snp_airport_country["country_name"])} ").Trim() == InCountry)
						{
							RememberI = I;
						}

						snp_airport_country.MoveNext();

					}
					while(!snp_airport_country.EOF);

					if (RememberI >= 0)
					{
						inCbo.SelectedIndex = RememberI;
					}

					inCbo.Enabled = true;

				} // If (snp_airport_country.BOF = False And snp_airport_country.EOF = False) Then

				snp_airport_country.Close();
				snp_airport_country = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"Fill_Country_Error: {excep.Message}");
			}

		}

		private void Format_Latitude_Longitude_Values_Decimal_Or_Dir_Degree_Minute_Second()
		{





			txtAirport[5].Text = txtAirport[5].Text.ToUpper(); // Latitude Full
			txtAirport[10].Text = txtAirport[10].Text.ToUpper(); // Longitude Full

			double dLatDecimal = 0d;
			double dLongDecimal = 0d;

			string strLatFull = "";
			string strLatDir = "";
			int lLatDegree = 0;
			int lLatMinute = 0;
			int lLatSecond = 0;

			string strLongFull = "";
			string strLongDir = "";
			int lLongDegree = 0;
			int lLongMinute = 0;
			int lLongSecond = 0;

			bool bDecimal = false;
			if (txtAirport[iLAT_INDEX].Text != "" && txtAirport[iLONG_INDEX].Text != "")
			{
				if (Information.IsNumeric(txtAirport[iLAT_INDEX].Text) && Information.IsNumeric(txtAirport[iLONG_INDEX].Text))
				{
					if (Double.Parse(txtAirport[iLAT_INDEX].Text) != 0 && Double.Parse(txtAirport[iLONG_INDEX].Text) != 0)
					{
						bDecimal = true;
					}
				}
			}

			if (bDecimal)
			{

				dLatDecimal = Double.Parse(txtAirport[iLAT_INDEX].Text);
				dLongDecimal = Double.Parse(txtAirport[iLONG_INDEX].Text);

				modAdminCommon.Convert_Decimal_To_Dir_Degree_Minute_Seconds(dLatDecimal, dLongDecimal, ref strLatFull, ref strLatDir, ref lLatDegree, ref lLatMinute, ref lLatSecond, ref strLongFull, ref strLongDir, ref lLongDegree, ref lLongMinute, ref lLongSecond);

				txtAirport[4].Text = "";
				txtAirport[5].Text = strLatDir;
				txtAirport[6].Text = lLatDegree.ToString();
				txtAirport[7].Text = lLatMinute.ToString();
				txtAirport[8].Text = lLatSecond.ToString();

				txtAirport[4].Text = "";
				txtAirport[10].Text = strLongDir;
				txtAirport[11].Text = lLongDegree.ToString();
				txtAirport[12].Text = lLongMinute.ToString();
				txtAirport[13].Text = lLongSecond.ToString();

			}
			else
			{

				strLatFull = txtAirport[4].Text;
				strLatDir = txtAirport[5].Text;
				if (Information.IsNumeric(txtAirport[6].Text))
				{
					lLatDegree = Convert.ToInt32(Double.Parse(txtAirport[6].Text));
				}
				if (Information.IsNumeric(txtAirport[7].Text))
				{
					lLatMinute = Convert.ToInt32(Double.Parse(txtAirport[7].Text));
				}
				if (Information.IsNumeric(txtAirport[8].Text))
				{
					lLatSecond = Convert.ToInt32(Double.Parse(txtAirport[8].Text));
				}

				strLongFull = txtAirport[9].Text;
				strLongDir = txtAirport[10].Text;
				if (Information.IsNumeric(txtAirport[11].Text))
				{
					lLongDegree = Convert.ToInt32(Double.Parse(txtAirport[11].Text));
				}
				if (Information.IsNumeric(txtAirport[12].Text))
				{
					lLongMinute = Convert.ToInt32(Double.Parse(txtAirport[12].Text));
				}
				if (Information.IsNumeric(txtAirport[13].Text))
				{
					lLongSecond = Convert.ToInt32(Double.Parse(txtAirport[13].Text));
				}

				if (strLatDir != "" && lLatDegree != 0 && lLatMinute != 0 && lLatSecond != 0 && strLongDir != "" && lLongDegree != 0 && lLongMinute != 0 && lLongSecond != 0)
				{

					modAdminCommon.Convert_Dir_Degree_Minute_Seconds_To_Decimal(ref dLatDecimal, ref dLongDecimal, strLatFull, strLatDir, lLatDegree, lLatMinute, lLatSecond, strLongFull, strLongDir, lLongDegree, lLongMinute, lLongSecond);

					txtAirport[iLAT_INDEX].Text = StringsHelper.Format(dLatDecimal, "#0.00000000");
					txtAirport[iLONG_INDEX].Text = StringsHelper.Format(dLongDecimal, "#0.00000000");

				} // If strLatDir <> "" And lLatDegree <> 0 And lLatMinute <> 0 And lLatSecond <> 0 And ...etc

			} // If (txtAirport(iLAT_INDEX ).Text <> "" And CLng(txtAirport(iLAT_INDEX ).Text) <> 0) And (txtAirport(iLONG_INDEX).Text <> "" And CLng(txtAirport(iLONG_INDEX).Text) <> 0) Then

			// Build Latitude Full
			string strTemp = txtAirport[4].Text;
			modAdminCommon.BuildLatLongFull(ref strTemp, txtAirport[5].Text, txtAirport[6].Text, txtAirport[7].Text, txtAirport[8].Text);
			txtAirport[4].Text = strTemp;

			// Build Longtitude Full
			strTemp = txtAirport[9].Text;
			modAdminCommon.BuildLatLongFull(ref strTemp, txtAirport[10].Text, txtAirport[11].Text, txtAirport[12].Text, txtAirport[13].Text);
			txtAirport[9].Text = strTemp;

		} // Format_Latitude_Longitude_Values_Decimal_Or_Dir_Degree_Minute_Second

		public void Update_AC_Models_Attached(int engine_id)
		{


			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strUpdate1 = "";

			if (engine_id > 0)
			{

				strQuery1 = $" SELECT distinct ameng_amod_id FROM Aircraft_Model_Engine where ameng_engine_model_id = {engine_id.ToString()}";

				rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					do 
					{ //Loop Until snpAC.EOF = True

						Update_Aircraft_Model_Record_With_Aircraft_Model_Engine_Lowest_Seq(Convert.ToInt32(rstRec1["ameng_amod_id"]), engine_id);

						rstRec1.MoveNext();
					}
					while(!rstRec1.EOF);

				} // If rstRec1.BOF = False And rstRec1.EOF = False Then

				rstRec1.Close();

			} // If lAModId > 0 Then


		}


		public void Update_Aircraft_TBO_Hours(int engine_id, int engine_old_tbo_hours, int engine_new_tbo_hours)
		{


			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			StringBuilder strUpdate1 = new StringBuilder();
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

				for (int I = 1; I <= 4; I++)
				{

					ac_id_list = new StringBuilder("");
					total_count = 0;

					strQuery1 = "SELECT distinct ac_id FROM Aircraft_Model_Engine inner join aircraft with (NOLOCK) on ac_amod_id = ameng_amod_id and ac_journ_id = 0 ";
					strQuery1 = $"{strQuery1} inner join Aircraft_Model with (NOLOCK) on ac_amod_id = amod_id ";
					strQuery1 = $"{strQuery1} where ameng_engine_model_id = {engine_id.ToString()}";

					if (where_Addition.Trim() != "")
					{
						strQuery1 = $"{strQuery1}{where_Addition}";
					}

					// added in to make sure the serial number isnt blank
					strQuery1 = $"{strQuery1} and (ac_engine_{I.ToString()}_tbo_hrs = '{engine_old_tbo_hours.ToString()}' or ((ac_engine_{I.ToString()}_tbo_hrs = '0' or ac_engine_{I.ToString()}_tbo_hrs IS NULL)  and amod_number_of_engines >= {I.ToString()}) ) ";

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


					if (ac_id_list.ToString().Trim() != "")
					{
						// update all of these AC
						strUpdate1 = new StringBuilder($"UPDATE Aircraft SET ac_engine_{I.ToString()}_tbo_hrs = {engine_new_tbo_hours.ToString()}  ");
						strUpdate1.Append($"WHERE ac_id in ({ac_id_list.ToString()}) and ac_journ_id = 0  ");
						strUpdate1.Append($" and (ac_engine_{I.ToString()}_tbo_hrs = '{engine_old_tbo_hours.ToString()}'  or ((ac_engine_{I.ToString()}_tbo_hrs = '0' or ac_engine_{I.ToString()}_tbo_hrs IS NULL)) ) ");
						strUpdate1.Append(where_Addition);

						DbCommand TempCommand = null;
						TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
						TempCommand.CommandText = strUpdate1.ToString();
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
						TempCommand.ExecuteNonQuery();

						if (where_Addition.Trim() != "")
						{ // if there is a where clause, its only off market
							modMyAdmin.Record_EventAdmin("Aircraft TBO Hours Change", $"Aircraft TBO Hours Changed: Off Market Aircraft: From {engine_old_tbo_hours.ToString().Trim()} to {engine_new_tbo_hours.ToString().Trim()}, Engine {I.ToString()}, Total Count: {total_count.ToString()}");
						}
						else
						{
							modMyAdmin.Record_EventAdmin("Aircraft TBO Hours Change", $"Aircraft TBO Hours Changed: All Aircraft: From {engine_old_tbo_hours.ToString().Trim()} to {engine_new_tbo_hours.ToString().Trim()}, Engine {I.ToString()}, Total Count: {total_count.ToString()}");
						}
					}


				}




			} // If lAModId > 0 Then


		}

		public void Update_Aircraft_Model_Record_With_Aircraft_Model_Engine_Lowest_Seq(int lAModId, int engine_id)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strUpdate1 = "";

			if (lAModId > 0)
			{

				strQuery1 = "SELECT TOP 1 EM1.* FROM Aircraft_Model_Engine AS AME1 WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}INNER JOIN Engine_Models AS EM1 WITH (NOLOCK) ON EM1.em_id = AME1.ameng_engine_model_id ";
				strQuery1 = $"{strQuery1}WHERE (AME1.ameng_amod_id = {lAModId.ToString()}) ";
				strQuery1 = $"{strQuery1} and EM1.em_id = {engine_id.ToString()}";
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

		private bool UpdateAllAircraftAirports(int lAPortId, string strIATAOld, string strICAOOld, string strFAAIDOld, string strIATANew, string strICAONew, string strFAAIDNew, string strAPortName, string strAPortCity, string strAPortState, string strAPortCountry, bool bClear)
		{
			bool result = false;
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strUpdate1 = "";

			string LockUsers = "";
			string[] arrTransmit = new string[]{"", "", "", "", ""};
			string strErrDesc = "";
			bool bTrans = false;

			try
			{

				result = false;

				if (strIATAOld != "" || strICAOOld != "")
				{

					arrTransmit[1] = "ac_aport_code";
					arrTransmit[2] = "ac_aport_name";
					arrTransmit[3] = "ac_aport_state";

					LockUsers = CheckForAircraftLocksByAirportId(lAPortId);

					if (LockUsers.Trim() != "")
					{
						if (bClear)
						{
							MessageBox.Show($"The Following Users Have Aircraft Records Locked:{Environment.NewLine}{LockUsers}{Environment.NewLine}{Environment.NewLine}You cannot delete at this time.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						}
						else
						{
							MessageBox.Show($"The Following Users Have Aircraft Records Locked:{Environment.NewLine}{LockUsers}{Environment.NewLine}{Environment.NewLine}You cannot update at this time.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						}

						return false;

					}

					strQuery1 = "SELECT ac_id, ac_ser_no_full, ac_amod_id, ac_journ_id, ac_product_business_flag ";
					strQuery1 = $"{strQuery1}FROM Aircraft WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1}WHERE (ac_journ_id = 0) AND (ac_aport_id = {lAPortId.ToString()}) ";

					rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						rstRec1.ActiveConnection = null; // Disconnected

						modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Changing Airports...", Color.Blue);

						strUpdate1 = "UPDATE Aircraft ";
						if (bClear)
						{
							strUpdate1 = $"{strUpdate1}SET ac_aport_id = 0,  ac_aport_iata_code = '', ";
							strUpdate1 = $"{strUpdate1}ac_aport_icao_code = '', ac_aport_faaid_code = '', ";
							strUpdate1 = $"{strUpdate1}ac_aport_name = '', ac_aport_city = '', ";
							strUpdate1 = $"{strUpdate1}ac_aport_state = '',  ac_aport_country = '', ";
						}
						else
						{
							strUpdate1 = $"{strUpdate1}SET ac_aport_id = {lAPortId.ToString()}, ac_aport_iata_code = '{strIATANew}', ";
							strUpdate1 = $"{strUpdate1}ac_aport_icao_code = '{strICAONew}',  ac_aport_faaid_code = '{strFAAIDNew}', ";
							strUpdate1 = $"{strUpdate1}ac_aport_name = '{modAdminCommon.Fix_Quote(strAPortName)}', ac_aport_city = '{modAdminCommon.Fix_Quote(strAPortCity)}', ";
							if (strAPortState == "Not Found" || strAPortState == "")
							{
								strUpdate1 = $"{strUpdate1}ac_aport_state = '', ";
							}
							else
							{
								strUpdate1 = $"{strUpdate1}ac_aport_state = '{modAdminCommon.Fix_Quote(strAPortState)}', ";
							}
							strUpdate1 = $"{strUpdate1}ac_aport_country = '{modAdminCommon.Fix_Quote(strAPortCountry)}', ";
						} // If bClear = True Then

						strUpdate1 = $"{strUpdate1}ac_action_date = NULL WHERE (ac_journ_id = 0) ";
						strUpdate1 = $"{strUpdate1}AND (ac_aport_id = {lAPortId.ToString()}) ";

						bTrans = true;
						UpgradeHelpers.DB.TransactionManager.Enlist(modAdminCommon.LOCAL_ADO_DB.BeginTransaction());
						DbCommand TempCommand = null;
						TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
						TempCommand.CommandText = strUpdate1;
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
						TempCommand.ExecuteNonQuery();
						UpgradeHelpers.DB.TransactionManager.Commit(modAdminCommon.LOCAL_ADO_DB);
						bTrans = false;

						do 
						{ //Loop Until snpAC.EOF = True

							if (Convert.ToString(rstRec1["ac_product_business_flag"]) == "Y")
							{

								if (chkAirportListOptions[APortTransmitAC].CheckState == CheckState.Checked)
								{

									modStatusBar.Update_Status_Bar(modAdminCommon.SB, $"Writing Transmit For Aircraft: {($"{Convert.ToString(rstRec1["ac_id"])}").Trim()}", Color.Blue);

									if (StringsHelper.ToDoubleSafe(($"{Convert.ToString(rstRec1["ac_journ_id"])} ").Trim()) == 0)
									{
										modAdminCommon.Record_Transmit(($"{Convert.ToString(rstRec1["ac_ser_no_full"])} ").Trim(), Convert.ToInt32(rstRec1["ac_id"]), Convert.ToInt32(rstRec1["ac_journ_id"]), Convert.ToInt32(rstRec1["ac_amod_id"]), "Aircraft", "Change", ref arrTransmit);
									}
									else
									{
										//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
										if (!Convert.IsDBNull(rstRec1["journ_pcreckey"]))
										{
											if (Convert.ToDouble(rstRec1["journ_pcreckey"]) > 0)
											{
												modAdminCommon.Record_Transmit(($"{Convert.ToString(rstRec1["ac_ser_no_full"])} ").Trim(), Convert.ToInt32(rstRec1["ac_id"]), Convert.ToInt32(rstRec1["ac_journ_id"]), Convert.ToInt32(rstRec1["ac_amod_id"]), "Transaction", "Change", ref arrTransmit);
											}
										}
									}

								} // If chkAirportListOptions(APortTransmitAC).Value = vbChecked Then

							} // If snpAC!ac_product_business_flag = "Y" Then

							rstRec1.MoveNext();
							Application.DoEvents();

						}
						while(!rstRec1.EOF);

						modStatusBar.Clear_Status_Bar(modAdminCommon.SB);

					} // If (snpAC.BOF=False And snpAC.EOF=False) Then

					rstRec1.Close();

				} // If strIATAOld <> "" Or strICAOOld <> "" Then

				rstRec1 = null;


				return true;
			}
			catch (System.Exception excep)
			{

				strErrDesc = excep.Message;

				if (bTrans)
				{
					UpgradeHelpers.DB.TransactionManager.Rollback(modAdminCommon.LOCAL_ADO_DB);
				}

				modAdminCommon.Report_Error($"UpdateAllAircraftAirports_Error: {strErrDesc}");

				result = false;
			}
			return result;
		} // UpdateAllAircraftAirports


		private bool Key_Feature_Ok_to_Inactivate()
		{
			//

			bool result = false;
			string Query = "";
			ADORecordSetHelper snpKey = new ADORecordSetHelper(); //8/26/05 aey

			result = true;

			if (chk_Inactive_Feature_Code.CheckState == CheckState.Checked && KeyFeatureWasActive)
			{
				Query = "SELECT count(*) as KeyCount FROM Aircraft_Key_Feature ";
				Query = $"{Query}WHERE afeat_journ_id = 0  AND afeat_feature_code = '{txt_kfeat_code.Text.Trim()}'";

				snpKey.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpKey.BOF && snpKey.EOF))
				{
					if (Convert.ToDouble(snpKey["KeyCount"]) > 0)
					{
						if (MessageBox.Show($"Feature Code {txt_kfeat_code.Text.Trim()} is used on {Convert.ToString(snpKey["KeyCount"])} aircraft.{Environment.NewLine}{Environment.NewLine}Are you sure you want to make this feature code inactive?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
						{
							result = false;
						}
					}
					snpKey.Close();
				}

			}


			return result;
		}

		private void acTopicAdd_Click(Object eventSender, EventArgs eventArgs)
		{
			Fill_Aircraft_Topic_Item(0);
			acTopicsPanel.Visible = true;
			acTopicAdd.Enabled = false;
		}

		private void acTopicArea_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs)
		{

			if (($"{acTopicArea.Text}").Trim() != "" && acTopicArea.Enabled)
			{
				Aircraft_Topic_List_By_Topic_Fill(acTopicArea.Text);
			}

		}

		private void acTopicCancel_Click(Object eventSender, EventArgs eventArgs)
		{

			acTopicsPanel.Visible = false;
			acTopicAdd.Enabled = true;

		}

		private void acTopicDelete_Click(Object eventSender, EventArgs eventArgs)
		{


			string temp_text = acTopicArea.Text;


			Insert_Update_Aircraft_Topic_item(Convert.ToInt32(Double.Parse(ToolTipMain.GetToolTip(acTopicIDLabel))), true);

			Aircraft_Topic_List_By_Topic_Fill(temp_text);
			acTopicAdd.Enabled = true;


		}

		//UPGRADE_NOTE: (7001) The following declaration (acTopicQueryTestLabel_Click) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void acTopicQueryTestLabel_Click()
		//{
			//
			//if (($"{acTopicItemQuery.Text}").Trim() != "")
			//{
				//acTopicsAircraftFrame.Visible = true;
				//acTopicsGrid.Visible = false;
				//acTopicArea.Visible = false;
				//Fill_Topic_Aircraft_List();
			//}
			//
		//}

		private void acTopicSave_Click(Object eventSender, EventArgs eventArgs)
		{

			string temp_text = acTopicArea.Text;

			Insert_Update_Aircraft_Topic_item(Convert.ToInt32(Double.Parse(ToolTipMain.GetToolTip(acTopicIDLabel))), false);

			Aircraft_Topic_List_By_Topic_Fill(temp_text);
			acTopicAdd.Enabled = true;

		}

		private void acTopicsGrid_Click(Object eventSender, EventArgs eventArgs)
		{

			acTopicAdd.Enabled = false;

			acTopicsPanel.Visible = true;

			acTopicsGrid.CurrentColumnIndex = 0;
			acTopicsGrid.ColSel = 0;
			acTopicsGrid.RowSel = acTopicsGrid.CurrentRowIndex;

			Fill_Aircraft_Topic_Item(Convert.ToInt32(Double.Parse(acTopicsGrid[acTopicsGrid.CurrentRowIndex, acTopicsGrid.CurrentColumnIndex].FormattedValue.ToString())));

		}

		private void acTopicsListClose_Click(Object eventSender, EventArgs eventArgs)
		{
			acTopicsAircraftFrame.Visible = false;
			acTopicsGrid.Visible = true;
			acTopicArea.Visible = true;
		}

		private void cbo_aport_country_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs)
		{

			string strCountry = "";

			if (frmAirport.Enabled && cbo_aport_country.Enabled)
			{
				strCountry = ($"{cbo_aport_country.Text} ").Trim();
				grd_Airport.CurrentColumnIndex = 6;
				if (strCountry != grd_Airport[grd_Airport.CurrentRowIndex, grd_Airport.CurrentColumnIndex].FormattedValue.ToString())
				{
					lblAirport[0].Text = "Airport Name*";
				}
			}

			if (cbo_aport_country.Text != "")
			{
				Fill_State(cbo_aport_state, cbo_aport_state.Text, cbo_aport_country.Text);
			}

		}

		private void cbo_aport_state_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs)
		{

			string strState = "";

			if (frmAirport.Enabled && cbo_aport_state.Enabled)
			{
				if (cbo_aport_state.Text != "")
				{
					strState = cbo_aport_state.Text.Substring(0, Math.Min(cbo_aport_state.Text.IndexOf(" -- "), cbo_aport_state.Text.Length));
				}
				grd_Airport.CurrentColumnIndex = 5;
				if (strState != grd_Airport[grd_Airport.CurrentRowIndex, grd_Airport.CurrentColumnIndex].FormattedValue.ToString())
				{
					lblAirport[0].Text = "Airport Name*";
				}
			}

		}

		private void cbo_CREG_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs)
		{

			string tmp = $"{cbo_CREG.Text}";
			ToolTipMain.SetToolTip(cbo_CREG, tmp);
			if (Strings.Len(txt_crm_amod_list.Text) > 0)
			{
				txt_crm_amod_list.Text = $"{txt_crm_amod_list.Text},{Conversion.Val(tmp.Substring(0, Math.Min(3, tmp.Length))).ToString()}";
			}
			else
			{
				txt_crm_amod_list.Text = Conversion.Val(tmp.Substring(0, Math.Min(3, tmp.Length))).ToString();
			}

		}

		private void Check_For_Search_Enter_Key(int KeyCode)
		{
			if (KeyCode == Strings.Asc("\r"[0]))
			{
				cmd_Refresh_Airports_Click(cmd_Refresh_Airports, new EventArgs());
			}
		}

		private void cbo_iata_index_KeyUp(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				Check_For_Search_Enter_Key(KeyCode);
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}

		private void cbo_iata_index_Leave(Object eventSender, EventArgs eventArgs)
		{
			cbo_iata_index.Text = cbo_iata_index.Text.ToUpper();
			if (cbo_iata_index.Text == "")
			{
				cbo_iata_index.Text = "ALL";
			}
		}

		private void cbo_icao_index_KeyUp(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				Check_For_Search_Enter_Key(KeyCode);
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}

		private void cbo_icao_index_Leave(Object eventSender, EventArgs eventArgs)
		{
			cbo_icao_index.Text = cbo_icao_index.Text.ToUpper();
			if (cbo_icao_index.Text == "")
			{
				cbo_icao_index.Text = "ALL";
			}
		}

		private void cbo_faaid_index_KeyUp(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				Check_For_Search_Enter_Key(KeyCode);
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}

		private void cbo_faaid_index_Leave(Object eventSender, EventArgs eventArgs)
		{
			cbo_faaid_index.Text = cbo_faaid_index.Text.ToUpper();
			if (cbo_faaid_index.Text == "")
			{
				cbo_faaid_index.Text = "ALL";
			}
		}

		private void cbo_Airport_Index_KeyUp(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				Check_For_Search_Enter_Key(KeyCode);
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		}

		private void cbo_Airport_Index_Leave(Object eventSender, EventArgs eventArgs)
		{
			if (cbo_Airport_Index.Text == "")
			{
				cbo_Airport_Index.Text = "ALL";
			}
		}

		private void cboShow_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs) => Aircraft_Contact_Type("Fill List");


		private void chk_actype_compref_flag_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{

			if (chk_actype_compref_flag.CheckState == CheckState.Checked)
			{
				pnl_CompanyRelationship.Visible = true;
			}
			else
			{
				//      pnl_CompanyRelationship.Visible = False
			}

		}

		private void chk_show_inactive_CheckStateChanged(Object eventSender, EventArgs eventArgs) => get_keyfeat();


		private void chkAirportListOptions_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.chkAirportListOptions, eventSender);

			if (Index == APortWCoord || Index == APortWOCoord)
			{

				if (chkAirportListOptions[APortWCoord].Enabled && chkAirportListOptions[APortWOCoord].Enabled)
				{

					chkAirportListOptions[APortWCoord].Enabled = false;
					chkAirportListOptions[APortWOCoord].Enabled = false;


					switch(Index)
					{
						case APortWCoord :  // w/Coordinates 
							 
							if (chkAirportListOptions[APortWCoord].CheckState == CheckState.Checked)
							{
								chkAirportListOptions[APortWOCoord].CheckState = CheckState.Unchecked;
							} 
							 
							break;
						case APortWOCoord :  // wo/Coordinates 
							 
							if (chkAirportListOptions[APortWOCoord].CheckState == CheckState.Checked)
							{
								chkAirportListOptions[APortWCoord].CheckState = CheckState.Unchecked;
							} 
							 
							break;
					} // Case Index

					chkAirportListOptions[APortWCoord].Enabled = true;
					chkAirportListOptions[APortWOCoord].Enabled = true;

				} // If chkAirportListOptions(APortWCoord ).Enabled = True And chkAirportListOptions(APortWOCoord ).Enabled = True Then

			} // If Index = APortWCoord  Or Index = APortWOCoord  Then

			//-------------------------------
			// With and Without Runway

			if (Index == APortWRunway || Index == APortWORunway)
			{

				if (chkAirportListOptions[APortWRunway].Enabled && chkAirportListOptions[APortWORunway].Enabled)
				{

					chkAirportListOptions[APortWRunway].Enabled = false;
					chkAirportListOptions[APortWORunway].Enabled = false;


					switch(Index)
					{
						case APortWRunway :  // w/Runway 
							 
							if (chkAirportListOptions[APortWRunway].CheckState == CheckState.Checked)
							{
								chkAirportListOptions[APortWORunway].CheckState = CheckState.Unchecked;
							} 
							 
							break;
						case APortWORunway :  // wo/Runway 
							 
							if (chkAirportListOptions[APortWORunway].CheckState == CheckState.Checked)
							{
								chkAirportListOptions[APortWRunway].CheckState = CheckState.Unchecked;
							} 
							 
							break;
					} // Case Index

					chkAirportListOptions[APortWRunway].Enabled = true;
					chkAirportListOptions[APortWORunway].Enabled = true;

				} // If chkAirportListOptions(APortWRunway ).Enabled = True And chkAirportListOptions(APortWORunway ).Enabled = True Then

			} // If Index = APortWRunway  Or Index = APortWORunway  Then

		} // chkAirportListOptions_Click

		private void chkShowCounts_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{

			try
			{

				int lngResult = 0;
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Counting Feature Code Information .....", Color.Blue);


				if (pnl_kfeat_test.Visible && Strings.Len(($"{txt_kfeat_code.Text}").Trim()) > 0)
				{

					if (chkShowCounts.CheckState == CheckState.Checked)
					{

						lblCount[0].Visible = false;
						lblCount[1].Visible = false;
						lblCount[2].Visible = false;

						this.Cursor = Cursors.WaitCursor;

						Application.DoEvents();

						lblCount[0].Text = $"Yes: {modAdminCommon.CountACFeatures(0, ($"{txt_kfeat_code.Text}").Trim(), "Y").ToString()}";
						lblCount[1].Text = $"No: {modAdminCommon.CountACFeatures(0, ($"{txt_kfeat_code.Text}").Trim(), "N").ToString()}";
						lngResult = modAdminCommon.Key_Feature_Auto_Count(($"{txt_kfeat_code.Text}").Trim(), 0);
						if (lngResult == -1)
						{
							lblCount[2].Text = "Data: N/A";
						}
						else
						{
							lblCount[2].Text = $"Data: {lngResult.ToString()} - Note: This is total for all aircraft. Mass updates will only apply to designated ac models.";
						}

						lblCount[0].Visible = true;
						lblCount[1].Visible = true;
						lblCount[2].Visible = true;

						this.Cursor = CursorHelper.CursorDefault;

					}
					else
					{
						//If chkShowCounts.Value = vbChecked Then

						lblCount[0].Visible = false;
						lblCount[1].Visible = false;
						lblCount[2].Visible = false;

					} //If chkShowCounts.Value = vbChecked Then

				}
				else
				{
					//If lst_Kfeat_List.ListIndex >= 0 Then

					lblCount[0].Visible = false;
					lblCount[1].Visible = false;
					lblCount[2].Visible = false;

				} //If lst_Kfeat_List.ListIndex >= 0 Then
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "", Color.Blue);
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"chkShowCounts_Click_Error: {excep.Message}");
			}

		}

		private void cmd_Add_Aircraft_Contact_type_Click(Object eventSender, EventArgs eventArgs)
		{

			pnl_ACTypeMain.Visible = true;
			pnl_Aircraft_Contact_Type_AddUpdate.Visible = true;
			Aircraft_Contact_Type("Clear");
			RecordStat = "Add";
			txt_actype_code.Enabled = true;

		}

		private void cmd_Add_Aircraft_type_Click(Object eventSender, EventArgs eventArgs)
		{

			RecordStat = "Add";
			txt_atype_code.Text = "";
			txt_atype_Name.Text = "";

			pnl_Aircraft_Type_AddUpdate.Visible = true;
			txt_atype_code.Enabled = true;

		}

		private void cmd_Add_APU_Click(Object eventSender, EventArgs eventArgs)
		{
			RecordStat = "Add";
			txt_apu_make_name.Text = "";
			txt_apu_model_name.Text = "";
			pnl_APU_Update_Change.Visible = true;
			txt_apu_make_name.Enabled = true;

		}

		private void cmd_Add_Asking_Click(Object eventSender, EventArgs eventArgs)
		{
			//aey 4/21/04 Aircraft_Asking ("Clear")

			RecordStat = "Add";
			txt_aask_name.Text = "";
			txt_aask_description.Text = "";
			pnl_NameDesc_Asking.Visible = true;
			txt_aask_name.Enabled = true;

		}

		private void cmd_Add_avionics_Click(Object eventSender, EventArgs eventArgs)
		{

			RecordStat = "Add";
			txt_avion_name.Text = "";
			txt_avion_notes.Text = "";
			pnl_avionics_Update_Change.Visible = true;
			txt_avion_name.Enabled = true;

		}

		private void cmd_Add_Certification_Click(Object eventSender, EventArgs eventArgs)
		{


			RecordStat = "Add";
			txt_certification_name[0].Text = "";
			txt_certification_name[2].Text = "";
			pnl_Certification_Update_Change.Visible = true;
			txt_certification_name[0].Enabled = true;
			cbo_Ops_Cert_usaFlag.Text = "";
			chkCertActive.CheckState = CheckState.Checked;

		}

		private void cmd_Add_EMP_Click(Object eventSender, EventArgs eventArgs)
		{

			txt_emp_code.Text = "";
			txt_emp_name.Text = "";
			txt_Emp_ID.Text = "";
			txt_Provider_Name.Text = "";
			txt_Program_Name.Text = "";

			RecordStat = "Add";
			pnl_EMP_AddUpdate.Visible = true;
			txt_emp_code.Enabled = true;

		}

		private void cmd_Add_IC_Click(Object eventSender, EventArgs eventArgs)
		{
			//aey 4/21/2004    Interior_Configuration ("Clear")

			RecordStat = "Add";
			txt_intconfig_name.Text = "";
			pnl_IC_Update_Change.Visible = true;
			txt_intconfig_name.Enabled = true;

		}

		private void cmd_Add_Kfeat_Click(Object eventSender, EventArgs eventArgs)
		{

			pnl_kfeat_test.Visible = true;
			cmd_Save_Kfeat.Text = "&Save";
			txt_kfeat_name.Enabled = true;
			txt_kfeat_description.Enabled = true;
			txt_kfeat_research_notes.Enabled = true;
			txt_kfeat_howtoformat.Enabled = true;
			txt_kfeat_wheretoenter.Enabled = true;
			txt_kfeat_code.BackColor = Color.White;

			txt_kfeat_code.Text = "";
			txt_kfeat_name.Text = "";
			txt_kfeat_description.Text = "";
			txt_kfeat_research_notes.Text = "";
			txt_kfeat_howtoformat.Text = "";
			txt_kfeat_wheretoenter.Text = "";
			chk_Inactive_Feature_Code.CheckState = CheckState.Unchecked;
			chk_kfeat_donotclear.CheckState = CheckState.Unchecked;
			txt_InactiveDate.Text = "";

			txt_kfeat_query.Text = "";
			pnlAdmin.Visible = true;

			RecordStat = "Add";
			txt_kfeat_code.Enabled = true;
			chkShowCounts.Visible = false;

		}

		private void cmd_Add_Aircraft_Class_Click(Object eventSender, EventArgs eventArgs)
		{

			RecordStat = "Add";
			txt_aclass_code.Text = "";
			txt_aclass_Name.Text = "";

			pnl_Aircraft_Class_AddUpdate.Visible = true;
			txt_aclass_code.Enabled = true;

		}

		private void cmd_add_spec_Click(Object eventSender, EventArgs eventArgs)
		{
			//aey 4/21/2004    'Specification ("Clear")

			RecordStat = "Add";
			txt_spec_name.Text = "";
			txt_spec_type.Text = "";
			txt_spec_notes.Text = "";

			pnl_Spec_Update_Change.Visible = true;
			txt_spec_name.Enabled = true;

		}

		private void cmd_Airport_Add_Click(Object eventSender, EventArgs eventArgs)
		{

			cmd_Airport_Delete.Visible = false;
			cmd_Airport_Delete.Enabled = false;
			Airport_Clear_Input();
			txtAirport[iAPORTNAME_INDEX].Focus();

		}

		private void cmd_Airport_Cancel_Click(Object eventSender, EventArgs eventArgs) => cmd_Airport_Delete.Visible = true;//   Airport ("Fill List")


		private void cmd_Airport_Delete_Click(Object eventSender, EventArgs eventArgs)
		{

			ADORecordSetHelper snpCount = new ADORecordSetHelper();
			string strQuery1 = ""; // Check To See If Airport Is Duplicate
			string strDelete1 = "";
			string strWhere1 = "";
			string strWhere2 = "";

			bool bDuplicate = false;
			string strIATA = "";
			string strICAO = "";
			string strFAAID = "";
			string strAirport = "";
			int lRecordCount = 0;
			int iDel1 = 0;

			int lRow = 0;
			int lAPortId = 0;

			try
			{

				lRow = grd_Airport.CurrentRowIndex;
				lAPortId = grd_Airport.get_RowData(lRow);

				strDelete1 = "";
				if (lAPortId > 0)
				{
					strDelete1 = "DELETE FROM Airport ";
					strDelete1 = $"{strDelete1}WHERE (aport_id = {lAPortId.ToString()}) ";
				}

				strAirport = ($"{txtAirport[iAPORTNAME_INDEX].Text} ").Trim();
				strIATA = ($"{txtAirport[iIATA_INDEX].Text} ").Trim();
				strICAO = ($"{txtAirport[iICAO_INDEX].Text} ").Trim();
				strFAAID = ($"{txtAirport[iFAAID_INDEX].Text} ").Trim();

				bDuplicate = false;
				strQuery1 = "SELECT DISTINCT aport_id, aport_iata_code, aport_icao_code, aport_name, aport_active_flag ";
				strQuery1 = $"{strQuery1}FROM Airport WITH (NOLOCK) ";

				strWhere1 = $"WHERE (aport_name = '{StringsHelper.Replace(strAirport, "'", "''", 1, -1, CompareMethod.Binary)}') ";

				if (strIATA == "")
				{
					strWhere1 = $"{strWhere1}AND (aport_iata_code = '' OR aport_iata_code IS NULL) ";
				}
				else
				{
					strWhere1 = $"{strWhere1}AND (aport_iata_code = '{strIATA}') ";
				}

				if (strICAO == "")
				{
					strWhere1 = $"{strWhere1}AND (aport_icao_code = '' OR aport_icao_code IS NULL) ";
				}
				else
				{
					strWhere1 = $"{strWhere1}AND (aport_icao_code = '{strICAO}') ";
				}

				if (strFAAID == "")
				{
					strWhere1 = $"{strWhere1}AND (aport_faaid_code = '' OR aport_faaid_code IS NULL) ";
				}
				else
				{
					strWhere1 = $"{strWhere1}AND (aport_faaid_code = '{strFAAID}') ";
				}

				snpCount.CursorLocation = CursorLocationEnum.adUseClient;
				snpCount.Open($"{strQuery1}{strWhere1}", modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!snpCount.BOF) && (!snpCount.EOF))
				{

					lAPortId = grd_Airport.get_RowData(lRow);
					lRecordCount = snpCount.RecordCount;
					if (lRecordCount > 1)
					{
						bDuplicate = true;
					}

				} // If (snpCount.BOF = False) And (snpCount.EOF = False) Then

				snpCount.Close();

				if (bDuplicate)
				{

					if (MessageBox.Show($"This Airport is a Duplicate Airport{Environment.NewLine}Are You Trying To Delete An Inactive Duplicate Airport", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
					{

						if (strDelete1 != "")
						{

							modMyAdmin.Record_EventAdmin("Maintenance", $"Delete Duplicate of Airport: {txtAirport[iIATA_INDEX].Text}-{txtAirport[iICAO_INDEX].Text}-{txtAirport[iFAAID_INDEX].Text} {modAdminCommon.Fix_Quote(txtAirport[iAPORTNAME_INDEX].Text)}");

							iDel1 = 0;
							DbCommand TempCommand = null;
							TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
							TempCommand.CommandText = strDelete1;
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
							TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
							iDel1 = TempCommand.ExecuteNonQuery();


							if (Send_To_Evo(strDelete1))
							{
								Application.DoEvents();
							}

							if (iDel1 > 0)
							{
								MessageBox.Show("The Duplicate Airport Has Been Deleted", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
							}
							else
							{
								MessageBox.Show("Could NOT Find An InActive Airport To Delete", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							}

							Airport_Fill_List();

						}
						else
						{
							MessageBox.Show("Could Not Find Airport Id To Delete", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						} // If strDelete1 <> "" Then

					} // If MsgBox("This Airport is a Duplicate Airport"

				}
				else
				{
					// If bDuplicate = True Then



					if (strIATA != "" || strICAO != "")
					{

						this.Cursor = Cursors.WaitCursor;
						cmd_Airport_Delete.Enabled = false;
						modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Counting Aircraft...", Color.Blue);

						if (ac_count > 0)
						{
							if (MessageBox.Show($"This will affect {ac_count.ToString()} Aircraft Records.{Environment.NewLine}Are you sure you want to delete this Airport?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
							{
								Airport_Delete();
							}
						}
						else
						{
							if (MessageBox.Show("Are you sure you want to delete this Airport?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
							{
								Airport_Delete();
							}
						}

					}
					else
					{
						MessageBox.Show($"Airport must have an IATA or ICAO to Delete{Environment.NewLine}This Airport does not have either{Environment.NewLine}And must be deleted manually", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					} // If strIATA <> "" Or strICAO <> "" Then

				} // End If ' If bDuplicate Then

				snpCount = null;

				Airport_Clear_Input();

				this.Cursor = CursorHelper.CursorDefault;
				cmd_Airport_Delete.Enabled = true;

				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"AirCraft_Delete_Error: {excep.Message}");
				this.Cursor = CursorHelper.CursorDefault;
			}

		}

		private void cmd_Airport_Save_Click(Object eventSender, EventArgs eventArgs)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strIATAOld = "";
			string strICAOOld = "";
			string strFAAIDOld = "";

			string strAPortName = "";
			string strIATANew = "";
			string strICAONew = "";
			string strFAAIDNew = "";

			int lACCount = 0;
			int lAPortId = 0;
			int lRow = 0;

			try
			{

				this.Cursor = Cursors.WaitCursor;
				cmd_Airport_Save.Enabled = false;

				lRow = grd_Airport.CurrentRowIndex;
				lAPortId = grd_Airport.get_RowData(lRow);

				grd_Airport.CurrentColumnIndex = 0;
				strIATAOld = grd_Airport[grd_Airport.CurrentRowIndex, grd_Airport.CurrentColumnIndex].FormattedValue.ToString().ToUpper();

				grd_Airport.CurrentColumnIndex = 1;
				strICAOOld = grd_Airport[grd_Airport.CurrentRowIndex, grd_Airport.CurrentColumnIndex].FormattedValue.ToString().ToUpper();

				grd_Airport.CurrentColumnIndex = 2;
				strFAAIDOld = grd_Airport[grd_Airport.CurrentRowIndex, grd_Airport.CurrentColumnIndex].FormattedValue.ToString().ToUpper();

				strIATANew = ($"{txtAirport[iIATA_INDEX].Text} ").Trim().ToUpper();
				txtAirport[iIATA_INDEX].Text = strIATANew;

				strICAONew = ($"{txtAirport[iICAO_INDEX].Text} ").Trim().ToUpper();
				txtAirport[iICAO_INDEX].Text = strICAONew;

				strFAAIDNew = ($"{txtAirport[iFAAID_INDEX].Text} ").Trim().ToUpper();
				txtAirport[iFAAID_INDEX].Text = strFAAIDNew;

				strAPortName = ($"{txtAirport[iAPORTNAME_INDEX].Text} ").Trim();

				// Direction
				txtAirport[5].Text = txtAirport[5].Text.ToUpper();
				txtAirport[10].Text = txtAirport[10].Text.ToUpper();


				switch(RecordStat)
				{
					case "Add" : 
						 
						if (strIATANew != "" || strICAONew != "" || strFAAIDNew != "")
						{
							Airport_Insert();
						}
						else
						{
							MessageBox.Show("The IATA, ICAO and FAAID codes are blank, unable to update", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						} 
						 
						break;
					case "Delete" : 
						 
						Airport_Delete(); 
						 
						break;
					case "Save" : case "Update" : 
						 
						if (strIATANew != "" || strICAONew != "" || strFAAIDNew != "")
						{

							if (strAPortName != "")
							{

								//-----------------------------------------------------------
								// Check To See If Main Airport Information Has Changed

								if (lblAirport[0].Text == "Airport Name*")
								{

									lACCount = ac_count;

									if (lACCount > 0)
									{
										if (MessageBox.Show($"This will affect {StringsHelper.Format(lACCount, "#,###")} Aircraft Records.{Environment.NewLine}Are you sure you want to update this Airport?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
										{
											Airport_Update(lAPortId);
										}
									}
									else
									{
										Airport_Update(lAPortId);
									} // If lACCount > 0 Then

								}
								else
								{
									Airport_Update(lAPortId);
								} // If lblAirport(0).Caption = "Airport Name*"

							}
							else
							{
								MessageBox.Show("Unable To Update Please enter an Airport Name", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							} // If strAPortName <> "" Then

						}
						else
						{
							MessageBox.Show("The IATA, ICAO and FAAID codes are blank, unable to update", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						}  // If strIATANew <> "" Or strICAONew <> "" Or strFAAIDNew <> "" Then 
						 
						grd_Airport.CurrentRowIndex = lRow; 
						grd_Airport.CurrentColumnIndex = 0; 
						grd_Airport.ColSel = grd_Airport.ColumnsCount - 1; 
						 
						break;
				} // RecordStat

				this.Cursor = CursorHelper.CursorDefault;
				cmd_Airport_Save.Enabled = true;

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"cmd_Airport_Save_Click: {excep.Message}");
				this.Cursor = CursorHelper.CursorDefault;
			}

		} // cmd_Airport_Save_Click

		private void cmd_button_Click(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.cmd_button, eventSender);

			string Query = "";
			string strWhatDatabase = "";
			int IsLive = 0;
			string strJetAFuelPrice = "";
			string strLowLeadFuelPrice = "";
			string strCommercialFuelPrice = "";
			string strSAFFuelPrice = "";
			string strQuery1 = "";
			string strQuery2 = "";
			string strQuery3a = "";
			string strQuery3b = "";
			string strQuery3c = "";
			string strQuery3d = "";
			string strQuery3e = "";
			string strQuery4 = "";
			string strQuery5 = "";

			string strQuery6 = "";
			string strQuery7 = "";
			string strQuery8 = "";

			try
			{

				Query = "";
				switch(Index)
				{
					case 0 :  // ABI Hide Aircraft - Add 
						if (cmd_button[0].Text == "Save")
						{
							if (Text1[0].Text != "")
							{
								//ABI_Aircraft_Do_Not_Show
								Query = "INSERT INTO ABI_Aircraft_Do_Not_Show (aadns_ac_id, aadns_journ_id, aadns_entry_date, aadns_user_id) VALUES (";
								Query = $"{Query}{Convert.ToInt32(Double.Parse(Text1[0].Text.Trim())).ToString()},0,'{DateTime.Now.ToString()}','{modAdminCommon.gbl_User_ID}')";

								DbCommand TempCommand = null;
								TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
								UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
								TempCommand.CommandText = Query;
								UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
								TempCommand.ExecuteNonQuery();
								modAdminCommon.Table_Action_Log("ABI_Aircraft_Do_Not_Show");
								Load_grd_ABI_Hide_AC();
								grd_ABI_Hide_AC.CurrentRowIndex = 1;
								grd_ABI_Hide_AC.CurrentColumnIndex = 0;
								Text1[0].Text = grd_ABI_Hide_AC[grd_ABI_Hide_AC.CurrentRowIndex, grd_ABI_Hide_AC.CurrentColumnIndex].FormattedValue.ToString();
								grd_ABI_Hide_AC.CurrentColumnIndex = 1;
								lbl_generic[5].Text = grd_ABI_Hide_AC[grd_ABI_Hide_AC.CurrentRowIndex, grd_ABI_Hide_AC.CurrentColumnIndex].FormattedValue.ToString();
								grd_ABI_Hide_AC.CurrentColumnIndex = 2;
								lbl_generic[6].Text = grd_ABI_Hide_AC[grd_ABI_Hide_AC.CurrentRowIndex, grd_ABI_Hide_AC.CurrentColumnIndex].FormattedValue.ToString();
								grd_ABI_Hide_AC.CurrentColumnIndex = 3;
								lbl_generic[7].Text = grd_ABI_Hide_AC[grd_ABI_Hide_AC.CurrentRowIndex, grd_ABI_Hide_AC.CurrentColumnIndex].FormattedValue.ToString();
								lbl_generic[1].Visible = true;
								lbl_generic[3].Visible = true;
								lbl_generic[4].Visible = true;
								lbl_generic[5].Visible = true;
								lbl_generic[6].Visible = true;
								lbl_generic[7].Visible = true;
								Text1[0].Visible = true;
								lbl_generic[0].Visible = true;
								cmd_button[0].Text = "Add";
							}
							else
							{
								MessageBox.Show("Aircraft ID is cannot be blank", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
								Text1[0].Focus();
							}
						}
						else if (cmd_button[0].Text == "Add")
						{ 
							cmd_button[0].Text = "Save";
							Text1[0].Text = "";
							lbl_generic[1].Visible = false;
							lbl_generic[3].Visible = false;
							lbl_generic[4].Visible = false;
							lbl_generic[5].Visible = false;
							lbl_generic[6].Visible = false;
							lbl_generic[7].Visible = false;
						} 
						 
						break;
					case 1 :  // ABI Hide Aircraft - Delete 
						if (Text1[0].Text.Trim() != "")
						{
							if (MessageBox.Show("Are You Sure You Want To Delete This Record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
							{
								Query = "DELETE FROM ABI_Aircraft_Do_Not_Show";
								Query = $"{Query} WHERE aadns_ac_id={Convert.ToInt32(Double.Parse(Text1[0].Text.Trim())).ToString()}";
								DbCommand TempCommand_2 = null;
								TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
								UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
								TempCommand_2.CommandText = Query;
								UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
								TempCommand_2.ExecuteNonQuery();
								modAdminCommon.Table_Action_Log("ABI_Aircraft_Do_Not_Show");
								Load_grd_ABI_Hide_AC();
							}
						}
						else
						{
							MessageBox.Show("Aircraft ID cannot be blank", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
							Text1[0].Focus();
						} 
						 
						break;
					case 2 :  // ABI Hide Aircraft - Cancel 
						cmd_button[0].Text = "Add"; 
						grd_ABI_Hide_AC.CurrentRowIndex = 1; 
						grd_ABI_Hide_AC.CurrentColumnIndex = 0; 
						Text1[0].Text = grd_ABI_Hide_AC[grd_ABI_Hide_AC.CurrentRowIndex, grd_ABI_Hide_AC.CurrentColumnIndex].FormattedValue.ToString(); 
						grd_ABI_Hide_AC.CurrentColumnIndex = 1; 
						lbl_generic[5].Text = grd_ABI_Hide_AC[grd_ABI_Hide_AC.CurrentRowIndex, grd_ABI_Hide_AC.CurrentColumnIndex].FormattedValue.ToString(); 
						grd_ABI_Hide_AC.CurrentColumnIndex = 2; 
						lbl_generic[6].Text = grd_ABI_Hide_AC[grd_ABI_Hide_AC.CurrentRowIndex, grd_ABI_Hide_AC.CurrentColumnIndex].FormattedValue.ToString(); 
						grd_ABI_Hide_AC.CurrentColumnIndex = 3; 
						lbl_generic[7].Text = grd_ABI_Hide_AC[grd_ABI_Hide_AC.CurrentRowIndex, grd_ABI_Hide_AC.CurrentColumnIndex].FormattedValue.ToString(); 
						lbl_generic[1].Visible = true; 
						lbl_generic[3].Visible = true; 
						lbl_generic[4].Visible = true; 
						lbl_generic[5].Visible = true; 
						lbl_generic[6].Visible = true; 
						lbl_generic[7].Visible = true; 
						Text1[0].Visible = true; 
						lbl_generic[0].Visible = true; 
						 
						break;
					case 3 :  // Update Fuel Price 

						 
						strJetAFuelPrice = StringsHelper.Replace(($"{txtFuelCost[0].Text} ").Trim(), "$", "", 1, -1, CompareMethod.Binary); 
						strLowLeadFuelPrice = StringsHelper.Replace(($"{txtFuelCost[1].Text} ").Trim(), "$", "", 1, -1, CompareMethod.Binary); 
						strCommercialFuelPrice = StringsHelper.Replace(($"{txtFuelCost[2].Text} ").Trim(), "$", "", 1, -1, CompareMethod.Binary); 
						strSAFFuelPrice = StringsHelper.Replace(($"{txtFuelCost[3].Text} ").Trim(), "$", "", 1, -1, CompareMethod.Binary);  // added MSW - 8/22/24 
						 
						if (Information.IsNumeric(lbl_generic[9].Text))
						{

							if (strJetAFuelPrice != "")
							{

								if (Information.IsNumeric(strJetAFuelPrice))
								{

									if (strLowLeadFuelPrice != "")
									{

										if (Information.IsNumeric(strLowLeadFuelPrice))
										{

											if (strCommercialFuelPrice != "")
											{

												if (Information.IsNumeric(strCommercialFuelPrice))
												{

													//------------------------------------------------------------
													// 02/01/2012 - By David D. Cruger
													// Update All Homebase Application_Configuration Fuel Cost Records

													strQuery1 = $"UPDATE Application_Configuration SET  aconfig_fuel_cost = {strJetAFuelPrice}, ";
													strQuery1 = $"{strQuery1}aconfig_jeta_fuel_cost = {strJetAFuelPrice}, ";
													strQuery1 = $"{strQuery1}aconfig_lowlead_fuel_cost = {strLowLeadFuelPrice}, ";
													strQuery1 = $"{strQuery1}aconfig_saf_fuel_cost = {strSAFFuelPrice}, ";
													strQuery1 = $"{strQuery1}aconfig_commercial_fuel_cost = {strCommercialFuelPrice} ";



													DbCommand TempCommand_3 = null;
													TempCommand_3 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
													UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_3);
													TempCommand_3.CommandText = strQuery1;
													//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
													//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
													TempCommand_3.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
													UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_3);
													TempCommand_3.ExecuteNonQuery();


													strQuery2 = $"UPDATE Evolution_Configuration SET evo_config_fuel_cost = {strJetAFuelPrice}, ";
													strQuery2 = $"{strQuery2}evo_config_jeta_fuel_cost = {strJetAFuelPrice}, ";
													strQuery2 = $"{strQuery2}evo_config_lowlead_fuel_cost = {strLowLeadFuelPrice}, ";
													strQuery2 = $"{strQuery2}evo_config_saf_fuel_cost = {strSAFFuelPrice}, ";
													strQuery2 = $"{strQuery2}evo_config_commercial_fuel_cost = {strCommercialFuelPrice} ";

													DbCommand TempCommand_4 = null;
													TempCommand_4 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
													UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_4);
													TempCommand_4.CommandText = strQuery2;
													//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
													//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
													TempCommand_4.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
													UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_4);
													TempCommand_4.ExecuteNonQuery();

													strQuery3a = $"UPDATE Aircraft_Model  SET amod_fuel_gal_cost={strJetAFuelPrice}, amod_fuel_tot_cost=(({strJetAFuelPrice} + amod_fuel_add_cost ) * amod_fuel_burn_rate) ";
													strQuery3a = $"{strQuery3a}WHERE (amod_airframe_type_code IN ('R','F')) ";
													strQuery3a = $"{strQuery3a}AND (amod_product_business_flag = 'Y' OR amod_product_helicopter_flag = 'Y') ";
													strQuery3a = $"{strQuery3a}AND (amod_type_code IN ('J','T','E')) ";

													strQuery3b = $"UPDATE Aircraft_Model SET amod_fuel_gal_cost={strLowLeadFuelPrice}, amod_fuel_tot_cost=(({strLowLeadFuelPrice} + amod_fuel_add_cost ) * amod_fuel_burn_rate) ";
													strQuery3b = $"{strQuery3b}WHERE (amod_airframe_type_code IN ('R','F')) ";
													strQuery3b = $"{strQuery3b}AND (amod_product_business_flag = 'Y' OR amod_product_helicopter_flag = 'Y') ";
													strQuery3b = $"{strQuery3b}AND (amod_type_code = 'P') ";

													strQuery3c = $"UPDATE Aircraft_Model SET amod_fuel_gal_cost={strCommercialFuelPrice}, amod_fuel_tot_cost=(({strCommercialFuelPrice} + amod_fuel_add_cost ) * amod_fuel_burn_rate) ";
													strQuery3c = $"{strQuery3c}WHERE (amod_airframe_type_code = 'F') ";
													strQuery3c = $"{strQuery3c}AND (amod_product_business_flag = 'N') ";
													strQuery3c = $"{strQuery3c}AND (amod_product_commercial_flag = 'Y') ";
													strQuery3c = $"{strQuery3c}AND (amod_type_code IN ('J','T','E')) ";



													// CHANGED PER ERROL - APPROVED BY LISA - 9/21/21 - CHANGED TO BE BACK TO COMMERCIAL
													strQuery3d = $"UPDATE Aircraft_Model  SET amod_fuel_gal_cost={strCommercialFuelPrice}, amod_fuel_tot_cost=(({strCommercialFuelPrice} + amod_fuel_add_cost ) * amod_fuel_burn_rate) ";
													strQuery3d = $"{strQuery3d}WHERE (amod_airframe_type_code = 'F') ";
													strQuery3d = $"{strQuery3d}AND (amod_product_business_flag = 'Y' AND amod_product_commercial_flag = 'Y') ";
													strQuery3d = $"{strQuery3d} AND amod_id in ";
													strQuery3d = $"{strQuery3d} (703,712,714,720,723,725,728,729,730,672,763,6,668,782,312,313,314,316,821,823,321,322,841,1099,324,326,328,854,329,856,859,860,332,861,863,864,865,868,869,871,181,885,914,915,689,16,265,1017,1023,1175,1025) ";


													strQuery3e = $"UPDATE Aircraft_Model  SET amod_fuel_gal_cost={strJetAFuelPrice}, amod_fuel_tot_cost=(({strJetAFuelPrice} + amod_fuel_add_cost ) * amod_fuel_burn_rate) ";
													strQuery3e = $"{strQuery3e}WHERE (amod_airframe_type_code = 'F') ";
													strQuery3e = $"{strQuery3e}AND (amod_product_business_flag = 'Y' AND amod_product_commercial_flag = 'Y') ";
													strQuery3e = $"{strQuery3e}AND amod_id in  ";
													strQuery3e = $"{strQuery3e} (181,644,22,1220,1133,1218,1174,1248,301,302,788,789,307,308,801,310,311,814,831,28,1270,1271,1272,266,655,1263,1264,1265,1261,1262,180,1170,884,281,263,264,1171,1172,1014,1026,1157) ";


													DbCommand TempCommand_5 = null;
													TempCommand_5 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
													UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_5);
													TempCommand_5.CommandText = strQuery3a;
													//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
													//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
													TempCommand_5.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
													UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_5);
													TempCommand_5.ExecuteNonQuery();

													Application.DoEvents();
													Application.DoEvents();
													Application.DoEvents();
													Application.DoEvents();

													DbCommand TempCommand_6 = null;
													TempCommand_6 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
													UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_6);
													TempCommand_6.CommandText = strQuery3b;
													//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
													//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
													TempCommand_6.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
													UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_6);
													TempCommand_6.ExecuteNonQuery();

													Application.DoEvents();
													Application.DoEvents();
													Application.DoEvents();
													Application.DoEvents();
													DbCommand TempCommand_7 = null;
													TempCommand_7 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
													UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_7);
													TempCommand_7.CommandText = strQuery3c;
													//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
													//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
													TempCommand_7.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
													UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_7);
													TempCommand_7.ExecuteNonQuery();


													Application.DoEvents();
													Application.DoEvents();
													JetNetSupport.PInvoke.SafeNative.kernel32.Sleep(20);
													Application.DoEvents();
													Application.DoEvents();
													Application.DoEvents();
													DbCommand TempCommand_8 = null;
													TempCommand_8 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
													UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_8);
													TempCommand_8.CommandText = strQuery3d;
													//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
													//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
													TempCommand_8.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
													UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_8);
													TempCommand_8.ExecuteNonQuery();

													Application.DoEvents();
													Application.DoEvents();
													JetNetSupport.PInvoke.SafeNative.kernel32.Sleep(20);
													Application.DoEvents();
													Application.DoEvents();
													Application.DoEvents();
													DbCommand TempCommand_9 = null;
													TempCommand_9 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
													UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_9);
													TempCommand_9.CommandText = strQuery3e;
													//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
													//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
													TempCommand_9.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
													UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_9);
													TempCommand_9.ExecuteNonQuery();

													//------------------------------------------------------------
													// 02/14/2018 - By David D. Cruger
													// Updated Total Hour Direct Cost Records

													strQuery4 = "UPDATE Aircraft_Model ";
													strQuery4 = $"{strQuery4}SET amod_tot_hour_direct_cost = dbo.ReturnAircraftModelDirectCost(amod_id) ";

													DbCommand TempCommand_10 = null;
													TempCommand_10 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
													UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_10);
													TempCommand_10.CommandText = strQuery4;
													//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
													//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
													TempCommand_10.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
													UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_10);
													TempCommand_10.ExecuteNonQuery();
													Application.DoEvents();
													Application.DoEvents();
													JetNetSupport.PInvoke.SafeNative.kernel32.Sleep(50);
													Application.DoEvents();
													Application.DoEvents();
													Application.DoEvents();
													Application.DoEvents();
													Application.DoEvents();
													//------------------------------------------------------------



													strQuery6 = "UPDATE Aircraft_Model   SET amod_misc_train_cost =  ";
													strQuery6 = $"{strQuery6} ((amod_tot_hour_direct_cost * 20) + 300)  ";

													strQuery6 = strQuery6;
													DbCommand TempCommand_11 = null;
													TempCommand_11 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
													UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_11);
													TempCommand_11.CommandText = strQuery6;
													//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
													//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
													TempCommand_11.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
													UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_11);
													TempCommand_11.ExecuteNonQuery();
													Application.DoEvents();
													Application.DoEvents();
													JetNetSupport.PInvoke.SafeNative.kernel32.Sleep(50);
													Application.DoEvents();
													Application.DoEvents();
													Application.DoEvents();
													//------------------------------------------------------------


													//------------------------------------------------------------
													// 09/03/2021  - MSW - to update Total Direct Cost On the Fly
													// Updated Total Hour Direct Cost Records

													strQuery7 = "UPDATE Aircraft_Model  SET amod_misc_modern_cost =  ";
													strQuery7 = $"{strQuery7} (amod_misc_train_cost * 1.3)  ";
													strQuery7 = $"{strQuery7} where amod_weight_class = 'H' "; // - -1.3

													strQuery7 = strQuery7;
													DbCommand TempCommand_12 = null;
													TempCommand_12 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
													UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_12);
													TempCommand_12.CommandText = strQuery7;
													//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
													//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
													TempCommand_12.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
													UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_12);
													TempCommand_12.ExecuteNonQuery();
													Application.DoEvents();
													Application.DoEvents();
													JetNetSupport.PInvoke.SafeNative.kernel32.Sleep(50);
													Application.DoEvents();
													Application.DoEvents();
													Application.DoEvents();

													strQuery7 = "UPDATE Aircraft_Model  SET amod_misc_modern_cost =  ";
													strQuery7 = $"{strQuery7} (amod_misc_train_cost * 1.7)  ";
													strQuery7 = $"{strQuery7} where amod_weight_class = 'M' "; // - -1.7

													strQuery7 = strQuery7;
													DbCommand TempCommand_13 = null;
													TempCommand_13 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
													UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_13);
													TempCommand_13.CommandText = strQuery7;
													//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
													//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
													TempCommand_13.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
													UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_13);
													TempCommand_13.ExecuteNonQuery();

													Application.DoEvents();
													Application.DoEvents();
													JetNetSupport.PInvoke.SafeNative.kernel32.Sleep(50);
													Application.DoEvents();
													Application.DoEvents();


													strQuery7 = "UPDATE Aircraft_Model  SET amod_misc_modern_cost =  ";
													strQuery7 = $"{strQuery7} (amod_misc_train_cost * 1.8)  ";
													strQuery7 = $"{strQuery7} where amod_weight_class = 'V' "; // - -1.8

													strQuery7 = strQuery7;
													DbCommand TempCommand_14 = null;
													TempCommand_14 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
													UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_14);
													TempCommand_14.CommandText = strQuery7;
													//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
													//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
													TempCommand_14.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
													UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_14);
													TempCommand_14.ExecuteNonQuery();
													Application.DoEvents();
													Application.DoEvents();
													JetNetSupport.PInvoke.SafeNative.kernel32.Sleep(50);
													Application.DoEvents();
													Application.DoEvents();

													strQuery7 = "UPDATE Aircraft_Model  SET amod_misc_modern_cost =  ";
													strQuery7 = $"{strQuery7} (amod_misc_train_cost * 1.9)  ";
													strQuery7 = $"{strQuery7} where amod_weight_class = 'L' "; // - -1.9

													strQuery7 = strQuery7;
													DbCommand TempCommand_15 = null;
													TempCommand_15 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
													UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_15);
													TempCommand_15.CommandText = strQuery7;
													//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
													//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
													TempCommand_15.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
													UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_15);
													TempCommand_15.ExecuteNonQuery();
													Application.DoEvents();
													Application.DoEvents();
													JetNetSupport.PInvoke.SafeNative.kernel32.Sleep(50);
													Application.DoEvents();
													Application.DoEvents();

													//------------------------------------------------------------

													strQuery5 = "UPDATE Aircraft_Model SET amod_variable_costs = dbo.ReturnAircraftModelVariableCost(amod_id) ";

													DbCommand TempCommand_16 = null;
													TempCommand_16 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
													UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_16);
													TempCommand_16.CommandText = strQuery5;
													//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
													//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
													TempCommand_16.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
													UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_16);
													TempCommand_16.ExecuteNonQuery();



													modAdminCommon.Record_Event("Aircraft Model", $"Updated JETA Fuel Price: ${strJetAFuelPrice} :{txt_fuel_price_notes[0].Text}", 0, 0, 0, false, 0, 0);
													modAdminCommon.Record_Event("Aircraft Model", $"Updated Low Lead Fuel Price: ${strLowLeadFuelPrice} :{txt_fuel_price_notes[1].Text}", 0, 0, 0, false, 0, 0);
													modAdminCommon.Record_Event("Aircraft Model", $"Updated Commercial Fuel Price: ${strCommercialFuelPrice} :{txt_fuel_price_notes[2].Text}", 0, 0, 0, false, 0, 0);
													modAdminCommon.Record_Event("Aircraft Model", $"Updated SAF Fuel Price: ${strCommercialFuelPrice} :{txt_fuel_price_notes[3].Text}", 0, 0, 0, false, 0, 0);


													IsLive = 0;
													strWhatDatabase = "";
													strWhatDatabase = modAdminCommon.LOCAL_ADO_DB.ConnectionString;
													IsLive = (strWhatDatabase.IndexOf("jetnet_ra_", StringComparison.CurrentCultureIgnoreCase) + 1);

													if (IsLive == 0)
													{

														//----------------------------------------------------------
														// Update Homebase App Config Fuel Cost
														if (Send_To_Evo(strQuery1))
														{

															//----------------------------------------------------------
															// Update Evolution App Config Fuel Cost
															if (Send_To_Evo(strQuery2))
															{

																//----------------------------------------------------------
																// Update Aircraft Model Fuel Gal Cost and Fuel Total Cost
																if (Send_To_Evo(strQuery3a))
																{

																	if (Send_To_Evo(strQuery3b))
																	{

																		if (Send_To_Evo(strQuery3c))
																		{

																			//----------------------------------------------------------
																			// Update Total Hour Direct Cost
																			if (Send_To_Evo(strQuery4))
																			{

																				//----------------------------------------------------------
																				// Update Variable Cost
																				if (Send_To_Evo(strQuery5))
																				{

																					MessageBox.Show("Update To Homebase And Evolution Executed", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));

																				}
																				else
																				{
																					MessageBox.Show("There was an error while trying to update the Evolution Database - #5", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
																				} // If Send_To_Evo(strQuery4) = True Then

																			}
																			else
																			{
																				MessageBox.Show("There was an error while trying to update the Evolution Database - #4", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
																			} // If Send_To_Evo(strQuery4) = True Then

																		}
																		else
																		{
																			MessageBox.Show("There was an error while trying to update the Evolution Database - #3c", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
																		} // If Send_To_Evo(strQuery3c) = True Then

																	}
																	else
																	{
																		MessageBox.Show("There was an error while trying to update the Evolution Database - #3b", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
																	} // If Send_To_Evo(strQuery3b) = True Then

																}
																else
																{
																	MessageBox.Show("There was an error while trying to update the Evolution Database - #3a", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
																} // If Send_To_Evo(strQuery3a) = True Then

															}
															else
															{
																MessageBox.Show("There was an error while trying to update the Evolution Database - #2", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
															} // If Send_To_Evo(strQuery2) = True Then

														}
														else
														{
															MessageBox.Show("There was an error while trying to update the Evolution Database - #1", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
														} // If Send_To_Evo(strQuery1) = True Then

													}
													else
													{
														MessageBox.Show("Update To Homebase Executed", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
													} // If IsLive = 0 Then

												}
												else
												{
													MessageBox.Show("Please enter a numeric value for the Commercial Fuel Price", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
												} // If IsNumeric(strCommercialFuelPrice) = True Then

											}
											else
											{
												MessageBox.Show("Please enter a Commercial Fuel Price in the text box", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
											} // If strCommercialFuelPrice <> "" Then

										}
										else
										{
											MessageBox.Show("Please enter a numeric value for the Low Lead Fuel Price", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
										} // If IsNumeric(strLowLeadFuelPrice) = True Then

									}
									else
									{
										MessageBox.Show("Please enter a Low Lead Fuel Price in the text box", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
									} // If strLowLeadFuelPrice <> "" Then

								}
								else
								{
									MessageBox.Show("Please enter a numeric value for the JETA Fuel Price", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
								} // If IsNumeric(strJetAFuelPrice) = True Then

							}
							else
							{
								MessageBox.Show("Please enter a JETA Fuel Price in the text box", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							} // If strJetAFuelPrice <> "" Then

						}
						else
						{
							MessageBox.Show("Do NOT Have a Valid Evo-Con Id For This Operation", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						}  // If IsNumeric(lbl_generic(9).Caption) = True Then 
						 
						break;
				} // Select Case Index
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"cmd_button_Click - Index: {Index.ToString()} - {excep.Message}");

				this.Cursor = CursorHelper.CursorDefault;
				Is_Dirty = false;
			}

		} // cmd_button_Click


		public bool Send_To_Evo(string strQuery)
		{

			bool result = false;
			string strEvoServer = "";
			string strEvoUser = "";
			string strEvoPassword = "";

			DbConnection cntConn = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateConnection();
			string strConn = "";

			bool bResults = false;

			try
			{

				bResults = false;

				strEvoServer = modAdminCommon.DLookUp("aconfig_evo_sql_server", "Application_Configuration");
				strEvoUser = modAdminCommon.DLookUp("aconfig_evo_sql_user", "Application_Configuration");
				strEvoPassword = modAdminCommon.DLookUp("aconfig_evo_sql_password", "Application_Configuration");

				strConn = $"Provider=SQLOLEDB;" +
				          $"Data Source={strEvoServer};" +
				          $"Initial Catalog=jetnet_ra;" +
				          $"User Id={strEvoUser};" +
				          $"Password={strEvoPassword};";

				//UPGRADE_ISSUE: (2064) ADODB.Connection property cntConn.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				cntConn.setCursorLocation(CursorLocationEnum.adUseServer);
				//UPGRADE_ISSUE: (2064) ADODB.Connection property cntConn.ConnectionTimeout was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				cntConn.setConnectionTimeout(30);
				UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(cntConn, 120);
				//UPGRADE_TODO: (7010) The connection string must be verified to fullfill the .NET data provider connection string requirements. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-7010
				cntConn.ConnectionString = strConn;
				cntConn.Open();

				DbCommand TempCommand = null;
				TempCommand = cntConn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = strQuery;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();

				UpgradeHelpers.DB.TransactionManager.DeEnlist(cntConn);
				cntConn.Close();
				cntConn = null;

				bResults = true;


				return bResults;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"Send_To_Evo_Error{excep.Message}");
				this.Cursor = CursorHelper.CursorDefault;
				Is_Dirty = false;
				result = false;
			}
			return result;
		} // Send_To_Evo

		private void Load_grd_ABI_Hide_AC()
		{
			try
			{
				int nRow = 0;
				string Query = "";
				ADORecordSetHelper RS_Table = new ADORecordSetHelper();
				grd_ABI_Hide_AC.Clear();
				grd_ABI_Hide_AC.CurrentRowIndex = 0;
				grd_ABI_Hide_AC.CurrentColumnIndex = 0;
				grd_ABI_Hide_AC[grd_ABI_Hide_AC.CurrentRowIndex, grd_ABI_Hide_AC.CurrentColumnIndex].Value = "AC_ID";
				grd_ABI_Hide_AC.CurrentColumnIndex = 1;
				grd_ABI_Hide_AC[grd_ABI_Hide_AC.CurrentRowIndex, grd_ABI_Hide_AC.CurrentColumnIndex].Value = "Make";
				grd_ABI_Hide_AC.CurrentColumnIndex = 2;
				grd_ABI_Hide_AC[grd_ABI_Hide_AC.CurrentRowIndex, grd_ABI_Hide_AC.CurrentColumnIndex].Value = "Model";
				grd_ABI_Hide_AC.CurrentColumnIndex = 3;
				grd_ABI_Hide_AC[grd_ABI_Hide_AC.CurrentRowIndex, grd_ABI_Hide_AC.CurrentColumnIndex].Value = "Serial_Num";
				grd_ABI_Hide_AC.SetColumnWidth(0, 53);
				grd_ABI_Hide_AC.SetColumnWidth(1, 120);
				grd_ABI_Hide_AC.SetColumnWidth(2, 120);
				grd_ABI_Hide_AC.SetColumnWidth(3, 147);
				grd_ABI_Hide_AC.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
				grd_ABI_Hide_AC.ColAlignment[0] = DataGridViewContentAlignment.MiddleLeft;
				grd_ABI_Hide_AC.ColAlignment[1] = DataGridViewContentAlignment.MiddleLeft;
				grd_ABI_Hide_AC.ColAlignment[2] = DataGridViewContentAlignment.MiddleLeft;
				grd_ABI_Hide_AC.ColAlignment[3] = DataGridViewContentAlignment.MiddleLeft;
				nRow = 1;
				grd_ABI_Hide_AC.CurrentRowIndex = nRow;
				Query = "SELECT DISTINCT aadns_ac_id, ac_ser_no_full, amod_make_name, amod_model_name";
				Query = $"{Query} FROM ABI_Aircraft_Do_Not_Show INNER JOIN Aircraft ON aadns_ac_id = ac_id INNER JOIN Aircraft_Model ON ac_amod_id  =  amod_id Order By aadns_ac_id ASC";

				RS_Table.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);
				if (!(RS_Table.BOF && RS_Table.EOF))
				{

					while(!RS_Table.EOF)
					{
						grd_ABI_Hide_AC.CurrentColumnIndex = 0;
						grd_ABI_Hide_AC[grd_ABI_Hide_AC.CurrentRowIndex, grd_ABI_Hide_AC.CurrentColumnIndex].Value = ($"{Convert.ToString(RS_Table["aadns_ac_id"])}").Trim();
						grd_ABI_Hide_AC.CurrentColumnIndex = 1;
						grd_ABI_Hide_AC[grd_ABI_Hide_AC.CurrentRowIndex, grd_ABI_Hide_AC.CurrentColumnIndex].Value = ($"{Convert.ToString(RS_Table["amod_make_name"])}").Trim();
						grd_ABI_Hide_AC.CurrentColumnIndex = 2;
						grd_ABI_Hide_AC[grd_ABI_Hide_AC.CurrentRowIndex, grd_ABI_Hide_AC.CurrentColumnIndex].Value = ($"{Convert.ToString(RS_Table["amod_model_name"])}").Trim();
						grd_ABI_Hide_AC.CurrentColumnIndex = 3;
						grd_ABI_Hide_AC[grd_ABI_Hide_AC.CurrentRowIndex, grd_ABI_Hide_AC.CurrentColumnIndex].Value = ($"{Convert.ToString(RS_Table["ac_ser_no_full"])}").Trim();

						nRow++;
						grd_ABI_Hide_AC.RowsCount = nRow + 1;
						grd_ABI_Hide_AC.CurrentRowIndex = nRow;
						RS_Table.MoveNext();
					};
					RS_Table.MoveFirst();
					Text1[0].Text = ($"{Convert.ToString(RS_Table["aadns_ac_id"])}").Trim();
					lbl_generic[5].Text = ($"{Convert.ToString(RS_Table["amod_make_name"])}").Trim();
					lbl_generic[6].Text = ($"{Convert.ToString(RS_Table["amod_model_name"])}").Trim();
				}
				else
				{
					lbl_generic[7].Text = grd_ABI_Hide_AC[grd_ABI_Hide_AC.CurrentRowIndex, grd_ABI_Hide_AC.CurrentColumnIndex].FormattedValue.ToString();
					lbl_generic[1].Visible = false;
					lbl_generic[3].Visible = false;
					lbl_generic[4].Visible = false;
					lbl_generic[5].Visible = false;
					lbl_generic[6].Visible = false;
					lbl_generic[7].Visible = false;
					Text1[0].Visible = false;
					lbl_generic[0].Visible = false;
					cmd_button[0].Text = "Add";
				}
				RS_Table.Close();
				//grd_ABI_Hide_AC.Rows = Grd.Rows - 1
				grd_ABI_Hide_AC.Refresh();
			}
			catch (System.Exception excep)
			{
				this.Cursor = CursorHelper.CursorDefault;
				Is_Dirty = false;
				modAdminCommon.Report_Error($"Load_grd_ABI_Hide_AC{excep.Message}");
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1065
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
				return;
			}

		}

		private void cmd_Cancel_Aircraft_Class_Click(Object eventSender, EventArgs eventArgs) => pnl_Aircraft_Class_AddUpdate.Visible = false;


		private void cmd_Cancel_Aircraft_Contact_Type_Click(Object eventSender, EventArgs eventArgs)
		{

			pnl_ACTypeMain.Visible = false;
			pnl_Aircraft_Contact_Type_AddUpdate.Visible = false;
			Aircraft_Contact_Type("Fill List");

		}

		private void cmd_Cancel_Aircraft_Type_Click(Object eventSender, EventArgs eventArgs) => pnl_Aircraft_Type_AddUpdate.Visible = false;


		private void cmd_Cancel_APU_Click(Object eventSender, EventArgs eventArgs) => pnl_APU_Update_Change.Visible = false;


		private void cmd_Cancel_Asking_Click(Object eventSender, EventArgs eventArgs) => pnl_NameDesc_Asking.Visible = false;


		private void cmd_Cancel_Avionics_Click(Object eventSender, EventArgs eventArgs) => pnl_avionics_Update_Change.Visible = false;


		private void cmd_Cancel_Certification_Click(Object eventSender, EventArgs eventArgs) => pnl_Certification_Update_Change.Visible = false;


		private void cmd_cancel_certified_Click(Object eventSender, EventArgs eventArgs) => pnl_Certified_Update_Change.Visible = false;


		private void cmd_Cancel_EMP_Click(Object eventSender, EventArgs eventArgs) => pnl_EMP_AddUpdate.Visible = false;


		private void cmd_Cancel_IC_Click(Object eventSender, EventArgs eventArgs)
		{

			pnl_IC_Update_Change.Visible = false;
			this.Cursor = CursorHelper.CursorDefault;

		}

		private void cmd_cancel_spec_Click(Object eventSender, EventArgs eventArgs) => pnl_Spec_Update_Change.Visible = false;


		private void cmd_certified_add_Click(Object eventSender, EventArgs eventArgs)
		{
			RecordStat = "Add";
			pnl_Certified_Update_Change.Visible = true;
			txt_cert_name_cert.Enabled = true;

		}

		private void cmd_CloseAutoModel_Click(Object eventSender, EventArgs eventArgs)
		{
			frame_automodels.Visible = false;
			FG_KeyFeature.Visible = true;
		}
		private void Fill_Key_Feature_Auto_List()
		{

			ADORecordSetHelper ado_KeyFeature = default(ADORecordSetHelper);
			try
			{
				string Query = "";
				ado_KeyFeature = new ADORecordSetHelper();
				cmd_CloseAutoModel.Visible = false;
				int RememberTimeout = 0;
				this.Cursor = Cursors.WaitCursor;
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Selecting Aircraft Model List Based on Rules ...", Color.Blue);

				grd_AutoMod.Clear();
				grd_AutoMod.ColumnsCount = 4;
				grd_AutoMod.RowsCount = 1;

				grd_AutoMod.CurrentRowIndex = 0;
				grd_AutoMod.CurrentColumnIndex = 0;
				grd_AutoMod.SetColumnWidth(0, 133);
				grd_AutoMod.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
				grd_AutoMod[grd_AutoMod.CurrentRowIndex, grd_AutoMod.CurrentColumnIndex].Value = "Make";
				grd_AutoMod.CellBackColor = grd_AutoMod.BackColorFixed;

				grd_AutoMod.CurrentColumnIndex = 1;
				grd_AutoMod.SetColumnWidth(1, 113);
				grd_AutoMod.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
				grd_AutoMod[grd_AutoMod.CurrentRowIndex, grd_AutoMod.CurrentColumnIndex].Value = "Model";
				grd_AutoMod.CellBackColor = grd_AutoMod.BackColorFixed;

				grd_AutoMod.CurrentColumnIndex = 2;
				grd_AutoMod.SetColumnWidth(2, 53);
				grd_AutoMod.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
				grd_AutoMod[grd_AutoMod.CurrentRowIndex, grd_AutoMod.CurrentColumnIndex].Value = "Assigned";
				grd_AutoMod.CellBackColor = grd_AutoMod.BackColorFixed;

				grd_AutoMod.CurrentColumnIndex = 3;
				grd_AutoMod.SetColumnWidth(3, 40);
				grd_AutoMod.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
				grd_AutoMod[grd_AutoMod.CurrentRowIndex, grd_AutoMod.CurrentColumnIndex].Value = "#AC";
				grd_AutoMod.CellBackColor = grd_AutoMod.BackColorFixed;



				Query = ($"{txt_kfeat_query.Text}").Trim().ToLower();
				Query = StringsHelper.Replace(Query, "as expr1", "", 1, -1, CompareMethod.Binary);
				Query = StringsHelper.Replace(Query, "count(*)", "distinct amod_id, amod_make_name, amod_model_name, count(*) as tcount", 1, -1, CompareMethod.Binary);

				Query = $"{Query} group by amod_id, amod_make_name, amod_model_name  order by amod_make_name, amod_model_name";
				RememberTimeout = UpgradeHelpers.DB.DbConnectionHelper.GetCommandTimeOut(modAdminCommon.LOCAL_ADO_DB);
				UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(modAdminCommon.LOCAL_ADO_DB, 1000);
				ado_KeyFeature.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
				UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(modAdminCommon.LOCAL_ADO_DB, RememberTimeout);
				if (!(ado_KeyFeature.BOF && ado_KeyFeature.EOF))
				{

					while(!ado_KeyFeature.EOF)
					{

						grd_AutoMod.RowsCount++;
						grd_AutoMod.CurrentRowIndex++;

						// ENTER THE MAKE
						grd_AutoMod.CurrentColumnIndex = 0;
						grd_AutoMod[grd_AutoMod.CurrentRowIndex, grd_AutoMod.CurrentColumnIndex].Value = $" {Convert.ToString(ado_KeyFeature["amod_make_name"])}";


						// ENTER THE MODEL
						grd_AutoMod.CurrentColumnIndex = 1;
						grd_AutoMod[grd_AutoMod.CurrentRowIndex, grd_AutoMod.CurrentColumnIndex].Value = $" {Convert.ToString(ado_KeyFeature["amod_model_name"])}";


						grd_AutoMod.CurrentColumnIndex = 2;
						Query = $"select * from Aircraft_Model_Key_Feature where amfeat_amod_id = {Convert.ToString(ado_KeyFeature["amod_id"])} ";
						Query = $"{Query}and amfeat_feature_code = '{txt_kfeat_code.Text.Trim()}' ";
						if (modAdminCommon.Exist(Query))
						{
							grd_AutoMod[grd_AutoMod.CurrentRowIndex, grd_AutoMod.CurrentColumnIndex].Value = "YES";
						}
						else
						{
							grd_AutoMod[grd_AutoMod.CurrentRowIndex, grd_AutoMod.CurrentColumnIndex].Value = "NO";
						}


						grd_AutoMod.CurrentColumnIndex = 3;
						grd_AutoMod[grd_AutoMod.CurrentRowIndex, grd_AutoMod.CurrentColumnIndex].Value = $" {Convert.ToString(ado_KeyFeature["tcount"])}";

						ado_KeyFeature.MoveNext();
					};
				}
				else
				{
					// INDICATE NO FEATURES FOR THIS MODEL
					grd_AutoMod.RowsCount++;
					grd_AutoMod.CurrentRowIndex++;
					grd_AutoMod.CurrentColumnIndex = 2;
					grd_AutoMod[grd_AutoMod.CurrentRowIndex, grd_AutoMod.CurrentColumnIndex].Value = "None Found";

				}


				this.Cursor = CursorHelper.CursorDefault;
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
				// CLOSE RECORSET
				if (ado_KeyFeature != null)
				{
					if (ado_KeyFeature.State == ConnectionState.Open)
					{ // Already Open Close It
						ado_KeyFeature.Close();
					}
					ado_KeyFeature = null;
				}
				cmd_CloseAutoModel.Visible = true;
			}
			catch
			{

				// INDICATE ERROR IN GETTING RULE FOR THE MODEL
				cmd_CloseAutoModel.Visible = true;
				grd_AutoMod.RowsCount++;
				grd_AutoMod.CurrentRowIndex++;
				grd_AutoMod.CurrentColumnIndex = 0;
				grd_AutoMod[grd_AutoMod.CurrentRowIndex, grd_AutoMod.CurrentColumnIndex].Value = "Unable to select";

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
				modAdminCommon.Report_Error("Fill_Key_Feature_Auto_List_Error: ");

				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
			}

		}

		private void cmd_Delete_Aircraft_Class_Click(Object eventSender, EventArgs eventArgs)
		{

			string M = "";
			string Query = "";
			DialogResult RESP = (DialogResult) 0;

			if (modAdminCommon.Exist($"SELECT * FROM Aircraft_Model WHERE amod_class_code = '{txt_aclass_code.Text}'"))
			{
				M = $"Aircraft Class   '{txt_aclass_code.Text}',   currently used in the Aircraft Model Table.";
				MessageBox.Show(M, "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else if (modAdminCommon.Exist($"SELECT * FROM Aircraft_Class WHERE aclass_code = '{txt_aclass_code.Text}'"))
			{ 

				this.Cursor = Cursors.WaitCursor;
				Query = "DELETE FROM Aircraft_Class";
				Query = $"{Query} WHERE aclass_code='{txt_aclass_code.Text.Trim()}'";
				M = $"Aircraft Class Delete For: {txt_aclass_code.Text.Trim()}{"\r"}{"\r"}";
				M = $"{M}Do you wish to perform the delete at this time?";
				RESP = MessageBox.Show(M, "Confirm Delete!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (RESP == System.Windows.Forms.DialogResult.Yes)
				{
					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = Query;
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();
					FG_Aircraft_Class.RemoveItem(FG_Aircraft_Class.CurrentRowIndex);
					FG_Aircraft_Class.Refresh();
					MessageBox.Show("Delete Successfully Completed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}
				else
				{
					MessageBox.Show("Delete Cancelled!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}

			}
			else
			{
				M = $"Aircraft Class   '{txt_aclass_code.Text}',   not currently in the Aircraft Class Table.";
				MessageBox.Show(M, "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}

			this.Cursor = CursorHelper.CursorDefault;
			pnl_Aircraft_Class_AddUpdate.Visible = false;

		}

		private void cmd_Delete_Aircraft_Contact_Type_Click(Object eventSender, EventArgs eventArgs)
		{

			string M = "";

			if (modAdminCommon.Exist($"SELECT * FROM Aircraft_Reference WHERE cref_contact_type = '{txt_actype_code.Text}'"))
			{
				M = $"Aircraft Contact Type Code   '{txt_actype_code.Text}',   currently used in the Aircraft Reference Table.";
				MessageBox.Show(M, "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else if (modAdminCommon.Exist($"SELECT * FROM Aircraft_Contact_Type WHERE actype_code = '{txt_actype_code.Text}'"))
			{ 
				Aircraft_Contact_Type("Delete");
			}
			else
			{
				M = $"Aircraft Contact Type   '{txt_actype_code.Text}',   currently not in the Aircraft Contact Type Table.";
				MessageBox.Show(M, "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}

		}

		private void cmd_Delete_Aircraft_Type_Click(Object eventSender, EventArgs eventArgs)
		{
			//AEY 4/21/2004

			string M = "";
			string Query = "";
			DialogResult RESP = (DialogResult) 0;

			if (modAdminCommon.Exist($"select * from Aircraft_Model where amod_type_code = '{txt_atype_code.Text}'"))
			{
				M = $"Aircraft Type Code   '{txt_atype_code.Text}',   currently used in the Aircraft Model Table.";
				MessageBox.Show(M, "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else if (modAdminCommon.Exist($"select * from Aircraft_Type where atype_code = '{txt_atype_code.Text}'"))
			{ 
				//Aircraft_Type ("Delete")

				this.Cursor = Cursors.WaitCursor;
				Query = "DELETE FROM Aircraft_Type";
				Query = $"{Query} WHERE atype_code='{txt_atype_code.Text.Trim()}'";
				M = $"Aircraft Type Delete For: {txt_atype_code.Text.Trim()}{"\r"}{"\r"}";
				M = $"{M}Do you wish to perform the delete at this time?";
				RESP = MessageBox.Show(M, "Confirm Delete!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (RESP == System.Windows.Forms.DialogResult.Yes)
				{
					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = Query;
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();
					Is_Dirty = true;
					FG_Aircraft_Type.RemoveItem(FG_Aircraft_Type.CurrentRowIndex);
					FG_Aircraft_Type.Refresh();
					MessageBox.Show("Delete Successfully Completed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}
				else
				{
					MessageBox.Show("Delete Cancelled!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}
			}
			else
			{
				M = $"Aircraft Type Code   '{txt_atype_code.Text}',   not currently in the Aircraft Model Table.";
				MessageBox.Show(M, "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}

			pnl_Aircraft_Type_AddUpdate.Visible = false;
			this.Cursor = CursorHelper.CursorDefault;

		}

		private void cmd_Delete_APU_Click(Object eventSender, EventArgs eventArgs)
		{

			string M = "";
			string Query = "";
			DialogResult RESP = (DialogResult) 0;

			if (modAdminCommon.Exist($"select * from Aircraft with (NOLOCK) where ac_apu_model_name = '{txt_apu_make_name.Text}'"))
			{
				M = $"Auxiliary Power Unit   '{txt_apu_make_name.Text}'   currently used in the Aircraft Table.";
				MessageBox.Show(M, "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else if (modAdminCommon.Exist($"SELECT * FROM Auxilliary_Power_Unit where apu_make_name = '{txt_apu_make_name.Text}'"))
			{ 

				Query = "DELETE FROM Auxilliary_Power_Unit ";
				Query = $"{Query}WHERE apu_make_name='{txt_apu_make_name.Text.Trim()}'";
				M = $"Aircraft Asking Delete For: {txt_apu_make_name.Text.Trim()}{"\r"}{"\r"}";
				M = $"{M}Do you wish to perform the delete at this time?";
				RESP = MessageBox.Show(M, "Confirm Delete!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (RESP == System.Windows.Forms.DialogResult.Yes)
				{
					this.Cursor = Cursors.WaitCursor;
					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = Query;
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();
					Is_Dirty = true;
					FG_Auxiliary_Power.RemoveItem(FG_Auxiliary_Power.CurrentRowIndex);
					FG_Auxiliary_Power.Refresh();
					MessageBox.Show("Delete Successfully Completed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}
				else
				{
					MessageBox.Show("Delete Cancelled!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}
			}
			else
			{
				M = $"Auxiliary Power Unit   '{txt_apu_make_name.Text}'   not currently in the Aircraft Table.";
				MessageBox.Show(M, "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}

			pnl_APU_Update_Change.Visible = false;
			this.Cursor = CursorHelper.CursorDefault;

		}

		private void cmd_Delete_Avionics_Click(Object eventSender, EventArgs eventArgs)
		{

			string M = "";
			string Query = "";
			DialogResult RESP = (DialogResult) 0;

			if (modAdminCommon.Exist($"select * from Aircraft_Avionics where av_name = '{txt_avion_name.Text}'"))
			{
				M = $"Avionics Name   '{txt_avion_name.Text}'   currently used in the Aircraft_Avionics Table.";
				MessageBox.Show(M, "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else if (modAdminCommon.Exist($"SELECT * FROM Avionics where avion_name = '{txt_avion_name.Text}'"))
			{ 

				this.Cursor = Cursors.WaitCursor;
				Query = "DELETE FROM Avionics ";
				Query = $"{Query}WHERE avion_name='{txt_avion_name.Text.Trim()}'";
				M = $"Aircraft Asking Delete For: {txt_avion_name.Text.Trim()}{"\r"}{"\r"}";
				M = $"{M}Do you wish to perform the delete at this time?";
				RESP = MessageBox.Show(M, "Confirm Delete!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (RESP == System.Windows.Forms.DialogResult.Yes)
				{
					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = Query;
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();
					FG_Avionics.RemoveItem(FG_Avionics.CurrentRowIndex);
					FG_Avionics.Refresh();

					MessageBox.Show("Delete Successfully Completed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}
				else
				{
					MessageBox.Show("Delete Cancelled!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}


			}
			else
			{
				M = $"Avionics Name   '{txt_avion_name.Text}'   not currently in the Avionics Table.";
				MessageBox.Show(M, "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}

			pnl_avionics_Update_Change.Visible = false;
			this.Cursor = CursorHelper.CursorDefault;

		}

		private void cmd_Delete_Certification_Click(Object eventSender, EventArgs eventArgs)
		{
			//aey 4/21/2004 Certification ("Delete")

			string M = "";
			string Query = "";
			DialogResult RESP = (DialogResult) 0;

			if (modAdminCommon.Exist($"select * from Aircraft_Certified where accert_name = '{txt_certification_name[0].Text}'"))
			{
				M = $"Aircraft Certification   '{txt_certification_name[0].Text}'   currently used in the Aircraft_Certified Table.";
				MessageBox.Show(M, "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else if (modAdminCommon.Exist($"SELECT * FROM Certification where certification_name = '{txt_certification_name[0].Text}'"))
			{ 

				Query = $"DELETE FROM Certification WHERE certification_name='{txt_certification_name[0].Text.Trim()}'";
				M = $"Certification Delete For: {txt_certification_name[0].Text.Trim()}{"\r"}{"\r"}";
				M = $"{M}Do you wish to perform the delete at this time?";
				RESP = MessageBox.Show(M, "Confirm Delete!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (RESP == System.Windows.Forms.DialogResult.Yes)
				{
					this.Cursor = Cursors.WaitCursor;
					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = Query;
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();
					Is_Dirty = true;
					FG_Operating_Certification.RemoveItem(FG_Operating_Certification.CurrentRowIndex);
					FG_Operating_Certification.Refresh();
					MessageBox.Show("Delete Successfully Completed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}
				else
				{
					MessageBox.Show("Delete Cancelled!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}

			}
			else
			{
				M = $"Aircraft Certification   '{txt_certification_name[0].Text}'   not currently in the Aircraft_Certified Table.";
				MessageBox.Show(M, "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}

			pnl_Certification_Update_Change.Visible = false;
			this.Cursor = CursorHelper.CursorDefault;

		}

		private void cmd_delete_certified_Click(Object eventSender, EventArgs eventArgs)
		{
			//aey 4/28/2004

			string M = "";
			string Query = "";
			DialogResult RESP = (DialogResult) 0;

			if (Strings.Len(($"{txt_cert_name_cert.Text}").Trim()) == 0)
			{
				return;
			}
			this.Cursor = Cursors.WaitCursor;

			if (modAdminCommon.Exist($"select * from Aircraft_Certified where accert_name = '{txt_cert_name_cert.Text}'"))
			{
				M = $"Aircraft Certification   '{txt_cert_name_cert.Text}'   currently used in the Aircraft_Certified Table.";
				MessageBox.Show(M, "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else if (modAdminCommon.Exist($"SELECT * FROM Certified where cert_name = '{txt_cert_name_cert.Text}'"))
			{ 


				Query = $"DELETE FROM Certified  WHERE cert_name='{txt_cert_name_cert.Text.Trim()}'";
				M = $"certified Delete For: {txt_cert_name_cert.Text.Trim()}{"\r"}{"\r"}";
				M = $"{M}Do you wish to perform the delete at this time?";
				RESP = MessageBox.Show(M, "Confirm Delete!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (RESP == System.Windows.Forms.DialogResult.Yes)
				{
					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = Query;
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();
					Is_Dirty = true;
					FGRD_Certifed.RemoveItem(FGRD_Certifed.CurrentRowIndex);
					FGRD_Certifed.Refresh();
					MessageBox.Show("Delete Successfully Completed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}
				else
				{
					MessageBox.Show("Delete Cancelled!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}

			}
			else
			{
				M = $"Aircraft Certification   '{txt_cert_name_cert.Text}'   not currently in the Aircraft_Certified Table.";
				MessageBox.Show(M, "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			this.Cursor = CursorHelper.CursorDefault;

			pnl_Certified_Update_Change.Visible = false;

		}

		private void cmd_Delete_EMP_Click(Object eventSender, EventArgs eventArgs)
		{
			//aey 4/21/2004

			string M = "";
			string Query = "";
			DialogResult RESP = (DialogResult) 0;

			if (modAdminCommon.Exist($"SELECT * FROM Aircraft with (NOLOCK) WHERE ac_engine_maint_prog = '{txt_emp_code.Text}'"))
			{
				M = $"Engine Maintenance Program   '{txt_emp_code.Text}',   currently used in the Aircraft Table.";
				MessageBox.Show(M, "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else if (modAdminCommon.Exist($"select * from Engine_maintenance_Program where emp_code = '{txt_emp_code.Text}'"))
			{ 

				Query = $"DELETE FROM Engine_Maintenance_Program WHERE emp_code='{txt_emp_code.Text.Trim()}'";
				M = $"Engine_Maintenance_Program Delete For: {txt_emp_code.Text.Trim()}{"\r"}{"\r"}";
				M = $"{M}Do you wish to perform the delete at this time?";
				RESP = MessageBox.Show(M, "Confirm Delete!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (RESP == System.Windows.Forms.DialogResult.Yes)
				{
					this.Cursor = Cursors.WaitCursor;
					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = Query;
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();
					FG_Engine_Maintenance.RemoveItem(FG_Engine_Maintenance.CurrentRowIndex);
					FG_Engine_Maintenance.Refresh();

					//.Engine_Maintenance_Program ("Fill List")
					MessageBox.Show("Delete Successfully Completed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}
				else
				{
					MessageBox.Show("Delete Cancelled!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}
			}
			else
			{
				M = $"Engine Maintenance Program   '{txt_emp_code.Text}',   not currently in the Engine Maintenance Program Table.";
				MessageBox.Show(M, "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}

			pnl_EMP_AddUpdate.Visible = false;
			this.Cursor = CursorHelper.CursorDefault;

		}

		private void cmd_Delete_IC_Click(Object eventSender, EventArgs eventArgs)
		{

			string M = "";
			string Query = "";
			string RESP = "";

			if (modAdminCommon.Exist($"select * from Aircraft with (NOLOCK) where ac_interior_config_name = '{txt_intconfig_name.Text}'"))
			{
				M = $"Interior Configuration   '{txt_intconfig_name.Text}'   currently used in the Aircraft Table.";
				MessageBox.Show(M, "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else if (modAdminCommon.Exist($"SELECT * FROM Interior_Configuration where intconfig_name = '{txt_intconfig_name.Text}'"))
			{ 

				Query = $"DELETE FROM Interior_Configuration WHERE intconfig_name='{txt_intconfig_name.Text.Trim()}'";
				M = $"Interior_Configuration Delete For: {txt_intconfig_name.Text.Trim()}{"\r"}{"\r"}";
				M = $"{M}Do you wish to perform the delete at this time?";
				RESP = ((int) MessageBox.Show(M, "Confirm Delete!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)).ToString();
				if (RESP == ((int) System.Windows.Forms.DialogResult.Yes).ToString())
				{
					this.Cursor = Cursors.WaitCursor;
					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = Query;
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();
					Is_Dirty = true;
					FG_Interior_Configuration.RemoveItem(FG_Interior_Configuration.CurrentRowIndex);
					FG_Interior_Configuration.Refresh();
					MessageBox.Show("Delete Successfully Completed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}
				else
				{
					MessageBox.Show("Delete Cancelled!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}

			}
			else
			{
				M = $"Interior Configuration   '{txt_intconfig_name.Text}'   not currently in the Interior Configuration Table.";
				MessageBox.Show(M, "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}

			pnl_IC_Update_Change.Visible = false;
			this.Cursor = CursorHelper.CursorDefault;

		}

		private void cmd_delete_spec_Click(Object eventSender, EventArgs eventArgs)
		{

			string M = "";
			string Query = "";
			DialogResult RESP = (DialogResult) 0;

			if (modAdminCommon.Exist($"select * from Aircraft_Specification where acspec_name = '{txt_spec_name.Text}'"))
			{
				M = $"Specification   '{txt_spec_name.Text}'   currently used in the Aircraft Specification Table.";
				MessageBox.Show(M, "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else if (modAdminCommon.Exist($"SELECT * FROM Specification where spec_name = '{txt_spec_name.Text}'"))
			{ 

				Query = $"DELETE FROM Specification  WHERE spec_name='{txt_spec_name.Text.Trim()}'";
				M = $"Specification Delete For: {txt_spec_name.Text.Trim()}{"\r"}{"\r"}";
				M = $"{M}Do you wish to perform the delete at this time?";
				RESP = MessageBox.Show(M, "Confirm Delete!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (RESP == System.Windows.Forms.DialogResult.Yes)
				{
					this.Cursor = Cursors.WaitCursor;
					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = Query;
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();
					Is_Dirty = true;
					FG_Specification.RemoveItem(FG_Specification.CurrentRowIndex);
					FG_Specification.Refresh();
					MessageBox.Show("Delete Successfully Completed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}
				else
				{
					MessageBox.Show("Delete Cancelled!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}

			}
			else
			{
				M = $"Specification   '{txt_spec_name.Text}'   not currently in the Specification Table.";
				MessageBox.Show(M, "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}

			pnl_Spec_Update_Change.Visible = false;
			this.Cursor = CursorHelper.CursorDefault;

		}

		private void cmd_Launch_av_items_Click(Object eventSender, EventArgs eventArgs)
		{

			string sTextAddress = "http://www.homebase.com/selection_listing.aspx?item_name=&area=avionics&display=listing&homebase=Y";

			if (sTextAddress.Trim() != "")
			{


				try
				{
					ShellOpenURLInBrowser(modAdminCommon.gbl_User_Browser, sTextAddress);
					//
				}
				catch
				{
				}

			} // If Trim(sTextAddress) <> "" Then

		}

		private void cmd_maint_Click(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.cmd_maint, eventSender);

			int move_to_num = 0;
			int move_from_num = 0;
			string Query = "";

			if (Index == 0 || Index == 2)
			{
				clear_fields_maint();
				cmd_maint[0].Visible = true;
				cmd_maint[1].Visible = true;
				cmd_maint[4].Visible = true;
				txt_maint[3].Text = "0";
			}
			else if (Index == 1)
			{ 
				// add/update
				if (Information.IsNumeric(txt_maint[3].Text))
				{
					if (!txt_maint[0].Visible && txt_maint[0].Text == "0")
					{
						Query = "INSERT INTO Maintenance_Item ( mitem_name, ";
						Query = $"{Query}mitem_description,  mitem_duration, mitem_type,";
						Query = $"{Query}mitem_active_flag, mitem_load_flag, mitem_sort ";

						Query = $"{Query}) values ('{modAdminCommon.Fix_Quote(txt_maint[1].Text).Trim()}', ";
						Query = $"{Query}'{modAdminCommon.Fix_Quote(txt_maint[2].Text).Trim()}', ";
						Query = $"{Query}'{txt_maint[3].Text.Trim()}', ";
						Query = $"{Query}'{modAdminCommon.Fix_Quote(cbo_maint_type.Text).Trim()}' ";

						if (chk_maint[1].CheckState == CheckState.Checked)
						{
							Query = $"{Query},'Y'";
						}
						else
						{
							Query = $"{Query},'N'";
						}

						if (chk_maint[0].CheckState == CheckState.Checked)
						{
							Query = $"{Query},'Y'";
						}
						else
						{
							Query = $"{Query},'N'";
						}

						if (Information.IsNumeric(txt_maint[4].Text))
						{
							Query = $"{Query},'{modAdminCommon.Fix_Quote(txt_maint[4].Text).Trim()}' ";
						}
						else
						{
							Query = $"{Query},'99' ";
						}

						Query = $"{Query})";

						DbCommand TempCommand = null;
						TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
						TempCommand.CommandText = Query;
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
						TempCommand.ExecuteNonQuery();

						MessageBox.Show("Insert of Maintenance Item Successfully Completed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						display_maintenance_items("", 0);
						cmd_maint[0].Visible = false;
						cmd_maint[1].Visible = false;
						cmd_maint[4].Visible = false;
					}
					else if (txt_maint[0].Visible && txt_maint[0].Text != "0")
					{ 

						Query = "UPDATE Maintenance_Item set  mitem_name = ";
						Query = $"{Query}'{modAdminCommon.Fix_Quote(txt_maint[1].Text).Trim()}', ";


						Query = $"{Query}mitem_description = ";
						Query = $"{Query}'{modAdminCommon.Fix_Quote(txt_maint[2].Text).Trim()}', ";

						Query = $"{Query}mitem_duration = ";
						Query = $"{Query}'{txt_maint[3].Text.Trim()}', ";

						Query = $"{Query}mitem_type = ";
						Query = $"{Query}'{modAdminCommon.Fix_Quote(cbo_maint_type.Text).Trim()}', ";


						Query = $"{Query}mitem_sort = ";
						Query = $"{Query}'{modAdminCommon.Fix_Quote(txt_maint[4].Text).Trim()}' ";



						Query = $"{Query}, mitem_active_flag =  ";
						if (chk_maint[1].CheckState == CheckState.Checked)
						{
							Query = $"{Query}'Y'";
						}
						else
						{
							Query = $"{Query}'N'";
						}

						Query = $"{Query}, mitem_load_flag = ";
						if (chk_maint[0].CheckState == CheckState.Checked)
						{
							Query = $"{Query}'Y'";
						}
						else
						{
							Query = $"{Query}'N'";
						}

						Query = $"{Query} where mitem_id = {txt_maint[0].Text}";

						DbCommand TempCommand_2 = null;
						TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
						TempCommand_2.CommandText = Query;
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
						TempCommand_2.ExecuteNonQuery();

						MessageBox.Show("Update of Maintenance Item Successfully Completed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						display_maintenance_items("", 0);
						cmd_maint[0].Visible = false;
						cmd_maint[1].Visible = false;
						cmd_maint[4].Visible = false;
					}
				}
				else
				{
					MessageBox.Show("Month Duration Must Be Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK);
				}




			}
			else if (Index == 3)
			{ 
				display_maintenance_items("", 0);
			}
			else if (Index == 4)
			{ 
				// REMOVE
				if (txt_maint[0].Visible && txt_maint[0].Text != "0")
				{
					if (MessageBox.Show("Are You Sure you want to Delete this Maintenance Item?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
					{
						Query = $" Delete from Maintenance_Item where mitem_id = {txt_maint[0].Text}";
						DbCommand TempCommand_3 = null;
						TempCommand_3 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_3);
						TempCommand_3.CommandText = Query;
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_3);
						TempCommand_3.ExecuteNonQuery();

						MessageBox.Show("Delete of Maintenance Item Successfully Completed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						display_maintenance_items("", 0);
						clear_fields_maint();
						cmd_maint[0].Visible = false;
						cmd_maint[1].Visible = false;
						cmd_maint[4].Visible = false;
					}

				}
			}
			else if (Index == 5)
			{ 
				// up
				move_to_num = 0;
				move_from_num = 0;
				grd_maint_items.CurrentColumnIndex = 3;
				move_from_num = Convert.ToInt32(Double.Parse(grd_maint_items[grd_maint_items.CurrentRowIndex, grd_maint_items.CurrentColumnIndex].FormattedValue.ToString())); // if i have a 4
				move_to_num = move_from_num - 1; // then move it to 3

				Query = $"UPDATE Maintenance_Item set mitem_sort = '{move_from_num.ToString()}' "; // update the ones where it is 3, to 4

				Query = $"{Query} where mitem_sort = {move_to_num.ToString()}";
				Query = Query;
				DbCommand TempCommand_4 = null;
				TempCommand_4 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_4);
				TempCommand_4.CommandText = Query;
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_4);
				TempCommand_4.ExecuteNonQuery();

				Query = $"UPDATE Maintenance_Item set mitem_sort = '{move_to_num.ToString()}' ";
				grd_maint_items.CurrentColumnIndex = 0;
				Query = $"{Query} where mitem_id = {Convert.ToInt32(Double.Parse(grd_maint_items[grd_maint_items.CurrentRowIndex, grd_maint_items.CurrentColumnIndex].FormattedValue.ToString())).ToString()}";
				Query = Query;
				DbCommand TempCommand_5 = null;
				TempCommand_5 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_5);
				TempCommand_5.CommandText = Query;
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_5);
				TempCommand_5.ExecuteNonQuery();

				display_maintenance_items("", Convert.ToInt32(Double.Parse(grd_maint_items[grd_maint_items.CurrentRowIndex, grd_maint_items.CurrentColumnIndex].FormattedValue.ToString())));

			}
			else if (Index == 6)
			{ 
				// down

				move_to_num = 0;
				move_from_num = 0;
				grd_maint_items.CurrentColumnIndex = 3;
				move_from_num = Convert.ToInt32(Double.Parse(grd_maint_items[grd_maint_items.CurrentRowIndex, grd_maint_items.CurrentColumnIndex].FormattedValue.ToString())); // if i have a 4
				move_to_num = move_from_num + 1; // then move it to 3

				Query = $"UPDATE Maintenance_Item set mitem_sort = '{move_from_num.ToString()}' "; // update the ones where it is 3, to 4

				Query = $"{Query} where mitem_sort = {move_to_num.ToString()}";
				Query = Query;
				DbCommand TempCommand_6 = null;
				TempCommand_6 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_6);
				TempCommand_6.CommandText = Query;
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_6);
				TempCommand_6.ExecuteNonQuery();

				Query = $"UPDATE Maintenance_Item set mitem_sort = '{move_to_num.ToString()}' ";
				grd_maint_items.CurrentColumnIndex = 0;
				Query = $"{Query} where mitem_id = {Convert.ToInt32(Double.Parse(grd_maint_items[grd_maint_items.CurrentRowIndex, grd_maint_items.CurrentColumnIndex].FormattedValue.ToString())).ToString()}";
				Query = Query;
				DbCommand TempCommand_7 = null;
				TempCommand_7 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_7);
				TempCommand_7.CommandText = Query;
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_7);
				TempCommand_7.ExecuteNonQuery();

				display_maintenance_items("", Convert.ToInt32(Double.Parse(grd_maint_items[grd_maint_items.CurrentRowIndex, grd_maint_items.CurrentColumnIndex].FormattedValue.ToString())));


			}

		}


		private void cmd_post_Click(Object eventSender, EventArgs eventArgs)
		{
			modAdminCommon.Table_Action_Log("Maintenance_Item");
			MessageBox.Show("Entered into Action Log", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK);

		}

		private void cmd_Refresh_Airports_Click(Object eventSender, EventArgs eventArgs)
		{

			cbo_iata_index.Text = cbo_iata_index.Text.ToUpper();
			cbo_icao_index.Text = cbo_icao_index.Text.ToUpper();
			cbo_faaid_index.Text = cbo_faaid_index.Text.ToUpper();

			if (cmd_Refresh_Airports.Text == "&Stop")
			{
				StopIt = true;
			}
			else
			{
				StopIt = false;
				cmd_Refresh_Airports.Text = "&Stop";
				Airport_Fill_List();
			}
			cmd_Refresh_Airports.Text = "&Refresh";

		}

		private void cmd_Save_Aircraft_Class_Click(Object eventSender, EventArgs eventArgs)
		{
			//aey 4/21/004           Aircraft_Class ("Insert")

			string Query = "";

			try
			{

				switch(RecordStat)
				{
					case "Add" : 
						if (modAdminCommon.Exist($"select * from Aircraft_Class where aclass_code = '{txt_aclass_code.Text}'"))
						{
							MessageBox.Show($"Aircraft Class   '{txt_aclass_code.Text}',   currently used in the Aircraft Class Table. - ADD CANCELLED.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						}
						else
						{
							FG_Aircraft_Class.RowsCount++;
							FG_Aircraft_Class.CurrentRowIndex = FG_Aircraft_Class.RowsCount - 1;
							FG_Aircraft_Class.CurrentColumnIndex = 0;
							FG_Aircraft_Class[FG_Aircraft_Class.CurrentRowIndex, FG_Aircraft_Class.CurrentColumnIndex].Value = txt_aclass_code.Text.Trim();
							FG_Aircraft_Class.CurrentColumnIndex = 1;
							FG_Aircraft_Class[FG_Aircraft_Class.CurrentRowIndex, FG_Aircraft_Class.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_aclass_Name).Trim();

							Query = "INSERT INTO Aircraft_Class (aclass_code, aclass_name) VALUES (";
							Query = $"{Query}'{txt_aclass_code.Text.Trim()}','{modAdminCommon.Fix_Quote(txt_aclass_Name).Trim()}')";
							DbCommand TempCommand = null;
							TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
							TempCommand.CommandText = Query;
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
							TempCommand.ExecuteNonQuery();
							Is_Dirty = true;
							MessageBox.Show("Insert Successfully Completed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						} 
						break;
					case "Update" : 
						//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' 
						// Update 'Aircraft Class' record 
						//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' 
						FG_Aircraft_Class.CurrentColumnIndex = 0; 
						FG_Aircraft_Class[FG_Aircraft_Class.CurrentRowIndex, FG_Aircraft_Class.CurrentColumnIndex].Value = txt_aclass_code.Text.Trim(); 
						FG_Aircraft_Class.CurrentColumnIndex = 1; 
						FG_Aircraft_Class[FG_Aircraft_Class.CurrentRowIndex, FG_Aircraft_Class.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_aclass_Name).Trim(); 
						 
						Query = $"UPDATE Aircraft_Class SET aclass_code='{modAdminCommon.Fix_Quote(txt_aclass_code).Trim()}',"; 
						Query = $"{Query}aclass_name='{modAdminCommon.Fix_Quote(txt_aclass_Name).Trim()}'"; 
						Query = $"{Query} WHERE aclass_code='{txt_aclass_code.Text.Trim()}'"; 
						DbCommand TempCommand_2 = null; 
						TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand(); 
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2); 
						TempCommand_2.CommandText = Query; 
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2); 
						TempCommand_2.ExecuteNonQuery(); 
						Is_Dirty = true; 
						MessageBox.Show("Update Successfully Completed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly())); 
						break;
				}

				pnl_Aircraft_Class_AddUpdate.Visible = false;
				this.Cursor = CursorHelper.CursorDefault;
			}
			catch
			{

				this.Cursor = CursorHelper.CursorDefault;
				modAdminCommon.Report_Error("Aircraft_Class_Error: ");
			}
		}

		private void cmd_Cancel_Kfeat_Click(Object eventSender, EventArgs eventArgs)
		{

			pnl_kfeat_test.Visible = false;
			pnlAdmin.Visible = false;

		}

		private void cmd_Delete_Asking_Click(Object eventSender, EventArgs eventArgs)
		{
			//aey 4/21/2004
			string M = "";
			string Query = "";
			DialogResult RESP = (DialogResult) 0;

			if (modAdminCommon.Exist($"select * from Aircraft with (NOLOCK) where ac_asking = '{txt_aask_name.Text}'"))
			{
				M = $"Aircraft Asking   '{txt_aask_name.Text}'   currently used in the Aircraft Table.";
				MessageBox.Show(M, "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else if (modAdminCommon.Exist($"select * from Aircraft_Asking where aask_name = '{txt_aask_name.Text}'"))
			{ 

				this.Cursor = Cursors.WaitCursor;

				Query = $"DELETE FROM Aircraft_Asking  WHERE aask_name='{txt_aask_name.Text.Trim()}'";
				M = $"Aircraft Asking Delete For: {txt_aask_name.Text.Trim()}{"\r"}{"\r"}";
				M = $"{M}Do you wish to perform the delete at this time?";
				RESP = MessageBox.Show(M, "Confirm Delete!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (RESP == System.Windows.Forms.DialogResult.Yes)
				{
					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = Query;
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();
					Is_Dirty = true;
					FG_AirCraft_Asking.RemoveItem(FG_AirCraft_Asking.CurrentRowIndex);
					FG_AirCraft_Asking.Refresh();
					MessageBox.Show("Delete Successfully Completed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}
				else
				{
					MessageBox.Show("Delete Cancelled!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}

			}
			else
			{
				M = $"Aircraft Asking   '{txt_aask_name.Text}'   not currently in the Aircraft Asking Table.";
				MessageBox.Show(M, "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}

			pnl_NameDesc_Asking.Visible = false;
			this.Cursor = CursorHelper.CursorDefault;

		}

		private void cmd_Delete_Kfeat_Click(Object eventSender, EventArgs eventArgs)
		{
			//aey 4/20/2004 Key_Feature ("Delete")

			string M = "";
			string Query = "";
			DialogResult RESP = (DialogResult) 0;

			if (modAdminCommon.Exist($"select * from Aircraft_Model_Key_Feature with (NOLOCK) where amfeat_feature_code = '{txt_kfeat_code.Text.Trim()}'"))
			{
				M = $"Key Feature   '{txt_kfeat_code.Text}',   currently associated with an Aircraft Make/Model.";
				MessageBox.Show(M, "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else if (modAdminCommon.Exist($"select * from Key_Feature with (NOLOCK) where kfeat_code = '{txt_kfeat_code.Text}'"))
			{ 
				//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				Query = $"DELETE FROM Key_Feature WHERE kfeat_code='{txt_kfeat_code.Text.Trim()}'";
				M = $"Key Feature Delete For: {txt_kfeat_code.Text.ToUpper()}{"\r"}{"\r"}";
				M = $"{M}Do you wish to perform the delete at this time?";
				RESP = MessageBox.Show(M, "Confirm Delete!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (RESP == System.Windows.Forms.DialogResult.Yes)
				{
					//Call LOCAL_DB.Execute(QUERY, dbSQLPassThrough)
					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = Query;
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();
					FG_KeyFeature.RemoveItem(FG_KeyFeature.CurrentRowIndex);
					FG_KeyFeature.Refresh();

					Is_Dirty = true;
					MessageBox.Show("Delete Successfully Completed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}
				else
				{
					MessageBox.Show("Delete Cancelled!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}

			}
			else
			{
				M = $"Key Feature   '{txt_kfeat_code.Text}',   not currently in the Key Feature table.";
				MessageBox.Show(M, "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}

			pnl_kfeat_test.Visible = false;
			pnlAdmin.Visible = false;
			this.Cursor = CursorHelper.CursorDefault;

		}

		private void cmd_Save_Aircraft_Contact_Type_Click(Object eventSender, EventArgs eventArgs)
		{

			string M = "";

			if (RecordStat == "Add")
			{

				if (modAdminCommon.Exist($"SELECT * FROM Aircraft_Reference WHERE cref_contact_type = '{txt_actype_code.Text}'"))
				{
					M = $"Aircraft Contact Type Code   '{txt_actype_code.Text}',   currently used in the Aircraft Reference Table.";
					MessageBox.Show(M, "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

				}
				else
				{
					Aircraft_Contact_Type("Insert");
				}
			}
			else
			{
				if (RecordStat == "Delete")
				{
					Aircraft_Contact_Type("Delete");
				}
				else
				{
					Aircraft_Contact_Type("Update");
				}
			}

		}

		private void cmd_Save_Aircraft_Type_Click(Object eventSender, EventArgs eventArgs)
		{
			//aey 4/21/004 Aircraft_Type ("Insert")

			string Query = "";
			try
			{

				switch(RecordStat)
				{
					case "Add" : 
						if (modAdminCommon.Exist($"select * from Aircraft_Type where atype_code = '{txt_atype_code.Text}'"))
						{
							MessageBox.Show($"Aircraft Type   '{txt_atype_code.Text}',   currently used in the Aircraft Type Table - ADD CANCELLED.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						}
						else
						{
							FG_Aircraft_Type.RowsCount++;
							FG_Aircraft_Type.CurrentRowIndex = FG_Aircraft_Type.RowsCount - 1;
							FG_Aircraft_Type.CurrentColumnIndex = 0;
							FG_Aircraft_Type[FG_Aircraft_Type.CurrentRowIndex, FG_Aircraft_Type.CurrentColumnIndex].Value = txt_atype_code.Text.Trim().ToUpper();
							FG_Aircraft_Type.CurrentColumnIndex = 1;
							FG_Aircraft_Type[FG_Aircraft_Type.CurrentRowIndex, FG_Aircraft_Type.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_atype_Name).Trim();
							this.Cursor = Cursors.WaitCursor;

							Query = "INSERT INTO Aircraft_Type (atype_code, atype_name) values (";
							Query = $"{Query}'{txt_atype_code.Text.Trim().ToUpper()}','{modAdminCommon.Fix_Quote(txt_atype_Name).Trim()}')";
							DbCommand TempCommand = null;
							TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
							TempCommand.CommandText = Query;
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
							TempCommand.ExecuteNonQuery();
							Is_Dirty = true;
							MessageBox.Show("Insert Successfully Completed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						} 
						 
						break;
					case "Update" : 
						 
						FG_Aircraft_Type.CurrentColumnIndex = 0; 
						FG_Aircraft_Type[FG_Aircraft_Type.CurrentRowIndex, FG_Aircraft_Type.CurrentColumnIndex].Value = txt_atype_code.Text.Trim().ToUpper(); 
						FG_Aircraft_Type.CurrentColumnIndex = 1; 
						FG_Aircraft_Type[FG_Aircraft_Type.CurrentRowIndex, FG_Aircraft_Type.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_atype_Name).Trim(); 
						this.Cursor = Cursors.WaitCursor; 
						Query = "UPDATE Aircraft_Type SET "; 
						Query = $"{Query}atype_code='{modAdminCommon.Fix_Quote(txt_atype_code).Trim()}',"; 
						Query = $"{Query}atype_name='{modAdminCommon.Fix_Quote(txt_atype_Name).Trim()}'"; 
						Query = $"{Query} WHERE atype_code='{txt_atype_code.Text.Trim()}'"; 
						DbCommand TempCommand_2 = null; 
						TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand(); 
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2); 
						TempCommand_2.CommandText = Query; 
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2); 
						TempCommand_2.ExecuteNonQuery(); 
						Is_Dirty = true; 
						MessageBox.Show("Update Successfully Completed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly())); 
						break;
				}

				pnl_Aircraft_Type_AddUpdate.Visible = false;
				this.Cursor = CursorHelper.CursorDefault;
			}
			catch
			{

				this.Cursor = CursorHelper.CursorDefault;
				modAdminCommon.Report_Error("Aircraft_Type_Error: ");
			}
		}

		private void cmd_Save_APU_Click(Object eventSender, EventArgs eventArgs)
		{

			string Query = "";
			string FLDS = "";
			string VALS = "";
			try
			{

				switch(RecordStat)
				{
					case "Add" : 
						if (modAdminCommon.Exist($"SELECT * FROM Auxilliary_Power_Unit where apu_make_name = '{txt_apu_make_name.Text}'"))
						{
							MessageBox.Show($"Auxilliary Power Unit   '{txt_apu_make_name.Text}',   currently used in the Auxilliary_Power_Unit Table - ADD CANCELLED.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						}
						else
						{
							FG_Auxiliary_Power.RowsCount++;
							FG_Auxiliary_Power.CurrentRowIndex = FG_Auxiliary_Power.RowsCount - 1;
							FG_Auxiliary_Power.CurrentColumnIndex = 0;
							FG_Auxiliary_Power[FG_Auxiliary_Power.CurrentRowIndex, FG_Auxiliary_Power.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_apu_make_name).Trim();
							FG_Auxiliary_Power.CurrentColumnIndex = 1;
							FG_Auxiliary_Power[FG_Auxiliary_Power.CurrentRowIndex, FG_Auxiliary_Power.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_apu_model_name).Trim();

							FLDS = "INSERT INTO Auxilliary_Power_Unit (";
							VALS = ") VALUES (";
							FLDS = $"{FLDS}apu_make_name";
							VALS = $"{VALS}'{modAdminCommon.Fix_Quote(txt_apu_make_name).Trim()}'";
							if (Strings.Len(txt_apu_model_name.Text.Trim()) > 0)
							{
								FLDS = $"{FLDS}, apu_model_name";
								VALS = $"{VALS}, '{modAdminCommon.Fix_Quote(txt_apu_model_name).Trim()}'";
							}
							Query = $"{FLDS}{VALS})";
							this.Cursor = Cursors.WaitCursor;
							DbCommand TempCommand = null;
							TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
							TempCommand.CommandText = Query;
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
							TempCommand.ExecuteNonQuery();
							Is_Dirty = true;

							MessageBox.Show("Insert Successfully Completed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						} 
						 
						break;
					case "Update" : 
						 
						Query = $"UPDATE Auxilliary_Power_Unit SET apu_make_name='{modAdminCommon.Fix_Quote(txt_apu_make_name).Trim()}',"; 
						Query = $"{Query}apu_model_name='{modAdminCommon.Fix_Quote(txt_apu_model_name).Trim()}' "; 
						Query = $"{Query}WHERE apu_make_name='{txt_apu_make_name.Text.Trim()}'"; 
						 
						FG_Auxiliary_Power.CurrentColumnIndex = 0; 
						FG_Auxiliary_Power[FG_Auxiliary_Power.CurrentRowIndex, FG_Auxiliary_Power.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_apu_make_name).Trim(); 
						FG_Auxiliary_Power.CurrentColumnIndex = 1; 
						FG_Auxiliary_Power[FG_Auxiliary_Power.CurrentRowIndex, FG_Auxiliary_Power.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_apu_model_name).Trim(); 
						 
						this.Cursor = Cursors.WaitCursor; 
						DbCommand TempCommand_2 = null; 
						TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand(); 
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2); 
						TempCommand_2.CommandText = Query; 
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2); 
						TempCommand_2.ExecuteNonQuery(); 
						Is_Dirty = true; 
						MessageBox.Show("Update Successfully Completed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly())); 
						break;
				}

				pnl_APU_Update_Change.Visible = false;
				this.Cursor = CursorHelper.CursorDefault;
			}
			catch
			{

				this.Cursor = CursorHelper.CursorDefault;
				modAdminCommon.Report_Error("Auxilliary_Power_Unit_Error: ");
			}
		}

		private void cmd_Save_Asking_Click(Object eventSender, EventArgs eventArgs)
		{
			//aey 4/21/2004       Aircraft_Asking ("Insert")
			string Query = "";

			try
			{

				switch(RecordStat)
				{
					case "Add" : 
						if (modAdminCommon.Exist($"select * from Aircraft_Asking where aask_name = '{txt_aask_name.Text}'"))
						{
							MessageBox.Show($"Aircraft Asking   '{txt_aask_name.Text}',   currently used in the Aircraft Asking Table - ADD CANCELLED.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						}
						else
						{

							FG_AirCraft_Asking.RowsCount++;
							FG_AirCraft_Asking.CurrentRowIndex = FG_AirCraft_Asking.RowsCount - 1;
							FG_AirCraft_Asking.CurrentColumnIndex = 0;
							FG_AirCraft_Asking[FG_AirCraft_Asking.CurrentRowIndex, FG_AirCraft_Asking.CurrentColumnIndex].Value = txt_aask_name.Text.Trim();
							FG_AirCraft_Asking.CurrentColumnIndex = 1;
							FG_AirCraft_Asking[FG_AirCraft_Asking.CurrentRowIndex, FG_AirCraft_Asking.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_aask_description).Trim();

							Query = "INSERT INTO Aircraft_Asking (aask_name, aask_description ) VALUES (";
							Query = $"{Query}'{txt_aask_name.Text.Trim()}','{modAdminCommon.Fix_Quote(txt_aask_description).Trim()}')";
							//Call LOCAL_DB.Execute(Query, dbSQLPassThrough)
							DbCommand TempCommand = null;
							TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
							TempCommand.CommandText = Query;
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
							TempCommand.ExecuteNonQuery();
							Is_Dirty = true;
							MessageBox.Show("Insert Successfully Completed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						} 
						 
						break;
					case "Update" : 
						FG_AirCraft_Asking.CurrentColumnIndex = 0; 
						FG_AirCraft_Asking[FG_AirCraft_Asking.CurrentRowIndex, FG_AirCraft_Asking.CurrentColumnIndex].Value = txt_aask_name.Text.Trim(); 
						FG_AirCraft_Asking.CurrentColumnIndex = 1; 
						FG_AirCraft_Asking[FG_AirCraft_Asking.CurrentRowIndex, FG_AirCraft_Asking.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_aask_description).Trim(); 
						 
						Query = $"UPDATE Aircraft_Asking set aask_name='{modAdminCommon.Fix_Quote(txt_aask_name).Trim()}',"; 
						Query = $"{Query}aask_description='{modAdminCommon.Fix_Quote(txt_aask_description).Trim()}' "; 
						Query = $"{Query} WHERE aask_name='{txt_aask_name.Text.Trim()}'"; 
						DbCommand TempCommand_2 = null; 
						TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand(); 
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2); 
						TempCommand_2.CommandText = Query; 
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2); 
						TempCommand_2.ExecuteNonQuery(); 
						Is_Dirty = true; 
						MessageBox.Show("Update Successfully Completed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly())); 
						break;
				}

				this.Cursor = CursorHelper.CursorDefault;
				pnl_NameDesc_Asking.Visible = false;
			}
			catch
			{

				this.Cursor = CursorHelper.CursorDefault;
				modAdminCommon.Report_Error("Aircraft_Asking_Error: ");
				pnl_NameDesc_Asking.Visible = false;
			}
		}

		private void cmd_Save_Avionics_Click(Object eventSender, EventArgs eventArgs)
		{
			//aey 4/21/2004          Avionics ("Insert")

			string Query = "";

			if (Strings.Len(txt_avion_name.Text.Trim()) == 0)
			{
				MessageBox.Show("Invalid Name", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
			}

			switch(RecordStat)
			{
				case "Add" : 
					 
					if (modAdminCommon.Exist($"SELECT * FROM Avionics where avion_name = '{txt_avion_name.Text}'"))
					{
						MessageBox.Show($"Avionics   '{txt_avion_name.Text}',   currently used in the Aircraft Asking Table - ADD CANCELLED.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					}
					else
					{
						FG_Avionics.RowsCount++;
						FG_Avionics.CurrentRowIndex = FG_Avionics.RowsCount - 1;
						FG_Avionics.CurrentColumnIndex = 0;
						FG_Avionics[FG_Avionics.CurrentRowIndex, FG_Avionics.CurrentColumnIndex].Value = txt_avion_name.Text.Trim();
						FG_Avionics.CurrentColumnIndex = 1;
						FG_Avionics[FG_Avionics.CurrentRowIndex, FG_Avionics.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_avion_notes).Trim();
						this.Cursor = Cursors.WaitCursor;
						Query = "INSERT INTO Avionics (avion_name, avion_notes ) VALUES (";
						Query = $"{Query}'{txt_avion_name.Text.Trim()}','{modAdminCommon.Fix_Quote(txt_avion_notes).Trim()}')";
						DbCommand TempCommand = null;
						TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
						TempCommand.CommandText = Query;
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
						TempCommand.ExecuteNonQuery();
						Is_Dirty = true;
						MessageBox.Show("Insert Successfully Completed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					} 
					break;
				case "Update" : 
					this.Cursor = Cursors.WaitCursor; 
					FG_Avionics.CurrentColumnIndex = 0; 
					FG_Avionics[FG_Avionics.CurrentRowIndex, FG_Avionics.CurrentColumnIndex].Value = txt_avion_name.Text.Trim(); 
					FG_Avionics.CurrentColumnIndex = 1; 
					FG_Avionics[FG_Avionics.CurrentRowIndex, FG_Avionics.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_avion_notes).Trim(); 
					Query = $"UPDATE Avionics set avion_name='{modAdminCommon.Fix_Quote(txt_avion_name).Trim()}',"; 
					Query = $"{Query}avion_notes='{modAdminCommon.Fix_Quote(txt_avion_notes).Trim()}' "; 
					Query = $"{Query}WHERE avion_name='{txt_avion_name.Text.Trim()}'"; 
					DbCommand TempCommand_2 = null; 
					TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand(); 
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2); 
					TempCommand_2.CommandText = Query; 
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2); 
					TempCommand_2.ExecuteNonQuery(); 
					Is_Dirty = true; 
					MessageBox.Show("Update Successfully Completed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly())); 
					break;
			}

			pnl_avionics_Update_Change.Visible = false;
			this.Cursor = CursorHelper.CursorDefault;
			return;


			this.Cursor = CursorHelper.CursorDefault;
			modAdminCommon.Report_Error("Avionics_Error: ");

		}

		private void cmd_Save_Certification_Click(Object eventSender, EventArgs eventArgs)
		{
			//aey 4/21/2004       Certification ("Insert")

			string strUpdate = "";
			string strInsert = "";
			string old_name = "";
			string strActive = "";

			try
			{

				switch(RecordStat)
				{
					case "Add" : 
						if (modAdminCommon.Exist($"SELECT * FROM Certification where certification_name = '{txt_certification_name[0].Text}'"))
						{
							MessageBox.Show($"Certification   '{txt_certification_name[0].Text}',   currently used in the Certification Table - ADD CANCELLED.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						}
						else
						{

							if (Strings.Len(txt_certification_name[0].Text.Trim()) > 0)
							{

								FG_Operating_Certification.RowsCount++;
								FG_Operating_Certification.CurrentRowIndex = FG_Operating_Certification.RowsCount - 1;
								FG_Operating_Certification.CurrentColumnIndex = 0;
								FG_Operating_Certification[FG_Operating_Certification.CurrentRowIndex, FG_Operating_Certification.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_certification_name[0]).Trim();

								strActive = "N";
								if (chkCertActive.CheckState == CheckState.Checked)
								{
									strActive = "Y";
								}

								strInsert = "INSERT INTO Certification ( certification_name, certification_usa_flag, ";
								strInsert = $"{strInsert}certification_description,  certification_active_flag ";
								strInsert = $"{strInsert}) VALUES ('{modAdminCommon.Fix_Quote(txt_certification_name[0]).Trim()}',";
								strInsert = $"{strInsert}'{cbo_Ops_Cert_usaFlag.Text}',";
								strInsert = $"{strInsert}'{modAdminCommon.Fix_Quote(txt_certification_name[2]).Trim()}',";
								strInsert = $"{strInsert}'{strActive}')";

								DbCommand TempCommand = null;
								TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
								UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
								TempCommand.CommandText = strInsert;
								UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
								TempCommand.ExecuteNonQuery();
								Is_Dirty = true;

								MessageBox.Show("Insert Successfully Completed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));

							} // If Len(Trim(txt_certification_name(0))) > 0 Then

						} 
						 
						break;
					case "Update" : 
						if (Strings.Len(txt_certification_name[0].Text.Trim()) > 0)
						{

							FG_Operating_Certification.CurrentColumnIndex = 0;
							old_name = ($"{FG_Operating_Certification[FG_Operating_Certification.CurrentRowIndex, FG_Operating_Certification.CurrentColumnIndex].FormattedValue.ToString()}").Trim();
							FG_Operating_Certification[FG_Operating_Certification.CurrentRowIndex, FG_Operating_Certification.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_certification_name[0]).Trim();

							strActive = "N";
							if (chkCertActive.CheckState == CheckState.Checked)
							{
								strActive = "Y";
							}

							strUpdate = $"UPDATE Certification SET  certification_name = '{modAdminCommon.Fix_Quote(txt_certification_name[0]).Trim()}', ";
							strUpdate = $"{strUpdate}certification_usa_flag = '{cbo_Ops_Cert_usaFlag.Text.Substring(0, Math.Min(1, cbo_Ops_Cert_usaFlag.Text.Length))}', ";
							strUpdate = $"{strUpdate}certification_description = '{modAdminCommon.Fix_Quote(txt_certification_name[2]).Trim()}', ";
							strUpdate = $"{strUpdate}certification_active_flag = '{strActive}' ";
							strUpdate = $"{strUpdate}WHERE (certification_name='{old_name}') ";

							DbCommand TempCommand_2 = null;
							TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
							TempCommand_2.CommandText = strUpdate;
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
							TempCommand_2.ExecuteNonQuery();

							Is_Dirty = true;
							FG_Operating_Certification.CurrentColumnIndex = 0;
							FG_Operating_Certification[FG_Operating_Certification.CurrentRowIndex, FG_Operating_Certification.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_certification_name[0]).Trim();
							FG_Operating_Certification.CurrentColumnIndex = 1;
							FG_Operating_Certification[FG_Operating_Certification.CurrentRowIndex, FG_Operating_Certification.CurrentColumnIndex].Value = cbo_Ops_Cert_usaFlag.Text;
							FG_Operating_Certification.CurrentColumnIndex = 2;
							FG_Operating_Certification[FG_Operating_Certification.CurrentRowIndex, FG_Operating_Certification.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_certification_name[2]).Trim();
							FG_Operating_Certification.CurrentColumnIndex = 3;
							FG_Operating_Certification[FG_Operating_Certification.CurrentRowIndex, FG_Operating_Certification.CurrentColumnIndex].Value = modAdminCommon.ReturnYesNo(strActive);

							MessageBox.Show("Update Successfully Completed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));

						}  // If Len(Trim(txt_certification_name(0))) > 0 Then 
						 
						break;
				}

				pnl_Certification_Update_Change.Visible = false;
				FG_Operating_Certification.Refresh();
				this.Cursor = CursorHelper.CursorDefault;
			}
			catch
			{

				this.Cursor = CursorHelper.CursorDefault;
				modAdminCommon.Report_Error("Certification_Error: ");
			}
		} // cmd_Save_Certification_Click

		private void cmd_save_certified_Click(Object eventSender, EventArgs eventArgs)
		{
			//aey 4/28/24
			string Query = "";
			string FLDS = "";
			string VALS = "";
			string old_name = "";

			if (Strings.Len(($"{txt_cert_name_cert.Text}").Trim()) == 0)
			{
				return;
			}

			this.Cursor = Cursors.WaitCursor;

			switch(RecordStat)
			{
				case "Add" : 
					if (modAdminCommon.Exist($"SELECT * FROM Certified where cert_name = '{txt_cert_name_cert.Text}'"))
					{
						MessageBox.Show($"Certified   '{txt_cert_name_cert.Text}',   currently used in the Certified Table - ADD CANCELLED.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					}
					else
					{
						//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
						// Insert certified row into new table
						// Inform the user
						//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
						if (Strings.Len(txt_cert_name_cert.Text.Trim()) > 0)
						{
							FLDS = "INSERT INTO certified (";
							VALS = ") VALUES (";
							FLDS = $"{FLDS}cert_name";
							VALS = $"{VALS}'{modAdminCommon.Fix_Quote(txt_cert_name_cert).Trim()}'";
							Query = $"{FLDS}{VALS})";
							DbCommand TempCommand = null;
							TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
							TempCommand.CommandText = Query;
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
							TempCommand.ExecuteNonQuery();
							Is_Dirty = true;
							FGRD_Certifed.RowsCount++;
							FGRD_Certifed.CurrentRowIndex = FGRD_Certifed.RowsCount - 1;
							FGRD_Certifed.CurrentColumnIndex = 0;
							FGRD_Certifed[FGRD_Certifed.CurrentRowIndex, FGRD_Certifed.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_cert_name_cert).Trim();
							MessageBox.Show("Insert Successfully Completed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						}
					} 
					 
					break;
				case "Update" : 
					//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' 
					// Update 'certified' record 
					//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' 
					if (Strings.Len(txt_cert_name_cert.Text.Trim()) > 0)
					{
						FGRD_Certifed.CurrentColumnIndex = 0;
						old_name = ($"{FGRD_Certifed[FGRD_Certifed.CurrentRowIndex, FGRD_Certifed.CurrentColumnIndex].FormattedValue.ToString()}").Trim();
						Query = "UPDATE certified SET ";
						Query = $"{Query}certified_name='{modAdminCommon.Fix_Quote(txt_cert_name_cert).Trim()}',";
						Query = $"{Query}WHERE cert_name='{old_name}'";
						DbCommand TempCommand_2 = null;
						TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
						TempCommand_2.CommandText = Query;
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
						TempCommand_2.ExecuteNonQuery();
						Is_Dirty = true;
						FGRD_Certifed.CurrentColumnIndex = 0;
						FGRD_Certifed[FGRD_Certifed.CurrentRowIndex, FGRD_Certifed.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_cert_name_cert).Trim();
						MessageBox.Show("Update Successfully Completed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					} 
					 
					break;
			}

			pnl_Certified_Update_Change.Visible = false;
			this.Cursor = CursorHelper.CursorDefault;

			return;



			pnl_Certified_Update_Change.Visible = false;
			this.Cursor = CursorHelper.CursorDefault;
			modAdminCommon.Report_Error("Certified_Error: ");

		}

		private void cmd_Save_EMP_Click(Object eventSender, EventArgs eventArgs)
		{

			string Query = "";
			string FLDS = "";
			string VALS = "";

			try
			{

				if (Strings.Len(txt_emp_code.Text.Trim().ToUpper()) == 0 || Strings.Len(modAdminCommon.Fix_Quote(txt_emp_name).Trim()) == 0)
				{
					MessageBox.Show("Code and Name cannot be blank", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					return;
				}

				switch(RecordStat)
				{
					case "Add" : 
						if (modAdminCommon.Exist($"select * from Engine_maintenance_Program where emp_code = '{txt_emp_code.Text}'"))
						{
							MessageBox.Show($"Engine Maintenance Program   '{txt_emp_code.Text}',   currently used in the Engine Maintenance Program Table - ADD CANCELLED.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						}
						else
						{

							txt_Emp_ID.Text = "Auto";

							FG_Engine_Maintenance.RowsCount++;
							FG_Engine_Maintenance.CurrentRowIndex = FG_Engine_Maintenance.RowsCount - 1;
							FG_Engine_Maintenance.CurrentColumnIndex = 0;
							FG_Engine_Maintenance[FG_Engine_Maintenance.CurrentRowIndex, FG_Engine_Maintenance.CurrentColumnIndex].Value = txt_emp_code.Text.Trim().ToUpper();
							FG_Engine_Maintenance.CurrentColumnIndex = 1;
							FG_Engine_Maintenance[FG_Engine_Maintenance.CurrentRowIndex, FG_Engine_Maintenance.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_emp_name).Trim();
							FG_Engine_Maintenance.CurrentColumnIndex = 2;
							FG_Engine_Maintenance[FG_Engine_Maintenance.CurrentRowIndex, FG_Engine_Maintenance.CurrentColumnIndex].Value = txt_Emp_ID.Text.Trim();
							FG_Engine_Maintenance.CurrentColumnIndex = 3;
							FG_Engine_Maintenance[FG_Engine_Maintenance.CurrentRowIndex, FG_Engine_Maintenance.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_Provider_Name).Trim();
							FG_Engine_Maintenance.CurrentColumnIndex = 4;
							FG_Engine_Maintenance[FG_Engine_Maintenance.CurrentRowIndex, FG_Engine_Maintenance.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_Program_Name).Trim();

							this.Cursor = Cursors.WaitCursor;

							FLDS = "INSERT INTO Engine_Maintenance_Program (emp_code, emp_name ";
							VALS = $") VALUES ('{txt_emp_code.Text.Trim().ToUpper()}','{modAdminCommon.Fix_Quote(txt_emp_name).Trim()}' ";

							if (Strings.Len(modAdminCommon.Fix_Quote(txt_Provider_Name).Trim()) > 0)
							{
								FLDS = $"{FLDS}, emp_provider_name ";
								VALS = $"{VALS}, '{modAdminCommon.Fix_Quote(txt_Provider_Name).Trim()}' ";
							}
							if (Strings.Len(modAdminCommon.Fix_Quote(txt_Program_Name).Trim()) > 0)
							{
								FLDS = $"{FLDS}, emp_program_name ";
								VALS = $"{VALS}, '{modAdminCommon.Fix_Quote(txt_Program_Name).Trim()}' ";
							}
							Query = $"{FLDS}{VALS})";

							DbCommand TempCommand = null;
							TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
							TempCommand.CommandText = Query;
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
							TempCommand.ExecuteNonQuery();
							Is_Dirty = true;
							MessageBox.Show("Insert Successfully Completed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						} 
						 
						break;
					case "Update" : 
						 
						this.Cursor = Cursors.WaitCursor; 
						FG_Engine_Maintenance.CurrentColumnIndex = 0; 
						FG_Engine_Maintenance[FG_Engine_Maintenance.CurrentRowIndex, FG_Engine_Maintenance.CurrentColumnIndex].Value = txt_emp_code.Text.Trim().ToUpper(); 
						FG_Engine_Maintenance.CurrentColumnIndex = 1; 
						FG_Engine_Maintenance[FG_Engine_Maintenance.CurrentRowIndex, FG_Engine_Maintenance.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_emp_name).Trim(); 
						 
						Query = "UPDATE Engine_Maintenance_Program SET "; 
						Query = $"{Query}emp_code='{modAdminCommon.Fix_Quote(txt_emp_code).Trim()}',"; 
						Query = $"{Query}emp_name='{modAdminCommon.Fix_Quote(txt_emp_name).Trim()}' "; 
						if (Strings.Len(modAdminCommon.Fix_Quote(txt_Provider_Name).Trim()) > 0)
						{
							Query = $"{Query}, emp_provider_name ='{modAdminCommon.Fix_Quote(txt_Provider_Name).Trim()}' ";
						}
						else
						{
							Query = $"{Query}, emp_provider_name = NULL ";
						} 
						if (Strings.Len(modAdminCommon.Fix_Quote(txt_Program_Name).Trim()) > 0)
						{
							Query = $"{Query}, emp_program_name ='{modAdminCommon.Fix_Quote(txt_Program_Name).Trim()}' ";
						}
						else
						{
							Query = $"{Query}, emp_program_name = NULL ";
						} 
						 
						Query = $"{Query} WHERE emp_code='{txt_emp_code.Text.Trim()}'"; 
						DbCommand TempCommand_2 = null; 
						TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand(); 
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2); 
						TempCommand_2.CommandText = Query; 
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2); 
						TempCommand_2.ExecuteNonQuery(); 
						Is_Dirty = true; 
						MessageBox.Show("Update Successfully Completed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly())); 
						break;
				}
				pnl_EMP_AddUpdate.Visible = false;
				this.Cursor = CursorHelper.CursorDefault;
			}
			catch
			{

				this.Cursor = CursorHelper.CursorDefault;
				modAdminCommon.Report_Error("Engine_Maintenance_Program_Error: ");
			}
		}

		private void cmd_Save_IC_Click(Object eventSender, EventArgs eventArgs)
		{
			//aey 4/21/2004       Interior_Configuration ("Insert")
			string Query = "";
			string FLDS = "";
			string VALS = "";
			string old_name = "";
			try
			{

				switch(RecordStat)
				{
					case "Add" : 
						if (modAdminCommon.Exist($"SELECT * FROM Interior_Configuration where intconfig_name = '{txt_intconfig_name.Text}'"))
						{
							MessageBox.Show($"Interior Configuration   '{txt_intconfig_name.Text}',   currently used in the Interior_Configuration Table - ADD CANCELLED.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						}
						else
						{

							if (Strings.Len(txt_intconfig_name.Text.Trim()) > 0)
							{
								FLDS = "INSERT INTO Interior_Configuration (";
								VALS = ") VALUES (";
								FLDS = $"{FLDS}intconfig_name";
								VALS = $"{VALS}'{modAdminCommon.Fix_Quote(txt_intconfig_name).Trim()}'";
								Query = $"{FLDS}{VALS})";
								FG_Interior_Configuration.RowsCount++;
								FG_Interior_Configuration.CurrentRowIndex = FG_Interior_Configuration.RowsCount - 1;
								FG_Interior_Configuration.CurrentColumnIndex = 0;
								FG_Interior_Configuration[FG_Interior_Configuration.CurrentRowIndex, FG_Interior_Configuration.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_intconfig_name).Trim();
								DbCommand TempCommand = null;
								TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
								UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
								TempCommand.CommandText = Query;
								UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
								TempCommand.ExecuteNonQuery();
								Is_Dirty = true;
								MessageBox.Show("Insert Successfully Completed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
							}
						} 
						break;
					case "Update" : 
						if (Strings.Len(txt_intconfig_name.Text.Trim()) > 0)
						{
							FG_Interior_Configuration.CurrentColumnIndex = 0;
							old_name = ($"{FG_Interior_Configuration[FG_Interior_Configuration.CurrentRowIndex, FG_Interior_Configuration.CurrentColumnIndex].FormattedValue.ToString()}").Trim();
							Query = "UPDATE Interior_Configuration SET ";
							Query = $"{Query}intconfig_name = '{modAdminCommon.Fix_Quote(txt_intconfig_name).Trim()}' ";
							Query = $"{Query}WHERE intconfig_name = '{old_name}' ";
							FG_Interior_Configuration.CurrentColumnIndex = 0;
							FG_Interior_Configuration[FG_Interior_Configuration.CurrentRowIndex, FG_Interior_Configuration.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_intconfig_name).Trim();

							DbCommand TempCommand_2 = null;
							TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
							TempCommand_2.CommandText = Query;
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
							TempCommand_2.ExecuteNonQuery();
							Is_Dirty = true;
							MessageBox.Show("Update Successfully Completed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						} 
						break;
				}
				pnl_IC_Update_Change.Visible = false;
				this.Cursor = CursorHelper.CursorDefault;
			}
			catch
			{
				this.Cursor = CursorHelper.CursorDefault;
				modAdminCommon.Report_Error("Interior_Configuration_Error: ");
			}
		}

		private void cmd_Save_Kfeat_Click(Object eventSender, EventArgs eventArgs)
		{
			string Query = "";
			string tmp_Query = "";


			try
			{
				this.Cursor = Cursors.WaitCursor;

				tmp_Query = $"{txt_kfeat_query.Text}";

				switch(RecordStat)
				{
					case "Add" : 
						if (modAdminCommon.Exist($"select * from Key_Feature with (NOLOCK) where kfeat_code = '{txt_kfeat_code.Text}'"))
						{
							MessageBox.Show($"Key Feature '{txt_kfeat_code.Text.Trim()}' Already exists in Key Feature Table.  Add Cancelled ", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						}
						else
						{

							if (Check_for_Aircraft_Lock(modAdminCommon.Fix_Quote(txt_kfeat_code).Trim()) && modAdminCommon.gbl_User_ID != "mvit")
							{
								MessageBox.Show("There are currently aircraft that are locked by a user for this feature code.  Feature code update aborted.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
							}
							else
							{

								Query = "INSERT INTO Key_Feature ( Kfeat_code, Kfeat_Name, Kfeat_Description, ";
								Query = $"{Query}Kfeat_Research_Notes, kfeat_howtoformat,  kfeat_wheretoenter, ";

								Query = $"{Query}kfeat_product_business_flag , kfeat_product_commercial_flag , kfeat_product_helicopter_flag , ";
								Query = $"{Query}kfeat_model_dependent_flag , kfeat_area , ";


								if (pnlAdmin.Visible)
								{
									Query = $"{Query}kfeat_query, ";
								}
								Query = $"{Query}kfeat_donotclear ) VALUES (";
								Query = $"{Query}'{txt_kfeat_code.Text.Trim().ToUpper()}','" +
								        $"{modAdminCommon.Fix_Quote(txt_kfeat_name).Trim()}','" +
								        $"{modAdminCommon.Fix_Quote(txt_kfeat_description).Trim()}','" +
								        $"{modAdminCommon.Fix_Quote(txt_kfeat_research_notes).Trim()}','" +
								        $"{modAdminCommon.Fix_Quote(txt_kfeat_howtoformat).Trim()}','" +
								        $"{modAdminCommon.Fix_Quote(txt_kfeat_wheretoenter).Trim()}',";

								// ADDED MSW - 2/19/18
								//business
								if (chk_product_flags[0].CheckState == CheckState.Checked)
								{
									Query = $"{Query}'Y',";
								}
								else
								{
									Query = $"{Query}'N',";
								}

								//commercial
								if (chk_product_flags[1].CheckState == CheckState.Checked)
								{
									Query = $"{Query}'Y',";
								}
								else
								{
									Query = $"{Query}'N',";
								}

								//heli
								if (chk_product_flags[2].CheckState == CheckState.Checked)
								{
									Query = $"{Query}'Y',";
								}
								else
								{
									Query = $"{Query}'N',";
								}

								// model default
								if (chk_product_flags[3].CheckState == CheckState.Checked)
								{
									Query = $"{Query}'Y',";
								}
								else
								{
									Query = $"{Query}'N',";
								}


								Query = $"{Query}'{modAdminCommon.DeleteCarriageReturnsAndExtraSpaces(modAdminCommon.Fix_Quote(cbo_feat_area.Text))}', ";


								if (pnlAdmin.Visible)
								{
									Query = $"{Query}'{modAdminCommon.DeleteCarriageReturnsAndExtraSpaces(modAdminCommon.Fix_Quote(txt_kfeat_query))}', ";
								}

								if (chk_kfeat_donotclear.CheckState == CheckState.Checked)
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
								UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
								TempCommand.ExecuteNonQuery();
								FG_KeyFeature.RowsCount++;
								FG_KeyFeature.CurrentRowIndex = FG_KeyFeature.RowsCount - 1;
								FG_KeyFeature.CurrentColumnIndex = 0;
								FG_KeyFeature[FG_KeyFeature.CurrentRowIndex, FG_KeyFeature.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_kfeat_code).Trim();
								FG_KeyFeature.CurrentColumnIndex = 1;
								FG_KeyFeature[FG_KeyFeature.CurrentRowIndex, FG_KeyFeature.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_kfeat_name).Trim();

								MessageBox.Show("Insert Successfully Completed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));

							}
						} 
						 
						break;
					case "Update" : 
						 
						if (!Check_for_Aircraft_Lock(modAdminCommon.Fix_Quote(txt_kfeat_code).Trim()) || (modAdminCommon.gbl_User_ID == "mvit" || modAdminCommon.gbl_User_ID == "dcr"))
						{

							if (Key_Feature_Ok_to_Inactivate())
							{

								// RUN THE MASS UPDATE PROCESS FOR THE KEY FEATURE
								Key_Feature_Mass_Update();
								FG_KeyFeature.CurrentColumnIndex = 0;
								FG_KeyFeature[FG_KeyFeature.CurrentRowIndex, FG_KeyFeature.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_kfeat_code).Trim();
								FG_KeyFeature.CurrentColumnIndex = 1;
								FG_KeyFeature[FG_KeyFeature.CurrentRowIndex, FG_KeyFeature.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_kfeat_name).Trim();

								MessageBox.Show("Update Successfully Completed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));

							}
						}
						else
						{

							MessageBox.Show("There are currently aircraft that are locked by a user for this feature code.  Feature code update aborted.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						} 
						 
						break;
				}

				FG_KeyFeature.Refresh();
				pnl_kfeat_test.Visible = false;
				pnlAdmin.Visible = false;
				this.Cursor = CursorHelper.CursorDefault;
			}
			catch (System.Exception excep)
			{

				this.Cursor = CursorHelper.CursorDefault;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Key_Feature_Error: {Information.Err().Number.ToString()} {excep.Message}");
				if (Strings.Len(($"{tmp_Query}").Trim()) > 0)
				{ //restore query
					txt_kfeat_query.Text = tmp_Query;
				}
			}

		}

		private void cmd_Add_aircraft_status_Click(Object eventSender, EventArgs eventArgs)
		{
			//aey 4/20/2004  Aircraft_Status ("Clear")

			pnl_Update_Aircraft_Status.Visible = true;
			RecordStat = "Add";
			txt_astat_name.Text = "";
			txt_astat_description.Text = "";

		}

		private void cmd_Save_aircraft_status_Click(Object eventSender, EventArgs eventArgs)
		{
			//aey 4/20/2004         Aircraft_Status ("Update")
			string Query = "";

			switch(RecordStat)
			{
				case "Add" : 
					 
					if (modAdminCommon.Exist($"select * from Aircraft_Status where astat_name = '{txt_astat_name.Text}'"))
					{
						MessageBox.Show($"Aircraft Status   '{txt_astat_name.Text}',   currently used in the Aircraft Status Table- ADD CANCELLED.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					}
					else
					{
						FG_Aircraft_Status.RowsCount++;
						FG_Aircraft_Status.CurrentRowIndex = FG_Aircraft_Status.RowsCount - 1;
						FG_Aircraft_Status.CurrentColumnIndex = 0;
						FG_Aircraft_Status[FG_Aircraft_Status.CurrentRowIndex, FG_Aircraft_Status.CurrentColumnIndex].Value = txt_astat_name.Text.Trim();
						FG_Aircraft_Status.CurrentColumnIndex = 1;
						FG_Aircraft_Status[FG_Aircraft_Status.CurrentRowIndex, FG_Aircraft_Status.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_astat_description).Trim();

						Query = "INSERT INTO Aircraft_Status (astat_name, astat_description ) values (";
						Query = $"{Query}'{txt_astat_name.Text.Trim()}','{modAdminCommon.Fix_Quote(txt_astat_description).Trim()}')";
						DbCommand TempCommand = null;
						TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
						TempCommand.CommandText = Query;
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
						TempCommand.ExecuteNonQuery();
						Is_Dirty = true;
						MessageBox.Show("Insert Successfully Completed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					} 
					 
					break;
				case "Update" : 
					FG_Aircraft_Status.CurrentColumnIndex = 0; 
					FG_Aircraft_Status[FG_Aircraft_Status.CurrentRowIndex, FG_Aircraft_Status.CurrentColumnIndex].Value = txt_astat_name.Text.Trim(); 
					FG_Aircraft_Status.CurrentColumnIndex = 1; 
					FG_Aircraft_Status[FG_Aircraft_Status.CurrentRowIndex, FG_Aircraft_Status.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_astat_description).Trim(); 
					 
					Query = $"UPDATE Aircraft_Status SET  astat_name='{modAdminCommon.Fix_Quote(txt_astat_name).Trim()}',"; 
					Query = $"{Query}astat_description='{modAdminCommon.Fix_Quote(txt_astat_description).Trim()}'"; 
					Query = $"{Query} WHERE astat_name='{txt_astat_name.Text.Trim()}'"; 
					DbCommand TempCommand_2 = null; 
					TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand(); 
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2); 
					TempCommand_2.CommandText = Query; 
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2); 
					TempCommand_2.ExecuteNonQuery(); 
					MessageBox.Show("Update Successfully Completed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly())); 
					 
					break;
			}

			FG_Aircraft_Status.Refresh();
			pnl_Update_Aircraft_Status.Visible = false;
			this.Cursor = CursorHelper.CursorDefault;

		}

		private void cmd_Cancel_aircraft_status_Click(Object eventSender, EventArgs eventArgs)
		{
			//aey /21/2004   'Aircraft_Status ("Fill List")

			pnl_Update_Aircraft_Status.Visible = false;
			this.Cursor = CursorHelper.CursorDefault;

		}

		private void cmd_Delete_Aircraft_Status_Click(Object eventSender, EventArgs eventArgs)
		{

			string M = "";
			string Query = "";
			DialogResult RESP = (DialogResult) 0;
			this.Cursor = Cursors.WaitCursor;

			if (modAdminCommon.Exist($"SELECT * FROM Aircraft with (NOLOCK) WHERE ac_status = '{txt_astat_name.Text}'"))
			{
				M = $"Aircraft Status   '{txt_astat_name.Text}',   currently used in the Aircraft Table.";
				MessageBox.Show(M, "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else if (modAdminCommon.Exist($"SELECT * FROM Aircraft_Status WHERE astat_name = '{txt_astat_name.Text}'"))
			{ 
				Query = "DELETE FROM Aircraft_Status";
				Query = $"{Query} WHERE astat_name='{txt_astat_name.Text.Trim()}'";
				M = $"Aircraft Status Delete For: {txt_astat_name.Text.Trim()}{"\r"}{"\r"}";
				M = $"{M}Do you wish to perform the delete at this time?";
				RESP = MessageBox.Show(M, "Confirm Delete!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (RESP == System.Windows.Forms.DialogResult.Yes)
				{
					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = Query;
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();
					Is_Dirty = true;
					FG_Aircraft_Status.RemoveItem(FG_Aircraft_Status.CurrentRowIndex);
					FG_Aircraft_Status.Refresh();

					MessageBox.Show("Delete Successfully Completed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}
				else
				{
					MessageBox.Show("Delete Cancelled!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}

			}
			else
			{
				M = $"Aircraft Status   '{txt_astat_name.Text}',   not currently in the Aircraft Table.";
				MessageBox.Show(M, "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}

			pnl_Update_Aircraft_Status.Visible = false;
			this.Cursor = CursorHelper.CursorDefault;

		}

		private void cmd_save_spec_Click(Object eventSender, EventArgs eventArgs)
		{
			//aey 4/21/2004  Specification ("Insert")

			string Query = "";
			string FLDS = "";
			string VALS = "";

			try
			{

				switch(RecordStat)
				{
					case "Add" : 
						//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' 
						// Insert Specification row into new table 
						// Inform the user 
						//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' 
						if (modAdminCommon.Exist($"SELECT * FROM Specification where spec_name = '{txt_spec_name.Text}'"))
						{
							MessageBox.Show($"Specification   '{txt_spec_name.Text}',   currently used in the Specification Table - ADD CANCELLED.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						}
						else
						{
							FG_Specification.RowsCount++;
							FG_Specification.CurrentRowIndex = FG_Specification.RowsCount - 1;
							FG_Specification.CurrentColumnIndex = 0;
							FG_Specification[FG_Specification.CurrentRowIndex, FG_Specification.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_spec_name).Trim();
							FG_Specification.CurrentColumnIndex = 1;
							FG_Specification[FG_Specification.CurrentRowIndex, FG_Specification.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_spec_type).Trim();
							FG_Specification.CurrentColumnIndex = 2;
							FG_Specification[FG_Specification.CurrentRowIndex, FG_Specification.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_spec_notes).Trim();

							FLDS = "INSERT INTO Specification (";
							VALS = ") VALUES (";
							FLDS = $"{FLDS}spec_name";
							VALS = $"{VALS}'{modAdminCommon.Fix_Quote(txt_spec_name).Trim()}'";
							if (Strings.Len(txt_spec_type.Text.Trim()) > 0)
							{
								FLDS = $"{FLDS}, spec_type";
								VALS = $"{VALS}, '{modAdminCommon.Fix_Quote(txt_spec_type).Trim()}'";
							}
							if (Strings.Len(txt_spec_notes.Text.Trim()) > 0)
							{
								FLDS = $"{FLDS}, spec_notes";
								VALS = $"{VALS}, '{modAdminCommon.Fix_Quote(txt_spec_notes).Trim()}'";
							}
							Query = $"{FLDS}{VALS})";
							DbCommand TempCommand = null;
							TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
							TempCommand.CommandText = Query;
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
							TempCommand.ExecuteNonQuery();
							Is_Dirty = true;

							MessageBox.Show("Insert Successfully Completed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						} 
						 
						break;
					case "Update" : 
						//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' 
						// Update 'Specification' record 
						//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' 
						FG_Specification.CurrentColumnIndex = 0; 
						FG_Specification[FG_Specification.CurrentRowIndex, FG_Specification.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_spec_name).Trim(); 
						FG_Specification.CurrentColumnIndex = 1; 
						FG_Specification[FG_Specification.CurrentRowIndex, FG_Specification.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_spec_type).Trim(); 
						FG_Specification.CurrentColumnIndex = 2; 
						FG_Specification[FG_Specification.CurrentRowIndex, FG_Specification.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_spec_notes).Trim(); 
						 
						Query = "UPDATE Specification SET "; 
						Query = $"{Query}spec_name='{modAdminCommon.Fix_Quote(txt_spec_name).Trim()}'"; 
						if (Strings.Len(txt_spec_type.Text.Trim()) > 0)
						{
							Query = $"{Query}, spec_type='{modAdminCommon.Fix_Quote(txt_spec_type).Trim()}'";
						} 
						if (Strings.Len(txt_spec_notes.Text.Trim()) > 0)
						{
							Query = $"{Query}, spec_notes='{modAdminCommon.Fix_Quote(txt_spec_notes).Trim()}'";
						} 
						Query = $"{Query}WHERE spec_name='{modAdminCommon.Fix_Quote(txt_spec_name).Trim()}'"; 
						DbCommand TempCommand_2 = null; 
						TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand(); 
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2); 
						TempCommand_2.CommandText = Query; 
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2); 
						TempCommand_2.ExecuteNonQuery(); 
						Is_Dirty = true; 
						 
						MessageBox.Show("Update Successfully Completed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly())); 
						break;
				}

				pnl_Spec_Update_Change.Visible = false;
				this.Cursor = CursorHelper.CursorDefault;
			}
			catch
			{

				this.Cursor = CursorHelper.CursorDefault;
				modAdminCommon.Report_Error("Specification_Error: ");
			}
		}


		private void cmdAddCREG_Click(Object eventSender, EventArgs eventArgs)
		{
			pnl_CREG.Visible = true;
			RecordStat = "Add";

			txt_crm_id.Text = "";
			txt_crm_Make.Text = "";
			txt_crm_model.Text = "";
			txt_crm_amod_list.Text = "";
		}

		private void cmdAirportPreviousNext_Click(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.cmdAirportPreviousNext, eventSender);


			bool bRefresh = true;
			int lRow = grd_Airport.CurrentRowIndex;

			switch(Index)
			{
				case 0 :  // Previous/Up 
					lRow--; 
					break;
				case 1 :  // Next/Down 
					lRow++; 
					break;
			}

			if (lRow >= grd_Airport.RowsCount)
			{
				lRow = grd_Airport.CurrentRowIndex;
				bRefresh = false;
			}

			if (lRow < 1)
			{
				lRow = 1;
				bRefresh = false;
			}

			if (bRefresh)
			{
				grd_Airport.CurrentRowIndex = lRow;
				Airport_Select();
				grd_Airport.FirstDisplayedScrollingRowIndex = lRow;
				grd_Airport.CurrentColumnIndex = 0;
				grd_Airport.ColSel = grd_Airport.ColumnsCount - 1;
			}

		} // cmdAirportPreviousNext_Click

		private void cmdCancelCREG_Click(Object eventSender, EventArgs eventArgs)
		{
			pnl_CREG.Visible = false;
			this.Cursor = CursorHelper.CursorDefault;

		}

		private void cmdDeleteCREG_Click(Object eventSender, EventArgs eventArgs)
		{
			string M = "";
			string Query = "";
			DialogResult RESP = (DialogResult) 0;
			this.Cursor = Cursors.WaitCursor;


			if (modAdminCommon.Exist($"SELECT * FROM Canadian_Registry_Models WHERE crm_id = {txt_crm_id.Text} "))
			{

				Query = $"DELETE FROM Canadian_Registry_Models  WHERE crm_id = {txt_crm_id.Text} ";
				M = $"Canadian_Registry_Models Delete For: {txt_crm_model.Text.Trim()}{"\r"}{"\r"}";
				M = $"{M}Do you wish to perform the delete at this time?";
				RESP = MessageBox.Show(M, "Confirm Delete!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (RESP == System.Windows.Forms.DialogResult.Yes)
				{
					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = Query;
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();
					Is_Dirty = true;
					grdCREG.RemoveItem(FG_Aircraft_Status.CurrentRowIndex);
					grdCREG.Refresh();

					MessageBox.Show("Delete Successfully Completed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}
				else
				{
					MessageBox.Show("Delete Cancelled!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}

			}
			else
			{
				M = $"Canadian_Registry_Models   '{txt_crm_Make.Text} {txt_crm_model.Text}',   not currently in the Aircraft Table.";
				MessageBox.Show(M, "DELETE CANCELLED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}

			pnl_CREG.Visible = false;
			this.Cursor = CursorHelper.CursorDefault;

		}

		private void cmdEngineModelsAdd_Click(Object eventSender, EventArgs eventArgs) => Clear_Engine_Models_Fields();


		private bool Does_Engine_Name_Exist_On_The_Aircraft_Level(string strEngineName, bool bDuplicate)
		{

			bool result = false;
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			bool bResults = false;

			try
			{

				bResults = false;

				if (!bDuplicate)
				{

					strQuery1 = "SELECT TOP 1 * FROM Aircraft WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1}WHERE (ac_engine_name = '{strEngineName.Trim()}') ";

					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!rstRec1.BOF && !rstRec1.EOF)
					{
						bResults = true;
					}

					rstRec1.Close();

				} // If bDuplicate = False Then

				rstRec1 = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Does_Engine_Name_Exist_On_The_Aircraft_Level_Error", excep.Message);
				result = true;
			}
			return result;
		} // Does_Engine_Name_Exist_On_The_Aircraft_Level

		private bool Does_Engine_Id_Exist_On_The_Model_Level(int lEMId)
		{

			bool result = false;
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			bool bResults = false;

			try
			{

				bResults = true;

				if (lEMId > 0)
				{

					strQuery1 = $"SELECT TOP 1 * FROM Aircraft_Model_Engine WITH (NOLOCK) WHERE (ameng_engine_model_id = {lEMId.ToString()}) ";

					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (rstRec1.BOF && rstRec1.EOF)
					{
						bResults = false;
					}

					rstRec1.Close();

				} // If lEMId > 0 Then

				rstRec1 = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Does_Engine_Id_Exist_On_The_Model_Level", excep.Message);
				result = true;
			}
			return result;
		} // Does_Engine_Id_Exist_On_The_Model_Level

		private bool Does_Engine_Name_Exist_On_The_Model_Level(string strEngineName, bool bDuplicate)
		{

			bool result = false;
			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			bool bResults = false;

			try
			{

				bResults = false;

				if (!bDuplicate)
				{

					strQuery1 = "SELECT TOP 1 * FROM Aircraft_Model_Engine WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1}WHERE (ameng_engine_name = '{strEngineName.Trim()}') ";

					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!rstRec1.BOF && !rstRec1.EOF)
					{
						bResults = true;
					}

					rstRec1.Close();

				} // If bDuplicate = False Then

				rstRec1 = null;


				return bResults;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("Does_Engine_Name_Exist_On_The_Model_Level_Error", excep.Message);
				result = true;
			}
			return result;
		} // Does_Engine_Name_Exist_On_The_Model_Level

		private void cmdEngineModelsDelete_Click(Object eventSender, EventArgs eventArgs)
		{

			int lEMId = 0;
			string strEMId = "";
			string strEngineName = "";
			string strDelete1 = "";
			bool bDuplicate = false;

			try
			{

				strEMId = txtEngineModel[iEMID].Text;
				strEngineName = txtEngineModel[iEMNAME].Text;

				if (MessageBox.Show($"Are You Sure You Want To Delete EMId: [{strEMId}] Engine Name: [{strEngineName}]", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
				{

					if (strEMId != "")
					{

						if (Information.IsNumeric(strEMId))
						{

							lEMId = Convert.ToInt32(Double.Parse(strEMId));

							if (lEMId > 0)
							{

								if (strEngineName != "")
								{

									bDuplicate = modAdminCommon.Is_Engine_Model_A_Duplicate(strEngineName);

									if (!Does_Engine_Id_Exist_On_The_Model_Level(lEMId))
									{

										if (!Does_Engine_Name_Exist_On_The_Model_Level(strEngineName, bDuplicate))
										{

											if (!Does_Engine_Name_Exist_On_The_Aircraft_Level(strEngineName, bDuplicate))
											{

												strDelete1 = $"DELETE FROM Engine_Models WHERE (em_id = {strEMId}) ";
												DbCommand TempCommand = null;
												TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
												UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
												TempCommand.CommandText = strDelete1;
												//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
												//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
												TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
												UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
												TempCommand.ExecuteNonQuery();

												bEngineModelChanged = true;
												lblEMStatus.Text = $"Engine Model Id [{strEMId}] Name [{strEngineName}] Has Been Deleted. Duplicate={bDuplicate.ToString()}";

												modAdminCommon.Record_Event("Engine Models", lblEMStatus.Text, 0, 0, 0, false, 0, 0);

												cmdEngineModelsRefresh_Click(cmdEngineModelsRefresh, new EventArgs());

											}
											else
											{
												MessageBox.Show($"Engine Name: [{strEngineName}] Exists On The Aircraft Level. Can NOT Delete", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
											} // If Does_Engine_Name_Exist_On_The_Aircraft_Level(strEngineName, bDuplicate) = False Then

										}
										else
										{
											MessageBox.Show($"Engine Name: [{strEngineName}] Exists On The Model Level. Can NOT Delete", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
										} // If Does_Engine_Name_Exist_On_The_Model_Level(strEngineName, bDuplicate) = False Then

									}
									else
									{
										MessageBox.Show($"Engine Id: [{strEMId}] Exists On The Model Level. Can NOT Delete", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
									} // If Does_Engine_Id_Exist_On_The_Model_Level(lEMId) = False Then

								}
								else
								{
									MessageBox.Show("Engine Name Is Blank", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
								} // If strEngineName <> "" Then

							}
							else
							{
								MessageBox.Show("EMId Is Not Greater Than Zero", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							} // If lEMId > 0 Then

						}
						else
						{
							MessageBox.Show("EMId Is Non-Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						} // If IsNumeric(strEMId) = True Then

					}
					else
					{
						MessageBox.Show("EMId Is Blank", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					} // If strEMId <> "" Then

				} // If MsgBox("Are You Sure You Want To Delete EMId: [" & strEMId & "] Engine Name: [" & strEngineName & "]", vbYesNo + vbApplicationModal) = vbYes Then
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("cmdEngineModelsDelete_Click_Error", excep.Message);
			}

		} // cmdEngineModelsDelete_Click

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
			grdEngineModels.ColumnsCount = 18;

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

			lCol1++;
			grdEngineModels.CurrentColumnIndex = lCol1;
			grdEngineModels.SetColumnWidth(lCol1, 247);
			grdEngineModels.CellBackColor = grdEngineModels.BackColorFixed;
			grdEngineModels.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
			grdEngineModels[grdEngineModels.CurrentRowIndex, grdEngineModels.CurrentColumnIndex].Value = "Assigned To Make/Model";

			grdEngineModels.CurrentRowIndex = 1;
			grdEngineModels.FixedRows = 1;
			grdEngineModels.FixedColumns = 0;

		} // Load_Engine_Model_Grid_Headers

		public void Clear_Engine_Models_Fields()
		{

			txtEngineModel[iEMID].Text = "0";
			txtEngineModel[iEMNAME].Text = "";
			txtEngineModel[iEMPREFIX].Text = "";
			txtEngineModel[iEMCORE].Text = "";
			txtEngineModel[iEMTAKEOFFPOWER].Text = "0";
			txtEngineModel[iEMMAXCONPOWER].Text = "0";
			txtEngineModel[iEMSUFFIX1].Text = "";
			txtEngineModel[iEMSUFFIX2].Text = "";
			txtEngineModel[iEMMFRCOMPID].Text = "0";
			txtEngineModel[iEMMFRABBREV].Text = "";
			txtEngineModel[iEMMFRNAME].Text = "";
			txtEngineModel[iEMTHRUSTLBS].Text = "0";
			txtEngineModel[iEMCOMTBOHRS].Text = "0";
			txtEngineModel[iEMSHAFTHP].Text = "0";
			txtEngineModel[iEMHSI].Text = "0";

			chkEngineModel[iEMACTIVE].CheckState = CheckState.Checked;
			chkEngineModel[iEMONCONDITIONTBO].CheckState = CheckState.Unchecked;

			cmdEngineModelsSave.Enabled = true;
			cmdEngineModelsAdd.Enabled = false;
			cmdEngineModelsDelete.Enabled = false;

		} // Clear_Engine_Models_Fields

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
				lblExportToExcel[iExportEngineModels].Visible = false;

				lMainColor = 0xFFFFFF;
				lInActiveColor = 0xC0C0FF;

				Load_Engine_Model_Grid_Headers();

				Clear_Engine_Models_Fields();

				strSearchEngineModelName = txtSearchEngineModelName.Text.Trim();

				strQuery1 = "SELECT EM1.em_id As EMId, ";
				strQuery1 = $"{strQuery1}EM1.em_engine_name As EngineModel, EM1.em_engine_prefix As Prefix, ";
				strQuery1 = $"{strQuery1}EM1.em_engine_core As Core, EM1.em_engine_suffix1 As Suffix1, ";
				strQuery1 = $"{strQuery1}EM1.em_engine_suffix2 As Suffix2, EM1.em_active_flag As ActiveFlag, ";
				strQuery1 = $"{strQuery1}EM1.em_takeoff_power As TakeoffPower,  EM1.em_max_continuous_power As MaxPower, ";
				strQuery1 = $"{strQuery1}EM1.em_mfr_comp_id As MfrCompId, EM1.em_mfr_name_abbrev As MfrAbbrev, ";
				strQuery1 = $"{strQuery1}EM1.em_mfr_name As MfrName, EM1.em_engine_thrust_lbs As ThrustLbs, ";
				strQuery1 = $"{strQuery1}EM1.em_engine_com_tbo_hrs As TBOHours, EM1.em_engine_shaft As ShaftHP, ";
				strQuery1 = $"{strQuery1}EM1.em_engine_hsi As HSI,  EM1.em_on_condition_flag As OnTBO, ";

				strQuery1 = $"{strQuery1}COALESCE(";
				strQuery1 = $"{strQuery1}STUFF(";
				strQuery1 = $"{strQuery1}      (SELECT '; ' + AM1.amod_make_name + ' ' + AM1.amod_model_name ";
				strQuery1 = $"{strQuery1}       FROM Aircraft_Model AS AM1 WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}       INNER JOIN Aircraft_Model_Engine AS AME1 WITH (NOLOCK) ON AME1.ameng_amod_id = AM1.amod_id ";
				strQuery1 = $"{strQuery1}       WHERE (AME1.ameng_engine_name = EM1.em_engine_name) ";
				strQuery1 = $"{strQuery1}       FOR XML PATH('')),1,1,''),'') As ACMakeModel ";

				strQuery1 = $"{strQuery1}FROM Engine_Models AS EM1 WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (EM1.em_engine_name IS NOT NULL)  AND (EM1.em_engine_name <> '') ";

				if (strSearchEngineModelName != "")
				{
					strQuery1 = $"{strQuery1}AND (EM1.em_engine_name LIKE '{strSearchEngineModelName}%') ";
				}

				if (chkEMFindDuplicate.CheckState == CheckState.Checked)
				{
					strQuery1 = $"{strQuery1}AND (EXISTS (SELECT NULL FROM Engine_Models AS EM2 WITH (NOLOCK)";
					strQuery1 = $"{strQuery1}             WHERE (EM2.em_engine_name = EM1.em_engine_name) ";
					strQuery1 = $"{strQuery1}             AND (EM2.em_id <> EM1.em_id) ";
					strQuery1 = $"{strQuery1}            ) ";
					strQuery1 = $"{strQuery1}    ) ";
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
						if (($"{Convert.ToString(rstRec1["ActiveFlag"])} ").Trim() != "Y")
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
						grdEngineModels[grdEngineModels.CurrentRowIndex, grdEngineModels.CurrentColumnIndex].Value = Convert.ToString(rstRec1["EMId"]);

						lCol1++;
						grdEngineModels.CurrentColumnIndex = lCol1;
						grdEngineModels.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						//UPGRADE_WARNING: (1068) lTempColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						grdEngineModels.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lTempColor));
						grdEngineModels[grdEngineModels.CurrentRowIndex, grdEngineModels.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["EngineModel"])} ").Trim();

						lCol1++;
						grdEngineModels.CurrentColumnIndex = lCol1;
						grdEngineModels.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						//UPGRADE_WARNING: (1068) lTempColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						grdEngineModels.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lTempColor));
						grdEngineModels[grdEngineModels.CurrentRowIndex, grdEngineModels.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["Prefix"])} ").Trim();

						lCol1++;
						grdEngineModels.CurrentColumnIndex = lCol1;
						grdEngineModels.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						//UPGRADE_WARNING: (1068) lTempColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						grdEngineModels.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lTempColor));
						grdEngineModels[grdEngineModels.CurrentRowIndex, grdEngineModels.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["Core"])} ").Trim();

						lCol1++;
						grdEngineModels.CurrentColumnIndex = lCol1;
						grdEngineModels.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						//UPGRADE_WARNING: (1068) lTempColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						grdEngineModels.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lTempColor));
						grdEngineModels[grdEngineModels.CurrentRowIndex, grdEngineModels.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["Suffix1"])} ").Trim();

						lCol1++;
						grdEngineModels.CurrentColumnIndex = lCol1;
						grdEngineModels.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						//UPGRADE_WARNING: (1068) lTempColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						grdEngineModels.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lTempColor));
						grdEngineModels[grdEngineModels.CurrentRowIndex, grdEngineModels.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["Suffix2"])} ").Trim();

						lCol1++;
						grdEngineModels.CurrentColumnIndex = lCol1;
						grdEngineModels.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
						//UPGRADE_WARNING: (1068) lTempColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						grdEngineModels.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lTempColor));
						grdEngineModels[grdEngineModels.CurrentRowIndex, grdEngineModels.CurrentColumnIndex].Value = modAdminCommon.ReturnYesNo(($"{Convert.ToString(rstRec1["ActiveFlag"])} ").Trim());

						lCol1++;
						grdEngineModels.CurrentColumnIndex = lCol1;
						grdEngineModels.CellAlignment = DataGridViewContentAlignment.MiddleRight;
						//UPGRADE_WARNING: (1068) lTempColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						grdEngineModels.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lTempColor));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["TakeoffPower"]))
						{
							grdEngineModels[grdEngineModels.CurrentRowIndex, grdEngineModels.CurrentColumnIndex].Value = Convert.ToString(rstRec1["TakeoffPower"]);
						}

						lCol1++;
						grdEngineModels.CurrentColumnIndex = lCol1;
						grdEngineModels.CellAlignment = DataGridViewContentAlignment.MiddleRight;
						//UPGRADE_WARNING: (1068) lTempColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						grdEngineModels.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lTempColor));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["MaxPower"]))
						{
							grdEngineModels[grdEngineModels.CurrentRowIndex, grdEngineModels.CurrentColumnIndex].Value = Convert.ToString(rstRec1["MaxPower"]);
						}

						lCol1++;
						grdEngineModels.CurrentColumnIndex = lCol1;
						grdEngineModels.CellAlignment = DataGridViewContentAlignment.MiddleRight;
						//UPGRADE_WARNING: (1068) lTempColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						grdEngineModels.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lTempColor));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["MfrCompId"]))
						{
							grdEngineModels[grdEngineModels.CurrentRowIndex, grdEngineModels.CurrentColumnIndex].Value = Convert.ToString(rstRec1["MfrCompId"]);
						}

						lCol1++;
						grdEngineModels.CurrentColumnIndex = lCol1;
						grdEngineModels.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						//UPGRADE_WARNING: (1068) lTempColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						grdEngineModels.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lTempColor));
						grdEngineModels[grdEngineModels.CurrentRowIndex, grdEngineModels.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["MfrAbbrev"])} ").Trim();

						lCol1++;
						grdEngineModels.CurrentColumnIndex = lCol1;
						grdEngineModels.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						//UPGRADE_WARNING: (1068) lTempColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						grdEngineModels.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lTempColor));
						grdEngineModels[grdEngineModels.CurrentRowIndex, grdEngineModels.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["MfrName"])} ").Trim();

						lCol1++;
						grdEngineModels.CurrentColumnIndex = lCol1;
						grdEngineModels.CellAlignment = DataGridViewContentAlignment.MiddleRight;
						//UPGRADE_WARNING: (1068) lTempColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						grdEngineModels.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lTempColor));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["ThrustLbs"]))
						{
							grdEngineModels[grdEngineModels.CurrentRowIndex, grdEngineModels.CurrentColumnIndex].Value = Convert.ToString(rstRec1["ThrustLbs"]);
						}

						lCol1++;
						grdEngineModels.CurrentColumnIndex = lCol1;
						grdEngineModels.CellAlignment = DataGridViewContentAlignment.MiddleRight;
						//UPGRADE_WARNING: (1068) lTempColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						grdEngineModels.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lTempColor));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["TBOHours"]))
						{
							grdEngineModels[grdEngineModels.CurrentRowIndex, grdEngineModels.CurrentColumnIndex].Value = Convert.ToString(rstRec1["TBOHours"]);
						}

						lCol1++;
						grdEngineModels.CurrentColumnIndex = lCol1;
						grdEngineModels.CellAlignment = DataGridViewContentAlignment.MiddleRight;
						//UPGRADE_WARNING: (1068) lTempColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						grdEngineModels.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lTempColor));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["ShaftHP"]))
						{
							grdEngineModels[grdEngineModels.CurrentRowIndex, grdEngineModels.CurrentColumnIndex].Value = Convert.ToString(rstRec1["ShaftHP"]);
						}

						lCol1++;
						grdEngineModels.CurrentColumnIndex = lCol1;
						grdEngineModels.CellAlignment = DataGridViewContentAlignment.MiddleRight;
						//UPGRADE_WARNING: (1068) lTempColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						grdEngineModels.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lTempColor));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["HSI"]))
						{
							grdEngineModels[grdEngineModels.CurrentRowIndex, grdEngineModels.CurrentColumnIndex].Value = Convert.ToString(rstRec1["HSI"]);
						}

						lCol1++;
						grdEngineModels.CurrentColumnIndex = lCol1;
						grdEngineModels.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
						//UPGRADE_WARNING: (1068) lTempColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						grdEngineModels.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lTempColor));
						grdEngineModels[grdEngineModels.CurrentRowIndex, grdEngineModels.CurrentColumnIndex].Value = modAdminCommon.ReturnYesNo(($"{Convert.ToString(rstRec1["OnTBO"])} ").Trim());

						lCol1++;
						grdEngineModels.CurrentColumnIndex = lCol1;
						grdEngineModels.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						//UPGRADE_WARNING: (1068) lTempColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						grdEngineModels.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lTempColor));
						grdEngineModels[grdEngineModels.CurrentRowIndex, grdEngineModels.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["ACMakeModel"])} ").Trim();

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
					lblExportToExcel[iExportEngineModels].Visible = true;

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

		private void cmdEngineModelsSave_Click(Object eventSender, EventArgs eventArgs)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			int lEMId = 0;
			string strEMId = "";
			string strEngineName = "";
			int lRow1 = 0;
			bool has_tbo_change = false;
			try
			{

				lRow1 = grdEngineModels.CurrentRowIndex;

				strEMId = txtEngineModel[iEMID].Text;
				strEngineName = txtEngineModel[iEMNAME].Text;

				if (strEMId != "")
				{

					if (Information.IsNumeric(strEMId))
					{

						lEMId = Convert.ToInt32(Double.Parse(strEMId));

						if (lEMId >= 0)
						{

							strQuery1 = $"SELECT * FROM Engine_Models WHERE (em_id = {strEMId}) ";
							rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);

							if (rstRec1.BOF && rstRec1.EOF)
							{
								rstRec1.AddNew();
							}

							rstRec1["em_engine_name"] = txtEngineModel[iEMNAME].Text.Trim();
							rstRec1["em_engine_prefix"] = txtEngineModel[iEMPREFIX].Text.Trim();
							rstRec1["em_engine_core"] = txtEngineModel[iEMCORE].Text.Trim();
							rstRec1["em_engine_suffix1"] = txtEngineModel[iEMSUFFIX1].Text.Trim();
							rstRec1["em_engine_suffix2"] = txtEngineModel[iEMSUFFIX2].Text.Trim();

							if (chkEngineModel[iEMACTIVE].CheckState == CheckState.Checked)
							{
								rstRec1["em_active_flag"] = "Y";
							}
							else
							{
								rstRec1["em_active_flag"] = "N";
							}

							if (Information.IsNumeric(txtEngineModel[iEMTAKEOFFPOWER].Text.Trim()))
							{
								rstRec1["em_takeoff_power"] = Convert.ToInt32(Double.Parse(txtEngineModel[iEMTAKEOFFPOWER].Text));
							}
							else
							{
								rstRec1["em_takeoff_power"] = 0;
							}

							if (Information.IsNumeric(txtEngineModel[iEMMAXCONPOWER].Text.Trim()))
							{
								rstRec1["em_max_continuous_power"] = Convert.ToInt32(Double.Parse(txtEngineModel[iEMMAXCONPOWER].Text));
							}
							else
							{
								rstRec1["em_max_continuous_power"] = 0;
							}

							if (Information.IsNumeric(txtEngineModel[iEMMFRCOMPID].Text.Trim()))
							{
								rstRec1["em_mfr_comp_id"] = Convert.ToInt32(Double.Parse(txtEngineModel[iEMMFRCOMPID].Text));
							}
							else
							{
								rstRec1["em_mfr_comp_id"] = 0;
							}

							rstRec1["em_mfr_comp_id"] = txtEngineModel[iEMMFRCOMPID].Text;
							rstRec1["em_mfr_name_abbrev"] = txtEngineModel[iEMMFRABBREV].Text.Trim();
							rstRec1["em_mfr_name"] = txtEngineModel[iEMMFRNAME].Text.Trim();

							if (Information.IsNumeric(txtEngineModel[iEMTHRUSTLBS].Text.Trim()))
							{
								rstRec1["em_engine_thrust_lbs"] = Convert.ToInt32(Double.Parse(txtEngineModel[iEMTHRUSTLBS].Text));
							}
							else
							{
								rstRec1["em_engine_thrust_lbs"] = 0;
							}

							if (Information.IsNumeric(txtEngineModel[iEMCOMTBOHRS].Text.Trim()))
							{
								rstRec1["em_engine_com_tbo_hrs"] = Convert.ToInt32(Double.Parse(txtEngineModel[iEMCOMTBOHRS].Text));
							}
							else
							{
								rstRec1["em_engine_com_tbo_hrs"] = 0;
							}

							// added MSW - 7/31/2020
							if (txtEngineModel[iEMCOMTBOHRS].Text.Trim() != Convert.ToString(txtEngineModel[iEMCOMTBOHRS].Tag).Trim())
							{
								modMyAdmin.Record_EventAdmin("TBO Hours Change", $"TBO Hours Changed: Model:{strEMId} From {Convert.ToString(txtEngineModel[iEMCOMTBOHRS].Tag).Trim()} to {txtEngineModel[iEMCOMTBOHRS].Text.Trim()}");
								has_tbo_change = true;
							}



							if (Information.IsNumeric(txtEngineModel[iEMSHAFTHP].Text.Trim()))
							{
								rstRec1["em_engine_shaft"] = Convert.ToInt32(Double.Parse(txtEngineModel[iEMSHAFTHP].Text));
							}
							else
							{
								rstRec1["em_engine_shaft"] = 0;
							}

							if (Information.IsNumeric(txtEngineModel[iEMHSI].Text.Trim()))
							{
								rstRec1["em_engine_hsi"] = Convert.ToInt32(Double.Parse(txtEngineModel[iEMHSI].Text));
							}
							else
							{
								rstRec1["em_engine_hsi"] = 0;
							}

							if (chkEngineModel[iEMONCONDITIONTBO].CheckState == CheckState.Checked)
							{
								rstRec1["em_on_condition_flag"] = "Y";
							}
							else
							{
								rstRec1["em_on_condition_flag"] = "N";
							}

							rstRec1.UpdateBatch();

							bEngineModelChanged = true;

							if (lEMId > 0)
							{
								lblEMStatus.Text = $"Engine Model Id [{strEMId}] Name [{strEngineName}] Has Been Saved";
								if (lRow1 > 0)
								{
									Move_Engine_Model_Edit_Form_Data_To_Grid_Row(lRow1);
								}
							}
							else
							{
								lblEMStatus.Text = $"Engine Model Id [{strEMId}] Name [{strEngineName}] Has Been Added";
							}

							modAdminCommon.Record_Event("Engine Models", lblEMStatus.Text, 0, 0, 0, false, 0, 0);

						}
						else
						{
							MessageBox.Show("Engine Id Is Less Than Zero", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						} // If lEMId >= 0 Then

					}
					else
					{
						MessageBox.Show("Engind Id Is Non-Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					} // If IsNumeric(strEMId) = True Then

				}
				else
				{
					MessageBox.Show("Engine Id Is Blank", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If strEMId <> "" Then


				// ADDED IN MSW - 10/23/2020-------------
				Update_AC_Models_Attached(Convert.ToInt32(Double.Parse(strEMId)));

				if (has_tbo_change)
				{
					if (MessageBox.Show("Would You Like To Update All 'Off Market' Aircraft for this Engine Model with Matching TBO", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
					{
						Update_Aircraft_TBO_Hours(Convert.ToInt32(Double.Parse(strEMId)), Convert.ToInt32(Double.Parse(Convert.ToString(txtEngineModel[iEMCOMTBOHRS].Tag).Trim())), Convert.ToInt32(Double.Parse(txtEngineModel[iEMCOMTBOHRS].Text.Trim())));
					}
				}

				grdEngineModels_Click(grdEngineModels, new EventArgs());

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("cmdEngineModelsSave_Click_Error", excep.Message);
			}

		} // cmdEngineModelsSave_Click


		private void cmdSaveCREG_Click(Object eventSender, EventArgs eventArgs)
		{
			//aey 10/4/2005         canadian registry("Update")
			string Query = "";

			switch(RecordStat)
			{
				case "Add" : 
					if (modAdminCommon.Exist($"select * from Canadian_Registry_Models where crm_make_name = '{txt_crm_Make.Text}' and crm_model_name='{txt_crm_model.Text}'"))
					{
						MessageBox.Show($"Aircraft Status   '{txt_astat_name.Text}',   currently used in the Canadian_Registry_Models Table- ADD CANCELLED.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					}
					else
					{
						grdCREG.RowsCount++;
						grdCREG.CurrentRowIndex = grdCREG.RowsCount - 1;
						grdCREG.CurrentColumnIndex = 0;
						grdCREG[grdCREG.CurrentRowIndex, grdCREG.CurrentColumnIndex].Value = "";
						grdCREG.CurrentColumnIndex = 1;
						grdCREG[grdCREG.CurrentRowIndex, grdCREG.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_crm_Make).Trim();
						grdCREG.CurrentColumnIndex = 2;
						grdCREG[grdCREG.CurrentRowIndex, grdCREG.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_crm_model).Trim();
						grdCREG.CurrentColumnIndex = 3;
						grdCREG[grdCREG.CurrentRowIndex, grdCREG.CurrentColumnIndex].Value = txt_crm_amod_list.Text.Trim();

						Query = "INSERT INTO Canadian_Registry_Models (crm_make_name, crm_model_name,crm_amod_list ) values (";
						Query = $"{Query}'{modAdminCommon.Fix_Quote(txt_crm_Make)}','{modAdminCommon.Fix_Quote(txt_crm_model)}','{txt_crm_amod_list.Text.Trim()}')";
						DbCommand TempCommand = null;
						TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
						TempCommand.CommandText = Query;
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
						TempCommand.ExecuteNonQuery();
						Is_Dirty = true;
						MessageBox.Show("Insert Successfully Completed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					} 
					 
					break;
				case "Update" : 
					//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' 
					// Update 'Aircraft Status' record 
					//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' 
					grdCREG.CurrentColumnIndex = 1; 
					grdCREG[grdCREG.CurrentRowIndex, grdCREG.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_crm_Make); 
					grdCREG.CurrentColumnIndex = 2; 
					grdCREG[grdCREG.CurrentRowIndex, grdCREG.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txt_crm_model); 
					grdCREG.CurrentColumnIndex = 3; 
					grdCREG[grdCREG.CurrentRowIndex, grdCREG.CurrentColumnIndex].Value = txt_crm_amod_list; 
					 
					Query = $"UPDATE Canadian_Registry_Models SET crm_make_name='{modAdminCommon.Fix_Quote(txt_crm_Make)}',"; 
					Query = $"{Query}crm_model_name='{modAdminCommon.Fix_Quote(txt_crm_model)}', crm_amod_list ='{txt_crm_amod_list.Text.Trim()}' "; 
					Query = $"{Query}WHERE crm_id= {txt_crm_id.Text} "; 
					DbCommand TempCommand_2 = null; 
					TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand(); 
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2); 
					TempCommand_2.CommandText = Query; 
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2); 
					TempCommand_2.ExecuteNonQuery(); 
					MessageBox.Show("Update Successfully Completed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly())); 
					 
					break;
			}

			grdCREG.Refresh();
			pnl_CREG.Visible = false;
			this.Cursor = CursorHelper.CursorDefault;

		}

		private void acTopicsUpdateEvo_Click(Object eventSender, EventArgs eventArgs)
		{

			modAdminCommon.Table_Action_Log("Aircraft_Topic");
			MessageBox.Show("Aircraft_Topi Table Submitted to Evolution Listener for Update.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));

		}

		//UPGRADE_NOTE: (7001) The following declaration (Command1_Click) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void Command1_Click()
		//{
			//
			//
			//
		//}



		public void ShellOpenURLInBrowser(string strBrowser, string strURL)
		{

			object objIE = null; // If All Else Fails
			string strBrowserCmd = "";
			string strBrowserName = "";
			string strMozilla = "";
			string strChrome = "";

			int lErrNbr = 0;
			string strErrDesc = "";

			try
			{

				if (strBrowser == "")
				{
					strBrowser = "I";
				}


				if (strURL != "")
				{


					switch(strBrowser)
					{
						case "D" : case "Default" : 
							 
							strBrowserName = "Default"; 
							strBrowserCmd = ""; 
							 
							break;
						case "I" : case "Explorer" : case "Internet Explorer" : case "IE" :  // Internet Explorer 
							 
							// Default: "C:\Program Files\Internet Explorer\IEXPLORE.EXE" %1 
							strBrowserName = "Internet Explorer"; 
							 
							strBrowserCmd = modAdminCommon.ReadRegistryKeyString(modAdminCommon.HKEY_CLASSES_ROOT, "Applications\\iexplore.exe\\shell\\open\\command", ""); 
							strBrowserCmd = StringsHelper.Replace(strBrowserCmd, "%1", strURL, 1, -1, CompareMethod.Binary); 
							 
							break;
						case "M" : case "Firefox" : case "Mozilla" : case "Mozilla Firefox" :  // Mozilla 
							 
							// Default: "C:\Program Files\Mozilla Firefox\firefox.exe" -osint -url "%1" 
							strBrowserName = "Mozilla Firefox"; 
							 
							strBrowserCmd = modAdminCommon.ReadRegistryKeyString(modAdminCommon.HKEY_CLASSES_ROOT, "FirefoxHTML\\shell\\open\\command", ""); 
							 
							if (strBrowserCmd != "")
							{
								strURL = StringsHelper.Replace(strURL, "\"", "", 1, -1, CompareMethod.Binary);
								strBrowserCmd = StringsHelper.Replace(strBrowserCmd, "%1", strURL, 1, -1, CompareMethod.Binary);
							} 
							 
							break;
						case "C" : case "Chrome" : case "Google Chrome" :  // Chrome 
							 
							// Default: "C:\Documents and Settings\TECHPC03\Local Settings\Application Data\Google\Chrome\Application\chrome.exe" -- "%1" 
							strBrowserName = "Google Chrome"; 
							strBrowserCmd = modAdminCommon.ReadRegistryKeyString(modAdminCommon.HKEY_CLASSES_ROOT, "Applications\\chrome.exe\\shell\\open\\command", ""); 
							if (strBrowserCmd == "")
							{
								strBrowserCmd = modAdminCommon.ReadRegistryKeyString(modAdminCommon.HKEY_CLASSES_ROOT, "ChromeHTML\\shell\\open\\command", "");
							} 
							 
							if (strBrowserCmd != "")
							{
								strURL = StringsHelper.Replace(strURL, "\"", "", 1, -1, CompareMethod.Binary);
								strBrowserCmd = StringsHelper.Replace(strBrowserCmd, " -- ", " --new-window --app=", 1, -1, CompareMethod.Binary);
								strBrowserCmd = StringsHelper.Replace(strBrowserCmd, "%1", strURL, 1, -1, CompareMethod.Binary);
							} 
							 
							break;
					} // Case strBrowser

					if (strBrowserCmd != "")
					{

						//UPGRADE_TODO: (7005) parameters (if any) must be set using the Arguments property of ProcessStartInfo More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-7005
						ProcessStartInfo startInfo = new ProcessStartInfo(strBrowserCmd);
						startInfo.WindowStyle = ProcessWindowStyle.Normal;
						Process.Start(startInfo);

					}
					else
					{

						if ((strURL.IndexOf("http") + 1) == 0 && strURL.StartsWith("www", StringComparison.Ordinal))
						{
							strURL = $"http://{strURL}";
						}
						JetNetSupport.PInvoke.SafeNative.shell32.ShellExecute(Support.GetHInstance().ToInt32(), "open", strURL, null, null, modAdminCommon.SW_SHOWNORMAL);

					}

				} // If strURL <> "" Then
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErrNbr = Information.Err().Number;
				strErrDesc = excep.Message;

				//AddItemToLogFile "ShellOpenURLInBrowser_Error: " & strErrDesc
				modAdminCommon.Report_Error($"ShellOpenURLInBrowser_Error: {strErrDesc}");
			}

		} // ShellOpenURLInBrowser


		private void FG_AirCraft_Asking_Click(Object eventSender, EventArgs eventArgs)
		{
			//aey 4/21/2004
			RecordStat = "Update";
			FG_AirCraft_Asking.CurrentColumnIndex = 0;
			txt_aask_name.Text = $"{FG_AirCraft_Asking[FG_AirCraft_Asking.CurrentRowIndex, FG_AirCraft_Asking.CurrentColumnIndex].FormattedValue.ToString()}";
			FG_AirCraft_Asking.CurrentColumnIndex = 1;
			txt_aask_description.Text = FG_AirCraft_Asking[FG_AirCraft_Asking.CurrentRowIndex, FG_AirCraft_Asking.CurrentColumnIndex].FormattedValue.ToString();
			pnl_NameDesc_Asking.Visible = true;
			txt_aask_name.Enabled = false;

		}

		private void FG_Aircraft_Class_Click(Object eventSender, EventArgs eventArgs)
		{
			//aey 4/21/2004

			RecordStat = "Update";
			FG_Aircraft_Class.CurrentColumnIndex = 0;
			txt_aclass_code.Text = $"{FG_Aircraft_Class[FG_Aircraft_Class.CurrentRowIndex, FG_Aircraft_Class.CurrentColumnIndex].FormattedValue.ToString()}";
			FG_Aircraft_Class.CurrentColumnIndex = 1;
			txt_aclass_Name.Text = $"{FG_Aircraft_Class[FG_Aircraft_Class.CurrentRowIndex, FG_Aircraft_Class.CurrentColumnIndex].FormattedValue.ToString()}";
			pnl_Aircraft_Class_AddUpdate.Visible = true;
			txt_aclass_code.Enabled = false;

		}

		private void FG_Aircraft_Status_Click(Object eventSender, EventArgs eventArgs)
		{
			//aey 4/20/2004

			RecordStat = "Update";
			FG_Aircraft_Status.CurrentColumnIndex = 0;
			txt_astat_name.Text = FG_Aircraft_Status[FG_Aircraft_Status.CurrentRowIndex, FG_Aircraft_Status.CurrentColumnIndex].FormattedValue.ToString();
			FG_Aircraft_Status.CurrentColumnIndex = 1;
			txt_astat_description.Text = FG_Aircraft_Status[FG_Aircraft_Status.CurrentRowIndex, FG_Aircraft_Status.CurrentColumnIndex].FormattedValue.ToString();
			pnl_Update_Aircraft_Status.Visible = true;

		}

		private void FG_Aircraft_Type_Click(Object eventSender, EventArgs eventArgs)
		{
			//aey 4/21/2004

			RecordStat = "Update";
			FG_Aircraft_Type.CurrentColumnIndex = 0;
			txt_atype_code.Text = $"{FG_Aircraft_Type[FG_Aircraft_Type.CurrentRowIndex, FG_Aircraft_Type.CurrentColumnIndex].FormattedValue.ToString()}";
			FG_Aircraft_Type.CurrentColumnIndex = 1;
			txt_atype_Name.Text = $"{FG_Aircraft_Type[FG_Aircraft_Type.CurrentRowIndex, FG_Aircraft_Type.CurrentColumnIndex].FormattedValue.ToString()}";
			pnl_Aircraft_Type_AddUpdate.Visible = true;
			txt_atype_code.Enabled = false;

		}

		private void FG_Auxiliary_Power_Click(Object eventSender, EventArgs eventArgs)
		{
			//aey 4/21/2004

			RecordStat = "Update";
			FG_Auxiliary_Power.CurrentColumnIndex = 0;
			txt_apu_make_name.Text = $"{FG_Auxiliary_Power[FG_Auxiliary_Power.CurrentRowIndex, FG_Auxiliary_Power.CurrentColumnIndex].FormattedValue.ToString()}";
			FG_Auxiliary_Power.CurrentColumnIndex = 1;
			txt_apu_model_name.Text = $"{FG_Auxiliary_Power[FG_Auxiliary_Power.CurrentRowIndex, FG_Auxiliary_Power.CurrentColumnIndex].FormattedValue.ToString()}";
			pnl_APU_Update_Change.Visible = true;
			txt_apu_make_name.Enabled = false;

		}

		private void FG_Avionics_Click(Object eventSender, EventArgs eventArgs)
		{
			//aey 4/21/2004
			RecordStat = "Update";
			FG_Avionics.CurrentColumnIndex = 0;
			txt_avion_name.Text = $"{FG_Avionics[FG_Avionics.CurrentRowIndex, FG_Avionics.CurrentColumnIndex].FormattedValue.ToString()}";
			FG_Avionics.CurrentColumnIndex = 1;
			txt_avion_notes.Text = $"{FG_Avionics[FG_Avionics.CurrentRowIndex, FG_Avionics.CurrentColumnIndex].FormattedValue.ToString()}";
			pnl_avionics_Update_Change.Visible = true;
			txt_avion_name.Enabled = false;

		}

		private void FG_Engine_Maintenance_Click(Object eventSender, EventArgs eventArgs)
		{
			//aey 4/21/2004

			RecordStat = "Update";
			FG_Engine_Maintenance.CurrentColumnIndex = 0;
			txt_emp_code.Text = $"{FG_Engine_Maintenance[FG_Engine_Maintenance.CurrentRowIndex, FG_Engine_Maintenance.CurrentColumnIndex].FormattedValue.ToString()}";
			FG_Engine_Maintenance.CurrentColumnIndex = 1;
			txt_emp_name.Text = $"{FG_Engine_Maintenance[FG_Engine_Maintenance.CurrentRowIndex, FG_Engine_Maintenance.CurrentColumnIndex].FormattedValue.ToString()}";
			FG_Engine_Maintenance.CurrentColumnIndex = 2;
			txt_Emp_ID.Text = $"{FG_Engine_Maintenance[FG_Engine_Maintenance.CurrentRowIndex, FG_Engine_Maintenance.CurrentColumnIndex].FormattedValue.ToString()}";
			FG_Engine_Maintenance.CurrentColumnIndex = 3;
			txt_Provider_Name.Text = $"{FG_Engine_Maintenance[FG_Engine_Maintenance.CurrentRowIndex, FG_Engine_Maintenance.CurrentColumnIndex].FormattedValue.ToString()}";
			FG_Engine_Maintenance.CurrentColumnIndex = 4;
			txt_Program_Name.Text = $"{FG_Engine_Maintenance[FG_Engine_Maintenance.CurrentRowIndex, FG_Engine_Maintenance.CurrentColumnIndex].FormattedValue.ToString()}";
			pnl_EMP_AddUpdate.Visible = true;
			txt_emp_code.Enabled = false;

		}

		private void FG_Interior_Configuration_Click(Object eventSender, EventArgs eventArgs)
		{

			RecordStat = "Update";
			FG_Interior_Configuration.CurrentColumnIndex = 0;
			txt_intconfig_name.Text = $"{FG_Interior_Configuration[FG_Interior_Configuration.CurrentRowIndex, FG_Interior_Configuration.CurrentColumnIndex].FormattedValue.ToString()}";
			pnl_IC_Update_Change.Visible = true;
			txt_intconfig_name.Enabled = true;

		}

		private void FG_KeyFeature_Click(Object eventSender, EventArgs eventArgs)
		{
			//aey 4/20/2004  Update existing key Features

			string Query = "";
			ADORecordSetHelper RS_Table = new ADORecordSetHelper();
			int lngResult = 0;

			pnl_kfeat_test.Visible = true;
			RecordStat = "Update";
			txt_kfeat_code.Enabled = false;
			//Key_Feature ("Select")
			cmd_Delete_Kfeat.Visible = true;


			FG_KeyFeature.CurrentColumnIndex = 0;
			if (Strings.Len(($"{FG_KeyFeature[FG_KeyFeature.CurrentRowIndex, FG_KeyFeature.CurrentColumnIndex].FormattedValue.ToString()}").Trim()) > 0)
			{
				Query = "SELECT * from Key_Feature ";
				Query = $"{Query} Where kfeat_code ='{FG_KeyFeature[FG_KeyFeature.CurrentRowIndex, FG_KeyFeature.CurrentColumnIndex].FormattedValue.ToString().Trim()}'";
				RS_Table.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				txt_kfeat_code.Text = ($"{Convert.ToString(RS_Table["kfeat_code"])} ").Trim();
				txt_kfeat_code.Enabled = false;
				txt_kfeat_name.Text = ($"{Convert.ToString(RS_Table["kfeat_name"])} ").Trim();

				// CHECK THE BOX IF THE AUTO GEN FLAG IS SET.
				if (($"{Convert.ToString(RS_Table["kfeat_auto_generate_flag"])}").Trim().ToUpper() == "Y")
				{
					chk_AutoGen.CheckState = CheckState.Checked;
				}
				else
				{
					chk_AutoGen.CheckState = CheckState.Unchecked;
				}

				if (($"{Convert.ToString(RS_Table["kfeat_product_business_flag"])}").Trim().ToUpper() == "Y")
				{
					chk_product_flags[0].CheckState = CheckState.Checked;
				}
				else
				{
					chk_product_flags[0].CheckState = CheckState.Unchecked;
				}

				if (($"{Convert.ToString(RS_Table["kfeat_product_commercial_flag"])}").Trim().ToUpper() == "Y")
				{
					chk_product_flags[1].CheckState = CheckState.Checked;
				}
				else
				{
					chk_product_flags[1].CheckState = CheckState.Unchecked;
				}

				if (($"{Convert.ToString(RS_Table["kfeat_product_helicopter_flag"])}").Trim().ToUpper() == "Y")
				{
					chk_product_flags[2].CheckState = CheckState.Checked;
				}
				else
				{
					chk_product_flags[2].CheckState = CheckState.Unchecked;
				}

				if (($"{Convert.ToString(RS_Table["kfeat_model_dependent_flag"])}").Trim().ToUpper() == "Y")
				{
					chk_product_flags[3].CheckState = CheckState.Checked;
				}
				else
				{
					chk_product_flags[3].CheckState = CheckState.Unchecked;
				}

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(RS_Table["kfeat_area"]))
				{
					cbo_feat_area.Text = Convert.ToString(RS_Table["kfeat_area"]);
				}
				else
				{
					cbo_feat_area.Text = "";
				}

				Fill_cbo_feat_area(cbo_feat_area.Text);

				txt_kfeat_description.Text = ($"{Convert.ToString(RS_Table["kfeat_description"])} ").Trim();
				txt_kfeat_research_notes.Text = ($"{Convert.ToString(RS_Table["kfeat_research_notes"])} ").Trim();
				txt_kfeat_howtoformat.Text = ($"{Convert.ToString(RS_Table["kfeat_howtoformat"])}").Trim();
				txt_kfeat_wheretoenter.Text = ($"{Convert.ToString(RS_Table["kfeat_wheretoenter"])}").Trim();

				//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
				if (!Convert.IsDBNull(RS_Table["kfeat_inactive_date"]))
				{
					if (Information.IsDate(RS_Table["kfeat_inactive_date"]))
					{
						chk_Inactive_Feature_Code.CheckState = CheckState.Checked;
						txt_InactiveDate.Text = Convert.ToDateTime(RS_Table["kfeat_inactive_date"]).ToString("d");
						txt_InactiveDate.Visible = true;
						KeyFeatureWasActive = false;
					}
					else
					{
						chk_Inactive_Feature_Code.CheckState = CheckState.Unchecked;
						txt_InactiveDate.Text = "";
						txt_InactiveDate.Visible = false;
						KeyFeatureWasActive = true;
					}
				}
				else
				{
					chk_Inactive_Feature_Code.CheckState = CheckState.Unchecked;
					txt_InactiveDate.Text = "";
					txt_InactiveDate.Visible = false;
					KeyFeatureWasActive = true;
				}

				if (($"{Convert.ToString(RS_Table["kfeat_donotclear"])}").Trim().ToUpper() == "Y")
				{
					chk_kfeat_donotclear.CheckState = CheckState.Checked;
				}
				else
				{
					chk_kfeat_donotclear.CheckState = CheckState.Unchecked;
				}

				if (chkShowCounts.CheckState == CheckState.Checked)
				{

					lblCount[0].Visible = false;
					lblCount[1].Visible = false;
					lblCount[2].Visible = false;

					lblCount[0].Text = $"Yes: {modAdminCommon.CountACFeatures(0, ($"{Convert.ToString(RS_Table["kfeat_code"])}").Trim(), "Y").ToString()}";
					lblCount[1].Text = $"No: {modAdminCommon.CountACFeatures(0, ($"{Convert.ToString(RS_Table["kfeat_code"])}").Trim(), "N").ToString()}";

					lngResult = modAdminCommon.Key_Feature_Auto_Count(($"{Convert.ToString(RS_Table["kfeat_code"])}").Trim(), 0);

					if (lngResult == -1)
					{
						lblCount[2].Text = "Data: N/A";
					}
					else
					{
						lblCount[2].Text = $"Data: {lngResult.ToString()}";
					}

					lblCount[0].Visible = true;
					lblCount[1].Visible = true;
					lblCount[2].Visible = true;

				}
				else
				{
					lblCount[0].Visible = false;
					lblCount[1].Visible = false;
					lblCount[2].Visible = false;
				}

				pnlAdmin.Visible = true;
				txt_kfeat_query.Text = ($"{Convert.ToString(RS_Table["kfeat_query"])}").Trim();
			}


			was_model_dependant = false;
			if (chk_product_flags[3].CheckState == CheckState.Checked)
			{
				was_model_dependant = true;
			}

			chkShowCounts.Visible = true;
			RS_Table.Close();

		}
		public void Fill_cbo_feat_area(string selected_area_text)
		{

			ADORecordSetHelper ado_FieldList = new ADORecordSetHelper(); //Current recordset

			cbo_feat_area.Items.Clear();
			cbo_feat_area.AddItem("");

			string SQL = "SELECT distinct kfeat_area  from Key_Feature "; //Current query sql
			SQL = $"{SQL}where (kfeat_inactive_date = '' or kfeat_inactive_date is null) and kfeat_area <> ''  ";

			ado_FieldList.Open(SQL, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

			while (!ado_FieldList.EOF)
			{

				cbo_feat_area.AddItem(($"{Convert.ToString(ado_FieldList["kfeat_area"])}").Trim());

				if (Convert.ToString(ado_FieldList["kfeat_area"]).Trim() == selected_area_text)
				{
					cbo_feat_area.Text = Convert.ToString(ado_FieldList["kfeat_area"]).Trim();
				}


				ado_FieldList.MoveNext();
			}


			ado_FieldList.Close();


		}


		private void FG_Operating_Certification_Click(Object eventSender, EventArgs eventArgs)
		{
			//aey 4/21/2004


			int lRow = FG_Operating_Certification.CurrentRowIndex;

			RecordStat = "Update";
			txt_certification_name[0].Text = Convert.ToString(FG_Operating_Certification[lRow, 0].Value);

			cbo_Ops_Cert_usaFlag.Text = Convert.ToString(FG_Operating_Certification[lRow, 1].Value).Substring(0, Math.Min(1, Convert.ToString(FG_Operating_Certification[lRow, 1].Value).Length));

			txt_certification_name[2].Text = Convert.ToString(FG_Operating_Certification[lRow, 2].Value);
			pnl_Certification_Update_Change.Visible = true;
			txt_certification_name[0].Enabled = false;
			chkCertActive.CheckState = CheckState.Unchecked;

			chkCertActive.CheckState = CheckState.Unchecked;
			if (Convert.ToString(FG_Operating_Certification[lRow, 3].Value) == "Yes")
			{
				chkCertActive.CheckState = CheckState.Checked;
			}

		}

		private void FG_Specification_Click(Object eventSender, EventArgs eventArgs)
		{
			//aey 4/21/2004

			RecordStat = "Update";
			FG_Specification.CurrentColumnIndex = 0;
			txt_spec_name.Text = $"{FG_Specification[FG_Specification.CurrentRowIndex, FG_Specification.CurrentColumnIndex].FormattedValue.ToString()}";
			FG_Specification.CurrentColumnIndex = 1;
			txt_spec_type.Text = $"{FG_Specification[FG_Specification.CurrentRowIndex, FG_Specification.CurrentColumnIndex].FormattedValue.ToString()}";
			FG_Specification.CurrentColumnIndex = 2;
			txt_spec_notes.Text = $"{FG_Specification[FG_Specification.CurrentRowIndex, FG_Specification.CurrentColumnIndex].FormattedValue.ToString()}";
			pnl_Spec_Update_Change.Visible = true;
			txt_spec_name.Enabled = false;

		}

		private void FGRD_AircraftContactType_Click(Object eventSender, EventArgs eventArgs)
		{
			//aey 4/28/2004

			RecordStat = "Update";
			Aircraft_Contact_Type("Select");
			pnl_ACTypeMain.Visible = true;
			pnl_Aircraft_Contact_Type_AddUpdate.Visible = true;

		}

		private void FGRD_Certifed_Click(Object eventSender, EventArgs eventArgs)
		{
			//aey 4/28/2004
			RecordStat = "Update";
			FGRD_Certifed.CurrentColumnIndex = 0;
			txt_cert_name_cert.Text = $"{FGRD_Certifed[FGRD_Certifed.CurrentRowIndex, FGRD_Certifed.CurrentColumnIndex].FormattedValue.ToString()}";
			txt_cert_name_cert.Enabled = false;
			pnl_Certified_Update_Change.Visible = true;

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
		private void Form_Load()
		{

			modStatusBar.Clear_Status_Bar(modAdminCommon.SB);

			Is_Dirty = false;


			// make the ac class tab invisible
			SSTabHelper.SetTabVisible(tab_Lookup, 4, false);

			// RTW - 6/20/2023
			SSTabHelper.SetTabVisible(tab_Lookup, 16, false); // ABI AIRCRAFT TAB
			SSTabHelper.SetTabVisible(tab_Lookup, 18, false); // AIRCRAFT TOPICS - NO LONGER USED
			SSTabHelper.SetTabVisible(tab_Lookup, 22, false); // OPEN TAB
			SSTabHelper.SetTabVisible(tab_Lookup, 23, false); // OPEN TAB


			SSTabHelper.SetSelectedIndex(tab_Lookup, 0);
			tab_Lookup_SelectedIndexChanged(tab_Lookup, new EventArgs());
			//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			// Initialize the ToolBar
			//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			ToolbarSetup();
			ToolbarButtonsSetup();

			cboShow.Items.Clear();
			cboShow.AddItem("All");
			cboShow.AddItem("Aircraft Relationships");
			cboShow.AddItem("Company Relationships");
			cboShow.AddItem("Transaction Relationships");
			cboShow.AddItem("Fractional Share Relationships");
			cboShow.SelectedIndex = 0;

			//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			// Show/Hide update command buttons on the tabs
			//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			if ((($"{Convert.ToString(modMyAdmin.MYSNP_USER["user_type"])} ").Trim() == "Research Manager") || (($"{Convert.ToString(modMyAdmin.MYSNP_USER["user_type"])} ").Trim() == "Administrator"))
			{
				Update_Command_Buttons("Enable");
			}
			else
			{
				Update_Command_Buttons("Disable");
			}

		}

		private void Form_FormClosing(Object eventSender, FormClosingEventArgs eventArgs)
		{
			int Cancel = (eventArgs.Cancel) ? 1 : 0;
			int UnloadMode = (int) eventArgs.CloseReason;
			try
			{

				if (Is_Dirty)
				{
					tab_Lookup_SelectedIndexChanged(tab_Lookup, new EventArgs());
				}
			}
			finally
			{
				eventArgs.Cancel = Cancel != 0;
			}

		}


		private void grd_ABI_Hide_AC_Click(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				grd_ABI_Hide_AC.CurrentColumnIndex = 0;
				Text1[0].Text = grd_ABI_Hide_AC[grd_ABI_Hide_AC.CurrentRowIndex, grd_ABI_Hide_AC.CurrentColumnIndex].FormattedValue.ToString();
				grd_ABI_Hide_AC.CurrentColumnIndex = 1;
				lbl_generic[5].Text = grd_ABI_Hide_AC[grd_ABI_Hide_AC.CurrentRowIndex, grd_ABI_Hide_AC.CurrentColumnIndex].FormattedValue.ToString();
				grd_ABI_Hide_AC.CurrentColumnIndex = 2;
				lbl_generic[6].Text = grd_ABI_Hide_AC[grd_ABI_Hide_AC.CurrentRowIndex, grd_ABI_Hide_AC.CurrentColumnIndex].FormattedValue.ToString();
				grd_ABI_Hide_AC.CurrentColumnIndex = 3;
				lbl_generic[7].Text = grd_ABI_Hide_AC[grd_ABI_Hide_AC.CurrentRowIndex, grd_ABI_Hide_AC.CurrentColumnIndex].FormattedValue.ToString();
				lbl_generic[1].Visible = true;
				lbl_generic[3].Visible = true;
				lbl_generic[4].Visible = true;
				lbl_generic[5].Visible = true;
				lbl_generic[6].Visible = true;
				lbl_generic[7].Visible = true;
				Text1[0].Visible = true;
				lbl_generic[0].Visible = true;
				cmd_button[0].Text = "Add";
			}
			catch (System.Exception excep)
			{
				this.Cursor = CursorHelper.CursorDefault;
				Is_Dirty = false;
				modAdminCommon.Report_Error($"grd_ABI_Hide_AC_Click{excep.Message}");
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1065
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
				return;
			}
		}

		private void grd_Airport_Click(Object eventSender, EventArgs eventArgs)
		{
			// resort the list based on the column clicked
			// sorts for city,state,country, & freq added 9/24/04
			int lRow = 0;

			if (grd_Airport.MouseRow == 0)
			{

				// Default
				AirportSort = "ORDER BY aport_iata_code, aport_icao_code, aport_name ";

				switch(grd_Airport.MouseCol)
				{
					case 0 :  // IATA 
						AirportSort = "ORDER BY aport_iata_code, aport_icao_code, aport_name "; 
						break;
					case 1 :  // ICAO 
						AirportSort = "ORDER BY aport_icao_code, aport_iata_code, aport_name "; 
						break;
					case 2 :  // FAAID 
						AirportSort = "ORDER BY aport_faaid_code, aport_iata_code, aport_icao_code, aport_name "; 
						break;
					case 3 :  // Airport Name 
						AirportSort = "ORDER BY aport_name, aport_icao_code, aport_iata_code "; 
						break;
					case 4 :  // Airport City 
						AirportSort = "ORDER BY aport_city, aport_name, aport_icao_code, aport_iata_code "; 
						break;
					case 5 :  // State 
						AirportSort = "ORDER BY aport_state, aport_name, aport_icao_code, aport_iata_code "; 
						break;
					case 6 :  // Country 
						AirportSort = "ORDER BY aport_country, aport_state, aport_city, aport_name, aport_icao_code, aport_iata_code "; 
						break;
					case 8 :  // Aircraft Counts 
						if (chkAirportListOptions[APortACCounts].CheckState == CheckState.Checked)
						{
							AirportSort = "ORDER BY ACCount DESC, aport_iata_code, aport_icao_code, aport_name ";
						} 
						break;
					case 9 :  // FAA Flight Dat Counts 
						if (chkAirportListOptions[APortFAACounts].CheckState == CheckState.Checked)
						{
							AirportSort = "ORDER BY FAACount DESC, aport_iata_code, aport_icao_code, aport_name ";
						} 
						break;
				}

				StopIt = false;
				cmd_Refresh_Airports.Text = "&Stop";

				Airport_Fill_List();

			}
			else
			{
				// DISPLAY THE RECORD SELECTED
				lRow = grd_Airport.CurrentRowIndex;
				cmd_Airport_Delete.Visible = true;
				cmd_Airport_Delete.Enabled = true;
				lblAirport[0].Text = "Airport Name";
				frmAirport.Enabled = false;
				Airport_Select();
				RecordStat = "Update";
				frmAirport.Enabled = true;
				grd_Airport.CurrentRowIndex = lRow;
				grd_Airport.CurrentColumnIndex = 0;
				grd_Airport.ColSel = grd_Airport.ColumnsCount - 1;
				txtAirport[iAPORTNAME_INDEX].Focus();
			}

		} // grd_Airport_Click

		private void grd_maint_items_Click(Object eventSender, EventArgs eventArgs)
		{

			cmd_maint[5].Visible = grd_maint_items.CurrentRowIndex != 0;


			fill_maintenance_item(grd_maint_items.get_RowData(grd_maint_items.CurrentRowIndex));

		}


		private void grd_maint_items_DoubleClick(Object eventSender, EventArgs eventArgs)
		{

			if (grd_maint_items.CurrentRowIndex == 1)
			{
				if (grd_maint_items.CurrentColumnIndex == 0)
				{
					display_maintenance_items("id", 0);
				}
				else if (grd_maint_items.CurrentColumnIndex == 1)
				{ 
					display_maintenance_items("name", 0);
				}
				else if (grd_maint_items.CurrentColumnIndex == 2)
				{ 
					display_maintenance_items("count", 0);
				}
				else if (grd_maint_items.CurrentColumnIndex == 3)
				{ 
					display_maintenance_items("", 0);
				}
			}


		}


		private void grdCREG_Click(Object eventSender, EventArgs eventArgs)
		{

			grdCREG.CurrentColumnIndex = 0;
			txt_crm_id.Text = grdCREG[grdCREG.CurrentRowIndex, grdCREG.CurrentColumnIndex].FormattedValue.ToString();
			grdCREG.CurrentColumnIndex = 1;
			txt_crm_Make.Text = grdCREG[grdCREG.CurrentRowIndex, grdCREG.CurrentColumnIndex].FormattedValue.ToString();
			grdCREG.CurrentColumnIndex = 2;
			txt_crm_model.Text = grdCREG[grdCREG.CurrentRowIndex, grdCREG.CurrentColumnIndex].FormattedValue.ToString();
			grdCREG.CurrentColumnIndex = 3;
			string tmp = $"{grdCREG[grdCREG.CurrentRowIndex, grdCREG.CurrentColumnIndex].FormattedValue.ToString()}";
			if (tmp == "0," && Strings.Len(tmp) == 2)
			{
				tmp = "";
			}

			if ((tmp == "0" || tmp == ",") && Strings.Len(tmp) == 1)
			{
				tmp = "";
			}

			txt_crm_amod_list.Text = tmp;

			RecordStat = "Update";
			pnl_CREG.Visible = true;

			grdCREG.CurrentColumnIndex = 0;
			grdCREG.ColSel = 3;
			grdCREG.RowSel = grdCREG.CurrentRowIndex;

		}

		private void Move_Engine_Model_Grid_Data_To_Edit_Form(int lRow1)
		{

			Clear_Engine_Models_Fields();

			grdEngineModels.CurrentRowIndex = lRow1;

			txtEngineModel[iEMID].Text = Convert.ToString(grdEngineModels[lRow1, 0].Value);
			txtEngineModel[iEMNAME].Text = Convert.ToString(grdEngineModels[lRow1, 1].Value);
			txtEngineModel[iEMPREFIX].Text = Convert.ToString(grdEngineModels[lRow1, 2].Value);
			txtEngineModel[iEMCORE].Text = Convert.ToString(grdEngineModels[lRow1, 3].Value);
			txtEngineModel[iEMSUFFIX1].Text = Convert.ToString(grdEngineModels[lRow1, 4].Value);
			txtEngineModel[iEMSUFFIX2].Text = Convert.ToString(grdEngineModels[lRow1, 5].Value);

			if (Convert.ToString(grdEngineModels[lRow1, 6].Value) == "Yes")
			{
				chkEngineModel[iEMACTIVE].CheckState = CheckState.Checked;
			}
			else
			{
				chkEngineModel[iEMACTIVE].CheckState = CheckState.Unchecked;
			}

			if (Convert.ToString(grdEngineModels[lRow1, 7].Value) != "")
			{
				txtEngineModel[iEMTAKEOFFPOWER].Text = Convert.ToString(grdEngineModels[lRow1, 7].Value);
			}

			if (Convert.ToString(grdEngineModels[lRow1, 8].Value) != "")
			{
				txtEngineModel[iEMMAXCONPOWER].Text = Convert.ToString(grdEngineModels[lRow1, 8].Value);
			}

			if (Convert.ToString(grdEngineModels[lRow1, 9].Value) != "")
			{
				txtEngineModel[iEMMFRCOMPID].Text = Convert.ToString(grdEngineModels[lRow1, 9].Value);
			}

			txtEngineModel[iEMMFRABBREV].Text = Convert.ToString(grdEngineModels[lRow1, 10].Value);
			txtEngineModel[iEMMFRNAME].Text = Convert.ToString(grdEngineModels[lRow1, 11].Value);

			txtEngineModel[iEMTHRUSTLBS].Text = Convert.ToString(grdEngineModels[lRow1, 12].Value);
			txtEngineModel[iEMCOMTBOHRS].Text = Convert.ToString(grdEngineModels[lRow1, 13].Value);


			txtEngineModel[iEMCOMTBOHRS].Enabled = true;

			txtEngineModel[iEMCOMTBOHRS].Tag = txtEngineModel[iEMCOMTBOHRS].Text;


			txtEngineModel[iEMSHAFTHP].Text = Convert.ToString(grdEngineModels[lRow1, 14].Value);
			txtEngineModel[iEMHSI].Text = Convert.ToString(grdEngineModels[lRow1, 15].Value);

			if (Convert.ToString(grdEngineModels[lRow1, 16].Value) == "Yes")
			{
				chkEngineModel[iEMONCONDITIONTBO].CheckState = CheckState.Checked;
			}
			else
			{
				chkEngineModel[iEMONCONDITIONTBO].CheckState = CheckState.Unchecked;
			}

			txtEngineModel[iEMMAKEMODEL].Text = Convert.ToString(grdEngineModels[lRow1, 17].Value);

			Highlight_Grid_Row(grdEngineModels);

		} // Move_Engine_Model_Grid_Data_To_Edit_Form

		private void Move_Engine_Model_Edit_Form_Data_To_Grid_Row(int lRow1)
		{

			grdEngineModels.CurrentRowIndex = lRow1;

			grdEngineModels[lRow1, 1].Value = txtEngineModel[iEMNAME].Text;
			grdEngineModels[lRow1, 2].Value = txtEngineModel[iEMPREFIX].Text;
			grdEngineModels[lRow1, 3].Value = txtEngineModel[iEMCORE].Text;
			grdEngineModels[lRow1, 4].Value = txtEngineModel[iEMSUFFIX1].Text;
			grdEngineModels[lRow1, 5].Value = txtEngineModel[iEMSUFFIX2].Text;

			if (chkEngineModel[iEMACTIVE].CheckState == CheckState.Checked)
			{
				grdEngineModels[lRow1, 6].Value = "Yes";
			}
			else
			{
				grdEngineModels[lRow1, 6].Value = "No";
			}

			grdEngineModels[lRow1, 7].Value = txtEngineModel[iEMTAKEOFFPOWER].Text;
			grdEngineModels[lRow1, 8].Value = txtEngineModel[iEMMAXCONPOWER].Text;
			grdEngineModels[lRow1, 9].Value = txtEngineModel[iEMMFRCOMPID].Text;
			grdEngineModels[lRow1, 10].Value = txtEngineModel[iEMMFRABBREV].Text;
			grdEngineModels[lRow1, 11].Value = txtEngineModel[iEMMFRNAME].Text;

			grdEngineModels[lRow1, 12].Value = txtEngineModel[iEMTHRUSTLBS].Text;
			grdEngineModels[lRow1, 13].Value = txtEngineModel[iEMCOMTBOHRS].Text;
			grdEngineModels[lRow1, 14].Value = txtEngineModel[iEMSHAFTHP].Text;
			grdEngineModels[lRow1, 15].Value = txtEngineModel[iEMHSI].Text;

			if (chkEngineModel[iEMONCONDITIONTBO].CheckState == CheckState.Checked)
			{
				grdEngineModels[lRow1, 16].Value = "Yes";
			}
			else
			{
				grdEngineModels[lRow1, 16].Value = "No";
			}

			Highlight_Grid_Row(grdEngineModels);

		} // Move_Engine_Model_Edit_Form_Data_To_Grid_Row

		private void grdEngineModels_Click(Object eventSender, EventArgs eventArgs)
		{

			int lCol1 = 0;

			int lRow1 = grdEngineModels.CurrentRowIndex;

			Move_Engine_Model_Grid_Data_To_Edit_Form(lRow1);

			cmdEngineModelsAdd.Enabled = true;
			cmdEngineModelsDelete.Enabled = true;

		} // grdEngineModels_Click

		private void lblExportToExcel_Click(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.lblExportToExcel, eventSender);

			string strFileName = "";

			if (lblExportToExcel[Index].Enabled)
			{

				lblExportToExcel[Index].Enabled = false;


				switch(Index)
				{
					case iExportEngineModels : 
						 
						frmEngineModels.Enabled = false; 
						cmdEngineModelsRefresh.Enabled = false; 
						grdEngineModels.Enabled = false; 
						 
						strFileName = $"{Path.GetDirectoryName(Application.ExecutablePath)}\\ExcelFiles\\Engine_Model_Table_{StringsHelper.Format(DateTime.Now, "yyyymmdd_hhMMss")}.xls"; 
						if (File.Exists(strFileName))
						{

							if (MessageBox.Show("File Already Exists.  Overwrite?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
							{
								//UPGRADE_WARNING: (2081) DeleteFile has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
								File.Delete(strFileName);
							}
							else
							{
								return;
							}
						}  // If gfso.FileExists(strFileName) = True Then 
						 
						modExcel.ExportMSHFlexGrid(grdEngineModels, lblLoading); 
						 
						frmEngineModels.Enabled = true; 
						cmdEngineModelsRefresh.Enabled = true; 
						grdEngineModels.Enabled = true; 
						 
						break;
					case iExportEMP : 
						 
						Label24[45].Text = "Status"; 
						FG_Engine_Maintenance.Enabled = false; 
						pnl_EMP_AddUpdate.Visible = false; 
						cmd_Add_EMP.Enabled = false; 
						 
						strFileName = $"{Path.GetDirectoryName(Application.ExecutablePath)}\\ExcelFiles\\Engin_Maintenance_Program_EMP_{StringsHelper.Format(DateTime.Now, "yyyymmdd_hhMMss")}.xls"; 
						if (File.Exists(strFileName))
						{

							if (MessageBox.Show("File Already Exists.  Overwrite?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
							{
								//UPGRADE_WARNING: (2081) DeleteFile has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
								File.Delete(strFileName);
							}
							else
							{
								return;
							}
						}  // If gfso.FileExists(strFileName) = True Then 
						 
						modExcel.ExportMSHFlexGrid(FG_Engine_Maintenance, Label24[45]); 
						 
						cmd_Add_EMP.Enabled = true; 
						FG_Engine_Maintenance.Enabled = true; 
						 
						break;
				} // Case Index

				lblExportToExcel[Index].Enabled = true;

			} // If lblExportEngineModelToExcel.Enabled = True Then

		} // lblExportEngineModelToExcel_Click


		private void lblGlobal_Click(Object eventSender, EventArgs eventArgs) => txtGlobal.Text = "";


		private void lblIATAIndex_Click(Object eventSender, EventArgs eventArgs) => cbo_iata_index.SelectedIndex = 0;


		private void lblICAOIndex_Click(Object eventSender, EventArgs eventArgs) => cbo_icao_index.SelectedIndex = 0;


		private void lblFAAIdIndex_Click(Object eventSender, EventArgs eventArgs) => cbo_faaid_index.SelectedIndex = 0;


		private void lblNameIndex_Click(Object eventSender, EventArgs eventArgs) => cbo_Airport_Index.SelectedIndex = 0;


		private void lbl_rule_note_DoubleClick(Object eventSender, EventArgs eventArgs)
		{
			if (($"{txt_kfeat_query.Text}").Trim() != "")
			{
				frame_automodels.Visible = true;
				FG_KeyFeature.Visible = false;
				Fill_Key_Feature_Auto_List();
			}
		}

		private void lblAirport_Click(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.lblAirport, eventSender);

			string strLatitude = "";
			string strLongitude = "";
			string strAPortName = "";
			string strAPortCity = "";
			string strAPortCountry = "";
			string strCoord = "";
			int iPos1 = 0;

			string strURL = "";
			string strURLQuery = "";

			int lRow = grd_Airport.CurrentRowIndex;
			int lAPortId = grd_Airport.get_RowData(lRow);

			string strIATA = ($"{txtAirport[iIATA_INDEX].Text} ").Trim();
			string strICAO = ($"{txtAirport[iICAO_INDEX].Text} ").Trim();
			string strFAAID = ($"{txtAirport[iFAAID_INDEX].Text} ").Trim();


			switch(Index)
			{
				case 0 :  // Airport Name - Google.com /Maps 
					 
					lRow = grd_Airport.CurrentRowIndex; 
					lRow++; 
					if (lRow >= grd_Airport.RowsCount)
					{
						lRow = grd_Airport.CurrentRowIndex;
					}
					else
					{
						grd_Airport.CurrentRowIndex = lRow;
						Airport_Select();
						grd_Airport.FirstDisplayedScrollingRowIndex = lRow;
						grd_Airport.CurrentColumnIndex = 0;
						grd_Airport.ColSel = grd_Airport.ColumnsCount - 1;
						Index = 16;
					} 
					 
					break;
				case 4 :  // Full - Update Flight Data With New Lat/Long 
					 
					Update_FAA_Flight_Data(lAPortId, strIATA, strICAO, strFAAID, strIATA, strICAO, strFAAID); 
					 
					break;
				case 9 :  // FAA Airport Id Lookup 
					 
					if (strIATA != "" || strICAO != "" || strFAAID != "")
					{


						strURL = "https://nfdc.faa.gov/nfdcApps/services/ajv5/airportDisplay.jsp?airportId=";

						if (strFAAID != "")
						{
							strURL = $"{strURL}{strFAAID}";
						}
						else if (strIATA != "")
						{ 
							strURL = $"{strURL}{strIATA}";
						}
						else if (strICAO != "")
						{ 
							strURL = $"{strURL}{strICAO}";
						}

						modAdminCommon.OpenURLInBrowser(strURL);

					}  // If strIATA <> "" Or strICAO <> "" Or strFAAId <> "" Then 
					 
					break;
				case 13 :  // Airport IQ Lookup 
					 
					if (strIATA != "" || strICAO != "" || strFAAID != "")
					{

						strURL = "http://www.gcr1.com/5010WEB/airport.cfm?Site=";
						if (strFAAID != "")
						{
							strURL = $"{strURL}{strFAAID}";
						}
						else if (strIATA != "")
						{ 
							strURL = $"{strURL}{strIATA}";
						}
						else if (strICAO != "")
						{ 
							strURL = $"{strURL}{strICAO}";
						}

						modAdminCommon.OpenURLInBrowser(strURL);

					}  // If strIATA <> "" Or strICAO <> "" Or strFAAId <> "" Then 
					 
					break;
				case 16 :  // Google Maps 
					 
					strLatitude = ""; 
					strLongitude = ""; 
					 
					Format_Latitude_Longitude_Values_Decimal_Or_Dir_Degree_Minute_Second(); 
					 
					if ((txtAirport[iLAT_INDEX].Text != "" && txtAirport[iLONG_INDEX].Text != "") && (txtAirport[iLAT_INDEX].Text != "00 00.00" && txtAirport[iLONG_INDEX].Text != "00 00.00"))
					{
						strLatitude = txtAirport[iLAT_INDEX].Text; // 16 - Latitude Decimal
						strLongitude = txtAirport[iLONG_INDEX].Text; // 17 - Longitude Decimal
					}
					else if ((txtAirport[4].Text != "" && txtAirport[9].Text != ""))
					{ 
						strLatitude = txtAirport[4].Text; //  4 - Latitude Full
						strLongitude = txtAirport[9].Text; //  9 - Longitude Full
					} 
					 
					if (strLatitude != "" && strLongitude != "")
					{
						strURL = "http://maps.google.com/maps";
						strURLQuery = $"?q={StringsHelper.Replace(strLatitude, " ", "+", 1, -1, CompareMethod.Binary)},{StringsHelper.Replace(strLongitude, " ", "+", 1, -1, CompareMethod.Binary)}";
					}
					else
					{
						strAPortName = ($"{txtAirport[iAPORTNAME_INDEX].Text} ").Trim();
						strAPortCity = ($"{txtAirport[iCITY_INDEX].Text} ").Trim();
						strAPortCountry = ($"{cbo_aport_country.Text} ").Trim();
						strURL = "http://maps.google.com/maps";
						strURLQuery = $"?q={"\""}{strAPortName}{"\""}+{"\""}{strAPortCity}{"\""}+{"\""}{strAPortCountry}{"\""}+{strIATA}";
					} 
					 
					// Google Maps 
					strURLQuery = $"{strURLQuery}&output=classic"; 
					modAdminCommon.OpenURLInBrowser($"{strURL}{strURLQuery}"); 
					 
					break;
				case 17 :  // AirNav.Com 
					 
					if (strIATA != "" || strICAO != "" || strFAAID != "")
					{

						// AirNav.Com
						strURL = "http://www.airnav.com/airport/";
						if (strIATA != "")
						{
							strURL = $"{strURL}{strIATA}";
						}
						else if (strICAO != "")
						{ 
							strURL = $"{strURL}{strICAO}";
						}
						else if (strFAAID != "")
						{ 
							strURL = $"{strURL}{strFAAID}";
						}

						modAdminCommon.OpenURLInBrowser(strURL);

					}  // If strIATA <> "" Or strICAO <> "" Or strFAAId <> "" Then 

					 
					break;
				case 19 : case 20 :  // Lat/Decimal and Long/Decimal 
					 
					txtAirport[iAPORTNAME_INDEX].Focus(); 
					 
					strCoord = InputBoxHelper.InputBox("Enter Coordinates In Decmial", "Coordinates"); 
					if (strCoord != "")
					{

						strCoord = ($"{strCoord} ").Trim();
						strCoord = StringsHelper.Replace(strCoord, ",", "|", 1, -1, CompareMethod.Binary);
						strCoord = StringsHelper.Replace(strCoord, "\\", "|", 1, -1, CompareMethod.Binary);
						strCoord = StringsHelper.Replace(strCoord, "/", "|", 1, -1, CompareMethod.Binary);

						iPos1 = (strCoord.IndexOf('|') + 1);

						if (iPos1 > 0)
						{

							strLatitude = ($"{strCoord.Substring(0, Math.Min(iPos1 - 1, strCoord.Length))} ").Trim();
							strLongitude = ($"{strCoord.Substring(Math.Min(iPos1, strCoord.Length))} ").Trim();

							txtAirport[iLAT_INDEX].Text = StringsHelper.Format(strLatitude, "#0.00000000");
							txtAirport[iLONG_INDEX].Text = StringsHelper.Format(strLongitude, "#0.00000000");

							Format_Latitude_Longitude_Values_Decimal_Or_Dir_Degree_Minute_Second();

						} // If iPos1 > 0 Then

					}  // If strCoord <> "" Then 
					 
					break;
				case 21 :  // Acukwik.Com 
					 
					if (strIATA != "" || strICAO != "" || strFAAID != "")
					{

						strURL = "http://www.acukwik.com/Airports.aspx?search=";

						if (strIATA != "")
						{
							strURL = $"{strURL}{strIATA}";
						}
						else if (strFAAID != "")
						{ 
							strURL = $"{strURL}{strFAAID}";
						}
						else if (strICAO != "")
						{ 
							strURL = $"{strURL}{strICAO}";
						}

						modAdminCommon.OpenURLInBrowser(strURL);

					}  // If strIATA <> "" Or strICAO <> "" And strFAAId <> "" Then 
					 
					break;
				case 22 :  // Airport Nav Finder 
					 
					if (strICAO != "")
					{

						strURL = $"http://airportnavfinder.com/airport/{strICAO}/";

						modAdminCommon.OpenURLInBrowser(strURL);

					}
					else
					{
						MessageBox.Show("Airport Nav Finder Requires ICAO Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					}  // If strICAO <> "" Then 

					 
					break;
				case 23 :  // Great Circle Mapper 
					 
					if (strIATA != "" || strFAAID != "" || strICAO != "")
					{

						strURL = "http://www.gcmap.com/search?Q=";

						if (strIATA != "")
						{
							strURL = $"{strURL}{strIATA}";
						}
						else if (strFAAID != "")
						{ 
							strURL = $"{strURL}{strFAAID}";
						}
						else if (strICAO != "")
						{ 
							strURL = $"{strURL}{strICAO}";
						}

						strURL = $"{strURL}&EC=A";

						modAdminCommon.OpenURLInBrowser(strURL);

					}
					else
					{
						MessageBox.Show("Great Circle Mapper Requires IATA, FAAID Or ICAO Code", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					}  // If strIATA <> "" Or strFAAID <> "" Or strICAO <> "" Then 

					 
					break;
				case 24 :  // Clear Lat/Long 
					 
					for (int iCnt1 = 4; iCnt1 <= 8; iCnt1++)
					{
						txtAirport[iCnt1].Text = "";
					} 
					txtAirport[iLAT_INDEX].Text = ""; 
					 
					for (int iCnt1 = 9; iCnt1 <= 13; iCnt1++)
					{
						txtAirport[iCnt1].Text = "";
					} 
					txtAirport[iLONG_INDEX].Text = ""; 
					 
					break;
			} // Case Index

		} // lblAirport_Click

		private void Format_GPS_Long_Lat_To_Deciaml()
		{

			string strLatitude = "";
			string strLongitude = "";
			int iPos1 = 0;
			double dLatitudeDecimal = 0;
			double dLongitudeDecimal = 0;
			string[] aCoord = null;

			txtAirport[iAPORTNAME_INDEX].Focus();
			string strCoord = InputBoxHelper.InputBox("Enter Coordinates In GPS", "Coordinates");

			if (strCoord != "")
			{

				strCoord = ($"{strCoord} ").Trim();
				strCoord = StringsHelper.Replace(strCoord, " ", "|", 1, -1, CompareMethod.Binary);
				strCoord = StringsHelper.Replace(strCoord, ",", "|", 1, -1, CompareMethod.Binary);
				strCoord = StringsHelper.Replace(strCoord, "\\", "|", 1, -1, CompareMethod.Binary);
				strCoord = StringsHelper.Replace(strCoord, "/", "|", 1, -1, CompareMethod.Binary);
				strCoord = StringsHelper.Replace(strCoord, "-", "|", 1, -1, CompareMethod.Binary);

				iPos1 = (strCoord.IndexOf('|') + 1);

				if (iPos1 > 0)
				{

					aCoord = strCoord.Split('|');

					strLatitude = $"{aCoord[0]} {aCoord[1]}";
					strLongitude = $"{aCoord[2]} {aCoord[3]}";

					dLatitudeDecimal = modAdminCommon.Convert_GPS_To_Decimal(strLatitude);
					dLongitudeDecimal = modAdminCommon.Convert_GPS_To_Decimal(strLongitude);

					txtAirport[iLAT_INDEX].Text = StringsHelper.Format(dLatitudeDecimal, "#0.00000000");
					txtAirport[iLONG_INDEX].Text = StringsHelper.Format(dLongitudeDecimal, "#0.00000000");

					Format_Latitude_Longitude_Values_Decimal_Or_Dir_Degree_Minute_Second();

				} // If iPos1 > 0 Then

			} // If strCoord <> "" Then

		} // Format_GPS_Long_Lat_To_Deciaml

		private void lblLatitudeGPS_Click(Object eventSender, EventArgs eventArgs) => Format_GPS_Long_Lat_To_Deciaml();


		//UPGRADE_NOTE: (7001) The following declaration (lblLongitudeGPS_Click) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void lblLongitudeGPS_Click() => Format_GPS_Long_Lat_To_Deciaml();//
		//

		public void mnuFileClose_Click(Object eventSender, EventArgs eventArgs) => 

			//  frm_Administration.Show
			this.Close();


		public void mnuFileLogout_Click(Object eventSender, EventArgs eventArgs) => Environment.Exit(0);


		private void tab_Lookup_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{
			//aey 4/20/2004
			int NewTab = 0; //Current tab
			string Query = ""; //Current query sql
			ADORecordSetHelper RS_Table = new ADORecordSetHelper(); //Current recordset

			int nRow = 0; //Current row counter
            DataGridViewFlex Grd = null;

			try
			{

				this.Cursor = Cursors.WaitCursor;
				pnlAdmin.Visible = false;

				NewTab = SSTabHelper.GetSelectedIndex(tab_Lookup); //currently selected tab, zero based

				switch(tab_LookupPreviousTab)
				{
					case 0 :  //Key Features 
						modAdminCommon.Table_Action_Log("Key_Feature"); 
						break;
					case 1 :  //Aircreft status 
						modAdminCommon.Table_Action_Log("Aircraft_Status"); 
						break;
					case 2 :  //Aircraft asking 
						modAdminCommon.Table_Action_Log("Aircraft_Asking"); 
						break;
					case 3 :  //Avionics 
						modAdminCommon.Table_Action_Log("Avionics"); 
						break;
					case 4 :  //Aircraft Class 
						modAdminCommon.Table_Action_Log("Aircraft_Class"); 
						break;
					case 5 :  //Aircraft Type 
						modAdminCommon.Table_Action_Log("Aircraft_Type"); 
						break;
					case 6 :  //Engine Maintenance Program 
						modAdminCommon.Table_Action_Log("Engine_Maintenance_Program"); 
						break;
					case 7 :  //Interior Configuration 
						modAdminCommon.Table_Action_Log("Interior_Configuration"); 
						break;
					case 8 :  //Aircraft Contact Type 
						modAdminCommon.Table_Action_Log("Aircraft_Contact_Type"); 
						break;
					case 9 :  //Auxliary Power Unit 
						modAdminCommon.Table_Action_Log("Auxilliary_Power_Unit"); 
						break;
					case 10 :  //Operating Certification 
						modAdminCommon.Table_Action_Log("Certification"); 
						break;
					case 11 :  //Specification 
						modAdminCommon.Table_Action_Log("Specification"); 
						break;
					case 12 :  //Aircraft Airport 
						 
						break;
					case 13 :  //Certified 
						modAdminCommon.Table_Action_Log("certified"); 
						break;
					case 14 :  //airlines 
						// Table_Action_Log ("airlines") 
						break;
					case 15 :  //can reg 
						// Table_Action_Log ("Canadain_Registry_Models") 
						break;
					case 16 : 
						// ABI Hide Aircraft 
						break;
					case 17 : case 18 : case 19 : 
						// Fuel Price 
						break;
					case 20 : 
						// Engine Model 
						if (bEngineModelChanged)
						{
							modAdminCommon.Table_Action_Log("Engine_Models");
						} 
						 
						break;
				}

				Application.DoEvents();

				switch(NewTab)
				{
					case 0 :  //key features 
						pnl_kfeat_test.Visible = false; 
						pnlAdmin.Visible = false; 
						 
						if (modAdminCommon.gbl_User_ID.ToUpper() == "MVIT" || modAdminCommon.gbl_User_ID.ToUpper() == "DCR")
						{
							txt_kfeat_query.Enabled = true;
						} 
						 
						get_keyfeat(); 
						Fill_cbo_feat_area(""); 
						 
						break;
					case 1 :  //aircraft Status 
						// lst_Name_Aircraft_Status.Clear 
						pnl_Update_Aircraft_Status.Visible = false; 
						Grd = FG_Aircraft_Status; 
						//UPGRADE_TODO: (1067) Member Clear is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Clear(); 
						//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Row = 0; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 0; 
						Grd.Text = "Name"; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 1; 
						Grd.Text = "Description"; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[0] = 1500; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[1] = 2000; 
						nRow = 1; 
						//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Row = nRow; 
						 
						Query = "SELECT * from Aircraft_Status ORDER BY astat_name "; 
						RS_Table.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic); 
						if (!(RS_Table.BOF && RS_Table.EOF))
						{
							RS_Table.MoveFirst();

							while(!RS_Table.EOF)
							{
								//lst_Name_Aircraft_Status.AddItem (Trim(snp_aircraft_status!astat_name))
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 0;
								Grd.Text = ($"{Convert.ToString(RS_Table["astat_name"])}").Trim();
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 1;
								Grd.Text = ($"{Convert.ToString(RS_Table["astat_description"])}").Trim();

								nRow++;
								//UPGRADE_TODO: (1067) Member Rows is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.RowCount = nRow + 1;//gap-note Grd.Rows was changed to GrdRow.RowCount
								//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Row = nRow;
								RS_Table.MoveNext();
							};
						} 
						RS_Table.Close();
                        //UPGRADE_TODO: (1067) Member Rows is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
                        Grd.RowCount = nRow - 1;//gap-note Grd.Rows was changed to GrdRow.RowCount
                        Grd.Refresh(); 
						 
						break;
					case 2 :  //aircraft asking 
						pnl_NameDesc_Asking.Visible = false; 
						Grd = FG_AirCraft_Asking; 
						//UPGRADE_TODO: (1067) Member Clear is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Clear(); 
						//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Row = 0; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 0; 
						Grd.Text = "Name"; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 1; 
						Grd.Text = "Description"; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[0] = 1500; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[1] = 2000; 
						nRow = 1; 
						//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Row = nRow; 
						 
						Query = "SELECT * from Aircraft_Asking ORDER BY aask_name "; 
						RS_Table.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic); 
						if (!(RS_Table.BOF && RS_Table.EOF))
						{
							RS_Table.MoveFirst();

							while(!RS_Table.EOF)
							{
								//lst_Name_Asking.AddItem (Trim(snp_Asking!aask_name))
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 0;
								Grd.Text = ($"{Convert.ToString(RS_Table["aask_name"])}").Trim();
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 1;
								Grd.Text = ($"{Convert.ToString(RS_Table["aask_description"])}").Trim();

								nRow++;
								//UPGRADE_TODO: (1067) Member Rows is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
							    Grd.RowCount = nRow + 1;//gap-note Grd.Rows was changed to GrdRow.RowCount
								//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Row = nRow;

								RS_Table.MoveNext();
							};
						} 
						RS_Table.Close();
                        //UPGRADE_TODO: (1067) Member Rows is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
                        Grd.RowCount = nRow + 1;//gap-note Grd.Rows was changed to GrdRow.RowCount
                        Grd.Refresh(); 
						 
						break;
					case 3 :  //Avionics 
						pnl_avionics_Update_Change.Visible = false; 
						Grd = FG_Avionics; 
						//UPGRADE_TODO: (1067) Member Clear is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Clear(); 
						//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Row = 0; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 0; 
						Grd.Text = "Name"; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 1; 
						Grd.Text = "Notes"; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[0] = 2000; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[1] = 3000; 
						nRow = 1; 
						//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Row = nRow; 
						 
						Query = "SELECT * from Avionics "; 
						Query = $"{Query}ORDER BY avion_name "; 
						RS_Table.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic); 
						if (!(RS_Table.BOF && RS_Table.EOF))
						{
							RS_Table.MoveFirst();

							while(!RS_Table.EOF)
							{
								//lst_Avionics.AddItem (Trim(snp_Avionics!avion_name))
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 0;
								Grd.Text = ($"{Convert.ToString(RS_Table["avion_name"])}").Trim();
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 1;
								Grd.Text = ($"{Convert.ToString(RS_Table["avion_notes"])}").Trim();
								nRow++;
								//UPGRADE_TODO: (1067) Member Rows is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.RowCount = nRow + 1;//gap-note Grd.Rows was changed to GrdRow.RowCount
								//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Row = nRow;
								RS_Table.MoveNext();
							};
						} 
						RS_Table.Close();
                        //UPGRADE_TODO: (1067) Member Rows is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
                        Grd.RowCount = nRow + 1;//gap-note Grd.Rows was changed to GrdRow.RowCount
                        Grd.Refresh(); 
						 
						break;
					case 4 :  //Aircraft Class 
						pnl_Aircraft_Class_AddUpdate.Visible = false; 
						Grd = FG_Aircraft_Class; 
						//UPGRADE_TODO: (1067) Member Clear is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Clear(); 
						//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Row = 0; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 0; 
						Grd.Text = "Code"; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 1; 
						Grd.Text = "Name"; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[0] = 1000; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[1] = 2000; 
						nRow = 1; 
						//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Row = nRow; 
						 
						Query = "SELECT * from Aircraft_Class ORDER BY aclass_code "; 
						RS_Table.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic); 
						if (!(RS_Table.BOF && RS_Table.EOF))
						{
							RS_Table.MoveFirst();

							while(!RS_Table.EOF)
							{
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 0;
								Grd.Text = ($"{Convert.ToString(RS_Table["aclass_code"])}").Trim();
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 1;
								Grd.Text = ($"{Convert.ToString(RS_Table["aclass_name"])}").Trim();
								nRow++;
								//UPGRADE_TODO: (1067) Member Rows is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.RowCount = nRow + 1;//gap-note Grd.Rows was changed to GrdRow.RowCount
								//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Row = nRow;
								RS_Table.MoveNext();
							};
						} 
						RS_Table.Close();
                        //UPGRADE_TODO: (1067) Member Rows is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
                        Grd.RowCount = nRow + 1;//gap-note Grd.Rows was changed to GrdRow.RowCount
                        Grd.Refresh(); 
						 
						break;
					case 5 :  //Aircraft Type 
						pnl_Aircraft_Type_AddUpdate.Visible = false; 
						Grd = FG_Aircraft_Type; 
						//UPGRADE_TODO: (1067) Member Clear is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Clear(); 
						//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Row = 0; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 0; 
						Grd.Text = "Code"; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 1; 
						Grd.Text = "Name"; 
						 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[0] = 1000; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[1] = 3000; 
						nRow = 1; 
						//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Row = nRow; 
						 
						Query = "SELECT * from Aircraft_Type "; 
						Query = $"{Query} ORDER BY atype_code "; 
						RS_Table.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic); 
						if (!(RS_Table.BOF && RS_Table.EOF))
						{
							RS_Table.MoveFirst();

							while(!RS_Table.EOF)
							{
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 0;
								Grd.Text = ($"{Convert.ToString(RS_Table["atype_code"])}").Trim();
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 1;
								Grd.Text = ($"{Convert.ToString(RS_Table["atype_name"])}").Trim();

								nRow++;
								//UPGRADE_TODO: (1067) Member Rows is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.RowCount = nRow + 1;//gap-note Grd.Rows was changed to GrdRow.RowCount
								//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Row = nRow;
								RS_Table.MoveNext();
							};
						} 
						RS_Table.Close(); 
						//UPGRADE_TODO: (1067) Member Rows is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.RowCount = nRow + 1;//gap-note Grd.Rows was changed to GrdRow.RowCount
						Grd.Refresh(); 
						 
						break;
					case 6 :  //Engine Maintenance Program 
						pnl_EMP_AddUpdate.Visible = false; 
						Grd = FG_Engine_Maintenance; 
						//UPGRADE_TODO: (1067) Member Clear is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Clear(); 
						//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Row = 0; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 0; 
						Grd.Text = "Code"; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 1; 
						Grd.Text = "Name"; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 2; 
						Grd.Text = "ID"; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 3; 
						Grd.Text = "Provider Name"; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 4; 
						Grd.Text = "Program Name"; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[0] = 500; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[1] = 3000; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[2] = 500; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[3] = 1500; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[4] = 1500; 
						 
						nRow = 1; 
						//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Row = nRow; 
						 
						Query = "SELECT * from Engine_Maintenance_Program  ORDER BY emp_code "; 
						RS_Table.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic); 
						if (!(RS_Table.BOF && RS_Table.EOF))
						{
							RS_Table.MoveFirst();

							while(!RS_Table.EOF)
							{
								//lst_EMP_List.AddItem (Trim(snp_EMP!emp_code) & " - " & Trim(Fix_Quote(snp_EMP!emp_name)))
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 0;
								Grd.Text = ($"{Convert.ToString(RS_Table["emp_code"])}").Trim();
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 1;
								Grd.Text = ($"{Convert.ToString(RS_Table["emp_name"])}").Trim();
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 2;
								Grd.Text = ($"{Convert.ToString(RS_Table["emp_id"])}").Trim();
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 3;
								Grd.Text = ($"{Convert.ToString(RS_Table["emp_provider_name"])}").Trim();
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 4;
								Grd.Text = ($"{Convert.ToString(RS_Table["emp_program_name"])}").Trim();
								nRow++;
								//UPGRADE_TODO: (1067) Member Rows is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.RowCount = nRow + 1;//gap-note Grd.Rows was changed to GrdRow.RowCount
								//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Row = nRow;
								RS_Table.MoveNext();
							};
						} 
						RS_Table.Close();
                        //UPGRADE_TODO: (1067) Member Rows is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
                        Grd.RowCount = nRow - 1;//gap-note Grd.Rows was changed to GrdRow.RowCount
                        Grd.Refresh(); 
						Label24[45].Visible = true; 
						 
						break;
					case 7 :  //Interior Configuration 
						pnl_IC_Update_Change.Visible = false; 
						Grd = FG_Interior_Configuration; 
						//UPGRADE_TODO: (1067) Member Clear is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Clear(); 
						//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Row = 0; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 0; 
						Grd.Text = "Name"; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[0] = 3000; 
						nRow = 1; 
						//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Row = nRow; 
						 
						Query = "SELECT * from Interior_Configuration ORDER BY intconfig_name "; 
						RS_Table.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic); 
						if (!(RS_Table.BOF && RS_Table.EOF))
						{
							RS_Table.MoveFirst();

							while(!RS_Table.EOF)
							{
								//lst_IC.AddItem (Trim(snp_IC!intconfig_name))
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 0;
								Grd.Text = ($"{Convert.ToString(RS_Table["intconfig_name"])}").Trim();
								nRow++;
								//UPGRADE_TODO: (1067) Member Rows is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.RowCount = nRow + 1;//gap-note Grd.Rows was changed to GrdRow.RowCount
								//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Row = nRow;
								RS_Table.MoveNext();
							};
						} 
						RS_Table.Close(); 
						//UPGRADE_TODO: (1067) Member Rows is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.RowCount = nRow - 1;//gap-note Grd.Rows was changed to GrdRow.RowCount
						Grd.Refresh(); 
						 
						break;
					case 8 :  //Aircraft Contact Type 
						Application.DoEvents(); 
						AircraftContactTypeFill(); 
						break;
					case 9 :  //Auxliary Power Unit 
						pnl_APU_Update_Change.Visible = false; 
						Grd = FG_Auxiliary_Power; 
						//UPGRADE_TODO: (1067) Member Clear is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Clear(); 
						//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Row = 0; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 0; 
						Grd.Text = "Make"; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 1; 
						Grd.Text = "Model"; 
						 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[0] = 2000; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[1] = 2000; 
						// Grd.CellAlignment = 1 
						//UPGRADE_TODO: (1067) Member ColAlignment is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColAlignment[1] = DataGridViewContentAlignment.TopLeft;

                        nRow = 1; 
						//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Row = nRow; 
						 
						Query = "SELECT * from Auxilliary_Power_Unit ORDER BY apu_make_name "; 
						RS_Table.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic); 
						if (!(RS_Table.BOF && RS_Table.EOF))
						{
							RS_Table.MoveFirst();

							while(!RS_Table.EOF)
							{
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 0;
								Grd.Text = ($"{Convert.ToString(RS_Table["apu_make_name"])}").Trim();
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 1;
								Grd.Text = ($"{Convert.ToString(RS_Table["apu_model_name"])}").Trim();

								nRow++;
								//UPGRADE_TODO: (1067) Member Rows is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.RowCount = nRow + 1;//gap-note Grd.Rows was changed to GrdRow.RowCount
								//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Row = nRow;
								RS_Table.MoveNext();
							};
						} 
						RS_Table.Close(); 
						//UPGRADE_TODO: (1067) Member Rows is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.RowCount = nRow - 1;//gap-note Grd.Rows was changed to GrdRow.RowCount
						Grd.Refresh(); 
						 
						break;
					case 10 :  //Operating Certification 
						 
						pnl_Certification_Update_Change.Visible = false; 
						 
						cbo_Ops_Cert_usaFlag.Items.Clear(); 
						cbo_Ops_Cert_usaFlag.AddItem("U"); 
						cbo_Ops_Cert_usaFlag.AddItem("I"); 
						cbo_Ops_Cert_usaFlag.AddItem("B"); 
						 
						Grd = FG_Operating_Certification; 
						//UPGRADE_TODO: (1067) Member Clear is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Clear(); 
						 
						//UPGRADE_TODO: (1067) Member Rows is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.RowCount = 2; //gap-note Grd.Rows was changed to GrdRow.RowCount. Check this during stabilization.
						//UPGRADE_TODO: (1067) Member Cols is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Cols = 4; 
						 
						//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Row = 0; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 0; 
						Grd.Text = "Name"; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 1; 
						Grd.Text = "Cert. Type"; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 2; 
						Grd.Text = "Description"; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 3; 
						Grd.Text = "Active"; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[0] = 1500; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[1] = 900; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[2] = 5200; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[3] = 900; 
						nRow = 1; 
						//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Row = nRow; 
						 
						Query = "SELECT * from Certification ORDER BY certification_name "; 
						RS_Table.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic); 
						if (!(RS_Table.BOF && RS_Table.EOF))
						{
							RS_Table.MoveFirst();

							while(!RS_Table.EOF)
							{
								//lst_Certification.AddItem (Trim(snp_Certification!certification_name))
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 0;
								Grd.Text = ($"{Convert.ToString(RS_Table["certification_name"])}").Trim();
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 1;
								Grd.Text = ($"{Convert.ToString(RS_Table["certification_usa_flag"])}").Trim();
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 2;
								Grd.Text = ($"{Convert.ToString(RS_Table["certification_description"])}").Trim();
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 3;
								Grd.Text = modAdminCommon.ReturnYesNo(($"{Convert.ToString(RS_Table["certification_active_flag"])} ").Trim());
								nRow++;
								//UPGRADE_TODO: (1067) Member Rows is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.RowCount = nRow + 1;//gap-note Grd.Rows was changed to GrdRow.RowCount
								//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Row = nRow;
								RS_Table.MoveNext();
							};
						} 
						RS_Table.Close();
                        //UPGRADE_TODO: (1067) Member Rows is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
                        Grd.RowCount = nRow - 1;//gap-note Grd.Rows was changed to GrdRow.RowCount
                        Grd.Refresh(); 
						 
						break;
					case 11 :  //Specification 
						pnl_Spec_Update_Change.Visible = false; 
						Grd = FG_Specification; 
						//UPGRADE_TODO: (1067) Member Clear is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Clear(); 
						//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Row = 0; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 0; 
						Grd.Text = "Name"; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 1; 
						Grd.Text = "Type"; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 2; 
						Grd.Text = "Notes"; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[0] = 3000; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[1] = 1000; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[2] = 1000; 
						//UPGRADE_TODO: (1067) Member ColAlignment is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColAlignment[0] = DataGridViewContentAlignment.TopLeft;
                        nRow = 1; 
						//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Row = nRow; 
						 
						Query = "SELECT * from Specification ORDER BY spec_name "; 
						RS_Table.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic); 
						if (!(RS_Table.BOF && RS_Table.EOF))
						{
							RS_Table.MoveFirst();

							while(!RS_Table.EOF)
							{
								//lst_spec.AddItem (Trim(snp_Spec!spec_name))
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 0;
								Grd.Text = ($"{Convert.ToString(RS_Table["spec_name"])}").Trim();
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 1;
								Grd.Text = ($"{Convert.ToString(RS_Table["spec_type"])}").Trim();
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 2;
								Grd.Text = ($"{Convert.ToString(RS_Table["spec_notes"])}").Trim();
								nRow++;
								//UPGRADE_TODO: (1067) Member Rows is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.RowCount = nRow + 1;//gap-note Grd.Rows was changed to GrdRow.RowCount
								//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Row = nRow;
								RS_Table.MoveNext();
							};
						} 
						RS_Table.Close();
                        //UPGRADE_TODO: (1067) Member Rows is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
                        Grd.RowCount = nRow - 1;//gap-note Grd.Rows was changed to GrdRow.RowCount
                        Grd.Refresh(); 
						 
						break;
					case 12 :  //Aircraft Airport 
						Fill_Airport_Index(); 
						Application.DoEvents(); 
						Airport_Fill_List(); 
						 
						break;
					case 13 :  //certified 
						pnl_Certified_Update_Change.Visible = false; 
						Grd = FGRD_Certifed; 
						//UPGRADE_TODO: (1067) Member Clear is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Clear(); 
						//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Row = 0; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 0; 
						Grd.Text = "Name"; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[0] = 3000; 
						// Grd.ColAlignment(0) = 1 
						nRow = 1; 
						//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Row = nRow; 
						 
						Query = "SELECT * from Certified ORDER BY cert_name "; 
						RS_Table.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic); 
						if (!(RS_Table.BOF && RS_Table.EOF))
						{
							RS_Table.MoveFirst();

							while(!RS_Table.EOF)
							{
								// lst_certified.AddItem (Trim(snp_Certified!cert_name))
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 0;
								Grd.Text = ($"{Convert.ToString(RS_Table["cert_name"])}").Trim();
								nRow++;
								//UPGRADE_TODO: (1067) Member Rows is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.RowCount = nRow + 1;//gap-note Grd.Rows was changed to GrdRow.RowCount
								//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Row = nRow;
								RS_Table.MoveNext();
							};
						} 
						RS_Table.Close();
                        //UPGRADE_TODO: (1067) Member Rows is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
                        Grd.RowCount = nRow - 1;//gap-note Grd.Rows was changed to GrdRow.RowCount
                        Grd.Refresh(); 
						 
						break;
					case 14 :  // Airline 
						 
						break;
					case 15 :  //Canadain_Registry_Models 
						pnl_CREG.Visible = false; 
						Grd = grdCREG; 
						//UPGRADE_TODO: (1067) Member Clear is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Clear(); 
						//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Row = 0; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 0; 
						Grd.Text = "crm_id"; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 1; 
						Grd.Text = "Make"; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 2; 
						Grd.Text = "Model"; 
						//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Col = 3; 
						Grd.Text = "Model List"; 
						 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[0] = 0; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[1] = 2000; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[2] = 2500; 
						//UPGRADE_TODO: (1067) Member ColWidth is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColWidth[3] = 1500; 
						 
						//UPGRADE_TODO: (1067) Member ColAlignment is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.ColAlignment[1] = DataGridViewContentAlignment.TopLeft;
                        //UPGRADE_TODO: (1067) Member ColAlignment is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
                        Grd.ColAlignment[2] = DataGridViewContentAlignment.TopLeft;
                        //UPGRADE_TODO: (1067) Member ColAlignment is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
                        Grd.ColAlignment[3] = DataGridViewContentAlignment.TopLeft;
                        nRow = 1; 
						//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.Row = nRow; 
						 
						Query = "SELECT * from Canadian_Registry_Models ORDER BY crm_make_name,crm_model_name "; 
						RS_Table.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic); 
						if (!(RS_Table.BOF && RS_Table.EOF))
						{
							RS_Table.MoveFirst();

							while(!RS_Table.EOF)
							{
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 0;
								Grd.Text = ($"{Convert.ToString(RS_Table["crm_id"])}").Trim();
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 1;
								Grd.Text = ($"{Convert.ToString(RS_Table["crm_make_name"])}").Trim();
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 2;
								Grd.Text = ($"{Convert.ToString(RS_Table["crm_model_name"])}").Trim();
								//UPGRADE_TODO: (1067) Member Col is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Col = 3;
								Grd.Text = ($"{Convert.ToString(RS_Table["crm_amod_list"])}").Trim();
								nRow++;
								//UPGRADE_TODO: (1067) Member Rows is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.RowCount = nRow + 1;//gap-note Grd.Rows was changed to GrdRow.RowCount
								//UPGRADE_TODO: (1067) Member Row is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								Grd.Row = nRow;
								RS_Table.MoveNext();
							};
						} 
						RS_Table.Close(); 
						//UPGRADE_TODO: (1067) Member Rows is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067 
						Grd.RowCount = nRow - 1;//gap-note Grd.Rows was changed to GrdRow.RowCount
						Grd.Refresh(); 
						 
						cbo_CREG.Items.Clear(); 
						cbo_CREG.AddItem("000 Non-Selected"); 
						Query = "SELECT amod_id,amod_make_name,amod_model_name from Aircraft_model "; 
						Query = $"{Query}ORDER BY amod_make_name,amod_model_name "; 
						RS_Table.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic); 
						if (!(RS_Table.BOF && RS_Table.EOF))
						{
							RS_Table.MoveFirst();

							while(!RS_Table.EOF)
							{
								cbo_CREG.AddItem($"{StringsHelper.Format(RS_Table["amod_id"], "000")} {Convert.ToString(RS_Table["amod_make_name"])} {Convert.ToString(RS_Table["amod_model_name"])}");

								RS_Table.MoveNext();
							};
						} 
						RS_Table.Close(); 
						cbo_CREG.SelectedIndex = 0; 
						Application.DoEvents(); 
						 
						break;
					case 16 : 

						 
						break;
					case 17 :  // Fuel Price 

						 
						Query = "SELECT LngID, evo_config_fuel_cost, evo_config_jeta_fuel_cost, evo_config_lowlead_fuel_cost, evo_config_commercial_fuel_cost "; 
						Query = $"{Query}FROM Evolution_Configuration WITH (NOLOCK) "; 
						if (modAdminCommon.gbl_Live_flag)
						{
							Query = $"{Query}WHERE (evo_config_category ='LIVE') ";
						}
						else
						{
							Query = $"{Query}WHERE (evo_config_category ='TEST') ";
						} 
						 
						RS_Table.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic); 
						 
						txtFuelCost[0].Text = "0"; 
						txtFuelCost[1].Text = "0"; 
						txtFuelCost[2].Text = "0"; 
						lbl_generic[9].Text = "Evo_Config_ID:"; 
						 
						if (!RS_Table.BOF && !RS_Table.EOF)
						{
							txtFuelCost[0].Text = StringsHelper.Format(RS_Table["evo_config_jeta_fuel_cost"], "#,##0.00");
							txtFuelCost[1].Text = StringsHelper.Format(RS_Table["evo_config_lowlead_fuel_cost"], "#,##0.00");
							txtFuelCost[2].Text = StringsHelper.Format(RS_Table["evo_config_commercial_fuel_cost"], "#,##0.00");
							lbl_generic[9].Text = Convert.ToString(RS_Table["LngID"]);
						} 
						RS_Table.Close(); 
						 
						break;
					case 18 :  //Aircraft Topics 
						// ADDED MSW - 11/23 
						Aircraft_Topic_List_By_Topic_Fill(""); 
						acTopicArea.Text = "The Topic Area Is Now Managed as Attributes"; 
						break;
					case 19 : 
						display_maintenance_items("", 0); 
						 
						break;
					case 20 :  // Engine_Models 
						bEngineModelChanged = false; 
						lblEMStatus.Text = ""; 
						cmdEngineModelsRefresh_Click(cmdEngineModelsRefresh, new EventArgs()); 
						 
						break;
				}

				RS_Table = null;
				Grd = null;

				//RememberListPosition = -1

				Is_Dirty = false;
				this.Cursor = CursorHelper.CursorDefault;
				Application.DoEvents();
			}
			catch
			{

				this.Cursor = CursorHelper.CursorDefault;
				Is_Dirty = false;
				modAdminCommon.Report_Error($"Aircraft Tab Error, Tab:{Conversion.Str(NewTab)}");
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1065
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");

				tab_LookupPreviousTab = tab_Lookup.SelectedIndex;
			}

		}

		private void tbr_ToolBar_ButtonClick(Object eventSender, EventArgs eventArgs)
		{
			ToolStripItem Button = (ToolStripItem) eventSender;


			try
			{


				switch(Button.Name)
				{
					case "Home" : 
						modAdminCommon.gbl_bHomeClicked = true; 
						frm_Admin_Menu.DefInstance.Show(); 
						this.Close(); 
						 
						break;
					case "Back" : 
						mnuFileClose_Click(mnuFileClose, new EventArgs()); 
						 
						break;
					case "Save" : 
						MessageBox.Show("This is nothing to Save", "Aircraft Lookup", MessageBoxButtons.OK, MessageBoxIcon.Information); 
						 
						break;
					case "Help" : 
						MessageBox.Show("Help is forthcoming", "Aircraft Lookup", MessageBoxButtons.OK, MessageBoxIcon.Information); 
						 
						break;
					default:
						//RESP = MsgBox("ToolBar Error", vbInformation, "Unrecognized Toolbar Reference") 
						break;
				}
			}
			catch
			{

				modAdminCommon.Report_Error("tbr_ToolBar_Error: ");
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
				return;
			}

		}

		private void ToolbarButtonsSetup()
		{
			// show/hide toolbar buttons


			ToolStrip tbr = tbr_ToolBar;

			tbr.Items[1].Visible = true;
			tbr.Items[3].Visible = false;
			tbr.Items[5].Visible = false;
			tbr.Items[7].Visible = false;

			tbr.Items[1].Enabled = true;
			tbr.Items[3].Enabled = false;
			//      .Buttons(6).Enabled = True
			//      .Buttons(8).Enabled = True

		}

		private void ToolbarSetup()
		{
			//put Names, Images, and tooltips on the toolbar buttons


			ToolStrip tbr = tbr_ToolBar;

			tbr.ImageList = mdi_AdminAssistant.DefInstance.imgNormal;

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


		private void txt_aask_description_Leave(Object eventSender, EventArgs eventArgs) => txt_aask_description.Text = Strings.StrConv(txt_aask_description.Text, VbStrConv.ProperCase, 0);



		private void txt_aask_name_Leave(Object eventSender, EventArgs eventArgs) => txt_aask_name.Text = txt_aask_name.Text.ToUpper();



		private void txt_aclass_code_Leave(Object eventSender, EventArgs eventArgs) => txt_aclass_code.Text = ($"{txt_aclass_code.Text}").ToUpper();



		//UPGRADE_NOTE: (7001) The following declaration (txt_aport_iata_code_KeyPress) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void txt_aport_iata_code_KeyPress(ref int KeyAscii) => 
			////KeyAscii = Asc(UCase(Chr(KeyAscii)))
			//KeyAscii = Strings.AscW(Strings.ChrW(KeyAscii).ToString().ToUpper());
		//

		//UPGRADE_NOTE: (7001) The following declaration (txt_aport_icao_code_KeyPress) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void txt_aport_icao_code_KeyPress(ref int KeyAscii) => KeyAscii = Strings.AscW(Strings.ChrW(KeyAscii).ToString().ToUpper());
		//

		private void Txt_atype_Code_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{
				//UPGRADE_ISSUE: (1058) Assignment not supported: KeyAscii to a non-positive constant More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-1058
				KeyAscii = Strings.AscW(Strings.ChrW(KeyAscii).ToString().ToUpper());
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

		private void txt_crm_amod_list_TextChanged(Object eventSender, EventArgs eventArgs)
		{
			string tmp = "";

			if (Strings.Len($"{txt_crm_amod_list.Text}") > 0)
			{
				tmp = txt_crm_amod_list.Text;
				if (tmp.Substring(Math.Min(0, tmp.Length), Math.Min(1, Math.Max(0, tmp.Length))) == ",")
				{
					tmp = StringsHelper.MidAssignment(tmp, 1, 1, " ");
					txt_crm_amod_list.Text = tmp.Trim();
				}
			}

		}

		private void Txt_emp_Code_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{
				//UPGRADE_ISSUE: (1058) Assignment not supported: KeyAscii to a non-positive constant More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-1058
				KeyAscii = Strings.AscW(Strings.ChrW(KeyAscii).ToString().ToUpper());
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

		private void txt_kfeat_code_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Convert.ToInt32(eventArgs.KeyChar);
			try
			{
				//UPGRADE_ISSUE: (1058) Assignment not supported: KeyAscii to a non-positive constant More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-1058
				KeyAscii = Strings.AscW(Strings.ChrW(KeyAscii).ToString().ToUpper());
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

		private void Aircraft_Contact_Type(string Action)
		{
			//aey 4/28/2004 convered to (1) flex grid (2) ADO

			try
			{


				string Query = "";
				DialogResult RESP = (DialogResult) 0;
				// Dim I As Integer
				string M = "";

				this.Cursor = Cursors.WaitCursor;


				switch(Action)
				{
					case "Clear" : 
						txt_actype_code.Text = ""; 
						txt_actype_Name.Text = ""; 
						txt_actype_abbrev.Text = ""; 
						txt_actype_use_flag.Text = ""; 
						 
						chk_actype_compref_flag.CheckState = CheckState.Unchecked;  //company to company ref 
						chk_actype_acref_flag.CheckState = CheckState.Unchecked;  //aircraft to company ref 
						chk_compref_internal_flag.CheckState = CheckState.Unchecked;  //internal 
						chk_actype_transref_flag.CheckState = CheckState.Unchecked;  //transactional ref 
						chk_actype_shareref_flag.CheckState = CheckState.Unchecked;  //fractional share 
						chk_compref_twoway_flag.CheckState = CheckState.Unchecked;  //two-way 
						txt_compref_name2.Text = ""; 
						 
						break;
					case "Display" : 
						//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' 
						// Display Aircraft Contact Type input fields from recordset 
						//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' 
						FGRD_AircraftContactType.CurrentColumnIndex = 0; 
						txt_actype_code.Text = ($"{FGRD_AircraftContactType[FGRD_AircraftContactType.CurrentRowIndex, FGRD_AircraftContactType.CurrentColumnIndex].FormattedValue.ToString()}").Trim();  //Trim(snp_aircraft_contact_type!actype_code & " ")   'code 
						FGRD_AircraftContactType.CurrentColumnIndex = 1; 
						txt_actype_Name.Text = ($"{FGRD_AircraftContactType[FGRD_AircraftContactType.CurrentRowIndex, FGRD_AircraftContactType.CurrentColumnIndex].FormattedValue.ToString()}").Trim();  //Trim(snp_aircraft_contact_type!actype_name & " ")   'name 
						FGRD_AircraftContactType.CurrentColumnIndex = 9; 
						txt_actype_abbrev.Text = ($"{FGRD_AircraftContactType[FGRD_AircraftContactType.CurrentRowIndex, FGRD_AircraftContactType.CurrentColumnIndex].FormattedValue.ToString()}").Trim();  //Trim(snp_aircraft_contact_type!actype_abbrev & " ")  'abbrev 
						FGRD_AircraftContactType.CurrentColumnIndex = 10; 
						txt_actype_use_flag.Text = ($"{FGRD_AircraftContactType[FGRD_AircraftContactType.CurrentRowIndex, FGRD_AircraftContactType.CurrentColumnIndex].FormattedValue.ToString()}").Trim();  //Trim(snp_aircraft_contact_type!actype_use_flag & " ")  'usage 
						FGRD_AircraftContactType.CurrentColumnIndex = 5; 
						if (($"{FGRD_AircraftContactType[FGRD_AircraftContactType.CurrentRowIndex, FGRD_AircraftContactType.CurrentColumnIndex].FormattedValue.ToString()}").Trim() == "Y")
						{
							chk_actype_compref_flag.CheckState = CheckState.Checked; //company to company ref
						}
						else
						{
							chk_actype_compref_flag.CheckState = CheckState.Unchecked;
						} 
						FGRD_AircraftContactType.CurrentColumnIndex = 8; 
						if (($"{FGRD_AircraftContactType[FGRD_AircraftContactType.CurrentRowIndex, FGRD_AircraftContactType.CurrentColumnIndex].FormattedValue.ToString()}").Trim() == "Y")
						{
							chk_compref_internal_flag.CheckState = CheckState.Checked; //internal
						}
						else
						{
							chk_compref_internal_flag.CheckState = CheckState.Unchecked;
						} 
						FGRD_AircraftContactType.CurrentColumnIndex = 3; 
						if (($"{FGRD_AircraftContactType[FGRD_AircraftContactType.CurrentRowIndex, FGRD_AircraftContactType.CurrentColumnIndex].FormattedValue.ToString()}").Trim() == "Y")
						{
							chk_compref_twoway_flag.CheckState = CheckState.Checked; //two-way
						}
						else
						{
							chk_compref_twoway_flag.CheckState = CheckState.Unchecked;
						} 
						FGRD_AircraftContactType.CurrentColumnIndex = 2; 
						txt_compref_name2.Text = ($"{FGRD_AircraftContactType[FGRD_AircraftContactType.CurrentRowIndex, FGRD_AircraftContactType.CurrentColumnIndex].FormattedValue.ToString()}").Trim();  //Trim("" & snp_aircraft_contact_type!actype_compref_name2) 
						FGRD_AircraftContactType.CurrentColumnIndex = 4; 
						if (($"{FGRD_AircraftContactType[FGRD_AircraftContactType.CurrentRowIndex, FGRD_AircraftContactType.CurrentColumnIndex].FormattedValue.ToString()}").Trim() == "Y")
						{
							chk_actype_acref_flag.CheckState = CheckState.Checked; //aircraft to company ref
						}
						else
						{
							chk_actype_acref_flag.CheckState = CheckState.Unchecked;
						} 
						FGRD_AircraftContactType.CurrentColumnIndex = 6; 
						if (($"{FGRD_AircraftContactType[FGRD_AircraftContactType.CurrentRowIndex, FGRD_AircraftContactType.CurrentColumnIndex].FormattedValue.ToString()}").Trim() == "Y")
						{
							chk_actype_transref_flag.CheckState = CheckState.Checked; //transactional ref
						}
						else
						{
							chk_actype_transref_flag.CheckState = CheckState.Unchecked;
						} 
						FGRD_AircraftContactType.CurrentColumnIndex = 7; 
						if (($"{FGRD_AircraftContactType[FGRD_AircraftContactType.CurrentRowIndex, FGRD_AircraftContactType.CurrentColumnIndex].FormattedValue.ToString()}").Trim() == "Y")
						{
							chk_actype_shareref_flag.CheckState = CheckState.Checked; //fractional share
						}
						else
						{
							chk_actype_shareref_flag.CheckState = CheckState.Unchecked;
						} 
						 
						break;
					case "Select" : 
						 
						Aircraft_Contact_Type("Clear"); 
						Aircraft_Contact_Type("Display"); 
						 
						break;
					case "Insert" : 
						 
						Query = "INSERT INTO Aircraft_Contact_Type (actype_code, actype_name, "; 
						Query = $"{Query}actype_abbrev, actype_use_flag , "; 
						Query = $"{Query}actype_compref_flag,  actype_acref_flag, actype_transref_flag, actype_shareref_flag, "; 
						 
						Query = $"{Query}actype_compref_internal_flag, actype_compref_twoway_flag, "; 
						Query = $"{Query}actype_compref_name2) values ("; 
						 
						Query = $"{Query}'{txt_actype_code.Text.Trim().ToUpper()}', "; 
						Query = $"{Query}'{modAdminCommon.Fix_Quote(txt_actype_Name).Trim()}', "; 
						Query = $"{Query}'{modAdminCommon.Fix_Quote(txt_actype_abbrev).Trim()}', "; 
						Query = $"{Query}'{modAdminCommon.Fix_Quote(txt_actype_use_flag).Trim()}'"; 
						FGRD_AircraftContactType.RowsCount++; 
						FGRD_AircraftContactType.CurrentRowIndex = FGRD_AircraftContactType.RowsCount - 1; 
						FGRD_AircraftContactType.CurrentColumnIndex = 0; 
						FGRD_AircraftContactType[FGRD_AircraftContactType.CurrentRowIndex, FGRD_AircraftContactType.CurrentColumnIndex].Value = ($"{txt_actype_code.Text}").Trim().ToUpper(); 
						FGRD_AircraftContactType.CurrentColumnIndex = 1; 
						FGRD_AircraftContactType[FGRD_AircraftContactType.CurrentRowIndex, FGRD_AircraftContactType.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote($"{txt_actype_Name.Text}").Trim(); 
						FGRD_AircraftContactType.CurrentColumnIndex = 9; 
						FGRD_AircraftContactType[FGRD_AircraftContactType.CurrentRowIndex, FGRD_AircraftContactType.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote($"{txt_actype_abbrev.Text}").Trim(); 
						FGRD_AircraftContactType.CurrentColumnIndex = 10; 
						FGRD_AircraftContactType[FGRD_AircraftContactType.CurrentRowIndex, FGRD_AircraftContactType.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote($"{txt_actype_use_flag.Text}").Trim(); 
						FGRD_AircraftContactType.CurrentColumnIndex = 2; 
						FGRD_AircraftContactType[FGRD_AircraftContactType.CurrentRowIndex, FGRD_AircraftContactType.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote($"{txt_compref_name2.Text}").Trim(); 
						 
						FGRD_AircraftContactType.CurrentColumnIndex = 5; 
						if (chk_actype_compref_flag.CheckState == CheckState.Checked)
						{
							Query = $"{Query}, ";
							Query = $"{Query}'Y', ";
							FGRD_AircraftContactType[FGRD_AircraftContactType.CurrentRowIndex, FGRD_AircraftContactType.CurrentColumnIndex].Value = "Y";
						}
						else
						{
							Query = $"{Query}, ";
							Query = $"{Query}'N', ";
							FGRD_AircraftContactType[FGRD_AircraftContactType.CurrentRowIndex, FGRD_AircraftContactType.CurrentColumnIndex].Value = "N";
						} 
						FGRD_AircraftContactType.CurrentColumnIndex = 4; 
						if (chk_actype_acref_flag.CheckState == CheckState.Checked)
						{
							Query = $"{Query}'Y', ";
							FGRD_AircraftContactType[FGRD_AircraftContactType.CurrentRowIndex, FGRD_AircraftContactType.CurrentColumnIndex].Value = "Y";
						}
						else
						{
							Query = $"{Query}'N', ";
							FGRD_AircraftContactType[FGRD_AircraftContactType.CurrentRowIndex, FGRD_AircraftContactType.CurrentColumnIndex].Value = "N";
						} 
						FGRD_AircraftContactType.CurrentColumnIndex = 6; 
						if (chk_actype_transref_flag.CheckState == CheckState.Checked)
						{
							Query = $"{Query}'Y', ";
							FGRD_AircraftContactType[FGRD_AircraftContactType.CurrentRowIndex, FGRD_AircraftContactType.CurrentColumnIndex].Value = "Y";
						}
						else
						{
							Query = $"{Query}'N', ";
							FGRD_AircraftContactType[FGRD_AircraftContactType.CurrentRowIndex, FGRD_AircraftContactType.CurrentColumnIndex].Value = "N";
						} 
						FGRD_AircraftContactType.CurrentColumnIndex = 7; 
						if (chk_actype_shareref_flag.CheckState == CheckState.Checked)
						{
							Query = $"{Query}'Y', ";
							FGRD_AircraftContactType[FGRD_AircraftContactType.CurrentRowIndex, FGRD_AircraftContactType.CurrentColumnIndex].Value = "Y";
						}
						else
						{
							Query = $"{Query}'N', ";
							FGRD_AircraftContactType[FGRD_AircraftContactType.CurrentRowIndex, FGRD_AircraftContactType.CurrentColumnIndex].Value = "N";
						} 
						FGRD_AircraftContactType.CurrentColumnIndex = 8; 
						if (chk_compref_internal_flag.CheckState == CheckState.Checked)
						{
							Query = $"{Query}'Y', ";
							FGRD_AircraftContactType[FGRD_AircraftContactType.CurrentRowIndex, FGRD_AircraftContactType.CurrentColumnIndex].Value = "Y";
						}
						else
						{
							Query = $"{Query}'N', ";
							FGRD_AircraftContactType[FGRD_AircraftContactType.CurrentRowIndex, FGRD_AircraftContactType.CurrentColumnIndex].Value = "N";
						} 
						FGRD_AircraftContactType.CurrentColumnIndex = 3; 
						if (chk_compref_twoway_flag.CheckState == CheckState.Checked)
						{
							Query = $"{Query}'Y', ";
							FGRD_AircraftContactType[FGRD_AircraftContactType.CurrentRowIndex, FGRD_AircraftContactType.CurrentColumnIndex].Value = "Y";
						}
						else
						{
							Query = $"{Query}'N', ";
							FGRD_AircraftContactType[FGRD_AircraftContactType.CurrentRowIndex, FGRD_AircraftContactType.CurrentColumnIndex].Value = "N";
						} 
						Query = $"{Query}'{modAdminCommon.Fix_Quote(txt_compref_name2).Trim()}'"; 
						 
						Query = $"{Query})"; 
						 
						//Call LOCAL_DB.Execute(QUERY, dbSQLPassThrough) 
						DbCommand TempCommand = null; 
						TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand(); 
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand); 
						TempCommand.CommandText = Query; 
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand); 
						TempCommand.ExecuteNonQuery(); 
						 
						FGRD_AircraftContactType.Refresh(); 
						MessageBox.Show("Insert Successfully Completed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly())); 
						Is_Dirty = true; 
						 
						break;
					case "Update" : 
						Query = $"UPDATE Aircraft_Contact_Type SET actype_code='{txt_actype_code.Text.Trim().ToUpper()}',"; 
						Query = $"{Query}actype_name='{modAdminCommon.Fix_Quote(txt_actype_Name).Trim()}',"; 
						Query = $"{Query}actype_abbrev='{modAdminCommon.Fix_Quote(txt_actype_abbrev).Trim()}',"; 
						Query = $"{Query}actype_use_flag='{modAdminCommon.Fix_Quote(txt_actype_use_flag).Trim()}',"; 
						FGRD_AircraftContactType.CurrentColumnIndex = 0; 
						FGRD_AircraftContactType[FGRD_AircraftContactType.CurrentRowIndex, FGRD_AircraftContactType.CurrentColumnIndex].Value = ($"{txt_actype_code.Text}").Trim().ToUpper(); 
						FGRD_AircraftContactType.CurrentColumnIndex = 1; 
						FGRD_AircraftContactType[FGRD_AircraftContactType.CurrentRowIndex, FGRD_AircraftContactType.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote($"{txt_actype_Name.Text}").Trim(); 
						FGRD_AircraftContactType.CurrentColumnIndex = 9; 
						FGRD_AircraftContactType[FGRD_AircraftContactType.CurrentRowIndex, FGRD_AircraftContactType.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote($"{txt_actype_abbrev.Text}").Trim(); 
						FGRD_AircraftContactType.CurrentColumnIndex = 10; 
						FGRD_AircraftContactType[FGRD_AircraftContactType.CurrentRowIndex, FGRD_AircraftContactType.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote($"{txt_actype_use_flag.Text}").Trim(); 
						FGRD_AircraftContactType.CurrentColumnIndex = 2; 
						FGRD_AircraftContactType[FGRD_AircraftContactType.CurrentRowIndex, FGRD_AircraftContactType.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote($"{txt_compref_name2.Text}").Trim(); 
						FGRD_AircraftContactType.CurrentColumnIndex = 5; 
						if (chk_actype_compref_flag.CheckState == CheckState.Checked)
						{
							Query = $"{Query}actype_compref_flag='Y',";
							FGRD_AircraftContactType[FGRD_AircraftContactType.CurrentRowIndex, FGRD_AircraftContactType.CurrentColumnIndex].Value = "Y";
						}
						else
						{
							Query = $"{Query}actype_compref_flag='N',";
							FGRD_AircraftContactType[FGRD_AircraftContactType.CurrentRowIndex, FGRD_AircraftContactType.CurrentColumnIndex].Value = "N";
						} 
						FGRD_AircraftContactType.CurrentColumnIndex = 4; 
						if (chk_actype_acref_flag.CheckState == CheckState.Checked)
						{
							Query = $"{Query}actype_acref_flag='Y',";
							FGRD_AircraftContactType[FGRD_AircraftContactType.CurrentRowIndex, FGRD_AircraftContactType.CurrentColumnIndex].Value = "Y";
						}
						else
						{
							Query = $"{Query}actype_acref_flag='N',";
							FGRD_AircraftContactType[FGRD_AircraftContactType.CurrentRowIndex, FGRD_AircraftContactType.CurrentColumnIndex].Value = "N";
						} 
						FGRD_AircraftContactType.CurrentColumnIndex = 6; 
						if (chk_actype_transref_flag.CheckState == CheckState.Checked)
						{
							Query = $"{Query}actype_transref_flag='Y',";
							FGRD_AircraftContactType[FGRD_AircraftContactType.CurrentRowIndex, FGRD_AircraftContactType.CurrentColumnIndex].Value = "Y";
						}
						else
						{
							Query = $"{Query}actype_transref_flag='N',";
							FGRD_AircraftContactType[FGRD_AircraftContactType.CurrentRowIndex, FGRD_AircraftContactType.CurrentColumnIndex].Value = "N";
						} 
						FGRD_AircraftContactType.CurrentColumnIndex = 7; 
						if (chk_actype_shareref_flag.CheckState == CheckState.Checked)
						{
							Query = $"{Query}actype_shareref_flag='Y',";
							FGRD_AircraftContactType[FGRD_AircraftContactType.CurrentRowIndex, FGRD_AircraftContactType.CurrentColumnIndex].Value = "T";
						}
						else
						{
							Query = $"{Query}actype_shareref_flag='N',";
							FGRD_AircraftContactType[FGRD_AircraftContactType.CurrentRowIndex, FGRD_AircraftContactType.CurrentColumnIndex].Value = "N";
						} 
						FGRD_AircraftContactType.CurrentColumnIndex = 8; 
						if (chk_compref_internal_flag.CheckState == CheckState.Checked)
						{
							Query = $"{Query}actype_compref_internal_flag='Y',";
							FGRD_AircraftContactType[FGRD_AircraftContactType.CurrentRowIndex, FGRD_AircraftContactType.CurrentColumnIndex].Value = "Y";
						}
						else
						{
							Query = $"{Query}actype_compref_internal_flag='N',";
							FGRD_AircraftContactType[FGRD_AircraftContactType.CurrentRowIndex, FGRD_AircraftContactType.CurrentColumnIndex].Value = "N";
						} 
						FGRD_AircraftContactType.CurrentColumnIndex = 3; 
						if (chk_compref_twoway_flag.CheckState == CheckState.Checked)
						{
							Query = $"{Query}actype_compref_twoway_flag='Y',";
							FGRD_AircraftContactType[FGRD_AircraftContactType.CurrentRowIndex, FGRD_AircraftContactType.CurrentColumnIndex].Value = "Y";
						}
						else
						{
							Query = $"{Query}actype_compref_twoway_flag='N',";
							FGRD_AircraftContactType[FGRD_AircraftContactType.CurrentRowIndex, FGRD_AircraftContactType.CurrentColumnIndex].Value = "N";
						} 
						Query = $"{Query}actype_compref_name2='{modAdminCommon.Fix_Quote(txt_compref_name2).Trim()}' "; 
						Query = $"{Query} WHERE actype_code='{txt_actype_code.Text.Trim()}'"; 
						 
						DbCommand TempCommand_2 = null; 
						TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand(); 
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2); 
						TempCommand_2.CommandText = Query; 
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2); 
						TempCommand_2.ExecuteNonQuery(); 
						FGRD_AircraftContactType.Refresh(); 
						MessageBox.Show("Update Successfully Completed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly())); 
						 
						Is_Dirty = true; 
						 
						break;
					case "Delete" : 
						Query = $"DELETE FROM Aircraft_Contact_Type  WHERE actype_code='{txt_actype_code.Text.Trim()}'"; 
						M = $"Aircraft Contact Type Delete For: {txt_actype_code.Text.Trim()}{"\r"}{"\r"}"; 
						M = $"{M}Do you wish to perform the delete at this time?"; 
						RESP = MessageBox.Show(M, "Confirm Delete!", MessageBoxButtons.YesNo, MessageBoxIcon.Question); 
						if (RESP == System.Windows.Forms.DialogResult.Yes)
						{
							DbCommand TempCommand_3 = null;
							TempCommand_3 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_3);
							TempCommand_3.CommandText = Query;
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_3);
							TempCommand_3.ExecuteNonQuery();
							Is_Dirty = true;
							FGRD_AircraftContactType.RemoveItem(FGRD_AircraftContactType.CurrentRowIndex);
							FGRD_AircraftContactType.Refresh();
							//Aircraft_Contact_Type ("Fill List")
							MessageBox.Show("Delete Successfully Completed.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						}
						else
						{
							MessageBox.Show("Delete Cancelled!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
						} 
						 
						break;
					case "Fill List" : 
						 
						AircraftContactTypeFill(); 
						 
						break;
				}

				this.Cursor = CursorHelper.CursorDefault;
			}
			catch
			{

				modAdminCommon.Report_Error("Aircraft_Contact_Type_Error: ");
				this.Cursor = CursorHelper.CursorDefault;

				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1065
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
				return;
			}

		}

		private void Update_Command_Buttons(string Action)
		{
			//enable/disable buttons

			switch(Action)
			{
				case "Enable" : 
					cmd_Add_Aircraft_Class.Enabled = true; 
					cmd_Add_Aircraft_Contact_type.Enabled = true; 
					cmd_Add_Aircraft_Status.Enabled = true; 
					cmd_Add_Aircraft_type.Enabled = true; 
					cmd_Add_APU.Enabled = true; 
					cmd_Add_Asking.Enabled = true; 
					cmd_Add_Avionics.Enabled = true; 
					cmd_Add_Certification.Enabled = true; 
					cmd_Add_EMP.Enabled = true; 
					cmd_Add_IC.Enabled = true; 
					cmd_Add_Kfeat.Enabled = true; 
					cmd_Add_Spec.Enabled = true; 
					 
					cmd_Cancel_Aircraft_Class.Enabled = true; 
					cmd_Cancel_Aircraft_Contact_Type.Enabled = true; 
					cmd_Cancel_Aircraft_Status.Enabled = true; 
					cmd_Cancel_Aircraft_Type.Enabled = true; 
					cmd_Cancel_APU.Enabled = true; 
					cmd_Cancel_Asking.Enabled = true; 
					cmd_Cancel_Avionics.Enabled = true; 
					cmd_Cancel_Certification.Enabled = true; 
					cmd_Cancel_EMP.Enabled = true; 
					cmd_Cancel_IC.Enabled = true; 
					cmd_Cancel_Kfeat.Enabled = true; 
					cmd_Cancel_Spec.Enabled = true; 
					 
					cmd_Delete_Aircraft_Class.Enabled = true; 
					cmd_Delete_Aircraft_Contact_Type.Enabled = true; 
					cmd_Delete_Aircraft_Status.Enabled = true; 
					cmd_Delete_Aircraft_Type.Enabled = true; 
					cmd_Delete_APU.Enabled = true; 
					cmd_Delete_Asking.Enabled = true; 
					cmd_Delete_Avionics.Enabled = true; 
					cmd_Delete_Certification.Enabled = true; 
					cmd_Delete_EMP.Enabled = true; 
					cmd_Delete_IC.Enabled = true; 
					cmd_Delete_Kfeat.Enabled = true; 
					cmd_Delete_Spec.Enabled = true; 
					 
					cmd_Save_Aircraft_Class.Enabled = true; 
					cmd_Save_Aircraft_Contact_Type.Enabled = true; 
					cmd_Save_Aircraft_Status.Enabled = true; 
					cmd_Save_Aircraft_Type.Enabled = true; 
					cmd_Save_APU.Enabled = true; 
					cmd_Save_Asking.Enabled = true; 
					cmd_Save_Avionics.Enabled = true; 
					cmd_Save_Certification.Enabled = true; 
					cmd_Save_EMP.Enabled = true; 
					cmd_Save_IC.Enabled = true; 
					cmd_Save_Kfeat.Enabled = true; 
					cmd_Save_Spec.Enabled = true; 
					 
					break;
				case "Disable" : 
					cmd_Add_Aircraft_Class.Enabled = false; 
					cmd_Add_Aircraft_Contact_type.Enabled = false; 
					cmd_Add_Aircraft_Status.Enabled = false; 
					cmd_Add_Aircraft_type.Enabled = false; 
					cmd_Add_APU.Enabled = false; 
					cmd_Add_Asking.Enabled = false; 
					cmd_Add_Avionics.Enabled = false; 
					cmd_Add_Certification.Enabled = false; 
					cmd_Add_EMP.Enabled = false; 
					cmd_Add_IC.Enabled = false; 
					cmd_Add_Kfeat.Enabled = false; 
					cmd_Add_Spec.Enabled = false; 
					 
					cmd_Cancel_Aircraft_Class.Enabled = false; 
					cmd_Cancel_Aircraft_Contact_Type.Enabled = false; 
					cmd_Cancel_Aircraft_Status.Enabled = false; 
					cmd_Cancel_Aircraft_Type.Enabled = false; 
					cmd_Cancel_APU.Enabled = false; 
					cmd_Cancel_Asking.Enabled = false; 
					cmd_Cancel_Avionics.Enabled = false; 
					cmd_Cancel_Certification.Enabled = false; 
					cmd_Cancel_EMP.Enabled = false; 
					cmd_Cancel_IC.Enabled = false; 
					cmd_Cancel_Kfeat.Enabled = false; 
					cmd_Cancel_Spec.Enabled = false; 
					 
					cmd_Delete_Aircraft_Class.Enabled = false; 
					cmd_Delete_Aircraft_Contact_Type.Enabled = false; 
					cmd_Delete_Aircraft_Status.Enabled = false; 
					cmd_Delete_Aircraft_Type.Enabled = false; 
					cmd_Delete_APU.Enabled = false; 
					cmd_Delete_Asking.Enabled = false; 
					cmd_Delete_Avionics.Enabled = false; 
					cmd_Delete_Certification.Enabled = false; 
					cmd_Delete_EMP.Enabled = false; 
					cmd_Delete_IC.Enabled = false; 
					cmd_Delete_Kfeat.Enabled = false; 
					cmd_Delete_Spec.Enabled = false; 
					 
					cmd_Save_Aircraft_Class.Enabled = false; 
					cmd_Save_Aircraft_Contact_Type.Enabled = false; 
					cmd_Save_Aircraft_Status.Enabled = false; 
					cmd_Save_Aircraft_Type.Enabled = false; 
					cmd_Save_APU.Enabled = false; 
					cmd_Save_Asking.Enabled = false; 
					cmd_Save_Avionics.Enabled = false; 
					cmd_Save_Certification.Enabled = false; 
					cmd_Save_EMP.Enabled = false; 
					cmd_Save_IC.Enabled = false; 
					cmd_Save_Kfeat.Enabled = false; 
					cmd_Save_Spec.Enabled = false; 
					 
					break;
			}

		}

		public void Airport_Clear_Input()
		{

			try
			{

				lblAirport[18].Text = "0"; // Airport Id
				txtAirport[iAPORTNAME_INDEX].Text = ""; // Airport Name
				txtAirport[iIATA_INDEX].Text = ""; // IATA Code
				txtAirport[iICAO_INDEX].Text = ""; // ICAO Code
				txtAirport[iCITY_INDEX].Text = ""; // City

				// 06/18/2019 - By David D. Cruger; Added
				txtAirport[iCOMPID_INDEX].Text = "0"; // CompId
				txtAirport[iCOMPID_INDEX].Tag = "0"; // CompId
				ToolTipMain.SetToolTip(txtAirport[iCOMPID_INDEX], ""); // Company Name

				txtAirport[4].Text = ""; // Latitude Full
				txtAirport[5].Text = ""; // Direction
				txtAirport[6].Text = ""; // Degrees
				txtAirport[7].Text = ""; // Minutes
				txtAirport[8].Text = ""; // Seconds

				txtAirport[9].Text = ""; // Longitude Full
				txtAirport[10].Text = ""; // Direction
				txtAirport[11].Text = ""; // Degrees
				txtAirport[12].Text = ""; // Minutes
				txtAirport[13].Text = ""; // Seconds

				txtAirport[14].Text = ""; // Max Runway Length
				txtAirport[15].Text = ""; // Unit

				txtAirport[iLAT_INDEX].Text = ""; // Decimal
				txtAirport[iLAT_INDEX].Tag = ""; // Decimal
				txtAirport[iLONG_INDEX].Text = ""; // Decimal
				txtAirport[iLONG_INDEX].Tag = ""; // Decimal

				txtAirport[iFAAID_INDEX].Text = ""; // FAA Id

				Fill_State(cbo_aport_state);
				Fill_Country(cbo_aport_country);
				chk_aport_active_flag.CheckState = CheckState.Checked;
				lbl_aircraft_count.Text = "";
				lblAirport[0].Text = "Airport Name";
				RecordStat = "Add";
				//lblAirport(iLAT_INDEX ).Visible = False ' Google
				ac_count = 0;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"Airport_Clear_Input_Error: {excep.Message}");
			}

		} // Airport_Clear_Input

		public void Airport_Display()
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			ADORecordSetHelper rstRec2 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strQuery2 = "";

			int lRow = 0;
			string strIATA = "";
			string strICAO = "";
			int lAPortId = 0;
			string strCompId = "";
			string strCompany = "";

			try
			{

				lRow = grd_Airport.CurrentRowIndex;
				lAPortId = grd_Airport.get_RowData(lRow);

				if (lAPortId > 0)
				{

					grd_Airport.CurrentColumnIndex = 0;
					strIATA = ($"{grd_Airport[grd_Airport.CurrentRowIndex, grd_Airport.CurrentColumnIndex].FormattedValue.ToString()}").Trim();
					grd_Airport.CurrentColumnIndex = 1;
					strICAO = ($"{grd_Airport[grd_Airport.CurrentRowIndex, grd_Airport.CurrentColumnIndex].FormattedValue.ToString()}").Trim();

					strQuery1 = "SELECT * FROM Airport WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1}WHERE (aport_id = {lAPortId.ToString()}) ";

					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						frmAirport.Text = "Airport";
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["aport_action_date"]))
						{
							if (Convert.ToDateTime(rstRec1["aport_action_date"]) >= DateTime.Parse("1/1/2000"))
							{
								frmAirport.Text = $"Airport - Last Updated: {StringsHelper.Format(rstRec1["aport_action_date"], "MM/dd/yyyy hh:mm:ss AMPM")}";
							}
						}

						lblAirport[18].Text = lAPortId.ToString(); // Airport Id
						txtAirport[iAPORTNAME_INDEX].Text = ($"{Convert.ToString(rstRec1["aport_name"])} ").Trim(); // Airport Name
						txtAirport[iIATA_INDEX].Text = ($"{Convert.ToString(rstRec1["aport_iata_code"])} ").Trim(); // IATA Code
						txtAirport[iICAO_INDEX].Text = ($"{Convert.ToString(rstRec1["aport_icao_code"])} ").Trim(); // ICAO Code
						txtAirport[iFAAID_INDEX].Text = ($"{Convert.ToString(rstRec1["aport_faaid_code"])} ").Trim(); // FAA ID
						txtAirport[iCOMPID_INDEX].Text = ($"{Convert.ToString(rstRec1["aport_comp_id"])} ").Trim(); // CompId
						txtAirport[iCOMPID_INDEX].Tag = ($"{Convert.ToString(rstRec1["aport_comp_id"])} ").Trim(); // CompId
						ToolTipMain.SetToolTip(txtAirport[iCOMPID_INDEX], "");

						if (Convert.ToDouble(rstRec1["aport_comp_id"]) > 0)
						{
							ToolTipMain.SetToolTip(txtAirport[iCOMPID_INDEX], modAdminCommon.DLookUp("comp_name", "Company", $"(comp_id = {Convert.ToString(rstRec1["aport_comp_id"])} AND comp_journ_id = 0)"));
						}

						txtAirport[3].Text = ($"{Convert.ToString(rstRec1["aport_city"])} ").Trim(); // City

						txtAirport[4].Text = ($"{Convert.ToString(rstRec1["aport_latitude_full"])} ").Trim(); // Latitude Full
						txtAirport[5].Text = ($"{Convert.ToString(rstRec1["aport_latitude_direction"])} ").Trim(); // Direction

						txtAirport[iLAT_INDEX].Tag = "";
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["aport_latitude_decimal"]))
						{
							txtAirport[iLAT_INDEX].Text = StringsHelper.Format(rstRec1["aport_latitude_decimal"], "#0.00000000"); // Decimal
							txtAirport[iLAT_INDEX].Tag = StringsHelper.Format(rstRec1["aport_latitude_decimal"], "#0.00000000"); // Decimal
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["aport_latitude_degrees"]))
						{
							txtAirport[6].Text = Convert.ToString(rstRec1["aport_latitude_degrees"]); // Degrees
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["aport_latitude_minutes"]))
						{
							txtAirport[7].Text = Convert.ToString(rstRec1["aport_latitude_minutes"]); // Minutes
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["aport_latitude_seconds"]))
						{
							txtAirport[8].Text = Convert.ToString(rstRec1["aport_latitude_seconds"]); // Seconds
						}

						txtAirport[9].Text = ($"{Convert.ToString(rstRec1["aport_longitude_full"])} ").Trim(); // Longitude Full
						txtAirport[10].Text = ($"{Convert.ToString(rstRec1["aport_longitude_direction"])} ").Trim(); // Direction

						txtAirport[iLONG_INDEX].Tag = "";
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["aport_longitude_decimal"]))
						{
							txtAirport[iLONG_INDEX].Text = StringsHelper.Format(rstRec1["aport_longitude_decimal"], "#0.00000000"); // Decimal
							txtAirport[iLONG_INDEX].Tag = StringsHelper.Format(rstRec1["aport_longitude_decimal"], "#0.00000000"); // Decimal
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["aport_longitude_degrees"]))
						{
							txtAirport[11].Text = Convert.ToString(rstRec1["aport_longitude_degrees"]); // Degrees
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["aport_longitude_minutes"]))
						{
							txtAirport[12].Text = Convert.ToString(rstRec1["aport_longitude_minutes"]); // Minutes
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["aport_longitude_seconds"]))
						{
							txtAirport[13].Text = Convert.ToString(rstRec1["aport_longitude_seconds"]); // Seconds
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["aport_max_runway_length"]))
						{
							txtAirport[14].Text = Convert.ToString(rstRec1["aport_max_runway_length"]); // Max Runway Length
						}

						txtAirport[15].Text = ($"{Convert.ToString(rstRec1["aport_max_runway_length_unit"])} ").Trim(); // Unit

						if (($"{Convert.ToString(rstRec1["aport_active_flag"])} ").Trim().ToUpper() == "Y")
						{
							chk_aport_active_flag.CheckState = CheckState.Checked;
							Airport_Active_Status = "Active";
						}
						else
						{
							chk_aport_active_flag.CheckState = CheckState.Unchecked;
							Airport_Active_Status = "InActive";
						}

						if (chkAirportListOptions[APortACCounts].CheckState == CheckState.Checked)
						{
							lbl_aircraft_count.Text = $"{($"{Convert.ToString(grd_Airport[grd_Airport.CurrentRowIndex, 8].Value)} ").Trim()} Aircraft at this Airport";
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["aport_state"]))
						{

							strQuery2 = "SELECT state_name FROM State WITH (NOLOCK) ";
							strQuery2 = $"{strQuery2} WHERE (state_code =  '{($"{Convert.ToString(rstRec1["aport_state"])}").Trim()}') and state_country = '{Convert.ToString(rstRec1["aport_country"])}'  ";

							rstRec2.Open(strQuery2, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

							if ((!rstRec2.BOF) && (!rstRec2.EOF))
							{
								Fill_State(cbo_aport_state, $"{($"{Convert.ToString(rstRec1["aport_state"])}").Trim()} -- {($"{Convert.ToString(rstRec2["State_name"])} ").Trim()}");
							}
							else
							{
								Fill_State(cbo_aport_state);
							}

							rstRec2.Close();

						}
						else
						{
							Fill_State(cbo_aport_state);
						} // If IsNull(rstRec1!aport_state) = False Then

						grd_Airport.CurrentColumnIndex = 5;
						Fill_Country(cbo_aport_country, ($"{Convert.ToString(rstRec1["aport_country"])} ").Trim());

					} // If snp_Airport.BOF = False And snp_Airport.EOF = False Then

					rstRec1.Close();

				} // If lAPortId > 0 Then

				rstRec2 = null;
				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"Airport_Display_Error: {strIATA}-{strICAO} - {excep.Message}");
				this.Cursor = CursorHelper.CursorDefault;
			}

		} // Airport_Display

		public void Airport_Insert()
		{

			ADORecordSetHelper rstAdd1 = new ADORecordSetHelper();
			string strAdd1 = "";

			int lAPortId = 0;
			string strCompId = "";
			string strIATA = "";
			string strICAO = "";
			string strFAAID = "";
			string strTemp = "";
			string strInsert1 = "";
			string strUnit = "";
			int lCol = 0;
			int lFeet = 0;

			try
			{

				strIATA = ($"{txtAirport[iIATA_INDEX].Text} ").Trim().ToUpper();
				strICAO = ($"{txtAirport[iICAO_INDEX].Text} ").Trim().ToUpper();
				strFAAID = ($"{txtAirport[iFAAID_INDEX].Text} ").Trim().ToUpper();
				strCompId = ($"{txtAirport[iCOMPID_INDEX].Text} ").Trim().ToUpper();

				if (txtAirport[iAPORTNAME_INDEX].Text == "")
				{
					MessageBox.Show("Unable To Add Please enter an Airport Name", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					return;
				}

				if (IsAirportUnique(strIATA, strICAO, strFAAID, -1))
				{

					Format_Latitude_Longitude_Values_Decimal_Or_Dir_Degree_Minute_Second();

					strAdd1 = "SELECT * FROM Airport WHERE (aport_id = -1)";

					rstAdd1.CursorLocation = CursorLocationEnum.adUseClient;
					rstAdd1.Open(strAdd1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockBatchOptimistic);

					rstAdd1.AddNew();

					rstAdd1["aport_iata_code"] = strIATA;
					rstAdd1["aport_icao_code"] = strICAO;
					rstAdd1["aport_faaid_code"] = strFAAID;
					rstAdd1["aport_comp_id"] = strCompId;

					rstAdd1["aport_name"] = txtAirport[iAPORTNAME_INDEX].Text;
					rstAdd1["aport_city"] = txtAirport[iCITY_INDEX].Text;
					if (cbo_aport_state.Text.Substring(0, Math.Min(2, cbo_aport_state.Text.Length)).Trim() != "")
					{
						rstAdd1["aport_state"] = cbo_aport_state.Text.Substring(0, Math.Min(cbo_aport_state.Text.IndexOf(" -- "), cbo_aport_state.Text.Length)).Trim();
					}
					rstAdd1["aport_country"] = cbo_aport_country.Text.Trim();

					rstAdd1["aport_latitude_full"] = ($"{txtAirport[4].Text} ").Trim();
					if (($"{txtAirport[iLAT_INDEX].Text} ").Trim() != "")
					{
						rstAdd1["aport_latitude_decimal"] = Double.Parse(($"{txtAirport[iLAT_INDEX].Text} ").Trim());
					}
					rstAdd1["aport_latitude_direction"] = ($"{txtAirport[5].Text} ").Trim();
					if (($"{txtAirport[6].Text} ").Trim() != "")
					{
						rstAdd1["aport_latitude_degrees"] = Convert.ToInt32(Double.Parse(($"{txtAirport[6].Text} ").Trim()));
					}
					if (($"{txtAirport[7].Text} ").Trim() != "")
					{
						rstAdd1["aport_latitude_minutes"] = Convert.ToInt32(Double.Parse(($"{txtAirport[7].Text} ").Trim()));
					}
					if (($"{txtAirport[8].Text} ").Trim() != "")
					{
						rstAdd1["aport_latitude_seconds"] = Convert.ToInt32(Double.Parse(($"{txtAirport[8].Text} ").Trim()));
					}

					rstAdd1["aport_longitude_full"] = ($"{txtAirport[9].Text} ").Trim();
					if (($"{txtAirport[iLONG_INDEX].Text} ").Trim() != "")
					{
						rstAdd1["aport_longitude_decimal"] = Double.Parse(($"{txtAirport[iLONG_INDEX].Text} ").Trim());
					}
					rstAdd1["aport_longitude_direction"] = ($"{txtAirport[10].Text} ").Trim();
					if (($"{txtAirport[11].Text} ").Trim() != "")
					{
						rstAdd1["aport_longitude_degrees"] = Convert.ToInt32(Double.Parse(($"{txtAirport[11].Text} ").Trim()));
					}
					if (($"{txtAirport[12].Text} ").Trim() != "")
					{
						rstAdd1["aport_longitude_minutes"] = Convert.ToInt32(Double.Parse(($"{txtAirport[12].Text} ").Trim()));
					}
					if (($"{txtAirport[13].Text} ").Trim() != "")
					{
						rstAdd1["aport_longitude_seconds"] = Convert.ToInt32(Double.Parse(($"{txtAirport[13].Text} ").Trim()));
					}

					if (($"{txtAirport[14].Text} ").Trim() != "")
					{
						rstAdd1["aport_max_runway_length"] = Convert.ToInt32(Double.Parse(($"{txtAirport[14].Text} ").Trim()));
					}

					// Default To Feet If Nothing Entered
					strUnit = ($"{txtAirport[15].Text} ").Trim().ToUpper();

					// Default To Feet If Nothing Entered
					if (($"{txtAirport[14].Text} ").Trim() != "" && (strUnit == "" || strUnit == "FT"))
					{
						txtAirport[15].Text = "Feet";
					}

					if (strUnit.StartsWith("MILE", StringComparison.Ordinal) || strUnit == "MI")
					{
						lFeet = modAdminCommon.Convert_Miles_To_Feet(Double.Parse($"{txtAirport[14].Text} "));
						txtAirport[14].Text = lFeet.ToString();
						txtAirport[15].Text = "Feet";
					}

					if (strUnit.StartsWith("METER", StringComparison.Ordinal) || strUnit == "MR")
					{
						lFeet = modAdminCommon.Convert_Meters_To_Feet(Double.Parse($"{txtAirport[14].Text} "));
						txtAirport[14].Text = lFeet.ToString();
						txtAirport[15].Text = "Feet";
					}

					if (strUnit.StartsWith("KILO", StringComparison.Ordinal) || strUnit == "KM")
					{
						lFeet = modAdminCommon.Convert_Kilo_Meters_To_Feet(Double.Parse($"{txtAirport[14].Text} "));
						txtAirport[14].Text = lFeet.ToString();
						txtAirport[15].Text = "Feet";
					}

					rstAdd1["aport_max_runway_length_unit"] = ($"{txtAirport[15].Text} ").Trim();

					if (chk_aport_active_flag.CheckState == CheckState.Checked)
					{
						rstAdd1["aport_active_flag"] = "Y";
					}
					else
					{
						rstAdd1["aport_active_flag"] = "N";
					}

					rstAdd1["aport_action_date"] = DateTime.Parse("1/1/1900");

					rstAdd1.UpdateBatch();

					lAPortId = Convert.ToInt32(rstAdd1["aport_id"]);

					rstAdd1.Close();

					grd_Airport.RowsCount++;
					grd_Airport.CurrentRowIndex = grd_Airport.RowsCount - 1;

					lCol = -1;

					lCol++;
					grd_Airport.CurrentColumnIndex = lCol;
					grd_Airport.CellAlignment = DataGridViewContentAlignment.TopLeft;
					grd_Airport[grd_Airport.CurrentRowIndex, grd_Airport.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txtAirport[iIATA_INDEX].Text).Trim();

					lCol++;
					grd_Airport.CurrentColumnIndex = lCol;
					grd_Airport.CellAlignment = DataGridViewContentAlignment.TopLeft;
					grd_Airport[grd_Airport.CurrentRowIndex, grd_Airport.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txtAirport[iICAO_INDEX].Text).Trim();

					lCol++;
					grd_Airport.CurrentColumnIndex = lCol;
					grd_Airport.CellAlignment = DataGridViewContentAlignment.TopLeft;
					grd_Airport[grd_Airport.CurrentRowIndex, grd_Airport.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txtAirport[iFAAID_INDEX].Text).Trim();

					lCol++;
					grd_Airport.CurrentColumnIndex = lCol;
					grd_Airport.CellAlignment = DataGridViewContentAlignment.TopLeft;
					grd_Airport[grd_Airport.CurrentRowIndex, grd_Airport.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txtAirport[iAPORTNAME_INDEX].Text).Trim();

					lCol++;
					grd_Airport.CurrentColumnIndex = lCol;
					grd_Airport.CellAlignment = DataGridViewContentAlignment.TopLeft;
					grd_Airport[grd_Airport.CurrentRowIndex, grd_Airport.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(txtAirport[iCITY_INDEX].Text).Trim();

					lCol++;
					grd_Airport.CurrentColumnIndex = lCol;
					grd_Airport.CellAlignment = DataGridViewContentAlignment.TopCenter;
					grd_Airport[grd_Airport.CurrentRowIndex, grd_Airport.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(cbo_aport_state).Trim();

					lCol++;
					grd_Airport.CurrentColumnIndex = lCol;
					grd_Airport.CellAlignment = DataGridViewContentAlignment.TopLeft;
					grd_Airport[grd_Airport.CurrentRowIndex, grd_Airport.CurrentColumnIndex].Value = modAdminCommon.Fix_Quote(cbo_aport_country).Trim();

					lCol++;
					grd_Airport.CurrentColumnIndex = lCol;
					grd_Airport.CellAlignment = DataGridViewContentAlignment.TopCenter;
					if (chk_aport_active_flag.CheckState == CheckState.Checked)
					{
						grd_Airport[grd_Airport.CurrentRowIndex, grd_Airport.CurrentColumnIndex].Value = "Y";
					}
					else
					{
						grd_Airport[grd_Airport.CurrentRowIndex, grd_Airport.CurrentColumnIndex].Value = "N";
					}

					grd_Airport.set_RowData(grd_Airport.CurrentRowIndex, lAPortId);

					lbl_aircraft_count.Text = "";
					lbl_Airport_Count.Visible = true;
					if (chkAirportListOptions[APortACCounts].CheckState == CheckState.Checked)
					{
						txt_AirportColor.Visible = true;
					}
					lbl_Airport_Count.Text = $"Number of Airports: {(grd_Airport.RowsCount - 1).ToString()}";
					lblAirport[18].Text = lAPortId.ToString(); // Airport Id

					Update_FAA_Flight_Data(lAPortId, "", "", "", strIATA, strICAO, strFAAID);

					modAdminCommon.Record_Event("Airport", $"Airport Added: [{txtAirport[iIATA_INDEX].Text}]-[{txtAirport[iICAO_INDEX].Text}]-[{txtAirport[iFAAID_INDEX].Text}] - {txtAirport[iAPORTNAME_INDEX].Text}", 0, 0, 0, false);

					lbl_Airport_Message[1].Text = $"Airport - {txtAirport[iAPORTNAME_INDEX].Text} Has Been Added";

				} // If IsAirportUnique(Trim$(txtAirport(iIATA_INDEX).Text), Trim$(txtAirport(iICAO_INDEX).Text), -1) = True Then
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"Airport_Insert_Error: {strIATA}-{strICAO}-{strFAAID} - {excep.Message}");
				this.Cursor = CursorHelper.CursorDefault;
			}

		} // Airport_Insert

		public void Airport_Select()
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strIATA = "";
			string strICAO = "";
			string strFAAID = "";
			int lRow = 0;

			try
			{

				lRow = grd_Airport.CurrentRowIndex;

				strIATA = ($"{Convert.ToString(grd_Airport[lRow, 0].Value)} ").Trim();
				strICAO = ($"{Convert.ToString(grd_Airport[lRow, 1].Value)} ").Trim();
				strFAAID = ($"{Convert.ToString(grd_Airport[lRow, 2].Value)} ").Trim();

				if (strIATA != "" || strICAO != "" || strFAAID != "")
				{

					this.Cursor = Cursors.WaitCursor;
					lbl_Airport_Message[1].Text = "Selecting Airport. Please Wait ...";
					Application.DoEvents();

					Airport_Clear_Input();
					Airport_Display();

					this.Cursor = CursorHelper.CursorDefault;
					lbl_Airport_Message[1].Text = "Airports Listed. Click on Heading to Re-Sort. Double-Click to Select.";
					lbl_Airport_Count.Visible = true;

					strQuery1 = "SELECT COUNT(*) AS ACCount FROM Aircraft WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1}WHERE (ac_journ_id = 0) ";

					if (lblAirport[18].Text.Trim() != "")
					{
						strQuery1 = $"{strQuery1}AND (ac_aport_id = '{lblAirport[18].Text}' )";
					}
					else
					{
						if (strIATA != "")
						{
							strQuery1 = $"{strQuery1}AND (ac_aport_iata_code = '{strIATA}') ";
						}
						else
						{
							strQuery1 = $"{strQuery1}AND (ac_aport_iata_code = '' OR ac_aport_iata_code IS NULL) ";
						}
						if (strICAO != "")
						{
							strQuery1 = $"{strQuery1}AND (ac_aport_icao_code = '{strICAO}') ";
						}
						else
						{
							strQuery1 = $"{strQuery1}AND (ac_aport_icao_code = '' OR ac_aport_icao_code IS NULL) ";
						}

						if (strFAAID != "")
						{
							strQuery1 = $"{strQuery1}AND (ac_aport_faaid_code = '{strFAAID}') ";
						}
						else
						{
							strQuery1 = $"{strQuery1}AND (ac_aport_faaid_code = '' OR ac_aport_faaid_code IS NULL) ";
						}
					}

					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					ac_count = 0;
					if ((!rstRec1.BOF) && (!rstRec1.EOF))
					{
						ac_count = Convert.ToInt32(rstRec1["ACCount"]);
					}

					rstRec1.Close();

					//---------------------------------------------------
					// Find Number Of Flights To/From This Airport

					strQuery1 = "SELECT COUNT(*) AS lNbrFlights  FROM FAA_Flight_Data WITH (NOLOCK)  ";
					strQuery1 = $"{strQuery1}WHERE (ffd_journ_id = 0) ";
					strQuery1 = $"{strQuery1}AND (ffd_dest_aport_id = '{lblAirport[18].Text}' or ffd_origin_aport_id = '{lblAirport[18].Text}'  )";

					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					lNbrFlights = 0;
					if ((!rstRec1.BOF) && (!rstRec1.EOF))
					{
						lNbrFlights = Convert.ToInt32(rstRec1["lNbrFlights"]);
					}

					rstRec1.Close();

					lbl_Airport_Count.Text = $"Airports Listed: ({StringsHelper.Format(grd_Airport.RowsCount - 1, "#,##0")})    Nbr of Aircraft: ({StringsHelper.Format(ac_count, "#,##0")})    Nbr of Flights: ({StringsHelper.Format(lNbrFlights, "#,##0")})";

					if (chkAirportListOptions[APortACCounts].CheckState == CheckState.Checked)
					{
						txt_AirportColor.Visible = true;
					}

					RecordStat = "Update";

				} // If strIATA <> "" Or strICAO <> "" Or strFAAID <> "" Then

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"Airport_Select_Error: {strIATA}-{strICAO}-{strFAAID} - {excep.Message}");
				this.Cursor = CursorHelper.CursorDefault;
			}

		} // Airport_Select

		public void Update_FAA_Flight_Data(int lAPortId, string strIATAOld, string strICAOOld, string strFAAIDOld, string strIATANew, string strICAONew, string strFAAIDNew)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strUpdate1 = "";
			int lRec = 0;
			int lTotRec1 = 0;
			int lTotRec2 = 0;
			int lCommandTimeOut = 0;
			string strAPortId = "";
			string strMsg = "";
			int lTop = 0;
			int lMaxLoop = 0;
			int lUpdate1 = 0;
			int lUpdate2 = 0;
			bool bTrans = false;
			string strErrDesc = "";

			try
			{

				lCommandTimeOut = UpgradeHelpers.DB.DbConnectionHelper.GetCommandTimeOut(modAdminCommon.LOCAL_ADO_DB);
				UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(modAdminCommon.LOCAL_ADO_DB, 25000);

				strQuery1 = "SELECT COUNT(ffd_unique_flight_id) AS TotRec ";
				strQuery1 = $"{strQuery1}FROM FAA_Flight_Data WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (ffd_origin_aport_id = {lAPortId.ToString()}) OR (ffd_dest_aport_id = {lAPortId.ToString()}) ";

				rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					rstRec1.ActiveConnection = null;
					lTotRec1 = Convert.ToInt32(rstRec1["TotRec"]);
					lRec = 0;

					if (lTotRec1 > 0)
					{

						strMsg = $"Clearing FAA Flight Data Of Airport Id...Please Wait - Updating {StringsHelper.Format(lTotRec1, "#,##0")} Record(s)";
						if (lTotRec1 > 10000)
						{
							strMsg = $"{strMsg} - This Many Records Will Take Some Time To Process";
						}

						modStatusBar.Update_Status_Bar(modAdminCommon.SB, strMsg, Color.Blue);

						lTop = 15000;
						lMaxLoop = 5000;
						if (lTotRec1 > lTop)
						{
							lMaxLoop = Convert.ToInt32((lTotRec1 / ((double) lTop)) + 5);
						}

						// Updates Origin Airport Id - Clear
						lUpdate1 = modAdminCommon.Update_FAA_Flight_Data_Clear_APort_Id_Distance_In_Batch_Mode(modAdminCommon.LOCAL_ADO_DB, lbl_Airport_Message[1], lAPortId, true, ref lTop, ref lMaxLoop);

						// Updates Dest Airport Id  - Clear
						lUpdate2 = modAdminCommon.Update_FAA_Flight_Data_Clear_APort_Id_Distance_In_Batch_Mode(modAdminCommon.LOCAL_ADO_DB, lbl_Airport_Message[1], lAPortId, false, ref lTop, ref lMaxLoop);

					} // If lTotRec > 0 Then

					lTotRec2 = 0;

					if (strFAAIDNew != "")
					{

						modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Updating FAA Flight Data Of Airport Id = FAAID...Please Wait", Color.Blue);

						// Updates Origin Airport Id - New Airport Id
						lUpdate1 = modAdminCommon.Update_FAA_Flight_Data_APort_Id_By_APort_Code_In_Batch_Mode(modAdminCommon.LOCAL_ADO_DB, lbl_Airport_Message[1], lAPortId, strFAAIDNew, true, ref lTop, ref lMaxLoop);

						lTotRec2 += lUpdate1;

						// Updates Dest Airport Id - New Airport Id
						lUpdate2 = modAdminCommon.Update_FAA_Flight_Data_APort_Id_By_APort_Code_In_Batch_Mode(modAdminCommon.LOCAL_ADO_DB, lbl_Airport_Message[1], lAPortId, strFAAIDNew, false, ref lTop, ref lMaxLoop);

						lTotRec2 += lUpdate2;

					} // If strFAAIDNew <> "" Then

					if (strIATANew != "" && strIATANew != strFAAIDNew)
					{

						// Update ONLY If IATA Does NOT Also Exists As An FAAID
						strAPortId = modAdminCommon.DLookUp("aport_id", "Airport", $"aport_faaid_code='{strIATANew}'");

						if (strAPortId == "")
						{

							modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Updating FAA Flight Data Of Airport Id = IATA...Please Wait", Color.Blue);

							// Updates Origin Airport Id - New Airport Id
							lUpdate1 = modAdminCommon.Update_FAA_Flight_Data_APort_Id_By_APort_Code_In_Batch_Mode(modAdminCommon.LOCAL_ADO_DB, lbl_Airport_Message[1], lAPortId, strIATANew, true, ref lTop, ref lMaxLoop);

							lTotRec2 += lUpdate1;

							// Updates Dest Airport Id - New Airport Id
							lUpdate2 = modAdminCommon.Update_FAA_Flight_Data_APort_Id_By_APort_Code_In_Batch_Mode(modAdminCommon.LOCAL_ADO_DB, lbl_Airport_Message[1], lAPortId, strIATANew, false, ref lTop, ref lMaxLoop);

							lTotRec2 += lUpdate2;

						} // If strAPortId = "" Then

					} // If strIATANew <> "" And strIATANew <> strFAAIDNew Then

					if (strICAONew != "")
					{

						// Update ONLY If ICAO Does NOT Also Exists As An FAAID
						strAPortId = modAdminCommon.DLookUp("aport_id", "Airport", $"aport_faaid_code='{strICAONew}'");

						if (strAPortId == "")
						{

							modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Updating FAA Flight Data Of Airport Id = ICAO...Please Wait", Color.Blue);

							// Updates Origin Airport Id - New Airport Id
							lUpdate1 = modAdminCommon.Update_FAA_Flight_Data_APort_Id_By_APort_Code_In_Batch_Mode(modAdminCommon.LOCAL_ADO_DB, lbl_Airport_Message[1], lAPortId, strICAONew, true, ref lTop, ref lMaxLoop);

							lTotRec2 += lUpdate1;

							// Updates Dest Airport Id - New Airport Id
							lUpdate2 = modAdminCommon.Update_FAA_Flight_Data_APort_Id_By_APort_Code_In_Batch_Mode(modAdminCommon.LOCAL_ADO_DB, lbl_Airport_Message[1], lAPortId, strICAONew, false, ref lTop, ref lMaxLoop);

							lTotRec2 += lUpdate2;

						} // If strAPortId = "" Then

					} // If strICAONew <> "" Then

					if (lTotRec2 > 0)
					{

						modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Updating FAA Flight Data Of Distance...Please Wait", Color.Blue);

						lUpdate1 = modAdminCommon.Update_FAA_Flight_Data_Distance_By_APort_Id_In_Batch_Mode(modAdminCommon.LOCAL_ADO_DB, lbl_Airport_Message[1], lAPortId, true, ref lTop, ref lMaxLoop);

						lTotRec2 += lUpdate1;

						lUpdate1 = modAdminCommon.Update_FAA_Flight_Data_Distance_By_APort_Id_In_Batch_Mode(modAdminCommon.LOCAL_ADO_DB, lbl_Airport_Message[1], lAPortId, false, ref lTop, ref lMaxLoop);

						lTotRec2 += lUpdate2;

						// Update Hide Flag = N If Time/Distance Are OK
						modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Updating FAA Flight Data - Setting Hide Flag = N...Please Wait", Color.Blue);

						strUpdate1 = "UPDATE FAA_Flight_Data SET ffd_hide_flag = 'N' WHERE (ffd_action_date IN ('1/1/1911','1/2/1911')) ";
						strUpdate1 = $"{strUpdate1}AND (ffd_hide_flag = 'Y') ";
						strUpdate1 = $"{strUpdate1}AND (ffd_distance > 0) AND (ffd_distance IS NOT NULL) ";
						strUpdate1 = $"{strUpdate1}AND (ffd_flight_time > 0) AND (ffd_flight_time IS NOT NULL) ";

						bTrans = true;
						UpgradeHelpers.DB.TransactionManager.Enlist(modAdminCommon.LOCAL_ADO_DB.BeginTransaction());
						DbCommand TempCommand = null;
						TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
						TempCommand.CommandText = strUpdate1;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
						lRec = TempCommand.ExecuteNonQuery();
						UpgradeHelpers.DB.TransactionManager.Commit(modAdminCommon.LOCAL_ADO_DB);
						bTrans = false;

					} // If lTotRec2 > 0 Then

					modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Updating FAA Flight Data - Clearing Action Date...Please Wait", Color.Blue);

					lUpdate1 = modAdminCommon.Update_FAA_Flight_Data_Clear_Action_Date_For_By_Action_Date_In_Batch_Mode(modAdminCommon.LOCAL_ADO_DB, lbl_Airport_Message[1], DateTime.Parse("1/1/1911"), ref lTop, ref lMaxLoop);

					lUpdate1 = modAdminCommon.Update_FAA_Flight_Data_Clear_Action_Date_For_By_Action_Date_In_Batch_Mode(modAdminCommon.LOCAL_ADO_DB, lbl_Airport_Message[1], DateTime.Parse("1/2/1911"), ref lTop, ref lMaxLoop);

					lbl_Airport_Message[1].Text = $"Finished FAA Flight Data - Updated {StringsHelper.Format(lTotRec2, "#,##0")} Record(s)...";

					modStatusBar.Update_Status_Bar(modAdminCommon.SB, $"Finished FAA Flight Data - Updated {StringsHelper.Format(lTotRec2, "#,##0")} Record(s)...", Color.Blue);

				} // If rstRec1.BOF = False And rstRec1.EOF = False Then

				rstRec1.Close();
				rstRec1 = null;

				UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(modAdminCommon.LOCAL_ADO_DB, lCommandTimeOut);
			}
			catch (System.Exception excep)
			{

				strErrDesc = excep.Message;

				if (bTrans)
				{
					UpgradeHelpers.DB.TransactionManager.Rollback(modAdminCommon.LOCAL_ADO_DB);
				}

				modAdminCommon.Report_Error($"Update_FAA_Flight_Data: {strIATANew}-{strICAONew}-{strFAAIDNew} - {strErrDesc}");
			}

		} // Update_FAA_Flight_Data

		public void Airport_Update(int lAPortId)
		{

			string strIATAOld = "";
			string strICAOOld = "";
			string strFAAIDOld = "";

			string strLatOld = "";
			string strLongOld = "";

			string strIATANew = "";
			string strICAONew = "";
			string strFAAIDNew = "";
			string strCompIdNew = "";

			string strLatNew = "";
			string strLongNew = "";

			string strAPortName = "";
			string strAPortCity = "";
			string strAPortState = "";
			string strAPortCountry = "";
			string strTemp = "";
			int lRow = 0;
			bool bTrans = false;
			string strErrDesc = "";
			int lFeet = 0;
			string strUnit = "";
			string user_id = "";
			string strUpdate1 = "";

			try
			{


				if (lAPortId > 0)
				{

					lRow = grd_Airport.CurrentRowIndex;

					strIATAOld = ($"{Convert.ToString(grd_Airport[lRow, 0].Value)}").Trim();
					strICAOOld = ($"{Convert.ToString(grd_Airport[lRow, 1].Value)}").Trim();
					strFAAIDOld = ($"{Convert.ToString(grd_Airport[lRow, 2].Value)}").Trim();
					strLatOld = ($"{Convert.ToString(txtAirport[iLAT_INDEX].Tag)} ").Trim();
					strLongOld = ($"{Convert.ToString(txtAirport[iLONG_INDEX].Tag)} ").Trim();

					strIATANew = ($"{txtAirport[iIATA_INDEX].Text} ").Trim().ToUpper();
					strICAONew = ($"{txtAirport[iICAO_INDEX].Text} ").Trim().ToUpper();
					strFAAIDNew = ($"{txtAirport[iFAAID_INDEX].Text} ").Trim().ToUpper();
					strCompIdNew = ($"{txtAirport[iCOMPID_INDEX].Text} ").Trim().ToUpper();

					strLatNew = ($"{txtAirport[iLAT_INDEX].Text} ").Trim();
					strLongNew = ($"{txtAirport[iLONG_INDEX].Text} ").Trim();

					strAPortName = ($"{txtAirport[iAPORTNAME_INDEX].Text} ").Trim();
					strAPortCity = ($"{txtAirport[iCITY_INDEX].Text} ").Trim();
					strAPortState = "";
					if (cbo_aport_state.Text != "")
					{
						strAPortState = ($"{cbo_aport_state.Text} ").Trim().Substring(0, Math.Min(cbo_aport_state.Text.IndexOf(" -- "), ($"{cbo_aport_state.Text} ").Trim().Length));
					}
					strAPortCountry = ($"{cbo_aport_country.Text} ").Trim();

					if (lblAirport[0].Text == "Airport Name*")
					{

						modMyAdmin.Record_EventAdmin("Mass Update", "Airport Code Start");

						if (UpdateAllAircraftAirports(lAPortId, strIATAOld, strICAOOld, strFAAIDOld, strIATANew, strICAONew, strFAAIDNew, strAPortName, strAPortCity, strAPortState, strAPortCountry, false))
						{
							Application.DoEvents();
						}


						modMyAdmin.Record_EventAdmin("Mass Update", "Airport Code Finish");

						grd_Airport[lRow, 0].Value = strIATANew;
						grd_Airport[lRow, 1].Value = strICAONew;
						grd_Airport[lRow, 2].Value = strFAAIDNew;
						grd_Airport[lRow, 3].Value = strAPortName;
						grd_Airport[lRow, 4].Value = strAPortCity;
						grd_Airport[lRow, 5].Value = strAPortState;
						grd_Airport[lRow, 6].Value = strAPortCountry;

						if (chk_aport_active_flag.CheckState == CheckState.Checked)
						{
							grd_Airport[lRow, 7].Value = "Y";
						}
						else
						{
							grd_Airport[lRow, 7].Value = "N";
						}

						grd_Airport.Refresh();

					} // If lblAirport(0).Caption = "Airport Name*" Then

					Format_Latitude_Longitude_Values_Decimal_Or_Dir_Degree_Minute_Second();

					strUpdate1 = $"UPDATE Airport SET aport_name = '{modAdminCommon.Fix_Quote(strAPortName)}', ";
					strUpdate1 = $"{strUpdate1}aport_iata_code = '{strIATANew}', aport_icao_code = '{strICAONew}', ";
					strUpdate1 = $"{strUpdate1}aport_faaid_code = '{strFAAIDNew}', aport_comp_id = '{strCompIdNew}', ";

					if (txtAirport[iCITY_INDEX].Text != "")
					{
						strUpdate1 = $"{strUpdate1}aport_city = '{modAdminCommon.Fix_Quote(strAPortCity)}', ";
					}
					else
					{
						strUpdate1 = $"{strUpdate1}aport_city = NULL, ";
					}

					if (strAPortState != "Not Found")
					{

						// 9-29-09 check for blank Tom
						if (strAPortState != "")
						{
							strUpdate1 = $"{strUpdate1}aport_state = '{strAPortState}', ";
						}
						else
						{
							strUpdate1 = $"{strUpdate1}aport_state = NULL, ";
						}

					} // If cbo_aport_state.Text <> "Not Found" Then

					if (strAPortCountry != "")
					{
						strUpdate1 = $"{strUpdate1}aport_country = '{modAdminCommon.Fix_Quote(strAPortCountry)}', ";
					}
					else
					{
						strUpdate1 = $"{strUpdate1}aport_country = NULL, ";
					}

					// 12/05/2011 - By David D. Cruger; Added

					strUpdate1 = $"{strUpdate1}aport_latitude_full = '{($"{txtAirport[4].Text} ").Trim()}', "; // Latitude Full

					if (($"{txtAirport[iLAT_INDEX].Text} ").Trim() != "")
					{
						strUpdate1 = $"{strUpdate1}aport_latitude_decimal = {($"{txtAirport[iLAT_INDEX].Text} ").Trim()}, "; // Decimal
					}
					else
					{
						strUpdate1 = $"{strUpdate1}aport_latitude_decimal = NULL, ";
					}

					strUpdate1 = $"{strUpdate1}aport_latitude_direction = '{($"{txtAirport[5].Text} ").Trim()}', "; // Direction

					if (($"{txtAirport[6].Text} ").Trim() != "")
					{
						strUpdate1 = $"{strUpdate1}aport_latitude_degrees = {($"{txtAirport[6].Text} ").Trim()}, "; // Degrees
					}
					else
					{
						strUpdate1 = $"{strUpdate1}aport_latitude_degrees = NULL, ";
					}

					if (($"{txtAirport[7].Text} ").Trim() != "")
					{
						strUpdate1 = $"{strUpdate1}aport_latitude_minutes = {($"{txtAirport[7].Text} ").Trim()}, "; // Minutes
					}
					else
					{
						strUpdate1 = $"{strUpdate1}aport_latitude_minutes = NULL, ";
					}

					if (($"{txtAirport[8].Text} ").Trim() != "")
					{
						strUpdate1 = $"{strUpdate1}aport_latitude_seconds = {($"{txtAirport[8].Text} ").Trim()}, "; // Seconds
					}
					else
					{
						strUpdate1 = $"{strUpdate1}aport_latitude_seconds = NULL, ";
					}

					// 12/05/2011 - By David D. Cruger; Added
					strUpdate1 = $"{strUpdate1}aport_longitude_full = '{($"{txtAirport[9].Text} ").Trim()}', "; // Longitude Full

					if (($"{txtAirport[iLONG_INDEX].Text} ").Trim() != "")
					{
						strUpdate1 = $"{strUpdate1}aport_longitude_decimal = {($"{txtAirport[iLONG_INDEX].Text} ").Trim()}, "; // Decimal
					}
					else
					{
						strUpdate1 = $"{strUpdate1}aport_longitude_decimal = NULL, ";
					}

					strUpdate1 = $"{strUpdate1}aport_longitude_direction = '{($"{txtAirport[10].Text} ").Trim()}', "; // Direction

					if (($"{txtAirport[11].Text} ").Trim() != "")
					{
						strUpdate1 = $"{strUpdate1}aport_longitude_degrees = {($"{txtAirport[11].Text} ").Trim()}, "; // Degrees
					}
					else
					{
						strUpdate1 = $"{strUpdate1}aport_longitude_degrees = NULL, ";
					}

					if (($"{txtAirport[12].Text} ").Trim() != "")
					{
						strUpdate1 = $"{strUpdate1}aport_longitude_minutes = {($"{txtAirport[12].Text} ").Trim()}, "; // Minutes
					}
					else
					{
						strUpdate1 = $"{strUpdate1}aport_longitude_minutes = NULL, ";
					}

					if (($"{txtAirport[13].Text} ").Trim() != "")
					{
						strUpdate1 = $"{strUpdate1}aport_longitude_seconds = {($"{txtAirport[13].Text} ").Trim()}, "; // Seconds
					}
					else
					{
						strUpdate1 = $"{strUpdate1}aport_longitude_seconds = NULL, ";
					}

					if (($"{txtAirport[14].Text} ").Trim() != "")
					{
						strUpdate1 = $"{strUpdate1}aport_max_runway_length = {($"{txtAirport[14].Text} ").Trim()}, "; // Max Runway Length
					}
					else
					{
						strUpdate1 = $"{strUpdate1}aport_max_runway_length = NULL, ";
					}

					// Default To Feet If Nothing Entered
					strUnit = ($"{txtAirport[15].Text} ").Trim().ToUpper();

					// Default To Feet If Nothing Entered
					if (($"{txtAirport[14].Text} ").Trim() != "" && (strUnit == "" || strUnit == "FT"))
					{
						txtAirport[15].Text = "Feet";
					}

					if (strUnit.StartsWith("MILE", StringComparison.Ordinal) || strUnit == "MI")
					{
						lFeet = modAdminCommon.Convert_Miles_To_Feet(Double.Parse($"{txtAirport[14].Text} "));
						txtAirport[14].Text = lFeet.ToString();
						txtAirport[15].Text = "Feet";
					}

					if (strUnit.StartsWith("METER", StringComparison.Ordinal) || strUnit == "MR")
					{
						lFeet = modAdminCommon.Convert_Meters_To_Feet(Double.Parse($"{txtAirport[14].Text} "));
						txtAirport[14].Text = lFeet.ToString();
						txtAirport[15].Text = "Feet";
					}

					if (strUnit.StartsWith("KILO", StringComparison.Ordinal) || strUnit == "KM")
					{
						lFeet = modAdminCommon.Convert_Kilo_Meters_To_Feet(Double.Parse($"{txtAirport[14].Text} "));
						txtAirport[14].Text = lFeet.ToString();
						txtAirport[15].Text = "Feet";
					}

					strUpdate1 = $"{strUpdate1}aport_max_runway_length_unit = '{($"{txtAirport[15].Text} ").Trim()}', "; // Unit

					// 9/24/2003 - RTW - STORE THE ACTIVE STATUS
					if (chk_aport_active_flag.CheckState == CheckState.Checked)
					{
						strUpdate1 = $"{strUpdate1}aport_active_flag = 'Y', ";
					}
					else
					{
						strUpdate1 = $"{strUpdate1}aport_active_flag = 'N', ";
					}

					strUpdate1 = $"{strUpdate1}aport_action_date = NULL WHERE (aport_id = {lAPortId.ToString()}) ";

					bTrans = true;
					UpgradeHelpers.DB.TransactionManager.Enlist(modAdminCommon.LOCAL_ADO_DB.BeginTransaction());
					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = strUpdate1;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();
					UpgradeHelpers.DB.TransactionManager.Commit(modAdminCommon.LOCAL_ADO_DB);
					bTrans = false;

					lblAirport[0].Text = "Airport Name";

					if (strIATAOld != strIATANew || strICAOOld != strICAONew || strFAAIDOld != strFAAIDNew || strLatOld != strLatNew || strLongOld != strLongNew)
					{

						Update_FAA_Flight_Data(lAPortId, strIATAOld, strICAOOld, strFAAIDOld, strIATANew, strICAONew, strFAAIDNew);

					}

					if (Airport_Active_Status == "Active" && chk_aport_active_flag.CheckState == CheckState.Unchecked)
					{
						modMyAdmin.Record_EventAdmin("Maintenance", $"Inactivated Airport {modAdminCommon.Fix_Quote(txtAirport[iAPORTNAME_INDEX].Text).Trim()}");
					}

					modAdminCommon.Record_Event("Airport", $"Airport Updated: [{strIATANew}]-[{strICAONew}]-[{strFAAIDNew}] - {strAPortName}", 0, 0, 0, false);

					lbl_Airport_Message[1].Text = $"Airport - {strAPortName} Has Been Updated";

				} // If lAPortId > 0 Then
			}
			catch (System.Exception excep)
			{

				strErrDesc = excep.Message;

				if (bTrans)
				{
					UpgradeHelpers.DB.TransactionManager.Rollback(modAdminCommon.LOCAL_ADO_DB);
				}

				modAdminCommon.Report_Error($"Airport_Update_Error: {strIATAOld}-{strICAOOld}-{strFAAIDOld} - {strErrDesc}");
				this.Cursor = CursorHelper.CursorDefault;
			}

		} // Airport_Update

		public void Airport_Delete()
		{

			int lRow = 0;
			int lAPortId = 0;
			string strIATAOld = "";
			string strICAOOld = "";
			string strFAAIDOld = "";

			string strIATANew = "";
			string strICAONew = "";
			string strFAAIDNew = "";

			string strAPortName = "";
			string strAPortCity = "";
			string strAPortState = "";
			string strAPortCountry = "";

			string strDelete1 = "";
			string strInsert1 = "";
			string strRowData = "";
			bool bTrans = false;
			string strErrDesc = "";

			try
			{

				lRow = grd_Airport.CurrentRowIndex;
				lAPortId = Convert.ToInt32(Double.Parse(lblAirport[18].Text));

				strIATAOld = ($"{Convert.ToString(grd_Airport[lRow, 0].Value)} ").Trim();
				strICAOOld = ($"{Convert.ToString(grd_Airport[lRow, 1].Value)} ").Trim();
				strFAAIDOld = ($"{Convert.ToString(grd_Airport[lRow, 2].Value)} ").Trim();

				grd_Airport.CurrentColumnIndex = 2;
				strFAAIDOld = ($"{grd_Airport[grd_Airport.CurrentRowIndex, grd_Airport.CurrentColumnIndex].FormattedValue.ToString()}").Trim();

				strIATANew = ($"{txtAirport[iIATA_INDEX].Text} ").Trim().ToUpper();
				strICAONew = ($"{txtAirport[iICAO_INDEX].Text} ").Trim().ToUpper();
				strFAAIDNew = ($"{txtAirport[iFAAID_INDEX].Text} ").Trim().ToUpper();

				strAPortName = ($"{txtAirport[iAPORTNAME_INDEX].Text} ").Trim();
				strAPortCity = ($"{txtAirport[iCITY_INDEX].Text} ").Trim();
				strAPortState = "";
				if (cbo_aport_state.Text.Trim() != "")
				{
					strAPortState = ($"{cbo_aport_state.Text} ").Trim().Substring(0, Math.Min(cbo_aport_state.Text.IndexOf(" -- "), ($"{cbo_aport_state.Text} ").Trim().Length));
				}
				strAPortCountry = ($"{cbo_aport_country.Text} ").Trim();

				modMyAdmin.Record_EventAdmin("Maintenance", $"Delete of Airport: {strIATAOld}-{strICAOOld}-{strFAAIDOld} {modAdminCommon.Fix_Quote(strAPortName)}");

				if (UpdateAllAircraftAirports(lAPortId, strIATAOld, strICAOOld, strFAAIDOld, strIATANew, strICAONew, strFAAIDNew, strAPortName, strAPortCity, strAPortState, strAPortCountry, true))
				{

					strDelete1 = $"DELETE FROM Airport  WHERE (aport_id = {lAPortId.ToString()}) ";

					bTrans = true;
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
					bTrans = false;

					if (Send_To_Evo(strDelete1))
					{
						Application.DoEvents();
					}

					strInsert1 = "INSERT INTO Delete_Log ( dlog_type, dlog_ac_id, dlog_journ_id, dlog_comp_id, ";
					strInsert1 = $"{strInsert1}dlog_contact_id, dlog_wanted_id, dlog_action_date, ";
					strInsert1 = $"{strInsert1}dlog_amod_id, dlog_entry_date,  dlog_entry_user";

					strInsert1 = $"{strInsert1}) VALUES ( 'Airport', ";
					strInsert1 = $"{strInsert1}{lAPortId.ToString()}, ";
					strInsert1 = $"{strInsert1}0, 0, 0, 0, ";
					strInsert1 = $"{strInsert1}NULL,  0, ";
					strInsert1 = $"{strInsert1}'{DateTime.Today.ToString("MM/dd/yyyy")}', ";
					strInsert1 = $"{strInsert1}'{modAdminCommon.gbl_User_ID}')";

					bTrans = true;
					UpgradeHelpers.DB.TransactionManager.Enlist(modAdminCommon.LOCAL_ADO_DB.BeginTransaction());
					DbCommand TempCommand_2 = null;
					TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
					TempCommand_2.CommandText = strInsert1;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand_2.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
					TempCommand_2.ExecuteNonQuery();
					UpgradeHelpers.DB.TransactionManager.Commit(modAdminCommon.LOCAL_ADO_DB);
					bTrans = false;

					grd_Airport.RemoveItem(lRow);
					grd_Airport.Refresh();

					lbl_Airport_Count.Text = $"Number of Airports: {(grd_Airport.RowsCount - 1).ToString()}";
					lbl_Airport_Count.Visible = true;
					if (chkAirportListOptions[APortACCounts].CheckState == CheckState.Checked)
					{
						txt_AirportColor.Visible = true;
					}

					Update_FAA_Flight_Data(lAPortId, strIATAOld, strICAOOld, strFAAIDOld, "", "", "");

					lbl_Airport_Message[1].Text = $"Airport - {strAPortName} Has Been Deleted";

					Application.DoEvents();

				}
				else
				{
					MessageBox.Show("Update Aircraft Airport Information Failed!!", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If UpdateAllAircraftAirports(strIATAOld, strICAOOld, strIATANew, strICAONew
			}
			catch (System.Exception excep)
			{

				strErrDesc = excep.Message;

				if (bTrans)
				{
					UpgradeHelpers.DB.TransactionManager.Rollback(modAdminCommon.LOCAL_ADO_DB);
				}

				modAdminCommon.Report_Error($"Airport_Delete_Error: {strIATAOld}-{strICAOOld} - {strErrDesc}");
				this.Cursor = CursorHelper.CursorDefault;
			}

		} // Airport_Delete


		public void Airport_Fill_List()
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			int APCount = 0; // Airport Count aey 9/24/04
			int ACCount = 0; // Aircraft Count
			object maincolor = null;
			int tempcolor = 0;
			int totairports = 0;
			string dupecheck_iata = "";
			string dupecheck_icao = "";
			bool bolFirstRun = false;
			int dupecheck_count = 0;
			int lAPortId = 0;
			string strIATA = "";
			string strICAO = "";
			string strFAAID = "";
			string strTemp = "";
			int lRow = 0;
			int lCol = 0;

			try
			{

				this.Cursor = Cursors.WaitCursor;
				lbl_Airport_Count.Visible = false;
				txt_AirportColor.Visible = false;

				lblAirport[0].Text = "Airport Name";
				this.Cursor = Cursors.WaitCursor;
				APCount = 0;
				ACCount = 0;
				StopIt = false;
				cmd_Refresh_Airports.Text = "&Stop";



				strQuery1 = "SELECT A1.*, ";

				if (chkAirportListOptions[APortACCounts].CheckState == CheckState.Checked)
				{
					strQuery1 = $"{strQuery1}(";
					strQuery1 = $"{strQuery1}SELECT COUNT(DISTINCT ac_id) FROM Aircraft WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1}WHERE (ac_journ_id = 0) ";
					strQuery1 = $"{strQuery1}AND (ac_aport_id = aport_id) ";
					strQuery1 = $"{strQuery1}) As ACCount, ";
				}
				else
				{
					strQuery1 = $"{strQuery1}0 As ACCount, ";
				}

				if (chkAirportListOptions[APortFAACounts].CheckState == CheckState.Checked)
				{
					strQuery1 = $"{strQuery1}(";
					strQuery1 = $"{strQuery1}SELECT COUNT(DISTINCT ffd_unique_flight_id) ";
					strQuery1 = $"{strQuery1}FROM FAA_Flight_Data WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1}WHERE (ffd_origin_aport_id = aport_id) ";
					strQuery1 = $"{strQuery1}OR (ffd_dest_aport_id = aport_id) ";
					strQuery1 = $"{strQuery1}) As FAACount ";
				}
				else
				{
					strQuery1 = $"{strQuery1}0 As FAACount ";
				}

				strQuery1 = $"{strQuery1}FROM Airport AS A1 WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (aport_id > 0) AND (aport_journ_id = 0) ";

				// Active Airports Only
				if (chkAirportListOptions[APortActiveOnly].CheckState == CheckState.Checked)
				{
					strQuery1 = $"{strQuery1}AND (aport_active_flag = 'Y') ";
				}

				// With Coordinate
				if (chkAirportListOptions[APortWCoord].CheckState == CheckState.Checked)
				{
					strQuery1 = $"{strQuery1}AND (aport_latitude_decimal IS NOT NULL) AND (aport_latitude_decimal <> 0) ";
					strQuery1 = $"{strQuery1}AND (aport_longitude_decimal IS NOT NULL) AND (aport_longitude_decimal <> 0) ";
				}

				// Without Coordinate
				if (chkAirportListOptions[APortWOCoord].CheckState == CheckState.Checked)
				{
					strQuery1 = $"{strQuery1}AND (aport_latitude_decimal IS NULL OR aport_latitude_decimal = 0) ";
					strQuery1 = $"{strQuery1}AND (aport_longitude_decimal IS NULL OR aport_longitude_decimal = 0) ";
				}

				// With Max Runway Length
				if (chkAirportListOptions[APortWRunway].CheckState == CheckState.Checked)
				{
					strQuery1 = $"{strQuery1}AND (aport_max_runway_length IS NOT NULL) AND (aport_max_runway_length <> 0) ";
					strQuery1 = $"{strQuery1}AND (aport_max_runway_length_unit IS NOT NULL)  AND (aport_max_runway_length_unit <> '') ";
				}

				// Without Max Runway Length
				if (chkAirportListOptions[APortWORunway].CheckState == CheckState.Checked)
				{
					strQuery1 = $"{strQuery1}AND (aport_max_runway_length IS NULL OR aport_max_runway_length = 0) ";
					strQuery1 = $"{strQuery1}AND (aport_max_runway_length_unit IS NULL OR aport_max_runway_length_unit = '') ";
				}

				// With FAA Flight Data
				if (chkAirportListOptions[APortWFlightData].CheckState == CheckState.Checked)
				{
					strQuery1 = $"{strQuery1}AND (EXISTS (SELECT NULL FROM FAA_Flight_Data WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1}             WHERE (ffd_origin_aport_id = aport_id) ";
					strQuery1 = $"{strQuery1}            ) ";
					strQuery1 = $"{strQuery1}     OR ";
					strQuery1 = $"{strQuery1}     EXISTS (SELECT NULL FROM FAA_Flight_Data WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1}             WHERE (ffd_dest_aport_id = aport_id) ";
					strQuery1 = $"{strQuery1}            ) ";
					strQuery1 = $"{strQuery1}    ) ";
				}

				txtGlobal.Text = txtGlobal.Text.Trim();
				if (txtGlobal.Text != "")
				{
					strQuery1 = $"{strQuery1}AND ( ";
					strQuery1 = $"{strQuery1}      aport_name LIKE '%{modAdminCommon.Fix_Quote(txtGlobal.Text)}%' ";
					strQuery1 = $"{strQuery1}   OR aport_iata_code LIKE '%{txtGlobal.Text}%' ";
					strQuery1 = $"{strQuery1}   OR aport_icao_code LIKE '%{txtGlobal.Text}%' ";
					strQuery1 = $"{strQuery1}   OR aport_faaid_code LIKE '%{txtGlobal.Text}%' ";
					strQuery1 = $"{strQuery1}   OR aport_city LIKE '%{txtGlobal.Text}%' ";
					strQuery1 = $"{strQuery1}   OR aport_country LIKE '%{txtGlobal.Text}%' ";
					if (Information.IsNumeric(txtGlobal.Text))
					{
						strQuery1 = $"{strQuery1}   OR aport_id = {txtGlobal.Text} ";
					}
					strQuery1 = $"{strQuery1}) ";
				}

				if (txtGlobal.Text == "")
				{
					if (cbo_Airport_Index.Text != "ALL")
					{
						if (cbo_Airport_Index.Text == "Blank")
						{
							strQuery1 = $"{strQuery1}AND (aport_name = '' OR aport_name IS NULL) ";
						}
						else
						{
							strQuery1 = $"{strQuery1}AND (aport_name LIKE '{modAdminCommon.Fix_Quote(cbo_Airport_Index.Text)}%') ";
						}
					}

					strIATA = cbo_iata_index.Text;
					if (Strings.Len(strIATA) >= 4)
					{
						modAdminCommon.SetComboBox(cbo_iata_index, "ALL");
						cbo_icao_index.Text = strIATA.Substring(0, Math.Min(4, strIATA.Length));
						strIATA = "All";
					}

					if (cbo_iata_index.Text != "ALL")
					{
						if (cbo_iata_index.Text == "BLANK")
						{
							strQuery1 = $"{strQuery1}AND (aport_iata_code = '' OR aport_iata_code IS NULL) ";
						}
						else
						{
							strQuery1 = $"{strQuery1}AND (aport_iata_code LIKE '{cbo_iata_index.Text}%') ";
						}
					}

					strICAO = cbo_icao_index.Text;
					if (cbo_icao_index.Text != "ALL")
					{
						if (cbo_icao_index.Text == "BLANK")
						{
							strQuery1 = $"{strQuery1}AND (aport_icao_code = '' OR aport_icao_code IS NULL) ";
						}
						else
						{
							strQuery1 = $"{strQuery1}AND (aport_icao_code LIKE '{cbo_icao_index.Text}%') ";
						}
					}

					// 08/11/2014 - By David D. Cruger; Added
					strFAAID = cbo_faaid_index.Text;
					if (cbo_faaid_index.Text != "ALL")
					{
						if (cbo_faaid_index.Text == "BLANK")
						{
							strQuery1 = $"{strQuery1}AND (aport_faaid_code = '' OR aport_faaid_code IS NULL) ";
						}
						else
						{
							strQuery1 = $"{strQuery1}AND (aport_faaid_code LIKE '{cbo_faaid_index.Text}%') ";
						}
					}

				} // If txtGlobal.Text = "" Then

				if (AirportSort.Trim() != "")
				{
					strQuery1 = $"{strQuery1}{AirportSort}";
				}
				else
				{
					strQuery1 = $"{strQuery1}ORDER BY aport_iata_code, aport_icao_code, aport_name ";
				}

				Airport_Clear_Input();

				grd_Airport.Clear();
				grd_Airport.Visible = false;

				grd_Airport.RowsCount = 1;
				grd_Airport.ColumnsCount = 10;

				lCol = -1;

				//grd_Airport.FixedRows = 1
				//grd_Airport.FixedCols = 0
				grd_Airport.CurrentRowIndex = 0;

				lCol++;
				grd_Airport.CurrentColumnIndex = lCol;
				grd_Airport.SetColumnWidth(lCol, 40); // IATA
				grd_Airport.CellBackColor = grd_Airport.BackColorFixed;
				grd_Airport[grd_Airport.CurrentRowIndex, grd_Airport.CurrentColumnIndex].Value = "IATA";

				lCol++;
				grd_Airport.CurrentColumnIndex = lCol;
				grd_Airport.SetColumnWidth(lCol, 40); // ICAO
				grd_Airport.CellBackColor = grd_Airport.BackColorFixed;
				grd_Airport[grd_Airport.CurrentRowIndex, grd_Airport.CurrentColumnIndex].Value = "ICAO";

				lCol++;
				grd_Airport.CurrentColumnIndex = lCol;
				grd_Airport.SetColumnWidth(lCol, 40); // FAAID
				grd_Airport.CellBackColor = grd_Airport.BackColorFixed;
				grd_Airport[grd_Airport.CurrentRowIndex, grd_Airport.CurrentColumnIndex].Value = "FAAID";

				lCol++;
				grd_Airport.CurrentColumnIndex = lCol;
				grd_Airport.SetColumnWidth(lCol, 200); // Airport Name
				grd_Airport.CellBackColor = grd_Airport.BackColorFixed;
				grd_Airport[grd_Airport.CurrentRowIndex, grd_Airport.CurrentColumnIndex].Value = "Airport Name";

				lCol++;
				grd_Airport.CurrentColumnIndex = lCol;
				grd_Airport[grd_Airport.CurrentRowIndex, grd_Airport.CurrentColumnIndex].Value = "City";
				grd_Airport.SetColumnWidth(lCol, 67); // City
				grd_Airport.CellBackColor = grd_Airport.BackColorFixed;

				lCol++;
				grd_Airport.CurrentColumnIndex = lCol;
				grd_Airport[grd_Airport.CurrentRowIndex, grd_Airport.CurrentColumnIndex].Value = "State";
				grd_Airport.CellBackColor = grd_Airport.BackColorFixed;
				grd_Airport.SetColumnWidth(lCol, 33); // State

				lCol++;
				grd_Airport.CurrentColumnIndex = lCol;
				grd_Airport[grd_Airport.CurrentRowIndex, grd_Airport.CurrentColumnIndex].Value = "Country";
				grd_Airport.CellBackColor = grd_Airport.BackColorFixed;
				grd_Airport.SetColumnWidth(lCol, 67); // Country

				lCol++;
				grd_Airport.CurrentColumnIndex = lCol;
				grd_Airport.SetColumnWidth(lCol, 0); // Active

				// new column for aircraft counts 9/24/04 aey
				lCol++;
				grd_Airport.CurrentColumnIndex = lCol;
				grd_Airport[grd_Airport.CurrentRowIndex, grd_Airport.CurrentColumnIndex].Value = "A/C Count";
				grd_Airport.CellBackColor = grd_Airport.BackColorFixed;
				if (chkAirportListOptions[APortACCounts].CheckState == CheckState.Checked)
				{
					grd_Airport.SetColumnWidth(lCol, 60); // A/C Count
				}
				else
				{
					grd_Airport.SetColumnWidth(lCol, 0); // A/C Count
				}

				lCol++;
				grd_Airport.CurrentColumnIndex = lCol;
				grd_Airport[grd_Airport.CurrentRowIndex, grd_Airport.CurrentColumnIndex].Value = "FAA Count";
				grd_Airport.CellBackColor = grd_Airport.BackColorFixed;
				if (chkAirportListOptions[APortFAACounts].CheckState == CheckState.Checked)
				{
					grd_Airport.SetColumnWidth(lCol, 60); // FAA Flight Data Count
				}
				else
				{
					grd_Airport.SetColumnWidth(lCol, 0); // A/C Counts
				}

				lbl_Airport_Message[1].Text = "Loading Airport List. Please Wait ...";
				Application.DoEvents();

				grd_Airport.Enabled = false;
				//'''''''''''''''''''''''''''''''''''''''''''''''''''
				// Testing Variables to fix dupes remove when done
				// set tempcolor to ConfirmColor when dupe condition is met
				//'''''''''''''''''''''''''''''''''''''''''''''''''''

				dupecheck_count = 0;
				dupecheck_iata = "";
				dupecheck_icao = "";
				bolFirstRun = false;

				UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(modAdminCommon.LOCAL_ADO_DB, 600);
				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if ((!rstRec1.BOF) && (!rstRec1.EOF))
				{

					rstRec1.MoveLast();
					totairports = rstRec1.RecordCount;
					rstRec1.MoveFirst();

					do 
					{ // Loop Until snp_Airport.EOF = True Or StopIt = True

						grd_Airport.RowsCount++;
						grd_Airport.CurrentRowIndex++;

						APCount++;

						maincolor = 0xFFFFFF;
						//UPGRADE_WARNING: (1068) maincolor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						tempcolor = Convert.ToInt32(maincolor);

						if (($"{Convert.ToString(rstRec1["aport_active_flag"])} ").Trim() != "Y")
						{
							tempcolor = 0xC0C0FF;
						}

						// Count
						if (chkAirportListOptions[APortACCounts].CheckState == CheckState.Checked)
						{
							if (Convert.ToDouble(rstRec1["ACCount"]) == 0)
							{
								tempcolor = 0xFFC0C0;
							}
						}

						// Without Coordinate
						if (chkAirportListOptions[APortWOCoord].CheckState == CheckState.Checked)
						{
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(rstRec1["aport_latitude_full"]) && !Convert.IsDBNull(rstRec1["aport_longitude_full"]))
							{
								if (($"{Convert.ToString(rstRec1["aport_latitude_full"])} ").Trim() != "" && ($"{Convert.ToString(rstRec1["aport_longitude_full"])} ").Trim() != "")
								{
									tempcolor = 0xFFFF;
								}
							}
						}

						if (!bolFirstRun)
						{
							bolFirstRun = true;
							dupecheck_iata = ($"{Convert.ToString(rstRec1["aport_iata_code"])} ").Trim();
							dupecheck_icao = ($"{Convert.ToString(rstRec1["aport_icao_code"])} ").Trim();
						}
						else if (dupecheck_iata == ($"{Convert.ToString(rstRec1["aport_iata_code"])} ").Trim() && ($"{Convert.ToString(rstRec1["aport_iata_code"])} ").Trim() != "")
						{ 
							tempcolor = Convert.ToInt32(Double.Parse(modAdminCommon.ConfirmColor));
							dupecheck_count++;
						}
						else if (dupecheck_icao == ($"{Convert.ToString(rstRec1["aport_icao_code"])} ").Trim() && ($"{Convert.ToString(rstRec1["aport_icao_code"])} ").Trim() != "")
						{ 
							tempcolor = Convert.ToInt32(Double.Parse(modAdminCommon.ConfirmColor));
							dupecheck_count++;
						}
						else
						{
							dupecheck_iata = ($"{Convert.ToString(rstRec1["aport_iata_code"])} ").Trim();
							dupecheck_icao = ($"{Convert.ToString(rstRec1["aport_icao_code"])} ").Trim();
						}

						// PUT THE IATA CODE IN THE GRID
						lCol = -1;

						lCol++;
						grd_Airport.CurrentColumnIndex = lCol;
						grd_Airport[grd_Airport.CurrentRowIndex, grd_Airport.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["aport_iata_code"])} ").Trim();
						//UPGRADE_WARNING: (1068) maincolor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						grd_Airport.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(maincolor));
						grd_Airport.CellAlignment = DataGridViewContentAlignment.TopLeft;
						//grd_Airport.BackColor = ConfirmColor

						// PUT THE ICAO CODE IN THE GRID
						lCol++;
						grd_Airport.CurrentColumnIndex = lCol;
						grd_Airport[grd_Airport.CurrentRowIndex, grd_Airport.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["aport_icao_code"])} ").Trim();
						//UPGRADE_WARNING: (1068) maincolor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						grd_Airport.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(maincolor));
						grd_Airport.CellAlignment = DataGridViewContentAlignment.TopLeft;

						// PUT THE FAAID CODE IN THE GRID
						lCol++;
						grd_Airport.CurrentColumnIndex = lCol;
						grd_Airport[grd_Airport.CurrentRowIndex, grd_Airport.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["aport_faaid_code"])} ").Trim();
						//UPGRADE_WARNING: (1068) maincolor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						grd_Airport.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(maincolor));
						grd_Airport.CellAlignment = DataGridViewContentAlignment.TopLeft;

						// PUT THE AIRPORT NAME IN THE GRID
						lCol++;
						grd_Airport.CurrentColumnIndex = lCol;
						grd_Airport[grd_Airport.CurrentRowIndex, grd_Airport.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["aport_name"])} ").Trim();
						grd_Airport.CellBackColor = ColorTranslator.FromOle(tempcolor);
						grd_Airport.CellAlignment = DataGridViewContentAlignment.TopLeft;

						lCol++;
						grd_Airport.CurrentColumnIndex = lCol;
						grd_Airport[grd_Airport.CurrentRowIndex, grd_Airport.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["aport_city"])}").Trim();
						//UPGRADE_WARNING: (1068) maincolor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						grd_Airport.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(maincolor));
						grd_Airport.CellAlignment = DataGridViewContentAlignment.TopLeft;

						lCol++;
						grd_Airport.CurrentColumnIndex = lCol;
						grd_Airport[grd_Airport.CurrentRowIndex, grd_Airport.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["aport_state"])}").Trim();
						//UPGRADE_WARNING: (1068) maincolor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						grd_Airport.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(maincolor));
						grd_Airport.CellAlignment = DataGridViewContentAlignment.TopCenter;

						lCol++;
						grd_Airport.CurrentColumnIndex = lCol;
						grd_Airport[grd_Airport.CurrentRowIndex, grd_Airport.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["aport_country"])}").Trim();
						//UPGRADE_WARNING: (1068) maincolor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						grd_Airport.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(maincolor));
						grd_Airport.CellAlignment = DataGridViewContentAlignment.TopLeft;

						lCol++;
						grd_Airport.CurrentColumnIndex = lCol;
						grd_Airport[grd_Airport.CurrentRowIndex, grd_Airport.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["aport_active_flag"])}").Trim();
						//UPGRADE_WARNING: (1068) maincolor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						grd_Airport.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(maincolor));
						grd_Airport.CellAlignment = DataGridViewContentAlignment.TopCenter;

						lCol++;
						if (chkAirportListOptions[APortACCounts].CheckState == CheckState.Checked)
						{
							grd_Airport.CurrentColumnIndex = lCol;
							grd_Airport[grd_Airport.CurrentRowIndex, grd_Airport.CurrentColumnIndex].Value = StringsHelper.Format(rstRec1["ACCount"], "#,###");
							grd_Airport.CellAlignment = DataGridViewContentAlignment.TopRight;
							ACCount = Convert.ToInt32(ACCount + Convert.ToDouble(rstRec1["ACCount"]));
						}

						lCol++;
						if (chkAirportListOptions[APortFAACounts].CheckState == CheckState.Checked)
						{
							grd_Airport.CurrentColumnIndex = lCol;
							grd_Airport[grd_Airport.CurrentRowIndex, grd_Airport.CurrentColumnIndex].Value = StringsHelper.Format(rstRec1["FAACount"], "#,###");
							grd_Airport.CellAlignment = DataGridViewContentAlignment.TopRight;
						}

						grd_Airport.set_RowData(grd_Airport.CurrentRowIndex, Convert.ToInt32(rstRec1.GetField("aport_id")));
						lbl_Airport_Message[1].Text = $"Loading Airport List Record {grd_Airport.CurrentRowIndex.ToString()} of {totairports.ToString()}. Please Wait ...";

						rstRec1.MoveNext();
						Application.DoEvents();

					}
					while(!(rstRec1.EOF || StopIt));

					if (grd_Airport.RowsCount >= 2)
					{
						grd_Airport.FixedRows = 1;
					}

					StopIt = false;
					cmd_Refresh_Airports.Text = "&Refresh";
					lbl_Airport_Count.Visible = true;
					if (ACCount > 0)
					{
						txt_AirportColor.Visible = true;
					}

					lbl_Airport_Count.Text = $"Airports Listed: ({StringsHelper.Format(grd_Airport.RowsCount - 1, "#,##0")})";
					lbl_Airport_Message[1].Text = "Airports Listed. Click on Heading to Re-Sort. Double-Click to Select.";

				}
				else
				{
					grd_Airport.CurrentColumnIndex = 2;
					grd_Airport.CurrentRowIndex = 0;
					grd_Airport[grd_Airport.CurrentRowIndex, grd_Airport.CurrentColumnIndex].Value = "No Airports for the Selected Criteria.";
					lbl_Airport_Message[1].Text = "No Airports Selected.";
					Application.DoEvents();
				} // If (snp_Airport.BOF = False) And (snp_Airport.EOF = False) Then

				rstRec1.Close();

				grd_Airport.Visible = true;
				grd_Airport.Enabled = true;

				if (totairports == 1)
				{
					grd_Airport.CurrentRowIndex = 1;
					Airport_Select();
					grd_Airport.CurrentColumnIndex = 0;
					grd_Airport.ColSel = grd_Airport.ColumnsCount - 1;
				}

				Application.DoEvents();

				rstRec1 = null;

				this.Cursor = CursorHelper.CursorDefault;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"Airport_Fill_List_Error: {excep.Message}");

				this.Cursor = CursorHelper.CursorDefault;
				grd_Airport.Visible = true;
				grd_Airport.Enabled = true;
			}

		} // Airport_Fill_List_Error

		public void Fill_State(ComboBox inCbo, string inState = "", string InCountry = "")
		{
			// fill combobox for state selection

			ADORecordSetHelper snp_State = new ADORecordSetHelper();
			string Query = "";
			int I = 0;
			int RememberI = 0;

			try
			{

				inCbo.AddItem("");

				Query = "SELECT * FROM State ";

				if (InCountry.Trim() != "")
				{
					Query = $"{Query} WHERE state_country = '{modAdminCommon.Fix_Quote(InCountry).Trim()}' ";
				}

				Query = $"{Query} ORDER BY State_name ";

				//Set snp_State = LOCAL_DB.OpenRecordset(QUERY, dbOpenSnapshot)
				snp_State.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

				if (!snp_State.BOF && !snp_State.EOF)
				{

					inCbo.Enabled = false;
					inCbo.Items.Clear();
					inCbo.SelectedIndex = -1;
					inCbo.AddItem("");
					I = 0;

					do 
					{ // Loop Until snp_State.EOF=True

						I++;
						inCbo.AddItem($"{(($"{Convert.ToString(snp_State["State_code"])} ").Trim())} -- {(($"{Convert.ToString(snp_State["State_name"])} ").Trim())}");

						if ($"{($"{Convert.ToString(snp_State["State_code"])} ").Trim()} -- {($"{Convert.ToString(snp_State["State_name"])} ").Trim()}" == inState)
						{
							RememberI = I;
						}

						snp_State.MoveNext();

					}
					while(!snp_State.EOF);

					if (RememberI >= 0)
					{
						inCbo.SelectedIndex = RememberI;
					}

					inCbo.Enabled = true;

				} // If (snp_State.BOF = False And snp_State.EOF = False) Then

				snp_State.Close();
				snp_State = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"Fill_State_Error: {excep.Message}");
			}

		}

		private void Fill_Airport_Index()
		{



			Application.DoEvents();
			cbo_Airport_Index.Items.Clear();
			cbo_Airport_Index.AddItem("ALL");
			cbo_Airport_Index.AddItem("BLANK");
			cbo_Airport_Index.AddItem("A");
			cbo_Airport_Index.AddItem("B");
			cbo_Airport_Index.AddItem("C");
			cbo_Airport_Index.AddItem("D");
			cbo_Airport_Index.AddItem("E");
			cbo_Airport_Index.AddItem("F");
			cbo_Airport_Index.AddItem("G");
			cbo_Airport_Index.AddItem("H");
			cbo_Airport_Index.AddItem("I");
			cbo_Airport_Index.AddItem("J");
			cbo_Airport_Index.AddItem("K");
			cbo_Airport_Index.AddItem("L");
			cbo_Airport_Index.AddItem("M");
			cbo_Airport_Index.AddItem("N");
			cbo_Airport_Index.AddItem("O");
			cbo_Airport_Index.AddItem("P");
			cbo_Airport_Index.AddItem("Q");
			cbo_Airport_Index.AddItem("R");
			cbo_Airport_Index.AddItem("S");
			cbo_Airport_Index.AddItem("T");
			cbo_Airport_Index.AddItem("U");
			cbo_Airport_Index.AddItem("V");
			cbo_Airport_Index.AddItem("W");
			cbo_Airport_Index.AddItem("X");
			cbo_Airport_Index.AddItem("Y");
			cbo_Airport_Index.AddItem("Z");
			cbo_Airport_Index.AddItem("0");
			cbo_Airport_Index.AddItem("1");
			cbo_Airport_Index.AddItem("2");
			cbo_Airport_Index.AddItem("3");
			cbo_Airport_Index.AddItem("4");
			cbo_Airport_Index.AddItem("5");
			cbo_Airport_Index.AddItem("6");
			cbo_Airport_Index.AddItem("7");
			cbo_Airport_Index.AddItem("8");
			cbo_Airport_Index.AddItem("9");

			cbo_iata_index.Items.Clear();
			cbo_icao_index.Items.Clear();
			cbo_faaid_index.Items.Clear();

			int tempForEndVar = cbo_Airport_Index.Items.Count - 1;
			for (int iCnt1 = 0; iCnt1 <= tempForEndVar; iCnt1++)
			{
				cbo_iata_index.AddItem(cbo_Airport_Index.GetListItem(iCnt1));
				cbo_icao_index.AddItem(cbo_Airport_Index.GetListItem(iCnt1));
				cbo_faaid_index.AddItem(cbo_Airport_Index.GetListItem(iCnt1));
			}

			cbo_Airport_Index.SelectedIndex = 0;

			cbo_iata_index.SelectedIndex = 2;
			cbo_icao_index.SelectedIndex = 0;
			cbo_faaid_index.SelectedIndex = 0;

			Application.DoEvents();

		}

		private bool Check_for_Aircraft_Lock(string inFeature)
		{
			bool result = false;
			try
			{
				ADORecordSetHelper ado_LockCheck = new ADORecordSetHelper();
				result = false;
				string Query = "";

				Query = "SELECT count(*) as KeyCount FROM Aircraft_Lock,Aircraft,Aircraft_Key_Feature ";
				Query = $"{Query}WHERE ac_journ_id = 0  and ac_id = alock_ac_id and ac_journ_id = alock_journ_id ";
				Query = $"{Query}and ac_id = afeat_ac_id and ac_journ_id = afeat_journ_id  and afeat_feature_code = '{inFeature.Trim()}' ";
				ado_LockCheck.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
				if (!(ado_LockCheck.BOF && ado_LockCheck.EOF))
				{
					if (Convert.ToDouble(ado_LockCheck["KeyCount"]) > 0)
					{
						result = true;
					}
				}
			}
			catch
			{
				result = false;
			}
			return result;
		}

		private void Key_Feature_Mass_Update()
		{

			ADORecordSetHelper ado_FeatureCheck = default(ADORecordSetHelper);
			ADORecordSetHelper ado_feature = default(ADORecordSetHelper);
			try
			{
				this.Cursor = Cursors.WaitCursor;
				bool Changed_AutoFlag = false; // FLAG INDICATING IF THE USER JUST SET THE AUTO FLAG FOR THE FETURE CODE
				string RuleStatus = ""; // USED TO IDENTIFY THE RESULTS OF TRYING TO APPLY RULES
				int StartSerNo = 0;
				int EndSerNo = 0;
				int CurrentModel = 0;
				int CurrentSerNo = 0;
				int AircraftCount = 0;
				int TotalAircraft = 0;
				bool StandardEquipment = false;
				string RuleString = "";
				ADORecordSetHelper ado_ModelFeature = new ADORecordSetHelper();
				ADORecordSetHelper ado_Aircraft_Info = new ADORecordSetHelper();
				ado_FeatureCheck = new ADORecordSetHelper();
				ADORecordSetHelper ado_FeatureCheck3 = new ADORecordSetHelper();
				string Query = "";
				ado_feature = new ADORecordSetHelper();
				ADORecordSetHelper ado_FeatureCheck2 = new ADORecordSetHelper();
				StringBuilder ac_to_update_list = new StringBuilder();
				string Query2 = "";
				int count_Array = 0;
				string[] temp_array = null;
				StringBuilder amod_id_list = new StringBuilder();
				string last_amod_id = "";
				string delete_query = "";
				StringBuilder insert_query = new StringBuilder();
				bool is_now_not_model_dependant = false;
				string old_query = "";
				string new_query = "";
				old_query = "";
				new_query = "";

				bool did_some_magic = false;
				did_some_magic = false;

				int insert_count = 0;
				insert_count = 0;

				modAdminCommon.ADO_Transaction("BeginTrans");

				Query = $"Select * from Key_Feature where kfeat_code='{txt_kfeat_code.Text.Trim()}' ";
				ado_feature.Open(Query, modAdminCommon.ADODB_Trans_conn, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);
				if (!(ado_feature.BOF && ado_feature.EOF))
				{

					// UPDATE THE KEY FEATURE NAME
					ado_feature["kfeat_name"] = modAdminCommon.Fix_Quote(txt_kfeat_name).Trim();

					// UPDATE THE KEY FEATURE DESCRIPTION
					ado_feature["kfeat_description"] = modAdminCommon.Fix_Quote(txt_kfeat_description).Trim();

					// UPDATE KEY FEATURE RESEARCH NOTES
					ado_feature["kfeat_research_notes"] = modAdminCommon.Fix_Quote(txt_kfeat_research_notes).Trim();

					// UPDATE KEY FEATURE HOW TO FORMAT
					ado_feature["kfeat_howtoformat"] = modAdminCommon.Fix_Quote(txt_kfeat_howtoformat).Trim();

					// UPDATE KEY FEATURE AUTO RULE FLAG AND RULE QUERY
					Changed_AutoFlag = chk_AutoGen.CheckState == CheckState.Checked && Convert.ToString(ado_feature["kfeat_auto_generate_flag"]) == "N";
					if (chk_AutoGen.CheckState == CheckState.Checked)
					{
						ado_feature["kfeat_auto_generate_flag"] = "Y";
					}
					else
					{
						ado_feature["kfeat_auto_generate_flag"] = "N";
					}

					if (chk_product_flags[0].CheckState == CheckState.Checked)
					{
						ado_feature["kfeat_product_business_flag"] = "Y";
					}
					else
					{
						ado_feature["kfeat_product_business_flag"] = "N";
					}

					if (chk_product_flags[1].CheckState == CheckState.Checked)
					{
						ado_feature["kfeat_product_commercial_flag"] = "Y";
					}
					else
					{
						ado_feature["kfeat_product_commercial_flag"] = "N";
					}

					if (chk_product_flags[2].CheckState == CheckState.Checked)
					{
						ado_feature["kfeat_product_helicopter_flag"] = "Y";
					}
					else
					{
						ado_feature["kfeat_product_helicopter_flag"] = "N";
					}

					if (chk_product_flags[3].CheckState == CheckState.Checked)
					{
						ado_feature["kfeat_model_dependent_flag"] = "Y";
					}
					else
					{
						ado_feature["kfeat_model_dependent_flag"] = "N";
					}

					ado_feature["kfeat_area"] = modAdminCommon.DeleteCarriageReturnsAndExtraSpaces(cbo_feat_area.Text);

					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					if (!Convert.IsDBNull(ado_feature["kfeat_query"]))
					{
						old_query = Convert.ToString(ado_feature["kfeat_query"]);
					}
					// UPDATE KEY FEATURE QUERY
					ado_feature["kfeat_query"] = modAdminCommon.DeleteCarriageReturnsAndExtraSpaces(txt_kfeat_query.Text);
					new_query = Convert.ToString(ado_feature["kfeat_query"]);

					// UPDATE KEY FEATURE DO NOT CLEAR FLAG
					if (chk_kfeat_donotclear.CheckState == CheckState.Checked)
					{
						ado_feature["kfeat_donotclear"] = "Y";
					}
					else
					{
						ado_feature["kfeat_donotclear"] = "N";
					}

					// UPDATE KEY FEATURE HOW TO FORMAT
					ado_feature["kfeat_wheretoenter"] = modAdminCommon.Fix_Quote(txt_kfeat_wheretoenter).Trim();

					if (chk_Inactive_Feature_Code.CheckState == CheckState.Checked && KeyFeatureWasActive)
					{
						did_some_magic = true;
						// SET THE INACTIVE DATE
						ado_feature["kfeat_inactive_date"] = DateTime.Now.ToString("d");


						ac_to_update_list = new StringBuilder("");


						Query2 = $" select distinct afeat_ac_id from Aircraft_Key_Feature WHERE afeat_feature_code = '{modAdminCommon.Fix_Quote(txt_kfeat_code)}' AND afeat_journ_id = 0 ";

						ado_FeatureCheck2.CursorLocation = CursorLocationEnum.adUseClient;
						ado_FeatureCheck2.Open(Query2, modAdminCommon.ADODB_Trans_conn, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

						if (!(ado_FeatureCheck2.BOF && ado_FeatureCheck2.EOF))
						{
							// FOUND FEATURE CODES FOR THIS MODEL TO UPDATE

							while(!ado_FeatureCheck2.EOF)
							{
								if (ac_to_update_list.ToString().Trim() != "")
								{
									ac_to_update_list.Append(", ");
								}
								ac_to_update_list.Append(Convert.ToString(ado_FeatureCheck2["afeat_ac_id"]));

								ado_FeatureCheck2.MoveNext();
							};
						}
						else
						{
						}


						// UPDATE ALL AIRCRAFT KEY MODEL FEATURES TO BE INACTIVE
						Query = $"update Aircraft_Key_Feature set afeat_inactive_date = '{DateTime.Parse(modAdminCommon.DateToday).ToString("d")}' ";
						Query = $"{Query}WHERE afeat_feature_code = '{modAdminCommon.Fix_Quote(txt_kfeat_code)}' AND afeat_journ_id <> 0 ";
						DbCommand TempCommand = null;
						TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
						TempCommand.CommandText = Query;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'ADODB.ExecuteOptionEnum' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
						TempCommand.ExecuteNonQuery();

						// DELETE ALL AIRCRAFT KEY FEATURES IF NO LONGER VALID
						Query = $"DELETE FROM Aircraft_Key_Feature WHERE afeat_feature_code = '{modAdminCommon.Fix_Quote(txt_kfeat_code)}' ";
						Query = $"{Query}AND afeat_journ_id = 0";
						DbCommand TempCommand_2 = null;
						TempCommand_2 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
						TempCommand_2.CommandText = Query;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'ADODB.ExecuteOptionEnum' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand_2.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
						TempCommand_2.ExecuteNonQuery();

						// DELETE ALL AIRCRAFT MODEL KEY FEATURES IF NO LONGER VALID
						Query = $"Update Aircraft_Model_Key_Feature set amfeat_inactive_date  =  '{DateTime.Parse(modAdminCommon.DateToday).ToString("d")}' where amfeat_feature_code = '{modAdminCommon.Fix_Quote(txt_kfeat_code)}' ";
						DbCommand TempCommand_3 = null;
						TempCommand_3 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_3);
						TempCommand_3.CommandText = Query;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'ADODB.ExecuteOptionEnum' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand_3.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_3);
						TempCommand_3.ExecuteNonQuery();

						modAdminCommon.Table_Action_Log("Aircraft_Model_Key_Feature");

						if (ac_to_update_list.ToString().Trim() != "")
						{
							Query = $"Update Aircraft set ac_action_date = NULL where ac_journ_id = 0 and ac_id in ({ac_to_update_list.ToString().Trim()}) ";
							DbCommand TempCommand_4 = null;
							TempCommand_4 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_4);
							TempCommand_4.CommandText = Query;
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'ADODB.ExecuteOptionEnum' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
							TempCommand_4.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_4);
							TempCommand_4.ExecuteNonQuery();

							// insert into the delete log for the ones that were deleted
							temp_array = ac_to_update_list.ToString().Split(',');
							foreach (string temp_array_item in temp_array)
							{
								Record_Delete_Log_Entry("Key_Feature", Convert.ToInt32(Double.Parse(temp_array_item)), 0, 0, 0, modAdminCommon.Fix_Quote(txt_kfeat_code));
							}

						}

					}
					else if (chk_Inactive_Feature_Code.CheckState == CheckState.Unchecked)
					{ 
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						ado_feature["kfeat_inactive_date"] = DBNull.Value;
					}

					ado_feature.Update();
				} // ADD NEW AIRCRAFT MODEL FEATURE CODE


				//if it has now become model dependant then
				is_now_not_model_dependant = false;
				if (was_model_dependant)
				{ // if ti was model dependant checked yes
					if (chk_product_flags[3].CheckState == CheckState.Unchecked)
					{ // and now its not model dependant
						is_now_not_model_dependant = true; //  then we may need to run
					}
				}



				// IF THE AUTOGENERATE FLAG WAS SET THEN GO GET THE AIRCRAFT KEY
				// FEATURE RECORDS TO PROCESS
				if (Changed_AutoFlag || (is_now_not_model_dependant && chk_AutoGen.CheckState == CheckState.Checked))
				{
					did_some_magic = true;
					AircraftCount = 0;
					TotalAircraft = 0;
					// SELECT A LIST OF AIRCRAFT KEY FEATURES TO UPDATE
					Query = "select * from Aircraft_Key_Feature inner join aircraft with (NOLOCK) on ac_id = afeat_ac_id and ac_journ_id = afeat_journ_id ";
					Query = $"{Query} inner join Aircraft_Model_Key_Feature on amfeat_feature_code = afeat_feature_code and amfeat_amod_id = ac_amod_id  ";
					Query = $"{Query}where afeat_journ_id = 0 and afeat_feature_code='{txt_kfeat_code.Text.Trim()}' ";
					Query = $"{Query} order by ac_amod_id asc ";

					ado_FeatureCheck.CursorLocation = CursorLocationEnum.adUseClient;
					ado_FeatureCheck.Open(Query, modAdminCommon.ADODB_Trans_conn, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);
					amod_id_list = new StringBuilder("");
					if (!(ado_FeatureCheck.BOF && ado_FeatureCheck.EOF))
					{
						TotalAircraft = ado_FeatureCheck.RecordCount;
						// FOUND FEATURE CODES FOR THIS MODEL TO UPDATE

						while(!ado_FeatureCheck.EOF)
						{
							AircraftCount++;
							modStatusBar.Update_Status_Bar(modAdminCommon.SB, $"Processing Aircraft {AircraftCount.ToString()} of {TotalAircraft.ToString()}. Updating Feature Code '{txt_kfeat_code.Text.Trim()}' On ACID = {Convert.ToString(ado_FeatureCheck["afeat_ac_id"])}", Color.Blue);

							//
							if ((Convert.ToString(ado_FeatureCheck["ac_amod_id"]).Trim() != last_amod_id.Trim()) || last_amod_id == "")
							{
								if (amod_id_list.ToString().Trim() != "")
								{
									amod_id_list.Append(", ");
								}
								amod_id_list.Append(Convert.ToString(ado_FeatureCheck["ac_amod_id"]).Trim());
							}
							last_amod_id = Convert.ToString(ado_FeatureCheck["ac_amod_id"]).Trim();



							// GET AIRCRAFT INFO
							Query = "Select ac_amod_id, ac_ser_no_value from Aircraft ";
							Query = $"{Query}where ac_id = {Convert.ToString(ado_FeatureCheck["afeat_ac_id"])} and ac_journ_id = 0";
							ado_Aircraft_Info.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);
							if (!(ado_Aircraft_Info.BOF && ado_Aircraft_Info.EOF))
							{
								CurrentModel = Convert.ToInt32(Conversion.Val($"{Convert.ToString(ado_Aircraft_Info["ac_amod_id"])}"));
								CurrentSerNo = Convert.ToInt32(Conversion.Val($"{Convert.ToString(ado_Aircraft_Info["ac_ser_no_value"])}"));
							}
							if (ado_Aircraft_Info != null)
							{
								if (ado_Aircraft_Info.State == ConnectionState.Open)
								{ // Already Open Close It
									ado_Aircraft_Info.Close();
								}
								ado_Aircraft_Info = null;
							}

							// IF THIS IS STANDARD EQUIPMENT, THEN SET THE FEATURE CODE TO "Y"
							Query = $"Select * from Aircraft_Model_Key_Feature where amfeat_feature_code='{txt_kfeat_code.Text.Trim()}' ";
							Query = $"{Query}and amfeat_amod_id = {CurrentModel.ToString()}";
							ado_ModelFeature.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);
							if (!(ado_ModelFeature.BOF && ado_ModelFeature.EOF))
							{
								if (($"{Convert.ToString(ado_ModelFeature["amfeat_standard_equip"])}").Trim().ToUpper() == "Y")
								{
									StandardEquipment = true;

									if (Strings.Len(Conversion.Val($"{Convert.ToString(ado_ModelFeature["amfeat_stdeq_start_ser_no_value"])}").ToString().Trim()) > 0)
									{
										StartSerNo = Convert.ToInt32(Conversion.Val($"{Convert.ToString(ado_ModelFeature["amfeat_stdeq_start_ser_no_value"])}"));
									}
									else
									{
										StartSerNo = 0;
									}

									if (Strings.Len(Conversion.Val($"{Convert.ToString(ado_ModelFeature["amfeat_stdeq_end_ser_no_value"])}").ToString().Trim()) > 0)
									{
										EndSerNo = Convert.ToInt32(Conversion.Val($"{Convert.ToString(ado_ModelFeature["amfeat_stdeq_end_ser_no_value"])}"));
									}
									else
									{
										EndSerNo = 0;
									}

									// CHECK IF THE SERIAL NUMBER IS WITHIN RANGE
									if (StartSerNo > 0 && CurrentSerNo < StartSerNo)
									{
										StandardEquipment = false;
									}
									if (EndSerNo > 0 && CurrentSerNo > EndSerNo)
									{
										StandardEquipment = false;
									}
								}
								else
								{
									StandardEquipment = false;
								}
							}
							if (ado_ModelFeature != null)
							{
								if (ado_ModelFeature.State == ConnectionState.Open)
								{ // Already Open Close It
									ado_ModelFeature.Close();
								}
								ado_ModelFeature = null;
							}

							if (StandardEquipment)
							{
								// UPDATE FEATURE TO YES
								if (($"{Convert.ToString(ado_FeatureCheck["afeat_status_flag"])}").Trim().ToUpper() == "N")
								{
									ado_FeatureCheck["afeat_status_flag"] = "Y";
									//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
									ado_FeatureCheck["afeat_action_date"] = DBNull.Value;
									ado_FeatureCheck.Update();
								}
							}
							else
							{
								if (txt_kfeat_query.Text.Trim() != "")
								{

									// SET THE KEY FEATURE FOR THE AIRCRAFT
									if (modAdminCommon.Key_Feature_Auto_Set(Convert.ToInt32(ado_FeatureCheck["afeat_ac_id"]), txt_kfeat_code.Text.Trim(), txt_kfeat_query.Text.Trim()))
									{
										// UPDATE FEATURE TO YES
										if (($"{Convert.ToString(ado_FeatureCheck["afeat_status_flag"])}").Trim().ToUpper() != "Y")
										{
											ado_FeatureCheck["afeat_status_flag"] = "Y";
											//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
											ado_FeatureCheck["afeat_action_date"] = DBNull.Value;
											ado_FeatureCheck.Update();
										}
									}
									else
									{
										// UPDATE FEATURE TO NO
										if (($"{Convert.ToString(ado_FeatureCheck["afeat_status_flag"])}").Trim().ToUpper() == "Y")
										{
											ado_FeatureCheck["afeat_status_flag"] = "U";
											//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
											ado_FeatureCheck["afeat_action_date"] = DBNull.Value;
											ado_FeatureCheck.Update();
										}
									}
								}
								else
								{
									// IF NO RULE APPLIES, THEN DO NOTHING
								} // HAVE A RULE TO APPLY
							} // STANDARD EQUIPMENT

							ado_FeatureCheck.MoveNext();
						};

					}
					else
					{
						// DID NOT FIND FEATURE CODES FOR THIS FETURE CODE TO UPDATE
						// DO NOTHING
					}
					// autogen key feature update

					ado_FeatureCheck.Close();

					//-------- ADDED MSW --- 2/2/23/18-----------------------------------------------------------------------------------------
					if (chk_product_flags[3].CheckState == CheckState.Unchecked)
					{ // if it is not model dependant
						did_some_magic = true;
						Query = "select * from Aircraft a2 with (NOLOCK) ";
						Query = $"{Query} where a2.ac_journ_id = 0 ";
						if (amod_id_list.ToString().Trim() != "")
						{
							Query = $"{Query} and a2.ac_amod_id not in ({amod_id_list.ToString()} ) ";
						}

						Query = $"{Query} and a2.ac_id in ( {StringsHelper.Replace(txt_kfeat_query.Text.Trim().ToLower(), " count(*) ", " distinct ac_id ", 1, -1, CompareMethod.Binary)} ) ";
						Query = $"{Query} order by ac_amod_id asc ";

						ado_FeatureCheck.CursorLocation = CursorLocationEnum.adUseClient;
						ado_FeatureCheck.Open(Query, modAdminCommon.ADODB_Trans_conn, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

						if (!(ado_FeatureCheck.BOF && ado_FeatureCheck.EOF))
						{
							TotalAircraft = ado_FeatureCheck.RecordCount;
							// FOUND FEATURE CODES FOR THIS MODEL TO UPDATE

							while(!ado_FeatureCheck.EOF)
							{


								Application.DoEvents();
								Application.DoEvents();

								// delete all of the ac key features for that feature for that ac
								delete_query = "";
								delete_query = $" delete from Aircraft_Key_Feature where afeat_journ_id = 0 and afeat_ac_id = {Convert.ToString(ado_FeatureCheck["ac_id"])} and afeat_feature_code = '{txt_kfeat_code.Text.Trim()}' ";
								DbCommand TempCommand_5 = null;
								TempCommand_5 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
								UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_5);
								TempCommand_5.CommandText = delete_query;
								//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
								//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
								TempCommand_5.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
								UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_5);
								TempCommand_5.ExecuteNonQuery();


								Application.DoEvents();
								Application.DoEvents();

								// re-insert it as a Y
								insert_query = new StringBuilder("");
								insert_query = new StringBuilder("INSERT INTO Aircraft_Key_Feature (");
								insert_query.Append("afeat_ac_id, afeat_journ_id, afeat_status_flag, afeat_feature_code, afeat_seq_no");
								insert_query.Append(") VALUES (");
								insert_query.Append($"{Convert.ToString(ado_FeatureCheck["ac_id"])}, 0,'Y', '{txt_kfeat_code.Text.Trim()}', 99 )");
								DbCommand TempCommand_6 = null;
								TempCommand_6 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
								UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_6);
								TempCommand_6.CommandText = insert_query.ToString();
								//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
								//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
								TempCommand_6.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
								UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_6);
								TempCommand_6.ExecuteNonQuery();


								Application.DoEvents();
								Application.DoEvents();
								JetNetSupport.PInvoke.SafeNative.kernel32.Sleep(10);

								insert_count++;


								ado_FeatureCheck.MoveNext();
							};

						}
						else
						{
						}

						ado_FeatureCheck.Close();



						Query = "select * from Aircraft_Key_Feature with (NOLOCK)";
						Query = $"{Query} Inner join aircraft with (NOLOCK) on ac_id = afeat_ac_id and ac_journ_id = afeat_journ_id ";
						Query = $"{Query} where afeat_journ_id = 0 and afeat_status_flag <> 'Y' and afeat_feature_code = '{txt_kfeat_code.Text.Trim()}' ";
						Query = $"{Query} and  ac_amod_id not in ({amod_id_list.ToString()} ) ";

						ado_FeatureCheck.CursorLocation = CursorLocationEnum.adUseClient;
						ado_FeatureCheck.Open(Query, modAdminCommon.ADODB_Trans_conn, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

						if (!(ado_FeatureCheck.BOF && ado_FeatureCheck.EOF))
						{
							TotalAircraft = ado_FeatureCheck.RecordCount;
							// FOUND FEATURE CODES FOR THIS MODEL TO UPDATE

							while(!ado_FeatureCheck.EOF)
							{

								delete_query = $" delete from Aircraft_Key_Feature where afeat_journ_id = 0 and afeat_ac_id = {Convert.ToString(ado_FeatureCheck["afeat_ac_id"])} and afeat_feature_code = '{txt_kfeat_code.Text.Trim()}' ";

								DbCommand TempCommand_7 = null;
								TempCommand_7 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
								UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_7);
								TempCommand_7.CommandText = delete_query;
								//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
								//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
								TempCommand_7.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
								UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_7);
								TempCommand_7.ExecuteNonQuery();

								ado_FeatureCheck.MoveNext();
							};

						}
						else
						{
						}

						ado_FeatureCheck.Close();
					}


				}






				// ----------- IN CASE IT SLIPS THRO THE CRACKS, then run our stored procedure ------
				string update_query = "";
				if (!did_some_magic)
				{
					//if it is model dependant and we changed the query
					if (chk_product_flags[3].CheckState == CheckState.Checked && new_query.Trim() != old_query.Trim())
					{

						Query = $"Select distinct amfeat_amod_id from Aircraft_Model_Key_Feature where amfeat_feature_code='{txt_kfeat_code.Text.Trim()}' ";


						ado_FeatureCheck3.Open(Query, modAdminCommon.ADODB_Trans_conn, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

						if (!(ado_FeatureCheck3.BOF && ado_FeatureCheck3.EOF))
						{
							// FOUND FEATURE CODES FOR THIS MODEL TO UPDATE

							while(!ado_FeatureCheck3.EOF)
							{

								update_query = $" exec Update_Model_Key_Feature {Convert.ToString(ado_FeatureCheck3["amfeat_amod_id"])},'{txt_kfeat_code.Text.Trim()}' ";
								// modAdminCommon.ADODB_Trans_conn.Execute update_query, , adCmdText + adExecuteNoRecords
								DbCommand TempCommand_8 = null;
								TempCommand_8 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
								UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_8);
								TempCommand_8.CommandText = update_query;
								//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
								//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
								TempCommand_8.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
								UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_8);
								TempCommand_8.ExecuteNonQuery();
								JetNetSupport.PInvoke.SafeNative.kernel32.Sleep(50);

								ado_FeatureCheck3.MoveNext();
							};

						}
						else
						{
						}

						ado_FeatureCheck3.Close();


					}
				}
				// ----------- IN CASE IT SLIPS THRO THE CRACKS, then run our stored procedure ------


				modAdminCommon.ADO_Transaction("CommitTrans");


				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Key Feature Update Complete.", Color.Blue);


				// CLOSE RECORSET
				if (ado_FeatureCheck != null)
				{
					if (ado_FeatureCheck.State == ConnectionState.Open)
					{ // Already Open Close It
						ado_FeatureCheck.Close();
					}
					ado_FeatureCheck = null;
				}

				if (ado_feature != null)
				{
					if (ado_feature.State == ConnectionState.Open)
					{ // Already Open Close It
						ado_feature.Close();
					}
					ado_feature = null;
				}
				this.Cursor = CursorHelper.CursorDefault;
			}
			catch (System.Exception excep)
			{

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
				if (ado_feature != null)
				{
					if (ado_feature.State == ConnectionState.Open)
					{ // Already Open Close It
						ado_feature.Close();
					}
					ado_feature = null;
				}
				modAdminCommon.Report_Error("Key_Feature_Mass_Update_Error:");

				modAdminCommon.Report_Error($"Key_Feature_Mass_Update_Error {excep.Message}");

				//Resume Next
			}

		}

		public bool Record_Delete_Log_Entry(string inRecord_Type, int inRecord_Id, int inJourn_ID, int inSeq_No = 0, int inEventID = 0, string inFeature = "", int inPictureID = 0)
		{

			bool result = false;
			try
			{

				string Query = "";

				result = false;

				Query = "INSERT INTO Delete_Log (dlog_type, dlog_ac_id, dlog_journ_id, dlog_comp_id, ";
				Query = $"{Query}dlog_contact_id, dlog_wanted_id,  dlog_amod_id, dlog_seq_no, ";
				Query = $"{Query}dlog_priorev_id, dlog_entry_user, dlog_acpic_id, dlog_yacht_id, ";
				Query = $"{Query}dlog_feature_code  ) VALUES ('";
				Query = $"{Query}{($" {inRecord_Type}").Trim()}', "; // Type or record being written

				// 06/21/2005 - By David D. Cruger; Added AircraftPictures
				if (inRecord_Type == "Transaction" || inRecord_Type == "Key_Feature" || inRecord_Type == "Document" || inRecord_Type == "Installation" || inRecord_Type == "WebUser" || inRecord_Type == "Subscription" || inRecord_Type == "AircraftPicture" || inRecord_Type == "Aircraft" || inRecord_Type == "AircraftPictures")
				{ // handle the AC ID
					Query = $"{Query}{inRecord_Id.ToString()}, ";
				}
				else
				{
					Query = $"{Query}0, ";
				}

				Query = $"{Query}{inJourn_ID.ToString()}, "; // handle the journal id

				if (inRecord_Type == "Company")
				{ // handle the Company ID
					Query = $"{Query}{inRecord_Id.ToString()}, ";
				}
				else
				{
					Query = $"{Query}0, ";
				}


				if (inRecord_Type == "Contact")
				{ // handle the Contact ID
					Query = $"{Query}{inRecord_Id.ToString()}, ";
				}
				else
				{
					Query = $"{Query}0, ";
				}

				if (inRecord_Type == "Wanted")
				{ // handle the Wanted ID
					Query = $"{Query}{inRecord_Id.ToString()}, ";
				}
				else
				{
					Query = $"{Query}0, ";
				}

				if (inRecord_Type == "Model")
				{ // handle the Model ID
					Query = $"{Query}{inRecord_Id.ToString()}, ";
				}
				else
				{
					Query = $"{Query}0, ";
				}

				if (Strings.Len(inSeq_No.ToString().Trim()) > 0)
				{ // handle sequence number
					Query = $"{Query}{inSeq_No.ToString()}, ";
				}
				else
				{
					Query = $"{Query}0, ";
				}

				if (Strings.Len(inEventID.ToString().Trim()) > 0)
				{
					Query = $"{Query}{inEventID.ToString()}, ";
				}
				else
				{
					Query = $"{Query}0, ";
				}

				Query = $"{Query}'{Convert.ToString(modAdminCommon.snp_User["user_id"])}', ";

				if (Strings.Len(inPictureID.ToString().Trim()) > 0)
				{ // acpic_id
					Query = $"{Query}{inPictureID.ToString()}, ";
				}
				else
				{
					Query = $"{Query}0, ";
				}


				if (inRecord_Type == "Yacht")
				{ // handle the Yacht ID
					Query = $"{Query}{inRecord_Id.ToString()}, ";
				}
				else
				{
					Query = $"{Query}0, ";
				}

				if (inRecord_Type == "Key_Feature")
				{ // HANDLE KEY FEATURE
					Query = $"{Query}'{inFeature}') ";
				}
				else
				{
					Query = $"{Query}'') ";
				}


				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();


				return true;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Record_Delete_Log_Entry ({Information.Err().Number.ToString()}) {excep.Message}");
				result = false;
			}
			return result;
		} // Record_Delete_Log_Entry
		private bool IsAirportUnique(string strIATA, string strICAO, string strFAAID, int lAPortId)
		{
			// This function will check and see if the IATA and ICAO combo already exists, then IATA exists, and ICAO exists
			// If any condition is met then it will return false for not being unique, if not returns true
			// aport_id = -1 means the funtion was called as an add, any other number is the aport ID which is checked before the update

			bool result = false;
			string Action = "";
			string strQuery1 = "";

			try
			{
				Action = "IsAirportUnique";

				strIATA = strIATA.Trim();
				strICAO = strICAO.Trim();
				strFAAID = strFAAID.Trim();

				strQuery1 = "SELECT aport_id, aport_iata_code, aport_icao_code, aport_faaid_code ";
				strQuery1 = $"{strQuery1}FROM Airport WITH (NOLOCK) ";

				if (strIATA == "")
				{
					strQuery1 = $"{strQuery1}WHERE (aport_iata_code IS NULL OR aport_iata_code = '') ";
				}
				else
				{
					strQuery1 = $"{strQuery1}WHERE (aport_iata_code = '{strIATA}') ";
				}

				if (strICAO == "")
				{
					strQuery1 = $"{strQuery1}AND (aport_icao_code IS NULL OR aport_icao_code = '') ";
				}
				else
				{
					strQuery1 = $"{strQuery1}AND (aport_icao_code = '{strICAO}') ";
				}

				if (strFAAID == "")
				{
					strQuery1 = $"{strQuery1}AND (aport_faaid_code IS NULL OR aport_faaid_code = '' ) ";
				}
				else
				{
					strQuery1 = $"{strQuery1}AND (aport_faaid_code = '{strFAAID}') ";
				}

				if (lAPortId != -1)
				{
					strQuery1 = $"{strQuery1}AND (aport_id <> {lAPortId.ToString()}) ";
				}

				//MsgBox Query
				if (modAdminCommon.Exist(strQuery1))
				{
					result = false;
					if (lAPortId != -1)
					{
						MessageBox.Show("An Airport with this IATA, ICAO and FAAID Already exists", "Duplicate IATA, ICAO and FAAID", MessageBoxButtons.OK);
					}
					else
					{
						MessageBox.Show($"An Airport with this IATA, ICAO, FAAID and Aport ID: {lAPortId.ToString()} Already exists", "Duplicate IATA, ICAO, FAAID, AirportID", MessageBoxButtons.OK);
					}
					return result;
				} // If Exist(strQuery1) Then

				if (strIATA != "")
				{
					strQuery1 = "SELECT aport_id FROM Airport WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1}WHERE (aport_iata_code = '{strIATA}') ";
					if (lAPortId != -1)
					{
						strQuery1 = $"{strQuery1}AND (aport_id <> {lAPortId.ToString()}) ";
					}

					if (modAdminCommon.Exist(strQuery1))
					{
						if (lAPortId != -1)
						{
							MessageBox.Show($"An Airport with this IATA Code and this aport_id({lAPortId.ToString()}) already exists", "Existing IATA", MessageBoxButtons.OK);
						}
						else
						{
							MessageBox.Show("An Airport with this IATA Code Already exists.", "Existing IATA", MessageBoxButtons.OK);
						}
						return false;
					}
				} // If strIATA <> "" Then

				if (strICAO != "")
				{
					strQuery1 = "SELECT aport_id FROM Airport WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1}WHERE (aport_icao_code = '{strICAO.Trim()}') ";
					if (lAPortId != -1)
					{
						strQuery1 = $"{strQuery1}AND (aport_id <> {lAPortId.ToString()}) ";
					}

					if (modAdminCommon.Exist(strQuery1))
					{
						if (lAPortId != -1)
						{
							MessageBox.Show($"An Airport with this ICAO Code and this aport_id({lAPortId.ToString()}) already exists", "Existing IATA", MessageBoxButtons.OK);
						}
						else
						{
							MessageBox.Show("An Airport with this ICAO Code Already exists.", "Existing IATA", MessageBoxButtons.OK);
						}
						return false;
					}
				} // If strICAO <> "" Then

				if (strFAAID != "")
				{
					strQuery1 = $"SELECT aport_id FROM Airport WITH (NOLOCK) WHERE (aport_faaid_code = '{strFAAID.Trim()}') ";
					if (lAPortId != -1)
					{
						strQuery1 = $"{strQuery1}AND (aport_id <> {lAPortId.ToString()}) ";
					}

					if (modAdminCommon.Exist(strQuery1))
					{
						if (lAPortId != -1)
						{
							MessageBox.Show($"An Airport with this FAAID and this aport_id({lAPortId.ToString()}) already exists", "Existing IATA", MessageBoxButtons.OK);
						}
						else
						{
							MessageBox.Show("An Airport with this FAAID Already exists.", "Existing IATA", MessageBoxButtons.OK);
						}
						return false;
					}
				} // If strFAAID <> "" Then

				return true;
			}
			catch (System.Exception excep)
			{

				this.Cursor = CursorHelper.CursorDefault;
				modAdminCommon.Report_Error($"Airport_Maintenance_Error: {Action} - {strIATA}-{strICAO}-{strFAAID} - {excep.Message}");
			}
			return result;
		}

		private void txtAirport_TextChanged(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.txtAirport, eventSender);

			int lRow = 0;

			bool bChanged = false;

			if (frmAirport.Enabled)
			{

				lRow = grd_Airport.CurrentRowIndex;

				switch(Index)
				{
					case iAPORTNAME_INDEX :  // Airport Name 
						if (txtAirport[iAPORTNAME_INDEX].Text != Convert.ToString(grd_Airport[lRow, 3].Value))
						{
							bChanged = true;
						} 
						break;
					case iIATA_INDEX :  // IATA 
						if (txtAirport[iIATA_INDEX].Text != Convert.ToString(grd_Airport[lRow, 0].Value))
						{
							bChanged = true;
						} 
						break;
					case iICAO_INDEX :  // ICAO 
						if (txtAirport[iICAO_INDEX].Text != Convert.ToString(grd_Airport[lRow, 1].Value))
						{
							bChanged = true;
						} 
						break;
					case iFAAID_INDEX :  // FAA ID 
						if (txtAirport[iFAAID_INDEX].Text != Convert.ToString(grd_Airport[lRow, 2].Value))
						{
							bChanged = true;
						} 
						break;
					case iCITY_INDEX :  // City 
						if (txtAirport[iCITY_INDEX].Text != Convert.ToString(grd_Airport[lRow, 4].Value))
						{
							bChanged = true;
						} 
						 
						break;
				}

			} // If frmAirport.Enabled = True Then

			if (bChanged)
			{
				lblAirport[0].Text = "Airport Name*";
			}

		} // txtAirport_Change

		private void txtAirport_Leave(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.txtAirport, eventSender);

			string strCompId = "";
			string strCompName = "";


			switch(Index)
			{
				case iCOMPID_INDEX : 
					 
					if (txtAirport[iCOMPID_INDEX].Text != Convert.ToString(txtAirport[iCOMPID_INDEX].Tag))
					{

						if (txtAirport[iCOMPID_INDEX].Text == "0" || txtAirport[iCOMPID_INDEX].Text == "")
						{
							txtAirport[iCOMPID_INDEX].Text = "0";
							txtAirport[iCOMPID_INDEX].Tag = "0";
							ToolTipMain.SetToolTip(txtAirport[iCOMPID_INDEX], "");
						}
						else
						{

							strCompId = txtAirport[iCOMPID_INDEX].Text;
							strCompName = "";

							if (Information.IsNumeric(strCompId))
							{
								strCompName = modAdminCommon.DLookUp("comp_name", "Company", $"(comp_id = {strCompId} AND comp_journ_id = 0)");
								if (strCompName != "")
								{
									txtAirport[iCOMPID_INDEX].Text = strCompId;
									txtAirport[iCOMPID_INDEX].Tag = strCompId;
									ToolTipMain.SetToolTip(txtAirport[iCOMPID_INDEX], strCompName);
								}
								else
								{
									MessageBox.Show($"Unable To Find CompId: {strCompId}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
									txtAirport[iCOMPID_INDEX].Text = "0";
									txtAirport[iCOMPID_INDEX].Tag = "0";
									ToolTipMain.SetToolTip(txtAirport[iCOMPID_INDEX], "");
								}
							}
							else
							{
								txtAirport[iCOMPID_INDEX].Text = "0";
								txtAirport[iCOMPID_INDEX].Tag = "0";
								ToolTipMain.SetToolTip(txtAirport[iCOMPID_INDEX], "");
							}

						} // If txtAirport(iCOMPID_INDEX).Text = "0" Or txtAirport(iCOMPID_INDEX).Text = "" Then

					}  // If txtAirport(iCOMPID_INDEX).Text <> txtAirport(iCOMPID_INDEX).Tag Then 
					 
					break;
			} // Case Index

		} // txtAirport_LostFocus

		private void txtGlobal_KeyUp(Object eventSender, KeyEventArgs eventArgs)
		{
			int KeyCode = (int) eventArgs.KeyCode;
			int Shift = ((int) eventArgs.KeyData) / 65536;
			try
			{
				if (txtGlobal.Text.Trim() != "")
				{
					Check_For_Search_Enter_Key(KeyCode);
				}
			}
			finally
			{
				eventArgs.Handled = KeyCode == 0;
			}
		} // txtGlobal_KeyUp

		private void Test_TextBox_Company_Id(int iMfrCompId, int iMfrName)
		{

			int lCompId = 0;

			string strCompany = "";
			string strCompId = txtEngineModel[iMfrCompId].Text.Trim();
			if (Information.IsNumeric(strCompId))
			{

				lCompId = Convert.ToInt32(Double.Parse(strCompId));
				modAdminCommon.Return_Company_Name(lCompId, ref strCompany);
				if (strCompany == "")
				{
					MessageBox.Show($"Can NOT Find Company Name for Mfr CompId [{strCompId}]", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					txtEngineModel[iMfrCompId].Text = "0";
				}

			}
			else
			{
				MessageBox.Show("Mfr CompId Must Be Numeric", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtEngineModel[iMfrCompId].Text = "0";
			} // If IsNumeric(strCompId) = True Then

			txtEngineModel[iMfrName].Text = strCompany;

		} // Test_TextBox_Company_Id

		private void txtEngineModel_Leave(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.txtEngineModel, eventSender);



			switch(Index)
			{
				case iEMID : case iEMNAME : case iEMMFRABBREV : case iEMMFRNAME : 
					 
					break;
				case iEMPREFIX : case iEMCORE : case iEMSUFFIX1 : case iEMSUFFIX2 : 
					txtEngineModel[iEMNAME].Text = modAdminCommon.BuildEngineModelName(txtEngineModel[iEMPREFIX].Text, txtEngineModel[iEMCORE].Text, txtEngineModel[iEMSUFFIX1].Text, txtEngineModel[iEMSUFFIX2].Text); 
					 
					break;
				case iEMTAKEOFFPOWER : 
					modAdminCommon.Test_TextBox_For_Numeric(txtEngineModel[iEMTAKEOFFPOWER], "Takeoff Power"); 
					 
					break;
				case iEMMAXCONPOWER : 
					modAdminCommon.Test_TextBox_For_Numeric(txtEngineModel[iEMMAXCONPOWER], "Max Continuous Power"); 
					 
					break;
				case iEMMFRCOMPID : 
					Test_TextBox_Company_Id(iEMMFRCOMPID, iEMMFRNAME); 
					 
					break;
				case iEMTHRUSTLBS : 
					modAdminCommon.Test_TextBox_For_Numeric(txtEngineModel[iEMTHRUSTLBS], "Thrust Per Engine (Lbs)"); 
					 
					break;
				case iEMCOMTBOHRS : 
					modAdminCommon.Test_TextBox_For_Numeric(txtEngineModel[iEMCOMTBOHRS], "Common TBO Hours"); 
					 
					break;
				case iEMSHAFTHP : 
					modAdminCommon.Test_TextBox_For_Numeric(txtEngineModel[iEMSHAFTHP], "Shaft Horse Power"); 
					 
					break;
				case iEMHSI : 
					modAdminCommon.Test_TextBox_For_Numeric(txtEngineModel[iEMHSI], "HSI"); 
					 
					break;
			} // Case INDEX

		} // txtEngineModel_LostFocus
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}