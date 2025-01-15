using Microsoft.VisualBasic;
using System;
using System.Data.Common;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Gui.Utils;
using UpgradeHelpers.Helpers;

namespace JETNET_Homebase
{
	internal partial class frm_JournalListPopUp
		: System.Windows.Forms.Form
	{

		//==================
		// Public Variables
		//==================
		public string inQuery = "";
		public string inEntryPoint = "";
		private bool Stopit = false;
		public frm_JournalListPopUp()
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



		public void FillAirportGrid()
		{

			string Query = "";
			int APCount = 0;
			ADORecordSetHelper snpJournal = new ADORecordSetHelper();
			int lCol = 0;

			try
			{

				this.Cursor = Cursors.WaitCursor;
				Stopit = false;
				cmdStop.Visible = true;

				this.Text = "Filling grid - Please Wait";
				APCount = 0;

				grdJournal.Enabled = false;
				grdJournal.Clear();

				this.Cursor = Cursors.WaitCursor;


				grdJournal.Clear();
				grdJournal.RowsCount = 2;
				grdJournal.ColumnsCount = 9;
				grdJournal.FixedRows = 1;
				grdJournal.FixedColumns = 0;

				grdJournal.CurrentRowIndex = 0;

				lCol = -1;

				lCol++;
				grdJournal.CurrentColumnIndex = lCol;
				grdJournal[grdJournal.CurrentRowIndex, grdJournal.CurrentColumnIndex].Value = "APORTID";
				grdJournal.SetColumnWidth(lCol, 0);

				lCol++;
				grdJournal.CurrentColumnIndex = lCol;
				grdJournal[grdJournal.CurrentRowIndex, grdJournal.CurrentColumnIndex].Value = "IATA";
				grdJournal.SetColumnWidth(lCol, 50);
				grdJournal.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

				lCol++;
				grdJournal.CurrentColumnIndex = lCol;
				grdJournal[grdJournal.CurrentRowIndex, grdJournal.CurrentColumnIndex].Value = "ICAO";
				grdJournal.SetColumnWidth(lCol, 50);
				grdJournal.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

				lCol++;
				grdJournal.CurrentColumnIndex = lCol;
				grdJournal[grdJournal.CurrentRowIndex, grdJournal.CurrentColumnIndex].Value = "FAAID";
				grdJournal.SetColumnWidth(lCol, 50);
				grdJournal.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

				lCol++;
				grdJournal.CurrentColumnIndex = lCol;
				grdJournal[grdJournal.CurrentRowIndex, grdJournal.CurrentColumnIndex].Value = "Name";
				grdJournal.SetColumnWidth(lCol, 167);

				lCol++;
				grdJournal.CurrentColumnIndex = lCol;
				grdJournal[grdJournal.CurrentRowIndex, grdJournal.CurrentColumnIndex].Value = "State";
				grdJournal.SetColumnWidth(lCol, 47);
				grdJournal.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

				lCol++;
				grdJournal.CurrentColumnIndex = lCol;
				grdJournal[grdJournal.CurrentRowIndex, grdJournal.CurrentColumnIndex].Value = "Country";
				grdJournal.SetColumnWidth(lCol, 100);

				lCol++;
				grdJournal.CurrentColumnIndex = lCol;
				grdJournal[grdJournal.CurrentRowIndex, grdJournal.CurrentColumnIndex].Value = "City";
				grdJournal.SetColumnWidth(lCol, 167);

				lCol++;
				grdJournal.CurrentColumnIndex = lCol;
				grdJournal[grdJournal.CurrentRowIndex, grdJournal.CurrentColumnIndex].Value = "Active";
				grdJournal.SetColumnWidth(lCol, 47);
				grdJournal.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

				grdJournal.Enabled = true;
				grdJournal.Visible = true;
				grdJournal.Redraw = true;
				 // grdJournal

				Application.DoEvents();

				Query = inQuery;

				snpJournal.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpJournal.BOF && snpJournal.EOF))
				{

					grdJournal.Enabled = false;
					grdJournal.Redraw = false;

					grdJournal.CurrentRowIndex = 0;

					do 
					{ // Loop Until snpJournal.EOF = True Or Stopit = True

						this.Text = $"Filling grid - Please Wait {APCount.ToString()}";

						APCount++;

						grdJournal.CurrentRowIndex++;

						lCol = -1;

						lCol++;
						grdJournal.CurrentColumnIndex = lCol;
						grdJournal[grdJournal.CurrentRowIndex, grdJournal.CurrentColumnIndex].Value = Convert.ToString(snpJournal["aport_id"]);

						lCol++;
						grdJournal.CurrentColumnIndex = lCol;
						grdJournal[grdJournal.CurrentRowIndex, grdJournal.CurrentColumnIndex].Value = ($"{Convert.ToString(snpJournal["aport_iata_code"])} ").Trim();
						grdJournal.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

						lCol++;
						grdJournal.CurrentColumnIndex = lCol;
						grdJournal[grdJournal.CurrentRowIndex, grdJournal.CurrentColumnIndex].Value = ($"{Convert.ToString(snpJournal["aport_icao_code"])} ").Trim();
						grdJournal.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

						lCol++;
						grdJournal.CurrentColumnIndex = lCol;
						grdJournal[grdJournal.CurrentRowIndex, grdJournal.CurrentColumnIndex].Value = ($"{Convert.ToString(snpJournal["aport_faaid_code"])} ").Trim();
						grdJournal.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

						lCol++;
						grdJournal.CurrentColumnIndex = lCol;
						grdJournal[grdJournal.CurrentRowIndex, grdJournal.CurrentColumnIndex].Value = ($"{Convert.ToString(snpJournal["aport_name"])} ").Trim();
						grdJournal.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

						lCol++;
						grdJournal.CurrentColumnIndex = lCol;
						grdJournal[grdJournal.CurrentRowIndex, grdJournal.CurrentColumnIndex].Value = ($"{Convert.ToString(snpJournal["aport_state"])} ").Trim();
						grdJournal.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

						lCol++;
						grdJournal.CurrentColumnIndex = lCol;
						grdJournal[grdJournal.CurrentRowIndex, grdJournal.CurrentColumnIndex].Value = ($"{Convert.ToString(snpJournal["aport_country"])} ").Trim();
						grdJournal.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

						lCol++;
						grdJournal.CurrentColumnIndex = lCol;
						grdJournal[grdJournal.CurrentRowIndex, grdJournal.CurrentColumnIndex].Value = ($"{Convert.ToString(snpJournal["Aport_city"])} ").Trim();
						grdJournal.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

						lCol++;
						grdJournal.CurrentColumnIndex = lCol;
						grdJournal[grdJournal.CurrentRowIndex, grdJournal.CurrentColumnIndex].Value = ($"{Convert.ToString(snpJournal["aport_active_flag"])} ").Trim();
						grdJournal.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

						grdJournal.RowsCount++;

						if (APCount == 21)
						{
							grdJournal.Enabled = true;
							grdJournal.Visible = true;
							grdJournal.Redraw = true;
							Application.DoEvents();
							grdJournal.Enabled = false;
							grdJournal.Redraw = false;
						}
						 // Do While Not snpJournal.EOF = False Or Stopit = True

						snpJournal.MoveNext();

					}
					while(!(snpJournal.EOF || Stopit));

					grdJournal.RowsCount--;

					this.Text = $"Please Select An Airport - {APCount.ToString()} Record(s)";

				}
				else
				{
					grdJournal.CurrentColumnIndex = 0;
					grdJournal.CurrentRowIndex = 1;
					grdJournal[grdJournal.CurrentRowIndex, grdJournal.CurrentColumnIndex].Value = "None Found";
				}

				grdJournal.Enabled = true;
				grdJournal.Visible = true;
				grdJournal.Redraw = true;

				cmdStop.Visible = false;
				Stopit = false;

				snpJournal.Close();
				snpJournal = null;

				this.Cursor = CursorHelper.CursorDefault;
			}
			catch (System.Exception excep)
			{

				this.Cursor = CursorHelper.CursorDefault;
				modAdminCommon.Report_Error($"FillAirportGrid_Error: {excep.Message}", "JrnlPopup");
			}

		}

		private void FillJournalGrid()
		{

			string Query = "";
			ADORecordSetHelper snpJournal = new ADORecordSetHelper();

			try
			{

				this.Cursor = Cursors.WaitCursor;

				grdJournal.Visible = false;
				grdJournal.Enabled = false;
				grdJournal.Clear();

				grdJournal.Clear();
				grdJournal.RowsCount = 2;
				grdJournal.ColumnsCount = 7;
				grdJournal.FixedRows = 1;
				grdJournal.FixedColumns = 0;

				grdJournal.CurrentColumnIndex = 0;
				grdJournal.CurrentRowIndex = 0;
				grdJournal[grdJournal.CurrentRowIndex, grdJournal.CurrentColumnIndex].Value = "Entry Date";
				grdJournal.SetColumnWidth(0, 67);

				grdJournal.CurrentColumnIndex = 1;
				grdJournal[grdJournal.CurrentRowIndex, grdJournal.CurrentColumnIndex].Value = "Event Date";
				grdJournal.SetColumnWidth(1, 67);

				grdJournal.CurrentColumnIndex = 2;
				grdJournal[grdJournal.CurrentRowIndex, grdJournal.CurrentColumnIndex].Value = "Subject";
				grdJournal.SetColumnWidth(2, 167);

				grdJournal.CurrentColumnIndex = 3;
				grdJournal[grdJournal.CurrentRowIndex, grdJournal.CurrentColumnIndex].Value = "User";
				grdJournal.SetColumnWidth(3, 67);

				grdJournal.CurrentColumnIndex = 4;
				grdJournal[grdJournal.CurrentRowIndex, grdJournal.CurrentColumnIndex].Value = "Acct ID";
				grdJournal.SetColumnWidth(4, 67);

				grdJournal.CurrentColumnIndex = 5;
				grdJournal[grdJournal.CurrentRowIndex, grdJournal.CurrentColumnIndex].Value = "Aircraft";
				grdJournal.SetColumnWidth(5, 133);

				grdJournal.CurrentColumnIndex = 6;
				grdJournal[grdJournal.CurrentRowIndex, grdJournal.CurrentColumnIndex].Value = "Company";
				grdJournal.SetColumnWidth(6, 133);


				Query = inQuery;

				snpJournal.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpJournal.BOF && snpJournal.EOF))
				{

					grdJournal.CurrentRowIndex = 0;

					while(!snpJournal.EOF)
					{
						grdJournal.CurrentRowIndex++;

						grdJournal.CurrentColumnIndex = 0;
						grdJournal[grdJournal.CurrentRowIndex, grdJournal.CurrentColumnIndex].Value = DateTime.Parse(Convert.ToString(snpJournal["journ_entry_date"]).Trim()).ToString("d");

						grdJournal.CurrentColumnIndex = 1;
						grdJournal[grdJournal.CurrentRowIndex, grdJournal.CurrentColumnIndex].Value = DateTime.Parse(Convert.ToString(snpJournal["journ_date"]).Trim()).ToString("d");

						grdJournal.CurrentColumnIndex = 2;
						grdJournal[grdJournal.CurrentRowIndex, grdJournal.CurrentColumnIndex].Value = ($"{Convert.ToString(snpJournal["journ_subject"])}").Trim();

						grdJournal.CurrentColumnIndex = 3;
						grdJournal[grdJournal.CurrentRowIndex, grdJournal.CurrentColumnIndex].Value = ($"{Convert.ToString(snpJournal["journ_user_id"])}").Trim();

						grdJournal.CurrentColumnIndex = 4;
						grdJournal[grdJournal.CurrentRowIndex, grdJournal.CurrentColumnIndex].Value = ($"{Convert.ToString(snpJournal["journ_account_id"])}").Trim();

						grdJournal.CurrentColumnIndex = 5;
						grdJournal[grdJournal.CurrentRowIndex, grdJournal.CurrentColumnIndex].Value = modCommon.GetAircraftName(Convert.ToInt32(Double.Parse(($"{Convert.ToString(snpJournal["journ_ac_id"])}").Trim())), 0);

						grdJournal.CurrentColumnIndex = 6;
						grdJournal[grdJournal.CurrentRowIndex, grdJournal.CurrentColumnIndex].Value = modCommon.GetCompanyName(Convert.ToInt32(Double.Parse(($"{Convert.ToString(snpJournal["journ_comp_id"])}").Trim())), 0);

						grdJournal.RowsCount++;

						snpJournal.MoveNext();
					};

					grdJournal.RowsCount--;

				}
				else
				{
					grdJournal.CurrentColumnIndex = 0;
					grdJournal.CurrentRowIndex = 1;
					grdJournal[grdJournal.CurrentRowIndex, grdJournal.CurrentColumnIndex].Value = "None Found";
				}

				grdJournal.Redraw = true;
				grdJournal.Visible = true;
				grdJournal.Enabled = true;

				snpJournal.Close();
				snpJournal = null;
				this.Cursor = CursorHelper.CursorDefault;
			}
			catch (System.Exception excep)
			{

				this.Cursor = CursorHelper.CursorDefault;
				modAdminCommon.Report_Error($"FillJournalGrid_Error: {excep.Message}", "JrnlPopup");
			}

		}

		private void cmdClose_Click(Object eventSender, EventArgs eventArgs) => this.Close();


		private void CmdSelect_Click(Object eventSender, EventArgs eventArgs) => grdJournal_DoubleClick(grdJournal, new EventArgs());


		private void cmdStop_Click(Object eventSender, EventArgs eventArgs) => Stopit = true;


		private void Form_Activated(Object eventSender, EventArgs eventArgs)
		{
			if (ActivateHelper.myActiveForm != eventSender)
			{
				ActivateHelper.myActiveForm = (Form) eventSender;

				Stopit = false;
				if (inQuery == "")
				{
					grdJournal.Clear();
				}
				else
				{
					if (inEntryPoint == "AddAircraft" || inEntryPoint == "Aircraft")
					{
						FillAirportGrid();
					}
					else
					{
						FillJournalGrid();
					}
				}

			}
		}

		private void grdJournal_Click(Object eventSender, EventArgs eventArgs) => CmdSelect.Visible = true;


		private void grdJournal_DoubleClick(Object eventSender, EventArgs eventArgs)
		{

			int K = 0;
			Form Frm = null;
			Form f = null;

			Form updateForm = null; 
			int lRow = 0;
			int lCol = 0;

			try
			{

				if (Convert.ToString(grdJournal[grdJournal.MouseRow, 0].Value) != "None Found")
				{

					foreach (Form FrmIterator in Application.OpenForms)
					{
						Frm = FrmIterator;
						f = Frm;


						if ((f.Name.Trim().ToLower()) == ("frm_Aircraft").ToLower())
						{
							if (inEntryPoint == "Aircraft")
							{
								updateForm = f;
								break;
							}
						}
						else if ((f.Name.Trim().ToLower()) == ("frm_AddAircraft").ToLower())
						{ 
							if (inEntryPoint == "AddAircraft")
							{
								updateForm = f;
								break;
							}
						}

						Frm = default(Form);
					}

					if (inEntryPoint == "Aircraft")
					{

						lRow = grdJournal.CurrentRowIndex;
						//UPGRADE_TODO: (1067) Member txtIATACode is not defined in type VB.Form. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						(updateForm as frm_aircraft).txtIATACode.Tag = Convert.ToString(grdJournal[lRow, 0].Value); // APortId
						//UPGRADE_TODO: (1067) Member txtIATACode is not defined in type VB.Form. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						(updateForm as frm_aircraft).txtIATACode.Text = Convert.ToString(grdJournal[lRow, 1].Value); // IATA
						//UPGRADE_TODO: (1067) Member txtICAOCode is not defined in type VB.Form. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						(updateForm as frm_aircraft).txtICAOCode.Text = Convert.ToString(grdJournal[lRow, 2].Value); // ICAO
						//UPGRADE_TODO: (1067) Member txtFAAIDCode is not defined in type VB.Form. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						(updateForm as frm_aircraft).txtFAAIDCode.Text = Convert.ToString(grdJournal[lRow, 3].Value); // FAAID
						//UPGRADE_TODO: (1067) Member txtBaseAirportName is not defined in type VB.Form. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						(updateForm as frm_aircraft).txtBaseAirportName.Text = Convert.ToString(grdJournal[lRow, 4].Value); // BASE NAME
						//UPGRADE_TODO: (1067) Member txtBaseCity is not defined in type VB.Form. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						(updateForm as frm_aircraft).txtBaseCity.Text = Convert.ToString(grdJournal[lRow, 7].Value); // CITY

						//UPGRADE_TODO: (1067) Member cboBaseState is not defined in type VB.Form. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						(updateForm as frm_aircraft).cboBaseState.SelectedIndex = (-1);
						if (Convert.ToString(grdJournal[lRow, 5].Value) != "")
						{
							//UPGRADE_TODO: (1067) Member cboBaseState is not defined in type VB.Form. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
							double tempForEndVar = Convert.ToDouble((updateForm as frm_aircraft).cboBaseState.Items.Count) - 1;
							for (int i = 0; i <= tempForEndVar; i++)
							{
								//UPGRADE_TODO: (1067) Member cboBaseState is not defined in type VB.Form. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								if (Convert.ToString((updateForm as frm_aircraft).cboBaseState.Items[i]).ToLower() == Convert.ToString(grdJournal[lRow, 5].Value).Trim().ToLower())
								{
									//UPGRADE_TODO: (1067) Member cboBaseState is not defined in type VB.Form. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									(updateForm as frm_aircraft).cboBaseState.SelectedIndex = i;
									break;
								}
							}
						}

						//UPGRADE_TODO: (1067) Member cboBaseCountry is not defined in type VB.Form. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						(updateForm as frm_aircraft).cboBaseCountry.SelectedIndex = (-1);
						if (Convert.ToString(grdJournal[lRow, 6].Value) != "")
						{
							//UPGRADE_TODO: (1067) Member cboBaseCountry is not defined in type VB.Form. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
							double tempForEndVar2 = Convert.ToDouble((updateForm as frm_aircraft).cboBaseCountry.Items.Count) - 1;
							for (int i = 0; i <= tempForEndVar2; i++)
							{
								//UPGRADE_TODO: (1067) Member cboBaseCountry is not defined in type VB.Form. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								if (Convert.ToString((updateForm as frm_aircraft).cboBaseCountry.Items[i]).ToLower() == Convert.ToString(grdJournal[lRow, 6].Value).Trim().ToLower())//gap-note this line must be checked in runtime to compare if the comparison makes sense or requires to change it
								{
									//UPGRADE_TODO: (1067) Member cboBaseCountry is not defined in type VB.Form. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									(updateForm as frm_aircraft).cboBaseCountry.SelectedIndex = i;
									break;
								}
							}
						}

					}
					else if (inEntryPoint == "AddAircraft")
					{ 

						lRow = grdJournal.CurrentRowIndex;
						//UPGRADE_TODO: (1067) Member txtBaseCode is not defined in type VB.Form. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						(updateForm as frm_AddAircraft).txtBaseCode[0].Tag = Convert.ToString(grdJournal[lRow, 0].Value); // APortId
																														  //UPGRADE_TODO: (1067) Member txtBaseCode is not defined in type VB.Form. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						(updateForm as frm_AddAircraft).txtBaseCode[0].Text = Convert.ToString(grdJournal[lRow, 1].Value); // IATA
																														   //UPGRADE_TODO: (1067) Member txtBaseCode is not defined in type VB.Form. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						(updateForm as frm_AddAircraft).txtBaseCode[1].Text = Convert.ToString(grdJournal[lRow, 2].Value); // ICAO
																														   //UPGRADE_TODO: (1067) Member txtBaseCode is not defined in type VB.Form. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						(updateForm as frm_AddAircraft).txtBaseCode[3].Text = Convert.ToString(grdJournal[lRow, 3].Value); // FAAID
																														   //UPGRADE_TODO: (1067) Member txtBaseCode is not defined in type VB.Form. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						(updateForm as frm_AddAircraft).txtBaseCode[2].Text = Convert.ToString(grdJournal[lRow, 4].Value); // BASE NAME
																														   //UPGRADE_TODO: (1067) Member txtBaseCode is not defined in type VB.Form. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						(updateForm as frm_AddAircraft).txtBaseCode[5].Text = Convert.ToString(grdJournal[lRow, 7].Value); // CITY

						//UPGRADE_TODO: (1067) Member cboBaseState is not defined in type VB.Form. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						(updateForm as frm_AddAircraft).cboBaseState.SelectedIndex = (-1); //gap-note this line must be checked in runtime to compare if the Listindex vb6 matches with this
						if (Convert.ToString(grdJournal[lRow, 5].Value) != "")
						{
							//UPGRADE_TODO: (1067) Member cboBaseState is not defined in type VB.Form. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
							double tempForEndVar3 = Convert.ToDouble((updateForm as frm_AddAircraft).cboBaseCountry.Items.Count) - 1;
							for (int i = 0; i <= tempForEndVar3; i++)
							{
								//UPGRADE_TODO: (1067) Member cboBaseState is not defined in type VB.Form. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								if (Convert.ToString((updateForm as frm_AddAircraft).cboBaseState.Items[i]).ToLower() == Convert.ToString(grdJournal[lRow, 5].Value).Trim().ToLower())//gap-note this line must be checked in runtime to compare if the comparison makes sense or requires to change it
								{
									//UPGRADE_TODO: (1067) Member cboBaseState is not defined in type VB.Form. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									(updateForm as frm_AddAircraft).cboBaseState.SelectedIndex = i;//gap-note this line must be checked in runtime to compare if the Listindex vb6 matches with this
									break;
								}
							}
						}

						//UPGRADE_TODO: (1067) Member cboBaseCountry is not defined in type VB.Form. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						(updateForm as frm_AddAircraft).cboBaseCountry.SelectedIndex = (-1);
						if (Convert.ToString(grdJournal[lRow, 6].Value) != "")
						{
							//UPGRADE_TODO: (1067) Member cboBaseCountry is not defined in type VB.Form. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
							double tempForEndVar4 = Convert.ToDouble((updateForm as frm_AddAircraft).cboBaseCountry.Items.Count) - 1;
							for (int i = 0; i <= tempForEndVar4; i++)
							{
								//UPGRADE_TODO: (1067) Member cboBaseCountry is not defined in type VB.Form. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
								if (Convert.ToString((updateForm as frm_AddAircraft).cboBaseCountry.Items[i]).ToLower() == Convert.ToString(grdJournal[lRow, 6].Value).Trim().ToLower())//gap-note this line must be checked in runtime to compare if the comparison makes sense or requires to change it
								{
									//UPGRADE_TODO: (1067) Member cboBaseCountry is not defined in type VB.Form. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
									(updateForm as frm_AddAircraft).cboBaseCountry.SelectedIndex = i;//gap-note this line must be checked in runtime to compare if the Listindex vb6 matches with this
									break;
								}
							}
						}

					} // ElseIf inEntryPoint = "AddAircraft" Then

				} // If grdJournal.TextMatrix(grdJournal.MouseRow, 0) <> "None Found" Then

				this.Close();
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"grdJournal_DblClick_Error: {excep.Message}", "JrnlPopup");
			}

		}
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}