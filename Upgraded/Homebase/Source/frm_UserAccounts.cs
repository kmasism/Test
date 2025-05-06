using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Gui.Controls;
using UpgradeHelpers.Gui.Utils;
using UpgradeHelpers.Helpers;
using UpgradeStubs;

namespace JETNET_Homebase
{
	internal partial class frm_UserAccounts
		: System.Windows.Forms.Form
	{



		private bool HadHourglass = false;
		private bool mvHasFocus = false;
		private bool Stopped = false;
		private ADORecordSetHelper snp_Assign = null; //8/1/05 aey converted to ado Snapshot
		private ADORecordSetHelper snp_ACSummary = null; //8/1/05 aey converted to ado Snapshot
		private string strAssignSort = "";
		private double Total_Aircraft = 0;
		private double Total_Automatic_Aircraft = 0;
		private double Total_Manual_Aircraft = 0;
		private double Total_Company = 0;
		private double Total_Automatic_Company = 0;
		private double Total_Manual_Company = 0;
		private double Total_Prime_Company = 0; //
		private double Total_Prime_Automatic_Company = 0;
		private double Total_Prime_Manual_Company = 0;
		private ADORecordSetHelper _snp_Unassign = null;
		public frm_UserAccounts()
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


		private ADORecordSetHelper snp_Unassign
		{
			get
			{
				if (_snp_Unassign is null)
				{
					_snp_Unassign = new ADORecordSetHelper();
				}
				return _snp_Unassign;
			}
			set => _snp_Unassign = value;
		}
		 //8/1/05 aey converted to ado  Snapshot
		private string tmp_db_account_id = "";
		private string tmp_eu_account_id = "";

		public string tmpAcctID = "";

		private int AC_Row = 0;
		private string tmpStart = "";
		private int tmpHowLong = 0;

		private void AddResearchNotesToGrid()
		{

			string LookFor = "";
			string tmpUser = "";
			string Query = "";
			ADORecordSetHelper snpDel = new ADORecordSetHelper(); //aey 8/1/05 converted to ado
			ADORecordSetHelper GetAccComp = new ADORecordSetHelper();
			string errMsg = "";


			try
			{

				errMsg = "setup";
				grdSchedule.RowsCount += 2;
				grdSchedule.CurrentRowIndex = grdSchedule.RowsCount - 1;
				grdSchedule.CurrentColumnIndex = 0;

				grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].Value = "Added Wanted";

				LookFor = "Added Wanted";
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Counting Wanted Adds ...", Color.Blue);

				errMsg = "loop";

				int tempForEndVar = grdSchedule.ColumnsCount - 1;
				for (int i = 1; i <= tempForEndVar; i++)
				{

					grdSchedule.CurrentRowIndex = 0;
					grdSchedule.CurrentColumnIndex = i;

					tmpUser = GetUserLogin(grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString());
					modStatusBar.Update_Status_Bar(modAdminCommon.SB, $"Counting Wanted Adds ... for {tmpUser}", Color.Blue);
					grdSchedule.CurrentRowIndex = grdSchedule.RowsCount - 1;

					grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].Value = GetRNCount(tmpUser, LookFor);

				}

				errMsg = "count";

				grdSchedule.RowsCount++;
				grdSchedule.CurrentRowIndex = grdSchedule.RowsCount - 1;
				grdSchedule.CurrentColumnIndex = 0;

				grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].Value = "Removed Wanted";
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Counting Wanted Removes ...", Color.Blue);

				errMsg = "cols";

				int tempForEndVar2 = grdSchedule.ColumnsCount - 1;
				for (int i = 1; i <= tempForEndVar2; i++)
				{

					grdSchedule.CurrentRowIndex = 0;
					grdSchedule.CurrentColumnIndex = i;

					tmpUser = GetUserLogin(grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString());

					grdSchedule.CurrentRowIndex = grdSchedule.RowsCount - 1;

					//grdSchedule.Text = GetDeleteCount(tmpUser, LookFor)
					errMsg = "count";

					Query = "SELECT count(*) AS DelCount  FROM Delete_Log WITH (NOLOCK) ";
					Query = $"{Query}WHERE dlog_entry_user = '{tmpUser}'  AND dlog_type = 'Wanted' ";

					if (chkIgnoreSchedDate1.CheckState == CheckState.Unchecked)
					{

						// ADD IN THE START TIME
						if (Strings.Len(txt_start_time.Text.Trim()) > 0)
						{
							Query = $"{Query}AND dlog_entry_date >= '{MonthView1.SelectionRange.Start.ToString("d")} {txt_start_time.Text.Trim()}' ";
						}
						else
						{
							Query = $"{Query}AND dlog_entry_date >= '{MonthView1.SelectionRange.Start.ToString("d")}' ";
						}

					} // If chkIgnoreSchedDate1.Value = vbUnchecked Then

					if (chkIgnoreSchedDate2.CheckState == CheckState.Unchecked)
					{

						// ADD IN THE END TIME
						if (Strings.Len(txt_end_time.Text.Trim()) > 0)
						{
							Query = $"{Query}AND dlog_entry_date <= '{MonthView2.SelectionRange.Start.ToString("d")} {txt_end_time.Text.Trim()}' ";
						}
						else
						{
							Query = $"{Query}AND dlog_entry_date <= '{MonthView2.SelectionRange.Start.ToString("d")}' ";
						}

					} // If chkIgnoreSchedDate2.Value = vbUnchecked Then

					snpDel.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					modStatusBar.Update_Status_Bar(modAdminCommon.SB, $"Counting Wanted Removes ... for {tmpUser}", Color.Blue);
					if (!snpDel.BOF && !snpDel.EOF)
					{
						snpDel.MoveFirst();
						grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].Value = ($"{Convert.ToString(snpDel["DelCount"])}").Trim();
					}
					else
					{
						grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].Value = "0";
					} // If (snpDel.BOF = False And snpDel.EOF = False) Then

					snpDel.Close();
					snpDel = null;

				}


				int daysconfirm = 0;
				System.DateTime targetdate = DateTime.FromOADate(0);
				string strTargetDate = "";
				ADORecordSetHelper GetAccConfirm = new ADORecordSetHelper();

				int accountcompaniestoconfirm = 0;
				int accountcompanies = 0;
				int accountcompaniesconfirmed = 0;
				string tmpAccountRep = "";

				errMsg = "rows";

				grdSchedule.RowsCount += 2;
				grdSchedule.CurrentRowIndex = grdSchedule.RowsCount - 1;
				grdSchedule.CurrentColumnIndex = 0;
				grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].Value = "COMPANY CONFIRMATION STATS ";
				grdSchedule.CellFontBold = true;
				grdSchedule.RowsCount++;
				grdSchedule.CurrentRowIndex = grdSchedule.RowsCount - 1;
				grdSchedule.CurrentColumnIndex = 0;

				errMsg = "total co";

				grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].Value = "Total Rep Companies ";
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Total Companies  ...", Color.Blue);

				int tempForEndVar3 = grdSchedule.ColumnsCount - 1;
				for (int i = 1; i <= tempForEndVar3; i++)
				{

					grdSchedule.CurrentRowIndex = 0;
					grdSchedule.CurrentColumnIndex = i;

					tmpUser = grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().Substring(Math.Min(grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().IndexOf('[') + 1, grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().Length), Math.Min((grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().IndexOf(']') + 1) - (grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().IndexOf('[') + 1) - 1, Math.Max(0, grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().Length - (grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().IndexOf('[') + 1))));

					tmpAccountRep = GetUserAccountRep(tmpUser);
					modStatusBar.Update_Status_Bar(modAdminCommon.SB, $"Total Companies ... for {tmpUser}", Color.Blue);

					Query = "SELECT COUNT(comp_id) AS TotCnt FROM Company WITH (NOLOCK) ";
					Query = $"{Query}WHERE (comp_journ_id = 0) AND (comp_active_flag = 'Y') AND (comp_account_id = '{tmpAccountRep.Trim()}') ";

					GetAccComp.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					accountcompanies = 0;
					if (!GetAccComp.BOF && !GetAccComp.EOF)
					{
						accountcompanies = Convert.ToInt32(GetAccComp["TotCnt"]);
					}

					GetAccComp.Close();
					GetAccComp = null;

					grdSchedule.CurrentRowIndex = grdSchedule.RowsCount - 1;

					grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].Value = Conversion.Val($"{accountcompanies.ToString()}");

				}

				errMsg = "verify";

				grdSchedule.RowsCount++;
				grdSchedule.CurrentRowIndex = grdSchedule.RowsCount - 1;
				grdSchedule.CurrentColumnIndex = 0;
				grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].Value = "Total Rep Companies Unverified";
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Total Rep Companies Unverified ...", Color.Blue);

				int tempForEndVar4 = grdSchedule.ColumnsCount - 1;
				for (int i = 1; i <= tempForEndVar4; i++)
				{

					grdSchedule.CurrentRowIndex = 0;
					grdSchedule.CurrentColumnIndex = i;

					tmpUser = grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().Substring(Math.Min(grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().IndexOf('[') + 1, grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().Length), Math.Min((grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().IndexOf(']') + 1) - (grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().IndexOf('[') + 1) - 1, Math.Max(0, grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().Length - (grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().IndexOf('[') + 1))));
					tmpAccountRep = GetUserAccountRep(tmpUser);
					modStatusBar.Update_Status_Bar(modAdminCommon.SB, $"Total Rep Companies Unverified... for {tmpUser}", Color.Blue);

					daysconfirm = Convert.ToInt32(Double.Parse(cbo_days_confirm.Text));

					targetdate = DateTime.Parse(modAdminCommon.DateToday).AddDays(-daysconfirm);
					strTargetDate = targetdate.ToString("MM/dd/yyyy");

					Query = "SELECT COUNT(DISTINCT comp_id) As TotCnt FROM Company WITH (NOLOCK) ";
					Query = $"{Query}WHERE (comp_journ_id = 0) AND (comp_active_flag = 'Y') AND (comp_account_id = '{tmpAccountRep}') ";
					Query = $"{Query}AND (comp_address_confirm_date IS NULL   OR comp_address_confirm_date <= '{strTargetDate}' ";
					Query = $"{Query}  OR comp_web_confirm_date IS NULL   OR comp_web_confirm_date <= '{strTargetDate}' ";
					Query = $"{Query}  OR comp_email_confirm_date IS NULL  OR comp_email_confirm_date <= '{strTargetDate}' ";
					Query = $"{Query}  OR (EXISTS (SELECT NULL FROM Phone_Numbers WITH (NOLOCK)    WHERE (pnum_comp_id = comp_id) ";
					Query = $"{Query}              AND (pnum_journ_id = comp_journ_id) ";
					Query = $"{Query}              AND (pnum_contact_id = 0) ";
					Query = $"{Query}              AND (pnum_confirm_date = NULL OR pnum_confirm_date <= '{strTargetDate}') ";
					Query = $"{Query}              )     )     ) ";

					GetAccConfirm.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					accountcompaniestoconfirm = 0;
					if (!GetAccConfirm.BOF && !GetAccConfirm.EOF)
					{
						accountcompaniestoconfirm = Convert.ToInt32(GetAccConfirm["TotCnt"]);
					}

					GetAccConfirm.Close();
					GetAccConfirm = null;

					grdSchedule.CurrentRowIndex = grdSchedule.RowsCount - 1;

					grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].Value = accountcompaniestoconfirm;

				}

				// ******************************************
				// PERCENTAGE OF TOTAL COMPANIES VERIFIED
				errMsg = "pct verify";

				grdSchedule.RowsCount++;
				grdSchedule.CurrentRowIndex = grdSchedule.RowsCount - 1;
				grdSchedule.CurrentColumnIndex = 0;
				grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].Value = "Total Rep Companies Verified";
				int tempForEndVar5 = grdSchedule.ColumnsCount - 1;
				double percentcompverified = 0;
				for (int i = 1; i <= tempForEndVar5; i++)
				{

					grdSchedule.CurrentRowIndex = 0;
					grdSchedule.CurrentColumnIndex = i;

					tmpUser = grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().Substring(Math.Min(grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().IndexOf('[') + 1, grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().Length), Math.Min((grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().IndexOf(']') + 1) - (grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().IndexOf('[') + 1) - 1, Math.Max(0, grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().Length - (grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().IndexOf('[') + 1))));
					tmpAccountRep = GetUserAccountRep(tmpUser);
					modStatusBar.Update_Status_Bar(modAdminCommon.SB, $"Total Rep Companies Verified ... for {tmpUser}", Color.Blue);

					accountcompaniestoconfirm = 0;

					// get to the row we want for text
					grdSchedule.CurrentRowIndex = grdSchedule.RowsCount - 1;
					// move back one to get companies to confirm
					grdSchedule.CurrentRowIndex--;
					accountcompaniestoconfirm = Convert.ToInt32(Conversion.Val(grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString()));
					// move back one to get the total companies
					grdSchedule.CurrentRowIndex--;
					accountcompanies = Convert.ToInt32(Conversion.Val(grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString()));
					accountcompaniesconfirmed = accountcompanies - accountcompaniestoconfirm;
					grdSchedule.CurrentRowIndex += 2;
					if (accountcompanies > 0)
					{
						percentcompverified = (accountcompaniesconfirmed / ((double) accountcompanies)) * 100;
					}
					else
					{
						percentcompverified = 0;
					}
					grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].Value = $"{accountcompaniesconfirmed.ToString()} ({Strings.FormatNumber(percentcompverified, 1, TriState.True, TriState.True, TriState.True)}%)";

				}

				errMsg = "primary";

				grdSchedule.RowsCount += 2;
				grdSchedule.CurrentRowIndex = grdSchedule.RowsCount - 1;
				grdSchedule.CurrentColumnIndex = 0;

				grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].Value = "Total Rep Primary Companies ";
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Total Rep Primary Companies  ...", Color.Blue);

				int tempForEndVar6 = grdSchedule.ColumnsCount - 1;
				for (int i = 1; i <= tempForEndVar6; i++)
				{

					grdSchedule.CurrentRowIndex = 0;
					grdSchedule.CurrentColumnIndex = i;

					tmpUser = grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().Substring(Math.Min(grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().IndexOf('[') + 1, grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().Length), Math.Min((grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().IndexOf(']') + 1) - (grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().IndexOf('[') + 1) - 1, Math.Max(0, grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().Length - (grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().IndexOf('[') + 1))));

					tmpAccountRep = GetUserAccountRep(tmpUser);
					modStatusBar.Update_Status_Bar(modAdminCommon.SB, $"Total Primary Companies ... for {tmpUser}", Color.Blue);

					Query = "SELECT COUNT(DISTINCT comp_id) AS TotCnt  FROM Company WITH (NOLOCK) ";
					Query = $"{Query}WHERE (comp_journ_id = 0) AND (comp_active_flag = 'Y') ";
					Query = $"{Query}AND (comp_account_id = '{tmpAccountRep}') AND (EXISTS (SELECT NULL  ";
					Query = $"{Query}             FROM Aircraft_Reference WITH (NOLOCK) ";
					Query = $"{Query}             WHERE (cref_comp_id = comp_id)   AND (cref_journ_id = comp_journ_id)    AND (cref_primary_poc_flag = 'Y')    )    ) ";

					GetAccComp.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					accountcompanies = 0;
					if (!GetAccComp.BOF && !GetAccComp.EOF)
					{
						accountcompanies = Convert.ToInt32(GetAccComp["TotCnt"]);
					}

					GetAccComp.Close();
					GetAccComp = null;

					grdSchedule.CurrentRowIndex = grdSchedule.RowsCount - 1;

					grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].Value = accountcompanies;

				}

				// *********************************************************
				// GET THE ACCOUNT REP PRIMARY COMPANIES NEEDING VERIFICATION
				errMsg = "primary needs verify";

				grdSchedule.RowsCount++;
				grdSchedule.CurrentRowIndex = grdSchedule.RowsCount - 1;
				grdSchedule.CurrentColumnIndex = 0;
				grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].Value = "Total Rep Primary Companies Unverified";
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Total Primary Companies Unverified ...", Color.Blue);

				int tempForEndVar7 = grdSchedule.ColumnsCount - 1;
				for (int i = 1; i <= tempForEndVar7; i++)
				{

					grdSchedule.CurrentRowIndex = 0;
					grdSchedule.CurrentColumnIndex = i;

					tmpUser = grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().Substring(Math.Min(grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().IndexOf('[') + 1, grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().Length), Math.Min((grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().IndexOf(']') + 1) - (grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().IndexOf('[') + 1) - 1, Math.Max(0, grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().Length - (grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().IndexOf('[') + 1))));
					tmpAccountRep = GetUserAccountRep(tmpUser);
					modStatusBar.Update_Status_Bar(modAdminCommon.SB, $"Total Primary Companies Unverified... for {tmpUser}", Color.Blue);

					daysconfirm = Convert.ToInt32(Double.Parse(cbo_days_confirm.Text));

					// 05/01/2008 - By David D. Cruger
					// Target Date must be mm/dd/yyyy format
					// Most of the confirm dates are smalldatetime fields

					targetdate = DateTime.Parse(modAdminCommon.DateToday).AddDays(-daysconfirm);
					strTargetDate = targetdate.ToString("MM/dd/yyyy");

					Query = "SELECT COUNT(DISTINCT comp_id) As TotCnt FROM  Company WITH (NOLOCK) ";
					Query = $"{Query}INNER JOIN Aircraft_Reference WITH (NOLOCK) ON comp_id = cref_comp_id AND comp_journ_id = cref_journ_id ";
					Query = $"{Query}WHERE (comp_journ_id = 0) AND (comp_active_flag = 'Y') ";
					Query = $"{Query}AND (cref_primary_poc_flag = 'Y') AND (comp_account_id = '{tmpAccountRep}') ";
					Query = $"{Query}AND (comp_address_confirm_date = NULL   OR comp_address_confirm_date <= '{strTargetDate}' ";
					Query = $"{Query}  OR comp_web_confirm_date = NULL ";
					Query = $"{Query}  OR comp_web_confirm_date <= '{strTargetDate}' ";
					Query = $"{Query}  OR comp_email_confirm_date = NULL ";
					Query = $"{Query}  OR comp_email_confirm_date <= '{strTargetDate}' ";
					Query = $"{Query}  OR (EXISTS (SELECT NULL FROM Phone_Numbers WITH (NOLOCK) ";
					Query = $"{Query}              WHERE (pnum_comp_id = Comp_id) ";
					Query = $"{Query}              AND (pnum_journ_id = comp_journ_id) ";
					Query = $"{Query}              AND (pnum_contact_id = 0) ";
					Query = $"{Query}              AND (pnum_confirm_date = NULL OR pnum_confirm_date <= '{strTargetDate}') ";
					Query = $"{Query}              )   )    ) ";

					GetAccConfirm.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					accountcompaniestoconfirm = 0;
					if (!GetAccConfirm.BOF && !GetAccConfirm.EOF)
					{
						accountcompaniestoconfirm = Convert.ToInt32(GetAccConfirm["TotCnt"]);
					}

					GetAccConfirm.Close();
					GetAccConfirm = null;

					grdSchedule.CurrentRowIndex = grdSchedule.RowsCount - 1;

					grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].Value = accountcompaniestoconfirm;

				}

				errMsg = "pct verified";

				grdSchedule.RowsCount++;
				grdSchedule.CurrentRowIndex = grdSchedule.RowsCount - 1;
				grdSchedule.CurrentColumnIndex = 0;
				grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].Value = "Total Rep Primary Companies Verified";
				int tempForEndVar8 = grdSchedule.ColumnsCount - 1;
				for (int i = 1; i <= tempForEndVar8; i++)
				{

					grdSchedule.CurrentRowIndex = 0;
					grdSchedule.CurrentColumnIndex = i;

					tmpUser = grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().Substring(Math.Min(grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().IndexOf('[') + 1, grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().Length), Math.Min((grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().IndexOf(']') + 1) - (grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().IndexOf('[') + 1) - 1, Math.Max(0, grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().Length - (grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().IndexOf('[') + 1))));
					tmpAccountRep = GetUserAccountRep(tmpUser);
					modStatusBar.Update_Status_Bar(modAdminCommon.SB, $"Total Primary Companies Needing Verification... for {tmpUser}", Color.Blue);

					accountcompaniestoconfirm = 0;

					// get to the row we want for text
					grdSchedule.CurrentRowIndex = grdSchedule.RowsCount - 1;
					// move back one to get companies to confirm
					grdSchedule.CurrentRowIndex--;
					accountcompaniestoconfirm = Convert.ToInt32(Conversion.Val($"{grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString()}"));
					// move back one to get the total companies
					grdSchedule.CurrentRowIndex--;
					accountcompanies = Convert.ToInt32(Conversion.Val(grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString()));
					accountcompaniesconfirmed = accountcompanies - accountcompaniestoconfirm;
					grdSchedule.CurrentRowIndex += 2;
					if (accountcompanies > 0)
					{
						percentcompverified = (accountcompaniesconfirmed / ((double) accountcompanies)) * 100;
					}
					else
					{
						percentcompverified = 0;
					}
					grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].Value = $"{accountcompaniesconfirmed.ToString()} ({Strings.FormatNumber(percentcompverified, 1, TriState.True, TriState.True, TriState.True)}%)";

				}
			}
			catch (System.Exception excep)
			{
				Application.DoEvents();
				modAdminCommon.Report_Error($"AddResearchNotesToGrid_Error: {excep.Message} {errMsg}", "User_Accounts");

				this.Cursor = CursorHelper.CursorDefault;
			}

		}

		private void CallAccountRepActivityWebPage()
		{

			string strURL = "";

			string strTemp = "";
			System.DateTime dtStartDate = DateTime.FromOADate(0);
			System.DateTime tStartTime = DateTime.FromOADate(0);
			System.DateTime dtEndDate = DateTime.FromOADate(0);
			System.DateTime tEndTime = DateTime.FromOADate(0);
			int iPos1 = 0;

			string strAcctRep = lstAcctRep.Text.ToUpper();

			if (strAcctRep != "")
			{

				iPos1 = (strAcctRep.IndexOf('-') + 1);
				if (iPos1 > 0)
				{
					strAcctRep = strAcctRep.Substring(0, Math.Min(iPos1 - 1, strAcctRep.Length)).Trim().ToUpper();
				}

				if (strAcctRep != "ALL")
				{

					strAcctRep = "";
					int tempForEndVar = lstAcctRep.Items.Count - 1;
					for (int iCnt1 = 1; iCnt1 <= tempForEndVar; iCnt1++)
					{
						if (ListBoxHelper.GetSelected(lstAcctRep, iCnt1))
						{
							strTemp = lstAcctRep.GetListItem(iCnt1).ToUpper();
							iPos1 = (strTemp.IndexOf('-') + 1);
							strTemp = strTemp.Substring(0, Math.Min(iPos1 - 1, strTemp.Length)).Trim();
							strAcctRep = $"{strAcctRep}{strTemp},";
						}
					}
					strAcctRep = strAcctRep.Trim();
					strAcctRep = strAcctRep.Substring(0, Math.Min(Strings.Len(strAcctRep) - 1, strAcctRep.Length));

					dtStartDate = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy"));
					tStartTime = DateTime.FromOADate(0);
					dtEndDate = DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy"));
					tStartTime = DateTime.FromOADate(0);

					if (Information.IsDate(txtDate1.Text))
					{
						dtStartDate = DateTime.Parse(DateTime.Parse(txtDate1.Text).ToString("MM/dd/yyyy"));
					}

					if (Information.IsDate(txtDate2.Text))
					{
						dtEndDate = DateTime.Parse(DateTime.Parse(txtDate2.Text).ToString("MM/dd/yyyy"));
					}

					if (Information.IsDate(txt_start_time.Text))
					{
						tStartTime = DateTime.Parse(DateTime.Parse(txt_start_time.Text).ToString("HH:mm:ss"));
					}

					if (Information.IsDate(txt_end_time.Text))
					{
						tEndTime = DateTime.Parse(DateTime.Parse(txt_end_time.Text).ToString("HH:mm:ss"));
					}

					strURL = modCommon.DLookUp("aconfig_website", "Application_Configuration");
					if (strURL.Substring(Math.Max(strURL.Length - 1, 0)) != "/")
					{
						strURL = $"{strURL}/help/accountrepactivitydisplay.asp";
					}
					strURL = $"{strURL}?UserIdACCTRep={strAcctRep}&StartDate={dtStartDate.ToString("MM/dd/yyyy")}";
					strURL = $"{strURL}&EndDate={dtEndDate.ToString("MM/dd/yyyy")}";

					strURL = $"{strURL}&StartTime=";
					if (tStartTime > DateTime.FromOADate(0))
					{
						strURL = $"{strURL}{tStartTime.ToString("HH:mm:ss")}";
					}

					strURL = $"{strURL}&EndTime=";
					if (tEndTime > DateTime.FromOADate(0))
					{
						strURL = $"{strURL}{tEndTime.ToString("HH:mm:ss")}";
					}

					wbAcctRepActivity.Navigate(new Uri(strURL));

				}
				else
				{
					MessageBox.Show("Account Rep List Box Can NOT Select ALL", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
				} // If strAcctRep <> "ALL" Then

			}
			else
			{
				MessageBox.Show("Nothing Selected In The Account Rep List Box", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
			} // If strAcctRep <> "" And strAcctRep <> "All" Then

		} // CallAccountRepActivityWebPage

		//UPGRADE_NOTE: (7001) The following declaration (FillActivityGrid) seems to be dead code More Information: https://docs.mobilize.net/vbuc/ewis/notes#id-7001
		//private void FillActivityGrid()
		//{
			//
			//string strMsg = "";
			//System.DateTime dtStartDate = DateTime.FromOADate(0);
			//System.DateTime dtEndDate = DateTime.FromOADate(0);
			//
			//string Query = "";
			//ADORecordSetHelper snpJourn = new ADORecordSetHelper();
			//ADORecordSetHelper snpCategories = new ADORecordSetHelper(); //aey 8/1/05 converted to ado
			//
			//int ColOffset = 0;
			//int totCount = 0;
			//int GrandTotal = 0;
			//int totAcctRep = 0;
			//int Percentage = 0;
			//int tmpForCalc = 0;
			//string strUserId = "";
			//string strAcctRep = "";
			//
			//try
			//{
				//
				//if (!Check_Time(txt_start_time.Text))
				//{
					//MessageBox.Show("Start Time is not in the correct format.  Please correct.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					//return;
				//}
				//if (!Check_Time(txt_end_time.Text))
				//{
					//MessageBox.Show("End Time is not in the correct format.  Please correct.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					//return;
				//}
				//if (ListBoxHelper.GetSelected(lstAcctRep, 0))
				//{
					//MessageBox.Show("Cannot Run ALL for Account Rep Activity Report", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
					//return;
				//}
				//
				//modCommon.Start_Activity_Monitor_Message("AcctRep Activity", ref strMsg, ref dtStartDate, ref dtEndDate);
				//
				//this.Cursor = Cursors.WaitCursor;
				//modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Getting Activity Information ...", Color.Blue);
				//modAdminCommon.Record_Event("User_Accounts AcctRepActivity", $"{Convert.ToString(modAdminCommon.snp_User["user_id"])} Started ", 0, 0, 0, true);
				//tmpStart = DateTime.Parse(modAdminCommon.GetDateTime()).ToString("HH:mm:ss");
				//
				//ColOffset = 0;
				//tmpAcctID = "";
				//
				//lstCompany.Items.Clear();
				//lstCompany.Visible = false;
				//
				//grdSchedule.Clear();
				//grdSchedule.ColumnsCount = 1;
				//grdSchedule.RowsCount = 1;
				//grdSchedule.FixedColumns = 0;
				//grdSchedule.FixedRows = 0;
				//
				////*********************************************************
				//// FIRST, GET ALL THE POSSIBLE ROW HEADINGS (SUBCATEGORIES)
				//Query = "SELECT DISTINCT jcat_subcategory_name  FROM Journal WITH(NOLOCK) , Journal_Category ";
				//Query = $"{Query}WHERE journ_subcategory_code = jcat_subcategory_code ";
				//Query = $"{Query}AND journ_user_id IS NOT NULL AND journ_user_id <> '' ";
				//
				//if (!ListBoxHelper.GetSelected(lstAcctRep, 0))
				//{
					//Query = $"{Query}AND journ_user_id in (";
					//int tempForEndVar = lstAcctRep.Items.Count - 1;
					//for (int i = 1; i <= tempForEndVar; i++)
					//{
						//if (ListBoxHelper.GetSelected(lstAcctRep, i))
						//{
							////*******************************
							////THE USER ID IS BEFORE THE "-"
							//Query = $"{Query}'{lstAcctRep.GetListItem(i).Substring(0, Math.Min(lstAcctRep.GetListItem(i).IndexOf('-'), lstAcctRep.GetListItem(i).Length)).Trim()}', ";
						//}
					//}
					//
					//Query = $"{Query.Substring(0, Math.Min(Strings.Len(Query) - 2, Query.Length))}) ";
				//}
				//
				//if (chkIgnoreSchedDate1.CheckState == CheckState.Unchecked)
				//{
					//
					//
					//if (Strings.Len(txt_start_time.Text.Trim()) > 0)
					//{
						//Query = $"{Query}AND journ_entry_date >= '{MonthView1.SelectionRange.Start.ToString("MM/dd/yyyy")} {txt_start_time.Text.Trim()}' ";
					//}
					//else
					//{
						//Query = $"{Query}AND journ_entry_date >= '{MonthView1.SelectionRange.Start.ToString("MM/dd/yyyy")}' ";
					//}
					//
				//} // If chkIgnoreSchedDate1.Value = vbUnchecked Then
				//
				//if (chkIgnoreSchedDate2.CheckState == CheckState.Unchecked)
				//{
					//
					//if (Strings.Len(txt_end_time.Text.Trim()) > 0)
					//{
						//Query = $"{Query}AND journ_entry_date <= '{MonthView2.SelectionRange.Start.ToString("MM/dd/yyyy")} {txt_end_time.Text.Trim()}' ";
					//}
					//else
					//{
						//Query = $"{Query}AND journ_entry_date <= '{MonthView2.SelectionRange.Start.ToString("MM/dd/yyyy")}' ";
					//}
					//
				//} // If chkIgnoreSchedDate2.Value = vbUnchecked Then
				//
				//Query = $"{Query}ORDER BY jcat_subcategory_name";
				//
				//// Set snpCategories = LOCAL_DB.OpenRecordset(Query, dbOpenSnapshot, dbSQLPassThrough)
				//snpCategories.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
				//
				//if (!snpCategories.BOF && !snpCategories.EOF)
				//{
					////********************************
					////FILL IN ALL THE SUBCATEGORIES
					//grdSchedule.CurrentColumnIndex = 0;
					//grdSchedule.CurrentRowIndex = 0;
					//snpCategories.MoveFirst();
					//
					//do 
					//{ // Loop Until snpCategories.EOF = True
						//
						//grdSchedule.RowsCount++;
						//grdSchedule.CurrentRowIndex = grdSchedule.RowsCount - 1;
						//
						//grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].Value = ($"{Convert.ToString(snpCategories["jcat_subcategory_name"])}").Trim();
						//
						//if (grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString() == "Research Action")
						//{
							//grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].Value = $"{grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString()} (HotBox Items)";
						//}
						//
						//snpCategories.MoveNext();
						//
					//}
					//while(!snpCategories.EOF);
					//
				//} // If (snpCategories.BOF = False And snpCategories.EOF = False) Then
				//
				//snpCategories.Close();
				//
				//grdSchedule.RowsCount += 2;
				//grdSchedule.CurrentRowIndex = grdSchedule.RowsCount - 1;
				//
				//grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].Value = "Total Actions Per User";
				//
				//Query = "SELECT DISTINCT journ_user_id, jcat_subcategory_name, count(*) AS JournCount ";
				//Query = $"{Query}FROM Journal WITH(NOLOCK), Journal_Category WHERE journ_subcategory_code = jcat_subcategory_code ";
				//Query = $"{Query}AND journ_user_id IS NOT NULL AND journ_user_id <> '' ";
				//
				//if (!ListBoxHelper.GetSelected(lstAcctRep, 0))
				//{
					//Query = $"{Query}AND journ_user_id in (";
					//int tempForEndVar2 = lstAcctRep.Items.Count - 1;
					//for (int i = 1; i <= tempForEndVar2; i++)
					//{
						//if (ListBoxHelper.GetSelected(lstAcctRep, i))
						//{
							////*******************************
							////THE USER ID IS BEFORE THE "-"
							//Query = $"{Query}'{lstAcctRep.GetListItem(i).Substring(0, Math.Min(lstAcctRep.GetListItem(i).IndexOf('-'), lstAcctRep.GetListItem(i).Length)).Trim()}', ";
						//}
					//}
					//Query = $"{Query.Substring(0, Math.Min(Strings.Len(Query) - 2, Query.Length))}) ";
				//}
				//
				//if (chkIgnoreSchedDate1.CheckState == CheckState.Unchecked)
				//{
					//
					//// ADD IN THE START TIME
					//if (Strings.Len(txt_start_time.Text.Trim()) > 0)
					//{
						//Query = $"{Query}AND journ_entry_date >= '{MonthView1.SelectionRange.Start.ToString("MM/dd/yyyy")} {txt_start_time.Text.Trim()}' ";
					//}
					//else
					//{
						//Query = $"{Query}AND journ_entry_date >= '{MonthView1.SelectionRange.Start.ToString("MM/dd/yyyy")}' ";
					//}
					//
				//} // If chkIgnoreSchedDate1.Value = vbUnchecked Then
				//
				//if (chkIgnoreSchedDate2.CheckState == CheckState.Unchecked)
				//{
					//
					//// ADD IN THE END TIME
					//if (Strings.Len(txt_end_time.Text.Trim()) > 0)
					//{
						//Query = $"{Query}AND journ_entry_date <= '{MonthView2.SelectionRange.Start.ToString("MM/dd/yyyy")} {txt_end_time.Text.Trim()}' ";
					//}
					//else
					//{
						//Query = $"{Query}AND journ_entry_date <= '{MonthView2.SelectionRange.Start.ToString("MM/dd/yyyy")}' ";
					//}
					//
				//} // If chkIgnoreSchedDate2.Value = vbUnchecked Then
				//Query = $"{Query}group BY journ_user_id,jcat_subcategory_name ORDER BY journ_user_id,jcat_subcategory_name ";
				//
				////Set snpJourn = LOCAL_DB.OpenRecordset(Query, dbOpenSnapshot, dbSQLPassThrough)
				//snpJourn.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
				//
				//if (!snpJourn.BOF && !snpJourn.EOF)
				//{
					//
					//snpJourn.MoveLast();
					//snpJourn.MoveFirst();
					//
					//mdi_ResearchAssistant.DefInstance.prg_Progress_Bar.Maximum = snpJourn.RecordCount;
					//mdi_ResearchAssistant.DefInstance.prg_Progress_Bar.Value = 0;
					//mdi_ResearchAssistant.DefInstance.prg_Progress_Bar.Visible = true;
					//
					//modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Filling Grid ...", Color.Blue);
					//
					//Stopped = false;
					//cmdStop.Visible = true;
					//
					//totAcctRep = 0;
					//
					//do 
					//{ // Loop Until snpJourn.EOF = True
						//
						//// ********************************************
						//// BUILD A NEW GRID COLUMN FOR EACH NEW USER
						//if (($"{Convert.ToString(snpJourn["journ_user_id"])}").Trim().ToLower() != tmpAcctID.ToLower())
						//{
							//
							//totAcctRep++;
							////*************************************************
							////IF WE'VE ALREADY DONE ONE, THEN FILL IN THE TOTAL
							//if (ColOffset > 0)
							//{
								//grdSchedule.CurrentRowIndex = grdSchedule.RowsCount - 1;
								//grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].Value = totCount;
							//}
							//tmpAcctID = ($"{Convert.ToString(snpJourn["journ_user_id"])}").Trim().ToLower();
							//ColOffset++;
							//grdSchedule.ColumnsCount = ColOffset + 1;
							//grdSchedule.CurrentColumnIndex = ColOffset;
							//grdSchedule.CurrentRowIndex = 0;
							//grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].Value = $"{modCommon.GetUserName(($"{Convert.ToString(snpJourn["journ_user_id"])}").Trim())} [{($"{Convert.ToString(snpJourn["journ_user_id"])}").Trim()}]";
							//modStatusBar.Update_Status_Bar(modAdminCommon.SB, $"Summarizing Activity for ... User {grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString()}", Color.Blue);
							//Application.DoEvents();
							//grdSchedule.CurrentColumnIndex = 0;
							//grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].Value = "Category";
							//grdSchedule.SetColumnWidth(0, 233);
							//grdSchedule.ColAlignment[0] = DataGridViewContentAlignment.TopLeft;
							//totCount = 0;
						//} // IF NEW USER
						//
						//grdSchedule.CurrentRowIndex = 0;
						//grdSchedule.CurrentColumnIndex = 0;
						//
						//
						//while(grdSchedule.CurrentRowIndex < grdSchedule.RowsCount - 1)
						//{
							//grdSchedule.CurrentRowIndex++;
							//if (grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().Trim() == ($"{Convert.ToString(snpJourn["jcat_subcategory_name"])}").Trim())
							//{
								//break;
							//}
						//};
						//
						//mdi_ResearchAssistant.DefInstance.prg_Progress_Bar.Value = Convert.ToInt32(mdi_ResearchAssistant.DefInstance.prg_Progress_Bar.Value + 1);
						//Application.DoEvents();
						//if (Stopped)
						//{
							//break;
						//}
						//
						//grdSchedule.CurrentColumnIndex = ColOffset;
						//grdSchedule.SetColumnWidth(grdSchedule.CurrentColumnIndex, 67);
						//grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].Value = ($"{Convert.ToString(snpJourn["JournCount"])}").Trim();
						//totCount = Convert.ToInt32(totCount + Convert.ToDouble(snpJourn["JournCount"]));
						//
						//grdSchedule.FixedColumns = 1;
						//grdSchedule.FixedRows = 1;
						//
						//snpJourn.MoveNext();
						//Application.DoEvents();
						//
					//}
					//while(!snpJourn.EOF);
					//
					//
					//grdSchedule.RowsCount += 2;
					//grdSchedule.CurrentRowIndex = grdSchedule.RowsCount - 1;
					//grdSchedule.CurrentColumnIndex = 0;
					//
					//grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].Value = "Companies Verified AC Status";
					//modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Counting Verified Companies...", Color.Blue);
					//
					//int tempForEndVar3 = grdSchedule.ColumnsCount - 1;
					//for (int i = 1; i <= tempForEndVar3; i++)
					//{
						//
						//grdSchedule.CurrentRowIndex = 0;
						//grdSchedule.CurrentColumnIndex = i;
						//
						//strUserId = grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().Substring(Math.Min(grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().IndexOf('[') + 1, grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().Length), Math.Min((grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().IndexOf(']') + 1) - (grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().IndexOf('[') + 1) - 1, Math.Max(0, grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().Length - (grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().IndexOf('[') + 1))));
						//modStatusBar.Update_Status_Bar(modAdminCommon.SB, $"Counting Verified Companies... for {strUserId}", Color.Blue);
						//grdSchedule.CurrentRowIndex = grdSchedule.RowsCount - 1;
						//
						//grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].Value = Get_Companies_Verified_AC_Status(strUserId);
						//
					//}
					//
					//grdSchedule.RowsCount++;
					//grdSchedule.CurrentRowIndex = grdSchedule.RowsCount - 1;
					//grdSchedule.CurrentColumnIndex = 0;
					//
					//grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].Value = "Called Unable To Verify Status";
					//modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Counting Verified Companies...", Color.Blue);
					//
					//int tempForEndVar4 = grdSchedule.ColumnsCount - 1;
					//for (int i = 1; i <= tempForEndVar4; i++)
					//{
						//
						//grdSchedule.CurrentRowIndex = 0;
						//grdSchedule.CurrentColumnIndex = i;
						//
						//strUserId = grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().Substring(Math.Min(grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().IndexOf('[') + 1, grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().Length), Math.Min((grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().IndexOf(']') + 1) - (grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().IndexOf('[') + 1) - 1, Math.Max(0, grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().Length - (grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().IndexOf('[') + 1))));
						//modStatusBar.Update_Status_Bar(modAdminCommon.SB, $"Counting Called But Unable To Verify Status... for {strUserId}", Color.Blue);
						//grdSchedule.CurrentRowIndex = grdSchedule.RowsCount - 1;
						//
						//grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].Value = Get_Companies_Called_Unable_To_Verify_Status(strUserId);
						//
					//}
					//
					//grdSchedule.RowsCount++;
					//grdSchedule.CurrentRowIndex = grdSchedule.RowsCount - 1;
					//grdSchedule.CurrentColumnIndex = 0;
					//
					//grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].Value = "Companies Verified Information On";
					//modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Counting Verified Companies...", Color.Blue);
					//
					//int tempForEndVar5 = grdSchedule.ColumnsCount - 1;
					//for (int i = 1; i <= tempForEndVar5; i++)
					//{
						//
						//grdSchedule.CurrentRowIndex = 0;
						//grdSchedule.CurrentColumnIndex = i;
						//
						//strUserId = grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().Substring(Math.Min(grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().IndexOf('[') + 1, grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().Length), Math.Min((grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().IndexOf(']') + 1) - (grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().IndexOf('[') + 1) - 1, Math.Max(0, grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().Length - (grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().IndexOf('[') + 1))));
						//strAcctRep = GetUserAccountRep(strUserId);
						//modStatusBar.Update_Status_Bar(modAdminCommon.SB, $"Counting Called But Unable To Verify Status... for {strUserId}", Color.Blue);
						//grdSchedule.CurrentRowIndex = grdSchedule.RowsCount - 1;
						//
						//grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].Value = Get_Companies_Verified_Information(strUserId, strAcctRep);
						//
					//}
					//
					//if (chkAllActivityReports.CheckState == CheckState.Checked)
					//{
						//AddResearchNotesToGrid();
					//}
					//
				//} // If (snpJourn.BOF = False And snpJourn.EOF = False) Then
				//
				//snpJourn.Close();
				//
				//cmdStop.Visible = false;
				//
				//mdi_ResearchAssistant.DefInstance.prg_Progress_Bar.Visible = false;
				//
				//modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
				//this.Cursor = CursorHelper.CursorDefault;
				//HadHourglass = false;
				//
				//tmpHowLong = (int) DateAndTime.DateDiff("s", DateTime.Parse(tmpStart), DateTime.Parse(DateTime.Parse(modAdminCommon.GetDateTime()).ToString("HH:mm:ss")), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
				//
				//modCommon.End_Activity_Monitor_Message("AcctRep Activity Report", ref strMsg, dtStartDate, ref dtEndDate, 0, 0, 0, 0, 0);
				//
				//snpCategories = null;
				//snpJourn = null;
			//}
			//catch (System.Exception excep)
			//{
				//
				//modAdminCommon.Report_Error($"FillActivityGrid_Error: {excep.Message}", "User_Accounts");
				//
				//
				//modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
				//this.Cursor = CursorHelper.CursorDefault;
			//}
			//
		//}

		private string GetCount(string inHow, string inAcctType)
		{

			string result = "";
			string Query = "";
			ADORecordSetHelper snpCounts = new ADORecordSetHelper(); //aey 8/1/05 converted to ado

			try
			{

				Query = "SELECT DISTINCT comp_id ";

				if (inHow == "Prime" || cmbResearchType.Text.StartsWith("B", StringComparison.Ordinal))
				{
					Query = $"{Query}FROM Company WITH(NOLOCK) inner join Aircraft_Reference WITH(NOLOCK) on comp_id = cref_comp_id and comp_journ_id = cref_journ_id ";

					if (cmbResearchType.Text.StartsWith("B", StringComparison.Ordinal))
					{
						Query = $"{Query}inner join Aircraft WITH(NOLOCK) on ac_id = cref_ac_id and ac_journ_id = cref_journ_id ";
						Query = $"{Query}inner join aircraft_model WITH(NOLOCK) on ac_amod_id=amod_id ";
					}
				}
				else
				{
					Query = $"{Query}FROM Company WITH(NOLOCK) ";
				}

				if (inAcctType == "DB")
				{
					Query = $"{Query}WHERE comp_account_id='{($"{cbo_assign_db_account_id.Text} ").Trim()}' ";
				}
				else
				{
					Query = $"{Query}WHERE comp_account_id='{($"{cbo_assign_eu_account_id.Text} ").Trim()}' ";
				}

				if (cmbResearchType.Text.StartsWith("B", StringComparison.Ordinal))
				{
					Query = $"{Query}and (amod_airframe_type_code = 'F' or ( amod_airframe_type_code = 'R' and amod_class_code='A')) ";
					Query = $"{Query}and (ac_use_code <> 'C' ) ";
				}

				if (inHow == "Prime")
				{
					//  Query = Query & "and comp_id = cref_comp_id and comp_journ_id = cref_journ_id "
					Query = $"{Query}and cref_primary_poc_flag='Y' ";
				}

				Query = $"{Query}and comp_assign_flag='A' AND comp_active_flag='Y' ";
				Query = $"{Query}and comp_account_type='{inAcctType}' and comp_journ_id = 0 and comp_name like '{txt_assign_character.Text.Trim()}%' ";

				// Set snpCounts = LOCAL_DB.OpenRecordset(Query, dbOpenSnapshot, dbSQLPassThrough)
				snpCounts.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpCounts.BOF && snpCounts.EOF))
				{
					snpCounts.MoveLast();
					snpCounts.MoveFirst();
					result = StringsHelper.Format(snpCounts.RecordCount, "###,###");
				}
				snpCounts.Close();
				snpCounts = null;
			}
			catch (System.Exception excep)
			{
				modAdminCommon.Report_Error($"GetCount_Error: {excep.Message} {inHow} {inAcctType}", "User_Accounts");
			}

			return result;
		}

		private string GetRNCount(string inUser, string inSearchString)
		{

			string result = "";
			string Query = "";
			ADORecordSetHelper snpRN = new ADORecordSetHelper(); //8/1/05 aey converted to ado

			try
			{

				Query = "SELECT DISTINCT journ_user_id, count(*) AS JournCount FROM Journal WITH(NOLOCK), Journal_Category ";
				Query = $"{Query}WHERE journ_subcategory_code = jcat_subcategory_code ";
				Query = $"{Query}AND journ_subcategory_code = 'RN' AND journ_user_id IS NOT NULL AND journ_user_id <> '' ";

				Query = $"{Query}AND journ_user_id = '{inUser}' ";

				if (chkIgnoreSchedDate1.CheckState != CheckState.Checked)
				{

					// ADD IN THE START TIME
					if (Strings.Len(txt_start_time.Text.Trim()) > 0)
					{
						Query = $"{Query}AND journ_entry_time >= '{MonthView1.SelectionRange.Start.ToString("MM/dd/yyyy")} {txt_start_time.Text.Trim()}' ";
					}
					else
					{
						Query = $"{Query}AND journ_entry_date >= '{MonthView1.SelectionRange.Start.ToString("MM/dd/yyyy")}' ";
					}
				}
				if (chkIgnoreSchedDate2.CheckState != CheckState.Checked)
				{

					// ADD IN THE END TIME
					if (Strings.Len(txt_end_time.Text.Trim()) > 0)
					{
						Query = $"{Query}AND journ_entry_time <= '{MonthView2.SelectionRange.Start.ToString("MM/dd/yyyy")} {txt_end_time.Text.Trim()}' ";
					}
					else
					{
						Query = $"{Query}AND journ_entry_date <= '{MonthView2.SelectionRange.Start.ToString("MM/dd/yyyy")}' ";
					}
				}

				Query = $"{Query}AND (journ_subject LIKE '{inSearchString}%') ";

				Query = $"{Query}GROUP BY journ_user_id ORDER BY journ_user_id ";

				//Set snpRN = LOCAL_DB.OpenRecordset(Query, dbOpenSnapshot, dbSQLPassThrough)
				snpRN.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpRN.BOF && snpRN.EOF))
				{
					snpRN.MoveFirst();
					result = ($"{Convert.ToString(snpRN["JournCount"])}").Trim();
				}
				else
				{
					result = "0";
				}

				snpRN.Close();
				snpRN = null;
			}
			catch (System.Exception excep)
			{
				modAdminCommon.Report_Error($"GetRNCount_Error: {excep.Message}", "User_Accounts");
			}
			return result;
		}

		private string GetUserLogin(string inUser)
		{


			string tmpResult = inUser.Substring(Math.Min(inUser.IndexOf('[') + 1, inUser.Length));
			tmpResult = tmpResult.Substring(0, Math.Min(tmpResult.IndexOf(']'), tmpResult.Length));

			return tmpResult;


		}

		private void InsertScheduleGridRow()
		{

			string TempText = "";

			grdSchedule.RowsCount++;

			int tempForEndVar = grdSchedule.CurrentRowIndex + 1;
			for (int i = grdSchedule.RowsCount - 1; i >= tempForEndVar; i--)
			{

				int tempForEndVar2 = grdSchedule.ColumnsCount - 1;
				for (int II = 0; II <= tempForEndVar2; II++)
				{

					grdSchedule.CurrentRowIndex = i - 1;

					grdSchedule.CurrentColumnIndex = II;
					if (II == 0)
					{
						grdSchedule.CellFontBold = true;
					}
					TempText = grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString();

					grdSchedule.CurrentRowIndex = i;




					grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].Value = TempText;
				}

			}

			grdSchedule.CurrentRowIndex--;

			int tempForEndVar3 = grdSchedule.ColumnsCount - 1;
			for (int i = 0; i <= tempForEndVar3; i++)
			{
				grdSchedule.CurrentColumnIndex = i;
				grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].Value = "";
			}
		}

		private void ListScheduleCompanies()
		{

			string Query = "";
			ADORecordSetHelper snpCompany = new ADORecordSetHelper(); //8/1/05 aey converted to ado
			int tmpRow = 0;
			int tmpCol = 0;
			string tmpString = "";

			try
			{

				if (grdSchedule.CurrentRowIndex > 0 && grdSchedule.CurrentColumnIndex > 0 && grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().Trim() != "")
				{

					modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Getting Companies...", Color.Blue);
					this.Cursor = Cursors.WaitCursor;

					lblCompany.Visible = false;

					tmpRow = grdSchedule.CurrentRowIndex;
					tmpCol = grdSchedule.CurrentColumnIndex;
					lstCompany.Items.Clear();

					Query = "SELECT DISTINCT comp_id, comp_name, comp_city, comp_state FROM Company WITH(NOLOCK) ";
					Query = $"{Query}inner join Aircraft_Reference WITH(NOLOCK) on comp_id = cref_comp_id AND comp_journ_id = cref_journ_id ";
					Query = $"{Query}WHERE comp_journ_id = 0 AND (cref_primary_poc_flag = 'Y' or cref_primary_poc_flag='X') ";

					grdSchedule.CurrentRowIndex = 0;
					tmpString = grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString();

					Query = $"{Query}AND comp_account_id = '{grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().Trim()}' ";

					grdSchedule.CurrentRowIndex = tmpRow;
					grdSchedule.CurrentColumnIndex = 0;
					if (grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().Trim() != "")
					{
						lblCompany.Text = $"{tmpString} - {grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString()}";
					}
					else
					{
						lblCompany.Text = $"{tmpString} - <No Date>";
					}
					lblCompany.Visible = true;

					if (grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().Trim() != "")
					{
						Query = $"{Query}AND comp_account_callback_date = '{DateTime.Parse(grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString()).ToString("MM/dd/yyyy")}' ";
					}
					else
					{
						Query = $"{Query}AND comp_account_callback_date IS NULL ";
					}

					grdSchedule.CurrentColumnIndex = tmpCol;

					Query = $"{Query}ORDER BY comp_name";
					//txtTemp.Text = Query
					// Set snpCompany = LOCAL_DB.OpenRecordset(Query, dbOpenSnapshot, dbSQLPassThrough)
					snpCompany.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!(snpCompany.BOF && snpCompany.EOF))
					{
						modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Adding Companies to List...", Color.Blue);
						snpCompany.MoveFirst();

						while(!snpCompany.EOF)
						{
							lstCompany.AddItem($"{($"{Convert.ToString(snpCompany["comp_name"])}").Trim()} - {($"{Convert.ToString(snpCompany["comp_city"])}").Trim()}, {($"{Convert.ToString(snpCompany["comp_state"])}").Trim()}");
							lstCompany.SetItemData(lstCompany.Items.Count - 1, Convert.ToInt32(Double.Parse(($"{Convert.ToString(snpCompany["comp_id"])}").Trim())));

							snpCompany.MoveNext();
						};

						lstCompany.Visible = true;

					}

					modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
					this.Cursor = CursorHelper.CursorDefault;
					HadHourglass = false;

				}
				else
				{
					lstCompany.Visible = false;
					lblCompany.Visible = false;
				}

				snpCompany.Close();
				snpCompany = null;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"ListScheduleCompanies_Error: {excep.Message}", "User_Accounts");
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
				this.Cursor = CursorHelper.CursorDefault;
				HadHourglass = false;
			}

		}

		private void ShowJournalList()
		{


			int RememberRow = grdSchedule.CurrentRowIndex;


			string Query = "SELECT Journal.* FROM Journal WITH(NOLOCK) , Journal_Category, [User] ";
			Query = $"{Query}WHERE journ_subcategory_code = jcat_subcategory_code ";
			Query = $"{Query}AND journ_user_id IS NOT NULL AND journ_user_id <> ''  AND user_id = journ_user_id ";

			if (!ListBoxHelper.GetSelected(lstAcctRep, 0))
			{
				Query = $"{Query}AND journ_user_id in (";
				int tempForEndVar = lstAcctRep.Items.Count - 1;
				for (int i = 1; i <= tempForEndVar; i++)
				{
					if (ListBoxHelper.GetSelected(lstAcctRep, i))
					{
						//*******************************
						//THE USER ID IS BEFORE THE "-"
						Query = $"{Query}'{lstAcctRep.GetListItem(i).Substring(0, Math.Min(lstAcctRep.GetListItem(i).IndexOf('-'), lstAcctRep.GetListItem(i).Length)).Trim()}', ";
					}
				}

				Query = $"{Query.Substring(0, Math.Min(Strings.Len(Query) - 2, Query.Length))}) ";
			}

			if (chkIgnoreSchedDate1.CheckState != CheckState.Checked)
			{
				Query = $"{Query}AND journ_entry_date >= '{MonthView1.SelectionRange.Start.ToString("MM/dd/yyyy")}' ";
			}
			if (chkIgnoreSchedDate2.CheckState != CheckState.Checked)
			{
				Query = $"{Query}AND journ_entry_date <= '{MonthView2.SelectionRange.Start.ToString("MM/dd/yyyy")}' ";
			}

			grdSchedule.CurrentRowIndex = 0;
			Query = $"{Query}AND user_first_name = '{grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().Substring(0, Math.Min(grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().IndexOf('['), grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString().Length)).Trim()}' ";

			grdSchedule.CurrentRowIndex = RememberRow;
			grdSchedule.CurrentColumnIndex = 0;
			Query = $"{Query}AND jcat_subcategory_name = '{grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString()}' ";

			frm_JournalListPopUp.DefInstance.inEntryPoint = "ShowJournalList";
			frm_JournalListPopUp.DefInstance.inQuery = Query;
			frm_JournalListPopUp.DefInstance.ShowDialog();

		}

		private void cbo_account_id_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs) => Fill_Account_Assignment_List();


		private void cbo_Account_Scope_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs)
		{
			pnl_AircraftDetail.Visible = false;
			lblTeam.Text = $"{cbo_Account_Scope.Text}";
		}


		private void cbo_assign_db_account_id_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs) => cmd_Save_Assignments.Visible = true;


		private void cbo_assign_eu_account_id_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs) => cmd_Save_Assignments.Visible = true;



		private string GetTeamMembers(string TeamID)
		{

			string result = "";
			switch(TeamID)
			{
				case "1A" : 
					result = "'AC03','AC07','AC09','AC11'"; 
					break;
				case "1B" : 
					result = "'AC02','AC04','AC08','AC10','AC16'"; 
					break;
				case "2" : 
					result = "'DB01','DB02','DB03','DB05'"; 
					break;
				case "3" : 
					result = "'AC13','DB13','AC18','DB18','AC06','AC12'"; 
					break;
			}

			return result;
		}

		private void chkIncludeACCount_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{
			//Fill_Account_Summary_List
			if (chkIncludeACCount.CheckState == CheckState.Checked)
			{
				cbo_Account_Scope.Visible = true;
				lbl_account[17].Visible = true;
			}
			else
			{
				cbo_Account_Scope.Visible = false;
				lbl_account[17].Visible = false;
			}

		}

		private void ChkTeams_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{

			if (ChkTeams.CheckState == CheckState.Checked)
			{
				cboTeams.Visible = true;
				txtAcctRep.Visible = false;
			}
			else
			{
				cboTeams.Visible = false;
				txtAcctRep.Visible = true;
			}


		}

		private void cmbResearchType_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs) => ToolTipMain.SetToolTip(cmbResearchType, cmbResearchType.Text);


		private void cmd_AircraftDetail_Click(Object eventSender, EventArgs eventArgs)
		{
			pnl_AircraftDetail.Visible = false;
			if (mvHasFocus)
			{
				mvHasFocus = false;
			}
		}

		private void cmd_AircraftDetail_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;

			if (mvHasFocus)
			{
				mvHasFocus = false;
				cmd_AircraftDetail_Click(cmd_AircraftDetail, new EventArgs());
			}

		}

		private void cmd_Analyze_Click(Object eventSender, EventArgs eventArgs)
		{
			modAdminCommon.Record_Event("User_Accounts SearchForUnassignedAircraft", $"{Convert.ToString(modAdminCommon.snp_User["user_id"])} Started ");
			tmpStart = DateTime.Parse(modAdminCommon.GetDateTime()).ToString("HH:mm:ss");

			Fill_Unassigned_Aircraft_List();

			//end time tracking aey 4/28/05
			tmpHowLong = (int) DateAndTime.DateDiff("s", DateTime.Parse(tmpStart), DateTime.Parse(DateTime.Parse(modAdminCommon.GetDateTime()).ToString("HH:mm:ss")), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
			modAdminCommon.Record_Event("User_Accounts SearchForUnassignedAircraft", $"{Convert.ToString(modAdminCommon.snp_User["user_id"])} Finished [Time Elapsed: {tmpHowLong.ToString()} Seconds]");

			if (mvHasFocus)
			{
				mvHasFocus = false;
			}

		}

		private void cmd_Analyze_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;
			if (mvHasFocus)
			{
				mvHasFocus = false;
				cmd_Analyze_Click(cmd_Analyze, new EventArgs());
			}

		}

		private void cmd_FindDup_Click(Object eventSender, EventArgs eventArgs)
		{
			modAdminCommon.Record_Event("User_Accounts FindDupAircraftPOC", $"{Convert.ToString(modAdminCommon.snp_User["user_id"])} Started ");
			tmpStart = DateTime.Parse(modAdminCommon.GetDateTime()).ToString("HH:mm:ss");

			Fill_Dup_POC_List();

			//end time tracking aey 4/28/05
			tmpHowLong = (int) DateAndTime.DateDiff("s", DateTime.Parse(tmpStart), DateTime.Parse(DateTime.Parse(modAdminCommon.GetDateTime()).ToString("HH:mm:ss")), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
			modAdminCommon.Record_Event("User_Accounts FindDupAircraftPOC", $"{Convert.ToString(modAdminCommon.snp_User["user_id"])} Finished [Time Elapsed: {tmpHowLong.ToString()} Seconds]");

			if (mvHasFocus)
			{
				mvHasFocus = false;
			}

		}

		private void cmd_FindDup_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;
			if (mvHasFocus)
			{
				mvHasFocus = false;
				cmd_FindDup_Click(cmd_FindDup, new EventArgs());
			}

		}

		private void cmd_Save_Assignments_Click(Object eventSender, EventArgs eventArgs)
		{
			Save_Account_Assignment_Changes();
			if (mvHasFocus)
			{
				mvHasFocus = false;
			}

		}

		private void cmd_Save_Assignments_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;
			if (mvHasFocus)
			{
				mvHasFocus = false;
				cmd_Save_Assignments_Click(cmd_Save_Assignments, new EventArgs());
			}

		}

		private void cmd_SummarizeConfirms_Click(Object eventSender, EventArgs eventArgs)
		{
			Get_Company_Confirmation();
			if (mvHasFocus)
			{
				mvHasFocus = false;
			}
		}

		private void cmd_SummarizeConfirms_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;
			if (mvHasFocus)
			{
				mvHasFocus = false;
				cmd_SummarizeConfirms_Click(cmd_SummarizeConfirms, new EventArgs());
			}

		}

		private void cmdAccountAssignRefresh_Click(Object eventSender, EventArgs eventArgs)
		{

			Fill_Account_Summary_List();

			if (mvHasFocus)
			{
				mvHasFocus = false;
			}
		}

		private void cmdAccountAssignRefresh_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;
			if (mvHasFocus)
			{
				mvHasFocus = false;
				cmdAccountAssignRefresh_Click(cmdAccountAssignRefresh, new EventArgs());
			}

		}

		private void cmdCancelNewAccountID_Click(Object eventSender, EventArgs eventArgs)
		{

			pnlAddNewAccountID.Visible = false;
			if (mvHasFocus)
			{
				mvHasFocus = false;
			}

		}

		private void cmdCancelNewAccountID_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;
			if (mvHasFocus)
			{
				mvHasFocus = false;
				cmdCancelNewAccountID_Click(cmdCancelNewAccountID, new EventArgs());
			}

		}

		private void cmdDeleteNewAccountID_Click(Object eventSender, EventArgs eventArgs)
		{

			string Query = "";

			if (txtNewAccountID.Text.Trim() != "")
			{
				if (MessageBox.Show($"Are you sure you want to Delete Account ID {txtNewAccountID.Text.Trim()}?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
				{
					Query = $"DELETE FROM Account_Rep WHERE accrep_account_id = '{txtNewAccountID.Text.Trim()}'";

					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();

					MessageBox.Show("Delete Successful", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));

					cmdCancelNewAccountID_Click(cmdCancelNewAccountID, new EventArgs());

					SSTabHelper.SetSelectedIndex(tab_Accounts, 0);
					Fill_Account_Assignment_List();
					Display_Account_Rep_Lists();
					FillComboAcctRep();

				}
			}

			if (mvHasFocus)
			{
				mvHasFocus = false;
			}

		}

		private void cmdDeleteNewAccountID_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;

			if (mvHasFocus)
			{
				mvHasFocus = false;
				cmdDeleteNewAccountID_Click(cmdDeleteNewAccountID, new EventArgs());
			}

		}

		private void cmdSaveNewAccountID_Click(Object eventSender, EventArgs eventArgs)
		{

			string Query = "";

			if (txtNewAccountID.Text != "")
			{

				Query = $"SELECT * FROM Account_Rep WHERE accrep_account_id = '{txtNewAccountID.Text.Trim()}'";

				if (!modAdminCommon.Exist(Query))
				{
					Query = $"INSERT INTO Account_Rep (accrep_account_id) VALUES ('{txtNewAccountID.Text.Trim()}')";

					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();

					MessageBox.Show("Insert Successful.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));

					cmdCancelNewAccountID_Click(cmdCancelNewAccountID, new EventArgs());

					SSTabHelper.SetSelectedIndex(tab_Accounts, 0);
					Fill_Account_Assignment_List();
					Display_Account_Rep_Lists();
					FillComboAcctRep();

				}
				else
				{
					MessageBox.Show($"Account ID {txtNewAccountID.Text.Trim()} Already Exists.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));

				}
			}

			if (mvHasFocus)
			{
				mvHasFocus = false;
			}

		}

		private void cmdSaveNewAccountID_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;

			if (mvHasFocus)
			{
				mvHasFocus = false;
				cmdSaveNewAccountID_Click(cmdSaveNewAccountID, new EventArgs());
			}

		}

		private void cmdScheduleGo_Click(Object eventSender, EventArgs eventArgs)
		{

			if (optCallbackSchedule.Checked)
			{
				FillScheduleGrid();
			}
			else
			{
				//FillActivityGrid
				CallAccountRepActivityWebPage();
			}

			if (mvHasFocus)
			{
				mvHasFocus = false;
			}

		}

		private void cmdScheduleGo_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;

			if (mvHasFocus)
			{
				mvHasFocus = false;
				cmdScheduleGo_Click(cmdScheduleGo, new EventArgs());
			}

		}
		private void cmdStop_MouseMove(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;

			HadHourglass = this.Cursor == Cursors.WaitCursor || HadHourglass;
			this.Cursor = CursorHelper.CursorDefault;

		}

		private void cmdStop_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;

			if (mvHasFocus)
			{
				mvHasFocus = false;
				cmdStop_Click(cmdStop, new EventArgs());
			}

		}
		private void cmdStop_Click(Object eventSender, EventArgs eventArgs)
		{

			Stopped = true;

			if (mvHasFocus)
			{
				mvHasFocus = false;
			}

		}

		private void FillScheduleGrid()
		{

			string Query = "";
			ADORecordSetHelper snpSchedule = new ADORecordSetHelper(); //8/1/05 converted to ado aey
			int ColOffset = 0;

			try
			{

				this.Cursor = Cursors.WaitCursor;
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Getting Schedule Information ...", Color.Blue);
				modAdminCommon.Record_Event("User_Accounts CallbackSchedule", $"{Convert.ToString(modAdminCommon.snp_User["user_id"])} Started ");
				tmpStart = DateTime.Parse(modAdminCommon.GetDateTime()).ToString("HH:mm:ss");

				ColOffset = 0;
				tmpAcctID = "";

				lblCompany.Visible = false;
				lstCompany.Items.Clear();
				lstCompany.Visible = false;

				grdSchedule.Clear();
				grdSchedule.ColumnsCount = 0;
				grdSchedule.RowsCount = 2;
				grdSchedule.FixedColumns = 0;
				grdSchedule.FixedRows = 0;

				//aey 11/9/2004 replaced query
				Query = "SELECT DISTINCT comp_account_id, comp_account_callback_date, count(*) as CallbackCount ";
				Query = $"{Query}FROM Company WITH(NOLOCK) WHERE comp_journ_id = 0 ";
				Query = $"{Query}AND comp_active_flag='Y' And comp_id in (select  cref_comp_id from aircraft_reference where cref_journ_id=0 and cref_primary_poc_flag = 'Y' ) ";

				if (!ListBoxHelper.GetSelected(lstAcctRep, 0))
				{

					Query = $"{Query}AND comp_account_id in (";

					int tempForEndVar = lstAcctRep.Items.Count - 1;
					for (int i = 1; i <= tempForEndVar; i++)
					{
						if (ListBoxHelper.GetSelected(lstAcctRep, i))
						{

							Query = $"{Query}'{lstAcctRep.GetListItem(i)}', ";

						}
					}

					Query = $"{Query.Substring(0, Math.Min(Strings.Len(Query) - 2, Query.Length))}) ";

				}

				if (chkIgnoreSchedDate1.CheckState != CheckState.Checked)
				{
					Query = $"{Query}AND comp_account_callback_date >= '{MonthView1.SelectionRange.Start.ToString("d")}' ";
				}
				if (chkIgnoreSchedDate2.CheckState != CheckState.Checked)
				{
					Query = $"{Query}AND comp_account_callback_date <= '{MonthView2.SelectionRange.Start.ToString("d")}' ";
				}

				Query = $"{Query}GROUP BY comp_account_id, comp_account_callback_date ORDER BY comp_account_id, comp_account_callback_date";

				snpSchedule.CursorLocation = CursorLocationEnum.adUseClient;
				snpSchedule.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpSchedule.BOF && snpSchedule.EOF))
				{

					mdi_ResearchAssistant.DefInstance.prg_Progress_Bar.Maximum = snpSchedule.RecordCount;
					mdi_ResearchAssistant.DefInstance.prg_Progress_Bar.Value = 0;
					mdi_ResearchAssistant.DefInstance.prg_Progress_Bar.Visible = true;

					modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Filling Grid ...", Color.Blue);

					Stopped = false;
					cmdStop.Visible = true;


					while(!snpSchedule.EOF)
					{
						if (($"{Convert.ToString(snpSchedule["comp_account_id"])}").Trim() != tmpAcctID)
						{
							tmpAcctID = ($"{Convert.ToString(snpSchedule["comp_account_id"])}").Trim();
							ColOffset++;

							grdSchedule.ColumnsCount = ColOffset + 1;

							grdSchedule.CurrentColumnIndex = ColOffset;
							grdSchedule.CurrentRowIndex = 0;

							grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].Value = ($"{Convert.ToString(snpSchedule["comp_account_id"])}").Trim();
							grdSchedule.CellFontBold = true;

							grdSchedule.CurrentColumnIndex = 0;
							grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].Value = "Date";
							grdSchedule.CellFontBold = true;
							grdSchedule.SetColumnWidth(0, 93);
							
							grdSchedule.ColAlignment[0] = DataGridViewContentAlignment.NotSet;

						}
						grdSchedule.CurrentRowIndex = 1;
						grdSchedule.CurrentColumnIndex = 0;

						while(grdSchedule.CurrentRowIndex < grdSchedule.RowsCount - 1)
						{
							if (DateTime.Parse(($"{grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString()}").Trim()).ToString("d") == DateTime.Parse(($"{Convert.ToString(snpSchedule["comp_account_callback_date"])}").Trim()).ToString("d"))
							{
								break;
							}
							else if (String.CompareOrdinal(DateTime.Parse(($"{grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].FormattedValue.ToString()}").Trim()).ToString("d"), DateTime.Parse(($"{Convert.ToString(snpSchedule["comp_account_callback_date"])}").Trim()).ToString("d")) > 0)
							{ 
								InsertScheduleGridRow();
								break;
							}
							else
							{
								grdSchedule.CurrentRowIndex++;
							}
						};

						if (grdSchedule.CurrentRowIndex == grdSchedule.RowsCount - 1)
						{
							grdSchedule.RowsCount++;
						}

						mdi_ResearchAssistant.DefInstance.prg_Progress_Bar.Value = Convert.ToInt32(mdi_ResearchAssistant.DefInstance.prg_Progress_Bar.Value + 1);
						Application.DoEvents();
						if (Stopped)
						{
							break;
						}

						grdSchedule.CurrentColumnIndex = ColOffset;
						grdSchedule.SetColumnWidth(grdSchedule.CurrentColumnIndex, 67);
						grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].Value = ($"{Convert.ToString(snpSchedule["CallbackCount"])}").Trim();

						grdSchedule.CurrentColumnIndex = 0;
						grdSchedule[grdSchedule.CurrentRowIndex, grdSchedule.CurrentColumnIndex].Value = DateTime.Parse(($"{Convert.ToString(snpSchedule["comp_account_callback_date"])}").Trim()).ToString("d");
						grdSchedule.CellFontBold = true;

						snpSchedule.MoveNext();
					};
				}

				if (grdSchedule.RowsCount > 0)
				{
					grdSchedule.RowsCount--;
				}

				cmdStop.Visible = false;

				mdi_ResearchAssistant.DefInstance.prg_Progress_Bar.Visible = false;

				snpSchedule.Close();
				snpSchedule = null;

				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
				this.Cursor = CursorHelper.CursorDefault;
				HadHourglass = false;

				tmpHowLong = (int) DateAndTime.DateDiff("s", DateTime.Parse(tmpStart), DateTime.Parse(DateTime.Parse(modAdminCommon.GetDateTime()).ToString("HH:mm:ss")), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
				modAdminCommon.Record_Event("User_Accounts CallbackSchedule", $"{Convert.ToString(modAdminCommon.snp_User["user_id"])} Finished [Time Elapsed: {tmpHowLong.ToString()} Seconds]");
			}
			catch (System.Exception excep)
			{
				modAdminCommon.Report_Error($"FillScheduleGrid_Error {excep.Message}", "User_Accounts");
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
				this.Cursor = CursorHelper.CursorDefault;
			}

		}

		private void Form_Activated(Object eventSender, EventArgs eventArgs)
		{
			if (ActivateHelper.myActiveForm != eventSender)
			{
				ActivateHelper.myActiveForm = (Form) eventSender;
				// 3/23/2011 -    RTW - REMOVED OLD PROCEDURES THAT WERE BUILT FOR HELO INTEGRATION

				mnuFixSerNoSort.Available = modAdminCommon.gbl_User_ID == "mvit" || modAdminCommon.gbl_User_ID == "dcr" || modAdminCommon.gbl_User_ID == "aja";

				this.Cursor = Cursors.WaitCursor;

				grdSchedule.RowsCount = 0;
				grdSchedule.ColumnsCount = 0;

				Fill_Account_Assignment_List();
				Display_Account_Rep_Lists();

				MonthView1.SetDate(DateTime.Parse(modAdminCommon.DateToday));
				MonthView2.SetDate(DateTime.Parse(modAdminCommon.DateToday));
				txtDate1.Text = DateTimeHelper.ToString(MonthView1.SelectionRange.Start);
				txtDate2.Text = DateTimeHelper.ToString(MonthView2.SelectionRange.Start);

				cbo_days_confirm.Items.Clear();
				cbo_days_confirm.AddItem("90");
				cbo_days_confirm.AddItem("180");
				cbo_days_confirm.AddItem("270");
				cbo_days_confirm.AddItem("360");
				cbo_days_confirm.SelectedIndex = 0;

				Application.DoEvents();

				this.Cursor = CursorHelper.CursorDefault;
				HadHourglass = false;

				if (modAdminCommon.gbl_bHomeClicked)
				{
					this.Hide();
				}
			}
		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
		private void Form_Load()
		{

			SSTabHelper.SetSelectedIndex(tab_Accounts, 0);
			ToolbarSetup();
			ToolbarButtonsSetup();

			FillComboAcctRep();

			cbo_Account_Scope.Items.Clear();
			cbo_Account_Scope.AddItem("All");
			cbo_Account_Scope.AddItem("Missing Operator");
			cbo_Account_Scope.AddItem("Missing Chief Pilot");
			cbo_Account_Scope.AddItem("Missing Base");
			cbo_Account_Scope.SelectedIndex = 0;

			cboTeams.Items.Clear();
			cboTeams.AddItem("1A");
			cboTeams.AddItem("1B");
			cboTeams.AddItem("2");
			cboTeams.AddItem("3");
			cboTeams.SelectedIndex = 0;

			pnl_AircraftDetail.Visible = false;

			cmbResearchType.Items.Clear();
			cmbResearchType.AddItem("B - Business and Class A Helicopter no Comm");
			cmbResearchType.AddItem("A - All");
			cmbResearchType.SelectedIndex = 0;


		}

		private void FillComboAcctRep()
		{

			string Query = "";
			ADORecordSetHelper snpAcctRep = new ADORecordSetHelper(); //8/1/05 aey converted to ado

			try
			{

				lstAcctRep.Items.Clear();
				lstAcctRep.AddItem("All");

				if (optAccountRepActivity.Checked)
				{

					Query = "SELECT DISTINCT user_id, user_default_account_id FROM [User] ";
					Query = $"{Query}WHERE (user_password <> 'inactive') ORDER BY user_default_account_id, user_id";

				}
				else
				{

					Query = "SELECT DISTINCT accrep_account_id FROM Account_rep ORDER BY accrep_account_id";

				}

				snpAcctRep.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpAcctRep.BOF && snpAcctRep.EOF))
				{

					while(!snpAcctRep.EOF)
					{
						if (optAccountRepActivity.Checked)
						{
							lstAcctRep.AddItem($"{modAdminCommon.gbl_LeftAdjust(($"{Convert.ToString(snpAcctRep["user_id"])}").Trim().ToUpper(), "****")} - {modAdminCommon.gbl_LeftAdjust(($"{Convert.ToString(snpAcctRep["user_default_account_id"])}").Trim().ToUpper(), "****")}");
						}
						else
						{
							lstAcctRep.AddItem(($"{Convert.ToString(snpAcctRep["accrep_account_id"])}").Trim());
						}
						snpAcctRep.MoveNext();
					};
				}

				ListBoxHelper.SetSelected(lstAcctRep, 0, true);

				snpAcctRep.Close();
				snpAcctRep = null;
			}
			catch (System.Exception excep)
			{
				modAdminCommon.Report_Error($"FillComboAcctRep_Error: {excep.Message}", "User_Accounts");
			}

		}

		public void Fill_Account_Assignment_List()
		{
			string Query = "";

			try
			{

				this.Cursor = Cursors.WaitCursor;
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Getting Account Assignments...", Color.Blue);

				lst_Assign.Items.Clear();

				Query = "SELECT * FROM Account_Rep_Assignment ";

				if (cbo_Account_ID.Text.Trim() != "All")
				{
					Query = $"{Query}WHERE assign_db_account_id='{cbo_Account_ID.Text.Trim()}' OR assign_eu_account_id='{cbo_Account_ID.Text.Trim()}' ";
				}

				Query = $"{Query}{strAssignSort}";
				snp_Assign = new ADORecordSetHelper();
				snp_Assign.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_Assign.BOF && snp_Assign.EOF))
				{

					while(!snp_Assign.EOF)
					{
						lst_Assign.AddItem($"   {($"{Convert.ToString(snp_Assign["assign_character"])} ").Trim()}   {($"{Convert.ToString(snp_Assign["assign_eu_account_id"])} ").Trim()}   {($"{Convert.ToString(snp_Assign["assign_db_account_id"])} ").Trim()}");
						snp_Assign.MoveNext();
					};
					ListBoxHelper.SetSelectedIndex(lst_Assign, 0);
					pnl_AutoAssign.Visible = false;
					snp_Assign.MoveFirst();
				}


				this.Cursor = CursorHelper.CursorDefault;
				HadHourglass = false;
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
			}
			catch
			{

				this.Cursor = CursorHelper.CursorDefault;
				HadHourglass = false;
				modAdminCommon.Report_Error("Fill_Account_Assignment_List_Error: ");
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
				return;
			}

		}

		public void Fill_Account_Summary_List()
		{


			string strMsg = "";
			System.DateTime dtStartDate = DateTime.FromOADate(0);
			System.DateTime dtEndDate = DateTime.FromOADate(0);

			string Query = "";
			string SumLine = "";
			double Tot_Comp = 0;
			double Tot_Man_Comp = 0;
			double Tot_Aut_Comp = 0;
			double Tot_Prime_Comp = 0;
			double Tot_Prime_Man_Comp = 0;
			double Tot_Prime_Aut_Comp = 0;
			double Tot_Aircraft = 0;
			double Tot_Man_Aircraft = 0;
			double Tot_Aut_Aircraft = 0;
			string Report_Scope = "";
			string strAcctRep = "";

			try
			{

				this.Cursor = Cursors.WaitCursor;

				modCommon.Start_Activity_Monitor_Message("Account Assignments", ref strMsg, ref dtStartDate, ref dtEndDate);

				Report_Scope = cbo_Account_Scope.Text;
				pnl_AircraftDetail.Visible = false;

				Stopped = false;
				AC_Row = 0;

				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Getting Company Records...", Color.Blue);
				Application.DoEvents();

				Tot_Comp = 0;
				Tot_Man_Comp = 0;
				Tot_Aut_Comp = 0;

				Tot_Prime_Comp = 0;
				Tot_Prime_Man_Comp = 0;
				Tot_Prime_Aut_Comp = 0;

				Tot_Aircraft = 0;
				Tot_Man_Aircraft = 0;
				Tot_Aut_Aircraft = 0;

				txt_tot_comp.Text = "0";
				txt_tot_man_comp.Text = "0";
				txt_tot_aut_comp.Text = "0";

				txt_tot_aircraft.Text = "0";
				txt_tot_man_aircraft.Text = "0";
				txt_tot_aut_aircraft.Text = "0";

				Total_Aircraft = 0;
				Total_Automatic_Aircraft = 0;
				Total_Manual_Aircraft = 0;

				grdACSummary.Clear();
				grdACSummary.FixedRows = 0;
				grdACSummary.FixedColumns = 0;

				if (chkIncludeACCount.CheckState == CheckState.Checked)
				{
					grdACSummary.ColumnsCount = 10;
				}
				else
				{
					grdACSummary.ColumnsCount = 7;
				}
				int tempForEndVar = grdACSummary.ColumnsCount - 1;
				for (int i = 0; i <= tempForEndVar; i++)
				{
					grdACSummary.SetColumnWidth(i, 50);
				}
				grdACSummary.RowsCount = 0;

				cbo_Account_ID.Items.Clear();
				cbo_Account_ID.AddItem("All");

				Query = "SELECT accrep_account_id FROM Account_rep WITH(NOLOCK) ";

				strAcctRep = "ALL";
				if (ChkTeams.CheckState == CheckState.Checked)
				{
					strAcctRep = GetTeamMembers(cboTeams.GetListItem(cboTeams.SelectedIndex));
					Query = $"{Query}WHERE accrep_account_id in ({strAcctRep}) ";
				}
				else
				{
					if (txtAcctRep.Text.Trim() != "")
					{
						strAcctRep = ($"{txtAcctRep.Text} ").Trim();
						Query = $"{Query}WHERE accrep_account_id LIKE '{strAcctRep}%' ";
					}
				}

				Query = $"{Query}ORDER BY accrep_account_id";

				snp_ACSummary = new ADORecordSetHelper();

				snp_ACSummary.CursorLocation = CursorLocationEnum.adUseClient;
				snp_ACSummary.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!snp_ACSummary.BOF && !snp_ACSummary.EOF)
				{

					cmdStop.Visible = true;

					do 
					{ // Loop Until snp_ACSummary.EOF = True

						modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Counting Company Records...", Color.Blue);

						Get_Company_Count();

						Application.DoEvents();
						if (Stopped)
						{
							break;
						}

						if (chkIncludeACCount.CheckState == CheckState.Checked)
						{
							lbl_account[4].Visible = true;
							lbl_account[5].Visible = true;
							lbl_account[11].Visible = true;
							txt_tot_aut_aircraft.Visible = true;
							txt_tot_man_aircraft.Visible = true;
							txt_tot_aircraft.Visible = true;

							Get_Aircraft_Count(Report_Scope);

						}
						else
						{
							lbl_account[4].Visible = false;
							lbl_account[5].Visible = false;
							lbl_account[11].Visible = false;
							txt_tot_aut_aircraft.Visible = false;
							txt_tot_man_aircraft.Visible = false;
							txt_tot_aircraft.Visible = false;

						}

						// TOTAL NUMBER OF COMPANIES ASSIGNED - INDEPENDENT OF AIRCRAFT
						Tot_Comp += Total_Company;
						Tot_Man_Comp += Total_Manual_Company;
						Tot_Aut_Comp += Total_Automatic_Company;

						// TOTAL NUMBER OF COMPANIES ASSIGNED AS PRIMARY TO AIRCRAFT
						Tot_Prime_Comp += Total_Prime_Company;
						Tot_Prime_Man_Comp += Total_Prime_Manual_Company;
						Tot_Prime_Aut_Comp += Total_Prime_Automatic_Company;

						// TOTAL NUMBER OF AIRCRAFT ASSIGNED TO COMPANIES
						Tot_Aircraft += Total_Aircraft;
						Tot_Man_Aircraft += Total_Manual_Aircraft;
						Tot_Aut_Aircraft += Total_Automatic_Aircraft;

						txt_tot_comp.Text = modAdminCommon.gbl_RightAdjust(StringsHelper.Format(Tot_Comp, "###,###"), "###,###");
						txt_tot_man_comp.Text = modAdminCommon.gbl_RightAdjust(StringsHelper.Format(Tot_Man_Comp, "###,###"), "###,###");
						txt_tot_aut_comp.Text = modAdminCommon.gbl_RightAdjust(StringsHelper.Format(Tot_Aut_Comp, "###,###"), "###,###");

						txt_tot_prime_company.Text = modAdminCommon.gbl_RightAdjust(StringsHelper.Format(Tot_Prime_Comp, "###,###"), "###,###");
						txt_tot_prime_man_company.Text = modAdminCommon.gbl_RightAdjust(StringsHelper.Format(Tot_Prime_Man_Comp, "###,###"), "###,###");
						txt_tot_prime_auto_company.Text = modAdminCommon.gbl_RightAdjust(StringsHelper.Format(Tot_Prime_Aut_Comp, "###,###"), "###,###");

						txt_tot_aircraft.Text = modAdminCommon.gbl_RightAdjust(StringsHelper.Format(Tot_Aircraft, "###,###"), "###,###");
						txt_tot_man_aircraft.Text = modAdminCommon.gbl_RightAdjust(StringsHelper.Format(Tot_Man_Aircraft, "###,###"), "###,###");
						txt_tot_aut_aircraft.Text = modAdminCommon.gbl_RightAdjust(StringsHelper.Format(Tot_Aut_Aircraft, "###,###"), "###,###");

						//MsgBox ("Check")
						SumLine = $"{($"{Convert.ToString(snp_ACSummary["accrep_account_id"])} ").Trim()}{"\t"}";
						SumLine = $"{SumLine}{StringsHelper.Format(Total_Automatic_Company, "###,###")}{"\t"}";
						SumLine = $"{SumLine}{StringsHelper.Format(Total_Manual_Company, "###,###")}{"\t"}";
						SumLine = $"{SumLine}{StringsHelper.Format(($"{(Total_Manual_Company + Total_Automatic_Company).ToString()} ").Trim(), "###,###")}{"\t"}";

						SumLine = $"{SumLine}{StringsHelper.Format(Total_Prime_Automatic_Company, "###,###")}{"\t"}";
						SumLine = $"{SumLine}{StringsHelper.Format(Total_Prime_Manual_Company, "###,###")}{"\t"}";
						SumLine = $"{SumLine}{StringsHelper.Format(($"{(Total_Prime_Manual_Company + Total_Prime_Automatic_Company).ToString()} ").Trim(), "###,###")}{"\t"}";

						SumLine = $"{SumLine}{StringsHelper.Format(Total_Automatic_Aircraft, "###,###")}{"\t"}";
						SumLine = $"{SumLine}{StringsHelper.Format(Total_Manual_Aircraft, "###,###")}{"\t"}";
						SumLine = $"{SumLine}{StringsHelper.Format(Total_Aircraft, "###,###")}";
						//SumLine = SumLine & gbl_LeftAdjust(Trim(snp_ACSummary!accrep_description & " "), "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@") & " "
						grdACSummary.AddItem(SumLine);
						cbo_Account_ID.AddItem(($"{Convert.ToString(snp_ACSummary["accrep_account_id"])} ").Trim());

						snp_ACSummary.MoveNext();
						Application.DoEvents();

					}
					while(!snp_ACSummary.EOF);

					//      grdACSummary.ListIndex = 0
					cbo_Account_ID.SelectedIndex = 0;

				} // If (snp_ACSummary.BOF = False And snp_ACSummary.EOF = False) Then

				Get_Unused_AC(); // DISPLAY A COUNT OF THE UNUSED AIRCRAFT
				cmdStop.Visible = false;

				if (Report_Scope != "All" && chkIncludeACCount.CheckState == CheckState.Checked)
				{
					pnl_AircraftDetail.Visible = true;
				}

				this.Cursor = CursorHelper.CursorDefault;
				HadHourglass = false;
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);

				strMsg = $"Account Rep: ({strAcctRep}) - ";
				modCommon.End_Activity_Monitor_Message("Account Assignments", ref strMsg, dtStartDate, ref dtEndDate, 0, 0, 0, 0, 0);
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"Fill_Account_Summary_List_Error: {excep.Message}");
				this.Cursor = CursorHelper.CursorDefault;
				HadHourglass = false;
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
			}

		}

		public void Get_Company_Count()
		{

			string Query = "";
			ADORecordSetHelper snp_Company_Total = new ADORecordSetHelper(); //8/1/05 aey converted to ado

			try
			{

				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Getting Company Records...", Color.Blue);
				Application.DoEvents();

				Total_Company = 0;
				Total_Automatic_Company = 0;
				Total_Manual_Company = 0;

				Query = "SELECT distinct comp_id, comp_assign_flag FROM Company WITH(NOLOCK) ";

				Query = $"{Query}WHERE comp_journ_id=0 and comp_active_flag='Y' AND comp_account_id = '{Convert.ToString(snp_ACSummary["accrep_account_id"]).Trim()}' ";


				snp_Company_Total.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_Company_Total.BOF && snp_Company_Total.EOF))
				{
					modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Counting Company Records...", Color.Blue);

					while(!snp_Company_Total.EOF)
					{
						Application.DoEvents();
						if (Stopped)
						{
							break;
						}
						if (Convert.ToString(snp_Company_Total["comp_assign_flag"]) == "A")
						{
							Total_Automatic_Company++;
						}
						else
						{
							Total_Manual_Company++;
						}
						Total_Company++;

						snp_Company_Total.MoveNext();
					};
				}

				snp_Company_Total.Close();
				snp_Company_Total = null;

				Total_Prime_Company = 0;
				Total_Prime_Automatic_Company = 0;
				Total_Prime_Manual_Company = 0;

				Query = "SELECT distinct comp_id,comp_assign_flag FROM Company WITH(NOLOCK), Aircraft_Reference WITH(NOLOCK) ";
				Query = $"{Query}WHERE comp_journ_id=0 and comp_id = cref_comp_id and comp_journ_id = cref_journ_id ";
				Query = $"{Query}and cref_primary_poc_flag='Y' and comp_active_flag='Y' AND comp_account_id = '{Convert.ToString(snp_ACSummary["accrep_account_id"]).Trim()}' ";

				Query = $"{Query}group by comp_id,comp_assign_flag";

				snp_Company_Total = new ADORecordSetHelper();
				snp_Company_Total.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_Company_Total.BOF && snp_Company_Total.EOF))
				{
					modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Counting Primary Company Records...", Color.Blue);

					while(!snp_Company_Total.EOF)
					{
						Application.DoEvents();
						if (Stopped)
						{
							break;
						}
						if (Convert.ToString(snp_Company_Total["comp_assign_flag"]) == "A")
						{
							Total_Prime_Automatic_Company++;
						}
						else
						{
							Total_Prime_Manual_Company++;
						}
						Total_Prime_Company++;

						snp_Company_Total.MoveNext();
					};
				}

				snp_Company_Total.Close();
				snp_Company_Total = null;
			}
			catch (System.Exception excep)
			{

				this.Cursor = CursorHelper.CursorDefault;
				HadHourglass = false;
				modAdminCommon.Report_Error($"Get_Company_Total_Error: {excep.Message}");
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
			}
		}

		public void Get_Aircraft_Count(string inScope)
		{

			string Query = "";
			ADORecordSetHelper snp_Aircraft_Total = new ADORecordSetHelper(); //8/1/05 aey converted to ado
			int RememberTimeout = 0;
			int AC_ID = 0;
			string Query2 = "";
			bool Resp = false;

			try
			{

				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Getting Aircraft Records...", Color.Blue);
				Application.DoEvents();
				Total_Aircraft = 0;
				Total_Automatic_Aircraft = 0;
				Total_Manual_Aircraft = 0;

				Query = "SELECT distinct comp_id, comp_assign_flag, cref_ac_id FROM Company ";
				Query = $"{Query}inner join Aircraft_Reference on comp_id=cref_comp_id and comp_journ_id=cref_journ_id ";

				if (cmbResearchType.Text.StartsWith("B", StringComparison.Ordinal))
				{
					Query = $"{Query}inner join Aircraft on ac_id=cref_ac_id and ac_journ_id=cref_journ_id ";
					Query = $"{Query}inner join aircraft_model on amod_id=ac_amod_id ";
				}
				Query = $"{Query}WHERE comp_account_id='{($"{Convert.ToString(snp_ACSummary["accrep_account_id"])} ").Trim()}' ";
				if (cmbResearchType.Text.StartsWith("B", StringComparison.Ordinal))
				{
					Query = $"{Query}and (amod_airframe_type_code = 'F' or ( amod_airframe_type_code = 'R' and amod_class_code='A')) ";
					Query = $"{Query}and (ac_use_code <> 'C' ) ";
				}

				Query = $"{Query}and (cref_journ_id = 0) and (cref_primary_poc_flag='Y')";

				RememberTimeout = UpgradeHelpers.DB.DbConnectionHelper.GetCommandTimeOut(modAdminCommon.LOCAL_ADO_DB);
				UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(modAdminCommon.LOCAL_ADO_DB, 1000);

				snp_Aircraft_Total.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(modAdminCommon.LOCAL_ADO_DB, RememberTimeout);

				if (!(snp_Aircraft_Total.BOF && snp_Aircraft_Total.EOF))
				{

					modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Counting Aircraft Records...", Color.Blue);

					if (inScope != "All" && AC_Row == 0)
					{
						GrdAircraftDetail.CurrentRowIndex = 0;
						GrdAircraftDetail.CurrentColumnIndex = 0;
						GrdAircraftDetail[GrdAircraftDetail.CurrentRowIndex, GrdAircraftDetail.CurrentColumnIndex].Value = "Rep";
						GrdAircraftDetail.CurrentColumnIndex = 1;
						GrdAircraftDetail[GrdAircraftDetail.CurrentRowIndex, GrdAircraftDetail.CurrentColumnIndex].Value = "Aircraft ID";
						//Rotary/fixed???
					}


					while(!snp_Aircraft_Total.EOF)
					{
						Application.DoEvents();
						if (Stopped)
						{
							break;
						}

						AC_ID = Convert.ToInt32(snp_Aircraft_Total["cref_ac_id"]);

						Resp = false;

						switch(inScope)
						{
							case "All" : 
								Resp = true; 
								break;
							case "Missing Operator" : 
								Query2 = $"Select cref_ac_id from aircraft_reference WITH(NOLOCK) Where cref_transmit_seq_no =2 and cref_journ_id=0 and cref_ac_id={AC_ID.ToString()}"; 
								 
								if (!modAdminCommon.Exist(Query2))
								{
									Resp = true;
								} 
								break;
							case "Missing Chief Pilot" : 
								Query2 = $"Select cref_ac_id from aircraft_reference  WITH(NOLOCK) Where cref_contact_type='44' and cref_journ_id=0 and cref_ac_id={AC_ID.ToString()}"; 
								if (!modAdminCommon.Exist(Query2))
								{
									Resp = true;
								} 
								break;
							case "Missing Base" : 
								Query2 = "Select ac_id from aircraft WITH(NOLOCK) Where ((ac_aport_iata_code is null or ac_aport_iata_code ='') "; 
								Query2 = $"{Query2} and (ac_aport_icao_code is null  or ac_aport_icao_code ='' )) and ac_journ_id=0 and ac_id = {AC_ID.ToString()}"; 
								if (modAdminCommon.Exist(Query2))
								{
									Resp = true;
								} 
								break;
						}

						if (Resp)
						{
							if (Convert.ToString(snp_Aircraft_Total["comp_assign_flag"]) == "A")
							{
								Total_Automatic_Aircraft++;
							}
							else
							{
								Total_Manual_Aircraft++;
							}
							Total_Aircraft++;
							AC_Row++;

							if (inScope != "All")
							{
								GrdAircraftDetail.RowsCount = AC_Row + 1;
								GrdAircraftDetail.CurrentRowIndex = AC_Row;
								GrdAircraftDetail.CurrentColumnIndex = 0;
								GrdAircraftDetail[GrdAircraftDetail.CurrentRowIndex, GrdAircraftDetail.CurrentColumnIndex].Value = $"{Convert.ToString(snp_ACSummary["accrep_account_id"])}";
								GrdAircraftDetail.CurrentColumnIndex = 1;
								GrdAircraftDetail[GrdAircraftDetail.CurrentRowIndex, GrdAircraftDetail.CurrentColumnIndex].Value = AC_ID;
							}
						}

						snp_Aircraft_Total.MoveNext();
					};
				}

				snp_Aircraft_Total.Close();
				snp_Aircraft_Total = null;
			}
			catch (System.Exception excep)
			{

				this.Cursor = CursorHelper.CursorDefault;
				HadHourglass = false;
				modAdminCommon.Report_Error($"Get_Aircraft_Total_Error: {excep.Message} {inScope}");
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
				return;
			}

		}

		public void Select_Account()
		{

			try
			{

				snp_ACSummary.MoveFirst();
				int tempForEndVar = grdACSummary.CurrentRowIndex - 1;
				for (int i = 0; i <= tempForEndVar; i++)
				{
					snp_ACSummary.MoveNext();
				}
			}
			catch (System.Exception excep)
			{

				this.Cursor = CursorHelper.CursorDefault;
				HadHourglass = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Select_Account_Error: {Information.Err().Number.ToString()} {excep.Message}");
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
				return;
			}

		}

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

		private void Form_Closed(Object eventSender, EventArgs eventArgs) => snp_Assign = null;


		private void frmAcctAssignments_Click(Object eventSender, EventArgs eventArgs)
		{


			frmAcctAssignments.Enabled = false;
			string strHeader = "AcctId|Comp Auto|Comp Manual|Comp Total|Prime Comp Auto|Prime Comp Manual|Total Prime Comp";
			if (chkIncludeACCount.CheckState == CheckState.Checked)
			{
				strHeader = $"{strHeader}|A/C Auto|A/C Manual|Total A/C";
			}
			modExcel.ExportMSHFlexGrid(grdACSummary, strHeader);
			frmAcctAssignments.Enabled = true;

		}

		private void GrdAircraftDetail_DoubleClick(Object eventSender, EventArgs eventArgs)
		{

			GrdAircraftDetail.CurrentColumnIndex = 1;
			int AC_ID = Convert.ToInt32(Conversion.Val($"{GrdAircraftDetail[GrdAircraftDetail.CurrentRowIndex, GrdAircraftDetail.CurrentColumnIndex].FormattedValue.ToString()}"));
			modAdminCommon.gbl_Aircraft_ID = AC_ID;

			if (modAdminCommon.gbl_Aircraft_ID > 0)
			{

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

			} // If gbl_Aircraft_ID > 0 Then

		}

		private void grdSchedule_Click(Object eventSender, EventArgs eventArgs)
		{

			if (optCallbackSchedule.Checked)
			{
				ListScheduleCompanies();
			}

		}

		private void grdSchedule_DoubleClick(Object eventSender, EventArgs eventArgs)
		{

			if (optAccountRepActivity.Checked)
			{
				ShowJournalList();
			}

		}


		private void lbl_account_character_Click(Object eventSender, EventArgs eventArgs)
		{
			strAssignSort = "order by assign_character";
			Fill_Account_Assignment_List();
		}

		private void lbl_account_Click(Object eventSender, EventArgs eventArgs)
		{
			int Index = Array.IndexOf(this.lbl_account, eventSender);

			if (Index == 4 || Index == 14)
			{
				lbl_account[18].Visible = true;
				cmbResearchType.Visible = true;
			}

			if (Index == 18)
			{
				lbl_account[18].Visible = false;
				cmbResearchType.Visible = false;
			}

			Application.DoEvents();

		}

		private void lbl_db_account_id_Click(Object eventSender, EventArgs eventArgs)
		{
			strAssignSort = "order by assign_db_account_id,assign_character";
			Fill_Account_Assignment_List();
		}

		private void lbl_eu_account_id_Click(Object eventSender, EventArgs eventArgs)
		{
			strAssignSort = "order by assign_eu_account_id,assign_character";
			Fill_Account_Assignment_List();
		}

		private void grdacsummary_Click(Object eventSender, EventArgs eventArgs)
		{
			//Shouldn't be able to call unless Grid is finished loading.
			Select_Account();
			cbo_Account_ID.Text = Convert.ToString(snp_ACSummary["accrep_account_id"]);
		}

		private void grdacsummary_DoubleClick(Object eventSender, EventArgs eventArgs)
		{
			Select_Account();
			frm_ActionList.DefInstance.Show();
		}

		public void Display_Account_Rep_Lists()
		{
			//  Fill Dealer-Broker and End User Account List
			modFillCompConControls.Fill_AccountRep_FromArray(cbo_assign_db_account_id, false, true);
			modFillCompConControls.Fill_AccountRep_FromArray(cbo_assign_eu_account_id, false, true);

		}

		public void Select_Assignment()
		{
			try
			{


				if (snp_Assign.BOF && snp_Assign.EOF)
				{
					return;
				}

				snp_Assign.MoveFirst();
				int tempForEndVar = ListBoxHelper.GetSelectedIndex(lst_Assign);
				for (int i = 1; i <= tempForEndVar; i++)
				{
					snp_Assign.MoveNext();
				}
				txt_assign_character.Text = $"{Convert.ToString(snp_Assign["assign_character"])}";
				cbo_assign_db_account_id.Text = $"{Convert.ToString(snp_Assign["assign_db_account_id"])}";
				tmp_db_account_id = $"{Convert.ToString(snp_Assign["assign_db_account_id"])}";
				cbo_assign_eu_account_id.Text = $"{Convert.ToString(snp_Assign["assign_eu_account_id"])}";
				tmp_eu_account_id = $"{Convert.ToString(snp_Assign["assign_eu_account_id"])}";
				cmd_Save_Assignments.Visible = false;
				pnl_AutoAssign.Visible = true;
				Count_Assignments();
			}
			catch
			{

				this.Cursor = CursorHelper.CursorDefault;
				HadHourglass = false;
				modAdminCommon.Report_Error("Select_Assignment_Error: ");
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
				return;
			}
		}

		private void lst_Assign_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{
			this.Cursor = Cursors.WaitCursor;
			txt_assign_character.Text = "";
			txt_db_count.Text = "";
			txt_db_prime_count.Text = "";
			txt_eu_count.Text = "";
			txt_eu_prime_count.Text = "";
			Application.DoEvents();

			Select_Assignment();

			this.Cursor = CursorHelper.CursorDefault;

		}

		private void lst_Unassigned_DoubleClick(Object eventSender, EventArgs eventArgs) => Select_Unassigned_Aircraft();


		private void lstCompany_DoubleClick(Object eventSender, EventArgs eventArgs)
		{

			frm_Company o_Local_Show_Company = null;

			if (ListBoxHelper.GetSelectedIndex(lstCompany) > -1)
			{

				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Loading Company/Contact Form...", Color.Blue);

				modCommon.Unload_Form("frm_Company");
				o_Local_Show_Company = frm_Company.CreateInstance();
				//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//VB.Global.Load(o_Local_Show_Company);
				o_Local_Show_Company.Form_Initialize();
				o_Local_Show_Company.StartForm = modGlobalVars.tStart_Form;
				o_Local_Show_Company.Reference_CompanyID = lstCompany.GetItemData(ListBoxHelper.GetSelectedIndex(lstCompany));
				o_Local_Show_Company.Reference_CompanyJID = 0;
				o_Local_Show_Company.Show();
				//UPGRADE_WARNING: (2065) Form method o_Local_Show_Company.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
				o_Local_Show_Company.BringToFront();
				//UPGRADE_WARNING: (2065) Form event Form.Activated has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
				o_Local_Show_Company.Form_Activated(null, new EventArgs());

			}

		}

		public void mnuAddAccountID_Click(Object eventSender, EventArgs eventArgs)
		{

			pnlAddNewAccountID.Visible = true;
			pnlAddNewAccountID.Enabled = true;
			txtNewAccountID.Enabled = true;
			txtNewAccountID.Text = "";
			lblNewAccountID.Enabled = true;
			cmdSaveNewAccountID.Enabled = true;
			cmdCancelNewAccountID.Enabled = true;
			cmdDeleteNewAccountID.Enabled = true;

			pnlAddNewAccountID.BringToFront();

			txtNewAccountID.Focus();

		}

		public void mnuFileClose_Click(Object eventSender, EventArgs eventArgs) => this.Close();


		public void Fill_Unassigned_Aircraft_List()
		{
			string Query = "";
			int i = 0;
			int TotFound = 0;
			int RememberTimeout = 0;
			string ACQuery = ""; // String for checking if a primary cross reference for an aircraft exists

			string primequery = "SELECT distinct cref_ac_id  FROM Company WITH(NOLOCK) , Aircraft_Reference ";
			primequery = $"{primequery}WHERE (comp_id=cref_comp_id and comp_journ_id=cref_journ_id) ";
			primequery = $"{primequery}and (cref_journ_id = 0) and (cref_primary_poc_flag='Y')";

			this.Cursor = Cursors.WaitCursor;
			Stopped = false;
			cmdStop.Visible = false;

			Application.DoEvents();

			try
			{
				i = 0;
				TotFound = 0;
				lst_Unassigned.Items.Clear();
				Query = "SELECT ac_id,amod_make_name,amod_model_name,ac_status,ac_ser_no_prefix,ac_ser_no,ac_ser_no_suffix,ac_ser_no_full,ac_lifecycle_stage ";
				Query = $"{Query}FROM Aircraft WITH(NOLOCK) ,Aircraft_Model  WHERE ac_amod_id=amod_id AND ac_journ_id = 0 ";
				Query = $"{Query}and ac_lifecycle_stage <> 4 and ac_id not in ({primequery}) ORDER BY amod_make_name,amod_model_name ";

				RememberTimeout = UpgradeHelpers.DB.DbConnectionHelper.GetCommandTimeOut(modAdminCommon.LOCAL_ADO_DB);
				UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(modAdminCommon.LOCAL_ADO_DB, 300);

				snp_Unassign.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				UpgradeHelpers.DB.DbConnectionHelper.SetCommandTimeOut(modAdminCommon.LOCAL_ADO_DB, RememberTimeout);

				if (!(snp_Unassign.BOF && snp_Unassign.EOF))
				{
					snp_Unassign.MoveLast();
					snp_Unassign.MoveFirst();

					txtTotalUnAssigned.Text = snp_Unassign.RecordCount.ToString();

					mdi_ResearchAssistant.DefInstance.prg_Progress_Bar.Maximum = snp_Unassign.RecordCount;
					mdi_ResearchAssistant.DefInstance.prg_Progress_Bar.Value = 0;
					mdi_ResearchAssistant.DefInstance.prg_Progress_Bar.Visible = true;

					cmdStop.Visible = true;
					Application.DoEvents();

					while(!snp_Unassign.EOF)
					{
						if (Stopped)
						{
							break;
						}
						i++;
						txt_RecCount.Text = i.ToString();
						Application.DoEvents();

						ACQuery = $"select * from Aircraft_Reference WITH(NOLOCK) where cref_ac_id={($"{Convert.ToString(snp_Unassign["AC_ID"])} ").Trim()} and (cref_primary_poc_flag='Y' or cref_primary_poc_flag='X') ";
						//If Not Exist(ACQuery) Then
						TotFound++;
						txt_FoundCount.Text = TotFound.ToString();
						lst_Unassigned.AddItem($"{($"{Convert.ToString(snp_Unassign["ac_ser_no_full"])}").Trim()} ---> {StringsHelper.Format(($"{Convert.ToString(snp_Unassign["AC_ID"])} ").Trim(), "######")} ---> {($"{Convert.ToString(snp_Unassign["amod_make_name"])} ").Trim()} {($"{Convert.ToString(snp_Unassign["amod_model_name"])} ").Trim()}  {($"{Convert.ToString(snp_Unassign["ac_status"])}").Trim()}");
						lst_Unassigned.SetItemData(lst_Unassigned.Items.Count - 1, Convert.ToInt32(Double.Parse(($"{Convert.ToString(snp_Unassign["AC_ID"])}").Trim())));
						Application.DoEvents();
						// End If
						//End If

						mdi_ResearchAssistant.DefInstance.prg_Progress_Bar.Value = TotFound;
						snp_Unassign.MoveNext();
					};
					if (lst_Unassigned.Items.Count > 0)
					{
						ListBoxHelper.SetSelectedIndex(lst_Unassigned, 0);
					}
				}

				this.Cursor = CursorHelper.CursorDefault;
				HadHourglass = false;
				cmdStop.Visible = false;
				mdi_ResearchAssistant.DefInstance.prg_Progress_Bar.Visible = false;
			}
			catch (System.Exception excep)
			{

				//  MsgBox ("Fill_Unassigned_Aircraft_List_Error: " & Err.Description)
				modAdminCommon.Report_Error($"Fill_Unassigned_Aircraft_List_Error:  {excep.Message}", "User_Accounts");
				this.Cursor = CursorHelper.CursorDefault;
			}
		}

		public void Select_Unassigned_Aircraft()
		{

			try
			{

				string tmpStr = "";

				tmpStr = lst_Unassigned.GetListItem(ListBoxHelper.GetSelectedIndex(lst_Unassigned));

				modAdminCommon.gbl_Aircraft_ID = Convert.ToInt32(Double.Parse(lst_Unassigned.GetListItem(ListBoxHelper.GetSelectedIndex(lst_Unassigned)).Substring(Math.Min(tmpStr.IndexOf("--->") + 4, lst_Unassigned.GetListItem(ListBoxHelper.GetSelectedIndex(lst_Unassigned)).Length), Math.Min(6, Math.Max(0, lst_Unassigned.GetListItem(ListBoxHelper.GetSelectedIndex(lst_Unassigned)).Length - (tmpStr.IndexOf("--->") + 4))))));
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
			catch
			{

				this.Cursor = CursorHelper.CursorDefault;
				HadHourglass = false;
				modAdminCommon.Report_Error("Select_Unassigned_Aircraft_Error: ");
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
			}

		} // Select_Unassigned_Aircraft

		public void mnuFileLogout_Click(Object eventSender, EventArgs eventArgs) => frm_Main_Menu.DefInstance.Close();


		public void Count_Assignments()
		{

			txt_eu_count.Text = "0";
			txt_db_count.Text = "0";

			try
			{

				txt_db_count.Text = GetCount("All", "DB");
				txt_db_prime_count.Text = GetCount("Prime", "DB");
				txt_eu_count.Text = GetCount("All", "EU");
				txt_eu_prime_count.Text = GetCount("Prime", "EU");
			}
			catch
			{

				this.Cursor = CursorHelper.CursorDefault;
				HadHourglass = false;
				modAdminCommon.Report_Error("Count_Assignment_Error: ");
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
				return;
			}


		}

		public void mnuFixSerNoSort_Click(Object eventSender, EventArgs eventArgs)
		{
			int AC_ID = 0;
			string SerPrefix = "";
			string SerNo = "";
			string SerSuffix = "";
			string OldSerSort = "";
			string NewSerSort = "";
			string AirframeType = "";
			ADORecordSetHelper ado_serSort = new ADORecordSetHelper();

			int amod_ID = Convert.ToInt32(Conversion.Val($"{InputBoxHelper.InputBox("Enter Amod_id", "Fix Ser Nums")}"));
			if (amod_ID == 0)
			{
				return;
			}

			this.Cursor = Cursors.WaitCursor;

			string Query = "select ac_id,ac_ser_no_prefix,ac_ser_no,ac_ser_no_suffix,ac_ser_no_sort,amod_airframe_type_code from aircraft ";
			Query = $"{Query}inner join aircraft_model on amod_id=ac_amod_id Where amod_id = {amod_ID.ToString()} and ac_journ_id =0 ";

			ado_serSort.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

			if (!(ado_serSort.EOF && ado_serSort.BOF))
			{
				ado_serSort.MoveFirst();

				while (!ado_serSort.EOF)
				{
					AC_ID = Convert.ToInt32(Double.Parse($"{Convert.ToString(ado_serSort["AC_ID"])}"));
					SerPrefix = $"{Convert.ToString(ado_serSort["ac_ser_no_prefix"])}";
					SerNo = $"{Convert.ToString(ado_serSort["ac_ser_no"])}";
					SerSuffix = $"{Convert.ToString(ado_serSort["ac_ser_no_suffix"])}";
					OldSerSort = $"{Convert.ToString(ado_serSort["ac_ser_no_sort"])}";
					AirframeType = $"{Convert.ToString(ado_serSort["amod_airframe_type_code"])}";

					NewSerSort = modCommon.Format_Ser_No_Sort(SerPrefix, SerNo, SerSuffix, AirframeType);

					if (OldSerSort != NewSerSort)
					{
						Query = $"update aircraft set ac_ser_no_sort ='{NewSerSort}'  where ac_journ_id=0 and ac_id= {AC_ID.ToString()} ";

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


					ado_serSort.MoveNext();
				}
			}

			ado_serSort.Close();
			ado_serSort = null;

			this.Cursor = CursorHelper.CursorDefault;
			MessageBox.Show("done", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));

		}





		public void mnuResetAuto_Click(Object eventSender, EventArgs eventArgs) => ResetAutoAssignments();


		private void ResetAutoAssignments()
		{


			string Query = "";
			ADORecordSetHelper snpReps = new ADORecordSetHelper(); //8/1/05 aey converted to ado

			try
			{

				this.Cursor = Cursors.WaitCursor;
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Getting Account Rep Records...", Color.Blue);

				Query = "SELECT * FROM Account_Rep_Assignment WITH(NOLOCK) ";

				snpReps.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpReps.BOF && snpReps.EOF))
				{


					while(!snpReps.EOF)
					{

						modStatusBar.Update_Status_Bar(modAdminCommon.SB, $"Processing - {($"{Convert.ToString(snpReps["assign_db_account_id"])}").Trim()} - '{($"{Convert.ToString(snpReps["assign_character"])}").Trim()}'", Color.Blue);
						Application.DoEvents();

						Query = $"UPDATE Company SET comp_account_id = '{($"{Convert.ToString(snpReps["assign_db_account_id"])}").Trim()}' ";

						Query = $"{Query}WHERE comp_assign_flag = 'A' AND comp_account_type = 'DB' ";
						Query = $"{Query}AND comp_name LIKE '{($"{Convert.ToString(snpReps["assign_character"])}").Trim()}%' ";

						DbCommand TempCommand = null;
						TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
						TempCommand.CommandText = Query;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
						TempCommand.ExecuteNonQuery();

						modStatusBar.Update_Status_Bar(modAdminCommon.SB, $"Processing - {($"{Convert.ToString(snpReps["assign_eu_account_id"])}").Trim()} - '{($"{Convert.ToString(snpReps["assign_character"])}").Trim()}'", Color.Blue);
						Application.DoEvents();

						Query = $"UPDATE Company SET comp_account_id = '{($"{Convert.ToString(snpReps["assign_eu_account_id"])}").Trim()}' ";

						Query = $"{Query}WHERE comp_assign_flag = 'A' AND comp_account_type = 'EU' AND comp_name LIKE '{($"{Convert.ToString(snpReps["assign_character"])}").Trim()}%' ";

						DbCommand TempCommand_2 = null;
						TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
						TempCommand_2.CommandText = Query;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand_2.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
						TempCommand_2.ExecuteNonQuery();


						snpReps.MoveNext();
					};
				}

				snpReps.Close();
				snpReps = null;
				MessageBox.Show("done with account rep reassigns.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
				this.Cursor = CursorHelper.CursorDefault;
			}
			catch (System.Exception excep)
			{
				modAdminCommon.Report_Error($"ResetAutoAssignments_Error: {excep.Message}", "User_Accounts");
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
				this.Cursor = CursorHelper.CursorDefault;
			}

		}

		private void MonthView1_Click(Object eventSender, EventArgs eventArgs) => txtDate1.Text = MonthView1.SelectionRange.Start.ToString("d");


		//UPGRADE_WARNING: (2050) MSComCtl2.MonthView Event MonthView1.DateClick was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2050
		private void MonthView1_DateClick(System.DateTime DateClicked) => txtDate1.Text = MonthView1.SelectionRange.Start.ToString("d");


		private void MonthView1_Enter(Object eventSender, EventArgs eventArgs) => mvHasFocus = true;


		private void MonthView2_Click(Object eventSender, EventArgs eventArgs) => txtDate2.Text = MonthView2.SelectionRange.Start.ToString("d");


		//UPGRADE_WARNING: (2050) MSComCtl2.MonthView Event MonthView2.DateClick was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2050
		private void MonthView2_DateClick(System.DateTime DateClicked) => txtDate2.Text = MonthView2.SelectionRange.Start.ToString("d");


		private void MonthView2_Enter(Object eventSender, EventArgs eventArgs) => mvHasFocus = true;


		private bool isInitializingComponent;
		private void optAccountRepActivity_CheckedChanged(Object eventSender, EventArgs eventArgs)
		{
			if (((RadioButton) eventSender).Checked)
			{
				if (isInitializingComponent)
				{
					return;
				}

				wbAcctRepActivity.Navigate(new Uri("about:blank"));
				wbAcctRepActivity.Visible = true;

				FillComboAcctRep();

				chkAllActivityReports.Enabled = true;
				chkAllActivityReports.CheckState = CheckState.Unchecked;

			}
		}

		private void optCallbackSchedule_CheckedChanged(Object eventSender, EventArgs eventArgs)
		{
			if (((RadioButton) eventSender).Checked)
			{
				if (isInitializingComponent)
				{
					return;
				}

				wbAcctRepActivity.Visible = false;
				wbAcctRepActivity.Navigate(new Uri("about:blank"));

				FillComboAcctRep();

				chkAllActivityReports.CheckState = CheckState.Unchecked;
				chkAllActivityReports.Enabled = false;

			}
		}

		private void pnl_AircraftDetail_Click(Object eventSender, EventArgs eventArgs)
		{

			pnl_AircraftDetail.Enabled = false;
			modExcel.ExportMSHFlexGrid(GrdAircraftDetail);
			pnl_AircraftDetail.Enabled = true;

		}

		private void tbr_ToolBar_ButtonClick(Object eventSender, EventArgs eventArgs)
		{
			ToolStripItem Button = (ToolStripItem) eventSender;

			try
			{



				switch(Button.Name)
				{
					case "Home" : 
						frm_Main_Menu.DefInstance.Show(); 
						this.Close(); 
						 
						break;
					case "Back" : 
						mnuFileClose_Click(mnuFileClose, new EventArgs()); 
						 
						break;
					case "Save" : 
						MessageBox.Show("This is nothing to Save", "User Accounts", MessageBoxButtons.OK, MessageBoxIcon.Information); 
						 
						break;
					case "Help" : 
						MessageBox.Show("Help is forthcoming", "User Accounts", MessageBoxButtons.OK, MessageBoxIcon.Information); 
						 
						break;
				}
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"tbr_ToolBar_Error: User_Accts {Button.Name} {excep.Message}");
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
				return;
			}

		}

		private void ToolbarButtonsSetup()
		{


			ToolStrip tbr = tbr_ToolBar;

			tbr.Items[1].Visible = true;
			tbr.Items[3].Visible = true;
			tbr.Items[5].Visible = true;
			tbr.Items[7].Visible = true;

			tbr.Items[1].Enabled = true;
			tbr.Items[3].Enabled = true;
			tbr.Items[5].Enabled = true;
			tbr.Items[7].Enabled = true;

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

		public void Fill_Dup_POC_List()
		{
			string Query = "";
			ADORecordSetHelper snp_Dup = new ADORecordSetHelper(); //8/1/05 aey converted to ado  Snapshot
			int found = 0;

			this.Cursor = Cursors.WaitCursor;
			try
			{
				found = 0;
				lst_dup.Items.Clear();
				Query = "SELECT cref_ac_id,cref_comp_id,count(*) as tcount FROM Aircraft WITH(NOLOCK) ";
				Query = $"{Query}inner join Aircraft_Reference WITH(NOLOCK) on ac_id=cref_ac_id and ac_journ_id=cref_journ_id ";
				Query = $"{Query}WHERE ac_journ_id=0  AND (cref_primary_poc_flag='Y') GROUP BY cref_ac_id,cref_comp_id ";

				snp_Dup.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_Dup.BOF && snp_Dup.EOF))
				{
					snp_Dup.MoveFirst();

					while(!snp_Dup.EOF)
					{
						txt_message.Text = $"Checking {Convert.ToString(snp_Dup["cref_ac_id"])}-{Convert.ToString(snp_Dup["cref_comp_id"])} ....";
						if (Convert.ToDouble(snp_Dup["tcount"]) > 1)
						{
							lst_dup.AddItem($"{Convert.ToString(snp_Dup["cref_ac_id"])}-{Convert.ToString(snp_Dup["cref_comp_id"])}");
							found = 1;
						}
						snp_Dup.MoveNext();
					};

				}
				if (found == 0)
				{
					MessageBox.Show("Found no duplicate POCs", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}
				this.Cursor = CursorHelper.CursorDefault;
				HadHourglass = false;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"Fill_Dup_POC_Error: {excep.Message}", "User_Accounts");
				this.Cursor = CursorHelper.CursorDefault;
			}
		}

		private void txtAcctRep_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
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


		private void txtNewAccountID_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
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

		public void Get_Unused_AC()
		{
			string Query = "";
			ADORecordSetHelper snp_Aircraft_Total = new ADORecordSetHelper();

			try
			{

				Query = "SELECT count(*) as tcount FROM Aircraft WITH(NOLOCK) WHERE ac_lifecycle_stage = 4 and (ac_journ_id = 0) ";
				snp_Aircraft_Total.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
				if (!(snp_Aircraft_Total.BOF && snp_Aircraft_Total.EOF))
				{
					snp_Aircraft_Total.MoveFirst();
					txt_tot_AC_unused.Text = modAdminCommon.gbl_RightAdjust(StringsHelper.Format(snp_Aircraft_Total["tcount"], "###,###"), "###,###");
					Application.DoEvents();
				}

				if (snp_Aircraft_Total != null)
				{
					if (snp_Aircraft_Total.State == ConnectionState.Open)
					{ // Already Open Close It
						snp_Aircraft_Total.Close();
					}
					snp_Aircraft_Total = null;
				}
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"Get_Unused_AC_Error: {excep.Message}", "User_Accounts");
			}

		}


		public void Save_Account_Assignment_Changes()
		{

			string Query = "";

			if (cbo_assign_db_account_id.Text.Trim() != tmp_db_account_id.Trim())
			{

				if (MessageBox.Show($"Are you sure you want to assign all of the '{txt_assign_character.Text.Trim()}' companies from {tmp_db_account_id.Trim()} to {cbo_assign_db_account_id.Text.Trim()}?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
				{
					// update the account assignment table
					this.Cursor = Cursors.WaitCursor;
					Query = $"update Account_Rep_Assignment set assign_db_account_id='{cbo_assign_db_account_id.Text.Trim()}' ";
					Query = $"{Query}where assign_db_account_id='{tmp_db_account_id.Trim()}' and assign_character='{txt_assign_character.Text.Trim()}'";
					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();


					this.Cursor = Cursors.WaitCursor;
					Application.DoEvents();
					Query = $"update Journal set journ_account_id='{cbo_assign_db_account_id.Text.Trim()}' ";
					Query = $"{Query}where journ_account_id='{tmp_db_account_id.Trim()}' and journ_subcategory_code='AA' and journ_comp_id in (select comp_id from company ";
					Query = $"{Query}where comp_account_id='{tmp_db_account_id.Trim()}' ";
					Query = $"{Query}and comp_assign_flag='A' and comp_account_type='DB' and comp_journ_id = 0 ";
					Query = $"{Query} and (comp_product_business_flag = 'Y' or comp_product_helicopter_flag = 'Y' or comp_product_commercial_flag = 'Y') ";
					Query = $"{Query}and comp_name like '{txt_assign_character.Text.Trim()}%')";

					DbCommand TempCommand_2 = null;
					TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
					TempCommand_2.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand_2.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
					TempCommand_2.ExecuteNonQuery();


					// update the company account assignment
					Query = $"update Company set comp_account_id='{cbo_assign_db_account_id.Text.Trim()}' ";
					Query = $"{Query}where comp_account_id='{tmp_db_account_id.Trim()}' ";
					Query = $"{Query}and comp_assign_flag='A' and comp_account_type='DB' and comp_journ_id = 0 ";
					Query = $"{Query} and (comp_product_business_flag = 'Y' or comp_product_helicopter_flag = 'Y' or comp_product_commercial_flag = 'Y') ";
					Query = $"{Query}and comp_name like '{txt_assign_character.Text.Trim()}%'";

					DbCommand TempCommand_3 = null;
					TempCommand_3 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_3);
					TempCommand_3.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand_3.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_3);
					TempCommand_3.ExecuteNonQuery();


					Fill_Account_Assignment_List();
					this.Cursor = CursorHelper.CursorDefault;
					HadHourglass = false;
				}

			}

			if (cbo_assign_eu_account_id.Text.Trim() != tmp_eu_account_id.Trim())
			{

				if (MessageBox.Show($"Are you sure you want to assign all of the '{txt_assign_character.Text.Trim()}' companies from {tmp_eu_account_id.Trim()} to {cbo_assign_eu_account_id.Text.Trim()}?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
				{

					// update the account assignment table
					this.Cursor = Cursors.WaitCursor;
					Application.DoEvents();
					Query = $"update Account_Rep_Assignment set assign_eu_account_id='{cbo_assign_eu_account_id.Text.Trim()}' ";
					Query = $"{Query}where assign_eu_account_id='{tmp_eu_account_id.Trim()}' and assign_character='{txt_assign_character.Text.Trim()}'";
					DbCommand TempCommand_4 = null;
					TempCommand_4 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_4);
					TempCommand_4.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand_4.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_4);
					TempCommand_4.ExecuteNonQuery();


					// update the reassigns
					this.Cursor = Cursors.WaitCursor;
					Query = $"update Journal set journ_account_id='{cbo_assign_eu_account_id.Text.Trim()}' ";
					Query = $"{Query}where journ_account_id='{tmp_eu_account_id.Trim()}' and journ_subcategory_code='AA' and journ_comp_id in (select comp_id from company ";
					Query = $"{Query}where comp_account_id='{tmp_eu_account_id.Trim()}' and comp_assign_flag='A' ";
					Query = $"{Query}and comp_account_type='EU' and comp_journ_id = 0 ";
					Query = $"{Query} and (comp_product_business_flag = 'Y' or comp_product_helicopter_flag = 'Y' or comp_product_commercial_flag = 'Y') ";
					Query = $"{Query}and comp_name like '{txt_assign_character.Text.Trim()}%')";
					// LOCAL_DB.Execute Query, dbSQLPassThrough
					DbCommand TempCommand_5 = null;
					TempCommand_5 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_5);
					TempCommand_5.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand_5.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_5);
					TempCommand_5.ExecuteNonQuery();


					// update the company account assignment
					Query = $"update Company set comp_account_id='{cbo_assign_eu_account_id.Text.Trim()}' ";
					Query = $"{Query}where comp_account_id='{tmp_eu_account_id.Trim()}' ";
					Query = $"{Query}and comp_assign_flag='A'   and comp_account_type='EU' and comp_journ_id = 0 ";
					Query = $"{Query} and (comp_product_business_flag = 'Y' or comp_product_helicopter_flag = 'Y' or comp_product_commercial_flag = 'Y') ";
					Query = $"{Query}and comp_name like '{txt_assign_character.Text.Trim()}%'";
					//LOCAL_DB.Execute Query, dbSQLPassThrough
					DbCommand TempCommand_6 = null;
					TempCommand_6 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_6);
					TempCommand_6.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand_6.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_6);
					TempCommand_6.ExecuteNonQuery();


					Fill_Account_Assignment_List();
					this.Cursor = CursorHelper.CursorDefault;
					HadHourglass = false;
				}

			}

		}

		private int Get_Companies_Verified_AC_Status(string strUserId)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();

			string strQuery1 = "SELECT COUNT(DISTINCT journ_comp_id) As TotCnt FROM Journal WITH (NOLOCK) ";
			strQuery1 = $"{strQuery1}WHERE (journ_subcategory_code = 'VS') AND (journ_comp_id > 0) AND (journ_user_id = '{strUserId}') ";

			if (chkIgnoreSchedDate1.CheckState == CheckState.Unchecked)
			{

				if (Strings.Len(txt_start_time.Text.Trim()) > 0)
				{
					strQuery1 = $"{strQuery1}AND (journ_entry_time >= '{MonthView1.SelectionRange.Start.ToString("MM/dd/yyyy")} {txt_start_time.Text.Trim()}') ";
				}
				else
				{
					strQuery1 = $"{strQuery1}AND (journ_entry_date >= '{MonthView1.SelectionRange.Start.ToString("MM/dd/yyyy")}') ";
				}

			} // If chkIgnoreSchedDate1.Value = vbUnchecked Then

			if (chkIgnoreSchedDate2.CheckState == CheckState.Unchecked)
			{

				// ADD IN THE END TIME
				if (Strings.Len(txt_end_time.Text.Trim()) > 0)
				{
					strQuery1 = $"{strQuery1}AND (journ_entry_time <= '{MonthView2.SelectionRange.Start.ToString("MM/dd/yyyy")} {txt_end_time.Text.Trim()}') ";
				}
				else
				{
					strQuery1 = $"{strQuery1}AND (journ_entry_date <= '{MonthView2.SelectionRange.Start.ToString("MM/dd/yyyy")}') ";
				}

			} // If chkIgnoreSchedDate1.Value = vbUnchecked Then

			rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

			int lTotCnt = 0;
			if (!rstRec1.BOF && !rstRec1.EOF)
			{
				lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
			}

			rstRec1.Close();
			rstRec1 = null;

			return lTotCnt;

		} // Get_Companies_Verified_AC_Status

		private int Get_Companies_Called_Unable_To_Verify_Status(string strUserId)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();

			string strQuery1 = "SELECT COUNT(DISTINCT journ_id) As TotCnt  FROM Journal WITH (NOLOCK) ";
			strQuery1 = $"{strQuery1}WHERE (journ_subcategory_code = 'RN') AND (journ_subject = 'Called. Not able to verify status') ";
			strQuery1 = $"{strQuery1}AND (journ_user_id = '{strUserId}') ";

			if (chkIgnoreSchedDate1.CheckState == CheckState.Unchecked)
			{

				// ADD IN THE START TIME
				if (Strings.Len(txt_start_time.Text.Trim()) > 0)
				{
					strQuery1 = $"{strQuery1}AND (journ_entry_time >= '{MonthView1.SelectionRange.Start.ToString("MM/dd/yyyy")} {txt_start_time.Text.Trim()}') ";
				}
				else
				{
					strQuery1 = $"{strQuery1}AND (journ_entry_date >= '{MonthView1.SelectionRange.Start.ToString("MM/dd/yyyy")}') ";
				}

			} // If chkIgnoreSchedDate1.Value = vbUnchecked Then

			if (chkIgnoreSchedDate2.CheckState == CheckState.Unchecked)
			{

				// ADD IN THE END TIME
				if (Strings.Len(txt_end_time.Text.Trim()) > 0)
				{
					strQuery1 = $"{strQuery1}AND (journ_entry_time <= '{MonthView2.SelectionRange.Start.ToString("MM/dd/yyyy")} {txt_end_time.Text.Trim()}') ";
				}
				else
				{
					strQuery1 = $"{strQuery1}AND (journ_entry_date <= '{MonthView2.SelectionRange.Start.ToString("MM/dd/yyyy")}') ";
				}

			} // If chkIgnoreSchedDate1.Value = vbUnchecked Then

			rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

			int lTotCnt = 0;
			if (!rstRec1.BOF && !rstRec1.EOF)
			{
				lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
			}

			rstRec1.Close();
			rstRec1 = null;

			return lTotCnt;

		} // Get_Companies_Called_Unable_To_Verify_Status

		private void Get_Company_Confirmation()
		{

			int totalcompanies = 0;
			int primarycompanies = 0;
			int primarytoconfirm = 0;
			int totalcompaniestoconfirm = 0;
			int totalcompaniesconfirmed = 0;
			double percentcompaniesconfirmed = 0;
			double percentcompaniestoconfirm = 0;
			string Query = "";
			System.DateTime targetdate = DateTime.FromOADate(0);
			string strTargetDate = "";
			int primaryconfirmed = 0;
			double percentprimaryconfirmed = 0;
			int daysconfirm = 0;
			double percentprimaryneedconfirm = 0;

			try
			{

				ADORecordSetHelper GetCompany = new ADORecordSetHelper();
				ADORecordSetHelper GetConfirm = new ADORecordSetHelper();
				this.Cursor = Cursors.WaitCursor;

				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Counting Active Companies. Please Wait!...", Color.Blue);
				modAdminCommon.Record_Event("User_Accounts ColorConfirmStatus", $"{Convert.ToString(modAdminCommon.snp_User["user_id"])} Started ");
				tmpStart = DateTime.Parse(modAdminCommon.GetDateTime()).ToString("HH:mm:ss");

				Application.DoEvents();


				Query = "SELECT count(*) as tcount FROM Company WITH(NOLOCK) where comp_journ_id = 0 and comp_active_flag='Y' ";
				GetCompany.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(GetCompany.BOF && GetCompany.EOF))
				{
					totalcompanies = Convert.ToInt32(GetCompany["tcount"]);
					txt_totalactivecompanies.Text = $"{totalcompanies.ToString()} total companies";
				}
				else
				{
					totalcompanies = 0;
					txt_totalactivecompanies.Text = "0 total companies";
				}
				GetCompany.Close();
				GetCompany = null;

				// COUNTING THE NUMBER OF PRIMARY COMPANIES
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Counting Primary Companies. Please Wait!...", Color.Blue);
				Application.DoEvents();

				Query = "SELECT count(*) as tcount FROM Company WITH(NOLOCK) where comp_journ_id = 0 and comp_active_flag='Y' ";
				Query = $"{Query}and comp_id in (select distinct cref_comp_id ";
				Query = $"{Query}from Aircraft_Reference WITH(NOLOCK) where cref_journ_id = 0 and cref_primary_poc_flag = 'Y') ";
				GetCompany.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(GetCompany.BOF && GetCompany.EOF))
				{
					primarycompanies = Convert.ToInt32(GetCompany["tcount"]);
					txt_primarycompanies.Text = $"{primarycompanies.ToString()} primary companies";
				}
				else
				{
					primarycompanies = 0;
					txt_primarycompanies.Text = "0 primary companies";
				}
				GetCompany.Close();
				GetCompany = null;
				Application.DoEvents();

				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Counting Companies Needing Confirmation. Please Wait!...", Color.Blue);
				Application.DoEvents();

				daysconfirm = Convert.ToInt32(Double.Parse(cbo_days_confirm.Text));

				targetdate = DateTime.Parse(modAdminCommon.DateToday).AddDays(-daysconfirm);
				strTargetDate = targetdate.ToString("MM/dd/yyyy");

				Query = $"EXEC HomebaseGetCompaniesNeedConfirm '{strTargetDate}'";
				GetConfirm.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(GetConfirm.BOF && GetConfirm.EOF))
				{
					GetConfirm.MoveFirst();

					while(!GetConfirm.EOF)
					{
						totalcompaniestoconfirm++;
						GetConfirm.MoveNext();
					};
				}
				else
				{
					totalcompaniestoconfirm = 0;
				}
				// totalcompaniestoconfirm = 0

				GetConfirm.Close();
				GetConfirm = null;

				modStatusBar.Update_Status_Bar(modAdminCommon.SB, "Counting Primary Companies Needing Confirmation. Please Wait!...", Color.Blue);
				Application.DoEvents();
				primarytoconfirm = 0;

				Query = $"EXEC HomebaseGetPrimaryCompaniesNeedConfirm '{strTargetDate}'";
				GetConfirm.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(GetConfirm.BOF && GetConfirm.EOF))
				{
					GetConfirm.MoveFirst();

					while(!GetConfirm.EOF)
					{
						primarytoconfirm++;
						GetConfirm.MoveNext();
					};
				}
				else
				{
					primarytoconfirm = 0;
				}
				GetConfirm.Close();
				GetConfirm = null;

				primaryconfirmed = primarycompanies - primarytoconfirm;
				percentprimaryconfirmed = (primaryconfirmed / ((double) primarycompanies)) * 100;
				txt_primaryconfirmed.Text = $"{primaryconfirmed.ToString()} ({Strings.FormatNumber(percentprimaryconfirmed, 1, TriState.True, TriState.False, TriState.UseDefault)}%) primary confirmed";
				percentcompaniestoconfirm = (totalcompaniestoconfirm / ((double) totalcompanies)) * 100;
				txt_totalnonconfirmedcompanies.Text = $"{totalcompaniestoconfirm.ToString()} ({Strings.FormatNumber(percentcompaniestoconfirm, 1, TriState.True, TriState.False, TriState.UseDefault)}%) need confirmation";

				totalcompaniesconfirmed = totalcompanies - totalcompaniestoconfirm;
				percentcompaniesconfirmed = (totalcompaniesconfirmed / ((double) totalcompanies)) * 100;

				percentprimaryneedconfirm = (primarytoconfirm / ((double) primarycompanies)) * 100;
				txt_primaryneedconfirm.Text = $"{(primarytoconfirm.ToString())} ({Strings.FormatNumber(percentprimaryneedconfirm, 1, TriState.True, TriState.False, TriState.UseDefault)}%) need confirmation";
				txt_totalconfirmedcompanies.Text = $"{totalcompaniesconfirmed.ToString()} ({Strings.FormatNumber(percentcompaniesconfirmed, 1, TriState.True, TriState.False, TriState.UseDefault)}%) confirmed";
				Application.DoEvents();
				this.Cursor = CursorHelper.CursorDefault;
				HadHourglass = false;
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
				tmpHowLong = (int) DateAndTime.DateDiff("s", DateTime.Parse(tmpStart), DateTime.Parse(DateTime.Parse(modAdminCommon.GetDateTime()).ToString("HH:mm:ss")), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
				modAdminCommon.Record_Event("User_Accounts ColorConfirmStatus", $"{Convert.ToString(modAdminCommon.snp_User["user_id"])} Finished [Time Elapsed: {tmpHowLong.ToString()} Seconds]");
			}
			catch (System.Exception excep)
			{
				this.Cursor = CursorHelper.CursorDefault;
				HadHourglass = false;
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
				modAdminCommon.Report_Error($"Get_Company_Confirmation_Error:{excep.Message}");
			}

		}

		private bool Check_Time(string inTime)
		{

			bool result = false;
			result = true;
			if (Strings.Len(inTime.Trim()) == 0)
			{
				return result;
			}
			inTime = inTime.Trim().ToUpper();

			if ((inTime.IndexOf(':') + 1) == 0)
			{
				result = false;
			}

			if (inTime.Substring(Math.Max(inTime.Length - 2, 0)) != "AM" && inTime.Substring(Math.Max(inTime.Length - 2, 0)) != "PM")
			{
				result = false;
			}

			if (!Information.IsNumeric(inTime.Substring(0, Math.Min(1, inTime.Length))))
			{
				result = false;
			}
			return result;
		}

		private string GetUserAccountRep(string inUser)
		{

			string result = "";
			ADORecordSetHelper snpGetAccount = new ADORecordSetHelper();

			string Query = $"SELECT user_default_account_id FROM [User] WITH(NOLOCK) WHERE user_id='{inUser}'";

			snpGetAccount.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

			if (!(snpGetAccount.BOF && snpGetAccount.EOF))
			{
				snpGetAccount.MoveFirst();
				result = Convert.ToString(snpGetAccount["user_default_account_id"]);
			}
			else
			{
				result = "";
			}

			snpGetAccount.Close();

			return result;
		}

		private int Get_Companies_Verified_Information(string strUserId, string strAcctRep)
		{

			ADORecordSetHelper rstRec1 = new ADORecordSetHelper();



			string strStartDate = MonthView1.SelectionRange.Start.ToString("MM/dd/yyyy");
			string strEndDate = MonthView2.SelectionRange.Start.ToString("MM/dd/yyyy");

			string strStartTime = ($"{txt_start_time.Text} ").Trim();
			string strEndTime = ($"{txt_end_time.Text} ").Trim();

			if (strStartTime != "")
			{
				strStartDate = $"{strStartDate} {strStartTime}";
			}
			if (strEndTime != "")
			{
				strEndDate = $"{strEndDate} {strEndTime}";
			}

			string strQuery1 = "SELECT COUNT(comp_id) AS TotCnt FROM Company WITH (NOLOCK) ";
			strQuery1 = $"{strQuery1}WHERE (comp_journ_id = 0)  AND (comp_account_id = '{strAcctRep}') ";
			strQuery1 = $"{strQuery1}AND (";
			strQuery1 = $"{strQuery1}     (comp_upd_date BETWEEN '{strStartDate}' AND '{strEndDate}') ";
			strQuery1 = $"{strQuery1}  OR (comp_action_date BETWEEN '{strStartDate}' AND '{strEndDate}') ";
			strQuery1 = $"{strQuery1}    ) ";

			strQuery1 = $"{strQuery1}AND ( ";
			strQuery1 = $"{strQuery1}           (comp_address_confirm_date BETWEEN '{strStartDate}' AND '{strEndDate}') ";
			strQuery1 = $"{strQuery1}        OR (comp_web_confirm_date BETWEEN '{strStartDate}' AND '{strEndDate}') ";
			strQuery1 = $"{strQuery1}        OR (comp_email_confirm_date BETWEEN '{strStartDate}' AND '{strEndDate}') ";
			strQuery1 = $"{strQuery1}        OR (EXISTS (SELECT NULL FROM Phone_Numbers WITH (NOLOCK) ";
			strQuery1 = $"{strQuery1}                    WHERE (pnum_comp_id = comp_id) ";
			strQuery1 = $"{strQuery1}                    AND (pnum_journ_id = comp_journ_id) ";
			strQuery1 = $"{strQuery1}                    AND (pnum_contact_id = 0) ";
			strQuery1 = $"{strQuery1}                    AND (pnum_confirm_date BETWEEN '{strStartDate}' AND '{strEndDate}') ";
			strQuery1 = $"{strQuery1}                   )    )   ) ";

			rstRec1.Open(strQuery1, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

			int lTotCnt = 0;
			if (!rstRec1.BOF && !rstRec1.EOF)
			{
				lTotCnt = Convert.ToInt32(rstRec1["TotCnt"]);
			}

			rstRec1.Close();
			rstRec1 = null;

			return lTotCnt;

		} // Get_Companies_Verified_Information
	}
}