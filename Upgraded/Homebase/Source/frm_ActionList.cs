using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
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
	internal partial class frm_ActionList
		: System.Windows.Forms.Form
	{

		//******************************************************************************************
		//******************************************************************************************


		//=====================
		// Check Box Constant
		//=====================
		private const int chkShowIQCompleted = 0;
		private const int chkExcludedReassigns = 1;
		private const int chkHideIQDeclined = 2;
		private const int chkOnlyShowCBForAvail = 3;
		private const int chkViewMasterList = 4;
		private const int chkClassA = 5;
		private const int chkAllCompanies = 6;
		private const int chkACNoCPExcludeReassigns = 7;
		private const int chkACNoBaseExcludeReassigns = 8;
		private const int chkViewDocsOrdered = 9;
		private const int chkViewDocsSending = 10;

		//==================
		// Public Variables
		//==================
		public ADORecordSetHelper snp_NewAssign = null;
		public ADORecordSetHelper snp_FractionsPending = null;
		public ADORecordSetHelper snp_WantedList = null;
		public ADORecordSetHelper snp_CompConfirm = null;
		public ADORecordSetHelper snp_HotItems = null;
		public ADORecordSetHelper snp_DocLog = null;

		public string FindId = "";

		//===================
		// Private Variables
		//===================
		private bool AlreadyLoaded = false;
		private bool HadHourglass = false;
		private bool Stopped = false;
		private int RememberExclusiveCompanyId = 0;
		private ADORecordSetHelper _snp_Callback = null;
		public frm_ActionList()
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
			isInitializingComponent = true;
			InitializeComponent();
			isInitializingComponent = false;
			ReLoadForm(false);
		}


		private ADORecordSetHelper snp_Callback
		{
			get
			{
				if (_snp_Callback is null)
				{
					_snp_Callback = new ADORecordSetHelper();
				}
				return _snp_Callback;
			}
			set => _snp_Callback = value;
		}

		private ADORecordSetHelper snp_ExclusiveCallback = null;
		private ADORecordSetHelper snp_UnverifiedCallback = null; // added MSW - 11/25/2020
		private ADORecordSetHelper adoFractionReassign = null;
		private string strOrderBy = "";
		private string strFractOrderBy = "";
		private string strReverifyOrderBy = "";
		private string strUnverifiedOrderBy = "";
		private string strReassignOrderBy = "";
		private string strEventsOrderBy = "";
		private bool HasBoundCallback = false; //aey 11/17/04

		ADORecordSetHelper snpFractional = null;
		private string LeaseAction = "";
		private string DocumentsOrderBy = "";
		private string DocResponseOrderBy = ""; //7/14/04 aey
		private string WantedOrderBy = "";
		private string tmpStart = "";
		private int tmpHowLong = 0;
		private int iHOTBoxSortCol = 0;

		bool Tab0 = false;
		bool Tab1 = false;
		bool Tab2 = false;
		bool Tab3 = false;
		bool Tab4 = false;
		bool Tab5 = false;
		bool Tab6 = false;
		bool Tab7 = false;
		bool Tab8 = false;
		bool Tab9 = false;
		bool Tab10 = false;
		bool Tab11 = false;

		string SortField1 = "";
		string SortField2 = "";
		string SortField3 = "";

		private bool mvHasFocus = false;
		private bool bIsFormLoad = false;

		private modGlobalVars.e_find_form_action_types tCompFind_ActionTypes = (modGlobalVars.e_find_form_action_types) 0;
		private modGlobalVars.e_find_form_entry_points tCompFind_EntryPoints = (modGlobalVars.e_find_form_entry_points) 0;

		string airbp_company_name = ""; // used for selection and display of air bp company - matt 8/26/2010
		bool bLog = false;

		private int gCompIdCol = 0;
		private int gJournIdCol = 0;
		private int gContactIdCol = 0;
		private int gACIdCol = 0;
		private int gAModIdCol = 0;

		private string is_compact_view = "";
		private string form_direction = "";
		public string make_account_rep_answer_string()
		{

			bool use_alt_rep = false;

			if (chk_alt_rep.CheckState == CheckState.Checked)
			{
				use_alt_rep = true;
				chk_alt_rep.Tag = modAdminCommon.return_top1_alt_account(modAdminCommon.gbl_Account_ID);
				lbl_gen[57].Text = Convert.ToString(chk_alt_rep.Tag);
			}
			else
			{
				chk_alt_rep.Tag = "0";
				lbl_gen[57].Text = "";
			}

			if (use_alt_rep)
			{
				return $" in ('{cbo_account_id.Text.Trim()}', '{lbl_gen[57].Text}')  ";
			}
			else
			{
				return $" = '{($"{cbo_account_id.Text} ").Trim()}' ";
			}


		}

		public void SetTab(int lTab)
		{
			if (lTab >= 0 && lTab <= 18)
			{
				SSTabHelper.SetSelectedIndex(tab_callback, lTab);
			}
		} // SetTab

		private void ClearPriorityEventsGrid()
		{


			grdPriorityEvents.FixedColumns = 0;
			grdPriorityEvents.FixedRows = 0;

			grdPriorityEvents.ColumnsCount = 4;
			grdPriorityEvents.RowsCount = 1;

			grdPriorityEvents.CurrentRowIndex = 0;

			grdPriorityEvents.CurrentColumnIndex = 0;
			grdPriorityEvents.CellBackColor = grdPriorityEvents.BackColorFixed;
			grdPriorityEvents.SetColumnWidth(grdPriorityEvents.CurrentColumnIndex, 200);
			grdPriorityEvents[grdPriorityEvents.CurrentRowIndex, grdPriorityEvents.CurrentColumnIndex].Value = "Make/Model";

			grdPriorityEvents.CurrentColumnIndex = 1;
			grdPriorityEvents.CellBackColor = grdPriorityEvents.BackColorFixed;
			grdPriorityEvents.SetColumnWidth(grdPriorityEvents.CurrentColumnIndex, 133);
			
			grdPriorityEvents.ColAlignment[1] = DataGridViewContentAlignment.TopLeft;
			grdPriorityEvents[grdPriorityEvents.CurrentRowIndex, grdPriorityEvents.CurrentColumnIndex].Value = "Serial #";

			grdPriorityEvents.CurrentColumnIndex = 2;
			grdPriorityEvents.CellBackColor = grdPriorityEvents.BackColorFixed;
			grdPriorityEvents.SetColumnWidth(grdPriorityEvents.CurrentColumnIndex, 467);
			grdPriorityEvents[grdPriorityEvents.CurrentRowIndex, grdPriorityEvents.CurrentColumnIndex].Value = "Subject - Description";

			grdPriorityEvents.CurrentColumnIndex = 3;
			grdPriorityEvents.CellBackColor = grdPriorityEvents.BackColorFixed;
			grdPriorityEvents.SetColumnWidth(grdPriorityEvents.CurrentColumnIndex, 133);
			grdPriorityEvents[grdPriorityEvents.CurrentRowIndex, grdPriorityEvents.CurrentColumnIndex].Value = "Date";


		}

		private void Fill_AvailableAircraft_Grid()
		{
			//
			// PURPOSE: THE PURPOSE OF THIS PROCEDURE IS TO CREATE STANDARD CALLBACK
			// LIST BUT FOR AVAILABLE AIRCRAFT ONLY.
			//
			// 6/30/03 - RTW - ADDED COMMENTS
			//                 ADDED BETTER ERROR TRAPS
			//                 CHANGED TO ADO
			// 9/15/2010 - RTW - MODIFIED QUERIES TO NOT USE CLASS C HELICOPTER QUERIES

			string Query = "";
			string cellcolor = "";
			int total = 0;
			ADORecordSetHelper snpAvailableAircraft = new ADORecordSetHelper();
			string strProductType = "";
			string strAcctRep = "";
			string strAcctRepId = "";

			string strMsg = "";
			System.DateTime dtStartDate = DateTime.FromOADate(0);
			System.DateTime dtEndDate = DateTime.FromOADate(0);

			try
			{

				modCommon.Start_Activity_Monitor_Message("Callback Available", ref strMsg, ref dtStartDate, ref dtEndDate);

				grd_AvailableAircraft.Visible = true;
				pnl_AvailableAircraft.Visible = true;
				cmdRefreshAvailAircraft.Enabled = false;

				string tempRefParam = "Available Aircraft Callbacks";
				search_on(ref tempRefParam);
				SSTabHelper.SetSelectedIndex(tab_callback, 8);

				lblAvailACTotal.Text = "Total: ";

				FindId = "Available Aircraft";
				grd_AvailableAircraft.Clear();
				grd_AvailableAircraft.ColumnsCount = 7;
				grd_AvailableAircraft.RowsCount = 2;
				grd_AvailableAircraft.FixedRows = 1;

				grd_AvailableAircraft.CurrentRowIndex = 0;

				grd_AvailableAircraft.CurrentColumnIndex = 0;
				grd_AvailableAircraft.SetColumnWidth(grd_AvailableAircraft.CurrentColumnIndex, 67);
				grd_AvailableAircraft[grd_AvailableAircraft.CurrentRowIndex, grd_AvailableAircraft.CurrentColumnIndex].Value = "Date";

				grd_AvailableAircraft.CurrentColumnIndex = 1;
				grd_AvailableAircraft.SetColumnWidth(grd_AvailableAircraft.CurrentColumnIndex, 267);
				grd_AvailableAircraft[grd_AvailableAircraft.CurrentRowIndex, grd_AvailableAircraft.CurrentColumnIndex].Value = "Company Name";

				grd_AvailableAircraft.CurrentColumnIndex = 2;
				grd_AvailableAircraft.SetColumnWidth(grd_AvailableAircraft.CurrentColumnIndex, 233);
				grd_AvailableAircraft[grd_AvailableAircraft.CurrentRowIndex, grd_AvailableAircraft.CurrentColumnIndex].Value = "City [Country]";

				grd_AvailableAircraft.CurrentColumnIndex = 3;
				grd_AvailableAircraft.SetColumnWidth(grd_AvailableAircraft.CurrentColumnIndex, 40);
				grd_AvailableAircraft[grd_AvailableAircraft.CurrentRowIndex, grd_AvailableAircraft.CurrentColumnIndex].Value = "State";

				grd_AvailableAircraft.CurrentColumnIndex = 4;
				grd_AvailableAircraft.SetColumnWidth(grd_AvailableAircraft.CurrentColumnIndex, 87);
				grd_AvailableAircraft[grd_AvailableAircraft.CurrentRowIndex, grd_AvailableAircraft.CurrentColumnIndex].Value = "Timezone";

				grd_AvailableAircraft.CurrentColumnIndex = 5;
				grd_AvailableAircraft.SetColumnWidth(grd_AvailableAircraft.CurrentColumnIndex, 67);
				grd_AvailableAircraft[grd_AvailableAircraft.CurrentRowIndex, grd_AvailableAircraft.CurrentColumnIndex].Value = "Last Called";

				grd_AvailableAircraft.CurrentColumnIndex = 6;
				grd_AvailableAircraft.SetColumnWidth(grd_AvailableAircraft.CurrentColumnIndex, 80);
				grd_AvailableAircraft[grd_AvailableAircraft.CurrentRowIndex, grd_AvailableAircraft.CurrentColumnIndex].Value = "IQ Last Attempt";

				grd_AvailableAircraft.CurrentColumnIndex = 0;

				lbl_Message.Text = "";
				Stopped = false;

				//aey 6/24/04 added prefixes to query field names

				// 03/24/2005 - By David D. Cruger; Adjusted Query to make it faster.
				Query = "SELECT DISTINCT ";
				Query = $"{Query}C1.comp_account_callback_date, ";
				Query = $"{Query}C1.comp_last_contact_date, ";
				Query = $"{Query}C1.comp_name, ";
				Query = $"{Query}C1.comp_id, ";
				Query = $"{Query}C1.comp_city, ";
				Query = $"{Query}C1.comp_state, ";
				Query = $"{Query}C1.comp_country, ";
				Query = $"{Query}C1.comp_journ_id, ";
				Query = $"{Query}C1.comp_timezone, ";
				Query = $"{Query}C1.comp_product_business_flag, ";
				Query = $"{Query}C1.comp_product_helicopter_flag, ";
				Query = $"{Query}C1.comp_product_commercial_flag ";

				Query = $"{Query}, (SELECT TOP 1 journ_date FROM Journal WITH (NOLOCK) ";
				Query = $"{Query} WHERE (journ_comp_id = C1.comp_id) ";
				Query = $"{Query} AND ( ";
				Query = $"{Query}       (journ_subcategory_code = 'IQ') ";
				Query = $"{Query}    OR (journ_subcategory_code = 'RN' AND journ_subject LIKE '%JNiQ%') ";
				Query = $"{Query}     ) ";
				Query = $"{Query} ORDER BY journ_date DESC ";
				Query = $"{Query}) As dtJNiQLastAttemptedDate ";



				// 07/18/2019 - By David D. Cruger; Removed INDEX HINT
				//Query = Query & "FROM Company AS C1 WITH (NOLOCK, INDEX(" & chr(34) & "ix_comp_callback_key" & chr(34) & ")) "
				Query = $"{Query}FROM Company AS C1 WITH (NOLOCK) ";
				Query = $"{Query}INNER JOIN Aircraft_Reference AS AR1 WITH (NOLOCK) ON AR1.cref_comp_id = C1.comp_id AND AR1.cref_journ_id = C1.comp_journ_id ";

				//added MSW - 5/30/18
				Query = $"{Query} and cref_primary_poc_flag = 'Y' ";
				Query = $"{Query}INNER JOIN Aircraft AS A1 WITH (NOLOCK) ON A1.ac_id = AR1.cref_ac_id AND A1.ac_journ_id = AR1.cref_journ_id ";

				//added MSW - 5/30/18
				Query = $"{Query} and ac_forsale_flag = 'Y'  and ac_last_verified_date <= '{DateTime.Parse(txt_Callback_Date.Text.Trim()).ToString("d")}' ";
				Query = $"{Query}INNER JOIN Aircraft_Model AS AM1 WITH (NOLOCK) ON AM1.amod_id = A1.ac_amod_id ";
				Query = $"{Query}WHERE (C1.comp_journ_id = 0) ";
				Query = $"{Query}AND  C1.comp_account_id  {make_account_rep_answer_string()}";
				Query = $"{Query}AND (C1.comp_account_callback_date <= '{DateTime.Parse(txt_Callback_Date.Text.Trim()).ToString("d")}') ";
				Query = $"{Query}AND ((C1.comp_last_contact_date < '{DateTime.Now.ToString("d")}') OR (C1.comp_last_contact_date IS NULL)) ";
				Query = $"{Query}AND (AR1.cref_primary_poc_flag = 'Y') ";
				Query = $"{Query}AND (A1.ac_forsale_flag = 'Y') ";

				strProductType = cmbProductType.Text.Substring(0, Math.Min(1, cmbProductType.Text.Length)).ToUpper();
				strAcctRep = cbo_account_id.Text.Substring(0, Math.Min(2, cbo_account_id.Text.Length)).ToUpper();
				strAcctRepId = cbo_account_id.Text.ToUpper();


				switch(strProductType)
				{
					case "A" :  // Business and Helicopter 
						Query = $"{Query}AND (A1.ac_product_business_flag = 'Y' OR A1.ac_product_helicopter_flag = 'Y') "; 
						 
						break;
					case "B" :  // Business Only 
						Query = $"{Query}AND (A1.ac_product_business_flag = 'Y') "; 
						 
						break;
					case "H" :  // Helicopter Only 
						Query = $"{Query}AND (A1.ac_product_helicopter_flag = 'Y') "; 
						 
						break;
					case "C" :  // Commercial Only 
						Query = $"{Query}AND (A1.ac_product_commercial_flag = 'Y') "; 
						 
						break;
					case "Q" :  // JNiQ Eligible 
						Query = $"{Query}{modCommon.Return_JNiQ_Eligible_Query(strAcctRep, Query)}"; 
						 
						break;
					case "N" :  // Non-JNiQ Eligible 
						Query = $"{Query}{modCommon.Return_Non_JNiQ_Eligible_Query()}"; 
						 
						break;
					case "P" :  // AirBP 
						Query = $"{Query}AND (A1.ac_product_airbp_flag = 'Y') "; 
						 
						break;
					case "L" :  // All Aircraft 
						 
						break;
				} // Case strProductType

				if (strProductType.Trim() == "A" || strProductType.Trim() == "B" || strProductType.Trim() == "H" || strProductType.Trim() == "C")
				{
					Query = $"{Query}  and not exists(";
					Query = $"{Query} select top 1 ar1.cref_ac_id  from Aircraft_Reference ar1 with (NOLOCK) ";
					Query = $"{Query} INNER JOIN Aircraft AS A2 WITH (NOLOCK) ON A2.ac_id = ar1.cref_ac_id AND A2.ac_journ_id = ar1.cref_journ_id ";
					Query = $"{Query} Where ar1.cref_ac_id <> A1.AC_ID And ar1.cref_comp_id = C1.Comp_id ";

					switch(strProductType)
					{
						case "A" :  // Business and Helicopter 
							Query = $"{Query}AND (A1.ac_product_business_flag <> 'Y' OR A1.ac_product_helicopter_flag <> 'Y') "; 
							break;
						case "B" :  // Business Only 
							Query = $"{Query}AND (A1.ac_product_business_flag <> 'Y') "; 
							break;
						case "H" :  // Helicopter Only 
							Query = $"{Query}AND (A1.ac_product_helicopter_flag <> 'Y') "; 
							break;
						case "C" :  // Commercial Only 
							Query = $"{Query}AND (A1.ac_product_commercial_flag  <>'Y') "; 
							break;
					} // Case strProductType
					Query = $"{Query} ) ";
				}

				Query = $"{Query}{strOrderBy}";

				modAdminCommon.Record_Event("Monitor Activity", $"ExpAvailable Aircraft - Selected AcctRep: {strAcctRepId}");
				//Record_Event "HB Usage", "ExpAvailable Aircraft - Selected AcctRep: " & strAcctRepId

				snpAvailableAircraft.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!snpAvailableAircraft.BOF && !snpAvailableAircraft.EOF)
				{

					cellcolor = modAdminCommon.NoColor;
					pnl_AvailableAircraft.Visible = true;
					cmdStop.Visible = true;
					total = 0;

					grd_AvailableAircraft.CurrentRowIndex = 1;
					grd_AvailableAircraft.Redraw = false;


					while(!snpAvailableAircraft.EOF)
					{

						if (Stopped)
						{
							Stopped = false;
							break;
						}

						cellcolor = modAdminCommon.NoColor;

						grd_AvailableAircraft.CurrentColumnIndex = 0;
						grd_AvailableAircraft.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
						grd_AvailableAircraft[grd_AvailableAircraft.CurrentRowIndex, grd_AvailableAircraft.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snpAvailableAircraft["comp_account_callback_date"]))
						{
							if (Information.IsDate(snpAvailableAircraft["comp_account_callback_date"]))
							{
								grd_AvailableAircraft[grd_AvailableAircraft.CurrentRowIndex, grd_AvailableAircraft.CurrentColumnIndex].Value = Convert.ToDateTime(snpAvailableAircraft["comp_account_callback_date"]).ToString("d").Trim();
							}
						}

						grd_AvailableAircraft.CurrentColumnIndex = 1;
						grd_AvailableAircraft.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						grd_AvailableAircraft.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
						grd_AvailableAircraft[grd_AvailableAircraft.CurrentRowIndex, grd_AvailableAircraft.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snpAvailableAircraft["Comp_Name"]))
						{
							if (Convert.ToString(snpAvailableAircraft["Comp_Name"]).Trim() != modGlobalVars.cEmptyString)
							{
								grd_AvailableAircraft[grd_AvailableAircraft.CurrentRowIndex, grd_AvailableAircraft.CurrentColumnIndex].Value = Convert.ToString(snpAvailableAircraft["Comp_Name"]).Trim();
							}
						}

						grd_AvailableAircraft.CurrentColumnIndex = 2;
						grd_AvailableAircraft.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
						grd_AvailableAircraft[grd_AvailableAircraft.CurrentRowIndex, grd_AvailableAircraft.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snpAvailableAircraft["comp_city"]))
						{
							if (Convert.ToString(snpAvailableAircraft["comp_city"]).Trim() != modGlobalVars.cEmptyString)
							{
								grd_AvailableAircraft[grd_AvailableAircraft.CurrentRowIndex, grd_AvailableAircraft.CurrentColumnIndex].Value = Convert.ToString(snpAvailableAircraft["comp_city"]).Trim();
							}
						}
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snpAvailableAircraft["comp_country"]))
						{
							if (Convert.ToString(snpAvailableAircraft["comp_country"]).Trim() != modGlobalVars.cEmptyString)
							{
								grd_AvailableAircraft[grd_AvailableAircraft.CurrentRowIndex, grd_AvailableAircraft.CurrentColumnIndex].Value = $"{grd_AvailableAircraft[grd_AvailableAircraft.CurrentRowIndex, grd_AvailableAircraft.CurrentColumnIndex].FormattedValue.ToString()} [{Convert.ToString(snpAvailableAircraft["comp_country"]).Trim()}]";
							}
						}

						grd_AvailableAircraft.CurrentColumnIndex = 3;
						grd_AvailableAircraft.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
						grd_AvailableAircraft[grd_AvailableAircraft.CurrentRowIndex, grd_AvailableAircraft.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snpAvailableAircraft["comp_state"]))
						{
							if (Convert.ToString(snpAvailableAircraft["comp_state"]).Trim() != modGlobalVars.cEmptyString)
							{
								grd_AvailableAircraft[grd_AvailableAircraft.CurrentRowIndex, grd_AvailableAircraft.CurrentColumnIndex].Value = Convert.ToString(snpAvailableAircraft["comp_state"]).Trim();
							}
						}

						grd_AvailableAircraft.CurrentColumnIndex = 4;
						grd_AvailableAircraft.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
						grd_AvailableAircraft[grd_AvailableAircraft.CurrentRowIndex, grd_AvailableAircraft.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snpAvailableAircraft["comp_timezone"]))
						{
							if (Convert.ToString(snpAvailableAircraft["comp_timezone"]).Trim() != modGlobalVars.cEmptyString)
							{
								grd_AvailableAircraft[grd_AvailableAircraft.CurrentRowIndex, grd_AvailableAircraft.CurrentColumnIndex].Value = Convert.ToString(snpAvailableAircraft["comp_timezone"]).Trim();
							}
						}

						grd_AvailableAircraft.CurrentColumnIndex = 5;
						grd_AvailableAircraft.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
						grd_AvailableAircraft[grd_AvailableAircraft.CurrentRowIndex, grd_AvailableAircraft.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snpAvailableAircraft["comp_last_contact_date"]))
						{
							if (Convert.ToString(snpAvailableAircraft["comp_last_contact_date"]).Trim() != modGlobalVars.cEmptyString)
							{
								grd_AvailableAircraft[grd_AvailableAircraft.CurrentRowIndex, grd_AvailableAircraft.CurrentColumnIndex].Value = Convert.ToString(snpAvailableAircraft["comp_last_contact_date"]).Trim();
							}
						}

						grd_AvailableAircraft.CurrentColumnIndex = 6;
						grd_AvailableAircraft.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
						grd_AvailableAircraft[grd_AvailableAircraft.CurrentRowIndex, grd_AvailableAircraft.CurrentColumnIndex].Value = modGlobalVars.cEmptyString;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snpAvailableAircraft["dtJNiQLastAttemptedDate"]))
						{
							if (Convert.ToString(snpAvailableAircraft["dtJNiQLastAttemptedDate"]).Trim() != modGlobalVars.cEmptyString)
							{
								grd_AvailableAircraft[grd_AvailableAircraft.CurrentRowIndex, grd_AvailableAircraft.CurrentColumnIndex].Value = Convert.ToDateTime(snpAvailableAircraft["dtJNiQLastAttemptedDate"]).ToString("MM/dd/yyyy");
							}
						}


						grd_AvailableAircraft.set_RowData(grd_AvailableAircraft.CurrentRowIndex, Convert.ToInt32(snpAvailableAircraft["Comp_id"]));

						grd_AvailableAircraft.CurrentRowIndex = grd_AvailableAircraft.RowsCount - 1;

						grd_AvailableAircraft.CurrentColumnIndex = 2;

						if (grd_AvailableAircraft[grd_AvailableAircraft.CurrentRowIndex, grd_AvailableAircraft.CurrentColumnIndex].FormattedValue.ToString().IndexOf("[]") >= 0)
						{
							grd_AvailableAircraft[grd_AvailableAircraft.CurrentRowIndex, grd_AvailableAircraft.CurrentColumnIndex].Value = grd_AvailableAircraft[grd_AvailableAircraft.CurrentRowIndex, grd_AvailableAircraft.CurrentColumnIndex].FormattedValue.ToString().Substring(0, Math.Min(Strings.Len(grd_AvailableAircraft[grd_AvailableAircraft.CurrentRowIndex, grd_AvailableAircraft.CurrentColumnIndex].FormattedValue.ToString()) - 2, grd_AvailableAircraft[grd_AvailableAircraft.CurrentRowIndex, grd_AvailableAircraft.CurrentColumnIndex].FormattedValue.ToString().Length)).Trim();
						}

						snpAvailableAircraft.MoveNext();

						grd_AvailableAircraft.RowsCount++;
						grd_AvailableAircraft.CurrentRowIndex++;

						total++;
						lblAvailACTotal.Text = $"Total: {total.ToString()}";

						if (total == 22)
						{
							grd_AvailableAircraft.Redraw = true;
							grd_AvailableAircraft.Refresh();
							Application.DoEvents();
							grd_AvailableAircraft.Redraw = false;
						}

					}; // Do While Not snpAvailableAircraft.EOF

					grd_AvailableAircraft.Redraw = true;
					cmdStop.Visible = false;

					grd_AvailableAircraft.RowsCount--;

				}
				else
				{
					grd_AvailableAircraft.CurrentRowIndex = 1;
					grd_AvailableAircraft.CurrentColumnIndex = 1;
					grd_AvailableAircraft[grd_AvailableAircraft.CurrentRowIndex, grd_AvailableAircraft.CurrentColumnIndex].Value = "No Available Aircraft Found";
					cmd_Update_Callback_Dates.Visible = false;
				} // If (snpAvailableAircraft.BOF = False And snpAvailableAircraft.EOF = False) Then

				snpAvailableAircraft.Close();
				snpAvailableAircraft = null;

				strMsg = $"AcctRep: {cbo_account_id.Text}";
				strMsg = $"{strMsg} Product: {cmbProductType.Text}";
				strMsg = $"{strMsg} Callback Date: {txt_Callback_Date.Text}";

				if (bLog)
				{

					modCommon.End_Activity_Monitor_Message("Callback Available", ref strMsg, dtStartDate, ref dtEndDate, 0, 0, 0, 0, 0);

					frm_UserHistory.DefInstance.Refresh_User_History_Grids("Callback");

				}

				grd_AvailableAircraft.Redraw = true;

				HadHourglass = false;
				cmdRefreshAvailAircraft.Enabled = true;

				search_off();
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_AvailableAircraft_Grid_Error ({Information.Err().Number.ToString()}) {excep.Message} acctid[{cbo_account_id.Text.Trim()}]", "frm_ActionList(AIRCRAFT)");
				search_off();
			}

		}

		public void Fill_Document_Responses()
		{
			//******************************************************************************************
			//* Note: VBC id'd the following unreferenced items and handled them as described:         *
			//*                                                                                        *
			//* Local Variables (Removed)                                                              *
			//*  CompanyCellColor              CompAddress                   TempACID                  *
			//*  GotTotal                      i                                                       *
			//******************************************************************************************

			int TotFound = 0;
			string Query = "";
			string cellcolor = "";
			string strProductType = "";
			string strClass = "";
			string strAcctRep = "";
			string strAcctRepId = "";

			try
			{

				if (DocResponseOrderBy == "")
				{
					DocResponseOrderBy = "ORDER BY journ_date DESC, journ_id DESC";
				}

				lbl_Documents_In_Process.Text = "Searching for Documents ...";
				Stopped = false;
				cellcolor = modAdminCommon.NoColor;
				this.Cursor = Cursors.WaitCursor;
				cmd_DocsInProcessRefresh.PerformClick();

				strAcctRep = cbo_account_id.Text.Substring(0, Math.Min(2, cbo_account_id.Text.Length)).ToUpper();
				strAcctRepId = cbo_account_id.Text.ToUpper();

				TotFound = 0;
				grd_DocumentLog.Clear();
				grd_DocumentLog.Visible = false;

				grd_DocumentLog.ColumnsCount = 4;
				grd_DocumentLog.RowsCount = 2;
				grd_DocumentLog.FixedRows = 1;

				grd_DocumentLog.CurrentRowIndex = 0;

				grd_DocumentLog.CurrentColumnIndex = 0;
				grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = "Make/Model-Serial#";
				grd_DocumentLog.DefaultCellStyle.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_DocumentLog.SetColumnWidth(grd_DocumentLog.CurrentColumnIndex, 267);

				grd_DocumentLog.CurrentColumnIndex = 1;
				grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = "Journal Date [Journal ID]";
				grd_DocumentLog.DefaultCellStyle.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_DocumentLog.SetColumnWidth(grd_DocumentLog.CurrentColumnIndex, 153);

				grd_DocumentLog.CurrentColumnIndex = 2;
				grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = "Journal User";
				grd_DocumentLog.DefaultCellStyle.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_DocumentLog.SetColumnWidth(grd_DocumentLog.CurrentColumnIndex, 67);

				grd_DocumentLog.CurrentColumnIndex = 3;
				grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = "Notes";
				grd_DocumentLog.DefaultCellStyle.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_DocumentLog.SetColumnWidth(grd_DocumentLog.CurrentColumnIndex, 533);

				grd_DocumentLog.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

				Query = "SELECT DISTINCT ";
				Query = $"{Query}FDL1.faalog_ac_id, ";
				Query = $"{Query}AM1.amod_make_name, ";
				Query = $"{Query}AM1.amod_model_name, ";
				Query = $"{Query}A1.ac_ser_no_full, ";
				Query = $"{Query}A1.ac_id, ";
				Query = $"{Query}J1.journ_subject, ";
				Query = $"{Query}J1.journ_date, ";
				Query = $"{Query}J1.journ_user_id, ";
				Query = $"{Query}J1.journ_id ";


				Query = $"{Query}FROM FAA_Document_Log AS FDL1 WITH (NOLOCK) ";
				Query = $"{Query}INNER JOIN Aircraft AS A1 WITH (NOLOCK) ON A1.ac_id = FDL1.faalog_ac_id AND A1.ac_journ_id = FDL1.faalog_journ_id ";
				Query = $"{Query}INNER JOIN Aircraft_Model AS AM1 WITH (NOLOCK) ON AM1.amod_id = A1.ac_amod_id ";
				Query = $"{Query}INNER JOIN Journal AS J1 WITH (NOLOCK) ON J1.journ_ac_id = A1.ac_id ";
				Query = $"{Query}WHERE (J1.journ_subcategory_code = 'RDR') ";

				strProductType = cmbProductType.Text.Substring(0, Math.Min(1, cmbProductType.Text.Length)).ToUpper();


				switch(strProductType)
				{
					case "A" :  // Business and Helicopter 
						Query = $"{Query}AND (A1.ac_product_business_flag = 'Y' OR A1.ac_product_helicopter_flag = 'Y') "; 
						 
						break;
					case "B" :  // Business Only 
						Query = $"{Query}AND (A1.ac_product_business_flag = 'Y') "; 
						 
						break;
					case "H" :  // Helicopter Only 
						Query = $"{Query}AND (A1.ac_product_helicopter_flag = 'Y') "; 
						 
						break;
					case "C" :  // Commercial Only 
						Query = $"{Query}AND (A1.ac_product_commercial_flag = 'Y') "; 
						 
						break;
					case "Q" :  // JNiQ Eligible 
						// Does NOT Exist For Document Responses 
						 
						break;
					case "N" :  // Non-JNiQ Eligible 
						// Does NOT Exist For Document Responses 
						 
						break;
					case "P" :  // AirBP 
						Query = $"{Query}AND (A1.ac_product_airbp_flag = 'Y') "; 
						 
						break;
					case "L" :  // All Aircraft 
						 
						break;
				} // Case strProductType

				// 01/12/2016 - By David D. Cruger
				// Added Class Search

				strClass = cmbDocInProcsClass.Text.ToUpper();
				if (strClass != "ALL")
				{
					Query = $"{Query}AND (AM1.amod_class_code = '{strClass.Substring(Math.Max(strClass.Length - 1, 0))}') ";
				}

				Query = $"{Query}{DocResponseOrderBy}";

				modAdminCommon.Record_Event("Monitor Activity", $"Document Responses - Selected AcctRep: {strAcctRepId}");
				//Record_Event "HB Usage", "Document Responses - Selected AcctRep: " & strAcctRepId

				snp_DocLog = new ADORecordSetHelper();
				snp_DocLog.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
				TotFound = 0;
				if (!(snp_DocLog.BOF && snp_DocLog.EOF))
				{

					grd_DocumentLog.CurrentRowIndex = 1;

					cmdStop.Visible = true;


					while(!snp_DocLog.EOF)
					{

						Application.DoEvents();
						if (Stopped)
						{
							Stopped = false;
							this.Cursor = CursorHelper.CursorDefault;
							break;
						}
						TotFound++;
						lbl_Documents_In_Process.Text = $"{TotFound.ToString()} Documents Selected.";




						// MAKE/MODEL-SERIAL #
						grd_DocumentLog.CurrentColumnIndex = 0;
						grd_DocumentLog.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
						grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = "";
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snp_DocLog["amod_make_name"]))
						{
							if (Convert.ToString(snp_DocLog["amod_make_name"]).Trim() != modGlobalVars.cEmptyString)
							{
								grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = Convert.ToString(snp_DocLog["amod_make_name"]).Trim();
							}
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snp_DocLog["amod_model_name"]))
						{
							if (Convert.ToString(snp_DocLog["amod_model_name"]).Trim() != modGlobalVars.cEmptyString)
							{
								grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = $"{grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].FormattedValue.ToString()}/{Convert.ToString(snp_DocLog["amod_model_name"]).Trim()}";
							}
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snp_DocLog["ac_ser_no_full"]))
						{
							if (Convert.ToString(snp_DocLog["ac_ser_no_full"]).Trim() != modGlobalVars.cEmptyString)
							{
								grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = $"{grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].FormattedValue.ToString()}-{Convert.ToString(snp_DocLog["ac_ser_no_full"]).Trim()}";
							}
						}

						grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = $"{grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].FormattedValue.ToString()} [ID:{Convert.ToString(snp_DocLog["ac_id"])}]";

						grd_DocumentLog.CurrentColumnIndex = 1;
						grd_DocumentLog.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
						grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = "";
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snp_DocLog["journ_date"]))
						{
							if (Information.IsDate(snp_DocLog["journ_date"]))
							{
								grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = DateTime.Parse(Convert.ToString(snp_DocLog["journ_date"]).Trim()).ToString("d");
							}
						}
						grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = $"{grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].FormattedValue.ToString()} [{Convert.ToString(snp_DocLog["journ_id"])}]";

						grd_DocumentLog.CurrentColumnIndex = 2;
						grd_DocumentLog.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
						grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = "";
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snp_DocLog["journ_user_id"]))
						{
							if (Convert.ToString(snp_DocLog["journ_user_id"]).Trim() != modGlobalVars.cEmptyString)
							{
								grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = Convert.ToString(snp_DocLog["journ_user_id"]).Trim();
							}
						}

						// NOTES
						grd_DocumentLog.CurrentColumnIndex = 3;
						
						grd_DocumentLog.ColAlignment[3] = DataGridViewContentAlignment.TopLeft;
						grd_DocumentLog.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
						grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = "";
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snp_DocLog["journ_subject"]))
						{
							if (Convert.ToString(snp_DocLog["journ_subject"]).Trim() != modGlobalVars.cEmptyString)
							{
								grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = Convert.ToString(snp_DocLog["journ_subject"]).Trim();
							}
						}

						grd_DocumentLog.set_RowData(grd_DocumentLog.CurrentRowIndex, Convert.ToInt32(snp_DocLog["ac_id"]));
						//UPGRADE_ISSUE: (2064) MSHierarchicalFlexGridLib.MSHFlexGrid property grd_DocumentLog.BandData was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						grd_DocumentLog.setBandData(Convert.ToInt32(snp_DocLog["journ_id"]), grd_DocumentLog.CurrentRowIndex);

						grd_DocumentLog.RowsCount++;
						grd_DocumentLog.CurrentRowIndex++;

						snp_DocLog.MoveNext();

					};

					grd_DocumentLog.RowsCount--;
					grd_DocumentLog.CurrentRowIndex = 1;
					grd_DocumentLog.CurrentColumnIndex = 0;
					grd_DocumentLog.Visible = true;

				}
				else
				{
					// no document log matches found

					grd_DocumentLog.CurrentRowIndex = 1;
					grd_DocumentLog.CurrentColumnIndex = 0;
					grd_DocumentLog.Visible = false;
					lbl_Documents_In_Process.Text = "No Documents Found.";

				} // if document log matches found

				cmdStop.Visible = false;
				grd_DocumentLog.Redraw = true;
				cmd_DocsInProcessRefresh.PerformClick();

				HadHourglass = false;

				search_off();
			}
			catch (Exception e)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				if (Information.Err().Number == 3146)
				{
					MessageBox.Show($"There are too many records to display.{Environment.NewLine}{Environment.NewLine}Please refine your search criteria and try again.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}
				else
				{
					MessageBox.Show($"Fill Aircraft Grid Error fill Doc Resp: {Environment.NewLine}{Environment.NewLine}{e.Message}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}

				this.Cursor = CursorHelper.CursorDefault;
			}
		}

		private void Fill_Fractional_ReAssign_Grid()
		{
			//******************************************************************************************
			//* Note: VBC id'd the following unreferenced items and handled them as described:         *
			//*                                                                                        *
			//* Local Variables (Removed)                                                              *
			//*  TotalAircraft                                                                         *
			//******************************************************************************************

			//----------------------------------------------------------------------------------------------
			//Function used to fill the Fractional Grid
			//----------------------------------------------------------------------------------------------

			try
			{

				double TotalCompCallBacks = 0;

				string tempRefParam = "Fractional Company Re-Assigns";
				search_on(ref tempRefParam);

				string Query = "";
				string cellcolor = "";

				lbl_fract_col5.Text = "";
				lbl_fract_col6.Text = "";
				lbl_fract_col7.Text = "#A/C";
				lbl_fract_col8.Text = "";
				Label8.Text = "";
				Label15.Text = "";

				cellcolor = modAdminCommon.NoColor;
				FindId = "Fractional Reassign";
				SSTabHelper.SetSelectedIndex(tab_callback, 6);
				TotalCompCallBacks = 0;
				txt_Total_Comp_Callbacks.Text = "";
				Stopped = false;

				grdFractional.Clear();

				grdFractional.ColumnsCount = 8;
				grdFractional.RowsCount = 1;

				grdFractional.CurrentRowIndex = 0;
				grdFractional.CurrentColumnIndex = 0;

				grdFractional.SetColumnWidth(0, 67);
				grdFractional.SetColumnWidth(1, 167);
				grdFractional.SetColumnWidth(2, 100);
				grdFractional.SetColumnWidth(3, 33);
				grdFractional.SetColumnWidth(4, 267);
				grdFractional.SetColumnWidth(5, 67);
				grdFractional.SetColumnWidth(6, 0);
				grdFractional.SetColumnWidth(7, 0);
				//   Query = "select distinct c.comp_id, c.comp_account_callback_date, c.comp_name, c.comp_city, c.comp_state, c.comp_timezone, c.comp_fractowr_id, j.journ_date,j.journ_subject,j.journ_id , count(*) as aircraft_count "
				//   Query = Query & "From Journal as J WITH(NOLOCK),  Company as C ,Aircraft_Reference as R, Aircraft as A "
				//   Query = Query & "Where journ_subcategory_code='FR' "
				//   Query = Query & "and  c.comp_id = j.journ_comp_id and c.comp_journ_id=0 "
				//   Query = Query & "and (c.comp_id = r.cref_comp_id And c.comp_journ_id = r.cref_journ_id) "
				//   Query = Query & "and (r.cref_ac_id=a.ac_id and r.cref_journ_id=a.ac_journ_id) "

				//frac re-assign
				Query = "select distinct c.comp_id, c.comp_account_callback_date, c.comp_name, c.comp_city, c.comp_state, c.comp_timezone, c.comp_fractowr_id, j.journ_date,j.journ_subject,j.journ_id , count(*) as aircraft_count ";
				Query = $"{Query}From Journal as J WITH(NOLOCK) ";
				Query = $"{Query}inner join Company as C WITH(NOLOCK) on (c.comp_id = j.journ_comp_id) ";
				Query = $"{Query}inner join Aircraft_Reference as R WITH(NOLOCK) on (c.comp_id = r.cref_comp_id And c.comp_journ_id = r.cref_journ_id)";
				Query = $"{Query}inner join Aircraft as A WITH(NOLOCK) on (r.cref_ac_id=a.ac_id and r.cref_journ_id=a.ac_journ_id)";
				Query = $"{Query}inner join Aircraft_model as M WITH(NOLOCK) on (M.amod_id=a.ac_amod_id) ";
				Query = $"{Query}Where j.journ_subcategory_code='FR' and  c.comp_journ_id=0 ";
				if (cmbProductType.Text.StartsWith("L", StringComparison.Ordinal))
				{ //aey 10/17/05
				}
				else if (cmbProductType.Text.StartsWith("A", StringComparison.Ordinal))
				{  //aey 10/17/05
					Query = $"{Query}AND a.ac_use_code <> 'C'  ";
					Query = $"{Query}AND (m.amod_airframe_type_code = 'F' or (m.amod_airframe_type_code = 'R' AND m.amod_class_code='A')) ";
					Query = $"{Query}AND c.comp_id not in(select distinct c2.comp_id From Journal as J2 WITH(NOLOCK) ";
					Query = $"{Query}inner join Company as C2 WITH(NOLOCK) on (c2.comp_id = j2.journ_comp_id) ";
					Query = $"{Query}inner join Aircraft_Reference as R2 WITH(NOLOCK) on (c2.comp_id = r2.cref_comp_id And c2.comp_journ_id = r2.cref_journ_id)";
					Query = $"{Query}inner join Aircraft as A2 WITH(NOLOCK) on (r2.cref_ac_id=a2.ac_id and r2.cref_journ_id=a2.ac_journ_id)";
					Query = $"{Query}Where j2.journ_subcategory_code='FR' and  c2.comp_journ_id=0 ";
					Query = $"{Query}AND a2.ac_use_code = 'C' ) ";
				}
				else if (cmbProductType.Text.StartsWith("B", StringComparison.Ordinal))
				{ 
					Query = $"{Query}AND m.amod_airframe_type_code = 'F' ";
				}
				else if (cmbProductType.Text.StartsWith("H", StringComparison.Ordinal))
				{ 
					Query = $"{Query}AND m.amod_airframe_type_code = 'R' AND m.amod_class_code='A' ";
					Query = $"{Query}AND c.comp_id not in(select distinct c2.comp_id From Journal as J2 WITH(NOLOCK) ";
					Query = $"{Query}inner join Company as C2 WITH(NOLOCK) on (c2.comp_id = j2.journ_comp_id) ";
					Query = $"{Query}inner join Aircraft_Reference as R2 WITH(NOLOCK) on (c2.comp_id = r2.cref_comp_id And c2.comp_journ_id = r2.cref_journ_id)";
					Query = $"{Query}inner join Aircraft as A2 WITH(NOLOCK) on (r2.cref_ac_id=a2.ac_id and r2.cref_journ_id=a2.ac_journ_id)";
					Query = $"{Query}inner join Aircraft_model as M2 WITH(NOLOCK) on (M2.amod_id=a2.ac_amod_id) ";
					Query = $"{Query}Where j2.journ_subcategory_code='FR' and  c2.comp_journ_id=0 ";
					Query = $"{Query}AND m2.amod_airframe_type_code = 'F') ";
				}
				else if (cmbProductType.Text.StartsWith("C", StringComparison.Ordinal))
				{ 
					Query = $"{Query}AND a.ac_use_code='C'  ";
					Query = $"{Query}AND c.comp_id not in(select distinct c2.comp_id From Journal as J2 WITH(NOLOCK) ";
					Query = $"{Query}inner join Company as C2 WITH(NOLOCK) on (c2.comp_id = j2.journ_comp_id) ";
					Query = $"{Query}inner join Aircraft_Reference as R2 WITH(NOLOCK) on (c2.comp_id = r2.cref_comp_id And c2.comp_journ_id = r2.cref_journ_id)";
					Query = $"{Query}inner join Aircraft as A2 WITH(NOLOCK) on (r2.cref_ac_id=a2.ac_id and r2.cref_journ_id=a2.ac_journ_id)";
					//Query = Query & "inner join Aircraft_model as M2 WITH(NOLOCK) on (M2.amod_id=a2.ac_amod_id) "
					Query = $"{Query}Where j2.journ_subcategory_code='FR' and  c2.comp_journ_id=0 ";
					Query = $"{Query}AND a2.ac_use_code <>'C' ) ";
				}

				Query = $"{Query}group by c.comp_id, c.comp_account_callback_date, c.comp_name, c.comp_city, c.comp_state, c.comp_timezone, c.comp_fractowr_id, j.journ_date,j.journ_subject,j.journ_id ";
				Query = $"{Query}order by c.comp_id, c.comp_account_callback_date, c.comp_name, c.comp_city, c.comp_state, c.comp_timezone, c.comp_fractowr_id, j.journ_date,j.journ_subject,j.journ_id ";

				//MsgBox ("Here - " & Query)
				adoFractionReassign = new ADORecordSetHelper();
				adoFractionReassign.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

				if (!(adoFractionReassign.BOF && adoFractionReassign.EOF))
				{
					pnl_fractional_display.Visible = true;
					// adoFractionReassign.MoveLast
					adoFractionReassign.MoveFirst();
					cmdStop.Visible = true;


					while(!adoFractionReassign.EOF)
					{
						if (Stopped)
						{
							Stopped = false;
							break;
						}

						//fill grid

						grdFractional.CurrentColumnIndex = 0;
						grdFractional.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
						grdFractional[grdFractional.CurrentRowIndex, grdFractional.CurrentColumnIndex].Value = Convert.ToDateTime(adoFractionReassign["journ_date"]).ToString("d");
						grdFractional.CurrentColumnIndex = 1;
						grdFractional.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						grdFractional.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
						grdFractional[grdFractional.CurrentRowIndex, grdFractional.CurrentColumnIndex].Value = ($"{Convert.ToString(adoFractionReassign["comp_name"])} ").Trim();
						grdFractional.CurrentColumnIndex = 2;
						grdFractional.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						grdFractional.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
						grdFractional[grdFractional.CurrentRowIndex, grdFractional.CurrentColumnIndex].Value = ($"{Convert.ToString(adoFractionReassign["Comp_city"])} ").Trim();
						grdFractional.CurrentColumnIndex = 3;
						grdFractional.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						grdFractional.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
						grdFractional[grdFractional.CurrentRowIndex, grdFractional.CurrentColumnIndex].Value = ($"{Convert.ToString(adoFractionReassign["comp_state"])} ").Trim();
						grdFractional.CurrentColumnIndex = 4;
						grdFractional.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						grdFractional.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
						grdFractional[grdFractional.CurrentRowIndex, grdFractional.CurrentColumnIndex].Value = ($"{Convert.ToString(adoFractionReassign["journ_subject"])} ").Trim();
						grdFractional.CurrentColumnIndex = 5;
						grdFractional.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						grdFractional.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
						grdFractional[grdFractional.CurrentRowIndex, grdFractional.CurrentColumnIndex].Value = $" {Convert.ToString(adoFractionReassign["aircraft_count"])} ";
						grdFractional.CurrentColumnIndex = 6;
						grdFractional[grdFractional.CurrentRowIndex, grdFractional.CurrentColumnIndex].Value = adoFractionReassign.GetField("comp_id");
						grdFractional.CurrentColumnIndex = 7;
						grdFractional[grdFractional.CurrentRowIndex, grdFractional.CurrentColumnIndex].Value = adoFractionReassign.GetField("journ_id");


						TotalCompCallBacks++;
						txt_Total_Comp_Callbacks.Text = TotalCompCallBacks.ToString();
						adoFractionReassign.MoveNext();
						grdFractional.RowsCount++;
						grdFractional.CurrentRowIndex++;
					};
					cmdStop.Visible = false;
					grdFractional.RowsCount--;

				}
				else
				{
					pnl_fractional_display.Visible = false;
					//UPGRADE_ISSUE: (2064) Threed.SSPanel property pnl_Fractional.Caption was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					pnl_Fractional.setCaption("NO COMPANY RE-ASSIGNS");
				}

				pnl_Fractional.Visible = true;

				adoFractionReassign.Close();
				adoFractionReassign = null;

				grdFractional.Redraw = true;

				search_off();
			}
			catch (System.Exception excep)
			{

				adoFractionReassign = null;
				search_off();
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_Fractional_ReAssign_Grid_Error: {Information.Err().Number.ToString()} {excep.Message}");
			}

		}

		private void Fill_FracWithPrimaryWhole_Grid()
		{
			//******************************************************************************************
			//* Note: VBC id'd the following unreferenced items and handled them as described:         *
			//*                                                                                        *
			//* Local Variables (Removed)                                                              *
			//*  TotalAircraft                                                                         *
			//******************************************************************************************

			//----------------------------------------------------------------------------------------------
			//Function used to fill the Fractional Grid
			//----------------------------------------------------------------------------------------------

			try
			{

				double TotalCompCallBacks = 0;

				string tempRefParam = "Fractional Companies Primary on Whole/Share";
				search_on(ref tempRefParam);

				string Query = "";
				string cellcolor = "";

				lbl_fract_col5.Text = "#A/C";
				lbl_fract_col6.Text = "";
				lbl_fract_col7.Text = "";
				lbl_fract_col8.Text = "";
				Label8.Text = "";
				Label15.Text = "";

				cellcolor = modAdminCommon.NoColor;
				FindId = "Fractional Account Companies which are Primary on Whole A/C";
				SSTabHelper.SetSelectedIndex(tab_callback, 6);
				TotalCompCallBacks = 0;
				txt_Total_Comp_Callbacks.Text = "";
				Stopped = false;

				grdFractional.Clear();

				grdFractional.ColumnsCount = 7;
				grdFractional.RowsCount = 1;

				grdFractional.CurrentRowIndex = 0;
				grdFractional.CurrentColumnIndex = 0;

				grdFractional.SetColumnWidth(0, 67);
				grdFractional.SetColumnWidth(1, 233);
				grdFractional.SetColumnWidth(2, 133);
				grdFractional.SetColumnWidth(3, 33);
				grdFractional.SetColumnWidth(4, 67);
				grdFractional.SetColumnWidth(5, 67);
				grdFractional.SetColumnWidth(6, 0);
				//   Query = "select distinct c.comp_id, c.comp_account_callback_date, c.comp_name, c.comp_city, c.comp_state, c.comp_timezone, c.comp_fractowr_id, count(*) as aircraft_count "
				//  Query = Query & "from company as C WITH(NOLOCK), aircraft_reference as R, aircraft as A "
				//  Query = Query & "where c.comp_account_type ='FO' and r.cref_primary_poc_flag='Y' "
				//  Query = Query & "and c.comp_business_type <> 'PH' "
				//  Query = Query & "and c.comp_id=r.cref_comp_id and c.comp_journ_id=r.cref_journ_id "
				//  Query = Query & "and c.comp_journ_id=0 and c.comp_active_flag='Y' and a.ac_id=r.cref_ac_id and a.ac_journ_id=r.cref_journ_id "
				//  Query = Query & "and (a.ac_ownership_type='W' or a.ac_ownership_type='S') "

				//frac with priamry whole
				Query = "select distinct c.comp_id, c.comp_account_callback_date, c.comp_name, c.comp_city, c.comp_state, c.comp_timezone, c.comp_fractowr_id, count(*) as aircraft_count ";
				Query = $"{Query}from company as C WITH(NOLOCK) ";
				Query = $"{Query}inner join aircraft_reference as R WITH(NOLOCK) on (c.comp_id=r.cref_comp_id and c.comp_journ_id=r.cref_journ_id) ";
				Query = $"{Query}inner join aircraft as A WITH(NOLOCK) on (a.ac_id=r.cref_ac_id and a.ac_journ_id=r.cref_journ_id) ";
				Query = $"{Query}inner join aircraft_model as M WITH(NOLOCK) on (M.amod_id=a.ac_amod_id) ";
				Query = $"{Query}where c.comp_account_type ='FO' and r.cref_primary_poc_flag='Y' ";
				Query = $"{Query}and c.comp_business_type <> 'PH' ";
				Query = $"{Query}and (c.comp_journ_id=0 and c.comp_active_flag='Y') ";
				Query = $"{Query}and (a.ac_ownership_type='W' or a.ac_ownership_type='S') ";

				if (cmbProductType.Text.StartsWith("L", StringComparison.Ordinal))
				{ //aey 10/17/05
				}
				else if (cmbProductType.Text.StartsWith("A", StringComparison.Ordinal))
				{  //aey 10/17/05
					Query = $"{Query}AND a.ac_use_code <> 'C'  ";
					Query = $"{Query}AND (m.amod_airframe_type_code = 'F' or (m.amod_airframe_type_code = 'R' AND m.amod_class_code='A')) ";
					Query = $"{Query}AND c.comp_id not in (select distinct c2.comp_id ";
					Query = $"{Query}from company as C2 WITH(NOLOCK) ";
					Query = $"{Query}inner join aircraft_reference as R2 WITH(NOLOCK) on (c2.comp_id=r2.cref_comp_id and c2.comp_journ_id=r2.cref_journ_id) ";
					Query = $"{Query}inner join aircraft as A2 WITH(NOLOCK) on (a2.ac_id=r2.cref_ac_id and a2.ac_journ_id=r2.cref_journ_id) ";
					Query = $"{Query}where c2.comp_account_type ='FO' ";
					Query = $"{Query}and c2.comp_business_type <> 'PH' ";
					Query = $"{Query}and (c2.comp_journ_id=0 and c2.comp_active_flag='Y') ";
					Query = $"{Query}and (a2.ac_ownership_type='W' or a2.ac_ownership_type='S') ";
					Query = $"{Query}AND a2.ac_use_code = 'C') ";
				}
				else if (cmbProductType.Text.StartsWith("B", StringComparison.Ordinal))
				{ 
					Query = $"{Query}AND m.amod_airframe_type_code = 'F' ";
				}
				else if (cmbProductType.Text.StartsWith("H", StringComparison.Ordinal))
				{ 
					Query = $"{Query}AND m.amod_airframe_type_code = 'R' AND m.amod_class_code='A' ";
					Query = $"{Query}AND c.comp_id not in( select distinct c2.comp_id ";
					Query = $"{Query}from company as C2 WITH(NOLOCK) ";
					Query = $"{Query}inner join aircraft_reference as R2 WITH(NOLOCK) on (c2.comp_id=r2.cref_comp_id and c2.comp_journ_id=r2.cref_journ_id) ";
					Query = $"{Query}inner join aircraft as A2 WITH(NOLOCK) on (a2.ac_id=r2.cref_ac_id and a2.ac_journ_id=r2.cref_journ_id) ";
					Query = $"{Query}inner join aircraft_model as M2 WITH(NOLOCK) on (M2.amod_id=a2.ac_amod_id) ";
					Query = $"{Query}where c2.comp_account_type ='FO' "; //and r2.cref_primary_poc_flag='Y' "
					Query = $"{Query}and c2.comp_business_type <> 'PH' ";
					Query = $"{Query}and (c2.comp_journ_id=0 and c2.comp_active_flag='Y') ";
					Query = $"{Query}and (a2.ac_ownership_type='W' or a2.ac_ownership_type='S') ";
					Query = $"{Query}AND m2.amod_airframe_type_code = 'F') ";
				}
				else if (cmbProductType.Text.StartsWith("C", StringComparison.Ordinal))
				{ 
					Query = $"{Query}AND a.ac_use_code='C'  ";
					Query = $"{Query}AND c.comp_id not in( select distinct c2.comp_id ";
					Query = $"{Query}from company as C2 WITH(NOLOCK) ";
					Query = $"{Query}inner join aircraft_reference as R2 WITH(NOLOCK) on (c2.comp_id=r2.cref_comp_id and c2.comp_journ_id=r2.cref_journ_id) ";
					Query = $"{Query}inner join aircraft as A2 WITH(NOLOCK) on (a2.ac_id=r2.cref_ac_id and a2.ac_journ_id=r2.cref_journ_id) ";
					Query = $"{Query}where c2.comp_account_type ='FO' ";
					//and r2.cref_primary_poc_flag='Y' "
					Query = $"{Query}and c2.comp_business_type <> 'PH' ";
					Query = $"{Query}and (c2.comp_journ_id=0 and c2.comp_active_flag='Y') ";
					Query = $"{Query}and (a2.ac_ownership_type='W' or a2.ac_ownership_type='S') ";
					Query = $"{Query}AND a2.ac_use_code <>'C') ";
				}

				Query = $"{Query}group by c.comp_id, c.comp_account_callback_date, c.comp_name, c.comp_city , c.comp_state, c.comp_timezone, c.comp_fractowr_id ";
				Query = $"{Query}order by c.comp_id, c.comp_account_callback_date, c.comp_name, c.comp_city , c.comp_state, c.comp_timezone, c.comp_fractowr_id";

				//MsgBox ("Here - " & Query)
				adoFractionReassign = new ADORecordSetHelper();
				adoFractionReassign.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

				if (!(adoFractionReassign.BOF && adoFractionReassign.EOF))
				{
					pnl_fractional_display.Visible = true;
					// adoFractionReassign.MoveLast
					adoFractionReassign.MoveFirst();
					cmdStop.Visible = true;


					while(!adoFractionReassign.EOF)
					{
						Application.DoEvents();
						if (Stopped)
						{
							Stopped = false;
							break;
						}

						//fill grid

						grdFractional.CurrentColumnIndex = 0;
						grdFractional.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
						grdFractional[grdFractional.CurrentRowIndex, grdFractional.CurrentColumnIndex].Value = Convert.ToDateTime(adoFractionReassign["comp_account_callback_date"]).ToString("MM/dd/yyyy");
						grdFractional.CurrentColumnIndex = 1;
						grdFractional.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						grdFractional.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
						grdFractional[grdFractional.CurrentRowIndex, grdFractional.CurrentColumnIndex].Value = ($"{Convert.ToString(adoFractionReassign["comp_name"])} ").Trim();
						grdFractional.CurrentColumnIndex = 2;
						grdFractional.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						grdFractional.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
						grdFractional[grdFractional.CurrentRowIndex, grdFractional.CurrentColumnIndex].Value = ($"{Convert.ToString(adoFractionReassign["Comp_city"])} ").Trim();
						grdFractional.CurrentColumnIndex = 3;
						grdFractional.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						grdFractional.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
						grdFractional[grdFractional.CurrentRowIndex, grdFractional.CurrentColumnIndex].Value = ($"{Convert.ToString(adoFractionReassign["comp_state"])} ").Trim();
						grdFractional.CurrentColumnIndex = 4;
						grdFractional.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						grdFractional.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
						grdFractional[grdFractional.CurrentRowIndex, grdFractional.CurrentColumnIndex].Value = ($"{Convert.ToString(adoFractionReassign["comp_timezone"])} ").Trim();
						grdFractional.CurrentColumnIndex = 5;
						grdFractional.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						grdFractional.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
						grdFractional[grdFractional.CurrentRowIndex, grdFractional.CurrentColumnIndex].Value = $" {Convert.ToString(adoFractionReassign["aircraft_count"])} ";
						grdFractional.CurrentColumnIndex = 6;
						grdFractional[grdFractional.CurrentRowIndex, grdFractional.CurrentColumnIndex].Value = adoFractionReassign.GetField("comp_id");


						TotalCompCallBacks++;
						txt_Total_Comp_Callbacks.Text = TotalCompCallBacks.ToString();
						adoFractionReassign.MoveNext();
						grdFractional.RowsCount++;
						grdFractional.CurrentRowIndex++;
					};

					cmdStop.Visible = false;
					grdFractional.RowsCount--;
				}
				else
				{
					pnl_fractional_display.Visible = false;
					//UPGRADE_ISSUE: (2064) Threed.SSPanel property pnl_Fractional.Caption was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					pnl_Fractional.setCaption("NO Fractional Companies who are Primary on Whole/share");

				}

				search_off();
				pnl_Fractional.Visible = true;
				adoFractionReassign.Close();
			}
			catch (System.Exception excep)
			{

				adoFractionReassign = null;
				search_off();
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_FracWithPrimaryWhole_Grid_Error: {Information.Err().Number.ToString()} {excep.Message}");
			}

		}

		private void Fill_Priority_Events()
		{

			// RTW - 9/14/2010 - MODIFIED QUERIES TO NOT INCLUDE CLASS C HELICOPTER SECTIONS

			string Query = "";
			ADORecordSetHelper snpEvents = new ADORecordSetHelper();
			int RememberID = 0;
			string Comma = "";
			int totCount = 0;
			int lTot1 = 0;
			string strMsg1 = "";
			string strPEvents = "";

			string strMsg = "";
			System.DateTime dtStartDate = DateTime.FromOADate(0);
			System.DateTime dtEndDate = DateTime.FromOADate(0);

			string strAcctRep = "";
			string strAcctRepId = "";

			try
			{

				modCommon.Start_Activity_Monitor_Message("Callback PEvents", ref strMsg, ref dtStartDate, ref dtEndDate);
				string tempRefParam = "Events";
				search_on(ref tempRefParam);
				cmdFillEvents.Enabled = false;

				ClearPriorityEventsGrid();

				strAcctRep = cbo_account_id.Text.Substring(0, Math.Min(2, cbo_account_id.Text.Length)).ToUpper();
				strAcctRepId = cbo_account_id.Text.ToUpper();

				lblTotalPEventRecordsFound.Text = "Total Records Found: 0";
				lblPEventStop.Visible = false;
				lblPEventStop.Enabled = false;

				Query = "SELECT * FROM Aircraft as A WITH(NOLOCK) ";
				Query = $"{Query}inner join Aircraft_Model as M WITH(NOLOCK) on (a.ac_amod_id = m.amod_id) ";
				Query = $"{Query}inner join Priority_Events as E WITH(NOLOCK) on (E.priorev_ac_id = a.ac_id) ";
				Query = $"{Query}inner join Priority_Events_Category as P WITH(NOLOCK) on (e.priorev_category_code = p.priorevcat_category_code) ";
				Query = $"{Query}WHERE a.ac_journ_id = 0  ";

				if (chk_EventsToday.CheckState == CheckState.Checked)
				{
					Query = $"{Query}AND e.priorev_entry_date >= '{DateTime.Today.ToString("MM/dd/yyyy")}' ";
				}
				else
				{

					if (txtEventDateFrom.Text.Trim() != "")
					{
						if (Information.IsDate(txtEventDateFrom.Text.Trim()))
						{
							Query = $"{Query}AND e.priorev_entry_date >= '{StringsHelper.Format(txtEventDateFrom.Text.Trim(), "mm/dd/yyyy hh:mm:ss am/pm")}' ";
						}
					}

					if (txtEventDateTo.Text.Trim() != "")
					{
						if (Information.IsDate(txtEventDateTo.Text.Trim()))
						{
							if (Strings.Len(txtEventDateTo.Text.Trim()) < 11)
							{
								Query = $"{Query}AND e.priorev_entry_date <= '{StringsHelper.Format($"{txtEventDateTo.Text.Trim()} 11:59pm", "mm/dd/yyyy hh:mm:ss am/pm")}' ";
							}
							else
							{
								Query = $"{Query}AND e.priorev_entry_date <= '{StringsHelper.Format(txtEventDateTo.Text.Trim(), "mm/dd/yyyy hh:mm:ss am/pm")}' ";
							}
						}
					}
				}

				strPEvents = "";
				if (lstEventCat.Items.Count > 0)
				{
					if (lstEventCat.SelectedItems.Count > 0 && !ListBoxHelper.GetSelected(lstEventCat, 0))
					{
						Query = $"{Query}AND e.priorev_category_code IN (";
						Comma = "";
						int tempForEndVar = lstEventCat.Items.Count - 1;
						for (int i = 0; i <= tempForEndVar; i++)
						{
							if (ListBoxHelper.GetSelected(lstEventCat, i))
							{
								Query = $"{Query}{Comma}'{lstEventCat.GetListItem(i).Trim().Substring(0, Math.Min(lstEventCat.Text.IndexOf(" -"), lstEventCat.GetListItem(i).Trim().Length))}'";
								Comma = ",";
								strPEvents = $"{strPEvents}{lstEventCat.GetListItem(i).Trim().Substring(0, Math.Min(lstEventCat.Text.IndexOf(" -"), lstEventCat.GetListItem(i).Trim().Length))},";
							}
						}
						Query = $"{Query}) ";
						if (strPEvents.Substring(Math.Max(strPEvents.Length - 1, 0)) == ",")
						{
							strPEvents = strPEvents.Substring(0, Math.Min(Strings.Len(strPEvents) - 1, strPEvents.Length));
						} // Remove Comma
					}
				} // If lstEventCat.ListCount > 0 Then

				if (cmbProductType.Text.StartsWith("L", StringComparison.Ordinal))
				{
				}
				else if (cmbProductType.Text.StartsWith("A", StringComparison.Ordinal))
				{ 
					Query = $"{Query}AND (m.amod_airframe_type_code = 'F'  or (m.amod_airframe_type_code = 'R')) ";

				}
				else if (cmbProductType.Text.StartsWith("B", StringComparison.Ordinal))
				{ 
					Query = $"{Query}AND m.amod_airframe_type_code = 'F' ";

				}
				else if (cmbProductType.Text.StartsWith("H", StringComparison.Ordinal))
				{ 
					Query = $"{Query}AND m.amod_airframe_type_code = 'R' ";

				}
				else if (cmbProductType.Text.StartsWith("C", StringComparison.Ordinal))
				{ 
					Query = $"{Query}AND a.ac_product_commercial_flag='Y' ";

				}
				else if (cmbProductType.Text.StartsWith("P", StringComparison.Ordinal))
				{ 
					Query = $"{Query}AND a.ac_product_airbp_flag='Y' ";
				}

				if (strEventsOrderBy != "")
				{
					Query = $"{Query}{strEventsOrderBy}";
				}
				else
				{
					Query = $"{Query}ORDER BY  a.ac_id";
				}

				modAdminCommon.Record_Event("Monitor Activity", $"Priority Events - Selected AcctRep: {strAcctRepId}");
				// Record_Event "HB Usage", "Priority Events - Selected AcctRep: " & strAcctRepId

				snpEvents.CursorLocation = CursorLocationEnum.adUseClient;
				snpEvents.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!snpEvents.BOF && !snpEvents.EOF)
				{

					lTot1 = snpEvents.RecordCount;

					lblPEventStop.Visible = true;
					lblPEventStop.Enabled = true;
					grdPriorityEvents.Redraw = false;

					totCount = 0;
					RememberID = 0;

					do 
					{ // Loop Until snpEvents.EOF = True Or lblPEventStop.Enabled = False

						totCount++;
						strMsg1 = $"Loading Event Records: {StringsHelper.Format(totCount, "#,##0")} of {StringsHelper.Format(lTot1, "#,##0")} Records";
						lblTotalPEventRecordsFound.Text = strMsg1;


						grdPriorityEvents.RowsCount++;
						grdPriorityEvents.CurrentRowIndex = grdPriorityEvents.RowsCount - 1;

						if (RememberID != StringsHelper.ToDoubleSafe(($"{Convert.ToString(snpEvents["ac_id"])}").Trim()))
						{

							grdPriorityEvents.CurrentColumnIndex = 0;
							grdPriorityEvents[grdPriorityEvents.CurrentRowIndex, grdPriorityEvents.CurrentColumnIndex].Value = $"{($"{Convert.ToString(snpEvents["amod_make_name"])}").Trim()}/{($"{Convert.ToString(snpEvents["amod_model_name"])}").Trim()}";

							grdPriorityEvents.CurrentColumnIndex = 1;
							grdPriorityEvents[grdPriorityEvents.CurrentRowIndex, grdPriorityEvents.CurrentColumnIndex].Value = ($"{Convert.ToString(snpEvents["ac_ser_no_full"])}").Trim();
						}

						grdPriorityEvents.CurrentColumnIndex = 2;
						grdPriorityEvents[grdPriorityEvents.CurrentRowIndex, grdPriorityEvents.CurrentColumnIndex].Value = ($"{Convert.ToString(snpEvents["priorev_subject"])}").Trim();
						if (($"{Convert.ToString(snpEvents["priorev_description"])}").Trim() != "")
						{
							grdPriorityEvents[grdPriorityEvents.CurrentRowIndex, grdPriorityEvents.CurrentColumnIndex].Value = $"{grdPriorityEvents[grdPriorityEvents.CurrentRowIndex, grdPriorityEvents.CurrentColumnIndex].FormattedValue.ToString()} [{($"{Convert.ToString(snpEvents["priorev_description"])}").Trim()}]";
						}

						grdPriorityEvents.CurrentColumnIndex = 3;
						grdPriorityEvents[grdPriorityEvents.CurrentRowIndex, grdPriorityEvents.CurrentColumnIndex].Value = StringsHelper.Format(($"{Convert.ToString(snpEvents["priorev_entry_date"])}").Trim(), "mm/dd/yyyy hh:mm:ss am/pm");

						grdPriorityEvents.set_RowData(grdPriorityEvents.CurrentRowIndex, Convert.ToInt32(snpEvents["ac_id"]));
						RememberID = Convert.ToInt32(Double.Parse(($"{Convert.ToString(snpEvents["ac_id"])}").Trim()));


						if (totCount == 20)
						{
							grdPriorityEvents.Redraw = true;
							grdPriorityEvents.Refresh();
							Application.DoEvents();
							grdPriorityEvents.Redraw = false;
						}

						snpEvents.MoveNext();

					}
					while(!(snpEvents.EOF && !lblPEventStop.Enabled));

					strMsg1 = $"Total Records Loaded: {StringsHelper.Format(totCount, "#,##0")} of {StringsHelper.Format(lTot1, "#,##0")} Records";
					lblTotalPEventRecordsFound.Text = strMsg1;

					if (snpEvents.RecordCount > 0)
					{
						grdPriorityEvents.FixedRows = 1;
					}

					lblPEventStop.Visible = false;
					lblPEventStop.Enabled = false;

				}
				else
				{
					grdPriorityEvents.RowsCount = 2;
					grdPriorityEvents.CurrentRowIndex = 1;
					grdPriorityEvents.CurrentColumnIndex = 0;
					grdPriorityEvents[grdPriorityEvents.CurrentRowIndex, grdPriorityEvents.CurrentColumnIndex].Value = "No Priority Event Records Found";
				} // If (snpEvents.BOF = False And snpEvents.EOF = False) Then

				snpEvents.Close();
				snpEvents = null;

				strMsg = $"AcctRep: {cbo_account_id.Text}";
				strMsg = $"{strMsg} Product: {cmbProductType.Text}";
				strMsg = $"{strMsg} Callback Date: {txt_Callback_Date.Text}";

				if (chk_EventsToday.CheckState == CheckState.Checked)
				{
					strMsg = $"{strMsg} [x] Events Today ";
				}
				if (txtEventDateFrom.Text != "")
				{
					strMsg = $"{strMsg} Date From: {txtEventDateFrom.Text}";
				}
				if (txtEventDateTo.Text != "")
				{
					strMsg = $"{strMsg} To From: {txtEventDateTo.Text}";
				}
				if (strPEvents != "")
				{
					strMsg = $"{strMsg} Events: {strPEvents}";
				}

				if (bLog)
				{

					modCommon.End_Activity_Monitor_Message("Callback PEvents", ref strMsg, dtStartDate, ref dtEndDate, 0, 0, 0, 0, 0);

					frm_UserHistory.DefInstance.Refresh_User_History_Grids("Callback");

				}

				grdPriorityEvents.Redraw = true;
				cmdFillEvents.Enabled = true;

				search_off();
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"{Information.Err().Number.ToString()} - {excep.Message}");

				snpEvents.Close();

				search_off();
			}

		} // Fill_Priority_Events



		private string Find_Models_Excluded(string include_ignored_priority, string include_prefix, string aircraft_or_model)
		{


			string Query = "";
			ADORecordSetHelper snpEvents = new ADORecordSetHelper();
			int RememberID = 0;
			int i = 0;
			string Comma = "";
			int totCount = 0;
			int lTot1 = 0;
			string strMsg1 = "";
			string strPEvents = "";

			string strMsg = "";
			System.DateTime dtStartDate = DateTime.FromOADate(0);
			System.DateTime dtEndDate = DateTime.FromOADate(0);

			string strAcctRep = "";
			string strAcctRepId = "";
			return "";


			//  On Error GoTo Find_Models_Excluded_Error
			//
			//
			//  Query = "SELECT distinct amod_id FROM Aircraft_Model WITH(NOLOCK) where amod_research_priority > 50 "
			//
			//  snpEvents.CursorLocation = adUseClient
			//  snpEvents.Open Query, LOCAL_ADO_DB, adOpenStatic, adLockReadOnly, adCmdText
			//
			//  If (snpEvents.BOF = False And snpEvents.EOF = False) Then
			//
			//
			//    Do ' Loop Until snpEvents.EOF = True Or lblPEventStop.Enabled = False
			//
			//       'aircraft_or_model then amod_id
			//
			//
			//        If Trim(Find_Models_Excluded) <> "" Then
			//            Find_Models_Excluded = Find_Models_Excluded & ", "
			//        End If
			//
			//        Find_Models_Excluded = Find_Models_Excluded & snpEvents!amod_id
			//
			//
			//      snpEvents.MoveNext
			//
			//    Loop Until snpEvents.EOF = True And lblPEventStop.Enabled = False
			//
			//  Else
			//  End If ' If (snpEvents.BOF = False And snpEvents.EOF = False) Then
			//
			//  snpEvents.Close
			//  Set snpEvents = Nothing
			//
			//
			//   If Trim(Find_Models_Excluded) <> "" Then
			//        Find_Models_Excluded = Find_Models_Excluded & " and ac_amod_id in (" & Find_Models_Excluded & ") "
			//   End If


			//  Exit Function

			//Find_Models_Excluded_Error:
			//
			//  Report_Error Err.Number & " - " & Err.description
			//
			//  snpEvents.Close
			//  Set snpEvents = Nothing
			//
			//  search_off

		} // Fill_Priority_Events


		private void Fill_Product_Type()
		{
			//Product: Business or Helicopter
			//Business includes Fixed & Rotary
			//Helicopter is Rotary only
			//aey 6/3/05

			string Query = "";
			ADORecordSetHelper snp_AirframeType = new ADORecordSetHelper();
			int FixedRow = 0;

			try
			{

				FixedRow = 0;

				if (Convert.ToString(modAdminCommon.snp_User["user_default_airframe"]) == "R")
				{
					FixedRow = 2;
				}

				// 08/27/2015 - By David D. Cruger
				// Per Jackie; Default to All
				FixedRow = 7;

				cmbProductType.Items.Clear();
				cmbProductType.AddItem("A - Business and Helicopter");
				cmbProductType.AddItem("B - Business Only");
				cmbProductType.AddItem("H - Helicopter Only");
				cmbProductType.AddItem("C - Commercial Only");
				cmbProductType.AddItem("Q - JNiQ Eligible");
				cmbProductType.AddItem("N - Non-JNiQ Eligible");
				cmbProductType.AddItem("P - AirBP");
				cmbProductType.AddItem("L - All");

				cmbProductType.SelectedIndex = FixedRow;
			}
			catch (System.Exception excep)
			{

				this.Cursor = CursorHelper.CursorDefault;
				modAdminCommon.Report_Error($"Fill_Product_Type_Error:: {excep.Message}");
			}

		}

		private void Fill_Color_Confirm_Type()
		{

			cmbColorConfirmType.Enabled = false;
			cmbColorConfirmType.Items.Clear();
			cmbColorConfirmType.AddItem("All");
			cmbColorConfirmType.AddItem("Company Address");
			cmbColorConfirmType.AddItem("Company Phone Nbrs");
			cmbColorConfirmType.AddItem("Company EMail");
			cmbColorConfirmType.AddItem("Company Website");
			cmbColorConfirmType.AddItem("Contact Name");
			cmbColorConfirmType.AddItem("Contact Title");
			cmbColorConfirmType.AddItem("Contact Phone Nbrs");
			cmbColorConfirmType.AddItem("Aircraft Reg Nbr");
			cmbColorConfirmType.AddItem("Aircraft Base");

			cmbColorConfirmType.SelectedIndex = 0;
			cmbColorConfirmType.Enabled = true;

		} // Fill_Color_Confirm_Type

		private void Fill_Find_Duplicates_Reports()
		{

			cmbFindDupReports.Items.Clear();
			cmbFindDupReports.AddItem("");
			cmbFindDupReports.AddItem("Company Address");
			cmbFindDupReports.AddItem("Contact EMail");
			cmbFindDupReports.AddItem("Contact Phone Nbr");
			cmbFindDupReports.AddItem("Contact Name");

			cmbFindDupReports.SelectedIndex = 0;

		} // Fill_Find_Duplicates_Reports

		private void Fill_Find_Research_Reports()
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			try
			{

				cmbFindResearchReports.Items.Clear();
				cmbFindResearchReports.Tag = "";
				cmbFindResearchReports.AddItem("");

				strQuery1 = "SELECT sqlrep_id, sqlrep_title ";
				strQuery1 = $"{strQuery1}FROM SQL_Report WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (sqlrep_sub_id in (1484,777) ) ";
				strQuery1 = $"{strQuery1}AND (sqlrep_level = 'HOMEBASE') ";
				strQuery1 = $"{strQuery1}ORDER BY sqlrep_title ";

				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					do 
					{
						cmbFindResearchReports.AddItem(($"{Convert.ToString(rstRec1["sqlrep_title"])} ").Trim());
						cmbFindResearchReports.SetItemData(cmbFindResearchReports.GetNewIndex(), Convert.ToInt32(rstRec1["sqlrep_id"]));
						rstRec1.MoveNext();
					}
					while(!rstRec1.EOF);

				} // If rstRec1.BOF = False And rstRec1.EOF = False Then

				rstRec1.Close();

				cmbFindResearchReports.SelectedIndex = 0;

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"Fill_Find_Duplicates_Reports: {excep.Message}");
			}

		} // Fill_Find_Duplicates_Reports

		private void FillEventCat()
		{

			ADORecordSetHelper snpCat = new ADORecordSetHelper(); //aey 6/18/04

			lstEventCat.Items.Clear();
			lstEventCat.AddItem("All");

			string Query = "SELECT * FROM Priority_Events_Category WITH(NOLOCK)";
			Query = $"{Query}ORDER BY priorevcat_category_name";

			//Set snpCat = LOCAL_DB.OpenRecordset(Query, dbOpenSnapshot, dbSQLPassThrough)
			snpCat.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

			if (!(snpCat.BOF && snpCat.EOF))
			{
				snpCat.MoveFirst(); //aey 6/16/04

				while(!snpCat.EOF)
				{
					lstEventCat.AddItem($"{($"{Convert.ToString(snpCat["priorevcat_category_code"])}").Trim()} - {($"{Convert.ToString(snpCat["priorevcat_category_name"])}").Trim()}");

					snpCat.MoveNext();
				};
			}

			ListBoxHelper.SetSelected(lstEventCat, 0, true);
			snpCat.Close();


		}


		private int GetACCount(int PassedCompID)
		{
			//
			// THE PURPOSE OF THIS PROCEDURE IS TO COUNT THE NUMBER OF AIRCRAFT
			// ASSOCIATED WITH A GIVEN COMPANY
			//
			// 8/6/2003 - RTW - CHANGED TO ADO RECORDSET
			int result = 0;
			try
			{

				string Query = "";
				ADORecordSetHelper snpACCount = new ADORecordSetHelper();

				result = 0;

				//   Query = "SELECT count(DISTINCT cref_ac_id) as AircraftCount "
				//   Query = Query & "FROM Aircraft_Reference WITH(NOLOCK) "
				//   Query = Query & "WHERE cref_comp_id = " & PassedCompID & " "
				//   Query = Query & "AND cref_journ_id = 0"

				//aey 6/13/06 converted to SUM()
				Query = "select sum(cac_total_referenced) as AircraftCount  from Company_Aircraft_Count WITH(NOLOCK) ";
				Query = $"{Query}where cac_comp_id = {PassedCompID.ToString()} ";

				snpACCount.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpACCount.BOF && snpACCount.EOF))
				{
					snpACCount.MoveFirst();
					result = Convert.ToInt32(Conversion.Val(($"{Convert.ToString(snpACCount["AircraftCount"])}").Trim()));
				}

				snpACCount.Close();
				snpACCount = null;
			}
			catch (System.Exception excep)
			{
				modAdminCommon.Report_Error($"GetACCount_Error: {excep.Message}");
			}
			return result;
		}

		public void setup_HotBox_Columns(UpgradeHelpers.DataGridViewFlex grd_Hot_Items, string cellcolor)
		{



			grd_Hot_Items.Clear();
			grd_Hot_Items.ColumnsCount = 12;
			grd_Hot_Items.RowsCount = 2;

			grd_Hot_Items.CurrentRowIndex = 0;


			//--------------------------------------------------------------------------------------------------------
			// #0          #1       #2    #3    #4       #5       #6          #7          #8       #9    #10   #11
			// Make/Model  Serial#  Reg#  Date  Company  Subject  Brand/Model Yacht Name  JournId  ACId  YTId  CompId

			grd_Hot_Items.CurrentColumnIndex = 0;
			grd_Hot_Items.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
			grd_Hot_Items.SetColumnWidth(0, 0);
			if (opHBAircraftYacht[0].Checked)
			{
				grd_Hot_Items.SetColumnWidth(0, 160);
			}
			grd_Hot_Items[grd_Hot_Items.CurrentRowIndex, grd_Hot_Items.CurrentColumnIndex].Value = "Make/Model ";

			grd_Hot_Items.CurrentColumnIndex = 1;
			grd_Hot_Items.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
			grd_Hot_Items.SetColumnWidth(1, 0);
			if (opHBAircraftYacht[0].Checked)
			{
				grd_Hot_Items.SetColumnWidth(1, 67);
			}
			grd_Hot_Items[grd_Hot_Items.CurrentRowIndex, grd_Hot_Items.CurrentColumnIndex].Value = "Serial#";

			grd_Hot_Items.CurrentColumnIndex = 2;
			grd_Hot_Items.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
			grd_Hot_Items.SetColumnWidth(2, 0);
			if (opHBAircraftYacht[0].Checked)
			{
				grd_Hot_Items.SetColumnWidth(2, 67);
			}
			grd_Hot_Items[grd_Hot_Items.CurrentRowIndex, grd_Hot_Items.CurrentColumnIndex].Value = "Reg#";

			grd_Hot_Items.CurrentColumnIndex = 3;
			grd_Hot_Items.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
			grd_Hot_Items.SetColumnWidth(3, 67);
			grd_Hot_Items[grd_Hot_Items.CurrentRowIndex, grd_Hot_Items.CurrentColumnIndex].Value = "Date";

			grd_Hot_Items.CurrentColumnIndex = 4;
			grd_Hot_Items.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
			grd_Hot_Items.SetColumnWidth(4, 200);
			grd_Hot_Items[grd_Hot_Items.CurrentRowIndex, grd_Hot_Items.CurrentColumnIndex].Value = "Company";

			grd_Hot_Items.CurrentColumnIndex = 5;
			grd_Hot_Items.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
			grd_Hot_Items.SetColumnWidth(5, 400);
			grd_Hot_Items[grd_Hot_Items.CurrentRowIndex, grd_Hot_Items.CurrentColumnIndex].Value = "Journal Subject";

			grd_Hot_Items.CurrentColumnIndex = 6;
			grd_Hot_Items.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
			grd_Hot_Items.SetColumnWidth(6, 0);
			if (opHBAircraftYacht[1].Checked)
			{
				grd_Hot_Items.SetColumnWidth(6, 200);
			}
			grd_Hot_Items[grd_Hot_Items.CurrentRowIndex, grd_Hot_Items.CurrentColumnIndex].Value = "Yacht Brand/Model";

			grd_Hot_Items.CurrentColumnIndex = 7;
			grd_Hot_Items.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
			grd_Hot_Items.SetColumnWidth(7, 0);
			if (opHBAircraftYacht[1].Checked)
			{
				grd_Hot_Items.SetColumnWidth(7, 200);
			}
			grd_Hot_Items[grd_Hot_Items.CurrentRowIndex, grd_Hot_Items.CurrentColumnIndex].Value = "Yacht Name";

			grd_Hot_Items.CurrentColumnIndex = 8;
			grd_Hot_Items.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
			grd_Hot_Items.SetColumnWidth(8, 0);
			grd_Hot_Items[grd_Hot_Items.CurrentRowIndex, grd_Hot_Items.CurrentColumnIndex].Value = "JournId";

			grd_Hot_Items.CurrentColumnIndex = 9;
			grd_Hot_Items.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
			grd_Hot_Items.SetColumnWidth(9, 0);
			grd_Hot_Items[grd_Hot_Items.CurrentRowIndex, grd_Hot_Items.CurrentColumnIndex].Value = "ACId";

			grd_Hot_Items.CurrentColumnIndex = 10;
			grd_Hot_Items.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
			grd_Hot_Items.SetColumnWidth(10, 0);
			grd_Hot_Items[grd_Hot_Items.CurrentRowIndex, grd_Hot_Items.CurrentColumnIndex].Value = "YTId";

			grd_Hot_Items.CurrentColumnIndex = 11;
			grd_Hot_Items.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
			grd_Hot_Items.SetColumnWidth(11, 0);
			grd_Hot_Items[grd_Hot_Items.CurrentRowIndex, grd_Hot_Items.CurrentColumnIndex].Value = "CompId";


		}

		private void Show_Pending_Fractional_Company_Info()
		{


			snp_FractionsPending.MoveFirst();
			int tempForEndVar = grdFractional.CurrentRowIndex - 1;
			for (int i = 0; i <= tempForEndVar; i++)
			{
				snp_FractionsPending.MoveNext();
			}

			RememberExclusiveCompanyId = Convert.ToInt32(snp_FractionsPending["comp_id"]);
			modCommon.Build_Company_NameAddress(this.lstCompany, Convert.ToInt32(snp_FractionsPending["comp_id"]), Convert.ToInt32(snp_FractionsPending["ac_journ_id"]));
			lstCompany.SetItemData(0, Convert.ToInt32(snp_FractionsPending["comp_id"]));

			cmdConfirmExclusive.Enabled = true; //aey 4/21/2006
			cmdConfirmExclusive.Text = "&Confirm Company";
			string strLock = modCommon.CompanyLocked(RememberExclusiveCompanyId, 0);

			if ((strLock == "False") || (strLock == Convert.ToString(modAdminCommon.snp_User["user_id"])))
			{
			}
			else
			{
				cmdConfirmExclusive.Enabled = false;
				cmdConfirmExclusive.Text = "Confirm Company Locked";
			}


		}

		private void ShowAvailableAircraftCallbackInfo()
		{


			RememberExclusiveCompanyId = grd_AvailableAircraft.get_RowData(grd_AvailableAircraft.CurrentRowIndex);
			modCommon.Build_Company_NameAddress(this.lstCompany, RememberExclusiveCompanyId, 0);
			lstCompany.SetItemData(0, RememberExclusiveCompanyId);

			cmdConfirmExclusive.Enabled = true; //aey 4/21/2006
			cmdConfirmExclusive.Text = "&Confirm Company";
			string strLock = modCommon.CompanyLocked(RememberExclusiveCompanyId, 0);

			if (strLock != "False" || strLock != Convert.ToString(modAdminCommon.snp_User["user_id"]))
			{
				cmdConfirmExclusive.Enabled = false;
				cmdConfirmExclusive.Text = "Confirm Company Locked";
			}

		}

		private void ShowPendingFractionalReAssigns()
		{
			//aey 7/7/04



			int CompID = 0;
			int JournID = 0;
			string strLock = "";
			grdFractional.CurrentColumnIndex = 6;
			ErrorHandlingHelper.ResumeNext(
				() => {CompID = Convert.ToInt32(Conversion.Val(grdFractional[grdFractional.CurrentRowIndex, grdFractional.CurrentColumnIndex].FormattedValue.ToString()));}, 

				() => {RememberExclusiveCompanyId = CompID;}, 
				() => {modCommon.Build_Company_NameAddress(this.lstCompany, CompID, JournID);}, 
				() => {lstCompany.SetItemData(0, CompID);}, 

				() => {cmdConfirmExclusive.Enabled = true;},  //aey 4/21/2006
				() => {cmdConfirmExclusive.Text = "&Confirm Company";}, 
				() => {strLock = modCommon.CompanyLocked(RememberExclusiveCompanyId, 0);});

			if (ErrorHandlingHelper.ResumeNextExpr<bool>(() => (strLock == "False") || (strLock == Convert.ToString(modAdminCommon.snp_User["user_id"]))))
			{
			}
			else
			{
				try
				{
					cmdConfirmExclusive.Enabled = false;
				}
				catch
				{
				}
				cmdConfirmExclusive.Text = "Confirm Company Locked";
			}


		}

		private void ToolbarButtonsSetup()
		{


			ToolStrip tbr = tbr_AL_ToolBar; //gap-note ToolStrip instead of Control

			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[2].Visible = true;
			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[4].Visible = true;
			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[6].Visible = false;
			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[8].Visible = false;

			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[2].Enabled = true;
			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[4].Enabled = true;
			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[6].Enabled = false;
			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[8].Enabled = false;

		}

		private void ToolbarSetup()
		{

			ToolStrip tbr = tbr_AL_ToolBar; //gap-note ToolStrip instead of Control;

			//UPGRADE_TODO: (1067) Member ImageList is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.ImageList = mdi_ResearchAssistant.DefInstance.imgNormal;

			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			(tbr.Items[2] as ToolStripButton).Image = (Image) resources.GetObject("Home");
			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			(tbr.Items[4] as ToolStripButton).Image = (Image) resources.GetObject("Back");
			//    .Buttons(6).Image = "Save"
			//     .Buttons(8).Image = "Help"

			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[2].Text = "Home";
			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[4].Text = "Back";
			//    .Buttons(6).Key = "Save"
			//    .Buttons(8).Key = "Help"

			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[2].ToolTipText = "Go to Main Menu";
			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[4].ToolTipText = "Go to Previous Screen";
			//    .Buttons(6).ToolTipText = "Save screen data"
			//    .Buttons(8).ToolTipText = "Online Help"

		}

		//UPGRADE_WARNING: (2050) MSComCtl2.MonthView Event cal_Callback.DateClick was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2050
		private void cal_Callback_DateClick(System.DateTime DateClicked)
		{
			txt_Callback_Date.Text = DateTimeHelper.ToString(cal_Callback.SelectionRange.Start);
			cbo_TimeScale_SelectionChangeCommitted(cbo_TimeScale, new EventArgs());
		}

		private void cal_Callback_Enter(Object eventSender, EventArgs eventArgs) => mvHasFocus = true;


		private void cbo_account_id_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs)
		{


			if (!bIsFormLoad)
			{

				if (cbo_account_id.Text != "")
				{
					foreach (string AccountRep_Array_item in modGlobalVars.AccountRep_Array)
					{
						if (AccountRep_Array_item.Trim() == cbo_account_id.Text.Trim())
						{
							modAdminCommon.gbl_Account_ID = cbo_account_id.Text;
						}
					}
				}


				//added MSW - 8/4/22
				if (chk_alt_rep.CheckState == CheckState.Checked)
				{
					chk_alt_rep.Tag = modAdminCommon.return_top1_alt_account(modAdminCommon.gbl_Account_ID);
					lbl_gen[57].Text = Convert.ToString(chk_alt_rep.Tag);
				}
				else
				{
					chk_alt_rep.Tag = "0";
					lbl_gen[57].Text = "";
				}



				switch(SSTabHelper.GetSelectedIndex(tab_callback))
				{
					case 0 :  // Primary Callback List 
						 
						Fill_Callback_Grid(); 
						 
						break;
					case 1 :  // Reassign List 
						 
						Fill_New_Assignment_Grid(); 
						 
						break;
					case 2 :  // Color Confirm 
						 
						Fill_Comp_Confirm_Grid(""); 
						 
						break;
					case 3 :  // Reverify Exclusive Due 
						 
						Fill_Exclusive_Callback_Grid(); 
						 
						break;
					case 4 :  // Hot Box Items 
						 
						Fill_Hot_Items_Grid(); 
						 
						break;
					case 5 :  // Expired Leases 
						 
						Fill_Aircraft_Expired_Leases_Grid(); 
						 
						break;
					case 6 :  // Fractional Owners 
						 
						optFractionalOwners.Checked = true; 
						cmd_ClearFractionalReassign.Visible = false; 
						cmdRefreshFractOwners_Click(cmdRefreshFractOwners, new EventArgs()); 
						 
						break;
					case 7 :  // Wanteds 
						 
						Fill_WantedList(); 
						 
						break;
					case 8 :  // Avilable Aircraft 
						 
						Fill_AvailableAircraft_Grid(); 
						 
						break;
					case 9 :  // Documents In Process 
						 
						if (chk_AllDocuments.CheckState == CheckState.Unchecked)
						{
							cmd_DocsInProcessRefresh_Click(cmd_DocsInProcessRefresh, new EventArgs());
						} 
						 
						break;
					case 19 :  // Research Reports 
						 
						if (cmbFindResearchReports.Text != "")
						{
							cmdResearchReportsRefresh_Click(cmdResearchReportsRefresh, new EventArgs());
						} 
						 
						break;
				} // tab_callback

				CheckForNewAvailables(cbo_account_id.Text);

				if (cbo_account_id.Visible && cbo_account_id.Enabled)
				{
					cbo_account_id.Focus();
				}

				search_off();

			} // If Not bIsFormLoad Then

			bLog = false;
			Fill_Find_Customer_Submitted_Data_Grid();
			bLog = true;

		} // cbo_account_id_Click

		public void Fill_Account_Rep_List()
		{

			if (!AlreadyLoaded)
			{
				modFillCompConControls.Fill_AccountRep_FromArray(cbo_account_id, true, false);
			}

		} // Fill_Account_Rep_List

		public void Select_Wanted()
		{
			//******************************************************************************************
			//* Note: VBC id'd the following unreferenced items and handled them as described:         *
			//*                                                                                        *
			//* Local Variables (Removed)                                                              *
			//*  i                                                                                     *
			//******************************************************************************************

			//----------------------------------------------------------------------------------------------
			//Function used to select wanteds
			//----------------------------------------------------------------------------------------------

			frm_Company o_Local_Show_Company = null;

			try
			{

				if (grd_WantedList.get_RowData(grd_WantedList.CurrentRowIndex) > 0)
				{

					// cleanup any contact forms and open a clean form
					modCommon.Unload_Form("frm_Company");

					o_Local_Show_Company = frm_Company.CreateInstance();
					//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//VB.Global.Load(o_Local_Show_Company);
					o_Local_Show_Company.Form_Initialize();
					o_Local_Show_Company.StartForm = modGlobalVars.tStart_Form;
					o_Local_Show_Company.Reference_CompanyID = grd_WantedList.get_RowData(grd_WantedList.CurrentRowIndex);
					o_Local_Show_Company.Reference_CompanyJID = 0;
					o_Local_Show_Company.Show();
					//UPGRADE_WARNING: (2065) Form method o_Local_Show_Company.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
					o_Local_Show_Company.BringToFront();
					//UPGRADE_WARNING: (2065) Form event Form.Activated has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
					o_Local_Show_Company.Form_Activated(null, new EventArgs());

				}
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Select_Wanted_Error: {excep.Message} No.{Information.Err().Number.ToString()}", "frmActionList");
				search_off();
			}

		}

		public void Select_Callback()
		{
			//******************************************************************************************
			//* Note: VBC id'd the following unreferenced items and handled them as described:         *
			//*                                                                                        *
			//* Local Variables (Removed)                                                              *
			//*  i                                                                                     *
			//******************************************************************************************

			//----------------------------------------------------------------------------------------------
			//Function used to select callbacks
			//----------------------------------------------------------------------------------------------

			frm_Company o_Local_Show_Company = null;

			try
			{

				if (grd_Callbacks.get_RowData(grd_Callbacks.CurrentRowIndex) > 0)
				{

					modCommon.Unload_Form("frm_Company");

					o_Local_Show_Company = frm_Company.CreateInstance();
					//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//VB.Global.Load(o_Local_Show_Company);
					o_Local_Show_Company.Form_Initialize();
					o_Local_Show_Company.StartForm = modGlobalVars.tStart_Form;
					o_Local_Show_Company.Reference_CompanyID = grd_Callbacks.get_RowData(grd_Callbacks.CurrentRowIndex);
					o_Local_Show_Company.Reference_CompanyJID = 0;
					o_Local_Show_Company.Show();
					//UPGRADE_WARNING: (2065) Form method o_Local_Show_Company.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
					o_Local_Show_Company.BringToFront();
					//UPGRADE_WARNING: (2065) Form event Form.Activated has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
					o_Local_Show_Company.Form_Activated(null, new EventArgs());

				}
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"Select_Callback_Error: {excep.Message}");
				search_off();
				return;
			}

		}

		public void SelectExclusiveCallback()
		{
			//----------------------------------------------------------------------------------------------
			//Function used to select exclusive callbacks
			//----------------------------------------------------------------------------------------------

			try
			{

				frm_Company o_Local_Show_Company = null;

				this.Cursor = Cursors.WaitCursor;

				snp_ExclusiveCallback.MoveFirst();
				int tempForEndVar = grd_Exclusives.CurrentRowIndex - 1;
				for (int i = 1; i <= tempForEndVar; i++)
				{
					snp_ExclusiveCallback.MoveNext();
				}

				modCommon.Unload_Form("frm_Company");

				o_Local_Show_Company = frm_Company.CreateInstance();
				//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//VB.Global.Load(o_Local_Show_Company);
				o_Local_Show_Company.Form_Initialize();
				o_Local_Show_Company.StartForm = modGlobalVars.tStart_Form;
				o_Local_Show_Company.Reference_CompanyID = Convert.ToInt32(snp_ExclusiveCallback["Comp_id"]);
				o_Local_Show_Company.Reference_CompanyJID = 0;
				o_Local_Show_Company.Show();
				//UPGRADE_WARNING: (2065) Form method o_Local_Show_Company.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
				o_Local_Show_Company.BringToFront();
				//UPGRADE_WARNING: (2065) Form event Form.Activated has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
				o_Local_Show_Company.Form_Activated(null, new EventArgs());
			}
			catch
			{

				modAdminCommon.Report_Error("SelectExclusiveCallbackError: ");
				search_off();
				return;
			}

		}


		private void cbo_multi_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.cbo_multi, eventSender);

			if (Index == 0 || Index == 1)
			{
				cmd_refresh_Click(cmd_refresh[4], new EventArgs());
			}
			else if (Index == 1)
			{ 

				cmd_refresh_Click(cmd_refresh[4], new EventArgs());

			}
			else if (Index == 2)
			{ 
				cmd_refresh_Click(cmd_refresh[5], new EventArgs());
			}

		}

		private void cbo_TimeScale_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs)
		{


			// RTW - MODIFIED - 2/7/2012 - SCALE FOR INCREASING SEARCH
			if (cbo_TimeScale.Text == "Week")
			{
				txt_ListStartDate.Text = DateTimeHelper.ToString(DateTime.Parse(txt_Callback_Date.Text).AddDays(-7));
			}
			else if (cbo_TimeScale.Text == "Month")
			{ 
				txt_ListStartDate.Text = DateTimeHelper.ToString(DateTime.Parse(txt_Callback_Date.Text).AddMonths(-1));
			}
			else if (cbo_TimeScale.Text == "Year")
			{ 
				txt_ListStartDate.Text = DateTimeHelper.ToString(DateTime.Parse(txt_Callback_Date.Text).AddMonths(-12));
			}
			else
			{
				txt_ListStartDate.Text = "";
			}
		}

		private void chk_Account_Rep_Wanted_CheckStateChanged(Object eventSender, EventArgs eventArgs) => Fill_WantedList();


		private void chk_action_list_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.chk_action_list, eventSender);


			switch(Index)
			{
				case chkShowIQCompleted : case chkExcludedReassigns : case chkHideIQDeclined : case chkOnlyShowCBForAvail : case chkAllCompanies : 
					cmdRefresh_Click(cmdRefresh, new EventArgs()); 
					 
					break;
				case chkViewMasterList : 
					 
					Fill_Callback_Grid(); 
					 
					if (chk_action_list[chkViewMasterList].CheckState == CheckState.Checked)
					{
						mnuViewAcctRepMasterList.Checked = true;
						lbl_gen[1].Visible = false;
						txt_Callback_Date.Visible = false;
						cal_Callback.Visible = false;
					}
					else
					{
						mnuViewAcctRepMasterList.Checked = false;
						lbl_gen[1].Visible = true;
						txt_Callback_Date.Visible = true;
						cal_Callback.Visible = true;
					}  // If chk_action_list(chkViewMasterList).Value = vbChecked Then 
					 
					break;
				case chkClassA : 
					 
					if (chk_action_list[chkClassA].CheckState == CheckState.Checked)
					{
						Text4.Visible = true;
						Label24.Visible = true;
					}
					else
					{
						Text4.Visible = false;
						Label24.Visible = false;
					} 
					 
					Fill_Callback_Grid(); 
					 
					break;
				case chkViewDocsOrdered : 
					 
					break;
				case chkViewDocsSending : 

					 
					break;
				case 12 : 
					 
					// added MSW - for top 10 models select -------- 12/29/2020-- 
					cmd_DocsInProcessRefresh_Click(cmd_DocsInProcessRefresh, new EventArgs()); 
					 
					break;
			} // Case Index

		} // chk_action_list_Click

		//UPGRADE_NOTE: (7001) The following declaration (chk_All_ABI_Dealers_Click) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void chk_All_ABI_Dealers_Click()
		//{
			//
		//}

		private void chk_AllDocuments_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{

			if (chkResponses.CheckState == CheckState.Checked)
			{
				chkResponses.CheckState = CheckState.Unchecked;
			}
			else
			{
				cmd_DocsInProcessRefresh_Click(cmd_DocsInProcessRefresh, new EventArgs());
			}
		}



		private void chk_alt_rep_CheckStateChanged(Object eventSender, EventArgs eventArgs) => cbo_account_id_SelectionChangeCommitted(cbo_account_id, new EventArgs());


		private void chk_compact_MouseDown(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;

			Application.DoEvents();
			Application.DoEvents();
			Application.DoEvents();
			Application.DoEvents();

			if (is_compact_view.Trim() == "")
			{
				is_compact_view = "Y";
			}
			else if (is_compact_view.Trim() == "Y")
			{ 
				is_compact_view = "N";
			}
			else if (is_compact_view.Trim() == "N")
			{ 
				is_compact_view = "Y";
			}
			else
			{
				is_compact_view = "Y";
			}

			Application.DoEvents();
			Application.DoEvents();
			Application.DoEvents();
			Application.DoEvents();

			cmd_DocsInProcessRefresh_Click(cmd_DocsInProcessRefresh, new EventArgs());

			Application.DoEvents();
			Application.DoEvents();
			Application.DoEvents();
			Application.DoEvents();

		}


		private void chk_EventsToday_CheckStateChanged(Object eventSender, EventArgs eventArgs) => fraDateTimeRange.Visible = chk_EventsToday.CheckState != CheckState.Checked;



		private void chk_HotItemsAcctRep_CheckStateChanged(Object eventSender, EventArgs eventArgs) => Fill_Hot_Items_Grid();


		//UPGRADE_NOTE: (7001) The following declaration (chk_Offlist_Click) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void chk_Offlist_Click()
		//{
			//
		//}

		private void chkAttachedDocs_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{
			if (chkResponses.CheckState == CheckState.Checked)
			{
				chkResponses.CheckState = CheckState.Unchecked;
			}
			else
			{
				cmd_DocsInProcessRefresh_Click(cmd_DocsInProcessRefresh, new EventArgs());
			}
		}

		//UPGRADE_NOTE: (7001) The following declaration (chkHelicopterOnly_Click) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void chkHelicopterOnly_Click()
		//{
			//
			//int TabNum = SSTabHelper.GetSelectedIndex(tab_callback);
			//switch(TabNum)
			//{
				//case 0 :  //primary callbacks 
					//cmdRefresh_Click(cmdRefresh, new EventArgs()); 
					//break;
				//case 1 :  //reassignments 
					//cmd_Refresh_Reassignments_Click(cmd_Refresh_Reassignments, new EventArgs()); 
					//break;
				//case 2 :  //company color confirm 
					//cmd_Refresh_CompColorConfirm_Click(cmd_Refresh_CompColorConfirm, new EventArgs()); 
					//break;
				//case 3 :  //reverify exclusive 
					//cmd_refresh_Click(cmd_refresh[2], new EventArgs()); 
					//break;
				//case 4 :  //hot items 
					//Fill_Hot_Items_Grid(); 
					//break;
				//case 5 :  //expired leases 
					//cmd_refresh_Click(cmd_refresh[0], new EventArgs()); 
					//break;
				//case 6 :  //fractional owners 
					//cmdRefreshFractOwners_Click(cmdRefreshFractOwners, new EventArgs()); 
					//break;
				//case 7 :  //wanted 
					//cmd_Refresh_Wanted_Click(cmd_Refresh_Wanted, new EventArgs()); 
					//break;
				//case 8 :  //available 
					//cmdRefreshAvailAircraft_Click(cmdRefreshAvailAircraft, new EventArgs()); 
					//break;
				//case 9 :  //docs in process 
					//cmd_DocsInProcessRefresh_Click(cmd_DocsInProcessRefresh, new EventArgs()); 
					//break;
				//case 10 :  //events 
					//cmdFillEvents_Click(cmdFillEvents, new EventArgs()); 
					//break;
			//}
			//
		//}

		private void chkDoNotIncludeWrittenOffAC_CheckStateChanged(Object eventSender, EventArgs eventArgs) => Fill_Comp_Confirm_Grid("");


		private void chkNotPrimary_CheckStateChanged(Object eventSender, EventArgs eventArgs) => Fill_Comp_Confirm_Grid("");


		private void ChkRelatedtoAircraft_CheckStateChanged(Object eventSender, EventArgs eventArgs) => Fill_Comp_Confirm_Grid();


		private void chkResponses_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{
			if (chkResponses.CheckState == CheckState.Checked)
			{ //7/14/04 aey
				chk_AllDocuments.CheckState = CheckState.Unchecked;
				chkAttachedDocs.CheckState = CheckState.Unchecked;
				cmd_DocsInProcessRefresh_Click(cmd_DocsInProcessRefresh, new EventArgs());
			}
			else
			{
				cmd_DocsInProcessRefresh_Click(cmd_DocsInProcessRefresh, new EventArgs());
			}

		}

		private void cmbColorConfirmType_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs)
		{

			cmbColorConfirmType.Enabled = false;
			Fill_Comp_Confirm_Grid("");
			cmbColorConfirmType.Enabled = true;

		}

		private void cmbDocType_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{

			int lRow1 = 0;
			int lCol1 = 0;
			int lPos1 = 0;
			int lACId = 0;
			string strFAALogId = "";
			int lFAALogId = 0;

			string strCurrentDocType = "";
			string strNewDocType = "";

			string strCurrentFAAProcessDir = "";
			string strNewFAAProcessDir = "";

			string strCurrentFileName = "";
			string strNewFileName = "";

			string strUpdate1 = "";

			if (cmbDocType.Enabled)
			{

				lRow1 = grd_DocumentLog.CurrentRowIndex;
				lCol1 = 2;
				strCurrentDocType = Convert.ToString(grd_DocumentLog[lRow1, lCol1].Value);

				strNewDocType = cmbDocType.Text;
				lPos1 = (strNewDocType.IndexOf(" - ") + 1);
				strNewDocType = strNewDocType.Substring(0, Math.Min(lPos1 - 1, strNewDocType.Length));

				if (strCurrentDocType != strNewDocType)
				{

					if (MessageBox.Show($"Change Current Document Type To {Environment.NewLine}{Environment.NewLine}{cmbDocType.Text}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
					{

						strFAALogId = Convert.ToString(grd_DocumentLog[lRow1, 10].Value);
						lFAALogId = Convert.ToInt32(Double.Parse(strFAALogId));
						lACId = grd_DocumentLog.get_RowData(lRow1);

						strCurrentFAAProcessDir = modCommon.Return_FAA_Document_Root_Directory(strCurrentDocType);
						strCurrentFileName = modCommon.Get_FAA_Document_In_Process_File_Name(lFAALogId, lACId);

						//-- Now Update Document Log Table

						strUpdate1 = $"UPDATE FAA_Document_Log SET faalog_doc_type = '{strNewDocType}' ";
						strUpdate1 = $"{strUpdate1}WHERE (faalog_id = {lFAALogId.ToString()}) ";

						DbCommand TempCommand = null;
						TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
						TempCommand.CommandText = strUpdate1;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand.CommandType = (CommandType) (((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()) + ((int) CommandType.Text));
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
						TempCommand.ExecuteNonQuery();

						strNewFAAProcessDir = modCommon.Return_FAA_Document_Root_Directory(strNewDocType);
						strNewFileName = modCommon.Get_FAA_Document_In_Process_File_Name(lFAALogId, lACId);

						if (File.Exists($"{strCurrentFAAProcessDir}{strCurrentFileName}"))
						{

							if (File.Exists($"{strNewFAAProcessDir}{strNewFileName}"))
							{
								//UPGRADE_WARNING: (2081) DeleteFile has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
								File.Delete($"{strNewFAAProcessDir}{strNewFileName}");
							}

							File.Move($"{strCurrentFAAProcessDir}{strCurrentFileName}", $"{strNewFAAProcessDir}{strNewFileName}");

						} // If gfso.FileExists(strCurrentFAAProcessDir + strCurrentFileName) = True Then

						grd_DocumentLog[lRow1, 2].Value = strNewDocType;

						modAdminCommon.Record_Event("Change FAALog DocType", $"ChangedDocument Type From [{strCurrentDocType}] To [{strNewDocType}] On FAALogId: [{strFAALogId}]", lACId, 0, 0, false, 0, 0);

						grd_DocumentLog.CurrentRowIndex = lRow1;
						modCommon.Highlight_Grid_Row(grd_DocumentLog);

					} // If MsgBox("Change Current Document Type To " & vbCrLf & vbCrLf & cmbDocType.Text, vbYesNo) = vbYes Then

				} // If strCurrentDocType <> strNewDocType Then

				lbl_gen[36].Visible = false;
				cmbDocType.Visible = false;

			} // If cmbDocType.Enabled = True Then

		} // cmbDocType_Click

		private void cmbFindDupReports_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs)
		{

			cmbFindDupReports.Enabled = false;
			cmdFindDupsRefresh.Enabled = false;

			if (cmbFindDupReports.Text != "")
			{

				fgrdFindDups.Tag = "Company, Address1Search";
				if (cmbFindDupReports.Text.IndexOf("Company") >= 0)
				{
					fgrdFindDups.Tag = "Company, Address1Search";
				}
				if (cmbFindDupReports.Text.IndexOf("Company") >= 0)
				{
					fgrdFindDups.Tag = "ContactSearch, Company";
				}

				Fill_Find_Duplicate_Callback_Grid();

			} // If cmbFindDupReports.Text <> "" Then

			cmdFindDupsRefresh.Enabled = true;
			cmbFindDupReports.Enabled = true;

		} // cmbFindDupReports_Click

		private void cmbFindResearchReports_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs)
		{

			int iReportId = 0;

			cmbFindResearchReports.Enabled = false;
			cmdResearchReportsRefresh.Enabled = false;

			cmbFindResearchReports.Tag = "";
			string strReportName = cmbFindResearchReports.Text;

			if (strReportName != "")
			{

				iReportId = cmbFindResearchReports.GetItemData(cmbFindResearchReports.SelectedIndex);

				switch(iReportId)
				{
					case 171 :  // Aircraft With A PEvent CREG Where RegNbr Was Removed 6mths Prior 
						if (MessageBox.Show($"This Report Can Take A Long Time To Process.  Continue?{Environment.NewLine}{Environment.NewLine}{strReportName}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
						{
							Fill_Find_Research_Reports_Grid();
						} 
						 
						break;
					default:
						Fill_Find_Research_Reports_Grid(); 
						break;
				}

			} // If strReportName <> "" Then

			cmbFindResearchReports.Enabled = true;
			cmdResearchReportsRefresh.Enabled = true;

		} // cmbFindResearchReports_Click

		private void cmbProductType_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs)
		{

			int TabNum = 0;

			if (!bIsFormLoad)
			{

				ToolTipMain.SetToolTip(cmbProductType, cmbProductType.Text);
				Application.DoEvents();

				TabNum = SSTabHelper.GetSelectedIndex(tab_callback);

				switch(TabNum)
				{
					case 0 :  //primary callbacks 
						cmdRefresh_Click(cmdRefresh, new EventArgs()); 
						break;
					case 1 :  //reassignments 
						cmd_Refresh_Reassignments_Click(cmd_Refresh_Reassignments, new EventArgs()); 
						break;
					case 2 :  //company color confirm 
						cmd_Refresh_CompColorConfirm_Click(cmd_Refresh_CompColorConfirm, new EventArgs()); 
						break;
					case 3 :  //reverify exclusive 
						cmd_refresh_Click(cmd_refresh[2], new EventArgs()); 
						break;
					case 4 :  //hot items 
						Fill_Hot_Items_Grid(); 
						break;
					case 5 :  //expired leases 
						cmd_refresh_Click(cmd_refresh[0], new EventArgs()); 
						break;
					case 6 :  //fractional owners 
						cmdRefreshFractOwners_Click(cmdRefreshFractOwners, new EventArgs()); 
						break;
					case 7 :  //wanted 
						cmd_Refresh_Wanted_Click(cmd_Refresh_Wanted, new EventArgs()); 
						break;
					case 8 :  //available 
						cmdRefreshAvailAircraft_Click(cmdRefreshAvailAircraft, new EventArgs()); 
						break;
					case 9 :  //docs in process 
						cmd_DocsInProcessRefresh_Click(cmd_DocsInProcessRefresh, new EventArgs()); 
						break;
					case 10 :  //events 
						cmdFillEvents_Click(cmdFillEvents, new EventArgs()); 
						break;
					case 13 :  // Yachts 
						// cmd_Refresh_Yacht_Callback_List_Click 
						break;
					case 14 :  // Owr=Opr 
						cmdOwrOprRefresh_Click(cmdOwrOprRefresh, new EventArgs()); 
						break;
					case 15 :  // Find Dups 
						cmdFindDupsRefresh_Click(cmdFindDupsRefresh, new EventArgs()); 
						break;
					case 19 :  // Research Reports 
						cmdResearchReportsRefresh_Click(cmdResearchReportsRefresh, new EventArgs()); 
						break;
				}

			} // If bIsFormLoad = False Then

		}

		//UPGRADE_NOTE: (7001) The following declaration (cmd_AirBP_Refresh_Click) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void cmd_AirBP_Refresh_Click()
		//{
			//
		//}

		//UPGRADE_NOTE: (7001) The following declaration (cmd_change_acrep_Click) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void cmd_change_acrep_Click()
		//{
			//
			////  Dim lSubISId As Long
			////  Dim lRow As Long
			////  Dim lCol As Long
			////  Dim strUpdate1 As String
			////
			////  lRow = fgrdFindCustSubData.Row
			////
			////    If lRow > 0 Then
			////          lSubISId = fgrdFindCustSubData.RowData(lRow)
			////      If lSubISId > 0 Then
			////          If cmd_in_progress.Caption = "Change to: No Longer In Process" Then
			////            strUpdate1 = "UPDATE Subscription_Install_Log SET subislog_msg_type = 'Submitted Data' "
			////          Else
			////            strUpdate1 = "UPDATE Subscription_Install_Log SET subislog_msg_type = 'Submitted Data In Progress' "
			////          End If
			////
			////
			////          strUpdate1 = strUpdate1 & "WHERE (subislog_id = " & CStr(lSubISId) & ") "
			////
			////          LOCAL_ADO_DB.Execute strUpdate1, , adCmdText + adExecuteNoRecords
			////
			////
			////           If cmdFindCustSubDataRefresh.Enabled = True Then
			////
			////            cmdFindCustSubDataRefresh.Enabled = False
			////
			////            Fill_Find_Customer_Submitted_Data_Grid
			////
			////            cmdFindCustSubDataRefresh.Enabled = True
			////
			////            cmd_in_progress.Visible = False
			////
			////          End If ' If cmdFindCustSubDataRefresh.Enabled = True Then
			////
			////      End If
			////    End If
			//
			//
			//
		//}


		private void cmd_ClearFractionalReassign_Click(Object eventSender, EventArgs eventArgs)
		{
			//7/7/04 aey
			//find the journal entry for the curent row and update the row

			int CompID = 0;
			string Query = "";
			ADORecordSetHelper adoClearJourn = new ADORecordSetHelper();

			//grdFractional.Col = 6
			//CompID = Val(grdFractional.Text)
			grdFractional.CurrentColumnIndex = 7;
			int JournID = Convert.ToInt32(Conversion.Val(grdFractional[grdFractional.CurrentRowIndex, grdFractional.CurrentColumnIndex].FormattedValue.ToString()));

			if (grdFractional.CurrentRowIndex < 0)
			{
				return;
			}
			string Msg = "Are you sure you want to clear this reassign?";

			if (MessageBox.Show(Msg, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
			{
				if (grdFractional.CurrentRowIndex >= 0)
				{

					Query = "select journ_id,journ_subcategory_code,journ_action_date, journ_subject from Journal WITH(NOLOCK) ";
					Query = $"{Query}where journ_id={JournID.ToString()} And journ_subcategory_code = 'FR' ";

					adoClearJourn.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);
					if (!(adoClearJourn.BOF && adoClearJourn.EOF))
					{
						//snp_Journal.MoveLast
						adoClearJourn.MoveFirst();

						Msg = $"{Convert.ToString(adoClearJourn["journ_subject"])}  Cleared {modAdminCommon.DateToday}";
						adoClearJourn["journ_subcategory_code"] = "FRC";
						adoClearJourn["journ_subject"] = Msg.Substring(0, Math.Min(120, Msg.Length)).Trim();
						if (modCommon.GetTransWeb("FRC"))
						{
							adoClearJourn["journ_action_date"] = "1/1/1900";
						}
						else
						{
							adoClearJourn["journ_action_date"] = modAdminCommon.GetDateTime();
						}

						adoClearJourn.Update();

						Opt_Reassigned_CheckedChanged(Opt_Reassigned, new EventArgs());

					}
					adoClearJourn.Close();
					adoClearJourn = null;

				}
			}

		}


		private void cmd_contacts_phone_Click(Object eventSender, EventArgs eventArgs)
		{


			modCommon.Build_Company_NameAddress(lstCompany, RememberExclusiveCompanyId, 0, "", true);
			cmd_contacts_phone.Visible = false;

		}

		private void cmd_DocsInProcessRefresh_Click(Object eventSender, EventArgs eventArgs)
		{

			string strMsg = "";
			System.DateTime dtStartDate = DateTime.FromOADate(0);
			System.DateTime dtEndDate = DateTime.FromOADate(0);

			modCommon.Start_Activity_Monitor_Message("Callback Docs In Process", ref strMsg, ref dtStartDate, ref dtEndDate);

			cmd_DocsInProcessRefresh.PerformClick();

			if (chkResponses.CheckState == CheckState.Checked)
			{ //7/14/04 aey
				Fill_Document_Responses();
			}
			else
			{
				Fill_Documents_In_Process();
			}

			strMsg = $"AcctRep: {cbo_account_id.Text}";
			strMsg = $"{strMsg} Product: {cmbProductType.Text}";
			strMsg = $"{strMsg} Callback Date: {txt_Callback_Date.Text}";

			if (chk_AllDocuments.CheckState == CheckState.Checked)
			{
				strMsg = $"{strMsg} [x] All Docs ";
			}
			if (chkAttachedDocs.CheckState == CheckState.Checked)
			{
				strMsg = $"{strMsg} [x] Attached Docs ";
			}
			if (chkResponses.CheckState == CheckState.Checked)
			{
				strMsg = $"{strMsg} [x] Doc Responses ";
			}
			strMsg = $"{strMsg} Doc Class: {cmbDocInProcsClass.Text}";

			if (bLog)
			{

				modCommon.End_Activity_Monitor_Message("Callback Docs In Process", ref strMsg, dtStartDate, ref dtEndDate, 0, 0, 0, 0, 0);

				frm_UserHistory.DefInstance.Refresh_User_History_Grids("Callback");

			}

			cmd_DocsInProcessRefresh.Enabled = true;

		} // cmd_DocsInProcessRefresh_Click

		private void cmd_export_docs_Click(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.cmd_export_docs, eventSender);

			cmd_export_docs[Index].Enabled = false;

			if (Index == 0)
			{
				modExcel.ExportMSHFlexGrid(grd_DocumentLog);
			}
			else if (Index == 1)
			{ 
				modExcel.ExportMSHFlexGrid(grd_Hot_Items);
			}
			else if (Index == 2)
			{ 
				Fill_Documents_In_Process(true);
				modExcel.ExportMSHFlexGrid(grd_DocumentLog);
			}

			cmd_export_docs[Index].Enabled = true;


		}

		private void cmd_Fix_Fract_Owners_Click(Object eventSender, EventArgs eventArgs)
		{

			if (mvHasFocus)
			{
				mvHasFocus = false;
			}
			Fix_Fract_Owners();

		}

		private void cmd_in_progress_Click(Object eventSender, EventArgs eventArgs)
		{

			int lSubISId = 0;
			int lRow = 0;
			int lCol = 0;
			string strUpdate1 = "";

			try
			{

				lRow = fgrdFindCustSubData.CurrentRowIndex;

				if (lRow > 0)
				{

					cmd_in_progress.Enabled = false;

					lSubISId = fgrdFindCustSubData.get_RowData(lRow);
					if (lSubISId > 0)
					{

						if (cmd_in_progress.Text == "Change to: No Longer In Process")
						{
							strUpdate1 = "UPDATE Subscription_Install_Log SET subislog_msg_type = 'Submitted Data' ";
						}
						else
						{
							strUpdate1 = "UPDATE Subscription_Install_Log SET subislog_msg_type = 'Submitted Data In Progress' ";
						}

						strUpdate1 = $"{strUpdate1}WHERE (subislog_id = {lSubISId.ToString()}) ";

						DbCommand TempCommand = null;
						TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
						TempCommand.CommandText = strUpdate1;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
						TempCommand.ExecuteNonQuery();

						cmdFindCustSubDataRefresh_Click(cmdFindCustSubDataRefresh, new EventArgs());

					} // If lSubISId > 0 Then

					cmd_in_progress.Enabled = true;

				} // If lRow > 0 Then
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Record_Error("cmd_in_progress_Click_Error", $"{Information.Err().Number.ToString()} - {excep.Message}");
			}

		} // cmd_in_progress_Click

		private void cmd_New_Avail_Click(Object eventSender, EventArgs eventArgs)
		{

			if (cbo_account_id.Text.Trim().ToUpper() != "ALL")
			{
				frm_WebCrawl.DefInstance.WhichAcctRep = cbo_account_id.Text;
			}
			if (mvHasFocus)
			{
				mvHasFocus = false;
			}
			frm_WebCrawl.DefInstance.Show();

		}

		//UPGRADE_NOTE: (7001) The following declaration (cmd_pub_Click) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void cmd_pub_Click(int Index)
		//{
			//
			//
			//
		//}

		//UPGRADE_NOTE: (7001) The following declaration (cmd_Refresh_abi_Click) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void cmd_Refresh_abi_Click()
		//{
			//
			//
		//}

		private void cmd_refresh_Click(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.cmd_refresh, eventSender);


			switch(Index)
			{
				case 0 :  // Expired Leases 
					 
					if (mvHasFocus)
					{
						mvHasFocus = false;
					} 
					Fill_Aircraft_Expired_Leases_Grid(); 
					 
					break;
				case 1 :  // Hot Items 
					 
					if (mvHasFocus)
					{
						mvHasFocus = false;
					} 
					 
					Fill_Hot_Items_Grid(); 
					 
					break;
				case 2 :  // Exclusive Callback 
					 
					if (mvHasFocus)
					{
						mvHasFocus = false;
					} 
					 
					Fill_Exclusive_Callback_Grid(); 
					 
					break;
				case 4 :  //Issues 
					 
					Application.DoEvents(); 
					Application.DoEvents(); 
					Application.DoEvents(); 
					this.Cursor = Cursors.WaitCursor; 
					Application.DoEvents(); 
					this.Cursor = Cursors.WaitCursor; 
					Application.DoEvents(); 
					Application.DoEvents(); 
					 
					if (cbo_multi[0].Text == "Aircraft")
					{
						Fill_Issues_Callback_Grid_AC();
					}
					else
					{
						Fill_Issues_Callback_Grid();
					} 

					 
					Application.DoEvents(); 
					Application.DoEvents(); 
					this.Cursor = CursorHelper.CursorDefault; 
					Application.DoEvents(); 
					Application.DoEvents(); 

					 
					break;
				case 5 :  //Salesforce 
					 
					Fill_Salesforce_Callback_Grid(); 
					 
					break;
			} // Case Index

		} // cmd_Refresh_Click

		private void cmd_Refresh_CompColorConfirm_Click(Object eventSender, EventArgs eventArgs)
		{
			if (mvHasFocus)
			{
				mvHasFocus = false;
			}
			Fill_Comp_Confirm_Grid("");
		}

		private void cmd_Refresh_Reassignments_Click(Object eventSender, EventArgs eventArgs)
		{
			if (mvHasFocus)
			{
				mvHasFocus = false;
			}
			Fill_New_Assignment_Grid();
		}

		private void cmd_Refresh_Wanted_Click(Object eventSender, EventArgs eventArgs)
		{

			if (mvHasFocus)
			{
				mvHasFocus = false;
			}

			Fill_WantedList();

		}



		private void cmd_ClearReassign_Click(Object eventSender, EventArgs eventArgs)
		{

			string Msg = "";
			string Query = "";

			try
			{

				if (grd_NewAssignments.RowSel > grd_NewAssignments.CurrentRowIndex)
				{
					Msg = "Are you sure you want to clear the selected reassigns?";
				}
				else
				{
					Msg = "Are you sure you want to clear this reassign?";
				}

				if (MessageBox.Show(Msg, "Callbacks", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
				{

					modAdminCommon.ADO_Transaction("BeginTrans");

					if (grd_NewAssignments.RowSel > grd_NewAssignments.CurrentRowIndex)
					{
						int tempForEndVar = grd_NewAssignments.RowSel;
						for (int i = grd_NewAssignments.CurrentRowIndex; i <= tempForEndVar; i++)
						{
							grd_NewAssignments.CurrentRowIndex = i;

							//UPGRADE_ISSUE: (2064) MSHierarchicalFlexGridLib.MSHFlexGrid property grd_NewAssignments.BandData was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							Query = $"EXEC HomebaseClearAircraftReassigns {grd_NewAssignments.BandData(grd_NewAssignments.CurrentRowIndex).ToString()},{cbo_account_id.Text.Trim()},{modAdminCommon.gbl_Account_ID},'{modAdminCommon.gbl_User_ID}' ";
							DbCommand TempCommand = null;
							TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
							TempCommand.CommandText = Query;
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
							TempCommand.CommandType = (CommandType) (((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()) + ((int) CommandType.Text));
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
							TempCommand.ExecuteNonQuery();

						}

					}
					else
					{

						//UPGRADE_ISSUE: (2064) MSHierarchicalFlexGridLib.MSHFlexGrid property grd_NewAssignments.BandData was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						Query = $"EXEC HomebaseClearAircraftReassigns {grd_NewAssignments.BandData(grd_NewAssignments.CurrentRowIndex).ToString()},{cbo_account_id.Text.Trim()},{modAdminCommon.gbl_Account_ID},'{modAdminCommon.gbl_User_ID}' ";
						DbCommand TempCommand_2 = null;
						TempCommand_2 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
						TempCommand_2.CommandText = Query;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand_2.CommandType = (CommandType) (((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()) + ((int) CommandType.Text));
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
						TempCommand_2.ExecuteNonQuery();

					}

					modAdminCommon.ADO_Transaction("CommitTrans");

					Fill_New_Assignment_Grid();

				}
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"ClearAircraftReassigns_error ({Information.Err().Number.ToString()}) {excep.Message}", "frm_ActionList(RESSAGINCLICK)");
				modAdminCommon.ADO_Transaction("RollbackTrans");
			}

		}

		//UPGRADE_NOTE: (7001) The following declaration (cmd_remove_from_airbp_Click) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void cmd_remove_from_airbp_Click()
		//{
			//
		//}

		private void cmd_Update_Callback_Dates_Click(Object eventSender, EventArgs eventArgs)
		{

			if (snp_Callback.State == ConnectionState.Open)
			{ //aey 4/11/05

				string tempRefParam = "Updating Callback ";
				search_on(ref tempRefParam);
				if (!(snp_Callback.BOF && snp_Callback.EOF))
				{

					while(!snp_Callback.EOF)
					{
						modCompany.update_company_callback_date(Convert.ToInt32(snp_Callback["Comp_id"]), modGlobalVars.cEmptyString);
						snp_Callback.MoveNext();
					};
				}

			}
			else
			{
				cmd_Update_Callback_Dates.Visible = false;
			}

			if (mvHasFocus)
			{
				mvHasFocus = false;
			}

			search_off();

		}

		private void cmdCSDChangeAcctRep_Click(Object eventSender, EventArgs eventArgs)
		{

			int lRow = 0;
			int lSubISId = 0;
			string strAcctRepNew = "";
			string strAcctRepOld = "";
			string strUpdate1 = "";

			int lACId = 0;
			int lCompId = 0;
			int lContactId = 0;
			int lJournId = 0;

			try
			{

				lRow = fgrdFindCustSubData.CurrentRowIndex;

				if (lRow > 0)
				{

					if (cmdCSDChangeAcctRep.Enabled)
					{

						cmdCSDChangeAcctRep.Enabled = false;

						lSubISId = fgrdFindCustSubData.get_RowData(lRow);
						strAcctRepNew = cmbCustSubAcctRep.Text;
						strAcctRepOld = Convert.ToString(fgrdFindCustSubData[lRow, 14].Value);

						lCompId = Convert.ToInt32(Double.Parse(Convert.ToString(fgrdFindCustSubData[lRow, 1].Value))); // CompId
						lContactId = Convert.ToInt32(Double.Parse(Convert.ToString(fgrdFindCustSubData[lRow, 4].Value))); // Contact Id
						lACId = Convert.ToInt32(Double.Parse(Convert.ToString(fgrdFindCustSubData[lRow, 6].Value))); // ACId
						lJournId = Convert.ToInt32(Double.Parse(Convert.ToString(fgrdFindCustSubData[lRow, 7].Value))); // JournId

						if (strAcctRepNew != strAcctRepOld)
						{

							strUpdate1 = "UPDATE Subscription_Install_Log ";
							if (strAcctRepNew == "" || strAcctRepNew.ToUpper() == "NO REP SELECTED")
							{
								strUpdate1 = $"{strUpdate1}SET subislog_account_id = '' ";
							}
							else
							{
								strUpdate1 = $"{strUpdate1}SET subislog_account_id = '{strAcctRepNew}' ";
							}

							strUpdate1 = $"{strUpdate1}WHERE (subislog_id = {lSubISId.ToString()}) ";

							DbCommand TempCommand = null;
							TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
							TempCommand.CommandText = strUpdate1;
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
							TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
							TempCommand.ExecuteNonQuery();

							modAdminCommon.Record_Event("Submitted Data", $"Changed Account Rep From: [{strAcctRepOld}] To [{strAcctRepNew}] - SubIsLogId=[{lSubISId.ToString()}]", lACId, lJournId, lCompId, false, 0, lContactId);

							cmdFindCustSubDataRefresh_Click(cmdFindCustSubDataRefresh, new EventArgs());
							fgrdFindCustSubData.CurrentRowIndex = lRow;
							modCommon.Highlight_Grid_Row(fgrdFindCustSubData);
							cmbCustSubAcctRep.Text = strAcctRepNew;

							cmdCSDChangeAcctRep.Enabled = true;

						}
						else
						{
							MessageBox.Show("Account Rep Selected Is Already Assigned To This Record", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						} // If strAcctRepNew <> strAcctRepOld Then

					} // If cmdCSDChangeAcctRep.Enabled = True Then

				} // If lRow > 0 Then
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"cmdCSDChangeAcctRep_Click_Error ({Information.Err().Number.ToString()}) {excep.Message}", "frm_ActionList(Customer Submitted Data)");
			}

		} // cmdCSDChangeAcctRep_Click

		private void cmdConfirmExclusive_Click(Object eventSender, EventArgs eventArgs)
		{

			// 06/10/2008 - By David D. Cruger
			// Per Lucia Fronteria this button should be de-activated
			// It is not to be used anywhere on this form
			cmdConfirmExclusive.Visible = false;
			cmdConfirmExclusive.Enabled = false;

			if (cmdConfirmExclusive.Enabled)
			{

				if (Conversion.Val(RememberExclusiveCompanyId.ToString()) != 0)
				{
					this.Cursor = Cursors.WaitCursor;

					modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Confirming Company...", Color.Blue);
					modCommon.Confirm_Company(RememberExclusiveCompanyId);
					//      Show_Company_Color_Confirm_Info
					//      Show_New_Assign_Confirm_Info

					if (SSTabHelper.GetSelectedIndex(tab_callback) == 0)
					{
						grd_Callbacks_Click(grd_Callbacks, new EventArgs());
					}
					if (SSTabHelper.GetSelectedIndex(tab_callback) == 1)
					{
						grd_NewAssignments_Click(grd_NewAssignments, new EventArgs());
					}
					if (SSTabHelper.GetSelectedIndex(tab_callback) == 2)
					{
						grd_CompConfirm_Click(grd_CompConfirm, new EventArgs());
						//       Fill_Comp_Confirm_Grid
						//      pnl_lstcompany.Visible = False
					}
					if (SSTabHelper.GetSelectedIndex(tab_callback) == 3)
					{
						grd_Exclusives_Click(grd_Exclusives, new EventArgs());
						//       Confirm_Reassign_For_Confirm_Company
					}
					if (SSTabHelper.GetSelectedIndex(tab_callback) == 4)
					{
						grd_Hot_Items_Click(grd_Hot_Items, new EventArgs());
					}
					if (SSTabHelper.GetSelectedIndex(tab_callback) == 5)
					{
						grd_expired_leases_Click(grd_expired_leases, new EventArgs());
					}
					if (SSTabHelper.GetSelectedIndex(tab_callback) == 6)
					{
						grdFractional_Click(grdFractional, new EventArgs());
					}
					if (SSTabHelper.GetSelectedIndex(tab_callback) == 8)
					{
						ShowAvailableAircraftCallbackInfo();
					}
					modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
					this.Cursor = CursorHelper.CursorDefault;
					HadHourglass = false;

				}
				if (mvHasFocus)
				{
					mvHasFocus = false;
				}

			} //If cmdConfirmExclusive.Enabled = True Then

		}


		private void cmdFillEvents_Click(Object eventSender, EventArgs eventArgs)
		{

			if (mvHasFocus)
			{
				mvHasFocus = false;
			}

			if (chk_EventsToday.CheckState == CheckState.Unchecked)
			{
				if (txtEventDateFrom.Text == "" && txtEventDateTo.Text == "")
				{
					MessageBox.Show("When Todays Events Only Is Unchecked A Date From/To Must Be Entered", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}

			Fill_Priority_Events();

		} // cmdFillEvents_Click

		private void cmdFindACNoBaseRefresh_Click(Object eventSender, EventArgs eventArgs)
		{

			if (cmdFindACNoBaseRefresh.Enabled)
			{

				cmdFindACNoBaseRefresh.Enabled = false;

				Fill_Find_AC_With_No_Base_Information_Grid();

				cmdFindACNoBaseRefresh.Enabled = true;

			} // If cmdFindACNoBaseRefresh.Enabled = True Then

		} // cmdFindACNoBaseRefresh_Click

		private void cmdFindACNoCHPRefresh_Click(Object eventSender, EventArgs eventArgs)
		{

			if (cmdFindACNoCHPRefresh.Enabled)
			{

				cmdFindACNoCHPRefresh.Enabled = false;

				Fill_Find_AC_With_No_Chief_Pilots_Grid();

				cmdFindACNoCHPRefresh.Enabled = true;

			} // If cmdFindACNoCHPRefresh.Enabled = True Then

		} // cmdFindACNoCHPRefresh_Click

		private void cmdFindCustSubDataRefresh_Click(Object eventSender, EventArgs eventArgs)
		{

			if (cmdFindCustSubDataRefresh.Enabled)
			{

				cmdFindCustSubDataRefresh.Enabled = false;

				Fill_Find_Customer_Submitted_Data_Grid();

				cmdFindCustSubDataRefresh.Enabled = true;

				cmd_in_progress.Visible = false;

			} // If cmdFindCustSubDataRefresh.Enabled = True Then

		} // cmdFindCustSubDataRefresh_Click

		private void cmdFindLikeCompany_Click(Object eventSender, EventArgs eventArgs)
		{
			int nRememberCol = 0;
			string ts_CompanyName = "";

			lbl_Message.Text = "Loading Company/Contact Search Form ...";

			ts_CompanyName = "";
			if (FindId == "CallBacks")
			{
				ts_CompanyName = lstCompany.GetListItem(0).Substring(0, Math.Min(lstCompany.GetListItem(0).IndexOf("(ID="), lstCompany.GetListItem(0).Length)).Trim();
			}
			else
			{
				if (FindId == "Reassignments")
				{
					ts_CompanyName = lstCompany.GetListItem(0).Substring(0, Math.Min(lstCompany.GetListItem(0).IndexOf("(ID="), lstCompany.GetListItem(0).Length)).Trim();
				}
				else
				{
					if (FindId == "CompColor")
					{
						ts_CompanyName = lstCompany.GetListItem(0).Substring(0, Math.Min(lstCompany.GetListItem(0).IndexOf("(ID="), lstCompany.GetListItem(0).Length)).Trim();
					}
					else
					{
						if (FindId == "Exclusives")
						{
							ts_CompanyName = lstCompany.GetListItem(0).Substring(0, Math.Min(lstCompany.GetListItem(0).IndexOf("(ID="), lstCompany.GetListItem(0).Length)).Trim();
						}
						else
						{
							if (FindId == "HotItemColor")
							{
								ts_CompanyName = lstCompany.GetListItem(0).Substring(0, Math.Min(lstCompany.GetListItem(0).IndexOf("(ID="), lstCompany.GetListItem(0).Length)).Trim();
							}
							else
							{
								if (FindId == "ExpiredLeases")
								{
									ts_CompanyName = lstCompany.GetListItem(0).Substring(0, Math.Min(lstCompany.GetListItem(0).IndexOf("(ID="), lstCompany.GetListItem(0).Length)).Trim();
								}
								else
								{
									if (FindId == "Available Aircraft")
									{
										if (lstCompany.Items.Count > 0)
										{
											ts_CompanyName = lstCompany.GetListItem(0).Trim();
										}
									}
									else
									{
										if (FindId == "Fractional Owner")
										{
											ts_CompanyName = lstCompany.GetListItem(0).Substring(0, Math.Min(lstCompany.GetListItem(0).IndexOf("(ID="), lstCompany.GetListItem(0).Length)).Trim();
										}
										else
										{
											ts_CompanyName = $"{ts_CompanyName}{("*")}";
										}
									}
								}
							}
						}
					}
				}
			}

			tCompFind_ActionTypes = modGlobalVars.e_find_form_action_types.geIdCompany;

			if (ts_CompanyName.Trim() != modGlobalVars.cEmptyString)
			{
				if (modGlobalVars.bCallShowAndLoadOnlyOnce)
				{

					//UPGRADE_TODO: (1067) Member Clear_Search_Criteria is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_MISC].Clear_Search_Criteria(true, true, true);
					//UPGRADE_TODO: (1067) Member EntryPoint is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_MISC].EntryPoint = modGlobalVars.e_find_form_entry_points.geAccountCallback;
					//UPGRADE_TODO: (1067) Member ActionTypes is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_MISC].ActionTypes = tCompFind_ActionTypes;
					//UPGRADE_TODO: (1067) Member Reference_AccountRep is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_MISC].Reference_AccountRep = modAdminCommon.gbl_Account_ID;
					//UPGRADE_TODO: (1067) Member Reference_CompanyName is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_MISC].Reference_CompanyName = ts_CompanyName;
					//UPGRADE_TODO: (1067) Member Show is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_MISC].Show();
					modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_MISC].BringToFront(); //gap-note Manual change to fix BringToFront rule failing sometimes

				}
			}

			if (mvHasFocus)
			{
				mvHasFocus = false;
			}

		}

		private void Fill_Owner_Operator_Callback_Grid_Headers()
		{

			int lRowl = 0;

			fgrdOwrOpr.Clear();
			fgrdOwrOpr.RowsCount = 2;
			fgrdOwrOpr.ColumnsCount = 12;

			fgrdOwrOpr.CurrentRowIndex = 0;

			int lCol1 = -1;

			lCol1++;
			fgrdOwrOpr.CurrentColumnIndex = lCol1;
			fgrdOwrOpr[fgrdOwrOpr.CurrentRowIndex, fgrdOwrOpr.CurrentColumnIndex].Value = "ACId";
			fgrdOwrOpr.SetColumnWidth(lCol1, 53);
			fgrdOwrOpr.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdOwrOpr.CurrentColumnIndex = lCol1;
			fgrdOwrOpr[fgrdOwrOpr.CurrentRowIndex, fgrdOwrOpr.CurrentColumnIndex].Value = "Make";
			fgrdOwrOpr.SetColumnWidth(lCol1, 133);
			fgrdOwrOpr.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdOwrOpr.CurrentColumnIndex = lCol1;
			fgrdOwrOpr[fgrdOwrOpr.CurrentRowIndex, fgrdOwrOpr.CurrentColumnIndex].Value = "Model";
			fgrdOwrOpr.SetColumnWidth(lCol1, 133);
			fgrdOwrOpr.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdOwrOpr.CurrentColumnIndex = lCol1;
			fgrdOwrOpr[fgrdOwrOpr.CurrentRowIndex, fgrdOwrOpr.CurrentColumnIndex].Value = "SerNbr";
			fgrdOwrOpr.SetColumnWidth(lCol1, 100);
			fgrdOwrOpr.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdOwrOpr.CurrentColumnIndex = lCol1;
			fgrdOwrOpr[fgrdOwrOpr.CurrentRowIndex, fgrdOwrOpr.CurrentColumnIndex].Value = "RegNbr";
			fgrdOwrOpr.SetColumnWidth(lCol1, 77);
			fgrdOwrOpr.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdOwrOpr.CurrentColumnIndex = lCol1;
			fgrdOwrOpr[fgrdOwrOpr.CurrentRowIndex, fgrdOwrOpr.CurrentColumnIndex].Value = "CompId";
			fgrdOwrOpr.SetColumnWidth(lCol1, 53);
			fgrdOwrOpr.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdOwrOpr.CurrentColumnIndex = lCol1;
			fgrdOwrOpr[fgrdOwrOpr.CurrentRowIndex, fgrdOwrOpr.CurrentColumnIndex].Value = "Company";
			fgrdOwrOpr.SetColumnWidth(lCol1, 167);
			fgrdOwrOpr.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdOwrOpr.CurrentColumnIndex = lCol1;
			fgrdOwrOpr[fgrdOwrOpr.CurrentRowIndex, fgrdOwrOpr.CurrentColumnIndex].Value = "City";
			fgrdOwrOpr.SetColumnWidth(lCol1, 100);
			fgrdOwrOpr.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdOwrOpr.CurrentColumnIndex = lCol1;
			fgrdOwrOpr[fgrdOwrOpr.CurrentRowIndex, fgrdOwrOpr.CurrentColumnIndex].Value = "State";
			fgrdOwrOpr.SetColumnWidth(lCol1, 40);
			fgrdOwrOpr.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

			lCol1++;
			fgrdOwrOpr.CurrentColumnIndex = lCol1;
			fgrdOwrOpr[fgrdOwrOpr.CurrentRowIndex, fgrdOwrOpr.CurrentColumnIndex].Value = "Country";
			fgrdOwrOpr.SetColumnWidth(lCol1, 100);
			fgrdOwrOpr.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdOwrOpr.CurrentColumnIndex = lCol1;
			fgrdOwrOpr[fgrdOwrOpr.CurrentRowIndex, fgrdOwrOpr.CurrentColumnIndex].Value = "LastAttempt";
			fgrdOwrOpr.SetColumnWidth(lCol1, 100);
			fgrdOwrOpr.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdOwrOpr.CurrentColumnIndex = lCol1;
			fgrdOwrOpr[fgrdOwrOpr.CurrentRowIndex, fgrdOwrOpr.CurrentColumnIndex].Value = "LastIQAttempt";
			fgrdOwrOpr.SetColumnWidth(lCol1, 100);
			fgrdOwrOpr.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			fgrdOwrOpr.FixedRows = 1;
			fgrdOwrOpr.FixedColumns = 0;

			fgrdOwrOpr.CurrentRowIndex = 1;

		} // Fill_Owner_Operator_Callback_Grid_Headers

		private void cmdNewCustSubData_Click(Object eventSender, EventArgs eventArgs) => SSTabHelper.SetSelectedIndex(tab_callback, 18);



		private void cmdResearchReportsExport_Click(Object eventSender, EventArgs eventArgs)
		{


			if (Convert.ToString(cmdResearchReportsExport.Tag) == "1")
			{
				cmdResearchReportsExport.Tag = "2";
				cmbFindResearchReports_SelectionChangeCommitted(cmbFindResearchReports, new EventArgs());
			}



			cmdResearchReportsExport.Enabled = false;
			modExcel.ExportMSHFlexGrid(fgrdFindResearchReports);
			cmdResearchReportsExport.Enabled = true;




		} // cmdResearchReportsExport_Click

		private void cmdResearchReportsRefresh_Click(Object eventSender, EventArgs eventArgs) => cmbFindResearchReports_SelectionChangeCommitted(cmbFindResearchReports, new EventArgs());
		 // cmdResearchReportsRefresh_Click

		private void cmdSubDataEMail_Click(Object eventSender, EventArgs eventArgs)
		{

			string strInsert1 = "";

			int lSubISId = 0;
			int lACId = 0;
			int lCompId = 0;
			int lCompId2 = 0;
			int lContactId = 0;

			string strToEMail = "";
			string strToName = "";
			string strFromEMail = "";
			string strFromName = "";
			string strSubject = "";
			string strBody = "";
			string strStatus = "";
			string strErrorMsg = "";

			string strMake = "";
			string strModel = "";
			string strSerNbr = "";
			string strRegNbr = "";
			string strNote = "";
			string strCompName = "";

			string strJSubject = "";

			string strSMTPServer = "";
			int lSMTPPort = 0;
			string strSMTPUserName = "";
			string strSMTPPassWord = "";

			System.DateTime dtSystemDateTime = DateTime.FromOADate(0);

			string strMsg = "";

			int lRow1 = 0;
			int lCol1 = 0;

			try
			{

				if (cmdSubDataEMail.Enabled)
				{

					cmdSubDataEMail.Enabled = false;

					lRow1 = fgrdFindCustSubData.RowSel;

					if (lRow1 >= 1)
					{

						lSubISId = fgrdFindCustSubData.get_RowData(lRow1);

						if (lSubISId > 0)
						{

							//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
							// 0             1       2        3                   4          5        6     7        8     9      10      11      12       13         14     15,   16
							// Date Entered, CompId, Company, Country-State-City, ContactId, Contact, ACId, JournId, Make, Model, SerNbr, RegNbr, CompId2, CompName2, ACREP, Note, Completed

							lCompId = 0;
							lContactId = 0;
							lACId = 0;
							lCompId2 = 0;

							if (Information.IsNumeric(Convert.ToString(fgrdFindCustSubData[lRow1, 1].Value)))
							{
								lCompId = Convert.ToInt32(Double.Parse(Convert.ToString(fgrdFindCustSubData[lRow1, 1].Value)));
							}
							if (Information.IsNumeric(Convert.ToString(fgrdFindCustSubData[lRow1, 4].Value)))
							{
								lContactId = Convert.ToInt32(Double.Parse(Convert.ToString(fgrdFindCustSubData[lRow1, 4].Value)));
							}
							if (Information.IsNumeric(Convert.ToString(fgrdFindCustSubData[lRow1, 6].Value)))
							{
								lACId = Convert.ToInt32(Double.Parse(Convert.ToString(fgrdFindCustSubData[lRow1, 6].Value)));
							}
							if (Information.IsNumeric(Convert.ToString(fgrdFindCustSubData[lRow1, 12].Value)))
							{
								lCompId2 = Convert.ToInt32(Double.Parse(Convert.ToString(fgrdFindCustSubData[lRow1, 12].Value)));
							}

							if (lCompId > 0)
							{

								if (lContactId > 0)
								{

									if (lACId > 0 || lCompId2 > 0)
									{

										strToEMail = modCommon.DLookUp("contact_email_address", "Contact", $"(contact_id = {lContactId.ToString()}) AND (contact_email_address IS NOT NULL) AND (contact_email_address <> '') AND (contact_journ_id = 0)");
										strToName = Convert.ToString(fgrdFindCustSubData[lRow1, 5].Value).Trim(); //-- Contact Name

										if (strToEMail != "")
										{

											strFromEMail = modCommon.GetUserEMailAddress(modAdminCommon.gbl_User_ID);
											strFromName = modCommon.GetFullUserName(modAdminCommon.gbl_User_ID);

											strMake = Convert.ToString(fgrdFindCustSubData[lRow1, 8].Value).Trim();
											strModel = Convert.ToString(fgrdFindCustSubData[lRow1, 9].Value).Trim();
											strSerNbr = Convert.ToString(fgrdFindCustSubData[lRow1, 10].Value).Trim();
											strRegNbr = Convert.ToString(fgrdFindCustSubData[lRow1, 11].Value).Trim();

											strCompName = Convert.ToString(fgrdFindCustSubData[lRow1, 13].Value).Trim();
											strNote = Convert.ToString(fgrdFindCustSubData[lRow1, 15].Value).Trim();

											strBody = "JETNET has received your feedback and have updated the information you have provided.%0D%0D";

											if (strMake != "")
											{
												strSubject = $"JETNET has received your feedback on {strMake} {strModel} {strSerNbr} {strRegNbr}";
												strBody = $"{strBody}On the following aircraft.%0D%0D";
												strBody = $"{strBody}Make: {strMake}%0D";
												strBody = $"{strBody}Model: {strModel}%0D";
												strBody = $"{strBody}SerNbr: {strSerNbr}%0D";
												strBody = $"{strBody}RegNbr: {strRegNbr}%0D%0D";
											}

											if (strCompName != "")
											{
												strSubject = $"JETNET has received your feedback on {strCompName}";
												strBody = $"{strBody}On the following company.%0D%0D";
												strBody = $"{strBody}Company: {strCompName}%0D";
											}
											strBody = $"{strBody}Submitted Information: {StringsHelper.Replace(strNote, "\"", "", 1, -1, CompareMethod.Binary)}%0D%0D";

											strBody = $"{strBody}Kind regards,%0D%0D";
											strBody = $"{strBody}{strFromName}%0D%0D";

											if (strToEMail != "" && strSubject != "" && strBody != "")
											{
												JetNetSupport.PInvoke.SafeNative.shell32.ShellExecute(Support.GetHInstance().ToInt32(), "open", $"mailto:{strToEMail}?subject={strSubject}&body={strBody}", null, null, 0);
											}

											strJSubject = "Sent email response to customer submitted data";
											strStatus = "Open";
											strErrorMsg = "";

											dtSystemDateTime = DateTime.Parse(modAdminCommon.GetSystemDateTime());

											strInsert1 = "INSERT INTO Journal (";
											strInsert1 = $"{strInsert1}journ_date, ";
											strInsert1 = $"{strInsert1}journ_subcategory_code, ";
											strInsert1 = $"{strInsert1}journ_subject, ";
											strInsert1 = $"{strInsert1}journ_description, ";
											strInsert1 = $"{strInsert1}journ_ac_id, ";
											strInsert1 = $"{strInsert1}journ_comp_id, ";
											strInsert1 = $"{strInsert1}journ_contact_id, ";
											strInsert1 = $"{strInsert1}journ_user_id, ";
											strInsert1 = $"{strInsert1}journ_entry_date, ";
											strInsert1 = $"{strInsert1}journ_entry_time, ";
											strInsert1 = $"{strInsert1}journ_account_id, ";
											strInsert1 = $"{strInsert1}journ_prior_account_id, ";
											strInsert1 = $"{strInsert1}journ_status, ";
											strInsert1 = $"{strInsert1}journ_customer_note, ";
											strInsert1 = $"{strInsert1}journ_action_date ";

											strInsert1 = $"{strInsert1}) VALUES (";
											strInsert1 = $"{strInsert1}'{dtSystemDateTime.ToString("MM/dd/yyyy")}', ";
											strInsert1 = $"{strInsert1}'RN', ";
											strInsert1 = $"{strInsert1}'{($"{strJSubject} ").Trim()}', ";
											strInsert1 = $"{strInsert1}'{strNote.Substring(0, Math.Min(2000, strNote.Length))}', ";
											strInsert1 = $"{strInsert1}{lACId.ToString()}, ";
											strInsert1 = $"{strInsert1}{lCompId.ToString()}, ";
											strInsert1 = $"{strInsert1}{lContactId.ToString()}, ";
											strInsert1 = $"{strInsert1}'{modAdminCommon.gbl_User_ID}', ";
											strInsert1 = $"{strInsert1}'{dtSystemDateTime.ToString("MM/dd/yyyy")}', ";
											strInsert1 = $"{strInsert1}'{dtSystemDateTime.ToString("HH:mm:ss")}', ";
											strInsert1 = $"{strInsert1}'{modAdminCommon.gbl_Account_ID}', ";
											strInsert1 = $"{strInsert1}'', ";
											strInsert1 = $"{strInsert1}'A', ";
											strInsert1 = $"{strInsert1}'', ";
											strInsert1 = $"{strInsert1}'{dtSystemDateTime.ToString("MM/dd/yyyy HH:mm:ss")}'";
											strInsert1 = $"{strInsert1})";

											DbCommand TempCommand = null;
											TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
											UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
											TempCommand.CommandText = strInsert1;
											//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
											//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
											TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
											UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
											TempCommand.ExecuteNonQuery();

											strMsg = $"Customer Submitted Data EMail Response Has Been Sent To {Environment.NewLine}{Environment.NewLine}";
											strMsg = $"{strMsg}{strToName} at {strToEMail}{Environment.NewLine}{Environment.NewLine}";
											strMsg = $"{strMsg}For Aircraft {strMake} {strModel} {strSerNbr} {strRegNbr}";

											MessageBox.Show(strMsg, AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);

										}
										else
										{
											MessageBox.Show($"Customer Submitted Data Row Selected - Contact Does NOT Have An EMail Address{Environment.NewLine}{Environment.NewLine}EMail Cannot Be Sent", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
										} // If strToEMail <> "" Then

									}
									else
									{
										MessageBox.Show($"Customer Submitted Data Row Selected Does NOT Have An ACId or CompId2{Environment.NewLine}{Environment.NewLine}EMail Cannot Be Sent", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
									} // If lACId > 0 Or lCompId2 > 0 Then

								}
								else
								{
									MessageBox.Show($"Customer Submitted Data Row Selected Does NOT Have An ContactId{Environment.NewLine}{Environment.NewLine}EMail Cannot Be Sent", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
								} //If lContactId > 0 Then

							}
							else
							{
								MessageBox.Show($"Customer Submitted Data Row Selected Does NOT Have An CompId{Environment.NewLine}{Environment.NewLine}EMail Cannot Be Sent", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
							} // If lCompId > 0 Then

						}
						else
						{
							MessageBox.Show($"Customer Submitted Data Row Selected Does NOT Have An SubISId{Environment.NewLine}{Environment.NewLine}EMail Cannot Be Sent", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
						} // If lSubISId > 0 Then

					}
					else
					{
						MessageBox.Show($"Customer Submitted Data Grid Must Have A Row Selected{Environment.NewLine}{Environment.NewLine}EMail Cannot Be Sent", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
					} // If lRow1 >= 1 Then

					cmdSubDataEMail.Enabled = true;

				} // If cmdSubDataEMail.Enabled = True Then
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"cmdSubDataEMail_Click_Error ({Information.Err().Number.ToString()}) {excep.Message}", "frm_ActionList(EMAIL SUB DATA)");
			}

		} // cmdSubDataEMail_Click

		private void fgrdFindACNoBase_Click(Object eventSender, EventArgs eventArgs)
		{

			string strOrderBy = "";

			int lMouseRow = fgrdFindACNoBase.MouseRow;
			int lMouseCol = fgrdFindACNoBase.MouseCol;

			if (lMouseRow == 0)
			{ // Header Row

				switch(lMouseCol)
				{
					case 0 :  // ACId 
						strOrderBy = "ACId"; 
						break;
					case 1 :  // Make 
						strOrderBy = "Make, Model, SerNbr"; 
						break;
					case 2 :  // Model 
						strOrderBy = "Model, SerNbr "; 
						break;
					case 3 :  // SerNbr 
						strOrderBy = "SerNbr"; 
						break;
					case 4 :  // RegNbr 
						strOrderBy = "RegNbr"; 
						break;
					case 5 :  // CompId 
						strOrderBy = "CompId"; 
						break;
					case 6 :  // Company 
						strOrderBy = "Company, Make, Model, SerNbr"; 
						break;
				} // Case lMouseCol

				if (strOrderBy != Convert.ToString(fgrdFindACNoBase.Tag))
				{

					fgrdFindACNoBase.Tag = strOrderBy;
					fgrdFindACNoBase.CurrentColumnIndex = lMouseCol;

					switch(lMouseCol)
					{
						case 0 :  // ACId 
							//UPGRADE_WARNING: (2065) MSHierarchicalFlexGridLib.SortSettings property SortSettings.flexSortNumericAscending has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065 
							fgrdFindACNoBase.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortNumericAscending)); 
							break;
						case 5 :  // CompId 
							//UPGRADE_WARNING: (2065) MSHierarchicalFlexGridLib.SortSettings property SortSettings.flexSortNumericAscending has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065 
							fgrdFindACNoBase.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortNumericAscending)); 
							break;
						default:
							fgrdFindACNoBase.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortStringAscending)); 
							break;
					} // Case lMouseCol

				} // If strOrderBy <> fgrdFindACNoBase.Tag Then

			}
			else
			{
				modCommon.Highlight_Grid_Row(fgrdFindACNoBase);
			} // If lMouseRow = 0 Then ' Header Row

		} // fgrdFindACNoBase_Click

		private void fgrdFindACNoBase_DoubleClick(Object eventSender, EventArgs eventArgs)
		{

			string strOrderBy = "";
			frm_Company frmCompany = frm_Company.CreateInstance();

			int lMouseRow = fgrdFindACNoBase.MouseRow;
			int lMouseCol = fgrdFindACNoBase.MouseCol;

			if (lMouseRow > 0)
			{ // Header Row

				switch(lMouseCol)
				{
					case 0 : case 1 : case 2 : case 3 : case 4 :  // ACId, Make, Model, SerNbr, RegNbr 
						 
						modAdminCommon.gbl_Aircraft_ID = Convert.ToInt32(Double.Parse(Convert.ToString(fgrdFindACNoBase[lMouseRow, 0].Value)));  // Aircraft Id (ACId) 
						modAdminCommon.gbl_Aircraft_Journal_ID = 0; 
						 
						frm_aircraft.DefInstance.Form_Initialize(); 
						frm_aircraft.DefInstance.StartForm = modGlobalVars.tStart_Form; 
						frm_aircraft.DefInstance.Reference_Aircraft_ID = modAdminCommon.gbl_Aircraft_ID; 
						frm_aircraft.DefInstance.Reference_Journal_ID = modAdminCommon.gbl_Aircraft_Journal_ID; 
						frm_aircraft.DefInstance.Reference_Company_ID = 0; 
						frm_aircraft.DefInstance.Show(); 
						//UPGRADE_WARNING: (2065) Form method frm_aircraft.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065 
						frm_aircraft.DefInstance.BringToFront(); 
						//UPGRADE_WARNING: (2065) Form event Form.Activated has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065 
						frm_aircraft.DefInstance.Form_Activated(frm_aircraft.DefInstance, new EventArgs()); 
						 
						break;
					case 5 : case 6 :  // CompId, Company 
						 
						//--------------------------------------------------- 
						// Cleanup any Company Forms and Open A New One 
						 
						modCommon.Unload_Form("frm_Company"); 
						//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064 
						//VB.Global.Load(frmCompany); 
						frmCompany.Form_Initialize(); 
						frmCompany.StartForm = modGlobalVars.tStart_Form; 
						frmCompany.Reference_CompanyID = Convert.ToInt32(Double.Parse(Convert.ToString(fgrdFindACNoBase[lMouseRow, 5].Value)));  // Company Id (CompId) 
						frmCompany.Reference_CompanyJID = 0; 
						frmCompany.Show(); 
						//UPGRADE_WARNING: (2065) Form method frmCompany.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065 
						frmCompany.BringToFront(); 
						//UPGRADE_WARNING: (2065) Form event Form.Activated has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065 
						frmCompany.Form_Activated(null, new EventArgs()); 
						 
						break;
				} // Case lMouseCol

			} // If lMouseRow > 0 Then ' Header Row

		} // fgrdFindACNoBase_DblClick

		private void fgrdFindACNoCHP_Click(Object eventSender, EventArgs eventArgs)
		{

			string strOrderBy = "";

			int lMouseRow = fgrdFindACNoCHP.MouseRow;
			int lMouseCol = fgrdFindACNoCHP.MouseCol;

			if (lMouseRow == 0)
			{ // Header Row

				switch(lMouseCol)
				{
					case 0 :  // ACId 
						strOrderBy = "ACId"; 
						break;
					case 1 :  // Make 
						strOrderBy = "Make, Model, SerNbr"; 
						break;
					case 2 :  // Model 
						strOrderBy = "Model, SerNbr "; 
						break;
					case 3 :  // SerNbr 
						strOrderBy = "SerNbr "; 
						break;
					case 4 :  // RegNbr 
						strOrderBy = "RegNbr "; 
						break;
				} // Case lMouseCol

				if (strOrderBy != Convert.ToString(fgrdFindACNoCHP.Tag))
				{

					fgrdFindACNoCHP.Tag = strOrderBy;
					fgrdFindACNoCHP.CurrentColumnIndex = lMouseCol;

					switch(lMouseCol)
					{
						case 0 :  // ACId 
							//UPGRADE_WARNING: (2065) MSHierarchicalFlexGridLib.SortSettings property SortSettings.flexSortNumericAscending has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065 
							fgrdFindACNoCHP.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortNumericAscending)); 
							break;
						default:
							fgrdFindACNoCHP.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortStringAscending)); 
							break;
					} // Case lMouseCol

				} // If strOrderBy <> fgrdFindACNoBase.Tag Then

			}
			else
			{
				modCommon.Highlight_Grid_Row(fgrdFindACNoCHP);
			} // If lMouseRow = 0 Then ' Header Row

		} // fgrdFindACNoCHP_Click

		private void fgrdFindACNoCHP_DoubleClick(Object eventSender, EventArgs eventArgs)
		{

			string strOrderBy = "";

			frm_Company frmCompany = frm_Company.CreateInstance();

			int lMouseRow = fgrdFindACNoCHP.MouseRow;
			int lMouseCol = fgrdFindACNoCHP.MouseCol;

			if (lMouseRow > 0)
			{ // Header Row

				switch(lMouseCol)
				{
					case 0 : case 1 : case 2 : case 3 : case 4 :  // ACId, Make, Model, SerNbr, RegNbr 
						 
						modAdminCommon.gbl_Aircraft_ID = Convert.ToInt32(Double.Parse(Convert.ToString(fgrdFindACNoCHP[lMouseRow, 0].Value)));  // Aircraft Id (ACId) 
						modAdminCommon.gbl_Aircraft_Journal_ID = 0; 
						 
						frm_aircraft.DefInstance.Form_Initialize(); 
						frm_aircraft.DefInstance.StartForm = modGlobalVars.tStart_Form; 
						frm_aircraft.DefInstance.Reference_Aircraft_ID = modAdminCommon.gbl_Aircraft_ID; 
						frm_aircraft.DefInstance.Reference_Journal_ID = modAdminCommon.gbl_Aircraft_Journal_ID; 
						frm_aircraft.DefInstance.Reference_Company_ID = 0; 
						frm_aircraft.DefInstance.Show(); 
						//UPGRADE_WARNING: (2065) Form method frm_aircraft.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065 
						frm_aircraft.DefInstance.BringToFront(); 
						//UPGRADE_WARNING: (2065) Form event Form.Activated has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065 
						frm_aircraft.DefInstance.Form_Activated(frm_aircraft.DefInstance, new EventArgs()); 
						break;
					case 5 : case 6 :  // CompId, Company 
						 
						//--------------------------------------------------- 
						// Cleanup any Company Forms and Open A New One 
						 
						modCommon.Unload_Form("frm_Company"); 
						//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064 
						//VB.Global.Load(frmCompany); 
						frmCompany.Form_Initialize(); 
						frmCompany.StartForm = modGlobalVars.tStart_Form; 
						frmCompany.Reference_CompanyID = Convert.ToInt32(Double.Parse(Convert.ToString(fgrdFindACNoCHP[lMouseRow, 5].Value)));  // Company Id (CompId) 
						frmCompany.Reference_CompanyJID = 0; 
						frmCompany.Show(); 
						//UPGRADE_WARNING: (2065) Form method frmCompany.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065 
						frmCompany.BringToFront(); 
						//UPGRADE_WARNING: (2065) Form event Form.Activated has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065 
						frmCompany.Form_Activated(null, new EventArgs()); 
						break;
				} // Case lMouseCol

			} // If lMouseRow > 0 Then ' Header Row

		} // fgrdFindACNoCHP_DblClick

		private void fgrdFindResearchReports_Click(Object eventSender, EventArgs eventArgs)
		{

			string strOrderBy = "";
			string strColHeader = "";
			string strCompId = "";
			string strJournId = "";

			int lMouseRow = fgrdFindResearchReports.MouseRow;
			int lMouseCol = fgrdFindResearchReports.MouseCol;

			if (lMouseRow == 0)
			{ // Header Row

				strColHeader = Convert.ToString(fgrdFindResearchReports[0, lMouseCol].Value).ToUpper();
				fgrdFindResearchReports.CurrentColumnIndex = lMouseCol;


				switch(strColHeader)
				{
					case "COMPID" : 
						if (chkSortDesc.CheckState == CheckState.Unchecked)
						{
							strOrderBy = "CompId, JournId";
							//UPGRADE_WARNING: (2065) MSHierarchicalFlexGridLib.SortSettings property SortSettings.flexSortNumericAscending has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
							fgrdFindResearchReports.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortNumericAscending));
						}
						else
						{
							strOrderBy = "CompId DESC, JournId DESC";
							//UPGRADE_WARNING: (2065) MSHierarchicalFlexGridLib.SortSettings property SortSettings.flexSortNumericDescending has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
							fgrdFindResearchReports.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortNumericDescending));
						} 
						 
						break;
					case "JOURNID" : 
						if (chkSortDesc.CheckState == CheckState.Unchecked)
						{
							strOrderBy = "JournId";
							//UPGRADE_WARNING: (2065) MSHierarchicalFlexGridLib.SortSettings property SortSettings.flexSortNumericAscending has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
							fgrdFindResearchReports.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortNumericAscending));
						}
						else
						{
							strOrderBy = "JournId DESC";
							//UPGRADE_WARNING: (2065) MSHierarchicalFlexGridLib.SortSettings property SortSettings.flexSortNumericDescending has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
							fgrdFindResearchReports.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortNumericDescending));
						} 
						 
						break;
					case "CONTACTID" : 
						if (chkSortDesc.CheckState == CheckState.Unchecked)
						{
							strOrderBy = "ContactId, CompId, JournId";
							//UPGRADE_WARNING: (2065) MSHierarchicalFlexGridLib.SortSettings property SortSettings.flexSortNumericAscending has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
							fgrdFindResearchReports.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortNumericAscending));
						}
						else
						{
							strOrderBy = "ContactId DESC, CompId DESC, JournId DESC";
							//UPGRADE_WARNING: (2065) MSHierarchicalFlexGridLib.SortSettings property SortSettings.flexSortNumericDescending has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
							fgrdFindResearchReports.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortNumericDescending));
						} 
						 
						break;
					case "ACID" : 
						if (chkSortDesc.CheckState == CheckState.Unchecked)
						{
							strOrderBy = "ACId, JournId";
							//UPGRADE_WARNING: (2065) MSHierarchicalFlexGridLib.SortSettings property SortSettings.flexSortNumericAscending has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
							fgrdFindResearchReports.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortNumericAscending));
						}
						else
						{
							strOrderBy = "ACId DESC, JournId DESC";
							//UPGRADE_WARNING: (2065) MSHierarchicalFlexGridLib.SortSettings property SortSettings.flexSortNumericDescending has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
							fgrdFindResearchReports.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortNumericDescending));
						} 
						 
						break;
					case "ACCTREP" : 
						if (chkSortDesc.CheckState == CheckState.Unchecked)
						{
							strOrderBy = "AcctRep";
							fgrdFindResearchReports.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortStringAscending));
						}
						else
						{
							strOrderBy = "AcctRep DESC";
							fgrdFindResearchReports.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortStringDescending));
						} 
						 
						break;
					case "COMPANY" : case "OPERATOR" : 
						if (chkSortDesc.CheckState == CheckState.Unchecked)
						{
							strOrderBy = "Company, Country, StateAbbrev, City";
							fgrdFindResearchReports.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortStringAscending));
						}
						else
						{
							strOrderBy = "Company DESC, Country DESC, StateAbbrev DESC, City DESC";
							fgrdFindResearchReports.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortStringDescending));
						} 
						 
						break;
					case "CITY" : 
						if (chkSortDesc.CheckState == CheckState.Unchecked)
						{
							strOrderBy = "City, Country, StateAbbrev, Company";
							fgrdFindResearchReports.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortStringAscending));
						}
						else
						{
							strOrderBy = "City DESC, Country DESC, StateAbbrev DESC, Company DESC";
							fgrdFindResearchReports.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortStringDescending));
						} 
						 
						break;
					case "STATEABBREV" : 
						if (chkSortDesc.CheckState == CheckState.Unchecked)
						{
							strOrderBy = "StateAbbrev, Country, City, Company";
							fgrdFindResearchReports.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortStringAscending));
						}
						else
						{
							strOrderBy = "StateAbbrev DESC, Country DESC, City DESC, Company DESC";
							fgrdFindResearchReports.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortStringDescending));
						} 
						 
						break;
					case "STATE" : 
						if (chkSortDesc.CheckState == CheckState.Unchecked)
						{
							strOrderBy = "[State], Country, City, Company";
							fgrdFindResearchReports.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortStringAscending));
						}
						else
						{
							strOrderBy = "[State] DESC, Country DESC, City DESC, Company DESC";
							fgrdFindResearchReports.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortStringDescending));
						} 
						 
						break;
					case "COUNTRY" : 
						if (chkSortDesc.CheckState == CheckState.Unchecked)
						{
							strOrderBy = "Country, StateAbbrev, City, Company";
							fgrdFindResearchReports.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortStringAscending));
						}
						else
						{
							strOrderBy = "Country DESC, StateAbbrev DESC, City DESC, Company DESC";
							fgrdFindResearchReports.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortStringDescending));
						} 
						 
						break;
					case "TOTAC" : 
						if (chkSortDesc.CheckState == CheckState.Unchecked)
						{
							strOrderBy = "TotAC, Company, Country, StateAbbrev, City";
							//UPGRADE_WARNING: (2065) MSHierarchicalFlexGridLib.SortSettings property SortSettings.flexSortNumericAscending has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
							fgrdFindResearchReports.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortNumericAscending));
						}
						else
						{
							strOrderBy = "TotAC DESC, Company DESC, Country DESC, StateAbbrev DESC, City DESC";
							//UPGRADE_WARNING: (2065) MSHierarchicalFlexGridLib.SortSettings property SortSettings.flexSortNumericDescending has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
							fgrdFindResearchReports.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortNumericDescending));
						} 
						 
						break;
					case "AFTT" : case "SMOH1" : case "SMOH2" : case "SMOH3" : case "SMOH4" : case "ENGTT1" : case "ENGTT2" : case "ENGTT3" : case "ENGTT4" : case "ASKINGPRICE" : case "PRICE" : 
						if (chkSortDesc.CheckState == CheckState.Unchecked)
						{
							strOrderBy = $"{strColHeader}, Make, Model, SerNbr";
							//UPGRADE_WARNING: (2065) MSHierarchicalFlexGridLib.SortSettings property SortSettings.flexSortNumericAscending has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
							fgrdFindResearchReports.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortNumericAscending));
						}
						else
						{
							strOrderBy = $"{strColHeader} DESC, Make DESC, Model DESC, SerNbr DESC";
							//UPGRADE_WARNING: (2065) MSHierarchicalFlexGridLib.SortSettings property SortSettings.flexSortNumericDescending has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
							fgrdFindResearchReports.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortNumericDescending));
						} 
						 
						break;
					//UPGRADE_NOTE: (7001) The following case (switch) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
					//case "ASKINGPRICE" : 
						//break;
					//UPGRADE_NOTE: (7001) The following case (switch) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
					//case "PRICE" : 
						//if (chkSortDesc.CheckState == CheckState.Unchecked)
						//{
							//strOrderBy = $"{strColHeader}, Make, Model, SerNbr";
							//fgrdFindResearchReports.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortStringAscending));
						//}
						//else
						//{
							//strOrderBy = $"{strColHeader} DESC, Make DESC, Model DESC, SerNbr DESC";
							//fgrdFindResearchReports.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortStringDescending));
						//} 
						// 
						//break;
					case "MAKE" : 
						if (chkSortDesc.CheckState == CheckState.Unchecked)
						{
							strOrderBy = "Make, Model, SerNbr, RegNbr";
							fgrdFindResearchReports.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortStringAscending));
						}
						else
						{
							strOrderBy = "Make DESC, Model DESC, SerNbr DESC, RegNbr DESC";
							fgrdFindResearchReports.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortStringDescending));
						} 
						 
						break;
					case "MAKETYPE" : 
						if (chkSortDesc.CheckState == CheckState.Unchecked)
						{
							strOrderBy = "MakeType, Make, Model, SerNbr, RegNbr";
							fgrdFindResearchReports.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortStringAscending));
						}
						else
						{
							strOrderBy = "MakeType DESC, Make DESC, Model DESC, SerNbr DESC, RegNbr DESC";
							fgrdFindResearchReports.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortStringDescending));
						} 
						 
						break;
					case "MODEL" : 
						if (chkSortDesc.CheckState == CheckState.Unchecked)
						{
							strOrderBy = "Model, Make, SerNbr, RegNbr";
							fgrdFindResearchReports.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortStringAscending));
						}
						else
						{
							strOrderBy = "Model DESC, Make DESC, SerNbr DESC, RegNbr DESC";
							fgrdFindResearchReports.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortStringDescending));
						} 
						 
						break;
					case "SERNBR" : 
						if (chkSortDesc.CheckState == CheckState.Unchecked)
						{
							strOrderBy = "SerNbr, Make, Model, RegNbr";
							fgrdFindResearchReports.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortStringAscending));
						}
						else
						{
							strOrderBy = "SerNbr DESC, Make DESC, Model DESC, RegNbr DESC";
							fgrdFindResearchReports.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortStringDescending));
						} 
						 
						break;
					case "REGNBR" : 
						if (chkSortDesc.CheckState == CheckState.Unchecked)
						{
							strOrderBy = "RegNbr, Make, Model, SerNbr";
							fgrdFindResearchReports.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortStringAscending));
						}
						else
						{
							strOrderBy = "RegNbr DESC, Make DESC, Model DESC, SerNbr DESC";
							fgrdFindResearchReports.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortStringDescending));
						} 
						 
						break;
					case "ENGINE" : 
						if (chkSortDesc.CheckState == CheckState.Unchecked)
						{
							strOrderBy = $"{strColHeader}, Make, Model, SerNbr";
							fgrdFindResearchReports.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortStringAscending));
						}
						else
						{
							strOrderBy = $"{strColHeader} DESC, Make DESC, Model DESC, SerNbr DESC";
							fgrdFindResearchReports.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortStringDescending));
						} 
						 
						break;
					default:
						if (chkSortDesc.CheckState == CheckState.Unchecked)
						{
							strOrderBy = strColHeader;
							fgrdFindResearchReports.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortStringAscending));
						}
						else
						{
							strOrderBy = $"{strColHeader} DESC";
							fgrdFindResearchReports.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortStringDescending));
						} 
						 
						break;
				} // Case strColHeader

				if (strOrderBy != Convert.ToString(fgrdFindResearchReports.Tag))
				{
					fgrdFindResearchReports.Tag = strOrderBy;
				}

			}
			else
			{

				// ADDED MSW - 7/27/18 - to make the company name show up in the upper right box

				// 11/26/2019 - BY David D. Cruger
				// Can't use col=0 as it may change due to which report is being view.
				// Use the global variables that point to what cell the ID's are in
				// gACIdCol, gCompIdCol, gJournIdCol

				pnl_lstcompany.Visible = false;
				cmd_contacts_phone.Visible = false;

				if (gCompIdCol >= 0)
				{

					strCompId = Convert.ToString(fgrdFindResearchReports[lMouseRow, gCompIdCol].Value);
					strJournId = Convert.ToString(fgrdFindResearchReports[lMouseRow, gJournIdCol].Value);

					modCommon.Build_Company_NameAddress(lstCompany, Convert.ToInt32(Double.Parse(strCompId)), Convert.ToInt32(Double.Parse(strJournId)));
					pnl_lstcompany.Visible = true;

				} // If gCompIdCol Then

				modCommon.Highlight_Grid_Row(fgrdFindResearchReports);

			} // If lMouseRow = 0 Then ' Header Row

		} // fgrdFindResearchReports_Click

		private void fgrdFindResearchReports_DoubleClick(Object eventSender, EventArgs eventArgs)
		{

			string strOrderBy = "";
			string strColHeader = "";
			frm_Company frmCompany = frm_Company.CreateInstance();
			string strText = "";

			int lMouseRow = fgrdFindResearchReports.MouseRow;
			int lMouseCol = fgrdFindResearchReports.MouseCol;

			if (lMouseRow > 0)
			{ // Data Row

				strColHeader = Convert.ToString(fgrdFindResearchReports[0, lMouseCol].Value).ToUpper();

				modCommon.Highlight_Grid_Row(fgrdFindResearchReports);


				switch(strColHeader)
				{
					case "COMPID" : case "CONTACTID" : case "COMPANY" : case "OPERATOR" : case "OWNER" : case "CITY" : case "STATE" : case "STATEABBREV" : case "COUNTRY" : case "TOTAC" : 
						 
						if (gCompIdCol >= 0)
						{

							modCommon.Unload_Form("frm_Company");
							//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//VB.Global.Load(frmCompany);
							frmCompany.Form_Initialize();
							frmCompany.StartForm = modGlobalVars.tStart_Form;
							frmCompany.Reference_CompanyID = Convert.ToInt32(Double.Parse(Convert.ToString(fgrdFindResearchReports[lMouseRow, gCompIdCol].Value))); // (Comp Id)
							frmCompany.Reference_CompanyJID = Convert.ToInt32(Double.Parse(Convert.ToString(fgrdFindResearchReports[lMouseRow, gJournIdCol].Value))); // (Journal Id)
							frmCompany.Show();
							//UPGRADE_WARNING: (2065) Form method frmCompany.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
							frmCompany.BringToFront();
							//UPGRADE_WARNING: (2065) Form event Form.Activated has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
							frmCompany.Form_Activated(null, new EventArgs());

						}
						else
						{
							MessageBox.Show("No Company Id To Link To", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						}  // If gCompIdCol >= 0 Then 
						 
						break;
					case "MAKETYPE" : case "MAKE" : case "MODEL" : case "SERNBR" : case "REGNBR" : case "ENGINE" : case "ASKINGPRICE" : case "PRICE" : case "AFTT" : case "ENGTT1" : case "ENGTT2" : case "ENGTT3" : case "ENGTT4" : case "SMOH1" : case "SMOH2" : case "SMOH3" : case "SMOH4" : case "YEARDLV" : case "YEARMFR" : case "FEATURE1" : case "FEATURE2" : case "FEATURE3" : case "FEATURE4" : case "FEATURE5" : case "FEATURE6" : case "BASECOUNTRY" : case "LIFECYCLE" : 
						 
						if (gACIdCol >= 0)
						{

							modAdminCommon.gbl_Aircraft_ID = Convert.ToInt32(Double.Parse(Convert.ToString(fgrdFindResearchReports[lMouseRow, gACIdCol].Value))); // (Aircraft Id)
							if (gJournIdCol > 0)
							{
								modAdminCommon.gbl_Aircraft_Journal_ID = Convert.ToInt32(Double.Parse(Convert.ToString(fgrdFindResearchReports[lMouseRow, gJournIdCol].Value))); // (Journal Id)
							}
							else
							{
								modAdminCommon.gbl_Aircraft_Journal_ID = 0; // (Journal Id)
							}



							frm_aircraft.DefInstance.Form_Initialize();
							frm_aircraft.DefInstance.StartForm = modGlobalVars.tStart_Form;
							frm_aircraft.DefInstance.Reference_Aircraft_ID = modAdminCommon.gbl_Aircraft_ID;
							frm_aircraft.DefInstance.Reference_Journal_ID = modAdminCommon.gbl_Aircraft_Journal_ID;
							frm_aircraft.DefInstance.Reference_Company_ID = 0;
							frm_aircraft.DefInstance.Show();
							//UPGRADE_WARNING: (2065) Form method frm_aircraft.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
							frm_aircraft.DefInstance.BringToFront();
							//UPGRADE_WARNING: (2065) Form event Form.Activated has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
							frm_aircraft.DefInstance.Form_Activated(frm_aircraft.DefInstance, new EventArgs());

						}
						else
						{
							MessageBox.Show("No Aircraft Id To Link To", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						}  // If gACIdCol >= 0 Then 
						 
						break;
					case "SUBJECT" : case "DESCRIPTION" : case "INTERNALNOTE" : case "NOTE" : case "DESC" : case "JOURNALNOTE" : case "JOURNALDESC" : case "JOURNALSUBJECT" : 
						 
						strText = $"{new string('-', 75)}{Environment.NewLine}"; 
						strText = $"{strText}Note: {Convert.ToString(fgrdFindResearchReports[lMouseRow, lMouseCol].Value)}";  // Note 
						 
						if (strText != "")
						{

							if (frm_info2.DefInstance == null)
							{
								//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
								//VB.Global.Load(frm_info2.DefInstance);
							}

							frm_info2.DefInstance.SetFormCaption(strColHeader);
							frm_info2.DefInstance.SetText(strText);
							frm_info2.DefInstance.SetTextEnabled(true);
							frm_info2.DefInstance.Show();

						}  // If strText <> "" Then 
						 
						break;
				} // Case strColHeader

			} // If lMouseRow > 0 Then ' Data Row

		} // fgrdFindResearchReports_DblClick

		private void fgrdOwrOpr_Click(Object eventSender, EventArgs eventArgs)
		{

			string strOrderBy = "";

			int lMouseRow = fgrdOwrOpr.MouseRow;
			int lMouseCol = fgrdOwrOpr.MouseCol;

			if (lMouseRow == 0)
			{ // Header Row

				switch(lMouseCol)
				{
					case 0 :  // ACId 
						strOrderBy = "ACId "; 
						break;
					case 1 :  // Make 
						strOrderBy = "Make, Model, SerNbr "; 
						break;
					case 2 :  // Model 
						strOrderBy = "Model, SerNbr "; 
						break;
					case 3 :  // SerNbr 
						strOrderBy = "RegNbr, SerNbr, Make, Model  "; 
						break;
					case 4 :  // RegNbr 
						strOrderBy = "RegNbr, Make, Model, SerNbr "; 
						break;
					case 5 :  // CompId 
						strOrderBy = "CompId, Make, Model, SerNbr "; 
						break;
					case 6 :  // Company 
						strOrderBy = "Company, Country, [State], City"; 
						break;
					case 7 :  // City 
						strOrderBy = "City, [State], Country "; 
						break;
					case 8 :  // State 
						strOrderBy = "[State], Country, City "; 
						break;
					case 9 :  // Country 
						strOrderBy = "Country, [State], City "; 
						break;
					case 10 :  // Country 
						strOrderBy = " last_attempted "; 
						break;
					case 11 :  // Country 
						strOrderBy = " dtJNiQLastAttemptedDate "; 
						 
						break;
				} // Case lMouseCol

				if (strOrderBy != Convert.ToString(fgrdOwrOpr.Tag))
				{
					fgrdOwrOpr.Tag = strOrderBy;
					Fill_Owner_Operator_Callback_Grid();
				}

			} // If lMouseRow = 0 Then ' Header Row

		} // fgrdOwrOpr_Click

		private void fgrdOwrOpr_DoubleClick(Object eventSender, EventArgs eventArgs)
		{

			string strOrderBy = "";

			frm_Company frmCompany = frm_Company.CreateInstance();

			int lMouseRow = fgrdOwrOpr.MouseRow;
			int lMouseCol = fgrdOwrOpr.MouseCol;

			if (lMouseRow > 0)
			{ // Header Row

				switch(lMouseCol)
				{
					case 0 : case 1 : case 2 : case 3 : case 4 :  // ACId, Make, Model, SerNbr, RegNbr 
						 
						modAdminCommon.gbl_Aircraft_ID = Convert.ToInt32(Double.Parse(Convert.ToString(fgrdOwrOpr[lMouseRow, 0].Value)));  // Aircraft Id (ACId) 
						modAdminCommon.gbl_Aircraft_Journal_ID = 0; 
						 
						frm_aircraft.DefInstance.Form_Initialize(); 
						frm_aircraft.DefInstance.StartForm = modGlobalVars.tStart_Form; 
						frm_aircraft.DefInstance.Reference_Aircraft_ID = modAdminCommon.gbl_Aircraft_ID; 
						frm_aircraft.DefInstance.Reference_Journal_ID = modAdminCommon.gbl_Aircraft_Journal_ID; 
						frm_aircraft.DefInstance.Reference_Company_ID = 0; 
						frm_aircraft.DefInstance.Show(); 
						//UPGRADE_WARNING: (2065) Form method frm_aircraft.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065 
						frm_aircraft.DefInstance.BringToFront(); 
						//UPGRADE_WARNING: (2065) Form event Form.Activated has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065 
						frm_aircraft.DefInstance.Form_Activated(frm_aircraft.DefInstance, new EventArgs()); 
						 
						break;
					case 5 : case 6 : case 7 : case 8 : case 9 :  // CompId, Company, City, State, Country 
						 
						//--------------------------------------------------- 
						// Cleanup any Company Forms and Open A New One 
						 
						modCommon.Unload_Form("frm_Company"); 
						//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064 
						//VB.Global.Load(frmCompany); 
						frmCompany.Form_Initialize(); 
						frmCompany.StartForm = modGlobalVars.tStart_Form; 
						frmCompany.Reference_CompanyID = Convert.ToInt32(Double.Parse(Convert.ToString(fgrdOwrOpr[lMouseRow, 5].Value)));  // Company Id (CompId) 
						frmCompany.Reference_CompanyJID = 0; 
						frmCompany.Show(); 
						//UPGRADE_WARNING: (2065) Form method frmCompany.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065 
						frmCompany.BringToFront(); 
						//UPGRADE_WARNING: (2065) Form event Form.Activated has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065 
						frmCompany.Form_Activated(null, new EventArgs()); 
						 
						break;
				} // Case lMouseCol

			} // If lMouseRow > 0 Then ' Header Row

		} // fgrdOwrOpr_DblClick

		private void Fill_Owner_Operator_Callback_Grid()
		{



			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strSelect = "";
			string strAcctRep = "";
			string strAcctRepId = "";

			int lCol1 = 0;
			int lRow1 = 0;

			int lTot1 = 0;
			int lCnt1 = 0;

			string strMsg = "";
			System.DateTime dtStartDate = DateTime.FromOADate(0);
			System.DateTime dtEndDate = DateTime.FromOADate(0);

			try
			{

				modCommon.Start_Activity_Monitor_Message("Callback Owner=Operator", ref strMsg, ref dtStartDate, ref dtEndDate);

				Fill_Owner_Operator_Callback_Grid_Headers();

				lRow1 = 0;
				lCol1 = 0;
				fgrdOwrOpr.Enabled = false;
				cmdOwrOprRefresh.Enabled = false;

				strAcctRep = cbo_account_id.Text.Substring(0, Math.Min(2, cbo_account_id.Text.Length)).ToUpper();
				strAcctRepId = cbo_account_id.Text.ToUpper();
				strSelect = cmbProductType.Text.Substring(0, Math.Min(1, cmbProductType.Text.Length));

				if (strAcctRep != "ID")
				{

					lblOwrOprStop.Enabled = true;
					lblOwrOprStop.Visible = true;

					strQuery1 = "SELECT ";
					strQuery1 = $"{strQuery1}C1.comp_account_id As AcctRep, ";
					strQuery1 = $"{strQuery1}A1.ac_id As ACId, ";
					strQuery1 = $"{strQuery1}AM1.amod_make_name As Make, ";
					strQuery1 = $"{strQuery1}AM1.amod_model_name As Model, ";
					strQuery1 = $"{strQuery1}A1.ac_ser_no_full As SerNbr, ";
					strQuery1 = $"{strQuery1}A1.ac_reg_no As RegNbr, ";
					strQuery1 = $"{strQuery1}C1.comp_id As CompId, ";
					strQuery1 = $"{strQuery1}C1.comp_name As Company, ";
					strQuery1 = $"{strQuery1}C1.comp_city As City, ";
					strQuery1 = $"{strQuery1}C1.comp_state As [State], ";
					strQuery1 = $"{strQuery1}C1.comp_country As Country ";

					// added MSW - 4/8/24 - MSW - per JETDEV-865
					strQuery1 = $"{strQuery1}, (";
					strQuery1 = $"{strQuery1} SELECT TOP 1 journ_date FROM Journal AS J1 WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1} WHERE (J1.journ_ac_id = A1.ac_id) ";
					strQuery1 = $"{strQuery1} AND (J1.journ_subject LIKE 'Doc Resp:%') ";
					strQuery1 = $"{strQuery1} and J1.journ_date >= (getdate() - 540) ";
					strQuery1 = $"{strQuery1} ORDER BY J1.journ_date DESC";
					strQuery1 = $"{strQuery1} ) AS last_attempted ";

					strQuery1 = $"{strQuery1}, (SELECT TOP 1 journ_date FROM Journal WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1} WHERE (journ_comp_id = C1.comp_id) ";
					strQuery1 = $"{strQuery1} AND ( ";
					strQuery1 = $"{strQuery1}       (journ_subcategory_code = 'IQ') ";
					strQuery1 = $"{strQuery1}    OR (journ_subcategory_code = 'RN' AND journ_subject LIKE '%JNiQ%') ";
					strQuery1 = $"{strQuery1}     ) ";
					strQuery1 = $"{strQuery1} ORDER BY journ_date DESC ";
					strQuery1 = $"{strQuery1}) As dtJNiQLastAttemptedDate ";


					strQuery1 = $"{strQuery1}FROM Aircraft_Model AS AM1 WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1}INNER JOIN Aircraft AS A1 WITH (NOLOCK) ON A1.ac_amod_id = AM1.amod_id ";
					strQuery1 = $"{strQuery1}INNER JOIN Aircraft_Reference AS AR1 WITH (NOLOCK) ON AR1.cref_ac_id = A1.ac_id AND AR1.cref_journ_id = A1.ac_journ_id ";
					strQuery1 = $"{strQuery1}INNER JOIN Company AS C1 WITH (NOLOCK) ON C1.comp_id = AR1.cref_comp_id AND C1.comp_journ_id = AR1.cref_journ_id ";

					strQuery1 = $"{strQuery1}WHERE (AM1.amod_customer_flag = 'Y') ";
					strQuery1 = $"{strQuery1}AND (A1.ac_journ_id = 0) ";
					strQuery1 = $"{strQuery1}AND (A1.ac_lifecycle_stage = 3) ";
					strQuery1 = $"{strQuery1}AND (AR1.cref_transmit_seq_no = 1) ";
					strQuery1 = $"{strQuery1}AND (AR1.cref_operator_flag IN ('Y','O')) ";
					strQuery1 = $"{strQuery1}AND (C1.comp_active_flag = 'Y') ";
					strQuery1 = $"{strQuery1}AND (C1.comp_name <> 'Awaiting Documentation') ";
					strQuery1 = $"{strQuery1}AND (LEFT(C1.comp_account_id,2) <> 'ID') "; // Unidentified
					strQuery1 = $"{strQuery1}AND (C1.comp_account_id <> 'IDGM') "; // Governemnt Do Not Call
					strQuery1 = $"{strQuery1}AND (C1.comp_account_id <> 'AC19') "; // Not Sure But Jackie Says This Is Also Unidentified

					//---------------------------------------
					// Select Account Rep Type

					if (strAcctRepId != "" && strAcctRepId != "NO REP SELECTED")
					{
						strQuery1 = $"{strQuery1}AND C1.comp_account_id  {make_account_rep_answer_string()}";
					}

					//-------------------------------------
					// Select Aircraft Type


					switch(strSelect)
					{
						case "A" :  // - Helicopters and Business Aircraft 
							strQuery1 = $"{strQuery1}AND ( "; 
							strQuery1 = $"{strQuery1}        (AM1.amod_airframe_type_code = 'F' "; 
							strQuery1 = $"{strQuery1}         AND AM1.amod_product_business_flag = 'Y' "; 
							strQuery1 = $"{strQuery1}         AND A1.ac_product_business_flag = 'Y' "; 
							strQuery1 = $"{strQuery1}        ) "; 
							strQuery1 = $"{strQuery1}     OR (AM1.amod_airframe_type_code = 'R' "; 
							strQuery1 = $"{strQuery1}         AND AM1.amod_product_helicopter_flag = 'Y' "; 
							strQuery1 = $"{strQuery1}         AND A1.ac_product_helicopter_flag = 'Y' "; 
							strQuery1 = $"{strQuery1}        ) "; 
							strQuery1 = $"{strQuery1}    ) "; 
							 
							break;
						case "B" :  // - Business Aircraft 
							strQuery1 = $"{strQuery1}AND (AM1.amod_airframe_type_code = 'F') "; 
							strQuery1 = $"{strQuery1}AND (AM1.amod_product_business_flag = 'Y') "; 
							strQuery1 = $"{strQuery1}AND (A1.ac_product_business_flag = 'Y') "; 
							 
							break;
						case "C" :  // - Commercial 
							strQuery1 = $"{strQuery1}AND (AM1.amod_airframe_type_code = 'F') "; 
							strQuery1 = $"{strQuery1}AND (AM1.amod_product_commercial_flag = 'Y') "; 
							strQuery1 = $"{strQuery1}AND (A1.ac_product_commercial_flag = 'Y') "; 
							 
							break;
						case "H" :  // - Helicopters 
							strQuery1 = $"{strQuery1}AND (AM1.amod_airframe_type_code = 'R') "; 
							strQuery1 = $"{strQuery1}AND (AM1.amod_product_helicopter_flag = 'Y') "; 
							strQuery1 = $"{strQuery1}AND (A1.ac_product_helicopter_flag = 'Y') "; 
							 
							break;
						case "L" :  // - All 
							 
							break;
						case "Q" :  // JNiQ Eligible 
							 
							strQuery1 = $"{strQuery1}{modCommon.Return_JNiQ_Eligible_Query(strAcctRepId, strQuery1)}"; 
							 
							break;
						case "N" :  // Non-JNiQ Eligible 
							 
							strQuery1 = $"{strQuery1}{modCommon.Return_Non_JNiQ_Eligible_Query()}"; 
							 
							break;
						case "P" :  // - AirBP 
							 
							strQuery1 = $"{strQuery1}AND (A1.ac_product_airbp_flag = 'Y') "; 
							 
							break;
					} // strSelect

					// added MSW - 9/9/20
					if (cbo_Timezones.Text != "All")
					{
						if (cbo_Timezones.Text == "International")
						{
							strQuery1 = $"{strQuery1}AND ((C1.comp_timezone is NULL) or (comp_timezone=''))";
						}
						else
						{
							strQuery1 = $"{strQuery1}AND (C1.comp_timezone='{cbo_Timezones.Text}') ";
						}
					}





					//-------------------------------------------
					//-- No SeqNbr = 2 Company

					strQuery1 = $"{strQuery1}AND (NOT EXISTS (SELECT NULL FROM Aircraft_Reference AS AR2 WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1}                 WHERE (AR2.cref_ac_id = A1.AC_ID) ";
					strQuery1 = $"{strQuery1}                 AND (AR2.cref_journ_id = A1.ac_journ_id) ";
					strQuery1 = $"{strQuery1}                 AND (AR2.cref_transmit_seq_no = 2) ";
					strQuery1 = $"{strQuery1}                ) ";
					strQuery1 = $"{strQuery1}    ) ";

					if (Convert.ToString(fgrdOwrOpr.Tag) != "")
					{
						strQuery1 = $"{strQuery1}ORDER BY {Convert.ToString(fgrdOwrOpr.Tag)}";
					}

					modAdminCommon.Record_Event("Monitor Activity", $"Owner=Operatore - Selected AcctRep: {strAcctRepId}");
					//Record_Event "HB Usage", "Owner=Operatore - Selected AcctRep: " & strAcctRepId

					lblOwrOprRecords.Text = "Searching Records";

					rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						lTot1 = rstRec1.RecordCount;
						lCnt1 = 0;

						fgrdOwrOpr.Redraw = false;

						do 
						{ // Loop Until rstRec1.EOF = True Or lblOwrOprStop.Enabled = False

							lCnt1++;
							lblOwrOprRecords.Text = $"Total Records Found: {StringsHelper.Format(lTot1, "00000#")}  Loading: {StringsHelper.Format(lCnt1, "00000#")}";

							lRow1++;
							fgrdOwrOpr.RowsCount = lRow1 + 1;
							fgrdOwrOpr.CurrentRowIndex = lRow1;

							lCol1 = -1;

							lCol1++;
							fgrdOwrOpr.CurrentColumnIndex = lCol1;
							fgrdOwrOpr[fgrdOwrOpr.CurrentRowIndex, fgrdOwrOpr.CurrentColumnIndex].Value = Convert.ToString(rstRec1["ACID"]);
							fgrdOwrOpr.CellAlignment = DataGridViewContentAlignment.MiddleRight;

							lCol1++;
							fgrdOwrOpr.CurrentColumnIndex = lCol1;
							fgrdOwrOpr[fgrdOwrOpr.CurrentRowIndex, fgrdOwrOpr.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["make"])} ").Trim();
							fgrdOwrOpr.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

							lCol1++;
							fgrdOwrOpr.CurrentColumnIndex = lCol1;
							fgrdOwrOpr[fgrdOwrOpr.CurrentRowIndex, fgrdOwrOpr.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["model"])} ").Trim();
							fgrdOwrOpr.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

							lCol1++;
							fgrdOwrOpr.CurrentColumnIndex = lCol1;
							fgrdOwrOpr[fgrdOwrOpr.CurrentRowIndex, fgrdOwrOpr.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["SerNbr"])} ").Trim();
							fgrdOwrOpr.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

							lCol1++;
							fgrdOwrOpr.CurrentColumnIndex = lCol1;
							fgrdOwrOpr[fgrdOwrOpr.CurrentRowIndex, fgrdOwrOpr.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["RegNbr"])} ").Trim();
							fgrdOwrOpr.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

							lCol1++;
							fgrdOwrOpr.CurrentColumnIndex = lCol1;
							fgrdOwrOpr[fgrdOwrOpr.CurrentRowIndex, fgrdOwrOpr.CurrentColumnIndex].Value = Convert.ToString(rstRec1["CompID"]);
							fgrdOwrOpr.CellAlignment = DataGridViewContentAlignment.MiddleRight;

							lCol1++;
							fgrdOwrOpr.CurrentColumnIndex = lCol1;
							fgrdOwrOpr[fgrdOwrOpr.CurrentRowIndex, fgrdOwrOpr.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["Company"])} ").Trim();
							fgrdOwrOpr.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

							lCol1++;
							fgrdOwrOpr.CurrentColumnIndex = lCol1;
							fgrdOwrOpr[fgrdOwrOpr.CurrentRowIndex, fgrdOwrOpr.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["city"])} ").Trim();
							fgrdOwrOpr.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

							lCol1++;
							fgrdOwrOpr.CurrentColumnIndex = lCol1;
							fgrdOwrOpr[fgrdOwrOpr.CurrentRowIndex, fgrdOwrOpr.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["state"])} ").Trim();
							fgrdOwrOpr.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

							lCol1++;
							fgrdOwrOpr.CurrentColumnIndex = lCol1;
							fgrdOwrOpr[fgrdOwrOpr.CurrentRowIndex, fgrdOwrOpr.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["country"])} ").Trim();
							fgrdOwrOpr.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

							lCol1++;
							fgrdOwrOpr.CurrentColumnIndex = lCol1;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(rstRec1["last_attempted"]))
							{
								fgrdOwrOpr[fgrdOwrOpr.CurrentRowIndex, fgrdOwrOpr.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["last_attempted"])} ").Trim();
							}
							else
							{
								fgrdOwrOpr[fgrdOwrOpr.CurrentRowIndex, fgrdOwrOpr.CurrentColumnIndex].Value = "";
							}
							fgrdOwrOpr.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

							lCol1++;
							fgrdOwrOpr.CurrentColumnIndex = lCol1;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(rstRec1["dtJNiQLastAttemptedDate"]))
							{
								fgrdOwrOpr[fgrdOwrOpr.CurrentRowIndex, fgrdOwrOpr.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["dtJNiQLastAttemptedDate"])} ").Trim();
							}
							else
							{
								fgrdOwrOpr[fgrdOwrOpr.CurrentRowIndex, fgrdOwrOpr.CurrentColumnIndex].Value = "";
							}

							fgrdOwrOpr.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

							if (lRow1 == 25)
							{
								fgrdOwrOpr.Redraw = true;
								fgrdOwrOpr.Refresh();
								fgrdOwrOpr.Redraw = false;
							}

							rstRec1.MoveNext();
							Application.DoEvents();

						}
						while(!(rstRec1.EOF || !lblOwrOprStop.Enabled));

						if (lblOwrOprStop.Enabled)
						{
							lblOwrOprRecords.Text = $"Total Records Found: {StringsHelper.Format(lTot1, "00000#")}";
						}

						fgrdOwrOpr.Redraw = true;
						fgrdOwrOpr.Refresh();
						fgrdOwrOpr.Enabled = true;

					}
					else
					{
						fgrdOwrOpr.CurrentRowIndex = 1;
						fgrdOwrOpr.CurrentColumnIndex = 1;
						fgrdOwrOpr[fgrdOwrOpr.CurrentRowIndex, fgrdOwrOpr.CurrentColumnIndex].Value = "No Records Found";
						lblOwrOprRecords.Text = "No Records Found";
					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

					lblOwrOprStop.Enabled = false;
					lblOwrOprStop.Visible = false;

					strMsg = $"AcctRep: {strAcctRepId}";
					strMsg = $"{strMsg} Product: {cmbProductType.Text}";

					if (bLog)
					{

						modCommon.End_Activity_Monitor_Message("Callback Owner=Operator", ref strMsg, dtStartDate, ref dtEndDate, 0, 0, 0, 0, 0);

						frm_UserHistory.DefInstance.Refresh_User_History_Grids("Callback");

					}

				}
				else
				{
					MessageBox.Show("Can NOT Search for ID Rep Companies", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Information);
				} // If left(strAcctRep, 2) <> "ID" Then

				rstRec1 = null;
				cmdOwrOprRefresh.Enabled = true;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Record_Error("Callbacks (Owr=Opr)", $"Fill_Owner_Operator_Callback_Grid_Error: {Information.Err().Number.ToString()} - {excep.Message}");
			}




		} // Fill_Owner_Operator_Callback_Grid

		private void fgrdFindDups_Click(Object eventSender, EventArgs eventArgs)
		{

			string strOrderBy = "";

			int lMouseRow = fgrdFindDups.MouseRow;
			int lMouseCol = fgrdFindDups.MouseCol;

			if (lMouseRow == 0)
			{ // Header Row

				switch(lMouseCol)
				{
					case 0 :  // CompId 
						strOrderBy = "CompId "; 
						break;
					case 1 :  // Company 
						strOrderBy = "Company, Address1Search "; 
						break;
					case 2 :  // Address1 
						strOrderBy = "Address1Search, Company "; 
						break;
					case 3 :  // CompIdString 
						strOrderBy = "CompIdString, CompId "; 
						break;
					case 4 :  // ContactId 
						strOrderBy = "ContactId, CompId "; 
						break;
					case 5 :  // Contact 
						strOrderBy = "ContactSearch, Company "; 
						break;
					case 6 :  // EMail Address 
						strOrderBy = "EMailAddressSearch "; 
						break;
					case 7 :  // Phone Type 
						strOrderBy = "PhoneType, PhoneSearch "; 
						break;
					case 8 :  // Phone Nbr 
						strOrderBy = "PhoneSearch, Company "; 
						break;
					case 9 :  // Contact Id String 
						strOrderBy = "ContactIdString"; 
						break;
				} // Case lMouseCol

				if (strOrderBy != Convert.ToString(fgrdFindDups.Tag))
				{

					fgrdFindDups.Tag = strOrderBy;
					fgrdFindDups.CurrentColumnIndex = lMouseCol;

					switch(lMouseCol)
					{
						case 0 : case 4 :  // CompId, ContactI 
							//UPGRADE_WARNING: (2065) MSHierarchicalFlexGridLib.SortSettings property SortSettings.flexSortNumericAscending has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065 
							fgrdFindDups.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortNumericAscending)); 
							break;
						default:
							fgrdFindDups.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortStringAscending)); 
							break;
					} // Case lMouseCol

				} // If strOrderBy <> fgrdFindDups.Tag Then

			}
			else
			{
				modCommon.Highlight_Grid_Row(fgrdFindDups);
			} // If lMouseRow = 0 Then ' Header Row

		} // fgrdFindDups_Click

		private void fgrdFindDups_DoubleClick(Object eventSender, EventArgs eventArgs)
		{

			string strOrderBy = "";

			frm_Company frmCompany = frm_Company.CreateInstance();

			int lMouseRow = fgrdFindDups.MouseRow;
			int lMouseCol = fgrdFindDups.MouseCol;

			if (lMouseRow > 0)
			{ // Header Row

				//---------------------------------------------------
				// Cleanup any Company Forms and Open A New One

				modCommon.Unload_Form("frm_Company");
				//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//VB.Global.Load(frmCompany);
				frmCompany.Form_Initialize();
				frmCompany.StartForm = modGlobalVars.tStart_Form;
				frmCompany.Reference_CompanyID = Convert.ToInt32(Double.Parse(Convert.ToString(fgrdFindDups[lMouseRow, 0].Value))); // Company Id (CompId)
				frmCompany.Reference_CompanyJID = 0;
				frmCompany.Show();
				//UPGRADE_WARNING: (2065) Form method frmCompany.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
				frmCompany.BringToFront();
				//UPGRADE_WARNING: (2065) Form event Form.Activated has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
				frmCompany.Form_Activated(null, new EventArgs());

			} // If lMouseRow > 0 Then ' Header Row

		} // fgrdFindDups_DblClick

		private void fgrdFindDups_MouseDown(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;


			int lRow = fgrdFindDups.MouseRow;
			int lCol = fgrdFindDups.MouseCol;

			if (lRow > 0)
			{

				if (Button == UpgradeHelpers.Utils.WinForms.MouseButtonsHelper.GetVB6ShortValue(MouseButtons.Right))
				{

					fgrdFindDups.CurrentRowIndex = lRow;
					fgrdFindDups.CurrentColumnIndex = lCol;
					fgrdFindDups.ColSel = lCol;

					mnuEdit.Enabled = true;

					mnuCopyFindDupsGrid.Enabled = true;
					mnuCopyFindDupsGrid.Available = true;
					mnuCopyFindDupsGrid.Tag = $"{lRow.ToString()}:{lCol.ToString()}";

					mnuEditCompletedCustSubData.Available = false;

					modCommon.Highlight_Grid_Row(fgrdFindDups);

					//UPGRADE_WARNING: (6024) Default menues are not supported for Context Menues (Popup) More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6024
					Ctx_mnuEdit.Show(this, PointToClient(Cursor.Position).X, PointToClient(Cursor.Position).Y);

				} // If Button = vbRightButton Then

			} // If lRow > 0 Then

			mnuCopyFindDupsGrid.Tag = "";

		} // fgrdFindDups_MouseDown

		private void fgrdFindCustSubData_MouseDown(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;


			int lRow = fgrdFindCustSubData.MouseRow;
			int lCol = fgrdFindCustSubData.MouseCol;

			if (lRow > 0)
			{

				if (Button == UpgradeHelpers.Utils.WinForms.MouseButtonsHelper.GetVB6ShortValue(MouseButtons.Right))
				{

					fgrdFindCustSubData.CurrentRowIndex = lRow;
					modCommon.Highlight_Grid_Row(fgrdFindCustSubData);

					if (fgrdFindCustSubData.get_RowData(lRow) > 0)
					{

						if (Convert.ToString(fgrdFindCustSubData[lRow, 17].Value) == "No")
						{

							mnuEdit.Enabled = true;

							mnuEditCompletedCustSubData.Enabled = true;
							mnuEditCompletedCustSubData.Available = true;
							mnuEditCompletedCustSubData.Tag = $"{lRow.ToString()}:{lCol.ToString()}";

							mnuCopyFindDupsGrid.Available = false;

							modCommon.Highlight_Grid_Row(fgrdFindCustSubData);

							//UPGRADE_WARNING: (6024) Default menues are not supported for Context Menues (Popup) More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6024
							Ctx_mnuEdit.Show(this, PointToClient(Cursor.Position).X, PointToClient(Cursor.Position).Y);

						} // If fgrdFindCustSubData.TextMatrix(lRow, 17) = "No" Then

					} // If fgrdFindCustSubData.RowData(lRow) > 0 Then

				} // If Button = vbRightButton Then

			} // If lRow > 0 Then

			mnuEditCompletedCustSubData.Tag = "";

		} // fgrdFindCustSubData_MouseDown

		private void grd_DocumentLog_Click(Object eventSender, EventArgs eventArgs)
		{

			lbl_gen[36].Visible = false; // Document Type
			cmbDocType.Visible = false;

		}

		private void grd_issues_DoubleClick(Object eventSender, EventArgs eventArgs)
		{



			frm_Company o_Local_Show_Company = null;
			if (cbo_multi[0].Text == "Aircraft")
			{

				if (grd_issues.get_RowData(grd_issues.CurrentRowIndex) > 0)
				{
					modAdminCommon.gbl_Aircraft_ID = grd_issues.get_RowData(grd_issues.CurrentRowIndex); // ACId
					modAdminCommon.gbl_Aircraft_Journal_ID = 0; // JournId

					frm_aircraft.DefInstance.Form_Initialize();
					frm_aircraft.DefInstance.StartForm = modGlobalVars.tStart_Form;
					frm_aircraft.DefInstance.Reference_Aircraft_ID = modAdminCommon.gbl_Aircraft_ID;
					frm_aircraft.DefInstance.Reference_Journal_ID = modAdminCommon.gbl_Aircraft_Journal_ID;
					frm_aircraft.DefInstance.Reference_Company_ID = 0;
					frm_aircraft.DefInstance.Show();
					//UPGRADE_WARNING: (2065) Form method frm_aircraft.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
					frm_aircraft.DefInstance.BringToFront();
					//UPGRADE_WARNING: (2065) Form event Form.Activated has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
					frm_aircraft.DefInstance.Form_Activated(frm_aircraft.DefInstance, new EventArgs());
				}


			}
			else
			{
				if (grd_issues.get_RowData(grd_issues.CurrentRowIndex) > 0)
				{

					modCommon.Unload_Form("frm_Company");

					o_Local_Show_Company = frm_Company.CreateInstance();
					//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//VB.Global.Load(o_Local_Show_Company);
					o_Local_Show_Company.Form_Initialize();
					o_Local_Show_Company.StartForm = modGlobalVars.tStart_Form;
					o_Local_Show_Company.Reference_CompanyID = grd_issues.get_RowData(grd_issues.CurrentRowIndex);
					o_Local_Show_Company.Reference_CompanyJID = 0;
					o_Local_Show_Company.Show();
					//UPGRADE_WARNING: (2065) Form method o_Local_Show_Company.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
					o_Local_Show_Company.BringToFront();
					//UPGRADE_WARNING: (2065) Form event Form.Activated has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
					o_Local_Show_Company.Form_Activated(null, new EventArgs());

				}
			}


		}


		private void grd_salesforce_DoubleClick(Object eventSender, EventArgs eventArgs)
		{



			frm_Company o_Local_Show_Company = null;
			if (grd_salesforce.get_RowData(grd_salesforce.CurrentRowIndex) > 0)
			{

				modCommon.Unload_Form("frm_Company");

				o_Local_Show_Company = frm_Company.CreateInstance();
				//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//VB.Global.Load(o_Local_Show_Company);
				o_Local_Show_Company.Form_Initialize();
				o_Local_Show_Company.StartForm = modGlobalVars.tStart_Form;
				o_Local_Show_Company.Reference_CompanyID = grd_salesforce.get_RowData(grd_salesforce.CurrentRowIndex);
				o_Local_Show_Company.Reference_CompanyJID = 0;
				o_Local_Show_Company.Show();
				//UPGRADE_WARNING: (2065) Form method o_Local_Show_Company.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
				o_Local_Show_Company.BringToFront();
				//UPGRADE_WARNING: (2065) Form event Form.Activated has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
				o_Local_Show_Company.Form_Activated(null, new EventArgs());

			}


		}




		private void lbl_gen_Click(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.lbl_gen, eventSender);


			switch(Index)
			{
				case 38 :  // Research Report 
					 
					if (Convert.ToString(cmbFindResearchReports.Tag) != "")
					{

						if (frm_Info.DefInstance == null)
						{
							//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//VB.Global.Load(frm_Info.DefInstance);
						}

						frm_Info.DefInstance.SetFormCaption(cmbFindResearchReports.Text);
						frm_Info.DefInstance.SetText(StringsHelper.Replace(Convert.ToString(cmbFindResearchReports.Tag), ". ", $".{Environment.NewLine}{Environment.NewLine}", 1, -1, CompareMethod.Binary));
						frm_Info.DefInstance.SetTextEnabled(true);
						frm_Info.DefInstance.Show();

					}  // If cmbFindResearchReports.Tag <> "" Then 


					 
					break;
			} // Case Index

		} // lbl_gen_Click

		private void lblFindACNoBaseStop_Click(Object eventSender, EventArgs eventArgs)
		{
			lblFindACNoBaseStop.Enabled = false;
			lblFindACNoBaseStop.Visible = false;
		}

		private void lblFindACNoCHPStop_Click(Object eventSender, EventArgs eventArgs)
		{
			lblFindACNoCHPStop.Enabled = false;
			lblFindACNoCHPStop.Visible = false;
		}

		private void lblFindCustSubDataStop_Click(Object eventSender, EventArgs eventArgs)
		{
			lblFindCustSubDataStop.Enabled = false;
			lblFindCustSubDataStop.Visible = false;
		}

		private void lblFindResearchReportsStop_Click(Object eventSender, EventArgs eventArgs) => lblFindResearchReportsStop.Enabled = false;


		private void lblPEventStop_Click(Object eventSender, EventArgs eventArgs)
		{
			lblPEventStop.Visible = false;
			lblPEventStop.Enabled = false;
		}

		private void lblReassignStopLoading_Click(Object eventSender, EventArgs eventArgs)
		{
			lblReassignStopLoading.Enabled = false;
			lblReassignStopLoading.Visible = false;
		}

		private void lblYTCallbackStop_Click(Object eventSender, EventArgs eventArgs) => lblYTCallbackStop.Enabled = false;


		public void mnuActionListShowUserHistory_Click(Object eventSender, EventArgs eventArgs)
		{

			if (frm_Main_Menu.DefInstance.mnuShowUserHistory.Text == "Show User History")
			{
				frm_UserHistory.DefInstance.Refresh_User_History_Grids("All");
				mnuActionListShowUserHistory.Text = "Hide User History";
				frm_Main_Menu.DefInstance.mnuShowUserHistory.Text = "Hide User History";
				modCommon.CenterFormOnHomebaseMainForm(frm_UserHistory.DefInstance);
				frm_UserHistory.DefInstance.Show();
			}
			else
			{
				frm_UserHistory.DefInstance.TimerOff();
				mnuActionListShowUserHistory.Text = "Show User History";
				frm_Main_Menu.DefInstance.mnuShowUserHistory.Text = "Show User History";
				frm_UserHistory.DefInstance.Hide();
			}

		} // mnuActionListShowUserHistory_Click

		public void mnuChangeDocType_Click(Object eventSender, EventArgs eventArgs)
		{

			string strDocType = "";
			string strDocDesc = "";
			int lACId = 0;
			int lJournId = 0;

			string strDocId = "";
			int lDocId = 0;

			int lRow1 = grd_DocumentLog.CurrentRowIndex;
			int lCol1 = grd_DocumentLog.CurrentColumnIndex;

			if (lRow1 > 0)
			{

				strDocType = Convert.ToString(grd_DocumentLog[lRow1, 2].Value);
				strDocDesc = modCommon.DLookUp("doctype_description", "Document_Type", $"(doctype_code = '{strDocType}')");

				modAdminCommon.gbl_Aircraft_ID = grd_DocumentLog.get_RowData(lRow1);
				modAdminCommon.gbl_Aircraft_Journal_ID = 0;

				strDocId = Convert.ToString(grd_DocumentLog[lRow1, 10].Value);
				lDocId = Convert.ToInt32(Double.Parse(strDocId));

				lbl_gen[36].Visible = true;
				cmbDocType.Visible = true;

				cmbDocType.Enabled = false;
				modCommon.SetComboText(cmbDocType, $"{strDocType} - {strDocDesc}");
				cmbDocType.Enabled = true;

			} // If lRow1 > 0 Then

		} // mnuChangeDocType_Click

		public void mnuCopyFindDupsGrid_Click(Object eventSender, EventArgs eventArgs)
		{

			int lRow = 0;
			int lCol = 0;
			int iPos1 = 0;

			if (Convert.ToString(mnuCopyFindDupsGrid.Tag) != "")
			{

				iPos1 = (Convert.ToString(mnuCopyFindDupsGrid.Tag).IndexOf(':') + 1);
				if (iPos1 > 0)
				{

					lRow = Convert.ToInt32(Double.Parse(Convert.ToString(mnuCopyFindDupsGrid.Tag).Substring(Math.Min(0, Convert.ToString(mnuCopyFindDupsGrid.Tag).Length), Math.Min(iPos1 - 1, Math.Max(0, Convert.ToString(mnuCopyFindDupsGrid.Tag).Length)))));
					lCol = Convert.ToInt32(Double.Parse(Convert.ToString(mnuCopyFindDupsGrid.Tag).Substring(Math.Min(iPos1, Convert.ToString(mnuCopyFindDupsGrid.Tag).Length))));

					Clipboard.Clear();

					//UPGRADE_WARNING: (2081) Clipboard.SetText has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
					Clipboard.SetText(Convert.ToString(fgrdFindDups[lRow, lCol].Value));
					modCommon.Highlight_Grid_Row(fgrdFindDups);

				} // If iPos1 > 0 Then

			} // If mnuCopyFindDupsGrid.Tag <> "" Then

		} // mnuCopyFindDupsGrid_Click

		private void Fill_Find_Duplicate_Callback_Grid_Headers(string strReport)
		{

			int lRowl = 0;

			fgrdFindDups.Clear();
			fgrdFindDups.RowsCount = 2;

			double dPlusWidth = 1.5d;
			fgrdFindDups.ColumnsCount = 5;
			if (strReport.IndexOf("Contact") >= 0)
			{
				dPlusWidth = 1;
				fgrdFindDups.ColumnsCount = 11;
			}

			fgrdFindDups.CurrentRowIndex = 0;

			int lCol1 = -1;

			lCol1++;
			fgrdFindDups.CurrentColumnIndex = lCol1;
			fgrdFindDups[fgrdFindDups.CurrentRowIndex, fgrdFindDups.CurrentColumnIndex].Value = "CompId";
			fgrdFindDups.SetColumnWidth(lCol1, 60);
			fgrdFindDups.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindDups.CurrentColumnIndex = lCol1;
			fgrdFindDups[fgrdFindDups.CurrentRowIndex, fgrdFindDups.CurrentColumnIndex].Value = "Company";
			fgrdFindDups.SetColumnWidth(lCol1, Convert.ToInt32(2500 * dPlusWidth) / 15);
			fgrdFindDups.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindDups.CurrentColumnIndex = lCol1;
			fgrdFindDups[fgrdFindDups.CurrentRowIndex, fgrdFindDups.CurrentColumnIndex].Value = "Address1";
			fgrdFindDups.SetColumnWidth(lCol1, Convert.ToInt32(2250 * dPlusWidth) / 15);
			fgrdFindDups.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindDups.CurrentColumnIndex = lCol1;
			fgrdFindDups[fgrdFindDups.CurrentRowIndex, fgrdFindDups.CurrentColumnIndex].Value = "CompId String";
			fgrdFindDups.SetColumnWidth(lCol1, Convert.ToInt32(2250 * dPlusWidth) / 15);
			fgrdFindDups.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindDups.CurrentColumnIndex = lCol1;
			fgrdFindDups[fgrdFindDups.CurrentRowIndex, fgrdFindDups.CurrentColumnIndex].Value = "Nbr A/C";
			fgrdFindDups.SetColumnWidth(lCol1, 50);
			fgrdFindDups.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

			if (fgrdFindDups.ColumnsCount > 5)
			{

				// CompIdString
				fgrdFindDups.SetColumnWidth(lCol1 - 1, 0); // No Need For This

				lCol1++;
				fgrdFindDups.CurrentColumnIndex = lCol1;
				fgrdFindDups[fgrdFindDups.CurrentRowIndex, fgrdFindDups.CurrentColumnIndex].Value = "ContactId";
				fgrdFindDups.SetColumnWidth(lCol1, 60);
				fgrdFindDups.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

				lCol1++;
				fgrdFindDups.CurrentColumnIndex = lCol1;
				fgrdFindDups[fgrdFindDups.CurrentRowIndex, fgrdFindDups.CurrentColumnIndex].Value = "Contact";
				fgrdFindDups.SetColumnWidth(lCol1, 160);
				fgrdFindDups.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

				lCol1++;
				fgrdFindDups.CurrentColumnIndex = lCol1;
				fgrdFindDups[fgrdFindDups.CurrentRowIndex, fgrdFindDups.CurrentColumnIndex].Value = "EMail Address";
				if (strReport.IndexOf("EMail") >= 0)
				{
					fgrdFindDups.SetColumnWidth(lCol1, 160);
				}
				else
				{
					fgrdFindDups.SetColumnWidth(lCol1, 0); // No Need For This
				}
				fgrdFindDups.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

				lCol1++;
				fgrdFindDups.CurrentColumnIndex = lCol1;
				fgrdFindDups[fgrdFindDups.CurrentRowIndex, fgrdFindDups.CurrentColumnIndex].Value = "Phone Type";
				if (strReport.IndexOf("Phone") >= 0)
				{
					fgrdFindDups.SetColumnWidth(lCol1, 77);
				}
				else
				{
					fgrdFindDups.SetColumnWidth(lCol1, 0); // No Need For This
				}
				fgrdFindDups.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

				lCol1++;
				fgrdFindDups.CurrentColumnIndex = lCol1;
				fgrdFindDups[fgrdFindDups.CurrentRowIndex, fgrdFindDups.CurrentColumnIndex].Value = "Phone Nbr";
				if (strReport.IndexOf("Phone") >= 0)
				{
					fgrdFindDups.SetColumnWidth(lCol1, 93);
				}
				else
				{
					fgrdFindDups.SetColumnWidth(lCol1, 0); // No Need For This
				}
				fgrdFindDups.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

				lCol1++;
				fgrdFindDups.CurrentColumnIndex = lCol1;
				fgrdFindDups[fgrdFindDups.CurrentRowIndex, fgrdFindDups.CurrentColumnIndex].Value = "ContactId String";
				fgrdFindDups.SetColumnWidth(lCol1, 153);
				fgrdFindDups.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			} // If fgrdFindDups.Cols > 5 Then

			fgrdFindDups.FixedRows = 1;
			fgrdFindDups.FixedColumns = 0;

			fgrdFindDups.CurrentRowIndex = 1;

		} // Fill_Find_Duplicate_Callback_Grid_Headers

		private void Create_Find_Duplicate_Company_Contact_Temp_Table(DbConnection cntConn, ref string strTempTable)
		{

			string strDrop1 = "";
			string strCreate1 = "";
			string strCreate2 = "";
			string strCreate3 = "";
			string strCreate4 = "";
			string strCreate5 = "";
			string strCreate6 = "";
			string strCreate7 = "";

			int lErr = 0;
			string strErr = "";



			string strTempTableName = "";
			string strTempTableTmp = strTempTable;
			ErrorHandlingHelper.ResumeNext(
				() => {strTempTableName = $"Temp_Table_{modCommon.GetGUID()}";}, 
				() => {strTempTableTmp = $"#{strTempTableName}";}, 

					//------------------------------------
					// Drop Table If It Exists

				() => {strDrop1 = $"{strDrop1}DROP TABLE {strTempTableTmp} ";});
			strTempTable = strTempTableTmp;

			try
			{

				//-----------------------------------
				// Create Temp Table

				strCreate1 = $"CREATE TABLE {strTempTable} ";
				strCreate1 = $"{strCreate1}( ";
				strCreate1 = $"{strCreate1}AcctRep VARCHAR(4), ";
				strCreate1 = $"{strCreate1}JournId INT, ";
				strCreate1 = $"{strCreate1}CompId INT, ";
				strCreate1 = $"{strCreate1}Company VARCHAR(150), ";
				strCreate1 = $"{strCreate1}Address1 VARCHAR(150), ";
				strCreate1 = $"{strCreate1}Address1Search VARCHAR(150), ";
				strCreate1 = $"{strCreate1}City VARCHAR(50), ";
				strCreate1 = $"{strCreate1}CitySearch VARCHAR(50), ";
				strCreate1 = $"{strCreate1}StateCode VARCHAR(4), ";
				strCreate1 = $"{strCreate1}Country VARCHAR(25), ";
				strCreate1 = $"{strCreate1}CompIdString VARCHAR(500), ";
				strCreate1 = $"{strCreate1}NbrAircraft INT, ";
				strCreate1 = $"{strCreate1}ContactId INT, ";
				strCreate1 = $"{strCreate1}Contact VARCHAR(150), ";
				strCreate1 = $"{strCreate1}ContactSearch VARCHAR(150), ";
				strCreate1 = $"{strCreate1}EMailAddress VARCHAR(150), ";
				strCreate1 = $"{strCreate1}EMailAddressSearch VARCHAR(150), ";
				strCreate1 = $"{strCreate1}PhoneType VARCHAR(15), ";
				strCreate1 = $"{strCreate1}PhoneNbr VARCHAR(150), ";
				strCreate1 = $"{strCreate1}PhoneNbrSearch VARCHAR(150), ";
				strCreate1 = $"{strCreate1}ContactIdString VarChar(500) ";
				strCreate1 = $"{strCreate1})";

				DbCommand TempCommand = null;
				TempCommand = cntConn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = strCreate1;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();

				//-----------------------------------------
				//-- Create Indexes

				strCreate2 = $"CREATE INDEX PK_{strTempTableName}_Key1 ON {strTempTable}(CompId, ContactId, JournId)";
				DbCommand TempCommand_2 = null;
				TempCommand_2 = cntConn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
				TempCommand_2.CommandText = strCreate2;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand_2.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
				TempCommand_2.ExecuteNonQuery();

				strCreate3 = $"CREATE INDEX PK_{strTempTableName}_Key2 ON {strTempTable}(ContactId, CompId, JournId)";
				DbCommand TempCommand_3 = null;
				TempCommand_3 = cntConn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_3);
				TempCommand_3.CommandText = strCreate3;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand_3.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_3);
				TempCommand_3.ExecuteNonQuery();

				strCreate4 = $"CREATE INDEX PK_{strTempTableName}_Key3 ON {strTempTable}(Address1Search, CitySearch)";
				DbCommand TempCommand_4 = null;
				TempCommand_4 = cntConn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_4);
				TempCommand_4.CommandText = strCreate4;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand_4.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_4);
				TempCommand_4.ExecuteNonQuery();

				strCreate5 = $"CREATE INDEX PK_{strTempTableName}_Key4 ON {strTempTable}(ContactSearch)";
				DbCommand TempCommand_5 = null;
				TempCommand_5 = cntConn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_5);
				TempCommand_5.CommandText = strCreate5;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand_5.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_5);
				TempCommand_5.ExecuteNonQuery();

				strCreate6 = $"CREATE INDEX PK_{strTempTableName}_Key5 ON {strTempTable}(EMailAddressSearch)";
				DbCommand TempCommand_6 = null;
				TempCommand_6 = cntConn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_6);
				TempCommand_6.CommandText = strCreate6;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand_6.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_6);
				TempCommand_6.ExecuteNonQuery();

				strCreate7 = $"CREATE INDEX PK_{strTempTableName}_Key6 ON {strTempTable}(PhoneNbrSearch)";
				DbCommand TempCommand_7 = null;
				TempCommand_7 = cntConn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_7);
				TempCommand_7.CommandText = strCreate7;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand_7.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_7);
				TempCommand_7.ExecuteNonQuery();
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErr = Information.Err().Number;
				strErr = excep.Message;

				modAdminCommon.Record_Error("Callbacks (Create Temp Table)", $"Create_Find_Duplicate_Company_Contact_Temp_Table_Error: {lErr.ToString()} - {strErr}");
				lblFindDupsRecords.Text = $"Error: {strErr}";

				strTempTable = "";
			}

		} // Create_Find_Duplicate_Company_Contact_Temp_Table

		public string Create_Insert_Into_Find_Duplicate_Company_Contact_Temp_Table(string strReport, string strTempTable)
		{


			string strInsert1 = $"INSERT INTO {strTempTable} ";
			strInsert1 = $"{strInsert1}SELECT ";
			strInsert1 = $"{strInsert1}C1.comp_account_id AS AcctRep, ";
			strInsert1 = $"{strInsert1}C1.comp_journ_id As JournId, ";
			strInsert1 = $"{strInsert1}C1.comp_id As CompId, ";
			strInsert1 = $"{strInsert1}C1.comp_name As Company, ";
			strInsert1 = $"{strInsert1}C1.comp_address1 As Address1, ";
			strInsert1 = $"{strInsert1}C1.comp_address1_search As Address1Search, ";
			strInsert1 = $"{strInsert1}C1.comp_city As City, ";
			strInsert1 = $"{strInsert1}dbo.LeaveAlphaAndNumeric(C1.comp_city) As CitySearch, ";
			strInsert1 = $"{strInsert1}C1.comp_state As StateCode, ";
			strInsert1 = $"{strInsert1}C1.comp_country As Country, ";
			strInsert1 = $"{strInsert1}'' As CompIdString, ";
			strInsert1 = $"{strInsert1}(SELECT COUNT(DISTINCT AR1.cref_ac_id) ";
			strInsert1 = $"{strInsert1} FROM Aircraft_Reference AS AR1 WITH (NOLOCK) ";
			strInsert1 = $"{strInsert1} WHERE (AR1.cref_journ_id = 0) ";
			strInsert1 = $"{strInsert1} AND (AR1.cref_comp_id = C1.comp_id) ";
			strInsert1 = $"{strInsert1}) As NbrAircraft, ";


			switch(strReport)
			{
				case "Company Address" : 
					 
					lblFindDupsRecords.Text = "Creating Temporary Search Table (Company Address)"; 
					 
					strInsert1 = $"{strInsert1}0 As ContactId, "; 
					strInsert1 = $"{strInsert1}'' As Contact, "; 
					strInsert1 = $"{strInsert1}'' As ContactSearch, "; 
					strInsert1 = $"{strInsert1}'' As EMailAddress, "; 
					strInsert1 = $"{strInsert1}'' As EMailAddressSearch, "; 
					strInsert1 = $"{strInsert1}'' As PhoneType, "; 
					strInsert1 = $"{strInsert1}'' As PhoneNbr, "; 
					strInsert1 = $"{strInsert1}'' As PhoneNbrSearch, "; 
					strInsert1 = $"{strInsert1}'' As ContactIdString "; 
					strInsert1 = $"{strInsert1}FROM Company AS C1 WITH (NOLOCK) "; 
					strInsert1 = $"{strInsert1}WHERE (C1.comp_journ_id = 0) "; 
					strInsert1 = $"{strInsert1}AND (C1.comp_address1 IS NOT NULL) "; 
					strInsert1 = $"{strInsert1}AND (C1.comp_address1 <> '') "; 
					strInsert1 = $"{strInsert1}AND (C1.comp_city IS NOT NULL) "; 
					strInsert1 = $"{strInsert1}AND (C1.comp_city <> '') "; 
					 
					break;
				case "Contact EMail" : 
					 
					lblFindDupsRecords.Text = "Creating Temporary Search Table (Contact EMail)"; 
					 
					strInsert1 = $"{strInsert1}CT1.contact_id As ContactId, "; 
					strInsert1 = $"{strInsert1}dbo.CreateContactFullNameTitle(CT1.contact_sirname, CT1.contact_first_name, CT1.contact_middle_initial, CT1.contact_last_name, CT1.contact_suffix,'') As Contact, "; 
					strInsert1 = $"{strInsert1}dbo.LeaveAlphaAndNumeric(dbo.CreateContactFullNameTitle(CT1.contact_sirname, CT1.contact_first_name, CT1.contact_middle_initial, CT1.contact_last_name, CT1.contact_suffix,'')) As ContactSearch, "; 
					strInsert1 = $"{strInsert1}CT1.contact_email_address As EMailAddress, "; 
					strInsert1 = $"{strInsert1}dbo.LeaveAlphaAndNumeric(CT1.contact_email_address) As EMailAddressSearch, "; 
					strInsert1 = $"{strInsert1}'' As PhoneType, "; 
					strInsert1 = $"{strInsert1}'' As PhoneNbr, "; 
					strInsert1 = $"{strInsert1}'' As PhoneNbrSearch, "; 
					strInsert1 = $"{strInsert1}'' As ContactIdString "; 
					strInsert1 = $"{strInsert1}FROM Contact AS CT1 WITH (NOLOCK) "; 
					strInsert1 = $"{strInsert1}INNER JOIN Company AS C1 WITH (NOLOCK) ON comp_id = contact_comp_id AND comp_journ_id = contact_journ_id "; 
					strInsert1 = $"{strInsert1}WHERE (CT1.contact_journ_id = 0) "; 
					strInsert1 = $"{strInsert1}AND (CT1.contact_email_address IS NOT NULL) "; 
					strInsert1 = $"{strInsert1}AND (CT1.contact_email_address <> '') "; 
					strInsert1 = $"{strInsert1}AND (CT1.contact_first_name IS NOT NULL) "; 
					strInsert1 = $"{strInsert1}AND (CT1.contact_first_name <> '') "; 
					strInsert1 = $"{strInsert1}AND (CT1.contact_last_name IS NOT NULL) "; 
					strInsert1 = $"{strInsert1}AND (CT1.contact_last_name <> '') "; 
					strInsert1 = $"{strInsert1}AND (CT1.contact_active_flag = 'Y') "; 
					 
					break;
				case "Contact Phone Nbr" : 
					 
					lblFindDupsRecords.Text = "Creating Temporary Search Table (Contact Phone Nbr)"; 
					 
					strInsert1 = $"{strInsert1}CT1.contact_id As ContactId, "; 
					strInsert1 = $"{strInsert1}dbo.CreateContactFullNameTitle(CT1.contact_sirname, CT1.contact_first_name, CT1.contact_middle_initial, CT1.contact_last_name, CT1.contact_suffix,'') As Contact, "; 
					strInsert1 = $"{strInsert1}dbo.LeaveAlphaAndNumeric(dbo.CreateContactFullNameTitle(CT1.contact_sirname, CT1.contact_first_name, CT1.contact_middle_initial, CT1.contact_last_name, CT1.contact_suffix,'')) As ContactSearch, "; 
					strInsert1 = $"{strInsert1}CT1.contact_email_address As EMailAddress, "; 
					strInsert1 = $"{strInsert1}dbo.LeaveAlphaAndNumeric(CT1.contact_email_address) As EMailAddressSearch, "; 
					strInsert1 = $"{strInsert1}PN1.pnum_type As PhoneType, "; 
					strInsert1 = $"{strInsert1}PN1.pnum_number_full As PhoneNbr, "; 
					strInsert1 = $"{strInsert1}dbo.LeaveAlphaAndNumeric(PN1.pnum_number_full) As PhoneNbrSearch, "; 
					strInsert1 = $"{strInsert1}'' As ContactIdString "; 
					strInsert1 = $"{strInsert1}FROM Contact AS CT1 WITH (NOLOCK) "; 
					strInsert1 = $"{strInsert1}INNER JOIN Company AS C1 WITH (NOLOCK) ON comp_id = contact_comp_id AND comp_journ_id = contact_journ_id "; 
					strInsert1 = $"{strInsert1}INNER JOIN Phone_Numbers AS PN1 WITH (NOLOCK) ON pnum_comp_id = contact_comp_id AND pnum_contact_id = contact_id AND pnum_journ_id = contact_journ_id "; 
					strInsert1 = $"{strInsert1}WHERE (CT1.contact_journ_id = 0) "; 
					strInsert1 = $"{strInsert1}AND (PN1.pnum_journ_id = 0) "; 
					strInsert1 = $"{strInsert1}AND (PN1.pnum_contact_id > 0) "; 
					strInsert1 = $"{strInsert1}AND (PN1.pnum_number_full IS NOT NULL) "; 
					strInsert1 = $"{strInsert1}AND (PN1.pnum_number_full <> '') "; 
					strInsert1 = $"{strInsert1}AND (CT1.contact_active_flag = 'Y') "; 
					strInsert1 = $"{strInsert1}AND (CT1.contact_first_name IS NOT NULL) "; 
					strInsert1 = $"{strInsert1}AND (CT1.contact_first_name <> '') "; 
					strInsert1 = $"{strInsert1}AND (CT1.contact_last_name IS NOT NULL) "; 
					strInsert1 = $"{strInsert1}AND (CT1.contact_last_name <> '') "; 
					 
					break;
				case "Contact Name" : 
					 
					lblFindDupsRecords.Text = "Creating Temporary Search Table (Contact Name) "; 
					 
					strInsert1 = $"{strInsert1}CT1.contact_id As ContactId, "; 
					strInsert1 = $"{strInsert1}dbo.CreateContactFullNameTitle(CT1.contact_sirname, CT1.contact_first_name, CT1.contact_middle_initial, CT1.contact_last_name, CT1.contact_suffix,'') As Contact, "; 
					strInsert1 = $"{strInsert1}dbo.LeaveAlphaAndNumeric(dbo.CreateContactFullNameTitle(CT1.contact_sirname, CT1.contact_first_name, CT1.contact_middle_initial, CT1.contact_last_name, CT1.contact_suffix,'')) As ContactSearch, "; 
					strInsert1 = $"{strInsert1}CT1.contact_email_address As EMailAddress, "; 
					strInsert1 = $"{strInsert1}dbo.LeaveAlphaAndNumeric(CT1.contact_email_address) As EMailAddressSearch, "; 
					strInsert1 = $"{strInsert1}'' As PhoneType, "; 
					strInsert1 = $"{strInsert1}'' As PhoneNbr, "; 
					strInsert1 = $"{strInsert1}'' As PhoneNbrSearch, "; 
					strInsert1 = $"{strInsert1}'' As ContactIdString "; 
					strInsert1 = $"{strInsert1}FROM Contact AS CT1 WITH (NOLOCK) "; 
					strInsert1 = $"{strInsert1}INNER JOIN Company AS C1 WITH (NOLOCK) ON comp_id = contact_comp_id AND comp_journ_id = contact_journ_id "; 
					strInsert1 = $"{strInsert1}WHERE (CT1.contact_journ_id = 0) "; 
					strInsert1 = $"{strInsert1}AND (dbo.CreateContactFullNameTitle(CT1.contact_sirname, CT1.contact_first_name, CT1.contact_middle_initial, CT1.contact_last_name, CT1.contact_suffix,'') <> '') "; 
					strInsert1 = $"{strInsert1}AND (CT1.contact_first_name IS NOT NULL) "; 
					strInsert1 = $"{strInsert1}AND (CT1.contact_first_name <> '') "; 
					strInsert1 = $"{strInsert1}AND (CT1.contact_last_name IS NOT NULL) "; 
					strInsert1 = $"{strInsert1}AND (CT1.contact_last_name <> '') "; 
					strInsert1 = $"{strInsert1}AND (CT1.contact_active_flag = 'Y') "; 
					 
					break;
			} // Case Report

			strInsert1 = $"{strInsert1}AND (C1.comp_active_flag = 'Y') ";
			strInsert1 = $"{strInsert1}AND (C1.comp_name <> 'Awaiting Documentation') ";
			strInsert1 = $"{strInsert1}AND (LEFT(C1.comp_account_id,2) <> 'ID') ";
			strInsert1 = $"{strInsert1}AND (C1.comp_account_id <> 'IDGM') ";
			strInsert1 = $"{strInsert1}AND (C1.comp_account_id <> 'AC19') ";
			strInsert1 = $"{strInsert1}ORDER BY CompId, JournId ";

			return strInsert1;

		} // Create_Insert_Into_Find_Duplicate_Company_Contact_Temp_Table

		private string Create_Select_Query_Find_Duplicate_Company_Contact_Temp_Table(string strReport, string strTempTable, string strAcctRep)
		{


			string strQuery1 = "SELECT ";
			strQuery1 = $"{strQuery1}C1.AcctRep, ";
			strQuery1 = $"{strQuery1}C1.JournId, ";
			strQuery1 = $"{strQuery1}C1.CompId, ";
			strQuery1 = $"{strQuery1}C1.Company, ";
			strQuery1 = $"{strQuery1}C1.Address1, ";
			strQuery1 = $"{strQuery1}C1.Address1Search, ";
			strQuery1 = $"{strQuery1}C1.City, ";
			strQuery1 = $"{strQuery1}C1.CitySearch, ";
			strQuery1 = $"{strQuery1}C1.StateCode, ";
			strQuery1 = $"{strQuery1}C1.Country, ";
			strQuery1 = $"{strQuery1}C1.NbrAircraft, ";


			switch(strReport)
			{
				case "Company Address" : 
					 
					lblFindDupsRecords.Text = "Searching Records (Company Address)"; 
					 
					strQuery1 = $"{strQuery1}STUFF("; 
					strQuery1 = $"{strQuery1}     (SELECT ';'+RTRIM(CAST(C2.CompId AS VARCHAR(8))) "; 
					strQuery1 = $"{strQuery1}      FROM {strTempTable} AS C2 WITH (NOLOCK) "; 
					strQuery1 = $"{strQuery1}      WHERE (C2.JournID = 0) "; 
					strQuery1 = $"{strQuery1}      AND (C2.CompId <> C1.CompId) "; 
					strQuery1 = $"{strQuery1}      AND (C2.Address1Search = C1.Address1Search) "; 
					strQuery1 = $"{strQuery1}      AND (C2.CitySearch = C1.CitySearch) "; 
					 
					//                              -- And NOT Related 
					strQuery1 = $"{strQuery1}      AND (NOT EXISTS (SELECT NULL FROM Company_Reference AS CR2 WITH (NOLOCK) "; 
					strQuery1 = $"{strQuery1}                       WHERE (CR2.compref_journ_id = 0) "; 
					strQuery1 = $"{strQuery1}                       AND ( "; 
					strQuery1 = $"{strQuery1}                              (CR2.compref_comp_id = C1.CompId OR CR2.compref_rel_comp_id = C1.CompId) "; 
					strQuery1 = $"{strQuery1}                           ) "; 
					strQuery1 = $"{strQuery1}                      ) "; 
					strQuery1 = $"{strQuery1}          ) "; 
					strQuery1 = $"{strQuery1}       FOR XML PATH('') "; 
					strQuery1 = $"{strQuery1}     ),1,1,'' "; 
					strQuery1 = $"{strQuery1}     ) As CompIdString, "; 
					strQuery1 = $"{strQuery1}C1.ContactId, "; 
					strQuery1 = $"{strQuery1}C1.Contact, "; 
					strQuery1 = $"{strQuery1}C1.ContactSearch, "; 
					strQuery1 = $"{strQuery1}C1.EMailAddress, "; 
					strQuery1 = $"{strQuery1}C1.EMailAddressSearch, "; 
					strQuery1 = $"{strQuery1}C1.PhoneType, "; 
					strQuery1 = $"{strQuery1}C1.PhoneNbr, "; 
					strQuery1 = $"{strQuery1}C1.PhoneNbrSearch, "; 
					strQuery1 = $"{strQuery1}C1.ContactIdString "; 
					 
					strQuery1 = $"{strQuery1}FROM {strTempTable} AS C1 WITH (NOLOCK) "; 
					strQuery1 = $"{strQuery1}WHERE (C1.JournId = 0) "; 
					strQuery1 = $"{strQuery1}AND (C1.CompId > 0) "; 
					 
					//--------------------------------------- 
					// Select Account Rep Type 
					 
					if (strAcctRep != "" && strAcctRep != "NO REP SELECTED")
					{
						strQuery1 = $"{strQuery1}AND (C1.AcctRep = '{strAcctRep}') ";
					} 
					 
					strQuery1 = $"{strQuery1}AND (EXISTS (SELECT NULL FROM {strTempTable} AS C2 WITH (NOLOCK) "; 
					strQuery1 = $"{strQuery1}             WHERE (C2.JournID = 0) "; 
					strQuery1 = $"{strQuery1}             AND (C2.CompId <> C1.CompId) "; 
					strQuery1 = $"{strQuery1}             AND (C2.Address1Search = C1.Address1Search) "; 
					strQuery1 = $"{strQuery1}             AND (C2.City = C1.City) "; 
					 
					//                                     -- And NOT Related 
					strQuery1 = $"{strQuery1}             AND (NOT EXISTS (SELECT NULL FROM Company_Reference AS CR2 WITH (NOLOCK) "; 
					strQuery1 = $"{strQuery1}                              WHERE (CR2.compref_journ_id = 0) "; 
					strQuery1 = $"{strQuery1}                              AND ( "; 
					strQuery1 = $"{strQuery1}                                     (CR2.compref_comp_id = C1.CompId OR CR2.compref_rel_comp_id = C1.CompId) "; 
					strQuery1 = $"{strQuery1}                                  ) "; 
					strQuery1 = $"{strQuery1}                             ) "; 
					strQuery1 = $"{strQuery1}                 ) "; 
					strQuery1 = $"{strQuery1}             ) "; 
					strQuery1 = $"{strQuery1}     ) "; 
					strQuery1 = $"{strQuery1}ORDER BY Company, CitySearch, Address1Search "; 
					 
					break;
				case "Contact EMail" : 
					 
					lblFindDupsRecords.Text = "Searching Records (Contact EMail)"; 
					 
					strQuery1 = $"{strQuery1}C1.CompIdString, "; 
					strQuery1 = $"{strQuery1}C1.ContactId, "; 
					strQuery1 = $"{strQuery1}C1.Contact, "; 
					strQuery1 = $"{strQuery1}C1.ContactSearch, "; 
					strQuery1 = $"{strQuery1}C1.EMailAddress, "; 
					strQuery1 = $"{strQuery1}C1.EMailAddressSearch, "; 
					strQuery1 = $"{strQuery1}C1.PhoneType ,"; 
					strQuery1 = $"{strQuery1}C1.PhoneNbr, "; 
					strQuery1 = $"{strQuery1}C1.PhoneNbrSearch, "; 
					strQuery1 = $"{strQuery1}STUFF("; 
					strQuery1 = $"{strQuery1}     (SELECT ';'+RTRIM(CAST(C2.ContactId AS VARCHAR(8))) "; 
					strQuery1 = $"{strQuery1}      FROM {strTempTable} AS C2 WITH (NOLOCK) "; 
					strQuery1 = $"{strQuery1}      WHERE (C2.JournID = 0) "; 
					strQuery1 = $"{strQuery1}      AND (C2.CompId <> C1.CompId) "; 
					strQuery1 = $"{strQuery1}      AND (C2.ContactId <> C1.ContactId) "; 
					strQuery1 = $"{strQuery1}      AND (C2.ContactId > 0 AND C1.ContactId > 0) "; 
					strQuery1 = $"{strQuery1}      AND (C2.EMailAddressSearch = C1.EMailAddressSearch) "; 
					 
					//                              -- And NOT Related 
					strQuery1 = $"{strQuery1}      AND (NOT EXISTS (SELECT NULL FROM Contact_Reference AS CTR2 WITH (NOLOCK) "; 
					strQuery1 = $"{strQuery1}                       WHERE (CTR2.cr_journ_id = 0) "; 
					strQuery1 = $"{strQuery1}                       AND ( "; 
					strQuery1 = $"{strQuery1}                              (CTR2.cr_contact_id = C1.ContactId OR CTR2.cr_contact_rel_id = C1.ContactId) "; 
					strQuery1 = $"{strQuery1}                           ) "; 
					strQuery1 = $"{strQuery1}                      ) "; 
					strQuery1 = $"{strQuery1}          ) "; 
					strQuery1 = $"{strQuery1}       FOR XML PATH('') "; 
					strQuery1 = $"{strQuery1}     ),1,1,'' "; 
					strQuery1 = $"{strQuery1}     ) As ContactIdString "; 
					 
					strQuery1 = $"{strQuery1}FROM {strTempTable} AS C1 WITH (NOLOCK) "; 
					strQuery1 = $"{strQuery1}WHERE (C1.JournId = 0) "; 
					strQuery1 = $"{strQuery1}AND (C1.CompId > 0) "; 
					strQuery1 = $"{strQuery1}AND (C1.ContactId > 0) "; 
					 
					//--------------------------------------- 
					// Select Account Rep Type 
					 
					if (strAcctRep != "" && strAcctRep != "NO REP SELECTED")
					{
						strQuery1 = $"{strQuery1}AND (C1.AcctRep = '{strAcctRep}') ";
					} 
					 
					strQuery1 = $"{strQuery1}AND (EXISTS (SELECT NULL FROM {strTempTable} AS C2 WITH (NOLOCK) "; 
					strQuery1 = $"{strQuery1}             WHERE (C2.JournID = 0) "; 
					strQuery1 = $"{strQuery1}             AND (C2.CompId <> C1.CompId) "; 
					strQuery1 = $"{strQuery1}             AND (C2.ContactId <> C1.ContactId) "; 
					strQuery1 = $"{strQuery1}             AND (C2.ContactId > 0) "; 
					strQuery1 = $"{strQuery1}             AND (C2.EMailAddressSearch = C1.EMailAddressSearch)"; 
					 
					//                                   -- And NOT Related 
					strQuery1 = $"{strQuery1}             AND (NOT EXISTS (SELECT NULL FROM Contact_Reference AS CTR2 WITH (NOLOCK) "; 
					strQuery1 = $"{strQuery1}                              WHERE (CTR2.cr_journ_id = 0) "; 
					strQuery1 = $"{strQuery1}                              AND ( "; 
					strQuery1 = $"{strQuery1}                                     (CTR2.cr_contact_id = C1.ContactId OR CTR2.cr_contact_rel_id = C1.ContactId) "; 
					strQuery1 = $"{strQuery1}                                  ) "; 
					strQuery1 = $"{strQuery1}                             ) "; 
					strQuery1 = $"{strQuery1}                 ) "; 
					strQuery1 = $"{strQuery1}             ) "; 
					strQuery1 = $"{strQuery1}     ) "; 
					strQuery1 = $"{strQuery1}ORDER BY Company, Contact, EMailAddress "; 
					 
					break;
				case "Contact Phone Nbr" : 
					 
					lblFindDupsRecords.Text = "Searching Records (Contact Phone Nbr)"; 
					 
					strQuery1 = $"{strQuery1}C1.CompIdString, "; 
					strQuery1 = $"{strQuery1}C1.ContactId, "; 
					strQuery1 = $"{strQuery1}C1.Contact, "; 
					strQuery1 = $"{strQuery1}C1.ContactSearch, "; 
					strQuery1 = $"{strQuery1}C1.EMailAddress, "; 
					strQuery1 = $"{strQuery1}C1.EMailAddressSearch, "; 
					strQuery1 = $"{strQuery1}C1.PhoneType, "; 
					strQuery1 = $"{strQuery1}C1.PhoneNbr, "; 
					strQuery1 = $"{strQuery1}C1.PhoneNbrSearch, "; 
					strQuery1 = $"{strQuery1}STUFF( "; 
					strQuery1 = $"{strQuery1}     (SELECT ';'+RTRIM(CAST(C2.ContactId AS VARCHAR(8))) "; 
					strQuery1 = $"{strQuery1}      FROM {strTempTable} AS C2 WITH (NOLOCK) "; 
					strQuery1 = $"{strQuery1}      WHERE (C2.JournID = 0) "; 
					strQuery1 = $"{strQuery1}      AND (C2.CompId <> C1.CompId) "; 
					strQuery1 = $"{strQuery1}      AND (C2.ContactId <> C1.ContactId) "; 
					strQuery1 = $"{strQuery1}      AND (C2.ContactId > 0 AND C1.ContactId > 0) "; 
					strQuery1 = $"{strQuery1}      AND (C2.PhoneNbrSearch = C1.PhoneNbrSearch) "; 
					 
					//                              -- And NOT Related 
					strQuery1 = $"{strQuery1}      AND (NOT EXISTS (SELECT NULL FROM Contact_Reference AS CTR2 WITH (NOLOCK) "; 
					strQuery1 = $"{strQuery1}                       WHERE (CTR2.cr_journ_id = 0) "; 
					strQuery1 = $"{strQuery1}                       AND ( "; 
					strQuery1 = $"{strQuery1}                              (CTR2.cr_contact_id = C1.ContactId OR CTR2.cr_contact_rel_id = C1.ContactId) "; 
					strQuery1 = $"{strQuery1}                           ) "; 
					strQuery1 = $"{strQuery1}                      ) "; 
					strQuery1 = $"{strQuery1}          ) "; 
					strQuery1 = $"{strQuery1}       FOR XML PATH('') "; 
					strQuery1 = $"{strQuery1}     ),1,1,'' "; 
					strQuery1 = $"{strQuery1}     ) As ContactIdString "; 
					 
					strQuery1 = $"{strQuery1}FROM {strTempTable} AS C1 WITH (NOLOCK) "; 
					strQuery1 = $"{strQuery1}WHERE (C1.JournId = 0) "; 
					strQuery1 = $"{strQuery1}AND (C1.CompId > 0) "; 
					strQuery1 = $"{strQuery1}AND (C1.ContactId > 0) "; 
					 
					//--------------------------------------- 
					// Select Account Rep Type 
					 
					if (strAcctRep != "" && strAcctRep != "NO REP SELECTED")
					{
						strQuery1 = $"{strQuery1}AND (C1.AcctRep = '{strAcctRep}') ";
					} 
					 
					strQuery1 = $"{strQuery1}AND (EXISTS (SELECT NULL FROM {strTempTable} AS C2 WITH (NOLOCK) "; 
					strQuery1 = $"{strQuery1}             WHERE (C2.JournID = 0) "; 
					strQuery1 = $"{strQuery1}             AND (C2.CompId <> C1.CompId) "; 
					strQuery1 = $"{strQuery1}             AND (C2.ContactId <> C1.ContactId) "; 
					strQuery1 = $"{strQuery1}             AND (C2.ContactId > 0) "; 
					strQuery1 = $"{strQuery1}             AND (C2.PhoneNbrSearch = C1.PhoneNbrSearch) "; 
					 
					//                                    -- And NOT Related 
					strQuery1 = $"{strQuery1}             AND (NOT EXISTS (SELECT NULL FROM Contact_Reference AS CTR2 WITH (NOLOCK) "; 
					strQuery1 = $"{strQuery1}                              WHERE (CTR2.cr_journ_id = 0) "; 
					strQuery1 = $"{strQuery1}                              AND ( "; 
					strQuery1 = $"{strQuery1}                                     (CTR2.cr_contact_id = C1.ContactId OR CTR2.cr_contact_rel_id = C1.ContactId) "; 
					strQuery1 = $"{strQuery1}                                  ) "; 
					strQuery1 = $"{strQuery1}                             ) "; 
					strQuery1 = $"{strQuery1}                 ) "; 
					strQuery1 = $"{strQuery1}             ) "; 
					strQuery1 = $"{strQuery1}     ) "; 
					strQuery1 = $"{strQuery1}ORDER BY Company, Contact, PhoneNbrSearch "; 
					 
					break;
				case "Contact Name" : 
					 
					lblFindDupsRecords.Text = "Searching Records (Contact Name)"; 
					 
					strQuery1 = $"{strQuery1}C1.CompIdString, "; 
					strQuery1 = $"{strQuery1}C1.ContactId, "; 
					strQuery1 = $"{strQuery1}C1.Contact, "; 
					strQuery1 = $"{strQuery1}C1.ContactSearch, "; 
					strQuery1 = $"{strQuery1}C1.EMailAddress, "; 
					strQuery1 = $"{strQuery1}C1.EMailAddressSearch, "; 
					strQuery1 = $"{strQuery1}C1.PhoneType, "; 
					strQuery1 = $"{strQuery1}C1.PhoneNbr, "; 
					strQuery1 = $"{strQuery1}C1.PhoneNbrSearch, "; 
					strQuery1 = $"{strQuery1}STUFF( "; 
					strQuery1 = $"{strQuery1}     (SELECT ';'+RTRIM(CAST(C2.ContactId AS VARCHAR(8))) "; 
					strQuery1 = $"{strQuery1}      FROM {strTempTable} AS C2 WITH (NOLOCK) "; 
					strQuery1 = $"{strQuery1}      WHERE (C2.JournID = 0) "; 
					strQuery1 = $"{strQuery1}      AND (C2.CompId <> C1.CompId) "; 
					strQuery1 = $"{strQuery1}      AND (C2.ContactId <> C1.ContactId) "; 
					strQuery1 = $"{strQuery1}      AND (C2.ContactId > 0 AND C1.ContactId > 0) "; 
					strQuery1 = $"{strQuery1}      AND (C2.ContactSearch = C1.ContactSearch) "; 
					 
					//                              -- And NOT Related 
					strQuery1 = $"{strQuery1}      AND (NOT EXISTS (SELECT NULL FROM Contact_Reference AS CTR2 WITH (NOLOCK) "; 
					strQuery1 = $"{strQuery1}                       WHERE (CTR2.cr_journ_id = 0) "; 
					strQuery1 = $"{strQuery1}                       AND ( "; 
					strQuery1 = $"{strQuery1}                              (CTR2.cr_contact_id = C1.ContactId OR CTR2.cr_contact_rel_id = C1.ContactId) "; 
					strQuery1 = $"{strQuery1}                           ) "; 
					strQuery1 = $"{strQuery1}                      ) "; 
					strQuery1 = $"{strQuery1}          ) "; 
					strQuery1 = $"{strQuery1}       FOR XML PATH('') "; 
					strQuery1 = $"{strQuery1}     ),1,1,'' "; 
					strQuery1 = $"{strQuery1}     ) As ContactIdString "; 
					 
					strQuery1 = $"{strQuery1}FROM {strTempTable} AS C1 WITH (NOLOCK) "; 
					strQuery1 = $"{strQuery1}WHERE (C1.JournId = 0) "; 
					strQuery1 = $"{strQuery1}AND (C1.CompId > 0) "; 
					 
					//--------------------------------------- 
					// Select Account Rep Type 
					 
					if (strAcctRep != "" && strAcctRep != "NO REP SELECTED")
					{
						strQuery1 = $"{strQuery1}AND (C1.AcctRep = '{strAcctRep}') ";
					} 
					 
					strQuery1 = $"{strQuery1}AND (EXISTS (SELECT NULL FROM {strTempTable} AS C2 WITH (NOLOCK) "; 
					strQuery1 = $"{strQuery1}             WHERE (C2.JournID = 0) "; 
					strQuery1 = $"{strQuery1}             AND (C2.CompId <> C1.CompId) "; 
					strQuery1 = $"{strQuery1}             AND (C2.ContactId <> C1.ContactId) "; 
					strQuery1 = $"{strQuery1}             AND (C2.ContactId > 0) "; 
					strQuery1 = $"{strQuery1}             AND (C2.ContactSearch = C1.ContactSearch) "; 
					 
					//                                     -- And NOT Related 
					strQuery1 = $"{strQuery1}             AND (NOT EXISTS (SELECT NULL FROM Contact_Reference AS CTR2 WITH (NOLOCK) "; 
					strQuery1 = $"{strQuery1}                              WHERE (CTR2.cr_journ_id = 0) "; 
					strQuery1 = $"{strQuery1}                              AND ( "; 
					strQuery1 = $"{strQuery1}                                     (CTR2.cr_contact_id = C1.ContactId OR CTR2.cr_contact_rel_id = C1.ContactId) "; 
					strQuery1 = $"{strQuery1}                                  ) "; 
					strQuery1 = $"{strQuery1}                             ) "; 
					strQuery1 = $"{strQuery1}                 ) "; 
					strQuery1 = $"{strQuery1}             ) "; 
					strQuery1 = $"{strQuery1}     ) "; 
					 
					if (Convert.ToString(fgrdFindDups.Tag) != "")
					{
						strQuery1 = $"{strQuery1}ORDER BY {Convert.ToString(fgrdFindDups.Tag)}";
					}
					else
					{
						strQuery1 = $"{strQuery1}ORDER BY Company, ContactSearch ";
					} 
					 
					break;
			} // Case strReport

			return strQuery1;

		} // Create_Select_Query_Find_Duplicate_Company_Contact_Temp_Table

		private void Fill_Find_Duplicate_Callback_Grid()
		{

			DbConnection cntConn = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateConnection();
			string strConn = "";

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strInsert1 = "";
			string strDrop1 = "";

			string strAcctRep = "";
			string strAcctRepId = "";
			string strReport = "";

			int lCol1 = 0;
			int lRow1 = 0;

			int lTot1 = 0;
			int lCnt1 = 0;
			string strTempTable = "";
			int lCommandTimeOut = 0;

			string strErr = "";
			int lErr = 0;

			string strMsg = "";
			System.DateTime dtStartDate = DateTime.FromOADate(0);
			System.DateTime dtEndDate = DateTime.FromOADate(0);

			try
			{

				modCommon.Start_Activity_Monitor_Message("Callback Find Duplicate", ref strMsg, ref dtStartDate, ref dtEndDate);

				lRow1 = 0;
				lCol1 = 0;
				fgrdFindDups.Enabled = false;
				cmdFindDupsRefresh.Enabled = false;

				strAcctRep = cbo_account_id.Text.Substring(0, Math.Min(2, cbo_account_id.Text.Length)).ToUpper();
				strAcctRepId = cbo_account_id.Text.ToUpper();

				strReport = cmbFindDupReports.Text.Trim();

				if (strAcctRep != "ID" && strAcctRep != "RM" && (strAcctRep != ""))
				{

					if (strReport != "")
					{

						Fill_Find_Duplicate_Callback_Grid_Headers(strReport);

						lblFindDupsRecords.Text = "Creating Temporary Search Table";

						modAdminCommon.Record_Event("Monitor Activity", $"Find Duplicate Company - Selected AcctRep: {strAcctRepId}  Selected Report: {strReport}");
						// Record_Event "HB Usage", "Find Duplicate Company - Selected AcctRep: " & strAcctRepId & "  Selected Report: " & strReport

						//---------------------------------------------------------------
						// Need To Open A Client Side Connection For Temp Tables


						strConn = $"Provider=SQLNCLI10;" +
						          $"Data Source={frm_Main_Menu.DefInstance.txt_ip_address.Text};" +
						          $"Initial Catalog={frm_Main_Menu.DefInstance.txt_database_name.Text};" +
						          $"User Id={frm_Main_Menu.DefInstance.txt_db_login.Text};" +
						          $"Password={frm_Main_Menu.DefInstance.txt_db_password.Text};";

						lCommandTimeOut = UpgradeHelpers.DB.DbConnectionHelper.GetCommandTimeOut(modAdminCommon.LOCAL_ADO_DB);
						UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(cntConn, lCommandTimeOut * 4);

						cntConn.ConnectionString = strConn;
						//UPGRADE_ISSUE: (2064) ADODB.Connection property cntConn.CursorLocation was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						cntConn.setCursorLocation(CursorLocationEnum.adUseClient);
						//UPGRADE_TODO: (7010) The connection string must be verified to fullfill the .NET data provider connection string requirements. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-7010
						cntConn.Open();

						Create_Find_Duplicate_Company_Contact_Temp_Table(cntConn, ref strTempTable);

						if (strTempTable != "")
						{

							lblFindDupsRecords.Text = "Filling Temporary Search Table (Please Wait)";

							strInsert1 = Create_Insert_Into_Find_Duplicate_Company_Contact_Temp_Table(strReport, strTempTable);

							DbCommand TempCommand = null;
							TempCommand = cntConn.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
							TempCommand.CommandText = strInsert1;
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
							TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
							TempCommand.ExecuteNonQuery();

							lblFindDupsRecords.Text = "Searching Records";

							strQuery1 = Create_Select_Query_Find_Duplicate_Company_Contact_Temp_Table(strReport, strTempTable, strAcctRepId);

							rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
							rstRec1.Open(strQuery1, cntConn, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

							if (!rstRec1.BOF && !rstRec1.EOF)
							{

								lblFindDupsStop.Enabled = true;
								lblFindDupsStop.Visible = true;

								lTot1 = rstRec1.RecordCount;
								lCnt1 = 0;
								lRow1 = 0;

								fgrdFindDups.Redraw = false;

								do 
								{ // Loop Until rstRec1.EOF = True Or lblFindDupsStop.Enabled = False

									lCnt1++;
									lblFindDupsRecords.Text = $"Total Records Found: {StringsHelper.Format(lTot1, "00000#")}  Loading: {StringsHelper.Format(lCnt1, "00000#")}";

									lRow1++;
									fgrdFindDups.RowsCount = lRow1 + 1;
									fgrdFindDups.CurrentRowIndex = lRow1;

									lCol1 = -1;

									lCol1++;
									fgrdFindDups.CurrentColumnIndex = lCol1;
									fgrdFindDups[fgrdFindDups.CurrentRowIndex, fgrdFindDups.CurrentColumnIndex].Value = Convert.ToString(rstRec1["CompID"]);
									fgrdFindDups.CellAlignment = DataGridViewContentAlignment.MiddleRight;

									lCol1++;
									fgrdFindDups.CurrentColumnIndex = lCol1;
									fgrdFindDups[fgrdFindDups.CurrentRowIndex, fgrdFindDups.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["Company"])} ").Trim();
									fgrdFindDups.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

									lCol1++;
									fgrdFindDups.CurrentColumnIndex = lCol1;
									fgrdFindDups[fgrdFindDups.CurrentRowIndex, fgrdFindDups.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["Address1"])} ").Trim();
									fgrdFindDups.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

									lCol1++;
									fgrdFindDups.CurrentColumnIndex = lCol1;
									fgrdFindDups[fgrdFindDups.CurrentRowIndex, fgrdFindDups.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["CompIdString"])} ").Trim();
									fgrdFindDups.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

									lCol1++;
									fgrdFindDups.CurrentColumnIndex = lCol1;
									fgrdFindDups[fgrdFindDups.CurrentRowIndex, fgrdFindDups.CurrentColumnIndex].Value = StringsHelper.Format(rstRec1["NbrAircraft"], "#,##0");
									fgrdFindDups.CellAlignment = DataGridViewContentAlignment.MiddleRight;

									//-----------------------------------
									// Check To Display Contacts

									if (fgrdFindDups.ColumnsCount > 5)
									{

										lCol1++;
										fgrdFindDups.CurrentColumnIndex = lCol1;
										fgrdFindDups[fgrdFindDups.CurrentRowIndex, fgrdFindDups.CurrentColumnIndex].Value = Convert.ToString(rstRec1["ContactId"]);
										fgrdFindDups.CellAlignment = DataGridViewContentAlignment.MiddleRight;

										lCol1++;
										fgrdFindDups.CurrentColumnIndex = lCol1;
										fgrdFindDups[fgrdFindDups.CurrentRowIndex, fgrdFindDups.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["Contact"])} ").Trim();
										fgrdFindDups.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

										lCol1++;
										fgrdFindDups.CurrentColumnIndex = lCol1;
										fgrdFindDups[fgrdFindDups.CurrentRowIndex, fgrdFindDups.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["emailAddress"])} ").Trim();
										fgrdFindDups.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

										lCol1++;
										fgrdFindDups.CurrentColumnIndex = lCol1;
										fgrdFindDups[fgrdFindDups.CurrentRowIndex, fgrdFindDups.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["PhoneType"])} ").Trim();
										fgrdFindDups.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

										lCol1++;
										fgrdFindDups.CurrentColumnIndex = lCol1;
										fgrdFindDups[fgrdFindDups.CurrentRowIndex, fgrdFindDups.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["PhoneNbr"])} ").Trim();
										fgrdFindDups.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

										lCol1++;
										fgrdFindDups.CurrentColumnIndex = lCol1;
										fgrdFindDups[fgrdFindDups.CurrentRowIndex, fgrdFindDups.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["ContactIdString"])} ").Trim();
										fgrdFindDups.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

									} // If fgrdFindDups.Cols > 5 Then

									if (lRow1 == 25)
									{
										fgrdFindDups.Redraw = true;
										fgrdFindDups.Refresh();
										fgrdFindDups.Redraw = false;
									}

									rstRec1.MoveNext();
									Application.DoEvents();

								}
								while(!(rstRec1.EOF || !lblFindDupsStop.Enabled));

								if (lblFindDupsStop.Enabled)
								{
									lblFindDupsRecords.Text = $"Total Records Found: {StringsHelper.Format(lTot1, "00000#")}";
								}

								fgrdFindDups.Redraw = true;
								fgrdFindDups.Refresh();

							}
							else
							{
								fgrdFindDups.CurrentRowIndex = 1;
								fgrdFindDups.CurrentColumnIndex = 1;
								fgrdFindDups[fgrdFindDups.CurrentRowIndex, fgrdFindDups.CurrentColumnIndex].Value = "No Records Found";
								lblFindDupsRecords.Text = "No Records Found";
							} // If rstRec1.BOF = False And rstRec1.EOF = False Then

							rstRec1.Close();

							strDrop1 = $"DROP TABLE {strTempTable}";
							DbCommand TempCommand_2 = null;
							TempCommand_2 = cntConn.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
							TempCommand_2.CommandText = strDrop1;
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
							TempCommand_2.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
							TempCommand_2.ExecuteNonQuery();

							UpgradeHelpers.DB.TransactionManager.DeEnlist(cntConn);
							cntConn.Close();

							lblFindDupsStop.Enabled = false;
							lblFindDupsStop.Visible = false;

							strMsg = $"AcctRep: {cbo_account_id.Text}";
							strMsg = $"{strMsg} Report: {cmbFindDupReports.Text}";

							if (bLog)
							{

								modCommon.End_Activity_Monitor_Message("Callback Find Duplicate", ref strMsg, dtStartDate, ref dtEndDate, 0, 0, 0, 0, 0);

								frm_UserHistory.DefInstance.Refresh_User_History_Grids("Callback");

							}

						}
						else
						{
							MessageBox.Show("Unable To Create SQL Temp Table", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						} // If strTempTable <> "" Then

					}
					else
					{
						lblFindDupsRecords.Text = "Report Selection Can NOT Be Blank";
					} // If strReport <> "" Then

				}
				else
				{
					if (strAcctRepId != "")
					{
						lblFindDupsRecords.Text = "Can NOT Process Reports for AcctRep ID##, RM##";
					}
				} // If strAcctRep <> "ID" And strAcctRep <> "RM" And (strAcctRep <> "") Then

				fgrdFindDups.Enabled = true;
				cmdFindDupsRefresh.Enabled = true;

				rstRec1 = null;
				cntConn = null;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErr = Information.Err().Number;
				strErr = excep.Message;

				modAdminCommon.Record_Error("Callbacks (Find Dups)", $"Fill_Find_Duplicate_Callback_Grid_Error: {lErr.ToString()} - {strErr}");

				lblFindDupsRecords.Text = $"Error: {strErr.Substring(0, Math.Min(150, strErr.Length))}";
				cmdFindDupsRefresh.Enabled = true;
			}

		} // Fill_Find_Duplicate_Callback_Grid

		private void Fill_Find_Research_Reports_Grid_Headers(ADORecordSetHelper rstRec1, string strAcctRep, string report_name)
		{

			int lRow1 = 0;
			int lCol1 = 0;
			string strFieldName = "";

			if (!rstRec1.BOF && !rstRec1.EOF)
			{

				fgrdFindResearchReports.Clear();
				fgrdFindResearchReports.RowsCount = 2;
				fgrdFindResearchReports.ColumnsCount = rstRec1.FieldsMetadata.Count;

				lRow1 = 0;
				lCol1 = 0;

				fgrdFindResearchReports.CurrentRowIndex = lRow1;

				gCompIdCol = -1;
				gJournIdCol = -1;
				gContactIdCol = -1;
				gACIdCol = -1;
				gAModIdCol = -1;

				int tempForEndVar = rstRec1.FieldsMetadata.Count - 1;
				for (int lCnt1 = 0; lCnt1 <= tempForEndVar; lCnt1++)
				{

					lCol1 = lCnt1;

					strFieldName = rstRec1.GetField(lCnt1).FieldMetadata.ColumnName;

					fgrdFindResearchReports.CurrentColumnIndex = lCol1;
					fgrdFindResearchReports[fgrdFindResearchReports.CurrentRowIndex, fgrdFindResearchReports.CurrentColumnIndex].Value = strFieldName;
					fgrdFindResearchReports.SetColumnWidth(lCol1, 33);
					fgrdFindResearchReports.CellAlignment = DataGridViewContentAlignment.MiddleLeft;


					switch(strFieldName.ToUpper())
					{
						case "COMPID" : 
							gCompIdCol = lCol1; 
							fgrdFindResearchReports.SetColumnWidth(lCol1, 0); 
							 
							break;
						case "JOURNID" : 
							gJournIdCol = lCol1; 
							fgrdFindResearchReports.SetColumnWidth(lCol1, 0); 
							 
							break;
						case "CONTACTID" : 
							gContactIdCol = lCol1; 
							fgrdFindResearchReports.SetColumnWidth(lCol1, 0); 
							 
							break;
						case "ACID" : 
							gACIdCol = lCol1; 
							fgrdFindResearchReports.SetColumnWidth(lCol1, 0); 
							 
							break;
						case "AMODID" : 
							gAModIdCol = lCol1; 
							fgrdFindResearchReports.SetColumnWidth(lCol1, 0); 
							 
							break;
						case "ACCTREP" : 
							if (strAcctRep != "NO REP SELECTED")
							{
								fgrdFindResearchReports.SetColumnWidth(lCol1, 0);
							}
							else
							{
								fgrdFindResearchReports.SetColumnWidth(lCol1, 60);
							} 
							 
							break;
						case "USERNAME" : 
							if (strAcctRep != "NO REP SELECTED")
							{
								fgrdFindResearchReports.SetColumnWidth(lCol1, 0);
							}
							else
							{
								fgrdFindResearchReports.SetColumnWidth(lCol1, 117);
							} 
							 
							break;
						case "COMPANY" : case "OPERATOR" : case "OWNER" : case "COMPANYEMAILADDRESS" : case "CONTACT" : case "CONTACTNAME" : case "CONTACTEMAILADDRESS" : 
							fgrdFindResearchReports.SetColumnWidth(lCol1, 183); 
							 
							break;
						case "CITY" : 
							//fgrdFindResearchReports.ColWidth(lCol1) = 2250 
							fgrdFindResearchReports.SetColumnWidth(lCol1, 120); 
							 
							break;
						case "STATEABBREV" : 
							fgrdFindResearchReports[fgrdFindResearchReports.CurrentRowIndex, fgrdFindResearchReports.CurrentColumnIndex].Value = "State"; 
							fgrdFindResearchReports.SetColumnWidth(lCol1, 40); 
							 
							break;
						case "STATE" : 
							fgrdFindResearchReports.SetColumnWidth(lCol1, 42); 
							 
							break;
						case "COUNTRY" : case "CONTINENT" : case "BASECOUNTRY" : 
							fgrdFindResearchReports.SetColumnWidth(lCol1, 120); 
							 
							break;
						case "TOTAC" : case "TOTCNT" : case "TODAY" : case ">= TODAY" : case "< TODAY" : case "< 5 YEARS" : 
							fgrdFindResearchReports.SetColumnWidth(lCol1, 50); 
							 
							break;
						case "BTW TODAY- 90 DAYS" : case "BTW 90-180 DAYS" : case "BTW 180 DAYS-1 YEAR" : case "BTW 1-2 YEARS" : case "BTW 2-3 YEARS" : case "BTW 3-4 YEARS" : case "BTW 4-5 YEARS" : case "MODEL" : 
							fgrdFindResearchReports.SetColumnWidth(lCol1, 117); 
							 
							break;
						case "RELATIONSHIP" : case "CONTACTTYPE" : 
							fgrdFindResearchReports.SetColumnWidth(lCol1, 133); 
							 
							break;
						case "MAKE" : case "BUSINESSTYPE" : 
							fgrdFindResearchReports.SetColumnWidth(lCol1, 126); 
							 
							break;
						case "MAKETYPE" : case "YEARDLV" : case "YEARMFR" : case "DOCTYPE" : case "FEATURE1" : case "FEATURE2" : case "FEATURE3" : case "FEATURE4" : case "FEATURE5" : case "FEATURE6" : case "AFTT" : case "ENGTT1" : case "ENGTT2" : case "ENGTT3" : case "ENGTT4" : case "SMOH1" : case "SMOH2" : case "SMOH3" : case "SMOH4" : case "FREQUENCY" : case "EXPORTLIMIT" : 
							fgrdFindResearchReports.SetColumnWidth(lCol1, 67); 
							 
							break;
						case "SERNBR" : case "LAST_CONTACT" : case "LIFECYCLE" : case "LASTCONTACTDATE" : case "ENDDATE" : case "DOCENTRYDATE" : case "DOCDATE" : case "EXPDATE" : case "REGCHGFRMODATE" : case "REGCHGTODATE" : 
							fgrdFindResearchReports.SetColumnWidth(lCol1, 93); 
							 
							break;
						case "REGNBR" : 
							fgrdFindResearchReports.SetColumnWidth(lCol1, 77); 
							 
							break;
						case "JNIQLASTATTEMPTEDDATE" : case "JNIQLASTCOMPLETEDDATE" : 
							fgrdFindResearchReports.SetColumnWidth(lCol1, 123); 
							 
							break;
						case "ASKINGPRICE" : case "ASKING" : case "PRICE" : 
							fgrdFindResearchReports.SetColumnWidth(lCol1, 80); 
							 
							break;
						case "DOCTYPENAME" : case "DOCSUBJECT" : case "DOCDESCRIPTION" : case "REGCHGFROM" : case "REGCHGTO" : case "PREVIOUSCOMP" : case "FLIGHT_LOCATION" : 
							fgrdFindResearchReports.SetColumnWidth(lCol1, 167); 
							 
							break;
						case "ENGINES" : 
							fgrdFindResearchReports.SetColumnWidth(lCol1, 100); 
							 
							break;
						case "SUBID" : 
							fgrdFindResearchReports.SetColumnWidth(lCol1, 40); 
							 
							break;
						case "MKTFLAG" : case "DEMOFLAG" : case "BFLAG" : case "CFLAG" : case "HFLAG" : case "AFLAG" : case "SPIFLAG" : case "YFLAG" : case "TLEVEL" : case "SERCODE" : 
							fgrdFindResearchReports.SetColumnWidth(lCol1, 63); 
							 
							break;
						case "SERNAME" : case "SUBJECT" : case "DESCRIPTION" : case "INTERNALNOTE" : case "NOTE" : case "DESC" : case "JOURNALNOTE" : case "JOURNALDESC" : case "JOURNALSUBJECT" : 
							fgrdFindResearchReports.SetColumnWidth(lCol1, 200); 
							 
							break;
						case "AVG3MTHS" : case "MAX3MTHS" : case "TOT3MTHS" : 
							fgrdFindResearchReports.SetColumnWidth(lCol1, 57); 
							 
							break;
						case "TOT3MTHRECS" : case "TOT3MTHCOUNT" : case "ALLOWEXPORTFLAG" : 
							fgrdFindResearchReports.SetColumnWidth(lCol1, 83); 
							 
							break;
						case "PREVIOUSREP" : case "LAST_FLIGHT" : 
							fgrdFindResearchReports.SetColumnWidth(lCol1, 70); 
							 
							break;
						case "MAKEMODEL" : 
							fgrdFindResearchReports.SetColumnWidth(lCol1, 125); 
							 
							break;
					} // Case strFieldName



					if (report_name.Trim() == "Aircraft on Awaiting Docs with Flight Activity")
					{
						switch(strFieldName.ToUpper())
						{
							case "SERNBR" : case "REGNBR" : 
								fgrdFindResearchReports.SetColumnWidth(lCol1, 73); 
								 
								break;
							case "CITY" : case "COUNTRY" : 
								fgrdFindResearchReports.SetColumnWidth(lCol1, 83); 
								break;
						}

					}




				}

				fgrdFindResearchReports.FixedRows = 1;
				fgrdFindResearchReports.FixedColumns = 0;

				fgrdFindResearchReports.CurrentRowIndex = 1;

			} // If rstRec1.BOF = False And rstRec1.EOF = False Then

		} // Fill_Find_Research_Reports_Grid_Headers

		private void Insert_TimeZone_And_Product_Into_Query_If_Needed(ref string strQuery1)
		{


			string strTZQuery = ""; // TimeZone
			string strTRQuery = ""; // Type of Research
			string strStartDate = "";
			string strEndDate = "";

			string strAcctRep = cbo_account_id.Text.Substring(0, Math.Min(2, cbo_account_id.Text.Length)).ToUpper();
			string strAcctRepName = cbo_account_id.Text.ToUpper();

			bool bCompanyBasedQuery = false;
			bool bAircraftBasedQuery = false;
			bool bPriorityEventQuery = false;
			bool bUseAccountRep = false;

			if (strQuery1.IndexOf("-- Insert Company Type of Research") >= 0 || strQuery1.IndexOf("-- Company Based Search") >= 0)
			{
				bCompanyBasedQuery = true;
			}

			if (strQuery1.IndexOf("-- Insert Aircraft Type of Research") >= 0 || strQuery1.IndexOf("-- Aircraft Based Search") >= 0)
			{
				bAircraftBasedQuery = true;
			}

			if (strQuery1.IndexOf("-- Insert Priority Event Start End Date") >= 0)
			{

				bPriorityEventQuery = true;
				strStartDate = DateTime.Now.AddMonths(-1).ToString("MM/dd/yyyy");
				strEndDate = DateTime.Now.ToString("MM/dd/yyyy");

				if (txt_ListStartDate.Text != "" && txt_Callback_Date.Text != "")
				{
					if (Information.IsDate(txt_ListStartDate.Text))
					{
						strStartDate = DateTime.Parse(txt_ListStartDate.Text).ToString("MM/dd/yyyy");
					}
					if (Information.IsDate(txt_Callback_Date.Text))
					{
						strEndDate = DateTime.Parse(txt_Callback_Date.Text).ToString("MM/dd/yyyy");
					}
				}

				if (txt_ListStartDate.Text == "" && txt_Callback_Date.Text != "")
				{
					if (Information.IsDate(txt_Callback_Date.Text))
					{
						if (DateTime.Parse(txt_Callback_Date.Text) < DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")))
						{
							strStartDate = DateTime.Parse(txt_Callback_Date.Text).ToString("MM/dd/yyyy");
						}
					}
				}

			} // If InStr(1, strQuery1, "-- Insert Priority Event Start End Date") > 0 Then

			if (bCompanyBasedQuery)
			{

				//-----------------------------------------------------------------------------------

				strTZQuery = "";
				if (cbo_Timezones.Text != "All")
				{

					if (cbo_Timezones.Text == "International")
					{
						strTZQuery = "AND ((C1.comp_timezone IS NULL) OR (C1.comp_timezone = '')) ";
					}
					else
					{
						strTZQuery = $"AND (C1.comp_timezone = '{cbo_Timezones.Text}') ";
					}

					strQuery1 = StringsHelper.Replace(strQuery1, "-- Insert Company TimeZone", strTZQuery, 1, -1, CompareMethod.Binary);

				} // If cbo_Timezones.Text <> "All" Then

				//----------------------------------------------------------------------------------

				strTRQuery = "";


				switch(cmbProductType.Text.Substring(0, Math.Min(1, cmbProductType.Text.Length)))
				{
					case "A" :  // Business and Helicopters 
						strTRQuery = $"{strTRQuery}AND (C1.comp_product_business_flag = 'Y') "; 
						strTRQuery = $"{strTRQuery}AND (C1.comp_product_helicopter_flag = 'Y') "; 
						strTRQuery = $"{strTRQuery}AND (C1.comp_product_commercial_flag = 'N')"; 
						 
						break;
					case "B" :  // Business Only 
						strTRQuery = $"{strTRQuery}AND (C1.comp_product_business_flag = 'Y') "; 
						strTRQuery = $"{strTRQuery}AND (C1.comp_product_helicopter_flag = 'N') "; 
						strTRQuery = $"{strTRQuery}AND (C1.comp_product_commercial_flag = 'N')"; 
						 
						break;
					case "H" :  // Helicopter Only 
						strTRQuery = $"{strTRQuery}AND (C1.comp_product_business_flag = 'N') "; 
						strTRQuery = $"{strTRQuery}AND (C1.comp_product_helicopter_flag = 'Y') "; 
						strTRQuery = $"{strTRQuery}AND (C1.comp_product_commercial_flag = 'N')"; 
						 
						break;
					case "C" :  // Commerical Only 
						strTRQuery = $"{strTRQuery}AND (C1.comp_product_business_flag = 'N') "; 
						strTRQuery = $"{strTRQuery}AND (C1.comp_product_helicopter_flag = 'N') "; 
						strTRQuery = $"{strTRQuery}AND (C1.comp_product_commercial_flag = 'Y')"; 
						 
						// 11/07/2014 - By David D. Cruger 
						// Added Per Jackie 
						 
						break;
					case "Q" :  // JNiQ Eligible 
						 
						strTRQuery = $"{strTRQuery}{modCommon.Return_JNiQ_Eligible_Query(strAcctRep, strTRQuery)}"; 
						 
						break;
					case "N" :  // Non-JNiQ Eligible 
						 
						strTRQuery = $"{strTRQuery}{modCommon.Return_Non_JNiQ_Eligible_Query()}"; 
						 
						break;
					case "P" :  // AirBP 
						 
						strTRQuery = $"{strTRQuery}AND (C1.comp_product_airbp_flag = 'Y')"; 
						 
						break;
					case "L" :  // ALL 
						 
						break;
				} // Case left(cmbProductType.Text, 1)

				if (strQuery1.IndexOf("-- Insert Company Type of Research") >= 0)
				{
					strQuery1 = StringsHelper.Replace(strQuery1, "-- Insert Company Type of Research", strTRQuery, 1, -1, CompareMethod.Binary);
				}
				if (strQuery1.IndexOf("-- Company Based Search") >= 0)
				{
					strQuery1 = StringsHelper.Replace(strQuery1, "-- Company Based Search", strTRQuery, 1, -1, CompareMethod.Binary);
				}

			} // If bCompanyBasedQuery = True Then

			//---------------------------------------------------------------------------------------------
			//---------------------------------------------------------------------------------------------

			if (bAircraftBasedQuery)
			{

				strTRQuery = "";


				switch(cmbProductType.Text.Substring(0, Math.Min(1, cmbProductType.Text.Length)))
				{
					case "A" :  // - Helicopters and Business Aircraft 
						strTRQuery = $"{strTRQuery}AND (A1.ac_product_business_flag = 'Y' OR A1.ac_product_helicopter_flag = 'Y') "; 
						 
						break;
					case "B" :  // - Business Aircraft 
						strTRQuery = $"{strTRQuery}AND (A1.ac_product_business_flag = 'Y') "; 
						 
						break;
					case "C" :  // - Commercial 
						strTRQuery = $"{strTRQuery}AND (A1.ac_product_commercial_flag = 'Y') "; 
						 
						break;
					case "H" :  // - Helicopters 
						strTRQuery = $"{strTRQuery}AND (A1.ac_product_helicopter_flag = 'Y') "; 
						 
						break;
					case "L" :  // - All 
						 
						break;
					case "P" :  // - AirBP 
						strTRQuery = $"{strTRQuery}AND (A1.ac_product_airbp_flag = 'Y') "; 
						 
						break;
				} // strSelect

				if (strQuery1.IndexOf("-- Insert Aircraft Type of Research") >= 0)
				{
					strQuery1 = StringsHelper.Replace(strQuery1, "-- Insert Aircraft Type of Research", strTRQuery, 1, -1, CompareMethod.Binary);
				}

				if (strQuery1.IndexOf("-- Aircraft Based Search") >= 0)
				{
					strQuery1 = StringsHelper.Replace(strQuery1, "-- Aircraft Based Search", strTRQuery, 1, -1, CompareMethod.Binary);
				}

			} // If bAircraftBasedQuery = True Then

			if (bPriorityEventQuery)
			{

				strTRQuery = $"AND (PE1.priorev_entry_date BETWEEN '{strStartDate}' AND '{strEndDate}') ";

				if (strAcctRepName != "NO REP SELECTED")
				{
					strTRQuery = $"{strTRQuery}AND  C1.comp_account_id  {make_account_rep_answer_string()}";
				}

				strQuery1 = StringsHelper.Replace(strQuery1, "-- Insert Priority Event Start End Date", strTRQuery, 1, -1, CompareMethod.Binary);

			} // If bPriorityEventQuery = True Then

			// added MSW - 11/4/21
			if (strQuery1.IndexOf("-- Insert Account Rep") >= 0)
			{
				bUseAccountRep = true;
			}


			if (bUseAccountRep)
			{
				if (strAcctRepName != "NO REP SELECTED")
				{
					strQuery1 = $"{strQuery1}AND  comp_account_id  {make_account_rep_answer_string()}";
				}
			}

		} // Insert_TimeZone_And_Product_Into_Query_If_Needed

		private void Fill_Find_Research_Reports_Grid()
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strInsert1 = "";
			string strDrop1 = "";

			string strAcctRep = "";
			string strReport = "";

			int lCol1 = 0;
			int lRow1 = 0;

			int lTot1 = 0;
			int lCnt1 = 0;

			string strTempTable = "";
			int lCommandTimeOut = 0;

			string strErr = "";
			int lErr = 0;

			string strDesc = "";
			string strMsg = "";
			System.DateTime dtStartDate = DateTime.FromOADate(0);
			System.DateTime dtEndDate = DateTime.FromOADate(0);
			string strFieldName = "";
			string top_20_bus_jet_models = "";
			string top_20_turbo_prop_models = "";

			try
			{

				modCommon.Start_Activity_Monitor_Message($"Callback Find Research Reports - {cmbFindResearchReports.Text}", ref strMsg, ref dtStartDate, ref dtEndDate);

				lRow1 = 0;
				lCol1 = 0;

				fgrdFindResearchReports.Enabled = false;
				fgrdFindResearchReports.Clear();
				fgrdFindResearchReports.RowsCount = 2;
				fgrdFindResearchReports.ColumnsCount = 2;
				fgrdFindResearchReports.CurrentRowIndex = 1;
				fgrdFindResearchReports.CurrentColumnIndex = 1;

				strAcctRep = cbo_account_id.Text.ToUpper();

				strReport = cmbFindResearchReports.Text.Trim();

				if (!strAcctRep.StartsWith("ID", StringComparison.Ordinal) && !strAcctRep.StartsWith("RM", StringComparison.Ordinal) && (strAcctRep != ""))
				{

					if (strReport != "")
					{

						// Get Query String From SQL_Report
						strQuery1 = modCommon.DLookUp("sqlrep_query", "SQL_Report", $"(sqlrep_title = '{strReport}')");

						if (strQuery1.IndexOf("XX_YY_ZZ") >= 0)
						{
							top_20_bus_jet_models = modCommon.DLookUp_Top("ac_amod_id", "EVO_LIVE.jetnet_ra.dbo.Subscription_Install_Log with (NOLOCK)   inner join aircraft with (NOLOCK) on ac_journ_id = 0 and ac_id = subislog_ac_id inner join aircraft_model with (NOLOCK) on ac_amod_id= amod_id and ac_product_business_flag = 'Y' and amod_airframe_type_code = 'F'  AND amod_customer_flag = 'Y'  AND amod_type_code in ('J')", 20, "subislog_ac_id = ac_id and subislog_date > getdate() - 120 and ac_amod_id > 0 group by ac_amod_id order by count(*) desc");
							top_20_turbo_prop_models = modCommon.DLookUp_Top("ac_amod_id", "EVO_LIVE.jetnet_ra.dbo.Subscription_Install_Log with (NOLOCK)   inner join aircraft with (NOLOCK) on ac_journ_id = 0 and ac_id = subislog_ac_id inner join aircraft_model with (NOLOCK) on ac_amod_id= amod_id and ac_product_business_flag = 'Y' and amod_airframe_type_code = 'F'  AND amod_customer_flag = 'Y'  AND amod_type_code in ('T')", 20, "subislog_ac_id = ac_id and subislog_date > getdate() - 120 and ac_amod_id > 0 group by ac_amod_id order by count(*) desc");

							strQuery1 = StringsHelper.Replace(strQuery1, "XX_YY_ZZ", $"{top_20_bus_jet_models},{top_20_turbo_prop_models}", 1, -1, CompareMethod.Binary);

							if (Convert.ToString(cmdResearchReportsExport.Tag) == "2")
							{
								strQuery1 = StringsHelper.Replace(strQuery1, "top 500", "", 1, -1, CompareMethod.Binary);
							}

							cmdResearchReportsExport.Tag = "1";
						}
						else
						{
							cmdResearchReportsExport.PerformClick();
						}



						if (strQuery1 != "")
						{

							//Record_Event "HB Usage", "Research Report - " & strReport & " Selected AcctRep: " & strAcctRep
							modAdminCommon.Record_Event("Monitor Activity", $"Research Report - {strReport} Selected AcctRep: {strAcctRep}");

							Insert_TimeZone_And_Product_Into_Query_If_Needed(ref strQuery1);

							strDesc = modCommon.DLookUp("sqlrep_description", "SQL_Report", $"(sqlrep_title = '{strReport}')");

							//adding in as a specific replace for Aircraft on Awaiting Docs with Flight Activity - report 260
							if (strAcctRep.Trim() != "" && strAcctRep.Trim() != "All" && strQuery1.Trim().IndexOf("ZZZ_REP") >= 0)
							{
								strQuery1 = StringsHelper.Replace(strQuery1, "ZZZ_REP", strAcctRep, 1, -1, CompareMethod.Binary);
							}

							// 11/30/2018 - By David D. Cruger
							// This statement REPLACE can NOT be done.  It messes up SUB-QUERIES
							//strQuery1 = Replace(strQuery1, "FROM ", ", comp_last_contact_date as LAST_CONTACT FROM ")

							cmbFindResearchReports.Tag = strDesc;

							lblFindResearchReports.Text = "Searching Records";

							lCommandTimeOut = UpgradeHelpers.DB.DbConnectionHelper.GetCommandTimeOut(modAdminCommon.LOCAL_ADO_DB);
							switch(cmbFindResearchReports.GetItemData(cmbFindResearchReports.SelectedIndex))
							{
								case 171 :  // Aircraft With A PEvent CREG Where RegNbr Was Removed 6mths Prior 
									UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(modAdminCommon.LOCAL_ADO_DB, lCommandTimeOut * 5); 
									break;
							}

							rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
							rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
							UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(modAdminCommon.LOCAL_ADO_DB, lCommandTimeOut);

							if (!rstRec1.BOF && !rstRec1.EOF)
							{

								if (strAcctRep != "NO REP SELECTED")
								{
									if (strQuery1.IndexOf("AcctRep") >= 0)
									{
										rstRec1.Filter = $"(AcctRep = '{strAcctRep}')";
									}
								}

								if (!rstRec1.BOF && !rstRec1.EOF)
								{

									rstRec1.MoveFirst();

									Fill_Find_Research_Reports_Grid_Headers(rstRec1, strAcctRep, strReport);

									lblFindResearchReportsStop.Enabled = true;
									lblFindResearchReportsStop.Visible = true;

									lTot1 = rstRec1.RecordCount;
									lCnt1 = 0;
									lRow1 = 0;

									fgrdFindResearchReports.Redraw = false;

									do 
									{ // Loop Until rstRec1.EOF = True Or lblFindResearchReportsStop.Enabled = False

										lCnt1++;
										lblFindResearchReports.Text = $"Total Records Found: {StringsHelper.Format(lTot1, "00000#")}  Loading: {StringsHelper.Format(lCnt1, "00000#")}";

										lRow1++;
										fgrdFindResearchReports.RowsCount = lRow1 + 1;
										fgrdFindResearchReports.CurrentRowIndex = lRow1;

										int tempForEndVar = rstRec1.FieldsMetadata.Count - 1;
										for (int lCnt2 = 0; lCnt2 <= tempForEndVar; lCnt2++)
										{

											lCol1 = lCnt2;

											strFieldName = rstRec1.GetField(lCnt2).FieldMetadata.ColumnName.ToUpper();

											fgrdFindResearchReports.CurrentColumnIndex = lCol1;
											fgrdFindResearchReports.CellAlignment = DataGridViewContentAlignment.MiddleLeft;


											switch(strFieldName)
											{
												case "COMPID" : 
													fgrdFindResearchReports[fgrdFindResearchReports.CurrentRowIndex, fgrdFindResearchReports.CurrentColumnIndex].Value = Convert.ToString(rstRec1["CompID"]); 
													 
													break;
												case "JOURNID" : 
													fgrdFindResearchReports[fgrdFindResearchReports.CurrentRowIndex, fgrdFindResearchReports.CurrentColumnIndex].Value = Convert.ToString(rstRec1["JournID"]); 
													 
													break;
												case "CONTACTID" : 
													fgrdFindResearchReports[fgrdFindResearchReports.CurrentRowIndex, fgrdFindResearchReports.CurrentColumnIndex].Value = Convert.ToString(rstRec1["ContactId"]); 
													 
													break;
												case "ACID" : 
													fgrdFindResearchReports[fgrdFindResearchReports.CurrentRowIndex, fgrdFindResearchReports.CurrentColumnIndex].Value = Convert.ToString(rstRec1["ACID"]); 
													 
													break;
												case "MAKETYPE" : case "YEARDLV" : case "YEARMFR" : 
													fgrdFindResearchReports.CellAlignment = DataGridViewContentAlignment.MiddleCenter; 
													fgrdFindResearchReports[fgrdFindResearchReports.CurrentRowIndex, fgrdFindResearchReports.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1[lCnt2])} ").Trim(); 
													 
													break;
												case "TOTAC" : 
													fgrdFindResearchReports[fgrdFindResearchReports.CurrentRowIndex, fgrdFindResearchReports.CurrentColumnIndex].Value = StringsHelper.Format(rstRec1["TotAC"], "#,##0"); 
													fgrdFindResearchReports.CellAlignment = DataGridViewContentAlignment.MiddleRight; 
													 
													break;
												case "STATEABBREV" : 
													fgrdFindResearchReports.CellAlignment = DataGridViewContentAlignment.MiddleCenter; 
													fgrdFindResearchReports[fgrdFindResearchReports.CurrentRowIndex, fgrdFindResearchReports.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["StateAbbrev"])} ").Trim(); 
													 
													break;
												case "FEATURE1" : case "FEATURE2" : case "FEATURE3" : case "FEATURE4" : case "FEATURE5" : case "FEATURE6" : 
													if (!Convert.IsDBNull(rstRec1[lCnt2]))
													{
														fgrdFindResearchReports[fgrdFindResearchReports.CurrentRowIndex, fgrdFindResearchReports.CurrentColumnIndex].Value = rstRec1[lCnt2];
														fgrdFindResearchReports.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
													} 
													 
													break;
												case "AFTT" : case "ENGTT1" : case "ENGTT2" : case "ENGTT3" : case "ENGTT4" : case "SMOH1" : case "SMOH2" : case "SMOH3" : case "SMOH4" : 
													if (!Convert.IsDBNull(rstRec1[lCnt2]))
													{
														fgrdFindResearchReports[fgrdFindResearchReports.CurrentRowIndex, fgrdFindResearchReports.CurrentColumnIndex].Value = StringsHelper.Format(rstRec1[lCnt2], "#,##0");
														fgrdFindResearchReports.CellAlignment = DataGridViewContentAlignment.MiddleRight;
													} 
													 
													break;
												case "ASKINGPRICE" : case "PRICE" : 
													if (!Convert.IsDBNull(rstRec1[lCnt2]))
													{
														//fgrdFindResearchReports.Text = "$" & Format(rstRec1.fields(lCnt2).Value, "#,##0")
														fgrdFindResearchReports[fgrdFindResearchReports.CurrentRowIndex, fgrdFindResearchReports.CurrentColumnIndex].Value = StringsHelper.Format(rstRec1[lCnt2], "#,##0");
														fgrdFindResearchReports.CellAlignment = DataGridViewContentAlignment.MiddleRight;
													} 
													break;
												case "LAST_FLIGHT" : case "PREVIOUSREP" : 
													fgrdFindResearchReports.CellAlignment = DataGridViewContentAlignment.MiddleRight; 
													if (!Convert.IsDBNull(rstRec1[lCnt2]))
													{
														fgrdFindResearchReports[fgrdFindResearchReports.CurrentRowIndex, fgrdFindResearchReports.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1[lCnt2])} ").Trim();
													} 
													break;
												default:
													if (!Convert.IsDBNull(rstRec1[lCnt2]))
													{
														fgrdFindResearchReports[fgrdFindResearchReports.CurrentRowIndex, fgrdFindResearchReports.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1[lCnt2])} ").Trim();
													} 
													 
													break;
											} // Case strFieldName

										}

										if (lRow1 == 25)
										{
											fgrdFindResearchReports.Redraw = true;
											fgrdFindResearchReports.Refresh();
											fgrdFindResearchReports.Redraw = false;
										}

										rstRec1.MoveNext();
										Application.DoEvents();

									}
									while(!(rstRec1.EOF || !lblFindResearchReportsStop.Enabled));

									if (lblFindResearchReportsStop.Enabled)
									{
										lblFindResearchReports.Text = $"Total Records Found: {StringsHelper.Format(lTot1, "00000#")}";
									}

									fgrdFindResearchReports.Redraw = true;
									fgrdFindResearchReports.Refresh();

								}
								else
								{
									fgrdFindResearchReports.SetColumnWidth(1, 167);
									fgrdFindResearchReports[fgrdFindResearchReports.CurrentRowIndex, fgrdFindResearchReports.CurrentColumnIndex].Value = "No Records Found";
									lblFindResearchReports.Text = "No Records Found";
								} // If rstRec1.BOF = False And rstRec1.EOF = False Then

							}
							else
							{
								fgrdFindResearchReports.SetColumnWidth(1, 167);
								fgrdFindResearchReports[fgrdFindResearchReports.CurrentRowIndex, fgrdFindResearchReports.CurrentColumnIndex].Value = "No Records Found";
								lblFindResearchReports.Text = "No Records Found";
							} // If rstRec1.BOF = False And rstRec1.EOF = False Then

							rstRec1.Filter = "";

							rstRec1.Close();

							lblFindResearchReportsStop.Enabled = false;
							lblFindResearchReportsStop.Visible = false;

							strMsg = $"AcctRep: {strAcctRep} Report: {strReport}";

							if (bLog)
							{

								modCommon.End_Activity_Monitor_Message("Callback Research Report", ref strMsg, dtStartDate, ref dtEndDate, 0, 0, 0, 0, 0);

								frm_UserHistory.DefInstance.Refresh_User_History_Grids("Callback");

							}

						}
						else
						{
							MessageBox.Show($"Unable To Find Report Query for {strReport}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
						} // If strQuery1 <> "" Then

					}
					else
					{
						lblFindResearchReports.Text = "Report Selection Can NOT Be Blank";
					} // If strReport <> "" Then

				}
				else
				{
					if (strAcctRep != "")
					{
						lblFindResearchReports.Text = "Can NOT Process Reports for AcctRep ID##, RM##";
					}
				} // If left(strAcctRep, 2) <> "ID" And left(strAcctRep, 2) <> "RM" And (strAcctRep <> "") Then

				fgrdFindResearchReports.Enabled = true;

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lErr = Information.Err().Number;
				strErr = excep.Message;

				modAdminCommon.Record_Error("Callbacks (Research Reports)", $"Fill_Find_Research_Reports_Grid_Error: {lErr.ToString()} - {strErr}");

				lblFindResearchReports.Text = $"Error: {strErr.Substring(0, Math.Min(150, strErr.Length))}";
			}

		} // Fill_Find_Research_Reports_Grid

		private void Fill_Find_AC_With_No_Base_Information_Grid_Headers()
		{

			int lRowl = 0;

			fgrdFindACNoBase.Clear();
			fgrdFindACNoBase.RowsCount = 2;
			fgrdFindACNoBase.ColumnsCount = 7;

			fgrdFindACNoBase.CurrentRowIndex = 0;

			int lCol1 = -1;

			lCol1++;
			fgrdFindACNoBase.CurrentColumnIndex = lCol1;
			fgrdFindACNoBase[fgrdFindACNoBase.CurrentRowIndex, fgrdFindACNoBase.CurrentColumnIndex].Value = "ACId";
			fgrdFindACNoBase.SetColumnWidth(lCol1, 67);
			fgrdFindACNoBase.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindACNoBase.CurrentColumnIndex = lCol1;
			fgrdFindACNoBase[fgrdFindACNoBase.CurrentRowIndex, fgrdFindACNoBase.CurrentColumnIndex].Value = "Make";
			fgrdFindACNoBase.SetColumnWidth(lCol1, 167);
			fgrdFindACNoBase.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindACNoBase.CurrentColumnIndex = lCol1;
			fgrdFindACNoBase[fgrdFindACNoBase.CurrentRowIndex, fgrdFindACNoBase.CurrentColumnIndex].Value = "Model";
			fgrdFindACNoBase.SetColumnWidth(lCol1, 167);
			fgrdFindACNoBase.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindACNoBase.CurrentColumnIndex = lCol1;
			fgrdFindACNoBase[fgrdFindACNoBase.CurrentRowIndex, fgrdFindACNoBase.CurrentColumnIndex].Value = "SerNbr";
			fgrdFindACNoBase.SetColumnWidth(lCol1, 100);
			fgrdFindACNoBase.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindACNoBase.CurrentColumnIndex = lCol1;
			fgrdFindACNoBase[fgrdFindACNoBase.CurrentRowIndex, fgrdFindACNoBase.CurrentColumnIndex].Value = "RegNbr";
			fgrdFindACNoBase.SetColumnWidth(lCol1, 100);
			fgrdFindACNoBase.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindACNoBase.CurrentColumnIndex = lCol1;
			fgrdFindACNoBase[fgrdFindACNoBase.CurrentRowIndex, fgrdFindACNoBase.CurrentColumnIndex].Value = "CompId";
			fgrdFindACNoBase.SetColumnWidth(lCol1, 67);
			fgrdFindACNoBase.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindACNoBase.CurrentColumnIndex = lCol1;
			fgrdFindACNoBase[fgrdFindACNoBase.CurrentRowIndex, fgrdFindACNoBase.CurrentColumnIndex].Value = "Primary Company";
			fgrdFindACNoBase.SetColumnWidth(lCol1, 233);
			fgrdFindACNoBase.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			fgrdFindACNoBase.FixedRows = 1;
			fgrdFindACNoBase.FixedColumns = 0;

			fgrdFindACNoBase.CurrentRowIndex = 1;

		} // Fill_Find_AC_With_No_Base_Information_Grid_Headers

		private void Fill_Find_AC_With_No_Base_Information_Grid()
		{

			DbConnection cntConn = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateConnection();
			string strConn = "";

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strSelect = "";
			string strAcctRep = "";
			string strAcctRepId = "";

			int lCol1 = 0;
			int lRow1 = 0;

			int lTot1 = 0;
			int lCnt1 = 0;
			int lCommandTimeOut = 0;

			string strMsg = "";
			System.DateTime dtStartDate = DateTime.FromOADate(0);
			System.DateTime dtEndDate = DateTime.FromOADate(0);

			try
			{

				modCommon.Start_Activity_Monitor_Message("Callback AC No Base", ref strMsg, ref dtStartDate, ref dtEndDate);

				lRow1 = 0;
				lCol1 = 0;
				fgrdFindACNoBase.Enabled = false;
				cmdFindACNoBaseRefresh.Enabled = false;

				strAcctRep = cbo_account_id.Text.Substring(0, Math.Min(2, cbo_account_id.Text.Length)).ToUpper();
				strAcctRepId = cbo_account_id.Text.ToUpper();

				strSelect = cmbProductType.Text.Substring(0, Math.Min(1, cmbProductType.Text.Length));

				if (strAcctRep != "ID" && strAcctRep != "RM" && (strAcctRep != ""))
				{

					Fill_Find_AC_With_No_Base_Information_Grid_Headers();

					strQuery1 = "SELECT DISTINCT ac_id AS ACId, ";
					strQuery1 = $"{strQuery1}amod_make_name As Make, ";
					strQuery1 = $"{strQuery1}amod_model_name As Model, ";
					strQuery1 = $"{strQuery1}ac_ser_no_full As SerNbr, ";
					strQuery1 = $"{strQuery1}ac_reg_no As RegNbr, ";
					strQuery1 = $"{strQuery1}C1.comp_id As CompId, ";
					strQuery1 = $"{strQuery1}C1.comp_name As Company ";

					strQuery1 = $"{strQuery1}FROM Aircraft_Model AS AM1 WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1}INNER JOIN Aircraft AS A1 WITH (NOLOCK) ON A1.ac_amod_id = AM1.amod_id ";
					strQuery1 = $"{strQuery1}INNER JOIN Aircraft_Reference AS AR1 WITH (NOLOCK) ON AR1.cref_ac_id = A1.ac_id AND AR1.cref_journ_id = A1.ac_journ_id ";
					strQuery1 = $"{strQuery1}INNER JOIN Company AS C1 WITH (NOLOCK) ON C1.comp_id = AR1.cref_comp_id AND C1.comp_journ_id = AR1.cref_journ_id ";
					strQuery1 = $"{strQuery1}WHERE (A1.ac_journ_id = 0) ";
					strQuery1 = $"{strQuery1}AND (AM1.amod_customer_flag = 'Y') ";
					strQuery1 = $"{strQuery1}AND (C1.comp_active_flag = 'Y') ";
					strQuery1 = $"{strQuery1}AND (C1.comp_name <> 'Awaiting Documentation') ";
					strQuery1 = $"{strQuery1}AND (LEFT(C1.comp_account_id,2) <> 'ID') "; // Unidentified
					strQuery1 = $"{strQuery1}AND (C1.comp_account_id <> 'IDGM') "; // Governemnt Do Not Call
					strQuery1 = $"{strQuery1}AND (C1.comp_account_id <> 'AC19') "; // Not Sure But Jackie Says This Is Also Unidentified
					strQuery1 = $"{strQuery1}AND (AR1.cref_primary_poc_flag = 'Y') ";

					// 05/12/2017 - Per Jackie; Do NOT include Commercial or Fractional Aircraft
					strQuery1 = $"{strQuery1}AND (A1.ac_product_business_flag = 'Y' OR A1.ac_product_helicopter_flag = 'Y') ";
					strQuery1 = $"{strQuery1}AND (A1.ac_ownership_type <> 'F') ";

					//---------------------------------------
					// No AC Base Inform Unless Private

					strQuery1 = $"{strQuery1}AND (A1.ac_aport_id = 0 OR A1.ac_aport_id IS NULL) ";
					strQuery1 = $"{strQuery1}AND (A1.ac_aport_private <> 'Y') ";

					// addedMSW  - 8/4/2020
					strQuery1 = $"{strQuery1} AND (A1.ac_aport_iata_code is null or A1.ac_aport_iata_code = '') ";
					strQuery1 = $"{strQuery1} AND (A1.ac_aport_icao_code is null or A1.ac_aport_icao_code = '') ";
					strQuery1 = $"{strQuery1} and (A1.ac_aport_faaid_code is null or A1.ac_aport_faaid_code = '') ";
					//strQuery1 = strQuery1 & " and a1.ac_aport_name <> 'Transient' "
					strQuery1 = $"{strQuery1} and (a1.ac_aport_name is null or a1.ac_aport_name = '') "; // added MSW -  10/5/2020 - based on details from task

					//-----------------------------------------------
					// No Journal Note "Confirmed No Chief Pilot"

					strQuery1 = $"{strQuery1}AND (NOT EXISTS (SELECT NULL FROM Journal WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1}                 WHERE (journ_ac_id = A1.ac_id) ";
					strQuery1 = $"{strQuery1}                 AND (journ_date >= DateAdd(year,-1,GetDate())) ";
					strQuery1 = $"{strQuery1}                 AND (journ_subject LIKE '%Confirmed No Base%') ";
					strQuery1 = $"{strQuery1}                ) ";
					strQuery1 = $"{strQuery1}     ) ";

					//---------------------------------------
					// Select Account Rep Type

					if (strAcctRepId != "" && strAcctRepId != "NO REP SELECTED")
					{
						strQuery1 = $"{strQuery1}AND  C1.comp_account_id  {make_account_rep_answer_string()}";
					}

					//-------------------------------------



					// added MSW - 9/9/20
					if (cbo_Timezones.Text != "All")
					{
						if (cbo_Timezones.Text == "International")
						{
							strQuery1 = $"{strQuery1}AND ((C1.comp_timezone is NULL) or (comp_timezone=''))";
						}
						else
						{
							strQuery1 = $"{strQuery1}AND (C1.comp_timezone='{cbo_Timezones.Text}') ";
						}
					}




					// Select Aircraft Type


					switch(strSelect)
					{
						case "A" :  // - Helicopters and Business Aircraft 
							strQuery1 = $"{strQuery1}AND ( "; 
							strQuery1 = $"{strQuery1}        (AM1.amod_airframe_type_code = 'F' "; 
							strQuery1 = $"{strQuery1}         AND AM1.amod_product_business_flag = 'Y' "; 
							strQuery1 = $"{strQuery1}         AND A1.ac_product_business_flag = 'Y' "; 
							strQuery1 = $"{strQuery1}        ) "; 
							strQuery1 = $"{strQuery1}     OR (AM1.amod_airframe_type_code = 'R' "; 
							strQuery1 = $"{strQuery1}         AND AM1.amod_product_helicopter_flag = 'Y' "; 
							strQuery1 = $"{strQuery1}         AND A1.ac_product_helicopter_flag = 'Y' "; 
							strQuery1 = $"{strQuery1}        ) "; 
							strQuery1 = $"{strQuery1}    ) "; 
							 
							break;
						case "B" :  // - Business Aircraft 
							strQuery1 = $"{strQuery1}AND (AM1.amod_airframe_type_code = 'F') "; 
							strQuery1 = $"{strQuery1}AND (AM1.amod_product_business_flag = 'Y') "; 
							strQuery1 = $"{strQuery1}AND (A1.ac_product_business_flag = 'Y') "; 
							 
							break;
						case "C" :  // - Commercial 
							strQuery1 = $"{strQuery1}AND (AM1.amod_airframe_type_code = 'F') "; 
							strQuery1 = $"{strQuery1}AND (AM1.amod_product_commercial_flag = 'Y') "; 
							strQuery1 = $"{strQuery1}AND (A1.ac_product_commercial_flag = 'Y') "; 
							 
							break;
						case "H" :  // - Helicopters 
							strQuery1 = $"{strQuery1}AND (AM1.amod_airframe_type_code = 'R') "; 
							strQuery1 = $"{strQuery1}AND (AM1.amod_product_helicopter_flag = 'Y') "; 
							strQuery1 = $"{strQuery1}AND (A1.ac_product_helicopter_flag = 'Y') "; 
							 
							break;
						case "L" :  // - All 
							 
							break;
						case "Q" :  // JNiQ Eligible 
							 
							strQuery1 = $"{strQuery1}{modCommon.Return_JNiQ_Eligible_Query(strAcctRepId, strQuery1)}"; 
							 
							break;
						case "N" :  // Non-JNiQ Eligible 
							 
							strQuery1 = $"{strQuery1}{modCommon.Return_Non_JNiQ_Eligible_Query()}"; 
							 
							break;
						case "P" :  // - AirBP 
							 
							strQuery1 = $"{strQuery1}AND (A1.ac_product_airbp_flag = 'Y') "; 
							 
							break;
					} // strSelect

					if (chk_action_list[chkACNoBaseExcludeReassigns].CheckState == CheckState.Checked)
					{
						strQuery1 = $"{strQuery1} and not exists (SELECT j2.journ_id FROM Journal j2 WITH(NOLOCK) WHERE j2.journ_ac_id =  a1.ac_id AND j2.journ_subcategory_code = 'AA') ";
					}

					// If chk_action_list(9).Value = vbChecked Then
					//    strQuery1 = strQuery1 & " and  "
					//' End If

					strQuery1 = $"{strQuery1}ORDER BY Make, Model, SerNbr ";

					fgrdFindACNoBase.Tag = "Make, Model, SerNbr"; // Save Sort Order

					modAdminCommon.Record_Event("Monitor Activity", $"AC No Base Info - Selected AcctRep: {strAcctRepId}");
					// Record_Event "HB Usage", "AC No Base Info - Selected AcctRep: " & strAcctRepId

					lblFindACNoBaseRecords.Text = "Searching Records";

					lCommandTimeOut = UpgradeHelpers.DB.DbConnectionHelper.GetCommandTimeOut(modAdminCommon.LOCAL_ADO_DB);
					UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(modAdminCommon.LOCAL_ADO_DB, lCommandTimeOut * 4);

					rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						lblFindACNoBaseStop.Enabled = true;
						lblFindACNoBaseStop.Visible = true;

						lTot1 = rstRec1.RecordCount;
						lCnt1 = 0;
						lRow1 = 0;

						fgrdFindACNoBase.Redraw = false;

						do 
						{ // Loop Until rstRec1.EOF = True Or lblFindACNoBaseStop.Enabled = False

							lCnt1++;
							lblFindACNoBaseRecords.Text = $"Total Records Found: {StringsHelper.Format(lTot1, "00000#")}  Loading: {StringsHelper.Format(lCnt1, "00000#")}";

							lRow1++;
							fgrdFindACNoBase.RowsCount = lRow1 + 1;
							fgrdFindACNoBase.CurrentRowIndex = lRow1;

							lCol1 = -1;

							lCol1++;
							fgrdFindACNoBase.CurrentColumnIndex = lCol1;
							fgrdFindACNoBase[fgrdFindACNoBase.CurrentRowIndex, fgrdFindACNoBase.CurrentColumnIndex].Value = Convert.ToString(rstRec1["ACID"]);
							fgrdFindACNoBase.CellAlignment = DataGridViewContentAlignment.MiddleRight;

							lCol1++;
							fgrdFindACNoBase.CurrentColumnIndex = lCol1;
							fgrdFindACNoBase[fgrdFindACNoBase.CurrentRowIndex, fgrdFindACNoBase.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["make"])} ").Trim();
							fgrdFindACNoBase.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

							lCol1++;
							fgrdFindACNoBase.CurrentColumnIndex = lCol1;
							fgrdFindACNoBase[fgrdFindACNoBase.CurrentRowIndex, fgrdFindACNoBase.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["model"])} ").Trim();
							fgrdFindACNoBase.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

							lCol1++;
							fgrdFindACNoBase.CurrentColumnIndex = lCol1;
							fgrdFindACNoBase[fgrdFindACNoBase.CurrentRowIndex, fgrdFindACNoBase.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["SerNbr"])} ").Trim();
							fgrdFindACNoBase.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

							lCol1++;
							fgrdFindACNoBase.CurrentColumnIndex = lCol1;
							fgrdFindACNoBase[fgrdFindACNoBase.CurrentRowIndex, fgrdFindACNoBase.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["RegNbr"])} ").Trim();
							fgrdFindACNoBase.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

							lCol1++;
							fgrdFindACNoBase.CurrentColumnIndex = lCol1;
							fgrdFindACNoBase[fgrdFindACNoBase.CurrentRowIndex, fgrdFindACNoBase.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["CompID"])} ").Trim();
							fgrdFindACNoBase.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

							lCol1++;
							fgrdFindACNoBase.CurrentColumnIndex = lCol1;
							fgrdFindACNoBase[fgrdFindACNoBase.CurrentRowIndex, fgrdFindACNoBase.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["Company"])} ").Trim();
							fgrdFindACNoBase.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

							if (lRow1 == 25)
							{
								fgrdFindACNoBase.Redraw = true;
								fgrdFindACNoBase.Refresh();
								fgrdFindACNoBase.Redraw = false;
							}

							rstRec1.MoveNext();
							Application.DoEvents();

						}
						while(!(rstRec1.EOF || !lblFindACNoBaseStop.Enabled));

						if (lblFindDupsStop.Enabled)
						{
							lblFindACNoBaseRecords.Text = $"Total Records Found: {StringsHelper.Format(lTot1, "00000#")}";
						}

						fgrdFindACNoBase.Redraw = true;
						fgrdFindACNoBase.Refresh();
						fgrdFindACNoBase.Enabled = true;

					}
					else
					{
						fgrdFindACNoBase.CurrentRowIndex = 1;
						fgrdFindACNoBase.CurrentColumnIndex = 1;
						fgrdFindDups[fgrdFindDups.CurrentRowIndex, fgrdFindDups.CurrentColumnIndex].Value = "No Records Found";
						lblFindACNoBaseRecords.Text = "No Records Found";
					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

					UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(modAdminCommon.LOCAL_ADO_DB, lCommandTimeOut);

					strMsg = $"AcctRep: {cbo_account_id.Text}";
					strMsg = $"{strMsg} Product: {cmbProductType.Text}";

					if (bLog)
					{

						modCommon.End_Activity_Monitor_Message("Callback AC No Base", ref strMsg, dtStartDate, ref dtEndDate, 0, 0, 0, 0, 0);

						frm_UserHistory.DefInstance.Refresh_User_History_Grids("Callback");

					}

					lblFindACNoBaseStop.Enabled = false;
					lblFindACNoBaseStop.Visible = false;

				}
				else
				{
					if (strAcctRep != "")
					{
						lblFindACNoBaseRecords.Text = "Can NOT Process Reports for AcctRep ID##, RM##";
					}
				} // If strAcctRep <> "ID" And strAcctRep <> "RM" And (strAcctRep <> "") Then

				cmdFindACNoBaseRefresh.Enabled = true;
				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Record_Error("Callbacks (Find AC No Base)", $"Fill_Find_AC_With_No_Base_Information_Grid: {Information.Err().Number.ToString()} - {excep.Message}");
			}

		} // Fill_Find_AC_With_No_Base_Information_Grid

		private void Fill_Find_AC_With_No_Chief_Pilots_Grid_Headers()
		{

			int lRowl = 0;

			fgrdFindACNoCHP.Clear();
			fgrdFindACNoCHP.RowsCount = 2;
			fgrdFindACNoCHP.ColumnsCount = 8;

			fgrdFindACNoCHP.CurrentRowIndex = 0;

			int lCol1 = -1;

			lCol1++;
			fgrdFindACNoCHP.CurrentColumnIndex = lCol1;
			fgrdFindACNoCHP[fgrdFindACNoCHP.CurrentRowIndex, fgrdFindACNoCHP.CurrentColumnIndex].Value = "ACId";
			fgrdFindACNoCHP.SetColumnWidth(lCol1, 67);
			fgrdFindACNoCHP.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindACNoCHP.CurrentColumnIndex = lCol1;
			fgrdFindACNoCHP[fgrdFindACNoCHP.CurrentRowIndex, fgrdFindACNoCHP.CurrentColumnIndex].Value = "Make";
			fgrdFindACNoCHP.SetColumnWidth(lCol1, 167);
			fgrdFindACNoCHP.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindACNoCHP.CurrentColumnIndex = lCol1;
			fgrdFindACNoCHP[fgrdFindACNoCHP.CurrentRowIndex, fgrdFindACNoCHP.CurrentColumnIndex].Value = "Model";
			fgrdFindACNoCHP.SetColumnWidth(lCol1, 167);
			fgrdFindACNoCHP.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindACNoCHP.CurrentColumnIndex = lCol1;
			fgrdFindACNoCHP[fgrdFindACNoCHP.CurrentRowIndex, fgrdFindACNoCHP.CurrentColumnIndex].Value = "SerNbr";
			fgrdFindACNoCHP.SetColumnWidth(lCol1, 100);
			fgrdFindACNoCHP.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindACNoCHP.CurrentColumnIndex = lCol1;
			fgrdFindACNoCHP[fgrdFindACNoCHP.CurrentRowIndex, fgrdFindACNoCHP.CurrentColumnIndex].Value = "RegNbr";
			fgrdFindACNoCHP.SetColumnWidth(lCol1, 100);
			fgrdFindACNoCHP.CellAlignment = DataGridViewContentAlignment.MiddleLeft;


			lCol1++;
			fgrdFindACNoCHP.CurrentColumnIndex = lCol1;
			fgrdFindACNoCHP[fgrdFindACNoCHP.CurrentRowIndex, fgrdFindACNoCHP.CurrentColumnIndex].Value = "CompID";
			fgrdFindACNoCHP.SetColumnWidth(lCol1, 0);
			fgrdFindACNoCHP.CellAlignment = DataGridViewContentAlignment.MiddleLeft;


			lCol1++;
			fgrdFindACNoCHP.CurrentColumnIndex = lCol1;
			fgrdFindACNoCHP[fgrdFindACNoCHP.CurrentRowIndex, fgrdFindACNoCHP.CurrentColumnIndex].Value = "Company";
			fgrdFindACNoCHP.SetColumnWidth(lCol1, 100);
			fgrdFindACNoCHP.CellAlignment = DataGridViewContentAlignment.MiddleLeft;


			lCol1++;
			fgrdFindACNoCHP.CurrentColumnIndex = lCol1;
			fgrdFindACNoCHP[fgrdFindACNoCHP.CurrentRowIndex, fgrdFindACNoCHP.CurrentColumnIndex].Value = "LastContact";
			fgrdFindACNoCHP.SetColumnWidth(lCol1, 100);
			fgrdFindACNoCHP.CellAlignment = DataGridViewContentAlignment.MiddleLeft;


			fgrdFindACNoCHP.FixedRows = 1;
			fgrdFindACNoCHP.FixedColumns = 0;

			fgrdFindACNoCHP.CurrentRowIndex = 1;

		} // Fill_Find_AC_With_No_Chief_Pilots_Grid_Headers

		private void Fill_Find_AC_With_No_Chief_Pilots_Grid()
		{

			DbConnection cntConn = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateConnection();
			string strConn = "";

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strSelect = "";
			string strAcctRep = "";
			string strAcctRepId = "";

			int lCol1 = 0;
			int lRow1 = 0;

			int lTot1 = 0;
			int lCnt1 = 0;
			int lCommandTimeOut = 0;

			string strMsg = "";
			System.DateTime dtStartDate = DateTime.FromOADate(0);
			System.DateTime dtEndDate = DateTime.FromOADate(0);

			try
			{

				modCommon.Start_Activity_Monitor_Message("Callback AC wNo ChfPilot", ref strMsg, ref dtStartDate, ref dtEndDate);

				lRow1 = 0;
				lCol1 = 0;
				fgrdFindACNoCHP.Enabled = false;
				cmdFindACNoCHPRefresh.Enabled = false;

				strAcctRep = cbo_account_id.Text.Substring(0, Math.Min(2, cbo_account_id.Text.Length)).ToUpper();
				strAcctRepId = cbo_account_id.Text.ToUpper();
				strSelect = cmbProductType.Text.Substring(0, Math.Min(1, cmbProductType.Text.Length));

				if (strAcctRep != "ID" && strAcctRep != "RM" && (strAcctRep != ""))
				{

					Fill_Find_AC_With_No_Chief_Pilots_Grid_Headers();

					strQuery1 = "SELECT DISTINCT ac_id AS ACId, ";
					strQuery1 = $"{strQuery1}amod_make_name As Make, ";
					strQuery1 = $"{strQuery1}amod_model_name As Model, ";
					strQuery1 = $"{strQuery1}ac_ser_no_full As SerNbr, ";
					strQuery1 = $"{strQuery1}ac_reg_no As RegNbr, ";
					strQuery1 = $"{strQuery1} comp_name AS CompName, comp_id, ";
					strQuery1 = $"{strQuery1} comp_last_contact_date LastContact ";


					strQuery1 = $"{strQuery1}FROM Aircraft_Model AS AM1 WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1}INNER JOIN Aircraft AS A1 WITH (NOLOCK) ON A1.ac_amod_id = AM1.amod_id ";
					strQuery1 = $"{strQuery1}INNER JOIN Aircraft_Reference AS AR1 WITH (NOLOCK) ON AR1.cref_ac_id = A1.ac_id AND AR1.cref_journ_id = A1.ac_journ_id ";
					strQuery1 = $"{strQuery1}INNER JOIN Company AS C1 WITH (NOLOCK) ON C1.comp_id = AR1.cref_comp_id AND C1.comp_journ_id = AR1.cref_journ_id ";
					strQuery1 = $"{strQuery1}WHERE (A1.ac_journ_id = 0) ";
					strQuery1 = $"{strQuery1}AND (A1.ac_lifecycle_stage = 3) "; // 04/13/2016 - By David D. Cruger; Per Jackie
					strQuery1 = $"{strQuery1}AND (AM1.amod_customer_flag = 'Y') ";
					strQuery1 = $"{strQuery1}AND (C1.comp_active_flag = 'Y') ";
					strQuery1 = $"{strQuery1}AND (C1.comp_name <> 'Awaiting Documentation') ";
					strQuery1 = $"{strQuery1}AND (LEFT(C1.comp_account_id,2) <> 'ID') "; // Unidentified
					strQuery1 = $"{strQuery1}AND (C1.comp_account_id <> 'IDGM') "; // Governemnt Do Not Call
					strQuery1 = $"{strQuery1}AND (C1.comp_account_id <> 'AC19') "; // Not Sure But Jackie Says This Is Also Unidentified
					strQuery1 = $"{strQuery1}AND (AR1.cref_primary_poc_flag = 'Y') ";

					//-----------------------------------------------
					// No Chief Pilot Reference

					strQuery1 = $"{strQuery1}AND (NOT EXISTS (SELECT NULL FROM Aircraft_Reference AS AR2 WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1}                 WHERE (AR2.cref_ac_id = A1.ac_id) ";
					strQuery1 = $"{strQuery1}                 AND (AR2.cref_journ_id = A1.ac_journ_id)  ";
					strQuery1 = $"{strQuery1}                 AND (AR2.cref_contact_type = '44') "; // Chief Pilot
					strQuery1 = $"{strQuery1}                ) ";
					strQuery1 = $"{strQuery1}    ) ";

					//-----------------------------------------------
					// No Journal Note "Confirmed No Chief Pilot"

					strQuery1 = $"{strQuery1}     AND (NOT EXISTS (SELECT NULL FROM Journal AS J2 WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1}                      WHERE (J2.journ_ac_id = A1.ac_id) ";
					strQuery1 = $"{strQuery1}                      AND (J2.journ_date >= DateAdd(year,-1,GetDate())) ";
					strQuery1 = $"{strQuery1}                      AND (J2.journ_subject LIKE '%Confirmed No Chief Pilot%') ";
					strQuery1 = $"{strQuery1}                      ) ";
					strQuery1 = $"{strQuery1}         ) ";

					//-----------------------------------------------
					// Select Account Rep Type

					if (strAcctRep != "" && strAcctRep != "NO REP SELECTED")
					{
						strQuery1 = $"{strQuery1}AND  C1.comp_account_id  {make_account_rep_answer_string()}";
					}


					// added MSW - 9/9/20
					if (cbo_Timezones.Text != "All")
					{
						if (cbo_Timezones.Text == "International")
						{
							strQuery1 = $"{strQuery1}AND ((C1.comp_timezone is NULL) or (comp_timezone=''))";
						}
						else
						{
							strQuery1 = $"{strQuery1}AND (C1.comp_timezone='{cbo_Timezones.Text}') ";
						}
					}



					//-----------------------------------------------
					// Select Aircraft Type


					switch(strSelect)
					{
						case "A" :  // - Helicopters and Business Aircraft 
							strQuery1 = $"{strQuery1}AND ( "; 
							strQuery1 = $"{strQuery1}        (AM1.amod_airframe_type_code = 'F' "; 
							strQuery1 = $"{strQuery1}         AND AM1.amod_product_business_flag = 'Y' "; 
							strQuery1 = $"{strQuery1}         AND A1.ac_product_business_flag = 'Y' "; 
							strQuery1 = $"{strQuery1}        ) "; 
							strQuery1 = $"{strQuery1}     OR (AM1.amod_airframe_type_code = 'R' "; 
							strQuery1 = $"{strQuery1}         AND AM1.amod_product_helicopter_flag = 'Y' "; 
							strQuery1 = $"{strQuery1}         AND A1.ac_product_helicopter_flag = 'Y' "; 
							strQuery1 = $"{strQuery1}        ) "; 
							strQuery1 = $"{strQuery1}    ) "; 
							 
							break;
						case "B" :  // - Business Aircraft 
							strQuery1 = $"{strQuery1}AND (AM1.amod_airframe_type_code = 'F') "; 
							strQuery1 = $"{strQuery1}AND (AM1.amod_product_business_flag = 'Y') "; 
							strQuery1 = $"{strQuery1}AND (A1.ac_product_business_flag = 'Y') "; 
							 
							break;
						case "C" :  // - Commercial 
							strQuery1 = $"{strQuery1}AND (AM1.amod_airframe_type_code = 'F') "; 
							strQuery1 = $"{strQuery1}AND (AM1.amod_product_commercial_flag = 'Y') "; 
							strQuery1 = $"{strQuery1}AND (A1.ac_product_commercial_flag = 'Y') "; 
							 
							break;
						case "H" :  // - Helicopters 
							strQuery1 = $"{strQuery1}AND (AM1.amod_airframe_type_code = 'R') "; 
							strQuery1 = $"{strQuery1}AND (AM1.amod_product_helicopter_flag = 'Y') "; 
							strQuery1 = $"{strQuery1}AND (A1.ac_product_helicopter_flag = 'Y') "; 
							 
							break;
						case "L" :  // - All 
							 
							break;
						case "Q" :  // JNiQ Eligible 
							 
							strQuery1 = $"{strQuery1}{modCommon.Return_JNiQ_Eligible_Query(strAcctRepId, strQuery1)}"; 
							 
							break;
						case "N" :  // Non-JNiQ Eligible 
							 
							strQuery1 = $"{strQuery1}{modCommon.Return_Non_JNiQ_Eligible_Query()}"; 
							 
							break;
						case "P" :  // - AirBP 
							 
							strQuery1 = $"{strQuery1}AND (A1.ac_product_airbp_flag = 'Y') "; 
							 
							break;
					} // strSelect

					if (chk_action_list[chkACNoCPExcludeReassigns].CheckState == CheckState.Checked)
					{
						strQuery1 = $"{strQuery1} and not exists (SELECT j2.journ_id FROM Journal j2 WITH(NOLOCK) WHERE j2.journ_ac_id =  a1.ac_id AND j2.journ_subcategory_code = 'AA') ";
					}

					strQuery1 = $"{strQuery1}ORDER BY Make, Model, SerNbr ";

					fgrdFindACNoCHP.Tag = "Make, Model, SerNbr"; // Save Sort Order

					// Record_Event "HB Usage", "Aircraft With No Chief Pilot - AcctRep: " & strAcctRepId
					modAdminCommon.Record_Event("Monitor Activity", $"Aircraft With No Chief Pilot - AcctRep: {strAcctRepId}");

					lblFindACNoCHPRecords.Text = "Searching Records";

					rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
					rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!rstRec1.BOF && !rstRec1.EOF)
					{

						lblFindACNoCHPStop.Enabled = true;
						lblFindACNoCHPStop.Visible = true;

						lTot1 = rstRec1.RecordCount;
						lCnt1 = 0;
						lRow1 = 0;

						fgrdFindACNoCHP.Redraw = false;

						do 
						{ // Loop Until rstRec1.EOF = True Or lblFindACNoCHPStop.Enabled = False

							lCnt1++;
							lblFindACNoCHPRecords.Text = $"Total Records Found: {StringsHelper.Format(lTot1, "00000#")}  Loading: {StringsHelper.Format(lCnt1, "00000#")}";

							lRow1++;
							fgrdFindACNoCHP.RowsCount = lRow1 + 1;
							fgrdFindACNoCHP.CurrentRowIndex = lRow1;

							lCol1 = -1;

							lCol1++;
							fgrdFindACNoCHP.CurrentColumnIndex = lCol1;
							fgrdFindACNoCHP[fgrdFindACNoCHP.CurrentRowIndex, fgrdFindACNoCHP.CurrentColumnIndex].Value = Convert.ToString(rstRec1["ACID"]);
							fgrdFindACNoCHP.CellAlignment = DataGridViewContentAlignment.MiddleRight;

							lCol1++;
							fgrdFindACNoCHP.CurrentColumnIndex = lCol1;
							fgrdFindACNoCHP[fgrdFindACNoCHP.CurrentRowIndex, fgrdFindACNoCHP.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["make"])} ").Trim();
							fgrdFindACNoCHP.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

							lCol1++;
							fgrdFindACNoCHP.CurrentColumnIndex = lCol1;
							fgrdFindACNoCHP[fgrdFindACNoCHP.CurrentRowIndex, fgrdFindACNoCHP.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["model"])} ").Trim();
							fgrdFindACNoCHP.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

							lCol1++;
							fgrdFindACNoCHP.CurrentColumnIndex = lCol1;
							fgrdFindACNoCHP[fgrdFindACNoCHP.CurrentRowIndex, fgrdFindACNoCHP.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["SerNbr"])} ").Trim();
							fgrdFindACNoCHP.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

							lCol1++;
							fgrdFindACNoCHP.CurrentColumnIndex = lCol1;
							fgrdFindACNoCHP[fgrdFindACNoCHP.CurrentRowIndex, fgrdFindACNoCHP.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["RegNbr"])} ").Trim();
							fgrdFindACNoCHP.CellAlignment = DataGridViewContentAlignment.MiddleLeft;


							lCol1++;
							fgrdFindACNoCHP.CurrentColumnIndex = lCol1;
							fgrdFindACNoCHP[fgrdFindACNoCHP.CurrentRowIndex, fgrdFindACNoCHP.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["comp_id"])} ").Trim();
							fgrdFindACNoCHP.CellAlignment = DataGridViewContentAlignment.MiddleLeft;


							lCol1++;
							fgrdFindACNoCHP.CurrentColumnIndex = lCol1;
							fgrdFindACNoCHP[fgrdFindACNoCHP.CurrentRowIndex, fgrdFindACNoCHP.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["CompName"])} ").Trim();
							fgrdFindACNoCHP.CellAlignment = DataGridViewContentAlignment.MiddleLeft;


							lCol1++;
							fgrdFindACNoCHP.CurrentColumnIndex = lCol1;
							fgrdFindACNoCHP[fgrdFindACNoCHP.CurrentRowIndex, fgrdFindACNoCHP.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["LastContact"])} ").Trim();
							fgrdFindACNoCHP.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

							if (lRow1 == 25)
							{
								fgrdFindACNoCHP.Redraw = true;
								fgrdFindACNoCHP.Refresh();
								fgrdFindACNoCHP.Redraw = false;
							}

							rstRec1.MoveNext();
							Application.DoEvents();

						}
						while(!(rstRec1.EOF || !lblFindACNoCHPStop.Enabled));

						if (lblFindACNoCHPStop.Enabled)
						{
							lblFindACNoCHPRecords.Text = $"Total Records Found: {StringsHelper.Format(lTot1, "00000#")}";
						}

						fgrdFindACNoCHP.Redraw = true;
						fgrdFindACNoCHP.Refresh();
						fgrdFindACNoCHP.Enabled = true;

					}
					else
					{
						fgrdFindACNoCHP.CurrentRowIndex = 1;
						fgrdFindACNoCHP.CurrentColumnIndex = 1;
						fgrdFindACNoCHP[fgrdFindACNoCHP.CurrentRowIndex, fgrdFindACNoCHP.CurrentColumnIndex].Value = "No Records Found";
						lblFindACNoCHPRecords.Text = "No Records Found";
					} // If rstRec1.BOF = False And rstRec1.EOF = False Then

					rstRec1.Close();

					lblFindACNoCHPStop.Enabled = false;
					lblFindACNoCHPStop.Visible = false;

					strMsg = $"AcctRep: {cbo_account_id.Text}";
					strMsg = $"{strMsg} Product: {cmbProductType.Text}";

					if (bLog)
					{

						modCommon.End_Activity_Monitor_Message("Callback AC wNo ChfPilot", ref strMsg, dtStartDate, ref dtEndDate, 0, 0, 0, 0, 0);

						frm_UserHistory.DefInstance.Refresh_User_History_Grids("Callback");

					}

				}
				else
				{
					if (strAcctRepId != "")
					{
						lblFindACNoCHPRecords.Text = "Can NOT Process Reports for AcctRep ID##, RM##";
					}
				} // If strAcctRep <> "ID" And strAcctRep <> "RM" And (strAcctRep <> "") Then

				cmdFindACNoCHPRefresh.Enabled = true;
				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Record_Error("Callbacks (Find AC No Chief Pilot)", $"Fill_Find_AC_With_No_Chief_Pilots_Grid: {Information.Err().Number.ToString()} - {excep.Message}");
			}

		} // Fill_Find_AC_With_No_Chief_Pilots_Grid

		private void fgrdFindCustSubData_Click(Object eventSender, EventArgs eventArgs)
		{

			string strOrderBy = "";
			string temp_acrep = "";

			int lMouseRow = fgrdFindCustSubData.MouseRow;
			int lMouseCol = fgrdFindCustSubData.MouseCol;
			cmdCSDChangeAcctRep.Enabled = false;

			if (lMouseRow == 0)
			{ // Header Row

				//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
				// 0             1       2        3                   4          5        6     7        8     9      10      11      12       13         14       15,   16
				// Date Entered, CompId, Company, Country-State-City, ContactId, Contact, ACId, JournId, Make, Model, SerNbr, RegNbr, CompId2, CompName2, AcctRep, Note, Completed

				switch(lMouseCol)
				{
					case 0 : 
						strOrderBy = "DateEntered, Make, Model, SerNbr "; 
						break;
					case 1 : 
						strOrderBy = "CompId "; 
						break;
					case 2 : 
						strOrderBy = "CompName, Country, State, City "; 
						break;
					case 3 : 
						strOrderBy = "Country, State, City "; 
						break;
					case 5 : 
						strOrderBy = "Contact "; 
						break;
					case 8 : 
						strOrderBy = "Make, Model, SerNbr "; 
						break;
					case 9 : 
						strOrderBy = "Model, Make, SerNbr "; 
						break;
					case 10 : 
						strOrderBy = "SerNbr, Make, Model "; 
						break;
					case 11 : 
						strOrderBy = "RegNbr, SerNbr "; 
						break;
					case 12 : 
						strOrderBy = "CompId2 "; 
						break;
					case 13 : 
						strOrderBy = "CompName2 "; 
						break;
					case 14 : 
						strOrderBy = "AcctRep "; 
						break;
					case 15 : 
						strOrderBy = "Note "; 
						break;
				} // Case lMouseCol

				if (strOrderBy != Convert.ToString(fgrdFindCustSubData.Tag))
				{

					fgrdFindCustSubData.Tag = strOrderBy;
					fgrdFindCustSubData.CurrentColumnIndex = lMouseCol;

					switch(lMouseCol)
					{
						case 1 : case 4 : case 6 : case 7 : case 12 :  // CompId, ContactId, ACId, JournId, CompId2 
							//UPGRADE_WARNING: (2065) MSHierarchicalFlexGridLib.SortSettings property SortSettings.flexSortNumericAscending has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065 
							fgrdFindCustSubData.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortNumericAscending)); 
							break;
						default:
							fgrdFindCustSubData.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortStringAscending)); 
							break;
					} // Case lMouseCol

				} // If strOrderBy <> fgrdFindACNoBase.Tag Then

			}
			else
			{
				modCommon.Highlight_Grid_Row(fgrdFindCustSubData);
				cmbCustSubAcctRep.Text = Convert.ToString(fgrdFindCustSubData[lMouseRow, 14].Value);
				cmdCSDChangeAcctRep.Enabled = true;
			} // If lMouseRow = 0 Then ' Header Row

			// Check Completed Status
			if (Convert.ToString(fgrdFindCustSubData[lMouseRow, 16].Value) == "Submitted Data In Progress")
			{
				cmd_in_progress.Text = "Change to: No Longer In Process";
			}
			else
			{
				cmd_in_progress.Text = "Change To: In Progress";
			}

			cmd_in_progress.Visible = true;

		} // fgrdFindCustSubData_Click

		private void fgrdFindCustSubData_DoubleClick(Object eventSender, EventArgs eventArgs)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			int lMouseRow = 0;
			int lMouseCol = 0;
			string strOrderBy = "";
			System.DateTime dtDate = DateTime.FromOADate(0);
			int lSubISId = 0;

			frm_Company frmCompany = frm_Company.CreateInstance();
			string strText = "";

			try
			{

				lMouseRow = fgrdFindCustSubData.MouseRow;
				lMouseCol = fgrdFindCustSubData.MouseCol;

				if (lMouseRow > 0)
				{ // Header Row

					//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
					// 0             1       2        3                   4          5        6     7        8     9      10      11      12       13         14       15,   16,        17
					// Date Entered, CompId, Company, Country-State-City, ContactId, Contact, ACId, JournId, Make, Model, SerNbr, RegNbr, CompId2, CompName2, AcctRep, Note, Completed, Status


					switch(lMouseCol)
					{
						case 1 : case 2 : case 3 : case 4 : case 5 :  // CompId, CompName, Country, State, City, ContactId, Contact 
							 
							//--------------------------------------------------- 
							// Cleanup any Company Forms and Open A New One 
							 
							if (Convert.ToString(fgrdFindCustSubData[lMouseRow, 1].Value) != "")
							{

								modCommon.Unload_Form("frm_Company");
								//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
								//VB.Global.Load(frmCompany);
								frmCompany.Form_Initialize();
								frmCompany.StartForm = modGlobalVars.tStart_Form;
								frmCompany.Reference_CompanyID = Convert.ToInt32(Double.Parse(Convert.ToString(fgrdFindCustSubData[lMouseRow, 1].Value))); // CompId
								frmCompany.Reference_CompanyJID = Convert.ToInt32(Double.Parse(Convert.ToString(fgrdFindCustSubData[lMouseRow, 7].Value))); // JournId
								frmCompany.Show();
								//UPGRADE_WARNING: (2065) Form method frmCompany.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
								frmCompany.BringToFront();
								//UPGRADE_WARNING: (2065) Form event Form.Activated has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
								frmCompany.Form_Activated(null, new EventArgs());

							}  // If fgrdFindCustSubData.TextMatrix(lMouseRow, 1) <> "" Then 
							 
							break;
						case 6 : case 7 : case 8 : case 9 : case 10 : case 11 :  // ACId, JournId, Make, Model, SerNbr, RegNbr 
							 
							if (Convert.ToString(fgrdFindCustSubData[lMouseRow, 6].Value) != "")
							{

								modAdminCommon.gbl_Aircraft_ID = Convert.ToInt32(Double.Parse(Convert.ToString(fgrdFindCustSubData[lMouseRow, 6].Value))); // ACId
								modAdminCommon.gbl_Aircraft_Journal_ID = Convert.ToInt32(Double.Parse(Convert.ToString(fgrdFindCustSubData[lMouseRow, 7].Value))); // JournId

								frm_aircraft.DefInstance.Form_Initialize();
								frm_aircraft.DefInstance.StartForm = modGlobalVars.tStart_Form;
								frm_aircraft.DefInstance.Reference_Aircraft_ID = modAdminCommon.gbl_Aircraft_ID;
								frm_aircraft.DefInstance.Reference_Journal_ID = modAdminCommon.gbl_Aircraft_Journal_ID;
								frm_aircraft.DefInstance.Reference_Company_ID = 0;
								frm_aircraft.DefInstance.Show();
								//UPGRADE_WARNING: (2065) Form method frm_aircraft.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
								frm_aircraft.DefInstance.BringToFront();
								//UPGRADE_WARNING: (2065) Form event Form.Activated has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
								frm_aircraft.DefInstance.Form_Activated(frm_aircraft.DefInstance, new EventArgs());

							}  // If fgrdFindCustSubData.TextMatrix(lMouseRow, 6) <> "" Then 
							 
							break;
						case 12 : case 13 :  // CompId2, CompName2 
							 
							//--------------------------------------------------- 
							// Cleanup any Company Forms and Open A New One 
							 
							if (Convert.ToString(fgrdFindCustSubData[lMouseRow, 12].Value) != "" && Convert.ToString(fgrdFindCustSubData[lMouseRow, 12].Value) != "0")
							{

								modCommon.Unload_Form("frm_Company");
								//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
								//VB.Global.Load(frmCompany);
								frmCompany.Form_Initialize();
								frmCompany.StartForm = modGlobalVars.tStart_Form;
								frmCompany.Reference_CompanyID = Convert.ToInt32(Double.Parse(Convert.ToString(fgrdFindCustSubData[lMouseRow, 12].Value))); // CompId2
								frmCompany.Reference_CompanyJID = Convert.ToInt32(Double.Parse(Convert.ToString(fgrdFindCustSubData[lMouseRow, 7].Value))); // JournId
								frmCompany.Show();
								//UPGRADE_WARNING: (2065) Form method frmCompany.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
								frmCompany.BringToFront();
								//UPGRADE_WARNING: (2065) Form event Form.Activated has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
								frmCompany.Form_Activated(null, new EventArgs());

							}  // If fgrdFindCustSubData.TextMatrix(lMouseRow, 12) <> "" And fgrdFindCustSubData.TextMatrix(lMouseRow, 12) <> "0" Then 
							 
							break;
						case 15 :  // Note 
							 
							lSubISId = fgrdFindCustSubData.get_RowData(lMouseRow); 
							 
							strText = $"Date Entered: {Convert.ToString(fgrdFindCustSubData[lMouseRow, 0].Value)}{Environment.NewLine}{Environment.NewLine}"; 
							 
							strText = $"{strText}Company Submitted Information{Environment.NewLine}"; 
							strText = $"{strText}CompId: {Convert.ToString(fgrdFindCustSubData[lMouseRow, 1].Value)} - "; 
							strText = $"{strText}{Convert.ToString(fgrdFindCustSubData[lMouseRow, 2].Value)}{Environment.NewLine}";  // Company Name 
							 
							strText = $"{strText}ContactId: {Convert.ToString(fgrdFindCustSubData[lMouseRow, 4].Value)} - "; 
							strText = $"{strText}{Convert.ToString(fgrdFindCustSubData[lMouseRow, 5].Value)}{Environment.NewLine}{Environment.NewLine}";  // Contact Name 
							 
							if (Convert.ToString(fgrdFindCustSubData[lMouseRow, 6].Value) != "" && Convert.ToString(fgrdFindCustSubData[lMouseRow, 6].Value) != "0")
							{
								strText = $"{strText}ACId: {Convert.ToString(fgrdFindCustSubData[lMouseRow, 6].Value)} - ";
								strText = $"{strText}JournId: {Convert.ToString(fgrdFindCustSubData[lMouseRow, 7].Value)}{Environment.NewLine}";
								strText = $"{strText}Make: {Convert.ToString(fgrdFindCustSubData[lMouseRow, 8].Value)}  ";
								strText = $"{strText}Model: {Convert.ToString(fgrdFindCustSubData[lMouseRow, 9].Value)}  ";
								strText = $"{strText}SerNbr: {Convert.ToString(fgrdFindCustSubData[lMouseRow, 10].Value)}  ";
								strText = $"{strText}RegNbr: {Convert.ToString(fgrdFindCustSubData[lMouseRow, 11].Value)}{Environment.NewLine}";
							} 
							 
							if (Convert.ToString(fgrdFindCustSubData[lMouseRow, 12].Value) != "" && Convert.ToString(fgrdFindCustSubData[lMouseRow, 12].Value) != "0")
							{
								strText = $"{strText}Company Updated Information{Environment.NewLine}";
								strText = $"{strText}CompId: {Convert.ToString(fgrdFindCustSubData[lMouseRow, 12].Value)} - ";
								strText = $"{strText}JournId: {Convert.ToString(fgrdFindCustSubData[lMouseRow, 7].Value)}{Environment.NewLine}";
								strText = $"{strText}{Convert.ToString(fgrdFindCustSubData[lMouseRow, 13].Value)}{Environment.NewLine}"; // Company Name
							} 
							 
							// Status 
							if (Convert.ToString(fgrdFindCustSubData[lMouseRow, 17].Value) == "Yes")
							{

								if (lSubISId > 0)
								{

									strQuery1 = "SELECT * FROM EventLog WITH (NOLOCK) ";
									strQuery1 = $"{strQuery1}WHERE (evtl_type = 'Submitted Data') ";
									strQuery1 = $"{strQuery1}AND (evtl_message LIKE '%Completed%') ";
									strQuery1 = $"{strQuery1}AND (evtl_message LIKE '%SubIsLogId%') ";
									strQuery1 = $"{strQuery1}AND (evtl_message LIKE '%[{lSubISId.ToString()}]%') ";

									rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
									if (!rstRec1.BOF && !rstRec1.EOF)
									{
										strText = $"{strText}{Environment.NewLine}";
										strText = $"{strText}Completed By: {($"{Convert.ToString(rstRec1["evtl_user_id"])} ").Trim()} - {modCommon.GetFullUserName(($"{Convert.ToString(rstRec1["evtl_user_id"])} ").Trim())}";
										strText = $"{strText}  On: {StringsHelper.Format(rstRec1["evtl_date"], "mm/dd/yyyy hh:MM:ss AMPM")}{Environment.NewLine}{Environment.NewLine}";
									}
									rstRec1.Close();

								} // If lSubISId > 0 Then

							}  // If fgrdFindCustSubData.TextMatrix(lRow, 17) = "Yes" Then 
							 
							strText = $"{strText}{new string('-', 75)}{Environment.NewLine}"; 
							strText = $"{strText}Note: {Convert.ToString(fgrdFindCustSubData[lMouseRow, 15].Value)}";  // Note 
							strText = StringsHelper.Replace(strText, "&#39;", "'", 1, -1, CompareMethod.Binary);  // added MSW - 4/15/24 
							strText = StringsHelper.Replace(strText, "&amp;", "&", 1, -1, CompareMethod.Binary);  // added also - 4/19/24 

							 
							if (strText != "")
							{

								if (frm_info2.DefInstance == null)
								{
									//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
									//VB.Global.Load(frm_info2.DefInstance);
								}

								frm_info2.DefInstance.SetFormCaption("Customer Submitted Data");
								frm_info2.DefInstance.SetText(strText);
								frm_info2.DefInstance.SetTextEnabled(true);
								frm_info2.DefInstance.Show();

							}  // If strText <> "" Then 
							 
							break;
					} // Case lMouseCol

				} // If lMouseRow > 0 Then ' Header Row

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("fgrdFindCustSubData_DblClick_Error", excep.Message);
			}

		} // fgrdFindCustSubData_DblClick

		private void Fill_Find_Customer_Submitted_Data_Grid_Headers()
		{

			int lRowl = 0;

			if (cmbCustSubAcctRep.Items.Count == 0)
			{
				modFillCompConControls.Fill_AccountRep_FromArray(cmbCustSubAcctRep, true, false);
			}

			fgrdFindCustSubData.Clear();
			fgrdFindCustSubData.RowsCount = 2;
			fgrdFindCustSubData.ColumnsCount = 20;

			fgrdFindCustSubData.CurrentRowIndex = 0;

			//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			// 0             1       2        3                   4          5        6     7        8     9      10      11      12       13         14       15,   16,        17
			// Date Entered, CompId, Company, Country-State-City, ContactId, Contact, ACId, JournId, Make, Model, SerNbr, RegNbr, CompId2, CompName2, AcctRep, Note, Completed, Status

			int lCol1 = -1;

			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "Date Entered";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 117);
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "CompId";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 0);
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "Company";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 150);
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "Country, State, City";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 0);
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "ContactId";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 0);
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "Contact";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 133);
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "ACId";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 0);
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "JournId";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 0);
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "Make";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 0);
			// If opSubmitAircraft.Value = True Or opSubmitBoth.Value = True Then
			fgrdFindCustSubData.SetColumnWidth(lCol1, 97);
			// End If
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "Model";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 0);
			// If opSubmitAircraft.Value = True Or opSubmitBoth.Value = True Then
			fgrdFindCustSubData.SetColumnWidth(lCol1, 93);
			//  End If
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "SerNbr";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 0);
			//  If opSubmitAircraft.Value = True Or opSubmitBoth.Value = True Then
			fgrdFindCustSubData.SetColumnWidth(lCol1, 77);
			//  End If
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "RegNbr";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 0);
			// If opSubmitAircraft.Value = True Or opSubmitBoth.Value = True Then
			fgrdFindCustSubData.SetColumnWidth(lCol1, 73);
			// End If
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "CompId";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 0);
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "Company Updated";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 0);
			//  If opSubmitCompany.Value = True Or opSubmitBoth.Value = True Then
			fgrdFindCustSubData.SetColumnWidth(lCol1, 150);
			//  End If
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			string strAcctRep = cbo_account_id.Text.ToUpper();
			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "AcctRep";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 0);
			//  If strAcctRep = "NO REP SELECTED" Then
			fgrdFindCustSubData.SetColumnWidth(lCol1, 53);
			// End If
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "Note";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 200);
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "Completed";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 0);
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "Status";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 147);
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleCenter;


			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "Last Contact Date";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 147);
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "Login";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 147);
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleCenter;


			fgrdFindCustSubData.FixedRows = 1;
			fgrdFindCustSubData.FixedColumns = 0;

			fgrdFindCustSubData.CurrentRowIndex = 1;

		} // Fill_Find_Customer_Submitted_Data_Grid_Headers


		private void Fill_Find_Customer_Submitted_Data_Grid_Headers_New()
		{

			int lRowl = 0;

			if (cmbCustSubAcctRep.Items.Count == 0)
			{
				modFillCompConControls.Fill_AccountRep_FromArray(cmbCustSubAcctRep, true, false);
			}

			fgrdFindCustSubData.Clear();
			fgrdFindCustSubData.RowsCount = 2;
			fgrdFindCustSubData.ColumnsCount = 20;

			fgrdFindCustSubData.CurrentRowIndex = 0;

			//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			// 0             1       2        3                   4          5        6     7        8     9      10      11      12       13         14       15,   16,        17
			// Date Entered, CompId, Company, Country-State-City, ContactId, Contact, ACId, JournId, Make, Model, SerNbr, RegNbr, CompId2, CompName2, AcctRep, Note, Completed, Status

			int lCol1 = -1;

			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "Submitted";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 117);
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "CompId";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 0);
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "Company";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 150);
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "Country, State, City";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 0);
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "ContactId";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 0);
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "Contact";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 133);
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "ACId";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 0);
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "JournId";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 0);
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "Make";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 0);
			// If opSubmitAircraft.Value = True Or opSubmitBoth.Value = True Then
			fgrdFindCustSubData.SetColumnWidth(lCol1, 97);
			// End If
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "Model";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 0);
			// If opSubmitAircraft.Value = True Or opSubmitBoth.Value = True Then
			fgrdFindCustSubData.SetColumnWidth(lCol1, 93);
			//  End If
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "SerNbr";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 0);
			//  If opSubmitAircraft.Value = True Or opSubmitBoth.Value = True Then
			fgrdFindCustSubData.SetColumnWidth(lCol1, 77);
			//  End If
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "RegNbr";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 0);
			// If opSubmitAircraft.Value = True Or opSubmitBoth.Value = True Then
			fgrdFindCustSubData.SetColumnWidth(lCol1, 73);
			// End If
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			//  lCol1 = lCol1 + 1
			//  fgrdFindCustSubData.Col = lCol1
			//  fgrdFindCustSubData.Text = "CompId"
			//  fgrdFindCustSubData.ColWidth(lCol1) = 0
			//  fgrdFindCustSubData.CellAlignment = flexAlignLeftCenter

			//'  lCol1 = lCol1 + 1
			//'  fgrdFindCustSubData.Col = lCol1
			//'  fgrdFindCustSubData.Text = "Company Updated"
			//'  fgrdFindCustSubData.ColWidth(lCol1) = 0
			//''  If opSubmitCompany.Value = True Or opSubmitBoth.Value = True Then
			//'    fgrdFindCustSubData.ColWidth(lCol1) = 2250
			//''  End If
			//'  fgrdFindCustSubData.CellAlignment = flexAlignLeftCenter

			string strAcctRep = cbo_account_id.Text.ToUpper();
			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "AcctRep";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 0);
			//  If strAcctRep = "NO REP SELECTED" Then
			fgrdFindCustSubData.SetColumnWidth(lCol1, 53);
			// End If
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "Note";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 200);
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "Completed";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 0);
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "Status";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 147);
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleCenter;


			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "Last Contact Date";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 147);
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

			lCol1++;
			fgrdFindCustSubData.CurrentColumnIndex = lCol1;
			fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "Login";
			fgrdFindCustSubData.SetColumnWidth(lCol1, 147);
			fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleCenter;


			fgrdFindCustSubData.FixedRows = 1;
			fgrdFindCustSubData.FixedColumns = 0;

			fgrdFindCustSubData.CurrentRowIndex = 1;

		} // Fill_Find_Customer_Submitted_Data_Grid_Headers


		public void mnuEditCompletedCustSubData_Click(Object eventSender, EventArgs eventArgs)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";
			string strUpdate1 = "";

			int lSubISId = 0;
			int lACId = 0;
			int lCompId = 0;
			int lCompId2 = 0;
			int lContactId = 0;
			int lJournId = 0;

			string strNote = "";

			int lRow = 0;
			int lCol = 0;
			int iPos1 = 0;
			string strTempMsg = "";

			string strDateSubmitted = "";
			string strDateCompleted = "";
			string strContactInfo = "";

			try
			{

				if (Convert.ToString(mnuEditCompletedCustSubData.Tag) != "")
				{

					iPos1 = (Convert.ToString(mnuEditCompletedCustSubData.Tag).IndexOf(':') + 1);
					if (iPos1 > 0)
					{

						lRow = Convert.ToInt32(Double.Parse(Convert.ToString(mnuEditCompletedCustSubData.Tag).Substring(Math.Min(0, Convert.ToString(mnuEditCompletedCustSubData.Tag).Length), Math.Min(iPos1 - 1, Math.Max(0, Convert.ToString(mnuEditCompletedCustSubData.Tag).Length)))));
						lCol = Convert.ToInt32(Double.Parse(Convert.ToString(mnuEditCompletedCustSubData.Tag).Substring(Math.Min(iPos1, Convert.ToString(mnuEditCompletedCustSubData.Tag).Length))));

						fgrdFindCustSubData.CurrentRowIndex = lRow;
						modCommon.Highlight_Grid_Row(fgrdFindCustSubData);

						lACId = 0;
						lCompId = 0;
						lCompId2 = 0;
						lContactId = 0;
						lJournId = 0;
						strNote = "";

						lSubISId = fgrdFindCustSubData.get_RowData(lRow);

						if (lSubISId > 0)
						{

							//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
							// 0             1       2        3                   4          5        6     7        8     9      10      11      12       13         14       15,   16,        17
							// Date Entered, CompId, Company, Country-State-City, ContactId, Contact, ACId, JournId, Make, Model, SerNbr, RegNbr, CompId2, CompName2, AcctRep, Note, Completed, Status

							if (Convert.ToString(fgrdFindCustSubData[lRow, 17].Value) == "No")
							{

								if (Information.IsNumeric(Convert.ToString(fgrdFindCustSubData[lRow, 6].Value)))
								{
									lACId = Convert.ToInt32(Double.Parse(Convert.ToString(fgrdFindCustSubData[lRow, 6].Value)));
								}

								if (Information.IsNumeric(Convert.ToString(fgrdFindCustSubData[lRow, 7].Value)))
								{
									lJournId = Convert.ToInt32(Double.Parse(Convert.ToString(fgrdFindCustSubData[lRow, 7].Value)));
								}

								if (Information.IsNumeric(Convert.ToString(fgrdFindCustSubData[lRow, 1].Value)))
								{
									lCompId = Convert.ToInt32(Double.Parse(Convert.ToString(fgrdFindCustSubData[lRow, 1].Value)));
								}

								if (Information.IsNumeric(Convert.ToString(fgrdFindCustSubData[lRow, 12].Value)))
								{
									lCompId2 = Convert.ToInt32(Double.Parse(Convert.ToString(fgrdFindCustSubData[lRow, 12].Value)));
								}

								if (Information.IsNumeric(Convert.ToString(fgrdFindCustSubData[lRow, 4].Value)))
								{
									lContactId = Convert.ToInt32(Double.Parse(Convert.ToString(fgrdFindCustSubData[lRow, 4].Value)));
								}

								strNote = Convert.ToString(fgrdFindCustSubData[lRow, 15].Value);

								strUpdate1 = "UPDATE Subscription_Install_Log SET subislog_msg_type = 'Submitted Data Completed' ";
								strUpdate1 = $"{strUpdate1}WHERE (subislog_id = {lSubISId.ToString()}) ";

								DbCommand TempCommand = null;
								TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
								UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
								TempCommand.CommandText = strUpdate1;
								//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
								//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
								TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
								UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
								TempCommand.ExecuteNonQuery();

								// --- ADDED MSW - 3/1/16-------------------------

								strQuery1 = "SELECT subislog_message, subislog_date, subislog_subins_contact_id, contact_first_name, contact_last_name, contact_email_address, comp_name ";
								strQuery1 = $"{strQuery1}FROM Subscription_Install_Log WITH (NOLOCK)  ";
								strQuery1 = $"{strQuery1}INNER JOIN Contact WITH(NOLOCK) ON contact_id = subislog_subins_contact_id AND contact_journ_id = 0 ";
								strQuery1 = $"{strQuery1}INNER JOIN Company WITH (NOLOCK) ON comp_id = contact_comp_id AND comp_journ_id = 0 ";
								strQuery1 = $"{strQuery1}WHERE (subislog_id = {lSubISId.ToString()}) ";

								rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

								if (!rstRec1.BOF && !rstRec1.EOF)
								{

									strTempMsg = ($"{Convert.ToString(rstRec1["subislog_message"])} ").Trim();

									strDateSubmitted = "";
									//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
									if (!Convert.IsDBNull(rstRec1["subislog_date"]))
									{
										strDateSubmitted = StringsHelper.Format(rstRec1["subislog_date"], "mm/dd/yyyy hh:MM:ss AMPM");
									}
									strDateCompleted = StringsHelper.Format(DateTime.Now, "mm/dd/yyyy hh:MM:ss AMPM");

									strContactInfo = $"{($"{Convert.ToString(rstRec1["comp_name"])} ").Trim()} - " +
									                 $"{($"{Convert.ToString(rstRec1["contact_first_name"])} ").Trim()} " +
									                 $"{($"{Convert.ToString(rstRec1["contact_last_name"])} ").Trim()} (" +
									                 $"{($"{Convert.ToString(rstRec1["contact_email_address"])} ").Trim()}) ";

									strTempMsg = $"{strTempMsg}, Submitted: {strDateSubmitted}, By: {strContactInfo}, Completed: {strDateCompleted}";

								} // If rstRec1.BOF = False And rstRec1.EOF = False Then

								rstRec1.Close();

								// INSERT JOURNAL NOTE FOR COMPLETED RECORD
								// MSW  - 3/1/2016
								InsertJournalNote("Subscriber Feedback Action Completed", strTempMsg, lACId, lCompId2);

								int tempForEndVar = fgrdFindCustSubData.ColumnsCount - 1;
								for (lCol = 0; lCol <= tempForEndVar; lCol++)
								{
									fgrdFindCustSubData.CurrentColumnIndex = lCol;
									fgrdFindCustSubData.CellBackColor = SystemColors.InactiveCaption;
								}

								modCommon.Highlight_Grid_Row(fgrdFindCustSubData);

								modAdminCommon.Record_Event("Submitted Data", $"Completed - SubIsLogId=[{lSubISId.ToString()}] - {strNote.Substring(0, Math.Min(150, strNote.Length))}", lACId, lJournId, lCompId, false, 0, lContactId);

							} // If fgrdFindCustSubData.TextMatrix(lRow, 17) = "No" Then

						} // If lSubISId > 0 Then

					} // If iPos1 > 0 Then

				} // If mnuCopyFindDupsGrid.Tag <> "" Then

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("mnuEditCompletedCustSubData_Click_Error", excep.Message);
			}

		} // mnuEditCompletedCustSubData_Click

		private void InsertJournalNote(string strSubject, string description, int inACID, int incompid)
		{

			string strInsert1 = "";
			System.DateTime dtSystemDateTime = DateTime.FromOADate(0);

			try
			{

				if (strSubject != "")
				{

					dtSystemDateTime = DateTime.Parse(modAdminCommon.GetSystemDateTime());

					strInsert1 = "INSERT INTO Journal (";
					strInsert1 = $"{strInsert1}journ_date, ";
					strInsert1 = $"{strInsert1}journ_subcategory_code, ";
					strInsert1 = $"{strInsert1}journ_subject, ";
					strInsert1 = $"{strInsert1}journ_description, ";
					strInsert1 = $"{strInsert1}journ_ac_id, ";
					strInsert1 = $"{strInsert1}journ_comp_id, ";
					strInsert1 = $"{strInsert1}journ_contact_id, ";
					strInsert1 = $"{strInsert1}journ_user_id, ";
					strInsert1 = $"{strInsert1}journ_entry_date, ";
					strInsert1 = $"{strInsert1}journ_entry_time, ";
					strInsert1 = $"{strInsert1}journ_account_id, ";
					strInsert1 = $"{strInsert1}journ_prior_account_id, ";
					strInsert1 = $"{strInsert1}journ_status, ";
					strInsert1 = $"{strInsert1}journ_customer_note, ";
					strInsert1 = $"{strInsert1}journ_action_date ";

					strInsert1 = $"{strInsert1}) VALUES (";
					strInsert1 = $"{strInsert1}'{DateTime.Now.ToString("MM/dd/yyyy")}', ";
					strInsert1 = $"{strInsert1}'RN', ";
					strInsert1 = $"{strInsert1}'{($"{strSubject} ").Trim()}', ";
					strInsert1 = $"{strInsert1}'{StringsHelper.Replace(description, "'", "''", 1, -1, CompareMethod.Binary).Trim()}', ";
					strInsert1 = $"{strInsert1}{inACID.ToString()}, ";
					strInsert1 = $"{strInsert1}{incompid.ToString()}, ";
					strInsert1 = $"{strInsert1}0, ";
					strInsert1 = $"{strInsert1}'{modAdminCommon.gbl_User_ID}', ";
					strInsert1 = $"{strInsert1}'{dtSystemDateTime.ToString("MM/dd/yyyy")}', ";
					strInsert1 = $"{strInsert1}'{dtSystemDateTime.ToString("HH:mm:ss")}', ";
					strInsert1 = $"{strInsert1}'{modAdminCommon.gbl_Account_ID}', ";
					strInsert1 = $"{strInsert1}'', ";
					strInsert1 = $"{strInsert1}'A', ";
					strInsert1 = $"{strInsert1}'', ";
					strInsert1 = $"{strInsert1}'{DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}'";
					strInsert1 = $"{strInsert1})";

					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = strInsert1;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand.CommandType = (CommandType) (((int) CommandType.Text) + ((int) UpgradeStubs.ADODB_ExecuteOptionEnum.getadExecuteNoRecords()));
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();

				} // If strSubject <> "" Then
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Record_Error("InsertJournalNote_Error: ", excep.Message);
			}

		} // InsertJournalNote

		private void Fill_Find_Customer_Submitted_Data_Grid()
		{
			object lRowColor = null;


			DbConnection cntConn = null;
			string strConn = "";
			ADORecordSetHelper rstRec1 = null;
			string strQuery1 = "";
			string strSelect = "";
			string strAcctRep = "";
			string strAcctRepId = "";
			int lCol1 = 0;
			int lRow1 = 0;
			int lTot1 = 0;
			int lCnt1 = 0;
			int lCommandTimeOut = 0;
			int lCellColor = 0;
			string strMsg = "";
			System.DateTime dtStartDate = DateTime.FromOADate(0);
			System.DateTime dtEndDate = DateTime.FromOADate(0);
			if (chk_new_submitted.CheckState == CheckState.Checked)
			{
				Fill_Find_Customer_Submitted_Data_Grid_New();
			}
			else
			{



				cntConn = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateConnection();

				rstRec1 = new ADORecordSetHelper();



				dtStartDate = DateTime.FromOADate(0);
				dtEndDate = DateTime.FromOADate(0);

				//UPGRADE_TODO: (1065) Error handling statement (On Error Goto) could not be converted. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1065
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("On Error Goto Label (Fill_Find_Customer_Submitted_Data_Grid_Error)");

				modCommon.Start_Activity_Monitor_Message("Callback Cust Submit Data", ref strMsg, ref dtStartDate, ref dtEndDate);

				lRow1 = 0;
				lCol1 = 0;
				fgrdFindCustSubData.Enabled = false;
				cmdNewCustSubData.Visible = false;
				cmdFindCustSubDataRefresh.Enabled = false;
				cmdCSDChangeAcctRep.Enabled = false;
				cmbCustSubAcctRep.Text = "No Rep Selected";

				strAcctRep = cbo_account_id.Text.Substring(0, Math.Min(2, cbo_account_id.Text.Length)).ToUpper();
				strAcctRepId = cbo_account_id.Text.ToUpper();
				strSelect = cmbProductType.Text.Substring(0, Math.Min(1, cmbProductType.Text.Length));

				// commented out, by request - msw 4/20/17
				//  If strACCTRep <> "ID" And strACCTRep <> "RM" And (strACCTRep <> "") Then

				//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
				// 0             1       2        3                   4          5        6     7        8     9      10      11      12       13         14       15,   16,        17
				// Date Entered, CompId, Company, Country-State-City, ContactId, Contact, ACId, JournId, Make, Model, SerNbr, RegNbr, CompId2, CompName2, AcctRep, Note, Completed, Status

				if (!opSubmitAircraft.Checked && !opSubmitCompany.Checked && !opSubmitBoth.Checked)
				{
					opSubmitCompany.Checked = true;
				}

				Fill_Find_Customer_Submitted_Data_Grid_Headers();

				strQuery1 = "SELECT DISTINCT ";
				strQuery1 = $"{strQuery1}SIL1.subislog_id As SubISId, ";
				strQuery1 = $"{strQuery1}SIL1.subislog_date As DateEntered, ";
				strQuery1 = $"{strQuery1} SIL1.subislog_login as Login , ";
				strQuery1 = $"{strQuery1}C1.comp_id As CompId, ";
				strQuery1 = $"{strQuery1}C1.comp_name As CompName, ";
				strQuery1 = $"{strQuery1}C1.comp_city As City, ";
				strQuery1 = $"{strQuery1}C1.comp_state As StateAbbrev, ";
				strQuery1 = $"{strQuery1}C1.comp_country As Country, ";
				strQuery1 = $"{strQuery1}CT1.contact_id As ContactId, ";
				strQuery1 = $"{strQuery1}C1.comp_account_callback_date As Callback_Date, ";

				strQuery1 = $"{strQuery1}dbo.CreateContactFullNameTitle(CT1.contact_sirname, CT1.contact_first_name, CT1.contact_middle_initial, CT1.contact_last_name, CT1.contact_suffix,'') As Contact, ";
				strQuery1 = $"{strQuery1}A1.ac_id As ACId, ";
				strQuery1 = $"{strQuery1}SIL1.subislog_journ_id As JournId, ";
				strQuery1 = $"{strQuery1}SIL1.subislog_comp_id As CompId2, ";
				strQuery1 = $"{strQuery1}C2.comp_name As CompName2, ";
				strQuery1 = $"{strQuery1}AM1.amod_make_name As Make, ";
				strQuery1 = $"{strQuery1}AM1.amod_model_name As Model, ";
				strQuery1 = $"{strQuery1}A1.ac_ser_no_full As SerNbr, ";
				strQuery1 = $"{strQuery1}A1.ac_reg_no As RegNbr, ";

				strQuery1 = $"{strQuery1}SIL1.subislog_msg_type As MsgType, ";
				strQuery1 = $"{strQuery1}SIL1.subislog_message As Note, ";

				if (opSubmitAircraft.Checked || opSubmitBoth.Checked)
				{
					strQuery1 = $"{strQuery1}(SELECT C3.comp_account_id ";
					strQuery1 = $"{strQuery1} FROM Aircraft_Reference AS AR3 WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1} INNER JOIN Company AS C3 WITH (NOLOCK) ON C3.comp_id = AR3.cref_comp_id AND C3.comp_journ_id = AR3.cref_journ_id ";
					strQuery1 = $"{strQuery1} WHERE (AR3.cref_ac_id = SIL1.subislog_ac_id) ";
					strQuery1 = $"{strQuery1} AND (AR3.cref_journ_id = SIL1.subislog_journ_id) ";
					strQuery1 = $"{strQuery1} AND (AR3.cref_primary_poc_flag = 'Y')) As AcctRep, ";
				}
				else
				{
					strQuery1 = $"{strQuery1}'' As AcctRep, ";
				}

				if (opSubmitCompany.Checked || opSubmitBoth.Checked)
				{
					strQuery1 = $"{strQuery1}(SELECT C4.comp_account_id ";
					strQuery1 = $"{strQuery1} FROM Company AS C4 WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1} WHERE (C4.comp_id = c1.comp_id) "; //switched from  SIL1.subislog_comp_id
					strQuery1 = $"{strQuery1} AND (C4.comp_journ_id = SIL1.subislog_journ_id) ";
					strQuery1 = $"{strQuery1}) As AcctRep2, ";
				}
				else
				{
					strQuery1 = $"{strQuery1}'' As AcctRep2, ";
				}

				strQuery1 = $"{strQuery1}SIL1.subislog_account_id  As AcctRep3 ";

				strQuery1 = $"{strQuery1}FROM Subscription_Install_Log AS SIL1 WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}INNER JOIN Subscription AS S1 WITH (NOLOCK) ON S1.sub_id = SIL1.subislog_subid ";
				strQuery1 = $"{strQuery1}INNER JOIN Subscription_Install AS SI1 WITH (NOLOCK) ON SI1.subins_sub_id = SIL1.subislog_subid AND SI1.subins_login = SIL1.subislog_login AND SI1.subins_seq_no = SIL1.subislog_seq_no ";
				strQuery1 = $"{strQuery1}INNER JOIN Company AS C1 WITH (NOLOCK) ON C1.comp_id = S1.sub_comp_id AND C1.comp_journ_id = 0 ";
				strQuery1 = $"{strQuery1}INNER JOIN Contact AS CT1 WITH (NOLOCK) ON CT1.contact_id = SI1.subins_contact_id AND CT1.contact_journ_id = 0 ";
				strQuery1 = $"{strQuery1}LEFT OUTER JOIN Company AS C2 WITH (NOLOCK) ON C2.comp_id = SIL1.subislog_comp_id AND C2.comp_journ_id = SIL1.subislog_journ_id ";
				strQuery1 = $"{strQuery1}LEFT OUTER JOIN Aircraft AS A1 WITH (NOLOCK) ON SIL1.subislog_ac_id = A1.ac_id AND A1.ac_journ_id = SIL1.subislog_journ_id ";
				strQuery1 = $"{strQuery1}LEFT OUTER JOIN Aircraft_Model AS AM1 WITH (NOLOCK) ON AM1.amod_id = A1.ac_amod_id ";
				strQuery1 = $"{strQuery1}WHERE (SIL1.subislog_journ_id = 0) ";

				if (opSubmitAircraft.Checked)
				{
					strQuery1 = $"{strQuery1}AND (SIL1.subislog_ac_id > 0) ";
				}

				// If opSubmitCompany.Value = True Then
				//   strQuery1 = strQuery1 & "AND (SIL1.subislog_comp_id > 0) "
				// End If

				strQuery1 = $"{strQuery1}AND (SIL1.subislog_msg_type in ('Submitted Data', 'Submitted Data In Progress') ";

				if (chkCustSubDataIncludeCompleted.CheckState == CheckState.Checked)
				{
					strQuery1 = $"{strQuery1} OR SIL1.subislog_msg_type = 'Submitted Data Completed' ";
				}

				strQuery1 = $"{strQuery1}) ";

				if (($"{txt_ListStartDate.Text} ").Trim() != "")
				{
					if (Information.IsDate(($"{txt_ListStartDate.Text} ").Trim()))
					{
						strQuery1 = $"{strQuery1}AND (SIL1.subislog_date >= '{($"{txt_ListStartDate.Text} ").Trim()}') ";
					}
				}

				strQuery1 = $"{strQuery1}AND (SIL1.subislog_message IS NOT NULL AND SIL1.subislog_message <> '') ";

				//---------------------------------------------------------
				// Must Be Primary On Aircraft Or Company AcctRep

				if (strAcctRepId != "" && strAcctRepId != "NO REP SELECTED")
				{

					if (opSubmitBoth.Checked)
					{
						strQuery1 = $"{strQuery1}AND (";

						strQuery1 = $"{strQuery1}     (";
						strQuery1 = $"{strQuery1}        (SIL1.subislog_account_id IS NULL OR SIL1.subislog_account_id = '') ";
						strQuery1 = $"{strQuery1}        AND EXISTS (SELECT NULL FROM Aircraft_Reference AS AR2 WITH (NOLOCK) ";
						strQuery1 = $"{strQuery1}                    INNER JOIN Company AS C2 WITH (NOLOCK) ON C2.comp_id = AR2.cref_comp_id AND C2.comp_journ_id = AR2.cref_journ_id ";
						strQuery1 = $"{strQuery1}                    WHERE (AR2.cref_ac_id = A1.ac_id) ";
						strQuery1 = $"{strQuery1}                    AND (AR2.cref_journ_id = A1.ac_journ_id)  ";
						strQuery1 = $"{strQuery1}                    AND (AR2.cref_primary_poc_flag = 'Y') ";
						strQuery1 = $"{strQuery1}                    AND  C2.comp_account_id {make_account_rep_answer_string()}";
						strQuery1 = $"{strQuery1}                    ) ";
						strQuery1 = $"{strQuery1}     ) ";

						strQuery1 = $"{strQuery1} OR ";

						strQuery1 = $"{strQuery1}    (";
						strQuery1 = $"{strQuery1}        (SIL1.subislog_account_id IS NULL OR SIL1.subislog_account_id = '') ";
						strQuery1 = $"{strQuery1}         AND EXISTS (SELECT NULL FROM Company AS C3 WITH (NOLOCK) ";
						strQuery1 = $"{strQuery1}                     WHERE (C3.comp_id = C1.comp_id) "; // changed from SIL1.subislog_comp_id) - MSW 7/31/19
						strQuery1 = $"{strQuery1}                     AND (C3.comp_journ_id = 0) ";
						strQuery1 = $"{strQuery1}                     AND  C3.comp_account_id {make_account_rep_answer_string()}";
						strQuery1 = $"{strQuery1}                     ) ";
						strQuery1 = $"{strQuery1}     ) ";

						strQuery1 = $"{strQuery1}     OR (SIL1.subislog_account_id IS NOT NULL AND SIL1.subislog_account_id = '{strAcctRepId}') ";

						strQuery1 = $"{strQuery1}    ) "; // AND

					} // If opSubmitBoth.Value = True Then

					if (opSubmitAircraft.Checked)
					{
						strQuery1 = $"{strQuery1}AND (";
						strQuery1 = $"{strQuery1}       (";
						strQuery1 = $"{strQuery1}         (SIL1.subislog_account_id IS NULL OR SIL1.subislog_account_id = '') ";
						strQuery1 = $"{strQuery1}          AND EXISTS (SELECT NULL FROM Aircraft_Reference AS AR2 WITH (NOLOCK) ";
						strQuery1 = $"{strQuery1}                      INNER JOIN Company AS C2 WITH (NOLOCK) ON C2.comp_id = AR2.cref_comp_id AND C2.comp_journ_id = AR2.cref_journ_id ";
						strQuery1 = $"{strQuery1}                      WHERE (AR2.cref_ac_id = A1.ac_id) ";
						strQuery1 = $"{strQuery1}                      AND (AR2.cref_journ_id = A1.ac_journ_id)  ";
						strQuery1 = $"{strQuery1}                      AND (AR2.cref_primary_poc_flag = 'Y') ";
						strQuery1 = $"{strQuery1}                      AND  C2.comp_account_id  {make_account_rep_answer_string()}";
						strQuery1 = $"{strQuery1}                     ) ";
						strQuery1 = $"{strQuery1}         ) ";
						strQuery1 = $"{strQuery1}     OR (SIL1.subislog_account_id IS NOT NULL AND SIL1.subislog_account_id = '{strAcctRepId}') ";
						strQuery1 = $"{strQuery1}    ) ";
					} // If opSubmitAircraft.Value = True Then

					if (opSubmitCompany.Checked)
					{
						strQuery1 = $"{strQuery1}AND (";
						strQuery1 = $"{strQuery1}        (";
						strQuery1 = $"{strQuery1}          (SIL1.subislog_account_id IS NULL OR SIL1.subislog_account_id = '') ";
						strQuery1 = $"{strQuery1}           AND EXISTS (SELECT NULL FROM Company AS C3 WITH (NOLOCK) ";
						strQuery1 = $"{strQuery1}                       WHERE (C3.comp_id = C1.comp_id) ";
						strQuery1 = $"{strQuery1}                       AND (C3.comp_journ_id = 0) ";
						strQuery1 = $"{strQuery1}                       AND ((C3.comp_account_id  {make_account_rep_answer_string()}) or (C3.comp_account_id  {make_account_rep_answer_string()})) ";
						strQuery1 = $"{strQuery1}                      ) ";
						strQuery1 = $"{strQuery1}         ) ";
						strQuery1 = $"{strQuery1}     OR (SIL1.subislog_account_id IS NOT NULL AND SIL1.subislog_account_id {make_account_rep_answer_string()}) ";
						strQuery1 = $"{strQuery1}    ) ";
					} // If opSubmitCompany.Value = True Then

				} // If strACCTRepId <> "" And strACCTRepId <> "NO REP SELECTED" Then

				//-----------------------------------------------
				// Select Aircraft Type

				if (opSubmitAircraft.Checked || opSubmitBoth.Checked)
				{


					switch(strSelect)
					{
						case "A" :  // - Helicopters and Business Aircraft 
							strQuery1 = $"{strQuery1}AND ( "; 
							strQuery1 = $"{strQuery1}        (AM1.amod_airframe_type_code = 'F' "; 
							strQuery1 = $"{strQuery1}         AND AM1.amod_product_business_flag = 'Y' "; 
							strQuery1 = $"{strQuery1}         AND A1.ac_product_business_flag = 'Y' "; 
							strQuery1 = $"{strQuery1}        ) "; 
							strQuery1 = $"{strQuery1}     OR (AM1.amod_airframe_type_code = 'R' "; 
							strQuery1 = $"{strQuery1}         AND AM1.amod_product_helicopter_flag = 'Y' "; 
							strQuery1 = $"{strQuery1}         AND A1.ac_product_helicopter_flag = 'Y' "; 
							strQuery1 = $"{strQuery1}        ) "; 
							strQuery1 = $"{strQuery1}    ) "; 
							 
							break;
						case "B" :  // - Business Aircraft 
							strQuery1 = $"{strQuery1}AND (AM1.amod_airframe_type_code = 'F') "; 
							strQuery1 = $"{strQuery1}AND (AM1.amod_product_business_flag = 'Y') "; 
							strQuery1 = $"{strQuery1}AND (A1.ac_product_business_flag = 'Y') "; 
							 
							break;
						case "C" :  // - Commercial 
							strQuery1 = $"{strQuery1}AND (AM1.amod_airframe_type_code = 'F') "; 
							strQuery1 = $"{strQuery1}AND (AM1.amod_product_commercial_flag = 'Y') "; 
							strQuery1 = $"{strQuery1}AND (A1.ac_product_commercial_flag = 'Y') "; 
							 
							break;
						case "H" :  // - Helicopters 
							strQuery1 = $"{strQuery1}AND (AM1.amod_airframe_type_code = 'R') "; 
							strQuery1 = $"{strQuery1}AND (AM1.amod_product_helicopter_flag = 'Y') "; 
							strQuery1 = $"{strQuery1}AND (A1.ac_product_helicopter_flag = 'Y') "; 
							 
							break;
						case "L" :  // - All 
							 
							break;
						case "Q" :  // JNiQ Eligible 
							 
							strQuery1 = $"{strQuery1}{modCommon.Return_JNiQ_Eligible_Query(strAcctRepId, strQuery1)}"; 
							 
							break;
						case "N" :  // Non-JNiQ Eligible 
							 
							strQuery1 = $"{strQuery1}{modCommon.Return_Non_JNiQ_Eligible_Query()}"; 
							 
							break;
						case "P" :  // - AirBP 
							 
							strQuery1 = $"{strQuery1}AND (A1.ac_product_airbp_flag = 'Y') "; 
							 
							break;
					} // strSelect

				} // If opSubmitAircraft.Value = True Or opSubmitBoth.Value = True Then

				strQuery1 = $"{strQuery1}ORDER BY DateEntered, Make, Model, SerNbr ";

				fgrdFindCustSubData.Tag = "DateEntered, Make, Model, SerNbr"; // Save Sort Order

				modAdminCommon.Record_Event("Monitor Activity", $"Customer Submitted Data - Selected AcctRep: {strAcctRepId}");
				//Record_Event "HB Usage", "Customer Submitted Data - Selected AcctRep: " & strAcctRepId

				lblFindCustSubDataRecords.Text = "Searching Records";

				rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					lblFindCustSubDataStop.Enabled = true;
					lblFindCustSubDataStop.Visible = true;
					cmdNewCustSubData.Visible = true;

					lTot1 = rstRec1.RecordCount;
					lCnt1 = 0;
					lRow1 = 0;

					fgrdFindCustSubData.Redraw = false;

					do 
					{ // Loop Until rstRec1.EOF = True Or lblFindCustSubDataStop.Enabled = False

						lCnt1++;
						lblFindCustSubDataRecords.Text = $"Total Records Found: {StringsHelper.Format(lTot1, "00000#")}  Loading: {StringsHelper.Format(lCnt1, "00000#")}";

						lRow1++;
						fgrdFindCustSubData.RowsCount = lRow1 + 1;
						fgrdFindCustSubData.CurrentRowIndex = lRow1;

						//---------------------------------------------
						//-- Set Status Field

						fgrdFindCustSubData.set_RowData(lRow1, Convert.ToInt32(rstRec1.GetField("SubISId")));
						fgrdFindCustSubData[lRow1, 17].Value = "No";
						lRowColor = 0x80000005; // White
						lCellColor = unchecked((int) 0x80000008); // Black

						if (($"{Convert.ToString(rstRec1["MsgType"])} ").Trim() == "Submitted Data Completed")
						{
							fgrdFindCustSubData[lRow1, 17].Value = "Yes";
							lRowColor = 0x80000003;
						}

						if (($"{Convert.ToString(rstRec1["MsgType"])} ").Trim() == "Submitted Data In Progress")
						{
							fgrdFindCustSubData[lRow1, 17].Value = "No";
							lRowColor = 0xFFFF00;
						}

						lCol1 = -1;

						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["DateEntered"]))
						{
							fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = StringsHelper.Format(rstRec1["DateEntered"], "mm/dd/yyyy hh:MM AMPM");
						}
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = Convert.ToString(rstRec1["CompID"]);

						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["CompName"])} ").Trim();

						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = $"{($"{Convert.ToString(rstRec1["country"])} ").Trim()}, {($"{Convert.ToString(rstRec1["StateAbbrev"])} ").Trim()}, {($"{Convert.ToString(rstRec1["city"])} ").Trim()}";

						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = Convert.ToString(rstRec1["ContactId"]);
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["Contact"])} ").Trim();

						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["ACID"]))
						{
							fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = Convert.ToString(rstRec1["ACID"]);
						}
						else
						{
							fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "0";
						}

						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["JournID"]))
						{
							fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = Convert.ToString(rstRec1["JournID"]);
						}
						else
						{
							fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "0";
						}

						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["make"])} ").Trim();

						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["model"])} ").Trim();

						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["SerNbr"])} ").Trim();

						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["RegNbr"])} ").Trim();

						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["compid2"]))
						{
							fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = Convert.ToString(rstRec1["compid2"]);
						}
						else
						{
							fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "0";
						}

						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						fgrdFindCustSubData.CellFontBold = false;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["CompName2"])} ").Trim();

						// ADDED MSW - 3/1/16 to show account rep
						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

						if (opSubmitCompany.Checked)
						{
							fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["AcctRep2"])} ").Trim();
						}
						else
						{
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(rstRec1["AcctRep"]))
							{
								fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["AcctRep"])} ").Trim();
							}
							else
							{
								fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["AcctRep2"])} ").Trim();
							}
						}


						// 11/29/2018 - By David D. Cruger
						// This AcctRep has been manually Assigned To This Record
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["AcctRep3"]) && ($"{Convert.ToString(rstRec1["AcctRep3"])} ").Trim() != "")
						{
							fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["AcctRep3"])} ").Trim();
							fgrdFindCustSubData.CellBackColor = Color.FromArgb(255, 128, 0); // TAN
							fgrdFindCustSubData.CellForeColor = SystemColors.HighlightText; // WHITE
							fgrdFindCustSubData.CellFontBold = true;
						}

						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["NOTE"])} ").Trim(); // Trim(rstRec1!NOTE & " ")
						fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = StringsHelper.Replace(fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].FormattedValue.ToString(), "&#39;", "'", 1, -1, CompareMethod.Binary); // added MSW - 4/15/24
						fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = StringsHelper.Replace(fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].FormattedValue.ToString(), "&amp;", "&", 1, -1, CompareMethod.Binary); // added MSW - 4/15/24
						fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = StringsHelper.Replace(fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].FormattedValue.ToString(), "amp;", "&", 1, -1, CompareMethod.Binary); // added MSW - 4/15/24


						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["MsgType"])} ").Trim();

						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						// fgrdFindCustSubData.Text = ""

						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["Callback_Date"])} ").Trim();


						// ADDED MSW 3/9/2020 FOR MOSTLY DEMO LOGINS
						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["login"])} ").Trim();



						if (lRow1 == 25)
						{
							fgrdFindCustSubData.Redraw = true;
							fgrdFindCustSubData.Refresh();
							fgrdFindCustSubData.Redraw = false;
						}

						rstRec1.MoveNext();
						Application.DoEvents();

					}
					while(!(rstRec1.EOF || !lblFindCustSubDataStop.Enabled));

					if (lblFindCustSubDataStop.Enabled)
					{
						lblFindCustSubDataRecords.Text = $"Total Records Found: {StringsHelper.Format(lTot1, "00000#")}";
					}

					fgrdFindCustSubData.Redraw = true;
					fgrdFindCustSubData.Refresh();
					fgrdFindCustSubData.Enabled = true;

				}
				else
				{
					fgrdFindCustSubData.CurrentRowIndex = 1;
					fgrdFindCustSubData.CurrentColumnIndex = 2;
					fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "No Records Found";
					lblFindCustSubDataRecords.Text = "No Records Found";
				} // If rstRec1.BOF = False And rstRec1.EOF = False Then

				rstRec1.Close();

				lblFindCustSubDataStop.Enabled = false;
				lblFindCustSubDataStop.Visible = false;

				strMsg = $"AcctRep: {cbo_account_id.Text}";
				strMsg = $"{strMsg} Product: {cmbProductType.Text}";
				if (txt_ListStartDate.Text != "")
				{
					strMsg = $"{strMsg} Start Date: {txt_ListStartDate.Text}";
				}

				if (chkCustSubDataIncludeCompleted.CheckState == CheckState.Checked)
				{
					strMsg = $"{strMsg} [x] Include Completed ";
				}

				if (bLog)
				{

					modCommon.End_Activity_Monitor_Message("Callback Cust Submit Data", ref strMsg, dtStartDate, ref dtEndDate, 0, 0, 0, 0, 0);

					frm_UserHistory.DefInstance.Refresh_User_History_Grids("Callback");

				}

				// Else
				//   If strACCTRepId <> "" Then
				//     lblFindCustSubDataRecords.Caption = "Can NOT Process Reports for AcctRep ID##, RM##"
				//   End If
				// End If ' If strAcctRep <> "ID" And strAcctRep <> "RM" And (strAcctRep <> "") Then

				cmdFindCustSubDataRefresh.Enabled = true;
				rstRec1 = null;

				return;

			}

			Fill_Find_Customer_Submitted_Data_Grid_Error:

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
			modAdminCommon.Record_Error("Callbacks (Find Customer Submitted Data)", $"Fill_Find_Customer_Submitted_Data_Grid: {Information.Err().Number.ToString()} - {Information.Err().Description}");

		} // Fill_Find_Customer_Submitted_Data_Grid



		private void Fill_Find_Customer_Submitted_Data_Grid_New()
		{

			DbConnection cntConn = UpgradeHelpers.DB.AdoFactoryManager.GetFactory().CreateConnection();
			string strConn = "";

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			string strSelect = "";
			string strAcctRep = "";
			string strAcctRepId = "";
			int lCol1 = 0;
			int lRow1 = 0;

			int lTot1 = 0;
			int lCnt1 = 0;
			int lCommandTimeOut = 0;
			object lRowColor = null;
			int lCellColor = 0;

			string strMsg = "";
			System.DateTime dtStartDate = DateTime.FromOADate(0);
			System.DateTime dtEndDate = DateTime.FromOADate(0);

			try
			{

				modCommon.Start_Activity_Monitor_Message("Callback Cust Submit Data", ref strMsg, ref dtStartDate, ref dtEndDate);

				lRow1 = 0;
				lCol1 = 0;
				fgrdFindCustSubData.Enabled = false;
				cmdNewCustSubData.Visible = false;
				cmdFindCustSubDataRefresh.Enabled = false;
				cmdCSDChangeAcctRep.Enabled = false;
				cmbCustSubAcctRep.Text = "No Rep Selected";

				strAcctRep = cbo_account_id.Text.Substring(0, Math.Min(2, cbo_account_id.Text.Length)).ToUpper();
				strAcctRepId = cbo_account_id.Text.ToUpper();
				strSelect = cmbProductType.Text.Substring(0, Math.Min(1, cmbProductType.Text.Length));

				// commented out, by request - msw 4/20/17
				//  If strACCTRep <> "ID" And strACCTRep <> "RM" And (strACCTRep <> "") Then

				//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
				// 0             1       2        3                   4          5        6     7        8     9      10      11      12       13         14       15,   16,        17
				// Date Entered, CompId, Company, Country-State-City, ContactId, Contact, ACId, JournId, Make, Model, SerNbr, RegNbr, CompId2, CompName2, AcctRep, Note, Completed, Status

				if (!opSubmitAircraft.Checked && !opSubmitCompany.Checked && !opSubmitBoth.Checked)
				{
					opSubmitCompany.Checked = true;
				}

				Fill_Find_Customer_Submitted_Data_Grid_Headers_New();

				strQuery1 = "SELECT DISTINCT ";
				strQuery1 = $"{strQuery1} clirequest_sub_id  As SubISId, ";
				strQuery1 = $"{strQuery1} clirequest_date_submitted As DateEntered, ";
				strQuery1 = $"{strQuery1} clirequest_login as Login , ";
				strQuery1 = $"{strQuery1}C1.comp_id As CompId, ";
				strQuery1 = $"{strQuery1}C1.comp_name As CompName, ";
				strQuery1 = $"{strQuery1}C1.comp_city As City, ";
				strQuery1 = $"{strQuery1}C1.comp_state As StateAbbrev, ";
				strQuery1 = $"{strQuery1}C1.comp_country As Country, ";
				strQuery1 = $"{strQuery1}CT1.contact_id As ContactId, ";
				strQuery1 = $"{strQuery1}C1.comp_account_callback_date As Callback_Date, ";

				strQuery1 = $"{strQuery1}dbo.CreateContactFullNameTitle(CT1.contact_sirname, CT1.contact_first_name, CT1.contact_middle_initial, CT1.contact_last_name, CT1.contact_suffix,'') As Contact, ";
				strQuery1 = $"{strQuery1}A1.ac_id As ACId, ";
				strQuery1 = $"{strQuery1} 0  As JournId, "; // to be added ?
				strQuery1 = $"{strQuery1} 0  As CompId2, ";
				strQuery1 = $"{strQuery1}C2.comp_name As CompName2, ";
				strQuery1 = $"{strQuery1}AM1.amod_make_name As Make, ";
				strQuery1 = $"{strQuery1}AM1.amod_model_name As Model, ";
				strQuery1 = $"{strQuery1}A1.ac_ser_no_full As SerNbr, ";
				strQuery1 = $"{strQuery1}A1.ac_reg_no As RegNbr, ";

				strQuery1 = $"{strQuery1}clireqdet_field_name As MsgType, ";
				strQuery1 = $"{strQuery1}clirequest_notes As Note, ";

				if (opSubmitCompany.Checked || opSubmitBoth.Checked)
				{
					strQuery1 = $"{strQuery1}(SELECT C4.comp_account_id ";
					strQuery1 = $"{strQuery1} FROM Company AS C4 WITH (NOLOCK) ";
					strQuery1 = $"{strQuery1} WHERE (C4.comp_id = c1.comp_id) "; //switched from  SIL1.subislog_comp_id
					strQuery1 = $"{strQuery1} AND (C4.comp_journ_id = 0) ";
					strQuery1 = $"{strQuery1}) As AcctRep2, ";
				}
				else
				{
					strQuery1 = $"{strQuery1}'' As AcctRep2, ";
				}


				strQuery1 = $"{strQuery1} C1.comp_account_id  As AcctRep3 ";

				// ADDED MSW - 9/14/22
				strQuery1 = $"{strQuery1}FROM [EVO_Live].jetnet_ra.dbo.Client_Data_Change   WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1} left outer join [EVO_Live].jetnet_ra.dbo.client_data_change_details on clirequest_id = clireqdet_clirequest_id ";

				strQuery1 = $"{strQuery1}INNER JOIN Subscription AS S1 WITH (NOLOCK) ON S1.sub_id =  clirequest_sub_id ";
				strQuery1 = $"{strQuery1}INNER JOIN Subscription_Install AS SI1 WITH (NOLOCK) ON SI1.subins_sub_id = clirequest_sub_id AND SI1.subins_login = clirequest_login AND SI1.subins_seq_no = 1  "; // changed to 1
				strQuery1 = $"{strQuery1}INNER JOIN Company AS C1 WITH (NOLOCK) ON C1.comp_id = S1.sub_comp_id AND C1.comp_journ_id = 0 ";
				strQuery1 = $"{strQuery1}INNER JOIN Contact AS CT1 WITH (NOLOCK) ON CT1.contact_id = SI1.subins_contact_id AND CT1.contact_journ_id = 0 ";
				strQuery1 = $"{strQuery1}LEFT OUTER JOIN Company AS C2 WITH (NOLOCK) ON C2.comp_id = 0 AND C2.comp_journ_id = 0 "; // should be comp id - but isnt one
				strQuery1 = $"{strQuery1}LEFT OUTER JOIN Aircraft AS A1 WITH (NOLOCK) ON clireqdet_ac_id = A1.ac_id AND A1.ac_journ_id = 0 ";
				strQuery1 = $"{strQuery1}LEFT OUTER JOIN Aircraft_Model AS AM1 WITH (NOLOCK) ON AM1.amod_id = A1.ac_amod_id ";
				strQuery1 = $"{strQuery1}WHERE (C1.comp_journ_id = 0) ";

				if (opSubmitAircraft.Checked)
				{
					strQuery1 = $"{strQuery1}AND (SIL1.subislog_ac_id > 0) ";
				}



				if (($"{txt_ListStartDate.Text} ").Trim() != "")
				{
					if (Information.IsDate(($"{txt_ListStartDate.Text} ").Trim()))
					{
						strQuery1 = $"{strQuery1}AND (SIL1.subislog_date >= '{($"{txt_ListStartDate.Text} ").Trim()}') ";
					}
				}



				strQuery1 = $"{strQuery1}ORDER BY DateEntered, Make, Model, SerNbr ";

				fgrdFindCustSubData.Tag = "DateEntered, Make, Model, SerNbr"; // Save Sort Order

				modAdminCommon.Record_Event("Monitor Activity", $"Customer Submitted Data - Selected AcctRep: {strAcctRepId}");
				//Record_Event "HB Usage", "Customer Submitted Data - Selected AcctRep: " & strAcctRepId

				lblFindCustSubDataRecords.Text = "Searching Records";

				rstRec1.CursorLocation = CursorLocationEnum.adUseClient;
				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					lblFindCustSubDataStop.Enabled = true;
					lblFindCustSubDataStop.Visible = true;
					cmdNewCustSubData.Visible = true;

					lTot1 = rstRec1.RecordCount;
					lCnt1 = 0;
					lRow1 = 0;

					fgrdFindCustSubData.Redraw = false;

					do 
					{ // Loop Until rstRec1.EOF = True Or lblFindCustSubDataStop.Enabled = False

						lCnt1++;
						lblFindCustSubDataRecords.Text = $"Total Records Found: {StringsHelper.Format(lTot1, "00000#")}  Loading: {StringsHelper.Format(lCnt1, "00000#")}";

						lRow1++;
						fgrdFindCustSubData.RowsCount = lRow1 + 1;
						fgrdFindCustSubData.CurrentRowIndex = lRow1;

						//---------------------------------------------
						//-- Set Status Field

						fgrdFindCustSubData.set_RowData(lRow1, Convert.ToInt32(rstRec1.GetField("SubISId")));
						fgrdFindCustSubData[lRow1, 17].Value = "No";
						lRowColor = 0x80000005; // White
						lCellColor = unchecked((int) 0x80000008); // Black

						if (($"{Convert.ToString(rstRec1["MsgType"])} ").Trim() == "Submitted Data Completed")
						{
							fgrdFindCustSubData[lRow1, 17].Value = "Yes";
							lRowColor = 0x80000003;
						}

						if (($"{Convert.ToString(rstRec1["MsgType"])} ").Trim() == "Submitted Data In Progress")
						{
							fgrdFindCustSubData[lRow1, 17].Value = "No";
							lRowColor = 0xFFFF00;
						}

						lCol1 = -1;

						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["DateEntered"]))
						{
							fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = StringsHelper.Format(rstRec1["DateEntered"], "mm/dd/yyyy hh:MM AMPM");
						}
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = Convert.ToString(rstRec1["CompID"]);

						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["CompName"])} ").Trim();

						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = $"{($"{Convert.ToString(rstRec1["country"])} ").Trim()}, {($"{Convert.ToString(rstRec1["StateAbbrev"])} ").Trim()}, {($"{Convert.ToString(rstRec1["city"])} ").Trim()}";

						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = Convert.ToString(rstRec1["ContactId"]);
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["Contact"])} ").Trim();

						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["ACID"]))
						{
							fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = Convert.ToString(rstRec1["ACID"]);
						}
						else
						{
							fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "0";
						}

						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["JournID"]))
						{
							fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = Convert.ToString(rstRec1["JournID"]);
						}
						else
						{
							fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "0";
						}

						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["make"])} ").Trim();

						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["model"])} ").Trim();

						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["SerNbr"])} ").Trim();

						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["RegNbr"])} ").Trim();

						//        lCol1 = lCol1 + 1
						//        fgrdFindCustSubData.Col = lCol1
						//        fgrdFindCustSubData.CellBackColor = lRowColor
						//        fgrdFindCustSubData.CellAlignment = flexAlignLeftCenter
						//        If IsNull(rstRec1!compid2) = False Then
						//          fgrdFindCustSubData.Text = CStr(rstRec1!compid2)
						//        Else
						//            fgrdFindCustSubData.Text = "0"
						//        End If
						//
						//        lCol1 = lCol1 + 1
						//        fgrdFindCustSubData.Col = lCol1
						//        fgrdFindCustSubData.CellFontBold = False
						//        fgrdFindCustSubData.CellBackColor = lRowColor
						//        fgrdFindCustSubData.CellAlignment = flexAlignLeftCenter
						//        fgrdFindCustSubData.Text = Trim(rstRec1!CompName2 & " ")

						// ADDED MSW - 3/1/16 to show account rep
						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;

						if (opSubmitCompany.Checked)
						{
							fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["AcctRep2"])} ").Trim();
						}
						else
						{
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(rstRec1["AcctRep"]))
							{
								fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["AcctRep"])} ").Trim();
							}
							else
							{
								fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["AcctRep2"])} ").Trim();
							}
						}


						// 11/29/2018 - By David D. Cruger
						// This AcctRep has been manually Assigned To This Record
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(rstRec1["AcctRep3"]) && ($"{Convert.ToString(rstRec1["AcctRep3"])} ").Trim() != "")
						{
							fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["AcctRep3"])} ").Trim();
							fgrdFindCustSubData.CellBackColor = Color.FromArgb(255, 128, 0); // TAN
							fgrdFindCustSubData.CellForeColor = SystemColors.HighlightText; // WHITE
							fgrdFindCustSubData.CellFontBold = true;
						}

						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["NOTE"])} ").Trim(); // Trim(rstRec1!NOTE & " ")

						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["MsgType"])} ").Trim();

						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						// fgrdFindCustSubData.Text = ""

						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["Callback_Date"])} ").Trim();


						// ADDED MSW 3/9/2020 FOR MOSTLY DEMO LOGINS
						lCol1++;
						fgrdFindCustSubData.CurrentColumnIndex = lCol1;
						//UPGRADE_WARNING: (1068) lRowColor of type Variant is being forced to int. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1068
						fgrdFindCustSubData.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(lRowColor));
						fgrdFindCustSubData.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = ($"{Convert.ToString(rstRec1["login"])} ").Trim();



						if (lRow1 == 25)
						{
							fgrdFindCustSubData.Redraw = true;
							fgrdFindCustSubData.Refresh();
							fgrdFindCustSubData.Redraw = false;
						}

						rstRec1.MoveNext();
						Application.DoEvents();

					}
					while(!(rstRec1.EOF || !lblFindCustSubDataStop.Enabled));

					if (lblFindCustSubDataStop.Enabled)
					{
						lblFindCustSubDataRecords.Text = $"Total Records Found: {StringsHelper.Format(lTot1, "00000#")}";
					}

					fgrdFindCustSubData.Redraw = true;
					fgrdFindCustSubData.Refresh();
					fgrdFindCustSubData.Enabled = true;

				}
				else
				{
					fgrdFindCustSubData.CurrentRowIndex = 1;
					fgrdFindCustSubData.CurrentColumnIndex = 2;
					fgrdFindCustSubData[fgrdFindCustSubData.CurrentRowIndex, fgrdFindCustSubData.CurrentColumnIndex].Value = "No Records Found";
					lblFindCustSubDataRecords.Text = "No Records Found";
				} // If rstRec1.BOF = False And rstRec1.EOF = False Then

				rstRec1.Close();

				lblFindCustSubDataStop.Enabled = false;
				lblFindCustSubDataStop.Visible = false;

				strMsg = $"AcctRep: {cbo_account_id.Text}";
				strMsg = $"{strMsg} Product: {cmbProductType.Text}";
				if (txt_ListStartDate.Text != "")
				{
					strMsg = $"{strMsg} Start Date: {txt_ListStartDate.Text}";
				}

				if (chkCustSubDataIncludeCompleted.CheckState == CheckState.Checked)
				{
					strMsg = $"{strMsg} [x] Include Completed ";
				}

				if (bLog)
				{

					modCommon.End_Activity_Monitor_Message("Callback Cust Submit Data", ref strMsg, dtStartDate, ref dtEndDate, 0, 0, 0, 0, 0);

					frm_UserHistory.DefInstance.Refresh_User_History_Grids("Callback");

				}

				// Else
				//   If strACCTRepId <> "" Then
				//     lblFindCustSubDataRecords.Caption = "Can NOT Process Reports for AcctRep ID##, RM##"
				//   End If
				// End If ' If strAcctRep <> "ID" And strAcctRep <> "RM" And (strAcctRep <> "") Then

				cmdFindCustSubDataRefresh.Enabled = true;
				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Record_Error("Callbacks (Find Customer Submitted Data)", $"Fill_Find_Customer_Submitted_Data_Grid_New: {Information.Err().Number.ToString()} - {excep.Message}");
			}

		} // Fill_Find_Customer_Submitted_Data_Grid


		private void cmdOwrOprRefresh_Click(Object eventSender, EventArgs eventArgs)
		{

			if (cmdOwrOprRefresh.Enabled)
			{

				cmdOwrOprRefresh.Enabled = false;

				Fill_Owner_Operator_Callback_Grid();

				cmdOwrOprRefresh.Enabled = true;

			} // If cmdOwrOprRefresh.Enabled = True Then

		} // cmdOwrOprRefresh_Click

		private void cmdFindDupsRefresh_Click(Object eventSender, EventArgs eventArgs)
		{

			if (cmdFindDupsRefresh.Enabled)
			{

				cmdFindDupsRefresh.Enabled = false;
				cmbFindDupReports.Enabled = false;

				if (cmbFindDupReports.Text != "")
				{
					Fill_Find_Duplicate_Callback_Grid();
				}

				cmbFindDupReports.Enabled = true;
				cmdFindDupsRefresh.Enabled = true;

			} // If cmdFindDupsRefresh.Enabled = True Then

		} // cmdFindDupsRefresh_Click

		private void cmdRefresh_Click(Object eventSender, EventArgs eventArgs)
		{

			if (mvHasFocus)
			{
				mvHasFocus = false;
			}

			cmdRefresh.Enabled = false;
			Fill_Callback_Grid();
			CheckForNewAvailables(cbo_account_id.Text);
			cmdRefresh.Enabled = true;

		}

		private void cmdRefreshAvailAircraft_Click(Object eventSender, EventArgs eventArgs)
		{

			if (mvHasFocus)
			{
				mvHasFocus = false;
			}

			Fill_AvailableAircraft_Grid();

		}

		private void cmdRefreshFractOwners_Click(Object eventSender, EventArgs eventArgs)
		{

			string strMsg = "";
			System.DateTime dtStartDate = DateTime.FromOADate(0);
			System.DateTime dtEndDate = DateTime.FromOADate(0);

			if (mvHasFocus)
			{
				mvHasFocus = false;
			}

			modCommon.Start_Activity_Monitor_Message("Callback Fractional Owners", ref strMsg, ref dtStartDate, ref dtEndDate);

			string strAcctRep = cbo_account_id.Text.Substring(0, Math.Min(2, cbo_account_id.Text.Length)).ToUpper();
			string strAcctRepId = cbo_account_id.Text.ToUpper();

			cmdRefreshFractOwners.Enabled = false;

			if (opt_OwnersPendingSale.Checked)
			{
				modAdminCommon.Record_Event("Monitor Activity", $"Fractional Owners Pending Sale - Selected AcctRep: {strAcctRepId}");
				Fill_Fractional_Owners_Pending_Sale_Grid();
			}
			if (optBadFractions.Checked)
			{
				modAdminCommon.Record_Event("Monitor Activity", $"Fractional Bad Fractions - Selected AcctRep: {strAcctRepId}");
				Fill_Bad_Fractions_Grid();
			}
			if (optFractionalOwners.Checked)
			{
				modAdminCommon.Record_Event("Monitor Activity", $"Fractional Owners Grid - Selected AcctRep: {strAcctRepId}");
				Fill_Fractional_Owner_Grid();
			}
			if (Opt_Reassigned.Checked)
			{
				modAdminCommon.Record_Event("Monitor Activity", $"Fractional ReAssign - Selected AcctRep: {strAcctRepId}");
				Fill_Fractional_ReAssign_Grid();
			}
			if (Opt_FracWithPrimaryWhole.Checked)
			{
				modAdminCommon.Record_Event("Monitor Activity", $"Fractional With Primary Whole - Selected AcctRep: {strAcctRepId}");
				Fill_FracWithPrimaryWhole_Grid();
			}

			//    If opt_OwnersPendingSale = True Then
			//    Record_Event "HB Usage", "Fractional Owners Pending Sale - Selected AcctRep: " & strAcctRepId
			//    Fill_Fractional_Owners_Pending_Sale_Grid
			//  End If
			//  If optBadFractions = True Then
			//    Record_Event "HB Usage", "Fractional Bad Fractions - Selected AcctRep: " & strAcctRepId
			//    Fill_Bad_Fractions_Grid
			//  End If
			//  If optFractionalOwners = True Then
			//    Record_Event "HB Usage", "Fractional Owners Grid - Selected AcctRep: " & strAcctRepId
			//    Fill_Fractional_Owner_Grid
			//  End If
			//  If Opt_Reassigned.Value = True Then
			//    Record_Event "HB Usage", "Fractional ReAssign - Selected AcctRep: " & strAcctRepId
			//    Fill_Fractional_ReAssign_Grid
			//  End If
			//  If Opt_FracWithPrimaryWhole.Value = True Then
			//    Record_Event "HB Usage", "Fractional With Primary Whole - Selected AcctRep: " & strAcctRepId
			//    Fill_FracWithPrimaryWhole_Grid
			//  End If
			//

			strMsg = $"AcctRep: {cbo_account_id.Text}";
			strMsg = $"{strMsg} Product: {cmbProductType.Text}";
			strMsg = $"{strMsg} Callback Date: {txt_Callback_Date.Text}";

			if (chk_Current_Acct_Rep.CheckState != CheckState.Unchecked)
			{
				strMsg = $"{strMsg} [x] Current Rep Only ";
			}
			if (chk_Date_Less_Than.CheckState != CheckState.Unchecked)
			{
				strMsg = $"{strMsg} [x] Date Less Than ";
			}
			if (optFractionalOwners.Checked)
			{
				strMsg = $"{strMsg} (*) FractOwners ";
			}
			if (optBadFractions.Checked)
			{
				strMsg = $"{strMsg} (*) Bad Fractions ";
			}
			if (opt_OwnersPendingSale.Checked)
			{
				strMsg = $"{strMsg} (*) Pending Sale ";
			}
			if (Opt_Reassigned.Checked)
			{
				strMsg = $"{strMsg} (*)  Reassigns ";
			}
			if (Opt_FracWithPrimaryWhole.Checked)
			{
				strMsg = $"{strMsg} (*) Primary On Whole ";
			}

			if (bLog)
			{

				modCommon.End_Activity_Monitor_Message("Callback Fractional Owners", ref strMsg, dtStartDate, ref dtEndDate, 0, 0, 0, 0, 0);

				frm_UserHistory.DefInstance.Refresh_User_History_Grids("Callback");

			}

			cmdRefreshFractOwners.Enabled = true;

		} // cmdRefreshFractOwners_Click

		private void cmdSelDClick_Click(Object eventSender, EventArgs eventArgs)
		{
			if (mvHasFocus)
			{
				mvHasFocus = false;
			}

			cmdSelDClick.Enabled = false;
			grd_Callbacks_DoubleClick(grd_Callbacks, new EventArgs());
			cmdSelDClick.Enabled = true;

		}

		private void cmdStop_Click(Object eventSender, EventArgs eventArgs)
		{
			Stopped = true;
			this.Cursor = CursorHelper.CursorDefault;
			if (mvHasFocus)
			{
				mvHasFocus = false;
			}
		}

		public void CheckForNewAvailables(string inAccountID = "")
		{

			try
			{

				string Query = "";
				ADORecordSetHelper snpPubs = new ADORecordSetHelper();
				string whichAcctID = "";


				// CHECK TO SEE IF THEIR ARE NEW AVAILABLES
				if (inAccountID.Trim() == "")
				{
					if (cbo_account_id.Text.Trim() == "")
					{
						cmd_New_Avail.Enabled = false;
						return;
					}
					else
					{
						whichAcctID = cbo_account_id.Text.Trim();
					}
				}
				else
				{
					whichAcctID = cbo_account_id.Text.Trim();
				}

				Query = "SELECT top 1 * FROM Publication_listing ";

				Query = $"{Query} WHERE publist_status in ('O','I')  ";

				Query = $"{Query} AND publist_acct_rep = '{whichAcctID.Trim()}' ";

				snpPubs.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpPubs.BOF && snpPubs.EOF))
				{
					cmd_New_Avail.Enabled = true;
					cmd_New_Avail.Font = cmd_New_Avail.Font.Change(bold:true);
				}
				else
				{
					cmd_New_Avail.Enabled = false;
				}

				snpPubs.Close();
				snpPubs = null;
			}
			catch
			{

				cmd_New_Avail.Enabled = false;
				search_off();
			}

		} // CheckForNewAvailables

		private void Form_Activated(Object eventSender, EventArgs eventArgs)
		{
			if (ActivateHelper.myActiveForm != eventSender)
			{
				ActivateHelper.myActiveForm = (Form) eventSender;

				bIsFormLoad = false;
				if (modAdminCommon.gbl_bHomeClicked)
				{
					this.Close();
					return;
				}

				modGlobalVars.tStart_Form = modCommon.pubf_DecodeStartForm(modGlobalVars.gcCALLBACKS);

				// 09/24/2002 - By David D. Cruger; If User Is the following then
				// enable the Verify Status Report Menu Option
				if (($" {Convert.ToString(modAdminCommon.snp_User["user_type"])}").Trim() == "Administrator" || ($" {Convert.ToString(modAdminCommon.snp_User["user_type"])}").Trim() == "Research Manager")
				{
					mnuViewVerifyStatusReport.Enabled = true;
					mnuViewVerifyStatusReport.Available = true;
				}
				else
				{
					mnuViewVerifyStatusReport.Enabled = false;
					mnuViewVerifyStatusReport.Available = false;
				}

			}
		} // Form_Activate

		public void Form_Initialize()
		{

			//--------------------------------------------------ALL MOVED FROM THE FORM ACTIVE --------- MSW -- 7/23/2014----------------

			//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			// Initialize the ToolBar

			//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			ToolbarSetup();
			ToolbarButtonsSetup();

			if (cbo_account_id.Visible && cbo_account_id.Enabled)
			{
				cbo_account_id.Focus();
			}

			SSTabHelper.SetTabVisible(tab_callback, 11, false); // rdp = 11
			SSTabHelper.SetTabVisible(tab_callback, 12, false); // airbp = 12
			SSTabHelper.SetTabVisible(tab_callback, 20, false); // unverified - 20

		} // Form_Initialize

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
		private void Form_Load()
		{

			bLog = false;

			bIsFormLoad = true;

			Stopped = false;
			cal_Callback.SetDate(DateTime.Parse(modAdminCommon.DateToday));
			txt_Callback_Date.Text = DateTime.Parse(modAdminCommon.DateToday).ToString("d");

			SSTabHelper.SetTabVisible(tab_callback, 13, false); // make the yacht tab invisible

			Fill_Product_Type();

			Fill_Color_Confirm_Type();

			Fill_Find_Duplicates_Reports();

			Fill_Find_Research_Reports();

			Fill_Timezones();

			Fill_TimeScale();

			Fill_Document_Type();

			// added MSW - 7/31/19
			modCommon.Fill_Country_Combo_Box(cbo_primary_country);


			if (mdi_ResearchAssistant.DefInstance.lbl_test_omg.Visible)
			{
				lbl_Test_omg.Visible = true;
			}



			cmd_Update_Callback_Dates.Visible = Convert.ToString(modAdminCommon.snp_User["user_id"]).Trim().ToLower() == "mvit";

			AlreadyLoaded = false;
			chk_Current_Acct_Rep.CheckState = CheckState.Checked; // Default the fractional owner tab to use the current account rep
			chk_Date_Less_Than.CheckState = CheckState.Checked; // default the fractional owner tab to use the current calendar date

			SSTabHelper.SetSelectedIndex(tab_callback, 0);
			chk_action_list[chkOnlyShowCBForAvail].CheckState = CheckState.Unchecked;
			chk_action_list[chkViewDocsOrdered].CheckState = CheckState.Unchecked;
			chk_action_list[chkViewDocsSending].CheckState = CheckState.Unchecked;

			lbl_Message.Text = "No Callbacks Selected!";
			strOrderBy = "ORDER BY comp_name,comp_city,comp_state, comp_id";
			SortField1 = "comp_name";
			SortField2 = "comp_city";
			SortField3 = "comp_state";

			strReassignOrderBy = "A1.ac_ser_no_full";

			// 06/10/2008 - By David D. Cruger
			// Per Lucia Fronteria this button should be de-activated
			// It is not to be used anywhere on this form
			cmdConfirmExclusive.Visible = false;
			cmdConfirmExclusive.Enabled = false;

			// RTW - 8/3/2007
			// default the reassign tab to only get 30 days of reassigns
			opt_last30.Checked = true;

			pnl_Callbacks.Visible = false;
			pnl_reassignemnt.Visible = false;

			Fill_Account_Rep_List();

			modCommon.SetComboText(cbo_account_id, Convert.ToString(modAdminCommon.snp_User["user_default_account_id"]));

			CheckForNewAvailables(cbo_account_id.Text);

			bLog = true;

			Fill_Callback_Grid();

			bLog = false;

			Fill_Find_Customer_Submitted_Data_Grid();

			bLog = true;

		} // Form_Load

		private void Form_MouseMove(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;

			if (HadHourglass)
			{
				this.Cursor = Cursors.WaitCursor;
			}

		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
			snp_NewAssign = null;
			snp_DocLog = null;
			snp_HotItems = null;
			snp_CompConfirm = null;
			snp_WantedList = null;
			snp_FractionsPending = null;
			snpFractional = null;
			snp_ExclusiveCallback = null;

		}


		//UPGRADE_NOTE: (7001) The following declaration (grd_AirBPCompanies_Click) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void grd_AirBPCompanies_Click()
		//{
			//
		//}

		//UPGRADE_NOTE: (7001) The following declaration (grd_AirBPCompanies_DblClick) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void grd_AirBPCompanies_DblClick()
		//{
			//
			//
		//}

		private void grd_AvailableAircraft_Click(Object eventSender, EventArgs eventArgs)
		{

			if (grd_AvailableAircraft.MouseRow > 0)
			{
				pnl_lstcompany.Visible = true;
				ShowAvailableAircraftCallbackInfo();
			}
			else
			{

				switch(grd_AvailableAircraft.MouseCol)
				{
					case 0 : 
						 
						strOrderBy = "ORDER BY comp_account_callback_date"; 
						 
						break;
					case 1 : 
						 
						strOrderBy = "ORDER BY comp_name"; 
						 
						break;
					case 2 : 
						 
						strOrderBy = "ORDER BY comp_city, comp_country"; 
						 
						break;
					case 3 : 
						 
						strOrderBy = "ORDER BY comp_state"; 
						 
						break;
					case 4 : 
						 
						strOrderBy = "ORDER BY comp_timezone"; 
						 
						break;
					case 5 : 
						 
						// 07/14/2015 - By David D. Cruger 
						// Per Jackie; Have this sort by oldest date first 
						strOrderBy = "ORDER BY comp_last_contact_date"; 
						break;
					case 6 : 
						strOrderBy = "ORDER BY dtJNiQLastAttemptedDate"; 
						 
						break;
				}

				Fill_AvailableAircraft_Grid();
			}

		}

		private void grd_AvailableAircraft_DoubleClick(Object eventSender, EventArgs eventArgs)
		{


			// cleanup any contact forms and open a clean form
			modCommon.Unload_Form("frm_Company");

			frm_Company o_Local_Show_Company = frm_Company.CreateInstance();
			//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			//VB.Global.Load(o_Local_Show_Company);
			o_Local_Show_Company.Form_Initialize();
			o_Local_Show_Company.StartForm = modGlobalVars.tStart_Form;
			o_Local_Show_Company.Reference_CompanyID = grd_AvailableAircraft.get_RowData(grd_AvailableAircraft.CurrentRowIndex);
			o_Local_Show_Company.Reference_CompanyJID = 0;
			o_Local_Show_Company.Show();
			//UPGRADE_WARNING: (2065) Form method o_Local_Show_Company.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
			o_Local_Show_Company.BringToFront();
			//UPGRADE_WARNING: (2065) Form event Form.Activated has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
			o_Local_Show_Company.Form_Activated(null, new EventArgs());

		}

		private void Set_Primary_Callback_Order_By(int lRow1, int lCol1)
		{

			string strOrderBy = "";

			if (lRow1 == 0)
			{

				grd_Callbacks.CurrentColumnIndex = lCol1;

				if (chk_action_list[chkShowIQCompleted].CheckState == CheckState.Checked || chk_action_list[chkHideIQDeclined].CheckState == CheckState.Checked)
				{

					switch(lCol1)
					{
						case 0 :  // CompId 
							strOrderBy = "ORDER BY comp_id"; 
							grd_Callbacks.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortStringAscending)); 
							 
							break;
						case 1 :  // Date 
							strOrderBy = "ORDER BY comp_account_callback_date, comp_name,comp_city,comp_state, comp_country"; 
							grd_Callbacks.CurrentColumnIndex = 12; 
							//UPGRADE_WARNING: (2065) MSHierarchicalFlexGridLib.SortSettings property SortSettings.flexSortNumericAscending has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065 
							grd_Callbacks.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortNumericAscending)); 
							 
							break;
						case 2 :  // Company 
							strOrderBy = "ORDER BY comp_city, comp_state, comp_country, comp_name, comp_id"; 
							grd_Callbacks.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortStringAscending)); 
							 
							break;
						case 3 :  // Location 
							strOrderBy = "ORDER BY comp_city, comp_state, comp_country, comp_name, comp_id"; 
							grd_Callbacks.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortStringAscending)); 
							 
							break;
						case 4 :  // Time Zone 
							strOrderBy = "ORDER BY comp_timezone, comp_account_callback_date, comp_id"; 
							grd_Callbacks.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortStringAscending)); 
							break;
						case 5 :  // Last Attempted Callback 
							strOrderBy = "ORDER BY comp_last_contact_date, comp_name"; 
							grd_Callbacks.CurrentColumnIndex = 8; 
							//UPGRADE_WARNING: (2065) MSHierarchicalFlexGridLib.SortSettings property SortSettings.flexSortNumericAscending has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065 
							grd_Callbacks.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortNumericAscending)); 
							 
							break;
						case 6 :  // JNiQ Last Attempted Date 
							strOrderBy = "ORDER BY dtJNiQLastAttemptedDate, comp_name"; 
							grd_Callbacks.CurrentColumnIndex = 9; 
							//UPGRADE_WARNING: (2065) MSHierarchicalFlexGridLib.SortSettings property SortSettings.flexSortNumericAscending has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065 
							grd_Callbacks.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortNumericAscending)); 
							 
							break;
						case 7 :  // JNiQ Last Completed Date 
							strOrderBy = "ORDER BY dtJNiQLastAttemptedDate, comp_name"; 
							grd_Callbacks.CurrentColumnIndex = 10; 
							//UPGRADE_WARNING: (2065) MSHierarchicalFlexGridLib.SortSettings property SortSettings.flexSortNumericAscending has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065 
							grd_Callbacks.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortNumericAscending)); 
							 
							break;
						default:
							strOrderBy = "ORDER BY comp_account_callback_date, comp_name, comp_city, comp_state, comp_country"; 
							grd_Callbacks.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortStringAscending)); 
							 
							break;
					} // Case lCol1
				}
				else
				{
					switch(lCol1)
					{
						case 0 :  // CompId 
							strOrderBy = "ORDER BY comp_id"; 
							grd_Callbacks.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortStringAscending)); 
							 
							break;
						case 1 :  // Date 
							strOrderBy = "ORDER BY comp_account_callback_date, comp_name,comp_city,comp_state, comp_country"; 
							grd_Callbacks.CurrentColumnIndex = 12; 
							//UPGRADE_WARNING: (2065) MSHierarchicalFlexGridLib.SortSettings property SortSettings.flexSortNumericAscending has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065 
							grd_Callbacks.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortNumericAscending)); 
							 
							break;
						case 2 :  // Company 
							strOrderBy = "ORDER BY comp_city, comp_state, comp_country, comp_name, comp_id"; 
							grd_Callbacks.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortStringAscending)); 
							 
							break;
						case 3 :  // Location 
							strOrderBy = "ORDER BY comp_city, comp_state, comp_country, comp_name, comp_id"; 
							grd_Callbacks.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortStringAscending)); 
							 
							break;
						case 4 :  // State 
							strOrderBy = "ORDER BY comp_state, comp_city, comp_country, comp_id"; 
							grd_Callbacks.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortStringAscending)); 
							 
							break;
						case 5 :  // Time Zone 
							strOrderBy = "ORDER BY comp_timezone, comp_account_callback_date, comp_id"; 
							grd_Callbacks.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortStringAscending)); 
							 
							break;
						case 6 :  // # of Aircraft 
							 
							//UPGRADE_WARNING: (2065) MSHierarchicalFlexGridLib.SortSettings property SortSettings.flexSortNumericAscending has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065 
							grd_Callbacks.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortNumericAscending)); 
							 
							break;
						case 7 :  // Last Attempted Callback 
							strOrderBy = "ORDER BY comp_last_contact_date, comp_name"; 
							grd_Callbacks.CurrentColumnIndex = 13; 
							//UPGRADE_WARNING: (2065) MSHierarchicalFlexGridLib.SortSettings property SortSettings.flexSortNumericAscending has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065 
							grd_Callbacks.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortNumericAscending)); 
							 
							break;
						case 8 :  // JNiQ Last Attempted Date 
							strOrderBy = "ORDER BY dtJNiQLastAttemptedDate, comp_name"; 
							grd_Callbacks.CurrentColumnIndex = 14; 
							//UPGRADE_WARNING: (2065) MSHierarchicalFlexGridLib.SortSettings property SortSettings.flexSortNumericAscending has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065 
							grd_Callbacks.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortNumericAscending)); 
							 
							break;
						case 9 :  // JNiQ Last Completed Date 
							strOrderBy = "ORDER BY dtJNiQLastAttemptedDate, comp_name"; 
							grd_Callbacks.CurrentColumnIndex = 15; 
							//UPGRADE_WARNING: (2065) MSHierarchicalFlexGridLib.SortSettings property SortSettings.flexSortNumericAscending has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065 
							grd_Callbacks.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortNumericAscending)); 
							 
							break;
						case 10 :  // Service 
							strOrderBy = "ORDER BY CompService, comp_name"; 
							grd_Callbacks.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortStringAscending)); 
							 
							break;
						case 11 :  // Sub-Service 
							strOrderBy = "ORDER BY ActiveSubService, comp_name"; 
							grd_Callbacks.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortStringAscending)); 
							 
							break;
						default:
							strOrderBy = "ORDER BY comp_account_callback_date, comp_name, comp_city, comp_state, comp_country"; 
							grd_Callbacks.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortStringAscending)); 
							 
							break;
					} // Case lCol1
				}




				grd_Callbacks.CurrentColumnIndex = lCol1;

				grd_Callbacks.Tag = strOrderBy;

			} // If lRow1 = 0 Then

		} // Set_Primary_Callback_Order_By

		private void grd_Callbacks_Click(Object eventSender, EventArgs eventArgs)
		{


			pnl_lstcompany.Visible = true;

			int lRow1 = grd_Callbacks.MouseRow;
			int lCol1 = grd_Callbacks.MouseCol;

			if (lRow1 == 0)
			{
				Set_Primary_Callback_Order_By(lRow1, lCol1);
			}
			else
			{

				Show_Callback_Company_Info();

				//aey 12/2/04 -- highlight row
				grd_Callbacks.CurrentColumnIndex = 1;
				grd_Callbacks.ColSel = 5;
				grd_Callbacks.RowSel = grd_Callbacks.CurrentRowIndex;
				cmdSelDClick.Visible = true;

			} // ' If lRow1 = 0 Then

		} // grd_Callbacks_Click

		private void grd_Callbacks_DoubleClick(Object eventSender, EventArgs eventArgs)
		{

			Select_Callback();
			grd_Callbacks.Enabled = true;

		}

		private void grd_Callbacks_MouseMove(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;

			if (HadHourglass)
			{
				this.Cursor = Cursors.WaitCursor;
			}

		}


		//UPGRADE_NOTE: (7001) The following declaration (display_airbp_remarks) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void display_airbp_remarks(string inLeasedAC, string incompid)
		//{
			//
			//StringBuilder tmpLeaseInfo = new StringBuilder();
			//ADORecordSetHelper ado_leasinfo = new ADORecordSetHelper();
			//
			//
			//
			//string tmpResponse = "";
			//int LeasedOut = 0;
			//int Leased = 0;
			//
			//// ********************************************************************************
			//// GET SUBLSD FROM AIRCRAFT COUNTS
			//string Query = "select distinct cref_contact_type, comp_name, comp_product_airbp_flag,count(*) as tcount ";
			//Query = $"{Query}From Aircraft ";
			//Query = $"{Query}INNER JOIN Aircraft_Reference  on ac_id = cref_ac_id and ac_journ_id = cref_journ_id ";
			//Query = $"{Query}INNER JOIN Company ON comp_id = cref_comp_id and comp_journ_id = cref_journ_id ";
			//Query = $"{Query}Where ac_journ_id = 0 ";
			//Query = $"{Query}and cref_contact_type ='57' ";
			//Query = $"{Query}and ac_id in ({inLeasedAC}) ";
			//Query = $"{Query}and comp_id <> {incompid} ";
			//
			//// GET JUST A LIST OF COMPANIES FOR AIRCRAFT THAT I AM THE SUBLESSEE
			//Query = $"{Query}and ac_id in (select distinct cref_ac_id from aircraft_reference ";
			//Query = $"{Query}where cref_ac_id in ({inLeasedAC}) ";
			//Query = $"{Query}and cref_contact_type='39' ";
			//Query = $"{Query}and cref_comp_id={incompid})";
			//
			//Query = $"{Query}group by cref_contact_type, comp_name, comp_product_airbp_flag ";
			//Query = $"{Query}order by comp_name";
			//
			//ado_leasinfo.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
			//if (!(ado_leasinfo.EOF && ado_leasinfo.BOF))
			//{
				//ado_leasinfo.MoveFirst();
				//
				//
				//while(!ado_leasinfo.EOF)
				//{
					//if (Convert.ToString(ado_leasinfo["comp_product_airbp_flag"]) == "Y")
					//{
						//tmpResponse = $"{Convert.ToString(ado_leasinfo["tcount"])} SubLsd From {Convert.ToString(ado_leasinfo["comp_name"])}";
					//}
					//else
					//{
						//// LEASED FROM COMPANY OTHER THAN AIRLINE COMPANY
						//Leased = Convert.ToInt32(Leased + Convert.ToDouble(ado_leasinfo["tcount"]));
					//}
					//tmpResponse = StringsHelper.Replace(tmpResponse, "Corporation", "Corp", 1, -1, CompareMethod.Binary);
					//
					//// ADD THE COMPANY INFORMATION TO THE LEASE INFORMATION
					//if (Strings.Len(tmpResponse.Trim()) > 0)
					//{
						//if (Strings.Len(tmpLeaseInfo.ToString().Trim()) > 0)
						//{
							//tmpLeaseInfo.Append($",{tmpResponse}");
						//}
						//else
						//{
							//tmpLeaseInfo = new StringBuilder(tmpResponse);
						//}
					//}
					//
					//ado_leasinfo.MoveNext();
				//};
				//ado_leasinfo.Close();
			//}
			//Application.DoEvents();
			//ado_leasinfo = null;
			//
			//// ********************************************************************************
			//// GET LEASED FROM AIRCRAFT COUNTS WHERE MY COMP IS THE LESSEE
			//Query = "select distinct cref_contact_type, comp_name, comp_product_airbp_flag,count(*) as tcount ";
			//Query = $"{Query}From Aircraft ";
			//Query = $"{Query}INNER JOIN Aircraft_Reference  on ac_id = cref_ac_id and ac_journ_id = cref_journ_id ";
			//Query = $"{Query}INNER JOIN Company ON comp_id = cref_comp_id and comp_journ_id = cref_journ_id ";
			//Query = $"{Query}Where ac_journ_id = 0 ";
			//Query = $"{Query}and cref_contact_type ='13' ";
			//Query = $"{Query}and ac_id in ({inLeasedAC}) ";
			//Query = $"{Query}and comp_id <> {incompid} ";
			//
			//// GET JUST A LIST OF COMPANIES FOR AIRCRAFT THAT I AM THE SUBLESSEE
			//Query = $"{Query}and ac_id in (select distinct cref_ac_id from aircraft_reference ";
			//Query = $"{Query}where cref_ac_id in ({inLeasedAC}) ";
			//Query = $"{Query}and cref_contact_type='12' ";
			//Query = $"{Query}and cref_comp_id={incompid})";
			//
			//Query = $"{Query}group by cref_contact_type, comp_name, comp_product_airbp_flag ";
			//Query = $"{Query}order by comp_name";
			//
			//ado_leasinfo.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
			//if (!(ado_leasinfo.EOF && ado_leasinfo.BOF))
			//{
				//ado_leasinfo.MoveFirst();
				//
				//
				//while(!ado_leasinfo.EOF)
				//{
					//if (Convert.ToString(ado_leasinfo["comp_product_airbp_flag"]) == "Y")
					//{
						//tmpResponse = $"{Convert.ToString(ado_leasinfo["tcount"])} Leased From {Convert.ToString(ado_leasinfo["comp_name"])}";
					//}
					//else
					//{
						//// LEASED FROM COMPANY OTHER THAN AIRLINE COMPANY
						//Leased = Convert.ToInt32(Leased + Convert.ToDouble(ado_leasinfo["tcount"]));
					//}
					//tmpResponse = StringsHelper.Replace(tmpResponse, "Corporation", "Corp", 1, -1, CompareMethod.Binary);
					//// ADD THE COMPANY INFORMATION TO THE LEASE INFORMATION
					//if (Strings.Len(tmpResponse.Trim()) > 0)
					//{
						//if (Strings.Len(tmpLeaseInfo.ToString().Trim()) > 0)
						//{
							//tmpLeaseInfo.Append($",{tmpResponse}");
						//}
						//else
						//{
							//tmpLeaseInfo = new StringBuilder(tmpResponse);
						//}
					//}
					//
					//ado_leasinfo.MoveNext();
				//};
				//ado_leasinfo.Close();
			//}
			//Application.DoEvents();
			//ado_leasinfo = null;
			//
			//
			//// ********************************************************************************
			//// GET SUBLSD TO AIRCRAFT COUNTS
			//Query = "select distinct cref_contact_type, comp_name, comp_product_airbp_flag,count(*) as tcount ";
			//Query = $"{Query}From Aircraft ";
			//Query = $"{Query}INNER JOIN Aircraft_Reference  on ac_id = cref_ac_id and ac_journ_id = cref_journ_id ";
			//Query = $"{Query}INNER JOIN Company ON comp_id = cref_comp_id and comp_journ_id = cref_journ_id ";
			//Query = $"{Query}Where ac_journ_id = 0 ";
			//Query = $"{Query}and cref_contact_type ='39' ";
			//Query = $"{Query}and ac_id in ({inLeasedAC}) ";
			//Query = $"{Query}and comp_id <> {incompid} ";
			//
			//// GET JUST A LIST OF COMPANIES FOR AIRCRAFT THAT I AM THE SUBLESSOR
			//Query = $"{Query}and ac_id in (select distinct cref_ac_id from aircraft_reference ";
			//Query = $"{Query}where cref_ac_id in ({inLeasedAC}) ";
			//Query = $"{Query}and cref_contact_type='57' ";
			//Query = $"{Query}and cref_comp_id={incompid})";
			//
			//Query = $"{Query}group by cref_contact_type, comp_name, comp_product_airbp_flag ";
			//Query = $"{Query}order by comp_name";
			//
			//ado_leasinfo.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
			//if (!(ado_leasinfo.EOF && ado_leasinfo.BOF))
			//{
				//ado_leasinfo.MoveFirst();
				//
				//
				//while(!ado_leasinfo.EOF)
				//{
					//if (Convert.ToString(ado_leasinfo["comp_product_airbp_flag"]) == "Y")
					//{
						//tmpResponse = $"{Convert.ToString(ado_leasinfo["tcount"])} SubLsd To {Convert.ToString(ado_leasinfo["comp_name"])}";
					//}
					//else
					//{
						//// LEASED TO COMPANY OTHER THAN AIRLINE COMPANY
						//LeasedOut = Convert.ToInt32(LeasedOut + Convert.ToDouble(ado_leasinfo["tcount"]));
					//}
					//tmpResponse = StringsHelper.Replace(tmpResponse, "Corporation", "Corp", 1, -1, CompareMethod.Binary);
					//// ADD THE COMPANY INFORMATION TO THE LEASE INFORMATION
					//if (Strings.Len(tmpResponse.Trim()) > 0)
					//{
						//if (Strings.Len(tmpLeaseInfo.ToString().Trim()) > 0)
						//{
							//tmpLeaseInfo.Append($",{tmpResponse}");
						//}
						//else
						//{
							//tmpLeaseInfo = new StringBuilder(tmpResponse);
						//}
					//}
					//
					//ado_leasinfo.MoveNext();
				//};
				//ado_leasinfo.Close();
			//}
			//Application.DoEvents();
			//ado_leasinfo = null;
			//
			//
			//// ********************************************************************************
			//// GET LEASED TO AIRCRAFT COUNTS - WHERE MY COMPANY IS THE LESSOR
			//Query = "select distinct cref_contact_type, comp_name, comp_product_airbp_flag,count(*) as tcount ";
			//Query = $"{Query}From Aircraft ";
			//Query = $"{Query}INNER JOIN Aircraft_Reference  on ac_id = cref_ac_id and ac_journ_id = cref_journ_id ";
			//Query = $"{Query}INNER JOIN Company ON comp_id = cref_comp_id and comp_journ_id = cref_journ_id ";
			//Query = $"{Query}Where ac_journ_id = 0 ";
			//Query = $"{Query}and cref_contact_type ='12' ";
			//Query = $"{Query}and ac_id in ({inLeasedAC}) ";
			//Query = $"{Query}and comp_id <> {incompid} ";
			//
			//// GET JUST A LIST OF COMPANIES FOR AIRCRAFT THAT I AM THE LESSOR
			//Query = $"{Query}and ac_id in (select distinct cref_ac_id from aircraft_reference ";
			//Query = $"{Query}where cref_ac_id in ({inLeasedAC}) ";
			//Query = $"{Query}and cref_contact_type='13' ";
			//Query = $"{Query}and cref_comp_id={incompid})";
			//
			//Query = $"{Query}group by cref_contact_type, comp_name, comp_product_airbp_flag ";
			//Query = $"{Query}order by comp_name";
			//
			//ado_leasinfo.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
			//if (!(ado_leasinfo.EOF && ado_leasinfo.BOF))
			//{
				//ado_leasinfo.MoveFirst();
				//
				//
				//while(!ado_leasinfo.EOF)
				//{
					//if (Convert.ToString(ado_leasinfo["comp_product_airbp_flag"]) == "Y")
					//{
						//tmpResponse = $"{Convert.ToString(ado_leasinfo["tcount"])} Leased To {Convert.ToString(ado_leasinfo["comp_name"])}";
					//}
					//else
					//{
						//// LEASED TO COMPANY OTHER THAN AIRLINE COMPANY
						//LeasedOut = Convert.ToInt32(LeasedOut + Convert.ToDouble(ado_leasinfo["tcount"]));
					//}
					//tmpResponse = StringsHelper.Replace(tmpResponse, "Corporation", "Corp", 1, -1, CompareMethod.Binary);
					//// ADD THE COMPANY INFORMATION TO THE LEASE INFORMATION
					//if (Strings.Len(tmpResponse.Trim()) > 0)
					//{
						//if (Strings.Len(tmpLeaseInfo.ToString().Trim()) > 0)
						//{
							//tmpLeaseInfo.Append($",{tmpResponse}");
						//}
						//else
						//{
							//tmpLeaseInfo = new StringBuilder(tmpResponse);
						//}
					//}
					//
					//ado_leasinfo.MoveNext();
				//};
				//ado_leasinfo.Close();
			//}
			//Application.DoEvents();
			//ado_leasinfo = null;
			//
			//
			//// ADD THE TOTAL AIRCRAFT LEASED OUT
			//if (LeasedOut > 0)
			//{
				//tmpResponse = $"{LeasedOut.ToString()} Lsd Out";
				//if (Strings.Len(tmpLeaseInfo.ToString().Trim()) > 0)
				//{
					//tmpLeaseInfo.Append($",{tmpResponse}");
				//}
				//else
				//{
					//tmpLeaseInfo = new StringBuilder(tmpResponse);
				//}
			//}
			//
			//
			//text_airbp_remarks.Text = tmpLeaseInfo.ToString();
		//}


		private void grd_CompConfirm_Click(Object eventSender, EventArgs eventArgs)
		{

			string strOrderBy = "";

			int lMouseRow = grd_CompConfirm.MouseRow;
			int lMouseCol = grd_CompConfirm.MouseCol;

			if (lMouseRow > 0)
			{

				pnl_lstcompany.Visible = true;
				Show_Company_Color_Confirm_Info();

				grd_CompConfirm.CurrentRowIndex = lMouseRow;
				modCommon.Highlight_Grid_Row(grd_CompConfirm);

			}
			else
			{

				switch(lMouseCol)
				{
					case 0 : 
						strOrderBy = "Date"; 
						break;
					case 1 : 
						strOrderBy = "Name"; 
						break;
					case 2 : 
						strOrderBy = "City/State"; 
						break;
					case 3 : 
						strOrderBy = "Time Zone"; 
						break;
					case 4 : 
						strOrderBy = "Last Attempt"; 
						 
						break;
					case 7 : 
						 
						strOrderBy = "dtJNiQLastAttemptedDate"; 
						break;
				} // Case lMouseCol

				if (Convert.ToString(grd_CompConfirm.Tag) != strOrderBy)
				{

					grd_CompConfirm.Tag = strOrderBy;
					grd_CompConfirm.CurrentColumnIndex = lMouseCol;

					switch(lMouseCol)
					{
						case 0 :  // Date 
							grd_CompConfirm.CurrentColumnIndex = 5;  // Sort Date 
							//UPGRADE_WARNING: (2065) MSHierarchicalFlexGridLib.SortSettings property SortSettings.flexSortNumericAscending has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065 
							grd_CompConfirm.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortNumericAscending)); 
							break;
						case 4 :  // Last Attempt 
							grd_CompConfirm.CurrentColumnIndex = 6;  // Sort Date 
							//UPGRADE_WARNING: (2065) MSHierarchicalFlexGridLib.SortSettings property SortSettings.flexSortNumericAscending has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065 
							grd_CompConfirm.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortNumericAscending)); 
							break;
						default:
							grd_CompConfirm.Sort(new UpgradeHelpers.FlexComparer(UpgradeHelpers.SortSettings.SortGenericAscending)); 
							break;
					}

					grd_CompConfirm.CurrentColumnIndex = lMouseCol;


					Fill_Comp_Confirm_Grid(strOrderBy);

				}
				else
				{
					modCommon.Clear_Grid_Row(grd_CompConfirm);
				}

			} // If lMouseRow > 0 Then

		} // grd_CompConfirm_Click

		private void grd_CompConfirm_DoubleClick(Object eventSender, EventArgs eventArgs)
		{


			int lRow1 = grd_CompConfirm.CurrentRowIndex;
			int lCol1 = grd_CompConfirm.CurrentColumnIndex;

			if (lRow1 > 0)
			{
				Show_Company_Color_Confirm_Info();
				Select_Company_Color_Confirm();
			}

		}

		private void grd_DocumentLog_DoubleClick(Object eventSender, EventArgs eventArgs)
		{

			int i = 0;
			int temp_col = 0;
			lbl_gen[36].Visible = false;
			cmbDocType.Visible = false;


			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (Convert.IsDBNull(form_direction))
			{
				form_direction = "asc";
			}
			else if (form_direction.Trim() == "")
			{ 
				form_direction = "asc";
			}
			else if (form_direction.Trim() == "asc")
			{ 
				form_direction = "desc";
			}
			else if (form_direction.Trim() == "desc")
			{ 
				form_direction = "asc";
			}


			if (grd_DocumentLog.MouseRow > 0)
			{

				modAdminCommon.gbl_Aircraft_ID = grd_DocumentLog.get_RowData(grd_DocumentLog.CurrentRowIndex);
				modAdminCommon.gbl_Aircraft_Journal_ID = 0;

				frm_aircraft.DefInstance.Form_Initialize();
				frm_aircraft.DefInstance.StartForm = modGlobalVars.tStart_Form;
				frm_aircraft.DefInstance.Reference_Aircraft_ID = modAdminCommon.gbl_Aircraft_ID;
				frm_aircraft.DefInstance.Reference_Journal_ID = modAdminCommon.gbl_Aircraft_Journal_ID;
				frm_aircraft.DefInstance.Reference_Company_ID = 0;
				frm_aircraft.DefInstance.Show();
				//UPGRADE_WARNING: (2065) Form method frm_aircraft.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
				frm_aircraft.DefInstance.BringToFront();
				//UPGRADE_WARNING: (2065) Form event Form.Activated has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
				frm_aircraft.DefInstance.Form_Activated(frm_aircraft.DefInstance, new EventArgs());

			}
			else
			{


				Application.DoEvents();
				Application.DoEvents();
				Application.DoEvents();
				Application.DoEvents();
				Application.DoEvents();

				if (is_compact_view == "Y")
				{

					Application.DoEvents();
					Application.DoEvents();
					Application.DoEvents();
					Application.DoEvents();
					Application.DoEvents();

					temp_col = grd_DocumentLog.MouseCol;

					Application.DoEvents();
					Application.DoEvents();
					Application.DoEvents();
					Application.DoEvents();
					Application.DoEvents();


					switch(temp_col)
					{
						case 0 : 
							DocumentsOrderBy = $"ORDER BY amod_make_name {form_direction}, amod_model_name {form_direction}, ac_ser_no_full {form_direction}"; 
							DocResponseOrderBy = $"ORDER BY amod_make_name {form_direction}, amod_model_name {form_direction}, ac_ser_no_full {form_direction}"; 
							break;
						case 1 : 
							DocumentsOrderBy = $"ORDER BY faalog_update_date {form_direction}"; 
							DocResponseOrderBy = $"ORDER BY journ_date  {form_direction}, .Journ_id  {form_direction} "; 
							break;
						case 2 : 
							DocumentsOrderBy = $"ORDER BY faalog_doc_type {form_direction}"; 
							DocResponseOrderBy = $"ORDER BY Journ_user_id {form_direction}"; 
							break;
						case 3 : 
							DocumentsOrderBy = $"ORDER BY faalog_tape_no {form_direction}"; 
							DocResponseOrderBy = $"ORDER BY Journ_Subject {form_direction}"; 
							break;
						case 4 : 
							DocumentsOrderBy = $"ORDER BY faalog_tape_date {form_direction}"; 
							 
							break;
						case 5 : 
							DocumentsOrderBy = $"ORDER BY faalog_document_date {form_direction}"; 
							 
							break;
						case 6 : 
							DocumentsOrderBy = $"ORDER BY faalog_starting_frame_no {form_direction}"; 
							 
							break;
						case 7 : 
							DocumentsOrderBy = $"ORDER BY faalog_ending_frame_no {form_direction}"; 
							 
							break;
						case 8 : 
							DocumentsOrderBy = $"ORDER BY faalog_rolled_by_user_id {form_direction}"; 
							 
							break;
						case 9 : 
							DocumentsOrderBy = $"ORDER BY faalog_user_id {form_direction}"; 
							 
							break;
						case 10 : 
							DocumentsOrderBy = $"ORDER BY faalog_id {form_direction}"; 
							 
							break;
						case 13 : 
							DocumentsOrderBy = $"ORDER BY  comp_state  {form_direction}"; 
							 
							break;
						case 14 : case 15 : 
							DocumentsOrderBy = $"ORDER BY comp_country  {form_direction}, comp_state  {form_direction}"; 
							 
							break;
					}
				}
				else
				{

					switch(grd_DocumentLog.MouseCol)
					{
						case 0 : 
							DocumentsOrderBy = $"ORDER BY amod_make_name {form_direction}, amod_model_name {form_direction}, ac_ser_no_full {form_direction}"; 
							DocResponseOrderBy = $"ORDER BY amod_make_name {form_direction}, amod_model_name {form_direction}, ac_ser_no_full {form_direction}"; 
							break;
						case 1 : 
							DocumentsOrderBy = $"ORDER BY faalog_update_date {form_direction}"; 
							DocResponseOrderBy = $"ORDER BY journ_date  {form_direction}, .Journ_id  {form_direction}"; 
							break;
						case 2 : 
							DocumentsOrderBy = $"ORDER BY faalog_doc_type {form_direction}"; 
							DocResponseOrderBy = $"ORDER BY Journ_user_id {form_direction}"; 
							break;
						case 3 : 
							DocumentsOrderBy = $"ORDER BY faalog_tape_no {form_direction}"; 
							DocResponseOrderBy = $"ORDER BY Journ_Subject {form_direction}"; 
							break;
						case 4 : 
							DocumentsOrderBy = $"ORDER BY faalog_tape_date {form_direction}"; 
							 
							break;
						case 5 : 
							DocumentsOrderBy = $"ORDER BY faalog_document_date {form_direction}"; 
							 
							break;
						case 6 : 
							DocumentsOrderBy = $"ORDER BY faalog_starting_frame_no {form_direction}"; 
							 
							break;
						case 7 : 
							DocumentsOrderBy = $"ORDER BY faalog_ending_frame_no {form_direction}"; 
							 
							break;
						case 8 : 
							DocumentsOrderBy = $"ORDER BY faalog_rolled_by_user_id {form_direction}"; 
							 
							break;
						case 9 : 
							DocumentsOrderBy = $"ORDER BY faalog_user_id {form_direction}"; 
							 
							break;
						case 10 : 
							DocumentsOrderBy = $"ORDER BY faalog_id {form_direction}"; 
							 
							break;
						case 11 : 
							DocumentsOrderBy = $"ORDER BY faalog_general_note {form_direction}"; 
							 
							break;
						case 12 : 
							// ADDED MSW - 3/9/20 asked to be sortable 
							DocumentsOrderBy = $" ORDER BY ( select top 1 journ_date from Journal with (NOLOCK) where journ_ac_id = A1.ac_id and journ_subject like '%Doc Attempted%' and J1.journ_date >= (getdate() - 540)  order by journ_date desc )    {form_direction}"; 

							 
							break;
					}
				}


				cmd_DocsInProcessRefresh_Click(cmd_DocsInProcessRefresh, new EventArgs());

			}

		}

		private void grd_DocumentLog_MouseDown(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;
			//aey 7/15/04 clear document log entries
			int nGridCol = 0;
			string Query = "";
			string Msg = "";

			int lRow1 = 0;
			int lCol1 = 0;

			try
			{

				lRow1 = grd_DocumentLog.MouseRow;
				lCol1 = grd_DocumentLog.MouseCol;

				if (lRow1 > 0 && lCol1 > 0)
				{

					if (Button == UpgradeHelpers.Utils.WinForms.MouseButtonsHelper.GetVB6ShortValue(MouseButtons.Right))
					{

						if (Convert.ToString(grd_DocumentLog[1, 0].Value) != "No Documents Found.")
						{

							if (chkResponses.CheckState == CheckState.Checked)
							{

								if (MessageBox.Show("Do you want to clear this Document Response?", "Clear Document Response", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
								{

									nGridCol = grd_DocumentLog.CurrentColumnIndex;
									grd_DocumentLog.CurrentColumnIndex = 3;
									Msg = $"DR Cleared {DateTime.Parse(modAdminCommon.DateToday).ToString("d")} {grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].FormattedValue.ToString().Trim()}";
									Msg = StringsHelper.Replace(Msg, "'", "", 1, -1, CompareMethod.Binary);

									Query = $"UPDATE journal SET journ_subcategory_code = 'RDRC', Journ_Subject = '{Msg.Substring(0, Math.Min(120, Msg.Length)).Trim()}'";
									//UPGRADE_ISSUE: (2064) MSHierarchicalFlexGridLib.MSHFlexGrid property grd_DocumentLog.BandData was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
									Query = $"{Query} WHERE journ_id = {grd_DocumentLog.BandData(grd_DocumentLog.CurrentRowIndex).ToString().Trim()}";

									grd_DocumentLog.CurrentColumnIndex = nGridCol;

									DbCommand TempCommand = null;
									TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
									UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
									TempCommand.CommandText = Query;
									TempCommand.CommandType = CommandType.Text;
									UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
									TempCommand.ExecuteNonQuery();
									Fill_Document_Responses();

								} // If MsgBox("Do you want to clear this Document Response?", vbQuestion + vbYesNo + vbDefaultButton1, "Clear Document Response") = vbYes Then

							}
							else
							{

								if (lCol1 == 2)
								{ // Document Type

									//--------------------------------------------------
									// Click on the Document Type To Change

									grd_DocumentLog.CurrentRowIndex = lRow1;

									modCommon.Highlight_Grid_Row(grd_DocumentLog);

									mnuChangeDocType.Available = true;

									modCommon.Highlight_Grid_Row(grd_DocumentLog);

									//UPGRADE_WARNING: (6024) Default menues are not supported for Context Menues (Popup) More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6024
									Ctx_mnuRightClickCallback.Show(this, PointToClient(Cursor.Position).X, PointToClient(Cursor.Position).Y);
									grd_DocumentLog.Redraw = true;

								} // If lCol1 = 2 Then ' Document Type

							} // If chkResponses.Value = 1 Then

						} // If grd_DocumentLog.TextMatrix(1, 0) <> "No Documents Found." Then

					} // If Button = vbRightButton Then

				} // If lRow1 > 0 And lCol1 > 0 Then
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"grd_DocumentLog_MouseDown_error: {excep.Message} {Msg}");
			}

		}


		private void grd_Exclusives_Click(Object eventSender, EventArgs eventArgs)
		{
			if (grd_Exclusives.MouseRow > 0)
			{
				pnl_lstcompany.Visible = true;
				//  cmd_Confirm_Reassign.Visible = True
				//  lbl_gen(4).Visible = True
				//  txt_next_confirm_date.Visible = True
				//  cmd_Confirm_Reassign.Caption = "Confirm Exclusive"
				ShowExclusiveCompanyInfo();
				ShowPrimaryCompanyInfo();
			}

		}

		private void grd_Exclusives_DoubleClick(Object eventSender, EventArgs eventArgs)
		{
			if (grd_Exclusives.MouseRow > 0)
			{
				ShowExclusiveCompanyInfo();
				SelectExclusiveCallback();
			}
			else
			{

				switch(grd_Exclusives.MouseCol)
				{
					case 0 : 
						strReverifyOrderBy = "ORDER BY ac_exclusive_verify_date"; 
						break;
					case 1 : 
						strReverifyOrderBy = "ORDER BY comp_name"; 
						break;
					case 2 : 
						strReverifyOrderBy = "ORDER BY comp_city"; 
						break;
					case 3 : 
						strReverifyOrderBy = "ORDER BY comp_state"; 
						break;
					case 4 : 
						strReverifyOrderBy = "ORDER BY comp_timezone"; 
						break;
					case 5 : 
						strReverifyOrderBy = "ORDER BY amod_make_name, amod_model_name, ac_ser_no_full"; 
						break;
					case 6 : 
						strReverifyOrderBy = "ORDER BY dtLastAttempted"; 
						 
						break;
				}

				Fill_Exclusive_Callback_Grid();

			}

		}

		private void grd_Exclusives_MouseMove(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;

			if (HadHourglass)
			{
				this.Cursor = Cursors.WaitCursor;
			}

		}

		private void grd_expired_leases_Click(Object eventSender, EventArgs eventArgs)
		{
			if (grd_expired_leases.CurrentRowIndex > 0)
			{
				pnl_lstcompany.Visible = true;
				Show_Expired_Leases_Info();
			}
		}

		private void grd_expired_leases_DoubleClick(Object eventSender, EventArgs eventArgs)
		{
			//******************************************************************************************

			int i = 0;

			if (grd_expired_leases.CurrentRowIndex > 0)
			{

				Show_Expired_Leases_Info();

				if (grd_expired_leases.CurrentRowIndex > -1)
				{

					//UPGRADE_ISSUE: (2064) MSHierarchicalFlexGridLib.MSHFlexGrid property grd_expired_leases.BandData was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					modAdminCommon.gbl_Aircraft_ID = grd_expired_leases.BandData(grd_expired_leases.CurrentRowIndex);
					modAdminCommon.gbl_Aircraft_Journal_ID = 0; //aey 8/4/4

					frm_aircraft.DefInstance.Form_Initialize();
					frm_aircraft.DefInstance.StartForm = modGlobalVars.tStart_Form;
					frm_aircraft.DefInstance.Reference_Aircraft_ID = modAdminCommon.gbl_Aircraft_ID;
					frm_aircraft.DefInstance.Reference_Journal_ID = modAdminCommon.gbl_Aircraft_Journal_ID;
					frm_aircraft.DefInstance.Reference_Company_ID = 0;
					frm_aircraft.DefInstance.Show();
					//UPGRADE_WARNING: (2065) Form method frm_aircraft.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
					frm_aircraft.DefInstance.BringToFront();
					//UPGRADE_WARNING: (2065) Form event Form.Activated has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
					frm_aircraft.DefInstance.Form_Activated(frm_aircraft.DefInstance, new EventArgs());

				} // If grd_expired_leases.Row > -1 Then

			} // If grd_expired_leases.Row > 0 Then

		} // grd_expired_leases_DblClick

		private void grd_Hot_Items_Click(Object eventSender, EventArgs eventArgs)
		{


			int lRow1 = grd_Hot_Items.MouseRow;
			int lCol1 = grd_Hot_Items.MouseCol;

			//--------------------------------------------------------------------------------------------------------
			// #0          #1       #2    #3    #4       #5       #6          #7          #8       #9    #10   #11
			// Make/Model  Serial#  Reg#  Date  Company  Subject  Brand/Model Yacht Name  JournId  ACId  YTId  CompId

			if (lRow1 == 0)
			{
				iHOTBoxSortCol = lCol1;
				Fill_Hot_Items_Grid();
			}
			else
			{

				pnl_lstcompany.Visible = true;
				modCommon.Highlight_Grid_Row(grd_Hot_Items);
				Show_Hot_Items_Confirm_Info();

			} // If lRow1 = 0 Then

		} // grd_Hot_Items_Click

		private void grd_Hot_Items_DoubleClick(Object eventSender, EventArgs eventArgs)
		{

			frm_Company ofrm_Company = null;


			int lJournId = 0;
			int lACId = 0;
			int lYTId = 0;

			int i = 0;

			int lRow1 = grd_Hot_Items.MouseRow;
			int lCol1 = grd_Hot_Items.MouseCol;

			//--------------------------------------------------------------------------------------------------------
			// #0          #1       #2    #3    #4       #5       #6          #7          #8       #9    #10   #11
			// Make/Model  Serial#  Reg#  Date  Company  Subject  Brand/Model Yacht Name  JournId  ACId  YTId  CompId

			modAdminCommon.gbl_Aircraft_ID = Convert.ToInt32(Double.Parse(Convert.ToString(grd_Hot_Items[lRow1, 9].Value)));
			modAdminCommon.gbl_Aircraft_Journal_ID = 0;

			modAdminCommon.gbl_Yacht_ID = Convert.ToInt32(Double.Parse(Convert.ToString(grd_Hot_Items[lRow1, 10].Value)));
			modAdminCommon.gbl_Yacht_Journal_ID = 0;

			modAdminCommon.gbl_Company_ID = Convert.ToInt32(Double.Parse(Convert.ToString(grd_Hot_Items[lRow1, 11].Value)));
			modAdminCommon.gbl_Company_Journal_ID = 0;

			switch(lCol1)
			{
				case 0 : case 1 : case 2 : case 3 : case 5 : case 9 :  // Aircraft 
					 
					if (modAdminCommon.gbl_Aircraft_ID > 0)
					{
						frm_aircraft.DefInstance.Form_Initialize();
						frm_aircraft.DefInstance.StartForm = modGlobalVars.tStart_Form;
						frm_aircraft.DefInstance.Reference_Aircraft_ID = modAdminCommon.gbl_Aircraft_ID;
						frm_aircraft.DefInstance.Reference_Journal_ID = modAdminCommon.gbl_Aircraft_Journal_ID;
						frm_aircraft.DefInstance.Reference_Company_ID = 0;
						frm_aircraft.DefInstance.Show();
						//UPGRADE_WARNING: (2065) Form method frm_aircraft.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
						frm_aircraft.DefInstance.BringToFront();
						//UPGRADE_WARNING: (2065) Form event Form.Activated has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
						frm_aircraft.DefInstance.Form_Activated(frm_aircraft.DefInstance, new EventArgs());
					}  // If gbl_Aircraft_ID > 0 Then 
					 
					break;
				case 4 : case 11 :  // Company 
					 
					ofrm_Company = frm_Company.CreateInstance(); 
					modCommon.Unload_Form("frm_Company"); 
					 
					ofrm_Company = frm_Company.CreateInstance(); 
					//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064 
					//VB.Global.Load(ofrm_Company); 
					ofrm_Company.Form_Initialize(); 
					ofrm_Company.StartForm = modGlobalVars.tStart_Form; 
					ofrm_Company.Reference_CompanyID = modAdminCommon.gbl_Company_ID; 
					ofrm_Company.Reference_CompanyJID = modAdminCommon.gbl_Company_Journal_ID; 
					ofrm_Company.Show(); 
					//UPGRADE_WARNING: (2065) Form method ofrm_Company.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065 
					ofrm_Company.BringToFront(); 
					//UPGRADE_WARNING: (2065) Form event Form.Activated has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065 
					ofrm_Company.Form_Activated(null, new EventArgs()); 

					 
					//    Case 6, 7, 10    ' Yacht 
					// 
					//      If gbl_Yacht_ID > 0 Then 
					//        frm_Yacht.yacht_id = gbl_Yacht_ID 
					//        frm_Yacht.journ_id = gbl_Yacht_Journal_ID 
					//        frm_Yacht.previous_screen = "Callback" 
					//        frm_Yacht.search_string = "" 
					//        frm_Yacht.load_yacht_data 
					//        frm_Yacht.Show 
					//        frm_Yacht.ZOrder 0 
					//      End If ' If gbl_Yacht_ID > 0 Then 
					 
					break;
			} // Case lCol1

		} // grd_Hot_Items_DblClick

		private void grd_NewAssignments_Click(Object eventSender, EventArgs eventArgs)
		{


			int lRow1 = grd_NewAssignments.MouseRow;
			int lCol1 = grd_NewAssignments.MouseCol;

			cmd_ClearReassign.Visible = false;

			switch(lRow1)
			{
				case 0 : 
					 
					 
					switch(lCol1)
					{
						case 0 : 
							strReassignOrderBy = "AM1.amod_make_name, AM1.amod_model_name"; 
							 
							break;
						case 1 : 
							strReassignOrderBy = "A1.ac_ser_no_full"; 
							 
							break;
						case 2 : 
							strReassignOrderBy = "A1.ac_reg_no"; 
							 
							break;
						case 3 : 
							strReassignOrderBy = "J1.journ_date"; 
							 
							break;
						case 4 : 
							strReassignOrderBy = "C1.comp_name"; 
							 
							break;
						case 5 : 
							strReassignOrderBy = "C1.comp_state"; 
							 
							break;
						case 6 : 
							strReassignOrderBy = "C1.comp_country"; 
							 
							break;
						case 7 : 
							strReassignOrderBy = "J1.journ_prior_account_id"; 
							 
							break;
						case 8 : 
							strReassignOrderBy = "dtLastAttempted"; 
							 
							break;
						case 10 : 
							strReassignOrderBy = "comp_abi_callback_date"; 
							 
							break;
						case 11 : 
							strReassignOrderBy = "dtLastAttemptedReassign"; 
							 
							break;
						case 12 : 
							strReassignOrderBy = "dtJNiQLastAttemptedDate"; 


							 
							break;
					}  // Case lCol1 
					 
					Fill_New_Assignment_Grid(); 
					 
					break;
				default:
					 
					pnl_lstcompany.Visible = true; 
					 
					Show_New_Assign_Confirm_Info(); 
					 
					break;
			} // Case lRow1

		} // grd_NewAssignments_Click

		private void grd_NewAssignments_DoubleClick(Object eventSender, EventArgs eventArgs)
		{


			int lACId = 0;
			int lCompId = 0;

			int lRow1 = grd_NewAssignments.MouseRow;
			int lCol1 = grd_NewAssignments.MouseCol;

			frm_Company o_Local_Show_Company = null;

			if (lRow1 > 0)
			{


				switch(lCol1)
				{
					case 0 : case 1 : case 2 :  // Aircraft 
						 
						//UPGRADE_ISSUE: (2064) MSHierarchicalFlexGridLib.MSHFlexGrid property grd_NewAssignments.BandData was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064 
						modAdminCommon.gbl_Aircraft_ID = grd_NewAssignments.BandData(grd_NewAssignments.CurrentRowIndex); 
						modAdminCommon.gbl_Aircraft_Journal_ID = 0; 
						 
						frm_aircraft.DefInstance.Form_Initialize(); 
						frm_aircraft.DefInstance.StartForm = modGlobalVars.tStart_Form; 
						frm_aircraft.DefInstance.Reference_Aircraft_ID = modAdminCommon.gbl_Aircraft_ID; 
						frm_aircraft.DefInstance.Reference_Journal_ID = modAdminCommon.gbl_Aircraft_Journal_ID; 
						frm_aircraft.DefInstance.Reference_Company_ID = 0; 
						frm_aircraft.DefInstance.Show(); 
						//UPGRADE_WARNING: (2065) Form method frm_aircraft.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065 
						frm_aircraft.DefInstance.BringToFront(); 
						//UPGRADE_WARNING: (2065) Form event Form.Activated has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065 
						frm_aircraft.DefInstance.Form_Activated(frm_aircraft.DefInstance, new EventArgs()); 
						 
						break;
					default: // 3,4,5,6,7,8,9 - Company 
						 
						lCompId = grd_NewAssignments.get_RowData(grd_NewAssignments.CurrentRowIndex); 
						 
						// cleanup any contact forms and open a clean form 
						modCommon.Unload_Form("frm_Company"); 
						 
						o_Local_Show_Company = frm_Company.CreateInstance(); 
						//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064 
						//VB.Global.Load(o_Local_Show_Company); 
						o_Local_Show_Company.Form_Initialize(); 
						o_Local_Show_Company.StartForm = modGlobalVars.tStart_Form; 
						o_Local_Show_Company.Reference_CompanyID = lCompId; 
						o_Local_Show_Company.Reference_CompanyJID = 0; 
						o_Local_Show_Company.Show(); 
						//UPGRADE_WARNING: (2065) Form method o_Local_Show_Company.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065 
						o_Local_Show_Company.BringToFront(); 
						//UPGRADE_WARNING: (2065) Form event Form.Activated has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065 
						o_Local_Show_Company.Form_Activated(null, new EventArgs()); 
						 
						break;
				} // Case lCol1

			} // If lRow1 > 0 Then

		} // grd_NewAssignments_DblClick

		private void grd_WantedList_Click(Object eventSender, EventArgs eventArgs)
		{
			if (grd_WantedList.MouseRow > 0)
			{
				pnl_lstcompany.Visible = true;
				Show_Wanted_Company_Information();
			}
		}

		private void grd_WantedList_DoubleClick(Object eventSender, EventArgs eventArgs)
		{
			if (grd_WantedList.MouseRow > 0)
			{
				pnl_lstcompany.Visible = true;
				Show_Wanted_Company_Information();
				// change 8-14-09 Mike & Tom
				// Did a call to Select_Callbacks
				// Wrote Select_Wanted function
				Select_Wanted();
			}
			else
			{
				switch(grd_WantedList.MouseCol)
				{
					case 0 : 
						WantedOrderBy = "order BY comp_name,comp_city,comp_state,comp_timezone "; 
						 
						break;
					case 1 : 
						WantedOrderBy = "order BY comp_city,comp_name,comp_state,comp_timezone "; 
						 
						break;
					case 2 : 
						WantedOrderBy = "order BY comp_state,comp_name,comp_city,comp_timezone "; 
						 
						break;
					case 3 : 
						WantedOrderBy = "order BY comp_timezone,comp_name,comp_city,comp_state "; 
						 
						break;
					case 4 : 
						WantedOrderBy = "order BY amod_make_name,comp_name,comp_city,comp_state,comp_timezone "; 
						 
						break;
					case 5 : 
						WantedOrderBy = "order BY amod_model_name,comp_name,comp_city,comp_state,comp_timezone "; 
						 
						break;
					case 6 : 
						WantedOrderBy = "order BY amwant_listed_date,comp_name,comp_city,comp_state,comp_timezone "; 
						 
						break;
					case 7 : 
						WantedOrderBy = "order BY amwant_verified_date,comp_name,comp_city,comp_state,comp_timezone "; 
						 
						break;
				}

				Fill_WantedList();

			}

		}

		private void grd_Yacht_Callbacks_Click(Object eventSender, EventArgs eventArgs)
		{

			pnl_lstcompany.Visible = true;

			if (Convert.ToString(grd_Yacht_Callbacks[0, 0].Value) != "No Records Found")
			{
				//Show_Yacht_Callback_Company_Info
			}

			//  grd_Yacht_Callbacks.Col = 1
			//  grd_Yacht_Callbacks.ColSel = 5
			//  grd_Yacht_Callbacks.RowSel = grd_Yacht_Callbacks.Row

		}



		private void grdBadFractions_DoubleClick(Object eventSender, EventArgs eventArgs)
		{

			if (grdBadFractions.CurrentRowIndex > -1)
			{

				modAdminCommon.gbl_Aircraft_ID = grdBadFractions.get_RowData(grdBadFractions.CurrentRowIndex);
				modAdminCommon.gbl_Aircraft_Journal_ID = 0; //aey 8/3/04

				frm_aircraft.DefInstance.Form_Initialize();
				frm_aircraft.DefInstance.StartForm = modGlobalVars.tStart_Form;
				frm_aircraft.DefInstance.Reference_Aircraft_ID = modAdminCommon.gbl_Aircraft_ID;
				frm_aircraft.DefInstance.Reference_Journal_ID = modAdminCommon.gbl_Aircraft_Journal_ID;
				frm_aircraft.DefInstance.Reference_Company_ID = 0;
				frm_aircraft.DefInstance.Show();
				//UPGRADE_WARNING: (2065) Form method frm_aircraft.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
				frm_aircraft.DefInstance.BringToFront();
				//UPGRADE_WARNING: (2065) Form event Form.Activated has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
				frm_aircraft.DefInstance.Form_Activated(frm_aircraft.DefInstance, new EventArgs());

			} // If grdBadFractions.Row > -1 Then

		}

		private void grdFractional_Click(Object eventSender, EventArgs eventArgs)
		{

			pnl_lstcompany.Visible = true;
			this.Cursor = Cursors.WaitCursor;

			if (opt_OwnersPendingSale.Checked)
			{

				if (grdFractional.CurrentRowIndex >= 0)
				{
					Show_Pending_Fractional_Company_Info();
				}

			}
			else if (Opt_Reassigned.Checked)
			{ 
				//7/7/04 aey
				if (grdFractional.CurrentRowIndex >= 0)
				{
					cmd_ClearFractionalReassign.Visible = true;
					ShowPendingFractionalReAssigns();
				}
			}
			else if (Opt_FracWithPrimaryWhole.Checked)
			{ 
				//7/8/04 aey
				if (grdFractional.CurrentRowIndex >= 0)
				{
					ShowPendingFractionalReAssigns();
				}

			}
			else
			{

				if (grdFractional.CurrentRowIndex >= 0)
				{
					Show_Fractional_Company_Info();
				}

			}

			this.Cursor = CursorHelper.CursorDefault;

		}

		private void grdFractional_DoubleClick(Object eventSender, EventArgs eventArgs)
		{

			frm_Company o_Local_Show_Company = null;

			if (opt_OwnersPendingSale.Checked)
			{

				if (grdFractional.CurrentRowIndex >= 0)
				{

					Show_Pending_Fractional_Company_Info();
					modAdminCommon.gbl_Aircraft_ID = Convert.ToInt32(snp_FractionsPending["AC_ID"]);
					modAdminCommon.gbl_Aircraft_Journal_ID = Convert.ToInt32(snp_FractionsPending["AC_Journ_id"]);

					frm_aircraft.DefInstance.Form_Initialize();
					frm_aircraft.DefInstance.StartForm = modGlobalVars.tStart_Form;
					frm_aircraft.DefInstance.Reference_Aircraft_ID = modAdminCommon.gbl_Aircraft_ID;
					frm_aircraft.DefInstance.Reference_Journal_ID = modAdminCommon.gbl_Aircraft_Journal_ID;
					frm_aircraft.DefInstance.Reference_Company_ID = 0;
					frm_aircraft.DefInstance.Show();
					//UPGRADE_WARNING: (2065) Form method frm_aircraft.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
					frm_aircraft.DefInstance.BringToFront();
					//UPGRADE_WARNING: (2065) Form event Form.Activated has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
					frm_aircraft.DefInstance.Form_Activated(frm_aircraft.DefInstance, new EventArgs());

				} // If grdFractional.Row >= 0 Then

			}
			else if ((Opt_Reassigned.Checked || Opt_FracWithPrimaryWhole.Checked) && grdFractional.CurrentRowIndex >= 0)
			{ 
				//7/8/04 aey
				grdFractional.CurrentColumnIndex = 6;

				// cleanup any contact forms and open a clean form
				modCommon.Unload_Form("frm_Company");

				o_Local_Show_Company = frm_Company.CreateInstance();
				//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//VB.Global.Load(o_Local_Show_Company);
				o_Local_Show_Company.Form_Initialize();
				o_Local_Show_Company.StartForm = modGlobalVars.tStart_Form;
				o_Local_Show_Company.Reference_CompanyID = Convert.ToInt32(Double.Parse(grdFractional[grdFractional.CurrentRowIndex, grdFractional.CurrentColumnIndex].FormattedValue.ToString().Trim()));
				o_Local_Show_Company.Reference_CompanyJID = 0;
				o_Local_Show_Company.Show();
				//UPGRADE_WARNING: (2065) Form method o_Local_Show_Company.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
				o_Local_Show_Company.BringToFront();
				//UPGRADE_WARNING: (2065) Form event Form.Activated has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
				o_Local_Show_Company.Form_Activated(null, new EventArgs());

				this.Cursor = CursorHelper.CursorDefault;

			}
			else
			{

				if (grdFractional.CurrentRowIndex >= 0)
				{
					Show_Fractional_Company_Info();
					Select_Fractional_Owner();
				}

			}
		}

		private void grdPriorityEvents_DoubleClick(Object eventSender, EventArgs eventArgs)
		{

			if (grdPriorityEvents.MouseRow > 0)
			{

				modAdminCommon.gbl_Aircraft_ID = grdPriorityEvents.get_RowData(grdPriorityEvents.MouseRow);
				modAdminCommon.gbl_Aircraft_Journal_ID = 0; //aey 8/4/4

				frm_aircraft.DefInstance.Form_Initialize();
				frm_aircraft.DefInstance.StartForm = modGlobalVars.tStart_Form;
				frm_aircraft.DefInstance.Reference_Aircraft_ID = modAdminCommon.gbl_Aircraft_ID;
				frm_aircraft.DefInstance.Reference_Journal_ID = modAdminCommon.gbl_Aircraft_Journal_ID;
				frm_aircraft.DefInstance.Reference_Company_ID = 0;
				frm_aircraft.DefInstance.Show();
				//UPGRADE_WARNING: (2065) Form method frm_aircraft.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
				frm_aircraft.DefInstance.BringToFront();
				//UPGRADE_WARNING: (2065) Form event Form.Activated has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
				frm_aircraft.DefInstance.Form_Activated(frm_aircraft.DefInstance, new EventArgs());

			}
			else
			{

				switch(grdPriorityEvents.MouseCol)
				{
					case 0 : 
						strEventsOrderBy = "ORDER BY amod_make_name, amod_model_name, ac_ser_no_sort"; 
						Fill_Priority_Events(); 
						 
						break;
					case 1 : 
						strEventsOrderBy = "ORDER BY ac_ser_no_sort"; 
						Fill_Priority_Events(); 
						 
						break;
					case 2 : 
						strEventsOrderBy = "ORDER BY priorev_subject, priorev_description"; 
						Fill_Priority_Events(); 
						 
						break;
					case 3 : 
						strEventsOrderBy = "ORDER BY priorev_entry_date DESC"; 
						Fill_Priority_Events(); 
						 
						break;
					default:
						return; 

				}

			}

		}

		private void Label1_Click(Object eventSender, EventArgs eventArgs)
		{
			strFractOrderBy = "ORDER BY comp_name,comp_city,comp_state";
			cmdRefreshFractOwners_Click(cmdRefreshFractOwners, new EventArgs());
		}

		private void Label15_Click(Object eventSender, EventArgs eventArgs)
		{
			strFractOrderBy = "ORDER BY comp_state, comp_city";
			cmdRefreshFractOwners_Click(cmdRefreshFractOwners, new EventArgs());
		}

		//UPGRADE_NOTE: (7001) The following declaration (Label28_Click) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void Label28_Click()
		//{
			//
			//
		//}

		//UPGRADE_NOTE: (7001) The following declaration (Label29_Click) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void Label29_Click() => strOrderBy = "order by comp_city, comp_country, comp_id ";//
		//


		//UPGRADE_NOTE: (7001) The following declaration (Label30_Click) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void Label30_Click()
		//{
			//
		//}

		//UPGRADE_NOTE: (7001) The following declaration (Label31_Click) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void Label31_Click()
		//{
			//
		//}

		//UPGRADE_NOTE: (7001) The following declaration (Label33_Click) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void Label33_Click()
		//{
			//
		//}


		//UPGRADE_NOTE: (7001) The following declaration (Label44_Click) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void Label44_Click()
		//{
			//
			//
			//
		//}

		//UPGRADE_NOTE: (7001) The following declaration (Label45_Click) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void Label45_Click()
		//{
			//
		//}

		//UPGRADE_NOTE: (7001) The following declaration (Label48_Click) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void Label48_Click()
		//{
			//
			//
		//}


		//UPGRADE_NOTE: (7001) The following declaration (Label49_Click) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void Label49_Click()
		//{
			//
			//
		//}

		//UPGRADE_NOTE: (7001) The following declaration (Label50_Click) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void Label50_Click()
		//{
			//
			//
		//}

		//UPGRADE_NOTE: (7001) The following declaration (Label51_Click) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void Label51_Click()
		//{
			//
		//}


		//UPGRADE_NOTE: (7001) The following declaration (Label52_Click) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void Label52_Click()
		//{
			//
		//}

		//UPGRADE_NOTE: (7001) The following declaration (Label54_Click) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void Label54_Click()
		//{
			//
			//
		//}

		private void lblFindDupsStop_Click(Object eventSender, EventArgs eventArgs)
		{

			lblFindDupsStop.Enabled = false;
			lblFindDupsStop.Visible = false;

		}

		private void Label8_Click(Object eventSender, EventArgs eventArgs)
		{
			strFractOrderBy = "ORDER BY comp_city,comp_state,comp_name";
			cmdRefreshFractOwners_Click(cmdRefreshFractOwners, new EventArgs());
		}

		private void Label9_Click(Object eventSender, EventArgs eventArgs)
		{
			strFractOrderBy = "ORDER BY comp_account_callback_date";
			cmdRefreshFractOwners_Click(cmdRefreshFractOwners, new EventArgs());
		}

		//UPGRADE_NOTE: (7001) The following declaration (lbl_Aircraft_Click) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void lbl_Aircraft_Click()
		//{
			//
		//}

		//UPGRADE_NOTE: (7001) The following declaration (lbl_end_Date_Click) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void lbl_end_Date_Click()
		//{
			//
		//}

		private void lbl_fract_col5_Click(Object eventSender, EventArgs eventArgs)
		{

			strFractOrderBy = "ORDER BY comp_timezone ";
			cmdRefreshFractOwners_Click(cmdRefreshFractOwners, new EventArgs());

		}

		private void lbl_fract_col6_Click(Object eventSender, EventArgs eventArgs)
		{

			strFractOrderBy = "ORDER BY comp_fractowr_id desc ";
			cmdRefreshFractOwners_Click(cmdRefreshFractOwners, new EventArgs());

		}

		private void ShowExclusiveCompanyInfo()
		{


			lstCompany.Items.Clear();
			string strLock = "";
			if (grd_Exclusives.CurrentRowIndex > 0)
			{
				snp_ExclusiveCallback.MoveFirst();
				int tempForEndVar = grd_Exclusives.CurrentRowIndex - 1;
				for (int i = 1; i <= tempForEndVar; i++)
				{
					snp_ExclusiveCallback.MoveNext();
				}
				txt_next_confirm_date.Text = DateTimeHelper.ToString(DateTime.Parse(modAdminCommon.DateToday).AddDays(Double.Parse(($"{modAdminCommon.gbl_ColorConfirmDays.ToString()}").Trim())));

				RememberExclusiveCompanyId = Convert.ToInt32(snp_ExclusiveCallback["comp_id"]);
				modCommon.Build_Company_NameAddress(this.lstCompany, Convert.ToInt32(snp_ExclusiveCallback["comp_id"]), Convert.ToInt32(snp_ExclusiveCallback["comp_journ_id"]));
				lstCompany.SetItemData(0, Convert.ToInt32(snp_ExclusiveCallback["comp_id"]));

				cmdConfirmExclusive.Enabled = true; //aey 4/21/2006
				cmdConfirmExclusive.Text = "&Confirm Company";
				strLock = modCommon.CompanyLocked(RememberExclusiveCompanyId, 0);

				if ((strLock == "False") || (strLock == Convert.ToString(modAdminCommon.snp_User["user_id"])))
				{
				}
				else
				{
					cmdConfirmExclusive.Enabled = false;
					cmdConfirmExclusive.Text = "Confirm Company Locked";
				}

			}

		}

		public void Select_Account_Rep()
		{
			//----------------------------------------------------------------------------------------------
			//Function used to select account rep
			//----------------------------------------------------------------------------------------------

			try
			{


				if (!bIsFormLoad)
				{

					if (modAdminCommon.gbl_Account_ID != "")
					{
						int tempForEndVar = modGlobalVars.AccountRep_Array.GetUpperBound(0);
						for (int i = modGlobalVars.AccountRep_Array.GetLowerBound(0); i <= tempForEndVar; i++)
						{
							if (modGlobalVars.AccountRep_Array[i].Trim() == modAdminCommon.gbl_Account_ID.Trim())
							{
								cbo_account_id.SelectedIndex = i + 1;
								break;
							}
						}
					}
					else
					{
						cbo_account_id.SelectedIndex = 0;
					}

				} // form is not loaded
			}
			catch
			{

				search_off();
				modAdminCommon.Report_Error("Select_Account_Rep_Error: ");
				return;
			}

		}

		private void lblOwrOprStop_Click(Object eventSender, EventArgs eventArgs)
		{

			lblOwrOprStop.Visible = false;
			lblOwrOprStop.Enabled = false;

		}

		private void lst_primary_DoubleClick(Object eventSender, EventArgs eventArgs)
		{
			RememberExclusiveCompanyId = lst_primary.GetItemData(0);
			Select_Callback();
		}

		private void lstCompany_DoubleClick(Object eventSender, EventArgs eventArgs)
		{
			RememberExclusiveCompanyId = lstCompany.GetItemData(0);
			Select_Callback();
		}

		public void mnuCanRegistry_Click(Object eventSender, EventArgs eventArgs)
		{

			// 04/17/2013 - By David D. Cruger
			// Use The frm_NTSB_New Form

			modCommon.CenterFormOnHomebaseMainForm(frm_CanReg.DefInstance);
			frm_CanReg.DefInstance.Show();

			// If .Show vbModal Then Unload Form
			//Unload frm_CanReg

		}

		public void mnuFileClose_Click(Object eventSender, EventArgs eventArgs) => this.Close();


		public void mnuFileLogout_Click(Object eventSender, EventArgs eventArgs) => frm_Main_Menu.DefInstance.Close();


		public void mnuNewPubsAvailable_Click(Object eventSender, EventArgs eventArgs) => frm_WebCrawl.DefInstance.Show();


		public void mnuViewAcctRepMasterList_Click(Object eventSender, EventArgs eventArgs)
		{

			if (mnuViewAcctRepMasterList.Checked)
			{
				mnuViewAcctRepMasterList.Checked = false;
				chk_action_list[chkViewMasterList].CheckState = CheckState.Unchecked;
			}
			else
			{
				mnuViewAcctRepMasterList.Checked = true;
				chk_action_list[chkViewMasterList].CheckState = CheckState.Checked;
			}

		}

		// ====================================================================================
		// Written By : David D. Cruger
		// Created    : 09/24/2002
		// Modified   : 09/24/2002
		// Function   : mnuViewVerifyStatusReport_Click
		// Parameters : None
		//
		// Returns    : None
		//
		// Notes      : Only if user is an 'Administrator' or 'Research Manager' can
		// this report be run.
		//
		// ====================================================================================

		public void mnuViewVerifyStatusReport_Click(Object eventSender, EventArgs eventArgs)
		{

			if (($" {Convert.ToString(modAdminCommon.snp_User["user_type"])}").Trim() == "Administrator" || ($" {Convert.ToString(modAdminCommon.snp_User["user_type"])}").Trim() == "Research Manager")
			{
				//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//VB.Global.Load(frm_VerifyStatusReport.DefInstance);
				modCommon.CenterFormOnHomebaseMainForm(frm_VerifyStatusReport.DefInstance);
				frm_VerifyStatusReport.DefInstance.ShowDialog();
			}

		} // End Sub mnuViewVerifyStatusReport_Click

		private bool isInitializingComponent;
		private void opHBAircraftYacht_CheckedChanged(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.opHBAircraftYacht, eventSender);
			if (((RadioButton) eventSender).Checked)
			{
				if (isInitializingComponent)
				{
					return;
				}
				if (opHBAircraftYacht[Index].Enabled)
				{
					Fill_Hot_Items_Grid(Index);
				}
			}
		}

		private void opSubmitAircraft_CheckedChanged(Object eventSender, EventArgs eventArgs)
		{
			if (((RadioButton) eventSender).Checked)
			{
				if (isInitializingComponent)
				{
					return;
				}
				cmdFindCustSubDataRefresh_Click(cmdFindCustSubDataRefresh, new EventArgs());
			}
		}

		private void opSubmitBoth_CheckedChanged(Object eventSender, EventArgs eventArgs)
		{
			if (((RadioButton) eventSender).Checked)
			{
				if (isInitializingComponent)
				{
					return;
				}
				cmdFindCustSubDataRefresh_Click(cmdFindCustSubDataRefresh, new EventArgs());
			}
		}

		private void opSubmitCompany_CheckedChanged(Object eventSender, EventArgs eventArgs)
		{
			if (((RadioButton) eventSender).Checked)
			{
				if (isInitializingComponent)
				{
					return;
				}
				cmdFindCustSubDataRefresh_Click(cmdFindCustSubDataRefresh, new EventArgs());
			}
		}

		private void Opt_FracWithPrimaryWhole_CheckedChanged(Object eventSender, EventArgs eventArgs)
		{
			if (((RadioButton) eventSender).Checked)
			{
				if (isInitializingComponent)
				{
					return;
				}
				cmd_ClearFractionalReassign.Visible = false;
				pnl_fractional_display.Visible = false;
				pnlFractionalPercentagesBad.Visible = false;

				chk_Current_Acct_Rep.Visible = false;
				chk_Date_Less_Than.Visible = false;

				//UPGRADE_ISSUE: (2064) Threed.SSPanel property pnl_Fractional.Caption was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				pnl_Fractional.setCaption(" ");
				Fill_FracWithPrimaryWhole_Grid();

			}
		}

		private void opt_OwnersPendingSale_CheckedChanged(Object eventSender, EventArgs eventArgs)
		{
			if (((RadioButton) eventSender).Checked)
			{
				if (isInitializingComponent)
				{
					return;
				}
				pnl_fractional_display.Visible = false;
				pnlFractionalPercentagesBad.Visible = false;
				cmd_ClearFractionalReassign.Visible = false;

				chk_Current_Acct_Rep.Visible = false;
				chk_Date_Less_Than.Visible = false;

				//UPGRADE_ISSUE: (2064) Threed.SSPanel property pnl_Fractional.Caption was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				pnl_Fractional.setCaption(" ");
				Fill_Fractional_Owners_Pending_Sale_Grid();
			}
		}

		private void Opt_Reassigned_CheckedChanged(Object eventSender, EventArgs eventArgs)
		{
			if (((RadioButton) eventSender).Checked)
			{
				if (isInitializingComponent)
				{
					return;
				}
				pnl_fractional_display.Visible = false;
				pnlFractionalPercentagesBad.Visible = false;

				chk_Current_Acct_Rep.Visible = false;
				chk_Date_Less_Than.Visible = false;

				//UPGRADE_ISSUE: (2064) Threed.SSPanel property pnl_Fractional.Caption was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				pnl_Fractional.setCaption(" ");
				Fill_Fractional_ReAssign_Grid();

			}
		}

		private void optBadFractions_CheckedChanged(Object eventSender, EventArgs eventArgs)
		{
			if (((RadioButton) eventSender).Checked)
			{
				if (isInitializingComponent)
				{
					return;
				}
				pnl_fractional_display.Visible = false;
				pnlFractionalPercentagesBad.Visible = true;
				cmd_ClearFractionalReassign.Visible = false;
				chk_Current_Acct_Rep.Visible = false;
				chk_Date_Less_Than.Visible = false;
				//UPGRADE_ISSUE: (2064) Threed.SSPanel property pnl_Fractional.Caption was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				pnl_Fractional.setCaption("Searching for Fractionals...");
				Fill_Bad_Fractions_Grid();
			}
		}

		private void optFractionalOwners_CheckedChanged(Object eventSender, EventArgs eventArgs)
		{
			if (((RadioButton) eventSender).Checked)
			{
				if (isInitializingComponent)
				{
					return;
				}

				pnlFractionalPercentagesBad.Visible = false;
				pnl_fractional_display.Visible = true;
				cmd_ClearFractionalReassign.Visible = false;

				chk_Current_Acct_Rep.Visible = true;
				chk_Date_Less_Than.Visible = true;
				cmdRefreshFractOwners_Click(cmdRefreshFractOwners, new EventArgs());

			}
		}

		private void pnl_Callbacks_MouseMove(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;

			if (HadHourglass)
			{
				this.Cursor = Cursors.WaitCursor;
			}

		}

		private void pnl_Exclusives_MouseMove(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;

			if (HadHourglass)
			{
				this.Cursor = Cursors.WaitCursor;
			}

		}

		private void tab_callback_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{

			text_airbp_remarks.Visible = false;


			if (cbo_multi[0].Items.Count == 0)
			{
				cbo_multi[0].Items.Clear();
				cbo_multi[0].AddItem("Company");
				cbo_multi[0].AddItem("Contact");
				cbo_multi[0].AddItem("All Company/Contact");
				cbo_multi[0].AddItem("Aircraft");
				cbo_multi[0].Text = "All Company/Contact";
			}




			if (cbo_multi[1].Items.Count < 2)
			{


				switch(SSTabHelper.GetSelectedIndex(tab_callback))
				{
					case 21 :  // issues 
						Application.DoEvents(); 
						Application.DoEvents(); 
						this.Cursor = Cursors.WaitCursor; 
						Application.DoEvents(); 
						Application.DoEvents(); 
						Fill_Issues_Type(); 
						Application.DoEvents(); 
						Application.DoEvents(); 
						this.Cursor = CursorHelper.CursorDefault; 
						Application.DoEvents(); 
						Application.DoEvents(); 
						 
						break;
					default:
						cbo_multi[1].Items.Clear(); 
						cbo_multi[1].AddItem("All"); 
						cbo_multi[1].Text = "All"; 
						break;
				}


				//    cbo_multi.Item(1).Clear
				//   ' cbo_multi.Item(1).AddItem ("Country")
				//   ' cbo_multi.Item(1).AddItem ("Email Address")
				//    cbo_multi.Item(1).AddItem ("All")
				//    cbo_multi.Item(1).Text = "All"
			}

			if (cbo_multi[2].Items.Count == 0)
			{
				Fill_Salesforce_Type();
			}


			if (!bIsFormLoad)
			{

				cal_Callback.Visible = true;
				cmd_ClearReassign.Visible = false;
				lbl_gen[4].Visible = false;
				txt_next_confirm_date.Visible = false;
				lstCompany.Items.Clear();
				pnl_lstcompany.Visible = false;

				lbl_gen[3].Visible = false;
				cbo_Timezones.Visible = false;
				lbl_gen[0].Visible = false;
				cbo_TimeScale.Visible = false;
				lbl_gen[4].Visible = false;
				txt_ListStartDate.Visible = false;
				lbl_gen[1].Visible = true;
				txt_Callback_Date.Visible = true;

				if (cbo_Timezones.Items.Count == 11)
				{
					cbo_Timezones.RemoveItem(10);
				}



				switch(SSTabHelper.GetSelectedIndex(tab_callback))
				{
					case 0 :  // CallBack 
						 
						pnl_lstcompany.Visible = false; 
						lbl_gen[3].Visible = true; 
						cbo_Timezones.Visible = true; 
						lbl_gen[0].Visible = true; 
						cbo_TimeScale.Visible = true; 
						lbl_gen[4].Visible = true; 
						txt_ListStartDate.Visible = true; 
						Fill_Callback_Grid(); 
						 
						break;
					case 1 :  // Reassigns 
						 
						lbl_gen[3].Visible = true; 
						cbo_Timezones.Visible = true; 
						pnl_lstcompany.Visible = true; 
						Fill_New_Assignment_Grid(); 
						 
						break;
					case 2 :  // Company Color Confirm 
						 
						pnl_lstcompany.Visible = true; 
						cmd_Refresh_CompColorConfirm.Visible = true; 
						lbl_CompConfirm.Text = $"The following represents a list of companies that have been over {modAdminCommon.gbl_ColorConfirmDays.ToString()} days since having their address information confirmed for the selected account representative."; 
						Fill_Comp_Confirm_Grid(""); 
						 
						break;
					case 3 :  // Reverify Exclusives Due 
						 
						pnl_lstcompany.Visible = false; 
						Fill_Exclusive_Callback_Grid(); 
						 
						break;
					case 4 :  // Hot Items 
						 
						lbl_gen[0].Visible = true; 
						cbo_TimeScale.Visible = true; 
						lbl_gen[4].Visible = true; 
						txt_ListStartDate.Visible = true; 
						cbo_Timezones.Visible = true; 
						lbl_gen[3].Visible = true; 
						cbo_Timezones.Visible = true; 

						 
						pnl_lstcompany.Visible = false; 
						iHOTBoxSortCol = 0;  // Make/Model 
						Fill_Hot_Items_Grid(); 
						 
						break;
					case 5 :  // Expired Leases 
						 
						lbl_gen[3].Visible = true; 
						cbo_Timezones.Visible = true; 
						pnl_lstcompany.Visible = false; 
						Fill_Aircraft_Expired_Leases_Grid(); 
						 
						break;
					case 6 :  // Fractional Owners 
						 
						pnl_lstcompany.Visible = false; 
						pnl_Fractional.Visible = false; 
						cmdRefreshFractOwners_Click(cmdRefreshFractOwners, new EventArgs()); 
						 
						break;
					case 7 :  // Wanteds 
						 
						Fill_WantedList(); 
						Tab7 = false; 
						 
						break;
					case 8 :  // Available AC 
						 
						Fill_AvailableAircraft_Grid(); 
						 
						break;
					case 9 :  // Docs in Process 
						 
						lbl_gen[3].Visible = true; 
						cbo_Timezones.Visible = true; 
						 
						cbo_Timezones.AddItem("All U.S."); 

						 
						if (cmbDocInProcsClass.Items.Count <= 0)
						{
							modCommon.FillComboAircraftClass(cmbDocInProcsClass);
						} 
						 
						cmd_DocsInProcessRefresh_Click(cmd_DocsInProcessRefresh, new EventArgs()); 
						 
						break;
					case 10 :  // Events 
						 
						FillEventCat(); 
						Fill_Priority_Events(); 


						 
						break;
					case 14 :  // Owner=Operator No SeqNbr 
						 
						Application.DoEvents(); 
						 
						lbl_gen[3].Visible = true; 
						cbo_Timezones.Visible = true; 
						 
						Application.DoEvents(); 
						 
						if (fgrdOwrOpr.ColumnsCount <= 2)
						{
							Fill_Owner_Operator_Callback_Grid();
						} 
						 
						break;
					case 15 :  // Find Duplicate Reports 
						 
						Application.DoEvents(); 
						 
						if (fgrdFindDups.ColumnsCount <= 2)
						{
							Fill_Find_Duplicate_Callback_Grid();
						} 
						 
						break;
					case 16 :  // Find AC With No Base Information 

						 
						lbl_gen[3].Visible = true; 
						cbo_Timezones.Visible = true; 
						 
						if (fgrdFindACNoBase.ColumnsCount <= 2)
						{
							Fill_Find_AC_With_No_Base_Information_Grid();
						} 
						 
						break;
					case 17 :  // Find AC With Missing Chief Pilot 
						 
						lbl_gen[3].Visible = true; 
						cbo_Timezones.Visible = true; 
						 
						if (fgrdFindACNoCHP.ColumnsCount <= 2)
						{
							Fill_Find_AC_With_No_Chief_Pilots_Grid();
						} 
						 
						break;
					case 18 :  // Find Company Submitted Data 
						 
						lbl_gen[0].Visible = true; 
						lbl_gen[1].Visible = false; 
						lbl_gen[4].Visible = true; 
						 
						cbo_TimeScale.Visible = true; 
						txt_Callback_Date.Visible = false; 
						txt_ListStartDate.Visible = true; 
						cal_Callback.Visible = false; 
						 
						if (fgrdFindCustSubData.ColumnsCount <= 2)
						{
							Fill_Find_Customer_Submitted_Data_Grid();
						} 
						 
						break;
					case 19 :  // Find Research Reports 
						 
						cbo_TimeScale.Visible = true; 
						txt_Callback_Date.Visible = true; 
						txt_ListStartDate.Visible = true; 
						lbl_gen[3].Visible = true; 
						cbo_Timezones.Visible = true; 
						Application.DoEvents();  // User Must Select Report Before Running 
						 
						break;
					case 21 :  //Issues 
						 
						Application.DoEvents(); 
						Application.DoEvents(); 
						this.Cursor = Cursors.WaitCursor; 
						Application.DoEvents(); 
						Application.DoEvents(); 

						 
						Fill_Issues_Callback_Grid(); 
						 
						Application.DoEvents(); 
						Application.DoEvents(); 
						this.Cursor = CursorHelper.CursorDefault; 
						Application.DoEvents(); 
						Application.DoEvents(); 
						 
						break;
					case 22 :  //Salesforce 
						 
						Fill_Salesforce_Callback_Grid(); 


						 
						break;
				} // Case tab_callback.Tab

				search_off();

				if (cbo_account_id.Visible && cbo_account_id.Enabled)
				{
					cbo_account_id.Focus();
				}

			} // If bIsFormLoad = False Then

			tab_callbackPreviousTab = tab_callback.SelectedIndex;
		} // tab_callback_Click


		private void Fill_Salesforce_Type()
		{
			//----------------------------------------------------------------------------------------------
			//Function used to fill the bad fractions grid
			//----------------------------------------------------------------------------------------------
			ADORecordSetHelper snpAC = new ADORecordSetHelper(); //aey 6/18/04
			string TheWholeThing = "";



			string Query = " select  distinct changetype ";
			Query = $"{Query} from view_SalesAPI_Changes ";
			Query = $"{Query} left outer join company with (NOLOCK) on comp_journ_id = 0 and comp_id = journ_comp_id ";
			Query = $"{Query} where journ_date >= getdate() - 365 ";
			Query = $"{Query} order by changetype asc ";

			snpAC.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snpAC.Fields) && !(snpAC.BOF && snpAC.EOF))
			{
				cbo_multi[2].Items.Clear();


				while(!snpAC.EOF)
				{

					cbo_multi[2].AddItem(Convert.ToString(snpAC["changetype"]));

					snpAC.MoveNext();
				};

				cbo_multi[2].AddItem("All");
			}

			snpAC.Close();

		}




		private void Fill_Issues_Type()
		{
			//----------------------------------------------------------------------------------------------
			//Function used to fill the bad fractions grid
			//----------------------------------------------------------------------------------------------
			ADORecordSetHelper snpAC = new ADORecordSetHelper(); //aey 6/18/04
			string TheWholeThing = "";



			string Query = " select distinct issue_area, issue_title";
			Query = $"{Query} From Issue_All ";

			if (cbo_multi[0].Text.Trim() != "All")
			{
				Query = $"{Query} where issue_area = '{cbo_multi[0].Text.Trim()}' ";
			}

			Query = $"{Query} group by issue_area,issue_title ";
			Query = $"{Query} order by issue_area,issue_title ";


			snpAC.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

			//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
			if (!Convert.IsDBNull(snpAC.Fields) && !(snpAC.BOF && snpAC.EOF))
			{
				cbo_multi[1].Items.Clear();


				while(!snpAC.EOF)
				{

					cbo_multi[1].AddItem(Convert.ToString(snpAC["issue_title"]));

					snpAC.MoveNext();
				};

				cbo_multi[1].AddItem("All");
				cbo_multi[1].Text = "All";
			}

			snpAC.Close();

		}


		private void Fill_Bad_Fractions_Grid()
		{
			//----------------------------------------------------------------------------------------------
			//Function used to fill the Bad Fractions Grid
			//----------------------------------------------------------------------------------------------

			ADORecordSetHelper snpBadFractions = new ADORecordSetHelper(); //aey 6/18/04

			string tempRefParam = "Bad Fractions";
			search_on(ref tempRefParam);
			double tot = 0;
			txt_total_bad_fractional.Text = "";

			Stopped = false;
			grdBadFractions.Clear();
			grdBadFractions.ColumnsCount = 5;
			grdBadFractions.RowsCount = 1;

			//select percentage
			string Query = "SELECT DISTINCT ac_id, SUM(cref_owner_percent) as tpercent ";
			Query = $"{Query}FROM Aircraft_Reference WITH(NOLOCK) ";
			Query = $"{Query}inner join Aircraft WITH(NOLOCK) on (ac_id = cref_ac_id and ac_journ_id = cref_journ_id ) ";
			Query = $"{Query}inner join Aircraft_model WITH(NOLOCK) on (ac_amod_id=amod_id) ";
			Query = $"{Query}WHERE ac_ownership_type = 'F' AND ac_journ_id = 0 ";
			if (cmbProductType.Text.StartsWith("L", StringComparison.Ordinal))
			{ //aey 10/17/05
			}
			else if (cmbProductType.Text.StartsWith("A", StringComparison.Ordinal))
			{  //aey 10/17/05
				Query = $"{Query}AND ac_use_code <> 'C'  ";
				Query = $"{Query}AND (amod_airframe_type_code = 'F' or (amod_airframe_type_code = 'R' AND amod_class_code ='A')) ";
				Query = $"{Query}and ac_id not in( SELECT DISTINCT a2.ac_id FROM Aircraft_Reference r2 WITH(NOLOCK) ";
				Query = $"{Query}inner join Aircraft as a2 WITH(NOLOCK) on (a2.ac_id = r2.cref_ac_id and a2.ac_journ_id = r2.cref_journ_id ) ";
				Query = $"{Query}WHERE a2.ac_ownership_type = 'F' AND a2.ac_journ_id = 0 ";
				Query = $"{Query}AND a2.ac_use_code = 'C' ) ";
			}
			else if (cmbProductType.Text.StartsWith("B", StringComparison.Ordinal))
			{ 
				Query = $"{Query}AND amod_airframe_type_code = 'F' ";
			}
			else if (cmbProductType.Text.StartsWith("H", StringComparison.Ordinal))
			{ 
				Query = $"{Query}AND amod_airframe_type_code = 'R' AND amod_class_code ='A' ";
				Query = $"{Query}and ac_id not in( SELECT DISTINCT a2.ac_id FROM Aircraft_Reference r2 WITH(NOLOCK) ";
				Query = $"{Query}inner join Aircraft as a2 WITH(NOLOCK) on (a2.ac_id = r2.cref_ac_id and a2.ac_journ_id = r2.cref_journ_id ) ";
				Query = $"{Query}inner join Aircraft_model as m2 WITH(NOLOCK) on (a2.ac_amod_id=m2.amod_id) ";
				Query = $"{Query}WHERE a2.ac_ownership_type = 'F' AND a2.ac_journ_id = 0 ";
				Query = $"{Query}AND m2.amod_airframe_type_code = 'F') ";
			}
			else if (cmbProductType.Text.StartsWith("C", StringComparison.Ordinal))
			{ 
				Query = $"{Query}AND ac_use_code='C'  ";
				Query = $"{Query}and ac_id not in( SELECT DISTINCT a2.ac_id FROM Aircraft_Reference r2 WITH(NOLOCK) ";
				Query = $"{Query}inner join Aircraft as a2 WITH(NOLOCK) on (a2.ac_id = r2.cref_ac_id and a2.ac_journ_id = r2.cref_journ_id ) ";
				//Query = Query & "inner join Aircraft_model as m2 WITH(NOLOCK) on (a2.ac_amod_id=m2.amod_id) "
				Query = $"{Query}WHERE a2.ac_ownership_type = 'F' AND a2.ac_journ_id = 0 ";
				Query = $"{Query}AND a2.ac_use_code <>'C' ) ";
			}

			Query = $"{Query}GROUP BY ac_id";

			//Set snpBadFractions = LOCAL_DB.OpenRecordset(Query, dbOpenSnapshot, dbSQLPassThrough)
			snpBadFractions.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

			if (!(snpBadFractions.BOF && snpBadFractions.EOF))
			{
				//snpBadFractions.MoveLast 'aey 6/18/04
				snpBadFractions.MoveFirst();
				//UPGRADE_ISSUE: (2064) Threed.SSPanel property pnl_Fractional.Caption was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				pnl_Fractional.setCaption("Searching for Bad Fractionals...");

				while(!snpBadFractions.EOF)
				{
					Application.DoEvents();
					if (Stopped)
					{
						Stopped = false;
						break;
					}
					//populate grid if fractional ownership is not 100%
					if (Conversion.Val(($"{Convert.ToString(snpBadFractions["tpercent"])}").Trim()) != 100)
					{
						AddToBadFractionGrid(Convert.ToInt32(Double.Parse(($"{Convert.ToString(snpBadFractions["ac_id"])}").Trim())), Convert.ToInt32(Conversion.Val($"{Convert.ToString(snpBadFractions["tpercent"])}")));
						pnlFractionalPercentagesBad.Visible = true;
						grdBadFractions.Visible = true;
						tot++;
						txt_total_bad_fractional.Text = tot.ToString();
						cmdStop.Visible = true;
					}

					snpBadFractions.MoveNext();
				};

			}
			if (grdBadFractions.RowsCount > 1)
			{
				grdBadFractions.RemoveItem(0);
			}

			grdBadFractions.Redraw = true;

			search_off();

			//UPGRADE_ISSUE: (2064) Threed.SSPanel property pnl_Fractional.Caption was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			pnl_Fractional.setCaption("NO COMPANIES SELECTED");

			snpBadFractions.Close();

		}

		private void AddToBadFractionGrid(int PassedACID, int tpercent)
		{
			//----------------------------------------------------------------------------------------------
			//Function used to fill the bad fractions grid
			//----------------------------------------------------------------------------------------------
			ADORecordSetHelper snpAC = new ADORecordSetHelper(); //aey 6/18/04
			string TheWholeThing = "";

			string Query = "SELECT ac_id, ac_ser_no_full, ac_reg_no, amod_make_name, amod_model_name ";
			Query = $"{Query}FROM Aircraft WITH(NOLOCK), Aircraft_Model ";
			Query = $"{Query}WHERE ac_amod_id = amod_id ";
			Query = $"{Query}AND ac_journ_id = 0 ";
			Query = $"{Query}AND ac_id = {PassedACID.ToString()}";

			snpAC.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);


			if (!(snpAC.BOF && snpAC.EOF))
			{
				snpAC.MoveFirst(); //aey 6/1904
				TheWholeThing = $"{($"{Convert.ToString(snpAC["amod_make_name"])}").Trim()}{"\t"}{($"{Convert.ToString(snpAC["amod_model_name"])}").Trim()}{"\t"}{($"{Convert.ToString(snpAC["ac_ser_no_full"])}").Trim()}{"\t"}{($"{Convert.ToString(snpAC["ac_reg_no"])}").Trim()}{"\t"}{($"{tpercent.ToString()}").Trim()}";
				grdBadFractions.AddItem(TheWholeThing);
				grdBadFractions.set_RowData(grdBadFractions.RowsCount - 1, PassedACID);
			}

			snpAC.Close();

		}

		private void Fill_Fractional_Owner_Grid()
		{
			//******************************************************************************************
			//* Note: VBC id'd the following unreferenced items and handled them as described:         *
			//*                                                                                        *
			//* Local Variables (Removed)                                                              *
			//*  TotalAircraft                 cellcolor                                               *
			//******************************************************************************************

			//----------------------------------------------------------------------------------------------
			//Function used to fill the Fractional Grid
			//----------------------------------------------------------------------------------------------
			double TotalCompCallBacks = 0;
			string Query = "";

			try
			{

				string tempRefParam = "Fractional Owners";
				search_on(ref tempRefParam);

				lbl_fract_col6.Text = "Owner ID";
				lbl_fract_col7.Text = "#Aircraft";
				lbl_fract_col8.Text = " ";
				if (optBadFractions.Checked)
				{
					Fill_Bad_Fractions_Grid();
					return;
				}
				FindId = "Fractional Owner";
				SSTabHelper.SetSelectedIndex(tab_callback, 6);
				TotalCompCallBacks = 0;
				txt_Total_Comp_Callbacks.Text = "";

				Stopped = false;

				grdFractional.Clear();

				grdFractional.ColumnsCount = 7;
				grdFractional.RowsCount = 1;

				grdFractional.CurrentRowIndex = 0;
				grdFractional.CurrentColumnIndex = 0;
				grdFractional.SetColumnWidth(0, 60);

				grdFractional.SetColumnWidth(1, 267);
				grdFractional.SetColumnWidth(2, 167);
				grdFractional.SetColumnWidth(3, 33);
				grdFractional.SetColumnWidth(4, 87);
				grdFractional.SetColumnWidth(5, 53);
				grdFractional.SetColumnWidth(6, 33);

				//select fractional ownership records
				Query = "select distinct c.comp_id, c.comp_account_callback_date, c.comp_name, c.comp_city, c.comp_state, c.comp_timezone, c.comp_journ_id, c.comp_fractowr_id,count(*) as aircraft_count ";
				Query = $"{Query}From Company as C WITH(NOLOCK) ";
				Query = $"{Query}inner join Aircraft_Reference as R WITH(NOLOCK) on (c.comp_id = r.cref_comp_id And c.comp_journ_id = r.cref_journ_id) ";
				Query = $"{Query}inner join Aircraft as A WITH(NOLOCK) on (r.cref_ac_id=a.ac_id and r.cref_journ_id=a.ac_journ_id) ";
				Query = $"{Query}inner join Aircraft_model as M WITH(NOLOCK) on (M.amod_id = A.ac_amod_id) ";
				Query = $"{Query}Where (r.cref_contact_type='97') ";
				Query = $"{Query}and c.comp_journ_id= 0 ";
				//Query = Query & "and c.comp_id not in (select distinct cref_comp_id from Aircraft_Reference WITH(NOLOCK) "
				//Query = Query & "where cref_contact_type='00' or cref_contact_type='50') "
				if (chk_Current_Acct_Rep.CheckState == CheckState.Checked)
				{
					Query = $"{Query}and comp_account_id  {make_account_rep_answer_string()}"; // get only fractional owner current account rep
				}
				if (chk_Date_Less_Than.CheckState == CheckState.Checked)
				{
					Query = $"{Query}and comp_account_callback_date <= '{txt_Callback_Date.Text}' "; //get only fractional owner date <= call back date
				}

				if (cmbProductType.Text.StartsWith("L", StringComparison.Ordinal))
				{
				}
				else if (cmbProductType.Text.StartsWith("A", StringComparison.Ordinal))
				{ 
					Query = $"{Query}AND (m.amod_airframe_type_code = 'F' or (m.amod_airframe_type_code = 'R')) ";

				}
				else if (cmbProductType.Text.StartsWith("B", StringComparison.Ordinal))
				{ 
					Query = $"{Query}AND m.amod_airframe_type_code = 'F' ";

				}
				else if (cmbProductType.Text.StartsWith("H", StringComparison.Ordinal))
				{ 
					Query = $"{Query}AND m.amod_airframe_type_code = 'R' ";

				}
				else if (cmbProductType.Text.StartsWith("C", StringComparison.Ordinal))
				{ 
					Query = $"{Query}AND ac_product_commercial_flag='Y' ";

				}
				else if (cmbProductType.Text.StartsWith("P", StringComparison.Ordinal))
				{ 
					Query = $"{Query}AND ac_product_airbp_flag='Y' ";

				}

				Query = $"{Query}group by c.comp_id,c.comp_account_callback_date,c.comp_name,c.comp_city,c.comp_state,c.comp_timezone, c.comp_journ_id,c.comp_fractowr_id ";
				Query = $"{Query}{strFractOrderBy}";

				snpFractional = new ADORecordSetHelper();
				snpFractional.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpFractional.BOF && snpFractional.EOF))
				{

					pnl_fractional_display.Visible = true;
					cmdStop.Visible = true;
					grdFractional.Redraw = false;


					while(!snpFractional.EOF)
					{

						if (Stopped)
						{
							Stopped = false;
							break;
						}

						//fill grid

						grdFractional.CurrentColumnIndex = 0;
						grdFractional[grdFractional.CurrentRowIndex, grdFractional.CurrentColumnIndex].Value = $"{Convert.ToDateTime(snpFractional["comp_account_callback_date"]).ToString("d")} ";
						grdFractional.CurrentColumnIndex = 1;
						grdFractional.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						grdFractional[grdFractional.CurrentRowIndex, grdFractional.CurrentColumnIndex].Value = ($"{Convert.ToString(snpFractional["comp_name"])} ").Trim();
						grdFractional.CurrentColumnIndex = 2;
						grdFractional[grdFractional.CurrentRowIndex, grdFractional.CurrentColumnIndex].Value = ($"{Convert.ToString(snpFractional["Comp_city"])} ").Trim();
						grdFractional.CurrentColumnIndex = 3;
						grdFractional[grdFractional.CurrentRowIndex, grdFractional.CurrentColumnIndex].Value = ($"{Convert.ToString(snpFractional["comp_state"])} ").Trim();
						grdFractional.CurrentColumnIndex = 4;
						grdFractional[grdFractional.CurrentRowIndex, grdFractional.CurrentColumnIndex].Value = ($"{Convert.ToString(snpFractional["comp_timezone"])} ").Trim();
						grdFractional.CurrentColumnIndex = 5;
						grdFractional[grdFractional.CurrentRowIndex, grdFractional.CurrentColumnIndex].Value = ($"{Convert.ToString(snpFractional["comp_fractowr_id"])} ").Trim();
						grdFractional.CurrentColumnIndex = 6;
						grdFractional[grdFractional.CurrentRowIndex, grdFractional.CurrentColumnIndex].Value = snpFractional.GetField("aircraft_count");

						grdFractional.set_RowData(grdFractional.CurrentRowIndex, Convert.ToInt32(snpFractional.GetField("comp_id")));

						TotalCompCallBacks++;
						txt_Total_Comp_Callbacks.Text = TotalCompCallBacks.ToString();
						snpFractional.MoveNext();
						grdFractional.RowsCount++;
						grdFractional.CurrentRowIndex++;

						if (TotalCompCallBacks == 20)
						{
							grdFractional.Redraw = true;
							grdFractional.Refresh();
							Application.DoEvents();
							grdFractional.Redraw = false;
						}

					}; // Do While Not snpFractional.EOF

					grdFractional.Redraw = true;
					Application.DoEvents();

					cmdStop.Visible = false;
					grdFractional.RowsCount--;

				}
				else
				{
					pnl_fractional_display.Visible = false;
				} // If Not (snpFractional.BOF And snpFractional.EOF) Then

				HadHourglass = false;
				search_off();

				pnl_Fractional.Visible = true;
				//UPGRADE_ISSUE: (2064) Threed.SSPanel property pnl_Fractional.Caption was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				pnl_Fractional.setCaption("NO COMPANIES SELECTED");
			}
			catch (System.Exception excep)
			{

				snpFractional = null;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_Fractional_Owner_Grid_Error: {excep.Message},{Information.Err().Number.ToString()},Callbacks:{TotalCompCallBacks.ToString()}");
				search_off();
				HadHourglass = false;
			}

		}

		private void tbr_AL_ToolBar_ButtonClick(Object eventSender, EventArgs eventArgs)
		{
			ToolStripItem Button = (ToolStripItem) eventSender;
			//******************************************************************************************
			//* Note: VBC id'd the following unreferenced items and handled them as described:         *
			//*                                                                                        *
			//* Local Variables (Removed)                                                              *
			//*  RESP                                                                                  *
			//******************************************************************************************

			try
			{


				switch(Button.Name)
				{
					case "Home" : 
						modAdminCommon.gbl_bHomeClicked = true; 
						this.Close(); 
						 
						break;
					case "Back" : 
						mnuFileClose_Click(mnuFileClose, new EventArgs()); 
						 
						break;
					case "Help" : 
						MessageBox.Show("Help is forthcoming", "Action List", MessageBoxButtons.OK, MessageBoxIcon.Information); 
						 
						break;
					default:
						MessageBox.Show("ToolBar Error", "Unrecognized Toolbar Reference", MessageBoxButtons.OK, MessageBoxIcon.Information); 
						 
						break;
				}
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"tbr_AL_ToolBar_Error ({Information.Err().Number.ToString()}) {excep.Message}");
				search_off();
			}

		}

		private void Fill_New_Assignment_Grid()
		{

			//******************************************************************************************
			//*    8/3/2007 - RTW
			//*    MODIFIED WITH NEW QUERY FROM DAVID CRUGER TO SPEED UP SEARCH TO INCLUDE ONLY LATEST 30 DAYS OF DATA
			//*    8/7/2007 - David D. Cruger
			//*    Modified the Query again, more stream line and removed the IN (SELECT) statement
			//*    9/14/2010 - RTW - MODIFIED QUERIES TO NOT INCLUDE CLASS C HELICOPTER STUFF
			//******************************************************************************************

			//----------------------------------------------------------------------------------------------
			//Function used to fill the New Assignment Grid
			//----------------------------------------------------------------------------------------------

			string Query = "";

			double TotalReassigns = 0;
			string cellcolor = "";
			string strAcctRep = "";
			string strAcctRepId = "";
			string strSelect = "";
			int lCol = 0;

			string strMsg = "";
			System.DateTime dtStartDate = DateTime.FromOADate(0);
			System.DateTime dtEndDate = DateTime.FromOADate(0);

			try
			{

				if (cbo_account_id.Text.Trim() == "No Rep Selected" && opt_AllReassigns.Checked)
				{
					if (MessageBox.Show($"No Rep Selected and All Reassigns Selected{Environment.NewLine}{Environment.NewLine}This is a very BIG List{Environment.NewLine}{Environment.NewLine}Are You Sure You Want To Run This?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
					{
						return;
					}
				}

				modCommon.Start_Activity_Monitor_Message("Callback Reassigns", ref strMsg, ref dtStartDate, ref dtEndDate);

				if (!opt_last30.Checked && !opt_AllReassigns.Checked)
				{
					opt_last30.Checked = true;
				}

				strMsg = "init";
				string tempRefParam = "Account Reassignments";
				search_on(ref tempRefParam);
				FindId = "Reassignments";
				pnl_lstcompany.Visible = false;
				cmd_Refresh_Reassignments.Enabled = false;

				cellcolor = modAdminCommon.HeadingColor;

				txt_total_reassigns.Text = "";
				TotalReassigns = 0;

				lbl_Reassign_Message.Text = "  ";
				strMsg = "grid";
				grd_NewAssignments.Enabled = false;
				grd_NewAssignments.Clear();
				grd_NewAssignments.ColumnsCount = 13;
				grd_NewAssignments.RowsCount = 2;
				grd_NewAssignments.FixedRows = 1;

				grd_NewAssignments.CurrentRowIndex = 0;
				lCol = -1;

				lCol++;
				grd_NewAssignments.CurrentColumnIndex = lCol;
				grd_NewAssignments.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
				grd_NewAssignments.SetColumnWidth(lCol, 160);
				grd_NewAssignments[grd_NewAssignments.CurrentRowIndex, grd_NewAssignments.CurrentColumnIndex].Value = "Make/Model ";

				lCol++;
				grd_NewAssignments.CurrentColumnIndex = lCol;
				grd_NewAssignments.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
				grd_NewAssignments.SetColumnWidth(lCol, 67);
				grd_NewAssignments[grd_NewAssignments.CurrentRowIndex, grd_NewAssignments.CurrentColumnIndex].Value = "Serial#";

				lCol++;
				grd_NewAssignments.CurrentColumnIndex = lCol;
				grd_NewAssignments.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
				grd_NewAssignments.SetColumnWidth(lCol, 67);
				grd_NewAssignments[grd_NewAssignments.CurrentRowIndex, grd_NewAssignments.CurrentColumnIndex].Value = "Reg#";

				lCol++;
				grd_NewAssignments.CurrentColumnIndex = lCol;
				grd_NewAssignments.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
				grd_NewAssignments.SetColumnWidth(lCol, 67);
				grd_NewAssignments[grd_NewAssignments.CurrentRowIndex, grd_NewAssignments.CurrentColumnIndex].Value = "Date";

				lCol++;
				grd_NewAssignments.CurrentColumnIndex = lCol;
				grd_NewAssignments.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
				grd_NewAssignments.SetColumnWidth(lCol, 300);
				grd_NewAssignments[grd_NewAssignments.CurrentRowIndex, grd_NewAssignments.CurrentColumnIndex].Value = "Company";

				lCol++;
				grd_NewAssignments.CurrentColumnIndex = lCol;
				grd_NewAssignments.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
				grd_NewAssignments.SetColumnWidth(lCol, 40);
				grd_NewAssignments[grd_NewAssignments.CurrentRowIndex, grd_NewAssignments.CurrentColumnIndex].Value = "State";

				lCol++;
				grd_NewAssignments.CurrentColumnIndex = lCol;
				grd_NewAssignments.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
				grd_NewAssignments.SetColumnWidth(lCol, 100);
				grd_NewAssignments[grd_NewAssignments.CurrentRowIndex, grd_NewAssignments.CurrentColumnIndex].Value = "Country";

				lCol++;
				grd_NewAssignments.CurrentColumnIndex = lCol;
				grd_NewAssignments.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
				grd_NewAssignments.SetColumnWidth(lCol, 100);
				grd_NewAssignments[grd_NewAssignments.CurrentRowIndex, grd_NewAssignments.CurrentColumnIndex].Value = "Previous Account";

				lCol++;
				grd_NewAssignments.CurrentColumnIndex = lCol;
				grd_NewAssignments.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
				grd_NewAssignments.SetColumnWidth(lCol, 83);
				grd_NewAssignments[grd_NewAssignments.CurrentRowIndex, grd_NewAssignments.CurrentColumnIndex].Value = "Last Attempt";

				lCol++;
				grd_NewAssignments.CurrentColumnIndex = lCol;
				grd_NewAssignments.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
				grd_NewAssignments.SetColumnWidth(lCol, 73);
				grd_NewAssignments[grd_NewAssignments.CurrentRowIndex, grd_NewAssignments.CurrentColumnIndex].Value = "# Primary A/C";

				lCol++;
				grd_NewAssignments.CurrentColumnIndex = lCol;
				grd_NewAssignments.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
				grd_NewAssignments.SetColumnWidth(lCol, 67);
				grd_NewAssignments[grd_NewAssignments.CurrentRowIndex, grd_NewAssignments.CurrentColumnIndex].Value = "RADN";

				lCol++;
				grd_NewAssignments.CurrentColumnIndex = lCol;
				grd_NewAssignments.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
				grd_NewAssignments.SetColumnWidth(lCol, 93);
				grd_NewAssignments[grd_NewAssignments.CurrentRowIndex, grd_NewAssignments.CurrentColumnIndex].Value = "Last/Att Reassign";

				lCol++;
				grd_NewAssignments.CurrentColumnIndex = lCol;
				grd_NewAssignments.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
				grd_NewAssignments.SetColumnWidth(lCol, 80);
				grd_NewAssignments[grd_NewAssignments.CurrentRowIndex, grd_NewAssignments.CurrentColumnIndex].Value = "IQ Last Attempt";



				Stopped = false;

				strMsg = "sql";

				//-------------------------------------------------------------------------
				// 08/07/2007 - By David D. Cruger
				// Reworked the query even more and removed the IN (SELECT) Statement
				//-------------------------------------------------------------------------
				Query = "SELECT journ_entry_date, ac_id, ac_amod_id, ac_ser_no_full, ac_reg_no, ";
				Query = $"{Query}journ_id, journ_comp_id, journ_date, journ_prior_account_id, journ_account_id, ";
				Query = $"{Query}comp_name, comp_state, comp_country, Comp_id, comp_journ_id, amod_make_name, amod_model_name, ";


				Query = $"{Query} comp_abi_callback_date, ";

				// 03/19/2015 - By David D. Cruger
				// Added Last Attempted Date

				Query = $"{Query}(SELECT CAST(MAX(journ_date) AS DATE) As dtLastAttempted FROM Journal WITH (NOLOCK) ";
				Query = $"{Query}WHERE (journ_comp_id = C1.comp_id) ";
				Query = $"{Query}AND (journ_subject = 'Attempted to Contact') ";
				Query = $"{Query}) As dtLastAttempted, ";

				// ADDED MSW - 6/7/2020 dont seem to be a ton, but last RAAT note added
				Query = $"{Query}(SELECT CAST(MAX(journ_date) AS DATE) FROM Journal WITH (NOLOCK) ";
				Query = $"{Query}WHERE (journ_comp_id = C1.comp_id) ";
				Query = $"{Query}AND journ_subcategory_code = 'RAAT' ";
				Query = $"{Query}) As dtLastAttemptedReassign , ";

				// 04/14/2015 - By David D. Cruger
				// Added Number of Primary Aircraft

				Query = $"{Query}(SELECT COUNT(DISTINCT AR2.cref_ac_id) ";
				Query = $"{Query} FROM Aircraft_Reference AS AR2 WITH (NOLOCK) ";
				Query = $"{Query} INNER JOIN Aircraft AS A2 WITH (NOLOCK) ON A2.ac_id = AR2.cref_ac_id AND A2.ac_journ_id = AR2.cref_journ_id ";
				Query = $"{Query} INNER JOIN Aircraft_Model AS AM2 WITH (NOLOCK) ON AM2.amod_id = A2.ac_amod_id ";
				Query = $"{Query} WHERE (AR2.cref_comp_id = C1.comp_id)  ";
				Query = $"{Query} AND (AR2.cref_journ_id = C1.comp_journ_id) ";
				Query = $"{Query} AND (AR2.cref_primary_poc_flag = 'Y') ";


				// added MSW - 9/9/20
				if (cbo_Timezones.Text != "All")
				{
					if (cbo_Timezones.Text == "International")
					{
						Query = $"{Query}AND ((C1.comp_timezone is NULL) or (comp_timezone=''))";
					}
					else
					{
						Query = $"{Query}AND (C1.comp_timezone='{cbo_Timezones.Text}') ";
					}
				}



				// 06/04/2015 - Per Lucia Do NOT Include Class E
				Query = $"{Query} AND (AM2.amod_class_code <> 'E') ";

				strSelect = cmbProductType.Text.Substring(0, Math.Min(1, cmbProductType.Text.Length));


				switch(strSelect)
				{
					case "A" :  // - Helicopters and Business Aircraft 
						Query = $"{Query}AND (A2.ac_product_business_flag = 'Y' OR A2.ac_product_helicopter_flag = 'Y') "; 
						 
						break;
					case "B" :  // - Business Aircraft 
						Query = $"{Query}AND (A2.ac_product_business_flag = 'Y') "; 
						 
						break;
					case "C" :  // - Commercial 
						Query = $"{Query}AND (A2.ac_product_commercial_flag = 'Y') "; 
						 
						break;
					case "H" :  // - Helicopters 
						Query = $"{Query}AND (A2.ac_product_helicopter_flag = 'Y') "; 
						 
						break;
					case "L" :  // - All 
						 
						break;
					case "P" :  // - AirBP 
						Query = $"{Query}AND (A2.ac_product_airbp_flag = 'Y') "; 
						 
						break;
				} // strSelect

				Query = $"{Query}) As lACCnt ";



				Query = $"{Query}, (SELECT TOP 1 journ_date FROM Journal WITH (NOLOCK) ";
				Query = $"{Query} WHERE (journ_comp_id = C1.comp_id) ";
				Query = $"{Query} AND ( ";
				Query = $"{Query}       (journ_subcategory_code = 'IQ') ";
				Query = $"{Query}    OR (journ_subcategory_code = 'RN' AND journ_subject LIKE '%JNiQ%') ";
				Query = $"{Query}     ) ";
				Query = $"{Query} ORDER BY journ_date DESC ";
				Query = $"{Query}) As dtJNiQLastAttemptedDate ";



				// 07/18/2019 - By David D. Cruger; Removed INDEX HINT
				//Query = Query & "FROM Journal AS J1 WITH (NOLOCK, INDEX(" & chr(34) & "ix_journ_account_subcat_key" & chr(34) & ")) "
				Query = $"{Query}FROM Journal AS J1 WITH (NOLOCK) ";
				//Query = Query & "INNER JOIN Aircraft AS A1 WITH (NOLOCK, INDEX(" & chr(34) & "PK_Aircraft" & chr(34) & ")) ON J1.journ_ac_id = A1.ac_id AND A1.ac_journ_id = 0 "
				Query = $"{Query}INNER JOIN Aircraft AS A1 WITH (NOLOCK) ON J1.journ_ac_id = A1.ac_id AND A1.ac_journ_id = 0 ";
				Query = $"{Query}INNER JOIN Aircraft_Model AS AM1 WITH (NOLOCK) ON A1.ac_amod_id = AM1.amod_id ";
				Query = $"{Query}INNER JOIN Aircraft_Reference AS AR1 WITH (NOLOCK) ON ac_id = cref_ac_id AND cref_journ_id = ac_journ_id ";


				// If chk_action_list(11).Value = 1 Then
				//      Query = Query & " and not ( cref_business_type = 'DB' and (cref_owner_percent = 0 or cref_owner_percent is null)) "
				//  End If

				Query = $"{Query}INNER JOIN Company AS C1 WITH (NOLOCK) ON AR1.cref_comp_id = C1.comp_id AND AR1.cref_journ_id = C1.comp_journ_id ";

				Query = $"{Query}WHERE (J1.journ_subcategory_code = 'AA') ";

				if (cbo_account_id.Text.Trim() != "No Rep Selected")
				{
					// changed MSW - 3/1/2019 - to relfect current company account rep. not the acc rep at the time of the trans
					//  Query = Query & "AND(J1.journ_account_id = '" & Trim(cbo_account_id.Text) & "') "
					Query = $"{Query}AND C1.comp_account_id {make_account_rep_answer_string()}";
				}

				Query = $"{Query}AND (AR1.cref_primary_poc_flag='Y') ";

				Query = $"{Query}{Find_Models_Excluded("", "A1", "Aircraft")}";

				// CHANGE TO SPEED SEARCH
				if (opt_last30.Checked)
				{
					Query = $"{Query}AND (J1.journ_entry_date >= '{DateTimeHelper.ToString(DateTime.Parse(txt_Callback_Date.Text).AddDays(-30))}') ";
				}


				if (chk_action_list[11].CheckState == CheckState.Checked)
				{
					// and there exists a relationship to a DB within the last 180 days.
					Query = $"{Query} and exists(";
					Query = $"{Query} select top 1 cref_ac_id from Aircraft_Reference with (NOLOCK)";
					Query = $"{Query} inner join company with (NOLOCK) on cref_comp_id = comp_id and cref_business_type = 'DB' and comp_journ_id = cref_journ_id";
					Query = $"{Query} inner join Journal with (NOLOCK) on journ_id = cref_journ_id";
					Query = $"{Query} Where cref_ac_id = AC_ID And journ_date >= GetDate() - 180";
					Query = $"{Query} )";

					// and it has come off exclusive within 180 days
					//-- and off exclusive in last 6 months
					Query = $"{Query} and (";
					Query = $"{Query} exists((select top 1 * from journal with (NOLOCK) where journ_ac_id = ac_id and journ_subcategory_code = 'EXOFF' and journ_date >= getdate()-180))";
					Query = $"{Query} OR exists((select top 1 * from journal with (NOLOCK) where journ_ac_id = ac_id and journ_subcategory_code = 'OM' and journ_date >= getdate()-180))";
					Query = $"{Query} )";


					// and there wasnt an internal sold
					// right 2 of journ cat = IT

					//Exclude Internal Solds. Below is an example with the transaction code.
					//However, the WS (whole sale) may change to SS (Share Sale) and the EU may change as well.
					//The only constant is the IT.
					Query = $"{Query} and not ";
					Query = $"{Query} exists( ";
					Query = $"{Query} select top 1 * from journal with (NOLOCK) where journ_ac_id = ac_id and right(journ_subcategory_code, 2) = 'IT' ";
					Query = $"{Query} and journ_date >= getdate()-180   ";
					Query = $"{Query} )";


					//Exclude those where the owner has retained possession.
					//These two highlighted statements need to be together (one right after the other) in order for it to be excluded

					// and there does not exist an off market in the last 180 days where right after it there was a verified as not for sale
					Query = $"{Query} and not exists(";
					Query = $"{Query} select top 1 * from journal j1 with (NOLOCK) where j1.journ_ac_id = ac_id and j1.journ_subcat_code_part1 = 'OM'";
					Query = $"{Query} and j1.journ_action_date > getdate()-180";

					Query = $"{Query} and exists(";
					Query = $"{Query} select top 1 * from journal j2 with (NOLOCK) where j2.journ_ac_id = j1.journ_ac_id and j2.journ_subject = 'Verified status as Not for Sale'";
					Query = $"{Query} and j2.journ_action_date > getdate()-180";
					Query = $"{Query} and j2.journ_id > j1.journ_id and j2.journ_id < (j1.journ_id + 25)";
					Query = $"{Query} )";
					Query = $"{Query} )";

				}



				// added MSW - 6/2/21
				if (cbo_Timezones.Text != "All")
				{
					if (cbo_Timezones.Text == "International")
					{
						Query = $"{Query}AND ((C1.comp_timezone is NULL) or (comp_timezone=''))";
					}
					else
					{
						Query = $"{Query}AND (C1.comp_timezone='{cbo_Timezones.Text}') ";
					}
				}



				strSelect = cmbProductType.Text.Substring(0, Math.Min(1, cmbProductType.Text.Length));
				strAcctRep = cbo_account_id.Text.Substring(0, Math.Min(2, cbo_account_id.Text.Length)).ToUpper();
				strAcctRepId = cbo_account_id.Text.ToUpper();


				switch(strSelect)
				{
					case "A" :  // - Helicopters and Business Aircraft 
						Query = $"{Query}AND ((AM1.amod_airframe_type_code = 'F' OR AM1.amod_airframe_type_code = 'R') "; 
						Query = $"{Query}and ((A1.ac_product_business_flag = 'Y') or (A1.ac_product_helicopter_flag = 'Y'))) "; 
						 
						break;
					case "B" :  // - Business Aircraft 
						Query = $"{Query}AND (AM1.amod_airframe_type_code = 'F') "; 
						Query = $"{Query}AND (A1.ac_product_business_flag = 'Y') "; 
						 
						break;
					case "C" :  // - Commercial 
						Query = $"{Query}AND (A1.ac_product_commercial_flag = 'Y') "; 
						 
						break;
					case "H" :  // - Helicopters 
						Query = $"{Query}AND (AM1.amod_airframe_type_code = 'R') "; 
						// NO LONGER REQUIRED - RTW - 9/15/2010 
						// Query = Query & "AND (AM1.amod_class_code = 'A') " 
						Query = $"{Query}AND (A1.ac_product_helicopter_flag = 'Y') "; 
						 
						break;
					case "L" :  // - All 
						 
						break;
					case "Q" :  // JNiQ Eligible 
						 
						Query = $"{Query}{modCommon.Return_JNiQ_Eligible_Query(strAcctRep, Query)}"; 
						 
						break;
					case "N" :  // Non-JNiQ Eligible 
						 
						Query = $"{Query}{modCommon.Return_Non_JNiQ_Eligible_Query()}"; 
						 
						break;
					case "P" :  // - AirBP 
						 
						Query = $"{Query}AND (A1.ac_product_airbp_flag = 'Y') "; 
						 
						break;
				} // strSelect

				// Query = Query & "  and j1.journ_id = (select top 1 j3.journ_id from Journal j3 with (NOLOCK) where j3.journ_ac_id = j1.journ_ac_id and (j3.journ_subcategory_code = 'AA')  order by journ_date desc ) "

				if (strReassignOrderBy == "")
				{
					strReassignOrderBy = "A1.ac_ser_no_full";
				}

				Query = $"{Query}ORDER BY {strReassignOrderBy}";

				strMsg = "ado ";

				if (snp_NewAssign != null)
				{
					if (snp_NewAssign.State == ConnectionState.Open)
					{
						snp_NewAssign.Close();
					}
					snp_NewAssign = null;
				}

				snp_NewAssign = new ADORecordSetHelper();

				modAdminCommon.Record_Event("Monitor Activity", $"Reassigns - Selected AcctRep: {strAcctRepId}");
				//Record_Event "HB Usage", "Reassigns - Selected AcctRep: " & strAcctRepId

				snp_NewAssign.CursorLocation = CursorLocationEnum.adUseClient;
				snp_NewAssign.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!snp_NewAssign.BOF && !snp_NewAssign.EOF)
				{

					string tempRefParam2 = "Account Reassignments";
					search_on(ref tempRefParam2, snp_NewAssign.RecordCount);

					tab_callback.Enabled = true;

					pnl_reassignemnt.Visible = true;
					pnl_reassignemnt.Enabled = true;

					lblReassignStopLoading.Visible = true;
					lblReassignStopLoading.Enabled = true;
					grd_NewAssignments.Visible = false;
					grd_NewAssignments.Redraw = false;
					grd_NewAssignments.CurrentRowIndex = 1;

					do 
					{ // Loop Until snp_NewAssign.EOF = True Or lblReassignStopLoading.Visible = False

						lCol = -1;

						lCol++;
						grd_NewAssignments.CurrentColumnIndex = lCol;
						
						grd_NewAssignments.ColAlignment[lCol] = DataGridViewContentAlignment.MiddleLeft;
						grd_NewAssignments[grd_NewAssignments.CurrentRowIndex, grd_NewAssignments.CurrentColumnIndex].Value = $"{($"{Convert.ToString(snp_NewAssign["amod_make_name"])} ").Trim()}/{($"{Convert.ToString(snp_NewAssign["amod_model_name"])} ").Trim()}";

						lCol++;
						grd_NewAssignments.CurrentColumnIndex = lCol;
						
						grd_NewAssignments.ColAlignment[lCol] = DataGridViewContentAlignment.MiddleLeft;
						grd_NewAssignments[grd_NewAssignments.CurrentRowIndex, grd_NewAssignments.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_NewAssign["ac_ser_no_full"])} ").Trim();

						lCol++;
						grd_NewAssignments.CurrentColumnIndex = lCol;
						
						grd_NewAssignments.ColAlignment[lCol] = DataGridViewContentAlignment.MiddleLeft;
						grd_NewAssignments[grd_NewAssignments.CurrentRowIndex, grd_NewAssignments.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_NewAssign["ac_reg_no"])} ").Trim();

						lCol++;
						grd_NewAssignments.CurrentColumnIndex = lCol;
						grd_NewAssignments.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snp_NewAssign["journ_date"]))
						{
							grd_NewAssignments[grd_NewAssignments.CurrentRowIndex, grd_NewAssignments.CurrentColumnIndex].Value = Convert.ToDateTime(snp_NewAssign["journ_date"]).ToString("MM/dd/yyyy");
						}

						lCol++;
						grd_NewAssignments.CurrentColumnIndex = lCol;
						
						grd_NewAssignments.ColAlignment[lCol] = DataGridViewContentAlignment.MiddleLeft;
						grd_NewAssignments[grd_NewAssignments.CurrentRowIndex, grd_NewAssignments.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_NewAssign["comp_name"])} ").Trim();

						lCol++;
						grd_NewAssignments.CurrentColumnIndex = lCol;
						grd_NewAssignments.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
						grd_NewAssignments[grd_NewAssignments.CurrentRowIndex, grd_NewAssignments.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_NewAssign["comp_state"])} ").Trim();

						lCol++;
						grd_NewAssignments.CurrentColumnIndex = lCol;
						
						grd_NewAssignments.ColAlignment[lCol] = DataGridViewContentAlignment.MiddleLeft;
						grd_NewAssignments[grd_NewAssignments.CurrentRowIndex, grd_NewAssignments.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_NewAssign["Comp_country"])} ").Trim();

						lCol++;
						grd_NewAssignments.CurrentColumnIndex = lCol;
						grd_NewAssignments.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
						grd_NewAssignments[grd_NewAssignments.CurrentRowIndex, grd_NewAssignments.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_NewAssign["journ_prior_account_id"])} ").Trim();

						lCol++;
						grd_NewAssignments.CurrentColumnIndex = lCol;
						grd_NewAssignments.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snp_NewAssign["dtLastAttempted"]))
						{
							grd_NewAssignments[grd_NewAssignments.CurrentRowIndex, grd_NewAssignments.CurrentColumnIndex].Value = Convert.ToDateTime(snp_NewAssign["dtLastAttempted"]).ToString("MM/dd/yyyy");
						}

						// 04/14/2015 - By David D. Cruger
						// Added Number of Primary Aircraft
						lCol++;
						grd_NewAssignments.CurrentColumnIndex = lCol;
						grd_NewAssignments.CellAlignment = DataGridViewContentAlignment.MiddleRight;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snp_NewAssign["lACCnt"]))
						{
							grd_NewAssignments[grd_NewAssignments.CurrentRowIndex, grd_NewAssignments.CurrentColumnIndex].Value = StringsHelper.Format(snp_NewAssign["lACCnt"], "#,##0");
						}


						lCol++;
						grd_NewAssignments.CurrentColumnIndex = lCol;
						grd_NewAssignments.CellAlignment = DataGridViewContentAlignment.MiddleRight; // RE_USED FIELD - RADN - REASSIGN
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snp_NewAssign["comp_abi_callback_date"]))
						{
							grd_NewAssignments[grd_NewAssignments.CurrentRowIndex, grd_NewAssignments.CurrentColumnIndex].Value = Convert.ToDateTime(snp_NewAssign["comp_abi_callback_date"]).ToString("MM/dd/yyyy");
						}


						lCol++;
						grd_NewAssignments.CurrentColumnIndex = lCol;
						grd_NewAssignments.CellAlignment = DataGridViewContentAlignment.MiddleRight;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snp_NewAssign["dtLastAttemptedReassign"]))
						{
							grd_NewAssignments[grd_NewAssignments.CurrentRowIndex, grd_NewAssignments.CurrentColumnIndex].Value = snp_NewAssign.GetField("dtLastAttemptedReassign");
						}


						lCol++;
						grd_NewAssignments.CurrentColumnIndex = lCol;
						grd_NewAssignments.CellAlignment = DataGridViewContentAlignment.MiddleRight;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snp_NewAssign["dtJNiQLastAttemptedDate"]))
						{
							grd_NewAssignments[grd_NewAssignments.CurrentRowIndex, grd_NewAssignments.CurrentColumnIndex].Value = Convert.ToDateTime(snp_NewAssign["dtJNiQLastAttemptedDate"]).ToString("MM/dd/yyyy");
						}



						grd_NewAssignments.set_RowData(grd_NewAssignments.CurrentRowIndex, Convert.ToInt32(snp_NewAssign["comp_id"]));
						//UPGRADE_ISSUE: (2064) MSHierarchicalFlexGridLib.MSHFlexGrid property grd_NewAssignments.BandData was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						grd_NewAssignments.setBandData(Convert.ToInt32(snp_NewAssign["ac_id"]), grd_NewAssignments.CurrentRowIndex);

						snp_NewAssign.MoveNext();
						Application.DoEvents();

						grd_NewAssignments.RowsCount++;
						grd_NewAssignments.CurrentRowIndex++;

						TotalReassigns++;
						txt_total_reassigns.Text = TotalReassigns.ToString();

						if (TotalReassigns == 21)
						{
							grd_NewAssignments.Visible = true;
							grd_NewAssignments.Redraw = true;
							Application.DoEvents();
							grd_NewAssignments.Redraw = false;
						}

					}
					while(!(snp_NewAssign.EOF || !lblReassignStopLoading.Visible));

					lblReassignStopLoading.Visible = false;
					lblReassignStopLoading.Enabled = false;

					Stopped = false;

					grd_NewAssignments.RowsCount--;
					grd_NewAssignments.CurrentRowIndex = 1;
					grd_NewAssignments.Visible = true;
					grd_NewAssignments.Redraw = true;
					grd_NewAssignments.Enabled = true;

				}
				else
				{
					pnl_reassignemnt.Visible = false;
					lbl_Reassign_Message.Text = "No Reassignments Selected.";
					grd_NewAssignments.CurrentRowIndex = 1;
					grd_NewAssignments.CurrentColumnIndex = 0;
					grd_NewAssignments[grd_NewAssignments.CurrentRowIndex, grd_NewAssignments.CurrentColumnIndex].Value = "No Reassignments Found";
					grd_NewAssignments.Enabled = false;
				} // If (snp_NewAssign.BOF = False And snp_NewAssign.EOF = False) Then

				lblReassignStopLoading.Visible = false;
				strMsg = $"AcctRep: {cbo_account_id.Text}";

				if (opt_last30.Checked)
				{
					strMsg = $"{strMsg} (*) Last 30 Days ";
				}
				if (opt_AllReassigns.Checked)
				{
					strMsg = $"{strMsg} (*) All Reassigns ";
				}

				if (bLog)
				{

					modCommon.End_Activity_Monitor_Message("Callback Reassigns", ref strMsg, dtStartDate, ref dtEndDate, 0, 0, 0, 0, 0);

					frm_UserHistory.DefInstance.Refresh_User_History_Grids("Callback");

				}

				HadHourglass = false;
				cmd_Refresh_Reassignments.Enabled = true;

				grd_NewAssignments.Redraw = true;
				search_off();
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_New_Assignment_Grid_Error ({Information.Err().Number.ToString()}) {excep.Message} : calldt[{txt_Callback_Date.Text.Trim()}] acctid[{cbo_account_id.Text.Trim()}]", "frm_ActionList(NEWASSIGN)");

				search_off();
				HadHourglass = false;
				snp_NewAssign = null;
			}

		} // Fill_New_Assignment_Grid

		public void Fill_Comp_Confirm_Grid(string order_by = "")
		{

			//******************************************************************************************
			//* Note: VBC id'd the following unreferenced items and handled them as described:         *
			//*                                                                                        *
			//* Local Variables (Removed)                                                              *
			//*  TempLocation                                                                          *
			//******************************************************************************************

			//----------------------------------------------------------------------------------------------
			//Function used to fill the company confirm Grid
			//----------------------------------------------------------------------------------------------

			string Query = "";
			System.DateTime tempconfirmdate = DateTime.FromOADate(0);
			string cellcolor = "";
			double TotalConfirms = 0;
			int RememberTimeout = 0;
			string strAcctRep = "";
			string strAcctRepId = "";
			string strCCType = "";
			string strCCTypeQuery = "";
			int lRow1 = 0;
			int lCol1 = 0;
			string strMsg = "";
			System.DateTime dtStartDate = DateTime.FromOADate(0);
			System.DateTime dtEndDate = DateTime.FromOADate(0);

			try
			{

				modCommon.Start_Activity_Monitor_Message("Callback Color Confirm", ref strMsg, ref dtStartDate, ref dtEndDate);

				string tempRefParam = "Company Color Confirm";
				search_on(ref tempRefParam);

				cmd_Refresh_CompColorConfirm.Enabled = false;
				cmbColorConfirmType.Enabled = false;

				TotalConfirms = 0;
				txt_Total_Confirm_Companies.Text = "0";

				strCCType = cmbColorConfirmType.Text.ToUpper();

				//pnl_lstcompany.Visible = False  ' Temp Hold
				pnl_lstcompany.Visible = true;

				cellcolor = modAdminCommon.HeadingColor;
				tempconfirmdate = DateTime.Parse(txt_Callback_Date.Text).AddDays(modAdminCommon.gbl_ConfirmDays * -1);

				Stopped = false;
				FindId = "CompColor";
				//Call Update_Status_Bar(SB, "Accessing Database, Please Wait", vbRed)
				grd_CompConfirm.Clear();
				grd_CompConfirm.Visible = false;
				lbl_CompConfirm.Visible = false;

				Application.DoEvents();
				grd_CompConfirm.Redraw = false;

				lbl_Comp_Confirm.Text = " ";
				grd_CompConfirm.ColumnsCount = 8;
				grd_CompConfirm.RowsCount = 2;
				grd_CompConfirm.CurrentRowIndex = 0;

				grd_CompConfirm.CurrentColumnIndex = 0;
				grd_CompConfirm.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
				
				grd_CompConfirm.ColAlignment[0] = DataGridViewContentAlignment.NotSet;
				grd_CompConfirm.SetColumnWidth(0, 67);
				grd_CompConfirm[grd_CompConfirm.CurrentRowIndex, grd_CompConfirm.CurrentColumnIndex].Value = "Date ";

				grd_CompConfirm.CurrentColumnIndex = 1;
				grd_CompConfirm.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
				grd_CompConfirm.SetColumnWidth(1, 233);
				grd_CompConfirm[grd_CompConfirm.CurrentRowIndex, grd_CompConfirm.CurrentColumnIndex].Value = "Name";

				grd_CompConfirm.CurrentColumnIndex = 2;
				grd_CompConfirm.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
				grd_CompConfirm.SetColumnWidth(2, 133);
				grd_CompConfirm[grd_CompConfirm.CurrentRowIndex, grd_CompConfirm.CurrentColumnIndex].Value = "City/State";

				grd_CompConfirm.CurrentColumnIndex = 3;
				grd_CompConfirm.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
				grd_CompConfirm.SetColumnWidth(3, 100);
				grd_CompConfirm[grd_CompConfirm.CurrentRowIndex, grd_CompConfirm.CurrentColumnIndex].Value = "Time Zone";

				grd_CompConfirm.CurrentColumnIndex = 4;
				grd_CompConfirm.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
				grd_CompConfirm.SetColumnWidth(4, 67);
				grd_CompConfirm[grd_CompConfirm.CurrentRowIndex, grd_CompConfirm.CurrentColumnIndex].Value = "Last Attempt";

				// This Next Two Fields Are Hidden Sort Fields

				grd_CompConfirm.CurrentColumnIndex = 5;
				grd_CompConfirm.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
				
				grd_CompConfirm.ColAlignment[5] = DataGridViewContentAlignment.NotSet;
				grd_CompConfirm.SetColumnWidth(5, 0);
				grd_CompConfirm[grd_CompConfirm.CurrentRowIndex, grd_CompConfirm.CurrentColumnIndex].Value = "Date Sort ";

				grd_CompConfirm.CurrentColumnIndex = 6;
				grd_CompConfirm.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
				grd_CompConfirm.SetColumnWidth(6, 0);
				grd_CompConfirm[grd_CompConfirm.CurrentRowIndex, grd_CompConfirm.CurrentColumnIndex].Value = "Last Attempt Sort";

				grd_CompConfirm.CurrentColumnIndex = 7;
				grd_CompConfirm.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
				grd_CompConfirm.SetColumnWidth(7, 80);
				grd_CompConfirm[grd_CompConfirm.CurrentRowIndex, grd_CompConfirm.CurrentColumnIndex].Value = "IQ Last Attempt";

				grd_CompConfirm.FixedRows = 1;
				grd_CompConfirm.FixedColumns = 0;

				Query = "SELECT DISTINCT ";
				Query = $"{Query}C1.comp_account_callback_date, ";
				Query = $"{Query}C1.comp_name, ";
				Query = $"{Query}C1.comp_id, ";
				Query = $"{Query}C1.comp_journ_id, ";
				Query = $"{Query}C1.comp_city, ";
				Query = $"{Query}C1.comp_state, ";
				Query = $"{Query}C1.comp_timezone, ";
				Query = $"{Query}C1.comp_last_contact_date ";


				// 08/27/2015 - By David D. Cruger; Added JNiQ Last Attempted Date
				Query = $"{Query}, (SELECT MAX(journ_date) FROM Journal WITH (NOLOCK) ";
				Query = $"{Query} WHERE (journ_comp_id = comp_id) ";
				Query = $"{Query} AND ( ";
				Query = $"{Query}       (journ_subcategory_code = 'IQ') ";
				Query = $"{Query}    OR (journ_subcategory_code = 'RN' AND journ_subject LIKE '%JNiQ%') ";
				Query = $"{Query}     ) ";
				//Query = Query & " ORDER BY journ_date DESC "
				Query = $"{Query}) As dtJNiQLastAttemptedDate ";

				// 07/18/2019 - By David D. Cruger; Removed INDEX HINT
				//Query = Query & "FROM Company AS C1 WITH (NOLOCK, INDEX(" & chr(34) & "ix_comp_callback_key" & chr(34) & ")) "
				Query = $"{Query}FROM Company AS C1 WITH (NOLOCK) ";
				Query = $"{Query}LEFT OUTER JOIN Phone_Numbers as P WITH (NOLOCK) ON C1.comp_id=p.pnum_comp_id AND C1.comp_journ_id = p.pnum_journ_id ";

				Query = $"{Query}WHERE (C1.comp_journ_id = 0) ";
				Query = $"{Query}AND (C1.comp_active_flag = 'Y') ";

				if (cbo_account_id.Text.ToUpper() != "NO REP SELECTED")
				{
					Query = $"{Query}AND  C1.comp_account_id  {make_account_rep_answer_string()}";
				}

				strCCTypeQuery = "";

				if (strCCType == "ALL" || strCCType == "COMPANY ADDRESS")
				{
					strCCTypeQuery = $"{strCCTypeQuery}OR (";
					strCCTypeQuery = $"{strCCTypeQuery}         (C1.comp_address1 IS NOT NULL AND C1.comp_address1 <> '') ";
					strCCTypeQuery = $"{strCCTypeQuery}     AND (C1.comp_address_confirm_date <= '{DateTimeHelper.ToString(tempconfirmdate)}' OR C1.comp_address_confirm_date IS NULL) ";
					strCCTypeQuery = $"{strCCTypeQuery}   ) ";
				}

				if (strCCType == "ALL" || strCCType == "COMPANY PHONE NBRS")
				{
					strCCTypeQuery = $"{strCCTypeQuery}OR EXISTS (SELECT NULL FROM Phone_Numbers AS PN1 WITH (NOLOCK) ";
					strCCTypeQuery = $"{strCCTypeQuery}           WHERE (PN1.pnum_comp_id = C1.comp_id) ";
					strCCTypeQuery = $"{strCCTypeQuery}           AND (PN1.pnum_journ_id = 0) ";
					strCCTypeQuery = $"{strCCTypeQuery}           AND (PN1.pnum_contact_id = 0) ";
					strCCTypeQuery = $"{strCCTypeQuery}           AND (PN1.pnum_confirm_date <= '{DateTimeHelper.ToString(tempconfirmdate)}' OR PN1.pnum_confirm_date IS NULL) ";
					strCCTypeQuery = $"{strCCTypeQuery}           AND (PN1.pnum_number_full_search IS NOT NULL AND PN1.pnum_number_full_search <> '') ";
					strCCTypeQuery = $"{strCCTypeQuery}          ) ";
				}

				if (strCCType == "ALL" || strCCType == "COMPANY EMAIL")
				{
					strCCTypeQuery = $"{strCCTypeQuery}OR (";
					strCCTypeQuery = $"{strCCTypeQuery}         (C1.comp_email_address IS NOT NULL AND C1.comp_email_address <> '') ";
					strCCTypeQuery = $"{strCCTypeQuery}     AND (C1.comp_email_confirm_date <= '{DateTimeHelper.ToString(tempconfirmdate)}' OR C1.comp_email_confirm_date IS NULL) ";
					strCCTypeQuery = $"{strCCTypeQuery}   ) ";
				}

				if (strCCType == "ALL" || strCCType == "COMPANY WEBSITE")
				{
					strCCTypeQuery = $"{strCCTypeQuery}OR (";
					strCCTypeQuery = $"{strCCTypeQuery}         (C1.comp_web_address IS NOT NULL AND C1.comp_web_address <> '') ";
					strCCTypeQuery = $"{strCCTypeQuery}     AND (C1.comp_web_confirm_date <= '{DateTimeHelper.ToString(tempconfirmdate)}' OR C1.comp_web_confirm_date IS NULL) ";
					strCCTypeQuery = $"{strCCTypeQuery}   ) ";
				}

				if (strCCType == "ALL" || strCCType == "CONTACT NAME")
				{
					strCCTypeQuery = $"{strCCTypeQuery}OR EXISTS (SELECT NULL FROM Contact AS CT1 WITH (NOLOCK) ";
					strCCTypeQuery = $"{strCCTypeQuery}           WHERE (CT1.contact_comp_id = C1.comp_id) ";
					strCCTypeQuery = $"{strCCTypeQuery}           AND (CT1.contact_journ_id = 0) ";
					strCCTypeQuery = $"{strCCTypeQuery}           AND (CT1.contact_active_flag = 'Y') ";
					strCCTypeQuery = $"{strCCTypeQuery}           AND (CT1.contact_name_confirm_date <= '{DateTimeHelper.ToString(tempconfirmdate)}' OR CT1.contact_name_confirm_date IS NULL) ";
					strCCTypeQuery = $"{strCCTypeQuery}           AND (CT1.contact_first_name IS NOT NULL AND CT1.contact_first_name <> '') ";
					strCCTypeQuery = $"{strCCTypeQuery}           AND (CT1.contact_last_name IS NOT NULL AND CT1.contact_last_name <> '') ";
					strCCTypeQuery = $"{strCCTypeQuery}          ) ";
				}

				if (strCCType == "ALL" || strCCType == "CONTACT TITLE")
				{
					strCCTypeQuery = $"{strCCTypeQuery}OR EXISTS (SELECT NULL FROM Contact AS CT1 WITH (NOLOCK) ";
					strCCTypeQuery = $"{strCCTypeQuery}           WHERE (CT1.contact_comp_id = C1.comp_id) ";
					strCCTypeQuery = $"{strCCTypeQuery}           AND (CT1.contact_journ_id = 0) ";
					strCCTypeQuery = $"{strCCTypeQuery}           AND (CT1.contact_active_flag = 'Y') ";
					strCCTypeQuery = $"{strCCTypeQuery}           AND (CT1.contact_title_confirm_date <= '{DateTimeHelper.ToString(tempconfirmdate)}' OR CT1.contact_title_confirm_date IS NULL) ";
					strCCTypeQuery = $"{strCCTypeQuery}           AND (CT1.contact_title IS NOT NULL AND CT1.contact_title <> '') ";
					strCCTypeQuery = $"{strCCTypeQuery}          ) ";
				}

				if (strCCType == "ALL" || strCCType == "CONTACT PHONE NBRS")
				{
					strCCTypeQuery = $"{strCCTypeQuery}OR EXISTS (SELECT NULL FROM Phone_Numbers AS PN1 WITH (NOLOCK) ";
					strCCTypeQuery = $"{strCCTypeQuery}           INNER JOIN Contact AS CT1 WITH (NOLOCK) ON CT1.contact_id = PN1.pnum_contact_id AND CT1.contact_journ_id = PN1.pnum_journ_id ";
					strCCTypeQuery = $"{strCCTypeQuery}           WHERE (PN1.pnum_comp_id = C1.comp_id) ";
					strCCTypeQuery = $"{strCCTypeQuery}           AND (PN1.pnum_journ_id = 0) ";
					strCCTypeQuery = $"{strCCTypeQuery}           AND (PN1.pnum_contact_id > 0) ";
					strCCTypeQuery = $"{strCCTypeQuery}           AND (PN1.pnum_confirm_date <= '{DateTimeHelper.ToString(tempconfirmdate)}' OR PN1.pnum_confirm_date IS NULL) ";
					strCCTypeQuery = $"{strCCTypeQuery}           AND (PN1.pnum_number_full_search IS NOT NULL AND PN1.pnum_number_full_search <> '') ";
					strCCTypeQuery = $"{strCCTypeQuery}           AND (CT1.contact_active_flag = 'Y') ";
					strCCTypeQuery = $"{strCCTypeQuery}          ) ";
				}

				if (strCCType == "ALL" || strCCType == "AIRCRAFT REG NBR")
				{
					strCCTypeQuery = $"{strCCTypeQuery}OR EXISTS (SELECT NULL FROM Aircraft AS A1 WITH (NOLOCK) ";
					strCCTypeQuery = $"{strCCTypeQuery}           INNER JOIN Aircraft_Reference AS AR1 WITH (NOLOCK) ON AR1.cref_ac_id = A1.ac_id AND AR1.cref_journ_id = A1.ac_journ_id ";
					strCCTypeQuery = $"{strCCTypeQuery}           WHERE (AR1.cref_comp_id = C1.comp_id) ";
					strCCTypeQuery = $"{strCCTypeQuery}           AND (AR1.cref_journ_id = 0) ";
					strCCTypeQuery = $"{strCCTypeQuery}           AND (AR1.cref_primary_poc_flag IN ('X','Y')) ";
					strCCTypeQuery = $"{strCCTypeQuery}           AND (A1.ac_reg_no_verify_date <= '{DateTimeHelper.ToString(tempconfirmdate)}' OR A1.ac_reg_no_verify_date IS NULL) ";
					strCCTypeQuery = $"{strCCTypeQuery}           AND (A1.ac_reg_no IS NOT NULL AND A1.ac_reg_no <> '') ";
					strCCTypeQuery = $"{strCCTypeQuery}          ) ";
				}

				if (strCCType == "ALL" || strCCType == "AIRCRAFT BASE")
				{
					strCCTypeQuery = $"{strCCTypeQuery}OR EXISTS (SELECT NULL FROM Aircraft AS A1 WITH (NOLOCK) ";
					strCCTypeQuery = $"{strCCTypeQuery}           INNER JOIN Aircraft_Reference AS AR1 WITH (NOLOCK) ON AR1.cref_ac_id = A1.ac_id AND AR1.cref_journ_id = A1.ac_journ_id ";
					strCCTypeQuery = $"{strCCTypeQuery}           WHERE (AR1.cref_comp_id = C1.comp_id) ";
					strCCTypeQuery = $"{strCCTypeQuery}           AND (AR1.cref_journ_id = 0) ";
					strCCTypeQuery = $"{strCCTypeQuery}           AND (AR1.cref_primary_poc_flag IN ('X','Y')) ";
					strCCTypeQuery = $"{strCCTypeQuery}           AND (A1.ac_airport_code_verify_date <= '{DateTimeHelper.ToString(tempconfirmdate)}' OR A1.ac_airport_code_verify_date IS NULL) ";
					strCCTypeQuery = $"{strCCTypeQuery}           AND (A1.ac_aport_name IS NOT NULL AND A1.ac_aport_name <> '') ";
					strCCTypeQuery = $"{strCCTypeQuery}           AND (A1.ac_aport_id IS NOT NULL AND A1.ac_aport_id > 0) ";
					strCCTypeQuery = $"{strCCTypeQuery}          ) ";
				}

				if (strCCTypeQuery != "")
				{ // Remove First OR
					strCCTypeQuery = strCCTypeQuery.Substring(Math.Min(3, strCCTypeQuery.Length));
					Query = $"{Query}AND ( ";
					Query = $"{Query}{strCCTypeQuery}";
					Query = $"{Query} ) ";
				}

				// 11/16/2015 - By David D. Cruger
				// Added Do NOT Include Companies with Only Written Off Aircraft
				// They must have no references or at least 1 that is NOT lifecycle=4

				if (chkDoNotIncludeWrittenOffAC.CheckState == CheckState.Checked)
				{
					Query = $"{Query}AND ( ";

					// This query KILLS the performance. To the point it's no good.
					//                        Does NOT Have Any Aircraft References
					//query = query & "        NOT EXISTS (SELECT NULL FROM Aircraft_Reference AS AR2 WITH (NOLOCK) "
					//query = query & "                    WHERE (AR2.cref_comp_id = C1.comp_id) "
					//query = query & "                    AND (AR2.cref_journ_id = C1.comp_journ_id) "
					//query = query & "                   ) "

					//                        Has An Aircraft Reference That Is NOT Written Off
					Query = $"{Query}        EXISTS (SELECT NULL FROM Aircraft_Reference AS AR3 WITH (NOLOCK) ";
					Query = $"{Query}                INNER JOIN Aircraft AS A3 WITH (NOLOCK) ON A3.ac_id = AR3.cref_ac_id AND A3.ac_journ_id = AR3.cref_journ_id ";
					Query = $"{Query}                WHERE (AR3.cref_comp_id = C1.comp_id) ";
					Query = $"{Query}                AND (AR3.cref_journ_id = C1.comp_journ_id) ";
					Query = $"{Query}                AND (A3.ac_lifecycle_stage < 4) ";
					Query = $"{Query}               ) ";
					Query = $"{Query}    ) ";
				} // If chkDoNotIncludeWrittenOffAC.Value = vbChecked Then

				strAcctRep = cbo_account_id.Text.Substring(0, Math.Min(2, cbo_account_id.Text.Length)).ToUpper();
				strAcctRepId = cbo_account_id.Text.ToUpper();

				if (ChkRelatedtoAircraft.CheckState == CheckState.Checked)
				{


					switch(cmbProductType.Text.Substring(0, Math.Min(1, cmbProductType.Text.Length)))
					{
						case "L" :  // All 
							 
							Query = $"{Query}AND (EXISTS (SELECT NULL FROM Aircraft_Reference AS AR2 WITH (NOLOCK) "; 
							Query = $"{Query}             WHERE (AR2.cref_comp_id = C1.comp_id) "; 
							Query = $"{Query}             AND (AR2.cref_journ_id = 0) "; 
							Query = $"{Query}            ) "; 
							Query = $"{Query}    ) "; 
							 
							break;
						case "A" :  // Business And Helicopter 
							 
							Query = $"{Query}AND (EXISTS (SELECT NULL FROM Aircraft_Reference AS AR2 WITH (NOLOCK) "; 
							Query = $"{Query}             INNER JOIN Aircraft AS A2 ON A2.ac_id = AR2.cref_ac_id AND A2.ac_journ_id = AR2.cref_journ_id "; 
							Query = $"{Query}             INNER JOIN Aircraft_Model AS AM2 ON AM2.amod_id = A2.ac_amod_id "; 
							Query = $"{Query}             WHERE (AR2.cref_comp_id = C1.comp_id) "; 
							Query = $"{Query}             AND (AR2.cref_journ_id = 0) "; 
							Query = $"{Query}             AND (AM2.amod_customer_flag = 'Y') "; 
							Query = $"{Query}             AND (AM2.amod_airframe_type_code = 'F') "; 
							Query = $"{Query}             AND (AM2.amod_product_business_flag = 'Y' OR AM2.amod_product_commercial_flag = 'Y') "; 
							Query = $"{Query}             AND (A2.ac_product_business_flag = 'Y' OR A2.ac_product_commercial_flag = 'Y') "; 
							Query = $"{Query}            ) "; 
							Query = $"{Query}    ) "; 
							 
							break;
						case "B" :  // Business 
							 
							Query = $"{Query}AND (EXISTS (SELECT NULL FROM Aircraft_Reference AS AR2 WITH (NOLOCK) "; 
							Query = $"{Query}             INNER JOIN Aircraft AS A2 ON A2.ac_id = AR2.cref_ac_id AND A2.ac_journ_id = AR2.cref_journ_id "; 
							Query = $"{Query}             INNER JOIN Aircraft_Model AS AM2 ON AM2.amod_id = A2.ac_amod_id "; 
							Query = $"{Query}             WHERE (AR2.cref_comp_id = C1.comp_id) "; 
							Query = $"{Query}             AND (AR2.cref_journ_id = 0) "; 
							Query = $"{Query}             AND (AM2.amod_customer_flag = 'Y') "; 
							Query = $"{Query}             AND (AM2.amod_airframe_type_code = 'F') "; 
							Query = $"{Query}             AND (AM2.amod_product_business_flag = 'Y') "; 
							Query = $"{Query}             AND (A2.ac_product_business_flag = 'Y') "; 
							Query = $"{Query}            ) "; 
							Query = $"{Query}    ) "; 
							 
							break;
						case "H" :  // Helicopters 
							 
							Query = $"{Query}AND (EXISTS (SELECT NULL FROM Aircraft_Reference AS AR2 WITH (NOLOCK) "; 
							Query = $"{Query}             INNER JOIN Aircraft AS A2 ON A2.ac_id = AR2.cref_ac_id AND A2.ac_journ_id = AR2.cref_journ_id "; 
							Query = $"{Query}             INNER JOIN Aircraft_Model AS AM2 ON AM2.amod_id = A2.ac_amod_id "; 
							Query = $"{Query}             WHERE (AR2.cref_comp_id = C1.comp_id) "; 
							Query = $"{Query}             AND (AR2.cref_journ_id = 0) "; 
							Query = $"{Query}             AND (AM2.amod_customer_flag = 'Y') "; 
							Query = $"{Query}             AND (AM2.amod_airframe_type_code = 'R') "; 
							Query = $"{Query}             AND (AM2.amod_product_helicopter_flag = 'Y') "; 
							Query = $"{Query}             AND (A2.ac_product_helicopter_flag = 'Y') "; 
							Query = $"{Query}            ) "; 
							Query = $"{Query}    ) "; 
							 
							break;
						case "C" :  // Commercial 
							 
							Query = $"{Query}AND (EXISTS (SELECT NULL FROM Aircraft_Reference AS AR2 WITH (NOLOCK) "; 
							Query = $"{Query}             INNER JOIN Aircraft AS A2 ON A2.ac_id = AR2.cref_ac_id AND A2.ac_journ_id = AR2.cref_journ_id "; 
							Query = $"{Query}             INNER JOIN Aircraft_Model AS AM2 ON AM2.amod_id = A2.ac_amod_id "; 
							Query = $"{Query}             WHERE (AR2.cref_comp_id = C1.comp_id) "; 
							Query = $"{Query}             AND (AR2.cref_journ_id = 0) "; 
							Query = $"{Query}             AND (AM2.amod_customer_flag = 'Y') "; 
							Query = $"{Query}             AND (AM2.amod_airframe_type_code = 'F') "; 
							Query = $"{Query}             AND (AM2.amod_product_commercial_flag = 'Y') "; 
							Query = $"{Query}             AND (A2.ac_product_commercial_flag = 'Y') "; 
							Query = $"{Query}            ) "; 
							Query = $"{Query}    ) "; 
							 
							break;
						case "Q" :  // JNiQ Eligible 
							 
							Query = $"{Query}{modCommon.Return_JNiQ_Eligible_Query(strAcctRep, Query)}"; 
							 
							break;
						case "N" :  // Non-JNiQ Eligible 
							 
							Query = $"{Query}{modCommon.Return_Non_JNiQ_Eligible_Query()}"; 
							 
							break;
						case "P" :  // AirBP 
							 
							Query = $"{Query}AND (EXISTS (SELECT NULL FROM Aircraft_Reference AS AR2 WITH (NOLOCK) "; 
							Query = $"{Query}             INNER JOIN Aircraft AS A2 ON A2.ac_id = AR2.cref_ac_id AND A2.ac_journ_id = AR2.cref_journ_id "; 
							Query = $"{Query}             INNER JOIN Aircraft_Model AS AM2 ON AM2.amod_id = A2.ac_amod_id "; 
							Query = $"{Query}             WHERE (AR2.cref_comp_id = C1.comp_id) "; 
							Query = $"{Query}             AND (AR2.cref_journ_id = 0) "; 
							Query = $"{Query}             AND (AM2.amod_customer_flag = 'Y') "; 
							Query = $"{Query}             AND (AM2.amod_airframe_type_code = 'F') "; 
							Query = $"{Query}             AND (A2.ac_product_airbp_flag = 'Y') "; 
							Query = $"{Query}            ) "; 
							Query = $"{Query}    ) "; 
							 
							break;
					} // Case left(cmbProductType.Text, 1)

				} // If ChkRelatedtoAircraft.Value = vbChecked Then

				if (chkNotPrimary.CheckState == CheckState.Checked)
				{
					Query = $"{Query}AND NOT EXISTS (SELECT top 1 AR2.cref_ac_id ";
					Query = $"{Query}                FROM Aircraft_Reference AS AR2 WITH(NOLOCK) ";
					Query = $"{Query}                INNER JOIN Company AS C2 ON AR2.cref_comp_id = C2.comp_id AND AR2.cref_journ_id = C2.comp_journ_id ";
					Query = $"{Query}                WHERE (AR2.cref_comp_id = C1.comp_id) ";
					Query = $"{Query}                AND (AR2.cref_primary_poc_flag = 'Y') ";
					Query = $"{Query}                AND (AR2.cref_journ_id = 0) ";
					Query = $"{Query}                AND (C2.comp_account_id {make_account_rep_answer_string()}) ";
					Query = $"{Query}                ORDER BY cref_ac_id desc ";
					Query = $"{Query}                ) ";
				}


				if (order_by == "dtJNiQLastAttemptedDate")
				{
					Query = $"{Query}ORDER BY dtJNiQLastAttemptedDate asc  ";
				}
				else
				{
					Query = $"{Query}ORDER BY C1.comp_account_callback_date desc ";
				}





				grd_CompConfirm.Tag = "Date";

				//RememberTimeout = LOCAL_ADO_DB.ConnectionTimeout

				// LOCAL_ADO_DB.ConnectionTimeout = 40  '400

				modAdminCommon.Record_Event("Monitor Activity", $"Color Confirm - Selected AcctRep: {strAcctRepId}");
				// Record_Event "HB Usage", "Color Confirm - Selected AcctRep: " & strAcctRepId

				// Set snp_CompConfirm = LOCAL_DB.OpenRecordset(Query, dbOpenSnapshot, dbSQLPassThrough)
				snp_CompConfirm = new ADORecordSetHelper();

				snp_CompConfirm.CursorLocation = CursorLocationEnum.adUseClient;
				snp_CompConfirm.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				//LOCAL_ADO_DB.ConnectionTimeout = RememberTimeout

				if (!snp_CompConfirm.BOF && !snp_CompConfirm.EOF)
				{

					cmdStop.Visible = true;
					lRow1 = 0;

					do 
					{ // Loop Until snp_CompConfirm.EOF = True Or Stopped = True

						//fill grid
						grd_CompConfirm.Visible = true;

						lRow1++;
						grd_CompConfirm.RowsCount = lRow1 + 1;
						grd_CompConfirm.CurrentRowIndex = lRow1;
						cellcolor = modAdminCommon.NoColor;

						grd_CompConfirm.set_RowData(lRow1, Convert.ToInt32(snp_CompConfirm.GetField("comp_id")));

						grd_CompConfirm.CurrentColumnIndex = 0;
						grd_CompConfirm.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						grd_CompConfirm[grd_CompConfirm.CurrentRowIndex, grd_CompConfirm.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_CompConfirm["comp_account_callback_date"])}").Trim();

						grd_CompConfirm.CurrentColumnIndex = 5; // Date Sort - Hidden
						grd_CompConfirm.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						grd_CompConfirm[grd_CompConfirm.CurrentRowIndex, grd_CompConfirm.CurrentColumnIndex].Value = Convert.ToDateTime(snp_CompConfirm["comp_account_callback_date"]).ToString("yyyyMMdd");

						grd_CompConfirm.CurrentColumnIndex = 1;
						grd_CompConfirm.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						grd_CompConfirm[grd_CompConfirm.CurrentRowIndex, grd_CompConfirm.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_CompConfirm["comp_name"])}").Trim();

						grd_CompConfirm.CurrentColumnIndex = 2;
						grd_CompConfirm.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						grd_CompConfirm[grd_CompConfirm.CurrentRowIndex, grd_CompConfirm.CurrentColumnIndex].Value = $"{($"{Convert.ToString(snp_CompConfirm["Comp_city"])}").Trim()}, {($"{Convert.ToString(snp_CompConfirm["comp_state"])}").Trim()}";

						grd_CompConfirm.CurrentColumnIndex = 3;
						grd_CompConfirm.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						grd_CompConfirm[grd_CompConfirm.CurrentRowIndex, grd_CompConfirm.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_CompConfirm["comp_timezone"])}").Trim();

						grd_CompConfirm.CurrentColumnIndex = 4;
						grd_CompConfirm.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snp_CompConfirm["comp_last_contact_date"]))
						{
							grd_CompConfirm[grd_CompConfirm.CurrentRowIndex, grd_CompConfirm.CurrentColumnIndex].Value = Convert.ToDateTime(snp_CompConfirm["comp_last_contact_date"]).ToString("MM/dd/yyyy");
						}

						grd_CompConfirm.CurrentColumnIndex = 6; // Last Attempt Sort - Hidden
						grd_CompConfirm.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snp_CompConfirm["comp_last_contact_date"]))
						{
							grd_CompConfirm[grd_CompConfirm.CurrentRowIndex, grd_CompConfirm.CurrentColumnIndex].Value = Convert.ToDateTime(snp_CompConfirm["comp_last_contact_date"]).ToString("yyyyMMdd");
						}


						grd_CompConfirm.CurrentColumnIndex = 7; // IQ Last Attempt Sort - Hidden
						grd_CompConfirm.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snp_CompConfirm["dtJNiQLastAttemptedDate"]))
						{
							grd_CompConfirm[grd_CompConfirm.CurrentRowIndex, grd_CompConfirm.CurrentColumnIndex].Value = Convert.ToDateTime(snp_CompConfirm["dtJNiQLastAttemptedDate"]).ToString("MM/dd/yyyy");
						}


						snp_CompConfirm.MoveNext();
						if (grd_CompConfirm.CurrentRowIndex == grd_CompConfirm.RowsCount - 1)
						{
							grd_CompConfirm.RowsCount++;
						}

						TotalConfirms++;
						if (TotalConfirms == 24)
						{
							grd_CompConfirm.Visible = true;
							grd_CompConfirm.Redraw = true;
							Application.DoEvents();
							grd_CompConfirm.Redraw = false;
						}

						txt_Total_Confirm_Companies.Text = StringsHelper.Format(TotalConfirms, "#,###");
						Application.DoEvents();

					}
					while(!(snp_CompConfirm.EOF || Stopped));

					grd_CompConfirm.RowsCount--;

					cmdStop.Visible = false;
					Stopped = false;

				}
				else
				{
					grd_CompConfirm.CurrentRowIndex = 1;
					grd_CompConfirm.CurrentColumnIndex = 1;
					grd_CompConfirm[grd_CompConfirm.CurrentRowIndex, grd_CompConfirm.CurrentColumnIndex].Value = "No Companies to Confirm!";
					lbl_CompConfirm.Visible = true;
					lbl_Comp_Confirm.Text = "No Companies to Confirm!";
					cmd_Refresh_CompColorConfirm.Visible = false;
				} // If (snp_CompConfirm.BOF = False And snp_CompConfirm.EOF = False) Then

				strMsg = $"AcctRep: {cbo_account_id.Text}";
				strMsg = $"{strMsg} CCType: {strCCType}";
				strMsg = $"{strMsg} Product Type: {cmbProductType.Text}";

				if (chkNotPrimary.CheckState == CheckState.Checked)
				{
					strMsg = $"{strMsg} [x] Not Primary ";
				}

				if (ChkRelatedtoAircraft.CheckState == CheckState.Checked)
				{
					strMsg = $"{strMsg} [x] Related To A/C ";
				}

				if (chkDoNotIncludeWrittenOffAC.CheckState == CheckState.Checked)
				{
					strMsg = $"{strMsg} [x] No Written Off A/C ";
				}

				if (bLog)
				{

					modCommon.End_Activity_Monitor_Message("Callback Color Confirm", ref strMsg, dtStartDate, ref dtEndDate, 0, 0, 0, 0, 0);

					frm_UserHistory.DefInstance.Refresh_User_History_Grids("Callback");

				}

				grd_CompConfirm.Visible = true;
				grd_CompConfirm.Redraw = true;

				cmbColorConfirmType.Enabled = true;
				cmd_Refresh_CompColorConfirm.Enabled = true;

				search_off();
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error("Fill_Comp_Confirm_Grid_Error: ", excep.Message);
				search_off();
			}

		} // Fill_Comp_Confirm_Grid

		private void Fill_Primary_Callback_Grid_Headers()
		{

			int lRowl = 0;

			grd_Callbacks.Clear();
			grd_Callbacks.RowsCount = 2;
			grd_Callbacks.ColumnsCount = 17;
			grd_Callbacks.CurrentRowIndex = 0;
			grd_Callbacks.SetRowHeight(0, 32);

			int lCol1 = -1;

			lCol1++; // 0
			grd_Callbacks.CurrentColumnIndex = lCol1;
			grd_Callbacks[grd_Callbacks.CurrentRowIndex, grd_Callbacks.CurrentColumnIndex].Value = "CompId";
			grd_Callbacks.SetColumnWidth(lCol1, 0);
			grd_Callbacks.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

			lCol1++; // 1
			grd_Callbacks.CurrentColumnIndex = lCol1;
			grd_Callbacks[grd_Callbacks.CurrentRowIndex, grd_Callbacks.CurrentColumnIndex].Value = "Date";
			grd_Callbacks.SetColumnWidth(lCol1, 67);
			grd_Callbacks.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

			lCol1++; // 2
			grd_Callbacks.CurrentColumnIndex = lCol1;
			grd_Callbacks[grd_Callbacks.CurrentRowIndex, grd_Callbacks.CurrentColumnIndex].Value = "Company";
			grd_Callbacks.SetColumnWidth(lCol1, 253);
			grd_Callbacks.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

			lCol1++; // 3
			grd_Callbacks.CurrentColumnIndex = lCol1;
			grd_Callbacks[grd_Callbacks.CurrentRowIndex, grd_Callbacks.CurrentColumnIndex].Value = "Location";
			grd_Callbacks.SetColumnWidth(lCol1, 213);
			grd_Callbacks.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

			// show only IQ completed
			if (chk_action_list[chkShowIQCompleted].CheckState == CheckState.Checked || chk_action_list[chkHideIQDeclined].CheckState == CheckState.Checked)
			{
			}
			else
			{
				lCol1++; // 4
				grd_Callbacks.CurrentColumnIndex = lCol1;
				grd_Callbacks[grd_Callbacks.CurrentRowIndex, grd_Callbacks.CurrentColumnIndex].Value = "State";
				grd_Callbacks.SetColumnWidth(lCol1, 40);
				grd_Callbacks.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			}

			lCol1++; // 5
			grd_Callbacks.CurrentColumnIndex = lCol1;
			grd_Callbacks[grd_Callbacks.CurrentRowIndex, grd_Callbacks.CurrentColumnIndex].Value = "Time Zone";
			grd_Callbacks.SetColumnWidth(lCol1, 47);
			grd_Callbacks.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

			// show only IQ completed
			if (chk_action_list[chkShowIQCompleted].CheckState == CheckState.Checked || chk_action_list[chkHideIQDeclined].CheckState == CheckState.Checked)
			{
			}
			else
			{
				lCol1++; // 6
				grd_Callbacks.CurrentColumnIndex = lCol1;
				grd_Callbacks[grd_Callbacks.CurrentRowIndex, grd_Callbacks.CurrentColumnIndex].Value = $"#{Environment.NewLine}Aircraft";
				grd_Callbacks.SetColumnWidth(lCol1, 47);
				grd_Callbacks.CellAlignment = DataGridViewContentAlignment.MiddleCenter;


				lCol1++; // 7
				grd_Callbacks.CurrentColumnIndex = lCol1;
				grd_Callbacks[grd_Callbacks.CurrentRowIndex, grd_Callbacks.CurrentColumnIndex].Value = $"Last{Environment.NewLine}Attempt";
				grd_Callbacks.SetColumnWidth(lCol1, 67);
				grd_Callbacks.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			}
			lCol1++; // 8
			grd_Callbacks.CurrentColumnIndex = lCol1;
			grd_Callbacks[grd_Callbacks.CurrentRowIndex, grd_Callbacks.CurrentColumnIndex].Value = $"JNiQ Last{Environment.NewLine}Attempt";
			grd_Callbacks.SetColumnWidth(lCol1, 67);
			grd_Callbacks.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

			lCol1++; // 9
			grd_Callbacks.CurrentColumnIndex = lCol1;
			grd_Callbacks[grd_Callbacks.CurrentRowIndex, grd_Callbacks.CurrentColumnIndex].Value = $"JNiQ Last{Environment.NewLine}Completed";
			grd_Callbacks.SetColumnWidth(lCol1, 67);
			grd_Callbacks.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			if (chk_action_list[chkShowIQCompleted].CheckState == CheckState.Checked || chk_action_list[chkHideIQDeclined].CheckState == CheckState.Checked)
			{
			}
			else
			{
				lCol1++; // 10
				grd_Callbacks.CurrentColumnIndex = lCol1;
				grd_Callbacks[grd_Callbacks.CurrentRowIndex, grd_Callbacks.CurrentColumnIndex].Value = "Service";
				grd_Callbacks.SetColumnWidth(lCol1, 113);
				grd_Callbacks.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

				lCol1++; // 11
				grd_Callbacks.CurrentColumnIndex = lCol1;
				grd_Callbacks[grd_Callbacks.CurrentRowIndex, grd_Callbacks.CurrentColumnIndex].Value = "Sub-Service";
				grd_Callbacks.SetColumnWidth(lCol1, 80);
				grd_Callbacks.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
			}
			//---------------------------------------------------------------------
			// This Next 4 Cells Are Hidden And Are Used For Sorting Date Fields
			//---------------------------------------------------------------------

			lCol1++; // 12
			grd_Callbacks.CurrentColumnIndex = lCol1;
			grd_Callbacks[grd_Callbacks.CurrentRowIndex, grd_Callbacks.CurrentColumnIndex].Value = "Date Sort";
			grd_Callbacks.SetColumnWidth(lCol1, 0);
			grd_Callbacks.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

			lCol1++; // 13
			grd_Callbacks.CurrentColumnIndex = lCol1;
			grd_Callbacks[grd_Callbacks.CurrentRowIndex, grd_Callbacks.CurrentColumnIndex].Value = "Last Attempt Date Sort";
			grd_Callbacks.SetColumnWidth(lCol1, 0);
			grd_Callbacks.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

			lCol1++; // 14
			grd_Callbacks.CurrentColumnIndex = lCol1;
			grd_Callbacks[grd_Callbacks.CurrentRowIndex, grd_Callbacks.CurrentColumnIndex].Value = "JNiQ Last Attempt Date Sort";
			grd_Callbacks.SetColumnWidth(lCol1, 0);
			grd_Callbacks.CellAlignment = DataGridViewContentAlignment.MiddleCenter;


			lCol1++; // 15
			grd_Callbacks.CurrentColumnIndex = lCol1;
			grd_Callbacks[grd_Callbacks.CurrentRowIndex, grd_Callbacks.CurrentColumnIndex].Value = "JNiQ Last Completed Date Sort";
			grd_Callbacks.SetColumnWidth(lCol1, 0);
			grd_Callbacks.CellAlignment = DataGridViewContentAlignment.MiddleCenter;


			lCol1++; // 16
			grd_Callbacks.CurrentColumnIndex = lCol1;
			grd_Callbacks[grd_Callbacks.CurrentRowIndex, grd_Callbacks.CurrentColumnIndex].Value = "JNiQ Last Journal";
			grd_Callbacks.SetColumnWidth(lCol1, 200);
			grd_Callbacks.CellAlignment = DataGridViewContentAlignment.MiddleCenter;

			grd_Callbacks.FixedRows = 1;
			grd_Callbacks.FixedColumns = 0;

			grd_Callbacks.CurrentRowIndex = 1;

		} // Fill_Primary_Callback_Grid_Headers

		private void Fill_Callback_Grid()
		{
			//'******************************************************************************************
			//Function used to fill the Callbacks Grid
			// RTW - MODIFIED TO REMOVE THE CLASS C HELICOPTER QUERIES ON 9/14/2010
			//----------------------------------------------------------------------------------------------

			string errString = "";
			try
			{

				// 02/02/2012 - By David D. Cruger
				// For Monitoring

				string strMsg = "";
				System.DateTime dtStartDate = DateTime.FromOADate(0);
				System.DateTime dtEndDate = DateTime.FromOADate(0);
				bool use_alt_rep = false;
				use_alt_rep = false;
				string Query = "";
				int ErrCount = 0;
				string tmpDate = "";
				int tcol = 0;
				tcol = 0;

				int TempCount = 0;
				int TotalAircraft = 0;
				int TotalCallbacks = 0;
				string cellcolor = "";
				int PreviousCompID = 0;
				int RememberTimeout = 0;
				ADORecordSetHelper snp_SumAC = new ADORecordSetHelper();
				string HelicopterFlag = "";
				string strPType = "";
				string strAcctRep = "";
				string strAcctRepId = "";
				System.DateTime dtJNiQLastAttemptDate = DateTime.FromOADate(0);
				int lCnt1 = 0;

				modCommon.Start_Activity_Monitor_Message("Callback Aircraft", ref strMsg, ref dtStartDate, ref dtEndDate);

				errString = "Initializing";
				ErrCount = 0;
				HasBoundCallback = false; //aey 11/17/04
				cmdSelDClick.Visible = false;
				cmdRefresh.Enabled = false;
				HelicopterFlag = "N";

				SSTabHelper.SetSelectedIndex(tab_callback, 0);
				txt_TotalAircraft.Text = "";
				txt_TotalCallbacks.Text = "";

				pnl_lstcompany.Visible = false;
				pnl_Callbacks.Visible = true;
				grd_Callbacks.Visible = true;

				grd_Callbacks.DataSource = null;

				FindId = "CallBacks";
				grd_Callbacks.Clear();
				lbl_Message.Text = "";
				Stopped = false;

				TotalCallbacks = 0;
				TotalAircraft = 0;
				//working call backs
				PreviousCompID = 0;

				errString = "Grid Header";

				Fill_Primary_Callback_Grid_Headers();

				if (Convert.ToString(grd_Callbacks.Tag) == "")
				{
					grd_Callbacks.Tag = "ORDER BY comp_account_callback_date, comp_name, comp_city, comp_state, comp_country";
				}

				// if account rep begins with a "DB"
				// then we don't want to join the aircraft reference table
				Query = "";

				strPType = cmbProductType.Text.Substring(0, Math.Min(1, cmbProductType.Text.Length)).ToUpper();
				strAcctRep = cbo_account_id.Text.Substring(0, Math.Min(2, cbo_account_id.Text.Length)).ToUpper();
				if (((int) chk_alt_rep.CheckState).ToString().Trim() == "1")
				{
					use_alt_rep = true;
				}
				strAcctRepId = cbo_account_id.Text.ToUpper();

				modAdminCommon.Record_Event("Monitor Activity", $"Callback - Selected AcctRep: {strAcctRepId}");
				//Record_Event "HB Usage", "Callback - Selected AcctRep: " & strAcctRepId

				// 10/03/2019 - By David D. Cruger; Added ACAX, DEX1 and DEX2 Per Lisa
				if (strAcctRep == "DB" || strAcctRepId == "ACAX" || strAcctRepId == "DEX1" || strAcctRepId == "DEX2" || strAcctRepId == "DEX3")
				{

					errString = "Get Callback Data db";
					if (chk_action_list[chkViewMasterList].CheckState == CheckState.Unchecked)
					{
						tmpDate = DateTime.Parse(txt_Callback_Date.Text).ToString("d");
					}
					else
					{
						// 06/27/2007 - By David D. Cruger
						// Push Date As Far In Advance As Possible
						// Or Don't Use Date At All
						tmpDate = DateTime.Parse("12/31/2100").ToString("d");
					}

					if (SortField1.Trim() == "")
					{
						SortField1 = "comp_account_callback_date";
					}


					//HasBoundCallback = True
					errString = "Get Callback bound dlr sort";
					//Query = "EXEC HomebaseGetDealerCallbacks '" & Trim(cbo_account_id.Text & " ") & "','" & tmpDate & "','" & SortField1 & "','" & left(cmbProductType.Text, 1) & "'"
					// MODIFIED ON 9/16/2010 BY RTW TO USE CODE QUERY RATHER THAN STORED PROCEDURE

					// MODIFIED ON 2/2/2012 - RTW - TO GET JUST TOP 250
					if (chk_action_list[chkAllCompanies].CheckState == CheckState.Checked)
					{
						Query = "SELECT ";
					}
					else
					{
						Query = "SELECT TOP 250 ";
					}

					Query = $"{Query}comp_id, comp_journ_id, ";
					Query = $"{Query}comp_account_callback_date, ";
					Query = $"{Query}comp_name, ";
					Query = $"{Query}(comp_city + ' [' + comp_country + ']') as location, ";
					Query = $"{Query}comp_state, ";
					Query = $"{Query}comp_city, ";
					Query = $"{Query}comp_country, ";
					Query = $"{Query}comp_timezone, ";

					// ADDED MSW - 8/13/18 - TO GET LAST JOURNAL NOTE
					Query = $"{Query} (select top 1 journ_subject  from Journal with (NOLOCK) where journ_comp_id = comp_id and journ_subcategory_code = 'IQ' order by journ_id desc) as iq_note_type, ";


					// 07/25/2016 - By David D. Cruger; Added
					Query = $"{Query}(SELECT TOP 1 svud_Desc FROM Services_Used WITH (NOLOCK) WHERE (svud_code = comp_service)) As CompService, ";

					// 07/25/2016 - By David D. Cruger; Added
					Query = $"{Query}STUFF((SELECT DISTINCT ';'+sub_serv_code FROM Subscription WITH (NOLOCK) ";
					Query = $"{Query}WHERE (sub_comp_id = comp_id) ";
					Query = $"{Query}AND (sub_start_date <= GETDATE()) ";
					Query = $"{Query}AND (sub_end_date IS NULL OR sub_end_date > GETDATE()) ";
					Query = $"{Query}AND (sub_marketing_flag = 'N') ";
					Query = $"{Query}FOR XML PATH('')),1,1,'') As ActiveSubService, ";

					Query = $"{Query}(SELECT COUNT(DISTINCT AR2.cref_ac_id) ";
					Query = $"{Query}FROM Aircraft_Reference AS AR2 WITH (NOLOCK) ";
					Query = $"{Query}INNER JOIN Aircraft AS A2 WITH (NOLOCK) ON A2.ac_id = AR2.cref_ac_id AND A2.ac_journ_id = AR2.cref_journ_id ";
					Query = $"{Query}INNER JOIN Aircraft_Model AS AM2 WITH (NOLOCK) ON AM2.amod_id = A2.ac_amod_id ";
					Query = $"{Query}WHERE (AR2.cref_comp_id = C1.comp_id) ";
					Query = $"{Query}AND (AR2.cref_journ_id = 0) ";
					Query = $"{Query}AND (A2.ac_lifecycle_stage < 4) ";

					// 06/04/2015 - By David D. Cruger;
					// Per Lucia Do NOT Include Class E
					Query = $"{Query}AND (AM2.amod_class_code <> 'E') ";

					switch(strPType)
					{
						case "A" :  // Business and Helicopter 
							Query = $"{Query}AND (A2.ac_product_business_flag = 'Y' OR A2.ac_product_helicopter_flag = 'Y') "; 
							break;
						case "B" :  // Business Only 
							Query = $"{Query}AND (A2.ac_product_business_flag = 'Y') "; 
							break;
						case "C" :  // Commerical Only 
							Query = $"{Query}AND (A2.ac_product_commercial_flag = 'Y') "; 
							break;
						case "H" :  // Helicopter Only 
							Query = $"{Query}AND (A2.ac_product_helicopter_flag = 'Y') "; 
							break;
						case "L" :  // ALL 
							 
							break;
						case "P" :  // AirBP 
							Query = $"{Query}AND (A2.ac_product_airbp_flag = 'Y') "; 
							break;
					} // Case strPType

					Query = $"{Query}) As aircraft_count, ";

					Query = $"{Query}comp_last_contact_date, ";

					// 08/27/2015 - By David D. Cruger; Added JNiQ Last Attempted Date
					Query = $"{Query}(SELECT max(journ_date) FROM Journal WITH (NOLOCK) ";
					Query = $"{Query} WHERE (journ_comp_id = comp_id) ";
					Query = $"{Query} AND (journ_date >= '1/1/2010') ";
					Query = $"{Query} AND ( ";
					Query = $"{Query}       (journ_subcategory_code = 'IQ') ";
					Query = $"{Query}    OR (journ_subcategory_code = 'RN' AND journ_subject LIKE '%JNiQ%') ";
					Query = $"{Query}     ) ";
					// Query = Query & " ORDER BY journ_date DESC "
					Query = $"{Query}) As dtJNiQLastAttemptedDate, ";

					// 01/28/2016 - By David D. Cruger; Added JNiQ Last Attempted Date
					Query = $"{Query}(SELECT max(journ_date) FROM Journal WITH (NOLOCK) ";
					Query = $"{Query} WHERE (journ_comp_id = comp_id) ";
					Query = $"{Query} AND (journ_date >= '1/1/2010') ";
					Query = $"{Query} AND (journ_subcategory_code = 'IQ') ";
					Query = $"{Query} AND (journ_subject LIKE 'Completed Q%') ";
					Query = $"{Query} AND (journ_subject LIKE '% Survey%') ";
					//Query = Query & " ORDER BY journ_date DESC "
					Query = $"{Query}) As dtJNiQLastCompletedDate, ";

					Query = $"{Query}compref_rel_comp_id ";

					// RTW TEMP HOLD - I WOULD LOVE TO REMOVE THIS JOIN - WHEN I DO I GET ONE OTHER RECORD THEY DON'T WANT
					// 07/18/2019 - By David D. Cruger; Removed INDEX HINT
					Query = $"{Query}FROM Company AS C1 WITH (NOLOCK) ";
					//Query = Query & "FROM Company AS C1 WITH(NOLOCK, INDEX(ix_comp_callback_key)) "
					Query = $"{Query}LEFT OUTER JOIN Company_Reference WITH (NOLOCK) on comp_id = compref_rel_comp_id and compref_contact_type = '79' ";


					Query = $"{Query}WHERE comp_account_id {make_account_rep_answer_string()}";





					Query = $"{Query}AND comp_account_callback_date <= '{tmpDate}' ";

					// RTW - MODIFIED - 2/7/2012 - SCALE FOR INCREASING SEARCH
					if (Strings.Len(($"{txt_ListStartDate.Text}").Trim()) > 0)
					{
						Query = $"{Query}AND comp_account_callback_date > '{txt_ListStartDate.Text}' ";
					}
					Query = $"{Query}AND (comp_last_contact_date < '{tmpDate}' OR comp_last_contact_date IS NULL) ";
					// and comp_id NOT IN (SELECT DISTINCT compref_rel_comp_id FROM Company_Reference WITH (NOLOCK) WHERE compref_contact_type = '79')
					Query = $"{Query}AND comp_active_flag='Y' AND comp_journ_id=0 ";

					// ***********************************************
					// SELECT THE RIGHT COMPANY PRODUCT TYPES

					switch(cmbProductType.Text.Substring(0, Math.Min(1, cmbProductType.Text.Length)))
					{
						case "A" :  // Business and Helicopters 
							Query = $"{Query}AND (comp_product_business_flag = 'Y') "; 
							Query = $"{Query}AND (comp_product_helicopter_flag = 'Y') "; 
							Query = $"{Query}AND (comp_product_commercial_flag = 'N')"; 
							 
							break;
						case "B" :  // Business Only 
							Query = $"{Query}AND (comp_product_business_flag = 'Y') "; 
							Query = $"{Query}AND (comp_product_helicopter_flag = 'N') "; 
							Query = $"{Query}AND (comp_product_commercial_flag = 'N')"; 
							 
							break;
						case "H" :  // Helicopter Only 
							Query = $"{Query}AND (comp_product_business_flag = 'N') "; 
							Query = $"{Query}AND (comp_product_helicopter_flag = 'Y') "; 
							Query = $"{Query}AND (comp_product_commercial_flag = 'N')"; 
							 
							break;
						case "C" :  // Commerical Only 
							Query = $"{Query}AND (comp_product_business_flag = 'N') "; 
							Query = $"{Query}AND (comp_product_helicopter_flag = 'N') "; 
							Query = $"{Query}AND (comp_product_commercial_flag = 'Y')"; 
							 
							// 11/07/2014 - By David D. Cruger 
							// Added Per Jackie 
							 
							break;
						case "Q" :  // JNiQ Eligible 
							 
							Query = $"{Query}{modCommon.Return_JNiQ_Eligible_Query(strAcctRep, Query)}"; 
							 
							break;
						case "N" :  // Non-JNiQ Eligible 
							 
							Query = $"{Query}{modCommon.Return_Non_JNiQ_Eligible_Query()}"; 
							 
							break;
						case "P" :  // AirBP 
							Query = $"{Query}AND (comp_product_airbp_flag = 'Y')"; 
							 
							break;
						case "L" :  // ALL 
							 
							break;
					} // Case left(cmbProductType.Text, 1)

					// 07/25/2016 - By David D. Cruger; Added Search for Customers or Non-Customers
					if (optSearchCust[1].Checked)
					{ // Customers Only
						Query = $"{Query}AND (EXISTS (SELECT NULL FROM Services_Used WITH (NOLOCK) ";
						Query = $"{Query}             WHERE (svud_code = comp_service) ";
						Query = $"{Query}             AND (svud_desc LIKE '%JETNET%' OR svud_desc LIKE '%AVDATA%') ";
						Query = $"{Query}            ) ";
						Query = $"{Query}    ) ";
					}

					if (optSearchCust[2].Checked)
					{ // Non-Customers
						Query = $"{Query}AND (   comp_service IS NULL ";
						Query = $"{Query}     OR comp_service = '' ";
						Query = $"{Query}     OR comp_service = 'U' ";
						Query = $"{Query}     OR (NOT EXISTS (SELECT NULL FROM Services_Used WITH (NOLOCK) ";
						Query = $"{Query}                     WHERE (svud_code = comp_service) ";
						Query = $"{Query}                     AND (svud_desc LIKE '%JETNET%' OR svud_desc LIKE '%AVDATA%') ";
						Query = $"{Query}                    ) ";
						Query = $"{Query}        ) ";
						Query = $"{Query}    ) ";
					}

					if (cbo_Timezones.Text != "All")
					{
						if (cbo_Timezones.Text == "International")
						{
							Query = $"{Query}AND ((comp_timezone is NULL) or (comp_timezone=''))";
						}
						else
						{
							Query = $"{Query}AND (comp_timezone='{cbo_Timezones.Text}') ";
						}
					}

					if (cbo_primary_country.Text.Trim() != "" && cbo_primary_country.Text.Trim() != "All")
					{
						Query = $"{Query}AND (comp_country = '{cbo_primary_country.Text.Trim()}') ";
					}

					Query = $"{Query}GROUP BY comp_name,comp_city,comp_state,comp_id,comp_journ_id,comp_account_callback_date,comp_country,comp_timezone,comp_last_contact_date, compref_rel_comp_id, comp_service ";
					//Query = Query & "Group by comp_name,comp_city,comp_state,comp_id,comp_account_callback_date,comp_country,comp_timezone,comp_last_contact_date "
					Query = $"{Query}HAVING compref_rel_comp_id Is Null ";



					Query = $"{Query}{Convert.ToString(grd_Callbacks.Tag)}"; // ORDER BY


					// *****************************************************************************8
				}
				else
				{
					// THIS SECTION IS USED FOR NON DEALER BROKER (END USER CALLBACK LISTS)

					errString = "Get Callback Data alt ";

					//use a different select statement for the bound grid
					// HasBoundCallback = True
					// MODIFIED ON 2/2/2012 - RTW - TO GET JUST TOP 250
					if (chk_action_list[chkAllCompanies].CheckState == CheckState.Checked)
					{
						Query = "SELECT ";
					}
					else
					{
						Query = "SELECT TOP 250 ";
					}
					Query = $"{Query}comp_id, ";
					Query = $"{Query}comp_account_callback_date, ";
					Query = $"{Query}comp_name, ";
					Query = $"{Query}(comp_city + ' [' + comp_country + ']') AS location, ";
					Query = $"{Query}comp_city, ";
					Query = $"{Query}comp_country, ";
					Query = $"{Query}comp_state, comp_timezone, ";
					Query = $"{Query}count(*) AS aircraft_count, ";
					Query = $"{Query}comp_last_contact_date, ";

					// ADDED MSW - 8/13/18 - TO GET LAST JOURNAL NOTE
					Query = $"{Query} (select top 1 journ_subject  from Journal with (NOLOCK) where journ_comp_id = comp_id and journ_subcategory_code = 'IQ' order by journ_id desc) as iq_note_type, ";


					// 07/25/2016 - By David D. Cruger; Added
					Query = $"{Query}(SELECT TOP 1 svud_Desc FROM Services_Used WITH (NOLOCK) WHERE (svud_code = comp_service)) As CompService, ";

					// 07/25/2016 - By David D. Cruger; Added
					Query = $"{Query}STUFF((SELECT DISTINCT ';'+sub_serv_code FROM Subscription WITH (NOLOCK) ";
					Query = $"{Query}WHERE (sub_comp_id = comp_id) ";
					Query = $"{Query}AND (sub_start_date <= GETDATE()) ";
					Query = $"{Query}AND (sub_end_date IS NULL OR sub_end_date > GETDATE()) ";
					Query = $"{Query}AND (sub_marketing_flag = 'N') ";
					Query = $"{Query}FOR XML PATH('')),1,1,'') As ActiveSubService, ";

					// 08/27/2015 - By David D. Cruger; Added JNiQ Last Attempted Date
					Query = $"{Query}(SELECT max(journ_date) FROM Journal WITH (NOLOCK) ";
					Query = $"{Query} WHERE (journ_comp_id = comp_id) ";
					Query = $"{Query} AND ( ";
					Query = $"{Query}       (journ_subcategory_code = 'IQ') ";
					Query = $"{Query}    OR (journ_subcategory_code = 'RN' AND journ_subject LIKE '%JNiQ%') ";
					Query = $"{Query}     ) ";
					//Query = Query & " ORDER BY journ_date DESC "
					Query = $"{Query}) As dtJNiQLastAttemptedDate, ";

					// 01/28/2016 - By David D. Cruger; Added JNiQ Last Attempted Date
					Query = $"{Query}(SELECT max(journ_date) FROM Journal WITH (NOLOCK) ";
					Query = $"{Query} WHERE (journ_comp_id = comp_id) ";
					Query = $"{Query} AND (journ_date >= '1/1/2010') ";
					Query = $"{Query} AND (journ_subcategory_code = 'IQ') ";
					Query = $"{Query} AND (journ_subject LIKE 'Completed Q%') ";
					Query = $"{Query} AND (journ_subject LIKE '% Survey%') ";
					// Query = Query & " ORDER BY journ_date DESC "
					Query = $"{Query}) As dtJNiQLastCompletedDate ";

					// 07/18/2019 - By David D. Cruger; Removed INDEX HINT
					//Query = Query & "FROM Company AS C1 WITH(NOLOCK, INDEX(" & chr(34) & "ix_comp_callback_key" & chr(34) & ")) "
					Query = $"{Query}FROM Company AS C1 WITH (NOLOCK) ";
					//Query = Query & "INNER JOIN Aircraft_Reference AS AR1 WITH(NOLOCK, INDEX(" & chr(34) & "ix_cref_comp_journ_primary_poc_key" & chr(34) & ")) ON comp_id = cref_comp_id AND comp_journ_id = cref_journ_id "
					Query = $"{Query}INNER JOIN Aircraft_Reference AS AR1 WITH (NOLOCK) ON comp_id = cref_comp_id AND comp_journ_id = cref_journ_id ";
					Query = $"{Query}INNER JOIN Aircraft AS A1 WITH(NOLOCK) ON cref_ac_id = ac_id AND cref_journ_id = ac_journ_id ";
					Query = $"{Query}INNER JOIN Aircraft_Model AS AM1 WITH(NOLOCK) ON ac_amod_id = amod_id ";
					Query = $"{Query}WHERE comp_account_id  {make_account_rep_answer_string()}  ";
					Query = $"{Query}AND (comp_journ_id = 0) ";
					Query = $"{Query}AND (comp_active_flag = 'Y') ";


					Query = $"{Query}{Find_Models_Excluded("", "A1", "Aircraft")}";


					if (chk_action_list[chkExcludedReassigns].CheckState == CheckState.Checked)
					{
						Query = $"{Query} and not exists (SELECT j2.journ_id FROM Journal j2 WITH (NOLOCK) WHERE j2.journ_ac_id =  a1.ac_id AND j2.journ_subcategory_code = 'AA') ";
					}

					// show only IQ completed
					if (chk_action_list[chkShowIQCompleted].CheckState == CheckState.Checked)
					{
						Query = $"{Query}  and exists (SELECT top 1 j2.journ_description  FROM Journal j2 WITH (NOLOCK)  WHERE ((j2.journ_subject like '%completed%' and j2.journ_subject like '%survey%' and j2.journ_comp_id = comp_id and journ_date >= GETDATE()-90))) ";
					}

					// hide IQ declined
					if (chk_action_list[chkHideIQDeclined].CheckState == CheckState.Checked)
					{
						Query = $"{Query}  and not exists (SELECT top 100 j2.journ_description  FROM Journal j2 WITH(NOLOCK)  WHERE ((j2.journ_subject = 'JNiQ - Declined Survey' and j2.journ_comp_id = comp_id and journ_date >= GETDATE()-90) or  (j2.journ_subject = 'JNiQ - Declined Survey - Do not Send' and j2.journ_comp_id = comp_id and journ_date >= GETDATE()-365))) ";
					}


					// 06/04/2015 - By David D. Cruger;
					// Per Lucia Do NOT Include Class E
					Query = $"{Query}AND (AM1.amod_class_code <> 'E') ";

					if (cbo_Timezones.Text != "All")
					{
						if (cbo_Timezones.Text == "International")
						{
							Query = $"{Query}AND (comp_timezone IS NULL OR comp_timezone = '') ";
						}
						else
						{
							Query = $"{Query}AND (comp_timezone = '{cbo_Timezones.Text}') ";
						}
					}

					// ***********************************************
					// SELECT THE RIGHT COMPANY PRODUCT TYPES
					// ***********************************************


					switch(cmbProductType.Text.Substring(0, Math.Min(1, cmbProductType.Text.Length)))
					{
						case "A" :  // Business and Helicopters 
							Query = $"{Query}AND (comp_product_business_flag = 'Y') "; 
							Query = $"{Query}AND (comp_product_helicopter_flag = 'Y') "; 
							Query = $"{Query}AND (comp_product_commercial_flag = 'N')"; 
							 
							break;
						case "B" :  // Business Only 
							Query = $"{Query}AND (comp_product_business_flag = 'Y') "; 
							Query = $"{Query}AND (comp_product_helicopter_flag = 'N') "; 
							Query = $"{Query}AND (comp_product_commercial_flag = 'N')"; 
							 
							break;
						case "H" :  // Helicopter Only 
							Query = $"{Query}AND (comp_product_business_flag = 'N') "; 
							Query = $"{Query}AND (comp_product_helicopter_flag = 'Y') "; 
							Query = $"{Query}AND (comp_product_commercial_flag = 'N')"; 
							 
							break;
						case "C" :  // Commerical Only 
							Query = $"{Query}AND (comp_product_business_flag = 'N') "; 
							Query = $"{Query}AND (comp_product_helicopter_flag = 'N') "; 
							Query = $"{Query}AND (comp_product_commercial_flag = 'Y')"; 
							 
							// 11/07/2014 - By David D. Cruger 
							// Added Per Jackie 
							 
							break;
						case "Q" :  // JNiQ Eligible 
							 
							Query = $"{Query}{modCommon.Return_JNiQ_Eligible_Query(strAcctRep, Query)}"; 
							 
							break;
						case "N" :  // Non-JNiQ Eligible 
							 
							Query = $"{Query}{modCommon.Return_Non_JNiQ_Eligible_Query()}"; 
							 
							break;
						case "P" :  // AirBP 
							Query = $"{Query}AND (comp_product_airbp_flag = 'Y')"; 
							 
							break;
						case "L" :  // ALL 
							 
							break;
					} // Case left(cmbProductType.Text, 1)

					if (chk_action_list[chkViewMasterList].CheckState == CheckState.Unchecked)
					{

						if (Strings.Len(($"{txt_Callback_Date.Text}").Trim()) > 0)
						{
							Query = $"{Query}AND comp_account_callback_date <= '{txt_Callback_Date.Text}' ";
						}
						// RTW - MODIFIED - 2/7/2012 - SCALE FOR INCREASING SEARCH
						if (Strings.Len(($"{txt_ListStartDate.Text}").Trim()) > 0)
						{
							Query = $"{Query}AND comp_account_callback_date > '{txt_ListStartDate.Text}' ";
						}

						// do not get companies that were called today
						Query = $"{Query}AND (comp_last_contact_date < '{DateTime.Now.ToString("d")}' OR comp_last_contact_date IS NULL) ";

					} // If chk_action_list(chkViewMasterList).Value = vbUnchecked Then

					Query = $"{Query}AND (cref_primary_poc_flag = 'Y') ";

					// 07/25/2016 - By David D. Cruger; Added Search for Customers or Non-Customers
					if (optSearchCust[1].Checked)
					{ // Customers Only
						Query = $"{Query}AND (EXISTS (SELECT NULL FROM Services_Used WITH (NOLOCK) ";
						Query = $"{Query}             WHERE (svud_code = comp_service) ";
						Query = $"{Query}             AND (svud_desc LIKE '%JETNET%' OR svud_desc LIKE '%AVDATA%') ";
						Query = $"{Query}            ) ";
						Query = $"{Query}    ) ";
					}

					if (optSearchCust[2].Checked)
					{ // Non-Customers
						Query = $"{Query}AND (   comp_service IS NULL ";
						Query = $"{Query}     OR comp_service = '' ";
						Query = $"{Query}     OR comp_service = 'U' ";
						Query = $"{Query}     OR (NOT EXISTS (SELECT NULL FROM Services_Used WITH (NOLOCK) ";
						Query = $"{Query}                     WHERE (svud_code = comp_service) ";
						Query = $"{Query}                     AND (svud_desc LIKE '%JETNET%' OR svud_desc LIKE '%AVDATA%') ";
						Query = $"{Query}                    ) ";
						Query = $"{Query}        ) ";
						Query = $"{Query}    ) ";
					}


					if (cbo_primary_country.Text.Trim() != "" && cbo_primary_country.Text.Trim() != "All")
					{
						Query = $"{Query}AND (comp_country = '{cbo_primary_country.Text.Trim()}') ";
					}

					Query = $"{Query}GROUP BY comp_account_callback_date, comp_name, comp_id, comp_city, comp_state, comp_country, ";
					Query = $"{Query}comp_journ_id, comp_timezone, comp_last_contact_date, comp_service ";
					Query = $"{Query}{strOrderBy}";

				} // If strAcctRep = "DB" Or strAcctRepId = "ACAX" Or strAcctRepId = "DEX1" Or strAcctRepId = "DEX2" Then

				if (HasBoundCallback)
				{

					errString = "binding setup";

					errString = $"binding cntl:{($"{cbo_account_id.Text}").Trim()}";

					Adodc_CallBack.ConnectionString = modAdminCommon.LOCAL_ADO_DB.ConnectionString;
					Adodc_CallBack.RecordSource = Query;
					Adodc_CallBack.Refresh();

					errString = "open callback - bound";
					//UPGRADE_ISSUE: (2064) ADODB.Recordset method Adodc_CallBack.Recordset.Clone was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					snp_Callback = Adodc_CallBack.Recordset.getClone();
					if (snp_Callback.EOF && snp_Callback.BOF)
					{
						errString = "No callbacks - bound";
						lbl_Message.Text = "No Callbacks Selected. -";
						cmd_Update_Callback_Dates.Visible = false;
						return;
					}

					grd_Callbacks.DataSource = Adodc_CallBack.Recordset.Tables[0];
					grd_Callbacks.Refresh();
					grd_Callbacks.Visible = true;
					pnl_Callbacks.Visible = true;

					txt_TotalCallbacks.Text = snp_Callback.RecordCount.ToString();

				}
				else
				{

					errString = "close file";
					if (snp_Callback.State == ConnectionState.Open)
					{
						snp_Callback.Close();
					}

					errString = "open query";

					snp_Callback.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!snp_Callback.BOF && !snp_Callback.EOF)
					{

						errString = "Fill grid";
						cellcolor = modAdminCommon.NoColor;
						pnl_Callbacks.Visible = true;
						cmdStop.Visible = true;

						grd_Callbacks.Redraw = false;

						lCnt1 = 0;

						do 
						{ // Loop Until snp_Callback.EOF = True Or Stopped = True

							lCnt1++;

							errString = "Fill In Grid";

							lbl_Message.Text = " ";

							grd_Callbacks.CurrentColumnIndex = 0;
							grd_Callbacks[grd_Callbacks.CurrentRowIndex, grd_Callbacks.CurrentColumnIndex].Value = Convert.ToString(snp_Callback["comp_id"]);
							grd_Callbacks.set_RowData(grd_Callbacks.CurrentRowIndex, Convert.ToInt32(snp_Callback.GetField("comp_id")));

							if (chk_action_list[chkClassA].CheckState == CheckState.Checked)
							{
								if (Class_A_Aircraft(($"{Convert.ToString(snp_Callback["comp_id"])}").Trim()))
								{
									cellcolor = (0xFFFFC0).ToString();
								}
								else
								{
									cellcolor = modAdminCommon.NoColor;
								}
							}
							else
							{
								cellcolor = modAdminCommon.NoColor;
							}

							//fill call back grid
							if (Conversion.Val(($"0{Convert.ToString(snp_Callback["comp_id"])}").Trim()) != PreviousCompID)
							{


								grd_Callbacks.CurrentColumnIndex = 1; // Callback Date
								grd_Callbacks.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
								grd_Callbacks[grd_Callbacks.CurrentRowIndex, grd_Callbacks.CurrentColumnIndex].Value = $"{Convert.ToDateTime(snp_Callback["comp_account_callback_date"]).ToString("d")} ";


								grd_Callbacks.CurrentColumnIndex = 2; // Company Name
								grd_Callbacks.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
								grd_Callbacks.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
								grd_Callbacks[grd_Callbacks.CurrentRowIndex, grd_Callbacks.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_Callback["comp_name"])} ").Trim();

								grd_Callbacks.CurrentColumnIndex = 3; // Country
								grd_Callbacks.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
								grd_Callbacks[grd_Callbacks.CurrentRowIndex, grd_Callbacks.CurrentColumnIndex].Value = $"{($"{Convert.ToString(snp_Callback["Comp_city"])} ").Trim()} [{($"{Convert.ToString(snp_Callback["Comp_country"])} ").Trim()}]";

								tcol = 4;
								if (chk_action_list[chkShowIQCompleted].CheckState == CheckState.Checked || chk_action_list[chkHideIQDeclined].CheckState == CheckState.Checked)
								{
								}
								else
								{
									grd_Callbacks.CurrentColumnIndex = tcol; // State
									grd_Callbacks.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
									grd_Callbacks[grd_Callbacks.CurrentRowIndex, grd_Callbacks.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_Callback["comp_state"])} ").Trim();
									tcol++;
								}

								grd_Callbacks.CurrentColumnIndex = tcol; // Time Zone
								grd_Callbacks.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
								grd_Callbacks[grd_Callbacks.CurrentRowIndex, grd_Callbacks.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_Callback["comp_timezone"])} ").Trim();
								tcol++;

								if (chk_action_list[chkShowIQCompleted].CheckState == CheckState.Checked || chk_action_list[chkHideIQDeclined].CheckState == CheckState.Checked)
								{
								}
								else
								{
									grd_Callbacks.CurrentColumnIndex = tcol; // Nbr Aircraft
									grd_Callbacks.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
									//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
									if (!Convert.IsDBNull(snp_Callback["aircraft_count"]))
									{
										grd_Callbacks[grd_Callbacks.CurrentRowIndex, grd_Callbacks.CurrentColumnIndex].Value = snp_Callback.GetField("aircraft_count");
									}
									tcol++;


									grd_Callbacks.CurrentColumnIndex = tcol; // Last Attempt Date
									grd_Callbacks.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
									grd_Callbacks[grd_Callbacks.CurrentRowIndex, grd_Callbacks.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_Callback["comp_last_contact_date"])} ").Trim();
									tcol++;
								}

								grd_Callbacks.CurrentColumnIndex = tcol; // JNiQ Last Attempted Date
								grd_Callbacks.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(snp_Callback["dtJNiQLastAttemptedDate"]))
								{
									grd_Callbacks[grd_Callbacks.CurrentRowIndex, grd_Callbacks.CurrentColumnIndex].Value = Convert.ToDateTime(snp_Callback["dtJNiQLastAttemptedDate"]).ToString("MM/dd/yyyy");
								}
								tcol++;


								grd_Callbacks.CurrentColumnIndex = tcol; // JNiQ Last Completed Date
								grd_Callbacks.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(snp_Callback["dtJNiQLastCompletedDate"]))
								{
									grd_Callbacks[grd_Callbacks.CurrentRowIndex, grd_Callbacks.CurrentColumnIndex].Value = Convert.ToDateTime(snp_Callback["dtJNiQLastCompletedDate"]).ToString("MM/dd/yyyy");
								}
								tcol++;


								if (chk_action_list[chkShowIQCompleted].CheckState == CheckState.Checked || chk_action_list[chkHideIQDeclined].CheckState == CheckState.Checked)
								{
								}
								else
								{
									grd_Callbacks.CurrentColumnIndex = tcol;
									grd_Callbacks.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
									grd_Callbacks.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
									grd_Callbacks[grd_Callbacks.CurrentRowIndex, grd_Callbacks.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_Callback["CompService"])} ").Trim();
									tcol++;

									grd_Callbacks.CurrentColumnIndex = tcol;
									grd_Callbacks.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
									grd_Callbacks.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
									grd_Callbacks[grd_Callbacks.CurrentRowIndex, grd_Callbacks.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_Callback["ActiveSubService"])} ").Trim();
									tcol++;
								}

								grd_Callbacks.CurrentColumnIndex = tcol; // Date Sort
								grd_Callbacks.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
								grd_Callbacks[grd_Callbacks.CurrentRowIndex, grd_Callbacks.CurrentColumnIndex].Value = $"{Convert.ToDateTime(snp_Callback["comp_account_callback_date"]).ToString("yyyyMMdd")} ";
								tcol++;

								grd_Callbacks.CurrentColumnIndex = tcol; // Last Attempted Date Sort
								grd_Callbacks.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
								grd_Callbacks[grd_Callbacks.CurrentRowIndex, grd_Callbacks.CurrentColumnIndex].Value = Convert.ToDateTime(snp_Callback["comp_last_contact_date"]).ToString("yyyyMMdd");
								tcol++;

								grd_Callbacks.CurrentColumnIndex = tcol; // JNiQ Last Attempted Sort Date
								grd_Callbacks.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(snp_Callback["dtJNiQLastAttemptedDate"]))
								{
									grd_Callbacks[grd_Callbacks.CurrentRowIndex, grd_Callbacks.CurrentColumnIndex].Value = Convert.ToDateTime(snp_Callback["dtJNiQLastAttemptedDate"]).ToString("yyyyMMdd");
								}
								tcol++;


								grd_Callbacks.CurrentColumnIndex = tcol; // JNiQ Last Completed Sort Date
								grd_Callbacks.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(snp_Callback["dtJNiQLastCompletedDate"]))
								{
									grd_Callbacks[grd_Callbacks.CurrentRowIndex, grd_Callbacks.CurrentColumnIndex].Value = Convert.ToDateTime(snp_Callback["dtJNiQLastCompletedDate"]).ToString("yyyyMMdd");
								}
								tcol++;









								grd_Callbacks.CurrentColumnIndex = tcol; // JNiQ Last Journal
								grd_Callbacks.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(snp_Callback["iq_note_type"]))
								{
									// If left(Trim(snp_Callback!iq_note_type), 4) = "Sent" Then
									grd_Callbacks[grd_Callbacks.CurrentRowIndex, grd_Callbacks.CurrentColumnIndex].Value = Convert.ToString(snp_Callback["iq_note_type"]).Trim();
									// ElseIf left(Trim(snp_Callback!iq_note_type), 11) = "Auto Mailer" Then
									//      .Text = Trim(snp_Callback!iq_note_type)
									// Else
									//     .Text = Trim(snp_Callback!iq_note_type)
									// End If

								}




								 // grd_Callbacks

								grd_Callbacks.CurrentRowIndex = grd_Callbacks.RowsCount - 1;
								grd_Callbacks.CurrentColumnIndex = 2;
								if (grd_Callbacks[grd_Callbacks.CurrentRowIndex, grd_Callbacks.CurrentColumnIndex].FormattedValue.ToString().IndexOf("[]") >= 0)
								{
									grd_Callbacks[grd_Callbacks.CurrentRowIndex, grd_Callbacks.CurrentColumnIndex].Value = grd_Callbacks[grd_Callbacks.CurrentRowIndex, grd_Callbacks.CurrentColumnIndex].FormattedValue.ToString().Substring(0, Math.Min(Strings.Len(grd_Callbacks[grd_Callbacks.CurrentRowIndex, grd_Callbacks.CurrentColumnIndex].FormattedValue.ToString()) - 2, grd_Callbacks[grd_Callbacks.CurrentRowIndex, grd_Callbacks.CurrentColumnIndex].FormattedValue.ToString().Length));
								}

								PreviousCompID = Convert.ToInt32(Double.Parse(($"0{Convert.ToString(snp_Callback["comp_id"])}").Trim()));
								TotalCallbacks++;
							}
							else
							{
								grd_Callbacks.CurrentColumnIndex = 5;
								grd_Callbacks.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
								grd_Callbacks[grd_Callbacks.CurrentRowIndex, grd_Callbacks.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_Callback["amod_class_code"])} ").Trim();
								grd_Callbacks.CurrentColumnIndex = 6;
								grd_Callbacks.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
								if (cbo_account_id.Text.Substring(0, Math.Min(2, cbo_account_id.Text.Length)).ToUpper() != "DB")
								{
									grd_Callbacks[grd_Callbacks.CurrentRowIndex, grd_Callbacks.CurrentColumnIndex].Value = snp_Callback.GetField("aircraft_count");
								}
								else
								{
									TempCount = GetACCount(Convert.ToInt32(Conversion.Val(($"{Convert.ToString(snp_Callback["comp_id"])}").Trim())));
									grd_Callbacks[grd_Callbacks.CurrentRowIndex, grd_Callbacks.CurrentColumnIndex].Value = TempCount;
								}
							} // If Val(Trim("0" & snp_Callback!Comp_id)) <> PreviousCompID Then

							if (cbo_account_id.Text.Substring(0, Math.Min(2, cbo_account_id.Text.Length)).ToUpper() != "DB")
							{
								TotalAircraft = Convert.ToInt32(TotalAircraft + Convert.ToDouble(snp_Callback["aircraft_count"]));
							}
							else
							{
								TotalAircraft += TempCount;
							}

							grd_Callbacks.set_RowData(grd_Callbacks.CurrentRowIndex, Convert.ToInt32(snp_Callback["Comp_id"]));

							grd_Callbacks.RowsCount++;
							grd_Callbacks.CurrentRowIndex++;
							txt_TotalAircraft.Text = TotalAircraft.ToString();
							txt_TotalCallbacks.Text = TotalCallbacks.ToString();

							if (lCnt1 == 19)
							{
								grd_Callbacks.Redraw = true;
								grd_Callbacks.Refresh();
								Application.DoEvents();
								grd_Callbacks.Redraw = false;
							}

							snp_Callback.MoveNext();

						}
						while(!(snp_Callback.EOF || Stopped));

						errString = "Done filling grid";

						cmdStop.Visible = false;
						Stopped = false;

						grd_Callbacks.RowsCount--;
						txt_TotalAircraft.Text = TotalAircraft.ToString();
						txt_TotalCallbacks.Text = TotalCallbacks.ToString();

						grd_Callbacks.Visible = true;
						pnl_Callbacks.Visible = true;
						grd_Callbacks.Redraw = true;

					}
					else
					{
						errString = "No callbacks";
						grd_Callbacks[1, 2].Value = "No Callback Records Found";
						cmd_Update_Callback_Dates.Visible = false;
					} // If Not (snp_Callback.BOF And snp_Callback.EOF) Then

				} // If HasBoundCallback Then

				errString = "CB close";
				snp_Callback.Close();
				Adodc_CallBack.ConnectionString = "";
				snp_Callback = null;

				if (txt_TotalAircraft.Text == "")
				{
					grd_Callbacks.CurrentColumnIndex = 6;
					TotalAircraft = 0;
					int tempForEndVar = grd_Callbacks.RowsCount - 1;
					for (int K = 1; K <= tempForEndVar; K++)
					{
						grd_Callbacks.CurrentRowIndex = K;
						TotalAircraft = Convert.ToInt32(TotalAircraft + Conversion.Val($"{grd_Callbacks[grd_Callbacks.CurrentRowIndex, grd_Callbacks.CurrentColumnIndex].FormattedValue.ToString()}"));
					}
					txt_TotalAircraft.Text = TotalAircraft.ToString();
				}

				strMsg = $"AcctRep: {cbo_account_id.Text}";
				strMsg = $"{strMsg} TimeScale: {cbo_TimeScale.Text}";

				if (chk_action_list[chkAllCompanies].CheckState == CheckState.Checked)
				{
					strMsg = $"{strMsg} [x] All Companies ";
				}

				if (chk_action_list[chkViewMasterList].CheckState == CheckState.Checked)
				{

					strMsg = $"{strMsg} [x] View Master List (Ignore Calendar) ";
				}

				if (bLog)
				{

					modCommon.End_Activity_Monitor_Message("Callback Aircraft", ref strMsg, dtStartDate, ref dtEndDate, 0, 0, 0, 0, 0);

					frm_UserHistory.DefInstance.Refresh_User_History_Grids("Callback");

				}

				cmdRefresh.Enabled = true;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_Callback_Grid_Error: {errString} - {Information.Err().Number.ToString()} {excep.Message}");
				Adodc_CallBack.ConnectionString = "";
				snp_Callback = null;
			}

		} // Fill_Callback_Grid

		public bool Class_A_Aircraft(string vcomp_id)
		{

			bool result = false;
			try
			{

				//----------------------------------------------------------------------------------------------
				//Function used to select class 'A' aircraft
				//----------------------------------------------------------------------------------------------

				string Query = "";
				ADORecordSetHelper snp_ClassA = new ADORecordSetHelper();

				Query = $"EXEC HomebaseQueryGetAircraftClass {vcomp_id}";

				snp_ClassA.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				result = !(snp_ClassA.BOF && snp_ClassA.EOF);

				snp_ClassA.Close();
				snp_ClassA = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"Class_A_Aircraft_Error: {excep.Message}");
			}

			return result;
		}

		private void Fill_Exclusive_Callback_Grid()
		{
			//******************************************************************************************
			//* Note: VBC id'd the following unreferenced items and handled them as described:         *
			//*                                                                                        *
			//* Local Variables (Removed)                                                              *
			//*  TempLocation                  TotalAircraft                 acline                    *
			//*  PrevCompany                   cellcolor                                               *
			//******************************************************************************************

			//----------------------------------------------------------------------------------------------
			//Function used to fill the Exclusive Callback Grid
			//----------------------------------------------------------------------------------------------

			string Query = "";
			string strError = "";
			string strAcctRep = "";
			string strAcctRepId = "";
			int TotalCallbacks = 0;
			int lCol1 = 0;
			string strMsg = "";
			System.DateTime dtStartDate = DateTime.FromOADate(0);
			System.DateTime dtEndDate = DateTime.FromOADate(0);

			try
			{

				if (cmd_refresh[2].Enabled)
				{

					modCommon.Start_Activity_Monitor_Message("Callback Exclusive", ref strMsg, ref dtStartDate, ref dtEndDate);

					string tempRefParam = "Exclusives Due";
					search_on(ref tempRefParam);

					FindId = "Exclusives";
					strError = "Start";
					pnl_lstcompany.Visible = true;
					pnl_Exclusives.Visible = true;
					grd_Exclusives.Visible = true;
					pnl_primary.Visible = false;
					cmd_refresh[2].PerformClick();
					Stopped = false;

					grd_Exclusives.ColumnsCount = 8;
					grd_Exclusives.RowsCount = 1;

					grd_Exclusives.Clear();
					Application.DoEvents();

					grd_Exclusives.CurrentRowIndex = 0;

					lCol1 = 0;
					grd_Exclusives.CurrentColumnIndex = lCol1;
					grd_Exclusives.SetColumnWidth(lCol1, 67);
					grd_Exclusives[grd_Exclusives.CurrentRowIndex, grd_Exclusives.CurrentColumnIndex].Value = "Date";

					lCol1++;
					grd_Exclusives.CurrentColumnIndex = lCol1;
					grd_Exclusives.SetColumnWidth(lCol1, 220);
					grd_Exclusives[grd_Exclusives.CurrentRowIndex, grd_Exclusives.CurrentColumnIndex].Value = "Company";

					lCol1++;
					grd_Exclusives.CurrentColumnIndex = lCol1;
					grd_Exclusives.SetColumnWidth(lCol1, 167);
					grd_Exclusives[grd_Exclusives.CurrentRowIndex, grd_Exclusives.CurrentColumnIndex].Value = "Location";

					lCol1++;
					grd_Exclusives.CurrentColumnIndex = lCol1;
					grd_Exclusives.SetColumnWidth(lCol1, 33);
					grd_Exclusives[grd_Exclusives.CurrentRowIndex, grd_Exclusives.CurrentColumnIndex].Value = "State";

					lCol1++;
					grd_Exclusives.CurrentColumnIndex = lCol1;
					grd_Exclusives.SetColumnWidth(lCol1, 80);
					grd_Exclusives[grd_Exclusives.CurrentRowIndex, grd_Exclusives.CurrentColumnIndex].Value = "Timezone";

					lCol1++;
					grd_Exclusives.CurrentColumnIndex = lCol1;
					grd_Exclusives.SetColumnWidth(lCol1, 200);
					grd_Exclusives[grd_Exclusives.CurrentRowIndex, grd_Exclusives.CurrentColumnIndex].Value = "Make/Model/Serial#";

					lCol1++;
					grd_Exclusives.CurrentColumnIndex = lCol1;
					grd_Exclusives.SetColumnWidth(lCol1, 83);
					grd_Exclusives[grd_Exclusives.CurrentRowIndex, grd_Exclusives.CurrentColumnIndex].Value = "Last Attempted";

					lCol1++;
					grd_Exclusives.CurrentColumnIndex = lCol1;
					grd_Exclusives.SetColumnWidth(lCol1, 83);
					grd_Exclusives[grd_Exclusives.CurrentRowIndex, grd_Exclusives.CurrentColumnIndex].Value = "JNiQ Attempted";
					Application.DoEvents();

					lbl_exclusivesdue.Text = " ";

					if (strReverifyOrderBy.Trim() == "")
					{
						strReverifyOrderBy = "Order by ac_exclusive_verify_date,comp_name,comp_city,comp_state";
					}
					TotalCallbacks = 0;

					strAcctRep = cbo_account_id.Text.Substring(0, Math.Min(2, cbo_account_id.Text.Length)).ToUpper();
					strAcctRepId = cbo_account_id.Text.ToUpper();

					strError = "query";
					//aey 6/24/04 added prefixes to query field names

					Query = "SELECT m.amod_make_name,m.amod_model_name,m.amod_common_verify_days, ";
					Query = $"{Query}a.ac_ser_no_full,a.ac_exclusive_verify_date,a.ac_exclusive_flag, ";
					Query = $"{Query}C1.comp_name,C1.comp_city,C1.comp_state,C1.comp_timezone,C1.comp_account_id, ";
					Query = $"{Query}C1.comp_id,C1.comp_journ_id,a.ac_id,a.ac_exclusive_expiration_flag, ";

					// 03/19/2015 - By David D. Cruger
					// Added Last Attempted Date

					Query = $"{Query}(SELECT CAST(MAX(journ_date) AS DATE) As dtLastAttempted FROM Journal WITH (NOLOCK) ";
					Query = $"{Query}WHERE (journ_comp_id = C1.comp_id) ";
					Query = $"{Query}AND (journ_subject = 'Attempted to Contact') ";
					Query = $"{Query}) As dtLastAttempted, ";

					// 09/15/2015 - By David D. Cruger
					// Per Jackie Added JNiQ Last Attempted Date

					Query = $"{Query}(SELECT TOP 1 journ_date FROM Journal WITH (NOLOCK) ";
					Query = $"{Query} WHERE (journ_comp_id = C1.comp_id) ";
					Query = $"{Query} AND ( ";
					Query = $"{Query}       (journ_subcategory_code = 'IQ') ";
					Query = $"{Query}    OR (journ_subcategory_code = 'RN' AND journ_subject LIKE '%JNiQ%') ";
					Query = $"{Query}     ) ";
					Query = $"{Query} ORDER BY journ_date DESC ";
					Query = $"{Query}) As dtJNiQLastAttemptedDate ";

					Query = $"{Query}FROM Aircraft_Model as M WITH(NOLOCK) ";
					Query = $"{Query}INNER JOIN Aircraft as A WITH(NOLOCK) ON a.ac_amod_id = m.amod_id ";
					Query = $"{Query}INNER JOIN Aircraft_Reference as R WITH(NOLOCK) on (a.ac_id=r.cref_ac_id and a.ac_journ_id=r.cref_journ_id) ";
					Query = $"{Query}INNER JOIN Company AS C1 WITH(NOLOCK) on (C1.comp_id=r.cref_comp_id and C1.comp_journ_id=r.cref_journ_id) ";
					Query = $"{Query}WHERE (a.ac_journ_id = 0) ";

					if (cbo_account_id.Text.Trim() != "No Rep Selected")
					{
						Query = $"{Query}AND C1.comp_account_id  {make_account_rep_answer_string()}"; // Company
					}

					Query = $"{Query}AND (a.ac_exclusive_verify_date <= '{txt_Callback_Date.Text}') ";
					Query = $"{Query}AND (a.ac_exclusive_flag = 'Y') ";
					Query = $"{Query}AND (r.cref_primary_poc_flag = 'X') ";
					Query = $"{Query}AND (C1.comp_id = r.cref_comp_id) ";
					Query = $"{Query}AND (C1.comp_journ_id = r.cref_journ_id) ";
					Query = $"{Query}AND (a.ac_id = r.cref_ac_id) ";
					Query = $"{Query}AND (a.ac_journ_id = r.cref_journ_id) ";
					Query = $"{Query}AND (a.ac_amod_id = m.amod_id) ";

					switch(cmbProductType.Text.Substring(0, Math.Min(1, cmbProductType.Text.Length)))
					{
						case "L" : 
							 
							break;
						case "A" :  // Business and Helicopters 
							Query = $"{Query}AND (amod_product_business_flag = 'Y' OR amod_product_helicopter_flag = 'Y') "; 
							Query = $"{Query}AND (ac_product_business_flag = 'Y' OR ac_product_helicopter_flag = 'Y') "; 
							 
							break;
						case "B" :  // Business Only 
							Query = $"{Query}AND (amod_product_business_flag = 'Y') "; 
							Query = $"{Query}AND (ac_product_business_flag = 'Y') "; 
							 
							break;
						case "H" :  // Helicopter Only 
							Query = $"{Query}AND (amod_airframe_type_code = 'R') "; 
							Query = $"{Query}AND (amod_product_helicopter_flag = 'Y') "; 
							Query = $"{Query}AND (ac_product_helicopter_flag = 'Y') "; 
							 
							break;
						case "C" :  // Commercial Only 
							Query = $"{Query}AND (amod_product_commercial_flag = 'Y') "; 
							Query = $"{Query}AND (ac_product_commercial_flag = 'N') "; 
							 
							break;
						case "Q" :  // JNiQ Eligible 
							 
							Query = $"{Query}{modCommon.Return_JNiQ_Eligible_Query(strAcctRep, Query)}"; 
							 
							break;
						case "N" :  // Non-JNiQ Eligible 
							 
							Query = $"{Query}{modCommon.Return_Non_JNiQ_Eligible_Query()}"; 
							 
							break;
					} // Select Case left(cmbProductType.Text, 1)

					Query = $"{Query}{strReverifyOrderBy}";

					modAdminCommon.Record_Event("Monitor Activity", $"Reverify Exclusive - Selected AcctRep: {strAcctRepId}");
					//Record_Event "HB Usage", "Reverify Exclusive - Selected AcctRep: " & strAcctRepId

					strError = "openrc";
					//Set snp_ExclusiveCallback = LOCAL_DB.OpenRecordset(Query, dbOpenSnapshot, dbSQLPassThrough)
					snp_ExclusiveCallback = new ADORecordSetHelper();
					snp_ExclusiveCallback.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!snp_ExclusiveCallback.BOF && !snp_ExclusiveCallback.EOF)
					{

						grd_Exclusives.Redraw = false;

						grd_Exclusives.RowsCount++;
						grd_Exclusives.CurrentRowIndex++;
						snp_ExclusiveCallback.MoveLast();
						snp_ExclusiveCallback.MoveFirst();

						pnl_Exclusives.Visible = true;
						cmdStop.Visible = true;
						Stopped = false;

						do 
						{ // Loop Until snp_ExclusiveCallback.EOF = True Or Stopped = True

							lCol1 = 0;
							grd_Exclusives.CurrentColumnIndex = lCol1;
							if (($"{Convert.ToString(snp_ExclusiveCallback["ac_exclusive_expiration_flag"])}").Trim() == "Y")
							{
								grd_Exclusives.CellBackColor = Color.Yellow;
							}
							else
							{
								grd_Exclusives.CellBackColor = Color.FromArgb(255, 192, 192);
							}

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(snp_ExclusiveCallback["ac_exclusive_verify_date"]))
							{
								grd_Exclusives.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
								grd_Exclusives[grd_Exclusives.CurrentRowIndex, grd_Exclusives.CurrentColumnIndex].Value = $"{Convert.ToDateTime(snp_ExclusiveCallback["ac_exclusive_verify_date"]).ToString("MM/dd/yyyy")} ";
							}

							lCol1++;
							grd_Exclusives.CurrentColumnIndex = lCol1;
							grd_Exclusives.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.NoColor)));
							grd_Exclusives[grd_Exclusives.CurrentRowIndex, grd_Exclusives.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_ExclusiveCallback["comp_name"])} ").Trim();

							lCol1++;
							grd_Exclusives.CurrentColumnIndex = lCol1;
							grd_Exclusives.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.NoColor)));
							grd_Exclusives[grd_Exclusives.CurrentRowIndex, grd_Exclusives.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_ExclusiveCallback["Comp_city"])} ").Trim();

							lCol1++;
							grd_Exclusives.CurrentColumnIndex = lCol1;
							grd_Exclusives.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.NoColor)));
							grd_Exclusives[grd_Exclusives.CurrentRowIndex, grd_Exclusives.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_ExclusiveCallback["comp_state"])} ").Trim();

							lCol1++;
							grd_Exclusives.CurrentColumnIndex = lCol1;
							grd_Exclusives.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.NoColor)));
							grd_Exclusives[grd_Exclusives.CurrentRowIndex, grd_Exclusives.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_ExclusiveCallback["comp_timezone"])} ").Trim();

							lCol1++;
							grd_Exclusives.CurrentColumnIndex = lCol1;
							grd_Exclusives.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.NoColor)));
							grd_Exclusives[grd_Exclusives.CurrentRowIndex, grd_Exclusives.CurrentColumnIndex].Value = $"{($"{Convert.ToString(snp_ExclusiveCallback["amod_make_name"])}").Trim()}/{($"{Convert.ToString(snp_ExclusiveCallback["amod_model_name"])}").Trim()}/{($"{Convert.ToString(snp_ExclusiveCallback["ac_ser_no_full"])}").Trim()}";

							lCol1++;
							grd_Exclusives.CurrentColumnIndex = lCol1;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(snp_ExclusiveCallback["dtLastAttempted"]))
							{
								grd_Exclusives.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.NoColor)));
								grd_Exclusives.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
								grd_Exclusives[grd_Exclusives.CurrentRowIndex, grd_Exclusives.CurrentColumnIndex].Value = Convert.ToDateTime(snp_ExclusiveCallback["dtLastAttempted"]).ToString("MM/dd/yyyy");
							}

							lCol1++;
							grd_Exclusives.CurrentColumnIndex = lCol1;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(snp_ExclusiveCallback["dtJNiQLastAttemptedDate"]))
							{
								grd_Exclusives.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.NoColor)));
								grd_Exclusives.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
								grd_Exclusives[grd_Exclusives.CurrentRowIndex, grd_Exclusives.CurrentColumnIndex].Value = Convert.ToDateTime(snp_ExclusiveCallback["dtJNiQLastAttemptedDate"]).ToString("MM/dd/yyyy");
							}

							TotalCallbacks++;
							grd_Exclusives.RowsCount++;
							grd_Exclusives.CurrentRowIndex++;
							txt_TotExclusive.Text = StringsHelper.Format(TotalCallbacks, "#,##0");

							if (TotalCallbacks == 18)
							{
								grd_Exclusives.Visible = true;
								grd_Exclusives.Redraw = true;
								Application.DoEvents();
								grd_Exclusives.Redraw = false;
							}

							snp_ExclusiveCallback.MoveNext();
							Application.DoEvents();

						}
						while(!(snp_ExclusiveCallback.EOF || Stopped));

						grd_Exclusives.Visible = true;
						grd_Exclusives.Redraw = true;

						strError = "totals";

						cmdStop.Visible = false;
						grd_Exclusives.RowsCount--;
						txt_TotExclusive.Text = StringsHelper.Format(TotalCallbacks, "#,##0");
						if (TotalCallbacks > 0)
						{
							grd_Exclusives.FixedRows = 1;
						}

					}
					else
					{
						strError = "none selected";
						txt_TotExclusive.Text = "0";
						pnl_Exclusives.Visible = true;
						grd_Exclusives.Visible = false;
						pnl_Exclusives.Visible = false;
						lbl_exclusivesdue.Text = "No Exclusives Due Selected .......";
					} // If (snp_ExclusiveCallback.BOF = False And snp_ExclusiveCallback.EOF = False) Then

					strMsg = $"AcctRep: {cbo_account_id.Text}";
					strMsg = $"{strMsg} Product: {cmbProductType.Text}";
					strMsg = $"{strMsg} Callback Date: {txt_Callback_Date.Text}";

					if (bLog)
					{

						modCommon.End_Activity_Monitor_Message("Callback Exclusive", ref strMsg, dtStartDate, ref dtEndDate, 0, 0, 0, 0, 0);

						frm_UserHistory.DefInstance.Refresh_User_History_Grids("Callback");

					}

					search_off();

					grd_Exclusives.Redraw = true;
					cmd_refresh[2].Enabled = true;

				} // If cmd_refresh(2).Enabled = True Then
			}
			catch (System.Exception excep)
			{

				search_off();
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				strError = $" AR:{($"{cbo_account_id.Text} ").Trim()} cbdate:{txt_Callback_Date.Text} err:{strError} {Information.Err().Number.ToString()} {excep.Message}";
				modAdminCommon.Report_Error($"Fill_Exclusive_Callback_Grid_Error: {strError}");
			}

		}



		private void Fill_Issues_Callback_Grid()
		{

			string Query = "";
			string strError = "";
			string strAcctRep = "";
			string strAcctRepId = "";
			int TotalCallbacks = 0;
			int lCol1 = 0;
			string strMsg = "";
			System.DateTime dtStartDate = DateTime.FromOADate(0);
			System.DateTime dtEndDate = DateTime.FromOADate(0);
			string where_and = "where";

			try
			{

				lbl_gen[53].Text = "0";

				if (cmd_refresh[2].Enabled)
				{

					modCommon.Start_Activity_Monitor_Message("Issues", ref strMsg, ref dtStartDate, ref dtEndDate);


					grd_issues.ColumnsCount = 8;
					grd_issues.RowsCount = 1;

					grd_issues.Clear();
					Application.DoEvents();

					grd_issues.CurrentRowIndex = 0;

					lCol1 = 0;
					grd_issues.CurrentColumnIndex = lCol1;
					grd_issues.SetColumnWidth(lCol1, 80);
					grd_issues[grd_issues.CurrentRowIndex, grd_issues.CurrentColumnIndex].Value = "Area";

					lCol1++;
					grd_issues.CurrentColumnIndex = lCol1;
					grd_issues.SetColumnWidth(lCol1, 93);
					grd_issues[grd_issues.CurrentRowIndex, grd_issues.CurrentColumnIndex].Value = "Title";

					lCol1++;
					grd_issues.CurrentColumnIndex = lCol1;
					grd_issues.SetColumnWidth(lCol1, 360);
					grd_issues[grd_issues.CurrentRowIndex, grd_issues.CurrentColumnIndex].Value = "Description";

					lCol1++;
					grd_issues.CurrentColumnIndex = lCol1;
					grd_issues.SetColumnWidth(lCol1, 233);
					grd_issues[grd_issues.CurrentRowIndex, grd_issues.CurrentColumnIndex].Value = "Company";

					lCol1++;
					grd_issues.CurrentColumnIndex = lCol1;
					grd_issues.SetColumnWidth(lCol1, 167);
					grd_issues[grd_issues.CurrentRowIndex, grd_issues.CurrentColumnIndex].Value = "Contact";

					lCol1++;
					grd_issues.CurrentColumnIndex = lCol1;
					grd_issues.SetColumnWidth(lCol1, 133);
					grd_issues[grd_issues.CurrentRowIndex, grd_issues.CurrentColumnIndex].Value = "Make/Model/Serial#";

					lCol1++;
					grd_issues.CurrentColumnIndex = lCol1;
					grd_issues.SetColumnWidth(lCol1, 83);
					grd_issues[grd_issues.CurrentRowIndex, grd_issues.CurrentColumnIndex].Value = "Amod ID";


					lCol1++;
					grd_issues.CurrentColumnIndex = lCol1;
					grd_issues.SetColumnWidth(lCol1, 120);
					grd_issues[grd_issues.CurrentRowIndex, grd_issues.CurrentColumnIndex].Value = "Date";


					Application.DoEvents();



					Query = " select  ";
					Query = $"{Query} Issue_Title, Issue_Area, Issue_description, Issue_comp_id, Issue_contact_id, Issue_ac_id, Issue_Journ_id, Issue_date, Issue_amod_id ";
					Query = $"{Query} , amod_make_name, amod_model_name, comp_name, ac_ser_no_full ";
					Query = $"{Query} , contact_first_name, contact_last_name ";
					Query = $"{Query} from Issue_All  ";
					Query = $"{Query} left outer join company with (NOLOCK) on comp_id = Issue_comp_id and comp_journ_id = 0 ";
					Query = $"{Query} left outer join aircraft with (NOLOCK) on ac_id = Issue_ac_id and ac_id = 0 ";
					Query = $"{Query} left outer join aircraft_model with (NOLOCK) on ac_amod_id = amod_id  ";
					Query = $"{Query} left outer join contact with (NOLOCK) on contact_id = Issue_contact_id and contact_journ_id = 0 ";

					if (cbo_account_id.Text.Trim() != "All" && cbo_account_id.Text.Trim() != "No Rep Selected")
					{
						Query = $"{Query}{where_and}  comp_account_id {make_account_rep_answer_string()}";
						where_and = "and";
					}

					if (cbo_multi[0].Text.Trim() != "" && cbo_multi[0].Text.Substring(0, Math.Min(3, cbo_multi[0].Text.Length)).Trim() != "All")
					{
						Query = $"{Query}{where_and}  Issue_Area = '{cbo_multi[0].Text.Trim()}'  ";
						where_and = "and";
					}

					if (cbo_multi[1].Text.Trim() != "" && cbo_multi[1].Text.Substring(0, Math.Min(3, cbo_multi[1].Text.Length)).Trim() != "All")
					{
						Query = $"{Query}{where_and}  Issue_Title = '{cbo_multi[1].Text.Trim()}'  ";
						where_and = "and";
					}



					Query = $"{Query} order by Issue_Title asc ";


					strError = "openrc";

					Application.DoEvents();
					Application.DoEvents();
					JetNetSupport.PInvoke.SafeNative.kernel32.Sleep(50);
					Application.DoEvents();
					snp_UnverifiedCallback = new ADORecordSetHelper();
					snp_UnverifiedCallback.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
					Application.DoEvents();
					Application.DoEvents();
					Application.DoEvents();
					if (!snp_UnverifiedCallback.BOF && !snp_UnverifiedCallback.EOF)
					{


						grd_issues.RowsCount++;
						grd_issues.CurrentRowIndex++;
						snp_UnverifiedCallback.MoveLast();
						snp_UnverifiedCallback.MoveFirst();

						do 
						{ // Loop Until snp_UnverifiedCallback.EOF = True Or Stopped = True

							lCol1 = 0;
							grd_issues.CurrentColumnIndex = lCol1;
							//  grd_issues.CellBackColor = &HC0C0FF
							grd_issues[grd_issues.CurrentRowIndex, grd_issues.CurrentColumnIndex].Value = "";

							grd_issues.CurrentColumnIndex = lCol1;
							grd_issues.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.NoColor)));
							grd_issues[grd_issues.CurrentRowIndex, grd_issues.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_UnverifiedCallback["issue_area"])} ").Trim();

							lCol1++;
							grd_issues.CurrentColumnIndex = lCol1;
							grd_issues.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.NoColor)));
							grd_issues[grd_issues.CurrentRowIndex, grd_issues.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_UnverifiedCallback["issue_title"])} ").Trim();

							lCol1++;
							grd_issues.CurrentColumnIndex = lCol1;
							grd_issues.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.NoColor)));
							grd_issues[grd_issues.CurrentRowIndex, grd_issues.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_UnverifiedCallback["Issue_description"])} ").Trim();

							lCol1++;
							grd_issues.CurrentColumnIndex = lCol1;
							grd_issues.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.NoColor)));

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(snp_UnverifiedCallback["comp_name"]))
							{
								grd_issues[grd_issues.CurrentRowIndex, grd_issues.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_UnverifiedCallback["comp_name"])} ").Trim();
							}

							grd_issues[grd_issues.CurrentRowIndex, grd_issues.CurrentColumnIndex].Value = $"{grd_issues[grd_issues.CurrentRowIndex, grd_issues.CurrentColumnIndex].FormattedValue.ToString()} ({($"{Convert.ToString(snp_UnverifiedCallback["Issue_comp_id"])}) ").Trim()}";


							lCol1++;
							grd_issues.CurrentColumnIndex = lCol1;
							grd_issues.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.NoColor)));
							grd_issues[grd_issues.CurrentRowIndex, grd_issues.CurrentColumnIndex].Value = "";
							if (Convert.ToDouble(snp_UnverifiedCallback["Issue_contact_id"]) > 0)
							{
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(snp_UnverifiedCallback["contact_first_name"]))
								{
									grd_issues[grd_issues.CurrentRowIndex, grd_issues.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_UnverifiedCallback["contact_first_name"])} {Convert.ToString(snp_UnverifiedCallback["contact_last_name"])}").Trim();
								}
								grd_issues[grd_issues.CurrentRowIndex, grd_issues.CurrentColumnIndex].Value = $"{grd_issues[grd_issues.CurrentRowIndex, grd_issues.CurrentColumnIndex].FormattedValue.ToString()} ({($"{Convert.ToString(snp_UnverifiedCallback["Issue_contact_id"])}) ").Trim()}";
							}


							lCol1++;
							grd_issues.CurrentColumnIndex = lCol1;
							grd_issues.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.NoColor)));
							grd_issues[grd_issues.CurrentRowIndex, grd_issues.CurrentColumnIndex].Value = "";
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(snp_UnverifiedCallback["ac_ser_no_full"]))
							{
								grd_issues[grd_issues.CurrentRowIndex, grd_issues.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_UnverifiedCallback["amod_make_name"])} {Convert.ToString(snp_UnverifiedCallback["amod_model_name"])} {Convert.ToString(snp_UnverifiedCallback["ac_ser_no_full"])}").Trim();
							}


							lCol1++;
							grd_issues.CurrentColumnIndex = lCol1;
							grd_issues.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.NoColor)));
							grd_issues[grd_issues.CurrentRowIndex, grd_issues.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_UnverifiedCallback["Issue_date"])} ").Trim();

							grd_issues.set_RowData(grd_issues.RowsCount - 1, Convert.ToInt32(snp_UnverifiedCallback.GetField("Issue_comp_id")));

							lbl_gen[53].Text = (grd_issues.RowsCount - 1).ToString();
							grd_issues.RowsCount++;
							grd_issues.CurrentRowIndex++;

							snp_UnverifiedCallback.MoveNext();
							Application.DoEvents();

						}
						while(!(snp_UnverifiedCallback.EOF || Stopped));


					}
					else
					{
						MessageBox.Show("No Records Found", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					} // If (snp_UnverifiedCallback.BOF = False And snp_UnverifiedCallback.EOF = False) Then

					grd_issues.Redraw = true;

				} // If cmd_refresh(2).Enabled = True Then
			}
			catch (System.Exception excep)
			{

				search_off();
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				strError = $" AR:{($"{cbo_account_id.Text} ").Trim()} cbdate:{txt_Callback_Date.Text} err:{strError} {Information.Err().Number.ToString()} {excep.Message}";
				modAdminCommon.Report_Error($"Fill_Issues_Callback_Grid_Error: {strError}");
			}

		}

		private void Fill_Issues_Callback_Grid_AC()
		{

			string Query = "";
			string strError = "";
			string strAcctRep = "";
			string strAcctRepId = "";
			int TotalCallbacks = 0;
			int lCol1 = 0;
			string strMsg = "";
			System.DateTime dtStartDate = DateTime.FromOADate(0);
			System.DateTime dtEndDate = DateTime.FromOADate(0);
			string where_and = "where";

			try
			{

				lbl_gen[53].Text = "0";

				if (cmd_refresh[2].Enabled)
				{

					modCommon.Start_Activity_Monitor_Message("Issues", ref strMsg, ref dtStartDate, ref dtEndDate);


					grd_issues.ColumnsCount = 7;
					grd_issues.RowsCount = 1;

					grd_issues.Clear();
					Application.DoEvents();

					grd_issues.CurrentRowIndex = 0;

					lCol1 = 0;
					grd_issues.CurrentColumnIndex = lCol1;
					grd_issues.SetColumnWidth(lCol1, 57);
					grd_issues[grd_issues.CurrentRowIndex, grd_issues.CurrentColumnIndex].Value = "Area";

					lCol1++;
					grd_issues.CurrentColumnIndex = lCol1;
					grd_issues.SetColumnWidth(lCol1, 87);
					grd_issues[grd_issues.CurrentRowIndex, grd_issues.CurrentColumnIndex].Value = "Title";

					lCol1++;
					grd_issues.CurrentColumnIndex = lCol1;
					grd_issues.SetColumnWidth(lCol1, 267);
					grd_issues[grd_issues.CurrentRowIndex, grd_issues.CurrentColumnIndex].Value = "Description";

					lCol1++;
					grd_issues.CurrentColumnIndex = lCol1;
					grd_issues.SetColumnWidth(lCol1, 267);
					grd_issues[grd_issues.CurrentRowIndex, grd_issues.CurrentColumnIndex].Value = "Make/Model/Serial#";

					//    lCol1 = lCol1 + 1
					//    grd_issues.Col = lCol1
					//    grd_issues.ColWidth(lCol1) = 1250
					//    grd_issues.Text = "Amod ID"


					lCol1++;
					grd_issues.CurrentColumnIndex = lCol1;
					grd_issues.SetColumnWidth(lCol1, 167);
					grd_issues[grd_issues.CurrentRowIndex, grd_issues.CurrentColumnIndex].Value = "Company";

					lCol1++;
					grd_issues.CurrentColumnIndex = lCol1;
					grd_issues.SetColumnWidth(lCol1, 133);
					grd_issues[grd_issues.CurrentRowIndex, grd_issues.CurrentColumnIndex].Value = "Contact";


					//    lCol1 = lCol1 + 1
					//    grd_issues.Col = lCol1
					//    grd_issues.ColWidth(lCol1) = 1800
					//    grd_issues.Text = "Date"
					//

					Application.DoEvents();



					Query = " select  ";
					Query = $"{Query} Issue_Title, Issue_Area, Issue_description, Issue_comp_id, Issue_contact_id, Issue_ac_id, Issue_Journ_id, Issue_amod_id ";
					Query = $"{Query} , amod_make_name, amod_model_name, company.comp_name, ac_ser_no_full ";
					Query = $"{Query} , contact_first_name, contact_last_name ";
					Query = $"{Query} from issue_aircraft_all  ";
					Query = $"{Query} left outer join company with (NOLOCK) on comp_id = Issue_comp_id and comp_journ_id = 0 ";
					Query = $"{Query} left outer join aircraft with (NOLOCK) on ac_id = Issue_ac_id and ac_journ_id = 0 ";
					Query = $"{Query} left outer join aircraft_model with (NOLOCK) on ac_amod_id = amod_id  ";
					Query = $"{Query} left outer join contact with (NOLOCK) on contact_id = Issue_contact_id and contact_journ_id = 0 ";

					Query = $"{Query} left outer join Aircraft_Reference with (NOLOCK) on cref_ac_id = Issue_ac_id and cref_primary_poc_flag = 'Y' and cref_journ_id = Issue_Journ_id ";
					Query = $"{Query} left outer join company c2 with (NOLOCK) on c2.comp_id = cref_comp_id and c2.comp_journ_id = 0 ";



					if (cbo_account_id.Text.Trim() != "All" && cbo_account_id.Text.Trim() != "No Rep Selected")
					{
						Query = $"{Query}{where_and}  c2.comp_account_id  {make_account_rep_answer_string()}";
						where_and = "and";
					}

					if (cbo_multi[0].Text.Trim() != "" && cbo_multi[1].Text.Trim() != "Aircraft" && cbo_multi[0].Text.Substring(0, Math.Min(3, cbo_multi[0].Text.Length)).Trim() != "All")
					{
						Query = $"{Query}{where_and}  Issue_Area = '{cbo_multi[0].Text.Trim()}'  ";
						where_and = "and";
					}

					if (cbo_multi[1].Text.Trim() != "" && cbo_multi[1].Text.Trim() != "Aircraft" && cbo_multi[1].Text.Substring(0, Math.Min(3, cbo_multi[1].Text.Length)).Trim() != "All")
					{
						Query = $"{Query}{where_and}  Issue_Title = '{cbo_multi[1].Text.Trim()}'  ";
						where_and = "and";
					}



					Query = $"{Query} order by Issue_Title asc ";


					strError = "openrc";

					Application.DoEvents();
					Application.DoEvents();
					JetNetSupport.PInvoke.SafeNative.kernel32.Sleep(50);
					Application.DoEvents();
					snp_UnverifiedCallback = new ADORecordSetHelper();
					snp_UnverifiedCallback.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
					Application.DoEvents();
					Application.DoEvents();
					Application.DoEvents();
					if (!snp_UnverifiedCallback.BOF && !snp_UnverifiedCallback.EOF)
					{


						grd_issues.RowsCount++;
						grd_issues.CurrentRowIndex++;
						snp_UnverifiedCallback.MoveLast();
						snp_UnverifiedCallback.MoveFirst();

						do 
						{ // Loop Until snp_UnverifiedCallback.EOF = True Or Stopped = True

							lCol1 = 0;
							grd_issues.CurrentColumnIndex = lCol1;
							//  grd_issues.CellBackColor = &HC0C0FF
							grd_issues[grd_issues.CurrentRowIndex, grd_issues.CurrentColumnIndex].Value = "";

							grd_issues.CurrentColumnIndex = lCol1;
							grd_issues.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.NoColor)));
							grd_issues[grd_issues.CurrentRowIndex, grd_issues.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_UnverifiedCallback["issue_area"])} ").Trim();

							lCol1++;
							grd_issues.CurrentColumnIndex = lCol1;
							grd_issues.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.NoColor)));
							grd_issues[grd_issues.CurrentRowIndex, grd_issues.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_UnverifiedCallback["issue_title"])} ").Trim();

							lCol1++;
							grd_issues.CurrentColumnIndex = lCol1;
							grd_issues.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.NoColor)));
							grd_issues[grd_issues.CurrentRowIndex, grd_issues.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_UnverifiedCallback["Issue_description"])} ").Trim();


							lCol1++;
							grd_issues.CurrentColumnIndex = lCol1;
							grd_issues.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.NoColor)));
							grd_issues[grd_issues.CurrentRowIndex, grd_issues.CurrentColumnIndex].Value = "";
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(snp_UnverifiedCallback["ac_ser_no_full"]))
							{
								grd_issues[grd_issues.CurrentRowIndex, grd_issues.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_UnverifiedCallback["amod_make_name"])} {Convert.ToString(snp_UnverifiedCallback["amod_model_name"])} {Convert.ToString(snp_UnverifiedCallback["ac_ser_no_full"])}").Trim();
							}



							lCol1++;
							grd_issues.CurrentColumnIndex = lCol1;
							grd_issues.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.NoColor)));

							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(snp_UnverifiedCallback["comp_name"]))
							{
								grd_issues[grd_issues.CurrentRowIndex, grd_issues.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_UnverifiedCallback["comp_name"])} ").Trim();
							}

							grd_issues[grd_issues.CurrentRowIndex, grd_issues.CurrentColumnIndex].Value = $"{grd_issues[grd_issues.CurrentRowIndex, grd_issues.CurrentColumnIndex].FormattedValue.ToString()} ({($"{Convert.ToString(snp_UnverifiedCallback["Issue_comp_id"])}) ").Trim()}";


							lCol1++;
							grd_issues.CurrentColumnIndex = lCol1;
							grd_issues.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.NoColor)));
							grd_issues[grd_issues.CurrentRowIndex, grd_issues.CurrentColumnIndex].Value = "";
							if (Convert.ToDouble(snp_UnverifiedCallback["Issue_contact_id"]) > 0)
							{
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(snp_UnverifiedCallback["contact_first_name"]))
								{
									grd_issues[grd_issues.CurrentRowIndex, grd_issues.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_UnverifiedCallback["contact_first_name"])} {Convert.ToString(snp_UnverifiedCallback["contact_last_name"])}").Trim();
								}
								grd_issues[grd_issues.CurrentRowIndex, grd_issues.CurrentColumnIndex].Value = $"{grd_issues[grd_issues.CurrentRowIndex, grd_issues.CurrentColumnIndex].FormattedValue.ToString()} ({($"{Convert.ToString(snp_UnverifiedCallback["Issue_contact_id"])}) ").Trim()}";
							}




							//        lCol1 = lCol1 + 1
							//        grd_issues.Col = lCol1
							//        grd_issues.CellBackColor = NoColor
							//        grd_issues.Text = Trim(snp_UnverifiedCallback!Issue_date & " ")
							//
							grd_issues.set_RowData(grd_issues.RowsCount - 1, Convert.ToInt32(snp_UnverifiedCallback.GetField("Issue_ac_id")));

							lbl_gen[53].Text = (grd_issues.RowsCount - 1).ToString();
							grd_issues.RowsCount++;
							grd_issues.CurrentRowIndex++;

							snp_UnverifiedCallback.MoveNext();
							Application.DoEvents();

						}
						while(!(snp_UnverifiedCallback.EOF || Stopped));


					}
					else
					{
						MessageBox.Show("No Records Found", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					} // If (snp_UnverifiedCallback.BOF = False And snp_UnverifiedCallback.EOF = False) Then

					grd_issues.Redraw = true;

				} // If cmd_refresh(2).Enabled = True Then
			}
			catch (System.Exception excep)
			{

				search_off();
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				strError = $" AR:{($"{cbo_account_id.Text} ").Trim()} cbdate:{txt_Callback_Date.Text} err:{strError} {Information.Err().Number.ToString()} {excep.Message}";
				modAdminCommon.Report_Error($"Fill_Issues_Callback_Grid_AC_Error: {strError}");
			}

		}







		private void Fill_Salesforce_Callback_Grid()
		{

			string Query = "";
			string strError = "";
			string strAcctRep = "";
			string strAcctRepId = "";
			int TotalCallbacks = 0;
			int lCol1 = 0;
			string strMsg = "";
			System.DateTime dtStartDate = DateTime.FromOADate(0);
			System.DateTime dtEndDate = DateTime.FromOADate(0);
			string where_and = "where";
			string temp_string = "";


			try
			{

				Application.DoEvents();
				this.Cursor = Cursors.WaitCursor;
				Application.DoEvents();
				Application.DoEvents();
				Application.DoEvents();

				if (cmd_refresh[2].Enabled)
				{


					Stopped = false;

					grd_salesforce.ColumnsCount = 11;
					grd_salesforce.RowsCount = 1;


					grd_salesforce.Clear();
					Application.DoEvents();

					grd_salesforce.CurrentRowIndex = 0;

					lCol1 = 0;
					grd_salesforce.CurrentColumnIndex = lCol1;
					grd_salesforce.SetColumnWidth(lCol1, 117);
					grd_salesforce[grd_salesforce.CurrentRowIndex, grd_salesforce.CurrentColumnIndex].Value = "Date";

					lCol1++;
					grd_salesforce.CurrentColumnIndex = lCol1;
					grd_salesforce.SetColumnWidth(lCol1, 114);
					grd_salesforce[grd_salesforce.CurrentRowIndex, grd_salesforce.CurrentColumnIndex].Value = "Change";

					lCol1++;
					grd_salesforce.CurrentColumnIndex = lCol1;
					grd_salesforce.SetColumnWidth(lCol1, 247);
					grd_salesforce[grd_salesforce.CurrentRowIndex, grd_salesforce.CurrentColumnIndex].Value = "Subject";

					lCol1++;
					grd_salesforce.CurrentColumnIndex = lCol1;
					grd_salesforce.SetColumnWidth(lCol1, 247);
					grd_salesforce[grd_salesforce.CurrentRowIndex, grd_salesforce.CurrentColumnIndex].Value = "Descrip";


					lCol1++;
					grd_salesforce.CurrentColumnIndex = lCol1;
					grd_salesforce.SetColumnWidth(lCol1, 147);
					grd_salesforce[grd_salesforce.CurrentRowIndex, grd_salesforce.CurrentColumnIndex].Value = "Company";

					lCol1++;
					grd_salesforce.CurrentColumnIndex = lCol1;
					grd_salesforce.SetColumnWidth(lCol1, 80);
					grd_salesforce[grd_salesforce.CurrentRowIndex, grd_salesforce.CurrentColumnIndex].Value = "Location";

					lCol1++;
					grd_salesforce.CurrentColumnIndex = lCol1;
					grd_salesforce.SetColumnWidth(lCol1, 80);
					grd_salesforce[grd_salesforce.CurrentRowIndex, grd_salesforce.CurrentColumnIndex].Value = "Contact";

					lCol1++;
					grd_salesforce.CurrentColumnIndex = lCol1;
					grd_salesforce.SetColumnWidth(lCol1, 80);
					grd_salesforce[grd_salesforce.CurrentRowIndex, grd_salesforce.CurrentColumnIndex].Value = "Title";


					lCol1++;
					grd_salesforce.CurrentColumnIndex = lCol1;
					grd_salesforce.SetColumnWidth(lCol1, 80);
					grd_salesforce[grd_salesforce.CurrentRowIndex, grd_salesforce.CurrentColumnIndex].Value = "User";



					Application.DoEvents();
					strAcctRep = cbo_account_id.Text.Substring(0, Math.Min(2, cbo_account_id.Text.Length)).ToUpper();
					strAcctRepId = cbo_account_id.Text.ToUpper();

					strError = "query";
					//aey 6/24/04 added prefixes to query field names

					Query = " select  journ_Date, changetype, journ_subject, journ_description, journ_comp_id , journ_user_id, ";
					Query = $"{Query} view_SalesAPI_Changes.comp_name, view_SalesAPI_Changes.comp_city, view_SalesAPI_Changes.comp_state, journ_contact_id, contact_first_name, contact_last_name, ";
					Query = $"{Query} contact_title , user_first_name, user_last_name ";
					Query = $"{Query} from view_SalesAPI_Changes ";
					Query = $"{Query} left outer join company with (NOLOCK) on comp_journ_id = 0 and comp_id = journ_comp_id ";

					if (cbo_multi[2].Text.Trim() != "" && cbo_multi[2].Text.Trim() != "All")
					{
						Query = $"{Query}{where_and} changetype = '{cbo_multi[2].Text.Trim()}' ";
						where_and = "and";
					}

					if (cbo_account_id.Text.Trim() != "All" && cbo_account_id.Text.Trim() != "No Rep Selected")
					{
						Query = $"{Query}{where_and}  comp_account_id {make_account_rep_answer_string()}";
						where_and = "and";
					}

					Query = $"{Query} order by journ_Date desc ";

					modAdminCommon.Record_Event("HB Unverified", $"Unverified - Selected AcctRep: {strAcctRepId}");

					strError = "openrc";

					snp_UnverifiedCallback = new ADORecordSetHelper();
					snp_UnverifiedCallback.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!snp_UnverifiedCallback.BOF && !snp_UnverifiedCallback.EOF)
					{

						grd_salesforce.Redraw = false;

						grd_salesforce.RowsCount++;
						grd_salesforce.CurrentRowIndex++;
						snp_UnverifiedCallback.MoveLast();
						snp_UnverifiedCallback.MoveFirst();

						pnl_Exclusives.Visible = true;
						cmdStop.Visible = true;
						Stopped = false;



						if (grd_salesforce.RowsCount > 1)
						{
							grd_salesforce.FixedRows = 1;
							grd_salesforce.FixedColumns = 0;
						}


						do 
						{ // Loop Until snp_UnverifiedCallback.EOF = True Or Stopped = True

							lCol1 = 0;
							grd_salesforce.CurrentColumnIndex = lCol1;
							//  grd_salesforce.CellBackColor = &HC0C0FF
							grd_salesforce[grd_salesforce.CurrentRowIndex, grd_salesforce.CurrentColumnIndex].Value = "";

							//       journ_date , changetype, journ_subject, journ_comp_id, journ_user_id, ""
							//  Query = Query & " comp_name, comp_city, comp_state, journ_contact_id, contact_first_name, contact_last_name, "
							//  Query = Query & " contact_title , user_first_name, user_last_name"

							grd_salesforce.CurrentColumnIndex = lCol1;
							grd_salesforce.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.NoColor)));
							grd_salesforce[grd_salesforce.CurrentRowIndex, grd_salesforce.CurrentColumnIndex].Value = StringsHelper.Replace(StringsHelper.Replace(StringsHelper.Replace(StringsHelper.Replace(StringsHelper.Replace(StringsHelper.Replace(($"{Convert.ToString(snp_UnverifiedCallback["journ_date"])} ").Trim(), "2022", "22", 1, -1, CompareMethod.Binary), "2023", "23", 1, -1, CompareMethod.Binary), "2024", "24", 1, -1, CompareMethod.Binary), "2025", "25", 1, -1, CompareMethod.Binary), "2026", "26", 1, -1, CompareMethod.Binary), "2027", "27", 1, -1, CompareMethod.Binary);

							lCol1++;
							grd_salesforce.CurrentColumnIndex = lCol1;
							grd_salesforce.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.NoColor)));
							grd_salesforce[grd_salesforce.CurrentRowIndex, grd_salesforce.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_UnverifiedCallback["changetype"])} ").Trim();

							lCol1++;
							grd_salesforce.CurrentColumnIndex = lCol1;
							grd_salesforce.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.NoColor)));

							temp_string = "";
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(snp_UnverifiedCallback["journ_subject"]))
							{
								temp_string = ($"{Convert.ToString(snp_UnverifiedCallback["journ_subject"])} ").Trim();
								temp_string = StringsHelper.Replace(temp_string, "Updated", "Upd", 1, -1, CompareMethod.Binary);
								temp_string = StringsHelper.Replace(temp_string, "from Salesforce", "from SF", 1, -1, CompareMethod.Binary);
								temp_string = StringsHelper.Replace(temp_string, "", "", 1, -1, CompareMethod.Binary);
								temp_string = StringsHelper.Replace(temp_string, "", "", 1, -1, CompareMethod.Binary);
							}
							grd_salesforce[grd_salesforce.CurrentRowIndex, grd_salesforce.CurrentColumnIndex].Value = temp_string;


							lCol1++;
							grd_salesforce.CurrentColumnIndex = lCol1;
							grd_salesforce.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.NoColor)));

							temp_string = "";
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(snp_UnverifiedCallback["journ_description"]))
							{
								temp_string = ($"{Convert.ToString(snp_UnverifiedCallback["journ_description"])} ").Trim();
								temp_string = StringsHelper.Replace(temp_string, "", "", 1, -1, CompareMethod.Binary);
								temp_string = StringsHelper.Replace(temp_string, "", "", 1, -1, CompareMethod.Binary);
								temp_string = StringsHelper.Replace(temp_string, "", "", 1, -1, CompareMethod.Binary);
								temp_string = StringsHelper.Replace(temp_string, "", "", 1, -1, CompareMethod.Binary);
							}
							grd_salesforce[grd_salesforce.CurrentRowIndex, grd_salesforce.CurrentColumnIndex].Value = temp_string;

							lCol1++;
							grd_salesforce.CurrentColumnIndex = lCol1;
							grd_salesforce.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.NoColor)));
							grd_salesforce[grd_salesforce.CurrentRowIndex, grd_salesforce.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_UnverifiedCallback["comp_name"])} ").Trim();

							grd_salesforce[grd_salesforce.CurrentRowIndex, grd_salesforce.CurrentColumnIndex].Value = $"{grd_salesforce[grd_salesforce.CurrentRowIndex, grd_salesforce.CurrentColumnIndex].FormattedValue.ToString()} ({Convert.ToString(snp_UnverifiedCallback["journ_comp_id"])})";



							lCol1++;
							grd_salesforce.CurrentColumnIndex = lCol1;
							grd_salesforce.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.NoColor)));
							grd_salesforce[grd_salesforce.CurrentRowIndex, grd_salesforce.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_UnverifiedCallback["Comp_city"])} ").Trim();

							lCol1++;
							grd_salesforce.CurrentColumnIndex = lCol1;
							grd_salesforce.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.NoColor)));
							grd_salesforce.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
							//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
							if (!Convert.IsDBNull(snp_UnverifiedCallback["contact_first_name"]) && !Convert.IsDBNull(snp_UnverifiedCallback["contact_last_name"]))
							{
								grd_salesforce[grd_salesforce.CurrentRowIndex, grd_salesforce.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_UnverifiedCallback["contact_first_name"])} {Convert.ToString(snp_UnverifiedCallback["contact_last_name"])}").Trim();
							}


							lCol1++;
							grd_salesforce.CurrentColumnIndex = lCol1;
							grd_salesforce.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.NoColor)));
							grd_salesforce[grd_salesforce.CurrentRowIndex, grd_salesforce.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_UnverifiedCallback["contact_title"])} ").Trim();


							lCol1++;
							grd_salesforce.CurrentColumnIndex = lCol1;
							grd_salesforce.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.NoColor)));
							grd_salesforce[grd_salesforce.CurrentRowIndex, grd_salesforce.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_UnverifiedCallback["user_first_name"])} {Convert.ToString(snp_UnverifiedCallback["user_last_name"])}").Trim();



							grd_salesforce.set_RowData(grd_salesforce.RowsCount - 1, Convert.ToInt32(snp_UnverifiedCallback.GetField("journ_comp_id")));

							lbl_gen[55].Text = grd_salesforce.RowsCount.ToString();
							TotalCallbacks++;
							grd_salesforce.RowsCount++;
							grd_salesforce.CurrentRowIndex++;
							txt_TotExclusive.Text = StringsHelper.Format(TotalCallbacks, "#,##0");

							if (TotalCallbacks == 18)
							{
								grd_salesforce.Visible = true;
								grd_salesforce.Redraw = true;
								Application.DoEvents();
								grd_salesforce.Redraw = false;
							}

							snp_UnverifiedCallback.MoveNext();
							Application.DoEvents();

						}
						while(!(snp_UnverifiedCallback.EOF || Stopped));

						grd_salesforce.Visible = true;
						grd_salesforce.Redraw = true;

						strError = "totals";


					}
					else
					{
						strError = "none selected";
						txt_TotExclusive.Text = "0";
						pnl_Exclusives.Visible = true;
						grd_salesforce.Visible = false;
						pnl_Exclusives.Visible = false;
						lbl_exclusivesdue.Text = "No Exclusives Due Selected .......";
					} // If (snp_UnverifiedCallback.BOF = False And snp_UnverifiedCallback.EOF = False) Then

					search_off();

					grd_salesforce.Redraw = true;
					this.Cursor = CursorHelper.CursorDefault;


				} // If cmd_refresh(2).Enabled = True Then
			}
			catch (System.Exception excep)
			{

				search_off();
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				strError = $" AR:{($"{cbo_account_id.Text} ").Trim()} cbdate:{txt_Callback_Date.Text} err:{strError} {Information.Err().Number.ToString()} {excep.Message}";
				modAdminCommon.Report_Error($"Fill_Salesforce_Callback_Grid_Error: {strError}");
			}

		}





		public void Fill_Aircraft_Expired_Leases_Grid()
		{
			//----------------------------------------------------------------------------------------------
			//Function used to fill the Aircraft Expired Leases Grid
			//----------------------------------------------------------------------------------------------
			// RTW - MODIFIED QUERIES TO NOT USE CLASS C HELICOPTER STUFF

			string Query = "";
			string cellcolor = "";
			int Total_Leased_Aircraft = 0;
			ADORecordSetHelper snp_ExpLease = new ADORecordSetHelper();
			string strProductType = "";
			string strAcctRep = "";
			string strAcctRepId = "";

			string strMsg = "";
			System.DateTime dtStartDate = DateTime.FromOADate(0);
			System.DateTime dtEndDate = DateTime.FromOADate(0);

			try
			{

				modCommon.Start_Activity_Monitor_Message("Callback Expired Leases", ref strMsg, ref dtStartDate, ref dtEndDate);

				string tempRefParam = "Expired Leases";
				search_on(ref tempRefParam);
				cellcolor = modAdminCommon.HeadingColor;
				pnl_lstcompany.Visible = false;
				cmd_refresh[0].Visible = false;

				txt_total_leased_aircraft.Text = "";

				LeaseAction = "Good";
				SSTabHelper.SetSelectedIndex(tab_callback, 5);
				FindId = "ExpiredLeases";
				lbl_expiredleases.Text = " ";

				grd_expired_leases.Clear();
				grd_expired_leases.Visible = false;
				Application.DoEvents();
				grd_expired_leases.Redraw = false;

				grd_expired_leases.ColumnsCount = 12;
				grd_expired_leases.RowsCount = 1;

				grd_expired_leases.CurrentRowIndex = 0;

				grd_expired_leases.CurrentColumnIndex = 0;
				grd_expired_leases.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
				grd_expired_leases.SetColumnWidth(0, 187);
				grd_expired_leases[grd_expired_leases.CurrentRowIndex, grd_expired_leases.CurrentColumnIndex].Value = "Company";
				grd_expired_leases.CurrentColumnIndex = 1;
				grd_expired_leases.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
				grd_expired_leases.SetColumnWidth(1, 67);
				grd_expired_leases[grd_expired_leases.CurrentRowIndex, grd_expired_leases.CurrentColumnIndex].Value = "City";
				grd_expired_leases.CurrentColumnIndex = 2;
				grd_expired_leases.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
				grd_expired_leases.SetColumnWidth(2, 53);
				grd_expired_leases[grd_expired_leases.CurrentRowIndex, grd_expired_leases.CurrentColumnIndex].Value = "State";
				grd_expired_leases.CurrentColumnIndex = 3;
				grd_expired_leases.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
				grd_expired_leases.SetColumnWidth(3, 80);
				grd_expired_leases[grd_expired_leases.CurrentRowIndex, grd_expired_leases.CurrentColumnIndex].Value = "Country";



				grd_expired_leases.CurrentColumnIndex = 4;
				grd_expired_leases.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
				grd_expired_leases.SetColumnWidth(4, 187);
				grd_expired_leases[grd_expired_leases.CurrentRowIndex, grd_expired_leases.CurrentColumnIndex].Value = "Make/Model ";

				grd_expired_leases.CurrentColumnIndex = 5;
				grd_expired_leases.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
				grd_expired_leases.SetColumnWidth(5, 67);
				grd_expired_leases[grd_expired_leases.CurrentRowIndex, grd_expired_leases.CurrentColumnIndex].Value = "Serial #";


				grd_expired_leases.CurrentColumnIndex = 6;
				grd_expired_leases.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
				grd_expired_leases.SetColumnWidth(6, 67);
				grd_expired_leases[grd_expired_leases.CurrentRowIndex, grd_expired_leases.CurrentColumnIndex].Value = "Reg #";


				grd_expired_leases.CurrentColumnIndex = 7;
				grd_expired_leases.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
				grd_expired_leases.SetColumnWidth(7, 0);
				grd_expired_leases[grd_expired_leases.CurrentRowIndex, grd_expired_leases.CurrentColumnIndex].Value = "Type";


				grd_expired_leases.CurrentColumnIndex = 8;
				grd_expired_leases.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
				grd_expired_leases.SetColumnWidth(8, 57);
				grd_expired_leases[grd_expired_leases.CurrentRowIndex, grd_expired_leases.CurrentColumnIndex].Value = "Term";
				grd_expired_leases.CurrentColumnIndex = 9;
				grd_expired_leases.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
				grd_expired_leases.SetColumnWidth(9, 100);
				grd_expired_leases[grd_expired_leases.CurrentRowIndex, grd_expired_leases.CurrentColumnIndex].Value = "Exp. Date";
				grd_expired_leases.CurrentColumnIndex = 10;
				grd_expired_leases.CellAlignment = DataGridViewContentAlignment.MiddleCenter;
				grd_expired_leases.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
				grd_expired_leases.SetColumnWidth(10, 0);
				grd_expired_leases[grd_expired_leases.CurrentRowIndex, grd_expired_leases.CurrentColumnIndex].Value = "%";
				grd_expired_leases.CurrentColumnIndex = 11;
				grd_expired_leases.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
				grd_expired_leases.SetColumnWidth(11, 480);
				grd_expired_leases[grd_expired_leases.CurrentRowIndex, grd_expired_leases.CurrentColumnIndex].Value = "Notes";

				Stopped = false;

				Total_Leased_Aircraft = 0;

				LeaseAction = "Bad";
				//aey 6/24/04 added prefixes to query field names

				Query = "SELECT AL1.aclease_type, ";
				Query = $"{Query}AL1.aclease_term, ";
				Query = $"{Query}AL1.aclease_expiration_date, ";
				Query = $"{Query}AL1.aclease_percentage, ";
				Query = $"{Query}AL1.aclease_note, ";
				Query = $"{Query}A1.ac_ser_no, A1.ac_reg_no, ";
				Query = $"{Query}A1.ac_id, ";
				Query = $"{Query}C1.comp_id, ";
				Query = $"{Query}C1.comp_name, ";
				Query = $"{Query}C1.comp_city, ";
				Query = $"{Query}C1.comp_state, ";
				Query = $"{Query}C1.comp_country, ";
				Query = $"{Query}C1.comp_journ_id, ";
				Query = $"{Query}C1.comp_name, ";
				Query = $"{Query}A1.ac_amod_id ";

				Query = $"{Query}FROM Aircraft_Lease AS AL1 WITH (NOLOCK) ";
				Query = $"{Query}INNER JOIN Aircraft AS A1 WITH(NOLOCK) ON A1.ac_id = AL1.aclease_ac_id AND A1.ac_journ_id = 0  ";
				Query = $"{Query}INNER JOIN Aircraft_Model AS AM1 WITH (NOLOCK) ON AM1.amod_id = A1.ac_amod_id ";
				Query = $"{Query}INNER JOIN Aircraft_Reference AS AR1 WITH (NOLOCK) ON AR1.cref_ac_id = A1.ac_id  AND AR1.cref_journ_id = A1.ac_journ_id ";
				Query = $"{Query}INNER JOIN Company AS C1 WITH (NOLOCK) ON C1.comp_id = AR1.cref_comp_id AND C1.comp_journ_id = AR1.cref_journ_id ";

				if (chk_Unknown.CheckState == CheckState.Checked)
				{
					Query = $"{Query}WHERE (AL1.aclease_expiration_date <='{txt_Callback_Date.Text}' OR AL1.aclease_expiration_date IS NULL) ";
				}
				else
				{
					Query = $"{Query}WHERE (AL1.aclease_expiration_date <='{txt_Callback_Date.Text}') ";
				}

				Query = $"{Query}AND (AL1.aclease_expired <> 'Y') ";
				Query = $"{Query}AND (AR1.cref_primary_poc_flag IN ('X','Y')) ";
				Query = $"{Query}AND  C1.comp_account_id {make_account_rep_answer_string()}";

				// added MSW - 9/9/20
				if (cbo_Timezones.Text != "All")
				{
					if (cbo_Timezones.Text == "International")
					{
						Query = $"{Query}AND ((C1.comp_timezone is NULL) or (comp_timezone=''))";
					}
					else
					{
						Query = $"{Query}AND (C1.comp_timezone='{cbo_Timezones.Text}') ";
					}
				}


				strProductType = cmbProductType.Text.Substring(0, Math.Min(1, cmbProductType.Text.Length));
				strAcctRep = cbo_account_id.Text.Substring(0, Math.Min(2, cbo_account_id.Text.Length)).ToUpper();
				strAcctRepId = cbo_account_id.Text.ToUpper();


				switch(strProductType)
				{
					case "A" :  // Business and Helicopter 
						Query = $"{Query}AND (A1.ac_product_business_flag = 'Y' OR A1.ac_product_helicopter_flag = 'Y') "; 
						 
						break;
					case "B" :  // Business Only 
						Query = $"{Query}AND (A1.ac_product_business_flag = 'Y') "; 
						 
						break;
					case "H" :  // Helicopter Only 
						Query = $"{Query}AND (A1.ac_product_helicopter_flag = 'Y') "; 
						 
						break;
					case "C" :  // Commercial Only 
						Query = $"{Query}AND (A1.ac_product_commercial_flag = 'Y') "; 
						 
						break;
					case "Q" :  // JNiQ Eligible 
						Query = $"{Query}{modCommon.Return_JNiQ_Eligible_Query(strAcctRep, Query)}"; 
						 
						break;
					case "N" :  // Non-JNiQ Eligible 
						Query = $"{Query}{modCommon.Return_Non_JNiQ_Eligible_Query()}"; 
						 
						break;
					case "P" :  // AirBP 
						Query = $"{Query}AND (A1.ac_product_airbp_flag = 'Y') "; 
						 
						break;
					case "L" :  // All Aircraft 
						 
						break;
				} // Case strProductType

				Query = $"{Query}ORDER BY AL1.aclease_expiration_date ";

				cellcolor = modAdminCommon.NoColor;

				modAdminCommon.Record_Event("Monitor Activity", $"Expired Leases - Selected AcctRep: {strAcctRepId}");
				// Record_Event "HB Usage", "Expired Leases - Selected AcctRep: " & strAcctRepId

				//Set snp_ExpLease = LOCAL_DB.OpenRecordset(Query, dbOpenSnapshot, dbSQLPassThrough)
				snp_ExpLease.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!snp_ExpLease.BOF && !snp_ExpLease.EOF)
				{

					cmd_refresh[0].Visible = true;

					grd_expired_leases.RowsCount++;
					grd_expired_leases.CurrentRowIndex++;
					cmdStop.Visible = true;
					snp_ExpLease.MoveFirst();

					while(!snp_ExpLease.EOF)
					{
						Application.DoEvents();

						if (Stopped)
						{
							Stopped = false;
							break;
						}

						lbl_Message.Text = " ";
						//fill the grid

						grd_expired_leases.CurrentColumnIndex = 0;
						grd_expired_leases.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
						grd_expired_leases[grd_expired_leases.CurrentRowIndex, grd_expired_leases.CurrentColumnIndex].Value = snp_ExpLease.GetField("comp_name");
						grd_expired_leases.CurrentColumnIndex = 1;
						grd_expired_leases.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snp_ExpLease["Comp_city"]))
						{
							grd_expired_leases[grd_expired_leases.CurrentRowIndex, grd_expired_leases.CurrentColumnIndex].Value = snp_ExpLease.GetField("Comp_city");
						}
						else
						{
							grd_expired_leases[grd_expired_leases.CurrentRowIndex, grd_expired_leases.CurrentColumnIndex].Value = "";
						}

						grd_expired_leases.CurrentColumnIndex = 2;
						grd_expired_leases.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snp_ExpLease["comp_state"]))
						{
							grd_expired_leases[grd_expired_leases.CurrentRowIndex, grd_expired_leases.CurrentColumnIndex].Value = snp_ExpLease.GetField("comp_state");
						}
						else
						{
							grd_expired_leases[grd_expired_leases.CurrentRowIndex, grd_expired_leases.CurrentColumnIndex].Value = "";
						}


						grd_expired_leases.CurrentColumnIndex = 3;
						grd_expired_leases.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snp_ExpLease["Comp_country"]))
						{
							grd_expired_leases[grd_expired_leases.CurrentRowIndex, grd_expired_leases.CurrentColumnIndex].Value = snp_ExpLease.GetField("Comp_country");
						}
						else
						{
							grd_expired_leases[grd_expired_leases.CurrentRowIndex, grd_expired_leases.CurrentColumnIndex].Value = "";
						}


						grd_expired_leases.CurrentColumnIndex = 4;
						grd_expired_leases.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
						grd_expired_leases[grd_expired_leases.CurrentRowIndex, grd_expired_leases.CurrentColumnIndex].Value = get_make_model(Convert.ToInt32(snp_ExpLease["ac_amod_id"]));
						grd_expired_leases.CurrentColumnIndex = 5;
						grd_expired_leases.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						grd_expired_leases.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
						grd_expired_leases[grd_expired_leases.CurrentRowIndex, grd_expired_leases.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_ExpLease["ac_ser_no"])} ").Trim();

						grd_expired_leases.CurrentColumnIndex = 6;
						grd_expired_leases.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						grd_expired_leases.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snp_ExpLease["ac_reg_no"]))
						{
							grd_expired_leases[grd_expired_leases.CurrentRowIndex, grd_expired_leases.CurrentColumnIndex].Value = snp_ExpLease.GetField("ac_reg_no");
						}
						else
						{
							grd_expired_leases[grd_expired_leases.CurrentRowIndex, grd_expired_leases.CurrentColumnIndex].Value = "";
						}

						grd_expired_leases.CurrentColumnIndex = 7;
						grd_expired_leases.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						grd_expired_leases.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
						grd_expired_leases[grd_expired_leases.CurrentRowIndex, grd_expired_leases.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_ExpLease["aclease_type"])} ").Trim();
						grd_expired_leases.CurrentColumnIndex = 8;
						grd_expired_leases.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						grd_expired_leases.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
						grd_expired_leases[grd_expired_leases.CurrentRowIndex, grd_expired_leases.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_ExpLease["aclease_term"])} ").Trim();
						grd_expired_leases.CurrentColumnIndex = 9;
						grd_expired_leases.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
						grd_expired_leases[grd_expired_leases.CurrentRowIndex, grd_expired_leases.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_ExpLease["aclease_expiration_date"])} ").Trim();
						grd_expired_leases.CurrentColumnIndex = 10;
						grd_expired_leases.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
						grd_expired_leases[grd_expired_leases.CurrentRowIndex, grd_expired_leases.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_ExpLease["aclease_percentage"])} ").Trim();
						grd_expired_leases.CurrentColumnIndex = 11;
						grd_expired_leases.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
						grd_expired_leases[grd_expired_leases.CurrentRowIndex, grd_expired_leases.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_ExpLease["aclease_note"])} ").Trim();

						grd_expired_leases.set_RowData(grd_expired_leases.CurrentRowIndex, Convert.ToInt32(($"{Convert.ToString(snp_ExpLease["comp_id"])}").Trim()));
						//UPGRADE_ISSUE: (2064) MSHierarchicalFlexGridLib.MSHFlexGrid property grd_expired_leases.BandData was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						grd_expired_leases.setBandData(Convert.ToInt32(Double.Parse(($"{Convert.ToString(snp_ExpLease["ac_id"])}").Trim())), grd_expired_leases.CurrentRowIndex);


						Total_Leased_Aircraft++;

						if (Total_Leased_Aircraft == 22)
						{
							grd_expired_leases.Visible = true;
							grd_expired_leases.Redraw = true;
							Application.DoEvents();
							grd_expired_leases.Redraw = false;
						}

						snp_ExpLease.MoveNext();
						grd_expired_leases.RowsCount++;
						grd_expired_leases.CurrentRowIndex++;

						txt_total_leased_aircraft.Text = Total_Leased_Aircraft.ToString();
					};

					grd_expired_leases.RowsCount--;

				}
				else
				{
					lbl_expiredleases.Text = "No Expired Leases Selected.";
					grd_expired_leases.Visible = false;
				} // If (snp_ExpLease.BOF = False And snp_ExpLease.EOF = False) Then

				if (grd_expired_leases.RowsCount > 1)
				{
					grd_expired_leases.FixedRows = 1;
				}

				snp_ExpLease.Close();
				snp_ExpLease = null;

				strMsg = $"AcctRep: {cbo_account_id.Text}";
				strMsg = $"{strMsg} Product: {cmbProductType.Text}";
				strMsg = $"{strMsg} Callback Date: {txt_Callback_Date.Text}";

				if (chk_Unknown.CheckState == CheckState.Checked)
				{
					strMsg = $"{strMsg} [x] Inc Unk Exp Date ";
				}

				if (bLog)
				{

					modCommon.End_Activity_Monitor_Message("Callback Expired Leases", ref strMsg, dtStartDate, ref dtEndDate, 0, 0, 0, 0, 0);

					frm_UserHistory.DefInstance.Refresh_User_History_Grids("Callback");

				}

				grd_expired_leases.Visible = true;
				grd_expired_leases.Redraw = true;
				cmd_refresh[0].Enabled = true;

				search_off();
			}
			catch (System.Exception excep)
			{

				snp_ExpLease.Close();

				modAdminCommon.Report_Error($"Fill_Aircraft_Expired_Leases_Grid_Error: {excep.Message}");
				search_off();

				return;
			}

		}

		public void Show_Callback_Company_Info()
		{
			int tmpCol = 0;
			bool has_phone = false;

			try
			{

				lstCompany.Items.Clear();

				string strLock = "";
				if (grd_Callbacks.RowsCount > 0)
				{

					if (HasBoundCallback)
					{ //aey 11/17/04
						//company_id is in column 0 if it is a bound grid
						grd_Callbacks.CurrentColumnIndex = 0;
						grd_Callbacks.set_RowData(grd_Callbacks.CurrentRowIndex, Convert.ToInt32(grd_Callbacks[grd_Callbacks.CurrentRowIndex, grd_Callbacks.CurrentColumnIndex].FormattedValue.ToString()));
						grd_Callbacks.CurrentColumnIndex = tmpCol;
					}

					RememberExclusiveCompanyId = grd_Callbacks.get_RowData(grd_Callbacks.CurrentRowIndex);
					modCommon.Build_Company_NameAddress(lstCompany, RememberExclusiveCompanyId, 0, "", false, ref has_phone);

					cmd_contacts_phone.Visible = false;
					if (!has_phone)
					{
						cmd_contacts_phone.Visible = true;
					}
					lstCompany.SetItemData(0, RememberExclusiveCompanyId);

					cmdConfirmExclusive.Enabled = true; //aey 4/21/2006
					cmdConfirmExclusive.Text = "&Confirm Company";

					strLock = modCommon.CompanyLocked(RememberExclusiveCompanyId, 0).ToUpper();

					if (strLock != ("False").ToUpper() || (strLock == modAdminCommon.gbl_User_ID.ToUpper()))
					{
						cmdConfirmExclusive.Enabled = false;
						cmdConfirmExclusive.Text = "Confirm Company Locked";
					}
				}
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Show_Callback_Company_Info_Error: ({Information.Err().Number.ToString()}) {excep.Message}[GR:{grd_Callbacks.CurrentRowIndex.ToString()} COMPID:{RememberExclusiveCompanyId.ToString()}]");
				return;
			}

		}

		public void Select_Company_Color_Confirm()
		{

			//----------------------------------------------------------------------------------------------
			//Function used to select company color confirm records
			//----------------------------------------------------------------------------------------------

			int lRow1 = 0;
			int lCompId = 0;

			frm_Company o_Local_Show_Company = null;

			try
			{

				this.Cursor = Cursors.WaitCursor;

				lRow1 = grd_CompConfirm.CurrentRowIndex;

				if (lRow1 > 0)
				{

					lCompId = grd_CompConfirm.get_RowData(lRow1);

					if (lCompId > 0)
					{

						// cleanup any contact forms and open a clean form
						modCommon.Unload_Form("frm_Company");

						o_Local_Show_Company = frm_Company.CreateInstance();
						//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//VB.Global.Load(o_Local_Show_Company);
						o_Local_Show_Company.Form_Initialize();
						o_Local_Show_Company.StartForm = modGlobalVars.tStart_Form;
						o_Local_Show_Company.Reference_CompanyID = lCompId;
						o_Local_Show_Company.Reference_CompanyJID = 0;
						o_Local_Show_Company.Show();
						//UPGRADE_WARNING: (2065) Form method o_Local_Show_Company.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
						o_Local_Show_Company.BringToFront();
						//UPGRADE_WARNING: (2065) Form event Form.Activated has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
						o_Local_Show_Company.Form_Activated(null, new EventArgs());

						this.Cursor = CursorHelper.CursorDefault;

					} // If lCompId > 0 Then

				} // If lRow1 > 0 Then
			}
			catch
			{

				modAdminCommon.Report_Error("Select_Company_Color_Confirm_Error");
				search_off();
			}

		} // Select_Company_Color_Confirm

		public void Show_Company_Color_Confirm_Info()
		{

			//******************************************************************************************
			//* Note: VBC id'd the following unreferenced items and handled them as described:         *
			//*                                                                                        *
			//* Local Variables (Removed)                                                              *
			//*  Query                                                                                 *
			//******************************************************************************************

			//----------------------------------------------------------------------------------------------
			//Function used to display Company Color Confirm Info
			//----------------------------------------------------------------------------------------------

			int lCompId = 0;
			string strLock = "";
			int lRow1 = grd_CompConfirm.CurrentRowIndex;

			if (lRow1 > 0)
			{

				lCompId = grd_CompConfirm.get_RowData(lRow1);

				if (lCompId > 0)
				{

					lstCompany.Items.Clear();

					RememberExclusiveCompanyId = lCompId;
					modCommon.Build_Company_NameAddress(this.lstCompany, lCompId, 0);
					lstCompany.SetItemData(0, lCompId);

					cmdConfirmExclusive.Enabled = true; //aey 4/21/2006
					cmdConfirmExclusive.Text = "&Confirm Company";

					strLock = modCommon.CompanyLocked(lCompId, 0);

					if ((strLock == "False") || (strLock == Convert.ToString(modAdminCommon.snp_User["user_id"])))
					{
					}
					else
					{
						cmdConfirmExclusive.Enabled = false;
						cmdConfirmExclusive.Text = "Confirm Company Locked";
					}

				} // If lCompId > 0 Then

			} // If lRow1 > 0 Then

		} // Show_Company_Color_Confirm_Info

		public void Fill_Hot_Items_Grid(int temp_index = 0)
		{

			//******************************************************************************************

			//Function used to fill the Hot Items Grid
			//----------------------------------------------------------------------------------------------

			bool run_new = false;




			string Query = "";
			int tmpcount = 0;
			string strProductType = "";
			string strAcctRep = "";
			string strAcctRepId = "";
			int lTotRec = 0;

			string cellcolor = modAdminCommon.HeadingColor;



			string strStartDate = "";
			string strEndDate = "";
			int lRow = 0;
			int lTimeOut = 0;

			string strMsg = "";
			System.DateTime dtStartDate = DateTime.FromOADate(0);
			System.DateTime dtEndDate = DateTime.FromOADate(0);

			try
			{

				modCommon.Start_Activity_Monitor_Message("Callback Hot Box", ref strMsg, ref dtStartDate, ref dtEndDate);

				lbl_gen[37].Text = "No Hot Items Loaded.";
				Application.DoEvents();
				cmd_refresh[1].Enabled = false;

				string tempRefParam = "Hot Items";
				search_on(ref tempRefParam);
				pnl_lstcompany.Visible = false;
				cmd_refresh[1].Enabled = false;

				FindId = "HotItemColor";

				if (!opHBAircraftYacht[0].Checked && !opHBAircraftYacht[1].Checked)
				{
					opHBAircraftYacht[0].Enabled = false;
					opHBAircraftYacht[0].Checked = true;
					opHBAircraftYacht[0].Enabled = true;
				}

				lbl_Hot_Items.Text = "  ";


				run_new = true;
				if (run_new)
				{

					cmdStop.Visible = true;
					Stopped = false;

					setup_HotBox_Columns(grd_Hot_Items, cellcolor);
					cellcolor = modAdminCommon.NoColor;
					modCommon.fill_research_action_list(0, 0, null, grd_Hot_Items, ($"{cbo_account_id.Text} ").Trim(), temp_index, ref tmpcount, chk_action_list[9].CheckState != CheckState.Unchecked, chk_action_list[10].CheckState != CheckState.Unchecked, cbo_Timezones.Text, iHOTBoxSortCol);
					grd_Hot_Items.Redraw = true;
					grd_Hot_Items.Refresh();

					cmdStop.Visible = false;
					Stopped = false;

					lbl_gen[37].Text = $"Loaded {tmpcount.ToString()} Hot Items";
				}
				else
				{

					setup_HotBox_Columns(grd_Hot_Items, cellcolor);


					cellcolor = modAdminCommon.NoColor;
					Stopped = false;

					strStartDate = txt_ListStartDate.Text;
					strEndDate = txt_Callback_Date.Text;

					Query = "SELECT DISTINCT ";
					Query = $"{Query}hbs_airframe_type_code As AirframeType, ";
					Query = $"{Query}hbs_type_code As MakeType, ";
					Query = $"{Query}hbs_make_name As Make, ";
					Query = $"{Query}hbs_model_name As Model, ";
					Query = $"{Query}hbs_ser_no_full As SerNbr, ";
					Query = $"{Query}hbs_reg_no As RegNbr, ";
					Query = $"{Query}hbs_entry_date As EntryDate, ";
					Query = $"{Query}hbs_comp_name As Company, ";
					Query = $"{Query}hbs_comp_id As CompId, ";
					Query = $"{Query}hbs_comp_account_id As ACCTRep, ";
					Query = $"{Query}hbs_yacht_brand_name As BrandName, ";
					Query = $"{Query}hbs_yacht_model_name As ModelName, ";
					Query = $"{Query}hbs_yacht_name As YachtName, ";
					Query = $"{Query}hbs_journ_id As JournId, ";
					Query = $"{Query}hbs_ac_id As ACId, ";
					Query = $"{Query}hbs_yacht_id As YTId, ";
					Query = $"{Query}hbs_status As HBStatus, ";
					Query = $"{Query}hbs_subject As Subject, ";
					Query = $"{Query}hbs_description As Description ";

					Query = $"{Query}FROM Hot_Box_Summary WITH (NOLOCK) ";

					Query = $"{Query}LEFT OUTER JOIN Company AS C1 WITH (NOLOCK) ON comp_id = hbs_comp_id AND comp_journ_id = 0 ";

					if (strStartDate != "" && strEndDate != "")
					{
						Query = $"{Query}WHERE (hbs_entry_date BETWEEN '{strStartDate}' AND '{strEndDate}') ";
					}
					else
					{
						Query = $"{Query}WHERE (CAST(hbs_entry_date AS DATE) <= '{strEndDate}') ";
					}

					if (chk_HotItemsAcctRep.CheckState == CheckState.Checked)
					{
						if (cbo_account_id.Text.Trim() != "No Rep Selected")
						{
							Query = $"{Query}AND hbs_comp_account_id  {make_account_rep_answer_string()}";
						}
					}

					// 08/14/2019 - By David D. Cruger
					// Added Files for Ordered Docs and Sending Docs
					if (chk_action_list[chkViewDocsOrdered].CheckState == CheckState.Checked && chk_action_list[chkViewDocsSending].CheckState == CheckState.Unchecked)
					{
						Query = $"{Query}AND (hbs_subject LIKE 'Ordered%') ";
					}
					else if (chk_action_list[chkViewDocsSending].CheckState == CheckState.Unchecked)
					{  // if its not both ' msw - 8/3/2020
						Query = $"{Query}AND (hbs_subject NOT LIKE 'Ordered%') ";
					}

					if (chk_action_list[chkViewDocsOrdered].CheckState == CheckState.Unchecked && chk_action_list[chkViewDocsSending].CheckState == CheckState.Checked)
					{
						Query = $"{Query}AND (hbs_subject LIKE 'Sending%') ";
					}
					else if (chk_action_list[chkViewDocsSending].CheckState == CheckState.Unchecked)
					{  // if its not both - 8/3/2020- MSW
						Query = $"{Query}AND (hbs_subject NOT LIKE 'Sending%') ";
					}

					if (chk_action_list[chkViewDocsOrdered].CheckState == CheckState.Checked && chk_action_list[chkViewDocsSending].CheckState == CheckState.Checked)
					{
						Query = $"{Query}AND (hbs_subject LIKE 'Ordered%' OR hbs_subject LIKE 'Sending%') ";
					}



					Query = $"{Query}AND (hbs_status = 'P') ";

					if (opHBAircraftYacht[0].Checked)
					{
						Query = $"{Query}AND (hbs_ac_id > 0) ";
					}
					if (opHBAircraftYacht[1].Checked)
					{
						Query = $"{Query}AND (hbs_yacht_id > 0) ";
						if (iHOTBoxSortCol < 3)
						{
							iHOTBoxSortCol = 6;
						}
					}

					// added MSW - 9/9/20
					if (cbo_Timezones.Text != "All")
					{
						if (cbo_Timezones.Text == "International")
						{
							Query = $"{Query}AND ((C1.comp_timezone is NULL) or (comp_timezone=''))";
						}
						else
						{
							Query = $"{Query}AND (C1.comp_timezone='{cbo_Timezones.Text}') ";
						}
					}

					strProductType = cmbProductType.Text.Substring(0, Math.Min(1, cmbProductType.Text.Length)).ToUpper();
					strAcctRep = cbo_account_id.Text.Substring(0, Math.Min(2, cbo_account_id.Text.Length)).ToUpper();
					strAcctRepId = cbo_account_id.Text.ToUpper();

					switch(strProductType)
					{
						case "L" :  // All 
							 
							break;
						case "A" :  // Business and Helicopters' 
							Query = $"{Query}AND (hbs_ac_product_business_flag = 'Y' OR hbs_ac_product_helicopter_flag = 'Y') "; 
							 
							break;
						case "B" :  // Business 
							Query = $"{Query}AND (hbs_ac_product_business_flag = 'Y') "; 
							 
							break;
						case "H" :  // Helicopter 
							Query = $"{Query}AND (hbs_ac_product_helicopter_flag = 'Y') "; 
							 
							break;
						case "C" :  // Commercial 
							Query = $"{Query}AND (hbs_ac_product_commercial_Flag = 'Y') "; 
							 
							break;
						case "Q" :  // JNiQ Eligible 
							 
							Query = $"{Query}{modCommon.Return_JNiQ_Eligible_Query(strAcctRep, Query)}"; 
							 
							break;
						case "N" :  // Non-JNiQ Eligible 
							 
							MessageBox.Show($"Query Not Supported - JNiQ - Non-Eligible{Environment.NewLine}Defaulting To ALL", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error | MessageBoxIcon.Information); 
							//Query = Query & Return_Non_JNiQ_Eligible_Query() 
							 
							break;
					} // Select Case strProductType

					// 03/17/2015 - By David D. Cruger
					// Added Sorting Options

					switch(iHOTBoxSortCol)
					{
						case 0 :  // Make/Model 
							Query = $"{Query}ORDER BY hbs_make_name, hbs_model_name, hbs_ser_no_full "; 
							break;
						case 1 :  // SerNbr 
							Query = $"{Query}ORDER BY hbs_ser_no_full, hbs_make_name, hbs_model_name "; 
							break;
						case 2 :  // RegNbr 
							Query = $"{Query}ORDER BY hbs_reg_no, hbs_make_name, hbs_model_name, hbs_ser_no_full "; 
							break;
						case 3 :  // Date 
							Query = $"{Query}ORDER BY hbs_entry_date, hbs_make_name, hbs_model_name, hbs_ser_no_full "; 
							break;
						case 4 :  // Company 
							Query = $"{Query}ORDER BY hbs_comp_name, hbs_make_name, hbs_model_name, hbs_ser_no_full "; 
							break;
						case 5 :  // Subject 
							Query = $"{Query}ORDER BY hbs_subject, hbs_make_name, hbs_model_name, hbs_ser_no_full "; 
							break;
						case 6 :  // Yacht Brand/Model 
							Query = $"{Query}ORDER BY hbs_yacht_brand_name, hbs_yacht_model_name, hbs_yacht_name "; 
							break;
						case 7 :  // Yacht Name 
							Query = $"{Query}ORDER BY hbs_yacht_name, hbs_yacht_brand_name, hbs_yacht_model_name "; 
							break;
					} // Case iHOTBoxSortCol

					tmpcount = 0;

					modAdminCommon.Record_Event("Monitor Activity", $"Hot Box Items - Selected AcctRep: {strAcctRepId}");
					// Record_Event "HB Usage", "Hot Box Items - Selected AcctRep: " & strAcctRepId

					snp_HotItems = new ADORecordSetHelper();
					snp_HotItems.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!snp_HotItems.BOF && !snp_HotItems.EOF)
					{

						cmdStop.Visible = true;

						pnl_Hot_Items.Visible = true;
						grd_Hot_Items.Visible = true;
						lTotRec = snp_HotItems.RecordCount;
						grd_Hot_Items.Redraw = false;

						lRow = 0;

						do 
						{ // Loop Until snp_HotItems.EOF = True Or Stopped = True

							lRow++;
							grd_Hot_Items.RowsCount = lRow + 1;
							grd_Hot_Items.CurrentRowIndex = lRow;

							// fill grid
							tmpcount++;
							lbl_gen[37].Text = $"Loading Hot Items ...{StringsHelper.Format(tmpcount, "#,##0")} of {StringsHelper.Format(lTotRec, "#,##0")}";


							//--------------------------------------------------------------------------------------------------------
							// #0          #1       #2    #3    #4       #5       #6          #7          #8       #9    #10   #11
							// Make/Model  Serial#  Reg#  Date  Company  Subject  Brand/Model Yacht Name  JournId  ACId  YTId  CompId


							modCommon.add_middle_hot_box(grd_Hot_Items, lRow, cellcolor, Convert.ToString(snp_HotItems["make"]), Convert.ToString(snp_HotItems["model"]), ($"{Convert.ToString(snp_HotItems["SerNbr"])}").Trim(), ($"{Convert.ToString(snp_HotItems["RegNbr"])}").Trim(), Convert.ToDateTime(snp_HotItems["EntryDate"]).ToString("d"), ($"{Convert.ToString(snp_HotItems["Company"])}").Trim(), ($"{Convert.ToString(snp_HotItems["Subject"])}").Trim(), ($"{Convert.ToString(snp_HotItems["Subject"])}").Trim(), ($"{Convert.ToString(snp_HotItems["modelname"])} ").Trim(), ($"{Convert.ToString(snp_HotItems["YachtName"])}").Trim(), Convert.ToInt32(Double.Parse(Convert.ToString(snp_HotItems["JournID"]))), Convert.ToInt32(Double.Parse(Convert.ToString(snp_HotItems["ACID"]))), Convert.ToInt32(Double.Parse(Convert.ToString(snp_HotItems["YTId"]))), Convert.ToInt32(Double.Parse(Convert.ToString(snp_HotItems["CompID"]))));

							if (tmpcount == 20)
							{
								grd_Hot_Items.Redraw = true;
								grd_Hot_Items.Refresh();
								Application.DoEvents();
								grd_Hot_Items.Redraw = false;
							}

							snp_HotItems.MoveNext();
							Application.DoEvents();

							if (grd_Hot_Items.CurrentRowIndex == grd_Hot_Items.RowsCount - 1)
							{
								grd_Hot_Items.RowsCount++;
							}

						}
						while(!(snp_HotItems.EOF || Stopped));

						grd_Hot_Items.Redraw = true;
						grd_Hot_Items.Refresh();

						cmdStop.Visible = false;
						Stopped = false;

						lbl_gen[37].Text = $"Loaded {tmpcount.ToString()} Hot Items";
						grd_Hot_Items.RowsCount--;

					}
					else
					{
						pnl_Hot_Items.Visible = false;
						lbl_Hot_Items.Text = "No Hot Items Selected.";
					} // If (snp_HotItems.BOF = False And snp_HotItems.EOF = False) Then

					strMsg = $"AcctRep: {cbo_account_id.Text}";
					strMsg = $"{strMsg} Product: {cmbProductType.Text}";

					if (strStartDate != "")
					{
						strMsg = $"{strMsg} Start Date: {strStartDate}";
					}
					if (strEndDate != "")
					{
						strMsg = $"{strMsg} End Date: {strEndDate}";
					}

					if (chk_HotItemsAcctRep.CheckState == CheckState.Checked)
					{
						strMsg = $"{strMsg} [x] Only Current AcctRep";
					}

					if (bLog)
					{

						modCommon.End_Activity_Monitor_Message("Callback Hot Box", ref strMsg, dtStartDate, ref dtEndDate, 0, 0, 0, 0, 0);

						// 08/14/2019 - By David D. Cruger
						// Not sure why this was here.
						// This made the Hot Box List Load Twice
						//frm_UserHistory.Refresh_User_History_Grids "Callback"

					}


				} // end if from new bloack

				grd_Hot_Items.FixedRows = 1;
				grd_Hot_Items.FixedColumns = 0;

				search_off();
				HadHourglass = false;
				cmd_refresh[1].Enabled = true;
			}
			catch
			{

				search_off();
				HadHourglass = false;
				modAdminCommon.Report_Error("Fill_Hot_Items_Grid_Error: ");
			}

		}

		public void Show_Hot_Items_Confirm_Info()
		{




			int lRow1 = grd_Hot_Items.MouseRow;
			int lCol1 = grd_Hot_Items.MouseCol;

			txt_next_confirm_date.Text = DateTimeHelper.ToString(DateTime.Parse(modAdminCommon.DateToday).AddDays(Double.Parse(($"{modAdminCommon.gbl_ColorConfirmDays.ToString()}").Trim())));

			//--------------------------------------------------------------------------------------------------------
			// #0          #1       #2    #3    #4       #5       #6          #7          #8       #9    #10   #11
			// Make/Model  Serial#  Reg#  Date  Company  Subject  Brand/Model Yacht Name  JournId  ACId  YTId  CompId

			int lJournId = Convert.ToInt32(Double.Parse(Convert.ToString(grd_Hot_Items[lRow1, 8].Value)));
			int lACId = Convert.ToInt32(Double.Parse(Convert.ToString(grd_Hot_Items[lRow1, 9].Value)));
			int lYTId = Convert.ToInt32(Double.Parse(Convert.ToString(grd_Hot_Items[lRow1, 10].Value)));
			int lCompId = Convert.ToInt32(Double.Parse(Convert.ToString(grd_Hot_Items[lRow1, 11].Value)));

			RememberExclusiveCompanyId = lCompId;
			modCommon.Build_Company_NameAddress(this.lstCompany, lCompId, 0);
			lstCompany.SetItemData(0, lCompId);

			cmdConfirmExclusive.Enabled = true; //aey 4/21/2006
			cmdConfirmExclusive.Text = "&Confirm Company";

			string strLocked = modCommon.CompanyLocked(RememberExclusiveCompanyId, 0);

			if ((strLocked == "False") || (strLocked == Convert.ToString(modAdminCommon.snp_User["user_id"])))
			{
			}
			else
			{
				//If (CompanyLocked(RememberExclusiveCompanyId, 0) = snp_User!user_id) Then
				cmdConfirmExclusive.Enabled = false;
				cmdConfirmExclusive.Text = "Confirm Company Locked";
			}

		} // Show_Hot_Items_Confirm_Info

		public void Show_New_Assign_Confirm_Info()
		{
			//Dim Query As String
			//
			int i = 0;

			try
			{
				//   lstCompany.Clear

				string strLock = "";
				if (grd_NewAssignments.CurrentRowIndex > 0)
				{

					RememberExclusiveCompanyId = grd_NewAssignments.get_RowData(grd_NewAssignments.CurrentRowIndex);
					modCommon.Build_Company_NameAddress(this.lstCompany, grd_NewAssignments.get_RowData(grd_NewAssignments.CurrentRowIndex), 0);
					lstCompany.SetItemData(0, grd_NewAssignments.get_RowData(grd_NewAssignments.CurrentRowIndex));
					cmd_ClearReassign.Visible = true;

					cmdConfirmExclusive.Enabled = true; //aey 4/21/2006
					cmdConfirmExclusive.Text = "&Confirm Company";
					strLock = modCommon.CompanyLocked(RememberExclusiveCompanyId, 0);

					if ((strLock == "False") || (strLock == Convert.ToString(modAdminCommon.snp_User["user_id"])))
					{
					}
					else
					{
						cmdConfirmExclusive.Enabled = false;
						cmdConfirmExclusive.Text = "Confirm Company Locked";
					}

				}
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Show_New_Assign_Confirm_Info_Error: {Information.Err().Number.ToString()} {excep.Message}");
			}

		}

		public void Show_Expired_Leases_Info()
		{
			//----------------------------------------------------------------------------------------------
			//Function used to display Company Color Confirm Info
			//----------------------------------------------------------------------------------------------
			//Dim Query As String
			//
			int i = 0;

			//snp_ExpLease.MoveFirst
			//For I = 1 To grd_expired_leases.Row - 1
			//   snp_ExpLease.MoveNext
			//Next I
			//If LeaseAction = "Good" Then
			RememberExclusiveCompanyId = grd_expired_leases.get_RowData(grd_expired_leases.CurrentRowIndex);
			modCommon.Build_Company_NameAddress(this.lstCompany, grd_expired_leases.get_RowData(grd_expired_leases.CurrentRowIndex), 0);
			lstCompany.SetItemData(0, grd_expired_leases.get_RowData(grd_expired_leases.CurrentRowIndex));

			cmdConfirmExclusive.Enabled = true; //aey 4/21/2006
			cmdConfirmExclusive.Text = "&Confirm Company";
			string strLocked = modCommon.CompanyLocked(RememberExclusiveCompanyId, 0);
			if ((strLocked == "False") || (strLocked == Convert.ToString(modAdminCommon.snp_User["user_id"])))
			{
			}
			else
			{

				// If (CompanyLocked(RememberExclusiveCompanyId, 0) = snp_User!user_id) Then
				cmdConfirmExclusive.Enabled = false;
				cmdConfirmExclusive.Text = "Confirm Company Locked";
			}


			//End If
		}

		public void Show_Fractional_Company_Info()
		{
			//Dim Query As String
			//
			snpFractional.MoveFirst();
			int tempForEndVar = grdFractional.CurrentRowIndex - 1;
			for (int i = 0; i <= tempForEndVar; i++)
			{
				snpFractional.MoveNext();
			}

			RememberExclusiveCompanyId = Convert.ToInt32(snpFractional["comp_id"]);
			modCommon.Build_Company_NameAddress(this.lstCompany, Convert.ToInt32(snpFractional["comp_id"]), Convert.ToInt32(snpFractional["comp_journ_id"]));
			lstCompany.SetItemData(0, Convert.ToInt32(snpFractional["comp_id"]));

			cmdConfirmExclusive.Enabled = true; //aey 4/21/2006
			cmdConfirmExclusive.Text = "&Confirm Company";
			string strLock = modCommon.CompanyLocked(RememberExclusiveCompanyId, 0);

			if ((strLock == "False") || (strLock == Convert.ToString(modAdminCommon.snp_User["user_id"])))
			{
			}
			else
			{
				cmdConfirmExclusive.Enabled = false;
				cmdConfirmExclusive.Text = "Confirm Company Locked";
			}


		}

		public void Select_Fractional_Owner()
		{
			//----------------------------------------------------------------------------------------------
			//Function used to select fractional owners
			//----------------------------------------------------------------------------------------------
			try
			{

				frm_Company o_Local_Show_Company = null;

				this.Cursor = Cursors.WaitCursor;

				if (grdFractional.CurrentRowIndex > -1)
				{
					snpFractional.MoveFirst();
					int tempForEndVar = grdFractional.CurrentRowIndex - 1;
					for (int i = 0; i <= tempForEndVar; i++)
					{
						snpFractional.MoveNext();
					}

					// cleanup any contact forms and open a clean form
					modCommon.Unload_Form("frm_Company");

					o_Local_Show_Company = frm_Company.CreateInstance();
					//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//VB.Global.Load(o_Local_Show_Company);
					o_Local_Show_Company.Form_Initialize();
					o_Local_Show_Company.StartForm = modGlobalVars.tStart_Form;
					o_Local_Show_Company.Reference_CompanyID = Convert.ToInt32(snpFractional["Comp_id"]);
					o_Local_Show_Company.Reference_CompanyJID = 0;
					o_Local_Show_Company.Show();
					//UPGRADE_WARNING: (2065) Form method o_Local_Show_Company.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
					o_Local_Show_Company.BringToFront();
					//UPGRADE_WARNING: (2065) Form event Form.Activated has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
					o_Local_Show_Company.Form_Activated(null, new EventArgs());

					this.Cursor = CursorHelper.CursorDefault;

				}
			}
			catch
			{

				modAdminCommon.Report_Error("Select_Fractional_Owner_Error: ");
				search_off();
				return;
			}

		}

		public void ShowPrimaryCompanyInfo()
		{
			ADORecordSetHelper snp_PrimaryCompanyInfo = new ADORecordSetHelper(); //aey 6/18/04


			lst_primary.Items.Clear();

			if (grd_Exclusives.CurrentRowIndex > 0)
			{
				snp_ExclusiveCallback.MoveFirst();
				int tempForEndVar = grd_Exclusives.CurrentRowIndex - 1;
				for (int i = 1; i <= tempForEndVar; i++)
				{
					snp_ExclusiveCallback.MoveNext();
				}
			}

			string Query = "SELECT cref_comp_id, actype_name, cref_journ_id ";
			Query = $"{Query}FROM Aircraft_Reference WITH(NOLOCK), Aircraft_Contact_Type ";
			Query = $"{Query}WHERE ";
			Query = $"{Query}cref_ac_id={($"{Convert.ToString(snp_ExclusiveCallback["ac_id"])} ").Trim()}";
			Query = $"{Query} and cref_journ_id=0 ";
			Query = $"{Query} and (cref_contact_type = actype_code) ";
			Query = $"{Query} and cref_primary_poc_flag='Y'";

			snp_PrimaryCompanyInfo.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

			string strLock = "";
			if (!(snp_PrimaryCompanyInfo.BOF && snp_PrimaryCompanyInfo.EOF))
			{
				snp_PrimaryCompanyInfo.MoveLast();
				snp_PrimaryCompanyInfo.MoveFirst();
				pnl_primary.Visible = true;
				lbl_actype.Text = Convert.ToString(snp_PrimaryCompanyInfo["actype_name"]).Trim();
				RememberExclusiveCompanyId = Convert.ToInt32(snp_PrimaryCompanyInfo["cref_comp_id"]);
				modCommon.Build_Company_NameAddress(this.lst_primary, Convert.ToInt32(snp_PrimaryCompanyInfo["cref_comp_id"]), Convert.ToInt32(snp_PrimaryCompanyInfo["cref_journ_id"]));
				lst_primary.SetItemData(0, Convert.ToInt32(snp_PrimaryCompanyInfo["cref_comp_id"]));

				cmdConfirmExclusive.Enabled = true; //aey 4/21/2006
				cmdConfirmExclusive.Text = "&Confirm Company";
				strLock = modCommon.CompanyLocked(RememberExclusiveCompanyId, 0);

				if ((strLock == "False") || (strLock == Convert.ToString(modAdminCommon.snp_User["user_id"])))
				{
				}
				else
				{
					cmdConfirmExclusive.Enabled = false;
					cmdConfirmExclusive.Text = "Confirm Company Locked";
				}

			}
			else
			{
				pnl_primary.Visible = false;

			}

			snp_PrimaryCompanyInfo.Close();

		}

		public void search_on(ref string inMessage, int lTotRec = 0)
		{

			try
			{

				this.Cursor = Cursors.WaitCursor;
				inMessage = $"Selecting {inMessage.Trim()} Data ......";
				pnl_Wait.Visible = true;
				//UPGRADE_ISSUE: (2064) Threed.SSPanel property pnl_Wait.Caption was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				pnl_Wait.setCaption(inMessage.Trim());
				lblTotRecordFound.Visible = false;
				if (lTotRec > 0)
				{
					lblTotRecordFound.Text = $"Total Records Found: {StringsHelper.Format(lTotRec, "#,##0")}";
					lblTotRecordFound.Visible = true;
				}
				pnl_Wait.Refresh();
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, inMessage, Color.Blue);
				cmdStop.Visible = false;
				tab_callback.Enabled = false;
				Application.DoEvents();
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Record_Error("Callbacks (frm_ActionList)", $"Search_On_Error: {Information.Err().Number.ToString()} - {excep.Message}");
			}

		}

		public void search_off()
		{

			// display panel while search is being performed
			HadHourglass = false;
			this.Cursor = CursorHelper.CursorDefault;
			pnl_Wait.Visible = false;
			//UPGRADE_ISSUE: (2064) Threed.SSPanel property pnl_Wait.Caption was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			pnl_Wait.setCaption("");
			pnl_Wait.Refresh();
			tab_callback.Enabled = true;
			modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
			Application.DoEvents();

			if (mvHasFocus)
			{
				mvHasFocus = false;
			}

		}

		public void Fill_Fractional_Owners_Pending_Sale_Grid()
		{
			//******************************************************************************************
			//* Note: VBC id'd the following unreferenced items and handled them as described:         *
			//*                                                                                        *
			//* Local Variables (Removed)                                                              *
			//*  TotalAircraft                                                                         *
			//******************************************************************************************

			//----------------------------------------------------------------------------------------------
			//Function used to fill the Fractional Grid
			//----------------------------------------------------------------------------------------------

			try
			{

				double TotalCompCallBacks = 0;

				string tempRefParam = "Fractional Owners Pending Sale";
				search_on(ref tempRefParam);

				string Query = "";
				string cellcolor = "";

				cellcolor = modAdminCommon.NoColor;
				FindId = "Fractional Pending";
				SSTabHelper.SetSelectedIndex(tab_callback, 6);
				TotalCompCallBacks = 0;
				txt_Total_Comp_Callbacks.Text = "";
				Stopped = false;

				grdFractional.Clear();

				grdFractional.ColumnsCount = 8;
				grdFractional.RowsCount = 1;

				grdFractional.CurrentRowIndex = 0;
				grdFractional.CurrentColumnIndex = 0;
				lbl_fract_col5.Text = "Make";
				lbl_fract_col6.Text = "Model";
				lbl_fract_col7.Text = "Ser#";
				lbl_fract_col8.Text = "Percent";

				grdFractional.SetColumnWidth(0, 60);

				grdFractional.SetColumnWidth(1, 267);
				grdFractional.SetColumnWidth(2, 167);
				grdFractional.SetColumnWidth(3, 33);
				grdFractional.SetColumnWidth(4, 87);
				grdFractional.SetColumnWidth(5, 40);
				grdFractional.SetColumnWidth(6, 53);
				grdFractional.SetColumnWidth(7, 33);
				//select fractional owners pending sale transactions
				// Query = "select j.journ_date,a.ac_id,a.ac_journ_id,a.ac_ser_no_full,m.amod_make_name,m.amod_model_name,c.comp_id,comp_name,comp_city,comp_state,journ_subject,cref_owner_percent "
				//   Query = Query & "From Journal as J WITH(NOLOCK), Aircraft as A, Aircraft_Reference as R, Company as C, Aircraft_Model as M "
				//   Query = Query & "Where "
				//   Query = Query & "r.cref_contact_type='91' "
				//   Query = Query & "and (c.comp_id = r.cref_comp_id And c.comp_journ_id = r.cref_journ_id) " ' join company and reference table
				//   Query = Query & "and (r.cref_ac_id=a.ac_id and r.cref_journ_id=a.ac_journ_id) "   '  join aircraft and reference table
				//   Query = Query & "and (j.journ_ac_id=a.ac_id and j.journ_id=a.ac_journ_id) "   '  join journal to aircraft
				//   Query = Query & "and journ_subcategory_code='FSPEND' "
				//   Query = Query & "and a.ac_amod_id=m.amod_id "

				//aey 6/16/04 where re-ordered
				Query = "select j.journ_date,a.ac_id,a.ac_journ_id,a.ac_ser_no_full,m.amod_make_name,m.amod_model_name,c.comp_id,comp_name,comp_city,comp_state,journ_subject,cref_owner_percent ";
				Query = $"{Query}From Journal as J WITH(NOLOCK), Aircraft as A, Aircraft_Reference as R, Company as C, Aircraft_Model as M ";
				Query = $"{Query}Where ";
				Query = $"{Query}r.cref_contact_type='91' ";
				Query = $"{Query}and (c.comp_id = r.cref_comp_id And c.comp_journ_id = r.cref_journ_id) "; // join company and reference table
				Query = $"{Query}and (r.cref_ac_id=a.ac_id and r.cref_journ_id=a.ac_journ_id) "; //  join aircraft and reference table
				Query = $"{Query}and (j.journ_ac_id=a.ac_id and j.journ_id=a.ac_journ_id) "; //  join journal to aircraft
				Query = $"{Query}and journ_subcategory_code='FSPEND' ";
				Query = $"{Query}and a.ac_amod_id=m.amod_id ";
				if (cmbProductType.Text.StartsWith("L", StringComparison.Ordinal))
				{ //aey 10/17/05
				}
				else if (cmbProductType.Text.StartsWith("A", StringComparison.Ordinal))
				{  //aey 10/17/05
					Query = $"{Query}AND a.ac_use_code <> 'C'  ";
					Query = $"{Query}AND (m.amod_airframe_type_code = 'F' or (m.amod_airframe_type_code = 'R' AND m.amod_class_code='A'))  ";
					Query = $"{Query}and c.comp_id not in(select distinct c2.comp_id ";
					Query = $"{Query}From Journal as J2 WITH(NOLOCK), Aircraft as A2, Aircraft_Reference as R2, Company as C2 ";
					Query = $"{Query}Where r2.cref_contact_type='91' ";
					Query = $"{Query}and (c2.comp_id = r2.cref_comp_id And c2.comp_journ_id = r2.cref_journ_id) ";
					Query = $"{Query}and (r2.cref_ac_id=a2.ac_id and r2.cref_journ_id=a2.ac_journ_id) ";
					Query = $"{Query}and (j2.journ_ac_id=a2.ac_id and j2.journ_id=a2.ac_journ_id) ";
					Query = $"{Query}and j2.journ_subcategory_code='FSPEND' ";
					Query = $"{Query}and a2.ac_use_code = 'C' ) ";

				}
				else if (cmbProductType.Text.StartsWith("B", StringComparison.Ordinal))
				{ 
					Query = $"{Query}AND m.amod_airframe_type_code = 'F' ";
				}
				else if (cmbProductType.Text.StartsWith("H", StringComparison.Ordinal))
				{ 
					Query = $"{Query}AND m.amod_airframe_type_code = 'R' AND m.amod_class_code='A'  ";
					Query = $"{Query}and c.comp_id not in(select distinct c2.comp_id ";
					Query = $"{Query}From Journal as J2 WITH(NOLOCK), Aircraft as A2, Aircraft_Reference as R2, Company as C2, Aircraft_Model as M2 ";
					Query = $"{Query}Where r2.cref_contact_type='91' ";
					Query = $"{Query}and (c2.comp_id = r2.cref_comp_id And c2.comp_journ_id = r2.cref_journ_id) ";
					Query = $"{Query}and (r2.cref_ac_id=a2.ac_id and r2.cref_journ_id=a2.ac_journ_id) ";
					Query = $"{Query}and (j2.journ_ac_id=a2.ac_id and j2.journ_id=a2.ac_journ_id) ";
					Query = $"{Query}and j2.journ_subcategory_code='FSPEND' ";
					Query = $"{Query}and a2.ac_amod_id=m2.amod_id AND m2.amod_airframe_type_code = 'F') ";
				}
				else if (cmbProductType.Text.StartsWith("C", StringComparison.Ordinal))
				{ 
					Query = $"{Query}AND a.ac_use_code='C'  ";
					Query = $"{Query}and c.comp_id not in(select distinct c2.comp_id ";
					Query = $"{Query}From Journal as J2 WITH(NOLOCK), Aircraft as A2, Aircraft_Reference as R2, Company as C2 ";
					Query = $"{Query}Where r2.cref_contact_type='91' ";
					Query = $"{Query}and (c2.comp_id = r2.cref_comp_id And c2.comp_journ_id = r2.cref_journ_id) ";
					Query = $"{Query}and (r2.cref_ac_id=a2.ac_id and r2.cref_journ_id=a2.ac_journ_id) ";
					Query = $"{Query}and (j2.journ_ac_id=a2.ac_id and j2.journ_id=a2.ac_journ_id) ";
					Query = $"{Query}and j2.journ_subcategory_code='FSPEND' ";
					Query = $"{Query}and a2.ac_use_code <>'C' ) ";
				}

				Query = $"{Query}order by j.journ_date,c.comp_name ";

				//MsgBox ("Here - " & Query)

				//Set snp_FractionsPending = LOCAL_DB.OpenRecordset(Query, dbOpenSnapshot, dbSQLPassThrough)
				snp_FractionsPending = new ADORecordSetHelper();

				snp_FractionsPending.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_FractionsPending.BOF && snp_FractionsPending.EOF))
				{
					pnl_fractional_display.Visible = true;
					snp_FractionsPending.MoveLast();
					snp_FractionsPending.MoveFirst();
					cmdStop.Visible = true;


					while(!snp_FractionsPending.EOF)
					{
						if (Stopped)
						{
							Stopped = false;
							break;
						}

						//fill grid

						grdFractional.CurrentColumnIndex = 0;
						grdFractional.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
						grdFractional[grdFractional.CurrentRowIndex, grdFractional.CurrentColumnIndex].Value = Convert.ToDateTime(snp_FractionsPending["journ_date"]).ToString("d");
						grdFractional.CurrentColumnIndex = 1;
						grdFractional.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						grdFractional.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
						grdFractional[grdFractional.CurrentRowIndex, grdFractional.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_FractionsPending["comp_name"])} ").Trim();
						grdFractional.CurrentColumnIndex = 2;
						grdFractional.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						grdFractional.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
						grdFractional[grdFractional.CurrentRowIndex, grdFractional.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_FractionsPending["Comp_city"])} ").Trim();
						grdFractional.CurrentColumnIndex = 3;
						grdFractional.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						grdFractional.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
						grdFractional[grdFractional.CurrentRowIndex, grdFractional.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_FractionsPending["comp_state"])} ").Trim();
						grdFractional.CurrentColumnIndex = 4;
						grdFractional.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						grdFractional.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
						grdFractional[grdFractional.CurrentRowIndex, grdFractional.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_FractionsPending["amod_make_name"])} ").Trim();
						grdFractional.CurrentColumnIndex = 5;
						grdFractional.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						grdFractional.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
						grdFractional[grdFractional.CurrentRowIndex, grdFractional.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_FractionsPending["amod_model_name"])} ").Trim();
						grdFractional.CurrentColumnIndex = 6;
						grdFractional.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						grdFractional.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
						grdFractional[grdFractional.CurrentRowIndex, grdFractional.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_FractionsPending["ac_ser_no_full"])} ").Trim();
						grdFractional.CurrentColumnIndex = 7;
						grdFractional.CellAlignment = DataGridViewContentAlignment.MiddleLeft;
						grdFractional.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
						grdFractional[grdFractional.CurrentRowIndex, grdFractional.CurrentColumnIndex].Value = StringsHelper.Format(snp_FractionsPending["cref_owner_percent"], "##.#");

						TotalCompCallBacks++;
						txt_Total_Comp_Callbacks.Text = TotalCompCallBacks.ToString();
						snp_FractionsPending.MoveNext();
						grdFractional.RowsCount++;
						grdFractional.CurrentRowIndex++;
					};
					cmdStop.Visible = false;
					grdFractional.RowsCount--;
				}
				else
				{
					pnl_fractional_display.Visible = false;
				}

				pnl_Fractional.Visible = true;
				//UPGRADE_ISSUE: (2064) Threed.SSPanel property pnl_Fractional.Caption was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				pnl_Fractional.setCaption("NO PENDING FRACTIONAL SALES");
				grdFractional.Redraw = true;

				search_off();
			}
			catch
			{

				search_off();
				modAdminCommon.Report_Error("Fill_Fractional_Owners_Pending_Sale_Grid_Error: ");
				return;
			}
		}

		public void Fill_WantedList()
		{
			//******************************************************************************************
			//* Note: VBC id'd the following unreferenced items and handled them as described:         *
			//*                                                                                        *
			//* Local Variables (Removed)                                                              *
			//*  TempLocation                  acline                        PrevCompany               *
			//*                                                                                        *
			//******************************************************************************************

			//----------------------------------------------------------------------------------------------
			//Function used to fill the Wanted Grid
			//----------------------------------------------------------------------------------------------

			string Query = "";
			int Total_Wanteds = 0;
			int Total_Company_Wanteds = 0;
			string cellcolor = "";
			int PreviousCompID = 0;
			StringBuilder tmp_desc = new StringBuilder();
			string strProductType = "";
			string strAcctRep = "";
			string strAcctRepId = "";

			string strMsg = "";
			System.DateTime dtStartDate = DateTime.FromOADate(0);
			System.DateTime dtEndDate = DateTime.FromOADate(0);

			try
			{

				modCommon.Start_Activity_Monitor_Message("Callback Wanted", ref strMsg, ref dtStartDate, ref dtEndDate);

				cmd_Refresh_Wanted.Enabled = false;

				string tempRefParam = "Wanteds";
				search_on(ref tempRefParam);

				SSTabHelper.SetSelectedIndex(tab_callback, 7);

				if (WantedOrderBy == "")
				{
					WantedOrderBy = "ORDER BY comp_name, comp_id, comp_city, comp_state, comp_timezone ";
				}

				grd_WantedList.Clear();
				grd_WantedList.ColumnsCount = 8;
				grd_WantedList.RowsCount = 2;

				grd_WantedList.CurrentRowIndex = 0;
				grd_WantedList.CurrentColumnIndex = 0;
				//   grd_WantedList.CellAlignment = flexAlignLeftCenter
				grd_WantedList.SetColumnWidth(0, 240); // company
				grd_WantedList.SetColumnWidth(1, 167); // city
				//   grd_WantedList.CellAlignment = flexAlignLeftCenter
				grd_WantedList.SetColumnWidth(2, 67); // state
				grd_WantedList.SetColumnWidth(3, 67); // timezone
				grd_WantedList.SetColumnWidth(4, 100); // make
				grd_WantedList.SetColumnWidth(5, 47); // model
				grd_WantedList.SetColumnWidth(6, 67); // date listed
				grd_WantedList.SetColumnWidth(7, 67); // date verified
				grd_WantedList.SetColumnWidth(8, 400); // date verified

				// setup grid headers
				grd_WantedList.FixedRows = 1;
				grd_WantedList.FixedColumns = 0;
				grd_WantedList.CurrentColumnIndex = 0;
				grd_WantedList.CurrentRowIndex = 0;

				grd_WantedList[grd_WantedList.CurrentRowIndex, grd_WantedList.CurrentColumnIndex].Value = " Company Name";

				grd_WantedList.CurrentColumnIndex = 1;
				grd_WantedList[grd_WantedList.CurrentRowIndex, grd_WantedList.CurrentColumnIndex].Value = " City";

				grd_WantedList.CurrentColumnIndex = 2;
				grd_WantedList[grd_WantedList.CurrentRowIndex, grd_WantedList.CurrentColumnIndex].Value = "State";

				grd_WantedList.CurrentColumnIndex = 3;
				grd_WantedList[grd_WantedList.CurrentRowIndex, grd_WantedList.CurrentColumnIndex].Value = "Timezone";

				grd_WantedList.CurrentColumnIndex = 4;
				grd_WantedList[grd_WantedList.CurrentRowIndex, grd_WantedList.CurrentColumnIndex].Value = " Make";

				grd_WantedList.CurrentColumnIndex = 5;
				grd_WantedList[grd_WantedList.CurrentRowIndex, grd_WantedList.CurrentColumnIndex].Value = " Model";

				grd_WantedList.CurrentColumnIndex = 6;
				grd_WantedList[grd_WantedList.CurrentRowIndex, grd_WantedList.CurrentColumnIndex].Value = "Listed";

				grd_WantedList.CurrentColumnIndex = 7;
				grd_WantedList[grd_WantedList.CurrentRowIndex, grd_WantedList.CurrentColumnIndex].Value = "Verified";

				grd_WantedList.CurrentColumnIndex = 8;
				grd_WantedList[grd_WantedList.CurrentRowIndex, grd_WantedList.CurrentColumnIndex].Value = "Summary";

				grd_WantedList.CurrentRowIndex = 1;

				//lbl_Message.Caption = ""
				Stopped = false;

				grd_WantedList.Visible = true;
				Total_Company_Wanteds = 0;
				Total_Wanteds = 0;
				PreviousCompID = 0;

				//aey 6/24/04 added prefixes to query field names

				Query = "SELECT ";
				Query = $"{Query}C1.comp_name, ";
				Query = $"{Query}C1.comp_id, ";
				Query = $"{Query}C1.comp_city, ";
				Query = $"{Query}C1.comp_state, ";
				Query = $"{Query}C1.comp_timezone, ";
				Query = $"{Query}AM1.amod_make_name, ";
				Query = $"{Query}AM1.amod_model_name, ";
				Query = $"{Query}AMW1.* ";

				Query = $"{Query}FROM Company AS C1 WITH (NOLOCK) ";
				Query = $"{Query}INNER JOIN Aircraft_Model_Wanted AS AMW1 WITH (NOLOCK) ON AMW1.amwant_comp_id = C1.comp_id AND AMW1.amwant_journ_id = C1.comp_journ_id ";
				Query = $"{Query}INNER JOIN Aircraft_Model AS AM1 WITH (NOLOCK) ON AM1.amod_id = AMW1.amwant_amod_id ";
				Query = $"{Query}WHERE (AMW1.amwant_journ_id = 0) ";

				if (chk_Account_Rep_Wanted.CheckState == CheckState.Checked)
				{
					Query = $"{Query}AND C1.comp_account_id  {make_account_rep_answer_string()}";
				}

				strProductType = cmbProductType.Text.Substring(0, Math.Min(1, cmbProductType.Text.Length)).ToUpper();
				strAcctRep = cbo_account_id.Text.Substring(0, Math.Min(2, cbo_account_id.Text.Length)).ToUpper();
				strAcctRepId = cbo_account_id.Text.ToUpper();


				switch(strProductType)
				{
					case "A" :  // Business and Helicopter 
						Query = $"{Query}AND (AM1.amod_product_business_flag = 'Y' OR AM1.amod_product_helicopter_flag = 'Y') "; 
						 
						break;
					case "B" :  // Business Only 
						Query = $"{Query}AND (AM1.amod_product_business_flag = 'Y') "; 
						 
						break;
					case "H" :  // Helicopter Only 
						Query = $"{Query}AND (AM1.amod_product_helicopter_flag = 'Y') "; 
						 
						break;
					case "C" :  // Commercial Only 
						Query = $"{Query}AND (AM1.amod_product_commercial_flag = 'Y') "; 
						 
						break;
					case "Q" :  // JNiQ Eligible 
						Query = $"{Query}{modCommon.Return_JNiQ_Eligible_Query(strAcctRep, Query)}"; 
						 
						break;
					case "N" :  // Non-JNiQ Eligible 
						Query = $"{Query}{modCommon.Return_Non_JNiQ_Eligible_Query()}"; 
						 
						break;
					case "P" :  // AirBP 
						Query = $"{Query}AND (AM1.amod_product_airbp_flag = 'Y') "; 
						 
						break;
					case "L" :  // All Aircraft 
						 
						break;
				} // Case strProductType

				Query = $"{Query}{WantedOrderBy}";

				modAdminCommon.Record_Event("Monitor Activity", $"Wanted List - Selected AcctRep: {strAcctRepId}");
				//Record_Event "HB Usage", "Wanted List - Selected AcctRep: " & strAcctRepId

				snp_WantedList = new ADORecordSetHelper();
				snp_WantedList.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!snp_WantedList.BOF && !snp_WantedList.EOF)
				{

					cellcolor = modAdminCommon.NoColor;
					pnl_Callbacks.Visible = true;
					cmdStop.Visible = true;
					grd_WantedList.Redraw = false;


					while(!snp_WantedList.EOF)
					{

						if (Stopped)
						{
							Stopped = false;
							break;
						}

						lbl_Message.Text = " ";
						grd_WantedList.CurrentColumnIndex = 0;

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (Convert.IsDBNull(snp_WantedList["amwant_verified_date"]))
						{
							cellcolor = ColorTranslator.ToOle(Color.Yellow).ToString();
						}
						else if (Information.IsDate(snp_WantedList["amwant_verified_date"]))
						{ 

							if (((int) DateAndTime.DateDiff("d", DateTime.Parse(Convert.ToString(snp_WantedList["amwant_verified_date"])), DateTime.Parse(modAdminCommon.DateToday), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) > modAdminCommon.gbl_ConfirmDays)
							{
								cellcolor = (0xC0C0FF).ToString();
							}
							else
							{
								cellcolor = (0xFFFFFF).ToString();
							}

						}

						if (PreviousCompID != Convert.ToInt32(snp_WantedList["comp_id"]))
						{

							grd_WantedList.CellBackColor = Color.White;
							grd_WantedList[grd_WantedList.CurrentRowIndex, grd_WantedList.CurrentColumnIndex].Value = $" {($"{Convert.ToString(snp_WantedList["comp_name"])} ").Trim()}";
							grd_WantedList.CurrentColumnIndex = 1;
							grd_WantedList.CellBackColor = Color.White;
							grd_WantedList[grd_WantedList.CurrentRowIndex, grd_WantedList.CurrentColumnIndex].Value = $" {($"{Convert.ToString(snp_WantedList["Comp_city"])} ").Trim()}";
							grd_WantedList.CurrentColumnIndex = 2;
							grd_WantedList.CellBackColor = Color.White;
							grd_WantedList[grd_WantedList.CurrentRowIndex, grd_WantedList.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_WantedList["comp_state"])} ").Trim();
							grd_WantedList.CurrentColumnIndex = 3;
							grd_WantedList.CellBackColor = Color.White;
							grd_WantedList[grd_WantedList.CurrentRowIndex, grd_WantedList.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_WantedList["comp_timezone"])} ").Trim();

							PreviousCompID = Convert.ToInt32(snp_WantedList["comp_id"]);
							Total_Company_Wanteds++;

						}

						grd_WantedList.CurrentColumnIndex = 4;
						grd_WantedList.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
						grd_WantedList[grd_WantedList.CurrentRowIndex, grd_WantedList.CurrentColumnIndex].Value = $" {($"{Convert.ToString(snp_WantedList["amod_make_name"])} ").Trim()}";
						grd_WantedList.CurrentColumnIndex = 5;
						grd_WantedList.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
						grd_WantedList[grd_WantedList.CurrentRowIndex, grd_WantedList.CurrentColumnIndex].Value = $" {Convert.ToString(snp_WantedList["amod_model_name"])}";
						grd_WantedList.CurrentColumnIndex = 6;
						grd_WantedList.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
						grd_WantedList[grd_WantedList.CurrentRowIndex, grd_WantedList.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_WantedList["amwant_listed_date"])} ").Trim();
						grd_WantedList.CurrentColumnIndex = 7;
						grd_WantedList.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
						grd_WantedList[grd_WantedList.CurrentRowIndex, grd_WantedList.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_WantedList["amwant_verified_date"])} ").Trim();
						tmp_desc = new StringBuilder("");

						if (Strings.Len(($"{Convert.ToString(snp_WantedList["amwant_start_year"])} ").Trim()) > 0 || Strings.Len(($"{Convert.ToString(snp_WantedList["amwant_end_year"])} ").Trim()) > 0)
						{
							// check for no start
							if (($"{Convert.ToString(snp_WantedList["amwant_start_year"])} ").Trim() == "Open" || Strings.Len(($"{Convert.ToString(snp_WantedList["amwant_start_year"])} ").Trim()) == 0)
							{
								// have no start year but have a end year
								if (($"{Convert.ToString(snp_WantedList["amwant_end_year"])} ").Trim() != "Open" && Strings.Len(($"{Convert.ToString(snp_WantedList["amwant_end_year"])} ").Trim()) != 0)
								{
									tmp_desc.Append($"Years <= {($"{Convert.ToString(snp_WantedList["amwant_end_year"])} ").Trim()}; ");
								}
								else
								{
									// no start year or end year

								}
							}
							else
							{
								// have a start year
								// have a start year and a end year
								if (($"{Convert.ToString(snp_WantedList["amwant_end_year"])} ").Trim() != "Open" && Strings.Len(($"{Convert.ToString(snp_WantedList["amwant_end_year"])} ").Trim()) != 0)
								{
									tmp_desc.Append($"Years From {($"{Convert.ToString(snp_WantedList["amwant_start_year"])} ").Trim()} to {($"{Convert.ToString(snp_WantedList["amwant_end_year"])} ").Trim()}; ");
								}
							}

						}

						if (Strings.Len(($"{Convert.ToString(snp_WantedList["amwant_max_price"])} ").Trim()) > 0 && Conversion.Val(($"{Convert.ToString(snp_WantedList["amwant_max_price"])} ").Trim()) > 0)
						{
							tmp_desc.Append($"Max ${($"{Convert.ToString(snp_WantedList["amwant_max_price"])} ").Trim()}; ");
						}

						if (Strings.Len(($"{Convert.ToString(snp_WantedList["amwant_max_aftt"])} ").Trim()) > 0 && Conversion.Val(($"{Convert.ToString(snp_WantedList["amwant_max_aftt"])} ").Trim()) > 0)
						{
							tmp_desc.Append($"Max AFTT {($"{Convert.ToString(snp_WantedList["amwant_max_aftt"])} ").Trim()}; ");
						}

						if (($"{Convert.ToString(snp_WantedList["amwant_accept_dam_cur"])} ").Trim() == "Y")
						{
							tmp_desc.Append("Current Damage OK;");
						}
						else
						{

							if (($"{Convert.ToString(snp_WantedList["amwant_accept_dam_cur"])} ").Trim() == "N")
							{
								tmp_desc.Append("No Current Damage;");
							}

						}

						if (($"{Convert.ToString(snp_WantedList["amwant_accept_damage_hist"])} ").Trim() == "Y")
						{
							tmp_desc.Append("Historical Damage OK;");
						}
						else
						{

							if (($"{Convert.ToString(snp_WantedList["amwant_accept_damage_hist"])} ").Trim() == "N")
							{
								tmp_desc.Append("No Historical Damage;");
							}

						}
						grd_WantedList.CurrentColumnIndex = 8;
						grd_WantedList.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
						grd_WantedList[grd_WantedList.CurrentRowIndex, grd_WantedList.CurrentColumnIndex].Value = tmp_desc.ToString();

						grd_WantedList.set_RowData(grd_WantedList.CurrentRowIndex, Convert.ToInt32(snp_WantedList["comp_id"]));
						Total_Wanteds++;
						snp_WantedList.MoveNext();

						grd_WantedList.RowsCount++;
						grd_WantedList.CurrentRowIndex++;
						txt_Tot_Wanted.Text = Total_Wanteds.ToString();
						txt_Tot_CompanyWanted.Text = Total_Company_Wanteds.ToString();

						if (Total_Wanteds == 22)
						{
							grd_WantedList.Redraw = true;
							grd_WantedList.Refresh();
							Application.DoEvents();
							grd_WantedList.Redraw = false;
						}

					}; // Do While Not snp_WantedList.EOF

					grd_WantedList.Redraw = true;

					cmdStop.Visible = false;

					grd_WantedList.RowsCount--;
					txt_Tot_Wanted.Text = Total_Wanteds.ToString();
					txt_Tot_CompanyWanted.Text = Total_Company_Wanteds.ToString();
					grd_WantedList.Visible = true;
					grd_WantedList.Redraw = true;

				}
				else
				{
					lbl_Message.Text = "No Wanteds Selected.";
				} // If (snp_WantedList.BOF = False And snp_WantedList.EOF = False) Then

				strMsg = $"AcctRep: {cbo_account_id.Text}";
				strMsg = $"{strMsg} Product: {cmbProductType.Text}";
				strMsg = $"{strMsg} Callback Date: {txt_Callback_Date.Text}";

				if (chk_Account_Rep_Wanted.CheckState == CheckState.Checked)
				{
					strMsg = $"{strMsg} [x] Current AcctRep Only ";
				}

				if (bLog)
				{

					modCommon.End_Activity_Monitor_Message("Callback Wanted", ref strMsg, dtStartDate, ref dtEndDate, 0, 0, 0, 0, 0);

					frm_UserHistory.DefInstance.Refresh_User_History_Grids("Callback");

				}

				search_off();
				cmd_Refresh_Wanted.Enabled = true;
			}
			catch (System.Exception excep)
			{

				snp_WantedList.Close();
				snp_WantedList = null;

				modAdminCommon.Report_Error($"Fill_WantedList_Error: {excep.Message}{Environment.NewLine}");
				search_off();
			}

		} // Fill_WantedList

		public void Show_Wanted_Company_Information()
		{
			//******************************************************************************************
			//* Note: VBC id'd the following unreferenced items and handled them as described:         *
			//*                                                                                        *
			//* Local Variables (Removed)                                                              *
			//*  Query                                                                                 *
			//******************************************************************************************

			//----------------------------------------------------------------------------------------------
			//Function used to display company callback information
			//----------------------------------------------------------------------------------------------


			lstCompany.Items.Clear();
			//MsgBox (grd_WantedList.row)
			snp_WantedList.MoveFirst();
			int tempForEndVar = grd_WantedList.CurrentRowIndex - 1;
			for (int i = 1; i <= tempForEndVar; i++)
			{
				snp_WantedList.MoveNext();
			}

			RememberExclusiveCompanyId = Convert.ToInt32(snp_WantedList["comp_id"]);

			modCommon.Build_Company_NameAddress(lstCompany, Convert.ToInt32(snp_WantedList["comp_id"]), 0);
			lstCompany.SetItemData(0, Convert.ToInt32(snp_WantedList["comp_id"]));

			cmdConfirmExclusive.Enabled = true; //aey 4/21/2006
			cmdConfirmExclusive.Text = "&Confirm Company";

			string strLock = modCommon.CompanyLocked(RememberExclusiveCompanyId, 0);

			if ((strLock == "False") || (strLock == Convert.ToString(modAdminCommon.snp_User["user_id"])))
			{
			}
			else
			{
				cmdConfirmExclusive.Enabled = false;
				cmdConfirmExclusive.Text = "Confirm Company Locked";
			}


		}

		public string get_make_model(int inModel_ID)
		{
			//----------------------------------------------------------------------------------------------
			//Function used to select class 'A' aircraft
			//----------------------------------------------------------------------------------------------
			string result = "";
			ADORecordSetHelper snp_ModNames = new ADORecordSetHelper(); // dao.Recordset aey 6/18/04

			string Query = "SELECT amod_make_name, amod_model_name ";
			Query = $"{Query}FROM Aircraft_Model WITH(NOLOCK) ";
			Query = $"{Query}WHERE amod_id={inModel_ID.ToString()}";

			// Set snp_ModNames = LOCAL_DB.OpenRecordset(Query, dbOpenSnapshot, dbSQLPassThrough)
			snp_ModNames.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

			if (!(snp_ModNames.EOF && snp_ModNames.BOF))
			{
				snp_ModNames.MoveFirst(); //aey 6/18/04    'If snp_ModNames.RecordCount > 0 Then
				result = $"{($" {Convert.ToString(snp_ModNames["amod_make_name"])}").Trim()}/{($" {Convert.ToString(snp_ModNames["amod_model_name"])}").Trim()}";
			}
			else
			{
				result = "Not Found.";
			}
			snp_ModNames.Close();
			return result;
		}

		public int Get_Company_ID(int inAircraft_ID, int inJournal_ID, string inContact_Type)
		{

			int result = 0;
			ADORecordSetHelper snp_CID = new ADORecordSetHelper(); // dao.Recordset aey 6/18/04
			string Query = "SELECT cref_comp_id ";
			Query = $"{Query}FROM Aircraft_Reference WITH(NOLOCK) ";
			Query = $"{Query}WHERE cref_ac_id={inAircraft_ID.ToString()} ";
			Query = $"{Query}AND cref_journ_id={inJournal_ID.ToString()} ";
			switch(inContact_Type)
			{
				case "13" : 
					Query = $"{Query}AND (cref_contact_type='13' OR cref_contact_type='57')"; 
					break;
				case "12" : 
					Query = $"{Query}AND (cref_contact_type='12' OR cref_contact_type='39')"; 
					break;
			}

			//Set snp_CID = LOCAL_DB.OpenRecordset(Query, dbOpenSnapshot, dbSQLPassThrough)
			snp_CID.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

			if (!(snp_CID.BOF && snp_CID.EOF))
			{
				snp_CID.MoveFirst(); //If snp_CID.RecordCount > 0 Then aey 6/18/04
				result = Convert.ToInt32(Double.Parse(Convert.ToString(snp_CID["cref_comp_id"]).Trim()));
			}
			else
			{
				result = 0;
			}
			snp_CID.Close();
			return result;
		}


		public string Get_Company_Name(int inComp_ID, int inJourn_ID)
		{
			string result = "";
			ADORecordSetHelper snp_CompName = new ADORecordSetHelper(); // dao.Recordset aey 6/18/04
			string Query = $"select comp_name from Company WITH(NOLOCK) where comp_id={inComp_ID.ToString()}";
			Query = $"{Query} and comp_journ_id={inJourn_ID.ToString()}";
			//Set snp_CompName = LOCAL_DB.OpenRecordset(Query, dbOpenSnapshot, dbSQLPassThrough)
			snp_CompName.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

			if (!(snp_CompName.BOF && snp_CompName.EOF))
			{
				//snp_CompName.MoveLast
				snp_CompName.MoveFirst();
				result = ($" {Convert.ToString(snp_CompName["comp_name"])}").Trim();
			}
			snp_CompName.Close();

			return result;
		}

		public void Fill_Documents_In_Process(bool only_dups = false)
		{
			//******************************************************************************************
			//* Note: VBC id'd the following unreferenced items and handled them as described:         *
			//*                                                                                        *
			//* Local Variables (Removed)                                                              *
			//*  CompanyCellColor              CompAddress                   TempACID                  *
			//*  GotTotal                      i                                                       *
			//******************************************************************************************

			int TotFound = 0;
			string Query = "";
			string cellcolor = "";
			string strProductType = "";
			string strClass = "";
			string strAcctRep = "";
			string strAcctRepId = "";
			bool pass_display = false;
			bool duplicate_record = false;
			int doc_ac = 0;
			bool display_row = false;
			string doc_date = "";
			string doc_type = "";

			try
			{

				if (DocumentsOrderBy == "")
				{
					DocumentsOrderBy = "ORDER BY amod_make_name, amod_model_name, ac_ser_no_full, faalog_tape_no, faalog_tape_date";
				}

				Application.DoEvents();

				lbl_Documents_In_Process.Text = "Searching for Documents ...";
				Stopped = false;
				cellcolor = modAdminCommon.NoColor;
				this.Cursor = Cursors.WaitCursor;
				cmd_DocsInProcessRefresh.Enabled = false;

				strAcctRep = cbo_account_id.Text.Substring(0, Math.Min(2, cbo_account_id.Text.Length)).ToUpper();
				strAcctRepId = cbo_account_id.Text.ToUpper();

				TotFound = 0;
				grd_DocumentLog.Clear();
				grd_DocumentLog.Visible = true;

				if (is_compact_view == "Y")
				{
					grd_DocumentLog.ColumnsCount = 15;
				}
				else
				{
					grd_DocumentLog.ColumnsCount = 13;
				}

				grd_DocumentLog.RowsCount = 2;
				grd_DocumentLog.FixedRows = 1;
				grd_DocumentLog.CurrentRowIndex = 0;

				grd_DocumentLog.CurrentColumnIndex = 0;
				grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = "Make/Model-SerNbr/RegNbr";
				grd_DocumentLog.DefaultCellStyle.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_DocumentLog.SetColumnWidth(grd_DocumentLog.CurrentColumnIndex, 247);

				grd_DocumentLog.CurrentColumnIndex = 1;
				grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = "Last Action Date";
				grd_DocumentLog.DefaultCellStyle.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_DocumentLog.SetColumnWidth(grd_DocumentLog.CurrentColumnIndex, 67);

				if (is_compact_view == "Y")
				{
					grd_DocumentLog.SetColumnWidth(grd_DocumentLog.CurrentColumnIndex, 0);
				}

				grd_DocumentLog.CurrentColumnIndex = 2;
				grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = "Type";
				grd_DocumentLog.DefaultCellStyle.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_DocumentLog.SetColumnWidth(grd_DocumentLog.CurrentColumnIndex, 43);

				if (is_compact_view == "Y")
				{
					grd_DocumentLog.SetColumnWidth(grd_DocumentLog.CurrentColumnIndex, 0);
				}

				grd_DocumentLog.CurrentColumnIndex = 3;
				grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = "Tape#";
				grd_DocumentLog.DefaultCellStyle.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_DocumentLog.SetColumnWidth(grd_DocumentLog.CurrentColumnIndex, 50);

				if (is_compact_view == "Y")
				{
					grd_DocumentLog.SetColumnWidth(grd_DocumentLog.CurrentColumnIndex, 0);
				}

				grd_DocumentLog.CurrentColumnIndex = 4;
				grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = "Tape Date";
				grd_DocumentLog.DefaultCellStyle.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_DocumentLog.SetColumnWidth(grd_DocumentLog.CurrentColumnIndex, 67);

				if (is_compact_view == "Y")
				{
					grd_DocumentLog.SetColumnWidth(grd_DocumentLog.CurrentColumnIndex, 0);
				}

				grd_DocumentLog.CurrentColumnIndex = 5;
				grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = "Doc Date";
				grd_DocumentLog.DefaultCellStyle.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_DocumentLog.SetColumnWidth(grd_DocumentLog.CurrentColumnIndex, 67);

				grd_DocumentLog.CurrentColumnIndex = 6;
				grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = "Frame Start";
				grd_DocumentLog.DefaultCellStyle.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_DocumentLog.SetColumnWidth(grd_DocumentLog.CurrentColumnIndex, 63);

				if (is_compact_view == "Y")
				{
					grd_DocumentLog.SetColumnWidth(grd_DocumentLog.CurrentColumnIndex, 0);
				}

				grd_DocumentLog.CurrentColumnIndex = 7;
				grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = "Frame End";
				grd_DocumentLog.DefaultCellStyle.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_DocumentLog.SetColumnWidth(grd_DocumentLog.CurrentColumnIndex, 60);

				if (is_compact_view == "Y")
				{
					grd_DocumentLog.SetColumnWidth(grd_DocumentLog.CurrentColumnIndex, 0);
				}

				grd_DocumentLog.CurrentColumnIndex = 8;
				grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = "Rolled By";
				grd_DocumentLog.DefaultCellStyle.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_DocumentLog.SetColumnWidth(grd_DocumentLog.CurrentColumnIndex, 53);

				if (is_compact_view == "Y")
				{
					grd_DocumentLog.SetColumnWidth(grd_DocumentLog.CurrentColumnIndex, 0);
				}

				grd_DocumentLog.CurrentColumnIndex = 9;
				grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = "Assigned To";
				grd_DocumentLog.DefaultCellStyle.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_DocumentLog.SetColumnWidth(grd_DocumentLog.CurrentColumnIndex, 57);

				if (is_compact_view == "Y")
				{
					grd_DocumentLog.SetColumnWidth(grd_DocumentLog.CurrentColumnIndex, 0);
				}

				grd_DocumentLog.CurrentColumnIndex = 10;
				grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = "Log ID";
				grd_DocumentLog.DefaultCellStyle.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_DocumentLog.SetColumnWidth(grd_DocumentLog.CurrentColumnIndex, 53);

				if (is_compact_view == "Y")
				{
					grd_DocumentLog.SetColumnWidth(grd_DocumentLog.CurrentColumnIndex, 0);
				}

				if (is_compact_view == "Y")
				{
					grd_DocumentLog.CurrentColumnIndex = 11;
					grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = "Notes";
					grd_DocumentLog.DefaultCellStyle.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
					grd_DocumentLog.SetColumnWidth(grd_DocumentLog.CurrentColumnIndex, 387);

					grd_DocumentLog.CurrentColumnIndex = 12;
					grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = "Doc Attempted";
					grd_DocumentLog.DefaultCellStyle.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
					grd_DocumentLog.SetColumnWidth(grd_DocumentLog.CurrentColumnIndex, 100);

					grd_DocumentLog.CurrentColumnIndex = 13;
					grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = "State";
					grd_DocumentLog.DefaultCellStyle.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
					grd_DocumentLog.SetColumnWidth(grd_DocumentLog.CurrentColumnIndex, 33);

					grd_DocumentLog.CurrentColumnIndex = 14;
					grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = "Country";
					grd_DocumentLog.DefaultCellStyle.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
					grd_DocumentLog.SetColumnWidth(grd_DocumentLog.CurrentColumnIndex, 73);
				}
				else
				{
					grd_DocumentLog.CurrentColumnIndex = 11;
					grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = "Notes";
					grd_DocumentLog.DefaultCellStyle.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
					grd_DocumentLog.SetColumnWidth(grd_DocumentLog.CurrentColumnIndex, 400);

					grd_DocumentLog.CurrentColumnIndex = 12;
					grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = "Doc Resp";
					grd_DocumentLog.DefaultCellStyle.BackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
					grd_DocumentLog.SetColumnWidth(grd_DocumentLog.CurrentColumnIndex, 107);
				}

				grd_DocumentLog.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

				//aey 6/24/04 added prefixes to query field names

				Query = "SELECT FDL1.*, ";
				Query = $"{Query}AM1.amod_make_name, ";
				Query = $"{Query}Am1.amod_model_name, ";
				Query = $"{Query}A1.ac_ser_no_full, ";
				Query = $"{Query}A1.ac_reg_no, ";
				Query = $"{Query}A1.ac_id, ";

				Query = $"{Query}A1.ac_product_business_flag as bus_flag, ";
				Query = $"{Query}A1.ac_product_helicopter_flag as heli_flag,  ";
				Query = $"{Query}A1.ac_product_commercial_flag as comm_flag  ";


				Query = $"{Query}, (";


				Query = $"{Query}SELECT COUNT(*)  ";
				Query = $"{Query}FROM Aircraft_Document WITH (NOLOCK) ";
				Query = $"{Query}INNER JOIN Document_Type WITH (NOLOCK) ON doctype_description = adoc_doc_type ";
				Query = $"{Query}WHERE (adoc_ac_id = FDL1.faalog_ac_id) ";
				Query = $"{Query}AND (adoc_journ_id > 0) ";
				Query = $"{Query}AND (doctype_code = FDL1.faalog_doc_type) ";
				Query = $"{Query}AND (CAST(adoc_doc_date AS DATE) = FDL1.faalog_document_date) ";
				Query = $"{Query}AND (doctype_company_doc_view = 'N') ";

				Query = $"{Query} ) AS doc_duplicate ";

				// original doc duplicate in case we need it ever - MSW - 3/22/23
				//    Query = Query & ", ("
				//  Query = Query & " SELECT count(*) FROM FAA_Document_Log AS D1 WITH (NOLOCK) "
				//  Query = Query & " WHERE (D1.faalog_ac_id = FDL1.faalog_ac_id) "
				//  Query = Query & " and (D1.faalog_document_date = FDL1.faalog_document_date) "
				//  Query = Query & " and (D1.faalog_doc_type = FDL1.faalog_doc_type) "
				//
				//  Query = Query & " ) AS doc_duplicate "


				//  Query = Query & ", ("
				//  Query = Query & " SELECT count(*) FROM Aircraft_Document AS D2 WITH (NOLOCK) "
				//    Query = Query & " inner join Document_Type with (nolock) on doctype_description = adoc_doc_type"
				//    Query = Query & " Where D2.adoc_ac_id = FDL1.faalog_ac_id "
				//    Query = Query & " and doctype_code   = FDL1.faalog_doc_type"
				//    Query = Query & " and D2.adoc_doc_date = FDL1.faalog_document_date  "
				//
				//  Query = Query & " ) AS att_doc_duplicate "
				//

				//  Query = Query & " ("
				//  Query = Query & " SELECT TOP 1 journ_date FROM Journal AS J1 WITH (NOLOCK) "
				//  Query = Query & " WHERE (J1.journ_ac_id = A1.ac_id) "
				//  Query = Query & " AND (J1.journ_subject LIKE '%Doc Attempted%') "
				//  Query = Query & " and J1.journ_date >= (getdate() - 540) "
				//  Query = Query & " ORDER BY J1.journ_date DESC"
				//  Query = Query & " ) AS last_attempted, "

				Query = $"{Query}, (";
				Query = $"{Query} SELECT TOP 1 journ_date FROM Journal AS J1 WITH (NOLOCK) ";
				Query = $"{Query} WHERE (J1.journ_ac_id = A1.ac_id) ";
				Query = $"{Query} AND (J1.journ_subject LIKE 'Doc Resp:%') ";
				Query = $"{Query} and J1.journ_date >= (getdate() - 540) ";
				Query = $"{Query} ORDER BY J1.journ_date DESC";
				Query = $"{Query} ) AS last_attempted, ";


				if (is_compact_view == "Y")
				{
					Query = $"{Query} comp_state, comp_country, ";
				}

				Query = $"{Query}A1.ac_forsale_flag ,";
				Query = $"{Query}A1.ac_lifecycle_stage ";

				Query = $"{Query}FROM FAA_Document_Log as FDL1 WITH (NOLOCK) ";
				Query = $"{Query}INNER JOIN Aircraft AS A1 WITH (NOLOCK) ON A1.ac_id = FDL1.faalog_ac_id AND A1.ac_journ_id = FDL1.faalog_journ_id ";
				Query = $"{Query}INNER JOIN Aircraft_Model AS AM1 WITH (NOLOCK) ON AM1.amod_id = A1.ac_amod_id ";

				// below modified - 7/6/21 - MSw
				// modified both to be left outer joins so that all records, mostly retired, show up all the time
				// make sure you only do inner joins if they pick a country or timezone
				//If is_compact_view = "Y" Then   ' commented this out so that it worked for both view - 11/23/21
				Query = $"{Query}LEFT OUTER JOIN Aircraft_Reference AS AR1 WITH (NOLOCK) ON cref_ac_id = a1.ac_id and cref_journ_id =  A1.ac_journ_id  and cref_primary_poc_flag = 'Y' ";

				// Added MSW - 7/30/2020 -------------
				if (cbo_Timezones.Text != "All")
				{
					if (cbo_Timezones.Text == "International")
					{
						Query = $"{Query}LEFT OUTER JOIN Company AS C1 WITH (NOLOCK) ON comp_journ_id =  A1.ac_journ_id and comp_id = cref_comp_id  ";
						Query = $"{Query} AND ((comp_timezone is NULL) or (comp_timezone=''))";
					}
					else
					{
						Query = $"{Query}INNER JOIN Company AS C1 WITH (NOLOCK) ON comp_journ_id =  A1.ac_journ_id and comp_id = cref_comp_id  ";

						if (cbo_Timezones.Text.Trim() == "All U.S.")
						{
							Query = $"{Query} AND (comp_country = 'United States') ";
						}
						else
						{
							Query = $"{Query} AND (comp_timezone='{cbo_Timezones.Text}') ";
						}
					}
				}
				else
				{
					Query = $"{Query}LEFT OUTER JOIN Company AS C1 WITH (NOLOCK) ON comp_journ_id =  A1.ac_journ_id and comp_id = cref_comp_id  ";
				}
				// End If







				if (chkAttachedDocs.CheckState == CheckState.Checked)
				{
					Query = $"{Query}WHERE (FDL1.faalog_journ_id > 0) ";
					Query = $"{Query}AND (FDL1.faalog_update_date >= '{cal_Callback.SelectionRange.Start.ToString("MM/dd/yyyy")}') ";
				}
				else
				{
					Query = $"{Query}WHERE (FDL1.faalog_journ_id = 0) ";
				}
				if (chk_AllDocuments.CheckState == CheckState.Unchecked)
				{
					if (strAcctRepId != "NO REP SELECTED")
					{
						Query = $"{Query}AND (FDL1.faalog_user_id = '{strAcctRepId}') ";
					}
				}



				// added in msw - top 10 models selected
				if (chk_action_list[12].CheckState == CheckState.Checked)
				{

					Query = $"{Query}  and amod_id in (";
					Query = $"{Query} (select top 10  amodrank_amod_id  from [EVO_Live].jetnet_ra.dbo.Aircraft_Model_Rank";
					Query = $"{Query} Where amodrank_month = month(getdate()) And amodrank_year = year(getdate())  ";
					Query = $"{Query} order by amodrank_rank asc ) ";
					Query = $"{Query} ) ";

				}

				strProductType = cmbProductType.Text.Substring(0, Math.Min(1, cmbProductType.Text.Length)).ToUpper();


				switch(strProductType)
				{
					case "A" :  // Business and Helicopter 
						//  Query = Query & "AND (A1.ac_product_business_flag = 'Y' OR A1.ac_product_helicopter_flag = 'Y') " 
						//   Query = Query & "AND (A1.ac_product_business_flag = 'Y') " 
						// NO IDEA WHY THIS DOESNT WORK - IT FREEZES EVEN THO SELECT WORKS IN 1 seecond - MSW - 11/3/21 
						break;
					case "B" :  // Business Only 
						Query = $"{Query}AND (A1.ac_product_business_flag = 'Y') "; 
						 
						break;
					case "H" :  // Helicopter Only 
						Query = $"{Query}AND (A1.ac_product_helicopter_flag = 'Y') "; 
						 
						break;
					case "C" :  // Commercial Only 
						//  Query = Query & "AND (A1.ac_product_commercial_flag = 'Y') " 
						 
						break;
					case "Q" :  // JNiQ Eligible 
						// Does NOT Exist For Documents In Process 
						// Query = Query & Return_JNiQ_Eligible_Query(strAcctRep, Query) 
						// added in MSW- - 12/31/2020-------------- 
						Query = $"{Query}             AND (AM1.amod_airframe_type_code = 'F') "; 
						Query = $"{Query}             AND (AM1.amod_customer_flag = 'Y') "; 
						Query = $"{Query}             AND (AM1.amod_type_code IN ('J','T','E')) "; 
						Query = $"{Query}             AND (AM1.amod_product_business_flag = 'Y') "; 
						Query = $"{Query}             AND (A1.ac_product_business_flag = 'Y') "; 
						 
						break;
					case "N" :  // Non-JNiQ Eligible 
						 
						//Query = Query & Return_Non_JNiQ_Eligible_Query() 
						 
						// added in MSW- - 12/31/2020-------------- 
						Query = $"{Query}  and not(          (AM1.amod_airframe_type_code = 'F') "; 
						Query = $"{Query}             AND (AM1.amod_customer_flag = 'Y') "; 
						Query = $"{Query}             AND (AM1.amod_type_code IN ('J','T','E')) "; 
						Query = $"{Query}             AND (AM1.amod_product_business_flag = 'Y') "; 
						Query = $"{Query}             AND (A1.ac_product_business_flag = 'Y') "; 
						Query = $"{Query}           )  "; 

						 
						// Does NOT Exist For Documents In Process 
						 
						break;
					case "P" :  // AirBP 
						Query = $"{Query}AND (A1.ac_product_airbp_flag = 'Y') "; 
						 
						break;
					case "L" :  // All Aircraft 
						 
						break;
				} // Case strProductType

				// 01/12/2016 - By David D. Cruger
				// Added Class Search

				strClass = cmbDocInProcsClass.Text.ToUpper();
				if (strClass != "ALL")
				{
					Query = $"{Query}AND (AM1.amod_class_code = '{strClass.Substring(Math.Max(strClass.Length - 1, 0))}') ";
				}

				// added MSW - 9/6/23
				if (chk_action_list[13].CheckState == CheckState.Unchecked)
				{
					Query = $"{Query}AND (AM1.amod_class_code <> 'E') ";
				}
				else
				{
					// show all ac including E
				}

				Query = $"{Query}{DocumentsOrderBy}";



				// Record_Event "HB Usage", "Documents In Process - Selected AcctRep: " & strAcctRepId
				modAdminCommon.Record_Event("Monitor Activity", $"Documents In Process - Selected AcctRep: {strAcctRepId}");

				snp_DocLog = new ADORecordSetHelper();
				snp_DocLog.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				TotFound = 0;
				if (!(snp_DocLog.BOF && snp_DocLog.EOF))
				{

					grd_DocumentLog.Redraw = false;
					grd_DocumentLog.CurrentRowIndex = 1;

					cmdStop.Visible = true;
					pass_display = true;


					while(!snp_DocLog.EOF)
					{

						if (Stopped)
						{
							Stopped = false;
							this.Cursor = CursorHelper.CursorDefault;
							break;
						}


						// added in MSW - 1/20/22
						cellcolor = modAdminCommon.NoColor;

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snp_DocLog["ac_forsale_flag"]))
						{
							if (Convert.ToString(snp_DocLog["ac_forsale_flag"]).Trim() == "Y")
							{
								cellcolor = (0xC000).ToString();
							}
						}

						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snp_DocLog["ac_lifecycle_stage"]))
						{
							if (Convert.ToString(snp_DocLog["ac_lifecycle_stage"]).Trim() == "4")
							{
								cellcolor = (0xC0C0C0).ToString();
							}
						}




						//        ' added in MSW -8/14/22
						//        If Not IsNull(snp_DocLog("ac_id")) And Not IsNull(snp_DocLog("faalog_document_date")) And Not IsNull(snp_DocLog("faalog_doc_type")) Then
						//            If CLng(snp_DocLog("ac_id").Value) = doc_ac Then
						//                If Trim(doc_date) = FormatDateTime(Trim$(snp_DocLog("faalog_document_date").Value), vbShortDate) Then
						//                    If Trim(doc_type) = Trim$(snp_DocLog("faalog_doc_type").Value) Then
						//                            ' cellcolor = &HE1E4FF      'pink ish color
						//                             cellcolor = vbBlack
						//                             duplicate_record = True
						//
						//                             If Trim(doc_type) = "LSE" Then
						//                                doc_type = doc_type
						//                             End If
						//                    End If
						//                End If
						//            End If
						//        End If


						duplicate_record = false;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						if (!Convert.IsDBNull(snp_DocLog["doc_duplicate"]))
						{
							if (Convert.ToDouble(snp_DocLog["doc_duplicate"]) > 0)
							{
								cellcolor = (0xE1E4FF).ToString();
								duplicate_record = true;
							}
						}

						//        '  commented out MSW - not going to use yellow
						//         If Not IsNull(snp_DocLog("att_doc_duplicate")) Then
						//            If snp_DocLog("att_doc_duplicate") > 0 Then
						//            cellcolor = &H80FFFF
						//            duplicate_record = True
						//            End If
						//         End If





						if (only_dups && !duplicate_record)
						{
							// then dont display
							display_row = false;
						}
						else if (only_dups && duplicate_record)
						{ 
							display_row = true;
						}
						else
						{
							display_row = true;
						}

						if (display_row)
						{





							if (strProductType == "A")
							{
								pass_display = false;
								// added this in as select didnt work above - no clue why - MSW - 11/4/21
								if (Convert.ToString(snp_DocLog["bus_flag"]).Trim() == "Y" || Convert.ToString(snp_DocLog["heli_flag"]).Trim() == "Y")
								{
									pass_display = true;
								}

							}
							else if (strProductType == "C")
							{ 
								pass_display = false;
								if (Convert.ToString(snp_DocLog["comm_flag"]).Trim() == "Y")
								{
									pass_display = true;
								}
							}

							if (pass_display)
							{


								TotFound++;
								lbl_Documents_In_Process.Text = $"{TotFound.ToString()} Documents Selected.";

								// MAKE/MODEL-SERNBR/REGNBR
								grd_DocumentLog.CurrentColumnIndex = 0;
								grd_DocumentLog.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));

								grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = ($"{Convert.ToString(snp_DocLog["amod_make_name"])} ").Trim();
								grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = $"{grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].FormattedValue.ToString()} / {($"{Convert.ToString(snp_DocLog["amod_model_name"])} ").Trim()}";
								grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = $"{grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].FormattedValue.ToString()} - {($"{Convert.ToString(snp_DocLog["ac_ser_no_full"])} ").Trim()}";
								grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = $"{grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].FormattedValue.ToString()} / {($"{Convert.ToString(snp_DocLog["ac_reg_no"])} ").Trim()}";

								// Remove ACId; 11/05/2015 - By David D. Cruger
								//grd_DocumentLog.Text = grd_DocumentLog.Text & " [ID:" & CStr(snp_DocLog("ac_id").Value) & "]"

								// LAST ACTION DATE (UPDATE DATE)
								grd_DocumentLog.CurrentColumnIndex = 1;
								grd_DocumentLog.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
								grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = "";
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(snp_DocLog["faalog_update_date"]))
								{
									if (Information.IsDate(snp_DocLog["faalog_update_date"]))
									{
										grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = DateTime.Parse(Convert.ToString(snp_DocLog["faalog_update_date"]).Trim()).ToString("d");
									}
								}

								// DOCUMENT TYPE
								grd_DocumentLog.CurrentColumnIndex = 2;
								grd_DocumentLog.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
								grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = "";
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(snp_DocLog["faalog_doc_type"]))
								{
									if (Convert.ToString(snp_DocLog["faalog_doc_type"]).Trim() != modGlobalVars.cEmptyString)
									{
										grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = Convert.ToString(snp_DocLog["faalog_doc_type"]).Trim();
										doc_type = grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].FormattedValue.ToString();
									}
								}

								// TAPE#
								grd_DocumentLog.CurrentColumnIndex = 3;
								grd_DocumentLog.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
								grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = "";
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(snp_DocLog["faalog_tape_no"]))
								{
									if (Convert.ToString(snp_DocLog["faalog_tape_no"]).Trim() != modGlobalVars.cEmptyString)
									{
										grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = Convert.ToString(snp_DocLog["faalog_tape_no"]).Trim();
									}
								}

								// TAPE DATE
								grd_DocumentLog.CurrentColumnIndex = 4;
								grd_DocumentLog.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
								grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = "";
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(snp_DocLog["faalog_tape_date"]))
								{
									if (Information.IsDate(snp_DocLog["faalog_tape_date"]))
									{
										grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = DateTime.Parse(Convert.ToString(snp_DocLog["faalog_tape_date"]).Trim()).ToString("d");
									}
								}

								// DOCUMENT DATE
								grd_DocumentLog.CurrentColumnIndex = 5;
								grd_DocumentLog.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
								grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = "";
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(snp_DocLog["faalog_document_date"]))
								{
									if (Information.IsDate(snp_DocLog["faalog_document_date"]))
									{
										grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = DateTime.Parse(Convert.ToString(snp_DocLog["faalog_document_date"]).Trim()).ToString("d");
										doc_date = grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].FormattedValue.ToString();
									}
								}

								// FRAME# START
								grd_DocumentLog.CurrentColumnIndex = 6;
								grd_DocumentLog.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
								grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = "";
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(snp_DocLog["faalog_starting_frame_no"]))
								{
									if (Convert.ToString(snp_DocLog["faalog_starting_frame_no"]).Trim() != modGlobalVars.cEmptyString)
									{
										grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = Convert.ToString(snp_DocLog["faalog_starting_frame_no"]).Trim();
									}
								}

								// FRAME# END
								grd_DocumentLog.CurrentColumnIndex = 7;
								grd_DocumentLog.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
								grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = "";
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(snp_DocLog["faalog_ending_frame_no"]))
								{
									if (Convert.ToString(snp_DocLog["faalog_ending_frame_no"]).Trim() != modGlobalVars.cEmptyString)
									{
										grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = Convert.ToString(snp_DocLog["faalog_ending_frame_no"]).Trim();
									}
								}

								// USER
								grd_DocumentLog.CurrentColumnIndex = 8;
								grd_DocumentLog.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
								grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = "";
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(snp_DocLog["faalog_rolled_by_user_id"]))
								{
									if (Convert.ToString(snp_DocLog["faalog_rolled_by_user_id"]).Trim() != modGlobalVars.cEmptyString)
									{
										grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = Convert.ToString(snp_DocLog["faalog_rolled_by_user_id"]).Trim();
									}
								}

								// user ID
								grd_DocumentLog.CurrentColumnIndex = 9;
								grd_DocumentLog.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
								grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = "";
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(snp_DocLog["faalog_user_id"]))
								{
									if (Convert.ToString(snp_DocLog["faalog_user_id"]).Trim() != modGlobalVars.cEmptyString)
									{
										grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = Convert.ToString(snp_DocLog["faalog_user_id"]).Trim();
									}
								}

								// LOG ID
								grd_DocumentLog.CurrentColumnIndex = 10;
								grd_DocumentLog.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
								grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = "";
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(snp_DocLog["faalog_id"]))
								{
									if (Convert.ToString(snp_DocLog["faalog_id"]).Trim() != modGlobalVars.cEmptyString)
									{
										grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = Convert.ToString(snp_DocLog["faalog_id"]).Trim();
									}
								}

								// NOTES
								grd_DocumentLog.CurrentColumnIndex = 11;
								
								grd_DocumentLog.ColAlignment[11] = DataGridViewContentAlignment.TopLeft;
								grd_DocumentLog.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
								grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = "";
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(snp_DocLog["faalog_general_note"]))
								{
									if (Convert.ToString(snp_DocLog["faalog_general_note"]).Trim() != modGlobalVars.cEmptyString)
									{
										grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = Convert.ToString(snp_DocLog["faalog_general_note"]).Trim();
									}
								}

								// DOC ATTEMPTED
								grd_DocumentLog.CurrentColumnIndex = 12;
								
								grd_DocumentLog.ColAlignment[12] = DataGridViewContentAlignment.TopLeft;
								grd_DocumentLog.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
								grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = "";
								//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
								if (!Convert.IsDBNull(snp_DocLog["last_attempted"]))
								{
									if (Convert.ToString(snp_DocLog["last_attempted"]).Trim() != modGlobalVars.cEmptyString)
									{
										grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = Convert.ToString(snp_DocLog["last_attempted"]).Trim();
									}
								}

								if (is_compact_view == "Y")
								{
									grd_DocumentLog.CurrentColumnIndex = 13;
									
									grd_DocumentLog.ColAlignment[13] = DataGridViewContentAlignment.TopLeft;
									grd_DocumentLog.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
									grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = "";
									//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
									if (!Convert.IsDBNull(snp_DocLog["comp_state"]))
									{
										if (Convert.ToString(snp_DocLog["comp_state"]).Trim() != modGlobalVars.cEmptyString)
										{
											grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = Convert.ToString(snp_DocLog["comp_state"]).Trim();
										}
									}

									grd_DocumentLog.CurrentColumnIndex = 14;
									
									grd_DocumentLog.ColAlignment[14] = DataGridViewContentAlignment.TopLeft;
									grd_DocumentLog.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(cellcolor)));
									grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = "";
									//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
									if (!Convert.IsDBNull(snp_DocLog["comp_country"]))
									{
										if (Convert.ToString(snp_DocLog["comp_country"]).Trim() != modGlobalVars.cEmptyString)
										{
											grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = Convert.ToString(snp_DocLog["comp_country"]).Trim();
										}
									}

								}

								doc_ac = Convert.ToInt32(snp_DocLog["ac_id"]);


								grd_DocumentLog.set_RowData(grd_DocumentLog.CurrentRowIndex, Convert.ToInt32(snp_DocLog["ac_id"]));

								grd_DocumentLog.RowsCount++;
								grd_DocumentLog.CurrentRowIndex++;

								if (TotFound == 21)
								{
									grd_DocumentLog.Redraw = true;
									grd_DocumentLog.Refresh();
									Application.DoEvents();
									grd_DocumentLog.Redraw = false;
								}

							}
						}



						snp_DocLog.MoveNext();

					}; // Do While Not snp_DocLog.EOF

					grd_DocumentLog.RowsCount--;
					grd_DocumentLog.CurrentRowIndex = 1;
					grd_DocumentLog.CurrentColumnIndex = 0;

				}
				else
				{
					// no document log matches found

					grd_DocumentLog.CurrentRowIndex = 1;
					grd_DocumentLog.CurrentColumnIndex = 0;
					grd_DocumentLog[grd_DocumentLog.CurrentRowIndex, grd_DocumentLog.CurrentColumnIndex].Value = "No Documents Found.";

				} // if document log matches found

				grd_DocumentLog.Redraw = true;
				cmd_DocsInProcessRefresh.Enabled = true;

				cmdStop.Visible = false;

				search_off();
			}
			catch (Exception e)
			{

				search_off();

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				if (Information.Err().Number == 3146)
				{
					MessageBox.Show($"There are too many records to display.{Environment.NewLine}{Environment.NewLine}Please refine your search criteria and try again.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					this.Cursor = CursorHelper.CursorDefault;
					return;
				}
				else
				{
					MessageBox.Show($"Fill Aircraft Grid Error ActionList: {Environment.NewLine}{Environment.NewLine}{e.Message}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					this.Cursor = CursorHelper.CursorDefault;
					return;
				}
			}
		}

		private void Fix_Fract_Owners()
		{

			// THE PURPOSE OF THIS PROCEDURE IS TO PUT COMPANY INFORMATION FROM
			// CURRENT FRACTIONAL OWNER RECORDS TO THEIR HISTORICAL COMPANY RECORDS
			// IF INFORMATION IS MISSING.
			//
			// RTW - 4/22/2004 - PER LU
			// ******************************************************************
			string Query = "";
			ADORecordSetHelper ado_TargetHistory = new ADORecordSetHelper();
			ADORecordSetHelper ado_TargetCompany = new ADORecordSetHelper();
			ADORecordSetHelper ado_TargetPhone = new ADORecordSetHelper();
			ADORecordSetHelper ado_TargetContact = new ADORecordSetHelper();

			int countfix = 0;
			bool FoundFix = false;
			int totaltrans = 0;
			int countrec = 0;

			try
			{

				this.Cursor = Cursors.WaitCursor;
				countrec = 0;
				countfix = 0;
				totaltrans = 0;
				Query = "select * from company WITH(NOLOCK) ";
				Query = $"{Query}where comp_journ_id=0 ";
				//Query = Query & "and comp_business_type <> 'PH' "
				Query = $"{Query}AND (comp_upd_date >= '4/13/2004') AND (comp_fractowr_id > 0) AND (comp_active_flag = 'Y')";
				ado_TargetCompany.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);
				ADORecordSetHelper ado_AddPhone = null;
				ADORecordSetHelper ado_AddContact = null;
				if (!(ado_TargetCompany.BOF && ado_TargetCompany.EOF))
				{
					ado_TargetCompany.MoveFirst();

					while(!ado_TargetCompany.EOF)
					{
						countrec++;
						string tempRefParam = $"Updating Company {($"{Convert.ToString(ado_TargetCompany["comp_name"])}").Trim()} ... Found {countfix.ToString()} of {totaltrans.ToString()} for {countrec.ToString()} companies.";
						search_on(ref tempRefParam);
						// *************************************************
						// GET HISTORICAL COMPANIES

						//            Query = "select * from company  "
						//            Query = Query & "WHERE comp_id=" & ado_TargetCompany!comp_id & " "
						//            Query = Query & "and comp_journ_id > 0 "

						Query = "select company.* from company, journal ";
						Query = $"{Query}WHERE comp_id={Convert.ToString(ado_TargetCompany["comp_id"])} ";
						Query = $"{Query}and comp_journ_id > 0 ";
						Query = $"{Query}and comp_journ_id = journ_id ";
						Query = $"{Query}and journ_entry_date >= '11/1/2001' ";
						Query = $"{Query}and journ_subcategory_code like 'F%' ";
						ado_TargetHistory.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);
						if (!(ado_TargetHistory.BOF && ado_TargetHistory.EOF))
						{
							ado_TargetHistory.MoveFirst();

							while(!ado_TargetHistory.EOF)
							{
								totaltrans++;
								FoundFix = false;

								// FIX ADDRESS1
								if (($"{Convert.ToString(ado_TargetCompany["comp_address1"])}").Trim() != "" && ($"{Convert.ToString(ado_TargetHistory["comp_address1"])}").Trim() == "")
								{
									ado_TargetHistory["comp_address1"] = ($"{Convert.ToString(ado_TargetCompany["comp_address1"])}").Trim();
									ado_TargetHistory["comp_address1_search"] = modCommon.LeaveOnlyAlphaAndNumeric(($"{Convert.ToString(ado_TargetCompany["comp_address1"])} ").Trim()).ToUpper();
									FoundFix = true;
								}

								// FIX ADDRESS2
								if (($"{Convert.ToString(ado_TargetCompany["Comp_address2"])}").Trim() != "" && ($"{Convert.ToString(ado_TargetHistory["Comp_address2"])}").Trim() == "")
								{
									ado_TargetHistory["Comp_address2"] = ($"{Convert.ToString(ado_TargetCompany["Comp_address2"])}").Trim();
									ado_TargetHistory["comp_address2_search"] = modCommon.LeaveOnlyAlphaAndNumeric(($"{Convert.ToString(ado_TargetCompany["Comp_address2"])} ").Trim()).ToUpper();
									FoundFix = true;
								}

								// FIX CITY
								if (($"{Convert.ToString(ado_TargetCompany["Comp_city"])}").Trim() != "" && ($"{Convert.ToString(ado_TargetHistory["Comp_city"])}").Trim() == "")
								{
									ado_TargetHistory["Comp_city"] = ($"{Convert.ToString(ado_TargetCompany["Comp_city"])}").Trim();
									FoundFix = true;
								}

								// FIX STATE
								if (($"{Convert.ToString(ado_TargetCompany["comp_state"])}").Trim() != "" && ($"{Convert.ToString(ado_TargetHistory["comp_state"])}").Trim() == "")
								{
									ado_TargetHistory["comp_state"] = ($"{Convert.ToString(ado_TargetCompany["comp_state"])}").Trim();
									FoundFix = true;
								}


								// FIX ZIP
								if (($"{Convert.ToString(ado_TargetCompany["comp_zip_code"])}").Trim() != "" && ($"{Convert.ToString(ado_TargetHistory["comp_zip_code"])}").Trim() == "")
								{
									ado_TargetHistory["comp_zip_code"] = ($"{Convert.ToString(ado_TargetCompany["comp_zip_code"])}").Trim();
									FoundFix = true;
								}

								// FIX WEB ADDRESS
								if (($"{Convert.ToString(ado_TargetCompany["comp_web_address"])}").Trim() != "" && ($"{Convert.ToString(ado_TargetHistory["comp_web_address"])}").Trim() == "")
								{
									ado_TargetHistory["comp_web_address"] = ($"{Convert.ToString(ado_TargetCompany["comp_web_address"])}").Trim();
									FoundFix = true;
								}

								// FIX EMAIL ADDRESS
								if (($"{Convert.ToString(ado_TargetCompany["comp_email_address"])}").Trim() != "" && ($"{Convert.ToString(ado_TargetHistory["comp_email_address"])}").Trim() == "")
								{
									ado_TargetHistory["comp_email_address"] = ($"{Convert.ToString(ado_TargetCompany["comp_email_address"])}").Trim();
									FoundFix = true;
								}

								// TIMEZONE
								if (($"{Convert.ToString(ado_TargetCompany["comp_timezone"])}").Trim() != "" && ($"{Convert.ToString(ado_TargetHistory["comp_timezone"])}").Trim() == "")
								{
									ado_TargetHistory["comp_timezone"] = ($"{Convert.ToString(ado_TargetCompany["comp_timezone"])}").Trim();
									FoundFix = true;
								}

								// ****************************************************************
								// IF PHONE NUMBERS ON THIS HISTORY RECORD THEN IGNORE
								Query = "select * from Phone_Numbers WITH(NOLOCK) ";
								Query = $"{Query}WHERE pnum_comp_id={Convert.ToString(ado_TargetCompany["comp_id"])} ";
								Query = $"{Query}and pnum_journ_id = {Convert.ToString(ado_TargetHistory["comp_journ_id"])} ";
								if (!modAdminCommon.Exist(Query))
								{
									// IF NO HISTORICAL PHONE NUMBERS THEN GET THE CURRENT AND ADD THEM
									Query = "select * from Phone_Numbers WITH(NOLOCK) ";
									Query = $"{Query}WHERE pnum_comp_id={Convert.ToString(ado_TargetCompany["comp_id"])} ";
									Query = $"{Query}and pnum_journ_id = 0";
									ado_TargetPhone.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

									if (!(ado_TargetPhone.BOF && ado_TargetPhone.EOF))
									{
										ado_TargetPhone.MoveFirst();

										while(!ado_TargetPhone.EOF)
										{

											// MAKE A DUPLICATE COPY OF THE CURRENT COMPANY PHONE
											// NUMBERS ON THE HISTORICAL RECORDS
											ado_AddPhone = new ADORecordSetHelper();
											Query = "select * from Phone_Numbers where pnum_comp_id = -1";
											ado_AddPhone.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);
											//UPGRADE_ISSUE: (2064) ADODB.CursorOptionEnum property CursorOptionEnum.adAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
											//UPGRADE_ISSUE: (2064) ADODB.Recordset method ado_AddPhone.Supports was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
											if (ado_AddPhone.Supports(UpgradeStubs.ADODB_CursorOptionEnum.getadAddNew()))
											{
												ado_AddPhone.AddNew();
												int tempForEndVar = ado_TargetPhone.FieldsMetadata.Count - 1;
												for (int i = 0; i <= tempForEndVar; i++)
												{
													ado_AddPhone[i] = ado_TargetPhone[i];
												}
												ado_AddPhone["pnum_journ_id"] = ado_TargetHistory["comp_journ_id"];
												ado_AddPhone.Update();
												FoundFix = true;
											}
											if (ado_AddPhone.State == ConnectionState.Open)
											{
												ado_AddPhone.Close();
											}
											ado_AddPhone = null;
											ado_TargetPhone.MoveNext();
										};

									}
									ado_TargetPhone.Close();
									ado_TargetPhone = null;
								} // IF THERE ARE NO PHONE NUMBERS ON HISTORY


								// ****************************************************************
								// IF TRANSACTIONS ARE SINCE JANUARY 1 THEN LOOK AT THE CONTACTS
								Query = "select * from JournaL WITH(NOLOCK) ";
								Query = $"{Query}WHERE journ_id={Convert.ToString(ado_TargetHistory["comp_journ_id"])} ";
								Query = $"{Query}and journ_date >= '1/1/2004'";
								if (modAdminCommon.Exist(Query))
								{

									// ****************************************************************
									// IF CONTACTS ON THIS HISTORY RECORD THEN IGNORE
									Query = "select * from Contact WITH(NOLOCK) ";
									Query = $"{Query}WHERE contact_comp_id={Convert.ToString(ado_TargetCompany["comp_id"])} ";
									Query = $"{Query}and contact_journ_id = {Convert.ToString(ado_TargetHistory["comp_journ_id"])} ";
									if (!modAdminCommon.Exist(Query))
									{
										// IF NO HISTORICAL PHONE NUMBERS THEN GET THE CURRENT AND ADD THEM
										Query = "select * from Contact ";
										Query = $"{Query}WHERE contact_comp_id={Convert.ToString(ado_TargetCompany["comp_id"])} ";
										Query = $"{Query}and contact_journ_id = 0";
										ado_TargetContact.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);
										if (!(ado_TargetContact.BOF && ado_TargetContact.EOF))
										{
											ado_TargetContact.MoveFirst();

											while(!ado_TargetContact.EOF)
											{

												// MAKE A DUPLICATE COPY OF THE CURRENT COMPANY PHONE
												// NUMBERS ON THE HISTORICAL RECORDS
												ado_AddContact = new ADORecordSetHelper();
												Query = "select * from Contact where contact_comp_id = -1";
												ado_AddContact.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);
												//UPGRADE_ISSUE: (2064) ADODB.CursorOptionEnum property CursorOptionEnum.adAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
												//UPGRADE_ISSUE: (2064) ADODB.Recordset method ado_AddContact.Supports was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
												if (ado_AddContact.Supports(UpgradeStubs.ADODB_CursorOptionEnum.getadAddNew()))
												{
													ado_AddContact.AddNew();
													int tempForEndVar2 = ado_TargetContact.FieldsMetadata.Count - 1;
													for (int i = 0; i <= tempForEndVar2; i++)
													{
														ado_AddContact[i] = ado_TargetContact[i];
													}
													ado_AddContact["contact_journ_id"] = ado_TargetHistory["comp_journ_id"];
													ado_AddContact.Update();
													FoundFix = true;
												}
												if (ado_AddContact.State == ConnectionState.Open)
												{ //status changed to state aey 7/20/04
													ado_AddContact.Close();
												}
												ado_AddContact = null;
												ado_TargetContact.MoveNext();
											};

										}
										ado_TargetContact.Close();
										ado_TargetContact = null;
									} // IF THERE ARE NO PHONE NUMBERS ON HISTORY
								} // IF TRANSACTION IS SINCE JANUARY 1

								// DID WE FIND THE RECORD
								if (FoundFix)
								{
									countfix++;
									//MsgBox ("found")
									//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
									ado_TargetHistory["comp_action_date"] = DBNull.Value;
									ado_TargetHistory["comp_upd_user_id"] = "mvit";
								}
								ado_TargetHistory.Update();
								ado_TargetHistory.MoveNext();
							};
						}
						ado_TargetHistory.Close();
						ado_TargetHistory = null;
						ado_TargetCompany.MoveNext();
						//Search_Off
					};
				}
				ado_TargetCompany.Close();
				ado_TargetCompany = null;
				MessageBox.Show($"Found {countfix.ToString()} of {totaltrans.ToString()} for {countrec.ToString()} companies", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));

				search_off();
			}
			catch
			{

				search_off();
				modAdminCommon.Report_Error($"Fix_Fract_Owners_Error: {Query}");
			}

		}





		public modGlobalVars.e_first_start_form StartForm
		{
			get => modGlobalVars.tStart_Form;
			set => modGlobalVars.tStart_Form = value;
		}



		//UPGRADE_NOTE: (7001) The following declaration (txt_Total_AbiCounter_Change) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void txt_Total_AbiCounter_Change()
		//{
			//
		//}

		public void Fill_Timezones()
		{

			ADORecordSetHelper snpTimeZone = new ADORecordSetHelper();

			cbo_Timezones.Items.Clear();
			cbo_Timezones.AddItem("All");

			string Query = "SELECT tzone_name FROM Timezone ";
			Query = $"{Query}ORDER BY tzone_name";

			//Set snpTimeZone = LOCAL_DB.OpenRecordset(Query, dbOpenSnapshot, dbSQLPassThrough)
			snpTimeZone.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

			if (!(snpTimeZone.BOF && snpTimeZone.EOF))
			{
				snpTimeZone.MoveFirst();

				while(!snpTimeZone.EOF)
				{
					cbo_Timezones.AddItem(($"{Convert.ToString(snpTimeZone["tzone_name"])}").Trim());
					snpTimeZone.MoveNext();
				};
			}
			cbo_Timezones.AddItem("International");

			cbo_Timezones.SelectedIndex = 0;
			snpTimeZone.Close();

		} // Fill_Timezones

		private void Fill_TimeScale()
		{

			cbo_TimeScale.Items.Clear();
			// 08/03/2016 - By David D. Cruger
			// Per Jackie; Have the Default To ALL
			// Note; It was set to Weekly for speed issues
			cbo_TimeScale.AddItem("All");
			cbo_TimeScale.AddItem("Week");
			cbo_TimeScale.AddItem("Month");
			cbo_TimeScale.AddItem("Year");

			cbo_TimeScale.SelectedIndex = 0;

		}

		private void Fill_Document_Type()
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();
			string strQuery1 = "";

			try
			{

				strQuery1 = "SELECT doctype_code, doctype_description ";
				strQuery1 = $"{strQuery1}FROM Document_Type WITH (NOLOCK) ";
				strQuery1 = $"{strQuery1}WHERE (doctype_subdir_name = 'FAAPDF') ";
				strQuery1 = $"{strQuery1}AND (doctype_contract_doc_view = 'N') ";
				strQuery1 = $"{strQuery1}AND (doctype_company_doc_view = 'N') ";
				strQuery1 = $"{strQuery1}ORDER BY doctype_code";

				rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!rstRec1.BOF && !rstRec1.EOF)
				{

					cmbDocType.Items.Clear();
					do 
					{ // Loop Until rstRec1.EOF = True

						cmbDocType.AddItem($"{($"{Convert.ToString(rstRec1["doctype_code"])} ").Trim()} - {($"{Convert.ToString(rstRec1["doctype_description"])} ").Trim()}");
						rstRec1.MoveNext();

					}
					while(!rstRec1.EOF);

				} // If rstRec1.BOF = False And rstRec1.EOF = False Then

				rstRec1.Close();

				rstRec1 = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error("Fill_Document_Type", excep.Message);
			}

		} // End Sub
	}
}